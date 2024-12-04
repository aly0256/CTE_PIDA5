Option Compare Text

Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Globalization
Imports Excel = Microsoft.Office.Interop.Excel


'== 27oct2021
Imports System.Text.RegularExpressions

Module TA
    Dim dtTemp As New DataTable
    Public StopRFHA As Boolean = True

    Public Sub ResumenCafeteria(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim dtResumenCafeteria As New DataTable

        Try

            Dim LocalFechaIni As String = FechaSQL(CafFechaIni)
            Dim LocalFechaFin As String = FechaSQL(CafFechaFin)

            dtDatos.Columns.Add("cod_comp", GetType(System.String))
            dtDatos.Columns.Add("reloj", GetType(System.String))
            dtDatos.Columns.Add("nombres", GetType(System.String))
            dtDatos.Columns.Add("fecha", GetType(System.String))
            dtDatos.Columns.Add("hora", GetType(System.String))
            dtDatos.Columns.Add("aplica", GetType(System.String))
            dtDatos.Columns.Add("periodo_fechas", GetType(System.String))
            dtDatos.Columns.Add("cod_hora", GetType(System.String))
            'dtDatos.Columns.Add("servicio", GetType(System.String))
            'dtDatos.Columns.Add("subsidio", GetType(System.String))
            '
            'dtDatos.Columns.Add("dispositivo", GetType(System.String))

            'Dim strSQl As String = "select personalvw.cod_comp, hrs_brt_cafeteria.reloj,personalvw.nombres,hrs_brt_cafeteria.fecha,hrs_brt_cafeteria.hora,ltrim(horarios_cafeteria.nombre) as servicio,subsidio_cafeteria.nombre_subsidio as subsidio,rtrim(ltrim(hrs_brt_cafeteria.dispositivo)) as dispositivo" & vbCr & _
            '    " from hrs_brt_cafeteria left join horarios_cafeteria" & vbCr & _
            '    " on hrs_brt_cafeteria.horario = horarios_cafeteria.cod_hora_cafe left join subsidio_cafeteria" & vbCr & _
            '    " on hrs_brt_cafeteria.subsidio = subsidio_cafeteria.cod_subsidio left join PERSONAL.dbo.personalvw" & vbCr & _
            '    " on hrs_brt_cafeteria.reloj = personalvw.reloj" & vbCr & _
            '    " where fecha >= '" & LocalFechaIni & "' and fecha <= '" & LocalFechaFin & "'" & vbCr & _
            '    " order by reloj asc,fecha asc, hora asc"

            Dim strSQl As String = "select ch.*,p.nombres from checadas_qr_caf ch left outer join PERSONAL.dbo.personalvw p on ch.id=p.RELOJ " & _
                "where ch.FECHA between '" & LocalFechaIni & "' and '" & LocalFechaFin & "'  order by ch.id asc,ch.fecha asc, ch.hora asc"

            dtResumenCafeteria = sqlExecute(strSQl, "TA")

            If dtResumenCafeteria.Rows.Count > 0 Then

                For Each row As DataRow In dtResumenCafeteria.Rows

                    Dim drRegistro As DataRow = dtDatos.NewRow
                    Dim aplica As String = ""

                    drRegistro("cod_comp") = Trim(IIf(IsDBNull(row("cod_comp")), "", row("cod_comp")))
                    drRegistro("reloj") = Trim(IIf(IsDBNull(row("id")), "", row("id")))
                    drRegistro("nombres") = Trim(IIf(IsDBNull(row("nombres")), "", row("nombres")))
                    drRegistro("fecha") = Trim(IIf(IsDBNull(row("fecha")), "", row("fecha")))
                    drRegistro("hora") = Trim(IIf(IsDBNull(row("hora")), "", row("hora")))
                    drRegistro("periodo_fechas") = "Del " & LocalFechaIni & " al " & LocalFechaFin
                    drRegistro("cod_hora") = Trim(IIf(IsDBNull(row("cod_hora")), "", row("cod_hora")))
                    aplica = Trim(IIf(IsDBNull(row("cuenta")), "", row("cuenta")))
                    If (aplica = "1") Then drRegistro("aplica") = "Si" Else drRegistro("aplica") = "No"


                    'drRegistro("servicio") = Trim(IIf(IsDBNull(row("servicio")), "", row("servicio")))
                    'drRegistro("subsidio") = Trim(IIf(IsDBNull(row("subsidio")), "", row("subsidio")))
                    'drRegistro("dispositivo") = Trim(IIf(IsDBNull(row("dispositivo")), "", row("dispositivo")))


                    dtDatos.Rows.Add(drRegistro)

                Next

            Else
                MessageBox.Show("No se encontró información en el rango de fechas establecido, favor de verificar.", "Información no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un error al intentar generar el reporte. Si el problema persiste contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Public Sub TiempoExtraDobleyTriple(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("turno")
            dtDatos.Columns.Add("COD_depto")
            dtDatos.Columns.Add("cod_cc")
            dtDatos.Columns.Add("NOMBRE_CC")
            dtDatos.Columns.Add("periodo")
            dtDatos.Columns.Add("supervisor")
            dtDatos.Columns.Add("planta")
            dtDatos.Columns.Add("clase")

            dtDatos.Columns.Add("horasNormalesL")
            dtDatos.Columns.Add("horasExtrasL")
            dtDatos.Columns.Add("horasNormalesM")
            dtDatos.Columns.Add("horasExtrasM")
            dtDatos.Columns.Add("horasNormalesW")
            dtDatos.Columns.Add("horasExtrasW")
            dtDatos.Columns.Add("horasNormalesJ")
            dtDatos.Columns.Add("horasExtrasJ")
            dtDatos.Columns.Add("horasNormalesV")
            dtDatos.Columns.Add("horasExtrasV")
            dtDatos.Columns.Add("horasNormalesS")
            dtDatos.Columns.Add("horasExtrasS")
            dtDatos.Columns.Add("horasNormalesD")
            dtDatos.Columns.Add("horasExtrasD")

            dtDatos.Columns.Add("horasNormales")
            dtDatos.Columns.Add("horasExtras")
            dtDatos.Columns.Add("horasDobles")
            dtDatos.Columns.Add("horasTriples")

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("RELOJ"), dtDatos.Columns("periodo")}

            Dim drDatos As DataRow
            Dim Dia As Date
            Dim R As String
            Dim P As String

            'Dim view As DataView = New DataView(dtInformacion)
            'view.Sort = "CENTRO_COSTOS, RELOJ, PERIODO"
            'Dim dtFinal As DataTable = view.Table

            For Each dRow As DataRow In dtInformacion.Select("HORAS_NORMALES <> '00:00' OR HORAS_EXTRAS <> '00:00' AND COD_COMP IN ('090','091','093')", "CENTRO_COSTOS, RELOJ, PERIODO")

                R = IIf(IsDBNull(dRow("RELOJ")), "SIN REF.", dRow("RELOJ"))
                P = dRow("periodo")
                drDatos = dtDatos.Rows.Find({R, P})

                Dia = dRow("fecha_entro").ToString()
                Dim DiaSemanal As Integer = Date.Parse(dRow("fecha_entro")).DayOfWeek

                If IsNothing(drDatos) Then
                    dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), dRow("cod_turno"), dRow("cod_depto"), dRow("CENTRO_COSTOS"), dRow("NOMBRE_CC"), dRow("periodo"), dRow("NOMBRE_SUPER"),
                                      dRow("COD_PLANTA"), dRow("NOMBRE_CLASE"), 0, 0, 0, 0, 0, 0, 0, 0,
                                      0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
                    drDatos = dtDatos.Rows.Find({R, P})
                    Dim hrsD As Double = 0
                    Dim hrsT As Double = 0
                    Dim hrsN As Double = 0
                    If (Not IsDBNull(dRow("hrs_dobles"))) Then
                        hrsD = Math.Round(dRow("hrs_dobles"), 2)
                    End If
                    If (Not IsDBNull(dRow("hrs_triples"))) Then
                        hrsT = Math.Round(dRow("hrs_triples"), 2)
                    End If
                    If (Not IsDBNull(dRow("hrs_normales"))) Then
                        hrsN = Math.Round(dRow("HRS_NORMALES"), 2)
                    End If
                    drDatos("horasDobles") = hrsD
                    drDatos("horasTriples") = hrsT
                    drDatos("horasExtras") = hrsD + hrsT
                    drDatos("horasNormales") = hrsN

                End If

                Select Case DiaSemanal
                    Case DayOfWeek.Monday
                        drDatos("horasNormalesL") = HtoD(dRow("HORAS_NORMALES"))
                        drDatos("horasExtrasL") += HtoD(dRow("EXTRAS_AUTORIZADAS"))
                    Case DayOfWeek.Tuesday
                        drDatos("horasNormalesM") = HtoD(dRow("HORAS_NORMALES"))
                        drDatos("horasExtrasM") += HtoD(dRow("EXTRAS_AUTORIZADAS"))
                    Case DayOfWeek.Wednesday
                        drDatos("horasNormalesW") = HtoD(dRow("HORAS_NORMALES"))
                        drDatos("horasExtrasW") += HtoD(dRow("EXTRAS_AUTORIZADAS"))
                    Case DayOfWeek.Thursday
                        drDatos("horasNormalesJ") = HtoD(dRow("HORAS_NORMALES"))
                        drDatos("horasExtrasJ") += HtoD(dRow("EXTRAS_AUTORIZADAS"))
                    Case DayOfWeek.Friday
                        drDatos("horasNormalesV") = HtoD(dRow("HORAS_NORMALES"))
                        drDatos("horasExtrasV") += HtoD(dRow("EXTRAS_AUTORIZADAS"))
                    Case DayOfWeek.Saturday
                        drDatos("horasNormalesS") = HtoD(dRow("HORAS_NORMALES"))
                        drDatos("horasExtrasS") += HtoD(dRow("EXTRAS_AUTORIZADAS"))
                        'drDatos("horasNormalesS") = HtoD(dRow("HORAS_NORMALES"))
                        'drDatos("horasExtrasS") = HtoD(dRow("EXTRAS_AUTORIZADAS"))
                    Case DayOfWeek.Sunday
                        drDatos("horasNormalesD") = HtoD(dRow("HORAS_NORMALES"))
                        drDatos("horasExtrasD") += HtoD(dRow("EXTRAS_AUTORIZADAS"))
                End Select
            Next

            dtDatosPostFunciones = dtDatos

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub HistorialHorasBruto(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim dtProcesarDatos As New DataTable
        Dim dtBitacoraHrsBruto As New DataTable
        Dim cadena As String = ""

        Dim frm As New frmTrabajando
        frm.Show()

        Try
            Dim strFechaIni As String = FechaSQL(Trim(dtInformacion.Compute("MIN(FHA_ENT_HOR)", "").ToString))
            Dim strFechaFin As String = FechaSQL(Trim(dtInformacion.Compute("MAX(FHA_ENT_HOR)", "").ToString))

            dtDatos.Columns.Add("reloj", GetType(System.String))
            dtDatos.Columns.Add("nombre", GetType(System.String))
            dtDatos.Columns.Add("centro_costos", GetType(System.String))
            dtDatos.Columns.Add("area", GetType(System.String))
            dtDatos.Columns.Add("supervisor", GetType(System.String))
            dtDatos.Columns.Add("cod_clerk", GetType(System.String))
            dtDatos.Columns.Add("clerk", GetType(System.String))
            dtDatos.Columns.Add("horario", GetType(System.String))
            dtDatos.Columns.Add("fecha_cambio_de", GetType(System.String))
            dtDatos.Columns.Add("hora_cambio_de", GetType(System.String))
            dtDatos.Columns.Add("fecha_cambio_a", GetType(System.String))
            dtDatos.Columns.Add("hora_cambio_a", GetType(System.String))
            dtDatos.Columns.Add("tipo_tran", GetType(System.String))
            dtDatos.Columns.Add("usuario", GetType(System.String))
            dtDatos.Columns.Add("nombre_usuario", GetType(System.String))
            dtDatos.Columns.Add("fecha", GetType(System.String))

            Dim ListaRelojUnico = (From dr As DataRow In dtInformacion.AsEnumerable() _
                        Select dr.Field(Of String)("reloj")).Distinct

            For Each Relojunico As String In ListaRelojUnico
                My.Application.DoEvents()
                cadena = cadena & "'" & Relojunico & "'" & ","

            Next

            cadena = cadena.TrimEnd(",")

            If cadena.Trim = "" Then
                MessageBox.Show("Se presentó un error procesar la información para el reporte", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            My.Application.DoEvents()

            'dtBitacoraHrsBruto = sqlExecute("select personalvw.*,bhb.fecha_original as fecha_cambio_de," & _
            '                       "bhb.hora_original as hora_cambio_de,bhb.fecha as fecha_cambio_a," & _
            '                       "bhb.hora as hora_cambio_a,bhb.tipo_tran,bhb.usuario,bhb.fecha_cambio as fecha" & _
            '                       " from PERSONAL.dbo.personalvw inner join ta.dbo.bitacora_hrs_brt bhb on personalvw.RELOJ = bhb.reloj" & _
            '                       " where personalvw.reloj in(" & cadena & ") and (convert(date,fecha_cambio) >= '" & strFechaIni & "' and convert(date,fecha_cambio) <= '" & strFechaFin & "')")


            dtBitacoraHrsBruto = sqlExecute("select personalvw.*,bhb.fecha_original as fecha_cambio_de," & _
                                   "bhb.hora_original as hora_cambio_de,bhb.fecha as fecha_cambio_a," & _
                                   "bhb.hora as hora_cambio_a,bhb.tipo_tran,appuser.nombre as nombre_usuario,bhb.usuario,bhb.fecha_cambio as fecha" & _
                                   " from PERSONAL.dbo.personalvw inner join ta.dbo.bitacora_hrs_brt bhb on personalvw.RELOJ = bhb.reloj LEFT JOIN SEGURIDAD.dbo.appuser on bhb.usuario = appuser.username" & _
                                   " where personalvw.reloj in(" & cadena & ") and (convert(date,fecha_cambio) >= '" & strFechaIni & "' and convert(date,fecha_cambio) <= '" & strFechaFin & "') and bhb.usuario not In('Depuración','AnalisisTA')")

            My.Application.DoEvents()

            If Not dtBitacoraHrsBruto.Columns.Contains("ERROR") Then

                For Each drRow As DataRow In dtBitacoraHrsBruto.Select("", "reloj")

                    My.Application.DoEvents()

                    Dim drAgregar As DataRow = dtDatos.NewRow

                    drAgregar("reloj") = Trim(drRow("reloj"))
                    drAgregar("nombre") = Trim(drRow("nombres"))
                    drAgregar("centro_costos") = Trim(IIf(IsDBNull(drRow("centro_costos")), "", drRow("centro_costos")))
                    drAgregar("area") = Trim(IIf(IsDBNull(drRow("nombre_area")), "", drRow("nombre_area")))
                    drAgregar("supervisor") = Trim(IIf(IsDBNull(drRow("nombre_super")), "", drRow("nombre_super")))
                    drAgregar("cod_clerk") = Trim(IIf(IsDBNull(drRow("cod_clerk")), "", drRow("cod_clerk")))
                    drAgregar("clerk") = Trim(IIf(IsDBNull(drRow("nombre_clerk")), "", drRow("nombre_clerk")))
                    drAgregar("horario") = Trim(IIf(IsDBNull(drRow("nombre_horario")), "", drRow("nombre_horario")))
                    drAgregar("fecha_cambio_de") = Trim(IIf(IsDBNull(drRow("fecha_cambio_de")), "", drRow("fecha_cambio_de")))
                    drAgregar("hora_cambio_de") = Trim(IIf(IsDBNull(drRow("hora_cambio_de")), "", drRow("hora_cambio_de")))
                    drAgregar("fecha_cambio_a") = Trim(IIf(IsDBNull(drRow("fecha_cambio_a")), "", drRow("fecha_cambio_a")))
                    drAgregar("hora_cambio_a") = Trim(IIf(IsDBNull(drRow("hora_cambio_a")), "", drRow("hora_cambio_a")))
                    drAgregar("tipo_tran") = Trim(IIf(IsDBNull(drRow("tipo_tran")), "", drRow("tipo_tran")))
                    drAgregar("usuario") = Trim(IIf(IsDBNull(drRow("usuario")), "", drRow("usuario")))
                    drAgregar("nombre_usuario") = Trim(IIf(IsDBNull(drRow("nombre_usuario")), "", drRow("nombre_usuario")))
                    drAgregar("fecha") = Trim(IIf(IsDBNull(drRow("fecha")), "", drRow("fecha")))

                    dtDatos.Rows.Add(drAgregar)
                Next

                Dim sfd As New SaveFileDialog

                sfd.OverwritePrompt = True
                sfd.Title = "Guardar en"
                sfd.FileName = "Reporte_Historial_Horas_Bruto"
                sfd.DefaultExt = "xls"
                sfd.Filter = "Excel (*.xls)|*.xls"

                If sfd.ShowDialog() = DialogResult.OK Then
                    frmVistaPrevia.LlamarReporte("Reporte Historial Horas en Bruto", dtDatos, , , , sfd.FileName)
                    frmVistaPrevia.Show()
                End If

            Else

                MessageBox.Show("Se presentó un error procesar la información para el reporte", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "TA", ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un error procesar la información para el reporte", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ActivoTrabajando = False
        frm.Close()

    End Sub

    Public Sub RevisionIncidenciasClerk(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim frm As New frmTrabajando
        frm.Show()
        Try


            dtInformacion.Columns.Add("fh_incidencia", Type.GetType("System.String"))

            For Each row As DataRow In dtInformacion.Select("fha_ent_hor is not null")
                row("fh_incidencia") = FechaSQL(row("fha_ent_hor"))
            Next


            dtDatos = dtInformacion.Clone


            Dim min_date As Date = Now.Date
            Dim max_date As Date = Now.Date

            Dim filtros As New ArrayList
            filtros.Add("comentario like '%falta entrada%'")
            filtros.Add("comentario like '%falta salida%'")
            filtros.Add("comentario like '%salida anticipada%'")
            filtros.Add("comentario like '%retardo%'")
            filtros.Add("comentario like '%excepciones%'")
            filtros.Add("tipo_aus = 'FI'")
            filtros.Add("tipo_aus = 'ING'")

            For Each row As DataRow In dtInformacion.Select("fha_ent_hor is not null", "fha_ent_hor asc")
                min_date = Date.Parse(row("fha_ent_hor"))
                Exit For
            Next

            For Each row As DataRow In dtInformacion.Select("fha_ent_hor is not null", "fha_ent_hor desc")
                max_date = Date.Parse(row("fha_ent_hor"))
                Exit For
            Next

            For Each filtro As String In filtros
                For Each row As DataRow In dtInformacion.Select(filtro)

                    Application.DoEvents()

                    dtDatos.ImportRow(row)
                Next
            Next


            'CHECADAS SIN ANALIZAR
            Try
                Dim dtChecadasSinAnalizar As DataTable = sqlExecute("select hrs_brt.reloj, personalvw.nombres, personalvw.cod_clerk, personalvw.nombre_clerk as clerk_nombre, hrs_brt.fecha as fh_incidencia, 'SIN ANALIZAR ' + hrs_brt.hora as comentario from hrs_brt left join personal.dbo.personalvw on personalvw.reloj = hrs_brt.reloj " & _
                                                                " where isnull(hrs_brt.entrada_salida, '') <> '' and hrs_brt.fecha < cast(getdate() as date) and " & _
                                                                " hrs_brt.fecha between '" & FechaSQL(min_date) & "' and '" & FechaSQL(max_date) & "' and " & _
                                                                " hrs_brt.reloj in (select reloj from personal.dbo.personalvw  where nivel_seguridad <= '" & NivelConsulta & "' " & IIf(FiltroXUsuario.Trim = "", "", " and " & FiltroXUsuario) & ")", "TA")

                For Each row As DataRow In dtChecadasSinAnalizar.Rows
                    dtDatos.ImportRow(row)
                Next
            Catch ex As Exception

            End Try

            'Extras mayores a las normales
            Try
                Dim dtExtrasMayoresNormales As DataTable = sqlExecute("select asist.reloj, personalvw.nombres, personalvw.nombre_clerk as clerk_nombre, ano+'-'+periodo as 'fh_incidencia', 'EXTRAS MAYORES A LAS NORMALES (' + rtrim(cast(sum(dbo.htod(asist.horas_normales)) - sum(dbo.htod(asist.extras_autorizadas)) as char)) + ')' as COMENTARIO" & _
                                                                  " from asist" & _
                                                                  " left join personal.dbo.personalvw on personalvw.reloj = asist.reloj" & _
                                                                  " where asist.FHA_ENT_HOR between '" & FechaSQL(min_date) & "' and '" & FechaSQL(max_date) & "'" & _
                                                                  " and asist.reloj in (select reloj from personal.dbo.personalvw  where nivel_seguridad <= '" & NivelConsulta & "' " & IIf(FiltroXUsuario.Trim = "", "", " and " & FiltroXUsuario) & ")" & _
                                                                  " group by asist.reloj, personalvw.nombres, personalvw.nombre_clerk, ano+'-'+periodo" & _
                                                                  " having sum(dbo.htod(asist.horas_normales)) - sum(dbo.htod(asist.extras_autorizadas)) < 0", "TA")

                For Each row As DataRow In dtExtrasMayoresNormales.Rows
                    dtDatos.ImportRow(row)
                Next
            Catch ex As Exception

            End Try

            ' MAS DE 5 HRSPSG
            Try
                Dim dtMasDeCincoHRSPSG As DataTable = sqlExecute("select asist.reloj, personalvw.nombres, personalvw.nombre_clerk as clerk_nombre, ano+'-'+periodo as 'fh_incidencia', 'MAS DE 5 HORAS PSG (' + rtrim(cast(case when sum(dbo.htod(asist.horas_tarde)) > 0 then sum(dbo.htod(asist.horas_tarde)) else sum(dbo.htod(asist.horas_anticipadas)) end  as char)) + ')' as COMENTARIO" & _
                                                                  " from asist" & _
                                                                  " left join personal.dbo.personalvw on personalvw.reloj = asist.reloj" & _
                                                                  " where asist.FHA_ENT_HOR between '" & FechaSQL(min_date) & "' and '" & FechaSQL(max_date) & "'" & _
                                                                  " and asist.reloj in (select reloj from personal.dbo.personalvw  where nivel_seguridad <= '" & NivelConsulta & "' " & IIf(FiltroXUsuario.Trim = "", "", " and " & FiltroXUsuario) & ")" & _
                                                                  " group by asist.reloj, personalvw.nombres, personalvw.nombre_clerk, ano+'-'+periodo" & _
                                                                  " having sum(dbo.htod(asist.horas_tarde)) > 5 or  sum(dbo.htod(asist.horas_anticipadas)) > 5", "TA")

                For Each row As DataRow In dtMasDeCincoHRSPSG.Rows
                    dtDatos.ImportRow(row)
                Next
            Catch ex As Exception

            End Try



        Catch ex As Exception

        End Try
        ActivoTrabajando = False
        frm.Close()
    End Sub


    Public Sub PorcentajeTotalesDepartamento(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            dtDatos = New DataTable

            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_planta", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
            dtDatos.Columns.Add("centro_costos", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_area", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))

            dtDatos.Columns.Add("dias", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("faltas", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("alta", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("baja", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("al_inicio", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("al_final", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("f_ini", Type.GetType("System.String"))
            dtDatos.Columns.Add("f_fin", Type.GetType("System.String"))

            dtDatos.Columns.Add("prioridad", Type.GetType("System.String"))

            Dim f_ini As String = FechaSQL(dtInformacion.Select("cod_clase in ('D', 'I') and cod_comp = '090'", "fha_ent_hor asc")(0)("fha_ent_hor"))
            Dim f_fin As String = FechaSQL(dtInformacion.Select("cod_clase in ('D', 'I') and cod_comp = '090'", "fha_ent_hor desc")(0)("fha_ent_hor"))

            Dim f_0 As String = f_ini
            Dim f_1 As String = f_fin

            While Date.Parse(f_ini).DayOfWeek = DayOfWeek.Saturday Or Date.Parse(f_ini).DayOfWeek = DayOfWeek.Sunday
                f_ini = FechaSQL(Date.Parse(f_ini).AddDays(1))
            End While

            While Date.Parse(f_fin).DayOfWeek = DayOfWeek.Saturday Or Date.Parse(f_fin).DayOfWeek = DayOfWeek.Sunday
                f_fin = FechaSQL(Date.Parse(f_fin).AddDays(-1))
            End While

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj"), dtDatos.Columns("cod_planta"), dtDatos.Columns("cod_depto"), dtDatos.Columns("cod_super")}


            'SOLO PERSONAL 090 DIRECTO E INDIRECTO
            Dim _r As String = ""
            Dim _f As String = ""

            For Each row As DataRow In dtInformacion.Select("cod_clase in ('D', 'I') and cod_comp = '090'", "reloj,fha_ent_hor")

                Dim reloj As String = row("reloj")
                Dim fha As String = IIf(IsDBNull(row("fha_ent_hor")), "", FechaSQL(row("fha_ent_hor")))

                Dim aus_real As String = RTrim(IIf(IsDBNull(row("ausentismo_real")), "", row("ausentismo_real")))
                Dim comentario As String = RTrim(IIf(IsDBNull(row("comentario")), "", row("comentario")))
                Dim descanso As Boolean = IIf(comentario.ToLower.Contains("desc"), True, False)

                Dim parcial As Boolean = False

                If reloj <> _r Then
                    _r = reloj
                    _f = fha

                    parcial = False
                ElseIf fha = _f Then
                    parcial = True
                Else
                    _f = fha
                    parcial = False
                End If

                If Not parcial And Not descanso Then

                    Dim cod_planta As String = RTrim(IIf(IsDBNull(row("cod_planta")), "", row("cod_planta")))
                    Dim cod_depto As String = RTrim(IIf(IsDBNull(row("cod_depto")), "", row("cod_depto")))
                    Dim cod_super As String = RTrim(IIf(IsDBNull(row("cod_super")), "", row("cod_super")))

                    Dim drow As DataRow = dtDatos.Rows.Find({reloj, cod_planta, cod_depto, cod_super})



                    If IsNothing(drow) Then
                        drow = dtDatos.NewRow

                        drow("reloj") = reloj
                        drow("cod_planta") = cod_planta
                        drow("cod_depto") = cod_depto
                        drow("cod_super") = cod_super

                        drow("dias") = 1
                        drow("faltas") = 0

                        drow("alta") = 0
                        drow("baja") = 0

                        drow("al_inicio") = 0
                        drow("al_final") = 0

                        drow("f_ini") = f_0
                        drow("f_fin") = f_1

                        dtDatos.Rows.Add(drow)
                    Else
                        Dim dias As Integer = drow("dias")
                        drow("dias") = dias + 1
                    End If

                    Try
                        Dim alta As String = FechaSQL(row("alta"))
                        If fha = alta Then
                            drow("alta") = 1
                        End If

                        'Dim baja As String = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                        'If fha = baja Then
                        '    Dim dtBaja As DataTable = sqlExecute("select * from personal where reloj = '" & row("reloj") & "' and cod_mot_ba NOT in ('03', '04', '09', '07')")
                        '    If dtBaja.Rows.Count > 0 Then
                        '        drow("baja") = 1
                        '    End If
                        'End If

                    Catch ex As Exception

                    End Try

                    Dim falta_permiso As Integer = 0
                    '('FI','MAT','NAC','PGO','PSG','FUN','PSV')
                    Select Case aus_real
                        Case "FI"
                            falta_permiso = 1
                        Case "MAT"
                            falta_permiso = 1
                        Case "NAC"
                            falta_permiso = 1
                        Case "PGO"
                            falta_permiso = 1
                        Case "PSG"
                            falta_permiso = 1
                        Case "FUN"
                            falta_permiso = 1
                        Case "PSV"
                            falta_permiso = 1
                        Case Else
                            falta_permiso = 0
                    End Select

                    Dim faltas As Integer = drow("faltas")
                    drow("faltas") = faltas + IIf(falta_permiso > 0, 1, 0)

                    If fha = f_ini Then
                        drow("al_inicio") = 1
                    End If

                    If fha = f_fin Then
                        drow("al_final") = 1
                    End If

                End If

            Next

            Dim dtSuper As DataTable = sqlExecute("select distinct cod_super, nombre from super")
            Dim dtDeptos As DataTable = sqlExecute("select distinct cod_depto, centro_costos from deptos")
            Dim dtCC As DataTable = sqlExecute("select distinct centro_costos, cod_area from c_costos")
            Dim dtAreas As DataTable = sqlExecute("select distinct cod_area, nombre from areas")

            For Each row As DataRow In dtDatos.Rows
                Try : row("nombre_super") = dtSuper.Select("cod_super = '" & row("cod_super") & "'")(0)("nombre") : Catch : row("nombre_super") = "" : End Try
                Try : row("centro_costos") = dtDeptos.Select("cod_depto = '" & row("cod_depto") & "'")(0)("centro_costos") : Catch : row("centro_costos") = "" : End Try
                Try : row("cod_area") = dtCC.Select("centro_costos = '" & row("centro_costos") & "'")(0)("cod_area") : Catch : row("cod_area") = "" : End Try
                Try : row("nombre_area") = dtAreas.Select("cod_area = '" & row("cod_area") & "'")(0)("nombre") : Catch : row("nombre_area") = "" : End Try

                Dim cod_area As String = RTrim(row("cod_area"))

                Select Case cod_area
                    Case "03"
                        row("prioridad") = "01"
                    Case "08"
                        row("prioridad") = "02"
                    Case "04"
                        row("prioridad") = "03"
                    Case "28"
                        row("prioridad") = "03"
                    Case "09"
                        row("prioridad") = "03"
                    Case "32"
                        row("prioridad") = "03"
                    Case "33"
                        row("prioridad") = "03"
                    Case "31"
                        row("prioridad") = "03"
                    Case "05"
                        row("prioridad") = "04"
                    Case "07"
                        row("prioridad") = "05"
                    Case "30"
                        row("prioridad") = "06"
                    Case "26"
                        row("prioridad") = "07"
                    Case "11"
                        row("prioridad") = "08"
                    Case "16"
                        row("prioridad") = "09"
                    Case "02"
                        row("prioridad") = "10"
                    Case "20"
                        row("prioridad") = "11"
                    Case Else
                        row("prioridad") = "99"
                End Select
            Next

            Try
                Dim _r_baja As String = ""
                For Each row As DataRow In dtDatos.Select("", "reloj")
                    Dim _r_ As String = row("reloj")
                    If _r_ <> _r_baja Then
                        Dim dtBaja As DataTable = sqlExecute("select * from personal where reloj = '" & _r_ & "' and cod_mot_ba NOT in ('03', '04', '09', '07') and baja between '" & FechaSQL(f_ini) & "' and '" & FechaSQL(f_fin) & "'")
                        If dtBaja.Rows.Count > 0 Then
                            row("baja") = 1
                        End If
                    End If
                    _r_baja = _r_
                Next
            Catch ex As Exception

            End Try

            dtDatos = dtDatos.Select("", "cod_planta, prioridad, nombre_super").CopyToDataTable

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try

    End Sub

    Public Sub KardexEmpleado(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            dtDatos = dtInformacion.Copy
            dtDatos.Columns.Add("color_letra", Type.GetType("System.String"))
            dtDatos.Columns.Add("color_fondo", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_hora_actual", Type.GetType("System.String"))
            dtDatos.Columns.Add("area_actual", Type.GetType("System.String"))

            Dim dtColores As DataTable = sqlExecute("select rtrim(tipo_aus) as tipo_aus, color_letra, color_back from tipo_ausentismo", "TA")
            dtColores.PrimaryKey = ({dtColores.Columns("tipo_aus")})

            ActivoTrabajando = True
            frmTrabajando.Show()

            For Each row As DataRow In dtDatos.Rows

                frmTrabajando.lblAvance.Text = row("reloj")
                Application.DoEvents()

                Dim color_letra As Integer = Color.Black.ToArgb
                Dim color_fondo As Integer = Color.White.ToArgb
                Try
                    Dim tipo_aus As String = RTrim(row("tipo_aus"))
                    Dim drow As DataRow = dtColores.Rows.Find(tipo_aus)
                    If drow IsNot Nothing Then
                        color_letra = drow("color_letra")
                        color_fondo = drow("color_back")
                    End If
                Catch ex As Exception

                End Try
                row("color_letra") = "#" & color_letra.ToString("X").Substring(2, 6)
                row("color_fondo") = "#" & color_fondo.ToString("X").Substring(2, 6)

                row("cod_hora_actual") = row("cod_hora")

                Dim dtArea As DataTable = sqlExecute("select * from detalle_auxiliares where campo = 'area' and reloj = '" & row("reloj") & "'")
                If dtArea.Rows.Count > 0 Then
                    row("area_actual") = dtArea.Rows(0)("contenido")
                Else
                    row("area_actual") = ""
                End If


            Next

            ActivoTrabajando = False
            frmTrabajando.Dispose()
        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Dispose()
        End Try
    End Sub

    Public Sub GraficasAusentismo(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtPrimerAusentismo As DataTable
            Dim dtFaltasDI002610 As DataTable
            Dim strSQL As String = ""
            Dim dtTurno As DataTable
            Dim dtTemp As DataTable

            strSQL = "select distinct * from " & _
                "(select d.ENTRA,ta.dbo.getTurno(d.ENTRA) turno, rh.COD_HORA, rh.COD_COMP ,p.fecha_ini,p.fecha_fin " & _
                        "from ta.dbo.periodos p join personal.dbo.rol_horarios rh on p.ano = rh.ano and p.PERIODO = rh.PERIODO " & _
                        "     join personal.dbo.dias d on d.SEMANA = rh.SEMANA and d.cod_hora = rh.cod_hora and d.COD_COMP = rh.COD_COMP " & _
                        "where p.fecha_ini between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' " & _
                        "      and p.PERIODO_ESPECIAL = 0 " & _
                        "      and d.descanso = 0 " & _
                        ") as temp"
            dtTurno = sqlExecute(strSQL)

            dtPrimerAusentismo = sqlExecute("select pa.*, '0' asistencia, '1' falta, case pa.cod_comp when '610' then '1' else '0' end falta_BRP, case pa.cod_comp when '002' then '1' else '0' end falta_OH, " & _
                                            "   sa.Teamleader, sa.COD_SUB_AUS,sa.Comentarios, coalesce(tsa.nombre,'Undefined') nombre_sub_aus, coalesce(rtrim(pp.nombre)+' '+rtrim(pp.apaterno),'Undefined') nombre_teamleader " & _
                                            "from primer_ausentismo pa left join SubAusentismos sa on pa.reloj = sa.reloj and sa.Fecha_AUS = pa.fecha " & _
                                            "join personal.dbo.personal p on pa.RELOJ = p.reloj and p.cod_clase in ('D', 'I') " & _
                                            "left join tipo_sub_ausentismo tsa on sa.COD_SUB_AUS = tsa.tipo_sub_aus " & _
                                            "left join personal.dbo.personal pp on sa.Teamleader = pp.reloj " & _
                                            "where pa.fecha between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' " & _
                                            "order by pa.reloj, pa.fecha", "TA")

            dtDatos = New DataTable

            dtFaltasDI002610 = dtInformacion.Select("cod_clase in ('D', 'I') and cod_comp in ('610','002') and comentario not like '%desc%'", "reloj,fha_ent_hor").CopyToDataTable
            Dim query = From DT1 In dtFaltasDI002610.AsEnumerable()
                                Group Join DT2 In dtPrimerAusentismo.AsEnumerable()
                                On DT1.Field(Of String)("RELOJ") Equals DT2.Field(Of String)("RELOJ") And DT1.Field(Of Date)("fecha") Equals DT2.Field(Of Date)("FECHA") Into Group
                                From g In Group.DefaultIfEmpty()
                                Select reloj = DT1.Field(Of String)("RELOJ"), cod_comp = DT1.Field(Of String)("cod_comp"), nombre_super = DT1.Field(Of String)("NOMBRE_SUPER_PERSONAL"),
                                       cod_super = DT1.Field(Of String)("COD_SUPER"), cod_depto = DT1.Field(Of String)("COD_DEPTO"), cod_area = DT1.Field(Of String)("CC_AREA"),
                                       nombre_area = DT1.Field(Of String)("CC_NOMBRE_AREA"), TIPO_AUS = If(g Is Nothing, "", g("TIPO_AUS")), asistencia = If(g Is Nothing, 1, g("asistencia")),
                                       falta = If(g Is Nothing, 0, g("falta")), falta_BRP = If(g Is Nothing, 0, g("falta_BRP")), falta_OH = If(g Is Nothing, 0, g("falta_OH")),
                                       cod_sub_aus = If(g Is Nothing, "", g("COD_SUB_AUS")), nombre_sub_aus = If(g Is Nothing, "", g("nombre_sub_aus")), reloj_teamleader = If(g Is Nothing, "", g("Teamleader")),
                                        nombre_teamleader = If(g Is Nothing, "", g("nombre_teamleader")), cod_hora = DT1.Field(Of String)("cod_hora"), comentario = DT1.Field(Of String)("comentario")
            dtTemp = EQToDataTable(query)

            Dim qryTurno = From DT1 In dtTemp.AsEnumerable()
                            Group Join DT2 In dtTurno.AsEnumerable()
                            On DT1.Field(Of String)("cod_hora") Equals DT2.Field(Of String)("COD_HORA") And DT1.Field(Of String)("cod_comp") Equals DT2.Field(Of String)("COD_COMP") Into Group
                            From g In Group.DefaultIfEmpty()
                            Select reloj = DT1.Field(Of String)("RELOJ"), cod_hora = DT1.Field(Of String)("cod_hora"), turno = If(g Is Nothing, "1", g("turno")), cod_comp = DT1.Field(Of String)("cod_comp"),
                                   nombre_super = DT1.Field(Of String)("nombre_super"), cod_super = DT1.Field(Of String)("cod_super"), cod_depto = DT1.Field(Of String)("cod_depto"), cod_area = DT1.Field(Of String)("cod_area"),
                                   nombre_area = DT1.Field(Of String)("nombre_area").Trim(), TIPO_AUS = DT1.Field(Of String)("TIPO_AUS"), asistencia = DT1.Field(Of Int32)("asistencia"), falta = DT1.Field(Of Int32)("falta"),
                                   falta_BRP = DT1.Field(Of Int32)("falta_BRP"), falta_OH = DT1.Field(Of Int32)("falta_OH"), cod_sub_aus = DT1.Field(Of String)("cod_sub_aus"), nombre_sub_aus = DT1.Field(Of String)("nombre_sub_aus").Trim(),
                                   reloj_teamleader = DT1.Field(Of String)("reloj_teamleader"), nombre_teamleader = DT1.Field(Of String)("nombre_teamleader"), comentario = DT1.Field(Of String)("comentario"),
                                   cod_turno = If(g Is Nothing, "1", g("turno"))
            dtDatos = EQToDataTable(qryTurno)

            If dtDatos.Rows.Count > 0 Then
                dtDatos = dtDatos.Select("", "cod_comp, nombre_super").CopyToDataTable
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            MessageBox.Show("Ocurrio un error al generar el reporte de graficas ausentismo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Public Function EQToDataTable(ByVal parIList As System.Collections.IEnumerable) As System.Data.DataTable
        Dim ret As New System.Data.DataTable()
        Try
            Dim ppi As System.Reflection.PropertyInfo() = Nothing
            If parIList Is Nothing Then Return ret
            For Each itm In parIList
                If ppi Is Nothing Then
                    ppi = DirectCast(itm.[GetType](), System.Type).GetProperties()
                    For Each pi As System.Reflection.PropertyInfo In ppi
                        Dim colType As System.Type = pi.PropertyType
                        If (colType.IsGenericType) AndAlso
                           (colType.GetGenericTypeDefinition() Is GetType(System.Nullable(Of ))) Then colType = colType.GetGenericArguments()(0)
                        If pi.Name.Equals("asistencia") Or pi.Name.Equals("falta") Or pi.Name.Equals("falta_BRP") Or pi.Name.Equals("falta_OH") Then
                            ret.Columns.Add(New System.Data.DataColumn(pi.Name, System.Type.GetType("System.Int32")))
                        Else
                            ret.Columns.Add(New System.Data.DataColumn(pi.Name, colType))
                        End If
                    Next
                End If
                Dim dr As System.Data.DataRow = ret.NewRow
                For Each pi As System.Reflection.PropertyInfo In ppi
                    dr(pi.Name) = If(pi.GetValue(itm, Nothing) Is Nothing, DBNull.Value, pi.GetValue(itm, Nothing))
                Next
                ret.Rows.Add(dr)
            Next
            'For Each c As System.Data.DataColumn In ret.Columns
            '    c.ColumnName = c.ColumnName.Replace("_", " ")
            'Next
        Catch ex As Exception
            ret = New System.Data.DataTable()
        End Try
        Return ret
    End Function


    Public Sub AusentismoPorArea(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim dRow As DataRow

        'MCR - CAMBIO 10-OCT-2015
        'Enviar datos ya agrupados al reporte
        dtDatos = New DataTable
        'MCR - dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_area", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
        dtDatos.Columns.Add("fha_ent_hor", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("fecha", Type.GetType("System.String"))
        dtDatos.Columns.Add("ausentismo", Type.GetType("System.Int32"))
        '*** MCR - 
        dtDatos.Columns.Add("asistencia", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("empleados", Type.GetType("System.Int32"))
        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("cod_area"), dtDatos.Columns("cod_turno"), dtDatos.Columns("fha_ent_hor")}
        'MCR ***

        For Each row As DataRow In dtInformacion.Select("NOT fha_ent_hor IS NULL", "cc_area,cod_turno,fha_ent_hor")
            Try
                dRow = dtDatos.Rows.Find({IIf(IsDBNull(row("cc_area")), "", row("cc_area")), _
                                          IIf(IsDBNull(row("cod_turno")), "", row("cod_turno")), _
                                          IIf(IsDBNull(row("fha_ent_hor")), New Date, row("fha_ent_hor"))})
                If dRow Is Nothing Then
                    dRow = dtDatos.NewRow
                    dRow("cod_depto") = IIf(IsDBNull(row("cod_depto")), "", row("cod_depto")).ToString.Trim.ToUpper
                    dRow("cod_area") = IIf(IsDBNull(row("cc_area")), "", row("cc_area")).ToString.Trim.ToUpper
                    dRow("cod_turno") = IIf(IsDBNull(row("cod_turno")), "", row("cod_turno")).ToString.Trim
                    dRow("nombre_area") = IIf(IsDBNull(row("cc_nombre_area")), "", row("cc_nombre_area")).ToString.Trim.ToUpper
                    dRow("fha_ent_hor") = IIf(IsDBNull(row("fha_ent_hor")), New Date, row("fha_ent_hor"))
                    dRow("fecha") = DiaSem(row("fha_ent_hor")) & " " & FechaMediaLetra(row("fha_ent_hor"))
                    dRow("ausentismo") = 0
                    dRow("asistencia") = 0
                    dRow("empleados") = 0
                    dtDatos.Rows.Add(dRow)
                End If
                If IIf(IsDBNull(row("ausentismo")), 0, row("ausentismo")) = 1 Then
                    dRow("ausentismo") += 1
                ElseIf IIf(IsDBNull(row("horas_extras")), "00:00", row("horas_extras")) <> "00:00" Or IIf(IsDBNull(row("horas_normales")), "00:00", row("horas_normales")) <> "00:00" Then
                    dRow("asistencia") += 1
                Else
                    'Stop
                End If
                dRow("empleados") += 1
            Catch ex As Exception
                Debug.Print(ex.Message)
                Stop
            End Try
        Next

    End Sub
    'Public Sub FollowUpByWeek(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
    '    dtDatos = New DataTable

    '    dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("fecha", Type.GetType("System.String"))

    '    dtDatos.Columns.Add("mes", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("periodo", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("area", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("turno", Type.GetType("System.String"))

    '    dtDatos.Columns.Add("ausentismo", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("tipo_ausentismo", Type.GetType("System.String"))


    '    dtDatos.Columns.Add("incapacidad", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("tiempo_extra", Type.GetType("System.Int32"))

    '    dtDatos.Columns.Add("horas", Type.GetType("System.Int32"))

    '    dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj"), dtDatos.Columns("fecha")}
    '    Try
    '        For Each row As DataRow In dtInformacion.Rows



    '            Dim dRow As DataRow = dtDatos.Rows.Find({row("reloj"), row("fha_ent_hor")}) '= dtDatos.NewRow
    '            If dRow Is Nothing Then
    '                dRow = dtDatos.NewRow

    '                dRow("reloj") = row("reloj")
    '                dRow("fecha") = row("fha_ent_hor")

    '                Dim dtPeriodo As DataTable = sqlExecute("select * from ta.dbo.periodos where periodo_especial = 0 and '" & FechaSQL(row("fha_ent_hor")) & "' between fecha_ini and fecha_fin")
    '                If dtPeriodo.Rows.Count > 0 Then
    '                    dRow("mes") = dtPeriodo.Rows(0)("mes")
    '                    dRow("periodo") = dtPeriodo.Rows(0)("periodo")
    '                End If

    '                dRow("area") = row("cc_area")
    '                dRow("nombre_area") = row("cc_nombre_area")
    '                dRow("turno") = row("cod_turno")


    '                If row("ausentismo_real").ToString.Trim = "FI" Or row("ausentismo_real").ToString.Trim = "FJ" Or row("ausentismo_real").ToString.Trim.Contains("SUS") Or IIf(IsDBNull(row("tipo_naturaleza")), False, IIf(RTrim(row("tipo_naturaleza").ToString) = "I", True, False)) Then
    '                    dRow("ausentismo") = row("ausentismo")
    '                    dRow("tipo_ausentismo") = row("ausentismo_real")
    '                End If


    '                If IIf(IsDBNull(row("hrs_dobles")), 0, row("hrs_dobles")) > 0 Or IIf(IsDBNull(row("hrs_triples")), 0, row("hrs_triples")) > 0 Then
    '                    dRow("tiempo_extra") = 1
    '                End If

    '                dRow("incapacidad") = IIf(IsDBNull(row("tipo_naturaleza")), 0, IIf(RTrim(row("tipo_naturaleza").ToString) = "I", 1, 0))

    '                Dim dtHorasDistribuidas As DataTable = sqlExecute("select sum(horas) as horas from ta.dbo.time_allocation where reloj = '" & row("reloj") & "' and  fecha ='" & FechaSQL(row("fha_ent_hor")) & "'")
    '                If dtHorasDistribuidas.Rows.Count > 0 Then
    '                    dRow("horas") = dtHorasDistribuidas.Rows(0)("horas")
    '                Else
    '                    dRow("horas") = 0
    '                End If

    '                dtDatos.Rows.Add(dRow)
    '            End If

    '        Next
    '    Catch ex As Exception

    '    End Try



    'End Sub

    Public Sub FollowUpByWeek(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Try
            ' Dim dtHorasDistribuidas As DataTable
            Dim dtPeriodo As New DataTable
            Dim TI As DateTime = Now
            Dim Fecha As Date
            Dim EsFestivo As Boolean
            Dim EsDescanso As Boolean
            Dim dRow As DataRow
            Dim AnoMes As String = ""
            Dim Mes As String = ""
            Dim Periodo As String = ""

            dtDatos = New DataTable

            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano_mes", Type.GetType("System.String"))
            dtDatos.Columns.Add("mes", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))
            dtDatos.Columns.Add("area", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
            dtDatos.Columns.Add("turno", Type.GetType("System.String"))

            dtDatos.Columns.Add("ausentismo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("incapacidad", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("tiempo_extra", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("asistencia", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("horas", Type.GetType("System.Double"))

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("fecha"), dtDatos.Columns("reloj")}


            For Each row As DataRow In dtInformacion.Select("NOT FHA_ENT_HOR IS NULL", "fha_ent_hor")
                dRow = dtDatos.Rows.Find({row("fha_ent_hor"), row("reloj")}) '= dtDatos.NewRow
                If dRow Is Nothing Then
                    dRow = dtDatos.NewRow

                    dRow("reloj") = row("reloj")
                    dRow("fecha") = row("fha_ent_hor")

                    If Fecha <> row("fha_ent_hor") Then
                        'MCR
                        'Si cambia la fecha, buscar año, periodo y mes correspondiente
                        'Esto es para no tener que estar haciéndolo con cada registro
                        'El select debe estar ordenado por fha_ent_hor

                        Fecha = row("fha_ent_hor")

                        dtPeriodo = sqlExecute("select num_mes,ano,mes,periodo from ta.dbo.periodos where '" & _
                                       FechaSQL(Fecha) & "' between fecha_ini and fecha_fin AND periodo_especial = 0", "TA")
                        If dtPeriodo.Rows.Count > 0 Then
                            AnoMes = dtPeriodo.Rows(0)("ano").ToString.Trim & dtPeriodo.Rows(0)("num_mes").ToString.Trim
                            Mes = dtPeriodo.Rows(0)("mes").ToString.Trim
                            Periodo = dtPeriodo.Rows(0)("periodo")
                        Else
                            AnoMes = ""
                            Mes = ""
                            Periodo = ""
                        End If
                    End If

                    dRow("ano_mes") = AnoMes
                    dRow("mes") = Mes
                    dRow("periodo") = Periodo

                    dRow("area") = row("cc_area").ToString.Trim
                    dRow("nombre_area") = row("cc_nombre_area").ToString.Trim
                    dRow("turno") = row("cod_turno").ToString.Trim

                    If Not IsDBNull(row("ausentismo_real")) Then
                        'Si hay ausentismo, considerar solamente los que no gocen de pago regular, mientras no sean vacaciones o convenios
                        dtTemp = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE tipo_aus = '" & row("ausentismo_real").ToString.Trim & "' AND " & _
                                            "goce_sdo<>1 and NOT tipo_aus IN ('VAC' ,'CNV')", "TA")
                        If dtTemp.Rows.Count > 0 Then
                            dRow("ausentismo") = 1
                        End If
                        dRow("incapacidad") = IIf(IsDBNull(row("tipo_naturaleza")), 0, IIf(RTrim(row("tipo_naturaleza").ToString) = "I", 1, 0))
                    End If

                    'If row("ausentismo_real").ToString.Trim = "FI" Or row("ausentismo_real").ToString.Trim = "FJ" Or row("ausentismo_real").ToString.Trim.Contains("SUS") Or IIf(IsDBNull(row("tipo_naturaleza")), False, IIf(RTrim(row("tipo_naturaleza").ToString) = "I", True, False)) Then
                    '    dRow("ausentismo") = row("ausentismo")
                    '    dRow("tipo_ausentismo") = row("ausentismo_real")
                    'End If

                    dtDatos.Rows.Add(dRow)
                    EsDescanso = row("comentario").ToString.Contains("DESCANSO TRABAJADO")
                End If

                EsFestivo = IIf(IsDBNull(row("tipo_aus")), "", row("tipo_aus")) = "FES"

                If EsFestivo Or EsDescanso Then
                    dRow("tiempo_extra") = IIf(IIf(IsDBNull(row("horas_extras")), "00:00", row("horas_extras")).ToString.Trim > "00:00", 1, 0)
                End If

                If IIf(IsDBNull(row("horas_normales")), "00:00", row("horas_normales")) <> "00:00" Or IIf(IsDBNull(row("horas_extras")), "00:00", row("horas_extras")) <> "00:00" Then
                    If Not EsFestivo Then
                        dRow("horas") = IIf(IsDBNull(dRow("horas")), 0, dRow("horas")) + _
                                        IIf(IsDBNull(row("horas_normales")), 0, HtoD(row("horas_normales"))) + _
                                        IIf(IsDBNull(row("horas_extras")), 0, HtoD(row("horas_extras")))
                        dRow("asistencia") = 1
                    ElseIf IIf(IsDBNull(row("horas_extras")), "00:00", row("horas_extras")) <> "00:00" Then
                        dRow("asistencia") = 1
                    End If
                End If

                'dtHorasDistribuidas = sqlExecute("select sum(horas) as horas from ta.dbo.time_allocation where reloj = '" & _
                'row("reloj") & "' and  fecha ='" & FechaSQL(row("fha_ent_hor")) & "'")
                'If dtHorasDistribuidas.Rows.Count > 0 Then
                '    'dRow("horas") = dtHorasDistribuidas.Rows(0)("horas")
                'End If

                My.Application.DoEvents()
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub HorasTrabajadas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtFiltroFinal As New DataTable
            Dim _fini As Date = Now.Date
            Dim _ffin As Date = _fini.AddDays(7).Date

            Dim frm As New frmRangoFechas
            If frm.ShowDialog = DialogResult.OK Then
                _fini = FechaInicial
                _ffin = FechaFinal
            Else
                Exit Sub
            End If

            Dim dtTavw As DataTable = sqlExecute("SELECT COD_COMP,COMPANIA,COD_TIPO,COD_CLASE,CENTRO_COSTOS,NOMBRE_CC,COD_DEPTO,NOMBRE_DEPTO,COD_SUPER,NOMBRE_SUPER,COD_TURNO,RELOJ,AUSENTISMO,HORAS_NORMALES,ALTA,BAJA," & _
                                                 "EXTRAS_AUTORIZADAS,ANO,PERIODO,HORAS_TURNO FROM TAVW WHERE FHA_ENT_HOR between '" & FechaSQL(_fini) & "' and '" & FechaSQL(_ffin) & "'", "TA")

            '--Obt Personas faltantes
            Dim dtFalt As DataTable = sqlExecute("SELECT RELOJ,COD_COMP,ALTA,AMATERNO,APATERNO,NOMBRE,NOMBRES,AVISO_ACC,BAJA,BANCO,CHECA_TARJETA,COD_CD,COD_CIVIL,COD_CLASE AS 'COD_CLASE_PERSONAL',COD_COL,COD_COMP AS 'COD_COMP_PERSONAL',COD_DEPTO AS 'COD_DEPTO_PERSONAL',COD_EDO,COD_HORA,COD_LINEA,COD_MOT_BA,COD_MOT_IM,COD_PLANTA," & _
                                                 "COD_PUESTO AS 'COD_PUESTO_PERSONAL',COD_SUPER AS 'COD_SUPER_PERSONAL',COD_TIPO AS 'COD_TIPO_PERSONAL',COD_TURNO AS 'COD_TURNO_PERSONAL',COMENTARIO AS 'COMENTARIO_PERSONAL',CREDITO_IN,CUENTA_BANCO,CURP,DIAS_AGUINALDO,DIAS_VACACIONES,DIG_VER,DIG_VER_IN,DIRECCION,FACTOR_INT,FAH_PARTIC,FAH_PORCEN,FECHA_CRE," & _
                                                 "FHA_NAC,FHA_ULT_EV,FHA_ULT_MO,GAFETE AS 'GAFETE_PERSONAL',IMSS,INFONAVIT,INTEGRADO,LOCKER,LUGARN,NIVEL,NOMBRE,NOMBRE_DEPTO AS 'NOMBRE_DEPTO_PERSONAL',NOMBRE_HORARIO AS 'NOMBRE_HORARIO_PERSONAL',NOMBRE_PUESTO AS 'NOMBRE_PUESTO_PERSONAL',NOMBRE_SUPER AS 'NOMBRE_SUPER_PERSONAL',NOMBRE_PLANTA," & _
                                                 "NOMBRE_LINEA,PAGO_INF,PAGO_SEGVI,PRO_VAR,RECONTRATA,RFC,SACTUAL,SAL_ANT,SEXO,TELEFONO,TIPO_CRE,TIPO_PAGO,HORAS AS HORAS_TURNO,UMF,EDAD,ESCOLARIDAD,ANTIGUEDAD,FOTO,NOMBRE_COLONIA,NOMBRE_TIPOEMP,NOMBRE_TURNO,NOMBRE_CLASE,LUGAR_NAC,MOTIVO_BAJA,MOTIVO_BAJA_IM " & _
                                                 "FROM PERSONALVW WHERE RELOJ not in " & _
                                                 "(SELECT RELOJ FROM ta.dbo.TAVW WHERE FHA_ENT_HOR between '" & FechaSQL(_fini) & "' and '" & FechaSQL(_ffin) & "') AND (BAJA IS NULL OR baja>'" & FechaSQL(_fini) & "') AND alta <= '" & FechaSQL(_ffin) & "'", "PERSONAL")

            '---Agregar personal faltante
            For Each dEmp As DataRow In dtFalt.Rows
                dtTavw.ImportRow(dEmp)
            Next

            '-----Faltaría lo de actualizar bitácora??
            '-----PENDIENTE

            '---Mandar al Dt final filtrado con lo que hayamos mandado
            dtFiltroFinal = dtTavw.Clone
            For Each dR As DataRow In dtTavw.Select(FiltroReporte, OrdenReporte)
                dtFiltroFinal.ImportRow(dR)
            Next

            dtDatos = New DataTable
            dtDatos.Columns.Add("COD_COMP")
            dtDatos.Columns.Add("COMPANIA")
            dtDatos.Columns.Add("COD_TIPO")
            dtDatos.Columns.Add("COD_CLASE")
            dtDatos.Columns.Add("CENTRO_COSTOS")
            dtDatos.Columns.Add("NOMBRE_CC")
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("NOMBRE_DEPTO")
            dtDatos.Columns.Add("COD_SUPER")
            dtDatos.Columns.Add("NOMBRE_SUPER")
            dtDatos.Columns.Add("COD_TURNO")
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("ASISTENCIA", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("HORAS_NORMALES", Type.GetType("System.Double"))
            dtDatos.Columns.Add("EXTRAS_AUTORIZADAS", Type.GetType("System.Double"))
            dtDatos.Columns.Add("TOTALES", Type.GetType("System.Double"))
            dtDatos.Columns.Add("ANO")
            dtDatos.Columns.Add("PERIODO")
            dtDatos.Columns.Add("HORAS_TURNO", Type.GetType("System.Double"))
            dtDatos.Columns.Add("FECHA_INI")
            dtDatos.Columns.Add("FECHA_FIN")

            For Each row As DataRow In dtFiltroFinal.Rows
                dtDatos.Rows.Add(row("cod_comp"), row("compania"), row("cod_tipo"), row("cod_clase"), row("centro_costos"), row("nombre_cc"),
                                 row("cod_depto"), row("nombre_depto"), _
                                 row("cod_super"), row("nombre_super"), row("cod_turno"), row("reloj"), _
                                 IIf(IIf(IsDBNull(row("ausentismo")), 0, 1) = 1, 0, 1), _
                                 HtoD(IIf(IsDBNull(row("HORAS_NORMALES")), "00:00", row("HORAS_NORMALES"))), _
                                 HtoD(IIf(IsDBNull(row("EXTRAS_AUTORIZADAS")), "00:00", row("EXTRAS_AUTORIZADAS"))), _
                                 HtoD(IIf(IsDBNull(row("HORAS_NORMALES")), "00:00", row("HORAS_NORMALES"))) + _
                                 HtoD(IIf(IsDBNull(row("EXTRAS_AUTORIZADAS")), "00:00", row("EXTRAS_AUTORIZADAS"))), row("ANO"), row("PERIODO"), row("HORAS_TURNO"), _
                                 FechaSQL(_fini), FechaSQL(_ffin))
            Next
            '---Original
            'For Each row As DataRow In dtInformacion.Rows
            '    dtDatos.Rows.Add(row("cod_comp"), row("compania"), row("cod_tipo"), row("cod_clase"), row("centro_costos"), row("nombre_cc"),
            '                     row("cod_depto"), row("nombre_depto"), _
            '                     row("cod_super"), row("nombre_super"), row("cod_turno"), row("reloj"), _
            '                     IIf(IIf(IsDBNull(row("ausentismo")), 0, 1) = 1, 0, 1), _
            '                     HtoD(IIf(IsDBNull(row("HORAS_NORMALES")), "00:00", row("HORAS_NORMALES"))), _
            '                     HtoD(IIf(IsDBNull(row("EXTRAS_AUTORIZADAS")), "00:00", row("EXTRAS_AUTORIZADAS"))), _
            '                     HtoD(IIf(IsDBNull(row("HORAS_NORMALES")), "00:00", row("HORAS_NORMALES"))) + _
            '                     HtoD(IIf(IsDBNull(row("EXTRAS_AUTORIZADAS")), "00:00", row("EXTRAS_AUTORIZADAS"))), row("ANO"), row("PERIODO"), row("HORAS_TURNO"), _
            '                     FechaSQL(FechaInicial), FechaSQL(FechaFinal))
            'Next
        Catch ex As Exception
            dtDatos.Rows.Clear()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub Reporteasistenciaperfecta(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        dtDatos = New DataTable
        dtDatos.Columns.Add("RELOJ")
        dtDatos.Columns.Add("NOMBRES")
        dtDatos.Columns.Add("COD_COMP")
        dtDatos.Columns.Add("cod_turno")
        dtDatos.Columns.Add("cod_depto")
        dtDatos.Columns.Add("COD_HORA")
        dtDatos.Columns.Add("nombre_super")
        dtDatos.Columns.Add("nombre_puesto")
        dtDatos.Columns.Add("fecha_ini")
        dtDatos.Columns.Add("fecha_fin")

        Dim frm_fechas As New frmRangoFechas
        frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
        frm_fechas.frmRangoFechas_fecha_fin = Now
        frm_fechas.ShowDialog()

        Dim filtros As String = frmReporteadorTA.FiltrosAcumulados
        'Dim dtIncapacidades As DataTable = sqlExecute(
        '"select distinct RELOJ,NOMBRES,COD_TURNO,COD_DEPTO,NOMBRE_SUPER,NOMBRE_PUESTO,'' as fecha_ini,'' as fecha_fin from TA.dbo.tavw where alta <'" & FechaSQL(FechaInicial) & "' and baja is null", "TA")

        Dim dtRelojes As DataTable = sqlExecute("select distinct RELOJ from TAVW where alta<'" & FechaSQL(FechaInicial) & "' and baja is NULL and " & filtros & "", "TA")



        For Each row As DataRow In dtRelojes.Rows
            Dim dtasistencia As DataTable = sqlExecute("select * from tavw where reloj = '" & row("reloj") & "' and  fecha_entro between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and comentario not like '%RETARDO%' and (tipo_aus is not null and tipo_aus <> 'vac' and tipo_aus <> 'fes' and tipo_aus <> 'cor')", "TA")

            If dtasistencia.Rows.Count Then
            Else
                Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj = '" & row("reloj") & "'")

                dtDatos.Rows.Add({
                                        row("Reloj"),
                                        dtPersona.Rows(0)("NOMBRES"),
                                        dtPersona.Rows(0)("COD_COMP"),
                                        dtPersona.Rows(0)("cod_turno"),
                                        dtPersona.Rows(0)("cod_depto"),
                                        dtPersona.Rows(0)("COD_HORA"),
                                        dtPersona.Rows(0)("nombre_super"),
                                        dtPersona.Rows(0)("nombre_puesto"),
                                        FechaSQL(FechaInicial),
                                        FechaSQL(FechaFinal)
                                        })
            End If

            'Dim dtIncapacidad As DataTable = sqlExecute("select RELOJ from TAVW where alta<'" & FechaSQL(FechaInicial) & "'", "TA")


            'End If

        Next



    End Sub

    Public Sub Reporteausentismo(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("tipo_aus", Type.GetType("System.String"))

            dtDatos.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))


            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_comp", Type.GetType("System.String"))
            dtDatos.Columns.Add("compania", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

            dtDatos.Columns.Add("nombre_tipo_ausentismo", Type.GetType("System.String"))

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj"), dtDatos.Columns("fecha")}

            For Each row As DataRow In dtInformacion.Select("trim(isnull(ausentismo_real, '')) <> ''")
                Try
                    Dim drow As DataRow
                    drow = dtDatos.Rows.Find({row("reloj"), row("fha_ent_hor")})
                    If drow Is Nothing Then
                        drow = dtDatos.NewRow

                        drow("reloj") = row("reloj")
                        drow("fecha") = row("fha_ent_hor")
                        drow("tipo_aus") = row("ausentismo_real")

                        drow("nombres") = row("nombres")

                        drow("cod_clase") = row("cod_clase")
                        drow("cod_turno") = row("cod_turno")

                        drow("cod_comp") = row("cod_comp")
                        drow("compania") = row("compania")

                        drow("cod_depto") = row("cod_depto")
                        drow("nombre_depto") = row("nombre_depto")

                        drow("cod_super") = row("cod_super")
                        drow("nombre_super") = row("nombre_super")

                        drow("nombre_tipo_ausentismo") = row("nombre_aus")

                        drow("fecha_ini") = FechaInicial
                        drow("fecha_fin") = FechaFinal

                        dtDatos.Rows.Add(drow)
                    Else

                    End If

                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ReporteIncapacidades(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("cod_comp")
            dtDatos.Columns.Add("compania")
            dtDatos.Columns.Add("cod_depto")
            dtDatos.Columns.Add("nombre_depto")
            dtDatos.Columns.Add("cod_clase")
            dtDatos.Columns.Add("fecha_ini_incapacidad")
            dtDatos.Columns.Add("fecha_fin_incapacidad")
            dtDatos.Columns.Add("Dias")
            dtDatos.Columns.Add("tipo_naturaleza")
            dtDatos.Columns.Add("nombre_naturaleza")
            dtDatos.Columns.Add("referencia")
            dtDatos.Columns.Add("tipo_aus")
            dtDatos.Columns.Add("nombre_tipo_ausentismo")
            dtDatos.Columns.Add("fecha_ini")
            dtDatos.Columns.Add("fecha_fin")

            Dim dtIncapacidad As DataTable = sqlExecute("SELECT DISTINCT ausentismo.RELOJ,TAVW.nombres,TAVW.COD_COMP,TAVW.COMPANIA,TAVW.COD_DEPTO,TAVW.NOMBRE_DEPTO,MAX(DISTINCT tavw.COD_CLASE) AS COD_CLASE,tipo_ausentismo.TIPO_NATURALEZA,naturaleza_aus.NOMBRE as nombre_naturaleza,AUSENTISMO.REFERENCIA, " & _
                                                                         "AUSENTISMO.TIPO_AUS,tipo_ausentismo.NOMBRE as 'nombre_tipo_ausentismo'" & _
                                                        "FROM ausentismo left join TAVW on TAVW.RELOJ=AUSENTISMO.RELOJ left join tipo_ausentismo on tipo_ausentismo.TIPO_AUS=AUSENTISMO.TIPO_AUS " & _
                                                                        "left join naturaleza_aus on naturaleza_aus.TIPO_NATURALEZA=tipo_ausentismo.TIPO_NATURALEZA " & _
                                                        "GROUP BY ausentismo.RELOJ,tavw.nombres,tavw.COD_COMP,tavw.COMPANIA,tavw.COD_DEPTO,tavw.NOMBRE_DEPTO,tavw.COD_HORA,tipo_ausentismo.TIPO_NATURALEZA,naturaleza_aus.NOMBRE,ausentismo.REFERENCIA, " & _
                                                                 "ausentismo.TIPO_AUS, tipo_ausentismo.NOMBRE " & _
                                                        "HAVING tipo_ausentismo.TIPO_NATURALEZA = 'I' " & _
                                                        "ORDER BY ausentismo.RELOJ", "TA")

            Dim filtros As String = frmReporteadorTA.FiltrosAcumulados
            Dim ausentismo As String = ""
            Dim incapacidades As String = ""

            Try
                For Each row As DataRow In dtIncapacidad.Rows
                    Try
                        Dim dtDias As DataTable = sqlExecute("SELECT ausentismo.RELOJ, '' AS NOMBRES, ausentismo.REFERENCIA, ausentismo.TIPO_AUS, COUNT('') AS DIAS, COUNT('') AS DIAS_NS, MIN(ausentismo.FECHA) AS FECHA_INICIO, MAX(ausentismo.FECHA) AS FECHA_FINAL " & _
                                                             "FROM naturaleza_aus INNER JOIN tipo_ausentismo ON naturaleza_aus.TIPO_NATURALEZA = tipo_ausentismo.TIPO_NATURALEZA INNER JOIN ausentismo ON tipo_ausentismo.TIPO_AUS = ausentismo.TIPO_AUS " & _
                                                             "WHERE (ausentismo.FECHA BETWEEN '" & RangoFInicial & "' AND '" & RangoFFinal & "') AND (naturaleza_aus.TIPO_NATURALEZA = 'I') AND (RELOJ = '" & row("reloj") & "') and REFERENCIA = '" & RTrim(IIf(IsDBNull(row("REFERENCIA")), "", row("REFERENCIA"))) & "'" & _
                                                             "GROUP BY ausentismo.RELOJ, ausentismo.TIPO_AUS, ausentismo.REFERENCIA " & _
                                                             "ORDER BY ausentismo.RELOJ, FECHA_INICIO", "TA")

                        dtDatos.Rows.Add(row("Reloj"), RTrim(row("NOMBRES")), RTrim(row("cod_comp")), RTrim(row("compania")), row("cod_depto"), row("nombre_depto"), row("cod_clase"), FechaSQL(dtDias.Rows(0)("FECHA_INICIO")), FechaSQL(dtDias.Rows(0)("FECHA_FINAL")), dtDias.Rows(0)("DIAS"), row("tipo_naturaleza"), row("nombre_naturaleza"), row("referencia"), row("tipo_aus"), RTrim(row("nombre_tipo_ausentismo")), FechaSQL(FechaInicial), FechaSQL(FechaFinal))
                    Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
                    End Try
                Next
            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub RrtIncapa(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("FOLIO")
            dtDatos.Columns.Add("TIPO_AUS")
            dtDatos.Columns.Add("DIAS")
            dtDatos.Columns.Add("DIAS_NS")
            dtDatos.Columns.Add("FECHA_INICIO")
            dtDatos.Columns.Add("FECHA_FINAL")
            dtDatos.Columns.Add("FECHAR_INICIO")
            dtDatos.Columns.Add("FECHAR_FINAL")

            Dim nDia As Integer
            Dim dtIncapacidad As DataTable = sqlExecute("SELECT ausentismo.RELOJ, '' AS NOMBRES, ausentismo.REFERENCIA AS FOLIO, ausentismo.TIPO_AUS, COUNT(ausentismo.fecha) as DIAS_NS " & _
                                                   "FROM naturaleza_aus INNER JOIN " & _
                                                   "tipo_ausentismo ON naturaleza_aus.TIPO_NATURALEZA = tipo_ausentismo.TIPO_NATURALEZA INNER JOIN " & _
                                                   "ausentismo ON tipo_ausentismo.TIPO_AUS = ausentismo.TIPO_AUS " & _
                                                   "WHERE ausentismo.FECHA BETWEEN '" & FechaSQL(RangoFInicial) & "' AND '" & FechaSQL(RangoFFinal) & "' AND naturaleza_aus.TIPO_NATURALEZA = 'I'" & _
                                                   "GROUP BY ausentismo.RELOJ, ausentismo.TIPO_AUS, ausentismo.REFERENCIA " & _
                                                   "ORDER BY ausentismo.RELOJ", "TA")

            Dim filtros As String = frmReporteadorTA.FiltrosAcumulados

            Dim ausentismo As String = ""
            Dim incapacidades As String = ""

            Try

                For Each row As DataRow In dtIncapacidad.Rows
                    Dim dtPersonal As DataTable = sqlExecute("Select NOMBRES FROM PERSONALVW WHERE RELOJ = '" & row("RELOJ") & "'", "PERSONAL")
                    Dim dtDias As DataTable = sqlExecute("select reloj,tipo_aus,referencia, min(fecha) as inicio, max(fecha) as final, count(reloj) as dias " & _
                                                         "from ausentismo " & _
                                                         "where reloj = '" & row("reloj") & "' and referencia = '" & row("Folio") & "'" & _
                                                         "group by reloj, tipo_aus, referencia", "TA")

                    'Dim DiaSem As Date = row("FECHA_INICIO")
                    'nDia = (7 - DiaSem.DayOfWeek)
                    dtDatos.Rows.Add({
                    row("RELOJ"),
                    RTrim(dtPersonal.Rows(0).Item("NOMBRES")),
                    RTrim(row("FOLIO")),
                    RTrim(row("TIPO_AUS")),
                    dtDias.Rows(0).Item("dias"),
                    row("DIAS_NS"),
                    FechaSQL(dtDias.Rows(0).Item("inicio")),
                    FechaSQL(dtDias.Rows(0).Item("final")),
                    FechaSQL(RangoFInicial),
                    FechaSQL(RangoFFinal)
                    })
                Next
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ExportacionAusentismo(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim LocalRangoFInicial As Date = RangoFInicial
        Dim LocalRangoFFinal As Date = RangoFFinal

        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("cod_clase")
            dtDatos.Columns.Add("cod_hora")
            dtDatos.Columns.Add("tipo")
            dtDatos.Columns.Add("dias")
            dtDatos.Columns.Add("tipo_nombre")
            dtDatos.Columns.Add("fecha")
            dtDatos.Columns.Add("tipo_aus_nombre")
            dtDatos.Columns.Add("tipo_aus")
            dtDatos.Columns.Add("fecha_ini")
            dtDatos.Columns.Add("fecha_fin")
            dtDatos.Columns.Add("referencia")

            Dim frm_cia As New frmSeleccionarCia
            frm_cia.ShowDialog()

            Dim frm_fechas As New frmRangoFechas
            frm_fechas.frmRangoFechas_fecha_ini = LocalRangoFInicial
            frm_fechas.frmRangoFechas_fecha_fin = LocalRangoFFinal
            frm_fechas.ShowDialog()

            Dim ausentismo As String = ""
            Dim incapacidades As String = ""

            Dim sfd As New SaveFileDialog


            Try
                Dim dtIncapacidades As DataTable = sqlExecute("select DISTINCT reloj, referencia,ausentismo.tipo_aus,tipo_ausentismo.NOMBRE  from ausentismo left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus where ausentismo.tipo_aus in (select tipo_aus from tipo_ausentismo where tipo_naturaleza = 'I') and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and cod_comp = '" & Compania & "'", "TA")

                For Each row As DataRow In dtIncapacidades.Rows
                    Dim dtFechas As DataTable = sqlExecute("select top 1 fecha from ausentismo where reloj = '" & row("reloj") & "' and referencia = '" & RTrim(IIf(IsDBNull(row("referencia")), "", row("referencia"))) & "' order by fecha asc", "TA")

                    If dtFechas.Rows(0)("fecha") >= FechaInicial Then
                        Dim dtDias As DataTable = sqlExecute("select referencia, count(distinct(fecha)) as dias from ausentismo where referencia = '" & RTrim(IIf(IsDBNull(row("referencia")), "", row("referencia"))) & "' group by referencia", "TA")

                        Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj = '" & row("reloj") & "'")

                        dtDatos.Rows.Add({
                        row("Reloj"),
                        dtPersona.Rows(0)("NOMBRES"),
                        dtPersona.Rows(0)("cod_clase"),
                        dtPersona.Rows(0)("cod_hora"),
                        "I",
                        dtDias.Rows(0)("dias"),
                        "INCAPACIDADES",
                        FechaSQL(dtFechas.Rows(0)("fecha")),
                         row("nombre"),
                         row("tipo_aus"),
                        FechaSQL(FechaInicial),
                        FechaSQL(FechaFinal),
                        row("referencia").ToString.Substring(0, 8)
                        })

                        Dim fechafin As Date = Date.Parse(dtFechas.Rows(0)("fecha")).AddDays(dtDias.Rows(0)("dias"))

                    End If
                Next
            Catch ex As Exception

            End Try


            Try
                Dim dtAusentismo As DataTable = sqlExecute("select DISTINCT reloj, fecha, ausentismo.tipo_aus,tipo_ausentismo.NOMBRE  from ausentismo left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus where ausentismo.tipo_aus in (select tipo_aus from tipo_ausentismo where afecta_sua = '1') and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and cod_comp = '" & Compania & "'", "TA")

                For Each row As DataRow In dtAusentismo.Rows

                    Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj = '" & row("reloj") & "'")

                    dtDatos.Rows.Add({
                    row("Reloj"),
                    dtPersona.Rows(0)("NOMBRES"),
                    dtPersona.Rows(0)("cod_clase"),
                    dtPersona.Rows(0)("cod_hora"),
                    "A",
                    1,
                    "AUSENTISMOS",
                   FechaSQL(row("fecha")),
                     row("nombre"),
                     row("tipo_aus"),
                    FechaSQL(FechaInicial),
                    FechaSQL(FechaFinal),
                    ""
                    })

                Next
            Catch ex As Exception

            End Try



            Try
                sfd.DefaultExt = ".txt"
                sfd.Title = "EXPORTACION AUSENTISMO"
                sfd.FileName = Compania & "_ausentismo_" & FechaSQL(Date.Now) & ".txt"
                sfd.OverwritePrompt = True
                If sfd.ShowDialog() = DialogResult.OK Then
                    ausentismo = sfd.FileName
                End If

                sfd.DefaultExt = ".txt"
                sfd.Title = "EXPORTACION INCAPACIDADES"
                sfd.FileName = Compania & "_incapacidades_" & FechaSQL(Date.Now) & ".txt"
                sfd.OverwritePrompt = True
                If sfd.ShowDialog() = DialogResult.OK Then
                    incapacidades = sfd.FileName
                End If

                Dim writer As New StreamWriter(ausentismo)
                For Each row As DataRow In dtDatos.Select("tipo = 'A'")
                    writer.WriteLine(row("reloj").ToString.PadLeft(6, "0") & FechaSQL(row("fecha")).Replace("-", ""))
                Next
                writer.Close()

                writer = New StreamWriter(incapacidades)
                For Each row As DataRow In dtDatos.Select("tipo = 'I'")
                    writer.WriteLine(row("reloj").ToString.PadLeft(6, "0") & RTrim(row("referencia")).PadRight(8, " ") & Space(1) & FechaSQL(row("fecha")).Replace("-", "") & row("dias").ToString.PadLeft(2, " ") & Space(1) & row("tipo_aus").ToString.PadLeft(3, " ")) 'chuy
                Next
                writer.Close()


            Catch ex As Exception

            End Try
        Catch ex As Exception
            MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
        End Try


    End Sub
    Public Sub KardexAnual(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable, ByVal ParametrosAdicionales As String())
        Try
            Dim Ano As Integer = ParametrosAdicionales(0)
            Dim Reloj As String = ParametrosAdicionales(1)

            Dim dtPersonal As New DataTable
            Dim Fecha As New Date(Ano, 1, 1)
            Dim FinAno As New Date(Ano, 12, 31)
            Dim FAlta As Date
            Dim FBaja As Date

            dtDatos = New DataTable
            dtDatos.Columns.Add("numMes", GetType(System.Int16))
            dtDatos.Columns.Add("mes")
            dtDatos.Columns.Add("dia", GetType(System.Int16))
            dtDatos.Columns.Add("año")
            dtDatos.Columns.Add("detalle")
            dtDatos.Columns.Add("color_back", GetType(System.Double))
            dtDatos.Columns.Add("color_letra", GetType(System.Double))

            dtPersonal = sqlExecute("SELECT alta,baja from personalvw WHERE reloj = '" & Reloj & "'")
            FAlta = dtPersonal.Rows(0).Item("alta")
            FBaja = IIf(IsDBNull(dtPersonal.Rows(0).Item("baja")), DateSerial(2100, 1, 1), dtPersonal.Rows(0).Item("baja"))
            Do Until Fecha = FinAno
                If (Fecha < FAlta Or Fecha > FBaja) And Fecha < Now Then
                    dtDatos.Rows.Add({Fecha.Month, MesLetra(Fecha), Fecha.Day, Ano, "---"})
                Else
                    'dtDatos.Rows.Add({Month(Fecha), MesLetra(Fecha), Fecha.Day, ""})
                    Dim Q As String = "select ausentismo.tipo_aus,color_letra,color_back FROM ausentismo " & _
                                            "LEFT JOIN tipo_ausentismo on ausentismo.tipo_aus=tipo_ausentismo.tipo_aus " & _
                                            "WHERE ausentismo.reloj= '" & Reloj & "' AND fecha = '" & FechaSQL(Fecha) & "'"
                    dtTemporal = sqlExecute(Q, "TA")
                    If dtTemporal.Rows.Count = 0 Then
                        dtDatos.Rows.Add({Fecha.Month, MesLetra(Fecha), Fecha.Day, Ano, "", -1, -16777216})
                    Else
                        dtDatos.Rows.Add({Fecha.Month, MesLetra(Fecha), Fecha.Day, Ano, _
                                          IIf(IsDBNull(dtTemporal.Rows(0).Item("tipo_aus")), "FI", dtTemporal.Rows(0).Item("tipo_aus")), _
                                          IIf(IsDBNull(dtTemporal.Rows(0).Item("color_back")), -1, dtTemporal.Rows(0).Item("color_back")), _
                                          IIf(IsDBNull(dtTemporal.Rows(0).Item("color_letra")), -16777216, dtTemporal.Rows(0).Item("color_letra"))})
                    End If

                    '=====Vacaciones programadas
                    Q = "select reloj,fecha from vacs_prog where isnull(APLICADO,0)=0 and reloj='" & Reloj & "' and fecha='" & FechaSQL(Fecha) & "'"
                    Dim dtVacsProg As New DataTable
                    dtVacsProg = sqlExecute(Q, "PERSONAL")
                    If Not dtVacsProg.Columns.Contains("Error") And dtVacsProg.Rows.Count > 0 Then

                        '===Si existe ya un registro en esa fecha que este en blanco, eliminarlo para que agregue la vacación programada
                        If dtDatos.Select("detalle='' and color_back=-1 and numMes=" & Fecha.Month & " and mes='" & MesLetra(Fecha) & "' and dia=" & Fecha.Day & " and año='" & Ano & "'").Count > 0 Then
                            Dim dElimina() As DataRow
                            dElimina = dtDatos.Select("detalle='' and color_back=-1 and numMes=" & Fecha.Month & " and mes='" & MesLetra(Fecha) & "' and dia=" & Fecha.Day & " and año='" & Ano & "'")
                            For Each dEl As DataRow In dElimina
                                dtDatos.Rows.Remove(dEl)
                            Next
                        End If

                        dtDatos.Rows.Add({Fecha.Month, MesLetra(Fecha), Fecha.Day, Ano, "VAP", -256, -16777216})
                    End If

                End If
                Fecha = DateAdd(DateInterval.Day, 1, Fecha)
            Loop
            Debug.Print("Terminado")
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    'Agregue este metodo de FaltasInjustificadas para Segregar los registro que tienen tipo_aus como  "FI" *******************CARLOS************************************
    Public Sub FaltasInjustificadas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos = dtInformacion.Clone
        For Each row As DataRow In dtInformacion.Rows
            If row.Item("tipo_aus").ToString.Trim.Equals("FI") Then
                dtDatos.ImportRow(row)
            End If
        Next
    End Sub
    Public Sub ConteoFaltasInjustificadas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim relojito As String = "XXXXX"
        Dim dtTemp As DataTable
        Dim fr As New frmRangoFechas
        fr.frmRangoFechas_fecha_ini = Date.Now.AddDays(-30)
        fr.frmRangoFechas_fecha_fin = Date.Now
        fr.ShowDialog()
        Try


            Dim q As String = "select " & _
            "count(0) as 'Faltas'," & _
            "AusentismoVW.reloj, AusentismoVW.NOMBRE," & _
            "personalvw.nombres, personalvw.nombre_depto, personalvw.nombre_turno," & _
            "'01-01-1900' as FECHA_INI,'01-02-1900' as FECHA_FIN " & _
            "from AusentismoVW " & _
            "LEFT JOIN PERSONAL.dbo.PersonalVW " & _
            "on AusentismoVW.reloj = personalvw.reloj " & _
            "Where AusentismoVW.FECHA BETWEEN '01-01-1900' and '01-02-1900' and AusentismoVW.TIPO_AUS = 'FI' " & _
            "GROUP BY AusentismoVW.reloj,AusentismoVW.NOMBRE," & _
            "personalvw.nombres, personalvw.nombre_depto, personalvw.nombre_turno " & _
            "ORDER BY faltas desc"
            dtDatos = sqlExecute(q, "TA")
            For Each r As DataRow In dtInformacion.Rows
                If relojito <> r.Item("reloj") Then
                    relojito = r.Item("reloj")
                    q = "select top 1 " & _
               "count(0) as 'Faltas'," & _
               "AusentismoVW.reloj, AusentismoVW.NOMBRE," & _
               "personalvw.nombres, personalvw.nombre_depto, personalvw.nombre_turno," & _
               "'" + FechaSQL(FechaInicial) + "' as FECHA_INI,'" + FechaSQL(FechaFinal) + "' as FECHA_FIN " & _
               "from AusentismoVW " & _
               "LEFT JOIN PERSONAL.dbo.PersonalVW " & _
               "on AusentismoVW.reloj = personalvw.reloj " & _
               "Where AusentismoVW.FECHA BETWEEN '" + FechaSQL(FechaInicial) + "' and '" + FechaSQL(FechaFinal) + "' and AusentismoVW.TIPO_AUS = 'FI' and AusentismoVW.reloj = '" + r.Item("reloj") + "'" & _
               "GROUP BY AusentismoVW.reloj,AusentismoVW.NOMBRE," & _
               "personalvw.nombres, personalvw.nombre_depto, personalvw.nombre_turno " & _
               "ORDER BY faltas desc"
                    dtTemp = sqlExecute(q, "ta")
                    For Each o As DataRow In dtTemp.Rows
                        dtDatos.ImportRow(o)
                    Next
                End If

            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub
    Public Sub ReporteAsistencia(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtAsist As New DataTable
            Dim dtCiasTA As New DataTable
            Dim dtTemp As DataTable
            Dim relojito As String = "xt912"
            Dim fr As New frmRangoFechas
            fr.frmRangoFechas_fecha_ini = Date.Now
            fr.frmRangoFechas_fecha_fin = Date.Now
            fr.ShowDialog()
            Dim query As String = "SELECT " & _
            "TAVW.reloj,TAVW.COD_DEPTO, TAVW.COD_TURNO, TAVW.COD_HORA, TAVW.NOMBRE_DEPTO, TAVW.FECHA_ENTRO" & _
            ",IIF(TAVW.BAJA BETWEEN '2015-03-23' and  '2015-03-23',1,0) AS RENUNCIAS" & _
            ",IIF((TAVW.FECHA_ENTRO BETWEEN '2015-03-23' and  '2015-03-23') and (TAVW.TIPO_AUS IS NULL),1,0) AS ASISTENCIAS" & _
            ",IIF((DATEDIFF(DAY, TAVW.ALTA, '2015-03-23')>30) and (TAVW.FECHA_ENTRO BETWEEN '2015-03-23' and  '2015-03-23'),1,0) as PERMANENTES" & _
            ",IIF((DATEDIFF(DAY, TAVW.ALTA, '2015-03-23')<=30) and (TAVW.FECHA_ENTRO BETWEEN '2015-03-23' and  '2015-03-23'),1,0) as TEMPORALES" & _
            ",'2015-03-23' as Fecha " & _
            "FROM tAVW " & _
            "where tavw.reloj = 'xt912' " & _
            "ORDER BY tavw.reloj desc"
            dtDatos = sqlExecute(query, "TA")
            For Each r As DataRow In dtInformacion.Rows

                If relojito <> r.Item("reloj") Then
                    relojito = r.Item("reloj")


                    query = "SELECT " & _
                    "TAVW.reloj,TAVW.COD_DEPTO, TAVW.COD_TURNO, TAVW.COD_HORA, TAVW.NOMBRE_DEPTO, TAVW.FECHA_ENTRO" & _
                    ",IIF(TAVW.BAJA BETWEEN '" + FechaSQL(FechaFinal) + "' and  '" + FechaSQL(FechaFinal) + "',1,0) AS RENUNCIAS" & _
                    ",IIF((TAVW.FECHA_ENTRO BETWEEN '" + FechaSQL(FechaFinal) + "' and  '" + FechaSQL(FechaFinal) + "') and (TAVW.TIPO_AUS IS NULL),1,0) AS ASISTENCIAS" & _
                    ",IIF((DATEDIFF(DAY, TAVW.ALTA, '" + FechaSQL(FechaFinal) + "')>30) and (TAVW.FECHA_ENTRO BETWEEN '" + FechaSQL(FechaFinal) + "' and  '" + FechaSQL(FechaFinal) + "'),1,0) as PERMANENTES" & _
                    ",IIF((DATEDIFF(DAY, TAVW.ALTA, '" + FechaSQL(FechaFinal) + "')<=30) and (TAVW.FECHA_ENTRO BETWEEN '" + FechaSQL(FechaFinal) + "' and  '" + FechaSQL(FechaFinal) + "'),1,0) as TEMPORALES" & _
                    ",'" + FechaSQL(FechaFinal) + "' as Fecha " & _
                    "FROM tAVW " & _
                    "where tavw.reloj = '" + r.Item("reloj").ToString + "' " & _
                    "ORDER BY tavw.reloj desc"
                    My.Application.DoEvents()
                    dtTemp = sqlExecute(query, "ta")
                    For Each o As DataRow In dtTemp.Rows
                        dtDatos.ImportRow(o)
                    Next
                End If

            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub PrenominaAdmva(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            Dim Depto As String
            Dim dtAuxiliar As New DataTable

            dtDatos = New DataTable

            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("COD_TURNO")
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            Dim dr As DataRow
            For Each dRow As DataRow In dtInformacion.Select("checa_tarjeta IS NULL OR checa_tarjeta = 0")
                'Buscar si ya existe el número de reloj en dtDatos, si no, lo agrega
                dr = dtDatos.Rows.Find({dRow("reloj")})
                If IsNothing(dr) Then
                    dtAuxiliar = sqlExecute("SELECT contenido FROM detalle_auxiliares WHERE campo = 'DEPTO_PREN' AND reloj = '" & dRow("reloj") & "'")
                    If dtAuxiliar.Rows.Count > 0 Then
                        Depto = IIf(IsDBNull(dtAuxiliar.Rows(0).Item("contenido")), "", dtAuxiliar.Rows(0).Item("contenido"))
                    Else
                        Depto = IIf(IsDBNull(dRow("cod_depto")), "", dRow("cod_depto"))
                    End If

                    dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), Depto, dRow("cod_turno")})
                End If
            Next

            Debug.Print("Terminado")
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub ListaAsistencia(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtAsist As New DataTable
            Dim dtCiasTA As New DataTable

            Dim Asist As Boolean

            Dim fr As New frmGrupo
            fr.ShowDialog()
            'La forma regresa un DataRow llamado drGrupo, que contiene la información sobre el grupo seleccionado
            If drGrupo Is Nothing Then
                Exit Sub
            End If

            dtInformacion.Columns.Add("ASISTENCIA", GetType(System.Int16))
            dtInformacion.Columns.Add("INASISTENCIA", GetType(System.Int16))
            dtInformacion.Columns.Add("TOTAL", GetType(System.Int16))
            dtInformacion.Columns.Add("GRUPO")
            dtInformacion.Columns.Add("NOMBRE_GRUPO")
            dtInformacion.Columns.Add("TIPO_GRUPO")

            For Each dRow As DataRow In dtInformacion.Rows
                Try
                    Dim fecha As String = FechaSQL(dRow("fecha_entro"))
                    dtAsist = sqlExecute("SELECT entro, tipo_aus FROM asist WHERE fecha_entro = '" & fecha & "' AND reloj = '" & dRow("reloj") & "'", "TA")
                    If dtAsist.Rows.Count = 0 Then
                        dRow("INASISTENCIA") = 1
                        dRow("ASISTENCIA") = 0
                    Else
                        'Si la hora de entrada está en blanco, o es nulo, no es asistencia

                        Asist = IIf(IsDBNull(dtAsist.Rows(0).Item("entro")), False, IIf(dtAsist.Rows(0).Item("entro").ToString.Trim = "", False, True))
                        dRow("ASISTENCIA") = IIf(Asist, 1, 0)
                        dRow("INASISTENCIA") = IIf(Asist, 0, 1)
                    End If
                    dRow("total") = dRow("ASISTENCIA") + dRow("INASISTENCIA")
                    dRow("grupo") = dRow(drGrupo("grupo"))
                    dRow("nombre_grupo") = dRow(drGrupo("nombre_grupo"))
                    dRow("tipo_grupo") = drGrupo("tipo_grupo")
                Catch ex As Exception

                End Try

            Next

            dtDatos = dtInformacion.Copy

            'ExportaExcel(dtDatos.Select("cod_hora = 'B2'").CopyToDataTable, "C:\Users\PIDA-PC\Desktop\prueba_lista.txt")

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    'Public Sub AsistenciaSemanal(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable, ByVal NombreDataSet As String)
    '    Try
    '        Dim dtAsist As New DataTable
    '        Dim dtCiasTA As New DataTable
    '        Dim F As Date
    '        Dim FI As Date
    '        Dim FF As Date
    '        Dim M As String
    '        Dim D As Integer
    '        Dim x As Integer
    '        Dim P As Integer
    '        Dim Asist As Boolean
    '        Static PeriodoSeleccionado As Boolean = False
    '        Dim NoFoto As String = ""


    '        If Not PeriodoSeleccionado Then
    '            Dim frPer As New frmSeleccionaPeriodo

    '            frPer.ShowDialog()
    '            PeriodoSeleccionado = True

    '            If Periodo Is Nothing Then
    '                Exit Sub
    '            End If
    '        End If

    '        If NombreDataSet = "Calendario_COD" Then
    '            'Si el DataSet es calendario, formar el calendario para el periodo seleccionado
    '            dtDatos.Columns.Add("Periodo")
    '            dtDatos.Columns.Add("Mes")
    '            For x = 1 To 42
    '                dtDatos.Columns.Add("Dia" & x)
    '            Next

    '            For x = 1 To 6
    '                dtDatos.Columns.Add("Sem" & x)
    '            Next

    '            dtTemp = sqlExecute("SELECT fecha_ini,fecha_fin FROM periodos WHERE periodo = '" & Periodo & "' and ano = '" & Ano & "'", "TA")
    '            F = dtTemp.Rows(0).Item("fecha_fin")

    '            If F.Day <= 3 Then
    '                'Si el día es menor o igual a 3, considerar la fecha de inicio, pues la fecha final ya es del siguiente mes
    '                F = dtTemp.Rows(0).Item("fecha_ini")
    '            End If

    '            'Obtener el primer día del mes
    '            FI = DateSerial(F.Year, F.Month, 1)
    '            'Obtener el último día del mes, tomando el primer día, sumando un mes, y restando un día
    '            FF = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateSerial(F.Year, F.Month, 1)))


    '            M = MesLetra(F) & "/" & F.Year
    '            P = ObtenerPeriodo(FI)
    '            'Insertar un registro, conteniendo Mes/Año, para luego agregar el resto de las columnas
    '            dtDatos.Rows.Add({Periodo, M})

    '            'Insertar los periodos, a partir del periodo incial del mes
    '            For x = 1 To 6
    '                dtDatos.Rows(0).Item("Sem" & x) = P
    '                P = P + 1
    '            Next

    '            'Agregar los días del mes, a partir del día de la semana que sea el primer día del mes
    '            D = FI.DayOfWeek
    '            'Si el primer día es domingo, debe ser 7, pues iniciamos en lunes
    '            If D = 0 Then D = 7

    '            For x = 1 To FF.Day
    '                dtDatos.Rows(0).Item("Dia" & D) = x
    '                D = D + 1
    '            Next

    '        ElseIf NombreDataSet = "Datos_COD" Then
    '            'sqlExecute("SELECT RELOJ,NOMBRES,'C:\PIDA\PIDA NET\Personal\Personal\Fotos\04076.jpg' AS FOTO,'P' AS LUNES,'' AS MARTES,'' AS MIERCOLES,'P' AS JUEVES,'' AS VIERNES,'P' AS SABADO,'' AS DOMINGO,'2013-06-10' AS FECHA_INI,'2013-06-13' AS FECHA_FIN,COD_SUPER,NOMBRE_SUPER,'C:\PIDA\PIDA NET\Personal\Personal\Fotos\nofoto.png' AS FOTO_SUPER FROM personal.dbo.PERSONALVW WHERE BAJA IS NULL AND COD_TURNO = '2'", dtDatos)

    '            'Definir lista de campos para el datatable
    '            dtDatos.Columns.Add("RELOJ")
    '            dtDatos.Columns.Add("NOMBRES")
    '            dtDatos.Columns.Add("FOTO")
    '            dtDatos.Columns.Add("COD_SUPER")
    '            dtDatos.Columns.Add("NOMBRE_SUPER")
    '            dtDatos.Columns.Add("FOTO_SUPER")
    '            dtDatos.Columns.Add("LUNES")
    '            dtDatos.Columns.Add("MARTES")
    '            dtDatos.Columns.Add("MIERCOLES")
    '            dtDatos.Columns.Add("JUEVES")
    '            dtDatos.Columns.Add("VIERNES")
    '            dtDatos.Columns.Add("SABADO")
    '            dtDatos.Columns.Add("DOMINGO")

    '            'Si se canceló selección de periodo, salir del procedimiento
    '            If Periodo = Nothing Then
    '                Exit Sub
    '            End If

    '            'Obtener rango de fechas de acuerdo al periodo
    '            dtTemp = sqlExecute("SELECT fecha_ini,fecha_fin FROM periodos WHERE periodo = '" & Periodo & "' and ano = '" & Ano & "'", "TA")
    '            FI = dtTemp.Rows(0).Item("fecha_ini")
    '            FF = dtTemp.Rows(0).Item("fecha_fin")

    '            Try
    '                'Direccionamiento de imagen para cuando no hay fotografía
    '                NoFoto = PathFoto & "nofoto.png"

    '            Catch ex As Exception
    '                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "TA", ex.HResult, ex.Message)
    '            End Try

    '            'sqlExecute("SELECT cod_super,foto FROM super LEFT JOIN personalvw ON personalVW.reloj = super.reloj ", dtTemp)
    '            'dtTemp.PrimaryKey = New DataColumn() {dtTemp.Columns("cod_super")}

    '            x = 0
    '            'Para cada registro en el DataTable dado
    '            For Each dRow As DataRow In dtInformacion.Rows
    '                'Insertar campos desde dtInformacion
    '                dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), dRow("foto"), dRow("cod_super"), dRow("nombre_super")})

    '                ''Buscar foto del supervisor, de acuerdo al número de reloj en tabla super
    '                dtTemp = sqlExecute("SELECT foto FROM personalvw LEFT JOIN super ON personalVW.reloj = super.reloj WHERE super.cod_super = '" & dRow("cod_super") & "'")
    '                If dtTemp.Rows.Count = 0 Then
    '                    dtDatos.Rows(x).Item("foto_super") = NoFoto
    '                Else
    '                    dtDatos.Rows(x).Item("foto_super") = IIf(IsDBNull(dtTemp.Rows(0).Item("foto")), NoFoto, dtTemp.Rows(0).Item("foto"))
    '                End If

    '                F = FI
    '                Do While F <= FF
    '                    dtAsist = sqlExecute("SELECT entro FROM asist WHERE fecha_entro = '" & FechaSQL(F) & "' AND reloj = '" & dRow("reloj") & "'", "TA")
    '                    If dtAsist.Rows.Count = 0 Then
    '                        Asist = False
    '                    Else
    '                        'Si la hora de entrada está en blanco, o es nulo, no es asistencia
    '                        Asist = IIf(IsDBNull(dtAsist.Rows(0).Item("entro")), 0, IIf(dtAsist.Rows(0).Item("entro") = "", 0, 1)) = 1
    '                    End If

    '                    'Llenar los días de la semana con asistencia
    '                    'En caso de asistencia, poner P, para que con el tipo de letra Webdings 2 aparezca la palomita
    '                    D = F.DayOfWeek

    '                    Select Case D
    '                        Case 0
    '                            'Domingo
    '                            dtDatos.Rows(x).Item("domingo") = IIf(Asist, "P", "")
    '                        Case 1
    '                            'Lunes
    '                            dtDatos.Rows(x).Item("Lunes") = IIf(Asist, "P", "")
    '                        Case 2
    '                            'Martes
    '                            dtDatos.Rows(x).Item("Martes") = IIf(Asist, "P", "")
    '                        Case 3
    '                            'Miércoels
    '                            dtDatos.Rows(x).Item("miercoles") = IIf(Asist, "P", "")
    '                        Case 4
    '                            'Jueves
    '                            dtDatos.Rows(x).Item("Jueves") = IIf(Asist, "P", "")
    '                        Case 5
    '                            'Viernes
    '                            dtDatos.Rows(x).Item("Viernes") = IIf(Asist, "P", "")
    '                        Case 6
    '                            'Sábado
    '                            dtDatos.Rows(x).Item("Sabado") = IIf(Asist, "P", "")
    '                    End Select

    '                    F = DateAdd(DateInterval.Day, 1, F)
    '                Loop
    '                x += 1

    '            Next

    '        End If


    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
    '        Stop
    '    End Try
    'End Sub
    Public Sub AusentismoPorGrupo(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtAsist As New DataTable
            Dim dtCiasTA As New DataTable

            Dim fr As New frmGrupo
            fr.ShowDialog()

            'La forma regresa un DataRow llamado drGrupo, que contiene la información sobre el grupo seleccionado
            If drGrupo Is Nothing Then
                Exit Sub
            End If

            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("COD_TURNO")
            dtDatos.Columns.Add("cod_hora")
            dtDatos.Columns.Add("FECHA", GetType(System.DateTime))
            dtDatos.Columns.Add("TIPO_AUS")
            dtDatos.Columns.Add("NOMBRE_AUS")
            dtDatos.Columns.Add("DIAS", GetType(System.Int16))
            dtDatos.Columns.Add("GRUPO")
            dtDatos.Columns.Add("NOMBRE_GRUPO")
            dtDatos.Columns.Add("TIPO_GRUPO")
            dtDatos.Columns.Add("REFERENCIA")

            Dim Grupo As String
            Dim NombreGrupo As String
            Dim TipoGrupo As String

            TipoGrupo = drGrupo("tipo_grupo")
            For Each dRow As DataRow In dtInformacion.Select("tipo_aus IS NOT NULL AND tipo_aus <> ''")
                Grupo = dRow(drGrupo("grupo"))
                NombreGrupo = IIf(IsDBNull(dRow(drGrupo("nombre_grupo"))), "", dRow(drGrupo("nombre_grupo")))
                dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), dRow("cod_turno"), dRow("cod_hora"), dRow("fha_ent_hor"), dRow("tipo_aus"), dRow("nombre_aus"), 1, Grupo, NombreGrupo, TipoGrupo, dRow("referencia")})
            Next
        Catch ex As Exception
            Stop
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub


    Public Sub ExportaIncapacidades(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtAsist As New DataTable
            Dim dtCiasTA As New DataTable
            Dim dr As DataRow
            Dim Ref As String
            Dim GuardaArchivo As Boolean
            Dim strFileName As String = ""

            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("COD_TURNO")
            dtDatos.Columns.Add("FECHA", GetType(System.DateTime))
            dtDatos.Columns.Add("TIPO_AUS")
            dtDatos.Columns.Add("NOMBRE_AUS")
            dtDatos.Columns.Add("DIAS", GetType(System.Int16))
            dtDatos.Columns.Add("REFERENCIA")
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("RELOJ"), dtDatos.Columns("REFERENCIA")}

            For Each dRow As DataRow In dtInformacion.Select("tipo_naturaleza='I'")
                Ref = IIf(IsDBNull(dRow("referencia")), "SIN REF.", dRow("referencia"))
                dr = dtDatos.Rows.Find({dRow("RELOJ"), Ref})
                If IsNothing(dr) Then
                    dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), dRow("cod_turno"), dRow("fha_ent_hor"), dRow("tipo_aus"), dRow("nombre_aus"), 1, Ref})
                Else
                    dr("DIAS") += 1
                End If
            Next

            Dim oWrite As System.IO.StreamWriter
            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

            PreguntaArchivo.Filter = "Text file|*.txt"
            PreguntaArchivo.FileName = dtInformacion.Rows(0).Item("cod_comp") & "incapacidades"
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            End If
            Try
                oWrite = File.CreateText(strFileName)
                GuardaArchivo = True
            Catch ex As Exception
                oWrite = Nothing
                GuardaArchivo = False
            End Try

            For Each dRow As DataRow In dtDatos.Rows
                If GuardaArchivo Then

                    oWrite.WriteLine(dRow("reloj").ToString.Trim.PadRight(5) & _
                                     Space(1) & _
                                     dRow("referencia").ToString.Trim.PadRight(8) & _
                                     Space(1) & _
                                     DatePart(DateInterval.Year, dRow("fecha")).ToString.Substring(2, 2) & DatePart(DateInterval.Month, dRow("fecha")).ToString.PadLeft(2, "0") & DatePart(DateInterval.Day, dRow("fecha")).ToString.PadLeft(2, "0") & _
                                     Space(1) & _
                                     dRow("dias").ToString.Trim.PadLeft(2, "0") & _
                                     Space(104))

                End If
            Next

            If GuardaArchivo Then
                oWrite.Close()
            End If


        Catch ex As Exception
            Stop
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub


    Public Sub ExportaAusentismo(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtAsist As New DataTable
            Dim dtCiasTA As New DataTable
            Dim dRow As DataRow
            Dim Ref As String
            Dim GuardaArchivo As Boolean
            Dim strFileName As String = ""

            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("COD_TURNO")
            dtDatos.Columns.Add("FECHA", GetType(System.DateTime))
            dtDatos.Columns.Add("TIPO_AUS")
            dtDatos.Columns.Add("NOMBRE_AUS")
            dtDatos.Columns.Add("DIAS", GetType(System.Int16))
            dtDatos.Columns.Add("REFERENCIA")
            dtDatos.Columns.Add("IMSS")

            'dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("RELOJ"), dtDatos.Columns("REFERENCIA")}
            For Each dRow In dtInformacion.Select("afecta_sua = 1")
                Ref = IIf(IsDBNull(dRow("referencia")), "", dRow("referencia"))
                dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), dRow("cod_turno"), dRow("fha_ent_hor"), dRow("tipo_aus"), dRow("nombre_aus"), 1, Ref, dRow("imss")})
            Next

            Dim oWrite As System.IO.StreamWriter
            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

            PreguntaArchivo.Filter = "Text file|*.txt"
            PreguntaArchivo.FileName = dtInformacion.Rows(0).Item("cod_comp") & "ausentismo"
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            End If
            Try
                oWrite = File.CreateText(strFileName)
                GuardaArchivo = True
            Catch ex As Exception
                oWrite = Nothing
                GuardaArchivo = False
            End Try

            For Each dRow In dtDatos.Rows
                If GuardaArchivo Then
                    oWrite.WriteLine(dRow("reloj").ToString.Trim.PadRight(5) & _
                                     DatePart(DateInterval.Year, dRow("fecha")).ToString & DatePart(DateInterval.Month, dRow("fecha")).ToString.PadLeft(2, "0") & DatePart(DateInterval.Day, dRow("fecha")).ToString.PadLeft(2, "0") & _
                                     dRow("tipo_aus").ToString.Trim.PadRight(3) & _
                                     Space(112))
                End If
            Next

            If GuardaArchivo Then
                oWrite.Close()
            End If


        Catch ex As Exception
            Stop
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub AsistenciaPerfectaReporte(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtAusentismo As New DataTable
            Dim drPermisos() As DataRow
            Dim Bono As Boolean
            'Dim fr As New frmFecha
            'fr.ShowDialog()

            'If FechaInicial = Nothing Then
            'Exit Sub
            '  End If

            'FechaFinal = DateAdd(DateInterval.Month, 6, FechaInicial)

            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("NOMBRE_DEPTO")
            dtDatos.Columns.Add("COD_SUPER")
            dtDatos.Columns.Add("NOMBRE_SUPER")

            dtDatos.Columns.Add("COD_PUESTO")
            dtDatos.Columns.Add("NOMBRE_PUESTO")
            dtDatos.Columns.Add("COD_TURNO")
            dtDatos.Columns.Add("ALTA", GetType(System.DateTime))
            dtDatos.Columns.Add("FECHA", GetType(System.DateTime))

            'Este reporte no lo afectan los filtros, se considera todo el personal operativo activo en el rango de 6 meses a partir de la fecha seleccionada, y tenga antig. >= 1
            'dtInformacion = New DataTable
            '    dtInformacion = sqlExecute("SELECT RELOJ,NOMBRES,ALTA,BAJA,COD_TIPO,COD_PUESTO,NOMBRE_PUESTO,COD_DEPTO,NOMBRE_DEPTO,COD_SUPER,NOMBRE_SUPER,COD_TURNO FROM personalVW WHERE sactual <= 136.30 AND cod_tipo = 'O' AND DATEDIFF(y,ALTA,'" & FechaSQL(FechaFinal) & "') >= 1 AND (baja IS NULL OR baja >'" & FechaSQL(FechaFinal) & "') ORDER BY reloj")

            Dim Permisos As Integer

            For Each dRow As DataRow In dtInformacion.Rows
                Bono = True
                'dtAusentismo = sqlExecute("SELECT tipo_aus FROM ausentismoVW WHERE reloj = '" & dRow("reloj") & "' AND fecha BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "' AND afecta_asistencia_perfecta = 1", "TA")
                If dtAusentismo.Rows.Count > 0 Then
                    'Si tuvo ausentismo durante el periodo, revisar permisos sin goce de sueldo
                    drPermisos = dtAusentismo.Select("tipo_aus='P/S'")
                    Permisos = drPermisos.Count
                    If dtAusentismo.Rows.Count > Permisos Then
                        'Si los ausentismos son mayores a los permisos, indica que hubo otro tipo de ausentismo, por lo tanto pierde bono
                        ' Bono = False
                    Else
                        'Si todos los ausentismos fueron permisos, revisar si son menores a 3
                        ' Bono = (Permisos <= 3)
                    End If
                End If

                'Buscar en asist los retardos (que el campo dif_ent inicie con '-', que indica valor negativo, o sea después de su hora de entrada)
                'dtAusentismo = sqlExecute("SELECT dif_ent FROM asist WHERE reloj = '" & dRow("reloj") & "' AND fha_ent_hor BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "' AND dif_ent LIKE '-%'", "TA")
                'Si ya llevaba ganado el bono, y tuvo menos de 10 retardos, gana el bono
                'Bono = Bono And dtAusentismo.Rows.Count <= 10

                If Bono Then
                    dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_super"), dRow("nombre_super"), dRow("cod_puesto"), dRow("nombre_puesto"), dRow("cod_turno"), dRow("alta"), FechaInicial})
                End If
            Next
        Catch ex As Exception
            Stop
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub AsistenciaPerfectaSecundaria(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal NombreDataSet As String)
        Try
            Static dtAusentismo As New DataTable
            Dim drPermisos() As DataRow
            Dim Bono As Boolean
            Static TieneFecha As Boolean = False

            'If Not TieneFecha Then
            'Solo debe preguntar la fecha una vez
            Dim fr As New frmFecha
            fr.ShowDialog()
            TieneFecha = True

            If FechaInicial = Nothing Then
                Exit Sub
            End If
            FechaFinal = DateAdd(DateInterval.Month, 6, FechaInicial)
            'End If

            'Si el dataset es Datos_COD, llenar los datos de los que ganan el bono
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("NOMBRE_DEPTO")
            dtDatos.Columns.Add("COD_SUPER")
            dtDatos.Columns.Add("NOMBRE_SUPER")

            dtDatos.Columns.Add("COD_PUESTO")
            dtDatos.Columns.Add("NOMBRE_PUESTO")
            dtDatos.Columns.Add("COD_TURNO")
            dtDatos.Columns.Add("ALTA", GetType(System.DateTime))
            dtDatos.Columns.Add("FECHA", GetType(System.DateTime))
            dtDatos.Columns.Add("TIPO_AUS")
            dtDatos.Columns.Add("NOMBRE_AUS")
            dtDatos.Columns.Add("DIAS")

            'Este reporte no lo afectan los filtros, se considera todo el personal operativo activo en el rango de 6 meses a partir de la fecha seleccionada, y tenga antig. >= 1
            dtInformacion = New DataTable
            dtInformacion = sqlExecute("SELECT RELOJ,NOMBRES,ALTA,BAJA,COD_TIPO,COD_PUESTO,NOMBRE_PUESTO,COD_DEPTO,NOMBRE_DEPTO,COD_SUPER,NOMBRE_SUPER,COD_TURNO,MAX_ESCOLARIDAD FROM personalVW WHERE sactual <= 136.30 AND cod_tipo = 'O' AND DATEDIFF(y,ALTA,'" & FechaSQL(FechaFinal) & "') >= 1 AND (baja IS NULL OR baja >'" & FechaSQL(FechaFinal) & "') ORDER BY reloj")

            Dim Permisos As Integer

            For Each dRow As DataRow In dtInformacion.Rows
                Bono = True
                If Val(IIf(IsDBNull(dRow("max_escolaridad")), 0, dRow("max_escolaridad"))) < 2 Then
                    'Si el nivel máximo de estudios es menor a 2, no tiene secundaria, así que no gana bono
                    dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("cod_puesto"), dRow("nombre_depto"), dRow("cod_super"), dRow("nombre_super"), dRow("nombre_puesto"), dRow("cod_turno"), dRow("alta"), FechaInicial, "ESC", "Escolaridad", 1})
                    Bono = False
                End If

                dtAusentismo = sqlExecute("SELECT tipo_aus,nombre FROM ausentismoVW WHERE reloj = '" & dRow("reloj") & "' AND fecha BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "' AND afecta_asistencia_perfecta = 1", "TA")
                If dtAusentismo.Rows.Count > 0 Then
                    'Si tuvo ausentismo durante el periodo, revisar permisos sin goce de sueldo
                    drPermisos = dtAusentismo.Select("tipo_aus='P/S'")
                    Permisos = drPermisos.Count
                    If dtAusentismo.Rows.Count > Permisos Then
                        'Si los ausentismos son mayores a los permisos, indica que hubo otro tipo de ausentismo, por lo tanto pierde bono
                        Bono = False
                        For Each DR As DataRow In dtAusentismo.Rows
                            dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_super"), dRow("nombre_super"), dRow("cod_puesto"), dRow("nombre_puesto"), dRow("cod_turno"), dRow("alta"), FechaInicial, DR("tipo_aus"), DR("nombre"), 1})
                        Next
                    Else
                        'Si todos los ausentismos fueron permisos, revisar si son menores a 3
                        Bono = (Permisos <= 3)
                    End If
                End If

                'Buscar en asist los retardos (que el campo dif_ent inicie con '-', que indica valor negativo, o sea después de su hora de entrada)
                dtAusentismo = sqlExecute("SELECT dif_ent FROM asist WHERE reloj = '" & dRow("reloj") & "' AND fha_ent_hor BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "' AND dif_ent LIKE '-%'", "TA")
                If dtAusentismo.Rows.Count > 10 Then
                    'Si tiene más de 10 ausentismos, insertar razón para no bono
                    dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_super"), dRow("nombre_super"), dRow("cod_puesto"), dRow("nombre_puesto"), dRow("cod_turno"), dRow("alta"), FechaInicial, "RET", "Retardo", dtAusentismo.Rows.Count})
                End If
                'Si ya llevaba ganado el bono, y tuvo menos de 10 retardos, gana el bono
                Bono = Bono And dtAusentismo.Rows.Count <= 10

                If Bono Then
                    dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_super"), dRow("nombre_super"), dRow("cod_puesto"), dRow("nombre_puesto"), dRow("cod_turno"), dRow("alta"), FechaInicial, "NO"})
                End If
            Next

        Catch ex As Exception
            Stop
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub TiempoExtra(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("NOMBRE_DEPTO")
            dtDatos.Columns.Add("OPERACION")
            dtDatos.Columns.Add("PRENSA")
            dtDatos.Columns.Add("GRUPO")
            dtDatos.Columns.Add("NOMBRE_GRUPO")
            dtDatos.Columns.Add("TIPO_GRUPO")
            dtDatos.Columns.Add("LUNES", GetType(System.Double))
            dtDatos.Columns.Add("MARTES", GetType(System.Double))
            dtDatos.Columns.Add("MIERCOLES", GetType(System.Double))
            dtDatos.Columns.Add("JUEVES", GetType(System.Double))
            dtDatos.Columns.Add("VIERNES", GetType(System.Double))
            dtDatos.Columns.Add("SABADO", GetType(System.Double))
            dtDatos.Columns.Add("DOMINGO", GetType(System.Double))
            dtDatos.Columns.Add("NORMALES", GetType(System.Double))
            dtDatos.Columns.Add("EXTRAS", GetType(System.Double))
            dtDatos.Columns.Add("DOBLES", GetType(System.Double))
            dtDatos.Columns.Add("TRIPLES", GetType(System.Double))
            dtDatos.Columns.Add("COSTO", GetType(System.Double))

            Dim fr As New frmGrupo
            'Bandera para que incluya los grupos que provienen de auxiliares, como operación, prensa y suboperación
            'Por default, es falso
            GrupoAuxiliares = True
            drGrupo = Nothing
            fr.ShowDialog()
            'Regresar la bandera a falso
            GrupoAuxiliares = False

            'La forma regresa un DataRow llamado drGrupo, que contiene la información sobre el grupo seleccionado
            If drGrupo Is Nothing Then
                Exit Sub
            End If

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("RELOJ")}

            Dim R As String
            Dim Op As String
            Dim Pr As String
            Dim Aux As String
            Dim drDatos As DataRow
            Dim Dia As DayOfWeek
            Dim CostoHora As Double
            For Each dRow As DataRow In dtInformacion.Select("horas_normales <> '00:00' AND horas_extras<> '00:00'")
                R = IIf(IsDBNull(dRow("RELOJ")), "SIN REF.", dRow("RELOJ"))

                drDatos = dtDatos.Rows.Find({R})
                If IsNothing(drDatos) Then
                    dtTemp = sqlExecute("SELECT contenido FROM detalle_auxiliares WHERE campo = 'OPERACION' AND reloj = '" & R & "'")
                    If dtTemp.Rows.Count = 0 Then
                        Op = ""
                    Else
                        Op = IIf(IsDBNull(dtTemp.Rows(0).Item("contenido")), "", dtTemp.Rows(0).Item("contenido"))
                    End If
                    dtTemp = sqlExecute("SELECT contenido FROM detalle_auxiliares WHERE campo = 'PRENSA' AND reloj = '" & R & "'")
                    If dtTemp.Rows.Count = 0 Then
                        Pr = ""
                    Else
                        Pr = IIf(IsDBNull(dtTemp.Rows(0).Item("contenido")), "", dtTemp.Rows(0).Item("contenido"))
                    End If
                    CostoHora = (dRow("sactual") * 6) / dRow("horas_turno")
                    dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), Op, Pr, "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0})

                    drDatos = dtDatos.Rows.Find({R})
                    'Insertar campos semanales
                    drDatos("dobles") = Math.Round(dRow("hrs_dobles"), 2)
                    drDatos("triples") = Math.Round(dRow("hrs_triple"), 2)
                    drDatos("costo") = Math.Round((drDatos("dobles") * 2 * CostoHora) + (drDatos("triples") * 3 * CostoHora), 2)

                    'Ya que el dtInformacion no incluye auxiliares
                    'Si el grupo seleccionado uno de ellos, obtener el dato de los auxiliares
                    If drGrupo("grupo") = "SUB_OP" Then
                        dtTemp = sqlExecute("SELECT contenido FROM detalle_auxiliares WHERE campo = 'SUB_OP' AND reloj = '" & R & "'")
                        If dtTemp.Rows.Count = 0 Then
                            Aux = ""
                        Else
                            Aux = IIf(IsDBNull(dtTemp.Rows(0).Item("contenido")), "", dtTemp.Rows(0).Item("contenido"))
                        End If
                        drDatos("grupo") = Aux
                        drDatos("nombre_grupo") = Aux
                    ElseIf drGrupo("grupo") = "OPERACION" Then
                        drDatos("grupo") = Op
                        drDatos("nombre_grupo") = Op
                    ElseIf drGrupo("grupo") = "PRENSA" Then
                        dtTemp = sqlExecute("SELECT contenido FROM detalle_auxiliares WHERE campo = 'PRENSA' AND reloj = '" & R & "'")
                        If dtTemp.Rows.Count = 0 Then
                            Aux = ""
                        Else
                            Aux = IIf(IsDBNull(dtTemp.Rows(0).Item("contenido")), "", dtTemp.Rows(0).Item("contenido"))
                        End If
                        drDatos("grupo") = Aux
                        drDatos("nombre_grupo") = Aux
                    Else
                        'Si es cualquier otro grupo, tomarlo del dtInformacion
                        drDatos("grupo") = dRow(drGrupo("grupo"))
                        drDatos("nombre_grupo") = dRow(drGrupo("nombre_grupo"))
                    End If
                    drDatos("tipo_grupo") = drGrupo("tipo_grupo")
                End If
                Dia = DatePart(DateInterval.Weekday, dRow("fecha_entro"))
                Select Case Dia
                    Case DayOfWeek.Monday
                        drDatos("lunes") = Math.Round(drDatos("lunes") + HtoD(dRow("horas_extras")), 2)
                    Case DayOfWeek.Tuesday
                        drDatos("martes") = Math.Round(drDatos("martes") + HtoD(dRow("horas_extras")), 2)
                    Case DayOfWeek.Wednesday
                        drDatos("miercoles") = Math.Round(drDatos("miercoles") + HtoD(dRow("horas_extras")), 2)
                    Case DayOfWeek.Thursday
                        drDatos("jueves") = Math.Round(drDatos("jueves") + HtoD(dRow("horas_extras")), 2)
                    Case DayOfWeek.Friday
                        drDatos("viernes") = Math.Round(drDatos("viernes") + HtoD(dRow("horas_extras")), 2)
                    Case DayOfWeek.Saturday
                        drDatos("sabado") = Math.Round(drDatos("sabado") + HtoD(dRow("horas_extras")), 2)
                    Case DayOfWeek.Sunday
                        drDatos("domingo") = Math.Round(drDatos("domingo") + HtoD(dRow("horas_extras")), 2)
                End Select

                drDatos("normales") = Math.Round(drDatos("normales") + HtoD(dRow("horas_normales")), 2)
                drDatos("extras") = Math.Round(drDatos("extras") + HtoD(dRow("horas_extras")), 2)
            Next


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub


    Public Sub TiempoExtraCostoDiario(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("NOMBRE_DEPTO")
            dtDatos.Columns.Add("OPERACION")
            dtDatos.Columns.Add("PRENSA")
            dtDatos.Columns.Add("LUNES", GetType(System.Double))
            dtDatos.Columns.Add("MARTES", GetType(System.Double))
            dtDatos.Columns.Add("MIERCOLES", GetType(System.Double))
            dtDatos.Columns.Add("JUEVES", GetType(System.Double))
            dtDatos.Columns.Add("VIERNES", GetType(System.Double))
            dtDatos.Columns.Add("SABADO", GetType(System.Double))
            dtDatos.Columns.Add("DOMINGO", GetType(System.Double))
            dtDatos.Columns.Add("NORMALES", GetType(System.Double))
            dtDatos.Columns.Add("EXTRAS", GetType(System.Double))
            dtDatos.Columns.Add("DOBLES", GetType(System.Double))
            dtDatos.Columns.Add("TRIPLES", GetType(System.Double))
            dtDatos.Columns.Add("COSTO", GetType(System.Double))

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("RELOJ")}

            Dim R As String
            Dim Op As String
            Dim Pr As String
            Dim drDatos As DataRow
            Dim Dia As DayOfWeek
            Dim CostoHora As Double
            For Each dRow As DataRow In dtInformacion.Select("horas_normales <> '00:00' AND horas_extras<> '00:00'")
                R = IIf(IsDBNull(dRow("RELOJ")), "SIN REF.", dRow("RELOJ"))

                drDatos = dtDatos.Rows.Find({R})
                If IsNothing(drDatos) Then
                    dtTemp = sqlExecute("SELECT contenido FROM detalle_auxiliares WHERE campo = 'OPERACION' AND reloj = '" & R & "'")
                    If dtTemp.Rows.Count = 0 Then
                        Op = ""
                    Else
                        Op = IIf(IsDBNull(dtTemp.Rows(0).Item("contenido")), "", dtTemp.Rows(0).Item("contenido"))
                    End If
                    dtTemp = sqlExecute("SELECT contenido FROM detalle_auxiliares WHERE campo = 'PRENSA' AND reloj = '" & R & "'")
                    If dtTemp.Rows.Count = 0 Then
                        Pr = ""
                    Else
                        Pr = IIf(IsDBNull(dtTemp.Rows(0).Item("contenido")), "", dtTemp.Rows(0).Item("contenido"))
                    End If
                    CostoHora = (IIf(IsDBNull(dRow("sactual")), 0, dRow("sactual")) * 6) / IIf(IsDBNull(dRow("horas_turno")), 1, dRow("horas_turno"))
                    dtDatos.Rows.Add({dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), Op, Pr, 0, 0, 0, 0, 0, 0, 0, 0, 0})

                    drDatos = dtDatos.Rows.Find({R})
                    'Insertar campos semanales
                    drDatos("dobles") = Math.Round(dRow("hrs_dobles"), 2)
                    drDatos("triples") = Math.Round(dRow("hrs_triple"), 2)
                    drDatos("costo") = Math.Round((drDatos("dobles") * 2 * CostoHora) + (drDatos("triples") * 3 * CostoHora), 2)
                End If
                Dia = DatePart(DateInterval.Weekday, dRow("fecha_entro"))
                Select Case Dia
                    Case DayOfWeek.Monday
                        drDatos("lunes") = Math.Round(drDatos("lunes") + HtoD(dRow("horas_extras")), 2)
                    Case DayOfWeek.Tuesday
                        drDatos("martes") = Math.Round(drDatos("martes") + HtoD(dRow("horas_extras")), 2)
                    Case DayOfWeek.Wednesday
                        drDatos("miercoles") = Math.Round(drDatos("miercoles") + HtoD(dRow("horas_extras")), 2)
                    Case DayOfWeek.Thursday
                        drDatos("jueves") = Math.Round(drDatos("jueves") + HtoD(dRow("horas_extras")), 2)
                    Case DayOfWeek.Friday
                        drDatos("viernes") = Math.Round(drDatos("viernes") + HtoD(dRow("horas_extras")), 2)
                    Case DayOfWeek.Saturday
                        drDatos("sabado") = Math.Round(drDatos("sabado") + HtoD(dRow("horas_extras")), 2)
                    Case DayOfWeek.Sunday
                        drDatos("domingo") = Math.Round(drDatos("domingo") + HtoD(dRow("horas_extras")), 2)
                End Select

                drDatos("normales") = Math.Round(drDatos("normales") + HtoD(dRow("horas_normales")), 2)
                drDatos("extras") = Math.Round(drDatos("extras") + HtoD(dRow("horas_extras")), 2)
            Next


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub


    Public Sub ProvisionNormalesExtras(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim drDatos As DataRow
            Dim R As String
            Dim Op As String
            Dim CostoHora6 As Double
            Dim CostoHora7 As Double
            Dim DeptoPoliza As String
            Dim PerAnt As String = ""
            Dim Periodos As String = ""
            Dim DoblesCompletas As Boolean
            Dim Extras As Double
            Dim dtPoliza As New DataTable
            Dim dtMovs As New DataTable

            dtMovs.Columns.Add("RELOJ")
            dtMovs.Columns.Add("COD_DEPTO")
            dtMovs.Columns.Add("COD_TIPO")
            dtMovs.Columns.Add("COD_CLASE")
            dtMovs.Columns.Add("CONCEPTO")
            dtMovs.Columns.Add("MONTO", GetType(System.Double))

            dtPoliza.Columns.Add("RELOJ")
            dtPoliza.Columns.Add("COD_CLASE")
            dtPoliza.Columns.Add("COD_DEPTO")
            dtPoliza.Columns.Add("CUENTA")
            dtPoliza.Columns.Add("SUBCUENTA")
            dtPoliza.Columns.Add("NOMBRE_CTA")
            dtPoliza.Columns.Add("CONCEPTO")
            dtPoliza.Columns.Add("DEBE", GetType(System.Double))
            dtPoliza.Columns.Add("HABER", GetType(System.Double))

            dtDatos.Columns.Add("FECHA", GetType(System.DateTime))
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("COD_TIPO")
            dtDatos.Columns.Add("COD_CLASE")
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("NOMBRE_DEPTO")
            dtDatos.Columns.Add("COD_DEPTO_POLIZA")
            dtDatos.Columns.Add("COD_TURNO")
            dtDatos.Columns.Add("OPERACION")
            dtDatos.Columns.Add("COSTO_HORA_7D")
            dtDatos.Columns.Add("COSTO_HORA_6D")
            dtDatos.Columns.Add("PERIODOS") 'Lista de periodos en el reporte
            dtDatos.Columns.Add("ANOPERIODO")  'Periodo para este movimiento
            dtDatos.Columns.Add("NORMAL_EMP", GetType(System.Double))
            dtDatos.Columns.Add("NORMAL_HOR", GetType(System.Double))
            dtDatos.Columns.Add("NORMAL_PRO", GetType(System.Double))
            dtDatos.Columns.Add("NORMAL_COSTO", GetType(System.Double))
            dtDatos.Columns.Add("FESTIVO_EMP", GetType(System.Double))
            dtDatos.Columns.Add("FESTIVO_HOR", GetType(System.Double))
            dtDatos.Columns.Add("FESTIVO_PRO", GetType(System.Double))
            dtDatos.Columns.Add("FESTIVO_COSTO", GetType(System.Double))
            dtDatos.Columns.Add("EXTRAS_EMP", GetType(System.Double))
            dtDatos.Columns.Add("EXTRAS_HOR", GetType(System.Double))
            dtDatos.Columns.Add("EXTRAS_PRO", GetType(System.Double))
            dtDatos.Columns.Add("EXTRAS_COSTO", GetType(System.Double))
            dtDatos.Columns.Add("DOBLES_EMP", GetType(System.Double))
            dtDatos.Columns.Add("DOBLES_HOR", GetType(System.Double))
            dtDatos.Columns.Add("DOBLES_PRO", GetType(System.Double))
            dtDatos.Columns.Add("DOBLES_COSTO", GetType(System.Double))
            dtDatos.Columns.Add("TRIPLES_EMP", GetType(System.Double))
            dtDatos.Columns.Add("TRIPLES_HOR", GetType(System.Double))
            dtDatos.Columns.Add("TRIPLES_PRO", GetType(System.Double))
            dtDatos.Columns.Add("TRIPLES_COSTO", GetType(System.Double))
            dtDatos.Columns.Add("TOTAL_EMP", GetType(System.Double))
            dtDatos.Columns.Add("TOTAL_HOR", GetType(System.Double))
            dtDatos.Columns.Add("TOTAL_PRO", GetType(System.Double))
            dtDatos.Columns.Add("TOTAL_COSTO", GetType(System.Double))
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("RELOJ"), dtDatos.Columns("FECHA")}

            For Each dRow As DataRow In dtInformacion.Select("cod_tipo = 'O' AND horas_normales <> '00:00' AND horas_extras<> '00:00'")
                R = IIf(IsDBNull(dRow("RELOJ")), "SIN REF.", dRow("RELOJ"))

                drDatos = dtDatos.Rows.Find({R, dRow("FHA_ENT_HOR")})
                If IsNothing(drDatos) Then
                    dtTemp = sqlExecute("SELECT contenido FROM detalle_auxiliares WHERE campo = 'OPERACION' AND reloj = '" & R & "'")
                    If dtTemp.Rows.Count = 0 Then
                        Op = ""
                    Else
                        Op = IIf(IsDBNull(dtTemp.Rows(0).Item("contenido")), "", dtTemp.Rows(0).Item("contenido"))
                    End If
                    CostoHora6 = (dRow("sactual") * 6) / dRow("horas_turno")
                    CostoHora7 = (dRow("sactual") * 7) / dRow("horas_turno")
                    DeptoPoliza = "3" & dRow("cod_depto").ToString.Substring(2, 2) & "1"

                    dtDatos.Rows.Add({dRow("fha_ent_hor"), dRow("reloj"), dRow("nombres"), dRow("cod_tipo"), dRow("cod_clase"), dRow("cod_depto"), dRow("nombre_depto"), DeptoPoliza, dRow("cod_turno"), Op, CostoHora6, CostoHora7, "", dRow("ano") & dRow("periodo"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
                    drDatos = dtDatos.Rows.Find({R, dRow("FHA_ENT_HOR")})
                End If
                'Sumar horas normales, festivas y extras diarias
                drDatos("normal_hor") = Math.Round(drDatos("normal_hor") + IIf(Festivo(dRow("fha_ent_hor"), dRow("reloj")), 0, HtoD(dRow("horas_normales"))), 2)
                drDatos("festivo_hor") = Math.Round(drDatos("festivo_hor") + IIf(Festivo(dRow("fha_ent_hor"), dRow("reloj")), 0, HtoD(dRow("horas_normales"))), 2)
                drDatos("extras_hor") = Math.Round(drDatos("extras_hor") + HtoD(dRow("horas_extras")), 2)

                'Si hay cambio de periodo, reiniciar conteo de horas extras
                If PerAnt < dRow("periodo") Then
                    PerAnt = dRow("periodo")
                    Periodos = Periodos & IIf(Periodos = "", "", " - ") & PerAnt
                    DoblesCompletas = False
                    Extras = 0
                End If
                Extras = Extras + HtoD(dRow("horas_extras"))

                'Calcular horas dobles y triples diarias
                If Not DoblesCompletas Then
                    If Extras < 9 Then
                        drDatos("dobles_hor") = drDatos("dobles_hor") + HtoD(dRow("horas_extras"))
                    Else
                        drDatos("dobles_hor") = Extras - 9
                        drDatos("triples_hor") = HtoD(dRow("horas_extras")) - (Extras - 9)
                        DoblesCompletas = True
                    End If
                Else
                    drDatos("triples_hor") = drDatos("triples_hor") + HtoD(dRow("horas_extras"))
                End If
            Next

            For Each dRow In dtDatos.Rows
                dRow("normal_costo") = Math.Round(dRow("normal_hor") * CostoHora7, 2)
                dRow("festivo_costo") = Math.Round(dRow("festivo_hor") * CostoHora7, 2)
                dRow("dobles_costo") = Math.Round(dRow("dobles_hor") * CostoHora6 * 2, 2)
                dRow("triples_costo") = Math.Round(dRow("triples_hor") * CostoHora6 * 3, 2)
                dRow("total_costo") = Math.Round(dRow("normal_costo") + dRow("festivo_costo") + dRow("dobles_costo") + dRow("triples_costo"), 2)
                dRow("total_hor") = Math.Round(dRow("normal_hor") + dRow("festivo_hor") + dRow("dobles_hor") + dRow("triples_hor"), 2)
                dRow("normal_por") = IIf(dRow("total_hor") > 0, ((dRow("normal_hor") + dRow("festivo_hor")) * 100) / dRow("total_hor"), 0)
                dRow("extras_por") = IIf(dRow("total_hor") > 0, ((dRow("extras_hor") + dRow("extras_hor")) * 100) / dRow("extras_hor"), 0)
                dRow("normal_emp") = IIf(dRow("normal_hor") + dRow("festivo_hor") > 0, 1, 0)
                dRow("dobles_emp") = IIf(dRow("dobles_hor") > 0, 1, 0)
                dRow("triples_emp") = IIf(dRow("triples_hor") > 0, 1, 0)
                dRow("total_emp") = IIf(dRow("normal_hor") + dRow("festivo_hor") + dRow("dobles_hor") + dRow("triples_hor") > 0, 1, 0)
                dRow("periodos") = Periodos

                If dRow("normal_costo") > 0 Then
                    dtMovs = sqlExecute("SELECT monto FROM movimientos WHERE concepto = 'PERNOR' AND CONCAT(ano,periodo) = '" & dRow("anoperiodo") & "' AND reloj = '" & dRow("reloj") & "'")
                    If dtMovs.Rows.Count > 0 Then



                    End If
                End If
            Next
        Catch ex As Exception
            dtDatos = New DataTable
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

    End Sub

    Public Sub RetardosAnticipada(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal Nombre As String)
        Try
            Dim Condicion As String
            If Nombre.ToUpper.Contains("RETARDO") Then
                Condicion = "LEFT(DIF_ENT,1)='-'"
            ElseIf Nombre.ToUpper.Contains("SALIDA") Then
                Condicion = "LEFT(DIF_SAL,1)='-'"
            Else
                'Condición falsa para que no regrese registros
                Condicion = "1=3"
            End If

            Dim dtResultadoDatos As New DataSet
            dtResultadoDatos.Merge(dtInformacion.Select(Condicion))

            If dtResultadoDatos.Tables.Count > 0 Then
                dtDatos = dtResultadoDatos.Tables(0)
                dtResultadoDatos.Tables(0).TableName = Nombre
            Else
                'Si no hubo registros, crear la estructura básica para el reporte
                dtDatos.Columns.Add("RELOJ")
                dtDatos.Columns.Add("NOMBRES")
                dtDatos.Columns.Add("COD_TURNO")
                dtDatos.Columns.Add("COD_DEPTO")
                dtDatos.Columns.Add("COD_SUPER")
                dtDatos.Columns.Add("NOMBRE_SUPER")
                dtDatos.Columns.Add("FECHA_ENTRO", GetType(System.DateTime))
                dtDatos.Columns.Add("FECHA_SALIO", GetType(System.DateTime))
                dtDatos.Columns.Add("ENTRO")
                dtDatos.Columns.Add("SALIO")
                dtDatos.Columns.Add("PERMISOS")
                dtDatos.Columns.Add("SAL_PER")
                dtDatos.Columns.Add("ENT_PER")
                dtDatos.Columns.Add("COMENTARIO")
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub Bitacorarelojes(ByRef dtDatos As DataTable)
        'Solicitar rango de fechas
        Dim fr As New frmRangoFechas

        fr.ShowDialog()

        If FechaInicial = Nothing Then
            'Si el rango de fecha está en blanco, salir del procedimiento
            Exit Sub
        End If

        dtDatos = sqlExecute("SELECT RTRIM(TERMINAL) AS TERMINAL,FECHA,HORA,RTRIM(RESULTADO) AS RESULTADO,NUM_TRANS,'" & FechaCortaLetra(FechaInicial) & "' AS FECHA_INI,'" & FechaCortaLetra(FechaFinal) & "' AS FECHA_FIN FROM ta.dbo.bitacora WHERE fecha BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "' ORDER BY FECHA,HORA", "TA")

    End Sub

    Public Sub PersonalSinHoras(ByRef dtDatos As DataTable)
        Try
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("ALTA", GetType(System.DateTime))
            dtDatos.Columns.Add("BAJA", GetType(System.DateTime))
            dtDatos.Columns.Add("COD_TURNO")
            dtDatos.Columns.Add("LUNES")
            dtDatos.Columns.Add("MARTES")
            dtDatos.Columns.Add("MIERCOLES")
            dtDatos.Columns.Add("JUEVES")
            dtDatos.Columns.Add("VIERNES")
            dtDatos.Columns.Add("SABADO")
            dtDatos.Columns.Add("DOMINGO")

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("RELOJ")}

            Dim frPer As New frmSeleccionaPeriodo
            frPer.ShowDialog()
            If Periodo Is Nothing Then
                Exit Sub
            End If

            Dim Archivo As String
            Dim Linea As String
            Dim PreguntaArchivo As New Windows.Forms.OpenFileDialog
            Dim R As String = ""
            Dim DiaSemana(7) As String
            Dim dtPeriodos As New DataTable
            Dim dtAusentismo As New DataTable
            Dim dtNomSem As New DataTable
            Dim FIni As Date
            Dim FFin As Date
            Dim Fecha As Date
            Dim _reloj As String, _nombres As String, _alta As Date, _baja As Date, _turno As String


            dtPeriodos = sqlExecute("SELECT fecha_ini,fecha_fin FROM periodos WHERE ano+periodo = '" & Ano & Periodo & "'", "ta")

            If dtPeriodos.Rows.Count = 0 Then
                Exit Sub
            Else
                FIni = IIf(IsDBNull(dtPeriodos.Rows(0).Item("fecha_ini")), Nothing, dtPeriodos.Rows(0).Item("fecha_ini"))
                FFin = IIf(IsDBNull(dtPeriodos.Rows(0).Item("fecha_fin")), Nothing, dtPeriodos.Rows(0).Item("fecha_fin"))
            End If

            PreguntaArchivo.Filter = "Text file|*.txt"
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            If Not PreguntaArchivo.CheckFileExists Then
                Exit Sub
            End If
            Stop
            Archivo = PreguntaArchivo.FileName
            'Si existe el archivo, abrir para analizar su contenido
            Using sr As New StreamReader(Archivo)
                Linea = ""

                'Buscar la línea que contenga "# EMP", lo que indica el encabezado de las columnas
                Do While Not Linea.Contains("# EMP") And Not sr.EndOfStream
                    Linea = sr.ReadLine
                Loop
                'Si salió del loop por ser fin de archivo, terminar

                If sr.EndOfStream Then
                    Exit Sub

                End If


                Do Until sr.EndOfStream
                    Linea = sr.ReadLine
                    If sr.EndOfStream Then
                        Exit Sub
                    End If
                    If Linea.Length > 50 Then
                        R = Linea.Substring(0, 10).Trim.PadLeft(LongReloj, "0)")

                        'Buscar datos en nomsem y personalvw.
                        dtNomSem = sqlExecute("SELECT nomsem.reloj,nombres,alta,baja,cod_turno FROM nomsem LEFT JOIN personal.dbo.personal ON nomsem.reloj = personalvw.reloj WHERE ano+periodo = '" & Ano & Periodo & "' AND nomsem.reloj = '" & R & "'", "ta")
                        If dtNomSem.Rows.Count > 0 Then
                            _reloj = dtNomSem.Rows(0).Item("reloj")
                            _nombres = dtNomSem.Rows(0).Item("nombres")
                            _alta = IIf(IsDBNull(dtNomSem.Rows(0).Item("alta")), New Date, dtNomSem.Rows(0).Item("alta"))
                            _baja = IIf(IsDBNull(dtNomSem.Rows(0).Item("baja")), New Date, dtNomSem.Rows(0).Item("baja"))
                            _turno = dtNomSem.Rows(0).Item("cod_turno")

                            dtAusentismo = sqlExecute("SELECT tipo_aus,fecha FROM ausentismo WHERE reloj = '" & R & "' AND fecha BETWEEN '" & FechaSQL(FIni) & "' AND '" & FechaSQL(FFin) & "'", "TA")
                            For Each dRow As DataRow In dtAusentismo.Rows
                                Fecha = dRow("fecha")
                                DiaSemana(Fecha.DayOfWeek) = dRow("tipo_aus")
                            Next

                            dtDatos.Rows.Add({_reloj, _nombres, IIf(_alta = New Date, DBNull.Value, _alta), IIf(_baja = New Date, DBNull.Value, _baja), _turno, DiaSemana(1), DiaSemana(2), DiaSemana(3), DiaSemana(4), DiaSemana(5), DiaSemana(6), DiaSemana(0)})
                        End If
                    End If
                Loop

            End Using

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub AsistenciaPerfectaMensual(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            'Ultima modificación: MCR 17/NOV/2015
            'MCR 9/NOV/2015
            'Asistencia perfecta BRP
            'Condiciones:
            '   Solo empleados cod_comp 090 o 093
            '   Que hayan estado activos todo el periodo
            '   Cualquier ajuste, pierde bono
            '   Considerar transferencias
            '   Retardos y salidas anticipadas, pierde bono (excepto en día de descanso)
            '   Si hay ausentismo, revisar si afecta_asistencia_perfecta

            Dim dtAusentismo As New DataTable
            Dim dtTransferencias As New DataTable
            Dim dtInfoTransferencias As New DataTable

            Dim Bono As Boolean
            Dim dEmp As DataRow
            Dim Reloj As String
            Dim RelojAnt As String
            Dim i As Integer = 0
            Dim InicialAlta As Date

            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("RELOJ_ANTERIOR")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("COD_PLANTA")
            dtDatos.Columns.Add("COD_COMP")
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("COD_TURNO")
            dtDatos.Columns.Add("COD_CLASE")
            dtDatos.Columns.Add("ALTA", GetType(System.DateTime))
            dtDatos.Columns.Add("BAJA", GetType(System.DateTime))
            dtDatos.Columns.Add("AUSENTISMOS", GetType(System.Int32))
            dtDatos.Columns.Add("PARCIALES", GetType(System.Int32))
            dtDatos.Columns.Add("AJUSTES", GetType(System.Int32))
            dtDatos.Columns.Add("COMENTARIOS")
            dtDatos.Columns.Add("RESULTADO")
            dtDatos.Columns.Add("RANGO")
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("RELOJ")}

            Dim fr As New frmRangoFechas
            fr.frmRangoFechas_fecha_ini = DateAdd(DateInterval.Month, -1, DateSerial(Now.Year, Now.Month, 1))
            fr.frmRangoFechas_fecha_fin = DateAdd(DateInterval.Day, -1, DateSerial(Now.Year, Now.Month, 1))
            fr.ShowDialog()

            If FechaInicial = Nothing Or FechaFinal = Nothing Then
                Exit Sub
            End If
            Bono = True
            dtInfoTransferencias = dtInformacion.Copy
            dtInfoTransferencias.Columns.Add("RELOJ_ANTERIOR")

            InicialAlta = FechaInicial
            'Para la fecha de alta, no considerar fin de semana
            Do Until InicialAlta.DayOfWeek <> DayOfWeek.Saturday And InicialAlta.DayOfWeek <> DayOfWeek.Sunday
                InicialAlta = DateAdd(DateInterval.Day, 1, InicialAlta)
            Loop
            'Buscar si hay transferencias en el periodo
            dtTransferencias = sqlExecute("SELECT * FROM transferencias WHERE alta BETWEEN '" & FechaSQL(InicialAlta) & _
                                          "' AND '" & FechaSQL(FechaFinal) & "' ORDER BY ALTA DESC")
            For Each dTrans As DataRow In dtTransferencias.Rows
                'A cada transferencia, buscar si hay registros con su número de reloj anterior
                'y actualizar datos al nuevo
                For Each dEmp In dtInfoTransferencias.Select("reloj = '" & dTrans("reloj_anterior") & "'")
                    dEmp("reloj_anterior") = dEmp("reloj")
                    dEmp("reloj") = dTrans("reloj_nuevo")
                    dEmp("baja") = dTrans("baja")
                    dEmp("alta") = dTrans("alta_anterior")
                    dEmp("cod_comp") = dTrans("cod_comp_nuevo")
                Next
            Next

            'Solamente empleados de las compañías 090 y 093
            'que hayan estado activos durante todo el periodo a analizar
            'Si fue transferencia, cuenta la compañía final, con el alta inicial
            For Each dRow As DataRow In dtInfoTransferencias.Select("(cod_comp ='090' or cod_comp = '093') AND " & _
                                                                    "(baja IS NULL OR baja >'" & FechaSQL(FechaFinal) & _
                                                                    "') AND alta<='" & FechaSQL(InicialAlta) & "'" & _
                                                                    "", "reloj,fecha desc")
                Reloj = dRow("reloj")
                RelojAnt = IIf(IsDBNull(dRow("reloj_anterior")), dRow("reloj"), dRow("reloj_anterior"))

                dEmp = dtDatos.Rows.Find(Reloj)
                If dEmp Is Nothing Then
                    dEmp = dtDatos.Rows.Find(RelojAnt)
                    If dEmp Is Nothing Then
                        dEmp = dtDatos.NewRow
                        dEmp("rango") = (FechaLetra(FechaInicial) & " al " & FechaLetra(FechaFinal)).ToUpper
                        dEmp("reloj") = Reloj
                        dEmp("reloj_anterior") = RelojAnt

                        dEmp("alta") = dRow("alta")
                        dEmp("baja") = dRow("baja")

                        dEmp("nombres") = dRow("nombres")
                        dEmp("cod_comp") = dRow("cod_comp")
                        dEmp("cod_depto") = dRow("cod_depto")
                        dEmp("cod_planta") = dRow("cod_planta")
                        dEmp("cod_turno") = dRow("cod_turno")
                        dEmp("cod_clase") = dRow("cod_clase")
                        dtDatos.Rows.Add(dEmp)
                    End If
                End If
            Next

            For Each dEmp In dtDatos.Rows
                Bono = True
                i += 1
                'MCR 12/NOV/2015
                'Integrar bitácora para comparar ajustes
                dtAusentismo = sqlExecute("SELECT asist.tipo_aus,fha_ent_hor,ISNULL(entro,'') AS entro,ISNULL(salio,'') AS salio,comentario," & _
                                          "ISNULL(afecta_asistencia_perfecta,0) AS afecta_asistencia_perfecta, " & _
                                          "ISNULL((select sum(1) FROM " & _
                                            "hrs_brt LEFT JOIN bitacora_hrs_brt " & _
                                                "ON hrs_brt.fecha = bitacora_hrs_brt.fecha  " & _
                                                    "AND hrs_brt.reloj = bitacora_hrs_brt.reloj    " & _
                                                "WHERE hrs_brt.reloj = asist.reloj " & _
                                                    "AND bitacora_hrs_brt.reloj= asist.reloj " & _
                                                    "AND fecha_efva =asist.FHA_ENT_HOR " & _
                                                    "AND hrs_brt.tipo_tran<>'R' " & _
                                                    "AND (bitacora_hrs_brt.hora<>bitacora_hrs_brt.hora_original " & _
                                                        "OR (bitacora_hrs_brt.hora=hora_original and bitacora_hrs_brt.tipo_tran='N'))),0)" & _
                                          "AS ajustes " & _
                                          "FROM asist LEFT JOIN tipo_ausentismo " & _
                                          "ON asist.tipo_aus = tipo_ausentismo.tipo_aus WHERE " & _
                                          "reloj = '" & dEmp("reloj").ToString.Trim & _
                                          "' AND fha_ent_hor BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "'", "TA")

                If dtAusentismo.Rows.Count > 0 Then
                    For Each dRow In dtAusentismo.Rows
                        If IsDBNull(dRow("tipo_aus")) Then
                            'Si no hay ausentismo
                            'Y no hubo algún ajuste
                            If dRow("ajustes") = 0 Then
                                If (dRow("entro") = "" Or dRow("salio") = "") Or _
                                    dRow("comentario").ToString.ToUpper.Contains("RETARDO") Or _
                                    dRow("comentario").ToString.ToUpper.Contains("ANTICIPADA") Then
                                    '... pero falta checada,
                                    'o hubo retardo/salida anticipada
                                    If Not DiaDescanso(dRow("fha_ent_hor"), dEmp("reloj")) Then
                                        ' y no es día de descanso
                                        Bono = False
                                        dEmp("parciales") = IIf(IsDBNull(dEmp("parciales")), 0, dEmp("parciales")) + 1
                                    End If
                                End If
                            Else
                                'Si hubo ajuste, se pierde el bono
                                If Not DiaDescanso(dRow("fha_ent_hor"), dEmp("reloj")) Then
                                    Bono = False
                                    dEmp("ajustes") = IIf(IsDBNull(dEmp("ajustes")), 0, dEmp("ajustes")) + 1
                                End If
                            End If
                        ElseIf dRow("afecta_asistencia_perfecta") = 1 Then
                            'Si hay ausentismo, y afecta al bono, perder el bono
                            Try
                                If dRow("tipo_aus") = "PSG" Then
                                    Dim dtPeriodoCierre As DataTable = sqlExecute("select * from ta.dbo.periodos where '" & FechaSQL(dRow("fha_ent_hor")) & "' between fecha_ini and fecha_fin and periodo_especial = 0 and cierre = 1")
                                    If dtPeriodoCierre.Rows.Count > 0 Then
                                        Bono = True
                                        'dEmp("ausentismos") = IIf(IsDBNull(dEmp("ausentismos")), 0, dEmp("ausentismos")) + 1
                                    Else
                                        Bono = False
                                        dEmp("ausentismos") = IIf(IsDBNull(dEmp("ausentismos")), 0, dEmp("ausentismos")) + 1
                                    End If
                                Else
                                    Bono = False
                                    dEmp("ausentismos") = IIf(IsDBNull(dEmp("ausentismos")), 0, dEmp("ausentismos")) + 1
                                End If
                            Catch ex As Exception
                                Bono = False
                                dEmp("ausentismos") = IIf(IsDBNull(dEmp("ausentismos")), 0, dEmp("ausentismos")) + 1
                            End Try
                        Else
                            'Hay ausentismo, pero no afecta al bono
                        End If

                    Next
                    dEmp("resultado") = IIf(Bono, "GANA", "PIERDE")

                End If
                My.Application.DoEvents()
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub Residencias(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("nombre_depto")
            dtDatos.Columns.Add("hrs_normales")
            dtDatos.Columns.Add("dia_entro")
            dtDatos.Columns.Add("entro")
            dtDatos.Columns.Add("salio")
            dtDatos.Columns.Add("horas")
            dtDatos.Columns.Add("periodo")
            dtDatos.Columns.Add("centro_costos")
            dtDatos.Columns.Add("super")
            dtDatos.Columns.Add("esquema")


            For Each dR In dtInformacion.Select("COD_CLASE = 'P'", "fecha_entro")
                Dim dtesquema As New DataTable
                Dim esquema As String
                Dim reloj As String = dR("reloj")
                dtesquema = sqlExecute("select contenido from detalle_auxiliares where campo = 'ESQ_PRACT' and reloj = '" & dR("reloj") & "'")

                If dtesquema.Rows.Count() > 0 Then
                    Dim drow = dtesquema.Rows(0)
                    esquema = IIf(IsDBNull(drow("contenido")), "", drow("contenido"))

                Else
                    esquema = ""
                End If

                dtDatos.Rows.Add({dR("reloj"), _
                                  Trim(dR("nombres")), _
                                  dR("cod_depto") & "  " & Trim(dR("nombre_depto")), _
                                  Trim(dR("hrs_normales")), _
                                  dR("dia_entro"), _
                                  dR("entro"), _
                                  dR("salio"), _
                                  dR("horas"), _
                                  dR("periodo"), _
                                  dR("centro_costos"), _
                                  dR("nombre_super"), _
                                  esquema
                                 })
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub PrenominaSemanal(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        'Filtrar empleados que no apareceran en el reporte, pero si estan activos
        Dim dtexcepcion As DataTable = sqlExecute("select reloj from personal where inactivo = 2")
        Dim exclusiones As String = ""
        If dtexcepcion.Rows.Count > 0 Then
            For Each row As DataRow In dtexcepcion.Rows
                exclusiones = exclusiones & "'" & row("reloj") & "',"
            Next
            exclusiones = exclusiones.Remove(exclusiones.Length - 1)
        Else
            exclusiones = "0"
        End If

        dtDatos = dtInformacion.Clone
        'For Each dR As DataRow In dtInformacion.Select("(COD_COMP IN ('090','092','093','094','095','096','097','099')) AND RELOJ NOT IN (" & exclusiones & ")", "RELOJ ASC")
        '    dtDatos.ImportRow(dR)
        'Next
        For Each dR As DataRow In dtInformacion.Select("(COD_COMP IN ('610')) AND RELOJ NOT IN (" & exclusiones & ")", "RELOJ ASC")
            dtDatos.ImportRow(dR)
        Next
    End Sub
    Public Sub ExcelAusentismo(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim sfd As New SaveFileDialog
        Try
            sfd.DefaultExt = ".xlsx"
            sfd.FileName = "Excel ausentismo semanal.xlsx"

            sfd.OverwritePrompt = True
            If sfd.ShowDialog() = DialogResult.OK Then

                '----Codigo anterior que genera el excel a partir de una hoja
                'Dim archivo As ExcelPackage = New ExcelPackage()
                'Dim wb As ExcelWorkbook = archivo.Workbook

                'ExcelDetallesAusentismo("Ausentismo_semanal", "", wb, dtInformacion)
                'archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
                'MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                '---Codigo tomando una plantilla de excel ya preestablecida
                Dim File = New FileInfo(DireccionReportes & "Plantilla_Excel ausentismo semanal.xlsx") ' Aqui es donde toma la plantilla
                'Dim wb As ExcelWorkbook = archivo.Workbook
                Using package As New ExcelPackage(File)

                    Dim hoja_excel As ExcelWorksheet = package.Workbook.Worksheets("Ausentismo_semanal") ' Toma el nombre de la hoja

                    ExcelDetallesAusentismoV2("Ausentismo_semanal", "", hoja_excel, dtInformacion)
                    package.SaveAs(New System.IO.FileInfo(sfd.FileName)) ' Guarda el archivo
                    MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End Using


            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un problema al procesar la información.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '-----Original anterior
    Public Sub ExcelDetallesAusentismo(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, dtDatos As DataTable)

        Dim x As Integer = 1
        Dim y As Integer = 1
        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

        Dim dtAuxEmpleados As New DataTable, dtAusentismo As New DataTable

        Dim dtTipoAus As DataTable = sqlExecute("select tipo_aus, rtrim(nombre) as nombre, color_letra, color_back from tipo_ausentismo", "TA")
        dtTipoAus.PrimaryKey = ({dtTipoAus.Columns("tipo_aus")})


        hoja_excel.Cells(x, y).Value = "Departamento"
        hoja_excel.Cells(x, y).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 1).Value = "Reloj"
        hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 2).Value = "Nombre"
        hoja_excel.Cells(x, y + 2).Style.Font.Bold = True


        hoja_excel.Cells(x, y + 3).Value = "Fecha"
        hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 4).Value = "Incidencia"
        hoja_excel.Cells(x, y + 4).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 5).Value = "Descripción"
        hoja_excel.Cells(x, y + 5).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 6).Value = "Motivo"
        hoja_excel.Cells(x, y + 6).Style.Font.Bold = True



        'hoja_excel.Cells(x, y + 7).Value = "Turno"
        'hoja_excel.Cells(x, y + 7).Style.Font.Bold = True

        ''***************************
        'hoja_excel.Cells(x, y + 8).Value = "Horario Código"
        'hoja_excel.Cells(x, y + 8).Style.Font.Bold = True

        'hoja_excel.Cells(x, y + 9).Value = "Horario Nombre"
        'hoja_excel.Cells(x, y + 9).Style.Font.Bold = True
        ''**************************

        'hoja_excel.Cells(x, y + 10).Value = "Fecha Ausentismo"
        'hoja_excel.Cells(x, y + 10).Style.Font.Bold = True

        'hoja_excel.Cells(x, y + 11).Value = "Tipo Ausentsimo"
        'hoja_excel.Cells(x, y + 11).Style.Font.Bold = True

        'hoja_excel.Cells(x, y + 12).Value = "Nombre Ausentismo"
        'hoja_excel.Cells(x, y + 12).Style.Font.Bold = True

        dtAuxEmpleados = sqlExecute("select reloj,contenido from detalle_auxiliares where campo='001' order by reloj asc ", "PERSONAL")

        For Each row As DataRow In dtDatos.Select(filtro, "reloj")
            Dim ausentismo As String = IIf(IsDBNull(row("tipo_aus")), "", row("tipo_aus").ToString)
            Dim comentario As String = "", tieneRet As Boolean = False
            Try : comentario = row("comentario").ToString.Trim : Catch ex As Exception : comentario = "" : End Try
            If comentario.Contains("RETARD") Then tieneRet = True

            If ausentismo <> "" Or tieneRet Then
                x += 1
                Dim reloj As String = "", tipo_aus As String = "", nombre_depto As String = "", nombres As String = "", fecha_entro As String = "", nombre_aus As String = ""
                Dim motivo As String = "", ruta_cliente As String = ""

                Try : nombre_depto = row("nombre_depto_personal").ToString.Trim : Catch ex As Exception : nombre_depto = "" : End Try ' PEND de obtener la ruta cliente
                Try : reloj = row("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                Try : nombres = row("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
                Try : fecha_entro = FechaSQL(row("fecha_entro")) : Catch ex As Exception : fecha_entro = "" : End Try

                If tieneRet Then
                    tipo_aus = "RET"
                    nombre_aus = "RETARDO"
                Else
                    Try : tipo_aus = row("tipo_aus").ToString.Trim : Catch ex As Exception : tipo_aus = "" : End Try
                    Try : nombre_aus = row("nombre_aus").ToString.Trim : Catch ex As Exception : nombre_aus = "" : End Try
                End If

                dtAusentismo = sqlExecute("select reloj,fecha,tipo_aus,subclasi from ausentismo where reloj='" & reloj & "' and fecha='" & fecha_entro & "'", "TA")
                If Not dtAusentismo.Columns.Contains("Error") And dtAusentismo.Rows.Count > 0 Then Try : motivo = dtAusentismo.Rows(0).Item("subclasi").ToString.Trim : Catch ex As Exception : motivo = "" : End Try

                If motivo.Contains("Evaluador") Then motivo = ""


                '---Obtener la ruta_cliente del empleado
                Dim item = (From z In dtAuxEmpleados.Rows Where z("reloj").ToString.Trim = reloj).ToList()
                If (item.Count > 0) Then Try : ruta_cliente = (item.First()("contenido").ToString.Trim) : Catch ex As Exception : ruta_cliente = "" : End Try


                '*********------=================ASIGNACION DE VALORES EN EL EXCEL
                hoja_excel.Cells(x, y).Value = ruta_cliente
                hoja_excel.Cells(x, y + 1).Value = reloj
                hoja_excel.Cells(x, y + 2).Value = nombres

                '---*****************----Fecha de inci
                hoja_excel.Cells(x, y + 3).Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern
                hoja_excel.Cells(x, y + 3).Value = Date.Parse(fecha_entro)

                '********--------------TIPO_AUS
                hoja_excel.Cells(x, y + 4).Value = tipo_aus
                hoja_excel.Cells(x, y + 4).Style.Font.Bold = True
                hoja_excel.Cells(x, y + 4).Style.Fill.PatternType = Style.ExcelFillStyle.Solid

                If tieneRet Then
                    hoja_excel.Cells(x, y + 4).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(-4582375))
                    hoja_excel.Cells(x, y + 4).Style.Font.Color.SetColor(Color.FromArgb(-1))
                Else
                    hoja_excel.Cells(x, y + 4).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(dtTipoAus.Rows.Find({tipo_aus})("color_back")))
                    hoja_excel.Cells(x, y + 4).Style.Font.Color.SetColor(Color.FromArgb(dtTipoAus.Rows.Find({tipo_aus})("color_letra")))
                End If

                hoja_excel.Cells(x, y + 5).Value = nombre_aus
                hoja_excel.Cells(x, y + 6).Value = motivo


            End If
        Next

        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

    End Sub

    '------Nueva que toma a partir de una plantilla
    Public Sub ExcelDetallesAusentismoV2(nombre_hoja As String, filtro As String, ByRef hoja_excel As ExcelWorksheet, dtDatos As DataTable)

        Dim x As Integer = 5
        Dim y As Integer = 1
        'Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

        Dim dtAuxEmpleados As New DataTable, dtAusentismo As New DataTable

        Dim dtTipoAus As DataTable = sqlExecute("select tipo_aus, rtrim(nombre) as nombre, color_letra, color_back from tipo_ausentismo", "TA")
        dtTipoAus.PrimaryKey = ({dtTipoAus.Columns("tipo_aus")})



        hoja_excel.Cells(x, y).Value = "Departamento"
        hoja_excel.Cells(x, y).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 1).Value = "Reloj"
        hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 2).Value = "Nombre"
        hoja_excel.Cells(x, y + 2).Style.Font.Bold = True


        hoja_excel.Cells(x, y + 3).Value = "Fecha"
        hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 4).Value = "Incidencia"
        hoja_excel.Cells(x, y + 4).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 5).Value = "Descripción"
        hoja_excel.Cells(x, y + 5).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 6).Value = "Motivo"
        hoja_excel.Cells(x, y + 6).Style.Font.Bold = True



        dtAuxEmpleados = sqlExecute("select reloj,contenido from detalle_auxiliares where campo='001' order by reloj asc ", "PERSONAL")

        For Each row As DataRow In dtDatos.Select(filtro, "reloj")
            Dim ausentismo As String = IIf(IsDBNull(row("tipo_aus")), "", row("tipo_aus").ToString)
            Dim comentario As String = "", tieneRet As Boolean = False
            Try : comentario = row("comentario").ToString.Trim : Catch ex As Exception : comentario = "" : End Try
            If comentario.Contains("RETARD") Then tieneRet = True

            If ausentismo <> "" Or tieneRet Then
                x += 1
                Dim reloj As String = "", tipo_aus As String = "", nombre_depto As String = "", nombres As String = "", fecha_entro As String = "", nombre_aus As String = ""
                Dim motivo As String = "", ruta_cliente As String = ""

                Try : nombre_depto = row("nombre_depto_personal").ToString.Trim : Catch ex As Exception : nombre_depto = "" : End Try ' PEND de obtener la ruta cliente
                Try : reloj = row("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                Try : nombres = row("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
                Try : fecha_entro = FechaSQL(row("fecha_entro")) : Catch ex As Exception : fecha_entro = "" : End Try

                If tieneRet Then
                    tipo_aus = "RET"
                    nombre_aus = "RETARDO"
                Else
                    Try : tipo_aus = row("tipo_aus").ToString.Trim : Catch ex As Exception : tipo_aus = "" : End Try
                    Try : nombre_aus = row("nombre_aus").ToString.Trim : Catch ex As Exception : nombre_aus = "" : End Try
                End If

                dtAusentismo = sqlExecute("select reloj,fecha,tipo_aus,subclasi from ausentismo where reloj='" & reloj & "' and fecha='" & fecha_entro & "'", "TA")
                If Not dtAusentismo.Columns.Contains("Error") And dtAusentismo.Rows.Count > 0 Then Try : motivo = dtAusentismo.Rows(0).Item("subclasi").ToString.Trim : Catch ex As Exception : motivo = "" : End Try

                If motivo.Contains("Evaluador") Then motivo = ""


                '---Obtener la ruta_cliente del empleado
                Dim item = (From z In dtAuxEmpleados.Rows Where z("reloj").ToString.Trim = reloj).ToList()
                If (item.Count > 0) Then Try : ruta_cliente = (item.First()("contenido").ToString.Trim) : Catch ex As Exception : ruta_cliente = "" : End Try


                '*********------=================ASIGNACION DE VALORES EN EL EXCEL
                hoja_excel.Cells(x, y).Value = ruta_cliente
                hoja_excel.Cells(x, y + 1).Value = reloj
                hoja_excel.Cells(x, y + 2).Value = nombres

                '---*****************----Fecha de inci
                hoja_excel.Cells(x, y + 3).Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern
                hoja_excel.Cells(x, y + 3).Value = Date.Parse(fecha_entro)

                '********--------------TIPO_AUS
                hoja_excel.Cells(x, y + 4).Value = tipo_aus
                hoja_excel.Cells(x, y + 4).Style.Font.Bold = True
                hoja_excel.Cells(x, y + 4).Style.Fill.PatternType = Style.ExcelFillStyle.Solid

                If tieneRet Then
                    hoja_excel.Cells(x, y + 4).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(-4582375))
                    hoja_excel.Cells(x, y + 4).Style.Font.Color.SetColor(Color.FromArgb(-1))
                Else
                    hoja_excel.Cells(x, y + 4).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(dtTipoAus.Rows.Find({tipo_aus})("color_back")))
                    hoja_excel.Cells(x, y + 4).Style.Font.Color.SetColor(Color.FromArgb(dtTipoAus.Rows.Find({tipo_aus})("color_letra")))
                End If

                hoja_excel.Cells(x, y + 5).Value = nombre_aus
                hoja_excel.Cells(x, y + 6).Value = motivo


            End If
        Next

        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

    End Sub
    '------------------------------------------------CHUY--------------------------------------------

    Public Sub ExcelAusentismoTA(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim sfd As New SaveFileDialog
            Dim frm_fechas As New frmRangoFechas
            frm_fechas.Text = "Filtrar fecha para el Ausentismo"
            frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 12)
            frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>FECHAS PARA AUSENTISMO</b></font>
            frm_fechas.frmRangoFechas_fecha_ini = RangoFInicial
            frm_fechas.frmRangoFechas_fecha_fin = RangoFFinal
            frm_fechas.ShowDialog()

            Dim fecha_ini As Date = frm_fechas.frmRangoFechas_fecha_ini
            Dim fecha_fin As Date = frm_fechas.frmRangoFechas_fecha_fin

            'Dim periodo_actual As String = ""

            'Dim dtPeriodoActual As DataTable = sqlExecute("select * from periodos where '" & FechaInicial & "' between fecha_ini and fecha_fin and isnull(periodo_especial, 0) <> 1", "TA")
            'If dtPeriodoActual.Rows.Count > 0 Then
            '    periodo_actual = dtPeriodoActual.Rows(0)("ano") & dtPeriodoActual.Rows(0)("periodo")

            '    Dim periodo_analisis As String = dtPeriodoActual.Rows(0)("ano") & dtPeriodoActual.Rows(0)("periodo")

            sfd.DefaultExt = ".xlsx"
            sfd.FileName = "Excel ausentismo rango horizontal.xlsx"

            sfd.OverwritePrompt = True
            If sfd.ShowDialog() = DialogResult.OK Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                ExcelDetallesAusentismoH("Excel ausentismo rango horizontal", "", wb, fecha_ini, fecha_fin, dtInformacion)

                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))

                MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            End If

            'Else

            'End If

        Catch ex As Exception

        End Try
    End Sub


    Public Sub ExcelDetallesAusentismoH(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, fecha_ini As Date, fecha_fin As Date, dtInformacion As DataTable)
        Try
            'MCR OCT-29-2020
            'Cambios solicitados por WME 

            ' Reporte a detalle Excel
            Dim x As Integer = 1
            Dim y As Integer = 1

            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

            'Dim dtEmpleadosJ1 As DataTable = sqlExecute("select distinct(reloj) as reloj from ausentismo where fecha between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "' and reloj in (select reloj from personal.dbo.personal where cod_comp = 'PIM' and cod_tipo = 'O') " & IIf(filtro.Trim <> "", " and " & filtro, "") & "order by reloj asc", "TA")

            Dim celdas_encabezado = 13

            '-----ENCABEZADOS----------
            '**VALORES FIJOS


            hoja_excel.Cells(x, y).Value = "Cod.Comp."
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            'hoja_excel.Cells(x, y + 1).Value = "Cod_Planta"
            'hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

            y += 1
            hoja_excel.Cells(x, y).Value = "Reloj"
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            'hoja_excel.Cells(x, y + 3).Value = "Reloj_Alterno"
            'hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

            y += 1
            hoja_excel.Cells(x, y).Value = "Nombre"
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            y += 1
            hoja_excel.Cells(x, y).Value = "Alta"
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            y += 1
            hoja_excel.Cells(x, y).Value = "Baja"
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            'y += 1
            'hoja_excel.Cells(x, y + 7).Value = "Cod_Departamento"
            'hoja_excel.Cells(x, y + 7).Style.Font.Bold = True

            y += 1
            hoja_excel.Cells(x, y).Value = "Departamento"
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            y += 1
            hoja_excel.Cells(x, y).Value = "Supervisor"
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            y += 1
            hoja_excel.Cells(x, y).Value = "Turno"
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            '*************************************
            y += 1
            hoja_excel.Cells(x, y).Value = "Horario Código"
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            y += 1
            hoja_excel.Cells(x, y).Value = "Horario Nombre"
            hoja_excel.Cells(x, y).Style.Font.Bold = True
            '*************************************

            'Genera las fechas como columnas, para posteriormente clasificar asistencia o ausencia****************************************************************************************************************************************
            celdas_encabezado = y + 1
            Dim f As Date = fecha_ini
            While f <= fecha_fin
                Dim dif As Integer = (DateDiff(DateInterval.Day, fecha_ini, f))
                hoja_excel.Cells(x, celdas_encabezado + dif).Value = f.ToShortDateString
                hoja_excel.Cells(x, celdas_encabezado + dif).Style.Font.Bold = True
                f = f.AddDays(1)
            End While
            'FIN Genera las fechas como columnas, para posteriormente clasificar asistencia o ausencia****************************************************************************************************************************************


            hoja_excel.Cells(x, 1 + celdas_encabezado + DateDiff(DateInterval.Day, fecha_ini, fecha_fin)).Value = "Total"
            hoja_excel.Cells(x, 1 + celdas_encabezado + DateDiff(DateInterval.Day, fecha_ini, fecha_fin)).Style.Font.Bold = True
            x += 1

            '-----CONTENIDO----------

            Dim reloj_tmp As String = ""

            y = 1
            For Each row As DataRow In dtInformacion.Select("", "reloj")

                If reloj_tmp = row("reloj") Then
                    Continue For
                Else
                    reloj_tmp = row("reloj")
                End If


                f = fecha_ini

                'ASIGNA LOS VALORES CONSULTADOS DIRECTAMENTE DE LOS EMPLEADOS**********************************************************************************************************

                hoja_excel.Cells(x, y + 1).Value = row("reloj")

                Dim dtNombres As DataTable = sqlExecute("select reloj,reloj_alt, nombres, cod_clase, cod_comp, cod_planta, alta, baja, nombre_planta, cod_depto, nombre_depto, cod_turno, nombre_super,cod_hora,nombre_horario from personalvw where reloj = '" & row("reloj") & "'")

                If dtNombres.Rows.Count > 0 Then
                    'hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("cod_comp")
                    hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("cod_planta")
                    'hoja_excel.Cells(x, y + 3).Value = dtNombres.Rows(0)("reloj_alt")
                    y += 2
                    hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("nombres")
                    y += 1
                    hoja_excel.Cells(x, y).Value = Date.Parse(dtNombres.Rows(0)("alta")).ToShortDateString

                    y += 1
                    Try
                        hoja_excel.Cells(x, y).Value = Date.Parse(dtNombres.Rows(0)("baja")).ToShortDateString
                    Catch ex As Exception
                        hoja_excel.Cells(x, y).Value = ""
                    End Try
                    'hoja_excel.Cells(x, y + 6).Value = dtNombres.Rows(0)("cod_depto")
                    y += 1
                    hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("nombre_depto")
                    y += 1
                    hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("nombre_super")
                    y += 1
                    hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("cod_turno")

                    '********************************

                    Try
                        y += 1
                        hoja_excel.Cells(x, y).Value = IIf(IsDBNull(dtNombres.Rows(0)("cod_hora")), "", dtNombres.Rows(0)("cod_hora"))
                        y += 1
                        hoja_excel.Cells(x, y).Value = IIf(IsDBNull(dtNombres.Rows(0)("nombre_horario")), "", dtNombres.Rows(0)("nombre_horario"))
                    Catch ex As Exception

                    End Try

                    '*******************************
                End If

                celdas_encabezado = y
                y = 1
                'BUSCA EL TIPO DE AUSENCIA****************************************************************************************************************************************
                While ((f <= fecha_fin) And (DateDiff(DateInterval.Day, f, DateTime.Today())) >= 1)

                    'VERIFICA SI EL EMPLEADO ES VIGENTE********************************************************************************************************************
                    Dim dtVerificarSiEsVigente As DataTable = sqlExecute("select asist.*, PERSONAL.ALTA, PERSONAL.BAJA  from ta.dbo.asist left join PERSONAL.dbo.personal on asist.reloj = personal.reloj where PERSONAL.reloj = '" & row("reloj") & "' AND ALTA <= '" & FechaSQL(f) & "'  AND (BAJA is null or BAJA >= '" & FechaSQL(f) & "')")
                    If dtVerificarSiEsVigente.Rows.Count > 0 Then

                        'VERIFICA SI SE ENCUENTRA EN LA TABLA ASISTENCIA POR FECHA Y RELOJ********************************************************************************************************************
                        Dim dtAusentismo As DataTable = sqlExecute("select rtrim(tipo_aus) as tipo_aus, rtrim(entro) as entro, rtrim(salio) as salio from asist where reloj = '" & row("reloj") & "' and fecha_entro = '" & FechaSQL(f) & "' " & IIf(filtro.Trim <> "", " and " & filtro, ""), "TA")
                        If dtAusentismo.Rows.Count > 0 Then

                            'VERIFICA SI TIENE ALGUN TIPO DE AUSENTISMO********************************************************************************************************************
                            Dim tipo_aus As String = Convert.ToString(dtAusentismo.Rows(0)("tipo_aus"))
                            If tipo_aus <> "" Then

                                Dim dtObtieneTipoAus As DataTable = sqlExecute("select rtrim(nombre) as nombre, color_letra, color_back from tipo_ausentismo WHERE rtrim(tipo_aus) = '" + tipo_aus + "'", "TA")

                                If tipo_aus = "FES" And (dtAusentismo.Rows(0)("entro") <> "" Or dtAusentismo.Rows(0)("salio") <> "") Then
                                    Dim dif As Integer = (DateDiff(DateInterval.Day, fecha_ini, f))
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = "FEST TRAB"
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Bold = True
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(dtObtieneTipoAus.Rows(0)("color_back")))
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Color.SetColor(Color.FromArgb(dtObtieneTipoAus.Rows(0)("color_letra")))
                                Else
                                    'SI HUBO ALGUN TIPO DE AUSENTISMO, LO BUSCA Y LO DESCRIBE DESDE LA BASE DE DATOS*******************************************************************************************************************
                                    Dim dif As Integer = (DateDiff(DateInterval.Day, fecha_ini, f))
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = tipo_aus
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).AddComment(dtObtieneTipoAus.Rows(0)("nombre"), "Detalle")
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Bold = True
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(dtObtieneTipoAus.Rows(0)("color_back")))
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Color.SetColor(Color.FromArgb(dtObtieneTipoAus.Rows(0)("color_letra")))
                                End If
                            Else
                                'ASIGNA 'DESC TRAB' De acuerdo a los comentarios de la tabla ASIST****************************************************************************************************************************************
                                Dim dtDescansoTrabajado As DataTable = sqlExecute("select * from ta.dbo.asist where reloj = '" & row("reloj") & "' and fecha_entro = '" & FechaSQL(f) & "' and COMENTARIO LIKE '%DESCANSO%'")
                                If dtDescansoTrabajado.Rows.Count > 0 Then
                                    Dim dif As Integer = (DateDiff(DateInterval.Day, fecha_ini, f))
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = "DESC TRAB"
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Bold = True
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255))
                                Else
                                    'ASIGNA 'ASIS' A LOS QUE TENGAN POR LO MENOS HORARIO DE ENTRADA O DE SALIDA****************************************************************************************************************************************
                                    Dim dtasist As DataTable = sqlExecute("select asist.entro,asist.salio, PERSONAL.ALTA, PERSONAL.BAJA  from ta.dbo.asist left join PERSONAL.dbo.personal on asist.reloj = personal.reloj where PERSONAL.reloj = '" & row("reloj") & "' and fecha_entro = '" & FechaSQL(f) & "' AND fecha_entro >= ALTA AND (BAJA is null or fecha_entro <= BAJA) AND (SALIO <> '' or ENTRO <> '') and TIPO_AUS is NULL")
                                    If dtasist.Rows.Count > 0 Then
                                        Dim dif As Integer = (DateDiff(DateInterval.Day, fecha_ini, f))
                                        hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = IIf(IsDBNull(dtasist.Rows(0).Item("entro")), "", dtasist.Rows(0).Item("entro")) & " - " & IIf(IsDBNull(dtasist.Rows(0).Item("salio")), "", dtasist.Rows(0).Item("salio"))
                                        hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Bold = True
                                        hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                        hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255))
                                    End If
                                End If
                            End If
                        Else
                            'SI NO NUBO UNA FECHA DE ENTRADA LO TOMA COMO DESCANSO****************************************************************************************************************************************
                            Dim dif As Integer = (DateDiff(DateInterval.Day, fecha_ini, f))
                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = "DESC"
                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Bold = True
                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255))

                        End If
                    End If
                    f = f.AddDays(1)
                End While

                Dim dtSum As DataTable = sqlExecute("select * from ausentismo where reloj = '" & row("reloj") & "' and tipo_aus = 'FI' and fecha between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "'" & IIf(filtro.Trim <> "", " and " & filtro, ""), "TA")
                hoja_excel.Cells(x, 1 + y + celdas_encabezado + DateDiff(DateInterval.Day, fecha_ini, fecha_fin)).Style.Font.Bold = True
                hoja_excel.Cells(x, 1 + y + celdas_encabezado + DateDiff(DateInterval.Day, fecha_ini, fecha_fin)).Value = dtSum.Rows.Count

                x += 1

            Next

            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub ChecadaSalary(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim i As Integer
            i = 1
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("FECHA_ENTRO", GetType(System.DateTime))
            dtDatos.Columns.Add("TIPO")
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("RELOJ"), dtDatos.Columns("NOMBRES"), dtDatos.Columns("FECHA_ENTRO")}

            For Each row As DataRow In dtInformacion.Rows
                Dim rowchecada As DataRow = dtDatos.Rows.Find({row("RELOJ"), row("NOMBRES"), row("FECHA_ENTRO")})
                If rowchecada Is Nothing Then
                    rowchecada = dtDatos.NewRow
                    If Not IsDBNull(row("nombres")) Or RTrim(row("nombres")) <> "" Then

                        rowchecada("RELOJ") = row("reloj")
                        rowchecada("NOMBRES") = row("nombres")

                        If RTrim(row("entro")) <> "" And RTrim(row("salio")) <> "" And RTrim(row("comentario")) = "" Then
                            rowchecada("FECHA_ENTRO") = row("FECHA_ENTRO")
                            rowchecada("TIPO") = "COMPLETA"
                        End If

                        If RTrim(row("entro")) = "" And RTrim(row("salio")) = "" And RTrim(row("comentario")) = "" Then
                            rowchecada("FECHA_ENTRO") = row("FECHA_ENTRO")
                            rowchecada("TIPO") = "NO CHECARON"
                        ElseIf RTrim(row("entro")) = "" And RTrim(row("salio")) = "" And RTrim(row("comentario")) <> "" Then
                            rowchecada("FECHA_ENTRO") = row("FECHA_ENTRO")
                            rowchecada("TIPO") = "NO CHECARON"
                        End If

                        If RTrim(row("entro")) <> "" And RTrim(row("salio")) = "" And RTrim(row("comentario")) <> "" Then
                            rowchecada("FECHA_ENTRO") = row("FECHA_ENTRO")
                            rowchecada("TIPO") = "INCOMPLETAS"

                        ElseIf RTrim(row("salio")) <> "" And RTrim(row("entro")) = "" And RTrim(row("comentario")) <> "" Then
                            rowchecada("FECHA_ENTRO") = row("FECHA_ENTRO")
                            rowchecada("TIPO") = "INCOMPLETAS"
                        End If

                        If RTrim(row("entro")) <> "" And RTrim(row("salio")) <> "" And RTrim(row("comentario")) <> "" Then
                            rowchecada("FECHA_ENTRO") = row("FECHA_ENTRO")
                            rowchecada("TIPO") = row("comentario").ToString.Trim
                        End If

                        dtDatos.Rows.Add(rowchecada)

                    Else
                        MsgBox("Hola", MsgBoxStyle.OkOnly, "Solo")
                    End If

                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Checada Salary", ex.HResult, ex.Message)
        End Try


    End Sub

    'Public Sub ReporteAusentismoDevuelto(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal DataSet As String)


    '    If DataSet = "Informacion_COD" Then
    '        dtDatos = New DataTable
    '        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("fecha", Type.GetType("System.DateTime"))
    '        dtDatos.Columns.Add("tipo_aus", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
    '        dtDatos.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))


    '        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("cod_comp", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("compania", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("nombre_tipo_ausentismo", Type.GetType("System.String"))

    '        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj"), dtDatos.Columns("fecha")}

    '        For Each row As DataRow In dtInformacion.Select("trim(isnull(ausentismo_real, '')) <> ''")
    '            Try
    '                Dim drow As DataRow
    '                drow = dtDatos.Rows.Find({row("reloj"), row("fha_ent_hor")})
    '                If drow Is Nothing Then
    '                    drow = dtDatos.NewRow

    '                    drow("reloj") = row("reloj")
    '                    drow("fecha") = row("fha_ent_hor")
    '                    drow("tipo_aus") = row("ausentismo_real")

    '                    drow("nombres") = row("nombres")

    '                    drow("cod_clase") = row("cod_clase")
    '                    drow("cod_turno") = row("cod_turno")

    '                    drow("cod_comp") = row("cod_comp")
    '                    drow("compania") = row("compania")

    '                    drow("cod_depto") = row("cod_depto")
    '                    drow("nombre_depto") = row("nombre_depto")

    '                    drow("cod_super") = row("cod_super")
    '                    drow("nombre_super") = row("nombre_super")

    '                    drow("nombre_tipo_ausentismo") = row("nombre_aus")

    '                    drow("fecha_ini") = FechaInicial
    '                    drow("fecha_fin") = FechaFinal

    '                    dtDatos.Rows.Add(drow)
    '                Else

    '                End If

    '            Catch ex As Exception

    '            End Try
    '        Next

    '    Else


    '        Dim q As String = " " &
    '        "SELECT RELOJ,ANO,PERIODO,CONCEPTO,FECHA_INCIDENCIA,TIPO_AUS,NOMBRE  " &
    '        "FROM ajustes_nom,ta.dbo.tipo_ausentismo  " &
    '        "WHERE CONCEPTO IN ( " &
    '        "SELECT concepto FROM conceptos  " &
    '        "LEFT JOIN naturalezas ON conceptos.cod_naturaleza = naturalezas.cod_naturaleza   " &
    '        "WHERE NOT (misce_clave IS NULL OR MISCE_CLAVE = 0) and concepto  in  " &
    '        "(select distinct ISNULL(cancelacion,devolucion) AS concepto FROM ta.dbo.tipo_ausentismo  " &
    '        "WHERE NOT (cancelacion IS NULL and devolucion IS NULL)) AND (aplica_mtro_ded IS NULL OR APLICA_MTRO_DED = 0))  " &
    '        "AND tipo_ausentismo.devolucion = ajustes_nom.CONCEPTO " &
    '        "AND FECHA_INCIDENCIA BETWEEN '" + FechaInicial.ToString("yyyy-MM-dd") + "' AND '" + FechaFinal.ToString("yyyy-MM-dd") + "' "
    '        Debug.Print(q)
    '        dtDatos = sqlExecute(q, "NOMINA")


    '    End If



    'End Sub

    Public Sub ReporteAusentismoDevuelto(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal DataSet As String)

        If StopRFHA = True Then
            Dim frm_fechas As New frmRangoFechas
            frm_fechas.frmRangoFechas_fecha_ini = RangoFInicial
            frm_fechas.frmRangoFechas_fecha_fin = RangoFFinal
            frm_fechas.ShowDialog()
            StopRFHA = False
        End If

        Try
            If DataSet = "Informacion_COD" Then
                Dim q As String = " " &
                "select a.reloj " &
                ",p.nombres " &
                ",p.nombre_area " &
                ",p.alta,a.fecha " &
                ",a.nombre  " &
                    ",'" + FechaInicial.ToString("yyyy-MM-dd") + "' as fecha_ini  " &
                        ",'" + FechaFinal.ToString("yyyy-MM-dd") + "' as fecha_fin " &
                "from ausentismovw a  " &
                "left join personal.dbo.personalvw p " &
                "on a.reloj=p.reloj  " &
                "where fecha between '" + FechaInicial.ToString("yyyy-MM-dd") + "' AND '" + FechaFinal.ToString("yyyy-MM-dd") + "' order by fecha "
                Debug.Print(q)
                dtDatos = sqlExecute(q, "ta")
            Else
                Dim q As String = " " &
                "select aj.reloj,p.nombres" &
                ",p.nombre_area" &
                ",p.alta,aj.fecha_incidencia" &
                ",c.nombre" &
                ",aj.ano" &
                ",aj.periodo" &
                ",aj.tipo_periodo " &
                "from ajustes_nom aj " &
                "left join personal.dbo.personalvw p " &
                "on aj.reloj=p.reloj left join conceptos c " &
                "on aj.concepto=c.concepto " &
                "where fecha_incidencia between '" + FechaInicial.ToString("yyyy-MM-dd") + "' AND '" + FechaFinal.ToString("yyyy-MM-dd") + "' and aj.concepto like 'DDV%' "
                Debug.Print(q)
                dtDatos = sqlExecute(q, "nomina")
                StopRFHA = True
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Sub ReporteAusentismoAplicado(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        dtDatos = dtInformacion.Copy
        dtDatos.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))

        For Each row As DataRow In dtDatos.Rows
            row("fecha_ini") = FechaSQL(RangoFInicial)
            row("fecha_fin") = FechaSQL(RangoFFinal)
        Next

    End Sub

    Public Sub ReporteAjustesClerkFecha(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            Dim f As Date = Now.Date.AddDays(1)


            Dim frm As New frmRangoFechas

            Do
                If f.DayOfWeek = DayOfWeek.Tuesday Then
                    Exit Do
                Else
                    f = f.AddDays(-1)
                End If
            Loop

            If f < Now.Date Then
                frm.frmRangoFechas_fecha_ini = f
                frm.frmRangoFechas_fecha_fin = f.AddDays(7)
            Else
                frm.frmRangoFechas_fecha_fin = f
                frm.frmRangoFechas_fecha_ini = f.AddDays(-7)
            End If

            If frm.ShowDialog() = DialogResult.OK Then

                Dim fini As Date = FechaInicial
                Dim ffin As Date = FechaFinal

                Dim dtAjustes As New DataTable

                dtAjustes.Columns.Add("cod_clerk", Type.GetType("System.String"))
                dtAjustes.Columns.Add("usuario", Type.GetType("System.String"))
                dtAjustes.Columns.Add("usuario_nombre", Type.GetType("System.String"))
                dtAjustes.Columns.Add("usuario_filtro", Type.GetType("System.String"))
                dtAjustes.Columns.Add("ajustes", Type.GetType("System.Int32"))
                dtAjustes.Columns.Add("incluir", Type.GetType("System.Int32"))

                dtAjustes.PrimaryKey = New DataColumn() {dtAjustes.Columns("cod_clerk"), dtAjustes.Columns("usuario")}

                If True Then
                    Dim f_ As Date = fini
                    While f_ <= ffin
                        dtAjustes.Columns.Add(FechaSQL(f_).Replace("-", ""), Type.GetType("System.Int32"))
                        f_ = f_.AddDays(1)
                    End While
                End If


                Dim dtUsuarios As DataTable = sqlExecute("select isnull(username, '') as username , isnull(nombre, '') as nombre , isnull(filtro, '') as filtro from seguridad.dbo.appuser where cod_perfil in ('IDEASCLERK', 'CLERK')")

                Dim dtClerks As DataTable = sqlExecute("select clerks.cod_clerk, clerks.nombre, count(personalvw.reloj) as hc from clerks left join personalvw on personalvw.cod_clerk = clerks.cod_clerk where personalvw.baja is null and clerks.activo = '1' group by clerks.cod_clerk, clerks.nombre")


                For Each row_usuario As DataRow In dtUsuarios.Rows

                    Dim u As String = RTrim(row_usuario("username"))

                    For Each row_clerk As DataRow In dtClerks.Rows

                        Dim cod_clerk As String = row_clerk("cod_clerk")

                        Dim drow As DataRow = dtAjustes.Rows.Find({u, cod_clerk})

                        If drow Is Nothing Then

                            drow = dtAjustes.NewRow

                            drow("cod_clerk") = cod_clerk

                            drow("usuario") = u
                            drow("usuario_nombre") = RTrim(row_usuario("nombre"))
                            drow("usuario_filtro") = RTrim(row_usuario("filtro"))

                            drow("ajustes") = 0
                            drow("incluir") = 0


                            dtAjustes.Rows.Add(drow)

                        End If

                    Next
                Next


                Dim dtPersonalActivo As DataTable = sqlExecute("select * from personalvw where baja is null")

                For Each row_ajustes As DataRow In dtAjustes.Rows

                    Dim cod_clerk As String = row_ajustes("cod_clerk")

                    Try
                        Dim dtPersonalClerks As DataTable = dtPersonalActivo.Select("cod_clerk = '" & cod_clerk & "'").CopyToDataTable


                        For Each row As DataRow In dtPersonalClerks.Select(row_ajustes("usuario_filtro"))
                            row_ajustes("incluir") = 1
                            Exit For
                        Next

                    Catch ex As Exception
                        Continue For
                    End Try



                    Dim u As String = row_ajustes("usuario")

                    If True Then
                        Dim f_ As Date = fini
                        While f_ <= ffin


                            Dim dtAjustesClerk As DataTable = sqlExecute("select *, convert(char(10), fecha_cambio, 120) as f from ta.dbo.bitacora_hrs_brt where convert(char(10), fecha_cambio, 120) = '" & FechaSQL(f_) & "' and usuario = '" & u & "'")

                            row_ajustes(FechaSQL(f_).Replace("-", "")) = dtAjustesClerk.Rows.Count
                            f_ = f_.AddDays(1)

                        End While
                    End If

                Next


                '***********************************


                Dim sfd As New SaveFileDialog
                sfd.Title = "Ajustes por usuario"
                sfd.Filter = "Excel|*.xlsx"
                sfd.FileName = "Ajustes por usuario"

                If sfd.ShowDialog = DialogResult.OK Then
                    Dim archivo As ExcelPackage = New ExcelPackage()
                    Dim wb As ExcelWorkbook = archivo.Workbook

                    Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("Ajustes por usuario")

                    Dim x As Integer = 4

                    hoja_excel.Cells(x, 1).Value = "Clerk"
                    hoja_excel.Cells(x, 1).Style.Font.Bold = True
                    hoja_excel.Cells(x, 1).Style.Font.Size = 10
                    hoja_excel.Cells(x, 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    hoja_excel.Cells(x, 1).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
                    hoja_excel.Cells(x, 1).Style.Font.Color.SetColor(Color.White)

                    hoja_excel.Cells(x, 2).Value = "Clerk / Usuario"
                    hoja_excel.Cells(x, 2).Style.Font.Bold = True
                    hoja_excel.Cells(x, 2).Style.Font.Size = 10
                    hoja_excel.Cells(x, 2).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    hoja_excel.Cells(x, 2).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
                    hoja_excel.Cells(x, 2).Style.Font.Color.SetColor(Color.White)

                    hoja_excel.Cells(x, 3).Value = "Headcount (Actual)"
                    hoja_excel.Cells(x, 3).Style.Font.Bold = True
                    hoja_excel.Cells(x, 3).Style.Font.Size = 10
                    hoja_excel.Cells(x, 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    hoja_excel.Cells(x, 3).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
                    hoja_excel.Cells(x, 3).Style.Font.Color.SetColor(Color.White)


                    If True Then
                        Dim n As Integer = 4
                        Dim f_ As Date = fini
                        While f_ <= ffin

                            hoja_excel.Cells(x, n).Value = FechaSQL(f_)
                            hoja_excel.Cells(x, n).Style.Font.Bold = True
                            hoja_excel.Cells(x, n).Style.Font.Size = 10
                            hoja_excel.Cells(x, n).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                            hoja_excel.Cells(x, n).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
                            hoja_excel.Cells(x, n).Style.Font.Color.SetColor(Color.White)

                            f_ = f_.AddDays(1)
                            n += 1
                        End While
                    End If

                    For Each row_clerk As DataRow In dtClerks.Select("hc > 0")

                        x += 1

                        hoja_excel.Cells(x, 1).Value = RTrim(row_clerk("cod_clerk"))
                        hoja_excel.Cells(x, 1).Style.Font.Bold = True
                        hoja_excel.Cells(x, 1).Style.Font.Size = 10
                        hoja_excel.Cells(x, 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x, 1).Style.Fill.BackgroundColor.SetColor(Color.LightGray)

                        hoja_excel.Cells(x, 2).Value = RTrim(row_clerk("nombre"))
                        hoja_excel.Cells(x, 2).Style.Font.Bold = True
                        hoja_excel.Cells(x, 2).Style.Font.Size = 10
                        hoja_excel.Cells(x, 2).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x, 2).Style.Fill.BackgroundColor.SetColor(Color.LightGray)

                        hoja_excel.Cells(x, 3).Value = row_clerk("hc")
                        hoja_excel.Cells(x, 3).Style.Font.Bold = True
                        hoja_excel.Cells(x, 3).Style.Font.Size = 10
                        hoja_excel.Cells(x, 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x, 3).Style.Fill.BackgroundColor.SetColor(Color.LightGray)

                        If True Then
                            Dim n As Integer = 4
                            Dim f_ As Date = fini
                            While f_ <= ffin

                                hoja_excel.Cells(x, n).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                hoja_excel.Cells(x, n).Style.Fill.BackgroundColor.SetColor(Color.LightGray)

                                f_ = f_.AddDays(1)
                                n += 1
                            End While
                        End If

                        For Each row_ajustes As DataRow In dtAjustes.Select("cod_clerk = '" & row_clerk("cod_clerk") & "' and incluir = '1'")

                            x += 1

                            hoja_excel.Cells(x, 2).Value = RTrim(row_ajustes("usuario")) & " - " & RTrim(row_ajustes("usuario_nombre"))
                            hoja_excel.Cells(x, 2).Style.Font.Size = 10

                            hoja_excel.Cells(x, 3).Value = " "


                            If True Then
                                Dim n As Integer = 4
                                Dim f_ As Date = fini
                                While f_ <= ffin

                                    Dim cuantos As Integer = 0
                                    Try
                                        cuantos = row_ajustes(FechaSQL(f_).Replace("-", ""))
                                    Catch ex As Exception
                                        cuantos = 0
                                    End Try

                                    hoja_excel.Cells(x, n).Value = cuantos

                                    If cuantos > 0 Then
                                        hoja_excel.Cells(x, n).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                        hoja_excel.Cells(x, n).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
                                        hoja_excel.Cells(x, n).Style.Font.Bold = True
                                    End If

                                    hoja_excel.Cells(x, n).Style.Font.Size = 10
                                    f_ = f_.AddDays(1)

                                    n += 1
                                End While

                            End If

                        Next
                    Next

                    hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()


                    hoja_excel.Cells(1, 1).Value = "BRP QUERETARO"
                    hoja_excel.Cells(1, 1).Style.Font.Bold = True
                    hoja_excel.Cells(1, 1).Style.Font.Size = 12

                    hoja_excel.Cells(2, 1).Value = "Ajustes T&A por usuario (clerks) del " & FechaSQL(fini) & " al " & FechaSQL(ffin)
                    hoja_excel.Cells(2, 1).Style.Font.Bold = True
                    hoja_excel.Cells(2, 1).Style.Font.Size = 12


                    archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))

                    MessageBox.Show("El archivo ha sido generado correctamente" & vbCrLf & sfd.FileName, "Archivo generado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If



                '***********************************

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "TA", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub OH_AvanceAutoriazion(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("ano", GetType(System.String))
            dtDatos.Columns.Add("periodo", GetType(System.String))
            dtDatos.Columns.Add("fecha_ini", GetType(System.String))
            dtDatos.Columns.Add("fecha_fin", GetType(System.String))
            dtDatos.Columns.Add("cod_planta", GetType(System.String))
            dtDatos.Columns.Add("cod_clerk", GetType(System.String))
            dtDatos.Columns.Add("nombre_clerk", GetType(System.String))
            dtDatos.Columns.Add("cod_super", GetType(System.String))
            dtDatos.Columns.Add("nombre_super", GetType(System.String))
            dtDatos.Columns.Add("empleados", GetType(System.Int32))
            dtDatos.Columns.Add("confirmados", GetType(System.Int32))
            dtDatos.Columns.Add("avance", GetType(System.Double))
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("cod_planta"), dtDatos.Columns("cod_super")}

            Dim dtAnoPer As DataTable = sqlExecute("select TOP 1 * from ta.dbo.periodos where FECHA_INI='" & FechaSQL(RangoFInicial) & "' and FECHA_FIN='" & FechaSQL(RangoFFinal) & "'")
            If ((dtAnoPer.Columns.Contains("Error")) Or (Not dtAnoPer.Columns.Contains("Error") And dtAnoPer.Rows.Count = 0)) Then Exit Sub

            frmTrabajando.Show()
            Application.DoEvents()

            Dim Anio As String = IIf(IsDBNull(dtAnoPer.Rows(0).Item("ANO")), "", dtAnoPer.Rows(0).Item("ANO").ToString.Trim)
            Dim Per As String = IIf(IsDBNull(dtAnoPer.Rows(0).Item("PERIODO")), "", dtAnoPer.Rows(0).Item("PERIODO").ToString.Trim)

            Dim QP As String = "select reloj, nombres, cod_planta, cod_turno, cod_depto, cod_clase,isnull(cod_clerk, '') as cod_clerk, isnull(nombre_clerk, '') as nombre_clerk, isnull(cod_super, '') as cod_super, isnull(nombre_super, 'Sin Supervisor') as nombre_super from personalvw where cod_tipo = 'O' and alta <= '" & FechaSQL(RangoFFinal) & "' and (baja is null or baja >= '" & FechaSQL(RangoFInicial) & "') and cod_comp in ('002') and isnull(cod_super, '') <> '' and  cod_planta = '001' order by cod_clerk,reloj"
            Dim dtPersonalTodo As DataTable = sqlExecute(QP, "PERSONAL")

            For Each row As DataRow In dtPersonalTodo.Rows
                Application.DoEvents()

                Dim drow As DataRow = dtDatos.Rows.Find({row("cod_planta"), row("cod_super")})
                If drow Is Nothing Then
                    drow = dtDatos.NewRow
                    drow("ano") = Anio
                    drow("periodo") = Per
                    drow("fecha_ini") = RangoFInicial
                    drow("fecha_fin") = RangoFFinal

                    drow("cod_planta") = row("cod_planta")
                    drow("cod_clerk") = row("cod_clerk")
                    drow("nombre_clerk") = row("nombre_clerk")
                    drow("cod_super") = row("cod_super")
                    drow("empleados") = 1
                    drow("confirmados") = 0

                    dtDatos.Rows.Add(drow)
                Else
                    Dim empleados As Integer = drow("empleados")
                    drow("empleados") += 1
                End If

                Dim AnoPer As String = Anio & Per
                Dim dtConfirmado As DataTable = sqlExecute("select * from nomsem where ano + periodo = '" & AnoPer & "' and reloj = '" & row("reloj") & "' and fecha_firma is not null", "ta")
                If dtConfirmado.Rows.Count > 0 Then
                    Dim confirmados As Integer = drow("confirmados")
                    drow("confirmados") += 1
                End If

            Next

            Dim dSuper As DataTable = sqlExecute("select distinct cod_super, nombre, cod_clerk from super where cod_comp in ('002') order by cod_clerk")
            For Each row As DataRow In dtDatos.Rows
                Application.DoEvents()

                Try

                    row("nombre_super") = dSuper.Select("cod_super = '" & row("cod_super") & "'")(0)("nombre")
                Catch ex As Exception

                End Try

                row("avance") = (row("confirmados") / row("empleados")) * 100
            Next

            ActivoTrabajando = False
            frmTrabajando.Close()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "TA", ex.HResult, ex.Message)
            ActivoTrabajando = False
            frmTrabajando.Close()
        End Try
    End Sub

    Public Sub InfoRetPSG(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ", GetType(System.String))
            dtDatos.Columns.Add("NOMBRES", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_AREA", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_CLERK", GetType(System.String))

            For Each row As DataRow In dtInformacion.Rows
                Dim drow As DataRow = dtDatos.NewRow
                drow("RELOJ") = IIf(IsDBNull(row("RELOJ")), "", row("RELOJ").ToString.Trim)
                drow("NOMBRES") = IIf(IsDBNull(row("NOMBRES")), "", row("NOMBRES").ToString.Trim)
                drow("NOMBRE_AREA") = IIf(IsDBNull(row("NOMBRE_AREA")), "", row("NOMBRE_AREA").ToString.Trim)
                drow("NOMBRE_CLERK") = IIf(IsDBNull(row("NOMBRE_CLERK")), "", row("NOMBRE_CLERK").ToString.Trim)
                dtDatos.Rows.Add(drow)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "TA", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub TiempoextraAcumulado(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)


        Dim tipo_emp As String = ""
        Dim horas_extras As String = ""
        Dim extras_autorizadas As String = ""

        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
        dtDatos.Columns.Add("alta", Type.GetType("System.String"))
        dtDatos.Columns.Add("centro_costos", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_hora", Type.GetType("System.String"))
        dtDatos.Columns.Add("ano", Type.GetType("System.String"))
        dtDatos.Columns.Add("periodo", Type.GetType("System.String"))
        dtDatos.Columns.Add("horas_extras", Type.GetType("System.String"))
        dtDatos.Columns.Add("extras_autorizadas", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_cc", Type.GetType("System.String"))
        dtDatos.Columns.Add("clerk_nombre", Type.GetType("System.String"))

        For Each dr As DataRow In dtInformacion.Rows
            tipo_emp = IIf(IsDBNull(dr("cod_tipo")), "", dr("cod_tipo"))
            horas_extras = IIf(IsDBNull(dr("horas_extras")), "00:00", dr("horas_extras"))
            extras_autorizadas = IIf(IsDBNull(dr("extras_autorizadas")), "00:00", dr("extras_autorizadas"))
            If tipo_emp.Trim = "O" Then
                If horas_extras.Trim <> "00:00" Or extras_autorizadas.Trim <> "00:00" Then
                    If Not IsDBNull(dr("horas_extras")) Then
                        dtDatos.Rows.Add({dr("reloj"),
                                    dr("nombres"),
                                    dr("cod_tipo"),
                                    dr("alta"),
                                    dr("centro_costos"),
                                    dr("nombre_depto"),
                                    dr("nombre_super"),
                                    dr("cod_hora"),
                                    dr("ano"),
                                    dr("periodo"),
                                    dr("horas_extras"),
                                    dr("extras_autorizadas"),
                                    dr("nombre_cc"),
                                          dr("clerk_nombre")})
                    End If
                End If
            End If

        Next



    End Sub

    Public Sub genera_graficas_ausentismo(ByRef dtInformacion As DataTable)
        Dim dtDatos = New DataTable

        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_comp", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("centro_costos", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_area", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
        dtDatos.Columns.Add("dias", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("faltas", Type.GetType("System.Int32"))
        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj"), dtDatos.Columns("cod_comp"), dtDatos.Columns("cod_depto"), dtDatos.Columns("cod_super")}
        Dim _r As String = ""
        Dim _f As String = ""
        For Each row As DataRow In dtInformacion.Select("cod_clase in ('D', 'I') and cod_comp in ('610','002')", "reloj,fha_ent_hor")
            Dim reloj As String = row("reloj")
            Dim fha As String = IIf(IsDBNull(row("fha_ent_hor")), "", FechaSQL(row("fha_ent_hor")))
            Dim aus_real As String = RTrim(IIf(IsDBNull(row("ausentismo_real")), "", row("ausentismo_real")))
            Dim comentario As String = RTrim(IIf(IsDBNull(row("comentario")), "", row("comentario")))
            Dim descanso As Boolean = IIf(comentario.ToLower.Contains("desc"), True, False)
            Dim parcial As Boolean = False
            If reloj <> _r Then
                _r = reloj
                _f = fha

                parcial = False
            ElseIf fha = _f Then
                parcial = True
            Else
                _f = fha
                parcial = False
            End If

            If Not parcial And Not descanso Then
                Dim cod_comp As String = RTrim(IIf(IsDBNull(row("cod_comp")), "", row("cod_comp")))
                Dim cod_depto As String = RTrim(IIf(IsDBNull(row("cod_depto")), "", row("cod_depto")))
                Dim cod_super As String = RTrim(IIf(IsDBNull(row("cod_super")), "", row("cod_super")))
                Dim centro_costos As String = RTrim(IIf(IsDBNull(row("centro_costos")), "", row("centro_costos")))
                Dim drow As DataRow = dtDatos.Rows.Find({reloj, cod_comp, cod_depto, cod_super})
                If IsNothing(drow) Then
                    drow = dtDatos.NewRow

                    drow("reloj") = reloj
                    drow("cod_comp") = cod_comp
                    drow("cod_depto") = cod_depto
                    drow("cod_super") = cod_super
                    drow("centro_costos") = centro_costos

                    drow("dias") = 1
                    drow("faltas") = 0

                    dtDatos.Rows.Add(drow)
                Else
                    Dim dias As Integer = drow("dias")
                    drow("dias") = dias + 1
                End If
                Dim falta_permiso As Integer = 0
                Select Case aus_real.Trim
                    Case "FI"
                        falta_permiso = 1
                    Case "MAT"
                        falta_permiso = 1
                    Case "NAC"
                        falta_permiso = 1
                    Case "PGO"
                        falta_permiso = 1
                    Case "PSG"
                        falta_permiso = 1
                    Case "FUN"
                        falta_permiso = 1
                    Case "SU1"
                        falta_permiso = 1
                    Case "SU3"
                        falta_permiso = 1
                    Case "SU5"
                        falta_permiso = 1
                    Case "SU8"
                        falta_permiso = 1
                    Case "FJ"
                        falta_permiso = 1
                    Case Else
                        falta_permiso = 0
                End Select
                Dim faltas As Integer = drow("faltas")
                drow("faltas") = faltas + IIf(falta_permiso > 0, 1, 0)
            End If
        Next
        Dim dtSuper As DataTable = sqlExecute("select distinct cod_super, nombre from super")
        Dim dtDeptos As DataTable = sqlExecute("select distinct cod_depto, centro_costos from deptos")
        Dim dtCC As DataTable = sqlExecute("select distinct centro_costos, cod_area from c_costos")
        Dim dtAreas As DataTable = sqlExecute("select distinct cod_area, nombre from areas")
        For Each row As DataRow In dtDatos.Rows
            Try : row("nombre_super") = dtSuper.Select("cod_super = '" & row("cod_super") & "'")(0)("nombre") : Catch : row("nombre_super") = "" : End Try
            Try : row("cod_area") = dtCC.Select("centro_costos = '" & row("centro_costos") & "'")(0)("cod_area") : Catch : row("cod_area") = "" : End Try
            Try : row("nombre_area") = dtAreas.Select("cod_area = '" & row("cod_area") & "'")(0)("nombre") : Catch : row("nombre_area") = "" : End Try
        Next
        dtDatos = dtDatos.Select("", "cod_comp, nombre_super").CopyToDataTable

        Dim n As Integer = 2

        Try
            Dim saveFileDialog1 As New SaveFileDialog()

            saveFileDialog1.Filter = "Excel File|*.xlsx"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim File = New FileInfo(DireccionReportes & "Plantilla graficas ausentismo.xlsx")

                Using package As New ExcelPackage(File)
                    package.Load(New FileStream(DireccionReportes & "Plantilla graficas ausentismo.xlsx", FileMode.Open))

                    Dim workSheet As ExcelWorksheet = package.Workbook.Worksheets("Detalle")

                    For Each dr As DataRow In dtDatos.Rows
                        workSheet.Cells("A" & (n).ToString).Value = dr("reloj").ToString
                        workSheet.Cells("B" & (n).ToString).Value = dr("cod_comp").ToString
                        If dr("cod_comp").ToString.Equals("610") Then
                            workSheet.Cells("C" & (n).ToString).Value = "BRP"
                        ElseIf dr("cod_comp").ToString.Equals("002") Then
                            workSheet.Cells("C" & (n).ToString).Value = "OH"
                        Else
                            workSheet.Cells("C" & (n).ToString).Value = ""
                        End If
                        workSheet.Cells("D" & (n).ToString).Value = dr("nombre_super").ToString
                        workSheet.Cells("E" & (n).ToString).Value = dr("cod_super").ToString
                        workSheet.Cells("F" & (n).ToString).Value = dr("cod_area").ToString
                        workSheet.Cells("G" & (n).ToString).Value = dr("nombre_area").ToString
                        workSheet.Cells("H" & (n).ToString).Value = CInt(dr("dias").ToString)
                        workSheet.Cells("I" & (n).ToString).Value = CInt(dr("faltas").ToString)
                        n = n + 1
                    Next

                    package.SaveAs(New System.IO.FileInfo(saveFileDialog1.FileName.ToString()))
                End Using
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            MessageBox.Show("Ocurrio un error al generar el reporte de graficas ausentismo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub
    Public Function ausentismo_semanal3090() As String
        Try
            Dim file_name As String = ""

            Dim saveFileDialog1 As New SaveFileDialog()

            saveFileDialog1.Filter = "Excel File|*.xlsx"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True
            saveFileDialog1.FileName = "Reporte Faltas injustificadas 30 y 90 días.xlsx"
            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                ' contenido_ausentismo_semanal("Faltas injustificadas", "tipo_aus = 'FI'", wb, fecha_ini, fecha_fin)
                ' contenido_ausentismo_semanal("Ausentismo semanal", "", wb, fecha_ini, fecha_fin)
                contenido_ausentismo_semanal_fi30("Faltas injustificadas 30 días", "tipo_aus = 'FI'", wb, Date.Now.AddDays(-30), Date.Now)
                contenido_ausentismo_semanal_fi90("Faltas injustificadas 90 días (H01A-H01AA)", "tipo_aus = 'FI'", wb, Date.Now.AddDays(-90), Date.Now)

                archivo.SaveAs(New System.IO.FileInfo(saveFileDialog1.FileName))
            End If


            Return ""
        Catch ex As Exception
            Return ""
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Ausentismo Semanal", ex.HResult, ex.Message)
        End Try
    End Function
    Public Sub contenido_ausentismo_semanal_fi90(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, fecha_ini As Date, fecha_fin As Date)
        Try

            ' Reporte a detalle Excel
            Dim x As Integer = 1
            Dim y As Integer = 1

            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

            Dim dtTipoAus As DataTable = sqlExecute("select tipo_aus, rtrim(nombre) as nombre, color_letra, color_back from tipo_ausentismo", "TA")
            dtTipoAus.PrimaryKey = ({dtTipoAus.Columns("tipo_aus")})

            Dim dtEmpleadosJ1 As DataTable = sqlExecute("select distinct(reloj) as reloj from ausentismo where fecha between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "' and reloj in (select reloj from personal.dbo.personal where cod_comp = '610' and cod_tipo = 'O' and baja is null and nivel in ('H01A', 'H01AA')) " & IIf(filtro.Trim <> "", " and " & filtro, "") & "order by reloj asc", "TA")

            Dim celdas_encabezado = 10

            '-----ENCABEZADOS----------
            '**VALORES FIJOS

            hoja_excel.Cells(x, y).Value = "Reloj"
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 1).Value = "Id SF"
            hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 2).Value = "Nombre"
            hoja_excel.Cells(x, y + 2).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 3).Value = "Planta"
            hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 4).Value = "Horario"
            hoja_excel.Cells(x, y + 4).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 5).Value = "Compañia"
            hoja_excel.Cells(x, y + 5).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 6).Value = "Centro costos"
            hoja_excel.Cells(x, y + 6).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 7).Value = "Departamento"
            hoja_excel.Cells(x, y + 7).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 8).Value = "Nombre departamento"
            hoja_excel.Cells(x, y + 8).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 9).Value = "Tipo"
            hoja_excel.Cells(x, y + 9).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 10).Value = "Clase"
            hoja_excel.Cells(x, y + 10).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 11).Value = "Nivel"
            hoja_excel.Cells(x, y + 11).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 12).Value = "Supervisor"
            hoja_excel.Cells(x, y + 12).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 13).Value = "Alta"
            hoja_excel.Cells(x, y + 13).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 14).Value = "Baja"
            hoja_excel.Cells(x, y + 14).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 15).Value = "Area"
            hoja_excel.Cells(x, y + 15).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 16).Value = "Total"
            hoja_excel.Cells(x, y + 16).Style.Font.Bold = True
            x += 1

            '-----CONTENIDO----------
            For Each row As DataRow In dtEmpleadosJ1.Rows
                ' f = fecha_ini

                '**VALORES FIJOS
                hoja_excel.Cells(x, y).Value = row("reloj")
                Dim dtNombres As DataTable = sqlExecute("select * from personalvw where reloj = '" & row("reloj") & "'")
                If dtNombres.Rows.Count > 0 Then
                    hoja_excel.Cells(x, y + 1).Value = dtNombres.Rows(0)("sf_id")
                    hoja_excel.Cells(x, y + 2).Value = dtNombres.Rows(0)("nombres")
                    hoja_excel.Cells(x, y + 3).Value = dtNombres.Rows(0)("nombre_planta")
                    hoja_excel.Cells(x, y + 4).Value = dtNombres.Rows(0)("cod_hora")
                    hoja_excel.Cells(x, y + 5).Value = dtNombres.Rows(0)("compania")
                    hoja_excel.Cells(x, y + 6).Value = dtNombres.Rows(0)("centro_costos")
                    hoja_excel.Cells(x, y + 7).Value = dtNombres.Rows(0)("cod_depto")
                    hoja_excel.Cells(x, y + 8).Value = dtNombres.Rows(0)("nombre_depto")
                    hoja_excel.Cells(x, y + 9).Value = dtNombres.Rows(0)("cod_tipo")
                    hoja_excel.Cells(x, y + 10).Value = dtNombres.Rows(0)("cod_clase")
                    hoja_excel.Cells(x, y + 11).Value = dtNombres.Rows(0)("nivel")
                    hoja_excel.Cells(x, y + 12).Value = dtNombres.Rows(0)("nombre_super")

                    hoja_excel.Cells(x, y + 13).Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern
                    hoja_excel.Cells(x, y + 13).Value = Date.Parse(dtNombres.Rows(0)("alta"))
                    If IsDBNull(dtNombres.Rows(0)("baja")) Then
                        hoja_excel.Cells(x, y + 14).Value = ""
                    Else
                        hoja_excel.Cells(x, y + 14).Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern
                        hoja_excel.Cells(x, y + 14).Value = Date.Parse(dtNombres.Rows(0)("baja"))
                    End If

                    hoja_excel.Cells(x, y + 15).Value = dtNombres.Rows(0)("nombre_area")

                End If



                Dim dtSum As DataTable = sqlExecute("select * from ausentismo where reloj = '" & row("reloj") & "' and fecha between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "'" & IIf(filtro.Trim <> "", " and " & filtro, ""), "TA")
                hoja_excel.Cells(x, y + 16).Style.Font.Bold = True
                hoja_excel.Cells(x, y + 16).Value = dtSum.Rows.Count


                If dtSum.Rows.Count >= 1 Then
                    x += 1
                Else
                    hoja_excel.Cells(x, y + 1).Value = ""
                    hoja_excel.Cells(x, y + 2).Value = ""
                    hoja_excel.Cells(x, y + 3).Value = ""
                    hoja_excel.Cells(x, y + 4).Value = ""
                    hoja_excel.Cells(x, y + 5).Value = ""
                    hoja_excel.Cells(x, y + 6).Value = ""
                    hoja_excel.Cells(x, y + 7).Value = ""
                    hoja_excel.Cells(x, y + 8).Value = ""
                    hoja_excel.Cells(x, y + 9).Value = ""
                    hoja_excel.Cells(x, y + 10).Value = ""
                    hoja_excel.Cells(x, y + 11).Value = ""
                    hoja_excel.Cells(x, y + 12).Value = ""
                    hoja_excel.Cells(x, y + 13).Value = ""
                    hoja_excel.Cells(x, y + 14).Value = ""
                    hoja_excel.Cells(x, y + 15).Value = ""
                    hoja_excel.Cells(x, y + 16).Value = ""
                End If

            Next

            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Ausentismo Semanal", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub contenido_ausentismo_semanal_fi30(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, fecha_ini As Date, fecha_fin As Date)
        Try

            ' Reporte a detalle Excel
            Dim x As Integer = 1
            Dim y As Integer = 1

            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

            Dim dtTipoAus As DataTable = sqlExecute("select tipo_aus, rtrim(nombre) as nombre, color_letra, color_back from tipo_ausentismo", "TA")
            dtTipoAus.PrimaryKey = ({dtTipoAus.Columns("tipo_aus")})

            'Dim dtEmpleadosJ1 As DataTable = sqlExecute("select distinct(reloj) as reloj from ausentismo where fecha between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "' and reloj in (select reloj from personal.dbo.personal where cod_comp = '610' and cod_tipo = 'O' and baja is null) " & IIf(filtro.Trim <> "", " and " & filtro, "") & "order by reloj asc", "TA")
            Dim dtEmpleadosJ1 As DataTable = sqlExecute("select distinct(reloj) as reloj from ausentismo where fecha between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "' and reloj in (select reloj from personal.dbo.personal where cod_comp in ('610','002') and cod_tipo = 'O' and baja is null) " & IIf(filtro.Trim <> "", " and " & filtro, "") & "order by reloj asc", "TA")

            Dim celdas_encabezado = 10

            '-----ENCABEZADOS----------
            '**VALORES FIJOS

            hoja_excel.Cells(x, y).Value = "Reloj"
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 1).Value = "Id SF"
            hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 2).Value = "Nombre"
            hoja_excel.Cells(x, y + 2).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 3).Value = "Planta"
            hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 4).Value = "Horario"
            hoja_excel.Cells(x, y + 4).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 5).Value = "Compañia"
            hoja_excel.Cells(x, y + 5).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 6).Value = "Centro costos"
            hoja_excel.Cells(x, y + 6).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 7).Value = "Departamento"
            hoja_excel.Cells(x, y + 7).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 8).Value = "Nombre departamento"
            hoja_excel.Cells(x, y + 8).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 9).Value = "Tipo"
            hoja_excel.Cells(x, y + 9).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 10).Value = "Clase"
            hoja_excel.Cells(x, y + 10).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 11).Value = "Nivel"
            hoja_excel.Cells(x, y + 11).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 12).Value = "Supervisor"
            hoja_excel.Cells(x, y + 12).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 13).Value = "Alta"
            hoja_excel.Cells(x, y + 13).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 14).Value = "Baja"
            hoja_excel.Cells(x, y + 14).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 15).Value = "Area"
            hoja_excel.Cells(x, y + 15).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 16).Value = "Total"
            hoja_excel.Cells(x, y + 16).Style.Font.Bold = True
            x += 1

            '-----CONTENIDO----------
            For Each row As DataRow In dtEmpleadosJ1.Rows
                ' f = fecha_ini

                '**VALORES FIJOS
                hoja_excel.Cells(x, y).Value = row("reloj")
                Dim dtNombres As DataTable = sqlExecute("select * from personalvw where reloj = '" & row("reloj") & "'")
                If dtNombres.Rows.Count > 0 Then
                    hoja_excel.Cells(x, y + 1).Value = dtNombres.Rows(0)("sf_id")
                    hoja_excel.Cells(x, y + 2).Value = dtNombres.Rows(0)("nombres")
                    hoja_excel.Cells(x, y + 3).Value = dtNombres.Rows(0)("nombre_planta")
                    hoja_excel.Cells(x, y + 4).Value = dtNombres.Rows(0)("cod_hora")
                    hoja_excel.Cells(x, y + 5).Value = dtNombres.Rows(0)("compania")
                    hoja_excel.Cells(x, y + 6).Value = dtNombres.Rows(0)("centro_costos")
                    hoja_excel.Cells(x, y + 7).Value = dtNombres.Rows(0)("cod_depto")
                    hoja_excel.Cells(x, y + 8).Value = dtNombres.Rows(0)("nombre_depto")
                    hoja_excel.Cells(x, y + 9).Value = dtNombres.Rows(0)("cod_tipo")
                    hoja_excel.Cells(x, y + 10).Value = dtNombres.Rows(0)("cod_clase")
                    hoja_excel.Cells(x, y + 11).Value = dtNombres.Rows(0)("nivel")
                    hoja_excel.Cells(x, y + 12).Value = dtNombres.Rows(0)("nombre_super")

                    hoja_excel.Cells(x, y + 13).Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern
                    hoja_excel.Cells(x, y + 13).Value = Date.Parse(dtNombres.Rows(0)("alta"))
                    If IsDBNull(dtNombres.Rows(0)("baja")) Then
                        hoja_excel.Cells(x, y + 14).Value = ""
                    Else
                        hoja_excel.Cells(x, y + 14).Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern
                        hoja_excel.Cells(x, y + 14).Value = Date.Parse(dtNombres.Rows(0)("baja"))
                    End If

                    hoja_excel.Cells(x, y + 15).Value = dtNombres.Rows(0)("nombre_area")

                End If



                Dim dtSum As DataTable = sqlExecute("select * from ausentismo where reloj = '" & row("reloj") & "' and fecha between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "'" & IIf(filtro.Trim <> "", " and " & filtro, ""), "TA")
                hoja_excel.Cells(x, y + 16).Style.Font.Bold = True
                hoja_excel.Cells(x, y + 16).Value = dtSum.Rows.Count


                If dtSum.Rows.Count >= 4 Then
                    x += 1
                Else
                    hoja_excel.Cells(x, y + 1).Value = ""
                    hoja_excel.Cells(x, y + 2).Value = ""
                    hoja_excel.Cells(x, y + 3).Value = ""
                    hoja_excel.Cells(x, y + 4).Value = ""
                    hoja_excel.Cells(x, y + 5).Value = ""
                    hoja_excel.Cells(x, y + 6).Value = ""
                    hoja_excel.Cells(x, y + 7).Value = ""
                    hoja_excel.Cells(x, y + 8).Value = ""
                    hoja_excel.Cells(x, y + 9).Value = ""
                    hoja_excel.Cells(x, y + 10).Value = ""
                    hoja_excel.Cells(x, y + 11).Value = ""
                    hoja_excel.Cells(x, y + 12).Value = ""
                    hoja_excel.Cells(x, y + 13).Value = ""
                    hoja_excel.Cells(x, y + 14).Value = ""
                    hoja_excel.Cells(x, y + 15).Value = ""
                    hoja_excel.Cells(x, y + 16).Value = ""
                End If

            Next

            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Ausentismo Semanal", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub ReporteChecadas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim file_name As String = ""

            Dim saveFileDialog1 As New SaveFileDialog()

            saveFileDialog1.Filter = "Excel File|*.xlsx"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True
            saveFileDialog1.FileName = "Reporte de checadas.xlsx"
            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook



                Dim dtinfo_checadas As DataTable = sqlExecute("select * from reloj_qro where nuserid <> '0' and fecha between '" & FechaInicial & "' and '" & FechaFinal & "' and nReaderIdn not in ('56413','82844','82899','90958') order by  nuserid asc, fecha_hora desc", "TA")


                ' contenido_ausentismo_semanal("Faltas injustificadas", "tipo_aus = 'FI'", wb, fecha_ini, fecha_fin)
                ' contenido_ausentismo_semanal("Ausentismo semanal", "", wb, fecha_ini, fecha_fin)
                rep_checadas_asist("Asistencia", "", wb, dtInformacion)
                rep_checadas("Checadas", "", wb, dtinfo_checadas)

                archivo.SaveAs(New System.IO.FileInfo(saveFileDialog1.FileName))
            End If






        Catch ex As Exception

            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ReporteChecadas", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub rep_checadas_asist(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, ByRef dtinfo As DataTable)
        ' Reporte a detalle Excel
        Dim x As Integer = 1
        Dim y As Integer = 1
        Try
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

            hoja_excel.Cells(x, y).Value = "Reloj"
            hoja_excel.Cells(x, y).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 1).Value = "Nombre"
            hoja_excel.Cells(x, y + 1).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 2).Value = "Centro costos"
            hoja_excel.Cells(x, y + 2).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 3).Value = "Area"
            hoja_excel.Cells(x, y + 3).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 4).Value = "Supervisor"
            hoja_excel.Cells(x, y + 4).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 5).Value = "Horario"
            hoja_excel.Cells(x, y + 5).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 6).Value = "Hora entrada"
            hoja_excel.Cells(x, y + 6).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 7).Value = "Hora salida"
            hoja_excel.Cells(x, y + 7).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 8).Value = "fecha_entrada"
            hoja_excel.Cells(x, y + 8).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 9).Value = "fecha_salida"
            hoja_excel.Cells(x, y + 9).Style.Font.Bold = True


            x = x + 1
            For Each dr As DataRow In dtinfo.Rows
                hoja_excel.Cells(x, y).Value = dr("reloj")
                hoja_excel.Cells(x, y + 1).Value = IIf(IsDBNull(dr("nombres")), "", dr("nombres"))
                hoja_excel.Cells(x, y + 2).Value = IIf(IsDBNull(dr("centro_costos")), "", dr("centro_costos"))
                hoja_excel.Cells(x, y + 3).Value = IIf(IsDBNull(dr("cc_nombre_area")), "", dr("cc_nombre_area"))
                hoja_excel.Cells(x, y + 4).Value = IIf(IsDBNull(dr("nombre_super")), "", dr("nombre_super"))
                hoja_excel.Cells(x, y + 5).Value = IIf(IsDBNull(dr("cod_hora")), "", dr("cod_hora"))
                hoja_excel.Cells(x, y + 6).Value = IIf(IsDBNull(dr("entro")), "", dr("entro"))
                hoja_excel.Cells(x, y + 7).Value = IIf(IsDBNull(dr("salio")), "", dr("salio"))

                If Not IsDBNull(dr("fecha_entro")) Then
                    hoja_excel.Cells(x, y + 8).Value = FechaSQL(Date.Parse(dr("fecha_entro")))
                Else
                    hoja_excel.Cells(x, y + 8).Value = ""
                End If
                If Not IsDBNull(dr("fecha_salio")) Then
                    hoja_excel.Cells(x, y + 9).Value = FechaSQL(Date.Parse(dr("fecha_salio")))
                Else
                    hoja_excel.Cells(x, y + 8).Value = ""
                End If
                x = x + 1
            Next
            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

        Catch ex As Exception

            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ReporteChecadas", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub rep_checadas(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, ByRef dtinfo As DataTable)
        Dim x As Integer = 1
        Dim y As Integer = 1
        Try
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

            hoja_excel.Cells(x, y).Value = "ID"
            hoja_excel.Cells(x, y).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 1).Value = "Nombre"
            hoja_excel.Cells(x, y + 1).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 2).Value = "Fecha"
            hoja_excel.Cells(x, y + 2).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 3).Value = "Hora"
            hoja_excel.Cells(x, y + 3).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 4).Value = "Dispositivo"
            hoja_excel.Cells(x, y + 4).Style.Font.Bold = True



            x = x + 1
            For Each dr As DataRow In dtinfo.Rows
                hoja_excel.Cells(x, y).Value = dr("nUserID")
                hoja_excel.Cells(x, y + 1).Value = IIf(IsDBNull(dr("sUserName")), "", dr("sUserName"))

                hoja_excel.Cells(x, y + 2).Value = FechaSQL(Date.Parse(dr("fecha")))
                hoja_excel.Cells(x, y + 3).Value = IIf(IsDBNull(dr("hora")), "", dr("hora").ToString)
                hoja_excel.Cells(x, y + 4).Value = IIf(IsDBNull(dr("nReaderIdn")), "", dr("nReaderIdn").ToString)

                x = x + 1
            Next
            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

        Catch ex As Exception

            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ReporteChecadas", ex.HResult, ex.Message)
        End Try
    End Sub

    '==Modificada 3junio2021    Ernesto
    Public Sub ChecadasXDia(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Try


            Dim fr As New frmRangoFechas
            fr.frmRangoFechas_fecha_ini = Today.Date
            fr.frmRangoFechas_fecha_fin = Today.Date
            fr.ShowDialog()

            If FechaInicial = Nothing Then
                dtDatos = sqlExecute("select h.reloj,p.nombres,p.nombre_tipoemp,p.nombre_horario,p.alta,p.baja,h.dia,h.fecha,h.hora from ta.dbo.hrs_brt h left join personal.dbo.personalvw p on h.reloj=p.reloj where 1=2", "TA")
            Else
                dtDatos = sqlExecute("select h.reloj,p.nombres,p.nombre_tipoemp,p.nombre_horario,p.alta,p.baja,h.dia,h.fecha,h.hora from ta.dbo.hrs_brt h left " & _
                                     "join personal.dbo.personalvw p on h.reloj=p.reloj where fecha between '" & _
                                     FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'", "TA")
            End If

            '== Filtro para el usuario      3jun2021        Ernesto
            Dim dtTemp As New DataTable
            dtTemp = dtDatos.Clone
            For Each drow As DataRow In dtDatos.Rows
                Dim rj As String = ""
                rj = drow("reloj").ToString.Trim
                If (dtInformacion.Select("reloj='" & rj & "'").Count > 0) Then
                    dtTemp.ImportRow(drow)
                End If
            Next
            dtDatos = dtTemp.Copy

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Checadas por día", ex.HResult, ex.Message)
        End Try

    End Sub

    '----------------------------------------------------------ANTONIO --------------------------------------------------------
    '==Modificado           25nov2021           Ernesto
    Public Sub ExcelAsistenciaTA(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, nombreReporte As String)
        Try
            '== Dialogo para seleccionar información de empresas            25nov2021           Ernesto
            '  Dim frm_planta As New frmSeleccionaPlanta

            ' If frm_planta.ShowDialog = DialogResult.OK Then

            '== Combinación de info de plantas                  25nov2021           Ernesto
            Dim dtInfo As DataTable = dtInformacion.Clone

            '== 12ene2021
            Try : dtInfo = FiltroDtInfo(dtInformacion, dtInfoPlanta2, selecPlantaRep) : Catch ex As Exception : End Try

            '== Funcion principal
            Dim sfd As New SaveFileDialog

            '---Se desactiva rango de fechas
            'Dim frm_fechas As New frmRangoFechas
            'frm_fechas.Text = "Filtrar fecha para Registro de Asistencia"
            'frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 12)
            'frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>FECHAS PARA ASISTENCIAS</b></font>
            'frm_fechas.frmRangoFechas_fecha_ini = RangoFInicial
            'frm_fechas.frmRangoFechas_fecha_fin = RangoFFinal
            'frm_fechas.ShowDialog()

            'Dim fecha_ini As Date = frm_fechas.frmRangoFechas_fecha_ini
            'Dim fecha_fin As Date = frm_fechas.frmRangoFechas_fecha_fin

            Dim fecha_ini As Date = RangoFInicial
            Dim fecha_fin As Date = RangoFFinal

            'Dim periodo_actual As String = ""

            'Dim dtPeriodoActual As DataTable = sqlExecute("select * from periodos where '" & FechaInicial & "' between fecha_ini and fecha_fin and isnull(periodo_especial, 0) <> 1", "TA")
            'If dtPeriodoActual.Rows.Count > 0 Then
            '    periodo_actual = dtPeriodoActual.Rows(0)("ano") & dtPeriodoActual.Rows(0)("periodo")

            '    Dim periodo_analisis As String = dtPeriodoActual.Rows(0)("ano") & dtPeriodoActual.Rows(0)("periodo")

            sfd.DefaultExt = ".xlsx"
            sfd.FileName = "Excel Registro De Asistencias.xlsx"

            '--Modificado       abr/21  Ernesto
            If nombreReporte = "Detalle Horas trabajadas reales (catorcenales)" Then
                sfd.FileName = "Excel Registro De Asistencias Catorcenales.xlsx"
            End If

            sfd.OverwritePrompt = True
            If sfd.ShowDialog() = DialogResult.OK Then

                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                '--CASOS PARA REPORTE       feb/21      ernesto
                Select Case nombreReporte
                    Case "Excel Registro de Asistencia"
                        ExcelRegistroAsistencia("Excel registro de asistencia", "", wb, fecha_ini, fecha_fin, dtInfo)                   '== La combinacion de info solo aplicara a este reporte         25nov2021
                    Case "Detalle Horas trabajadas reales (catorcenales)"
                        ExcelRegistroAsistenciaCatorcenal("Detalle Horas trabajadas reales (catorcenales)", "", wb, fecha_ini, fecha_fin, dtInformacion)
                End Select

                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))

                '== Convertir a PDF  -  Ernesto  -  13junio2022
                '---2023-06-22: Perfil de asist no puede generar en PDF
                '---- 2024-04-09: Se deshabilita el pdf
                'If Not Perfil.Contains("ASIST") Then ConvertirExcelPDF(sfd.FileName)

                MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

            '  End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "excel detalle de asist", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Función que convierte un excel a pdf.
    ''' Autor: Ernesto G.  Fecha: 13 junio 2022.
    ''' </summary>
    ''' <param name="ruta">Ruta de guardado</param>
    ''' <remarks></remarks>
    Public Sub ConvertirExcelPDF(ruta As String)
        Dim excelApp As New Microsoft.Office.Interop.Excel.Application
        Dim ExcelDoc As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim SalidaDoc As String

        Try
            '== Abre la ruta del excel
            ExcelDoc = excelApp.Workbooks.Open(ruta)
            SalidaDoc = System.IO.Path.ChangeExtension(ruta, "pdf")

            '== Conversión del archivo
            If Not ExcelDoc Is Nothing Then
                ExcelDoc.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, SalidaDoc, Excel.XlFixedFormatQuality.xlQualityStandard, True, True)
            End If

        Catch ex As Exception
        Finally

            '== Libera memoria
            If Not ExcelDoc Is Nothing Then
                ExcelDoc.Close(False)
                releaseObject(ExcelDoc)
                ExcelDoc = Nothing
            End If
            If Not excelApp Is Nothing Then
                excelApp.Quit()
                releaseObject(excelApp)
                excelApp = Nothing
            End If

        End Try
    End Sub
    '------------------------------------------------------FIN ANTONIO---------------------------------------------------------

    '===Reporte de horas totales para los empleados catorcenales        -       Ernesto     Abril 2021
    Public Sub ExcelRegistroAsistenciaCatorcenal(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, fecha_ini As Date, fecha_fin As Date, dtInformacion As DataTable)
        Try

            '== Actualiza estatus inicio        6Oct2021
            ActualizaEstatusTabla("TA.dbo.reportes_recientes", "estatus_inicio", Date.Now, "WHERE Usuario='" & Usuario & "' and nombre='" & _varNomReport & "'")

            ' Reporte a detalle Excel
            Dim x As Integer = 1
            Dim y As Integer = 1
            Dim yy As Integer = 0
            Dim ContadorFaltas As Integer = 0
            Dim ContadorAsistencia As Integer = 0
            Dim FechaBak As Date = fecha_ini
            Dim dtRescataData As New DataTable
            Dim FechaIniInicio As Date = fecha_ini
            Dim FechaFinInicio As Integer
            Dim MesEspanol As String = 0
            Dim dtSacaFIDeAus As New DataTable

            '-- Para los catorcenales
            Dim dtHorasEntradayTotal As New DataTable
            Dim dtCatocernales As New DataTable
            Dim suma_horas As Double = 0.0
            Dim total_horas As String = ""
            Dim lista_HrsTotales As New List(Of String)
            Dim listaRelojes As New List(Of String)
            Dim contador As Integer = 0
            Dim var_Y As Integer = 0
            Dim newInicio As Date

            Dim f As Date = FechaSQL(fecha_ini)
            Dim fSuplente As Date


            Dim diff As Integer = DateDiff(DateInterval.Month, fecha_ini, fecha_fin)
            Dim Ciclos As Integer = diff

            diff += 1

            For z As Integer = 0 To diff - 1
                x = 1
                y = 1

                f = FechaIniInicio
                '--Si abarca mas de un mes  Abril 2021 Ernesto
                If z > 0 And diff > 0 Then
                    FechaIniInicio = newInicio.AddDays(1)
                    f = newInicio.AddDays(1)
                End If

                If FechaIniInicio.Month = 1 Then
                    MesEspanol = "ENERO"
                ElseIf FechaIniInicio.Month = 2 Then
                    MesEspanol = "FEBRERO"
                ElseIf FechaIniInicio.Month = 3 Then
                    MesEspanol = "MARZO"
                ElseIf FechaIniInicio.Month = 4 Then
                    MesEspanol = "ABRIL"
                ElseIf FechaIniInicio.Month = 5 Then
                    MesEspanol = "MAYO"
                ElseIf FechaIniInicio.Month = 6 Then
                    MesEspanol = "JUNIO"
                ElseIf FechaIniInicio.Month = 7 Then
                    MesEspanol = "JULIO"
                ElseIf FechaIniInicio.Month = 8 Then
                    MesEspanol = "AGOSTO"
                ElseIf FechaIniInicio.Month = 9 Then
                    MesEspanol = "SEPTIEMBRE"
                ElseIf FechaIniInicio.Month = 10 Then
                    MesEspanol = "OCTUBRE"
                ElseIf FechaIniInicio.Month = 11 Then
                    MesEspanol = "NOVIEMBRE"
                ElseIf FechaIniInicio.Month = 12 Then
                    MesEspanol = "DICIEMBRE"
                End If
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(MesEspanol & " ASISTENCIA")
                Dim celdas_encabezado = 13
                If dtRescataData.Columns.Count = 0 Then
                Else
                    dtRescataData.Columns.Clear()
                End If


                '-----ENCABEZADOS----------
                '**VALORES FIJOS

                Dim ultimodía As Date = DateSerial(FechaIniInicio.Year, FechaIniInicio.Month + 1, 0)

                '---Agregado para tomar un nuevo inicio en caso de que sean mas de un mes       abril 2021      Ernesto
                If diff > 0 Then
                    newInicio = ultimodía
                End If


                Dim FechaEnF As Date

                dtRescataData.Columns.Add("Cod_Planta", Type.GetType("System.String"))

                hoja_excel.Cells(x, y).Value = "Reloj"
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(180, 198, 231))
                dtRescataData.Columns.Add("Reloj", Type.GetType("System.String"))

                y += 1
                hoja_excel.Cells(x, y).Value = "Nombre"
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(180, 198, 231))
                dtRescataData.Columns.Add("Nombre", Type.GetType("System.String"))

                y += 1
                hoja_excel.Cells(x, y).Value = "Fecha Ingreso"
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(180, 198, 231))
                dtRescataData.Columns.Add("Fecha Ingreso", Type.GetType("System.String"))

                y += 1
                hoja_excel.Cells(x, y).Value = "Departamento"
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(180, 198, 231))
                dtRescataData.Columns.Add("Departamento", Type.GetType("System.String"))

                y += 1
                hoja_excel.Cells(x, y).Value = "Puesto"
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(180, 198, 231))
                dtRescataData.Columns.Add("Puesto", Type.GetType("System.String"))

                y += 1
                hoja_excel.Cells(x, y).Value = "Horario"
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(180, 198, 231))
                dtRescataData.Columns.Add("Horario", Type.GetType("System.String"))

                y += 1
                hoja_excel.Cells(x, y).Value = "Nombre Horario"
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(180, 198, 231))
                dtRescataData.Columns.Add("Nombre Horario", Type.GetType("System.String"))

                'Genera las fechas como columnas, para posteriormente clasificar asistencia o ausencia****************************************************************************************************************************************
                celdas_encabezado = y + 1
                While f <= fecha_fin And f <= ultimodía
                    Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))
                    hoja_excel.Cells(x, celdas_encabezado + dif).Value = f.ToString("dd-MMM-yyyy")
                    hoja_excel.Cells(x, celdas_encabezado + dif).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    hoja_excel.Cells(x, celdas_encabezado + dif).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(180, 198, 231))
                    hoja_excel.Cells(x, celdas_encabezado + dif).Style.Font.Bold = True
                    dtRescataData.Columns.Add(f, Type.GetType("System.String"))
                    f = f.AddDays(1)

                    '===================================== PARA LAS HORAS TOTALES DE LOS CATORCENALES =========================
                    '--Columna horas totales        Abril 7     Ernesto
                    If f > ultimodía Or f > fecha_fin Then
                        hoja_excel.Cells(x, celdas_encabezado + dif + 1).Value = "Horas totales"
                        hoja_excel.Cells(x, celdas_encabezado + dif + 1).Style.Font.Bold = True
                        hoja_excel.Cells(x, celdas_encabezado + dif + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x, celdas_encabezado + dif + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(169, 208, 142))
                        dtRescataData.Columns.Add("Horas totales", Type.GetType("System.String"))

                        '---Solo toma los catorenales presentes en ese periodo
                        dtCatocernales = sqlExecute("select RTRIM(RELOJ) as reloj, RTRIM(tipo_periodo) as tipo_per from PERSONAL.dbo.personal where tipo_periodo = 'C' " & _
                                                                "and RELOJ in (select RELOJ from TA.dbo.asist where FECHA_ENTRO between '" & FechaSQL(FechaIniInicio) & "' and '" & FechaSQL(f.AddDays(-1)) & "')")
                        Dim bandera As String = ""

                        '--Llenar con horas totales de cada empleado        Ernesto
                        For Each fila As DataRow In dtInformacion.Rows

                            If bandera <> fila.Item("reloj").ToString.Trim Then
                                bandera = fila.Item("reloj").ToString.Trim
                                For Each cat As DataRow In dtCatocernales.Select("reloj='" & fila.Item("reloj") & "'")
                                    listaRelojes.Add(fila.Item("reloj").ToString.Trim)
                                    dtHorasEntradayTotal = sqlExecute("select * from TA.dbo.asist where RELOJ='" & fila.Item("reloj") & "' and FECHA_ENTRO between '" & FechaSQL(FechaIniInicio) & "' and '" & FechaSQL(f.AddDays(-1)) & "'")
                                    '-- Se obtienen las horas trabajadas de cada dia y se van acumulando
                                    For Each hrs As DataRow In dtHorasEntradayTotal.Rows
                                        suma_horas = suma_horas + HtoD(hrs("HORAS"))
                                    Next

                                    '-- Se almacenan las horas totales para asignarlas a la tabla correspondiente mas adelante
                                    total_horas = DtoH(suma_horas)
                                    lista_HrsTotales.Add(total_horas)
                                    suma_horas = 0.0
                                    total_horas = ""
                                Next
                            End If
                        Next
                    End If
                    '===================================== PARA LAS HORAS TOTALES DE LOS CATORCENALES =========================
                End While
                'FIN Genera las fechas como columnas, para posteriormente clasificar asistencia o ausencia****************************************************************************************************************************************

                'hoja_excel.Cells(x, 1 + celdas_encabezado + DateDiff(DateInterval.Day, fecha_ini, fecha_fin)).Value = "Total"
                'hoja_excel.Cells(x, 1 + celdas_encabezado + DateDiff(DateInterval.Day, fecha_ini, fecha_fin)).Style.Font.Bold = True
                x += 1

                '-----CONTENIDO----------

                Dim reloj_tmp As String = ""

                y = 1
                Dim dtNombres As DataTable
                Dim Renglon As DataRow = dtRescataData.NewRow()

                '-- Trabaja con los empleados catorcenales solamente        abril 8 
                For Each row As DataRow In dtInformacion.Select("", "reloj")

                    If reloj_tmp = row("reloj") Then
                        Continue For
                    Else
                        reloj_tmp = row("reloj")
                    End If

                    '--Aquí se delimita solo a los catorcenales
                    Dim catorcenal As String = ""
                    Dim dtCatorcenal As DataTable = sqlExecute("select RTRIM(RELOJ) as reloj, RTRIM(tipo_periodo) as tipo from PERSONAL.dbo.personal where tipo_periodo = 'C' " & _
                                                                "and RELOJ in (select RELOJ from TA.dbo.asist where FECHA_ENTRO between '" & FechaSQL(FechaIniInicio) & "' and '" & FechaSQL(f.AddDays(-1)) & "')")

                    For Each cat As DataRow In dtCatorcenal.Select("reloj='" & reloj_tmp & "'")
                        catorcenal = cat("tipo")
                    Next

                    If catorcenal = "C" Then

                        f = FechaIniInicio

                        'ASIGNA LOS VALORES CONSULTADOS DIRECTAMENTE DE LOS EMPLEADOS**********************************************************************************************************

                        hoja_excel.Cells(x, y).Value = row("reloj")
                        Renglon("Reloj") = row("reloj")
                        dtNombres = sqlExecute("select reloj,reloj_alt, nombres, cod_clase, cod_comp, cod_planta, alta, baja, nombre_planta, cod_depto, nombre_depto, cod_turno, nombre_super,(SELECT TOP 1 cod_hora FROM TA.dbo.asist " & _
                                                            "WHERE RELOJ = '" & row("reloj") & "' AND FECHA_ENTRO BETWEEN '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "') AS 'cod_hora', " & _
                                                            "(SELECT NOMBRE FROM PERSONAL.DBO.horarios WHERE COD_HORA = (SELECT top 1 cod_hora FROM TA.dbo.asist WHERE RELOJ = '" & row("reloj") & _
                                                            "' AND FECHA_ENTRO BETWEEN '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "')) AS 'nombre_horario', nombre_puesto from personalvw where reloj = '" & row("reloj") & "'")

                        If dtNombres.Rows.Count > 0 Then

                            Renglon("Cod_Planta") = dtNombres.Rows(0)("cod_planta")

                            y += 1
                            hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("nombres")
                            Renglon("Nombre") = dtNombres.Rows(0)("nombres")
                            y += 1
                            hoja_excel.Cells(x, y).Value = Date.Parse(dtNombres.Rows(0)("alta")).ToShortDateString
                            Renglon("Fecha Ingreso") = Date.Parse(dtNombres.Rows(0)("alta")).ToShortDateString

                            y += 1
                            hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("nombre_depto")
                            Renglon("Departamento") = dtNombres.Rows(0)("nombre_depto")

                            y += 1
                            hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("nombre_puesto")
                            Renglon("Puesto") = dtNombres.Rows(0)("nombre_puesto")

                            y += 1
                            hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("cod_hora")
                            Renglon("Horario") = dtNombres.Rows(0)("cod_hora")

                            y += 1
                            hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("nombre_horario")
                            Renglon("Nombre Horario") = dtNombres.Rows(0)("nombre_horario")

                        End If

                        celdas_encabezado = y
                        y = 1
                        'BUSCA EL TIPO DE AUSENCIA****************************************************************************************************************************************
                        '== Se quito la restriccion para que se genere en cualquier fecha del año       26nov2021
                        While ((f <= fecha_fin))
                            'VERIFICA SI EL EMPLEADO ES VIGENTE********************************************************************************************************************
                            Dim dtVerificarSiEsVigente As DataTable = sqlExecute("select asist.*, PERSONAL.ALTA, PERSONAL.BAJA  from ta.dbo.asist left join PERSONAL.dbo.personal on asist.reloj = personal.reloj where PERSONAL.reloj = '" & row("reloj") & "' AND ALTA <= '" & FechaSQL(f) & "'  AND (BAJA is null or BAJA >= '" & FechaSQL(f) & "')")
                            If dtVerificarSiEsVigente.Rows.Count > 0 Then

                                'VERIFICA SI SE ENCUENTRA EN LA TABLA ASISTENCIA POR FECHA Y RELOJ********************************************************************************************************************
                                Dim dtAusentismo As DataTable = sqlExecute("select rtrim(tipo_aus) as tipo_aus, rtrim(entro) as entro, rtrim(salio) as salio from asist where reloj = '" & row("reloj") & "' and fecha_entro = '" & FechaSQL(f) & "' " & IIf(filtro.Trim <> "", " and " & filtro, ""), "TA")
                                If dtAusentismo.Rows.Count > 0 Then

                                    'VERIFICA SI TIENE ALGUN TIPO DE AUSENTISMO********************************************************************************************************************
                                    Dim tipo_aus As String = Convert.ToString(dtAusentismo.Rows(0)("tipo_aus"))
                                    If tipo_aus <> "" Then

                                        Dim dtObtieneTipoAus As DataTable = sqlExecute("select rtrim(nombre) as nombre, color_letra, color_back from tipo_ausentismo WHERE rtrim(tipo_aus) = '" + tipo_aus + "'", "TA")

                                        If tipo_aus = "FES" And (dtAusentismo.Rows(0)("entro") <> "" Or dtAusentismo.Rows(0)("salio") <> "") Then
                                            Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))

                                            '--- Para la ultima columna
                                            var_Y = y + celdas_encabezado + dif

                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = "FEST TRAB"
                                            Renglon(f) = "FEST TRAB"
                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Bold = False
                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(dtObtieneTipoAus.Rows(0)("color_back")))
                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Color.SetColor(Color.FromArgb(dtObtieneTipoAus.Rows(0)("color_letra")))
                                        Else
                                            'SI HUBO ALGUN TIPO DE AUSENTISMO, LO BUSCA Y LO DESCRIBE DESDE LA BASE DE DATOS*******************************************************************************************************************
                                            If tipo_aus = "FI" Then
                                                dtSacaFIDeAus = sqlExecute("select * from ausentismo where RELOJ = '" & row("reloj") & "' AND fecha = '" & f & "'", "TA")
                                                If dtSacaFIDeAus.Rows.Count <> 0 Then
                                                    Dim zz As String = dtSacaFIDeAus.Rows(0)("TIPO_AUS")
                                                    If zz <> tipo_aus Then
                                                        tipo_aus = zz
                                                        dtObtieneTipoAus = sqlExecute("select rtrim(nombre) as nombre, color_letra, color_back from tipo_ausentismo WHERE rtrim(tipo_aus) = '" + tipo_aus + "'", "TA")
                                                    End If
                                                End If
                                            End If
                                            dtSacaFIDeAus = sqlExecute("select * from ausentismo where RELOJ = '" & row("reloj") & "' AND fecha = '" & f & "'", "TA")
                                            Dim segundocomentario As String
                                            If dtSacaFIDeAus.Rows.Count > 0 Then
                                                segundocomentario = dtSacaFIDeAus.Rows(0)("SUBCLASI").ToString.Trim
                                            Else
                                                segundocomentario = ""
                                            End If
                                            Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))

                                            '--- Para la ultima columna
                                            var_Y = y + celdas_encabezado + dif

                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = tipo_aus
                                            Renglon(f) = tipo_aus
                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).AddComment(dtObtieneTipoAus.Rows(0)("nombre") + ", " + segundocomentario.Trim, "Detalle")
                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Bold = False
                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(dtObtieneTipoAus.Rows(0)("color_back")))
                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Color.SetColor(Color.FromArgb(dtObtieneTipoAus.Rows(0)("color_letra")))
                                        End If
                                    Else
                                        'ASIGNA 'DESC TRAB' De acuerdo a los comentarios de la tabla ASIST****************************************************************************************************************************************
                                        Dim dtDescansoTrabajado As DataTable = sqlExecute("select * from ta.dbo.asist where reloj = '" & row("reloj") & "' and fecha_entro = '" & FechaSQL(f) & "' and COMENTARIO LIKE '%DESCANSO%'")
                                        If dtDescansoTrabajado.Rows.Count > 0 Then
                                            Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))

                                            '--- Para la ultima columna
                                            var_Y = y + celdas_encabezado + dif

                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = "DESC TRAB"
                                            Renglon(f) = "DESC TRAB"
                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Bold = False
                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                            hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255))
                                        Else
                                            'ASIGNA 'ASIS' A LOS QUE TENGAN POR LO MENOS HORARIO DE ENTRADA O DE SALIDA****************************************************************************************************************************************

                                            '--Anadido horas        Ernesto     abril 6
                                            Dim dtasist As DataTable = sqlExecute("select asist.entro,asist.salio, PERSONAL.ALTA, PERSONAL.BAJA, asist.horas " & _
                                                                                 "from ta.dbo.asist left join PERSONAL.dbo.personal on asist.reloj = personal.reloj where PERSONAL.reloj = '" & row("reloj") & "' and fecha_entro = '" & FechaSQL(f) & "'" & _
                                                                                 " AND fecha_entro >= ALTA AND (BAJA is null or fecha_entro <= BAJA) AND (SALIO <> '' or ENTRO <> '') and TIPO_AUS is NULL")

                                            If dtasist.Rows.Count > 0 Then
                                                Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))

                                                '--- Para la ultima columna
                                                var_Y = y + celdas_encabezado + dif

                                                'hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = IIf(IsDBNull(dtasist.Rows(0).Item("entro")), "", dtasist.Rows(0).Item("entro")) & " - " & IIf(IsDBNull(dtasist.Rows(0).Item("salio")), "", dtasist.Rows(0).Item("salio"))
                                                'Renglon(f) = IIf(IsDBNull(dtasist.Rows(0).Item("entro")), "", dtasist.Rows(0).Item("entro")) & " - " & IIf(IsDBNull(dtasist.Rows(0).Item("salio")), "", dtasist.Rows(0).Item("salio"))
                                                hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = IIf(IsDBNull(dtasist.Rows(0).Item("horas")), "", dtasist.Rows(0).Item("horas"))
                                                Renglon(f) = IIf(IsDBNull(dtasist.Rows(0).Item("horas")), "", dtasist.Rows(0).Item("horas"))
                                                hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Bold = False
                                                hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                                hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255))
                                            End If
                                        End If
                                    End If
                                Else
                                    'SI NO NUBO UNA FECHA DE ENTRADA LO TOMA COMO DESCANSO****************************************************************************************************************************************
                                    Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))

                                    '--- Para la ultima columna
                                    var_Y = y + celdas_encabezado + dif

                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = "DESC"
                                    Renglon(f) = "DESC"
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Bold = False
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255))

                                End If

                            Else
                                '=== Si el empleado fue dado de baja a mitad del periodo        Abril 2021      Ernesto
                                Dim dtBaja As DataTable = sqlExecute("select top 1 RTRIM(reloj) AS reloj, baja from PERSONAL.dbo.personal where reloj='" & row("reloj") & "'")
                                Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))

                                If Not IsDBNull(dtBaja.Rows(0)("baja")) Then
                                    '--- Para la ultima columna
                                    var_Y = y + celdas_encabezado + dif

                                    'hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = IIf(IsDBNull(dtasist.Rows(0).Item("entro")), "", dtasist.Rows(0).Item("entro")) & " - " & IIf(IsDBNull(dtasist.Rows(0).Item("salio")), "", dtasist.Rows(0).Item("salio"))
                                    'Renglon(f) = IIf(IsDBNull(dtasist.Rows(0).Item("entro")), "", dtasist.Rows(0).Item("entro")) & " - " & IIf(IsDBNull(dtasist.Rows(0).Item("salio")), "", dtasist.Rows(0).Item("salio"))
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Value = "BAJA"
                                    Renglon(f) = "BAJA"
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Bold = False
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(82, 8, 10))
                                    hoja_excel.Cells(x, y + celdas_encabezado + dif).Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255))
                                End If
                            End If
                            FechaEnF = DateSerial(f.Year, f.Month + 1, 0)

                            '==== Se asignan las horas totales al renglon =====     abril 8     Ernesto
                            If f = FechaEnF Or f = fecha_fin Then
                                var_Y = var_Y + 1
                                hoja_excel.Cells(x, var_Y).Value = lista_HrsTotales.Item(contador)
                                Renglon("Horas totales") = lista_HrsTotales.Item(contador).ToString
                                contador += 1
                            End If
                            '=================================
                            If f = ultimodía Then
                                Exit While
                            End If
                            f = f.AddDays(1)
                        End While
                        dtRescataData.Rows.Add(Renglon)
                        Renglon = dtRescataData.NewRow
                        x += 1
                        If f = ultimodía Then
                            Continue For
                        End If
                    End If
                Next

                hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()
                suma_horas = 0.0
                contador = 0
                var_Y = 0
                total_horas = ""
                lista_HrsTotales.Clear()
                listaRelojes.Clear()

                '== Para la exportación a PDF  -  Ernesto  -  13junio2022
                hoja_excel.PrinterSettings.Scale = 26
                hoja_excel.PrinterSettings.Orientation = eOrientation.Landscape

                'FechaIniInicio = DateAdd("m", 1, FechaIniInicio)
                'FechaIniInicio = DateSerial(FechaIniInicio.Year, FechaIniInicio.Month, 1)
            Next

            '== Actualiza estatus fin        6Oct2021
            ActualizaEstatusTabla("TA.dbo.reportes_recientes", "estatus_fin", Date.Now, "WHERE Usuario='" & Usuario & "' and nombre='" & _varNomReport & "'")

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    '=================================================================================================================

    '----------------------------------------------------------ANTONIO --------------------------------------------------------
    '== Rango de celdas excel               marzo22     Ernesto 
    Private Function RangoColumnaReportes(nivel As Integer, inicio As Integer, fin As Integer, Optional borde As Boolean = False, Optional totFilas As Integer = 0) As String
        Try

            Dim LetrasColumnas() As String
            Dim letCol As New ArrayList
            Dim abc() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            For Each lista As String In abc
                letCol.Add(lista)
            Next

            For Each x As String In abc
                For Each y As String In abc
                    Dim conjunto As String = x & y
                    letCol.Add(conjunto)
                Next
            Next

            'Dim letrasCol() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            '                                                        "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL"}
            Dim rango As String = ""
            Dim celdaY As Integer = nivel

            For i As Integer = 0 To 2000
                If i = inicio - 1 Or i = fin - 1 Then
                    'rango &= letrasCol(i) & IIf(i = inicio - 1, nivel.ToString & ":", nivel.ToString)
                    rango &= letCol.Item(i) & IIf(i = inicio - 1, nivel.ToString & ":", nivel.ToString)
                End If
            Next

            If borde Then
                rango = ""
                For i As Integer = 0 To 2000
                    If i = inicio - 1 Or i = fin - 1 Then
                        'rango &= letrasCol(i) & IIf(i = inicio - 1, nivel.ToString & ":", totFilas.ToString)
                        rango &= letCol.Item(i) & IIf(i = inicio - 1, nivel.ToString & ":", nivel.ToString)
                    End If
                Next
            End If

            Return rango
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '== Formato de celdas de excel              marzo22     Ernesto
    Private Sub FormatoCelda(ByRef hoja_excel As ExcelWorksheet, tipo_celda As Integer, x As Integer, y As Integer,
                                                valor As String, colorCelda As Color, colorLetra As Color, negrita As Boolean, Optional rango As String = "")
        Try

            Select Case tipo_celda
                Case 0 '== Celda
                    hoja_excel.Cells(x, y).Value = valor
                    hoja_excel.Cells(x, y).Style.Font.Bold = negrita
                    hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    hoja_excel.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(colorCelda)
                    hoja_excel.Cells(x, y).Style.Font.Color.SetColor(colorLetra)
                Case 1 '== Rango
                    hoja_excel.SelectedRange(rango).Merge = True
                    hoja_excel.SelectedRange(rango).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    hoja_excel.SelectedRange(rango).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    hoja_excel.SelectedRange(rango).Style.Fill.BackgroundColor.SetColor(colorCelda)
                    hoja_excel.SelectedRange(rango).Style.Font.Color.SetColor(colorLetra)
                Case 2 '== Bordes
                    hoja_excel.SelectedRange(rango).Style.Border.Right.Style = Style.ExcelBorderStyle.Thin
                    hoja_excel.SelectedRange(rango).Style.Border.Left.Style = Style.ExcelBorderStyle.Thin

            End Select

        Catch ex As Exception : End Try
    End Sub

    '== Si sale el dia siguiente                        marzo22         Ernesto
    Private Function SaleDiaSigExcelRegistroAsistencia(ByVal tabla As DataTable, reloj As String, fecha As Date) As Boolean
        Try
            For Each x As DataRow In tabla.Select("reloj='" & reloj & "' and fecha='" & FechaSQL(fecha) & "' and SalidaDiaSig=1")
                Return True
            Next
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    '== Informacion de la celda excel               marzo22     Ernesto
    Private Sub InfoCeldaExcelRegistroAsistencia(reloj As String, tabla As DataTable, ByRef hoja_excel As ExcelWorksheet, x As Integer, y As Integer, fecha As Date, saleSigDia As Boolean, Optional ByVal _retardo As String = "")
        Try
            Dim dtEntradas As New DataTable
            Dim dtHoras As New DataTable
            Dim filaChecada As DataRow
            Dim cont As Integer = 0
            Dim flag As Integer = 0
            Dim hr_temp As String = ""

            '== Inicializa las cuatro checadas con valores default
            dtEntradas.Columns.Add("Checada", Type.GetType("System.String"))
            'For i As Integer = 0 To 3
            For i As Integer = 0 To 2
                filaChecada = dtEntradas.NewRow
                filaChecada.Item("Checada") = "N/A"
                dtEntradas.Rows.Add(filaChecada)
            Next

            '== Valores de hrs_brt
            dtHoras.Columns.Add("fecha", Type.GetType("System.String"))
            dtHoras.Columns.Add("hora", Type.GetType("System.String"))
            dtHoras.Columns.Add("e_s", Type.GetType("System.String"))
            dtHoras.Columns.Add("id", Type.GetType("System.String"))

            filaChecada = Nothing

            '== Se llenan las checadas de determinada fecha
            If Not saleSigDia Then
                For Each fila As DataRow In tabla.Select("reloj='" & reloj & "' and fecha='" & FechaSQL(fecha) & "'", "hora,fecha")
                    filaChecada = dtHoras.NewRow
                    filaChecada.Item("fecha") = FechaSQL(fila.Item("fecha"))
                    filaChecada.Item("hora") = fila.Item("hora")
                    filaChecada.Item("e_s") = fila.Item("entrada_salida").ToString
                    filaChecada.Item("id") = cont.ToString
                    dtHoras.Rows.Add(filaChecada)
                    cont += 1
                Next
            Else
                For Each fila As DataRow In tabla.Select("reloj='" & reloj & "' and fecha between '" & FechaSQL(fecha) & "' and '" & FechaSQL(fecha.AddDays(1)) & "'")
                    Dim mismaFechaEfva As Boolean
                    Try
                        If IsDBNull(fila.Item("fecha_efva")) Then
                            mismaFechaEfva = True
                        Else
                            If fila.Item("fecha_efva") <> fecha.AddDays(1) Then
                                mismaFechaEfva = True
                            ElseIf fila.Item("fecha_efva") = fecha.AddDays(1) Then
                                mismaFechaEfva = False
                                Exit For
                            End If
                        End If

                    Catch ex As Exception : End Try

                    filaChecada = dtHoras.NewRow
                    filaChecada.Item("fecha") = FechaSQL(fila.Item("fecha"))
                    filaChecada.Item("hora") = fila.Item("hora")
                    filaChecada.Item("e_s") = fila.Item("entrada_salida").ToString
                    filaChecada.Item("id") = cont.ToString
                    dtHoras.Rows.Add(filaChecada)
                    cont += 1
                Next
            End If


            '==--- Agregar la columna de retardo de SI o NO
            dtEntradas.Rows(1)("checada") = _retardo
            '== Asigna los dos registros
            For Each row As DataRow In dtHoras.Rows

                '---AO 2024-06-12: Como se solicitó que solo pusiera entrada y salida sin comidas, solo agregar estas
                If row.Item("e_s").ToString.Trim = "E" Then dtEntradas.Rows(0)("checada") = row.Item("hora").ToString.Trim
                If row.Item("e_s").ToString.Trim = "S" Then dtEntradas.Rows(2)("checada") = row.Item("hora").ToString.Trim



                '---Proceso anterior que colocaba las entradas y salidas de comida
                'If cont >= 4 Then
                '    If row.Item("e_s").ToString.Trim = "E" And row.Item("id").ToString.Trim = "0" Then dtEntradas.Rows(0)("checada") = row.Item("hora").ToString.Trim
                '    If row.Item("e_s").ToString.Trim = "S" And row.Item("id").ToString.Trim = (cont - 1).ToString Then dtEntradas.Rows(3)("checada") = row.Item("hora").ToString.Trim
                '    If row.Item("id").ToString.Trim = "1" Then dtEntradas.Rows(1)("checada") = row.Item("hora").ToString.Trim
                '    If row.Item("id").ToString.Trim = (cont - 2).ToString Then dtEntradas.Rows(2)("checada") = row.Item("hora").ToString.Trim
                'End If

                'If cont = 3 Then
                '    If row.Item("e_s").ToString.Trim = "E" And row.Item("id").ToString.Trim = "0" Then dtEntradas.Rows(0)("checada") = row.Item("hora").ToString.Trim
                '    If row.Item("e_s").ToString.Trim = "S" And row.Item("id").ToString.Trim = (cont - 1).ToString Then dtEntradas.Rows(3)("checada") = row.Item("hora").ToString.Trim
                '    If row.Item("id").ToString.Trim = "1" Then dtEntradas.Rows(1)("checada") = row.Item("hora").ToString.Trim
                'End If

                'If cont <= 2 Then
                '    If row.Item("e_s").ToString.Trim = "E" Then dtEntradas.Rows(0)("checada") = row.Item("hora").ToString.Trim
                '    If row.Item("e_s").ToString.Trim = "S" Then dtEntradas.Rows(3)("checada") = row.Item("hora").ToString.Trim
                'End If
            Next

            '== Llena el excel con los datos
            cont = 0
            For Each celdaEx As DataRow In dtEntradas.Rows
                FormatoCelda(hoja_excel, 0, x, y + cont, celdaEx.Item("checada"), Color.FromArgb(255, 255, 255), Color.Black, False)
                cont += 1
            Next

        Catch ex As Exception

        End Try
    End Sub

    '== Modificado 14julio2022            Ernesto
    Public Sub ExcelRegistroAsistencia(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, fecha_ini As Date, fecha_fin As Date, dtInformacion As DataTable)
        Try
            '== Actualiza estatus inicio        6Oct2021
            ActualizaEstatusTabla("TA.dbo.reportes_recientes", "estatus_inicio", Date.Now, "WHERE Usuario='" & Usuario & "' and nombre='" & _varNomReport & "'")

            ' Reporte a detalle Excel
            Dim x As Integer = 1
            Dim y As Integer = 1
            Dim yy As Integer = 0
            Dim ContadorFaltas As Integer = 0
            Dim ContadorAsistencia As Integer = 0
            Dim FechaBak As Date = fecha_ini
            Dim dtRescataData As New DataTable
            Dim FechaIniInicio As Date = fecha_ini
            Dim FechaFinInicio As Integer
            Dim MesEspanol As String = 0
            Dim dtSacaFIDeAus As New DataTable

            Dim f As Date = FechaSQL(fecha_ini)
            Dim fSuplente As Date

            Dim diff As Integer = DateDiff(DateInterval.Month, fecha_ini, fecha_fin)
            Dim Ciclos As Integer = diff

            diff += 1

            '== Checadas generales              10mar22         Ernesto
            Dim dtHrsBrt As New DataTable
            Dim J As String = "SELECT H.*, (CASE WHEN (SELECT RELOJ FROM PERSONAL.dbo.personal WHERE RELOJ=H.reloj and COD_HORA in " & _
                                                "(SELECT COD_HORA FROM PERSONAL.dbo.horarios WHERE SAL_SIG_DIA=1)) IS NOT NULL THEN 1 ELSE 0 END) as 'SalidaDiaSig' " & _
                                                "FROM TA.dbo.hrs_brt H where FECHA between '" & FechaSQL(fecha_ini) & "' AND '" & FechaSQL(fecha_fin) & "' ORDER BY H.RELOJ"

            dtHrsBrt = sqlExecute("SELECT H.*, (CASE WHEN (SELECT RELOJ FROM PERSONAL.dbo.personal WHERE RELOJ=H.reloj and COD_HORA in " & _
                                                "(SELECT COD_HORA FROM PERSONAL.dbo.horarios WHERE SAL_SIG_DIA=1)) IS NOT NULL THEN 1 ELSE 0 END) as 'SalidaDiaSig' " & _
                                                "FROM TA.dbo.hrs_brt H where FECHA between '" & FechaSQL(fecha_ini) & "' AND '" & FechaSQL(fecha_fin) & "' ORDER BY H.RELOJ", "TA")

            Dim dtBajas As New DataTable
            dtBajas = sqlExecute("select reloj,baja from personal.dbo.personal where baja is not null", "TA")

            '== Total de empleados
            Dim totalEmp As Integer = 0
            Dim emp As New ArrayList
            For Each cant As DataRow In dtInformacion.Rows
                If Not emp.Contains(cant.Item("reloj").ToString.Trim) Then
                    emp.Add(cant.Item("reloj").ToString.Trim)
                End If
            Next

            For z As Integer = 0 To diff - 1
                x = 3
                y = 1
                f = FechaIniInicio
                If FechaIniInicio.Month = 1 Then
                    MesEspanol = "ENERO"
                ElseIf FechaIniInicio.Month = 2 Then
                    MesEspanol = "FEBRERO"
                ElseIf FechaIniInicio.Month = 3 Then
                    MesEspanol = "MARZO"
                ElseIf FechaIniInicio.Month = 4 Then
                    MesEspanol = "ABRIL"
                ElseIf FechaIniInicio.Month = 5 Then
                    MesEspanol = "MAYO"
                ElseIf FechaIniInicio.Month = 6 Then
                    MesEspanol = "JUNIO"
                ElseIf FechaIniInicio.Month = 7 Then
                    MesEspanol = "JULIO"
                ElseIf FechaIniInicio.Month = 8 Then
                    MesEspanol = "AGOSTO"
                ElseIf FechaIniInicio.Month = 9 Then
                    MesEspanol = "SEPTIEMBRE"
                ElseIf FechaIniInicio.Month = 10 Then
                    MesEspanol = "OCTUBRE"
                ElseIf FechaIniInicio.Month = 11 Then
                    MesEspanol = "NOVIEMBRE"
                ElseIf FechaIniInicio.Month = 12 Then
                    MesEspanol = "DICIEMBRE"
                End If
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(MesEspanol & " ASISTENCIA")
                Dim celdas_encabezado = 13
                If dtRescataData.Columns.Count = 0 Then
                Else
                    dtRescataData.Columns.Clear()
                End If

                '-----ENCABEZADOS----------
                '**VALORES FIJOS

                Dim ultimodía As Date = DateSerial(FechaIniInicio.Year, FechaIniInicio.Month + 1, 0)
                Dim FechaEnF As Date

                dtRescataData.Columns.Add("Cod_Planta", Type.GetType("System.String"))

                hoja_excel.Cells(x, y).Value = "Reloj"
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                dtRescataData.Columns.Add("Reloj", Type.GetType("System.String"))

                y += 1
                hoja_excel.Cells(x, y).Value = "Nombre"
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                dtRescataData.Columns.Add("Nombre", Type.GetType("System.String"))

                y += 1
                hoja_excel.Cells(x, y).Value = "Fecha Ingreso"
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                dtRescataData.Columns.Add("Fecha Ingreso", Type.GetType("System.String"))

                y += 1
                hoja_excel.Cells(x, y).Value = "Departamento"
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                dtRescataData.Columns.Add("Departamento", Type.GetType("System.String"))

                y += 1
                hoja_excel.Cells(x, y).Value = "Puesto"
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                dtRescataData.Columns.Add("Puesto", Type.GetType("System.String"))

                '**-----2024-06-12:  A peticion de Lupita y gaby se deshabilitan el horario y su descripción
                'y += 1
                'hoja_excel.Cells(x, y).Value = "Horario"
                'hoja_excel.Cells(x, y).Style.Font.Bold = True
                'dtRescataData.Columns.Add("Horario", Type.GetType("System.String"))

                'y += 1
                'hoja_excel.Cells(x, y).Value = "Nombre Horario"
                'hoja_excel.Cells(x, y).Style.Font.Bold = True
                'dtRescataData.Columns.Add("Nombre Horario", Type.GetType("System.String"))

                'Genera las fechas como columnas, para posteriormente clasificar asistencia o ausencia****************************************************************************************************************************************
                celdas_encabezado = y + 1
                Dim rango As String = ""
                Dim posIni As Integer = 0 : Dim posFin As Integer = 0
                Dim cont As Integer = 0

                Dim _difPos As Integer = 0
                While f <= fecha_fin And f <= ultimodía
                    Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))
                    If cont = 0 Then posIni = celdas_encabezado + dif - 1

                    hoja_excel.Cells(x - 1, posIni + 1).Value = f.ToString("dd-MMM-yyyy")
                    hoja_excel.Cells(x - 1, posIni + 1).Style.Font.Bold = True
                    dtRescataData.Columns.Add(f, Type.GetType("System.String"))

                    '== Columnas entradas salidas
                    FormatoCelda(hoja_excel, 0, x, posIni + 1, "Entrada", Color.FromArgb(217, 217, 217), Color.Black, False)
                    FormatoCelda(hoja_excel, 0, x, posIni + 2, "Retardo", Color.FromArgb(217, 217, 217), Color.Black, False)
                    FormatoCelda(hoja_excel, 0, x, posIni + 3, "Salida", Color.FromArgb(217, 217, 217), Color.Black, False)

                    ' FormatoCelda(hoja_excel, 0, x, posIni + 2, "Comida Ent.", Color.FromArgb(217, 217, 217), Color.Black, False) ' 2024-06-12 tambien se deshabilitan entrada y salida comida a peticion de Gaby y Lupita
                    ' FormatoCelda(hoja_excel, 0, x, posIni + 3, "Comida Sal.", Color.FromArgb(217, 217, 217), Color.Black, False)
                    'FormatoCelda(hoja_excel, 0, x, posIni + 4, "Salida", Color.FromArgb(217, 217, 217), Color.Black, False)

                    ' posIni = celdas_encabezado + dif + (3 + cont)
                    ' posFin = posIni + 3

                    posIni = celdas_encabezado + dif + (2 + cont)
                    posFin = posIni + 2

                    'rango = RangoColumnaReportes(x - 1, posIni - 3, posFin - 3)
                    'FormatoCelda(hoja_excel, 1, 0, 0, "", Color.FromArgb(166, 166, 166), Color.Black, False, rango)

                    rango = RangoColumnaReportes(x - 1, posIni - 2, posFin - 2)
                    FormatoCelda(hoja_excel, 1, 0, 0, "", Color.FromArgb(166, 166, 166), Color.Black, False, rango)

                    '== Dibujar bordes para separar
                    'rango = RangoColumnaReportes(x - 1, posIni - 3, posFin - 3, True, emp.Count + 2)
                    'FormatoCelda(hoja_excel, 2, 0, 0, "", Nothing, Nothing, False, rango)

                    rango = RangoColumnaReportes(x - 1, posIni - 2, posFin - 2, True, emp.Count + 2)
                    FormatoCelda(hoja_excel, 2, 0, 0, "", Nothing, Nothing, False, rango)

                    f = f.AddDays(1)
                    ' cont += 3
                    cont += 2

                    _difPos = dif
                End While

                '----2024-04-09: Agregar columna de bono de asist y bono de punt
                'Dim titulo As String = "DETALLE DIAS BONOS"
                'hoja_excel.Cells(x - 1, posIni + 1).Value = titulo
                'hoja_excel.Cells(x - 1, posIni + 1).Style.Font.Bold = True
                'dtRescataData.Columns.Add(titulo, Type.GetType("System.String"))

                '== Columnas premio de asist y punt
                FormatoCelda(hoja_excel, 0, x, posIni + 1, "Asistencia", Color.FromArgb(217, 217, 217), Color.Black, False)
                FormatoCelda(hoja_excel, 0, x, posIni + 2, "Puntualidad.", Color.FromArgb(217, 217, 217), Color.Black, False)
                FormatoCelda(hoja_excel, 0, x, posIni + 3, "Horas.", Color.FromArgb(217, 217, 217), Color.Black, False)


                'posIni = celdas_encabezado + _difPos + (3 + cont)
                'posFin = posIni + 3

                'rango = RangoColumnaReportes(x - 1, posIni - 3, posFin - 3)
                'FormatoCelda(hoja_excel, 1, 0, 0, "", Color.FromArgb(166, 166, 166), Color.Black, False, rango)

                ''== Dibujar bordes para separar
                'rango = RangoColumnaReportes(x - 1, posIni - 3, posFin - 3, True, emp.Count + 2)
                'FormatoCelda(hoja_excel, 2, 0, 0, "", Nothing, Nothing, False, rango)


                posIni = 0
                posFin = 0
                x += 1

                '-----CONTENIDO----------
                Dim reloj_tmp As String = ""

                y = 1
                Dim dtNombres As DataTable
                Dim Renglon As DataRow = dtRescataData.NewRow()

                For Each row As DataRow In dtInformacion.Select("", "reloj") ' Para todos

                    'For Each row As DataRow In dtInformacion.Select("reloj='00035'", "reloj") ' Para ciertos empleados, solo prueba

                    If reloj_tmp = row("reloj") Then
                        Continue For
                    Else
                        reloj_tmp = row("reloj")
                    End If

                    f = FechaIniInicio

                    'ASIGNA LOS VALORES CONSULTADOS DIRECTAMENTE DE LOS EMPLEADOS**********************************************************************************************************

                    hoja_excel.Cells(x, y).Value = row("reloj")
                    Renglon("Reloj") = row("reloj")

                    Dim _reloj As String = row("reloj").ToString.Trim

                    Dim QNomb As String = "select reloj,reloj_alt, nombres, cod_clase, cod_comp, cod_planta, alta, baja, nombre_planta, cod_depto, nombre_depto, cod_turno, nombre_super,cod_hora,nombre_puesto,nombre_horario from personalvw where reloj = '" & row("reloj") & "'"
                    dtNombres = sqlExecute(QNomb, "PERSONAL")

                    If dtNombres.Rows.Count > 0 Then

                        Renglon("Cod_Planta") = dtNombres.Rows(0)("cod_planta")

                        y += 1
                        hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("nombres")
                        Renglon("Nombre") = dtNombres.Rows(0)("nombres")
                        y += 1
                        hoja_excel.Cells(x, y).Value = Date.Parse(dtNombres.Rows(0)("alta")).ToShortDateString
                        Renglon("Fecha Ingreso") = Date.Parse(dtNombres.Rows(0)("alta")).ToShortDateString

                        y += 1
                        hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("nombre_depto")
                        Renglon("Departamento") = dtNombres.Rows(0)("nombre_depto")

                        y += 1
                        hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("nombre_puesto")
                        Renglon("Puesto") = dtNombres.Rows(0)("nombre_puesto")

                        'y += 1
                        'hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("cod_hora")
                        'Renglon("Horario") = dtNombres.Rows(0)("cod_hora")

                        'y += 1
                        'hoja_excel.Cells(x, y).Value = dtNombres.Rows(0)("nombre_horario")
                        'Renglon("Nombre Horario") = dtNombres.Rows(0)("nombre_horario")

                    End If

                    celdas_encabezado = y
                    y = 1

                    'BUSCA EL TIPO DE AUSENCIA****************************************************************************************************************************************
                    '== Se quito la restriccion para que se genere en cualquier fecha del año           25nov2021
                    While ((f <= fecha_fin))

                        'VERIFICA SI EL EMPLEADO ES VIGENTE********************************************************************************************************************
                        Dim dtVerificarSiEsVigente As DataTable = sqlExecute("select asist.*, PERSONAL.ALTA, PERSONAL.BAJA  from ta.dbo.asist left join PERSONAL.dbo.personal on " & _
                                                                             "asist.reloj = personal.reloj where PERSONAL.reloj = '" & row("reloj") & "' AND ALTA <= '" & FechaSQL(f) & "'  AND (BAJA is null or BAJA >= '" & FechaSQL(f) & "')", "")
                        If dtVerificarSiEsVigente.Rows.Count > 0 Then

                            '== Si existe cualquier ausentismo y el empleado esta dado de baja, priorizar la baja sobre todo lo demás
                            If dtBajas.Select("reloj='" & row("reloj").ToString.Trim & "' and baja='" & FechaSQL(f) & "'").Count > 0 Then
                                Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))
                                Renglon(f) = "BAJA"

                                'posIni = (y + celdas_encabezado + dif) + (dif * 3)
                                'posFin = posIni + 3

                                posIni = (y + celdas_encabezado + dif) + (dif * 2)
                                posFin = posIni + 2

                                hoja_excel.Cells(x, posIni).Value = "BAJA"
                                hoja_excel.Cells(x, posIni).AddComment("BAJA", "Detalle")
                                hoja_excel.Cells(x, posIni).Style.Font.Size = 10

                                rango = RangoColumnaReportes(x, posIni, posFin)

                                FormatoCelda(hoja_excel, 1, 0, 0, "", Color.FromArgb(82, 82, 82), Color.White, True, rango)
                                GoTo BajaSobreAus

                            End If

                            'VERIFICA SI SE ENCUENTRA EN LA TABLA ASISTENCIA POR FECHA Y RELOJ********************************************************************************************************************
                            Dim dtAusentismo As DataTable = sqlExecute("select rtrim(tipo_aus) as tipo_aus, rtrim(entro) as entro, rtrim(salio) as salio from asist where reloj = '" & row("reloj") & "' and fecha_entro = '" & FechaSQL(f) & "' " & IIf(filtro.Trim <> "", " and " & filtro, ""), "TA")
                            If dtAusentismo.Rows.Count > 0 Then

                                'VERIFICA SI TIENE ALGUN TIPO DE AUSENTISMO********************************************************************************************************************
                                Dim tipo_aus As String = Convert.ToString(dtAusentismo.Rows(0)("tipo_aus"))
                                If tipo_aus <> "" Then

                                    Dim dtObtieneTipoAus As DataTable = sqlExecute("select rtrim(nombre) as nombre, color_letra, color_back from tipo_ausentismo WHERE rtrim(tipo_aus) = '" + tipo_aus + "'", "TA")

                                    If tipo_aus = "FES" And (dtAusentismo.Rows(0)("entro") <> "" Or dtAusentismo.Rows(0)("salio") <> "") Then
                                        Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))
                                        Renglon(f) = "FEST TRAB"

                                        'posIni = (y + celdas_encabezado + dif) + (dif * 3)
                                        'posFin = posIni + 3

                                        posIni = (y + celdas_encabezado + dif) + (dif * 2)
                                        posFin = posIni + 2

                                        hoja_excel.Cells(x, posIni).Value = "FEST TRAB"
                                        rango = RangoColumnaReportes(x, posIni, posFin)
                                        FormatoCelda(hoja_excel, 1, 0, 0, "", Color.FromArgb(dtObtieneTipoAus.Rows(0)("color_back")), Color.FromArgb(dtObtieneTipoAus.Rows(0)("color_letra")),
                                                                True, rango)
                                    Else
                                        'SI HUBO ALGUN TIPO DE AUSENTISMO, LO BUSCA Y LO DESCRIBE DESDE LA BASE DE DATOS*******************************************************************************************************************
                                        If tipo_aus = "FI" Then
                                            dtSacaFIDeAus = sqlExecute("select * from ausentismo where RELOJ = '" & row("reloj") & "' AND fecha = '" & FechaSQL(f) & "'", "TA")
                                            If dtSacaFIDeAus.Rows.Count <> 0 Then
                                                Dim zz As String = dtSacaFIDeAus.Rows(0)("TIPO_AUS")
                                                If zz <> tipo_aus Then
                                                    tipo_aus = zz
                                                    dtObtieneTipoAus = sqlExecute("select rtrim(nombre) as nombre, color_letra, color_back from tipo_ausentismo WHERE rtrim(tipo_aus) = '" + tipo_aus + "'", "TA")
                                                End If
                                            End If
                                        End If
                                        dtSacaFIDeAus = sqlExecute("select * from ausentismo where RELOJ = '" & row("reloj") & "' AND fecha = '" & FechaSQL(f) & "'", "TA")

                                        Dim segundocomentario As String
                                        If dtSacaFIDeAus.Rows.Count > 0 Then
                                            segundocomentario = dtSacaFIDeAus.Rows(0)("SUBCLASI").ToString.Trim
                                        Else
                                            segundocomentario = ""
                                        End If

                                        Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))
                                        Dim comentarioCelda As String = ""
                                        Try : comentarioCelda = dtObtieneTipoAus.Rows(0)("nombre") + ", " + segundocomentario.Trim : Catch ex As Exception : comentarioCelda = "" : End Try
                                        Renglon(f) = tipo_aus

                                        'posIni = (y + celdas_encabezado + dif) + (dif * 3)
                                        'posFin = posIni + 3

                                        posIni = (y + celdas_encabezado + dif) + (dif * 2)
                                        posFin = posIni + 2

                                        hoja_excel.Cells(x, posIni).Value = tipo_aus
                                        hoja_excel.Cells(x, posIni).AddComment(comentarioCelda, "Detalle")

                                        hoja_excel.Cells(x, posIni).Style.Font.Size = 10
                                        rango = RangoColumnaReportes(x, posIni, posFin)

                                        FormatoCelda(hoja_excel, 1, 0, 0, "", Color.FromArgb(dtObtieneTipoAus.Rows(0)("color_back")), Color.FromArgb(dtObtieneTipoAus.Rows(0)("color_letra")),
                                                                True, rango)
                                    End If
                                Else
                                    '--- AO 2023-05-12: Solicita Miriam que los descansos trabajados aparezca su entrada y salida y no solo la leyenda de "DESC TRAB"
                                    'ASIGNA 'DESC TRAB' De acuerdo a los comentarios de la tabla ASIST****************************************************************************************************************************************
                                    'Dim dtDescansoTrabajado As DataTable = sqlExecute("select * from ta.dbo.asist where reloj = '" & row("reloj") & "' and fecha_entro = '" & FechaSQL(f) & "' and COMENTARIO LIKE '%DESCANSO%'", "", selecPlantaRep)
                                    'If dtDescansoTrabajado.Rows.Count > 0 Then
                                    '    Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))
                                    '    Renglon(f) = "DESC TRAB"

                                    '    posIni = (y + celdas_encabezado + dif) + (dif * 3)
                                    '    posFin = posIni + 3

                                    '    hoja_excel.Cells(x, posIni).Value = "DESC TRAB"
                                    '    hoja_excel.Cells(x, posIni).AddComment("DESCANSO TRABAJADO", "Detalle")
                                    '    hoja_excel.Cells(x, posIni).Style.Font.Size = 10

                                    '    rango = RangoColumnaReportes(x, posIni, posFin)
                                    '    FormatoCelda(hoja_excel, 1, 0, 0, "", Color.FromArgb(255, 255, 255), Color.Black, True, rango)

                                    'Else
                                    '    'ASIGNA 'ASIS' A LOS QUE TENGAN POR LO MENOS HORARIO DE ENTRADA O DE SALIDA****************************************************************************************************************************************
                                    '    Dim dtasist As DataTable = sqlExecute("select asist.entro,asist.salio, PERSONAL.ALTA, PERSONAL.BAJA  from ta.dbo.asist left join PERSONAL.dbo.personal on asist.reloj = personal.reloj where " & _
                                    '                                          "PERSONAL.reloj = '" & row("reloj") & "' and fecha_entro = '" & FechaSQL(f) & "' AND fecha_entro >= ALTA AND (BAJA is null or fecha_entro <= BAJA) AND (SALIO <> '' or ENTRO <> '') and TIPO_AUS is NULL", "", selecPlantaRep)
                                    '    If dtasist.Rows.Count > 0 Then

                                    '        Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))
                                    '        Dim saleDiaSiguiente As Boolean = SaleDiaSigExcelRegistroAsistencia(dtHrsBrt, reloj_tmp.Trim, f)
                                    '        Renglon(f) = IIf(IsDBNull(dtasist.Rows(0).Item("entro")), "", dtasist.Rows(0).Item("entro")) & " - " & IIf(IsDBNull(dtasist.Rows(0).Item("salio")), "", dtasist.Rows(0).Item("salio"))

                                    '        posIni = (y + celdas_encabezado + dif) + (dif * 3)
                                    '        posFin = posIni + 3

                                    '        InfoCeldaExcelRegistroAsistencia(reloj_tmp, dtHrsBrt, hoja_excel, x, posIni, f, saleDiaSiguiente)
                                    '    End If
                                    'End If

                                    '----- AO:  2023-05-12: Este proceso es el que inserta las horas de entrada y salida para cada dia, 
                                    'NOTA: En el Renglon(f) que trae la columna del dia, es donde se inserta la hora de entrada y salida para cada día
                                    Dim dtasist As DataTable = sqlExecute("select asist.entro,asist.salio,asist.comentario, PERSONAL.ALTA, PERSONAL.BAJA  from ta.dbo.asist left join PERSONAL.dbo.personal on asist.reloj = personal.reloj where " & _
                                       "PERSONAL.reloj = '" & row("reloj") & "' and fecha_entro = '" & FechaSQL(f) & "' AND fecha_entro >= ALTA AND (BAJA is null or fecha_entro <= BAJA) AND (SALIO <> '' or ENTRO <> '') and TIPO_AUS is NULL", "")
                                    If dtasist.Rows.Count > 0 Then

                                        Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))
                                        Dim saleDiaSiguiente As Boolean = SaleDiaSigExcelRegistroAsistencia(dtHrsBrt, reloj_tmp.Trim, f)
                                        Renglon(f) = IIf(IsDBNull(dtasist.Rows(0).Item("entro")), "", dtasist.Rows(0).Item("entro")) & " - " & IIf(IsDBNull(dtasist.Rows(0).Item("salio")), "", dtasist.Rows(0).Item("salio"))

                                        'posIni = (y + celdas_encabezado + dif) + (dif * 3)
                                        'posFin = posIni + 3

                                        posIni = (y + celdas_encabezado + dif) + (dif * 2)
                                        posFin = posIni + 2

                                        Dim retardo As String = ""
                                        Try : retardo = dtasist.Rows(0).Item("comentario").ToString.Trim : Catch ex As Exception : retardo = "" : End Try
                                        If retardo.Contains("RETARD") Then retardo = "SI" Else retardo = "NO"

                                        InfoCeldaExcelRegistroAsistencia(reloj_tmp, dtHrsBrt, hoja_excel, x, posIni, f, saleDiaSiguiente, retardo)
                                    End If
                                    '-----

                                End If
                            Else
                                'SI NO NUBO UNA FECHA DE ENTRADA LO TOMA COMO DESCANSO****************************************************************************************************************************************
                                Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))
                                Renglon(f) = "DESC"

                                'posIni = (y + celdas_encabezado + dif) + (dif * 3)
                                'posFin = posIni + 3

                                posIni = (y + celdas_encabezado + dif) + (dif * 2)
                                posFin = posIni + 2

                                hoja_excel.Cells(x, posIni).Value = "DESC"
                                hoja_excel.Cells(x, posIni).AddComment("DESCANSO", "Detalle")
                                hoja_excel.Cells(x, posIni).Style.Font.Size = 10

                                rango = RangoColumnaReportes(x, posIni, posFin)
                                FormatoCelda(hoja_excel, 1, 0, 0, "", Color.FromArgb(255, 255, 255), Color.Black, True, rango)
                            End If
                        Else
                            '== Si es una baja, llenar los días con dicha etiqueta.
                            If dtBajas.Select("reloj='" & reloj_tmp & "'").Count > 0 Then
                                Dim dif As Integer = (DateDiff(DateInterval.Day, FechaIniInicio, f))
                                Renglon(f) = "BAJA"

                                'posIni = (y + celdas_encabezado + dif) + (dif * 3)
                                'posFin = posIni + 3

                                posIni = (y + celdas_encabezado + dif) + (dif * 2)
                                posFin = posIni + 2

                                hoja_excel.Cells(x, posIni).Value = "BAJA"
                                hoja_excel.Cells(x, posIni).AddComment("BAJA", "Detalle")
                                hoja_excel.Cells(x, posIni).Style.Font.Size = 10

                                rango = RangoColumnaReportes(x, posIni, posFin)

                                FormatoCelda(hoja_excel, 1, 0, 0, "", Color.FromArgb(82, 82, 82), Color.White, True, rango)
                            End If
                        End If

BajaSobreAus:
                        FechaEnF = DateSerial(f.Year, f.Month + 1, 0)
                        If f = ultimodía Then
                            Exit While
                        End If

                        f = f.AddDays(1)
                    End While

                    '-----****----***----///*---//***--****2024-04-09:   Ingresar dias de asist y puntalidad al final ///**********///*********---////////*****
                    Dim Q As String = "", dtPeriodo As New DataTable, _anoPer As String = "", dtBonos As New DataTable, bonasi As String = "0", bonpun As String = "0", hrs_normales As String = "0.00"
                    Q = "SELECT * from periodos  where FECHA_FIN='" & FechaSQL(fecha_fin) & "'"
                    dtPeriodo = sqlExecute(Q, "TA")
                    If Not dtPeriodo.Columns.Contains("Error") And dtPeriodo.Rows.Count > 0 Then Try : _anoPer = dtPeriodo.Rows(0).Item("ano").ToString.Trim & dtPeriodo.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : _anoPer = "" : End Try
                    Q = "select reloj,BONO_ASISTENCIA,BONO_PUNTUALIDAD,HRS_NORMALES from nomsem where ano+periodo='" & _anoPer & "' and reloj='" & row("reloj").ToString.Trim & "'"
                    dtBonos = sqlExecute(Q, "TA")
                    If Not dtBonos.Columns.Contains("Error") And dtBonos.Rows.Count > 0 Then
                        Try : bonasi = dtBonos.Rows(0).Item("BONO_ASISTENCIA").ToString.Trim : Catch ex As Exception : bonasi = "0" : End Try
                        Try : bonpun = dtBonos.Rows(0).Item("BONO_PUNTUALIDAD").ToString.Trim : Catch ex As Exception : bonpun = "0" : End Try
                        Try : hrs_normales = dtBonos.Rows(0).Item("hrs_normales").ToString.Trim : Catch ex As Exception : hrs_normales = "0.00" : End Try
                    End If

                    If hrs_normales <> "0.00" Then hrs_normales = Math.Round(Double.Parse(hrs_normales), 2)


                    ' posIni += 4
                    posIni += 3
                    hoja_excel.Cells(x, posIni).Value = bonasi ' Bono asist
                    hoja_excel.Cells(x, posIni + 1).Value = bonpun ' Bono Punt
                    hoja_excel.Cells(x, posIni + 2).Value = hrs_normales ' Total de horas a la semana

                    '-----****----***----///*---//***--****ENDS: Ingresar dias de asist y puntalidad al final ///**********///*********---////////*****


                    dtRescataData.Rows.Add(Renglon)
                    Renglon = dtRescataData.NewRow
                    x += 1

                    If f = ultimodía Then
                        Continue For
                    End If
                Next

                hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

                '=== A PARTIR DE AQUI MOSTRAR PORCENTAJES
                fSuplente = FechaSQL(FechaIniInicio)
                cont = 0 : x += 1
                Dim o As Integer = 8
                Dim dtSum As DataTable
                Dim dtTermino_periodo As New DataTable
                Dim dtPeriodos As DataTable = sqlExecute("select ano, periodo, fini_nom, ffin_nom from periodos", "TA")
                Dim rgbDivisionPeriodo(,) As Integer = {{31, 21}, {78, 53}, {120, 82}}
                Dim selectorRGB As Integer = 0
                Dim UltimoPeriodoImpreso As Integer = 0
                Dim ColumnaPromedioPeriodo As Integer = 0
                Dim DatoEnFecha As String
                Dim ContaPlanta000 As Integer = 0
                Dim ContaPlanta001 As Integer = 0
                Dim ContaPlanta002 As Integer = 0
                Dim SumaSemanalAsist As Integer = 0
                Dim SumaSemanalFaltas1 As Integer = 0
                Dim SumaSemanalFaltas2 As Integer = 0
                Dim SumaSemanalFaltas0 As Integer = 0

                Dim justificadasCorte As Integer = 0
                Dim justificadasPiel As Integer = 0
                Dim injustificadasCorte As Integer = 0
                Dim injustificadasPiel As Integer = 0
                Dim corteFaltasBajas As Integer = 0
                Dim pielFaltasBajas As Integer = 0
            Next

            '== Actualiza estatus fin        6Oct2021
            ActualizaEstatusTabla("TA.dbo.reportes_recientes", "estatus_fin", Date.Now, "WHERE Usuario='" & Usuario & "' and nombre='" & _varNomReport & "'")
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Excel detalle de asist", ex.HResult, ex.Message)
        End Try
    End Sub
    '------------------------------------------------------FIN ANTONIO---------------------------------------------------------

    '==Funcion modificada       31mayo2022        Ernesto
    Public Sub ExcelFaltasInjustificadasMotivos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Try
            '== Verifica que exista la plantilla del reporte
            Dim dir As String = DireccionReportes & "Reporte Faltas Clasificacion.xlsx"
            Dim motivo As String = ""
            Dim clasificacion As String = ""
            Dim tipo_falta As String = ""

            If File.Exists(dir) Then

                '== Rango de fechas de acuerdo a la seleccion en la forma
                Dim frm_fechas As New frmRangoFechas
                frm_fechas.Text = "Filtrar fecha para faltas"
                frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 12)
                frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>Filtrar fecha para faltas</b></font>
                frm_fechas.frmRangoFechas_fecha_ini = RangoFInicial
                frm_fechas.frmRangoFechas_fecha_fin = RangoFFinal
                frm_fechas.ShowDialog()

                Dim fecha_ini As Date = frm_fechas.frmRangoFechas_fecha_ini
                Dim fecha_fin As Date = frm_fechas.frmRangoFechas_fecha_fin

                dtDatos = dtInformacion.Copy ' Para que mande el resumen de todos los empleados

                Dim fbd As New SaveFileDialog
                fbd.DefaultExt = ".xlsx"
                fbd.FileName = "Reporte faltas clasificacion"
                fbd.OverwritePrompt = True

                If fbd.ShowDialog() = DialogResult.OK Then

                    Dim plantilla As New ExcelPackage(New System.IO.FileInfo(DireccionReportes & "Reporte Faltas Clasificacion.xlsx"))
                    Dim wb As ExcelWorkbook = plantilla.Workbook
                    'Dim nombre_hoja As String = FechaSQL(fecha_ini) & " a " & FechaSQL(fecha_fin)
                    Dim hoja As ExcelWorksheet = wb.Worksheets(1)
                    'hoja.Name = nombre_hoja

                    '==Nuevo query      6sep2021
                    Dim dtFaltasClasif As DataTable = sqlExecute("select RTRIM(aus.RELOJ) as reloj,CONCAT(RTRIM(P.NOMBRE),' ',RTRIM(P.APATERNO),' ',RTRIM(P.AMATERNO)) as nombre,RTRIM(P.nombre_depto) as depto,RTRIM(P.nombre_puesto) as nombre_puesto,p.ALTA as alta, " & _
                                                                                                "aus.fecha as fecha_falta,aus.TIPO_AUS,aus.PERIODO,aus.DETALLE_AUS,aus.SUBCLASI, " & _
                                                                                                "(case when aus.RELOJ in " & _
                                                                                                "(select reloj from ta.dbo.faltas_justificadas_reporte fj where fj.FECHA=aus.FECHA) then '1' else '0' end) as AmbasTablas, " & _
                                                                                                "(case when aus.SUBCLASI = 'Evaluador' and aus.DETALLE_AUS is null then '1' else '0' end) as AnalizadoEvaluador, " & _
                                                                                                "(case when aus.DETALLE_AUS is not null and aus.DETALLE_AUS not in " & _
                                                                                                "(select DETALLE_AUS from ta.dbo.faltas_justificadas_reporte where FECHA=aus.FECHA) then '1' else '0' end) as ActualizadoEnTablaAus, " & _
                                                                                                "(fjr.DETALLE_AUS) as DetalleTablaReporte, " & _
                                                                                                "(select top 1 f.nombre from ta.dbo.tipo_faltas f where f.COD_FALTA=fjr.detalle_aus) as NombreFaltaTablaReporte, " & _
                                                                                                "(fjr.tipo_aus) as TipoAusTablaReporte, " & _
                                                                                                "(fjr.subclasi) as MotivoTablaReporte, " & _
                                                                                                "(aus.DETALLE_AUS) as DetalleTablaAus,(tf.NOMBRE) as NombreFaltaTablaAus " & _
                                                                                                "from ta.dbo.ausentismo aus left join ta.dbo.faltas_justificadas_reporte fjr on aus.RELOJ=fjr.RELOJ and aus.FECHA=fjr.FECHA " & _
                                                                                                "left join ta.dbo.tipo_faltas tf on aus.DETALLE_AUS=tf.COD_FALTA " & _
                                                                                                "left join personal.dbo.personalvw p on p.reloj=aus.RELOJ " & _
                                                                                                "where aus.TIPO_AUS in ('FI','JUS') and  aus.fecha between '" & FechaSQL(fecha_ini) & "' AND '" & FechaSQL(fecha_fin) & "'")

                    Dim x As Integer = 2
                    Dim y As Integer = 1
                    Dim cont As Integer = 0
                    Dim empleado As String = ""
                    Dim reloj_temporal As String = ""
                    Dim dia As String = ""
                    Dim fechaFalta As Date = Nothing

                    '== Aqui se comienza a llenar la plantilla del documento
                    If dtFaltasClasif.Rows.Count > 0 Then

                        '== Se recorre la tabla del filtro seleccionado
                        For Each emp As DataRow In dtInformacion.Rows
                            empleado = emp.Item("reloj").ToString.Trim

                            '== Tomar relojes del registro sin repetirse
                            If reloj_temporal <> empleado Then
                                reloj_temporal = empleado

                                For Each falta As DataRow In dtFaltasClasif.Select("reloj = '" & empleado & "'")

                                    '--Casos:
                                    'Si AmbasTablas = 1 y ActualizadoEnTablaAus = 1 pone valor de tabla aus
                                    'Si AmbasTablas = 1 y ActualizadoEnTablaAus = 0 pone valor de tabla aus
                                    'Si AmbasTablas = 1 y AnalizadoEvaluador = 1 pone valor de tabla reportefaltas
                                    'Si solamente AnalizadoEvaluador = 1, no toma registro en cuenta
                                    'Si solamente ActualizadoEnTablaAus = 1, pone valor de tabla aus

                                    '==Condiciones para aceptar registro            6sep2021
                                    If (falta.Item("AmbasTablas").ToString = "1" And (falta.Item("ActualizadoEnTablaAus").ToString = "1" Or falta.Item("ActualizadoEnTablaAus").ToString = "0")) Or
                                        (falta.Item("ActualizadoEnTablaAus").ToString = "1" And (falta.Item("AmbasTablas").ToString = "0" And falta.Item("AnalizadoEvaluador").ToString = "0")) Then

                                        motivo = IIf(falta.Item("subclasi").ToString.Trim.Length < 1, "<--- Motivo no registrado --->", falta.Item("subclasi").ToString.Trim)
                                        clasificacion = falta.Item("NombreFaltaTablaAus").ToString.Trim
                                        tipo_falta = falta.Item("tipo_aus").ToString.Trim

                                    ElseIf falta.Item("AmbasTablas").ToString = "1" And falta.Item("AnalizadoEvaluador").ToString = "1" Then

                                        motivo = falta.Item("MotivoTablaReporte").ToString.Trim
                                        clasificacion = falta.Item("NombreFaltaTablaReporte").ToString.Trim
                                        tipo_falta = falta.Item("TipoAusTablaReporte").ToString.Trim

                                    ElseIf falta.Item("AnalizadoEvaluador").ToString = "1" And (falta.Item("AmbasTablas").ToString = "0" Or falta.Item("ActualizadoEnTablaAus").ToString = "0") Then
                                        Continue For
                                    End If

                                    hoja.Cells(x + cont, y).Value = FechaSQL(falta.Item("fecha_falta"))
                                    fechaFalta = falta.Item("fecha_falta")
                                    Try : dia = LCase(DiaSemanaLetra(fechaFalta.DayOfWeek).ToString.Substring(0, 3)) : Catch ex As Exception : dia = "" : End Try
                                    hoja.Cells(x + cont, y + 1).Value = dia
                                    hoja.Cells(x + cont, y + 2).Value = falta.Item("reloj")
                                    hoja.Cells(x + cont, y + 3).Value = falta.Item("nombre")
                                    hoja.Cells(x + cont, y + 4).Value = FechaSQL(falta.Item("alta"))
                                    hoja.Cells(x + cont, y + 5).Value = falta.Item("depto")
                                    hoja.Cells(x + cont, y + 6).Value = falta.Item("nombre_puesto")
                                    hoja.Cells(x + cont, y + 7).Value = motivo
                                    hoja.Cells(x + cont, y + 8).Value = clasificacion
                                    hoja.Cells(x + cont, y + 9).Value = tipo_falta
                                    cont += 1
                                    y = 1
                                Next
                            End If
                        Next
                        '==

                        Try : hoja.Cells(hoja.Dimension.Address).AutoFitColumns() : Catch ex As Exception : End Try
                        'LlenarRelacionEmpleados("Reporte de vencimiento de contrato", "", dtInformacion, wb)     '- Metodo para Generar varias plantillas en excel si es que se mandan mas de 1 empleado y llenar cada una a partir de una plantilla base
                        plantilla.SaveAs(New System.IO.FileInfo(fbd.FileName))
                        MessageBox.Show("Archivo generado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No existen registros en el periodo seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            Else
                MessageBox.Show("No se encontró el archivo base, contacte al administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ExcelFaltasInjustificadasMotivos", ex.HResult, ex.Message)
        End Try
    End Sub


    '=== Reporte (rdl) de captura de excepciones de horario     Mayo    2021        Ernesto
    Public Sub ReporteExcepcionesHorario(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            Dim _fini As String = ""
            Dim _ffin As String = ""
            Dim dtExcepciones As New DataTable
            _fini = FechaSQL(FechaInicial)
            _ffin = FechaSQL(FechaFinal)

            'Dim frm As New frmRangoFechas
            'If frm.ShowDialog = DialogResult.OK Then
            '    _fini = FechaInicial
            '    _ffin = FechaFinal
            'Else
            '    Exit Sub
            'End If

            dtExcepciones = sqlExecute("select e.*,p.COD_DEPTO,p.nombre_depto,p.cod_area,p.nombre_area from excepciones_horarios e left outer join personalvw p  on e.RELOJ=p.RELOJ " & _
                                                    "where fecha between '" & _fini & "' and '" & _ffin & "' order by e.FECHA asc")

            '== Prueba
            'dtExcepciones = sqlExecute("select e.*,p.COD_DEPTO,p.nombre_depto,p.cod_area,p.nombre_area from excepciones_horarios e left outer join personalvw p  on e.RELOJ=p.RELOJ " & _
            '                                        "where fecha between '2020-09-01' and '2020-09-30' order by e.FECHA asc")

            If dtExcepciones.Rows.Count > 0 Then

                dtDatos = New DataTable
                dtDatos.Columns.Add("RELOJ")
                dtDatos.Columns.Add("COD_HORA")
                dtDatos.Columns.Add("COD_HORA_PERSONAL")
                dtDatos.Columns.Add("FECHA")
                dtDatos.Columns.Add("FECHA_CAPTURA")
                dtDatos.Columns.Add("FECHA_ANALISIS")
                dtDatos.Columns.Add("HORA_CAPTURA")
                dtDatos.Columns.Add("USUARIO")
                dtDatos.Columns.Add("COMENTARIO")
                dtDatos.Columns.Add("USUARIO_ANALISIS")
                dtDatos.Columns.Add("COD_DEPTO")
                dtDatos.Columns.Add("nombre_depto")
                dtDatos.Columns.Add("cod_area")
                dtDatos.Columns.Add("nombre_area")

                For Each row As DataRow In dtExcepciones.Rows
                    Dim _fecha As String = "", _fecha_captura = "", _fecha_analisis = "", _hora_captura = ""

                    Try : _fecha = FechaSQL(row("FECHA")) : Catch ex As Exception : _fecha = "" : End Try
                    Try : _fecha_captura = FechaSQL(row("FECHA_CAPTURA")) : Catch ex As Exception : _fecha_captura = "" : End Try
                    Try : _fecha_analisis = FechaSQL(row("FECHA_ANALISIS")) : Catch ex As Exception : _fecha_analisis = "" : End Try
                    Try : _hora_captura = row("HORA_CAPTURA").ToString : Catch ex As Exception : _hora_captura = "" : End Try

                    dtDatos.Rows.Add(row("RELOJ"),
                                     row("COD_HORA"),
                                     row("COD_HORA_PERSONAL"),
                                     _fecha,
                                     _fecha_captura,
                                     _fecha_analisis,
                                     _hora_captura,
                                     row("USUARIO"),
                                     row("COMENTARIO"),
                                     row("USUARIO_ANALISIS"),
                                     row("COD_DEPTO"),
                                     row("nombre_depto"),
                                     row("cod_area"),
                                     row("nombre_area"))
                Next
            End If

        Catch ex As Exception
            dtDatos.Rows.Clear()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reporte Excepciones Horario", ex.HResult, ex.Message)
            MessageBox.Show("Ha ocurrido un error en la generación del reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '== Reporte "Formato de solicitud de tiempo extra"  23nov2021
    Public Sub ExcelFormatoHorasExtras(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim filtroR As String = Usuario.ToUpper & "*" & "Formato de solicitud de tiempo extra"
            Dim dtInformacionFiltro As DataTable = FiltroPerfilReportes(dtInformacion, filtroR)

            If dtInformacionFiltro.Rows.Count = 0 Then
                MessageBox.Show("No hay registro de empleados para tiempo extra", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim dir As String = DireccionReportes & "Formato de solicitud de tiempo extra.xlsx"
                Dim relojes As String = "" : Dim plantas As String = ""
                Dim dtDatosEmp As New DataTable : Dim row As DataRow

                dtDatosEmp = DataTableColEsencial("reloj,nombres,puesto,departamento,Lunes,Martes,Miércoles,Jueves,Viernes,Sábado,Domingo",
                                                                                 "String,String,String,String,String,String,String,String,String,String,String")

                '== Verifica que exista la plantilla del reporte
                If File.Exists(dir) Then
                    Dim fbd As New SaveFileDialog
                    fbd.DefaultExt = ".xlsx"
                    fbd.FileName = "Formato de solicitud de tiempo extra"
                    fbd.OverwritePrompt = True

                    If fbd.ShowDialog() = DialogResult.OK Then
                        Dim plantilla As New ExcelPackage(New System.IO.FileInfo(DireccionReportes & "Formato de solicitud de tiempo extra.xlsx"))
                        Dim wb As ExcelWorkbook = plantilla.Workbook
                        Dim hoja As ExcelWorksheet = wb.Worksheets(1)

                        Dim dtHorasExtras As DataTable = sqlExecute("select  * from TA.dbo.asist where FHA_ENT_HOR between '" & FechaSQL(f_inicio) & "' and '" & FechaSQL(f_final) & "'")

                        '== Filtra los relojes del datatable principal para proceder la búsqueda en las horas extras
                        If dtHorasExtras.Rows.Count > 0 Then
                            For Each drow As DataRow In dtInformacionFiltro.Rows
                                If Not relojes.Contains(drow.Item("reloj").ToString.Trim) Then
                                    relojes = relojes & "'" & drow.Item("reloj").ToString.Trim & "'-"
                                    plantas = plantas & drow.Item("nombre_planta").ToString.Trim & ","
                                    row = dtDatosEmp.NewRow
                                    row("reloj") = drow.Item("reloj").ToString.Trim
                                    row("nombres") = drow.Item("nombres").ToString.Trim
                                    row("puesto") = drow.Item("nombre_puesto_personal").ToString.Trim
                                    row("departamento") = drow.Item("nombre_depto_personal").ToString.Trim
                                    dtDatosEmp.Rows.Add(row)
                                End If
                            Next

                            '== Valores por default en datatable
                            For Each r As DataRow In dtDatosEmp.Rows
                                Dim hrsDef As String = "0"
                                r.Item("Lunes") = hrsDef : r.Item("Martes") = hrsDef : r.Item("Miércoles") = hrsDef
                                r.Item("Jueves") = hrsDef : r.Item("Viernes") = hrsDef : r.Item("Sábado") = hrsDef
                                r.Item("Domingo") = hrsDef
                            Next

                            Dim cadena As String = Replace(relojes.Substring(0, relojes.Length - 1), "-", ",") : Dim filtro As String = "reloj in (" & cadena & ")"

                            '== Planta de empleados
                            Dim a As Integer = 0 : Dim b As Integer = 0 : Dim coincidencias As MatchCollection : Dim _planta As String = ""
                            Dim dtPlanta As DataTable = Nothing
                            coincidencias = Regex.Matches(plantas, "CORTE") : a = coincidencias.Count
                            coincidencias = Regex.Matches(plantas, "PIEL") : b = coincidencias.Count

                            If a >= b Then
                                _planta = "PLANTA 001: CORTE"
                            Else
                                _planta = "PLANTA 002: PIEL"
                            End If

                            If a = 0 And b = 0 Then
                                _planta = "PLANTA INDEFINIDA"
                            End If

                            '== Horas extras
                            For Each hrs As DataRow In dtHorasExtras.Select(filtro, "reloj")
                                relojes = hrs.Item("reloj").ToString.Trim
                                For Each emp As DataRow In dtDatosEmp.Select("reloj='" & relojes & "'")
                                    emp.Item(hrs.Item("dia_entro").ToString.Trim) = HtoD(hrs.Item("horas_extras").ToString.Trim)
                                Next
                            Next

                            '== Llenar hoja de excel con la información
                            Dim x As Integer = 0 : Dim y As Integer = 0 : Dim f As Integer = 0 : Dim c As Integer = 0 : Dim sum As Double = 0.0
                            Dim _periodo As String = "Periodo " & p_num & " " & p_anio
                            Dim _rangoFechas As String = "Del " & FechaMediaLetra(f_inicio) & " a " & FechaMediaLetra(f_final)

                            hoja.Cells(7, 2).Value = _planta
                            hoja.Cells(7, 6).Value = _periodo
                            hoja.Cells(7, 7).Value = _rangoFechas

                            x = 12 : y = 2

                            Dim rango As String = "" : Dim formula As String = ""
                            Dim fil As Integer = 0 : Dim col As Integer = 0 : Dim cont As Integer = 0
                            Dim dias(7) As Double

                            For Each z As DataRow In dtDatosEmp.Rows
                                hoja.Cells(x + f, y + c).Value = z.Item("reloj").ToString : c += 1
                                hoja.Cells(x + f, y + c).Value = z.Item("nombres").ToString : c += 1
                                hoja.Cells(x + f, y + c).Value = z.Item("puesto").ToString : c += 1
                                hoja.Cells(x + f, y + c).Value = z.Item("departamento").ToString : c += 2

                                '== Original (comentado)        16dic2021
                                'hoja.Cells(x + f, y + c).Value = CDbl(z.Item("Lunes")) : c += 1 : dias(0) += CDbl(z.Item("Lunes"))
                                'hoja.Cells(x + f, y + c).Value = CDbl(z.Item("Martes")) : c += 1 : dias(1) += CDbl(z.Item("Martes"))
                                'hoja.Cells(x + f, y + c).Value = CDbl(z.Item("Miércoles")) : c += 1 : dias(2) += CDbl(z.Item("Miércoles"))
                                'hoja.Cells(x + f, y + c).Value = CDbl(z.Item("Jueves")) : c += 1 : dias(3) += CDbl(z.Item("Jueves"))
                                'hoja.Cells(x + f, y + c).Value = CDbl(z.Item("Viernes")) : c += 1 : dias(4) += CDbl(z.Item("Viernes"))
                                'hoja.Cells(x + f, y + c).Value = CDbl(z.Item("Sábado")) : c += 1 : dias(5) += CDbl(z.Item("Sábado"))
                                'hoja.Cells(x + f, y + c).Value = CDbl(z.Item("Domingo")) : c += 1 : dias(6) += CDbl(z.Item("Domingo"))

                                '== Comentado (Original)            16dic2021
                                'sum = CDbl(z.Item("Lunes")) + CDbl(z.Item("Martes")) + CDbl(z.Item("Miércoles")) + CDbl(z.Item("Jueves")) +
                                '            CDbl(z.Item("Viernes")) + CDbl(z.Item("Sábado")) + CDbl(z.Item("Domingo"))

                                '== Redondea despues del 0.5 decimal             16dic2021
                                hoja.Cells(x + f, y + c).Value = RedondeaCifra(CDbl(z.Item("Lunes"))) : c += 1 : dias(0) += RedondeaCifra(CDbl(z.Item("Lunes")))
                                hoja.Cells(x + f, y + c).Value = RedondeaCifra(CDbl(z.Item("Martes"))) : c += 1 : dias(1) += RedondeaCifra(CDbl(z.Item("Martes")))
                                hoja.Cells(x + f, y + c).Value = RedondeaCifra(CDbl(z.Item("Miércoles"))) : c += 1 : dias(2) += RedondeaCifra(CDbl(z.Item("Miércoles")))
                                hoja.Cells(x + f, y + c).Value = RedondeaCifra(CDbl(z.Item("Jueves"))) : c += 1 : dias(3) += RedondeaCifra(CDbl(z.Item("Jueves")))
                                hoja.Cells(x + f, y + c).Value = RedondeaCifra(CDbl(z.Item("Viernes"))) : c += 1 : dias(4) += RedondeaCifra(CDbl(z.Item("Viernes")))
                                hoja.Cells(x + f, y + c).Value = RedondeaCifra(CDbl(z.Item("Sábado"))) : c += 1 : dias(5) += RedondeaCifra(CDbl(z.Item("Sábado")))
                                hoja.Cells(x + f, y + c).Value = RedondeaCifra(CDbl(z.Item("Domingo"))) : c += 1 : dias(6) += RedondeaCifra(CDbl(z.Item("Domingo")))

                                '== Redondea despues del 0.5 decimal           16dic2021
                                sum = RedondeaCifra(CDbl(z.Item("Lunes"))) + RedondeaCifra(CDbl(z.Item("Martes"))) + RedondeaCifra(CDbl(z.Item("Miércoles"))) + RedondeaCifra(CDbl(z.Item("Jueves"))) +
                                            RedondeaCifra(CDbl(z.Item("Viernes"))) + RedondeaCifra(CDbl(z.Item("Sábado"))) + RedondeaCifra(CDbl(z.Item("Domingo")))

                                hoja.Cells(x + f, y + c).Value = sum
                                dias(7) += sum

                                rango = "B" & (x + f).ToString & ":P" & (x + f).ToString
                                hoja.SelectedRange(rango).Style.Border.Right.Style = Style.ExcelBorderStyle.Thin
                                hoja.SelectedRange(rango).Style.Border.Left.Style = Style.ExcelBorderStyle.Thin
                                hoja.SelectedRange(rango).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                                fil = x + f
                                col = y + c

                                If cont = dtDatosEmp.Rows.Count - 1 Then
                                    rango = "B" & (fil + 1).ToString & ":F" & (fil + 1).ToString
                                    hoja.Cells(fil + 1, y).Value = "TOTAL DE TIEMPO EXTRA"
                                    hoja.Cells(fil + 1, y).Style.Font.Bold = True
                                    hoja.SelectedRange(rango).Merge = True
                                    hoja.Cells(fil + 1, y + 5).Value = dias(0).ToString
                                    hoja.Cells(fil + 1, y + 6).Value = dias(1).ToString
                                    hoja.Cells(fil + 1, y + 7).Value = dias(2).ToString
                                    hoja.Cells(fil + 1, y + 8).Value = dias(3).ToString
                                    hoja.Cells(fil + 1, y + 9).Value = dias(4).ToString
                                    hoja.Cells(fil + 1, y + 10).Value = dias(5).ToString
                                    hoja.Cells(fil + 1, y + 11).Value = dias(6).ToString
                                    hoja.Cells(fil + 1, y + 12).Value = dias(7).ToString

                                    rango = "B" & (fil + 1).ToString & ":P" & (fil + 1).ToString
                                    hoja.SelectedRange(rango).Style.Border.Right.Style = Style.ExcelBorderStyle.Thin
                                    hoja.SelectedRange(rango).Style.Border.Left.Style = Style.ExcelBorderStyle.Thin
                                    hoja.SelectedRange(rango).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                                End If
                                cont += 1
                                x += 1 : c = 0 : f = 0 : sum = 0
                            Next

                            hoja.Cells(fil + 3, y).Value = "OBSERVACIONES"
                            hoja.Cells(fil + 3, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                            hoja.Cells(fil + 3, y).Style.Font.Bold = True

                            rango = "B" & (fil + 4).ToString & ":P" & (fil + 5).ToString
                            hoja.SelectedRange(rango).Merge = True
                            hoja.SelectedRange(rango).Style.Border.Right.Style = Style.ExcelBorderStyle.Thin
                            hoja.SelectedRange(rango).Style.Border.Left.Style = Style.ExcelBorderStyle.Thin
                            hoja.SelectedRange(rango).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                            hoja.SelectedRange(rango).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin

                            rango = "B" & (fil + 6).ToString & ":C" & (fil + 6).ToString
                            hoja.SelectedRange(rango).Merge = True
                            hoja.Cells(fil + 6, y).Value = "NOTA: Todos los campos deberán de estar debidamente llenos"
                            hoja.Cells(fil + 6, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                            hoja.Cells(fil + 6, y).Style.Font.Bold = True

                            rango = "B" & (fil + 11).ToString & ":C" & (fil + 11).ToString
                            hoja.SelectedRange(rango).Merge = True : hoja.SelectedRange(rango).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                            rango = "E" & (fil + 11).ToString & ":F" & (fil + 11).ToString
                            hoja.SelectedRange(rango).Merge = True : hoja.SelectedRange(rango).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                            rango = "H" & (fil + 11).ToString & ":N" & (fil + 11).ToString
                            hoja.SelectedRange(rango).Merge = True : hoja.SelectedRange(rango).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin

                            rango = "B" & (fil + 12).ToString & ":C" & (fil + 12).ToString : hoja.SelectedRange(rango).Merge = True : hoja.Cells(fil + 12, y).Value = "Supervisor de área"
                            rango = "E" & (fil + 12).ToString & ":F" & (fil + 12).ToString : hoja.SelectedRange(rango).Merge = True : hoja.Cells(fil + 12, y + 3).Value = "Gerente de Recursos Humanos"
                            rango = "H" & (fil + 12).ToString & ":N" & (fil + 12).ToString : hoja.SelectedRange(rango).Merge = True : hoja.Cells(fil + 12, y + 6).Value = "Director de planta"


                            rango = "B" & (fil + 19).ToString & ":C" & (fil + 19).ToString
                            hoja.SelectedRange(rango).Merge = True : hoja.SelectedRange(rango).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                            rango = "E" & (fil + 19).ToString & ":F" & (fil + 19).ToString
                            hoja.SelectedRange(rango).Merge = True : hoja.SelectedRange(rango).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                            rango = "H" & (fil + 19).ToString & ":N" & (fil + 19).ToString
                            hoja.SelectedRange(rango).Merge = True : hoja.SelectedRange(rango).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin

                            rango = "B" & (fil + 20).ToString & ":C" & (fil + 20).ToString : hoja.SelectedRange(rango).Merge = True : hoja.Cells(fil + 20, y).Value = "Gerente de área"
                            rango = "E" & (fil + 20).ToString & ":F" & (fil + 20).ToString : hoja.SelectedRange(rango).Merge = True : hoja.Cells(fil + 20, y + 3).Value = "Gerente de finanzas"
                            rango = "H" & (fil + 20).ToString & ":N" & (fil + 20).ToString : hoja.SelectedRange(rango).Merge = True : hoja.Cells(fil + 20, y + 6).Value = "Nóminas"

                            'Try : hoja.Cells(hoja.Dimension.Address).AutoFitColumns() : Catch ex As Exception : End Try
                            plantilla.SaveAs(New System.IO.FileInfo(fbd.FileName))
                            MessageBox.Show("Archivo generado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Else
                    MessageBox.Show("No se encontró el archivo base, contacte al administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    '== Redondear la cifra          12ene2022
    Private Function RedondeaCifra(cant As Double) As Double
        Try
            Dim cantidad As String = CStr(cant)
            Dim r() As String = Split(cantidad, ".")
            Dim resultado As Double = 0.0

            If r.Count > 1 Then
                Dim decimales As Double = IIf(r(1).Length = 1, r(1) * 10, r(1))
                If decimales >= 50 Then
                    resultado = CDbl(r(0)) + 0.5
                Else
                    resultado = CDbl(r(0))
                End If
                Return resultado
            Else
                Return cant
            End If
            Return cant
        Catch ex As Exception
        End Try
    End Function

    ''' <summary>
    ''' 'Método para generar reporte de asistencia por día
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub AsistenciaXDia(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Try

            Dim dtAuxEmpleados As New DataTable

            '----Solicita fecha
            Dim fechaproy As String = ""
            Dim selFecha As frmSeleccionarFecha = New frmSeleccionarFecha()
            selFecha.ShowDialog()
            '  fechaproy = FechaSQL(selFecha.dtFechaInicial.Value)
            fechaproy = FechaSQL(FechaInicial)

            Dim Q As String = "", dtInfoAsistDiaria As New DataTable
            Dim ENCABEZADO_EMPRESA As String = "", DIR_EMPRESA As String = ""

            Q = "select a.COD_COMP,a.RELOJ,p.nombres,p.nombre_depto,a.FHA_ENT_HOR,a.ENTRO,a.FHA_SAL_HOR,a.SALIO,a.HORAS_NORMALES,a.HORAS,a.TIPO_AUS,au.REFERENCIA,a.COMENTARIO " & _
                "from asist a left outer join PERSONAL.dbo.personalvw p on a.RELOJ=p.RELOJ " & _
                "left outer join ausentismo au on a.RELOJ=au.RELOJ and a.FHA_ENT_HOR=au.FECHA " & _
                "where a.FHA_ENT_HOR='" & fechaproy & "' order by reloj asc"

            dtInfoAsistDiaria = sqlExecute(Q, "TA")

            If Not dtInfoAsistDiaria.Columns.Contains("Error") And dtInfoAsistDiaria.Rows.Count > 0 Then

                dtDatos = New DataTable
                If Not dtDatos.Columns.Contains("RELOJ") Then dtDatos.Columns.Add("RELOJ", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("NOMBRES") Then dtDatos.Columns.Add("NOMBRES", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FHA_ENT_HOR") Then dtDatos.Columns.Add("FHA_ENT_HOR", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ENTRO") Then dtDatos.Columns.Add("ENTRO", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("SALIO") Then dtDatos.Columns.Add("SALIO", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("HORAS") Then dtDatos.Columns.Add("HORAS", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("COMENTARIO") Then dtDatos.Columns.Add("COMENTARIO", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("REFERENCIA") Then dtDatos.Columns.Add("REFERENCIA", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ENCABEZADO_EMPRESA") Then dtDatos.Columns.Add("ENCABEZADO_EMPRESA", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("DIR_EMPRESA") Then dtDatos.Columns.Add("DIR_EMPRESA", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("RUTA_CLIENTE") Then dtDatos.Columns.Add("RUTA_CLIENTE", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("TOTAL") Then dtDatos.Columns.Add("TOTAL", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ASISTENCIAS") Then dtDatos.Columns.Add("ASISTENCIAS", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FALTAS") Then dtDatos.Columns.Add("FALTAS", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("TIPO_AUS") Then dtDatos.Columns.Add("TIPO_AUS", Type.GetType("System.String"))

                '----Obtener Encabezado y direccion de la empresa
                Dim dtCia As DataTable = sqlExecute("select * from PERSONAL.dbo.cias where CIA_DEFAULT=1", "PERSONAL")
                If Not dtCia.Columns.Contains("Error") And dtCia.Rows.Count > 0 Then
                    Dim rep_legal As String = "", rfc As String = "", direccion As String = "", colonia As String = "", cod_postal As String = "", telefono1 As String = "", ciudad As String = "", estado As String = ""

                    Try : rep_legal = dtCia.Rows(0).Item("rep_legal").ToString.Trim.ToUpper : Catch ex As Exception : rep_legal = "" : End Try
                    Try : rfc = dtCia.Rows(0).Item("rfc").ToString.Trim.ToUpper : Catch ex As Exception : rfc = "" : End Try
                    Try : direccion = dtCia.Rows(0).Item("direccion").ToString.Trim.ToUpper : Catch ex As Exception : direccion = "" : End Try
                    Try : colonia = dtCia.Rows(0).Item("colonia").ToString.Trim.ToUpper : Catch ex As Exception : colonia = "" : End Try
                    Try : cod_postal = dtCia.Rows(0).Item("cod_postal").ToString.Trim.ToUpper : Catch ex As Exception : cod_postal = "" : End Try
                    Try : telefono1 = dtCia.Rows(0).Item("telefono1").ToString.Trim.ToUpper : Catch ex As Exception : telefono1 = "" : End Try
                    Try : ciudad = dtCia.Rows(0).Item("ciudad").ToString.Trim.ToUpper : Catch ex As Exception : ciudad = "" : End Try
                    Try : estado = dtCia.Rows(0).Item("estado").ToString.Trim.ToUpper : Catch ex As Exception : estado = "" : End Try

                    ENCABEZADO_EMPRESA = rep_legal & "  RFC:" & rfc
                    DIR_EMPRESA = "CALLE " & direccion & " " & colonia & " C.P." & cod_postal & ", TEL:" & telefono1 & " " & ciudad & ", " & estado

                End If

                dtAuxEmpleados = sqlExecute("select reloj,contenido from detalle_auxiliares where campo='001' order by reloj asc ", "PERSONAL")


                For Each dr As DataRow In dtInfoAsistDiaria.Rows
                    Dim reloj As String = "", nombres As String = "", fecha As String = "", hora_entrada As String = "", hora_salida As String = "", horas_laboradas As String = ""
                    Dim incidencia As String = "", motivo_inci As String = "", ruta_cliente As String = ""
                    Dim tipo_aus As String = ""

                    Try : reloj = dr("RELOJ").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                    Try : nombres = dr("NOMBRES").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
                    Try : fecha = FechaSQL(dr("FHA_ENT_HOR")) : Catch ex As Exception : fecha = "" : End Try
                    Try : hora_entrada = dr("ENTRO").ToString.Trim : Catch ex As Exception : hora_entrada = "" : End Try
                    Try : hora_salida = dr("SALIO").ToString.Trim : Catch ex As Exception : hora_salida = "" : End Try
                    Try : horas_laboradas = dr("HORAS").ToString.Trim : Catch ex As Exception : horas_laboradas = "" : End Try
                    Try : incidencia = dr("COMENTARIO").ToString.Trim : Catch ex As Exception : incidencia = "" : End Try
                    Try : motivo_inci = dr("REFERENCIA").ToString.Trim : Catch ex As Exception : motivo_inci = "" : End Try
                    Try : tipo_aus = dr("TIPO_AUS").ToString.Trim : Catch ex As Exception : tipo_aus = "" : End Try


                    '---Obtener la ruta_cliente del empleado
                    Dim item = (From x In dtAuxEmpleados.Rows Where x("reloj").ToString.Trim = reloj).ToList()
                    If (item.Count > 0) Then Try : ruta_cliente = (item.First()("contenido").ToString.Trim) : Catch ex As Exception : ruta_cliente = "" : End Try



                    dtDatos.Rows.Add({reloj, nombres, fecha, hora_entrada, hora_salida, horas_laboradas, incidencia, motivo_inci, ENCABEZADO_EMPRESA, DIR_EMPRESA, ruta_cliente, "0", "0", "0", tipo_aus})
                Next
            Else
                MessageBox.Show("No hay información de asistencia para el día seleccionado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            '**--************---******-***********************----Obtener totales de total de registros, ASISTENCIAS y FALTAS (FI) para cada Grupo
            Dim dtDistinctGroup As DataTable = sqlExecute("select distinct contenido from detalle_auxiliares where campo='001'", "PERSONAL")
            If Not dtDistinctGroup.Columns.Contains("Error") And dtDistinctGroup.Rows.Count > 0 Then
                For Each dr As DataRow In dtDistinctGroup.Rows
                    Dim ruta_cliente As String = ""
                    Try : ruta_cliente = dr("contenido").ToString.Trim : Catch ex As Exception : ruta_cliente = "" : End Try

                    If dtDatos.Select("ruta_cliente='" & ruta_cliente & "'").Count > 0 Then
                        Dim total As String = "", asistencias As String = "", faltas As String = ""
                        total = dtDatos.Select("ruta_cliente='" & ruta_cliente & "'").Count
                        asistencias = dtDatos.Select("ruta_cliente='" & ruta_cliente & "' and tipo_aus=''").Count
                        faltas = dtDatos.Select("ruta_cliente='" & ruta_cliente & "' and tipo_aus='FI'").Count

                        For Each drAsis As DataRow In dtDatos.Select("ruta_cliente='" & ruta_cliente & "'")
                            drAsis("TOTAL") = total
                            drAsis("ASISTENCIAS") = asistencias
                            drAsis("FALTAS") = faltas
                        Next

                    End If

                Next
            End If
            '**--************---******-***********************----END Obtener totales


            'If FechaInicial = Nothing Then
            '    dtDatos = sqlExecute("select h.reloj,p.nombres,p.nombre_tipoemp,p.nombre_horario,p.alta,p.baja,h.dia,h.fecha,h.hora from ta.dbo.hrs_brt h left join personal.dbo.personalvw p on h.reloj=p.reloj where 1=2", "TA")
            'Else
            '    dtDatos = sqlExecute("select h.reloj,p.nombres,p.nombre_tipoemp,p.nombre_horario,p.alta,p.baja,h.dia,h.fecha,h.hora from ta.dbo.hrs_brt h left " & _
            '                         "join personal.dbo.personalvw p on h.reloj=p.reloj where fecha between '" & _
            '                         FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'", "TA")
            'End If

            ''== Filtro para el usuario      3jun2021        Ernesto
            'Dim dtTemp As New DataTable
            'dtTemp = dtDatos.Clone
            'For Each drow As DataRow In dtDatos.Rows
            '    Dim rj As String = ""
            '    rj = drow("reloj").ToString.Trim
            '    If (dtInformacion.Select("reloj='" & rj & "'").Count > 0) Then
            '        dtTemp.ImportRow(drow)
            '    End If
            'Next
            'dtDatos = dtTemp.Copy

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la generación del reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Rep.Asistencia por día", ex.HResult, ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 'Método para generar reporte de asistencia semanal
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub AsistenciaSemanal(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            Dim dtAuxEmpleados As New DataTable, Q As String = "", ENCABEZADO_EMPRESA As String = "", DIR_EMPRESA As String = "", dtInfoAsistSemanal As New DataTable, periodo As String = "", dtDataNomsem As New DataTable
            Dim _fInic As String = FechaSQL(FechaInicial)
            Dim _fFin As String = FechaSQL(FechaFinal)
            Dim dtInfoPersonal As New DataTable


            periodo = AnoSelec & PeriodoSelec

            '----Query de todos los empleados que estan en asist en ese periodo
            Q = "select distinct a.reloj,a.COD_COMP,p.nombres, a.ANO,a.PERIODO " & _
    "from ta.dbo.asist a   left outer join PERSONAL.dbo.personalvw p on a.RELOJ=p.RELOJ " & _
    "where a.ano+a.periodo='" & periodo & "' order by reloj asc"

            dtInfoPersonal = sqlExecute(Q, "TA")

            '----Query de cada uno de los dias de cada no de los empleados
            Q = "select distinct a.reloj,a.COD_COMP,p.nombres,a.DIA_ENTRO,a.FHA_ENT_HOR,a.ENTRO,a.FHA_SAL_HOR,a.SALIO,a.HORAS,a.TIPO_AUS,a.COMENTARIO " & _
            "from ta.dbo.asist a   left outer join PERSONAL.dbo.personalvw p on a.RELOJ=p.RELOJ " & _
            "where a.ano+a.periodo='" & periodo & "' order by reloj asc,FHA_ENT_HOR asc"

            dtInfoAsistSemanal = sqlExecute(Q, "TA")


            If (Not dtInfoPersonal.Columns.Contains("Error") And dtInfoPersonal.Rows.Count > 0) Then

                '---Rutas de los clientes para cada empleado
                dtAuxEmpleados = sqlExecute("select reloj,contenido from detalle_auxiliares where campo='001' order by reloj asc ", "PERSONAL")

                '---Datos de nomsem
                dtDataNomsem = sqlExecute(" select * from nomsem where ano+PERIODO='" & periodo & "'", "TA")

                dtDatos = New DataTable
                If Not dtDatos.Columns.Contains("RELOJ") Then dtDatos.Columns.Add("RELOJ", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("NOMBRES") Then dtDatos.Columns.Add("NOMBRES", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("HORAS") Then dtDatos.Columns.Add("HORAS", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ENCABEZADO_EMPRESA") Then dtDatos.Columns.Add("ENCABEZADO_EMPRESA", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("DIR_EMPRESA") Then dtDatos.Columns.Add("DIR_EMPRESA", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("RUTA_CLIENTE") Then dtDatos.Columns.Add("RUTA_CLIENTE", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ENTRO1") Then dtDatos.Columns.Add("ENTRO1", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("SALIO1") Then dtDatos.Columns.Add("SALIO1", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("INCI1") Then dtDatos.Columns.Add("INCI1", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ENTRO2") Then dtDatos.Columns.Add("ENTRO2", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("SALIO2") Then dtDatos.Columns.Add("SALIO2", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("INCI2") Then dtDatos.Columns.Add("INCI2", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ENTRO3") Then dtDatos.Columns.Add("ENTRO3", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("SALIO3") Then dtDatos.Columns.Add("SALIO3", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("INCI3") Then dtDatos.Columns.Add("INCI3", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ENTRO4") Then dtDatos.Columns.Add("ENTRO4", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("SALIO4") Then dtDatos.Columns.Add("SALIO4", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("INCI4") Then dtDatos.Columns.Add("INCI4", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ENTRO5") Then dtDatos.Columns.Add("ENTRO5", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("SALIO5") Then dtDatos.Columns.Add("SALIO5", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("INCI5") Then dtDatos.Columns.Add("INCI5", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ENTRO6") Then dtDatos.Columns.Add("ENTRO6", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("SALIO6") Then dtDatos.Columns.Add("SALIO6", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("INCI6") Then dtDatos.Columns.Add("INCI6", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ENTRO7") Then dtDatos.Columns.Add("ENTRO7", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("SALIO7") Then dtDatos.Columns.Add("SALIO7", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("INCI7") Then dtDatos.Columns.Add("INCI7", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("HRSLAB1") Then dtDatos.Columns.Add("HRSLAB1", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("HRSLAB2") Then dtDatos.Columns.Add("HRSLAB2", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("HRSLAB3") Then dtDatos.Columns.Add("HRSLAB3", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("HRSLAB4") Then dtDatos.Columns.Add("HRSLAB4", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("HRSLAB5") Then dtDatos.Columns.Add("HRSLAB5", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("HRSLAB6") Then dtDatos.Columns.Add("HRSLAB6", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("HRSLAB7") Then dtDatos.Columns.Add("HRSLAB7", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("BONASI") Then dtDatos.Columns.Add("BONASI", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("BONPUN") Then dtDatos.Columns.Add("BONPUN", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FINIC") Then dtDatos.Columns.Add("FINIC", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FFIN") Then dtDatos.Columns.Add("FFIN", Type.GetType("System.String"))

                '----Obtener Encabezado y direccion de la empresa
                Dim dtCia As DataTable = sqlExecute("select * from PERSONAL.dbo.cias where CIA_DEFAULT=1", "PERSONAL")
                If Not dtCia.Columns.Contains("Error") And dtCia.Rows.Count > 0 Then
                    Dim rep_legal As String = "", rfc As String = "", direccion As String = "", colonia As String = "", cod_postal As String = "", telefono1 As String = "", ciudad As String = "", estado As String = ""

                    Try : rep_legal = dtCia.Rows(0).Item("rep_legal").ToString.Trim.ToUpper : Catch ex As Exception : rep_legal = "" : End Try
                    Try : rfc = dtCia.Rows(0).Item("rfc").ToString.Trim.ToUpper : Catch ex As Exception : rfc = "" : End Try
                    Try : direccion = dtCia.Rows(0).Item("direccion").ToString.Trim.ToUpper : Catch ex As Exception : direccion = "" : End Try
                    Try : colonia = dtCia.Rows(0).Item("colonia").ToString.Trim.ToUpper : Catch ex As Exception : colonia = "" : End Try
                    Try : cod_postal = dtCia.Rows(0).Item("cod_postal").ToString.Trim.ToUpper : Catch ex As Exception : cod_postal = "" : End Try
                    Try : telefono1 = dtCia.Rows(0).Item("telefono1").ToString.Trim.ToUpper : Catch ex As Exception : telefono1 = "" : End Try
                    Try : ciudad = dtCia.Rows(0).Item("ciudad").ToString.Trim.ToUpper : Catch ex As Exception : ciudad = "" : End Try
                    Try : estado = dtCia.Rows(0).Item("estado").ToString.Trim.ToUpper : Catch ex As Exception : estado = "" : End Try

                    ENCABEZADO_EMPRESA = rep_legal & "  RFC:" & rfc
                    DIR_EMPRESA = "CALLE " & direccion & " " & colonia & " C.P." & cod_postal & ", TEL:" & telefono1 & " " & ciudad & ", " & estado

                End If



                '---Recorrer a cada uno de los empleados
                For Each dr1 As DataRow In dtInfoPersonal.Rows ' Todos los empleados
                    'For Each dr1 As DataRow In dtInfoPersonal.Select("reloj='00076'") ' De prueba para ciertos empleados
                    Dim RELOJ As String = "", NOMBRES As String = "", HORAS As String = "", RUTA_CLIENTE As String = ""
                    Dim ENTRO1 As String = "", ENTRO2 As String = "", ENTRO3 As String = "", ENTRO4 As String = "", ENTRO5 As String = "", ENTRO6 As String = "", ENTRO7 As String = ""
                    Dim SALIO1 As String = "", SALIO2 As String = "", SALIO3 As String = "", SALIO4 As String = "", SALIO5 As String = "", SALIO6 As String = "", SALIO7 As String = ""
                    Dim INCI1 As String = "", INCI2 As String = "", INCI3 As String = "", INCI4 As String = "", INCI5 As String = "", INCI6 As String = "", INCI7 As String = ""
                    Dim HRSLAB1 As String = "00:00", HRSLAB2 As String = "00:00", HRSLAB3 As String = "00:00", HRSLAB4 As String = "00:00", HRSLAB5 As String = "00:00", HRSLAB6 As String = "00:00", HRSLAB7 As String = "00:00"
                    Dim BONASI As String = "", BONPUN As String = "", FINIC As String = "", FFIN As String = ""


                    '***********************************************************************************************************************************************************************************
                    '************************************************************************Obtener cada uno de los valores ***************************************************************************
                    '***********************************************************************************************************************************************************************************
                    Try : RELOJ = dr1("reloj").ToString.Trim : Catch ex As Exception : RELOJ = "" : End Try

                    '====Compararse contra la información de personal que vienen a raiz del filtro para solo mostrar a personal que viene del filtro
                    If (dtInformacion.Select("reloj='" & RELOJ & "'").Count <= 0) Then
                        GoTo SigRec
                    End If

                    Try : NOMBRES = dr1("nombres").ToString.Trim : Catch ex As Exception : NOMBRES = "" : End Try

                    'Obtener bono de punt y de asist de NOMSEM
                    Dim itNomsem = (From x In dtDataNomsem.Rows Where x("RELOJ").ToString.Trim = RELOJ).ToList()
                    If (itNomsem.Count > 0) Then
                        Try : BONPUN = (itNomsem.First()("BONO_PUNTUALIDAD").ToString.Trim) : Catch ex As Exception : BONPUN = "0" : End Try
                        Try : BONASI = (itNomsem.First()("BONO_ASISTENCIA").ToString.Trim) : Catch ex As Exception : BONASI = "0" : End Try
                    End If

                    '----Obtener horas totales de la semana realmente trabajadas

                    'SELECT isnull(SUM(dbo.HTOD(horas)),0)AS horas_normales FROM asist where reloj='00040' and ano+periodo='202421'
                    Dim dtHorasTrab As DataTable = sqlExecute("SELECT isnull(SUM(dbo.HTOD(horas)),0)AS horas_normales  FROM asist  WHERE  reloj = '" & RELOJ & " ' AND ano+periodo= '" & periodo & "'", "TA")
                    If Not dtHorasTrab.Columns.Contains("Error") And dtHorasTrab.Rows.Count > 0 Then Try : HORAS = dtHorasTrab.Rows(0).Item("horas_normales").ToString.Trim : Catch ex As Exception : HORAS = "00:00" : End Try
                    If HORAS <> "00:00" Then HORAS = Math.Round(Double.Parse(HORAS), 2)
                    If Not HORAS.Contains(".") Then HORAS = HORAS & ".00"


                    '---Cambiar de HH.mm a HH:MM de 49.95 a 45:35 x ejemplo (De decimal a formato HH:MM para que pase los minutos a otra hora si excedio los 60 min)
                    If HORAS <> "00:00" Then
                        Dim HH As String = "", MM As String = "", intMM As Integer = 0, MinReales As Double = 0.0, MinRealesStr As String = "", totDigMM As Integer = 0, totDigHH As Integer = 0
                        HH = HORAS.Split(".")(0).Trim
                        MM = HORAS.Split(".")(1).Trim
                        intMM = Convert.ToInt32(MM)
                        MinReales = Math.Round(((intMM * 60) / 100), 2)
                        If (MinReales.ToString.Contains(".")) Then
                            Dim pt1 As Integer = 0, pt2 As Integer = 0
                            pt2 = Convert.ToInt32(MinReales.ToString.Split(".")(1))
                            If pt2 > 5 Then MinReales = Math.Round(((intMM * 60) / 100), 0) * 10 Else MinReales = Math.Round(((intMM * 60) / 100), 2) * 10
                        End If
                        If MinReales.ToString.Contains(".") Then MinRealesStr = MinReales.ToString.Split(".")(0) Else MinRealesStr = MinReales.ToString.Trim

                        totDigHH = Len(HH)
                        totDigMM = Len(MinRealesStr)
                        If totDigHH = 1 Then HH = "0" & HH
                        If totDigMM = 1 Then MinRealesStr = "0" & MinRealesStr

                        totDigMM = Len(MinRealesStr)
                        If totDigMM >= 2 Then MinRealesStr = MinRealesStr.Substring(0, 2)

                        HORAS = HH & ":" & MinRealesStr
                    End If
                    ' End Cambiar formato 

                    '---Obtener la ruta_cliente del empleado
                    Dim item = (From x In dtAuxEmpleados.Rows Where x("RELOJ").ToString.Trim = RELOJ).ToList()
                    If (item.Count > 0) Then Try : RUTA_CLIENTE = (item.First()("contenido").ToString.Trim) : Catch ex As Exception : RUTA_CLIENTE = "SIN RUTA ASIGNADA" : End Try
                    If RUTA_CLIENTE.Trim = "" Then RUTA_CLIENTE = "SIN RUTA ASIGNADA"

                    '---Recorrer cada dia de cada uno de los empleados para obtener entrada, salida, incidencia y horas x dia
                    For Each dr As DataRow In dtInfoAsistSemanal.Select("reloj='" & RELOJ & "'")
                        Dim dia_entro As String = "", comentario As String = ""
                        Try : dia_entro = dr("DIA_ENTRO").ToString.Trim : Catch ex As Exception : dia_entro = "" : End Try
                        Try : comentario = dr("COMENTARIO").ToString.Trim : Catch ex As Exception : comentario = "" : End Try

                        If dia_entro = "Lunes" Then
                            Try : ENTRO1 = dr("ENTRO").ToString.Trim : Catch ex As Exception : ENTRO1 = "" : End Try
                            Try : SALIO1 = dr("SALIO").ToString.Trim : Catch ex As Exception : SALIO1 = "" : End Try
                            Try : INCI1 = dr("TIPO_AUS").ToString.Trim : Catch ex As Exception : INCI1 = "" : End Try
                            Try : HRSLAB1 = dr("HORAS").ToString.Trim : Catch ex As Exception : HRSLAB1 = "00:00" : End Try
                            If INCI1 = "" And comentario.Contains("RETARDO") Then INCI1 = "RET"

                        ElseIf dia_entro = "Martes" Then
                            Try : ENTRO2 = dr("ENTRO").ToString.Trim : Catch ex As Exception : ENTRO2 = "" : End Try
                            Try : SALIO2 = dr("SALIO").ToString.Trim : Catch ex As Exception : SALIO2 = "" : End Try
                            Try : INCI2 = dr("TIPO_AUS").ToString.Trim : Catch ex As Exception : INCI2 = "" : End Try
                            Try : HRSLAB2 = dr("HORAS").ToString.Trim : Catch ex As Exception : HRSLAB2 = "00:00" : End Try
                            If INCI2 = "" And comentario.Contains("RETARDO") Then INCI2 = "RET"
                        ElseIf dia_entro = "Miércoles" Then
                            Try : ENTRO3 = dr("ENTRO").ToString.Trim : Catch ex As Exception : ENTRO3 = "" : End Try
                            Try : SALIO3 = dr("SALIO").ToString.Trim : Catch ex As Exception : SALIO3 = "" : End Try
                            Try : INCI3 = dr("TIPO_AUS").ToString.Trim : Catch ex As Exception : INCI3 = "" : End Try
                            Try : HRSLAB3 = dr("HORAS").ToString.Trim : Catch ex As Exception : HRSLAB3 = "00:00" : End Try
                            If INCI3 = "" And comentario.Contains("RETARDO") Then INCI3 = "RET"
                        ElseIf dia_entro = "Jueves" Then
                            Try : ENTRO4 = dr("ENTRO").ToString.Trim : Catch ex As Exception : ENTRO4 = "" : End Try
                            Try : SALIO4 = dr("SALIO").ToString.Trim : Catch ex As Exception : SALIO4 = "" : End Try
                            Try : INCI4 = dr("TIPO_AUS").ToString.Trim : Catch ex As Exception : INCI4 = "" : End Try
                            Try : HRSLAB4 = dr("HORAS").ToString.Trim : Catch ex As Exception : HRSLAB4 = "00:00" : End Try
                            If INCI4 = "" And comentario.Contains("RETARDO") Then INCI4 = "RET"
                        ElseIf dia_entro = "Viernes" Then
                            Try : ENTRO5 = dr("ENTRO").ToString.Trim : Catch ex As Exception : ENTRO5 = "" : End Try
                            Try : SALIO5 = dr("SALIO").ToString.Trim : Catch ex As Exception : SALIO5 = "" : End Try
                            Try : INCI5 = dr("TIPO_AUS").ToString.Trim : Catch ex As Exception : INCI5 = "" : End Try
                            Try : HRSLAB5 = dr("HORAS").ToString.Trim : Catch ex As Exception : HRSLAB5 = "00:00" : End Try
                            If INCI5 = "" And comentario.Contains("RETARDO") Then INCI5 = "RET"
                        ElseIf dia_entro = "Sábado" Then
                            Try : ENTRO6 = dr("ENTRO").ToString.Trim : Catch ex As Exception : ENTRO6 = "" : End Try
                            Try : SALIO6 = dr("SALIO").ToString.Trim : Catch ex As Exception : SALIO6 = "" : End Try
                            Try : INCI6 = dr("TIPO_AUS").ToString.Trim : Catch ex As Exception : INCI6 = "" : End Try
                            Try : HRSLAB6 = dr("HORAS").ToString.Trim : Catch ex As Exception : HRSLAB6 = "00:00" : End Try
                            If INCI6 = "" And comentario.Contains("RETARDO") Then INCI6 = "RET"
                        ElseIf dia_entro = "Domingo" Then
                            Try : ENTRO7 = dr("ENTRO").ToString.Trim : Catch ex As Exception : ENTRO7 = "" : End Try
                            Try : SALIO7 = dr("SALIO").ToString.Trim : Catch ex As Exception : SALIO7 = "" : End Try
                            Try : INCI7 = dr("TIPO_AUS").ToString.Trim : Catch ex As Exception : INCI7 = "" : End Try
                            Try : HRSLAB7 = dr("HORAS").ToString.Trim : Catch ex As Exception : HRSLAB7 = "00:00" : End Try
                            If INCI7 = "" And comentario.Contains("RETARDO") Then INCI6 = "RET"
                        End If
                    Next
                    '--------------------END Recorrer cada dia

                    '---Descansos
                    If (ENTRO6 = "" And INCI6 = "") Then INCI6 = "DES"
                    If (ENTRO7 = "" And INCI7 = "") Then INCI7 = "DES"

                    '---Fecha inicial y final del periodo a consultar
                    FINIC = _fInic
                    FFIN = _fFin


                    '***********************************************************************************************************************************************************************************
                    '************************************************************************END: Obtener cada uno de los valores****************************************************************************
                    '***********************************************************************************************************************************************************************************

                    dtDatos.Rows.Add({RELOJ, NOMBRES, HORAS, ENCABEZADO_EMPRESA, DIR_EMPRESA, RUTA_CLIENTE, ENTRO1, SALIO1, INCI1, ENTRO2, SALIO2, INCI2, ENTRO3, SALIO3, INCI3,
                                      ENTRO4, SALIO4, INCI4, ENTRO5, SALIO5, INCI5, ENTRO6, SALIO6, INCI6, ENTRO7, SALIO7, INCI7, HRSLAB1, HRSLAB2, HRSLAB3, HRSLAB4, HRSLAB5, HRSLAB6, HRSLAB7,
                                      BONASI, BONPUN, FINIC, FFIN})

SigRec:
                Next

            Else
                MessageBox.Show("No hay información de asistencia para la semana seleccionada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la generación del reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Rep.Asistencia Semanal", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 'Método para generar reporte de Métrico de 60 horas
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub Metrico60Horas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtAuxEmpleados As New DataTable, Q As String = "", ENCABEZADO_EMPRESA As String = "", DIR_EMPRESA As String = "", dtInfoAsistSemanal As New DataTable, periodo As String = "", dtDataNomsem As New DataTable
            Dim _fInic As String = FechaSQL(FechaInicial)
            Dim _fFin As String = FechaSQL(FechaFinal)
            Dim dtInfoPersonal As New DataTable


            periodo = AnoSelec & PeriodoSelec

            '---Query para obtener el acumulado de horas
            Q = "select RELOJ,sum(isnull(HRS_NORMALES,0) + isnull(HRS_DOBLES,0) + isnull(HRS_TRIPLES,0)) as 'total_horas' from nomsem where  ano+periodo='" & periodo & "' group by reloj order by reloj asc"
            dtDataNomsem = sqlExecute(Q, "TA")

            '---Obtener info de personal
            Q = "select * from personal.dbo.personalvw where reloj in (select RELOJ from nomsem where  ano+periodo='" & periodo & "')"
            dtInfoPersonal = sqlExecute(Q, "TA")

            If Not dtDataNomsem.Columns.Contains("ERROR") And dtDataNomsem.Rows.Count > 0 Then

                '---Rutas de los clientes para cada empleado
                dtAuxEmpleados = sqlExecute("select reloj,contenido from detalle_auxiliares where campo='001' order by reloj asc ", "PERSONAL")

                dtDatos = New DataTable
                If Not dtDatos.Columns.Contains("RELOJ") Then dtDatos.Columns.Add("RELOJ", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("NOMBRES") Then dtDatos.Columns.Add("NOMBRES", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("HORAS") Then dtDatos.Columns.Add("HORAS", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ENCABEZADO_EMPRESA") Then dtDatos.Columns.Add("ENCABEZADO_EMPRESA", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("DIR_EMPRESA") Then dtDatos.Columns.Add("DIR_EMPRESA", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("RUTA_CLIENTE") Then dtDatos.Columns.Add("RUTA_CLIENTE", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("PERIODO") Then dtDatos.Columns.Add("PERIODO", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FINI") Then dtDatos.Columns.Add("FINI", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FFIN") Then dtDatos.Columns.Add("FFIN", Type.GetType("System.String"))

                '----Obtener Encabezado y direccion de la empresa
                Dim dtCia As DataTable = sqlExecute("select * from PERSONAL.dbo.cias where CIA_DEFAULT=1", "PERSONAL")
                If Not dtCia.Columns.Contains("Error") And dtCia.Rows.Count > 0 Then
                    Dim rep_legal As String = "", rfc As String = "", direccion As String = "", colonia As String = "", cod_postal As String = "", telefono1 As String = "", ciudad As String = "", estado As String = ""

                    Try : rep_legal = dtCia.Rows(0).Item("rep_legal").ToString.Trim.ToUpper : Catch ex As Exception : rep_legal = "" : End Try
                    Try : rfc = dtCia.Rows(0).Item("rfc").ToString.Trim.ToUpper : Catch ex As Exception : rfc = "" : End Try
                    Try : direccion = dtCia.Rows(0).Item("direccion").ToString.Trim.ToUpper : Catch ex As Exception : direccion = "" : End Try
                    Try : colonia = dtCia.Rows(0).Item("colonia").ToString.Trim.ToUpper : Catch ex As Exception : colonia = "" : End Try
                    Try : cod_postal = dtCia.Rows(0).Item("cod_postal").ToString.Trim.ToUpper : Catch ex As Exception : cod_postal = "" : End Try
                    Try : telefono1 = dtCia.Rows(0).Item("telefono1").ToString.Trim.ToUpper : Catch ex As Exception : telefono1 = "" : End Try
                    Try : ciudad = dtCia.Rows(0).Item("ciudad").ToString.Trim.ToUpper : Catch ex As Exception : ciudad = "" : End Try
                    Try : estado = dtCia.Rows(0).Item("estado").ToString.Trim.ToUpper : Catch ex As Exception : estado = "" : End Try

                    ENCABEZADO_EMPRESA = rep_legal & "  RFC:" & rfc
                    DIR_EMPRESA = "CALLE " & direccion & " " & colonia & " C.P." & cod_postal & ", TEL:" & telefono1 & " " & ciudad & ", " & estado

                End If


                '-----Recorrer cada uno de los empleados 
                For Each dr As DataRow In dtDataNomsem.Rows
                    Dim RELOJ As String = "", NOMBRES As String = "", HORAS As String = "", RUTA_CLIENTE As String = "", SEMANA As String = ""


                    Try : RELOJ = dr("reloj").ToString.Trim : Catch ex As Exception : RELOJ = "" : End Try

                    '----Obtener nombre
                    Dim itPer = (From x In dtInfoPersonal.Rows Where x("RELOJ").ToString.Trim = RELOJ).ToList()
                    If itPer.Count > 0 Then Try : NOMBRES = (itPer.First()("NOMBRES").ToString.Trim) : Catch ex As Exception : NOMBRES = "" : End Try

                    '----Obtener horas de la semana
                    Dim dtHorasTrab As DataTable = sqlExecute("SELECT isnull(SUM(dbo.HTOD(horas)),0)AS horas_normales  FROM asist  WHERE  reloj = '" & RELOJ & " ' AND ano+periodo= '" & periodo & "'", "TA")
                    If Not dtHorasTrab.Columns.Contains("Error") And dtHorasTrab.Rows.Count > 0 Then Try : HORAS = dtHorasTrab.Rows(0).Item("horas_normales").ToString.Trim : Catch ex As Exception : HORAS = "00:00" : End Try
                    If HORAS <> "00:00" Then HORAS = Math.Round(Double.Parse(HORAS), 2)
                    If Not HORAS.Contains(".") Then HORAS = HORAS & ".00"

                    If HORAS <> "00:00" Then
                        Dim HH As String = "", MM As String = "", intMM As Integer = 0, MinReales As Double = 0.0, MinRealesStr As String = "", totDigMM As Integer = 0, totDigHH As Integer = 0
                        HH = HORAS.Split(".")(0).Trim
                        MM = HORAS.Split(".")(1).Trim
                        intMM = Convert.ToInt32(MM)
                        MinReales = Math.Round(((intMM * 60) / 100), 2)
                        If MinReales.ToString.Contains(".") Then MinRealesStr = MinReales.ToString.Split(".")(0) Else MinRealesStr = MinReales.ToString.Trim

                        totDigHH = Len(HH)
                        totDigMM = Len(MinRealesStr)
                        If totDigHH = 1 Then HH = "0" & HH
                        If totDigMM = 1 Then MinRealesStr = "0" & MinRealesStr

                        HORAS = HH & ":" & MinRealesStr
                    End If

                    '---Obtener la ruta_cliente del empleado
                    Dim item = (From x In dtAuxEmpleados.Rows Where x("RELOJ").ToString.Trim = RELOJ).ToList()
                    If (item.Count > 0) Then Try : RUTA_CLIENTE = (item.First()("contenido").ToString.Trim) : Catch ex As Exception : RUTA_CLIENTE = "SIN RUTA ASIGNADA" : End Try
                    If RUTA_CLIENTE.Trim = "" Then RUTA_CLIENTE = "SIN RUTA ASIGNADA"

                    SEMANA = PeriodoSelec

                    dtDatos.Rows.Add({RELOJ, NOMBRES, HORAS, ENCABEZADO_EMPRESA, DIR_EMPRESA, RUTA_CLIENTE, SEMANA, _fInic, _fFin})
                Next
            Else
                MessageBox.Show("No existe información de asistencia en el periodo seleccionado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la generación del reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Rep.Metrico 60 Hrs", ex.HResult, ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 'Método para generar reporte de incapacidades
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub RepIncap(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            If dtInformacion.Columns.Contains("Error") Or dtInformacion.Rows.Count <= 0 Then
                MessageBox.Show("No hay empleados selecionados para generar este reporte", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            '---Se desactiva rango de fechas
            'Dim frm_fechas As New frmRangoFechas
            'frm_fechas.Text = "Filtrar fecha para Registro de Asistencia"
            'frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 12)
            'frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>FECHAS PARA ASISTENCIAS</b></font>
            'frm_fechas.frmRangoFechas_fecha_ini = RangoFInicial
            'frm_fechas.frmRangoFechas_fecha_fin = RangoFFinal
            'frm_fechas.ShowDialog()

            'Dim fecha_ini As Date = frm_fechas.frmRangoFechas_fecha_ini
            'Dim fecha_fin As Date = frm_fechas.frmRangoFechas_fecha_fin

            Dim fecha_ini As Date = RangoFInicial
            Dim fecha_fin As Date = RangoFFinal

            If Not dtInformacion.Columns.Contains("Error") And dtInformacion.Rows.Count > 0 Then

                '----Columnas
                'reloj nombres FechaInicial FechaFinal fecha_inic_incap fecha_fin_incap total_dias referencia

                '---Crear columnas
                dtDatos = New DataTable
                If Not dtDatos.Columns.Contains("reloj") Then dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("nombres") Then dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FechaInicial") Then dtDatos.Columns.Add("FechaInicial", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FechaFinal") Then dtDatos.Columns.Add("FechaFinal", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("fecha_inic_incap") Then dtDatos.Columns.Add("fecha_inic_incap", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("fecha_fin_incap") Then dtDatos.Columns.Add("fecha_fin_incap", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("total_dias") Then dtDatos.Columns.Add("total_dias", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("referencia") Then dtDatos.Columns.Add("referencia", Type.GetType("System.String"))

                '----==========Recorrer a cada uno de los empleados enviados en el filtro
                For Each dr As DataRow In dtInformacion.Rows
                    Dim _rj As String = "", query As String = "", dtReferencia As New DataTable, nombres As String = ""
                    Try : _rj = dr("reloj").ToString.Trim : Catch ex As Exception : _rj = "" : End Try
                    Try : nombres = dr("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try

                    query = "select distinct referencia from ausentismo where reloj='" & _rj & "' and TIPO_AUS IN (select TIPO_AUS from tipo_ausentismo where TIPO_NATURALEZA='I') " & _
                        "and fecha between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "'"

                    dtReferencia = sqlExecute(query, "TA")

                    If Not dtReferencia.Columns.Contains("Error") And dtReferencia.Rows.Count > 0 Then

                        For Each drRef As DataRow In dtReferencia.Rows
                            Dim referencia As String = "", dtFecIni As DataTable, dtFecFin As DataTable, fecha_inicio As String = "", fecha_final As String = "", tot_dias As Integer = 0

                            Try : referencia = drRef("referencia").ToString.Trim : Catch ex As Exception : referencia = "" : End Try

                            If dtDatos.Select("reloj='" & _rj & "' and referencia='" & referencia & "'").Count >= 1 Then GoTo SigRec


                            '----Fecha Inicio
                            query = "SELECT TOP 1 * from ausentismo where reloj='" & _rj & "'  and REFERENCIA='" & referencia & "' order by fecha asc "
                            dtFecIni = sqlExecute(query, "TA")
                            If dtFecIni.Rows.Count > 0 Then Try : fecha_inicio = FechaSQL(dtFecIni.Rows(0).Item("FECHA")) : Catch ex As Exception : fecha_inicio = "" : End Try

                            '----Fecha Fin
                            query = "SELECT TOP 1 * from ausentismo where reloj='" & _rj & "'  and REFERENCIA='" & referencia & "' order by fecha desc "
                            dtFecFin = sqlExecute(query, "TA")
                            If dtFecFin.Rows.Count > 0 Then Try : fecha_final = FechaSQL(dtFecFin.Rows(0).Item("FECHA")) : Catch ex As Exception : fecha_final = "" : End Try

                            '----Total de dias de la incap fecha ini a la fecha final + 1
                            tot_dias = DateDiff(DateInterval.Day, Date.Parse(fecha_inicio), Date.Parse(fecha_final)) + 1

                            dtDatos.Rows.Add({_rj, nombres, FechaSQL(fecha_ini), FechaSQL(fecha_fin), fecha_inicio, fecha_final, tot_dias, referencia})

SigRec:
                        Next

                    End If
                Next

            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reporte de incapacidades", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 'Método para generar reporte  en excel de las vacaciones programadas a futuro que se tengan
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ExcelVacsProg(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim sfd As New SaveFileDialog
        Try
            sfd.DefaultExt = ".xlsx"
            sfd.FileName = "Excel detalle de vacaciones programadas.xlsx"

            sfd.OverwritePrompt = True
            If sfd.ShowDialog() = DialogResult.OK Then

                Dim File = New FileInfo(DireccionReportes & "Plantilla_Excel vacaciones programadas.xlsx") ' Aqui es donde toma la plantilla
                Using package As New ExcelPackage(File)

                    Dim hoja_excel As ExcelWorksheet = package.Workbook.Worksheets("Vacaciones_programadas") ' Toma el nombre de la hoja

                    ExcelDetalleVacacacionesProg("Vacaciones_programadas", "", hoja_excel, dtInformacion)
                    package.SaveAs(New System.IO.FileInfo(sfd.FileName)) ' Guarda el archivo
                    MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End Using

            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un problema al procesar la información.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' 'Método para escribir en la plantilla de excel el detalle por empleado de las vacaciones que se programaron durante ciertas fechas
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ExcelDetalleVacacacionesProg(nombre_hoja As String, filtro As String, ByRef hoja_excel As ExcelWorksheet, dtDatos As DataTable)
        Try
            '====Variables fecha inicial y final
            Dim fecha_ini As Date = RangoFInicial
            Dim fecha_fin As Date = RangoFFinal
            Dim f As Date
            Dim dtAuxEmpleados As New DataTable

            '====2024-10-30: Preguntar si desea generar solo los que tienen vacacaciones programadas, en caso de que no, mandar a todos
            Dim _solo_v_prg As Boolean = False
            If MessageBox.Show("¿Desea generar solamente a empleados que tengan vacaciones programadas?", "P.I.D.A", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                _solo_v_prg = True
            End If


            Dim x As Integer = 7
            Dim y As Integer = 1
            Dim z As Integer = 0

            '=====================Encabaezados fijos
            hoja_excel.Cells(x, y).Value = "Reloj"
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 1).Value = "Nombre"
            hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 2).Value = "Alta"
            hoja_excel.Cells(x, y + 2).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 3).Value = "Supervisor"
            hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 4).Value = "Ruta cliente"
            hoja_excel.Cells(x, y + 4).Style.Font.Bold = True

            '======================Encabezados para cada una de las fechas
            f = fecha_ini
            z = 5
            While f <= fecha_fin

                hoja_excel.Cells(x, y + z).Value = f.ToString("dd-MMM-yyyy")
                hoja_excel.Cells(x, y + z).Style.Font.Bold = True

                z += 1
                f = f.AddDays(1)
            End While

            dtAuxEmpleados = sqlExecute("select reloj,contenido from detalle_auxiliares where campo='001' order by reloj asc ", "PERSONAL")

            '=====Recorrer a cada uno de los empleados
            Dim reloj_tmp As String = ""
            For Each row As DataRow In dtDatos.Select("", "reloj")

                '====Para que no repita al mismo empleado y lo vuelva a meter
                If reloj_tmp = row("reloj") Then
                    Continue For
                Else
                    reloj_tmp = row("reloj")
                End If
                '===END que no repita el mismo empleado

                Dim reloj As String = "", nombres As String = "", alta As String = "", supervisor As String = "", ruta_cliente As String = ""

                x += 1

                Try : reloj = row("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                Try : nombres = row("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
                Try : alta = FechaSQL(row("alta")) : Catch ex As Exception : alta = "" : End Try
                Try : supervisor = row("nombre_super_personal").ToString.Trim : Catch ex As Exception : supervisor = "" : End Try


                '---Obtener la ruta_cliente del empleado
                Dim item = (From N In dtAuxEmpleados.Rows Where N("reloj").ToString.Trim = reloj).ToList()
                If (item.Count > 0) Then Try : ruta_cliente = (item.First()("contenido").ToString.Trim) : Catch ex As Exception : ruta_cliente = "" : End Try

                '======Asignar valores a cada celda de los campos fijos
                hoja_excel.Cells(x, y).Value = reloj
                hoja_excel.Cells(x, y + 1).Value = nombres
                hoja_excel.Cells(x, y + 2).Value = alta
                hoja_excel.Cells(x, y + 3).Value = supervisor ' PENDIENTE
                hoja_excel.Cells(x, y + 4).Value = ruta_cliente

                '=======Agregando vacacion para cada fecha segun aplique

                f = fecha_ini
                z = 5
                While f <= fecha_fin
                    Dim Q2 As String = "", colorBackGround As Integer = 0, Q1 As String = ""
                    Dim dtVacProg As DataTable, dtVacAus As DataTable

                    '========Revisar si no hay vacacion ya en ausentismo, Ya que tiene prioridad
                    Q1 = "select * from ausentismo where reloj='" & reloj & "' and fecha='" & FechaSQL(f) & "' and TIPO_AUS='VAC'"
                    dtVacAus = sqlExecute(Q1, "TA")

                    If dtVacAus.Rows.Count > 0 And Not _solo_v_prg Then '==2024-10-30 Si hay vacs tomadas y que no se genere solamente los que tengan vacs progrs
                        colorBackGround = -16726779
                    Else
                        '======Revisar si tiene vacacion programada 
                        Q2 = "select reloj,fecha from vacs_prog where isnull(APLICADO,0)=0 and reloj='" & reloj & "' and fecha='" & FechaSQL(f) & "'"
                        dtVacProg = sqlExecute(Q2, "PERSONAL")

                        If dtVacProg.Rows.Count > 0 Then
                            colorBackGround = -256
                        End If
                    End If

                    If colorBackGround <> 0 Then
                        hoja_excel.Cells(x, y + z).Value = "VAC"
                        hoja_excel.Cells(x, y + z).Style.Font.Bold = True
                        hoja_excel.Cells(x, y + z).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x, y + z).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                        hoja_excel.Cells(x, y + z).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(colorBackGround))  ' amarillo= -256 (vacs prog) ; verde=  -16726779 (vacs normales)
                        hoja_excel.Cells(x, y + z).Style.Font.Color.SetColor(Color.FromArgb(-15784898)) ' Legra negra
                    End If

                    'hoja_excel.SelectedRange("A7:A7").Style.Border.Right.Style = Style.ExcelBorderStyle.Thin
                    'hoja_excel.SelectedRange("A7:A7").Style.Border.Left.Style = Style.ExcelBorderStyle.Thin

                    z += 1
                    f = f.AddDays(1)
                End While

            Next


            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Metodo genera excel detalle de vacaciones", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 'Método para generar reporte  en excel de registro de asistencia diaria en forma vertical
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ExcelAsistVertical(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim sfd As New SaveFileDialog
        Try
            sfd.DefaultExt = ".xlsx"
            sfd.FileName = "Excel registro de asistencia vertical.xlsx"

            sfd.OverwritePrompt = True
            If sfd.ShowDialog() = DialogResult.OK Then

                Dim File = New FileInfo(DireccionReportes & "Plantilla_Excel registro de asistencia vertical.xlsx") ' Aqui es donde toma la plantilla
                Using package As New ExcelPackage(File)

                    Dim hoja_excel As ExcelWorksheet = package.Workbook.Worksheets("Detalle_asistencia") ' Toma el nombre de la hoja

                    ExcelDetalleAsistVertical("Detalle_asistencia", "", hoja_excel, dtInformacion)
                    package.SaveAs(New System.IO.FileInfo(sfd.FileName)) ' Guarda el archivo
                    MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End Using

            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un problema al procesar la información.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' 'Método para escribir en la plantilla de excel el detalle por empleado el detalle de asistencia Diaria en formato vertical
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub ExcelDetalleAsistVertical(nombre_hoja As String, filtro As String, ByRef hoja_excel As ExcelWorksheet, dtDatos As DataTable)
        Try


            '====Variables fecha inicial y final
            Dim fecha_ini As Date = RangoFInicial
            Dim fecha_fin As Date = RangoFFinal
            Dim f As Date
            Dim dtAuxEmpleados As New DataTable, dtBajas As New DataTable, dtTipoAusentismo As New DataTable

            Dim x As Integer = 5, y As Integer = 1

            dtBajas = sqlExecute("select reloj,baja from personal.dbo.personal where ISNULL(baja,'')<>''", "TA")
            dtTipoAusentismo = sqlExecute("SELECT * from tipo_ausentismo", "TA")

            '=====Encabezados Fijos
            hoja_excel.Cells(x, y).Value = "Departamento" ' Ruta del cliente
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 1).Value = "Reloj"
            hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 2).Value = "Nombre"
            hoja_excel.Cells(x, y + 2).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 3).Value = "Fecha"
            hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 5).Value = "Descripción"
            hoja_excel.Cells(x, y + 5).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 6).Value = "Entrada"
            hoja_excel.Cells(x, y + 6).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 7).Value = "Salida"
            hoja_excel.Cells(x, y + 7).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 8).Value = "Horas no laboradas"
            hoja_excel.Cells(x, y + 8).Style.Font.Bold = True

            '===Obtener ruta del cliente, que sería el departamento
            dtAuxEmpleados = sqlExecute("select reloj,contenido from detalle_auxiliares where campo='001' order by reloj asc ", "PERSONAL")


            x = 6
            y = 1
            '====Recorrer a cada uno de los empleados
            Dim reloj_tmp As String = "" ' Para no repetir el mismo empleado
            For Each dr As DataRow In dtDatos.Select("", "reloj")
                'For Each dr As DataRow In dtDatos.Select("RELOJ='00168'", "reloj") ' Prueba

                Dim reloj As String = "", depto As String = "", nombres As String = "", colorBackGround As Integer = 0

                Try : reloj = dr("RELOJ").ToString.Trim : Catch ex As Exception : reloj = "" : End Try

                '====Para que no repita al mismo empleado y lo vuelva a meter
                If reloj_tmp = reloj Then
                    Continue For
                Else
                    reloj_tmp = reloj
                End If
                '===END que no repita el mismo empleado


                '=====Obtener valores fijos, como depto, nombre
                Try : nombres = dr("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try

                '===Obtener la ruta_cliente del empleado, que en este caso sería el departamento
                Dim item = (From N In dtAuxEmpleados.Rows Where N("reloj").ToString.Trim = reloj).ToList()
                If (item.Count > 0) Then Try : depto = (item.First()("contenido").ToString.Trim) : Catch ex As Exception : depto = "" : End Try


                '=====Obtener detalle de asistencia diaria del empleado
                f = fecha_ini

                While f <= fecha_fin
                    Dim entro As String = "", salio As String = "", comentario As String = "", tipo_aus As String = "", dif_sal As String = ""
                    Dim dtAsist As New DataTable
                    Dim descripcionAus As String = "", colorLetra As Integer = 0, color_back As Integer = 0
                    Dim rgb1 As Integer = 0, rgb2 As Integer = 0, rgb3 As Integer = 0, rgbF1 As Integer = 0, rgbf2 As Integer = 0, rgbf3 As Integer = 0

                    '====Asignar valores fijos, como reloj, nombre, depto
                    hoja_excel.Cells(x, y).Value = depto
                    hoja_excel.Cells(x, y + 1).Value = reloj
                    hoja_excel.Cells(x, y + 2).Value = nombres
                    hoja_excel.Cells(x, y + 3).Value = FechaSQL(f)

                    '=====Validar si es baja, prioritizar, y ya no evaluar todo lo demas
                    If dtBajas.Select("reloj='" & reloj & "' and baja<='" & FechaSQL(f) & "'").Count > 0 Then
                        tipo_aus = "B"
                        descripcionAus = "BAJA"
                        rgb1 = 82 ' backcolor gris
                        rgb2 = 82
                        rgb3 = 82
                        rgbF1 = 255 ' letra blanca
                        rgbf2 = 255
                        rgbf3 = 255
                        hoja_excel.Cells(x, y + 5).Value = descripcionAus

                        GoTo sigRec
                    End If

                    '=====Si no es baja, verificar si tiene entrada y salida
                    dtAsist = dtDatos.Clone
                    Try
                        dtAsist = dtDatos.Select("reloj='" & reloj & "' and fecha_entro='" & FechaSQL(f) & "'").CopyToDataTable
                    Catch ex As Exception
                        dtAsist.Rows.Clear()
                    End Try


                    If dtAsist.Rows.Count > 0 Then
                        Try : entro = dtAsist.Rows(0).Item("entro").ToString.Trim : Catch ex As Exception : entro = "" : End Try
                        Try : salio = dtAsist.Rows(0).Item("salio").ToString.Trim : Catch ex As Exception : salio = "" : End Try
                        Try : comentario = dtAsist.Rows(0).Item("comentario").ToString.Trim : Catch ex As Exception : comentario = "" : End Try
                        Try : tipo_aus = dtAsist.Rows(0).Item("tipo_aus").ToString.Trim : Catch ex As Exception : tipo_aus = "" : End Try
                        Try : dif_sal = dtAsist.Rows(0).Item("dif_sal").ToString.Trim : Catch ex As Exception : dif_sal = "" : End Try

                        If ((entro <> "" Or salio <> "")) And tipo_aus = "" Then '===     si tiene entrada o salida, pero NO tiene aus, poner checadas normales
                            hoja_excel.Cells(x, y + 6).Value = entro
                            hoja_excel.Cells(x, y + 7).Value = salio
                            If (dif_sal <> "" And dif_sal.Contains("-")) Then hoja_excel.Cells(x, y + 8).Value = dif_sal Else hoja_excel.Cells(x, y + 8).Value = "0.00"
                            If comentario.Contains("RETARDO") Then
                                tipo_aus = "RET"
                                descripcionAus = "RETARDO"
                                ' Backcolor Rojo y letra blanca
                                rgb1 = 255 : rgb2 = 0 : rgb3 = 0 : rgbF1 = 255 : rgbf2 = 255 : rgbf3 = 255
                            End If
                            hoja_excel.Cells(x, y + 5).Value = descripcionAus
                            GoTo sigRec

                        ElseIf tipo_aus <> "" Then '  si tiene algun ausentismo

                            If (entro = "" And salio = "") Then ' Si no tiene entrada ni salida, es un ausentismo puro
                                If dtTipoAusentismo.Select("TIPO_AUS='" & tipo_aus & "'").Count > 0 Then
                                    Dim item2 = (From k In dtTipoAusentismo.Rows Where k("tipo_aus").ToString.Trim = tipo_aus).ToList()
                                    If (item2.Count > 0) Then
                                        Try : descripcionAus = (item2.First()("NOMBRE").ToString.Trim) : Catch ex As Exception : descripcionAus = "" : End Try
                                        Try : colorLetra = Integer.Parse((item2.First()("COLOR_LETRA").ToString.Trim)) : Catch ex As Exception : colorLetra = 0 : End Try
                                        Try : color_back = Integer.Parse((item2.First()("COLOR_BACK").ToString.Trim)) : Catch ex As Exception : color_back = 0 : End Try
                                    End If
                                End If
                                hoja_excel.Cells(x, y + 5).Value = descripcionAus
                                GoTo sigRec
                            End If

                            If ((entro <> "" Or salio <> "") And tipo_aus = "FES") Then ' si es festivo y tiene checadas, es festivo trabajado
                                tipo_aus = "FES"
                                descripcionAus = "FEST TRAB"
                                Dim item2 = (From k In dtTipoAusentismo.Rows Where k("tipo_aus").ToString.Trim = tipo_aus).ToList()
                                If (item2.Count > 0) Then
                                    Try : colorLetra = Integer.Parse((item2.First()("COLOR_LETRA").ToString.Trim)) : Catch ex As Exception : colorLetra = 0 : End Try
                                    Try : color_back = Integer.Parse((item2.First()("COLOR_BACK").ToString.Trim)) : Catch ex As Exception : color_back = 0 : End Try
                                End If

                                hoja_excel.Cells(x, y + 5).Value = descripcionAus
                                hoja_excel.Cells(x, y + 6).Value = entro
                                hoja_excel.Cells(x, y + 7).Value = salio
                                If (dif_sal <> "" And dif_sal.Contains("-")) Then hoja_excel.Cells(x, y + 8).Value = dif_sal Else hoja_excel.Cells(x, y + 8).Value = "0.00"

                                GoTo sigRec
                            End If



                        End If


                    Else ' ==Si no tiene registros de asistencia, Ver si tiene algun ausentismo en ese dia
                        Dim dtAus As DataTable = sqlExecute("SELECT * from ausentismo where reloj='" & reloj & "' AND FECHA='" & FechaSQL(f) & "' AND isnull(TIPO_AUS,'')<>''", "TA")

                        If Not dtAus.Columns.Contains("Error") And dtAus.Rows.Count > 0 Then
                            Try : tipo_aus = dtAus.Rows(0).Item("TIPO_AUS").ToString.Trim : Catch ex As Exception : tipo_aus = "" : End Try
                            Dim item2 = (From k In dtTipoAusentismo.Rows Where k("tipo_aus").ToString.Trim = tipo_aus).ToList()
                            If (item2.Count > 0) Then
                                Try : descripcionAus = (item2.First()("NOMBRE").ToString.Trim) : Catch ex As Exception : descripcionAus = "" : End Try
                                Try : colorLetra = Integer.Parse((item2.First()("COLOR_LETRA").ToString.Trim)) : Catch ex As Exception : colorLetra = 0 : End Try
                                Try : color_back = Integer.Parse((item2.First()("COLOR_BACK").ToString.Trim)) : Catch ex As Exception : color_back = 0 : End Try
                            End If

                            hoja_excel.Cells(x, y + 5).Value = descripcionAus
                            GoTo sigRec

                        Else '=== Revisar si es descanso
                      If DiaDescanso(f, reloj) Then
                                tipo_aus = "DESC"
                                descripcionAus = "DESCANSO"
                                ' backColor Blanco y Letra negra
                                rgb1 = 255 : rgb2 = 255 : rgb3 = 255 : rgbF1 = 0 : rgbf2 = 0 : rgbf3 = 0
                                hoja_excel.Cells(x, y + 5).Value = descripcionAus
                                GoTo sigRec
                            End If

                        End If

                    End If

sigRec:
                    '===Formato de como visualizar la baja en la celda
                    If tipo_aus <> "" Then
                        hoja_excel.Cells(x, y + 4).Value = tipo_aus
                        hoja_excel.Cells(x, y + 4).AddComment(descripcionAus, "Detalle")
                        hoja_excel.Cells(x, y + 4).Style.Font.Size = 10
                        hoja_excel.Cells(x, y + 4).Style.Font.Bold = True
                        hoja_excel.Cells(x, y + 4).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x, y + 4).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                        If color_back <> 0 Then
                            hoja_excel.Cells(x, y + 4).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(color_back))
                            hoja_excel.Cells(x, y + 4).Style.Font.Color.SetColor(Color.FromArgb(colorLetra))
                        Else
                            hoja_excel.Cells(x, y + 4).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(rgb1, rgb2, rgb3))
                            hoja_excel.Cells(x, y + 4).Style.Font.Color.SetColor(Color.FromArgb(rgbF1, rgbf2, rgbf3))
                        End If

                    End If

                    f = f.AddDays(1)
                    x += 1
                End While

            Next

            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Metodo genera excel detalle de vacaciones", ex.HResult, ex.Message)
        End Try
    End Sub


    Public Sub AvanceAutoriazion(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            '            /*Obtener los distintos super que van a participar*/
            'select distinct cod_super from PERSONAL.dbo.personalvw where reloj in(select reloj from nomsem where ano+periodo='202440')

            ' /*Obtener universo de empleados en personal y nomsem*/
            'select p.reloj,p.nombres,p.COD_PLANTA,p.nombre_planta,p.COD_SUPER,p.nombre_super,n.ano,n.PERIODO,isnull(n.TRAN_CERRADA,0) as 'TRAN_CERRADA'
            'from personal.dbo.personalvw p left outer join ta.dbo.nomsem n on p.reloj=n.reloj  where n.ano+n.PERIODO='202442'
            'order by n.reloj asc



            '/*  ==Obtener ruta del cliente
            '   dtAuxEmpleados = sqlExecute("select reloj,contenido from personal.dbo.detalle_auxiliares where campo='001' order by reloj asc ", "PERSONAL")

            '   ===Ya en cada empleado:
            '                    '---Obtener la ruta_cliente del empleado
            '                Dim item = (From z In dtAuxEmpleados.Rows Where z("reloj").ToString.Trim = reloj).ToList()
            '                If (item.Count > 0) Then Try : ruta_cliente = (item.First()("contenido").ToString.Trim) : Catch ex As Exception : ruta_cliente = "" : End Try
            '*/

            '=====Variables generales
            Dim Query As String = "", ano As String = "", periodo As String = "", dtSuper As New DataTable, dtAllPersonal As New DataTable


            '===cREAR DATATABLE 
            dtDatos = New DataTable
            If Not dtDatos.Columns.Contains("cod_planta") Then dtDatos.Columns.Add("cod_planta", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("cod_super") Then dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("nombre_super") Then dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("empleados") Then dtDatos.Columns.Add("empleados", Type.GetType("System.Int32"))
            If Not dtDatos.Columns.Contains("confirmados") Then dtDatos.Columns.Add("confirmados", Type.GetType("System.Int32"))
            If Not dtDatos.Columns.Contains("avance") Then dtDatos.Columns.Add("avance", Type.GetType("System.Double"))
            If Not dtDatos.Columns.Contains("ano") Then dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("periodo") Then dtDatos.Columns.Add("periodo", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("ruta_cliente") Then dtDatos.Columns.Add("ruta_cliente", Type.GetType("System.String"))

            '===Llave primaria
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("ruta_cliente"), dtDatos.Columns("cod_super")}


            '=== Obtener anio y periodo
            Dim dtAnoPer As DataTable = sqlExecute("select TOP 1 * from ta.dbo.periodos where FECHA_INI='" & FechaSQL(RangoFInicial) & "' and FECHA_FIN='" & FechaSQL(RangoFFinal) & "'")
            If ((dtAnoPer.Columns.Contains("Error")) Or (Not dtAnoPer.Columns.Contains("Error") And dtAnoPer.Rows.Count = 0)) Then Exit Sub

            Try : ano = dtAnoPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : ano = "" : End Try
            Try : periodo = dtAnoPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try


            '===
            Query = "select distinct cod_super from PERSONAL.dbo.personalvw where reloj in(select reloj from ta.dbo.nomsem where ano+periodo='" & ano & periodo & "')"
            dtSuper = sqlExecute(Query, "TA")

            Query = "select p.reloj,p.nombres,p.COD_PLANTA,p.nombre_planta,p.COD_SUPER,p.nombre_super,n.ano,n.PERIODO,isnull(n.TRAN_CERRADA,0) as 'TRAN_CERRADA' " & _
            "from personal.dbo.personalvw p left outer join ta.dbo.nomsem n on p.reloj=n.reloj  where n.ano+n.PERIODO='" & ano & periodo & "' " & _
            "order by n.reloj asc"
            dtAllPersonal = sqlExecute(Query, "PERSONAL")


            If Not dtAllPersonal.Columns.Contains("Error") And dtAllPersonal.Rows.Count > 0 Then
                '====HERE 2024-10-29
            End If



            dtDatos = New DataTable
            dtDatos.Columns.Add("ano", GetType(System.String))
            dtDatos.Columns.Add("periodo", GetType(System.String))
            dtDatos.Columns.Add("fecha_ini", GetType(System.String))
            dtDatos.Columns.Add("fecha_fin", GetType(System.String))
            dtDatos.Columns.Add("cod_planta", GetType(System.String))
            dtDatos.Columns.Add("cod_clerk", GetType(System.String))
            dtDatos.Columns.Add("nombre_clerk", GetType(System.String))
            dtDatos.Columns.Add("cod_super", GetType(System.String))
            dtDatos.Columns.Add("nombre_super", GetType(System.String))
            dtDatos.Columns.Add("empleados", GetType(System.Int32))
            dtDatos.Columns.Add("confirmados", GetType(System.Int32))
            dtDatos.Columns.Add("avance", GetType(System.Double))
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("cod_planta"), dtDatos.Columns("cod_super")}

            dtAnoPer = sqlExecute("select TOP 1 * from ta.dbo.periodos where FECHA_INI='" & FechaSQL(RangoFInicial) & "' and FECHA_FIN='" & FechaSQL(RangoFFinal) & "'")
            If ((dtAnoPer.Columns.Contains("Error")) Or (Not dtAnoPer.Columns.Contains("Error") And dtAnoPer.Rows.Count = 0)) Then Exit Sub

            frmTrabajando.Show()
            Application.DoEvents()

            Dim Anio As String = IIf(IsDBNull(dtAnoPer.Rows(0).Item("ANO")), "", dtAnoPer.Rows(0).Item("ANO").ToString.Trim)
            Dim Per As String = IIf(IsDBNull(dtAnoPer.Rows(0).Item("PERIODO")), "", dtAnoPer.Rows(0).Item("PERIODO").ToString.Trim)

            Dim QP As String = "select reloj, nombres, cod_planta, cod_turno, cod_depto, cod_clase,isnull(cod_clerk, '') as cod_clerk, isnull(nombre_clerk, '') as nombre_clerk, isnull(cod_super, '') as cod_super, isnull(nombre_super, 'Sin Supervisor') as nombre_super from personalvw where cod_tipo = 'O' and alta <= '" & FechaSQL(RangoFFinal) & "' and (baja is null or baja >= '" & FechaSQL(RangoFInicial) & "') and cod_comp in ('002') and isnull(cod_super, '') <> '' and  cod_planta = '001' order by cod_clerk,reloj"
            Dim dtPersonalTodo As DataTable = sqlExecute(QP, "PERSONAL")

            For Each row As DataRow In dtPersonalTodo.Rows
                Application.DoEvents()

                Dim drow As DataRow = dtDatos.Rows.Find({row("cod_planta"), row("cod_super")})
                If drow Is Nothing Then
                    drow = dtDatos.NewRow
                    drow("ano") = Anio
                    drow("periodo") = Per
                    drow("fecha_ini") = RangoFInicial
                    drow("fecha_fin") = RangoFFinal

                    drow("cod_planta") = row("cod_planta")
                    drow("cod_clerk") = row("cod_clerk")
                    drow("nombre_clerk") = row("nombre_clerk")
                    drow("cod_super") = row("cod_super")
                    drow("empleados") = 1
                    drow("confirmados") = 0

                    dtDatos.Rows.Add(drow)
                Else
                    Dim empleados As Integer = drow("empleados")
                    drow("empleados") += 1
                End If

                Dim AnoPer As String = Anio & Per
                Dim dtConfirmado As DataTable = sqlExecute("select * from nomsem where ano + periodo = '" & AnoPer & "' and reloj = '" & row("reloj") & "' and fecha_firma is not null", "ta")
                If dtConfirmado.Rows.Count > 0 Then
                    Dim confirmados As Integer = drow("confirmados")
                    drow("confirmados") += 1
                End If

            Next

            Dim dSuper As DataTable = sqlExecute("select distinct cod_super, nombre, cod_clerk from super where cod_comp in ('002') order by cod_clerk")
            For Each row As DataRow In dtDatos.Rows
                Application.DoEvents()

                Try

                    row("nombre_super") = dSuper.Select("cod_super = '" & row("cod_super") & "'")(0)("nombre")
                Catch ex As Exception

                End Try

                row("avance") = (row("confirmados") / row("empleados")) * 100
            Next

            ActivoTrabajando = False
            frmTrabajando.Close()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "REP_Avance_Autorizacion", ex.HResult, ex.Message)
            ActivoTrabajando = False
            frmTrabajando.Close()
        End Try
    End Sub

    ''' <summary>
    ''' 'Método para generar reporte de ausentismo diario
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub AusentismoDiario(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Try

            '===Fechas mandadas segun el filtro del reporteador de TA
            Dim fecha_ini As Date = RangoFInicial
            Dim fecha_fin As Date = RangoFFinal

            '===Variables generales
            Dim ENCABEZADO_EMPRESA As String = "", DIR_EMPRESA As String = "", query As String = "", dtFalInjus As New DataTable, dtFalJus As New DataTable, cod_comp As String = "", dtSuper As New DataTable

            Dim AUS_INJUS_DIA As Integer = 0, HC_DIA As Integer = 0, AUS_JUS_DIA As Integer = 0

            '===Creacion de columnas
            Dim dKey As DataRow
            dtDatos = New DataTable

            If Not dtDatos.Columns.Contains("FECHA_DIA") Then dtDatos.Columns.Add("FECHA_DIA", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("COD_TIPO") Then dtDatos.Columns.Add("COD_TIPO", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("SUPERV") Then dtDatos.Columns.Add("SUPERV", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("RUTA_CLIENTE") Then dtDatos.Columns.Add("RUTA_CLIENTE", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("HC") Then dtDatos.Columns.Add("HC", Type.GetType("System.Int32"))
            If Not dtDatos.Columns.Contains("AUS_INJUS") Then dtDatos.Columns.Add("AUS_INJUS", Type.GetType("System.Int32"))
            If Not dtDatos.Columns.Contains("AUS_JUS") Then dtDatos.Columns.Add("AUS_JUS", Type.GetType("System.Int32"))
            If Not dtDatos.Columns.Contains("BAJAS") Then dtDatos.Columns.Add("BAJAS", Type.GetType("System.Int32"))
            If Not dtDatos.Columns.Contains("ALTAS") Then dtDatos.Columns.Add("ALTAS", Type.GetType("System.Int32"))
            If Not dtDatos.Columns.Contains("OBSERVACIONES") Then dtDatos.Columns.Add("OBSERVACIONES", Type.GetType("System.String"))
            '===Columnas del Encabezado
            If Not dtDatos.Columns.Contains("ENCABEZADO_EMPRESA") Then dtDatos.Columns.Add("ENCABEZADO_EMPRESA", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("DIR_EMPRESA") Then dtDatos.Columns.Add("DIR_EMPRESA", Type.GetType("System.String"))

            '==Variable para indicar si se genero para 1 solo dia o mas días
            If Not dtDatos.Columns.Contains("UN_DIA") Then dtDatos.Columns.Add("UN_DIA", Type.GetType("System.String"))

            '====Totales X DIA  
            If Not dtDatos.Columns.Contains("AUS_INJUS_DIA") Then dtDatos.Columns.Add("AUS_INJUS_DIA", Type.GetType("System.Int32"))
            If Not dtDatos.Columns.Contains("HC_DIA") Then dtDatos.Columns.Add("HC_DIA", Type.GetType("System.Int32"))
            If Not dtDatos.Columns.Contains("AUS_JUS_DIA") Then dtDatos.Columns.Add("AUS_JUS_DIA", Type.GetType("System.Int32"))

            '===Llave primaria
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("FECHA_DIA"), dtDatos.Columns("COD_TIPO"), dtDatos.Columns("SUPERV"), dtDatos.Columns("RUTA_CLIENTE")} ' Llave primaria



            '----Obtener Encabezado y direccion de la empresa
            Dim dtCia As DataTable = sqlExecute("select * from PERSONAL.dbo.cias where CIA_DEFAULT=1", "PERSONAL")
            If Not dtCia.Columns.Contains("Error") And dtCia.Rows.Count > 0 Then
                Dim rep_legal As String = "", rfc As String = "", direccion As String = "", colonia As String = "", cod_postal As String = "", telefono1 As String = "", ciudad As String = "", estado As String = ""

                Try : cod_comp = dtCia.Rows(0).Item("cod_comp").ToString.Trim.ToUpper : Catch ex As Exception : cod_comp = "" : End Try
                Try : rep_legal = dtCia.Rows(0).Item("rep_legal").ToString.Trim.ToUpper : Catch ex As Exception : rep_legal = "" : End Try
                Try : rfc = dtCia.Rows(0).Item("rfc").ToString.Trim.ToUpper : Catch ex As Exception : rfc = "" : End Try
                Try : direccion = dtCia.Rows(0).Item("direccion").ToString.Trim.ToUpper : Catch ex As Exception : direccion = "" : End Try
                Try : colonia = dtCia.Rows(0).Item("colonia").ToString.Trim.ToUpper : Catch ex As Exception : colonia = "" : End Try
                Try : cod_postal = dtCia.Rows(0).Item("cod_postal").ToString.Trim.ToUpper : Catch ex As Exception : cod_postal = "" : End Try
                Try : telefono1 = dtCia.Rows(0).Item("telefono1").ToString.Trim.ToUpper : Catch ex As Exception : telefono1 = "" : End Try
                Try : ciudad = dtCia.Rows(0).Item("ciudad").ToString.Trim.ToUpper : Catch ex As Exception : ciudad = "" : End Try
                Try : estado = dtCia.Rows(0).Item("estado").ToString.Trim.ToUpper : Catch ex As Exception : estado = "" : End Try

                ENCABEZADO_EMPRESA = rep_legal & "  RFC:" & rfc
                DIR_EMPRESA = "CALLE " & direccion & " " & colonia & " C.P." & cod_postal & ", TEL:" & telefono1 & " " & ciudad & ", " & estado

            End If


            '  Faltas injustificadas
            query = "select * from asist where TIPO_AUS='FI' and FHA_ENT_HOR between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "'"
            dtFalInjus = sqlExecute(query, "TA")

            '  Faltas Justif
            query = "select * from asist where (ISNULL(TIPO_AUS,'')<>'' AND TIPO_AUS<>'FI') and FHA_ENT_HOR between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "'"
            dtFalJus = sqlExecute(query, "TA")

            ' === Supervisores
            query = "select s.cod_comp,s.COD_SUPER,p.nombres,s.NOMBRE,s.reloj from super s left outer join personalvw p on s.RELOJ=p.RELOJ " & _
                "where s.cod_comp='" & cod_comp & "'and s.COD_SUPER<>'000' order by COD_SUPER"
            dtSuper = sqlExecute(query, "PERSONAL")

            '===Validar si el reporte se genera para 1 solo día o varios
            Dim un_dia As String = "0"
            Dim difDias As Integer = DateDiff(DateInterval.Day, fecha_ini, fecha_fin) + 1
            If difDias = 1 Then un_dia = "1"

            If Not dtSuper.Columns.Contains("Error") And dtSuper.Rows.Count > 0 Then
                Dim f As Date = fecha_ini
                While f <= fecha_fin ' Recorrer cada día

                    '==Recorrer cada supervisor
                    For Each drS As DataRow In dtSuper.Rows
                        Dim cod_super As String = "", nombre_super As String = "", reloj_super As String = "", dtPersonal As New DataTable

                        Try : cod_super = drS("cod_super").ToString.Trim : Catch ex As Exception : cod_super = "" : End Try
                        Try : nombre_super = drS("nombres").ToString.Trim : Catch ex As Exception : nombre_super = "INDEFINIDO" : End Try
                        Try : reloj_super = drS("reloj").ToString.Trim : Catch ex As Exception : reloj_super = "" : End Try

                        If nombre_super = "" Then nombre_super = "INDEFINIDO"

                        query = "select p.*,d.CONTENIDO as 'ruta_cliente' from personalvw p left outer join detalle_auxiliares d on p.reloj=d.RELOJ " & _
                            "where d.CAMPO='001' and p.cod_super in('" & cod_super & "') and (isnull(p.baja,'')='' or p.baja>='" & FechaSQL(f) & "')"

                        dtPersonal = sqlExecute(query, "PERSONAL")
                        If Not dtPersonal.Columns.Contains("Error") And dtPersonal.Rows.Count > 0 Then

                            '==Recorrer cada empleado
                            For Each drP As DataRow In dtPersonal.Rows
                                Dim rj As String = "", cod_tipo As String = "", ruta_cliente As String = "", observaciones As String = "", nombre_empleado As String = "", tipo_aus As String = ""
                                Dim alta As String = "", baja As String = "", fecha_dia As String = "", hc As Integer = 1, aus_injus As Integer = 0, aus_jus As Integer = 0, bajas As Integer = 0, altas As Integer = 0

                                fecha_dia = FechaSQL(f)
                                Try : rj = drP("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                                Try : cod_tipo = drP("cod_tipo").ToString.Trim : Catch ex As Exception : cod_tipo = "" : End Try
                                Try : ruta_cliente = drP("ruta_cliente").ToString.Trim : Catch ex As Exception : ruta_cliente = "" : End Try
                                Try : alta = FechaSQL(drP("alta").ToString.Trim) : Catch ex As Exception : alta = "" : End Try
                                Try : baja = FechaSQL(drP("baja").ToString.Trim) : Catch ex As Exception : baja = "" : End Try
                                Try : nombre_empleado = drP("nombres").ToString.Trim : Catch ex As Exception : nombre_empleado = "" : End Try

                                '== si la alta o baja es el mismo dia, contarlo como tal, y no contar como HC
                                If alta = fecha_dia Then
                                    hc = 0
                                    altas = 1
                                End If

                                If baja = fecha_dia Then
                                    hc = 0
                                    bajas = 1
                                End If


                                If dtFalInjus.Select("reloj='" & rj & "' and FHA_ENT_HOR='" & fecha_dia & "'").Count > 0 Then
                                    aus_injus = 1
                                    tipo_aus = "FIN"
                                End If

                                If dtFalJus.Select("reloj='" & rj & "' and FHA_ENT_HOR='" & fecha_dia & "'").Count > 0 Then
                                    aus_jus = 1
                                    Dim myRow() As DataRow = Nothing
                                    myRow = dtFalJus.Select("reloj='" & rj & "' and FHA_ENT_HOR='" & fecha_dia & "'")
                                    tipo_aus = myRow(0)("tipo_aus").ToString.Trim
                                End If


                                '===Llenar campo de observaciones: codigo de ausentismo + Nombre, ejemplo: IXM: NombreEmpleado
                                If tipo_aus <> "" Then observaciones = tipo_aus & ": " & nombre_empleado

                                '====Validar si el registro ya existe de acuerdo a la llave grupal
                                dKey = dtDatos.Rows.Find({fecha_dia, cod_tipo, nombre_super, ruta_cliente})

                                If dKey Is Nothing Then
                                    '==Si no está, agregar
                                    'dKey = dtDatos.NewRow
                                    dtDatos.Rows.Add({fecha_dia, cod_tipo, nombre_super, ruta_cliente, hc, aus_injus, aus_jus, bajas, altas, observaciones, ENCABEZADO_EMPRESA, DIR_EMPRESA, un_dia,
                                                      AUS_INJUS_DIA, HC_DIA, AUS_JUS_DIA})
                                Else
                                    '==Solo actualizar conteos: hc, aus_injus, aus_jus, bajas, altas y observaciones
                                    dKey("HC") += hc
                                    dKey("AUS_INJUS") += aus_injus
                                    dKey("AUS_JUS") += aus_jus
                                    dKey("BAJAS") += bajas
                                    dKey("ALTAS") += altas
                                    Dim _obser As String = dKey("OBSERVACIONES").ToString.Trim
                                    If observaciones <> "" Then
                                        If _obser <> "" Then ' Si ya hay observaciones, hacer salto de línea
                                            dKey("OBSERVACIONES") += vbCrLf & observaciones
                                        Else
                                            dKey("OBSERVACIONES") += observaciones
                                        End If

                                    End If


                                End If


                            Next ' END Recorrer cada empleado

                        End If
                    Next ' END Recorrer cada super

                    f = f.AddDays(1)
                End While

            End If

            '====Obtener totales x dia y actualizar el dtDatos
            Dim f_dia As Date = fecha_ini
            While f_dia <= fecha_fin ' Recorrer cada día

                '===Aus Injus
                Dim totalAusInjusXDia = (From i In dtDatos.Select("FECHA_DIA = '" & FechaSQL(f_dia) & "'") Select Decimal.Parse(i("AUS_INJUS"))).ToList().Sum()
                For Each drF As DataRow In dtDatos.Select("FECHA_DIA = '" & FechaSQL(f_dia) & "'")
                    drF("AUS_INJUS_DIA") = totalAusInjusXDia
                Next

                '===Aus Jus
                Dim totalAusJusXDia = (From i In dtDatos.Select("FECHA_DIA='" & FechaSQL(f_dia) & "'") Select Decimal.Parse(i("AUS_JUS"))).ToList().Sum()
                For Each drF As DataRow In dtDatos.Select("FECHA_DIA='" & FechaSQL(f_dia) & "'")
                    drF("AUS_JUS_DIA") = totalAusJusXDia
                Next

                '===HC
                Dim totalHCXDia = (From i In dtDatos.Select("FECHA_DIA = '" & FechaSQL(f_dia) & "'") Select Decimal.Parse(i("HC"))).ToList().Sum()
                For Each drF As DataRow In dtDatos.Select("FECHA_DIA = '" & FechaSQL(f_dia) & "'")
                    drF("HC_DIA") = totalHCXDia
                Next

                f_dia = f_dia.AddDays(1)
            End While



        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reporte Ausentismo Diario", ex.HResult, ex.Message)
        End Try

    End Sub



End Module

