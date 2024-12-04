Public Class frmTiempoxTiempos
    Public reloj_t As String
    Public horario_t As String
    Dim fecha1 As Date = Today()
    Dim fecha2 As Date = Date.Today.AddDays(1)
    Dim _fecha_analisis As Date
    Private Sub frmTiempoxTiempo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        _fecha_analisis = FechaIni
        Dim dttxt As DataTable = sqlExecute("select * from tiempo_x_tiempo where reloj = '" & reloj_t & "' and fecha_intercambio = '" & FechaSQL(_fecha_analisis) & "'", "PERSONAL")
        If dttxt.Rows.Count > 0 Then
            sqlExecute("delete from tiempo_x_tiempo where reloj = '" & reloj_t & "' and fecha_intercambio = '" & FechaSQL(_fecha_analisis) & "'", "PERSONAL")
            Me.Close()
            MessageBox.Show("Se borro con exito el Tiempo x tiempo", "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
End Class