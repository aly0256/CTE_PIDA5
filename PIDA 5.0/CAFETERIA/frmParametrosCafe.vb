Public Class frmParametrosCafe

    Private Sub frmParametrosCafe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarServicios()
        CargarParametros()
        RevisaExcepciones(Me, "", True)
    End Sub
    Private Sub CargarServicios()
        Dim dtServicios As DataTable = sqlExecute("select * from servicios WHERE SERVICIO = 'DESAYUNO'", "CAFETERIA")
        If dtServicios.Rows.Count > 0 Then
            numDesPriNormal.Value = IIf(IsDBNull(dtServicios.Rows(0).Item("COSTO_PRIMERA_NORMAL")), 0, dtServicios.Rows(0).Item("COSTO_PRIMERA_NORMAL"))
            numDesRepNormal.Value = IIf(IsDBNull(dtServicios.Rows(0).Item("COSTO_REPETICION_NORMAL")), 0, dtServicios.Rows(0).Item("COSTO_REPETICION_NORMAL"))
            numDesPriExtra.Value = IIf(IsDBNull(dtServicios.Rows(0).Item("COSTO_PRIMERA_EXTRA")), 0, dtServicios.Rows(0).Item("COSTO_PRIMERA_EXTRA"))
            numDesRepExtra.Value = IIf(IsDBNull(dtServicios.Rows(0).Item("COSTO_REPETICION_EXTRA")), 0, dtServicios.Rows(0).Item("COSTO_REPETICION_EXTRA"))
        Else
            numDesPriNormal.Value = 0
            numDesRepNormal.Value = 0
            numDesPriExtra.Value = 0
            numDesRepExtra.Value = 0
        End If
        dtServicios = sqlExecute("select * from servicios WHERE SERVICIO = 'COMIDA'", "CAFETERIA")
        If dtServicios.Rows.Count > 0 Then
            numComPriNormal.Value = IIf(IsDBNull(dtServicios.Rows(0).Item("COSTO_PRIMERA_NORMAL")), 0, dtServicios.Rows(0).Item("COSTO_PRIMERA_NORMAL"))
            numComRepNormal.Value = IIf(IsDBNull(dtServicios.Rows(0).Item("COSTO_REPETICION_NORMAL")), 0, dtServicios.Rows(0).Item("COSTO_REPETICION_NORMAL"))
            numComPriExtra.Value = IIf(IsDBNull(dtServicios.Rows(0).Item("COSTO_PRIMERA_EXTRA")), 0, dtServicios.Rows(0).Item("COSTO_PRIMERA_EXTRA"))
            numComRepExtra.Value = IIf(IsDBNull(dtServicios.Rows(0).Item("COSTO_REPETICION_EXTRA")), 0, dtServicios.Rows(0).Item("COSTO_REPETICION_EXTRA"))
        Else
            numComPriNormal.Value = 0
            numComRepNormal.Value = 0
            numComPriExtra.Value = 0
            numComRepExtra.Value = 0
        End If
        dtServicios = sqlExecute("select * from servicios WHERE SERVICIO = 'CENA'", "CAFETERIA")
        If dtServicios.Rows.Count > 0 Then
            numCenPriNormal.Value = IIf(IsDBNull(dtServicios.Rows(0).Item("COSTO_PRIMERA_NORMAL")), 0, dtServicios.Rows(0).Item("COSTO_PRIMERA_NORMAL"))
            numCenRepNormal.Value = IIf(IsDBNull(dtServicios.Rows(0).Item("COSTO_REPETICION_NORMAL")), 0, dtServicios.Rows(0).Item("COSTO_REPETICION_NORMAL"))
            numCenPriExtra.Value = IIf(IsDBNull(dtServicios.Rows(0).Item("COSTO_PRIMERA_EXTRA")), 0, dtServicios.Rows(0).Item("COSTO_PRIMERA_EXTRA"))
            numCenRepExtra.Value = IIf(IsDBNull(dtServicios.Rows(0).Item("COSTO_REPETICION_EXTRA")), 0, dtServicios.Rows(0).Item("COSTO_REPETICION_EXTRA"))
        Else
            numCenPriNormal.Value = 0
            numCenRepNormal.Value = 0
            numCenPriExtra.Value = 0
            numCenRepExtra.Value = 0
        End If


    End Sub

    Private Sub numDesPriNormal_ValueChanged(sender As Object, e As EventArgs) Handles numDesPriNormal.Validating
        sqlExecute("UPDATE SERVICIOS SET COSTO_PRIMERA_NORMAL = '" + numDesPriNormal.Value.ToString + "' WHERE SERVICIO = 'DESAYUNO'", "CAFETERIA")
    End Sub

    Private Sub numDesRepNormal_ValueChanged(sender As Object, e As EventArgs) Handles numDesRepNormal.Validating
        sqlExecute("UPDATE SERVICIOS SET COSTO_REPETICION_NORMAL = '" + numDesRepNormal.Value.ToString + "' WHERE SERVICIO = 'DESAYUNO'", "CAFETERIA")
    End Sub

    Private Sub numComPriNormal_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles numComPriNormal.Validating
        sqlExecute("UPDATE SERVICIOS SET COSTO_PRIMERA_NORMAL = '" + numComPriNormal.Value.ToString + "' WHERE SERVICIO = 'COMIDA'", "CAFETERIA")
    End Sub

    Private Sub numComRepNormal_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles numComRepNormal.Validating
        sqlExecute("UPDATE SERVICIOS SET COSTO_REPETICION_NORMAL = '" + numComRepNormal.Value.ToString + "' WHERE SERVICIO = 'COMIDA'", "CAFETERIA")
    End Sub

    Private Sub numCenPriNormal_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles numCenPriNormal.Validating
        sqlExecute("UPDATE SERVICIOS SET COSTO_PRIMERA_NORMAL= '" + numCenPriNormal.Value.ToString + "' WHERE SERVICIO = 'CENA'", "CAFETERIA")
    End Sub

    Private Sub numCenRepNormal_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles numCenRepNormal.Validating
        sqlExecute("UPDATE SERVICIOS SET COSTO_REPETICION_NORMAL= '" + numCenRepNormal.Value.ToString + "' WHERE SERVICIO = 'CENA'", "CAFETERIA")
    End Sub

    Private Sub numDesPriExtra_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles numDesPriExtra.Validating
        sqlExecute("UPDATE SERVICIOS SET COSTO_PRIMERA_EXTRA= '" + numDesPriExtra.Value.ToString + "' WHERE SERVICIO = 'DESAYUNO'", "CAFETERIA")
    End Sub

    Private Sub numDesRepExtra_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles numDesRepExtra.Validating
        sqlExecute("UPDATE SERVICIOS SET COSTO_REPETICION_EXTRA= '" + numDesRepExtra.Value.ToString + "' WHERE SERVICIO = 'DESAYUNO'", "CAFETERIA")
    End Sub

    Private Sub numComPriExtra_ValueChanged(sender As Object, e As EventArgs) Handles numComPriExtra.Validating
        sqlExecute("UPDATE SERVICIOS SET COSTO_PRIMERA_EXTRA = '" + numComPriExtra.Value.ToString + "' WHERE SERVICIO = 'COMIDA'", "CAFETERIA")
    End Sub

    Private Sub numComRepExtra_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles numComRepExtra.Validating
        sqlExecute("UPDATE SERVICIOS SET COSTO_REPETICION_EXTRA = '" + numComRepExtra.Value.ToString + "' WHERE SERVICIO = 'COMIDA'", "CAFETERIA")
    End Sub

    Private Sub numCenPriExtra_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles numCenPriExtra.Validating
        sqlExecute("UPDATE SERVICIOS SET COSTO_PRIMERA_EXTRA= '" + numCenPriExtra.Value.ToString + "' WHERE SERVICIO = 'CENA'", "CAFETERIA")
    End Sub

    Private Sub numCenRepExtra_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles numCenRepExtra.Validating
        sqlExecute("UPDATE SERVICIOS SET COSTO_REPETICION_EXTRA= '" + numCenRepExtra.Value.ToString + "' WHERE SERVICIO = 'CENA'", "CAFETERIA")
    End Sub


    Private Sub btnPathServidor_Click(sender As Object, e As EventArgs) Handles btnPathServidor.Click
        Dim fbd As New System.Windows.Forms.FolderBrowserDialog
        If fbd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPathServidor.Text = fbd.SelectedPath + "\"
            sqlExecute("update parametros set PATH_FOTOS ='" + txtPathServidor.Text + "'", "CAFETERIA")
        End If
    End Sub
    Private Sub CargarParametros()
        Dim dtParametros As DataTable = sqlExecute("select path_fotos from parametros ", "CAFETERIA")
        If dtParametros.Rows.Count > 0 Then
            txtPathServidor.Text = IIf(IsDBNull(dtParametros.Rows(0).Item("PATH_FOTOS")), "", dtParametros.Rows(0).Item("PATH_FOTOS"))

        Else
            txtPathServidor.Text = ""
        End If
    End Sub

    Private Sub numComRepNormal_ValueChanged(sender As Object, e As EventArgs) Handles numComRepNormal.ValueChanged

    End Sub
End Class
