Public Class frmCapturaCursosTemp
    Dim dtLista As New DataTable

    Private Sub frmCapturaCursosTemp_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyValue = Keys.F5 Then
            MostrarInformacion()
        End If
    End Sub

    Private Sub frmCapturaCursosTemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarInformacion()

        Dim _visible As Boolean = True
        _visible = revisarPerfiles(Perfil, Me, _visible, "WME", "")
        btnNuevo.Visible = _visible
        btnEditar.Visible = _visible
        btnBorrar.Visible = _visible
        btnParametros.Visible = _visible
        btnAplicar.Visible = _visible

    End Sub

    Private Sub EmpNav_Enter(sender As Object, e As EventArgs) Handles EmpNav.Enter

    End Sub

    Private Sub dgCursosEmp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCursosEmp.CellContentClick

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            keyReloj = "AGREGAR"
            keyCurso = ""
            keyFechaInicio = Now
            AplicarCurso = False
            If frmEditarCursosEmpleado.ShowDialog = Windows.Forms.DialogResult.OK Then
                MostrarInformacion()
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub MostrarInformacion()
        Try
            dtLista = New DataTable
            dtLista = sqlExecute("SELECT cursos_empleado.RELOJ, RTRIM(personalvw.nombres) AS NOMBRES, RTRIM(institutos.NOMBRE) AS INSTITUTO, " & _
                                 "RTRIM(instructores.NOMBRE) AS INSTRUCTOR,RTRIM(cursos.NOMBRE) AS CURSO,cursos_empleado.COD_CURSO," & _
                                 "cursos_empleado.COD_INSTRUCTOR,cursos_empleado.COD_INSTITUTO,cursos_empleado.INICIO," & _
                                 "cursos_empleado.FIN,cursos_empleado.CALIFICACION,cursos_empleado.APROBADO, cursos_empleado.duracion," & _
                                 "RTRIM(cursos_empleado.COMENTARIO) AS COMENTARIO FROM cursos_empleado " & _
                                 "INNER JOIN institutos ON cursos_empleado.COD_INSTITUTO = institutos.COD_INSTITUTO " & _
                                 "INNER JOIN instructores ON cursos_empleado.COD_INSTRUCTOR = instructores.COD_INSTRUCTOR " & _
                                 "INNER JOIN cursos ON cursos_empleado.COD_CURSO = cursos.COD_CURSO " & _
                                 "INNER JOIN personal.dbo.personalvw ON personalvw.reloj = cursos_empleado.reloj " & _
                                 "WHERE aplicado = 0 OR aplicado IS NULL ORDER BY inicio DESC,cod_curso,fin", "capacitacion")
            dgCursosEmp.DataSource = dtLista
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgCursosEmp_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCursosEmp.CellContentDoubleClick

    End Sub

    Private Sub dgCursosEmp_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgCursosEmp.UserDeletingRow
        btnBorrar.PerformClick()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim Reloj As String
        Dim Curso As String
        Dim Fecha As Date
        Dim i As Integer = 0
        Try
            If MessageBox.Show("¿Está seguro de borrar " & IIf(dgCursosEmp.SelectedRows.Count = 1, " el curso seleccionado", " los " & dgCursosEmp.SelectedRows.Count & " cursos seleccionados") & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                pbAplicar.Visible = True
                pbAplicar.Maximum = dgCursosEmp.SelectedRows.Count - 1
                Me.Cursor = Cursors.WaitCursor
                For Each dR As System.Windows.Forms.DataGridViewRow In dgCursosEmp.SelectedRows

                    Reloj = dR.Cells("colReloj").Value.ToString.Trim
                    Curso = dR.Cells("colCodCurso").Value.ToString.Trim
                    Fecha = dR.Cells("colInicio").Value

                    i += 1
                    pbAplicar.Value = i
                    pbAplicar.Text = "Borrando curso al empleado " & Reloj
                    My.Application.DoEvents()

                    sqlExecute("DELETE FROM cursos_empleado WHERE reloj = '" & Reloj & "' AND cod_curso = '" & Curso & _
                               "' AND inicio = '" & FechaSQL(Fecha) & "'", "capacitacion")
                Next
                MostrarInformacion()
            End If

        Catch ex As Exception
            MessageBox.Show("Se detectaron errores durante el borrado de registro (s). Si el problema persiste, contacte al administrador del sistema." & _
                            vbCrLf & vbCrLf & "Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        Finally
            pbAplicar.Visible = False
            pbAplicar.Text = ""
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim i As Integer

        Try
            i = dgCursosEmp.CurrentCell.RowIndex
            keyReloj = dgCursosEmp.Item("colReloj", i).Value.ToString.Trim
            keyCurso = dgCursosEmp.Item("colCodCurso", i).Value.ToString.Trim
            keyFechaInicio = dgCursosEmp.Item("colInicio", i).Value

            AplicarCurso = False
            If frmEditarCursosEmpleado.ShowDialog = Windows.Forms.DialogResult.OK Then
                MostrarInformacion()

                dgCursosEmp.CurrentCell.Selected = False
                dgCursosEmp.Rows(i).Selected = True
                dgCursosEmp.FirstDisplayedScrollingRowIndex = i
            End If
        Catch ex As Exception
            MessageBox.Show("Se detectaron errores durante la edición de datos. Si el problema persiste, contacte al administrador del sistema." & _
                 vbCrLf & vbCrLf & "Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Dim x As Integer
        Dim Respuesta As System.Windows.Forms.DialogResult

        Try
            Respuesta = MessageBox.Show("Se aplicarán los cursos a los empleados, ¿Desea emitir el reporte de cambios pendientes " & _
                                        "antes de continuar? " & vbCrLf & "Una vez aplicados los cambios, el reporte no se podrá emitir.", "Aplicar cambios de sueldo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If Respuesta = vbCancel Then
                Exit Sub
            ElseIf Respuesta = vbYes Then

                frmVistaPrevia.LlamarReporte("Cursos por aplicar", Nothing)
                frmVistaPrevia.ShowDialog()
            End If

            pbAplicar.Visible = True
            pbAplicar.Maximum = dtLista.Rows.Count - 1
            Me.Cursor = Cursors.WaitCursor

            For x = 0 To dtLista.Rows.Count - 1
                pbAplicar.Value = x
                pbAplicar.Text = "Aplicando curso al empleado " & dtLista.Rows.Item(x).Item("reloj")

                sqlExecute("UPDATE cursos_empleado SET aplicado = 1, fecha_aplicacion = GETDATE(), usuario_aplicacion = '" & _
                           Usuario & "' WHERE reloj = '" & dtLista.Rows(x).Item("reloj") & "' " & _
                           "AND cod_curso = '" & dtLista.Rows(x).Item("cod_curso") & "' " & _
                           "AND inicio = '" & FechaSQL(dtLista.Rows(x).Item("inicio")) & "' ", "capacitacion")
            Next

            MessageBox.Show("Los cambios fueron aplicados exitosamente.", "Aplicar cambios de sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("No todos los cambios pudieron ser aplicados. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        Finally
            pbAplicar.Visible = False
            MostrarInformacion()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub EditaSueldos(ByVal Reloj As String, ByVal Campo As String, ByVal Valor As Object)
        Dim TipoMovimiento As String = "M"
        Dim dtTemp As New DataTable
        Dim Cadena As String
        Try
            If TypeOf Valor Is Double Or TypeOf Valor Is Integer Or TypeOf Valor Is Decimal Then
                '*** Si el valor recibido es de tipo numérico
                Dim ValAnt As Double
                dtTemp = sqlExecute("SELECT " & Campo & " from personalvw WHERE reloj = '" & Reloj & "'")
                ValAnt = IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), 0, dtTemp.Rows.Item(0).Item(0))

                If Valor <> ValAnt Then
                    Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                    Cadena = Cadena & Reloj & "','" & Campo & "'," & ValAnt & "," & Valor & ",'" & Usuario & "',GETDATE(),'" & TipoMovimiento & "')"
                    dtTemp = sqlExecute(Cadena)

                    dtTemp = sqlExecute("UPDATE personal SET " & Campo & " = " & Valor & " WHERE reloj = '" & Reloj & "'")
                End If

            ElseIf TypeOf Valor Is Date Then
                '*** Si el valor recibido es de tipo fecha
                Dim ValAnt As Date
                Dim ValAntSTR As String
                dtTemp = sqlExecute("SELECT " & Campo & " from personalvw WHERE reloj = '" & Reloj & "'")
                ValAnt = IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), Nothing, dtTemp.Rows.Item(0).Item(0))
                ValAntSTR = FechaSQL(ValAnt)

                If ValAnt <> Valor Then
                    Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                    Cadena = Cadena & Reloj & "','" & Campo & "','" & ValAntSTR & "','" & Valor & "','" & Usuario & "',GETDATE(),'" & TipoMovimiento & "')"
                    dtTemp = sqlExecute(Cadena)

                    Dim ValorFecha As String
                    ValorFecha = FechaSQL(Valor)
                    dtTemp = sqlExecute("UPDATE personal SET " & Campo & " = '" & ValorFecha & "' WHERE reloj = '" & Reloj & "'")
                End If
            Else
                '*** Si el valor recibido es de cualquier otro tipo, lo maneja como String
                Dim ValAnt As String

                ' Si el valor a editar es el imss, insertar también el dígito verificador en la bitácora
                If Campo.ToUpper = "IMSS" Then
                    dtTemp = sqlExecute("SELECT imss,dig_ver from personalvw WHERE reloj = '" & Reloj & "'")
                    ValAnt = IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), "", dtTemp.Rows.Item(0).Item(0)) & "-" & IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), "", dtTemp.Rows.Item(0).Item(1))

                    If ValAnt.Trim <> Valor Then
                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','" & Campo & "','" & ValAnt & "','" & Valor & "','" & Usuario & "',GETDATE(),'" & TipoMovimiento & "')"
                        dtTemp = sqlExecute(Cadena)

                        If Valor = "NULL" Then
                            dtTemp = sqlExecute("UPDATE personal SET " & Campo & " = NULL WHERE reloj = '" & Reloj & "'")
                        Else
                            Dim i As Integer
                            i = Valor.ToString.IndexOf("-")
                            dtTemp = sqlExecute("UPDATE personal SET IMSS = '" & Valor.ToString.Substring(0, i) & "', dig_ver = '" & Valor.ToString.Substring(i + 1, 1) & "' WHERE reloj = '" & Reloj & "'")
                        End If
                    End If
                Else
                    dtTemp = sqlExecute("SELECT " & Campo & " from personalvw WHERE reloj = '" & Reloj & "'")
                    If dtTemp.Rows.Count > 0 Then
                        ValAnt = IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), "", dtTemp.Rows.Item(0).Item(0))

                        If ValAnt.Trim <> Valor Then
                            Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                            Cadena = Cadena & Reloj & "','" & Campo & "','" & ValAnt & "','" & Valor & "','" & Usuario & "',GETDATE(),'" & TipoMovimiento & "')"
                            dtTemp = sqlExecute(Cadena)

                            dtTemp = sqlExecute("UPDATE personal SET " & Campo & " = '" & Valor & "' WHERE reloj = '" & Reloj & "'")

                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try

    End Sub

    Private Sub btnParametros_Click(sender As Object, e As EventArgs) Handles btnParametros.Click
        frmCapturaCursosMasivos.ShowDialog()
        MostrarInformacion()
    End Sub

    Private Sub btnMostrarInformacion_Click(sender As Object, e As EventArgs) Handles btnMostrarInformacion.Click
        MostrarInformacion()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("Cursos pendientes", Nothing)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub dgCursosEmp_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgCursosEmp.CellContentClick

    End Sub

    Private Sub dgCursosEmp_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCursosEmp.CellDoubleClick
        btnEditar.PerformClick()
    End Sub

    Private Sub frmCapturaCursosTemp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing


        For x = 0 To dtLista.Rows.Count - 1


            Dim dttemp As DataTable = sqlExecute("select reloj from cursos_empleado WHERE aplicado is null and reloj = '" & dtLista.Rows(x).Item("reloj") & "' " & _
                       "AND cod_curso = '" & dtLista.Rows(x).Item("cod_curso") & "' " & _
                       "AND inicio = '" & FechaSQL(dtLista.Rows(x).Item("inicio")) & "' ", "capacitacion")


            If dttemp.Rows.Count > 0 Then

                Dim dialogres As DialogResult = MessageBox.Show("Hay cursos sin aplicar, desea aplicarlos ahora? (Los cursos no aplicados seran borrados)", "Avertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If dialogres = Windows.Forms.DialogResult.Yes Then
                    pbAplicar.Value = x
                    pbAplicar.Text = "Aplicando curso al empleado " & dtLista.Rows.Item(x).Item("reloj")

                    sqlExecute("UPDATE cursos_empleado SET aplicado = 1, fecha_aplicacion = GETDATE(), usuario_aplicacion = '" & _
                               Usuario & "' WHERE reloj = '" & dtLista.Rows(x).Item("reloj") & "' " & _
                               "AND cod_curso = '" & dtLista.Rows(x).Item("cod_curso") & "' " & _
                               "AND inicio = '" & FechaSQL(dtLista.Rows(x).Item("inicio")) & "' ", "capacitacion")
                Else
                    sqlExecute("delete from cursos_empleado WHERE aplicado is null and reloj = '" & dtLista.Rows(x).Item("reloj") & "' " & _
                       "AND cod_curso = '" & dtLista.Rows(x).Item("cod_curso") & "' " & _
                       "AND inicio = '" & FechaSQL(dtLista.Rows(x).Item("inicio")) & "' ", "capacitacion")
                End If
            End If


        Next
    End Sub
End Class