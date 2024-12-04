Public Module ClasesSermed

    Public Class ConsultaSermed
        Public folio As String

        Public DatosCaptura As DatosCapturaSermed

        ' Public responsable As String

        Public datos_clinicos As String

        Public comentarios As String

        Public medicamentos As String

        Public tieneProx_cita As Boolean

        Public prox_cita As Date

        Public peso As Double

        Public altura As Double

        Public imc As Double

        Public esExterno As Boolean

        Sub New()
            Dim dtConsulta As DataTable = sqlExecute("select top 1 folio from consultas order by folio desc", "sermed")
            If dtConsulta.Rows.Count > 0 Then
                Me.folio = completar(Integer.Parse(dtConsulta.Rows(0)("folio")) + 1, 6)
            End If
            Me.DatosCaptura = New DatosCapturaSermed()
        End Sub

        Private Function completar(numero As Integer, caracteres As Integer) As String
            Dim s As String = numero.ToString
            While (s.Length < caracteres)
                s = "0" + s
            End While
            Return s
        End Function

        Sub New(folio As String)
            On Error Resume Next

            Dim dtConsulta As DataTable = sqlExecute("select * from consultas where folio = '" & folio & "'", "sermed")

            If dtConsulta.Rows.Count > 0 Then

                Dim row As DataRow = dtConsulta.Rows(0)

                Me.DatosCaptura = New DatosCapturaSermed(row)

                Me.folio = row("folio")

                Me.datos_clinicos = row("datos_clinicos")

                Me.comentarios = row("comentarios")

                Me.medicamentos = row("medicamentos")

                Me.tieneProx_cita = IIf(row("prox_cita").Equals(""), False, True)

                If Me.tieneProx_cita Then
                    Me.prox_cita = row("prox_cita")
                End If

                Me.peso = row("peso")

                Me.altura = row("altura")

                Me.imc = row("imc")

            End If

        End Sub

        Public Sub guardar()
            Dim dtExisteConsulta As DataTable = sqlExecute("select folio from consultas where folio = '" + folio + "'", "sermed")
            If dtExisteConsulta.Rows.Count <= 0 Then
                sqlExecute("insert into consultas (folio) values ('" + Me.folio + "')", "sermed")
            End If
            '
            ' datos generales
            sqlExecute("update consultas set reloj = '" & DatosCaptura.reloj & "', nombres = '" & DatosCaptura.nombres & "', fecha = '" & FechaSQL(DatosCaptura.fecha) & "' " & IIf(tieneProx_cita, ", prox_cita = '" & FechaSQL(prox_cita) & "'", "") & " where folio = '" & folio & "'", "sermed")
            'Usuario
            sqlExecute("update consultas set responsable = '" & DatosCaptura.responsable & "' where folio = '" + Me.folio + "'", "sermed")
            'datos externos
            sqlExecute("update consultas set externo = '" & DatosCaptura.externo & "', reloj_fam = '" & DatosCaptura.reloj_fam & "', edad = '" & DatosCaptura.edad & "', sexo = '" & DatosCaptura.sexo & "', empresa = '" & DatosCaptura.empresa & "' where folio = '" & folio & "'", "sermed")
            ' dadsadasa
            sqlExecute("update consultas set peso = '" & peso & "', altura = '" & altura & "', imc = '" & imc & "' where folio = '" + folio + "'", "sermed")
            '    ' causas/patologia
            '    sqlExecute("update visitas set cod_pato1 = '" & cod_pato1 & "', cod_pato2 = '" & cod_pato2 & "', cod_pato3  = '" & cod_pato3 & "' where folio = '" & folio & "'", "sermed")
            ' conclusiones
            sqlExecute("update consultas set comentarios = '" & comentarios & "', medicamentos = '" & medicamentos & "', datos_clinicos = '" & datos_clinicos & "' where folio = '" & folio & "'", "sermed")
            '
        End Sub

    End Class

    Public Class VisitaSermed
        Public concluida As Boolean = False

        Public folio As String

        Public DatosCaptura As DatosCapturaSermed

        'Public reloj As String = ""

        'Public nombres As String = ""

        'Public fecha As Date = Date.Now

        Public hora_entro As DateTime = Date.Now

        Public salida As String

        Public hora_salio As DateTime

        Public minutos As Integer

        Public tiempo As String = ""

        Public inyeccion As Boolean = False

        Public inyec_det As String = ""

        Public curacion As Boolean = False

        Public cura_det As String = ""

        Public plan_fam As Boolean = False

        Public cod_pato1 As String = "000"

        Public cod_pato2 As String = "000"

        Public cod_pato3 As String = "000"

        Public comentario As String = ""

        Public medicamento As String = ""

        Public responsable As String = ""

        Public consulta As Boolean = False

        Public acc_traba As Boolean = False

        Public acc_tray As Boolean = False

        Sub New()
            Dim dtVisita As DataTable = sqlExecute("select top 1 folio from visitas order by folio desc", "sermed")
            If dtVisita.Rows.Count > 0 Then
                Me.folio = completar(Integer.Parse(dtVisita.Rows(0)("folio")) + 1, 6)
            End If
            Me.DatosCaptura = New DatosCapturaSermed()
        End Sub

        Private Function completar(numero As Integer, caracteres As Integer) As String
            Dim s As String = numero.ToString
            While (s.Length < caracteres)
                s = "0" + s
            End While
            Return s
        End Function

        Sub New(folio As String)
            On Error Resume Next

            Dim dtVisita As DataTable = sqlExecute("select * from visitas where folio = '" & folio & "'", "sermed")

            If dtVisita.Rows.Count > 0 Then

                Dim row As DataRow = dtVisita.Rows(0)

                Me.DatosCaptura = New DatosCapturaSermed(row)

                Me.folio = row("folio")               
                Me.tiempo = row("tiempo")
                Me.hora_entro = row("hora_entro")
                Me.salida = row("hora_salio")
                'Me.responsable = row("responsable")

                If salida.Trim.Equals("") Then
                    concluida = False
                Else
                    concluida = True
                    hora_salio = row("hora_salio")
                End If

                Me.comentario = row("comentario")
                Me.medicamento = row("medicamento")
                Me.cod_pato1 = row("cod_pato1")
                Me.cod_pato2 = row("cod_pato2")
                Me.cod_pato3 = row("cod_pato3")
                Me.inyeccion = row("inyeccion")
                Me.cura_det = row("cura_det")
                Me.inyec_det = row("inyec_det")
                Me.curacion = row("curacion")
                Me.acc_traba = row("acc_traba")
                Me.acc_tray = row("acc_tray")
                Me.consulta = row("consulta")
                Me.plan_fam = row("plan_fam")
            End If
        End Sub

        Public Sub guardar()
            Dim dtExisteVisita As DataTable = sqlExecute("select folio from visitas where folio = '" + folio + "'", "sermed")
            If dtExisteVisita.Rows.Count <= 0 Then
                sqlExecute("insert into visitas (folio) values ('" + Me.folio + "')", "sermed")
            End If
            '
            ' datos generales
            'sqlExecute("update visitas set fecha = '" & FechaSQL(fecha) & "' where folio = '" & folio & "'", "sermed")

            If minutos > 0 Then
                hora_salio = hora_entro.AddMinutes(minutos)
            End If
            ' datos generales
            sqlExecute("update visitas set reloj = '" & DatosCaptura.reloj & "', nombres = '" & DatosCaptura.nombres & "', fecha = '" & FechaSQL(DatosCaptura.fecha) & "', hora_entro = '" & hora_entro.ToShortTimeString & "', tiempo = '" & tiempo & "', hora_salio = '" & IIf(tiempo.Equals(""), "", hora_salio.ToShortTimeString) & "' where folio = '" & folio & "'", "sermed")
            '' usuario
            sqlExecute("update visitas set responsable = '" & DatosCaptura.responsable & "' where folio = '" + Me.folio + "'", "sermed")
            ' datos externos
            sqlExecute("update visitas set externo = '" & DatosCaptura.externo & "', reloj_fam = '" & DatosCaptura.reloj_fam & "', edad = '" & DatosCaptura.edad & "', sexo = '" & DatosCaptura.sexo & "', empresa = '" & DatosCaptura.empresa & "' where folio = '" & folio & "'", "sermed")
            'asistencia()
            sqlExecute("update visitas set inyeccion = '" & inyeccion & "', inyec_det = '" & inyec_det & "', curacion = '" & curacion & "', cura_det = '" & cura_det & "', plan_fam = '" & plan_fam & "', acc_tray = '" & acc_tray & "', acc_traba = '" & acc_traba & "' where folio = '" + folio + "'", "sermed")
            ' causas/patologia
            sqlExecute("update visitas set cod_pato1 = '" & cod_pato1 & "', cod_pato2 = '" & cod_pato2 & "', cod_pato3  = '" & cod_pato3 & "' where folio = '" & folio & "'", "sermed")
            ' conclusiones
            sqlExecute("update visitas set comentario = '" & comentario & "', medicamento = '" & medicamento & "', consulta = '" & consulta & "' where folio = '" & folio & "'", "sermed")
        End Sub

    End Class

    Public Class EmpleadoSermed
        Public reloj As String
        Public nombres As String
        Public nombre As String
        Public apaterno As String
        Public amaterno As String
        Private fha_nac As Date
        Public edad As Integer
        Public sexo As String = "M"
        Public depto As String
        Public puesto As String
        Public turno As String
        Public tipo As String
        Public super As String
        Public clase As String
        Public horario As String
        Public alta As Date
        Public baja As String

        Sub New(reloj As String)

            If reloj <> "" Then
                Dim dtEmpleado As DataTable = sqlExecute("select * from personalsermed where reloj = '" + reloj + "'", "sermed")

                If dtEmpleado.Rows.Count > 0 Then
                    On Error Resume Next
                    Me.nombres = dtEmpleado.Rows(0)("nombres")
                    Me.nombre = dtEmpleado.Rows(0)("nombre")
                    Me.apaterno = dtEmpleado.Rows(0)("apaterno")
                    Me.amaterno = dtEmpleado.Rows(0)("amaterno")

                    Me.fha_nac = dtEmpleado.Rows(0)("fha_nac")

                    Me.edad = Date.Now.Subtract(fha_nac).TotalDays / 365

                    Me.depto = dtEmpleado.Rows(0)("cod_depto") & "(" & dtEmpleado.Rows(0)("depto") & ")"
                    Me.reloj = dtEmpleado.Rows(0)("reloj")
                    Me.sexo = dtEmpleado.Rows(0)("sexo")
                    Me.tipo = dtEmpleado.Rows(0)("cod_tipo") & "(" & dtEmpleado.Rows(0)("tipo") & ")"
                    Me.puesto = dtEmpleado.Rows(0)("cod_puesto") & "(" & dtEmpleado.Rows(0)("puesto") & ")"
                    Me.super = dtEmpleado.Rows(0)("cod_super") & "(" & dtEmpleado.Rows(0)("super") & ")"
                    Me.turno = dtEmpleado.Rows(0)("cod_turno") & "(" & dtEmpleado.Rows(0)("turno") & ")"
                    Me.horario = dtEmpleado.Rows(0)("cod_hora") & "(" & dtEmpleado.Rows(0)("hora") & ")"
                    Me.clase = dtEmpleado.Rows(0)("cod_clase") & "(" & dtEmpleado.Rows(0)("clase") & ")"
                    Me.alta = dtEmpleado.Rows(0)("alta")
                    Me.baja = IIf(IsDBNull(dtEmpleado.Rows(0)("baja")), "", dtEmpleado.Rows(0)("baja"))
                End If
            End If
        End Sub

    End Class

    Public Class DatosCapturaSermed        
        Public reloj As String = "Exter"
        Public nombres As String = ""
        Public nombre As String = ""
        Public apaterno As String = ""
        Public amaterno As String = ""
        Public empresa As String = ""
        Public fecha As Date = Date.Now
        Public responsable As String = IIf(Declaraciones.Usuario <> "", Declaraciones.Usuario, "PIDA")
        Public edad As String = ""
        Public sexo As String = ""
        Public reloj_fam As String = ""
        Public externo As Boolean = True

        Sub New()

        End Sub

        Sub New(empleado As EmpleadoSermed)
            Me.reloj = empleado.reloj
            Me.nombres = empleado.nombres
            If nombres.Length > 0 Then
                Me.apaterno = nombres.Split(",")(0)
                Me.amaterno = nombres.Split(",")(1)
                Me.nombre = nombres.Split(",")(2)
            End If
            Me.edad = empleado.edad
            Me.sexo = empleado.sexo
            Me.externo = False
        End Sub

        Sub New(row As DataRow)
            On Error Resume Next
            Me.externo = row("externo")
            Me.reloj = row("reloj")
            Me.fecha = row("fecha")
            nombres = row("nombres")
            Me.edad = row("edad")
            Me.sexo = row("sexo")

            If nombres.Length > 0 Then               
                Me.apaterno = nombres.Split(",")(0)
                Me.amaterno = nombres.Split(",")(1)
                Me.nombre = nombres.Split(",")(2)
            End If

            If Me.externo Then
                Me.empresa = row("empresa")
                Me.reloj_fam = row("reloj_fam")
            End If
        End Sub

    End Class
End Module
