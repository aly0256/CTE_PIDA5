Public Class frmProgVacs

    Private Sub frmProgVacs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarInformacion()
    End Sub


    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub


    ''' <summary>
    ''' 'Método que cargará los registros de vacaciones programadas al dataGridView para mostrar la información
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MostrarInformacion()
        Dim query As String = "", dtLista As New DataTable

        Try
            query = "select '0' as 'INCLUIR', v.RELOJ, v.NOMBRE, v.FECHA, v.NOTAS from vacs_prog v where isnull(APLICADO,0)=0 order by reloj asc"
            dtLista = sqlExecute(query, "PERSONAL")

            If Not dtLista.Columns.Contains("Error") And dtLista.Rows.Count > 0 Then
                dgvProgVacs.DataSource = dtLista
            Else
                dgvProgVacs.DataSource = dtLista
                'dgvProgVacs.DataSource = Nothing
                'dgvProgVacs.Rows.Clear() ' Eliminar datos del dgv
                MessageBox.Show("No se encontraron empleados con vacaciones programadas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 'Método que permitirá capturar nuevos registros, como reloj, a partir de que fecha, y la cantidad de días a partir de la fecha mencionada
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        '===================
        Try
            '===== Abrir una ventanita para capturar no reloj, fecha y dias

            Dim Respuesta As Windows.Forms.DialogResult

            Respuesta = frmAddVacsProg.ShowDialog(Me)

            MostrarInformacion() ' Actualiza dgv

            If Respuesta = Windows.Forms.DialogResult.Abort Then
                MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf Respuesta = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' 'Método para borrar registro seleccionado
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            Dim Query As String = "", reloj As String = "", fecha As String = ""

            reloj = dgvProgVacs.Item("RELOJ", dgvProgVacs.CurrentRow.Index).Value.ToString.Trim
            fecha = FechaSQL(dgvProgVacs.Item("FECHA", dgvProgVacs.CurrentRow.Index).Value.ToString.Trim)

            If MessageBox.Show("¿Está seguro de elimnar el registro seleccionado?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Query = "delete from vacs_prog where reloj='" & reloj & "' and fecha='" & fecha & "' and isnull(APLICADO,0)=0"
                sqlExecute(Query, "PERSONAL")
                MostrarInformacion()
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' 'Método para seleccionar a los registros que van a aplicarse
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click



        Try
            Dim rj As String = "", fechaAplica As Date, dtRegistros As New DataTable
            Dim TotalRecSel As Integer = 0, aplicados As Integer = 0, no_aplicados As Integer = 0

            If MessageBox.Show("¿Desea aplicar las vacaciones seleccionadas?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                dtRegistros = sqlExecute("select * from vacs_prog where isnull(APLICADO,0)=0 order by reloj asc")
                If Not dtRegistros.Columns.Contains("Error") And dtRegistros.Rows.Count > 0 Then



                    Dim dtSeleccion As DataTable = dtRegistros.Clone

                    For Each dr As DataRow In dtRegistros.Rows
                        Dim reloj As String = "", fecha As String = "", cod_comp As String = ""
                        Try : reloj = dr("RELOJ").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                        Try : fecha = FechaSQL(dr("FECHA").ToString.Trim) : Catch ex As Exception : fecha = "" : End Try
                        Try : cod_comp = dr("COD_COMP").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try

                        For i As Integer = 0 To dgvProgVacs.RowCount - 1
                            Dim x0 As String = "", x1 As String = "", x3 As String = ""

                            Try : x0 = dgvProgVacs.Item(0, i).Value.ToString.Trim : Catch ex As Exception : x0 = "" : End Try ' valores 0 o 1 de aplicado
                            Try : x1 = dgvProgVacs.Item(1, i).Value.ToString.Trim : Catch ex As Exception : x1 = "" : End Try ' Reloj
                            Try : x3 = FechaSQL(dgvProgVacs.Item(3, i).Value.ToString.Trim) : Catch ex As Exception : x3 = "" : End Try ' Fecha

                            '=== Solo si aplica el movmiento
                            If x0 = "1" And x1 = reloj And x3 = fecha Then
                                dtSeleccion.ImportRow(dr)
                            End If

                        Next

                    Next

                    '====================Aplicar vacaciones solo de las seleccionadas
                    If dtSeleccion.Rows.Count > 0 Then

                        '===Seleccionar periodo para pago en Nómina
                        MessageBox.Show("Favor de seleccionar el periodo para pago en Nómina de las vacaciones seleccionadas a apliar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Dim Respuesta As Windows.Forms.DialogResult
                        Respuesta = frmSelAnoPeriodo.ShowDialog(Me)
                        Dim anoPerSeleccionado As String = ""
                        anoPerSeleccionado = frmSelAnoPeriodo.cmbPeriodos.SelectedValue
                        '===End selecciona periodo

                        TotalRecSel = dtSeleccion.Rows.Count

                        '---Mostrar Progress
                        Dim z As Integer = -1
                        frmTrabajando.Text = "Aplicando vacaciones"
                        frmTrabajando.Avance.IsRunning = True
                        frmTrabajando.lblAvance.Text = "Aplicando vacaciones"
                        ActivoTrabajando = True
                        frmTrabajando.Show()
                        Application.DoEvents()

                        '--Mostrar progress
                        frmTrabajando.Avance.IsRunning = False
                        frmTrabajando.lblAvance.Text = "Procesando datos"
                        Application.DoEvents()
                        frmTrabajando.Avance.Maximum = dtSeleccion.Rows.Count


                        For Each row As DataRow In dtSeleccion.Rows
                            Dim aplicaDiaVac As Boolean = True
                            Dim _reloj As String = "", _fechaAplica As String = "", cod_comp As String = ""
                            Try : _reloj = row("reloj").ToString.Trim : Catch ex As Exception : _reloj = "" : End Try

                            '----Mostrar Progress - avance
                            z += 1
                            frmTrabajando.Avance.Value = z
                            frmTrabajando.lblAvance.Text = _reloj
                            Application.DoEvents()

                            Try : _fechaAplica = FechaSQL(row("fecha")) : Catch ex As Exception : _fechaAplica = "" : End Try
                            Try : cod_comp = row("COD_COMP").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try

                            '=====Evaluar si es descanso o Festivo
                            If Festivo(Date.Parse(_fechaAplica), _reloj) Then
                                MessageBox.Show("El día " & _fechaAplica & "  no puede aplicar como vacación, ya que es festivo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                aplicaDiaVac = False
                                no_aplicados += 1
                                GoTo SigFecha
                            End If

                            If DiaDescanso(Date.Parse(_fechaAplica), _reloj) Then
                                MessageBox.Show("El día " & _fechaAplica & "  no puede aplicar como vacación, ya que está como día de descanso para el empleado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                aplicaDiaVac = False
                                no_aplicados += 1
                                GoTo SigFecha
                            End If

                            '===Evaluar si en la fecha no hay ya vacación aplicada
                            If HayVacAplicada(Date.Parse(_fechaAplica), _reloj) Then
                                MessageBox.Show("El día " & _fechaAplica & "  no puede aplicar como vacación, ya que hay vacación aplicada ya para este día", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                aplicaDiaVac = False
                                no_aplicados += 1
                                GoTo SigFecha
                            End If

                            If aplicaDiaVac Then
                                AplicaVacacion(_reloj, Date.Parse(_fechaAplica), cod_comp, anoPerSeleccionado)
                                aplicados += 1
                            End If


SigFecha:
                        Next

                        ActivoTrabajando = False
                        frmTrabajando.Close()
                        frmTrabajando.Dispose()

                        MessageBox.Show("---Registros seleccionados: " & TotalRecSel & vbCrLf & "---Aplicados: " & aplicados & vbCrLf & "---No aplicados: " & no_aplicados, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        MostrarInformacion() ' Actualizar Grid

                    Else

                        ActivoTrabajando = False
                        frmTrabajando.Close()
                        frmTrabajando.Dispose()

                        MessageBox.Show("No se encontraron registros por aplicar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                End If

            End If

            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()

        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' 'Método para aplicar las vacaciones a saldos_vacaciones, ausentismo y ajustes_nom
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AplicaVacacion(ByVal _rj As String, _fecha_aplica As Date, cod_comp As String, _AnioPerAplPagoNom As String)
        Try
            Dim _fecha_fin As Date, _fecha_ini As Date, InsertaVac As Boolean = False, dtTemp As New DataTable, AusVac As String = "", _aus_natural As String = "", _semana_captura As Boolean = False, _fecha As Date
            Dim x As Integer, _diasDinero As Double = 1.0, _diasTiempo As Double = 1.0, Respuesta As DialogResult, _dinero As Double = 0, _tiempo As Double = 0, _ano As String = "", _prima As Double = 0, ClaveVA As String = ""
            Dim _diasDineroConvertidos As Double = _diasDinero
            Dim _diasTiempoConvertidos As Double = _diasTiempo
            Dim tipo_per As String = ""


            _fecha_ini = _fecha_aplica
            ' _fecha_fin = DateAdd(DateInterval.Day, 1, _fecha_ini)
            _fecha_fin = _fecha_ini

            '----AO: 2023-11-28: Validar que en las fechas seleccionadas, no haya ya días capturados en saldos_vacaciones
            Dim dtVacExiste As New DataTable

            Do While _fecha_fin > _fecha_ini
                dtVacExiste = sqlExecute("select * from saldos_vacaciones where reloj='" & _rj & "' and FECHA_INI<='" & FechaSQL(_fecha_ini) & "' and FECHA_FIN>='" & FechaSQL(_fecha_ini) & "'", "PERSONAL")

                If dtVacExiste.Rows.Count > 0 Then
                    MessageBox.Show("Ya existe vacaciones capturados en la fecha:" & FechaSQL(_fecha_ini) & " , favor de agregar otro rango de fechas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    InsertaVac = False
                    Exit Sub
                End If
                '  _fecha_ini = DateAdd(DateInterval.Day, 1, _fecha_ini)
            Loop
            _fecha_ini = _fecha_aplica
            '-----End validar fechas seleccionadas

            '***** PROCESO PARA APLICAR VACACIONES EN AUSENTISMO *******
            dtTemp = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE tipo_naturaleza = 'V'", "TA")
            If dtTemp.Rows.Count = 0 Then
                AusVac = "VAC"
            Else
                AusVac = dtTemp.Rows(0).Item("tipo_aus")
            End If

            'Revisar ausentismo default y tipo de pago para vacaciones
            dtTemp = sqlExecute("SELECT ausentismo,pago_vacaciones_semana_captura FROM parametros")
            If dtTemp.Rows.Count = 0 Then
                _aus_natural = "AUS"
            Else
                _aus_natural = IIf(IsDBNull(dtTemp.Rows(0).Item("ausentismo")), "AUS", dtTemp.Rows(0).Item("ausentismo")).ToString.Trim
                _semana_captura = IIf(IsDBNull(dtTemp.Rows(0).Item("pago_vacaciones_semana_captura")), False, dtTemp.Rows(0).Item("pago_vacaciones_semana_captura"))
            End If

            _fecha = _fecha_ini


            Dim dtperiodo_ajustesnom As New DataTable
            dtperiodo_ajustesnom.Columns.Add("ano")
            dtperiodo_ajustesnom.Columns.Add("periodo")
            dtperiodo_ajustesnom.Columns.Add("dias")
            dtperiodo_ajustesnom.PrimaryKey = New DataColumn() {dtperiodo_ajustesnom.Columns("ano"), dtperiodo_ajustesnom.Columns("periodo")}


            x = 1
            Do Until x > _diasTiempo
                If Not (Festivo(_fecha, _rj) Or DiaDescanso(_fecha, _rj)) Then
                    dtTemp = sqlExecute("SELECT TIPO_NATURALEZA,ausentismo.TIPO_AUS,NOMBRE FROM AUSENTISMO LEFT JOIN TIPO_AUSENTISMO ON ausentismo.TIPO_AUS = tipo_ausentismo.TIPO_AUS WHERE RELOJ = '" & _rj & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                    If dtTemp.Rows.Count > 0 Then
                        If dtTemp.Rows(0).Item("tipo_aus") = _aus_natural Then
                            sqlExecute("DELETE FROM ausentismo  WHERE RELOJ = '" & _rj & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                            InsertaVac = True
                        Else
                            Respuesta = MessageBox.Show("Existe ausentismo registrado para el día " & FechaMediaLetra(_fecha) & " (" & dtTemp.Rows(0).Item("nombre") & "). ¿Desea sobrescribirlo?", "Ausentismo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
                            If Respuesta = Windows.Forms.DialogResult.Yes Then
                                sqlExecute("DELETE FROM ausentismo  WHERE RELOJ = '" & _rj & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                                InsertaVac = True
                            ElseIf Respuesta = Windows.Forms.DialogResult.No Then
                                InsertaVac = False
                            Else
                                Exit Sub
                            End If
                        End If
                    End If

                    '--HERE INSERTA EL AUS - AOS
                    If InsertaVac Then

                        '--- AO 2023-12-15: Agregar usuario y fecha hora de registro
                        sqlExecute("INSERT INTO ausentismo (COD_COMP,RELOJ,FECHA,TIPO_AUS,PERIODO,USUARIO,FECHA_HORA) VALUES ('" & _
                  cod_comp & "','" & _
                  _rj & "','" & _
                  FechaSQL(_fecha) & "','" & _
                  AusVac & "','" & _
                  ObtenerPeriodo(_fecha) & "','" & Usuario & "',getdate())", "TA")


                        _fecha_fin = _fecha
                        x = x + 1


                        Dim ano_pago As String = _fecha.Year
                        Dim periodo_pago As String = _fecha.Month.ToString.PadLeft(2, "0")

                        Dim dtFechaCorte As DataTable = sqlExecute("select * from periodos where ano = '" & ano_pago & "' and periodo = '" & periodo_pago & "' and fecha_fin <= '" & FechaSQL(Now.Date) & "' and isnull(periodo_especial, 0) = 0", "ta")
                        If dtFechaCorte.Rows.Count <= 0 Then
                            Dim dtSiguiente As DataTable = sqlExecute("select * from periodos where fecha_fin > '" & FechaSQL(Now.Date) & "' and isnull(periodo_especial, 0) = 0 order by ano, periodo", "ta")
                            If dtSiguiente.Rows.Count > 0 Then
                                ano_pago = dtSiguiente.Rows(0)("ano")
                                periodo_pago = dtSiguiente.Rows(0)("periodo")
                            Else
                                MessageBox.Show("Es necesario dar de alta los periodos de pago faltantes, si recibe este mensaje por favor contacte a PIDA", "Faltan periodos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If

                        Dim drPeriodoPago As DataRow = dtperiodo_ajustesnom.Rows.Find({ano_pago, periodo_pago})
                        If drPeriodoPago Is Nothing Then
                            drPeriodoPago = dtperiodo_ajustesnom.NewRow
                            drPeriodoPago("ano") = ano_pago
                            drPeriodoPago("periodo") = periodo_pago
                            drPeriodoPago("dias") = 0
                            dtperiodo_ajustesnom.Rows.Add(drPeriodoPago)
                        End If

                        Dim dias_ As Integer = drPeriodoPago("dias")
                        drPeriodoPago("dias") = dias_ + 1

                    End If

                End If
                ' _fecha = _fecha.AddDays(1)
                InsertaVac = True
            Loop

            '**** VACACIONES PARA SALDOS Y PAGOS *****
            dtTemp = sqlExecute("SELECT TOP 1 ano,prima,saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & _rj & _
             "' ORDER BY fecha_captura DESC,fecha_fin DESC")
            If dtTemp.Rows.Count > 0 Then
                Try : _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero") : Catch ex As Exception : _dinero = 0 : End Try
                Try : _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo") : Catch ex As Exception : _tiempo = 0 : End Try
                Try : _ano = dtTemp.Rows.Item(0).Item("ano") : Catch ex As Exception : _ano = Date.Now.Year.ToString : End Try
                Try : _prima = dtTemp.Rows.Item(0).Item("prima") : Catch ex As Exception : _prima = 25 : End Try
            End If

            dtTemp = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = 'DIASVA'", "Nomina")
            If dtTemp.Rows.Count > 0 Then
                ClaveVA = dtTemp.Rows.Item(0).Item("misce_clave")
            Else
                ClaveVA = ""
            End If

            _dinero = _dinero - _diasDineroConvertidos
            _tiempo = _tiempo - _diasTiempoConvertidos

            '--- AO 2023-12: Registrar el usuairo que las está ingresando
            Dim comentario As String = "VACACIONES"
            sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                       "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                       _rj & "','" & _
                       _fecha.Year & "'," & _
                       _prima & "," & _
                       _dinero & "," & _
                       _tiempo & "," & _
                       _diasDineroConvertidos & "," & _
                       _diasTiempoConvertidos & _
                       ",'" & comentario & "','" & _
                       FechaSQL(_fecha_ini) & "','" & _
                       FechaSQL(_fecha_fin) & "','" & _
                       FechaHoraSQL(Now) & "')")

            '---AO 2023-12: Registrar en bitacora_vacaciones para tener mayor detalle:
            Dim Q As String = ""
            Q = "insert into bitacora_vacaciones (RELOJ,FECHA_INI,FECHA_FIN,COMENTARIO,USUARIO,FECHA_CAPTURA) VALUES" & _
                "('" & _rj & "','" & FechaSQL(_fecha_ini) & "','" & FechaSQL(_fecha_fin) & "','AGREGADO DESDE PANTALA PLANEACION_VACS','" & Usuario & "',GETDATE())"
            sqlExecute(Q, "PERSONAL")

            '**** PROCESO PARA APLICAR VACACIONES EN MISCELANEOS DE NOMINA ******* 
            '--- AOS: Proceso nuevo que evalua dia a dia e inserta de acuerdo a las fechas ini y fin en ajustes_nom (Miscelaneos), ya que puede abarcar uno o mas periodos
            Dim diasPag As Double = 0.0
            Try : diasPag = _diasDinero : Catch ex As Exception : diasPag = 0.0 : End Try

            '==Periodo del empleado     junio2021       Ernesto
            tipo_per = "S"
            'seleccionado = ObtenerPeriodo(_fecha)
            seleccionado = _AnioPerAplPagoNom ' De acuerdo al anio y periodo que seleccionaron
            ProcInsDiasVaAjNom(_rj, diasPag, _fecha_ini, _fecha_fin, tipo_per, seleccionado, "DIAS CAPTURADOS DESDE PLANEACION DE VACACIONES")

            '================Si se aplicó la vacación, actualizar
            If InsertaVac Then
                sqlExecute("update vacs_prog set APLICADO=1,FECHA_APLICACION=getdate() where reloj='" & _rj & "' and fecha='" & _fecha & "'")
            End If



        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Public Function HayVacAplicada(Fecha As Date, Optional Reloj As String = "") As Boolean
        Dim _hayVacAplicada As Boolean = False, dtExisteVac As New DataTable
        Try
            Dim Q As String = "select * from saldos_vacaciones  where reloj='" & Reloj & "' and COMENTARIO ='VACACIONES' and FECHA_INI<='" & Fecha & "' and FECHA_FIN>='" & Fecha & "'"

            dtExisteVac = sqlExecute(Q, "PERSONAL")
            If Not dtExisteVac.Columns.Contains("Error") And dtExisteVac.Rows.Count > 0 Then
                _hayVacAplicada = True
            End If

            Return _hayVacAplicada
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return _hayVacAplicada
        End Try
    End Function

End Class