Public Class frmAguinaldo
    Dim dtTemp As New DataTable
    Dim dtCias As New DataTable
    Dim ix As Integer

    ' Variables para Aguinaldo de integración
    Dim dtAguinaldo As New DataTable
    Dim CambiosAguinaldo(4, 0) As String         'Arreglo para guardar los cambios en el grid, y administrarlos en el botón de guardar
    Dim EditarAguinaldo As Boolean               'Modificar registro?
    Dim AgregarAguinaldo As Boolean              'Agregar nuevo?
    Dim AguinaldoAnt As String                   'Código anterior
    Dim HuboCambios As Boolean
    Dim HuboBorrados As Boolean


    Private Sub btnBuscar_click(sender As System.Object, e As System.EventArgs)
        Dim Cod As String, x As Integer
        Cod = Buscar("Aguinaldo", "cod_tipo", "Aguinaldo", False)
        If Cod <> "CANCELAR" Then
            x = dtAguinaldo.DefaultView.Find(Cod)
            If x >= 0 Then
                dgAguinaldo.CurrentCell.Selected = False
                dgAguinaldo.Rows(x).Selected = True
                dgAguinaldo.FirstDisplayedScrollingRowIndex = x
            End If

        End If
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Dim dias As String, anos As String, tipo As String
        Dim cia As String = txtCia.Text
        Dim CambioAplicado As Boolean
        Dim Success As Boolean
        Dim cadena As String = ""
        Dim nombre As String = ""

        Success = True
        Try
            For Each dRow As DataGridViewRow In dgAguinaldo.Rows
                If dRow.Cells("cambio").Value <> "I" And Not dRow.Cells("cambio").Value = Nothing Then
                    tipo = IIf(IsDBNull(dRow.Cells("tipo").Value), "", dRow.Cells("tipo").Value).ToString.ToUpper
                    anos = IIf(IsDBNull(dRow.Cells("años").Value), 0, dRow.Cells("años").Value)
                    dias = IIf(IsDBNull(dRow.Cells("dias").Value), 0, dRow.Cells("dias").Value)
                    cadena = IIf(IsDBNull(dRow.Cells("cadena").Value), "", dRow.Cells("cadena").Value)
                    'nombre = IIf(IsDBNull(dRow.Cells("nombre").Value), "", dRow.Cells("nombre").Value)


                    CambioAplicado = True
                    If dRow.Cells("cambio").Value = "A" Then
                        sqlExecute("INSERT INTO Agui (cod_comp,cod_tipo,dias,anos,nombre) VALUES ('" & cia & "','" & tipo & "','" & dias & "','" & anos & "','" & nombre & "')")

                    ElseIf dRow.Cells("cambio").Value = "B" And cadena.Length > 0 Then
                        'Si la cadena = 0, el registro a borrar fue recién insertado
                        sqlExecute("DELETE FROM Agui WHERE " & cadena)
                        'dRow.Visible = False
                    ElseIf dRow.Cells("cambio").Value = "C" Then
                        If dias <> 0 Then
                            sqlExecute("UPDATE Agui SET anos = '" & anos & "', cod_tipo = '" & tipo & "', dias = '" & dias & "', nombre = '" & nombre & "' WHERE " & cadena)
                        Else
                            sqlExecute("UPDATE Agui SET cod_tipo = '" & tipo & "', anos = '" & anos & "', nombre = '" & nombre & "' WHERE " & cadena)
                        End If
                    End If
                    If Not CambioAplicado And Success Then
                        Success = False
                    End If
                End If
            Next

            'For x = 1 To CambiosAguinaldo.GetUpperBound(1)
            '    cod = CambiosAguinaldo(0, x)
            '    anos = CambiosAguinaldo(1, x)
            '    dias = CambiosAguinaldo(4, x)
            '    tipo = CambiosAguinaldo(2, x)
            '    codAnt = CambiosAguinaldo(3, x)
            '    CambioAplicado = True
            '    If tipo = "A" Then
            '        CambioAplicado = sqlExecute("INSERT INTO Agui (cod_comp,cod_tipo,dias,anos) VALUES ('" & cia & "','" & cod & "','" & dias & "','" & anos & "')", dtTemp)
            '    ElseIf tipo = "C" Then
            '        If dias <> 0 Then
            '            CambioAplicado = sqlExecute("UPDATE Agui SET dias = '" & dias & "' WHERE cod_tipo = '" & codAnt & "' AND cod_comp = '" & cia & "' AND anos = '" & anos & "'", dtTemp)
            '        Else
            '            CambioAplicado = sqlExecute("UPDATE Agui SET anos = '" & anos & "' WHERE cod_tipo = '" & codAnt & "' AND cod_comp = '" & cia & "' AND anos = '" & 0 & "'", dtTemp)
            '        End If
            '    ElseIf tipo = "B" Then
            '        CambioAplicado = sqlExecute("DELETE FROM Agui WHERE  cod_tipo = '" & cod & "' AND cod_comp = '" & cia & "' AND anos = '" & anos & "'", dtTemp)
            '    End If

            '    If Not CambioAplicado And Success Then
            '        Success = False
            '    End If
            'Next
            EditarAguinaldo = False
            'dtAguinaldo = New DataTable
            'sqlExecute("SELECT cod_tipo AS 'TIPO',anos AS 'AÑOS',dias as 'DÍAS' FROM agui WHERE cod_comp = '" & txtCia.Text & "'", dtAguinaldo)
            'dgAguinaldo.DataSource = dtAguinaldo
            'HabilitarAguinaldo()
            MostrarInformacion()


            If Not Success Then
                MessageBox.Show("Algunos cambios no pudieron ser aplicados por duplicidad o inconsistencias. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf ix > 0 Then
                'MessageBox.Show("Los cambios fueron aplicados exitosamente.", "Aplicar cambios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'ReDim CambiosAguinaldo(4, 5)
            'ix = 0
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        On Error GoTo ErrEditar
        EditarAguinaldo = Not EditarAguinaldo

        If EditarAguinaldo Then
            dgAguinaldo.Focus()
        Else
            'dtAguinaldo = New DataTable
            'sqlExecute("SELECT cod_tipo AS 'TIPO',anos AS 'AÑOS',dias as 'DÍAS' FROM agui WHERE cod_comp = '" & txtCia.Text & "'", dtAguinaldo)
            'dgAguinaldo.DataSource = dtAguinaldo

            MostrarInformacion()
            ReDim CambiosAguinaldo(4, 5)
            ix = 0
        End If
        HabilitarAguinaldo()
ErrEditar:
    End Sub

    Private Sub dgAguinaldo_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAguinaldo.CellEndEdit
        Dim c As String = ""
        Try

            If AgregarAguinaldo Then
                dgAguinaldo.Item("cambio", e.RowIndex).Value = "A"
            End If

            If EditarAguinaldo Then
                dgAguinaldo.Item("cambio", e.RowIndex).Value = IIf(dgAguinaldo.Item("cambio", e.RowIndex).Value = "A", "A", "C")
                If dgAguinaldo.Columns(e.ColumnIndex).Name.ToLower = "tipo" Then
                    c = dgAguinaldo.Item("tipo", e.RowIndex).Value
                    dtTemp = sqlExecute("SELECT nombre FROM tipo_emp where cod_tipo = '" & c & "'")
                    If dtTemp.Rows.Count = 0 Then
                        MessageBox.Show("El tipo de empleado no es válido. Favor de verificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dgAguinaldo.Item("nombre", e.RowIndex).Value = "NO IDENTIFICADO"
                    Else
                        dgAguinaldo.Item("nombre", e.RowIndex).Value = dtTemp.Rows(0).Item("nombre")
                    End If
                End If

                HuboCambios = True
                AgregarAguinaldo = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgAguinaldo_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAguinaldo.RowEnter
        AguinaldoAnt = IIf(IsDBNull(dgAguinaldo.Item(0, e.RowIndex).Value), "", dgAguinaldo.Item(0, e.RowIndex).Value)
    End Sub

    Private Sub dgAguinaldo_UserAddedRow(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgAguinaldo.UserAddedRow
        AgregarAguinaldo = True
    End Sub

    Private Sub dgAguinaldo_UserDeletingRow(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgAguinaldo.UserDeletingRow
        Dim val As String
        ', x As Integer, i As Integer
        val = dgAguinaldo.Item(1, e.Row.Index).Value
        If AgregarAguinaldo Or EditarAguinaldo Then
            If MessageBox.Show("¿Está seguro de borrar el registro " & val & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ' Revisar si se va a borrar un registro que se acaba de agregar

                dgAguinaldo.Item("cambio", e.Row.Index).Value = "B"
                e.Row.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Strikeout)
                e.Cancel = True
                'i = -1
                'For x = 0 To CambiosAguinaldo.GetUpperBound(1)
                '    If CambiosAguinaldo(1, x) = val And CambiosAguinaldo(3, x) = "A" Then
                '        i = x
                '        ix = x
                '        Exit For
                '    End If
                'Next

                '' Si el registro se acaba de agregar, ignorarlo
                'If i >= 0 Then
                '    CambiosAguinaldo(3, ix) = "I" 'Marcar para ignorar el alta
                'Else
                '    If ix > CambiosAguinaldo.GetUpperBound(1) Then
                '        ReDim Preserve CambiosAguinaldo(4, ix + 1)
                '    End If
                '    ix = ix + 1
                '    CambiosAguinaldo(0, ix) = IIf(IsDBNull(dgAguinaldo.Item(0, e.Row.Index).Value), "", dgAguinaldo.Item(0, e.Row.Index).Value)
                '    CambiosAguinaldo(1, ix) = IIf(IsDBNull(dgAguinaldo.Item(1, e.Row.Index).Value), 0, dgAguinaldo.Item(1, e.Row.Index).Value)
                '    CambiosAguinaldo(2, ix) = "B" 'Marcar que será borrado de la tabla

                'End If
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub HabilitarAguinaldo()
        On Error Resume Next
        btnReporte.Enabled = Not EditarAguinaldo
        btnAgregar.visible = EditarAguinaldo
        If EditarAguinaldo Then
            ' Si está activa la edición o nuevo registro
            btnAgregar.Image = PIDA.My.Resources.Ok16
            btnEditar.Image = PIDA.My.Resources.CancelX

            btnAgregar.Text = "Aceptar"
            btnEditar.Text = "Cancelar"
        Else
            btnAgregar.Image = PIDA.My.Resources.NewRecord
            btnEditar.Image = PIDA.My.Resources.Edit

            btnAgregar.Text = "Agregar"
            btnEditar.Text = "Editar"
        End If
        dgAguinaldo.ReadOnly = Not EditarAguinaldo
        dgAguinaldo.DefaultCellStyle.BackColor = IIf(EditarAguinaldo, Color.White, Color.WhiteSmoke)
        dgAguinaldo.BackgroundColor = IIf(EditarAguinaldo, Color.White, Color.WhiteSmoke)
        dgAguinaldo.ForeColor = IIf(EditarAguinaldo, Color.Black, Color.DarkGray)
    End Sub

    Private Sub btnReporte_click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtCompanias As New DataTable
        Dim dtDatos As New DataTable
        dtDatos = sqlExecute("SELECT agui.cod_comp,agui.cod_tipo,tipo_emp.nombre as 'nombre_tipo',agui.nombre,agui.anos,agui.dias,agui.dias_ad FROM personal.dbo.agui LEFT JOIN personal.dbo.tipo_emp ON agui.cod_tipo = tipo_emp.cod_tipo AND agui.cod_comp = tipo_emp.cod_comp WHERE agui.cod_comp = '" & txtCia.Text & "'")
        dtCompanias = sqlExecute("SELECT cod_comp FROM cias WHERE cod_comp = '" & txtCia.Text & "'")

        frmVistaPrevia.LlamarReporte("Aguinaldo", dtDatos, txtCia.Text)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub frmAguinaldo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmFactInt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReDim CambiosAguinaldo(4, 5)
        btnCiasFirst.PerformClick()
    End Sub
    Private Sub MostrarInformacion()
        Dim x As Integer
        Try
            txtCia.Text = dtCias.Rows.Item(0).Item("cod_comp")
            txtNombre.Text = dtCias.Rows.Item(0).Item("nombre")

            'dtAguinaldo = sqlExecute("SELECT agui.cod_tipo 'TIPO',tipo_emp.NOMBRE,anos AS 'AÑOS',dias as 'DÍAS',('cod_comp = '''+ 'agui.COD_COMP + "' AND cod_tipo ='" + agui.COD_TIPO + "' AND anos = " + anos + " AND dias = " + dias) as cadena, 'I' as Cambio  FROM agui LEFT JOIN tipo_emp ON agui.cod_tipo = tipo_emp.cod_tipo AND agui.cod_comp = tipo_emp.cod_comp WHERE agui.cod_comp ='" & txtCia.Text & "'")
            ' CAMBIO!!
            dtAguinaldo = sqlExecute(
                "SELECT agui.cod_tipo as 'TIPO', " & _
                "tipo_emp.NOMBRE, " & _
                "anos AS 'AÑOS', " & _
                "dias as 'DÍAS', " & _
                "('cod_comp = ''' + cast(agui.COD_COMP as char(3)) + ''' AND cod_tipo =''' + cast(agui.COD_TIPO as char(1)) + ''' AND anos = ' + rtrim(cast(anos as char(2)))+ ' AND dias = ' + rtrim( cast (dias as char(4)))) as cadena, " & _
                " 'I' as Cambio  " & _
                "FROM agui " & _
                "LEFT JOIN tipo_emp ON agui.cod_tipo = tipo_emp.cod_tipo AND agui.cod_comp = tipo_emp.cod_comp WHERE agui.cod_comp ='" & txtCia.Text & "'"
                )

            dgAguinaldo.DataSource = dtAguinaldo
            'dgAguinaldo.DataMember = "TIPO,AÑOS,DÍAS"

            dgAguinaldo.Columns.Remove("Tipo")
            dgAguinaldo.Columns.Remove("Cambio")

            'dgAguinaldo.Columns.RemoveAt(dgAguinaldo.Columns.Count - 1)
            'dgAguinaldo.Columns.RemoveAt(dgAguinaldo.Columns.Count - 1)

            Dim dgvCombo As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn
            With dgvCombo
                .Width = 150
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                dtTemp = sqlExecute("SELECT cod_tipo,nombre FROM tipo_emp WHERE cod_comp = '" & txtCia.Text & "' ORDER BY cod_tipo")
                For x = 0 To dtTemp.Rows.Count - 1
                    .Items.Add(dtTemp.Rows.Item(x).Item("cod_tipo"))
                Next

                .DataPropertyName = "TIPO"
                .HeaderText = "TIPO"
                .Name = "Tipo"
            End With
            dgAguinaldo.Columns.Insert(0, dgvCombo)
            Dim dCol As New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
            dCol.DataPropertyName = "Cambio"
            dCol.HeaderText = "Cambio"
            dCol.Visible = False
            dCol.Name = "Cambio"

            dCol.Width = 10

            dgAguinaldo.Columns.Add(dCol)

            HabilitarAguinaldo()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try

    End Sub


    Private Sub btnCerrar_click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.close()
    End Sub

    Private Sub btnCiasFirst_Click(sender As Object, e As EventArgs) Handles btnCiasFirst.Click
        Primero("cias", "cod_comp", dtCias)
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(sender As Object, e As EventArgs) Handles btnCiasPrev.Click
        Anterior("cias", "cod_comp", txtCia.Text, dtCias)
        MostrarInformacion()
    End Sub

    Private Sub btnCiasNext_Click(sender As Object, e As EventArgs) Handles btnCiasNext.Click
        Siguiente("cias", "cod_comp", txtCia.Text, dtCias)
        MostrarInformacion()
    End Sub

    Private Sub btnCiasLast_Click(sender As Object, e As EventArgs) Handles btnCiasLast.Click
        Ultimo("cias", "cod_comp", dtCias)
        MostrarInformacion()
    End Sub

    Private Sub dgAguinaldo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAguinaldo.CellContentClick

    End Sub

    Private Sub frmAguinaldo_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus

    End Sub
End Class