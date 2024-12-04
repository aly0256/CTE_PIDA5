Public Class frmDispositivosCafeteria

    Private Sub frmDispositivosCafeteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TimerConexion.Start()


        ActualizarDispositivos()
    End Sub
    Private Sub ActualizarDispositivos()
        Dim dtDispositivos As DataTable = sqlExecute("select * from dispositivos order by cod_dispositivo ", "cafeteria")
        For Each d As DataRow In dtDispositivos.Rows
            flwDispositivos.Controls.Add(New uscDispositivoCafeteria(d.Item("cod_dispositivo")))

        Next
    End Sub

    Private Sub TimerConexion_Tick(sender As Object, e As EventArgs) Handles TimerConexion.Tick
        sqlExecute("update dispositivos set conectado = '0'", "cafeteria")
    End Sub
End Class