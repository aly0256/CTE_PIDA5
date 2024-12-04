Public Class frmEditarDeducciones
    Dim dtConceptos As New DataTable
    Dim dtPeriodos As New DataTable
    Dim dtDeducc As New DataTable
    Dim dtTemp As New DataTable
    Dim Nuevo As Boolean
    Dim _strTipoPer = ""
    Dim PeriodoActivo As String = ""

    Private Sub frmEditarDeducciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtReloj.Text = frmMaestroDeducciones.txtReloj.Text
        txtNombre.Text = frmMaestroDeducciones.txtNombres.Text

        '== ProcesoBrpQro: Tipo de empleado para el periodo.
        Dim dtPer = sqlExecute("select reloj,COD_TIPO from personal.dbo.personal")
        Dim strPeriodoActivo = "select ano+periodo as 'unico' from ta.dbo.[tipo_per] where ACTIVO=1 ORDER BY ano DESC,periodo DESC"
        Dim strPeriodos = "SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin FROM ta.dbo.[tipo_per] WHERE " & _
                                         "periodo_especial IS NULL OR periodo_especial = 0 ORDER BY ano DESC,periodo ASC"

        Try
            'dtConceptos = sqlExecute("SELECT concepto,nombre FROM conceptos WHERE aplica_mtro_ded = 1", "nomina")
            dtConceptos = sqlExecute("SELECT (rtrim(concepto)+' - '+rtrim(nombre)) as concepto,concepto as con FROM conceptos", "nomina")
            cmbDeduccion.DataSource = dtConceptos

            '== ProcesoBrpQro: Tipo de empleado para el periodo.
            _strTipoPer = dtPer.Select("reloj='" & txtReloj.Text.Trim & "'").First().Item("cod_tipo").ToString.Trim
            strPeriodoActivo = strPeriodoActivo.Replace("[tipo_per]", "periodos")
            strPeriodos = strPeriodos.Replace("[tipo_per]", "periodos")

            '== ProcesoBrpQro: Comentado original
            dtTemp = sqlExecute(strPeriodoActivo)

            If dtTemp.Rows.Count > 0 Then PeriodoActivo = dtTemp.Rows(0).Item(0)
            dtPeriodos = sqlExecute(strPeriodos)
            cmbPeriodo.DataSource = dtPeriodos
            cmbPeriodo.SelectedValue = PeriodoActivo

            '== ProcesoBrpQro: No existe num. credito. Original comentado
            dtDeducc = sqlExecute("SELECT * FROM mtro_ded WHERE id  = '" & If(MtroDedConcepto = "NVO", -1, MtroDedConcepto) & "'", "nomina")

            If dtDeducc.Rows.Count = 0 Then
                'Si no se localiza el núm. de crédito, es que se va a agregar
                dtDeducc.Rows.Add()
                drMtroDed = dtDeducc.Rows(0)
                Nuevo = True
                cmbDeduccion.SelectedIndex = 0
                txtNumCredito.Text = ""
                txtSemanas.Text = 0
                txtSaldoInicial.Text = 0
                txtAbono.Text = 0
                txtSaldoActual.Text = 0
                txtTasa.Text = 0
                txtSemRestan.Text = 0
                btnProrratearMes.Value = False
                txtAbonoMes.Text = 0
                txtSaldoMes.Text = 0
                txtAbonoActual.Text = 0
                btnProrratear.Value = False
            Else
                Dim strConcepto = dtDeducc.Rows(0)("concepto").ToString.Trim
                Dim dtCon = dtConceptos.Select("con='" & strConcepto & "'").CopyToDataTable

                Nuevo = False
                drMtroDed = dtDeducc.Rows(0)
                cmbDeduccion.SelectedValue = dtCon.Rows(0).Item("concepto")
                cmbPeriodo.SelectedValue = dtDeducc.Rows(0).Item("ini_ano").ToString.Trim & dtDeducc.Rows(0).Item("ini_per").ToString.Trim
                txtSemanas.Text = IIf(IsDBNull(dtDeducc.Rows(0).Item("periodos")), 0, dtDeducc.Rows(0).Item("periodos"))
                txtSaldoInicial.Text = IIf(IsDBNull(dtDeducc.Rows(0).Item("ini_saldo")), 0, dtDeducc.Rows(0).Item("ini_saldo"))
                txtAbono.Text = IIf(IsDBNull(dtDeducc.Rows(0).Item("abono")), 0, dtDeducc.Rows(0).Item("abono"))
                txtSaldoActual.Text = IIf(IsDBNull(dtDeducc.Rows(0).Item("sald_act")), 0, dtDeducc.Rows(0).Item("sald_act"))
            End If

            cmbDeduccion.Enabled = Nuevo
            txtSaldoInicial.Enabled = Nuevo
            txtSaldoActual.Enabled = False
            txtAbono.Enabled = True
            cmbPeriodo.Enabled = Nuevo
            txtSemanas.Enabled = Nuevo

        Catch ex As Exception
            MessageBox.Show("Se detectaron errores al intentar editar. Si el error persiste, contacte al administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub

    Private Sub CalculaSaldoAbono(sender As Object, e As EventArgs) Handles txtSemanas.ValueChanged, txtSaldoInicial.ValueChanged
        Try
            txtAbono.Value = Math.Round(IIf(txtSemanas.Value > 0, txtSaldoInicial.Value / txtSemanas.Value, 0), 2)
            If txtSemanas.Value > 0 Then
                txtAbono.Value = Math.Round(txtSaldoInicial.Value / txtSemanas.Value, 2)
                txtSaldoActual.Value = Math.Round(txtSaldoInicial.Value, 2)
                txtSemRestan.Value = txtSemanas.Value
                txtAbonoActual.Value = Math.Round(txtSaldoInicial.Value / txtSemanas.Value, 2)
            End If

            If txtSemanas.Value = 0 And txtSaldoInicial.Value = 0 Then
                txtAbono.Text = 0.0
                txtSaldoActual.Text = 0.0
            End If
        Catch ex As Exception
            txtAbono.Text = ""
            txtSaldoActual.Text = ""
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim Concepto As String
            Dim NumCredito As String

            Dim strConcepto = cmbDeduccion.SelectedValue.ToString.Split(" - ")(0)
            Concepto = strConcepto

            NumCredito = Date.Now.TimeOfDay.ToString.Replace(".", "").Replace(":", "")
            drMtroDed("concepto") = Concepto
            drMtroDed("ini_ano") = cmbPeriodo.SelectedValue.ToString.Substring(0, 4)
            drMtroDed("ini_per") = cmbPeriodo.SelectedValue.ToString.Substring(4, 2)
            drMtroDed("periodos") = txtSemanas.Value
            drMtroDed("ini_saldo") = txtSaldoInicial.Value
            drMtroDed("abono") = txtAbono.Value
            drMtroDed("sald_act") = txtSaldoActual.Value

            'Tipo empleado
            Dim tipoEmp = sqlExecute("select reloj,cod_tipo from personal.dbo.personal where reloj='" & txtReloj.Text & "'")
            Dim tipo = "NULL"
            If tipoEmp.Rows.Count > 0 Then tipo = "S"

            '-------------------------------------------
            'Guardar cambios
            If Nuevo Then
                '== ProcesoBRPQro: Original comentada y modificada
                sqlExecute("INSERT INTO nomina.dbo.saldos_ca (reloj,periodo,ano,concepto,numcredito,abono_alc,saldo_act,comentario) VALUES ('" & _
                           txtReloj.Text & "','" &
                           drMtroDed("ini_per") & "','" &
                           drMtroDed("ini_ano") & "','" &
                           Concepto & "','" &
                           NumCredito & _
                           "',0," &
                           drMtroDed("sald_act") &
                           ",'Saldo inicial " &
                           drMtroDed("ini_saldo") &
                           " Usuario: " &
                           Usuario & "')", "nomina")

                sqlExecute("INSERT INTO nomina.dbo.mtro_ded (concepto,abono,ini_saldo,ini_per,ini_ano,periodos,sald_act,activo,fijo,comentario,tipo_perio,reloj,credito) " &
                           "values ('" & drMtroDed("concepto") &
                           "'," & drMtroDed("abono") &
                           "," & drMtroDed("ini_saldo") &
                           ",'" & drMtroDed("ini_per") &
                           "','" & drMtroDed("ini_ano") &
                           "','" & drMtroDed("periodos") &
                           "'," & drMtroDed("sald_act") &
                           ",1,0,'Ingresado Sem " & drMtroDed("ini_ano") & "-" & drMtroDed("ini_per") & "','" & tipo & "','" & txtReloj.Text & "'," &
                           "'" & NumCredito & "')")
            End If

            '== Actualizar registros de mtro_ded
            ActualizaMtroDed(MtroDedConcepto, "abono", drMtroDed("abono"))
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        End Try
    End Sub

    ''' <summary>
    ''' Funcion para actualizar el mtro ded [Provisionalmente se utilizara el id para actualizar el registro, en vez de num. de crédito]
    ''' </summary>
    ''' <param name="Campo"></param>
    ''' <param name="Valor"></param>
    ''' <remarks></remarks>
    Private Sub ActualizaMtroDed(ByVal ID As String, ByVal Campo As String, ByVal Valor As String)
        Try
            If ID <> "NVO" Then sqlExecute("UPDATE mtro_ded SET " & Campo & " = '" & Valor & "' WHERE id = '" & ID & "'", "nomina")
        Catch ex As Exception
            'ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnProrratearMes_ValueChanged(sender As Object, e As EventArgs) Handles btnProrratearMes.ValueChanged
        If btnProrratearMes.Value Then
            'Para evitar pérdidas en el redondeo, se suma +.005
            txtAbonoMes.Value = Math.Round((txtSaldoInicial.Value / txtSemanas.Value * 4) + 0.005, 2)

            txtSaldoMes.Value = txtAbonoMes.Value
            txtAbonoActual.Value = txtAbonoMes.Value / 4
        Else
            txtAbonoMes.Value = 0
            txtSaldoMes.Value = 0
            txtAbonoActual.Value = 0
        End If
    End Sub

End Class