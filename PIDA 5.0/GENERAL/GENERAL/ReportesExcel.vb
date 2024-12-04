Imports OfficeOpenXml
Imports OfficeOpenXml.Drawing.Chart
Imports System.Globalization

Public Module ReportesExcel

    Public fecha_reporte As Date = Now
    Public archivo_name As String

    'Public Function CreateSheet(p As ExcelPackage, sheetName As String) As ExcelWorksheet
    '    p.Workbook.Worksheets.Add(sheetName)
    '    Dim ws As ExcelWorksheet = p.Workbook.Worksheets(1)
    '    ws.Name = sheetName ' //Setting Sheet's name
    '    ws.Cells.Style.Font.Size = 10 ' //Default font size for whole sheet
    '    ws.Cells.Style.Font.Name = "Calibri" ' //Default Font name for whole sheet
    '    Return ws
    'End Function

    'Reporte del ausentismo semanal del periodo anterior al que esta en curso
    Public Function transacciones_procesadas() As String
        Try
            'Dim file_name As String = ""

            Dim fecha_ini As Date = Now.Date
            Dim fecha_fin As Date = Now.Date

            'file_name = sfd.FileName

            If archivo_name.Trim <> "" Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                AgregarHoja(wb, "O")
                AgregarHoja(wb, "A")


                archivo.SaveAs(New System.IO.FileInfo(archivo_name))
            Else
                archivo_name = ""
            End If

            'file_name = My.Computer.FileSystem.SpecialDirectories.Desktop & "\reportes_automaticos\" & "Transacciones aplicadas " & FechaSQL(fecha_reporte).Replace("-", "") & ".xlsx"



            Return archivo_name
        Catch ex As Exception
            Return ""
        End Try
    End Function


    Public Sub AgregarHoja(wb As ExcelWorkbook, cod_tipo_hoja As String)
        Try

            ' Reporte a detalle Excel
            Dim x As Integer = 1
            Dim y As Integer = 1

            Dim hoja_hourly As ExcelWorksheet = wb.Worksheets.Add("Transacciones aplicadas " & IIf(cod_tipo_hoja = "O", "Hourly", "Salary") & "")

            hoja_hourly.Cells.Style.Font.Size = 9

            hoja_hourly.Cells(x, 1).Value = "Transacciones aplicadas"
            hoja_hourly.Cells(x, 1).Style.Font.Bold = True
            x += 1

            hoja_hourly.Cells(x, 1).Value = Now.ToShortDateString & "+" & Now.ToShortTimeString
            hoja_hourly.Cells(x, 1).Style.Font.Size = 9
            x += 1
            x += 1

            '-----ENCABEZADOS----------

            hoja_hourly.Cells(x, 1).Value = "Tipo de movimiento"
            hoja_hourly.Cells(x, 1).Style.Font.Bold = True

            hoja_hourly.Cells(x, 2).Value = "Id Success Factors"
            hoja_hourly.Cells(x, 2).Style.Font.Bold = True

            hoja_hourly.Cells(x, 3).Value = "Reloj PIDA"
            hoja_hourly.Cells(x, 3).Style.Font.Bold = True

            hoja_hourly.Cells(x, 4).Value = "Descripción"
            hoja_hourly.Cells(x, 4).Style.Font.Bold = True

            hoja_hourly.Cells(x, 5).Value = "Fecha efectiva"
            hoja_hourly.Cells(x, 5).Style.Font.Bold = True

            hoja_hourly.Cells(x, 6).Value = "Aplicado por"
            hoja_hourly.Cells(x, 6).Style.Font.Bold = True

            x += 1

            hoja_hourly.Cells(x, 1).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 2).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 3).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 4).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 5).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 6).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin

            Dim Transacciones As DataTable = sqlExecute("select * from reporte_transacciones where cast(fecha_registro as date) = '" & FechaSQL(fecha_reporte) & "' order by tipo_mov")

            'ALTAS

            For Each row As DataRow In Transacciones.Select("tipo_mov = 'A' or tipo_mov = 'R'")
                Dim dtClase As DataTable = sqlExecute("select * from personal where reloj = '" & ObtenerReloj(RTrim(row("sf_id"))) & "' and cod_tipo = '" & cod_tipo_hoja & "'")
                If dtClase.Rows.Count > 0 Then

                    hoja_hourly.Cells(x, 1).Value = "ALTA"
                    hoja_hourly.Cells(x, 2).Value = RTrim(row("sf_id"))
                    hoja_hourly.Cells(x, 3).Value = ObtenerReloj(RTrim(row("sf_id")))


                    Dim dtNombre As DataTable = sqlExecute("select * from personalvw where sf_id = '" & row("sf_id") & "'")
                    If dtNombre.Rows.Count > 0 Then
                        hoja_hourly.Cells(x, 4).Value = RTrim(dtNombre.Rows(0)("nombres"))
                    End If
                    hoja_hourly.Cells(x, 5).Value = FechaSQL(row("fecha_mov"))
                    hoja_hourly.Cells(x, 6).Value = ObtenerUsuario(RTrim(row("usuario")))

                    x += 1
                End If
            Next

            hoja_hourly.Cells(x, 1).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 2).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 3).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 4).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 5).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 6).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin


            'BAJAS

            For Each row As DataRow In Transacciones.Select("tipo_mov = 'B'")
                Dim dtClase As DataTable = sqlExecute("select * from personal where reloj = '" & ObtenerReloj(RTrim(row("sf_id"))) & "' and cod_tipo = '" & cod_tipo_hoja & "'")
                If dtClase.Rows.Count > 0 Then
                    hoja_hourly.Cells(x, 1).Value = "BAJA"
                    hoja_hourly.Cells(x, 2).Value = RTrim(row("sf_id"))
                    hoja_hourly.Cells(x, 3).Value = ObtenerReloj(RTrim(row("sf_id")))
                    Dim dtNombre As DataTable = sqlExecute("select * from personalvw where sf_id = '" & row("sf_id") & "'")
                    If dtNombre.Rows.Count > 0 Then
                        hoja_hourly.Cells(x, 4).Value = RTrim(dtNombre.Rows(0)("nombres"))
                    End If
                    hoja_hourly.Cells(x, 5).Value = FechaSQL(row("fecha_mov"))
                    hoja_hourly.Cells(x, 6).Value = ObtenerUsuario(RTrim(row("usuario")))

                    x += 1
                End If
            Next

            hoja_hourly.Cells(x, 1).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 2).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 3).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 4).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 5).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 6).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin

            'CAMBIOS

            For Each row As DataRow In Transacciones.Select("tipo_mov = 'C'", "descripcion")
                Dim dtClase As DataTable = sqlExecute("select * from personal where reloj = '" & ObtenerReloj(RTrim(row("sf_id"))) & "' and cod_tipo = '" & cod_tipo_hoja & "'")
                If dtClase.Rows.Count > 0 Then
                    Dim cod_campo As String = RTrim(row("descripcion")).ToUpper

                    Dim dtExiste As DataTable = sqlExecute("select top 1 " & cod_campo & " from personal")

                    If dtExiste.Rows.Count > 0 Then

                        hoja_hourly.Cells(x, 1).Value = "CAMBIO"
                        hoja_hourly.Cells(x, 2).Value = RTrim(row("sf_id"))
                        hoja_hourly.Cells(x, 3).Value = ObtenerReloj(RTrim(row("sf_id")))

                        Dim dtNombre As DataTable = sqlExecute("select * from campos where cod_campo = '" & cod_campo & "'")
                        If dtNombre.Rows.Count > 0 Then
                            Dim campo As String = RTrim(dtNombre.Rows(0)("nombre")).ToUpper
                            Try
                                campo = campo.Split("(")(0)
                            Catch ex As Exception

                            End Try
                            hoja_hourly.Cells(x, 4).Value = "Cambio de " & campo & ", Valor nuevo: " & funcion_codigos(cod_campo, row("aplicado"))
                        Else
                            Dim campo As String = cod_campo

                            hoja_hourly.Cells(x, 4).Value = "Cambio de " & campo & ", Valor nuevo: " & funcion_codigos(cod_campo, row("aplicado"))
                        End If

                        hoja_hourly.Cells(x, 5).Value = FechaSQL(row("fecha_mov"))
                        hoja_hourly.Cells(x, 6).Value = ObtenerUsuario(RTrim(row("usuario")))

                        x += 1
                    End If
                End If

            Next

            hoja_hourly.Cells(x, 1).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 2).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 3).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 4).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 5).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 6).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin


            'Modificaciones de salario

            For Each row As DataRow In Transacciones.Select("tipo_mov = 'M'")
                Dim dtClase As DataTable = sqlExecute("select * from personal where reloj = '" & ObtenerReloj(RTrim(row("sf_id"))) & "' and cod_tipo = '" & cod_tipo_hoja & "'")
                If dtClase.Rows.Count > 0 Then
                    hoja_hourly.Cells(x, 1).Value = "SALARIO"
                    hoja_hourly.Cells(x, 2).Value = RTrim(row("sf_id"))
                    hoja_hourly.Cells(x, 3).Value = ObtenerReloj(RTrim(row("sf_id")))

                    Dim dtNombre As DataTable = sqlExecute("select * from tipo_mod_sal where cod_tipo_mod = '" & RTrim(row("anterior")) & "'")
                    If dtNombre.Rows.Count > 0 Then
                        Dim campo As String = RTrim(dtNombre.Rows(0)("nombre")).ToUpper
                        Try
                            campo = campo.Split("(")(0)
                        Catch ex As Exception

                        End Try
                        hoja_hourly.Cells(x, 4).Value = "Motivo: [" & campo & "], Salario nuevo: " & row("aplicado")
                    Else
                        hoja_hourly.Cells(x, 1).Value = ""
                        hoja_hourly.Cells(x, 2).Value = ""
                        hoja_hourly.Cells(x, 3).Value = ""
                        Continue For
                    End If
                    hoja_hourly.Cells(x, 5).Value = FechaSQL(row("fecha_mov"))
                    hoja_hourly.Cells(x, 6).Value = ObtenerUsuario(RTrim(row("usuario")))

                    x += 1
                End If

            Next

            hoja_hourly.Cells(x, 1).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 2).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 3).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 4).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 5).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 6).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin

            'AUSENTISMO

            Dim dtExiste_aus As New DataTable
            dtExiste_aus.Columns.Add("sf_id")
            dtExiste_aus.Columns.Add("tipo_aus")
            dtExiste_aus.Columns.Add("fecha")
            dtExiste_aus.PrimaryKey = New DataColumn() {dtExiste_aus.Columns("sf_id"), dtExiste_aus.Columns("tipo_aus"), dtExiste_aus.Columns("fecha")}

            For Each row As DataRow In Transacciones.Select("tipo_mov = 'AUS'", "sf_id, fecha_mov")
                Dim dtClase As DataTable = sqlExecute("select * from personal where reloj = '" & ObtenerReloj(RTrim(row("sf_id"))) & "' and cod_tipo = '" & cod_tipo_hoja & "'")
                If dtClase.Rows.Count > 0 Then
                    Dim sf_id As String = RTrim(row("sf_id"))
                    Dim tipo_aus As String = RTrim(row("aplicado"))
                    Dim fecha As String = FechaSQL(row("fecha_mov"))

                    Dim drow As DataRow = dtExiste_aus.Rows.Find({sf_id, tipo_aus, fecha})
                    If drow Is Nothing Then
                        dtExiste_aus.Rows.Add({sf_id, tipo_aus, fecha})
                    Else
                        Continue For
                    End If

                    hoja_hourly.Cells(x, 1).Value = "AUSENTISMO"
                    hoja_hourly.Cells(x, 2).Value = RTrim(row("sf_id"))
                    hoja_hourly.Cells(x, 3).Value = ObtenerReloj(RTrim(row("sf_id")))
                    Dim dtNombre As DataTable = sqlExecute("select * from tipo_ausentismo where tipo_aus = '" & RTrim(row("aplicado")) & "'", "TA")
                    If dtNombre.Rows.Count > 0 Then

                        Dim cancelado As Boolean = False

                        If row("descripcion").ToString.ToUpper.Contains("CANCEL") Then
                            cancelado = True
                        End If

                        hoja_hourly.Cells(x, 4).Value = IIf(cancelado, "CANCELADO", "APLICADO") & ": [" & RTrim(row("aplicado")) & "][" & RTrim(dtNombre.Rows(0)("nombre")).ToUpper & "]"
                    Else
                        hoja_hourly.Cells(x, 1).Value = ""
                        hoja_hourly.Cells(x, 2).Value = ""
                        hoja_hourly.Cells(x, 3).Value = ""
                        Continue For
                    End If
                    hoja_hourly.Cells(x, 5).Value = FechaSQL(row("fecha_mov"))
                    hoja_hourly.Cells(x, 6).Value = ObtenerUsuario(RTrim(row("usuario")))

                    x += 1
                End If
            Next

            hoja_hourly.Cells(x, 1).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 2).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 3).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 4).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 5).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            hoja_hourly.Cells(x, 6).Style.Border.Top.Style = Style.ExcelBorderStyle.Thin

            hoja_hourly.Cells(hoja_hourly.Dimension.Address).AutoFitColumns()

        Catch ex As Exception

        End Try
    End Sub

    Public Function ObtenerUsuario(u As String) As String
        Dim usuario As String = ""
        Try
            Dim dtSFID As DataTable = sqlExecute("select reloj, nombres from personalvw where sf_id = '" & u & "'")
            If dtSFID.Rows.Count > 0 Then
                usuario = RTrim(dtSFID.Rows(0)("nombres"))
            Else
                Dim dtUsuariosPIDA As DataTable = sqlExecute("select * from appuser where username = '" & u & "'", "seguridad")
                If dtUsuariosPIDA.Rows.Count > 0 Then
                    usuario = RTrim(dtUsuariosPIDA.Rows(0)("nombre"))
                Else
                    usuario = "No relacionado"
                End If
            End If
        Catch ex As Exception
            usuario = "No relacionado"
        End Try
        Return RTrim(u) & "-" & RTrim(usuario)
    End Function

    Public Function funcion_codigos(campo As String, codigo As String) As String
        Dim valor As String = "[" & codigo.Trim & "]"

        Select Case campo.Trim.ToLower
            Case "cod_super"
                Dim dtSuper As DataTable = sqlExecute("select * from super where cod_super = '" & codigo.Trim & "'")
                If dtSuper.Rows.Count > 0 Then
                    valor = "[" & codigo.Trim & "][" & RTrim(dtSuper.Rows(0)("nombre")) & "]"
                End If
            Case "cod_depto"
                Dim dtSuper As DataTable = sqlExecute("select * from deptos where cod_depto = '" & codigo.Trim & "'")
                If dtSuper.Rows.Count > 0 Then
                    valor = "[" & codigo.Trim & "][" & RTrim(dtSuper.Rows(0)("nombre")) & "]"
                End If
            Case "cod_puesto"
                Dim dtPuestos As DataTable = sqlExecute("select * from puestos where cod_puesto = '" & codigo.Trim & "'")
                If dtPuestos.Rows.Count > 0 Then
                    valor = "[" & codigo.Trim & "][" & RTrim(dtPuestos.Rows(0)("nombre")) & "]"
                End If
        End Select

        Return valor
    End Function

End Module
