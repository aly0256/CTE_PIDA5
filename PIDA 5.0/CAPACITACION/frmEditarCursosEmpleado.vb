Public Class frmEditarCursosEmpleado
    Dim dtCursosEmpleados As DataTable
    Dim drCursosEmpleado As DataRow
    Dim Nuevo As Boolean


    Private Sub frmEditarCursosEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtInfoPersonal As New DataTable
        Dim dtConfiguracion As New DataTable
        Dim dtcalif As New DataTable
        Dim calif As Integer

        Try
            'cmbCurso.DataSource = sqlExecute("SELECT cod_curso,nombre FROM cursos where activo = 1 ORDER BY cod_curso", "capacitacion")
            cmbCurso.DataSource = sqlExecute("SELECT cod_curso,nombre FROM cursos ORDER BY cod_curso", "capacitacion")
            cmbInstituto.DataSource = sqlExecute("SELECT cod_instituto,nombre FROM institutos ORDER BY cod_instituto", "capacitacion")
            cmbInstructor.DataSource = sqlExecute("SELECT cod_instructor,nombre FROM instructores ORDER BY cod_instructor", "capacitacion")

            dtCursosEmpleados = sqlExecute("SELECT * FROM cursos_empleado WHERE reloj = '" & keyReloj & "' AND cod_curso = '" & keyCurso & _
                                           "' AND inicio = '" & FechaSQL(keyFechaInicio) & "'", "capacitacion")

            If dtCursosEmpleados.Rows.Count = 0 Then
                'Si no se localiza el núm. de curso, es que se va a agregar
                lblaprobado.Visible = False
                btnAprobado.Visible = True
                ' btnAprobado.IsReadOnly = True
                btnAprobado.IsReadOnly = False
                dtCursosEmpleados.Rows.Add("")
                drCursosEmpleado = dtCursosEmpleados.Rows(0)
                Nuevo = True
                'Buscar en la tabla de configuracion_cursos, si hay información predefinida para captura por este usuario
                dtConfiguracion = sqlExecute("SELECT configuracion_cursos.*,calificacion_minima," & _
                                             "CASE WHEN calificacion<calificacion_minima THEN '0' ELSE '1' END  as aprobado FROM configuracion_cursos " & _
                                             "LEFT JOIN capacitacion.dbo.cursos ON configuracion_cursos.cod_curso = cursos.cod_curso " & _
                                             "WHERE usuario = '" & Usuario & "'", "seguridad")
                If dtConfiguracion.Rows.Count = 0 Then
                    'Si no hay información, insertar registro para el usuario
                    sqlExecute("INSERT INTO configuracion_cursos  (Usuario) VALUES ('" & Usuario & "')", "seguridad")
                    sqlExecute("UPDATE configuracion_cursos SET " & _
                                            "cod_curso = '" & cmbCurso.SelectedValue & "'," & _
                                            "cod_instituto = '" & cmbInstituto.SelectedValue & "'," & _
                                            "cod_instructor = '" & cmbInstructor.SelectedValue & "'," & _
                                            "inicio = '" & FechaSQL(txtFechaInicio.Value) & "'," & _
                                            "fin = '" & FechaSQL(txtFechaFin.Value) & "'," & _
                                            "calificacion = '" & txtCalificacion.Text & "'," & _
                                            "comentario = '" & txtComentario.Text & "'" & _
                                            "WHERE usuario = '" & Usuario & "'", "seguridad")
                End If



                cmbCurso.SelectedValue = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("cod_curso")), "", dtConfiguracion.Rows(0).Item("cod_curso"))
                cmbInstituto.SelectedValue = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("cod_instituto")), "", dtConfiguracion.Rows(0).Item("cod_instituto"))
                cmbInstructor.SelectedValue = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("cod_instructor")), "", dtConfiguracion.Rows(0).Item("cod_instructor"))
                txtCalificacion.Text = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("calificacion")), 0, dtConfiguracion.Rows(0).Item("calificacion"))

                btnAprobado.Value = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("aprobado")), 0, dtConfiguracion.Rows(0).Item("aprobado")) = 1
                txtFechaInicio.Value = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("inicio")), Now.Date, dtConfiguracion.Rows(0).Item("inicio"))
                txtFechaFin.Value = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("fin")), Now.Date, dtConfiguracion.Rows(0).Item("fin"))
                txtComentario.Text = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("comentario")), 0, dtConfiguracion.Rows(0).Item("comentario").ToString.Trim)

                calif = txtCalificacion.Text
                dtcalif = sqlExecute("select calificacion_minima from cursos where cod_curso = '" & cmbCurso.SelectedValue & "'", "CAPACITACION")
                lblcalifminima.Text = "Calif. min. " & dtcalif.Rows(0).Item("calificacion_minima")
                If dtcalif.Rows(0).Item("calificacion_minima") = 0 Then
                    lblaprobado.Visible = False
                    btnAprobado.Visible = True
                    Dim calif_min As Boolean
                    calif_min = IIf(IsDBNull(dtcalif.Rows(0).Item("calificacion_minima")), False, IIf(dtcalif.Rows(0).Item("calificacion_minima") = 0, False, True))
                    ' btnAprobado.IsReadOnly = calif_min
                    btnAprobado.IsReadOnly = False
                Else
                    btnAprobado.Visible = False
                    lblaprobado.Visible = True
                    If calif >= dtcalif.Rows(0).Item("calificacion_minima") Then
                        lblaprobado.Text = "APROBADO"
                    Else
                        lblaprobado.Text = "NO APROBADO"
                    End If
                End If




                'Else
                '    'Si no hay información, poner todo en blanco

                '    cmbCurso.SelectedIndex = 0
                '    cmbInstituto.SelectedIndex = 0
                '    cmbInstructor.SelectedIndex = 0
                '    txtCalificacion.Value = 0
                '    btnAprobado.Value = True
                '    txtComentario.Text = ""
                '    txtFechaFin.Value = Now.Date
                '    txtFechaInicio.Value = Now.Date
                'End If
            Else

                'IIf(IsDBNull(dtConfiguracion.Rows(0).Item("calificacion_minima")), btnAprobado.IsReadOnly = False, IIf(dtConfiguracion.Rows(0).Item("calificacion_minima") = 0, btnAprobado.IsReadOnly = False, btnAprobado.IsReadOnly = True))
                Nuevo = False
                drCursosEmpleado = dtCursosEmpleados.Rows(0)
                cmbCurso.SelectedValue = drCursosEmpleado("cod_curso")
                cmbInstituto.SelectedValue = drCursosEmpleado("cod_instituto")
                cmbInstructor.SelectedValue = drCursosEmpleado("cod_instructor")
                txtFechaInicio.Value = IIf(IsDBNull(drCursosEmpleado("inicio")), Now, drCursosEmpleado("inicio"))
                txtFechaFin.Value = IIf(IsDBNull(drCursosEmpleado("fin")), Now, drCursosEmpleado("fin"))
                '  txtCalificacion.Value = IIf(IsDBNull(drCursosEmpleado("calificacion")), 0, drCursosEmpleado("calificacion"))
                Try : txtCalificacion.Value = drCursosEmpleado("calificacion") : Catch ex As Exception : txtCalificacion.Value = 0 : End Try
                '    btnAprobado.Value = IIf(IsDBNull(drCursosEmpleado("aprobado")), 0, drCursosEmpleado("aprobado"))
                Try : btnAprobado.Value = drCursosEmpleado("aprobado") : Catch ex As Exception : btnAprobado.Value = 0 : End Try
                txtComentario.Text = IIf(IsDBNull(drCursosEmpleado("comentario")), "", drCursosEmpleado("comentario").ToString.Trim)


                calif = IIf(IsDBNull(drCursosEmpleado("calificacion")), 0, drCursosEmpleado("calificacion"))
                dtcalif = sqlExecute("select calificacion_minima from cursos where cod_curso = '" & drCursosEmpleado("cod_curso") & "'", "CAPACITACION")
                lblcalifminima.Text = "Calif. min. " & dtcalif.Rows(0).Item("calificacion_minima")
                If dtcalif.Rows(0).Item("calificacion_minima") = 0 Then
                    lblaprobado.Visible = False
                    btnAprobado.Visible = True
                    Dim calif_min As Boolean
                    calif_min = IIf(IsDBNull(dtcalif.Rows(0).Item("calificacion_minima")), False, IIf(dtcalif.Rows(0).Item("calificacion_minima") = 0, False, True))
                    btnAprobado.IsReadOnly = calif_min
                Else
                    btnAprobado.Visible = False
                    lblaprobado.Visible = True
                    If calif >= dtcalif.Rows(0).Item("calificacion_minima") Then
                        lblaprobado.Text = "APROBADO"
                    Else
                        lblaprobado.Text = "NO APROBADO"
                    End If
                End If


                Try
                    txtDuracion.Value = IIf(IsDBNull(drCursosEmpleado("duracion")), 0, drCursosEmpleado("duracion"))
                Catch ex As Exception

                End Try

            End If


            If keyReloj = "AGREGAR" Then
                txtReloj.Text = ""
                ' txtReloj.Enabled = True
                'txtReloj.Focus()
                'txtReloj.Select()
                btnBuscar.PerformClick()
                If Not ValidaReloj() Then
                    Me.Dispose()
                End If
            Else
                txtReloj.Enabled = False
                txtReloj.Text = keyReloj
                dtInfoPersonal = sqlExecute("SELECT RTRIM(nombre)+' '+RTRIM(apaterno)+' '+RTRIM(amaterno) AS nombres from personalvw " & _
                                            "WHERE reloj = '" & keyReloj & "'")
                If dtInfoPersonal.Rows.Count = 0 Then
                    txtNombre.Text = ""
                Else
                    txtNombre.Text = dtInfoPersonal.Rows(0).Item("nombres").ToString.Trim
                End If
                cmbCurso.Focus()
                cmbCurso.Select()
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim dtInfo As DataTable
            Dim drInfo As DataRow
            Dim dtCurso As New DataTable
            Dim dtConfiguracion As New DataTable
            Dim dtInfoPersonal As New DataTable
            Dim Aprobado As Boolean
            Dim Q As String = ""

            Dim Baja As String


            If Not ValidaReloj() Then Exit Sub

            If txtFechaInicio.Value > txtFechaFin.Value Then
                MessageBox.Show("La fecha de terminación del curso debe ser posterior a la fecha de inicio. Favor de verificar.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning)
                txtFechaFin.Focus()
                Exit Sub
            End If

            'Actualizar info de configuración para el usuario
            dtConfiguracion = sqlExecute("UPDATE configuracion_cursos SET " & _
                                         "cod_curso = '" & cmbCurso.SelectedValue & "'," & _
                                         "cod_instituto = '" & cmbInstituto.SelectedValue & "'," & _
                                         "cod_instructor = '" & cmbInstructor.SelectedValue & "'," & _
                                         "inicio = '" & FechaSQL(txtFechaInicio.Value) & "'," & _
                                         "fin = '" & FechaSQL(txtFechaFin.Value) & "'," & _
                                         "calificacion = '" & txtCalificacion.Text & "'," & _
                                         "comentario = '" & txtComentario.Text & "'" & _
                                         "WHERE usuario = '" & Usuario & "'", "seguridad")

            'Buscar calificación mínima del curso, para saber si está aprobado
            dtCurso = sqlExecute("SELECT calificacion_minima FROM cursos WHERE cod_curso = '" & cmbCurso.SelectedValue & "'", "capacitacion")
            Aprobado = (txtCalificacion.Value >= IIf(IsDBNull(dtCurso.Rows(0).Item("calificacion_minima")), 0, dtCurso.Rows(0).Item("calificacion_minima")))

            drCursosEmpleado("cod_curso") = cmbCurso.SelectedValue
            drCursosEmpleado("cod_instituto") = cmbInstituto.SelectedValue
            drCursosEmpleado("cod_instructor") = cmbInstructor.SelectedValue
            drCursosEmpleado("inicio") = txtFechaInicio.Value
            drCursosEmpleado("fin") = txtFechaFin.Value
            drCursosEmpleado("calificacion") = txtCalificacion.Value
            drCursosEmpleado("aprobado") = IIf(Aprobado, 1, 0)
            drCursosEmpleado("comentario") = txtComentario.Text.Trim


            'Guardar cambios 
            If Nuevo Then
                dtCursosEmpleados = sqlExecute("SELECT * FROM cursos_empleado WHERE reloj = '" & txtReloj.Text & "' AND cod_curso = '" & cmbCurso.SelectedValue & _
                                                   "' AND inicio = '" & FechaSQL(txtFechaInicio.Value) & "'", "capacitacion")

                If dtCursosEmpleados.Rows.Count > 0 Then
                    MessageBox.Show("El empleado no puede tomar el mismo curso dos veces en el mismo día. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    cmbCurso.Focus()

                    Exit Sub
                End If

                dtInfo = ConsultaPersonalVW("SELECT reloj,alta,baja,sexo,cod_depto,cod_turno,cod_puesto,cod_super,cod_tipo,personalvw.cod_comp,cod_planta " & _
                                          " from personalvw WHERE reloj= '" & txtReloj.Text & "'")

                'Validar
                If dtInfo.Rows.Count = 0 Then
                    MessageBox.Show("El empleado " & txtReloj.Text & " no fue localizado. Es necesario tener un número de reloj válido para poder continuar.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning)
                    txtReloj.Focus()
                    txtReloj.Select()
                    Exit Sub
                ElseIf Not IsDBNull(dtInfo.Rows(0).Item("baja")) Then
                    MessageBox.Show("El empleado " & txtReloj.Text & " se encuentra dado de baja; solo se puede asignar cursos a empleados activos.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning)
                    txtReloj.Focus()
                    txtReloj.Select()
                    Exit Sub
                ElseIf txtFechaInicio.Value < dtInfo.Rows(0).Item("alta") Then  ' Solo se pueden asignar cursos si la fecha es del curso es igual o mayor a la fecha de alta del empleado
                    MessageBox.Show("La fecha del curso es anterior a la fecha de alta del empleado; solo se puede asignar cursos a empleados activos.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning)
                    txtReloj.Focus()
                    txtReloj.Select()
                    Exit Sub
                End If
                drInfo = dtInfo.Rows(0)

                keyReloj = txtReloj.Text
                keyCurso = cmbCurso.SelectedValue
                keyFechaInicio = txtFechaInicio.Value

                If IsDBNull(drInfo("baja")) Then
                    Baja = "NULL"
                Else
                    Baja = "'" & FechaSQL(drInfo("baja")) & "'"
                End If


                'Insertar la información básica para el índice (reloj,curso,inicio), y los datos de personal
                Q = "INSERT INTO cursos_empleado (reloj,cod_curso,inicio,alta," + IIf(IsDBNull(drInfo("baja")), "", "BAJA,") + "sexo,cod_depto,cod_turno,cod_puesto,cod_super," & _
                           "cod_tipo,cod_comp,cod_planta) VALUES (" & _
                           "'" & keyReloj & "'," & _
                           "'" & keyCurso & "'," & _
                           "'" & FechaSQL(keyFechaInicio) & "'," & _
                           "'" & FechaSQL(drInfo("alta")) & "'," & _
                            IIf(IsDBNull(drInfo("baja")), "", Baja & ",") & _
                                  "'" & drInfo("sexo") & "'," & _
                           "'" & drInfo("cod_depto") & "'," & _
                           "'" & drInfo("cod_turno") & "'," & _
                           "'" & drInfo("cod_puesto") & "'," & _
                           "'" & drInfo("cod_super") & "'," & _
                           "'" & drInfo("cod_tipo") & "'," & _
                           "'" & drInfo("cod_comp") & "'," & _
                           "'" & drInfo("cod_planta") & "')"
                sqlExecute(Q, "capacitacion")
            End If

            'Abraham, guardar duracion directamente en el curso
            'Actualizar los campos referentes al curso
            Q = "UPDATE cursos_empleado SET " & _
                       "cod_curso = '" & cmbCurso.SelectedValue & "'," & _
                       "cod_instructor = '" & cmbInstructor.SelectedValue & "'," & _
                       "cod_instituto = '" & cmbInstituto.SelectedValue & "'," & _
                       "inicio = '" & FechaSQL(txtFechaInicio.Value) & "'," & _
                       "fin = '" & FechaSQL(txtFechaFin.Value) & "'," & _
                       "calificacion = " & txtCalificacion.Value & "," & _
                       "aprobado = " & IIf(lblaprobado.Text = "APROBADO", 1, 0) & ", " & _
                       "duracion = " & txtDuracion.Value & ", " & _
                       "comentario = '" & txtComentario.Text.Trim & "' " & _
                       IIf(AplicarCurso, ",aplicado = 1, fecha_aplicacion = GETDATE(), usuario_aplicacion = '" & Usuario & "' ", "") & _
                       "WHERE reloj= '" & keyReloj & "' AND cod_curso = '" & keyCurso & "' AND inicio = '" & FechaSQL(keyFechaInicio) & "'"
            sqlExecute(Q, "Capacitacion")

            PlaneacionCursada(txtReloj.Text, cmbCurso.SelectedValue, txtFechaInicio.Value)

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = Windows.Forms.DialogResult.Abort
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)

        End Try
    End Sub

    Private Sub txtCalificacion_ValueChanged(sender As Object, e As EventArgs) Handles txtCalificacion.ValueChanged
        Dim dtCurso As New DataTable
        Dim minima As Integer
        dtCurso = sqlExecute("SELECT calificacion_minima FROM cursos WHERE cod_curso = '" & cmbCurso.SelectedValue & "'", "capacitacion")
        minima = IIf(IsDBNull(dtCurso.Rows(0).Item("calificacion_minima")), 0, dtCurso.Rows(0).Item("calificacion_minima"))
        If minima = 0 Then
            'btnAprobado.Value = False
        Else
            'btnAprobado.Value = (txtCalificacion.Value >= IIf(IsDBNull(dtCurso.Rows(0).Item("calificacion_minima")), 0, dtCurso.Rows(0).Item("calificacion_minima")))
            lblaprobado.Text = IIf((txtCalificacion.Value >= IIf(IsDBNull(dtCurso.Rows(0).Item("calificacion_minima")), 0, dtCurso.Rows(0).Item("calificacion_minima"))), "APROBADO", "NO APROBADO")
        End If

    End Sub

    Private Sub txtReloj_TextChanged(sender As Object, e As EventArgs) Handles txtReloj.TextChanged
        ValidaReloj()
    End Sub

    Private Sub txtReloj_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtReloj.Validating
        'e.Cancel
        'validare
    End Sub

    Private Function ValidaReloj() As Boolean
        Dim vl As String
        Dim dtInfoPersonal As New DataTable
        Dim EsValido As Boolean = True
        Try
            If True Then
                vl = txtReloj.Text.Trim.PadLeft(LongReloj, "0")
                If vl = "00000" Then
                    EsValido = False
                Else
                    txtReloj.Text = vl
                    dtInfoPersonal = ConsultaPersonalVW("SELECT RTRIM(nombre)+' '+RTRIM(apaterno)+' '+RTRIM(amaterno) AS nombres FROM personalvw " & _
                                                        "WHERE reloj = '" & vl & "'", False)
                    If dtInfoPersonal.Rows.Count = 0 Then
                        txtNombre.Text = ""
                        'If MessageBox.Show("El empleado " & vl & " no fue localizado.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then
                        '    EsValido = False
                        'Else
                        '    EsValido = True
                        'End If
                    Else
                        txtNombre.Text = dtInfoPersonal.Rows(0).Item("nombres").ToString.Trim
                    End If
                End If
            End If
            Return EsValido
        Catch ex As Exception
            txtNombre.Text = "ERROR"
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            Return False
        End Try
    End Function

    Private Sub cmbCurso_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbCurso.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("CAPACITACION.DBO.cursos", "cod_curso", "cursos", False)
        If Cod <> "CANCELAR" Then
            'Dim dtCol As DataTable = sqlExecute("SELECT * from colonias WHERE cod_col = '" & Cod & "'")            
            cmbCurso.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbInstituto_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbInstituto.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("CAPACITACION.DBO.institutos", "cod_instituto", "institutos", False)
        If Cod <> "CANCELAR" Then
            'Dim dtCol As DataTable = sqlExecute("SELECT * from colonias WHERE cod_col = '" & Cod & "'")            
            cmbInstituto.SelectedValue = Cod
        End If
    End Sub


    Private Sub cmbInstructor_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbInstructor.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("CAPACITACION.DBO.instructores", "cod_instructor", "instructores", False)
        If Cod <> "CANCELAR" Then
            'Dim dtCol As DataTable = sqlExecute("SELECT * from colonias WHERE cod_col = '" & Cod & "'")            
            cmbInstructor.SelectedValue = Cod
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                Dim dtPersonal As DataTable = ConsultaPersonalVW("SELECT TOP 1 * FROM PersonalVW WHERE reloj = '" & Reloj & "' ORDER BY reloj ASC")
                If dtPersonal.Rows.Count = 0 Then
                    MessageBox.Show("El empleado " & Reloj & " no fue localizado, o tiene un nivel al que su usuario no tiene acceso.", "Empleado no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Else
                    txtReloj.Text = Reloj
                End If
            Else
                Me.Dispose()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub

    Private Sub cmbCurso_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCurso.SelectedValueChanged
        Try
            Dim dtCurso As DataTable = sqlExecute("select cod_curso, isnull(duracion, 0) as duracion, isnull(calificacion_minima, 0) as minima from cursos where cod_curso = '" & cmbCurso.SelectedValue & "'", "capacitacion")
            If dtCurso.Rows.Count > 0 Then
                txtDuracion.Value = dtCurso.Rows(0)("duracion")

                If dtCurso.Rows(0)("minima") = 0 Then

                    lblaprobado.Visible = False
                    btnAprobado.Visible = True
                    btnAprobado.IsReadOnly = False

                    txtCalificacion.Visible = False
                    Label4.Visible = False
                    lblcalifminima.Text = "No requiere calificación"
                Else

                    btnAprobado.Visible = False
                    btnAprobado.IsReadOnly = True
                    lblaprobado.Visible = True

                    txtCalificacion.Visible = True
                    Label4.Visible = True


                    If txtCalificacion.Value >= dtCurso.Rows(0).Item("minima") Then
                        lblaprobado.Text = "APROBADO"
                    Else
                        lblaprobado.Text = "NO APROBADO"
                    End If

                    lblcalifminima.Text = "Calif. min. " & dtCurso.Rows(0)("minima")
                End If





            Else
                txtDuracion.Value = 0

            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnAprobado_ValueChanged(sender As Object, e As EventArgs) Handles btnAprobado.ValueChanged
        If btnAprobado.Value = False Then

            If txtCalificacion.Visible = False Then
                txtCalificacion.Value = 0
            End If

            lblaprobado.Text = "NO APROBADO"
        ElseIf btnAprobado.Value = True Then

            If txtCalificacion.Visible = False Then
                txtCalificacion.Value = 100
            End If

            lblaprobado.Text = "APROBADO"
        End If



    End Sub


End Class