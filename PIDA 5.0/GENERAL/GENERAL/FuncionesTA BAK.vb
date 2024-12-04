''' <summary>
''' Funciones requeridas para análisis de información TA
''' * Evaluador
''' * AnalisisHrsBrt
''' * AnalisisHrsBrtPares
''' * AsistenciaPerfecta
''' ... etc.
''' </summary>
''' <remarks></remarks>
Module FuncionesTA
    Dim dtTemp As New DataTable
    Dim dtHrsBrtTEMP As New DataTable   'Temporal para guardar lo que hay en horas en bruto antes de borrarlo, para mantener bitácora

    'VARIABLES GLOBALES
    Public dtHrsBrt As New DataTable

    Public _pri_ent_ult_sal As Boolean
    Public _aus_natural As String = ""
    Public _aus_festivo As String
    Public AutorizarExtra As Boolean
    Public FiltroExtras As String = ""
    Public FiltroExtrasAutorizadas As String = ""

    Public drHorarios() As DataRow
    Public drHorario As DataRow
    Public AnalizarES As Boolean
    'Manejo de horario mixto, qué semana trabaja, 1 o 2. Si no es mixto, tiposemana = 1
    Public Semana As DetalleSemana
    Public FechaIni As Date
    Public FechaFin As Date
    Public DiaSemana As Integer

    Public Sub analisis_cafeteria(reloj As String, fecha_inicio As Date)
        Try

            Dim semana As DetalleSemana = SemanaHorarioMixto(ObtenerAnoPeriodo(fecha_inicio), reloj)
            Dim dtHorario As DataTable = sqlExecute("select *, case when cod_dia = '7' then case when cod_dia_sal = '1' then '1' else '0' end else case when cod_dia_sal > cod_dia then 1 else 0 end end as sal_dia_siguiente from dias where cod_hora in ('" & semana.cod_hora & "') and semana = '" & semana.NumSemana & "' and cod_dia = '" & IIf(fecha_inicio.DayOfWeek = DayOfWeek.Sunday, 7, fecha_inicio.DayOfWeek) & "'")
            Dim drHorario As DataRow = dtHorario.Rows(0)

            Dim haytiempotiempo As Boolean = False
            'Dim FechaTiempoTiempo As String = ""

            Dim dtExcepcionesDescanso As DataTable = sqlExecute("select * from tiempo_x_tiempo where reloj = '" & reloj & "' and fecha_intercambio = '" & FechaSQL(fecha_inicio) & "'")
            If dtExcepcionesDescanso.Rows.Count > 0 Then
                HayTiempoTiempo = True

                Dim drow_excepcion As DataRow = dtExcepcionesDescanso.Rows(0)
                Dim dia_sem As Integer = Date.Parse(drow_excepcion("fecha_original")).DayOfWeek
                If dia_sem = 0 Then : dia_sem = 7 : End If

                Dim dtHorarioTiempo = sqlExecute("select * from dias where cod_hora = '" & drow_excepcion("cod_hora") & "' and cod_dia = '" & dia_sem & "' and semana = '" & drHorario("semana") & "'")
                If dtHorarioTiempo.Rows.Count > 0 Then
                    For Each column As DataColumn In dtHorarioTiempo.Columns
                        drHorario(column.ColumnName) = dtHorarioTiempo.Rows(0)(column.ColumnName)
                    Next
                End If
            End If


            '**********************************************
            Dim HayExcepcion As Boolean = False
            Dim dtHayExcepcion As DataTable = sqlExecute("select * from excepciones_horarios where reloj = '" & reloj & "' AND fecha = '" & FechaSQL(fecha_inicio) & "'")
            If dtHayExcepcion.Rows.Count > 0 Then
                HayExcepcion = True

                Dim horario_excepcion As String = dtHayExcepcion.Rows(0)("cod_hora")
                Dim dtInfoHorarioExcepcion As DataTable = sqlExecute("select * from excepciones_dias where cod_hora = '" & horario_excepcion & "'")
                Dim drow_ex As DataRow = dtInfoHorarioExcepcion.Rows(0)
                drHorario("entra") = drow_ex("entrada")
                drHorario("sale") = drow_ex("salida")
                drHorario("rango_hrs") = drow_ex("rango_hrs")

                drHorario("sal_dia_siguiente") = drow_ex("sal_sig_dia")
            End If

            '**********************************************
             Dim descanso As Integer = drHorario("descanso")
            'Dim dia_siguiente As Integer = drHorario("sal_dia_siguiente")
            ' Dim inicio As DateTime = DateTime.Parse(FechaSQL(fecha_inicio) & Space(1) & MerMilitar(drHorario("entra")))
            ' Dim inicio As DateTime = DateTime.Parse(FechaSQL(fecha_inicio) & Space(1) & MerMilitar("06:00"))
            'Dim fin As DateTime = DateTime.Parse(FechaSQL(fecha_inicio.AddDays(dia_siguiente)) & Space(1) & MerMilitar(drHorario("sale")))


            Dim dtMarcajes As DataTable = sqlExecute("select * from hrs_brt_cafeteria where reloj = '" & reloj & "' and fecha = '" & FechaSQL(fecha_inicio) & "' and (subsidio <> 'B' or subsidio is null) order by fecha, hora, id_registro", "TA")

            Dim f As String = ""
            Dim h As String = ""

            Dim subsidio_utilizado As Boolean = False

            For Each row As DataRow In dtMarcajes.Select("", "fecha, hora, id_registro")

                Dim id As String = row("id_registro")
                Dim marcaje As DateTime = DateTime.Parse(row("fecha") & Space(1) & row("hora"))
                Dim tipo_servicio As String = ""

                Dim q As String = ""
                q = "update hrs_brt_cafeteria set hrs_brt_cafeteria.horario = horarios_cafeteria.cod_hora_cafe, hrs_brt_cafeteria.subsidio = horarios_cafeteria.genera_costo" & Space(1) & _
                    "from hrs_brt_cafeteria" & Space(1) & _
                    "left join horarios_cafeteria on hrs_brt_cafeteria.hora between horarios_cafeteria.inicio and horarios_cafeteria.fin" & Space(1) & _
                    "where hrs_brt_cafeteria.reloj = '" & reloj & "' and fecha = '" & FechaSQL(row("fecha")) & "' and hora = '" & row("hora") & "' and id_registro = '" & id & "'"
                sqlExecute(q, "TA")


                Dim dttipo As DataTable = sqlExecute("select * from hrs_brt_cafeteria where id_registro = '" & id & "'", "TA")
                If dttipo.Rows.Count > 0 Then
                    tipo_servicio = dttipo.Rows(0).Item("horario").ToString.Trim
                End If

                If h <> "" Then

                    If subsidio_utilizado = True Then

                        Dim dif = DateDiff(DateInterval.Minute, DateTime.Parse(f & " " & h), marcaje)
                        If dif < 240 Then
                            If tipo_servicio = "D" Or tipo_servicio = "M" Then
                                sqlExecute("update hrs_brt_cafeteria set subsidio = 'Z' where reloj = '" & reloj & "' and fecha = '" & FechaSQL(row("fecha")) & "' and hora = '" & row("hora") & "' and id_registro = '" & id & "'", "TA")
                            Else
                                sqlExecute("update hrs_brt_cafeteria set subsidio = 'S' where reloj = '" & reloj & "' and fecha = '" & FechaSQL(row("fecha")) & "' and hora = '" & row("hora") & "' and id_registro = '" & id & "'", "TA")
                            End If

                        Else
                            sqlExecute("update hrs_brt_cafeteria set subsidio = 'N' where reloj = '" & reloj & "' and fecha = '" & FechaSQL(row("fecha")) & "' and hora = '" & row("hora") & "' and id_registro = '" & id & "'", "TA")
                        End If

                    Else
                        If tipo_servicio = "D" Or tipo_servicio = "M" Then
                            Dim dif = DateDiff(DateInterval.Minute, DateTime.Parse(f & " " & h), marcaje)
                            If dif < 240 Then
                                sqlExecute("update hrs_brt_cafeteria set subsidio = 'Z' where reloj = '" & reloj & "' and fecha = '" & FechaSQL(row("fecha")) & "' and hora = '" & row("hora") & "' and id_registro = '" & id & "'", "TA")
                            Else
                                sqlExecute("update hrs_brt_cafeteria set subsidio = 'N' where reloj = '" & reloj & "' and fecha = '" & FechaSQL(row("fecha")) & "' and hora = '" & row("hora") & "' and id_registro = '" & id & "'", "TA")
                            End If
                        End If
                    End If


                End If

                f = FechaSQL(row("fecha"))
                h = row("hora")


                If descanso <> 0 Then
                    q = "update hrs_brt_cafeteria set hrs_brt_cafeteria.subsidio = 'D'" & Space(1) & _
                    "where hrs_brt_cafeteria.reloj = '" & reloj & "' and fecha = '" & FechaSQL(row("fecha")) & "' and hora = '" & row("hora") & "' and id_registro = '" & id & "'"
                    sqlExecute(q, "TA")
                End If

                If subsidio_utilizado = False Then
                    Try
                        Dim dtCobrado As DataTable = sqlExecute("select * from hrs_brt_cafeteria where id_registro = '" & id & "' and subsidio in ('C', 'S')", "TA")
                        If dtCobrado.Rows.Count > 0 Then
                            subsidio_utilizado = True
                        End If
                    Catch ex As Exception

                    End Try
                End If

            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "analisis_cafeteria", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub analisis_independiente(_reloj_analisis As String, _fecha_analisis As Date, Optional semana_completa As Boolean = False, Optional forzar_pares As Boolean = False, Optional preus As Boolean = False, Optional solo_33 As Boolean = False)

        _fecha_analisis = _fecha_analisis.Date

        Dim f_fin_analisis As Date = _fecha_analisis

        Try
            If semana_completa Then
                Dim dtPeriodos As DataTable = sqlExecute("select * from periodos where '" & FechaSQL(_fecha_analisis) & "' between fecha_ini and fecha_fin and periodo_especial = 0", "ta")
                If dtPeriodos.Rows.Count > 0 Then
                    Dim f_ini As Date = dtPeriodos.Rows(0)("fecha_ini")
                    Dim f_fin As Date = dtPeriodos.Rows(0)("fecha_fin")
                    While f_ini <= f_fin
                        analisis_cafeteria(_reloj_analisis, f_ini)
                        f_ini = f_ini.AddDays(1)
                    End While
                End If
            Else
                analisis_cafeteria(_reloj_analisis, _fecha_analisis)
            End If


        Catch ex As Exception

        End Try

        Dim dtEmpleados As DataTable = sqlExecute("select * from personalvw where reloj = '" & _reloj_analisis & "'")
        If dtEmpleados.Rows.Count > 0 Then
            Dim drEmpleado As DataRow = dtEmpleados.Rows(0)

            Dim dtPeriodo As DataTable = sqlExecute("select * from periodos where '" & FechaSQL(_fecha_analisis) & "' between fecha_ini and fecha_fin and isnull(periodo_especial, 0) = '0'", "TA")
            If dtPeriodo.Rows.Count > 0 Then

                Dim ano As String = dtPeriodo.Rows(0)("ano")
                Dim periodo As String = dtPeriodo.Rows(0)("periodo")

                Dim fecha_ini_periodo As Date = dtPeriodo.Rows(0)("fecha_ini")
                Dim fecha_fin_periodo As Date = dtPeriodo.Rows(0)("fecha_fin")

                If solo_33 Then
                    Dim dtASist_33 As DataTable = sqlExecute("select * from asist where reloj = '" & _reloj_analisis & "' and fha_ent_hor between '" & FechaSQL(fecha_ini_periodo) & "' and '" & FechaSQL(fecha_fin_periodo) & "'", "TA")
                    LlenaNomSem(drEmpleado, ano & periodo, dtASist_33)
                    Exit Sub
                End If

                ConsultaBitacora(dtEmpleados, drEmpleado, fecha_fin_periodo)

                Dim semana As DetalleSemana = SemanaHorarioMixto(ano & periodo, _reloj_analisis)
                Dim dtHorarios = sqlExecute("SELECT horarios.*,dias.*,TA.DBO.HORA12A24(ENTRA) AS ENTRADA24  " & _
                                        "FROM horarios LEFT JOIN dias ON horarios.cod_hora = dias.cod_hora AND horarios.cod_comp = dias.cod_comp " & _
                                        "WHERE horarios.cod_comp = '" & drEmpleado("cod_comp") & "' AND horarios.cod_hora = '" & drEmpleado("cod_hora") & _
                                        "' AND semana = " & semana.NumSemana)

                'Variables por usuario

                Dim _cod_comp As String = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp")).ToString.Trim
                Dim _cod_tipo As String = IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo")).ToString.Trim
                Dim _cod_turno As String = IIf(IsDBNull(drEmpleado("cod_turno")), "", drEmpleado("cod_turno")).ToString.Trim
                Dim _cod_hora As String = IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora")).ToString.Trim
                Dim _alta As Date = drEmpleado("alta")
                Dim _baja As Date = IIf(IsDBNull(drEmpleado("baja")), DateSerial(2100, 1, 1), drEmpleado("baja"))
                Dim _checa_tarjeta As Boolean = IIf(IsDBNull(drEmpleado("checa_tarjeta")), True, drEmpleado("checa_tarjeta"))

                Dim dtTemp As DataTable = sqlExecute("SELECT tran_cerrada FROM nomsem WHERE reloj = '" & drEmpleado("reloj") & "' AND ano + periodo = '" & ano & periodo & "'", "TA")
                If dtTemp.Rows.Count > 0 Then
                    'Si el registro se localiza en NomSem, y está registrado como transacción cerrada, regresa al siguiente registro del FOR
                    If IIf(IsDBNull(dtTemp.Rows(0).Item("tran_cerrada")), 0, dtTemp.Rows(0).Item("tran_cerrada")) = 1 Then
                        Exit Sub
                    End If
                End If

                If semana_completa Then

                    _fecha_analisis = fecha_ini_periodo
                    f_fin_analisis = fecha_fin_periodo

                    'Si se seleccionó la semana completa, borrar datos de toda la semana
                    sqlExecute("DELETE FROM asist WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & _reloj_analisis & _
                                  "' AND fha_ent_hor BETWEEN '" & _
                               FechaSQL(_fecha_analisis) & "' AND '" & FechaSQL(f_fin_analisis) & "'", "TA")
                    sqlExecute("UPDATE hrs_brt SET fecha_efva = NULL WHERE RELOJ ='" & _reloj_analisis & "' AND fecha_efva BETWEEN '" & _
                               FechaSQL(_fecha_analisis) & "' AND '" & FechaSQL(f_fin_analisis) & "'", "TA")


                End If

                If forzar_pares Then
                    AnalisisHrsBrtPares(drEmpleado, ano, periodo, _fecha_analisis, f_fin_analisis)


                    Do While _fecha_analisis <= f_fin_analisis
                        'Si la pantalla de frmTrabajando fue cerrada, cancelar procedimiento                        

                        DiaSemana = Weekday(_fecha_analisis, IIf(IniciaLunes, FirstDayOfWeek.Monday, FirstDayOfWeek.Sunday))
                        'Tomar información de horarios y días

                        drHorarios = dtHorarios.Select("cod_dia = " & DiaSemana, "entrada24")

                        If drHorarios.Count > 0 Then
                            drHorario = drHorarios(0)
                        Else
                            Exit Sub
                        End If

                        'Analizar solo si estuvo activo en el periodo
                        If _fecha_analisis >= _alta And _fecha_analisis <= _baja Then
                            'Evaluar las horas en bruto, para llenar el asist
                            Evaluador(drEmpleado, _fecha_analisis, periodo, ano)
                        End If
                        'Incrementar la fecha en 1 día
                        _fecha_analisis = DateAdd(DateInterval.Day, 1, _fecha_analisis)
                    Loop
                Else
                    Do While _fecha_analisis <= f_fin_analisis
                        'Si la pantalla de frmTrabajando fue cerrada, cancelar procedimiento


                        DiaSemana = Weekday(_fecha_analisis, IIf(IniciaLunes, FirstDayOfWeek.Monday, FirstDayOfWeek.Sunday))
                        'Tomar información de horarios y días

                        drHorarios = dtHorarios.Select("cod_dia = " & DiaSemana, "entrada24")

                        If drHorarios.Count > 0 Then
                            drHorario = drHorarios(0)
                        Else
                            Exit Sub
                        End If

                        If Not semana_completa Then
                            'Borrar datos de asist que pudiera haber de esta fecha
                            sqlExecute("DELETE FROM asist WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & _reloj_analisis & _
                                  "' AND fha_ent_hor ='" & _
                                       FechaSQL(_fecha_analisis) & "'", "TA")
                            'Borrar fecha efectiva del hrs_brt, que pudiera haber quedado de evaluaciones anteriores
                            sqlExecute("UPDATE hrs_brt SET fecha_efva = NULL WHERE RELOJ ='" & _reloj_analisis & "' AND fecha_efva = '" & FechaSQL(_fecha_analisis) & "'", "TA")
                        End If

                        'Analizar solo si estuvo activo en el periodo
                        If _fecha_analisis >= _alta And _fecha_analisis <= _baja Then
                            'Analizar horas en bruto, para asignar entradas y salidas
                            If drHorario("descanso") Then
                                'Día de descanso analizar tipo forzar pares
                                AnalisisHrsBrtPares(drEmpleado, ano, periodo, _fecha_analisis, _fecha_analisis)
                            Else
                                AnalisisHrsBrt(drEmpleado, _fecha_analisis, periodo, ano)

                            End If
                            My.Application.DoEvents()
                            'Evaluar las horas en bruto, para llenar el asist
                            Evaluador(drEmpleado, _fecha_analisis, periodo, ano)
                        End If

                        'Incrementar la fecha en 1 día
                        _fecha_analisis = DateAdd(DateInterval.Day, 1, _fecha_analisis)
                    Loop
                End If
                'Llenar tabla de NomSem, para el periodo
                Dim dtASist As DataTable = sqlExecute("select * from asist where reloj = '" & _reloj_analisis & "' and fha_ent_hor between '" & FechaSQL(fecha_ini_periodo) & "' and '" & FechaSQL(fecha_fin_periodo) & "'", "TA")
                LlenaNomSem(drEmpleado, ano & periodo, dtASist)

            End If

        End If

    End Sub


    Public Sub Evaluador(ByVal drEmpleado As DataRow, Fecha As Date, Periodo As String, Ano As String, Optional DesdeAsistenciaPerfecta As Boolean = False)

        Dim reloj As String = ""
        reloj = drEmpleado("reloj")

        'sqlExecute("EXEC DiasSemana @fecha = '" & FechaSQL(Fecha) & "'", "TA")

        Dim fIni As DateTime            'Fecha de entrada, considerando rango de horas
        Dim fFin As DateTime            'Fecha de salida, considerando rango de horas

        Dim FechaEntro As Date              'Fecha de entrada
        Dim FechaSalio As Date              'Fecha de salida
        Dim HoraEntro As String = ""        'Hora de entrada
        Dim HoraSalio As String = ""        'Hora de salida
        Dim FechaSalida As Date             'Fecha de salida, de acuerdo a su horario

        Dim dtEvNomSem As New DataTable
        Dim dtCiasTA As New DataTable
        Dim dtHrsBrt As New DataTable
        Dim dtEntrada As New DataTable
        Dim dtSalida As New DataTable

        Dim ChecaTarjeta As Boolean
        Dim Cadena As String = ""
        Dim Hrs As String = "00:00"
        Dim Cafeteria As Double = 0
        Dim HrsNor As String = "00:00"
        Dim Extras As String = "00:00"
        Dim HrsExt As String = "00:00"

        Dim HrsTotales As Double

        Dim ExtrasAutorizadas As String = "00:00"
        Dim ExtrasRealesTabla As String = "00:00"

        Dim HorasTarde As String = "00:00"
        Dim HorasSalidaAnticipada As String = "00:00"
        Dim HorasConvenio As String = "00:00"
        Dim DescansoTrabajado As Boolean = False
        Dim FestivoTrabajado As Boolean = False
        Dim VacacionesTrabajadas As Boolean = False
        Dim EntradaReal As String = "00:00"
        Dim SalidaReal As String = "00:00"
        Dim FEntradaReal As Date
        Dim FSalidaReal As Date

        Dim EsFestivo As Boolean
        Dim EsDescanso As Boolean

        Dim HayExcepcion As Boolean
        Dim horario_excepcion As String = ""

        Dim HayTiempoTiempo As Boolean = False
        Dim FechaTiempoTiempo As String = ""

        Dim retardo_transporte As String = ""

        Dim HayTiempoCompleto As Boolean = False
        Dim HayLactancia As Boolean = False


        '-----------------------------------------------------------------------
        'inicializacion de variables de memoria

        ' _pareja .- El la base de datos de horas en bruto (hrs_brt) existe un campo que define 
        '			 si la transaccion tiene pareja con otra transaccion, al igual que con la variable
        '			 esta indica si el registro activo tiene o no pareja.

        ' _cuenta_extra .- La variable es cargada de horarios.aviso_ex la cual no indica si para determinado 
        '				horario se tomara en cuenta el tiempo extra, esto es si sera tomado en 
        '				cuenta en la tarjeta

        ' _cuenta_extra_antes .- La varieble es cargada de horarios.aviso_ex la cual no indica si para determinado 
        '				horario se tomara en cuenta el tiempo extra, esto es si sera tomado en 
        '				cuenta en la tarjeta


        ' _descanso.-	La variable es cargada de dias.descanso y no indica si el dia es de descanso,
        ' 				si es esto el dia sera tratado de modio especial. (todo el tiempo trabajado 
        '				pasara a tiempo extra)

        ' _seg_horas_ex.- Nos cuanta las horas extras expresadas en segundos

        ' _comentario.- Esta variable guarda los mensajes para la tarjeta, cada paraja (entrada, salida)
        '				tiene un comentario ya sea retardo, ajuste, salida anticipada, etc.

        '**** VARIABLES NO UTILIZADAS ****

        'Dim _descanso As Boolean = False
        'Dim _festivo As Boolean = False
        'Dim _seg_horas_ex As Integer = 0

        'Dim _rango_hrs As String = "00:00"

        'Dim DifEnt As Double
        'Dim DifSal As Double
        '**********************************

        Dim _pareja As Boolean = True
        Dim _abierto As Boolean = False
        Dim _tipo_aus As String = ""
        Dim _comentario As String = ""


        Dim DifEnt As String = ""
        Dim DifSal As String = ""

        Dim _al_ant_ent As Integer = 0
        Dim _al_des_ent As Integer = 0
        Dim _al_ant_sal As Integer = 0
        Dim _al_des_sal As Integer = 0
        Dim _al_horas_ex As Integer = 0

        Dim _cuenta_extra As Boolean = False
        Dim _cuenta_extra_antes As Boolean = False

        Dim ExtraAntes As String = ""                   'Tiempo extra antes de la entrada
        Dim ExtraDespues As String = ""                 'Tiempo extra después de la salida

        Dim FaltaEntrada As Boolean = False
        Dim FaltaSalida As Boolean = False

        Dim AjusteEntrada As Boolean = False
        Dim AjusteSalida As Boolean = False
        Dim TipoTran As String = ""                    'Tipo de transacción. Por default R = Reloj
        Dim MinCafeteria As Decimal
        Dim EsTiempoCompleto As Boolean
        Dim AutorizaTodo As Boolean = False
        Dim Autoriza30 As Boolean = False
        Dim DescontoCafeteria As Boolean = False
        Try
            Reloj = drEmpleado("reloj").ToString.Trim
            'My.Application.DoEvents()

            'Modificar el día con letra en hrs_brt, porque del reloj no traen este campo
            sqlExecute("UPDATE hrs_brt SET dia = '" & DiaSem(Fecha) & "' WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(Fecha) & "'", "TA")

            Dim dtExcepcionesDescanso As DataTable = sqlExecute("select * from tiempo_x_tiempo where reloj = '" & Reloj & "' and fecha_intercambio = '" & FechaSQL(Fecha) & "'")
            If dtExcepcionesDescanso.Rows.Count > 0 Then
                HayTiempoTiempo = True

                Dim drow_excepcion As DataRow = dtExcepcionesDescanso.Rows(0)
                Dim dia_sem As Integer = Date.Parse(drow_excepcion("fecha_original")).DayOfWeek
                If dia_sem = 0 Then : dia_sem = 7 : End If


                Select Case dia_sem
                    Case 1
                        FechaTiempoTiempo = "Lu "
                    Case 2
                        FechaTiempoTiempo = "Ma "
                    Case 3
                        FechaTiempoTiempo = "Mi "
                    Case 4
                        FechaTiempoTiempo = "Ju "
                    Case 5
                        FechaTiempoTiempo = "Vi "
                    Case 6
                        FechaTiempoTiempo = "Sa "
                    Case 7
                        FechaTiempoTiempo = "Do "
                    Case Else
                End Select

                FechaTiempoTiempo &= FechaSQL(Date.Parse(drow_excepcion("fecha_original"))).Replace("-", "/")

                Dim dtHorario = sqlExecute("select * from dias where cod_hora = '" & drow_excepcion("cod_hora") & "' and cod_dia = '" & dia_sem & "' and semana = '" & drHorario("semana") & "'")
                If dtHorario.Rows.Count > 0 Then
                    For Each column As DataColumn In dtHorario.Columns
                        drHorario(column.ColumnName) = dtHorario.Rows(0)(column.ColumnName)
                    Next
                End If
            End If

            Dim dtHayExcepcion As DataTable = sqlExecute("select * from excepciones_horarios where reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(Fecha) & "'")
            If dtHayExcepcion.Rows.Count > 0 Then
                HayExcepcion = True

                sqlExecute("update excepciones_horarios set fecha_analisis = getdate(), usuario_analisis = '" & Usuario.Trim & "'  where reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(Fecha) & "'")

                horario_excepcion = dtHayExcepcion.Rows(0)("cod_hora")
                Dim dtInfoHorarioExcepcion As DataTable = sqlExecute("select * from excepciones_dias where cod_hora = '" & horario_excepcion & "'")
                Dim drow_ex As DataRow = dtInfoHorarioExcepcion.Rows(0)
                drHorario("entra") = drow_ex("entrada")
                drHorario("sale") = drow_ex("salida")
                drHorario("rango_hrs") = drow_ex("rango_hrs")

                Dim sal_sig_dia As Integer = drow_ex("sal_sig_dia")
                If sal_sig_dia = 1 Then
                    Dim dia_sem As Integer = drHorario("cod_dia")
                    If dia_sem = 7 Then
                        drHorario("cod_dia_sal") = 1
                    Else
                        drHorario("cod_dia_sal") = dia_sem + 1
                    End If
                Else
                    drHorario("cod_dia_sal") = drHorario("cod_dia")

                    drHorario("extra_fijo") = drow_ex("extra_fijo")
                End If
            End If

            '*** TIEMPO COMPLETO

            Dim dtHayTiempoCompleto As DataTable = sqlExecute("select * from ta.dbo.TiempoCompleto where reloj = '" & reloj & "' AND fecha = '" & FechaSQL(Fecha) & "'")
            If dtHayTiempoCompleto.Rows.Count > 0 Then
                HayTiempoCompleto = True
            End If

            Dim dtLactancia As DataTable = sqlExecute("select * from personal.dbo.detalle_auxiliares where reloj = '" & reloj & "' and CAMPO = 'LACTANCIA' and CONTENIDO = 'SI'")
            If dtLactancia.Rows.Count > 0 Then
                HayLactancia = True
                HayTiempoCompleto = True
            End If


            '** TIEMPO EXTRA FIJO ***************************************

            Try
                Dim extra_fijo As Double = HtoD(drHorario("extra_fijo"))
                If extra_fijo > 0 Then
                    Dim dtAutorizado As DataTable = sqlExecute("select * from extras_autorizadas where reloj = '" & reloj & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                    If dtAutorizado.Rows.Count <= 0 Then
                        sqlExecute("insert into extras_autorizadas (reloj, fecha, extras_reales, extras_autorizadas, entrada, salida, autori_a1) values ('" & _
                                  reloj & "', '" & _
                                  FechaSQL(Fecha) & "', '', '" & _
                                  DtoH(extra_fijo) & "', '" & _
                                  HoraEntro & "', '" & _
                                  HoraSalio & "', '1')", "TA")
                        bitacora_tiempo_extra(reloj, Fecha, DtoH(extra_fijo))
                        Dim dtMasReciente As DataTable = sqlExecute("select * from bitacora_te where reloj = '" & reloj & "' and fecha = '" & FechaSQL(Fecha) & "' order by fecha_hora desc", "ta")
                        If dtMasReciente.Rows.Count > 0 Then
                            Dim _orden As Integer = dtMasReciente.Rows(0)("orden")
                            sqlExecute("update bitacora_te set enviado = getdate() where reloj = '" & reloj & "' and fecha = '" & FechaSQL(Fecha) & "' and orden = '" & _orden & "'", "TA")
                        Else
                            sqlExecute("update bitacora_te set enviado = getdate() where reloj = '" & reloj & "' and fecha = '" & FechaSQL(Fecha) & "' and orden = '1'", "TA")

                        End If
                    End If


                End If
            Catch ex As Exception

            End Try

            '***********************************************************



            ChecaTarjeta = IIf(IsDBNull(drEmpleado("checa_tarjeta")), True, drEmpleado("checa_tarjeta"))
            'If Not ChecaTarjeta And Not DesdeAsistenciaPerfecta Then
            '    'Si el empleado no checa tarjeta, poner asistencia perfecta
            '    AsistenciaPerfecta(drEmpleado, Fecha, Ano & Periodo, _pri_ent_ult_sal)
            '    AnalisisHrsBrt(drEmpleado, Fecha, Periodo, Ano)
            'End If

            'Abraham CAsas 2016-08-08
            If Not ChecaTarjeta And Not DesdeAsistenciaPerfecta Then
                'Si el empleado no checa tarjeta, poner asistencia perfecta

                Dim dtTieneAjustes As DataTable = sqlExecute("select * from hrs_brt where reloj = '" & reloj & "' and fecha_efva = '" & FechaSQL(Fecha) & "'", "TA")

                If dtTieneAjustes.Rows.Count = 0 Then
                    If Fecha.Date >= Now.Date Then
                        AsistenciaPerfecta(drEmpleado, Fecha, Ano & Periodo, _pri_ent_ult_sal)
                    End If
                ElseIf dtTieneAjustes.Select("tipo_tran <> 'S'").Count = 0 Then
                    If dtTieneAjustes.Rows.Count Mod 2 = 0 Then
                        AsistenciaPerfecta(drEmpleado, Fecha, Ano & Periodo, _pri_ent_ult_sal)
                    End If
                End If

                AnalisisHrsBrt(drEmpleado, Fecha, Periodo, Ano)
            End If

            'Determinar la hora en que inicia el día, de acuerdo al rango de horas definido
            fIni = DateAdd(DateInterval.Hour, HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))), Fecha)
            'Determinar la hora en que termina el día, de acuerdo al rango de horas definido
            fFin = DateAdd(DateInterval.Hour, HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))) + 24, Fecha)
            FechaSalida = IIf(drHorario("cod_dia") <> drHorario("cod_dia_sal"), DateAdd(DateInterval.Day, 1, Fecha), Fecha)


            'MCR 22/OCT/2015
            'No insertar en bitácora de ausentismo desde el evaluador

            ''MCR 15/OCT/2015
            ''Insertar en bitácora borrado de ausentismo (INSERTAR EN BITACORA ANTES DE BORRAR, PUES SE LLENA DESDE AUSENTISMO)
            'sqlExecute("INSERT INTO bitacora_ausentismo " & _
            '              "(reloj,fecha,tipo_aus,tipo_movimiento,fecha_movimiento,usuario_movimiento,valor_anterior,notas) " & _
            '           "SELECT reloj,fecha,tipo_aus,'B',GETDATE(),'" & Usuario & "','','Borrar ausentismo desde " & _
            '           System.Reflection.MethodBase.GetCurrentMethod.Name() & "' FROM ausentismo WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(Fecha) & _
            '           "' AND tipo_aus IN ('" & _aus_natural & "','AUS')", "TA")

            'Borrar ausentismo de ese día, que sea de tipo ausentismo natural
            sqlExecute("DELETE from ausentismo WHERE reloj = '" & reloj & "' AND fecha = '" & FechaSQL(Fecha) & _
                       "' AND tipo_aus IN ('" & _aus_natural & "','FI')", "TA")



            'Buscar ausentismo ya registrado para esta fecha (incapacidades, vacaciones, etc.)
            dtTemp = sqlExecute("SELECT ausentismo.tipo_aus FROM ausentismo WHERE reloj = '" & reloj & "' AND fecha = '" & _
                                FechaSQL(Fecha) & "'", "TA")
            If dtTemp.Rows.Count > 0 Then
                _tipo_aus = dtTemp.Rows(0).Item("tipo_aus")
            End If

            dtTemp = sqlExecute("SELECT autorizar_extra,filtro_extra,filtro_extra_aut FROM cias_ta WHERE cod_comp = '" & drEmpleado("cod_comp") & "'", "TA")
            If dtTemp.Rows.Count = 0 Then
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "TA", 0, "Falta información de CiasTa para " & drEmpleado("cod_comp"))
                Exit Sub
            Else
                AutorizarExtra = IIf(IsDBNull(dtTemp.Rows(0).Item("autorizar_extra")), 0, dtTemp.Rows(0).Item("autorizar_extra"))
                FiltroExtras = IIf(IsDBNull(dtTemp.Rows(0).Item("filtro_extra")), "", dtTemp.Rows(0).Item("filtro_extra"))
                FiltroExtrasAutorizadas = IIf(IsDBNull(dtTemp.Rows(0).Item("filtro_extra_aut")), "", dtTemp.Rows(0).Item("filtro_extra_aut"))
            End If

            'Revisar si es día festivo o descanso
            EsFestivo = Festivo(Fecha, reloj)
            EsDescanso = DiaDescanso(Fecha, reloj)

            If EsFestivo Then
                'Agregar festivo en ausentismo
                If _tipo_aus <> _aus_festivo And TipoNaturaleza(_tipo_aus) <> "I" Then
                    'Si el tipo de ausentismo encontrado es diferente al festivo (si no hay ausentismo, _tipo_aus = "")  y no es incapacidad

                    'Borrar ausentismo existente
                    sqlExecute("DELETE from ausentismo WHERE reloj = '" & reloj & "' AND fecha = '" & FechaSQL(Fecha) & "'", "TA")

                    'Insertar día festivo en tabla de ausentismo
                    sqlExecute("INSERT INTO ausentismo (cod_comp,reloj,fecha,tipo_aus,periodo,subclasi,usuario,fecha_hora) VALUES ('" & _
                               drEmpleado("cod_comp") & "','" & _
                               drEmpleado("reloj") & "','" & _
                               FechaSQL(Fecha) & "','" & _
                               _aus_festivo & "','" & _
                               Periodo & "','" & _
                               "Evaluador" & "','" & _
                               Usuario & "', " & _
                               "GETDATE())", "TA")
                    _tipo_aus = _aus_festivo
                End If
            End If

            'Obtener todos los registros en esta fecha
            dtEntrada = sqlExecute("SELECT fecha,hora,entrada_salida,faltaba_tran,tipo_tran FROM hrs_brt WHERE RELOJ = '" & reloj & _
                                   "' AND  fecha_efva = '" & FechaSQL(Fecha) & _
                                   "' AND NOT entrada_salida IS NULL ORDER BY fecha ASC,hora ASC", "TA")

            If dtEntrada.Rows.Count = 0 Then
                'Si no se obtuvieron registros de hrs_brt, agregar un registro solo para referencia. 
                'La X indica que no debe considerarlo Entrada ni Salida
                dtEntrada.Rows.Add({Nothing, "", "X", 0, "S"})

                If EsDescanso Then
                    'Si es día de descanso, salir del procedimiento
                    Exit Sub
                ElseIf Not EsFestivo And _tipo_aus.Length = 0 And Fecha <= Now Then
                    'Si no es descanso ni festivo, y no tiene ausentismo registrado, poner el natural
                    'MCR 11/NOV/2015
                    'Cambio de condición a fecha máxima
                    If IIf(IsDBNull(drEmpleado("BAJA")), DateSerial(2999, 1, 1), drEmpleado("BAJA")) >= Fecha Then
                        'MCR 8/Oct/2015                        
                        'Siempre que la fecha de baja sea anterior a la fecha analizada, o en blanco
                        'ACA 1/Nov/2017
                        'En QTO SI incluir falta del dia de la baja
                        _tipo_aus = _aus_natural
                        sqlExecute("INSERT INTO ausentismo (cod_comp,reloj,fecha,tipo_aus,periodo,subclasi,usuario,fecha_hora) VALUES ('" & _
                                   drEmpleado("cod_comp") & "','" & _
                                   drEmpleado("reloj") & "','" & _
                                   FechaSQL(Fecha) & "','" & _
                                   _tipo_aus & "','" & _
                                   Periodo & "','" & _
                                   "Evaluador','" & _
                                   Usuario & "', " & _
                                   "GETDATE())", "TA")
                    Else
                        'MCR 8/Oct/2015
                        'El día de la baja no cuenta ausentismo. No es forzoso que asista.
                        Exit Sub
                    End If

                ElseIf Fecha > Now And _tipo_aus = _aus_natural Then
                    _tipo_aus = ""
                End If
            ElseIf EsDescanso Then
                'MCR 14/OCT/2015
                'Si es descanso, y hay checadas, revisar a qué registro de horario pertenecen, basados en la entrada
                Dim Dif() As Integer
                ReDim Dif(drHorarios.Count - 1)
                Dim i As Integer = 0
                Dim x As Integer
                Dim Min As Integer = 1000

                Dim hora_d = HtoD(dtEntrada.Rows(0)("hora"))
                If 6.5 <= hora_d And hora_d <= 15 Then
                    'MCR 2017-09-27
                    'Buscar el horario que está entre 6.30 y 15.00 hrs
                    For Each dRow As DataRow In drHorarios
                        If HtoD(dRow("entra")) >= 6.5 And HtoD(dRow("entra")) <= 15 Then
                            x = i
                            Exit For
                        End If
                        i += 1
                    Next

                Else

                    For Each dRow As DataRow In drHorarios
                        Dif(i) = Math.Abs(HtoD(RestaHrs(dRow("entra"), dtEntrada(0)("hora"))))
                        i += 1
                    Next

                    For i = 0 To Dif.Count - 1
                        If Dif(i) < Min Then
                            Min = Dif(i)
                            x = i
                        End If
                    Next
                End If
                drHorario = drHorarios(x)

                'Alambrito
                'Si la checada esta entre 6:30 y 15:00, forzar al horario de las 6:30
                'Try
                '    Dim hora_d = HtoD(dtEntrada.Rows(0)("hora"))
                '    If 6.5 <= hora_d And hora_d <= 15 Then
                '        drHorario = drHorarios(1)
                '    End If
                'Catch ex As Exception

                'End Try
            End If


            For x = 0 To dtEntrada.Rows.Count - 1
                FechaEntro = Fecha
                HoraEntro = ""
                FechaSalio = FechaSalida
                HoraSalio = ""

                FaltaEntrada = True
                FaltaSalida = True
                _pareja = False
                _comentario = ""
                _al_ant_ent = 0
                _al_ant_sal = 0
                _al_des_ent = 0
                _al_des_sal = 0
                _al_horas_ex = 0

                'TipoTran = IIf(IsDBNull(dtEntrada.Rows(x).Item("tipo_tran")), "", dtEntrada.Rows(x).Item("tipo_tran"))

                If IsDBNull(dtEntrada.Rows(x).Item("tipo_tran")) Then
                    TipoTran = ""
                ElseIf dtEntrada.Rows(x).Item("tipo_tran") = "O" Then
                    TipoTran = "Olvidó gafete"
                ElseIf dtEntrada.Rows(x).Item("tipo_tran") = "P" Then
                    TipoTran = "Perdió gafete"
                Else
                    TipoTran = ""
                End If

                If dtEntrada.Rows(x).Item("entrada_salida") = "E" Then
                    'Si el registro es una entrada
                    'Poner en falso la variable _pareja, porque aún no sabemos si tiene salida
                    _pareja = False
                    'Llenar las variables con los datos de la entrada
                    FaltaEntrada = False

                    'Si faltaba una transacción, y se puso por ajuste
                    AjusteEntrada = IIf(IsDBNull(dtEntrada.Rows(x).Item("faltaba_tran")), 0, dtEntrada.Rows(x).Item("faltaba_tran")) = 1

                    'Hora y fecha de entrada
                    HoraEntro = MilitarMer(dtEntrada.Rows(x).Item("hora"))
                    FechaEntro = dtEntrada.Rows(x).Item("fecha")
                    If HoraEntro = "**:**" Then
                        HoraEntro = ""
                    End If

                    'Buscar si hay un siguiente registro
                    If x < dtEntrada.Rows.Count - 1 Then
                        'Si hay, revisar si es una salida
                        x = x + 1
                        If dtEntrada.Rows(x).Item("entrada_salida") = "S" Then
                            'Como ya tuvo entrada y salida, poner en verdadero la variable _pareja
                            _pareja = True

                            'Si faltaba una transacción, y se puso por ajuste
                            AjusteSalida = IIf(IsDBNull(dtEntrada.Rows(x).Item("faltaba_tran")), 0, dtEntrada.Rows(x).Item("faltaba_tran")) = 1

                            'Llenar las variables con los datos de la salida
                            FaltaSalida = False
                            HoraSalio = MilitarMer(dtEntrada.Rows(x).Item("hora"))
                            FechaSalio = dtEntrada.Rows(x).Item("fecha")
                            If HoraSalio = "**:**" Then
                                HoraSalio = ""
                            End If
                        Else
                            'Si el siguiente registro no es una salida, devolver el contador para tomar nuevamente el registro
                            'Aunque es casi imposible que haya dos entradas seguidas el mismo día...
                            x = x - 1
                        End If
                    End If
                ElseIf dtEntrada.Rows(x).Item("entrada_salida") = "S" Then
                    'Si el registro es una salida
                    _pareja = False
                    FaltaSalida = False
                    'Si faltaba una transacción, y se puso por ajuste
                    AjusteSalida = IIf(IsDBNull(dtEntrada.Rows(x).Item("faltaba_tran")), 0, dtEntrada.Rows(x).Item("faltaba_tran")) = 1

                    HoraSalio = MilitarMer(dtEntrada.Rows(x).Item("hora"))
                    FechaSalio = dtEntrada.Rows(x).Item("fecha")

                    If HoraSalio = "**:**" Then
                        HoraSalio = ""
                    End If
                End If

                Dim dtsalida_aut As DataTable = sqlExecute("select * from variables where variable = 'HABILITAR_SAL_AUT' and valor = '1'", "KIOSCO")
                If dtsalida_aut.Rows.Count > 0 And FaltaSalida And Not dtEntrada.Rows(0).Item("entrada_salida") = "X" Then
                    'Si el registro es una salida
                    _pareja = True
                    FaltaSalida = False
                    'Si faltaba una transacción, y se puso por ajuste
                    AjusteSalida = 0

                    HoraSalio = drHorario("sale")
                    FechaSalio = FechaSalida

                    If HoraSalio = "**:**" Then
                        HoraSalio = ""
                    End If
                    'Ajuste_salida_cod19(drEmpleado, Fecha, Ano & Periodo, "A")
                    'Evaluador(drEmpleado, Fecha, Periodo, Ano)
                End If


                'Obtener el número total de horas
                If FaltaEntrada Or FaltaSalida Then
                    Hrs = "00:00"
                    HrsNor = "00:00"
                Else
                    Hrs = RestaHrs(FechaEntro, HoraEntro, FechaSalio, HoraSalio)

                    If Hrs.Substring(0, 1) = "-" Or Hrs = "**.**" Then
                        'Si las horas son negativas, o error, hacer 0
                        Hrs = "00:00"
                    End If

                    'Entradas y salidas para contar horas
                    If Not FaltaEntrada Then
                        'If HtoD(HoraEntro) - HtoD(drHorario("min_des_ent")) <= HtoD(drHorario("entra")) Then
                        ''''' REVISAR MCR
                        If HtoD(RestaHrs(Fecha, drHorario("entra"), FechaEntro, HoraEntro)) <= HtoD(drHorario("min_des_ent")) Then
                            'Si el empleado llegó tarde, pero dentro del margen, o llegó antes de la hora, se maneja su horario
                            EntradaReal = drHorario("entra")
                            FEntradaReal = Fecha
                        Else
                            'Si llegó tarde, se utiliza su hora de llegada
                            EntradaReal = HoraEntro
                            FEntradaReal = FechaEntro
                        End If
                    End If
                    Dim DifSalida As Double

                    If Not FaltaSalida Then
                        'If HtoD(MerMilitar(HoraSalio)) + HtoD(drHorario("min_ant_sal")) >= HtoD(MerMilitar(drHorario("sale"))) Then
                        DifSalida = HtoD(RestaHrs(FechaSalio, HoraSalio, FechaSalida, drHorario("sale")))
                        If DifSalida < HtoD(drHorario("min_des_sal")) Then

                            'Si el empleado salió a su hora o antes, pero dentro del margen, 
                            SalidaReal = drHorario("sale")
                            'Obtener el número total de horas con las entradas y salidas ajustadas
                            FSalidaReal = FechaSalida

                        Else
                            'Si salió antes, se utiliza su hora de llegada
                            SalidaReal = HoraSalio
                            FSalidaReal = FechaSalio
                            'Obtener el número total de horas con las entradas y salidas ajustadas
                        End If
                    End If
                    'Obtener el número total de horas con las entradas y salidas ajustadas
                    HrsNor = RestaHrs(FEntradaReal, EntradaReal, FSalidaReal, SalidaReal)

                End If

                'MCR 3/FEB/2016
                If HtoD(HrsNor) < 0 Then
                    'Si las horas son negativas, o error, hacer 0
                    HrsNor = "00:00"
                End If

                'Si se descuenta proporción de cafetería, y las horas trabajadas son mayores o iguales al mínimo para descontar cafetería
                'MCR 11/NOV/2015
                'Acumular horas trabajadas, por si hay varias entradas/salidas


                HrsTotales += HtoD(HrsNor)
                MinCafeteria = HtoD(IIf(IsDBNull(drHorario("minimo_cafeteria")), "", drHorario("minimo_cafeteria")))

                'MCR 3/FEB/2016
                'Si ya se descontó cafetería en este día, igualar a 0
                If DescontoCafeteria Then
                    Cafeteria = 0
                ElseIf EsDescanso Then
                    Cafeteria = 0
                Else
                    If HrsTotales >= MinCafeteria Then
                        If IIf(IsDBNull(drHorario("com_prop")), False, drHorario("com_prop")) Then
                            Cafeteria = (HtoD(IIf(IsDBNull(drHorario("comida")), "00:00", drHorario("comida"))) * HtoD(Hrs)) / HtoD(drHorario("hrs_dia"))
                        Else
                            Cafeteria = HtoD(IIf(IsDBNull(drHorario("comida")), "00:00", drHorario("comida")))
                        End If
                    Else
                        'MCR 11/NOV/2015
                        'Si no cumple el mínimo, reiniciar cafetería a 0, 
                        'por si hay más entradas/salidas del mismo día
                        Cafeteria = 0
                    End If
                End If

                If HtoD(Hrs) > 0 Then
                    If EsDescanso Then
                        DescansoTrabajado = True
                        _comentario = IIf(_comentario.Length > 0, _comentario & ", ", "") & "Descanso trabajado"
                    ElseIf Festivo(Fecha, reloj) Then
                        FestivoTrabajado = True
                    ElseIf TipoNaturaleza(_tipo_aus) = "V" Then
                        VacacionesTrabajadas = True
                    End If
                End If

                'MCR 3/FEB/2016
                'Si no se ha descontado cafetería en este día, descontarla
                If Not DescontoCafeteria Then
                    'Descontar proporción cafetería al total de horas 
                    'Si no se descuenta proporción, Cafetería = 0. Como Cafetería es numérico, se debe convertir a caracter antes de enviarlo como parámtetro 
                    If (DescansoTrabajado Or VacacionesTrabajadas Or FestivoTrabajado) Then
                        'Si es día de descanso trabajado, descontar cafetería de las horas totales
                        Hrs = RestaHrs(DtoH(Cafeteria), Hrs, True)
                    Else
                        'Si es día de trabajo regular, descontar cafetería de las horas normales
                        HrsNor = RestaHrs(DtoH(Cafeteria), HrsNor)
                    End If
                End If

                'MCR 3/FEB/2016
                If Cafeteria > 0 Then DescontoCafeteria = True

                'MCR 3/FEB/2016
                'Efectuar nuevamente comparación, por si al restar cafetería queda negativo
                If HtoD(HrsNor) < 0 Then
                    'Si las horas son negativas, o error, hacer 0
                    HrsNor = "00:00"
                End If


                'Si es horario abierto, y las horas normales son mayores al tiempo que debió trabajar, se ponen las horas de su horario
                'o bien, son vacaciones o festivo
                'o aplica tiempo completo y tiene al menos entrada o salida
                _abierto = IIf(IsDBNull(drHorario("abierto")), False, drHorario("abierto"))
                EsTiempoCompleto = TiempoCompleto(reloj)
                If (_abierto And HtoD(HrsNor) > HtoD(drHorario("hrs_dia"))) _
                        Or TipoNaturaleza(_tipo_aus) = "V" _
                        Or _tipo_aus = _aus_festivo Then
                    HrsNor = drHorario("hrs_dia")
                ElseIf EsTiempoCompleto And Not (FaltaEntrada And FaltaSalida) And Not EsDescanso Then
                    If x <= 1 Then
                        HrsNor = drHorario("hrs_dia")
                    Else
                        HrsNor = "00:00"
                    End If
                End If
                If x > 1 Then
                    'Stop
                End If

                'Si cuenta el tiempo extra después de la salida o antes de la entrada
                _cuenta_extra = IIf(IsDBNull(drHorario("cuenta_ex")), False, drHorario("cuenta_ex"))
                _cuenta_extra_antes = IIf(IsDBNull(drHorario("cuenta_ex_antes")), False, drHorario("cuenta_ex_antes"))

                If _cuenta_extra Or _cuenta_extra_antes Then

                    If DescansoTrabajado Then
                        'NO--- Si trabajó el día de descanso, todas las horas son extras
                        'HrsExt = Hrs

                        HrsNor = "00:00"
                        'MCR 13/OCT/2015
                        'Aún en descanso, solo tomar el tiempo extra antes de la entrada si así se define

                        If Not _cuenta_extra_antes And Not FaltaEntrada Then
                            If HtoD(RestaHrs(Fecha, drHorario("entra"), FechaSalio, HoraSalio)) < 0 Then
                                'Si entró y salió antes de su horario de entrada, las extras solo son las que trabajó
                                ExtraAntes = Hrs
                            Else
                                'Si entró temprano, luego continuó con su horario, las extras antes son las que falten entre su entrada y la entrada del horario
                                ExtraAntes = RestaHrs(FechaEntro, HoraEntro, Fecha, EntradaReal)
                            End If
                        Else
                            ExtraAntes = ""
                        End If

                        HrsExt = DtoH(HtoD(Hrs) - HtoD(ExtraAntes))

                    ElseIf FestivoTrabajado Then
                        'MCR 8/OCT/2015
                        'Las vacaciones trabajadas se pagan como día normal
                        'a petición de Magdalena Belmont
                        'Or VacacionesTrabajadas Then
                        '

                        'Si trabajó en vacaciones o festivo, todas las horas son extras
                        'y las horas normales son las que trabaja por día de acuerdo a su horario
                        HrsExt = Hrs
                    ElseIf _abierto Then
                        'Si es horario abierto, ver condiciones
                        'MessageBox.Show("PENDIENTE HORARIO ABIERTO")
                    ElseIf Not EsFestivo Then
                        If _cuenta_extra_antes And Not FaltaEntrada Then
                            If HtoD(RestaHrs(Fecha, drHorario("entra"), FechaSalio, HoraSalio)) < 0 Then
                                'Si entró y salió antes de su horario de entrada, las extras solo son las que trabajó
                                ExtraAntes = Hrs
                            Else
                                'Si entró temprano, luego continuó con su horario, las extras antes son las que falten entre su entrada y la entrada del horario
                                ExtraAntes = RestaHrs(FechaEntro, HoraEntro, Fecha, EntradaReal)
                            End If
                        Else
                            ExtraAntes = ""
                        End If

                        If _cuenta_extra And Not FaltaSalida Then
                            If HtoD(RestaHrs(FechaEntro, HoraEntro, FechaSalio, drHorario("sale"))) < 0 And x > 1 Then
                                'Si entró y salió después de su horario de entrada, las extras solo son las que trabajó
                                ExtraDespues = Hrs
                            Else
                                'Si entró temprano, luego continuó con su horario, las extras antes son las que falten entre su entrada y la entrada del horario
                                ExtraDespues = RestaHrs(FechaSalida, SalidaReal, FechaSalio, HoraSalio)
                            End If

                            If HtoD(ExtraDespues) < 0 Then ExtraDespues = ""
                        Else
                            ExtraDespues = ""
                        End If

                        Dim horas_extra_d As Double = 0
                        If HtoD(ExtraAntes) >= HtoD(drHorario("aviso_extra")) Then
                            horas_extra_d += HtoD(ExtraAntes)
                        End If

                        If HtoD(ExtraDespues) >= HtoD(drHorario("aviso_extra")) Then
                            horas_extra_d += HtoD(ExtraDespues)
                        End If

                        HrsExt = DtoH(horas_extra_d)

                    End If
                End If

                'Alerta de tiempo antes o después de entrada
                'Si no es descanso, festivo, o incapacidad
                If Not EsDescanso And Not EsFestivo And TipoNaturaleza(_tipo_aus) <> "I" Then
                    DifEnt = RestaHrs(FechaEntro, HoraEntro, Fecha, drHorario("entra"))


                    '****************
                    Dim dif_ent_d As Double = HtoD(DifEnt)
                    Dim dtRetardoTransporte As DataTable = sqlExecute("select * from retardo_transporte where reloj = '" & reloj & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                    If dtRetardoTransporte.Rows.Count > 0 Then
                        Dim limite_permiso As Double = HtoD(dtRetardoTransporte.Rows(0)("tiempo")) * -1
                        If limite_permiso <= dif_ent_d Then
                            DifEnt = "00:00"
                            retardo_transporte = dtRetardoTransporte.Rows(0)("tiempo")
                            retardo_transporte = DtoH(dif_ent_d * -1)
                        End If
                    End If
                    '****************

                    DifSal = RestaHrs(FechaSalida, drHorario("sale"), FechaSalio, HoraSalio)

                    ' Si el horario es abierto, comparar entrada y salida contra las mismas, no habrá nunca dferencia de E/S
                    If _abierto Then
                        DifEnt = RestaHrs(FechaEntro, HoraEntro, FechaEntro, HoraEntro)
                        DifSal = RestaHrs(FechaSalio, HoraSalio, FechaSalio, HoraSalio)
                    End If

                    If Not FaltaEntrada And HtoD(DifEnt) * -1 > HtoD(drHorario("min_des_ent")) Then


                        Dim limite As Double = HtoD(drHorario("min_des_ent"))



                        Dim d_dif_ent As Double = HtoD(DifEnt)

                        _al_des_ent = (d_dif_ent + limite) * 3600
                        If _al_des_ent > 0 Then _al_des_ent = 0
                        _al_ant_ent = -_al_des_ent
                    End If
                    'Alerta de tiempo antes o después de entrada
                    If Not FaltaSalida And HtoD(DifSal) * -1 > HtoD(drHorario("min_ant_sal")) Then

                        _al_ant_sal = (HtoD(DifSal) - HtoD(drHorario("min_ant_sal"))) * 3600
                        If _al_ant_sal > 0 Then _al_ant_sal = 0
                        _al_des_sal = -_al_ant_sal
                    End If
                    'Alerta de tiempo extra
                    _al_horas_ex = HtoD(Extras) * 3600


                    'Mensaje de retardo
                    If _al_des_ent < 0 Then
                        dtTemp = sqlExecute("select TOP 1 hora from hrs_brt where fecha_efva = '" & FechaSQL(Fecha) & "' and reloj = '" & reloj & _
                                            "' and entrada_salida = 'E'", "TA")
                        If dtTemp.Rows.Count <> 0 Then
                            'Solo poner retardo en la primer entrada del día
                            If dtTemp.Rows(0).Item("hora") = MerMilitar(HoraEntro) Then
                                _comentario = IIf(_comentario.Length > 0, _comentario & ", ", "") & "Retardo"
                                HorasTarde = DifEnt.Substring(1)
                            End If
                        End If
                    End If

                    'Mensaje salida anticipada
                    If _al_ant_sal < 0 Then
                        dtTemp = sqlExecute("select TOP 1 hora from hrs_brt where fecha_efva = '" & FechaSQL(Fecha) & "' and reloj = '" & reloj & _
                                            "' AND entrada_salida = 'S' order by hora DESC", "TA")
                        If dtTemp.Rows.Count <> 0 Then
                            'Solo poner salida anticipada en la  última salida del día
                            If dtTemp.Rows(0).Item("hora") = MerMilitar(HoraSalio) Then
                                _comentario = IIf(_comentario.Length > 0, _comentario & ", ", "") & "Salida anticipada"
                                HorasSalidaAnticipada = DifSal
                            End If
                        End If
                    End If
                End If
                'Agregar al comentario si falta entrada o salida. Si faltan las dos, será ausentismo, y el comentario es el tipo de ausentismo
                _comentario = _comentario & IIf(FaltaEntrada And Not FaltaSalida, IIf(_comentario.Length > 0, ", ", "") & "Falta entrada", "")
                _comentario = _comentario & IIf(FaltaSalida And Not FaltaEntrada, IIf(_comentario.Length > 0, ", ", "") & "Falta salida", "")

                'Agregar al comentario si se hizo ajuste en la transacción

                If AjusteEntrada And AjusteSalida Then
                    _comentario = IIf(_comentario.Length > 0, _comentario & ", ", "") & "Doble ajuste"
                ElseIf AjusteEntrada Or AjusteSalida Then
                    _comentario = IIf(_comentario.Length > 0, _comentario & ", ", "") & "Ajuste"
                End If

                'Si hubo ajuste de entrada y salida, agregar al comentario el tipo de transacción (olvidó o perdió gafete)
                If AjusteEntrada And AjusteSalida Then
                    _comentario = TipoTran & IIf(TipoTran.Length > 0 And _comentario.Length > 0, ", ", "") & _comentario
                End If

                'Revisar si aplica filtro para considerar tiempo extra (p.ej. solo a operativos)
                If FiltroExtras.Length > 0 Then
                    'Si hay un filtro para contar horas extras, revisar
                    dtTemp = sqlExecute("SELECT reloj FROM personal WHERE reloj = '" & drEmpleado("reloj") & "' AND " & FiltroExtras)
                    If dtTemp.Rows.Count = 0 Then
                        'Si no se encontró registro cumpliendo la condición, no considerar tiempo extra
                        HrsExt = "00:00"
                    End If
                End If
                If FaltaEntrada Or FaltaSalida Then
                    HrsExt = "00:00"
                End If

                'Revisar horas extras autorizadas
                If AutorizarExtra And HtoD(HrsExt) > 0 Then
                    'Si se requiere autorización para tiempo extra

                    If RTrim(FiltroExtrasAutorizadas) <> "" Then

                        'Saber si por default las tiene autorizadas
                        Dim dtAutorizar As DataTable = sqlExecute("select * from personalvw where reloj = '" & reloj & "' and " & _
                                                                  FiltroExtrasAutorizadas)
                        Dim dtRegistroAutorizadas As DataTable = sqlExecute("select * from extras_autorizadas where reloj = '" & reloj & _
                                                                            "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                        Dim autori_a1 As Boolean = False
                        ' si ya hay un registro de autorizadas en a_1, tomar ese valor

                        If dtRegistroAutorizadas.Rows.Count > 0 Then
                            ExtrasRealesTabla = IIf(IsDBNull(dtRegistroAutorizadas.Rows(0).Item("extras_reales")), "00:00", dtRegistroAutorizadas.Rows(0).Item("extras_reales"))
                            ExtrasAutorizadas = IIf(IsDBNull(dtRegistroAutorizadas.Rows(0).Item("extras_autorizadas")), "00:00", dtRegistroAutorizadas.Rows(0).Item("extras_autorizadas")).ToString.Trim
                            'Si la tabla indica "TODO", reemplazar SIEMPRE por el tiempo extra trabajado
                            If ExtrasAutorizadas = "TODO" Then
                                ExtrasRealesTabla = HrsExt
                                ExtrasAutorizadas = HrsExt

                                'AutorizaTodo = True
                                '2018-01-27 EN QTO NUNCA AUTORIZAR TODO
                                AutorizaTodo = False
                                Autoriza30 = False
                            ElseIf ExtrasAutorizadas = "R-30" Then
                                ExtrasRealesTabla = HrsExt
                                Dim horas As Double = Math.Truncate(HtoD(HrsExt))
                                Dim minutos As Double = HtoD(HrsExt) - horas
                                If minutos >= 0 And minutos < 0.5 Then
                                    ExtrasAutorizadas = DtoH(horas)
                                Else
                                    ExtrasAutorizadas = DtoH(horas + 0.5)
                                End If

                                AutorizaTodo = False
                                Autoriza30 = True
                            End If

                            autori_a1 = IIf(IsDBNull(dtRegistroAutorizadas.Rows(0).Item("autori_a1")), False, dtRegistroAutorizadas.Rows(0).Item("autori_a1"))
                        Else
                            ExtrasRealesTabla = HrsExt
                            ExtrasAutorizadas = "00:00"
                            AutorizaTodo = False
                            Autoriza30 = False
                            autori_a1 = False
                        End If

                        If dtRegistroAutorizadas.Rows.Count <= 0 Then
                            If dtAutorizar.Rows.Count > 0 Then
                                autori_a1 = False
                            Else
                                autori_a1 = True
                            End If
                        End If

                        If dtRegistroAutorizadas.Rows.Count <= 0 Then
                            If autori_a1 = True Then
                                sqlExecute("insert into extras_autorizadas (reloj, fecha, extras_reales, extras_autorizadas, entrada, salida, autori_a1) values ('" & _
                                       reloj & "', '" & _
                                       FechaSQL(Fecha) & "', '" & _
                                       ExtrasRealesTabla & "', '" & _
                                       IIf(AutorizaTodo, "TODO", IIf(Autoriza30, "R-30", ExtrasAutorizadas)) & "', '" & _
                                       HoraEntro & "', '" & _
                                       HoraSalio & "', '" & _
                                       IIf(autori_a1, 1, 0) & "')", "TA")
                            Else
                                sqlExecute("delete from extras_autorizadas where reloj = '" & reloj & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                            End If
                        Else
                            sqlExecute("update extras_autorizadas set extras_autorizadas = '" & IIf(AutorizaTodo, "TODO", IIf(Autoriza30, "R-30", ExtrasAutorizadas)) & _
                                       "' where reloj = '" & reloj & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                        End If


                        sqlExecute("update extras_autorizadas set entrada = '" & EntradaReal & _
                                   "', salida = '" & SalidaReal & _
                                   "' where reloj = '" & reloj & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")

                        If Not autori_a1 Then
                            ExtrasAutorizadas = "00:00"
                        End If
                    Else
                        ExtrasAutorizadas = HrsExt
                    End If
                Else
                    ExtrasAutorizadas = HrsExt
                End If

                If AutorizarExtra Then
                    sqlExecute("update extras_autorizadas set extras_reales = '" & HrsExt & _
                               "' where reloj = '" & reloj & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                End If

                'MCR 2017-10-06
                'Agregar cod_hora y tipo_periodo

                If HayExcepcion Then
                    If _comentario.Trim <> "" Then
                        _comentario = " " & _comentario
                    End If
                    _comentario = "EXCEP (" & horario_excepcion & ")" & _comentario
                End If

                If HayTiempoTiempo Then
                    If _comentario.Trim <> "" Then
                        _comentario = " " & _comentario
                    End If
                    _comentario = "INTER (" & FechaTiempoTiempo & ")" & _comentario
                End If

                If retardo_transporte <> "" Then
                    If _comentario.Trim <> "" Then
                        _comentario = " " & _comentario
                    End If
                    _comentario = "TRANSPORTE (" & retardo_transporte & ")" & _comentario
                End If

                Dim ComentarioTiempoCompleto As String = ""
                Try
                    'ABRAHAM CASAS TIEMPO COMPLETO

                    Dim horas_dia_esperadas As String = drHorario("hrs_dia")
                    Dim horas_originales As String = HrsNor

                    ' Si el empleado tiene sus 2 checadas y es de tipo periodo catorcenal, se le pondra tiempo completo en caso de alguna incidencia(no ausentismo)
                    If HoraEntro <> "" And HoraSalio <> "" And _comentario <> "" And drEmpleado("tipo_periodo") = "C" Then
                        Dim dtHayTiempoCompleto_C As DataTable = sqlExecute("select * from ta.dbo.TiempoCompleto where reloj = '" & reloj & "' AND fecha = '" & FechaSQL(Fecha) & "'")
                        If Not dtHayTiempoCompleto_C.Rows.Count > 0 Then
                            sqlExecute("insert into ta.dbo.TiempoCompleto (reloj, fecha, usuario, registro) values ('" & reloj & "', '" & FechaSQL(Fecha) & "', '" & Usuario & "', getdate())")
                            HayTiempoCompleto = True
                        End If
                    End If
                    If HayTiempoCompleto Then

                        If HayLactancia Then

                            Dim _hrs_tarde As Double = HtoD(HorasTarde)
                            Dim _hrs_sal_ant As Double = HtoD(HorasSalidaAnticipada)

                            Dim _dif_ent As Double = HtoD(DifEnt)
                            Dim _dif_sal As Double = HtoD(DifSal)

                            If _hrs_tarde > 1 Then
                                HrsNor = DtoH(HtoD(HrsNor) + (_hrs_tarde - 1))
                            Else
                                HrsNor = DtoH(HtoD(HrsNor) + _hrs_tarde)
                            End If

                            If _hrs_sal_ant < -1 Then
                                HrsNor = DtoH(HtoD(HrsNor) - (_hrs_sal_ant + 1))
                            Else
                                HrsNor = DtoH(HtoD(HrsNor) - _hrs_sal_ant)
                            End If

                            _hrs_tarde = IIf(_hrs_tarde > 1, _hrs_tarde - 1, 0)
                            _hrs_sal_ant = IIf(_hrs_sal_ant < -1, _hrs_sal_ant + 1, 0)

                            _dif_ent = IIf(_dif_ent < 1, _dif_ent + 1, 0)
                            _dif_sal = IIf(_dif_sal < 1, _dif_sal + 1, 0)

                            _al_ant_ent = 0
                            _al_des_ent = IIf(_al_des_ent < 36000, _al_des_ent - 3600, 0)

                            _al_ant_sal = IIf(_al_ant_sal < 36000, _al_ant_sal - 3600, 0)
                            _al_des_sal = 0

                            HorasTarde = DtoH(_hrs_tarde)
                            DifEnt = DtoH(_dif_ent)

                            HorasSalidaAnticipada = DtoH(_hrs_sal_ant)
                            DifSal = DtoH(_dif_sal)

                        Else

                            Dim _hrs_tarde As Double = 0
                            Dim _hrs_sal_ant As Double = 0

                            Dim _dif_ent As Double = 0
                            Dim _dif_sal As Double = 0

                            _hrs_tarde = 0
                            _dif_ent = 0

                            _al_ant_ent = 0
                            _al_des_ent = 0

                            _al_ant_sal = 0
                            _al_des_sal = 0

                            HrsNor = horas_dia_esperadas

                            HorasTarde = DtoH(_hrs_tarde)
                            DifEnt = DtoH(_dif_ent)

                            HorasSalidaAnticipada = DtoH(_hrs_sal_ant)
                            DifSal = DtoH(_dif_sal)

                        End If

                    End If

                    If HayTiempoCompleto Then

                        If HayLactancia Then
                            ComentarioTiempoCompleto = "LACTANCIA (" & horas_originales & ")"
                        Else
                            ComentarioTiempoCompleto = "TIEMPO COMPLETO (" & horas_originales & ")"
                        End If

                    End If


                Catch ex As Exception

                End Try



                Cadena = "INSERT INTO asist (reloj,cod_comp,cod_planta,cod_depto,cod_puesto,cod_tipo,cod_super,cod_turno,cod_hora," & _
                    "cod_clase,gafete,periodo,ano,"
                Cadena = Cadena & "fha_ent_hor,fha_sal_hor,horario_ent,horario_sal,fecha_entro,entro,fecha_salio,salio,dia_entro,dia_salio,pareja"
                Cadena = Cadena & ",tipo_aus,ausentismo,horas,dif_ent,dif_sal,horas_normales,horas_extras,horas_tarde,horas_anticipadas,horas_convenio,"
                Cadena = Cadena & "fal_tran_ent,fal_tran_sal"
                Cadena = Cadena & ",al_ant_ent,al_des_ent,al_ant_sal,al_des_sal,al_horas_ex,fecha,hora,extras_autorizadas"
                Cadena = Cadena & ",comentario,periodo_act,usuario, cafeteria)"
                Cadena = Cadena & "VALUES ('" & reloj & "','" & drEmpleado("cod_comp") & "','" & drEmpleado("cod_planta") & "','" & drEmpleado("cod_depto") & "','"
                Cadena = Cadena & drEmpleado("cod_puesto") & "','" & drEmpleado("cod_tipo") & "','" & drEmpleado("cod_super") & "','" & drEmpleado("cod_turno") & "','" & drEmpleado("cod_hora") & "','"
                Cadena = Cadena & drEmpleado("cod_clase") & "','" & drEmpleado("gafete")
                Cadena = Cadena & "','" & Periodo & "','" & Ano & "','"
                'Fecha de entrada y salida por horario
                Cadena = Cadena & FechaSQL(Fecha) & "','" & FechaSQL(FechaSalida) & "','"
                'Hora de entrada y salida por horario
                Cadena = Cadena & drHorario("entra") & "','" & drHorario("sale") & "','"
                'Hora en que entró y salió
                Cadena = Cadena & FechaSQL(FechaEntro) & "','" & HoraEntro & "','"
                Cadena = Cadena & FechaSQL(FechaSalio) & "','" & HoraSalio & "','"
                'Día de la semana que entró y salió
                Cadena = Cadena & DiaSem(FechaEntro) & "','" & DiaSem(FechaSalio) & "',"
                'Si tiene pareja
                Cadena = Cadena & IIf(_pareja, 1, 0) & ","
                'Ausentismo, en caso de haber
                If _tipo_aus.Length > 0 Then
                    DifEnt = ""
                    DifSal = ""
                    Cadena = Cadena & "'" & _tipo_aus & "',1"
                    'Buscar el nombre del ausentismo, 
                    dtTemp = sqlExecute("SELECT nombre,ISNULL(porcentaje,0) AS porcentaje,acumula_horas_convenio FROM tipo_ausentismo where tipo_aus = '" & _tipo_aus & "'", "TA")
                    If dtTemp.Rows.Count > 0 Then

                        _comentario = IIf(_comentario.Length > 0, _comentario & ", ", "") & dtTemp.Rows(0).Item("nombre")
                        'If dtTemp.Rows(0).Item("porcentaje") > 0 Then Stop

                        If dtTemp.Rows(0).Item("porcentaje") > 0 Then
                            'MCR 8/OCT/2015
                            'Si el porcentaje > 0, es ausentismo con goce de sueldo
                            If (HrsNor = "00:00" Or HrsNor < drHorario("hrs_dia")) Then
                                If x <= 1 And Not EsDescanso And Not EsFestivo Then
                                    HrsNor = drHorario("hrs_dia")
                                Else
                                    HrsNor = "00:00"
                                End If
                            End If

                            If IIf(IsDBNull(dtTemp.Rows(0).Item("acumula_horas_convenio")), 0, dtTemp.Rows(0).Item("acumula_horas_convenio")) Then
                                HorasConvenio = DtoH(HtoD(HrsNor) * (100 - dtTemp.Rows(0).Item("porcentaje")) / 100)
                                HrsNor = DtoH(HtoD(HrsNor) * dtTemp.Rows(0).Item("porcentaje") / 100)
                            Else
                                HorasConvenio = "00:00"
                                HrsNor = DtoH(HtoD(HrsNor) * dtTemp.Rows(0).Item("porcentaje") / 100)
                            End If
                        ElseIf Hrs = "00:00" Then
                            'MCR 8/OCT/2015
                            'Si es ausentismo sin goce de sueldo, pero no tiene horas,
                            'todo regresa a 0 (asumiendo que se hayan asignado las horas x día)
                            HrsNor = "00:00"
                            HrsExt = "00:00"
                        End If
                    End If
                    If VacacionesTrabajadas Or DescansoTrabajado Or FestivoTrabajado Then
                        _comentario = _comentario & " trab."
                    End If
                Else
                    Cadena = Cadena & "NULL,0"
                End If
                _comentario = _comentario.ToUpper

                'Horas trabajadas
                Cadena = Cadena & ",'" & IIf(FaltaEntrada Or FaltaSalida, "00:00", RestaHrs(FechaEntro, HoraEntro, FechaSalio, HoraSalio)) & "','"
                'Diferencia de tiempo respecto a entrada y salida
                Cadena = Cadena & DifEnt & "','" & DifSal & "','"
                'Horas normales
                Cadena = Cadena & HrsNor & "','"
                'Horas extras
                Cadena = Cadena & HrsExt & "','"
                'Horas tarde
                Cadena = Cadena & HorasTarde & "','"
                'Horas salida anticipada
                Cadena = Cadena & HorasSalidaAnticipada & "','"
                'Horas por convenio
                Cadena = Cadena & HorasConvenio & "',"
                'Faltaba transacción de entrada y/o salida, y se hizo ajuste (desde hrs_brt)
                Cadena = Cadena & IIf(AjusteEntrada, 1, 0) & ","
                Cadena = Cadena & IIf(AjusteSalida, 1, 0) & ","
                'Alerta antes y después de la entrada y salida 
                Cadena = Cadena & _al_ant_ent & ","
                Cadena = Cadena & _al_des_ent & ","
                Cadena = Cadena & _al_ant_sal & ","
                Cadena = Cadena & _al_des_sal & ","
                'Alerta de tiempo extra
                Cadena = Cadena & _al_horas_ex & ",'"
                'Fecha y hora actuales
                Cadena = Cadena & FechaSQL(Now.Date) & "','"
                Cadena = Cadena & Now.Hour.ToString.PadLeft(2, "0") & ":" & Now.Minute.ToString.PadLeft(2, "0") & ":" & Now.Second.ToString.PadLeft(2, "0") & "','"
                'Extras autorizadas (si las trabajadas son menores, usar las extras trabajadas)
                Cadena = Cadena & IIf(HrsExt < ExtrasAutorizadas, HrsExt, ExtrasAutorizadas) & "','"
                'Comentario

                If HayTiempoCompleto Then
                    If _tipo_aus.Length <= 0 Then
                        _comentario = ComentarioTiempoCompleto
                    End If
                End If

                Cadena = Cadena & Mid(_comentario, 1, 100) & "','"
                'periodo_act y usuario
                Cadena = Cadena & Ano & Periodo & "A" & "','" & Usuario & "', '" & IIf(Cafeteria <= 0, "00:00", DtoH(Cafeteria)) & "')"

                'Ejecutar cadena
                'MCR 2017-10-04
                'Si se analizó previamente el día por falta de una salida, no insertar
                dtTemp = sqlExecute("SELECT reloj FROM asist where COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & reloj & _
                                  "' AND fha_ent_hor = '" & FechaSQL(FechaEntro) & "' AND entro = '" & HoraEntro & "'", "TA")
                If dtTemp.Rows.Count > 0 Then
                    Continue For
                End If
                dtTemp = sqlExecute(Cadena, "TA")
                '***** 2017-10-04


                If AutorizarExtra And HtoD(HrsExt) > 0 Then
                    'Si hay horas extras autorizadas, registrar en la tabla que ya se analizaron
                    sqlExecute("UPDATE extras_autorizadas SET analizado = 1,extras_reales = '" & HrsExt & _
                               "' WHERE reloj = '" & reloj & "' AND fecha = '" & FechaSQL(Fecha) & "'", "TA")
                End If
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "TA", ex.HResult, ex.Message)

        End Try
    End Sub
    Public Sub AnalisisHrsBrt(ByVal drEmpleado As DataRow, Fecha As Date, Periodo As String, Ano As String)

        Dim reloj As String = ""
        reloj = drEmpleado("reloj")

        Dim HoraInicial As DateTime = Now

        '*************** Análisis de entradas/salidas en hrs_brt ******************
        Dim dtBrt As New DataTable
        Dim dtBrtSalida As New DataTable
        Dim dtBrtEntrada As New DataTable

        'MCR 2017-09-25
        'Revisar si el siguiente movimiento está más cercano a la salida, antes de asignarla
        Dim DifEntSiguiente As Double = 0
        Dim DifSalSiguiente As Double = 0
        Dim drSiguiente() As DataRow

        Dim fIni As Date
        Dim fFin As Date

        Dim DifEnt As Double
        Dim DifSal As Double

        Dim UltimaTran As String = ""
        Dim FechaEntro As String = ""
        Dim FechaSalio As String = ""
        Dim HoraEntro As String = ""
        Dim HoraSalio As String = ""
        Dim drHoras As DataRow

        Dim HayExcepcion As Boolean
        Dim horario_excepcion As String = ""

        Try
            Reloj = drEmpleado("reloj")

            'Definir si la hora de entrada es cercana a las 0hrs
            '*** ATENCION: AL CAPTURAR TABLA DIAS, TENER CUIDADO EN EL RANGO_HRS, PARA QUE ALCANCE LA ENTRADA Y EL TIEMPO EXTRA ESTIMADO... ****


            Dim dtHayExcepcion As DataTable = sqlExecute("select * from excepciones_horarios where reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(Fecha) & "'")
            If dtHayExcepcion.Rows.Count > 0 Then
                HayExcepcion = True
                horario_excepcion = dtHayExcepcion.Rows(0)("cod_hora")
                Dim dtInfoHorarioExcepcion As DataTable = sqlExecute("select * from excepciones_dias where cod_hora = '" & horario_excepcion & "'")
                Dim drow_ex As DataRow = dtInfoHorarioExcepcion.Rows(0)
                drHorario("entra") = drow_ex("entrada")
                drHorario("sale") = drow_ex("salida")
                drHorario("rango_hrs") = drow_ex("rango_hrs")

                Dim sal_sig_dia As Integer = drow_ex("sal_sig_dia")
                If sal_sig_dia = 1 Then
                    Dim dia_sem As Integer = drHorario("cod_dia")
                    If dia_sem = 7 Then
                        drHorario("cod_dia_sal") = 1
                    Else
                        drHorario("cod_dia_sal") = dia_sem + 1
                    End If
                Else
                    drHorario("cod_dia_sal") = drHorario("cod_dia")
                End If
            End If

            Dim rango_horas As Double = 3.0
            rango_horas = HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs")))

            'If HtoD(MerMilitar(drHorario("entra"))) < 2 Then
            '    'Si la hora de entrada es menor a las 2:00 AM
            '    fIni = DateAdd(DateInterval.Minute, HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))) * 60, Fecha)
            '    'Determinar la hora en que termina el día, de acuerdo al rango de horas definido
            '    fFin = DateAdd(DateInterval.Minute, (-HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))) + 24) * 60, Fecha)
            'Else
            'Determinar la hora en que inicia el día, de acuerdo al rango de horas definido

            'MCR 2017-09-28
            'Cuando los horarios son cercanos a media noche, modificar el rango de horas en el horario, para utilizar negativos
            fIni = DateAdd(DateInterval.Minute, HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))) * 60, Fecha)
            fIni = DateAdd(DateInterval.Second, -1, fIni)

            'Determinar la hora en que terminia el día, de acuerdo al rango de horas definido
            fFin = DateAdd(DateInterval.Minute, (HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))) + 24) * 60, Fecha)
            'End If


            'Abraham Casas 201609015
            DepuracionHrsBRT(drEmpleado("reloj"), Fecha, rango_horas)

            If _pri_ent_ult_sal Then
                'Si se consideran solamente las primeras entradas y últimas salidas
                'Marcar todos como NULL en el campo entrada_salida, por si ya se habían evaluado anteriormente, quitar el valor predefinido
                Dim i As Integer = 0

                If AnalizarES Then
                    sqlExecute("UPDATE hrs_brt SET entrada_salida = NULL " & _
                               "WHERE reloj = '" & Reloj & "' AND  RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & FechaHoraSQL(fIni) & "' AND '" & _
                               FechaHoraSQL(fFin) & "'", "TA")
                End If

                'Tomar los primeros 2 registros del día (el primero se evalúa por si es salida del día anterior)
                dtBrtEntrada = sqlExecute("SELECT TOP 2 fecha,hora, RTRIM(CAST(fecha as CHAR))+' ' + hora AS FechaCompleta FROM hrs_brt " & _
                                          "WHERE RELOJ = '" & Reloj & "' AND  RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & FechaHoraSQL(fIni) & "' AND '" & _
                                            FechaHoraSQL(fFin) & "' ORDER BY fecha ASC,hora ASC", "TA")
                'y  el último registro del rango de fechas, buscando entrada y salida
                dtBrtSalida = sqlExecute("SELECT TOP 1 fecha,hora, RTRIM(CAST(fecha as CHAR))+' ' + hora AS FechaCompleta FROM hrs_brt " & _
                                         "WHERE RELOJ = '" & Reloj & "' AND  RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & FechaHoraSQL(fIni) & "' AND '" & _
                                            FechaHoraSQL(fFin) & "' ORDER BY fecha DESC,hora DESC", "TA")

                If dtBrtEntrada.Rows.Count = 2 Then
                    'Si hay al menos 2 registros en la tabla, checar el primero, a ver si no corresponde a salida del día anterior
                    DifEnt = HtoD(RestaHrs(dtBrtEntrada.Rows(i).Item("hora"), drHorario("entra")))

                    If DifEnt > 1 Then
                        'Si la diferencia es mayor a una hora antes de su entrada, revisar si al día anterior le falta una salida
                        dtTemp = sqlExecute("SELECT TOP 1 * FROM hrs_brt WHERE reloj = '" & Reloj & "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora >= '" & _
                                            FechaHoraSQL(fIni) & "' ORDER BY RTRIM(CAST(fecha as CHAR))+' ' + hora", "TA")
                        If dtTemp.Rows.Count = 0 Then
                            UltimaTran = "S"
                        Else
                            UltimaTran = IIf(IsDBNull(dtTemp.Rows(0).Item("entrada_salida")), "S", dtTemp.Rows(0).Item("entrada_salida"))
                        End If

                        If UltimaTran <> "S" Then
                            'Si la última transacción no fue una salida, pasar este registro como salida del día anterior
                            sqlExecute("UPDATE hrs_brt SET PREUS = 1 " & _
                                       IIf(AnalizarES, ", entrada_salida = 'S'", "") & _
                                       ", ano = '" & Ano & _
                                       "', periodo = '" & Periodo & _
                                       "', fecha_efva = '" & FechaSQL(DateAdd(DateInterval.Day, -1, Fecha)) & _
                                       "' WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(dtTemp.Rows(0).Item("fecha")) & _
                                       "' AND hora = '" & dtTemp.Rows(0).Item("hora") & "'", "TA")
                            UltimaTran = "X"
                            'Si este registro es del día anterior, deberemos tomar el siguiente registro como entrada de este día
                            i = 1
                        End If
                    End If
                End If

                If dtBrtEntrada.Rows.Count > 0 Then
                    'Si hay resultado para entrada, hay checadas de ese día

                    If dtBrtEntrada.Rows(i).Item("fecha") + dtBrtEntrada.Rows(i).Item("hora") <> dtBrtSalida.Rows(i).Item("fecha") + dtBrtSalida.Rows(i).Item("hora") Then
                        'Si la información máxima y mínima son diferentes, entonces es realmente una entrada y una salida

                        sqlExecute("UPDATE hrs_brt SET PREUS = 1 " & IIf(AnalizarES, ", entrada_salida = 'E'", "") & ", ano = '" & Ano & "', periodo = '" & Periodo & _
                                   "', fecha_efva = '" & FechaSQL(Fecha) & "' WHERE reloj = '" & Reloj & _
                                   "' AND fecha = '" & FechaSQL(dtBrtEntrada.Rows(i).Item("fecha")) & "' AND hora = '" & dtBrtEntrada.Rows(i).Item("hora") & "'", "TA")
                        sqlExecute("UPDATE hrs_brt SET PREUS = 1 " & IIf(AnalizarES, ", entrada_salida = 'S'", "") & ", ano = '" & Ano & "', periodo = '" & Periodo & _
                                       "', fecha_efva = '" & FechaSQL(Fecha) & "' WHERE reloj = '" & Reloj & _
                                   "' AND fecha = '" & FechaSQL(dtBrtSalida.Rows(0).Item("fecha")) & "' AND hora = '" & dtBrtSalida.Rows(0).Item("hora") & "'", "TA")
                    Else
                        'Si son iguales, solo hay un registro, y se debe determinar si es entrada o salida

                        DifEnt = HtoD(RestaHrs(drHorario("entra"), dtBrtEntrada.Rows(i).Item("hora")))
                        DifSal = HtoD(RestaHrs(drHorario("sale"), dtBrtEntrada.Rows(i).Item("hora")))

                        If Math.Abs(DifEnt) < Math.Abs(DifSal) Or DifEnt > 23 Then
                            'Es una entrada
                            sqlExecute("UPDATE hrs_brt SET PREUS =  1" & IIf(AnalizarES, ", entrada_salida = 'E'", "") & ", fecha_efva = '" & FechaSQL(Fecha) & _
                                       "' WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(dtBrtEntrada.Rows(i).Item("fecha")) & _
                                            "' AND hora = '" & dtBrtEntrada.Rows(i).Item("hora") & "'", "TA")
                        Else
                            'Es una salida
                            sqlExecute("UPDATE hrs_brt SET PREUS = 1 " & IIf(AnalizarES, ", entrada_salida = 'S'", "") & ", fecha_efva = '" & FechaSQL(Fecha) & _
                                       "' WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(dtBrtSalida.Rows(0).Item("fecha")) & _
                                            "' AND hora = '" & dtBrtSalida.Rows(0).Item("hora") & "'", "TA")
                        End If
                    End If
                End If
            Else
                'Si no es PREUS
                dtBrt = sqlExecute("SELECT fecha,hora,preus,entrada_salida,fecha_efva FROM hrs_brt WHERE reloj = '" & Reloj & _
                                   "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & _
                                   FechaHoraSQL(fIni) & "' AND '" & FechaHoraSQL(fFin) & _
                                   "' AND fecha_efva IS NULL ORDER BY fecha,hora", "TA")




                For Each drHoras In dtBrt.Rows

                    'MCR 2017-09-25
                    'Revisión siguiente movimiento más cercano
                    drSiguiente = dtBrt.Select("hora>'" + drHoras("hora") + "'")
                    If drSiguiente.Count > 0 Then
                        DifEntSiguiente = HtoD(RestaHrs(drHorario("entra"), drSiguiente(0)("hora")))
                        DifSalSiguiente = HtoD(RestaHrs(drHorario("sale"), drSiguiente(0)("hora")))
                    Else
                        DifEntSiguiente = 24
                        DifSalSiguiente = 24
                    End If
                    '**********MCR

                    If UltimaTran = "" Then

                        'Si es el primer movimiento, revisar si está más cerca de la entrada o de la salida

                        DifEnt = HtoD(RestaHrs(drHorario("entra"), drHoras("hora")))
                        DifSal = HtoD(RestaHrs(drHoras("hora"), drHorario("sale")))

                        If DifEnt < -1 Then
                            'Si la diferencia es mayor a una hora antes de su entrada, revisar si al día anterior le falta una salida
                            dtTemporal = sqlExecute("SELECT TOP 1 * FROM hrs_brt WHERE reloj = '" & Reloj & _
                                                "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora < '" & FechaHoraSQL(fIni) & _
                                                "' ORDER BY RTRIM(CAST(fecha as CHAR))+' ' + hora DESC", "TA")
                            If dtTemporal.Rows.Count = 0 Then
                                UltimaTran = "S"
                            Else
                                If IsDBNull(dtTemporal.Rows(0).Item("fecha_efva")) Then
                                    UltimaTran = "S"
                                ElseIf DateDiff(DateInterval.Day, dtTemporal.Rows(0).Item("fecha_efva"), Fecha) > 1 Then
                                    UltimaTran = "S"
                                Else
                                    UltimaTran = IIf(IsDBNull(dtTemporal.Rows(0).Item("entrada_salida")), "S", dtTemporal.Rows(0).Item("entrada_salida"))
                                End If
                            End If

                            'If UltimaTran <> "S" Then
                            'Si la última transacción no fue una salida, pasar este registro como salida del día anterior

                            'MCR '2017-09-25
                            'A menos que el horario esté a 2 horas de la salida
                            If UltimaTran <> "S" And Math.Abs(DifSal) > 2 Then

                                sqlExecute("UPDATE hrs_brt SET " & IIf(AnalizarES, " entrada_salida = 'S',", "") & " ano = '" & Ano & "', periodo = '" & Periodo & _
                                       "', fecha_efva = '" & FechaSQL(DateAdd(DateInterval.Day, -1, Fecha)) & _
                                           "' WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(drHoras("fecha")) & _
                                           "' AND hora = '" & drHoras("hora") & "'", "TA")
                                sqlExecute("DELETE FROM asist WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & Reloj & _
                                  "' AND fha_ent_hor ='" & FechaSQL(DateAdd(DateInterval.Day, -1, Fecha)) & "'", "TA")
                                Evaluador(drEmpleado, DateAdd(DateInterval.Day, -1, Fecha), Periodo, Ano)
                                UltimaTran = "X"
                            Else
                                DifSal = HtoD(RestaHrs(drHoras("hora"), drHorario("sale")))
                                If Math.Abs(DifEnt) < Math.Abs(DifSal) Or DifEnt > 23 Then
                                    'Si el movimiento está más cerca de la entrada, marcar última transacción como salida, para que tome el movimiento como entrada
                                    'Si la diferencia con la entrada es >23, es hora cercana a la media noche
                                    UltimaTran = "S"
                                Else
                                    UltimaTran = "E"
                                End If
                            End If
                        Else
                            DifSal = HtoD(RestaHrs(drHoras("hora"), drHorario("sale")))

                            'MCR 2017-09-25
                            'Revisión siguiente movimiento más cercano
                            'If Math.Abs(DifEnt) < Math.Abs(DifSal) Then

                            If Math.Abs(DifEnt) < Math.Abs(DifSal) Or Math.Abs(DifEnt) > Math.Abs(DifSalSiguiente) Then
                                'Si el movimiento está más cerca de la entrada, marcar última transacción como salida, para que tome el movimiento como entrada
                                UltimaTran = "S"
                            Else
                                UltimaTran = "E"
                            End If
                        End If
                    End If


                    If UltimaTran = "E" Then
                        'Si la última transacción fue una entrada, esta es una salida
                        sqlExecute("UPDATE hrs_brt SET " & IIf(AnalizarES, "entrada_salida = 'S',", "") & " ano = '" & Ano & "', periodo = '" & Periodo & _
                                       "',fecha_efva = '" & FechaSQL(Fecha) & _
                                   "' WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(drHoras("fecha")) & _
                                   "' AND hora = '" & drHoras("hora") & "'", "TA")

                        UltimaTran = "S"
                    ElseIf UltimaTran <> "X" Then
                        'Si la última transacción fue una salida, o no ha habido movimiento, esta es una entrada
                        sqlExecute("UPDATE hrs_brt SET " & IIf(AnalizarES, " entrada_salida = 'E', ", "") & "  ano = '" & Ano & "', periodo = '" & Periodo & _
                                       "',fecha_efva = '" & FechaSQL(Fecha) & _
                                   "' WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(drHoras("fecha")) & _
                                   "' AND hora = '" & drHoras("hora") & "'", "TA")

                        UltimaTran = "E"
                    ElseIf UltimaTran = "X" Then
                        UltimaTran = ""
                    End If
                Next

                If dtBrt.Rows.Count Mod 2 <> 0 And dtBrt.Rows.Count > 1 And UltimaTran <> "S" Then
                    drHoras = dtBrt.Rows(dtBrt.Rows.Count - 1)
                    DifEnt = HtoD(RestaHrs(drHorario("entra"), drHoras("hora")))
                    DifSal = HtoD(RestaHrs(drHoras("hora"), drHorario("sale")))
                    If DifEnt > DifSal Then
                        'Si hay menos diferencia con la salida, es salida
                        sqlExecute("UPDATE hrs_brt SET " & IIf(AnalizarES, " entrada_salida = 'S',", "") & "  ano = '" & Ano & "', periodo = '" & Periodo & _
                                       "',fecha_efva = '" & FechaSQL(Fecha) & _
                                    "' WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(drHoras("fecha")) & _
                                    "' AND hora = '" & drHoras("hora") & "'", "TA")
                    End If

                End If
            End If 'PREUS

        Catch ex As Exception
            ErrorLog(usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "TA", ex.HResult, ex.Message)
        End Try

    End Sub

    Public Sub AnalisisHrsBrtPares(ByVal drEmpleado As DataRow, ByVal Ano As String, ByVal Periodo As String, ByVal FIni As Date, ByVal FFin As Date, Optional ByVal RangoMax As Double = 0)
        Dim R As String
        Dim Rango As Double
        Dim dtHorario As New DataTable
        Dim Fecha As Date
        Dim Tipo As String
        Dim drHorarioTemp As DataRow

        Dim reloj As String = ""
        reloj = drEmpleado("reloj")

        Try
            R = drEmpleado("reloj").ToString.Trim
            'MCR 2017-10-04
            'Incluir número de semana en queries

            If DateDiff(DateInterval.Day, FIni, FFin) > 0 Then
                'MCR 2017-09-26
                'No considerar los días de descanso al tomar el máximo

                dtHorario = sqlExecute("SELECT MAX(rango_hrs) AS rango_hrs FROM dias LEFT JOIN personal " & _
                                           "ON dias.cod_comp = personal.cod_comp AND dias.cod_hora = '" & Semana.cod_hora & "' " & _
                                           " WHERE reloj = '" & R & "' AND semana = " & Semana.NumSemana & " AND (DESCANSO =0 OR DESCANSO IS NULL)")
                Rango = HtoD(IIf(IsDBNull(dtHorario.Rows(0).Item("rango_hrs")), "03:00", dtHorario.Rows(0).Item("rango_hrs")))
            Else
                dtHorario = sqlExecute("SELECT rango_hrs FROM dias LEFT JOIN personal " & _
                                         "ON dias.cod_comp = personal.cod_comp AND dias.cod_hora = '" & Semana.cod_hora & "' " & _
                                         " WHERE reloj = '" & R & "' and dia_ent = '" & DiaSem(FIni) & "' AND semana = " & _
                                         Semana.NumSemana & " order by TA.DBO.HORA12A24(ENTRA)")
                Rango = HtoD(IIf(IsDBNull(dtHorario.Rows(0).Item("rango_hrs")), "03:00", dtHorario.Rows(0).Item("rango_hrs")))
            End If


            FIni = DateAdd(DateInterval.Hour, Rango, FIni)
            'Determinar la hora en que termina el día, de acuerdo al rango de horas definido

            'Si hay más de un rango, tomar el siguiente para el final
            If dtHorario.Rows.Count > 1 Then
                Rango = HtoD(IIf(IsDBNull(dtHorario.Rows(dtHorario.Rows.Count - 1).Item("rango_hrs")), Rango, dtHorario.Rows(dtHorario.Rows.Count - 1).Item("rango_hrs")))
            End If

            'MCR  2017-09-28
            'Si se recibe rango máximo definido
            If RangoMax > 0 Then
                FFin = DateAdd(DateInterval.Hour, RangoMax + 24, FFin)
            Else
                FFin = DateAdd(DateInterval.Hour, Rango + 24, FFin)
            End If

            'dtHrsBrt = sqlExecute("SELECT reloj,fecha,hora FROM hrs_brt WHERE RELOJ ='" & R & "' AND fecha BETWEEN '" & FechaSQL(FIni) & "' AND '" & FechaSQL(FFin) & "'", "TA")

            dtHrsBrt = sqlExecute("SELECT reloj,fecha,hora,fecha_efva,entrada_salida FROM hrs_brt WHERE RELOJ ='" & R & "' AND CONVERT(char(11),fecha,23)+ hora >=  '" & _
                                  FechaHoraSQL(FIni, False, False) & "' AND CONVERT(char(11),fecha,23)+ hora <= '" & FechaHoraSQL(FFin, False, False) & "' order by (cast(fecha as datetime)+cast(hora as datetime))", "TA")



            'Revisar es el primer movimiento, por si es una salida del día anterior, que no esté registrada

            Dim DifEnt As Decimal
            Dim DifSal As Decimal
            Dim DifSalSiguiente As Decimal

            Dim Inserta As Boolean = True
            Tipo = ""
            For Each dHrs As DataRow In dtHrsBrt.Rows
                Inserta = True

                DifEnt = HtoD(RestaHrs(drHorario("entra"), dHrs("hora")))
                If Tipo = "" Then
                    'My.Application.DoEvents()


                    'MCR 2017-09-28
                    'Como caso especial en BRP, si el sábado solo tiene un registro (falta entrada/salida), revisar si también al viernes
                    'en caso de que a ambos días les falte salida, asumir que la entrada del sábado es la salida del viernes (por tiempo extra)
                    If FIni.DayOfWeek = DayOfWeek.Saturday And dtHrsBrt.Rows.Count = 1 Then
                        'Revisar si no está más cerca de una salida (en sábado)
                        DifEnt = HtoD(RestaHrs(drHorario("sale"), dHrs("hora")))
                    End If

                    If DifEnt < -1 Then
                        'Si la diferencia es mayor a una hora antes de su entrada, revisar si al día anterior le falta una salida
                        dtTemporal = sqlExecute("SELECT TOP 1 * FROM hrs_brt WHERE reloj = '" & Reloj & _
                                            "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora < '" & FechaHoraSQL(FIni) & _
                                            "' ORDER BY RTRIM(CAST(fecha as CHAR))+' ' + hora DESC", "TA")
                        If dtTemporal.Rows.Count = 0 Then
                            Tipo = "S"
                        Else
                            If IsDBNull(dtTemporal.Rows(0).Item("fecha_efva")) Then
                                Tipo = "S"
                            ElseIf DateDiff(DateInterval.Day, dtTemporal.Rows(0).Item("fecha_efva"), Fecha) > 1 Then
                                Tipo = "S"
                            Else
                                Tipo = IIf(IsDBNull(dtTemporal.Rows(0).Item("entrada_salida")), "S", dtTemporal.Rows(0).Item("entrada_salida"))
                            End If
                        End If

                        'Si la última transacción no fue una salida, pasar este registro como salida del día anterior

                        If Tipo <> "S" Then
                            Fecha = dHrs("fecha")
                            sqlExecute("UPDATE hrs_brt SET " & IIf(AnalizarES, " entrada_salida = 'S',", "") & " ano = '" & Ano & "', periodo = '" & Periodo & _
                                   "', fecha_efva = '" & FechaSQL(DateAdd(DateInterval.Day, -1, Fecha)) & _
                                       "' WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(dHrs("fecha")) & _
                                       "' AND hora = '" & dHrs("hora") & "'", "TA")
                            sqlExecute("DELETE FROM asist WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & Reloj & _
                                  "' AND fha_ent_hor ='" & FechaSQL(DateAdd(DateInterval.Day, -1, Fecha)) & "'", "TA")


                            'MCR 2017-09-28
                            'Si se va a evaluar otro día, es necesario tomar el horario para ese día
                            'Guardando primero el horario definido, para no perderlo, y continuar evaluando los demás registros
                            drHorarioTemp = drHorario
                            dtHorario = sqlExecute("SELECT horarios.*,dias.*,TA.DBO.HORA12A24(ENTRA) AS ENTRADA24 FROM " & _
                                                   " personal.dbo.horarios " & _
                                                   " LEFT JOIN personal.dbo.dias ON horarios.cod_hora = dias.cod_hora " & _
                                                   " AND horarios.cod_comp = dias.cod_comp WHERE horarios.cod_hora = '" & Semana.cod_hora & _
                                                   "' and dias.cod_dia = " & _
                                                   Weekday(DateAdd(DateInterval.Day, -1, Fecha), IIf(IniciaLunes, FirstDayOfWeek.Monday, FirstDayOfWeek.Sunday)) & _
                                                    " AND semana = " & Semana.NumSemana & " ORDER BY TA.DBO.HORA12A24(ENTRA)")

                            If dtHorario.Rows.Count > 0 Then
                                drHorario = dtHorario.Rows(0)
                                drHorarios = dtHorario.Select("cod_dia = " & IIf(DiaSemana = 0, DiaSemana = 6, DiaSemana - 1), "entrada24")
                            Else
                                Debug.Print("No hay información de horarios para empleado " & Reloj)
                                Exit Sub
                            End If
                            '******** 2017-09-28

                            Evaluador(drEmpleado, DateAdd(DateInterval.Day, -1, Fecha), Periodo, Ano)
                            Tipo = "X"
                            Inserta = False

                            'MCR 2017-09-28
                            'Después, regresar al horario que estábamos analizando, para continuar si hay más checadas de esa fecha
                            drHorario = drHorarioTemp
                            '******** 2017-09-28
                        Else
                            DifSal = HtoD(RestaHrs(dHrs("hora"), drHorario("sale")))
                            If Math.Abs(DifEnt) < Math.Abs(DifSal) Or DifEnt > 23 Then
                                'Si el movimiento está más cerca de la entrada, marcar última transacción como salida, para que tome el movimiento como entrada
                                'Si la diferencia con la entrada es >23, es hora cercana a la media noche
                                Tipo = "S"
                            Else
                                Tipo = "E"
                            End If
                        End If
                    Else
                        DifSal = HtoD(RestaHrs(dHrs("hora"), drHorario("sale")))

                        'MCR 2017-09-25
                        'Revisión siguiente movimiento más cercano
                        'If Math.Abs(DifEnt) < Math.Abs(DifSal) Then

                        If Math.Abs(DifEnt) < Math.Abs(DifSal) Or Math.Abs(DifEnt) > Math.Abs(DifSalSiguiente) Then
                            'Si el movimiento está más cerca de la entrada, marcar última transacción como salida, para que tome el movimiento como entrada
                            Tipo = "S"
                        Else
                            Tipo = "E"
                        End If
                    End If
                End If


                If Tipo = "S" Then
                    Fecha = dHrs("fecha")
                    'MCR 15/OCT/2015
                    'En descanso, se forzan pares, pero puede haber una salida del día anterior que se confunda
                    'ya que no se hace de toda la semana
                    'Si hay una salida con fecha_efva del día anterior, ignorarla
                    If Not IsDBNull(dHrs("fecha_efva")) And Not IsDBNull(dHrs("entrada_salida")) Then
                        If dHrs("fecha_efva") = DateAdd(DateInterval.Day, -1, Fecha) And dHrs("entrada_salida") = "S" Then
                            Inserta = False
                        End If
                    End If
                End If

                If Inserta Then
                    Tipo = IIf(Tipo = "E", "S", "E")
                    sqlExecute("UPDATE hrs_brt SET fecha_efva = '" & FechaSQL(Fecha) & "'" & IIf(AnalizarES, ",entrada_salida = '" & Tipo & "'", "") & _
                               " WHERE RELOJ ='" & R & _
                               "' AND fecha = '" & FechaSQL(dHrs("fecha")) & "' AND hora = '" & dHrs("hora") & "'", "TA")
                End If
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "TA", ex.HResult, ex.Message)
        End Try

    End Sub

    Public Function AsistenciaPerfecta(drEmpleado As DataRow, Fecha As Date, Periodo As String, Preus As Byte) As Boolean
        Try
            Dim Entrada As String = ""
            Dim Salida As String = ""
            Dim FechaEntrada As Date
            Dim FechaSalida As Date
            Dim Dif As Integer
            Dim Descanso As Boolean
            Dim EsFestivo As Boolean
            Dim fAlta As Date
            Dim fBaja As Date
            Dim fFin As Date
            Dim fIni As Date
            Dim R As String
            Dim Gafete As String
            Dim Comp As String
            Dim Tipo As String
            Dim Horario As String
            Dim Turno As String

            R = drEmpleado("reloj")

            Gafete = IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("reloj"), drEmpleado("gafete"))
            Comp = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp"))
            Tipo = IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo"))
            Horario = IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora"))
            Turno = IIf(IsDBNull(drEmpleado("cod_turno")), "", drEmpleado("cod_turno"))

            fAlta = drEmpleado("alta")
            'Si la fecha de baja está en blanco, poner una fecha del 2100 para que siempre sea posterior a la fecha en que se procesa
            fBaja = IIf(IsDBNull(drEmpleado("baja")), DateSerial(2100, 1, 1), drEmpleado("baja"))

            FechaEntrada = Fecha
            Descanso = DiaDescanso(FechaEntrada, drEmpleado("reloj"))
            EsFestivo = Festivo(FechaEntrada, drEmpleado("reloj"))

            Entrada = drHorario("entra")
            Salida = drHorario("sale")
            Dif = IIf(drHorario("dia_ent") <> drHorario("dia_sal"), 1, 0)
            FechaSalida = DateAdd(DateInterval.Day, Dif, Fecha)


            If HtoD(MerMilitar(Entrada)) < 2 Then
                'Si la hora de entrada es menor a las 2:00 AM
                fIni = DateAdd(DateInterval.Hour, -HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))), Fecha)
                'Determinar la hora en que termina el día, de acuerdo al rango de horas definido
                fFin = DateAdd(DateInterval.Hour, -HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))) + 24, Fecha)
            Else
                'Determinar la hora en que inicia el día, de acuerdo al rango de horas definido
                fIni = DateAdd(DateInterval.Hour, HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))), Fecha)
                'Determinar la hora en que termina el día, de acuerdo al rango de horas definido
                fFin = DateAdd(DateInterval.Hour, HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))) + 24, Fecha)
            End If

            'Obtener la información de hrs_brt, para guardar en bitácora
            dtHrsBrtTEMP = sqlExecute("SELECT fecha,hora,entrada_salida FROM hrs_brt  WHERE reloj = '" & R & "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & FechaHoraSQL(fIni) & "' AND '" & FechaHoraSQL(fFin) & "'", "TA")
            sqlExecute("DELETE FROM hrs_brt WHERE reloj = '" & R & "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & FechaHoraSQL(fIni) & "' AND '" & FechaHoraSQL(fFin) & "'", "TA")

            If Not Descanso And FechaEntrada >= fAlta And FechaEntrada <= fBaja Then

                dtTemp = sqlExecute("SELECT tipo_aus FROM ausentismo WHERE reloj = '" & R & _
                                    "' AND (fecha = '" & FechaSQL(FechaEntrada) & "') AND NOT tipo_aus IN ('" & _aus_natural & "')", "TA")
                Dim Inserta As Boolean = False
                Dim ES As String = "S"
                If dtTemp.Rows.Count > 0 Then
                    If (TipoNaturaleza(dtTemp.Rows(0).Item("tipo_aus")) = "A" Or dtTemp.Rows(0).Item("tipo_aus") = "") And Not EsFestivo Then


                        'MCR 15/OCT/2015
                        'Insertar en bitácora borrado de ausentismo
                        sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                      "(reloj,fecha,tipo_aus,fecha_movimiento,usuario_movimiento,valor_anterior,notas) " & _
                                   "SELECT reloj,fecha,tipo_aus,GETDATE(),'" & Usuario & _
                                   "','/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/','" & _
                                   System.Reflection.MethodBase.GetCurrentMethod.Name() & "' FROM ausentismo WHERE reloj = '" & R & _
                                   "' AND fecha ='" & FechaSQL(Fecha) & "'", "TA")

                        sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & R & "' AND fecha ='" & FechaSQL(Fecha) & "'", "TA")



                        Inserta = True

                    End If
                Else
                    Inserta = True
                End If
                If EsFestivo Then
                    Inserta = False
                End If

                If Inserta Then
                    sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,dia,periodo,tipo_tran,pareja,preus,ano) VALUES ('" & _
                               Comp & "','" & R & "','" & Gafete & "','" & FechaSQL(FechaEntrada) & "','" & MerMilitar(Entrada) & "','" & _
                               DiaSem(FechaEntrada) & "','" & Periodo.Substring(4, 2) & "','S',1," & Preus & ",'" & Periodo.Substring(0, 4) & "')", "TA")
                    sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,dia,periodo,tipo_tran,pareja,preus,ano) VALUES ('" & _
                               Comp & "','" & R & "','" & Gafete & "','" & FechaSQL(FechaSalida) & "','" & MerMilitar(Salida) & "','" & _
                               DiaSem(FechaSalida) & "','" & Periodo.Substring(4, 2) & "','S',1," & Preus & ",'" & Periodo.Substring(0, 4) & "')", "TA")

                    'Insertar en bitácora
                    If dtHrsBrtTEMP.Rows.Count > 0 Then
                        'Si había al menos un registro antes de entrar al procedimiento
                        'Revisar si el registro anterior era entrada o salida
                        'Si aún no estaba marcado, se considera salida, por ser el primer movimiento
                        ES = IIf(IsDBNull(dtHrsBrtTEMP.Rows(0).Item("entrada_salida")), "E", dtHrsBrtTEMP.Rows(0).Item("entrada_salida"))
                        'Si el registro anterior estaba ya marcado de entrada o salida, 
                        If ES = "E" Then
                            dtTemp = sqlExecute("INSERT INTO bitacora_hrs_brt " & _
                           "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                           R & "','" & FechaSQL(FechaEntrada) & "','" & MerMilitar(Entrada) & "','" & _
                                       Usuario & "',GETDATE(),'S','" & FechaSQL(dtHrsBrtTEMP.Rows(0).Item(("fecha"))) & "','" & _
                                       dtHrsBrtTEMP.Rows(0).Item("hora") & "')", "TA")
                        Else
                            dtTemp = sqlExecute("INSERT INTO bitacora_hrs_brt " & _
                           "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                           R & "','" & FechaSQL(FechaSalida) & "','" & MerMilitar(Salida) & "','" & _
                                       Usuario & "',GETDATE(),'S','" & FechaSQL(dtHrsBrtTEMP.Rows(0).Item(("fecha"))) & "','" & _
                                       dtHrsBrtTEMP.Rows(0).Item("hora") & "')", "TA")
                        End If

                        If dtHrsBrtTEMP.Rows.Count > 1 Then
                            'Si había más de un registro antes de entrar al procedimiento
                            'Revisar si el registro anterior era entrada o salida
                            'Si aún no estaba marcado, se considera salida, por ser el segundo movimiento
                            ES = IIf(IsDBNull(dtHrsBrtTEMP.Rows(1).Item("entrada_salida")), "S", dtHrsBrtTEMP.Rows(1).Item("entrada_salida"))
                            'Si el registro anterior estaba ya marcado de entrada o salida, 
                            If ES = "E" Then
                                dtTemp = sqlExecute("INSERT INTO bitacora_hrs_brt " & _
                           "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                           R & "','" & FechaSQL(FechaEntrada) & "','" & MerMilitar(Entrada) & "','" & _
                                           Usuario & "',GETDATE(),'S','" & FechaSQL(dtHrsBrtTEMP.Rows(0).Item(("fecha"))) & "','" & _
                                           dtHrsBrtTEMP.Rows(1).Item("hora") & "')", "TA")
                            Else
                                dtTemp = sqlExecute("INSERT INTO bitacora_hrs_brt " & _
                           "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                           R & "','" & FechaSQL(FechaSalida) & "','" & MerMilitar(Salida) & "','" & _
                                           Usuario & "',GETDATE(),'S','" & FechaSQL(dtHrsBrtTEMP.Rows(1).Item(("fecha"))) & "','" & _
                                           dtHrsBrtTEMP.Rows(1).Item("hora") & "')", "TA")
                            End If
                        End If

                        'Si hubiera más registros del día, pasar a bitácora sin nueva fecha-hora
                        For x = 2 To dtHrsBrtTEMP.Rows.Count - 1
                            sqlExecute("INSERT INTO bitacora_hrs_brt " & _
                           "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                           R & "',NULL,NULL,'" & Usuario & "',GETDATE(),'S','" & _
                                       FechaSQL(dtHrsBrtTEMP.Rows(x).Item(("fecha"))) & "','" & dtHrsBrtTEMP.Rows(x).Item("hora") & "')", "TA")
                        Next
                    End If
                    'Limpiar la variable antes de salir
                    dtHrsBrtTEMP = New DataTable

                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "TA", ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Public Sub LlenaNomSem(ByVal drEmpleado As DataRow, Periodo As String, dtAsist As DataTable)
        Try
            Dim registros As Integer = 0
            Dim hrs_normal As Double = 0
            Dim hrs_extras As Double = 0
            Dim hrs_dobles As Double = 0
            Dim hrs_triples As Double = 0
            Dim hrs_tarde As Double = 0


            'Marzo2018 Abraham Casas
            Dim hrs_fel As Double = 0

            Dim hrs_prim_dom As Double = 0
            Dim hrs_prim_sab As Double = 0

            Dim hrs_descanso As Double = 0
            Dim hrs_festivo As Double = 0
            Dim shrs_dia As Double = 0
            Dim hrs_conv As Double = 0
            Dim pareja As Boolean = True
            Dim bono_puntualidad As Boolean = True
            Dim bono_asistencia As Boolean = True
            Dim asistencia_perfecta As Boolean = True
            Dim ausentismo As Boolean = True
            Dim periodo_act As Double = 0
            Dim dobles_exentas As Double = 0
            Dim dobles_33 As Double = 0
            Dim triples_33 As Double = 0
            Dim tran_cerrada As Boolean = False
            Dim ExtrasDiarias As Double = 0
            Dim DiasExtras As Integer = 0
            Dim DiasTrab As Integer = 0
            Dim diascafe As Integer = 0
            Dim dias_inc As Integer = 0
            Dim dias_cvn As Integer = 0
            'MCR 11/NOV/2015
            'Variables cálculo 3/3
            Dim DoblesIntegrables As Double = 0
            Dim TriplesIntegrables As Double = 0
            Dim Total33 As Double = 0
            Dim Excedente As Double = 0

            Dim DblDiarias As Double
            Dim TrplDiarias As Double
            Dim DblDiariasIntegrables As Double
            Dim TrplDiariasIntegrables As Double

            'calcular bonos

            Dim BONASI As Double = 0
            Dim BONPUN As Double = 0
            Dim BONDES As Double = 0

            Dim FestivoSeparado As Boolean
            Dim FestivoDescanso As Boolean

            Dim EsFestivo As Boolean = False
            Dim EsDescanso As Boolean = False
            Dim EsDomingo As Boolean = False
            Dim Fecha As Date

            Dim prima_dom As Integer = 0
            Dim prima_sab As Integer = 0

            Dim dtTAsist As New DataTable
            Dim drAsist As DataRow

            Dim R As String

            Dim Cadena As String = ""
            R = drEmpleado("reloj")

            'Borrar los datos que pudiera haber en nomsem
            sqlExecute("DELETE FROM nomsem WHERE reloj = '" & R & "' AND ano = '" & Periodo.Substring(0, 4) & "' AND periodo = '" & Periodo.Substring(4, 2) & "'", "TA")

            dtTemp = sqlExecute("SELECT festivo_sep,festivo_a_descanso FROM cias_ta WHERE cod_comp = '" & drEmpleado("cod_comp") & "'", "TA")
            If dtTemp.Rows.Count = 0 Then
                Exit Sub
                Debug.Print("Falta información de CiasTa para " & drEmpleado("cod_comp"))
            Else
                FestivoSeparado = IIf(IsDBNull(dtTemp.Rows(0).Item("festivo_sep")), True, dtTemp.Rows(0).Item("festivo_sep"))
                FestivoDescanso = IIf(IsDBNull(dtTemp.Rows(0).Item("festivo_a_descanso")), True, dtTemp.Rows(0).Item("festivo_a_descanso"))
            End If

            'Actualizar datos de personal que hay en asist, para todos los registros del periodo
            'De acuerdo a:
            '*** EL 23 ENERO 07 SUSY PIDIO QUE SE ACTUALIZARAN LOS DATOS DE TODA LA SEMANA
            '*** IVO

            Cadena = "UPDATE asist SET cod_comp = '" & drEmpleado("cod_comp") & "',"
            Cadena = Cadena & " cod_depto = '" & drEmpleado("cod_depto") & "', cod_puesto = '" & drEmpleado("cod_puesto") & "', cod_tipo = '" & drEmpleado("cod_tipo") & "',"
            Cadena = Cadena & " cod_super = '" & drEmpleado("cod_super") & "', cod_turno = '" & drEmpleado("cod_turno") & "', cod_clase = '" & drEmpleado("cod_clase") & "'"
            Cadena = Cadena & " WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & R & _
                                  "' AND ano = '" & Periodo.Substring(0, 4) & "' AND periodo = '" & Periodo.Substring(4, 2) & "'"
            dtTemp = sqlExecute(Cadena, "TA")

            dtAsist = sqlExecute("SELECT MIN(pareja) as pareja,MAX(ausentismo) as ausentismo," & _
                                "SUM(dbo.htod(horas_extras)) as horas_extras," & _
                                 "SUM(dbo.htod(extras_autorizadas)) as extras_autorizadas," & _
                                 "SUM(dbo.HTOD(horas_normales)) AS horas_normales," & _
                                 "SUM(dbo.HTOD(horas_tarde)) AS horas_tarde," & _
                                 "SUM(dbo.HTOD(horas_anticipadas)) AS horas_anticipadas," & _
                                 "SUM(dbo.HTOD(horas_convenio)) AS horas_convenio," & _
                                 "fha_ent_hor,MIN(fecha_entro) AS fecha_entro,MIN(entro) AS entro FROM asist " & _
                                 "WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & R & _
                                 "' AND ano = '" & Periodo.Substring(0, 4) & "' AND periodo = '" & Periodo.Substring(4, 2) & _
                                  "' GROUP BY FHA_ENT_HOR", "TA")

            'ABRAHAM CASAS, HORAS RETARDO, SOLAMENTE CUANDO EL COMENTARIO DIGA RETARDO, 2017/10/05
            Dim EsSabado As Boolean = False
            Dim hrs_nopag As Double = 0
            Dim hrs_retardo As Double = 0

            Dim dtRetardo As DataTable = sqlExecute("SELECT SUM(dbo.HTOD(horas_tarde)) AS horas_tarde FROM asist " & _
                                "WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & R & _
                                 "' AND ano = '" & Periodo.Substring(0, 4) & "' AND periodo = '" & Periodo.Substring(4, 2) & _
                                  "' and comentario like '%retardo%'", "TA")
            If dtRetardo.Rows.Count > 0 Then
                hrs_retardo = IIf(IsDBNull(dtRetardo.Rows(0)("horas_tarde")), 0, dtRetardo.Rows(0)("horas_tarde"))
            End If

            For Each drAsist In dtAsist.Rows
                'Contar registros
                registros = registros + 1

                'Utilizar la fecha de su horario como base
                Fecha = drAsist("fha_ent_hor")

                'Definir si esta fecha corresponde a un día festivo, domingo o descanso                
                EsDomingo = DiaSem(Fecha).ToLower = "domingo"
                EsSabado = DiaSem(Fecha).ToLower = "sábado"
                EsDescanso = DiaDescanso(Fecha, R)
                EsFestivo = Festivo(Fecha, R)

                'Sumar horas
                If Not FestivoSeparado Or Not EsFestivo Then
                    'Si no se separan las horas del festivo
                    'o no es festivo
                    hrs_normal = hrs_normal + drAsist("horas_normales")
                    hrs_tarde = hrs_tarde + drAsist("horas_tarde")
                    hrs_conv = hrs_conv + drAsist("horas_convenio")
                Else
                    hrs_festivo = hrs_festivo + drAsist("horas_normales")
                    hrs_tarde = hrs_tarde + drAsist("horas_tarde")
                End If

                If drAsist("horas_anticipadas") < 0 Then
                    hrs_nopag += drAsist("horas_anticipadas") * -1
                End If

                If drAsist("horas_tarde") > 0 Then
                    hrs_nopag += drAsist("horas_tarde")
                End If

                'NOVIEMBRE 2018 ABRAHAM CASAS
                ''Contabilizar horas extras
                'If FestivoSeparado Then
                '    If EsFestivo And FestivoDescanso Then
                '        hrs_descanso = hrs_descanso + drAsist("extras_autorizadas")
                '    Else
                '        hrs_extras = hrs_extras + drAsist("extras_autorizadas")
                '    End If
                'Else
                '    hrs_extras = hrs_extras + drAsist("extras_autorizadas")
                'End If

                ExtrasDiarias = drAsist("extras_autorizadas")



                'Si es domingo
                Try
                    If EsDomingo Then

                        hrs_prim_dom = hrs_prim_dom + drAsist("horas_extras") + drAsist("horas_normales")
                        Dim dtComentario As DataTable = sqlExecute("select * from asist where reloj = '" & R & "' and fha_ent_hor = '" & FechaSQL(drAsist("fha_ent_hor")) & "'", "TA")

                        If hrs_prim_dom > 0 Then
                            Try
                                If RTrim(dtComentario.Rows(0)("entro")) <> "" Then
                                    prima_dom = 1
                                Else
                                    prima_dom = 0
                                End If
                            Catch ex As Exception
                                prima_dom = 0
                            End Try
                        Else

                            For Each r_comentario As DataRow In dtComentario.Rows
                                Dim comentario As String = r_comentario("comentario")
                                If comentario.ToUpper.Contains("FALTA") Then
                                    If (comentario.ToUpper.Contains("SALIDA")) Then
                                        prima_dom = 1
                                    End If
                                End If
                            Next

                        End If
                    End If


                Catch ex As Exception

                End Try


                Try
                    If EsSabado Then

                        hrs_prim_sab = hrs_prim_sab + drAsist("horas_extras") + drAsist("horas_normales")
                        Dim dtComentario As DataTable = sqlExecute("select * from asist where reloj = '" & R & "' and fha_ent_hor = '" & FechaSQL(drAsist("fha_ent_hor")) & "'", "TA")

                        If hrs_prim_sab > 0 Then

                            Try
                                If RTrim(dtComentario.Rows(0)("entro")) <> "" Then
                                    prima_sab = 1
                                Else
                                    prima_sab = 0
                                End If
                            Catch ex As Exception
                                prima_sab = 0
                            End Try
                        Else
                            For Each r_comentario As DataRow In dtComentario.Rows
                                Dim comentario As String = r_comentario("comentario")
                                If comentario.ToUpper.Contains("FALTA") Then
                                    If (comentario.ToUpper.Contains("SALIDA")) Then
                                        prima_sab = 1
                                    End If
                                End If
                            Next

                        End If
                    End If


                Catch ex As Exception

                End Try


                ''Marzo2018 Abraham Casas
                ''HRSFEL
                ''Para los dias festivos generales (independientemente del horario del empleado), todas las horas se consideran dobles y no se toman en cuenta para la regla de 9 horas
                ''Dim festivo_general As Boolean = False
                'Dim dtFestivoGeneral As DataTable = sqlExecute("select * from ausentismo where reloj = '" & R & "' and fecha = '" & FechaSQL(Fecha) & "' and tipo_aus = 'FES'", "TA")
                'If dtFestivoGeneral.Rows.Count > 0 Then
                '    If ExtrasDiarias > 0 Then
                '        hrs_fel += ExtrasDiarias
                '        ExtrasDiarias = 0
                '        hrs_extras = 0
                '    End If
                'End If

                'Noviembre2018 Abraham Casas
                'HRSFEL
                'Se limitan las horas festivas a las horas determinadas por el horario, el restante de horas se consideran extras
                'Dim festivo_general As Boolean = False
                Dim dtFestivoGeneral As DataTable = sqlExecute("select * from ausentismo where reloj = '" & R & "' and fecha = '" & FechaSQL(Fecha) & "' and tipo_aus = 'FES'", "TA")
                If dtFestivoGeneral.Rows.Count > 0 Then
                    If ExtrasDiarias > 0 Then

                        Dim cod_dia As Integer = DiaSemInt(Fecha)
                        Dim se As DetalleSemana = SemanaHorarioMixto(Periodo, R)
                        Dim dtDiasHorario As DataTable = sqlExecute("select ta.dbo.htod(hrs_dia) as hrs_dia from dias where cod_hora = '" & se.cod_hora & "' and cod_comp = '" & drEmpleado("cod_comp") & "' and semana = '" & se.NumSemana & "' and isnull(descanso, 0) = 0 and cod_Dia = '" & cod_dia & "'")
                        Dim hrs_dia As Double = 0
                        If dtDiasHorario.Rows.Count > 0 Then
                            Try
                                hrs_dia = dtDiasHorario.Rows(0)("hrs_dia")
                            Catch ex As Exception

                            End Try
                        End If
                        hrs_fel += IIf(ExtrasDiarias > hrs_dia, hrs_dia, ExtrasDiarias)
                        ExtrasDiarias = IIf(ExtrasDiarias > hrs_dia, ExtrasDiarias - hrs_dia, 0)

                    End If
                End If

                hrs_extras += ExtrasDiarias

                hrs_festivo = 0
                hrs_descanso = 0

                If ExtrasDiarias > 0 Then
                    'Contabilizar horas dobles y triples
                    If hrs_extras > 9 Then
                        DblDiarias = 9 - hrs_dobles
                        TrplDiarias = ExtrasDiarias - DblDiarias

                        hrs_dobles = 9
                        hrs_triples = hrs_extras - hrs_dobles
                    Else
                        hrs_dobles = hrs_extras
                        DblDiarias = ExtrasDiarias
                    End If

                    '****** Sistema 3x3 ******
                    'MCR 12/NOV/2015
                    'ABRAHAM CASAS 2019 - Ajustes para queretaro
                    Dim Aplica33 As Integer = sqlExecute("select isnull(regla_33, 0) as regla_33 from cias_ta where cod_comp = '" & _
                                                         drEmpleado("cod_comp") & "'", "ta").Rows(0)("regla_33")
                    If Aplica33 Then
                        DiasExtras += 1

                        'Todas las triples se integran
                        TrplDiariasIntegrables = TrplDiarias

                        If EsDescanso Or EsFestivo Then
                            'Si es descanso o festivo, las horas extras son todas integrables
                            DblDiariasIntegrables = DblDiarias
                        ElseIf EsFestivo Then
                            DblDiariasIntegrables = 0
                        Else
                            If DiasExtras > 3 Then
                                'Después de 3 días con tiempo extra, todas las extras son integrables
                                DblDiariasIntegrables = DblDiarias
                            ElseIf DblDiarias > 3 Then
                                'Las primeras 3 horas extras del día no son integrables
                                DblDiariasIntegrables = DblDiarias - 3
                            Else
                                'Si no son más de 3 días, ni más de 3 horas, no hay dobles integrables
                                DblDiariasIntegrables = 0
                            End If
                        End If
                        'Acumular integrables semanales
                        DoblesIntegrables += DblDiariasIntegrables
                        TriplesIntegrables += TrplDiariasIntegrables

                        'Actualizar tabla de ASIST
                        sqlExecute("UPDATE asist SET analizado_33 = 1, " & _
                                   "dobles_33 = " & Math.Round(DblDiariasIntegrables, 4) & ", " & _
                                   "triples_33 = " & Math.Round(TrplDiariasIntegrables, 4) & _
                                   " WHERE reloj = '" & R & "' AND fha_ent_hor = '" & FechaSQL(drAsist("fecha_entro")) & "' AND " & _
                                   "entro = '" & drAsist("entro") & "'", "TA")


                        sqlExecute("update extras_autorizadas set dobles33 = '" & Math.Round(DblDiariasIntegrables, 4) & "', triples33 = '" & Math.Round(TrplDiariasIntegrables, 4) & "' where reloj = '" & R & "' and fecha = '" & FechaSQL(drAsist("fecha_entro")) & "'", "TA")

                    End If ' Aplica33
                    '***** ***** ****
                End If


                'Revisar si todos tienen pareja
                pareja = pareja And (drAsist("pareja") = 1)

                'Revisar si hubo ausentismo
                ausentismo = ausentismo And (IIf(IsDBNull(drAsist("ausentismo")), 0, drAsist("ausentismo")) = 1)
            Next


            ''CALCULO DE BONOS BRP (ABRAHAM)
            BONASI = bonos_asistencia(R, Periodo)
            'BONPUN = bonos_puntualidad(R, Periodo)
            'BONDES = bonos_cupon(R, Periodo)

            


            Dim dtCalculoBonos As DataTable = sqlExecute("select * from cias_ta where cod_comp = '" & drEmpleado("cod_comp") & "' and calcula_bonos = '1'", "TA")
            If dtCalculoBonos.Rows.Count <= 0 Then
                BONASI = 0
                BONPUN = 0
                BONDES = 0
            End If

            'Hrs_normal_originales CONSERVA LAS HORAS ORIGINALES
            'hrs_normal LAS HORAS FLEXTIME EN CASO DE QUE APLIQUE

            Dim Hrs_normal_originales As Double = hrs_normal

            hrs_nopag = hrs_nopag - hrs_retardo

            Dim dtFiltro_flextime As DataTable = sqlExecute("select filtro_flextime from parametros where filtro_flextime is not null")
            If dtFiltro_flextime.Rows.Count > 0 Then
                Dim filtro_flextime As String = dtFiltro_flextime.Rows(0)("filtro_flextime")

                Dim dt_flextime As DataTable = sqlExecute("select reloj from personal where reloj = '" & R & "' and " & filtro_flextime & "")
                If dt_flextime.Rows.Count > 0 Then
                    hrs_normal = horas_flextime(R, Periodo)
                End If
            End If


            dtTemp = sqlExecute("SELECT DISTINCT FHA_ENT_HOR FROM asist WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & R & _
                                 "' AND ano = '" & Periodo.Substring(0, 4) & "' AND periodo = '" & Periodo.Substring(4, 2) & _
                                  "' AND RTRIM(entro) <>'' and RTRIM(salio) <> ''", "TA")
            DiasTrab = dtTemp.Rows.Count

            sqlExecute("INSERT INTO nomsem (reloj,ano,periodo,tran_cerrada) VALUES ('" & R & "','" & Periodo.Substring(0, 4) & "','" & _
                       Periodo.Substring(4, 2) & "',0)", "TA")

            diascafe = dias_comida(R, Periodo)
            dias_inc = dias_incapacidad(R, Periodo)
            dias_cvn = dias_convenio(R, Periodo)

            ActualizaNomSem(R, "hrs_normales_original", Hrs_normal_originales, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "hrs_festivo_original", hrs_festivo, Periodo.Substring(0, 4), Periodo.Substring(4, 2))



            'MCR 11/NOV/2015
            'Si no se editaron horas manualmente, tomar calculadas
            If Semana.Mixto Then
                ActualizaNomSem(R, "hrs_normales", hrs_normal * Semana.Factor, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
                ActualizaNomSem(R, "hrs_festivo", hrs_festivo * Semana.Factor, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            Else
                ActualizaNomSem(R, "hrs_normales", hrs_normal, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
                ActualizaNomSem(R, "hrs_festivo", hrs_festivo, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            End If

            ActualizaNomSem(R, "hrs_dobles", hrs_dobles, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "hrs_triples", hrs_triples, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "hrs_prim_dom", hrs_prim_dom, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "hrs_descanso", hrs_descanso, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "dobles_33", DoblesIntegrables, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "triples_33", TriplesIntegrables, Periodo.Substring(0, 4), Periodo.Substring(4, 2))

            'Marzo2018 Abraham Casas
            ActualizaNomSem(R, "hrs_fel", hrs_fel, Periodo.Substring(0, 4), Periodo.Substring(4, 2))

            ActualizaNomSem(R, "hrs_nopag", hrs_nopag, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "hrs_retardo", hrs_retardo, Periodo.Substring(0, 4), Periodo.Substring(4, 2))

            ActualizaNomSem(R, "hrs_retardo", hrs_retardo, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "hrs_retardo", hrs_retardo, Periodo.Substring(0, 4), Periodo.Substring(4, 2))

            ActualizaNomSem(R, "prima_dom", prima_dom, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "prima_sab", prima_sab, Periodo.Substring(0, 4), Periodo.Substring(4, 2))

            ActualizaNomSem(R, "hrs_convenio", hrs_conv, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "hrs_tarde", hrs_tarde, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "pareja", IIf(pareja, 1, 0), Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "semana", Semana.NumSemana, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "dias_trabajados", DiasTrab, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "bono04", diascafe, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "bono05", dias_inc, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "bono06", dias_cvn, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ' ORDEN IMPORTANTE!!
            ActualizaNomSem(R, "bono01", BONASI, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "bono02", BONPUN, Periodo.Substring(0, 4), Periodo.Substring(4, 2))

            ActualizaNomSem(R, "bono_asistencia", BONASI, Periodo.Substring(0, 4), Periodo.Substring(4, 2))
            ActualizaNomSem(R, "bono_puntualidad", BONPUN, Periodo.Substring(0, 4), Periodo.Substring(4, 2))

            ActualizaNomSem(R, "bono03", BONDES, Periodo.Substring(0, 4), Periodo.Substring(4, 2))


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub ActualizaNomSem(R As String, Campo As String, Valor As String, ano As String, periodo As String)
        Try
            sqlExecute("UPDATE nomsem SET " & Campo & " = '" & Valor & "' WHERE reloj = '" & R & "' AND ano = '" & ano & "' AND periodo = '" & periodo & "'", "TA")
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "FuncionesTA", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub DepuracionHrsBRT(reloj As String, _fecha As Date, rango_horas As Double)
        Try
            Dim rango_depuracion As Integer = 1

            Try
                Dim dtRangoMinutosDepuracion As DataTable = sqlExecute("select top 1 * from parametros")
                If dtRangoMinutosDepuracion.Rows.Count > 0 Then
                    rango_depuracion = dtRangoMinutosDepuracion.Rows(0)("rango_depuracion")
                End If
            Catch ex As Exception
                'MessageBox.Show(ex.Message)
            End Try

            Dim dtHorasEnBruto As DataTable = sqlExecute("select * from hrs_brt where reloj = '" & reloj & "' and cast(convert(char(10), fecha, 20) + ' ' + hora as date) between '" & FechaHoraSQL(_fecha.AddHours(rango_horas * -1), False, False) & "' and '" & FechaHoraSQL(_fecha.AddHours(24 + rango_horas), False, False) & "'", "TA")

            Dim dtBorrar As New DataTable
            dtBorrar.Columns.Add("reloj", Type.GetType("System.String"))
            dtBorrar.Columns.Add("fecha", Type.GetType("System.DateTime"))
            dtBorrar.Columns.Add("hora", Type.GetType("System.String"))

            For Each row As DataRow In dtHorasEnBruto.Rows
                Dim r As String = row("reloj")
                Dim f As Date = row("fecha")
                Dim h As String = row("hora")

                Dim fh As Date = Date.Parse(FechaSQL(f) & Space(1) & h)

                For m As Integer = 1 To rango_depuracion
                    fh = fh.AddMinutes(1)

                    Dim _f As String = FechaSQL(fh)
                    Dim _h As String = fh.Hour.ToString.PadLeft(2, "0") & ":" & fh.Minute.ToString.PadLeft(2, "0")

                    If dtHorasEnBruto.Select("fecha = '" & _f & "' and hora = '" & _h & "'").Count > 0 Then
                        dtBorrar.Rows.Add({r, f, h})
                    End If
                Next

            Next

            For Each row As DataRow In dtBorrar.Rows
                'If MessageBox.Show(row("reloj") & vbCrLf & row("fecha") & vbCrLf & row("hora"), "Borrar?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                sqlExecute("delete from hrs_brt where reloj = '" & row("reloj") & "' and fecha = '" & FechaSQL(row("fecha")) & "' and hora = '" & row("hora") & "'", "TA")

                sqlExecute("INSERT INTO bitacora_hrs_brt " & _
                       "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES (" & _
                       "'" & row("reloj") & "',null,''," & _
                                   "'Depuración', GETDATE(), 'S', '" & FechaSQL(row("fecha")) & "','" & row("hora") & "')", "TA")

                'End If
            Next

        Catch ex As Exception

        End Try
    End Sub

End Module
