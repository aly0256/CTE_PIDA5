Public Class frmVacaciones
    Dim dtTemp As New DataTable
    Dim dtCias As New DataTable
    Dim ix As Integer

    ' Variables para Vacaciones de integración
    Dim dtVacaciones As New DataTable
    Dim CambiosVacaciones(5, 0) As String         'Arreglo para guardar los cambios en el grid, y administrarlos en el botón de guardar
    Dim EditarVacaciones As Boolean               'Modificar registro?
    Dim AgregarVacaciones As Boolean              'Agregar nuevo?
    Dim VacacionesAnt As String                   'Código anterior

    Private Sub btnAgregarVacaciones_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarVacaciones.Click
        Dim x As Integer
        Dim dias As String, prima As String, cod As String, anos As String, tipo As String, codAnt
        Dim cia As String = txtCia.Text
        Dim CambioAplicado As Boolean, Completo As Boolean
        Completo = True
        For x = 1 To CambiosVacaciones.GetUpperBound(1)
            cod = CambiosVacaciones(0, x)
            anos = CambiosVacaciones(1, x)
            dias = CambiosVacaciones(4, x)
            prima = CambiosVacaciones(5, x)

            tipo = CambiosVacaciones(2, x)
            codAnt = CambiosVacaciones(3, x)
            CambioAplicado = True
            If tipo = "A" Then
                dtTemp = sqlExecute("INSERT INTO vacaciones (cod_comp,cod_tipo,anos,dias,por_prima) VALUES ('" & _
                                    cia & "','" & cod & "'," & anos & "," & dias & "," & prima & ")")
            ElseIf tipo = "C" Then
                dtTemp = sqlExecute("UPDATE vacaciones SET dias = " & dias & ", por_prima = " & prima & _
                                    " WHERE cod_tipo = '" & codAnt & "' AND cod_comp = '" & cia & "' AND anos = " & anos)
            ElseIf tipo = "B" Then
                dtTemp = sqlExecute("DELETE FROM vacaciones WHERE  cod_tipo = '" & cod & "' AND cod_comp = '" & cia & "' AND anos = " & anos)
            End If
            CambioAplicado = Not (dtTemp Is New DataTable)
            If Not CambioAplicado Then
                Completo = False
            End If
        Next
        EditarVacaciones = False
        dtVacaciones = New DataTable
        dtVacaciones = sqlExecute("SELECT cod_tipo AS 'TIPO',anos AS 'AÑOS',dias AS 'DÍAS', por_prima AS 'PRIMA' FROM vacaciones WHERE cod_comp = '" & txtCia.Text & "'")
        dgVacaciones.DataSource = dtVacaciones
        HabilitarVacaciones()

        If Not Completo Then
            MessageBox.Show("Algunos cambios no pudieron ser aplicados por duplicidad o inconsistencias. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf ix > 0 Then
           ' MessageBox.Show("Los cambios fueron aplicados exitosamente.", "Aplicar cambios", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ReDim CambiosVacaciones(5, 5)
        ix = 0
    End Sub

    Private Sub btnEditarVacaciones_Click(sender As System.Object, e As System.EventArgs) Handles btnEditarVacaciones.Click
        On Error GoTo ErrEditar
        EditarVacaciones = Not EditarVacaciones

        If EditarVacaciones Then
            dgVacaciones.Focus()
        Else
            dtVacaciones = New DataTable
            dtVacaciones = sqlExecute("SELECT cod_tipo AS 'TIPO',anos AS 'AÑOS',dias AS 'DÍAS', por_prima AS 'PRIMA' FROM vacaciones WHERE cod_comp = '" & txtCia.Text & "'")

            dgVacaciones.DataSource = dtVacaciones
            ReDim CambiosVacaciones(5, 5)
            ix = 0
        End If
        HabilitarVacaciones()
ErrEditar:
    End Sub

    Private Sub dgVacaciones_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgVacaciones.CellEndEdit
        Dim dato As String
        If EditarVacaciones Then
            dato = dgVacaciones.Item(0, e.RowIndex).Value

            If ix > CambiosVacaciones.GetUpperBound(1) Then
                ReDim Preserve CambiosVacaciones(5, ix + 1)
            End If
            ix = ix + 1
            CambiosVacaciones(0, ix) = dgVacaciones.Item(0, e.RowIndex).Value
            CambiosVacaciones(1, ix) = IIf(IsDBNull(dgVacaciones.Item(1, e.RowIndex).Value), 0, dgVacaciones.Item(1, e.RowIndex).Value)
            CambiosVacaciones(2, ix) = IIf(AgregarVacaciones, "A", "C") 'Marcar si fue registro nuevo o un cambio pendiente en la tabla
            CambiosVacaciones(3, ix) = VacacionesAnt
            CambiosVacaciones(4, ix) = IIf(IsDBNull(dgVacaciones.Item(2, e.RowIndex).Value), 0, dgVacaciones.Item(2, e.RowIndex).Value) 'Años
            CambiosVacaciones(5, ix) = IIf(IsDBNull(dgVacaciones.Item(3, e.RowIndex).Value), 0, dgVacaciones.Item(3, e.RowIndex).Value) 'Prima
            VacacionesAnt = CambiosVacaciones(0, ix)
            AgregarVacaciones = False
        End If
    End Sub

    Private Sub dgVacaciones_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgVacaciones.RowEnter
        VacacionesAnt = dgVacaciones.Item(0, e.RowIndex).Value
    End Sub

    Private Sub dgVacaciones_UserAddedRow(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgVacaciones.UserAddedRow
        AgregarVacaciones = True
    End Sub

    Private Sub dgVacaciones_UserDeletingRow(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgVacaciones.UserDeletingRow
        Dim val As String, x As Integer, i As Integer
        val = dgVacaciones.Item(1, e.Row.Index).Value
        If AgregarVacaciones Or EditarVacaciones Then
            If MessageBox.Show("¿Está seguro de borrar el registro " & val & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ' Revisar si se va a borrar un registro que se acaba de agregar
                i = -1
                For x = 0 To CambiosVacaciones.GetUpperBound(1)
                    If CambiosVacaciones(1, x) = val And CambiosVacaciones(3, x) = "A" Then
                        i = x
                        ix = x
                        Exit For
                    End If
                Next

                ' Si el registro se acaba de agregar, ignorarlo
                If i >= 0 Then
                    CambiosVacaciones(3, ix) = "I" 'Marcar para ignorar el alta
                Else
                    If ix > CambiosVacaciones.GetUpperBound(1) Then
                        ReDim Preserve CambiosVacaciones(5, ix + 1)
                    End If
                    ix = ix + 1
                    CambiosVacaciones(0, ix) = dgVacaciones.Item(0, e.Row.Index).Value
                    CambiosVacaciones(1, ix) = dgVacaciones.Item(1, e.Row.Index).Value
                    CambiosVacaciones(2, ix) = "B" 'Marcar que será borrado de la tabla

                End If
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub HabilitarVacaciones()
        On Error Resume Next
        btnReporteVacaciones.Enabled = Not EditarVacaciones
        btnAgregarVacaciones.Visible = EditarVacaciones
        If EditarVacaciones Then
            ' Si está activa la edición o nuevo registro
            btnAgregarVacaciones.Image = PIDA.My.Resources.Ok16
            btnEditarVacaciones.Image = PIDA.My.Resources.CancelX

            btnAgregarVacaciones.Text = "Aceptar"
            btnEditarVacaciones.Text = "Cancelar"
        Else

            btnAgregarVacaciones.Image = PIDA.My.Resources.NewRecord
            btnEditarVacaciones.Image = PIDA.My.Resources.Edit

            btnAgregarVacaciones.Text = "Agregar"
            btnEditarVacaciones.Text = "Editar"
        End If
        dgVacaciones.ReadOnly = Not EditarVacaciones
        dgVacaciones.DefaultCellStyle.BackColor = IIf(EditarVacaciones, Color.White, Color.WhiteSmoke)
        dgVacaciones.BackgroundColor = IIf(EditarVacaciones, Color.White, Color.WhiteSmoke)
        dgVacaciones.ForeColor = IIf(EditarVacaciones, Color.Black, Color.DarkGray)
    End Sub

    Private Sub btnReporteVacaciones_Click(sender As Object, e As EventArgs) Handles btnReporteVacaciones.Click
        Dim dtDatos As New DataTable
        dtDatos = sqlExecute("SELECT vacaciones.cod_comp,vacaciones.cod_tipo,tipo_emp.nombre as 'nombre_tipo',vacaciones.anos,vacaciones.dias,vacaciones.por_prima,vacaciones.nombre FROM personal.dbo.vacaciones LEFT JOIN personal.dbo.tipo_emp ON   vacaciones.cod_tipo = tipo_emp.cod_tipo AND vacaciones.cod_comp = tipo_emp.cod_comp WHERE vacaciones.cod_comp = '" & txtCia.Text & "'")
        frmVistaPrevia.LlamarReporte("Vacaciones", dtDatos, txtCia.Text)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub frmFactInt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReDim CambiosVacaciones(5, 5)
        btnCiasFirst.PerformClick()

    End Sub
    Private Sub MostrarCias()

        txtCia.Text = dtCias.Rows.Item(0).Item("cod_comp")
        txtNombre.Text = dtCias.Rows.Item(0).Item("nombre")

        dtVacaciones = sqlExecute("SELECT cod_tipo AS 'TIPO',anos AS 'AÑOS',dias AS 'DÍAS', por_prima AS 'PRIMA' FROM vacaciones WHERE cod_comp = '" & txtCia.Text & "'")
        dgVacaciones.DataSource = dtVacaciones

        HabilitarVacaciones()
    End Sub


    Private Sub btnCerrarVacaciones_Click(sender As Object, e As EventArgs) Handles btnCerrarVacaciones.Click
        Me.close()
    End Sub

    Private Sub btnCiasFirst_Click(sender As Object, e As EventArgs) Handles btnCiasFirst.Click
        Primero("cias", "cod_comp", dtCias)
        MostrarCias()
    End Sub

    Private Sub btnCiasPrev_Click(sender As Object, e As EventArgs) Handles btnCiasPrev.Click
        Anterior("cias", "cod_comp", txtCia.Text, dtCias)
        MostrarCias()
    End Sub

    Private Sub btnCiasNext_Click(sender As Object, e As EventArgs) Handles btnCiasNext.Click
        Siguiente("cias", "cod_comp", txtCia.Text, dtCias)
        MostrarCias()
    End Sub

    Private Sub btnCiasLast_Click(sender As Object, e As EventArgs) Handles btnCiasLast.Click
        Ultimo("cias", "cod_comp", dtCias)
        MostrarCias()
    End Sub
End Class