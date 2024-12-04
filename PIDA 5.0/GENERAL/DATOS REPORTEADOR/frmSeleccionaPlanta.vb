Public Class frmSeleccionaPlanta
    Dim estado As Integer = 0

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Try
            estado = CInt(chkWME.CheckValue) + CInt(chkWSM.CheckValue)

            Select Case estado
                Case 0
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Case 1
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    selecPlantaRep = 0
                Case 2
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    selecPlantaRep = 1
                Case 3
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    selecPlantaRep = 2
            End Select
        Catch ex As Exception

        End Try
    End Sub


End Class