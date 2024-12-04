'--Librerias para cargar archivos de Excel
Imports OfficeOpenXml
Imports System.IO

Public Class frmCargaExcelSalMasivos

    Private Sub frmCargaExcelSalMasivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LimpiarControles()
    End Sub
    Private Function LimpiarControles()
        txtArchivoCarga.Text = ""
    End Function

    Private Sub btnInicCarga_Click(sender As Object, e As EventArgs) Handles btnInicCarga.Click
        '-Evento  que inicia la carga y el proceso para mostrar la info en el MOD SAL y en el dgModSal
        Try
            If txtArchivoCarga.Text.Trim <> "" Then
                '-- Declarar Datatable para cada uno de las columnas del excel para luego validar cada dato
                Dim dtEmpleados As New DataTable
                dtEmpleados.Columns.Add("reloj", GetType(System.String)) ' 1
                dtEmpleados.Columns.Add("sueldo", GetType(System.String)) ' 2 -Aunque el tipo de dato es Double, lo declaramos String para validar como se recibe
                dtEmpleados.Columns.Add("fecha_aplicacion", GetType(System.String)) ' 3
                dtEmpleados.Columns.Add("notas", GetType(System.String)) ' 4
                '--Auxiliares
                dtEmpleados.Columns.Add("linea", GetType(System.Int32))
                dtEmpleados.Columns.Add("validado", GetType(System.Int32))

                '--Validacion de que el archivo no esté en uso o dañado
                Dim package As ExcelPackage = New ExcelPackage
                Try
                    package = New ExcelPackage(New FileInfo(txtArchivoCarga.Text))
                Catch ex As Exception
                    MessageBox.Show("El archivo no pudo ser leido. Asegúrese de no estarlo utilizando en este momento", "Hubo un problema al leer el archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try


                '--Validar cada una de las columnas Y Renglones
                Dim hoja_empleados As ExcelWorksheet = package.Workbook.Worksheets(1)
                Dim columna As Integer = 0
                Dim TotalColumns As Integer = 4
                Dim validado As Boolean = True
                Dim mensaje_error As String = ""

                '---Validar titulos de la primer columna y que la info comience en la 2da columna
                For columna = 1 To TotalColumns
                    Dim valida As String = IIf(IsNothing(hoja_empleados.Cells(1, columna).Value), "", hoja_empleados.Cells(1, columna).Value)
                    Dim valida_2 As String = IIf(IsNothing(hoja_empleados.Cells(2, columna).Value), "", hoja_empleados.Cells(2, columna).Value)
                    Select Case columna
                        Case 1
                            If (valida.ToString.Trim <> "RELOJ" Or valida_2.ToString.Trim = "") Then
                                mensaje_error = "La columna " & columna & " debe contener el RELOJ" & vbCrLf '-Hacer salto de Linea
                                validado = False
                            End If
                        Case 2
                            If (valida.ToString.Trim <> "SUELDO" Or valida_2.ToString.Trim = "") Then
                                mensaje_error = mensaje_error & "La columna " & columna & " debe contener el SUELDO" & vbCrLf
                                validado = False
                            End If
                        Case 3
                            If (valida.ToString.Trim <> "FECHA APLICACION" Or valida_2.ToString.Trim = "") Then
                                mensaje_error = mensaje_error & "La columna " & columna & " debe contener la FECHA APLICACION" & vbCrLf
                                validado = False
                            End If
                        Case 4
                            If (valida.ToString.Trim <> "NOTAS" Or valida_2.ToString.Trim = "") Then
                                mensaje_error = mensaje_error & "La columna " & columna & " debe contener las NOTAS"
                                validado = False
                            End If
                    End Select

                Next

                '---Validar 2da Columna que ya empiece la información

                If validado = False Then
                    MessageBox.Show("El archivo no tiene el formato correcto: " & vbCrLf & mensaje_error, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                '--Leyenda de que va leyendo el archivo
                Dim frm As New frmTrabajando
                frm.Text = "Leyendo archivo"
                frm.Show()

                '--Ir metiendo cada renglon del excel a un DATATABLE para luego validar la info
                Dim x As Integer = 2 '-En el Renglon 2 inicia la info
                Dim continuar As Boolean = True

                While continuar
                    Application.DoEvents()
                    Dim reloj As String = IIf(IsNothing(hoja_empleados.Cells(x, 1).Value), "", hoja_empleados.Cells(x, 1).Value)  ' - Da el numero de reloj que esta en el segundo renglon en adelante y en la primer columna
                    If reloj <> "" Then
                        frm.lblAvance.Text = reloj
                        Dim drow As DataRow = dtEmpleados.NewRow
                        drow("reloj") = reloj
                        drow("sueldo") = IIf(IsNothing(hoja_empleados.Cells(x, 2).Value), 0, (hoja_empleados.Cells(x, 2).Value))
                        drow("fecha_aplicacion") = IIf(IsNothing(hoja_empleados.Cells(x, 3).Value), "", hoja_empleados.Cells(x, 3).Value)
                        drow("notas") = IIf(IsNothing(hoja_empleados.Cells(x, 4).Value), "", hoja_empleados.Cells(x, 4).Value)
                        drow("linea") = x
                        drow("validado") = 0

                        dtEmpleados.Rows.Add(drow) '-Ir llenando cada registro al DataTable
                    Else
                        continuar = False
                    End If
                    x += 1
                End While
                ActivoTrabajando = False
                frm.Close()


                '--Validar cada uno de los renglones que la info este correcta para luego procesarla.

                '--Datatables para comparar la info
                Dim dtReloj As DataTable = sqlExecute("SELECT DISTINCT reloj,baja from personalvw where isnull(reloj,'')<> ''") 'Validar que exista

                frm = New frmTrabajando
                frm.Text = "Realizando validaciones"
                frm.Show()

                Dim valida_renglon As Boolean = True
                Dim mensajeError As String = ""

                For Each row As DataRow In dtEmpleados.Rows
                    Application.DoEvents()
                    Dim Reloj As String = IIf(IsDBNull(row("reloj")), "", row("reloj")) ' Para validar Reloj
                    Dim Sueldo As String = IIf(IsDBNull(row("sueldo")), "", row("sueldo")) ' Para Validar Sueldo
                    Dim Fecha As String = IIf(IsDBNull(row("fecha_aplicacion")), "", row("fecha_aplicacion")) ' Para validar la fecha de APP
                    frm.lblAvance.Text = Reloj

                    Try
                        '--Validar  No. Reloj que exista 
                        If dtReloj.Select("reloj ='" & Reloj.Trim & "'").Any Then
                            row("reloj") = Reloj
                        Else
                            mensajeError &= "Fila [" & row("linea") & "]." & "El No. Reloj " & Reloj & " no es existe." & vbCrLf
                            valida_renglon = False
                        End If

                        '--Validar que ese empleado esté activo
                        If dtReloj.Select("reloj ='" & Reloj.Trim & "' AND BAJA IS  NULL").Any Then
                            row("reloj") = Reloj
                        Else
                            mensajeError &= "Fila [" & row("linea") & "]." & "El empleado con reloj " & Reloj & " no está activo." & vbCrLf
                            valida_renglon = False
                        End If

                        '--Validar sueldo
                        If validaSueldo(Sueldo.Trim) Then
                            row("sueldo") = Double.Parse(Sueldo.Trim)
                        Else
                            mensajeError &= "Fila [" & row("linea") & "]." & "El sueldo " & Sueldo.Trim & " no es válido." & vbCrLf
                            valida_renglon = False
                        End If

                        '--Validar fecha de aplicación
                        If validaFecha(Fecha.Trim) Then
                            row("fecha_aplicacion") = FechaSQL(Fecha.ToString.Trim)
                        Else
                            mensajeError &= "Fila [" & row("linea") & "]." & "La fecha " & Fecha.Trim & " no es válida, favor de revisar." & vbCrLf
                            valida_renglon = False
                        End If

                        '---------PENDING
                        row("validado") = 1 ' Decimos que ya está validado el renglón
                    Catch ex As Exception
                        valida_renglon = False
                        mensajeError &= "Fila [" & row("linea") & "]." & "Error no identificado. " & ex.Message & vbCrLf
                    End Try
                Next

                ActivoTrabajando = False
                frm.Close()

                '--Si se encontró errores al cargar archivo, enviar listado de errores
                If Not valida_renglon Then
                    ActivoTrabajando = False
                    frm.Close()
                    frmTrabajando.Hide()
                    Dim sfd As New SaveFileDialog
                    sfd.FileName = "Errores encontrados"
                    sfd.Filter = "Archivo de texto|*.txt"
                    sfd.Title = "Se encontraron errores en el archivo a cargar"
                    If sfd.ShowDialog() Then
                        Dim file As System.IO.StreamWriter
                        file = My.Computer.FileSystem.OpenTextFileWriter(sfd.FileName, False)
                        file.WriteLine(Now.ToString & vbCrLf & mensajeError)
                        file.Close()
                        MessageBox.Show("Archivo de errores generado en " & sfd.FileName, "Errores encontrados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else

                    frm = New frmTrabajando
                    frm.Text = "Aplicando sueldos"
                    frm.Show()

                    Dim z As Integer = 0
                    For Each row As DataRow In dtEmpleados.Select("validado = 1")

                        Dim reloj_ As String = row("reloj").ToString.Trim
                        Dim sueldo_ As Double = Double.Parse(row("sueldo").ToString.Trim)
                        Dim fecha_ As String = row("fecha_aplicacion").ToString.Trim
                        Dim notas_ As String = row("notas").ToString.Trim
                        Dim excel As Integer = 1 '--Decir que se cargo por excel
                        Try
                            Application.DoEvents()
                            frm.lblAvance.Text = reloj_

                            If (ActualizaSueldoModSal(reloj_, sueldo_, FechaSQL(fecha_), notas_, Usuario, excel) > 0) Then
                                z += 1
                            End If
                            Close()
                        Catch ex As Exception
                            ActivoTrabajando = False
                            frm.Close()
                        End Try

                    Next
                    '--Al final que termine, mandamos el mensaje de cuantos registros realmente se insertaron
                    MessageBox.Show("Se cargaron " & z & " registros para actualizar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ActivoTrabajando = False
                    frm.Close()

                End If
            Else
                MessageBox.Show("No ha cargado ningún archivo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub

            End If
        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            Application.DoEvents()
        End Try
    End Sub

    Private Function ActualizaSueldoModSal(ByRef rl As String, sl As Double, fec As String, nota As String, user As String, _excel As Integer) As Integer
        Dim totRecs As Integer = 0
        Try

            Dim query As String = "INSERT INTO mod_sal (COD_COMP,RELOJ,COD_TIPO_MOD,CAMBIO_DE,CAMBIO_A,PROVAR,FACT_INT,FECHA,NOTAS,INTEGRADO,HOY,APLICADO,FECHA_APLICACION,USUARIO_APLICACION,COMPA_RATIO_ANT,COMPA_RATIO_NVO,excel) " & _
"VALUES ('RDJ','" & rl & "','AJ',(SELECT SACTUAL FROM personal WHERE RELOJ='" & rl & "')," & sl & ",(SELECT PRO_VAR FROM personal WHERE RELOJ='" & rl & "'),(SELECT FACTOR_INT FROM personal WHERE RELOJ='" & rl & "')," & _
    "'" & fec & "','Ajuste Masivo',((" & sl & " * (SELECT FACTOR_INT FROM personal WHERE RELOJ='" & rl & "'))+ (SELECT PRO_VAR FROM personal WHERE RELOJ='" & rl & "'))," & _
    "GETDATE(),0,'" & fec & "','" & user & "',0,0," & _excel & ")"

            Dim dtInsertarQuery As DataTable = sqlExecute(query, "PERSONAL")

            If Not dtInsertarQuery.Columns.Contains("ERROR") Then
                totRecs += 1
            End If

            Return totRecs
        Catch ex As Exception
            Return totRecs
        End Try
    End Function


    Private Function validaSueldo(ByRef sueldo As String) As Boolean
        Try
            If IsNumeric(sueldo) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function validaFecha(ByRef _fecha As String) As Boolean 'Validar que la fecha venga en formato: 2018-12-01
        Try
            If (_fecha = "") Then 'A) Que no venga Vacía:
                Return False
            ElseIf (_fecha.Length <> 10) Then ' B) Que sean 10 dígitos 
                Return False
            ElseIf (_fecha.Substring(4, 1) <> "-") Then 'C) Que en la 4ta posicion tenga un "-"
                Return False
            ElseIf (_fecha.Substring(7, 1) <> "-") Then 'D) Que en la 7ta posicion tenga un "-"
                Return False
            ElseIf (Not validaAno(_fecha.Substring(0, 4))) Then 'E) Que el año sea igual al actual o mayor 1 año máximo
                Return False
            ElseIf (Not validaMes(_fecha.Substring(5, 2))) Then 'F) Que el mes sea válido esté dentro del 1 al 12
                Return False
            ElseIf (Not validaDia(_fecha.Substring(0, 4), _fecha.Substring(5, 2), _fecha.Substring(8, 2))) Then 'G)Validar que el dia sea correcto
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function validaAno(ByRef _ano As String) As Boolean
        Try
            If (_ano <> "") Then
                Dim Anio As Integer = Convert.ToInt32(_ano.ToString.Trim)
                Dim Anio_Actual As Integer = Convert.ToInt32(Now.Date.Year.ToString.Substring(0, 4))
                '--Solo si el año es igual al actual o un año mayor al actual solo es válido
                If ((Anio = Anio_Actual) Or (Anio_Actual + 1 >= Anio)) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function validaMes(ByRef _mes As String) As Boolean
        Try
            If (_mes <> "") Then
                Dim Mes As Integer = Convert.ToInt32(_mes.ToString.Trim)
                If (Mes >= 1 And Mes <= 12) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function validaDia(ByRef _ano As String, ByRef _mes As String, ByRef _dia As String) As Boolean
        Try
            If (_ano <> "" And _mes <> "" And _dia <> "") Then
                Dim Anio As Integer = Convert.ToInt32(_ano.ToString.Trim)
                Dim Mes As Integer = Convert.ToInt32(_mes.ToString.Trim)
                Dim Dia As Integer = Convert.ToInt32(_dia.ToString.Trim)
                Dim EsBisiesto As Integer = Anio Mod 4
                If ((Mes >= 1 And Mes <= 12) And (Dia >= 1 And Dia <= 31)) Then
                    Select Case Mes
                        Case 2 ' Feb
                            If (Dia = 29 And EsBisiesto <> 0) Or (Dia >= 30) Then
                                Return False
                            End If
                        Case 4, 6, 9, 11 ' Abril, Jun, Sept, Nov
                            If (Dia >= 31) Then
                                Return False
                            End If
                        Case 1, 3, 5, 7, 8, 10, 12 ' Ene, Mar,May,Jul,Ago,Oct,Dic
                            If (Dia < 1 Or Dia > 31) Then
                                Return False
                            End If
                        Case Else
                            Return False
                    End Select
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub btnBuscArcExcel_Click(sender As Object, e As EventArgs) Handles btnBuscArcExcel.Click
        '- Buscar archivo de excel para cargarlo
        Try
            '--Busca el archivo y lo carga, muestra la ruta en el textBox
            Dim ofd As New OpenFileDialog
            ofd.Filter = "Excel File|*.xlsx"
            ofd.Title = "Seleccionar archivo excel"
            ofd.Multiselect = False

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtArchivoCarga.Text = ofd.FileName
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmCargaExcelSalMasivos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        '----Generar LayOut en excel de sueldos para mandarlo
        Try
            'Definir el nombre del archivo y formato
            Dim nombre_archivo As String = "Carga masiva de sueldos"
            Dim sfd As New SaveFileDialog
            sfd.Filter = "Archivo de excel|*.xlsx"
            sfd.Title = "Generar layout para carga"
            sfd.FileName = nombre_archivo

            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook ' - Define cada hoja de excel que vamos a abrir

                '--Definimos el nombre de cada hoja de excel que vamos a estar abriendo, en este caso solo será 1
                Dim hoja_personal As ExcelWorksheet = wb.Worksheets.Add("personal")
                Dim x As Integer = 0 ' Renglon
                Dim y As Integer = 0 ' Columna

                '--Definimos el nombre de cada columna del 1er Renglon de la 1era Hoja
                hoja_personal.Cells(1, 1).Value = "RELOJ"
                hoja_personal.Cells(1, 1).Style.Font.Bold = True
                hoja_personal.Cells(1, 2).Value = "SUELDO"
                hoja_personal.Cells(1, 2).Style.Font.Bold = True
                hoja_personal.Cells(1, 3).Value = "FECHA APLICACION"
                hoja_personal.Cells(1, 3).Style.Font.Bold = True
                hoja_personal.Cells(1, 4).Value = "NOTAS"
                hoja_personal.Cells(1, 4).Style.Font.Bold = True

                '---Dar formato a cada una de las columnas
                For x = 2 To 2000
                    hoja_personal.Cells(x, 1).Style.Numberformat.Format = "@" '-Formato Texto
                    hoja_personal.Cells(x, 2).Style.Numberformat.Format = "0.00" '-Formato Numérico con 2 Decimales
                    hoja_personal.Cells(x, 3).Style.Numberformat.Format = "@"
                    hoja_personal.Cells(x, 4).Style.Numberformat.Format = "@"
                Next

                '--Definir el auto fit de las  hojas de excel
                hoja_personal.Cells(hoja_personal.Dimension.Address).AutoFitColumns()


                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName)) 'Abrir el explorador y pedir guardar el archivo 
            End If

            MessageBox.Show("Archivo generado correctamente en " & sfd.FileName, "Archivo generado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblMostrarEjemplo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblMostrarEjemplo.LinkClicked
        'Mostrar imagen con ejemplo
        ttEjemplo.ToolTipTitle = "Ejemplo de llenado de columnas"
        ttEjemplo.ToolTipIcon = ToolTipIcon.Info
        ttEjemplo.AutoPopDelay = 10000
        ttEjemplo.SetToolTip(lblMostrarEjemplo, "|RELOJ  | SUELDO  | FECHA APLICACION | NOTAS         |" & vbCrLf &
                                                "|00002   | 1200.50 | 2018-12-18          | AJUSTE MASIVO |")


    End Sub
End Class