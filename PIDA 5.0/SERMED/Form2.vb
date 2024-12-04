Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = consultaDBase("select * from movimientos", "L:\pida\Nomina\data\")
    End Sub
End Class