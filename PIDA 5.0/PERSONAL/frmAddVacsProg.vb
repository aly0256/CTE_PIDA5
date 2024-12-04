Public Class frmAddVacsProg

    '================Evento cargar Load
    Private Sub frmAddVacsProg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '==============Limpiar controles
        txtBuscaEmpleado.Text = ""
        txtDias.Value = "0.00"
        txtNotas.Text = ""
        txtFechaDe.Value = Now

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAgregarEmpleado_Click(sender As Object, e As EventArgs) Handles btnAgregarEmpleado.Click
        '==========Buscar empleado y ponerlo en el textbox

        ' dtTemp = dtPersonal
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj.Trim)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            '  dtPersonal = dtTemp
        End Try
    End Sub

    Private Sub MostrarInformacion(ByVal _reloj As String)
        Try
            Dim dtPersonal As New DataTable, nombres As String = "", cadenaNombre As String = ""
            dtPersonal = sqlExecute("select reloj,nombres from personalvw where reloj='" & _reloj & "'", "PERSONAL")
            If Not dtPersonal.Columns.Contains("Error") And dtPersonal.Rows.Count > 0 Then
                Try : nombres = dtPersonal.Rows(0).Item("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
            End If

            cadenaNombre = _reloj & "-" & nombres

            txtBuscaEmpleado.Text = cadenaNombre

            ' Llenar txtBuscaEmpleado con el reloj y nombres
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' 'Método que cargará guardará el registro en vacs_prog para que lo mande al grid principal de vacaciones programadas
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try
            Dim mensajeError As String = "", reloj As String = "", cantDias As Double = 0.0, fecha_a_partir_de As String = "", query As String = "", _fecha_ini As Date, _fecha_fin As Date
            Dim dtExistenVacs As New DataTable, nombres As String = "", cod_comp As String = "", dtDatosPersonal As New DataTable, notas As String = ""

            Try : reloj = txtBuscaEmpleado.Text.Trim.Split("-")(0) : Catch ex As Exception : reloj = "" : End Try
            Try : nombres = txtBuscaEmpleado.Text.Trim.Split("-")(1) : Catch ex As Exception : nombres = "" : End Try
            Try : cantDias = Double.Parse(txtDias.Text) : Catch ex As Exception : cantDias = 0.0 : End Try
            Try : fecha_a_partir_de = FechaSQL(txtFechaDe.Value) : Catch ex As Exception : fecha_a_partir_de = "" : End Try
            Try : notas = txtNotas.Text.ToString.Trim : Catch ex As Exception : notas = "" : End Try



            If reloj = "" Then mensajeError = "- Favor de seleccionar a un empleado"
            If cantDias <= 0.0 Then mensajeError &= vbCrLf & "- La cantidad de días debe de ser mayor a cero"


            If fecha_a_partir_de <> "" Then
                Dim _f As Date, fHoy As Date
                _f = Date.Parse(fecha_a_partir_de)
                fHoy = Now.Date.ToShortDateString
                If _f < fHoy Then mensajeError &= vbCrLf & "- Debe de seleccionar una fecha a partir del día de hoy"
            Else
                mensajeError &= vbCrLf & "- Debe de seleccionar una fecha válida"
            End If

            '========Guardar cambios
            If mensajeError = "" Then
                dtDatosPersonal = sqlExecute("select cod_comp from personal where reloj='" & reloj & "'", "PERSONAL")
                If dtDatosPersonal.Rows.Count > 0 Then Try : cod_comp = dtDatosPersonal.Rows(0).Item("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try

                _fecha_ini = txtFechaDe.Value
                _fecha_fin = DateAdd(DateInterval.Day, cantDias - 1, _fecha_ini)
                Dim _fecha As Date = _fecha_ini

                '=====Validar que en las fechas que se manden, no haya ya vacaciones aplicadas
                Dim dtVacsAplicadas As New DataTable
                query = "select * from saldos_vacaciones  where reloj='" & reloj & "' and COMENTARIO ='VACACIONES' and (fecha_ini between '" & FechaSQL(_fecha_ini) & "' and '" & FechaSQL(_fecha_fin) & "' OR FECHA_FIN between '" & FechaSQL(_fecha_ini) & "' and '" & FechaSQL(_fecha_fin) & "')"
                dtVacsAplicadas = sqlExecute(query, "PERSONAL")
                If Not dtVacsAplicadas.Columns.Contains("Error") And dtVacsAplicadas.Rows.Count > 0 Then
                    MessageBox.Show("Ya existen vacaciones capturadas/aplicadas en las fechas que se envían, favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If


                '===Validar que no existan registros
                query = "select * from vacs_prog where reloj='" & reloj & "' and FECHA between'" & fecha_a_partir_de & "' and '" & FechaSQL(_fecha_fin) & "'"
                dtExistenVacs = sqlExecute(query, "PERSONAL")

                If Not dtExistenVacs.Columns.Contains("Error") And dtExistenVacs.Rows.Count > 0 Then

                    If MessageBox.Show("¿Ya existen registros capturados en las fechas enviadas, desea reemplazarlos?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        query = "delete from vacs_prog where reloj='" & reloj & "' and FECHA between'" & fecha_a_partir_de & "' and '" & FechaSQL(_fecha_fin) & "'"
                        sqlExecute(query, "PERSONAL")

                        Do While _fecha <= _fecha_fin
                            Dim addDia As Boolean = True
                            '====Evaluar que no sea dia de descanso o dia festivo, de lo contrario aumentar un dia
                            If (Festivo(_fecha, reloj) Or DiaDescanso(_fecha, reloj)) Then ' Si es festivo o descanso, aumentar en 1 dia la fecha final y no agregar esa fecha
                                _fecha_fin = _fecha_fin.AddDays(1)
                                addDia = False
                            End If

                            '=====Insertar cada registro de acuerdo a cada fecha
                            If addDia Then
                                query = "insert into vacs_prog (COD_COMP,RELOJ,NOMBRE,fecha, APLICADO,NOTAS,FECHA_APLICACION,USUARIO_APLICACION) values" & _
                               "('" & cod_comp & "','" & reloj & "','" & nombres & "','" & FechaSQL(_fecha) & "',0,'" & notas & "',getdate(),'" & Usuario & "')"
                                sqlExecute(query, "PERSONAL")
                            End If

                            _fecha = _fecha.AddDays(1)
                        Loop


                        Me.Close()
                    End If

                Else
                    '===Insertar registro

                    Do While _fecha <= _fecha_fin

                        Dim addDia As Boolean = True
                        '====Evaluar que no sea dia de descanso o dia festivo, de lo contrario aumentar un dia
                        If (Festivo(_fecha, reloj) Or DiaDescanso(_fecha, reloj)) Then ' Si es festivo o descanso, aumentar en 1 dia la fecha final y no agregar esa fecha
                            _fecha_fin = _fecha_fin.AddDays(1)
                            addDia = False
                        End If

                        '=====Insertar cada registro de acuerdo a cada fecha
                        If addDia Then
                            query = "insert into vacs_prog (COD_COMP,RELOJ,NOMBRE,fecha, APLICADO,NOTAS,FECHA_APLICACION,USUARIO_APLICACION) values" & _
                                     "('" & cod_comp & "','" & reloj & "','" & nombres & "','" & FechaSQL(_fecha) & "',0,'" & notas & "',getdate(),'" & Usuario & "')"
                            sqlExecute(query, "PERSONAL")
                        End If

                        _fecha = _fecha.AddDays(1)
                    Loop

                    Me.Close()

                End If

            Else
                MessageBox.Show(mensajeError, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub
End Class