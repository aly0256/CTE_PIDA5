'*************** PROCEDIMIENTOS Y FUNCIONES DE PIDA CONVERTIDOS DESDE VFP  ***************************

Module LibreriasVFP
    ''' <summary>
    ''' Función para convertir caracter en formato de fecha, regresando tipo String
    ''' </summary>
    ''' <param name="_hora"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CtoH(_hora As String) As String
        Dim _tamano As Integer, _pos As Integer
        Dim _horas As String, _minutos As String
        Try
            _tamano = _hora.Trim.Length
            _hora = _hora.Replace(".", ":")
            _pos = _hora.IndexOf(":")
            If _pos >= 0 Then
                _horas = _hora.Substring(0, _pos)
                _minutos = _hora.Substring(_pos + 1, _tamano - _horas.Length - 1)

            Else
                _minutos = 0
                _horas = _hora
            End If

            If Val(_horas) >= 24 Or Val(_minutos) >= 60 Then
                _hora = "**:**"
            Else
                _hora = _horas.Trim.PadLeft(2, "0") & ":" + _minutos.ToString.Trim.PadLeft(2, "0")

                _hora = MilitarMer(_hora)
            End If
            Return _hora
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return "**:**"
        End Try
    End Function

    Public Function MilitarMer(_hora As String) As String

        Dim _horas As Integer
        Dim _meridiano As String
        Try

            _horas = _hora.Substring(0, 2)
            If _horas >= 12 Then
                If _horas <> 12 Then
                    _horas = _horas - 12
                End If
                _meridiano = " PM"
            Else
                _meridiano = " AM"
            End If
            _hora = _horas.ToString.PadLeft(2, "0") & ":" + _hora.Substring(3, 2) + _meridiano
            If Not IsDate(_hora) Then
                _hora = "**:**"
            End If
            Return _hora

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return "**:**"
        End Try
    End Function

    Public Function MerMilitar(_hora As String) As String
        Dim _mer As String
        Try

            If _hora.Trim.Length > 5 Then
                _mer = _hora.Substring(_hora.Length - 2, 2).Trim
            ElseIf _hora.Trim.Length < 2 Then
                Return "00:00"
            Else
                _mer = _hora
            End If

            Dim _horas As String = IIf(_hora.Length > 3, _hora.Substring(0, 2).Trim, "")
            If _mer = "PM" Then
                If _horas < 12 Then
                    _horas = _horas + 12
                End If
            End If
            _hora = _horas.PadLeft(2, "0") & _hora.Substring(2, 3)
            If Not IsDate(_hora) Then
                _hora = "**:**"
            End If
            Return _hora
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return "**:**"
        End Try
    End Function

    Public Function CtoHSimple(_hora As String) As String
        Dim _tamano As Integer, _pos As Integer
        Dim _horas As String, _minutos As String
        Try
            If _hora.Contains("*") Then
                _hora = "**:**"
                Return _hora
            End If
            _tamano = _hora.Trim.Length
            _hora = _hora.Replace(".", ":")
            _pos = _hora.IndexOf(":")
            If _pos >= 0 Then
                _horas = _hora.Substring(0, _pos)
                _minutos = _hora.Substring(_pos + 1, _tamano - _horas.Length - 1)
            Else
                _minutos = "0"
                _horas = _hora
            End If
            _horas = CDbl(IIf(_horas = "", "0", _horas))
            _minutos = CDbl(IIf(_minutos = "", "0", _minutos))

            If _horas >= 24 Or _minutos >= 60 Then
                _hora = "**:**"
            ElseIf Not IsNumeric(_horas) Or Not IsNumeric(_minutos) Then
                _hora = "**:**"
            Else
                _hora = _horas.Trim.PadLeft(2, "0") & ":" & _minutos.Trim.PadLeft(2, "0")
            End If
            Return _hora

        Catch ex As Exception
            Return "**:**"
        End Try
    End Function

    Public Function CtoM(_hora As String) As String
        Dim _tamano As Integer, _pos As Integer
        Dim _horas As String, _minutos As String
        Try
            _tamano = _hora.Trim.Length
            _hora = _hora.Replace(".", ":")
            _pos = _hora.IndexOf(":")

            If _pos >= 0 Then
                _horas = _hora.Substring(0, _pos)
                _minutos = _hora.Substring(_pos + 1, _tamano - _horas.Length - 1)
            Else
                _minutos = Val(_hora)
                If _minutos > 60 Then
                    _horas = Int(_minutos / 60)
                    _minutos = _minutos Mod 60
                Else
                    _horas = "0"
                End If
            End If

            If Val(_horas) >= 24 Or Val(_minutos) >= 60 Then
                _hora = "**:**"
            Else
                _hora = _horas.Trim.PadLeft(2, "0") & ":" & _minutos.Trim.PadLeft(2, "0")
            End If
            Return _hora

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return "**:**"
        End Try
    End Function

    

    

   

    Public Function Antiguedad_Dias(fInicio As Date, fFin As Date)
        '*calculo de dias cotizados 
        Try
            Return DateDiff(DateInterval.Day, fInicio, fFin) + 1
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return -1
        End Try
    End Function


    

    

    Public Function FechaAniversario(_alta_emp As Date) As Date
        Try
            Dim _fecha_aniv As New Date(Now.Year, _alta_emp.Month, _alta_emp.Day)
            Return _fecha_aniv
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function AntiguedadExacta(fInicio As Date, fFin As Date) As String
        Dim _men As String = ""
        Dim anos_cot As Double
        Dim dias_cot As Integer
        Dim meses_cot As Double
        Dim anos_cump As Integer
        Dim meses_cump As Integer
        Dim dias_cump As Integer
        Try
            If fInicio > fFin Then
                _men = "La fecha de alta es mayor a hoy"
                Return _men
            End If

            '*calculo de dias cotizados 
            dias_cot = DateDiff(DateInterval.Day, fInicio, fFin)


            '*años cotizados
            anos_cot = dias_cot / 365.25
            '*años cuimplidos
            anos_cump = Int(anos_cot)
            If anos_cump <> 0 Then
                If anos_cump = 1 Then
                    _men = _men & anos_cump & " año "
                Else
                    _men = _men & anos_cump & " años "
                End If
            End If

            '*meses cotizados
            meses_cot = (anos_cot - Int(anos_cot)) * 365.25 / 30.4
            '*meses cumplidos
            meses_cump = Int(meses_cot)
            If meses_cump <> 0 Then
                If meses_cump = 1 Then
                    _men = _men & meses_cump & " mes "
                Else
                    _men = _men & meses_cump & " meses "
                End If
            End If


            '*dias cotizados
            dias_cot = (meses_cot - Int(meses_cot)) * 30.4
            '*dias cumplidos
            dias_cump = Int(dias_cot)
            If dias_cump <> 0 Then
                If dias_cump = 1 Then
                    _men = _men & dias_cump & " día"
                Else
                    _men = _men & dias_cump & " días"
                End If
            End If

            Return _men
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return "ERROR"
        End Try
    End Function

    Public Function RFCaFechaNac(RFC As String) As Date
        Dim d As Integer, m As Integer, y As Integer
        Dim a As Integer
        Try
            a = Today.Year
            If RFC.Length >= 10 Then
                y = RFC.Substring(4, 2)
                If y + 2000 > a Then
                    y = y + 1900
                Else
                    y = y + 2000
                End If
                m = RFC.Substring(6, 2)
                d = RFC.Substring(8, 2)
                Dim FNac As New Date(y, m, d)
                Return FNac
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function DigitoVerificador(IMSS As String) As String
        Dim Cadena As String = ""
        Dim Bandera As Boolean = True
        Dim Num As Integer = 0
        Dim Suma As Integer = 0
        Dim Car As String
        Dim Dv As String
        Try
            If IMSS.Length < 10 Then
                Return "*"
            End If

            For x = 0 To 9
                If Bandera Then
                    Num = Val(IMSS.Substring(x, 1)) * 1
                Else
                    Num = Val(IMSS.Substring(x, 1)) * 2
                End If
                Cadena = Cadena + Num.ToString.PadLeft(2, "0")
                Bandera = Not Bandera
            Next x
            For x = 0 To Len(Cadena) - 1
                Suma = Suma + Val(Cadena.Substring(x, 1))
            Next x
            Car = Suma.ToString.Substring(0, 1)
            Dv = ((Val(Car) + 1) * 10) - Suma
            If Dv = 10 Then
                Dv = 0
            End If

            Return Dv
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return "*"
        End Try
    End Function

    Public Function FactorIntegracion(CodComp As String, CodTipo As String, Anos As Integer) As Decimal
        Dim Integrado As Double = 1
        Dim Calcular As Boolean = True
        Dim DiasVac As Integer
        Dim DiasAgui As Integer
        Dim DiasAguiAd As Integer
        Dim PrimaVac As Double
        Dim dtInt As New DataTable

        Try
            dtInt = sqlExecute("SELECT factores FROM cias WHERE cod_comp = '" & CodComp & "'")
            If dtInt.Rows.Count = 0 Then
                Calcular = True
            Else
                Calcular = IIf(IsDBNull(dtInt.Rows.Item(0).Item("factores")), 0, dtInt.Rows.Item(0).Item("factores"))
            End If

            '--AOS : 2021-02-09 Calcular los años correctos
            Anos = CInt(Math.Round(Anos / 365, 2))

            If Not Calcular Then
                Anos = Anos + 1
                dtInt = sqlExecute("SELECT factor_int FROM factores WHERE cod_comp = '" & CodComp & "' AND cod_tipo = '" & CodTipo & "' AND anos = " & Anos)
                If dtInt.Rows.Count > 0 Then
                    Integrado = dtInt.Rows.Item(0).Item("factor_int")
                Else
                    dtInt = sqlExecute("SELECT MAX(factor_int) AS factor_int FROM factores WHERE cod_comp = '" & CodComp & "' AND cod_tipo = '" & CodTipo & "'")
                    If dtInt.Rows.Count > 0 Then
                        Integrado = IIf(IsDBNull(dtInt.Rows.Item(0).Item("factor_int")), 0, dtInt.Rows.Item(0).Item("factor_int"))
                    End If

                End If
            Else
                dtInt = sqlExecute("SELECT * FROM vacaciones WHERE cod_comp = '" & CodComp & "' AND cod_tipo = '" & CodTipo & "' AND anos = " & Anos)
                If dtInt.Rows.Count > 0 Then
                    DiasVac = dtInt.Rows.Item(0).Item("dias")
                    PrimaVac = dtInt.Rows.Item(0).Item("por_prima")
                    dtInt = sqlExecute("SELECT * FROM agui WHERE cod_comp = '" & CodComp & "' AND cod_tipo = '" & CodTipo & "' AND anos = " & Anos)
                    DiasAgui = dtInt.Rows.Item(0).Item("dias")
                    DiasAguiAd = IIf(IsDBNull(dtInt.Rows.Item(0).Item("dias_ad")), 0, dtInt.Rows.Item(0).Item("dias_ad"))

                    Integrado = (365 + DiasAgui + DiasAguiAd + (DiasVac) * (PrimaVac) / 100) / 365
                End If

            End If

            Return Integrado
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "LibreriasVFP", ex.hResult, ex.Message)
            Return -1
        End Try

    End Function

    Public Function UltimoDiaBimestre(ByVal Fecha As Date) As Date
        Dim m As Integer
        Dim ld As Date

        Try
            m = Month(Fecha)
            If m Mod 2 = 0 Then
                ld = New DateTime(Fecha.Year, Fecha.Month, 1).AddMonths(1).AddDays(-1)
            Else
                ld = New DateTime(Fecha.Year, Fecha.Month, 1).AddMonths(2).AddDays(-1)
            End If
            Return ld
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "LibreriasVFP", ex.hResult, ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function NumDia(Fecha As Date, Optional IniciaLunes As Boolean = True) As Integer
        Try
            Dim N As Integer
            N = Fecha.DayOfWeek
            If Not IniciaLunes Then
                N = N - 1
                If N = 1 Then
                    N = 7
                End If
            End If
            Return N
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return -1
        End Try
    End Function

    Public Function DiaSemInt(Fecha As Date) As Integer
        Dim D As Integer
        Dim Dia As Integer
        Try
            Dia = Fecha.DayOfWeek
            Select Case Dia
                Case DayOfWeek.Monday
                    D = 1
                Case DayOfWeek.Tuesday
                    D = 2
                Case DayOfWeek.Wednesday
                    D = 3
                Case DayOfWeek.Thursday
                    D = 4
                Case DayOfWeek.Friday
                    D = 5
                Case DayOfWeek.Saturday
                    D = 6
                Case DayOfWeek.Sunday
                    D = 7
                Case Else
                    D = -1
            End Select
            Return D
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return "Error"
        End Try
    End Function

    Public Function DiaSem(Fecha As Date) As String
        Dim D As String
        Dim Dia As Integer
        Try
            Dia = Fecha.DayOfWeek
            Select Case Dia
                Case DayOfWeek.Monday
                    D = "Lunes"
                Case DayOfWeek.Tuesday
                    D = "Martes"
                Case DayOfWeek.Wednesday
                    D = "Miércoles"
                Case DayOfWeek.Thursday
                    D = "Jueves"
                Case DayOfWeek.Friday
                    D = "Viernes"
                Case DayOfWeek.Saturday
                    D = "Sábado"
                Case DayOfWeek.Sunday
                    D = "Domingo"
                Case Else
                    D = "Error"
            End Select
            Return D
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return "Error"
        End Try
    End Function

    '==Funcion festivos original (comentada backup)             23sep2021

    'Public Function Festivo(_fecha As Date, Optional Reloj As String = "") As Boolean
    '    Dim EsFestivo As Boolean = False
    '    Dim Filtro As String
    '    Dim _aus_festivo As String = ""
    '    Dim dtFestivo As New DataTable
    '    Try
    '        'Determinar el tipo de ausentismo para día festivo 
    '        dtFestivo = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE UPPER(nombre) LIKE '%FESTIVO%'", "TA")
    '        If dtFestivo.Rows.Count > 0 Then
    '            _aus_festivo = IIf(IsDBNull(dtFestivo.Rows(0).Item("tipo_aus")), "FES", dtFestivo.Rows(0).Item("tipo_aus"))
    '        End If

    '        dtTemporal = sqlExecute("SELECT * FROM festivos WHERE festivo = '" & FechaSQL(_fecha) & "'", "TA")
    '        'Si no encontró la fecha entre los festivos, buscar en ausentismo del empleado
    '        If dtTemporal.Rows.Count > 0 Then
    '            If Reloj = "" Then
    '                EsFestivo = True
    '            Else
    '                If DiaDescanso(_fecha, Reloj) Then
    '                    'Si es día de descanso, no es festivo
    '                    EsFestivo = False
    '                Else
    '                    'Si se encontró la fecha entre los festivos, revisar si 
    '                    Filtro = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("filtro")), "", dtTemporal.Rows(0).Item("filtro"))
    '                    If Filtro.Length = 0 Then
    '                        EsFestivo = True
    '                    Else
    '                        'Buscar si empleado cumple la condición indicada en el festivo
    '                        dtTemporal = sqlExecute("SELECT reloj from personalvw WHERE reloj = '" & Reloj & "' AND " & Filtro)
    '                        If dtTemporal.Rows.Count > 0 Then
    '                            EsFestivo = True
    '                        Else
    '                            'Buscar en tabla de ausentismo, si no está registrado como festivo ese día para ese empleado
    '                            dtTemporal = sqlExecute("SELECT reloj FROM ausentismo WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(_fecha) & _
    '                                                    "' AND tipo_aus = '" & _aus_festivo & "'", "TA")
    '                            If dtTemporal.Rows.Count > 0 Then
    '                                EsFestivo = True
    '                            End If
    '                        End If
    '                    End If
    '                End If

    '            End If
    '        ElseIf Reloj.Length > 0 Then
    '            'Buscar en tabla de ausentismo, si no está registrado como festivo ese día para ese empleado
    '            'MCR 2/DIC/2015
    '            'Corrección: agregar número de reloj en la búsqueda
    '            dtTemporal = sqlExecute("SELECT reloj FROM ausentismo WHERE reloj = '" & Reloj & "' and tipo_aus = '" & _aus_festivo & _
    '                                    "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
    '            If dtTemporal.Rows.Count > 0 Then
    '                EsFestivo = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
    '        EsFestivo = False
    '    End Try
    '    Return EsFestivo

    'End Function

    '==Modificada para tomar en cuenta bien el filtro de festivos               23sep2021

    '== Modificacion a la funcion festivos                  23sep2021

    '==Modificado 17nov2021
    Public Function Festivo(_fecha As Date, Optional Reloj As String = "") As Boolean
        Dim EsFestivo As Boolean = False
        Dim Filtro As String
        Dim _aus_festivo As String = ""
        Dim dtFestivo As New DataTable
        Dim valorColQuery As String = ""
        Dim f_FinPer As Date = Nothing
        Dim HorPerEmp As String = ""

        Dim dtTempFest As New DataTable

        Try
            'Determinar el tipo de ausentismo para día festivo 
            dtFestivo = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE UPPER(nombre) LIKE '%FESTIVO%'", "TA")
            If dtFestivo.Rows.Count > 0 Then
                _aus_festivo = IIf(IsDBNull(dtFestivo.Rows(0).Item("tipo_aus")), "FES", dtFestivo.Rows(0).Item("tipo_aus"))
            End If

            dtTempFest = sqlExecute("SELECT * FROM festivos WHERE festivo = '" & FechaSQL(_fecha) & "'", "TA")
            'Si no encontró la fecha entre los festivos, buscar en ausentismo del empleado
            If dtTempFest.Rows.Count > 0 Then
                If Reloj = "" Then
                    EsFestivo = True
                Else
                    If DiaDescanso(_fecha, Reloj) Then
                        'Si es día de descanso, no es festivo
                        EsFestivo = False
                    Else
                        'Si se encontró la fecha entre los festivos, revisar si 
                        Filtro = IIf(IsDBNull(dtTempFest.Rows.Item(0).Item("filtro")), "", dtTempFest.Rows(0).Item("filtro"))
                        If Filtro.Length = 0 Then
                            EsFestivo = True
                        Else
                            '====================CAMBIOS COMIENZAN AQUI           22SEP2021
                            '== Se borra cualquier registro de ausentismo de día festivo (mas adelante se agregará si es correcto)
                            'If bandera Then
                            '    Dim QBorrarFestivo As String = "DELETE FROM TA.DBO.ausentismo WHERE RELOJ='" & Reloj &
                            '                                                   "' AND FECHA='" & FechaSQL(_fecha) & "' and TIPO_AUS='FES'"
                            '    sqlExecute(QBorrarFestivo)
                            'End If

                            '== Buscar si empleado cumple la condición indicada en el festivo
                            dtTempFest = sqlExecute("SELECT * from personalvw WHERE reloj = '" & Reloj & "'")

                            '== Periodo de la fecha
                            Dim dtPeriodoFin As DataTable = sqlExecute("select ano,periodo,FECHA_INI,FECHA_FIN from ta.dbo.periodos " & _
                                                                                                            "where '" & FechaSQL(_fecha) & "' >= FECHA_INI and '" & FechaSQL(_fecha) & "' <= FECHA_FIN " & _
                                                                                                             "and PERIODO_ESPECIAL ='0'")

                            Try : f_FinPer = IIf(IsDBNull(dtPeriodoFin.Rows(0)("fecha_fin")), Nothing, dtPeriodoFin.Rows(0)("fecha_fin")) : Catch ex As Exception : f_FinPer = Nothing : End Try

                            '== Horarios en personal y bitácora
                            Dim dtBitacoraHorario As DataTable = sqlExecute("SELECT RELOJ,COD_HORA as HorarioActual,(SELECT VALORANTERIOR FROM PERSONAL.dbo.bitacora_personal " & _
                                                                                                                    "WHERE reloj = '" & Reloj & "' AND FECHA = (SELECT MIN(FECHA) AS FECHA FROM dbo.bitacora_personal AS BITACORA " & _
                                                                                                                    "WHERE CAST(fecha AS DATE) > '" & FechaSQL(f_FinPer) & "' AND campo = bitacora_personal.campo and reloj= bitacora_personal.reloj) " & _
                                                                                                                    "AND tipo_movimiento = 'C' AND campo='cod_hora') as cod_hora " & _
                                                                                                                    "FROM PERSONAL.dbo.personal where RELOJ='" & Reloj & "'")

                            '== Valor default a la columna que se revisará con el filtro
                            valorColQuery = "[cod_hora]"

                            '== Si tiene un horario correcto
                            If dtTempFest.Rows.Count > 0 Then

                                '== Horario que tiene en tabla personal             22sep2021
                                HorPerEmp = dtTempFest.Rows(0)("cod_hora").ToString.Trim
                                '== Horario que se tenga en bitácora (si es que hay)            22sep2021
                                Try : HorBitEmp = IIf(IsDBNull(dtBitacoraHorario.Rows(0)("cod_hora")), "", dtBitacoraHorario.Rows(0)("cod_hora").ToString.Trim) : Catch ex As Exception : HorBitEmp = "" : End Try

                                If HorPerEmp = HorBitEmp Then
                                    For Each x As DataRow In dtTempFest.Select(Filtro)
                                        EsFestivo = True
                                    Next
                                Else
                                    '==Si son distintos, busca en el filtro para ver cual es festivo y cual no. Si no hay cambios en bitácora, entonces tomar en cuenta el horario de personal
                                    If HorBitEmp = "" Then
                                        Filtro = Replace(Filtro, "cod_hora", "HorarioActual")
                                        valorColQuery = "[HorarioActual]"
                                    End If

                                    If Filtro.Contains(valorColQuery) Then
                                        Dim parametros_filtro() As String = Split(Filtro.ToString.Trim, " and ")
                                        Dim cont As Integer = 0

                                        For i As Integer = 0 To parametros_filtro.Length - 1
                                            If parametros_filtro(i).Contains(valorColQuery) Then
                                                '== La posicion del filtro correcto
                                                cont = i
                                            End If
                                        Next

                                        For Each x As DataRow In dtBitacoraHorario.Select(parametros_filtro(cont))
                                            EsFestivo = True
                                        Next
                                    Else
                                        EsFestivo = True
                                        'Buscar en tabla de ausentismo, si no está registrado como festivo ese día para ese empleado
                                        'dtTemporal = sqlExecute("SELECT reloj FROM ausentismo WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(_fecha) & _
                                        '                        "' AND tipo_aus = '" & _aus_festivo & "'", "TA")
                                        'If dtTemporal.Rows.Count > 0 Then
                                        '    EsFestivo = True
                                        'End If
                                    End If
                                End If
                            End If

                        End If
                    End If

                End If
            ElseIf Reloj.Length > 0 Then
                'Buscar en tabla de ausentismo, si no está registrado como festivo ese día para ese empleado
                'MCR 2/DIC/2015
                'Corrección: agregar número de reloj en la búsqueda
                dtTempFest = sqlExecute("SELECT reloj FROM ausentismo WHERE reloj = '" & Reloj & "' and tipo_aus = '" & _aus_festivo & _
                                        "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                If dtTempFest.Rows.Count > 0 Then
                    EsFestivo = True
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            EsFestivo = False
        End Try
        Return EsFestivo

    End Function

    ''' <summary>
    ''' Determinar la diferencia en horas, entre 2 horas dadas en formato string
    ''' </summary>
    Public Function RestaHrs(HoraIni As String, HoraFin As String, Optional cafeteria As Boolean = False) As String
        Try
            Dim _tiempo As String = "**.**"
            Dim _positivo As Boolean = True
            Dim _segundos As Integer
            Dim _horas As Decimal
            Dim _frac_horas As String
            Dim _minutos As String

            _segundos = DateDiff(DateInterval.Second, Convert.ToDateTime(HoraIni), Convert.ToDateTime(HoraFin))
            If _segundos < 0 Then
                _positivo = False
                _segundos = Math.Abs(_segundos)
            End If
            _horas = _segundos / 3600
            If _horas > 12 And Not cafeteria Then
                _horas = 24 - _horas
            End If

            If _horas <= 99 Then
                _frac_horas = _horas - Int(_horas)
                _minutos = Math.Round((_horas - Int(_horas)) * 60, 0)
                _tiempo = Int(_horas).ToString.PadLeft(2, "0") & ":" & Int(_minutos).ToString.PadLeft(2, "0")
            End If

            If Not _positivo Then _tiempo = "-" + _tiempo
            Return _tiempo
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return "**:**"
        End Try
    End Function

    ''' <summary>
    ''' Función que devuelve el tiempo transcurrido en horas, considerando fecha y hora
    ''' Las fechas son en formato Date, las horas en formato String. Devuelve un String con formato de hora
    ''' </summary>

    Public Function RestaHrs(FechaIni As Date, HoraIni As String, FechaFin As Date, HoraFin As String) As String
        Dim EntradaCompleta As Date
        Dim SalidaCompleta As Date
        Dim Horas As Double
        Try
            EntradaCompleta = DateAdd(DateInterval.Second, HtoD(MerMilitar(HoraIni)) * 3600 + 1, FechaIni)
            SalidaCompleta = DateAdd(DateInterval.Second, HtoD(MerMilitar(HoraFin)) * 3600, FechaFin)

            'Calcula la diferencia en segundos, luego lo convierte a horas, redondeando a 2 decimales
            Horas = Math.Round(DateDiff(DateInterval.Second, EntradaCompleta, SalidaCompleta) / 3600, 2)
            'Antes de devolver el resultado, lo convierte a formato de hora en String
            Return DtoH(Horas)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return "**:**"
        End Try

    End Function

    ''' <summary>
    ''' Determina cuántos segundos hay en la hora indicada
    ''' </summary>
    ''' <param name="Hora"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function HtoS(Hora As String) As Integer
        Try
            Dim _negativo As Boolean = False
            Dim _segundos As Integer = 0
            Dim H As String
            Dim M As String
            If Hora.Substring(0, 1) = "-" Then
                Hora = Hora.Replace("-", "")
                _negativo = True
            End If

            If Hora.Length > 0 Then
                Hora = Hora.PadLeft(5, "0")
                H = Hora.Substring(0, 2)
                M = Hora.Substring(3, 2)

                _segundos = (H * 3600) + (M * 60)
                If _negativo Then _segundos = -_segundos
            End If
            Return _segundos
        Catch ex As Exception
            Return 0
        End Try
    End Function
    ''' <summary>
    '''  Convertir un hora en formato caracter a formato decimal
    ''' </summary>
    Public Function HtoD(Hora As String) As Double
        Try
            Dim H As Integer
            Dim M As Integer
            Dim _negativo As Boolean = False
            'En caso de que no ocupe 5 espacios, forzarlo
            If Left(Hora, 1) = "-" Then
                _negativo = True
                Hora = Hora.Replace("-", "")
            End If
            Hora = Hora.PadLeft(5, "0")
            H = Val(Hora.Substring(0, 3))
            M = Val(Hora.Substring(3, Hora.Length - 3))
            Return Math.Round((H + (M / 60)), 2) * IIf(_negativo, -1, 1)
        Catch ex As Exception
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Convertir una hora en formato decimal a formato caracter
    ''' </summary>
    Public Function DtoH(Hora As Double) As String
        Try
            Dim H As Integer
            Dim M As Integer

            H = Int(Math.Abs(Hora))
            M = (Math.Abs(Hora) - Int(Math.Abs(Hora))) * 60
            If M = 60 Then
                M = 0
                H = H + 1
            End If
            Return IIf(Hora < 0, "-", "") & H.ToString.PadLeft(2, "0") & ":" & M.ToString.PadLeft(2, "0")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function TotalPercepciones(ByVal Reloj As String, ByVal AnoPeriodo As String) As Double
        Dim Total As Double = 0
        Try
            dtTemporal = sqlExecute("SELECT SUM(MONTO) AS TOTAL FROM MOVIMIENTOS LEFT JOIN CONCEPTOS ON movimientos.concepto = conceptos.concepto " & _
                                    "WHERE RTRIM(CONCEPTOS.COD_NATURALEZA) = 'P' AND CONCEPTOS.SUMA_NETO = 1 AND positivo = 1 AND movimientos.reloj = '0" & _
                                    Reloj & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'", "Nomina")
            Total = dtTemporal.Rows(0).Item("total")
            Return Total
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function TotalDeducciones(ByVal Reloj As String, ByVal AnoPeriodo As String) As Double
        Dim Total As Double = 0
        Try
            dtTemporal = sqlExecute("SELECT SUM(MONTO) AS TOTAL FROM MOVIMIENTOS LEFT JOIN CONCEPTOS ON movimientos.concepto = conceptos.concepto " & _
                         "WHERE RTRIM(CONCEPTOS.COD_NATURALEZA) = 'D' AND CONCEPTOS.SUMA_NETO = 1 AND positivo = 0 AND movimientos.reloj = '0" & _
                         Reloj & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'", "Nomina")

            Total = dtTemporal.Rows(0).Item("total")
            Return Total
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function TotalPercepcionesRECIB(ByVal Reloj As String, ByVal AnoPeriodo As String) As Double
        Dim Total As Double = 0
        Try
            dtTemporal = sqlExecute("SELECT SUM(MONTO) AS TOTAL FROM MOVIMIENTOS LEFT JOIN CONCEPTOS ON movimientos.concepto = conceptos.concepto " & _
                                    "WHERE RTRIM(CONCEPTOS.COD_NATURALEZA) = 'P' AND CONCEPTOS.SUMA_NETO = 1 AND positivo = 1 AND movimientos.reloj = '" & _
                                    Reloj & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'", "KIOSCO")
            Total = dtTemporal.Rows(0).Item("total")
            Return Total
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function TotalDeduccionesRECIB(ByVal Reloj As String, ByVal AnoPeriodo As String) As Double
        Dim Total As Double = 0
        Try
            dtTemporal = sqlExecute("SELECT SUM(MONTO) AS TOTAL FROM MOVIMIENTOS LEFT JOIN CONCEPTOS ON movimientos.concepto = conceptos.concepto " & _
                         "WHERE RTRIM(CONCEPTOS.COD_NATURALEZA) = 'D' AND CONCEPTOS.SUMA_NETO = 1 AND positivo = 0 AND movimientos.reloj = '" & _
                         Reloj & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'", "KIOSCO")

            Total = dtTemporal.Rows(0).Item("total")
            Return Total
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function AddZeros(ByVal CantTotal As Integer, ByVal CantFinal As Integer) As String
        Try
            Dim Resta As Integer = CantTotal - CantFinal
            If Resta > 0 Then
                Select Case Resta
                    Case 1
                        Return "0"
                    Case 2
                        Return "00"
                    Case 3
                        Return "000"
                    Case 4
                        Return "0000"
                    Case 5
                        Return "00000"
                    Case 6
                        Return "000000"
                    Case 7
                        Return "0000000"
                    Case 8
                        Return "00000000"
                    Case 9
                        Return "000000000"
                    Case 10
                        Return "0000000000"
                    Case Else
                        Return ""
                End Select
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function ObtFecSabado(ByVal F1Inc As String, ByVal F2Inc As String) As String
        Dim strSab As String = ""
        Try
            If (F1Inc.Trim <> "" And F2Inc.Trim <> "") Then
                Dim FInic As Date = Convert.ToDateTime(F1Inc.Trim)
                Dim FFin As Date = Convert.ToDateTime(F2Inc.Trim)
                Dim NumDia As Integer = 0
                While FInic <= FFin
                    NumDia = FInic.DayOfWeek
                    If (NumDia = 6) Then
                        strSab = strSab & "'" & FechaSQL(Convert.ToString(FInic)) & "',"
                    End If
                    FInic = FInic.AddDays(1)
                End While

                strSab = strSab.TrimStart(",")
                strSab = strSab.TrimEnd(",")
            End If
            Return strSab
        Catch ex As Exception
            Return strSab
        End Try
    End Function

    Public Function ObtFecDomingo(ByVal F1Inc As String, ByVal F2Inc As String) As String
        Dim strDom As String = ""
        Try
            If (F1Inc.Trim <> "" And F2Inc.Trim <> "") Then
                Dim FInic As Date = Convert.ToDateTime(F1Inc.Trim)
                Dim FFin As Date = Convert.ToDateTime(F2Inc.Trim)
                Dim NumDia As Integer = 0
                While FInic <= FFin
                    NumDia = FInic.DayOfWeek
                    If (NumDia = 0) Then
                        strDom = strDom & "'" & FechaSQL(Convert.ToString(FInic)) & "',"
                    End If
                    FInic = FInic.AddDays(1)
                End While

                strDom = strDom.TrimStart(",")
                strDom = strDom.TrimEnd(",")
            End If
            Return strDom
        Catch ex As Exception
            Return strDom
        End Try
    End Function

    Public Function CalculoDAgDVacDPrVac(fAlta As Date, fBaja As Date, TipoEmp As String, CodComp As String, parameter As Integer) As Double
        Dim dtVac As New DataTable
        Dim dtAgui As New DataTable
        Dim _anos As Integer
        Dim Resultado As Double = 0.0
        Try
            Dim _primeroEnero As New Date(Now.Year, 1, 1)
            Dim _FAgui As New Date(Now.Year, 1, 1) ' Fecha para aguinaldo, x Default va a ser el el 01 de Enero del anio actual
            Dim _aniv As New Date(Now.Year, fAlta.Month, fAlta.Day)
            Dim _aniv_Ant As New Date(Now.Year - 1, fAlta.Month, fAlta.Day) ' Aniv del anio anterior si aplica
            Dim _dias As Double, _prima As Double, _diasAgui As Double
            Dim AntigDias As Double = 0.0
            Dim AntidDiasAgui As Double = 0.0

            '--Calcular días de antig para vacs y prima vac
            If (_aniv > fBaja) Then              ' Si aun no es su aniversario (Fecha de baja < Aniv Anio Actual)
                _primeroEnero = _aniv_Ant
                AntigDias = Antiguedad_Dias(_aniv_Ant, fBaja)
            Else                                 ' Si ya cumplieron el aniversario
                _primeroEnero = _aniv
                AntigDias = Antiguedad_Dias(_aniv, fBaja)
            End If

            '--Calcular días de antig para Aguinaldo
            If (fAlta >= _FAgui) Then _FAgui = fAlta ' Solo si el alta es mayor al 01/01/anio actual, sacar proporcional de dias del alta a la fecha
            AntidDiasAgui = Antiguedad_Dias(_FAgui, fBaja)


            Dim dias_vac As Double = 0.0
            Dim dias_prima_vac As Double = 0.0
            Dim dias_agui As Double = 0.0

            _anos = AntiguedadVac(fAlta, fBaja)


            dtVac = sqlExecute("SELECT * FROM vacaciones WHERE cod_comp = '" & CodComp & "' AND cod_tipo = '" & TipoEmp & "' AND anos = " & _anos + 1, "PERSONAL")
            dtAgui = sqlExecute("SELECT * FROM agui WHERE cod_comp = '" & CodComp & "' AND cod_tipo = '" & TipoEmp & "' AND anos = " & _anos + 1, "PERSONAL")

            If dtVac.Rows.Count > 0 Then
                _dias = dtVac.Rows.Item(0).Item("dias")
                _prima = dtVac.Rows.Item(0).Item("por_prima")
            Else
                _dias = 0
                _prima = 0
            End If

            If dtAgui.Rows.Count > 0 Then
                _diasAgui = dtAgui.Rows.Item(0).Item("dias")
            Else
                _diasAgui = 0
            End If

            dias_vac = Math.Round((_dias * AntigDias) / 365.25, 2)
            '  dias_prima_vac = Math.Round(((_dias * AntigDias) / 365.25) * (_prima / 100), 2) ' Aqui saca el % de la prima (por lo regular es el 25%)
            dias_prima_vac = Math.Round((_dias * AntigDias) / 365.25, 2) ' Lo manda sin el % prima, como lo requieren en el 400
            dias_agui = Math.Round((AntidDiasAgui / 365.25) * _diasAgui, 2)

            Select Case parameter
                Case 1
                    Resultado = dias_vac
                Case 2
                    Resultado = dias_prima_vac
                Case 3
                    Resultado = dias_agui
            End Select

            Return Resultado
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return Resultado = -1
        End Try
    End Function

    Public Function ProporcionVacaciones(fAlta As Date, fBaja As Date, TipoEmp As String, CodComp As String) As Double

        Dim dtVac As New DataTable
        Dim _anos As Integer
        Dim Resultado As Double = 0.0
        Try
            Dim _aniv As New Date(Now.Year, fAlta.Month, fAlta.Day)
            Dim _aniv_Ant As New Date(Now.Year - 1, fAlta.Month, fAlta.Day) ' Aniv del anio anterior si aplica
            Dim AntigDias As Double = 0.0
            Dim dias_vac As Double = 0.0
            Dim _dias As Double = 0.0

            If (_aniv > fBaja) Then
                AntigDias = Antiguedad_Dias(_aniv_Ant, fBaja)
            Else
                AntigDias = Antiguedad_Dias(_aniv, fBaja)
            End If

            '----Validar si el año actual es Bisiesto
            Dim dias_anio As Integer = 365
            Dim anio_bisiesto As Boolean = False
            Dim _anioActualInt As Integer = Convert.ToInt32(_aniv.Year.ToString.Substring(2, 2))
            Dim ResiduoAniv As Integer = _anioActualInt Mod 4
            If ResiduoAniv = 0 Then anio_bisiesto = True
            If anio_bisiesto Then dias_anio = 366

            '----- AO 2023-07-31: Validar que no sobrepase mas de 365 o 366(si es bisiesto) dias ya que seria el nuevo aniversario
            If (AntigDias > dias_anio) Then AntigDias = AntigDias - dias_anio

            _anos = AntiguedadVac(fAlta, fBaja)

            dtVac = sqlExecute("SELECT * FROM vacaciones WHERE cod_comp = '" & CodComp & "' AND cod_tipo = '" & TipoEmp & "' AND anos = " & _anos + 1, "PERSONAL")

            If dtVac.Rows.Count > 0 Then
                _dias = dtVac.Rows.Item(0).Item("dias")
            End If

            dias_vac = Math.Round((_dias * AntigDias) / dias_anio, 2)

            Resultado = Math.Round(dias_vac, 2)
            Return Resultado

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return Resultado
        End Try

    End Function


    Public Function AntiguedadVac(fInicio As Date, fFin As Date) As Integer
        Dim dias_cot As Integer, anos_cump As Integer
        Dim anos_cot As Double
        Dim difAnios As Double = 0.0
        Try
            '*calculo de dias cotizados 
            If fFin.Year = "2024" Or fFin.Year = "2028" Or fFin.Year = "2032" Or fFin.Year = "2036" Or fFin.Year = "2040" Or fFin.Year = "2044" Or fFin.Year = "2048" Or fFin.Year = "2052" Or fFin.Year = "2056" Or fFin.Year = "2060" Or fFin.Year = "2064" Then ' porque son bisiestos
                dias_cot = DateDiff(DateInterval.Day, fInicio, fFin) - 1
            Else
                dias_cot = DateDiff(DateInterval.Day, fInicio, fFin)
            End If

            difAnios = DateDiff(DateInterval.Year, fInicio, fFin)
            '
            '*años cotizados
            anos_cot = dias_cot / 365.25

            '*años cumplidos
            anos_cump = Int(anos_cot)

            Return anos_cump
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return -1
        End Try
    End Function

    Public Function AntiguedadDbl(fInicio As Date, fFin As Date) As Double
        Dim dias_cot As Integer
        Dim anos_cot As Double
        '*calculo de dias cotizados 
        Try
            dias_cot = DateDiff(DateInterval.Day, fInicio, fFin) + 1

            '*años cotizados
            anos_cot = dias_cot / 365.25

            Return anos_cot
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return -1
        End Try
    End Function

    Public Function Antiguedad(fInicio As Date, fFin As Date) As Double
        '*calculo de dias cotizados 
        Try
            Return DateDiff(DateInterval.Day, fInicio, fFin)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return -1
        End Try
    End Function

    Public Function ProporcionAguinaldo(fAlta As Date, fBaja As Date, TipoEmp As String, CodComp As String)
        Dim _anos As Integer
        Dim _ant_completa As Double
        Dim _primero As New Date(fBaja.Year, 1, 1)
        Dim _aniv As New Date(fBaja.Year, fAlta.Month, fAlta.Day)
        Dim dtAgui As New DataTable
        Dim _corresponden As Double
        Try


            Dim _fecha_calculo As Date = fBaja
            If _aniv <> fAlta Then
                _ant_completa = Antiguedad_Dias(_primero, _aniv)
                _anos = Antiguedad(fAlta, _aniv.AddDays(-15))
                _corresponden = (_dias_agui(CodComp, TipoEmp, _anos) * _ant_completa) / 365

                _ant_completa = Antiguedad_Dias(_aniv, fBaja.AddDays(1))
                _anos = Antiguedad(fAlta, fBaja)
                Dim _corresponden2 As Double = (_dias_agui(CodComp, TipoEmp, _anos) * _ant_completa) / 365
                _corresponden += _corresponden2

            Else
                _ant_completa = Antiguedad_Dias(fAlta, fBaja)
                _anos = Antiguedad(fAlta, fBaja)
                _corresponden = (_dias_agui(CodComp, TipoEmp, _anos) * _ant_completa) / 365
            End If

            _corresponden = Math.Round(_corresponden, 2)
            Return _corresponden
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return -1
        End Try
    End Function

    Public Function _dias_agui(CodComp As String, tipoemp As String, _anos As Integer)
        Try
            Dim dtAgui As DataTable = sqlExecute("SELECT * FROM agui WHERE cod_comp = '" & CodComp & "' AND cod_tipo = '" & tipoemp & "' AND anos = " & _anos + 1)
            If dtAgui.Rows.Count > 0 Then
                Return dtAgui.Rows.Item(0).Item("dias")
            Else
                Return 15
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return -1
        End Try
    End Function

    Public Function Antiguedad_Dias_Proy(fInicio As Date, fFin As Date)
        '*calculo de dias cotizados 
        Try
            Dim dias As Integer = DateDiff(DateInterval.Day, fInicio, fFin)
            If fFin.Year = "2024" Or fFin.Year = "2028" Or fFin.Year = "2032" Or fFin.Year = "2036" Or fFin.Year = "2040" Or fFin.Year = "2044" Or fFin.Year = "2048" Or fFin.Year = "2052" Or fFin.Year = "2056" Or fFin.Year = "2060" Or fFin.Year = "2064" Then ' porque son bisiestos
                If dias = 0 Then ' si los dias son 0, es que la finicio y fin  son iguales
                    Return dias
                Else
                    Return dias - 1
                End If
            Else
                Return dias
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return -1
        End Try
    End Function

    Public Function ProporcionVacas2(fAlta As Date, fBaja As Date, TipoEmp As String, CodComp As String, fhoy As Date) As Double ' Ant Funci

        '----Anterior Funcion original
        Dim dtVac As New DataTable
        Dim _anos As Integer
        Dim Resultado As Double = 0.0
        Try
            Dim _aniv As New Date(fBaja.Year, fAlta.Month, fAlta.Day)
            Dim _aniv_Ant As New Date(fBaja.Year - 1, fAlta.Month, fAlta.Day) ' Aniv del anio anterior si aplica
            Dim AntigDias As Double = 0.0
            Dim dias_vac As Double = 0.0
            Dim _dias As Double = 0.0

            'If (_aniv > fBaja) Then
            '    AntigDias = Antiguedad_Dias_Proy(_aniv_Ant, fBaja)
            'Else
            '    AntigDias = Antiguedad_Dias_Proy(_aniv, fBaja)
            'End If

            AntigDias = Antiguedad_Dias_Proy(fhoy, fBaja) ' calcular los dias del dia la consulta al dia de proyección

            '----- AO 2023-07-31: Validar que no sobrepase mas de 365 dias ya que seria el nuevo aniversario
            '-----NOTA: Solo se puede consultar hasta antes de su 1er  y prox aniv, ya que de lo contrario, los dias los va a reducir a 365 dias o menos
            If (AntigDias >= 365) Then AntigDias = AntigDias - 365

            _anos = AntiguedadVac(fAlta, fBaja)

            dtVac = sqlExecute("SELECT * FROM vacaciones WHERE cod_comp = '" & CodComp & "' AND cod_tipo = '" & TipoEmp & "' AND anos = " & _anos + 1, "PERSONAL")

            If dtVac.Rows.Count > 0 Then
                _dias = dtVac.Rows.Item(0).Item("dias")
            End If

            dias_vac = Math.Round((_dias * AntigDias) / 365, 2)

            Resultado = Math.Round(dias_vac, 2)
            Return Resultado

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return Resultado
        End Try

    End Function

End Module
