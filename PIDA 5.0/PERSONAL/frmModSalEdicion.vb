Public Class frmModSalEdicion
    Dim dtModSal As New DataTable
    Dim dtTemp As New DataTable
    Dim dtInfo As New DataTable
    Dim dtNivel As New DataTable
    Dim Nivel As String = ""
    Dim CompaRatio As Double
    Dim EditaInfo As Boolean = False
    Dim ID As Integer

    Private Sub frmModSalEdicion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub frmModSalEdicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not EditaInfo Then
            ' BG - Mostrar únicamente la opcion para Inicio de periodo de prueba / Inhabilitar los demás controles
            dtModSal = sqlExecute("SELECT * FROM tipo_mod_sal")
            cmbTipoModSal.DataSource = dtModSal

            'cmbNivel.Enabled = False
            'txtCambioA.Enabled = False
            'txtProVar.Enabled = False
            'txtIntegrado.Enabled = False
            'txtFactorInt.Enabled = False
            '

            txtFecha.Value = Today

            dtTemporal = sqlExecute("SELECT cod_tipo_mod,fecha_mod FROM configuracion WHERE usuario = '" & Usuario & "'", "Seguridad")
            If dtTemporal.Rows.Count > 0 Then
                txtFecha.Value = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("fecha_mod")), Today, dtTemporal.Rows.Item(0).Item("fecha_mod"))
                cmbTipoModSal.SelectedValue = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("cod_tipo_mod")), "A", dtTemporal.Rows.Item(0).Item("cod_tipo_mod"))
            End If
        End If
        btnBuscar.Enabled = Not EditaInfo
    End Sub

    Public Function MostrarInformacionEDICION(modID As Integer) As Boolean
        Dim dtEdicion As New DataTable
        Dim Reloj As String
        Try
            ID = modID
            dtEdicion = sqlExecute("SELECT * FROM mod_sal WHERE ID =" & ID)
            If dtEdicion.Rows.Count < 1 Then
                EditaInfo = False
                Return False
            Else
                EditaInfo = True
                'dtModSal = sqlExecute("SELECT * FROM tipo_mod_sal")
                cmbTipoModSal.DataSource = dtModSal


                Reloj = dtEdicion.Rows.Item(0).Item("reloj")
                txtReloj.Text = Reloj
                txtReloj.Enabled = False
                dtTemp = sqlExecute("SELECT baja from personalvw WHERE reloj = '" & Reloj & "'")
                If dtTemp.Rows.Count = 0 Then
                    MessageBox.Show("El empleado no fue localizado en archivo maestro. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                ElseIf Not IsDBNull(dtTemp.Rows.Item(0).Item("baja")) Then
                    MessageBox.Show("No puede modificarse el sueldo de un empleado dado de baja. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                MostrarInformacion(Reloj)

                txtSueldoActual.Text = dtEdicion.Rows.Item(0).Item("cambio_de")
                cmbTipoModSal.SelectedValue = dtEdicion.Rows.Item(0).Item("cod_tipo_mod")
                cmbNivel.SelectedValue = dtEdicion.Rows.Item(0).Item("nivel")
                txtCambioA.Text = dtEdicion.Rows.Item(0).Item("cambio_a")
                txtFecha.Value = dtEdicion.Rows.Item(0).Item("fecha")
                txtProVar.Text = dtEdicion.Rows.Item(0).Item("provar")
                txtFactorInt.Text = dtEdicion.Rows.Item(0).Item("fact_int")
                txtIntegrado.Text = dtEdicion.Rows.Item(0).Item("integrado")
                txtNotas.Text = dtEdicion.Rows.Item(0).Item("notas")

                cmbTipoModSal.Focus()
                Return True
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            Return False
        End Try
    End Function

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        dtTemp = dtInfo
        Reloj = txtReloj.Text
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            dtInfo = dtTemp
        End Try
    End Sub

    Private Sub MostrarInformacion(Reloj As String)
        Dim Cadena As String
        Dim ArchivoFoto As String
        Try


            If Reloj = "" Then
                Exit Sub
            End If

            'Cadena = "SELECT personalvw.cod_comp,personalvw.RELOJ,personalvw.NOMBRES,personalvw.COD_DEPTO,personalvw.COD_SUPER,personalvw.COD_PUESTO,deptos.NOMBRE AS departamento,"
            'Cadena = Cadena & " puestos.nombre AS puesto,super.nombre AS supervisor,personalvw.ALTA,personalvw.BAJA,super.NOMBRE,puestos.NOMBRE,sactual,personalvw.nivel,personalvw.cod_tipo from personalvw"
            'Cadena = Cadena & " FULL OUTER JOIN deptos ON deptos.COD_DEPTO = personalvw.COD_DEPTO"
            'Cadena = Cadena & " INNER JOIN puestos ON personalvw.COD_PUESTO = puestos.COD_PUESTO"
            'Cadena = Cadena & " INNER JOIN super ON personalvw.COD_SUPER = super.COD_SUPER"
            'Cadena = Cadena & " WHERE personalvw.RELOJ = '" & Reloj & "'"

            Cadena = "SELECT cod_comp,RELOJ,pro_var,nombres,cod_depto,cod_super,cod_puesto,factor_int, nombre_depto as departamento,nombre_puesto as puesto,nombre_super as supervisor,alta,baja,sactual,nivel,cod_tipo,COMPA_RATIO  from personalvw WHERE RELOJ = '" & Reloj & "'"

            dtInfo = ConsultaPersonalVW(Cadena, False)
            If dtInfo.Rows.Count < 1 Then
                MessageBox.Show("No se localizó el empleado con número de reloj '" & Reloj & "', o tiene un nivel al que este usuario no tiene acceso.", "Empleado no localizado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReloj.Focus()
                Exit Sub
            End If

            If Not IsDBNull(dtInfo.Rows.Item(0).Item("baja")) Then
                MessageBox.Show("No puede modificarse el sueldo de un empleado dado de baja. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                txtComp.Text = dtInfo.Rows.Item(0).Item("cod_comp")
                txtReloj.Text = dtInfo.Rows.Item(0).Item("reloj")
                txtNombre.Text = dtInfo.Rows.Item(0).Item("nombres")
                txtDepto.Text = IIf(IsDBNull(dtInfo.Rows.Item(0).Item("departamento")), "", dtInfo.Rows.Item(0).Item("departamento"))
                txtPuesto.Text = IIf(IsDBNull(dtInfo.Rows.Item(0).Item("puesto")), "", dtInfo.Rows.Item(0).Item("puesto"))
                txtTipo.Text = IIf(IsDBNull(dtInfo.Rows.Item(0).Item("cod_tipo")), "", dtInfo.Rows.Item(0).Item("cod_tipo"))
                txtAlta.Text = dtInfo.Rows.Item(0).Item("alta")

                txtFactorInt.Text = dtInfo.Rows.Item(0).Item("factor_int")
                'MCR 6-OCT-2015
                'Solo cargar niveles que correspondan al tipo de empleado y compañía
                dtNivel = sqlExecute("SELECT * FROM niveles WHERE cod_comp = '" & txtComp.Text & "'")
                cmbNivel.DataSource = dtNivel
                cmbNivel.DisplayMembers = "nivel,sueldo"
                cmbNivel.ValueMember = "nivel"
                CompaRatio = IIf(IsDBNull(dtInfo.Rows(0).Item("COMPA_RATIO")), 0, dtInfo.Rows(0).Item("COMPA_RATIO"))
                Nivel = IIf(IsDBNull(dtInfo.Rows.Item(0).Item("nivel")), "", dtInfo.Rows.Item(0).Item("nivel"))
                cmbNivel.SelectedValue = Nivel
                txtSueldoActual.Text = IIf(IsDBNull(dtInfo.Rows.Item(0).Item("sactual")), 0, dtInfo.Rows.Item(0).Item("sactual"))
                txtProVar.Text = IIf(IsDBNull(dtInfo.Rows.Item(0).Item("pro_var")), 0, dtInfo.Rows.Item(0).Item("pro_var"))
                'BG 11/4/16 Si sueldo correspondiente a nivel es menor al salario actual, usar sueldo actual como 'cambio a:'
                Dim dtsueldonivel As DataTable = sqlExecute("select * from niveles where nivel='" & cmbNivel.SelectedValue & "' and cod_comp='" & dtInfo.Rows.Item(0).Item("cod_comp") & "'")
                If IsDBNull(dtsueldonivel.Rows(0)("sueldo")) Then
                    txtCambioA.Text = txtSueldoActual.Text
                ElseIf (dtsueldonivel.Rows(0)("sueldo") < CDbl(txtSueldoActual.Text)) Then
                    txtCambioA.Text = txtSueldoActual.Text
                End If
                '
                ' BG 30/03/16 Sólo permitir modificaciones de sueldo a empleados que no sean BRP
                Dim dtCia As DataTable = sqlExecute("select cod_comp from personalvw where reloj='" & Reloj & "'")
                If dtCia.Rows.Item(0).Item("cod_comp") = "090" Or dtCia.Rows.Item(0).Item("cod_comp") = "097" Then
                    dtModSal = sqlExecute("SELECT * FROM tipo_mod_sal where cod_tipo_mod='IPP'")
                    cmbNivel.Enabled = False
                    txtCambioA.Enabled = False
                    txtProVar.Enabled = False
                    txtIntegrado.Enabled = False
                    txtFactorInt.Enabled = False
                Else
                    dtModSal = sqlExecute("SELECT * FROM tipo_mod_sal")
                    cmbNivel.Enabled = True
                    txtCambioA.Enabled = True
                    txtProVar.Enabled = True
                    txtIntegrado.Enabled = True
                    txtFactorInt.Enabled = True
                End If
                cmbTipoModSal.DataSource = dtModSal
                '
                ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
                ArchivoFoto = PathFoto & txtReloj.Text & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    ArchivoFoto = PathFoto & "nofoto.png"
                End If

                If Dir(ArchivoFoto) <> "" Then
                    Dim ft As New Bitmap(ArchivoFoto)
                    picFoto.Image = ft
                End If
                '****************************************
            End If


            Try
                Dim dtPeriodos As DataTable = sqlExecute("select fecha_ini from periodos where fecha_ini <= '" & FechaSQL(Now) & "' and fecha_fin >= '" & FechaSQL(Now) & "' and periodo_especial = '0'", "ta")
                If dtPeriodos.Rows.Count Then
                    txtFecha.Value = dtPeriodos.Rows(0)("fecha_ini")
                End If
            Catch ex As Exception

            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub




    Private Sub txtReloj_Validated(sender As Object, e As EventArgs) Handles txtReloj.Validated
        Try
            If txtReloj.TextLength > 0 Then
                txtReloj.Text = txtReloj.Text.PadLeft(LongReloj, "0")
            End If
            MostrarInformacion(txtReloj.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtReloj_TextChanged(sender As Object, e As EventArgs) Handles txtReloj.TextChanged

    End Sub

    Private Sub cmbNivel_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNivel.SelectedValueChanged
        Dim sdo As Double
        dtTemp = sqlExecute("SELECT sueldo FROM niveles WHERE cod_comp = '" & txtComp.Text & "' AND nivel = '" & cmbNivel.SelectedValue & "'")
        If dtTemp.Rows.Count > 0 Then
            sdo = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("sueldo")), 0, dtTemp.Rows.Item(0).Item("sueldo"))

            If sdo <> 0 Then
                txtCambioA.Text = sdo
            End If
            txtCambioA.Enabled = (sdo = 0)

        End If
    End Sub

    Private Sub cmbNivel_Validated(sender As Object, e As EventArgs) Handles cmbNivel.Validated
        Dim sdo As Double
        dtTemp = sqlExecute("SELECT sueldo FROM niveles WHERE cod_comp = '" & txtComp.Text & "' AND nivel = '" & cmbNivel.SelectedValue & "'")
        If dtTemp.Rows.Count > 0 Then
            sdo = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("sueldo")), 0, dtTemp.Rows.Item(0).Item("sueldo"))

            If sdo <> 0 Then
                txtCambioA.Text = sdo
            End If
            txtCambioA.Enabled = (sdo = 0)

        End If

    End Sub

    Private Sub txtFecha_Click(sender As Object, e As EventArgs) Handles txtFecha.Click

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim cadena As String
        Dim CambioValido As Boolean = True
        Dim Notas As String
        Dim Integrado As String
        Dim dtCompaRatio As New DataTable
        dtTemporal = sqlExecute("UPDATE configuracion SET cod_tipo_mod = '" & cmbTipoModSal.SelectedValue & "', fecha_mod = '" & FechaSQL(txtFecha.Value) & "' WHERE usuario = '" & Usuario & "'", "Seguridad")

        If txtReloj.TextLength = 0 Then
            If MessageBox.Show("No puede insertarse un cambio de sueldo con un número de reloj en blanco. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) = vbOK Then
                txtReloj.Focus()
                CambioValido = False
                Exit Sub
            Else

            End If
        End If


        'MCR 19/NOV/2015
        'Revisar si la compañía del empleado es editable
        'Si no lo es, no permitir modificarlo
        If CambioValido And cmbTipoModSal.SelectedValue <> "IPP" Then
            dtTemporal = sqlExecute("select * from cias where cod_comp in (select cod_comp from personal where reloj = '" & txtReloj.Text & "') and  isnull(editable, 1) = 1")
            If dtTemporal.Rows.Count = 0 Then
                MessageBox.Show("El empleado pertenece a una compañía NO EDITABLE, por lo que no es posible procesar un cambio de sueldo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtReloj.Focus()
                CambioValido = False
                Exit Sub
            End If
        End If
        '******************************

        If CambioValido Then
            dtTemp = sqlExecute("SELECT reloj from personalvw WHERE reloj = '" & txtReloj.Text & "'")
            If dtTemp.Rows.Count < 1 Then
                If MessageBox.Show("No puede insertarse un cambio de sueldo para un empleado no localizado. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) = vbOK Then
                    txtReloj.Focus()
                    CambioValido = False
                    Exit Sub
                Else

                End If
            End If
        End If

        If CDbl(txtCambioA.Text) < CDbl(txtSueldoActual.Text) And CambioValido Then
            If MessageBox.Show("El sueldo nuevo es menor que el sueldo anterior, favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) = vbOK Then
                cmbNivel.Focus()
                CambioValido = False
                Exit Sub
            Else

            End If
        End If

        If CambioValido Then
            dtTemp = sqlExecute("SELECT cod_comp,cod_tipo,alta from personalvw WHERE reloj = '" & txtReloj.Text & "'")
            Dim factor As Double = FactorIntegracion(dtTemp.Rows(0)("cod_comp"), dtTemp.Rows(0)("cod_tipo"), Antiguedad(dtTemp.Rows(0)("alta"), Now))
            If factor > CDbl(txtFactorInt.Text) Then
                'Si el factor calculado es mayor al que trae el empleado, reemplazar. Si no, utilizar el del empleado
                txtFactorInt.Text = factor
                txtIntegrado.Text = FormatCurrency((txtCambioA.Text * txtFactorInt.Text) + txtProVar.Text)

                'MessageBox.Show("El factor de integración no corresponde a la tabla de factores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'cmbNivel.Focus()
                'CambioValido = False
                'Exit Sub
            End If
        End If



        If DateDiff(DateInterval.Day, txtFecha.Value, Today) > 15 And CambioValido Then
            If MessageBox.Show("La diferencia entre la fecha de aplicación del movimiento y el día de hoy, no puede ser mayor a 15 días .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) = vbOK Then
                txtFecha.Focus()
                CambioValido = False
            Else

            End If
        End If

        If CambioValido Then
            If EditaInfo Then
                dtTemp = sqlExecute("DELETE FROM mod_sal WHERE id = " & ID)
                ' sqlExecute("delete formato_multiple where comentario = '" & ID & "'")


            End If

            Notas = txtNotas.Text
            Notas = Notas.Replace("'", "''")
            Notas = Notas.Replace(Chr(34), "''")

            Integrado = txtIntegrado.Text.Replace("$", "")
            Integrado = Integrado.Replace(",", "")

            dtTemp = sqlExecute("SELECT MAX(ID)+ 1 AS ID FROM mod_sal")
            If dtTemp.Rows.Count <= 0 Then
                ID = 0
            Else
                ID = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("ID")), 0, dtTemp.Rows.Item(0).Item("ID"))
            End If
            '***********************Calcular compa_ratio nuevo y ant **********
            Dim SActual As Double = Double.Parse(txtCambioA.Text)
            Dim compa_ratio_ant As Double = CompaRatio
            Dim compa_ratio_nvo As Double
            Dim NivelAnt As String = Nivel
            Dim NivelNuevo As String = cmbNivel.SelectedValue
            Dim MidPoint As Double = 0

            dtCompaRatio = sqlExecute("select * from niveles where cod_comp = '" & txtComp.Text & "' and nivel = '" & NivelNuevo & "'")
            For Each row As DataRow In dtCompaRatio.Rows
                MidPoint = IIf(IsDBNull(row.Item("MED")), 0, row.Item("MED"))
                If MidPoint <> 0 Then
                    compa_ratio_nvo = ((SActual * 30.4) / MidPoint) * 100
                Else
                    compa_ratio_nvo = 0
                End If
            Next

            cadena = "INSERT INTO mod_sal (cod_comp,reloj,cod_tipo_mod,cambio_de,cambio_a,provar,fact_int,fecha,notas,nivel,integrado,hoy,compa_ratio_ant,compa_ratio_nvo) VALUES ('"
            cadena = cadena & txtComp.Text & "','" & txtReloj.Text & "','" & cmbTipoModSal.SelectedValue & "'," & txtSueldoActual.Text & "," & txtCambioA.Text & ","
            cadena = cadena & txtProVar.Text & "," & txtFactorInt.Text & ",'" & FechaSQL(txtFecha.Value) & "','" & txtNotas.Text & "','" & cmbNivel.SelectedValue & "',"
            cadena = cadena & Integrado & ", GETDATE(),'" & Format(compa_ratio_ant, "f") & "','" & Format(compa_ratio_nvo, "f") & "')"

            dtTemp = sqlExecute(cadena)
            ' cadena = "insert into formato_multipl (cod_comp,reloj,fecha_captura,hora_captura,usuario,equipo,comentario,campo,valor_actual,valor_nuevo,tipo_movimiento,fecha_efectiva,confirmado,impreso)"
            'cadena = cadena + " values('" & txtComp.Text & "','" & txtReloj.Text & "',GETDATE(),GETDATE(),'" & Usuario & "','" & My.Computer.Name & "','')"
            ' sqlExecute("insert into formato_multipl (cod_comp,reloj,fecha_captura,hora_captura,usuario,equipo,comentario,campo,valor_actual,valor_nuevo,tipo_movimiento,fecha_efectiva,confirmado,impreso)")
            'sqlExecute("delete formato_multiple where reloj = '" & Reloj & "' and tipo_movimiento = 'SALARIO' and confirmado = '0'")

            'Consultar e imprimir multiforma
            GenerarMultiforma()

            Me.Close()
        Else
            Me.Close()
        End If

    End Sub
    Private Sub GenerarMultiforma()
        Dim dtinfo As DataTable = sqlExecute("select top 1 personalvw.reloj,'mod_sal' as tipo_reporte from personalvw left join mod_sal on personalvw.reloj = mod_sal.reloj where personalvw.reloj ='" & txtReloj.Text & "' and mod_sal.aplicado='0'")
        If dtinfo.Rows.Count > 0 Then
            frmVistaPrevia.LlamarReporte("Formato Multiple", dtinfo)
            frmVistaPrevia.ShowDialog()
        End If

    End Sub
    Private Sub txtFecha_Validated(sender As Object, e As EventArgs) Handles txtFecha.Validated
        'Try
        '    Dim Factor As Decimal
        '    Dim Integrado As Decimal

        '    Factor = Format(FactorIntegracion(txtComp.Text, txtTipo.Text, DateDiff(DateInterval.Year, Date.Parse(txtAlta.Text), txtFecha.Value)), "0.0000")
        '    Integrado = (txtCambioA.Text * Factor) + txtProVar.Text

        '    txtFactorInt.Text = Factor
        '    txtIntegrado.Text = FormatCurrency(Integrado)
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub txtFecha_ValueChanged(sender As Object, e As EventArgs) Handles txtFecha.ValueChanged
        'Try
        '    Dim Factor As Double
        '    Dim Integrado As Decimal

        '    Factor = Format(FactorIntegracion(txtComp.Text, txtTipo.Text, DateDiff(DateInterval.Year, Date.Parse(txtAlta.Text), txtFecha.Value)), "0.0000")
        '    Integrado = (txtCambioA.Text * Factor) + txtProVar.Text

        '    txtFactorInt.Text = Factor
        '    txtIntegrado.Text = FormatCurrency(Integrado)
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmbNivel_TextChanged(sender As Object, e As EventArgs) Handles cmbNivel.TextChanged

    End Sub

    Private Sub gpSueldos_Click(sender As Object, e As EventArgs) Handles gpSueldos.Click

    End Sub

    Private Sub txtReloj_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReloj.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                cmbTipoModSal.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub txtCambioA_TextChanged(sender As Object, e As EventArgs) Handles txtCambioA.TextChanged
        Try
            Dim Integrado As Double = (txtCambioA.Text * txtFactorInt.Text) + txtProVar.Text

            txtIntegrado.Text = FormatCurrency(Integrado)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub btnBusca_Click(sender As Object, e As EventArgs) Handles btnBusca.Click
        Dim dtpersonal As DataTable
        Try
            frmBuscar.ShowDialog()
            dtpersonal = ConsultaPersonalVW("select  * from personalvw where reloj = '" & Declaraciones.Reloj & "'", False)
            If dtPersonal.Rows.Count > 0 Then
                MostrarInformacion(dtpersonal.Rows(0).Item("reloj"))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbTipoModSal_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoModSal.SelectedValueChanged
        If cmbTipoModSal.SelectedValue = "IPP" Then
            txtCambioA.Enabled = False
        Else
            txtCambioA.Enabled = True
        End If
    End Sub
End Class