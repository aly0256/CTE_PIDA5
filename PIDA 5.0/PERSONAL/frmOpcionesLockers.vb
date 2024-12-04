Public Class frmOpcionesLockers
    Dim dtregistros As New DataTable
    Dim dtinformacion As DataTable
    Dim status As String
    Dim dttemp As DataTable
    Dim dttempllave As DataTable
    Dim editar As Boolean
    Dim dtusuario As DataTable
    Dim valAnt As String
    Dim baja As String
    Dim nombres As String
    Dim locker As String
    Dim candado As String


    Private Sub frmOpcionesLockers_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        dtregistros = sqlExecute("select * from lockers where locker = '" & no_locker & "' and grupo = '" & grupo_locker & "'")
        status = IIf(IsDBNull(dtregistros.Rows(0)("status")), "", RTrim(dtregistros(0)("status")))


        MostrarInformacion()
        txtReloj.Text = Reloj
        txtDetalle.Text = ""
        If status = "0" Or status = "2" Then

            tabLockers.SelectedTab = tabAsignar
        ElseIf status = "1" Then

            tabLockers.SelectedTab = tabLiberar
        End If
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
    Private Sub MostrarInformacion()
        If Reloj <> "CANCEL" Then
            txtReloj.Text = Reloj
        End If
        txtClave.Text = ""
        dtinformacion = sqlExecute("select candado, llave_combinacion from lockers  where locker = '" & no_locker & "' and grupo = '" & grupo_locker & "'")

        txtNoCandado.Text = IIf(IsDBNull(dtinformacion.Rows(0)("candado")), "", RTrim(dtinformacion(0)("candado").ToString))
        txtLlave.Text = IIf(IsDBNull(dtinformacion.Rows(0)("llave_combinacion")), "", RTrim(dtinformacion(0)("llave_combinacion").ToString))

    End Sub

    Private Sub btnVerBuscar_Click(sender As Object, e As EventArgs) Handles btnVerBuscar.Click

        frmBuscar.ShowDialog(Me)
        MostrarInformacion()

    End Sub

    Private Sub txtClave_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtClave.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            Dim errorlogin As Boolean
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
                sqlExecute("insert into bitacora_lockers (reloj, locker, candado, llave, detalle, usuario, fecha, usuario_pc, nombre_pc) " & _
                           "values ('" & Reloj & "', '" & no_locker & "','" & txtNoCandado.Text & "', '" & txtLlave.Text & "', " & _
                           "'Consulta', '" & Usuario & "', '" & FechaHoraSQL(Now, True, False) & "', '" & Environment.UserName & "', '" & Environment.MachineName & "', '" & grupo_locker & "')")

                panelLockers1.Visible = True
                panelLockers2.Visible = False
                editar = True
            End If
            End If
    End Sub

    Private Sub btnAceptAsignar_Click(sender As Object, e As EventArgs) Handles btnAceptAsignar.Click
        If MessageBox.Show("Estas por asignar el locker No. " & no_locker & " al empleado '" & txtReloj.Text & "'. Estas seguro que deseas continuar?", "Asignar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            '********** VALIDAR RELOJ *********
            If txtReloj.Text <> "" Then

                dttemp = sqlExecute("select baja, nombres from personalVW where reloj = '" & txtReloj.Text & "'")
                If dttemp.Rows.Count > 0 Then

                    baja = IIf(IsDBNull(dttemp.Rows(0)("baja")), "", RTrim(dttemp(0)("baja").ToString))
                    nombres = IIf(IsDBNull(dttemp.Rows(0)("nombres")), "", RTrim(dttemp(0)("nombres").ToString))
                    dttemp = sqlExecute("select locker from lockers where reloj = '" & txtReloj.Text & "' and grupo = '" & grupo_locker & "'")
                    dttempllave = sqlExecute("select locker, candado from lockers where candado = '" & txtNoCandado.Text & "' and grupo = '" & grupo_locker & "' ")

                    '*********** VALIDAR LOCKER ************
                    If dttemp.Rows.Count <> 0 Then

                        locker = IIf(IsDBNull(dttemp.Rows(0)("locker")), "", RTrim(dttemp(0)("locker").ToString))
                        If locker = no_locker Then
                            update_lockers()
                        Else
                            MessageBox.Show("Este empleado ya cuenta con el locker " & locker & " asignado. No es posible asignar mas de un locker ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If

                        '*********** VALIDAR CANDADO **********
                    ElseIf dttempllave.Rows.Count <> 0 Then
                        locker = IIf(IsDBNull(dttempllave.Rows(0)("locker")), "", RTrim(dttempllave(0)("locker").ToString))
                        candado = IIf(IsDBNull(dttempllave.Rows(0)("candado")), "", RTrim(dttempllave(0)("candado").ToString))

                        If candado = txtNoCandado.Text And no_locker <> locker Then
                            MessageBox.Show("El candado " & candado & " ya se encuentra asignado al locker " & locker & ". Favor de verificar el numero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        Else
                            update_lockers()


                        End If
                    Else
                        update_lockers()
                    End If
                Else
                    MessageBox.Show("El numero de reloj introducido no es valido o no se encuentra dado de alta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("El campo de número de reloj no puede estar vacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub
    Private Sub update_lockers()
        '********** VALIDAR BAJA **********
        If baja <> "" Then

            MessageBox.Show("No se puede asignar locker a personal inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            '************* UPDATE TABLA LOCKERS *********
            
            If txtNoCandado.Text <> "" And txtLlave.Text <> "" Then
                sqlExecute("insert into bitacora_lockers (reloj, locker, candado, llave, detalle, usuario, fecha, usuario_pc, nombre_pc, grupo) " & _
                            "values ('" & Reloj & "', '" & no_locker & "','" & txtNoCandado.Text & "', '" & txtLlave.Text & "', " & _
                            "'Asginado_Reasignado', '" & Usuario & "', '" & FechaHoraSQL(Now, True, False) & "', '" & Environment.UserName & "', '" & Environment.MachineName & "', '" & grupo_locker & "')")
                sqlExecute("update lockers set status = '1', reloj = '" & txtReloj.Text & "', detalle = '" & nombres & "', " & _
                           "candado= '" & txtNoCandado.Text & "', llave_combinacion= '" & txtLlave.Text & "' " & _
                           "where locker = '" & no_locker & "' and grupo = '" & grupo_locker & "'")
                Me.Close()
            Else
                MessageBox.Show("Ingrese todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If
    End Sub
    Private Sub btnAceptarLiberar_Click(sender As Object, e As EventArgs) Handles btnAceptarLiberar.Click
        If MessageBox.Show("Estas por liberar el locker No. " & no_locker & ". Estas seguro que deseas continuar?", "Asignar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            sqlExecute("update lockers set status = '0', reloj = '', llave_combinacion = '', candado = '', detalle = '' " & _
                       "where locker = '" & no_locker & "' and grupo='" & grupo_locker & "'")
            Me.Close()
        End If
    End Sub

    Private Sub btnAceptarBaja_Click(sender As Object, e As EventArgs) Handles btnAceptarBaja.Click
        If MessageBox.Show("Estas por cancelar el locker No. " & no_locker & ". Estas seguro que deseas continuar?", "Asignar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            sqlExecute("update lockers set status = '2', reloj = '', llave_combinacion = '', candado = '', detalle = '" & txtDetalle.Text & "' " & _
                       "where locker = '" & no_locker & "' and grupo = '" & grupo_locker & "'")
            Me.Close()
        End If
    End Sub

    Private Sub txtNoCandado_TextChanged(sender As Object, e As EventArgs) Handles txtNoCandado.TextChanged
        dttemp = sqlExecute("select top 1 llave from bitacora_lockers where CANDADO in('" & txtNoCandado.Text & "') and grupo = '" & grupo_locker & "' order by fecha DESC ")
        If dttemp.Rows.Count > 0 And txtNoCandado.Text <> "" Then
            txtLlave.Text = IIf(IsDBNull(dttemp.Rows(0)("llave")), "", RTrim(dttemp(0)("llave").ToString))
        Else
            txtLlave.Text = ""
        End If
    End Sub

    Private Sub picVer_Click(sender As Object, e As EventArgs) Handles picVer.Click
        txtLlave.PasswordChar = ""
    End Sub

    Private Sub picVer_MouseLeave(sender As Object, e As EventArgs) Handles picVer.MouseLeave
        txtLlave.PasswordChar = "*"
    End Sub
End Class