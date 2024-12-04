Public Class frmSuplentes
    Dim dtUsuarios As New DataTable
    Dim dtUsuarios_principal As New DataTable
    Private Sub frmSuplentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'lblName.Text = "USUARIO: " & Usuario
            Dim dtDatos As New DataTable
            dtDatos = sqlExecute("SELECT suplente1,activo_suplente1,suplente2,activo_suplente2,suplente3,activo_suplente3,suplente_definido, " & _
                                 "suplente_fecha_inicio,suplente_fecha_fin FROM appuser where username = '" & Usuario & "'", "seguridad")
            chkDefinido.Checked = IIf(IsDBNull(dtDatos.Rows(0).Item("suplente_definido")), False, dtDatos.Rows(0).Item("suplente_definido"))
            chkIndefinido.Checked = Not chkDefinido.Checked

            dtFechaInicial.ValueObject = IIf(IsDBNull(dtDatos.Rows(0).Item("suplente_fecha_inicio")), Nothing, dtDatos.Rows(0).Item("suplente_fecha_inicio"))
            dtFechaFinal.ValueObject = IIf(IsDBNull(dtDatos.Rows(0).Item("suplente_fecha_fin")), Nothing, dtDatos.Rows(0).Item("suplente_fecha_fin"))

            dtUsuarios = sqlExecute("SELECT RTRIM(username) AS USUARIO,RTRIM(NOMBRE) AS NOMBRE FROM appuser", "seguridad")
            dtUsuarios.Rows.Add({"", "INDEFINIDO"})

            dtUsuarios_principal = sqlExecute("SELECT RTRIM(username) AS USUARIO,RTRIM(NOMBRE) AS NOMBRE FROM appuser", "seguridad")


            cmbUsuarioPrincipal.DataSource = dtUsuarios_principal.Copy
            cmbUsuarioPrincipal.SelectedValue = Usuario
            cmbSuplente1.DataSource = dtUsuarios.Copy
            cmbSuplente1.SelectedValue = IIf(IsDBNull(dtDatos.Rows(0).Item("suplente1")), "", dtDatos.Rows(0).Item("suplente1"))
            cmbSuplente2.DataSource = dtUsuarios.Copy
            cmbSuplente2.SelectedValue = IIf(IsDBNull(dtDatos.Rows(0).Item("suplente2")), "", dtDatos.Rows(0).Item("suplente3"))
            cmbSuplente3.DataSource = dtUsuarios.Copy
            cmbSuplente3.SelectedValue = IIf(IsDBNull(dtDatos.Rows(0).Item("suplente3")), "", dtDatos.Rows(0).Item("suplente3"))

            btnActivo1.Value = IIf(IsDBNull(dtDatos.Rows(0).Item("activo_suplente1")), False, dtDatos.Rows(0).Item("activo_suplente1"))
            btnActivo2.Value = IIf(IsDBNull(dtDatos.Rows(0).Item("activo_suplente2")), False, dtDatos.Rows(0).Item("activo_suplente2"))
            btnActivo3.Value = IIf(IsDBNull(dtDatos.Rows(0).Item("activo_suplente3")), False, dtDatos.Rows(0).Item("activo_suplente3"))

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            sqlExecute("UPDATE appuser SET suplente_definido = " & IIf(chkDefinido.Checked, 1, 0) & "," & _
                       "suplente_fecha_inicio = " & IIf(chkIndefinido.Checked, "NULL", "'" & FechaSQL(dtFechaInicial.Value) & "'") & "," & _
                       "suplente_fecha_fin = " & IIf(chkIndefinido.Checked, "NULL", "'" & FechaSQL(dtFechaFinal.Value) & "'") & "," & _
                       "suplente1 = '" & cmbSuplente1.SelectedValue & "'," & _
                       "suplente2 = '" & cmbSuplente2.SelectedValue & "'," & _
                       "suplente3 = '" & cmbSuplente3.SelectedValue & "'," & _
                       "activo_suplente1 = " & IIf(btnActivo1.Value, 1, 0) & "," & _
                       "activo_suplente2 = " & IIf(btnActivo2.Value, 1, 0) & "," & _
                       "activo_suplente3 = " & IIf(btnActivo3.Value, 1, 0) & " WHERE username = '" & cmbUsuarioPrincipal.SelectedValue & "'", "seguridad")
            'Me.Close()
            'Me.Dispose()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub

    Private Sub chkDefinido_CheckedChanged(sender As Object, e As EventArgs) Handles chkDefinido.CheckedChanged
        dtFechaFinal.Enabled = chkDefinido.Checked
        dtFechaInicial.Enabled = chkDefinido.Checked
    End Sub

 
    Private Sub cmbUsuarioPrincipal_TextChanged(sender As Object, e As EventArgs) Handles cmbUsuarioPrincipal.TextChanged
        Dim dtDatos_ As DataTable = sqlExecute("SELECT suplente1,activo_suplente1,suplente2,activo_suplente2,suplente3,activo_suplente3,suplente_definido, " & _
                              "suplente_fecha_inicio,suplente_fecha_fin FROM appuser where username = '" & cmbUsuarioPrincipal.SelectedValue & "'", "seguridad")
        chkDefinido.Checked = IIf(IsDBNull(dtDatos_.Rows(0).Item("suplente_definido")), False, dtDatos_.Rows(0).Item("suplente_definido"))
        chkIndefinido.Checked = Not chkDefinido.Checked

        dtFechaInicial.ValueObject = IIf(IsDBNull(dtDatos_.Rows(0).Item("suplente_fecha_inicio")), Nothing, dtDatos_.Rows(0).Item("suplente_fecha_inicio"))
        dtFechaFinal.ValueObject = IIf(IsDBNull(dtDatos_.Rows(0).Item("suplente_fecha_fin")), Nothing, dtDatos_.Rows(0).Item("suplente_fecha_fin"))



        cmbSuplente1.SelectedValue = IIf(IsDBNull(dtDatos_.Rows(0).Item("suplente1")), "", dtDatos_.Rows(0).Item("suplente1"))

        cmbSuplente2.SelectedValue = IIf(IsDBNull(dtDatos_.Rows(0).Item("suplente2")), "", dtDatos_.Rows(0).Item("suplente3"))

        cmbSuplente3.SelectedValue = IIf(IsDBNull(dtDatos_.Rows(0).Item("suplente3")), "", dtDatos_.Rows(0).Item("suplente3"))

        btnActivo1.Value = IIf(IsDBNull(dtDatos_.Rows(0).Item("activo_suplente1")), False, dtDatos_.Rows(0).Item("activo_suplente1"))
        btnActivo2.Value = IIf(IsDBNull(dtDatos_.Rows(0).Item("activo_suplente2")), False, dtDatos_.Rows(0).Item("activo_suplente2"))
        btnActivo3.Value = IIf(IsDBNull(dtDatos_.Rows(0).Item("activo_suplente3")), False, dtDatos_.Rows(0).Item("activo_suplente3"))
    End Sub
End Class