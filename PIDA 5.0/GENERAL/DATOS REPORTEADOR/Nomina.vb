Option Compare Text
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Drawing.Printing
'Imports Excel = Microsoft.Office.Interop.Excel
Imports OfficeOpenXml
Imports System.Globalization


Module Nomina

    '******************** ACASAS 20180316 ****************************

    Public Sub generar_recibos(ByVal dtInformacion As DataTable)
        Try

            EstructuraSobres()

            For Each drInformacion As DataRow In dtInformacion.Rows

                LlenarRecibo(drInformacion)

                Application.DoEvents()

            Next

            frmVistaPrevia.EmitirRecibos("Recibo_nomina", "", dtrecibos, "", "RELOJ", 0, True)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "btnEnviar", Err.Number, ex.Message)
        End Try

    End Sub



    Dim dtMontoHrExtra As New DataTable  ' Tabla que contendrá solo el monto de hora doble o tiple
    Dim dtMovConcExento As New DataTable  'Tabla que contendrá solo el movimiento del conceto exento
    Dim dtTimbrado As New DataTable     ' Tabla que va a contener la informacion de timbrado
    Dim dtTemp As New DataTable
    Public Sub AcumuladoConceptos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            Dim dtMovs As New DataTable
            dtDatos.Columns.Add("periodo")
            dtDatos.Columns.Add("concepto")
            dtDatos.Columns.Add("descripcion")
            dtDatos.Columns.Add("naturaleza")
            dtDatos.Columns.Add("monto", GetType(System.Double))
            dtDatos.Columns.Add("concepto_exento")
            dtDatos.Columns.Add("total", GetType(System.Double))
            dtDatos.Columns.Add("gravado", GetType(System.Double))
            dtDatos.Columns.Add("exento", GetType(System.Double))
            dtDatos.Columns.Add("prioridad")
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("periodo"), dtDatos.Columns("concepto")}

            Try
                Dim filtro As String = ""
                Dim _X As Integer = 9
                Dim txtTexto As String = EncabezadoReporte.Replace("PERIODOS", "PERIODO").Replace("PERIODO ", "")
                txtTexto = "'" & txtTexto & "'"
                For Each f As String In txtTexto.Replace(", ", "','").Replace("PERIODOS", "PERIODO").Replace("PERIODO ", "").Split(",")
                    filtro &= f.Substring(0, 9) & ","
                Next
                filtro &= "_"
                filtro = filtro.Replace("',_", "'")

                dtInformacion = sqlExecute(
                "select " & _
                "movimientos.periodo, " & _
                "movimientos.concepto, " & _
                "conceptos.nombre, " & _
                "sum(movimientos.monto) as monto, " & _
                "conceptos.prioridad, " & _
                "conceptos.cod_naturaleza, " & _
                "Conceptos.EXENTO " & _
                "from movimientos " & _
                "left join conceptos on movimientos.concepto=conceptos.concepto " & _
                "where movimientos.ano + '-' + movimientos.periodo in (" & filtro & ")" & _
                "and (conceptos.cod_naturaleza in ('P','D') OR movimientos.concepto='APOFAH') " & _
                "group by " & _
                "movimientos.periodo, " & _
                "movimientos.concepto, " & _
                "conceptos.nombre, " & _
                "conceptos.prioridad, " & _
                "conceptos.cod_naturaleza, " & _
                "conceptos.exento", "NOMINA")

            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

            For Each row As DataRow In dtInformacion.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("periodo") = row("periodo")
                dr("concepto") = row("concepto")
                dr("descripcion") = row("nombre")
                dr("monto") = row("monto")
                dr("prioridad") = row("prioridad")
                dr("naturaleza") = IIf(RTrim(row("cod_naturaleza")) = "P", "Percepciones", IIf(RTrim(row("cod_naturaleza")) = "D", "Deducciones", row("cod_naturaleza")))
                dr("concepto_exento") = row("exento")
                dr("gravado") = row("monto")
                dr("exento") = 0
                dr("total") = dr("gravado") + dr("exento")
                dtDatos.Rows.Add(dr)

            Next

            For Each row As DataRow In dtDatos.Rows
                Try
                    Dim dr As DataRow = dtDatos.Rows.Find({row("periodo"), row("concepto_exento")})
                    If Not dr Is Nothing Then
                        row("exento") = dr("monto")
                        row("gravado") = row("gravado") - row("exento")
                        row("total") = row("gravado") + row("exento")
                    End If
                Catch ex As Exception

                End Try
            Next
            dtDatos = dtDatos.Select("naturaleza <> 'I'").CopyToDataTable
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub
    Public Sub MovimientosFAHVector(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "", Optional _tipo_movimiento As String = "")
        Try

            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipomovimiento", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipomovimiento", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))
            dtDatos.Columns.Add("monto_b", Type.GetType("System.Double"))

            dtDatos.Columns.Add("detalle", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("procesado", Type.GetType("System.String"))

            dtDatos.Columns.Add("tipo_periodo", Type.GetType("System.String"))

            Dim f_ini_periodo As Date = Now
            Dim f_fin_periodo As Date = Now


            Dim tipo_per As String = IIf(IsDBNull(dtInformacion.Rows(0).Item("tipo_periodo")), "Q", dtInformacion.Rows(0).Item("tipo_periodo"))
            If tipo_per = "S" Then
                Dim dtInfoPeriodo As DataTable = sqlExecute("select * from periodos where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "TA")
                If dtInfoPeriodo.Rows.Count > 0 Then
                    f_ini_periodo = dtInfoPeriodo.Rows(0)("fecha_ini")
                    f_fin_periodo = dtInfoPeriodo.Rows(0)("fecha_fin")
                Else
                    Exit Sub
                End If
            ElseIf tipo_per = "Q" Then
                Dim dtInfoPeriodo As DataTable = sqlExecute("select * from periodos_quincenal where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "TA")
                If dtInfoPeriodo.Rows.Count > 0 Then
                    f_ini_periodo = dtInfoPeriodo.Rows(0)("fecha_ini")
                    f_fin_periodo = dtInfoPeriodo.Rows(0)("fecha_fin")
                Else
                    Exit Sub
                End If

            End If
            'Dim dtInfoPeriodo As DataTable = sqlExecute("select * from periodos where ano = '" & _ano & "' and periodo = '" & _periodo & "' and isnull(periodo_especial, 0) = '0'", "TA")
            'If dtInfoPeriodo.Rows.Count > 0 Then
            '    f_ini_periodo = dtInfoPeriodo.Rows(0)("fecha_ini")
            '    f_fin_periodo = dtInfoPeriodo.Rows(0)("fecha_fin")
            'Else
            '    Exit Sub
            'End If


            Dim dtArchivoExcel As New DataTable
            dtArchivoExcel.Columns.Add("tipo_movimiento")
            dtArchivoExcel.Columns.Add("tipo_aportacion")
            dtArchivoExcel.Columns.Add("codigo_empleado")
            dtArchivoExcel.Columns.Add("sucursal")
            dtArchivoExcel.Columns.Add("departamento")
            dtArchivoExcel.Columns.Add("importe")
            dtArchivoExcel.Columns.Add("nombre")
            dtArchivoExcel.Columns.Add("fecha")
            dtArchivoExcel.Columns.Add("adicional")
            dtArchivoExcel.Columns.Add("numero_prestamo")


            For Each row As DataRow In dtInformacion.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")
                dr("nombres") = row("nombres")
                dr("tipo_periodo") = row("tipo_periodo")
                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")

                dr("cod_tipomovimiento") = _tipo_movimiento

                Select Case _tipo_movimiento
                    Case "1"
                        dr("nombre_tipomovimiento") = "ALTAS"
                    Case "2"
                        dr("nombre_tipomovimiento") = "BAJAS"
                    Case "3"
                        dr("nombre_tipomovimiento") = "APORTACIONES"
                    Case "4"
                        dr("nombre_tipomovimiento") = "ABONOS"
                    Case "5"
                        dr("nombre_tipomovimiento") = "PRESTAMOS"
                    Case Else
                        dr("nombre_tipomovimiento") = "N / A"
                End Select

                Try
                    dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
                    dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                Catch ex As Exception

                End Try

                dr("ano") = _ano
                dr("periodo") = _periodo

                dr("procesado") = _ano & "-" & _periodo

                Dim monto_ As Double = 0
                'monto_ = IIf(IsDBNull(row("NETO")), 0, row("NETO"))

                Select Case _tipo_movimiento
                    Case "1"
                        '' ALTAS


                    Case "2"
                        ' BAJAS                        
                        monto_ = IIf(IsDBNull(row("DEVFAH")), 0, row("DEVFAH"))
                        dr("monto") = monto_

                        Dim f_baja As Date = f_fin_periodo.AddDays(1)

                        Try
                            f_baja = Date.Parse(row("baja"))
                        Catch ex As Exception

                        End Try


                        If monto_ > 0 Then
                            dtDatos.Rows.Add(dr)
                        End If

                    Case "3"
                        ' APORTACIONES                        
                        monto_ = IIf(IsDBNull(row("APOFAH")), 0, row("APOFAH"))
                        dr("monto") = monto_

                        If monto_ > 0 Then
                            dtDatos.Rows.Add(dr)
                        End If
                    Case "4"
                        '' ABONOS 

                    Case "5"
                        ' PRESTAMOS
                        'Dim prepre_ As Double = IIf(IsDBNull(row("PTMOFA")), 0, row("PTMOFA"))
                        Dim prepre_ As Double = IIf(IsDBNull(row("OTPNOG")), 0, row("OTPNOG"))

                        If prepre_ > 0 Then
                            monto_ = prepre_
                            dr("monto") = monto_

                            dtDatos.Rows.Add(dr)

                        End If


                    Case Else
                        monto_ = 0
                End Select

            Next



            nombre_archivo = nombre_archivo.Replace("YYYY", _ano)
            nombre_archivo = nombre_archivo.Replace("XX", _periodo)


            Try

                Dim reloj_actual As String = ""

                Try

                    For Each row As DataRow In dtDatos.Rows


                        Dim nombre As String = row("nombres").ToString().Split(",")(2).PadRight(0, Space(27))
                        Dim apaterno As String = row("nombres").ToString().Split(",")(0).PadRight(0, Space(27))
                        Dim amaterno As String = row("nombres").ToString().Split(",")(1).PadRight(0, Space(27))

                        Dim nombre_completo As String = RTrim(apaterno) & " " & RTrim(amaterno) & "/ " & RTrim(nombre)
                        nombre_completo = nombre_completo.ToUpper.Replace("Ñ", "N")


                        Select Case _tipo_movimiento
                            Case "1"
                                ' ALTAS                                


                            Case "2"
                                ' BAJAS

                                Dim monto_string As String = ""

                                monto_string = String.Format("{0:0.00}", row("monto")).PadLeft(10, Space(1))

                                Dim dtBajaRetiro As DataRow = dtArchivoExcel.NewRow
                                dtBajaRetiro("tipo_movimiento") = "3"
                                dtBajaRetiro("tipo_aportacion") = "S"
                                dtBajaRetiro("codigo_empleado") = row("reloj")
                                dtBajaRetiro("sucursal") = ""
                                dtBajaRetiro("departamento") = ""
                                dtBajaRetiro("importe") = monto_string
                                dtBajaRetiro("nombre") = nombre_completo
                                dtBajaRetiro("fecha") = FechaSQL(Now)
                                dtBajaRetiro("adicional") = ""
                                dtBajaRetiro("numero_prestamo") = ""

                                dtArchivoExcel.Rows.Add(dtBajaRetiro)


                            Case "3"
                                ' APORTACIONES

                                Dim monto_string As String = ""

                                monto_string = String.Format("{0:0.00}", row("monto")).PadLeft(10, Space(1))

                                Dim dAportacionA As DataRow = dtArchivoExcel.NewRow
                                dAportacionA("tipo_movimiento") = "1"
                                dAportacionA("tipo_aportacion") = row("tipo_periodo")
                                dAportacionA("codigo_empleado") = row("reloj")
                                dAportacionA("sucursal") = ""
                                dAportacionA("departamento") = ""
                                dAportacionA("importe") = monto_string
                                dAportacionA("nombre") = nombre_completo
                                dAportacionA("fecha") = f_fin_periodo
                                dAportacionA("adicional") = ""
                                dAportacionA("numero_prestamo") = ""
                                dtArchivoExcel.Rows.Add(dAportacionA)

                                Dim dAportacionB As DataRow = dtArchivoExcel.NewRow
                                dAportacionB("tipo_movimiento") = "2"
                                dAportacionB("tipo_aportacion") = row("tipo_periodo")
                                dAportacionB("codigo_empleado") = row("reloj")
                                dAportacionB("sucursal") = ""
                                dAportacionB("departamento") = ""
                                dAportacionB("importe") = monto_string
                                dAportacionB("nombre") = nombre_completo
                                dAportacionB("fecha") = f_fin_periodo
                                dAportacionB("adicional") = ""
                                dAportacionB("numero_prestamo") = ""
                                dtArchivoExcel.Rows.Add(dAportacionB)

                            Case "4"
                                '' ABONOS                                

                            Case "5"
                                ' PRESTAMOS

                                Dim monto_string As String = ""

                                monto_string = String.Format("{0:0.00}", row("monto")).PadLeft(10, Space(1))

                                Dim drAbonoPrestamo As DataRow = dtArchivoExcel.NewRow
                                drAbonoPrestamo("tipo_movimiento") = "6"
                                drAbonoPrestamo("tipo_aportacion") = "S"
                                drAbonoPrestamo("codigo_empleado") = row("reloj")
                                drAbonoPrestamo("sucursal") = ""
                                drAbonoPrestamo("departamento") = ""
                                drAbonoPrestamo("importe") = monto_string
                                drAbonoPrestamo("nombre") = nombre_completo
                                drAbonoPrestamo("fecha") = FechaSQL(Now)
                                drAbonoPrestamo("adicional") = ""
                                drAbonoPrestamo("numero_prestamo") = ""

                                dtArchivoExcel.Rows.Add(drAbonoPrestamo)

                            Case Else

                        End Select

                    Next

                    'guardar a csv
                    nombre_archivo = nombre_archivo.Replace("YYYY", _ano)
                    nombre_archivo = nombre_archivo.Replace("XX", _periodo)
                    Dim archivo As ExcelPackage = New ExcelPackage()
                    Dim wb As ExcelWorkbook = archivo.Workbook
                    'VectorFahCSV(nombre_archivo, dtArchivoExcel)
                    VectorFahCSV(nombre_archivo, dtArchivoExcel, wb)
                    archivo.SaveAs(New System.IO.FileInfo(nombre_archivo))

                Catch ex As Exception

                End Try

            Catch ex As Exception

                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub VectorFahCSV(nombre_archivo As String, dtCSV As DataTable, ByRef wb As ExcelWorkbook)
        Try

            ' Reporte a detalle Excel
            Dim x As Integer = 1
            Dim y As Integer = 1
            Dim hoja As String() = nombre_archivo.Split("\")
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(hoja(hoja.Length - 1))
            hoja_excel.Cells(x, y).Value = "Mov"
            hoja_excel.Cells(x, y).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 1).Value = "Apo"
            hoja_excel.Cells(x, y + 1).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 2).Value = "Codigo de Empleado"
            hoja_excel.Cells(x, y + 2).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 3).Value = "Suc"
            hoja_excel.Cells(x, y + 3).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 4).Value = "Dp"
            hoja_excel.Cells(x, y + 4).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 5).Value = "Importe"
            hoja_excel.Cells(x, y + 5).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 6).Value = "Nombre"
            hoja_excel.Cells(x, y + 6).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 7).Value = "Fecha"
            hoja_excel.Cells(x, y + 7).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 8).Value = "Adicional"
            hoja_excel.Cells(x, y + 8).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 9).Value = "No. Pago Prest"
            hoja_excel.Cells(x, y + 9).Style.Font.Bold = True
            x = x + 1

            For Each drAbonoPrestamo As DataRow In dtCSV.Rows
                hoja_excel.Cells(x, y).Value = Convert.ToInt32(drAbonoPrestamo("tipo_movimiento"))
                hoja_excel.Cells(x, y + 1).Value = drAbonoPrestamo("tipo_aportacion")
                hoja_excel.Cells(x, y + 2).Value = Convert.ToInt32(drAbonoPrestamo("codigo_empleado"))
                hoja_excel.Cells(x, y + 3).Value = drAbonoPrestamo("sucursal")
                hoja_excel.Cells(x, y + 4).Value = drAbonoPrestamo("departamento")
                hoja_excel.Cells(x, y + 5).Value = Convert.ToDouble(drAbonoPrestamo("importe"))
                hoja_excel.Cells(x, y + 6).Value = drAbonoPrestamo("nombre")
                hoja_excel.Cells(x, y + 7).Value = Date.Parse(drAbonoPrestamo("fecha")).ToShortDateString
                hoja_excel.Cells(x, y + 8).Value = drAbonoPrestamo("adicional")
                hoja_excel.Cells(x, y + 9).Value = drAbonoPrestamo("numero_prestamo")
                x = x + 1
            Next


            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()
            ''Dim oWrite As System.IO.StreamWriter
            ''Try
            ''    oWrite = File.CreateText(nombre_archivo)

            ''    Dim reloj_actual As String = ""

            ''    Try

            ''        For Each drAbonoPrestamo As DataRow In dtCSV.Rows

            ''            Dim linea As String = ""


            ''            linea &= drAbonoPrestamo("tipo_movimiento") & ","
            ''            linea &= drAbonoPrestamo("tipo_aportacion") & ","
            ''            linea &= drAbonoPrestamo("codigo_empleado") & ","
            ''            linea &= drAbonoPrestamo("sucursal") & ","
            ''            linea &= drAbonoPrestamo("departamento") & ","
            ''            linea &= drAbonoPrestamo("importe") & ","
            ''            linea &= drAbonoPrestamo("nombre") & ","
            ''            linea &= drAbonoPrestamo("fecha")

            ''            oWrite.WriteLine(linea)

            ''        Next
            ''    Catch ex As Exception
            ''        oWrite.WriteLine(reloj_actual & Space(1) & ex.Message)
            ''    End Try

            ''    oWrite.Close()
            ''Catch ex As Exception
            ''    oWrite = Nothing
            ''End Try
        Catch ex As Exception

        End Try
    End Sub

    Public Sub MovimientosFAH(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "", Optional _tipo_movimiento As String = "")
        Try

            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipomovimiento", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipomovimiento", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))

            dtDatos.Columns.Add("detalle", Type.GetType("System.Int32"))


            Dim f_ini_periodo As Date = Now
            Dim f_fin_periodo As Date = Now

            Dim dtInfoPeriodo As DataTable = sqlExecute("select * from periodos where ano = '" & _ano & "' and periodo = '" & _periodo & "' and isnull(periodo_especial, 0) = '0'", "TA")
            If dtInfoPeriodo.Rows.Count > 0 Then
                f_ini_periodo = dtInfoPeriodo.Rows(0)("fecha_ini")
                f_fin_periodo = dtInfoPeriodo.Rows(0)("fecha_fin")
            Else
                Exit Sub
            End If

            For Each row As DataRow In dtInformacion.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")
                dr("nombres") = row("nombres")

                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")

                dr("cod_tipomovimiento") = _tipo_movimiento

                Select Case _tipo_movimiento
                    Case "1"
                        dr("nombre_tipomovimiento") = "ALTAS"
                    Case "2"
                        dr("nombre_tipomovimiento") = "BAJAS"
                    Case "3"
                        dr("nombre_tipomovimiento") = "APORTACIONES"
                    Case "4"
                        dr("nombre_tipomovimiento") = "ABONOS"
                    Case "5"
                        dr("nombre_tipomovimiento") = "PRESTAMOS"
                    Case Else
                        dr("nombre_tipomovimiento") = "N / A"
                End Select

                Try
                    dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
                    dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                Catch ex As Exception

                End Try

                dr("ano") = _ano
                dr("periodo") = _periodo

                Dim monto_ As Double = 0
                'monto_ = IIf(IsDBNull(row("NETO")), 0, row("NETO"))

                Select Case _tipo_movimiento
                    Case "1"
                        ' ALTAS
                        monto_ = 0
                        dr("monto") = monto_

                        Dim f_alta As Date = f_fin_periodo.AddDays(1)
                        f_alta = Date.Parse(row("alta"))

                        If f_ini_periodo <= f_alta And f_alta <= f_fin_periodo Then
                            dtDatos.Rows.Add(dr)
                        End If

                    Case "2"
                        ' BAJAS                        
                        monto_ = IIf(IsDBNull(row("SANEFA")), 0, row("SANEFA"))
                        dr("monto") = monto_

                        Dim f_baja As Date = f_fin_periodo.AddDays(1)

                        Try
                            f_baja = Date.Parse(row("baja"))
                        Catch ex As Exception

                        End Try

                        'If (f_ini_periodo <= f_baja And f_baja <= f_fin_periodo) And monto_ > 0 Then
                        '     dtDatos.Rows.Add(dr)
                        ' End If

                        If monto_ > 0 Then
                            dtDatos.Rows.Add(dr)
                        End If

                    Case "3"
                        ' APORTACIONES                        
                        monto_ = IIf(IsDBNull(row("APOFAH")), 0, row("APOFAH"))
                        dr("monto") = monto_

                        If monto_ > 0 Then
                            dtDatos.Rows.Add(dr)
                        End If
                    Case "4"
                        ' ABONOS 
                        Dim abono_ As Double = IIf(IsDBNull(row("PREFAH")), 0, row("PREFAH"))
                        Dim intereses_ As Double = IIf(IsDBNull(row("INTFAH")), 0, row("INTFAH"))

                        monto_ = abono_ + intereses_

                        dr("monto") = monto_
                        If monto_ > 0 Then
                            dtDatos.Rows.Add(dr)
                        End If
                    Case "5"
                        ' PRESTAMOS
                        Dim prepre_ As Double = IIf(IsDBNull(row("PREPRE")), 0, row("PREPRE"))

                        Dim salprf_ As Double = IIf(IsDBNull(row("SALPRF")), 0, row("SALPRF"))
                        Dim salint_ As Double = IIf(IsDBNull(row("SALINT")), 0, row("SALINT"))

                        Dim semanas_ As Double = IIf(IsDBNull(row("PAGPRE")), 0, row("PAGPRE"))

                        If prepre_ > 0 Then
                            If (prepre_ = salprf_) Then
                                monto_ = prepre_
                                dr("monto") = monto_ + salint_

                                dr("detalle") = IIf(semanas_ = 0, 999, semanas_)

                                dtDatos.Rows.Add(dr)

                            End If
                        End If


                    Case Else
                        monto_ = 0
                End Select

            Next

            nombre_archivo = nombre_archivo.Replace("YYYY", _ano)
            nombre_archivo = nombre_archivo.Replace("XX", _periodo)

            Dim oWrite As System.IO.StreamWriter
            Try
                oWrite = File.CreateText(nombre_archivo)

                Dim reloj_actual As String = ""

                Try

                    For Each row As DataRow In dtDatos.Rows

                        Dim linea As String = ""

                        Select Case _tipo_movimiento
                            Case "1"
                                ' ALTAS
                                linea &= row("reloj").ToString().Substring(1, 5) & ","

                                Dim nombre As String = row("nombres").ToString().Split(",")(0).PadRight(0, Space(27))
                                Dim apaterno As String = row("nombres").ToString().Split(",")(1).PadRight(0, Space(27))
                                Dim amaterno As String = row("nombres").ToString().Split(",")(2).PadRight(0, Space(27))

                                linea &= nombre & "," & apaterno & "," & amaterno & ","

                                linea &= IIf(row("cod_tipo") = "A", 3, 1)

                                oWrite.WriteLine(linea)
                            Case "2"
                                ' BAJAS
                                linea &= row("reloj").ToString().Substring(1, 5) & ","

                                Dim aportacion_string As String = Int(row("monto") * 100).ToString.PadLeft(3, "0")
                                aportacion_string = aportacion_string.PadLeft(9, Space(1))
                                aportacion_string = aportacion_string.Substring(0, 7) & "." & aportacion_string.Substring(7, 2)

                                aportacion_string = String.Format("{0:0.00}", row("monto")).PadLeft(10, Space(1))

                                linea &= aportacion_string & ","

                                linea &= "L"

                                oWrite.WriteLine(linea)
                            Case "3"
                                ' APORTACIONES

                                Dim aportacion_string As String = Int(row("monto") * 100).ToString.PadLeft(3, "0")
                                aportacion_string = aportacion_string.PadLeft(9, Space(1))
                                aportacion_string = aportacion_string.Substring(0, 7) & "." & aportacion_string.Substring(7, 2)

                                aportacion_string = String.Format("{0:0.00}", row("monto")).PadLeft(10, Space(1))

                                linea = ""
                                linea &= row("reloj").ToString().Substring(1, 5) & ","
                                linea &= aportacion_string & ","
                                linea &= "APEMP"
                                oWrite.WriteLine(linea)

                                linea = ""
                                linea &= row("reloj").ToString().Substring(1, 5) & ","
                                linea &= aportacion_string & ","
                                linea &= "APCIA"

                                oWrite.WriteLine(linea)
                            Case "4"
                                ' ABONOS
                                linea &= row("reloj").ToString().Substring(1, 5) & ","

                                Dim aportacion_string As String = Int(row("monto") * 100).ToString.PadLeft(3, "0")
                                aportacion_string = aportacion_string.PadLeft(9, Space(1))
                                aportacion_string = aportacion_string.Substring(0, 7) & "." & aportacion_string.Substring(7, 2)

                                aportacion_string = String.Format("{0:0.00}", row("monto")).PadLeft(10, Space(1))

                                linea &= aportacion_string

                                oWrite.WriteLine(linea)
                            Case "5"
                                ' PRESTAMOS

                                linea &= row("reloj").ToString().Substring(1, 5) & ","
                                linea &= "IG" & ","
                                linea &= "PS" & ","

                                Dim aportacion_string As String = Int(row("monto") * 100).ToString.PadLeft(3, "0")
                                aportacion_string = aportacion_string.PadLeft(9, Space(1))
                                aportacion_string = aportacion_string.Substring(0, 7) & "." & aportacion_string.Substring(7, 2)

                                aportacion_string = String.Format("{0:0.00}", row("monto")).PadLeft(10, Space(1))

                                linea &= aportacion_string & ","

                                linea &= row("detalle").ToString.PadLeft(3, "0")

                                oWrite.WriteLine(linea)
                            Case Else
                                oWrite.WriteLine(linea)
                        End Select

                    Next
                Catch ex As Exception
                    oWrite.WriteLine(reloj_actual & Space(1) & ex.Message)
                End Try

                oWrite.Close()

            Catch ex As Exception
                oWrite = Nothing
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte flujo efectivo basado en qro
    ''' </summary>
    ''' <param name="dtDatos"></param>
    ''' <param name="dtInformacion"></param>
    ''' <param name="nombre_archivo"></param>
    ''' <param name="_ano"></param>
    ''' <param name="_periodo"></param>
    ''' <param name="_inter"></param>
    ''' <remarks></remarks>
    Public Sub FlujoEfectivo(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "", Optional _inter As String = "0")
        Try
            Dim tipo_periodo As String = ""
            Dim cod_comp As String = ""
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

            dtDatos.Columns.Add("nomina", Type.GetType("System.Double"))
            dtDatos.Columns.Add("prestamo", Type.GetType("System.Double"))
            dtDatos.Columns.Add("retiro", Type.GetType("System.Double"))
            dtDatos.Columns.Add("pension", Type.GetType("System.Double"))
            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))

            dtDatos.Columns.Add("cod_tipo_nomina", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo_nomina", Type.GetType("System.String"))

            dtDatos.Columns.Add("tipo_reporte", Type.GetType("System.String"))

            For Each row As DataRow In dtInformacion.Rows

                If tipo_periodo = "" Then
                    tipo_periodo = row("tipo_periodo").ToString.Trim
                End If
                If cod_comp = "" Then
                    cod_comp = row("cod_comp")
                End If

                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")

                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")

                dr("cod_tipo_nomina") = RTrim(row("cod_tipo_nomina"))



                dr("ano") = _ano
                dr("periodo") = _periodo

                Dim nomina_ As Double = IIf(IsDBNull(row("NETO")), 0, row("NETO"))
                dr("nomina") = nomina_

                Dim prestamo_ As Double = 0.0
                dr("prestamo") = prestamo_

                Dim retiro_ As Double = 0.0
                dr("retiro") = retiro_

                Dim pension_ As Double = 0
                dr("pension") = pension_

                Dim monto_ As Double = nomina_ + prestamo_ + retiro_ + pension_
                dr("monto") = monto_


                Dim interbancario As Boolean = IIf(IsDBNull(row("banco")), True, False)
                Dim cuenta As String = RTrim(row("cuenta"))

                If dr("cod_tipo_nomina") = "F" Then
                    dr("tipo_reporte") = "Convenio"
                Else
                    If interbancario = True Then
                        dr("tipo_reporte") = "Interbancarios"
                    Else
                        If cuenta = "" Then
                            If row("cod_pago") = "S" Then
                                dr("tipo_reporte") = "Sueldos por cobrar"
                            Else
                                dr("tipo_reporte") = "Ordenes de pago"
                            End If

                        Else
                            dr("tipo_reporte") = "Citibanamex"
                        End If
                    End If
                End If

                '--- AO 2023-06-07: Agregar a tabla de bajasxaus las bajas que son por Aus para que se muestren en pantalla
                If row("cod_pago") = "A" Then
                    dr("tipo_reporte") = "Finiquitos ausentismo"

                    Dim _cComp As String = "", anio As String = "", periodo As String = "", _reloj As String = "", nombre As String = "", fbaja As String = "", _neto As Double = 0.0
                    Try : _cComp = row("cod_comp").ToString.Trim : Catch ex As Exception : _cComp = "" : End Try
                    anio = _ano
                    periodo = _periodo
                    Try : _reloj = row("reloj").ToString.Trim : Catch ex As Exception : _reloj = "" : End Try
                    Try : nombre = row("nombres").ToString.Trim : Catch ex As Exception : nombre = "" : End Try
                    Try : fbaja = FechaSQL(row("baja")) : Catch ex As Exception : fbaja = "" : End Try
                    Try : _neto = monto_ : Catch ex As Exception : _neto = 0.0 : End Try

                    If fbaja = "" Then fbaja = "NULL" Else fbaja = "'" & fbaja & "'"

                    If _neto <> 0 Then
                        Dim QD As String = "delete from bajasxaus where COD_COMP='" & _cComp & "' and ano+PERIODO='" & anio & periodo & "' and reloj='" & _reloj & "'"
                        Dim QI As String = "insert into bajasxaus values ('" & _cComp & "','" & anio & "','" & periodo & "','" & _reloj & "','" & nombre & "'," & fbaja & ",'" & cuenta & "'," & _neto & ",'" & Usuario & "',GETDATE(),NULL,0)"
                        sqlExecute(QD, "NOMINA")
                        sqlExecute(QI, "NOMINA")
                    End If

                End If


                If monto_ > 0 Then
                    dtDatos.Rows.Add(dr)
                End If

            Next


            Dim dtPensiones As DataTable

            Dim QP As String = "select * from pensiones_alimenticias where  tipo_periodo = '" & tipo_periodo & "' and cod_comp = '" & cod_comp & "'"
            dtPensiones = sqlExecute(QP, "nomina")


            For Each row As DataRow In dtPensiones.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")

                dr("cod_tipo") = "PX"
                dr("nombre_tipo") = "Pensiones"

                dr("cod_tipo_nomina") = "P"

                dr("ano") = row("ano")
                dr("periodo") = row("periodo")

                dr("nomina") = 0
                dr("prestamo") = 0
                dr("retiro") = 0

                Dim QMP As String = "select * from movimientos where reloj = '" & row("reloj") & "' and ano= '" & _ano & "' and periodo = '" & _periodo & "' and tipo_periodo = '" & tipo_periodo & "' and concepto = '" & IIf(row("pension").ToString.Trim = "1", "PENAL1", "PENAL2") & "'"
                Dim dtmontopen As DataTable = sqlExecute(QMP, "NOMINA")
                Dim pension_ As Double = 0
                If dtmontopen.Rows.Count > 0 Then
                    pension_ = IIf(IsDBNull(dtmontopen.Rows(0).Item("monto")), 0, dtmontopen.Rows(0).Item("monto"))
                End If
                dr("pension") = pension_

                Dim monto_ As Double = pension_
                dr("nomina") = monto_

                Dim interbancario As Boolean = IIf(row("inter") = 1, True, False)

                Dim cuenta As String = RTrim(row("cuenta"))
                Dim no_pago As Integer = row("no_pago")
                If interbancario = True Then
                    If cuenta = "" Then
                        dr("tipo_reporte") = "Juzgados"
                    Else
                        dr("tipo_reporte") = "Interbancarios"
                    End If

                    If no_pago = 1 Then
                        dr("tipo_reporte") = "Sueldos por cobrar"
                    End If
                Else
                    If cuenta = "" Then
                        dr("tipo_reporte") = "Juzgados"
                    Else
                        dr("tipo_reporte") = "Citibanamex"
                    End If
                    If no_pago = 1 Then
                        dr("tipo_reporte") = "Sueldos por cobrar"
                    End If
                End If

                If monto_ > 0 Then
                    dtDatos.Rows.Add(dr)
                End If

                '2023-03-23: Registrar las pensines de sueldos por cobrar
                If no_pago = 1 Then
                    ' Add el nombre y la cuenta HERE
                    Dim _nombrePens As String = "", _cuentaPens As String = ""
                    Try : _nombrePens = row("nombre").ToString.Trim : Catch ex As Exception : _nombrePens = "" : End Try
                    Try : _cuentaPens = row("cuenta").ToString.Trim : Catch ex As Exception : _cuentaPens = "" : End Try
                    sqlExecute("delete from sueldos_x_pagar_pensiones where cod_comp='" & cod_comp & "' and ano+periodo='" & _ano & _periodo & "' and TIPO_PERIODO='" & tipo_periodo & "' and concepto='" & IIf(row("pension").ToString.Trim = "1", "PENAL1", "PENAL2") & "' and reloj='" & row("reloj").ToString.Trim & "'", "NOMINA")
                    If (monto_ > 0) Then
                        sqlExecute("insert into sueldos_x_pagar_pensiones values ('" & cod_comp & "','" & _ano & "','" & _periodo & "','" & tipo_periodo & "','" & row("reloj").ToString.Trim & "','" & _nombrePens & "','" & _cuentaPens & "','" & IIf(row("pension").ToString.Trim = "1", "PENAL1", "PENAL2") & "'," & monto_ & ",'" & Usuario & "',getdate(),null,0)", "NOMINA")
                    End If
                End If

            Next

            For Each row As DataRow In dtDatos.Rows
                Dim c_t_n As String = row("cod_tipo_nomina")
                Select Case c_t_n
                    Case "N"
                        row("nombre_tipo_nomina") = "Normal"
                    Case "F"
                        row("nombre_tipo_nomina") = "Finiquitos"
                    Case "P"
                        row("nombre_tipo_nomina") = "Pensiones"
                    Case Else
                        row("nombre_tipo_nomina") = c_t_n
                End Select
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

    End Sub


    'Public Sub DispersionConvenio(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "", Optional _dias_a_sumar As String = "")
    '    Try
    '        dtDatos = New DataTable
    '        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("alta", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("baja", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("ano", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("nomina", Type.GetType("System.Double"))
    '        dtDatos.Columns.Add("retiro", Type.GetType("System.Double"))

    '        dtDatos.Columns.Add("monto", Type.GetType("System.Double"))


    '        Dim referencia As String = ""
    '        If nombre_archivo.ToLower.Contains("finiq") Then
    '            referencia = "BAJASSEM"
    '        ElseIf nombre_archivo.ToLower.Contains("efect") Then
    '            referencia = "EFECTSEM"
    '        Else
    '            referencia = "XXXXXXXX"
    '        End If

    '        For Each row As DataRow In dtInformacion.Rows
    '            Dim dr As DataRow = dtDatos.NewRow
    '            dr("reloj") = row("reloj")

    '            Dim nom As String = row("nombres")
    '            dr("nombres") = nom.ToUpper.Replace("Ñ", "#")

    '            dr("cod_tipo") = row("cod_tipo")
    '            dr("nombre_tipo") = row("nombre_tipoemp")
    '            dr("cod_clase") = row("cod_clase")

    '            Try
    '                dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
    '                dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
    '            Catch ex As Exception

    '            End Try

    '            dr("ano") = _ano
    '            dr("periodo") = _periodo

    '            Dim nomina_ As Double = IIf(IsDBNull(row("NETO")), 0, row("NETO"))
    '            dr("nomina") = nomina_

    '            Dim retiro_ As Double = IIf(IsDBNull(row("SANEFA")), 0, row("SANEFA"))
    '            dr("retiro") = retiro_

    '            Dim monto_ As Double = nomina_ + retiro_

    '            dr("monto") = monto_

    '            If monto_ > 0 Then
    '                dtDatos.Rows.Add(dr)
    '            End If
    '        Next

    '        nombre_archivo = nombre_archivo.Replace("YYYY", _ano)
    '        nombre_archivo = nombre_archivo.Replace("XX", _periodo)

    '        Dim fecha_envio As Date = Now
    '        Dim dtPeriodo As DataTable = sqlExecute("select * from periodos where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "TA")
    '        If dtPeriodo.Rows.Count > 0 Then
    '            fecha_envio = Date.Parse(dtPeriodo.Rows(0)("fecha_ini")).AddDays(Int32.Parse(_dias_a_sumar))
    '        Else
    '            Exit Sub
    '        End If

    '        Dim fecha_limite As Date = fecha_envio
    '        If nombre_archivo.ToLower.Contains("finiq") Then
    '            fecha_limite = fecha_envio.AddMonths(2)
    '        Else
    '            fecha_limite = fecha_envio.AddDays(14)
    '        End If


    '        Dim encabezado As String = ""
    '        encabezado &= "H001242946"
    '        encabezado &= FechaSQL(fecha_envio)
    '        encabezado &= "01"
    '        encabezado &= "SEMANA" & _periodo & referencia
    '        encabezado &= Space(14)
    '        encabezado &= "00"
    '        encabezado &= Space(20)
    '        encabezado &= "B"
    '        encabezado &= Space(1291)

    '        Dim oWrite As System.IO.StreamWriter
    '        Try
    '            oWrite = File.CreateText(nombre_archivo)

    '            oWrite.WriteLine(encabezado)

    '            Dim total_empleados As Integer = 0
    '            Dim total_monto As Double = 0

    '            Dim totales As String = ""
    '            Dim reloj_actual As String = ""

    '            Try

    '                For Each row As DataRow In dtDatos.Rows

    '                    Dim linea As String = ""

    '                    reloj_actual = row("reloj")

    '                    linea &= "DAP"
    '                    linea &= row("reloj").ToString().Substring(1, 5)
    '                    linea &= Space(15)
    '                    linea &= referencia & _periodo
    '                    linea &= Space(20)
    '                    linea &= "PDV"
    '                    linea &= "1"
    '                    linea &= "".PadRight(20, "0")
    '                    linea &= Space(15)
    '                    linea &= referencia & _periodo
    '                    linea &= Space(15)
    '                    linea &= referencia & _periodo
    '                    linea &= Space(67)
    '                    linea &= referencia & _periodo
    '                    linea &= Space(27)
    '                    linea &= "N"
    '                    linea &= Space(8)
    '                    linea &= "00"
    '                    linea &= Space(35)
    '                    linea &= (RTrim(IIf(IsDBNull(row("nombres")), "", row("nombres"))).ToString & Space(40)).Substring(0, 40)
    '                    linea &= "7"
    '                    linea &= Space(101)
    '                    linea &= "MXP"
    '                    linea &= Space(20)
    '                    linea &= "FA"

    '                    'linea &= Int(row("monto") * 100).ToString.PadLeft(15, "0")
    '                    Dim monto As String = String.Format("{0:0.00}", row("monto")).ToString.PadLeft(16, "0").Replace(".", "")
    '                    linea &= monto

    '                    linea &= "".PadRight(17, "0")
    '                    linea &= "MAGDA.BELMONT@BRP.COM".PadRight(50, Space(1))
    '                    linea &= "N"
    '                    linea &= "".PadRight(12, "0")
    '                    linea &= FechaSQL(fecha_envio)
    '                    linea &= FechaSQL(fecha_limite)
    '                    linea &= "0001-01-01"
    '                    linea &= FechaSQL(fecha_limite)
    '                    linea &= FechaSQL(fecha_limite)
    '                    linea &= "N"
    '                    linea &= Space(1)
    '                    linea &= "0001-01-01"
    '                    linea &= "700"
    '                    linea &= Space(752)
    '                    linea &= "0001-01-01"

    '                    oWrite.WriteLine(linea)

    '                    total_empleados += 1
    '                    total_monto += row("monto")

    '                Next
    '            Catch ex As Exception
    '                oWrite.WriteLine(reloj_actual & Space(1) & ex.Message)
    '            End Try

    '            totales &= "T"
    '            totales &= total_empleados.ToString().PadLeft(10, "0")
    '            'totales &= Int(total_monto * 100).ToString.PadLeft(15, "0")

    '            Dim monto_total As String = String.Format("{0:0.00}", total_monto).ToString.PadLeft(16, "0").Replace(".", "")
    '            totales &= monto_total

    '            totales &= "".PadRight(225, "0")
    '            totales &= Space(1115)

    '            oWrite.WriteLine(totales)

    '            oWrite.Close()

    '        Catch ex As Exception
    '            oWrite = Nothing
    '            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
    '        End Try

    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
    '    End Try
    'End Sub
    Public Sub DispersionConvenio(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "", Optional _dias_a_sumar As String = "")
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

            dtDatos.Columns.Add("nomina", Type.GetType("System.Double"))
            dtDatos.Columns.Add("retiro", Type.GetType("System.Double"))
            dtDatos.Columns.Add("prestamo", Type.GetType("System.Double"))

            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))

            dtDatos.Columns.Add("procesado", Type.GetType("System.String"))

            dtDatos.Columns.Add("CURP", Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo_periodo", Type.GetType("System.String"))
            Dim finiquitos As Boolean = False
            If nombre_archivo.ToLower.Contains("finiq") Then
                finiquitos = True
            Else
                finiquitos = False
            End If
            Dim tipo_periodo As String = ""
            Dim referencia As String = ""
            Dim encabezado_ref As String = ""
            Dim concecutivo As String = ""
            If nombre_archivo.ToLower.Contains("baja") Then
                referencia = "BAJASSEM"
                encabezado_ref = "BAJASSEM"
                concecutivo = "0005"
            ElseIf nombre_archivo.ToLower.Contains("activ") Then
                referencia = "ACTIVSEM"
                encabezado_ref = "ACTIVOSEMANA"
                concecutivo = "0036"
            Else
                referencia = "XXXXXXXX"
            End If

            'If nombre_archivo.ToLower.Contains("baja") Then
            '    Dim frm As New frmFiniquitosAdicionales
            '    frm.ShowDialog()
            'End If

            For Each row As DataRow In dtInformacion.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")

                dr("procesado") = _ano & " - " & _periodo

                Dim nom As String = row("nombres")
                dr("nombres") = nom.ToUpper.Replace("Ñ", "#")
                dr("CURP") = row("CURP")
                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")
                dr("cod_clase") = row("cod_clase")

                Try
                    dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
                    dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                Catch ex As Exception

                End Try

                dr("ano") = _ano
                dr("periodo") = _periodo
                dr("tipo_periodo") = row("tipo_periodo")
                If tipo_periodo = "" Then
                    tipo_periodo = row("tipo_periodo")
                End If


                Dim nomina_ As Double = IIf(IsDBNull(row("NETO")), 0, row("NETO"))
                nomina_ -= IIf(IsDBNull(row("DEVFAH")), 0, row("DEVFAH"))
                nomina_ -= IIf(IsDBNull(row("OTPNOG")), 0, row("OTPNOG"))
                dr("nomina") = nomina_

                'Dim retiro_ As Double = IIf(IsDBNull(row("SANEFA")), 0, row("SANEFA"))
                Dim retiro_ As Double = IIf(IsDBNull(row("DEVFAH")), 0, row("DEVFAH"))
                dr("retiro") = retiro_

                Dim prestamo_ As Double = IIf(IsDBNull(row("OTPNOG")), 0, row("OTPNOG"))
                dr("prestamo") = prestamo_

                Dim monto_ As Double = nomina_ + retiro_ + prestamo_

                dr("monto") = monto_

                If monto_ > 0 Then
                    dtDatos.Rows.Add(dr)

                    Try
                        'sqlExecute("update nomina set per_convenio = '" & _ano & _periodo & "' where reloj = '" & row("reloj") & "' and cod_tipo_nomina = 'F' and ano+periodo = '" & row("ano") & row("periodo") & "' and per_convenio is null", "nomina")
                    Catch ex As Exception

                    End Try

                End If
            Next

            'ABRAHAM CASAS - OCT 2017 PROVISIONAL PARA AGREGAR A FINIQUITOS ADICIONALES CORRESPONIDENTES
            'A SEMANAS ANTERIORES
            'Try
            '    For Each row As DataRow In dtFiniquitosAdicionales.Rows
            '        Dim dr As DataRow = dtDatos.NewRow
            '        dr("reloj") = row("reloj")

            '        dr("procesado") = row("ano") & " - " & row("periodo")


            '        Dim nom As String = row("nombres")
            '        dr("nombres") = nom.ToUpper.Replace("Ñ", "N")

            '        dr("cod_tipo") = row("cod_tipo")
            '        dr("nombre_tipo") = row("nombre_tipoemp")
            '        dr("cod_clase") = row("cod_clase")

            '        Try
            '            dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
            '            dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
            '        Catch ex As Exception

            '        End Try

            '        dr("ano") = _ano
            '        dr("periodo") = _periodo

            '        Dim nomina_ As Double = IIf(IsDBNull(row("NOMINA")), 0, row("NOMINA"))
            '        dr("nomina") = nomina_

            '        Dim retiro_ As Double = IIf(IsDBNull(row("RETIRO")), 0, row("RETIRO"))
            '        dr("retiro") = retiro_

            '        Dim prestamo_ As Double = 0
            '        dr("prestamo") = prestamo_

            '        Dim monto_ As Double = nomina_ + retiro_ + prestamo_

            '        dr("monto") = monto_

            '        If monto_ > 0 Then
            '            dtDatos.Rows.Add(dr)

            '            Try
            '                sqlExecute("update nomina set per_convenio = '" & _ano & _periodo & "' where reloj = '" & row("reloj") & "' and cod_tipo_nomina = 'F' and ano+periodo = '" & row("ano") & row("periodo") & "' and per_convenio is null", "nomina")
            '            Catch ex As Exception

            '            End Try

            '        End If
            '    Next
            'Catch ex As Exception

            'End Try

            '************* 
            nombre_archivo = nombre_archivo.Replace("YYYY", _ano)
            nombre_archivo = nombre_archivo.Replace("XX", _periodo)

            Dim fecha_envio As Date = Now
            Dim dtPeriodo As New DataTable
            If tipo_periodo.Trim = "Q" Then
                dtPeriodo = sqlExecute("select * from periodos_quincenal where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "TA")
            Else
                dtPeriodo = sqlExecute("select * from periodos where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "TA")
            End If

            If dtPeriodo.Rows.Count > 0 Then
                fecha_envio = Date.Parse(dtPeriodo.Rows(0)("fecha_pago"))
            Else
                Exit Sub
            End If

            Dim fecha_limite As Date = fecha_envio

            fecha_limite = fecha_envio.AddDays(14)



            Dim nombre As String = ""
            nombre = "//MD" & encabezado_ref & _periodo
            nombre = nombre.PadRight(20, Space(1))

            Dim encabezado As String = ""
            'encabezado &= "H001242946"
            'encabezado &= FechaSQL(fecha_envio)
            'encabezado &= "01"
            'encabezado &= nombre
            'encabezado &= "00"
            'encabezado &= Space(20)
            'encabezado &= "B"
            'encabezado &= Space(1291)
            Dim total_nuevo As Double = 0
            Dim oWrite As System.IO.StreamWriter
            Try
                encabezado &= "1"  ' Tipo de registro 1
                encabezado &= "000114411220" 'Numero de identificacion del cliente
                encabezado &= fecha_envio.ToString("dd/MM/yyyy").Replace("/", "").Replace("-", "") 'Fecha de pago
                encabezado &= concecutivo 'Secuencia del archivo
                encabezado &= "BRP QUERETARO SA DE CV".PadRight(36, Space(1)) 'Nombre de la empresa
                encabezado &= nombre 'Descripcion(referencia?)
                encabezado &= "09" 'Naturaleza del archivo
                encabezado &= Space(40)
                encabezado &= "B" 'Version del layout
                encabezado &= "0" 'Volumen
                encabezado &= "1" 'Caracteristicas del archivo

                'Dim oWrite As System.IO.StreamWriter
                oWrite = File.CreateText(nombre_archivo)
                oWrite.WriteLine(encabezado)


                For Each irow In dtDatos.Rows
                    total_nuevo += irow("monto")
                Next

                Dim encabezado2 As String = ""
                Dim total1 As String = String.Format("{0:0.00}", total_nuevo).ToString.PadLeft(19, "0").Replace(".", "")

                encabezado2 &= "2" 'Tipo de registro 2
                encabezado2 &= "1" 'Tipo de operacion
                encabezado2 &= "001" 'Clave moneda
                encabezado2 &= total1 'Importe a cargar
                encabezado2 &= "01" 'Tipo de cuenta
                encabezado2 &= "0001" 'Numero de sucursal
                encabezado2 &= "00000000000004369007" 'Numero de cuenta
                encabezado2 &= Space(37)
                oWrite.WriteLine(encabezado2)

                Dim total_empleados As Integer = 0
                Dim total_monto As Double = 0
                For Each row As DataRow In dtDatos.Rows

                    Dim linea As String = ""

                    linea &= "3"
                    linea &= "07"
                    linea &= "0870"
                    linea &= "48" & Space(14)
                    Dim monto As String = String.Format("{0:0.00}", row("monto")).ToString.PadLeft(20, "0")
                    linea &= monto
                    linea &= Space(34)
                    linea &= (RTrim(IIf(IsDBNull(row("nombres")), "", row("nombres"))).ToString & Space(55)).Substring(0, 55).Replace(",", " ").Replace("#", "N")
                    linea &= Space(40)
                    linea &= "0002"
                    linea &= Space(6)
                    linea &= "001"
                    linea &= "1"
                    Dim id_referencia As String = row("CURP")
                    linea &= id_referencia.PadRight(20, " ")
                    linea &= "1" & Space(9)
                    linea &= "2" & Space(9)
                    linea &= fecha_limite.ToString("dd/MM/yyyy").Replace("/", "").Replace("-", "")
                    linea &= Space(13)
                    linea &= "000000000000"
                    linea &= "99"
                    linea &= Space(31)
                    linea &= "0000"

                    total_empleados += 1
                    total_monto += row("monto")
                    oWrite.WriteLine(linea)

                Next

                Dim totales As String = ""
                totales &= "4"
                totales &= "001"
                totales &= total_empleados.ToString.PadLeft(6, "0")
                Dim prueba As Double = String.Format("{0:0.00}", total_monto).ToString.PadLeft(19, "0").Replace(".", "")
                totales &= String.Format("{0:0.00}", total_monto).ToString.PadLeft(19, "0").Replace(".", "")
                totales &= "000001"
                totales &= String.Format("{0:0.00}", total_monto).ToString.PadLeft(19, "0").Replace(".", "")

                oWrite.WriteLine(totales)
                oWrite.Close()


            Catch ex As Exception
                oWrite = Nothing
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub BonosDespensa(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "")
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))

            For Each row As DataRow In dtInformacion.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")
                dr("nombres") = row("nombres")

                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")
                dr("cod_clase") = row("cod_clase")

                Try
                    dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
                    dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                Catch ex As Exception

                End Try

                dr("ano") = _ano
                dr("periodo") = _periodo

                Dim monto_ As Double = IIf(IsDBNull(row("BONDES")), 0, row("BONDES"))

                dr("monto") = monto_

                If monto_ > 0 Then
                    dtDatos.Rows.Add(dr)
                End If
            Next

            If TipoPerSelec.Trim = "C" Then
                nombre_archivo = nombre_archivo & "DESPENSA CAT " & _periodo & ".xlsx"
            Else
                nombre_archivo = nombre_archivo & "DESPENSA SEMANA " & _periodo & ".xlsx"
            End If



            Dim archivo As ExcelPackage = New ExcelPackage()
            Dim wb As ExcelWorkbook = archivo.Workbook

            BonoDespensaWME("DESPENSA", "", wb, dtDatos)
            archivo.SaveAs(New System.IO.FileInfo(nombre_archivo))




        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub BonoDespensaWME(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, dtDatos As DataTable)



        Dim x As Integer = 1
        Dim y As Integer = 1
        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)






        For Each drow As DataRow In dtDatos.Rows

            hoja_excel.Cells(x, y).Value = "6478"
            hoja_excel.Cells(x, y + 1).Value = CInt(drow("reloj")).ToString
            hoja_excel.Cells(x, y + 2).Value = drow("monto")
            hoja_excel.Cells(x, y + 3).Value = "DESPENSA CHIP"

            x = x + 1
        Next





        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

    End Sub


    ''' <summary>
    ''' Pagos electronicos (basado en qro)
    ''' </summary>
    ''' <param name="dtDatos"></param>
    ''' <param name="dtInformacion"></param>
    ''' <param name="nombre_archivo"></param>
    ''' <param name="_ano"></param>
    ''' <param name="_periodo"></param>
    ''' <param name="_inter"></param>
    ''' <param name="consecutivo"></param>
    ''' <param name="cod_comp"></param>
    ''' <param name="payment_day"></param>
    ''' <param name="_nombre_Reporte"></param>
    ''' <remarks></remarks>
    Public Sub PagosElectronicos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable,
                                 Optional nombre_archivo As String = "", Optional _ano As String = "",
                                 Optional _periodo As String = "", Optional _inter As String = "0",
                                 Optional consecutivo As String = "", Optional cod_comp As String = "",
                                 Optional payment_day As String = Nothing, Optional ByVal _nombre_Reporte As String = "")
        Try
            '--- Archivo excel
            Dim archivo As ExcelPackage = New ExcelPackage()
            Dim wb As ExcelWorkbook = archivo.Workbook
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("Deposito bancario")

            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("rfc", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))
            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))
            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cuenta", Type.GetType("System.String"))
            dtDatos.Columns.Add("cla_ban", Type.GetType("System.String"))
            dtDatos.Columns.Add("nomina", Type.GetType("System.Double"))
            dtDatos.Columns.Add("prestamo", Type.GetType("System.Double"))
            dtDatos.Columns.Add("retiro", Type.GetType("System.Double"))
            dtDatos.Columns.Add("pension", Type.GetType("System.Double"))
            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))
            dtDatos.Columns.Add("tipo_reporte", Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo_periodo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_pago", Type.GetType("System.String"))

            dtDatos.Columns.Add("tipo_cuenta", Type.GetType("System.String"))
            dtDatos.Columns.Add("numero_cuenta", Type.GetType("System.String"))
            dtDatos.Columns.Add("descripcion", Type.GetType("System.String"))

            Dim tipo_periodo = ""

            If Not TipoPerSelec Is Nothing Then
                If TipoPerSelec.Trim <> "" Then
                    tipo_periodo = TipoPerSelec.Trim
                    If tipo_periodo = "Q" Then tipo_periodo = "Quincenal" Else If tipo_periodo = "S" Then tipo_periodo = "Semanal"
                End If
            End If

            For Each row As DataRow In dtInformacion.Rows
                If cod_comp.Trim.Count = 0 Then : cod_comp = row("cod_comp") : End If
                Dim dr = dtDatos.NewRow
                dr("reloj") = row("reloj")
                dr("rfc") = row("rfc")
                dr("nombres") = row("nombres").ToUpper.Replace("Ñ", "#")
                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")
                dr("cod_clase") = row("cod_clase")
                dr("tipo_periodo") = row("tipo_periodo")
                dr("cod_pago") = row("cod_pago")

                If Trim(row("tipo_periodo")) = "Q" And tipo_periodo = "" Then : tipo_periodo = "Quincenal"
                ElseIf Trim(row("tipo_periodo")) = "S" And tipo_periodo = "" Then : tipo_periodo = "Semanal" : End If

                Try
                    dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
                    dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                Catch ex As Exception : End Try

                '----2023-08: Si es de la pantalla de bajasxAus mandar el año y periodo de acuerdo a lo que esta en la pantalla

                If _nombre_Reporte = "Pagos electrónicos bajasxaus" Then
                    dr("ano") = row("ano")
                    dr("periodo") = row("periodo")
                Else ' 
                    dr("ano") = _ano
                    dr("periodo") = _periodo
                End If

                dr("cuenta") = row("cuenta")

                If _inter = "1" Then : dr("cla_ban") = row("cuenta").ToString.Substring(0, 3) : Else : dr("cla_ban") = "001" : End If
                Dim nomina_ As Double = IIf(IsDBNull(row("NETO")), 0, row("NETO"))
                dr("nomina") = nomina_

                '---AO: 2023-09
                Dim prestamo_ As Double = 0.0, retiro_ As Double = 0.0, pension_ As Double = 0, monto_ As Double = 0
                Dim deducciones As Double = 0.0, percepciones As Double = 0.0, Query As String = "", _anioPer As String = "", dtPerDedBajasXAus As New DataTable
                Dim TOTPER As Double = 0.0, TOTDED As Double = 0.0

                If _nombre_Reporte = "Pagos electrónicos bajasxaus" Then
                    _anioPer = row("ano").ToString.Trim + row("periodo").ToString.Trim
                    Query = "select * from movimientos where ano+periodo='" & _anioPer & "' and reloj='" & row("reloj").ToString.Trim & "' and concepto in ('NETO','TOTPER','TOTDED')"
                    dtPerDedBajasXAus = sqlExecute(Query, "NOMINA")

                    If Not dtPerDedBajasXAus.Columns.Contains("Error") And dtPerDedBajasXAus.Rows.Count > 0 Then
                        Dim itemsTP = (From x In dtPerDedBajasXAus.Rows Where x("concepto").ToString.Trim = "TOTPER").ToList()
                        If itemsTP.Count > 0 Then Try : TOTPER = (itemsTP.First()("monto")) : Catch ex As Exception : TOTPER = 0.0 : End Try
                        Dim itemTD = (From x In dtPerDedBajasXAus.Rows Where x("concepto").ToString.Trim = "TOTDED").ToList()
                        If itemTD.Count > 0 Then Try : TOTDED = (itemTD.First()("monto")) : Catch ex As Exception : TOTDED = 0.0 : End Try
                    End If

                    '----Agregar planta y motivo de la baja
                    If Not dtDatos.Columns.Contains("planta") Then : dtDatos.Columns.Add("planta", Type.GetType("System.String")) : End If
                    If Not dtDatos.Columns.Contains("motivo") Then : dtDatos.Columns.Add("motivo", Type.GetType("System.String")) : End If
                    Dim planta As String = "", motivo As String = ""
                    Try : planta = row("nombre_planta").ToString.Trim : Catch ex As Exception : planta = "" : End Try
                    motivo = "Renuncia"

                    Dim fbaja As Date, fHoy As Date = Date.Now(), diasTransc As Integer = 0
                    Try : fbaja = Date.Parse(row("baja")) : Catch ex As Exception : fbaja = Date.Now() : End Try
                    diasTransc = DateDiff(DateInterval.Day, fbaja, fHoy) + 1
                    If diasTransc >= 70 Then motivo = "Vencimiento"

                    dr("retiro") = TOTPER
                    dr("prestamo") = TOTDED
                    dr("pension") = pension_
                    monto_ = nomina_
                    dr("monto") = nomina_
                    dr("planta") = planta
                    dr("motivo") = motivo
                Else
                    prestamo_ = 0
                    retiro_ = 0
                    pension_ = 0

                    dr("pension") = pension_
                    dr("prestamo") = prestamo_
                    dr("retiro") = retiro_

                    monto_ = nomina_ + prestamo_ + retiro_ + pension_
                    dr("monto") = monto_
                End If

                Select Case _inter
                    Case "0" : dr("tipo_reporte") = "electrónicos Citibanamex"
                    Case "1" : dr("tipo_reporte") = "electrónicos Interbancarios"
                    Case Else : dr("tipo_reporte") = "en efectivo"
                End Select

                If monto_ > 0 Then : dtDatos.Rows.Add(dr) : End If
            Next

            Dim sql = "SELECT * FROM pensiones_alimenticias WHERE ano = '" & _ano & "' AND periodo = '" & _periodo & "' "
            If {"0", "1"}.Contains(_inter) Then : sql &= "AND inter = '" & _inter & "' and cuenta <> '' "
            Else : sql &= "AND cuenta = '' " : End If
            Dim dtPensiones = sqlExecute(sql, "nomina")

            For Each row As DataRow In dtPensiones.Rows
                Dim dr = dtDatos.NewRow
                dr("reloj") = row("reloj")
                dr("rfc") = ""
                dr("nombres") = row("nombre")
                dr("cod_tipo") = "PX"
                dr("nombre_tipo") = "PENSIONES"
                dr("cod_clase") = "n/a"
                dr("alta") = "-"
                dr("baja") = "-"
                dr("ano") = row("ano")
                dr("periodo") = row("periodo")
                dr("cuenta") = row("cuenta")

                If _inter = "1" Then : dr("cla_ban") = row("cuenta").ToString.Substring(0, 3) : Else : dr("cla_ban") = "001" : End If

                dr("nomina") = 0
                dr("prestamo") = 0
                dr("retiro") = 0

                Dim pension_ As Double = IIf(IsDBNull(row("monto")), 0, row("monto"))
                dr("pension") = pension_

                Dim monto_ As Double = pension_
                dr("monto") = monto_

                If monto_ > 0 Then : dtDatos.Rows.Add(dr) : End If
            Next

            'Obtener numero de cliente y cuenta para deposito banamex de cias
            Dim numcliente = ""
            Dim numcuenta = ""
            Dim datosbank = sqlExecute("SELECT * FROM cias WHERE cod_comp = '" & cod_comp & "'")

            If datosbank.Rows.Count > 0 Then
                numcliente = datosbank.Rows(0).Item("num_cliente").ToString.Trim
                numcuenta = datosbank.Rows(0).Item("num_cuenta").ToString.Trim
            End If

            If consecutivo.Count = 0 Then
                If nombre_archivo.Contains("C1") Then : consecutivo = "50" : nombre_archivo = nombre_archivo.Replace("C1", "")
                ElseIf nombre_archivo.Contains("C2") Then : consecutivo = "51" : nombre_archivo = nombre_archivo.Replace("C2", "")
                ElseIf nombre_archivo.Contains("C3") Then : consecutivo = "52" : nombre_archivo = nombre_archivo.Replace("C3", "")
                ElseIf tipo_periodo = "Quincenal" Then
                    consecutivo = IIf(Convert.ToInt32(_inter) = 1, IIf(cod_comp = "610", "41", "81"), IIf(cod_comp = "610", "40", "80"))                    'If Convert.ToInt32(_inter) = 1 Then : consecutivo = IIf(cod_comp = "610", "41", "81") : Else : consecutivo = IIf(cod_comp = "610", "40", "80") : End If
                Else
                    consecutivo = "01"
                End If
            End If

            Dim fecha_pago As Date
            Dim ano_pago = ""
            Dim mes_pago = ""
            Dim dtfechapago As New DataTable
            Dim tipo_pago = "01"

            If Not payment_day Is Nothing Then
                fecha_pago = Convert.ToDateTime(payment_day)
            ElseIf {"50", "51", "52"}.Contains(consecutivo) Then
                frmSeleccionarFecha.ShowDialog()
                fecha_pago = FechaInicial
            Else
                Dim table = "periodos"
                If tipo_periodo = "Quincenal" Then : table = "periodos_quincenal" : End If
                dtfechapago = sqlExecute("SELECT * FROM " & table & " WHERE ano = '" & _ano & "' AND periodo = '" & _periodo & "'", "TA")
                fecha_pago = dtfechapago.Rows(0).Item("fecha_pago")
            End If

            ano_pago = fecha_pago.Year.ToString.Substring(2, 2)
            mes_pago = fecha_pago.Month.ToString.PadLeft(2, "0")

            If _inter = "0" Or _inter = "1" Then
                Try
                    Dim Total As Double = 0
                    Dim Abonos = 0
                    Dim Creditos = 1
                    Dim dtRegistrosArchivo As New DataTable
                    Dim empresa = datosbank.Rows(0)("rep_legal").ToString.Trim
                    Dim descripcion = ("NOMINA" & " " & fecha_pago.ToString("dd") & " " & fecha_pago.ToString("MM") & " " & fecha_pago.ToString("yyyy"))

                    '-- Informacion de cabecera primer renglon
                    Dim strTipoRegistro = "1" '-- Siempre es uno. Longitud 1
                    Dim strIdentificacionCliente = Trim(numcliente).PadLeft(12, "0") '-- Número de contrato. Longitud 12. Completar con ceros a la izquierda
                    Dim strFhaPago = fecha_pago.ToString("ddMMyy") '-- Fecha pago. Longitud 6. ddmmaa
                    Dim strSecuencialArchivo = "0001" '-- Secuencial de archivo. Longitud 4.
                    Dim strNombreEmpresa = empresa.PadRight(36, Space(36 - empresa.Length)) '-- Razon social de la empresa. Longitud 36. Completar con espacios en blanco a la derecha
                    Dim strDescArchivo = descripcion.PadRight(20, Space(20 - descripcion.Length)) '-- Descripcion de tipo de pago. Longitud 20. Completar con espacios en blanco a la derecha
                    Dim strNaturalezaArchivo = "05" '-- La naturaleza 05 de pago de nomina. Longitud 2
                    Dim strInstrucOrdenesPago = Space(40) '-- Instrucciones para orden de pago. Longitud 40. Opcional se llena en blanco
                    Dim strVersionLayout = "C" '-- Version de layout. Longitud 1. Siempre es C
                    Dim strVolumen = "0" '-- Constante. Longitud 1. Siempre es 0
                    Dim strCaracteriscasArchivo = "0" '-- Si es modificado o solo lectura. Logitud 1.

                    Dim Header1 = "select '" & strTipoRegistro & strIdentificacionCliente & strFhaPago & strSecuencialArchivo &
                                  strNombreEmpresa & strDescArchivo & strNaturalezaArchivo & strInstrucOrdenesPago &
                                  strVersionLayout & strVolumen & strCaracteriscasArchivo & "'"

                    '-- Archivo excel
                    hoja_excel.Cells(1, 1).Value = strTipoRegistro
                    hoja_excel.Cells(1, 2).Value = strIdentificacionCliente
                    hoja_excel.Cells(1, 3).Value = strFhaPago
                    hoja_excel.Cells(1, 4).Value = strSecuencialArchivo
                    hoja_excel.Cells(1, 5).Value = strNombreEmpresa
                    hoja_excel.Cells(1, 6).Value = strDescArchivo
                    hoja_excel.Cells(1, 7).Value = strNaturalezaArchivo
                    hoja_excel.Cells(1, 8).Value = strInstrucOrdenesPago
                    hoja_excel.Cells(1, 9).Value = strVersionLayout
                    hoja_excel.Cells(1, 10).Value = strVolumen
                    hoja_excel.Cells(1, 11).Value = strCaracteriscasArchivo

                    Debug.Print(Header1)
                    dtRegistrosArchivo = sqlExecute(Header1, "Nomina")

                    If _inter = "0" Then
                        For Each r As DataRow In dtDatos.Select("cod_pago = 'B'")
                            Total = Total + r.Item("monto")
                            Abonos = Abonos + 1
                        Next
                    Else
                        For Each r As DataRow In dtDatos.Select("cod_pago = 'D'")
                            Total = Total + r.Item("monto")
                            Abonos = Abonos + 1
                        Next
                    End If

                    Dim strTipoReg = "2" '-- Constante. Longitud 1. Siempre es 2
                    Dim strClaveOperacion = "1" '-- Si es abono o cargo. Longitud 1. Es cargo
                    Dim strClaveMoneda = "001" '-- Constante y siempre es 001. Longitud 3
                    Dim strImporte = FormatNumber(Total, 2).Replace(",", "").Replace(".", "").PadLeft(18, "0") '-- Justificado a la derecha, no lleva decimal. Longitud 18.
                    Dim strTipoCta = "01" '-- Constante cheques. Longitud 2. 
                    Dim strNumSucursal = numcuenta.Substring(0, 3).PadLeft(4, "0") '-- Clave de sucursal, justificar a la derecha, completa con 0. Longitud 4
                    Dim strNumeroCuenta = numcuenta.Substring(3, numcuenta.Length - 3).PadLeft(20, "0") '-- Numero de cuenta de cargo, justificar a la derecha, completa con 0. Longitud 20
                    Dim strEspacioBlanco = Space(20) '-- Espacios en blanco. Longitud 20


                    Dim Header2 = "select '" & strTipoReg & strClaveOperacion & strClaveMoneda & strImporte & strTipoCta & strNumSucursal & strNumeroCuenta &
                                  strEspacioBlanco & "'"

                    Debug.Print(Header2)
                    dtRegistrosArchivo.Merge(sqlExecute(Header2, "Nomina"))

                    '-- Archivo excel
                    hoja_excel.Cells(2, 1).Value = strTipoReg
                    hoja_excel.Cells(2, 2).Value = strClaveOperacion
                    hoja_excel.Cells(2, 3).Value = strClaveMoneda
                    hoja_excel.Cells(2, 4).Value = strImporte
                    hoja_excel.Cells(2, 5).Value = strTipoCta
                    hoja_excel.Cells(2, 6).Value = strNumSucursal
                    hoja_excel.Cells(2, 7).Value = strNumeroCuenta
                    hoja_excel.Cells(2, 8).Value = strEspacioBlanco

                    Dim nombre = ""
                    Dim x = 3

                    If _inter = "0" Then

                        For Each r As DataRow In dtDatos.Select("cod_pago = 'B'")

                            If r.Item("cod_tipo") = "PX" Then
                                nombre = r.Item("nombres").ToString.Replace("0", "").Replace("#", "N").Replace(".", "").Replace("ñ", "@").Replace("'", "").Replace("Ñ", "@").Trim
                                tipo_pago = "54"
                            Else
                                nombre = r.Item("NOMBRES").ToString().Replace(".", "").Replace("'", "").Replace("#", "N").Replace("ñ", "@").Replace("Ñ", "@").Trim.Split(",")(2) +
                                    "," + r.Item("NOMBRES").ToString().Replace(".", "").Replace("#", "N").Replace("ñ", "@").Replace("Ñ", "@").Trim.Split(",")(0) +
                                    "/" + r.Item("NOMBRES").ToString().Replace(".", "").Replace("ñ", "@").Replace("#", "N").Replace("Ñ", "@").Trim.Split(",")(1)
                                tipo_pago = "01"
                            End If

                            Dim strMonto = CInt(If(IsDBNull(r.Item("monto")), 0, r.Item("monto") * 100)).ToString
                            Dim strCuenta = r.Item("CUENTA").ToString.Trim

                            strTipoReg = "3" '-- Tipo registro. Longitud 1
                            strClaveOperacion = "0" '-- Si es cargo o abono. Longitud 1
                            strClaveMoneda = "001" '-- Tipo moneda. Longitud 3
                            strImporte = strMonto.PadLeft(18, "0") '-- Importe a abonar o cargar. Longitud 18
                            strTipoCta = If(strCuenta.Length > 11, "03", "01") '-- Tipo de cuenta. Longitud 2
                            strNumeroCuenta = strCuenta '-- Numero de cuenta de abono. Longitud 20

                            If strTipoCta = "01" Then
                                If strCuenta.Length < 11 Then
                                    Dim strSuc = strCuenta.Substring(0, 4)
                                    Dim strCuentaSuc = strCuenta.Substring(4, strCuenta.Length - strSuc.Length)
                                    Dim strCeros = "".ToString.PadLeft(11 - strCuenta.Length, "0")
                                    strNumeroCuenta = strSuc & strCeros & strCuentaSuc
                                End If
                            End If

                            strNumeroCuenta = strNumeroCuenta.PadLeft(20, "0")
                            Dim strReferenciaOp = "0000000001".PadRight(40, Space(40 - "0000000001".Length))
                            Dim strBeneficiario = nombre.PadRight(55, Space(55 - nombre.Length))
                            Dim strCampoDesconocido = "WK " & _periodo.PadLeft(2, "0") & "                                                           0000000000100"

                            Dim Details = "select '" & strTipoReg & strClaveOperacion & strClaveMoneda & strImporte &
                                          strTipoCta & strNumeroCuenta & strReferenciaOp & strBeneficiario & strCampoDesconocido & "'"

                            '-- Archivo excel
                            hoja_excel.Cells(x, 1).Value = strTipoReg
                            hoja_excel.Cells(x, 2).Value = strClaveOperacion
                            hoja_excel.Cells(x, 3).Value = strClaveMoneda
                            hoja_excel.Cells(x, 4).Value = strImporte
                            hoja_excel.Cells(x, 5).Value = strTipoCta
                            hoja_excel.Cells(x, 6).Value = strNumeroCuenta
                            hoja_excel.Cells(x, 7).Value = strReferenciaOp
                            hoja_excel.Cells(x, 8).Value = strBeneficiario
                            hoja_excel.Cells(x, 9).Value = strCampoDesconocido
                            x += 1


                            'dtDatos.Columns.Add("tipo_cuenta", Type.GetType("System.String"))
                            'dtDatos.Columns.Add("numero_cuenta", Type.GetType("System.String"))
                            'dtDatos.Columns.Add("descripcion", Type.GetType("System.String"))
                            r("tipo_cuenta") = strTipoCta
                            r("numero_cuenta") = strCuenta
                            r("descripcion") = "WK " & _periodo.PadLeft(2, "0")

                            Debug.Print(Details)
                            dtRegistrosArchivo.Merge(sqlExecute(Details, "Nomina"))
                        Next
                    End If

                    strTipoReg = "4" '-- Tipo registro. Longitud 1
                    strClaveMoneda = "001" '-- Tipo moneda. Longitud 3
                    Dim strNumAbonos = Abonos.ToString.PadLeft(6, "0") '-- Número total de abonos del archivo. Longitud 6
                    Dim strTotalAbonos = FormatNumber(Total, 2).Replace(",", "").Replace(".", "").PadLeft(18, "0") '-- Sumatoria de los abonos. Longitud 18
                    Dim strNumCargos = Creditos.ToString.Replace(".", "").PadLeft(6, "0") '-- Número de cargos del archivo. Longitud 6
                    Dim strSumCargos = FormatNumber(Total, 2).Replace(",", "").Replace(".", "").PadLeft(18, "0")  '-- Sumatoria de los cargos. Longitud 18

                    Dim Footer = "select '" & strTipoReg & strClaveMoneda & strNumAbonos & strTotalAbonos & strNumCargos & strSumCargos & "'"

                    Debug.Print(Footer)
                    dtRegistrosArchivo.Merge(sqlExecute(Footer, "Nomina"))

                    '-- Archivo excel
                    hoja_excel.Cells(x, 1).Value = strTipoReg
                    hoja_excel.Cells(x, 2).Value = strClaveMoneda
                    hoja_excel.Cells(x, 3).Value = strNumAbonos
                    hoja_excel.Cells(x, 4).Value = strTotalAbonos
                    hoja_excel.Cells(x, 5).Value = strNumCargos
                    hoja_excel.Cells(x, 6).Value = strSumCargos

                    nombre_archivo = nombre_archivo & "SEM " & _periodo & "-" & _ano & ".txt"

                    Dim Writer = File.CreateText(nombre_archivo)
                    Writer.Close()

                    '-- Guardar archivo excel
                    hoja_excel.SelectedRange("A4:K" & x.ToString & "").AutoFitColumns()
                    archivo.SaveAs(New System.IO.FileInfo(nombre_archivo.Replace("txt", "xlsx")))

                    For Each dr As DataRow In dtRegistrosArchivo.Rows
                        Writer = File.AppendText(nombre_archivo)
                        Dim t As String = dr.Item(0).ToString()
                        t.Replace(".", " ")
                        Writer.WriteLine(t)
                        Writer.Flush()
                        Writer.Close()
                        Debug.Print(dr.Item(0))
                    Next
                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
                End Try
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

        If dtDatos.Rows.Count = 0 Then
            Dim dr = dtDatos.NewRow
            dr("reloj") = ""
            dr("rfc") = ""
            dr("nombres") = ""
            dr("cod_tipo") = ""
            dr("nombre_tipo") = ""
            dr("cod_clase") = "'"
            dr("alta") = ""
            dr("baja") = ""
            dr("ano") = ""
            dr("periodo") = ""
            dr("cuenta") = ""
            dr("cla_ban") = ""
            dr("nomina") = 0
            dr("prestamo") = 0
            dr("retiro") = 0
            dr("pension") = 0
            dr("monto") = 0

            Select Case _inter
                Case "0" : dr("tipo_reporte") = "electrónicos Citibanamex"
                Case "0" : dr("tipo_reporte") = "electrónicos Interbancarios"
                Case Else : dr("tipo_reporte") = "en efectivo"
            End Select

            dtDatos.Rows.Add(dr)
        End If
    End Sub

    Public Sub CaratulaGeneral(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim Ano As String
        Dim Per As String
        Dim dtPer As New DataTable
        Dim FechaFin As Date

        Try
            Ano = dtInformacion.Rows(0).Item("ano")
            Per = dtInformacion.Rows(0).Item("periodo")

            'Obtener la fecha final del periodo
            'Todas las provisiones de aguinaldo se considerarán al periodo del primer registro
            dtPer = sqlExecute("SELECT fecha_fin FROM periodos WHERE ano = '" & Ano & "' AND periodo = '" & Per & "'", "ta")
            FechaFin = dtPer.Rows(0).Item("fecha_fin")

            dtDatos = dtInformacion.Copy
            dtDatos.Columns.Add("ESTADO", GetType(System.String))
            dtDatos.Columns.Add("COMPENSA", GetType(System.Double))
            dtDatos.Columns.Add("ABOISPT", GetType(System.Double))
            'dtDatos.Columns.Add("DESEFE", GetType(System.Double))
            dtDatos.Columns.Add("DESDEP", GetType(System.Double))
            dtDatos.Columns.Add("EMPSIN", GetType(System.Double))
            dtDatos.Columns.Add("EMPEFE", GetType(System.Double))
            dtDatos.Columns.Add("EMPDEP", GetType(System.Double))
            dtDatos.Columns.Add("NETEFE", GetType(System.Double))
            dtDatos.Columns.Add("NETDEP", GetType(System.Double))
            dtDatos.Columns.Add("EXCEDE", GetType(System.Double))

            For Each dR As DataRow In dtDatos.Rows
                For Each dC As DataColumn In dtDatos.Columns
                    If dC.DataType Is GetType(System.Double) Then
                        dR(dC.ColumnName) = IIf(IsDBNull(dR(dC.ColumnName)), 0, dR(dC.ColumnName))
                    End If
                Next
                'dR("ESTADO") = IIf(IsDBNull(dR("BAJA")), "ACTIVOS", "BAJAS")

                If IsDBNull(dR("baja")) Then
                    dR("ESTADO") = "ACTIVOS"
                Else
                    dR("ESTADO") = IIf(dR("baja") > FechaFin, "ACTIVOS", "BAJAS")
                End If


            Next
            Dim Borrar As DataRow()
            Borrar = dtDatos.Select("baja is not null and totper = 0 and bondes = 0")
            For Each bR As DataRow In Borrar
                dtDatos.Rows.Remove(bR)
            Next
            dtDatos.Select("", "ESTADO,COD_CLASE,RELOJ")

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub DesgloseExcel(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            dtDatos = dtInformacion.Copy
            Dim _ano As String = dtDatos.Rows(0)("ano")
            Dim _periodo As String = dtDatos.Rows(0)("periodo")

            Dim dtDesglose As DataTable = sqlExecute("select concepto from conceptos where desglose > 0 order by desglose asc", "nomina")

            Dim dtExcel As New DataTable
            dtExcel.Columns.Add("reloj")
            dtExcel.Columns.Add("cod_tipo")
            dtExcel.Columns.Add("nombres")
            dtExcel.Columns.Add("liq")


            For Each row As DataRow In dtDesglose.Rows

                Dim concepto_desglose As String = RTrim(row("concepto"))

                For Each column As DataColumn In dtDatos.Columns
                    If concepto_desglose = column.ColumnName Then
                        dtExcel.Columns.Add(column.ColumnName)
                    End If
                Next
            Next

            Dim drHeaders As DataRow = dtExcel.NewRow
            drHeaders("reloj") = "N.EMP"
            drHeaders("cod_tipo") = "T-E"
            drHeaders("nombres") = "BRP - SEM " & _periodo & "/" & _ano
            drHeaders("liq") = "LIQ"

            Dim contador As Integer = 0
            For Each column As DataColumn In dtExcel.Columns
                contador += 1
                If contador > 4 Then
                    drHeaders(column.ColumnName) = column.ColumnName
                End If
            Next
            dtExcel.Rows.Add(drHeaders)

            For Each row As DataRow In dtDatos.Rows
                dtExcel.ImportRow(row)
            Next

            Dim sfd As New SaveFileDialog
            sfd.FileName = "Desglose de nómina " & _ano & _periodo & ".xlsx"
            If sfd.ShowDialog = DialogResult.OK Then
                ExportaExcel(dtExcel, sfd.FileName, "reloj", "", True)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub SaldosDescuentos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional clave As String = "")
        Try
            dtDatos = New DataTable

            If MessageBox.Show("Prueba", "titulo prueba", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ' ---- codigo
            End If

            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("cod_tipo")
            dtDatos.Columns.Add("cod_planta")

            dtDatos.Columns.Add("clave")
            dtDatos.Columns.Add("concepto")

            dtDatos.Columns.Add("prestamo", GetType(System.Double))
            dtDatos.Columns.Add("abono", GetType(System.Double))
            dtDatos.Columns.Add("descuento_real", GetType(System.Double))
            dtDatos.Columns.Add("saldo_actual", GetType(System.Double))
            dtDatos.Columns.Add("saldo_anterior", GetType(System.Double))
            dtDatos.Columns.Add("semanas_restan", GetType(System.Double))
            dtDatos.Columns.Add("observaciones")

            Dim dtSaldos As New DataTable

            If clave <> "" Then
                dtSaldos = sqlExecute("select * from saldos_descuento where clave = '" & clave & "'", "nomina")
            Else
                dtSaldos = sqlExecute("select * from saldos_descuento", "nomina")
            End If

            For Each row As DataRow In dtSaldos.Rows

                Dim _cv As String = Trim(row("clave"))
                Dim _descripcion As String = Trim(row("concepto"))

                Dim _prestamo As String = Trim(row("prestamo"))
                Dim _abono As String = Trim(row("abono"))
                Dim _descuento As String = Trim(row("descuento"))
                Dim _saldo As String = Trim(row("saldo"))
                Dim _semanas As String = Trim(row("pagpen"))

                For Each erow As DataRow In dtInformacion.Select(_saldo & " > 0 or " & _descuento & " > 0")

                    Dim drow As DataRow = dtDatos.NewRow

                    drow("reloj") = erow("reloj")
                    drow("nombres") = erow("nombres")
                    drow("cod_tipo") = erow("cod_tipo")
                    drow("cod_planta") = erow("cod_planta")

                    drow("clave") = _cv
                    drow("concepto") = _descripcion

                    drow("prestamo") = IIf(IsDBNull(erow(_prestamo)), 0, erow(_prestamo))
                    drow("abono") = IIf(IsDBNull(erow(_abono)), 0, erow(_abono))
                    drow("descuento_real") = IIf(IsDBNull(erow(_descuento)), 0, erow(_descuento))
                    drow("saldo_actual") = IIf(IsDBNull(erow(_saldo)), 0, erow(_saldo))
                    drow("semanas_restan") = IIf(IsDBNull(erow(_semanas)), 0, erow(_semanas))

                    drow("saldo_anterior") = IIf(IsDBNull(erow(_saldo)), 0, erow(_saldo)) + IIf(IsDBNull(erow(_descuento)), 0, erow(_descuento))

                    drow("observaciones") = IIf((IIf(IsDBNull(erow("neto")), 0, erow("neto")) = 0), "No tiene neto", IIf((IIf(IsDBNull(erow(_descuento)), 0, erow(_descuento)) = 0 Or IIf(IsDBNull(erow(_abono)), 0, erow(_abono)) = 0), "No tiene abono", ""))

                    dtDatos.Rows.Add(drow)
                Next

            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)

        End Try

    End Sub
    Public Sub ResumenTotComedores(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("servicio", GetType(System.String))
            dtDatos.Columns.Add("ConSub", GetType(System.Double))
            dtDatos.Columns.Add("SinSub", GetType(System.Double))
            dtDatos.Columns.Add("DesRep", GetType(System.Double))

            '--Obtener fechas de incidencia en base al periodo
            Dim dtFechasIniFin As DataTable = sqlExecute("SELECT top 1 * from periodos_quincenal where ANO='" & AnoSelec & "' and periodo='" & PeriodoSelec & "'  and PERIODO_ESPECIAL=0 order by periodo desc", "TA")
            Dim FIniInci As String = ""
            Dim FFinInci As String = ""
            If (Not dtFechasIniFin.Columns.Contains("Error") And dtFechasIniFin.Rows.Count > 0) Then
                FIniInci = IIf(IsDBNull(dtFechasIniFin.Rows(0).Item("fecha_ini_incidencia")), "", dtFechasIniFin.Rows(0).Item("fecha_ini_incidencia"))
                FFinInci = IIf(IsDBNull(dtFechasIniFin.Rows(0).Item("fecha_fin_incidencia")), "", dtFechasIniFin.Rows(0).Item("fecha_fin_incidencia"))
            End If

            Dim QTC As String = "select fecha,subsidio,count(reloj)as Total from hrs_brt_cafeteria where fecha between  '" & FechaSQL(FIniInci) & "' and '" & FechaSQL(FFinInci) & "' and subsidio in ('C','S','Z') and " & _
                "reloj in (select reloj from personal.dbo.personal where cod_tipo<>'O' and ISNULL(inactivo,0)=0 and cod_comp='610') group by fecha,subsidio order by fecha"
            Dim dtTotComedores As DataTable = sqlExecute(QTC, "TA")
            If (Not dtTotComedores.Columns.Contains("Error") And dtTotComedores.Rows.Count > 0) Then
                Dim F1 As Date = Convert.ToDateTime(FechaSQL(FIniInci))
                Dim F2 As Date = Convert.ToDateTime(FechaSQL(FFinInci))
                While F1 <= F2
                    Dim TotC As Double = 0
                    Dim TotS As Double = 0
                    Dim TotZ As Double = 0

                    Dim drowC As DataRow = Nothing
                    Try
                        drowC = dtTotComedores.Select("fecha='" & FechaSQL(F1) & "' AND subsidio='C'")(0)
                    Catch ex As Exception
                    End Try

                    Dim drowS As DataRow = Nothing
                    Try
                        drowS = dtTotComedores.Select("fecha='" & FechaSQL(F1) & "' AND subsidio='S'")(0)
                    Catch ex As Exception
                    End Try

                    Dim drowZ As DataRow = Nothing
                    Try
                        drowZ = dtTotComedores.Select("fecha='" & FechaSQL(F1) & "' AND subsidio='Z'")(0)
                    Catch ex As Exception
                    End Try

                    If Not IsNothing(drowC) Then TotC = drowC("Total")
                    If Not IsNothing(drowS) Then TotS = drowS("Total")
                    If Not IsNothing(drowZ) Then TotZ = drowZ("Total")

                    If (TotC > 0 Or TotS > 0 Or TotZ > 0) Then
                        Dim drow As DataRow = dtDatos.NewRow
                        drow("servicio") = FechaSQL(F1)
                        drow("ConSub") = TotC
                        drow("SinSub") = TotS
                        drow("DesRep") = TotZ

                        dtDatos.Rows.Add(drow)
                    End If

                    F1 = F1.AddDays(1)
                End While

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub ExcelPoliza(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, dtDatos As DataTable)


        Dim dtcuentas_per As DataTable = sqlExecute("select * from cuentas where DEBE_HABER = 'D' and concepto <> 'BONDES' order by prioridad asc", "NOMINA")
        Dim dtcuentas_desc As DataTable = sqlExecute("select * from cuentas where DEBE_HABER = 'H' order by prioridad asc", "NOMINA")
        Dim dtcuentas_bono As DataTable = sqlExecute("select * from cuentas where concepto = 'BONDES'", "NOMINA")

        Dim dtCostos As DataTable = sqlExecute("select centro_costos from c_costos")

        Dim _ano As String = dtDatos.Rows(0).Item("ano")
        Dim _periodo As String = dtDatos.Rows(0).Item("periodo")
        Dim _tipo_periodo As String = dtDatos.Rows(0).Item("tipo_periodo")

        Dim total As Double = 0
        Dim total_bono As Double = 0
        Dim x As Integer = 1
        Dim y As Integer = 1
        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

        hoja_excel.Cells(x, y).Value = ""
        hoja_excel.Cells(x, y).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 1).Value = "CUENTA"
        hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 4).Value = "MONTO"
        hoja_excel.Cells(x, y + 4).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 6).Value = "SUBCUENTA"
        hoja_excel.Cells(x, y + 6).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 7).Value = "DESC"
        hoja_excel.Cells(x, y + 7).Style.Font.Bold = True


        '-----BONDES
        hoja_excel.Cells(x, y + 12).Value = "CUENTA"
        hoja_excel.Cells(x, y + 12).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 14).Value = "MONTO"
        hoja_excel.Cells(x, y + 14).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 16).Value = "SUBCUENTA"
        hoja_excel.Cells(x, y + 16).Style.Font.Bold = True

        hoja_excel.Cells(x, y + 17).Value = "DESC"
        hoja_excel.Cells(x, y + 17).Style.Font.Bold = True


        x = x + 1

        For Each drow As DataRow In dtcuentas_per.Rows
            For Each dc As DataRow In dtcostos.rows
                Dim dtpersonal As DataTable = sqlExecute("select concepto, sum(monto) as total from movimientos where ano = '" & _ano & "' and PERIODO = '" & _periodo & "' and " & _
                                                  "tipo_periodo = '" & _tipo_periodo & "' and CONCEPTO = '" & drow("CONCEPTO") & "' and reloj in (select reloj " & _
                                                  "from PERSONAL.dbo.personal where " & drow("CONDICION") & " and cod_costos = '" & dc("centro_costos") & "') group by CONCEPTO", "NOMINA")

                If dtpersonal.Rows.Count > 0 Then
                    x = x + 1
                    total = total + dtpersonal.Rows(0).Item("total")
                    hoja_excel.Cells(x, y + 1).Value = drow("CUENTA")
                    hoja_excel.Cells(x, y + 4).Value = dtpersonal.Rows(0).Item("total")
                    hoja_excel.Cells(x, y + 6).Value = dc("centro_costos")
                    hoja_excel.Cells(x, y + 7).Value = "NOMINA " & IIf(_tipo_periodo = "C", "CAT", "SEM") & " " & _periodo & " " & _ano

                End If
            Next
        Next

        For Each drow2 As DataRow In dtcuentas_desc.Rows

            Dim dtpersonal As DataTable = sqlExecute("select concepto, sum(monto) as total from movimientos where ano = '" & _ano & "' and PERIODO = '" & _periodo & "' and " & _
                                              "tipo_periodo = '" & _tipo_periodo & "' and CONCEPTO = '" & drow2("CONCEPTO") & "' and reloj in (select reloj " & _
                                              "from PERSONAL.dbo.personal where " & drow2("CONDICION") & ") group by CONCEPTO", "NOMINA")

            If dtpersonal.Rows.Count > 0 Then
                x = x + 1
                total = total - dtpersonal.Rows(0).Item("total")
                hoja_excel.Cells(x, y).Value = drow2("nombre_cta")
                hoja_excel.Cells(x, y + 1).Value = drow2("CUENTA")
                hoja_excel.Cells(x, y + 4).Value = dtpersonal.Rows(0).Item("total")
                hoja_excel.Cells(x, y + 7).Value = "NOMINA " & IIf(_tipo_periodo = "C", "CAT", "SEM") & " " & _periodo & " " & _ano

            End If

        Next

        hoja_excel.Cells(x + 1, y + 4).Value = total

        x = 2
        For Each drow As DataRow In dtcuentas_bono.Rows
            For Each dc As DataRow In dtCostos.Rows
                Dim dtpersonal As DataTable = sqlExecute("select concepto, sum(monto) as total from movimientos where ano = '" & _ano & "' and PERIODO = '" & _periodo & "' and " & _
                                                  "tipo_periodo = '" & _tipo_periodo & "' and CONCEPTO = '" & drow("CONCEPTO") & "' and reloj in (select reloj " & _
                                                  "from PERSONAL.dbo.personal where " & drow("CONDICION") & " and cod_costos = '" & dc("centro_costos") & "') group by CONCEPTO", "NOMINA")

                If dtpersonal.Rows.Count > 0 Then
                    x = x + 1
                    total = total + dtpersonal.Rows(0).Item("total")
                    hoja_excel.Cells(x, y + 12).Value = drow("CUENTA")
                    hoja_excel.Cells(x, y + 14).Value = dtpersonal.Rows(0).Item("total")
                    hoja_excel.Cells(x, y + 16).Value = dc("centro_costos")
                    hoja_excel.Cells(x, y + 17).Value = "VALES DE DESPENSA " & IIf(_tipo_periodo = "C", "CAT", "SEM") & " " & _periodo & " " & _ano

                End If
            Next
        Next

        hoja_excel.Cells(x + 1, y + 14).Value = total




        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

    End Sub

    Public Sub ReportePoliza(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "", Optional _inter As String = "0")

        If nombre_archivo = "" Then

            Dim sfd As New SaveFileDialog

            sfd.OverwritePrompt = True
            sfd.Title = "Guardar en"
            sfd.FileName = "Reporte de Poliza"
            sfd.DefaultExt = ".xlsx"
            sfd.Filter = "Excel (*.xlsx)|*.xlsx"

            If sfd.ShowDialog() = DialogResult.OK Then

                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                ExcelPoliza("Poliza", "", wb, dtInformacion)
                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
                MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)



            End If

        Else
            'Dim archivo As ExcelPackage = New ExcelPackage()
            'Dim wb As ExcelWorkbook = archivo.Workbook

            'ExcelPoliza("Poliza", "", wb, dtInformacion)
            'archivo.SaveAs(New System.IO.FileInfo(nombre_archivo))
            'MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        End If


        dtDatos.Columns.Add("cat")
        dtDatos.Columns.Add("depto")
        dtDatos.Columns.Add("reloj")
        dtDatos.Columns.Add("nombre")
        dtDatos.Columns.Add("suedia", GetType(System.Double))
        dtDatos.Columns.Add("tothrs", GetType(System.Double))
        dtDatos.Columns.Add("cencos")

        'dtDatos.Columns.Add("cuenor", GetType(System.Double))
        dtDatos.Columns.Add("hrsnor", GetType(System.Double))
        dtDatos.Columns.Add("pernor", GetType(System.Double))
        'dtDatos.Columns.Add("cueext", GetType(System.Double))
        dtDatos.Columns.Add("hrsext", GetType(System.Double))
        dtDatos.Columns.Add("perext", GetType(System.Double))


        For Each dR As DataRow In dtInformacion.Rows
            dR("cod_clase") = IIf(IsDBNull(dR("cod_clase")), "", dR("cod_clase"))
            dR("cod_depto") = IIf(IsDBNull(dR("cod_depto")), "", dR("cod_depto"))
            dR("nombres") = IIf(IsDBNull(dR("nombres")), "", dR("nombres"))
            dR("sactual") = IIf(IsDBNull(dR("sactual")), 0, dR("sactual"))
            dR("cod_costos") = IIf(IsDBNull(dR("cod_costos")), "", dR("cod_costos"))
            dR("hrsnor") = IIf(IsDBNull(dR("hrsnor")), 0, dR("hrsnor"))
            dR("pernor") = IIf(IsDBNull(dR("pernor")), 0, dR("pernor"))
            dR("hrsex2") = IIf(IsDBNull(dR("hrsex2")), 0, dR("hrsex2"))
            dR("hrsex3") = IIf(IsDBNull(dR("hrsex3")), 0, dR("hrsex3"))

            dR("perex2") = IIf(IsDBNull(dR("perex2")), 0, dR("perex2"))
            dR("perex3") = IIf(IsDBNull(dR("perex3")), 0, dR("perex3"))

            'If dR("cod_clase") = "D" Then
            '    dR("cod_clase") = "0"
            'ElseIf dR("cod_clase") = "I" Then
            '    dR("cod_clase") = "1"
            'ElseIf dR("cod_clase") = "A" Or dR("cod_clase") = "G" Then
            '    dR("cod_clase") = "3"

            'End If

            dtDatos.Rows.Add({dR("cod_clase"), _
                              dR("cod_depto"), _
                              dR("reloj"), _
                              Trim(dR("nombres")), _
                              dR("sactual"), _
                              dR("hrsnor") + dR("hrsex2") + dR("hrsex3"), _
                              dR("cod_costos"), _
                              dR("hrsnor"), _
                              dR("pernor"), _
                              dR("hrsex2") + dR("hrsex3"), _
                              (dR("perex2") + dR("perex3")) - (dR("perex2") / 2)
                             })
        Next
    End Sub
    Public Sub CargaVacaciones(ByRef dtdatos As DataTable, ByVal dtInformacion As DataTable)
        dtdatos = dtInformacion.Clone
        For Each dR As DataRow In dtInformacion.Select("(diasva>0 AND baja IS NULL)", dtInformacion.DefaultView.Sort)
            dtdatos.ImportRow(dR)
        Next
    End Sub

    Public Sub ReporteNomina(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim T1 As Double
        Dim T2 As Double
        Dim Ano As String
        Dim Per As String
        Dim dtPer As New DataTable
        Dim FechaFin As Date

        Try
            Ano = dtInformacion.Rows(0).Item("ano")
            Per = dtInformacion.Rows(0).Item("periodo")

            'Obtener la fecha final del periodo
            'Todas las provisiones de aguinaldo se considerarán al periodo del primer registro
            dtPer = sqlExecute("SELECT fecha_fin FROM periodos WHERE ano = '" & Ano & "' AND periodo = '" & Per & "'", "ta")
            FechaFin = dtPer.Rows(0).Item("fecha_fin")

            dtDatos = dtInformacion.Copy
            dtDatos.Columns.Add("ESTADO", GetType(System.String))
            dtDatos.Columns.Add("COMPENSA", GetType(System.Double))
            dtDatos.Columns.Add("ABOISPT", GetType(System.Double))
            '  dtDatos.Columns.Add("DESEFE", GetType(System.Double))
            dtDatos.Columns.Add("DESDEP", GetType(System.Double))
            dtDatos.Columns.Add("EMPSIN", GetType(System.Double))
            dtDatos.Columns.Add("EMPEFE", GetType(System.Double))
            dtDatos.Columns.Add("EMPDEP", GetType(System.Double))
            dtDatos.Columns.Add("NETEFE", GetType(System.Double))
            dtDatos.Columns.Add("NETDEP", GetType(System.Double))
            dtDatos.Columns.Add("EXCEDE", GetType(System.Double))

            For Each dR As DataRow In dtDatos.Rows
                For Each dC As DataColumn In dtDatos.Columns
                    If dC.DataType Is GetType(System.Double) Then
                        dR(dC.ColumnName) = IIf(IsDBNull(dR(dC.ColumnName)), 0, dR(dC.ColumnName))
                    End If
                Next
                'dR("ESTADO") = IIf(IsDBNull(dR("BAJA")), "ACTIVOS", "BAJAS")

                If IsDBNull(dR("baja")) Then
                    dR("ESTADO") = "ACTIVOS"
                Else
                    dR("ESTADO") = IIf(dR("baja") > FechaFin, "ACTIVOS", "BAJAS")
                End If

            Next

            dtDatos.Select("", "ESTADO,COD_CLASE,RELOJ")

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub RelacionVacaciones(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            dtDatos.Columns.Add("reloj", GetType(System.String))
            dtDatos.Columns.Add("nombres", GetType(System.String))
            dtDatos.Columns.Add("cod_tipo", GetType(System.String))
            dtDatos.Columns.Add("alta", GetType(System.DateTime))
            dtDatos.Columns.Add("antig", GetType(System.Double))
            dtDatos.Columns.Add("cod_depto", GetType(System.String))
            dtDatos.Columns.Add("cod_tipo", GetType(System.String))
            dtDatos.Columns.Add("ganadas", GetType(System.Double))
            dtDatos.Columns.Add("pagadas", GetType(System.Double))

            For Each dR As DataRow In dtInformacion.Rows
                dtTemp = sqlExecute("SELECT (SELECT SUM(dias) FROM saldos_vacaciones WHERE reloj = '" & dR("reloj") & _
                                    "' and aniversario = 1) as ganadas, " & _
                                    "(SELECT SUM(dinero) FROM saldos_vacaciones WHERE reloj = '" & dR("reloj") & _
                                    "' and aniversario = 0) as pagadas")
                If dtTemp.Rows.Count > 0 Then
                    dR("ganadas") = dtTemp.Rows(0).Item("ganadas")
                    dR("pagadas") = dtTemp.Rows(0).Item("pagadas")
                End If
                dtDatos.ImportRow(dR)
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub



    Public Sub RelacionPersonalNum(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtPersonal As New DataTable
            Dim val = ""

            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("cod_depto")
            dtDatos.Columns.Add("rfc")
            dtDatos.Columns.Add("imss")
            dtDatos.Columns.Add("nombre_tiemp")
            dtDatos.Columns.Add("cod_tipoemp")
            dtDatos.Columns.Add("turno")
            dtDatos.Columns.Add("fecha_alta")
            dtDatos.Columns.Add("fecha_baja")
            dtDatos.Columns.Add("puesto")
            'dtDatos.Columns.Add("info_porc_vsm", GetType(System.Double))
            dtDatos.Columns.Add("info_porc_vsm")
            dtDatos.Columns.Add("sactual", GetType(System.Double))


            For Each dRow As DataRow In dtInformacion.Rows
                If Not IsDBNull(dRow("info_porc")) Then
                    val = IIf(dRow("info_porc") = 0, dRow("info_vsm") & "vsm", ((dRow("info_porc")) * 100) & "%")
                End If
                dtDatos.Rows.Add({dRow("reloj"), _
                                  Trim(dRow("nombres")), _
                                  dRow("cod_depto"), _
                                  dRow("rfc"), _
                                  dRow("numimss"), _
                                  dRow("nombre_tipoemp"), _
                                  dRow("cod_tipo"), _
                                  dRow("cod_turno"), _
                                  dRow("alta"), _
                                  dRow("baja"), _
                                  dRow("cod_puesto"), _
                                  val, _
                                  dRow("sactual")})

            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try





    End Sub
    'Public Sub DescuentosInfonavit(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
    '    Try
    '        Dim dtPersonal As New DataTable
    '        'Dim registro As DataRow
    '        Dim val = ""

    '        dtDatos.Columns.Add("reloj")
    '        dtDatos.Columns.Add("nombres")
    '        dtDatos.Columns.Add("cod_depto")
    '        dtDatos.Columns.Add("nombre_tipoemp")
    '        dtDatos.Columns.Add("info_cred")
    '        dtDatos.Columns.Add("info_porc_vsm")
    '        dtDatos.Columns.Add("desinf", GetType(System.Double))

    '        For Each dRow As DataRow In dtInformacion.Select("desinf>0 or info_cred <> ''", dtInformacion.DefaultView.Sort)
    '            'dtPersonal = sqlExecute("SELECT baja from personalvw WHERE reloj = '" & dRow("reloj") & "'")
    '            'If dtPersonal.Rows.Count > 0 Then
    '            'registro = dtPersonal.Rows(0)



    '            If IsDBNull(dRow("baja")) Then
    '                If Not IsDBNull(dRow("info_porc")) Then
    '                    val = IIf(dRow("info_porc") = 0, dRow("info_vsm"), (dRow("info_porc")) * 100)
    '                End If
    '                dtDatos.Rows.Add({dRow("reloj"), _
    '                                  Trim(dRow("nombres")), _
    '                                  dRow("cod_depto"), _
    '                                  dRow("nombre_tipoemp"), _
    '                                  IIf(IsDBNull(dRow("info_cred")), 0, dRow("info_cred")), _
    '                                  val, _
    '                                  IIf(IsDBNull(dRow("desinf")), 0, dRow("desinf"))})

    '            End If
    '            'End If
    '        Next
    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
    '        dtDatos = New DataTable
    '    End Try
    'End Sub


    Public Sub DescuentosInfonavit(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtPersonal As New DataTable
            'Dim registro As DataRow
            'Dim val = ""

            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("cod_depto")
            dtDatos.Columns.Add("nombre_tipoemp")
            dtDatos.Columns.Add("info_cred")
            dtDatos.Columns.Add("info_porc_vsm")
            dtDatos.Columns.Add("desinf", GetType(System.Double))
            dtDatos.Columns.Add("CTAINP", GetType(System.Double))
            dtDatos.Columns.Add("CTAINV", GetType(System.Double))
            dtDatos.Columns.Add("CTAINF", GetType(System.Double))

            'For Each dRow As DataRow In dtInformacion.Select("desinf>0 or info_cred <> ''", dtInformacion.DefaultView.Sort)
            For Each dRow As DataRow In dtInformacion.Rows

                'If Not IsDBNull(dRow("info_porc")) Then
                '    val = IIf(dRow("info_porc") = 0, dRow("info_vsm"), (dRow("info_porc")) * 100)
                'End If


                Dim descuento As Double = IIf(IsDBNull(dRow("DESINF")), 0, dRow("DESINF"))
                descuento += IIf(IsDBNull(dRow("DESINP")), 0, dRow("DESINP"))
                descuento += IIf(IsDBNull(dRow("DESINV")), 0, dRow("DESINV"))

                dtDatos.Rows.Add({dRow("reloj"), _
                                  Trim(dRow("nombres")), _
                                  dRow("cod_depto"), _
                                  dRow("nombre_tipoemp"), _
                                  IIf(IsDBNull(dRow("info_cred")), 0, dRow("info_cred")), _
                                   descuento, _
                                  IIf(IsDBNull(dRow("CTAINP")), 0, dRow("CTAINP")), _
                                   IIf(IsDBNull(dRow("CTAINV")), 0, dRow("CTAINV")), _
                                     IIf(IsDBNull(dRow("CTAINF")), 0, dRow("CTAINF"))})

            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub PrestamosFondoAhorro(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim Ano As String
            Dim Per As String
            Dim dtPer As New DataTable
            Dim FechaFin As Date

            dtInformacion.Columns.Add("grupo", GetType(System.String))
            dtInformacion.Columns.Add("color", GetType(System.Int16))
            dtDatos = dtInformacion.Clone

            Ano = dtInformacion.Rows(0).Item("ano")
            Per = dtInformacion.Rows(0).Item("periodo")

            'Obtener la fecha final del periodo
            dtPer = sqlExecute("SELECT fecha_fin FROM periodos WHERE ano = '" & Ano & "' AND periodo = '" & Per & "'", "ta")
            FechaFin = dtPer.Rows(0).Item("fecha_fin")

            For Each dR As DataRow In dtInformacion.Select("sali1 +salp1 + abial1 + aboal1 > 0", dtInformacion.DefaultView.Sort)
                If IsDBNull(dR("baja")) Then
                    dR("grupo") = "ACTIVOS"
                Else
                    dR("grupo") = IIf(dR("baja") > FechaFin, "ACTIVOS", "BAJAS")
                End If
                If IIf(IsDBNull(dR("neto")), 0, dR("neto")) = 0 And _
                       IIf(IsDBNull(dR("aboal1")), 0, dR("aboal1")) = 0 And _
                       IIf(IsDBNull(dR("sali1")), 0, dR("sali1")) + _
                       IIf(IsDBNull(dR("salp1")), 0, dR("salp1")) + _
                       IIf(IsDBNull(dR("abial1")), 0, dR("abial1")) + _
                       IIf(IsDBNull(dR("aboal1")), 0, dR("aboal1")) > 0 And dR("grupo") = "ACTIVOS" Then
                    'Personas sin neto ni abono
                    'Color verde
                    dR("color") = 1
                ElseIf IIf(IsDBNull(dR("neto")), 0, dR("neto")) = 0 And _
                       IIf(IsDBNull(dR("aboal1")), 0, dR("aboal1")) <> 0 And _
                       IIf(IsDBNull(dR("sali1")), 0, dR("sali1")) + _
                       IIf(IsDBNull(dR("salp1")), 0, dR("salp1")) + _
                       IIf(IsDBNull(dR("abial1")), 0, dR("abial1")) + _
                       IIf(IsDBNull(dR("aboal1")), 0, dR("aboal1")) > 0 And dR("grupo") = "ACTIVOS" Then
                    'Personas sin neto
                    'Color amarillo
                    dR("color") = 2
                ElseIf IIf(IsDBNull(dR("diasva")), 0, dR("diasva")) > 0 And _
                       IIf(IsDBNull(dR("sali1")), 0, dR("sali1")) + _
                       IIf(IsDBNull(dR("salp1")), 0, dR("salp1")) + _
                       IIf(IsDBNull(dR("abial1")), 0, dR("abial1")) + _
                       IIf(IsDBNull(dR("aboal1")), 0, dR("aboal1")) > 0 And dR("grupo") = "ACTIVOS" Then
                    'Personas con vacaciones
                    'Color morado
                    dR("color") = 3
                Else
                    'Color blanco
                    dR("color") = 0
                End If

                dR("retfah") = IIf(IsDBNull(dR("retfah")), 0, dR("retfah"))
                dtDatos.ImportRow(dR)
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub FondoAhorro(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim Ano As String
            Dim Per As String
            Dim FechaFin As Date
            Dim dtPer As New DataTable


            Ano = dtInformacion.Rows(0).Item("ano")
            Per = dtInformacion.Rows(0).Item("periodo")

            'Obtener la fecha final del periodo
            dtPer = sqlExecute("SELECT fecha_fin FROM periodos WHERE ano = '" & Ano & "' AND periodo = '" & Per & "'", "ta")
            FechaFin = dtPer.Rows(0).Item("fecha_fin")

            dtDatos = New DataTable
            'Agregar columnas para formar estructura
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("cod_tipo")
            dtDatos.Columns.Add("cod_clase")
            dtDatos.Columns.Add("centro_costos")
            dtDatos.Columns.Add("nombre_tipoemp")
            dtDatos.Columns.Add("apofah", GetType(System.Double))
            dtDatos.Columns.Add("safahe", GetType(System.Double))
            dtDatos.Columns.Add("fah_porc", GetType(System.Double))
            dtDatos.Columns.Add("safahc", GetType(System.Double))
            dtDatos.Columns.Add("prestamo", GetType(System.Double))
            dtDatos.Columns.Add("interes", GetType(System.Double))
            dtDatos.Columns.Add("retiro", GetType(System.Double))


            For Each dR As DataRow In dtInformacion.Rows
                dR("safahc") = IIf(IsDBNull(dR("safahc")), 0, dR("safahc"))
                dR("safahe") = IIf(IsDBNull(dR("safahe")), 0, dR("safahe"))
                dR("apofah") = IIf(IsDBNull(dR("apofah")), 0, dR("apofah"))
                dR("fah_porc") = IIf(IsDBNull(dR("fah_porc")), 0, dR("fah_porc"))
                dR("salpfa") = IIf(IsDBNull(dR("salpfa")), 0, dR("salpfa"))
                dR("sa2pfa") = IIf(IsDBNull(dR("sa2pfa")), 0, dR("sa2pfa"))
                dR("sa3pfa") = IIf(IsDBNull(dR("sa3pfa")), 0, dR("sa3pfa"))
                dR("sa1ifa") = IIf(IsDBNull(dR("sa1ifa")), 0, dR("sa1ifa"))
                dR("sa2ifa") = IIf(IsDBNull(dR("sa2ifa")), 0, dR("sa2ifa"))
                dR("sa3ifa") = IIf(IsDBNull(dR("sa3ifa")), 0, dR("sa3ifa"))
                dR("retfah") = IIf(IsDBNull(dR("retfah")), 0, dR("retfah"))
                dR("salprf") = IIf(IsDBNull(dR("salprf")), 0, dR("salprf"))



                'dtDatos.Rows.Add({dR("reloj"), _
                '                  Trim(dR("nombres")), _
                '                  dR("cod_tipo"), _
                '                  dR("cod_clase"), _
                '                  dR("centro_costos"), _
                '                  dR("nombre_tipoemp"), _
                '                  dR("apofah"), _
                '                  dR("safahe"), _
                '                  dR("fah_porc"), _
                '                  dR("safahc"), _
                '                  dR("salprf"), _
                '                  dR("sa1ifa") + dR("sa2ifa") + dR("sa3ifa"), _
                '                  dR("retfah")
                '                 })

                dtDatos.Rows.Add({dR("reloj"), _
                                  Trim(dR("nombres")), _
                                  dR("cod_tipo"), _
                                  dR("cod_clase"), _
                                  dR("centro_costos"), _
                                  dR("nombre_tipoemp"), _
                                  dR("apofah"), _
                                  dR("safahe"), _
                                  dR("fah_porc"), _
                                  dR("safahc"), _
                                  dR("salprf"), _
                                  IIf(IsDBNull(dR("intfah")), 0, dR("intfah")), _
                                  dR("retfah")
                                 })
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub NominaExcel1(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal Ingles As Boolean)
        Dim dtConceptos As New DataTable
        Dim dDato As DataRow
        Dim dtNombreEspIng As New DataTable
        ' Dim Depto As String
        Dim i As Integer
        Dim dtCias As New DataTable
        Dim AntClase As String = ""

        Dim Ix As Integer = 0
        Dim J As Integer = 0
        Dim ExcelAPP As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim _range As Excel.Range

        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("ano")
            dtDatos.Columns.Add("periodo")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("puesto")
            dtDatos.Columns.Add("clase")
            dtDatos.Columns.Add("idcc")
            dtDatos.Columns.Add("cod_depto")
            dtDatos.Columns.Add("depto")

            dtDatos.Columns.Add("turno")
            dtDatos.Columns.Add("horas_turno", GetType(System.Double))
            dtDatos.Columns.Add("sactual", GetType(System.Double))
            dtDatos.Columns.Add("alta")
            dtDatos.Columns.Add("baja")
            dtDatos.Columns.Add("numimss")

            If Ingles Then
                dtConceptos = sqlExecute("SELECT concepto,nombre_ingles AS nombre,COD_NATURALEZA,prioridad,0 as orden," & _
                                 "IIF(cod_naturaleza = 'HD','INFORMATION'," & _
                                    "IIF(cod_naturaleza= 'P','PERCEPTION'," & _
                                        "IIF(cod_naturaleza= 'D','DEDUCTION'," & _
                                        "IIF(cod_naturaleza = 'I','TAXES AND EXCEPTIONS','')))) AS tipo " & _
                                "FROM conceptos WHERE NOT nombre_ingles IS NULL AND nombre_ingles <> 'NA' ORDER BY " & _
                                "prioridad", "NOMINA")
            Else
                'dtConceptos = sqlExecute("SELECT concepto,nombre,COD_NATURALEZA,prioridad,0 as orden," & _
                '                   "IIF(cod_naturaleza = 'HD','INFORMATIVOS'," & _
                '                      "IIF(cod_naturaleza= 'P','PERCEPCIONES'," & _
                '                          "IIF(cod_naturaleza= 'D','DEDUCCIONES'," & _
                '                          "IIF(cod_naturaleza = 'I','EXENTOS E IMPUESTOS','')))) AS tipo " & _
                '                  "FROM nomina.dbo.conceptos WHERE NOT nombre_ingles IS NULL ORDER BY " & _
                '                  "prioridad")
                dtConceptos = sqlExecute("select concepto, nombre, cod_naturaleza,prioridad,0 as orden," & _
                                        "case when cod_naturaleza = 'HD' then 'INFORMATIVOS' " & _
                                            "else case when cod_naturaleza = 'P' then 'PERCEPCIONES'" & _
                                                "else case when cod_naturaleza = 'D' then 'DEDUCCIONES' " & _
                                                    "else case when cod_naturaleza = 'I' then 'EXENTOS E IMPUESTOS' " & _
                                                    "else 'OTROS' end end end end as 'tipo'" & _
                                        "from nomina.dbo.conceptos where not NOMBRE_INGLES is null order by " & _
                                        "prioridad")
            End If

            dtConceptos.PrimaryKey = New DataColumn() {dtConceptos.Columns("concepto")}

            i = 0
            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'HD'", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next

            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'P' AND concepto NOT IN ('BONDES','TOTPER','NETO')", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next
            i += 1
            dDato = dtConceptos.Rows.Find("TOTPER")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("TOTPER", GetType(System.Double))
            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'D' AND concepto NOT IN ('TOTDED','NETO')", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next
            i += 1
            dDato = dtConceptos.Rows.Find("TOTDED")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("TOTDED", GetType(System.Double))

            i += 1
            dDato = dtConceptos.Rows.Find("NETO")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("NETO", GetType(System.Double))
            i += 1
            dDato = dtConceptos.Rows.Find("BONDES")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("BONDES", GetType(System.Double))

            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza in ('I', 'V')", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next

            Dim Renglon As Integer = 7
            Dim Columna As Integer = 10
            Dim RenglonAnt As Integer = 7
            Dim dTotal As DataRow
            Dim dTotalGeneral As DataRow

            dTotal = dtDatos.NewRow
            dTotalGeneral = dtDatos.NewRow
            dtInformacion.Columns.Add("clasifica")
            For Each dEmpleado As DataRow In dtInformacion.Rows
                dEmpleado("clasifica") = IIf(dEmpleado("cod_clase") = "G", "A", dEmpleado("cod_clase"))
            Next

            For Each dEmpleado As DataRow In dtInformacion.Select("", "clasifica")
                dDato = dtDatos.NewRow

                dDato("ano") = dEmpleado("ano")
                dDato("periodo") = dEmpleado("periodo")
                dDato("clase") = ""
                dDato("reloj") = dEmpleado("reloj")
                dDato("nombres") = dEmpleado("nombres")
                dDato("numimss") = IIf(IsDBNull(dEmpleado("numimss")), "", dEmpleado("numimss"))
                dDato("sactual") = dEmpleado("sactual")
                dDato("alta") = Format(dEmpleado("alta"), "MM/dd/yyyy")

                If IsDBNull(dEmpleado("baja")) Then
                    dDato("baja") = ""
                Else
                    dDato("baja") = Format(dEmpleado("baja"), "MM/dd/yyyy")
                End If

                dDato("turno") = dEmpleado("cod_turno")
                dDato("idcc") = IIf(IsDBNull(dEmpleado("centro_costos")), "", dEmpleado("centro_costos")).ToString.Trim
                dDato("cod_depto") = IIf(IsDBNull(dEmpleado("cod_depto")), "", dEmpleado("cod_depto")).ToString.Trim

                dtTemp = sqlExecute("SELECT horas FROM turnos WHERE cod_comp = '" & dEmpleado("cod_comp") & _
                                    "' AND cod_turno ='" & dEmpleado("cod_turno") & "'")
                If dtTemp.Rows.Count > 0 Then
                    dDato("horas_turno") = dtTemp.Rows(0).Item("horas")
                End If

                If Ingles Then
                    dtNombreEspIng = sqlExecute("SELECT deptos.nombre_ingles AS depto,puestos.nombre_ingles AS puesto," & _
                                                 "clase.nombre_ingles AS clase FROM personal " & _
                                                 "LEFT JOIN deptos ON deptos.cod_depto = personal.cod_depto AND deptos.cod_comp = personal.cod_comp " & _
                                                 "LEFT JOIN puestos ON puestos.cod_puesto = personal.cod_puesto AND puestos.cod_comp = personal.cod_comp " & _
                                                 "LEFT JOIN clase ON clase.cod_clase = case when personal.cod_clase = 'G' then 'A' else personal.cod_clase end AND clase.cod_comp = personal.cod_comp " & _
                                                 "WHERE reloj = '" & dEmpleado("reloj") & "'")
                Else
                    dtNombreEspIng = sqlExecute("SELECT deptos.nombre AS depto,puestos.nombre AS puesto," & _
                                             "clase.nombre AS clase FROM personal " & _
                                             "LEFT JOIN deptos ON deptos.cod_depto = personal.cod_depto AND deptos.cod_comp = personal.cod_comp " & _
                                             "LEFT JOIN puestos ON puestos.cod_puesto = personal.cod_puesto AND puestos.cod_comp = personal.cod_comp " & _
                                             "LEFT JOIN clase ON clase.cod_clase =case when personal.cod_clase = 'G' then 'A' else personal.cod_clase end AND clase.cod_comp = personal.cod_comp " & _
                                             "WHERE reloj = '" & dEmpleado("reloj") & "'")
                End If

                If dtNombreEspIng.Rows.Count > 0 Then
                    dDato("depto") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("depto")), "", dtNombreEspIng.Rows(0).Item("depto")).ToString.Trim
                    dDato("puesto") = dEmpleado("cod_puesto") & " " & IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("puesto")), "", dtNombreEspIng.Rows(0).Item("puesto")).ToString.Trim
                    dDato("clase") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("clase")), "", dtNombreEspIng.Rows(0).Item("clase")).ToString.Trim
                End If

                If dDato("clase") <> AntClase And AntClase <> "" Then
                    dTotal("reloj") = "******"
                    dTotal("nombres") = "TOTAL"
                    dTotal("clase") = AntClase
                    dtDatos.Rows.Add(dTotal)
                    dTotal = dtDatos.NewRow
                End If



                For Each dConcepto As DataRow In dtConceptos.Rows
                    Try
                        dDato(dConcepto("concepto").ToString.Trim) = dEmpleado(dConcepto("concepto").ToString.Trim)
                        'IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))

                        dTotal(dConcepto("concepto").ToString.Trim) = _
                            IIf(IsDBNull(dTotal(dConcepto("concepto").ToString.Trim)), 0, dTotal(dConcepto("concepto").ToString.Trim)) + _
                                IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))
                        dTotalGeneral(dConcepto("concepto").ToString.Trim) = _
                            IIf(IsDBNull(dTotalGeneral(dConcepto("concepto").ToString.Trim)), 0, dTotalGeneral(dConcepto("concepto").ToString.Trim)) + _
                                IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))
                    Catch ex As Exception
                        'Si algún concepto no se localiza en la tabla de información
                        'Igualar a -1 para que sea fácilmente identificable
                        Try
                            dDato(dConcepto("concepto").ToString.Trim) = -1
                        Catch ex_2 As Exception

                        End Try

                    End Try
                Next

                dtDatos.Rows.Add(dDato)
                AntClase = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("clase")), "", dtNombreEspIng.Rows(0).Item("clase")).ToString.Trim
                Renglon += 1
            Next
            dTotal("reloj") = "******"
            dTotal("nombres") = "TOTAL"
            dTotal("clase") = AntClase
            dtDatos.Rows.Add(dTotal)

            dTotalGeneral("reloj") = "******"
            dTotalGeneral("nombres") = "TOTAL GENERAL"
            dtDatos.Rows.Add(dTotalGeneral)

            Dim datosRec As ADODB.Recordset
            datosRec = DataTableTORecordset(dtDatos)


            'Exportar a archivo excel con formato

            Try

                Dim NombreArchivo As String = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyDocuments & "\logo.jpg"
                ExcelAPP.Visible = False
                wBook = ExcelAPP.Workbooks.Add
                wSheet = wBook.ActiveSheet()
                wSheet.Name = "PIDA"

                'Buscar el logo de la compañía, tomando como base al primer empleado
                dtCias = sqlExecute("SELECT logo FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                If dtCias.Rows.Count > 0 Then
                    If Not IsDBNull(dtCias.Rows(0).Item("logo")) Then
                        'Guardar el logo en MyDocuments como logo.jpg
                        Dim imageInBytes As Byte() = dtCias.Rows(0).Item("logo")
                        Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(imageInBytes, False)
                        Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream)
                        image.Save(NombreArchivo)
                        'Insertar el logo en el excel
                        wSheet.Shapes.AddPicture(NombreArchivo, False, True, 0, 0, 50, 35)
                    End If
                End If

                'wSheet.Shapes.AddPicture("c:\archivo.jpg", False, True, 0, 0, 45, 50)
                If Ingles Then
                    wSheet.Cells(1, 2).Value = dtInformacion.Rows(0).Item("COMPANIA")
                    wSheet.Cells(2, 2).Value = "PAYROLL WEEK " & dtInformacion.Rows(0).Item("PERIODO") & "-" & dtInformacion.Rows(0).Item("ANO")


                    wSheet.Cells(6, 1).Value = "Year"
                    wSheet.Cells(6, 2).Value = "Week"
                    wSheet.Cells(6, 3).Value = "ID"
                    wSheet.Cells(6, 4).Value = "Name"
                    wSheet.Cells(6, 5).Value = "Position"
                    wSheet.Cells(6, 6).Value = "Category"
                    wSheet.Cells(6, 7).Value = "IDCC"
                    wSheet.Cells(6, 8).Value = "Dept."
                    wSheet.Cells(6, 9).Value = "Dept. Name"
                    wSheet.Cells(6, 10).Value = "Shift"
                    wSheet.Cells(6, 11).Value = "Hours per shift"
                    wSheet.Cells(6, 12).Value = "Daily Salary"
                    wSheet.Cells(6, 13).Value = "Hiring Date"
                    wSheet.Cells(6, 14).Value = "Termination Date"
                    wSheet.Cells(6, 15).Value = "IMSS"
                Else
                    wSheet.Cells(1, 2).Value = dtInformacion.Rows(0).Item("COMPANIA")
                    wSheet.Cells(2, 2).Value = "NOMINA SEMANA " & dtInformacion.Rows(0).Item("PERIODO") & "-" & dtInformacion.Rows(0).Item("ANO")

                    wSheet.Cells(6, 1).Value = "Año"
                    wSheet.Cells(6, 2).Value = "Periodo"
                    wSheet.Cells(6, 3).Value = "Reloj"
                    wSheet.Cells(6, 4).Value = "Nombre"
                    wSheet.Cells(6, 5).Value = "Puesto"
                    wSheet.Cells(6, 6).Value = "Clasificación"
                    wSheet.Cells(6, 7).Value = "IDCC"
                    wSheet.Cells(6, 8).Value = "Depto."
                    wSheet.Cells(6, 9).Value = "Nombre Depto."
                    wSheet.Cells(6, 10).Value = "Turno"
                    wSheet.Cells(6, 11).Value = "Horas por turno"
                    wSheet.Cells(6, 12).Value = "Sueldo diario"
                    wSheet.Cells(6, 13).Value = "Fecha alta"
                    wSheet.Cells(6, 14).Value = "Fecha baja"
                    wSheet.Cells(6, 15).Value = "IMSS"
                End If
                wSheet.Range("B1", "B2").Font.Bold = True
                wSheet.Range("B1", "B2").Font.Size = 16

                i = 15
                Dim T As Integer = 0
                Dim E As String = ""
                Dim BColor As Integer = RGB(255, 255, 255)
                Dim FColor As Integer = RGB(0, 0, 0)
                Dim ColTotales(,) As String
                ReDim ColTotales(1, 5)

                For Each dCol As DataRow In dtConceptos.Select("", "orden")
                    i += 1

                    If E <> dCol("cod_naturaleza").ToString.Trim Then
                        E = dCol("cod_naturaleza").ToString.Trim
                        FColor = RGB(0, 0, 0)
                        If E = "HD" Then
                            BColor = RGB(165, 165, 165)
                            FColor = RGB(255, 255, 255)
                        ElseIf E = "P" Then
                            If dCol("concepto").ToString.Trim = "BONDES" Then
                                BColor = -4142
                                dCol("tipo") = ""
                            Else
                                BColor = RGB(198, 239, 206)
                            End If

                        ElseIf E = "D" Then
                            BColor = RGB(0, 192, 255)
                        ElseIf E = "I" Then
                            BColor = RGB(248, 203, 173)
                        ElseIf E = "T" Then
                            E = "H"
                            If dCol("concepto").ToString.Trim = "NETO" Then
                                BColor = RGB(68, 114, 196)
                            End If

                            ColTotales(0, T) = i
                            ColTotales(1, T) = BColor
                            T += 1
                            If UBound(ColTotales, 2) < T Then
                                ReDim Preserve ColTotales(1, T)
                            End If
                            'BColor = RGB(255, 255, 255)
                        End If
                        wSheet.Cells(4, i).Value = dCol("tipo").ToString.Trim
                    End If
                    If E = "HD" Or E = "I" Then
                        _range = wSheet.Range(wSheet.Cells(4, i), wSheet.Cells(5, i))
                    Else
                        _range = wSheet.Range(wSheet.Cells(4, i), wSheet.Cells(4, i))
                    End If
                    _range.Interior.Color = BColor
                    _range.Font.Color = FColor
                    wSheet.Cells(5, i).Value = dCol("nombre").Trim
                    wSheet.Cells(6, i).Value = dCol("concepto").Trim
                Next

                ReDim Preserve ColTotales(1, T - 1)
                _range = wSheet.Range(wSheet.Cells(5, 12), wSheet.Cells(5, i))
                _range.Orientation = 90
                wSheet.Range("a7").CopyFromRecordset(datosRec)

                _range = wSheet.Range(wSheet.Cells(7, 11), wSheet.Cells(datosRec.RecordCount + 7, i))
                _range.NumberFormat = "#,##0.00"
                _range = wSheet.Range(wSheet.Cells(7, 13), wSheet.Cells(datosRec.RecordCount + 7, 14))
                _range.NumberFormat = "dd-mm-yyyy"

                wSheet.Range("D1").Select()
                ExcelAPP.ActiveWindow.FreezePanes = True

                For Ix = 0 To UBound(ColTotales, 2)
                    Columna = ColTotales(0, Ix)
                    Renglon = 5
                    _range = wSheet.Range(wSheet.Cells(Renglon, Columna), wSheet.Cells(datosRec.RecordCount + 7, Columna))
                    _range.Interior.Color = ColTotales(1, Ix)
                    _range.Font.Bold = True
                Next

                'La columna en la que se encuentra el reloj
                Dim columna_reloj As Integer = 3
                For Ix = 7 To datosRec.RecordCount + 6
                    If Not wSheet.Cells(Ix, columna_reloj).value Is Nothing Then
                        If wSheet.Cells(Ix, columna_reloj).value.ToString.Contains("*") Then
                            _range = wSheet.Range(wSheet.Cells(Ix, 1), wSheet.Cells(Ix, i))
                            _range.Interior.Color = Color.FromArgb(RGB(198, 239, 206))
                            _range.Font.Color = Color.DarkGreen
                        End If
                    End If
                Next
                datosRec.Close()


                wSheet.Rows.WrapText = False
                wSheet.Rows(5).WrapText = True
                wSheet.Rows(5).rowheight = 90
                Dim blnFileOpen As Boolean = False

                Dim frmSave As New Windows.Forms.SaveFileDialog
                frmSave.Filter = "Archivo excel (XLSX)|*.xlsx"

                frmSave.ShowDialog()
                If frmSave.FileName <> "" Then
                    NombreArchivo = frmSave.FileName
                    NombreArchivo = IIf(NombreArchivo.ToLower.Contains(".xlsx"), NombreArchivo, NombreArchivo & ".xlsx")
                End If

                ExcelAPP.Visible = True
                Try
                    Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(NombreArchivo)
                    fileTemp.Close()
                    blnFileOpen = True
                Catch ex As Exception
                    blnFileOpen = False
                    MessageBox.Show("El archivo " & NombreArchivo & " no pudo ser guardado. " & _
                                    "Si el problema persiste, contacte al administrador del sistema." & vbCrLf & vbCrLf & _
                                    "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nomina.vb", ex.HResult, ex.Message)
                End Try

                If blnFileOpen Then
                    If System.IO.File.Exists(NombreArchivo) Then
                        System.IO.File.Delete(NombreArchivo)
                    End If

                    wBook.SaveAs(NombreArchivo)
                End If


                releaseObject(wSheet)
                releaseObject(wBook)


            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nomina.vb", ex.HResult, ex.Message)

            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nomina.vb", ex.HResult, ex.Message)
            dtDatos = New DataTable
        Finally
            releaseObject(ExcelAPP)
        End Try
    End Sub


    Public Sub NominaExcel(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal Ingles As Boolean)
        Dim dtConceptos As New DataTable
        Dim dDato As DataRow
        Dim dtNombreEspIng As New DataTable
        ' Dim Depto As String
        Dim i As Integer
        Dim dtCias As New DataTable
        Dim AntClase As String = ""
        'Dim CC As String = ""

        Dim Ix As Integer = 0
        Dim J As Integer = 0
        Dim ExcelAPP As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim _range As Excel.Range

        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("ano")
            dtDatos.Columns.Add("periodo")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("cod_tipo")
            dtDatos.Columns.Add("clase")
            ' dtDatos.Columns.Add("idcc")
            dtDatos.Columns.Add("rfc")
            dtDatos.Columns.Add("cod_depto")
            dtDatos.Columns.Add("num_imss")
            dtDatos.Columns.Add("alta")
            dtDatos.Columns.Add("alta_antig")
            dtDatos.Columns.Add("baja")
            dtDatos.Columns.Add("sactual")
            dtDatos.Columns.Add("integrado")
            dtDatos.Columns.Add("cod_puesto")
            dtDatos.Columns.Add("puesto")

            'dtDatos.Columns.Add("idcc")
            'dtDatos.Columns.Add("depto")
            'dtDatos.Columns.Add("turno")
            'dtDatos.Columns.Add("horas_turno", GetType(System.Double))

            dtConceptos = sqlExecute("select concepto, nombre, cod_naturaleza,prioridad,0 as orden," & _
                                    "case when cod_naturaleza = 'I' then 'INFORMATIVOS' " & _
                                        "else case when cod_naturaleza = 'P' then 'PERCEPCIONES'" & _
                                            "else case when cod_naturaleza = 'D' then 'DEDUCCIONES' " & _
                                                "else case when cod_naturaleza = 'E' then 'EXENTOS' " & _
                                                    "else '' end end end end as 'tipo'" & _
                                    "from nomina.dbo.conceptos where cod_naturaleza not in('A','V') and not NOMBRE_INGLES is null order by " & _
                                    "prioridad")

            dtConceptos.PrimaryKey = New DataColumn() {dtConceptos.Columns("concepto")}


            '*************************************

            Dim dtAnoPerTipoPer As New DataTable
            dtAnoPerTipoPer.Columns.Add("ano")
            dtAnoPerTipoPer.Columns.Add("periodo")
            dtAnoPerTipoPer.Columns.Add("tipo_periodo")
            dtAnoPerTipoPer.PrimaryKey = New DataColumn() {dtAnoPerTipoPer.Columns("ano"), dtAnoPerTipoPer.Columns("periodo"), dtAnoPerTipoPer.Columns("tipo_periodo")}

            dtConceptos.Columns.Add("incluir")


            For Each dEmpleado As DataRow In dtInformacion.Rows
                Try
                    dtAnoPerTipoPer.Rows.Add({dEmpleado("ano"), dEmpleado("periodo"), dEmpleado("tipo_periodo")})
                Catch ex As Exception

                End Try
            Next


            For Each dCol As DataRow In dtConceptos.Select("", "orden")
                dCol("incluir") = 0
            Next

            For Each row_periodo As DataRow In dtAnoPerTipoPer.Rows
                For Each dCol As DataRow In dtConceptos.Select("incluir = 0", "orden")
                    Dim dtIncluir As DataTable = sqlExecute("select * from movimientos where concepto = '" & dCol("concepto").ToString.Trim & "' and monto > 0 and ano = '" & row_periodo("ano") & "' and periodo = '" & row_periodo("periodo") & "' and tipo_periodo = '" & row_periodo("tipo_periodo") & "'", "nomina")
                    If dtIncluir.Rows.Count > 0 Then
                        dCol("incluir") = 1
                    End If
                Next
            Next

            Try
                For Each dCol As DataRow In dtConceptos.Select("concepto in ('NETO', 'TOTDED', 'TOTPER')", "orden")
                    Try
                        dCol("incluir") = 1
                    Catch ex As Exception

                    End Try
                Next
            Catch ex As Exception

            End Try

            For Each dCol As DataRow In dtConceptos.Select("incluir = 0", "orden")
                Try
                    dtInformacion.Columns.Remove(RTrim(dCol("concepto")))
                Catch ex As Exception

                End Try
            Next

            dtConceptos = dtConceptos.Select("incluir = '1'").CopyToDataTable

            dtConceptos.PrimaryKey = New DataColumn() {dtConceptos.Columns("concepto")}
            '************************************


            i = 0
            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'P' AND concepto NOT IN ('BONDES','TOTPER','NETO')", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next

            i += 1
            dDato = dtConceptos.Rows.Find("TOTPER")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("TOTPER", GetType(System.Double))

            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'D' AND concepto NOT IN ('TOTDED','NETO')", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next

            i += 1
            dDato = dtConceptos.Rows.Find("TOTDED")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("TOTDED", GetType(System.Double))

            i += 1
            dDato = dtConceptos.Rows.Find("NETO")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("NETO", GetType(System.Double))
            i += 1
            dDato = dtConceptos.Rows.Find("BONDES")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If

            ' dtDatos.Columns.Add("BONDES", GetType(System.Double))

            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'E'", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next

            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza in ('I', 'V')", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next


            '-----------------------------------------------------------------------------------------------------------------------------------
            Dim Renglon As Integer = 7
            Dim Columna As Integer = 10
            Dim RenglonAnt As Integer = 7
            Dim dTotal As DataRow
            Dim dTotalGeneral As DataRow
            Dim dCc As DataRow

            dTotal = dtDatos.NewRow
            dTotalGeneral = dtDatos.NewRow
            dCc = dtDatos.NewRow

            dtInformacion.Columns.Add("clasifica")
            For Each dEmpleado As DataRow In dtInformacion.Rows
                dEmpleado("clasifica") = IIf(dEmpleado("cod_clase") = "G", "A", dEmpleado("cod_clase"))
            Next



            For Each dEmpleado As DataRow In dtInformacion.Select("", "clasifica")

                dDato = dtDatos.NewRow

                dDato("ano") = dEmpleado("ano")
                dDato("periodo") = dEmpleado("periodo")

                dDato("reloj") = dEmpleado("reloj")
                dDato("nombres") = dEmpleado("nombres")
                dDato("cod_tipo") = dEmpleado("cod_tipo")
                '   dDato("idcc") = IIf(IsDBNull(dEmpleado("centro_costos")), "", dEmpleado("centro_costos")).ToString.Trim
                dDato("rfc") = dEmpleado("rfc")
                dDato("cod_depto") = IIf(IsDBNull(dEmpleado("cod_depto")), "", dEmpleado("cod_depto")).ToString.Trim
                dDato("num_imss") = IIf(IsDBNull(dEmpleado("numimss")), "", dEmpleado("numimss"))
                dDato("alta") = Format(dEmpleado("alta"), "MM/dd/yyyy")
                ' dDato("alta_antig") = Format(dEmpleado("alta"), "MM/dd/yyyy")
                'dDato("alta_antig") = IIf(IsDBNull(dEmpleado("alta_vacacion")), "", dEmpleado("alta_vacacion"))
                If IsDBNull(dEmpleado("baja")) Then
                    dDato("baja") = ""
                Else
                    dDato("baja") = Format(dEmpleado("baja"), "MM/dd/yyyy")
                End If
                dDato("sactual") = dEmpleado("sactual")
                dDato("integrado") = dEmpleado("integrado")

                ' dDato("turno") = dEmpleado("cod_turno")
                'dDato("idcc") = IIf(IsDBNull(dEmpleado("centro_costos")), "", dEmpleado("centro_costos")).ToString.Trim
                'dtTemp = sqlExecute("SELECT horas FROM turnos WHERE cod_comp = '" & dEmpleado("cod_comp") & _
                '                    "' AND cod_turno ='" & dEmpleado("cod_turno") & "'")
                'If dtTemp.Rows.Count > 0 Then
                '    dDato("horas_turno") = dtTemp.Rows(0).Item("horas")
                'End If

                If Ingles Then
                    dtNombreEspIng = sqlExecute("SELECT deptos.nombre_ingles AS depto,puestos.nombre_ingles AS puesto," & _
                                                 "clase.nombre_ingles AS clase FROM personal " & _
                                                 "LEFT JOIN deptos ON deptos.cod_depto = personal.cod_depto AND deptos.cod_comp = personal.cod_comp " & _
                                                 "LEFT JOIN puestos ON puestos.cod_puesto = personal.cod_puesto AND puestos.cod_comp = personal.cod_comp " & _
                                                 "LEFT JOIN clase ON clase.cod_clase = case when personal.cod_clase = 'G' then 'A' else personal.cod_clase end AND clase.cod_comp = personal.cod_comp " & _
                                                 "WHERE reloj = '" & dEmpleado("reloj") & "'")
                Else
                    dtNombreEspIng = sqlExecute("SELECT deptos.nombre AS depto,puestos.nombre AS puesto," & _
                                             "clase.nombre AS clase FROM personal " & _
                                             "LEFT JOIN deptos ON deptos.cod_depto = personal.cod_depto AND deptos.cod_comp = personal.cod_comp " & _
                                             "LEFT JOIN puestos ON puestos.cod_puesto = personal.cod_puesto AND puestos.cod_comp = personal.cod_comp " & _
                                             "LEFT JOIN clase ON clase.cod_clase =case when personal.cod_clase = 'G' then 'A' else personal.cod_clase end AND clase.cod_comp = personal.cod_comp " & _
                                             "WHERE reloj = '" & dEmpleado("reloj") & "'")
                End If

                If dtNombreEspIng.Rows.Count > 0 Then
                    ' dDato("depto") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("depto")), "", dtNombreEspIng.Rows(0).Item("depto")).ToString.Trim
                    dDato("clase") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("clase")), "", dtNombreEspIng.Rows(0).Item("clase")).ToString.Trim
                    dDato("cod_puesto") = dEmpleado("cod_puesto")
                    dDato("puesto") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("puesto")), "", dtNombreEspIng.Rows(0).Item("puesto")).ToString.Trim
                End If

                'If dDato("idcc") <> CC And CC <> "" Then
                '    dCc("reloj") = "------"
                '    dCc("nombres") = "Centro de Costos:"
                '    dCc("idcc") = CC
                '    dtDatos.Rows.Add(dCc)
                '    dCc = dtDatos.NewRow
                'End If

                If dDato("clase") <> AntClase And AntClase <> "" Then
                    dTotal("reloj") = "******"
                    dTotal("nombres") = "TOTAL"
                    dTotal("clase") = AntClase
                    dtDatos.Rows.Add(dTotal)
                    dTotal = dtDatos.NewRow
                End If

                For Each dConcepto As DataRow In dtConceptos.Rows
                    Try
                        dDato(dConcepto("concepto").ToString.Trim) = dEmpleado(dConcepto("concepto").ToString.Trim)
                        'IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))

                        dTotal(dConcepto("concepto").ToString.Trim) = _
                            IIf(IsDBNull(dTotal(dConcepto("concepto").ToString.Trim)), 0, dTotal(dConcepto("concepto").ToString.Trim)) + _
                                IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))
                        dTotalGeneral(dConcepto("concepto").ToString.Trim) = _
                            IIf(IsDBNull(dTotalGeneral(dConcepto("concepto").ToString.Trim)), 0, dTotalGeneral(dConcepto("concepto").ToString.Trim)) + _
                                IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))
                    Catch ex As Exception
                        'Si algún concepto no se localiza en la tabla de información
                        'Igualar a -1 para que sea fácilmente identificable
                        dDato(dConcepto("concepto").ToString.Trim) = -1
                    End Try
                Next

                dtDatos.Rows.Add(dDato)
                AntClase = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("clase")), "", dtNombreEspIng.Rows(0).Item("clase")).ToString.Trim
                '   CC = dDato("idcc")
                Renglon += 1
            Next

            dTotal("reloj") = "******"
            dTotal("nombres") = "TOTAL"
            dTotal("clase") = AntClase
            dtDatos.Rows.Add(dTotal)

            'dCc("reloj") = "******"
            'dCc("nombres") = "Centro de Costos:"
            'dCc("clase") = dDato("idcc")
            'dtDatos.Rows.Add(dCc)

            dTotalGeneral("reloj") = "******"
            dTotalGeneral("nombres") = "TOTAL GENERAL"
            dtDatos.Rows.Add(dTotalGeneral)

            Dim datosRec As ADODB.Recordset
            datosRec = DataTableTORecordset(dtDatos)
            '-------------------------------------------------------------------------------------------------------------------------------------------------

            'Exportar a archivo excel con formato

            Try

                Dim NombreArchivo As String = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyDocuments & "\logo.jpg"
                ExcelAPP.Visible = False
                wBook = ExcelAPP.Workbooks.Add
                wSheet = wBook.ActiveSheet()
                wSheet.Name = "PIDA"

                'Buscar el logo de la compañía, tomando como base al primer empleado
                dtCias = sqlExecute("SELECT logo FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                If dtCias.Rows.Count > 0 Then
                    If Not IsDBNull(dtCias.Rows(0).Item("logo")) Then
                        'Guardar el logo en MyDocuments como logo.jpg
                        Dim imageInBytes As Byte() = dtCias.Rows(0).Item("logo")
                        Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(imageInBytes, False)
                        Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream)
                        image.Save(NombreArchivo)
                        'Insertar el logo en el excel
                        wSheet.Shapes.AddPicture(NombreArchivo, False, True, 0, 0, 50, 35)
                    End If
                End If

                'wSheet.Shapes.AddPicture("c:\archivo.jpg", False, True, 0, 0, 45, 50)

                wSheet.Cells(1, 2).Value = dtInformacion.Rows(0).Item("COMPANIA")
                If dtInformacion.Rows(0).Item("TIPO_PERIODO") = "Q" Then
                    wSheet.Cells(2, 2).Value = "NOMINA QUINCENAL " & dtInformacion.Rows(0).Item("PERIODO") & "-" & dtInformacion.Rows(0).Item("ANO")
                Else
                    wSheet.Cells(2, 2).Value = "NOMINA SEMANA " & dtInformacion.Rows(0).Item("PERIODO") & "-" & dtInformacion.Rows(0).Item("ANO")
                End If


                wSheet.Cells(6, 1).Value = "Año"
                wSheet.Cells(6, 2).Value = "Periodo"
                wSheet.Cells(6, 3).Value = "Reloj"
                wSheet.Cells(6, 4).Value = "Nombre"
                wSheet.Cells(6, 5).Value = "Cod Tipo"
                wSheet.Cells(6, 6).Value = "Cod Clase"
                wSheet.Cells(6, 7).Value = "RFC"
                wSheet.Cells(6, 8).Value = "Cod Depto"
                wSheet.Cells(6, 9).Value = "IMSS"
                wSheet.Cells(6, 10).Value = "Alta"
                wSheet.Cells(6, 11).Value = "Alta Antig"
                wSheet.Cells(6, 12).Value = "Baja"
                wSheet.Cells(6, 13).Value = "SActual"
                wSheet.Cells(6, 14).Value = "Integrado"
                wSheet.Cells(6, 15).Value = "Cod Puesto"
                wSheet.Cells(6, 16).Value = "Puesto"

                wSheet.Range("B1", "B2").Font.Bold = True
                wSheet.Range("B1", "B2").Font.Size = 16


                i = 16
                Dim T As Integer = 0
                Dim E As String = ""
                Dim BColor As Integer = RGB(255, 255, 255)
                Dim FColor As Integer = RGB(0, 0, 0)
                Dim ColTotales(,) As String
                ReDim ColTotales(1, 5)




                For Each dCol As DataRow In dtConceptos.Select("", "orden")
                    i += 1

                    If E <> dCol("cod_naturaleza").ToString.Trim Then
                        E = dCol("cod_naturaleza").ToString.Trim
                        FColor = RGB(0, 0, 0)
                        If E = "I" Then
                            BColor = RGB(165, 165, 165)
                            'FColor = RGB(255, 255, 255)
                        ElseIf E = "P" Then
                            If dCol("concepto").ToString.Trim = "BONDES" Then
                                BColor = RGB(198, 239, 206)
                                dCol("tipo") = ""
                            Else
                                BColor = RGB(198, 239, 206)
                            End If

                        ElseIf E = "D" Then
                            BColor = RGB(145, 201, 255)
                        ElseIf E = "E" Then
                            BColor = RGB(248, 203, 173)
                        ElseIf E = "T" Then
                            E = "H"
                            If dCol("concepto").ToString.Trim = "NETO" Then
                                BColor = RGB(68, 114, 196)
                            End If

                            ColTotales(0, T) = i
                            ColTotales(1, T) = BColor
                            T += 1
                            If UBound(ColTotales, 2) < T Then
                                ReDim Preserve ColTotales(1, T)
                            End If
                            'BColor = RGB(255, 255, 255)
                        End If
                        wSheet.Cells(4, i).Value = dCol("tipo").ToString.Trim
                    End If
                    If E = "" Or E = "" Then
                        _range = wSheet.Range(wSheet.Cells(4, i), wSheet.Cells(5, i))
                    Else
                        _range = wSheet.Range(wSheet.Cells(4, i), wSheet.Cells(4, i))
                    End If
                    _range.Interior.Color = BColor
                    _range.Font.Color = FColor
                    wSheet.Cells(5, i).Value = dCol("nombre").Trim
                    wSheet.Cells(6, i).Value = dCol("concepto").Trim
                Next

                ReDim Preserve ColTotales(1, T - 1)
                _range = wSheet.Range(wSheet.Cells(5, 12), wSheet.Cells(5, i))
                _range.Orientation = 90

                wSheet.Range("a7").CopyFromRecordset(datosRec)

                _range = wSheet.Range(wSheet.Cells(7, 11), wSheet.Cells(datosRec.RecordCount + 7, i))
                _range.NumberFormat = "#,##0.00"
                _range = wSheet.Range(wSheet.Cells(7, 13), wSheet.Cells(datosRec.RecordCount + 7, 14))
                _range.NumberFormat = "dd-mm-yyyy"

                wSheet.Range("D1").Select()
                ExcelAPP.ActiveWindow.FreezePanes = True

                For Ix = 0 To UBound(ColTotales, 2)
                    Columna = ColTotales(0, Ix)
                    Renglon = 5
                    _range = wSheet.Range(wSheet.Cells(Renglon, Columna), wSheet.Cells(datosRec.RecordCount + 7, Columna))
                    _range.Interior.Color = ColTotales(1, Ix)
                    _range.Font.Bold = True
                Next



                'La columna en la que se encuentra el reloj
                Dim columna_reloj As Integer = 3
                For Ix = 7 To datosRec.RecordCount + 6
                    If Not wSheet.Cells(Ix, columna_reloj).value Is Nothing Then
                        If wSheet.Cells(Ix, columna_reloj).value.ToString.Contains("*") Then
                            _range = wSheet.Range(wSheet.Cells(Ix, 1), wSheet.Cells(Ix, i))
                            _range.Interior.Color = Color.FromArgb(RGB(198, 239, 206))
                            _range.Font.Color = Color.DarkGreen
                        End If
                        If wSheet.Cells(Ix, columna_reloj).value.ToString.Contains("-") Then
                            _range = wSheet.Range(wSheet.Cells(Ix, 1), wSheet.Cells(Ix, i))
                            _range.Interior.Color = Color.FromArgb(RGB(240, 199, 198))
                            _range.Font.Color = Color.DarkRed
                        End If
                    End If
                Next


                datosRec.Close()


                wSheet.Rows.WrapText = False
                wSheet.Rows(5).WrapText = True
                wSheet.Rows(5).rowheight = 90
                Dim blnFileOpen As Boolean = False

                Dim frmSave As New Windows.Forms.SaveFileDialog
                frmSave.Filter = "Archivo excel (XLSX)|*.xlsx"

                frmSave.ShowDialog()
                If frmSave.FileName <> "" Then
                    NombreArchivo = frmSave.FileName
                    NombreArchivo = IIf(NombreArchivo.ToLower.Contains(".xlsx"), NombreArchivo, NombreArchivo & ".xlsx")
                End If

                ExcelAPP.Visible = True
                Try
                    Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(NombreArchivo)
                    fileTemp.Close()
                    blnFileOpen = True
                Catch ex As Exception
                    blnFileOpen = False
                    MessageBox.Show("El archivo " & NombreArchivo & " no pudo ser guardado. " & _
                                    "Si el problema persiste, contacte al administrador del sistema." & vbCrLf & vbCrLf & _
                                    "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nomina.vb", ex.HResult, ex.Message)
                End Try

                If blnFileOpen Then
                    If System.IO.File.Exists(NombreArchivo) Then
                        System.IO.File.Delete(NombreArchivo)
                    End If

                    wBook.SaveAs(NombreArchivo)
                End If


                releaseObject(wSheet)
                releaseObject(wBook)


            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)

            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)
            dtDatos = New DataTable
        Finally
            releaseObject(ExcelAPP)
        End Try
    End Sub

    'Public Sub NominaExcel(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal Ingles As Boolean)
    '    Dim dtConceptos As New DataTable
    '    Dim dDato As DataRow
    '    Dim dtNombreEspIng As New DataTable
    '    ' Dim Depto As String
    '    Dim i As Integer
    '    Dim dtCias As New DataTable
    '    Dim AntClase As String = ""
    '    'Dim CC As String = ""

    '    Dim Ix As Integer = 0
    '    Dim J As Integer = 0
    '    Dim ExcelAPP As New Excel.Application
    '    Dim wBook As Excel.Workbook
    '    Dim wSheet As Excel.Worksheet
    '    Dim _range As Excel.Range

    '    Try
    '        dtDatos = New DataTable
    '        dtDatos.Columns.Add("ano")
    '        dtDatos.Columns.Add("periodo")
    '        dtDatos.Columns.Add("reloj")
    '        dtDatos.Columns.Add("nombres")
    '        dtDatos.Columns.Add("cod_tipo")
    '        dtDatos.Columns.Add("clase")
    '        ' dtDatos.Columns.Add("idcc")
    '        dtDatos.Columns.Add("rfc")
    '        dtDatos.Columns.Add("cod_depto")
    '        dtDatos.Columns.Add("num_imss")
    '        dtDatos.Columns.Add("alta")
    '        dtDatos.Columns.Add("alta_antig")
    '        dtDatos.Columns.Add("baja")
    '        dtDatos.Columns.Add("sactual")
    '        dtDatos.Columns.Add("integrado")
    '        dtDatos.Columns.Add("cod_puesto")
    '        dtDatos.Columns.Add("puesto")

    '        'dtDatos.Columns.Add("idcc")
    '        'dtDatos.Columns.Add("depto")
    '        'dtDatos.Columns.Add("turno")
    '        'dtDatos.Columns.Add("horas_turno", GetType(System.Double))

    '        dtConceptos = sqlExecute("select concepto, nombre, cod_naturaleza,prioridad,0 as orden," & _
    '                                "case when cod_naturaleza = 'I' then 'INFORMATIVOS' " & _
    '                                    "else case when cod_naturaleza = 'P' then 'PERCEPCIONES'" & _
    '                                        "else case when cod_naturaleza = 'D' then 'DEDUCCIONES' " & _
    '                                            "else case when cod_naturaleza = 'E' then 'EXENTOS' " & _
    '                                                "else '' end end end end as 'tipo'" & _
    '                                "from nomina.dbo.conceptos where cod_naturaleza not in('A','V') and not NOMBRE_INGLES is null order by " & _
    '                                "prioridad")

    '        dtConceptos.PrimaryKey = New DataColumn() {dtConceptos.Columns("concepto")}

    '        i = 0
    '        For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'P' AND concepto NOT IN ('BONDES','TOTPER','NETO')", "prioridad")
    '            i += 1
    '            dConcepto("orden") = i
    '            dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
    '        Next

    '        i += 1
    '        dDato = dtConceptos.Rows.Find("TOTPER")
    '        If Not dDato Is Nothing Then
    '            dDato("orden") = i
    '        End If
    '        dtDatos.Columns.Add("TOTPER", GetType(System.Double))

    '        For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'D' AND concepto NOT IN ('TOTDED','NETO')", "prioridad")
    '            i += 1
    '            dConcepto("orden") = i
    '            dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
    '        Next

    '        i += 1
    '        dDato = dtConceptos.Rows.Find("TOTDED")
    '        If Not dDato Is Nothing Then
    '            dDato("orden") = i
    '        End If
    '        dtDatos.Columns.Add("TOTDED", GetType(System.Double))

    '        i += 1
    '        dDato = dtConceptos.Rows.Find("NETO")
    '        If Not dDato Is Nothing Then
    '            dDato("orden") = i
    '        End If
    '        dtDatos.Columns.Add("NETO", GetType(System.Double))
    '        i += 1
    '        dDato = dtConceptos.Rows.Find("BONDES")
    '        If Not dDato Is Nothing Then
    '            dDato("orden") = i
    '        End If
    '        dtDatos.Columns.Add("BONDES", GetType(System.Double))

    '        For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'E'", "prioridad")
    '            i += 1
    '            dConcepto("orden") = i
    '            dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
    '        Next

    '        For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza in ('I', 'V')", "prioridad")
    '            i += 1
    '            dConcepto("orden") = i
    '            dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
    '        Next


    '        '-----------------------------------------------------------------------------------------------------------------------------------
    '        Dim Renglon As Integer = 7
    '        Dim Columna As Integer = 10
    '        Dim RenglonAnt As Integer = 7
    '        Dim dTotal As DataRow
    '        Dim dTotalGeneral As DataRow
    '        Dim dCc As DataRow

    '        dTotal = dtDatos.NewRow
    '        dTotalGeneral = dtDatos.NewRow
    '        dCc = dtDatos.NewRow

    '        dtInformacion.Columns.Add("clasifica")
    '        For Each dEmpleado As DataRow In dtInformacion.Rows
    '            dEmpleado("clasifica") = IIf(dEmpleado("cod_clase") = "G", "A", dEmpleado("cod_clase"))
    '        Next

    '        For Each dEmpleado As DataRow In dtInformacion.Select("", "clasifica")

    '            dDato = dtDatos.NewRow

    '            dDato("ano") = dEmpleado("ano")
    '            dDato("periodo") = dEmpleado("periodo")
    '            dDato("reloj") = dEmpleado("reloj")
    '            dDato("nombres") = dEmpleado("nombres")
    '            dDato("cod_tipo") = dEmpleado("cod_tipo")
    '            '   dDato("idcc") = IIf(IsDBNull(dEmpleado("centro_costos")), "", dEmpleado("centro_costos")).ToString.Trim
    '            dDato("rfc") = dEmpleado("rfc")
    '            dDato("cod_depto") = IIf(IsDBNull(dEmpleado("cod_depto")), "", dEmpleado("cod_depto")).ToString.Trim
    '            dDato("num_imss") = IIf(IsDBNull(dEmpleado("numimss")), "", dEmpleado("numimss"))
    '            dDato("alta") = Format(dEmpleado("alta"), "MM/dd/yyyy")
    '            ' dDato("alta_antig") = Format(dEmpleado("alta"), "MM/dd/yyyy")
    '            'dDato("alta_antig") = IIf(IsDBNull(dEmpleado("alta_vacacion")), "", dEmpleado("alta_vacacion"))
    '            If IsDBNull(dEmpleado("baja")) Then
    '                dDato("baja") = ""
    '            Else
    '                dDato("baja") = Format(dEmpleado("baja"), "MM/dd/yyyy")
    '            End If
    '            dDato("sactual") = dEmpleado("sactual")
    '            dDato("integrado") = dEmpleado("integrado")

    '            ' dDato("turno") = dEmpleado("cod_turno")
    '            'dDato("idcc") = IIf(IsDBNull(dEmpleado("centro_costos")), "", dEmpleado("centro_costos")).ToString.Trim
    '            'dtTemp = sqlExecute("SELECT horas FROM turnos WHERE cod_comp = '" & dEmpleado("cod_comp") & _
    '            '                    "' AND cod_turno ='" & dEmpleado("cod_turno") & "'")
    '            'If dtTemp.Rows.Count > 0 Then
    '            '    dDato("horas_turno") = dtTemp.Rows(0).Item("horas")
    '            'End If

    '            If Ingles Then
    '                dtNombreEspIng = sqlExecute("SELECT deptos.nombre_ingles AS depto,puestos.nombre_ingles AS puesto," & _
    '                                             "clase.nombre_ingles AS clase FROM personal " & _
    '                                             "LEFT JOIN deptos ON deptos.cod_depto = personal.cod_depto AND deptos.cod_comp = personal.cod_comp " & _
    '                                             "LEFT JOIN puestos ON puestos.cod_puesto = personal.cod_puesto AND puestos.cod_comp = personal.cod_comp " & _
    '                                             "LEFT JOIN clase ON clase.cod_clase = case when personal.cod_clase = 'G' then 'A' else personal.cod_clase end AND clase.cod_comp = personal.cod_comp " & _
    '                                             "WHERE reloj = '" & dEmpleado("reloj") & "'")
    '            Else
    '                dtNombreEspIng = sqlExecute("SELECT deptos.nombre AS depto,puestos.nombre AS puesto," & _
    '                                         "clase.nombre AS clase FROM personal " & _
    '                                         "LEFT JOIN deptos ON deptos.cod_depto = personal.cod_depto AND deptos.cod_comp = personal.cod_comp " & _
    '                                         "LEFT JOIN puestos ON puestos.cod_puesto = personal.cod_puesto AND puestos.cod_comp = personal.cod_comp " & _
    '                                         "LEFT JOIN clase ON clase.cod_clase =case when personal.cod_clase = 'G' then 'A' else personal.cod_clase end AND clase.cod_comp = personal.cod_comp " & _
    '                                         "WHERE reloj = '" & dEmpleado("reloj") & "'")
    '            End If

    '            If dtNombreEspIng.Rows.Count > 0 Then
    '                ' dDato("depto") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("depto")), "", dtNombreEspIng.Rows(0).Item("depto")).ToString.Trim
    '                dDato("clase") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("clase")), "", dtNombreEspIng.Rows(0).Item("clase")).ToString.Trim
    '                dDato("cod_puesto") = dEmpleado("cod_puesto")
    '                dDato("puesto") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("puesto")), "", dtNombreEspIng.Rows(0).Item("puesto")).ToString.Trim
    '            End If

    '            'If dDato("idcc") <> CC And CC <> "" Then
    '            '    dCc("reloj") = "------"
    '            '    dCc("nombres") = "Centro de Costos:"
    '            '    dCc("idcc") = CC
    '            '    dtDatos.Rows.Add(dCc)
    '            '    dCc = dtDatos.NewRow
    '            'End If

    '            If dDato("clase") <> AntClase And AntClase <> "" Then
    '                dTotal("reloj") = "******"
    '                dTotal("nombres") = "TOTAL"
    '                dTotal("clase") = AntClase
    '                dtDatos.Rows.Add(dTotal)
    '                dTotal = dtDatos.NewRow
    '            End If

    '            For Each dConcepto As DataRow In dtConceptos.Rows
    '                Try
    '                    dDato(dConcepto("concepto").ToString.Trim) = dEmpleado(dConcepto("concepto").ToString.Trim)
    '                    'IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))

    '                    dTotal(dConcepto("concepto").ToString.Trim) = _
    '                        IIf(IsDBNull(dTotal(dConcepto("concepto").ToString.Trim)), 0, dTotal(dConcepto("concepto").ToString.Trim)) + _
    '                            IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))
    '                    dTotalGeneral(dConcepto("concepto").ToString.Trim) = _
    '                        IIf(IsDBNull(dTotalGeneral(dConcepto("concepto").ToString.Trim)), 0, dTotalGeneral(dConcepto("concepto").ToString.Trim)) + _
    '                            IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))
    '                Catch ex As Exception
    '                    'Si algún concepto no se localiza en la tabla de información
    '                    'Igualar a -1 para que sea fácilmente identificable
    '                    dDato(dConcepto("concepto").ToString.Trim) = -1
    '                End Try
    '            Next

    '            dtDatos.Rows.Add(dDato)
    '            AntClase = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("clase")), "", dtNombreEspIng.Rows(0).Item("clase")).ToString.Trim
    '            '   CC = dDato("idcc")
    '            Renglon += 1
    '        Next

    '        dTotal("reloj") = "******"
    '        dTotal("nombres") = "TOTAL"
    '        dTotal("clase") = AntClase
    '        dtDatos.Rows.Add(dTotal)

    '        'dCc("reloj") = "******"
    '        'dCc("nombres") = "Centro de Costos:"
    '        'dCc("clase") = dDato("idcc")
    '        'dtDatos.Rows.Add(dCc)

    '        dTotalGeneral("reloj") = "******"
    '        dTotalGeneral("nombres") = "TOTAL GENERAL"
    '        dtDatos.Rows.Add(dTotalGeneral)

    '        Dim datosRec As ADODB.Recordset
    '        datosRec = DataTableTORecordset(dtDatos)
    '        '-------------------------------------------------------------------------------------------------------------------------------------------------

    '        'Exportar a archivo excel con formato

    '        Try

    '            Dim NombreArchivo As String = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyDocuments & "\logo.jpg"
    '            ExcelAPP.Visible = False
    '            wBook = ExcelAPP.Workbooks.Add
    '            wSheet = wBook.ActiveSheet()
    '            wSheet.Name = "PIDA"

    '            'Buscar el logo de la compañía, tomando como base al primer empleado
    '            dtCias = sqlExecute("SELECT logo FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
    '            If dtCias.Rows.Count > 0 Then
    '                If Not IsDBNull(dtCias.Rows(0).Item("logo")) Then
    '                    'Guardar el logo en MyDocuments como logo.jpg
    '                    Dim imageInBytes As Byte() = dtCias.Rows(0).Item("logo")
    '                    Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(imageInBytes, False)
    '                    Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream)
    '                    image.Save(NombreArchivo)
    '                    'Insertar el logo en el excel
    '                    wSheet.Shapes.AddPicture(NombreArchivo, False, True, 0, 0, 50, 35)
    '                End If
    '            End If

    '            'wSheet.Shapes.AddPicture("c:\archivo.jpg", False, True, 0, 0, 45, 50)

    '            wSheet.Cells(1, 2).Value = dtInformacion.Rows(0).Item("COMPANIA")
    '            If dtInformacion.Rows(0).Item("TIPO_PERIODO") = "Q" Then
    '                wSheet.Cells(2, 2).Value = "NOMINA QUINCENAL " & dtInformacion.Rows(0).Item("PERIODO") & "-" & dtInformacion.Rows(0).Item("ANO")
    '            Else
    '                wSheet.Cells(2, 2).Value = "NOMINA SEMANA " & dtInformacion.Rows(0).Item("PERIODO") & "-" & dtInformacion.Rows(0).Item("ANO")
    '            End If


    '            wSheet.Cells(6, 1).Value = "Año"
    '            wSheet.Cells(6, 2).Value = "Periodo"
    '            wSheet.Cells(6, 3).Value = "Reloj"
    '            wSheet.Cells(6, 4).Value = "Nombre"
    '            wSheet.Cells(6, 5).Value = "Cod Tipo"
    '            wSheet.Cells(6, 6).Value = "Cod Clase"
    '            wSheet.Cells(6, 7).Value = "RFC"
    '            wSheet.Cells(6, 8).Value = "Cod Depto"
    '            wSheet.Cells(6, 9).Value = "IMSS"
    '            wSheet.Cells(6, 10).Value = "Alta"
    '            wSheet.Cells(6, 11).Value = "Alta Antig"
    '            wSheet.Cells(6, 12).Value = "Baja"
    '            wSheet.Cells(6, 13).Value = "SActual"
    '            wSheet.Cells(6, 14).Value = "Integrado"
    '            wSheet.Cells(6, 15).Value = "Cod Puesto"
    '            wSheet.Cells(6, 16).Value = "Puesto"

    '            wSheet.Range("B1", "B2").Font.Bold = True
    '            wSheet.Range("B1", "B2").Font.Size = 16


    '            i = 16
    '            Dim T As Integer = 0
    '            Dim E As String = ""
    '            Dim BColor As Integer = RGB(255, 255, 255)
    '            Dim FColor As Integer = RGB(0, 0, 0)
    '            Dim ColTotales(,) As String
    '            ReDim ColTotales(1, 5)

    '            For Each dCol As DataRow In dtConceptos.Select("", "orden")
    '                i += 1

    '                If E <> dCol("cod_naturaleza").ToString.Trim Then
    '                    E = dCol("cod_naturaleza").ToString.Trim
    '                    FColor = RGB(0, 0, 0)
    '                    If E = "I" Then
    '                        BColor = RGB(165, 165, 165)
    '                        'FColor = RGB(255, 255, 255)
    '                    ElseIf E = "P" Then
    '                        If dCol("concepto").ToString.Trim = "BONDES" Then
    '                            BColor = RGB(198, 239, 206)
    '                            dCol("tipo") = ""
    '                        Else
    '                            BColor = RGB(198, 239, 206)
    '                        End If

    '                    ElseIf E = "D" Then
    '                        BColor = RGB(145, 201, 255)
    '                    ElseIf E = "E" Then
    '                        BColor = RGB(248, 203, 173)
    '                    ElseIf E = "T" Then
    '                        E = "H"
    '                        If dCol("concepto").ToString.Trim = "NETO" Then
    '                            BColor = RGB(68, 114, 196)
    '                        End If

    '                        ColTotales(0, T) = i
    '                        ColTotales(1, T) = BColor
    '                        T += 1
    '                        If UBound(ColTotales, 2) < T Then
    '                            ReDim Preserve ColTotales(1, T)
    '                        End If
    '                        'BColor = RGB(255, 255, 255)
    '                    End If
    '                    wSheet.Cells(4, i).Value = dCol("tipo").ToString.Trim
    '                End If
    '                If E = "" Or E = "" Then
    '                    _range = wSheet.Range(wSheet.Cells(4, i), wSheet.Cells(5, i))
    '                Else
    '                    _range = wSheet.Range(wSheet.Cells(4, i), wSheet.Cells(4, i))
    '                End If
    '                _range.Interior.Color = BColor
    '                _range.Font.Color = FColor
    '                wSheet.Cells(5, i).Value = dCol("nombre").Trim
    '                wSheet.Cells(6, i).Value = dCol("concepto").Trim
    '            Next

    '            ReDim Preserve ColTotales(1, T - 1)
    '            _range = wSheet.Range(wSheet.Cells(5, 12), wSheet.Cells(5, i))
    '            _range.Orientation = 90

    '            wSheet.Range("a7").CopyFromRecordset(datosRec)

    '            _range = wSheet.Range(wSheet.Cells(7, 11), wSheet.Cells(datosRec.RecordCount + 7, i))
    '            _range.NumberFormat = "#,##0.00"
    '            _range = wSheet.Range(wSheet.Cells(7, 13), wSheet.Cells(datosRec.RecordCount + 7, 14))
    '            _range.NumberFormat = "dd-mm-yyyy"

    '            wSheet.Range("D1").Select()
    '            ExcelAPP.ActiveWindow.FreezePanes = True

    '            For Ix = 0 To UBound(ColTotales, 2)
    '                Columna = ColTotales(0, Ix)
    '                Renglon = 5
    '                _range = wSheet.Range(wSheet.Cells(Renglon, Columna), wSheet.Cells(datosRec.RecordCount + 7, Columna))
    '                _range.Interior.Color = ColTotales(1, Ix)
    '                _range.Font.Bold = True
    '            Next

    '            'La columna en la que se encuentra el reloj
    '            Dim columna_reloj As Integer = 3
    '            For Ix = 7 To datosRec.RecordCount + 6
    '                If Not wSheet.Cells(Ix, columna_reloj).value Is Nothing Then
    '                    If wSheet.Cells(Ix, columna_reloj).value.ToString.Contains("*") Then
    '                        _range = wSheet.Range(wSheet.Cells(Ix, 1), wSheet.Cells(Ix, i))
    '                        _range.Interior.Color = Color.FromArgb(RGB(198, 239, 206))
    '                        _range.Font.Color = Color.DarkGreen
    '                    End If
    '                    If wSheet.Cells(Ix, columna_reloj).value.ToString.Contains("-") Then
    '                        _range = wSheet.Range(wSheet.Cells(Ix, 1), wSheet.Cells(Ix, i))
    '                        _range.Interior.Color = Color.FromArgb(RGB(240, 199, 198))
    '                        _range.Font.Color = Color.DarkRed
    '                    End If
    '                End If
    '            Next


    '            datosRec.Close()


    '            wSheet.Rows.WrapText = False
    '            wSheet.Rows(5).WrapText = True
    '            wSheet.Rows(5).rowheight = 90
    '            Dim blnFileOpen As Boolean = False

    '            Dim frmSave As New Windows.Forms.SaveFileDialog
    '            frmSave.Filter = "Archivo excel (XLSX)|*.xlsx"

    '            frmSave.ShowDialog()
    '            If frmSave.FileName <> "" Then
    '                NombreArchivo = frmSave.FileName
    '                NombreArchivo = IIf(NombreArchivo.ToLower.Contains(".xlsx"), NombreArchivo, NombreArchivo & ".xlsx")
    '            End If

    '            ExcelAPP.Visible = True
    '            Try
    '                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(NombreArchivo)
    '                fileTemp.Close()
    '                blnFileOpen = True
    '            Catch ex As Exception
    '                blnFileOpen = False
    '                MessageBox.Show("El archivo " & NombreArchivo & " no pudo ser guardado. " & _
    '                                "Si el problema persiste, contacte al administrador del sistema." & vbCrLf & vbCrLf & _
    '                                "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nomina.vb", ex.HResult, ex.Message)
    '            End Try

    '            If blnFileOpen Then
    '                If System.IO.File.Exists(NombreArchivo) Then
    '                    System.IO.File.Delete(NombreArchivo)
    '                End If

    '                wBook.SaveAs(NombreArchivo)
    '            End If


    '            releaseObject(wSheet)
    '            releaseObject(wBook)


    '        Catch ex As Exception
    '            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)

    '        End Try

    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)
    '        dtDatos = New DataTable
    '    Finally
    '        releaseObject(ExcelAPP)
    '    End Try
    'End Sub

    Public Sub Cajadeahorro(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "")
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))

            For Each row As DataRow In dtInformacion.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")
                dr("nombres") = row("nombres")

                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")
                dr("cod_clase") = row("cod_clase")

                Try
                    dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
                    dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                Catch ex As Exception

                End Try

                dr("ano") = _ano
                dr("periodo") = _periodo

                Dim monto_ As Double = IIf(IsDBNull(row("AHOALC")), 0, row("AHOALC"))

                dr("monto") = monto_

                If monto_ > 0 Then
                    dtDatos.Rows.Add(dr)
                End If
            Next

            nombre_archivo = nombre_archivo.Replace("YYYY", _ano)
            nombre_archivo = nombre_archivo.Replace("XX", _periodo)

            Dim oWrite As System.IO.StreamWriter
            Try
                oWrite = File.CreateText(nombre_archivo)

                Dim consecutivo As Integer = 1
                For Each row As DataRow In dtDatos.Rows

                    Dim linea As String = ""

                    linea &= Int(row("reloj")).ToString & ","
                    linea &= "TITULAR" & ","

                    Dim monto As Double = Math.Round(row("monto"), 2)
                    linea &= String.Format("{0:0.00}", monto)

                    oWrite.WriteLine(linea)
                    consecutivo += 1

                Next
                oWrite.Close()

            Catch ex As Exception
                oWrite = Nothing
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub CompensacionTunel(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "")
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))

            For Each row As DataRow In dtInformacion.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")
                dr("nombres") = row("nombres")

                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")
                dr("cod_clase") = row("cod_clase")

                Try
                    dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
                    dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                Catch ex As Exception

                End Try

                dr("ano") = _ano
                dr("periodo") = _periodo

                Dim monto_ As Double = IIf(IsDBNull(row("CTUNEL")), 0, row("CTUNEL"))

                dr("monto") = monto_

                If monto_ > 0 Then
                    dtDatos.Rows.Add(dr)
                End If
            Next

            nombre_archivo = nombre_archivo.Replace("YYYY", _ano)
            nombre_archivo = nombre_archivo.Replace("XX", _periodo)

            Dim oWrite As System.IO.StreamWriter
            Try
                oWrite = File.CreateText(nombre_archivo)

                Dim consecutivo As Integer = 1
                For Each row As DataRow In dtDatos.Rows

                    Dim linea As String = ""

                    linea &= Int(row("reloj")).ToString & ","
                    linea &= "TITULAR" & ","

                    Dim monto As Double = Math.Round(row("monto"), 2)
                    linea &= String.Format("{0:0.00}", monto)

                    oWrite.WriteLine(linea)
                    consecutivo += 1

                Next
                oWrite.Close()

            Catch ex As Exception
                oWrite = Nothing
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub CuotaSindical(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "")
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))

            For Each row As DataRow In dtInformacion.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")
                dr("nombres") = row("nombres")

                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")
                dr("cod_clase") = row("cod_clase")

                Try
                    dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
                    dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                Catch ex As Exception

                End Try

                dr("ano") = _ano
                dr("periodo") = _periodo

                Dim monto_ As Double = IIf(IsDBNull(row("CUOSIN")), 0, row("CUOSIN"))

                dr("monto") = monto_

                If monto_ > 0 Then
                    dtDatos.Rows.Add(dr)
                End If
            Next

            nombre_archivo = nombre_archivo.Replace("YYYY", _ano)
            nombre_archivo = nombre_archivo.Replace("XX", _periodo)

            Dim oWrite As System.IO.StreamWriter
            Try
                oWrite = File.CreateText(nombre_archivo)

                Dim consecutivo As Integer = 1
                For Each row As DataRow In dtDatos.Rows

                    Dim linea As String = ""

                    linea &= Int(row("reloj")).ToString & ","
                    linea &= "TITULAR" & ","

                    Dim monto As Double = Math.Round(row("monto"), 2)
                    linea &= String.Format("{0:0.00}", monto)

                    oWrite.WriteLine(linea)
                    consecutivo += 1

                Next
                oWrite.Close()

            Catch ex As Exception
                oWrite = Nothing
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub PrestamoCajaAhorro(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "")
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))

            For Each row As DataRow In dtInformacion.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")
                dr("nombres") = row("nombres")

                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")
                dr("cod_clase") = row("cod_clase")

                Try
                    dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
                    dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                Catch ex As Exception

                End Try

                dr("ano") = _ano
                dr("periodo") = _periodo

                Dim monto_ As Double = IIf(IsDBNull(row("CAJPMO")), 0, row("CAJPMO"))

                dr("monto") = monto_

                If monto_ > 0 Then
                    dtDatos.Rows.Add(dr)
                End If
            Next

            nombre_archivo = nombre_archivo.Replace("YYYY", _ano)
            nombre_archivo = nombre_archivo.Replace("XX", _periodo)

            Dim oWrite As System.IO.StreamWriter
            Try
                oWrite = File.CreateText(nombre_archivo)

                Dim consecutivo As Integer = 1
                For Each row As DataRow In dtDatos.Rows

                    Dim linea As String = ""

                    linea &= Int(row("reloj")).ToString & ","
                    linea &= "TITULAR" & ","

                    Dim monto As Double = Math.Round(row("monto"), 2)
                    linea &= String.Format("{0:0.00}", monto)

                    oWrite.WriteLine(linea)
                    consecutivo += 1

                Next
                oWrite.Close()

            Catch ex As Exception
                oWrite = Nothing
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub AportacionesFondodeAhorro(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "")
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))

            For Each row As DataRow In dtInformacion.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")
                dr("nombres") = row("nombres")

                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")
                dr("cod_clase") = row("cod_clase")

                Try
                    dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
                    dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                Catch ex As Exception

                End Try

                dr("ano") = _ano
                dr("periodo") = _periodo

                Dim monto_ As Double = IIf(IsDBNull(row("APOFAH")), 0, row("APOFAH"))

                dr("monto") = monto_

                If monto_ > 0 Then
                    dtDatos.Rows.Add(dr)
                End If
            Next

            nombre_archivo = nombre_archivo.Replace("YYYY", _ano)
            nombre_archivo = nombre_archivo.Replace("XX", _periodo)

            Dim oWrite As System.IO.StreamWriter
            Try
                oWrite = File.CreateText(nombre_archivo)

                Dim consecutivo As Integer = 1
                For Each row As DataRow In dtDatos.Rows

                    Dim linea As String = ""

                    linea &= Int(row("reloj")).ToString & ","
                    linea &= "TITULAR" & ","

                    Dim monto As Double = Math.Round(row("monto"), 2)
                    linea &= String.Format("{0:0.00}", monto)

                    oWrite.WriteLine(linea)
                    consecutivo += 1

                Next
                oWrite.Close()

            Catch ex As Exception
                oWrite = Nothing
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub NominaExcelCC1(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal Ingles As Boolean)
        Dim dtConceptos As New DataTable
        Dim dDato As DataRow
        Dim dtNombreEspIng As New DataTable
        ' Dim Depto As String
        Dim i As Integer
        Dim dtCias As New DataTable
        Dim AntClase As String = ""
        Dim CC As String = ""

        Dim Ix As Integer = 0
        Dim J As Integer = 0
        Dim ExcelAPP As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim _range As Excel.Range

        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("ano")
            dtDatos.Columns.Add("periodo")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("puesto")
            dtDatos.Columns.Add("clase")
            dtDatos.Columns.Add("idcc")
            dtDatos.Columns.Add("cod_depto")
            dtDatos.Columns.Add("depto")

            dtDatos.Columns.Add("turno")
            dtDatos.Columns.Add("horas_turno", GetType(System.Double))
            dtDatos.Columns.Add("sactual", GetType(System.Double))
            dtDatos.Columns.Add("alta")
            dtDatos.Columns.Add("baja")
            dtDatos.Columns.Add("numimss")

            If Ingles Then
                dtConceptos = sqlExecute("SELECT concepto,nombre_ingles AS nombre,COD_NATURALEZA,prioridad,0 as orden," & _
                                 "IIF(cod_naturaleza = 'HD','INFORMATION'," & _
                                    "IIF(cod_naturaleza= 'P','PERCEPTION'," & _
                                        "IIF(cod_naturaleza= 'D','DEDUCTION'," & _
                                        "IIF(cod_naturaleza = 'I','TAXES AND EXCEPTIONS','')))) AS tipo " & _
                                "FROM conceptos WHERE NOT nombre_ingles IS NULL AND nombre_ingles <> 'NA' ORDER BY " & _
                                "prioridad", "NOMINA")
            Else
                'dtConceptos = sqlExecute("SELECT concepto,nombre,COD_NATURALEZA,prioridad,0 as orden," & _
                '                   "IIF(cod_naturaleza = 'HD','INFORMATIVOS'," & _
                '                      "IIF(cod_naturaleza= 'P','PERCEPCIONES'," & _
                '                          "IIF(cod_naturaleza= 'D','DEDUCCIONES'," & _
                '                          "IIF(cod_naturaleza = 'I','EXENTOS E IMPUESTOS','')))) AS tipo " & _
                '                  "FROM nomina.dbo.conceptos WHERE NOT nombre_ingles IS NULL ORDER BY " & _
                '                  "prioridad")
                dtConceptos = sqlExecute("select concepto, nombre, cod_naturaleza,prioridad,0 as orden," & _
                                        "case when cod_naturaleza = 'HD' then 'INFORMATIVOS' " & _
                                            "else case when cod_naturaleza = 'P' then 'PERCEPCIONES'" & _
                                                "else case when cod_naturaleza = 'D' then 'DEDUCCIONES' " & _
                                                    "else case when cod_naturaleza = 'I' then 'EXENTOS E IMPUESTOS' " & _
                                                    "else '' end end end end as 'tipo'" & _
                                        "from nomina.dbo.conceptos where not NOMBRE_INGLES is null order by " & _
                                        "prioridad")
            End If

            dtConceptos.PrimaryKey = New DataColumn() {dtConceptos.Columns("concepto")}

            i = 0
            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'HD'", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next

            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'P' AND concepto NOT IN ('BONDES','TOTPER','NETO')", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next
            i += 1
            dDato = dtConceptos.Rows.Find("TOTPER")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("TOTPER", GetType(System.Double))
            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'D' AND concepto NOT IN ('TOTDED','NETO')", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next
            i += 1
            dDato = dtConceptos.Rows.Find("TOTDED")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("TOTDED", GetType(System.Double))

            i += 1
            dDato = dtConceptos.Rows.Find("NETO")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("NETO", GetType(System.Double))
            i += 1
            dDato = dtConceptos.Rows.Find("BONDES")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("BONDES", GetType(System.Double))

            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'I'", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next

            Dim Renglon As Integer = 7
            Dim Columna As Integer = 10
            Dim RenglonAnt As Integer = 7
            Dim dTotal As DataRow
            Dim dTotalGeneral As DataRow
            Dim dCc As DataRow

            dTotal = dtDatos.NewRow
            dTotalGeneral = dtDatos.NewRow
            dCc = dtDatos.NewRow

            dtInformacion.Columns.Add("clasifica")
            For Each dEmpleado As DataRow In dtInformacion.Rows
                dEmpleado("clasifica") = IIf(dEmpleado("cod_clase") = "G", "A", dEmpleado("cod_clase"))
            Next

            For Each dEmpleado As DataRow In dtInformacion.Select("", "clasifica,centro_costos")

                dDato = dtDatos.NewRow

                dDato("ano") = dEmpleado("ano")
                dDato("periodo") = dEmpleado("periodo")
                dDato("clase") = ""
                dDato("reloj") = dEmpleado("reloj")
                dDato("nombres") = dEmpleado("nombres")
                dDato("numimss") = IIf(IsDBNull(dEmpleado("numimss")), "", dEmpleado("numimss"))
                dDato("sactual") = dEmpleado("sactual")
                dDato("alta") = Format(dEmpleado("alta"), "MM/dd/yyyy")

                If IsDBNull(dEmpleado("baja")) Then
                    dDato("baja") = ""
                Else
                    dDato("baja") = Format(dEmpleado("baja"), "MM/dd/yyyy")
                End If

                dDato("turno") = dEmpleado("cod_turno")
                dDato("idcc") = IIf(IsDBNull(dEmpleado("centro_costos")), "", dEmpleado("centro_costos")).ToString.Trim
                dDato("cod_depto") = IIf(IsDBNull(dEmpleado("cod_depto")), "", dEmpleado("cod_depto")).ToString.Trim

                dtTemp = sqlExecute("SELECT horas FROM turnos WHERE cod_comp = '" & dEmpleado("cod_comp") & _
                                    "' AND cod_turno ='" & dEmpleado("cod_turno") & "'")
                If dtTemp.Rows.Count > 0 Then
                    dDato("horas_turno") = dtTemp.Rows(0).Item("horas")
                End If

                If Ingles Then
                    dtNombreEspIng = sqlExecute("SELECT deptos.nombre_ingles AS depto,puestos.nombre_ingles AS puesto," & _
                                                 "clase.nombre_ingles AS clase FROM personal " & _
                                                 "LEFT JOIN deptos ON deptos.cod_depto = personal.cod_depto AND deptos.cod_comp = personal.cod_comp " & _
                                                 "LEFT JOIN puestos ON puestos.cod_puesto = personal.cod_puesto AND puestos.cod_comp = personal.cod_comp " & _
                                                 "LEFT JOIN clase ON clase.cod_clase = case when personal.cod_clase = 'G' then 'A' else personal.cod_clase end AND clase.cod_comp = personal.cod_comp " & _
                                                 "WHERE reloj = '" & dEmpleado("reloj") & "'")
                Else
                    dtNombreEspIng = sqlExecute("SELECT deptos.nombre AS depto,puestos.nombre AS puesto," & _
                                             "clase.nombre AS clase FROM personal " & _
                                             "LEFT JOIN deptos ON deptos.cod_depto = personal.cod_depto AND deptos.cod_comp = personal.cod_comp " & _
                                             "LEFT JOIN puestos ON puestos.cod_puesto = personal.cod_puesto AND puestos.cod_comp = personal.cod_comp " & _
                                             "LEFT JOIN clase ON clase.cod_clase =case when personal.cod_clase = 'G' then 'A' else personal.cod_clase end AND clase.cod_comp = personal.cod_comp " & _
                                             "WHERE reloj = '" & dEmpleado("reloj") & "'")
                End If

                If dtNombreEspIng.Rows.Count > 0 Then
                    dDato("depto") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("depto")), "", dtNombreEspIng.Rows(0).Item("depto")).ToString.Trim
                    dDato("puesto") = dEmpleado("cod_puesto") & " " & IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("puesto")), "", dtNombreEspIng.Rows(0).Item("puesto")).ToString.Trim
                    dDato("clase") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("clase")), "", dtNombreEspIng.Rows(0).Item("clase")).ToString.Trim
                End If

                If dDato("idcc") <> CC And CC <> "" Then
                    dCc("reloj") = "------"
                    dCc("nombres") = "Centro de Costos:"
                    dCc("idcc") = CC
                    dtDatos.Rows.Add(dCc)
                    dCc = dtDatos.NewRow
                End If


                If dDato("clase") <> AntClase And AntClase <> "" Then
                    dTotal("reloj") = "******"
                    dTotal("nombres") = "TOTAL"
                    dTotal("clase") = AntClase
                    dtDatos.Rows.Add(dTotal)
                    dTotal = dtDatos.NewRow
                End If








                For Each dConcepto As DataRow In dtConceptos.Rows
                    Try
                        dDato(dConcepto("concepto").ToString.Trim) = dEmpleado(dConcepto("concepto").ToString.Trim)
                        'IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))

                        dTotal(dConcepto("concepto").ToString.Trim) = _
                            IIf(IsDBNull(dTotal(dConcepto("concepto").ToString.Trim)), 0, dTotal(dConcepto("concepto").ToString.Trim)) + _
                                IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))
                        dTotalGeneral(dConcepto("concepto").ToString.Trim) = _
                            IIf(IsDBNull(dTotalGeneral(dConcepto("concepto").ToString.Trim)), 0, dTotalGeneral(dConcepto("concepto").ToString.Trim)) + _
                                IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))
                    Catch ex As Exception
                        'Si algún concepto no se localiza en la tabla de información
                        'Igualar a -1 para que sea fácilmente identificable
                        dDato(dConcepto("concepto").ToString.Trim) = -1
                    End Try
                Next

                dtDatos.Rows.Add(dDato)
                AntClase = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("clase")), "", dtNombreEspIng.Rows(0).Item("clase")).ToString.Trim
                CC = dDato("idcc")
                Renglon += 1
            Next

            dTotal("reloj") = "******"
            dTotal("nombres") = "TOTAL"
            dTotal("clase") = AntClase
            dtDatos.Rows.Add(dTotal)

            'dCc("reloj") = "******"
            'dCc("nombres") = "Centro de Costos:"
            'dCc("clase") = dDato("idcc")
            'dtDatos.Rows.Add(dCc)

            dTotalGeneral("reloj") = "******"
            dTotalGeneral("nombres") = "TOTAL GENERAL"
            dtDatos.Rows.Add(dTotalGeneral)

            Dim datosRec As ADODB.Recordset
            datosRec = DataTableTORecordset(dtDatos)


            'Exportar a archivo excel con formato

            Try

                Dim NombreArchivo As String = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyDocuments & "\logo.jpg"
                ExcelAPP.Visible = False
                wBook = ExcelAPP.Workbooks.Add
                wSheet = wBook.ActiveSheet()
                wSheet.Name = "PIDA"

                'Buscar el logo de la compañía, tomando como base al primer empleado
                dtCias = sqlExecute("SELECT logo FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                If dtCias.Rows.Count > 0 Then
                    If Not IsDBNull(dtCias.Rows(0).Item("logo")) Then
                        'Guardar el logo en MyDocuments como logo.jpg
                        Dim imageInBytes As Byte() = dtCias.Rows(0).Item("logo")
                        Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(imageInBytes, False)
                        Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream)
                        image.Save(NombreArchivo)
                        'Insertar el logo en el excel
                        wSheet.Shapes.AddPicture(NombreArchivo, False, True, 0, 0, 50, 35)
                    End If
                End If

                'wSheet.Shapes.AddPicture("c:\archivo.jpg", False, True, 0, 0, 45, 50)
                If Ingles Then
                    wSheet.Cells(1, 2).Value = dtInformacion.Rows(0).Item("COMPANIA")
                    wSheet.Cells(2, 2).Value = "PAYROLL WEEK " & dtInformacion.Rows(0).Item("PERIODO") & "-" & dtInformacion.Rows(0).Item("ANO")


                    wSheet.Cells(6, 1).Value = "Year"
                    wSheet.Cells(6, 2).Value = "Week"
                    wSheet.Cells(6, 3).Value = "ID"
                    wSheet.Cells(6, 4).Value = "Name"
                    wSheet.Cells(6, 5).Value = "Position"
                    wSheet.Cells(6, 6).Value = "Category"
                    wSheet.Cells(6, 7).Value = "IDCC"
                    wSheet.Cells(6, 8).Value = "Dept."
                    wSheet.Cells(6, 9).Value = "Dept. Name"
                    wSheet.Cells(6, 10).Value = "Shift"
                    wSheet.Cells(6, 11).Value = "Hours per shift"
                    wSheet.Cells(6, 12).Value = "Daily Salary"
                    wSheet.Cells(6, 13).Value = "Hiring Date"
                    wSheet.Cells(6, 14).Value = "Termination Date"
                    wSheet.Cells(6, 15).Value = "IMSS"
                Else
                    wSheet.Cells(1, 2).Value = dtInformacion.Rows(0).Item("COMPANIA")
                    wSheet.Cells(2, 2).Value = "NOMINA SEMANA " & dtInformacion.Rows(0).Item("PERIODO") & "-" & dtInformacion.Rows(0).Item("ANO")

                    wSheet.Cells(6, 1).Value = "Año"
                    wSheet.Cells(6, 2).Value = "Periodo"
                    wSheet.Cells(6, 3).Value = "Reloj"
                    wSheet.Cells(6, 4).Value = "Nombre"
                    wSheet.Cells(6, 5).Value = "Puesto"
                    wSheet.Cells(6, 6).Value = "Clasificación"
                    wSheet.Cells(6, 7).Value = "IDCC"
                    wSheet.Cells(6, 8).Value = "Depto."
                    wSheet.Cells(6, 9).Value = "Nombre Depto."
                    wSheet.Cells(6, 10).Value = "Turno"
                    wSheet.Cells(6, 11).Value = "Horas por turno"
                    wSheet.Cells(6, 12).Value = "Sueldo diario"
                    wSheet.Cells(6, 13).Value = "Fecha alta"
                    wSheet.Cells(6, 14).Value = "Fecha baja"
                    wSheet.Cells(6, 15).Value = "IMSS"
                End If
                wSheet.Range("B1", "B2").Font.Bold = True
                wSheet.Range("B1", "B2").Font.Size = 16


                i = 15
                Dim T As Integer = 0
                Dim E As String = ""
                Dim BColor As Integer = RGB(255, 255, 255)
                Dim FColor As Integer = RGB(0, 0, 0)
                Dim ColTotales(,) As String
                ReDim ColTotales(1, 5)

                For Each dCol As DataRow In dtConceptos.Select("", "orden")
                    i += 1

                    If E <> dCol("cod_naturaleza").ToString.Trim Then
                        E = dCol("cod_naturaleza").ToString.Trim
                        FColor = RGB(0, 0, 0)
                        If E = "HD" Then
                            BColor = RGB(165, 165, 165)
                            FColor = RGB(255, 255, 255)
                        ElseIf E = "P" Then
                            If dCol("concepto").ToString.Trim = "BONDES" Then
                                BColor = -4142
                                dCol("tipo") = ""
                            Else
                                BColor = RGB(198, 239, 206)
                            End If

                        ElseIf E = "D" Then
                            BColor = RGB(0, 192, 255)
                        ElseIf E = "I" Then
                            BColor = RGB(248, 203, 173)
                        ElseIf E = "T" Then
                            E = "H"
                            If dCol("concepto").ToString.Trim = "NETO" Then
                                BColor = RGB(68, 114, 196)
                            End If

                            ColTotales(0, T) = i
                            ColTotales(1, T) = BColor
                            T += 1
                            If UBound(ColTotales, 2) < T Then
                                ReDim Preserve ColTotales(1, T)
                            End If
                            'BColor = RGB(255, 255, 255)
                        End If
                        wSheet.Cells(4, i).Value = dCol("tipo").ToString.Trim
                    End If
                    If E = "HD" Or E = "I" Then
                        _range = wSheet.Range(wSheet.Cells(4, i), wSheet.Cells(5, i))
                    Else
                        _range = wSheet.Range(wSheet.Cells(4, i), wSheet.Cells(4, i))
                    End If
                    _range.Interior.Color = BColor
                    _range.Font.Color = FColor
                    wSheet.Cells(5, i).Value = dCol("nombre").Trim
                    wSheet.Cells(6, i).Value = dCol("concepto").Trim
                Next

                ReDim Preserve ColTotales(1, T - 1)
                _range = wSheet.Range(wSheet.Cells(5, 12), wSheet.Cells(5, i))
                _range.Orientation = 90
                wSheet.Range("a7").CopyFromRecordset(datosRec)

                _range = wSheet.Range(wSheet.Cells(7, 11), wSheet.Cells(datosRec.RecordCount + 7, i))
                _range.NumberFormat = "#,##0.00"
                _range = wSheet.Range(wSheet.Cells(7, 13), wSheet.Cells(datosRec.RecordCount + 7, 14))
                _range.NumberFormat = "dd-mm-yyyy"

                wSheet.Range("D1").Select()
                ExcelAPP.ActiveWindow.FreezePanes = True

                For Ix = 0 To UBound(ColTotales, 2)
                    Columna = ColTotales(0, Ix)
                    Renglon = 5
                    _range = wSheet.Range(wSheet.Cells(Renglon, Columna), wSheet.Cells(datosRec.RecordCount + 7, Columna))
                    _range.Interior.Color = ColTotales(1, Ix)
                    _range.Font.Bold = True
                Next

                'La columna en la que se encuentra el reloj
                Dim columna_reloj As Integer = 3
                For Ix = 7 To datosRec.RecordCount + 6
                    If Not wSheet.Cells(Ix, columna_reloj).value Is Nothing Then
                        If wSheet.Cells(Ix, columna_reloj).value.ToString.Contains("*") Then
                            _range = wSheet.Range(wSheet.Cells(Ix, 1), wSheet.Cells(Ix, i))
                            _range.Interior.Color = Color.FromArgb(RGB(198, 239, 206))
                            _range.Font.Color = Color.DarkGreen
                        End If
                        If wSheet.Cells(Ix, columna_reloj).value.ToString.Contains("-") Then
                            _range = wSheet.Range(wSheet.Cells(Ix, 1), wSheet.Cells(Ix, i))
                            _range.Interior.Color = Color.FromArgb(RGB(240, 199, 198))
                            _range.Font.Color = Color.DarkRed
                        End If
                    End If
                Next
                datosRec.Close()


                wSheet.Rows.WrapText = False
                wSheet.Rows(5).WrapText = True
                wSheet.Rows(5).rowheight = 90
                Dim blnFileOpen As Boolean = False

                Dim frmSave As New Windows.Forms.SaveFileDialog
                frmSave.Filter = "Archivo excel (XLSX)|*.xlsx"

                frmSave.ShowDialog()
                If frmSave.FileName <> "" Then
                    NombreArchivo = frmSave.FileName
                    NombreArchivo = IIf(NombreArchivo.ToLower.Contains(".xlsx"), NombreArchivo, NombreArchivo & ".xlsx")
                End If

                ExcelAPP.Visible = True
                Try
                    Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(NombreArchivo)
                    fileTemp.Close()
                    blnFileOpen = True
                Catch ex As Exception
                    blnFileOpen = False
                    MessageBox.Show("El archivo " & NombreArchivo & " no pudo ser guardado. " & _
                                    "Si el problema persiste, contacte al administrador del sistema." & vbCrLf & vbCrLf & _
                                    "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nomina.vb", ex.HResult, ex.Message)
                End Try

                If blnFileOpen Then
                    If System.IO.File.Exists(NombreArchivo) Then
                        System.IO.File.Delete(NombreArchivo)
                    End If

                    wBook.SaveAs(NombreArchivo)
                End If


                releaseObject(wSheet)
                releaseObject(wBook)


            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)

            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)
            dtDatos = New DataTable
        Finally
            releaseObject(ExcelAPP)
        End Try
    End Sub
    Public Sub NominaExcelCC(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal Ingles As Boolean)
        Dim dtConceptos As New DataTable
        Dim dDato As DataRow
        Dim dtNombreEspIng As New DataTable
        ' Dim Depto As String
        Dim i As Integer
        Dim dtCias As New DataTable
        Dim AntClase As String = ""
        Dim CC As String = ""

        Dim Ix As Integer = 0
        Dim J As Integer = 0
        Dim ExcelAPP As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim _range As Excel.Range

        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("ano")
            dtDatos.Columns.Add("periodo")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("cod_tipo")
            dtDatos.Columns.Add("clase")
            dtDatos.Columns.Add("idcc")
            dtDatos.Columns.Add("rfc")
            dtDatos.Columns.Add("cod_depto")
            dtDatos.Columns.Add("num_imss")
            dtDatos.Columns.Add("alta")
            dtDatos.Columns.Add("alta_antig")
            dtDatos.Columns.Add("baja")
            dtDatos.Columns.Add("sactual")
            dtDatos.Columns.Add("integrado")
            dtDatos.Columns.Add("cod_puesto")
            dtDatos.Columns.Add("puesto")

            'dtDatos.Columns.Add("idcc")
            'dtDatos.Columns.Add("depto")
            'dtDatos.Columns.Add("turno")
            'dtDatos.Columns.Add("horas_turno", GetType(System.Double))

            dtConceptos = sqlExecute("select concepto, nombre, cod_naturaleza,prioridad,0 as orden," & _
                                    "case when cod_naturaleza = 'I' then 'INFORMATIVOS' " & _
                                        "else case when cod_naturaleza = 'P' then 'PERCEPCIONES'" & _
                                            "else case when cod_naturaleza = 'D' then 'DEDUCCIONES' " & _
                                                "else case when cod_naturaleza = 'E' then 'EXENTOS' " & _
                                                    "else '' end end end end as 'tipo'" & _
                                    "from nomina.dbo.conceptos where cod_naturaleza not in('A','V') and not NOMBRE_INGLES is null order by " & _
                                    "prioridad")

            dtConceptos.PrimaryKey = New DataColumn() {dtConceptos.Columns("concepto")}

            i = 0
            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'P' AND concepto NOT IN ('BONDES','TOTPER','NETO')", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next

            i += 1
            dDato = dtConceptos.Rows.Find("TOTPER")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("TOTPER", GetType(System.Double))

            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'D' AND concepto NOT IN ('TOTDED','NETO')", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next

            i += 1
            dDato = dtConceptos.Rows.Find("TOTDED")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("TOTDED", GetType(System.Double))

            i += 1
            dDato = dtConceptos.Rows.Find("NETO")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("NETO", GetType(System.Double))
            i += 1
            dDato = dtConceptos.Rows.Find("BONDES")
            If Not dDato Is Nothing Then
                dDato("orden") = i
            End If
            dtDatos.Columns.Add("BONDES", GetType(System.Double))

            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza = 'E'", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next

            For Each dConcepto As DataRow In dtConceptos.Select("cod_naturaleza in ('I', 'V')", "prioridad")
                i += 1
                dConcepto("orden") = i
                dtDatos.Columns.Add(dConcepto("concepto").ToString.Trim, GetType(System.Double))
            Next


            '-----------------------------------------------------------------------------------------------------------------------------------
            Dim Renglon As Integer = 7
            Dim Columna As Integer = 10
            Dim RenglonAnt As Integer = 7
            Dim dTotal As DataRow
            Dim dTotalGeneral As DataRow
            Dim dCc As DataRow

            dTotal = dtDatos.NewRow
            dTotalGeneral = dtDatos.NewRow
            dCc = dtDatos.NewRow

            dtInformacion.Columns.Add("clasifica")
            For Each dEmpleado As DataRow In dtInformacion.Rows
                dEmpleado("clasifica") = IIf(dEmpleado("cod_clase") = "G", "A", dEmpleado("cod_clase"))
            Next

            For Each dEmpleado As DataRow In dtInformacion.Select("", "clasifica")

                dDato = dtDatos.NewRow

                dDato("ano") = dEmpleado("ano")
                dDato("periodo") = dEmpleado("periodo")
                dDato("reloj") = dEmpleado("reloj")
                dDato("nombres") = dEmpleado("nombres")
                dDato("cod_tipo") = dEmpleado("cod_tipo")
                dDato("idcc") = IIf(IsDBNull(dEmpleado("centro_costos")), "", dEmpleado("centro_costos")).ToString.Trim
                dDato("rfc") = dEmpleado("rfc")
                dDato("cod_depto") = IIf(IsDBNull(dEmpleado("cod_depto")), "", dEmpleado("cod_depto")).ToString.Trim
                dDato("num_imss") = IIf(IsDBNull(dEmpleado("numimss")), "", dEmpleado("numimss"))
                dDato("alta") = Format(dEmpleado("alta"), "MM/dd/yyyy")
                ' dDato("alta_antig") = Format(dEmpleado("alta"), "MM/dd/yyyy")
                'dDato("alta_antig") = IIf(IsDBNull(dEmpleado("alta_vacacion")), "", dEmpleado("alta_vacacion"))
                If IsDBNull(dEmpleado("baja")) Then
                    dDato("baja") = ""
                Else
                    dDato("baja") = Format(dEmpleado("baja"), "MM/dd/yyyy")
                End If
                dDato("sactual") = dEmpleado("sactual")
                dDato("integrado") = dEmpleado("integrado")

                ' dDato("turno") = dEmpleado("cod_turno")
                'dDato("idcc") = IIf(IsDBNull(dEmpleado("centro_costos")), "", dEmpleado("centro_costos")).ToString.Trim
                'dtTemp = sqlExecute("SELECT horas FROM turnos WHERE cod_comp = '" & dEmpleado("cod_comp") & _
                '                    "' AND cod_turno ='" & dEmpleado("cod_turno") & "'")
                'If dtTemp.Rows.Count > 0 Then
                '    dDato("horas_turno") = dtTemp.Rows(0).Item("horas")
                'End If

                If Ingles Then
                    dtNombreEspIng = sqlExecute("SELECT deptos.nombre_ingles AS depto,puestos.nombre_ingles AS puesto," & _
                                                 "clase.nombre_ingles AS clase FROM personal " & _
                                                 "LEFT JOIN deptos ON deptos.cod_depto = personal.cod_depto AND deptos.cod_comp = personal.cod_comp " & _
                                                 "LEFT JOIN puestos ON puestos.cod_puesto = personal.cod_puesto AND puestos.cod_comp = personal.cod_comp " & _
                                                 "LEFT JOIN clase ON clase.cod_clase = case when personal.cod_clase = 'G' then 'A' else personal.cod_clase end AND clase.cod_comp = personal.cod_comp " & _
                                                 "WHERE reloj = '" & dEmpleado("reloj") & "'")
                Else
                    dtNombreEspIng = sqlExecute("SELECT deptos.nombre AS depto,puestos.nombre AS puesto," & _
                                             "clase.nombre AS clase FROM personal " & _
                                             "LEFT JOIN deptos ON deptos.cod_depto = personal.cod_depto AND deptos.cod_comp = personal.cod_comp " & _
                                             "LEFT JOIN puestos ON puestos.cod_puesto = personal.cod_puesto AND puestos.cod_comp = personal.cod_comp " & _
                                             "LEFT JOIN clase ON clase.cod_clase =case when personal.cod_clase = 'G' then 'A' else personal.cod_clase end AND clase.cod_comp = personal.cod_comp " & _
                                             "WHERE reloj = '" & dEmpleado("reloj") & "'")
                End If

                If dtNombreEspIng.Rows.Count > 0 Then
                    ' dDato("depto") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("depto")), "", dtNombreEspIng.Rows(0).Item("depto")).ToString.Trim
                    dDato("clase") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("clase")), "", dtNombreEspIng.Rows(0).Item("clase")).ToString.Trim
                    dDato("cod_puesto") = dEmpleado("cod_puesto")
                    dDato("puesto") = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("puesto")), "", dtNombreEspIng.Rows(0).Item("puesto")).ToString.Trim
                End If

                If dDato("idcc") <> CC And CC <> "" Then
                    dCc("reloj") = "------"
                    dCc("nombres") = "Centro de Costos:"
                    dCc("idcc") = CC
                    dtDatos.Rows.Add(dCc)
                    dCc = dtDatos.NewRow
                End If

                If dDato("clase") <> AntClase And AntClase <> "" Then
                    dTotal("reloj") = "******"
                    dTotal("nombres") = "TOTAL"
                    dTotal("clase") = AntClase
                    dtDatos.Rows.Add(dTotal)
                    dTotal = dtDatos.NewRow
                End If

                For Each dConcepto As DataRow In dtConceptos.Rows
                    Try
                        dDato(dConcepto("concepto").ToString.Trim) = dEmpleado(dConcepto("concepto").ToString.Trim)
                        'IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))

                        dTotal(dConcepto("concepto").ToString.Trim) = _
                            IIf(IsDBNull(dTotal(dConcepto("concepto").ToString.Trim)), 0, dTotal(dConcepto("concepto").ToString.Trim)) + _
                                IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))
                        dTotalGeneral(dConcepto("concepto").ToString.Trim) = _
                            IIf(IsDBNull(dTotalGeneral(dConcepto("concepto").ToString.Trim)), 0, dTotalGeneral(dConcepto("concepto").ToString.Trim)) + _
                                IIf(IsDBNull(dEmpleado(dConcepto("concepto").ToString.Trim)), 0, dEmpleado(dConcepto("concepto").ToString.Trim))
                    Catch ex As Exception
                        'Si algún concepto no se localiza en la tabla de información
                        'Igualar a -1 para que sea fácilmente identificable
                        dDato(dConcepto("concepto").ToString.Trim) = -1
                    End Try
                Next

                dtDatos.Rows.Add(dDato)
                AntClase = IIf(IsDBNull(dtNombreEspIng.Rows(0).Item("clase")), "", dtNombreEspIng.Rows(0).Item("clase")).ToString.Trim
                CC = dDato("idcc")
                Renglon += 1
            Next

            dTotal("reloj") = "******"
            dTotal("nombres") = "TOTAL"
            dTotal("clase") = AntClase
            dtDatos.Rows.Add(dTotal)

            'dCc("reloj") = "******"
            'dCc("nombres") = "Centro de Costos:"
            'dCc("clase") = dDato("idcc")
            'dtDatos.Rows.Add(dCc)

            dTotalGeneral("reloj") = "******"
            dTotalGeneral("nombres") = "TOTAL GENERAL"
            dtDatos.Rows.Add(dTotalGeneral)

            Dim datosRec As ADODB.Recordset
            datosRec = DataTableTORecordset(dtDatos)
            '-------------------------------------------------------------------------------------------------------------------------------------------------

            'Exportar a archivo excel con formato

            Try

                Dim NombreArchivo As String = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyDocuments & "\logo.jpg"
                ExcelAPP.Visible = False
                wBook = ExcelAPP.Workbooks.Add
                wSheet = wBook.ActiveSheet()
                wSheet.Name = "PIDA"

                'Buscar el logo de la compañía, tomando como base al primer empleado
                dtCias = sqlExecute("SELECT logo FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                If dtCias.Rows.Count > 0 Then
                    If Not IsDBNull(dtCias.Rows(0).Item("logo")) Then
                        'Guardar el logo en MyDocuments como logo.jpg
                        Dim imageInBytes As Byte() = dtCias.Rows(0).Item("logo")
                        Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(imageInBytes, False)
                        Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream)
                        image.Save(NombreArchivo)
                        'Insertar el logo en el excel
                        wSheet.Shapes.AddPicture(NombreArchivo, False, True, 0, 0, 50, 35)
                    End If
                End If

                'wSheet.Shapes.AddPicture("c:\archivo.jpg", False, True, 0, 0, 45, 50)

                wSheet.Cells(1, 2).Value = dtInformacion.Rows(0).Item("COMPANIA")
                If dtInformacion.Rows(0).Item("TIPO_PERIODO") = "Q" Then
                    wSheet.Cells(2, 2).Value = "NOMINA QUINCENAL " & dtInformacion.Rows(0).Item("PERIODO") & "-" & dtInformacion.Rows(0).Item("ANO")
                Else
                    wSheet.Cells(2, 2).Value = "NOMINA SEMANA " & dtInformacion.Rows(0).Item("PERIODO") & "-" & dtInformacion.Rows(0).Item("ANO")
                End If


                wSheet.Cells(6, 1).Value = "Año"
                wSheet.Cells(6, 2).Value = "Periodo"
                wSheet.Cells(6, 3).Value = "Reloj"
                wSheet.Cells(6, 4).Value = "Nombre"
                wSheet.Cells(6, 5).Value = "Cod Tipo"
                wSheet.Cells(6, 6).Value = "Cod Clase"
                wSheet.Cells(6, 7).Value = "IDCC"
                wSheet.Cells(6, 8).Value = "RFC"
                wSheet.Cells(6, 9).Value = "Cod Depto"
                wSheet.Cells(6, 10).Value = "IMSS"
                wSheet.Cells(6, 11).Value = "Alta"
                wSheet.Cells(6, 12).Value = "Alta Antig"
                wSheet.Cells(6, 13).Value = "Baja"
                wSheet.Cells(6, 14).Value = "SActual"
                wSheet.Cells(6, 15).Value = "Integrado"
                wSheet.Cells(6, 16).Value = "Cod Puesto"
                wSheet.Cells(6, 17).Value = "Puesto"

                wSheet.Range("B1", "B2").Font.Bold = True
                wSheet.Range("B1", "B2").Font.Size = 16


                i = 17
                Dim T As Integer = 0
                Dim E As String = ""
                Dim BColor As Integer = RGB(255, 255, 255)
                Dim FColor As Integer = RGB(0, 0, 0)
                Dim ColTotales(,) As String
                ReDim ColTotales(1, 5)

                For Each dCol As DataRow In dtConceptos.Select("", "orden")
                    i += 1

                    If E <> dCol("cod_naturaleza").ToString.Trim Then
                        E = dCol("cod_naturaleza").ToString.Trim
                        FColor = RGB(0, 0, 0)
                        If E = "I" Then
                            BColor = RGB(165, 165, 165)
                            'FColor = RGB(255, 255, 255)
                        ElseIf E = "P" Then
                            If dCol("concepto").ToString.Trim = "BONDES" Then
                                BColor = RGB(198, 239, 206)
                                dCol("tipo") = ""
                            Else
                                BColor = RGB(198, 239, 206)
                            End If

                        ElseIf E = "D" Then
                            BColor = RGB(145, 201, 255)
                        ElseIf E = "E" Then
                            BColor = RGB(248, 203, 173)
                        ElseIf E = "T" Then
                            E = "H"
                            If dCol("concepto").ToString.Trim = "NETO" Then
                                BColor = RGB(68, 114, 196)
                            End If

                            ColTotales(0, T) = i
                            ColTotales(1, T) = BColor
                            T += 1
                            If UBound(ColTotales, 2) < T Then
                                ReDim Preserve ColTotales(1, T)
                            End If
                            'BColor = RGB(255, 255, 255)
                        End If
                        wSheet.Cells(4, i).Value = dCol("tipo").ToString.Trim
                    End If
                    If E = "" Or E = "" Then
                        _range = wSheet.Range(wSheet.Cells(4, i), wSheet.Cells(5, i))
                    Else
                        _range = wSheet.Range(wSheet.Cells(4, i), wSheet.Cells(4, i))
                    End If
                    _range.Interior.Color = BColor
                    _range.Font.Color = FColor
                    wSheet.Cells(5, i).Value = dCol("nombre").Trim
                    wSheet.Cells(6, i).Value = dCol("concepto").Trim
                Next

                ReDim Preserve ColTotales(1, T - 1)
                _range = wSheet.Range(wSheet.Cells(5, 12), wSheet.Cells(5, i))
                _range.Orientation = 90

                wSheet.Range("a7").CopyFromRecordset(datosRec)

                _range = wSheet.Range(wSheet.Cells(7, 11), wSheet.Cells(datosRec.RecordCount + 7, i))
                _range.NumberFormat = "#,##0.00"
                _range = wSheet.Range(wSheet.Cells(7, 13), wSheet.Cells(datosRec.RecordCount + 7, 14))
                _range.NumberFormat = "dd-mm-yyyy"

                wSheet.Range("D1").Select()
                ExcelAPP.ActiveWindow.FreezePanes = True

                For Ix = 0 To UBound(ColTotales, 2)
                    Columna = ColTotales(0, Ix)
                    Renglon = 5
                    _range = wSheet.Range(wSheet.Cells(Renglon, Columna), wSheet.Cells(datosRec.RecordCount + 7, Columna))
                    _range.Interior.Color = ColTotales(1, Ix)
                    _range.Font.Bold = True
                Next

                'La columna en la que se encuentra el reloj
                Dim columna_reloj As Integer = 3
                For Ix = 7 To datosRec.RecordCount + 6
                    If Not wSheet.Cells(Ix, columna_reloj).value Is Nothing Then
                        If wSheet.Cells(Ix, columna_reloj).value.ToString.Contains("*") Then
                            _range = wSheet.Range(wSheet.Cells(Ix, 1), wSheet.Cells(Ix, i))
                            _range.Interior.Color = Color.FromArgb(RGB(198, 239, 206))
                            _range.Font.Color = Color.DarkGreen
                        End If
                        If wSheet.Cells(Ix, columna_reloj).value.ToString.Contains("-") Then
                            _range = wSheet.Range(wSheet.Cells(Ix, 1), wSheet.Cells(Ix, i))
                            _range.Interior.Color = Color.FromArgb(RGB(240, 199, 198))
                            _range.Font.Color = Color.DarkRed
                        End If
                    End If
                Next


                datosRec.Close()


                wSheet.Rows.WrapText = False
                wSheet.Rows(5).WrapText = True
                wSheet.Rows(5).rowheight = 90
                Dim blnFileOpen As Boolean = False

                Dim frmSave As New Windows.Forms.SaveFileDialog
                frmSave.Filter = "Archivo excel (XLSX)|*.xlsx"

                frmSave.ShowDialog()
                If frmSave.FileName <> "" Then
                    NombreArchivo = frmSave.FileName
                    NombreArchivo = IIf(NombreArchivo.ToLower.Contains(".xlsx"), NombreArchivo, NombreArchivo & ".xlsx")
                End If

                ExcelAPP.Visible = True
                Try
                    Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(NombreArchivo)
                    fileTemp.Close()
                    blnFileOpen = True
                Catch ex As Exception
                    blnFileOpen = False
                    MessageBox.Show("El archivo " & NombreArchivo & " no pudo ser guardado. " & _
                                    "Si el problema persiste, contacte al administrador del sistema." & vbCrLf & vbCrLf & _
                                    "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nomina.vb", ex.HResult, ex.Message)
                End Try

                If blnFileOpen Then
                    If System.IO.File.Exists(NombreArchivo) Then
                        System.IO.File.Delete(NombreArchivo)
                    End If

                    wBook.SaveAs(NombreArchivo)
                End If


                releaseObject(wSheet)
                releaseObject(wBook)


            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)

            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)
            dtDatos = New DataTable
        Finally
            releaseObject(ExcelAPP)
        End Try
    End Sub

    Dim dtrecibos As New DataTable
    Dim dtAcuses As DataTable
    Dim dtPersonal As New DataTable
    Dim dtPeriodos As New DataTable
    Dim dtNomina As New DataTable
    Dim dtMovimiento As New DataTable
    Dim dtMovimientos As New DataTable
    Dim Pseleccionado As String
    Dim Aseleccionado As String
    Dim PPselect As String
    Dim NetoAPagar As Double
    Dim BanderAhorro As Integer
    Dim dtDetalles As New DataTable
    Dim COD_TIPO_NOMINA As String = "N"
    Dim ComentarioRecibo As String = ""
    Dim Seleccionado As String

    Private Sub EstructuraSobres()
        Dim X As Integer
        Try
            'Estructura para reporte
            dtrecibos = New DataTable
            dtrecibos.Columns.Add("GRUPO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("FOLIO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("PAGINA", System.Type.GetType("System.Int16"))
            dtrecibos.Columns.Add("COD_TIPO_NOMINA", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("PERIODO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("ANO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("MES", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("RELOJ", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("NOMBRES", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("COD_TURNO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("COD_LINEA", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("COD_DEPTO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("COD_SUPER", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("COD_HORA", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("COD_TIPO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("COD_CLASE", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("COD_PLANTA", System.Type.GetType("System.String"))  'Jose Hernandez 2019-Mar-05
            dtrecibos.Columns.Add("IMSS", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("RFC", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("CURP", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("COD_PUESTO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("cuenta_banco", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("NOMBRE_DEPTO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("NOMBRE_PUESTO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("COMPANIA", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("CIA_RFC", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("CIA_REG_PAT", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("DIRECCION_COMPANIA", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("NOMBRE_PLANTA", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("ALTA", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("BAJA", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("COD_PAGO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("COD_AREA", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("DEPOSITO", System.Type.GetType("System.Boolean"))
            dtrecibos.Columns.Add("HORAS_NORMALES", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("HORAS_DOBLES", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("HORAS_TRIPLES", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("HORAS_FESTIVAS", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("HORAS_DOMINGO", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("HORAS_COMPENSA", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("DIAS_VAC", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("DIAS_AGUI", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("SACTUAL", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("SMENSUAL", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("INTEGRADO", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("NETO", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("OTR_BON", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("AHORRO_EMP", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("AHORRO_EMPR", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("RETIROS", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("AHORRO_TOTAL", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("AHORRO_NETO", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("PRESTAMO", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("FONACOT", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("INFONAVIT", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("APOFAH", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("SAFAHE", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("SAFAHC", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("RETFAH", System.Type.GetType("System.Decimal"))

            For X = 1 To 10
                dtrecibos.Columns.Add("DESC_PER" & X, System.Type.GetType("System.String")) '- Descripcion Percep
                dtrecibos.Columns.Add("CANT_PER" & X, System.Type.GetType("System.Decimal")) '-- Monto Percep
                dtrecibos.Columns.Add("DESC_DED" & X, System.Type.GetType("System.String")) '-- Descripcion Dedud
                dtrecibos.Columns.Add("CANT_DED" & X, System.Type.GetType("System.Decimal")) '-- Monto Deduc
                dtrecibos.Columns.Add("BASE_PER" & X, System.Type.GetType("System.Decimal"))
                dtrecibos.Columns.Add("SALDO_DED" & X, System.Type.GetType("System.Decimal")) '-- Saldo Deduc
                dtrecibos.Columns.Add("COD_SAT_PER" & X, System.Type.GetType("System.String"))  ' Codigo del sat de la percep
                dtrecibos.Columns.Add("COD_SAT_DED" & X, System.Type.GetType("System.String"))  ' Codigo del sat de la Deduc
                dtrecibos.Columns.Add("GRAV_PER" & X, System.Type.GetType("System.Decimal")) ' Monto Gravable de cada percep
                dtrecibos.Columns.Add("EXEN_PER" & X, System.Type.GetType("System.Decimal")) ' Monto Exento de cada percep
                dtrecibos.Columns.Add("U_PER" & X, System.Type.GetType("System.Decimal"))
            Next

            dtrecibos.Columns.Add("TOT_PER", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("TOT_DED", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("SALDO_ISR", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("SEM_ISR", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("BON_DES", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("BON_ASP", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("BON_ESP", System.Type.GetType("System.Decimal"))
            '   dtRecibos.Columns.Add("COMENTARIO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("FECHA_INI", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("FECHA_FIN", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("FECHA_INI_NOM", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("FECHA_FIN_NOM", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("FECHA_PAGO", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("DIASPAG", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("TOT_GRAV", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("TOT_EXEN", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("ISR", System.Type.GetType("System.Decimal"))
            dtrecibos.Columns.Add("IMPORTE_LETRA", System.Type.GetType("System.String"))

            '----Datos para Timbrado
            dtrecibos.Columns.Add("serie", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("UUID", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("noCertificadoSAT", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("FechaTimbrado", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("sello", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("selloSat", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("selloCFD", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("path_qr", System.Type.GetType("System.String"))
            dtrecibos.Columns.Add("cadenaOriginal", System.Type.GetType("System.String"))


            dtrecibos.Columns.Add("LUNES", System.Type.GetType("System.DateTime"))
            dtrecibos.Columns.Add("MARTES", System.Type.GetType("System.DateTime"))
            dtrecibos.Columns.Add("MIERCOLES", System.Type.GetType("System.DateTime"))
            dtrecibos.Columns.Add("JUEVES", System.Type.GetType("System.DateTime"))
            dtrecibos.Columns.Add("VIERNES", System.Type.GetType("System.DateTime"))
            dtrecibos.Columns.Add("SABADO", System.Type.GetType("System.DateTime"))
            dtrecibos.Columns.Add("DOMINGO", System.Type.GetType("System.DateTime"))

            For X = 1 To 7
                dtrecibos.Columns.Add("E" & X, System.Type.GetType("System.String"))
                dtrecibos.Columns.Add("S" & X, System.Type.GetType("System.String"))
            Next

            For X = 1 To 7
                dtrecibos.Columns.Add("NOR" & X, System.Type.GetType("System.Double"))
                dtrecibos.Columns.Add("EXT" & X, System.Type.GetType("System.Double"))
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "EstructuraSObre", ex.HResult, ex.Message)
        End Try
    End Sub



    Private Sub LlenarRecibo(drInformacion As DataRow)
        Try
            Dim Reloj As String = drInformacion("reloj")
            Dim cod_comp As String = ""
            Try : cod_comp = drInformacion("cod_comp") : Catch ex As Exception : cod_comp = "" : End Try


            Dim AnoPeriodo As String = drInformacion("ano") & drInformacion("periodo")
            Dim tipo_periodo As String = drInformacion("tipo_periodo")
            Dim drPersonal As DataRow
            Dim drRecibo As DataRow
            '  Dim dtSobre As New DataTable

            Dim FI As String = ""
            Dim FF As String = ""
            Dim FECHA_INI_NOM As String = ""
            Dim FECHA_FIN_NOM As String = ""
            Dim FP As String = ""
            Dim M As String = ""

            Dim TotPer As Double = 0
            Dim TotDed As Double = 0
            Dim OtrBon As Double = 0
            Dim AhorroEmp As Double = 0
            Dim AhorroEmpr As Double = 0
            Dim Retiros As Double = 0
            Dim AhorroTottal As Double = 0
            Dim Fonacot As Double = 0
            Dim Infonavit As Double = 0
            Dim SaldoISR As Double = 0
            Dim SemISR As Double = 0
            Dim BonDes As Double = 0
            Dim BonAsP As Double = 0
            Dim SMENSUAL As Double = 0
            Dim periodoAdmin As String = ""
            Dim anoAdmin As String = ""


            Dim P As Integer = 0
            Dim D As Integer = 0
            Dim Naturaleza As String
            Dim conc_exento As String ' Obtener concepto Exento
            Dim TOT_GRAV As Double = 0
            Dim TOT_EXEN As Double = 0
            Dim ISR As Double = 0
            Dim BON_DES As Double = 0
            Dim IMPORTE_LETRA As String = ""
            Dim DIASPAG As String = ""


            Dim fInicial As Date

            If dtrecibos.Columns.Count = 0 Then
                'Si no se ha creado la estructura para los recibos, o está apenas iniciando salir de la subrutina
                Exit Sub
            End If


            'Clonar la tabla de recibos, para tomar un registro en blanco, pero con la misma estructura
            'dtrecibos.Rows.Clear()
            'dtSobre = dtrecibos.Clone
            'dtSobre.Rows.Add()
            ''DataRow para llenar información del registro actual
            'drRecibo = dtSobre.Rows(0)

            drRecibo = dtrecibos.NewRow

            'Obtener rango de fechas del periodo seleccionado
            If tipo_periodo = "C" Then
                dtTemporal = sqlExecute("SELECT fecha_ini,fecha_fin,FECHA_PAGO,mes,periodo,ano,DATEDIFF(dd, FECHA_INI, FECHA_FIN) +1 as DIASPAG,fini_nom,ffin_nom FROM periodos_catorcenal WHERE ano+periodo = '" & AnoPeriodo & "'", "TA")
            Else
                dtTemporal = sqlExecute("SELECT fecha_ini,fecha_fin,FECHA_PAGO,mes,periodo,ano,DATEDIFF(dd, FECHA_INI, FECHA_FIN) +1 as DIASPAG,fini_nom,ffin_nom  FROM periodos WHERE ano+periodo = '" & AnoPeriodo & "'", "TA")
            End If

            If dtTemporal.Rows.Count = 0 Then
                Err.Raise(-1, Seleccionado, "Periodo no localizado")
            Else
                FI = dtTemporal.Rows(0).Item("fecha_ini")
                FF = dtTemporal.Rows(0).Item("fecha_fin")
                FECHA_INI_NOM = dtTemporal.Rows(0).Item("fini_nom")
                FECHA_FIN_NOM = dtTemporal.Rows(0).Item("ffin_nom")
                FP = dtTemporal.Rows(0).Item("fecha_pago")
                periodoAdmin = dtTemporal.Rows(0).Item("periodo")
                anoAdmin = dtTemporal.Rows(0).Item("ano")
                M = IIf(IsDBNull(dtTemporal.Rows(0).Item("mes")), "", dtTemporal.Rows(0).Item("mes")).ToString.Trim
                fInicial = dtTemporal.Rows(0).Item("fecha_ini")
                Dim pt As Integer = Integer.Parse(periodoAdmin)
                'If dtPersonal.Rows(0).Item("COD_TIPO").ToString.Trim.Equals("A") And pt < 54 Then
                '    Dim qu As String = "SELECT TOP 1 fecha_ini,fecha_fin,mes,periodo,ano FROM periodos WHERE ano+periodo ='" & dtPersonal.Rows(0).Item("PERIODO_ACT").ToString.Trim & "' ORDER BY FECHA_INI ASC"
                '    Dim dtPerAdm As DataTable = sqlExecute(qu)
                '    If dtPerAdm.Rows.Count > 0 Then
                '        FI = dtPerAdm.Rows(0).Item("fecha_ini")
                '        FF = dtPerAdm.Rows(0).Item("fecha_fin")
                '        FP = dtTemporal.Rows(0).Item("fecha_pago")
                '        periodoAdmin = dtPerAdm.Rows(0).Item("periodo")
                '        anoAdmin = dtPerAdm.Rows(0).Item("ano")
                '        M = IIf(IsDBNull(dtPerAdm.Rows(0).Item("mes")), "", dtPerAdm.Rows(0).Item("mes"))
                '    End If
                'End If
                ' Titulo.TitleText = "Periodo " & periodoAdmin & " (" & FechaLetra(FI) & " al " & FechaLetra(FF) & ")"

                FI = FechaCortaLetra(FI)
                FF = FechaCortaLetra(FF)
                FECHA_INI_NOM = FechaCortaLetra(FECHA_INI_NOM)
                FECHA_FIN_NOM = FechaCortaLetra(FECHA_FIN_NOM)
                FP = FechaCortaLetra(FP)

            End If

            'Obtener lista de números de empleados del periodo
            dtNomina = sqlExecute("SELECT reloj FROM nomina WHERE RELOJ='" & Reloj & "' AND ano+periodo = '" & AnoPeriodo & "'", "NOMINA")


            '  frmTrabajando.Avance.Maximum = dtNomina.Rows.Count
            'Analizar cada empleado

            Dim dtAsist As DataTable = sqlExecute("select reloj, fha_ent_hor, min(entro) as entrada, max(salio) as salida, sum(1) as registros from asist where ano+periodo = '" & AnoPeriodo & "' group by reloj, fha_ent_hor order by reloj, fha_ent_hor", "ta")

            Dim dtAsistHoras As DataTable = sqlExecute("select reloj, fha_ent_hor, sum(round(dbo.HtoD(horas_normales), 2)) as normales, sum(round(dbo.HtoD(extras_autorizadas), 2)) as extras from asist where ano+periodo = '" & AnoPeriodo & "' group by reloj, fha_ent_hor order by reloj, fha_ent_hor", "ta")

            '  Dim dtAus As DataTable = sqlExecute("select ausentismo.reloj, ausentismo.fecha, ausentismo.tipo_aus from ausentismo left join periodos on ausentismo.fecha between periodos.fecha_ini and periodos.fecha_fin  where periodos.ano = '" & AnoPeriodo.Substring(0, 4) & "' and periodos.periodo = '" & AnoPeriodo.Substring(4, 2) & "' and isnull(periodos.periodo_especial, 0) = 0 ", "ta")

            Dim dtPersonalTodo As New DataTable
            dtPersonalTodo = sqlExecute("SELECT nominavw.* FROM nominaVW WHERE  ano+periodo = '" & _
                                        AnoPeriodo & "'", "Nomina")

            Dim dtMovimientosTodo As New DataTable
            Dim QMovTodo As String = "SELECT movimientos.reloj, movimientos.ano, movimientos.periodo, conceptos.concepto AS CODIGO,conceptos.NOMBRE AS CONCEPTO,conceptos.PRIORIDAD,conceptos.COD_SAT,conc_exento,movimientos.MONTO, " & _
                                           "conceptos.cod_naturaleza,conceptos.UNIDAD," & _
                                           "SUMA_NETO,POSITIVO FROM MOVIMIENTOS LEFT JOIN conceptos ON conceptos.concepto = movimientos.concepto " & _
                                           "WHERE ano+periodo = '" & AnoPeriodo & "' ORDER BY PRIORIDAD,COD_NATURALEZA,CONCEPTO"
            dtMovimientosTodo = sqlExecute(QMovTodo, "Nomina")

            '---Obtener datos de timbrado
            Dim dtTimbradosTodo As New DataTable
            '  tipo_periodo
            '    Dim QTimb As String = "select *,('?re=' + emisor + '&rr=' + receptor + '&tt=' + total + '&id=' + UUID) as qr from timbrado where ano+periodo='" & AnoPeriodo & "' and tipo_periodo='S' and cod_comp='WME'"
            Dim QTimb As String = "select *,('?re=' + emisor + '&rr=' + receptor + '&tt=' + total + '&id=' + UUID) as qr from timbrado where ano+periodo='" & AnoPeriodo & "' and tipo_periodo='" & tipo_periodo.ToString.Trim & "' and cod_comp='" & cod_comp & "'"
            dtTimbradosTodo = sqlExecute(QTimb, "NOMINA")

            For Each dRow As DataRow In dtNomina.Rows

                '-----Iniciar variables en cero de los totales para cada empleado
                TotPer = 0
                TotDed = 0
                TOT_GRAV = 0
                TOT_EXEN = 0
                ISR = 0
                BON_DES = 0
                IMPORTE_LETRA = ""
                DIASPAG = "0"
                '-----Ends

                Reloj = dRow("reloj")
                'frmTrabajando.lblAvance.Text = Reloj

                'frmTrabajando.Avance.Value += 1
                'Application.DoEvents()

                'If Not ActivoTrabajando Then
                '    MessageBox.Show("Los datos de nómina no fueron cargados correctamente.", "Recibos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Exit Sub
                'End If
                'Buscar información de nómina y personal
                dtPersonal = dtPersonalTodo.Select("reloj = '" & Reloj & "'").CopyToDataTable

                'Subir datos de nómina y personal a tabla de recibos
                drPersonal = dtPersonal.Rows(0)
                'dtSobre.Rows.Clear()
                'drRecibo = dtSobre.Rows.Add

                drRecibo("COD_TIPO_NOMINA") = drPersonal("COD_TIPO_NOMINA")
                drRecibo("PERIODO") = drPersonal("PERIODO")
                drRecibo("ANO") = drPersonal("ANO")
                drRecibo("MES") = M
                drRecibo("RELOJ") = drPersonal("RELOJ")
                drRecibo("NOMBRES") = drPersonal("NOMBRES").ToString.Trim
                drRecibo("COD_TURNO") = drPersonal("COD_TURNO")
                'drRecibo("COD_LINEA") = drPersonal("COD_LINEA")
                drRecibo("COD_DEPTO") = drPersonal("COD_DEPTO")
                drRecibo("COD_SUPER") = drPersonal("COD_SUPER")
                drRecibo("COD_HORA") = drPersonal("COD_HORA")
                drRecibo("COD_TIPO") = drPersonal("COD_TIPO")
                drRecibo("COD_CLASE") = drPersonal("COD_CLASE").ToString.ToUpper.Trim
                drRecibo("COD_PUESTO") = drPersonal("COD_PUESTO").ToString.ToUpper.Trim
                drRecibo("COD_PLANTA") = drPersonal("COD_PLANTA").ToString.ToUpper.Trim
                drRecibo("cuenta_banco") = drPersonal("cuenta").ToString.Trim
                drRecibo("NOMBRE_DEPTO") = drPersonal("NOMBRE_DEPTO").ToString.ToUpper.Trim
                drRecibo("NOMBRE_PUESTO") = drPersonal("NOMBRE_PUESTO").ToString.ToUpper.Trim
                drRecibo("NOMBRE_PLANTA") = drPersonal("NOMBRE_PLANTA").ToString.ToUpper.Trim
                drRecibo("COMPANIA") = drPersonal("COMPANIA").ToString.Trim
                drRecibo("CIA_RFC") = drPersonal("CIA_RFC")
                drRecibo("CIA_REG_PAT") = drPersonal("CIA_REG_PAT")

                Dim NumImss As String
                NumImss = IIf(IsDBNull(dtPersonal.Rows(0).Item("NUMIMSS")), "-----", dtPersonal.Rows(0).Item("NUMIMSS"))
                drRecibo("IMSS") = NumImss.Trim
                drRecibo("RFC") = IIf(IsDBNull(dtPersonal.Rows(0).Item("RFC")), "-----", dtPersonal.Rows(0).Item("RFC"))
                drRecibo("CURP") = IIf(IsDBNull(dtPersonal.Rows(0).Item("CURP")), "-----", dtPersonal.Rows(0).Item("CURP"))

                drRecibo("ALTA") = FechaCortaLetra(drPersonal("ALTA"))
                If Not IsDBNull(drPersonal("BAJA")) Then
                    drRecibo("BAJA") = IIf(IsDBNull(drPersonal("BAJA")), "", FechaLetra(drPersonal("BAJA")))
                End If
                drRecibo("COD_PAGO") = drPersonal("COD_PAGO")
                drRecibo("DEPOSITO") = IIf(IsDBNull(drPersonal("COD_PAGO")), "x", drPersonal("COD_PAGO")) = "D"
                drRecibo("HORAS_NORMALES") = drPersonal("HORAS_NORMALES")
                drRecibo("HORAS_DOBLES") = drPersonal("HORAS_DOBLES")
                drRecibo("HORAS_TRIPLES") = drPersonal("HORAS_TRIPLES")
                drRecibo("HORAS_FESTIVAS") = drPersonal("HORAS_FESTIVAS")
                drRecibo("HORAS_DOMINGO") = drPersonal("HORAS_DOMINGO")
                drRecibo("HORAS_COMPENSA") = drPersonal("HORAS_COMPENSA")
                drRecibo("DIAS_VAC") = drPersonal("DIAS_VAC")
                drRecibo("DIAS_AGUI") = drPersonal("DIAS_AGUI")
                drRecibo("SACTUAL") = drPersonal("SACTUAL")
                drRecibo("SMENSUAL") = Math.Round(drPersonal("SACTUAL") * 30, 2)
                drRecibo("INTEGRADO") = drPersonal("INTEGRADO")

                '    drRecibo("COMENTARIO") = txtComentario.Text
                drRecibo("FECHA_INI") = FI
                drRecibo("FECHA_FIN") = FF
                drRecibo("FECHA_INI_NOM") = FECHA_INI_NOM
                drRecibo("FECHA_FIN_NOM") = FECHA_FIN_NOM
                drRecibo("FECHA_PAGO") = FP
                ' drRecibo("DIASPAG") = DIASPAG

                drRecibo("LUNES") = fInicial
                drRecibo("MARTES") = DateAdd(DateInterval.Day, 1, fInicial)
                drRecibo("MIERCOLES") = DateAdd(DateInterval.Day, 2, fInicial)
                drRecibo("JUEVES") = DateAdd(DateInterval.Day, 3, fInicial)
                drRecibo("VIERNES") = DateAdd(DateInterval.Day, 4, fInicial)
                drRecibo("SABADO") = DateAdd(DateInterval.Day, 5, fInicial)
                drRecibo("DOMINGO") = DateAdd(DateInterval.Day, 6, fInicial)

                Try

                    Dim dtdiasSemana As DataTable = New DataTable
                    dtdiasSemana.Columns.Add("num_dia")
                    dtdiasSemana.Columns.Add("nombre_dia")

                    dtdiasSemana.Rows.Add({"1", "lunes"})
                    dtdiasSemana.Rows.Add({"2", "martes"})
                    dtdiasSemana.Rows.Add({"3", "miercoles"})
                    dtdiasSemana.Rows.Add({"4", "jueves"})
                    dtdiasSemana.Rows.Add({"5", "viernes"})
                    dtdiasSemana.Rows.Add({"6", "sabado"})
                    dtdiasSemana.Rows.Add({"7", "domingo"})

                    For Each row_dia_semana As DataRow In dtdiasSemana.Rows
                        Try


                            Try
                                For Each dAsist As DataRow In dtAsist.Select("reloj = '" & drPersonal("RELOJ") & "' and fha_ent_hor = '" & FechaSQL(drRecibo(row_dia_semana("nombre_dia"))) & "'")
                                    Try
                                        drRecibo("E" & row_dia_semana("num_dia")) = IIf(IsDBNull(dAsist("entrada")), "", "E - " & dAsist("entrada")) & IIf(dAsist("registros") > 1, " *", "")
                                        drRecibo("S" & row_dia_semana("num_dia")) = IIf(IsDBNull(dAsist("salida")), "", "S - " & dAsist("salida"))
                                    Catch ex As Exception

                                    End Try
                                Next
                            Catch ex As Exception

                            End Try

                            Try
                                For Each dAsist As DataRow In dtAsistHoras.Select("reloj = '" & drPersonal("RELOJ") & "' and fha_ent_hor = '" & FechaSQL(drRecibo(row_dia_semana("nombre_dia"))) & "'")
                                    Try
                                        drRecibo("NOR" & row_dia_semana("num_dia")) = dAsist("normales")
                                        drRecibo("EXT" & row_dia_semana("num_dia")) = dAsist("extras")
                                    Catch ex As Exception

                                    End Try
                                Next
                            Catch ex As Exception

                            End Try

                        Catch ex As Exception

                        End Try

                    Next


                Catch ex As Exception

                End Try


                'Inicializa variables de saldos y totales
                '   TotPer = TotalPercepciones(Reloj, AnoPeriodo)
                '  TotDed = TotalDeducciones(Reloj, AnoPeriodo)
                D = 0
                P = 0

                'Información de movimientos del empleado en el periodo

                dtMovimientos = dtMovimientosTodo.Select("reloj = '" & Reloj & "'").CopyToDataTable

                'Analizar cada movimiento
                For Each drMovs As DataRow In dtMovimientos.Rows
                    Dim MontoExen As Double = 0
                    Dim UnidadMonto As Double = 0
                    Dim cod_concepto As String = IIf(IsDBNull(drMovs("CODIGO")), "X", drMovs("CODIGO")).ToString.Trim
                    Dim UNIDAD As String = IIf(IsDBNull(drMovs("UNIDAD")), "", drMovs("UNIDAD")).ToString.Trim
                    conc_exento = IIf(IsDBNull(drMovs("conc_exento")), "X", drMovs("conc_exento")).ToString.Trim 'Concepto exento
                    Naturaleza = IIf(IsDBNull(drMovs("cod_naturaleza")), "I", drMovs("cod_naturaleza")).ToString.Trim

                    '----Dias de pago
                    If (cod_concepto.Trim = "DIASPA") Then
                        DIASPAG = drMovs("monto")
                        If (Double.Parse(DIASPAG) >= 30) Then DIASPAG = "30" ' Aplica para las nominas mensuales
                        '    If (Integer.Parse(DIASPAG) >= 30) Then DIASPAG = "30"
                    End If
                    drRecibo("DIASPAG") = DIASPAG
                    '-----End Dias de pago

                    If Naturaleza = "P" Or Naturaleza = "D" Or cod_concepto.Trim = "BONDES" Then
                        If ((drMovs("positivo") And drMovs("suma_neto")) Or drMovs("CODIGO").ToString.Trim = "BONDES") Then ' Si es Perc y suma al neto, o el bono de despensa que se incluye
                            P += 1
                            If P > 10 Then
                                P = 10
                                drRecibo("desc_per" & P) = "OTRAS PERCEPCIONES"
                            Else
                                drRecibo("desc_per" & P) = drMovs("concepto").ToString.Trim
                            End If
                            drRecibo("cant_per" & P) = drMovs("monto") + IIf(IsDBNull(drRecibo("cant_per" & P)), 0, drRecibo("cant_per" & P))
                            drRecibo("COD_SAT_PER" & P) = drMovs("COD_SAT")
                            TotPer = TotPer + drRecibo("cant_per" & P) ' Ir sumando para obtener el total de percepciones

                            '----------Obtener Unidad  de los conceptos que tengan un concepto para mostrar el monto de la unidad, x ejemplo, el total de hrs dobles o triples
                            If (UNIDAD.Trim <> "") Then
                                Try
                                    dtMontoHrExtra = dtMovimientosTodo.Select("reloj = '" & Reloj & "' and CODIGO='" & UNIDAD & "'").CopyToDataTable
                                    For Each drMontoUnidad As DataRow In dtMontoHrExtra.Rows
                                        UnidadMonto = drMontoUnidad("monto")
                                        If (UNIDAD.Trim = "HRSNOR") Then UnidadMonto = Math.Round(UnidadMonto / 8, 2) ' Para la percep normal, los dias = hrs/8
                                    Next
                                Catch ex As Exception

                                End Try
                                drRecibo("U_PER" & P) = UnidadMonto
                            End If

                            '---Obtener parte Gravable y exenta de cada percep
                            If (conc_exento.Trim = "X") Then 'Si no tiene ningun concepto exento, va a gravar 100%
                                drRecibo("GRAV_PER" & P) = drMovs("monto")
                                TOT_GRAV = TOT_GRAV + drRecibo("GRAV_PER" & P)
                            Else 'Obtener parte Exenta segun del concepto que tenga

                                'NOTA: CONCEPTOS QUE EXENTAN AL 100%:
                                If (conc_exento = "BONDES") Then
                                    drRecibo("EXEN_PER" & P) = drMovs("monto")
                                    TOT_EXEN = TOT_EXEN + drRecibo("EXEN_PER" & P)
                                Else ' Conceptos que tienen parte gravada y parte exenta
                                    ' 1.- Tomar el monto del concepto que es exento segun el concepto que lo trae la variable "conc_exento", y ese valor va a ser el valor exento
                                    ' 2.- Lo gravable = Lo que tengamos en monto - el monto exento
                                    '--NOTA: Lo unico complicado es traernos el monto del concepto exento que esta en este datable
                                    Try
                                        dtMovConcExento = dtMovimientosTodo.Select("reloj = '" & Reloj & "' and CODIGO='" & conc_exento.Trim & "'").CopyToDataTable
                                        For Each drMovExen As DataRow In dtMovConcExento.Rows
                                            MontoExen = drMovExen("monto")
                                        Next
                                    Catch ex As Exception
                                    End Try
                                    '---Para el caso de APOCIA es especial, ya que lo que grava lo trae su valor de exento, y lo que grava es lo contrario
                                    '---14/02/2020: AOS - Ya no es necesario ya que lo exento ya viene en el concepto PEXFAH a partir del periodo 02 del 2020
                                    'If (cod_concepto.Trim = "APOCIA") Then
                                    '    drRecibo("GRAV_PER" & P) = MontoExen
                                    '    drRecibo("EXEN_PER" & P) = drMovs("monto") - MontoExen
                                    '    GoTo Totales
                                    'End If

                                    '--Para todos los demas conceptos lo exento si es lo que traen en su valor de excento
                                    drRecibo("EXEN_PER" & P) = MontoExen
                                    drRecibo("GRAV_PER" & P) = drMovs("monto") - MontoExen

Totales:
                                    TOT_EXEN = TOT_EXEN + drRecibo("EXEN_PER" & P)
                                    TOT_GRAV = TOT_GRAV + drRecibo("GRAV_PER" & P)


                                End If
                            End If
                            '--------------Termina parte gravable y exenta de cada concepto

                            '----Sumar Bono de despensa
                            If (cod_concepto.Trim = "BONDES") Then BON_DES = BON_DES + drRecibo("cant_per" & P)

                            '------------------DETALLE DE DIAS Y HORAS
                            Select Case drMovs("codigo").ToString.Trim

                                Case "PERNOR"
                                    drRecibo("BASE_PER" & P) = MontoConcepto(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "HRSNOR")
                                Case "PEREX2"
                                    drRecibo("BASE_PER" & P) = MontoConcepto(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "HRSEX2")
                                Case "PEREX3"
                                    drRecibo("BASE_PER" & P) = MontoConcepto(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "HRSEX3")
                                Case "PERFES"
                                    drRecibo("BASE_PER" & P) = MontoConcepto(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "HRSFES")
                                Case "PERDOM"
                                    drRecibo("BASE_PER" & P) = MontoConcepto(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "HRSDOM")
                                Case "PERVAC"
                                    drRecibo("BASE_PER" & P) = MontoConcepto(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "DIASVA")
                                Case "PERAGI"
                                    drRecibo("BASE_PER" & P) = MontoConcepto(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "DIASAG")
                            End Select
                            '-----------------Termina Detalle de dias y horas
                        Else
                            '-------DEDUCCIONES
                            If drMovs("suma_neto") Then
                                D += 1
                                If D > 10 Then
                                    D = 10
                                    drRecibo("desc_ded" & D) = "OTRAS DEDUCCIONES"
                                Else
                                    drRecibo("desc_ded" & D) = drMovs("concepto")

                                    '*************Obtener SALDOS
                                    '- Saldo del fondo de ahorro
                                    Dim Conc As String = drMovs("CODIGO")
                                    If ((Conc.Trim = "APOFAH" Or Conc.Trim = "RETCIA")) Then
                                        Dim ConcsSaldoFAH As String = "'SAFAHC','SAFAHE','RETFAH'"  ' Conceptos que entran para el saldo del fondo de ahorrro por el momento para pruebas, pero queda pendiente de definir
                                        Dim SAFAHC As Double = 0
                                        Dim SAFAHE As Double = 0
                                        Dim RETFAH As Double = 0
                                        Dim QSFAH As String = "SELECT * from movimientos where ano+PERIODO='" & AnoPeriodo & "' and CONCEPTO in(" & ConcsSaldoFAH & ") and reloj='" & Reloj.Trim & "' AND MONTO>0"
                                        Dim dtSaldoFAh As DataTable = sqlExecute(QSFAH, "NOMINA")
                                        If (Not dtSaldoFAh.Columns.Contains("Error") And dtSaldoFAh.Rows.Count > 0) Then
                                            For Each dr As DataRow In dtSaldoFAh.Rows
                                                Dim Concep As String = IIf(IsDBNull(dr("CONCEPTO")), "", dr("CONCEPTO").ToString.Trim)
                                                If (Concep.Trim = "SAFAHC") Then SAFAHC = IIf(IsDBNull(dr("MONTO")), 0.0, dr("MONTO"))
                                                If (Concep.Trim = "SAFAHE") Then SAFAHE = IIf(IsDBNull(dr("MONTO")), 0.0, dr("MONTO"))
                                                If (Concep.Trim = "RETFAH") Then RETFAH = IIf(IsDBNull(dr("MONTO")), 0.0, dr("MONTO"))
                                            Next
                                        End If

                                        If (Conc.Trim = "APOFAH") Then drRecibo("SAFAHE") = SAFAHE ' Saldo FAH Empleado
                                        If (Conc.Trim = "RETCIA") Then
                                            drRecibo("SAFAHC") = SAFAHC ' Saldo FAH Compañía
                                            drRecibo("RETFAH") = RETFAH ' Retiro si es que tuvo retiro del Fondo de Ahorro
                                        End If
                                    End If
                                    '- Ends Saldo FAH


                                End If
                                drRecibo("cant_ded" & D) = drMovs("monto") + IIf(IsDBNull(drRecibo("cant_ded" & D)), 0, drRecibo("cant_ded" & D))
                                drRecibo("COD_SAT_DED" & D) = drMovs("COD_SAT")
                                TotDed = TotDed + drRecibo("cant_ded" & D) ' Ir sumando para obtener el total de deducciones
                                If (cod_concepto.Trim = "ISPTRE") Then ISR = ISR + drRecibo("cant_ded" & D) ' Sumar el ISR para obtener el total de ISR

                            Else
                                '**** EN ESPECIE ****
                                'PENDIENTE
                            End If
                        End If
                    End If

                    'Si es naturaleza A,I o E
                    Select Case drMovs("codigo").ToString.Trim
                        'Case "BONDES"
                        '    drRecibo("bon_des") = drMovs("monto")
                        Case "APOFAH"
                            drRecibo("APOFAH") = drMovs("monto")
                        Case "BONASP"
                            drRecibo("bon_asp") = drMovs("monto")
                        Case "SAFAHE"
                            drRecibo("AHORRO_EMP") = drMovs("monto")
                        Case "SAFAHC"
                            drRecibo("AHORRO_EMPR") = drMovs("monto")
                        Case "SALPFA"
                            drRecibo("PRESTAMO") = drMovs("monto")
                        Case "RETFAH", "SALP1", "SALI1"
                            drRecibo("RETIROS") = IIf(IsDBNull(drRecibo("RETIROS")), 0, drRecibo("RETIROS")) + IIf(IsDBNull(drMovs("monto")), 0, drMovs("monto"))
                        Case "SALFNT"
                            drRecibo("FONACOT") = drMovs("monto")
                        Case "SALADI"
                            drRecibo("INFONAVIT") = drMovs("monto")
                        Case "SEMACO"
                            drRecibo("SEM_ISR") = drMovs("monto")
                        Case "SALIFA"
                            drRecibo("SALDO_ISR") = IIf(IsDBNull(drMovs("monto")), 0, drMovs("monto"))
                        Case "SALICA"
                            drRecibo("SALDO_ISR") = IIf(IsDBNull(drMovs("monto")), 0, -drMovs("monto"))
                        Case "BONOS", "DESEFE"
                            drRecibo("BON_ESP") = IIf(IsDBNull(drRecibo("bon_esp")), 0, drRecibo("bon_esp")) + drMovs("monto")
                    End Select
                Next

                '-------Obtener datos de TIMBRADO
                If (Not dtTimbradosTodo.Columns.Contains("Error") And dtTimbradosTodo.Rows.Count > 0) Then
                    '   For Each dRowTimb As DataRow In dtTimbradosTodo.Rows
                    For Each dRowTimb As DataRow In dtTimbradosTodo.Select("RELOJ='" & Reloj.Trim & "'")
                        Dim drTimb As DataRow = Nothing
                        Try
                            drTimb = dtTimbradosTodo.Select("RELOJ='" & Reloj.Trim & "'")(0)
                        Catch ex As Exception

                        End Try
                        If Not IsNothing(drTimb) Then
                            drRecibo("serie") = drTimb("serie").ToString.Trim
                            drRecibo("UUID") = drTimb("UUID").ToString.Trim
                            drRecibo("noCertificadoSAT") = drTimb("noCertificadoSAT").ToString.Trim
                            drRecibo("FechaTimbrado") = drTimb("FechaTimbrado").ToString.Trim
                            drRecibo("sello") = drTimb("sello").ToString.Trim
                            drRecibo("selloSat") = drTimb("selloSat").ToString.Trim
                            drRecibo("selloCFD") = drTimb("selloCFD").ToString.Trim
                            drRecibo("cadenaOriginal") = "||1.0|" & drTimb("UUID") & "|" & drTimb("FechaTimbrado") & "|" & drTimb("sello") & "|" & drTimb("noCertificadoSAT")

                            '-----------Generar  Imagen QR
                            Dim qr As Bitmap = GenerateQRCode(drTimb("qr"), Color.Black, Color.White, 6)
                            Dim dtTemp As DataTable = sqlExecute("select path_qr from cias where CIA_DEFAULT=1", "KIOSCO") ' Obtener Path donde se guardan las fotos para generar imagn QR
                            PathFoto = dtTemp.Rows.Item(0).Item("path_qr").ToString.Trim
                            If PathFoto.Substring(PathFoto.Length - 1, 1) <> "\" Then PathFoto = PathFoto & "\"
                            If File.Exists(PathFoto & Reloj.Trim & "qr.bmp") Then File.Delete(PathFoto & Reloj.Trim & "qr.bmp")
                            qr.Save(PathFoto & Reloj.Trim & "qr.bmp", System.Drawing.Imaging.ImageFormat.Bmp)
                            drRecibo("path_qr") = PathFoto & Reloj.Trim & "qr.bmp"
                            '-----------Ends Gen Imagen QR
                        End If
                    Next

                End If

                '-------ENDS


                'Totales
                '   IMPORTE_LETRA = ConvNvo(TotPer - TotDed - BON_DES)
                IMPORTE_LETRA = ConvNvo(TotPer - TotDed)
                drRecibo("IMPORTE_LETRA") = IMPORTE_LETRA.Trim
                drRecibo("TOT_PER") = TotPer
                drRecibo("TOT_DED") = TotDed
                drRecibo("TOT_GRAV") = TOT_GRAV
                drRecibo("TOT_EXEN") = TOT_EXEN
                drRecibo("ISR") = ISR
                drRecibo("BON_DES") = BON_DES
                drRecibo("NETO") = TotPer - TotDed
                drRecibo("AHORRO_TOTAL") = IIf(IsDBNull(drRecibo("AHORRO_EMP")), 0, drRecibo("AHORRO_EMP")) + IIf(IsDBNull(drRecibo("AHORRO_EMPR")), 0, drRecibo("AHORRO_EMPR"))
                drRecibo("AHORRO_NETO") = IIf(IsDBNull(drRecibo("AHORRO_EMP")), 0, drRecibo("AHORRO_EMP")) + _
                    IIf(IsDBNull(drRecibo("AHORRO_EMPR")), 0, drRecibo("AHORRO_EMPR")) - _
                    (IIf(IsDBNull(drRecibo("RETIROS")), 0, drRecibo("RETIROS")) + (IIf(IsDBNull(drRecibo("PRESTAMO")), 0, drRecibo("PRESTAMO"))))

                'Insertar el registro en la tabla de los recibos
                dtrecibos.Rows.Add(drRecibo)
            Next



        Catch ex As Exception
            MessageBox.Show("Se detectó un error durante la carga de información del periodo seleccionado. Favor de verificar" & vbCrLf & vbCrLf & "Error.-" & ex.Message, "Recibos", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            'If Not (dtRecibos.Columns.Count = 0 Or Iniciando) Then
            '    LlenarGrupos()
            'End If

            'ActivoTrabajando = False

            'frmTrabajando.Close()
            'frmTrabajando.Dispose()
        End Try
    End Sub

    Private Function MontoConcepto(dtTabla As DataTable, ByVal Reloj As String, ByVal AnoPer As String, ByVal concepto As String) As Double
        Try
            Return dtTabla.Select("ano+periodo = '" & AnoPer & "' AND reloj = '" & Reloj & "' AND codigo = '" & concepto & "'")(0)("monto")
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private Function GenerateQRCode(URL As String, DarkColor As System.Drawing.Color, LightColor As System.Drawing.Color, escala As Integer) As Bitmap
        Dim Encoder As New Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.L)
        Dim Code As Gma.QrCodeNet.Encoding.QrCode = Encoder.Encode(URL)

        Dim contadorx As Integer = 1
        Dim contadory As Integer = 1

        Dim TempBMP As New Bitmap(Code.Matrix.Width * escala, Code.Matrix.Height * escala)
        For X As Integer = 0 To (Code.Matrix.Width) - 1
            For Y As Integer = 0 To (Code.Matrix.Height) - 1
                Try
                    If Code.Matrix.InternalArray(X, Y) Then
                        For i As Integer = 0 To escala Step 1
                            For j As Integer = 0 To escala - 1 Step 1
                                TempBMP.SetPixel((X * escala) + i, (Y * escala) + j, DarkColor)
                            Next
                        Next
                    Else
                        For i As Integer = 0 To escala Step 1
                            For j As Integer = 0 To escala - 1 Step 1
                                TempBMP.SetPixel((X * escala) + i, (Y * escala) + j, LightColor)
                            Next
                        Next
                    End If
                Catch ex As Exception

                End Try
            Next
        Next
        Return TempBMP
    End Function

    'Public Sub ListadoNomina(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
    '    Dim Ano As String
    '    Dim Periodo As String
    '    Dim Percepciones As Integer
    '    Dim Deducciones As Integer
    '    Dim dtDatoEmpleado As New DataTable
    '    Try
    '        dtDatos.Columns.Add("reloj")
    '        dtDatos.Columns.Add("alta", GetType(System.DateTime))
    '        dtDatos.Columns.Add("nombres")
    '        dtDatos.Columns.Add("numimss")
    '        dtDatos.Columns.Add("rfc")
    '        dtDatos.Columns.Add("sactual", GetType(System.Double))
    '        dtDatos.Columns.Add("integrado", GetType(System.Double))
    '        dtDatos.Columns.Add("PerConcepto")
    '        dtDatos.Columns.Add("PerDescripcion")
    '        dtDatos.Columns.Add("PerMonto", GetType(System.Double))
    '        dtDatos.Columns.Add("PerMontoSuma", GetType(System.Double))
    '        dtDatos.Columns.Add("PerBase", GetType(System.Double))
    '        dtDatos.Columns.Add("DedConcepto")
    '        dtDatos.Columns.Add("DedDescripcion")
    '        dtDatos.Columns.Add("DedMonto", GetType(System.Double))

    '        dtDatoEmpleado = dtDatos.Clone

    '        Dim dDato As DataRow
    '        Dim dtMovs As New DataTable
    '        Dim InsertaNuevo As Boolean = False
    '        Dim Base As Double = 0

    '        For Each dEmp As DataRow In dtInformacion.Rows
    '            dtDatoEmpleado.Rows.Clear()
    '            Percepciones = 0
    '            Deducciones = 0
    '            Reloj = dEmp("reloj")
    '            Ano = dEmp("ano")
    '            Periodo = dEmp("periodo")

    '            dtMovs = sqlExecute("SELECT * FROM movimientosVW WHERE reloj = '" & Reloj & "' AND ano = '" & Ano & _
    '                                "' AND periodo = '" & Periodo & "' and tipo_periodo = '" & dEmp("tipo_periodo") & "' AND cod_naturaleza IN ('P','D')", "nomina")

    '            For Each dMov As DataRow In dtMovs.Select("cod_naturaleza = 'P'", "prioridad")
    '                Percepciones += 1

    '                Try
    '                    Base = MontoConcepto(Reloj, Ano, Periodo, dEmp("tipo_periodo"), dMov("detalle"))
    '                Catch ex As Exception
    '                    Base = 0
    '                End Try

    '                dDato = dtDatoEmpleado.NewRow

    '                dDato("reloj") = dEmp("reloj")
    '                dDato("alta") = dEmp("alta")
    '                dDato("nombres") = dEmp("nombres")
    '                dDato("numimss") = dEmp("numimss")
    '                dDato("rfc") = dEmp("rfc")
    '                dDato("sactual") = dEmp("sactual")
    '                dDato("integrado") = dEmp("integrado")

    '                dDato("PerConcepto") = dMov("concepto")
    '                dDato("PerDescripcion") = dMov("nombre")
    '                dDato("PerMonto") = dMov("monto")
    '                If IIf(IsDBNull(dMov("suma_neto")), 0, dMov("suma_neto")) = 1 Then
    '                    dDato("PerMontoSuma") = dMov("monto")
    '                End If
    '                If Base > 0 Then dDato("Perbase") = Base

    '                dtDatoEmpleado.Rows.Add(dDato)
    '            Next

    '            For Each dMov As DataRow In dtMovs.Select("cod_naturaleza = 'D'", "prioridad")
    '                If Deducciones >= dtDatoEmpleado.Rows.Count Then
    '                    dDato = dtDatoEmpleado.NewRow

    '                    dDato("reloj") = dEmp("reloj")
    '                    dDato("alta") = dEmp("alta")
    '                    dDato("nombres") = dEmp("nombres")
    '                    dDato("numimss") = dEmp("numimss")
    '                    dDato("rfc") = dEmp("rfc")
    '                    dDato("sactual") = dEmp("sactual")
    '                    dDato("integrado") = dEmp("integrado")
    '                    dtDatoEmpleado.Rows.Add(dDato)
    '                End If

    '                dDato = dtDatoEmpleado.Rows(Deducciones)
    '                Deducciones += 1

    '                dDato("DedConcepto") = dMov("concepto")
    '                dDato("DedDescripcion") = dMov("nombre")
    '                dDato("DedMonto") = dMov("monto")
    '            Next

    '            For Each dDato In dtDatoEmpleado.Rows
    '                dtDatos.ImportRow(dDato)
    '            Next
    '        Next
    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nomina.vb", ex.HResult, ex.Message)
    '        dtDatos = New DataTable
    '    End Try
    'End Sub

    Public Sub CifraControl(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            'Jose R Hdez preguntar si se desea agregar mensual, finiquitos y bonos de despensa.
            ''--
            'If MessageBox.Show("Agregar Finiquitos y Mensual?", "PIDA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '    Dim anio = My.Forms.frmReporteadorNomina.lstPeriodos.Items(0).ToString.Split("-")(0)
            '    Dim cperiodo = My.Forms.frmReporteadorNomina.lstPeriodos.Items(0).ToString.Split("-")(1)
            '    Dim mes = ""
            '    Dim dtMes = sqlExecute("select top 1 mes from ta.dbo.periodos where ano = '" & anio & "' and periodo = '" & cperiodo & "'")
            '    If dtMes.Rows.Count > 0 Then
            '        mes = dtMes.Rows(0).Item("mes").ToString.Trim
            '    End If

            '    Dim dtPeriodosMensuales As DataTable = sqlExecute("Select periodo, tipo_periodo from ta.dbo.periodos_mensual where ano = '" & anio & "' and mes = '" & mes & "' and periodo_especial = '1'")
            '    If dtPeriodosMensuales.Rows.Count > 0 Then
            '        dtResultadoNomina = sqlExecute("EXEC ReporteadorNominaTipoPeriodo_Mensual @Cia = " & CiaReporteador.Replace("''", "'") & ",@ano = '" & anio & "', @periodo = '" & dtPeriodosMensuales.Rows(0).Item("periodo") & _
            '                             "',@Nivel = '" & NivelConsulta & "', @reloj = '', @TipoPeriodo = '" & dtPeriodosMensuales.Rows(0).Item("tipo_periodo") & "'", "nomina")
            '        dtResultadoNomina.Columns.Add("periodos")
            '        dtInformacion.Merge(dtResultadoNomina)
            '    End If

            '    dtResultadoNomina = sqlExecute("EXEC ReporteadorNominaTipoPeriodo_finiquitos_reportemensual @Cia = " & CiaReporteador.Replace("''", "'") & ",@Nivel = '" & NivelConsulta & "'", "nomina")
            '    dtResultadoNomina.Columns.Add("periodos")
            '    dtInformacion.Merge(dtResultadoNomina)
            'End If
            ''--

            Dim dtConceptos As DataTable
            dtConceptos = sqlExecute("select rtrim(concepto) as concepto, rtrim(isnull(unidad, '')) as detalle, nombre, rtrim(cod_naturaleza) as cod_naturaleza, prioridad,0 as orden," & _
                                    "case when cod_naturaleza = 'I' then 'INFORMATIVOS' " & _
                                        "else case when cod_naturaleza = 'P' then 'PERCEPCIONES'" & _
                                            "else case when cod_naturaleza = 'D' then 'DEDUCCIONES' " & _
                                                "else case when cod_naturaleza = 'E' then 'EXENTOS' " & _
                                                    "else '' end end end end as 'tipo'" & _
                                    "from nomina.dbo.conceptos where cod_naturaleza not in('A','V') and not NOMBRE_INGLES is null order by " & _
                                    "prioridad")

            dtConceptos.Columns.Add("total", Type.GetType("System.Double"))
            dtConceptos.Columns.Add("total_detalle", Type.GetType("System.Double"))
            dtConceptos.PrimaryKey = New DataColumn() {dtConceptos.Columns("concepto")}

            Dim cntObject As Object
            For Each row_conceptos As DataRow In dtConceptos.Rows
                Try
                    cntObject = dtInformacion.Compute("SUM(" & row_conceptos("concepto") & ")", "")
                    If Not IsDBNull(cntObject) Then
                        row_conceptos("total") = cntObject
                    End If
                    If Len(row_conceptos("detalle")) > 0 Then
                        cntObject = dtInformacion.Compute("SUM(" & row_conceptos("detalle") & ")", "")
                        If Not IsDBNull(cntObject) Then
                            row_conceptos("total_detalle") = cntObject
                        End If
                    End If
                Catch ex As Exception
                    Dim serror = ex.Message
                End Try
            Next

            'For Each row_conceptos As DataRow In dtConceptos.Rows
            '    If Not IsDBNull(dtInformacion.Columns(row_conceptos("concepto"))) Then
            '        For Each row_nomina As DataRow In dtInformacion.Rows
            '            Try
            '                Dim detalle As String = RTrim(row_conceptos("detalle"))
            '                Dim _monto As Double = 0.0
            '                Try
            '                    _monto = IIf(IsDBNull(row_nomina(row_conceptos("concepto"))), 0, row_nomina(row_conceptos("concepto")))
            '                Catch
            '                End Try
            '                Dim _total_actual As Double = IIf(IsDBNull(row_conceptos("total")), 0, row_conceptos("total"))
            '                row_conceptos("total") = _total_actual + _monto

            '                Dim _monto_detalle As Double = 0
            '                Dim _total_detalle As Double = 0

            '                If detalle <> "" Then
            '                    _monto_detalle = IIf(IsDBNull(row_nomina(row_conceptos("detalle"))), 0, row_nomina(row_conceptos("detalle")))
            '                    _total_detalle = IIf(IsDBNull(row_conceptos("total_detalle")), 0, row_conceptos("total_detalle"))
            '                End If

            '                row_conceptos("total_detalle") = _total_detalle + _monto_detalle

            '            Catch ex As Exception
            '                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            '            End Try
            '        Next
            '    End If
            'Next

            dtDatos = New DataTable
            dtDatos.Columns.Add("consecutivo", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("tipo_periodo")

            dtDatos.Columns.Add("per_concepto")
            dtDatos.Columns.Add("per_nombre")
            dtDatos.Columns.Add("per_monto", Type.GetType("System.Double"))
            dtDatos.Columns.Add("per_unidad", Type.GetType("System.Double"))

            dtDatos.Columns.Add("ded_concepto")
            dtDatos.Columns.Add("ded_nombre")
            dtDatos.Columns.Add("ded_monto", Type.GetType("System.Double"))
            dtDatos.Columns.Add("ded_unidad", Type.GetType("System.Double"))

            dtDatos.Columns.Add("total_neto", Type.GetType("System.Double"))
            dtDatos.Columns.Add("headcount", Type.GetType("System.Int32"))

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("consecutivo")}

            Dim consecutivo As Integer = 0

            consecutivo = 0
            For Each row As DataRow In dtConceptos.Select("cod_naturaleza = 'P' and total <> 0", "prioridad")
                Dim drow As DataRow = dtDatos.Rows.Find({consecutivo})
                If drow Is Nothing Then
                    drow = dtDatos.NewRow
                    drow("consecutivo") = consecutivo
                    drow("per_concepto") = row("concepto")
                    drow("per_nombre") = row("nombre")
                    drow("per_monto") = row("total")
                    drow("per_unidad") = row("total_detalle")
                    dtDatos.Rows.Add(drow)
                End If
                consecutivo += 1
            Next

            consecutivo = 0
            For Each row As DataRow In dtConceptos.Select("cod_naturaleza = 'D' and total > 0", "prioridad")
                Dim drow As DataRow = dtDatos.Rows.Find({consecutivo})
                If drow Is Nothing Then
                    drow = dtDatos.NewRow
                    drow("consecutivo") = consecutivo
                    drow("ded_concepto") = row("concepto")
                    drow("ded_nombre") = row("nombre")
                    drow("ded_monto") = row("total")
                    drow("ded_unidad") = row("total_detalle")
                    dtDatos.Rows.Add(drow)
                Else
                    drow("consecutivo") = consecutivo
                    drow("ded_concepto") = row("concepto")
                    drow("ded_nombre") = row("nombre")
                    drow("ded_monto") = row("total")
                    drow("ded_unidad") = row("total_detalle")
                End If
                consecutivo += 1
            Next

            'Jose Hdez 14 may 2020 Agregar bonos de despensa.
            'consecutivo = 0
            For Each row As DataRow In dtConceptos.Select("cod_naturaleza = 'B' and total > 0", "prioridad")
                Dim drow As DataRow = dtDatos.Rows.Find({consecutivo})
                If drow Is Nothing Then
                    drow = dtDatos.NewRow
                    drow("consecutivo") = consecutivo
                    drow("ded_concepto") = row("concepto")
                    drow("ded_nombre") = row("nombre")
                    drow("ded_monto") = row("total")
                    drow("ded_unidad") = row("total_detalle")
                    dtDatos.Rows.Add(drow)
                Else
                    drow("consecutivo") = consecutivo
                    drow("ded_concepto") = row("concepto")
                    drow("ded_nombre") = row("nombre")
                    drow("ded_monto") = row("total")
                    drow("ded_unidad") = row("total_detalle")
                End If
                consecutivo += 1
            Next

            Dim total_neto As Double = 0
            total_neto = dtConceptos.Select("concepto = 'neto'")(0)("total")

            'Estoy agregando el headcount asi para despues validar que va a pasar al cargar varios periodos
            Dim ano As String = dtInformacion.Rows(0)("ano")
            Dim periodo As String = dtInformacion.Rows(0)("periodo")
            Dim tipo_periodo As String = dtInformacion.Rows(0)("tipo_periodo")

            Dim dtHeadcount As DataTable = sqlExecute("select count(reloj) as headcount_nomina from nomina where ano = '" & ano & "' and periodo = '" & periodo & "' and tipo_periodo = '" & tipo_periodo & "' and " & _
                                                      " reloj not in (select reloj from personal.dbo.personal where inactivo = 1)", "nomina")
            Dim headcount As Integer = 0
            headcount = dtHeadcount.Rows(0)("headcount_nomina")

            For Each row As DataRow In dtDatos.Rows
                row("total_neto") = total_neto
                row("headcount") = headcount
                row("tipo_periodo") = IIf(tipo_periodo.Trim = "C", "Cartocenal", IIf(tipo_periodo.Trim = "M", "Mensual", "Semanal"))
            Next


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    'Public Sub ListadoRaya(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
    '    Try
    '        Dim dtConceptos As DataTable
    '        dtConceptos = sqlExecute("select rtrim(concepto) as concepto, rtrim(isnull(unidad, '')) as detalle, nombre, rtrim(cod_naturaleza) as cod_naturaleza, prioridad,0 as orden," & _
    '                                "case when cod_naturaleza = 'I' then 'INFORMATIVOS' " & _
    '                                    "else case when cod_naturaleza = 'P' then 'PERCEPCIONES'" & _
    '                                        "else case when cod_naturaleza = 'D' then 'DEDUCCIONES' " & _
    '                                            "else case when cod_naturaleza = 'E' then 'EXENTOS' " & _
    '                                                "else '' end end end end as 'tipo'" & _
    '                                "from nomina.dbo.conceptos where cod_naturaleza not in('A','V') and not NOMBRE_INGLES is null order by " & _
    '                                "prioridad")

    '        dtConceptos.Columns.Add("total", Type.GetType("System.Double"))
    '        dtConceptos.Columns.Add("total_detalle", Type.GetType("System.Double"))
    '        dtConceptos.PrimaryKey = New DataColumn() {dtConceptos.Columns("concepto")}

    '        Dim cntObject As Object
    '        For Each row_conceptos As DataRow In dtConceptos.Rows
    '            Try
    '                cntObject = dtInformacion.Compute("SUM(" & row_conceptos("concepto") & ")", "")
    '                If Not IsDBNull(cntObject) Then
    '                    row_conceptos("total") = cntObject
    '                End If
    '                If Len(row_conceptos("detalle")) > 0 Then
    '                    cntObject = dtInformacion.Compute("SUM(" & row_conceptos("detalle") & ")", "")
    '                    If Not IsDBNull(cntObject) Then
    '                        row_conceptos("total_detalle") = cntObject
    '                    End If
    '                End If
    '            Catch ex As Exception
    '                Dim serror = ex.Message
    '            End Try
    '        Next

    '        'For Each row_conceptos As DataRow In dtConceptos.Rows
    '        '    If Not IsDBNull(dtInformacion.Columns(row_conceptos("concepto"))) Then
    '        '        For Each row_nomina As DataRow In dtInformacion.Rows
    '        '            Try
    '        '                Dim detalle As String = RTrim(row_conceptos("detalle"))
    '        '                Dim _monto As Double = 0.0
    '        '                Try
    '        '                    _monto = IIf(IsDBNull(row_nomina(row_conceptos("concepto"))), 0, row_nomina(row_conceptos("concepto")))
    '        '                Catch
    '        '                End Try
    '        '                Dim _total_actual As Double = IIf(IsDBNull(row_conceptos("total")), 0, row_conceptos("total"))
    '        '                row_conceptos("total") = _total_actual + _monto

    '        '                Dim _monto_detalle As Double = 0
    '        '                Dim _total_detalle As Double = 0

    '        '                If detalle <> "" Then
    '        '                    _monto_detalle = IIf(IsDBNull(row_nomina(row_conceptos("detalle"))), 0, row_nomina(row_conceptos("detalle")))
    '        '                    _total_detalle = IIf(IsDBNull(row_conceptos("total_detalle")), 0, row_conceptos("total_detalle"))
    '        '                End If

    '        '                row_conceptos("total_detalle") = _total_detalle + _monto_detalle

    '        '            Catch ex As Exception
    '        '                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
    '        '            End Try
    '        '        Next
    '        '    End If
    '        'Next

    '        dtDatos = New DataTable
    '        dtDatos.Columns.Add("consecutivo", Type.GetType("System.Int32"))

    '        dtDatos.Columns.Add("tipo_periodo")

    '        dtDatos.Columns.Add("per_concepto")
    '        dtDatos.Columns.Add("per_nombre")
    '        dtDatos.Columns.Add("per_monto", Type.GetType("System.Double"))
    '        dtDatos.Columns.Add("per_unidad", Type.GetType("System.Double"))

    '        dtDatos.Columns.Add("ded_concepto")
    '        dtDatos.Columns.Add("ded_nombre")
    '        dtDatos.Columns.Add("ded_monto", Type.GetType("System.Double"))
    '        dtDatos.Columns.Add("ded_unidad", Type.GetType("System.Double"))

    '        dtDatos.Columns.Add("total_neto", Type.GetType("System.Double"))
    '        dtDatos.Columns.Add("headcount", Type.GetType("System.Int32"))

    '        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("consecutivo")}

    '        Dim consecutivo As Integer = 0

    '        consecutivo = 0
    '        For Each row As DataRow In dtConceptos.Select("cod_naturaleza = 'P' and total <> 0", "prioridad")
    '            Dim drow As DataRow = dtDatos.Rows.Find({consecutivo})
    '            If drow Is Nothing Then
    '                drow = dtDatos.NewRow
    '                drow("consecutivo") = consecutivo
    '                drow("per_concepto") = row("concepto")
    '                drow("per_nombre") = row("nombre")
    '                drow("per_monto") = row("total")
    '                drow("per_unidad") = row("total_detalle")
    '                dtDatos.Rows.Add(drow)
    '            End If
    '            consecutivo += 1
    '        Next

    '        consecutivo = 0
    '        For Each row As DataRow In dtConceptos.Select("cod_naturaleza = 'D' and total > 0", "prioridad")
    '            Dim drow As DataRow = dtDatos.Rows.Find({consecutivo})
    '            If drow Is Nothing Then
    '                drow = dtDatos.NewRow
    '                drow("consecutivo") = consecutivo
    '                drow("ded_concepto") = row("concepto")
    '                drow("ded_nombre") = row("nombre")
    '                drow("ded_monto") = row("total")
    '                drow("ded_unidad") = row("total_detalle")
    '                dtDatos.Rows.Add(drow)
    '            Else
    '                drow("consecutivo") = consecutivo
    '                drow("ded_concepto") = row("concepto")
    '                drow("ded_nombre") = row("nombre")
    '                drow("ded_monto") = row("total")
    '                drow("ded_unidad") = row("total_detalle")
    '            End If
    '            consecutivo += 1
    '        Next

    '        'Jose Hdez 14 may 2020 Agregar bonos de despensa.
    '        'consecutivo = 0
    '        For Each row As DataRow In dtConceptos.Select("cod_naturaleza = 'B' and total > 0", "prioridad")
    '            Dim drow As DataRow = dtDatos.Rows.Find({consecutivo})
    '            If drow Is Nothing Then
    '                drow = dtDatos.NewRow
    '                drow("consecutivo") = consecutivo
    '                drow("ded_concepto") = row("concepto")
    '                drow("ded_nombre") = row("nombre")
    '                drow("ded_monto") = row("total")
    '                drow("ded_unidad") = row("total_detalle")
    '                dtDatos.Rows.Add(drow)
    '            Else
    '                drow("consecutivo") = consecutivo
    '                drow("ded_concepto") = row("concepto")
    '                drow("ded_nombre") = row("nombre")
    '                drow("ded_monto") = row("total")
    '                drow("ded_unidad") = row("total_detalle")
    '            End If
    '            consecutivo += 1
    '        Next

    '        Dim total_neto As Double = 0
    '        total_neto = dtConceptos.Select("concepto = 'neto'")(0)("total")

    '        'Estoy agregando el headcount asi para despues validar que va a pasar al cargar varios periodos
    '        Dim ano As String = dtInformacion.Rows(0)("ano")
    '        Dim periodo As String = dtInformacion.Rows(0)("periodo")
    '        Dim tipo_periodo As String = dtInformacion.Rows(0)("tipo_periodo")

    '        Dim dtHeadcount As DataTable = sqlExecute("select count(reloj) as headcount_nomina from nomina where ano = '" & ano & "' and periodo = '" & periodo & "' and tipo_periodo = '" & tipo_periodo & "' and " & _
    '                                                  " reloj not in (select reloj from personal.dbo.personal where inactivo = 1)", "nomina")
    '        Dim headcount As Integer = 0
    '        headcount = dtHeadcount.Rows(0)("headcount_nomina")

    '        For Each row As DataRow In dtDatos.Rows
    '            row("total_neto") = total_neto
    '            row("headcount") = headcount
    '            row("tipo_periodo") = IIf(tipo_periodo.Trim = "C", "Cartocenal", IIf(tipo_periodo.Trim = "M", "Mensual", "Semanal"))
    '        Next


    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
    '    End Try
    'End Sub

    Public Sub ListadoRaya(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtConceptos = sqlExecute("select * from conceptos where cod_naturaleza = 'P' or cod_naturaleza = 'D'", "Nomina")
            Dim dtNomina As New DataTable
            dtNomina.Columns.Add("RELOJ")
            dtNomina.Columns.Add("COD_DEPTO")
            dtNomina.Columns.Add("NOMBRE_DEPTO")
            dtNomina.Columns.Add("COD_NATURALEZA")
            dtNomina.Columns.Add("PRIORIDAD")
            dtNomina.Columns.Add("SACTUAL", Type.GetType("System.Double"))
            dtNomina.Columns.Add("INTEGRADO", Type.GetType("System.Double"))
            dtNomina.Columns.Add("ALTA")
            dtNomina.Columns.Add("NOMBRES")
            dtNomina.Columns.Add("REG_PAT")
            dtNomina.Columns.Add("NUMIMSS")
            dtNomina.Columns.Add("CURP")
            dtNomina.Columns.Add("RFC")
            dtNomina.Columns.Add("nombre_puesto")
            dtNomina.Columns.Add("Concepto")
            dtNomina.Columns.Add("Nombre")
            dtNomina.Columns.Add("TotalMonto", Type.GetType("System.Double"))

            For Each row As DataRow In dtInformacion.Rows
                Dim reloj As String = row("reloj").ToString().Trim
                Dim SACTUAL As Double = row("SACTUAL")
                Dim INTEGRADO As Double = row("INTEGRADO")
                Dim ALTA As String = row("ALTA").ToString()
                Dim NOMBRES As String = row("NOMBRES").ToString().Trim
                Dim REG_PATRONAL As String = row("REG_PAT")
                Dim NUMIMSS As String = row("NUMIMSS").ToString().Trim
                Dim CURP As String = row("CURP").ToString().Trim
                Dim RFC As String = row("RFC").ToString().Trim
                Dim COD_DEPTO As String = row("COD_DEPTO").ToString().Trim
                Dim nombre_puesto As String = row("nombre_puesto").ToString().Trim
                Dim Nombre_depto As String = row("NOMBRE_DEPTO").ToString().Trim
                For Each conceptoRow As DataRow In dtConceptos.Rows
                    Dim concepto As String = conceptoRow("Concepto").ToString().Trim
                    Dim cod_naturaleza As String = conceptoRow("cod_naturaleza").ToString().Trim
                    Dim prioridad As String = conceptoRow("prioridad").ToString().Trim
                    Dim nombreConcepto As String = conceptoRow("nombre").ToString().Trim
                    If dtInformacion.Columns.Contains(concepto) Then
                        If Not IsDBNull(row(concepto)) Then
                            Dim monto As Double = row(concepto)
                            If monto > 0 Then
                                dtNomina.Rows.Add(reloj, COD_DEPTO, Nombre_depto, cod_naturaleza, prioridad, SACTUAL, INTEGRADO, ALTA, NOMBRES, REG_PATRONAL, NUMIMSS, CURP, RFC, nombre_puesto, concepto, nombreConcepto, Convert.ToDouble(row(concepto)))
                            End If
                        End If
                    End If
                Next
            Next

            dtDatos = New DataTable
            dtDatos.Columns.Add("consecutivo", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("SACTUAL", Type.GetType("System.Double"))
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("COD_PUESTO")
            dtDatos.Columns.Add("ALTA")
            dtDatos.Columns.Add("NOMBRE_EMPLEADO")
            dtDatos.Columns.Add("SALARIO_INTEGRADO", Type.GetType("System.Double"))
            dtDatos.Columns.Add("RFC")
            dtDatos.Columns.Add("IMSS")
            dtDatos.Columns.Add("COD_NATURALEZA", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("REG_PAT")
            dtDatos.Columns.Add("CURP")
            dtDatos.Columns.Add("NOMBRE_PUESTO")
            dtDatos.Columns.Add("NOMBRE_DEPTO")
            dtDatos.Columns.Add("TOTAL_HORAS", Type.GetType("System.Double"))
            dtDatos.Columns.Add("HORAS_EXTRA", Type.GetType("System.Double"))
            dtDatos.Columns.Add("DIAS_PAGADOS", Type.GetType("System.Double"))


            dtDatos.Columns.Add("PER_CONCEPTO")
            dtDatos.Columns.Add("PER_NOMBRE")
            dtDatos.Columns.Add("PER_MONTO", Type.GetType("System.Double"))

            dtDatos.Columns.Add("DED_CONCEPTO")
            dtDatos.Columns.Add("DED_NOMBRE")
            dtDatos.Columns.Add("DED_MONTO", Type.GetType("System.Double"))


            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("consecutivo")}


            Dim consecutivo As Integer = 0
            For Each row As DataRow In dtNomina.Rows
                Dim drow As DataRow = dtDatos.Rows.Find({consecutivo})
                Dim rowHrs As DataRow = dtInformacion.Select("RELOJ = '" & row("RELOJ") & "'").FirstOrDefault()
                If drow Is Nothing Then
                    drow = dtDatos.NewRow
                    Dim hrsNor As Double = 0
                    Dim hrsEx2 As Double = 0
                    Dim hrsEx3 As Double = 0
                    Dim totalHoras As Double = 0
                    If rowHrs IsNot Nothing Then
                        If dtInformacion.Columns.Contains("HRSNOR") AndAlso Not IsDBNull(rowHrs("HRSNOR")) Then
                            hrsNor = Convert.ToDouble(rowHrs("HRSNOR"))
                        End If

                        If dtInformacion.Columns.Contains("HRSEX2") AndAlso Not IsDBNull(rowHrs("HRSEX2")) Then
                            hrsEx2 = Convert.ToDouble(rowHrs("HRSEX2"))
                        End If

                        If dtInformacion.Columns.Contains("HRSEX3") AndAlso Not IsDBNull(rowHrs("HRSEX3")) Then
                            hrsEx3 = Convert.ToDouble(rowHrs("HRSEX3"))
                        End If

                        totalHoras = hrsNor + hrsEx2 + hrsEx3
                    End If
                    If dtInformacion.Columns.Contains("DIASPA") AndAlso Not IsDBNull(rowHrs("DIASPA")) Then
                        drow("DIAS_PAGADOS") = rowHrs("DIASPA")
                    Else
                        drow("DIAS_PAGADOS") = 0
                    End If
                    drow("TOTAL_HORAS") = totalHoras
                    drow("HORAS_EXTRA") = totalHoras - hrsNor
                    drow("RELOJ") = row("RELOJ")
                    drow("consecutivo") = consecutivo
                    drow("PER_CONCEPTO") = row("concepto")
                    drow("PER_NOMBRE") = row("nombre")
                    drow("PER_MONTO") = row("TotalMonto")
                    drow("SACTUAL") = row("SACTUAL")
                    drow("SALARIO_INTEGRADO") = row("INTEGRADO")
                    drow("NOMBRE_EMPLEADO") = row("NOMBRES")
                    drow("IMSS") = row("NUMIMSS")
                    drow("RFC") = row("RFC")
                    drow("ALTA") = row("ALTA")
                    drow("NOMBRE_PUESTO") = row("nombre_puesto")
                    drow("COD_DEPTO") = row("COD_DEPTO")
                    drow("REG_PAT") = row("REG_PAT")
                    drow("NOMBRE_DEPTO") = row("NOMBRE_DEPTO")
                    drow("CURP") = row("CURP")
                    If (row("COD_NATURALEZA").ToString.Trim = "P") Then
                        drow("COD_NATURALEZA") = 1
                    Else
                        drow("COD_NATURALEZA") = 2
                    End If
                    dtDatos.Rows.Add(drow)
                End If
                consecutivo += 1
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    'Jose R Hdez 4 Marzo 2020 Reportes mensuales
    Public Sub AcumuladoMensual(ByVal dtInformacion As DataTable)
        Try
            Dim anio = My.Forms.frmReporteadorNomina.lstPeriodos.Items(0).ToString.Split("-")(0)
            Dim periodo = My.Forms.frmReporteadorNomina.lstPeriodos.Items(0).ToString.Split("-")(1)
            Dim mes = ""
            Dim dtMes = sqlExecute("select top 1 mes from ta.dbo.periodos where ano = '" & anio & "' and periodo = '" & periodo & "'")
            If dtMes.Rows.Count > 0 Then
                mes = dtMes.Rows(0).Item("mes").ToString.Trim
            End If

            Dim dtPeriodosMensuales As DataTable = sqlExecute("Select periodo, tipo_periodo from ta.dbo.periodos_mensual where ano = '" & anio & "' and mes = '" & mes & "' and periodo_especial = '1'")
            If dtPeriodosMensuales.Rows.Count > 0 Then
                dtResultadoNomina = sqlExecute("EXEC ReporteadorNominaTipoPeriodo_Mensual @Cia = " & CiaReporteador.Replace("''", "'") & ",@ano = '" & anio & "', @periodo = '" & dtPeriodosMensuales.Rows(0).Item("periodo") & _
                                     "',@Nivel = '" & NivelConsulta & "', @reloj = '', @TipoPeriodo = '" & dtPeriodosMensuales.Rows(0).Item("tipo_periodo") & "'", "nomina")
                dtResultadoNomina.Columns.Add("periodos")
                dtInformacion.Merge(dtResultadoNomina)
            End If

            dtResultadoNomina = sqlExecute("EXEC ReporteadorNominaTipoPeriodo_finiquitos_reportemensual @Cia = " & CiaReporteador.Replace("''", "'") & ",@Nivel = '" & NivelConsulta & "'", "nomina")
            dtResultadoNomina.Columns.Add("periodos")
            dtInformacion.Merge(dtResultadoNomina)
            Dim dtConceptos As DataTable
            dtConceptos = sqlExecute("select rtrim(concepto) as concepto, rtrim(isnull(detalle, '')) as detalle, nombre, rtrim(cod_naturaleza) as cod_naturaleza, prioridad,0 as orden,exento,positivo,suma_neto,orden_reportemensual_1,orden_reportemensual_2," & _
                                    "case when cod_naturaleza = 'I' then 'INFORMATIVOS' " & _
                                        "else case when cod_naturaleza = 'P' then 'PERCEPCIONES'" & _
                                            "else case when cod_naturaleza = 'D' then 'DEDUCCIONES' " & _
                                                "else case when cod_naturaleza = 'E' then 'EXENTOS' " & _
                                                    "else '' end end end end as 'tipo'" & _
                                    "from nomina.dbo.conceptos where activo=1 order by " & _
                                    "prioridad")
            dtConceptos.Columns.Add("total", Type.GetType("System.Double"))
            dtConceptos.Columns.Add("total_detalle", Type.GetType("System.Double"))
            dtConceptos.PrimaryKey = New DataColumn() {dtConceptos.Columns("concepto")}

            Dim cntObject As Object
            For Each row_conceptos As DataRow In dtConceptos.Rows
                cntObject = dtInformacion.Compute("SUM(" & row_conceptos("concepto") & ")", "")
                If Not IsDBNull(cntObject) Then
                    row_conceptos("total") = cntObject
                End If
                If Len(row_conceptos("detalle")) > 0 Then
                    cntObject = dtInformacion.Compute("SUM(" & row_conceptos("detalle") & ")", "")
                    If Not IsDBNull(cntObject) Then
                        row_conceptos("total_detalle") = cntObject
                    End If
                End If
            Next

            Dim dtDatos = New DataTable
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("tipo_periodo")
            For Each row As DataRow In dtConceptos.Select("positivo = 1 and total > 0 and suma_neto = 1", "prioridad")
                dtDatos.Columns.Add(row("concepto"))
            Next
            dtDatos.Columns.Add("BONDES", Type.GetType("System.Double"))
            dtDatos.Columns.Add("totper")
            For Each row As DataRow In dtConceptos.Select("positivo = 0 and total > 0 and suma_neto = 1", "prioridad")
                dtDatos.Columns.Add(row("concepto"))
            Next
            dtDatos.Columns.Add("totded")
            Dim dtConceptosExentos = sqlExecute("Select concepto FROM Nomina.dbo.conceptos where concepto in (select distinct exento from nomina.dbo.conceptos)")
            For Each row As DataRow In dtConceptosExentos.Rows
                dtDatos.Columns.Add(row("concepto"))
            Next
            Dim promMensualObrerors = 0
            Dim promMensualOficinas = 0
            Dim fondoAhorroObreros = 0.0
            Dim fondoAhorroOficinas = 0.0
            'Dim despensaSemanal = 0.0
            'Dim despensaQuincenal = 0.0
            Dim salariosPagadosObreros = 0.0
            Dim salariosPagadosOficinas = 0.0
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}
            For Each row_nomina As DataRow In dtInformacion.Rows
                Dim drow As DataRow = dtDatos.Rows.Find({row_nomina("reloj")})
                Dim newRow As Boolean = False
                If IsNothing(drow) Then
                    newRow = True
                End If

                If newRow Then
                    drow = dtDatos.NewRow
                    drow("reloj") = row_nomina("reloj")
                    drow("nombres") = row_nomina("nombres")
                End If

                'If row_nomina("reloj") = "010141" Then
                '    Debugger.Break()
                'End If

                If row_nomina("tipo_periodo") = "Q" Then
                    drow("tipo_periodo") = "Quincenal"
                    If newRow Then promMensualOficinas = promMensualOficinas + 1
                ElseIf row_nomina("tipo_periodo") = "S" Then
                    drow("tipo_periodo") = "Semanal"
                    If newRow Then promMensualObrerors = promMensualObrerors + 1
                ElseIf row_nomina("tipo_periodo") = "M" Then
                    drow("tipo_periodo") = "Mensual"
                End If
                For Each row As DataRow In dtConceptos.Select("(cod_naturaleza = 'P' or cod_naturaleza = 'D') and total > 0 and suma_neto = 1")
                    If Not IsDBNull(row_nomina(row("concepto"))) Then
                        drow(row("concepto")) = IIf(IsDBNull(drow(row("concepto"))), 0.0, drow(row("concepto"))) + row_nomina(row("concepto"))
                    End If
                Next
                For Each row As DataRow In dtConceptos.Select("concepto = 'BONDES' or concepto = 'BONPA1' or concepto = 'BONPA2' or concepto = 'BONPA3'")
                    If IsDBNull(drow("BONDES")) Then
                        drow("BONDES") = 0
                    End If
                    If drow("BONDES") <= 0 Then
                        drow("BONDES") = IIf(IsDBNull(row_nomina(row("concepto").ToString.TrimEnd)), 0.0, row_nomina(row("concepto").ToString.TrimEnd))
                        'If row_nomina("tipo_periodo") = "S" Then
                        '    despensaSemanal = despensaSemanal + drow("BONDES")
                        'End If
                        'If row_nomina("tipo_periodo") = "Q" Then
                        '    despensaQuincenal = despensaQuincenal + drow("BONDES")
                        'End If
                    Else
                        drow("BONDES") = drow("BONDES") + IIf(IsDBNull(row_nomina(row("concepto").ToString.TrimEnd)), 0.0, row_nomina(row("concepto").ToString.TrimEnd))
                    End If
                Next
                For Each row As DataRow In dtConceptosExentos.Rows
                    Try
                        If IsDBNull(drow(row("concepto"))) Then drow(row("concepto")) = 0.0
                        drow(row("concepto")) = drow(row("concepto")) + row_nomina(row("concepto").ToString.TrimEnd)
                    Catch
                    End Try
                Next

                If newRow Then dtDatos.Rows.Add(drow)
            Next



            Dim total_neto As Double = 0
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.FileName = "Acumulado Mensual.xlsx"
            saveFileDialog1.Filter = "Excel File|*.xlsx"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True
            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim File = New FileInfo(DireccionReportes & "Plantilla BRP QRO Acumulado Mensual.xlsx")
                Using package As New ExcelPackage(File)
                    package.Load(New FileStream(DireccionReportes & "Plantilla BRP QRO Acumulado Mensual.xlsx", FileMode.Open))
                    Dim workSheet As ExcelWorksheet = package.Workbook.Worksheets("Acumulado")
                    workSheet.Cells("A2").Value = "Acumulado " & mes & " " & anio
                    Dim x As Integer = 0
                    Dim y As Integer = 0
                    x = 4
                    y = 4
                    For Each row_conceptos As DataRow In dtConceptos.Select("cod_naturaleza = 'P' and total > 0 ", "prioridad")
                        workSheet.Cells(x, y).Value = row_conceptos("nombre").ToString
                        workSheet.Cells(x + 1, y).Value = row_conceptos("concepto").ToString
                        y = y + 1
                    Next
                    workSheet.Cells(x, y).Value = "PERCEPCIÓN TOTAL"
                    workSheet.Cells(x + 1, y).Value = "TOTPER"
                    y = y + 1
                    For Each row_conceptos As DataRow In dtConceptos.Select("cod_naturaleza = 'D' and total > 0 ", "prioridad")
                        workSheet.Cells(x, y).Value = row_conceptos("nombre").ToString
                        workSheet.Cells(x + 1, y).Value = row_conceptos("concepto").ToString
                        y = y + 1
                    Next
                    workSheet.Cells(x, y).Value = "TOTAL DEDUCCIONES"
                    workSheet.Cells(x + 1, y).Value = "TOTDED"
                    y = y + 1
                    workSheet.Cells(x, y).Value = "NETO"
                    workSheet.Cells(x + 1, y).Value = "NETO"
                    x = 6
                    For Each dr As DataRow In dtDatos.Rows
                        y = 1
                        workSheet.Cells(x, y).Value = dr("reloj").ToString
                        workSheet.Cells(x, y + 1).Value = dr("nombres").ToString
                        workSheet.Cells(x, y + 2).Value = dr("tipo_periodo").ToString
                        y = 4
                        For Each row_conceptos As DataRow In dtConceptos.Select("cod_naturaleza = 'P' and total > 0 ", "prioridad")
                            If dr(row_conceptos("concepto")).ToString.Length = 0 Then
                                workSheet.Cells(x, y).Value = 0
                            Else
                                workSheet.Cells(x, y).Value = Double.Parse(dr(row_conceptos("concepto")))
                            End If
                            y = y + 1
                        Next
                        workSheet.Cells(x, y).Formula = "=SUM(" & workSheet.Cells(x, 4).Address.ToString & ":" & workSheet.Cells(x, y - 1).Address.ToString & ")"
                        y = y + 1
                        Dim colDed = y
                        For Each row_conceptos As DataRow In dtConceptos.Select("cod_naturaleza = 'D' and total > 0 ", "prioridad")
                            If dr(row_conceptos("concepto")).ToString.Length = 0 Then
                                workSheet.Cells(x, y).Value = 0
                            Else
                                workSheet.Cells(x, y).Value = Double.Parse(dr(row_conceptos("concepto")))
                            End If
                            y = y + 1
                        Next
                        workSheet.Cells(x, y).Formula = "=SUM(" & workSheet.Cells(x, colDed).Address.ToString & ":" & workSheet.Cells(x, y - 1).Address.ToString & ")"
                        y = y + 1
                        workSheet.Cells(x, y).Formula = "=round(" & workSheet.Cells(x, colDed - 1).Address.ToString & "-" & workSheet.Cells(x, y - 1).Address.ToString & ",2)"
                        x = x + 1
                    Next
                    For m = 4 To y
                        workSheet.Cells(x, m).Formula = "=SUM(" & workSheet.Cells(6, m).Address.ToString & ":" & workSheet.Cells(x - 1, m).Address.ToString & ")"
                    Next

                    workSheet = package.Workbook.Worksheets("Exentos y gravados")
                    workSheet.Cells("A2").Value = "Exentos y gravados " & mes & " " & anio
                    x = 4
                    y = 4
                    For Each row_conceptos As DataRow In dtConceptos.Select("cod_naturaleza = 'P' and total > 0 and orden_reportemensual_1 is not null", "orden_reportemensual_1")
                        workSheet.Cells(x, y).Value = row_conceptos("nombre").ToString
                        workSheet.Cells(x + 1, y).Value = row_conceptos("concepto").ToString
                        y = y + 1
                        workSheet.Cells(x + 1, y).Value = row_conceptos("concepto").ToString & "_gravado"
                        y = y + 1
                        workSheet.Cells(x + 1, y).Value = row_conceptos("concepto").ToString & "_exento"
                        y = y + 1
                    Next
                    workSheet.Cells(x, y).Value = "PERCEPCIÓN TOTAL"
                    workSheet.Cells(x + 1, y).Value = "TOTPER"
                    y = y + 1
                    'Segunda hora paraisr diferente de cero
                    For Each row_conceptos As DataRow In dtConceptos.Select("cod_naturaleza = 'D' and total > 0 and orden_reportemensual_1 is not null", "orden_reportemensual_1")
                        workSheet.Cells(x, y).Value = row_conceptos("nombre").ToString
                        workSheet.Cells(x + 1, y).Value = row_conceptos("concepto").ToString
                        y = y + 1
                        workSheet.Cells(x + 1, y).Value = row_conceptos("concepto").ToString & "_gravado"
                        y = y + 1
                        workSheet.Cells(x + 1, y).Value = row_conceptos("concepto").ToString & "_exento"
                        y = y + 1
                    Next
                    workSheet.Cells(x, y).Value = "TOTAL DEDUCCIONES"
                    workSheet.Cells(x + 1, y).Value = "TOTDED"
                    y = y + 1
                    workSheet.Cells(x, y).Value = "NETO"
                    workSheet.Cells(x + 1, y).Value = "NETO"
                    x = 6
                    For Each dr As DataRow In dtDatos.Rows
                        y = 1
                        workSheet.Cells(x, y).Value = dr("reloj").ToString
                        y = y + 1
                        workSheet.Cells(x, y).Value = dr("nombres").ToString
                        y = y + 1
                        workSheet.Cells(x, y).Value = dr("tipo_periodo").ToString
                        y = y + 1
                        Dim totper = 0.0
                        For Each row_conceptos As DataRow In dtConceptos.Select("cod_naturaleza = 'P' and total > 0 and orden_reportemensual_1 is not null", "orden_reportemensual_1")
                            If dr(row_conceptos("concepto")).ToString.Length = 0 Then
                                workSheet.Cells(x, y).Value = 0
                            Else
                                workSheet.Cells(x, y).Value = Double.Parse(dr(row_conceptos("concepto")))
                                totper = totper + Double.Parse(dr(row_conceptos("concepto")))
                            End If
                            y = y + 1
                            workSheet.Cells(x, y).Formula = "=" & workSheet.Cells(x, y - 1).Address.ToString & " - " & workSheet.Cells(x, y + 1).Address.ToString
                            y = y + 1
                            Dim cantExento = 0.0
                            For Each row_esteexento As DataRow In dtDatos.Select("reloj = '" & dr("reloj").ToString & "'")
                                If row_conceptos("exento").ToString.Trim.Length > 0 Then
                                    If row_esteexento(row_conceptos("exento")).ToString.Length = 0 Then
                                        cantExento = 0.0
                                    Else
                                        cantExento = IIf(IsDBNull(dr(row_conceptos("exento"))), 0.0, dr(row_conceptos("exento")))
                                    End If
                                End If
                            Next
                            workSheet.Cells(x, y).Value = cantExento
                            y = y + 1
                        Next
                        workSheet.Cells(x, y).Value = totper
                        y = y + 1
                        Dim totded = 0.0
                        For Each row_conceptos As DataRow In dtConceptos.Select("cod_naturaleza = 'D' and total > 0 and orden_reportemensual_1 is not null", "orden_reportemensual_1")
                            If dr(row_conceptos("concepto")).ToString.Length = 0 Then
                                workSheet.Cells(x, y).Value = 0
                            Else
                                workSheet.Cells(x, y).Value = Double.Parse(dr(row_conceptos("concepto")))
                                totded = totded + Double.Parse(dr(row_conceptos("concepto")))
                            End If
                            y = y + 1
                            workSheet.Cells(x, y).Formula = "=" & workSheet.Cells(x, y - 1).Address.ToString & " - " & workSheet.Cells(x, y + 1).Address.ToString
                            y = y + 1
                            Dim cantExento = 0.0
                            For Each row_esteexento As DataRow In dtDatos.Select("reloj = '" & dr("reloj").ToString & "'")
                                If row_conceptos("exento").ToString.Trim.Length > 0 Then
                                    If row_esteexento(row_conceptos("exento")).ToString.Length = 0 Then
                                        cantExento = 0.0
                                    Else
                                        cantExento = dr(row_conceptos("exento"))
                                    End If
                                End If
                            Next
                            workSheet.Cells(x, y).Value = cantExento
                            y = y + 1
                        Next
                        workSheet.Cells(x, y).Value = totded
                        y = y + 1
                        workSheet.Cells(x, y).Value = totper - totded
                        x = x + 1
                    Next
                    For m = 4 To y
                        workSheet.Cells(x, m).Formula = "=SUM(" & workSheet.Cells(6, m).Address.ToString & ":" & workSheet.Cells(x - 1, m).Address.ToString & ")"
                    Next

                    workSheet = package.Workbook.Worksheets("Impuesto estatal")
                    workSheet.Cells("A2").Value = "Impuesto estatal " & mes & " " & anio
                    Dim uma = 0.0
                    Dim bondes = 0.0
                    Dim dtCia = sqlExecute("select uma from personal.dbo.cias where cod_comp = '610'")
                    If dtCia.Rows.Count > 0 Then
                        Try
                            uma = Double.Parse(dtCia.Rows(0)("uma"))
                        Catch
                            uma = 0.0
                        End Try
                    End If
                    x = 4
                    y = 4
                    For Each row_conceptos As DataRow In dtConceptos.Select("cod_naturaleza = 'P' and total > 0 and suma_neto = 1 and orden_reportemensual_2 is not null or concepto = 'APOFAH'", "orden_reportemensual_2")
                        If row_conceptos("concepto").ToString.TrimEnd = "APOFAH" Then
                            workSheet.Cells(x, y).Value = "BONO DE DESPENSA"
                            workSheet.Cells(x + 1, y).Value = "APOCIA"
                        Else
                            workSheet.Cells(x, y).Value = row_conceptos("nombre").ToString
                            workSheet.Cells(x + 1, y).Value = row_conceptos("concepto").ToString
                        End If
                        y = y + 1
                    Next
                    workSheet.Cells(x, y).Value = ""
                    workSheet.Cells(x + 1, y).Value = "BONDES"
                    y = y + 1
                    workSheet.Cells(x, y).Value = "PERCEPCIÓN TOTAL"
                    workSheet.Cells(x + 1, y).Value = "TOTPER"
                    y = y + 1
                    For Each row_conceptos As DataRow In dtConceptos.Select("cod_naturaleza = 'D' and total > 0 and suma_neto = 1 and orden_reportemensual_2 is not null", "orden_reportemensual_2")
                        If row_conceptos("concepto").ToString.TrimEnd <> "APOFAH" Then
                            workSheet.Cells(x, y).Value = row_conceptos("nombre").ToString
                            workSheet.Cells(x + 1, y).Value = row_conceptos("concepto").ToString
                            y = y + 1
                        End If
                    Next
                    workSheet.Cells(x, y).Value = "TOTAL DEDUCCIONES"
                    workSheet.Cells(x + 1, y).Value = "TOTDED"
                    y = y + 1
                    workSheet.Cells(x, y).Value = "NETO"
                    workSheet.Cells(x + 1, y).Value = "NETO"
                    y = y + 1
                    workSheet.Cells(x, y).Value = "no_acumula_para_2porc"
                    workSheet.Cells(x + 1, y).Value = "no_acumula_para_2porc"
                    x = 6

                    For Each dr As DataRow In dtDatos.Rows
                        y = 1
                        workSheet.Cells(x, y).Value = dr("reloj").ToString
                        workSheet.Cells(x, y + 1).Value = dr("nombres").ToString
                        workSheet.Cells(x, y + 2).Value = dr("tipo_periodo").ToString
                        y = 4
                        'Si el concepto es APOFAH guardarlo en semanal y quincenal para el reporte INEGI
                        For Each row_conceptos As DataRow In dtConceptos.Select("cod_naturaleza = 'P' and total > 0 and suma_neto = 1 and orden_reportemensual_2 is not null or concepto = 'APOFAH'", "orden_reportemensual_2")
                            If dr(row_conceptos("concepto")).ToString.Length = 0 Then
                                workSheet.Cells(x, y).Value = 0
                            Else
                                workSheet.Cells(x, y).Value = Double.Parse(dr(row_conceptos("concepto")))
                                If dr("tipo_periodo") = "Semanal" Then
                                    If row_conceptos("concepto") = "APOFAH" Then
                                        fondoAhorroObreros = fondoAhorroObreros + Double.Parse(dr(row_conceptos("concepto")))
                                    End If
                                    If Not (row_conceptos("concepto") = "DEVFNT" Or row_conceptos("concepto") = "PERPTU" Or row_conceptos("concepto") = "ISRAFA" Or row_conceptos("concepto") = "BONDEE" Or row_conceptos("concepto") = "APOFAH" Or row_conceptos("concepto") = "IDEAS") Then
                                        salariosPagadosObreros = salariosPagadosObreros + Double.Parse(dr(row_conceptos("concepto")))
                                    End If
                                End If
                                If dr("tipo_periodo") = "Quincenal" Then
                                    If row_conceptos("concepto") = "APOFAH" Then
                                        fondoAhorroOficinas = fondoAhorroOficinas + Double.Parse(dr(row_conceptos("concepto")))
                                    End If
                                    If Not (row_conceptos("concepto") = "DEVFNT" Or row_conceptos("concepto") = "PERPTU" Or row_conceptos("concepto") = "ISRAFA" Or row_conceptos("concepto") = "BONDEE" Or row_conceptos("concepto") = "APOFAH" Or row_conceptos("concepto") = "IDEAS") Then
                                        salariosPagadosOficinas = salariosPagadosOficinas + Double.Parse(dr(row_conceptos("concepto")))
                                    End If
                                End If
                            End If
                            y = y + 1
                        Next
                        For Each row_conceptos As DataRow In dtConceptos.Select("concepto = 'BONDES'")
                            If dr(row_conceptos("concepto")).ToString.Length = 0 Then
                                bondes = 0.0
                            Else
                                bondes = Double.Parse(dr(row_conceptos("concepto")))
                            End If
                            workSheet.Cells(x, y).Value = bondes
                            y = y + 1
                        Next
                        workSheet.Cells(x, y).Formula = "=SUM(" & workSheet.Cells(x, 4).Address.ToString & ":" & workSheet.Cells(x, y - 1).Address.ToString & ")"
                        y = y + 1
                        Dim colDed = y
                        For Each row_conceptos As DataRow In dtConceptos.Select("cod_naturaleza = 'D' and total > 0 and suma_neto = 1 and orden_reportemensual_2 is not null", "orden_reportemensual_2")
                            If row_conceptos("concepto").ToString.TrimEnd <> "APOFAH" Then
                                If dr(row_conceptos("concepto")).ToString.Length = 0 Then
                                    workSheet.Cells(x, y).Value = 0
                                Else
                                    workSheet.Cells(x, y).Value = Double.Parse(dr(row_conceptos("concepto")))
                                End If
                                If Not IsDBNull(dr(row_conceptos("concepto"))) Then
                                    If dr("tipo_periodo") = "Semanal" Then
                                        salariosPagadosObreros = salariosPagadosObreros - Double.Parse(dr(row_conceptos("concepto")))
                                    End If
                                    If dr("tipo_periodo") = "Quincenal" Then
                                        salariosPagadosOficinas = salariosPagadosOficinas - Double.Parse(dr(row_conceptos("concepto")))
                                    End If
                                End If
                                y = y + 1
                            End If
                        Next
                        workSheet.Cells(x, y).Formula = "=SUM(" & workSheet.Cells(x, colDed).Address.ToString & ":" & workSheet.Cells(x, y - 1).Address.ToString & ")"
                        y = y + 1
                        workSheet.Cells(x, y).Formula = "=(" & workSheet.Cells(x, colDed - 1).Address.ToString & "-" & workSheet.Cells(x, y - 1).Address.ToString & ")"
                        y = y + 1
                        Dim tope = uma * 30 * 0.4
                        workSheet.Cells(x, y).Value = IIf(bondes >= tope, tope, bondes)
                        x = x + 1
                    Next
                    Dim ultimox = x
                    Dim ultimoy = y

                    For m = 4 To y
                        workSheet.Cells(x, m).Formula = "=SUM(" & workSheet.Cells(6, m).Address.ToString & ":" & workSheet.Cells(x - 1, m).Address.ToString & ")"
                    Next
                    x = x + 2
                    y = 4
                    Dim xinicuadro = x
                    workSheet.Cells(x, y).Value = "Total de Base"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    x = x + 1
                    y = 3
                    workSheet.Cells(x, y).Value = "Querétaro"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.Font.Color.SetColor(Color.Blue)
                    x = x + 1
                    workSheet.Cells(x, y).Value = "Ingreso"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.Indent = 9
                    y = 4
                    workSheet.Cells(x, y).Formula = "=" & workSheet.Cells(ultimox, ultimoy - 1).Address.ToString & "-" & workSheet.Cells(ultimox, ultimoy).Address.ToString
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.Numberformat.Format = "$##,###,###.00"
                    workSheet.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    workSheet.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.Orange)
                    x = x + 1
                    y = 3
                    workSheet.Cells(x, y).Value = "Deducción"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.Font.Color.SetColor(Color.Red)
                    workSheet.Cells(x, y).Style.Indent = 9
                    y = 4
                    workSheet.Cells(x, y).Style.Numberformat.Format = "##,###,###.00"
                    'workSheet.Cells(x, y).Value = uma * 8 * 30.5
                    workSheet.Cells(x, y).Value = uma * 133 * 30.4
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.Font.Color.SetColor(Color.Red)
                    x = x + 1
                    y = 3
                    workSheet.Cells(x, y).Value = "Base"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.Indent = 9
                    y = 4
                    workSheet.Cells(x, y).Style.Numberformat.Format = "##,###,###.00"
                    workSheet.Cells(x, y).Formula = "=" & workSheet.Cells(x - 2, y).Address.ToString & "-" & workSheet.Cells(x - 1, y).Address.ToString
                    x = x + 1
                    y = 3
                    workSheet.Cells(x, y).Value = "% de Impuesto"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.Indent = 9
                    y = 4
                    workSheet.Cells(x, y).Value = "1.60%"
                    workSheet.Cells(x, y).Style.Numberformat.Format = "0.00%"
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right
                    x = x + 1
                    y = 3
                    workSheet.Cells(x, y).Value = "Impuesto"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.Indent = 9
                    y = 4
                    workSheet.Cells(x, y).Style.Numberformat.Format = "##,###,###.00"
                    workSheet.Cells(x, y).Formula = "=" & workSheet.Cells(x - 2, y).Address.ToString & "*" & workSheet.Cells(x - 1, y).Address.ToString
                    x = x + 1
                    y = 3
                    workSheet.Cells(x, y).Value = "% de Impuesto 2"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.Indent = 9
                    y = 4
                    workSheet.Cells(x, y).Value = "25%"
                    workSheet.Cells(x, y).Style.Numberformat.Format = "0.00%"
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right
                    x = x + 1
                    y = 3
                    workSheet.Cells(x, y).Value = "Impuesto 2"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.Indent = 9
                    y = 4
                    workSheet.Cells(x, y).Style.Numberformat.Format = "##,###,###.00"
                    workSheet.Cells(x, y).Formula = "=" & workSheet.Cells(x - 2, y).Address.ToString & "*" & workSheet.Cells(x - 1, y).Address.ToString
                    x = x + 1
                    y = 3
                    workSheet.Cells(x, y).Value = "Impuesto Estatal"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.Indent = 9
                    y = 4
                    workSheet.Cells(x, y).Formula = "=" & workSheet.Cells(x - 3, y).Address.ToString & "+" & workSheet.Cells(x - 1, y).Address.ToString
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.Numberformat.Format = "$##,###,###.00"
                    Dim xfincuadro = x
                    For i = xinicuadro To xfincuadro
                        workSheet.Cells("C" & i & ":D" & i).Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick)
                    Next
                    package.SaveAs(New System.IO.FileInfo(saveFileDialog1.FileName.ToString()))
                End Using
            End If

            Dim horasNormalesObreros = 0.0
            'Dim horasDoblesObreros = 0.0
            'Dim horasTriplesObreros = 0.0
            Dim horasExtrasObreros = 0.0
            Dim dtPeriodosSemanal = sqlExecute("Select periodo FROM ta.dbo.periodos where ano = '" & anio & "' and mes = '" & mes & "' and PERIODO_ESPECIAL = 0")
            For Each row As DataRow In dtPeriodosSemanal.Rows
                'Dim dtHorasObreros = sqlExecute("select sum(hrs_normales) as sumhrsnormales, sum(hrs_dobles) as sumhrsdobles,sum(hrs_triples) as sumhrstriples from ta.dbo.nomsem where ano = '" & anio & "' and periodo = '" & row("periodo") & "' " & _
                '"and reloj in ( " & _
                '"Select Reloj " & _
                '"  FROM [NOMINA].[dbo].[nomina] " & _
                '"  where ano = '" & anio & "' " & _
                '"  and periodo = '" & row("periodo") & "' " & _
                '"  and tipo_periodo = 'S' " & _
                '")")
                Try
                    Dim dtRelojesPeriodos = dtInformacion.Select("periodo = '" & row("periodo") & "' and tipo_periodo = 'S'", "reloj").CopyToDataTable
                    Dim strRelojes = ""
                    For Each rowRelojes As DataRow In dtRelojesPeriodos.Rows
                        strRelojes = strRelojes + "'" + rowRelojes("reloj") + "',"
                    Next
                    strRelojes = strRelojes + ","
                    strRelojes = strRelojes.Replace(",,", "")
                    Dim dtHorasObreros = sqlExecute("SELECT sum(ta.dbo.HToD(horas_normales)) as sumhrsnormales, sum(ta.dbo.HToD(horas_extras)) as sumhrsextras from ta.dbo.asist where cod_comp = '610' and ano = '" & anio & "' and periodo = '" & row("periodo") & "' and ausentismo = 0 " & _
                    "and reloj in ( " & strRelojes & ")")
                    For Each rowhrs As DataRow In dtHorasObreros.Rows
                        horasNormalesObreros = horasNormalesObreros + IIf(IsDBNull(rowhrs("sumhrsnormales")), 0.0, rowhrs("sumhrsnormales"))
                        horasExtrasObreros = horasExtrasObreros + IIf(IsDBNull(rowhrs("sumhrsextras")), 0.0, rowhrs("sumhrsextras"))
                        'horasDoblesObreros = horasDoblesObreros + IIf(IsDBNull(rowhrs("sumhrsdobles")), 0.0, rowhrs("sumhrsdobles"))
                        'horasTriplesObreros = horasTriplesObreros + IIf(IsDBNull(rowhrs("sumhrstriples")), 0.0, rowhrs("sumhrstriples"))
                    Next
                Catch
                End Try
            Next

            Dim horasNormalesOficinas = 0.0
            'Dim horasDoblesOficinas = 0.0
            'Dim horasTriplesOficinas = 0.0
            Dim horasExtrasOficinas = 0.0
            Dim dtPeriodosQuincenal = sqlExecute("Select periodo FROM ta.dbo.periodos_quincenal where ano = '" & anio & "' and mes = '" & mes & "'")
            For Each row As DataRow In dtPeriodosQuincenal.Rows
                Try
                    Dim dtRelojesPeriodos = dtInformacion.Select("periodo = '" & row("periodo") & "' and tipo_periodo = 'Q'", "reloj").CopyToDataTable
                    horasNormalesOficinas = horasNormalesOficinas + dtRelojesPeriodos.Rows.Count
                Catch ex As Exception
                End Try
                'Dim dtHorasOficinas = sqlExecute("select sum(hrs_normales) as sumhrsnormales, sum(hrs_dobles) as sumhrsdobles,sum(hrs_triples) as sumhrstriples from ta.dbo.nomsem where ano = '" & anio & "' and periodo = '" & row("periodo") & "' " & _
                Dim dtHorasOficinas = sqlExecute("select sum(ta.dbo.HToD(horas_normales)) as sumhrsnormales, sum(ta.dbo.HToD(horas_extras)) as sumhrsextras from ta.dbo.asist where cod_comp = '610' and ano = '" & anio & "' and periodo = '" & row("periodo") & "' " & _
                    "and reloj in ( " & _
                    "Select Reloj " & _
                    "  FROM [NOMINA].[dbo].[nomina] " & _
                    "  where ano = '" & anio & "' " & _
                    "  and periodo = '" & row("periodo") & "' " & _
                    "  and tipo_periodo = 'Q' " & _
                    ")")
                For Each rowhrs As DataRow In dtHorasOficinas.Rows
                    'horasNormalesOficinas = horasNormalesOficinas + IIf(IsDBNull(rowhrs("sumhrsnormales")), 0.0, rowhrs("sumhrsnormales"))
                    horasExtrasOficinas = horasExtrasOficinas + IIf(IsDBNull(rowhrs("sumhrsextras")), 0.0, rowhrs("sumhrsextras"))
                    'horasDoblesOficinas = horasDoblesOficinas + IIf(IsDBNull(rowhrs("sumhrsdobles")), 0.0, rowhrs("sumhrsdobles"))
                    'horasTriplesOficinas = horasTriplesOficinas + IIf(IsDBNull(rowhrs("sumhrstriples")), 0.0, rowhrs("sumhrstriples"))
                Next
            Next
            horasNormalesOficinas = horasNormalesOficinas * 9.6

            Dim saveFileDialog2 As New SaveFileDialog()
            saveFileDialog2.FileName = "INEGI Reporte mensual.xlsx"
            saveFileDialog2.Filter = "Excel File|*.xlsx"
            saveFileDialog2.FilterIndex = 2
            saveFileDialog2.RestoreDirectory = True
            If saveFileDialog2.ShowDialog() = DialogResult.OK Then
                Dim File = New FileInfo(DireccionReportes & "Plantilla INEGI Reporte mensual.xlsx")
                Using package As New ExcelPackage(File)
                    package.Load(New FileStream(DireccionReportes & "Plantilla INEGI Reporte mensual.xlsx", FileMode.Open))
                    Dim workSheet As ExcelWorksheet = package.Workbook.Worksheets("Hoja1")
                    workSheet.Cells("B2").Value = "Reporte mensual para INEGI " & anio
                    workSheet.Cells("C3").Value = mes
                    workSheet.Cells(6, 3).Style.Numberformat.Format = "##,###,###"
                    workSheet.Cells(6, 3).Value = promMensualObrerors
                    workSheet.Cells(6, 4).Style.Numberformat.Format = "##,###,###"
                    workSheet.Cells(6, 4).Value = promMensualOficinas
                    workSheet.Cells(7, 3).Style.Numberformat.Format = "##,###,##0.00"
                    'Dim cntObreros = dtInformacion.Compute("Count(reloj)", "tipo_periodo = 'Q' and periodo = '07'")
                    workSheet.Cells(7, 3).Value = horasNormalesObreros
                    workSheet.Cells(7, 4).Style.Numberformat.Format = "##,###,##0.00"
                    workSheet.Cells(7, 4).Value = horasNormalesOficinas
                    workSheet.Cells(8, 3).Style.Numberformat.Format = "##,###,##0.00"
                    'workSheet.Cells(8, 3).Value = horasDoblesObreros + horasTriplesObreros
                    workSheet.Cells(8, 3).Value = horasExtrasObreros
                    workSheet.Cells(8, 4).Style.Numberformat.Format = "##,###,##0.00"
                    'workSheet.Cells(8, 4).Value = horasDoblesOficinas + horasTriplesOficinas
                    workSheet.Cells(8, 4).Value = horasExtrasOficinas
                    workSheet.Cells(11, 3).Style.Numberformat.Format = "##,###,##0.00"
                    workSheet.Cells(11, 3).Value = salariosPagadosObreros
                    workSheet.Cells(12, 4).Style.Numberformat.Format = "##,###,##0.00"
                    workSheet.Cells(12, 4).Value = salariosPagadosOficinas
                    workSheet.Cells(15, 3).Style.Numberformat.Format = "##,###,##0.00"
                    Dim cntUtilidades = dtInformacion.Compute("SUM(PERPTU)", "")
                    workSheet.Cells(15, 3).Value = cntUtilidades
                    workSheet.Cells(21, 3).Style.Numberformat.Format = "##,###,##0.00"
                    workSheet.Cells(21, 3).Value = fondoAhorroObreros
                    workSheet.Cells(21, 4).Style.Numberformat.Format = "##,###,##0.00"
                    workSheet.Cells(21, 4).Value = fondoAhorroOficinas
                    workSheet.Cells(22, 3).Style.Numberformat.Format = "##,###,##0.00"
                    Dim cntBONDES, cntBONPA1, cntBONPA2, cntBONPA3
                    Try
                        cntBONDES = dtInformacion.Compute("SUM(BONDES)", "tipo_periodo = 'S'")
                        If IsDBNull(cntBONDES) Then cntBONDES = 0.0
                        cntBONPA1 = dtInformacion.Compute("SUM(BONPA1)", "tipo_periodo = 'S'")
                        If IsDBNull(cntBONPA1) Then cntBONPA1 = 0.0
                        cntBONPA2 = dtInformacion.Compute("SUM(BONPA2)", "tipo_periodo = 'S'")
                        If IsDBNull(cntBONPA2) Then cntBONPA2 = 0.0
                        cntBONPA3 = dtInformacion.Compute("SUM(BONPA3)", "tipo_periodo = 'S'")
                        If IsDBNull(cntBONPA3) Then cntBONPA3 = 0.0
                    Catch ex As Exception
                        Dim exerror = ex.Message
                    End Try
                    'workSheet.Cells(22, 3).Value = despensaSemanal
                    workSheet.Cells(22, 3).Value = cntBONDES + cntBONPA1 + cntBONPA2 + cntBONPA3
                    workSheet.Cells(23, 4).Style.Numberformat.Format = "##,###,##0.00"
                    Try
                        cntBONDES = dtInformacion.Compute("SUM(BONDES)", "tipo_periodo = 'Q'")
                        If IsDBNull(cntBONDES) Then cntBONDES = 0.0
                        cntBONPA1 = dtInformacion.Compute("SUM(BONPA1)", "tipo_periodo = 'Q'")
                        If IsDBNull(cntBONPA1) Then cntBONPA1 = 0.0
                        cntBONPA2 = dtInformacion.Compute("SUM(BONPA2)", "tipo_periodo = 'Q'")
                        If IsDBNull(cntBONPA2) Then cntBONPA2 = 0.0
                        cntBONPA3 = dtInformacion.Compute("SUM(BONPA3)", "tipo_periodo = 'Q'")
                        If IsDBNull(cntBONPA3) Then cntBONPA3 = 0.0
                    Catch ex As Exception
                        Dim exerror = ex.Message
                    End Try
                    workSheet.Cells(23, 4).Value = cntBONDES + cntBONPA1 + cntBONPA2 + cntBONPA3
                    'workSheet.Cells(23, 4).Value = despensaQuincenal


                    package.SaveAs(New System.IO.FileInfo(saveFileDialog2.FileName.ToString()))
                End Using
            End If

        Catch ex As Exception
            MessageBox.Show("Error al crear el reporte Acumulado Mensual " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    'Jose R Hdez 25 Marzo 2020 Reporte ISN
    Public Sub ReporteISN(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim anio = My.Forms.frmReporteadorNomina.lstPeriodos.Items(0).ToString.Split("-")(0)
            Dim periodo = My.Forms.frmReporteadorNomina.lstPeriodos.Items(0).ToString.Split("-")(1)
            Dim mes = ""
            Dim numMes = 0
            Dim dtMes = sqlExecute("select top 1 mes,num_mes from ta.dbo.periodos where ano = '" & anio & "' and periodo = '" & periodo & "'")
            If dtMes.Rows.Count > 0 Then
                mes = dtMes.Rows(0).Item("mes").ToString.Trim
                numMes = dtMes.Rows(0).Item("num_mes").ToString.Trim
            End If
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("alta")
            dtDatos.Columns.Add("antiguedad")

            dtDatos.Columns.Add("PERAGI", Type.GetType("System.Double"))
            dtDatos.Columns.Add("BONDES")
            dtDatos.Columns.Add("totper", Type.GetType("System.Double"))

            dtDatos.Columns.Add("totded")
            dtDatos.Columns.Add("PEREX2", Type.GetType("System.Double"))
            dtDatos.Columns.Add("PEREX3", Type.GetType("System.Double"))
            dtDatos.Columns.Add("PRIVAC", Type.GetType("System.Double"))
            dtDatos.Columns.Add("PERPTU", Type.GetType("System.Double"))
            dtDatos.Columns.Add("PRIDOM", Type.GetType("System.Double"))
            dtDatos.Columns.Add("DEVFAH", Type.GetType("System.Double"))
            dtDatos.Columns.Add("OTPNOG", Type.GetType("System.Double"))

            Dim dtConceptosExentos = sqlExecute("Select concepto FROM Nomina.dbo.conceptos where concepto in (select distinct exento from nomina.dbo.conceptos) and cod_naturaleza = 'P' and activo = 1")
            For Each row As DataRow In dtConceptosExentos.Rows
                dtDatos.Columns.Add(row("concepto"))
            Next
            dtDatos.Columns.Add("percepcion_exenta", Type.GetType("System.Double"))
            Dim horasNormales = 0.0
            Dim horasDobles = 0.0
            Dim horasTriples = 0.0

            Dim promMensualObrerors = 0
            Dim promMensualOficinas = 0
            Dim horasNormalesObreros = 0.0
            Dim horasNormalesOficinas = 0.0
            Dim horasDoblesObreros = 0.0
            Dim horasDoblesOficinas = 0.0
            Dim horasTriplesObreros = 0.0
            Dim horasTriplesOficinas = 0.0
            Dim fondoAhorroObreros = 0.0
            Dim fondoAhorroOficinas = 0.0
            Dim despensaSemanal = 0.0
            Dim despensaQuincenal = 0.0
            Dim salariosPagadosObreros = 0.0
            Dim salariosPagadosOficinas = 0.0
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}
            For Each row_nomina As DataRow In dtInformacion.Rows
                Dim drow As DataRow = dtDatos.Rows.Find({row_nomina("reloj")})
                Dim newRow As Boolean = False
                If IsNothing(drow) Then
                    newRow = True
                End If

                If newRow Then
                    drow = dtDatos.NewRow
                    drow("reloj") = row_nomina("reloj")
                    drow("nombres") = row_nomina("nombres")
                    drow("alta") = FechaSQL(row_nomina("alta"))
                    drow("antiguedad") = row_nomina("ano") - row_nomina("alta").year
                End If

                If IsDBNull(drow("totper")) Then drow("totper") = 0.0
                drow("totper") = drow("totper") + row_nomina("totper")
                If IsDBNull(drow("totded")) Then drow("totded") = 0.0
                drow("totded") = drow("totded") + row_nomina("totded")
                If IsDBNull(drow("PERAGI")) Then drow("PERAGI") = 0.0
                drow("PERAGI") = drow("PERAGI") + IIf(IsDBNull(row_nomina("PERAGI")), 0.0, row_nomina("PERAGI"))
                If IsDBNull(drow("PEREX2")) Then drow("PEREX2") = 0.0
                drow("PEREX2") = drow("PEREX2") + IIf(IsDBNull(row_nomina("PEREX2")), 0.0, row_nomina("PEREX2"))
                If IsDBNull(drow("PEREX3")) Then drow("PEREX3") = 0.0
                drow("PEREX3") = drow("PEREX3") + IIf(IsDBNull(row_nomina("PEREX3")), 0.0, row_nomina("PEREX3"))
                If IsDBNull(drow("PRIVAC")) Then drow("PRIVAC") = 0.0
                drow("PRIVAC") = drow("PRIVAC") + IIf(IsDBNull(row_nomina("PRIVAC")), 0.0, row_nomina("PRIVAC"))
                If IsDBNull(drow("PERPTU")) Then drow("PERPTU") = 0.0
                drow("PERPTU") = drow("PERPTU") + IIf(IsDBNull(row_nomina("PERPTU")), 0.0, row_nomina("PERPTU"))
                If IsDBNull(drow("PRIDOM")) Then drow("PRIDOM") = 0.0
                drow("PRIDOM") = drow("PRIDOM") + IIf(IsDBNull(row_nomina("PRIDOM")), 0.0, row_nomina("PRIDOM"))
                If IsDBNull(drow("DEVFAH")) Then drow("DEVFAH") = 0.0
                drow("DEVFAH") = drow("DEVFAH") + IIf(IsDBNull(row_nomina("DEVFAH")), 0.0, row_nomina("DEVFAH"))
                If IsDBNull(drow("OTPNOG")) Then drow("OTPNOG") = 0.0
                drow("OTPNOG") = drow("OTPNOG") + IIf(IsDBNull(row_nomina("OTPNOG")), 0.0, row_nomina("OTPNOG"))
                If IsDBNull(drow("percepcion_exenta")) Then drow("percepcion_exenta") = 0.0
                For Each row As DataRow In dtConceptosExentos.Rows
                    Try
                        drow(row("concepto")) = IIf(IsDBNull(row_nomina(row("concepto").ToString.TrimEnd)), 0.0, row_nomina(row("concepto").ToString.TrimEnd))
                        drow("percepcion_exenta") = drow("percepcion_exenta") + Convert.ToDouble(drow(row("concepto")))
                    Catch
                    End Try
                Next

                If newRow Then dtDatos.Rows.Add(drow)
            Next
            Dim total_neto As Double = 0
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.FileName = "ReporteISN.xlsx"
            saveFileDialog1.Filter = "Excel File|*.xlsx"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True
            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim File = New FileInfo(DireccionReportes & "PlantillaReporteISN.xlsx")
                Using package As New ExcelPackage(File)
                    package.Load(New FileStream(DireccionReportes & "PlantillaReporteISN.xlsx", FileMode.Open))
                    Dim workSheet As ExcelWorksheet = package.Workbook.Worksheets("BRP_ISN")
                    workSheet.Cells("B2").Value = "Acumulado ISN " & mes & "/" & anio
                    Dim x As Integer = 0
                    Dim y As Integer = 0
                    x = 3
                    For Each dr As DataRow In dtDatos.Rows
                        y = 1
                        workSheet.Cells(x, y).Value = dr("reloj").ToString
                        y = y + 1
                        workSheet.Cells(x, y).Value = dr("nombres").ToString
                        y = y + 1
                        workSheet.Cells(x, y).Value = dr("alta").ToString
                        y = y + 1
                        workSheet.Cells(x, y).Value = dr("antiguedad").ToString
                        y = y + 1
                        workSheet.Cells(x, y).Value = CDbl(dr("totper").ToString)
                        y = y + 1
                        workSheet.Cells(x, y).Value = CDbl(dr("totded").ToString)
                        y = y + 1
                        workSheet.Cells(x, y).Value = CDbl(dr("percepcion_exenta").ToString)
                        x = x + 1
                    Next
                    y = 2
                    workSheet.Cells(x, y).Value = "PERIODO DE PAGO:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    Dim MyDate As Date = Now
                    Dim DaysInMonth As Integer = Date.DaysInMonth(CInt(anio), numMes)
                    Dim LastDayInMonthDate As Date = New Date(CInt(anio), numMes, DaysInMonth)
                    y = 3
                    workSheet.Cells(x, y).Value = FechaSQL(LastDayInMonthDate)
                    y = 2
                    x = x + 1
                    workSheet.Cells(x, y).Value = "REMUNERACIONES:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    y = 3
                    workSheet.Cells(x, y).Formula = "=SUM(" & workSheet.Cells(3, 5).Address.ToString & ":" & workSheet.Cells(x - 2, 5).Address.ToString & ")"
                    y = 2
                    x = x + 1
                    workSheet.Cells(x, y).Value = "REMUNERACIONES EXENTAS:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    y = 3
                    workSheet.Cells(x, y).Formula = "=SUM(" & workSheet.Cells(3, 7).Address.ToString & ":" & workSheet.Cells(x - 2, 7).Address.ToString & ")"
                    y = 2
                    x = x + 1
                    workSheet.Cells(x, y).Value = "BASE DEL IMPUESTO:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    y = 3
                    workSheet.Cells(x, y).Formula = "= " & workSheet.Cells(x - 2, y).Address.ToString & " - " & workSheet.Cells(x - 1, y).Address.ToString
                    y = 2
                    x = x + 1
                    workSheet.Cells(x, y).Value = "TASA:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    y = 3
                    workSheet.Cells(x, y).Value = 3
                    y = 2
                    x = x + 1
                    workSheet.Cells(x, y).Value = "IMPUESTO CAUSADO:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    y = 3
                    workSheet.Cells(x, y).Formula = "= " & workSheet.Cells(x - 2, y).Address.ToString & " * " & workSheet.Cells(x - 1, y).Address.ToString & "  / 100"
                    workSheet.Cells(x, y).Style.Numberformat.Format = "###.00"
                    y = 2
                    x = x + 1
                    workSheet.Cells(x, y).Value = "IMPUESTO UNIVERSITARIO:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    y = 3
                    workSheet.Cells(x, y).Formula = "= " & workSheet.Cells(x - 3, y).Address.ToString & " * 0.04"
                    workSheet.Cells(x, y).Style.Numberformat.Format = "###.00"
                    y = 2
                    x = x + 1
                    workSheet.Cells(x, y).Value = "CONTRIB.EXTRAORDAR 10%:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    y = 3
                    workSheet.Cells(x, y).Formula = "= " & workSheet.Cells(x - 4, y).Address.ToString & " * 0.1"
                    workSheet.Cells(x, y).Style.Numberformat.Format = "###.00"
                    y = 2
                    x = x + 1
                    workSheet.Cells(x, y).Value = "CONTRIB.EXTRAORDAR 05%:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    y = 3
                    workSheet.Cells(x, y).Formula = "= " & workSheet.Cells(x - 5, y).Address.ToString & " * 0.05"
                    workSheet.Cells(x, y).Style.Numberformat.Format = "###.00"
                    y = 2
                    x = x + 1
                    workSheet.Cells(x, y).Value = "SUBTOTAL:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    y = 3
                    workSheet.Cells(x, y).Formula = "=SUM(" & workSheet.Cells(x - 4, 3).Address.ToString & ":" & workSheet.Cells(x - 1, 3).Address.ToString & ")"
                    workSheet.Cells(x, y).Style.Numberformat.Format = "###.00"
                    y = 2
                    x = x + 1
                    workSheet.Cells(x, y).Value = "ESTIMULOS FISCALES:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    y = 3
                    workSheet.Cells(x, y).Value = 0
                    y = 2
                    x = x + 1
                    workSheet.Cells(x, y).Value = "TOTAL CONTRIBUCIONES:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    y = 3
                    workSheet.Cells(x, y).Formula = "= " & workSheet.Cells(x - 2, 3).Address.ToString & " + " & workSheet.Cells(x - 1, 3).Address.ToString
                    workSheet.Cells(x, y).Style.Numberformat.Format = "###.00"
                    y = 2
                    x = x + 1
                    workSheet.Cells(x, y).Value = "NUMERO DE EMPLEADOS:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    y = 3
                    workSheet.Cells(x, y).Value = dtDatos.Rows.Count
                    y = 2
                    x = x + 3
                    workSheet.Cells(x, y).Value = "Semanas Incluidas:"
                    workSheet.Cells(x, y).Style.Font.Bold = True
                    workSheet.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                    y = 3
                    Dim strSemanas = ""
                    For Each strPeriodo In My.Forms.frmReporteadorNomina.lstPeriodos.Items
                        workSheet.Cells(x, y).Value = strPeriodo.Split("-")(1)
                        strSemanas = strSemanas & strPeriodo.Split("-")(1) & ", "
                        x = x + 1
                    Next
                    strSemanas = strSemanas.Substring(0, strSemanas.Length - 2)

                    workSheet = package.Workbook.Worksheets("BRP_ISN_PROVISION")
                    workSheet.Cells("B1").Value = "SEM " & strSemanas
                    x = 4
                    y = 4
                    Dim sumTotPer As Object
                    sumTotPer = dtDatos.Compute("sum(totper)", "")
                    Dim sumPercepcionExenta As Object
                    sumPercepcionExenta = dtDatos.Compute("sum(percepcion_exenta)", "")
                    workSheet.Cells("B2").Value = sumTotPer - sumPercepcionExenta
                    workSheet.Cells("B2").Style.Numberformat.Format = "###.00"
                    'workSheet.Cells("B3").Value = sumPercepcionExenta
                    workSheet.Cells("B3").Formula = "=SUM(C4:C10)"
                    workSheet.Cells("B3").Style.Numberformat.Format = "###.00"
                    Dim sumHorasDobles As Object
                    sumHorasDobles = dtDatos.Compute("sum(PEREX2)", "")
                    Dim sumHorasTriples As Object
                    sumHorasTriples = dtDatos.Compute("sum(PEREX3)", "")
                    workSheet.Cells("C4").Value = sumHorasDobles + sumHorasTriples
                    workSheet.Cells("C4").Style.Numberformat.Format = "##0.00"
                    Dim sumPrimaVacacional As Object
                    sumPrimaVacacional = dtDatos.Compute("sum(PRIVAC)", "")
                    workSheet.Cells("C5").Value = sumPrimaVacacional
                    workSheet.Cells("C5").Style.Numberformat.Format = "##0.00"
                    Dim sumAguinaldo As Object
                    sumAguinaldo = dtDatos.Compute("sum(PERAGI)", "")
                    workSheet.Cells("C6").Value = sumAguinaldo
                    workSheet.Cells("C6").Style.Numberformat.Format = "##0.00"
                    Dim sumUtilidades As Object
                    sumUtilidades = dtDatos.Compute("sum(PERPTU)", "")
                    workSheet.Cells("C7").Value = sumUtilidades
                    workSheet.Cells("C7").Style.Numberformat.Format = "##0.00"
                    Dim sumPrimaDom As Object
                    sumPrimaDom = dtDatos.Compute("sum(PRIDOM)", "")
                    workSheet.Cells("C8").Value = sumPrimaDom
                    workSheet.Cells("C8").Style.Numberformat.Format = "##0.00"
                    Dim sumDevFondoAhorro As Object
                    sumDevFondoAhorro = dtDatos.Compute("sum(DEVFAH)", "")
                    workSheet.Cells("C9").Value = sumDevFondoAhorro
                    workSheet.Cells("C9").Style.Numberformat.Format = "##0.00"
                    Dim sumOtrasPerNoGrab As Object
                    sumOtrasPerNoGrab = dtDatos.Compute("sum(OTPNOG)", "")
                    workSheet.Cells("C10").Value = sumOtrasPerNoGrab
                    workSheet.Cells("C10").Style.Numberformat.Format = "##0.00"
                    workSheet.Cells("B20").Value = dtDatos.Rows.Count
                    
                    package.SaveAs(New System.IO.FileInfo(saveFileDialog1.FileName.ToString()))
                End Using
            End If

        Catch ex As Exception
            MessageBox.Show("Error al crear el Reporte ISN " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub HorasCCTA(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim encabezado As String = ""
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

            encabezado = "Horas por centro de costos del " & FechaSQL(_fini) & " al " & FechaSQL(_ffin)

            Dim dtTavw As DataTable = sqlExecute("SELECT COD_COMP,COMPANIA,COD_TIPO,COD_CLASE,CENTRO_COSTOS,NOMBRE_CC,COD_DEPTO,NOMBRE_DEPTO,COD_SUPER,NOMBRE_SUPER,COD_TURNO,RELOJ,AUSENTISMO,HORAS_NORMALES,nombres,ALTA,BAJA," & _
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


            'Dim tipo_periodo As String = "S"
            'Dim ano As String = RTrim(dtInformacion.Rows(0)("ano"))
            'Dim periodo As String = RTrim(dtInformacion.Rows(0)("periodo"))

            'Dim tabla_periodos As String = "periodos"
            'If tipo_periodo.ToUpper.Trim = "S" Then
            '    tabla_periodos = "periodos"
            'ElseIf tipo_periodo.ToUpper.Trim = "Q" Then
            '    tabla_periodos = "periodos_quincenal"
            'End If
            'Dim dtInfoPeriodos As DataTable = sqlExecute("select * from " & tabla_periodos & " where ano = '" & ano & "' and periodo = '" & periodo & "'", "TA")

            'If dtInfoPeriodos.Rows.Count > 0 Then
            '    Dim fecha_ini As String = FechaMediaLetra(dtInfoPeriodos.Rows(0)("fecha_ini"))
            '    Dim fecha_fin As String = FechaMediaLetra(dtInfoPeriodos.Rows(0)("fecha_fin"))

            '  encabezado = "Periodo " & IIf(tipo_periodo.ToUpper.Trim = "S", "Semanal ", "Quincenal ") & Ano & "-" & Periodo & " del " & fecha_ini & " al " & fecha_fin

            ' End If



            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("CENTRO_COSTOS")
            dtDatos.Columns.Add("NOMBRE_CC")
            dtDatos.Columns.Add("ANO")
            dtDatos.Columns.Add("PERIODO")
            dtDatos.Columns.Add("COD_CLASE")
            dtDatos.Columns.Add("NOMBRE_CLASE")
            dtDatos.Columns.Add("SUPERVISOR")

            dtDatos.Columns.Add("ENCABEZADO")

            dtDatos.Columns.Add("HORAS_NORMALES_CC", GetType(System.Double))
            dtDatos.Columns.Add("HORAS_EXTRA_CC", GetType(System.Double))

            dtDatos.Columns.Add("FACTOR", GetType(System.Double))

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("RELOJ")}

            Dim conceptos_normales As String = ""
            Dim detalle_normales As String = ""
            Dim conceptos_extras As String = ""
            Dim detalle_extras As String = ""

            Dim reloj_anterior As String = ""

            'For Each row As DataRow In dtInformacion.Select("cod_comp = '002'")
            For Each row As DataRow In dtFiltroFinal.Select("cod_comp = '002'")

                Dim drow As DataRow = dtDatos.Rows.Find({row("reloj")})

                If IsNothing(drow) Then
                    drow = dtDatos.NewRow

                    drow("RELOJ") = row("RELOJ")
                    drow("NOMBRES") = row("NOMBRES")
                    drow("CENTRO_COSTOS") = row("CENTRO_COSTOS")
                    drow("NOMBRE_CC") = row("NOMBRE_CC")
                    drow("ENCABEZADO") = encabezado

                    Dim supervisor As String = ""
                    Try
                        Dim dtSuper As DataTable = sqlExecute("select * from super where cod_super = '" & row("COD_SUPER") & "'")
                        If dtSuper.Rows.Count > 0 Then
                            supervisor = dtSuper.Rows(0)("nombre")
                        End If
                    Catch ex As Exception

                    End Try
                    drow("SUPERVISOR") = supervisor

                    Dim cod_clase As String = RTrim(row("COD_CLASE"))
                    If cod_clase = "D" Then
                        drow("COD_CLASE") = "DL"
                        drow("NOMBRE_CLASE") = "HOURLY DIRECT LABOR"
                    ElseIf cod_clase = "I" Then
                        drow("COD_CLASE") = "TM1"
                        drow("NOMBRE_CLASE") = "HOURLY INDIRECT"
                    ElseIf cod_clase = "A" Then
                        drow("COD_CLASE") = "-"
                        drow("NOMBRE_CLASE") = "SALARY"
                    End If

                    drow("ANO") = row("ANO")
                    drow("PERIODO") = row("PERIODO")

                    If cod_clase = "D" Then
                        Dim listadoCFC As String = "22539,22541,22552,22554,22555,22576,22577"
                        If listadoCFC.Contains(RTrim(drow("CENTRO_COSTOS"))) Then
                            drow("FACTOR") = 40
                        Else
                            drow("FACTOR") = 45
                        End If
                    Else
                        drow("FACTOR") = 45
                    End If

                    drow("HORAS_NORMALES_CC") = 0
                    drow("HORAS_EXTRA_CC") = 0


                    dtDatos.Rows.Add(drow)

                End If


                Try
                    Dim normales_ As Double = Double.Parse(drow("HORAS_NORMALES_CC"))

                    normales_ += HtoD(row("horas_normales"))

                    drow("HORAS_NORMALES_CC") = normales_
                Catch ex As Exception

                End Try

                Try
                    Dim extras_ As Double = Double.Parse(drow("HORAS_EXTRA_CC"))

                    extras_ += HtoD(row("extras_autorizadas"))

                    drow("HORAS_EXTRA_CC") = extras_
                Catch ex As Exception

                End Try

            Next

            Dim pausa As Integer = 0

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub HorasCC_Poliza(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            Dim encabezado As String = ""
            Dim tipo_periodo As String = ""
            Try
                tipo_periodo = RTrim(dtInformacion.Rows(0)("tipo_periodo"))
                Dim ano As String = RTrim(dtInformacion.Rows(0)("ano"))
                Dim periodo As String = RTrim(dtInformacion.Rows(0)("periodo"))

                Dim tabla_periodos As String = "periodos"
                If tipo_periodo.ToUpper.Trim = "S" Then
                    tabla_periodos = "periodos"
                ElseIf tipo_periodo.ToUpper.Trim = "Q" Then
                    tabla_periodos = "periodos_quincenal"
                End If
                Dim dtInfoPeriodos As DataTable = sqlExecute("select * from " & tabla_periodos & " where ano = '" & ano & "' and periodo = '" & periodo & "'", "TA")

                If dtInfoPeriodos.Rows.Count > 0 Then
                    Dim fecha_ini As String = FechaMediaLetra(dtInfoPeriodos.Rows(0)("fecha_ini"))
                    Dim fecha_fin As String = FechaMediaLetra(dtInfoPeriodos.Rows(0)("fecha_fin"))

                    encabezado = "Periodo " & IIf(tipo_periodo.ToUpper.Trim = "S", "Semanal ", "Quincenal ") & ano & "-" & periodo & " del " & fecha_ini & " al " & fecha_fin

                End If

            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("COD_HORA")
            dtDatos.Columns.Add("SINDICALIZADO")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("CENTRO_COSTOS")
            dtDatos.Columns.Add("NOMBRE_CC")
            dtDatos.Columns.Add("ANO")
            dtDatos.Columns.Add("PERIODO")
            dtDatos.Columns.Add("COD_CLASE")
            dtDatos.Columns.Add("NOMBRE_CLASE")
            dtDatos.Columns.Add("SUPERVISOR")

            dtDatos.Columns.Add("ENCABEZADO")

            dtDatos.Columns.Add("HORAS_NORMALES_CC", GetType(System.Double))
            dtDatos.Columns.Add("PERCEPCION_BASE_CC", GetType(System.Double))

            dtDatos.Columns.Add("HORAS_EXTRA_CC", GetType(System.Double))
            dtDatos.Columns.Add("PERCEPCION_EXTRA_CC", GetType(System.Double))

            dtDatos.Columns.Add("HRSEX2", GetType(System.Double))
            dtDatos.Columns.Add("HRSEX3", GetType(System.Double))
            dtDatos.Columns.Add("HRSFEL", GetType(System.Double))

            dtDatos.Columns.Add("CTEMPO", GetType(System.Double))
            dtDatos.Columns.Add("CTUNEL", GetType(System.Double))
            dtDatos.Columns.Add("CTUNE2", GetType(System.Double))
            dtDatos.Columns.Add("PRISAB", GetType(System.Double))
            dtDatos.Columns.Add("PRIDOM", GetType(System.Double))

            dtDatos.Columns.Add("FACTOR", GetType(System.Double))



            '---De aqui es donde toma los conceptos para las percep (SALARIO (Worked base Salary))
            '-------Salary  (Quincenal)
            ' Percepcion salario
            Dim QPerNorSalary As String = ""
            Dim dtPerNorSalary As DataTable
            Dim CtasPerSal As String = "'52400'" ' Cuentas que aplica para el salario pagado trabajado para los Salary
            ' OverTime Salary
            Dim QPerExtSal As String = ""
            Dim dtPerExtSal As DataTable
            Dim CtasExtSal As String = "'52425','52426','54540'" ' Cuentas que aplica para el pago de tiempo extra para los Salary


            '-------Hourly Directos
            Dim QPerHDir As String = ""
            Dim dtPerHDir As DataTable
            Dim CtasHDir As String = "'51000'" ' Cuentas que aplica para el salario pagado para los Hourly Directos

            '-------Hourly Indirectos
            Dim QPerHInd As String = ""
            Dim dtPerHInd As DataTable
            Dim CtasHInd As String = "'52000'" ' Cuentas que aplica para el salario pagado para los Hourly Indirectos

            '---OverTime Hourly
            Dim QPerExt As String = ""
            Dim dtPerExt As DataTable



            If (tipo_periodo.ToUpper.Trim = "Q") Then ' Salarys (Quincenal)
                QPerNorSalary = "select rtrim(cp.concepto) as concepto, case when cp.cod_naturaleza = 'P' then 1 else -1 end as porcentaje, rtrim(cp.detalle) as detalle,cp.factor_detalle " & _
            "FROM conceptos cp left outer join cuentas ct on cp.concepto=ct.CONCEPTO where ct.CUENTA=" & CtasPerSal & " and ct.DEBE_HABER='D'"
                dtPerNorSalary = sqlExecute(QPerNorSalary, "NOMINA")

                QPerExtSal = "select rtrim(cp.concepto) as concepto, case when cp.cod_naturaleza = 'P' then 1 else -1 end as porcentaje, rtrim(cp.detalle) as detalle,cp.factor_detalle " & _
                    "FROM conceptos cp left outer join cuentas ct on cp.concepto=ct.CONCEPTO where ct.CUENTA in(" & CtasExtSal & ") and ct.DEBE_HABER='D' and isnull(detalle,'')<>''"
                dtPerExtSal = sqlExecute(QPerExtSal, "NOMINA")
            End If

            If (tipo_periodo.ToUpper.Trim = "S") Then ' Hourly Directos E Indirectos
                QPerHDir = "select rtrim(cp.concepto) as concepto, case when cp.cod_naturaleza = 'P' then 1 else -1 end as porcentaje, rtrim(cp.detalle) as detalle,cp.factor_detalle " & _
                    "FROM conceptos cp left outer join cuentas ct on cp.concepto=ct.CONCEPTO where ct.CUENTA='" & CtasHDir & "' and ct.COD_CLASE='D' and ct.DEBE_HABER='D'"

                dtPerHDir = sqlExecute(QPerHDir, "NOMINA")

                QPerHInd = "select rtrim(cp.concepto) as concepto, case when cp.cod_naturaleza = 'P' then 1 else -1 end as porcentaje, rtrim(cp.detalle) as detalle,cp.factor_detalle " & _
                    "FROM conceptos cp left outer join cuentas ct on cp.concepto=ct.CONCEPTO where ct.CUENTA='" & CtasHInd & "' and ct.COD_CLASE='I' and ct.DEBE_HABER='D'"

                dtPerHInd = sqlExecute(QPerHInd, "NOMINA")

                QPerExt = "select rtrim(concepto) as concepto, case when cod_naturaleza = 'P' then 1 else -1 end as porcentaje, rtrim(detalle) as detalle, factor_detalle from conceptos where reporte_finanzas = '02'"
                dtPerExt = sqlExecute(QPerExt, "nomina")
            End If




            Dim conceptos_normales As String = ""
            Dim detalle_normales As String = ""
            Dim conceptos_extras As String = ""
            Dim detalle_extras As String = ""


            For Each row As DataRow In dtInformacion.Rows
                'For Each row As DataRow In dtInformacion.Select("cod_depto='43447'") ' Para revisar x cierto CCosto, pero se busca por el cod_depto su relacion con el ccosto está en la tabla de DEPTOS
                Dim drow As DataRow = dtDatos.NewRow

                Dim RJ As String = IIf(IsDBNull(row("RELOJ")), "", row("RELOJ"))
                drow("RELOJ") = row("RELOJ")
                drow("SINDICALIZADO") = IIf(Not IsDBNull(row("SINDICALIZADO")), row("SINDICALIZADO"), 0)
                drow("COD_HORA") = IIf(Not IsDBNull(row("COD_HORA")), row("COD_HORA"), "")
                drow("NOMBRES") = row("NOMBRES")
                drow("CENTRO_COSTOS") = row("CENTRO_COSTOS")
                drow("NOMBRE_CC") = row("NOMBRE_CC")
                drow("ENCABEZADO") = encabezado

                Dim supervisor As String = ""
                Try
                    Dim dtSuper As DataTable = sqlExecute("select * from super where cod_super = '" & row("COD_SUPER") & "'")
                    If dtSuper.Rows.Count > 0 Then
                        supervisor = dtSuper.Rows(0)("nombre")
                    End If
                Catch ex As Exception

                End Try
                drow("SUPERVISOR") = supervisor

                Dim cod_clase As String = RTrim(row("COD_CLASE"))

                If (tipo_periodo.ToUpper.Trim = "Q") Then
                    drow("COD_CLASE") = "-"
                    drow("NOMBRE_CLASE") = "SALARY"
                End If

                If (tipo_periodo.ToUpper.Trim = "S") Then
                    If cod_clase = "D" Then
                        drow("COD_CLASE") = "DL"
                        drow("NOMBRE_CLASE") = "HOURLY DIRECT LABOR"
                    ElseIf cod_clase = "I" Then
                        drow("COD_CLASE") = "TM1"
                        drow("NOMBRE_CLASE") = "HOURLY INDIRECT"
                    End If
                End If


                drow("ANO") = row("ANO")
                drow("PERIODO") = row("PERIODO")

                drow("HRSEX2") = IIf(Not IsDBNull(row("HRSEX2")), row("HRSEX2"), 0)
                drow("HRSEX3") = IIf(Not IsDBNull(row("HRSEX3")), row("HRSEX3"), 0)
                drow("HRSFEL") = IIf(Not IsDBNull(row("HRSFEL")), row("HRSFEL"), 0)




                Dim PerNor As Double = 0

                '--Va sumando la percep de cada concepto o restando en caso de ser deduc de acuerdo al tipo de clasif que tenga
                If (tipo_periodo.ToUpper.Trim = "Q") Then

                    For Each RowSal In dtPerNorSalary.Rows
                        Dim concepto As String = RTrim(RowSal("concepto"))

                        If Not ("******").Contains(concepto.ToUpper) Then
                            Dim m As Double = IIf(IsDBNull(row(concepto)), 0, row(concepto))
                            Dim f As Double = IIf(IsDBNull(RowSal("porcentaje")), 1, RowSal("porcentaje"))
                            PerNor += m * f
                        End If
                    Next
                Else
                    If cod_clase = "D" Then
                        For Each rowHD In dtPerHDir.Rows
                            Dim concepto As String = RTrim(rowHD("concepto"))

                            If Not ("******").Contains(concepto.ToUpper) Then
                                Dim m As Double = IIf(IsDBNull(row(concepto)), 0, row(concepto))
                                Dim f As Double = IIf(IsDBNull(rowHD("porcentaje")), 1, rowHD("porcentaje"))
                                PerNor += m * f
                            End If
                        Next
                    ElseIf cod_clase = "I" Then
                        For Each rowHI In dtPerHInd.Rows
                            Dim concepto As String = RTrim(rowHI("concepto"))

                            If Not ("******").Contains(concepto.ToUpper) Then
                                Dim m As Double = IIf(IsDBNull(row(concepto)), 0, row(concepto))
                                Dim f As Double = IIf(IsDBNull(rowHI("porcentaje")), 1, rowHI("porcentaje"))
                                PerNor += m * f
                            End If
                        Next
                    End If
                End If

                '----Obtener Suma de horas normales (Worked Base Hours)
                'HERE
                Dim HorasNorm As Double = 0
                HorasNorm = IIf(IsDBNull(row("HRSNOR")), 0, row("HRSNOR"))



                '---Obtener el total de horas
                Dim PerExt As Double = 0
                Dim HrsExt As Double = 0

                If (tipo_periodo.ToUpper.Trim = "Q") Then

                    For Each row_ As DataRow In dtPerExtSal.Rows
                        Dim concepto As String = RTrim(row_("concepto"))

                        If Not ("******").Contains(concepto.ToUpper) Then
                            Dim m As Double = IIf(IsDBNull(row(concepto)), 0, row(concepto))
                            Dim f As Double = IIf(IsDBNull(row_("porcentaje")), 1, row_("porcentaje"))
                            PerExt += m * f
                        End If
                    Next

                Else
                    '--Para los Hourly que son Semanalaes
                    For Each row_ As DataRow In dtPerExt.Rows
                        Dim concepto As String = RTrim(row_("concepto"))

                        If Not ("******").Contains(concepto.ToUpper) Then
                            Dim m As Double = IIf(IsDBNull(row(concepto)), 0, row(concepto))
                            Dim f As Double = IIf(IsDBNull(row_("porcentaje")), 1, row_("porcentaje"))
                            PerExt += m * f
                        End If
                    Next
                End If



                '----------Ingresamos ya los totales las respectivos campos
                '--Total de empleados x Ccosto (PEND)
                drow("PERCEPCION_BASE_CC") = PerNor ' Worked Based Salary : LISTO
                drow("HORAS_NORMALES_CC") = HorasNorm ' Worked base hours
                drow("PERCEPCION_EXTRA_CC") = PerExt ' OverTime
                drow("HORAS_EXTRA_CC") = drow("HRSEX2") + drow("HRSEX3") + drow("HRSFEL") ' Total Hours (OverTime)

                If cod_clase = "D" Then
                    Dim listadoCFC As String = "22539,22541,22552,22554,22555,22576,22577"
                    If listadoCFC.Contains(RTrim(drow("CENTRO_COSTOS"))) Then
                        drow("FACTOR") = 40
                    Else
                        drow("FACTOR") = 45
                    End If
                Else
                    drow("FACTOR") = 45
                End If

                If (PerNor + HorasNorm) > 0 Then ' Agregar solo si tiene percepcion u horas normales salario > 0
                    dtDatos.Rows.Add(drow)
                End If
            Next

            Dim pausa As Integer = 0

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub HorasCC(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            Dim encabezado As String = ""
            Try
                Dim tipo_periodo As String = RTrim(dtInformacion.Rows(0)("tipo_periodo"))
                Dim ano As String = RTrim(dtInformacion.Rows(0)("ano"))
                Dim periodo As String = RTrim(dtInformacion.Rows(0)("periodo"))

                Dim tabla_periodos As String = "periodos"
                If tipo_periodo.ToUpper.Trim = "S" Then
                    tabla_periodos = "periodos"
                ElseIf tipo_periodo.ToUpper.Trim = "Q" Then
                    tabla_periodos = "periodos_quincenal"
                End If
                Dim dtInfoPeriodos As DataTable = sqlExecute("select * from " & tabla_periodos & " where ano = '" & ano & "' and periodo = '" & periodo & "'", "TA")

                If dtInfoPeriodos.Rows.Count > 0 Then
                    Dim fecha_ini As String = FechaMediaLetra(dtInfoPeriodos.Rows(0)("fecha_ini"))
                    Dim fecha_fin As String = FechaMediaLetra(dtInfoPeriodos.Rows(0)("fecha_fin"))

                    encabezado = "Periodo " & IIf(tipo_periodo.ToUpper.Trim = "S", "Semanal ", "Quincenal ") & ano & "-" & periodo & " del " & fecha_ini & " al " & fecha_fin

                End If

            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("COD_HORA")
            dtDatos.Columns.Add("SINDICALIZADO")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("CENTRO_COSTOS")
            dtDatos.Columns.Add("NOMBRE_CC")
            dtDatos.Columns.Add("ANO")
            dtDatos.Columns.Add("PERIODO")
            dtDatos.Columns.Add("COD_CLASE")
            dtDatos.Columns.Add("NOMBRE_CLASE")
            dtDatos.Columns.Add("SUPERVISOR")

            dtDatos.Columns.Add("ENCABEZADO")

            dtDatos.Columns.Add("HORAS_NORMALES_CC", GetType(System.Double))
            dtDatos.Columns.Add("PERCEPCION_BASE_CC", GetType(System.Double))

            dtDatos.Columns.Add("HORAS_EXTRA_CC", GetType(System.Double))
            dtDatos.Columns.Add("PERCEPCION_EXTRA_CC", GetType(System.Double))

            dtDatos.Columns.Add("HRSEX2", GetType(System.Double))
            dtDatos.Columns.Add("HRSEX3", GetType(System.Double))
            dtDatos.Columns.Add("HRSFEL", GetType(System.Double))

            dtDatos.Columns.Add("CTEMPO", GetType(System.Double))
            dtDatos.Columns.Add("CTUNEL", GetType(System.Double))
            dtDatos.Columns.Add("CTUNE2", GetType(System.Double))
            dtDatos.Columns.Add("PRISAB", GetType(System.Double))
            dtDatos.Columns.Add("PRIDOM", GetType(System.Double))

            dtDatos.Columns.Add("FACTOR", GetType(System.Double))

            'Dim dtPerNor As DataTable = sqlExecute("select distinct cuentas.concepto, cuentas.porcentaje, conceptos.detalle, conceptos.factor_Detalle from cuentas left join conceptos on conceptos.concepto = cuentas.concepto where cuentas.cuenta in ('51000', '52000', '52400') and cuentas.concepto not in ('PRISAB', 'PRIDOM') order by detalle", "nomina")
            'Dim dtPerExt As DataTable = sqlExecute("select distinct cuentas.concepto, cuentas.porcentaje, conceptos.detalle, conceptos.factor_Detalle from cuentas left join conceptos on conceptos.concepto = cuentas.concepto where cuentas.cuenta in ('51020', '52020', '52425') and cuentas.concepto not in ('PRISAB', 'PRIDOM') order by detalle", "nomina")

            Dim dtPerNor As DataTable = sqlExecute("select rtrim(concepto) as concepto, case when cod_naturaleza = 'P' then 1 else -1 end as porcentaje, rtrim(detalle) as detalle, factor_detalle from conceptos where reporte_finanzas = '01'", "nomina")
            Dim dtPerExt As DataTable = sqlExecute("select rtrim(concepto) as concepto, case when cod_naturaleza = 'P' then 1 else -1 end as porcentaje, rtrim(detalle) as detalle, factor_detalle from conceptos where reporte_finanzas = '02'", "nomina")

            Dim conceptos_normales As String = ""
            Dim detalle_normales As String = ""
            Dim conceptos_extras As String = ""
            Dim detalle_extras As String = ""

            For Each row As DataRow In dtInformacion.Rows
                Dim drow As DataRow = dtDatos.NewRow

                drow("RELOJ") = row("RELOJ")
                drow("SINDICALIZADO") = IIf(Not IsDBNull(row("SINDICALIZADO")), row("SINDICALIZADO"), 0)
                drow("COD_HORA") = IIf(Not IsDBNull(row("COD_HORA")), row("COD_HORA"), "")
                drow("NOMBRES") = row("NOMBRES")
                drow("CENTRO_COSTOS") = row("CENTRO_COSTOS")
                drow("NOMBRE_CC") = row("NOMBRE_CC")
                drow("ENCABEZADO") = encabezado

                Dim supervisor As String = ""
                Try
                    Dim dtSuper As DataTable = sqlExecute("select * from super where cod_super = '" & row("COD_SUPER") & "'")
                    If dtSuper.Rows.Count > 0 Then
                        supervisor = dtSuper.Rows(0)("nombre")
                    End If
                Catch ex As Exception

                End Try
                drow("SUPERVISOR") = supervisor

                Dim cod_clase As String = RTrim(row("COD_CLASE"))
                If cod_clase = "D" Then
                    drow("COD_CLASE") = "DL"
                    drow("NOMBRE_CLASE") = "HOURLY DIRECT LABOR"
                ElseIf cod_clase = "I" Then
                    drow("COD_CLASE") = "TM1"
                    drow("NOMBRE_CLASE") = "HOURLY INDIRECT"
                ElseIf cod_clase = "A" Then
                    drow("COD_CLASE") = "-"
                    drow("NOMBRE_CLASE") = "SALARY"
                End If

                drow("ANO") = row("ANO")
                drow("PERIODO") = row("PERIODO")

                drow("HRSEX2") = IIf(Not IsDBNull(row("HRSEX2")), row("HRSEX2"), 0)
                drow("HRSEX3") = IIf(Not IsDBNull(row("HRSEX3")), row("HRSEX3"), 0)
                drow("HRSFEL") = IIf(Not IsDBNull(row("HRSFEL")), row("HRSFEL"), 0)

                drow("HORAS_NORMALES_CC") = IIf(Not IsDBNull(row("HRSNOR")), row("HRSNOR"), 0)
                drow("HORAS_EXTRA_CC") = drow("HRSEX2") + drow("HRSEX3") + drow("HRSFEL")

                Dim PerNor As Double = 0

                For Each row_ As DataRow In dtPerNor.Rows
                    Dim concepto As String = RTrim(row_("concepto"))

                    If Not ("******").Contains(concepto.ToUpper) Then
                        Dim m As Double = IIf(IsDBNull(row(concepto)), 0, row(concepto))
                        Dim f As Double = IIf(IsDBNull(row_("porcentaje")), 1, row_("porcentaje"))
                        PerNor += m * f
                    End If
                Next


                Dim PerExt As Double = 0
                Dim HrsExt As Double = 0
                For Each row_ As DataRow In dtPerExt.Rows
                    Dim concepto As String = RTrim(row_("concepto"))

                    If Not ("******").Contains(concepto.ToUpper) Then
                        Dim m As Double = IIf(IsDBNull(row(concepto)), 0, row(concepto))
                        Dim f As Double = IIf(IsDBNull(row_("porcentaje")), 1, row_("porcentaje"))
                        PerExt += m * f

                    End If

                Next

                drow("PERCEPCION_BASE_CC") = PerNor
                drow("PERCEPCION_EXTRA_CC") = PerExt

                If cod_clase = "D" Then
                    Dim listadoCFC As String = "22539,22541,22552,22554,22555,22576,22577"
                    If listadoCFC.Contains(RTrim(drow("CENTRO_COSTOS"))) Then
                        drow("FACTOR") = 40
                    Else
                        drow("FACTOR") = 45
                    End If
                Else
                    drow("FACTOR") = 45
                End If


                dtDatos.Rows.Add(drow)
            Next

            Dim pausa As Integer = 0

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub HorasCC_Detalle_Incidencias(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim encabezado As String = ""
            Dim anoPeriodo As String = ""
            Dim tipo_periodo As String = ""
            Dim Fini As String = ""
            Dim FFin As String = ""
            Try
                tipo_periodo = RTrim(dtInformacion.Rows(0)("tipo_periodo"))
                Dim ano As String = RTrim(dtInformacion.Rows(0)("ano"))
                Dim periodo As String = RTrim(dtInformacion.Rows(0)("periodo"))
                anoPeriodo = ano.Trim & periodo.Trim

                Dim tabla_periodos As String = "periodos"
                If tipo_periodo.ToUpper.Trim = "S" Then
                    tabla_periodos = "periodos"
                ElseIf tipo_periodo.ToUpper.Trim = "Q" Then
                    tabla_periodos = "periodos_quincenal"
                End If
                Dim dtInfoPeriodos As DataTable = sqlExecute("select * from " & tabla_periodos & " where ano = '" & ano & "' and periodo = '" & periodo & "'", "TA")

                If dtInfoPeriodos.Rows.Count > 0 Then
                    Dim fecha_ini As String = FechaMediaLetra(dtInfoPeriodos.Rows(0)("fecha_ini"))
                    Dim fecha_fin As String = FechaMediaLetra(dtInfoPeriodos.Rows(0)("fecha_fin"))

                    Try : Fini = FechaSQL(dtInfoPeriodos.Rows(0)("fecha_ini")) : Catch ex As Exception : Fini = "" : End Try
                    Try : FFin = FechaSQL(dtInfoPeriodos.Rows(0)("fecha_fin")) : Catch ex As Exception : FFin = "" : End Try

                    encabezado = "Periodo " & IIf(tipo_periodo.ToUpper.Trim = "S", "Semanal ", "Quincenal ") & ano & "-" & periodo & " del " & fecha_ini & " al " & fecha_fin

                End If

            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("COD_HORA")
            dtDatos.Columns.Add("SINDICALIZADO")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("CENTRO_COSTOS")
            dtDatos.Columns.Add("NOMBRE_CC")
            dtDatos.Columns.Add("ANO")
            dtDatos.Columns.Add("PERIODO")
            dtDatos.Columns.Add("COD_CLASE")
            dtDatos.Columns.Add("NOMBRE_CLASE")
            dtDatos.Columns.Add("SUPERVISOR")

            dtDatos.Columns.Add("ENCABEZADO")

            dtDatos.Columns.Add("HORAS_NORMALES_CC", GetType(System.Double))
            dtDatos.Columns.Add("W_HOURS", GetType(System.Double)) ' Worked HOurs
            dtDatos.Columns.Add("WP_HOURS", GetType(System.Double)) ' Worked Payment Hours
            dtDatos.Columns.Add("INS_OUT", GetType(System.Double)) ' Clock INS / OUT
            dtDatos.Columns.Add("PERCEPCION_BASE_CC", GetType(System.Double))

            dtDatos.Columns.Add("HORAS_EXTRA_CC", GetType(System.Double))
            dtDatos.Columns.Add("PERCEPCION_EXTRA_CC", GetType(System.Double))

            dtDatos.Columns.Add("HRSEX2", GetType(System.Double))
            dtDatos.Columns.Add("HRSEX3", GetType(System.Double))
            dtDatos.Columns.Add("HRSFEL", GetType(System.Double))

            dtDatos.Columns.Add("CTEMPO", GetType(System.Double))
            dtDatos.Columns.Add("CTUNEL", GetType(System.Double))
            dtDatos.Columns.Add("CTUNE2", GetType(System.Double))
            dtDatos.Columns.Add("PRISAB", GetType(System.Double))
            dtDatos.Columns.Add("PRIDOM", GetType(System.Double))
            dtDatos.Columns.Add("FACTOR", GetType(System.Double))

            dtDatos.Columns.Add("HRS_PLANEADAS", GetType(System.Double))
            dtDatos.Columns.Add("DIAC50", GetType(System.Double))
            dtDatos.Columns.Add("HRSRET", GetType(System.Double))
            dtDatos.Columns.Add("HRSPSG", GetType(System.Double))
            dtDatos.Columns.Add("DIAFIN", GetType(System.Double))
            dtDatos.Columns.Add("DIAFJU", GetType(System.Double))
            dtDatos.Columns.Add("DIAPSG", GetType(System.Double))
            dtDatos.Columns.Add("DIASVA", GetType(System.Double))
            dtDatos.Columns.Add("INCAP", GetType(System.Double))
            dtDatos.Columns.Add("DIAMAT", GetType(System.Double))
            dtDatos.Columns.Add("DIAIMA", GetType(System.Double))
            dtDatos.Columns.Add("DIANAC", GetType(System.Double))
            dtDatos.Columns.Add("DIAFUN", GetType(System.Double))

            frmTrabajando.Show()
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Text = "Preparando datos..."
            Application.DoEvents()
            frmTrabajando.Avance.IsRunning = True


            '  Dim dtPerNor As DataTable = sqlExecute("select rtrim(concepto) as concepto, case when cod_naturaleza = 'P' then 1 else -1 end as porcentaje, rtrim(detalle) as detalle, factor_detalle from conceptos where reporte_finanzas = '01'", "nomina")
            ' Dim dtPerExt As DataTable = sqlExecute("select rtrim(concepto) as concepto, case when cod_naturaleza = 'P' then 1 else -1 end as porcentaje, rtrim(detalle) as detalle, factor_detalle from conceptos where reporte_finanzas = '02'", "nomina")

            Dim conceptos_normales As String = ""
            Dim detalle_normales As String = ""
            Dim conceptos_extras As String = ""
            Dim detalle_extras As String = ""

            For Each row As DataRow In dtInformacion.Rows
                '    For Each row As DataRow In dtInformacion.Select("cod_depto='43473'") ' Para revisar x cierto CCosto, pero se busca por el cod_depto su relacion con el ccosto está en la tabla de DEPTOS
                Dim drow As DataRow = dtDatos.NewRow

                frmTrabajando.lblAvance.Text = "Reloj " & row("RELOJ").ToString.Trim  '*NOTA: Puede cambiar si es reloj, año, periodo, etc..
                Application.DoEvents()
                '  sqlExecute("INSERT into temporal VALUES ('" & row("RELOJ").ToString.Trim & "')")

                drow("RELOJ") = row("RELOJ")
                drow("SINDICALIZADO") = IIf(Not IsDBNull(row("SINDICALIZADO")), row("SINDICALIZADO"), 0)
                drow("COD_HORA") = IIf(Not IsDBNull(row("COD_HORA")), row("COD_HORA"), "")
                drow("NOMBRES") = row("NOMBRES")
                drow("CENTRO_COSTOS") = row("CENTRO_COSTOS")
                drow("NOMBRE_CC") = row("NOMBRE_CC")
                drow("ENCABEZADO") = encabezado

                Dim HRSNOR As Double = 0.0 ' Horas reales trabajadas
                Dim cod_comp As String = IIf(IsDBNull(row("COD_COMP")), "", row("COD_COMP").ToString.Trim)
                Dim NoSem As Integer = 0
                Dim HRS_PLANEADAS As Double = 0.0
                Dim HrsXDia As Double = 0.0
                Dim W_HOURS As Double = 0.0
                Dim WP_HOURS As Double = 0.0
                Dim INS_OUT As Double = 0.0
                Dim CantChecFalt As Integer = 0

                Dim supervisor As String = ""
                Try
                    Dim dtSuper As DataTable = sqlExecute("select * from super where cod_super = '" & row("COD_SUPER") & "'")
                    If dtSuper.Rows.Count > 0 Then
                        supervisor = dtSuper.Rows(0)("nombre")
                    End If
                Catch ex As Exception

                End Try
                drow("SUPERVISOR") = supervisor

                '---12/11/2019: AOS: Revisar
                Dim cod_clase As String = RTrim(row("COD_CLASE"))
                If cod_clase = "D" Then
                    drow("COD_CLASE") = "DL"
                    drow("NOMBRE_CLASE") = "HOURLY DIRECT LABOR"
                ElseIf cod_clase = "I" Then
                    drow("COD_CLASE") = "TM1"
                    drow("NOMBRE_CLASE") = "HOURLY INDIRECT"
                ElseIf cod_clase = "A" Then
                    drow("COD_CLASE") = "-"
                    drow("NOMBRE_CLASE") = "SALARY"
                End If


                drow("ANO") = row("ANO")
                drow("PERIODO") = row("PERIODO")

                drow("HRSEX2") = IIf(Not IsDBNull(row("HRSEX2")), row("HRSEX2"), 0)
                drow("HRSEX3") = IIf(Not IsDBNull(row("HRSEX3")), row("HRSEX3"), 0)
                drow("HRSFEL") = IIf(Not IsDBNull(row("HRSFEL")), row("HRSFEL"), 0)

                HRSNOR = IIf(Not IsDBNull(row("HRSNOR")), row("HRSNOR"), 0)
                drow("HORAS_NORMALES_CC") = HRSNOR
                drow("HORAS_EXTRA_CC") = drow("HRSEX2") + drow("HRSEX3") + drow("HRSFEL")

                'Dim PerNor As Double = 0

                ''--Va sumando la percep de cada concepto o restando en caso de ser deduc
                'For Each row_ As DataRow In dtPerNor.Rows
                '    Dim concepto As String = RTrim(row_("concepto"))

                '    If Not ("******").Contains(concepto.ToUpper) Then
                '        Dim m As Double = IIf(IsDBNull(row(concepto)), 0, row(concepto))
                '        Dim f As Double = IIf(IsDBNull(row_("porcentaje")), 1, row_("porcentaje"))
                '        PerNor += m * f
                '    End If
                'Next

                ''---Obtener el total de horas
                'Dim PerExt As Double = 0
                'Dim HrsExt As Double = 0
                'For Each row_ As DataRow In dtPerExt.Rows
                '    Dim concepto As String = RTrim(row_("concepto"))

                '    If Not ("******").Contains(concepto.ToUpper) Then
                '        Dim m As Double = IIf(IsDBNull(row(concepto)), 0, row(concepto))
                '        Dim f As Double = IIf(IsDBNull(row_("porcentaje")), 1, row_("porcentaje"))
                '        PerExt += m * f

                '    End If

                'Next
                'drow("PERCEPCION_BASE_CC") = PerNor
                'drow("PERCEPCION_EXTRA_CC") = PerExt

                drow("PERCEPCION_BASE_CC") = 0
                drow("PERCEPCION_EXTRA_CC") = 0

                If cod_clase = "D" Then
                    Dim listadoCFC As String = "22539,22541,22552,22554,22555,22576,22577"
                    If listadoCFC.Contains(RTrim(drow("CENTRO_COSTOS"))) Then
                        drow("FACTOR") = 40
                    Else
                        drow("FACTOR") = 45
                    End If
                Else
                    drow("FACTOR") = 45
                End If

                '--  Work hours
                Dim QWHrs As String = "SELECT ISNULL(((SUM(DATEPART(SECOND, horas) + 60 * DATEPART(MINUTE, horas) + 3600 * DATEPART(HOUR, horas)))/60),0) AS 'WORKED_HOURS' FROM asist where ano+periodo='" & anoPeriodo & "' and reloj='" & row("RELOJ").ToString.Trim & "' and ausentismo=0"
                Dim dtWHours As DataTable = sqlExecute(QWHrs, "TA")

                If (Not dtWHours.Columns.Contains("Error") And dtWHours.Rows.Count > 0) Then
                    W_HOURS = IIf(IsDBNull(dtWHours.Rows(0).Item("WORKED_HOURS")), 0, Double.Parse(dtWHours.Rows(0).Item("WORKED_HOURS"))) ' Min
                    W_HOURS = Math.Round(W_HOURS / 60, 2) ' Horas
                End If
                drow("W_HOURS") = W_HOURS

                '-- Work Payment Hours
                Dim QWPHrs As String = "SELECT ISNULL(((SUM(DATEPART(SECOND, HORAS_NORMALES) + 60 * DATEPART(MINUTE, HORAS_NORMALES) + 3600 * DATEPART(HOUR, HORAS_NORMALES)))/60),0) AS 'WORKED_PAYMENT_HOURS'  FROM asist where ano+periodo='" & anoPeriodo & "' and reloj='" & row("RELOJ").ToString.Trim & "' and ausentismo=0"
                Dim dtWPHours As DataTable = sqlExecute(QWPHrs, "TA")
                If (Not dtWPHours.Columns.Contains("Error") And dtWPHours.Rows.Count > 0) Then
                    WP_HOURS = IIf(IsDBNull(dtWPHours.Rows(0).Item("WORKED_PAYMENT_HOURS")), 0, Double.Parse(dtWPHours.Rows(0).Item("WORKED_PAYMENT_HOURS"))) ' Min
                    WP_HOURS = Math.Round(WP_HOURS / 60, 2) ' Horas
                End If
                drow("WP_HOURS") = WP_HOURS


                '---Horas Planeadas
                Dim dtHrsPlan As DataTable = sqlExecute("select * from rol_horarios where COD_COMP='" & cod_comp & "' and ano+PERIODO='" & anoPeriodo & "' and COD_HORA='" & drow("COD_HORA") & "'", "PERSONAL")
                If (Not dtHrsPlan.Columns.Contains("Error") And dtHrsPlan.Rows.Count > 0) Then
                    NoSem = IIf(IsDBNull(dtHrsPlan.Rows(0).Item("SEMANA")), 0, dtHrsPlan.Rows(0).Item("SEMANA"))
                    If (NoSem <> 0) Then
                        Dim dtSumHrs As DataTable = sqlExecute("SELECT ((SUM(DATEPART(SECOND, HRS_DIA) + 60 * DATEPART(MINUTE, [HRS_DIA]) + 3600 * DATEPART(HOUR, [HRS_DIA])))/60)/60 AS TOTAL_HORAS  FROM dias where COD_COMP='" & cod_comp & "' and COD_HORA='" & drow("COD_HORA") & "' and SEMANA=" & NoSem & " AND DESCANSO=0  ", "PERSONAL")
                        If (Not dtSumHrs.Columns.Contains("Error") And dtSumHrs.Rows.Count > 0) Then
                            HRS_PLANEADAS = IIf(IsDBNull(dtSumHrs.Rows(0).Item("TOTAL_HORAS")), 0, Double.Parse(dtSumHrs.Rows(0).Item("TOTAL_HORAS")))
                        End If
                    End If
                End If

                '-------Obtener las horas diarias
                Dim dtHrsXDia As DataTable = sqlExecute("select top 1 ((DATEPART(SECOND, HRS_DIA) + 60 * DATEPART(MINUTE, [HRS_DIA]) + 3600 * DATEPART(HOUR, [HRS_DIA]))/60) AS TOTAL_MIN  from dias where COD_COMP='" & cod_comp & "' and COD_HORA='" & drow("COD_HORA") & "' and SEMANA=" & NoSem & " and descanso=0 ", "PERSONAL")
                If (Not dtHrsXDia.Columns.Contains("Error") And dtHrsXDia.Rows.Count > 0) Then
                    HrsXDia = IIf(IsDBNull(dtHrsXDia.Rows(0).Item("TOTAL_MIN")), 0, Double.Parse(dtHrsXDia.Rows(0).Item("TOTAL_MIN"))) ' Min
                    HrsXDia = Math.Round(HrsXDia / 60, 2) ' Horas
                End If

                '---Si el periodo es "Q", el total de horas es * 15
                If tipo_periodo.ToUpper.Trim = "Q" Then
                    Dim TotDias As Integer = 15

                    '***Validar cuando el alta es dentro del periodo para obtener el total de dias trabajados (Solo para 15nales ("Q"))

                    Dim Alta As String = ""
                    Try : Alta = FechaSQL(row("Alta")) : Catch ex As Exception : Alta = "" : End Try
                    If (Alta <> "" And Fini <> "" And FFin <> "") Then
                        If ((Alta >= Fini And Alta <= FFin)) Then ' Alta dentro del periodo
                            TotDias = DateDiff(DateInterval.Day, Convert.ToDateTime(Alta), Convert.ToDateTime(FFin))
                        End If
                    End If
                    HRS_PLANEADAS = HrsXDia * TotDias
                End If

                '--Las horas reales trabajadas no pueden ser mayor a las planeadas que es en base a su horario
                If (HRSNOR > HRS_PLANEADAS) Then HRS_PLANEADAS = HRSNOR

                drow("HRS_PLANEADAS") = HRS_PLANEADAS

                '***-Obtener las horas que faltan cuando faltan checadas  y en comentario tienen que les falta de entrada o una falta de salida (Clock INS / MISSING)
                Dim QCInsOut As String = " SELECT reloj,ano,PERIODO,FHA_ENT_HOR,entro,FHA_SAL_HOR,salio,HORAS,HORAS_NORMALES,COMENTARIO,ausentismo,TIPO_AUS,cod_hora FROM ASIST where (COMENTARIO like'%FALTA SAL%' OR COMENTARIO LIKE '%FALTA ENT%') " & _
                                         "and ano+periodo='" & anoPeriodo & "' and reloj='" & row("RELOJ").ToString.Trim & "'"

                Dim dtInsOut As DataTable = sqlExecute(QCInsOut, "TA")
                If (Not dtInsOut.Columns.Contains("Error") And dtInsOut.Rows.Count > 0) Then
                    CantChecFalt = dtInsOut.Rows.Count
                    INS_OUT = CantChecFalt * HrsXDia
                End If
                drow("INS_OUT") = INS_OUT

                '**********************INCIDENCIAS
                '-DIAC50
                Dim DIAC50 As Double = 0.0
                Try : DIAC50 = IIf(IsDBNull(row("DIAC50")), 0, Double.Parse(row("DIAC50"))) : Catch ex As Exception : DIAC50 = 0.0 : End Try
                Dim HrsDiaC50 As Double = 0.0

                If (DIAC50 <> 0) Then
                    HrsDiaC50 = (HrsXDia * DIAC50) / 2
                End If
                drow("DIAC50") = HrsDiaC50

                '- HRSRET
                Dim HRSRET As Double = 0
                Try : HRSRET = IIf(IsDBNull(row("HRSRET")), 0, Double.Parse(row("HRSRET"))) : Catch ex As Exception : HRSRET = 0.0 : End Try
                drow("HRSRET") = HRSRET

                '- HRSPSG
                Dim HRSPSG As Double = 0.0
                Try : HRSPSG = IIf(IsDBNull(row("HRSPSG")), 0, Double.Parse(row("HRSPSG"))) : Catch ex As Exception : HRSPSG = 0.0 : End Try
                drow("HRSPSG") = HRSPSG

                '**********************AUSENTISMOS
                'DIAFIN
                Dim DIAFIN As Double = 0.0
                Try : DIAFIN = IIf(IsDBNull(row("DIAFIN")), 0, Double.Parse(row("DIAFIN"))) : Catch ex As Exception : DIAFIN = 0.0 : End Try
                DIAFIN = DIAFIN * HrsXDia
                drow("DIAFIN") = DIAFIN

                'DIAFJU
                Dim DIAFJU As Double = 0.0
                Try : DIAFJU = IIf(IsDBNull(row("DIAFJU")), 0, Double.Parse(row("DIAFJU"))) : Catch ex As Exception : DIAFJU = 0.0 : End Try
                DIAFJU = DIAFJU * HrsXDia
                drow("DIAFJU") = DIAFJU

                'DIAPSG
                Dim DIAPSG As Double = 0.0
                Try : DIAPSG = IIf(IsDBNull(row("DIAPSG")), 0, Double.Parse(row("DIAPSG"))) : Catch ex As Exception : DIAPSG = 0.0 : End Try
                DIAPSG = DIAPSG * HrsXDia
                drow("DIAPSG") = DIAPSG

                'DIASVA
                Dim DIASVA As Double = 0.0
                Try : DIASVA = IIf(IsDBNull(row("DIASVA")), 0, Double.Parse(row("DIASVA"))) : Catch ex As Exception : DIASVA = 0.0 : End Try
                DIASVA = DIASVA * HrsXDia
                drow("DIASVA") = DIASVA

                '-INCAP (DIAING + DIAINY  +  DIAITR)
                Dim INCAP As Double = 0.0
                Dim DIAING As Double = 0.0
                Dim DIAINY As Double = 0.0
                Dim DIAITR As Double = 0.0
                Try : DIAING = IIf(IsDBNull(row("DIAING")), 0, Double.Parse(row("DIAING"))) : Catch ex As Exception : DIAING = 0.0 : End Try
                DIAING = DIAING * HrsXDia

                Try : DIAINY = IIf(IsDBNull(row("DIAINY")), 0, Double.Parse(row("DIAINY"))) : Catch ex As Exception : DIAINY = 0.0 : End Try
                DIAINY = DIAINY * HrsXDia

                Try : DIAITR = IIf(IsDBNull(row("DIAITR")), 0, Double.Parse(row("DIAITR"))) : Catch ex As Exception : DIAITR = 0.0 : End Try
                DIAITR = DIAITR * HrsXDia

                INCAP = DIAING + DIAINY + DIAITR

                drow("INCAP") = INCAP

                '--DIAMAT (Matrimonio)
                Dim DIAMAT As Double = 0.0
                Try : DIAMAT = IIf(IsDBNull(row("DIAMAT")), 0, Double.Parse(row("DIAMAT"))) : Catch ex As Exception : DIAMAT = 0.0 : End Try
                DIAMAT = DIAMAT * HrsXDia
                drow("DIAMAT") = DIAMAT

                '--DIAIMA (MATERNIDAD)
                Dim DIAIMA As Double = 0.0
                Try : DIAIMA = IIf(IsDBNull(row("DIAIMA")), 0, Double.Parse(row("DIAIMA"))) : Catch ex As Exception : DIAIMA = 0.0 : End Try
                DIAIMA = DIAIMA * HrsXDia
                drow("DIAIMA") = DIAIMA

                '--DIANAC (NACIMIENTO)
                Dim DIANAC As Double = 0.0
                Try : DIANAC = IIf(IsDBNull(row("DIANAC")), 0, Double.Parse(row("DIANAC"))) : Catch ex As Exception : DIANAC = 0.0 : End Try
                DIANAC = DIANAC * HrsXDia
                drow("DIANAC") = DIANAC

                '--DIAFUN (DEFUNCION)
                Dim DIAFUN As Double = 0.0
                Try : DIAFUN = IIf(IsDBNull(row("DIAFUN")), 0, Double.Parse(row("DIAFUN"))) : Catch ex As Exception : DIAFUN = 0.0 : End Try
                DIAFUN = DIAFUN * HrsXDia
                drow("DIAFUN") = DIAFUN

                '----Insertar registro finalmente
                dtDatos.Rows.Add(drow)
            Next


            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            ' Dim pausa As Integer = 0
        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)


        End Try
    End Sub


    Public Sub KPIOvertime(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        dtDatos.Columns.Add("centro_costos")
        dtDatos.Columns.Add("nombre")
        dtDatos.Columns.Add("clase")
        dtDatos.Columns.Add("cod_clase")
        dtDatos.Columns.Add("perex2", System.Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("perex3", System.Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("hrsex2", System.Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("hrsex3", System.Type.GetType("System.Decimal"))



        For Each dr As DataRow In dtInformacion.Rows

            dtDatos.Rows.Add({dr("centro_costos"),
                              dr("nombre_cc"),
                              dr("nombre_clase"),
                              dr("cod_clase"),
                              IIf(IsDBNull(dr("perex2")), 0, dr("perex2")),
                              IIf(IsDBNull(dr("perex3")), 0, dr("perex3")),
                              IIf(IsDBNull(dr("hrsex2")), 0, dr("hrsex2")),
                              IIf(IsDBNull(dr("hrsex3")), 0, dr("hrsex3"))
                             })

        Next

    End Sub

    Public Sub genera_retroactivos()
        Dim dtinformacion As New DataTable
        Dim n As Integer = 2


        frmRangoFechas.ShowDialog()


        Try
            Dim saveFileDialog1 As New SaveFileDialog()

            saveFileDialog1.Filter = "Excel File|*.xlsx"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then



                dtinformacion = sqlExecute("select ajustes_nom.tipo_periodo,ajustes_nom.ano, ajustes_nom.periodo, ajustes_nom.reloj, ajustes_nom.CONCEPTO, " & _
                                           "conceptos.nombre,ajustes_nom.monto, '' as concepto_importe, '' as importe, FECHA_INCIDENCIA, periodos.num_mes, " & _
                                           "periodos.mes, PERSONALvw.cod_depto, PERSONALvw.cod_tipo, PERSONALvw.cod_super, PERSONALvw.nombre_super, personalvw.nombre_depto, " & _
                                           "personalvw.centro_costos,personalvw.cod_area, personalvw.nombre_area  from ajustes_nom " & _
                                           "LEFT JOIN TA.dbo.periodos on ajustes_nom.ano+ajustes_nom.periodo = periodos.ano+periodos.periodo " & _
                                           "LEFT JOIN PERSONAL.dbo.personalvw on ajustes_nom.reloj = PERSONALvw.reloj " & _
                                           "LEFT JOIN CONCEPTOs on ajustes_nom.CONCEPTO = conceptos.CONCEPTO " & _
                                           "where ajustes_nom.ano+ajustes_nom.periodo in (select ano+periodo from TA.dbo.periodos where fecha_ini >= '" & FechaSQL(FechaInicial) & "' and  fecha_fin <= '" & FechaSQL(FechaFinal) & "') " & _
                                           "and ajustes_nom.CONCEPTO  in (select CONCEPTO from CONCEPTOs where MISCE_FECHA = '1' union all select concepto from conceptos where concepto = 'RETRO') and ajustes_nom.tipo_periodo = 'S' " & _
                                           "and (fecha_incidencia < periodos.FECHA_INI OR fecha_incidencia is null) and ajustes_nom.es_retro = '1' order by ajustes_nom.PERIODO asc ", "NOMINA")



                For Each dr As DataRow In dtinformacion.Rows

                    Dim dtconceptos As DataTable = sqlExecute("select * from conceptos where detalle = '" & dr("concepto") & "'", "NOMINA")
                    If dtconceptos.Rows.Count > 0 Then
                        dr("concepto_importe") = IIf(IsDBNull(dtconceptos.Rows(0).Item("concepto")), "", dtconceptos.Rows(0).Item("concepto"))
                    Else
                        dr("concepto_importe") = dr("concepto")
                    End If

                    Dim dtmovimientos As DataTable = sqlExecute("select * from movimientos where ano = '" & dr("ano") & "'  and periodo = '" & dr("periodo") & "' and reloj = '" & dr("reloj") & "' and concepto = '" & dr("concepto_importe") & "'", "NOMINA")
                    If dtmovimientos.Rows.Count > 0 Then
                        dr("importe") = IIf(IsDBNull(dtmovimientos.Rows(0).Item("monto")), "", dtmovimientos.Rows(0).Item("monto"))
                    Else
                        If dr("concepto") = "HRSEXA" Then
                            Dim dtmovextras As DataTable = sqlExecute("select sum(monto) as monto2 from movimientos where ano = '" & dr("ano") & "'  and periodo = '" & dr("periodo") & "' and reloj = '" & dr("reloj") & "' and concepto in ('PER2AN', 'PER3AN')", "NOMINA")
                            If dtmovextras.Rows.Count > 0 Then
                                dr("importe") = IIf(IsDBNull(dtmovextras.Rows(0).Item("monto2")), "", dtmovextras.Rows(0).Item("monto2"))
                            Else
                                dr("importe") = "0"
                            End If
                        Else
                            dr("importe") = "0"
                        End If
                    End If

                Next

                Dim File = New FileInfo(DireccionReportes & "Plantilla retro.xlsx")

                Using package As New ExcelPackage(File)
                    package.Load(New FileStream(DireccionReportes & "Plantilla retro.xlsx", FileMode.Open))

                    Dim workSheet As ExcelWorksheet = package.Workbook.Worksheets("Detalle")

                    For Each dr As DataRow In dtinformacion.Rows
                        workSheet.Cells("A" & (n).ToString).Value = ""
                        workSheet.Cells("B" & (n).ToString).Value = dr("tipo_periodo").ToString
                        workSheet.Cells("C" & (n).ToString).Value = dr("ano").ToString
                        workSheet.Cells("D" & (n).ToString).Value = dr("periodo").ToString
                        workSheet.Cells("E" & (n).ToString).Value = dr("reloj").ToString
                        workSheet.Cells("F" & (n).ToString).Value = dr("concepto").ToString
                        workSheet.Cells("G" & (n).ToString).Value = dr("nombre").ToString
                        workSheet.Cells("H" & (n).ToString).Value = Double.Parse(dr("monto"))
                        workSheet.Cells("I" & (n).ToString).Value = dr("concepto_importe").ToString
                        workSheet.Cells("J" & (n).ToString).Value = Double.Parse(dr("importe"))
                        workSheet.Cells("K" & (n).ToString).Value = dr("fecha_incidencia").ToString
                        workSheet.Cells("L" & (n).ToString).Value = dr("num_mes").ToString & " " & dr("mes")
                        workSheet.Cells("M" & (n).ToString).Value = dr("cod_depto")
                        workSheet.Cells("N" & (n).ToString).Value = dr("cod_tipo")
                        workSheet.Cells("O" & (n).ToString).Value = dr("cod_super")
                        workSheet.Cells("P" & (n).ToString).Value = dr("nombre_super")
                        workSheet.Cells("Q" & (n).ToString).Value = dr("nombre_depto")
                        workSheet.Cells("R" & (n).ToString).Value = dr("centro_costos")
                        workSheet.Cells("S" & (n).ToString).Value = dr("cod_area")
                        workSheet.Cells("T" & (n).ToString).Value = dr("nombre_area")


                        n = n + 1
                    Next

                    package.SaveAs(New System.IO.FileInfo(saveFileDialog1.FileName.ToString()))



                End Using


            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            MessageBox.Show("Ocurrio un error al generar el reporte de retroactivos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub
    Public Sub PagosElectronicosPEN(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "", Optional _inter As String = "0")
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("rfc", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))
            dtDatos.Columns.Add("ano", Type.GetType("System.String"))

            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cuenta", Type.GetType("System.String"))

            dtDatos.Columns.Add("cla_ban", Type.GetType("System.String"))

            dtDatos.Columns.Add("nomina", Type.GetType("System.Double"))
            dtDatos.Columns.Add("prestamo", Type.GetType("System.Double"))
            dtDatos.Columns.Add("retiro", Type.GetType("System.Double"))
            dtDatos.Columns.Add("pension", Type.GetType("System.Double"))
            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))

            dtDatos.Columns.Add("tipo_reporte", Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo_periodo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_pago", Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo_cuenta", Type.GetType("System.String"))
            Dim tipo_periodo As String = ""

            For Each row As DataRow In dtInformacion.Rows
                If Trim(row("tipo_periodo")) = "Q" And tipo_periodo = "" Then
                    tipo_periodo = "Q"
                ElseIf Trim(row("tipo_periodo")) = "S" And tipo_periodo = "" Then
                    tipo_periodo = "S"
                Else
                    Exit For
                End If
            Next
            Dim dtPensiones As DataTable
            If _inter = "0" Or _inter = "1" Then
                dtPensiones = sqlExecute("select * from pensiones_alimenticias where  inter = '" & _inter & "' and cuenta <> '' and tipo_periodo = '" & tipo_periodo & "'", "nomina")
            Else
                dtPensiones = sqlExecute("select * from pensiones_alimenticias where ano = '" & _ano & "' and periodo = '" & _periodo & "' and cuenta = '' ", "nomina")
            End If

            For Each row As DataRow In dtPensiones.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")
                dr("rfc") = ""
                dr("nombres") = row("nombre")

                dr("cod_tipo") = "PX"
                dr("nombre_tipo") = "PENSIONES"
                dr("cod_clase") = "n/a"

                dr("alta") = "-"
                dr("baja") = "-"

                dr("ano") = _ano
                dr("periodo") = _periodo
                dr("cuenta") = row("cuenta")

                If row("cuenta").ToString.Trim.Length = 16 Then
                    dr("tipo_cuenta") = "03"
                ElseIf row("cuenta").ToString.Trim.Length = 18 Then
                    dr("tipo_cuenta") = "40"
                ElseIf row("cuenta").ToString.Trim.Length = 11 Then
                    dr("tipo_cuenta") = "01"
                End If

                dr("cla_ban") = IIf(_inter = "1", row("cuenta").ToString.Substring(0, 3), "000")

                dr("nomina") = 0
                dr("prestamo") = 0
                dr("retiro") = 0

                Dim dtmontopen As DataTable = sqlExecute("select * from movimientos where reloj = '" & row("reloj") & "' and ano= '" & _ano & "' and periodo = '" & _periodo & "' and tipo_periodo = '" & tipo_periodo & "' and concepto = 'PENAL1'", "NOMINA")
                Dim pension_ As Double = 0
                If dtmontopen.Rows.Count > 0 Then
                    pension_ = IIf(IsDBNull(dtmontopen.Rows(0).Item("monto")), 0, dtmontopen.Rows(0).Item("monto"))
                End If

                dr("pension") = pension_

                Dim monto_ As Double = pension_
                dr("monto") = monto_
                dr("nomina") = monto_
                If monto_ > 0 Then
                    dtDatos.Rows.Add(dr)
                End If

            Next
            'Obtener numero de cliente y cuenta para deposito banamex de cias
            Dim numcliente As String = ""
            Dim numcuenta As String = ""
            Dim datosbank As DataTable = sqlExecute("select * from cias where cod_comp = '610'")
            If datosbank.Rows.Count > 0 Then
                numcliente = datosbank.Rows(0).Item("num_cliente")
                numcuenta = datosbank.Rows(0).Item("num_cuenta")
            End If

            Dim consecutivo As String = ""

            If nombre_archivo.Contains("C1") Then
                consecutivo = "50"
                nombre_archivo = nombre_archivo.Replace("C1", "")
            ElseIf nombre_archivo.Contains("C2") Then
                consecutivo = "51"
                nombre_archivo = nombre_archivo.Replace("C2", "")
            ElseIf nombre_archivo.Contains("C3") Then
                consecutivo = "52"
                nombre_archivo = nombre_archivo.Replace("C3", "")
            End If

            If consecutivo = "" Then
                If tipo_periodo = "Q" Then
                    If _inter = "1" Then
                        consecutivo = "44"
                    Else
                        consecutivo = "43"
                    End If
                Else
                    If _inter = "1" Then
                        consecutivo = "34"
                    Else
                        consecutivo = "33"
                    End If
                End If
            End If



            Dim fecha_pago As Date = Nothing
            Dim ano_pago As String = ""
            Dim mes_pago As String = ""
            Dim dtfechapago As New DataTable
            If consecutivo = "50" Or consecutivo = "51" Or consecutivo = "52" Then
                frmSeleccionarFecha.ShowDialog()
                fecha_pago = FechaInicial
            Else
                If tipo_periodo = "Q" Then
                    dtfechapago = sqlExecute("select * from periodos_quincenal where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "TA")
                Else
                    dtfechapago = sqlExecute("select * from periodos where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "TA")
                End If
                fecha_pago = dtfechapago.Rows(0).Item("fecha_pago")
            End If
            'fecha_pago = Date.Now
            'fecha_pago = fecha_pago.AddDays(-1)
            ano_pago = fecha_pago.Year.ToString.Substring(2, 2)
            mes_pago = fecha_pago.Month.ToString.PadLeft(2, "0")


            If _inter = "0" Or _inter = "1" Then
                Try
                    ' dtInformacion = dtInformacion.Select("NETO > 0 OR PTMOFA > 0 OR SANEFA >0").CopyToDataTable
                    ' Dim LayoutParams As New frmBanamexLayoutD()
                    Dim Total As Double = 0
                    Dim Abonos As Integer = 0
                    Dim Creditos As Integer = 1
                    Dim dtRegistrosArchivo As DataTable = New DataTable

                    'LayoutParams.ShowDialog()

                    Dim Header1 As String = "" & _
                    "Select " & _
                    "'1'+ " & _
                    "Replace(STR(" + Trim(numcliente) + ",12),SPACE(1),'0')+ " & _
                    "'" + fecha_pago.ToString("yyMMdd") + "'+" & _
                    "Replace(STR('" & consecutivo & "',4),SPACE(1),'0')+" & _
                    "substring(REPLACE(NOMBRE,'.',''),0,37)+ " & _
                    "cast('PAGO NOM SEM" + _ano & _periodo + "' as char(20))+ " & _
                    "'15'+" & _
                    "'D'+" & _
                    "'01'" & _
                    "From PERSONAL.DBO.cias WHERE COD_COMP='610' "
                    Debug.Print(Header1)
                    dtRegistrosArchivo = sqlExecute(Header1, "Nomina")


                    For Each r As DataRow In dtDatos.Rows
                        Total = Total + r.Item("monto")
                        Abonos = Abonos + 1
                    Next


                    Dim Header2 As String = "" &
                    "Declare @Total as decimal(18,2) " &
                    "Declare @Abonos as int " &
                    "set @Total = " + Total.ToString() + " " &
                    "set @Abonos  = " + Abonos.ToString() + " " &
                    "Select " &
                    "'2'+" & _
                    "'1'+" & _
                    "'001'+ " & _
                    "Replace(" & _
                    "STR(" & _
                    "Replace( " & _
                    "CAST(round(@Total,2) AS nvarchar(18)) " & _
                    ",'.',''),18) " & _
                    ",space(1),'0')+" & _
                    "'01'+ " & _
                    "REPLACE(STR(" + Trim(numcuenta) + ",20),space(1),'0')+ " & _
                    "REPLACE(STR(@Abonos,6),space(1),'0') "
                    Debug.Print(Header2)
                    dtRegistrosArchivo.Merge(sqlExecute(Header2, "Nomina"))

                    Dim nombre As String = ""

                    If _inter = "0" Then


                        For Each r As DataRow In dtDatos.Rows

                            If r.Item("cod_tipo") = "PX" Then
                                nombre = r.Item("nombres").ToString.Replace("0", "").Replace("#", "N").Replace(".", "").Replace("ñ", "n").Replace("Ñ", "N").Trim
                            Else
                                nombre = r.Item("NOMBRES").ToString().Replace(".", "").Replace("#", "N").Replace("ñ", "n").Replace("Ñ", "N").Trim.Split(",")(2) + "," + r.Item("NOMBRES").ToString().Replace(".", "").Replace("#", "N").Replace("ñ", "n").Replace("Ñ", "N").Trim.Split(",")(0) + "/" + r.Item("NOMBRES").ToString().Replace(".", "").Replace("ñ", "n").Replace("#", "N").Replace("Ñ", "N").Trim.Split(",")(1)
                            End If
                            Dim Details As String = "" &
                                "Select " &
                                "'3'+" & _
                                "'0'+" & _
                                "'001'+ " & _
                                "'54'+ " & _
                                "'001'+ " & _
                                "Replace( " & _
                                "Str( " & _
                                "REPLACE( " & _
                                "CAST( " & _
                                "CAST(" + (IIf(IsDBNull(r.Item("monto")), 0, r.Item("monto"))).ToString + " AS decimal(18,2))  " &
                                "AS nvarchar(18)) " & _
                                ",'.',''),18) " & _
                                ",space(1),'0')+" & _
                                "'" + r.Item("tipo_cuenta") + "'+" & _
                                "Replace('" + r.Item("CUENTA").ToString.Trim.PadLeft(20, Space(1)) + "',SPACE(1),'0') + " & _
                                 "'" + "SEM" + r.Item("PERIODO").ToString().PadLeft(2, "0") + r.Item("ANO").ToString().PadLeft(4, "0000") + " " + r.Item("RELOJ").ToString() + "'+" & _
                                "substring( cast('" + nombre + "' as char(120)),0,56)+" & _
                                "REPLACE(STR('',35),'0',' ')+ " & _
                                "REPLACE(STR('',35),'0',' ')+ " & _
                                "REPLACE(STR('',35),'0',' ')+ " & _
                                "REPLACE(STR('',35),'0',' ')+ " & _
                                "'0000'+" & _
                                "'00'+" & _
                                "Replace(STR('',14),'0',' ')+ " & _
                                "REPLACE(STR('',8),'0',' ')+" & _
                                "REPLACE(STR('',80),'0',' ')+" & _
                                "REPLACE(STR('',50),'0',' ') "

                            Debug.Print(Details)
                            dtRegistrosArchivo.Merge(sqlExecute(Details, "Nomina"))
                        Next
                    Else
                        For Each r As DataRow In dtDatos.Rows
                            If r.Item("cod_tipo") = "PX" Then
                                nombre = r.Item("nombres").ToString.Replace(".", "").Replace("0", "").Replace("#", "N").Replace("ñ", "n").Replace("Ñ", "N").Replace("#", "N").Trim
                            Else
                                nombre = r.Item("NOMBRES").ToString().Replace(".", "").Replace("ñ", "n").Replace("#", "N").Replace("Ñ", "N").Trim.Split(",")(2) + "," + r.Item("NOMBRES").ToString().Replace(".", "").Replace("#", "N").Replace("ñ", "n").Replace("Ñ", "N").Trim.Split(",")(0) + "/" + r.Item("NOMBRES").ToString().Replace(".", "").Replace("#", "N").Replace("ñ", "n").Replace("Ñ", "N").Trim.Split(",")(1)
                            End If

                            Dim Details As String = "" &
                                "Select " &
                                "'3'+" & _
                                "'0'+" & _
                                "'002'+ " & _
                                "'54'+ " & _
                                "'001'+ " & _
                                "Replace( " & _
                                "Str( " & _
                                "REPLACE( " & _
                                "CAST( " & _
                                "CAST(" + (IIf(IsDBNull(r.Item("monto")), 0, r.Item("monto"))).ToString + " AS decimal(18,2))  " &
                                "AS nvarchar(18)) " & _
                                ",'.',''),18) " & _
                                ",space(1),'0')+" & _
                                "'" + r.Item("tipo_cuenta") + "'+" & _
                                "Replace('" + r.Item("CUENTA").ToString.Trim.PadLeft(20, Space(1)) + "',SPACE(1),'0') + " & _
                                 "'" + (r.Item("PERIODO").ToString() + r.Item("ANO").ToString()).ToString.PadRight(16, Space(1)) + "'+" & _
                                "substring( cast('" + nombre + "' as char(120)),0,56)+" & _
                                "REPLACE(STR('',35),'0',' ')+ " & _
                                "REPLACE(STR('',35),'0',' ')+ " & _
                                "REPLACE(STR('',35),'0',' ')+ " & _
                                "REPLACE(STR('',35),'0',' ')+ " & _
                                "'0'+'" + r.Item("cuenta").ToString.Substring(0, 3) + "'+" & _
                                "'00'+" & _
                                "Replace(STR('',14),'0',' ')+ " & _
                                "REPLACE(STR('',8),'0',' ')+" & _
                                "REPLACE(STR('',80),'0',' ')+" & _
                                "REPLACE(STR('',50),'0',' ') "



                            Debug.Print(Details)
                            dtRegistrosArchivo.Merge(sqlExecute(Details, "Nomina"))
                        Next
                    End If
                    Dim Footer As String = "" &
                    "Declare @Total as decimal(18,2) " & _
                    "Declare @Abonos as int " & _
                    "Declare @Creditos as int " & _
                    "set @Total = " & Total.ToString() & " " & _
                    "set @Abonos  = " & Abonos.ToString() & " " & _
                    "set @Creditos  = " & Creditos.ToString() & " " & _
                    " Select " & _
                    "'4'+ " & _
                    "'001'+" & _
                    "REPLACE(STR(@Abonos,6),space(1),'0') +" & _
                    "REPLACE( " & _
                    "STR( " & _
                    "REPLACE( " & _
                    "CAST(ROUND(@Total,2) AS nvarchar(18)) " & _
                    ",'.',''),18) " & _
                    ",space(1),'0') +" & _
                    "REPLACE(STR(@Creditos,6),space(1),'0') +" & _
                    "REPLACE( " & _
                    "STR( " & _
                    "REPLACE( " & _
                    "CAST(ROUND(@Total,2) AS nvarchar(18)) " & _
                    ",'.',''),18) " & _
                    ",space(1),'0') "

                    Debug.Print(Footer)
                    dtRegistrosArchivo.Merge(sqlExecute(Footer, "Nomina"))

                    'Dim SaveLayout As SaveFileDialog = New SaveFileDialog()
                    'SaveLayout.FileName = "S274000007.27405E01.10.210618.000114407860.01.NOM_CFX"
                    'SaveLayout.Filter = "Texto Plano|*.txt"
                    'SaveLayout.Title = "Guardar Layout Banamex"
                    nombre_archivo = nombre_archivo & "S274000007.27405E01.10." & fecha_pago.Day.ToString.PadLeft(2, "0").Trim & mes_pago & ano_pago & ".000114407860." & consecutivo & ".NOM_CFX.txt"
                    Dim Writer As StreamWriter
                    Writer = File.CreateText(nombre_archivo)
                    Writer.Close()
                    For Each dr As DataRow In dtRegistrosArchivo.Rows
                        Writer = File.AppendText(nombre_archivo)
                        Dim t As String = dr.Item(0).ToString()
                        t.Replace(".", " ")
                        Writer.WriteLine(t)
                        Writer.Flush()
                        Writer.Close()
                        Debug.Print(dr.Item(0))
                    Next


                    'LayoutParams.Dispose()
                    'dtDatos = dtInformacion.Copy




                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
                    'oWrite = Nothing
                End Try
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

        If dtDatos.Rows.Count = 0 Then
            Dim dr As DataRow = dtDatos.NewRow

            dr("reloj") = ""
            dr("rfc") = ""
            dr("nombres") = ""

            dr("cod_tipo") = ""
            dr("nombre_tipo") = ""
            dr("cod_clase") = "'"

            dr("alta") = ""
            dr("baja") = ""

            dr("ano") = ""
            dr("periodo") = ""
            dr("cuenta") = ""

            dr("cla_ban") = ""

            dr("nomina") = 0
            dr("prestamo") = 0
            dr("retiro") = 0
            dr("pension") = 0
            dr("monto") = 0

            Select Case _inter
                Case "0"
                    dr("tipo_reporte") = "electrónicos Citibanamex"
                Case "0"
                    dr("tipo_reporte") = "electrónicos Interbancarios"
                Case Else
                    dr("tipo_reporte") = "en efectivo"
            End Select

            dtDatos.Rows.Add(dr)

        End If


    End Sub

    'Public Sub ReporteFiniquito(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

    '    Dim dtEmp As New DataTable
    '    Dim dtDetalles1 As New DataTable
    '    Dim copiaDtInformacion As New DataTable
    '    Dim strcomp As String = ""
    '    Dim strTipo As String = ""
    '    Dim strreloj As String = ""
    '    Dim strnombre As String = ""
    '    Dim strpuesto As String = ""
    '    Dim stringreso As String = ""
    '    Dim strbaja As String = ""
    '    Dim antiguedad As Single = 0
    '    Dim perdia As Single = 0
    '    Dim persmen As Single = 0
    '    Dim cantidad As String = ""
    '    Dim strSQL As String = ""
    '    Dim _neto As Single = 0
    '    ' Dim detalle As String = ""
    '    Dim unidades As Single = 0

    '    Try
    '        dtDatos = New DataTable

    '        'Dim row As DataRow

    '        Dim strnaturaleza As String = ""
    '        Dim monto As Single = 0

    '        dtDatos.Columns.Add("recibido", GetType(System.String))
    '        dtDatos.Columns.Add("reloj", GetType(System.String))
    '        dtDatos.Columns.Add("nomemp", GetType(System.String))
    '        dtDatos.Columns.Add("puesto", GetType(System.String))
    '        dtDatos.Columns.Add("ingreso", GetType(System.String))
    '        dtDatos.Columns.Add("antiguedad", GetType(System.String))
    '        dtDatos.Columns.Add("perdia", GetType(System.Single))
    '        dtDatos.Columns.Add("permen", GetType(System.Single))
    '        dtDatos.Columns.Add("naturaleza", GetType(System.String))
    '        dtDatos.Columns.Add("concepto", GetType(System.String))
    '        dtDatos.Columns.Add("nombre", GetType(System.String))
    '        dtDatos.Columns.Add("dias", GetType(System.String))
    '        dtDatos.Columns.Add("prioridad", GetType(System.Int32))
    '        dtDatos.Columns.Add("importe", GetType(System.Single))
    '        dtDatos.Columns.Add("neto", GetType(System.Single))
    '        dtDatos.Columns.Add("ini", GetType(System.String))
    '        dtDatos.Columns.Add("fin", GetType(System.String))
    '        dtDatos.Columns.Add("TOTPER", GetType(System.Single))
    '        dtDatos.Columns.Add("TOTDED", GetType(System.Single))

    '        If dtInformacion.Rows.Count > 0 Then

    '            copiaDtInformacion = dtInformacion.Select("", "prioridad asc").CopyToDataTable

    '            dtEmp = sqlExecute("select * from nomina_calculo where folio = '" & dtInformacion.Rows(0).Item("folio") & "'", "NOMINA")

    '            strSQL = "select ltrim(rtrim(movmont.concepto)) as concepto,ltrim(rtrim(movmont.detalle)) as detalle,convert(real,movtmp.Monto) as Monto from(select mov.Concepto,con.detalle from(select concepto"
    '            strSQL &= " from movimientos_calculo"
    '            strSQL &= " where exists(select * from conceptos where cod_naturaleza in('P','D') and suma_neto = 1 and positivo in(0,1) and Concepto = movimientos_calculo.Concepto) and folio = '" & dtInformacion.Rows(0).Item("folio") & "') mov"
    '            strSQL &= " inner join conceptos con on mov.Concepto = con.CONCEPTO where detalle is not null) movmont"
    '            strSQL &= " inner join movimientos_calculo movtmp on movmont.detalle = movtmp.Concepto where folio = '" & dtInformacion.Rows(0).Item("folio") & "'"

    '            dtDetalles1 = sqlExecute(strSQL, "NOMINA")

    '            If Not dtEmp.Rows.Count > 0 Then Exit Sub

    '            strTipo = Trim(IIf(IsDBNull(dtEmp.Rows(0).Item("cod_tipo")), "", dtEmp.Rows(0).Item("cod_tipo")))
    '            strreloj = dtEmp.Rows(0).Item("reloj").ToString
    '            strnombre = dtEmp.Rows(0).Item("nombres").ToString
    '            strpuesto = Trim(IIf(IsDBNull(dtEmp.Rows(0).Item("puesto")), "", dtEmp.Rows(0).Item("puesto")))
    '            strcomp = Trim(IIf(IsDBNull(dtEmp.Rows(0).Item("cod_comp")), "", dtEmp.Rows(0).Item("cod_comp")))


    '            stringreso = FechaSQL(CDate(dtEmp.Rows(0).Item("alta_antig")))
    '            strbaja = FechaSQL(CDate(dtEmp.Rows(0).Item("baja_finqto")))
    '            'antiguedad = Math.Truncate(AntiguedadDbl(CDate(stringreso), CDate(strbaja)) * 100) / 100
    '            antiguedad = CSng(Math.Round(AntiguedadDbl(CDate(stringreso), CDate(strbaja)), 2))
    '            perdia = dtEmp.Rows(0).Item("sactual").ToString

    '            Select Case strTipo
    '                Case "O"
    '                    persmen = perdia * 30.4
    '                Case "A"
    '                    persmen = perdia * 30
    '                Case Else
    '                    persmen = perdia * 30.4
    '            End Select


    '            cantidad = ConvNvo(CDbl(copiaDtInformacion.Rows(0).Item("neto")))

    '            Dim _NumRegistro As Integer = 0

    '            For Each drRow As DataRow In copiaDtInformacion.Rows

    '                _NumRegistro = _NumRegistro + 1

    '                strnaturaleza = Trim(IIf(IsDBNull(drRow("naturaleza")), "", drRow("naturaleza")))

    '                monto = IIf(IsDBNull(drRow("monto")), 0, drRow("monto"))

    '                If (strnaturaleza = "P" Or strnaturaleza = "D") Then

    '                    Dim row As DataRow = dtDatos.NewRow

    '                    row("recibido") = cantidad
    '                    row("reloj") = strreloj
    '                    row("nomemp") = strnombre
    '                    row("puesto") = strpuesto
    '                    row("ingreso") = stringreso
    '                    row("ini") = FechaLetra(CDate(stringreso))
    '                    row("fin") = FechaLetra(CDate(strbaja))
    '                    row("antiguedad") = CStr(antiguedad) & " años"
    '                    row("perdia") = perdia
    '                    row("permen") = persmen
    '                    row("naturaleza") = IIf(IsDBNull(drRow("naturaleza")), "", drRow("naturaleza"))
    '                    row("concepto") = Trim(IIf(IsDBNull(drRow("concepto")), "", drRow("concepto")))
    '                    row("nombre") = IIf(IsDBNull(drRow("nombre")), "", drRow("nombre"))
    '                    row("prioridad") = IIf(IsDBNull(drRow("prioridad")), 0, drRow("prioridad"))
    '                    row("dias") = ""

    '                    'detalle = Trim(IIf(IsDBNull(drRow("detalle")), "", drRow("detalle")))

    '                    'If Not detalle.Trim = "" Then

    '                    '    If detalle.Trim.ToUpper.StartsWith("HR") Then
    '                    '        row("dias") = FormatNumber(drRow("unidades"), 2) & " hrs"
    '                    '    Else
    '                    '        row("dias") = FormatNumber(drRow("unidades"), 2) & " días"
    '                    '    End If

    '                    'End If


    '                    If dtDetalles1.Rows.Count > 0 Then

    '                        For Each drDetalle As DataRow In dtDetalles1.Select("concepto = '" & row("concepto") & "' ")

    '                            If drDetalle("detalle").ToString.Trim.ToUpper.StartsWith("HR") Then

    '                                row("dias") = FormatNumber(CSng(drDetalle("monto")), 2) & " hrs"

    '                            Else
    '                                row("dias") = FormatNumber(CSng(drDetalle("monto")), 2) & " días"

    '                            End If


    '                            Exit For


    '                        Next

    '                        'Select Case strnaturaleza
    '                        '    Case "P"
    '                        '        _neto = Math.Round(_neto + Math.Round(monto, 2), 2)
    '                        '    Case "D"
    '                        '        _neto = Math.Round(_neto - Math.Round(monto, 2), 2)
    '                        'End Select
    '                        ' row("dias") = IIf(IsDBNull(dtDetalles.Rows(0).Item("monto")), "", dtDetalles.Rows(0).Item("monto"))

    '                    Else
    '                        row("dias") = ""

    '                    End If

    '                    'Select Case strnaturaleza
    '                    '    Case "P"
    '                    '        _neto = Math.Round(_neto + Math.Round(monto, 2), 2)
    '                    '    Case "D"
    '                    '        _neto = Math.Round(_neto - Math.Round(monto, 2), 2)
    '                    'End Select

    '                    'row("importe") = Math.Truncate(monto * 100) / 100

    '                    row("importe") = monto
    '                    row("TOTPER") = IIf(IsDBNull(drRow("TOTPER")), 0, drRow("TOTPER"))
    '                    row("TOTDED") = IIf(IsDBNull(drRow("TOTDED")), 0, drRow("TOTDED"))
    '                    row("neto") = IIf(IsDBNull(drRow("neto")), 0, drRow("neto"))
    '                    'row("neto") = IIf(_NumRegistro = copiaDtInformacion.Rows.Count, _neto, 0)
    '                    dtDatos.Rows.Add(row)

    '                End If


    '            Next



    '        End If


    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reporte Finiquito", ex.HResult, ex.Message)
    '        MessageBox.Show("Se presentó un error al intentar cargar el formato de finiquito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub


    Public Sub ReporteFiniquito(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim dtEmp As New DataTable
        Dim dtDetalles1 As New DataTable
        Dim copiaDtInformacion As New DataTable
        Dim strcomp As String = ""
        Dim strTipo As String = ""
        Dim strreloj As String = ""
        Dim strFolio As String = ""
        Dim strnombre As String = ""
        Dim strpuesto As String = ""
        Dim stringreso As String = ""
        Dim strbaja As String = ""
        Dim antiguedad As Double = 0
        Dim perdia As Decimal = 0
        Dim persmen As Decimal = 0
        Dim cantidad As String = ""
        Dim strSQL As String = ""
        Dim _neto As Decimal = 0
        ' Dim detalle As String = ""
        Dim unidades As Decimal = 0

        Try
            dtDatos = New DataTable

            'Dim row As DataRow

            Dim strnaturaleza As String = ""
            Dim monto As Decimal = 0

            dtDatos.Columns.Add("recibido", GetType(System.String))
            dtDatos.Columns.Add("folio", GetType(System.String))
            dtDatos.Columns.Add("reloj", GetType(System.String))
            dtDatos.Columns.Add("nomemp", GetType(System.String))
            dtDatos.Columns.Add("puesto", GetType(System.String))
            dtDatos.Columns.Add("ingreso", GetType(System.String))
            dtDatos.Columns.Add("antiguedad", GetType(System.String))
            dtDatos.Columns.Add("perdia", GetType(System.Decimal))
            dtDatos.Columns.Add("permen", GetType(System.Decimal))
            dtDatos.Columns.Add("naturaleza", GetType(System.String))
            dtDatos.Columns.Add("concepto", GetType(System.String))
            dtDatos.Columns.Add("nombre", GetType(System.String))
            dtDatos.Columns.Add("dias", GetType(System.String))
            dtDatos.Columns.Add("prioridad", GetType(System.Int32))
            dtDatos.Columns.Add("importe", GetType(System.Decimal))
            dtDatos.Columns.Add("neto", GetType(System.Decimal))
            dtDatos.Columns.Add("ini", GetType(System.String))
            dtDatos.Columns.Add("fin", GetType(System.String))
            dtDatos.Columns.Add("TOTPER", GetType(System.Decimal))
            dtDatos.Columns.Add("TOTDED", GetType(System.Decimal))

            If dtInformacion.Rows.Count > 0 Then

                copiaDtInformacion = dtInformacion.Select("", "prioridad asc").CopyToDataTable

                'dtEmp = sqlExecute("select * from nomina_calculo where folio = '" & dtInformacion.Rows(0).Item("folio") & "'", "NOMINA")

                dtEmp = sqlExecute("select * from nomina_calculo where folio = '" & dtInformacion.Rows(0).Item("folio") & "' and reloj = '" & dtInformacion.Rows(0).Item("reloj") & "'", "NOMINA")

                'strSQL = "select ltrim(rtrim(movmont.concepto)) as concepto,ltrim(rtrim(movmont.detalle)) as detalle,convert(real,movtmp.Monto) as Monto from(select mov.Concepto,con.detalle from(select concepto"
                'strSQL &= " from movimientos_calculo"
                'strSQL &= " where exists(select * from conceptos where cod_naturaleza in('P','D') and suma_neto = 1 and positivo in(0,1) and Concepto = movimientos_calculo.Concepto) and folio = '" & dtInformacion.Rows(0).Item("folio") & "') mov"
                'strSQL &= " inner join conceptos con on mov.Concepto = con.CONCEPTO where detalle is not null) movmont"
                'strSQL &= " inner join movimientos_calculo movtmp on movmont.detalle = movtmp.Concepto where folio = '" & dtInformacion.Rows(0).Item("folio") & "'"

                If Not dtEmp.Rows.Count > 0 Then Exit Sub

                strSQL = "declare @_reloj nvarchar(max) = '" & dtEmp.Rows(0).Item("reloj").ToString & "'" & vbCrLf & _
                  "declare @_folio int = '" & dtEmp.Rows(0).Item("folio").ToString & "' " & vbCrLf & _
                  "select ltrim(rtrim(movmont.concepto)) as concepto,ltrim(rtrim(movmont.detalle)) as detalle,convert(real,movtmp.Monto) as Monto" & vbCrLf & _
                  "from (select mov.reloj,mov.Folio, mov.Concepto,con.detalle from(" & vbCrLf & _
                  "select reloj,folio,concepto" & vbCrLf & _
                  "from movimientos_calculo" & vbCrLf & _
                  "where exists(" & vbCrLf & _
                  "select * from conceptos" & vbCrLf & _
                  "where cod_naturaleza in('P','D') and suma_neto = 1 and positivo in(0,1) and concepto = movimientos_calculo.concepto" & vbCrLf & _
                  ") and reloj = @_reloj and folio = @_folio" & vbCrLf & _
                  ") mov inner join conceptos con on mov.Concepto = con.CONCEPTO where detalle is not null" & vbCrLf & _
                  ") movmont inner join movimientos_calculo movtmp on movmont.detalle = movtmp.Concepto and  movmont.reloj = movtmp.reloj and movmont.Folio = movtmp.Folio"


                dtDetalles1 = sqlExecute(strSQL, "NOMINA")

                strFolio = Trim(IIf(IsDBNull(dtEmp.Rows(0).Item("folio")), "", dtEmp.Rows(0).Item("folio")))
                strTipo = Trim(IIf(IsDBNull(dtEmp.Rows(0).Item("cod_tipo")), "", dtEmp.Rows(0).Item("cod_tipo")))
                strreloj = dtEmp.Rows(0).Item("reloj").ToString
                strnombre = dtEmp.Rows(0).Item("nombres").ToString
                strpuesto = Trim(IIf(IsDBNull(dtEmp.Rows(0).Item("puesto")), "", dtEmp.Rows(0).Item("puesto")))
                strcomp = Trim(IIf(IsDBNull(dtEmp.Rows(0).Item("cod_comp")), "", dtEmp.Rows(0).Item("cod_comp")))


                stringreso = FechaSQL(CDate(dtEmp.Rows(0).Item("alta_antig")))
                strbaja = FechaSQL(CDate(dtEmp.Rows(0).Item("baja_fin")))
                'antiguedad = Math.Truncate(AntiguedadDbl(CDate(stringreso), CDate(strbaja)) * 100) / 100
                antiguedad = Math.Round(AntiguedadDbl(CDate(stringreso), CDate(strbaja)), 2)
                perdia = dtEmp.Rows(0).Item("sactual").ToString

                Select Case strTipo
                    Case "O"
                        persmen = perdia * 30.4
                    Case "A"
                        persmen = perdia * 30
                    Case Else
                        persmen = perdia * 30.4
                End Select


                cantidad = ConvNvo(CDec(copiaDtInformacion.Rows(0).Item("neto")))

                Dim _NumRegistro As Integer = 0

                For Each drRow As DataRow In copiaDtInformacion.Rows

                    _NumRegistro = _NumRegistro + 1

                    strnaturaleza = Trim(IIf(IsDBNull(drRow("naturaleza")), "", drRow("naturaleza")))

                    monto = IIf(IsDBNull(drRow("monto")), 0, drRow("monto"))

                    If (strnaturaleza = "P" Or strnaturaleza = "D") Then

                        Dim row As DataRow = dtDatos.NewRow

                        row("recibido") = cantidad
                        row("folio") = "FOLIO: " & strFolio.Trim.PadLeft(6, "0")
                        row("reloj") = strreloj
                        row("nomemp") = strnombre
                        row("puesto") = strpuesto
                        row("ingreso") = stringreso
                        row("ini") = FechaLetra(CDate(stringreso))
                        row("fin") = FechaLetra(CDate(strbaja))
                        row("antiguedad") = CStr(antiguedad) & " años"
                        row("perdia") = perdia
                        row("permen") = persmen
                        row("naturaleza") = IIf(IsDBNull(drRow("naturaleza")), "", drRow("naturaleza"))
                        row("concepto") = Trim(IIf(IsDBNull(drRow("concepto")), "", drRow("concepto")))
                        row("nombre") = IIf(IsDBNull(drRow("nombre")), "", drRow("nombre"))
                        row("prioridad") = IIf(IsDBNull(drRow("prioridad")), 0, drRow("prioridad"))
                        row("dias") = ""

                        'detalle = Trim(IIf(IsDBNull(drRow("detalle")), "", drRow("detalle")))

                        'If Not detalle.Trim = "" Then

                        '    If detalle.Trim.ToUpper.StartsWith("HR") Then
                        '        row("dias") = FormatNumber(drRow("unidades"), 2) & " hrs"
                        '    Else
                        '        row("dias") = FormatNumber(drRow("unidades"), 2) & " días"
                        '    End If

                        'End If


                        If dtDetalles1.Rows.Count > 0 Then

                            For Each drDetalle As DataRow In dtDetalles1.Select("concepto = '" & row("concepto") & "' ")

                                If drDetalle("detalle").ToString.Trim.ToUpper.StartsWith("HR") Then

                                    row("dias") = FormatNumber(CDbl(drDetalle("monto")), 2) & " hrs"

                                Else
                                    row("dias") = FormatNumber(CDbl(drDetalle("monto")), 2) & " días"

                                End If


                                Exit For


                            Next

                            'Select Case strnaturaleza
                            '    Case "P"
                            '        _neto = Math.Round(_neto + Math.Round(monto, 2), 2)
                            '    Case "D"
                            '        _neto = Math.Round(_neto - Math.Round(monto, 2), 2)
                            'End Select
                            ' row("dias") = IIf(IsDBNull(dtDetalles.Rows(0).Item("monto")), "", dtDetalles.Rows(0).Item("monto"))

                        Else
                            row("dias") = ""

                        End If

                        'Select Case strnaturaleza
                        '    Case "P"
                        '        _neto = Math.Round(_neto + Math.Round(monto, 2), 2)
                        '    Case "D"
                        '        _neto = Math.Round(_neto - Math.Round(monto, 2), 2)
                        'End Select

                        'row("importe") = Math.Truncate(monto * 100) / 100

                        row("importe") = monto
                        row("TOTPER") = IIf(IsDBNull(drRow("TOTPER")), 0, drRow("TOTPER"))
                        row("TOTDED") = IIf(IsDBNull(drRow("TOTDED")), 0, drRow("TOTDED"))
                        row("neto") = IIf(IsDBNull(drRow("neto")), 0, drRow("neto"))
                        'row("neto") = IIf(_NumRegistro = copiaDtInformacion.Rows.Count, _neto, 0)
                        dtDatos.Rows.Add(row)

                    End If


                Next



            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un error al intentar cargar el formato de finiquito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub AjustesNominaDetalle(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)


        Dim tipo_per As String = IIf(IsDBNull(dtInformacion.Rows(0).Item("tipo_periodo")), "Q", dtInformacion.Rows(0).Item("tipo_periodo"))
        Dim ano_aju As String = IIf(IsDBNull(dtInformacion.Rows(0).Item("ano")), "Q", dtInformacion.Rows(0).Item("ano"))
        Dim per_aju As String = IIf(IsDBNull(dtInformacion.Rows(0).Item("periodo")), "Q", dtInformacion.Rows(0).Item("periodo"))
        'Dim QANFinal As String = "SELECT ANO,PERIODO,ajustes_nom.numcredito AS numcredito,conceptos.NOMBRE AS CONCEPTO,conceptos.concepto as clave, naturalezas.NOMBRE AS NATURALEZA,ajustes_nom.RELOJ,NOMBRES," & _
        '                            "MONTO, ajustes_nom.fecha, ajustes_nom.usuario FROM ajustes_nom LEFT JOIN personal.dbo.personalvw ON ajustes_nom.reloj = personalvw.reloj " & _
        '                            "LEFT JOIN conceptos ON ajustes_nom.concepto = conceptos.concepto " & _
        '                            "LEFT JOIN naturalezas ON conceptos.cod_naturaleza = naturalezas.cod_naturaleza " & _
        '                            "WHERE ano = '" & ano_aju & "' and periodo = '" & per_aju & "' and ajustes_nom.tipo_periodo = '" & tipo_per & "' and ajustes_nom.PER_DED <> 'HD' and usuario not like '%EXPORT%'"


        Dim QANFinal As String = "SELECT ANO,PERIODO,ajustes_nom.numcredito AS numcredito,conceptos.NOMBRE AS CONCEPTO,conceptos.concepto as clave, naturalezas.NOMBRE AS NATURALEZA,ajustes_nom.RELOJ,NOMBRES," & _
                                            "MONTO, ajustes_nom.fecha, ajustes_nom.usuario FROM ajustes_nom LEFT JOIN personal.dbo.personalvw ON ajustes_nom.reloj = personalvw.reloj " & _
                                            "LEFT JOIN conceptos ON ajustes_nom.concepto = conceptos.concepto " & _
                                            "LEFT JOIN naturalezas ON conceptos.cod_naturaleza = naturalezas.cod_naturaleza " & _
                                            "WHERE CAP_NOMINA = '1' AND ano = '" & ano_aju & "' and periodo = '" & per_aju & "' and ajustes_nom.tipo_periodo = '" & tipo_per & "'"



        dtDatos = sqlExecute(QANFinal, "nomina")


    End Sub
    Public Sub PagosConvenio(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "", Optional _dias_a_sumar As String = "")
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

            dtDatos.Columns.Add("nomina", Type.GetType("System.Double"))
            dtDatos.Columns.Add("retiro", Type.GetType("System.Double"))
            dtDatos.Columns.Add("prestamo", Type.GetType("System.Double"))

            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))
            dtDatos.Columns.Add("numero_cuenta", Type.GetType("System.String"))
            dtDatos.Columns.Add("procesado", Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo_periodo", Type.GetType("System.String"))
            Dim finiquitos As Boolean = False
            If nombre_archivo.ToLower.Contains("finiq") Then
                finiquitos = True
            Else
                finiquitos = False
            End If

            Dim referencia As String = ""
            Dim encabezado_ref As String = "SEM"
            Dim concecutivo As String = "0036"
            Dim tipo_periodo As String = ""

            'If nombre_archivo.ToLower.Contains("baja") Then
            '    Dim frm As New frmFiniquitosAdicionales
            '    frm.ShowDialog()
            'End If

            For Each row As DataRow In dtInformacion.Rows
                Dim dr As DataRow = dtDatos.NewRow
                dr("reloj") = row("reloj")

                dr("procesado") = _ano & " - " & _periodo

                Dim nom As String = row("nombres")
                dr("nombres") = nom.ToUpper.Replace("Ñ", "N")

                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")
                dr("cod_clase") = row("cod_clase")
                dr("tipo_periodo") = row("tipo_periodo")
                If tipo_periodo = "" Then
                    tipo_periodo = row("tipo_periodo")


                End If

               
                dr("numero_cuenta") = "00000000047630000000"
               


                Try
                    dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
                    dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                Catch ex As Exception

                End Try

                dr("ano") = _ano
                dr("periodo") = _periodo

                Dim nomina_ As Double = IIf(IsDBNull(row("NETO")), 0, row("NETO"))
                nomina_ -= IIf(IsDBNull(row("DEVFAH")), 0, row("DEVFAH"))
                nomina_ -= IIf(IsDBNull(row("OTPNOG")), 0, row("OTPNOG"))
                dr("nomina") = nomina_

                'Dim retiro_ As Double = IIf(IsDBNull(row("SANEFA")), 0, row("SANEFA"))
                Dim retiro_ As Double = IIf(IsDBNull(row("DEVFAH")), 0, row("DEVFAH"))
                dr("retiro") = retiro_

                Dim prestamo_ As Double = IIf(IsDBNull(row("OTPNOG")), 0, row("OTPNOG"))
                dr("prestamo") = prestamo_

                Dim monto_ As Double = nomina_ + retiro_ + prestamo_

                dr("monto") = monto_

                If monto_ > 0 Then
                    dtDatos.Rows.Add(dr)
                End If
            Next



            '************* 

            Dim ano_pago As String = ""
            Dim mes_pago As String = ""

            Dim fecha_envio As Date = Now
            Dim dtPeriodo As New DataTable
            If tipo_periodo.Trim = "Q" Then
                dtPeriodo = sqlExecute("select * from periodos_quincenal where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "TA")
                encabezado_ref = "QUI"
            Else
                dtPeriodo = sqlExecute("select * from periodos where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "TA")
                encabezado_ref = "SEM"
            End If
            If dtPeriodo.Rows.Count > 0 Then
                fecha_envio = Date.Parse(dtPeriodo.Rows(0)("fecha_pago"))
            Else
                Exit Sub
            End If

            ' fecha_envio = fecha_envio.AddDays(-1)

            Dim fecha_limite As Date = fecha_envio

            fecha_limite = fecha_envio.AddMonths(6)


            ano_pago = fecha_envio.Year.ToString.Substring(2, 2)
            mes_pago = fecha_envio.Month.ToString.PadLeft(2, "0")
            nombre_archivo = nombre_archivo & "S274000007.27405E01.10." & fecha_envio.Day.ToString.PadLeft(2, "0").Trim & mes_pago & ano_pago & ".000114407860.36.NOM_CFX.txt"

            Dim nombre As String = ""
            nombre = "//MD" & encabezado_ref & _periodo
            nombre = nombre.PadRight(20, Space(1))

            Dim encabezado As String = ""
            'encabezado &= "H001242946"
            'encabezado &= FechaSQL(fecha_envio)
            'encabezado &= "01"
            'encabezado &= nombre
            'encabezado &= "00"
            'encabezado &= Space(20)
            'encabezado &= "B"
            'encabezado &= Space(1291)
            Dim total_nuevo As Double = 0

            Dim oWrite As System.IO.StreamWriter
            Try

                Dim numcliente As String = ""
                Dim numcuenta As String = ""
                Dim datosbank As DataTable = sqlExecute("select * from cias where cod_comp = '610'")
                If datosbank.Rows.Count > 0 Then
                    numcliente = datosbank.Rows(0).Item("num_cliente")
                    numcuenta = datosbank.Rows(0).Item("num_cuenta")
                End If


                encabezado &= "1"  ' Tipo de registro 1
                encabezado &= numcliente.Trim.PadLeft(12, "0") 'Numero de identificacion del cliente
                encabezado &= ano_pago & mes_pago & fecha_envio.Day.ToString.PadLeft(2, "0").Trim 'Fecha envio
                encabezado &= concecutivo 'Secuencia del archivo
                encabezado &= "BRP QUERETARO SA DE CV".PadRight(36, Space(1)) 'Nombre de la empresa
                encabezado &= nombre 'Descripcion(referencia?)
                encabezado &= "15" 'Naturaleza del archivo
                encabezado &= "D" 'Version del layout
                encabezado &= "01" 'Tipo de cargo

                'Dim oWrite As System.IO.StreamWriter
                oWrite = File.CreateText(nombre_archivo)
                oWrite.WriteLine(encabezado)


                For Each irow In dtDatos.Rows
                    total_nuevo += irow("monto")
                Next

                Dim encabezado2 As String = ""
                Dim total1 As String = String.Format("{0:0.00}", total_nuevo).ToString.PadLeft(19, "0").Replace(".", "")



                encabezado2 &= "2" 'Tipo de registro 2
                encabezado2 &= "1" 'Tipo de operacion
                encabezado2 &= "001" 'Clave moneda
                encabezado2 &= total1 'Importe a cargar
                encabezado2 &= "01" 'Tipo de cuenta
                encabezado2 &= numcuenta.Trim.PadLeft(20, "0") 'Numero de cuenta
                encabezado2 &= dtDatos.Rows.Count.ToString.PadLeft(6, "0")
                oWrite.WriteLine(encabezado2)

                Dim total_empleados As Integer = 0
                Dim total_monto As Double = 0
                For Each row As DataRow In dtDatos.Rows

                    Dim linea As String = ""

                    linea &= "3"
                    linea &= "0"
                    linea &= "003"
                    linea &= "01"
                    Dim monto As String = String.Format("{0:0.00}", row("monto")).ToString.PadLeft(19, "0").Replace(".", "")
                    linea &= "001"
                    linea &= monto
                    linea &= "04"
                    linea &= row("numero_cuenta")
                    linea &= encabezado_ref & _periodo & _ano & Space(1) & row("reloj")

                    Dim nombre_p As String = row("nombres").ToString().Split(",")(0).Trim
                    Dim apaterno As String = row("nombres").ToString().Split(",")(1).Trim
                    Dim amaterno As String = row("nombres").ToString().Split(",")(2).Trim
                    Dim nombres As String = nombre_p & "," & apaterno & "/" & amaterno
                    linea &= nombres.PadRight(55, Space(1))

                    linea &= Space(35)
                    linea &= Space(35)
                    linea &= Space(35)
                    linea &= Space(35)

                    linea &= "0000"
                    linea &= "00"
                    linea &= Space(14)
                    linea &= Space(8)
                    linea &= Space(80)
                    linea &= Space(50)


                    total_empleados += 1
                    total_monto += row("monto")
                    oWrite.WriteLine(linea)

                Next

                Dim totales As String = ""
                totales &= "4"
                totales &= "001"
                totales &= total_empleados.ToString.PadLeft(6, "0")
                Dim prueba As Double = String.Format("{0:0.00}", total_monto).ToString.PadLeft(19, "0").Replace(".", "")
                totales &= String.Format("{0:0.00}", total_monto).ToString.PadLeft(19, "0").Replace(".", "")
                totales &= "000001"
                totales &= String.Format("{0:0.00}", total_monto).ToString.PadLeft(19, "0").Replace(".", "")

                oWrite.WriteLine(totales)
                oWrite.Close()


            Catch ex As Exception
                oWrite = Nothing
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub OrdenesPagosConvenio(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "", Optional _dias_a_sumar As String = "")
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("baja", Type.GetType("System.String"))

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))

            dtDatos.Columns.Add("nomina", Type.GetType("System.Double"))
            dtDatos.Columns.Add("retiro", Type.GetType("System.Double"))
            dtDatos.Columns.Add("prestamo", Type.GetType("System.Double"))

            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))
            dtDatos.Columns.Add("numero_cuenta", Type.GetType("System.String"))
            dtDatos.Columns.Add("procesado", Type.GetType("System.String"))
            dtDatos.Columns.Add("referencia", Type.GetType("System.String"))
            Dim finiquitos As Boolean = False
            If nombre_archivo.ToLower.Contains("finiq") Then
                finiquitos = True
            Else
                finiquitos = False
            End If

            Dim referencia As String = ""
            Dim encabezado_ref As String = "BAJAS PTU"
            Dim concecutivo As String = "0010"


            'If nombre_archivo.ToLower.Contains("baja") Then
            '    Dim frm As New frmFiniquitosAdicionales
            '    frm.ShowDialog()
            'End If

            For Each row As DataRow In dtInformacion.Rows


                Dim dr As DataRow = dtDatos.NewRow

                Dim dtreferencias As DataTable = sqlExecute("select * from referencias_pago where ano = '" & _ano & "' and periodo = '" & _periodo & "' and reloj = '" & row("reloj") & "'", "NOMINA")

                If dtreferencias.Rows.Count > 0 Then
                    dr("referencia") = dtreferencias.Rows(0).Item("referencia").ToString.Trim
                Else
                    Continue For
                End If
                dr("reloj") = row("reloj")

                dr("procesado") = _ano & " - " & _periodo

                Dim nom As String = row("nombres")
                dr("nombres") = nom.ToUpper.Replace("Ñ", "N")

                dr("cod_tipo") = row("cod_tipo")
                dr("nombre_tipo") = row("nombre_tipoemp")
                dr("cod_clase") = row("cod_clase")


                If row("cod_planta").ToString.Trim.Contains("001") Then
                    dr("numero_cuenta") = "00000000042090000000"
                Else
                    dr("numero_cuenta") = "00000000046010000000"
                End If


                Try
                    dr("alta") = IIf(IsDBNull(row("alta")), "", FechaSQL(row("alta")))
                    dr("baja") = IIf(IsDBNull(row("baja")), "", FechaSQL(row("baja")))
                Catch ex As Exception

                End Try

                dr("ano") = _ano
                dr("periodo") = _periodo

                Dim nomina_ As Double = IIf(IsDBNull(row("NETO")), 0, row("NETO"))
                nomina_ -= IIf(IsDBNull(row("DEVFAH")), 0, row("DEVFAH"))
                nomina_ -= IIf(IsDBNull(row("OTPNOG")), 0, row("OTPNOG"))
                dr("nomina") = nomina_

                'Dim retiro_ As Double = IIf(IsDBNull(row("SANEFA")), 0, row("SANEFA"))
                Dim retiro_ As Double = IIf(IsDBNull(row("DEVFAH")), 0, row("DEVFAH"))
                dr("retiro") = retiro_

                Dim prestamo_ As Double = IIf(IsDBNull(row("OTPNOG")), 0, row("OTPNOG"))
                dr("prestamo") = prestamo_

                Dim monto_ As Double = nomina_ + retiro_ + prestamo_

                dr("monto") = monto_

                If monto_ > 0 Then
                    dtDatos.Rows.Add(dr)
                End If
            Next



            '************* 

            Dim ano_pago As String = ""
            Dim mes_pago As String = ""

            Dim fecha_envio As Date = Now
            Dim dtPeriodo As DataTable = sqlExecute("select * from periodos where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "TA")
            If dtPeriodo.Rows.Count > 0 Then
                fecha_envio = Date.Parse(dtPeriodo.Rows(0)("fecha_pago")).AddDays(Int32.Parse(_dias_a_sumar))
            Else
                Exit Sub
            End If

            fecha_envio = fecha_envio.AddDays(-1)

            Dim fecha_limite As Date = fecha_envio

            fecha_limite = fecha_envio.AddMonths(6)


            ano_pago = fecha_envio.Year.ToString
            mes_pago = fecha_envio.Month.ToString.PadLeft(2, "0")
            nombre_archivo = nombre_archivo & "S274000009.27405E03.10." & fecha_envio.Day.ToString.PadLeft(2, "0").Trim & mes_pago & ano_pago.Substring(2, 2) & ".000114407860.05.OPR_CFX.txt"

            Dim nombre As String = ""
            nombre = "//MD" & encabezado_ref & " " & (Integer.Parse(_ano) - 1).ToString & "20"
            nombre = nombre.PadRight(20, Space(1))

            Dim encabezado As String = ""
            'encabezado &= "H001242946"
            'encabezado &= FechaSQL(fecha_envio)
            'encabezado &= "01"
            'encabezado &= nombre
            'encabezado &= "00"
            'encabezado &= Space(20)
            'encabezado &= "B"
            'encabezado &= Space(1291)
            Dim total_nuevo As Double = 0

            Dim oWrite As System.IO.StreamWriter
            Try
                encabezado &= "1"  ' Tipo de registro 1
                encabezado &= "000114407860" 'Numero de identificacion del cliente
                encabezado &= fecha_envio.Day.ToString.PadLeft(2, "0").Trim & mes_pago & ano_pago 'Fecha de pago
                encabezado &= concecutivo 'Secuencia del archivo
                encabezado &= "BRP QUERETARO SA de CV".PadRight(36, Space(1)) 'Nombre de la empresa
                encabezado &= nombre 'Descripcion(referencia?)
                encabezado &= "09" 'Naturaleza del archivo
                encabezado &= Space(40)
                encabezado &= "B" 'Version del layout
                encabezado &= "01" 'Tipo de cargo

                'Dim oWrite As System.IO.StreamWriter
                oWrite = File.CreateText(nombre_archivo)
                oWrite.WriteLine(encabezado)


                For Each irow In dtDatos.Rows
                    total_nuevo += irow("monto")
                Next

                Dim encabezado2 As String = ""
                Dim total1 As String = String.Format("{0:0.00}", total_nuevo).ToString.PadLeft(19, "0").Replace(".", "")

                encabezado2 &= "2" 'Tipo de registro 2
                encabezado2 &= "1" 'Tipo de operacion
                encabezado2 &= "001" 'Clave moneda
                encabezado2 &= total1 'Importe a cargar
                encabezado2 &= "01" 'Tipo de cuenta
                encabezado2 &= "0001" 'NumeroSucursal
                encabezado2 &= "00000000000004368019" 'Numero de cuenta
                encabezado2 &= Space(20)

                oWrite.WriteLine(encabezado2)

                Dim total_empleados As Integer = 0
                Dim total_monto As Double = 0
                For Each row As DataRow In dtDatos.Rows

                    Dim linea As String = ""
                    total_empleados += 1
                    linea &= "3"
                    linea &= "07"
                    linea &= "0870"
                    linea &= "48".PadRight(16, Space(1))
                    Dim monto As String = String.Format("{0:0.00}", row("monto")).ToString.PadLeft(20, "0")
                    linea &= monto
                    linea &= Space(34)
                    Dim apaterno As String = row("nombres").ToString().Split(",")(0).Trim
                    Dim amaterno As String = row("nombres").ToString().Split(",")(1).Trim
                    Dim nombre_p As String = row("nombres").ToString().Split(",")(2).Trim
                    Dim nombres As String = nombre_p & " " & apaterno & " " & amaterno
                    linea &= nombres.PadRight(55, Space(1))
                    linea &= Space(40)
                    linea &= "0002"
                    linea &= Space(6)
                    linea &= "001"
                    linea &= "1"
                    linea &= row("referencia")
                    linea &= Space(8)
                    linea &= "1"
                    linea &= Space(9)
                    linea &= "2"
                    linea &= Space(9)
                    linea &= "3112" & _ano
                    linea &= Space(13)
                    linea &= "000000000000"
                    linea &= "99"
                    linea &= Space(31)
                    linea &= "0000"



                    total_monto += row("monto")
                    oWrite.WriteLine(linea)

                Next

                Dim totales As String = ""
                totales &= "4"
                totales &= "001"
                totales &= total_empleados.ToString.PadLeft(6, "0")
                Dim prueba As Double = String.Format("{0:0.00}", total_monto).ToString.PadLeft(19, "0").Replace(".", "")
                totales &= String.Format("{0:0.00}", total_monto).ToString.PadLeft(19, "0").Replace(".", "")
                totales &= "000001"
                totales &= String.Format("{0:0.00}", total_monto).ToString.PadLeft(19, "0").Replace(".", "")

                oWrite.WriteLine(totales)
                oWrite.Close()


            Catch ex As Exception
                oWrite = Nothing
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub NominaProExcel(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ocultar_detalle As Boolean, ocultar_totales_depto As Boolean, nombre_archivo As String, FromCondensado As Boolean, PathSave As String, _anio As String, _periodo As String, _tipoPer As String)
        Try
            fromCondFinanzas = False ' Indica que no viene del condensando de finanzas

            If _tipoPer = "S" Then _tipoPer = "Semanal" Else If _tipoPer = "C" Then _tipoPer = "Catorcenal"
            Dim anioPerTipo As String = _anio & "_" & _periodo & "_" & _tipoPer

            '---Depurar dtInformacion, dejando solo a los empleados que estan en MovimientosPro
            dtInformacion.Columns.Add("aplica", GetType(System.String))
            Dim dtRjMovsPro As DataTable = sqlExecute("SELECT DISTINCT RELOJ FROM movimientos_pro", "NOMINA")
            If Not (dtRjMovsPro.Columns.Contains("Error") And dtRjMovsPro.Rows.Count > 0) Then
                Dim pos As Integer = 0
                For Each dr As DataRow In dtInformacion.Rows
                    dtInformacion.Rows(pos)("aplica") = "n"
                    pos += 1
                Next

                For Each dr1 As DataRow In dtRjMovsPro.Rows
                    Dim rj As String = ""
                    Dim myRow() As DataRow
                    Try : rj = dr1("RELOJ").ToString.Trim : Catch ex As Exception : rj = "" : End Try

                    If (dtInformacion.Select("reloj='" & rj & "'").Count > 0) Then
                        myRow = dtInformacion.Select("reloj='" & rj & "'")
                        myRow(0)("aplica") = "s"
                    End If

                Next
                '--Eliminar masivamente los que no apliquen
                Dim dElimina() As DataRow
                dElimina = dtInformacion.Select("aplica ='n'")
                For Each del As DataRow In dElimina
                    dtInformacion.Rows.Remove(del)
                Next

            End If
            dtInformacion.Columns.Remove("aplica")
            '---Ends Depura dtInformacion

            '----Agregar los movimientos imss a dtInformacion
            Dim dtMovsImssPro As DataTable = sqlExecute("select * from movimientos_imss_pro order by reloj asc", "nomina")
            If (Not dtMovsImssPro.Columns.Contains("Error") And dtMovsImssPro.Rows.Count > 0) Then

                For Each drMovImss As DataRow In dtMovsImssPro.Rows
                    Dim reloj As String = "", concepto As String = "", monto As Double = 0.0
                    Try : reloj = drMovImss("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                    Try : concepto = drMovImss("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                    Try : monto = Double.Parse(drMovImss("monto")) : Catch ex As Exception : monto = 0.0 : End Try

                    Dim drRowFind() As DataRow
                    If (dtInformacion.Select("reloj='" & reloj & "'").Count > 0) Then
                        drRowFind = dtInformacion.Select("reloj='" & reloj & "'")
                        drRowFind(0)(concepto) = monto
                    End If

                Next

            End If

            '----Ends agregar movsImss



            dtDatos = New DataTable

            Dim dtEncabezados As New DataTable
            dtEncabezados.Columns.Add("orden", Type.GetType("System.Int32"))
            dtEncabezados.Columns.Add("campo")
            dtEncabezados.Columns.Add("encabezado")
            dtEncabezados.Columns.Add("cuenta")
            dtEncabezados.Columns.Add("tipo")
            dtEncabezados.Columns.Add("enfasis")
            dtEncabezados.Columns.Add("bgcolor")

            ' Columnas principales que se mostraran 
            dtDatos.Columns.Add("totales")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("reloj_alterno")
            dtDatos.Columns.Add("sactual")
            dtDatos.Columns.Add("integrado")
            dtDatos.Columns.Add("cod_costos")


            Dim dtPeriodos As DataTable = New DataTable
            dtPeriodos.Columns.Add("ano")
            dtPeriodos.Columns.Add("periodo")
            dtPeriodos.Columns.Add("tipo_periodo")
            dtPeriodos.PrimaryKey = New DataColumn() {dtPeriodos.Columns("ano"), dtPeriodos.Columns("periodo"), dtPeriodos.Columns("tipo_periodo")}

            Dim titulo_codigo As String = ""
            Dim titulo_nombre As String = ""

            If ocultar_detalle = True Then
                titulo_codigo = "Centro de costos"
                titulo_nombre = "Descripción"
            Else
                titulo_codigo = "Número de empleado"
                titulo_nombre = "Nombre completo"
            End If

            dtEncabezados.Rows.Add({1, "reloj", titulo_codigo, "", "", 0, "na"})
            dtEncabezados.Rows.Add({2, "nombres", titulo_nombre, "", "", 0, "na"})

            Dim siguiente_encabezado As Integer = 3

            If Not ocultar_detalle Then
                dtEncabezados.Rows.Add({3, "reloj_alterno", "Número SAP", "", "", 0, "na"})
                dtEncabezados.Rows.Add({4, "sactual", "Sueldo", "", "", 0, "na"}) ' Columnas que se mostrarán
                dtEncabezados.Rows.Add({5, "integrado", "Int.Imss", "", "", 0, "na"})
                siguiente_encabezado = 6
            End If

            Dim dtGruposConceptos As New DataTable

            dtGruposConceptos.Columns.Add("orden", Type.GetType("System.Int32"))
            dtGruposConceptos.Columns.Add("nombre")
            dtGruposConceptos.Columns.Add("filtro")
            dtGruposConceptos.Columns.Add("enfasis", Type.GetType("System.Int32"))
            dtGruposConceptos.Columns.Add("bgcolor")

            '---Orden a mostrar en prioridad para los conceptos que va conformar el excel
            dtGruposConceptos.Rows.Add({1, "Días/horas", "cod_naturaleza = 'I'  and activo = '1' and concepto in('HRSNOR','DIASPA','HRSEX2','HRSEX3','HRSFES','HRSFEL','HRSDOM','DIASVA','DIASPV','DIASAG')", 0, "nan"})

            dtGruposConceptos.Rows.Add({2, "Percepciones", "cod_naturaleza = 'P'  and activo = '1' and concepto<>'BONDES'", 0, "nan"})
            dtGruposConceptos.Rows.Add({3, "Aportación FAH Empresa", "cod_naturaleza = 'I'  and activo = '1' and concepto='APOCIA'", 0, "nan"})
            dtGruposConceptos.Rows.Add({4, "Total de Percepciones", "concepto = 'TOTPER'", 1, "nan"})

            dtGruposConceptos.Rows.Add({5, "Bono de despensa", "concepto= 'BONDES'", 1, "nan"}) ' Ya lo incluye dentro de las percepciones

            dtGruposConceptos.Rows.Add({6, "Deducciones", "cod_naturaleza = 'D' and activo = '1'", 0, "nan"})
            dtGruposConceptos.Rows.Add({7, "Total de Deducciones", "concepto = 'TOTDED'", 1, "nan"})

            dtGruposConceptos.Rows.Add({8, "Neto", "concepto= 'NETO'", 1, "nan"})

            dtGruposConceptos.Rows.Add({9, "Obligaciones", "cod_naturaleza = 'O'  and activo = '1' and concepto not in('TOTPAT','TOTASE')", 0, "nan"})
            dtGruposConceptos.Rows.Add({10, "Total de Obligaciones", "cod_naturaleza = 'O'  and activo = '1' and concepto in('TOTPAT','TOTASE')", 1, "nan"})

            Dim dtCuentas As DataTable = sqlExecute("select distinct concepto, cuenta from cuentas", "nomina")

            For Each row_grupo As DataRow In dtGruposConceptos.Select("", "orden")
                Dim dtConceptosGrupo As DataTable = sqlExecute("select * from conceptos where " & row_grupo("filtro") & " order by prioridad", "nomina") ' Se mostrarán por orden de prioridad (conceptos.prioridad)
                For Each row_conceptos As DataRow In dtConceptosGrupo.Rows

                    Dim cuenta_contable As String = "-"
                    Dim concepto_codigo As String = RTrim(row_conceptos("concepto")).ToLower
                    Dim concepto_nombre As String = RTrim(row_conceptos("nombre"))


                    Try
                        For Each row_cuenta As DataRow In dtCuentas.Select("concepto = '" & concepto_codigo & "'")
                            cuenta_contable = row_cuenta("cuenta")
                        Next
                    Catch ex As Exception

                    End Try

                    dtDatos.Columns.Add(concepto_codigo)
                    dtEncabezados.Rows.Add({siguiente_encabezado, concepto_codigo, concepto_nombre, cuenta_contable, "num", row_grupo("enfasis"), row_grupo("bgcolor")})
                    siguiente_encabezado += 1
                Next
            Next

            '*************************************



            Dim frm As New frmTrabajando
            frm.lblAvance.Text = ""
            frm.Show()

            Dim dtCentrosDeCostos As DataTable = sqlExecute("select * from c_costos")

            Dim drow_total_general As DataRow = dtDatos.NewRow
            drow_total_general("totales") = 3
            drow_total_general("reloj") = "Total Gral."

            '  For Each row_cc As DataRow In dtCentrosDeCostos.Rows ' Lo agrupa por Centro Costos
            For Each row_cc As DataRow In dtInformacion.Rows

                '   frm.lblAvance.Text = row_cc("centro_costos")
                frm.lblAvance.Text = row_cc("reloj")
                Application.DoEvents()

                'If dtInformacion.Select("cod_costos = '" & row_cc("centro_costos") & "'").Length > 0 Then

                Dim drow_grupo As DataRow = dtDatos.NewRow
                drow_grupo("totales") = 2
                '   drow_grupo("reloj") = row_cc("centro_costos")
                drow_grupo("reloj") = row_cc("reloj")
                '   drow_grupo("nombres") = row_cc("nombre")
                drow_grupo("nombres") = row_cc("nombres")

                If ocultar_totales_depto = False Then
                    dtDatos.Rows.Add(drow_grupo)
                End If


                Dim drow_totales As DataRow = dtDatos.NewRow
                drow_totales("totales") = 1
                drow_totales("reloj") = "Total Depto"

                drow_totales("totales") = 1

                Dim drow_vacia As DataRow = dtDatos.NewRow
                drow_vacia("totales") = 1


                '  For Each row_informacion As DataRow In dtInformacion.Select("cod_costos = '" & row_cc("centro_costos") & "' AND (TOTPER>0 OR BONDES>0)") ' &&_AOS 15/01/2020 - Solo incluir a empleados con percepcion > 0 o BONDES> 0
                '   For Each row_informacion As DataRow In dtInformacion.Select("cod_costos = '" & row_cc("centro_costos") & "'") ' &&_Incluir a todos los empleados aunque tengan TOTPER ,TOTDED ó NETO = 0
                Try
                    Dim drow_periodo As DataRow = dtPeriodos.NewRow
                    'drow_periodo("ano") = row_informacion("ano")
                    'drow_periodo("periodo") = row_informacion("periodo")
                    'drow_periodo("tipo_periodo") = row_informacion("tipo_periodo")

                    drow_periodo("ano") = row_cc("ano")
                    drow_periodo("periodo") = row_cc("periodo")
                    drow_periodo("tipo_periodo") = row_cc("tipo_periodo")
                    dtPeriodos.Rows.Add(drow_periodo)

                Catch ex As Exception

                End Try

                Application.DoEvents()

                Dim drow As DataRow = dtDatos.NewRow
                drow("totales") = 0

                '---AOS :: Here es donde veo que tarda mas
                For Each row_encabezado As DataRow In dtEncabezados.Rows ' Evalua y da el valor para cada uno de los campos a ingresar en el excel

                    Dim campo_ As String = row_encabezado("campo")

                    Try
                        '  Dim valor As String = row_informacion(row_encabezado("campo")) 'Es el valor de acuerdo al campo que esta buscando
                        Dim valor As String = row_cc(row_encabezado("campo")) 'Es el valor de acuerdo al campo que esta buscando

                        drow(campo_) = valor

                        '  Dim h As String = drow(campo_)

                        If row_encabezado("tipo") = "num" Then
                            If IsDBNull(drow(campo_)) Then
                                drow(campo_) = 0
                            End If

                            If ocultar_detalle = True Then
                                drow_grupo(campo_) = Double.Parse(IIf(IsDBNull(drow_grupo(campo_)), 0, drow_grupo(campo_))) + Double.Parse(drow(campo_))
                            Else
                                drow_totales(campo_) = Double.Parse(IIf(IsDBNull(drow_totales(campo_)), 0, drow_totales(campo_))) + Double.Parse(drow(campo_))
                            End If

                            drow_total_general(campo_) = Double.Parse(IIf(IsDBNull(drow_total_general(campo_)), 0, drow_total_general(campo_))) + Double.Parse(drow(campo_))

                        End If

                    Catch ex As Exception
                        drow(campo_) = 0
                    End Try

                Next

                dtDatos.Rows.Add(drow)
                '   Next

                If ocultar_totales_depto = False Then
                    dtDatos.Rows.Add(drow_totales)
                    dtDatos.Rows.Add(drow_vacia)
                End If

                '  End If
            Next

            dtDatos.Rows.Add(drow_total_general)

            ActivoTrabajando = False
            frm.Close()

            Dim archivo As ExcelPackage = New ExcelPackage()
            Dim wb As ExcelWorkbook = archivo.Workbook
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("nomina")


            Dim x As Integer = 4
            Dim y As Integer = 1

            If nombre_archivo = "Nómina centro de costos" Then
                x = 5
            End If

            hoja_excel.Row(x).Style.Font.Bold = True
            hoja_excel.Row(x - 1).Style.Font.Italic = True



            If nombre_archivo = "Nómina centro de costos" Then
                hoja_excel.Row(x - 2).Style.Font.Bold = True
                hoja_excel.Row(x - 2).Style.Font.Italic = True
            End If


            For Each row_encabezado As DataRow In dtEncabezados.Select("", "orden")

                If row_encabezado("tipo") = "num" Then
                    If nombre_archivo = "Nómina centro de costos" Then
                        hoja_excel.Cells(x - 2, y).Value = row_encabezado("campo")
                        hoja_excel.Cells(x - 2, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x - 2, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)

                        hoja_excel.Cells(x - 1, y).Value = row_encabezado("cuenta")
                        hoja_excel.Cells(x - 1, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x - 1, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                    Else
                        hoja_excel.Cells(x - 1, y).Value = row_encabezado("campo")
                        hoja_excel.Cells(x - 1, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x - 1, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                    End If

                End If

                hoja_excel.Cells(x, y).Value = row_encabezado("encabezado")
                hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)


                y += 1
            Next

            x += 1
            y = 1

            If nombre_archivo = "Nómina detalle" Then
                dtDatos = dtDatos.Select("", "reloj").CopyToDataTable

                Try
                    dtDatos = dtDatos.Select("totper <> 0 or totded <> 0 or bondes <> 0", "reloj").CopyToDataTable
                Catch ex As Exception

                End Try

            End If

            For Each row_datos As DataRow In dtDatos.Rows

                If row_datos("totales") > IIf(ocultar_detalle, 2, 0) Then
                    hoja_excel.Row(x).Style.Font.Bold = True
                End If

                If ocultar_detalle Then
                    If row_datos("totales") < 2 Then
                        Continue For
                    End If
                End If

                For Each row_encabezados As DataRow In dtEncabezados.Select("", "orden")

                    Dim valor As String = IIf(IsDBNull(row_datos(row_encabezados("campo"))), "", row_datos(row_encabezados("campo")))

                    If row_encabezados("tipo") = "num" And valor <> "" Then
                        hoja_excel.Cells(x, y).Value = Double.Parse(row_datos(row_encabezados("campo")))
                        hoja_excel.Cells(x, y).Style.Numberformat.Format = "#,##0.00"
                    Else
                        hoja_excel.Cells(x, y).Value = row_datos(row_encabezados("campo"))
                    End If

                    If row_encabezados("enfasis") = 1 Then
                        hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                    End If

                    y += 1
                Next
                x += 1
                y = 1
            Next

            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()


            Dim periodos_titulo As String = ""
            For Each row_periodo As DataRow In dtPeriodos.Rows
                periodos_titulo &= row_periodo("ano") & "-" & row_periodo("periodo") & ", "
            Next
            periodos_titulo &= "_"
            periodos_titulo = periodos_titulo.Replace(", _", "")

            hoja_excel.Cells(1, 1).Value = "CTE"
            hoja_excel.Cells(1, 1).Style.Font.Bold = True
            hoja_excel.Cells(1, 1).Style.Font.Size = 12

            '   hoja_excel.Cells(2, 1).Value = nombre_archivo & " " & periodos_titulo
            hoja_excel.Cells(2, 1).Value = nombre_archivo & " " & anioPerTipo
            hoja_excel.Cells(2, 1).Style.Font.Bold = True

            Dim sfd As New SaveFileDialog
            sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            '   sfd.FileName = "OSC " & nombre_archivo & ".xlsx"
            Dim NameFile As String = ""

            If fromCondFinanzas Then NameFile = "CTE - FINANZAS-" & nombre_archivo & anioPerTipo Else NameFile = "CTE " & nombre_archivo & "_" & anioPerTipo
            sfd.FileName = NameFile & ".xlsx"
            sfd.Filter = "Archivo excel (xlsx)|*.xlsx"


            If (FromCondensado And PathSave.Trim <> "") Then  '- Si viene del condensado
                sfd.InitialDirectory = PathSave
                '   sfd.FileName = "OSC " & nombre_archivo & ".xlsx"
                If fromCondFinanzas Then NameFile = "CTE - FINANZAS-" & nombre_archivo Else NameFile = "CTE " & nombre_archivo
                sfd.FileName = NameFile & ".xlsx"
                sfd.Filter = "Archivo excel (xlsx)|*.xlsx"
                archivo.SaveAs(New System.IO.FileInfo(PathSave & sfd.FileName))
                GoTo Saltar1
            End If

            If sfd.ShowDialog() = DialogResult.OK Then
                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
            End If
Saltar1:
            System.Diagnostics.Process.Start(sfd.FileName)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub DifConcCalcNom(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            dtDatos = New DataTable

            dtDatos.Columns.Add("ano", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo", Type.GetType("System.String"))
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("concepto", Type.GetType("System.String"))
            dtDatos.Columns.Add("descripcion", Type.GetType("System.String"))
            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))
            dtDatos.Columns.Add("tipo_periodo", Type.GetType("System.String"))

            For Each row As DataRow In dtInformacion.Rows
                Dim dr As DataRow = dtDatos.NewRow
                Dim ano As String = "", periodo As String = "", reloj As String = "", concepto As String = "", descripcion As String = "", monto As Double = 0.0, tipo_periodo As String = ""
                Try : ano = row("ano").ToString.Trim : Catch ex As Exception : ano = "" : End Try
                Try : periodo = row("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
                Try : reloj = row("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                Try : concepto = row("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                Try : descripcion = row("descripcion").ToString.Trim : Catch ex As Exception : descripcion = "" : End Try
                Try : monto = Double.Parse(row("monto")) : Catch ex As Exception : monto = 0 : End Try
                Try : tipo_periodo = row("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_periodo = "" : End Try

                If (tipo_periodo = "S") Then tipo_periodo = "Semanal"
                If (tipo_periodo = "C") Then tipo_periodo = "Catorcenal"


                dr("ano") = ano
                dr("periodo") = periodo
                dr("reloj") = reloj
                dr("concepto") = concepto
                dr("descripcion") = descripcion
                dr("monto") = monto
                dr("tipo_periodo") = tipo_periodo
                dtDatos.Rows.Add(dr)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub AcuseFiniquito(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim TOTPER As Double = 0
        Dim TOTDED As Double = 0
        Dim NETO As Double = 0
        Dim EsError As Boolean = False

        Try

            dtDatos = New DataTable

            dtDatos.Columns.Add("folio", Type.GetType("System.String"))
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nomemp", Type.GetType("System.String"))
            dtDatos.Columns.Add("concepto", Type.GetType("System.String"))
            dtDatos.Columns.Add("naturaleza", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre", Type.GetType("System.String"))
            dtDatos.Columns.Add("prioridad", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("recibido", Type.GetType("System.String"))
            dtDatos.Columns.Add("importe", Type.GetType("System.Double"))
            dtDatos.Columns.Add("fin", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_actual", Type.GetType("System.String"))
            dtDatos.Columns.Add("TOTPER", Type.GetType("System.Double"))
            dtDatos.Columns.Add("TOTDED", Type.GetType("System.Double"))
            dtDatos.Columns.Add("NETO", Type.GetType("System.Double"))

            For Each drRow As DataRow In dtInformacion.Select("", "folio")

                Try : TOTPER = dtInformacion.Select("concepto = 'TOTPER' and reloj = '" & drRow("reloj") & "' and folio = '" & drRow("folio") & "'")(0).Item("importe") : Catch ex As Exception : ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nomina.vb", ex.HResult, ex.Message) : EsError = True : End Try
                If EsError Then Exit For
                Try : TOTDED = dtInformacion.Select("concepto = 'TOTDED' and reloj = '" & drRow("reloj") & "' and folio = '" & drRow("folio") & "'")(0).Item("importe") : Catch ex As Exception : ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nomina.vb", ex.HResult, ex.Message) : EsError = True : End Try
                If EsError Then Exit For
                Try : NETO = dtInformacion.Select("concepto = 'NETO' and reloj = '" & drRow("reloj") & "' and folio = '" & drRow("folio") & "'")(0).Item("importe") : Catch ex As Exception : ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nomina.vb", ex.HResult, ex.Message) : EsError = True : End Try
                If EsError Then Exit For

                Dim drAgregar As DataRow = dtDatos.NewRow

                drAgregar("folio") = drRow("folio")
                drAgregar("reloj") = drRow("reloj")
                drAgregar("nomemp") = Trim(IIf(IsDBNull(drRow("apaterno")), "", drRow("apaterno")).ToString.Trim & " " & _
                        IIf(IsDBNull(drRow("amaterno")), "", drRow("amaterno")).ToString.Trim & " " & IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")).ToString.Trim)
                drAgregar("concepto") = drRow("concepto")
                drAgregar("naturaleza") = drRow("naturaleza")
                drAgregar("nombre") = Trim(IIf(IsDBNull(drRow("descripcion")), "", drRow("descripcion")))
                drAgregar("prioridad") = IIf(IsDBNull(drRow("prioridad")), 999, drRow("prioridad"))
                drAgregar("recibido") = ConvNvo(CDec(NETO)).ToLower & " M.N."
                drAgregar("importe") = drRow("importe")
                drAgregar("fin") = FechaLetra(CDate(drRow("fin"))).Replace("-", " de ")
                drAgregar("fecha_actual") = FechaLetra(CDate(drRow("fecha_actual"))).Replace("-", " de ")
                drAgregar("TOTPER") = TOTPER
                drAgregar("TOTDED") = TOTDED
                drAgregar("NETO") = NETO

                dtDatos.Rows.Add(drAgregar)
            Next


            If EsError Then dtDatos = New DataTable


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub ConvenioFiniquito(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim TOTPER As Double = 0
        Dim TOTDED As Double = 0
        Dim NETO As Double = 0
        Dim EsError As Boolean = False

        Try

            dtDatos = New DataTable


            dtDatos.Columns.Add("folio", Type.GetType("System.String"))
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nomemp", Type.GetType("System.String"))
            dtDatos.Columns.Add("num_cheque", Type.GetType("System.String"))
            dtDatos.Columns.Add("concepto_per", Type.GetType("System.String"))
            dtDatos.Columns.Add("nom_con_per", Type.GetType("System.String"))
            dtDatos.Columns.Add("prioridad_per", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("importe_per", Type.GetType("System.Double"))

            dtDatos.Columns.Add("TOTPER", Type.GetType("System.Double"))

            dtDatos.Columns.Add("concepto_ded", Type.GetType("System.String"))
            dtDatos.Columns.Add("nom_con_ded", Type.GetType("System.String"))
            dtDatos.Columns.Add("prioridad_ded", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("importe_ded", Type.GetType("System.Double"))

            dtDatos.Columns.Add("TOTDED", Type.GetType("System.Double"))

            dtDatos.Columns.Add("NETO", Type.GetType("System.Double"))
            dtDatos.Columns.Add("recibido", Type.GetType("System.String"))


            dtDatos.Columns.Add("fin", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_actual", Type.GetType("System.String"))
            dtDatos.Columns.Add("alta", Type.GetType("System.String"))

            dtDatos.Columns.Add("puesto", Type.GetType("System.String"))
            dtDatos.Columns.Add("area", Type.GetType("System.String"))
            dtDatos.Columns.Add("horario", Type.GetType("System.String"))

            dtDatos.Columns.Add("per_mensual", Type.GetType("System.String"))


            Dim dtFolios As DataTable = dtInformacion 'dtInformacion.DefaultView.ToTable(True, "reloj", "folio", "nomemp")

            For Each drFolios As DataRow In dtFolios.Rows

                Dim drAgregar As DataRow = Nothing
                Dim numPer As Integer = -1
                Dim numDed As Integer = -1
                Dim i As Integer = 0

                Dim dtPercepciones As DataTable = sqlExecute("select movimientos_calculo.*,rtrim(conceptos.NOMBRE) as 'nombre' from movimientos_calculo left join conceptos on movimientos_calculo.Concepto = conceptos.CONCEPTO where folio = '" & drFolios("folio") & "' and conceptos.COD_NATURALEZA = 'P'", "NOMINA")
                Dim dtDeducciones As DataTable = sqlExecute("select movimientos_calculo.*,rtrim(conceptos.NOMBRE) as 'nombre' from movimientos_calculo left join conceptos on movimientos_calculo.Concepto = conceptos.CONCEPTO where folio = '" & drFolios("folio") & "' and conceptos.COD_NATURALEZA = 'D'", "NOMINA")

                If Not dtPercepciones.Columns.Contains("ERROR") Then

                    numPer = dtPercepciones.Rows.Count

                Else
                    EsError = True
                    Exit Sub
                End If


                If Not dtDeducciones.Columns.Contains("ERROR") Then

                    numDed = dtDeducciones.Rows.Count

                Else
                    EsError = True
                    Exit Sub
                End If

                If numPer > numDed Then
                    i = numPer
                ElseIf numDed > numPer Then
                    i = numDed
                Else
                    i = numPer
                End If

                For x As Integer = 1 To i

                    drAgregar = dtDatos.NewRow

                    drAgregar("folio") = drFolios("folio")
                    drAgregar("reloj") = drFolios("reloj")
                    drAgregar("nomemp") = Trim(IIf(IsDBNull(drFolios("apaterno")), "", drFolios("apaterno")).ToString.Trim & " " & _
                        IIf(IsDBNull(drFolios("amaterno")), "", drFolios("amaterno")).ToString.Trim & " " & IIf(IsDBNull(drFolios("nombre")), "", drFolios("nombre")).ToString.Trim)
                    drAgregar("num_cheque") = Trim(IIf(IsDBNull(drFolios("num_cheque")), "SIN ESPECIFICAR", drFolios("num_cheque"))).ToUpper

                    Dim formatoFecha As String = ""
                    formatoFecha = FechaLetra(CDate(drFolios("fin")))
                    drAgregar("fin") = formatoFecha.Split("-")(0) & " de " & formatoFecha.Split("-")(1) & " " & formatoFecha.Split("-")(2)
                    formatoFecha = FechaLetra(CDate(drFolios("fecha_actual")))
                    drAgregar("fecha_actual") = formatoFecha.Split("-")(0) & " de " & formatoFecha.Split("-")(1) & " " & formatoFecha.Split("-")(2)

                    formatoFecha = FechaLetra(CDate(drFolios("alta")))
                    drAgregar("alta") = formatoFecha.Split("-")(0) & " de " & formatoFecha.Split("-")(1) & " " & formatoFecha.Split("-")(2)
                    drAgregar("puesto") = Trim(IIf(IsDBNull(drFolios("puesto")), "SIN ESPECIFICAR", drFolios("puesto"))).ToUpper
                    drAgregar("area") = Trim(IIf(IsDBNull(drFolios("area")), "SIN ESPECIFICAR", drFolios("area"))).ToUpper
                    drAgregar("horario") = Trim(IIf(IsDBNull(drFolios("horario")), "SIN ESPECIFICAR", drFolios("horario")))
                    Dim percepcion_mensual As Decimal = Decimal.Parse(drFolios("sactual").ToString) * 30.4D
                    drAgregar("per_mensual") = FormatCurrency(percepcion_mensual, 2).ToString & " (" & ConvNvo(CDec(percepcion_mensual)).ToUpper & " MONEDA NACIONAL)"

                    dtDatos.Rows.Add(drAgregar)
                Next

                If Not dtDatos.Rows.Count > 0 Then
                    Exit Sub
                End If

                Dim dtMontoNETO As DataTable = sqlExecute("select monto from movimientos_calculo where folio = '" & drFolios("folio") & "' and concepto  ='NETO'", "NOMINA")
                Try : NETO = dtMontoNETO.Rows(0).Item("monto") : Catch ex As Exception : EsError = True : Exit For : End Try
                Dim letraNEto As String = FormatCurrency(NETO, 2) & " (" & ConvNvo(CDec(NETO)).ToUpper & " M.N.)"


                i = 0

                Dim dtMontoPER As DataTable = sqlExecute("select monto from movimientos_calculo where folio = '" & drFolios("folio") & "' and concepto  ='TOTPER'", "NOMINA")
                Try : TOTPER = dtMontoPER.Rows(0).Item("monto") : Catch ex As Exception : EsError = True : Exit For : End Try

                For Each drPer As DataRow In dtPercepciones.Rows

                    Dim drDatos As DataRow = dtDatos.Rows(i)

                    drDatos("concepto_per") = drPer("concepto")
                    drDatos("nom_con_per") = drPer("nombre")
                    drDatos("prioridad_per") = drPer("prioridad")
                    drDatos("importe_per") = drPer("monto")
                    drDatos("TOTPER") = TOTPER
                    drDatos("NETO") = NETO
                    drDatos("recibido") = letraNEto
                    i = i + 1

                Next

                i = 0
                Dim dtMontoDED As DataTable = sqlExecute("select monto from movimientos_calculo where folio = '" & drFolios("folio") & "' and concepto  ='TOTDED'", "NOMINA")
                Try : TOTDED = dtMontoDED.Rows(0).Item("monto") : Catch ex As Exception : EsError = True : Exit For : End Try
                For Each drDed As DataRow In dtDeducciones.Rows

                    Dim drDatos As DataRow = dtDatos.Rows(i)

                    drDatos("concepto_ded") = drDed("concepto")
                    drDatos("nom_con_ded") = drDed("nombre")
                    drDatos("prioridad_ded") = drDed("prioridad")
                    drDatos("importe_ded") = drDed("monto")
                    drDatos("TOTDED") = TOTDED
                    drDatos("NETO") = NETO
                    drDatos("recibido") = letraNEto
                    i = i + 1

                Next

            Next

            If EsError Then dtDatos = New DataTable

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    '== Convenio de finiquito adicional                 10mar22             Ernesto
    Public Sub ConvenioFiniquitoAdicional(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim TOTPER As Double = 0
        Dim TOTDED As Double = 0
        Dim NETO As Double = 0
        Dim EsError As Boolean = False

        Try

            dtDatos = New DataTable


            dtDatos.Columns.Add("folio", Type.GetType("System.String"))
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nomemp", Type.GetType("System.String"))
            dtDatos.Columns.Add("num_cheque", Type.GetType("System.String"))
            dtDatos.Columns.Add("concepto_per", Type.GetType("System.String"))
            dtDatos.Columns.Add("nom_con_per", Type.GetType("System.String"))
            dtDatos.Columns.Add("prioridad_per", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("importe_per", Type.GetType("System.Double"))

            dtDatos.Columns.Add("TOTPER", Type.GetType("System.Double"))

            dtDatos.Columns.Add("concepto_ded", Type.GetType("System.String"))
            dtDatos.Columns.Add("nom_con_ded", Type.GetType("System.String"))
            dtDatos.Columns.Add("prioridad_ded", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("importe_ded", Type.GetType("System.Double"))

            dtDatos.Columns.Add("TOTDED", Type.GetType("System.Double"))

            dtDatos.Columns.Add("NETO", Type.GetType("System.Double"))
            dtDatos.Columns.Add("recibido", Type.GetType("System.String"))


            dtDatos.Columns.Add("fin", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_actual", Type.GetType("System.String"))
            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("puesto", Type.GetType("System.String"))
            dtDatos.Columns.Add("area", Type.GetType("System.String"))
            dtDatos.Columns.Add("horario", Type.GetType("System.String"))

            dtDatos.Columns.Add("imss", Type.GetType("System.String"))
            dtDatos.Columns.Add("curp", Type.GetType("System.String"))
            dtDatos.Columns.Add("rfc", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_nac", Type.GetType("System.String"))
            dtDatos.Columns.Add("direccion", Type.GetType("System.String"))
            dtDatos.Columns.Add("edo_civil", Type.GetType("System.String"))

            dtDatos.Columns.Add("per_mensual", Type.GetType("System.String"))


            Dim dtFolios As DataTable = dtInformacion 'dtInformacion.DefaultView.ToTable(True, "reloj", "folio", "nomemp")

            For Each drFolios As DataRow In dtFolios.Rows

                Dim drAgregar As DataRow = Nothing
                Dim numPer As Integer = -1
                Dim numDed As Integer = -1
                Dim i As Integer = 0

                Dim dtPercepciones As DataTable = sqlExecute("select movimientos_calculo.*,rtrim(conceptos.NOMBRE) as 'nombre' from movimientos_calculo left join conceptos on movimientos_calculo.Concepto = conceptos.CONCEPTO where folio = '" & drFolios("folio") & "' and conceptos.COD_NATURALEZA = 'P'", "NOMINA")
                Dim dtDeducciones As DataTable = sqlExecute("select movimientos_calculo.*,rtrim(conceptos.NOMBRE) as 'nombre' from movimientos_calculo left join conceptos on movimientos_calculo.Concepto = conceptos.CONCEPTO where folio = '" & drFolios("folio") & "' and conceptos.COD_NATURALEZA = 'D'", "NOMINA")

                If Not dtPercepciones.Columns.Contains("ERROR") Then
                    numPer = dtPercepciones.Rows.Count
                Else
                    EsError = True
                    Exit Sub
                End If


                If Not dtDeducciones.Columns.Contains("ERROR") Then
                    numDed = dtDeducciones.Rows.Count
                Else
                    EsError = True
                    Exit Sub
                End If

                If numPer > numDed Then
                    i = numPer
                ElseIf numDed > numPer Then
                    i = numDed
                Else
                    i = numPer
                End If

                For x As Integer = 1 To i

                    drAgregar = dtDatos.NewRow

                    drAgregar("folio") = drFolios("folio")
                    drAgregar("reloj") = drFolios("reloj")
                    drAgregar("nomemp") = Trim(IIf(IsDBNull(drFolios("apaterno")), "", drFolios("apaterno")).ToString.Trim & " " & _
                        IIf(IsDBNull(drFolios("amaterno")), "", drFolios("amaterno")).ToString.Trim & " " & IIf(IsDBNull(drFolios("nombre")), "", drFolios("nombre")).ToString.Trim)
                    drAgregar("num_cheque") = Trim(IIf(IsDBNull(drFolios("num_cheque")), "SIN ESPECIFICAR", drFolios("num_cheque"))).ToUpper

                    Dim formatoFecha As String = ""
                    formatoFecha = FechaLetra(CDate(drFolios("baja_fin")))
                    drAgregar("fin") = formatoFecha.Split("-")(0) & " de " & formatoFecha.Split("-")(1) & " " & formatoFecha.Split("-")(2)
                    formatoFecha = FechaLetra(CDate(drFolios("fecha_actual")))
                    drAgregar("fecha_actual") = formatoFecha.Split("-")(0) & " de " & formatoFecha.Split("-")(1) & " " & formatoFecha.Split("-")(2)

                    formatoFecha = FechaLetra(CDate(drFolios("alta")))
                    drAgregar("alta") = formatoFecha.Split("-")(0) & " de " & formatoFecha.Split("-")(1) & " " & formatoFecha.Split("-")(2)
                    drAgregar("puesto") = Trim(IIf(IsDBNull(drFolios("puesto")), "SIN ESPECIFICAR", drFolios("puesto"))).ToUpper
                    drAgregar("area") = Trim(IIf(IsDBNull(drFolios("area")), "SIN ESPECIFICAR", drFolios("area"))).ToUpper
                    drAgregar("horario") = Trim(IIf(IsDBNull(drFolios("horario")), "SIN ESPECIFICAR", drFolios("horario")))
                    Dim percepcion_mensual As Decimal = Decimal.Parse(drFolios("sactual").ToString) * 30.4D
                    drAgregar("per_mensual") = FormatCurrency(percepcion_mensual, 2).ToString & " (" & ConvNvo(CDec(percepcion_mensual)).ToUpper & " MONEDA NACIONAL)"

                    'dtDatos.Columns.Add("edo_civil", Type.GetType("System.String"))
                    drAgregar("imss") = Trim(IIf(IsDBNull(drFolios("imss")), "SIN ESPECIFICAR", drFolios("imss")))
                    drAgregar("curp") = Trim(IIf(IsDBNull(drFolios("curp")), "SIN ESPECIFICAR", drFolios("curp")))
                    drAgregar("rfc") = Trim(IIf(IsDBNull(drFolios("rfc")), "SIN ESPECIFICAR", drFolios("rfc")))

                    formatoFecha = FechaLetra(CDate(drFolios("fha_nac")))
                    drAgregar("fecha_nac") = formatoFecha.Split("-")(0) & " de " & formatoFecha.Split("-")(1) & " " & formatoFecha.Split("-")(2)
                    drAgregar("edo_civil") = Trim(IIf(IsDBNull(drFolios("nombre_civil")), "SIN ESPECIFICAR", drFolios("nombre_civil")))

                    Dim dir As String = Trim(IIf(IsDBNull(drFolios("d_completa")), "SIN ESPECIFICAR", drFolios("d_completa")))

                    If dir <> "SIN ESPECIFICAR" Then
                        Dim direccion_completa() As String = Split(dir, ",")
                        If direccion_completa(0).Length > 1 And direccion_completa(1).Length > 1 Then
                            drAgregar("direccion") = direccion_completa(0).Trim & " de la colonia " & direccion_completa(1).Trim
                        ElseIf direccion_completa(0).Length < 2 And direccion_completa(1).Length > 1 Then
                            drAgregar("direccion") = "SIN ESPECIFICAR de la colonia " & direccion_completa(1).Trim
                        ElseIf direccion_completa(0).Length > 1 And direccion_completa(1).Length < 2 Then
                            drAgregar("direccion") = direccion_completa(0).Trim & " de la colonia SIN ESPECIFICAR"
                        End If
                    End If


                    dtDatos.Rows.Add(drAgregar)
                Next

                If Not dtDatos.Rows.Count > 0 Then
                    Exit Sub
                End If

                Dim dtMontoNETO As DataTable = sqlExecute("select monto from movimientos_calculo where folio = '" & drFolios("folio") & "' and concepto  ='NETO'", "NOMINA")
                Try : NETO = dtMontoNETO.Rows(0).Item("monto") : Catch ex As Exception : EsError = True : Exit For : End Try
                Dim letraNEto As String = FormatCurrency(NETO, 2) & " (" & ConvNvo(CDec(NETO)).ToUpper & " M.N.)"


                i = 0

                Dim dtMontoPER As DataTable = sqlExecute("select monto from movimientos_calculo where folio = '" & drFolios("folio") & "' and concepto  ='TOTPER'", "NOMINA")
                Try : TOTPER = dtMontoPER.Rows(0).Item("monto") : Catch ex As Exception : EsError = True : Exit For : End Try

                For Each drPer As DataRow In dtPercepciones.Rows

                    Dim drDatos As DataRow = dtDatos.Rows(i)

                    drDatos("concepto_per") = drPer("concepto")
                    drDatos("nom_con_per") = drPer("nombre")
                    drDatos("prioridad_per") = drPer("prioridad")
                    drDatos("importe_per") = drPer("monto")
                    drDatos("TOTPER") = TOTPER
                    drDatos("NETO") = NETO
                    drDatos("recibido") = letraNEto
                    i = i + 1

                Next

                i = 0
                Dim dtMontoDED As DataTable = sqlExecute("select monto from movimientos_calculo where folio = '" & drFolios("folio") & "' and concepto  ='TOTDED'", "NOMINA")
                Try : TOTDED = dtMontoDED.Rows(0).Item("monto") : Catch ex As Exception : EsError = True : Exit For : End Try
                For Each drDed As DataRow In dtDeducciones.Rows

                    Dim drDatos As DataRow = dtDatos.Rows(i)

                    drDatos("concepto_ded") = drDed("concepto")
                    drDatos("nom_con_ded") = drDed("nombre")
                    drDatos("prioridad_ded") = drDed("prioridad")
                    drDatos("importe_ded") = drDed("monto")
                    drDatos("TOTDED") = TOTDED
                    drDatos("NETO") = NETO
                    drDatos("recibido") = letraNEto
                    i = i + 1

                Next

            Next

            If EsError Then dtDatos = New DataTable

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub LiquidacionFAH(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Try

            dtDatos = New DataTable

            Dim anioPerLiq As String = ""


            dtDatos.Columns.Add("folio", Type.GetType("System.String"))
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nomemp", Type.GetType("System.String"))
            dtDatos.Columns.Add("fin", Type.GetType("System.String"))
            dtDatos.Columns.Add("fin2", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_actual", Type.GetType("System.String"))
            dtDatos.Columns.Add("SEMANA", Type.GetType("System.String"))
            dtDatos.Columns.Add("PATRON", Type.GetType("System.Double"))
            dtDatos.Columns.Add("EMPLEADO", Type.GetType("System.Double"))
            dtDatos.Columns.Add("importe", Type.GetType("System.Double"))
            dtDatos.Columns.Add("recibido", Type.GetType("System.String"))
            dtDatos.Columns.Add("total", Type.GetType("System.Double"))

            Dim folio As String = dtInformacion.Rows(0).Item("folio").ToString.Trim
            Dim rl As String = dtInformacion.Rows(0).Item("reloj").ToString.Trim
            Dim nombre As String = Trim(IIf(IsDBNull(dtInformacion.Rows(0)("apaterno")), "", dtInformacion.Rows(0)("apaterno")).ToString.Trim & " " & _
                        IIf(IsDBNull(dtInformacion.Rows(0)("amaterno")), "", dtInformacion.Rows(0)("amaterno")).ToString.Trim & " " & IIf(IsDBNull(dtInformacion.Rows(0)("nombre")), "", dtInformacion.Rows(0)("nombre")).ToString.Trim)

            Dim AnioBusqueda As String = Year(dtInformacion.Rows(0).Item("baja_fin")).ToString
            Dim fin As Date = dtInformacion.Rows(0).Item("baja_fin")

            Dim dtPerLiqFah As DataTable = sqlExecute("select * from config_per_liqfah where ISNULL(activo,0)=1", "nomina")

            If (Not dtPerLiqFah.Columns.Contains("Error") And dtPerLiqFah.Rows.Count > 0) Then
                anioPerLiq = dtPerLiqFah.Rows(0)("anio_ini").ToString.Trim & dtPerLiqFah.Rows(0)("per_ini").ToString.Trim
            End If

            'select * from saldos_ca where ano+PERIODO>='202015' and reloj='00565' and CONCEPTO in ('SAFAHC','SAFAHE') order by ano asc,PERIODO asc

            '=============== MODIFICACION PARA TOME LOS INGRESOS CORRECTAMENTE (EN CASO DE QUE SE DE)            18oct2021           Ernesto
            Dim dtCargarFondoAhorro As New DataTable
            Dim FAlta_finiquito As String = FechaSQL(dtInformacion.Rows(0)("alta"))
            Dim reingresoBandera As Boolean = False
            Dim unicoBandera As Boolean = False
            Dim ultAnioPer As String = ""

            'Dim QryTemp As String = "select top 1 baja_ant from PERSONAL.dbo.reingresos where reloj='" & rl & "' and alta_ant='" & FAlta_finiquito & "' order by fecha desc"
            Dim QryTemp As String = "select * from PERSONAL.dbo.reingresos where reloj='" & rl & "'"
            Dim dtTemp As DataTable = sqlExecute(QryTemp)

            If dtTemp.Rows.Count > 0 Then
                reingresoBandera = True
                For Each x As DataRow In dtTemp.Select("alta_ant='" & FAlta_finiquito & "'")
                    Dim fecha_baja_Ant As String = FechaSQL(dtTemp.Rows(0)("baja_ant"))
                    QryTemp = "select top 1 ano,PERIODO from ta.dbo.periodos where '" & fecha_baja_Ant & "' >= fini_nom and ano=(YEAR('" & fecha_baja_Ant & "'))"
                    dtTemp = sqlExecute(QryTemp)

                    If dtTemp.Rows.Count > 0 Then
                        ultAnioPer = dtTemp.Rows(0)("ano").ToString.Trim & dtTemp.Rows(0)("periodo").ToString.Trim
                        QryTemp = "select * from NOMINA.dbo.saldos_ca where ano+PERIODO>='" & anioPerLiq & "' and reloj='" & rl & "' and ano+periodo <= '" & ultAnioPer & "'" & _
                                            "and CONCEPTO in ('SAFAHC','SAFAHE') order by ano asc,PERIODO asc"
                        dtCargarFondoAhorro = sqlExecute(QryTemp)
                    End If
                    reingresoBandera = False
                Next
            Else
                unicoBandera = True
            End If

            '== Sin reingresos
            If unicoBandera Then
                dtCargarFondoAhorro = sqlExecute("select * from saldos_ca where ano+PERIODO>='" & anioPerLiq & "' and reloj='" & rl & "' and CONCEPTO in ('SAFAHC','SAFAHE') order by ano asc,PERIODO asc", "NOMINA")
            End If

            '== Se toma en cuenta la fecha de alta del finiquito seleccionado en caso de que haya más para el mismo empleado
            If reingresoBandera And unicoBandera = False Then
                QryTemp = "select top 1 (ano+periodo) as AnioPer from ta.dbo.periodos where '" & FAlta_finiquito & "' >= fini_nom and '" & FAlta_finiquito & "' <= ffin_nom " & _
                                      "and ANO=YEAR('" & FAlta_finiquito & "') and PERIODO_ESPECIAL not in ('1')"
                dtTemp = sqlExecute(QryTemp)

                If dtTemp.Rows.Count > 0 Then
                    ultAnioPer = dtTemp.Rows(0)("AnioPer").ToString

                    dtCargarFondoAhorro = sqlExecute("select * from saldos_ca where ano+PERIODO>='" & ultAnioPer & "' and reloj='" & rl & _
                                                     "' and CONCEPTO in ('SAFAHC','SAFAHE') order by ano asc,PERIODO asc", "NOMINA")
                End If
            End If
            '=============== FIN

            'Dim dtCargarFondoAhorro As DataTable = sqlExecute("select * " & vbCr & _
            '                                                  "from saldos_ca" & vbCr & _
            '                                                  "where reloj = '" & rl & "' and ANO = '" & fin.Year.ToString & "' and exists(select * from ta.dbo.periodos tbPeriodos where tbPeriodos.ANO = saldos_ca.ANO and tbPeriodos.PERIODO = saldos_ca.PERIODO and ISNULL(PERIODO_ESPECIAL,0) = 0)" & vbCr & _
            '                                                  "order by ano asc, PERIODO asc", "nomina")

            Dim acumulado As Double = 0.0

            For Each Row As DataRow In dtCargarFondoAhorro.DefaultView.ToTable(True, "periodo").Rows

                Dim lclPeriodo As String = ""
                Try : lclPeriodo = Row("periodo").ToString.Trim : Catch ex As Exception : lclPeriodo = "" : End Try

                Dim drAgregar As DataRow = dtDatos.NewRow

                drAgregar("folio") = folio.Trim
                drAgregar("reloj") = rl.Trim
                drAgregar("nomemp") = nombre
                drAgregar("fin") = FechaLetra(fin).Replace("-", " de ")
                drAgregar("fin2") = fin.Day.ToString.PadLeft(2, "0") & "/" & fin.Month.ToString.PadLeft(2, "0") & "/" & fin.Year.ToString

                drAgregar("SEMANA") = "SEM " & lclPeriodo

                dtDatos.Rows.Add(drAgregar)

                For Each drFA As DataRow In dtCargarFondoAhorro.Select("periodo = '" & lclPeriodo & "'")

                    Dim SAFAHC As Double = 0.0
                    Dim SAFAHE As Double = 0.0

                    If drFA("concepto").ToString.Trim = "SAFAHC" Then
                        Try : SAFAHC = drFA("abono_alc").ToString.Trim : Catch ex As Exception : SAFAHC = 0.0 : End Try
                        Dim drActualizar As DataRow = dtDatos.Select("SEMANA = 'SEM " & lclPeriodo & "'")(0)
                        drActualizar("PATRON") = SAFAHC
                    End If

                    If drFA("concepto").ToString.Trim = "SAFAHE" Then
                        Try : SAFAHE = drFA("abono_alc").ToString.Trim : Catch ex As Exception : SAFAHE = 0.0 : End Try
                        Dim drActualizar As DataRow = dtDatos.Select("SEMANA = 'SEM " & lclPeriodo & "'")(0)
                        drActualizar("EMPLEADO") = SAFAHE
                    End If

                Next

            Next

            For Each drRow As DataRow In dtDatos.Rows
                drRow("total") = drRow("PATRON") + drRow("EMPLEADO")
                acumulado += drRow("total")
            Next

            For Each drRow As DataRow In dtDatos.Rows
                drRow("importe") = acumulado
                drRow("recibido") = ConvNvo(CDec(acumulado)).ToUpper & " M.N."
            Next

        Catch ex As Exception
            dtDatos = New DataTable
        End Try
    End Sub


    Public Sub NominaProExcel_2(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ocultar_detalle As Boolean, ocultar_totales_depto As Boolean, nombre_archivo As String, FromCondensado As Boolean, PathSave As String, _anio As String, _periodo As String, _tipoPer As String, _anoPerListados As String)

        'If (Not _anoPerListados.Trim.Contains(",")) Then
        '    GoTo SaltarAcumulado
        'End If

        ''******--- AOS:: Proceso de ACUMULAR por periodos
        'Dim z As Integer = -1
        'frmTrabajando.Text = "Acumulando periodos"
        'frmTrabajando.Avance.IsRunning = True
        'frmTrabajando.lblAvance.Text = "Acumulando nóminas"
        'ActivoTrabajando = True
        'frmTrabajando.Show()
        'Application.DoEvents()

        'Try

        '    dtInformacion.Columns.Add("aplica", GetType(System.String))

        '    Dim dtReloj As New DataTable
        '    dtReloj.Columns.Add("reloj", GetType(System.String))


        '    For Each r As DataRow In dtInformacion.Rows
        '        Dim _reloj As String = r("reloj").ToString.Trim

        '        If (dtReloj.Select("reloj='" & _reloj & "'").Count = 0) Then
        '            r("aplica") = "S"
        '        End If

        '        dtReloj.Rows.Add(_reloj)
        '    Next

        '    '--Mostrar progress
        '    frmTrabajando.Avance.IsRunning = False
        '    frmTrabajando.lblAvance.Text = "Procesando datos"
        '    Application.DoEvents()
        '    frmTrabajando.Avance.Maximum = dtInformacion.Select("aplica='S'").Count

        '    For Each drRow In dtInformacion.Select("aplica='S'")
        '        Dim rj As String = ""
        '        Try : rj = drRow("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try

        '        '----Mostrar Progress - avance
        '        z += 1
        '        frmTrabajando.Avance.Value = z
        '        frmTrabajando.lblAvance.Text = rj
        '        Application.DoEvents()

        '        '---Recorrer cada una de las columnas
        '        Dim name(dtInformacion.Columns.Count) As String
        '        Dim i As Integer = 0

        '        For Each col In dtInformacion.Columns
        '            Dim tipo As Type = col.DataType
        '            name(i) = col.ColumnName
        '            Dim x As Double = 0.0

        '            If (tipo.Name = "Double" And name(i) <> "SACTUAL" And name(i) <> "INTEGRADO") Then
        '                Try
        '                    x = (From a In dtInformacion.Select("reloj='" & rj & "'").AsEnumerable()
        '                    Select a.Field(Of Double)(name(i))).Sum()
        '                Catch ex As Exception

        '                End Try
        '                drRow(name(i)) = x
        '            End If
        '            i += 1

        '        Next

        '        drRow("aplica") = "S"

        '    Next


        '    Dim dElimina() As DataRow
        '    dElimina = dtInformacion.Select("isnull(aplica,'')=''")
        '    For Each del As DataRow In dElimina
        '        dtInformacion.Rows.Remove(del)
        '    Next

        '    ActivoTrabajando = False
        '    frmTrabajando.Close()
        '    frmTrabajando.Dispose()

        'Catch ex As Exception
        '    ActivoTrabajando = False
        '    frmTrabajando.Close()
        '    frmTrabajando.Dispose()
        '    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "NominaProExcel_2", ex.HResult, ex.Message)
        'End Try

        '-------------ENDS PROCESO de ACUMULAR 

        'SaltarAcumulado:

        Try
            fromCondFinanzas = False ' Indica que no viene del condensando de finanzas

            'If _tipoPer = "S" Then _tipoPer = "Semanal" Else If _tipoPer = "C" Then _tipoPer = "Catorcenal"
            'Dim anioPerTipo As String = _anio & "_" & _periodo & "_" & _tipoPer

            Dim anioPerTipo As String = _anoPerListados

            dtDatos = New DataTable

            Dim dtEncabezados As New DataTable
            dtEncabezados.Columns.Add("orden", Type.GetType("System.Int32"))
            dtEncabezados.Columns.Add("campo")
            dtEncabezados.Columns.Add("encabezado")
            dtEncabezados.Columns.Add("cuenta")
            dtEncabezados.Columns.Add("tipo")
            dtEncabezados.Columns.Add("enfasis")
            dtEncabezados.Columns.Add("bgcolor")

            ' Columnas principales que se mostraran 
            dtDatos.Columns.Add("totales")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("reloj_alterno")
            dtDatos.Columns.Add("sactual")
            dtDatos.Columns.Add("integrado")
            dtDatos.Columns.Add("cod_costos")


            Dim dtPeriodos As DataTable = New DataTable
            dtPeriodos.Columns.Add("ano")
            dtPeriodos.Columns.Add("periodo")
            dtPeriodos.Columns.Add("tipo_periodo")
            dtPeriodos.PrimaryKey = New DataColumn() {dtPeriodos.Columns("ano"), dtPeriodos.Columns("periodo"), dtPeriodos.Columns("tipo_periodo")}

            Dim titulo_codigo As String = ""
            Dim titulo_nombre As String = ""

            If ocultar_detalle = True Then
                titulo_codigo = "Centro de costos"
                titulo_nombre = "Descripción"
            Else
                titulo_codigo = "Número de empleado"
                titulo_nombre = "Nombre completo"
            End If

            dtEncabezados.Rows.Add({1, "reloj", titulo_codigo, "", "", 0, "na"})
            dtEncabezados.Rows.Add({2, "nombres", titulo_nombre, "", "", 0, "na"})

            Dim siguiente_encabezado As Integer = 3

            If Not ocultar_detalle Then
                dtEncabezados.Rows.Add({3, "reloj_alterno", "Reloj alterno", "", "", 0, "na"})
                dtEncabezados.Rows.Add({4, "sactual", "Sueldo", "", "", 0, "na"}) ' Columnas que se mostrarán
                dtEncabezados.Rows.Add({5, "integrado", "Int.Imss", "", "", 0, "na"})
                siguiente_encabezado = 6
            End If

            Dim dtGruposConceptos As New DataTable

            dtGruposConceptos.Columns.Add("orden", Type.GetType("System.Int32"))
            dtGruposConceptos.Columns.Add("nombre")
            dtGruposConceptos.Columns.Add("filtro")
            dtGruposConceptos.Columns.Add("enfasis", Type.GetType("System.Int32"))
            dtGruposConceptos.Columns.Add("bgcolor")

            '---Orden a mostrar en prioridad para los conceptos que va conformar el excel
            dtGruposConceptos.Rows.Add({1, "Días/horas", "cod_naturaleza = 'I'  and activo = '1' and concepto in('HRSNOR','DIASPA','HRSEX2','HRSEX3','HRSFES','HRSFEL','HRSDOM','DIASVA','DIASPV','DIASAG')", 0, "nan"})

            dtGruposConceptos.Rows.Add({2, "Percepciones", "cod_naturaleza = 'P'  and activo = '1' and concepto<>'BONDES'", 0, "nan"})
            dtGruposConceptos.Rows.Add({3, "Aportación FAH Empresa", "cod_naturaleza = 'I'  and activo = '1' and concepto='APOCIA'", 0, "nan"})
            dtGruposConceptos.Rows.Add({4, "Total de Percepciones", "concepto = 'TOTPER'", 1, "nan"})

            dtGruposConceptos.Rows.Add({5, "Bono de despensa", "concepto= 'BONDES'", 1, "nan"}) ' Ya lo incluye dentro de las percepciones

            dtGruposConceptos.Rows.Add({6, "Deducciones", "cod_naturaleza = 'D' and activo = '1'", 0, "nan"})
            dtGruposConceptos.Rows.Add({7, "Total de Deducciones", "concepto = 'TOTDED'", 1, "nan"})

            dtGruposConceptos.Rows.Add({8, "Neto", "concepto= 'NETO'", 1, "nan"})

            dtGruposConceptos.Rows.Add({9, "Obligaciones", "cod_naturaleza = 'O'  and activo = '1' and concepto not in('TOTPAT','TOTASE')", 0, "nan"})
            dtGruposConceptos.Rows.Add({10, "Total de Obligaciones", "cod_naturaleza = 'O'  and activo = '1' and concepto in('TOTPAT','TOTASE')", 1, "nan"})

            Dim dtCuentas As DataTable = sqlExecute("select distinct concepto, cuenta from cuentas", "nomina")

            For Each row_grupo As DataRow In dtGruposConceptos.Select("", "orden")
                Dim dtConceptosGrupo As DataTable = sqlExecute("select * from conceptos where " & row_grupo("filtro") & " order by prioridad", "nomina") ' Se mostrarán por orden de prioridad (conceptos.prioridad)
                For Each row_conceptos As DataRow In dtConceptosGrupo.Rows

                    Dim cuenta_contable As String = "-"
                    Dim concepto_codigo As String = RTrim(row_conceptos("concepto")).ToLower
                    Dim concepto_nombre As String = RTrim(row_conceptos("nombre"))


                    Try
                        For Each row_cuenta As DataRow In dtCuentas.Select("concepto = '" & concepto_codigo & "'")
                            cuenta_contable = row_cuenta("cuenta")
                        Next
                    Catch ex As Exception

                    End Try

                    dtDatos.Columns.Add(concepto_codigo)
                    dtEncabezados.Rows.Add({siguiente_encabezado, concepto_codigo, concepto_nombre, cuenta_contable, "num", row_grupo("enfasis"), row_grupo("bgcolor")})
                    siguiente_encabezado += 1
                Next
            Next

            '*************************************



            Dim frm As New frmTrabajando
            frm.lblAvance.Text = ""
            frm.Show()

            Dim dtCentrosDeCostos As DataTable = sqlExecute("select * from c_costos")

            Dim drow_total_general As DataRow = dtDatos.NewRow
            drow_total_general("totales") = 3
            drow_total_general("reloj") = "Total Gral."

            '  For Each row_cc As DataRow In dtCentrosDeCostos.Rows ' Lo agrupa por Centro Costos
            For Each row_cc As DataRow In dtInformacion.Rows

                '   frm.lblAvance.Text = row_cc("centro_costos")
                frm.lblAvance.Text = row_cc("reloj")
                Application.DoEvents()

                'If dtInformacion.Select("cod_costos = '" & row_cc("centro_costos") & "'").Length > 0 Then

                Dim drow_grupo As DataRow = dtDatos.NewRow
                drow_grupo("totales") = 2
                '   drow_grupo("reloj") = row_cc("centro_costos")
                drow_grupo("reloj") = row_cc("reloj")
                '   drow_grupo("nombres") = row_cc("nombre")
                drow_grupo("nombres") = row_cc("nombres")

                If ocultar_totales_depto = False Then
                    dtDatos.Rows.Add(drow_grupo)
                End If


                Dim drow_totales As DataRow = dtDatos.NewRow
                drow_totales("totales") = 1
                drow_totales("reloj") = "Total Depto"

                drow_totales("totales") = 1

                Dim drow_vacia As DataRow = dtDatos.NewRow
                drow_vacia("totales") = 1


                '  For Each row_informacion As DataRow In dtInformacion.Select("cod_costos = '" & row_cc("centro_costos") & "' AND (TOTPER>0 OR BONDES>0)") ' &&_AOS 15/01/2020 - Solo incluir a empleados con percepcion > 0 o BONDES> 0
                '   For Each row_informacion As DataRow In dtInformacion.Select("cod_costos = '" & row_cc("centro_costos") & "'") ' &&_Incluir a todos los empleados aunque tengan TOTPER ,TOTDED ó NETO = 0
                Try
                    Dim drow_periodo As DataRow = dtPeriodos.NewRow
                    'drow_periodo("ano") = row_informacion("ano")
                    'drow_periodo("periodo") = row_informacion("periodo")
                    'drow_periodo("tipo_periodo") = row_informacion("tipo_periodo")

                    drow_periodo("ano") = row_cc("ano")
                    drow_periodo("periodo") = row_cc("periodo")
                    drow_periodo("tipo_periodo") = row_cc("tipo_periodo")
                    dtPeriodos.Rows.Add(drow_periodo)

                Catch ex As Exception

                End Try

                Application.DoEvents()

                Dim drow As DataRow = dtDatos.NewRow
                drow("totales") = 0

                '---AOS :: Here es donde veo que tarda mas
                For Each row_encabezado As DataRow In dtEncabezados.Rows ' Evalua y da el valor para cada uno de los campos a ingresar en el excel

                    Dim campo_ As String = row_encabezado("campo")

                    Try
                        '  Dim valor As String = row_informacion(row_encabezado("campo")) 'Es el valor de acuerdo al campo que esta buscando
                        Dim valor As String = row_cc(row_encabezado("campo")) 'Es el valor de acuerdo al campo que esta buscando

                        drow(campo_) = valor

                        '  Dim h As String = drow(campo_)

                        If row_encabezado("tipo") = "num" Then
                            If IsDBNull(drow(campo_)) Then
                                drow(campo_) = 0
                            End If

                            If ocultar_detalle = True Then
                                drow_grupo(campo_) = Double.Parse(IIf(IsDBNull(drow_grupo(campo_)), 0, drow_grupo(campo_))) + Double.Parse(drow(campo_))
                            Else
                                drow_totales(campo_) = Double.Parse(IIf(IsDBNull(drow_totales(campo_)), 0, drow_totales(campo_))) + Double.Parse(drow(campo_))
                            End If

                            drow_total_general(campo_) = Double.Parse(IIf(IsDBNull(drow_total_general(campo_)), 0, drow_total_general(campo_))) + Double.Parse(drow(campo_))

                        End If

                    Catch ex As Exception
                        drow(campo_) = 0
                    End Try

                Next

                dtDatos.Rows.Add(drow)
                '   Next

                If ocultar_totales_depto = False Then
                    dtDatos.Rows.Add(drow_totales)
                    dtDatos.Rows.Add(drow_vacia)
                End If

                '  End If
            Next

            dtDatos.Rows.Add(drow_total_general)

            ActivoTrabajando = False
            frm.Close()

            Dim archivo As ExcelPackage = New ExcelPackage()
            Dim wb As ExcelWorkbook = archivo.Workbook
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("nomina")


            Dim x As Integer = 4
            Dim y As Integer = 1

            If nombre_archivo = "Nómina centro de costos" Then
                x = 5
            End If

            hoja_excel.Row(x).Style.Font.Bold = True
            hoja_excel.Row(x - 1).Style.Font.Italic = True



            If nombre_archivo = "Nómina centro de costos" Then
                hoja_excel.Row(x - 2).Style.Font.Bold = True
                hoja_excel.Row(x - 2).Style.Font.Italic = True
            End If


            For Each row_encabezado As DataRow In dtEncabezados.Select("", "orden")

                If row_encabezado("tipo") = "num" Then
                    If nombre_archivo = "Nómina centro de costos" Then
                        hoja_excel.Cells(x - 2, y).Value = row_encabezado("campo")
                        hoja_excel.Cells(x - 2, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x - 2, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)

                        hoja_excel.Cells(x - 1, y).Value = row_encabezado("cuenta")
                        hoja_excel.Cells(x - 1, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x - 1, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                    Else
                        hoja_excel.Cells(x - 1, y).Value = row_encabezado("campo")
                        hoja_excel.Cells(x - 1, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x - 1, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                    End If

                End If

                hoja_excel.Cells(x, y).Value = row_encabezado("encabezado")
                hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)


                y += 1
            Next

            x += 1
            y = 1

            If nombre_archivo = "Nomina detalle excel" Then
                dtDatos = dtDatos.Select("", "reloj").CopyToDataTable

                Try
                    dtDatos = dtDatos.Select("totper <> 0 or totded <> 0 or bondes <> 0", "reloj").CopyToDataTable
                Catch ex As Exception

                End Try

            End If

            For Each row_datos As DataRow In dtDatos.Rows

                If row_datos("totales") > IIf(ocultar_detalle, 2, 0) Then
                    hoja_excel.Row(x).Style.Font.Bold = True
                End If

                If ocultar_detalle Then
                    If row_datos("totales") < 2 Then
                        Continue For
                    End If
                End If

                For Each row_encabezados As DataRow In dtEncabezados.Select("", "orden")

                    Dim valor As String = IIf(IsDBNull(row_datos(row_encabezados("campo"))), "", row_datos(row_encabezados("campo")))

                    If row_encabezados("tipo") = "num" And valor <> "" Then
                        hoja_excel.Cells(x, y).Value = Double.Parse(row_datos(row_encabezados("campo")))
                        hoja_excel.Cells(x, y).Style.Numberformat.Format = "#,##0.00"
                    Else
                        hoja_excel.Cells(x, y).Value = row_datos(row_encabezados("campo"))
                    End If

                    If row_encabezados("enfasis") = 1 Then
                        hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                    End If

                    y += 1
                Next
                x += 1
                y = 1
            Next

            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()


            Dim periodos_titulo As String = ""
            For Each row_periodo As DataRow In dtPeriodos.Rows
                periodos_titulo &= row_periodo("ano") & "-" & row_periodo("periodo") & ", "
            Next
            periodos_titulo &= "_"
            periodos_titulo = periodos_titulo.Replace(", _", "")

            hoja_excel.Cells(1, 1).Value = "CTE"
            hoja_excel.Cells(1, 1).Style.Font.Bold = True
            hoja_excel.Cells(1, 1).Style.Font.Size = 12

            '   hoja_excel.Cells(2, 1).Value = nombre_archivo & " " & periodos_titulo
            hoja_excel.Cells(2, 1).Value = nombre_archivo & " " & anioPerTipo
            hoja_excel.Cells(2, 1).Style.Font.Bold = True

            Dim sfd As New SaveFileDialog
            sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            '   sfd.FileName = "OSC " & nombre_archivo & ".xlsx"
            Dim NameFile As String = ""

            If fromCondFinanzas Then NameFile = "CTE - FINANZAS-" & nombre_archivo & anioPerTipo Else NameFile = "CTE " & nombre_archivo & "_" & anioPerTipo
            sfd.FileName = NameFile & ".xlsx"
            sfd.Filter = "Archivo excel (xlsx)|*.xlsx"


            If (FromCondensado And PathSave.Trim <> "") Then  '- Si viene del condensado
                sfd.InitialDirectory = PathSave
                '   sfd.FileName = "OSC " & nombre_archivo & ".xlsx"
                If fromCondFinanzas Then NameFile = "CTE - FINANZAS-" & nombre_archivo Else NameFile = "CTE " & nombre_archivo
                sfd.FileName = NameFile & ".xlsx"
                sfd.Filter = "Archivo excel (xlsx)|*.xlsx"
                archivo.SaveAs(New System.IO.FileInfo(PathSave & sfd.FileName))
                GoTo Saltar1
            End If

            If sfd.ShowDialog() = DialogResult.OK Then
                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
            End If
Saltar1:
            System.Diagnostics.Process.Start(sfd.FileName)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    'Antonio  NoTimbrados
    Public Sub NoTimbrados(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable) 'Funcion para guardar los datos en la tabla del dataset en en rdl para que se muestren los nombres y relojes que no se les hizo timbrado
        Try
            Dim reloj As String = "", nombres As String = "", periodo As String = "", anio As String
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("Periodo")
            dtDatos.Columns.Add("Anio")

            For Each drRw In dtInformacion.Rows
                reloj = drRw("RELOJ").ToString.Trim
                nombres = drRw("NOMBRES").ToString.Trim
                anio = drRw("Periodo").ToString.Trim.Substring(0, 4)
                periodo = drRw("Periodo").ToString.Trim.Substring(5, 2)

                Dim drow As DataRow = dtDatos.NewRow
                drow("reloj") = reloj
                drow("nombres") = nombres
                drow("periodo") = periodo
                drow("Anio") = anio
                dtDatos.Rows.Add(drow)

            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub RelacionDeRecibosNomina(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable) '--Jose Hernandez Dic 03 2018--
        Try
            Dim intConsecutivo As Integer = 1
            Dim strFolio As String = ""
            Dim strPrevCodTipo As String = ""
            Dim strPrevCodDepto As String = ""
            dtDatos.Columns.Add("Folio")
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("PERIODO")
            dtDatos.Columns.Add("consecutivo")
            dtDatos.Columns.Add("Enviado") '--------Agregado por Antonio

            For Each dR As DataRow In dtInformacion.Rows
                intConsecutivo = intConsecutivo + 1
                If dR("COD_TIPO") <> strPrevCodTipo Then intConsecutivo = 1
                strPrevCodTipo = dR("COD_TIPO")
                If dR("COD_TIPO") = "O" And dR("COD_DEPTO") <> strPrevCodDepto Then intConsecutivo = 1
                strPrevCodDepto = dR("COD_DEPTO")
                dR("Folio") = IIf(IsDBNull(dR("Folio")), "0", dR("Folio"))
                dR("COD_DEPTO") = IIf(IsDBNull(dR("COD_DEPTO")), "", dR("COD_DEPTO"))
                dR("reloj") = IIf(IsDBNull(dR("reloj")), "", dR("reloj"))
                dR("nombres") = IIf(IsDBNull(dR("nombres")), "", dR("nombres"))
                dR("PERIODO") = IIf(IsDBNull(dR("PERIODO")), "", dR("PERIODO"))
                dR("Enviado") = dR("Enviado") '--------Agregado por Antonio
                If dR("COD_TIPO") = "A" Then strFolio = "A" & dR("Folio")
                If dR("COD_TIPO") = "G" Then strFolio = "G" & dR("Folio")
                If dR("COD_TIPO") = "O" Then strFolio = "O" & dR("Folio")
                If dR("COD_TIPO") = "" Then strFolio = "O" & dR("Folio")

                '  If (dR("Folio") > 0) Then
                dtDatos.Rows.Add({strFolio, _
                                  dR("COD_DEPTO"), _
                                  dR("reloj"), _
                                  Trim(dR("nombres")), _
                                  dR("PERIODO"), _
                                  intConsecutivo, _
                                  dR("Enviado")
                                 })
                '  End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub NominaProExcel_esp(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ocultar_detalle As Boolean, ocultar_totales_depto As Boolean, nombre_archivo As String, FromCondensado As Boolean, PathSave As String, _anio As String, _periodo As String, _tipoPer As String, Optional ByRef _tipoNom As String = "")
        Try
            fromCondFinanzas = False ' Indica que no viene del condensando de finanzas

            If _tipoPer = "S" Then _tipoPer = "Semanal" Else If _tipoPer = "C" Then _tipoPer = "Catorcenal"
            Dim anioPerTipo As String = _anio & "_" & _periodo & "_" & _tipoPer

            '---Depurar dtInformacion, dejando solo a los empleados que estan en MovimientosPro
            dtInformacion.Columns.Add("aplica", GetType(System.String))
            Dim dtRjMovsPro As DataTable = sqlExecute("SELECT DISTINCT RELOJ FROM movimientos_pro_esp", "NOMINA")
            If Not (dtRjMovsPro.Columns.Contains("Error") And dtRjMovsPro.Rows.Count > 0) Then
                Dim pos As Integer = 0
                For Each dr As DataRow In dtInformacion.Rows
                    dtInformacion.Rows(pos)("aplica") = "n"
                    pos += 1
                Next

                For Each dr1 As DataRow In dtRjMovsPro.Rows
                    Dim rj As String = ""
                    Dim myRow() As DataRow
                    Try : rj = dr1("RELOJ").ToString.Trim : Catch ex As Exception : rj = "" : End Try

                    If (dtInformacion.Select("reloj='" & rj & "'").Count > 0) Then
                        myRow = dtInformacion.Select("reloj='" & rj & "'")
                        myRow(0)("aplica") = "s"
                    End If

                Next
                '--Eliminar masivamente los que no apliquen
                Dim dElimina() As DataRow
                dElimina = dtInformacion.Select("aplica ='n'")
                For Each del As DataRow In dElimina
                    dtInformacion.Rows.Remove(del)
                Next

            End If
            dtInformacion.Columns.Remove("aplica")
            '---Ends Depura dtInformacion

            '----Agregar los movimientos imss a dtInformacion
            Dim dtMovsImssPro As DataTable = sqlExecute("select * from movimientos_imss_pro_esp order by reloj asc", "nomina")
            If (Not dtMovsImssPro.Columns.Contains("Error") And dtMovsImssPro.Rows.Count > 0) Then

                For Each drMovImss As DataRow In dtMovsImssPro.Rows
                    Dim reloj As String = "", concepto As String = "", monto As Double = 0.0
                    Try : reloj = drMovImss("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                    Try : concepto = drMovImss("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                    Try : monto = Double.Parse(drMovImss("monto")) : Catch ex As Exception : monto = 0.0 : End Try

                    Dim drRowFind() As DataRow
                    If (dtInformacion.Select("reloj='" & reloj & "'").Count > 0) Then
                        drRowFind = dtInformacion.Select("reloj='" & reloj & "'")
                        drRowFind(0)(concepto) = monto
                    End If

                Next

            End If

            '----Ends agregar movsImss



            dtDatos = New DataTable

            Dim dtEncabezados As New DataTable
            dtEncabezados.Columns.Add("orden", Type.GetType("System.Int32"))
            dtEncabezados.Columns.Add("campo")
            dtEncabezados.Columns.Add("encabezado")
            dtEncabezados.Columns.Add("cuenta")
            dtEncabezados.Columns.Add("tipo")
            dtEncabezados.Columns.Add("enfasis")
            dtEncabezados.Columns.Add("bgcolor")

            ' Columnas principales que se mostraran 
            dtDatos.Columns.Add("totales")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("reloj_alterno")
            dtDatos.Columns.Add("sactual")
            dtDatos.Columns.Add("integrado")
            dtDatos.Columns.Add("cod_costos")
            dtDatos.Columns.Add("alta")
            dtDatos.Columns.Add("baja")


            Dim dtPeriodos As DataTable = New DataTable
            dtPeriodos.Columns.Add("ano")
            dtPeriodos.Columns.Add("periodo")
            dtPeriodos.Columns.Add("tipo_periodo")
            dtPeriodos.PrimaryKey = New DataColumn() {dtPeriodos.Columns("ano"), dtPeriodos.Columns("periodo"), dtPeriodos.Columns("tipo_periodo")}

            Dim titulo_codigo As String = ""
            Dim titulo_nombre As String = ""

            If ocultar_detalle = True Then
                titulo_codigo = "Centro de costos"
                titulo_nombre = "Descripción"
            Else
                titulo_codigo = "Número de empleado"
                titulo_nombre = "Nombre completo"
            End If

            dtEncabezados.Rows.Add({1, "reloj", titulo_codigo, "", "", 0, "na"})
            dtEncabezados.Rows.Add({2, "nombres", titulo_nombre, "", "", 0, "na"})

            Dim siguiente_encabezado As Integer = 3

            If Not ocultar_detalle Then
                dtEncabezados.Rows.Add({3, "reloj_alterno", "Número SAP", "", "", 0, "na"})
                dtEncabezados.Rows.Add({4, "sactual", "Sueldo", "", "", 0, "na"}) ' Columnas que se mostrarán
                dtEncabezados.Rows.Add({5, "integrado", "Int.Imss", "", "", 0, "na"})
                dtEncabezados.Rows.Add({6, "alta", "Alta", "", "", 0, "na"})
                dtEncabezados.Rows.Add({7, "baja", "Baja", "", "", 0, "na"})
                siguiente_encabezado = 8
            End If

            Dim dtGruposConceptos As New DataTable

            dtGruposConceptos.Columns.Add("orden", Type.GetType("System.Int32"))
            dtGruposConceptos.Columns.Add("nombre")
            dtGruposConceptos.Columns.Add("filtro")
            dtGruposConceptos.Columns.Add("enfasis", Type.GetType("System.Int32"))
            dtGruposConceptos.Columns.Add("bgcolor")

            '---Orden a mostrar en prioridad para los conceptos que va conformar el excel

            If (_tipoNom = "Agui") Then

                dtGruposConceptos.Rows.Add({1, "diaspa", "cod_naturaleza = 'I'  and activo = '1' and concepto in('DIASPA')", 0, "nan"})
                dtGruposConceptos.Rows.Add({2, "diacag", "cod_naturaleza = 'I'  and activo = '1' and concepto in('DIACAG')", 0, "nan"})
                dtGruposConceptos.Rows.Add({3, "ausagi", "cod_naturaleza = 'I'  and activo = '1' and concepto in('AUSAGI')", 0, "nan"})
                dtGruposConceptos.Rows.Add({4, "diatag", "cod_naturaleza = 'I'  and activo = '1' and concepto in('DIATAG')", 0, "nan"})
                dtGruposConceptos.Rows.Add({5, "diasag", "cod_naturaleza = 'I'  and activo = '1' and concepto in('DIASAG')", 0, "nan"})

                dtGruposConceptos.Rows.Add({6, "Percepciones", "cod_naturaleza = 'P'  and activo = '1' and concepto in('PERAGI')", 0, "nan"})

                dtGruposConceptos.Rows.Add({7, "Total de Percepciones", "concepto = 'TOTPER'", 1, "nan"})


                dtGruposConceptos.Rows.Add({8, "Deducciones", "cod_naturaleza = 'D' and activo = '1' and concepto in('ISPTRE','PENALI','PENAL2','PENAL3')", 0, "nan"})
                dtGruposConceptos.Rows.Add({9, "Total de Deducciones", "concepto = 'TOTDED'", 1, "nan"})

                dtGruposConceptos.Rows.Add({10, "Neto", "concepto= 'NETO'", 1, "nan"})

                dtGruposConceptos.Rows.Add({11, "Obligaciones", "cod_naturaleza = 'O'  and activo = '1' and concepto in('ISPT','SUBCAU')", 0, "nan"})

            Else ' Para cualquier otro tipo de nom
                dtGruposConceptos.Rows.Add({1, "Días/horas", "cod_naturaleza = 'I'  and activo = '1' and concepto in('HRSNOR','DIASPA','HRSEX2','HRSEX3','HRSFES','HRSFEL','HRSDOM','DIASVA','DIASPV','DIACAG','AUSAGI','DIATAG','DIASAG','PTUDIA','PTUSUE')", 0, "nan"})

                dtGruposConceptos.Rows.Add({2, "Percepciones", "cod_naturaleza = 'P'  and activo = '1' and concepto<>'BONDES'", 0, "nan"})
                dtGruposConceptos.Rows.Add({3, "Aportación FAH Empresa", "cod_naturaleza = 'I'  and activo = '1' and concepto='APOCIA'", 0, "nan"})
                dtGruposConceptos.Rows.Add({4, "Total de Percepciones", "concepto = 'TOTPER'", 1, "nan"})

                dtGruposConceptos.Rows.Add({5, "Bono de despensa", "concepto= 'BONDES'", 1, "nan"}) ' Ya lo incluye dentro de las percepciones

                dtGruposConceptos.Rows.Add({6, "Deducciones", "cod_naturaleza = 'D' and activo = '1'", 0, "nan"})
                dtGruposConceptos.Rows.Add({7, "Total de Deducciones", "concepto = 'TOTDED'", 1, "nan"})

                dtGruposConceptos.Rows.Add({8, "Neto", "concepto= 'NETO'", 1, "nan"})

                dtGruposConceptos.Rows.Add({9, "Obligaciones", "cod_naturaleza = 'O'  and activo = '1' and concepto not in('TOTPAT','TOTASE')", 0, "nan"})
                dtGruposConceptos.Rows.Add({10, "Total de Obligaciones", "cod_naturaleza = 'O'  and activo = '1' and concepto in('TOTPAT','TOTASE')", 1, "nan"})
            End If


            Dim dtCuentas As DataTable = sqlExecute("select distinct concepto, cuenta from cuentas", "nomina")

            For Each row_grupo As DataRow In dtGruposConceptos.Select("", "orden")
                Dim dtConceptosGrupo As DataTable = sqlExecute("select * from conceptos where " & row_grupo("filtro") & " order by prioridad", "nomina") ' Se mostrarán por orden de prioridad (conceptos.prioridad)
                For Each row_conceptos As DataRow In dtConceptosGrupo.Rows

                    Dim cuenta_contable As String = "-"
                    Dim concepto_codigo As String = RTrim(row_conceptos("concepto")).ToLower
                    Dim concepto_nombre As String = RTrim(row_conceptos("nombre"))


                    Try
                        For Each row_cuenta As DataRow In dtCuentas.Select("concepto = '" & concepto_codigo & "'")
                            cuenta_contable = row_cuenta("cuenta")
                        Next
                    Catch ex As Exception

                    End Try

                    dtDatos.Columns.Add(concepto_codigo)
                    dtEncabezados.Rows.Add({siguiente_encabezado, concepto_codigo, concepto_nombre, cuenta_contable, "num", row_grupo("enfasis"), row_grupo("bgcolor")})
                    siguiente_encabezado += 1
                Next
            Next

            '*************************************



            Dim frm As New frmTrabajando
            frm.lblAvance.Text = ""
            frm.Show()

            Dim dtCentrosDeCostos As DataTable = sqlExecute("select * from c_costos")

            Dim drow_total_general As DataRow = dtDatos.NewRow
            drow_total_general("totales") = 3
            drow_total_general("reloj") = "Total Gral."

            '  For Each row_cc As DataRow In dtCentrosDeCostos.Rows ' Lo agrupa por Centro Costos
            For Each row_cc As DataRow In dtInformacion.Rows

                '   frm.lblAvance.Text = row_cc("centro_costos")
                frm.lblAvance.Text = row_cc("reloj")
                Application.DoEvents()

                'If dtInformacion.Select("cod_costos = '" & row_cc("centro_costos") & "'").Length > 0 Then

                Dim drow_grupo As DataRow = dtDatos.NewRow
                drow_grupo("totales") = 2
                '   drow_grupo("reloj") = row_cc("centro_costos")
                drow_grupo("reloj") = row_cc("reloj")
                '   drow_grupo("nombres") = row_cc("nombre")
                drow_grupo("nombres") = row_cc("nombres")

                If ocultar_totales_depto = False Then
                    dtDatos.Rows.Add(drow_grupo)
                End If


                Dim drow_totales As DataRow = dtDatos.NewRow
                drow_totales("totales") = 1
                drow_totales("reloj") = "Total Depto"

                drow_totales("totales") = 1

                Dim drow_vacia As DataRow = dtDatos.NewRow
                drow_vacia("totales") = 1


                '  For Each row_informacion As DataRow In dtInformacion.Select("cod_costos = '" & row_cc("centro_costos") & "' AND (TOTPER>0 OR BONDES>0)") ' &&_AOS 15/01/2020 - Solo incluir a empleados con percepcion > 0 o BONDES> 0
                '   For Each row_informacion As DataRow In dtInformacion.Select("cod_costos = '" & row_cc("centro_costos") & "'") ' &&_Incluir a todos los empleados aunque tengan TOTPER ,TOTDED ó NETO = 0
                Try
                    Dim drow_periodo As DataRow = dtPeriodos.NewRow
                    'drow_periodo("ano") = row_informacion("ano")
                    'drow_periodo("periodo") = row_informacion("periodo")
                    'drow_periodo("tipo_periodo") = row_informacion("tipo_periodo")

                    drow_periodo("ano") = row_cc("ano")
                    drow_periodo("periodo") = row_cc("periodo")
                    drow_periodo("tipo_periodo") = row_cc("tipo_periodo")
                    dtPeriodos.Rows.Add(drow_periodo)

                Catch ex As Exception

                End Try

                Application.DoEvents()

                Dim drow As DataRow = dtDatos.NewRow
                drow("totales") = 0

                '---AOS :: Here es donde veo que tarda mas
                For Each row_encabezado As DataRow In dtEncabezados.Rows ' Evalua y da el valor para cada uno de los campos a ingresar en el excel

                    Dim campo_ As String = row_encabezado("campo")

                    Try
                        '  Dim valor As String = row_informacion(row_encabezado("campo")) 'Es el valor de acuerdo al campo que esta buscando
                        Dim valor As String = row_cc(row_encabezado("campo")) 'Es el valor de acuerdo al campo que esta buscando

                        drow(campo_) = valor

                        '  Dim h As String = drow(campo_)

                        If row_encabezado("tipo") = "num" Then
                            If IsDBNull(drow(campo_)) Then
                                drow(campo_) = 0
                            End If

                            If ocultar_detalle = True Then
                                drow_grupo(campo_) = Double.Parse(IIf(IsDBNull(drow_grupo(campo_)), 0, drow_grupo(campo_))) + Double.Parse(drow(campo_))
                            Else
                                drow_totales(campo_) = Double.Parse(IIf(IsDBNull(drow_totales(campo_)), 0, drow_totales(campo_))) + Double.Parse(drow(campo_))
                            End If

                            drow_total_general(campo_) = Double.Parse(IIf(IsDBNull(drow_total_general(campo_)), 0, drow_total_general(campo_))) + Double.Parse(drow(campo_))

                        End If

                    Catch ex As Exception
                        drow(campo_) = 0
                    End Try

                Next

                dtDatos.Rows.Add(drow)
                '   Next

                If ocultar_totales_depto = False Then
                    dtDatos.Rows.Add(drow_totales)
                    dtDatos.Rows.Add(drow_vacia)
                End If

                '  End If
            Next

            dtDatos.Rows.Add(drow_total_general)

            ActivoTrabajando = False
            frm.Close()

            Dim archivo As ExcelPackage = New ExcelPackage()
            Dim wb As ExcelWorkbook = archivo.Workbook
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("nomina")


            Dim x As Integer = 4
            Dim y As Integer = 1

            If nombre_archivo = "Nómina centro de costos" Then
                x = 5
            End If

            hoja_excel.Row(x).Style.Font.Bold = True
            hoja_excel.Row(x - 1).Style.Font.Italic = True



            If nombre_archivo = "Nómina centro de costos" Then
                hoja_excel.Row(x - 2).Style.Font.Bold = True
                hoja_excel.Row(x - 2).Style.Font.Italic = True
            End If


            For Each row_encabezado As DataRow In dtEncabezados.Select("", "orden")

                If row_encabezado("tipo") = "num" Then
                    If nombre_archivo = "Nómina centro de costos" Then
                        hoja_excel.Cells(x - 2, y).Value = row_encabezado("campo")
                        hoja_excel.Cells(x - 2, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x - 2, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)

                        hoja_excel.Cells(x - 1, y).Value = row_encabezado("cuenta")
                        hoja_excel.Cells(x - 1, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x - 1, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                    Else
                        hoja_excel.Cells(x - 1, y).Value = row_encabezado("campo")
                        hoja_excel.Cells(x - 1, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x - 1, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                    End If

                End If

                hoja_excel.Cells(x, y).Value = row_encabezado("encabezado")
                hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)


                y += 1
            Next

            x += 1
            y = 1

            If nombre_archivo = "Nómina detalle" Then
                dtDatos = dtDatos.Select("", "reloj").CopyToDataTable

                Try
                    dtDatos = dtDatos.Select("totper <> 0 or totded <> 0 or bondes <> 0", "reloj").CopyToDataTable
                Catch ex As Exception

                End Try

            End If

            For Each row_datos As DataRow In dtDatos.Rows

                If row_datos("totales") > IIf(ocultar_detalle, 2, 0) Then
                    hoja_excel.Row(x).Style.Font.Bold = True
                End If

                If ocultar_detalle Then
                    If row_datos("totales") < 2 Then
                        Continue For
                    End If
                End If

                For Each row_encabezados As DataRow In dtEncabezados.Select("", "orden")

                    Dim valor As String = IIf(IsDBNull(row_datos(row_encabezados("campo"))), "", row_datos(row_encabezados("campo")))

                    If row_encabezados("tipo") = "num" And valor <> "" Then
                        hoja_excel.Cells(x, y).Value = Double.Parse(row_datos(row_encabezados("campo")))
                        hoja_excel.Cells(x, y).Style.Numberformat.Format = "#,##0.00"
                    Else
                        hoja_excel.Cells(x, y).Value = row_datos(row_encabezados("campo"))
                    End If

                    If row_encabezados("enfasis") = 1 Then
                        hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                    End If

                    y += 1
                Next
                x += 1
                y = 1
            Next

            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()


            Dim periodos_titulo As String = ""
            For Each row_periodo As DataRow In dtPeriodos.Rows
                periodos_titulo &= row_periodo("ano") & "-" & row_periodo("periodo") & ", "
            Next
            periodos_titulo &= "_"
            periodos_titulo = periodos_titulo.Replace(", _", "")

            hoja_excel.Cells(1, 1).Value = "CTE"
            hoja_excel.Cells(1, 1).Style.Font.Bold = True
            hoja_excel.Cells(1, 1).Style.Font.Size = 12

            '   hoja_excel.Cells(2, 1).Value = nombre_archivo & " " & periodos_titulo
            hoja_excel.Cells(2, 1).Value = nombre_archivo & " " & anioPerTipo
            hoja_excel.Cells(2, 1).Style.Font.Bold = True

            Dim sfd As New SaveFileDialog
            sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            '   sfd.FileName = "OSC " & nombre_archivo & ".xlsx"
            Dim NameFile As String = ""

            If fromCondFinanzas Then NameFile = "CTE - FINANZAS-" & nombre_archivo & anioPerTipo Else NameFile = "CTE " & nombre_archivo & "_" & anioPerTipo
            sfd.FileName = NameFile & ".xlsx"
            sfd.Filter = "Archivo excel (xlsx)|*.xlsx"


            If (FromCondensado And PathSave.Trim <> "") Then  '- Si viene del condensado
                sfd.InitialDirectory = PathSave
                '   sfd.FileName = "OSC " & nombre_archivo & ".xlsx"
                If fromCondFinanzas Then NameFile = "CTE - FINANZAS-" & nombre_archivo Else NameFile = "CTE " & nombre_archivo
                sfd.FileName = NameFile & ".xlsx"
                sfd.Filter = "Archivo excel (xlsx)|*.xlsx"
                archivo.SaveAs(New System.IO.FileInfo(PathSave & sfd.FileName))
                GoTo Saltar1
            End If

            If sfd.ShowDialog() = DialogResult.OK Then
                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
            End If
Saltar1:
            System.Diagnostics.Process.Start(sfd.FileName)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    Public Sub VariablesExcel_Pro(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ocultar_detalle As Boolean, ocultar_totales_depto As Boolean, nombre_archivo As String, FromCondensado As Boolean, PathSave As String, _anio As String, _periodo As String)
        Try
            fromCondFinanzas = False ' Indica que no viene del condensando de finanzas
            Dim anioPerTipo As String = "Bimestre_" & _anio & "_" & _periodo

            '---Depurar dtInformacion, dejando solo a los empleados que estan en MovimientosPro
            dtInformacion.Columns.Add("apl", GetType(System.String))
            Dim dtRjMovsPro As DataTable = sqlExecute("SELECT DISTINCT RELOJ FROM variables_mov_pro", "NOMINA")
            If Not (dtRjMovsPro.Columns.Contains("Error") And dtRjMovsPro.Rows.Count > 0) Then
                Dim pos As Integer = 0
                For Each dr As DataRow In dtInformacion.Rows
                    dtInformacion.Rows(pos)("apl") = "n"
                    pos += 1
                Next

                For Each dr1 As DataRow In dtRjMovsPro.Rows
                    Dim rj As String = ""
                    Dim myRow() As DataRow
                    Try : rj = dr1("RELOJ").ToString.Trim : Catch ex As Exception : rj = "" : End Try

                    If (dtInformacion.Select("reloj='" & rj & "'").Count > 0) Then
                        myRow = dtInformacion.Select("reloj='" & rj & "'")
                        myRow(0)("apl") = "s"
                    End If

                Next
                '--Eliminar masivamente los que no apliquen
                Dim dElimina() As DataRow
                dElimina = dtInformacion.Select("apl ='n'")
                For Each del As DataRow In dElimina
                    dtInformacion.Rows.Remove(del)
                Next

            End If
            dtInformacion.Columns.Remove("apl")
            '---Ends Depura dtInformacion

            dtDatos = New DataTable

            Dim dtEncabezados As New DataTable
            dtEncabezados.Columns.Add("orden", Type.GetType("System.Int32"))
            dtEncabezados.Columns.Add("campo")
            dtEncabezados.Columns.Add("encabezado")
            dtEncabezados.Columns.Add("cuenta")
            dtEncabezados.Columns.Add("tipo")
            dtEncabezados.Columns.Add("enfasis")
            dtEncabezados.Columns.Add("bgcolor")

            ' Columnas principales que se mostraran 
            dtDatos.Columns.Add("totales")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("tipo_periodo")
            dtDatos.Columns.Add("cod_tipo")
            dtDatos.Columns.Add("cod_depto")
            dtDatos.Columns.Add("cod_puesto")
            dtDatos.Columns.Add("alta")
            dtDatos.Columns.Add("baja")
            dtDatos.Columns.Add("sactual")
            dtDatos.Columns.Add("factor_int")
            dtDatos.Columns.Add("pro_var")
            dtDatos.Columns.Add("integrado")
            dtDatos.Columns.Add("dias_trab")
            dtDatos.Columns.Add("dias_aus")
            dtDatos.Columns.Add("tot_dias")




            Dim dtPeriodos As DataTable = New DataTable
            dtPeriodos.Columns.Add("ano")
            dtPeriodos.Columns.Add("periodo")
            dtPeriodos.Columns.Add("tipo_periodo")
            dtPeriodos.PrimaryKey = New DataColumn() {dtPeriodos.Columns("ano"), dtPeriodos.Columns("periodo"), dtPeriodos.Columns("tipo_periodo")}

            Dim titulo_codigo As String = ""
            Dim titulo_nombre As String = ""

            If ocultar_detalle = True Then
                titulo_codigo = "Centro de costos"
                titulo_nombre = "Descripción"
            Else
                titulo_codigo = "Número de empleado"
                titulo_nombre = "Nombre completo"
            End If

            dtEncabezados.Rows.Add({1, "reloj", titulo_codigo, "", "", 0, "na"})
            dtEncabezados.Rows.Add({2, "nombres", titulo_nombre, "", "", 0, "na"})

            Dim siguiente_encabezado As Integer = 3

            If Not ocultar_detalle Then
                dtEncabezados.Rows.Add({3, "tipo_periodo", "Tipo de periodo", "", "", 0, "na"}) ' Columnas que se mostrarán
                dtEncabezados.Rows.Add({4, "cod_tipo", "Tipo de empleado", "", "", 0, "na"}) ' Columnas que se mostrarán
                dtEncabezados.Rows.Add({5, "cod_depto", "Depto", "", "", 0, "na"}) ' Columnas que se mostrarán
                dtEncabezados.Rows.Add({6, "cod_puesto", "Puesto", "", "", 0, "na"}) ' Columnas que se mostrarán
                dtEncabezados.Rows.Add({7, "alta", "Alta", "", "", 0, "na"})
                dtEncabezados.Rows.Add({8, "baja", "Baja", "", "", 0, "na"})
                dtEncabezados.Rows.Add({9, "sactual", "Sueldo", "", "", 0, "na"}) ' Columnas que se mostrarán
                dtEncabezados.Rows.Add({10, "factor_int", "FI", "", "", 0, "na"}) ' Columnas que se mostrarán
                dtEncabezados.Rows.Add({11, "pro_var", "Prom. Var", "", "", 0, "na"}) ' Columnas que se mostrarán
                dtEncabezados.Rows.Add({12, "integrado", "Int. Actual", "", "", 0, "na"})
                dtEncabezados.Rows.Add({13, "dias_trab", "Días", "", "", 0, "na"})
                dtEncabezados.Rows.Add({14, "dias_aus", "Ausentismo", "", "", 0, "na"})
                dtEncabezados.Rows.Add({15, "tot_dias", "Días total", "", "", 0, "na"})

                siguiente_encabezado = 16
            End If

            Dim dtGruposConceptos As New DataTable

            dtGruposConceptos.Columns.Add("orden", Type.GetType("System.Int32"))
            dtGruposConceptos.Columns.Add("nombre")
            dtGruposConceptos.Columns.Add("filtro")
            dtGruposConceptos.Columns.Add("enfasis", Type.GetType("System.Int32"))
            dtGruposConceptos.Columns.Add("bgcolor")

            '---Orden a mostrar en prioridad para los conceptos que va conformar el excel
            dtGruposConceptos.Rows.Add({1, "Bono de despensa", "concepto= 'BONDES'", 1, "nan"}) ' Ya lo incluye dentro de las percepciones
            dtGruposConceptos.Rows.Add({2, "Bono de asistencia", "concepto= 'BONASI'", 1, "nan"}) ' Ya lo incluye dentro de las percepciones
            dtGruposConceptos.Rows.Add({3, "Percepciones", "activo = '1' AND ISNULL(aplica_variable,0)=1 and concepto NOT IN ('BONDES','BONASI','TOTVAR')", 0, "nan"})
            dtGruposConceptos.Rows.Add({4, "Total acumulado", "concepto = 'TOTVAR'", 1, "nan"})

            For Each row_grupo As DataRow In dtGruposConceptos.Select("", "orden")
                Dim dtConceptosGrupo As DataTable = sqlExecute("select * from conceptos where " & row_grupo("filtro") & " order by prioridad", "nomina") ' Se mostrarán por orden de prioridad (conceptos.prioridad)

                For Each row_conceptos As DataRow In dtConceptosGrupo.Rows
                    Dim cuenta_contable As String = "-"
                    Dim concepto_codigo As String = RTrim(row_conceptos("concepto")).ToLower
                    Dim concepto_nombre As String = RTrim(row_conceptos("nombre"))


                    dtDatos.Columns.Add(concepto_codigo)
                    dtEncabezados.Rows.Add({siguiente_encabezado, concepto_codigo, concepto_nombre, cuenta_contable, "num", row_grupo("enfasis"), row_grupo("bgcolor")})
                    siguiente_encabezado += 1

                Next
            Next

            dtDatos.Columns.Add("nvo_antig")
            dtDatos.Columns.Add("nvo_fi")
            dtDatos.Columns.Add("nvo_provar")
            dtDatos.Columns.Add("nvo_integrado")
            dtDatos.Columns.Add("aplica")
            dtDatos.Columns.Add("comentario")

            dtEncabezados.Rows.Add({siguiente_encabezado, "nvo_antig", "Nueva antiguedad.", "", "", 0, "na"})
            dtEncabezados.Rows.Add({siguiente_encabezado + 1, "nvo_fi", "Nuevo F.I", "", "", 0, "na"})
            dtEncabezados.Rows.Add({siguiente_encabezado + 2, "nvo_provar", "Nuevo prom.var.", "", "", 0, "na"})
            dtEncabezados.Rows.Add({siguiente_encabezado + 3, "nvo_integrado", "Nuevo Integrado", "", "", 0, "na"})
            dtEncabezados.Rows.Add({siguiente_encabezado + 4, "aplica", "Aplica", "", "", 0, "na"})
            dtEncabezados.Rows.Add({siguiente_encabezado + 5, "comentario", "Comentario", "", "", 0, "na"})

            Dim frm As New frmTrabajando
            frm.lblAvance.Text = ""
            frm.Show()

            Dim dtCentrosDeCostos As DataTable = sqlExecute("select * from c_costos")

            Dim drow_total_general As DataRow = dtDatos.NewRow
            drow_total_general("totales") = 3
            drow_total_general("reloj") = "Total Gral."

            For Each row_cc As DataRow In dtInformacion.Rows
                frm.lblAvance.Text = row_cc("reloj")
                Application.DoEvents()

                Dim drow_grupo As DataRow = dtDatos.NewRow
                drow_grupo("totales") = 2
                drow_grupo("reloj") = row_cc("reloj")
                drow_grupo("nombres") = row_cc("nombres")

                If ocultar_totales_depto = False Then
                    dtDatos.Rows.Add(drow_grupo)
                End If

                Dim drow_totales As DataRow = dtDatos.NewRow
                drow_totales("totales") = 1
                drow_totales("reloj") = "Total Depto"

                drow_totales("totales") = 1

                Dim drow_vacia As DataRow = dtDatos.NewRow
                drow_vacia("totales") = 1

                Try
                    Dim drow_periodo As DataRow = dtPeriodos.NewRow

                    drow_periodo("ano") = row_cc("ano")
                    drow_periodo("periodo") = row_cc("bimestre")
                    drow_periodo("tipo_periodo") = row_cc("tipo_periodo")
                    dtPeriodos.Rows.Add(drow_periodo)
                Catch ex As Exception

                End Try

                Application.DoEvents()

                Dim drow As DataRow = dtDatos.NewRow
                drow("totales") = 0


                For Each row_encabezado As DataRow In dtEncabezados.Rows ' Evalua y da el valor para cada uno de los campos a ingresar en el excel
                    Dim campo_ As String = row_encabezado("campo")

                    Try
                        Dim valor As String = row_cc(row_encabezado("campo")) 'Es el valor de acuerdo al campo que esta buscando.
                        drow(campo_) = valor

                        If row_encabezado("tipo") = "num" Then
                            If IsDBNull(drow(campo_)) Then
                                drow(campo_) = 0
                            End If

                            If ocultar_detalle = True Then
                                drow_grupo(campo_) = Double.Parse(IIf(IsDBNull(drow_grupo(campo_)), 0, drow_grupo(campo_))) + Double.Parse(drow(campo_))
                            Else
                                drow_totales(campo_) = Double.Parse(IIf(IsDBNull(drow_totales(campo_)), 0, drow_totales(campo_))) + Double.Parse(drow(campo_))
                            End If

                            drow_total_general(campo_) = Double.Parse(IIf(IsDBNull(drow_total_general(campo_)), 0, drow_total_general(campo_))) + Double.Parse(drow(campo_))

                        End If

                    Catch ex As Exception
                        drow(campo_) = 0
                    End Try

                Next

                dtDatos.Rows.Add(drow)


                If ocultar_totales_depto = False Then
                    dtDatos.Rows.Add(drow_totales)
                    dtDatos.Rows.Add(drow_vacia)
                End If

            Next

            dtDatos.Rows.Add(drow_total_general)

            ActivoTrabajando = False
            frm.Close()

            Dim archivo As ExcelPackage = New ExcelPackage()
            Dim wb As ExcelWorkbook = archivo.Workbook
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("nomina")

            Dim x As Integer = 4
            Dim y As Integer = 1


            hoja_excel.Row(x).Style.Font.Bold = True
            hoja_excel.Row(x - 1).Style.Font.Italic = True



            For Each row_encabezado As DataRow In dtEncabezados.Select("", "orden")
                If row_encabezado("tipo") = "num" Then

                    hoja_excel.Cells(x - 1, y).Value = row_encabezado("campo")
                    hoja_excel.Cells(x - 1, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    hoja_excel.Cells(x - 1, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                End If


                hoja_excel.Cells(x, y).Value = row_encabezado("encabezado")
                hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)


                y += 1

            Next

            x += 1
            y = 1

            For Each row_datos As DataRow In dtDatos.Rows

                If row_datos("totales") > IIf(ocultar_detalle, 2, 0) Then
                    hoja_excel.Row(x).Style.Font.Bold = True
                End If

                If ocultar_detalle Then
                    If row_datos("totales") < 2 Then
                        Continue For
                    End If
                End If

                For Each row_encabezados As DataRow In dtEncabezados.Select("", "orden")

                    Dim valor As String = IIf(IsDBNull(row_datos(row_encabezados("campo"))), "", row_datos(row_encabezados("campo")))

                    If row_encabezados("tipo") = "num" And valor <> "" Then
                        hoja_excel.Cells(x, y).Value = Double.Parse(row_datos(row_encabezados("campo")))
                        hoja_excel.Cells(x, y).Style.Numberformat.Format = "#,##0.00"
                    Else
                        hoja_excel.Cells(x, y).Value = row_datos(row_encabezados("campo"))
                    End If

                    If row_encabezados("enfasis") = 1 Then
                        hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                    End If

                    y += 1
                Next
                x += 1
                y = 1
            Next

            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

            Dim periodos_titulo As String = ""
            For Each row_periodo As DataRow In dtPeriodos.Rows
                periodos_titulo &= row_periodo("ano") & "-" & row_periodo("periodo") & ", "
            Next
            periodos_titulo &= "_"
            periodos_titulo = periodos_titulo.Replace(", _", "")

            hoja_excel.Cells(1, 1).Value = "CTE"
            hoja_excel.Cells(1, 1).Style.Font.Bold = True
            hoja_excel.Cells(1, 1).Style.Font.Size = 12

            hoja_excel.Cells(2, 1).Value = nombre_archivo & " " & anioPerTipo
            hoja_excel.Cells(2, 1).Style.Font.Bold = True

            Dim sfd As New SaveFileDialog
            sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            Dim NameFile As String = ""

            NameFile = "CTE " & nombre_archivo & "_" & anioPerTipo
            sfd.FileName = NameFile & ".xlsx"
            sfd.Filter = "Archivo excel (xlsx)|*.xlsx"

            If (FromCondensado And PathSave.Trim <> "") Then  '- Si viene del condensado
                sfd.InitialDirectory = PathSave
                '   sfd.FileName = "OSC " & nombre_archivo & ".xlsx"
                NameFile = "CTE " & nombre_archivo
                sfd.FileName = NameFile & ".xlsx"
                sfd.Filter = "Archivo excel (xlsx)|*.xlsx"
                archivo.SaveAs(New System.IO.FileInfo(PathSave & sfd.FileName))
                GoTo Saltar1
            End If

            If sfd.ShowDialog() = DialogResult.OK Then
                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
            End If
Saltar1:
            System.Diagnostics.Process.Start(sfd.FileName)


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Nominaed.vb", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

    '== Reporte de percepciones anuales de empleados                20octo2021
    Public Sub ReportePerTotEmpAnual(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtEstructura As New DataTable
            Dim dtConceptos As New DataTable
            Dim dtMontos As New DataTable
            Dim newRow As DataRow
            Dim Qry As String = ""
            Dim cont As Integer = 3
            Dim orden As Integer = 0
            Dim _reloj As String = ""
            Dim _concepto As String = ""

            '== Seleccionar año para el reporte
            Dim _seleccionaAnio As New frmseleccionarano
            _seleccionaAnio.ShowDialog()

            If _seleccionaAnio.DialogResult = DialogResult.OK Then
                '== Columnas para datatable de reporte
                dtEstructura = DataTableColEsencial("cod_comp,reloj,nombres,alta,baja,tipo_periodo,concepto,percepciones,cantidad,orden,orden_per", "String,String," &
                                                    "String,String,String,String,String,String,String,Int,Int")

                '== Se obtienen los distintos concepto del año presente
                Qry = "select distinct rtrim(m.CONCEPTO) as concepto,rtrim(c.EXENTO) as exento,rtrim(c.nombre) as nom_concepto," & _
                        "CAST(NULL AS INT) AS orden from NOMINA.dbo.movimientos m " & _
                        "left outer join NOMINA.dbo.conceptos c on c.CONCEPTO = m.CONCEPTO " & _
                        "where m.ano='" & anioSel & "' and c.COD_NATURALEZA='P'"

                dtConceptos = sqlExecute(Qry)

                '== Orden de los conceptos
                For Each x As DataRow In dtConceptos.Rows()
                    If x.Item("nom_concepto").ToString <> "Percepción Normal" And x.Item("nom_concepto").ToString <> "Percepción Extra Doble" And
                        x.Item("nom_concepto").ToString <> "Percepción Extra Triple" Then
                        cont = cont + 1
                        x.Item("orden") = cont
                    ElseIf x.Item("nom_concepto") = "Percepción Normal" Then
                        x.Item("orden") = 1
                    ElseIf x.Item("nom_concepto") = "Percepción Extra Doble" Then
                        x.Item("orden") = 2
                    ElseIf x.Item("nom_concepto") = "Percepción Extra Triple" Then
                        x.Item("orden") = 3
                    End If
                Next

                '== Empleados de la tabla isr_nom_pro
                Dim total_registros As Integer = 0
                cont = 0

                '== Cargando la informacion
                frmTrabajando.Text = "Percepciones empleado anual"
                frmTrabajando.Show()
                frmTrabajando.Avance.Value = 0
                frmTrabajando.Avance.IsRunning = False
                frmTrabajando.lblAvance.Font = New Font("", 10)
                frmTrabajando.lblAvance.Text = "Preparando información"
                frmTrabajando.Avance.IsRunning = True
                Application.DoEvents()

                total_registros = dtInformacion.Rows.Count * dtConceptos.Rows.Count * 3

                frmTrabajando.Avance.Maximum = total_registros
                frmTrabajando.Avance.Value = 0
                frmTrabajando.Avance.IsRunning = False

                '== Hacer cálculo de los montos
                dtMontos = DataTableColEsencial("reloj,concepto,per,grav,exe", "String,String,String,String,String")
                'CalculaMonto(dtInformacion, dtConceptos, dtMontos)

                '== Asigna la información al dataset para el report
                For Each x As DataRow In dtInformacion.Select("cod_comp='CTE'", "reloj")
                    For Each y As DataRow In dtConceptos.Select("concepto is not null", "orden")
                        Dim varReloj As String = x.Item("reloj").ToString.Trim
                        Dim varCon As String = y.Item("concepto").ToString
                        CalculaMonto(anioSel, dtInformacion, dtConceptos, dtMontos, varCon, varReloj)
                        While cont < 3
                            newRow = Nothing
                            newRow = dtEstructura.NewRow
                            _reloj = x("reloj").ToString.Trim
                            _concepto = y.Item("concepto")

                            newRow.Item("cod_comp") = x("cod_comp").ToString.Trim
                            newRow.Item("reloj") = _reloj
                            newRow.Item("nombres") = x("nombres").ToString.Trim
                            newRow.Item("alta") = FechaSQL(x("alta"))
                            Try : newRow.Item("baja") = FechaSQL(x("baja")) : Catch ex As Exception : newRow.Item("baja") = "---" : End Try
                            newRow.Item("tipo_periodo") = x("tipo_periodo").ToString.Trim
                            newRow.Item("concepto") = _concepto
                            newRow.Item("percepciones") = IIf(cont = 0, y.Item("nom_concepto").ToString,
                                                                                      IIf(cont = 1, "Gravable " & y.Item("nom_concepto"), "Exento " & y.Item("nom_concepto")))
                            newRow.Item("cantidad") = IIf(cont = 0, ObtenerMonto(dtMontos, _reloj, _concepto, "per"),
                                                                              IIf(cont = 1, ObtenerMonto(dtMontos, _reloj, _concepto, "grav"), ObtenerMonto(dtMontos, _reloj, _concepto, "exe")))
                            newRow.Item("orden") = y.Item("orden")
                            newRow.Item("orden_per") = orden
                            dtEstructura.Rows.Add(newRow)
                            cont += 1
                            orden += 1
                        End While
                        dtMontos.Rows.Clear()
                        cont = 0
                    Next
                    frmTrabajando.Avance.Value = orden
                    frmTrabajando.lblAvance.Text = x.Item("reloj").ToString.Trim
                    My.Application.DoEvents()
                Next

                dtDatos = dtEstructura.Copy

                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    '== Segunda función para calcular el monto de las percepciones anuales por empleado             21oct2021
    Private Sub CalculaMonto(anioSelect As String, ByVal dtInfo As DataTable, ByVal dtCon As DataTable, ByRef dtMonto As DataTable, Optional c As String = "", Optional clock As String = "")
        Try
            Dim Qry As String = "" : Dim newRow As DataRow
            Dim filtro1 As String = "concepto='" & c & "'"
            Dim filtro2 As String = "reloj='" & clock & "'"

            For Each concepto As DataRow In dtCon.Select(filtro1)
                For Each emp As DataRow In dtInfo.Select(filtro2)
                    newRow = dtMonto.NewRow
                    Dim _concep As String = concepto.Item("concepto").ToString.Trim
                    Dim _reloj As String = emp.Item("reloj").ToString.Trim
                    Dim _per1 As Double = 0.0
                    newRow.Item("reloj") = _reloj
                    newRow.Item("concepto") = _concep
                    '== Cálculo de valores
                    Qry = "select ISNULL(SUM(convert(float,monto)),0) AS 'monto' from NOMINA.dbo.movimientos " & _
                                "where  ANO='" & anioSelect & "' and concepto='" & _concep & "' AND reloj='" & _reloj & "' "
                    Dim dtTemp As DataTable = sqlExecute(Qry)
                    If dtTemp.Rows.Count > 0 Then
                        newRow.Item("per") = dtTemp.Rows(0)("monto").ToString
                        _per1 = Math.Round(CDbl(dtTemp.Rows(0)("monto")), 2)
                        If concepto.Item("exento").ToString.Length < 1 Then
                            newRow.Item("grav") = dtTemp.Rows(0)("monto").ToString
                            newRow.Item("exe") = "0"
                        ElseIf concepto.Item("concepto").ToString = concepto.Item("exento") Then
                            newRow.Item("grav") = "0"
                            newRow.Item("per") = dtTemp.Rows(0)("monto").ToString
                            newRow.Item("exe") = dtTemp.Rows(0)("monto").ToString
                        Else
                            _concep = concepto.Item("exento").ToString
                            Qry = "select ISNULL(SUM(convert(float,monto)),0) AS 'monto' from NOMINA.dbo.movimientos " & _
                                "where  ANO='" & anioSelect & "' and concepto='" & _concep & "' AND reloj='" & _reloj & "' "
                            dtTemp = sqlExecute(Qry)
                            If dtTemp.Rows.Count > 0 Then
                                Dim r As Double = 0.0
                                r = Math.Round(_per1 - CDbl(dtTemp.Rows(0)("monto")), 2)
                                newRow.Item("grav") = r.ToString
                                newRow.Item("exe") = dtTemp.Rows(0)("monto").ToString
                            End If
                        End If
                        dtMonto.Rows.Add(newRow)
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub

    '== Tercera función para consultar el monto de las percepciones anuales por empleado            21oct2021
    Private Function ObtenerMonto(ByVal dtMonto As DataTable, reloj As String, concepto As String, per As String) As String
        Try
            Dim filtro As String = "reloj='" & reloj & "' and concepto='" & concepto & "'"
            Dim resultado As String = ""

            For Each x As DataRow In dtMonto.Select(filtro)
                resultado = "$" & x.Item(per).ToString
            Next

            Return resultado
        Catch ex As Exception
            Return "Error"
        End Try
    End Function


    '== Reporte de percepciones mensuales de empleados                21feb22           Ernesto
    Public dtaux As New DataTable ''Para pasar los datos de #reloj al combobox en frmSelPerNominaReporte.vb
    '== Anio y periodo del reporteador de nomina            24feb22
    Public AnioPeriodoReporteadorNom As New ArrayList

    ''' <summary>
    ''' Reporte de acumulado mensual de cte -- Ernesto -- 16 oct 2024
    ''' </summary>
    ''' <param name="dtDatos"></param>
    ''' <param name="dtInformacion"></param>
    ''' <remarks></remarks>
    Public Sub ReportePerTotEmpMensualQro(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtEstructura As New DataTable
            Dim dtConceptos As New DataTable
            Dim dtAuxiliares As New DataTable
            Dim dtDetallesConceptos As New DataTable
            Dim dtDetallesConceptosBonos As New DataTable
            Dim dtTemp As New DataTable

            Dim listPer As New ArrayList
            Dim newRow As DataRow
            Dim _Qry As String = ""
            Dim _cont As Integer = 0
            Dim _total As Double = 0.0
            Dim _reloj As String = ""
            Dim _concepto As String = ""
            Dim _nomConcepto As String = ""
            Dim _cadena As String = ""
            Dim _totalRegistros As Integer = 0
            Dim _avance As Integer = 0
            Dim _cantDec As String = ""
            Dim _ordenPertot As Integer = 0
            Dim _ordenBondes As Integer = 0

            Dim _sindicalizado As String = ""
            Dim _tipoCre As String = ""
            Dim _pagoInf As String = ""

            '== Ventana para seleccionar relojes
            dtaux = dtInformacion.DefaultView.ToTable(False, New String() {"RELOJ"}) ''Pasa solo la columna de #reloj

            'Dim selReloj As New frmSelPerNominaReporte
            Dim lstRelojes = (From i In dtaux Select i("reloj").ToString.Trim).ToList

            'If selReloj.ShowDialog = DialogResult.OK Then

            '== Para relojes seleccionados
            'lstRelojes = selReloj.lstRelojesSel
            dtAuxiliares = DataTableColEsencial("reloj,sindicalizado,tipo_cre,pago_inf", "String,String,String,String")

            For Each x As String In lstRelojes

                If dtAuxiliares.Select("reloj='" & x & "'").Any Then Continue For

                Dim row As DataRow = dtAuxiliares.NewRow
                row.Item("reloj") = x

                _Qry = "select sindicalizado,tipo_cre,pago_inf from personal.dbo.personal where reloj='" & x & "'"
                dtTemp = sqlExecute(_Qry)
                If dtTemp.Rows.Count > 0 Then
                    Try : row.Item("sindicalizado") = dtTemp.Rows(0)("sindicalizado") : Catch ex As Exception : row.Item("sindicalizado") = "- -" : End Try
                    Try : row.Item("tipo_cre") = dtTemp.Rows(0)("tipo_cre") : Catch ex As Exception : row.Item("tipo_cre") = "- -" : End Try
                    Try : row.Item("pago_inf") = dtTemp.Rows(0)("pago_inf") : Catch ex As Exception : row.Item("pago_inf") = "- -" : End Try
                End If

                dtAuxiliares.Rows.Add(row)
            Next

            '== Columnas para datatable de reporte
            dtEstructura = DataTableColEsencial("ano,periodo,reloj,nombres,cod_tipo,cod_clase,rfc,cod_depto,centro_costos,num_imss,alta,alta_antig,baja,sactual,integrado,cod_puesto,puesto,sindicalizado,tipo_credito,factor_infonavit,concepto,nom_concepto,cantidad,orden,tipo_fila",
                                                "String,String,String,String,String,String,String,String,String,String,String,String,String,String,String,String,String,String,String,String,String,String,Double,Int,Int")

            If dtAuxiliares.Rows.Count > 0 Then

                '== Se obtienen el anio y periodo con los que se trabajaran
                For Each emp As DataRow In dtAuxiliares.Rows
                    _reloj = emp.Item("reloj").ToString.Trim

                    '== Año y periodo distintos
                    For Each x As DataRow In dtInformacion.Select("reloj='" & _reloj & "'")
                        Dim anoPeriodo As String = x.Item("ano").ToString.Trim & x.Item("periodo").ToString.Trim
                        If Not listPer.Contains(anoPeriodo) Then
                            listPer.Add(anoPeriodo)
                            _cadena &= "'" & anoPeriodo & "',"
                        End If
                    Next
                Next

                '== Inicializa la tabla conceptos
                dtConceptos = DataTableColEsencial("concepto,nombre,nat,orden", "String,String,String,Int")

                '======================== CONCEPTOS===========================
                '== Percepciones y deducciones
                Dim naturaleza As String = ""

                For i As Integer = 0 To 1

                    If i = 0 Then naturaleza = "'P'" Else naturaleza = "'D'"

                    _Qry = "select distinct m.concepto,n.detalle,n.nombre as nombre_concepto, (select NOMBRE from nomina.dbo.conceptos where CONCEPTO=n.detalle) as nombre_detalle " & _
                                          "from nomina.dbo.movimientos m left join nomina.dbo.conceptos n on m.concepto=n.concepto " & _
                                          "where ano+periodo in ([anioper]) and n.cod_naturaleza=[nat] order by m.CONCEPTO asc"
                    _Qry = _Qry.Replace("[anioper]", _cadena.Substring(0, _cadena.Length - 1))
                    _Qry = _Qry.Replace("[nat]", naturaleza)
                    dtDetallesConceptos = sqlExecute(_Qry)
                    newRow = Nothing : newRow = dtConceptos.NewRow

                    For Each p As DataRow In dtDetallesConceptos.Rows
                        newRow = Nothing : newRow = dtConceptos.NewRow
                        If Not IsDBNull(p.Item("detalle")) Then
                            newRow.Item("concepto") = p.Item("detalle").ToString.Trim : newRow.Item("nombre") = p.Item("nombre_detalle").ToString.Trim : newRow.Item("nat") = IIf(i < 1, "P", "D")
                            dtConceptos.Rows.Add(newRow) : newRow = dtConceptos.NewRow

                            newRow.Item("concepto") = p.Item("concepto").ToString.Trim : newRow.Item("nombre") = p.Item("nombre_concepto").ToString.Trim : newRow.Item("nat") = IIf(i < 1, "P", "D")
                            dtConceptos.Rows.Add(newRow)
                            Continue For
                        End If
                        newRow.Item("concepto") = p.Item("concepto").ToString.Trim : newRow.Item("nombre") = p.Item("nombre_concepto").ToString.Trim : newRow.Item("nat") = IIf(i < 1, "P", "D")
                        dtConceptos.Rows.Add(newRow)
                    Next

                    newRow = Nothing : newRow = dtConceptos.NewRow
                    newRow.Item("concepto") = IIf(i < 1, "TOTPER", "TOTDED") : newRow.Item("nombre") = IIf(i < 1, "PERCEPCIÓN TOTAL", "TOTAL DEDUCCIONES") : newRow.Item("nat") = IIf(i < 1, "P", "D")
                    dtConceptos.Rows.Add(newRow)


                    '--------Jose Mata se incluyeron los conceptos de bonos
                    If i = 1 Then
                        _Qry = "select distinct m.concepto,n.detalle,n.nombre as nombre_concepto, (select NOMBRE from nomina.dbo.conceptos where CONCEPTO=n.detalle) as nombre_detalle " & _
                                          "from nomina.dbo.movimientos m left join nomina.dbo.conceptos n on m.concepto=n.concepto " & _
                                          "where ano+periodo in ([anioper]) and n.cod_naturaleza=[nat] order by m.CONCEPTO asc"
                        _Qry = _Qry.Replace("[anioper]", _cadena.Substring(0, _cadena.Length - 1))
                        _Qry = _Qry.Replace("[nat]", "'B'")
                        dtDetallesConceptosBonos = sqlExecute(_Qry)
                        For Each b As DataRow In dtDetallesConceptosBonos.Rows
                            newRow = Nothing : newRow = dtConceptos.NewRow
                            newRow.Item("concepto") = b.Item("concepto").ToString.Trim : newRow.Item("nombre") = b.Item("nombre_concepto").ToString.Trim : newRow.Item("nat") = "B"
                            dtConceptos.Rows.Add(newRow)
                        Next
                    End If

                    '== Orden de conceptos
                    For Each ord As DataRow In dtConceptos.Rows
                        If ord.Item("nat") = IIf(i < 1, "P", "D") Then
                            ord.Item("orden") = _cont
                            _cont += 1
                        End If
                    Next
                    '----Orden para conceptos de bonos
                    For Each ordb As DataRow In dtConceptos.Rows
                        If ordb.Item("nat") = "B" Then
                            ordb.Item("orden") = _cont
                            _cont += 1
                        End If
                    Next
                Next

                '== Neto al final del reporte
                newRow = Nothing : newRow = dtConceptos.NewRow
                newRow.Item("concepto") = "NETO" : newRow.Item("nombre") = "NETO" : newRow.Item("orden") = _cont
                dtConceptos.Rows.Add(newRow) : newRow = Nothing
                _cont = 0

                '======================== FIN CONCEPTOS===========================

                '== Cargando la informacion
                frmTrabajando.Text = "Resumen movimientos mensual"
                frmTrabajando.Show()
                frmTrabajando.Avance.Value = 0
                frmTrabajando.Avance.IsRunning = False
                frmTrabajando.lblAvance.Font = New Font("", 9)
                frmTrabajando.lblAvance.Text = "Preparando información"
                frmTrabajando.Avance.IsRunning = True
                Application.DoEvents()

                _totalRegistros = listPer.Count * dtConceptos.Rows.Count * dtAuxiliares.Rows.Count

                frmTrabajando.Avance.Maximum = _totalRegistros
                frmTrabajando.Avance.Value = 0
                frmTrabajando.Avance.IsRunning = False

                '== Llenar datatable con valores de conceptos
                For Each anoPer As String In listPer
                    _cadena = ""

                    For Each aux As DataRow In dtAuxiliares.Rows
                        _reloj = aux.Item("reloj").ToString.Trim
                        _sindicalizado = aux.Item("sindicalizado").ToString
                        _tipoCre = aux.Item("tipo_cre").ToString
                        _pagoInf = aux.Item("pago_inf").ToString

                        _cadena = "reloj='" & _reloj & "' and ano+periodo='" & anoPer & "'"
                        _total = 0.0

                        For Each concep As DataRow In dtConceptos.Rows
                            _concepto = concep.Item("concepto").ToString.Trim
                            _nomConcepto = concep.Item("nombre").ToString.Trim

                            For Each info As DataRow In dtInformacion.Select(_cadena)
                                newRow = dtEstructura.NewRow
                                newRow.Item("reloj") = _reloj
                                newRow.Item("nombres") = info.Item("nombres").ToString.Trim
                                newRow.Item("cod_depto") = IIf((info.Item("cod_depto").ToString.Trim).Length < 2, "- -", info.Item("cod_depto").ToString.Trim)
                                newRow.Item("cod_puesto") = IIf((info.Item("cod_puesto").ToString.Trim).Length < 2, "- -", info.Item("cod_puesto").ToString.Trim)
                                newRow.Item("cod_tipo") = IIf((info.Item("cod_tipo").ToString.Trim).Length < 1, "- -", info.Item("cod_tipo").ToString.Trim)
                                newRow.Item("cod_clase") = IIf((info.Item("cod_clase").ToString.Trim).Length < 1, "- -", info.Item("cod_clase").ToString.Trim)
                                newRow.Item("rfc") = IIf((info.Item("rfc").ToString.Trim).Length < 2, "- -", info.Item("rfc").ToString.Trim)
                                newRow.Item("centro_costos") = IIf((info.Item("centro_costos").ToString.Trim).Length < 2, "- -", info.Item("centro_costos").ToString.Trim)
                                newRow.Item("num_imss") = IIf((info.Item("numimss").ToString.Trim).Length < 2, "- -", info.Item("numimss").ToString.Trim)
                                Try : newRow.Item("alta_antig") = FechaSQL(info.Item("alta_vacacion")) : Catch ex As Exception : newRow.Item("alta_antig") = "- -" : End Try
                                newRow.Item("sactual") = IIf((info.Item("sactual").ToString.Trim).Length < 2, "- -", info.Item("sactual").ToString.Trim)
                                newRow.Item("integrado") = IIf((info.Item("integrado").ToString.Trim).Length < 2, "- -", info.Item("integrado").ToString.Trim)
                                newRow.Item("puesto") = IIf((info.Item("nombre_puesto").ToString.Trim).Length < 2, "- -", info.Item("nombre_puesto").ToString.Trim)
                                newRow.Item("sindicalizado") = _sindicalizado
                                newRow.Item("tipo_credito") = _tipoCre
                                newRow.Item("factor_infonavit") = _pagoInf

                                newRow.Item("alta") = FechaSQL(info.Item("alta"))
                                Try : newRow.Item("baja") = FechaSQL(info.Item("baja")) : Catch ex As Exception : newRow.Item("baja") = "- -" : End Try
                                newRow.Item("Ano") = anoPer.Substring(0, 4)
                                newRow.Item("Periodo") = anoPer.Substring(4, 2)
                                newRow.Item("concepto") = _concepto
                                newRow.Item("nom_concepto") = _nomConcepto

                                '== Cantidad de dos decimales
                                Try : _cantDec = Math.Round(info.Item(_concepto), 2) : Catch ex As Exception : _cantDec = 0.0 : End Try
                                newRow.Item("cantidad") = _cantDec

                                Try : newRow.Item("orden") = concep.Item("orden") : Catch ex As Exception : newRow.Item("orden") = 0 : End Try
                                newRow.Item("tipo_fila") = 0
                                dtEstructura.Rows.Add(newRow) : newRow = Nothing
                                _avance += 1
                            Next
                        Next

                        '== Avance forma
                        frmTrabajando.Avance.Value = _avance
                        frmTrabajando.lblAvance.Text = "Reloj: " & _reloj & " AñoPeriodo: " & anoPer
                        My.Application.DoEvents()
                    Next
                Next

                '== Totales de cada concepto por reloj
                If dtEstructura.Rows.Count > 0 Then
                    Dim lstConceptos = Nothing
                    Dim lstReloj = (From i In dtEstructura Select i("reloj").ToString.Trim).ToList.Distinct

                    For Each r In lstReloj
                        lstConceptos = (From i In dtEstructura Where i("reloj") = r Select i("concepto").ToString.Trim).ToList.Distinct

                        For Each c In lstConceptos
                            Dim nRow As DataRow = dtEstructura.NewRow
                            Dim total = dtEstructura.Compute("sum(cantidad)", "reloj='" & r & "' and concepto='" & c & "'")

                            For Each dCol As DataColumn In dtEstructura.Columns
                                Dim strCol = dCol.ColumnName
                                If strCol = "reloj" Then nRow(strCol) = r : Continue For
                                If strCol = "nombres" Then nRow(strCol) = "Total " & r : Continue For
                                If strCol = "concepto" Then nRow(strCol) = c : Continue For
                                If strCol = "cantidad" Then nRow(strCol) = total : Continue For
                                If strCol = "tipo_fila" Then nRow(strCol) = 1 : Continue For
                                nRow(strCol) = DBNull.Value
                            Next

                            dtEstructura.Rows.Add(nRow)
                        Next
                    Next

                    '== Total de totales
                    lstConceptos = (From i In dtEstructura Select i("concepto").ToString.Trim).ToList.Distinct

                    For Each c In lstConceptos
                        Dim strFiltro = "concepto='" & c & "' and tipo_fila=1"
                        Dim nRow As DataRow = dtEstructura.NewRow
                        Dim total = Math.Round(dtEstructura.Compute("sum(cantidad)", strFiltro), 2)

                        For Each dCol As DataColumn In dtEstructura.Columns
                            Dim strCol = dCol.ColumnName
                            If strCol = "reloj" Then nRow(strCol) = "99999" : Continue For
                            If strCol = "factor_infonavit" Then nRow(strCol) = "TOTALES" : Continue For
                            If strCol = "concepto" Then nRow(strCol) = c : Continue For
                            If strCol = "cantidad" Then nRow(strCol) = total : Continue For
                            If strCol = "tipo_fila" Then nRow(strCol) = 2 : Continue For
                            nRow(strCol) = DBNull.Value
                        Next

                        dtEstructura.Rows.Add(nRow)
                    Next
                End If

                dtDatos = dtEstructura.Copy
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                dtaux.Clear()
            End If
            'End If

        Catch ex As Exception
            'ErrorLog("PIDA", System.Reflection.MethodBase.GetCurrentMethod.Name(), "", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de tiempos extras y bonos administrativos -- Ernesto - 23 oct 2024
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReporteTiempoExtraBonosAdmin(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try : frmReporteTEBonosProd.Show() : Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Se obtienen los totales por conceptos y periodos seleccionados por el usuario
    ''' </summary>
    ''' <param name="dtDatos"></param>
    ''' <param name="dtInformacion"></param>
    ''' <remarks></remarks>
    Public Sub ReporteTotalesConcepto(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            If dtInformacion.Rows.Count > 0 Then

                Dim dtCias = sqlExecute("select rtrim(cod_comp) as comp from personal.dbo.cias where cia_default=1")
                Dim strCias = If(dtCias.Rows.Count > 0, dtCias.Rows(0)("comp"), "")
                Dim strReporte = strCias & " " & "Reporte totales por concepto"

                Dim sfd As New SaveFileDialog
                Dim NameFile As String = strReporte & "_" & FechaSQL(Date.Now)
                sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                sfd.FileName = NameFile & ".xlsx"
                sfd.Filter = "Archivo excel (xlsx)|*.xlsx"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim lstPeriodos = String.Join(",", (From j In dtInformacion Select j("periodo").ToString.Trim).ToList.Distinct)
                    Dim lstAnios = String.Join(",", (From j In dtInformacion Select j("ano").ToString.Trim).ToList.Distinct)

                    '-- Conceptos de la informacion de nómina(s) seleccionada(s)
                    Dim dtNomina = sqlExecute("DECLARE @columns AS NVARCHAR(MAX), @sql AS NVARCHAR(MAX); " &
                                            "with percepciones AS ( " &
                                            "select distinct m.concepto from nomina.dbo.movimientos m " &
                                            "left join nomina.dbo.conceptos c on c.concepto=m.concepto " &
                                            "where ano in (" & lstAnios & ") and periodo in (" & lstPeriodos & ") and c.COD_NATURALEZA='P' " &
                                            "UNION ALL SELECT 'TOTPER' " &
                                            "), " &
                                            "deducciones AS ( " &
                                            "select distinct m.concepto from nomina.dbo.movimientos m " &
                                            "left join nomina.dbo.conceptos c on c.concepto=m.concepto " &
                                            "where ano in (" & lstAnios & ") and periodo in (" & lstPeriodos & ") and c.COD_NATURALEZA='D' " &
                                            "UNION ALL SELECT 'TOTDED' UNION ALL SELECT 'NETO' " &
                                            "), " &
                                            "lstConcepto as ( " &
                                            "(SELECT * FROM percepciones) UNION ALL (SELECT * FROM deducciones)) " &
                                            "" &
                                            "SELECT @columns = STUFF((" &
                                            "    SELECT ',' + QUOTENAME(concepto) " &
                                            "    FROM (SELECT DISTINCT concepto FROM lstConcepto) AS concept " &
                                            "    FOR XML PATH('')), 1, 1, ''); " &
                                            "" &
                                            "set @sql= N'SELECT reloj, nombres, cod_depto,nombre_depto,cod_puesto,  " &
                                            "		 nombre_puesto,numero_seguro_social,rfc,curp,alta,alta_antiguedad,baja,sueldo_actual,integrado,  " &
                                            "		 tipo_credito,factor_infonavit,'+@columns+N' " &
                                            "        FROM " &
                                            "		 (SELECT rtrim(m.reloj) as RELOJ,rtrim(p.nombres) as NOMBRES,rtrim(p.cod_tipo) as COD_TIPO,rtrim(p.cod_clase) as COD_CLASE, " &
                                            "		 rtrim(p.rfc) as RFC,rtrim(p.cod_depto) as COD_DEPTO,rtrim(p.nombre_depto) as NOMBRE_DEPTO,rtrim(p.cod_puesto) as COD_PUESTO,  " &
                                            "		 rtrim(p.nombre_puesto) as NOMBRE_PUESTO,rtrim(p.imss) as NUMERO_SEGURO_SOCIAL, " &
                                            "		 rtrim(p.curp) as curp,p.alta as ALTA,p.alta_vacacion as ALTA_ANTIGUEDAD,p.baja,p.sactual as SUELDO_ACTUAL,p.integrado as INTEGRADO, " &
                                            "		 p.tipo_cre as TIPO_CREDITO,p.PAGO_INF as FACTOR_INFONAVIT, " &
                                            "		 RTRIM(concepto) AS CONCEPTO, monto " &
                                            "		 FROM nomina.dbo.movimientos m  " &
                                            "		 LEFT JOIN personal.dbo.personalvw p on p.reloj=m.reloj " &
                                            "		 where ANO in (" & lstAnios & ") and periodo in (" & lstPeriodos & ") " &
                                            "	 ) AS SourceTable " &
                                            "                PIVOT " &
                                            "    (SUM(monto) " &
                                            "     FOR concepto IN ('+@columns+')) AS PivotTable;' " &
                                            "" &
                                            "EXEC sp_executesql @sql;")

                    Dim dtConceptos = sqlExecute("select distinct concepto,nombre " &
                                                 "from nomina.dbo.conceptos ")

                    If dtNomina.Rows.Count > 0 Then

                        Using archivo As ExcelPackage = New ExcelPackage
                            Dim wb As ExcelWorkbook = archivo.Workbook
                            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("ReporteTotales")

                            '-- Encabezado
                            hoja_excel.SelectedRange("A1:B1").Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                            hoja_excel.SelectedRange("A1:B1").Style.Fill.BackgroundColor.SetColor(Color.FromArgb(82, 169, 27))
                            hoja_excel.Cells(1, 1).Value = "CTE Reporte nómina totales por concepto"
                            hoja_excel.Cells(1, 1).Style.Font.Size = 14
                            hoja_excel.Cells(1, 1).Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255))
                            hoja_excel.Row(1).Style.Font.Bold = True

                            hoja_excel.SelectedRange("A2:B4").Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                            hoja_excel.SelectedRange("A2:B4").Style.Fill.BackgroundColor.SetColor(Color.FromArgb(226, 239, 218))
                            hoja_excel.Cells(2, 1).Value = "Fecha:"
                            hoja_excel.Cells(2, 1).Style.Font.Bold = True
                            hoja_excel.Cells(2, 1).Style.Font.Size = 12
                            hoja_excel.Cells(2, 2).Value = FechaSQL(Date.Now)
                            hoja_excel.Cells(2, 2).Style.Font.Size = 12

                            hoja_excel.Cells(3, 1).Value = "Año:"
                            hoja_excel.Cells(3, 1).Style.Font.Bold = True
                            hoja_excel.Cells(3, 1).Style.Font.Size = 12
                            hoja_excel.Cells(3, 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Top

                            hoja_excel.Cells(3, 2).Value = lstAnios
                            hoja_excel.Cells(3, 2).Style.Font.Size = 12
                            hoja_excel.Cells(3, 2).Style.WrapText = True

                            hoja_excel.Cells(4, 1).Value = "Periodo(s):"
                            hoja_excel.Cells(4, 1).Style.Font.Bold = True
                            hoja_excel.Cells(4, 1).Style.Font.Size = 12
                            hoja_excel.Cells(4, 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Top

                            hoja_excel.Cells(4, 2).Value = lstPeriodos
                            hoja_excel.Cells(4, 2).Style.Font.Size = 12
                            hoja_excel.Cells(4, 2).Style.WrapText = True

                            '-- Columnas
                            Dim y = 1, x = 6
                            Dim dicColSize As New Dictionary(Of String, Double)
                            Dim colsTamDistinto = {"nombres", "nombre_depto", "nombre_puesto", "numero_seguro_social"}

                            hoja_excel.Row(x).Style.Font.Bold = True
                            hoja_excel.Row(x).Height = 50
                            hoja_excel.Row(x + 1).Style.Font.Bold = True
                            hoja_excel.Row(x + 1).Height = 20

                            For Each emp As DataColumn In dtNomina.Columns
                                Dim nomCol = emp.ColumnName
                                hoja_excel.Column(y).Width = 19

                                If y >= 17 Then
                                    Dim nombreCol = dtConceptos.Select("concepto='" & nomCol.Trim.Replace("_", "") & "'").First.Item("nombre").ToString.Trim
                                    hoja_excel.Cells(x, y).Value = nombreCol
                                    hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(146, 208, 80))
                                    hoja_excel.Cells(x, y).Style.Font.Color.SetColor(Color.FromArgb(0, 0, 0))
                                    hoja_excel.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                                    hoja_excel.Cells(x, y).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center
                                    hoja_excel.Cells(x, y).Style.WrapText = True
                                End If

                                If {"nombres", "nombre_depto", "nombre_puesto"}.Contains(nomCol) Then hoja_excel.Column(y).Width = 60
                                If {"numero_seguro_social"}.Contains(nomCol) Then hoja_excel.Column(y).Width = 26

                                hoja_excel.Cells(x + 1, y).Value = nomCol.ToUpper.Trim
                                hoja_excel.Cells(x + 1, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                hoja_excel.Cells(x + 1, y).Style.Fill.BackgroundColor.SetColor(If(y >= 17, Color.FromArgb(0, 0, 0), Color.FromArgb(187, 188, 186)))
                                hoja_excel.Cells(x + 1, y).Style.Font.Color.SetColor(If(y >= 17, Color.FromArgb(255, 255, 255), Color.FromArgb(0, 0, 0)))
                                hoja_excel.Cells(x + 1, y).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center
                                hoja_excel.Cells(x + 1, y).Style.HorizontalAlignment = If(y >= 17, Style.ExcelHorizontalAlignment.Center, Style.ExcelHorizontalAlignment.Left)

                                y += 1
                            Next

                            '-- Filas
                            x = 8 : y = 1

                            For Each emp As DataRow In dtNomina.Rows
                                For Each col As DataColumn In dtNomina.Columns
                                    Dim colN = col.ColumnName
                                    Dim val = If(y >= 17, If(IsDBNull(emp(colN)), 0.0, emp(colN)), If(IsDBNull(emp(colN)), "", emp(colN)))
                                    Dim esNumero = val.GetType() Is GetType(Integer) Or val.GetType() Is GetType(Decimal) Or val.GetType() Is GetType(Double)
                                    hoja_excel.Cells(x, y).Value = If({"alta", "alta_antiguedad", "baja"}.Contains(colN), If(val.ToString = "", "", FechaSQL(val)), val)
                                    hoja_excel.Cells(x, y).Style.HorizontalAlignment = If(esNumero, Style.ExcelHorizontalAlignment.Right, Style.ExcelHorizontalAlignment.Left)
                                    y += 1
                                Next

                                x += 1
                                y = 1
                            Next

                            '-- Color de fondo de montos de conceptos
                            Dim lastCol = GetExcelColumnName(17) & "8:" & GetExcelColumnName(dtNomina.Columns.Count) & x - 1
                            hoja_excel.SelectedRange(lastCol).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                            hoja_excel.SelectedRange(lastCol).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(226, 239, 218))
                            hoja_excel.SelectedRange(lastCol).Style.Numberformat.Format = "$ #,##0.00"

                            archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
                            Process.Start(sfd.FileName)
                            MessageBox.Show("El reporte se ha generado", "Reporte generado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End Using
                    End If
                End If
            End If

        Catch ex As Exception
            ErrorLog("ReporteTotalesConcepto", System.Reflection.MethodBase.GetCurrentMethod.Name(), "", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene la letra de la columna del excel de acuerdo a un parámetro de un número. -- Ernesto
    ''' </summary>
    ''' <param name="columnNumber">Número de columna</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetExcelColumnName(columnNumber As Integer) As String
        Dim dividend As Integer = columnNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While

        Return columnName
    End Function


    ''' <summary>
    ''' Reporte de gráficas del desglose de pago de extras de cte -- AOS -- 2025-03-04
    ''' </summary>
    ''' <param name="dtDatos"></param>
    ''' <param name="dtInformacion"></param>
    ''' <remarks></remarks>
    Public Sub ReporteGraficaDesgloseTExtra(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim Query As String = ""
            '====Seleccionar ruta de guardado
            Dim fbd As New System.Windows.Forms.FolderBrowserDialog, pathSelec As String = ""
            If fbd.ShowDialog() = Windows.Forms.DialogResult.OK Then pathSelec = fbd.SelectedPath ' fbd.SelectedPath  ' Contiene la ruta seleccionada, ejemplo: C:\Users\aosw8\OneDrive\Documents\PIDA_TEMP_AOS

            If pathSelec.ToString.Trim = "" Then
                MessageBox.Show("No se seleccionó una ruta de guardado para el archivo a generar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            '====Generar archivo con mas de una hoja
            Dim path_reportes As String = "", plantilla_excel As String = "", dtPathReportes As New DataTable

            Query = "select path_reportes from PERSONAL.dbo.parametros"
            dtPathReportes = sqlExecute(Query, "PERSONAL")
            If Not dtPathReportes.Columns.Contains("Error") And dtPathReportes.Rows.Count > 0 Then
                Try : path_reportes = dtPathReportes.Rows(0).Item("path_reportes").ToString.Trim : Catch ex As Exception : path_reportes = "" : End Try
            End If

            plantilla_excel = path_reportes + "plantilla_reporte_graficas.xlsx"

            Dim archivo As ExcelPackage = New ExcelPackage(New FileInfo(plantilla_excel))
            Dim wb As ExcelWorkbook = archivo.Workbook
            Dim workSheet As ExcelWorksheet
            Dim filename As String = ""

            For x = 1 To 3
                Select Case x
                    Case 1
                        workSheet = wb.Worksheets("Hoja1")
                    Case 2
                        workSheet = wb.Worksheets("Hoja2")
                    Case 3
                        workSheet = wb.Worksheets("Hoja3")

                End Select
                llenarExcelInfoDesglosePExtrasGrafica(workSheet, x)
            Next

            filename = "pendiente"

            '---- Guardar archivo en ruta especificada
            If (pathSelec.Substring(pathSelec.Length() - 1) <> "\") Then pathSelec = pathSelec + "\"
            guardarArchivo(filename, archivo, , ".xlsx", "Archivo excel (xlsx)|*.xlsx", pathSelec) 'Guardar archivo en el path que se indicó

        Catch ex As Exception
            ErrorLog("Graficas desglose de pago de extras", System.Reflection.MethodBase.GetCurrentMethod.Name(), "", Err.Number, ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' Método para llenar el excel con la información de desglose de pago de extras y generar gráfica
    ''' </summary>
    ''' <param name="_wsheet"></param>
    ''' <remarks></remarks>
    Private Sub llenarExcelInfoDesglosePExtrasGrafica(_wsheet As ExcelWorksheet, ByVal numHoja As Integer)
        Try
            Dim x As Integer = 0, y As Integer = 0, anio_actual As Integer = Date.Now.Year(), query As String = ""
            Dim dtPeriodos As New DataTable

            '==============================================HOJA 1: Acumulado de bono de prod
            If numHoja = 1 Then

                '=== Recorrer cada uno de los periodos, solo los que ya están asentados, por eso se toma de Nomina
                query = "select distinct ano,periodo from nomina.dbo.nomina where ano=" & anio_actual & " and periodo<='53' order by periodo asc"
                dtPeriodos = sqlExecute(query, "NOMINA")
                If Not dtPeriodos.Columns.Contains("Error") And dtPeriodos.Rows.Count > 0 Then

                    x = 3 : y = 1
                    For Each drP As DataRow In dtPeriodos.Rows
                        Dim dtMontosPeriodo As New DataTable, anoPer As String = "", periodo As String = ""

                        Try : anoPer = drP("ano").ToString.Trim & drP("periodo").ToString.Trim : Catch ex As Exception : anoPer = "" : End Try
                        query = "select concepto,ISNULL(SUM(convert(float,MONTO)),0) as 'cantidad' from movimientos where ano+periodo='" & anoPer & "' group by concepto "
                        dtMontosPeriodo = sqlExecute(query, "NOMINA")

                        '===Columna semana                    
                        Try : periodo = drP("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
                        _wsheet.Cells(x, y).Value = periodo

                        '===Columna Nómina
                        Dim totper As Double = 0.0
                        Dim itNom = (From z In dtMontosPeriodo.Rows Where z("concepto").ToString.Trim = "TOTPER").ToList()
                        If itNom.Count > 0 Then Try : totper = Double.Parse(itNom.First()("cantidad")) : Catch ex As Exception : totper = 0.0 : End Try
                        _wsheet.Cells(x, y + 1).Value = totper

                        '====Extras operadores:: BONPRO filtrado con O
                        Dim extrOper As Double = 0.0


                        '===Extras administrativos:: BONPRO filtrado con A

                        '===Bono de permanencia:: BONPER

                        '=== BONO X CONTINGENCIA DE PUENTES:: PEND de dar de alta y que lo separen en nomina

                        '=== BONO X CIERRE DE EATON:: PEND de dar de alta y que lo separen en nomina

                        '=== BONO X CIERRE DE 4to.  SCHENKER ==> el concepto es BONSCH 

                        '=== T.E. X  CIERRE DE 4TO. DE SCHENKER ==> el concepto es BONTES

                        '=== LIQUIDACIONES FORANEOS ==> PEND de dar de alta y que lo separen en nomina

                        '=== Importe total a pagar de extras (Suma de todas las columnas, excepto la de nomina)



                        x += 1
                    Next
                End If




            End If




        Catch ex As Exception
            ErrorLog("Método para llenar info de extras para gráficas", System.Reflection.MethodBase.GetCurrentMethod.Name(), "", Err.Number, ex.Message)
        End Try
    End Sub




End Module
