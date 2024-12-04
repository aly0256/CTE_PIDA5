Imports System.IO
Public Class frmCargaExcepMasivo
    '/*********************************VARIABLES GLOBALES*/
    Dim listaExistencia As New List(Of String) : Dim listaErrores As New List(Of String)
    Dim clickEjemplo As Boolean : Dim listaInsert As New List(Of String)
    Dim x As Integer
    Dim progreso As Double = 0.0
    Dim total As Double = 0.0
    Dim Archivo As String
    Dim varReloj As String, cod_hora As String, fechaAplica As String


    Private Sub frmCargaExcepMasivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblMostrarEjemplo_Click(sender As Object, e As EventArgs) Handles lblMostrarEjemplo.Click
        If Not clickEjemplo Then
            lblMostrarEjemplo.Location = New Point(60, 15)
            lblMostrarEjemplo.Text = "** Dar click para ocultar " & vbCrLf & "ejemplo **"
            picEjemplo.Visible = True
            lblInfo.Visible = True
            clickEjemplo = True
        Else
            lblMostrarEjemplo.Location = New Point(60, 95)
            lblMostrarEjemplo.Text = "** Dar click para mostrar ejemplo " & vbCrLf & "de layout de excel **"
            picEjemplo.Visible = False
            lblInfo.Visible = False
            clickEjemplo = False
        End If
    End Sub

    Private Sub btnCarga_Click(sender As Object, e As EventArgs) Handles btnCarga.Click
        listaExistencia.Clear()
        listaInsert.Clear()
        listaErrores.Clear()
        btnResultados.Enabled = False

        ofDialogo.Multiselect = False
        ofDialogo.Filter = "Listas de empleados|*.xls;*.xlsx|Archivos excel|*.xls;*.xlsx"
        Try
            '---Limpiar grid si tiene datos

            dgExcepciones.Rows.Clear()
            lblRegistros.Text = "No. registros: "
            '--Fecha de aplicación
            FechaInicial = Nothing

            Dim lDialogResult As DialogResult = ofDialogo.ShowDialog()
            If lDialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                Archivo = ofDialogo.FileName
            End If

            If System.IO.File.Exists(Archivo) = False Then
                MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            '---Ruta del excel
            txtRuta.Text = Archivo
            '---Llenar arreglo con los elementos del excel
            CargarVistaPrevia(txtRuta.Text)
            '--Revisar si hay datos en el archivo de excel
            If dgExcepciones.Rows.Count <= 1 Then
                lblEstatus.Text = "No hay registros en el archivo de excel" & vbCrLf & "o el número de elementos sobrepasa el límite"
                BarraProgreso(4, 100)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub CargarVistaPrevia(ByVal Archivo As String)
        Dim arreglo(,) As String : Dim y As Integer
        Try
            Application.DoEvents()
            '--Redimensionar el arreglo principal de inicio a 1000
            ReDim arreglo(3, 1000)

            '--Llenar arreglo con datos de excel
            BarraProgreso(1, 5)
            arreglo = ExcelTOArrayList(Archivo, "C")
            x = arreglo.GetUpperBound(1)

            '--Establecer un limite (cuando el excel no tiene datos)
            Dim dtlimite As DataTable : Dim limite As Integer
            Try
                dtlimite = sqlExecute("SELECT (COUNT(RELOJ)*3) AS LIMIT FROM PERSONAL")
                limite = dtlimite.Rows(0)("LIMIT")
                If x > limite Then
                    Exit Sub
                End If
            Catch ex As Exception : End Try

            '--Llenar datagridview (dgHorarios)
            BarraProgreso(1, 10)
            For y = 0 To x
                '--Si hay valores nulos en el arreglo
                For z As Integer = 1 To 3
                    If arreglo(z, y) Is Nothing Then
                        arreglo(z, y) = ""
                    End If
                Next

                Application.DoEvents()
                dgExcepciones.Rows.Add()
                dgExcepciones.Item("colReloj", y).Value = arreglo(1, y).Trim
                dgExcepciones.Item("colExcepcion", y).Value = arreglo(2, y).Trim
                dgExcepciones.Item("colFechaAplicar", y).Value = arreglo(3, y).Trim
                BarraProgreso(2, y)
            Next

            '--Validar que en el datagridview no halla campos vacios
            Dim varHorario As String : Dim cont As Integer = 0 : Dim campoVacio As Boolean
            For Each fil As DataGridViewRow In dgExcepciones.Rows
                If cont > 0 And cont < x Then
                    For col As Integer = 0 To 2
                        varHorario = fil.Cells(col).Value
                        If varHorario Is Nothing Or varHorario = "" Then
                            campoVacio = True
                        End If
                    Next
                End If
                cont += 1
            Next

            btnCargar.Enabled = True

            '--Dependiendo de la respuesta, se procedera a cargar el excel o no
            If campoVacio Then
                If MessageBox.Show("Existen registros de campos vacios en el excel, " & _
                                   "desea continuar de igual manera?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.Cancel Then
                    btnCargar.Enabled = False
                End If
            End If

            progreso = 0
            total = 0
            lblEstatus.Text = "Información lista"
            lblRegistros.Text = "No. registros: " & (x + 1).ToString
        Catch ex As Exception
        End Try
    End Sub

    '---Barra de progreso
    Private Sub BarraProgreso(caso As Integer, prog As Integer)
        Select Case caso
            Case 1  '--Excel
                lblEstatus.Text = "Cargando datos, espere un " & vbCrLf & "momento por favor"
                progreso = prog
                pbProgreso.Value = prog
            Case 2  '--Datos
                total = 90 / x
                progreso = progreso + total
                pbProgreso.Value = progreso
                lblEstatus.Text = progreso.ToString("F2") & " %"
            Case 3  '--Actualizacion
                lblEstatus.Text = "Información lista"
                total = 100 / x
                progreso = total * prog
                pbProgreso.Value = progreso
                lblEstatus.Text = "Actualizados: " & listaInsert.Count.ToString & "   Omitidos: " & _
                                  listaExistencia.Count.ToString & "   Errores: " & listaErrores.Count.ToString
                btnCargar.Enabled = False
            Case 4  '--Sin datos
                lblRegistros.Text = "No. registros: -"
                pbProgreso.Value = prog
        End Select
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Dim confirmacion As Boolean

        '--Ventana de confirmacion
        If MessageBox.Show("Desea ingresar las excepciones de horario que se muestran en el listado? ", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
            confirmacion = True
        End If

        If confirmacion Then
            lblEstatus.Text = "Preparando información"
            ProcesaInformacion()
            btnResultados.Enabled = True

            '--Si se detectaron registros omitidos o errores, mandar msj para generar reporte para su revision
            If listaExistencia.Count > 0 Or listaErrores.Count > 0 Then
                MessageBox.Show("Se detectaron casos omitidos y/o errores después de la carga del excel. " & _
                                "Para más información, dar click en el botón 'Resultados' justo a la derecha de la barra de progreso, que generará " & _
                                "un archivo txt con los resultados.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("La información fue procesada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub ProcesaInformacion()

        Dim dtPersonal As DataTable : Dim validacion As Boolean = False : Dim noExiste As Boolean
        Dim dtExcepciones As DataTable : Dim flag As Integer = 0
        Dim cadena As String : Dim listaExcepciones As New List(Of String)
        Dim varError As String, cia As String = "", hayExepciones As Boolean = False
        Dim dtCia As DataTable = sqlExecute("select COD_COMP from cias where CIA_DEFAULT=1", "PERSONAL")
        If (Not dtCia.Columns.Contains("Error") And dtCia.Rows.Count > 0) Then
            Try : cia = dtCia.Rows(0).Item("COD_COMP").ToString.Trim : Catch ex As Exception : cia = "" : End Try
        End If

        Try
            dtPersonal = sqlExecute("select RTRIM(RELOJ) AS RELOJ,RTRIM(COD_HORA) AS COD_HORA from personal where cod_comp='" & cia & "'")
            dtExcepciones = sqlExecute("select RTRIM(COD_HORA) AS COD_HORA from excepciones_dias where cod_comp='" & cia & "'")

            '---Cargar las excepciones
            If (Not dtExcepciones.Columns.Contains("Error") And dtExcepciones.Rows.Count > 0) Then
                hayExepciones = True
                For Each filExcep As DataRow In dtExcepciones.Rows
                    listaExcepciones.Add(filExcep.Item("COD_HORA"))
                Next
            End If

            If (Not dtPersonal.Columns.Contains("Error") And dtPersonal.Rows.Count > 0 And hayExepciones) Then
                For Each x As DataGridViewRow In dgExcepciones.Rows
                    Application.DoEvents()


                    '---Inicializa valores
                    varReloj = ""
                    cod_hora = ""
                    fechaAplica = ""
                    varError = ""
                    Dim noExisteCodHora As Boolean = False, noExisteReloj As Boolean = False, fechaIncorrecta As Boolean = False, cod_hora_personal As String = ""

                    '-------------Validar que no haya filas vacías, y si las hay, que no las tome en cuenta
                    Dim t As String = "", y As String = "", z As String = "", filavacia As Boolean = False
                    t = x.Cells(0).Value
                    y = x.Cells(1).Value
                    z = x.Cells(2).Value

                    If (t Is Nothing And y Is Nothing And z Is Nothing) Then filavacia = True

                    If (Not filavacia) Then
                        '--Verificar que el reloj del excel exista en la tabla personal 
                        varReloj = x.Cells(0).Value
                        If (dtPersonal.Select("RELOJ='" & varReloj & "'").Count > 0) Then
                            validacion = True
                            varError = varError & "1"
                            For Each drCodHra As DataRow In dtPersonal.Select("RELOJ='" & varReloj & "'")
                                Try : cod_hora_personal = drCodHra("cod_hora").ToString.Trim : Catch ex As Exception : cod_hora_personal = "" : End Try
                            Next

                        Else
                            validacion = validacion And False
                            noExisteReloj = True
                            varError = varError & "4"
                        End If

                        '--Validar que las excepciones se encuentren en la base de datos
                        cod_hora = x.Cells(1).Value
                        If listaExcepciones.Contains(cod_hora) Then
                            validacion = validacion And True
                            varError = varError & "3"
                        Else
                            validacion = validacion And False
                            noExisteCodHora = True
                            varError = varError & "4"
                        End If

                        '----Validar que la fecha venga en el formato correcto
                        Try : fechaAplica = FechaSQL(x.Cells(2).Value) : Catch ex As Exception : fechaAplica = "" : End Try

                        If validaFecha(fechaAplica.Trim) Then
                            validacion = validacion And True
                            varError = varError & "3"
                        Else
                            validacion = validacion And False
                            fechaIncorrecta = True
                            varError = varError & "4"
                        End If

                        '--Si todo es correcto
                        If validacion And varError = "133" Then
                            If Not x.Cells(0).Value = Nothing Then
                                Try
                                    '1 ---Eliminar la excepción de ese día:
                                    sqlExecute("delete from excepciones_horarios where reloj='" & varReloj & "' and FECHA='" & fechaAplica & "'", "PERSONAL")

                                    '2----- Insertar el registro como tal
                                    ' HORA:  10:57:23.0000000  ::  SELECT DATEPART(HH, getdate())  - SELECT DATEPART(MINUTE, getdate()) --  SELECT DATEPART(SECOND, getdate())
                                    Dim QInsert As String = ""
                                    QInsert = "insert into excepciones_horarios (COD_COMP,RELOJ,COD_HORA,COD_HORA_PERSONAL,FECHA,FECHA_CAPTURA,HORA_CAPTURA,USUARIO) VALUES " & _
                                    "('" & cia & "','" & varReloj & "','" & cod_hora & "','" & cod_hora_personal & "','" & fechaAplica & "',GETDATE(),GETDATE(),'" & Usuario & "')"
                                    sqlExecute(QInsert, "PERSONAL")
                                Catch ex As Exception
                                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Validando empleados para carga de excepciones", Err.Number, ex.Message)
                                End Try
                            End If

                        Else '--Si hubo errores 

                            If (noExisteReloj) Then ' Si no existe el Empleado
                                varError = "El reloj " & varReloj & " no existe en la BD"
                                listaErrores.Add(varReloj & "          " & varError)
                            End If
                            If (noExisteCodHora) Then ' Si no existe el cod_hora
                                varError = "La excepción con código " & cod_hora & " no existe en la BD o no está dada de alta"
                                listaErrores.Add(cod_hora & "          " & varError)
                            End If
                            If (fechaIncorrecta) Then ' Si la fecha esta en formato incorrecto
                                varError = "El formato de fecha " & fechaAplica & " no cumple con la estructura YYYY-MM-DD"
                                listaErrores.Add(fechaIncorrecta & "          " & varError)
                            End If

                        End If
                    End If

                    '--Progreso
                    BarraProgreso(3, flag)
                    flag += 1

                Next
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Carga masiva de excepciones", Err.Number, ex.Message)
        End Try
    End Sub

    Private Sub btnResultados_Click(sender As Object, e As EventArgs) Handles btnResultados.Click
        Dim archivo As New RichTextBox : Dim texto As String
        Try
            texto = ""
            archivo.Clear()

            SaveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"

            texto = "*** CARGA MASIVA DE EXCEPCIONES DE HORARIO. PIDA. FECHA ACTUAL: " & FechaSQL(Date.Now) & " ***" & vbCrLf & vbCrLf
            texto = texto & "----------------------------------------------- RESUMEN DE RESULTADOS -------------------------------------------------------" & vbCrLf
            texto = texto & "-----------------------------------------------------------------------------------------------------------------------------------------" & vbCrLf
            texto = texto & "ACTUALIZADOS CORRECTAMENTE" & vbCrLf
            texto = texto & "RELOJ" & "          " & "Horario_Antes" & "          " & "Turno_Antes" & "          " & "Horario_Después" & "          " & "Turno_Después" & vbCrLf
            For Each lista As String In listaInsert
                texto = texto & lista & vbCrLf
            Next
            texto = texto & vbCrLf
            texto = texto & "OMITIDOS" & vbCrLf
            texto = texto & "RELOJ" & "          " & "Horario_excel" & "          " & "Horario_BD" & vbCrLf
            For Each lista As String In listaExistencia
                texto = texto & lista & vbCrLf
            Next
            texto = texto & vbCrLf
            texto = texto & "ERRORES" & vbCrLf
            texto = texto & "RELOJ" & "          " & "ERRORES" & vbCrLf
            For Each lista As String In listaErrores
                texto = texto & lista & vbCrLf
            Next

            archivo.Text = texto

            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, archivo.Text, True)
            End If
        Catch ex As Exception

        End Try
    End Sub



End Class