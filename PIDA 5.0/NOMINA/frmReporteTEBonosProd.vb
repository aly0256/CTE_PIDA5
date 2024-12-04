Imports OfficeOpenXml

Public Class frmReporteTEBonosProd

    ''' <summary>
    ''' Layout de excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLayout_Click(sender As Object, e As EventArgs) Handles btnLayout.Click
        Try
            Dim sfd As New SaveFileDialog
            Dim NameFile As String = "Layout de carga tiempo extra y bonos"
            sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            sfd.FileName = NameFile & ".xlsx"
            sfd.Filter = "Archivo excel (xlsx)|*.xlsx"

            If sfd.ShowDialog() = DialogResult.OK Then
                GeneraLayoutExcel(sfd.FileName)
                System.Diagnostics.Process.Start(sfd.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al generar el layout", "Error layout", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Genera el reporte en base al layout cargado
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            '-- Selecciona layout
            Dim ofdRuta As New OpenFileDialog
            ofdRuta.Filter = "Archivo excel (xlsx)|*.xlsx"
            ofdRuta.Title = "Selecciona layout"
            Dim lDialogResult As DialogResult = ofdRuta.ShowDialog()
            If lDialogResult = Windows.Forms.DialogResult.Cancel Then Exit Sub
            Dim strLayout = ofdRuta.FileName

            '-- Lee el layout
            Dim dtInformacion = LeerLayout(strLayout)

            '-- Genera reporte
            If Not IsNothing(dtInformacion) AndAlso dtInformacion.Rows.Count > 0 Then

                '-- Ruta para guardar el reporte
                Dim sfd As New SaveFileDialog
                Dim NameFile As String = "ReporteTiempoExtraBonosProductividad"
                sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                sfd.FileName = NameFile & ".xlsx"
                sfd.Filter = "Archivo excel (xlsx)|*.xlsx"

                If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If GeneraReporte(dtInformacion, sfd.FileName) Then
                        Process.Start(sfd.FileName)
                        Me.Dispose()
                        Me.Close()
                    Else
                        MessageBox.Show("El reporte no pudo ser generado", "Error reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

            Else
                MessageBox.Show("Sin información disponible para generar el reporte. Revise el layout.", "Sin información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error durante la generación del reporte.", "Error reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de tiempo extra y bonos de productividad
    ''' </summary>
    ''' <param name="dtInfo"></param>
    ''' <param name="strRuta"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GeneraReporte(dtInfo As DataTable, strRuta As String) As Boolean
        Try
            Dim archivo As ExcelPackage = New ExcelPackage()
            Dim wb As ExcelWorkbook = archivo.Workbook
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("TiempoExtraBonosProd")

            '-- Información de empleados
            Dim lstRelojes = String.Join(",", (From i In dtInfo Select "'" & i("reloj") & "'").ToList.Distinct)
            Dim dtPer = sqlExecute("select reloj,replace(nombres,',',' ') as nombre,sactual from personal.dbo.personalvw where reloj in (" & lstRelojes & ")")
            lstRelojes = String.Join(",", (From i In dtPer Select "'" & i("reloj") & "'").ToList.Distinct)

            If Not IsNothing(dtPer) AndAlso dtPer.Rows.Count > 0 Then

                '-- Encabezado
                hoja_excel.Row(1).Style.Font.Bold = True
                hoja_excel.Cells(1, 1).Value = "CTE Reporte tiempo extra y bono de productividad"

                hoja_excel.Cells(2, 1).Style.Font.Bold = True
                hoja_excel.Cells(2, 1).Value = "Fecha: "
                hoja_excel.Cells(2, 2).Value = FechaSQL(Date.Now)

                '-- Columnas
                Dim colRep = {"Reloj", "Nombre", "Sueldo día", "Horas dobles", "Monto doble", "Horas triples", "Monto triple", "Días prima",
                              "Prima dominical", "Bono shenker", "Bono eaton", "Total"}
                Dim y = 1
                hoja_excel.Row(4).Style.Font.Bold = True

                For Each c In colRep
                    hoja_excel.Cells(4, y).Value = c
                    hoja_excel.Cells(4, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    hoja_excel.Cells(4, y).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(99, 170, 27))
                    hoja_excel.Cells(4, y).Style.Font.Color.SetColor(Color.White)
                    hoja_excel.Cells(4, y).Style.Font.Bold = True

                    If c = "Total" Then hoja_excel.Cells(4, y).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(146, 208, 80))
                    y += 1
                Next

                '-- Cuerpo
                Dim x = 5 : y = 1

                '-- Omitir espacios vacios
                For Each row As DataRow In dtInfo.Select("reloj in (" & lstRelojes & ")", "reloj asc")
                    Dim sactual = 0.0, hrsdob = 0.0, hrstrip = 0.0, total = 0.0, dias_prima = 0.0
                    y = 1
                    For Each col In colRep
                        Dim valor = Nothing
                        Try : valor = row(col) : Catch ex As Exception : End Try

                        Try : If col = "Nombre" Then valor = dtPer.Select("reloj='" & row("reloj") & "'").First.Item("nombre")
                        Catch ex As Exception : valor = "- No existe reloj -" : End Try
                        Try : If col = "Sueldo día" Then valor = dtPer.Select("reloj='" & row("reloj") & "'").First.Item("sactual") : sactual = valor
                        Catch ex As Exception : valor = "- No existe reloj -" : sactual = 0.0 : End Try

                        If col = "Horas dobles" Then hrsdob = CDbl(valor) : valor = hrsdob
                        If col = "Horas triples" Then hrstrip = CDbl(valor) : valor = hrstrip
                        If col = "Monto doble" Then valor = Math.Round(sactual / 8 * 2 * hrsdob, 2) : total += valor
                        If col = "Monto triple" Then valor = Math.Round(sactual / 8 * 3 * hrstrip, 2) : total += valor
                        If col = "Días prima" Then dias_prima = CDbl(valor) : valor = dias_prima
                        If col = "Prima dominical" Then valor = Math.Round(0.25 * sactual * dias_prima, 2) : total += valor

                        If {"Bono shenker", "Bono eaton"}.Contains(col) Then valor = CDbl(row(col)) : total += valor

                        If col = "Total" Then
                            valor = Math.Round(total, 2)
                            hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                            hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(146, 208, 80))
                            hoja_excel.Cells(x, y).Style.Font.Color.SetColor(Color.White)
                            hoja_excel.Cells(x, y).Style.Font.Bold = True
                        End If

                        hoja_excel.Cells(x, y).Value = valor
                        y += 1
                    Next
                    x += 1
                Next

                '-- Totales por columna
                y = 3
                hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(169, 232, 106))
                hoja_excel.Cells(x, y).Style.Font.Color.SetColor(Color.Black)
                hoja_excel.Cells(x, y).Style.Font.Bold = True
                hoja_excel.Cells(x, y).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right
                hoja_excel.Cells(x, y).Value = "TOTALES" : y += 1

                For i = 0 To 8
                    Dim noCol = y + i
                    Dim col = GetExcelColumnName(noCol)
                    hoja_excel.Cells(x, noCol).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    hoja_excel.Cells(x, noCol).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(169, 232, 106))
                    hoja_excel.Cells(x, noCol).Style.Font.Color.SetColor(Color.Black)
                    hoja_excel.Cells(x, noCol).Style.Font.Bold = True
                    hoja_excel.Cells(x, noCol).Formula = "=SUM(" & col & "5:" & col & x - 1 & ")"
                Next

                '-- Guardar
                'hoja_excel.Column(10).Width = 20
                hoja_excel.SelectedRange("A4:B" & x).AutoFitColumns()

                '-- Tamaño de columnas
                For z = 3 To 12
                    hoja_excel.Column(z).Width = 18
                Next
                archivo.SaveAs(New System.IO.FileInfo(strRuta))
            Else
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la letra de la columna del excel de acuerdo a un parámetro de un número. -- Ernesto
    ''' </summary>
    ''' <param name="columnNumber">Número de columna</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetExcelColumnName(columnNumber As Integer) As String
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
    ''' Lee el layout del excel y lo pasa a un datatable
    ''' </summary>
    ''' <param name="strRuta"></param>
    ''' <remarks></remarks>
    Private Function LeerLayout(strRuta As String) As DataTable
        Try
            If System.IO.File.Exists(strRuta) = True Then

                Dim dtInfo As New DataTable
                Dim colValidas() = {"Reloj", "Horas_dobles", "Horas_triples", "Bono_Shenker", "Bono_Eaton", "Días_prima"}
                Dim dtValores = ProcesoNomina.creaDt("Reloj,Horas_dobles,Horas_triples,Bono_Shenker,Bono_Eaton,Días_prima",
                                                     "String,Double,Double,Double,Double,Double")

                '-- Cargar el archivo de Excel
                Using package As New ExcelPackage(New System.IO.FileInfo(strRuta))
                    Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets(1)
                    Dim rowCont As Integer = worksheet.Dimension.Rows
                    Dim colCont As Integer = worksheet.Dimension.Columns

                    '-- Validar que son las mismas columnas que el layout
                    If colValidas.Count = colCont Then
                        Dim cont = 0

                        For i = 0 To colCont - 1
                            If colValidas(i).Replace("_", " ") = worksheet.Cells(1, i + 1).Text Then cont += 1
                        Next

                        If cont <> colValidas.Count Then
                            MessageBox.Show("El layout es distinto al requerido para el reporte. " &
                                            "Asegurese de utiliza uno con las siguientes columnas: " &
                                            vbNewLine & vbNewLine & String.Join("'", From i In colValidas Select i),
                                            "Error layout", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return Nothing
                        End If
                    End If

                    '-- Leer las columnas
                    For i As Integer = 1 To colCont
                        dtInfo.Columns.Add(worksheet.Cells(1, i).Text)
                    Next

                    '-- Leer las filas
                    For i As Integer = 2 To rowCont
                        Dim row As DataRow = dtInfo.NewRow()
                        For j As Integer = 1 To colCont
                            row(j - 1) = worksheet.Cells(i, j).Text
                        Next
                        dtInfo.Rows.Add(row)
                    Next
                End Using

                Return dtInfo
            End If

            Return Nothing

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Se genera un layout de excel al usuario para que pueda ingresar la información que necesita
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneraLayoutExcel(strRuta As String)
        Try
            Dim archivo As ExcelPackage = New ExcelPackage()
            Dim wb As ExcelWorkbook = archivo.Workbook
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("LayoutTEBonos")

            hoja_excel.Row(1).Style.Font.Bold = True
            hoja_excel.Cells(1, 1).Value = "Reloj"
            hoja_excel.Cells(1, 2).Value = "Horas dobles"
            hoja_excel.Cells(1, 3).Value = "Horas triples"
            hoja_excel.Cells(1, 4).Value = "Bono Shenker"
            hoja_excel.Cells(1, 5).Value = "Bono Eaton"
            hoja_excel.Cells(1, 6).Value = "Días prima"
            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()
            archivo.SaveAs(New System.IO.FileInfo(strRuta))
        Catch ex As Exception : End Try
    End Sub
End Class