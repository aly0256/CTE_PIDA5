Public Class frmModSalTemp
    Dim dtLista As New DataTable

    Private Sub frmModSalTemp_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyValue = Keys.F5 Then
            MostrarInformacion()
        End If
    End Sub

    Private Sub frmModSalTemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarInformacion()
    End Sub

    Private Sub EmpNav_Enter(sender As Object, e As EventArgs) Handles EmpNav.Enter

    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim x As Integer
        Try
            Dim frm As New frmModSalEdicion
            frm.ShowDialog()
            MostrarInformacion()

            x = dgModSal.Rows.Count - 1
            If x >= 0 Then
                dgModSal.CurrentCell.Selected = False
                dgModSal.Rows(x).Selected = True
                dgModSal.FirstDisplayedScrollingRowIndex = x
                'dgModSal.Rows(1).Selected = True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub MostrarInformacion()
        Dim cadena As String
        Try
            ' cadena = "SELECT ID,'0' AS INCLUIR, mod_sal.cod_comp as 'COMP.',mod_sal.reloj as 'RELOJ',personalvw.nombres AS 'NOMBRE',mod_sal.cod_tipo_mod 'TIPO MOD.',"
            cadena = "SELECT '0' AS INCLUIR, mod_sal.cod_comp as 'COMP.',mod_sal.reloj as 'RELOJ',personalvw.nombres AS 'NOMBRE',mod_sal.cod_tipo_mod 'TIPO MOD.',"
            cadena = cadena & "cambio_de AS 'CAMBIO DE',mod_sal.nivel as 'NIVEL',cambio_a AS 'CAMBIO A',"
            cadena = cadena & "provar AS 'PROM.VAR.',mod_sal.fact_int AS 'FACT.INT.',mod_sal.integrado as 'INTEGRADO'"
            cadena = cadena & ",mod_sal.fecha as 'FECHA',mod_sal.notas as 'NOTAS' "
            cadena = cadena & " FROM mod_sal LEFT JOIN personalvw ON personalvw.reloj = mod_sal.reloj WHERE aplicado IS NULL OR aplicado = 0 ORDER BY fecha,reloj"
            dtLista = New DataTable
            dtLista = sqlExecute(cadena)
            dgModSal.DataSource = dtLista
            '  dgModSal.Columns("ID").Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgModSal_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgModSal.CellContentDoubleClick
        btnEditar.PerformClick()
    End Sub

    Private Sub dgModSal_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgModSal.UserDeletingRow
        Try
            Dim i As Integer = e.Row.Index
            Dim ID As Integer
            Dim Reloj As String
            Dim Sueldo As String
            ID = dgModSal.Item("ID", i).Value

            Sueldo = FormatCurrency(dgModSal.Item("CAMBIO_A", i).Value)
            Reloj = dgModSal.Item("RELOJ", i).Value.ToString

            If MessageBox.Show("¿Está seguro de borrar el cambio de sueldo al empleado '" & Reloj & "' por la cantidad de " & Sueldo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                dtTemporal = sqlExecute("DELETE FROM mod_sal WHERE id = " & ID)
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim i As Integer
        Dim ID As Integer
        Dim Reloj As String
        Dim Sueldo As String
        Try
            i = dgModSal.CurrentCell.RowIndex
            '  ID = IIf(IsDBNull(dgModSal.Item("ID", i).Value), 0, dgModSal.Item("ID", i).Value)
            ID = IIf(IsDBNull(dgModSal.Item("reloj", i).Value), "", dgModSal.Item("reloj", i).Value)

            Sueldo = FormatCurrency(dgModSal.Item("CAMBIO_A", i).Value)
            Reloj = dgModSal.Item("RELOJ", i).Value.ToString

            If MessageBox.Show("¿Está seguro de borrar el cambio de sueldo al empleado '" & Reloj & "' por la cantidad de " & Sueldo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                '  dtTemporal = sqlExecute("DELETE FROM mod_sal WHERE id = " & ID)
                dtTemporal = sqlExecute("DELETE FROM mod_sal WHERE reloj = " & ID)
                sqlExecute("delete formato_multiple where comentario = '" & ID & "'")
                dgModSal.Rows.RemoveAt(i)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim i As Integer
        Dim ID As Integer

        Try


            i = dgModSal.CurrentCell.RowIndex
            ID = IIf(IsDBNull(dgModSal.Item("ID", i).Value), 0, dgModSal.Item("ID", i).Value)

            If frmModSalEdicion.MostrarInformacionEDICION(ID) Then
                frmModSalEdicion.ShowDialog()
                MostrarInformacion()

                dgModSal.CurrentCell.Selected = False
                dgModSal.Rows(i).Selected = True
                dgModSal.FirstDisplayedScrollingRowIndex = i

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Dim x As Integer
        Dim u As Integer = 0
        Dim t As Integer = 0
        Dim Reloj As String
        Dim SAnterior As Decimal
        Dim SNuevo As Decimal
        Dim FhaUltMod As Date
        Dim Nivel As String
        Dim FactInt As Decimal
        Dim ProVar As Decimal
        Dim ID As Integer
        Dim Respuesta As System.Windows.Forms.DialogResult
        Dim dtSeleccion As DataTable
        Try

            Respuesta = MessageBox.Show("Se aplicarán los cambios al archivo maestro, ¿Desea emitir el reporte de cambios pendientes antes de continuar? " & vbCrLf & "Una vez aplicados los cambios, el reporte no se podrá emitir.", "Aplicar cambios de sueldo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If Respuesta = vbCancel Then
                Exit Sub
            ElseIf Respuesta = vbYes Then
                Dim Q As String = "SELECT mod_sal.*, personalvw.NOMBRES FROM personal.dbo.mod_sal LEFT JOIN personal.dbo.personalvw ON mod_sal.reloj = personalvw.reloj WHERE aplicado IS NULL or aplicado = 0"
                Dim dtModSalPendientes As DataTable = sqlExecute(Q, "PERSONAL")
                dtSeleccion = dtModSalPendientes.Clone
                For Each row As DataRow In dtModSalPendientes.Rows
                    For i As Integer = 0 To dgModSal.RowCount - 1
                        Dim x0 As String = "", x1 As String = "", x2 As String = "", _reloj_ As String = "", x7 As String = "", cambio_a As String = ""

                        Try : _reloj_ = row.Item("reloj").ToString.Trim : Catch ex As Exception : _reloj_ = "" : End Try
                        Try : cambio_a = row.Item("CAMBIO_A").ToString.Trim : Catch ex As Exception : cambio_a = "" : End Try

                        Try : x0 = dgModSal.Item(0, i).Value.ToString.Trim : Catch ex As Exception : x0 = "" : End Try ' valores 0 o 1 de aplicado
                        Try : x1 = dgModSal.Item(1, i).Value.ToString.Trim : Catch ex As Exception : x1 = "" : End Try ' Cod Comp
                        Try : x2 = dgModSal.Item(2, i).Value.ToString.Trim : Catch ex As Exception : x2 = "" : End Try ' Reloj empleado
                        Try : x7 = dgModSal.Item(7, i).Value.ToString.Trim : Catch ex As Exception : x7 = "" : End Try ' CAMBIO_A

                        If x2.Equals(_reloj_) And x0.Equals("1") And x7.Equals(cambio_a) Then
                            dtSeleccion.ImportRow(row)
                        End If
                    Next
                Next
                frmVistaPrevia.LlamarReporte("Cambios de sueldo pendientes", dtSeleccion)
                frmVistaPrevia.ShowDialog()
            End If

            pbAplicar.Visible = True
            pbAplicar.Maximum = dtLista.Rows.Count - 1
            Me.Cursor = Cursors.WaitCursor
            u = 0
            '*************************REALIZAR CAMBIOS EN BASE A REGISTROS SELECCIONADOS EN EL GRID**********************************
            dtSeleccion = dtLista.Clone
            For Each row As DataRow In dtLista.Rows
                For i As Integer = 0 To dgModSal.RowCount - 1  ' HERE AOS
                    ' If dgModSal.Item(0, i).Value.ToString.Equals(row.Item("ID").ToString) And dgModSal.Item(1, i).Value.ToString.Equals("1") Then
                    If dgModSal.Item(0, i).Value.ToString.Equals("1") And dgModSal.Item(2, i).Value.ToString.Equals(row.Item("reloj").ToString) Then
                        dtSeleccion.ImportRow(row)
                    End If
                Next
            Next

            For Each dRow As DataRow In dtSeleccion.Rows
                'MCR 19/NOV/2015
                'Verificar antes de aplicar, que el empleado no pertenezca a una compañía no editable
                dtTemporal = sqlExecute("select * from cias where cod_comp in (select cod_comp from personal where reloj = '" & dRow("reloj") & "') and  isnull(editable, 1) = 1  ")
                If dtTemporal.Rows.Count = 0 Then
                    t += 1
                    Continue For
                End If
                '******************************

                pbAplicar.Value = x
                pbAplicar.Text = "Aplicando cambio de sueldo al empleado " & dRow("reloj")
                If dRow("cambio de") <> dRow("cambio a") Then
                    '   ID = dRow("ID")
                    Reloj = dRow("reloj")
                    SAnterior = dRow("cambio de")
                    SNuevo = dRow("cambio a")
                    FhaUltMod = dRow("fecha")
                    Nivel = IIf(IsDBNull(dRow("nivel")), "", dRow("nivel"))
                    dtTemporal = sqlExecute("SELECT factor_int,pro_var,cod_comp,cod_tipo,alta from personalvw WHERE reloj = '" & Reloj & "'")
                    If dtTemporal.Rows.Count > 0 Then
                        'MCR 6-OCT-2015
                        'Recalcula factor de integración, por si hubo cambio en la situación del empleado
                        FactInt = FactorIntegracion(dtTemporal.Rows(0)("cod_comp"), dtTemporal.Rows(0)("cod_tipo"), Antiguedad(dtTemporal.Rows(0)("alta"), Now))
                        If FactInt < IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("factor_int")), 0, dtTemporal.Rows.Item(0).Item("factor_int")) Then
                            'MCR 6-OCT-2015
                            'Si el factor calculado es menor que el que ya tiene el empleado, mantener el de personal
                            FactInt = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("factor_int")), 0, dtTemporal.Rows.Item(0).Item("factor_int"))
                        End If
                        ProVar = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("pro_var")), 0, dtTemporal.Rows.Item(0).Item("pro_var"))
                    Else
                        FactInt = 0
                        ProVar = 0
                    End If
                    EditaSueldos(Reloj, "sal_ant", SAnterior)
                    EditaSueldos(Reloj, "sactual", SNuevo)
                    EditaSueldos(Reloj, "nivel", Nivel)
                    EditaSueldos(Reloj, "integrado", (SNuevo * FactInt) + ProVar)
                    EditaSueldos(Reloj, "fha_ult_mo", FhaUltMod)
                    '   Dim query As String = "UPDATE mod_sal SET aplicado = 1, fecha_aplicacion = GETDATE(), usuario_aplicacion = '" & Usuario & "' WHERE ID=" & ID
                    Dim query As String = "UPDATE mod_sal SET aplicado = 1, fecha_aplicacion = GETDATE(), usuario_aplicacion = '" & Usuario & "' WHERE reloj=" & Reloj
                    dtTemporal = sqlExecute(query)
                    '  sqlExecute("update formato_multiple set confirmado =1 where comentario ='" & ID & "'")
                    sqlExecute("update formato_multiple set confirmado =1 where comentario ='" & Reloj & "'")
                Else
                    u = u + 1
                End If
            Next

            If t > 0 Then
                'MCR 19/NOV/2015
                'Avisar que hubo empleados de empresa no editable
                MessageBox.Show("Algunos cambios no pudieron aplicarse porque la compañía a la que pertenece el empleado(s) no es editable.", "Cambios no aplicados", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf u > 0 Then
                MessageBox.Show("Algunos cambios no pudieron aplicarse porque el sueldo anterior es mayor o igual al nuevo. Favor de verificar.", "Cambios no aplicados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Los cambios fueron aplicados exitosamente.", "Aplicar cambios de sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
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
                    Cadena = Cadena & Reloj & "','" & Campo & "','" & ValAntSTR & "','" & FechaSQL(Valor) & "','" & Usuario & "',GETDATE(),'" & TipoMovimiento & "')"
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
        frmModSalMasivos.ShowDialog()
        MostrarInformacion()
    End Sub

    Private Sub btnMostrarInformacion_Click(sender As Object, e As EventArgs) Handles btnMostrarInformacion.Click
        MostrarInformacion()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtModSalPendientes As DataTable = sqlExecute("SELECT mod_sal.*, personalvw.NOMBRES FROM personal.dbo.mod_sal LEFT JOIN personal.dbo.personalvw ON mod_sal.reloj = personalvw.reloj WHERE aplicado IS NULL or aplicado = 0")
        frmVistaPrevia.LlamarReporte("Cambios de sueldo pendientes", dtModSalPendientes)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub frmModSalTemp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            NFiltros = 0
            Me.Dispose()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnMultiforma_Click(sender As Object, e As EventArgs) Handles btnMultiforma.Click
        If MessageBox.Show("Recuerda que solo los cambios seleccionado serán incluidos en este reporte " & vbCrLf & " ¿Deseas continuar?", "Cambios seleccionados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim dtinfo As DataTable = sqlExecute("select top 1 reloj,'mod_sal' as tipo_reporte from personalvw where reloj ='xt912'")
            Dim dtInfoTemp As DataTable = Nothing
            For i As Integer = 0 To dgModSal.RowCount - 1
                If dgModSal.Item(1, i).Value.ToString.Equals("1") Then
                    Dim clock As String = dgModSal.Item(3, i).Value.ToString
                    dtInfoTemp = sqlExecute("select top 1 reloj,'mod_sal' as tipo_reporte from personalvw where reloj ='" & clock & "'")
                    If dtInfoTemp.Rows.Count > 0 Then
                        dtinfo.ImportRow(dtInfoTemp.Rows(0))
                    End If
                End If
            Next
            frmVistaPrevia.LlamarReporte("Formato Multiple", dtinfo)
            frmVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub chkMultiforma_CheckedChanged(sender As Object, e As EventArgs) Handles chkMultiforma.CheckedChanged
        For i As Integer = 0 To dgModSal.RowCount - 1
            dgModSal.Item(1, i).Value = IIf(chkMultiforma.Checked, 1, 0)
        Next
    End Sub

    Private Sub btnCargarExcel_Click(sender As Object, e As EventArgs) Handles btnCargarExcel.Click
        frmCargaExcelSalMasivos.ShowDialog()
        MostrarInformacion()
    End Sub
End Class