Public Class frmPtuParam
    Dim CantRep As Double = 0.0, dias_ptu As Double = 0.0, sdMax As Double = 0.0

    Private Sub frmPtuParam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dtDatosPtu As DataTable = sqlExecute("select * from ptu_param", "PERSONAL")

            If (Not dtDatosPtu.Columns.Contains("Error") And dtDatosPtu.Rows.Count > 0) Then
                Try : CantRep = dtDatosPtu.Rows(0).Item("cant_repartir").ToString.Trim : Catch ex As Exception : CantRep = 0.0 : End Try
                Try : dias_ptu = dtDatosPtu.Rows(0).Item("dias_ptu").ToString.Trim : Catch ex As Exception : dias_ptu = 60.0 : End Try
                Try : sdMax = dtDatosPtu.Rows(0).Item("sd_max").ToString.Trim : Catch ex As Exception : sdMax = 0.0 : End Try
            End If
            txtDiasMinConsid.Text = Double.Parse(dias_ptu)
            txtCantRepartir.Text = Double.Parse(CantRep)
            txtSDMaxSindic.Text = Double.Parse(sdMax)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Parámetros PTU", Err.Number, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If (txtDiasMinConsid.Text = "" Or txtDiasMinConsid.Text = "0.00") Then
            MessageBox.Show("Favor de capturar los días mínimos a considerar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If (txtCantRepartir.Text = "" Or txtCantRepartir.Text = "0.00") Then
            MessageBox.Show("Favor de capturar un monto válido a repartir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If (txtSDMaxSindic.Text = "" Or txtSDMaxSindic.Text = "0.00") Then
            MessageBox.Show("Favor de capturar un sueldo máximo válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            CantRep = Double.Parse(txtCantRepartir.Text)
            dias_ptu = Double.Parse(txtDiasMinConsid.Text)
            sdMax = Double.Parse(txtSDMaxSindic.Text)

            sqlExecute("truncate table  ptu_param", "PERSONAL")
            sqlExecute("insert into ptu_param values (" & CantRep & "," & sdMax & "," & dias_ptu & ")", "PERSONAL")
            MessageBox.Show("Los datos fueron guardados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()
            Me.Dispose()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Parámetros PTU", Err.Number, ex.Message)
        End Try


    End Sub
End Class