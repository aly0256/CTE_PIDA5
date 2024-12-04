Public Class frmAño
    Dim dtAño As New DataTable
    Private Sub frmAño_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '//******************************  Definir Tabla de Años y Llenado  *******************

            dtAño.Columns.Add("NUM_AÑO")

            dtAño.Rows.Add(Format(Now(), "yyyy"))
            dtAño.Rows.Add(Format(Now(), "yyyy") - 1)
            dtAño.Rows.Add(Format(Now(), "yyyy") - 2)
            dtAño.Rows.Add(Format(Now(), "yyyy") - 3)
            dtAño.Rows.Add(Format(Now(), "yyyy") - 4)
            dtAño.Rows.Add(Format(Now(), "yyyy") - 5)
            dtAño.Rows.Add(Format(Now(), "yyyy") - 6)
            dtAño.Rows.Add(Format(Now(), "yyyy") - 7)
            dtAño.Rows.Add({Format(Now(), "yyyy") - 8})
            dtAño.Rows.Add({Format(Now(), "yyyy") - 9})

            dtAño.PrimaryKey = New DataColumn() {dtAño.Columns("NUM_AÑO")}

            cmbAño.DataSource = dtAño

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        drAño = Nothing
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        drAño = cmbAño.SelectedValue
        Me.Close()
        Me.Dispose()
    End Sub
End Class