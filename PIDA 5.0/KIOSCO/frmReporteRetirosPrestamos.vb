Public Class frmReporteRetirosPrestamos

    Private Sub txtFechaFinal_Click(sender As Object, e As EventArgs) Handles txtFechaFinal.Click

    End Sub

    Private Sub frmReporteRetirosPrestamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFechaFinal.Value = Date.Now
        txtFechaInicio.Value = Date.Now.AddDays(-7)
        sqlExecute("SELECT id , RELOJ,NOMBRE, CONFIRMADO, exportado,FECHA_SOL as 'Fecha de Solicitud','PRÉSTAMO FONDO DE AHORRO' AS 'Grupo1' from prestamos  where confirmado = 1 and exportado = 0 union ALL SELECT id, RELOJ,NOMBRE, confirmado, exportado,FECHA_SOL as 'Fecha de Solicitud','RETIRO DE FONDO DE AHORRO' AS 'Grupo1' from retiros where confirmado = 1 and exportado = 0 union ALL SELECT id, RELOJ,solicitud, confirmado, exportado,FECHA_SOL as 'Fecha de Solicitud','DESCUENTO DE ARTICULO' AS 'Grupo1' from solicitudes where confirmado = 1 and exportado = 0 and reloj <90000", "KIOSCO")

    End Sub

    Private Sub BtnBorrar_Click(sender As Object, e As EventArgs) Handles BtnBorrar.Click
        Dim Q As String = IIf(chkPrestamos.Checked, "SELECT ID, RELOJ, NOMBRE, CONFIRMADO, EXPORTADO, FECHA_SOL, FECHA_REV, 'Préstamo' AS 'tipo' " & _
        "FROM prestamos " & _
        "WHERE (EXPORTADO = 0) and (FECHA_SOL BETWEEN '" + FechaSQL(txtFechaInicio.Value) + "' and '" + FechaSQL(txtFechaFinal.Value) + "')" & _
        IIf(chkRetiros.Checked Or chkMisc.Checked, "UNION ALL ", ""), "") & _
        IIf(chkRetiros.Checked, "SELECT ID, RELOJ, NOMBRE, CONFIRMADO, EXPORTADO, FECHA_SOL, FECHA_REV, 'Retiro' AS 'tipo' " & _
        "FROM retiros " & _
        "WHERE (EXPORTADO = 0)  and (FECHA_SOL BETWEEN '" + FechaSQL(txtFechaInicio.Value) + "' and '" + FechaSQL(txtFechaFinal.Value) + "') " & _
        IIf(chkMisc.Checked, "UNION ALL ", ""), "") & _
        IIf(chkMisc.Checked, "SELECT ID, RELOJ, SOLICITUD, CONFIRMADO, EXPORTADO, FECHA_SOL, FECHA_REV, 'Solicitud' AS 'tipo' " & _
        "FROM solicitudes " & _
        "WHERE (EXPORTADO = 0) AND (RELOJ < 90000)  and (FECHA_SOL BETWEEN '" + FechaSQL(txtFechaInicio.Value) + "' and '" + FechaSQL(txtFechaFinal.Value) + "') ", "")
        frmVistaPrevia.LlamarReporte("Resumen solicitudes rh", sqlExecute(Q, "kiosco"))
        frmVistaPrevia.ShowDialog()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class