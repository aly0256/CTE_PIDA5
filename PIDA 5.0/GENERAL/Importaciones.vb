Imports System.IO
'Imports MySql.Data.MySqlClient

Module Importaciones
    Dim dtTemp As New DataTable

    Public Function ImportacionMySQL(AnoPeriodo As String) As Exception
        'Dim MySqlConexion As New MySqlCommand
        'Dim MySqlAdaptador As New MySqlDataAdapter
        'Dim dtResulta As New DataTable

        'CONFIGURAR DE ACUERDO AL SERVIDOR****
        Dim UsuarioMySql As String = "pida"
        Dim ClaveMySql As String = "soporte"
        Dim IPMySql As String = "10.97.0.8"
        Dim DBMySql As String = "hwatt"
        '*************************************

        Dim dtCiasTA As New DataTable
        Dim Mensaje As String = ""

        ''**** Variables importacion ****
        Dim dtImportadas As New DataTable
        Dim dtHrsBrt As New DataTable
        Dim dtPersonal As New DataTable

        Dim _usa_gafete As Boolean
        Dim _fecha_inicial As Date
        Dim _fecha_final As Date
        Dim _fecha_analisis As Date
        Dim Rango As Double = 3 'Default, 3 horas de margen
        Dim Minutos As Integer = 0
        Dim Duplicados As Integer = 0
        Dim NoRelacionados As Integer = 0
        Dim Insertados As Integer = 0
        Dim FechaIni As Date
        Dim FechaFin As Date

        'Dim _checador As String = ""
        'Dim NombreArchivo As String = ""

        Dim i As Integer = -1
        Dim dI As Date
        Dim dF As Date
        '**********************************

        Dim RelojesNoRelacionados As String = ""
        Try

            'Mostrar el progress bar de importación de relojes
            frmTrabajando.Text = "Importando información"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Cargando datos"
            ActivoTrabajando = True
            frmTrabajando.Show()
            Application.DoEvents()

            'Buscar en cias_ta el path de los archivos, relacionando con personal para obtener la cía default
            dtCiasTA = sqlExecute("SELECT path_hrs,reiniciar_relojes_automatico,usa_gafete,minutos_importacion FROM parametros")
            If dtCiasTA.Rows.Count = 0 Then
                Err.Raise(-1, Nothing, "No hay información de parámetros.")
            End If

            'Buscar el rango de horas máximo de la tabla días, para los horarios que no salen al siguiente día
            'Los horarios de salida día siguiente, se analizan al final
            dtTemp = sqlExecute("select max(rango_hrs) as maximo from dias where dia_ent=dia_sal")
            If dtTemp.Rows.Count > 0 Then
                Rango = IIf(IsDBNull(dtTemp.Rows(0).Item("maximo")), Rango, HtoD(dtTemp.Rows(0).Item("maximo")))
            End If

            _usa_gafete = IIf(IsDBNull(dtCiasTA.Rows(0).Item("usa_gafete")), 0, dtCiasTA.Rows(0).Item("usa_gafete")) = 1
            Minutos = IIf(IsDBNull(dtCiasTA.Rows(0).Item("minutos_importacion")), 5, dtCiasTA.Rows(0).Item("minutos_importacion"))


            'Ir 1 día antes y 1 día después en el rango, por si quedaron checadas sin cargar
            Dim dtPeriodo As New DataTable
            dtPeriodo = sqlExecute("SELECT fecha_ini,fecha_fin FROM Periodos WHERE ano = '" & AnoPeriodo.Substring(0, 4) & "' AND periodo = '" & AnoPeriodo.Substring(4) & "'", "TA")
            If dtPeriodo.Rows.Count > 0 Then
                FechaIni = dtPeriodo.Rows(0).Item("fecha_ini")
                FechaFin = dtPeriodo.Rows(0).Item("fecha_fin")
            End If
            _fecha_inicial = DateAdd(DateInterval.Hour, -Rango, FechaIni)
            'Agregar 24 a la fecha final, + el rango, para buscar las checadas hasta el lunes a la hora definida
            _fecha_final = DateAdd(DateInterval.Hour, 24 + Rango, FechaFin)
            _fecha_analisis = _fecha_inicial

            'Try
            '    'Conexion a MySQL para traer los datos de los relojes para el periodo +-15 días ********
            '    MySqlConexion.Connection = New MySqlConnection("server = " & IPMySql & _
            '                                                   ";Database=" & DBMySql & _
            '                                                   ";Uid=" & UsuarioMySql & _
            '                                                   ";Pwd=" & ClaveMySql & ";")

            '    MySqlConexion.CommandText = "select (case length(kqz_employee.EmployeeCode) when 5 then " & _
            '        "concat('0',cast(kqz_employee.EmployeeCode as char(5) charset utf8)) else " & _
            '        "cast(kqz_employee.EmployeeCode as char(6) charset utf8) end) AS 'reloj', " & _
            '        "cast(kqz_card.CardTime as date) AS 'fecha'," & _
            '        "substr(cast(kqz_card.CardTime as time),1,5) AS 'hora' " & _
            '        "from kqz_card join kqz_employee on kqz_employee.EmployeeID = kqz_card.EmployeeID " & _
            '        "WHERE cast(kqz_card.CardTime as date) >= '" & FechaSQL(_fecha_inicial) & "' AND cast(kqz_card.CardTime as date) <= '" & FechaSQL(_fecha_final) & "'"

            '    MySqlAdaptador.SelectCommand = MySqlConexion
            '    MySqlAdaptador.Fill(dtResulta)
            '    '********************************************************************
            'Catch ex As Exception
            '    Return ex
            'End Try

            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Text = "Procesando datos"
            Application.DoEvents()

            frmTrabajando.Avance.Maximum = dtResulta.Rows.Count
            For Each dRow As DataRow In dtResulta.Rows
                'Si se canceló el proceso, salir del ciclo y terminar
                If Not ActivoTrabajando Then Exit For

                i += 1
                frmTrabajando.Avance.Value = i
                frmTrabajando.lblAvance.Text = dRow("reloj")
                Application.DoEvents()

                dI = DateAdd(DateInterval.Minute, -Minutos, dRow("fecha") + " " + dRow("hora"))
                dF = DateAdd(DateInterval.Minute, Minutos, dRow("fecha") + " " + dRow("hora"))

                'Buscar en importadas, considerando el margen de minutos_importacion antes y después de la hora
                dtImportadas = sqlExecute("SELECT reloj FROM importadas WHERE reloj = '" & dRow("reloj") & "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & _
                                          FechaHoraSQL(dI, False, False) & "' AND '" & FechaHoraSQL(dF, False, False) & "'", "TA")
                If dtImportadas.Rows.Count = 0 Then
                    dtPersonal = sqlExecute("SELECT reloj,gafete,cod_comp from personalvw WHERE reloj = '" & dRow("reloj").ToString.Trim & "' OR gafete = '" & dRow("reloj").ToString.Trim & "'")
                    If dtPersonal.Rows.Count > 0 Then
                        'Insertar solo los que se localicen en personal

                        'Si no se encontró algún registro en este horario, revisar en hrs_brt
                        dtHrsBrt = sqlExecute("SELECT reloj FROM hrs_brt WHERE reloj = '" & dRow("reloj") & "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & _
                          FechaHoraSQL(dI, False, False) & "' AND '" & FechaHoraSQL(dF, False, False) & "'", "TA")

                        If dtHrsBrt.Rows.Count = 0 Then
                            'Si tampoco lo encontró en hrs_brt, insertarlo
                            sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,tipo_tran,dia,periodo,ano) VALUES (" & _
                                       "'" & dtPersonal.Rows(0).Item("cod_comp") & "'," & _
                                       "'" & dtPersonal.Rows(0).Item("reloj") & "'," & _
                                       "'" & IIf(_usa_gafete, dtPersonal.Rows(0).Item("gafete"), dRow("reloj")) & "'," & _
                                       "'" & FechaSQL(dRow("Fecha")) & "'," & _
                                       "'" & dRow("hora") & "'," & _
                                       "'R','" & DiaSem(dRow("fecha")) & "','" & AnoPeriodo.Substring(4, 2) & "','" & AnoPeriodo.Substring(0, 4) & "')", "TA")

                            sqlExecute("INSERT INTO importadas (reloj,fecha,hora) VALUES (" & _
                                       "'" & dtPersonal.Rows(0).Item("reloj") & "'," & _
                                       "'" & FechaSQL(dRow("Fecha")) & "'," & _
                                       "'" & dRow("hora") & "')", "TA")
                            'Registrar como avaluado
                            'dRow("eval") = True
                            Insertados += 1
                        Else
                            'Registrar como duplicado
                            'dRow("duplicado") = True
                            Duplicados += 1
                        End If
                    Else
                        'dRow("no_rel") = True
                        'Si no se localizó en personal, registrar como No relacionado

                        NoRelacionados += 1
                        RelojesNoRelacionados = RelojesNoRelacionados & vbCrLf & "     " & dRow("reloj") & "   " & dRow("fecha") & "   " & dRow("hora")
                    End If
                Else
                    'dRow("duplicado") = True
                    'Registrar como duplicado

                    Duplicados += 1
                End If
            Next
            Mensaje = IIf(ActivoTrabajando, "PROCESO CONCLUIDO", "PROCESO CANCELADO") & vbCrLf
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()

            If i < 0 Then
                'No hubo archivos para analizar
                MessageBox.Show("No hubo registros pendientes para importar.", "Importación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MessageBox.Show(Mensaje & vbCrLf & "   - Se analizaron " & i & " registros" & vbCrLf & _
                    "   - " & Insertados & " registros fueron insertados" & vbCrLf & _
                    "   - " & Duplicados & " registros se encontraron duplicados" & vbCrLf & _
                    "   - " & NoRelacionados & " registros no encontraron relación en personal" & vbCrLf & Now _
                    & IIf(NoRelacionados > 0, vbCrLf & vbCrLf & "Empleados no relacionados: " & RelojesNoRelacionados, "") _
                    , "Horas importadas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            Return Nothing
        Catch ex As Exception
            Return ex
        End Try


    End Function

    ''' <summary>
    ''' Importación de archivo texto separado por comas, conteniendo GAFETE (O RELOJ),FECHA,HORA
    ''' </summary>
    ''' <param name="AnoPeriodo"></param>
    Public Function ImportacionManual(AnoPeriodo As String) As Exception
        Try
            Dim _archivo As String
            Dim dtCiasTA As New DataTable
            Dim Mensaje As String = ""

            ''**** Variables importacion ****
            Dim dtImportadas As New DataTable
            Dim dtTA530 As New DataTable
            Dim dtHrsBrt As New DataTable
            Dim dtPersonal As New DataTable

            'Dim _bruto As String
            Dim _usa_gafete As Boolean
            Dim _fecha_inicial As Date
            Dim _fecha_final As Date
            Dim _fecha_analisis As Date
            Dim Rango As Double = 3 'Default, 3 horas de margen
            Dim Minutos As Integer = 0
            Dim Duplicados As Integer = 0
            Dim NoRelacionados As Integer = 0
            Dim Insertados As Integer = 0
            Dim FechaIni As Date
            Dim FechaFin As Date
            '**********************************

            'Mostrar el progress bar de importación de relojes
            frmTrabajando.Text = "Importando relojes"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Cargando relojes"
            Application.DoEvents()

            'Buscar en cias_ta el path de los archivos, relacionando con personal para obtener la cía default
            dtCiasTA = sqlExecute("SELECT path_hrs,reiniciar_relojes_automatico,usa_gafete,minutos_importacion FROM parametros")
            If dtCiasTA.Rows.Count = 0 Then
                Err.Raise(-1, Nothing, "No hay información de parámetros.")
            End If
            _archivo = IIf(IsDBNull(dtCiasTA.Rows(0).Item("path_hrs").ToString.Trim), "", dtCiasTA.Rows(0).Item("path_hrs").ToString.Trim)

            'Si el archivo no existe, provocar un error para terminar el proceso
            If Dir(_archivo).Length = 0 Then
                Err.Raise(50, Nothing, "Archivo de relojes " & _archivo & " no existe.")
            End If

            frmTrabajando.Show(frmTA)
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Abriendo archivos"
            Application.DoEvents()

            'Buscar el rango de horas máximo de la tabla días, para los horarios que no salen al siguiente día
            'Los horarios de salida día siguiente, se analizan al final
            dtTemp = sqlExecute("select max(rango_hrs) as maximo from dias where dia_ent=dia_sal")
            If dtTemp.Rows.Count > 0 Then
                Rango = IIf(IsDBNull(dtTemp.Rows(0).Item("maximo")), Rango, HtoD(dtTemp.Rows(0).Item("maximo")))
            End If

            _usa_gafete = IIf(IsDBNull(dtCiasTA.Rows(0).Item("usa_gafete")), 0, dtCiasTA.Rows(0).Item("usa_gafete")) = 1
            Minutos = IIf(IsDBNull(dtCiasTA.Rows(0).Item("minutos_importacion")), 5, dtCiasTA.Rows(0).Item("minutos_importacion"))

            'Ir 15 días antes y 15 días después en el rango, por si quedaron checadas sin cargar
            Dim dtPeriodo As New DataTable
            dtPeriodo = sqlExecute("SELECT fecha_ini,fecha_fin FROM Periodos WHERE ano = '" & AnoPeriodo.Substring(0, 4) & "' AND periodo = '" & AnoPeriodo.Substring(4) & "'", "TA")
            If dtPeriodo.Rows.Count > 0 Then
                FechaIni = dtPeriodo.Rows(0).Item("fecha_ini")
                FechaFin = dtPeriodo.Rows(0).Item("fecha_fin")
            End If
            _fecha_inicial = DateAdd(DateInterval.Day, -15, FechaIni)
            _fecha_final = DateAdd(DateInterval.Day, 15, FechaFin)
            _fecha_analisis = _fecha_inicial

            dtTA530.Columns.Add("reloj")
            dtTA530.Columns.Add("fecha")
            dtTA530.Columns.Add("hora")

            ' dtTA530.PrimaryKey = New DataColumn() {dtTA530.Columns("reloj"), dtTA530.Columns("fecha"), dtTA530.Columns("hora")}

            Dim Info() As String
            Dim line As String
            Dim _gafete As String
            Dim _fecha As Date
            Dim _hora As String
            Dim _checador As String = ""
            Dim NombreArchivo As String = ""

            'Revisar en el rango de fechas
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Analizando " & _fecha_analisis.Day & "-" & MesLetra(_fecha_analisis).Substring(0, 3)
            Application.DoEvents()

            'Si existe el archivo, abrir para analizar su contenido
            Using sr As New StreamReader(_archivo)
                'Inicializar fecha y checador
                _checador = ""
                _fecha = Nothing

                Do Until sr.EndOfStream
                    'Obtener cada línea, y separar en un arreglo, separando por el delimitador ","
                    line = sr.ReadLine
                    Info = line.Split(",")

                    If Info.GetUpperBound(0) >= 2 Then
                        'Si hay al menos 3 elementos en el arreglo...
                        _gafete = Info(0).Trim
                        'Fecha desde formato DDMMYYYY
                        _fecha = DateSerial(Info(1).Substring(4), Info(1).Substring(2, 2), Info(1).Substring(0, 2))
                        _hora = Info(2).Substring(0, 2) & ":" & Info(2).Substring(2, 2)

                        Dim drBusca() As DataRow
                        drBusca = dtTA530.Select("reloj = '" & _gafete & "' AND fecha = '" & _fecha & "' AND hora = '" & _hora & "'")
                        If drBusca.Length = 0 Then
                            dtTA530.Rows.Add({_gafete, _fecha, _hora})
                        End If
                    Else
                        'INSERTAR EN ERRORES O EXCEPCIONES
                    End If
                Loop
            End Using
            'Renombrar el archivo, para marcarlo y no volver a importarlo
            NombreArchivo = _archivo.Substring(_archivo.LastIndexOf("\") + 1)
            FileSystem.Rename(_archivo, _archivo.Replace(NombreArchivo, "I" & Year(Today) & Month(Today) & DatePart(DateInterval.Day, Today) & _
                                                         DatePart(DateInterval.Hour, Now).ToString.PadLeft(2, "0") & _
                                                         DatePart(DateInterval.Minute, Now).ToString.PadLeft(2, "0") & NombreArchivo))

            Dim i As Integer = -1
            Dim dI As Date
            Dim dF As Date

            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Text = "Procesando datos"
            Application.DoEvents()
            _fecha_inicial = DateAdd(DateInterval.Hour, -Rango, FechaIni)
            'Agregar 24 a la fecha final, + el rango, para buscar las checadas hasta el lunes a la hora definida
            _fecha_final = DateAdd(DateInterval.Hour, 24 + Rango, FechaFin)
            Dim dtSeleccion() As DataRow
            dtSeleccion = dtTA530.Select(" fecha >= '" & FechaSQL(_fecha_inicial) & "' AND fecha<= '" & FechaSQL(_fecha_final) & "'")
            frmTrabajando.Avance.Maximum = UBound(dtSeleccion)
            For Each dRow As DataRow In dtSeleccion
                'Si se canceló el proceso, salir del ciclo y terminar
                If Not ActivoTrabajando Then Exit For

                i += 1
                frmTrabajando.Avance.Value = i
                'frmTrabajando.lblAvance.Text = dRow("reloj")
                Application.DoEvents()

                dI = DateAdd(DateInterval.Minute, -5, dRow("fecha") + " " + dRow("hora"))
                dF = DateAdd(DateInterval.Minute, 5, dRow("fecha") + " " + dRow("hora"))

                'Buscar en importadas, considerando el margen de minutos_importacion antes y después de la hora
                dtImportadas = sqlExecute("SELECT reloj FROM importadas WHERE reloj = '" & dRow("reloj") & "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & _
                                          FechaHoraSQL(dI) & "' AND '" & FechaHoraSQL(dF) & "'", "TA")
                If dtImportadas.Rows.Count = 0 Then
                    dtPersonal = sqlExecute("SELECT reloj,gafete,cod_comp from personalvw WHERE gafete = '" & dRow("reloj").ToString.Trim & "'")
                    If dtPersonal.Rows.Count > 0 Then
                        'Insertar solo los que se localicen en personal

                        'Si no se encontró algún registro en este horario, revisar en hrs_brt
                        dtHrsBrt = sqlExecute("SELECT * FROM hrs_brt WHERE reloj = '" & dRow("reloj") & "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & _
                          FechaHoraSQL(dI) & "' AND '" & FechaHoraSQL(dF) & "'", "TA")
                        If dtHrsBrt.Rows.Count = 0 Then
                            'Si tampoco lo encontró en hrs_brt, insertarlo
                            sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,tipo_tran,dia,periodo,ano) VALUES (" & _
                                       "'" & dtPersonal.Rows(0).Item("cod_comp") & "'," & _
                                       "'" & dtPersonal.Rows(0).Item("reloj") & "'," & _
                                       "'" & IIf(_usa_gafete, dtPersonal.Rows(0).Item("gafete"), dRow("reloj")) & "'," & _
                                       "'" & FechaSQL(dRow("Fecha")) & "'," & _
                                       "'" & dRow("hora") & "'," & _
                                       "'R','" & DiaSem(dRow("fecha")) & "','" & AnoPeriodo.Substring(4, 2) & "','" & AnoPeriodo.Substring(0, 4) & "')", "TA")

                            sqlExecute("INSERT INTO importadas (reloj,fecha,hora) VALUES (" & _
                                       "'" & dtPersonal.Rows(0).Item("reloj") & "'," & _
                                       "'" & FechaSQL(dRow("Fecha")) & "'," & _
                                       "'" & dRow("hora") & "')", "TA")
                            'Registrar como avaluado
                            'dRow("eval") = True
                            Insertados += 1
                        Else
                            'Registrar como duplicado
                            'dRow("duplicado") = True
                            Duplicados += 1
                        End If
                    Else
                        'dRow("no_rel") = True
                        'Si no se localizó en personal, registrar como No relacionado

                        NoRelacionados += 1

                    End If
                Else
                    'dRow("duplicado") = True
                    'Registrar como duplicado

                    Duplicados += 1
                End If
            Next
            Mensaje = IIf(ActivoTrabajando, "PROCESO CONCLUIDO", "PROCESO CANCELADO") & vbCrLf
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()

            If i < 0 Then
                'No hubo archivos para analizar
                MessageBox.Show("No hubo registros pendientes para importar.", "Importación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MessageBox.Show(Mensaje & vbCrLf & "   - Se analizaron " & i & " registros" & vbCrLf & _
                    "   - " & Insertados & " registros fueron insertados" & vbCrLf & _
                    "   - " & Duplicados & " registros se encontraron duplicados" & vbCrLf & _
                    "   - " & NoRelacionados & " registros no encontraron relación en personal" & vbCrLf & Now _
                    , "Horas importadas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

           
            Return Nothing
        Catch ex As Exception
            Return ex
        End Try
    End Function


    Public Function ImportacionAcroCOMM(AnoPeriodo As String) As Exception
        Try
            Dim Parametros As String
            Dim _archivo As String
            Dim _bruto As String
            Dim _ano As String = Now.Year.ToString.Trim
            Dim _mes As String = Now.Month.ToString.Trim.PadLeft(2, "0")
            Dim _dia As String = Now.Day.ToString.Trim.PadLeft(2, "0")
            Dim ReiniciarAutomaticamente As Boolean = True
            Dim Reinicia As Boolean
            Dim dtCiasTA As New DataTable
            Dim dtRelojes As New DataTable

            Dim Mensaje As String = ""
            Dim ReiniciarTodos As Boolean = True

            '**** Variables importacion ****
            Dim dtBitacora As New DataTable
            Dim dtImportadas As New DataTable
            Dim dtTA530 As New DataTable
            Dim dtPeriodos As New DataTable
            Dim dtHrsBrt As New DataTable
            Dim dtPersonal As New DataTable

            Dim _usa_gafete As Boolean
            Dim _fecha_inicial As Date
            Dim _fecha_final As Date
            Dim _fecha_analisis As Date
            Dim Rango As Double = 3 'Default, 3 horas de margen
            Dim Minutos As Integer = 0
            Dim Duplicados As Integer = 0
            Dim NoRelacionados As Integer = 0
            Dim Insertados As Integer = 0
            Dim FechaIni As Date
            Dim FechaFin As Date
            '**********************************


            'Mostrar el progress bar de importación de relojes
            frmTrabajando.Text = "Importando relojes"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Cargando relojes"
            Application.DoEvents()


            Dim _servidor As String = "\\pida003\puente"
            Dim _unidad As String = "J"
            Dim _clave As String = "adminibm"
            Dim _usuarioServidor As String = "Administrator"

            '***** MAP DRIVE *****
            'Dim Conexion As Boolean

            ''Si la unidad existe, desconectarla -podría estar con otro servidor-
            'If IO.Directory.Exists(_unidad & ":\") Then
            '    Conexion = UnMapDrive(_unidad)
            'End If

            ''Conectar drive de acuerdo al servidor
            'Conexion = MapDrive(_unidad, servidor,_usuarioServidor,_clave)

            'If Not Conexion Then
            '    Err.Raise(10, Nothing, "Error de conexión con servidor " & _servidor)
            'End If
            '*********************

            'Buscar en cias_ta el path de los archivos, relacionando con personal para obtener la cía default
            dtCiasTA = sqlExecute("SELECT path_hrs,reiniciar_relojes_automatico FROM parametros")
            If dtCiasTA.Rows.Count = 0 Then
                Err.Raise(-1, Nothing, "No hay información de compañía default")
            End If
            _bruto = IIf(IsDBNull(dtCiasTA.Rows(0).Item("path_hrs").ToString.Trim), "", dtCiasTA.Rows(0).Item("path_hrs").ToString.Trim)
            'Formar el nombre del archivo, con el año, mes y día
            _archivo = _bruto & "\AUDIT\R" & _ano.Substring(2, 2) & _mes & _dia & ".ADT"
            ReiniciarAutomaticamente = IIf(IsDBNull(dtCiasTA.Rows(0).Item("reiniciar_relojes_automatico")), 1, dtCiasTA.Rows(0).Item("reiniciar_relojes_automatico")) = 1


            'Si el archivo no existe, provocar un error para terminar el proceso
            If Dir(_archivo).Length = 0 Then
                Err.Raise(50, Nothing, "Archivo de relojes " & _archivo & "no existe.")
            End If

            'Seleccionar los relojes activos, excepto el 1 (default de fábrica)
            dtRelojes = sqlExecute("SELECT reloj FROM relojes where activo = 1 and reloj > 1", "TA")
            If dtRelojes.Rows.Count > 0 Then
                'Agregar columna para registrar los que deban reiniciarse
                dtRelojes.Columns.Add("reiniciar", GetType(System.Boolean))
            End If

            For Each dReloj As DataRow In dtRelojes.Rows
                'Obtener información del reloj ("poleo")
                'REVISAR QUE ESTE UBICADO EN EL DIRECTORIO DEL ACROCOMM
                Parametros = _unidad & ":\pida\relojes\acrocomm @" & _unidad & ":\pida\relojes\cfg" & dReloj("reloj") & ".ini -adata.dat"
                'Shell(Parametros, AppWinStyle.Hide)

                Reinicia = BitacoraPoleos(dReloj("reloj"), _archivo)
                dReloj("reiniciar") = Reinicia
                ReiniciarTodos = ReiniciarTodos And Reinicia
                If Not Reinicia Then Mensaje = Mensaje & vbCrLf & "* Error en reloj " & dReloj("reloj")

                If Reinicia And ReiniciarAutomaticamente Then
                    'Si no hubo errores, y se selecciona reinicio automático, reiniciar
                    'REVISAR QUE ESTE UBICADO EN EL DIRECTORIO DEL ACROCOMM
                    Parametros = _unidad & ":\pida\relojes\acrocomm @" & _unidad & ":\pida\relojes\cfg" & dReloj("reloj") & ".ini -R"
                    'Shell(Parametros, AppWinStyle.Hide)
                End If
            Next

            'Una vez que se termina de jalar relojes, y reiniciar en caso de que se seleccionara, hacer la importación

            frmTrabajando.Show(frmTA)
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Abriendo archivos"
            Application.DoEvents()

            'Buscar el rango de horas máximo de la tabla días, para los horarios que no salen al siguiente día
            'Los horarios de salida día siguiente, se analizan al final
            dtTemp = sqlExecute("select max(rango_hrs) as maximo from dias where dia_ent=dia_sal")
            If dtTemp.Rows.Count > 0 Then
                Rango = IIf(IsDBNull(dtTemp.Rows(0).Item("maximo")), Rango, HtoD(dtTemp.Rows(0).Item("maximo")))
            End If

            dtCiasTA = sqlExecute("SELECT path_hrs,usa_gafete,minutos_importacion FROM parametros")
            _bruto = dtCiasTA.Rows(0).Item("path_hrs").ToString.Trim
            _usa_gafete = IIf(IsDBNull(dtCiasTA.Rows(0).Item("usa_gafete")), 0, dtCiasTA.Rows(0).Item("usa_gafete")) = 1
            Minutos = IIf(IsDBNull(dtCiasTA.Rows(0).Item("minutos_importacion")), 5, dtCiasTA.Rows(0).Item("minutos_importacion"))

            'Ir 15 días antes y 15 días después en el rango, por si quedaron checadas sin cargar
            _fecha_inicial = DateAdd(DateInterval.Day, -15, FechaIni)
            _fecha_final = DateAdd(DateInterval.Day, 15, FechaFin)
            _fecha_analisis = _fecha_inicial

            dtTA530.Columns.Add("hora")
            dtTA530.Columns.Add("tipo_tran")
            dtTA530.Columns.Add("reloj")
            dtTA530.Columns.Add("id_checador")
            dtTA530.Columns.Add("fecha", GetType(System.DateTime))
            dtTA530.Columns.Add("eval", GetType(System.Boolean))
            dtTA530.Columns.Add("no_rel", GetType(System.Boolean))
            dtTA530.Columns.Add("duplicado", GetType(System.Boolean))
            dtTA530.PrimaryKey = New DataColumn() {dtTA530.Columns("reloj"), dtTA530.Columns("fecha"), dtTA530.Columns("hora")}

            Dim Info() As String
            Dim line As String
            Dim _fecha As Date
            Dim _hora As String
            Dim _checador As String = ""
            Dim dR As DataRow
            Dim NombreArchivo As String = ""

            'Revisar en el rango de fechas
            Do While _fecha_analisis <= _fecha_final And ActivoTrabajando
                frmTrabajando.Avance.IsRunning = True
                frmTrabajando.lblAvance.Text = "Analizando " & _fecha_analisis.Day & "-" & MesLetra(_fecha_analisis).Substring(0, 3)
                Application.DoEvents()

                'Formar nombre de archivo de acuerdo al folder seleccionado en CIAS_TA y la fecha a analizar
                NombreArchivo = _fecha_analisis.Year & _fecha_analisis.Month & _fecha_analisis.Day.ToString.PadLeft(2, "0") & ".CHK"
                _archivo = _bruto & IIf(_bruto.Substring(_bruto.Length - 1, 1) = "\", "", "\") & NombreArchivo
                If Dir(_archivo) <> "" Then
                    'Si existe el archivo, abrir para analizar su contenido
                    Using sr As New StreamReader(_archivo)
                        'Inicializar fecha y checador
                        _checador = ""
                        _fecha = Nothing

                        Do Until sr.EndOfStream
                            'Obtener cada línea, y separar en un arreglo, separando por el delimitador ","
                            line = sr.ReadLine
                            Info = line.Split(",")

                            If Info.GetUpperBound(0) >= 2 Then
                                'Si hay al menos 3 elementos en el arreglo...
                                _hora = Info(0).Substring(0, 2) & ":" & Info(0).Substring(2, 2)


                                If Info(1) = "4" Then
                                    'Si el tipo de transacción es 4, convertir a formato fecha y hora, luego insertar
                                    _fecha = DateSerial(Info(2).Substring(0, 4), Info(2).Substring(4, 2), Info(2).Substring(6, 2))

                                    'dR = dtTA530.Rows.Find({Info(2), _fecha, _hora})
                                    'If IsNothing(dR) Then
                                    '    dtTA530.Rows.Add({_hora, Info(1), Info(2), _checador, _fecha, True})
                                    'End If
                                ElseIf Info(1) <> "1" And _checador <> "3" Then
                                    'Si no es tipo de transacción 1, ni es de cafetería, es registro de empleado. 
                                    'Convertir a formato hora e insertar, si no existe
                                    dR = dtTA530.Rows.Find({Info(2), _fecha, _hora})
                                    If IsNothing(dR) Then
                                        dtTA530.Rows.Add({_hora, Info(1), Info(2), _checador, _fecha})
                                    End If
                                End If
                            Else
                                'Si son menos de 2 elementos en el arreglo, es el identificador del reloj
                                If Info(0) <> "3" Then
                                    'Sin incluir cafetería
                                    _checador = Info(0)
                                    ''Insertar la fecha solo porque no acetpta NULL
                                    'dR = dtTA530.Rows.Find({Info(1), Now.Date, ""})
                                    'If IsNothing(dR) Then
                                    '    dtTA530.Rows.Add({"", "I", Info(1), Info(0), Now.Date})
                                    'End If
                                End If
                            End If
                        Loop
                    End Using
                    'Renombrar el archivo, para marcarlo y no volver a importarlo
                    FileSystem.Rename(_archivo, _archivo.Replace(NombreArchivo, "I" & NombreArchivo))
                End If
                'Incrementar la fecha para analizar el siguiente día
                _fecha_analisis = _fecha_analisis.AddDays(1)
            Loop

            Dim i As Integer = -1
            Dim dI As Date
            Dim dF As Date

            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Text = "Procesando datos"
            Application.DoEvents()
            _fecha_inicial = DateAdd(DateInterval.Hour, -Rango, FechaIni)
            'Agregar 24 a la fecha final, + el rango, para buscar las checadas hasta el lunes a la hora definida
            _fecha_final = DateAdd(DateInterval.Hour, 24 + Rango, FechaFin)
            Dim dtSeleccion() As DataRow
            dtSeleccion = dtTA530.Select("tipo_tran<>'4' AND fecha >= '" & FechaSQL(_fecha_inicial) & "' AND fecha<= '" & FechaSQL(_fecha_final) & "'")
            frmTrabajando.Avance.Maximum = UBound(dtSeleccion)
            For Each dRow As DataRow In dtSeleccion
                'Si se canceló el proceso, salir del ciclo y terminar
                If Not ActivoTrabajando Then Exit For

                i += 1
                frmTrabajando.Avance.Value = i
                'frmTrabajando.lblAvance.Text = dRow("reloj")
                Application.DoEvents()

                dI = DateAdd(DateInterval.Minute, -5, dRow("fecha") + " " + dRow("hora"))
                dF = DateAdd(DateInterval.Minute, 5, dRow("fecha") + " " + dRow("hora"))

                'Buscar en importadas, considerando el margen de minutos_importacion antes y después de la hora
                dtImportadas = sqlExecute("SELECT reloj FROM importadas WHERE reloj = '" & dRow("reloj") & "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & _
                                          FechaHoraSQL(dI) & "' AND '" & FechaHoraSQL(dF) & "'", "TA")
                If dtImportadas.Rows.Count = 0 Then
                    dtPersonal = sqlExecute("SELECT reloj,gafete,cod_comp from personalvw WHERE gafete = '" & dRow("reloj").ToString.Trim & "'")
                    If dtPersonal.Rows.Count > 0 Then
                        'Insertar solo los que se localicen en personal

                        'Si no se encontró algún registro en este horario, revisar en hrs_brt
                        dtHrsBrt = sqlExecute("SELECT * FROM hrs_brt WHERE reloj = '" & dRow("reloj") & "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & _
                          FechaHoraSQL(dI) & "' AND '" & FechaHoraSQL(dF) & "'", "TA")
                        If dtHrsBrt.Rows.Count = 0 Then
                            'Si tampoco lo encontró en hrs_brt, insertarlo
                            sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,tipo_tran,dia,periodo,ano) VALUES (" & _
                                       "'" & dtPersonal.Rows(0).Item("cod_comp") & "'," & _
                                       "'" & dtPersonal.Rows(0).Item("reloj") & "'," & _
                                       "'" & IIf(_usa_gafete, dtPersonal.Rows(0).Item("gafete"), dRow("reloj")) & "'," & _
                                       "'" & FechaSQL(dRow("Fecha")) & "'," & _
                                       "'" & dRow("hora") & "'," & _
                                       "'R','" & DiaSem(dRow("fecha")) & "','" & AnoPeriodo.Substring(4, 2) & "','" & AnoPeriodo.Substring(0, 4) & "')", "TA")

                            sqlExecute("INSERT INTO importadas (reloj,fecha,hora) VALUES (" & _
                                       "'" & dtPersonal.Rows(0).Item("reloj") & "'," & _
                                       "'" & FechaSQL(dRow("Fecha")) & "'," & _
                                       "'" & dRow("hora") & "')", "TA")
                            'Registrar como avaluado
                            'dRow("eval") = True
                            Insertados += 1
                        Else
                            'Registrar como duplicado
                            'dRow("duplicado") = True
                            Duplicados += 1
                        End If
                    Else
                        'dRow("no_rel") = True
                        'Si no se localizó en personal, registrar como No relacionado

                        NoRelacionados += 1

                    End If
                Else
                    'dRow("duplicado") = True
                    'Registrar como duplicado

                    Duplicados += 1
                End If
            Next
            Mensaje = IIf(ActivoTrabajando, "PROCESO concluido", "PROCESO CANCELADO") & vbCrLf
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()

            If i < 0 Then
                'No hubo archivos para analizar
                Err.Raise(-5, "No hubo archivos pendientes para importar.")
            Else
                MessageBox.Show(Mensaje & vbCrLf & "   - Se analizaron " & i & " registros" & vbCrLf & _
                    "   - " & Insertados & " registros fueron insertados" & vbCrLf & _
                    "   - " & Duplicados & " registros se encontraron duplicados" & vbCrLf & _
                    "   - " & NoRelacionados & " registros no encontraron relación en personal" & vbCrLf & Now _
                    , "Horas importadas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If ReiniciarAutomaticamente And ReiniciarTodos Then
                'Reiniciar de forma automática, y no hubo errores
                MessageBox.Show("Proceso concluido satisfactoriamente.", "Importación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf (ReiniciarAutomaticamente And Not ReiniciarTodos) Then
                'Se reiniciaron automáticamente los relojes, pero hubo problemas en alguno
                MessageBox.Show("Al menos un reloj tuvo problemas, y no puede ser reiniciado. El resto completó el proceso satisfactoriamente." & IIf(Mensaje.Length > 0, vbCrLf, "") & Mensaje, "Importación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf (Not ReiniciarAutomaticamente And ReiniciarTodos) Then
                'No hubo errores, pero hay que reiniciar manualmente
                If MessageBox.Show("No se detectaron problemas durante la importación." & vbCrLf & "¿Desea reiniciar los relojes ahora?", "Importación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Mensaje = ""
                    ReiniciarTodos = True
                    For Each dReloj As DataRow In dtRelojes.Rows
                        'Si no hubo errores, y se selecciona reinicio automático, reiniciar
                        'REVISAR QUE ESTE UBICADO EN EL DIRECTORIO DEL ACROCOMM
                        Parametros = _unidad & ":\pida\relojes\acrocomm @" & _unidad & ":\pida\relojes\cfg" & dReloj("reloj") & ".ini -R"
                        'Shell(Parametros, AppWinStyle.Hide)

                        'Después de resetear, revisar bitácora, a ver si pudo completarse exitosamente
                        Reinicia = BitacoraPoleos(dReloj("reloj"), _archivo)
                        dReloj("reiniciar") = Reinicia
                        ReiniciarTodos = ReiniciarTodos And Reinicia
                        If Not Reinicia Then Mensaje = Mensaje & vbCrLf & "* Error en reloj " & dReloj("reloj")
                    Next
                    If Not ReiniciarTodos Then
                        'Si hubo errores 
                        MessageBox.Show("Al menos un reloj tuvo problemas, y no puede ser reiniciado." & IIf(Mensaje.Length > 0, vbCrLf, "") & Mensaje, "Reiniciar relojes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("El proceso fue concluido satisfactoriamente.", "Reiniciar relojes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                'Si requieren reinicio manual, y hubo errores 
                If MessageBox.Show("Al menos un reloj tuvo problemas, y no puede ser reiniciado." & IIf(Mensaje.Length > 0, vbCrLf, "") & Mensaje & vbCrLf & vbCrLf & "¿Desea reiniciar los demás relojes?", "Reiniciar relojes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    'Seleccionar solo los relojes que no hayan tenido errores
                    Mensaje = ""
                    ReiniciarTodos = True
                    For Each dReloj As DataRow In dtRelojes.Select("NOT reiniciar")
                        'Si no hubo errores, y se selecciona reinicio automático, reiniciar
                        'REVISAR QUE ESTE UBICADO EN EL DIRECTORIO DEL ACROCOMM
                        Parametros = _unidad & ":\pida\relojes\acrocomm @" & _unidad & ":\pida\relojes\cfg" & dReloj("reloj") & ".ini -R"
                        'Shell(Parametros, AppWinStyle.Hide)

                        'Después de resetear, revisar bitácora, a ver si pudo completarse exitosamente
                        Reinicia = BitacoraPoleos(dReloj("reloj"), _archivo)
                        dReloj("reiniciar") = Reinicia
                        ReiniciarTodos = ReiniciarTodos And Reinicia
                        If Not Reinicia Then Mensaje = Mensaje & vbCrLf & "* Error en reloj " & dReloj("reloj")
                    Next
                    If Not ReiniciarTodos Then
                        'Si hubo errores 
                        MessageBox.Show("Al menos un reloj tuvo problemas, y no puede ser reiniciado." & IIf(Mensaje.Length > 0, vbCrLf, "") & Mensaje, "Reiniciar relojes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("El proceso fue concluido satisfactoriamente.", "Reiniciar relojes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
            Return Nothing
        Catch ex As Exception
            Return ex
        End Try
    End Function


    Public Function BitacoraPoleos(NumReloj As Integer, _archivo As String) As Boolean
        '*** Codigo para identificar si el poleo fue completo y en ese caso resetear el reloj IVO
        Dim dtCiasTa As New DataTable
        Dim dtRelojes As New DataTable
        Dim dtBitacora As New DataTable

        Dim Linea As String

        Dim _reiniciar As Boolean = True   'Bandera para regresar si se pueden reiniciar/resetear los relojes
        Dim _pFecha As Date = Now.Date
        Dim _hora As String = ""
        Dim _terminal As String = ""
        Dim _resultado As String = ""
        Dim _analiza As Boolean
        Dim _num_tran As Integer = 0

        Try
            'Abrir el archivo
            Using sr As New StreamReader(_archivo)
                'Leer primer línea del archivo
                Linea = sr.ReadLine

                'Repetir el proceso hasta que encuentre fin de archivo
                Do Until sr.EndOfStream
                    If Linea.Contains("TCP Connection Address") Or Linea.Contains("Polling Terminal") Or Linea.Contains("Sending Memory Reset") Then
                        'Si la línea contiene alguna de estas cadenas, tomar la información de la terminal, y buscar si es el reloj que se está analizando
                        _terminal = Linea.Trim.Replace(Chr(9), "")
                        If _terminal.Trim.Substring(_terminal.Trim.Length - 2, 2).Trim = NumReloj Then
                            _analiza = True
                            _reiniciar = True
                        Else
                            _analiza = False
                        End If
                    ElseIf Linea.Contains("Begin sesion,") Then
                        'Si es inicio de sesión, tomar la hora, dando formato de 8 caracteres
                        _hora = Linea.Replace("Begin sesion,", "").Trim.PadLeft(8, "0")
                    ElseIf Linea.Contains("End sesion,") Then
                        'Si es fin de sesión, limpiar variables
                        _terminal = ""
                        _analiza = False
                        _hora = ""
                        _num_tran = 0
                        _resultado = ""
                    ElseIf _analiza And (Linea.ToLower.Contains("transmission aborted") Or Linea.ToLower.Contains("transmition cancelled") Or Linea.ToLower.Contains("error")) Then
                        'Si es cadena de fin de transmisión por cancelación o error
                        _resultado = Linea.Trim.Replace(Chr(9), "")
                        'Si es un reloj analiza, la variable de reiniciar se hace falsa, por detectar error
                        _reiniciar = False
                        'Buscar en la tabla de bitácora
                        dtBitacora = sqlExecute("SELECT fecha,hora FROM bitacora WHERE fecha = '" & FechaSQL(_pFecha) & "' AND LTRIM(RTRIM(hora)) = '" & _hora.Trim & "'", "ta")
                        If dtBitacora.Rows.Count = 0 Then
                            'Si no la encontró, insertarla
                            sqlExecute("INSERT INTO bitacora (terminal,fecha,hora,resultado) VALUES ('" & _terminal & "','" & FechaSQL(_pFecha) & "','" & _hora.Trim & "','" & _resultado & "')", "TA")
                        End If
                    ElseIf _analiza And Linea.ToLower.Contains("successfull operation") Then
                        'Si la cadena indica que la operación fue exitosa
                        _resultado = Linea.Trim.Replace(Chr(9), "")
                        'Si el reloj está analiza, se pasa True a reiniciar. 
                        _reiniciar = True
                        'Buscar en la tabla de bitácora
                        dtBitacora = sqlExecute("SELECT fecha,hora FROM bitacora WHERE fecha = '" & FechaSQL(_pFecha) & "' AND LTRIM(RTRIM(hora)) = '" & _hora.Trim & "'", "ta")
                        If dtBitacora.Rows.Count = 0 Then
                            'Si no existe, insertarla
                            sqlExecute("INSERT INTO bitacora (terminal,fecha,hora,resultado) VALUES ('" & _terminal & "','" & FechaSQL(_pFecha) & "','" & _hora.Trim & "','" & _resultado & "')", "TA")
                        End If
                    ElseIf _analiza And Linea.ToLower.Contains("transactions received") Then
                        'Si la cadena contiene el número de transacciones recibidas, tomar el dato
                        _num_tran = Linea.ToLower.Replace("transactions received", "").Trim
                        'Buscar en la tabla de bitácora
                        dtBitacora = sqlExecute("SELECT fecha,hora FROM bitacora WHERE fecha = '" & FechaSQL(_pFecha) & "' AND LTRIM(RTRIM(hora)) = '" & _hora.Trim & "'", "ta")
                        If dtBitacora.Rows.Count > 0 Then
                            'Si encontró el registro en la bitácora, revisar...
                            If _num_tran <= 5 Then
                                'Si está analiza, y son menos de 5 transacciones, indicar advertencia
                                _resultado = "¡¡¡Advertencia!! Menos de 5 transacciones, NO se reseteará el reloj"
                                'La variable _reiniciar se hace falsa para indicar que hubo error, y no se reinicien relojes
                                _reiniciar = False
                                'Buscar en la tabla de bitácora
                                dtBitacora = sqlExecute("SELECT fecha,hora FROM bitacora WHERE fecha = '" & FechaSQL(_pFecha) & "' AND LTRIM(RTRIM(hora)) = '" & _hora.Trim & "'", "ta")
                                If dtBitacora.Rows.Count > 0 Then
                                    'Si existe, agregar número de transacciones y el mensaje de advertencia
                                    sqlExecute("UPDATE bitacora SET num_trans = " & _num_tran & ", resultado = resultado + iif(not resultado is null,',','') + '" & _resultado & "' WHERE fecha = '" & FechaSQL(_pFecha) & "' AND LTRIM(RTRIM(hora)) = '" & _hora.Trim & "'", "TA")
                                End If
                            Else
                                'Si _reiniciar se había hecho falsa anteriormente, se quedará falsa: False AND True = False
                                _reiniciar = True
                                'Agregar a la bitácora el número de transacciones recibidas
                                sqlExecute("UPDATE bitacora SET num_trans = " & _num_tran & " WHERE fecha = '" & FechaSQL(_pFecha) & "' AND LTRIM(RTRIM(hora)) = '" & _hora.Trim & "'", "TA")
                            End If
                        End If
                    End If
                    'Leer la siguiente línea del archivo 
                    Linea = sr.ReadLine
                Loop
            End Using
            'Regresar lo que valga _reiniciar
            Return _reiniciar
        Catch ex As Exception
            'Si hubo error, registrar en la bitácora de errores
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Importaciones", ex.HResult, ex.Message)
            'Regresar falso para no reiniciar relojes
            Return False
        End Try
    End Function

End Module
