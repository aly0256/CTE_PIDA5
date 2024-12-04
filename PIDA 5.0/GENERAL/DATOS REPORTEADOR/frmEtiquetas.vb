Public Class frmEtiquetas
    Friend MAXIMO_ETIQUETAS As Integer = 20
    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        chkLn1.Checked = chkTodos.Checked And chkLn1.Enabled
        chkLn2.Checked = chkTodos.Checked And chkLn2.Enabled
        chkLn3.Checked = chkTodos.Checked And chkLn3.Enabled
        chkLn4.Checked = chkTodos.Checked And chkLn4.Enabled
        chkLn5.Checked = chkTodos.Checked And chkLn5.Enabled
        chkLn6.Checked = chkTodos.Checked And chkLn6.Enabled
        chkLn7.Checked = chkTodos.Checked And chkLn7.Enabled
        chkLn8.Checked = chkTodos.Checked And chkLn8.Enabled
        chkLn9.Checked = chkTodos.Checked And chkLn9.Enabled
        chkLn10.Checked = chkTodos.Checked And chkLn10.Enabled
        chkLn11.Checked = chkTodos.Checked And chkLn11.Enabled
        chkLn12.Checked = chkTodos.Checked And chkLn12.Enabled
        chkLn13.Checked = chkTodos.Checked And chkLn13.Enabled
        chkLn14.Checked = chkTodos.Checked And chkLn14.Enabled
        chkLn15.Checked = chkTodos.Checked And chkLn15.Enabled
        chkLn1B.Checked = chkTodos.Checked And chkLn1B.Enabled
        chkLn2B.Checked = chkTodos.Checked And chkLn2B.Enabled
        chkLn3B.Checked = chkTodos.Checked And chkLn3B.Enabled
        chkLn4B.Checked = chkTodos.Checked And chkLn4B.Enabled
        chkLn5B.Checked = chkTodos.Checked And chkLn5B.Enabled
        chkLn6B.Checked = chkTodos.Checked And chkLn6B.Enabled
        chkLn7B.Checked = chkTodos.Checked And chkLn7B.Enabled
        chkLn8B.Checked = chkTodos.Checked And chkLn8B.Enabled
        chkLn9B.Checked = chkTodos.Checked And chkLn9B.Enabled
        chkLn10B.Checked = chkTodos.Checked And chkLn10B.Enabled
        chkLn11B.Checked = chkTodos.Checked And chkLn11B.Enabled
        chkLn12B.Checked = chkTodos.Checked And chkLn12B.Enabled
        chkLn13B.Checked = chkTodos.Checked And chkLn13B.Enabled
        chkLn14B.Checked = chkTodos.Checked And chkLn14B.Enabled
        chkLn15B.Checked = chkTodos.Checked And chkLn15B.Enabled
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
    
        EtiquetasDisponibles(0) = IIf(chkLn1.Checked, 1, 0)
        EtiquetasDisponibles(2) = IIf(chkLn2.Checked, 1, 0)
        EtiquetasDisponibles(4) = IIf(chkLn3.Checked, 1, 0)
        EtiquetasDisponibles(6) = IIf(chkLn4.Checked, 1, 0)
        EtiquetasDisponibles(8) = IIf(chkLn5.Checked, 1, 0)
        EtiquetasDisponibles(10) = IIf(chkLn6.Checked, 1, 0)
        EtiquetasDisponibles(12) = IIf(chkLn7.Checked, 1, 0)
        EtiquetasDisponibles(14) = IIf(chkLn8.Checked, 1, 0)
        EtiquetasDisponibles(16) = IIf(chkLn9.Checked, 1, 0)
        EtiquetasDisponibles(18) = IIf(chkLn10.Checked, 1, 0)
        EtiquetasDisponibles(20) = IIf(chkLn11.Checked, 1, 0)
        EtiquetasDisponibles(22) = IIf(chkLn12.Checked, 1, 0)
        EtiquetasDisponibles(24) = IIf(chkLn13.Checked, 1, 0)
        EtiquetasDisponibles(26) = IIf(chkLn14.Checked, 1, 0)
        EtiquetasDisponibles(28) = IIf(chkLn15.Checked, 1, 0)
        EtiquetasDisponibles(1) = IIf(chkLn1B.Checked, 1, 0)
        EtiquetasDisponibles(3) = IIf(chkLn2B.Checked, 1, 0)
        EtiquetasDisponibles(5) = IIf(chkLn3B.Checked, 1, 0)
        EtiquetasDisponibles(7) = IIf(chkLn4B.Checked, 1, 0)
        EtiquetasDisponibles(9) = IIf(chkLn5B.Checked, 1, 0)
        EtiquetasDisponibles(11) = IIf(chkLn6B.Checked, 1, 0)
        EtiquetasDisponibles(13) = IIf(chkLn7B.Checked, 1, 0)
        EtiquetasDisponibles(15) = IIf(chkLn8B.Checked, 1, 0)
        EtiquetasDisponibles(17) = IIf(chkLn9B.Checked, 1, 0)
        EtiquetasDisponibles(19) = IIf(chkLn10B.Checked, 1, 0)
        EtiquetasDisponibles(21) = IIf(chkLn11B.Checked, 1, 0)
        EtiquetasDisponibles(23) = IIf(chkLn12B.Checked, 1, 0)
        EtiquetasDisponibles(25) = IIf(chkLn13B.Checked, 1, 0)
        EtiquetasDisponibles(27) = IIf(chkLn14B.Checked, 1, 0)
        EtiquetasDisponibles(29) = IIf(chkLn15B.Checked, 1, 0)


        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmEtiquetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HabilitaCheck()
    End Sub
    Private Sub HabilitaCheck()
        chkLn1.Enabled = IIf(MAXIMO_ETIQUETAS >= 1, True, False)
        chkLn2.Enabled = IIf(MAXIMO_ETIQUETAS >= 3, True, False)
        chkLn3.Enabled = IIf(MAXIMO_ETIQUETAS >= 5, True, False)
        chkLn4.Enabled = IIf(MAXIMO_ETIQUETAS >= 7, True, False)
        chkLn5.Enabled = IIf(MAXIMO_ETIQUETAS >= 9, True, False)
        chkLn6.Enabled = IIf(MAXIMO_ETIQUETAS >= 11, True, False)
        chkLn7.Enabled = IIf(MAXIMO_ETIQUETAS >= 13, True, False)
        chkLn8.Enabled = IIf(MAXIMO_ETIQUETAS >= 15, True, False)
        chkLn9.Enabled = IIf(MAXIMO_ETIQUETAS >= 17, True, False)
        chkLn10.Enabled = IIf(MAXIMO_ETIQUETAS >= 19, True, False)
        chkLn11.Enabled = IIf(MAXIMO_ETIQUETAS >= 21, True, False)
        chkLn12.Enabled = IIf(MAXIMO_ETIQUETAS >= 23, True, False)
        chkLn13.Enabled = IIf(MAXIMO_ETIQUETAS >= 25, True, False)
        chkLn14.Enabled = IIf(MAXIMO_ETIQUETAS >= 27, True, False)
        chkLn15.Enabled = IIf(MAXIMO_ETIQUETAS >= 29, True, False)
        chkLn1B.Enabled = IIf(MAXIMO_ETIQUETAS >= 2, True, False)
        chkLn2B.Enabled = IIf(MAXIMO_ETIQUETAS >= 4, True, False)
        chkLn3B.Enabled = IIf(MAXIMO_ETIQUETAS >= 6, True, False)
        chkLn4B.Enabled = IIf(MAXIMO_ETIQUETAS >= 8, True, False)
        chkLn5B.Enabled = IIf(MAXIMO_ETIQUETAS >= 10, True, False)
        chkLn6B.Enabled = IIf(MAXIMO_ETIQUETAS >= 12, True, False)
        chkLn7B.Enabled = IIf(MAXIMO_ETIQUETAS >= 14, True, False)
        chkLn8B.Enabled = IIf(MAXIMO_ETIQUETAS >= 16, True, False)
        chkLn9B.Enabled = IIf(MAXIMO_ETIQUETAS >= 18, True, False)
        chkLn10B.Enabled = IIf(MAXIMO_ETIQUETAS >= 20, True, False)
        chkLn11B.Enabled = IIf(MAXIMO_ETIQUETAS >= 22, True, False)
        chkLn12B.Enabled = IIf(MAXIMO_ETIQUETAS >= 24, True, False)
        chkLn13B.Enabled = IIf(MAXIMO_ETIQUETAS >= 26, True, False)
        chkLn14B.Enabled = IIf(MAXIMO_ETIQUETAS >= 28, True, False)
        chkLn15B.Enabled = IIf(MAXIMO_ETIQUETAS >= 30, True, False)
        chkLn1.Checked = IIf(MAXIMO_ETIQUETAS >= 1, True, False)
        chkLn2.Checked = IIf(MAXIMO_ETIQUETAS >= 3, True, False)
        chkLn3.Checked = IIf(MAXIMO_ETIQUETAS >= 5, True, False)
        chkLn4.Checked = IIf(MAXIMO_ETIQUETAS >= 7, True, False)
        chkLn5.Checked = IIf(MAXIMO_ETIQUETAS >= 9, True, False)
        chkLn6.Checked = IIf(MAXIMO_ETIQUETAS >= 11, True, False)
        chkLn7.Checked = IIf(MAXIMO_ETIQUETAS >= 13, True, False)
        chkLn8.Checked = IIf(MAXIMO_ETIQUETAS >= 15, True, False)
        chkLn9.Checked = IIf(MAXIMO_ETIQUETAS >= 17, True, False)
        chkLn10.Checked = IIf(MAXIMO_ETIQUETAS >= 19, True, False)
        chkLn11.Checked = IIf(MAXIMO_ETIQUETAS >= 21, True, False)
        chkLn12.Checked = IIf(MAXIMO_ETIQUETAS >= 23, True, False)
        chkLn13.Checked = IIf(MAXIMO_ETIQUETAS >= 25, True, False)
        chkLn14.Checked = IIf(MAXIMO_ETIQUETAS >= 27, True, False)
        chkLn15.Checked = IIf(MAXIMO_ETIQUETAS >= 29, True, False)
        chkLn1B.Checked = IIf(MAXIMO_ETIQUETAS >= 2, True, False)
        chkLn2B.Checked = IIf(MAXIMO_ETIQUETAS >= 4, True, False)
        chkLn3B.Checked = IIf(MAXIMO_ETIQUETAS >= 6, True, False)
        chkLn4B.Checked = IIf(MAXIMO_ETIQUETAS >= 8, True, False)
        chkLn5B.Checked = IIf(MAXIMO_ETIQUETAS >= 10, True, False)
        chkLn6B.Checked = IIf(MAXIMO_ETIQUETAS >= 12, True, False)
        chkLn7B.Checked = IIf(MAXIMO_ETIQUETAS >= 14, True, False)
        chkLn8B.Checked = IIf(MAXIMO_ETIQUETAS >= 16, True, False)
        chkLn9B.Checked = IIf(MAXIMO_ETIQUETAS >= 18, True, False)
        chkLn10B.Checked = IIf(MAXIMO_ETIQUETAS >= 20, True, False)
        chkLn11B.Checked = IIf(MAXIMO_ETIQUETAS >= 22, True, False)
        chkLn12B.Checked = IIf(MAXIMO_ETIQUETAS >= 24, True, False)
        chkLn13B.Checked = IIf(MAXIMO_ETIQUETAS >= 26, True, False)
        chkLn14B.Checked = IIf(MAXIMO_ETIQUETAS >= 28, True, False)
        chkLn15B.Checked = IIf(MAXIMO_ETIQUETAS >= 30, True, False)



    End Sub
End Class