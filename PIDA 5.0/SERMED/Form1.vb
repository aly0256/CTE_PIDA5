Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cambiarfechas()
        'agregarProxCita()

        ' cambiarrelojes()


    End Sub

    Private Sub cambiarrelojes()
        Dim dtrelojesActuales As DataTable = sqlExecute("select distinct reloj from consultas", "sermed")
        If dtrelojesActuales.Rows.Count > 0 Then
            Dim dtNuevosRelojes As DataTable = sqlExecute("select top " & dtrelojesActuales.Rows.Count & " reloj, nombres, sexo from personal order by reloj desc")
            If dtNuevosRelojes.Rows.Count > 0 Then
                For Each row As DataRow In dtNuevosRelojes.Rows
                    sqlExecute("update consultas set nombres = '" & row("nombres") & "', reloj = '" & row("reloj") & "', sexo = '" & row("sexo") & "' where reloj = '" & dtrelojesActuales.Rows(dtNuevosRelojes.Rows.IndexOf(row))("reloj") & "' ", "sermed")
                Next                
            End If
        End If
    End Sub

    Private Sub agregarProxCita()
        Dim dtConsultas As DataTable = sqlExecute("select * from consultas order by folio desc", "sermed")

        Dim r As New Random

        If dtConsultas.Rows.Count > 0 Then
            For Each row As DataRow In dtConsultas.Rows
                Dim i As Integer = r.Next(100)
                If i < 10 Then
                    Dim fecha As Date = row("fecha")
                    sqlExecute("update consultas set prox_cita = '" & FechaSQL(fecha.AddDays(i)) & "' where folio = '" & row("folio") & "'", "sermed")
                End If

            Next
        End If
    End Sub

    Private Sub cambiarfechas()
        Dim dtConsultas As DataTable = sqlExecute("select * from visitas order by folio desc", "sermed")

        If dtConsultas.Rows.Count > 0 Then

            Dim fecha As Date = Date.Now
            Dim count As Integer = 0

            For Each row As DataRow In dtConsultas.Rows
                count += 1
                If count >= 9 Then
                    fecha = fecha.AddDays(-1)
                    count = 0
                End If
                sqlExecute("update visitas set fecha = '" & FechaSQL(fecha) & "' where folio = '" & row("folio") & "'", "sermed")
            Next
        End If
    End Sub

End Class