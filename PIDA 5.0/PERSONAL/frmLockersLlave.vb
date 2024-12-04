Public Class frmLockersLlave
    Dim dtinformacion As DataTable
    Dim dttemp As DataTable
    Dim editar As Boolean
    Dim dtusuario As DataTable

    Private Sub frmLockersLlave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostarInformacion()
        If txtLlave.Text = "" Then
            panelLockers1.Visible = True
            panelLockers2.Visible = False
            editar = True
            txtNoCandado.Focus()
            txtNoCandado.Select()

        Else
            panelLockers1.Visible = False
            panelLockers2.Visible = True
            editar = False
            txtClave.Focus()
            txtClave.Select()

        End If
    End Sub
    Private Sub MostarInformacion()
        txtClave.Text = ""
        dtinformacion = sqlExecute("select candado, llave_combinacion from lockers  where locker = '" & no_locker & "' and grupo= '" & grupo_locker & "'")

        txtNoCandado.Text = IIf(IsDBNull(dtinformacion.Rows(0)("candado")), "", RTrim(dtinformacion(0)("candado").ToString))
        txtLlave.Text = IIf(IsDBNull(dtinformacion.Rows(0)("llave_combinacion")), "", RTrim(dtinformacion(0)("llave_combinacion").ToString))

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim errorlogin As Boolean
        If editar = True Then
            Me.Close()
        Else
            dtusuario = sqlExecute("select userpass from appuser where username = '" & Usuario & "'", "seguridad")
            If dtusuario.Rows.Item(0).Item("userpass").ToString.Trim = getMD5Hash(txtClave.Text) Then
                errorlogin = False
            Else
                errorlogin = True
            End If
            If errorlogin = True Then

                MessageBox.Show("La contraseña es incorrecta, favor de verificar.", "Error en acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                sqlExecute("insert into bitacora_lockers (reloj, locker, detalle, usuario, fecha, usuario_pc, nombre_pc, grupo) " & _
                       "values ('" & Reloj & "', '" & no_locker & "', 'intento fallido pass', '" & Usuario & "', " & _
                       "'" & FechaHoraSQL(Now, True, False) & "', '" & Environment.UserName & "', '" & Environment.MachineName & "', '" & grupo_locker & "' )")
                txtClave.Text = ""
            Else
                sqlExecute("insert into bitacora_lockers (reloj, locker, candado, llave, detalle, usuario, fecha, usuario_pc, nombre_pc, grupo) " & _
                           "values ('" & Reloj & "', '" & no_locker & "','" & txtNoCandado.Text & "', '" & txtLlave.Text & "', " & _
                           "'Consulta', '" & Usuario & "', '" & FechaHoraSQL(Now, True, False) & "', '" & Environment.UserName & "', '" & Environment.MachineName & "', '" & grupo_locker & "')")

                panelLockers1.Visible = True
                panelLockers2.Visible = False
                editar = True
            End If
        End If
    End Sub
End Class