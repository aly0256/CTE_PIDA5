
Public Class frmFactInt
    Dim dtTemp As New DataTable
    Dim dtCias As New DataTable
    Dim ix As Integer

    ' Variables para Factores de integración
    Dim dtFactoresIntegracion As New DataTable
    Dim CambiosFactores(4, 0) As String         'Arreglo para guardar los cambios en el grid, y administrarlos en el botón de guardar
    Dim EditarFactores As Boolean               'Modificar registro?
    Dim AgregarFactores As Boolean              'Agregar nuevo?
    Dim FactoresAnt As String                   'Código anterior

    Private Sub btnBuscarFactores_Click(sender As System.Object, e As System.EventArgs)
        Dim Cod As String, x As Integer
        Cod = Buscar("factores", "cod_tipo", "factores", False)
        If Cod <> "CANCELAR" Then
            x = dtFactoresIntegracion.DefaultView.Find(Cod)
            If x >= 0 Then
                dgFactoresIntegracion.CurrentCell.Selected = False
                dgFactoresIntegracion.Rows(x).Selected = True
                dgFactoresIntegracion.FirstDisplayedScrollingRowIndex = x
            End If

        End If
    End Sub

    Private Sub btnAgregarFactores_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarFactores.Click
        Dim x As Integer
        Dim fact As String, cod As String, anos As String, tipo As String, codAnt
        Dim cia As String = txtCia.Text
        Dim CambioAplicado As Boolean
        For x = 1 To CambiosFactores.GetUpperBound(1)
            cod = CambiosFactores(0, x)
            anos = CambiosFactores(1, x)
            fact = CambiosFactores(4, x)
            tipo = CambiosFactores(2, x)
            codAnt = CambiosFactores(3, x)
            CambioAplicado = True
            If tipo = "A" Then
                dtTemp = sqlExecute("INSERT INTO factores (cod_comp,cod_tipo,factor_int,anos) VALUES ('" & cia & "','" & cod & "','" & fact & "'," & anos & ")")
            ElseIf tipo = "C" Then
                dtTemp = sqlExecute("UPDATE factores SET factor_int = '" & fact & "' WHERE cod_tipo = '" & codAnt & "' AND cod_comp = '" & cia & "' AND anos = " & anos)
            ElseIf tipo = "B" Then
                dtTemp = sqlExecute("DELETE FROM factores WHERE  cod_tipo = '" & cod & "' AND cod_comp = '" & cia & "' AND anos = " & anos)
            End If
            CambioAplicado = CambioAplicado And Not (dtTemp Is New DataTable)

        Next

        EditarFactores = False
        dtFactoresIntegracion = New DataTable
        dtFactoresIntegracion = sqlExecute("SELECT cod_tipo AS 'TIPO',anos AS 'AÑOS',factor_int AS 'FACTOR INT.' FROM factores WHERE cod_comp = '" & txtCia.Text & "'")
        dgFactoresIntegracion.DataSource = dtFactoresIntegracion
        HabilitarFactores()

        If Not CambioAplicado Then
            MessageBox.Show("Algunos cambios no pudieron ser aplicados por duplicidad o inconsistencias. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf ix > 0 Then
            ' MessageBox.Show("Los cambios fueron aplicados exitosamente.", "Aplicar cambios", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ReDim CambiosFactores(4, 5)
        ix = 0
    End Sub

    Private Sub btnEditarFactores_Click(sender As System.Object, e As System.EventArgs) Handles btnEditarFactores.Click
        On Error GoTo ErrEditar
        EditarFactores = Not EditarFactores

        If EditarFactores Then
            dgFactoresIntegracion.Focus()
        Else
            dtFactoresIntegracion = New DataTable
            dtFactoresIntegracion = sqlExecute("SELECT cod_tipo AS 'TIPO',anos AS 'AÑOS',factor_int AS 'FACTOR INT.' FROM factores WHERE cod_comp = '" & txtCia.Text & "'")
            dgFactoresIntegracion.DataSource = dtFactoresIntegracion
            ReDim CambiosFactores(4, 5)
            ix = 0
        End If
        HabilitarFactores()
ErrEditar:
    End Sub

    Private Sub dgFactoresIntegracion_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFactoresIntegracion.CellEndEdit
        Dim dato As String
        If EditarFactores Then
            dato = dgFactoresIntegracion.Item(0, e.RowIndex).Value

            If ix > CambiosFactores.GetUpperBound(1) Then
                ReDim Preserve CambiosFactores(4, ix + 1)
            End If
            ix = ix + 1
            CambiosFactores(0, ix) = dgFactoresIntegracion.Item(0, e.RowIndex).Value
            CambiosFactores(1, ix) = IIf(IsDBNull(dgFactoresIntegracion.Item(1, e.RowIndex).Value), "", dgFactoresIntegracion.Item(1, e.RowIndex).Value)
            CambiosFactores(2, ix) = IIf(AgregarFactores, "A", "C") 'Marcar si fue registro nuevo o un cambio pendiente en la tabla
            CambiosFactores(3, ix) = FactoresAnt
            CambiosFactores(4, ix) = IIf(IsDBNull(dgFactoresIntegracion.Item(2, e.RowIndex).Value), 0, dgFactoresIntegracion.Item(2, e.RowIndex).Value)
            FactoresAnt = CambiosFactores(0, ix)
            AgregarFactores = False
        End If
    End Sub

    Private Sub dgFactoresIntegracion_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFactoresIntegracion.RowEnter
        FactoresAnt = dgFactoresIntegracion.Item(0, e.RowIndex).Value
    End Sub

    Private Sub dgFactoresIntegracion_UserAddedRow(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgFactoresIntegracion.UserAddedRow
        AgregarFactores = True
    End Sub

    Private Sub dgFactoresIntegracion_UserDeletingRow(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgFactoresIntegracion.UserDeletingRow
        Dim val As String, x As Integer, i As Integer
        val = dgFactoresIntegracion.Item(1, e.Row.Index).Value
        If AgregarFactores Or EditarFactores Then
            If MessageBox.Show("¿Está seguro de borrar el registro " & val & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ' Revisar si se va a borrar un registro que se acaba de agregar
                i = -1
                For x = 0 To CambiosFactores.GetUpperBound(1)
                    If CambiosFactores(1, x) = val And CambiosFactores(3, x) = "A" Then
                        i = x
                        ix = x
                        Exit For
                    End If
                Next

                ' Si el registro se acaba de agregar, ignorarlo
                If i >= 0 Then
                    CambiosFactores(3, ix) = "I" 'Marcar para ignorar el alta
                Else
                    If ix > CambiosFactores.GetUpperBound(1) Then
                        ReDim Preserve CambiosFactores(4, ix + 1)
                    End If
                    ix = ix + 1
                    CambiosFactores(0, ix) = dgFactoresIntegracion.Item(0, e.Row.Index).Value
                    CambiosFactores(1, ix) = dgFactoresIntegracion.Item(1, e.Row.Index).Value
                    CambiosFactores(2, ix) = "B" 'Marcar que será borrado de la tabla

                End If
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub HabilitarFactores()
        On Error Resume Next
        btnReporteFactores.Enabled = Not EditarFactores
        btnAgregarFactores.Visible = EditarFactores
        If EditarFactores Then
            ' Si está activa la edición o nuevo registro
            btnAgregarFactores.Image = PIDA.My.Resources.Ok16
            btnEditarFactores.Image = PIDA.My.Resources.CancelX

            btnAgregarFactores.Text = "Aceptar"
            btnEditarFactores.Text = "Cancelar"
        Else
            btnAgregarFactores.Image = PIDA.My.Resources.NewRecord
            btnEditarFactores.Image = PIDA.My.Resources.Edit

            btnAgregarFactores.Text = "Agregar"
            btnEditarFactores.Text = "Editar"
        End If
        dgFactoresIntegracion.ReadOnly = Not EditarFactores
        dgFactoresIntegracion.DefaultCellStyle.BackColor = IIf(EditarFactores, Color.White, Color.WhiteSmoke)
        dgFactoresIntegracion.BackgroundColor = IIf(EditarFactores, Color.White, Color.WhiteSmoke)
        dgFactoresIntegracion.ForeColor = IIf(EditarFactores, Color.Black, Color.DarkGray)
    End Sub

    Private Sub btnReporteFactores_Click(sender As Object, e As EventArgs) Handles btnReporteFactores.Click
        Dim dtDatos As New DataTable
        dtDatos = sqlExecute("SELECT * FROM factores WHERE cod_comp = '" & txtCia.Text & "'")
        frmVistaPrevia.LlamarReporte("FactoresInt", dtDatos, txtCia.Text)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub frmFactInt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReDim CambiosFactores(4, 5)
        btnCiasFirst.PerformClick()
    End Sub
    Private Sub MostrarCias()

        txtCia.Text = dtCias.Rows.Item(0).Item("cod_comp")
        txtNombre.Text = dtCias.Rows.Item(0).Item("nombre")

        dtFactoresIntegracion = sqlExecute("SELECT cod_tipo AS 'TIPO',anos AS 'AÑOS',factor_int AS 'FACTOR INT.' FROM factores WHERE cod_comp = '" & txtCia.Text & "'")
        dgFactoresIntegracion.DataSource = dtFactoresIntegracion

        HabilitarFactores()
    End Sub


    Private Sub btnCerrarFactores_Click(sender As Object, e As EventArgs) Handles btnCerrarFactores.Click
        Me.close 
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