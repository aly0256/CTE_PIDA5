Public Class frmCambiarClave

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        resCancelar = True
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim NvaClave As String
        Dim Cambio As Boolean
        Dim dtCia As DataTable
        If txtNuevaClave.Text <> txtConfirmar.Text Then
            MessageBox.Show("La clave no coincide. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNuevaClave.Focus()
            Exit Sub
        End If

        If ValidarClaveAcceso(txtNuevaClave.Text) Then
            NvaClave = getMD5Hash(txtNuevaClave.Text)
            dtTemporal = sqlExecute("SELECT userpass FROM appuser WHERE username = '" & Usuario & "'", "Seguridad")
            If dtTemporal.Rows(0).Item(0) = NvaClave Then
                MessageBox.Show("La clave no puede ser igual que la anterior. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNuevaClave.Focus()
                Exit Sub
            End If

            dtCia = sqlExecute("SELECT DIAS_EXPIRA_CLAVE FROM parametros")
            dtTemporal = sqlExecute("UPDATE appuser SET userpass = '" & NvaClave & "',fecha_expira = DATEADD(DAY," & dtCia.Rows(0).Item("DIAS_EXPIRA_CLAVE") & ",GETDATE()) WHERE username ='" & Usuario & "'", "Seguridad")
            Cambio = Not (dtTemporal Is New DataTable)
            If Cambio Then
                MessageBox.Show("El cambio se realizó exitosamente." & vbCrLf & "Le recomendamos guardar su clave en un lugar seguro.", "Cambio de clave de acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                resCancelar = False
                Me.Close()
                Me.Dispose()
            Else
                MessageBox.Show("El cambio no pudo ser realizado. Favor de verificar con el administrador.", "Cambio de clave de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("El cambio no pudo ser realizado porque la clave de acceso no cumple la validación (mínimo 15 caracteres, y que incluya al menos un número, una mayúscula, una minúscula y un caracter especial).", "Cambio de clave de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub txtNuevaClave_GotFocus(sender As Object, e As EventArgs) Handles txtNuevaClave.GotFocus
        txtNuevaClave.SelectAll()
    End Sub


    Private Sub txtConfirmar_GotFocus(sender As Object, e As EventArgs) Handles txtConfirmar.GotFocus
        txtConfirmar.SelectAll()
    End Sub

    Private Sub txtNuevaClave_TextChanged(sender As Object, e As EventArgs) Handles txtNuevaClave.TextChanged
        btnOk.Enabled = (txtNuevaClave.Text <> "") And (txtNuevaClave.Text = txtConfirmar.Text)
    End Sub

    Private Sub txtConfirmar_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmar.TextChanged
        btnOk.Enabled = (txtNuevaClave.Text <> "") And (txtNuevaClave.Text = txtConfirmar.Text)
    End Sub

    Private Sub frmCambiarClave_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.CapsLock Then
            statusMay.Visible = My.Computer.Keyboard.CapsLock
        ElseIf e.KeyCode = Keys.NumLock Then
            statusNum.Visible = My.Computer.Keyboard.NumLock
        End If
    End Sub

    Private Sub frmCambiarClave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        statusMay.Visible = My.Computer.Keyboard.CapsLock
        statusNum.Visible = My.Computer.Keyboard.NumLock
    End Sub
End Class