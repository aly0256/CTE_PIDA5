Module Reclutamiento

    'Actualiza el estado de activo a inactivo
    'de las vacantes que ya expiraron y que aun estan activas 
    Public Sub ActualizarActivoVacante()

        sqlExecute("update Vacantes set Activo = 0 where Activo = 1 and  Vencimiento < CONVERT(date,GETDATE())", "Reclutamiento")

    End Sub



End Module
