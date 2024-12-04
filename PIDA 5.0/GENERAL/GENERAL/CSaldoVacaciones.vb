Imports System.Text

Public Class CSaldoVacaciones
    Implements IDisposable

#Region "Declaraciones"

    Private TSQL As New StringBuilder
    Private _reloj As String = ""

    ''' <summary>
    ''' fecha donde inicia el primer periodo de aniversario del empleado
    ''' </summary>
    Private fecha_inicio As Date = DateSerial(2023, 1, 1)
    ''' <summary>
    ''' fecha de corte para el calculo de proporciones
    ''' </summary>
    Private fecha_corte As Date
    ''' <summary>
    ''' Tabla de datos del empleado segun a personalvw
    ''' de todas las proporciones de vacaciones
    ''' </summary>
    Private dtEmpleado As New DataTable
    ''' <summary>
    ''' Tabla de los periodos calculados
    ''' con sus respectivas proporciones
    ''' </summary>
    Private dtProporcionesVacaciones As New DataTable
    'Private drProporcion As DataRow = Nothing
    ''' <summary>
    ''' Tabla de dias de vacaciones ganados por aniversario
    ''' </summary>
    Private dtVacacionesBeneficios As New DataTable
    ''' <summary>
    ''' Tabla de dias de vacaciones ganados para empleados que
    ''' tienen dias de vacaciones especiales
    ''' </summary>
    Private dtVacacionesEspeciales As New DataTable
    ''' <summary>
    ''' Tabla de cambios de empleado obtenido de la bitacora
    ''' </summary>
    Private dtCambioTipoEmpleado As New DataTable
    ''' <summary>
    ''' Tabla de periodos, saldos iniciales obtenidos de la tabla
    ''' de 'vac_aniversario'
    ''' </summary>
    Private dtVacacionesAniversario As New DataTable
    ''' <summary>
    ''' Numero de columnas de la tabla de saldos de vacaciones
    ''' de todas las proporciones de vacaciones
    ''' </summary>
    Public NumColSaldoVacaciones As Integer = 0
    ''' <summary>
    ''' Tabla que contiene todos los datos que se calcularon para 
    ''' el saldo finial de vacaciones
    ''' </summary>
    Private dtSaldosVacaciones As DataTable
    ''' <summary>
    ''' Tabla que contiene los errores generados al realizar
    ''' el proceso de obtencion de periodos y saldos de vacaiones
    ''' </summary>
    Private dtErrores As DataTable
    ''' <summary>
    ''' saldo inicial hasta el 16 de fecbrero 2018
    ''' </summary>
    Private SaldoInicial As Decimal = 0
    ''' <summary>
    ''' saldo final al descontar los dias de vacaciones tomadas a la suma
    ''' de todas las proporciones de vacaciones
    ''' </summary>
    Private SaldoFinal As Decimal = 0
    ''' <summary>
    ''' Numero de dias de vacaciones tomadas hasta el ultimo periodo asentado
    ''' en nómina ó hasta el periodo anterior asentado en nómina seleccionado para el calculo
    ''' </summary>
    Private DiasVacacionesTomadas As Decimal = 0
    ''' <summary>
    ''' Sumatoria de todas las proporciones de vacaciones
    ''' por cada periodo calculado
    ''' </summary>
    Private AcumuladoProporcion As Decimal = 0

    Private SiCrearTablaSaldos As Boolean = False

    Private EsFiniquito As Boolean = False

#End Region

    Public ReadOnly Property TablaErrores() As DataTable
        Get
            Return dtErrores
        End Get
    End Property

    Public ReadOnly Property TablaProporcionesVacaciones() As DataTable
        Get
            Return dtProporcionesVacaciones
        End Get
    End Property

    Public ReadOnly Property TablaSaldoFinal() As DataTable
        Get
            Return dtSaldosVacaciones
        End Get
    End Property

    Public ReadOnly Property Saldo_Final() As Decimal
        Get
            Return SaldoFinal
        End Get

    End Property

    Public ReadOnly Property Saldo_Inicial() As Decimal
        Get
            Return SaldoInicial
        End Get

    End Property

    Public ReadOnly Property Vacaciones_Tomadas() As Decimal
        Get
            Return DiasVacacionesTomadas
        End Get

    End Property

    Public ReadOnly Property Total_Porporcion() As Decimal
        Get
            Return AcumuladoProporcion
        End Get

    End Property

    Sub New(ByVal _reloj_ As String, ByVal fecha_corte As Date, ByVal ConTablaSaldos As Boolean, ByVal Finiquito As Boolean)
        Me._reloj = _reloj_.Trim
        Me.fecha_corte = fecha_corte
        Me.SiCrearTablaSaldos = ConTablaSaldos
        Me.EsFiniquito = Finiquito
        Inicializar()
    End Sub

    Private Sub CrearCamposTablaErrores()
        Try

            dtErrores = New DataTable("ERRORES")

            dtErrores.Columns.Add("usuario", GetType(System.String))
            dtErrores.Columns.Add("fechahora", GetType(System.DateTime))
            dtErrores.Columns.Add("procedimiento", GetType(System.String))
            dtErrores.Columns.Add("forma", GetType(System.String))
            dtErrores.Columns.Add("version", GetType(System.String))
            dtErrores.Columns.Add("errnum", GetType(System.Int64))
            dtErrores.Columns.Add("errdesc", GetType(System.String))
            dtErrores.Columns.Add("comentarios", GetType(System.String))

        Catch ex As Exception

            dtErrores.Dispose()
            dtErrores = Nothing
        End Try
    End Sub

    Private Sub CrearCamposTablaProporcionesVacaciones()
        Try

            dtProporcionesVacaciones.Columns.Add("cod_comp", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("especial", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("reloj", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("nombres", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("cod_tipo", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("cod_clase", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("cod_depto", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("aniversario", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("alta", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("alta_antiguedad", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("cod_tipo_anterior", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("fecha_cambio_tipo_emp", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("baja", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("sueldo", GetType(System.Decimal))
            dtProporcionesVacaciones.Columns.Add("antig_16_feb_2018", GetType(System.Decimal))
            dtProporcionesVacaciones.Columns.Add("saldo_inicial", GetType(System.Decimal))
            dtProporcionesVacaciones.Columns.Add("periodo", GetType(System.Int32))
            dtProporcionesVacaciones.Columns.Add("periodo_inicio", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("periodo_fin", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("periodo_dias", GetType(System.Decimal))
            dtProporcionesVacaciones.Columns.Add("periodo_antiguedad", GetType(System.Decimal))
            dtProporcionesVacaciones.Columns.Add("periodo_corresponden", GetType(System.Decimal))
            dtProporcionesVacaciones.Columns.Add("periodo_proporcion", GetType(System.Decimal))
            dtProporcionesVacaciones.Columns.Add("dias_tomados", GetType(System.Decimal))
            dtProporcionesVacaciones.Columns.Add("saldo_final", GetType(System.Decimal))
            dtProporcionesVacaciones.Columns.Add("tipo_registro", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("comentarios", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("fecha_creacion", GetType(System.String))
            dtProporcionesVacaciones.Columns.Add("idvacan", GetType(System.Int32))

        Catch ex As Exception

            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
            dtProporcionesVacaciones.Dispose()
            dtProporcionesVacaciones = Nothing
            'dtProporcionesVacaciones = New DataTable
            'dtProporcionesVacaciones.Columns.Add("ERROR")
        End Try

    End Sub

    Private Sub CargarVacacionesBeneficios()
        Try
            dtVacacionesBeneficios = sqlExecute("select * from vacaciones order by cod_tipo,anos")
        Catch ex As Exception
            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
            dtVacacionesBeneficios.Dispose()
            dtVacacionesBeneficios = Nothing
        End Try
    End Sub

    Private Sub CargarVacacionesEspeciales()
        Try
            dtVacacionesEspeciales = sqlExecute("select * from vac_especiales order by reloj,cod_tipo,anos")
        Catch ex As Exception
            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
            dtVacacionesEspeciales.Dispose()
            dtVacacionesEspeciales = Nothing
        End Try
    End Sub

    Private Sub CargarDatosEmpleado()
        Try
            dtEmpleado = sqlExecute("select * from personalvw where reloj = '" & _reloj & "'")

            With dtEmpleado.Rows(0)
                DiasVacacionesTomadas = VacacionesTomadas(.Item("reloj").ToString.Trim, .Item("alta").ToString, .Item("cod_tipo").ToString.Trim, fecha_inicio)
            End With

        Catch ex As Exception
            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
            dtEmpleado.Dispose()
            dtEmpleado = Nothing
        End Try
    End Sub

    Private Function VacacionesTomadas(ByVal rl As String, ByVal alta As Date, ByVal tipo_empleado As String, ByVal fha_inicio As Date) As Decimal

        Dim _resultado As Decimal = 0D
        Dim dtVacacionesTomadas As New DataTable

        Try

            TSQL.Clear()
            TSQL.AppendLine("declare @_finiquito as int = " & IIf(EsFiniquito, "1", "0"))
            TSQL.AppendLine("declare @_reloj as varchar(6) = '" & rl.Trim & "'")
            TSQL.AppendLine("declare @_alta as varchar(10) = '" & alta.ToString("yyyy-MM-dd") & "'")
            TSQL.AppendLine("declare @_inicio as varchar(10) = '" & fha_inicio.ToString("yyyy-MM-dd") & "'")
            TSQL.AppendLine("declare @_corte_provision as varchar(10) = '" & Me.fecha_corte.ToString("yyyy-MM-dd") & "'")
            TSQL.AppendLine("declare @_corte as varchar(10) = ''")
            TSQL.AppendLine("declare @_tomadas as int = 0")
            TSQL.AppendLine("")

            Select Case tipo_empleado.Trim.ToUpper

                Case "A"

                    TSQL.AppendLine("if @_finiquito = 1")
                    TSQL.AppendLine("begin")
                    TSQL.AppendLine(" set @_corte =  coalesce( (select convert(varchar(10),convert(date,fecha_fin_incidencia))")
                    TSQL.AppendLine(" from periodos_quincenal where ano+periodo =(")
                    TSQL.AppendLine(" Select MAX(ano+periodo) from ")
                    TSQL.AppendLine(" (select ano,periodo from NOMINA.dbo.nomina where reloj = @_reloj and tipo_periodo = 'Q' and  ano+periodo >= (")
                    TSQL.AppendLine(" select top 1 ano+periodo from periodos_quincenal ")
                    TSQL.AppendLine(" where (case when @_alta <= @_inicio then @_inicio else @_alta end) between FECHA_INI and FECHA_FIN and PERIODO_ESPECIAL = 0)) as T")
                    TSQL.AppendLine(" where exists (select * from periodos_quincenal where periodos_quincenal.ANO = T.ANO and periodos_quincenal.PERIODO = T.PERIODO and")
                    TSQL.AppendLine(" PERIODO_ESPECIAL = 0))),'')")
                    TSQL.AppendLine("")
                    TSQL.AppendLine(" if @_corte <> ''")
                    TSQL.AppendLine(" begin")
                    TSQL.AppendLine("  set @_tomadas =  coalesce((select count(tipo_aus) as tomadas")
                    TSQL.AppendLine("  from ausentismo")
                    TSQL.AppendLine("  where reloj = @_reloj and (TIPO_AUS = 'VAC') and (FECHA between @_inicio and @_corte)), 0)")
                    TSQL.AppendLine(" end")
                    TSQL.AppendLine("end")
                    TSQL.AppendLine("else")
                    TSQL.AppendLine("begin")
                    TSQL.AppendLine(" set @_tomadas =  coalesce((select count(tipo_aus) as tomadas")
                    TSQL.AppendLine(" from ausentismo")
                    TSQL.AppendLine(" where reloj = @_reloj and (TIPO_AUS = 'VAC') and (FECHA between (case when @_alta <= @_inicio then @_inicio else @_alta end )")
                    TSQL.AppendLine(" and @_corte_provision)), 0)")
                    TSQL.AppendLine("end")
                    TSQL.AppendLine("")
                    TSQL.AppendLine("select @_tomadas as tomadas")

                    dtVacacionesTomadas = sqlExecute(TSQL.ToString, "TA")

                    Try
                        _resultado = Integer.Parse(dtVacacionesTomadas.Rows(0)("tomadas").ToString)
                    Catch ex As Exception
                        _resultado = 0
                    End Try

                Case "O"

                    TSQL.AppendLine("if @_finiquito = 1")
                    TSQL.AppendLine("begin")
                    TSQL.AppendLine(" set @_corte =  coalesce( (select convert(varchar(10),convert(date,fecha_fin))")
                    TSQL.AppendLine(" from periodos where ano+periodo =(")
                    TSQL.AppendLine(" Select MAX(ano+periodo) from ")
                    TSQL.AppendLine(" (select ano,periodo from NOMINA.dbo.nomina where reloj = @_reloj and tipo_periodo = 'S' and  ano+periodo >= (")
                    TSQL.AppendLine(" select top 1 ano+periodo from periodos ")
                    TSQL.AppendLine(" where (case when @_alta <= @_inicio then @_inicio else @_alta end) between FECHA_INI and FECHA_FIN and PERIODO_ESPECIAL = 0)) as T")
                    TSQL.AppendLine(" where exists (select * from periodos where periodos.ANO = T.ANO and periodos.PERIODO = T.PERIODO and PERIODO_ESPECIAL = 0))),'')")
                    TSQL.AppendLine("")
                    TSQL.AppendLine(" if @_corte <> ''")
                    TSQL.AppendLine(" begin")
                    TSQL.AppendLine("  set @_tomadas =  coalesce((select count(tipo_aus) as tomadas")
                    TSQL.AppendLine("  from ausentismo")
                    TSQL.AppendLine("  where reloj = @_reloj and (TIPO_AUS = 'VAC') and (FECHA between @_inicio and @_corte)), 0)")
                    TSQL.AppendLine("  end")
                    TSQL.AppendLine("end")
                    TSQL.AppendLine("else")
                    TSQL.AppendLine("begin")
                    TSQL.AppendLine(" set @_tomadas =  coalesce((select count(tipo_aus) as tomadas")
                    TSQL.AppendLine(" from ausentismo")
                    TSQL.AppendLine(" where reloj = @_reloj and (TIPO_AUS = 'VAC') and (FECHA between (case when @_alta <= @_inicio then @_inicio else @_alta end )")
                    TSQL.AppendLine(" and @_corte_provision)), 0)")
                    TSQL.AppendLine("end")

                    TSQL.AppendLine("")
                    TSQL.AppendLine("select @_tomadas as tomadas")

                    dtVacacionesTomadas = sqlExecute(TSQL.ToString, "TA")

                    Try
                        _resultado = Integer.Parse(dtVacacionesTomadas.Rows(0)("tomadas").ToString)
                    Catch ex As Exception
                        _resultado = 0
                    End Try

                Case Else
                    _resultado = 0D
            End Select

        Catch ex As Exception
            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
            _resultado = 0D
        End Try

        dtVacacionesTomadas.Dispose()
        dtVacacionesTomadas = Nothing

        Return _resultado

    End Function

    Private Sub CargarCambioTipoEmpleado()

        Try
            dtCambioTipoEmpleado = sqlExecute("select * from bitacora_personal where campo='cod_tipo' and tipo_movimiento <> 'A' and (valornuevo <> 'O' and rtrim(ltrim(isnull(valornuevo,''))) <> '') and reloj = '" & _reloj & "' order by fecha_mantenimiento desc")
        Catch ex As Exception
            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
            dtCambioTipoEmpleado.Dispose()
            dtCambioTipoEmpleado = Nothing
        End Try

    End Sub

    Private Sub Inicializar()

        CrearCamposTablaErrores()
        CrearCamposTablaProporcionesVacaciones()
        CargarDatosEmpleado()
        CargarVacacionesBeneficios()
        CargarVacacionesEspeciales()


        ' If DatosNecesariosCompletos() Then RegistroInicial()

        If DatosNecesariosCompletos() Then CargarVacacionesAniversario(dtEmpleado.Rows(0))


    End Sub


    Public Sub TablaMemoriaErrorLog(ByVal Usuario As String, ByVal Procedimiento As String, ByVal Forma As String, ByVal ErrNum As Long, ByVal ErrDesc As String, Optional Comentarios As String = "")
        Try

            If Not (dtErrores Is Nothing) Then
                If dtErrores.Columns.Count > 0 Then
                    Dim drAgregar As DataRow = dtErrores.NewRow

                    drAgregar("usuario") = "PIDA-" & Usuario.Trim
                    drAgregar("fechahora") = Now
                    drAgregar("procedimiento") = Procedimiento.Trim
                    drAgregar("forma") = Forma.Trim
                    drAgregar("version") = ApVer.Trim
                    drAgregar("errnum") = ErrNum
                    drAgregar("errdesc") = ErrDesc.Trim
                    drAgregar("comentarios") = Comentarios.Trim

                    dtErrores.Rows.Add(drAgregar)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarVacacionesAniversario(ByVal Empleado As DataRow)

        Dim compania As String = ""
        Dim rl As String = ""
        Dim fecha_alta As Date = Nothing
        Dim STSQL As String = ""

        Try

            compania = IIf(IsDBNull(Empleado("cod_comp")), "NA", Empleado("cod_comp"))
            rl = Empleado("reloj").ToString.Trim
            fecha_alta = Empleado("alta")

            STSQL = "declare @_cod_comp as varchar(6) = '" & compania & "'" & vbCrLf
            STSQL &= "declare @_reloj as varchar(10) = '" & rl & "'" & vbCrLf
            STSQL &= "declare @_alta_actual as varchar(10) = '" & fecha_alta.ToString("yyyy-MM-dd") & "'" & vbCrLf
            STSQL &= "declare @_ultima_alta as varchar(10) = ''" & vbCrLf
            STSQL &= "declare @_fecha_corte as varchar(10) = '" & fecha_corte.ToString("yyyy-MM-dd") & "'" & vbCrLf
            STSQL &= "set @_ultima_alta = (select top 1 alta from vac_aniversarios where cod_comp = @_cod_comp and reloj = @_reloj order by idvacan desc)" & vbCrLf
            STSQL &= "if (@_ultima_alta is null) or (@_ultima_alta <> @_alta_actual)" & vbCrLf
            STSQL &= "begin" & vbCrLf
            STSQL &= " select 'RegistroNuevo' as 'comentario'" & vbCrLf
            STSQL &= "end" & vbCrLf
            STSQL &= "else" & vbCrLf
            STSQL &= "begin" & vbCrLf
            STSQL &= " select top 1 vac.especial,vac.reloj,vac.nombres,vac.aniversario,vac.alta,vac.alta_antiguedad,vac.cod_tipo_anterior,vac.fecha_cambio_tipo_emp,vac.antig_16_feb_2018,vac.saldo_inicial,vac.tipo_registro,vac.comentarios,vac.fecha_creacion,'RegistroExistente' as 'comentario' from vac_aniversarios vac where cod_comp = @_cod_comp and reloj = @_reloj order by idvacan desc" & vbCrLf
            STSQL &= "end" & vbCrLf

            dtVacacionesAniversario = sqlExecute(STSQL)
            CargarCambioTipoEmpleado()
            With dtVacacionesAniversario.Columns

                If .Contains("ERROR") Then
                    dtProporcionesVacaciones.Dispose()
                    dtProporcionesVacaciones = Nothing
                ElseIf .Contains("comentario") Then

                    Dim comentario As String = dtVacacionesAniversario.Rows(0)("comentario").ToString.Trim

                    Select Case comentario
                        Case "RegistroNuevo"
                            RegistroInicialTest(True)
                        Case "RegistroExistente"

                            RegistroInicialTest(False)
                        Case Else
                            dtProporcionesVacaciones.Dispose()
                            dtProporcionesVacaciones = Nothing
                    End Select

                End If

            End With

            ' dtVacacionesAniversario = sqlExecute("select top 1 * from vac_aniversarios where reloj = '" & rl & "' order by idvacan desc")

            'If dtVacacionesAniversario.Columns.Contains("ERROR") Then
            '    dtProporcionesVacaciones.Dispose()
            '    dtProporcionesVacaciones = Nothing
            'ElseIf dtVacacionesAniversario.Rows.Count > 0 Then
            '    Try

            '        Dim drVacAniversario As DataRow = dtVacacionesAniversario.Rows(0)
            '        Dim drProporcion As DataRow = Nothing

            '        drProporcion = dtProporcionesVacaciones.NewRow

            '        drProporcion("cod_comp") = Trim(IIf(IsDBNull(drVacAniversario("cod_comp")), "", drVacAniversario("cod_comp")))

            '        Try
            '            drProporcion("especial") = Trim(IIf(IsDBNull(drVacAniversario("especial")), "", drVacAniversario("especial")))
            '        Catch ex As Exception

            '        End Try

            '        drProporcion("reloj") = Trim(IIf(IsDBNull(drVacAniversario("reloj")), "", drVacAniversario("reloj")))
            '        drProporcion("nombres") = Trim(IIf(IsDBNull(drVacAniversario("nombres")), "", drVacAniversario("nombres")))
            '        drProporcion("cod_tipo") = Trim(IIf(IsDBNull(drVacAniversario("cod_tipo")), "", drVacAniversario("cod_tipo")))
            '        drProporcion("cod_clase") = Trim(IIf(IsDBNull(drVacAniversario("cod_clase")), "", drVacAniversario("cod_clase")))
            '        drProporcion("cod_depto") = Trim(IIf(IsDBNull(drVacAniversario("cod_depto")), "", drVacAniversario("cod_depto")))

            '        If IsDBNull(drVacAniversario("aniversario")) Then
            '            drProporcion("aniversario") = ""
            '        Else
            '            drProporcion("aniversario") = CDate(drVacAniversario("aniversario")).ToString("yyyy-MM-dd")
            '        End If

            '        Dim alta As Date = Date.Parse(drVacAniversario("alta").ToString)
            '        Dim alta_antiguedad As Date = Date.Parse(IIf(IsDBNull(drVacAniversario("alta_antiguedad")), alta, drVacAniversario("alta_antiguedad")).ToString)

            '        drProporcion("alta") = alta.ToString("yyyy-MM-dd")
            '        drProporcion("alta_antiguedad") = alta_antiguedad.ToString("yyyy-MM-dd")

            '        Try
            '            If Not IsDBNull(drVacAniversario("cod_tipo_anterior")) And Not IsDBNull(drVacAniversario("fecha_cambio_tipo_emp")) Then
            '                drProporcion("cod_tipo_anterior") = drVacAniversario("cod_tipo_anterior").ToString
            '                drProporcion("fecha_cambio_tipo_emp") = CDate(drVacAniversario("fecha_cambio_tipo_emp")).ToString("yyyy-MM-dd")
            '            Else
            '                drProporcion("cod_tipo_anterior") = ""
            '                drProporcion("fecha_cambio_tipo_emp") = ""
            '            End If
            '        Catch ex As Exception
            '            drProporcion("cod_tipo_anterior") = ""
            '            drProporcion("fecha_cambio_tipo_emp") = ""
            '        End Try

            '        Try
            '            If Not IsDBNull(drVacAniversario("baja")) Then drProporcion("baja") = CDate(drVacAniversario("baja")).ToString("yyyy-MM-dd")
            '        Catch ex As Exception
            '            drProporcion("baja") = ""
            '        End Try

            '        If IsDBNull(drVacAniversario("sueldo")) Then
            '            drProporcion("sueldo") = 0.0
            '        Else
            '            drProporcion("sueldo") = CDec(drVacAniversario("sueldo").ToString)
            '        End If

            '        If IsDBNull(drVacAniversario("antig_16_feb_2018")) Then
            '            drProporcion("antig_16_feb_2018") = 0.0
            '        Else
            '            drProporcion("antig_16_feb_2018") = CDec(drVacAniversario("antig_16_feb_2018").ToString)
            '        End If

            '        If IsDBNull(drVacAniversario("saldo_inicial")) Then
            '            drProporcion("saldo_inicial") = 0.0
            '        Else
            '            drProporcion("saldo_inicial") = CDec(drVacAniversario("saldo_inicial").ToString)
            '        End If

            '        drProporcion("periodo") = 1
            '        drProporcion("periodo_inicio") = CDate(drVacAniversario("periodo_inicio")).ToString("yyyy-MM-dd")
            '        drProporcion("periodo_fin") = CDate(drVacAniversario("periodo_fin")).ToString("yyyy-MM-dd")
            '        drProporcion("periodo_dias") = CDec(drVacAniversario("periodo_dias").ToString)
            '        drProporcion("periodo_antiguedad") = CDec(drVacAniversario("periodo_antiguedad").ToString)
            '        drProporcion("periodo_corresponden") = CDec(drVacAniversario("periodo_corresponden").ToString)
            '        drProporcion("periodo_proporcion") = CDec(drVacAniversario("periodo_proporcion").ToString)

            '        If IsDBNull(drVacAniversario("dias_tomados")) Then
            '            drProporcion("dias_tomados") = 0.0
            '        Else
            '            drProporcion("dias_tomados") = CDec(drVacAniversario("dias_tomados").ToString)
            '        End If

            '        If IsDBNull(drVacAniversario("saldo_final")) Then
            '            drProporcion("saldo_final") = 0.0
            '        Else
            '            drProporcion("saldo_final") = CDec(drVacAniversario("saldo_final").ToString)
            '        End If

            '        If IsDBNull(drVacAniversario("tipo_registro")) Then
            '            drProporcion("tipo_registro") = ""
            '        Else
            '            drProporcion("tipo_registro") = drVacAniversario("tipo_registro").ToString.Trim
            '        End If

            '        If IsDBNull(drVacAniversario("comentarios")) Then
            '            drProporcion("comentarios") = ""
            '        Else
            '            drProporcion("comentarios") = drVacAniversario("comentarios").ToString.Trim
            '        End If

            '        If IsDBNull(drVacAniversario("fecha_creacion")) Then
            '            drProporcion("fecha_creacion") = ""
            '        Else
            '            drProporcion("fecha_creacion") = CDate(drVacAniversario("fecha_creacion")).ToString("yyyy-MM-dd")
            '        End If

            '        dtProporcionesVacaciones.Rows.Add(drProporcion)

            '    Catch ex As Exception
            '        TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
            '        dtProporcionesVacaciones.Dispose()
            '        dtProporcionesVacaciones = Nothing
            '    End Try

            'Else
            '    CargarCambioTipoEmpleado()
            'End If

        Catch ex As Exception

            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)

            dtVacacionesAniversario.Dispose()
            dtVacacionesAniversario = Nothing
        End Try
    End Sub

    Private Sub RegistroInicialTest(ByVal RegistroNuevo As Boolean)

        Dim drProporcion As DataRow = Nothing
        Dim periodo1_inicio As Date = Nothing
        Dim periodo1_fin As Date = Nothing
        Dim alta As Date = Nothing
        Dim alta_antiguedad As Date = Nothing
        Dim cambio_fecha_tipo_emp As Date = Nothing
        Dim EsCambioTipoEmpleado As Boolean = False
        Dim cod_tipo As String = ""
        Dim drEmpleado As DataRow = Nothing
        Dim continuar As Boolean = True

        Try

            If Not dtProporcionesVacaciones Is Nothing Then
                If Not dtProporcionesVacaciones.Columns.Contains("ERROR") Then
                    If RegistroNuevo Then

                        drEmpleado = dtEmpleado.Rows(0)

                        drProporcion = dtProporcionesVacaciones.NewRow

                        drProporcion("cod_comp") = Trim(IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp")))

                        Try
                            drProporcion("especial") = ""
                        Catch ex As Exception

                        End Try

                        drProporcion("reloj") = Trim(IIf(IsDBNull(drEmpleado("reloj")), "", drEmpleado("reloj")))
                        drProporcion("nombres") = Trim(IIf(IsDBNull(drEmpleado("nombres")), "", drEmpleado("nombres")))
                        drProporcion("cod_tipo") = Trim(IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo")))

                        Dim lcl_cod_clase As String = Trim(IIf(IsDBNull(drEmpleado("cod_clase")), "", drEmpleado("cod_clase")))

                        drProporcion("cod_clase") = lcl_cod_clase
                        drProporcion("cod_depto") = Trim(IIf(IsDBNull(drEmpleado("cod_depto")), "", drEmpleado("cod_depto")))
                        drProporcion("aniversario") = ""

                        alta = Date.Parse(drEmpleado("alta").ToString)
                        alta_antiguedad = Date.Parse(IIf(IsDBNull(drEmpleado("alta_vacacion")), alta, drEmpleado("alta_vacacion")).ToString)

                        drProporcion("alta") = alta.ToString("yyyy-MM-dd")
                        drProporcion("alta_antiguedad") = alta_antiguedad.ToString("yyyy-MM-dd")

                        Try

                            cod_tipo = dtCambioTipoEmpleado.Rows(0)("valoranterior").ToString.Trim
                            ' drProporcion("cod_tipo_anterior") = cod_tipo

                            cambio_fecha_tipo_emp = CDate(dtCambioTipoEmpleado.Rows(0)("fecha"))
                            ' drProporcion("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")

                            EsCambioTipoEmpleado = True

                        Catch ex As Exception
                            EsCambioTipoEmpleado = False
                            cambio_fecha_tipo_emp = Nothing
                            cod_tipo = drProporcion("cod_tipo")
                            drProporcion("cod_tipo_anterior") = ""
                            drProporcion("fecha_cambio_tipo_emp") = ""
                        End Try

                        Try
                            drProporcion("baja") = CDate(drEmpleado("baja")).ToString("yyyy-MM-dd")
                        Catch ex As Exception
                            drProporcion("baja") = ""
                        End Try

                        drProporcion("sueldo") = IIf(IsDBNull(drEmpleado("sactual")), 0.0, drEmpleado("sactual"))
                        drProporcion("antig_16_feb_2018") = 0.0
                        drProporcion("saldo_inicial") = 0.0
                        drProporcion("periodo") = 1

                        ' periodo1_inicio = IIf(alta > fecha_inicio, alta, fecha_inicio)

                        Dim fecha_inicial As Date = fecha_inicio

                        'If alta < fecha_inicial Then

                        '    If alta.Month = 2 And alta.Day > 16 Then
                        '        Dim agregarDias As Integer = alta.Day - fecha_inicial.Day
                        '        fecha_inicial = fecha_inicial.AddDays(agregarDias)
                        '    End If

                        'End If

                        Dim per_ini As Date? = Calculo_Periodo1_Inicio(alta, fecha_inicial, True).Value
                        per_ini = IIf(per_ini.Value = Nothing, Nothing, per_ini.Value)

                        If per_ini.HasValue Then
                            periodo1_inicio = CDate(per_ini.Value)
                        Else
                            Exit Sub
                        End If

                        drProporcion("periodo_inicio") = periodo1_inicio.ToString("yyyy-MM-dd")

                        'Dim fecha_tmp As Date = DateSerial(periodo1_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)

                        'If fecha_tmp < periodo1_inicio Then
                        '    fecha_tmp = DateSerial(periodo1_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddYears(1).AddDays(-1)
                        'Else
                        '    fecha_tmp = DateSerial(periodo1_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)
                        'End If

                        'If fecha_tmp > fecha_corte Then
                        '    fecha_tmp = fecha_corte
                        'Else

                        '    fecha_tmp = DateSerial(periodo1_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)

                        '    If fecha_tmp < periodo1_inicio Then
                        '        fecha_tmp = DateSerial(periodo1_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddYears(1).AddDays(-1)
                        '    Else
                        '        fecha_tmp = DateSerial(periodo1_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)
                        '    End If

                        'End If

                        'periodo1_fin = fecha_tmp

                        Dim per_fin As Date? = Calculo_Periodo1_Fin(periodo1_inicio, alta_antiguedad, fecha_corte).Value
                        per_fin = IIf(per_fin.Value = Nothing, Nothing, per_fin.Value)

                        If per_fin.HasValue Then
                            periodo1_fin = CDate(per_fin.Value)
                        Else
                            Exit Sub
                        End If

                        'If EsCambioTipoEmpleado Then
                        '    If cambio_fecha_tipo_emp >= periodo1_inicio And cambio_fecha_tipo_emp <= periodo1_fin Then
                        '        periodo1_fin = cambio_fecha_tipo_emp.AddDays(-1)
                        '        drProporcion("cod_tipo_anterior") = cod_tipo
                        '        drProporcion("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")
                        '    Else
                        '        ' cod_tipo = drProporcion("cod_tipo")
                        '        drProporcion("cod_tipo_anterior") = cod_tipo
                        '        drProporcion("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")
                        '    End If
                        'Else
                        '    cod_tipo = drProporcion("cod_tipo")
                        '    drProporcion("cod_tipo_anterior") = ""
                        '    drProporcion("fecha_cambio_tipo_emp") = ""
                        'End If

                        If EsCambioTipoEmpleado Then
                            If cambio_fecha_tipo_emp >= periodo1_inicio And cambio_fecha_tipo_emp <= periodo1_fin Then
                                periodo1_fin = cambio_fecha_tipo_emp.AddDays(-1)
                                drProporcion("cod_tipo_anterior") = cod_tipo
                                drProporcion("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")
                            ElseIf cambio_fecha_tipo_emp < periodo1_inicio Then
                                cod_tipo = drProporcion("cod_tipo")
                                drProporcion("cod_tipo_anterior") = ""
                                drProporcion("fecha_cambio_tipo_emp") = ""
                            ElseIf cambio_fecha_tipo_emp > periodo1_fin Then
                                drProporcion("cod_tipo_anterior") = cod_tipo
                                drProporcion("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")
                            Else
                                cod_tipo = drProporcion("cod_tipo")
                                drProporcion("cod_tipo_anterior") = ""
                                drProporcion("fecha_cambio_tipo_emp") = ""
                            End If
                        Else
                            cod_tipo = drProporcion("cod_tipo")
                            drProporcion("cod_tipo_anterior") = ""
                            drProporcion("fecha_cambio_tipo_emp") = ""
                        End If


                        drProporcion("periodo_fin") = periodo1_fin.ToString("yyyy-MM-dd")
                        Dim periodo1_dias As Integer = DateDiff(DateInterval.Day, periodo1_inicio, periodo1_fin) + 1
                        drProporcion("periodo_dias") = periodo1_dias

                        'Dim Periodo1_dias_anteriores As Integer = IIf(alta < fecha_inicio, 20, 0)
                        'Dim Periodo1_dias_cotizados As Integer = DateDiff(DateInterval.Day, alta_antiguedad, periodo1_fin) - Periodo1_dias_anteriores
                        'Dim Periodo1_Antiguedad As Integer = Int((CDec(Periodo1_dias_cotizados) / 365D)) + 1
                        Dim Periodo1_Antiguedad As Integer = DiferenciaFecha(alta_antiguedad, periodo1_fin) + 1
                      
                        Dim Periodo1_Corresponden As Integer = 0

                        drProporcion("periodo_antiguedad") = Periodo1_Antiguedad

                        Try

                            Dim drVacaciones() As DataRow = Nothing
                            drVacaciones = dtVacacionesEspeciales.Select("cod_comp = '" & drProporcion("cod_comp") & "' and cod_tipo = '" & cod_tipo & "' and reloj = '" & _reloj & "' and anos <= " & Periodo1_Antiguedad.ToString, "anos desc")
                            Dim Vacaciones_Especiales As Boolean = False

                            If Not (drVacaciones Is Nothing) Then
                                If drVacaciones.Count > 0 Then
                                    Vacaciones_Especiales = True
                                    Periodo1_Corresponden = drVacaciones(0)("dias")
                                End If
                            End If

                            If Vacaciones_Especiales Then
                                Try
                                    drProporcion("especial") = "si"
                                Catch ex As Exception

                                End Try
                            End If

                            drVacaciones = Nothing
                            If Not Vacaciones_Especiales Then

                                If EsCambioTipoEmpleado Then
                                    drVacaciones = dtVacacionesBeneficios.Select("cod_comp = '" & drProporcion("cod_comp") & "' and cod_tipo = '" & cod_tipo & "' and anos <= " & Periodo1_Antiguedad.ToString, "anos desc")
                                Else
                                    drVacaciones = dtVacacionesBeneficios.Select("cod_comp = '" & drProporcion("cod_comp") & "' and cod_tipo = '" & IIf(lcl_cod_clase.Trim.ToUpper = "G" Or lcl_cod_clase.Trim.ToUpper = "R", "G", cod_tipo) & "' and anos <= " & Periodo1_Antiguedad.ToString, "anos desc")
                                End If

                                If Not (drVacaciones Is Nothing) Then
                                    If drVacaciones.Count > 0 Then
                                        Periodo1_Corresponden = drVacaciones(0)("dias")
                                    End If
                                End If
                            End If

                        Catch ex As Exception
                            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
                            Periodo1_Corresponden = 0
                        End Try

                        drProporcion("periodo_corresponden") = Periodo1_Corresponden

                        Dim dias_anio As Decimal = CDec(IIf(periodo1_dias = 366, 366, 365))
                        Dim periodo1_proporcion As Decimal = Math.Round(((CDec(Periodo1_Corresponden) / dias_anio) * periodo1_dias), 2)

                        drProporcion("saldo_final") = 0
                        drProporcion("periodo_proporcion") = periodo1_proporcion
                        drProporcion("dias_tomados") = 0
                        drProporcion("tipo_registro") = "N"
                        drProporcion("comentarios") = "NUEVO REGISTRO"

                        '---Varibales para carga inicial
                        'Dim var_cod_comp As String = Trim(IIf(IsDBNull(drProporcion("cod_comp")), "NA", drProporcion("cod_comp")))
                        'Dim var_especial As String = ""
                        'Try
                        '    var_especial = Trim(IIf(IsDBNull(drProporcion("especial")), "", drProporcion("especial")))
                        'Catch ex As Exception

                        'End Try

                        'Dim var_reloj As String = Trim(IIf(IsDBNull(drProporcion("reloj")), "", drProporcion("reloj")))
                        'Dim var_nombres As String = Trim(IIf(IsDBNull(drProporcion("nombres")), "", drProporcion("nombres")))
                        'Dim var_cod_tipo As String = IIf(lcl_cod_clase.Trim.ToUpper = "G" Or lcl_cod_clase.Trim.ToUpper = "R", "G", drProporcion("cod_tipo"))
                        'Dim var_cod_clase As String = Trim(IIf(IsDBNull(drProporcion("cod_clase")), "", drProporcion("cod_clase")))
                        'Dim var_cod_depto As String = Trim(IIf(IsDBNull(drProporcion("cod_depto")), "", drProporcion("cod_depto")))
                        'Dim var_aniversario As String = Trim(IIf(IsDBNull(drProporcion("aniversario")), "", drProporcion("aniversario")))
                        'Dim var_alta As String = drProporcion("alta")
                        'Dim var_alta_antiguedad As String = drProporcion("alta_antiguedad")
                        'Dim var_cod_tipo_anterior As String = ""
                        'Try
                        '    var_cod_tipo_anterior = drProporcion("cod_tipo_anterior").ToString.Trim
                        'Catch ex As Exception

                        'End Try
                        'Dim var_fecha_cambio_anterior As String = ""
                        'Try
                        '    If var_cod_tipo_anterior.Trim <> "" Then
                        '        var_fecha_cambio_anterior = drProporcion("fecha_cambio_tipo_emp")
                        '    Else
                        '        var_fecha_cambio_anterior = "1900-01-01"
                        '        var_cod_tipo_anterior = ""
                        '    End If

                        'Catch ex As Exception
                        '    var_fecha_cambio_anterior = "1900-01-01"
                        '    var_cod_tipo_anterior = ""
                        'End Try

                        'Dim var_baja As String = ""
                        'Try
                        '    var_baja = drProporcion("baja").ToString.Trim
                        '    If Not var_baja.Trim <> "" Then
                        '        var_baja = "1900-01-01"
                        '    End If

                        'Catch ex As Exception
                        '    var_baja = "1900-01-01"
                        'End Try

                        'Dim var_sueldo As Decimal = 0D
                        'Try
                        '    var_sueldo = CDec(drProporcion("sueldo"))
                        'Catch ex As Exception
                        '    var_sueldo = 0
                        'End Try

                        'Dim var_antig_16_feb_2018 As Decimal = 0D
                        'Try
                        '    var_antig_16_feb_2018 = CDec(drProporcion("antig_16_feb_2018"))
                        'Catch ex As Exception
                        '    var_antig_16_feb_2018 = 0
                        'End Try

                        'Dim var_saldo_inicial As Decimal = 0D
                        'Try
                        '    var_saldo_inicial = CDec(drProporcion("saldo_inicial"))
                        'Catch ex As Exception
                        '    var_saldo_inicial = 0
                        'End Try

                        'Dim var_periodo_inicio As String = drProporcion("periodo_inicio").ToString.Trim
                        'Dim var_periodo_fin As String = drProporcion("periodo_fin").ToString.Trim
                        'Dim var_periodo_dias As Integer = IIf(IsDBNull(drProporcion("periodo_dias")), 0, drProporcion("periodo_dias"))
                        'Dim var_periodo_antiguedad As Integer = IIf(IsDBNull(drProporcion("periodo_antiguedad")), 0, drProporcion("periodo_antiguedad"))
                        'Dim var_periodo_corresponden As Integer = IIf(IsDBNull(drProporcion("periodo_corresponden")), 0, drProporcion("periodo_corresponden"))
                        'Dim var_periodo_proporcion As Decimal = IIf(IsDBNull(drProporcion("periodo_proporcion")), 0, drProporcion("periodo_proporcion"))
                        'Dim var_dias_tomados As Integer = IIf(IsDBNull(drProporcion("dias_tomados")), 0, drProporcion("dias_tomados"))
                        'Dim var_saldo_final As Decimal = IIf(IsDBNull(drProporcion("saldo_final")), 0, drProporcion("saldo_final"))
                        'Dim var_tipo_registro As String = Trim(IIf(IsDBNull(drProporcion("tipo_registro")), "", drProporcion("tipo_registro")))
                        'Dim var_comentarios As String = Trim(IIf(IsDBNull(drProporcion("comentarios")), "", drProporcion("comentarios")))

                        'Dim STSQL As String = "Declare @_id_creado int;" & vbCrLf

                        'STSQL &= "INSERT INTO [vac_aniversarios]" & vbCrLf
                        'STSQL &= " ([cod_comp],[especial],[reloj],[nombres],[cod_tipo],[cod_clase],[cod_depto],[aniversario],[alta]" & vbCrLf
                        'STSQL &= ",[alta_antiguedad],[cod_tipo_anterior],[fecha_cambio_tipo_emp],[baja],[sueldo],[antig_16_feb_2018],[saldo_inicial]" & vbCrLf
                        'STSQL &= ",[periodo_inicio],[periodo_fin],[periodo_dias],[periodo_antiguedad],[periodo_corresponden],[periodo_proporcion],[dias_tomados]" & vbCrLf
                        'STSQL &= ",[saldo_final],[tipo_registro],[comentarios],[fecha_creacion])" & vbCrLf
                        'STSQL &= "VALUES" & vbCrLf
                        'STSQL &= "('" & var_cod_comp & "'" & vbCrLf
                        'STSQL &= ",'" & var_especial & "'" & vbCrLf
                        'STSQL &= ",'" & var_reloj & "'" & vbCrLf
                        'STSQL &= ",'" & var_nombres & "'" & vbCrLf
                        'STSQL &= ",'" & var_cod_tipo & "'" & vbCrLf
                        'STSQL &= ",'" & var_cod_clase & "'" & vbCrLf
                        'STSQL &= ",'" & var_cod_depto & "'" & vbCrLf
                        'STSQL &= ",'" & var_aniversario & "'" & vbCrLf
                        'STSQL &= ",'" & var_alta & "'" & vbCrLf
                        'STSQL &= ",'" & var_alta_antiguedad & "'" & vbCrLf
                        'STSQL &= ",'" & var_cod_tipo_anterior & "'" & vbCrLf
                        'STSQL &= "," & IIf(var_fecha_cambio_anterior.Trim = "1900-01-01", "NULL", "'" & var_fecha_cambio_anterior.Trim & "'") & "" & vbCrLf
                        'STSQL &= "," & IIf(var_baja.Trim = "1900-01-01", "NULL", "'" & var_baja.Trim & "'") & "" & vbCrLf
                        'STSQL &= "," & CDbl(var_sueldo) & vbCrLf
                        'STSQL &= "," & CDbl(var_antig_16_feb_2018) & vbCrLf
                        'STSQL &= "," & CDbl(var_saldo_inicial) & vbCrLf
                        'STSQL &= ",'" & var_periodo_inicio & "'" & vbCrLf
                        'STSQL &= ",'" & var_periodo_fin & "'" & vbCrLf
                        'STSQL &= "," & var_periodo_dias & vbCrLf
                        'STSQL &= "," & var_periodo_antiguedad & vbCrLf
                        'STSQL &= "," & var_periodo_corresponden & vbCrLf
                        'STSQL &= "," & CDbl(var_periodo_proporcion) & vbCrLf
                        'STSQL &= "," & var_dias_tomados & vbCrLf
                        'STSQL &= "," & CDbl(var_saldo_final) & vbCrLf
                        'STSQL &= ",'" & var_tipo_registro & "'" & vbCrLf
                        'STSQL &= ",'" & var_comentarios & "'" & vbCrLf
                        'STSQL &= ",convert(date,getdate())" & vbCrLf
                        'STSQL &= ");" & vbCrLf
                        'STSQL &= "set @_id_creado = @@IDENTITY;" & vbCrLf
                        'STSQL &= "select * from vac_aniversarios where idvacan = @_id_creado;"

                        'Dim dtInsertar As DataTable = sqlExecute(STSQL)

                        'If dtInsertar.Columns.Contains("ERROR") Then
                        '    dtProporcionesVacaciones.Dispose()
                        '    dtProporcionesVacaciones = Nothing
                        'ElseIf Not dtInsertar.Rows.Count > 0 Then
                        '    dtProporcionesVacaciones.Dispose()
                        '    dtProporcionesVacaciones = Nothing
                        'Else

                        '    dtProporcionesVacaciones.Rows.Add(drProporcion)

                        '    While continuar

                        '        continuar = Not CalcularPeriodos(dtProporcionesVacaciones.Select("", "periodo desc")(0))

                        '    End While

                        '    SaldoFinal = CalcularSaldoFinal(dtProporcionesVacaciones, DiasVacacionesTomadas)
                        '    CrearTablaSaldosVacaciones(dtProporcionesVacaciones, DiasVacacionesTomadas, SaldoFinal)

                        'End If

                        dtProporcionesVacaciones.Rows.Add(drProporcion)

                        While continuar

                            continuar = Not CalcularPeriodos(dtProporcionesVacaciones.Select("", "periodo desc")(0))

                        End While

                        SaldoFinal = CalcularSaldoFinal(dtProporcionesVacaciones, DiasVacacionesTomadas)
                        CrearTablaSaldosVacaciones(dtProporcionesVacaciones, DiasVacacionesTomadas, SaldoFinal)

                    Else
                        'Sino es un registro nuevo
                        If dtVacacionesAniversario.Columns.Contains("ERROR") Then
                            dtProporcionesVacaciones.Dispose()
                            dtProporcionesVacaciones = Nothing
                        ElseIf dtVacacionesAniversario.Rows.Count > 0 Then

                            Try

                                drEmpleado = Nothing
                                drEmpleado = dtEmpleado.Rows(0)

                                Dim drVacAniversario As DataRow = dtVacacionesAniversario.Rows(0)
                                drProporcion = Nothing

                                drProporcion = dtProporcionesVacaciones.NewRow

                                'drProporcion("cod_comp") = Trim(IIf(IsDBNull(drVacAniversario("cod_comp")), "", drVacAniversario("cod_comp")))
                                drProporcion("cod_comp") = Trim(IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp")))

                                Try
                                    drProporcion("especial") = Trim(IIf(IsDBNull(drVacAniversario("especial")), "", drVacAniversario("especial")))
                                Catch ex As Exception

                                End Try

                                'drProporcion("reloj") = Trim(IIf(IsDBNull(drVacAniversario("reloj")), "", drVacAniversario("reloj")))
                                drProporcion("reloj") = Trim(IIf(IsDBNull(drEmpleado("reloj")), "", drEmpleado("reloj")))
                                'drProporcion("nombres") = Trim(IIf(IsDBNull(drVacAniversario("nombres")), "", drVacAniversario("nombres")))
                                drProporcion("nombres") = Trim(IIf(IsDBNull(drEmpleado("nombres")), "", drEmpleado("nombres")))
                                'drProporcion("cod_tipo") = Trim(IIf(IsDBNull(drVacAniversario("cod_tipo")), "", drVacAniversario("cod_tipo")))
                                drProporcion("cod_tipo") = Trim(IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo")))
                                'Dim lcl_cod_clase As String = Trim(IIf(IsDBNull(drVacAniversario("cod_clase")), "", drVacAniversario("cod_clase")))
                                Dim lcl_cod_clase As String = Trim(IIf(IsDBNull(drEmpleado("cod_clase")), "", drEmpleado("cod_clase")))
                                drProporcion("cod_clase") = lcl_cod_clase
                                'drProporcion("cod_depto") = Trim(IIf(IsDBNull(drVacAniversario("cod_depto")), "", drVacAniversario("cod_depto")))
                                drProporcion("cod_depto") = Trim(IIf(IsDBNull(drEmpleado("cod_depto")), "", drEmpleado("cod_depto")))

                                If IsDBNull(drVacAniversario("aniversario")) Then
                                    drProporcion("aniversario") = ""
                                Else
                                    drProporcion("aniversario") = CDate(drVacAniversario("aniversario")).ToString("yyyy-MM-dd")
                                End If

                                'alta = Date.Parse(drVacAniversario("alta").ToString)
                                'alta_antiguedad = Date.Parse(IIf(IsDBNull(drVacAniversario("alta_antiguedad")), alta, drVacAniversario("alta_antiguedad")).ToString)

                                alta = Date.Parse(drEmpleado("alta").ToString)
                                alta_antiguedad = Date.Parse(IIf(IsDBNull(drEmpleado("alta_vacacion")), alta, drEmpleado("alta_vacacion")).ToString)

                                drProporcion("alta") = alta.ToString("yyyy-MM-dd")
                                drProporcion("alta_antiguedad") = alta_antiguedad.ToString("yyyy-MM-dd")

                                EsCambioTipoEmpleado = False
                                cambio_fecha_tipo_emp = Nothing
                                cod_tipo = drProporcion("cod_tipo")

                                'Try
                                '    If Not IsDBNull(drVacAniversario("cod_tipo_anterior")) And Not IsDBNull(drVacAniversario("fecha_cambio_tipo_emp")) Then
                                '        cod_tipo = drVacAniversario("cod_tipo_anterior").ToString
                                '        drProporcion("cod_tipo_anterior") = cod_tipo
                                '        cambio_fecha_tipo_emp = CDate(drVacAniversario("fecha_cambio_tipo_emp"))
                                '        drProporcion("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")
                                '        EsCambioTipoEmpleado = True
                                '    Else
                                '        drProporcion("cod_tipo_anterior") = ""
                                '        drProporcion("fecha_cambio_tipo_emp") = ""
                                '        EsCambioTipoEmpleado = False
                                '    End If
                                'Catch ex As Exception
                                '    drProporcion("cod_tipo_anterior") = ""
                                '    drProporcion("fecha_cambio_tipo_emp") = ""
                                '    EsCambioTipoEmpleado = False
                                '    cod_tipo = drProporcion("cod_tipo")
                                'End Try

                                Try
                                    cod_tipo = dtCambioTipoEmpleado.Rows(0)("valoranterior").ToString.Trim
                                    cambio_fecha_tipo_emp = CDate(dtCambioTipoEmpleado.Rows(0)("fecha"))
                                    EsCambioTipoEmpleado = True
                                Catch ex As Exception
                                    EsCambioTipoEmpleado = False
                                    cambio_fecha_tipo_emp = Nothing
                                    cod_tipo = drProporcion("cod_tipo")
                                    drProporcion("cod_tipo_anterior") = ""
                                    drProporcion("fecha_cambio_tipo_emp") = ""
                                End Try

                                'Try
                                '    If Not IsDBNull(drVacAniversario("baja")) Then drProporcion("baja") = CDate(drVacAniversario("baja")).ToString("yyyy-MM-dd")
                                'Catch ex As Exception
                                '    drProporcion("baja") = ""
                                'End Try

                                Try
                                    If Not IsDBNull(drEmpleado("baja")) Then drProporcion("baja") = CDate(drEmpleado("baja")).ToString("yyyy-MM-dd")
                                Catch ex As Exception
                                    drProporcion("baja") = ""
                                End Try

                                'If IsDBNull(drVacAniversario("sueldo")) Then
                                '    drProporcion("sueldo") = 0.0
                                'Else
                                '    drProporcion("sueldo") = CDec(drVacAniversario("sueldo").ToString)
                                'End If

                                If IsDBNull(drEmpleado("sactual")) Then
                                    drProporcion("sueldo") = 0.0
                                Else
                                    drProporcion("sueldo") = CDec(drEmpleado("sactual").ToString)
                                End If

                                If IsDBNull(drVacAniversario("antig_16_feb_2018")) Then
                                    drProporcion("antig_16_feb_2018") = 0.0
                                Else
                                    drProporcion("antig_16_feb_2018") = CDec(drVacAniversario("antig_16_feb_2018").ToString)
                                End If

                                If IsDBNull(drVacAniversario("saldo_inicial")) Then
                                    drProporcion("saldo_inicial") = 0.0
                                Else
                                    drProporcion("saldo_inicial") = CDec(drVacAniversario("saldo_inicial").ToString)
                                End If

                                drProporcion("periodo") = 1

                                Dim fecha_inicial As Date = fecha_inicio

                                'If alta < fecha_inicial Then

                                '    If alta.Month = 2 And alta.Day > 16 Then
                                '        Dim agregarDias As Integer = alta.Day - fecha_inicial.Day
                                '        fecha_inicial = fecha_inicial.AddDays(agregarDias)
                                '    End If

                                'End If

                                Dim per_ini As Date? = Calculo_Periodo1_Inicio(alta, fecha_inicial, True).Value
                                per_ini = IIf(per_ini.Value = Nothing, Nothing, per_ini.Value)

                                If per_ini.HasValue Then
                                    periodo1_inicio = CDate(per_ini.Value)
                                Else
                                    Exit Sub
                                End If

                                drProporcion("periodo_inicio") = periodo1_inicio.ToString("yyyy-MM-dd")

                                Dim per_fin As Date? = Calculo_Periodo1_Fin(periodo1_inicio, alta_antiguedad, fecha_corte).Value
                                per_fin = IIf(per_fin.Value = Nothing, Nothing, per_fin.Value)

                                If per_fin.HasValue Then
                                    periodo1_fin = CDate(per_fin.Value)
                                Else
                                    Exit Sub
                                End If

                                If EsCambioTipoEmpleado Then
                                    If cambio_fecha_tipo_emp >= periodo1_inicio And cambio_fecha_tipo_emp <= periodo1_fin Then
                                        periodo1_fin = cambio_fecha_tipo_emp.AddDays(-1)
                                        drProporcion("cod_tipo_anterior") = cod_tipo
                                        drProporcion("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")
                                    ElseIf cambio_fecha_tipo_emp < periodo1_inicio Then
                                        cod_tipo = drProporcion("cod_tipo")
                                        drProporcion("cod_tipo_anterior") = ""
                                        drProporcion("fecha_cambio_tipo_emp") = ""
                                    ElseIf cambio_fecha_tipo_emp > periodo1_fin Then
                                        drProporcion("cod_tipo_anterior") = cod_tipo
                                        drProporcion("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")
                                    Else
                                        cod_tipo = drProporcion("cod_tipo")
                                        drProporcion("cod_tipo_anterior") = ""
                                        drProporcion("fecha_cambio_tipo_emp") = ""
                                    End If
                                Else
                                    cod_tipo = drProporcion("cod_tipo")
                                    drProporcion("cod_tipo_anterior") = ""
                                    drProporcion("fecha_cambio_tipo_emp") = ""
                                End If

                                drProporcion("periodo_fin") = periodo1_fin.ToString("yyyy-MM-dd")

                                Dim periodo1_dias As Integer = DateDiff(DateInterval.Day, periodo1_inicio, periodo1_fin) + 1

                                drProporcion("periodo_dias") = periodo1_dias

                                'Dim Periodo1_dias_anteriores As Integer = IIf(alta < fecha_inicio, 20, 0)
                                'Dim Periodo1_dias_cotizados As Integer = DateDiff(DateInterval.Day, alta_antiguedad, periodo1_fin) - Periodo1_dias_anteriores
                                ' Dim Periodo1_Antiguedad As Integer = Int((CDec(Periodo1_dias_cotizados) / 365D)) + 1

                                Dim Periodo1_Antiguedad As Integer = DiferenciaFecha(alta_antiguedad, periodo1_fin) + 1

                                Dim Periodo1_Corresponden As Integer = 0

                                drProporcion("periodo_antiguedad") = Periodo1_Antiguedad

                                Try

                                    Dim drVacaciones() As DataRow = Nothing
                                    drVacaciones = dtVacacionesEspeciales.Select("cod_comp = '" & drProporcion("cod_comp") & "' and cod_tipo = '" & cod_tipo & "' and reloj = '" & _reloj & "' and anos <= " & Periodo1_Antiguedad.ToString, "anos desc")
                                    Dim Vacaciones_Especiales As Boolean = False

                                    If Not (drVacaciones Is Nothing) Then
                                        If drVacaciones.Count > 0 Then
                                            Vacaciones_Especiales = True
                                            Periodo1_Corresponden = drVacaciones(0)("dias")
                                        End If
                                    End If

                                    If Vacaciones_Especiales Then
                                        Try
                                            drProporcion("especial") = "si"
                                        Catch ex As Exception

                                        End Try
                                    End If

                                    drVacaciones = Nothing
                                    If Not Vacaciones_Especiales Then

                                        If EsCambioTipoEmpleado Then
                                            drVacaciones = dtVacacionesBeneficios.Select("cod_comp = '" & drProporcion("cod_comp") & "' and cod_tipo = '" & cod_tipo & "' and anos <= " & Periodo1_Antiguedad.ToString, "anos desc")
                                        Else
                                            drVacaciones = dtVacacionesBeneficios.Select("cod_comp = '" & drProporcion("cod_comp") & "' and cod_tipo = '" & IIf(lcl_cod_clase.Trim.ToUpper = "G" Or lcl_cod_clase.Trim.ToUpper = "R", "G", cod_tipo) & "' and anos <= " & Periodo1_Antiguedad.ToString, "anos desc")
                                        End If

                                        If Not (drVacaciones Is Nothing) Then
                                            If drVacaciones.Count > 0 Then
                                                Periodo1_Corresponden = drVacaciones(0)("dias")
                                            End If
                                        End If
                                    End If

                                Catch ex As Exception
                                    TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
                                    Periodo1_Corresponden = 0
                                End Try

                                drProporcion("periodo_corresponden") = Periodo1_Corresponden

                                Dim dias_anio As Decimal = CDec(IIf(periodo1_dias = 366, 366, 365))
                                Dim periodo1_proporcion As Decimal = Math.Round(((CDec(Periodo1_Corresponden) / dias_anio) * periodo1_dias), 2)

                                drProporcion("periodo_proporcion") = periodo1_proporcion

                                drProporcion("dias_tomados") = 0.0
                                'If IsDBNull(drVacAniversario("dias_tomados")) Then
                                '    drProporcion("dias_tomados") = 0.0
                                'Else
                                '    drProporcion("dias_tomados") = CDec(drVacAniversario("dias_tomados").ToString)
                                'End If

                                drProporcion("saldo_final") = 0.0

                                'If IsDBNull(drVacAniversario("saldo_final")) Then
                                '    drProporcion("saldo_final") = 0.0
                                'Else
                                '    drProporcion("saldo_final") = CDec(drVacAniversario("saldo_final").ToString)
                                'End If

                                If IsDBNull(drVacAniversario("tipo_registro")) Then
                                    drProporcion("tipo_registro") = ""
                                Else
                                    drProporcion("tipo_registro") = drVacAniversario("tipo_registro").ToString.Trim
                                End If

                                If IsDBNull(drVacAniversario("comentarios")) Then
                                    drProporcion("comentarios") = ""
                                Else
                                    drProporcion("comentarios") = drVacAniversario("comentarios").ToString.Trim
                                End If

                                If IsDBNull(drVacAniversario("fecha_creacion")) Then
                                    drProporcion("fecha_creacion") = ""
                                Else
                                    drProporcion("fecha_creacion") = CDate(drVacAniversario("fecha_creacion")).ToString("yyyy-MM-dd")
                                End If

                                dtProporcionesVacaciones.Rows.Add(drProporcion)

                                While continuar

                                    continuar = Not CalcularPeriodos(dtProporcionesVacaciones.Select("", "periodo desc")(0))

                                End While

                                SaldoFinal = CalcularSaldoFinal(dtProporcionesVacaciones, DiasVacacionesTomadas)
                                CrearTablaSaldosVacaciones(dtProporcionesVacaciones, DiasVacacionesTomadas, SaldoFinal)

                            Catch ex As Exception
                                TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
                                dtProporcionesVacaciones.Dispose()
                                dtProporcionesVacaciones = Nothing
                            End Try
                        Else
                            dtProporcionesVacaciones.Dispose()
                            dtProporcionesVacaciones = Nothing
                        End If

                    End If
                End If
            End If

        Catch ex As Exception
            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
            dtProporcionesVacaciones.Dispose()
            dtProporcionesVacaciones = Nothing
        End Try
    End Sub

    Private Function Calculo_Periodo1_Inicio(ByVal fecha_anterior As Date, fha_corte As Date, Optional ByVal EsPrimerPeriodo As Boolean = False) As Date?

        Dim periodo_inicio As Date? = Nothing

        Try
            If EsPrimerPeriodo Then
                periodo_inicio = IIf(fecha_anterior > fha_corte, fecha_anterior, fha_corte)
            Else

                If fecha_anterior.AddDays(1) <= fha_corte Then
                    periodo_inicio = fecha_anterior.AddDays(1)

                Else
                    periodo_inicio = Nothing
                End If

            End If

        Catch ex As Exception
            periodo_inicio = Nothing
        End Try

        Return periodo_inicio

    End Function

    Private Function Calculo_Periodo1_Fin(ByVal fha_perido_inicio As Date, fha_antiguedad As Date, fha_corte As Date) As Date?

        Dim periodo_fin As Date? = Nothing

        Try

            Dim fecha_tmp As Date = DateSerial(fha_perido_inicio.Year, fha_antiguedad.Month, fha_antiguedad.Day).AddDays(-1)

            If fecha_tmp < fha_perido_inicio Then
                fecha_tmp = DateSerial(fha_perido_inicio.Year + 1, fha_antiguedad.Month, fha_antiguedad.Day).AddDays(-1)
            Else
                fecha_tmp = DateSerial(fha_perido_inicio.Year, fha_antiguedad.Month, fha_antiguedad.Day).AddDays(-1)
            End If

            If fecha_tmp > fha_corte Then
                fecha_tmp = fha_corte
            Else

                fecha_tmp = DateSerial(fha_perido_inicio.Year, fha_antiguedad.Month, fha_antiguedad.Day).AddDays(-1)

                If fecha_tmp < fha_perido_inicio Then
                    fecha_tmp = DateSerial(fha_perido_inicio.Year + 1, fha_antiguedad.Month, fha_antiguedad.Day).AddDays(-1)
                Else
                    fecha_tmp = DateSerial(fha_perido_inicio.Year, fha_antiguedad.Month, fha_antiguedad.Day).AddDays(-1)
                End If

            End If

            periodo_fin = fecha_tmp

        Catch ex As Exception
            periodo_fin = Nothing
        End Try

        Return periodo_fin

    End Function

    'Private Sub RegistroInicial()

    '    Dim drProporcion As DataRow = Nothing
    '    Dim periodo1_inicio As Date = Nothing
    '    Dim periodo1_fin As Date = Nothing
    '    Dim alta As Date = Nothing
    '    Dim alta_antiguedad As Date = Nothing
    '    Dim cambio_fecha_tipo_emp As Date = Nothing
    '    Dim EsCambioTipoEmpleado As Boolean = False
    '    Dim cod_tipo As String = ""
    '    Dim drEmpleado As DataRow = Nothing
    '    Dim continuar As Boolean = True

    '    Try

    '        'Revisa si en la base de datos ya existe un registro de vacaciones aniversario del empleado
    '        'con la misma fecha de alta del mismo
    '        CargarVacacionesAniversario(dtEmpleado.Rows(0))

    '        If Not dtProporcionesVacaciones Is Nothing Then

    '            If Not dtProporcionesVacaciones.Columns.Contains("ERROR") Then

    '                If dtProporcionesVacaciones.Rows.Count > 0 Then

    '                    While continuar

    '                        continuar = Not CalcularPeriodos(dtProporcionesVacaciones.Select("", "periodo desc")(0))

    '                    End While

    '                    SaldoFinal = CalcularSaldoFinal(dtProporcionesVacaciones, DiasVacacionesTomadas)
    '                    CrearTablaSaldosVacaciones(dtProporcionesVacaciones, DiasVacacionesTomadas, SaldoFinal)
    '                Else

    '                    drEmpleado = dtEmpleado.Rows(0)

    '                    drProporcion = dtProporcionesVacaciones.NewRow

    '                    drProporcion("cod_comp") = Trim(IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp")))

    '                    Try
    '                        drProporcion("especial") = ""
    '                    Catch ex As Exception

    '                    End Try

    '                    drProporcion("reloj") = Trim(IIf(IsDBNull(drEmpleado("reloj")), "", drEmpleado("reloj")))
    '                    drProporcion("nombres") = Trim(IIf(IsDBNull(drEmpleado("nombres")), "", drEmpleado("nombres")))
    '                    drProporcion("cod_tipo") = Trim(IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo")))

    '                    Dim lcl_cod_clase As String = Trim(IIf(IsDBNull(drEmpleado("cod_clase")), "", drEmpleado("cod_clase")))

    '                    drProporcion("cod_clase") = lcl_cod_clase
    '                    drProporcion("cod_depto") = Trim(IIf(IsDBNull(drEmpleado("cod_depto")), "", drEmpleado("cod_depto")))
    '                    drProporcion("aniversario") = ""

    '                    alta = Date.Parse(drEmpleado("alta").ToString)
    '                    alta_antiguedad = Date.Parse(IIf(IsDBNull(drEmpleado("alta_vacacion")), alta, drEmpleado("alta_vacacion")).ToString)

    '                    drProporcion("alta") = alta.ToString("yyyy-MM-dd")
    '                    drProporcion("alta_antiguedad") = alta_antiguedad.ToString("yyyy-MM-dd")

    '                    Try

    '                        cod_tipo = dtCambioTipoEmpleado.Rows(0)("valoranterior").ToString.Trim
    '                        ' drProporcion("cod_tipo_anterior") = cod_tipo

    '                        cambio_fecha_tipo_emp = CDate(dtCambioTipoEmpleado.Rows(0)("fecha"))
    '                        ' drProporcion("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")

    '                        EsCambioTipoEmpleado = True

    '                    Catch ex As Exception
    '                        EsCambioTipoEmpleado = False
    '                        cambio_fecha_tipo_emp = Nothing
    '                        cod_tipo = drProporcion("cod_tipo")
    '                        drProporcion("cod_tipo_anterior") = ""
    '                        drProporcion("fecha_cambio_tipo_emp") = ""
    '                    End Try

    '                    Try
    '                        drProporcion("baja") = CDate(drEmpleado("baja")).ToString("yyyy-MM-dd")
    '                    Catch ex As Exception
    '                        drProporcion("baja") = ""
    '                    End Try

    '                    drProporcion("sueldo") = IIf(IsDBNull(drEmpleado("sactual")), 0.0, drEmpleado("sactual"))
    '                    drProporcion("antig_16_feb_2018") = 0.0
    '                    drProporcion("saldo_inicial") = 0.0
    '                    drProporcion("periodo") = 1

    '                    periodo1_inicio = IIf(alta > fecha_inicio, alta, fecha_inicio)

    '                    drProporcion("periodo_inicio") = periodo1_inicio.ToString("yyyy-MM-dd")

    '                    Dim fecha_tmp As Date = DateSerial(periodo1_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)

    '                    If fecha_tmp < periodo1_inicio Then
    '                        fecha_tmp = DateSerial(periodo1_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddYears(1).AddDays(-1)
    '                    Else
    '                        fecha_tmp = DateSerial(periodo1_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)
    '                    End If

    '                    If fecha_tmp > fecha_corte Then
    '                        fecha_tmp = fecha_corte
    '                    Else

    '                        fecha_tmp = DateSerial(periodo1_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)

    '                        If fecha_tmp < periodo1_inicio Then
    '                            fecha_tmp = DateSerial(periodo1_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddYears(1).AddDays(-1)
    '                        Else
    '                            fecha_tmp = DateSerial(periodo1_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)
    '                        End If

    '                    End If

    '                    periodo1_fin = fecha_tmp

    '                    If EsCambioTipoEmpleado Then
    '                        If cambio_fecha_tipo_emp >= periodo1_inicio And cambio_fecha_tipo_emp <= periodo1_fin Then
    '                            periodo1_fin = cambio_fecha_tipo_emp.AddDays(-1)
    '                            drProporcion("cod_tipo_anterior") = cod_tipo
    '                            drProporcion("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")
    '                        Else
    '                            ' cod_tipo = drProporcion("cod_tipo")
    '                            drProporcion("cod_tipo_anterior") = cod_tipo
    '                            drProporcion("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")
    '                        End If
    '                    Else
    '                        cod_tipo = drProporcion("cod_tipo")
    '                        drProporcion("cod_tipo_anterior") = ""
    '                        drProporcion("fecha_cambio_tipo_emp") = ""
    '                    End If

    '                    drProporcion("periodo_fin") = periodo1_fin.ToString("yyyy-MM-dd")
    '                    Dim periodo1_dias As Integer = DateDiff(DateInterval.Day, periodo1_inicio, periodo1_fin) + 1
    '                    drProporcion("periodo_dias") = periodo1_dias

    '                    Dim Periodo1_dias_anteriores As Integer = IIf(alta < fecha_inicio, 20, 0)
    '                    Dim Periodo1_dias_cotizados As Integer = DateDiff(DateInterval.Day, alta_antiguedad, periodo1_fin) - Periodo1_dias_anteriores
    '                    Dim Periodo1_Antiguedad As Integer = Int((CDec(Periodo1_dias_cotizados) / 365D)) + 1
    '                    Dim Periodo1_Corresponden As Integer = 0

    '                    drProporcion("periodo_antiguedad") = Periodo1_Antiguedad

    '                    Try

    '                        Dim drVacaciones() As DataRow = Nothing
    '                        drVacaciones = dtVacacionesEspeciales.Select("cod_comp = '" & drProporcion("cod_comp") & "' and cod_tipo = '" & cod_tipo & "' and reloj = '" & _reloj & "' and anos <= " & Periodo1_Antiguedad.ToString, "anos desc")
    '                        Dim Vacaciones_Especiales As Boolean = False

    '                        If Not (drVacaciones Is Nothing) Then
    '                            If drVacaciones.Count > 0 Then
    '                                Vacaciones_Especiales = True
    '                                Periodo1_Corresponden = drVacaciones(0)("dias")
    '                            End If
    '                        End If

    '                        If Vacaciones_Especiales Then
    '                            Try
    '                                drProporcion("especial") = "si"
    '                            Catch ex As Exception

    '                            End Try
    '                        End If

    '                        drVacaciones = Nothing
    '                        If Not Vacaciones_Especiales Then

    '                            If EsCambioTipoEmpleado Then
    '                                drVacaciones = dtVacacionesBeneficios.Select("cod_comp = '" & drProporcion("cod_comp") & "' and cod_tipo = '" & cod_tipo & "' and anos <= " & Periodo1_Antiguedad.ToString, "anos desc")
    '                            Else
    '                                drVacaciones = dtVacacionesBeneficios.Select("cod_comp = '" & drProporcion("cod_comp") & "' and cod_tipo = '" & IIf(lcl_cod_clase.Trim.ToUpper = "G" Or lcl_cod_clase.Trim.ToUpper = "R", "G", cod_tipo) & "' and anos <= " & Periodo1_Antiguedad.ToString, "anos desc")
    '                            End If

    '                            If Not (drVacaciones Is Nothing) Then
    '                                If drVacaciones.Count > 0 Then
    '                                    Periodo1_Corresponden = drVacaciones(0)("dias")
    '                                End If
    '                            End If
    '                        End If

    '                    Catch ex As Exception
    '                        TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
    '                        Periodo1_Corresponden = 0
    '                    End Try

    '                    drProporcion("periodo_corresponden") = Periodo1_Corresponden

    '                    Dim dias_anio As Decimal = CDec(IIf(periodo1_dias = 366, 366, 365))
    '                    Dim periodo1_proporcion As Decimal = Math.Round(((CDec(Periodo1_Corresponden) / dias_anio) * periodo1_dias), 2)

    '                    drProporcion("saldo_inicial") = 0
    '                    drProporcion("periodo_proporcion") = periodo1_proporcion
    '                    drProporcion("dias_tomados") = 0
    '                    drProporcion("tipo_registro") = "N"
    '                    drProporcion("comentarios") = "NUEVO CALCULO"

    '                    dtProporcionesVacaciones.Rows.Add(drProporcion)

    '                    While continuar

    '                        continuar = Not CalcularPeriodos(dtProporcionesVacaciones.Select("", "periodo desc")(0))

    '                    End While

    '                    SaldoFinal = CalcularSaldoFinal(dtProporcionesVacaciones, DiasVacacionesTomadas)
    '                    CrearTablaSaldosVacaciones(dtProporcionesVacaciones, DiasVacacionesTomadas, SaldoFinal)
    '                End If

    '            End If

    '        End If

    '    Catch ex As Exception
    '        TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
    '    End Try

    'End Sub

    Private Function CalcularPeriodos(ByVal drPeriodoAnterior As DataRow) As Boolean

        Dim Terminado As Boolean = False

        Dim periodo_inicio_anterior As Date = Nothing
        Dim periodo_fin_anterior As Date = Nothing
        Dim periodo_antiguedad_anterior = 0

        Dim periodo_inicio As Date = Nothing
        Dim PeriodoInicio As Boolean = False

        Dim periodo_fin As Date = Nothing

        Dim alta As Date = Nothing
        Dim alta_antiguedad As Date = Nothing
        Dim cambio_fecha_tipo_emp As Date = Nothing
        Dim EsCambioTipoEmpleado As Boolean = False

        Dim fecha_tmp As Date = Nothing

        Dim cod_tipo As String = ""
        Dim lcl_cod_clase As String = ""

        Dim periodo_anterior As Integer = 0

        Dim periodo_dias As Integer = 0

        Dim Periodo_dias_cotizados As Integer = 0
        Dim Periodo_Antiguedad As Integer = 0
        Dim Periodo_Corresponden As Integer = 0
        Dim dias_anio As Decimal = 0D
        Dim periodo_proporcion As Decimal = 0D

        Try

            If Not drPeriodoAnterior Is Nothing Then

                alta = CDate(drPeriodoAnterior("alta").ToString)
                alta_antiguedad = CDate(drPeriodoAnterior("alta_antiguedad").ToString)

                lcl_cod_clase = Trim(IIf(IsDBNull(drPeriodoAnterior("cod_clase")), "", drPeriodoAnterior("cod_clase")))

                periodo_fin_anterior = CDate(drPeriodoAnterior("periodo_fin").ToString)

                periodo_anterior = Integer.Parse(drPeriodoAnterior("periodo").ToString)
                periodo_antiguedad_anterior = Integer.Parse(drPeriodoAnterior("periodo_antiguedad").ToString)

                'Primera parte para calcular el periodo inicial del siguiente ciclo
                If periodo_fin_anterior.AddDays(1) <= fecha_corte Then
                    periodo_inicio = periodo_fin_anterior.AddDays(1)
                    PeriodoInicio = True
                Else
                    periodo_inicio = Nothing
                    PeriodoInicio = False
                End If

                'Segunda parte para calcular el periodo final
                If PeriodoInicio Then

                    fecha_tmp = DateSerial(periodo_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)

                    If fecha_tmp < periodo_inicio Then
                        fecha_tmp = DateSerial(periodo_inicio.Year + 1, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)
                    Else
                        fecha_tmp = DateSerial(periodo_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)
                    End If

                    If fecha_tmp > fecha_corte Then
                        fecha_tmp = fecha_corte
                    Else

                        fecha_tmp = DateSerial(periodo_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)

                        If fecha_tmp < periodo_inicio Then
                            fecha_tmp = DateSerial(periodo_inicio.Year + 1, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)
                        Else
                            fecha_tmp = DateSerial(periodo_inicio.Year, alta_antiguedad.Month, alta_antiguedad.Day).AddDays(-1)
                        End If

                    End If

                    periodo_fin = fecha_tmp

                    Try
                        Dim CambioDato As String = Trim(IIf(IsDBNull(drPeriodoAnterior("fecha_cambio_tipo_emp")), "", drPeriodoAnterior("fecha_cambio_tipo_emp")))
                        If CambioDato <> "" Then
                            cambio_fecha_tipo_emp = CDate(drPeriodoAnterior("fecha_cambio_tipo_emp")).ToString("yyyy-MM-dd")
                            EsCambioTipoEmpleado = True
                        Else
                            EsCambioTipoEmpleado = False
                            cambio_fecha_tipo_emp = Nothing
                        End If

                    Catch ex As Exception
                        EsCambioTipoEmpleado = False
                        cambio_fecha_tipo_emp = Nothing
                    End Try


                    'If EsCambioTipoEmpleado Then
                    '    If cambio_fecha_tipo_emp >= periodo_inicio And cambio_fecha_tipo_emp <= periodo_fin Then
                    '        periodo_fin = cambio_fecha_tipo_emp.AddDays(-1)
                    '    Else
                    '        cod_tipo = drPeriodoAnterior("cod_tipo")
                    '        periodo_antiguedad_anterior = periodo_antiguedad_anterior + 1

                    '    End If
                    'Else
                    '    cod_tipo = drPeriodoAnterior("cod_tipo")
                    '    periodo_antiguedad_anterior = periodo_antiguedad_anterior + 1
                    'End If

                    Dim EsAgregado As Boolean = True
                    Dim drAgregar = dtProporcionesVacaciones.NewRow

                    drAgregar("cod_comp") = Trim(IIf(IsDBNull(drPeriodoAnterior("cod_comp")), "", drPeriodoAnterior("cod_comp")))

                    Try
                        drAgregar("especial") = Trim(IIf(IsDBNull(drPeriodoAnterior("especial")), "", drPeriodoAnterior("especial")))
                    Catch ex As Exception

                    End Try

                    drAgregar("reloj") = Trim(IIf(IsDBNull(drPeriodoAnterior("reloj")), "", drPeriodoAnterior("reloj")))
                    drAgregar("nombres") = Trim(IIf(IsDBNull(drPeriodoAnterior("nombres")), "", drPeriodoAnterior("nombres")))
                    drAgregar("cod_tipo") = Trim(IIf(IsDBNull(drPeriodoAnterior("cod_tipo")), "", drPeriodoAnterior("cod_tipo")))
                    drAgregar("cod_clase") = Trim(IIf(IsDBNull(drPeriodoAnterior("cod_clase")), "", drPeriodoAnterior("cod_clase")))
                    drAgregar("cod_depto") = Trim(IIf(IsDBNull(drPeriodoAnterior("cod_depto")), "", drPeriodoAnterior("cod_depto")))

                    If EsCambioTipoEmpleado Then

                        If periodo_inicio = cambio_fecha_tipo_emp Then
                            cod_tipo = drAgregar("cod_tipo")
                            drAgregar("cod_tipo_anterior") = ""
                            drAgregar("fecha_cambio_tipo_emp") = ""

                        ElseIf cambio_fecha_tipo_emp >= periodo_inicio And cambio_fecha_tipo_emp <= periodo_fin Then
                            periodo_fin = cambio_fecha_tipo_emp.AddDays(-1)
                            cod_tipo = drPeriodoAnterior("cod_tipo_anterior").ToString.Trim
                            drAgregar("cod_tipo_anterior") = cod_tipo
                            drAgregar("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")
                            periodo_antiguedad_anterior = periodo_antiguedad_anterior + 1
                        ElseIf cambio_fecha_tipo_emp > periodo_fin Then
                            cod_tipo = drPeriodoAnterior("cod_tipo_anterior").ToString.Trim
                            drAgregar("cod_tipo_anterior") = cod_tipo
                            drAgregar("fecha_cambio_tipo_emp") = cambio_fecha_tipo_emp.ToString("yyyy-MM-dd")
                            periodo_antiguedad_anterior = periodo_antiguedad_anterior + 1
                        Else
                            EsAgregado = False
                        End If

                    Else

                        cod_tipo = drAgregar("cod_tipo")
                        drAgregar("cod_tipo_anterior") = ""
                        drAgregar("fecha_cambio_tipo_emp") = ""
                        periodo_antiguedad_anterior = periodo_antiguedad_anterior + 1
                    End If

                    If EsAgregado Then

                        Try : drAgregar("aniversario") = CDate(drPeriodoAnterior("aniversario")).ToString("yyyy-MM-dd") : Catch ex As Exception : drAgregar("aniversario") = "" : End Try

                        drAgregar("alta") = CDate(drPeriodoAnterior("alta")).ToString("yyyy-MM-dd")
                        drAgregar("alta_antiguedad") = CDate(drPeriodoAnterior("alta_antiguedad")).ToString("yyyy-MM-dd")

                        Try : drAgregar("baja") = CDate(drPeriodoAnterior("baja")).ToString("yyyy-MM-dd") : Catch ex As Exception : drAgregar("baja") = "" : End Try

                        drAgregar("sueldo") = IIf(IsDBNull(drPeriodoAnterior("sueldo")), 0.0, drPeriodoAnterior("sueldo"))
                        drAgregar("antig_16_feb_2018") = 0.0
                        drAgregar("saldo_inicial") = 0.0
                        drAgregar("periodo") = periodo_anterior + 1

                        drAgregar("periodo_inicio") = periodo_inicio.ToString("yyyy-MM-dd")
                        drAgregar("periodo_fin") = periodo_fin.ToString("yyyy-MM-dd")

                        periodo_dias = DateDiff(DateInterval.Day, periodo_inicio, periodo_fin) + 1
                        drAgregar("periodo_dias") = periodo_dias

                        Periodo_dias_cotizados = DateDiff(DateInterval.Day, alta_antiguedad, periodo_fin)
                        'Periodo_Antiguedad = Int((CDec(Periodo_dias_cotizados) / 365D)) + 1
                        Periodo_Antiguedad = periodo_antiguedad_anterior

                        drAgregar("periodo_antiguedad") = Periodo_Antiguedad

                        Try

                            Dim drVacaciones() As DataRow = Nothing
                            drVacaciones = dtVacacionesEspeciales.Select("cod_comp = '" & drPeriodoAnterior("cod_comp") & "' and cod_tipo = '" & cod_tipo & "' and reloj = '" & _reloj & "' and anos <= " & Periodo_Antiguedad.ToString, "anos desc")
                            Dim Vacaciones_Especiales As Boolean = False

                            If Not (drVacaciones Is Nothing) Then
                                If drVacaciones.Count > 0 Then
                                    Vacaciones_Especiales = True
                                    Periodo_Corresponden = drVacaciones(0)("dias")
                                End If
                            End If

                            If Vacaciones_Especiales Then
                                Try
                                    drAgregar("especial") = "si"
                                Catch ex As Exception

                                End Try
                            End If

                            drVacaciones = Nothing
                            If Not Vacaciones_Especiales Then

                                If EsCambioTipoEmpleado Then
                                    drVacaciones = dtVacacionesBeneficios.Select("cod_comp = '" & drPeriodoAnterior("cod_comp") & "' and cod_tipo = '" & cod_tipo & "' and anos <= " & Periodo_Antiguedad.ToString, "anos desc")
                                Else
                                    drVacaciones = dtVacacionesBeneficios.Select("cod_comp = '" & drPeriodoAnterior("cod_comp") & "' and cod_tipo = '" & IIf(lcl_cod_clase.ToUpper = "G" Or lcl_cod_clase.ToUpper = "R", "G", cod_tipo) & "' and anos <= " & Periodo_Antiguedad.ToString, "anos desc")
                                End If

                                If Not (drVacaciones Is Nothing) Then
                                    If drVacaciones.Count > 0 Then
                                        Periodo_Corresponden = drVacaciones(0)("dias")
                                    End If
                                End If
                            End If

                        Catch ex As Exception
                            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
                            Periodo_Corresponden = 0
                            Return True
                        End Try

                        drAgregar("periodo_corresponden") = Periodo_Corresponden

                        dias_anio = CDec(IIf(periodo_dias = 366, 366, 365))
                        periodo_proporcion = Math.Round(((CDec(Periodo_Corresponden) / dias_anio) * periodo_dias), 2)

                        drAgregar("periodo_proporcion") = periodo_proporcion
                        drAgregar("dias_tomados") = 0
                        drAgregar("tipo_registro") = "N"
                        drAgregar("comentarios") = "NUEVO CALCULO"

                        dtProporcionesVacaciones.Rows.Add(drAgregar)

                    End If

                    'If EsAgregado Then
                    '    dtProporcionesVacaciones.Rows.Add(drAgregar)
                    'Else
                    '    Terminado = True
                    'End If

                Else

                    Terminado = True

                End If
            Else
                Terminado = True
            End If


        Catch ex As Exception
            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
            Terminado = True
        End Try

        Return Terminado

    End Function

    Private Function CalcularSaldoFinal(ByVal dtTablaProporciones As DataTable, ByVal DiasVacTomadas As Integer) As Decimal

        Dim var_saldo_final As Decimal = 0D

        Try

            If Not (dtTablaProporciones Is Nothing) Then
                If Not dtTablaProporciones.Columns.Contains("ERROR") Then
                    If dtTablaProporciones.Rows.Count > 0 Then

                        Dim saldo_inicial As Decimal = 0D

                        Try
                            saldo_inicial = IIf(IsDBNull(dtTablaProporciones.Select("periodo = 1")(0)("saldo_inicial")), 0, dtTablaProporciones.Select("periodo = 1")(0)("saldo_inicial"))
                        Catch ex As Exception
                            saldo_inicial = 0D
                            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
                        End Try

                        Dim total_proporcion = (From tabla In dtTablaProporciones.AsEnumerable()
                                                Select tabla.Field(Of Decimal)("periodo_proporcion")).Sum

                        Me.SaldoInicial = saldo_inicial
                        Me.AcumuladoProporcion = total_proporcion

                        var_saldo_final = (Me.AcumuladoProporcion + Me.SaldoInicial) - CDec(DiasVacTomadas)

                    End If
                End If
            End If

        Catch ex As Exception
            var_saldo_final = 0D
            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
        End Try

        Return var_saldo_final

    End Function


    Private Sub CrearTablaSaldosVacaciones(ByRef dtTablaProporciones As DataTable, ByVal DiasVacTomadas As Integer, ByVal Saldo_final_vac As Decimal)

        Try

            If Not SiCrearTablaSaldos Then Exit Sub

            If Not (dtTablaProporciones Is Nothing) Then
                If Not dtTablaProporciones.Columns.Contains("ERROR") Then
                    If dtTablaProporciones.Rows.Count > 0 Then

                        Dim drProporcion As DataRow = dtTablaProporciones.Rows(0)

                        dtSaldosVacaciones = New DataTable

                        dtSaldosVacaciones.Columns.Add("cod_comp", GetType(System.String))
                        dtSaldosVacaciones.Columns.Add("especial", GetType(System.String))
                        dtSaldosVacaciones.Columns.Add("reloj", GetType(System.String))
                        dtSaldosVacaciones.Columns.Add("nombres", GetType(System.String))
                        dtSaldosVacaciones.Columns.Add("cod_tipo", GetType(System.String))
                        dtSaldosVacaciones.Columns.Add("cod_clase", GetType(System.String))
                        dtSaldosVacaciones.Columns.Add("cod_depto", GetType(System.String))
                        dtSaldosVacaciones.Columns.Add("alta", GetType(System.String))
                        dtSaldosVacaciones.Columns.Add("alta_antiguedad", GetType(System.String))
                        dtSaldosVacaciones.Columns.Add("cambio_tipo_emp", GetType(System.String))
                        dtSaldosVacaciones.Columns.Add("baja", GetType(System.String))
                        dtSaldosVacaciones.Columns.Add("sueldo", GetType(System.Decimal))
                        dtSaldosVacaciones.Columns.Add("antiguedad_16_feb_2018", GetType(System.Decimal))
                        dtSaldosVacaciones.Columns.Add("saldo_inicial", GetType(System.Decimal))

                        Dim var_cod_comp As String = IIf(IsDBNull(drProporcion("cod_comp")), "", drProporcion("cod_comp"))

                        Dim var_especial As String = ""
                        Try
                            var_especial = IIf(IsDBNull(drProporcion("especial")), "", drProporcion("especial"))
                        Catch ex As Exception

                        End Try

                        Dim var_reloj As String = IIf(IsDBNull(drProporcion("reloj")), "", drProporcion("reloj"))
                        Dim var_nombre As String = IIf(IsDBNull(drProporcion("nombres")), "", drProporcion("nombres"))
                        Dim var_cod_tipo As String = IIf(IsDBNull(drProporcion("cod_tipo")), "", drProporcion("cod_tipo"))
                        Dim var_cod_clase As String = IIf(IsDBNull(drProporcion("cod_clase")), "", drProporcion("cod_clase"))
                        Dim var_cod_depto As String = IIf(IsDBNull(drProporcion("cod_depto")), "", drProporcion("cod_depto"))
                        Dim var_alta As String = IIf(IsDBNull(drProporcion("alta")), "", drProporcion("alta"))
                        Dim var_alta_antiguedad As String = IIf(IsDBNull(drProporcion("alta_antiguedad")), "", drProporcion("alta_antiguedad"))
                        Dim var_cambio_tipo_emp As String = IIf(IsDBNull(drProporcion("fecha_cambio_tipo_emp")), "", drProporcion("fecha_cambio_tipo_emp"))
                        Dim var_baja As String = IIf(IsDBNull(drProporcion("baja")), "", drProporcion("baja"))
                        Dim var_sueldo As Decimal = IIf(IsDBNull(drProporcion("sueldo")), 0, drProporcion("sueldo"))
                        Dim var_antiguedad_16_feb_2018 As Decimal = IIf(IsDBNull(drProporcion("antig_16_feb_2018")), 0, drProporcion("antig_16_feb_2018"))
                        Dim var_saldo_inicial As Decimal = IIf(IsDBNull(drProporcion("saldo_inicial")), 0, drProporcion("saldo_inicial"))

                        dtSaldosVacaciones.Rows.Add(var_cod_comp, var_especial, var_reloj, var_nombre, var_cod_tipo, var_cod_clase, var_cod_depto, var_alta, var_alta_antiguedad, var_cambio_tipo_emp, _
                                                    var_baja, var_sueldo, var_antiguedad_16_feb_2018, var_saldo_inicial)



                        'dtSaldosVacaciones.Rows.Add({drProporcion("cod_comp"), drProporcion("reloj"), drProporcion("nombres"), drProporcion("cod_tipo"), _
                        '                            drProporcion("cod_clase"), drProporcion("cod_depto"), drProporcion("alta"), drProporcion("alta_antiguedad"), _
                        '                             drProporcion("cambio_tipo_emp"), drProporcion("baja"), drProporcion("sueldo"), drProporcion("antiguedad_16_feb_2018"), _
                        '                             drProporcion("saldo_inicial")})

                        For Each dRow As DataRow In dtTablaProporciones.Select("", "periodo")

                            Dim col_periodo_inicio As String = "periodo" & dRow("periodo").ToString & "_inicio"
                            Dim col_periodo_fin As String = "periodo" & dRow("periodo").ToString & "_fin"
                            Dim col_periodo_dias As String = "periodo" & dRow("periodo").ToString & "_dias"
                            Dim col_periodo_antiguedad As String = "periodo" & dRow("periodo").ToString & "_antiguedad"
                            Dim col_periodo_corresponden As String = "periodo" & dRow("periodo").ToString & "_corresponden"
                            Dim col_periodo_proporcion As String = "periodo" & dRow("periodo").ToString & "_proporcion"

                            dtSaldosVacaciones.Columns.Add(col_periodo_inicio, GetType(System.String))
                            dtSaldosVacaciones.Columns.Add(col_periodo_fin, GetType(System.String))
                            dtSaldosVacaciones.Columns.Add(col_periodo_dias, GetType(System.Int32))
                            dtSaldosVacaciones.Columns.Add(col_periodo_antiguedad, GetType(System.Int32))
                            dtSaldosVacaciones.Columns.Add(col_periodo_corresponden, GetType(System.Int32))
                            dtSaldosVacaciones.Columns.Add(col_periodo_proporcion, GetType(System.Decimal))

                            dtSaldosVacaciones.Rows(0)(col_periodo_inicio) = dRow("periodo_inicio")
                            dtSaldosVacaciones.Rows(0)(col_periodo_fin) = dRow("periodo_fin")
                            dtSaldosVacaciones.Rows(0)(col_periodo_dias) = dRow("periodo_dias")
                            dtSaldosVacaciones.Rows(0)(col_periodo_antiguedad) = dRow("periodo_antiguedad")
                            dtSaldosVacaciones.Rows(0)(col_periodo_corresponden) = dRow("periodo_corresponden")
                            dtSaldosVacaciones.Rows(0)(col_periodo_proporcion) = dRow("periodo_proporcion")

                        Next

                        dtSaldosVacaciones.Columns.Add("Tomadas", GetType(System.Int32))
                        dtSaldosVacaciones.Columns.Add("Saldo_final", GetType(System.Decimal))

                        dtSaldosVacaciones.Rows(0)("Tomadas") = DiasVacTomadas
                        dtSaldosVacaciones.Rows(0)("Saldo_final") = Saldo_final_vac

                        Try
                            NumColSaldoVacaciones = dtSaldosVacaciones.Columns.Count
                        Catch ex As Exception
                            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
                            NumColSaldoVacaciones = 0
                        End Try

                    End If
                End If
            End If


        Catch ex As Exception
            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
        End Try

    End Sub


    Private Function DatosNecesariosCompletos() As Boolean

        Dim _done As Boolean = False

        Try

            If (dtEmpleado Is Nothing) Then
            ElseIf (dtEmpleado.Columns.Contains("ERROR")) Then
            ElseIf (dtEmpleado.Rows.Count <= 0) Then
            Else
                _done = True
            End If

            If (dtVacacionesBeneficios Is Nothing) Then
            ElseIf (dtVacacionesBeneficios.Columns.Contains("ERROR")) Then
            ElseIf (dtVacacionesBeneficios.Rows.Count <= 0) Then
            Else
                _done = True
            End If

            If (dtVacacionesEspeciales Is Nothing) Then
            ElseIf (dtVacacionesEspeciales.Columns.Contains("ERROR")) Then
                'ElseIf (dtVacacionesEspeciales.Rows.Count <= 0) Then
            Else
                _done = True
            End If

            If (dtProporcionesVacaciones Is Nothing) Then
            ElseIf (dtProporcionesVacaciones.Columns.Contains("ERROR")) Then
            Else
                _done = True
            End If

        Catch ex As Exception
            TablaMemoriaErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CSaldoVacaciones", ex.HResult, ex.Message, "Reloj: " & _reloj.Trim)
            _done = False
        End Try

        Return _done

    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then

            Try

                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                    Return
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.

                If Not dtEmpleado Is Nothing Then
                    dtEmpleado.Dispose()
                    dtEmpleado = Nothing
                End If

                If Not dtCambioTipoEmpleado Is Nothing Then
                    dtCambioTipoEmpleado.Dispose()
                    dtCambioTipoEmpleado = Nothing
                End If

                If Not dtProporcionesVacaciones Is Nothing Then
                    dtProporcionesVacaciones.Dispose()
                    dtProporcionesVacaciones = Nothing
                End If

                If Not dtSaldosVacaciones Is Nothing Then
                    dtSaldosVacaciones.Dispose()
                    dtSaldosVacaciones = Nothing
                End If

                If Not dtVacacionesAniversario Is Nothing Then
                    dtVacacionesAniversario.Dispose()
                    dtVacacionesAniversario = Nothing
                End If

                If Not dtVacacionesBeneficios Is Nothing Then
                    dtVacacionesBeneficios.Dispose()
                    dtVacacionesBeneficios = Nothing
                End If

                If Not dtVacacionesEspeciales Is Nothing Then
                    dtVacacionesEspeciales.Dispose()
                    dtVacacionesEspeciales = Nothing
                End If


                If Not dtErrores Is Nothing Then
                    dtErrores.Dispose()
                    dtErrores = Nothing
                End If

            Catch ex As Exception

            End Try

        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
