Public Class frmLockers
    Dim dtRegistros As New DataTable
    Dim dtgrupos As DataTable
    Dim dtstatus As DataTable
    Dim qwery As String
    Dim grupo As String
    Dim status As String
    Dim cadena_buscar As String


    Private Sub frmLockers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtgrupos = sqlExecute("select * from grupos_lockers")
        cmbGrupos.DataSource = dtgrupos
        cmbStatus.Text = "Todos"
        cmbStatus.Items.Add("Todos")
        cmbStatus.Items.Add("Disponibles")
        cmbStatus.Items.Add("Asignados")
        cmbStatus.Items.Add("Cancelados")
        cmbStatus.Items.Add("Bajas asignados")
        status = "where grupo= '" & cmbGrupos.SelectedValue.ToString & "'"
        MostrarInformacion(status)
    End Sub
    Private Sub MostrarInformacion(Optional ByVal status As String = "")
        qwery = "SELECT lockers.locker, lockers.candado, lockers.status, " & _
               "lockers.RELOJ, lockers.detalle FROM lockers " & status & "  ORDER BY locker ASC"
        dtRegistros = sqlExecute(qwery)
        dgLockers.DataSource = dtRegistros



    End Sub

    Private Sub dgLockers_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgLockers.CellFormatting
        If Me.dgLockers.Columns(e.ColumnIndex).Name = "c_estatus" Then
            If CDbl(Me.dgLockers.Rows(e.RowIndex).Cells("c_status").Value) = "0" Then
                e.Value = New Bitmap(My.Resources.l_disponible)
            ElseIf CDbl(Me.dgLockers.Rows(e.RowIndex).Cells("c_status").Value) = "1" Then
                e.Value = New Bitmap(My.Resources.l_ocupado)
            ElseIf CDbl(Me.dgLockers.Rows(e.RowIndex).Cells("c_status").Value) = "2" Then
                e.Value = New Bitmap(My.Resources.l_cancelado)
            End If
        End If
        If Me.dgLockers.Columns(e.ColumnIndex).Name = "c_detalle" Then
            If CDbl(Me.dgLockers.Rows(e.RowIndex).Cells("c_status").Value) = "0" Then
                e.Value = "Disponible"
            End If
        End If
    End Sub

    Private Sub dgLockers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLockers.CellDoubleClick
        If e.ColumnIndex = 0 Then
            no_locker = dgLockers.Item("c_locker", dgLockers.CurrentRow.Index).Value.ToString.Trim()
            Reloj = dgLockers.Item("c_reloj", dgLockers.CurrentRow.Index).Value.ToString.Trim()
            grupo_locker = cmbGrupos.SelectedValue
            frmOpcionesLockers.ShowDialog()
            cambio_status()
            MostrarInformacion(status)

        End If
    End Sub

    Private Sub cmbGrupos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbGrupos.SelectedValueChanged
        If cmbGrupos.Text.Length > 0 Then
            grupo = "and grupo = '" & cmbGrupos.SelectedValue.ToString & "'"
            cambio_status()

        End If
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        cambio_status()

    End Sub

    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        If txtBusqueda.Text <> "" Then
            cadena_buscar = " and locker like '%" & txtBusqueda.Text & "%' or  CANDADO like '%" & txtBusqueda.Text & "%' or reloj like '%" & txtBusqueda.Text & "%' or DETALLE like '%" & txtBusqueda.Text & "%' "
        Else
            cadena_buscar = ""
        End If
        cambio_status()

    End Sub

    Private Sub dgLockers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLockers.CellClick
        If e.ColumnIndex = 1 Then
            no_locker = dgLockers.Item("c_locker", dgLockers.CurrentRow.Index).Value.ToString.Trim()            
            Reloj = dgLockers.Item("c_reloj", dgLockers.CurrentRow.Index).Value.ToString.Trim()
            grupo_locker = cmbGrupos.SelectedValue
            'If Reloj = "" Then
            ' MessageBox.Show("El locker debe estar ya asignado o en uso para poder consultar o registrar un candado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Else
            frmLockersLlave.ShowDialog()
            'MostrarInformacion()

            'End If


        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("Reporte Lockers", sqlExecute(qwery))
        frmVistaPrevia.Show()

    End Sub
    Private Sub cambio_status()
        If cmbStatus.Text = "Disponibles" Then
            status = "where status='0' " & grupo & cadena_buscar
        ElseIf cmbStatus.Text = "Asignados" Then
            status = "where status='1' " & grupo & cadena_buscar
        ElseIf cmbStatus.Text = "Cancelados" Then
            status = "where status='2' " & grupo & cadena_buscar
        ElseIf cmbStatus.Text = "Todos" Then
            status = "where grupo= '" & cmbGrupos.SelectedValue.ToString & "'" & cadena_buscar
        ElseIf cmbStatus.Text = "Bajas asignados" Then
            status = "left join personal on lockers.RELOJ = personal.RELOJ where personal.BAJA is not null and lockers.STATUS = '1'"
        End If
        MostrarInformacion(status)
    End Sub


    Private Sub btnVerBuscar_Click(sender As Object, e As EventArgs) Handles btnVerBuscar.Click
        txtBusqueda.Text = ""
    End Sub
End Class