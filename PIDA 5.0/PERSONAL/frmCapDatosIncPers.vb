Public Class frmCapDatosIncPers

    Dim dtInfoReporte As New DataTable

    Private Sub frmCapDatosIncPers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '====Evento LOAD

        '=====Limpiar controles
        gpbFalta.Visible = False
        gpbVac.Visible = False
        txtBuscaEmpleado.Text = ""
        LimpiaControlesGrupos()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim _index As Integer = -1, mensajeError As String = "", fecha_inicio As String = "", reloj As String = "", query As String = "", nombre As String = ""
            Dim dtPersonal As New DataTable, cod_comp As String = "", alta As String = "", depto As String = "", puesto As String = "", _tipo_movimiento As String = ""
            Dim dtAfectaRegistros As New DataTable, recsAfectados As Integer = 0

            _index = cmbTipoMov.SelectedIndex  ' 0--Vacacion; 1--PCG; 2--PermisoSinGoce; 3- Tolerancia; 4 -Falta Injus; 5 - Falta Justificada


            If txtBuscaEmpleado.Text.Trim <> "" Then

                Try : reloj = txtBuscaEmpleado.Text.Trim.Split("-")(0) : Catch ex As Exception : reloj = "" : End Try
                Try : nombre = txtBuscaEmpleado.Text.Trim.Split("-")(1) : Catch ex As Exception : nombre = "" : End Try

                '================Obtener datos del empleado
                dtPersonal = sqlExecute("select * from personalvw where reloj='" & reloj & "'", "PERSONAL")
                If Not dtPersonal.Columns.Contains("Error") And dtPersonal.Rows.Count > 0 Then
                    Try : cod_comp = dtPersonal.Rows(0).Item("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try
                    Try : alta = FechaSQL(dtPersonal.Rows(0).Item("alta")) : Catch ex As Exception : alta = "" : End Try
                    Try : depto = dtPersonal.Rows(0).Item("nombre_depto").ToString.Trim : Catch ex As Exception : depto = "" : End Try
                    Try : puesto = dtPersonal.Rows(0).Item("nombre_puesto").ToString.Trim : Catch ex As Exception : puesto = "" : End Try
                End If


                '================VALIDACIONES GENERALES

                '====Vacliar que la fecha de inicio de vacacion sea mayor o igual al dia de hoy
                Try : fecha_inicio = FechaSQL(txtFIniVac.Value) : Catch ex As Exception : fecha_inicio = "" : End Try
                If fecha_inicio <> "" Then
                    Dim _f As Date, fHoy As Date
                    _f = Date.Parse(fecha_inicio)
                    fHoy = Now.Date.ToShortDateString
                    If _f < fHoy Then mensajeError &= vbCrLf & "- Debe de seleccionar una fecha a partir del día de hoy"
                Else
                    mensajeError &= vbCrLf & "- Debe de seleccionar una fecha válida"
                End If


                '============Obtener la fecha fin de regreso real ya que puede haber dias festivos o descanso
                If _index = 0 Or _index = 1 Or _index = 2 Then

                    Dim _fecha As Date = txtFIniVac.Value.ToShortDateString
                    Dim _fecha_fin As Date = txtFechaRegVac.Value.ToShortDateString

                    Do While _fecha <= _fecha_fin

                        '====Evaluar que no sea dia de descanso o dia festivo, de lo contrario aumentar un dia
                        If (Festivo(_fecha, reloj) Or DiaDescanso(_fecha, reloj)) Then ' Si es festivo o descanso, aumentar en 1 dia la fecha final y no agregar esa fecha
                            _fecha_fin = _fecha_fin.AddDays(1)
                        End If
                        _fecha = _fecha.AddDays(1)
                    Loop

                    txtFechaRegVac.Value = _fecha_fin

                End If



                '=====================================================================================================================================================================================================================
                '======================================================================================VACACIONES=====================================================================================================================
                '=====================================================================================================================================================================================================================

                If _index = 0 Then
                    _tipo_movimiento = "Vacación"

                    '=====Validar que no existan registros de vacaciones programadas o de vacaciones aplicadas en las fechas enviadas
                    '===1ero en vacs_progs
                    Dim dtExisteVacsProg As New DataTable
                    query = "select * from vacs_prog where reloj='" & reloj & "' and isnull(aplicado,0)=0  and FECHA between'" & fecha_inicio & "' and '" & FechaSQL(txtFechaRegVac.Value) & "'"
                    dtExisteVacsProg = sqlExecute(query, "PERSONAL")
                    If Not dtExisteVacsProg.Columns.Contains("Error") And dtExisteVacsProg.Rows.Count > 0 Then
                        mensajeError &= vbCrLf & "- Ya existen días de vacaciones programadas en las fechas solicitadas"
                    End If

                    '===2do vacaciones ya aplicadas en saldos_vacaciones
                    Dim dtVacsAplicadas As New DataTable
                    query = "select * from saldos_vacaciones  where reloj='" & reloj & "' and COMENTARIO ='VACACIONES' and (fecha_ini between '" & fecha_inicio & "' and '" & FechaSQL(txtFechaRegVac.Value) & "' OR FECHA_FIN between '" & fecha_inicio & "' and '" & FechaSQL(txtFechaRegVac.Value) & "')"
                    dtVacsAplicadas = sqlExecute(query, "PERSONAL")
                    If Not dtVacsAplicadas.Columns.Contains("Error") And dtVacsAplicadas.Rows.Count > 0 Then
                        mensajeError &= vbCrLf & "- Ya existen días de vacaciones aplicadas en las fechas solicitadas"
                    End If

                    '=====Validar que no exista el registro ya capturado
                    Dim dtExisteRecCap As New DataTable
                    query = "select * from solicitud_incidencias_personal where cod_comp='" & cod_comp & "' and reloj='" & reloj & "' and tipo_movimiento=" & _index & " and f_ini_vac='" & fecha_inicio & "'"
                    dtExisteRecCap = sqlExecute(query, "PERSONAL")
                    If Not dtExisteRecCap.Columns.Contains("Error") And dtExisteRecCap.Rows.Count > 0 Then
                        MessageBox.Show("Ya existe una incidencia capturada en la misma fecha", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    '=====Guardar cambios
                    If mensajeError = "" Then

                        Dim f_ini_vac As Date = txtFIniVac.Value, f_fin_vac As Date = txtFechaRegVac.Value, periodo_vac As String = "", dias_vac_pend_gozar As String = ""
                        Dim dias_vac = txtDiasVac.Value

                        '====HERE AOS 2024-08-23  Mandar mensaje de confirmación con los datos capturados, reloj, tipo de movimento, cant de dias, fecha de salida y de regreso, si acepta, proceder ahora sí con el guardado
                        Dim _mensaje As String = ""
                        _mensaje = "Va a registrar una incidencia con la siguiente información:" & vbCrLf
                        _mensaje &= "Reloj-Nombre: " & reloj & "-" & nombre & vbCrLf
                        _mensaje &= "Tipo de movimiento: " & _tipo_movimiento & vbCrLf
                        _mensaje &= "Cantidad de días: " & dias_vac.ToString & vbCrLf
                        _mensaje &= "Fecha de salida: " & FechaSQL(f_ini_vac) & vbCrLf
                        _mensaje &= "Fecha de regreso: " & FechaSQL(f_fin_vac) & vbCrLf
                        _mensaje &= "Desea registrar esta incidencia?"

                        If MessageBox.Show(_mensaje, "P.I.D.A.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                            '==Obtener periodo de vacacion, y dias de vacaciones pendientes de gozar
                            periodo_vac = ObtenerPeriodo(f_ini_vac)

                            '===Proceso para obtener el saldo actual de vacaciones
                            Dim _dias_ganados As Integer = 0, _dias_tomados As Integer = 0, _dias_devengados As Double = 0.0, dtTotalesSaldoVacs As New DataTable

                            dtTotalesSaldoVacs = sqlExecute("select reloj,SUM(CAST(dias as int)) as dias_ganados, SUM(CAST(tiempo as int)) as dias_tomados  from saldos_vacaciones " & _
                                                         "where RELOJ= '" & reloj & "' group by RELOJ ")

                            If Not dtTotalesSaldoVacs.Columns.Contains("Error") And dtTotalesSaldoVacs.Rows.Count > 0 Then

                                Try : _dias_ganados = dtTotalesSaldoVacs.Rows(0).Item("dias_ganados") : Catch ex As Exception : _dias_ganados = 0 : End Try
                                Try : _dias_tomados = dtTotalesSaldoVacs.Rows(0).Item("dias_tomados") : Catch ex As Exception : _dias_tomados = 0 : End Try

                            End If

                            _dias_devengados = VacacionesDevengadas(reloj, Now.Date) '==Días Devengados a la fecha actual 
                            dias_vac_pend_gozar = Double.Parse(_dias_ganados - _dias_tomados - dias_vac + _dias_devengados) ' dias_vac son los dias que estan solicitando en la incidencia, y se restan del saldo

                            '===Hacer el insert

                            query = "insert into solicitud_incidencias_personal (cod_comp,reloj,nombre,f_captura,aplicado,impreso,depto,alta,puesto,tipo_movimiento,periodo_vac,dias_vac,f_ini_vac,f_fin_vac,dias_vac_pend_gozar,usuario) " & _
                                "values ('" & cod_comp & "','" & reloj & "','" & nombre & "',getdate(),0,0,'" & depto & "','" & alta & "','" & puesto & "'," & _index & ",'" & periodo_vac & "'," & dias_vac & ",'" & FechaSQL(f_ini_vac) & "','" & FechaSQL(f_fin_vac) & "','" & dias_vac_pend_gozar & "','" & Usuario & "') " & _
                                "select @@ROWCOUNT as 'RowsAfected'"

                            dtAfectaRegistros = sqlExecute(query, "PERSONAL")

                            If Not dtAfectaRegistros.Columns.Contains("Error") And dtAfectaRegistros.Rows.Count > 0 Then
                                Try : recsAfectados = Convert.ToInt32(dtAfectaRegistros.Rows(0).Item("RowsAfected").ToString.Trim) : Catch ex As Exception : recsAfectados = 0 : End Try
                                '===Mandar mensaje de confirmación que se agregó correctamente
                                If recsAfectados > 0 Then

                                    '====Probar reporte
                                    'Dim fecha_ini As Date = f_ini_vac
                                    'GenDataRepInciPers(reloj, _index, fecha_ini, cod_comp)
                                    'frmVistaPrevia.LlamarReporte("Reporte para incidencias del personal", dtInfoReporte)
                                    'frmVistaPrevia.ShowDialog()


                                    MessageBox.Show("El registro fue agregado de forma correcta", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Me.Close()
                                End If

                            Else
                                MessageBox.Show("Hubo un error al guardar el registro", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Close()
                            End If

                        End If

                    Else
                        MessageBox.Show(mensajeError, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End If


                '=====================================================================================================================================================================================================================
                '======================================================================================PERMISO CON GOCE DE SUELDO y SIN GOCE DE SUELDO================================================================================
                '=====================================================================================================================================================================================================================

                If (_index = 1 Or _index = 2) Then


                    Select Case _index
                        Case 1
                            _tipo_movimiento = "Permiso con goce de sueldo"
                        Case 2
                            _tipo_movimiento = "Permiso sin goce de sueldo"
                    End Select

                    '=====Validar que no exista el registro ya capturado
                    Dim dtExisteRecCap As New DataTable
                    query = "select * from solicitud_incidencias_personal where cod_comp='" & cod_comp & "' and reloj='" & reloj & "' and tipo_movimiento=" & _index & " and f_ini='" & fecha_inicio & "'"
                    dtExisteRecCap = sqlExecute(query, "PERSONAL")
                    If Not dtExisteRecCap.Columns.Contains("Error") And dtExisteRecCap.Rows.Count > 0 Then
                        MessageBox.Show("Ya existe una incidencia capturada en la misma fecha", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    '====Guardar cambios
                    If mensajeError = "" Then
                        '==Obtener periodo y dias
                        Dim f_ini As Date = txtFIniVac.Value
                        Dim f_reg As Date = txtFechaRegVac.Value
                        Dim dias = txtDiasVac.Value
                        Dim periodo = ObtenerPeriodo(f_ini)
                        Dim m As String = txtMotivo.Text.ToString.Trim

                        '=============Mandar mensaje de confirmación
                        Dim _mensaje As String = ""
                        _mensaje = "Va a registrar una incidencia con la siguiente información:" & vbCrLf
                        _mensaje &= "Reloj-Nombre: " & reloj & "-" & nombre & vbCrLf
                        _mensaje &= "Tipo de movimiento: " & _tipo_movimiento & vbCrLf
                        _mensaje &= "Cantidad de días: " & dias.ToString & vbCrLf
                        _mensaje &= "Fecha de salida: " & FechaSQL(f_ini) & vbCrLf
                        _mensaje &= "Fecha de regreso: " & FechaSQL(f_reg) & vbCrLf
                        _mensaje &= "Motivo: " & m & vbCrLf
                        _mensaje &= "Desea registrar esta incidencia?"

                        If MessageBox.Show(_mensaje, "P.I.D.A.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                            query = "insert into solicitud_incidencias_personal (cod_comp,reloj,nombre,f_captura,aplicado,impreso,depto,alta,puesto,tipo_movimiento,periodo,dias,f_ini,f_fin,usuario, motivo) values " & _
                                     "('" & cod_comp & "','" & reloj & "','" & nombre & "',getdate(),0,0,'" & depto & "','" & alta & "','" & puesto & "'," & _index & ",'" & periodo & "'," & dias & ",'" & FechaSQL(f_ini) & "','" & FechaSQL(f_reg) & "','" & Usuario & "','" & m & "') " & _
                                      "select @@ROWCOUNT as 'RowsAfected'"

                            dtAfectaRegistros = sqlExecute(query, "PERSONAL")

                            If Not dtAfectaRegistros.Columns.Contains("Error") And dtAfectaRegistros.Rows.Count > 0 Then
                                Try : recsAfectados = Convert.ToInt32(dtAfectaRegistros.Rows(0).Item("RowsAfected").ToString.Trim) : Catch ex As Exception : recsAfectados = 0 : End Try
                                '===Mandar mensaje de confirmación que se agregó correctamente
                                If recsAfectados > 0 Then

                                    '====Probar reporte
                                    'Dim fecha_ini As Date = txtFIniVac.Value
                                    'GenDataRepInciPers(reloj, _index, fecha_ini, cod_comp)
                                    'frmVistaPrevia.LlamarReporte("Reporte para incidencias del personal", dtInfoReporte)
                                    'frmVistaPrevia.ShowDialog()


                                    MessageBox.Show("El registro fue agregado de forma correcta", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Me.Close()
                                End If

                            Else
                                MessageBox.Show("Hubo un error al guardar el registro", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Close()
                            End If

                        End If

                    End If

                End If


                '=====================================================================================================================================================================================================================
                '======================================================================================TOLERANCIA / FI / FJ *****=====================================================================================================
                '=====================================================================================================================================================================================================================
                If (_index = 3 Or _index = 4 Or _index = 5) Then

                    Select Case _index
                        Case 3
                            _tipo_movimiento = "Tolerancia"
                        Case 4
                            _tipo_movimiento = "Falta injustificada"
                        Case 5
                            _tipo_movimiento = "Falta justificada"
                    End Select

                    '=====Validar que no exista el registro ya capturado
                    Dim dtExisteRecCap As New DataTable
                    query = "select * from solicitud_incidencias_personal where cod_comp='" & cod_comp & "' and reloj='" & reloj & "' and tipo_movimiento=" & _index & " and f_ini='" & fecha_inicio & "'"
                    dtExisteRecCap = sqlExecute(query, "PERSONAL")
                    If Not dtExisteRecCap.Columns.Contains("Error") And dtExisteRecCap.Rows.Count > 0 Then
                        MessageBox.Show("Ya existe una incidencia capturada en la misma fecha", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    If mensajeError = "" Then
                        Dim f As Date = txtFechaFalta.Value
                        Dim m As String = txtMotivo.Text.ToString.Trim
                        Dim periodo = ObtenerPeriodo(f)

                        '=============Mandar mensaje de confirmación
                        Dim _mensaje As String = "", _fecha_regreso As Date
                        _fecha_regreso = f.AddDays(1)  ' solo para mostrar en pantalla

                        _mensaje = "Va a registrar una incidencia con la siguiente información:" & vbCrLf
                        _mensaje &= "Reloj-Nombre: " & reloj & "-" & nombre & vbCrLf
                        _mensaje &= "Tipo de movimiento: " & _tipo_movimiento & vbCrLf
                        _mensaje &= "Cantidad de días: 1 " & vbCrLf
                        _mensaje &= "Fecha de salida: " & FechaSQL(f) & vbCrLf
                        _mensaje &= "Fecha de regreso: " & FechaSQL(_fecha_regreso) & vbCrLf
                        _mensaje &= "Motivo: " & m & vbCrLf
                        _mensaje &= "Desea registrar esta incidencia?"

                        If MessageBox.Show(_mensaje, "P.I.D.A.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                            query = "insert into solicitud_incidencias_personal (cod_comp,reloj,nombre,f_captura,aplicado,impreso,depto,alta,puesto,tipo_movimiento,periodo,dias,f_ini,f_fin,usuario,motivo) values " & _
                                "('" & cod_comp & "','" & reloj & "','" & nombre & "',getdate(),0,0,'" & depto & "','" & alta & "','" & puesto & "'," & _index & ",'" & periodo & "',1,'" & FechaSQL(f) & "','" & FechaSQL(f) & "','" & Usuario & "','" & m & "') " & _
                                 "select @@ROWCOUNT as 'RowsAfected'"

                            dtAfectaRegistros = sqlExecute(query, "PERSONAL")

                            If Not dtAfectaRegistros.Columns.Contains("Error") And dtAfectaRegistros.Rows.Count > 0 Then
                                Try : recsAfectados = Convert.ToInt32(dtAfectaRegistros.Rows(0).Item("RowsAfected").ToString.Trim) : Catch ex As Exception : recsAfectados = 0 : End Try
                                '===Mandar mensaje de confirmación que se agregó correctamente
                                If recsAfectados > 0 Then

                                    '====Probar reporte
                                    'Dim fecha_ini As Date = txtFechaFalta.Value
                                    'GenDataRepInciPers(reloj, _index, fecha_ini, cod_comp)
                                    'frmVistaPrevia.LlamarReporte("Reporte para incidencias del personal", dtInfoReporte)
                                    'frmVistaPrevia.ShowDialog()

                                    MessageBox.Show("El registro fue agregado de forma correcta", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Me.Close()
                                End If

                            Else
                                MessageBox.Show("Hubo un error al guardar el registro", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Close()
                            End If


                        End If


                    End If

                End If



            Else
                MessageBox.Show("Debe de seleccionar un empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.Close()
    End Sub

    Private Sub btnAgregarEmpleado_Click(sender As Object, e As EventArgs) Handles btnAgregarEmpleado.Click
        '==========Buscar empleado y ponerlo en el textbox
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj.Trim)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
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

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbTipoMov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMov.SelectedIndexChanged
        Dim _index As Integer = -1
        _index = cmbTipoMov.SelectedIndex

        If (_index = 0) Then
            gpbVac.Visible = True
            gpbFalta.Visible = False
            LimpiaControlesGrupos()
        ElseIf (_index = 1 Or _index = 2) Then
            gpbVac.Visible = True
            gpbFalta.Visible = True
            txtFechaFalta.Visible = False
            LimpiaControlesGrupos()

        ElseIf (_index = 3 Or _index = 4 Or _index = 5) Then
            gpbFalta.Visible = True
            gpbVac.Visible = False
            txtFechaFalta.Visible = True
            LimpiaControlesGrupos()

        Else
            gpbFalta.Visible = False
            gpbVac.Visible = False
            LimpiaControlesGrupos()

        End If

        'If (_index = 0 Or _index = 1 Or _index = 2) Then
        '    gpbVac.Visible = True
        '    gpbFalta.Visible = False
        '    LimpiaControlesGrupos()
        'ElseIf (_index = 3 Or _index = 4 Or _index = 5) Then
        '    gpbFalta.Visible = True
        '    gpbVac.Visible = False
        '    LimpiaControlesGrupos()
        'Else
        '    gpbFalta.Visible = False
        '    gpbVac.Visible = False
        '    LimpiaControlesGrupos()
        'End If
    End Sub
    Private Sub LimpiaControlesGrupos()
        txtDiasVac.Value = "0.00"
        txtMotivo.Text = ""

        txtFIniVac.Value = Date.Now()
        txtFechaRegVac.Value = Date.Now()
        txtFechaFalta.Value = Date.Now()
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If (txtBuscaEmpleado.Text.Trim <> "") Then
            If MessageBox.Show("¿Está seguro de cancelar lo capturado?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                '=====Limpiar controles
                gpbFalta.Visible = False
                gpbVac.Visible = False
                txtBuscaEmpleado.Text = ""
                txtDiasVac.Value = "0.00"
                txtMotivo.Text = ""
                cmbTipoMov.SelectedIndex = -1
            End If
        Else
            '=====Limpiar controles
            gpbFalta.Visible = False
            gpbVac.Visible = False
            txtBuscaEmpleado.Text = ""
            txtDiasVac.Value = "0.00"
            txtMotivo.Text = ""
            cmbTipoMov.SelectedIndex = -1
        End If
    End Sub

    Private Sub txtDiasVac_ValueChanged(sender As Object, e As EventArgs) Handles txtDiasVac.ValueChanged
        Dim _cantDias As Integer = 0, _fechaSalida As Date = Now()
        _cantDias = txtDiasVac.Value - 1
        _fechaSalida = txtFIniVac.Value
        _fechaSalida = _fechaSalida.Date.AddDays(_cantDias)
        txtFechaRegVac.Value = _fechaSalida
    End Sub

    Private Sub txtFIniVac_ValueChanged(sender As Object, e As EventArgs) Handles txtFIniVac.ValueChanged
        Dim _cantDias As Integer = 0, _fechaSalida As Date = Now()
        _cantDias = txtDiasVac.Value - 1
        _fechaSalida = txtFIniVac.Value
        _fechaSalida = _fechaSalida.Date.AddDays(_cantDias)
        txtFechaRegVac.Value = _fechaSalida
    End Sub



End Class