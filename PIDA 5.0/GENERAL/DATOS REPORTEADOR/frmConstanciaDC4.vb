Public Class frmConstanciaDC4

    Private Sub frmConstanciaDC4_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmConstanciaDC4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim dtesta As DataTable = sqlExecute("select establecimiento from cias where COD_COMP = '090'")
        Dim dtesta As DataTable = sqlExecute("select establecimiento from cias where COD_COMP = '610'")

        txtClave.Text = IIf(IsDBNull(dtesta.Rows(0).Item("establecimiento")), "36648", dtesta.Rows(0).Item("establecimiento"))

        dtFechaInicial.Value = FechaInicial

        dtFechaFinal.Value = FechaFinal
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click        

        'sqlExecute("update cias set establecimiento = '" & txtClave.Text & "' where cod_comp = '090'")
        sqlExecute("update cias set establecimiento = '" & txtClave.Text & "' where cod_comp = '610'")

        FechaInicial = dtFechaInicial.Value
        FechaFinal = dtFechaFinal.Value
        strRespuesta = txtClave.Text '& "@" &
        cod_capacitacion = txtClave.Text


        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub
End Class