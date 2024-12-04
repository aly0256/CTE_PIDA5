Imports OfficeOpenXml
Imports System.Globalization
Imports System.IO
Module PostFunciones
    Public dtDatosPostFunciones As DataTable
    Public dtDatosPost As DataTable

    Public Sub acciones(NombreReporte As String)
        Select Case NombreReporte.Trim
            Case "BRP_Listado de cambios por antiguedad"
                AplicarCambiosAntiguedad(dtDatosPostFunciones)
            Case "BRP_Listado de cambios por antiguedad"
                AplicarCambiosAntiguedad(dtDatosPostFunciones)
            Case "Tiempo extra (Doble y Triple)"
                ExcelTiempoExtraDobleyTriple(dtDatosPostFunciones)
            Case "Reporte de cursos tomados"
                ExcelCursosTomados(dtDatosPostFunciones)  'dtDatos, dtInformacion
            Case "Relación de cursos impartidos"
                ExcelCursosImpartidos(dtDatosPostFunciones)
        End Select
    End Sub
    Public Sub ExcelCursosTomados(dtDatosPostFunciones As DataTable) 'dtDatosPostFunciones,
        If MessageBox.Show("¿Quieres Generar Archivo Excel Plano?", "Generar Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


            Dim sfd As New SaveFileDialog
            Try
                sfd.DefaultExt = ".xlsx"
                sfd.FileName = "Excel Informacion Cursos Tomados.xlsx"

                sfd.OverwritePrompt = True
                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim archivo As ExcelPackage = New ExcelPackage()
                    Dim wb As ExcelWorkbook = archivo.Workbook

                    '

                    frmTrabajando.Show()

                    ExcelCursosTomadosPlano("Cursos Tomados", "", wb, dtDatosPostFunciones) ' mandar llamar la info dtinformacion
                    archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))

                    ActivoTrabajando = False
                    frmTrabajando.Close()

                End If

            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try
        End If
    End Sub

    ' Nuevos reportes Planos
    Public Sub ExcelCursosTomadosPlano(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, dtDatosPostFunciones As DataTable)

        Dim x As Integer = 1
        Dim y As Integer = 1
        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

        'Nombre
        hoja_excel.Cells(x, y).Value = "RELOJ"               'supervisor
        hoja_excel.Cells(x, y).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 1).Value = "NOMBRE"         'departamento
        hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 2).Value = "SUPERVISOR"    'puesto
        hoja_excel.Cells(x, y + 2).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 3).Value = "DEPARTAMENTO"   'turno
        hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 4).Value = "PUESTO"       'planta
        hoja_excel.Cells(x, y + 4).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 5).Value = "TURNO"    'codigo
        hoja_excel.Cells(x, y + 5).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 6).Value = "PLANTA"    'curso
        hoja_excel.Cells(x, y + 6).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 7).Value = "CODIGO"  'instructor
        hoja_excel.Cells(x, y + 7).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 8).Value = "CURSO" 'inicio
        hoja_excel.Cells(x, y + 8).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 9).Value = "INSTRUCTOR" ' fin
        hoja_excel.Cells(x, y + 9).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 10).Value = "INSTITUTO" ' fin
        hoja_excel.Cells(x, y + 10).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 11).Value = "INICIO"   ' duracion
        hoja_excel.Cells(x, y + 11).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 12).Value = "FIN"  'calificacion
        hoja_excel.Cells(x, y + 12).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 13).Value = "DURACION"
        hoja_excel.Cells(x, y + 13).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 14).Value = "CALIFICACION"    ' abajo aun no defino
        hoja_excel.Cells(x, y + 14).Style.Font.Bold = True



        For Each row As DataRow In dtDatosPostFunciones.Select(filtro, "reloj")
            frmTrabajando.lblAvance.Text = row("reloj")
            Application.DoEvents()
            Try
                'Dim STPS As Boolean = IIf(IsDBNull(row("STPS")), False, row("STPS"))
                'If STPS Then

                ' Dim _cc_ As String = row("COD_CURSO")
                ' If _cc_ <> "" Then
                '   If Not IsDBNull(row("COD_CURSO")) Then

                Dim dtDC4 As DataTable = sqlExecute("select nombres, apaterno, amaterno, max_escolaridad, COD_TIPO, COD_PUESTO, SEXO from personalvw " & _
                                                    "where reloj ='" & row("reloj") & "'")
                For Each dcrow As DataRow In dtDC4.Rows
                    Dim red As Integer
                    Dim duracion As Double = 1
                    If (IsDBNull(row("Duracion"))) = False Then   'mejoras

                        Try
                            duracion = Double.Parse(row("DURACION"))
                        Catch ex As Exception

                        End Try

                        red = Math.Ceiling(duracion)
                        If red = 0 Then
                            red = 1
                        End If
                    End If

                    x += 1

                    hoja_excel.Cells(x, y).Value = row("reloj")
                    Try
                        hoja_excel.Cells(x, y + 1).Value = dcrow("Nombres")
                    Catch ex As Exception
                    End Try
                    hoja_excel.Cells(x, y + 2).Value = row("nombre_super")
                    hoja_excel.Cells(x, y + 3).Value = row("nombre_depto")
                    hoja_excel.Cells(x, y + 4).Value = row("nombre_puesto")
                    hoja_excel.Cells(x, y + 5).Value = row("cod_turno")
                    hoja_excel.Cells(x, y + 6).Value = row("nombre_planta")
                    hoja_excel.Cells(x, y + 7).Value = row("cod_curso") ' CODIGO
                    hoja_excel.Cells(x, y + 8).Value = row("nombre_curso")
                    hoja_excel.Cells(x, y + 9).Value = row("nombre_instructor")
                    hoja_excel.Cells(x, y + 10).Value = row("nombre_instituto")

                    Try
                        'invertir hoja_excel.Cells(x, y + 11).Value = Date.Parse(row("inicio")).ToShortDateString
                        hoja_excel.Cells(x, y + 11).Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern
                        hoja_excel.Cells(x, y + 11).Value = Date.Parse(row("inicio"))
                    Catch ex As Exception
                    End Try

                    Try
                        hoja_excel.Cells(x, y + 12).Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern
                        hoja_excel.Cells(x, y + 12).Value = Date.Parse(row("fin"))

                    Catch ex As Exception
                    End Try

                    hoja_excel.Cells(x, y + 13).Value = red
                    hoja_excel.Cells(x, y + 14).Value = row("calificacion")                           'row("DURACION")


                Next
                'End If
                'End If   'stps if
            Catch ex As Exception
            End Try
        Next
        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()


    End Sub

    Public Sub ExcelCursosImpartidos(dtDatosPostFunciones)
        If MessageBox.Show("¿Quieres Generar Archivo Excel Plano?", "Generar Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


            Dim sfd As New SaveFileDialog
            Try
                sfd.DefaultExt = ".xlsx"
                sfd.FileName = "Excel Informacion Cursos Impartidos.xlsx"

                sfd.OverwritePrompt = True
                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim archivo As ExcelPackage = New ExcelPackage()
                    Dim wb As ExcelWorkbook = archivo.Workbook

                    '

                    frmTrabajando.Show()

                    ExcelCursosImpartidosPlano("Cursos Impartidos", "", wb, dtDatosPostFunciones) ' mandar llamar la info dtinformacion
                    archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))

                    ActivoTrabajando = False
                    frmTrabajando.Close()

                End If

            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try
        End If
    End Sub
    Public Sub ExcelCursosImpartidosPlano(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, dtDatosPostFunciones As DataTable)

        Dim x As Integer = 1
        Dim y As Integer = 1
        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

        'Nombre
        hoja_excel.Cells(x, y).Value = "COD CURSO"
        hoja_excel.Cells(x, y).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 1).Value = "NOMBRE CURSO"
        hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 2).Value = "INSTITUTO"
        hoja_excel.Cells(x, y + 2).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 3).Value = "COD INSTRUCTOR"
        hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 4).Value = "INSTRUCTOR"
        hoja_excel.Cells(x, y + 4).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 5).Value = "DURACION"
        hoja_excel.Cells(x, y + 5).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 6).Value = "FECHA INICIO"
        hoja_excel.Cells(x, y + 6).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 7).Value = "FECHA TERMINACION"
        hoja_excel.Cells(x, y + 7).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 8).Value = "RELOJ"  '------------------------------ultima mod
        hoja_excel.Cells(x, y + 8).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 9).Value = "NOMBRE"
        hoja_excel.Cells(x, y + 9).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 10).Value = "CALIFICACION"
        hoja_excel.Cells(x, y + 10).Style.Font.Bold = True




        For Each row As DataRow In dtDatosPostFunciones.Select(filtro, "COD_CURSO")
            frmTrabajando.lblAvance.Text = "Cargando Información Excel" ' IIf(IsDBNull(row("COD_CURSO")), False, "")
            Application.DoEvents()

            Try


                Dim dtDC4 As DataTable = sqlExecute("select nombres, apaterno, amaterno, max_escolaridad, COD_TIPO, COD_PUESTO, SEXO from personalvw " & _
                                                    "where reloj ='" & row("reloj") & "'")
                For Each dcrow As DataRow In dtDC4.Rows   'Select(filtro, "COD_CURSO")
                    Dim red As Integer
                    Dim duracion As Double = 1
                    If (IsDBNull(row("Duracion"))) = False Then   'mejoras

                        Try
                            duracion = Double.Parse(row("DURACION"))
                        Catch ex As Exception

                        End Try

                        red = Math.Ceiling(duracion)
                        If red = 0 Then
                            red = 1
                        End If
                    End If

                    x += 1

                    hoja_excel.Cells(x, y).Value = row("COD_CURSO") 'reloj
                    hoja_excel.Cells(x, y + 1).Value = row("NOMBRE_CURSO")
                    hoja_excel.Cells(x, y + 2).Value = row("NOMBRE_INSTITUTO")
                    hoja_excel.Cells(x, y + 3).Value = row("COD_INSTRUCTOR")
                    hoja_excel.Cells(x, y + 4).Value = row("NOMBRE_INSTRUCTOR")
                    hoja_excel.Cells(x, y + 5).Value = red
                    Try
                        hoja_excel.Cells(x, y + 6).Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern
                        hoja_excel.Cells(x, y + 6).Value = Date.Parse(row("inicio"))
                    Catch ex As Exception
                    End Try
                    Try
                        hoja_excel.Cells(x, y + 7).Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern
                        hoja_excel.Cells(x, y + 7).Value = Date.Parse(row("fin"))
                    Catch ex As Exception
                    End Try
                    hoja_excel.Cells(x, y + 8).Value = row("reloj")
                    hoja_excel.Cells(x, y + 9).Value = row("nombres")
                    hoja_excel.Cells(x, y + 10).Value = row("calificacion") ' CODIGO



                Next

            Catch ex As Exception
            End Try
            'End If   'stps if
        Next
        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()


    End Sub
    Public Sub ExcelTiempoExtraDobleyTriple(dtDatosPostFunciones)
        If MessageBox.Show("¿Quieres Generar Archivo Excel Plano?", "Generar Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


            Dim sfd As New SaveFileDialog
            Try
                sfd.DefaultExt = ".xlsx"
                sfd.FileName = "Tiempo extra doble y triple.xlsx"

                sfd.OverwritePrompt = True
                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim archivo As ExcelPackage = New ExcelPackage()
                    Dim wb As ExcelWorkbook = archivo.Workbook

                    '

                    frmTrabajando.Show()

                    ExcelTiempoExtradobleyTriplePlano("Tiempo extra doble y triple", "", wb, dtDatosPostFunciones) ' mandar llamar la info dtinformacion
                    archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))

                    ActivoTrabajando = False
                    frmTrabajando.Close()

                End If

            Catch ex As Exception

                ActivoTrabajando = False
                frmTrabajando.Close()
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try
        End If
    End Sub

    Public Sub ExcelTiempoExtradobleyTriplePlano(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, dtDatosPostFunciones As DataTable)

        Dim x As Integer = 1
        Dim xTotal As Integer = 1
        Dim yTotal As Integer = 1
        Dim y As Integer = 1
        Dim centroCostos As String = ""
        Dim cod_cc As String = ""
        Dim totalSemanal As Double = 0
        Dim totalSemanalD As Double = 0
        Dim totalSemanalT As Double = 0
        Dim totalLunes As Double = 0
        Dim totalMartes As Double = 0
        Dim totalMiercoles As Double = 0
        Dim totalJueves As Double = 0
        Dim totalViernes As Double = 0
        Dim totalSabado As Double = 0
        Dim totalDomingo As Double = 0
        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)
        Dim hoja_excelTotales As ExcelWorksheet = wb.Worksheets.Add("Totales")

        hoja_excel.Cells(x, y).Value = "RELOJ"
        hoja_excel.Cells(x, y).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 1).Value = "NOMBRE"
        hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 2).Value = "DEPTO"
        hoja_excel.Cells(x, y + 2).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 3).Value = "SUPERVISOR"
        hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 4).Value = "TURNO"
        hoja_excel.Cells(x, y + 4).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 5).Value = "PLANTA"
        hoja_excel.Cells(x, y + 5).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 6).Value = "COD CC"
        hoja_excel.Cells(x, y + 6).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 7).Value = "CENTRO COSTOS"
        hoja_excel.Cells(x, y + 7).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 8).Value = "PERIODO"
        hoja_excel.Cells(x, y + 8).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 9).Value = "CLASE"
        hoja_excel.Cells(x, y + 9).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 10).Value = "LUNES"
        hoja_excel.Cells(x, y + 10).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 12).Value = "MARTES"
        hoja_excel.Cells(x, y + 12).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 14).Value = "MIERCOLES"
        hoja_excel.Cells(x, y + 14).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 16).Value = "JUEVES"
        hoja_excel.Cells(x, y + 16).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 18).Value = "VIERNES"
        hoja_excel.Cells(x, y + 18).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 20).Value = "SABADO"
        hoja_excel.Cells(x, y + 20).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 22).Value = "DOMINGO"
        hoja_excel.Cells(x, y + 22).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 24).Value = "TOTAL"
        hoja_excel.Cells(x, y + 24).Style.Font.Bold = True

        x = x + 1

        For var = 10 To 24
            If (((var + y) Mod 2) = 0) Then
                hoja_excel.Cells(x, y + var).Value = "EXTRAS"
            Else
                hoja_excel.Cells(x, y + var).Value = "NORMALES"
            End If
        Next
        hoja_excel.Cells(x, y + 24).Value = "NORMALES"
        hoja_excel.Cells(x, y + 25).Value = "EXTRAS"
        hoja_excel.Cells(x, y + 26).Value = "DOBLES"
        hoja_excel.Cells(x, y + 27).Value = "TRIPLES"


        For Each row As DataRow In dtDatosPostFunciones.Rows
            frmTrabajando.lblAvance.Text = "Cargando Información Excel"
            Application.DoEvents()
            Try

                x += 1

                If ((Not x = 3) And cod_cc <> row("cod_cc").ToString.TrimEnd) Then

                    If (xTotal = 1) Then
                        For var = 0 To 11
                            hoja_excelTotales.Cells(xTotal, y + var).Style.Font.Bold = True
                        Next



                        hoja_excelTotales.Cells(xTotal, y).Value = "COD CENTRO COSTOS"
                        hoja_excelTotales.Cells(xTotal, y + 1).Value = "CENTRO COSTOS"
                        hoja_excelTotales.Cells(xTotal, y + 2).Value = "LUNES"
                        hoja_excelTotales.Cells(xTotal, y + 3).Value = "MARTES"
                        hoja_excelTotales.Cells(xTotal, y + 4).Value = "MIERCOLES"
                        hoja_excelTotales.Cells(xTotal, y + 5).Value = "JUEVES"
                        hoja_excelTotales.Cells(xTotal, y + 6).Value = "VIERNES"
                        hoja_excelTotales.Cells(xTotal, y + 7).Value = "SABADO"
                        hoja_excelTotales.Cells(xTotal, y + 8).Value = "DOMINGO"
                        hoja_excelTotales.Cells(xTotal, y + 9).Value = "TOTAL"
                        hoja_excelTotales.Cells(xTotal, y + 10).Value = "DOBLE"
                        hoja_excelTotales.Cells(xTotal, y + 11).Value = "TRIPLE"
                        xTotal += 1
                    End If

                    hoja_excelTotales.Cells(xTotal, yTotal).Value = cod_cc

                    hoja_excelTotales.Cells(xTotal, yTotal + 1).Value = centroCostos

                    hoja_excelTotales.Cells(xTotal, yTotal + 2).Value = totalLunes

                    hoja_excelTotales.Cells(xTotal, yTotal + 3).Value = totalMartes

                    hoja_excelTotales.Cells(xTotal, yTotal + 4).Value = totalMiercoles

                    hoja_excelTotales.Cells(xTotal, yTotal + 5).Value = totalJueves

                    hoja_excelTotales.Cells(xTotal, yTotal + 6).Value = totalViernes

                    hoja_excelTotales.Cells(xTotal, yTotal + 7).Value = totalSabado

                    hoja_excelTotales.Cells(xTotal, yTotal + 8).Value = totalDomingo

                    hoja_excelTotales.Cells(xTotal, yTotal + 9).Value = totalSemanal

                    hoja_excelTotales.Cells(xTotal, yTotal + 10).Value = totalSemanalD

                    hoja_excelTotales.Cells(xTotal, yTotal + 11).Value = totalSemanalT
                    xTotal += 1





                    totalSemanal = 0
                    totalSemanalD = 0
                    totalSemanalT = 0

                    totalLunes = 0
                    totalMartes = 0
                    totalMiercoles = 0
                    totalJueves = 0
                    totalViernes = 0
                    totalSabado = 0
                    totalDomingo = 0


                End If

                hoja_excel.Cells(x, y).Value = row("reloj")
                hoja_excel.Cells(x, y + 1).Value = row("nombres")
                hoja_excel.Cells(x, y + 2).Value = row("cod_depto")
                hoja_excel.Cells(x, y + 3).Value = row("supervisor")
                hoja_excel.Cells(x, y + 4).Value = row("turno")
                hoja_excel.Cells(x, y + 5).Value = row("planta")
                hoja_excel.Cells(x, y + 6).Value = row("cod_cc")
                hoja_excel.Cells(x, y + 7).Value = row("nombre_cc")
                hoja_excel.Cells(x, y + 8).Value = row("periodo")
                hoja_excel.Cells(x, y + 9).Value = row("clase")

                hoja_excel.Cells(x, y + 10).Value = row("horasNormalesL")
                hoja_excel.Cells(x, y + 11).Value = row("horasExtrasL")
                hoja_excel.Cells(x, y + 12).Value = row("horasNormalesM")
                hoja_excel.Cells(x, y + 13).Value = row("horasExtrasM")
                hoja_excel.Cells(x, y + 14).Value = row("horasNormalesW")
                hoja_excel.Cells(x, y + 15).Value = row("horasExtrasW")
                hoja_excel.Cells(x, y + 16).Value = row("horasNormalesJ")
                hoja_excel.Cells(x, y + 17).Value = row("horasExtrasJ")
                hoja_excel.Cells(x, y + 18).Value = row("horasNormalesV")
                hoja_excel.Cells(x, y + 19).Value = row("horasExtrasV")
                hoja_excel.Cells(x, y + 20).Value = row("horasNormalesS")
                hoja_excel.Cells(x, y + 21).Value = row("horasExtrasS")
                hoja_excel.Cells(x, y + 22).Value = row("horasNormalesD")
                hoja_excel.Cells(x, y + 23).Value = row("horasExtrasD")

                hoja_excel.Cells(x, y + 24).Value = row("horasNormales")
                hoja_excel.Cells(x, y + 25).Value = row("horasExtras")
                totalSemanal = totalSemanal + row("horasExtras")
                hoja_excel.Cells(x, y + 26).Value = row("horasDobles")
                totalSemanalD = totalSemanalD + row("horasDobles")
                hoja_excel.Cells(x, y + 27).Value = row("horasTriples")
                totalSemanalT = totalSemanalT + row("horasTriples")

                If (IsDBNull(row("nombre_cc")) And Not IsDBNull(row("cod_cc"))) Then
                    centroCostos = "sin nombre"
                    cod_cc = row("cod_cc").ToString.TrimEnd
                Else
                    centroCostos = row("nombre_cc").ToString.TrimEnd
                    cod_cc = row("cod_cc").ToString.TrimEnd
                End If

                totalLunes = totalLunes + row("horasExtrasL")
                totalMartes = totalMartes + row("horasExtrasM")
                totalMiercoles = totalMiercoles + row("horasExtrasW")
                totalJueves = totalJueves + row("horasExtrasJ")
                totalViernes = totalViernes + row("horasExtrasV")
                totalSabado = totalSabado + row("horasExtrasS")
                totalDomingo = totalDomingo + row("horasExtrasD")



            Catch ex As Exception

            End Try
        Next
        x = x + 1
        For var = 6 To 24
            hoja_excel.Cells(x, y + var).Style.Font.Bold = True
        Next
        hoja_excelTotales.Cells(xTotal, yTotal).Value = cod_cc

        hoja_excelTotales.Cells(xTotal, yTotal + 1).Value = centroCostos

        hoja_excelTotales.Cells(xTotal, yTotal + 2).Value = totalLunes

        hoja_excelTotales.Cells(xTotal, yTotal + 3).Value = totalMartes

        hoja_excelTotales.Cells(xTotal, yTotal + 4).Value = totalMiercoles

        hoja_excelTotales.Cells(xTotal, yTotal + 5).Value = totalJueves

        hoja_excelTotales.Cells(xTotal, yTotal + 6).Value = totalViernes

        hoja_excelTotales.Cells(xTotal, yTotal + 7).Value = totalSabado

        hoja_excelTotales.Cells(xTotal, yTotal + 8).Value = totalDomingo

        hoja_excelTotales.Cells(xTotal, yTotal + 9).Value = totalSemanal

        hoja_excelTotales.Cells(xTotal, yTotal + 10).Value = totalSemanalD

        hoja_excelTotales.Cells(xTotal, yTotal + 11).Value = totalSemanalT

        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()
        hoja_excelTotales.Cells(hoja_excelTotales.Dimension.Address).AutoFitColumns()


    End Sub

    Public Sub reporte_cursos(dtDatosPostFunciones)
        'codigo para generar excel
        Dim sfd As New SaveFileDialog
        sfd.Title = "Excel"
        If sfd.ShowDialog = DialogResult.OK Then
            ExportaExcel(dtDatosPostFunciones, sfd.FileName, "reloj", False)
        End If
    End Sub

    Public Sub AplicarCambiosAntiguedad(dtDatos As DataTable)
        Dim dtTemp As DataTable
        Dim dtCopiaModSal As DataTable = sqlExecute("select * from mod_sal where reloj='x'")
        Try
            'If MessageBox.Show("¿Desea agregar estos cambios a las modificaciones de sueldo pendientes y generar las multiformas?", "Cambios de salario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            For Each dRow As DataRow In dtDatos.Rows
                dtTemp = sqlExecute("SELECT * from personalvw WHERE reloj = '" & dRow("reloj") & "'")
                For Each dRow2 As DataRow In dtTemp.Rows
                    Dim nuevo_factor As Double = sqlExecute("select factor_int from factores where cod_comp = '" & dRow2("cod_comp") & "' and cod_tipo = '" & dRow2("cod_tipo") & "' and anos = '" & AntiguedadVac(dRow2("alta"), FechaFinal) + 1 & "'").Rows(0)("factor_int")
                    Dim sactual As Double = IIf(dRow("tipo_antiguedad").ToString.Contains("Antigüedad"), dRow("nuevo_sueldo"), 0)
                    Dim provar As Double = dRow2("pro_var")
                    Dim nuevo_integrado As Double = Math.Round((sactual * nuevo_factor) + provar, 2)

                    If dRow("nuevo_sueldo") > 0 Then

                    Else
                        dtCopiaModSal.Rows.Add({"0", dRow2("cod_comp"), dRow("reloj"), "", dRow("sactual"), 0, dRow2("pro_var"), nuevo_factor, dRow("fecha_cambio"), IIf(dRow("tipo_antiguedad").ToString.Contains("Antig"), dRow("tipo_antiguedad"), dRow("tipo_antiguedad").ToString.Substring(0, 9) + " " + "(promoción)"), dRow("nuevo_nivel"), 0, FechaSQL(Now), 0, FechaSQL(Now), ""})

                    End If
                Next
            Next
            dtDatos.Columns.Add("tipo_reporte")
            For Each dRow3 As DataRow In dtDatos.Rows
                'dtDatos.Rows(0).Item("nivel") = dRow("nuevo_nivel")
                dRow3("tipo_reporte") = "antiguedad"
            Next
            dtMultiformaExtraModSal = dtCopiaModSal
            dtDatosPost = dtDatos
            If dtDatos.Rows.Count > 0 Then
                frmVistaPrevia.LlamarReporte("Formato Multiple", dtDatos)
                frmVistaPrevia.ShowDialog()
            End If
            dtMultiformaExtraModSal = New DataTable

        Catch ex As Exception
        End Try
    End Sub
End Module
