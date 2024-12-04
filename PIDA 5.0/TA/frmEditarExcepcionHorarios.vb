Imports System.Data.SqlClient

Public Class frmEditarExcepcionHorarios
    Dim dtConceptos As New DataTable
    Dim dtPeriodos As New DataTable
    Dim dtAjustes As New DataTable
    Dim dtTemp As New DataTable
    Dim dtNaturalezas As New DataTable
    Dim drAjustesNom As DataRow
    Dim Nuevo As Boolean
    Dim Dias As Integer
    Dim FechaOriginal As Date
    Dim cod_comp As String

    Private Sub frmEditarAjustes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub


    Private Sub frmEditarAjustes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PeriodoActivo As String = ""
        Dim dtTipoAjuste As New DataTable
        Dim dtEmpleado As New DataTable
        Dim Reloj As String
        Dim Fecha As Date
        Dim T As String
        Dim F As Date

        Try

         
            cmbHorario.DataSource = sqlExecute("SELECT DISTINCT cod_hora, nombre FROM excepciones_dias")

            If frmExcepcionHorarios.RlExcep = "NUEVO" Then

                txtReloj.Text = reloj_exc
                cmbHorario.SelectedValue = "001"
            ElseIf frmExcepcionHorarios.RlExcep = "NUEVO1" Then
                txtReloj.Enabled = True
                cmbHorario.SelectedValue = "001"
            Else

                T = frmExcepcionHorarios.RlExcep
                Reloj = T.Substring(0, LongReloj).Trim
                T = T.Substring(LongReloj)


                If Not Date.TryParse(T, Fecha) Then
                    Fecha = Now
                End If

                dtEmpleado = sqlExecute("SELECT excepciones_horarios.reloj, RTRIM(APATERNO)+' ' + RTRIM(AMATERNO)+' '+RTRIM(NOMBRE) AS NOMBRES," & _
                                   "excepciones_horarios.cod_hora,excepciones_horarios.cod_hora_personal,excepciones_horarios.fecha,excepciones_horarios.comentario " & _
                                   "FROM excepciones_horarios LEFT JOIN personal ON excepciones_horarios.cod_comp = personal.cod_comp " & _
                                   "AND excepciones_horarios.reloj = personal.reloj WHERE excepciones_horarios.cod_comp = personal.cod_comp " & _
                                   "and excepciones_horarios.reloj = '" & Reloj & "' and excepciones_horarios.fecha = '" & FechaSQL(Fecha) & "'")
                If dtEmpleado.Rows.Count = 0 Then
                    Err.Raise(-1, "La información de excepción de horario del empleado " & Reloj & ", el día " & FechaSQL(Fecha) & " no fue localizada")
                End If

                'Revisar cuántos días son
                Dias = 0
                Do
                    Dias = Dias + 1
                    ' F = DateAdd(DateInterval.Day, 1, Fecha)
                    dtTemp = sqlExecute("SELECT 1 FROM excepciones_horarios WHERE excepciones_horarios.reloj = '" & Reloj & "' and excepciones_horarios.fecha = '" & FechaSQL(Fecha) & "'")
                Loop Until dtTemp.Rows.Count > 0

                FechaOriginal = Fecha

                txtReloj.Text = Reloj
                txtNombre.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("nombres")), "", dtEmpleado.Rows(0)("nombres"))
                txtHorario.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_hora_personal")), "", dtEmpleado.Rows(0)("cod_hora_personal"))
                txtFecha.Value = IIf(IsDBNull(dtEmpleado.Rows(0)("fecha")), Now, dtEmpleado.Rows(0)("fecha"))

                txtComentario.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("comentario")), "", dtEmpleado.Rows(0)("comentario"))

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim semana As Integer
        Dim Fecha As Date
        Dim dthorario As DataTable
        Dim dtaus As DataTable
        Dim dtmax As Integer
        Dim dtperiodofecha As DataTable
        Dim dtexcepciones As DataTable
        Dim descanso As Boolean
        Try
            '*****si se va a editar, se elimina para volver a captuar
            If frmExcepcionHorarios.RlExcep <> "NUEVO" Then
                sqlExecute("DELETE FROM excepciones_horarios WHERE cod_comp = '" & cod_comp & "' AND excepciones_horarios.reloj = '" & Reloj & "' and excepciones_horarios.fecha =  '" & _
                           FechaSQL(FechaOriginal) & "'")
            End If



            Reloj = txtReloj.Text
            Fecha = txtFecha.Value
            semana = SemanaHorarioMixto(ObtenerAnoPeriodo(txtFecha.Value), txtReloj.Text).NumSemana
            '*****Revisar el maximo de excepciones por semana
            Dim dtBitacora As DataTable = sqlExecute("select * from bitacora_personal left join ta.dbo.periodos on bitacora_personal.fecha between periodos.FECHA_INI and periodos.FECHA_FIN where reloj = '" & Reloj & "' and campo = 'cod_hora' and ISNULL(periodos.periodo_especial, 0) = 0 and periodos.ANO+periodo > '" & (ObtenerAnoPeriodo(txtFecha.Value)) & "' order by fecha asc")
            If dtBitacora.Rows.Count > 0 Then
                Dim anterior As String = dtBitacora.Rows(0)("valoranterior")
                txtHorario.Text = anterior
            End If




            dtmax = sqlExecute("select * from dias where semana = '" & semana & "' and cod_hora = '" & Trim(txtHorario.Text) & "' and descanso = '0' and cod_comp = '" & cod_comp.Trim & "'").Rows.Count
            dtperiodofecha = sqlExecute("select * from periodos where fecha_ini <= '" & FechaSQL(Fecha) & "' and fecha_fin >= '" & FechaSQL(Fecha) & "' and periodo_especial = '0'", "TA")
            dtexcepciones = sqlExecute("select * from excepciones_horarios where fecha BETWEEN '" & FechaSQL(dtperiodofecha.Rows(0).Item("fecha_ini")) & "' and  '" & FechaSQL(dtperiodofecha.Rows(0).Item("fecha_fin")) & "' and reloj = '" & Reloj & "'")

            If dtexcepciones.Rows.Count < dtmax - 1 Then
                '*****Revisar si ya hay una excepcion en la fecha seleccionada
                If sqlExecute("select * from excepciones_horarios where fecha = '" & FechaSQL(Fecha) & "' and reloj = '" & Reloj & "'").Rows.Count > 0 Then
                    MessageBox.Show("Ya hay una excepción capturada en la fecha " & FechaSQL(Fecha).ToString & " para este empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    dthorario = sqlExecute("select descanso from dias where cod_hora = '" & Trim(txtHorario.Text) & "' and semana = '" & semana & "' and cod_dia = '" & NumDiaex(txtFecha.Value, False) & "' ")

                    If dthorario.Rows.Count > 0 Then
                        descanso = IIf(IsDBNull(dthorario.Rows(0).Item("descanso")), False, dthorario.Rows(0).Item("descanso"))

                        Dim tiempo_x_tiempo As Boolean = False
                        Dim dtExcepcionTiempoxTiempo As DataTable = sqlExecute("select * from tiempo_x_tiempo where reloj = '" & Reloj & "' and fecha_intercambio = '" & FechaSQL(Fecha) & "'", "personal")
                        If dtExcepcionTiempoxTiempo.Rows.Count > 0 Then
                            tiempo_x_tiempo = True
                        End If


                        If (Not descanso) Or tiempo_x_tiempo Then

                            dtaus = sqlExecute("select * from ausentismo where reloj = '" & txtReloj.Text & "' and fecha = '" & FechaSQL(txtFecha.Value) & "'", "TA")

                            If dtaus.Rows.Count > 0 Then
                                Dim aus As String = IIf(IsDBNull(dtaus.Rows(0).Item("TIPO_AUS")), "", dtaus.Rows(0).Item("TIPO_AUS"))

                                If Trim(aus) = "FI" Then
                                    sqlExecute("INSERT INTO excepciones_horarios (cod_comp,reloj,cod_hora,cod_hora_personal,fecha,fecha_captura,hora_captura,usuario,comentario) VALUES (" & _
                                "'" & cod_comp & "'," & _
                                "'" & Reloj & "'," & _
                                "'" & cmbHorario.SelectedValue.ToString.Trim & "'," & _
                                "'" & txtHorario.Text & "'," & _
                                "'" & FechaSQL(Fecha) & "'," & _
                                "'" & FechaSQL(Now) & "'," & _
                                "'" & Now.TimeOfDay.Hours.ToString.PadLeft(2, "0") & ":" & Now.TimeOfDay.Minutes.ToString.PadLeft(2, "0") & ":" & Now.TimeOfDay.Seconds & "'," & _
                                "'" & Usuario & "'," & _
                                "'" & txtComentario.Text.Trim & "')")
                                    Me.DialogResult = Windows.Forms.DialogResult.OK
                                Else

                                End If
                            Else
                                sqlExecute("INSERT INTO excepciones_horarios (cod_comp,reloj,cod_hora,cod_hora_personal,fecha,fecha_captura,hora_captura,usuario,comentario) VALUES (" & _
                                "'" & cod_comp & "'," & _
                                "'" & Reloj & "'," & _
                                "'" & cmbHorario.SelectedValue.ToString.Trim & "'," & _
                                "'" & txtHorario.Text & "'," & _
                                "'" & FechaSQL(Fecha) & "'," & _
                                "'" & FechaSQL(Now) & "'," & _
                                "'" & Now.TimeOfDay.Hours.ToString.PadLeft(2, "0") & ":" & Now.TimeOfDay.Minutes.ToString.PadLeft(2, "0") & ":" & Now.TimeOfDay.Seconds & "'," & _
                                "'" & Usuario & "'," & _
                                "'" & txtComentario.Text.Trim & "')")
                                Me.DialogResult = Windows.Forms.DialogResult.OK
                            End If

                        Else
                            MessageBox.Show("No puedes agregar una excepción en un dia inhábil", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If

                    End If

                End If
            Else
                MessageBox.Show("No puedes capturar mas excepciones en este periodo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If



        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        End Try
    End Sub

    Public Function NumDiaex(Fecha As Date, Optional IniciaLunes As Boolean = True) As Integer
        Try
            Dim N As Integer
            N = Fecha.DayOfWeek
            If Not IniciaLunes Then
                'N = N - 1
                If N = 0 Then
                    N = 7
                End If
            End If
            Return N
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return -1
        End Try
    End Function
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub


    Private Sub txtReloj_TextChanged(sender As Object, e As EventArgs) Handles txtReloj.TextChanged
        Dim dtEmpleado As New DataTable

        If txtReloj.Text = "" Then Exit Sub
        Reloj = txtReloj.Text.Trim.PadLeft(LongReloj, "0")
        dtEmpleado = sqlExecute("SELECT personal.cod_hora,cod_comp, " & _
                    "RTRIM(ISNULL(dbo.personal.APATERNO, ''))  + ',' + RTRIM(ISNULL(dbo.personal.AMATERNO, '')) + ',' + RTRIM(ISNULL(dbo.personal.NOMBRE, '')) " & _
                    " as nombres FROM personal WHERE reloj = '" & Reloj & "'")
        If dtEmpleado.Rows.Count > 0 Then
            txtReloj.Text = Reloj
            txtFecha.Value = Now
            txtNombre.Text = If(IsDBNull(dtEmpleado.Rows(0)("nombres")), "", dtEmpleado.Rows(0)("nombres"))
            txtHorario.Text = If(IsDBNull(dtEmpleado.Rows(0)("cod_hora")), "", dtEmpleado.Rows(0)("cod_hora"))
            'cmbHorario.SelectedValue = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_hora")), "", dtEmpleado.Rows(0)("cod_hora"))
            cod_comp = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_comp")), "", dtEmpleado.Rows(0)("cod_comp"))
        End If

    End Sub

    Private Sub txtFecha_ValueChanged(sender As Object, e As EventArgs) Handles txtFecha.ValueChanged

        Dim dtperiodoseleccionado As New DataTable
        Dim dtperiodoactual As New DataTable
        Dim periodoactual As String
        Dim periodoseleccionado As String


        dtperiodoactual = sqlExecute("select * from periodos where periodo_especial <> '1' and (fecha_ini <= '" & FechaSQL(Date.Today) & "' and fecha_fin >= '" & FechaSQL(Date.Today) & "' )", "TA")
        periodoactual = dtperiodoactual.Rows(0).Item("periodo")

        dtperiodoseleccionado = sqlExecute("select * from periodos where periodo_especial <> '1' and (fecha_ini <= '" & FechaSQL(txtFecha.Value) & "' and fecha_fin >= '" & FechaSQL(txtFecha.Value) & "')", "TA")
        periodoseleccionado = dtperiodoseleccionado.Rows(0).Item("periodo")

        If Not sqlExecute("select * from periodos where periodo = '" & periodoseleccionado & "' and activo = '1'", "TA").Rows.Count > 0 Then
            If periodoactual <> periodoseleccionado Then
                MessageBox.Show("No puedes escoger una fecha de un periodo no activo pasado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtFecha.Value = Date.Today
            End If
        End If

    End Sub
End Class