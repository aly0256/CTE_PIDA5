Public Class frmColaboradores
    Dim dtrelojes As DataTable

    Private Sub frmColaboradores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'listarelojes = ""
        'totalcolaboradores = 0
        txtBusqueda.Text = ""
        dtrelojes = sqlExecute("select top (50) reloj, nombres from personalvw where baja is null and reloj not in ('" & relojidea & "')")
        ListAgregar.Items.Clear()
        MostrarInformacion()

    End Sub
    Private Sub MostrarInformacion()
        ListBusqueda.Items.Clear()

        For Each dr As DataRow In dtrelojes.Select("", "reloj")
            ListBusqueda.Items.Add(dr("reloj") & " - " & dr("nombres"))
        Next
        If listarelojes <> "" Then
            Dim dttemp As DataTable = sqlExecute("select reloj, nombres from personalvw where reloj in (" & listarelojes & ")")
            If dttemp.Rows.Count > 0 Then
                totalcolaboradores = 0
                ListAgregar.Items.Clear()
                For Each dr As DataRow In dttemp.Select("", "reloj")
                    ListAgregar.Items.Add(dr("reloj") & " - " & dr("nombres"))
                    totalcolaboradores += 1
                Next
            End If
        End If

    End Sub
    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        dtrelojes = sqlExecute("select top (50) reloj, nombres from personalvw where baja is null and reloj not in('" & relojidea & "') and (reloj like '%" & txtBusqueda.Text & "%' or nombres like '%" & txtBusqueda.Text & "%' or reloj_alt like '%" & txtBusqueda.Text & "%')")
        MostrarInformacion()
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        If ListBusqueda.SelectedItems.Count > 0 Then
            If ListAgregar.FindString(ListBusqueda.SelectedItem.ToString) > -1 Then
                MessageBox.Show("Este empleado ya se encuentra agregado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                ListAgregar.Items.Add(ListBusqueda.SelectedItem.ToString)
            End If
        Else
            MessageBox.Show("Primero seleccione un colaborador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        ListAgregar.Items.Remove(ListAgregar.SelectedItem)
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        ListAgregar.Items.Clear()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        listarelojes = ""
        If ListAgregar.Items.Count > 0 Then
            totalcolaboradores = 0
            For i As Integer = 0 To ListAgregar.Items.Count - 1
                Dim separar As String() = ListAgregar.Items(i).ToString.Split("-")
                If i < ListAgregar.Items.Count - 1 Then
                    listarelojes += separar(0).Trim & ", "
                Else
                    listarelojes += separar(0)
                End If
                totalcolaboradores = totalcolaboradores + 1
            Next
        Else
            totalcolaboradores = 0
        End If

        Dim result As Integer = MessageBox.Show("Se agregaran colaboradores a la idea que estas por capturar, deseas continuar?", "Atención", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            listarelojes = ""
            'totalcolaboradores = 1
            Me.Close()
        ElseIf result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
            Me.Close()
        End If

    End Sub
End Class