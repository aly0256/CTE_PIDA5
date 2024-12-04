Public Class frmseleccionarano

    Private Sub frmseleccionarano_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        Dim x As Integer = Now.Year
        For i As Integer = 1 To 3
            ComboBox1.Items.Add(x - i)
        Next
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click

        Try
            anioSel = ComboBox1.SelectedItem
            If anioSel = "" Then
                MessageBox.Show("Seleccione un año por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class