Public Module sermed_clases

    Public Sub EditaConsulta(folio As String, campo As String, valor As String)
        sqlExecute("update consultas set " & campo & " = '" & valor & "' where folio = '" & folio & "'", "sermed")
    End Sub

End Module
