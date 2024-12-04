Imports System.IO

Public Class frmHorarioMasivo
    '/*VARIABLES GLOBALES*/
    Dim listaExistencia As New List(Of String) : Dim listaErrores As New List(Of String)
    Dim clickEjemplo As Boolean : Dim listaInsert As New List(Of String)
    Dim x As Integer
    Dim progreso As Double = 0.0
    Dim total As Double = 0.0
    Dim Archivo As String

    Dim varReloj As String : Dim varAntes As String : Dim varNuevo As String

    Dim fechaFin As String = ""

    '/*FUNCIONES*/
    '---Carga la vista previa del excel en un datagridview siempre y cuando cumpla con las condiciones del layout
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
                dgHorarios.Rows.Add()
                dgHorarios.Item("colReloj", y).Value = arreglo(1, y).Trim
                dgHorarios.Item("colHorarioActual", y).Value = arreglo(2, y).Trim
                dgHorarios.Item("colHorarioNuevo", y).Value = arreglo(3, y).Trim
                BarraProgreso(2, y)
            Next

            '--Validar que en el datagridview no halla campos vacios
            Dim varHorario As String : Dim cont As Integer = 0 : Dim campoVacio As Boolean
            For Each fil As DataGridViewRow In dgHorarios.Rows
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

    '---Revisar que los relojes y horarios existen actualmente en la BD
    Private Sub RevisarExistencia()
        Dim dtPersonal As DataTable : Dim validacion As Boolean = False : Dim noExiste As Boolean
        Dim dtHorarios As DataTable : Dim flag As Integer = 0
        Dim cadena As String : Dim listaHorarios As New List(Of String)
        Dim varError As String

        Try
            '--Hacer una consulta a BD para comprobar la existencia de los relojes y horarios
            dtPersonal = sqlExecute("select RTRIM(RELOJ) AS RELOJ,RTRIM(COD_HORA) AS COD_HORA from personal")
            dtHorarios = sqlExecute("select RTRIM(COD_HORA) AS COD_HORA from horarios")

            '--Agregar horarios a una lista
            For Each filHor As DataRow In dtHorarios.Rows
                listaHorarios.Add(filHor.Item("COD_HORA"))
            Next

            '--Comparar los elementos del datagriedview con las tablas
            If dtPersonal.Rows.Count > 0 And dtHorarios.Rows.Count > 0 Then
                For Each x As DataGridViewRow In dgHorarios.Rows
                    Application.DoEvents()

                    '--Verificar que el reloj del excel exista en la tabla personal 
                    For Each y As DataRow In dtPersonal.Select("RELOJ='" & x.Cells(0).Value & "'")
                        validacion = True
                        varError = varError & "1"
                    Next

                    '--Verificar que el horario sea distinto del excel
                    'For Each y As DataRow In dtPersonal.Select("RELOJ='" & x.Cells(0).Value & "' AND COD_HORA<>'" & x.Cells(2).Value & "'")
                    '    validacion = validacion And True
                    '    varError = varError & "2"
                    'Next

                    '--Validar que horarios se encuentren en la base de datos
                    If listaHorarios.Contains(x.Cells(2).Value) Then
                        validacion = validacion And True
                        varError = varError & "3"
                    Else
                        validacion = validacion And False
                        noExiste = True
                        varError = varError & "4"
                    End If

                    varReloj = x.Cells(0).Value : varAntes = x.Cells(1).Value : varNuevo = x.Cells(2).Value

                    '--Si las validaciones son correctas, entonces se procede a actualizar
                    If validacion And varError = "13" Then
                        If Not x.Cells(0).Value = Nothing Then

                            '--Insertar valores en la tabla de bitacora_personal y personal

                            Try
                                '-- Borrar de bitacora_personal donde estén esos campos
                                sqlExecute("delete from bitacora_personal where reloj='" & varReloj & "' and fecha='" & fechaFin & "' and campo in('cod_hora','cod_turno')", "PERSONAL")

                                '--Actualizar bitacora personal
                                'cadena = "insert into bitacora_personal values " & _
                                '"('" & varReloj & "','cod_hora',(select COD_HORA from personal where reloj='" & varReloj & "')," & _
                                '"(select COD_HORA from horarios where cod_hora='" & varNuevo & "'),'" & Usuario & "','" & FechaSQL(FechaInicial) & "',null,'C',null,null)"

                                cadena = "insert into bitacora_personal values " & _
                      "('" & varReloj & "','cod_hora',(select COD_HORA from horarios where cod_hora='" & varNuevo & "')," & _
                      "'','" & Usuario & "','" & fechaFin & "',null,'C',null,null)"

                                sqlExecute(cadena)

                                'cadena = "insert into bitacora_personal values " & _
                                '"('" & varReloj & "','cod_turno',(select COD_TURNO from personal where reloj='" & varReloj & "')," & _
                                '"(select COD_TURNO from horarios where cod_hora='" & varNuevo & "'),'" & Usuario & "','" & FechaSQL(FechaInicial) & "',null,'C',null,null)"

                                cadena = "insert into bitacora_personal values " & _
                                            "('" & varReloj & "','cod_turno',(select COD_TURNO from horarios where cod_hora='" & varNuevo & "')," & _
                                            "'','" & Usuario & "','" & fechaFin & "',null,'C',null,null)"

                                sqlExecute(cadena)

                                '--Actualizar personal
                                cadena = "update personal set COD_HORA='" & varNuevo & "' where reloj='" & varReloj & "'"

                                sqlExecute(cadena)

                                cadena = "update personal set COD_TURNO=(select COD_TURNO from horarios where COD_HORA='" & varNuevo & "') where reloj='" & varReloj & "'"

                                sqlExecute(cadena)

                                '--Registros actualizados
                                Dim dtturno As DataTable : Dim antesT As String : Dim despuesT As String
                                dtturno = sqlExecute("select p.RELOJ,t.COD_TURNO as ANTES,p.COD_TURNO as DESPUES from personal p left join " & _
                                                     "personal_tmp t on p.RELOJ = t.RELOJ where p.RELOJ='" & varReloj & "'")
                                antesT = dtturno.Rows(0)("ANTES").ToString.Trim
                                despuesT = dtturno.Rows(0)("DESPUES").ToString.Trim

                                listaInsert.Add(varReloj & Space(16) & IIf(varAntes.Length < 2, varAntes & Space(2), varAntes) & Space(36) & _
                                                IIf(antesT.Length < 2, antesT & Space(2), antesT) & Space(34) & IIf(varNuevo.Length < 2, varNuevo & Space(2), varNuevo) & _
                                                Space(30) & despuesT)

                            Catch ex As Exception
                                ''---Registros con errores
                                'listaErrores.Add(x.Cells(0).Value)
                            End Try

                        End If
                    Else
                        '--Registros con valores iguales
                        If Not x.Cells(0).Value = Nothing And Not noExiste And varError.Contains("1") Then
                            Dim dtActuales As DataTable
                            dtActuales = sqlExecute("select COD_HORA from personal_tmp where RELOJ='" & varReloj & "'")
                            varAntes = dtActuales.Rows(0)("COD_HORA").ToString.Trim

                            listaExistencia.Add(varReloj & "                " & IIf(varNuevo.Length < 2, varNuevo & Space(3), varNuevo) & _
                                                "                            " & varAntes)

                            '--Registros con horarios que no existen
                        ElseIf Not x.Cells(0).Value = Nothing And (noExiste Or Not varError.Contains("1")) Then
                            varError = IIf(Not varError.Contains("1"), "El reloj " & varReloj & " no existe en la BD", "El horario '" & varNuevo & _
                                           "' no existe en la BD")
                            listaErrores.Add(varReloj & "          " & varError)
                        End If
                    End If
                    validacion = False
                    noExiste = False
                    varError = ""
                    '--Progreso
                    BarraProgreso(3, flag)
                    flag += 1
                Next
            End If

            progreso = 0
            total = 0
            x = 0

            MessageBox.Show("El archivo de los horarios ha sido cargado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Hubo un error en la carga del archivo, si el error persiste contacte al administrador del sistema",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    '---Realizar respaldo de BD
    Private Sub RespaldoBD()
        '--Limpiar tablas temporales de bitacora_personal y personal_temp
        sqlExecute("drop table bitacora_personal_tmp")
        sqlExecute("drop table personal_tmp	")
        '--Respaldar BD
        sqlExecute("select * into bitacora_personal_tmp from bitacora_personal")
        sqlExecute("select * into personal_tmp from personal")
    End Sub

    '/*EVENTOS DE CONTROLES*/
    '---Cambiar posiciones originales de elementos al dar click (INFORMACION)
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

    '---Carga la ruta del acceso al archivo de excel con los horarios (HORARIOS)
    Private Sub btnCarga_Click(sender As Object, e As EventArgs) Handles btnCarga.Click

        listaExistencia.Clear()
        listaInsert.Clear()
        listaErrores.Clear()
        btnResultados.Enabled = False

        ofDialogo.Multiselect = False
        ofDialogo.Filter = "Listas de empleados|*.xls;*.xlsx|Archivos excel|*.xls;*.xlsx"
        Try
            '---Limpiar grid si tiene datos
            dgHorarios.Rows.Clear()
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
            If dgHorarios.Rows.Count <= 1 Then
                lblEstatus.Text = "No hay registros en el archivo de excel" & vbCrLf & "o el número de elementos sobrepasa el límite"
                BarraProgreso(4, 100)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click

        Dim confirmacion As Boolean

        '---Fecha de aplicación y validacion para tener una fecha de aplicación
        frmFecha.ShowDialog()

        '---Si no se ingresa una fecha válida, no se realiza el proceso de carga
        If FechaInicial = Nothing Then
            Exit Sub
        Else
            '--Ventana de confirmacion
            If MessageBox.Show("Desea actualizar horarios con la siguiente fecha? " & vbCrLf &
                                       FechaInicial, "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                confirmacion = True
            End If
            '--Si se confirma entonces
            If confirmacion Then

                '----Obtener fecha fin del periodo
                '1-- Ver que periodo es de acuerdo a la fecha en donde estan aplicando el cambio, donde se le va a sumar 1 día**/
                Dim dtFecFin As DataTable = sqlExecute("select  DATEADD(DD, 1, FECHA_FIN) as fecha_fin from TA.dbo.periodos where '" & FechaSQL(FechaInicial) & "' BETWEEN FECHA_INI and FECHA_FIN and ISNULL(periodo_especial,0)=0", "TA")
                If (Not dtFecFin.Columns.Contains("Error") And dtFecFin.Rows.Count > 0) Then
                    Try : fechaFin = FechaSQL(dtFecFin.Rows(0).Item("fecha_fin").ToString.Trim) : Catch ex As Exception : fechaFin = "" : End Try
                End If

                '---Realizar validacion de registros
                RespaldoBD()
                lblEstatus.Text = "Preparando información"
                RevisarExistencia()
                btnResultados.Enabled = True

                '--Si se detectaron registros omitidos o errores, mandar msj para generar reporte para su revision
                If listaExistencia.Count > 0 Or listaErrores.Count > 0 Then
                    MessageBox.Show("Se detectaron casos omitidos y/o errores después de la carga del excel. " & _
                                    "Para más información, dar click en el botón 'Resultados' justo a la derecha de la barra de progreso, que generará " & _
                                    "un archivo txt con los resultados.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    '--Almacena en un bloc de notas los resultados actualizados
    Private Sub btnResultados_Click(sender As Object, e As EventArgs) Handles btnResultados.Click
        Dim archivo As New RichTextBox : Dim texto As String
        Try
            texto = ""
            archivo.Clear()

            SaveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"

            texto = "*** CARGA MASIVA DE HORARIOS. PIDA. FECHA ACTUAL: " & FechaSQL(Date.Now) & " ***" & vbCrLf & vbCrLf
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