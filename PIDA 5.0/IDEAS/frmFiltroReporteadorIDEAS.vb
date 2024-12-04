Public Class frmFiltroReporteadorIDEAS
    Dim dtAno As New DataTable
    Dim dtPeriodo As New DataTable

    Private Sub frmFiltroReporteador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtPeriodo = sqlExecute("SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin,(CASE activo WHEN 1 THEN '   *' ELSE '' END) AS activo FROM periodos WHERE periodo_especial IS NULL OR periodo_especial = 0 ORDER BY ano DESC,periodo ASC", "TA")
            cmbPeriodos.DataSource = dtPeriodo

            dtTemporal = sqlExecute("SELECT TOP 1 ano + periodo as anoPeriodo FROM periodos WHERE activo = 1 ORDER BY ano DESC,periodo DESC", "TA")
            If dtTemporal.Rows.Count > 0 Then
                cmbPeriodos.SelectedValue = dtTemporal.Rows(0).Item("anoPeriodo")
            End If
            dtAno = sqlExecute("SELECT DISTINCT ano as Año FROM periodos", "TA")
            cmbAno.DataSource = dtAno
            'MCR 9/NOV/2015
            cmbAno.ValueMember = "Año"
            cmbAno.SelectedValue = Year(Now) + 1
            '   cmbAno.SelectedValue = dtAno.Rows(0).Item(0).ToString
            'cmbAno.SelectedIndex = 0
            txtFecha1.Value = DateSerial(Now.Year, Now.Month, 1)
            txtFecha2.Value = DateAdd(DateInterval.Day, 28, txtFecha1.Value)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub chkAnoFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles chkAnoFiscal.CheckedChanged
        Try
            cmbPeriodos.Enabled = optPeriodo.Checked
            txtFecha1.Enabled = optRango.Checked
            txtFecha2.Enabled = optRango.Checked
            cmbAno.Enabled = chkAnoFiscal.Checked
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub optPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles optPeriodo.CheckedChanged
        Try
            cmbPeriodos.Enabled = optPeriodo.Checked
            txtFecha1.Enabled = optRango.Checked
            txtFecha2.Enabled = optRango.Checked
            cmbAno.Enabled = chkAnoFiscal.Checked
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub optRango_CheckedChanged(sender As Object, e As EventArgs) Handles optRango.CheckedChanged
        Try
            cmbPeriodos.Enabled = optPeriodo.Checked
            txtFecha1.Enabled = optRango.Checked
            txtFecha2.Enabled = optRango.Checked
            cmbAno.Enabled = chkAnoFiscal.Checked
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If txtFecha1.Value > txtFecha2.Value Then
                MessageBox.Show("El rango de fechas es inválido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            TipoFiltro = IIf(optPeriodo.Checked, "PERIODO", "RANGO")
            If optPeriodo.Checked Then
                PeriodoSelec = cmbPeriodos.SelectedValue.ToString.Substring(4, 2)
                AnoSelec = cmbPeriodos.SelectedValue.ToString.Substring(0, 4)

                dtTemporal = sqlExecute("SELECT Fecha_Ini,Fecha_Fin FROM periodos WHERE ano = '" & AnoSelec & "' AND periodo = '" & PeriodoSelec & "'", "TA")
                If dtTemporal.Rows.Count = 0 Then
                    MessageBox.Show("El periodo/año seleccionado es inválido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                RangoFInicial = dtTemporal.Rows(0).Item("fecha_Ini")
                RangoFFinal = dtTemporal.Rows(0).Item("fecha_fin")

                FechaInicial = RangoFInicial
                FechaFinal = RangoFFinal
            ElseIf optRango.Checked Then

                RangoFInicial = txtFecha1.Value
                RangoFFinal = txtFecha2.Value
            Else
                Dim tempIni As Int16
                tempIni = cmbAno.SelectedValue - 1
                RangoFInicial = tempIni.ToString + "-02-01"
                RangoFFinal = cmbAno.SelectedValue + "-01-31"
            End If

            FechaInicial = RangoFInicial
            FechaFinal = RangoFFinal

            Me.DialogResult = Windows.Forms.DialogResult.OK
            'Me.Close()
            'Me.Dispose()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se detectó un error al asignar el rango. Si el error persiste, contacte al administrador del sistema." & _
                            vbCrLf & vbCrLf & "Err.-" & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

End Class