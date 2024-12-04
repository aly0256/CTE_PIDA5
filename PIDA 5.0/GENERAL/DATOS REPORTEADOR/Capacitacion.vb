

Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Globalization

Module Capacitacion

    '==Funcion para crear reporte de empleados por curso            4oct2021
    '==Se toma como base la funcion "MatrizCapacitacionPorEmpleado"
    Public Sub MatrizCapacitacionPorCurso(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            EncabezadoReporte = MesLetra(Date.Now) + " " + Date.Now.Year.ToString
            Dim dtTemp As DataTable = Nothing
            Dim strCodCurso As String = ""

            If dtInformacion.Rows.Count > 0 Then
                strCodCurso = dtInformacion.Rows(0)("cod_curso").ToString
            End If

            dtDatos = dtInformacion.Clone

            For Each x As DataRow In dtInformacion.Rows
                dtDatos.ImportRow(x)
            Next

            Dim strDatosCurso As String = "SELECT TOP 1 RTRIM(CR.COD_CURSO) AS COD_CURSO,RTRIM(CR.NOMBRE) AS NOMBRE_CURSO," & _
                                                                "RTRIM(CR.COD_AREA+' - '+AT.NOMBRE) AS AREA_TEMATICA,RTRIM(RTRIM(CL.COD_CLASIF)+' - '+CL.NOMBRE) AS CLASIFICACION," & _
                                                                "RTRIM(CAT.CATEGORIA) AS CATEGORIA " & _
                                                                "FROM CAPACITACION.DBO.cursos CR LEFT JOIN CAPACITACION.DBO.clasificacion CL " & _
                                                                "ON CL.COD_CLASIF=CR.COD_CLASIF LEFT JOIN CAPACITACION.DBO.areas_tematicas AT " & _
                                                                "ON AT.COD_AREA=CR.COD_AREA LEFT JOIN CAPACITACION.DBO.modalidades MD " & _
                                                                "ON MD.MODALIDAD=CR.MODALIDAD LEFT JOIN CAPACITACION.DBO.objetivos OB " & _
                                                                "ON OB.OBJETIVO=CR.OBJETIVO LEFT JOIN CAPACITACION.DBO.Categorias_cursos CAT " & _
                                                                "ON RTRIM(CR.ORDEN_NIVEL) LIKE RTRIM(CONVERT(varchar,CAT.ORDEN))+'%' " & _
                                                                "WHERE CR.COD_CURSO='" & strCodCurso & "'"

            dtTemp = sqlExecute(strDatosCurso)

            dtDatos.Columns.Add("NOMBRE_CURSO")
            dtDatos.Columns.Add("AREA_TEMATICA")
            dtDatos.Columns.Add("CLASIFICACION")
            dtDatos.Columns.Add("CATEGORIA")

            dtDatos.Columns.Add("TOTAL_CURSOS")
            dtDatos.Columns.Add("CURSOS_COMP")
            dtDatos.Columns.Add("CURSOS_PL")
            dtDatos.Columns.Add("TC")
            dtDatos.Columns.Add("CC")
            dtDatos.Columns.Add("CPL")

            '== Conteo de completados y planeados
            Dim valores(2) As Double : Dim cont As Integer = 0 : Dim c As Integer = 0 : Dim porcentaje As Double = 0.0
            Dim filtro() As String = {"reloj is not null", "estatus='CM'", "estatus='PL'"}

            For Each s As String In filtro
                For Each row As DataRow In dtDatos.Select(s)
                    cont += 1
                Next
                valores(c) = cont
                cont = 0
                c += 1
            Next

            For Each i As DataRow In dtDatos.Rows
                i.Item("NOMBRE_CURSO") = dtTemp.Rows(0)("NOMBRE_CURSO")
                i.Item("AREA_TEMATICA") = dtTemp.Rows(0)("AREA_TEMATICA")
                i.Item("CLASIFICACION") = dtTemp.Rows(0)("CLASIFICACION")
                i.Item("CATEGORIA") = dtTemp.Rows(0)("CATEGORIA")
                i.Item("TOTAL_CURSOS") = valores(0)
                i.Item("CURSOS_COMP") = valores(1)
                i.Item("CURSOS_PL") = valores(2)
                i.Item("TC") = "100%"
                i.Item("CC") = Math.Round((valores(1) / valores(0)) * 100, 2).ToString & "%"
                i.Item("CPL") = Math.Round((valores(2) / valores(0)) * 100, 2).ToString & "%"
            Next

            '== Cambiar formato de fecha
            Dim varFecha As String = "" : Dim arrAltas As New ArrayList
            dtTemp = Nothing
            dtTemp = dtDatos.Clone
            dtTemp.Columns("alta").DataType = GetType(String)

            For Each x As DataRow In dtDatos.Rows
                dtTemp.ImportRow(x)
                For Each row As DataRow In dtTemp.Rows
                    If row("inicio") <> "---" Or row("fin") <> "---" Then
                        varFecha = FechaSQL(row("inicio"))
                        row("inicio") = ""
                        row("inicio") = varFecha
                        varFecha = FechaSQL(row("fin"))
                        row("fin") = ""
                        row("fin") = varFecha
                    End If
                    varFecha = FechaSQL(row("alta"))
                    row("alta") = ""
                    row("alta") = varFecha
                Next
            Next
            dtDatos = Nothing
            dtDatos = dtTemp.Copy

        Catch ex As Exception

        End Try
    End Sub

    '==Empleados certificados       agosto2021       Ernesto
    Public Sub EmpleadosCertificados(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            '== Rango de fechas de acuerdo a la seleccion en la forma
            Dim vencidos As Integer = 0 : Dim certificados As Integer = 0 : Dim total As Double = 0.0

            Dim frm_tipoEmp As New frmTipoEmpleado
            frm_tipoEmp.ShowDialog()

            If frm_tipoEmp.tipo_emp <> "" Then
                Dim dtPersonal As DataTable = sqlExecute("select * from personal.dbo.personalvw where baja is null and tipo_periodo in ('" & frm_tipoEmp.tipo_emp & "')")
                dtDatos.Columns.Add("reloj")
                dtDatos.Columns.Add("nombres")
                dtDatos.Columns.Add("alta")
                dtDatos.Columns.Add("nombre_depto")
                dtDatos.Columns.Add("nombre_puesto")
                dtDatos.Columns.Add("fecha_limite")
                dtDatos.Columns.Add("estatus")
                dtDatos.Columns.Add("vencidos")
                dtDatos.Columns.Add("por_vencidos")
                dtDatos.Columns.Add("certificados")
                dtDatos.Columns.Add("por_certificados")
                dtDatos.Columns.Add("fecha_limite_recert")
                dtDatos.Columns.Add("estatus_recert")

                Dim f_ini As String = FechaSQL(FechaInicial)
                Dim f_fin As String = FechaSQL(FechaFinal)

                Dim query As String = "select * from capacitacion.dbo.certi"
                Dim dtCertificados As DataTable = sqlExecute(query)

                Dim clock As String = "", nombres As String = "", alta As String = "", nombre_depto As String = "", nombre_puesto As String = ""
                Dim cod_puesto = ""
                Dim estatus As Integer = 0
                Dim dif As Integer = 0
                Dim f_limite As Date
                Dim f_limite_recert As Date
                Dim estatus_recert As Integer = 0
                Dim dif_recert As Integer = 0

                For Each x As DataRow In dtPersonal.Rows
                    ' For Each x As DataRow In dtPersonal.Select("reloj='01065'")
                    Try
                        Try : clock = x.Item("reloj").ToString.Trim : Catch ex As Exception : clock = "" : End Try
                        Try : cod_puesto = x.Item("cod_puesto").ToString.Trim : Catch ex As Exception : cod_puesto = "" : End Try
                        Try : nombres = x.Item("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
                        Try : alta = FechaSQL(x.Item("alta")) : Catch ex As Exception : alta = "" : End Try
                        Try : nombre_depto = x.Item("nombre_depto").ToString.Trim : Catch ex As Exception : nombre_depto = "" : End Try
                        Try : nombre_puesto = x.Item("nombre_puesto").ToString.Trim : Catch ex As Exception : nombre_puesto = "" : End Try

                        dif = DateDiff(DateInterval.Month, x.Item("alta"), Now.Date)
                        f_limite = DateAdd(DateInterval.Month, 3.0, x.Item("alta"))
                        estatus = IIf(dif >= 3, 0, -1)
                        For Each y As DataRow In dtCertificados.Select("reloj ='" & clock & "' and cod_puesto ='" & cod_puesto & "' and aprobado='1'")
                            estatus = 1
                        Next
                        Dim drow As DataRow = dtDatos.NewRow
                        drow("reloj") = clock
                        drow("nombres") = nombres
                        drow("alta") = alta
                        drow("nombre_depto") = nombre_depto
                        drow("nombre_puesto") = nombre_puesto
                        drow("fecha_limite") = FechaSQL(f_limite)
                        If estatus = -1 Then drow("estatus") = "En tiempo"
                        If estatus = 0 Then drow("estatus") = "Vencido"
                        If estatus = 1 Then drow("estatus") = "Certificado"

                        '----Recertificación
                        f_limite_recert = DateAdd(DateInterval.Year, 1, f_limite) ' Add 1 año a la fecha limite para certificar
                        dif_recert = DateDiff(DateInterval.Day, f_limite_recert, Now.Date)
                        estatus_recert = IIf(dif_recert > 365, 0, -1)

                        For Each y As DataRow In dtCertificados.Select("reloj ='" & clock & "' and cod_puesto ='" & cod_puesto & "' and recerti=1")
                            estatus_recert = 1
                        Next
                        Try : drow("fecha_limite_recert") = FechaSQL(f_limite_recert) : Catch ex As Exception : drow("fecha_limite_recert") = "" : End Try


                        If estatus_recert = -1 Then drow("estatus_recert") = "En tiempo"
                        If estatus_recert = 0 Then drow("estatus_recert") = "Vencido"
                        If estatus_recert = 1 Then drow("estatus_recert") = "Certificado"
                        '---Ends Recertificación

                        dtDatos.Rows.Add(drow)

                    Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
                    End Try
                Next

                For Each x As DataRow In dtDatos.Select("estatus='Certificado' or estatus='Vencido'")
                    If x.Item("estatus") = "Certificado" Then
                        certificados += 1
                    ElseIf x.Item("estatus") = "Vencido" Then
                        vencidos += 1
                    End If
                Next

                total = certificados + vencidos

                For Each i As DataRow In dtDatos.Rows
                    i.Item("vencidos") = vencidos
                    i.Item("por_vencidos") = Math.Round((vencidos / total) * 100, 2)
                    i.Item("certificados") = certificados
                    i.Item("por_certificados") = Math.Round((certificados / total) * 100, 2)
                Next
            Else
                Exit Sub
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    '== MODIFICADA 8OCT2021
    '== Modificado      5oct2021      Ernesto
    Public Sub MatrizCapacitacion(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        'dtDatos = dtInformacion.Copy
        EncabezadoReporte = MesLetra(Date.Now) + " " + Date.Now.Year.ToString
        Dim dtFiltroActivos As New DataTable
        dtFiltroActivos = dtInformacion.Clone
        ' For Each dR As DataRow In dtInformacion.Select("BAJA IS NULL AND COD_CURSO NOT IN('H6004','H6011')") '--06/04/2020: AOS - Solo activos y ciertos cursos nada mas
        For Each dR As DataRow In dtInformacion.Rows  '--TODOS
            dtFiltroActivos.ImportRow(dR)
        Next
        dtDatos = dtFiltroActivos.Copy


        If Not dtDatos.Columns.Contains("FEC_FIN_CURSO") Then dtDatos.Columns.Add("FEC_FIN_CURSO", Type.GetType("System.String"))

        For Each dr As DataRow In dtDatos.Select("FIN is not null")
            Dim _fin As String = ""
            Try : _fin = FechaSQL(Date.Parse(dr("FIN")).ToShortDateString) : Catch ex As Exception : _fin = "" : End Try
            dr("FEC_FIN_CURSO") = _fin.ToString.Trim
        Next


    End Sub

    '== Funcion para crear datatable solo con las columnas que necesita el reporte              13oct2021
    Public Function DataTableColEsencial(ByVal nombresCol As String, ByVal tipoCol As String) As DataTable
        Try
            Dim dtTablaCol As New DataTable
            Dim infoN() As String = Split(nombresCol, ",")
            Dim infoT() As String = Split(tipoCol, ",")
            Dim cont As Integer = infoN.Count

            If infoN.Count = infoT.Count Then
                For i As Integer = 0 To cont - 1
                    Dim colN As New DataColumn
                    colN.ColumnName = infoN(i)
                    dtTablaCol.Columns.Add(colN)

                    Select Case infoT(i)
                        Case "String"
                            dtTablaCol.Columns(infoN(i)).DataType = GetType(String)
                        Case "Int"
                            dtTablaCol.Columns(infoN(i)).DataType = GetType(Integer)
                        Case "Date"
                            dtTablaCol.Columns(infoN(i)).DataType = GetType(Date)
                        Case "Double"
                            dtTablaCol.Columns(infoN(i)).DataType = GetType(Double)
                    End Select
                Next
            End If

            Return dtTablaCol
        Catch ex As Exception

        End Try
    End Function




    '== Modificado      10sep2021      Ernesto
    Public Sub MatrizCapacitacionPorEmpleado(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable) '---Antonio---
        'dtDatos = dtInformacion.Copy
        EncabezadoReporte = MesLetra(Date.Now) + " " + Date.Now.Year.ToString
        Dim dtFiltroActivos As New DataTable : Dim dtData As New DataTable : Dim cont As Integer = 0
        Dim relojes As New ArrayList
        dtFiltroActivos = dtInformacion.Clone

        'For Each dR As DataRow In dtInformacion.Select("BAJA IS NULL") '--06/04/2020: AOS - Solo activos 
        '    dtFiltroActivos.ImportRow(dR)
        'Next

        For Each dR As DataRow In dtInformacion.Rows
            dtFiltroActivos.ImportRow(dR)
        Next

        dtData = dtFiltroActivos.Clone
        dtData.Columns.Add("CALIF")
        Dim calificacion As String = ""
        For Each x As DataRow In dtFiltroActivos.Rows
            Try : calificacion = x.Item("CALIFICACION").ToString.Trim : Catch ex As Exception : calificacion = "" : End Try
            If calificacion <> "" Then
                dtData.NewRow()
                dtData.ImportRow(x)
                dtData.Rows(cont).Item("CALIF") = "CM"
                cont += 1
            End If
            If Not relojes.Contains(x.Item("reloj").ToString) Then
                relojes.Add(x.Item("reloj").ToString)
            End If
        Next

        dtData.Columns.Add("TOTAL_CURSOS")
        dtData.Columns.Add("CURSOS_COMP")
        dtData.Columns.Add("CURSOS_PL")
        dtData.Columns.Add("TC")
        dtData.Columns.Add("CC")
        dtData.Columns.Add("CPL")

        For Each x As String In relojes
            PlaneacionCursosEmpleado(x, relojes, dtData)

            '==Se agrega codigo para ver la cantidad de cursos completados y planeados por reloj            septiembre2021
            Dim clock As String = "" : cont = 0 : Dim filtros() As String = {"reloj='" & x & "'", "reloj='" & x & "' and calif='CM'", "reloj='" & x & "' and calif='PL'"}
            Dim col() As String = {"TOTAL_CURSOS*TC", "CURSOS_COMP*CC", "CURSOS_PL*CPL"}
            Dim total As Integer = 0

            For i As Integer = 0 To 2
                For Each row As DataRow In dtData.Select(filtros(i))
                    cont += 1
                Next
                If i < 1 Then
                    total = cont
                End If
                For Each fila As DataRow In dtData.Select(filtros(0))
                    'j.Item(col(i)) = cont.ToString & "-" & Math.Round((cont * 100) / total, 2).ToString & "%"
                    Dim cadena() As String = Split(col(i), "*")
                    fila.Item(cadena(0)) = cont.ToString
                    fila.Item(cadena(1)) = Math.Round((cont * 100) / total, 2).ToString & "%"
                Next
                cont = 0
            Next
        Next

        dtDatos = dtData.Copy

    End Sub

    '== Determina si hay un curso planeado para el empleado     5oct2021      Ernesto
    Private Sub PlaneacionCursosEmpleado(reloj As String, relojes As ArrayList, ByRef dtData As DataTable,
                                         Optional op As Boolean = False, Optional ByVal dtCursos As DataTable = Nothing)

        '==Determina si se agrega la fila (si no tiene categoria no se agrega)
        Dim agregaPlaneado As Boolean = False

        Dim query As String = "SELECT planeacion_empleados.cod_curso,cursos.nombre,ano,mes,obligatorio, " & _
                                         "CASE WHEN fecha_curso IS NULL THEN 0 ELSE 1 END AS cursado,fecha_curso,usuario,fecha_captura,fecha_maxima " & _
                                         "FROM planeacion_empleados LEFT JOIN cursos ON planeacion_empleados.cod_curso = cursos.cod_curso WHERE RELOJ = '" & reloj & "' " & _
                                         "ORDER BY ano DESC,mes,planeacion_empleados.cod_curso"

        Dim query_b As String = "select top 1 nombres,alta,nombre_puesto,nombre_depto from personal.dbo.personalvw where reloj='" & reloj & "'"
        Dim dtPlaneados As DataTable = sqlExecute(query, "CAPACITACION")
        Dim dtInfo As DataTable = sqlExecute(query_b)

        '== Agregar los cursos planeados
        Dim row As DataRow
        For Each y As DataRow In dtPlaneados.Select("cursado = 0")
            row = dtData.NewRow
            row("reloj") = reloj
            row("alta") = FechaSQL(dtInfo.Rows(0).Item("alta").ToString)
            row("cod_curso") = y.Item("cod_curso")
            row("nombre_curso") = y.Item("nombre").ToString.Trim
            row("inicio") = y.Item("fecha_captura")
            row("fin") = y.Item("fecha_maxima")
            row("calif") = "PL"
            row("comentario") = "Planeado"
            row("nombres") = dtInfo.Rows(0).Item("nombres").ToString.Trim
            row("nombre_puesto") = dtInfo.Rows(0).Item("nombre_puesto").ToString.Trim
            row("nombre_depto") = dtInfo.Rows(0).Item("nombre_depto").ToString.Trim

            If op Then
                Dim codCurso As String = "cod_curso='" & y.Item("cod_curso").ToString.Trim & "'"
                For Each x As DataRow In dtCursos.Select(codCurso)
                    row("categoria") = x.Item("categoria").ToString.Trim
                    row("orden") = x.Item("orden").ToString
                    row("nivel") = x.Item("nivel")
                    agregaPlaneado = True
                Next
            End If

            If op = False Or (op And agregaPlaneado) Then
                dtData.Rows.Add(row)
                agregaPlaneado = False
            End If
        Next

    End Sub


    '== Modificada      junio 2021       Ernesto
    Public Sub MatrizHabilidades(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        EncabezadoReporte = MesLetra(Date.Now) + " " + Date.Now.Year.ToString
        Dim dtFiltroActivos As New DataTable
        Dim lista As New ArrayList
        Dim curso As New ArrayList
        Dim drRegistro As DataRow
        Dim query_cursos As String = ""
        Dim filtro As String = ""
        Dim fecha_actual As String = FechaSQL(Now.Date)

        dtFiltroActivos = dtInformacion.Clone
        Dim dtTemp As DataTable = sqlExecute("select RTRIM(cod_depto) as codigo,RTRIM(NOMBRE) as nombre from PERSONAL.dbo.deptos where len(cod_depto) > 1")
        Dim dtInfoEmp As DataTable = sqlExecute("select rtrim(reloj) as r,rtrim(cod_super) as cs,rtrim(nombre_super) as ns,rtrim(nombres) as n,rtrim(nombre_puesto) as np " & _
                                                                      "from PERSONAL.dbo.personalvw")

        '== Obtener el filtro de los departamentos de los cursos        mayo 2021       ernesto
        For Each x As DataRow In dtInformacion.Rows
            If Not lista.Contains(x.Item("NOMBRE_DEPTO").ToString.Trim) Then
                lista.Add(x.Item("nombre_depto").ToString.Trim)
            End If
        Next
        For Each c As String In lista
            For Each d As DataRow In dtTemp.Rows
                If d.Item("nombre") = c Then
                    filtro = "'" & d.Item("codigo") & "'," & filtro
                End If
            Next
        Next
        filtro = filtro.Substring(0, filtro.Length - 1)
        query_cursos = "select RTRIM(COD_CURSO) as codigo,RTRIM(NOMBRE) as n_curso from CAPACITACION.dbo.cursos where cod_depto in (" & filtro & ") order by cod_depto asc"
        dtTemp = Nothing
        lista.Clear()

        '== Cursos de acuerdo a departamento
        dtTemp = sqlExecute(query_cursos)
        For Each dR As DataRow In dtInformacion.Select("COD_CLASIF='H' AND BAJA IS NULL") '--06/04/2020: AOS - Solo cursos que son habilidad y solo activos 
            dtFiltroActivos.ImportRow(dR)
            If Not lista.Contains(dR.Item("reloj").ToString.Trim & "," & dR.Item("cod_super").ToString.Trim & "," & dR.Item("nombre_super").ToString.Trim) Then
                lista.Add(dR.Item("reloj").ToString.Trim & "," & dR.Item("cod_super").ToString.Trim & "," & dR.Item("nombre_super").ToString.Trim)
            End If
            If (Not curso.Contains(dR.Item("cod_curso").ToString.Trim)) Then
                curso.Add(dR.Item("cod_curso").ToString.Trim)
            End If
        Next
        dtDatos = dtFiltroActivos.Copy
        dtDatos.Columns.Add("FECHA", GetType(System.String))

        '== Agregar cursos que no tomaron
        Dim curso_x As String = "" : Dim curso_y As String = "" : Dim f As Boolean = True

        '== Todos los empleados de ese filtro seleccionado (por departamento)
        For Each li As String In lista
            '== Todos los cursos por departamento
            For Each x As DataRow In dtTemp.Rows
                '== Lista actual de cursos que si se tomaron
                For Each y As DataRow In dtDatos.Rows
                    curso_x = li.Substring(0, 5) & x.Item("codigo")
                    curso_y = y.Item("reloj").ToString.Trim & y.Item("cod_curso").ToString.Trim
                    If (curso_x = curso_y) Then
                        f = False
                    End If
                Next
                Try
                    If (f) Then
                        dtDatos.NewRow()
                        For Each z As DataRow In dtInfoEmp.Select("r = '" & li.Substring(0, 5) & "'")
                            drRegistro = dtDatos.NewRow
                            drRegistro("reloj") = li.Substring(0, 5)
                            drRegistro("cod_curso") = x.Item("codigo")
                            drRegistro("cod_super") = li.Substring(6, 3)
                            drRegistro("nombre_super") = li.Substring(10, (li.Length - 10))
                            drRegistro("nombres") = z.Item("n")
                            drRegistro("nombre_puesto") = z.Item("np")
                            drRegistro("nombre_curso") = x.Item("n_curso")
                            drRegistro("fin") = DBNull.Value
                            drRegistro("calificacion") = DBNull.Value
                            dtDatos.Rows.Add(drRegistro)
                        Next
                    End If
                Catch ex As Exception : End Try
                f = True
            Next
        Next

        '== Eliminar columnas ambiguas
        Dim dtDatosCopy As DataTable = dtDatos.Copy
        dtDatosCopy.Clear()
        For Each ordena As DataRow In dtDatos.Rows
            If curso.Contains(ordena.Item("cod_curso")) And IsDBNull(ordena.Item("calificacion")) Then
                Continue For
            Else
                dtDatosCopy.ImportRow(ordena)
            End If
        Next
        dtDatos.Clear() : dtDatos = dtDatosCopy

        '== Si la calificacion esta entre 0 y 79, no mostrar fecha  4jun2021    Ernesto
        Try
            For Each x As DataRow In dtDatos.Rows
                x.Item("FECHA") = fecha_actual
                Dim calif As String = IIf(IsDBNull(x.Item("calificacion")), "0", x.Item("calificacion"))
                Dim calificacion As Integer = CInt(calif)
                If (calificacion > 0 And calificacion <= 79) Then
                    x.Item("fin") = DBNull.Value
                End If
            Next
        Catch ex As Exception
        End Try

    End Sub

    '== Modificada      junio 2021       Ernesto
    Public Sub GafeteDeCertificacion(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        EncabezadoReporte = MesLetra(Date.Now) + " " + Date.Now.Year.ToString
        Dim _pathFirma As String = PathFirma + "gafete.jpg"
        Dim dtFiltroActivos As New DataTable
        Dim empList As New ArrayList
        Dim reg As DataRow
        Dim existe As Boolean

        '== Agregar las columnas de las calificaciones y nombre de curso
        For i As Integer = 1 To 16
            dtInformacion.Columns.Add("INDIC" & i, GetType(System.Int32))
            dtInformacion.Columns.Add("H" & i, GetType(System.String))
        Next
        dtInformacion.Columns.Add("path_firma", GetType(System.String))
        dtFiltroActivos = dtInformacion.Clone

        Dim cont As Integer = 0
        Dim orden_matriz As Integer = 0
        Dim calificacion As Double = 0.0
        Dim valorColor As Integer = 0
        Dim _reloj As String = "" : Dim _curso As String = ""

        For Each info As DataRow In dtInformacion.Select("COD_CLASIF='H' AND BAJA IS NULL")
            _reloj = info.Item("reloj").ToString.Trim
            _curso = info.Item("cod_curso").ToString.Trim
            existe = False

            '== Cursos del departamento del empleado
            Dim depto_curso As String = IIf(IsDBNull(info.Item("cod_depto")), "", info.Item("cod_depto").ToString.Trim)
            Dim dtCursosDep As DataTable = sqlExecute("select rtrim(cod_curso) as codigo,rtrim(nombre) as n,orden_matriz " & _
                                                      "from CAPACITACION.dbo.cursos where cod_depto ='" & depto_curso & "' order by ORDEN_MATRIZ asc")
            '== Evitar relojes repetidos
            For Each r As String In empList
                If r.Substring(0, 5) = _reloj Then existe = True
            Next

            If Not existe Then
                If dtCursosDep.Rows.Count > 0 Then
                    reg = dtFiltroActivos.NewRow
                    reg("nombres") = info.Item("nombres").ToString.Trim
                    reg("alta") = FechaSQL(info.Item("alta"))
                    reg("reloj") = info.Item("reloj").ToString.Trim
                    reg("nombre_puesto") = info.Item("nombre_puesto").ToString.Trim

                    '== Foto de empleados y firma 4junio2021    Ernesto
                    reg("foto_empl") = info.Item("foto_empl").ToString.Trim
                    reg("path_firma") = _pathFirma

                    '== Nombre de cursos y calificacion (aplica solo para el primer registro de ese empleado)
                    Dim c As Integer = 1
                    For Each n As DataRow In dtCursosDep.Rows
                        reg("H" & c) = n.Item("n")
                        reg("INDIC" & c) = 0
                        If info.Item("cod_curso").ToString.Trim = n.Item("codigo") Then
                            calificacion = info.Item("calificacion")
                            If (calificacion < 80.0) Then valorColor = 3
                            If (calificacion >= 80.0 And calificacion < 90.0) Then valorColor = 2
                            If (calificacion >= 90.0) Then valorColor = 1
                            reg("INDIC" & c) = valorColor
                        End If
                        c += 1
                    Next
                    dtFiltroActivos.Rows.Add(reg)
                    empList.Add(info.Item("reloj").ToString.Trim & "-" & cont)
                    cont += 1
                End If
                Continue For
            End If

            '== Si hay mas de un registro de un empleado
            For Each x As DataRow In dtCursosDep.Select("codigo = '" & _curso & "'")
                For Each lista As String In empList
                    If lista.Substring(0, 5) = _reloj Then
                        Dim fila As Integer = CInt(lista.Substring(6, (lista.Length - 6)))
                        orden_matriz = info.Item("orden_matriz")
                        calificacion = info.Item("calificacion")
                        If (calificacion < 80.0) Then valorColor = 3
                        If (calificacion >= 80.0 And calificacion < 90.0) Then valorColor = 2
                        If (calificacion >= 90.0) Then valorColor = 1
                        dtFiltroActivos.Rows(fila)("INDIC" & orden_matriz) = valorColor
                    End If
                Next
            Next
        Next
        dtDatos = dtFiltroActivos.Copy
    End Sub

    Public Sub LicenciaMontacargas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim ArchivoFoto As String
            Dim Licencia As Integer
            Dim drRegistro As DataRow
            Dim dtLogo As New DataTable
            Dim drLogo As DataRow
            Dim drLocaliza As DataRow
            Dim dtLicencia As New DataTable
            Dim Comp As String

            dtDatos.Columns.Add("RELOJ", GetType(System.String))
            dtDatos.Columns.Add("NOMBRES", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_DEPTO", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_PUESTO", GetType(System.String))
            dtDatos.Columns.Add("COD_COMP", GetType(System.String))
            dtDatos.Columns.Add("VIGENCIA", GetType(System.DateTime))
            dtDatos.Columns.Add("LICENCIA", GetType(System.Int16))
            dtDatos.Columns.Add("FOTO", GetType(System.String))
            dtDatos.Columns.Add("LOGO", GetType(System.Byte()))
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}

            dtLicencia = sqlExecute("SELECT MAX(numero) FROM licencias", "capacitacion")
            If dtLicencia.Rows.Count > 0 Then
                NumControl = dtLicencia.Rows(0).Item(0) + 1
            Else
                NumControl = 1
            End If

            If frmVigencia.ShowDialog = DialogResult.Cancel Then
                Exit Sub
            End If

            Licencia = NumControl
            Comp = ""
            drLogo = Nothing
            For Each dR As DataRow In dtInformacion.Select("baja IS NULL", dtInformacion.DefaultView.Sort)
                drLocaliza = dtDatos.Rows.Find({dR("reloj")})
                If IsNothing(drLocaliza) Then
                    'Números de reloj no repetidos
                    If Comp <> dR("cod_comp") Then
                        dtLogo = sqlExecute("SELECT logo FROM cias WHERE cod_comp = '" & dR("cod_comp") & "'")
                        If dtLogo.Rows.Count > 0 Then
                            drLogo = dtLogo.Rows(0)
                        Else
                            drLogo = dtLogo.NewRow
                        End If
                        Comp = dR("cod_comp")
                    End If

                    ArchivoFoto = PathFoto & Reloj & ".jpg"
                    If Dir(ArchivoFoto) = "" Then
                        ArchivoFoto = PathFoto & "nofoto.png"
                    End If

                    drRegistro = dtDatos.NewRow
                    drRegistro("reloj") = dR("reloj")
                    drRegistro("nombres") = dR("nombres")
                    drRegistro("nombre_depto") = dR("nombre_depto")
                    drRegistro("nombre_puesto") = dR("nombre_puesto")
                    drRegistro("cod_comp") = dR("cod_comp")
                    drRegistro("vigencia") = FechaInicial
                    drRegistro("licencia") = Licencia
                    drRegistro("logo") = drLogo("logo")
                    drRegistro("foto") = ArchivoFoto

                    dtDatos.Rows.Add(drRegistro)
                    dtLicencia = sqlExecute("SELECT numero FROM licencias WHERE reloj = '" & dR("reloj") & "'")
                    If dtLicencia.Rows.Count > 0 Then
                        sqlExecute("UPDATE licencias SET numero = " & Licencia & " WHERE reloj = '" & dR("reloj") & "'", "capacitacion")
                    Else
                        sqlExecute("INSERT INTO licencias (reloj,numero) VALUES ('" & dR("reloj") & "'," & Licencia & ")", "capacitacion")
                    End If
                    Licencia += 1
                End If
            Next
        Catch ex As Exception
            dtDatos = New DataTable
        End Try
    End Sub
    Public Sub MatrizCursos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim dtTemporal As New DataTable
        Dim query As String = "select  * from matrizoperativa where reloj ='xt912'"
        dtDatos = sqlExecute(query, "capacitacion")
        For Each row As DataRow In dtInformacion.Rows
            query = "select * from matrizoperativa where reloj = '" & row.Item("RELOJ") & "' and cod_curso ='" & row.Item("COD_CURSO") & "'"
            dtTemporal = sqlExecute(query, "capacitacion")
            For Each r As DataRow In dtTemporal.Rows
                dtDatos.ImportRow(r)
            Next
        Next
    End Sub
    Public Sub LicenciaPalletJack(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim ArchivoFoto As String
            Dim Licencia As Integer
            Dim drRegistro As DataRow
            Dim dtLogo As New DataTable
            Dim drLogo As DataRow
            Dim drLocaliza As DataRow
            Dim dtLicencia As New DataTable
            Dim Comp As String

            dtDatos.Columns.Add("RELOJ", GetType(System.String))
            dtDatos.Columns.Add("NOMBRES", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_DEPTO", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_PUESTO", GetType(System.String))
            dtDatos.Columns.Add("COD_COMP", GetType(System.String))
            dtDatos.Columns.Add("VIGENCIA", GetType(System.DateTime))
            dtDatos.Columns.Add("LICENCIA", GetType(System.Int16))
            dtDatos.Columns.Add("FOTO", GetType(System.String))
            dtDatos.Columns.Add("LOGO", GetType(System.Byte()))
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}

            dtLicencia = sqlExecute("SELECT MAX(numero) FROM licencias_pallet", "capacitacion")
            If dtLicencia.Rows.Count > 0 Then
                NumControl = dtLicencia.Rows(0).Item(0) + 1
            Else
                NumControl = 1
            End If
            If frmVigencia.ShowDialog = DialogResult.Cancel Then
                Exit Sub
            End If

            Licencia = NumControl
            Comp = ""
            drLogo = Nothing
            For Each dR As DataRow In dtInformacion.Select("baja IS NULL", dtInformacion.DefaultView.Sort)
                drLocaliza = dtDatos.Rows.Find({dR("reloj")})
                If IsNothing(drLocaliza) Then
                    'Números de reloj no repetidos 
                    If Comp <> dR("cod_comp") Then
                        dtLogo = sqlExecute("SELECT logo FROM cias WHERE cod_comp = '" & dR("cod_comp") & "'")
                        If dtLogo.Rows.Count > 0 Then
                            drLogo = dtLogo.Rows(0)
                        Else
                            drLogo = dtLogo.NewRow
                        End If
                        Comp = dR("cod_comp")
                    End If

                    ArchivoFoto = PathFoto & Reloj & ".jpg"
                    If Dir(ArchivoFoto) = "" Then
                        ArchivoFoto = PathFoto & "nofoto.png"
                    End If

                    drRegistro = dtDatos.NewRow
                    drRegistro("reloj") = dR("reloj")
                    drRegistro("nombres") = dR("nombres")
                    drRegistro("nombre_depto") = dR("nombre_depto")
                    drRegistro("nombre_puesto") = dR("nombre_puesto")
                    drRegistro("cod_comp") = dR("cod_comp")
                    drRegistro("vigencia") = FechaInicial
                    drRegistro("licencia") = Licencia
                    drRegistro("logo") = drLogo("logo")
                    drRegistro("foto") = ArchivoFoto

                    dtDatos.Rows.Add(drRegistro)
                    dtLicencia = sqlExecute("SELECT numero FROM licencias_pallet WHERE reloj = '" & dR("reloj") & "'")
                    If dtLicencia.Rows.Count > 0 Then
                        sqlExecute("UPDATE licencias_pallet SET numero = " & Licencia & " WHERE reloj = '" & dR("reloj") & "'", "capacitacion")
                    Else
                        sqlExecute("INSERT INTO licencias_pallet (reloj,numero) VALUES ('" & dR("reloj") & "'," & Licencia & ")", "capacitacion")
                    End If
                    Licencia += 1
                End If

            Next
        Catch ex As Exception
            dtDatos = New DataTable
        End Try
    End Sub
    Public Sub ReporteCursosTomados(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        dtDatos = sqlExecute("select * from cursos_empleadovw where reloj = 'xt912'", "capacitacion")
        For Each r As DataRow In dtInformacion.Select("COD_CURSO is not null")


            dtDatos.ImportRow(r)

        Next

        dtDatosPostFunciones = dtDatos
        dtDatosPost = dtInformacion

    End Sub

    Public Sub ReporteCursosImpartidos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        dtDatos = sqlExecute("select * from cursos_empleadovw where reloj = 'xt912'", "capacitacion")
        For Each r As DataRow In dtInformacion.Select("COD_CURSO is not null")

            dtDatos.ImportRow(r)
        Next

        '    ExcelCursosTomados(dtDatos, dtInformacion) ' nuevos reportes planos
        dtDatosPostFunciones = dtDatos
        dtDatosPost = dtInformacion


    End Sub

    Public Sub GafeteCertificacion(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim ArchivoFoto As String
            Dim drRegistro As DataRow
            Dim dtLogo As New DataTable
            Dim drLogo As DataRow
            Dim dtPersonal As New DataTable
            Dim Comp As String
            Dim drLocaliza As DataRow

            dtDatos.Columns.Add("RELOJ", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_COMPLETO", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_DEPTO", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_PUESTO", GetType(System.String))
            dtDatos.Columns.Add("OPERACION", GetType(System.String))
            dtDatos.Columns.Add("ALTA", GetType(System.DateTime))
            dtDatos.Columns.Add("COD_COMP", GetType(System.String))
            dtDatos.Columns.Add("FOTO", GetType(System.String))
            dtDatos.Columns.Add("LOGO", GetType(System.Byte()))
            dtDatos.Columns.Add("IGUALADO", GetType(System.Byte))
            dtDatos.Columns.Add("MEZCLADO", GetType(System.Byte))
            dtDatos.Columns.Add("LABORATORIO", GetType(System.Byte))
            dtDatos.Columns.Add("LIJADO", GetType(System.Byte))
            dtDatos.Columns.Add("HTOP", GetType(System.Byte))
            dtDatos.Columns.Add("STACKER", GetType(System.Byte))
            dtDatos.Columns.Add("GRABADO", GetType(System.Byte))
            dtDatos.Columns.Add("SORTEO", GetType(System.Byte))
            dtDatos.Columns.Add("QUIMICOS", GetType(System.Byte))
            dtDatos.Columns.Add("MOSTARDINI", GetType(System.Byte))
            dtDatos.Columns.Add("TIPPING", GetType(System.Byte))
            dtDatos.Columns.Add("CABINA", GetType(System.Byte))
            dtDatos.Columns.Add("INSPECCION", GetType(System.Byte))
            dtDatos.Columns.Add("PUENTE", GetType(System.Byte))
            dtDatos.Columns.Add("MOLINOS", GetType(System.Byte))
            dtDatos.Columns.Add("FILLER", GetType(System.Byte))
            dtDatos.Columns.Add("TUNEL", GetType(System.Byte))
            dtDatos.Columns.Add("RODILLOS", GetType(System.Byte))
            dtDatos.Columns.Add("ULTIMA", GetType(System.Byte))
            dtDatos.Columns.Add("NAVAJAS", GetType(System.Byte))
            dtDatos.Columns.Add("VIGENCIA_NAVAJAS", GetType(System.DateTime))
            dtDatos.Columns.Add("ULTIMA_CERTIFICACION", GetType(System.String))
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}

            Comp = ""
            drLogo = Nothing
            For Each dR As DataRow In dtInformacion.Select("baja IS NULL", dtInformacion.DefaultView.Sort)
                drLocaliza = dtDatos.Rows.Find({dR("reloj")})
                If IsNothing(drLocaliza) Then
                    'No duplicar números de reloj
                    If Comp <> dR("cod_comp") Then
                        dtLogo = sqlExecute("SELECT logo FROM cias WHERE cod_comp = '" & dR("cod_comp") & "'")
                        If dtLogo.Rows.Count > 0 Then
                            drLogo = dtLogo.Rows(0)
                        Else
                            drLogo = dtLogo.NewRow
                        End If
                        Comp = dR("cod_comp")
                    End If

                    dtPersonal = sqlExecute("SELECT PersonalVW.RELOJ," & _
                                            "RTRIM(personalVW.NOMBRE)+' '+RTRIM(APATERNO)+' '+RTRIM(AMATERNO) AS NOMBRE_COMPLETO," & _
                                            "contenido  AS OPERACION FROM personal.dbo.personalVW LEFT JOIN detalle_auxiliares " & _
                                            "ON personalvw.reloj = detalle_auxiliares.reloj WHERE PersonalVW.reloj = '" & dR("reloj") & _
                                            "' AND campo = 'OPERACION'")

                    If dtPersonal.Rows.Count > 0 Then
                        ArchivoFoto = PathFoto & Reloj & ".jpg"
                        If Dir(ArchivoFoto) = "" Then
                            ArchivoFoto = PathFoto & "nofoto.png"
                        End If

                        drRegistro = dtDatos.NewRow
                        drRegistro("reloj") = dR("reloj")
                        drRegistro("alta") = dR("alta")
                        drRegistro("nombre_completo") = dtPersonal.Rows(0).Item("nombre_completo")
                        drRegistro("operacion") = dtPersonal.Rows(0).Item("operacion")
                        drRegistro("nombre_depto") = dR("nombre_depto")
                        drRegistro("nombre_puesto") = dR("nombre_puesto")
                        drRegistro("cod_comp") = dR("cod_comp")
                        drRegistro("logo") = drLogo("logo")
                        drRegistro("foto") = ArchivoFoto

                        '*** LLENAR DATOS DE CAPACITACION ***
                        '******  
                        dtDatos.Rows.Add(drRegistro)
                    End If
                End If
            Next
        Catch ex As Exception
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub RegistroEntrenamiento(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim drRegistro As DataRow
            Dim drLocaliza As DataRow

            dtDatos.Columns.Add("RELOJ", GetType(System.String))
            dtDatos.Columns.Add("NOMBRES", GetType(System.String))
            dtDatos.Columns.Add("COD_TURNO", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_PUESTO", GetType(System.String))
            dtDatos.Columns.Add("ALTA", GetType(System.DateTime))
            dtDatos.Columns.Add("MIERCOLES", GetType(System.DateTime))
            dtDatos.Columns.Add("JUEVES", GetType(System.DateTime))
            dtDatos.Columns.Add("VIERNES", GetType(System.DateTime))
            dtDatos.Columns.Add("ESPECIALIZACION", GetType(System.String))
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}

            strRespuesta = ""
            If frmEspecializacion.ShowDialog = DialogResult.Cancel Then
                Exit Sub
            End If

            For Each dR As DataRow In dtInformacion.Select("1=1", dtInformacion.DefaultView.Sort)
                drLocaliza = dtDatos.Rows.Find({dR("reloj")})
                If IsNothing(drLocaliza) Then
                    'No duplicar números de reloj

                    drRegistro = dtDatos.NewRow
                    drRegistro("reloj") = dR("reloj")
                    drRegistro("alta") = dR("alta")
                    drRegistro("nombres") = dR("nombres")
                    drRegistro("cod_turno") = dR("cod_turno")
                    drRegistro("nombre_puesto") = dR("nombre_puesto")
                    drRegistro("alta") = dR("alta")
                    drRegistro("especializacion") = strRespuesta

                    If DatePart(DateInterval.Weekday, dR("alta")) >= 5 Then
                        drRegistro("miercoles") = dR("alta")
                        drRegistro("jueves") = dR("alta")
                        drRegistro("viernes") = dR("alta")
                    Else
                        drRegistro("miercoles") = DateAdd(DateInterval.Day, 4 - DatePart(DateInterval.Weekday, dR("alta")), dR("alta"))
                        drRegistro("jueves") = DateAdd(DateInterval.Day, 5 - DatePart(DateInterval.Weekday, dR("alta")), dR("alta"))
                        drRegistro("viernes") = DateAdd(DateInterval.Day, 6 - DatePart(DateInterval.Weekday, dR("alta")), dR("alta"))
                    End If
                    dtDatos.Rows.Add(drRegistro)
                End If

            Next
        Catch ex As Exception
            dtDatos = New DataTable
            Debug.Print(ex.Message)
        End Try
    End Sub

    Dim hombres As Int32
    Dim mujeres As Int32
    Public Sub FormatoDC4(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            dtDatos = sqlExecute("SELECT COD_COMP, NOMBRE, RFC, REG_PAT, INFONAVIT, LOGO, 'PERIODOS' AS ENCABEZADO, " & _
                                 "'FILTROS' AS FILTROS, GIRO, DIRECCION, COLONIA, CIUDAD, ESTADO, COD_POSTAL, TELEFONO1, " & _
                                 "FAX,0 AS HOMBRES,0 AS MUJERES FROM personal.dbo.cias WHERE cia_default = 1")
            FechaInicial = DateSerial(Year(Now.Date) - 1, 1, 1)
            FechaFinal = DateSerial(Year(Now.Date) - 1, 12, 31)

            Dim respuesta As DialogResult = frmConstanciaDC4.ShowDialog

            dtInformacion = dtInformacion.Select("inicio >=  '" & FechaSQL(FechaInicial) & "' and inicio <='" & FechaSQL(FechaFinal) & "'").CopyToDataTable
            If dtInformacion.Rows.Count > 0 Then
                If respuesta = DialogResult.Cancel Then
                    Exit Sub

                ElseIf respuesta = DialogResult.OK Then
                    ExcelDC4(dtDatos, dtInformacion)
                End If

                For Each dr As DataRow In dtDatos.Rows
                    dr("Hombres") = hombres
                    dr("Mujeres") = mujeres
                Next
            End If
            'SELECT PERSONALVW.RELOJ,NOMBRES,APATERNO,AMATERNO,PersonalVW.NOMBRE,SEXO,CURP,IMSS,0 AS DISCAPACIDAD,IIF(COD_CIVIL='C',1,IIF(COD_CIVIL='S',2,3) AS COD_CIVIL,
            '(select SUM(1) from familiares where cod_familia in (select cod_familia from familia where nombre like 'HIJ%' AND (FECHA_NAC  IS NULL OR DATEDIFF(yy,FECHA_NAC,GETDATE())<18) and reloj = PersonalVW.reloj)) AS hijos,'04.6 Procesos Industriales' as OCUPACION from personalvw

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub
    Public Sub BRPFormatoDC3(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos = sqlExecute("select cursos_empleadovw.* from cursos_empleadovw where reloj = 'xt912'", "capacitacion")
        Dim dtrep_empresa As DataTable = sqlExecute("select representantes.nombre from capacitacion.dbo.representantes where cod_representantes = '" & repEmpresa & "'", "capacitacion")
        Dim dtrep_empleados As DataTable = sqlExecute("select representantes.nombre from capacitacion.dbo.representantes where cod_representantes = '" & repEmpleados & "' ", "capacitacion")
        Dim nombre_rep_empresa As String
        Dim nombre_rep_empleados As String
        nombre_rep_empresa = IIf(IsDBNull(dtrep_empresa.Rows(0).Item("nombre")), "", RTrim(dtrep_empresa.Rows(0).Item("nombre")))
        nombre_rep_empleados = IIf(IsDBNull(dtrep_empleados.Rows(0).Item("nombre")), "", RTrim(dtrep_empleados.Rows(0).Item("nombre")))
        Dim firma_nombre_emp As New Data.DataColumn("firma_nombre_emp", GetType(System.String))
        Dim firma_nombre_emple As New Data.DataColumn("firma_nombre_emple", GetType(System.String))
        Dim rep_empresa As New Data.DataColumn("rep_empresa", GetType(System.String))
        Dim rep_empleados As New Data.DataColumn("rep_empleados", GetType(System.String))
        Dim clpathfirma As New Data.DataColumn("path_firma_capacitacion", GetType(System.String))

        dtDatos.Columns.Add(clpathfirma)
        dtDatos.Columns.Add(rep_empresa)
        dtDatos.Columns.Add(rep_empleados)
        dtDatos.Columns.Add(firma_nombre_emp)
        dtDatos.Columns.Add(firma_nombre_emple)

        rep_empleados.DefaultValue = repEmpleados
        rep_empresa.DefaultValue = repEmpresa
        clpathfirma.DefaultValue = PathFirma
        firma_nombre_emp.DefaultValue = nombre_rep_empresa
        firma_nombre_emple.DefaultValue = nombre_rep_empleados

        For Each r As DataRow In dtInformacion.Select("cod_curso is not null")
            Dim dtTemp As DataTable = sqlExecute("select * from cursos_empleadovw where reloj = '" + r.Item("reloj") + "'", "capacitacion")
            For Each row As DataRow In dtTemp.Rows
                dtDatos.ImportRow(r)
            Next
        Next

        For Each row As DataRow In dtDatos.Rows
            row("rep_empresa") = PathFirma & repEmpresa & ".jpg"
            row("rep_empleados") = PathFirma & repEmpleados & ".jpg"
            If System.IO.File.Exists(PathFirma & row("cod_instructor") & ".jpg") Then
                row("path_firma_capacitacion") = PathFirma & row("cod_instructor") & ".jpg"
            Else
                row("path_firma_capacitacion") = ""
            End If

        Next
    End Sub

    Public Sub FormatoDC3(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos = sqlExecute("select capacitacion.dbo.cursos_empleadovw.*, personal.dbo.parametros.path_firma_capacitacion from capacitacion.dbo.cursos_empleadovw, personal.dbo.parametros where reloj = 'xt912'", "capacitacion")
        Dim dtrep_empresa As DataTable = sqlExecute("select representantes.nombre from capacitacion.dbo.representantes where cod_representantes = '" & repEmpresa & "'", "capacitacion")
        Dim dtrep_empleados As DataTable = sqlExecute("select representantes.nombre from capacitacion.dbo.representantes where cod_representantes = '" & repEmpleados & "' ", "capacitacion")
        Dim nombre_rep_empresa As String
        Dim nombre_rep_empleados As String
        nombre_rep_empresa = IIf(IsDBNull(dtrep_empresa.Rows(0).Item("nombre")), "", RTrim(dtrep_empresa.Rows(0).Item("nombre")))
        nombre_rep_empleados = IIf(IsDBNull(dtrep_empleados.Rows(0).Item("nombre")), "", RTrim(dtrep_empleados.Rows(0).Item("nombre")))
        Dim firma_nombre_emp As New Data.DataColumn("firma_nombre_emp", GetType(System.String))
        Dim firma_nombre_emple As New Data.DataColumn("firma_nombre_emple", GetType(System.String))
        Dim rep_empresa As New Data.DataColumn("rep_empresa", GetType(System.String))
        Dim rep_empleados As New Data.DataColumn("rep_empleados", GetType(System.String))
        rep_empleados.DefaultValue = repEmpleados
        rep_empresa.DefaultValue = repEmpresa
        firma_nombre_emp.DefaultValue = nombre_rep_empresa
        firma_nombre_emple.DefaultValue = nombre_rep_empleados
        dtDatos.Columns.Add(firma_nombre_emp)
        dtDatos.Columns.Add(firma_nombre_emple)
        dtDatos.Columns.Add(rep_empresa)
        dtDatos.Columns.Add(rep_empleados)

        For Each r As DataRow In dtInformacion.Select("cod_curso is not null")
            'Dim dtTemp As DataTable = sqlExecute("select capacitacion.dbo.cursos_empleadovw.*, personal.dbo.parametros.path_firma_capacitacion from cursos_empleadovw, personal.dbo.parametros where reloj = '" + r.Item("reloj") + "' AND stps=1 and len(curp)>0", "capacitacion")
            'For Each row As DataRow In dtTemp.Rows
            dtDatos.ImportRow(r)
            'Next
        Next

        For Each row As DataRow In dtDatos.Rows
            row("rep_empresa") = PathFirma & repEmpresa & ".jpg"
            row("rep_empleados") = PathFirma & repEmpleados & ".jpg"
            If System.IO.File.Exists(PathFirma & row("cod_instructor") & ".jpg") Then
                row("path_firma_capacitacion") = PathFirma & row("cod_instructor") & ".jpg"
            Else
                row("path_firma_capacitacion") = ""
            End If

        Next

        'Try

        '    dtDatos = sqlExecute("SELECT COD_COMP, NOMBRE, RFC, REG_PAT, INFONAVIT, LOGO, 'PERIODOS' AS ENCABEZADO, " & _
        '                         "'FILTROS' AS FILTROS, GIRO, DIRECCION, COLONIA, CIUDAD, ESTADO, COD_POSTAL, TELEFONO1, " & _
        '                         "FAX,0 AS HOMBRES,0 AS MUJERES FROM personal.dbo.cias WHERE cia_default = 1")
        '    FechaInicial = DateSerial(Year(Now.Date) - 1, 1, 1)
        '    FechaFinal = DateSerial(Year(Now.Date) - 1, 12, 31)
        '    If frmConstanciaDC4.ShowDialog = DialogResult.Cancel Then
        '        Exit Sub
        '    End If

        '    'SELECT PERSONALVW.RELOJ,NOMBRES,APATERNO,AMATERNO,PersonalVW.NOMBRE,SEXO,CURP,IMSS,0 AS DISCAPACIDAD,IIF(COD_CIVIL='C',1,IIF(COD_CIVIL='S',2,3) AS COD_CIVIL,
        '    '(select SUM(1) from familiares where cod_familia in (select cod_familia from familia where nombre like 'HIJ%' AND (FECHA_NAC  IS NULL OR DATEDIFF(yy,FECHA_NAC,GETDATE())<18) and reloj = PersonalVW.reloj)) AS hijos,'04.6 Procesos Industriales' as OCUPACION from personalvw

        'Catch ex As Exception
        '    dtDatos = New DataTable
        'End Try
    End Sub


    '--------------------------------CHUY--------------------------inventos---------DC4



    Public Sub ExcelDC4(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim sfd As New SaveFileDialog
        Try
            sfd.DefaultExt = ".xlsx"
            sfd.FileName = "Excel informacion DC4.xlsx"

            sfd.OverwritePrompt = True
            If sfd.ShowDialog() = DialogResult.OK Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                '

                frmTrabajando.Show()

                Excelinformaciondc4("Informacion DC4", "", wb, dtInformacion)
                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))

                ActivoTrabajando = False
                frmTrabajando.Close()

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub Excelinformaciondc4(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, dtDatos As DataTable)

        Dim x As Integer = 1
        Dim y As Integer = 1
        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

        '  Dim dtTipoAus As DataTable = sqlExecute("select tipo_aus, rtrim(nombre) as nombre, color_letra, color_back from tipo_ausentismo", "TA")
        ' dtTipoAus.PrimaryKey = ({dtTipoAus.Columns("tipo_aus")})

        'Dim dtDC4 As DataTable = sqlExecute("select PERSONAL.dbo.PersonalVW.curp," & _
        '                                    "PERSONAL.dbo.PersonalVW.nombre," & _
        '                                    "PERSONAL.dbo.PersonalVW.reloj," & _
        '                                    "PERSONAL.dbo.PersonalVW.Apaterno," & _
        '                                    "PERSONAL.dbo.PersonalVW.Amaterno," & _
        '                                    "Capacitacion.dbo.Cursos_empleadoVW.COD_INSTITUTO," & _
        '                                    "Capacitacion.dbo.Cursos_empleadoVW.COD_CURSO," & _
        '                                    "Capacitacion.dbo.Cursos_empleadoVW.NOMBRE_CURSO," & _
        '                                    "Capacitacion.dbo.Cursos_empleadoVW.COD_AREA," & _
        '                                    "Capacitacion.dbo.Cursos_empleadoVW.DURACION," & _
        '                                    "Capacitacion.dbo.Cursos_empleadoVW.INICIO," & _
        '                                    "CAPACITACION.dbo.Cursos_empleadoVW.FIN," & _
        '                                    "CAPACITACION.dbo.Cursos_empleadoVW.STPS " & _
        '                                    "from PERSONAL.dbo.PersonalVW " & _
        '                                    "LEFT JOIN CAPACITACION.dbo.Cursos_empleadoVW on PERSONAL.dbo.PersonalVW.reloj = CAPACITACION.dbo.Cursos_empleadoVW.RELOJ " & _
        '                                    "where CAPACITACION.dbo.Cursos_empleadoVW.reloj ='" & row("reloj") & "'")


        hoja_excel.Cells(x, y).Value = "CURP"
        hoja_excel.Cells(x, y).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 1).Value = "NOMBRE"
        hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 2).Value = "PRIMER APELLIDO"
        hoja_excel.Cells(x, y + 2).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 3).Value = "SEGUNDO APELLIDO"
        hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 4).Value = "CLAVE ESTADO"
        hoja_excel.Cells(x, y + 4).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 5).Value = "CLAVE MUNICIPIO"
        hoja_excel.Cells(x, y + 5).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 6).Value = "CLAVE OCUPACION"
        hoja_excel.Cells(x, y + 6).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 7).Value = "CLAVE NIV ESTUDIOS"
        hoja_excel.Cells(x, y + 7).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 8).Value = "CLAVE DOC PROBATORIO"
        hoja_excel.Cells(x, y + 8).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 9).Value = "CLAVE INSTITUCION" '
        hoja_excel.Cells(x, y + 9).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 10).Value = "CLAVE CURSO"
        hoja_excel.Cells(x, y + 10).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 11).Value = "NOMBRE CURSO"
        hoja_excel.Cells(x, y + 11).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 12).Value = "CLAVE AREA TEMATICA"
        hoja_excel.Cells(x, y + 12).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 13).Value = "DURACION"
        hoja_excel.Cells(x, y + 13).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 14).Value = "FEC INICIO"
        hoja_excel.Cells(x, y + 14).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 15).Value = "FEC TERMINO"
        hoja_excel.Cells(x, y + 15).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 16).Value = "CLAVE TIP AGENTE"
        hoja_excel.Cells(x, y + 16).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 17).Value = "RFC AGENTE STPS"
        hoja_excel.Cells(x, y + 17).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 18).Value = "CLAVE MODALIDAD"
        hoja_excel.Cells(x, y + 18).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 19).Value = "CLAVE CAPACITACION"
        hoja_excel.Cells(x, y + 19).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 20).Value = "CLAVE ESTABLECIMIENTO"
        hoja_excel.Cells(x, y + 20).Style.Font.Bold = True


        For Each row As DataRow In dtDatos.Select(filtro, "reloj")
            frmTrabajando.lblAvance.Text = row("reloj")
            Application.DoEvents()

            Dim STPS As Boolean = IIf(IsDBNull(row("STPS")), False, row("STPS"))
            If STPS Then

                Dim sexo As String = "M"
                Try
                    sexo = RTrim(row("SEXO"))
                Catch ex As Exception

                End Try

                If sexo = "M" Then
                    hombres = hombres + 1
                Else
                    mujeres = mujeres + 1

                End If

                Dim dtDC4 As DataTable = sqlExecute("select nombre, apaterno, amaterno, max_escolaridad, COD_TIPO, COD_PUESTO, SEXO from personalvw " & _
                                                    "where reloj ='" & row("reloj") & "'")
                For Each dcrow As DataRow In dtDC4.Rows

                    Dim a As String
                    Dim b As String


                    Dim duracion As Double = 1
                    Try
                        duracion = Double.Parse(row("DURACION"))
                    Catch ex As Exception

                    End Try

                    Dim red As Integer = Math.Ceiling(duracion)
                    If red = 0 Then
                        red = 1
                    End If

                    Dim ocupacion As String


                    Select Case dcrow("max_escolaridad").ToString

                        Case "01"
                            a = "2"
                            b = "2"
                        Case "02"
                            a = "3"
                            b = "2"
                        Case "03"
                            a = "4"
                            b = "2"
                        Case "04"
                            a = "5"
                            b = "2"
                        Case "05"
                            a = "6" ' modificado a 6
                            b = "1"
                        Case "06" ' especialidad
                            a = "6"
                            b = "1"
                        Case "07"
                            a = "8"
                            b = "1"
                        Case Else
                            a = "1" 'Primaria por default
                            b = "1"

                    End Select


                    'Dim prueba = dcrow("COD_TIPO")
                    Select Case Trim(dcrow("COD_TIPO").ToString)
                        Case "O"
                            Select Case dcrow("COD_PUESTO").ToString
                                Case "152"
                                    ocupacion = "2807"
                                Case Else
                                    ocupacion = "2544"
                            End Select

                        Case Else
                            ocupacion = "2051"
                    End Select


                    ' Dim fechanac As Date = CDate(hrow("fecha_nac"))

                    Dim finicio As Date = Date.Parse(row("INICIO"))
                    Dim ffinal As Date = finicio
                    Try
                        ffinal = Date.Parse(row("FIN"))
                    Catch ex As Exception

                    End Try

                    Dim fechaact As String = finicio.ToString("dd/MM/yyyy")
                    Dim fechafin As String = ffinal.ToString("dd/MM/yyyy")

                    x += 1

                    hoja_excel.Cells(x, y).Value = row("curp")
                    hoja_excel.Cells(x, y + 1).Value = dcrow("Nombre")
                    hoja_excel.Cells(x, y + 2).Value = dcrow("Apaterno")
                    hoja_excel.Cells(x, y + 3).Value = dcrow("Amaterno")
                    hoja_excel.Cells(x, y + 4).Value = "22"
                    hoja_excel.Cells(x, y + 5).Value = "14"
                    hoja_excel.Cells(x, y + 6).Value = ocupacion ' clave ocupacion Pendiente
                    hoja_excel.Cells(x, y + 7).Value = a
                    hoja_excel.Cells(x, y + 8).Value = b
                    hoja_excel.Cells(x, y + 9).Value = "1"
                    hoja_excel.Cells(x, y + 10).Value = "" 'clave curso por checar
                    hoja_excel.Cells(x, y + 11).Value = row("NOMBRE_CURSO")
                    hoja_excel.Cells(x, y + 12).Value = row("COD_AREA")
                    hoja_excel.Cells(x, y + 13).Value = red                                'row("DURACION")
                    hoja_excel.Cells(x, y + 14).Value = fechaact                            'Date.Parse(row("INICIO")).ToShortDateString
                    hoja_excel.Cells(x, y + 15).Value = fechafin                            ' Date.Parse(dtNombres.Rows(0)("alta")).ToShortDateString
                    hoja_excel.Cells(x, y + 16).Value = "1"
                    hoja_excel.Cells(x, y + 17).Value = ""
                    hoja_excel.Cells(x, y + 18).Value = row("MODALIDAD")
                    hoja_excel.Cells(x, y + 19).Value = row("OBJETIVO")
                    hoja_excel.Cells(x, y + 20).Value = cod_capacitacion


                    'hoja_excel.Cells(x, y + 9).Value = dcrow("COD_INSTITUTO")
                    'hoja_excel.Cells(x, y + 8).Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern
                    'hoja_excel.Cells(x, y + 8).Value = Date.Parse(row("fecha_entro"))

                    '  hoja_excel.Cells(x, y + 9).Value = row("COD_INSTITUTO")
                    'hoja_excel.Cells(x, y + 10).Value = row("nombre_aus")
                    'hoja_excel.Cells(x, y + 9).Style.Font.Bold = True
                    'hoja_excel.Cells(x, y + 9).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    'hoja_excel.Cells(x, y + 9).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(dtTipoAus.Rows.Find({tipo_aus})("color_back")))
                    'hoja_excel.Cells(x, y + 9).Style.Font.Color.SetColor(Color.FromArgb(dtTipoAus.Rows.Find({tipo_aus})("color_letra")))
                    'End If
                Next
            End If
        Next
        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

    End Sub

    Public Sub SolicitudCapacitacion(ByRef dtDatos As DataTable)
        Try
            If Not (frmSeleccionarMes.ShowDialog = DialogResult.OK) Then
                Exit Sub
            End If
            Dim dtCursosPlaneados As DataTable = sqlExecute("select p.cod_curso, vw.NOMBRE_CURSO, vw.NOMBRE_OBJETIVO, vw.NOMBRE_MODALIDAD, vw.NOMBRE_CLASIFICACION, vw.NOMBRE_AREA_TEMATICA, vw.DURACION as total_horas, e.fecha_captura as fecha_inicio, e.fecha_maxima as fecha_fin, e.reloj, evw.nombres, evw.COD_PUESTO, evw.nombre_puesto, evw.COD_DEPTO, evw.nombre_depto " &
                                                            "from planeacion_cursos as p inner join cursosvw as vw on p.cod_curso = vw.cod_curso inner join planeacion_empleados as e on p.cod_curso = e.cod_curso inner join personal.dbo.personalvw as evw on e.reloj = evw.reloj " &
                                                            "where p.ano='" & AnoSelec & "' and p.mes='" & MesSelec & "'", "capacitacion")
            dtDatos = dtCursosPlaneados.Clone
            For Each row As DataRow In dtCursosPlaneados.Rows
                dtDatos.Rows.Add({row("cod_curso"), row("NOMBRE_CURSO").Trim, row("NOMBRE_OBJETIVO").Trim, row("NOMBRE_MODALIDAD").Trim,
                                  row("NOMBRE_CLASIFICACION").Trim, row("NOMBRE_AREA_TEMATICA").Trim, row("total_horas").ToString,
                                  row("fecha_inicio").ToString, row("fecha_inicio").ToString, row("reloj").Trim, row("nombres").Trim,
                                  row("COD_PUESTO").Trim, row("nombre_puesto").Trim, row("COD_DEPTO").Trim, row("nombre_depto").Trim})
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub MatrizHueTest(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            '---Mostrar Progress
            Dim i As Integer = -1
            frmTrabajando.Text = "Generando Matriz Hue Test"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Matriz Hue Test"
            ActivoTrabajando = True
            frmTrabajando.Show()
            Application.DoEvents()


            Dim Query As String = ""

            Query = "select * from CAPACITACION.dbo.planeacion_empleados where cod_curso='H0069' and fecha_maxima>=getdate()"
            Dim dtPlaneacionCursos As DataTable = sqlExecute(Query)

            'Query = "select * from PERSONAL.dbo.personalvw where reloj in (select distinct reloj from CAPACITACION.dbo.Cursos_empleadoVW where COD_CLASIF='H' and NOMBRE_CURSO like '%hue%') " & _
            '    "or reloj in (select reloj from CAPACITACION.dbo.planeacion_empleados where cod_curso='H0069' and fecha_maxima>=getdate()) " & _
            '    "order by reloj asc"

            Query = "select * from PERSONAL.dbo.personalvw where reloj in (select distinct reloj from CAPACITACION.dbo.Cursos_empleadoVW where COD_CLASIF='H' and NOMBRE_CURSO like '%hue%') " & _
                   "order by reloj asc"

            Dim dtInfoPersonal As DataTable = sqlExecute(Query)

            If Not dtInfoPersonal.Columns.Contains("Error") And dtInfoPersonal.Rows.Count > 0 Then

                '--Mostrar progress
                frmTrabajando.Avance.IsRunning = False
                frmTrabajando.lblAvance.Text = "Procesando datos"
                Application.DoEvents()
                frmTrabajando.Avance.Maximum = dtInfoPersonal.Rows.Count

                'Add columnas If Not dtVencidas.Columns.Contains("cancelar") Then dtVencidas.Columns.Add("cancelar", Type.GetType("System.Boolean"))
                If Not dtDatos.Columns.Contains("RELOJ") Then dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("NOMBRE") Then dtDatos.Columns.Add("NOMBRE", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("PUESTO") Then dtDatos.Columns.Add("PUESTO", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ULT_EVAL") Then dtDatos.Columns.Add("ULT_EVAL", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("SUPERIOR") Then dtDatos.Columns.Add("SUPERIOR", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("MEDIANA") Then dtDatos.Columns.Add("MEDIANA", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("BAJA") Then dtDatos.Columns.Add("BAJA", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("PEND_EVAL") Then dtDatos.Columns.Add("PEND_EVAL", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("INDICADOR") Then dtDatos.Columns.Add("INDICADOR", Type.GetType("System.Int32"))

                For Each dr As DataRow In dtInfoPersonal.Rows
                    Dim reloj As String = "", nombre As String = "", puesto As String = "", superior As String = "", mediana As String = "", baja As String = "", pend_eval As String = ""
                    Dim ULT_EVAL As String = "", calificacion As Double = 0.0
                    Try : reloj = dr("RELOJ").ToString.Trim : Catch ex As Exception : reloj = "" : End Try

                    '----Mostrar Progress - avance
                    i += 1
                    frmTrabajando.Avance.Value = i
                    frmTrabajando.lblAvance.Text = reloj
                    Application.DoEvents()

                    Try : nombre = dr("NOMBRES").ToString.Trim : Catch ex As Exception : nombre = "" : End Try
                    Try : puesto = dr("NOMBRE_PUESTO").ToString.Trim : Catch ex As Exception : puesto = "" : End Try

                    '-- select top 1 * from Cursos_empleadoVW where reloj='00008' and COD_CLASIF='H' and NOMBRE_CURSO like '%hue%' order by reloj asc,fin desc

                    '------Buscar si tiene capturado la habilidad
                    Query = "select top 1 * from CAPACITACION.dbo.Cursos_empleadoVW where reloj='" & reloj & "' and COD_CLASIF='H' and NOMBRE_CURSO like '%hue%' order by reloj asc,fin desc"
                    Dim dtCurso As DataTable = sqlExecute(Query)
                    If Not dtCurso.Columns.Contains("Error") And dtCurso.Rows.Count > 0 Then

                        Try : calificacion = Double.Parse(dtCurso.Rows(0).Item("CALIFICACION").ToString.Trim) : Catch ex As Exception : calificacion = 0.0 : End Try
                        Try : ULT_EVAL = FechaSQL(dtCurso.Rows(0).Item("FIN").ToString.Trim) : Catch ex As Exception : ULT_EVAL = "" : End Try

                        If calificacion <= 30 Then baja = "Amarilla"

                        If calificacion > 30 And calificacion <= 60 Then mediana = "Naranja"

                        If calificacion > 60 Then superior = "Verde"

                        pend_eval = ""

                        Dim drow As DataRow = dtDatos.NewRow
                        dtDatos.Rows.Add({reloj, nombre, puesto, ULT_EVAL, superior, mediana, baja, pend_eval, calificacion})

                    End If

                    '-----Ver si tiene capturado el mismo curso planeado a futuro
                    'If dtPlaneacionCursos.Select("reloj='" & reloj & "'").Count > 0 Then
                    '    superior = ""
                    '    mediana = ""
                    '    baja = ""
                    '    pend_eval = "Rojo"

                    '    Dim drow As DataRow = dtDatos.NewRow
                    '    dtDatos.Rows.Add({reloj, nombre, puesto, ULT_EVAL, superior, mediana, baja, pend_eval})
                    'End If

                Next


                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
            Else
                MessageBox.Show("No hay empleados a mostrar", "AVISO PIDA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                Exit Sub
            End If

        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

End Module
