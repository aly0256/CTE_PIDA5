Imports AxAcroPDFLib
Imports AcroPDFLib

Public Class frmVisualizaPDF

    Private Sub btnSi_Click(sender As Object, e As EventArgs) Handles btnSi.Click
        Me.Dispose()
    End Sub

    'Private Sub btnCorreo_Click(sender As Object, e As EventArgs)
    '    enviaCorreo = True
    '    '== Envia correo
    '    If enviaCorreo Then
    '        Dim n As frmMessageBox = New frmMessageBox("Su solicitud será enviada a Factor Humano. Desea continuar?", 2, True)

    '        If n.DialogResult = DialogResult.OK Then

    '            '== Aqui se prepara para enviar por correo electronico la solicitud junio 2021      Ernesto
    '            If var_nom_carta.Trim <> "" Then

    '                Dim nombre_completo As String = ""
    '                Dim _reloj As String = Empleado.getReloj.Trim
    '                Dim _fecha As Date = Date.Now()
    '                Dim hora As Date = TimeOfDay
    '                Dim enviado As Integer = 0
    '                Dim contador As Integer = 0
    '                Dim idRegistro As String = "0"
    '                Dim idReg As Integer = 0
    '                Dim dtNombres As System.Data.DataTable = sqlExecute("SELECT RTRIM(NOMBRES) AS nombres from PERSONAL.dbo.personalvw " & _
    '                                                                                                 "WHERE RELOJ ='" & _reloj & "'")
    '                Dim dtSolicitudes As System.Data.DataTable = sqlExecute("SELECT * FROM PERSONAL.dbo.solicitud_cartas ORDER BY FECHA DESC,HORA DESC")

    '                If dtNombres.Rows.Count > 0 Then
    '                    Try : nombre_completo = IIf(IsDBNull(dtNombres.Rows(0)("nombres")), "", dtNombres.Rows(0)("nombres").ToString) : Catch ex As Exception : nombre_completo = "" : End Try
    '                End If

    '                Try
    '                    '== Verificar si es el primer registro en existencia
    '                    If dtSolicitudes.Rows.Count = 0 Then
    '                        idRegistro = idRegistro & CStr(contador + 1)
    '                        '== Se ingresa registro
    '                        sqlExecute("INSERT INTO PERSONAL.dbo.solicitud_cartas VALUES ('" & idRegistro & "','" & _reloj & "','" & nombre_completo & "','" & var_nom_carta & "'," & _
    '                                                                                                                  "'" & FechaSQL(_fecha) & "','" & hora & "','" & enviado & "')")
    '                    Else '== Se obtiene el último registro y se va asignando el id
    '                        idRegistro = dtSolicitudes.Rows(0)("id_registro").ToString.Trim
    '                        idReg = CInt(idRegistro) + 1
    '                        idRegistro = "0" & CStr(idReg)

    '                        '== Se ingresa registro
    '                        sqlExecute("INSERT INTO PERSONAL.dbo.solicitud_cartas VALUES ('" & idRegistro & "','" & _reloj & "','" & nombre_completo & "','" & var_nom_carta & "'," & _
    '                                                                                                                  "'" & FechaSQL(_fecha) & "','" & hora & "','" & enviado & "')")
    '                    End If

    '                    Dim aviso As frmMessageBox = New frmMessageBox("Se ha enviado su solicitud a Factor Humano satisfactoriamente", 3, False)
    '                    Me.Dispose()
    '                Catch ex As Exception
    '                    Dim aviso As frmMessageBox = New frmMessageBox("Ha ocurrido un error en la solicitud" & vbCrLf & "por favor contacte con el Administrador", 3, False)
    '                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
    '                End Try

    '            End If
    '            '==
    '        Else

    '        End If
    '    End If
    '    '== Eliminar los documentos que quedaron        abril 2021      ernesto
    '    BorrarArchivosTemp(dir_archivoWord)
    'End Sub

    Private Sub frmVisualizaPDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AxAcroPDF1_OnError(sender As Object, e As EventArgs) Handles AxAcroPDF1.OnError

    End Sub
End Class