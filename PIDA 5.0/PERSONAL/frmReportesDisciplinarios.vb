Public Class frmReportesDisciplinarios

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If chckGeneral.Checked = True Then
            DisciplinarioGeneral = True
            Me.Close()


        ElseIf chckIndividual.Checked = True Then
            DisciplinarioIndividual = True
            Me.Close()
        ElseIf chkPDF.Checked = True Then
            DisciplinarioPDF = True
            Me.Close()
        Else
            MessageBox.Show("Seleccione un tipo de reporte", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub chckIndividual_CheckedChanged(sender As Object, e As EventArgs) Handles chckIndividual.CheckedChanged
        If chckIndividual.Checked = True Then
            chckGeneral.Checked = False
            chkPDF.Checked = False
        End If


    End Sub

    Private Sub chckGeneral_CheckedChanged(sender As Object, e As EventArgs) Handles chckGeneral.CheckedChanged
        If chckGeneral.Checked = True Then
            chckIndividual.Checked = False
            chkPDF.Checked = False
        End If


    End Sub

    Private Sub frmReportesDisciplinarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub chkPDF_CheckedChanged(sender As Object, e As EventArgs) Handles chkPDF.CheckedChanged
        If chkPDF.Checked = True Then
            chckGeneral.Checked = False
            chckIndividual.Checked = False
        End If
    End Sub
End Class