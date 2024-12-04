Public Class frmInfoPeriodosEspeciales
    Dim dtMeses As New DataTable

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmInfoPeriodosEspeciales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtPeriodos As New DataTable

        dtPeriodos = sqlExecute("SELECT * FROM periodos WHERE ano+periodo = '" & AnoSelec & PeriodoSelec & "'", "TA")
        If dtPeriodos.Rows.Count = 0 Then
            MessageBox.Show("El periodo seleccionado no es válido. Favor de verificar", "Periodo inválido", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If

        dtMeses = sqlExecute("SELECT num_mes,mes_may FROM meses ORDER BY num_mes")
        cmbMes.DataSource = dtMeses

        Dim drPeriodo As DataRow = dtPeriodos.Rows(0)
        gpInfo.Text = "PERIODO " & PeriodoSelec & " - " & AnoSelec
        txtFechaIni.Value = drPeriodo("fecha_ini")
        txtFechaFin.Value = drPeriodo("fecha_fin")
        txtDescripcion.Text = IIf(IsDBNull(drPeriodo("nombre")), "", drPeriodo("nombre"))
        txtObservaciones.Text = IIf(IsDBNull(drPeriodo("observaciones")), "", drPeriodo("observaciones"))
        txtFechaPago.Value = IIf(IsDBNull(drPeriodo("fecha_pago")), DateAdd(DateInterval.Day, 4, drPeriodo("fecha_fin")), drPeriodo("fecha_pago"))
        cmbMes.SelectedValue = IIf(IsDBNull(drPeriodo("num_mes")), Month(drPeriodo("fecha_ini")).ToString.PadLeft(2, "0"), drPeriodo("num_mes"))
        btnActivo.Value = True
        btnEspecial.Value = True

        txtFechaIni.Focus()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        'GUARDAR CAMBIOS
        Try
            If txtDescripcion.TextLength < 5 Then
                MessageBox.Show("La descripción del periodo no es válida. Favor de verificar.", "Descripción inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDescripcion.Focus()
                Exit Sub
            End If
            'BERE
            'sqlExecute("UPDATE periodos SET fecha_ini = '" & txtFechaIni.Value & "' WHERE CONCAT(ano,periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            'sqlExecute("UPDATE periodos SET fecha_fin = '" & txtFechaFin.Value & "' WHERE CONCAT(ano,periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            'sqlExecute("UPDATE periodos SET nombre = '" & txtDescripcion.Text & "' WHERE CONCAT(ano,periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            'sqlExecute("UPDATE periodos SET observaciones = '" & txtObservaciones.Text & "' WHERE CONCAT(ano,periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            'sqlExecute("UPDATE periodos SET fecha_pago = '" & FechaSQL(txtFechaPago.Value) & "' WHERE CONCAT(ano,periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            'sqlExecute("UPDATE periodos SET num_mes = '" & cmbMes.SelectedValue & "' WHERE CONCAT(ano,periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            'sqlExecute("UPDATE periodos SET mes = " & MesLetra(cmbMes.SelectedValue) & " WHERE CONCAT(ano,periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            sqlExecute("UPDATE periodos SET fecha_ini = '" & txtFechaIni.Value & "' WHERE (ano + periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            sqlExecute("UPDATE periodos SET fecha_fin = '" & txtFechaFin.Value & "' WHERE (ano + periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            sqlExecute("UPDATE periodos SET nombre = '" & txtDescripcion.Text & "' WHERE (ano + periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            sqlExecute("UPDATE periodos SET observaciones = '" & txtObservaciones.Text & "' WHERE (ano + periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            sqlExecute("UPDATE periodos SET fecha_pago = '" & FechaSQL(txtFechaPago.Value) & "' WHERE (ano + periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            sqlExecute("UPDATE periodos SET num_mes = '" & cmbMes.SelectedValue & "' WHERE (ano + periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            sqlExecute("UPDATE periodos SET mes = " & MesLetra(cmbMes.SelectedValue) & " WHERE (ano + periodo)='" & AnoSelec & PeriodoSelec & "'", "TA")
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try

    End Sub

    Private Sub txtFechaIni_Click(sender As Object, e As EventArgs) Handles txtFechaIni.Click

    End Sub
End Class