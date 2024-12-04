Public Module sermed
    Public servicio_consulta As String
    Public inicio_consulta As Date

    Public Sub EditaConsulta(folio As String, campo As String, valor As String)
        sqlExecute("update consultas set " & campo & " = '" & valor & "' where folio = '" & folio & "'", "sermed")
    End Sub

End Module
