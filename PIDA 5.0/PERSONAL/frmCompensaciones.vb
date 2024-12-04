Public Class frmCompensaciones
    Dim dtModSal As New DataTable
    Dim dtTemp As New DataTable
    Dim dtInfo As New DataTable
    Dim dtValidCompen As New DataTable
    Dim EditaNew As Boolean = True
    Dim ID As Integer
    Private Sub SwitchButton_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton.ValueChanged
        If Me.gpCompen.Enabled = True Then
            If SwitchButton.Value = False Then
                Label10.Visible = True
                DateTimeInput3.Visible = True
                DateTimeInput3.Value = Now()
                lblEstado.Text = "Suspendido"
                lblEstado.BackColor = Color.Red
                lblEstado.ForeColor = Color.White
            Else
                If SwitchButton.Value = True Then
                    Label10.Visible = False
                    DateTimeInput3.Visible = False
                    DateTimeInput3.Value = Nothing
                    lblEstado.Text = "Activo"
                    lblEstado.BackColor = Color.LimeGreen
                    lblEstado.ForeColor = Color.White
                End If
            End If
        End If
    End Sub
    Private Sub btnBusca_Click(sender As Object, e As EventArgs) Handles btnBusca.Click
        Dim dtpersonal As DataTable
        Try
            frmBuscar.ShowDialog()
            dtpersonal = ConsultaPersonalVW("select  * from personalvw where reloj = '" & Declaraciones.Reloj & "'", False)
            If dtpersonal.Rows.Count > 0 Then
                MostrarInformacion(dtpersonal.Rows(0).Item("reloj"))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub MostrarInformacion(Reloj As String)
        Dim Cadena As String
        Dim ArchivoFoto As String
        Dim nResp As VariantType = vbNo
        Try

            If Reloj = "" Then
                Exit Sub
            End If

            dtValidCompen = sqlExecute("Select * From Compensaciones Where RELOJ = '" & Reloj & "' and Estatus = 'Activo'", "PERSONAL")
            If dtValidCompen.Rows.Count <> 0 Then
                nResp = MessageBox.Show("El empleado con número de reloj '" & Reloj & "', ya tiene una compensación Activa. ¿Quieres cancelar la compensación activa?", "Empleado con compensación activa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If nResp = vbYes Then
                    SwitchButton.Value = False
                    SwitchButton.OffText = "Suspendido"
                    DateTimeInput3.Value = Now
                    lblEstado.Text = "Suspendido"
                    lblEstado.BackColor = Color.Red
                    lblEstado.ForeColor = Color.White
                    Label10.Visible = True
                    DateTimeInput3.Visible = True
                Else
                    lblEstado.Text = "Activo"
                    lblEstado.BackColor = Color.LimeGreen
                    lblEstado.ForeColor = Color.White
                End If
                EditaNew = False
                txtID.Text = dtValidCompen.Rows(0).Item("Id")
                txtCompensacionActual.Text = dtValidCompen.Rows(0).Item("SCOBER")
                DateTimeInput1.Value = dtValidCompen.Rows(0).Item("FHA_INICIO")
                DateTimeInput2.Value = dtValidCompen.Rows(0).Item("FHA_FINAL")
                cmbTipoCompen.SelectedValue = dtValidCompen.Rows(0).Item("TIPO_COMPEN")
                txtComent.Text = IIf(IsDBNull(dtValidCompen.Rows(0).Item("COMENTARIOS")), Nothing, dtValidCompen.Rows(0).Item("COMENTARIOS"))
            End If

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

                ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
                ArchivoFoto = PathFoto & txtReloj.Text & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    ArchivoFoto = PathFoto & "nofoto.png"
                End If

                If Dir(ArchivoFoto) <> "" Then
                    Dim ft As New Bitmap(ArchivoFoto)
                    picFoto.Image = ft
                End If

                '*** HABILITAR CAPTURA SI EMPLEADO EXISTE
                Me.gpCompen.Enabled = True
                If dtValidCompen.Rows.Count = 0 And nResp = vbNo Then DateTimeInput1.Value = Now
                If dtValidCompen.Rows.Count = 0 And nResp = vbNo Then DateTimeInput2.Value = DateTimeInput1.Value.Date.AddDays(30)
                Me.txtCompensacionActual.Focus()

                'Dim dtLista As DataTable = sqlExecute("SELECT RELOJ, NOMBRES, FHA_INICO AS 'FECHA INICIO', FHA_FINAL AS 'FECHA FINAL', SCOBAR AS 'SUELDO COBERTURA', TIPO_COMPEN AS 'TIPO', ESTATUS, FHA_SUSPEN AS 'FECHA SUSPENSION', COMENTARIOS FROM compensaciones Where RELOJ = '" & Reloj & "'", "PERSONAL")
                Dim dtLista As DataTable = sqlExecute("SELECT * FROM compensaciones Where RELOJ = '" & Reloj & "'", "PERSONAL")
                dtLista.DefaultView.Sort = "FHA_INICIO"
                dgTabla.DataSource = dtLista
                dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub frmCompensaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtNivel As DataTable = sqlExecute("SELECT * FROM Tipo_Compensaciones ORDER BY Desc_Compen", "PERSONAL")
        cmbTipoCompen.DataSource = dtNivel
        cmbTipoCompen.ValueMember = "Cve_Compen"
        Me.gpCompen.Enabled = False
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim CambioValido As Boolean = True
        Try
            If txtReloj.TextLength = 0 Then
                If MessageBox.Show("No puede insertarse un sueldo de cobertura con un número de reloj en blanco. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) = vbOK Then
                    txtReloj.Focus()
                    CambioValido = False
                    Exit Sub
                End If
            Else
                Dim nCompAct As String = txtCompensacionActual.Text
                If nCompAct = "$0.00" Then
                    If MessageBox.Show("No puede insertarse un sueldo de cobertura en $0.00; Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) = vbOK Then
                        txtCompensacionActual.Focus()
                        CambioValido = False
                        Exit Sub
                    End If
                Else
                    If EditaNew = False Then If SwitchButton.Value = False Then Dim dtTemporal As DataTable = sqlExecute("UPDATE compensaciones SET ESTATUS = 'Suspendido', FHA_SUSPEN = '" & Now & "', COMENTARIOS = '" & txtComent.Text & "' WHERE Id = '" & txtID.Text & "' and RELOJ = '" & txtReloj.Text & "' and ESTATUS = 'Activo'", "PERSONAL")
                    If EditaNew = False Then If SwitchButton.Value = True Then Dim dtTemporal As DataTable = sqlExecute("UPDATE compensaciones SET SCOBER = '" & txtCompensacionActual.Text & "', FHA_INICIO = '" & FechaSQL(DateTimeInput1.Text) & "', FHA_FINAL = '" & FechaSQL(DateTimeInput2.Text) & "', TIPO_COMPEN = '" & cmbTipoCompen.SelectedValue & "', COMENTARIOS = '" & txtComent.Text & "' WHERE Id = '" & txtID.Text & "' and RELOJ = '" & txtReloj.Text & "' and ESTATUS = 'Activo'", "PERSONAL")
                    If EditaNew = True Then
                        If SwitchButton.Value = False Then
                            sqlExecute("INSERT INTO Compensaciones (RELOJ, NOMBRES, ALTA, FHA_INICIO, FHA_FINAL, SCOBER, TIPO_COMPEN, ESTATUS, FHA_SUSPEN, COMENTARIOS) VALUES ('" & _
                               txtReloj.Text & "','" & _
                               txtNombre.Text & "','" & _
                               txtAlta.Text & "','" & _
                               FechaSQL(DateTimeInput1.Text) & "','" & _
                               FechaSQL(DateTimeInput2.Text) & "','" & _
                               txtCompensacionActual.Text & "','" & _
                               cmbTipoCompen.SelectedValue & "','" & _
                               IIf(SwitchButton.Value = False, SwitchButton.OffText, SwitchButton.OnText) & "','" & _
                               FechaSQL(DateTimeInput3.Text) & "','" & _
                               txtComent.Text & "')")
                        Else
                            sqlExecute("INSERT INTO Compensaciones (RELOJ, NOMBRES, ALTA, FHA_INICIO, FHA_FINAL, SCOBER, TIPO_COMPEN, ESTATUS, COMENTARIOS) VALUES ('" & _
                               txtReloj.Text & "','" & _
                               txtNombre.Text & "','" & _
                               txtAlta.Text & "','" & _
                               FechaSQL(DateTimeInput1.Text) & "','" & _
                               FechaSQL(DateTimeInput2.Text) & "','" & _
                               txtCompensacionActual.Text & "','" & _
                               cmbTipoCompen.SelectedValue & "','" & _
                               IIf(SwitchButton.Value = False, SwitchButton.OffText, SwitchButton.OnText) & "','" & _
                               txtComent.Text & "')")
                        End If
                    End If
                    Dim dtLista As DataTable = sqlExecute("SELECT * FROM compensaciones Where RELOJ = '" & Reloj & "'", "PERSONAL")
                    dtLista.DefaultView.Sort = "FHA_INICIO"
                    dgTabla.DataSource = dtLista
                    dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    GenerarMultiforma()
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("No puede modificarse ó insertar el sueldo de compensación del empleado. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GenerarMultiforma()
        Dim dtinfo As DataTable = sqlExecute("Select * From compensaciones Where RELOJ = '" & txtReloj.Text & "'")
        If dtinfo.Rows.Count > 0 Then
            frmVistaPrevia.LlamarReporte("Formato de Compensaciones", dtinfo, "")
            frmVistaPrevia.ShowDialog()
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub txtCompensacionActual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCompensacionActual.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("capture solo números")
        End If
    End Sub
    Private Sub txtCompensacionActual_Validated(sender As Object, e As EventArgs) Handles txtCompensacionActual.Validated
        Dim Monto As String
        If Val(txtCompensacionActual.Text) > 0 Then
            Monto = FormatCurrency(Val(txtCompensacionActual.Text), , , TriState.True, TriState.True)
            txtCompensacionActual.Text = Monto
        End If
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
End Class