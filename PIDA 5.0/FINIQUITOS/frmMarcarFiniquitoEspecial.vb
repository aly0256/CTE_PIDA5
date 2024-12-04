Public Class frmMarcarFiniquitoEspecial

    Private acepted = False

    Public Sub New(dtEmploys As DataTable, columns As Dictionary(Of String, String), Optional sizeColumn As String = Nothing)
        Call Me.InitializeComponent()
        Me.dgEmploys.DataSource = dtEmploys
        showDatagrid(Me.dgEmploys, columns, sizeColumn)
        cmbAno.DataSource = sqlExecute("SELECT * FROM (SELECT DISTINCT ano FROM periodos UNION SELECT DISTINCT ano FROM periodos_quincenal) AS T ORDER BY ano DESC;", "TA")
    End Sub

    Public Function isAcepted() As Boolean
        Return Me.acepted
    End Function

    Private Sub btnAcepta_Click(sender As Object, e As EventArgs) Handles btnAcepta.Click
        Me.acepted = True
        Me.Close()
    End Sub

    Private Sub loadPeriodo()
        Dim tabla = IIf(rbS.Checked, "periodos", "periodos_quincenal")
        cmbPeriodo.DataSource = sqlExecute("SELECT distinct periodo, convert(varchar, fecha_ini, 103) as Inicio, convert(varchar, fecha_fin, 103) as Fin FROM " & tabla & " where ano = '" & cmbAno.SelectedValue & "'", "TA")
    End Sub

    Public Function getAllOptions() As Dictionary(Of String, String)
        If Not Me.acepted Then : Return Nothing : End If
        Return New Dictionary(Of String, String) From {{"ano", Me.cmbAno.SelectedValue},
                                                        {"periodo", cmbPeriodo.SelectedValue("periodo")},
                                                        {"tipoPeriodo", IIf(rbS.Checked, "S", "Q")}}
    End Function

    Private Sub btnCancela_Click(sender As Object, e As EventArgs) Handles btnCancela.Click
        Me.acepted = False
        Me.Close()
    End Sub

    ''' <summary>
    ''' Muestra solo las columnas deseadas de un datagrid con los nombres asignados
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub showDatagrid(dg As DevComponents.DotNetBar.Controls.DataGridViewX, columns As Dictionary(Of String, String), Optional sizeColumn As String = Nothing)
        Try
            For Each item As DataGridViewColumn In dg.Columns
                If columns.Keys.Contains(item.Name) Then : dg.Columns(item.Name).HeaderCell.Value = columns(item.Name)
                Else : dg.Columns(item.Name).Visible = False : End If
            Next
            If Not sizeColumn Is Nothing Then : dg.Columns(sizeColumn).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : End If
        Catch ex As Exception : End Try
    End Sub

    Private Sub cmbAno_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cmbAno.SelectionChanged
        loadPeriodo()
    End Sub

    Private Sub rbS_CheckedChanged(sender As Object, e As EventArgs) Handles rbS.CheckedChanged
        loadPeriodo()
    End Sub
End Class