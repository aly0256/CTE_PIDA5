Module FuncionesConceptos

    '' bonos miscelaneos

    Public Function FuncionConcepto(concepto As String, cod_comp As String, ano As String, periodo As String, monto As Double, tipo_periodo As String) As DataTable
        Select Case RTrim(concepto).ToUpper
            ' BONOS POLYGROUP NO APLICAN BRP
            Case "IDEAS"
                Return concepto_ideas(cod_comp, ano, periodo, monto, tipo_periodo)
                'Case "BONESP"
                '    Return concepto_bonesp(cod_comp, ano, periodo, monto)
                'Case "BONPRO"
                '    Return concepto_bonpro(cod_comp, ano, periodo, monto)
            Case "BONREC"
                Return bono_recomendacion(cod_comp, ano, periodo, monto, tipo_periodo)
        End Select
        Return New DataTable
    End Function

    Public Function bono_recomendacion(cod_comp As String, ano As String, periodo As String, monto As Double, tipo_periodo As String) As DataTable

        Dim concepto_nombre As String = "BONREC"
        monto = 0
        Dim dtAjustesNom As New DataTable
        Dim totaldias As Integer
        Dim cod_turno As String
        Dim concepto_clave As String = "7"
        Dim comentario As String = ""
        dtAjustesNom.Columns.Add("RELOJ", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("ANO", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("PERIODO", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("PER_DED", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("CLAVE", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("MONTO", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("COMENTARIO", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("CONCEPTO", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("USUARIO", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("FECHA", Type.GetType("System.String"))

        '----Borrar todos los registros de BONREC del periodo para evitar duplicados
        sqlExecute("delete from ajustes_nom where tipo_periodo = '" & tipo_periodo & "' and ano >= '" & ano & "' and periodo >= '" & periodo & "' and  rtrim(concepto) like '%" & concepto_nombre & "%' and usuario = 'EXPORT'", "NOMINA")

        '----Obtener todos los auxiliares de recomendacion que esten aun activos 
        Dim dtauxiliares As DataTable = sqlExecute("select * from detalle_auxiliares where campo = 'RECOMEN' and detalles = '1' and reloj in (select reloj from personal where tipo_periodo = '" & tipo_periodo & "')")

        For Each row As DataRow In dtauxiliares.Rows
            comentario = ""
            Dim dtpersonal As DataTable = sqlExecute("select * from personal where reloj = '" & row("reloj") & "'")
            Dim dtpersonal2 As DataTable = sqlExecute("select * from personal where reloj = '" & row("contenido") & "'")
            If dtpersonal.Rows.Count > 0 Then

                If IsDBNull(dtpersonal.Rows(0).Item("baja")) And IsDBNull(dtpersonal2.Rows(0).Item("baja")) Then

                    '----Consultar bitacora para obtener el turno en el momento de la alta
                    ConsultaBitacora(dtpersonal, dtpersonal.Rows(0), dtpersonal.Rows(0).Item("alta"))



                    Dim periodotodo As DataTable = sqlExecute("select * from periodos where ano = '" & ano & "' and periodo = '" & periodo & "'", "TA")
                    Dim observacion As String = IIf(IsDBNull(periodotodo.Rows(0).Item("observaciones")), "", periodotodo.Rows(0).Item("observaciones"))
                    If observacion.ToUpper.Contains("BONREC") Then
                        Dim dtbonrec90 As DataTable = sqlExecute("select * from ajustes_nom where reloj = '" & row("contenido") & "' and concepto = 'BONREC' and tipo_periodo = '" & tipo_periodo & "' and comentario in ('Bono 90 " & row("reloj") & "', 'Bono 200 " & row("reloj") & "')", "NOMINA")
                        If Not dtbonrec90.Rows.Count > 0 Then
                            Dim dtasist As DataTable = sqlExecute("select * from asist where reloj = '" & row("reloj") & "' and tipo_aus = null", "TA")
                            If dtasist.Rows.Count > 0 Then
                                monto = 200
                                comentario = "Bono 200" & row("reloj")
                            End If
                        End If
                    Else
                    End If




                    '---Obtener total de dias activo del recomendado
                    totaldias = DateDiff(DateInterval.Day, dtpersonal.Rows(0).Item("alta"), Date.Now)

                    If totaldias >= 90 Then
                        Dim dtbonrec30 As DataTable = sqlExecute("select * from ajustes_nom where reloj = '" & row("contenido") & "' and concepto = 'BONREC' and tipo_periodo = '" & tipo_periodo & "' and comentario in ('Bono 90 " & row("reloj") & "', 'Bono 200 " & row("reloj") & "')", "NOMINA")
                        If Not dtbonrec30.Rows.Count > 0 Then
                            '---Si tiene mas 90 o mas dias y no se le a pagado el bono, pagar primera mitad
                            comentario = "Bono 90 " & row("reloj")
                            monto = 700
                        Else

                            If dtbonrec30.Rows(0).Item("comentario") = "Bono 200 " & row("reloj") Then

                                If sqlExecute("select * from ajustes_nom where reloj = '" & row("contenido") & "' and concepto = 'BONREC' and tipo_periodo = '" & tipo_periodo & "' and comentario in ('Bono 800 " & row("reloj") & "')", "NOMINA").Rows.Count > 0 Then
                                    '----Si ya se le pagaron ambos bonos marcar como concluido
                                    sqlExecute("update detalle_auxiliares set detalles = '0' where reloj = '" & row("reloj") & "' and campo = 'RECOMEN' and contenido = '" & row("contenido") & "'")
                                Else
                                    comentario = "Bono 800 " & row("reloj")
                                    monto = 800
                                End If

                            Else
                                '----Si ya se le pagaron ambos bonos marcar como concluido
                                sqlExecute("update detalle_auxiliares set detalles = '0' where reloj = '" & row("reloj") & "' and campo = 'RECOMEN' and contenido = '" & row("contenido") & "'")
                            End If

                        End If
                    End If

                    If comentario <> "" Then
                        Dim dr As DataRow = dtAjustesNom.NewRow
                        dr("reloj") = row("contenido")
                        dr("ano") = ano
                        dr("periodo") = periodo
                        dr("per_ded") = "P"
                        dr("clave") = concepto_clave
                        dr("monto") = monto
                        dr("comentario") = comentario
                        dr("concepto") = concepto_nombre
                        dr("usuario") = "EXPORT"
                        dr("fecha") = FechaSQL(Now)

                        dtAjustesNom.Rows.Add(dr)
                    End If
                Else
                    '----si el recomendado es baja marcar como concluido 
                    sqlExecute("update detalle_auxiliares set detalles = '0' where reloj = '" & row("contenido") & "' and campo = 'RECOMEN' and contenido = '" & row("reloj") & "'")
                End If

            End If
        Next

        Return dtAjustesNom
    End Function

    Public Function horas_flextime(rl As String, anoper As String) As Double
        Try
            Dim hrs_flex As Double = 0

            Dim q As String = "select asist.*, periodos.fecha_ini as fecha_ini_periodo, periodos.fecha_fin as fecha_fin_periodo from asist " & _
                " left join periodos on asist.fha_ent_hor between periodos.fecha_ini and periodos.fecha_fin" & _
                " where asist.reloj = '" & rl & "' and periodos.ano + periodos.periodo = '" & anoper & "' order by fha_ent_hor, entro"

            Dim dtAsist As DataTable = sqlExecute(q, "TA")

            Dim _fini As Date = Date.Parse(dtAsist.Rows(0)("fecha_ini_periodo"))
            Dim _ffin As Date = Date.Parse(dtAsist.Rows(0)("fecha_fin_periodo"))

            Dim _f As String = ""
            Dim _m As Integer = 0

            Dim dtInfoEmpleado As DataTable = sqlExecute("select reloj, cod_hora, cod_comp from personal where reloj = '" & rl & "'")



            Dim cod_hora As String = "" 'AOS 2022-02-10
            Dim drow As DataRow = dtInfoEmpleado.Rows(0)
            ConsultaBitacora(dtInfoEmpleado, drow, _ffin)
            cod_hora = ConsultaBitacoraHorarios(dtInfoEmpleado, drow, _ffin, "cod_hora") 'AOS 2022-02-10

            Dim _cod_hora As String = cod_hora 'AOS 2022-02-10
            '    Dim _cod_hora As String = RTrim(dtInfoEmpleado.Rows(0)("cod_hora"))
            Dim _cod_comp As String = RTrim(dtInfoEmpleado.Rows(0)("cod_comp"))

            For Each row As DataRow In dtAsist.Rows

                Dim f As String = FechaSQL(Date.Parse(row("fha_ent_hor")))

                'Dim wd As Integer = Date.Parse(f).DayOfWeek

                Dim wd As Integer = Weekday(Date.Parse(f), IIf(IniciaLunes, FirstDayOfWeek.Monday, FirstDayOfWeek.Sunday))

                Dim dtHorasDia As DataTable = sqlExecute("select * from dias where cod_comp = '" & _cod_comp & "' and cod_hora = '" & _cod_hora & "' and cod_dia = '" & wd & "'")

                Dim descanso As Boolean = False
                Dim HORAS_DIA As Double = 0

                Try
                    Dim comentario As String = RTrim(row("comentario"))                    

                    If comentario.ToUpper.Contains("RETARDO") Or comentario.ToUpper.Contains("ANTIC") Then

                        Dim entro As String = row("entro")

                        comentario = comentario.Replace("RETARDO, ", "")
                        comentario = comentario.Replace("SALIDA ANTICIPADA, ", "")
                        comentario = comentario.Replace("RETARDO", "")
                        comentario = comentario.Replace("SALIDA ANTICIPADA", "")
                        comentario = RTrim(comentario)

                        sqlExecute("update asist set comentario = '" & comentario & "' where reloj = '" & rl & "' and fha_ent_hor = '" & f & "' and entro = '" & entro & "'", "TA")
                    End If
                    
                Catch ex As Exception

                End Try

                Try
                    descanso = Boolean.Parse(dtHorasDia.Rows(0)("descanso"))

                    If descanso = True Then
                        HORAS_DIA = 0
                    Else
                        HORAS_DIA = HtoD(dtHorasDia.Rows(0)("hrs_dia"))
                    End If
                Catch ex As Exception

                End Try

                If _f = f Then
                    If _m > 1 Or _m = -1 Then
                        Continue For
                    Else
                        Dim entro As String = row("entro")
                        Dim salio As String = row("salio")

                        _m += IIf(entro <> "", 1, 0)
                        _m += IIf(salio <> "", 1, 0)

                        If _m > 1 Then
                            hrs_flex += HORAS_DIA

                            sqlExecute("update asist set normales_pago = '" & DtoH(HORAS_DIA) & "' where reloj = '" & rl & "' and fha_ent_hor = '" & FechaSQL(f) & "' and entro = '" & entro & "' and salio = '" & salio & "'", "TA")

                        End If

                    End If

                    _f = f
                Else
                    _m = 0

                    Dim entro As String = row("entro")
                    Dim salio As String = row("salio")

                    _m += IIf(RTrim(entro) <> "", 1, 0)
                    _m += IIf(RTrim(salio) <> "", 1, 0)

                    Dim tipo_aus As String = IIf(IsDBNull(row("tipo_aus")), "", row("tipo_aus"))
                    Dim dtGoceSueldo As DataTable = sqlExecute("select * from tipo_ausentismo where goce_sdo = '1' and tipo_aus = '" & tipo_aus & "'", "TA")
                    If dtGoceSueldo.Rows.Count > 0 Then
                        _m = -1
                        If tipo_aus <> "FES" Then
                            hrs_flex += HtoD(row("horas_normales"))

                            sqlExecute("update asist set normales_pago = '" & DtoH(HORAS_DIA) & "' where reloj = '" & rl & "' and fha_ent_hor = '" & FechaSQL(f) & "'", "TA")
                        Else
                            sqlExecute("update asist set normales_pago = '00:00' where reloj = '" & rl & "' and fha_ent_hor = '" & FechaSQL(f) & "'", "TA")
                        End If
                    End If

                    If _m > 1 Then
                        hrs_flex += HORAS_DIA

                        sqlExecute("update asist set normales_pago = '" & DtoH(HORAS_DIA) & "' where reloj = '" & rl & "' and fha_ent_hor = '" & FechaSQL(f) & "' and entro = '" & entro & "' and salio = '" & salio & "'", "TA")
                    End If

                    _f = f
                End If
            Next

            Return hrs_flex
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return 0
        End Try
    End Function

    'Public Function dias_comida(rl As String, anoper As String) As Double
    '    Try
    '        Dim dias As Integer = 0

    '        Dim q As String =
    '            "select marcajes.reloj, cast(marcajes.fechahora as date) as fecha, horarios.SERVICIO, ausentismo.tipo_aus from CAFETERIA.dbo.marcajes " & _
    '            "left join CAFETERIA.dbo.horarios on horarios.COD_HORARIO = marcajes.HORARIO_ASISTE " & _
    '            "left join ta.dbo.periodos on cast(marcajes.fechahora as date) between periodos.FECHA_INI and dateadd(day, -2, periodos.FECHA_FIN) " & _
    '            "left join ta.dbo.ausentismo on ausentismo.reloj = marcajes.reloj and ausentismo.fecha = CAST(fechahora as date) " & _
    '            "where marcajes.reloj = '" & rl & "' and periodos.ANO + periodos.PERIODO = '" & anoper & "' and horarios.SERVICIO = 'comida' and (ausentismo.tipo_aus is null or ausentismo.TIPO_AUS <> 'fes') order by fecha asc"

    '        Dim dtDias As DataTable = sqlExecute(q, "CAFETERIA")
    '        Dim f As String = ""
    '        For Each row As DataRow In dtDias.Rows
    '            Dim _f As String = FechaSQL(row("fecha"))
    '            If _f <> f Then
    '                dias += 1
    '            End If
    '            f = _f
    '        Next

    '        Return dias
    '    Catch ex As Exception

    '        Return 0
    '    End Try
    'End Function

    '2017/06/16
    Public Function dias_convenio(rl As String, anoper As String) As Double
        Try
            Dim dias As Integer = 0

            Dim dtaus_inc As DataTable = sqlExecute("select * from ausentismo left join periodos on fecha between periodos.fecha_ini and periodos.fecha_fin " & _
                                                    "where tipo_aus in ('CVN', 'C50') and reloj = '" & rl & "' and periodos.ANO + periodos.PERIODO = '" & anoper & "'", "TA")

            dias = dtaus_inc.Rows.Count
            Return dias
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' 'Función para calcular los días de pago para nómina
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Function dias_nomina(rl As String, anoper As String) As Double
        Try
            Dim _dias_pago_nom As Double = 0.0, Query As String = "", dtDiasPagoNom As New DataTable, condicion As String = ""

            condicion = " and (isnull(ENTRO,'')<>'' OR " & _
      "(isnull(TIPO_AUS,'')  in (select TIPO_AUS from tipo_ausentismo where isnull(GOCE_SDO,0)=1) and TIPO_AUS not in('VAC'))" & _
      ")"

            Query = "select distinct fha_ent_hor,baja from asist left join PERSONAL.dbo.personal on asist.reloj = personal.reloj " & _
              "WHERE ISNULL(asist.COMENTARIO,'') not like '%DESCANSO%' and asist.reloj = '" & rl & "' and ano+periodo = '" & anoper & "'" & condicion
            dtDiasPagoNom = sqlExecute(Query, "TA")

            If Not dtDiasPagoNom.Columns.Contains("Error") And dtDiasPagoNom.Rows.Count > 0 Then _dias_pago_nom = dtDiasPagoNom.Rows.Count

            If _dias_pago_nom > 6 Then _dias_pago_nom = 6

            Return _dias_pago_nom

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Funcion Calc Dias para nómina", ex.HResult, ex.Message)
            Return 0.0
        End Try
    End Function

    Public Function dias_incapacidad(rl As String, anoper As String) As Double
        Try
            Dim dias As Integer = 0

            Dim dtaus_inc As DataTable = sqlExecute("select * from ausentismo left join periodos on fecha between periodos.fecha_ini and periodos.fecha_fin " & _
                                                  "where tipo_aus in (select tipo_aus from tipo_ausentismo where tipo_naturaleza = 'I' or TIPO_AUS in('ISS')) and reloj = '" & rl & "' and periodos.ANO + periodos.PERIODO = '" & anoper & "'", "TA")

            dias = dtaus_inc.Rows.Count
            Return dias
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function dias_comida(rl As String, anoper As String) As Double
        Dim dias As Integer = 0
        Dim cod_hora As String = ""

        '--- Codigo para cargar manualmente
        Dim dtDiasCaf As DataTable = sqlExecute("select * from diacaf where reloj='" & rl & "'", "TA")
        If (Not dtDiasCaf.Columns.Contains("Error") And dtDiasCaf.Rows.Count > 0) Then
            Try : dias = Double.Parse(dtDiasCaf.Rows(0).Item("dias")) : Catch ex As Exception : dias = 0 : End Try
        End If
        Return dias

        '        Try
        '            Dim fIni As String = "", fFin As String = ""
        '            '--- Identificar fechas del periodo a analizar
        '            Dim dtFecPer As DataTable = sqlExecute("select * from periodos where ano+periodo='" & anoper & "'", "TA")
        '            If (Not dtFecPer.Columns.Contains("Error") And dtFecPer.Rows.Count > 0) Then
        '                Try : fIni = FechaSQL(dtFecPer.Rows(0).Item("FECHA_INI").ToString.Trim) : Catch ex As Exception : fIni = "" : End Try
        '                Try : fFin = FechaSQL(dtFecPer.Rows(0).Item("FECHA_FIN").ToString.Trim) : Catch ex As Exception : fFin = "" : End Try
        '            End If

        '            If (fIni = "" Or fIni Is Nothing) Then Return 0
        '            If (fFin = "" Or fFin Is Nothing) Then Return 0

        '            '**---Obtener el cod_hora que tiene cada empleado en el periodo a analizar
        '            Dim InfoBitacora As Boolean = True
        '            Dim dtConsultaBita As New DataTable
        '            Dim QConsultaBita As String = "SELECT CAMPO,VALORANTERIOR FROM bitacora_personal WHERE reloj = '" & rl & "' and campo='cod_hora' AND " & _
        '                "FECHA = (SELECT MIN(FECHA) AS FECHA FROM dbo.bitacora_personal AS BITACORA WHERE CAST(fecha AS DATE) > '" & fFin & "' AND " & _
        '                "campo = bitacora_personal.campo and reloj= bitacora_personal.reloj)  AND tipo_movimiento = 'C' ORDER BY fecha"
        '            dtConsultaBita = sqlExecute(QConsultaBita, "PERSONAL")
        '            If (Not dtConsultaBita.Columns.Contains("Error") And dtConsultaBita.Rows.Count > 0) Then  ' Lo va a tomar de la bitacora de acuerdo al perido en el que estuvo
        '                Try : cod_hora = dtConsultaBita.Rows(0).Item("VALORANTERIOR").ToString.Trim : Catch ex As Exception : cod_hora = "" : End Try

        '            Else  ' Si no está en bitácora, toma el que esta actual en personal
        '                Dim dtPersonal As DataTable = sqlExecute("Select * from personalvw where reloj='" & rl & "'", "PERSONAL")
        '                If (Not dtPersonal.Columns.Contains("Error") And dtPersonal.Rows.Count > 0) Then
        '                    Try : cod_hora = dtPersonal.Rows(0).Item("cod_hora").ToString.Trim : Catch ex As Exception : cod_hora = "" : End Try
        '                End If
        '            End If

        '            '----- Obtener datos del horario
        '            Dim dtHorario As DataTable = sqlExecute("select cod_dia,cod_dia_sal,entra,sale,DESCANSO from dias where cod_hora='" & cod_hora & "' and semana=1", "PERSONAL")
        '            If (dtHorario.Rows.Count = 0 Or dtHorario.Columns.Contains("Error")) Then Return 0

        '            '-----Validar si su horario es cuando sale al dia siguiente
        '            Dim diaEntra As String = "", diaSale As String = "", saleDiaSig As Boolean = False
        '            Try : diaEntra = dtHorario.Rows(0).Item("cod_dia").ToString.Trim : Catch ex As Exception : diaEntra = "" : End Try
        '            Try : diaSale = dtHorario.Rows(0).Item("cod_dia_sal").ToString.Trim : Catch ex As Exception : diaSale = "" : End Try
        '            If (diaEntra <> diaSale) Then saleDiaSig = True

        '            '--- Revisar las checadas que hay en ese periodo a evaluar
        '            Dim dtChecCaf As DataTable = sqlExecute("select * from checadas_qr_caf where id='" & rl & "' and fecha between '" & fIni & "' and '" & fFin & "' order by FECHA asc", "TA")
        '            If (Not dtChecCaf.Columns.Contains("Error") And dtChecCaf.Rows.Count > 0) Then

        '                '---Actualiza todos los dias en null para que no cuenten para dias de desc para que no se dupliquen
        '                sqlExecute("update checadas_qr_caf set cuenta=0,cod_hora='' where id='" & rl & "' and FECHA between '" & fIni & "' and '" & fFin & "'", "TA")

        '                '--Analizar cada una de las checadas de caf de ese periodo para ese empleado
        '                For Each rw As DataRow In dtChecCaf.Rows
        '                    Dim fecha As String = "", hora As String = "", dia_sem As Integer = 0, cod_dia As String = "", entra As String = "", sale As String = ""
        '                    Dim mismoDiaSal As Boolean = False
        '                    Try : fecha = FechaSQL(rw("FECHA")).ToString.Trim : Catch ex As Exception : fecha = "" : End Try
        '                    Try : hora = rw("HORA").ToString.Trim : Catch ex As Exception : hora = "" : End Try


        '                    dia_sem = Date.Parse(fecha).DayOfWeek
        '                    If (dia_sem = 0) Then
        '                        cod_dia = "7"
        '                        GoTo NOAPLICA '-- Confirma Brenda que si es en Domingo, la comida no se cobra, sea o no descanso
        '                    Else
        '                        cod_dia = Convert.ToString(dia_sem)
        '                    End If

        '                    '----**************************** Validar si hay una EXCEPCION de horario en esa fecha
        '                    Dim dtExcepciones As DataTable = sqlExecute("select top 1 reloj,COD_HORA,fecha from excepciones_horarios where reloj='" & rl & "' and fecha ='" & fecha & "'", "PERSONAL")
        '                    Dim dtCodHoraExcep As New DataTable
        '                    Dim cod_hora_excep As String = "", sal_sig_dia As Integer = 0, entra_excep As String = "", sale_excep As String = ""
        '                    If (Not dtExcepciones.Columns.Contains("Error") And dtExcepciones.Rows.Count > 0) Then
        '                        Try : cod_hora_excep = dtExcepciones.Rows(0).Item("cod_hora").ToString.Trim : Catch ex As Exception : cod_hora_excep = "" : End Try
        '                        dtCodHoraExcep = sqlExecute("select COD_HORA,ENTRADA,SALIDA,sal_sig_dia from excepciones_dias where COD_HORA='" & cod_hora_excep & "'", "PERSONAL")

        '                        If (Not dtCodHoraExcep.Columns.Contains("Error") And dtCodHoraExcep.Rows.Count > 0) Then
        '                            Try : entra_excep = MerMilitar(dtCodHoraExcep.Rows(0).Item("ENTRADA").ToString.Trim) : Catch ex As Exception : entra_excep = "" : End Try
        '                            Try : sale_excep = MerMilitar(dtCodHoraExcep.Rows(0).Item("SALIDA").ToString.Trim) : Catch ex As Exception : sale_excep = "" : End Try
        '                            Try : sal_sig_dia = Convert.ToInt32(dtCodHoraExcep.Rows(0).Item("sal_sig_dia")) : Catch ex As Exception : sal_sig_dia = 0 : End Try
        '                        End If

        '                        If (sal_sig_dia = 1) Then '---Si sale al siguiente día y su hora en la que comió es entre las 00:00 a las 09:00 Hrs entonces cod_dia se le resta - 1 ya que pertenece al mismo dia efectivo para poder comparar las horas
        '                            Dim HrDbl As Double = 0.0
        '                            HrDbl = HtoD(hora)
        '                            If (HrDbl >= 0.0 And HrDbl <= 9.0) Then
        '                                cod_dia = Convert.ToString(Convert.ToInt32(cod_dia) - 1)
        '                                mismoDiaSal = True
        '                            End If
        '                        End If

        '                        Dim EntradaAComer As Date, FechaIni As Date, EntradaTurno As Date, SalidaTurno As Date
        '                        FechaIni = Date.Parse(fecha)
        '                        EntradaAComer = DateAdd(DateInterval.Second, HtoD(hora) * 3600 + 1, FechaIni) '-La hora la necesitamos en formato HH:MM ejem: 15:35
        '                        EntradaTurno = DateAdd(DateInterval.Second, HtoD(entra_excep) * 3600 + 1, FechaIni)

        '                        If (mismoDiaSal) Then
        '                            SalidaTurno = DateAdd(DateInterval.Second, HtoD(sale_excep) * 3600 + 1, FechaIni)
        '                        Else
        '                            SalidaTurno = DateAdd(DateInterval.Second, HtoD(sale_excep) * 3600 + 1, FechaIni.AddDays(1))
        '                        End If

        '                        If (EntradaTurno <= EntradaAComer) And (SalidaTurno >= EntradaAComer) Then
        '                            dias += 1
        '                            sqlExecute("update checadas_qr_caf set cuenta=1,cod_hora='" & cod_hora & "' where id='" & rl & "' and fecha='" & fecha & "' and hora='" & hora & "'", "TA") ' Indicar que checadas se incluyeron para el descuento
        '                        End If

        '                        GoTo NOAPLICA ' Irse al final para continuar con la otra checada a analizar
        '                    End If

        '                    '---Si sale al siguiente día y su hora en la que comió es entre las 00:00 a las 09:00 Hrs entonces cod_dia se le resta - 1 ya que pertenece al mismo dia efectivo para poder comparar las horas
        '                    If (saleDiaSig) Then
        '                        Dim HrDbl As Double = 0.0
        '                        HrDbl = HtoD(hora)
        '                        If (HrDbl >= 0.0 And HrDbl <= 9.0) Then
        '                            cod_dia = Convert.ToString(Convert.ToInt32(cod_dia) - 1)
        '                            mismoDiaSal = True
        '                        End If
        '                    End If

        '                    Dim drowDia As DataRow = Nothing
        '                    Dim cod_dia_sal As String = ""
        '                    Try : drowDia = dtHorario.Select("cod_dia ='" & cod_dia & "'")(0) : Catch ex As Exception : drowDia = Nothing : End Try ' Aplica cualquier dia de Lun  a Sab (Menos domingo) y dentro de su horario normal
        '                    If (Not IsNothing(drowDia)) Then
        '                        Dim EntradaAComer As Date, FechaIni As Date, EntradaTurno As Date, SalidaTurno As Date
        '                        cod_dia_sal = drowDia("cod_dia_sal").ToString.Trim
        '                        FechaIni = Date.Parse(fecha)
        '                        entra = MerMilitar(drowDia("entra").ToString.Trim)
        '                        sale = MerMilitar(drowDia("sale").ToString.Trim)
        '                        EntradaAComer = DateAdd(DateInterval.Second, HtoD(hora) * 3600 + 1, FechaIni) '-La hora la necesitamos en formato HH:MM ejem: 15:35

        '                        ' Si comió en el mismo dia que sale, siendo que pertenece al mismo dia efectivo, entonces es el mismo dia de salida para poder comparar
        '                        If (mismoDiaSal) Then cod_dia_sal = cod_dia

        '                        EntradaTurno = DateAdd(DateInterval.Second, HtoD(entra) * 3600 + 1, FechaIni)

        '                        '--&&_Si el dia que entra y sale es el mismo, la fecha es la misma, si sale al dia sig, entonces a la fecha se le agrega 1 día para hacer la comparación de fechas
        '                        If (cod_dia = cod_dia_sal) Then SalidaTurno = DateAdd(DateInterval.Second, HtoD(sale) * 3600 + 1, FechaIni) Else SalidaTurno = DateAdd(DateInterval.Second, HtoD(sale) * 3600 + 1, FechaIni.AddDays(1))

        '                        If (EntradaTurno <= EntradaAComer) And (SalidaTurno >= EntradaAComer) Then
        '                            dias += 1
        '                            sqlExecute("update checadas_qr_caf set cuenta=1,cod_hora='" & cod_hora & "' where id='" & rl & "' and fecha='" & fecha & "' and hora='" & hora & "'", "TA") ' Indicar que checadas se incluyeron para el descuento
        '                        End If

        '                    End If
        'NOAPLICA:
        '                Next
        '            End If

        '            If (dias >= 6) Then dias = 6 ' Tope máximo de 6 comidas
        '            Return dias
        '        Catch ex As Exception
        '            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Cálculo dias cafetería", Err.Number, ex.Message)
        '            Return 0
        '        End Try
    End Function

    Public Function concepto_ideas(cod_comp As String, ano As String, periodo As String, monto As Double, tipo_periodo As String) As DataTable

        Dim concepto_nombre As String = "IDEAS"
        Dim concepto_descripcion As String = "Ideas"
        Dim concepto_clave As String = 44
        Dim concepto_monto As Double = 65

        Dim dtAjustesNom As New DataTable

        dtAjustesNom.Columns.Add("RELOJ", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("ANO", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("PERIODO", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("PER_DED", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("CLAVE", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("MONTO", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("COMENTARIO", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("CONCEPTO", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("USUARIO", Type.GetType("System.String"))
        dtAjustesNom.Columns.Add("FECHA", Type.GetType("System.String"))

        Try

            Dim dtIdeasAPagar As DataTable = sqlExecute("select * from ideas.dbo.ideas_empleado where envio_nomina is null and captura >= '2016-01-01' and pagada <= '" & ano & periodo & "' and estatus = 'I'")
            For Each row As DataRow In dtIdeasAPagar.Rows


                If sqlExecute("select * from personal where reloj = '" & row("reloj") & "'  and tipo_periodo = '" & tipo_periodo & "'").Rows.Count > 0 Then
                    sqlExecute("update ideas.dbo.ideas_empleado set envio_nomina = '" & FechaSQL(Now) & "' where folio = '" & row("folio") & "' and reloj = '" & row("reloj") & "'")

                    Dim dr As DataRow = dtAjustesNom.NewRow
                    dr("reloj") = row("reloj")
                    dr("ano") = ano
                    dr("periodo") = periodo
                    dr("per_ded") = "P"
                    dr("clave") = concepto_clave
                    If row("cod_objetivo").ToString.Contains("004") Then
                        dr("monto") = (concepto_monto * 2) / row("colaboradores")
                    Else
                        dr("monto") = (concepto_monto) / row("colaboradores")
                    End If
                    dr("comentario") = "Pago de idea #" & row("folio")
                    dr("concepto") = concepto_nombre
                    dr("usuario") = "EXPORT"
                    dr("fecha") = FechaSQL(Now)

                    dtAjustesNom.Rows.Add(dr)
                End If
            Next
        Catch ex As Exception

        End Try
        ' 
        Return dtAjustesNom
    End Function

    Public Function bonos_asistencia(rl As String, anoper As String) As Double
        Try

            '----NOTA: Esta configuración está en cantidad de dias, se mandan los dias que asistio el empleado, solo se peride si tiene:
            ' ING, VAC,FI,SUS,PSG

            Dim Query As String = ""
            Dim Concepto As String = "BONASI"
            Dim Monto As Double = 0
            Dim CalculaBono As Boolean = True
            Dim Condiciones As String = "isnull(TIPO_AUS,'') not in (select TIPO_AUS from tipo_ausentismo where AFECTA_BONO_ASISTENCIA = 1)" ' Condiciones de tipo aus que afectan al pago diario del bono de despensa

            ' Query = "select reloj from asist where reloj = '" & rl & "' and ano = '" & anoper.Substring(0, 4) & _
            '  "' AND periodo = '" & anoper.Substring(4, 2) & "' and " & Condiciones


            ' Dim dtAsist As DataTable = sqlExecute(Query, "ta")

            Dim dtAsist As DataTable

            Dim dtEmpleado As DataTable = sqlExecute("select * from personal where reloj = '" & rl & "' ")
            Dim cod_tipo As String = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_tipo")), "", dtEmpleado.Rows(0)("cod_tipo")).ToString.Trim
            Dim cod_turno As String = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_turno")), "", dtEmpleado.Rows(0)("cod_turno")).ToString.Trim
            Dim cod_hora As String = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_hora")), "", dtEmpleado.Rows(0)("cod_hora")).ToString.Trim

            '  If dtAsist.Rows.Count <= 0 Then


            'Query = "select distinct fha_ent_hor,baja from asist left join PERSONAL.dbo.personal on asist.reloj = personal.reloj WHERE asist.reloj = '" & rl & " ' and ano = '" & anoper.Substring(0, 4) & "' AND periodo = '" & anoper.Substring(4, 2) & "' AND " & _
            '    "ISNULL(entro,'') <>'' AND ISNULL(SALIO,'') <>'' AND " & Condiciones

            '---Con que tenga una sola entrada, no importa no tenga salida
            Query = "select distinct fha_ent_hor,baja from asist left join PERSONAL.dbo.personal on asist.reloj = personal.reloj WHERE asist.reloj = '" & rl & " ' and ano = '" & anoper.Substring(0, 4) & "' AND periodo = '" & anoper.Substring(4, 2) & "' AND " & _
       "ISNULL(entro,'') <>'' AND " & Condiciones


            dtAsist = sqlExecute(Query, "TA")
            If Not dtAsist.Columns.Contains("Error") And dtAsist.Rows.Count > 0 Then
                Dim totDias As Integer = 0, totDiasHabiles As Integer = 0
                '--- A: Obtener todos los dias que tiene registrado en asistencia
                totDias = dtAsist.Rows.Count

                '----B: Obtener los dias hábiles, NO DESCANSO que tiene de acuerdo a su horario
                Dim dtDias As DataTable = sqlExecute("SELECT descanso FROM dias LEFT JOIN personal ON dias.cod_comp = personal.cod_comp AND personal.cod_hora = dias.cod_hora " & _
                              "WHERE descanso = 0 AND reloj = '" & rl & "'")

                If Not dtDias.Columns.Contains("Error") And dtDias.Rows.Count > 0 Then
                    totDiasHabiles = dtDias.Rows.Count
                End If

                '----C: Topar a la cantidad de dias hábiles los dias que tiene registrado como asist
                Monto = totDias
                If Monto > totDiasHabiles Then Monto = totDiasHabiles

                'If Not IsDBNull(dtAsist(0)("baja")) Then


                '    If dtDias.Rows.Count > dtAsist.Rows.Count Then
                '        CalculaBono = False
                '    End If

                'End If
                'Dim dtConcepto As DataTable = sqlExecute("select misce_monto from conceptos where concepto = '" & Concepto & "'", "NOMINA")
                'If dtConcepto.Rows.Count And CalculaBono Then
                '    'Abraham Casas
                '    If cod_tipo = "A" Then
                '        Monto = 0
                '    Else

                '        Monto = dtConcepto.Rows(0)("misce_monto")

                '    End If
                'End If
            End If


            ' End If

            Return Monto
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return 0
        End Try
    End Function

    Public Function bonos_puntualidad(rl As String, anoper As String) As Double

        '----NOTA: Esta configuración está en cantidad de dias, se mandan los dias que asistio el empleado, solo se peride si tiene:
        ' ING, VAC,FI,SUS,PSG y RETARDOS
        Try
            Dim Query As String = ""
            Dim Concepto As String = "BONPUN"
            Dim Monto As Double = 0
            Dim CalculaBono As Boolean = True
            Dim Condiciones As String = "isnull(TIPO_AUS,'') not in (select TIPO_AUS from tipo_ausentismo where AFECTA_BONO_ASISTENCIA = 1) and asist.COMENTARIO not like '%RETAR%'" ' Condiciones de tipo aus que afectan al pago diario del bono de puntualidad

            Dim dtAsist As DataTable

            Dim dtEmpleado As DataTable = sqlExecute("select * from personal where reloj = '" & rl & "' ")
            Dim cod_tipo As String = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_tipo")), "", dtEmpleado.Rows(0)("cod_tipo")).ToString.Trim
            Dim cod_turno As String = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_turno")), "", dtEmpleado.Rows(0)("cod_turno")).ToString.Trim
            Dim cod_hora As String = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_hora")), "", dtEmpleado.Rows(0)("cod_hora")).ToString.Trim


            'Query = "select distinct fha_ent_hor,baja from asist left join PERSONAL.dbo.personal on asist.reloj = personal.reloj WHERE asist.reloj = '" & rl & " ' and ano = '" & anoper.Substring(0, 4) & "' AND periodo = '" & anoper.Substring(4, 2) & "' AND " & _
            '    "ISNULL(entro,'') <>'' AND ISNULL(SALIO,'') <>'' AND " & Condiciones

            '---Con que tenga una sola entrada y no sea retardo, aunque no tenga salida que si cuente para el BONPUN
            Query = "select distinct fha_ent_hor,baja from asist left join PERSONAL.dbo.personal on asist.reloj = personal.reloj WHERE asist.reloj = '" & rl & " ' and ano = '" & anoper.Substring(0, 4) & "' AND periodo = '" & anoper.Substring(4, 2) & "' AND " & _
          "ISNULL(entro,'') <>''  AND " & Condiciones


            dtAsist = sqlExecute(Query, "TA")
            If Not dtAsist.Columns.Contains("Error") And dtAsist.Rows.Count > 0 Then
                Dim totDias As Integer = 0, totDiasHabiles As Integer = 0
                '--- A: Obtener todos los dias que tiene registrado en asistencia
                totDias = dtAsist.Rows.Count

                '----B: Obtener los dias hábiles, NO DESCANSO que tiene de acuerdo a su horario
                Dim dtDias As DataTable = sqlExecute("SELECT descanso FROM dias LEFT JOIN personal ON dias.cod_comp = personal.cod_comp AND personal.cod_hora = dias.cod_hora " & _
                              "WHERE descanso = 0 AND reloj = '" & rl & "'")

                If Not dtDias.Columns.Contains("Error") And dtDias.Rows.Count > 0 Then
                    totDiasHabiles = dtDias.Rows.Count
                End If

                '----C: Topar a la cantidad de dias hábiles los dias que tiene registrado como asist
                Monto = totDias
                If Monto > totDiasHabiles Then Monto = totDiasHabiles

            End If

            Return Monto
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return 0
        End Try
    End Function

    Public Function bonos_cupon(rl As String, anoper As String) As Double
        Try
            Dim concepto As String = "BONDES"
            Dim monto As Double = 0
            Dim condiciones As String = "((HORAS_NORMALES <> '00:00' or HORAS_CONVENIO <> '00:00') or (tipo_aus in ('VAC', 'PSV')))"

            Dim dtAsist As DataTable = sqlExecute("select * from asist where reloj = '" & rl & "' and ano+periodo = '" & anoper & "' and " & condiciones, "ta")

            Dim dtEmpleado As DataTable = sqlExecute("select * from personal where reloj = '" & rl & "' ")

            Dim cod_tipo As String = RTrim(IIf(IsDBNull(dtEmpleado.Rows(0)("cod_tipo")), "", dtEmpleado.Rows(0)("cod_tipo")))
            Dim sactual As Double = IIf(IsDBNull(dtEmpleado.Rows(0)("sactual")), "0", dtEmpleado.Rows(0)("sactual"))

            If dtAsist.Rows.Count Then
                Dim dtConcepto As DataTable = sqlExecute("select * from conceptos where concepto = '" & concepto & "'", "NOMINA")
                If dtConcepto.Rows.Count Then

                    If cod_tipo = "O" Then
                        If Integer.Parse(anoper) >= 201710 Then
                            monto = dtConcepto.Rows(0)("misce_monto")
                        Else
                            monto = 180
                        End If

                    ElseIf cod_tipo = "A" Then
                        If Integer.Parse(anoper) >= 201716 Then
                            Dim factor As Double = 0.075
                            monto = Math.Round(sactual * 7 * factor, 2)
                            If monto < 210 Then
                                monto = 210
                            End If
                            If monto > 528.43 Then
                                monto = 528.43
                            End If
                        Else
                            monto = 180
                        End If

                    End If

                    ' 
                    Try
                        '200.00 más para empleados de horarios 45 y 46 que trabajan sabado o domingo
                        'Solicitud de Magda Belmont febrero 2017
                        If RTrim(dtEmpleado.Rows(0)("COD_HORA")) = "45" Then
                            Dim dtAsistSabaDomingo As DataTable = sqlExecute("select * from asist where reloj = '" & rl & "' and ano+periodo = '" & anoper & "' and dia_entro like '%sábado%' and ta.dbo.htod(horas_normales) > 0", "TA")
                            If dtAsistSabaDomingo.Rows.Count > 0 Then
                                monto += 200
                            End If
                        ElseIf RTrim(dtEmpleado.Rows(0)("COD_HORA")) = "46" Then
                            Dim dtAsistSabaDomingo As DataTable = sqlExecute("select * from asist where reloj = '" & rl & "' and ano+periodo = '" & anoper & "' and dia_entro like '%domingo%' and ta.dbo.htod(horas_normales) > 0", "TA")
                            If dtAsistSabaDomingo.Rows.Count > 0 Then
                                monto += 200
                            End If
                        End If
                    Catch ex As Exception

                    End Try

                    Return monto
                Else
                    Return 0
                End If
            Else
                Return 0
            End If

            Return 0
        Catch ex As Exception
            Return 0
        End Try        
    End Function

End Module
