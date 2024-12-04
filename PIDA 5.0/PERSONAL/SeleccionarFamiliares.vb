Public Class SeleccionarFamiliares


    Public dtFamiliares As New DataTable
    Private Sub SeleccionarFamiliares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            AdvTree1.DataSource = dtFamiliares.Select("nombre<>''", "reloj, cod_familia, edad").CopyToDataTable
            AdvTree1.DisplayMembers = "nombre, parentesco,edad,elegible,id_familiar"
            AdvTree1.GroupingMembers = "nomreloj"

            AdvTree1.Columns(0).Width.Absolute = 300
            AdvTree1.Columns(1).Width.Absolute = 125
            AdvTree1.Columns(2).Width.Absolute = 125
            AdvTree1.Columns(3).Width.Absolute = 0
            AdvTree1.Columns(4).Width.Absolute = 0

            For Each n As DevComponents.AdvTree.Node In AdvTree1.Nodes
                For Each m As DevComponents.AdvTree.Node In n.Nodes
                   
                    If m.Cells(3).Text = "Si" Then
                        m.CheckBoxVisible = True
                        m.Checked = False
                    Else
                        m.CheckBoxVisible = False
                        m.Checked = False
                    End If

                Next
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub


    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        For Each n As DevComponents.AdvTree.Node In AdvTree1.Nodes
            If n.HasChildNodes Then
                For Each n_ As DevComponents.AdvTree.Node In n.Nodes
                    If n_.Checked = True Then
                        Try
                            Dim drFamiliar = dtFamiliares.Rows.Find(n_.Cells(4).Text)
                            drFamiliar("imprimir") = 1
                        Catch ex As Exception
                            Debug.Print(ex.Message)
                        End Try
                    End If
                Next
            End If
        Next
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub AdvTree1_Click(sender As Object, e As EventArgs) Handles AdvTree1.Click

    End Sub
End Class