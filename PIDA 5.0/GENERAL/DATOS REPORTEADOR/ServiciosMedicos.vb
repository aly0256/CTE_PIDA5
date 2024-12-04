Option Compare Text

Imports System.Data.SqlClient
Imports System.IO
Module ServiciosMedicos
    Dim dtTemp As New DataTable

    Public Function AddMyValues(ByVal Value1 As Double, ByVal Value2 As Double)
        Dim Result As Double
        Result = Value1 * Value2
        Return Result
    End Function
    Public Sub RelacionConsultas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim dr As DataRow

        'Cursor = Cursors.WaitCursor

        Try
            'Crear estructura de datos
            dtDatos = New DataTable("Datos")


            dtDatos.Columns.Add("Prioridad", System.Type.GetType("System.Int16"))
            dtDatos.Columns.Add("grupo", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_grupo", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("subgrupo", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_subgrupo", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("hombres", System.Type.GetType("System.Int16"))
            dtDatos.Columns.Add("mujeres", System.Type.GetType("System.Int16"))
            dtDatos.Columns.Add("indefinido", System.Type.GetType("System.Int16"))
            dtDatos.Columns.Add("FECHA_INICIO", System.Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("FECHA_FIN", System.Type.GetType("System.DateTime"))

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("grupo"), dtDatos.Columns("subgrupo")}

            'Repasar cada registro original para agruparlo en su depto. correspondiente y contabilizar sexo



            Dim frm_fechas As New frmRangoFechas
            frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
            frm_fechas.frmRangoFechas_fecha_fin = Now
            frm_fechas.ShowDialog()



            ' POR SERVICIO
            For Each row In dtInformacion.Select("fecha >= '" & FechaSQL(FechaInicial) & "' and fecha <= '" & FechaSQL(FechaFinal) & "'")

                'Grupo
                Dim grupo As String = "0 - SERVICIO"
                Dim nombre_grupo As String = "Servicio"
                Dim subgrupo As String = IIf(IsDBNull(row("cod_servicio")), "INDF", row("cod_servicio"))
                Dim nombre_subgrupo As String = IIf(IsDBNull(row("nombre_servicio")), "Indefinido", row("nombre_servicio"))

                If subgrupo.StartsWith("MED") Then
                    subgrupo = "MED 1, 2 & 3"
                    nombre_subgrupo = "Servicio Médico"
                ElseIf subgrupo.Trim = "" Then
                    subgrupo = "INDF"
                    nombre_subgrupo = "Indefinido"
                End If

                Dim sexo As String = IIf(IsDBNull(row("sexo")), "I", (row("sexo")))

                dr = dtDatos.Rows.Find({grupo, subgrupo})

                If IsNothing(dr) Then
                    ' Si no existe, crear y agregar

                    dr = dtDatos.NewRow

                    dr("prioridad") = 0
                    dr("grupo") = grupo
                    dr("subgrupo") = subgrupo

                    dr("nombre_grupo") = nombre_grupo
                    dr("nombre_subgrupo") = nombre_subgrupo

                    dr("hombres") = IIf(sexo = "M", 1, 0)
                    dr("mujeres") = IIf(sexo = "F", 1, 0)
                    dr("indefinido") = IIf(sexo = "I", 1, 0)
                    dr("FECHA_INICIO") = FechaSQL(FechaInicial)
                    dr("FECHA_FIN") = FechaSQL(FechaFinal)
                    dtDatos.Rows.Add(dr)

                    'dtDatos.Rows.Add(dtRow.item("encargado_servicio"), IIf(Sexo = "M", 1, 0), IIf(Sexo = "F", 1, 0), IIf(IsDBNull(Sexo), 1, 0))
                Else
                    'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
                    dr("hombres") += IIf(sexo = "M", 1, 0)
                    dr("mujeres") += IIf(sexo = "F", 1, 0)
                    dr("indefinido") += IIf(sexo = "I", 1, 0)
                End If
            Next

            'POR MEDICO
            For Each row In dtInformacion.Select("fecha >= '" & FechaSQL(FechaInicial) & "' and fecha <= '" & FechaSQL(FechaFinal) & "'")

                'Grupo
                Dim grupo As String = "1 - MEDICO"
                Dim nombre_grupo As String = "Médico"
                Dim subgrupo As String = IIf(IsDBNull(row("cod_servicio")), "INDF", row("cod_servicio"))

                Dim nombre_subgrupo As String = IIf(IsDBNull(row("encargado_servicio")), "Indefinido", row("encargado_servicio"))

                If subgrupo.Trim = "" Then
                    subgrupo = "INDF"
                    nombre_subgrupo = "Indefinido"
                ElseIf nombre_subgrupo.ToUpper.StartsWith("INDEF") Then
                    nombre_subgrupo = nombre_subgrupo.ToLower
                End If

                Dim sexo As String = IIf(IsDBNull(row("sexo")), "I", (row("sexo")))

                dr = dtDatos.Rows.Find({grupo, subgrupo})

                If IsNothing(dr) Then
                    ' Si no existe, crear y agregar

                    dr = dtDatos.NewRow

                    dr("prioridad") = 1
                    dr("grupo") = grupo
                    dr("subgrupo") = subgrupo

                    dr("nombre_grupo") = nombre_grupo
                    dr("nombre_subgrupo") = nombre_subgrupo

                    dr("hombres") = IIf(sexo = "M", 1, 0)
                    dr("mujeres") = IIf(sexo = "F", 1, 0)
                    dr("indefinido") = IIf(sexo = "I", 1, 0)
                    dr("FECHA_INICIO") = FechaSQL(FechaInicial)
                    dr("FECHA_FIN") = FechaSQL(FechaFinal)
                    dtDatos.Rows.Add(dr)

                    'dtDatos.Rows.Add(dtRow.item("encargado_servicio"), IIf(Sexo = "M", 1, 0), IIf(Sexo = "F", 1, 0), IIf(IsDBNull(Sexo), 1, 0))
                Else
                    'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
                    dr("hombres") += IIf(sexo = "M", 1, 0)
                    dr("mujeres") += IIf(sexo = "F", 1, 0)
                    dr("indefinido") += IIf(sexo = "I", 1, 0)
                End If
            Next

            'POR PLANTA
            For Each row In dtInformacion.Select("fecha >= '" & FechaSQL(FechaInicial) & "' and fecha <= '" & FechaSQL(FechaFinal) & "'")

                'Grupo
                Dim grupo As String = "5 - PLANTA"
                Dim nombre_grupo As String = "Planta"

                Dim subgrupo As String = IIf(IsDBNull(row("cod_planta")), "ND", row("cod_planta"))
                Dim nombre_subgrupo As String = IIf(IsDBNull(row("nombre_planta")), "Indefinido", row("nombre_planta"))

                If subgrupo.Trim = "" Then
                    subgrupo = "ND"
                    nombre_subgrupo = "Indefinido"
                End If

                Dim sexo As String = IIf(IsDBNull(row("sexo")), "I", (row("sexo")))

                dr = dtDatos.Rows.Find({grupo, subgrupo})

                If IsNothing(dr) Then
                    ' Si no existe, crear y agregar

                    dr = dtDatos.NewRow

                    dr("prioridad") = 5
                    dr("grupo") = grupo
                    dr("subgrupo") = subgrupo

                    dr("nombre_grupo") = nombre_grupo
                    dr("nombre_subgrupo") = StrConv(nombre_subgrupo, VbStrConv.ProperCase)

                    dr("hombres") = IIf(sexo = "M", 1, 0)
                    dr("mujeres") = IIf(sexo = "F", 1, 0)
                    dr("indefinido") = IIf(sexo = "I", 1, 0)
                    dr("FECHA_INICIO") = FechaSQL(FechaInicial)
                    dr("FECHA_FIN") = FechaSQL(FechaFinal)
                    dtDatos.Rows.Add(dr)

                    'dtDatos.Rows.Add(dtRow.item("encargado_servicio"), IIf(Sexo = "M", 1, 0), IIf(Sexo = "F", 1, 0), IIf(IsDBNull(Sexo), 1, 0))
                Else
                    'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
                    dr("hombres") += IIf(sexo = "M", 1, 0)
                    dr("mujeres") += IIf(sexo = "F", 1, 0)
                    dr("indefinido") += IIf(sexo = "I", 1, 0)
                End If
            Next

            'POR TIPO CONSULTA
            For Each row In dtInformacion.Select("fecha >= '" & FechaSQL(FechaInicial) & "' and fecha <= '" & FechaSQL(FechaFinal) & "'")

                'Grupo
                Dim grupo As String = "2 - TIPO"
                Dim nombre_grupo As String = "Tipo de consulta"

                Dim subgrupo As String = IIf(IsDBNull(row("familiar")), "0", row("familiar"))
                Dim nombre_subgrupo As String = IIf(subgrupo = 1, "Consulta familiar", "Consulta empleado")


                Dim sexo As String = IIf(IsDBNull(row("sexo")), "I", (row("sexo")))

                dr = dtDatos.Rows.Find({grupo, subgrupo})

                If IsNothing(dr) Then
                    ' Si no existe, crear y agregar

                    dr = dtDatos.NewRow

                    dr("prioridad") = 2
                    dr("grupo") = grupo
                    dr("subgrupo") = subgrupo

                    dr("nombre_grupo") = nombre_grupo
                    dr("nombre_subgrupo") = nombre_subgrupo

                    dr("hombres") = IIf(sexo = "M", 1, 0)
                    dr("mujeres") = IIf(sexo = "F", 1, 0)
                    dr("indefinido") = IIf(sexo = "I", 1, 0)
                    dr("FECHA_INICIO") = FechaSQL(FechaInicial)
                    dr("FECHA_FIN") = FechaSQL(FechaFinal)
                    dtDatos.Rows.Add(dr)

                    'dtDatos.Rows.Add(dtRow.item("encargado_servicio"), IIf(Sexo = "M", 1, 0), IIf(Sexo = "F", 1, 0), IIf(IsDBNull(Sexo), 1, 0))
                Else
                    'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
                    dr("hombres") += IIf(sexo = "M", 1, 0)
                    dr("mujeres") += IIf(sexo = "F", 1, 0)
                    dr("indefinido") += IIf(sexo = "I", 1, 0)
                End If
            Next


            'POR CC
            'For Each row In dtInformacion.Select("fecha >= '" & FechaSQL(FechaInicial) & "' and fecha <= '" & FechaSQL(FechaFinal) & "'")

            '    'Grupo
            '    Dim grupo As String = "5 - CC"
            '    Dim nombre_grupo As String = "Centro de costos"

            '    Dim subgrupo As String = IIf(IsDBNull(row("cod_depto")), "ND", row("cod_depto"))
            '    Dim nombre_subgrupo As String = IIf(IsDBNull(row("nombre_depto")), "No Disponible", row("nombre_depto"))

            '    Dim dtCC As DataTable = sqlExecute("select * from c_costos where centro_costos in (select centro_costos from deptos where cod_depto = '" & subgrupo.Trim & "')")
            '    If dtCC.Rows.Count > 0 Then
            '        subgrupo = dtCC.Rows(0)("centro_costos")
            '        nombre_subgrupo = dtCC.Rows(0)("nombre")
            '    End If

            '    If subgrupo.Trim = "" Then
            '        subgrupo = "ND"
            '        nombre_subgrupo = "Indefinido"
            '    End If

            '    Dim sexo As String = IIf(IsDBNull(row("sexo")), "I", (row("sexo")))

            '    dr = dtDatos.Rows.Find({grupo, subgrupo})

            '    If IsNothing(dr) Then
            '        ' Si no existe, crear y agregar

            '        dr = dtDatos.NewRow

            '        dr("prioridad") = 5
            '        dr("grupo") = grupo
            '        dr("subgrupo") = subgrupo

            '        dr("nombre_grupo") = nombre_grupo
            '        dr("nombre_subgrupo") = nombre_subgrupo

            '        dr("hombres") = IIf(sexo = "M", 1, 0)
            '        dr("mujeres") = IIf(sexo = "F", 1, 0)
            '        dr("indefinido") = IIf(sexo = "I", 1, 0)

            '        dtDatos.Rows.Add(dr)

            '        'dtDatos.Rows.Add(dtRow.item("encargado_servicio"), IIf(Sexo = "M", 1, 0), IIf(Sexo = "F", 1, 0), IIf(IsDBNull(Sexo), 1, 0))
            '    Else
            '        'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
            '        dr("hombres") += IIf(sexo = "M", 1, 0)
            '        dr("mujeres") += IIf(sexo = "F", 1, 0)
            '        dr("indefinido") += IIf(sexo = "I", 1, 0)
            '    End If
            'Next


            'POR AREA
            For Each row In dtInformacion.Select("fecha >= '" & FechaSQL(FechaInicial) & "' and fecha <= '" & FechaSQL(FechaFinal) & "'")

                'Grupo
                Dim grupo As String = "6 - AREA"
                Dim nombre_grupo As String = "Area"

                Dim subgrupo As String = IIf(IsDBNull(row("cod_area")), "ND", row("cod_area"))
                Dim nombre_subgrupo As String = IIf(IsDBNull(row("nombre_area")), "Indefinido", row("nombre_area"))

                If subgrupo.Trim = "" Then
                    subgrupo = "ND"
                    nombre_subgrupo = "Indefinido"
                End If

                Dim sexo As String = IIf(IsDBNull(row("sexo")), "I", (row("sexo")))

                dr = dtDatos.Rows.Find({grupo, subgrupo})

                If IsNothing(dr) Then
                    ' Si no existe, crear y agregar

                    dr = dtDatos.NewRow

                    dr("prioridad") = 6
                    dr("grupo") = grupo
                    dr("subgrupo") = subgrupo

                    dr("nombre_grupo") = nombre_grupo
                    dr("nombre_subgrupo") = nombre_subgrupo

                    dr("hombres") = IIf(sexo = "M", 1, 0)
                    dr("mujeres") = IIf(sexo = "F", 1, 0)
                    dr("indefinido") = IIf(sexo = "I", 1, 0)
                    dr("FECHA_INICIO") = FechaSQL(FechaInicial)
                    dr("FECHA_FIN") = FechaSQL(FechaFinal)
                    dtDatos.Rows.Add(dr)

                    'dtDatos.Rows.Add(dtRow.item("encargado_servicio"), IIf(Sexo = "M", 1, 0), IIf(Sexo = "F", 1, 0), IIf(IsDBNull(Sexo), 1, 0))
                Else
                    'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
                    dr("hombres") += IIf(sexo = "M", 1, 0)
                    dr("mujeres") += IIf(sexo = "F", 1, 0)
                    dr("indefinido") += IIf(sexo = "I", 1, 0)
                End If
            Next

            'POR CLASE
            For Each row In dtInformacion.Select("fecha >= '" & FechaSQL(FechaInicial) & "' and fecha <= '" & FechaSQL(FechaFinal) & "'")

                'Grupo
                Dim grupo As String = "7 - CLASE"
                Dim nombre_grupo As String = "Clase"

                Dim subgrupo As String = IIf(IsDBNull(row("cod_clase")), "ND", row("cod_clase"))
                Dim nombre_subgrupo As String = IIf(IsDBNull(row("nombre_clase")), "Indefinido", row("nombre_clase"))

                If subgrupo.Trim = "" Then
                    subgrupo = "ND"
                    nombre_subgrupo = "Indefinido"
                End If

                Dim sexo As String = IIf(IsDBNull(row("sexo")), "I", (row("sexo")))

                dr = dtDatos.Rows.Find({grupo, subgrupo})

                If IsNothing(dr) Then
                    ' Si no existe, crear y agregar

                    dr = dtDatos.NewRow

                    dr("prioridad") = 7
                    dr("grupo") = grupo
                    dr("subgrupo") = subgrupo

                    dr("nombre_grupo") = nombre_grupo
                    dr("nombre_subgrupo") = nombre_subgrupo

                    dr("hombres") = IIf(sexo = "M", 1, 0)
                    dr("mujeres") = IIf(sexo = "F", 1, 0)
                    dr("indefinido") = IIf(sexo = "I", 1, 0)
                    dr("FECHA_INICIO") = FechaSQL(FechaInicial)
                    dr("FECHA_FIN") = FechaSQL(FechaFinal)
                    dtDatos.Rows.Add(dr)

                    'dtDatos.Rows.Add(dtRow.item("encargado_servicio"), IIf(Sexo = "M", 1, 0), IIf(Sexo = "F", 1, 0), IIf(IsDBNull(Sexo), 1, 0))
                Else
                    'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
                    dr("hombres") += IIf(sexo = "M", 1, 0)
                    dr("mujeres") += IIf(sexo = "F", 1, 0)
                    dr("indefinido") += IIf(sexo = "I", 1, 0)
                End If
            Next

            'POR PARENTESCO
            For Each row In dtInformacion.Select("fecha >= '" & FechaSQL(FechaInicial) & "' and fecha <= '" & FechaSQL(FechaFinal) & "'")

                'Grupo
                Dim grupo As String = "3 - PARENTESCO"
                Dim nombre_grupo As String = "Parentesco"

                Dim subgrupo As String = IIf(row("familiar") = 0, "EM", IIf(IsDBNull(row("cod_familia")), "ND", row("cod_familia")))
                Dim nombre_subgrupo As String = IIf(row("familiar") = 0, "Empleado", IIf(IsDBNull(row("parentesco")), "Indefinido", row("parentesco")))
                'Dim nombre_subgrupo As String = 

                If subgrupo.Trim = "" Then
                    subgrupo = "ND"
                    nombre_subgrupo = "Indefinido"
                End If

                Dim sexo As String = IIf(IsDBNull(row("sexo")), "I", (row("sexo")))

                dr = dtDatos.Rows.Find({grupo, subgrupo})

                If IsNothing(dr) Then
                    ' Si no existe, crear y agregar

                    dr = dtDatos.NewRow

                    dr("prioridad") = 3
                    dr("grupo") = grupo
                    dr("subgrupo") = subgrupo

                    dr("nombre_grupo") = nombre_grupo
                    dr("nombre_subgrupo") = nombre_subgrupo

                    dr("hombres") = IIf(sexo = "M", 1, 0)
                    dr("mujeres") = IIf(sexo = "F", 1, 0)
                    dr("indefinido") = IIf(sexo = "I", 1, 0)
                    dr("FECHA_INICIO") = FechaSQL(FechaInicial)
                    dr("FECHA_FIN") = FechaSQL(FechaFinal)
                    dtDatos.Rows.Add(dr)

                    'dtDatos.Rows.Add(dtRow.item("encargado_servicio"), IIf(Sexo = "M", 1, 0), IIf(Sexo = "F", 1, 0), IIf(IsDBNull(Sexo), 1, 0))
                Else
                    'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
                    dr("hombres") += IIf(sexo = "M", 1, 0)
                    dr("mujeres") += IIf(sexo = "F", 1, 0)
                    dr("indefinido") += IIf(sexo = "I", 1, 0)
                End If
            Next

            'POR TURNO
            For Each row In dtInformacion.Select("fecha >= '" & FechaSQL(FechaInicial) & "' and fecha <= '" & FechaSQL(FechaFinal) & "'")

                'Grupo
                Dim grupo As String = "8 - TURNO"
                Dim nombre_grupo As String = "Turno"

                Dim subgrupo As String = IIf(IsDBNull(row("cod_turno")), "ND", row("cod_turno"))
                Dim nombre_subgrupo As String = IIf(IsDBNull(row("nombre_turno")), "Indefinido", row("nombre_turno"))

                If subgrupo.Trim = "" Then
                    subgrupo = "ND"
                    nombre_subgrupo = "Indefinido"
                End If
                If nombre_subgrupo <> "Indefinido" Then
                    nombre_subgrupo = nombre_subgrupo.Substring(0, 7)
                End If
                Dim sexo As String = IIf(IsDBNull(row("sexo")), "I", (row("sexo")))

                dr = dtDatos.Rows.Find({grupo, subgrupo})

                If IsNothing(dr) Then
                    ' Si no existe, crear y agregar

                    dr = dtDatos.NewRow

                    dr("prioridad") = 8
                    dr("grupo") = grupo
                    dr("subgrupo") = subgrupo

                    dr("nombre_grupo") = nombre_grupo
                    dr("nombre_subgrupo") = nombre_subgrupo

                    dr("hombres") = IIf(sexo = "M", 1, 0)
                    dr("mujeres") = IIf(sexo = "F", 1, 0)
                    dr("indefinido") = IIf(sexo = "I", 1, 0)
                    dr("FECHA_INICIO") = FechaSQL(FechaInicial)
                    dr("FECHA_FIN") = FechaSQL(FechaFinal)
                    dtDatos.Rows.Add(dr)

                    'dtDatos.Rows.Add(dtRow.item("encargado_servicio"), IIf(Sexo = "M", 1, 0), IIf(Sexo = "F", 1, 0), IIf(IsDBNull(Sexo), 1, 0))
                Else
                    'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
                    dr("hombres") += IIf(sexo = "M", 1, 0)
                    dr("mujeres") += IIf(sexo = "F", 1, 0)
                    dr("indefinido") += IIf(sexo = "I", 1, 0)
                End If
            Next

            'POR PADECIMIENTO
            For Each row In dtInformacion.Select("fecha >= '" & FechaSQL(FechaInicial) & "' and fecha <= '" & FechaSQL(FechaFinal) & "'")

                'Grupo
                Dim grupo As String = "4 - PADECIMIENTO"
                Dim nombre_grupo As String = "Padecimiento"

                Dim subgrupo As String = IIf(IsDBNull(row("sintoma")), "ND", row("sintoma"))
                Dim nombre_subgrupo As String = IIf(IsDBNull(row("nombre_sintoma")), "Indefinido", row("nombre_sintoma"))

                If subgrupo.Trim = "" Then
                    subgrupo = "ND"
                    nombre_subgrupo = "Indefinido"
                End If

                Dim sexo As String = IIf(IsDBNull(row("sexo")), "I", (row("sexo")))

                dr = dtDatos.Rows.Find({grupo, subgrupo})

                If IsNothing(dr) Then
                    ' Si no existe, crear y agregar

                    dr = dtDatos.NewRow

                    dr("prioridad") = 4
                    dr("grupo") = grupo
                    dr("subgrupo") = subgrupo

                    dr("nombre_grupo") = nombre_grupo
                    dr("nombre_subgrupo") = StrConv(nombre_subgrupo, VbStrConv.ProperCase)

                    dr("hombres") = IIf(sexo = "M", 1, 0)
                    dr("mujeres") = IIf(sexo = "F", 1, 0)
                    dr("indefinido") = IIf(sexo = "I", 1, 0)
                    dr("FECHA_INICIO") = FechaSQL(FechaInicial)
                    dr("FECHA_FIN") = FechaSQL(FechaFinal)
                    dtDatos.Rows.Add(dr)

                    'dtDatos.Rows.Add(dtRow.item("encargado_servicio"), IIf(Sexo = "M", 1, 0), IIf(Sexo = "F", 1, 0), IIf(IsDBNull(Sexo), 1, 0))
                Else
                    'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
                    dr("hombres") += IIf(sexo = "M", 1, 0)
                    dr("mujeres") += IIf(sexo = "F", 1, 0)
                    dr("indefinido") += IIf(sexo = "I", 1, 0)
                End If
            Next

        Catch ex As Exception
            'ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

        'Cursor = Cursors.Default
    End Sub

    Public Sub Familiares16(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos = New DataTable
        dtDatos.Columns.Add("folio", Type.GetType("System.String"))
        dtDatos.Columns.Add("inicio", Type.GetType("System.String"))
        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_empleado", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre", Type.GetType("System.String"))
        dtDatos.Columns.Add("edad", Type.GetType("System.String"))
        dtDatos.Columns.Add("encargado", Type.GetType("System.String"))

        Dim dtSeleccion As DataTable
        Try
            dtSeleccion = sqlExecute("SELECT SUBSTRING(SUBSTRING(SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) , CHARINDEX( ',' , SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) ) + 1 , LEN( SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) ) - (CHARINDEX( ',' , SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) ) -2 )) , CHARINDEX( ',' , SUBSTRING(SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) , CHARINDEX( ',' , SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) ) + 1 , LEN( SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) ) - (CHARINDEX( ',' , SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) ) -2 )) ) + 1 , LEN( SUBSTRING(SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) , CHARINDEX( ',' , SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) ) + 1 , LEN( SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) ) - (CHARINDEX( ',' , SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) ) -2 )) ) - (CHARINDEX( ',' , SUBSTRING(SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) , CHARINDEX( ',' , SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) ) + 1 , LEN( SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) ) - (CHARINDEX( ',' , SUBSTRING(nombre_paciente , CHARINDEX( ',' , nombre_paciente ) + 1 , LEN( nombre_paciente ) - (CHARINDEX( ',' , nombre_paciente ) -2 )) ) -2 )) ) -2 )) as nombre ,consultas.*,servicios.encargado,familiares.cod_familia,rtrim(personal.nombre)+' '+rtrim(personal.apaterno)+' '+rtrim(personal.amaterno) as nombre_empleado FROM sermed.dbo.consultas left join SERMED.dbo.servicios on consultas.cod_servicio=servicios.cod_servicio left join PERSONAL.dbo.familiares on consultas.id_familiar=familiares.idFld left join PERSONAL.dbo.personal on personal.reloj=consultas.reloj where familiar=1 and (cod_familia=08 or cod_familia=07) and ((len(substring(edad,1,2))>1 and substring(edad,1,2)>='16' and (SUBSTRING(edad, 1, 8) not like '%mes%') and (SUBSTRING(edad, 1, 8) not like '%días%')))")
            For Each registro As DataRow In dtSeleccion.Rows
                Dim fila As DataRow
                fila = dtDatos.NewRow
                fila("folio") = registro("folio")
                fila("inicio") = registro("inicio")
                fila("reloj") = registro("reloj")
                fila("nombre_empleado") = registro("nombre_empleado")
                fila("nombre") = registro("nombre")
                fila("edad") = registro("edad")
                fila("encargado") = registro("encargado")

                dtDatos.Rows.Add(fila)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Expediente(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_paciente", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
            dtDatos.Columns.Add("sexo", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_nac", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("alta", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("baja", Type.GetType("System.DateTime"))

            dtDatos.Columns.Add("fecha", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("hora", Type.GetType("System.String"))
            dtDatos.Columns.Add("encargado_servicio", Type.GetType("System.String"))
            dtDatos.Columns.Add("nota_medica", Type.GetType("System.String"))
            dtDatos.Columns.Add("tratamiento", Type.GetType("System.String"))
            dtDatos.Columns.Add("indicaciones", Type.GetType("System.String"))

            Dim filtros As String = frmReporteadorSermed.FiltrosAcumulados

            For Each drow As DataRow In dtInformacion.Select(filtros)
                Dim row As DataRow
                row = dtDatos.NewRow
                row("reloj") = drow("reloj")
                row("nombre_paciente") = IIf(IsDBNull(drow("nombre_paciente")), "", drow("nombre_paciente"))
                row("nombres") = IIf(IsDBNull(drow("nombres")), "", drow("nombres"))
                row("sexo") = IIf(IsDBNull(drow("sexo")), "", drow("sexo"))
                row("fecha_nac") = IIf(IsDBNull(drow("fecha_nac")), DBNull.Value, drow("fecha_nac"))
                row("alta") = IIf(IsDBNull(drow("alta")), DBNull.Value, drow("alta"))
                row("baja") = IIf(IsDBNull(drow("baja")), DBNull.Value, drow("baja"))
                row("fecha") = IIf(IsDBNull(drow("fecha")), DBNull.Value, drow("fecha"))
                row("hora") = IIf(IsDBNull(drow("hora")), "", drow("hora"))
                row("encargado_servicio") = IIf(IsDBNull(drow("encargado_servicio")), "", drow("encargado_servicio"))
                row("nota_medica") = IIf(IsDBNull(drow("nota_medica")), "", drow("nota_medica"))
                row("tratamiento") = IIf(IsDBNull(drow("tratamiento")), "", drow("tratamiento"))
                row("indicaciones") = IIf(IsDBNull(drow("indicaciones")), "", drow("indicaciones"))
                dtDatos.Rows.Add(row)
            Next
        Catch ex As Exception

        End Try

    End Sub
End Module
