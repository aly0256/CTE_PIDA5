Public Class frmCancelarDeducciones

    Dim dtInfo As New DataTable
    Dim strCredito = ""
    Dim strComentario = ""

    Private Sub frmCancelarDeducciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Q1 As String = "SELECT * FROM mtro_ded WHERE ID=" & MtroDedConcepto
        dtInfo = sqlExecute(Q1, "nomina")

        strComentario = If(IsDBNull(dtInfo.Rows(0).Item("comentario")), "", dtInfo.Rows(0).Item("comentario").ToString.Trim & ";")
        strCredito = If(IsDBNull(dtInfo.Rows(0).Item("credito")), "", dtInfo.Rows(0).Item("credito").ToString.Trim)

        txtClave.Text = strCredito
        txtNvaClave.Text = ""
        txtNumCancelacion.Focus()
    End Sub

    ''' <summary>
    ''' Campos para cancelar deducción
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkDefinitivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkDefinitivo.CheckedChanged
        pnlDefinitiva.Enabled = chkDefinitivo.Checked
        pnlTransferencia.Enabled = chkTransferencia.Checked
    End Sub

    ''' <summary>
    ''' Campos para cambiar las claves del registro
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkTransferencia_CheckedChanged(sender As Object, e As EventArgs) Handles chkTransferencia.CheckedChanged
        pnlDefinitiva.Enabled = chkDefinitivo.Checked
        pnlTransferencia.Enabled = chkTransferencia.Checked
    End Sub

    ''' <summary>
    ''' Aceptar modificaciones
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim Comentario As String
            Dim msj = ""
            Dim aviso = ""

            If chkDefinitivo.Checked Then msj = "¿Está seguro de cancelar el crédito o préstamo " & txtClave.Text.Trim & "?" : aviso = "Cancelación"
            If chkTransferencia.Checked Then msj = "¿Está seguro de modificar el número de crédito del registro?" : aviso = "Modificación"

            If MessageBox.Show(msj, aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If chkDefinitivo.Checked Then

                    Comentario = IIf(IsDBNull(dtInfo.Rows(0).Item("comentario")), "", dtInfo.Rows(0).Item("comentario").ToString.Trim)
                    Comentario &= IIf(Comentario.Length > 0, "; ", "") &
                                "Cancelación #" & txtNumCancelacion.Text.Trim & " por el usuario " & Usuario & " el día " & Date.Now &
                                IIf(txtMotivo.TextLength > 0, " por ", "") & txtMotivo.Text.Trim

                    If Comentario.Length > 250 Then Comentario = Comentario.Substring(0, 250)

                    'BERE
                    sqlExecute("UPDATE mtro_ded SET activo = 0,comentario = '" & Comentario & "' WHERE ID = '" & MtroDedConcepto & "'", "nomina")

                    sqlExecute("INSERT INTO saldos_ca (reloj,periodo,ano,concepto,numcredito,abono_alc,saldo_act,comentario) VALUES ('" & _
                               dtInfo.Rows(0).Item("reloj") &
                               "','99','" & dtInfo.Rows(0).Item("ini_ano") &
                               "','" & dtInfo.Rows(0).Item("concepto").ToString.Trim &
                               "','" & strCredito &
                               "'," & MtroDedSaldo & ",0," &
                               "'Monto acreditado por cancelación " & Date.Now & ". Usuario: " & Usuario & "')", "nomina")
                Else
                    'BERE
                    strComentario &= "Transferencia de la clave original " & strCredito & " por el usuario " & Usuario & " el día " & Date.Now

                    sqlExecute("UPDATE mtro_ded SET credito = '" & txtNvaClave.Text & "', comentario = '" & strComentario & "' " &
                               "WHERE credito = '" & strCredito & "'", "nomina")

                    sqlExecute("UPDATE saldos_ca SET numcredito = '" & txtNvaClave.Text & "' WHERE numcredito = '" & strCredito & "'", "nomina")
                End If

                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        Finally
            Me.Dispose()
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class