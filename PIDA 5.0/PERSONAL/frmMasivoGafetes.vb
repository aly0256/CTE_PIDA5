Imports System.IO
Imports OfficeOpenXml

Public Class frmMasivoGafetes

    Dim sArchivo As String = ""
    Dim EsError As Boolean = False

    Private Sub btnSeleccionarArchivo_Click(sender As Object, e As EventArgs) Handles btnSeleccionarArchivo.Click
        Try

            Dim ofd As New OpenFileDialog

            ofd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            ofd.Filter = "Excel(xlsx)|*.xlsx"
            ofd.Title = "Seleccione el archivo Excel"
            ofd.Multiselect = False
            ofd.RestoreDirectory = True

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then


                sArchivo = ofd.FileName.ToString.Trim
                txtArchivoCarga.Text = Path.GetFileName(sArchivo)
                btnIniciarCarga.Enabled = True


            Else
                btnIniciarCarga.Enabled = False
            End If

        Catch ex As Exception
            btnIniciarCarga.Enabled = False
            EsError = True
            MessageBox.Show("Se presentó un error al seleccionar archivo para carga masiva.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub



    Private Sub btnIniciarCarga_Click(sender As Object, e As EventArgs) Handles btnIniciarCarga.Click

        Dim excel As ExcelPackage = Nothing
        Dim numRegistros As Long = 0
        Dim numRegistrosValidos As Long = 0
        Dim numRegistrosNoValidos As Long = 0

        Try
      

            Dim dtGafetesMasivo As DataTable = New DataTable

            Dim strRelojErrores As New System.Text.StringBuilder

            cpActualizacion.Visible = False
            cpActualizacion.Text = "Procesando..."
            cpActualizacion.Minimum = 0
            cpActualizacion.Value = 0


            If sArchivo.Trim = "" Then Exit Sub

            If System.IO.File.Exists(sArchivo) Then

                excel = New ExcelPackage(New FileInfo(sArchivo))

                Dim Hoja As ExcelWorksheet = excel.Workbook.Worksheets.FirstOrDefault(Function(nombrehoja) nombrehoja.Name = "GAFETES")

                If IsNothing(Hoja) Then
                    MessageBox.Show("Nombre de hoja 'GAFETES' no encontrada, favor de verificar.", "Hoja de carga masiva no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    excel = Nothing
                    Exit Sub
                ElseIf IsNothing(Hoja.Dimension) Then
                    MessageBox.Show("Al abrir el archivo no se localizó la información requerida para la carga, favor de verificar.", "Información no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    excel = Nothing
                    Exit Sub
                Else
                    Dim col_ini As Integer = Hoja.Dimension.Start.Column
                    Dim col_fin As Integer = Hoja.Dimension.End.Column

                    If col_ini <> 1 Or col_fin <> 2 Then
                        MessageBox.Show("No se puede cargar la información dado que el formato de carga no es correcto, favor de verificar.", "Formato de carga incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        excel = Nothing
                        Exit Sub
                    ElseIf Hoja.Cells(1, 1).Text.Trim.ToUpper <> "RELOJ" Then
                        MessageBox.Show("La primer columna debe tener como encabezado 'Reloj', favor de verificar.", "Encabezado no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        excel = Nothing
                        Exit Sub
                    ElseIf Hoja.Cells(1, 2).Text.Trim.ToUpper <> "GAFETE" Then
                        MessageBox.Show("La segunda columna debe tener como encabezado 'Gafete', favor de verificar.", "Encabezado no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        excel = Nothing
                        Exit Sub
                    Else

                        dtGafetesMasivo.Columns.Add("Reloj", Type.GetType("System.String"))
                        dtGafetesMasivo.Columns.Add("Gafete", Type.GetType("System.String"))

                        For fila As Long = 2 To Hoja.Dimension.End.Row

                            Dim row As ExcelRange = Hoja.Cells(fila, 1, fila, Hoja.Dimension.End.Column)
                            Dim NewRow As DataRow = dtGafetesMasivo.NewRow

                            If row.Item(fila, 1).Text.Trim <> "" And row.Item(fila, 2).Text.Trim <> "" Then

                                NewRow("Reloj") = row.Item(fila, 1).Text.Trim.PadLeft(6, "0")
                                NewRow("Gafete") = row.Item(fila, 2).Text.Trim

                                dtGafetesMasivo.Rows.Add(NewRow)
                            End If

                        Next

                    End If

                End If


                numRegistros = dtGafetesMasivo.Rows.Count

                If numRegistros > 0 Then

                    cpActualizacion.Text = "Procesando..."
                    cpActualizacion.Visible = True
                    cpActualizacion.Maximum = numRegistros

                    For Each row As DataRow In dtGafetesMasivo.Rows

                        Dim rl As String = IIf(IsDBNull(row("reloj")), "", row("reloj"))
                        Dim numGafete As String = IIf(IsDBNull(row("gafete")), "", row("gafete"))

                        If Not rl.Length > 6 And Not numGafete.Length > 10 Then

                            Dim dtExsite As DataTable = sqlExecute("select * from personal where reloj = '" & rl & "'")

                            If Not dtExsite.Columns.Contains("ERROR") Then


                                If Not dtExsite.Rows.Count > 0 Then
                                    strRelojErrores.Append(rl & " - No existe" & vbCr)
                                    numRegistrosNoValidos = numRegistrosNoValidos + 1
                                    Continue For
                                End If

                                Dim query As String = "UPDATE personal SET GAFETE = '" & numGafete & "' WHERE reloj = '" & rl & "'"

                                If Not sqlExecute(query).Columns.Contains("ERROR") Then

                                    numRegistrosValidos = numRegistrosValidos + 1
                                    cpActualizacion.Value = numRegistrosValidos
                                    Application.DoEvents()

                                Else

                                    strRelojErrores.Append(rl & " - Error al cargar" & vbCr)

                                    numRegistrosNoValidos = numRegistrosNoValidos + 1

                                End If

                            Else

                                strRelojErrores.Append(rl & " - Error consulta" & vbCr)

                                numRegistrosNoValidos = numRegistrosNoValidos + 1

                            End If


                        Else

                            strRelojErrores.Append(rl & " - Error formato" & vbCr)

                            numRegistrosNoValidos = numRegistrosNoValidos + 1

                        End If

                    Next

                    cpActualizacion.Text = "Finalizado..."

                    If numRegistrosNoValidos > 0 Then

                        MessageBox.Show("Los gafetes de los siguientes números de reloj no pudieron ser cargados, favor de verificar." & vbCr & _
                                        vbCr & strRelojErrores.ToString, "Gafetes no cargados", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                    MessageBox.Show("Se cargaron: " & numRegistrosValidos & " de " & numRegistros, "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else

                    MessageBox.Show("Al leer el archivo no se localizó información válida para la carga masiva de gafetes, favor de verificar.", "Información no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If


            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar cargar los numeros de gafete masivos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

        excel = Nothing

    End Sub

    Private Sub frmMasivoGafetes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnIniciarCarga.Enabled = False
        cpActualizacion.Visible = False
    End Sub

    Private Sub frmMasivoGafetes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub lnkformato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkformato.LinkClicked



        Try

            Dim sfd As New SaveFileDialog

            sfd.Title = "Descargar en"
            sfd.DefaultExt = ".xlsx"
            sfd.AddExtension = True
            sfd.Filter = "Excel(*.xlsx)|*.xlsx"
            sfd.FileName = "CARGA_MASIVA_GAFETES.xlsx"
            sfd.OverwritePrompt = True

            If sfd.ShowDialog() = DialogResult.OK Then

                Dim Plantilla As New ExcelPackage()

                Dim Hoja As ExcelWorksheet = Plantilla.Workbook.Worksheets.Add("GAFETES")
                Dim Rango As ExcelRange = Hoja.Cells("A:B")

                Rango.Style.Numberformat.Format = "@"
                Hoja.Cells(1, 1).Value = "RELOJ"
                Hoja.Cells(1, 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                Hoja.Cells(1, 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(28, 58, 112))
                Hoja.Cells(1, 1).Style.Font.Color.SetColor(Color.White)
                Hoja.Cells(1, 1).Style.Font.Bold = True

                Hoja.Cells(1, 2).Value = "GAFETE"
                Hoja.Cells(1, 2).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                Hoja.Cells(1, 2).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(28, 58, 112))
                Hoja.Cells(1, 2).Style.Font.Color.SetColor(Color.White)
                Hoja.Cells(1, 2).Style.Font.Bold = True

                'If File.Exists(sfd.FileName) Then
                '    File.Delete(sfd.FileName)
                'End If

                Plantilla.SaveAs(New FileInfo(sfd.FileName))

                MessageBox.Show("La plantilla ha sido descargada en: '" & sfd.FileName & "'", "Plantilla descargada", MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If



        Catch ex As Exception
            MessageBox.Show("Error al descargar la plantilla", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class