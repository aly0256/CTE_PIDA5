Public Class frmAgregarNivelSintomas

    Public id_parent As String = ""
    Public cod_sin As String = ""
    Public editar As Boolean = False
    Public label As String = ""

    Private Sub frmAgregarNivelSintomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If editar = False Then
            Label1.Text = "Agregar nivel a " & label
            TextBox1.Focus()
        Else
            Text = "Editar síntoma"
            Label1.Text = "Editar síntoma"
            Dim dtSintoma As DataTable = sqlExecute("select rtrim(nombre) as nombre from arbol_sintomas where cod_sin = '" & cod_sin & "'", "sermed")
            If dtSintoma.Rows.Count > 0 Then
                TextBox1.Text = dtSintoma.Rows(0)("nombre")
                TextBox1.SelectAll()
                TextBox1.Focus()
            Else
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End If
        End If        
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Try
            If editar = False Then
                sqlExecute("insert into arbol_sintomas (nombre, parent) values ('" & TextBox1.Text & "', '" & id_parent & "')", "sermed")

                Dim dtParent As DataTable = sqlExecute("select cod_sin, rtrim(isnull(imagen, '')) as imagen from arbol_sintomas where cod_sin = '" & id_parent & "'", "sermed")
                If dtParent.Rows.Count > 0 Then
                    Dim imagen As String = RTrim(dtParent.Rows(0)("imagen"))
                    Dim dtHijos As DataTable = sqlExecute("select cod_sin, rtrim(isnull(imagen, '')) as imagen from arbol_sintomas where parent = '" & id_parent & "'", "sermed")
                    For Each row As DataRow In dtHijos.Rows
                        Dim actual As String = RTrim(row("imagen"))
                        If actual = "" Then
                            sqlExecute("update arbol_sintomas set imagen = '" & imagen & "' where cod_sin = '" & row("cod_sin") & "'", "sermed")
                        End If
                    Next
                End If
            Else
                sqlExecute("update arbol_sintomas set nombre = '" & TextBox1.Text & "' where cod_sin = '" & cod_sin & "'", "sermed")
            End If
            

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                ButtonX1.PerformClick()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class