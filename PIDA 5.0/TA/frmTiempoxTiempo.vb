Public Class frmTiempoxTiempo
    Public reloj_t As String
    Public horario_t As String
    Dim fecha1 As Date = Today()
    Dim fecha2 As Date = Date.Today.AddDays(1)
    Private Sub frmTiempoxTiempo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'txtFechaOriginal.Value = Today()
        'txtNuevafecha.Value = Date.Today.AddDays(1)
    End Sub

    Private Sub txtFechaOriginal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaOriginal.ValueChanged

        Dim dthorario As DataTable
        Dim semana As String
        Dim descanso As Boolean
        semana = SemanaHorarioMixto(ObtenerAnoPeriodo(txtFechaOriginal.Value), reloj_t).NumSemana
        dthorario = sqlExecute("select descanso from dias where cod_hora = '" & Trim(horario_t.Substring(0, 3)) & "' and semana = '" & semana & "' and cod_dia = '" & NumDia(txtFechaOriginal.Value) & "' ")
        If dthorario.Rows.Count > 0 Then
            descanso = IIf(IsDBNull(dthorario.Rows(0).Item("descanso")), False, dthorario.Rows(0).Item("descanso"))


            If descanso Then
                MessageBox.Show("Tienes que escoger un dia hábil", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtFechaOriginal.Value = Nothing
            Else
                Dim dtempaus As DataTable = sqlExecute("select * from ausentismo where fecha = '" & FechaSQL(txtFechaOriginal.Value) & "' and reloj = '" & reloj_t & "' and tipo_aus <> 'FI'", "TA")
                If dtempaus.Rows.Count > 0 Then
                    MessageBox.Show("Hay un ausentismo caputardo para este empleado en la fecha elegida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtFechaOriginal.Value = Nothing
                End If
            End If
        End If


    End Sub

    Private Sub txtNuevafecha_ValueChanged(sender As Object, e As EventArgs) Handles txtNuevafecha.ValueChanged
  
        Dim dthorario As DataTable
        Dim semana As String
        Dim descanso As Boolean
        semana = SemanaHorarioMixto(ObtenerAnoPeriodo(txtNuevafecha.Value), reloj_t).NumSemana
        dthorario = sqlExecute("select descanso from dias where cod_hora = '" & Trim(horario_t.Substring(0, 3)) & "' and semana = '" & semana & "' and cod_dia = '" & NumDia(txtNuevafecha.Value) & "' ")
        If dthorario.Rows.Count > 0 Then
            descanso = IIf(IsDBNull(dthorario.Rows(0).Item("descanso")), False, dthorario.Rows(0).Item("descanso"))


            If Not descanso Then
                MessageBox.Show("Tienes que escoger un dia inhábil", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNuevafecha.Value = Nothing
            End If
        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim dtperiodoO As DataTable = sqlExecute("select * from periodos where fecha_ini <= '" & FechaSQL(txtFechaOriginal.Value) & "' and fecha_fin >= '" & FechaSQL(txtFechaOriginal.Value) & "'", "TA")
        Dim dtperiodoN As DataTable = sqlExecute("select * from periodos where fecha_ini <= '" & FechaSQL(txtNuevafecha.Value) & "' and fecha_fin >= '" & FechaSQL(txtNuevafecha.Value) & "'", "TA")
        If dtperiodoO.Rows.Count > 0 And dtperiodoN.Rows.Count > 0 Then
            If dtperiodoN.Rows(0).Item("Periodo") = dtperiodoO.Rows(0).Item("Periodo") Then

                sqlExecute("insert into tiempo_x_tiempo values ('" & reloj_t & "', '" & Trim(horario_t.Substring(0, 3)) & "', '" & FechaSQL(txtFechaOriginal.Value) & "','" & FechaSQL(txtNuevafecha.Value) & "', '" & Usuario & "','" & FechaHoraSQL(Date.Now) & "')")
                MessageBox.Show("El cambio se realizo correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("No puedes intercambiar fechas de distintos periodos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Revisa las fechas seleccionadas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class