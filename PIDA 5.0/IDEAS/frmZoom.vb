Public Class frmZoom
    Dim FiltroImagenes As String = "Todos los archivos de imagen|*.png;*.bmp;*.jpg,*.gif|Archivos PNG (*.png)|*.png|Archivos Bitmap (*.bmp)|*.bmp|" & _
        "Archivos JPEG (*.jpg)|*.jpg|Archivos GIF (*.gif)|*.gif|Todos los archivos (*.*)|*.*"
    Private Sub frmZoom_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmZoom_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click
        Clipboard.Clear()
        Clipboard.SetImage(picImagen.Image)
    End Sub

    Private Sub GuardarComoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarComoToolStripMenuItem.Click
        Dim Archivo As String
        Dim i As Integer
        Try
            Archivo = picImagen.ImageLocation
            i = Archivo.LastIndexOf("\")
            If i < 0 Then
                MessageBox.Show("El archivo no puede ser guardado. Si el error persiste, contacte al administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            sveDialog.FileName = Archivo.Substring(i + 1)
            sveDialog.Filter = FiltroImagenes
            If sveDialog.ShowDialog <> DialogResult.Cancel Then
                FileCopy(Archivo, sveDialog.FileName)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub frmZoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub picImagen_Click(sender As Object, e As EventArgs) Handles picImagen.Click

    End Sub
End Class