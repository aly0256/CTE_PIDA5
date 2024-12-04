Public Class frmEstilo
    Dim dtTemp As New DataTable
    Dim stEstilo As String
    Dim stColor As Integer

    Private Sub frmConfiguracion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub frmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo eRR
        Dim x As Integer
        Dim dm As Integer
        Dim dtPersonal As New DataTable
        Dim dtAños As New DataTable

        For Each s In System.Enum.GetNames(GetType(DevComponents.DotNetBar.eStyle))
            cmbEstilo.Items.Add(s)
        Next

        dtTemp = sqlExecute("SELECT estilo,color FROM appuser WHERE username = '" & Usuario & "'", "Seguridad")

        stEstilo = dtTemp.Rows.Item(0).Item("estilo").ToString.Trim
        stColor = dtTemp.Rows.Item(0).Item("color")
        clrEstilo.SelectedColor = Color.FromArgb(dtTemp.Rows.Item(0).Item("color"))
        cmbEstilo.Text = dtTemp.Rows.Item(0).Item("estilo").ToString.Trim
        btnPrevia.PerformClick()
        Exit Sub
eRR:

        Debug.Print(Err.Description)
        Resume Next
    End Sub


    Private Sub btnPrevia_Click(sender As Object, e As EventArgs) Handles btnPrevia.Click

        frmMain.stlEstiloVIsual.ManagerColorTint = clrEstilo.SelectedColor

        Dim scheme As DevComponents.DotNetBar.eStyle
        If cmbEstilo.SelectedIndex < 0 Then Exit Sub

        Dim sSel As String = cmbEstilo.SelectedItem.ToString()
        scheme = CType(System.Enum.Parse(GetType(DevComponents.DotNetBar.eStyle), sSel, False), DevComponents.DotNetBar.eStyle)
        frmMain.stlEstiloVIsual.ManagerStyle = scheme
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click

        btnPrevia.PerformClick()
        dtTemp = sqlExecute("UPDATE appuser SET estilo = '" & frmMain.stlEstiloVIsual.ManagerStyle.ToString & "', color = " & clrEstilo.SelectedColor.ToArgb & " WHERE username = '" & Usuario & "'", "Seguridad")
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        frmMain.stlEstiloVIsual.ManagerColorTint = Color.FromArgb(stColor)

        Dim scheme As DevComponents.DotNetBar.eStyle
        Dim sSel As String = stEstilo
        scheme = CType(System.Enum.Parse(GetType(DevComponents.DotNetBar.eStyle), sSel, False), DevComponents.DotNetBar.eStyle)
        frmMain.stlEstiloVIsual.ManagerStyle = scheme
        Me.Close()
    End Sub

    Private Sub cmbEstilo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstilo.SelectedIndexChanged

    End Sub
End Class