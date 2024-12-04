Public Class frmMultiformaAplicacion
    Dim dtMovimientos As DataTable
    Dim Resumen As String
    Dim FiltroMultiforma As String
    Private Sub frmAplicacionFM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MostrarInformacion()
    End Sub
    Private Sub MostrarInformacion()

        If FiltroXUsuario.Contains("COD_COMP") Or FiltroXUsuario.Contains("cod_comp") Then
            FiltroMultiforma = " where " & FiltroXUsuario & " and tipo_movimiento <> 'SALARIO'"
        Else
            FiltroMultiforma = " WHERE tipo_movimiento <> 'SALARIO'"
        End If
        Dim q As String = "" & _
            "Select " & _
            "formato_multiple.impreso,formato_multiple.cod_comp, formato_multiple.RELOJ," & _
            "personalvw.nombres as 'nombre',formato_multiple.usuario," & _
            "formato_multiple.tipo_movimiento, formato_multiple.comentario," & _
            "CASE TIPO_MOVIMIENTO " & _
            "WHEN 'BAJA' THEN ('Motivo de baja: '+ cast(formato_multiple.COD_MOT_BA as VARCHAR) + ' Fecha baja: '+ cast (formato_multiple.FECHA_BAJA as VARCHAR))  " & _
            "WHEN 'AUSENTISMO' THEN ('Tipo de ausentismo: '+ cast(formato_multiple.TIPO_AUS as VARCHAR) + ' Fecha de inicio: '+ cast (formato_multiple.FECHA_INICIO as VARCHAR)+ ' Duracion: '+ cast (formato_multiple.CANTIDAD_DIAS as VARCHAR) + ' días') " & _
            "WHEN 'POSICION' THEN ('Campo: '+ cast(formato_multiple.CAMPO as VARCHAR) + ' Actual: '+ cast (formato_multiple.VALOR_ACTUAL as VARCHAR)+ ' Nuevo: '+ cast (formato_multiple.VALOR_NUEVO as VARCHAR) + ' Fecha efectiva: '+ cast (formato_multiple.FECHA_EFECTIVA as VARCHAR)) " & _
            "WHEN 'TURNO' THEN ('Campo: '+ cast(formato_multiple.CAMPO as VARCHAR) + ' Actual: '+ cast (formato_multiple.VALOR_ACTUAL as VARCHAR)+ ' Nuevo: '+ cast (formato_multiple.VALOR_NUEVO as VARCHAR) + ' Fecha efectiva: '+ cast (formato_multiple.FECHA_EFECTIVA as VARCHAR)) " & _
            "END AS DETALLE " & _
            "from (select * from formato_multiple" & FiltroMultiforma & " )formato_multiple " & _
            "left join PersonalVW " & _
            "on formato_multiple.reloj = PersonalVW.RELOJ " & _
            "where formato_multiple.confirmado = '0'"

        dgMovimientos.AutoGenerateColumns = False
        dtMovimientos = sqlExecute(q)


        If dtMovimientos.Rows.Count > 0 Then
            Compania = dtMovimientos.Rows(0).Item("cod_comp")
        End If
        ' dgMovimientos.DataSource = dtMovimientos
        dgMovimientos.DataSource = dtMovimientos
    End Sub

    Private Sub btnMostrarInformacion_Click(sender As Object, e As EventArgs) Handles btnMostrarInformacion.Click
        MostrarInformacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub



    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        frmBuscar.ShowDialog(Me)
        If Reloj <> "CANCEL" Then
            Dim Nuevo As New frmMultiformaCaptura("Agregar")
            Nuevo.ShowDialog()
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If dtMovimientos.Rows.Count > 0 Then

            Dim _movimiento As String = dgMovimientos.SelectedCells.Item(3).Value.ToString().Trim
            Dim _reloj As String = dgMovimientos.SelectedCells.Item(1).Value.ToString().Trim
            Dim _compa As String = Compania
            Dim _usuario As String = dgMovimientos.SelectedCells.Item(4).Value.ToString().Trim
            Dim _comentario As String = dgMovimientos.SelectedCells.Item(6).Value.ToString().Trim
            Dim _detalle As String = dgMovimientos.SelectedCells.Item(5).Value.ToString().Trim
            Dim _campo As String = "None"

            If MessageBox.Show("Estás seguro que deseas borrar este registro? (reloj:" + _reloj + ",Mov:" + _movimiento + ")", "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If _movimiento.Equals("BAJA") Then
                    sqlExecute("delete formato_multiple where cod_comp ='" + _compa + "' and reloj ='" + _reloj + "' and usuario='" + _usuario + "' and comentario ='" + _comentario + "' and tipo_movimiento ='" + _movimiento + "' and confirmado ='0'")
                ElseIf _movimiento.Equals("AUSENTISMO") Then
                    sqlExecute("delete formato_multiple where cod_comp ='" + _compa + "' and reloj ='" + _reloj + "' and usuario='" + _usuario + "' and comentario ='" + _comentario + "' and tipo_movimiento ='" + _movimiento + "' and confirmado ='0'")
                ElseIf _movimiento.Equals("POSICION") Or _movimiento.Equals("TURNO") Then
                    If _detalle.Contains("COD_DEPTO") Then
                        _campo = "COD_DEPTO"
                    ElseIf _detalle.Contains("COD_HORA") Then
                        _campo = "COD_HORA"
                    ElseIf _detalle.Contains("COD_TURNO") Then
                        _campo = "COD_TURNO"
                    ElseIf _detalle.Contains("COD_SUPER") Then
                        _campo = "COD_SUPER"
                    ElseIf _detalle.Contains("COD_AREA") Then
                        _campo = "COD_AREA"
                    ElseIf _detalle.Contains("COD_PUESTO") Then
                        _campo = "COD_PUESTO"
                    End If
                    sqlExecute("delete formato_multiple where cod_comp ='" + _compa + "' and reloj ='" + _reloj + "' and usuario='" + _usuario + "' and comentario ='" + _comentario + "' and tipo_movimiento ='" + _movimiento + "' and campo ='" + _campo + "' and confirmado ='0'")
                End If
            End If
        End If

        MostrarInformacion()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dtMovimientos.Rows.Count > 0 Then
            Reloj = dgMovimientos.SelectedCells.Item(1).Value.ToString()
            Dim _movimiento As String = dgMovimientos.SelectedCells.Item(3).Value.ToString().Trim
            Dim Nuevo As New frmMultiformaCaptura("Editar", _movimiento)
            Nuevo.ShowDialog()
        End If
        MostrarInformacion()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtinfo As DataTable = sqlExecute("select  * from formato_multiple where confirmado = '0'")
        If dtinfo.Rows.Count > 0 Then
            dtinfo = sqlExecute("select distinct formato_multiple.reloj,'mixto' as tipo_reporte from formato_multiple left join personalvw on formato_multiple.reloj = personalvw.reloj where formato_multiple.confirmado= '0'")
            frmVistaPrevia.LlamarReporte("Formato Multiple", dtinfo)
            frmVistaPrevia.ShowDialog()
            sqlExecute("update formato_multiple set impreso='1' where impreso = '0' and confirmado = '0'")
        Else
            MessageBox.Show("No hay información disponible para generar el reporte solicitado", "No hay información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        MostrarInformacion()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click

        Try
            Resumen = ""
            Dim _consulta As String = ""
            Dim _reloj As String = dgMovimientos.SelectedCells.Item(1).Value.ToString().Trim
            Dim _movimiento As String = dgMovimientos.SelectedCells.Item(3).Value.ToString().Trim
            Dim _usuario As String = dgMovimientos.SelectedCells.Item(4).Value.ToString().Trim
            Dim _detalle As String = dgMovimientos.SelectedCells.Item(5).Value.ToString().Trim
            Dim _comentario As String = dgMovimientos.SelectedCells.Item(6).Value.ToString().Trim
            Dim _compa As String = Compania
            Dim _campo As String = "None"
            'For Each r As DataGridViewRow In dgMovimientos.Rows
            '    If r.Cells.Item(0).Value = Nothing Then
            '        Debug.Print("null")
            '    ElseIf r.Cells.Item(0).Value.ToString.Equals("0") Then
            '        Debug.Print("0")
            '    ElseIf r.Cells.Item(0).Value.ToString.Equals("1") Then
            '        Debug.Print("1")
            '    End If

            'Next
            pbAplicar.Maximum = dgMovimientos.Rows.Count
            pbAplicar.Minimum = 1
            pbAplicar.Visible = True
            pbAplicar.Value = 1
            For Each r As DataGridViewRow In dgMovimientos.Rows
                If Not r.Cells.Item(0).Value = Nothing Then
                    If r.Cells.Item(0).Value.ToString.Equals("1") Then

                        _reloj = r.Cells.Item(1).Value
                        _movimiento = r.Cells.Item(3).Value
                        _usuario = r.Cells.Item(4).Value
                        _detalle = r.Cells.Item(5).Value
                        _comentario = r.Cells.Item(6).Value
                        If _movimiento.Equals("BAJA") Then
                            _consulta = "select * from  formato_multiple where cod_comp ='" + _compa + "' and reloj ='" + _reloj + "' and usuario='" + _usuario + "' and comentario ='" + _comentario + "' and tipo_movimiento ='" + _movimiento + "' and confirmado ='0'"
                        ElseIf _movimiento.Equals("AUSENTISMO") Then
                            _consulta = "select * from formato_multiple where cod_comp ='" + _compa + "' and reloj ='" + _reloj + "' and usuario='" + _usuario + "' and comentario ='" + _comentario + "' and tipo_movimiento ='" + _movimiento + "' and confirmado ='0'"
                        ElseIf _movimiento.Equals("POSICION") Or _movimiento.Equals("TURNO") Then
                            If _detalle.Contains("COD_DEPTO") Then
                                _campo = "COD_DEPTO"
                            ElseIf _detalle.Contains("COD_HORA") Then
                                _campo = "COD_HORA"
                            ElseIf _detalle.Contains("COD_TURNO") Then
                                _campo = "COD_TURNO"
                            ElseIf _detalle.Contains("COD_SUPER") Then
                                _campo = "COD_SUPER"
                            ElseIf _detalle.Contains("COD_AREA") Then
                                _campo = "COD_AREA"
                            ElseIf _detalle.Contains("COD_PUESTO") Then
                                _campo = "COD_PUESTO"
                            End If
                            _consulta = "select * from  formato_multiple where cod_comp ='" + _compa + "' and reloj ='" + _reloj + "' and usuario='" + _usuario + "' and comentario ='" + _comentario + "' and tipo_movimiento ='" + _movimiento + "' and campo ='" + _campo + "' and confirmado ='0'"
                        End If
                        AplicarCambios(sqlExecute(_consulta))

                    End If
                End If
                pbAplicar.Value = pbAplicar.Value + 1

            Next
            pbAplicar.Visible = False
            MessageBox.Show(Resumen, "Resumen de movimientos ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MostrarInformacion()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub AplicarCambios(dtCambios As DataTable)

        Dim _movimiento As String = ""
        Dim _valor_anterior As String = ""
        Dim _valor_nuevo As String = ""
        Dim _campo As String = ""
        Dim _usuario As String = ""
        Dim _fecha As String = ""
        Dim _fecha_captura As String = ""
        Dim _compa As String = ""
        Dim _reloj As String = ""
        Dim _comentario As String = ""
        Dim wh As String = ""
        Dim _consulta As String = ""
        Dim _cod_mot_ba As String = ""
        Dim _cod_mot_im As String = ""
        Dim _dias As Integer = 0
        Dim _tipo_aus As String = ""
        Dim _dtTemp As New DataTable
        Dim _naturaleza As String = ""
        Dim _periodo_prueba As Boolean

        For Each r As DataRow In dtCambios.Rows
            Application.DoEvents()

            _movimiento = r.Item("tipo_movimiento")
            _usuario = r.Item("usuario")
            _fecha_captura = FechaSQL(r.Item("fecha_captura"))
            _compa = r.Item("cod_comp")
            _reloj = r.Item("reloj")
            _comentario = r.Item("comentario")
            _periodo_prueba = r.Item("periodo_prueba")

            wh = " and tipo_movimiento='" + _movimiento + "' and usuario='" + _usuario + "' and fecha_captura='" + _fecha_captura + "' and cod_comp='" + _compa + "' and  reloj='" + _reloj + "' and comentario='" + _comentario + "'"
            If _movimiento.Equals("BAJA") Then
                _fecha = FechaSQL(r.Item("fecha_baja"))
                _campo = "baja"
                _cod_mot_ba = r.Item("cod_mot_ba")
                _cod_mot_im = r.Item("cod_mot")
                If Date.Parse(_fecha) < Date.Now Then
                    'para dar de alta en la bitacora y en personal
                    'La baja y fecha
                    sqlExecute("update formato_multiple set confirmado = '1' where confirmado = '0'" + wh)
                    _consulta = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                    _consulta = _consulta & _reloj & "','" + _campo + "','','" & _fecha & "','" & Usuario & "',GETDATE(),'B')"
                    sqlExecute(_consulta)
                    ModPersonal(_campo, _fecha, _reloj)
                    'El motivo interno cod_mot_ba
                    _campo = "cod_mot_ba"
                    _consulta = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                    _consulta = _consulta & _reloj & "','" + _campo + "','','" & _cod_mot_ba & "','" & Usuario & "',GETDATE(),'B')"
                    sqlExecute(_consulta)
                    ModPersonal(_campo, _cod_mot_ba, _reloj)
                    'El motivo del imss cod_mot
                    _campo = "cod_mot_im"
                    _consulta = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                    _consulta = _consulta & _reloj & "','" + _campo + "','','" & _cod_mot_im & "','" & Usuario & "',GETDATE(),'B')"
                    sqlExecute(_consulta)
                    ModPersonal(_campo, _cod_mot_im, _reloj)

                    Resumen = Resumen & "Se aplicó " & _movimiento & " al reloj " & _reloj & vbCrLf
                Else
                    'si la fecha es mayor ala fecha de aplicacion
                    Resumen = Resumen & "No se aplicó " & _movimiento & " al reloj " & _reloj & " (fecha efectiva superior al día de hoy)" & vbCrLf
                End If
            ElseIf _movimiento.Equals("AUSENTISMO") Then
                Dim f1 As Date = r.Item("fecha_inicio")
                Dim f2 As Date = f1
                Dim x As Integer = 0
                _fecha = FechaSQL(r.Item("fecha_inicio"))
                _dias = r.Item("cantidad_dias")
                _tipo_aus = r.Item("tipo_aus")
                Do While x < _dias
                    f2 = DateAdd(DateInterval.Day, 1, f2)
                    If Not DiaDescanso(f2, _reloj) Or Festivo(f2, _reloj) Then
                        x = x + 1
                        _consulta = "insert into ausentismo(cod_comp,reloj,fecha,tipo_aus) "
                        _consulta = _consulta + "values('" + _compa + "','" + _reloj + "','" + FechaSQL(f1) + "','" + _tipo_aus + "')"
                        sqlExecute(_consulta, "TA")
                    End If
                Loop
                sqlExecute("update formato_multiple set confirmado = '1' where confirmado = '0'" + wh)
                Resumen = Resumen & "Se aplicó " & _movimiento & " con clave " & _tipo_aus & " al reloj " & _reloj & vbCrLf
            ElseIf _movimiento.Equals("POSICION") Or _movimiento.Equals("TURNO") Then
                _fecha = FechaSQL(r.Item("fecha_efectiva"))
                If Date.Parse(_fecha) < Date.Now Then
                    _campo = r.Item("campo")
                    _valor_anterior = r.Item("valor_actual")
                    _valor_nuevo = r.Item("valor_nuevo")
                    sqlExecute("update formato_multiple set confirmado = '1' where confirmado = '0' and campo='" + _campo + "'" + wh)
                    _consulta = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                    _consulta = _consulta & _reloj & "','" + _campo + "','" + _valor_anterior + "','" & _valor_nuevo & "','" & Usuario & "',GETDATE(),'C')"
                    sqlExecute(_consulta)
                    ModPersonal(_campo, _valor_nuevo, _reloj)
                    Resumen = Resumen & "Se aplicó " & _movimiento & " al reloj " & _reloj & vbCrLf

                    'Cambios de posicion con periodo de prueba en BRP - ABRAHAM
                    If _campo.ToLower = "cod_puesto" And _periodo_prueba Then
                        Dim dtPersonal As DataTable = sqlExecute("select * from personal where reloj = '" & _reloj & "'")
                        If dtPersonal.Rows.Count > 0 Then
                            Dim drPersonal As DataRow = dtPersonal.Rows(0)
                            sqlExecute("insert into mod_sal " & _
                                       "(cod_comp, reloj, cod_tipo_mod, cambio_de, cambio_a, provar, fact_int, fecha, notas, nivel, integrado, hoy, aplicado, fecha_aplicacion, usuario_aplicacion) " & _
                                       "values " & _
                                       " ('" & drPersonal("cod_comp") & "', '" & _reloj & "', '" & "IPP" & "', '" & drPersonal("sactual") & "', '" & drPersonal("sactual") & "', '" & drPersonal("pro_var") & "', '" & drPersonal("factor_int") & "', '" & FechaSQL(Now) & "', 'CAMBIO DE PUESTO APLICADO DESDE MULTIFORMA " & _valor_nuevo & "', '" & drPersonal("nivel") & "', '" & drPersonal("integrado") & "', '" & FechaSQL(Now) & "', '1', '" & FechaSQL(Now) & "', '" & Usuario & "')")
                        End If
                    End If

                Else
                    ' si la fecha efectiva es mayor a la fecha de aplicacion

                    Resumen = Resumen & "No se aplicó " & _movimiento & " al reloj " & _reloj & " (fecha efectiva superior al día de hoy)" & vbCrLf
                End If

            End If

        Next


    End Sub
    Private Sub ModPersonal(campo As String, valor As String, reloj As String)
        sqlExecute("UPDATE personal SET " & campo & " = '" & valor & "' WHERE reloj = '" & reloj & "'")

    End Sub

End Class