Imports System.IO
Imports System.Data.SqlClient
Imports OfficeOpenXml


Public Class frmDemoFiniquitosCapturados

    Dim dtLista As New DataTable
    Dim dtMulitSelCompleto As New DataTable
    Dim CambioSel As Boolean = False
    Dim sqlListaFiniquitos As String = ""


    Private Sub CargarListaFiniquitos(Optional ByVal filtro As String = "")
        Try

            btnAceptar.Enabled = False
            btnLimpiar.Enabled = False

            If dtMulitSelCompleto.Rows.Count > 0 Then dtMulitSelCompleto.Clear()

            Dim cadFiltrar As String

            cadFiltrar = sqlListaFiniquitos
            If Len(filtro) > 0 Then
                cadFiltrar = cadFiltrar.ToUpper.Replace("ORDER BY ", "WHERE " & filtro.Trim & " ORDER BY ")
            End If

            dtLista = sqlExecute(cadFiltrar, "NOMINA")

            'dtLista.DefaultView.Sort = "Folio"

            sdgFiniquitos.PrimaryGrid.DataSource = dtLista


            If Not dtLista.Rows.Count > 0 Then
                swExportacion.Enabled = False
                ' swExportacion.Value = False
            Else
                swExportacion.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al cargar la lista de finiquitos capturados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function LimpiarSelecciones() As Boolean

        Dim Deseleccionado As Boolean = False
        Dim copia As New DataTable
        Dim Fila As DataRow = Nothing

        Try

            copia = DirectCast(dtMulitSelCompleto, DataTable)

            For Each drRow As DataRow In dtLista.Select("seleccionado = 1")

                drRow("seleccionado") = 0

                Try : Fila = copia.Select("folio = " & drRow("folio"))(0) : Catch ex As Exception : Fila = Nothing : End Try

                If Not IsNothing(Fila) Then
                    copia.Rows.Remove(Fila)
                End If

            Next

            Deseleccionado = True

        Catch ex As Exception
            Deseleccionado = False
        End Try



        Return Deseleccionado
    End Function

    Private Sub ExportarExcelFiniquitos()

        Dim lclsqlConexion As New SqlCommand
        Dim lclsqlAdaptador As New SqlDataAdapter
        Dim lcldtResulta As New DataTable
        Dim dtExportarFiniquitos As DataTable

        Try

            Dim sfd As New SaveFileDialog

            sfd.DefaultExt = ".xlsx"
            sfd.AddExtension = True
            sfd.Title = "Guardar en"
            sfd.Filter = "Excel(xlsx)|*.xlsx"
            sfd.FileName = "BRP QRO Finiquitos_" & FechaDMY(Now) & ".xlsx"
            sfd.OverwritePrompt = True

            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then

                Try

                    lclsqlConexion.Connection = New System.Data.SqlClient.SqlConnection(SQLConn & ";Initial Catalog=NOMINA" & _
                                                               ";Persist Security Info=True; User ID=" & sUserAdmin & "; Password=" & _
                                                               sPassword & ";")

                    lclsqlConexion.CommandText = "ExcelFiniquitos"
                    lclsqlConexion.CommandTimeout = 360
                    lclsqlConexion.CommandType = CommandType.StoredProcedure

                    Dim par1 As New SqlParameter
                    par1.ParameterName = "@TablaFolio"
                    par1.SqlDbType = SqlDbType.Structured

                    Dim dtTabla As DataTable = dtMulitSelCompleto.DefaultView.ToTable(False, "folio", "reloj")

                    par1.Value = dtTabla

                    lclsqlConexion.Parameters.Add(par1)

                    lclsqlAdaptador.SelectCommand = lclsqlConexion
                    lclsqlAdaptador.Fill(lcldtResulta)

                Catch ex As Exception
                    lcldtResulta.Columns.Add("ERROR")
                End Try

                If lcldtResulta.Columns.Contains("ERROR") Then
                    MessageBox.Show("Error en la consulta de los folios.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf Not lcldtResulta.Rows.Count > 0 Then
                    MessageBox.Show("No se encontró la información requerida para el reporte.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else

                    ' Reporte a detalle Excel
                    Dim x As Integer = 1
                    Dim y As Integer = 1

                    Dim archivo As ExcelPackage = New ExcelPackage()
                    Dim wb As ExcelWorkbook = archivo.Workbook

                    Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("Finiquitos")

                    '-----ENCABEZADOS----------
                    '**VALORES FIJOS
                    hoja_excel.Cells("A2").Value = "año"
                    hoja_excel.Cells("A2").Style.Font.Bold = True

                    hoja_excel.Cells("B2").Value = "periodo"
                    hoja_excel.Cells("B2").Style.Font.Bold = True

                    hoja_excel.Cells("C2").Value = "reloj"
                    hoja_excel.Cells("C2").Style.Font.Bold = True

                    hoja_excel.Cells("D2").Value = "nombres"
                    hoja_excel.Cells("D2").Style.Font.Bold = True

                    hoja_excel.Cells("E2").Value = "cod_tipo"
                    hoja_excel.Cells("E2").Style.Font.Bold = True

                    hoja_excel.Cells("F2").Value = "cod_clase"
                    hoja_excel.Cells("F2").Style.Font.Bold = True

                    hoja_excel.Cells("G2").Value = "cod_depto"
                    hoja_excel.Cells("G2").Style.Font.Bold = True

                    hoja_excel.Cells("H2").Value = "alta"
                    hoja_excel.Cells("H2").Style.Font.Bold = True

                    hoja_excel.Cells("I2").Value = "alta_antig"
                    hoja_excel.Cells("I2").Style.Font.Bold = True

                    hoja_excel.Cells("J2").Value = "baja"
                    hoja_excel.Cells("J2").Style.Font.Bold = True

                    hoja_excel.Cells("K2").Value = "sactual"
                    hoja_excel.Cells("K2").Style.Font.Bold = True

                    hoja_excel.Cells("L2").Value = "integrado"
                    hoja_excel.Cells("L2").Style.Font.Bold = True

                    hoja_excel.Cells("M2").Value = "cod_puesto"
                    hoja_excel.Cells("M2").Style.Font.Bold = True

                    hoja_excel.Cells("N2").Value = "puesto"
                    hoja_excel.Cells("N2").Style.Font.Bold = True

                    hoja_excel.Cells("O2").Value = "sindicalizado"
                    hoja_excel.Cells("O2").Style.Font.Bold = True

                    Dim cadena As String = ""
                    For Each dRow As DataRow In lcldtResulta.Rows
                        cadena = cadena & "," & dRow("folio").ToString
                    Next

                    cadena = cadena.TrimStart(",")

                    Dim dtMovimientos As DataTable = sqlExecute("select folio,rtrim(ltrim(reloj)) as reloj,rtrim(ltrim(concepto)) as concepto,monto from movimientos_calculo where folio in (" & cadena & ")", "NOMINA")

                    Dim dtConceptosDetalle As DataTable = sqlExecute("select T1.nombre as nombre_concepto,T1.concepto," & vbCr & _
                                                                     "rtrim(ltrim(coalesce((select nombre from conceptos where concepto = T1.detalle),''))) as nombre_detalle," & vbCr & _
                                                                     "rtrim(ltrim(isnull(T1.detalle,''))) as detalle from( " & vbCr & _
                                                                     "select rtrim(ltrim(nombre)) as nombre, rtrim(ltrim(concepto)) as concepto,rtrim(ltrim(detalle)) as detalle " & vbCr & _
                                                                     "from conceptos) T1", "NOMINA")

                    dtExportarFiniquitos = New DataTable
                    dtExportarFiniquitos.Columns.Add("folio", GetType(Integer))
                    dtExportarFiniquitos.Columns.Add("reloj", GetType(String))
                    dtExportarFiniquitos.Columns.Add("nombres", GetType(String))
                    dtExportarFiniquitos.Columns.Add("cod_tipo", GetType(String))
                    dtExportarFiniquitos.Columns.Add("cod_clase", GetType(String))
                    dtExportarFiniquitos.Columns.Add("cod_depto", GetType(String))
                    dtExportarFiniquitos.Columns.Add("alta", GetType(Date))
                    dtExportarFiniquitos.Columns.Add("alta_vacacion", GetType(Date))
                    dtExportarFiniquitos.Columns.Add("baja", GetType(Date))
                    dtExportarFiniquitos.Columns.Add("sactual", GetType(Double))
                    dtExportarFiniquitos.Columns.Add("integrado", GetType(Double))
                    dtExportarFiniquitos.Columns.Add("cod_puesto", GetType(String))
                    dtExportarFiniquitos.Columns.Add("puesto", GetType(String))
                    dtExportarFiniquitos.Columns.Add("sindicalizado", GetType(String))

                    Dim indice As Integer = lcldtResulta.Columns.IndexOf("separador") + 1

                    For i As Integer = indice To (lcldtResulta.Columns.Count - 1)

                        Dim campo As String = lcldtResulta.Columns(i).ColumnName.ToString

                        Try
                            Dim Detalle As String = ""
                            Dim drDetalle As DataRow = dtConceptosDetalle.Select("concepto = '" & campo & "' and detalle <> ''")(0)
                            Detalle = drDetalle("detalle").ToString.Trim
                            dtExportarFiniquitos.Columns.Add(Detalle, GetType(Double))
                        Catch ex As Exception

                        End Try

                        dtExportarFiniquitos.Columns.Add(campo, GetType(Double))

                    Next

                    For Each drRow As DataRow In lcldtResulta.Rows

                        Dim drExporta As DataRow = dtExportarFiniquitos.NewRow

                        drExporta("folio") = drRow("folio")
                        drExporta("reloj") = drRow("reloj")
                        drExporta("nombres") = drRow("nombres")
                        drExporta("cod_tipo") = drRow("cod_tipo")
                        drExporta("cod_clase") = drRow("cod_clase")
                        drExporta("cod_depto") = drRow("cod_depto")
                        drExporta("alta") = drRow("alta")
                        drExporta("alta_vacacion") = drRow("alta_antig")
                        drExporta("baja") = drRow("baja_fin")
                        drExporta("sactual") = drRow("sactual")
                        drExporta("integrado") = drRow("integrado")
                        drExporta("cod_puesto") = drRow("cod_puesto")
                        drExporta("puesto") = drRow("puesto")
                        drExporta("sindicalizado") = drRow("sindicalizado")

                        For Each dRow As DataRow In dtMovimientos.Select("folio = " & drRow("folio").ToString & " and reloj = '" & drRow("reloj").ToString.Trim & "'")

                            Dim v_concepto As String = dRow("concepto").ToString.Trim

                            If dtExportarFiniquitos.Columns.Contains(v_concepto) Then

                                drExporta(v_concepto) = dRow("monto")

                            End If

                        Next

                        dtExportarFiniquitos.Rows.Add(drExporta)

                    Next

                    y = 16
                    For j As Integer = 14 To (dtExportarFiniquitos.Columns.Count - 1)

                        Dim NombreCampo As String = dtExportarFiniquitos.Columns(j).ColumnName.ToString
                        Dim NombreConcepto As String = ""

                        Try
                            NombreConcepto = dtConceptosDetalle.Select("concepto = '" & NombreCampo & "'")(0)("nombre_concepto")
                        Catch ex As Exception
                            NombreConcepto = "Indefinido"
                        End Try

                        hoja_excel.Cells(1, y).Value = NombreConcepto.Trim.ToUpper
                        hoja_excel.Cells(1, y).Style.Font.Bold = True

                        hoja_excel.Cells(2, y).Value = NombreCampo.Trim.ToLower
                        hoja_excel.Cells(2, y).Style.Font.Bold = True

                        y = y + 1
                    Next

                    x = 3
                    For Each drExcel As DataRow In dtExportarFiniquitos.Rows

                        hoja_excel.Cells("A" + x.ToString).Value = "xxxx"
                        hoja_excel.Cells("B" + x.ToString).Value = "xx"
                        hoja_excel.Cells("C" + x.ToString).Value = Trim(IIf(IsDBNull(drExcel("reloj")), "", drExcel("reloj")))
                        hoja_excel.Cells("D" + x.ToString).Value = Trim(IIf(IsDBNull(drExcel("nombres")), "", drExcel("nombres")))
                        hoja_excel.Cells("E" + x.ToString).Value = Trim(IIf(IsDBNull(drExcel("cod_tipo")), "", drExcel("cod_tipo")))
                        hoja_excel.Cells("F" + x.ToString).Value = Trim(IIf(IsDBNull(drExcel("cod_clase")), "", drExcel("cod_clase")))
                        hoja_excel.Cells("G" + x.ToString).Value = Trim(IIf(IsDBNull(drExcel("cod_depto")), "", drExcel("cod_depto")))
                        hoja_excel.Cells("H" + x.ToString).Value = FechaSQL(CDate(drExcel("alta")))
                        hoja_excel.Cells("I" + x.ToString).Value = FechaSQL(CDate(drExcel("alta_vacacion")))
                        hoja_excel.Cells("J" + x.ToString).Value = FechaSQL(CDate(drExcel("baja")))
                        hoja_excel.Cells("K" + x.ToString).Value = drExcel("sactual")
                        hoja_excel.Cells("L" + x.ToString).Value = drExcel("integrado")
                        hoja_excel.Cells("M" + x.ToString).Value = Trim(IIf(IsDBNull(drExcel("cod_puesto")), "", drExcel("cod_puesto")))
                        hoja_excel.Cells("N" + x.ToString).Value = Trim(IIf(IsDBNull(drExcel("puesto")), "", drExcel("puesto")))
                        hoja_excel.Cells("O" + x.ToString).Value = Trim(IIf(IsDBNull(drExcel("sindicalizado")), "", drExcel("sindicalizado")))

                        y = 16
                        For j As Integer = 14 To (dtExportarFiniquitos.Columns.Count - 1)

                            Dim NombreCampo As String = dtExportarFiniquitos.Columns(j).ColumnName.ToString
                            Dim Importe As Double = 0

                            Try
                                Importe = IIf(IsDBNull(drExcel(NombreCampo)), 0, drExcel(NombreCampo))
                            Catch ex As Exception
                                Importe = 0
                            End Try

                            hoja_excel.Cells(x, y).Value = Importe

                            y = y + 1
                        Next

                        x = x + 1
                    Next

                    x = 3
                    y = 16

                    Dim NumFilas As Integer = lcldtResulta.Rows.Count
                    Dim FilaFormula As Integer = 0

                    FilaFormula = x + NumFilas

                    For j As Integer = 14 To (dtExportarFiniquitos.Columns.Count - 1)

                        hoja_excel.Cells(FilaFormula, y).Formula = "=SUM(" & hoja_excel.Cells(x, y).Address & ":" & hoja_excel.Cells((x + NumFilas) - 1, y).Address & ")"
                        y = y + 1
                    Next

                    hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

                    archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))

                    MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                End If

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un error al intentar generar el Excel de finiquitos. Si el problema persiste contacte al administrador del sistema.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmDemoFiniquitosCapturados_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'sdgFiniquitos.PrimaryGrid.Columns(1)
    End Sub



    Private Sub frmDemoFiniquitosCapturados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try


            sqlListaFiniquitos = " select  0 as seleccionado,upper(rtrim(ltrim([Status]))) as estado,ano,Periodo,Folio,Reloj,Nombres," & _
                "baja_fin as baja_fin,cod_depto,cod_comp,cod_tipo,Neto,tipo_periodo,sactual from nomina_calculo order by reloj, folio"

            CargarListaFiniquitos("")

            sdgFiniquitos.PrimaryGrid.EnableFiltering = True
            sdgFiniquitos.PrimaryGrid.UseAlternateRowStyle = True
            sdgFiniquitos.PrimaryGrid.EnableColumnFiltering = True

            sdgFiniquitos.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells
            sdgFiniquitos.PrimaryGrid.AutoGenerateColumns = False
            sdgFiniquitos.PrimaryGrid.FrozenColumnCount = 5


            dtMulitSelCompleto.Columns.Add("ano", GetType(System.String))
            dtMulitSelCompleto.Columns.Add("periodo", GetType(System.String))
            dtMulitSelCompleto.Columns.Add("folio", GetType(System.Int32))
            dtMulitSelCompleto.Columns.Add("reloj", GetType(System.String))
            sdgFiniquitos.PrimaryGrid.SortColumns.Add(sdgFiniquitos.PrimaryGrid.Columns("colReloj"))
            sdgFiniquitos.PrimaryGrid.SortColumns.Add(sdgFiniquitos.PrimaryGrid.Columns("colFolio"))

            sdgFiniquitos.PrimaryGrid.GroupColumns.Add(sdgFiniquitos.PrimaryGrid.Columns("colReloj"))
            sdgFiniquitos.PrimaryGrid.ShowGroupExpand = True

            sdgFiniquitos.PrimaryGrid.Columns("colStatus").FilterExpr = "= 'CALCULADO'"
            sdgFiniquitos.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All


            dtMulitSelCompleto.PrimaryKey = New DataColumn() {dtMulitSelCompleto.Columns("folio")}
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un error al cargar la ventana. Si el problema persiste contacte al administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmDemoFiniquitosCapturados_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Try

            Dim Posx As Double = Convert.ToDouble((Me.Width - pnlBotones.Width)) / 2.0
            pnlBotones.Left = Posx

        Catch ex As Exception

        End Try
    End Sub

    Private Sub swExportacion_ValueChanged(sender As Object, e As EventArgs) Handles swExportacion.ValueChanged
        Try
            If swExportacion.Value Then
                sdgFiniquitos.PrimaryGrid.Columns("ColSel").ReadOnly = False
                CargarListaFiniquitos()
                sdgFiniquitos.PrimaryGrid.DataSource = dtLista
            Else
                If Not LimpiarSelecciones() Then
                    MessageBox.Show("No se pudo eliminar la seleccion de los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    CargarListaFiniquitos()
                    sdgFiniquitos.PrimaryGrid.Columns("ColSel").ReadOnly = True
                    sdgFiniquitos.PrimaryGrid.DataSource = dtLista
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

        CambioSel = False
    End Sub

    Private Sub sdgFiniquitos_CellClick(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs) Handles sdgFiniquitos.CellClick

        Dim chk As Boolean = False
        Dim drEncontrado As DataRow = Nothing
        Dim row As DataRow = Nothing

        Dim v_ano As String = ""
        Dim v_periodo As String = ""
        Dim v_folio As String = ""
        Dim v_reloj As String = ""

        Try
            If e.GridCell.GridColumn.Name.ToString = "ColSel" And swExportacion.Value Then
                If CambioSel Then

                    chk = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColSel.ColumnIndex).Value)

                    v_ano = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColAno.ColumnIndex).Value.ToString)
                    v_periodo = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColPeriodo.ColumnIndex).Value.ToString)
                    v_folio = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColFolio.ColumnIndex).Value.ToString)
                    v_reloj = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColReloj.ColumnIndex).Value.ToString)

                    If chk Then

                        row = dtMulitSelCompleto.NewRow

                        row("ano") = v_ano.Trim
                        row("periodo") = v_periodo.Trim
                        row("folio") = v_folio.Trim
                        row("reloj") = v_reloj.Trim

                        drEncontrado = dtMulitSelCompleto.Rows.Find({row("folio")})

                        If Not drEncontrado Is Nothing Then
                            MessageBox.Show("El folio '" & v_folio.Trim & "' ya fue seleccionado anteriormente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColSel.ColumnIndex).Value = False
                        Else
                            dtMulitSelCompleto.Rows.Add(row)
                        End If

                    Else

                        Dim copia As New DataTable
                        Dim drEliminar As DataRow = Nothing

                        copia = DirectCast(dtMulitSelCompleto, DataTable)

                        Try : drEliminar = copia.Select("folio = " & v_folio.Trim)(0) : Catch ex As Exception : drEliminar = Nothing : End Try

                        If Not drEliminar Is Nothing Then
                            dtMulitSelCompleto.Rows.Remove(drEliminar)
                        End If

                    End If

                End If

                If dtMulitSelCompleto.Rows.Count > 0 Then

                    btnAceptar.Enabled = True

                    btnLimpiar.Enabled = True

                Else

                    btnAceptar.Enabled = False
                    btnLimpiar.Enabled = False

                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

        CambioSel = False
    End Sub

    Private Sub sdgFiniquitos_CellValueChanged(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs) Handles sdgFiniquitos.CellValueChanged
        CambioSel = True
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Not dtMulitSelCompleto.Rows.Count > 0 Then
            MessageBox.Show("Debe selecionar al menos un folio de un empleado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            ExportarExcelFiniquitos()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try

            If MessageBox.Show("Esta acción quitará de la lista los folios seleccionados. ¿Desea continuar? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then


                If Not LimpiarSelecciones() Then
                    MessageBox.Show("No se pudo eliminar la seleccion de los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    btnAceptar.Enabled = False
                    btnLimpiar.Enabled = False
                    sdgFiniquitos.PrimaryGrid.ClearSelectedRows()
                End If

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un error al intentar quitar todas las selecciones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmDemoFiniquitosCapturados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub btnExportaNomina_Click(sender As Object, e As EventArgs) Handles btnExportaNomina.Click
        Try
            If dtLista.Select("seleccionado=1").Length = 0 Then
                MessageBox.Show("No hay registros seleccionados para la exportación.", "PIDA", MessageBoxButtons.OK)
                Exit Sub
            End If
            'Dim Resp As System.Windows.Forms.DialogResult
            'Resp = frmSeleccionarPeriodoQRO.ShowDialog()
            'If Resp = Windows.Forms.DialogResult.Cancel Then Exit Sub

            Dim dtDatosReporte As DataTable
            Dim Archivo As String
            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog
            Dim dMov As DataRow
            Dim dtMovsFin As DataTable
            Dim Estado As String = ""

            sfd.DefaultExt = ".txt"
            sfd.Title = "Crear archivo de movimientos"
            sfd.FileName = "Movs_finiquitos_" & FechaSQL(Date.Now) & ".txt"
            sfd.OverwritePrompt = True

            If sfd.ShowDialog() = DialogResult.Cancel Then
                Exit Sub
            End If

            Archivo = sfd.FileName

            Dim objFS As New FileStream(Archivo, FileMode.Create, FileAccess.Write)
            Dim objSW As New StreamWriter(objFS)

            dtDatosReporte = dtLista.Clone
            dtDatosReporte.PrimaryKey = New DataColumn() {dtDatosReporte.Columns("reloj")}

            For Each dRow As DataRow In dtLista.Select("seleccionado=1")
                Try
                    dtDatosReporte.ImportRow(dRow)
                Catch ex As Exception
                    If MessageBox.Show("Se seleccionó más de un movimiento de finiquito para el empleado " & dRow("reloj") & _
                               ". Solo 1 movimiento puede exportarse por empleado." & vbCrLf & vbCrLf & "¿Desea continuar la exportación?" _
                               , "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.OK Then
                        Continue For
                    Else
                        Exit Sub
                    End If
                End Try

                dtMovsFin = sqlExecute("SELECT * FROM movimientos_calculo WHERE reloj = '" & dRow("reloj") & "' and folio = " & dRow("folio"), "nomina")
                For Each dMov In dtMovsFin.Rows
                    objSW.WriteLine(dMov("ano") & vbTab & _
                                    dMov("periodo") & vbTab & _
                                    dMov("tipo_nomina") & vbTab & _
                                    dMov("reloj") & vbTab & _
                                    dMov("concepto") & vbTab & _
                                    dMov("monto"))
                Next
            Next

            'Si no hay errores, marcar como exportados
            For Each dRow As DataRow In dtLista.Select("seleccionado=1")
                dRow("estado") = "EXPORTADO"
                sqlExecute("UPDATE nomina_calculo SET status = 'EXPORTADO' WHERE  reloj = '" & dRow("reloj") & "' and folio = " & dRow("folio"), "nomina")

                '-- Marcar finiquitos especiales para el proceso de nómina semanal -- Ernesto -- 10 agosto 2023
                Try : sqlExecute("update nomina.dbo.nomina_calculo set finiq_especial_ano='" & Date.Now.Year & "',finiq_especial_periodo='" & PeriodoActual(Date.Now) & "',finiq_especial_tipo='S' where folio='" & dRow("folio") & "'")
                Catch ex As Exception : End Try
            Next

            'También marcar la tabla que va al reporte
            For Each dRow In dtDatosReporte.Rows
                dRow("estado") = "EXPORTADO"
            Next


            FiltroReporte = ""
            EncabezadoReporte = "REPORTE DE FINIQUITOS EXPORTADOS"

            frmVistaPrevia.LlamarReporte("Finiquitos seleccionados", dtDatosReporte)
            frmVistaPrevia.ShowDialog()

            objSW.Close()
            objFS.Close()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un error al exportar movimientos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
        End Try
    End Sub

    '-- Periodo actual para el finiquitos especial -- Ernesto -- 18 agosto 2023
    Private Function PeriodoActual(fecha As Date, Optional tipo As String = "S") As String
        Try
            Dim dtPeriodo = sqlExecute("select periodo from ta.dbo." & If(tipo = "S", "periodos", "periodos_quincenal") &
                                       " where '" & FechaSQL(Date.Now) & "'>=fecha_ini and '" & FechaSQL(Date.Now) & "'<=fecha_pago and isnull(periodo_especial,0)=0")

            Return If(dtPeriodo.Rows.Count > 0, dtPeriodo.Rows(0)("periodo").ToString.Trim, "")

        Catch ex As Exception : Return "" : End Try
    End Function

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Dim dtDatosReporte As DataTable
            Dim Par As OrdenFiltro
            Dim dtResultadoFiltro As New DataSet
            Par = CadenaFiltro(dtLista, sdgFiniquitos)
            dtResultadoFiltro.Merge(dtLista.Select(Par.Filtro, Par.Orden))
            If dtResultadoFiltro.Tables.Count = 0 Then
                dtDatosReporte = New DataTable
            Else
                dtDatosReporte = dtResultadoFiltro.Tables(0)
                dtResultadoFiltro.Tables(0).TableName = "Filtro"
            End If
            FiltroReporte = Par.Filtro
            EncabezadoReporte = "REPORTE DE FINIQUITOS CAPTURADOS"

            frmVistaPrevia.LlamarReporte("Finiquitos seleccionados", dtDatosReporte)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un error al generar el reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim elements = (From i As DataRow In dtLista.Rows Where i("seleccionado") = "1")
        If elements.Count = 0 Then
            MessageBox.Show("No hay registros seleccionados para marcar como finiquito especial.", "PIDA", MessageBoxButtons.OK)
            Exit Sub
        End If
        Dim columns As New Dictionary(Of String, String) From {{"Reloj", "Reloj"},
                                                               {"Nombres", "Nombre"},
                                                               {"Folio", "Folio"},
                                                               {"alta", "Alta"}}

        Dim finiqEspeciales = New frmMarcarFiniquitoEspecial(elements.CopyToDataTable, columns, "nombres")
        finiqEspeciales.ShowDialog()
        If finiqEspeciales.isAcepted Then
            Dim data = finiqEspeciales.getAllOptions, query = ""
            For Each i In elements
                query &= "UPDATE nomina_calculo SET finiq_especial_ano = '" & data("ano") & "', finiq_especial_periodo = '" & data("periodo") & "', finiq_especial_tipo = '" & data("tipoPeriodo") & "' WHERE reloj = '" & i("reloj") & "' And folio = '" & i("folio") & "'; "
            Next
            sqlExecute(query, "nomina")
            MessageBox.Show("Finiquitos especiales modificados correctamente.", "PIDA", MessageBoxButtons.OK)
            CargarListaFiniquitos()
        End If
    End Sub
End Class