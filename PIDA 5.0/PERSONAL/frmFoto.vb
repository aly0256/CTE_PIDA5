Public Class frmFoto

    Private Sub frmFoto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmFoto_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub CopiarImagenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarImagenToolStripMenuItem.Click
        Clipboard.SetImage(picFoto.Image)
    End Sub

    Private Sub GuardarImagenComoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarImagenComoToolStripMenuItem.Click


        Dim Archivo As String = ""
        Dim Foto As String = ""
        Try
            dlgGuardarFoto.Filter = "JPEG files (*.jpg)|*.jpg| All Files|*.*"
            Dim lDialogResult As DialogResult = dlgGuardarFoto.ShowDialog()

            If lDialogResult = Windows.Forms.DialogResult.Cancel Then
                'Si seleccionan "CANCEL", salir del procedimiento
                Exit Sub
            Else
                Archivo = dlgGuardarFoto.FileName
            End If
            picFoto.Image.Save(Archivo)
        Catch ex As Exception
            MessageBox.Show("Se detectó un error. La imagen no pudo ser guardada como  " & Archivo & "." & vbCrLf & ex.Message, "Cargar fotografía", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub picFoto_MouseDown(sender As Object, e As MouseEventArgs) Handles picFoto.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            mnuImagen.Show(CType(sender, Control), e.Location)
        End If
    End Sub
End Class