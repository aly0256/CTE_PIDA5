Public Class frmRangoFechas

    Public frmRangoFechas_fecha_ini As Date = Nothing
    Public frmRangoFechas_fecha_fin As Date = Nothing

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If dtFechaFinal.Value < dtFechaInicial.Value Then
                MessageBox.Show("La fecha inicial no debe ser mayor a la fecha inicial. Favor de verificar.", "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtFechaFinal.Focus()
            Else
                FechaInicial = dtFechaInicial.Value
                FechaFinal = dtFechaFinal.Value
                Me.Close()
                Me.Dispose()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        FechaInicial = Nothing
        FechaFinal = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            If Not IsNothing(frmRangoFechas_fecha_ini) Then
                dtFechaInicial.Value = frmRangoFechas_fecha_ini
            Else
                dtFechaInicial.Value = Now
            End If

            If Not IsNothing(frmRangoFechas_fecha_fin) Then
                dtFechaFinal.Value = frmRangoFechas_fecha_fin
            Else
                dtFechaFinal.Value = Now
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtFechaInicial_Click(sender As Object, e As EventArgs) Handles dtFechaInicial.Click

    End Sub
End Class