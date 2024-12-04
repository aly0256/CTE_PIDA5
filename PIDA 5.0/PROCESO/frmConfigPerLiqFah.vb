Public Class frmConfigPerLiqFah
    Dim dtPer As New DataTable

    Private Sub frmConfigPerLiqFah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtPer = sqlExecute("select anio_ini,per_ini,anio_fin,per_fin,anio_liq,coment from config_per_liqfah ", "NOMINA")
            dvbPerLiqFah.DataSource = dtPer
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnAddPer_Click(sender As Object, e As EventArgs) Handles btnAddPer.Click

        Dim Respuesta As Windows.Forms.DialogResult
        CalcIndivKey = "NVO"
        Respuesta = frmEditPerLiqFah.ShowDialog(Me)


        If Respuesta = Windows.Forms.DialogResult.Abort Then
            MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf Respuesta = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        '*--Actualiza Info
        dtPer = sqlExecute("select anio_ini,per_ini,anio_fin,per_fin,anio_liq,coment from config_per_liqfah ", "NOMINA")
        dvbPerLiqFah.DataSource = dtPer

    End Sub
End Class