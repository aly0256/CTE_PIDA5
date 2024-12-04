Public Class frmAuxiliares

    Dim dtTemp As New DataTable
    Dim dtLista As New DataTable
    ' Variables para Auxiliares
    Dim EditarAux As Boolean                    'Modificar registro?
    Dim AgregarAux As Boolean                     'Agregar nuevo?
    Dim AgregarAuxValido As Boolean               'Agregar nuevo auxiliar válido?
    Dim AuxIdx As Integer                       'Indice actual
    Dim dtAuxiliaresC As New DataTable           'Tabla de auxiliares
    Dim dtAuxiliaresCValidos As New DataTable    'Tabla de auxiliares válidos
    Dim idxValido As Integer                    'Auxiliar válido seleccionado actualmente
    Dim CambiosAux(2, 0) As String              'Arreglo para guardar los cambios en el grid de los auxiliares válidos, y admnistrarlos en el botón de guardar
    Dim ix As Integer                           'Indice para el arreglo de CambiosAux

    Dim DesdeGrid As Boolean


    Private Sub frmAuxiliares_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ReDim CambiosAux(2, 5)

        dtLista = sqlExecute("SELECT CAMPO AS 'Código',Nombre FROM AUXILIARES ORDER BY CAMPO")
        dtLista.DefaultView.Sort = "Código"

        dgTabla.DataSource = dtLista
        dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        dtAuxiliaresC = New DataTable
        dtAuxiliaresC = sqlExecute("SELECT * FROM auxiliares ORDER BY campo")
        dtAuxiliaresC.DefaultView.Sort = "campo"
        If dtAuxiliaresC.Rows.Count > 0 Then
            AuxIdx = 0
            AgregarAux = False
            EditarAux = False
            MostrarAuxiliares()
            HabilitarAuxiliares()
        End If
    End Sub

#Region "Auxiliares"

    Private Sub ActualizaTablaValidos() 'Proceso para actualizar la tabla de auxiliares válidos, de acuerdo al arreglo
        Dim x As Integer
        Dim aux As String, id As String, tipo As String
        For x = 0 To CambiosAux.GetUpperBound(1)
            id = CambiosAux(0, x)
            aux = CambiosAux(1, x)
            tipo = CambiosAux(2, x)
            If tipo = "A" Then
                sqlExecute("INSERT INTO auxiliares_validos (campo,campo_valido) VALUES ('" & txtCampo.Text & "','" & aux & "')")
            ElseIf tipo = "C" Then
                sqlExecute("UPDATE auxiliares_validos SET campo_valido = '" & aux & "' WHERE idFld = " & id, )
            ElseIf tipo = "B" Then
                sqlExecute("DELETE FROM auxiliares_validos WHERE idFld = " & id)
            End If

        Next
        ReDim CambiosAux(2, 5)
    End Sub

    Private Sub HabilitarAuxiliares()
        Try
            Dim NoRec As Boolean
            NoRec = dtAuxiliaresC.Rows.Count = 0

            btnPrev.Enabled = Not (AgregarAux Or EditarAux Or NoRec)
            btnFirst.Enabled = Not (AgregarAux Or EditarAux Or NoRec)
            btnNext.Enabled = Not (AgregarAux Or EditarAux Or NoRec)
            btnLast.Enabled = Not (AgregarAux Or EditarAux Or NoRec)
            btnBuscar.Enabled = Not (AgregarAux Or EditarAux Or NoRec)
            btnReporte.Enabled = Not (AgregarAux Or EditarAux Or NoRec)


            btnBorrar.Enabled = Not (AgregarAux Or EditarAux Or NoRec)

            If AgregarAux Or EditarAux Then
                ' Si está activa la edición o nuevo registro
                btnNuevo.Image = PIDA.My.Resources.Ok16
                btnEditar.Image = PIDA.My.Resources.CancelX

                btnNuevo.Text = "Aceptar"
                btnEditar.Text = "Cancelar"
            Else

                btnNuevo.Image = PIDA.My.Resources.NewRecord
                btnEditar.Image = PIDA.My.Resources.Edit

                btnNuevo.Text = "Agregar"
                btnEditar.Text = "Editar"
            End If

            txtCampo.Enabled = AgregarAux
            txtNombreAux.Enabled = AgregarAux Or EditarAux
            swMostrarMaestro.Enabled = AgregarAux Or EditarAux
            dgAuxiliares.ReadOnly = Not (AgregarAux Or EditarAux)

            dgAuxiliares.DefaultCellStyle.BackColor = IIf((AgregarAux Or EditarAux), Color.White, Color.WhiteSmoke)
            dgAuxiliares.BackgroundColor = IIf((AgregarAux Or EditarAux), Color.White, Color.WhiteSmoke)
            dgAuxiliares.ForeColor = IIf((AgregarAux Or EditarAux), Color.Black, Color.DarkGray)

            cmbInicial.Enabled = AgregarAux Or EditarAux

            If AgregarAux Then
                txtCampo.Text = ""
                txtNombreAux.Text = ""
                'dgAuxiliares.DataSource = Nothing
                If cmbInicial.Items.Count Then
                    cmbInicial.Items.Clear()
                End If

            End If

            If AgregarAux Or EditarAux Then
                txtCampo.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MostrarAuxiliares()
        Dim dtValidosInicial As New DataTable
        Dim i As Integer
        txtCampo.Text = dtAuxiliaresC.Rows.Item(0).Item("campo")

        If Not DesdeGrid Then
            i = dtLista.DefaultView.Find(txtCampo.Text)
            If i >= 0 Then
                dgTabla.FirstDisplayedScrollingRowIndex = i
                dgTabla.Rows(i).Selected = True
            End If
        End If

        DesdeGrid = False

        txtNombreAux.Text = dtAuxiliaresC.Rows.Item(0).Item("nombre")
        swMostrarMaestro.Value = IIf(IsDBNull(dtAuxiliaresC.Rows.Item(0).Item("mostrar_personal")), 0, dtAuxiliaresC.Rows.Item(0).Item("mostrar_personal")) = 1

        dtAuxiliaresCValidos = sqlExecute("SELECT idFld, campo_valido AS 'Campo válido' FROM auxiliares_validos WHERE campo ='" & txtCampo.Text & "'")
        dgAuxiliares.DataSource = dtAuxiliaresCValidos
        dgAuxiliares.Columns("idFld").Visible = False

        dtValidosInicial = dtAuxiliaresCValidos.Copy
        cmbInicial.DisplayMember = "Campo válido"
        cmbInicial.DataSource = dtValidosInicial
        cmbInicial.Text = IIf(IsDBNull(dtAuxiliaresC.Rows.Item(0).Item("valor_inicial")), "", dtAuxiliaresC.Rows.Item(0).Item("valor_inicial")).ToString.Trim

        ReDim CambiosAux(2, 5)
    End Sub

#End Region

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim rl As String
        rl = txtCampo.Text
        If MessageBox.Show("¿Está seguro de borrar el campo auxiliar " & rl & "?", "Borrar auxiliares", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            sqlExecute("DELETE FROM auxiliares WHERE campo = '" & rl & "'")
            dtAuxiliaresCValidos = sqlExecute("SELECT idFld, campo_valido AS 'Campo válido' FROM auxiliares_validos WHERE campo ='" & txtCampo.Text & "'")

            dgAuxiliares.DataSource = dtAuxiliaresCValidos
            dgAuxiliares.Columns("idFld").Visible = False
            btnNext.PerformClick()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        If AgregarAux Or EditarAux Then
            If txtCampo.TextLength = 0 Then
                MessageBox.Show("El código del auxiliar no puede quedar en blanco. Favor de verificar.", "Auxiliar en blanco", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCampo.Focus()
                Exit Sub
            End If

            If txtNombreAux.TextLength = 0 Then
                MessageBox.Show("El nombre del auxiliar no puede quedar en blanco. Favor de verificar.", "Auxiliar en blanco", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNombreAux.Focus()
                Exit Sub
            End If
        End If
        If AgregarAux Then
            ' Si AgregarAux, entonces guardar registro nuevo
            dtTemp = sqlExecute("select COL_LENGTH('personal', '" & txtCampo.Text.Trim & "') as campo")
            If Not IsDBNull(dtTemp.Rows(0).Item("campo")) Then
                'Si el campo ya existe en personal, no se puede agregar como auxiliar
                MessageBox.Show("El campo " & txtCampo.Text.Trim & " ya se encuentra incluido en la tabla de <Personal>, y no puede darse de alta como auxiliar.", "Error en auxiliar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtCampo.Focus()
                txtCampo.SelectAll()
                Exit Sub
            End If
            sqlExecute("INSERT INTO auxiliares (campo,nombre,cod_comp,valor_inicial,mostrar_personal) VALUES ('" & txtCampo.Text & "','" & txtNombreAux.Text & "','610','" & cmbInicial.Text & "'," & IIf(swMostrarMaestro.Value, 1, 0) & ")")
            ActualizaTablaValidos()
            AgregarAux = False
            EditarAux = False

        ElseIf EditarAux Then
            ' Si EditarAux, entonces guardar cambios a registro
            sqlExecute("UPDATE auxiliares SET nombre = '" & txtNombreAux.Text & "', valor_inicial ='" & cmbInicial.Text & "', mostrar_personal = " & IIf(swMostrarMaestro.Value, 1, 0) & " WHERE campo = '" & txtCampo.Text & "'")
            ActualizaTablaValidos()
            EditarAux = False

        Else
            AgregarAux = True
            EditarAux = True
            dgAuxiliares.Refresh()
        End If

        HabilitarAuxiliares()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        AgregarAux = False

        EditarAux = Not EditarAux

        MostrarAuxiliares()
        HabilitarAuxiliares()

        If EditarAux Then
            txtCampo.Focus()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Siguiente("auxiliares", "campo", txtCampo.Text, dtAuxiliaresC)
        MostrarAuxiliares()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Ultimo("auxiliares", "campo", dtAuxiliaresC)
        MostrarAuxiliares()
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Primero("auxiliares", "campo", dtAuxiliaresC)
        MostrarAuxiliares()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("auxiliares", "campo", "AUXILIARES", False)
        If Cod <> "CANCELAR" Then
            dtAuxiliaresC = sqlExecute("SELECT * FROM auxiliares WHERE campo = '" & Cod & "'")
            MostrarAuxiliares()
        End If
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Anterior("auxiliares", "campo", txtCampo.Text, dtAuxiliaresC)
        MostrarAuxiliares()
    End Sub

    Private Sub dgAuxiliares_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliares.CellContentClick

    End Sub

    Private Sub dgAuxiliares_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliares.CellValueChanged
        Dim aux As String
        Try
            aux = dgAuxiliares.Item(1, e.RowIndex).Value
            ix = ix + 1
            If ix > CambiosAux.GetUpperBound(1) Then
                ReDim Preserve CambiosAux(2, ix + 1)
            End If


            CambiosAux(0, ix) = IIf(AgregarAuxValido, -1, dgAuxiliares.Item(0, e.RowIndex).Value)
            CambiosAux(1, ix) = dgAuxiliares.Item(1, e.RowIndex).Value
            CambiosAux(2, ix) = IIf(AgregarAuxValido, "A", "C") 'Marcar si fue registro nuevo o un cambio pendiente en la tabla
            AgregarAuxValido = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub dgAuxiliares_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliares.RowEnter
        idxValido = e.RowIndex
    End Sub

    Private Sub dgAuxiliares_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgAuxiliares.UserAddedRow
        AgregarAuxValido = True
    End Sub

    Private Sub dgAuxiliares_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgAuxiliares.UserDeletingRow
        Dim aux As String, x As Integer
        aux = dgAuxiliares.Item(1, e.Row.Index).Value
        If AgregarAux Or EditarAux Then
            If MessageBox.Show("¿Está seguro de borrar el registro " & aux & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'Si no tiene ID, quiere decir que se está borrando un registro nuevo, que no se ha guardado en la tabla
                If IsDBNull(dgAuxiliares.Item(0, e.Row.Index).Value) Then
                    For x = 0 To CambiosAux.GetUpperBound(1)
                        If CambiosAux(1, x) = aux Then
                            ix = x
                            Exit For
                        End If
                    Next
                    CambiosAux(2, ix) = "I" 'Marcar para ignorar el cambio/alta
                Else
                    If ix > CambiosAux.GetUpperBound(1) Then
                        ReDim Preserve CambiosAux(2, ix + 1)
                    End If
                    ix = ix + 1
                    CambiosAux(0, ix) = dgAuxiliares.Item(0, e.Row.Index).Value
                    CambiosAux(1, ix) = dgAuxiliares.Item(1, e.Row.Index).Value
                    CambiosAux(2, ix) = "B" 'Marcar que será borrado de la tabla
                End If
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtCompanias As New DataTable
        Dim dtDatos As New DataTable
        dtDatos = sqlExecute("SELECT auxiliares.CAMPO, auxiliares.NOMBRE, auxiliares.COD_COMP, auxiliares.VALOR_INICIAL, auxiliares_validos.CAMPO_VALIDO FROM " & _
                             "personal.dbo.auxiliares INNER JOIN personal.dbo.auxiliares_validos ON " & _
                             "auxiliares.COD_COMP = auxiliares_validos.COD_COMP AND auxiliares.CAMPO = auxiliares_validos.CAMPO")

        frmVistaPrevia.LlamarReporte("Auxiliares", dtDatos)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub dgTabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellContentClick

    End Sub

    Private Sub dgTabla_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, nom As String

        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value
        dtAuxiliaresC  = sqlExecute("SELECT * FROM auxiliares WHERE campo = '" & cod & "'")
        MostrarAuxiliares()
    End Sub

    Private Sub cmbInicial_GotFocus(sender As Object, e As EventArgs) Handles cmbInicial.GotFocus
        'dtTemp = sqlExecute("SELECT campo_valido FROM auxiliares_validos WHERE campo = '" & txtCampo.Text & "'")
        'cmbInicial.DataSource = dtTemp
        Dim dtValidosInicial As New DataTable
        dtValidosInicial = dtAuxiliaresCValidos.Copy
        cmbInicial.DataSource = dtValidosInicial
        If IsDBNull(dtAuxiliaresC.Rows.Item(0).Item("valor_inicial")) Then
            cmbInicial.SelectedIndex = -1
        Else
            cmbInicial.SelectedValue = dtAuxiliaresC.Rows.Item(0).Item("valor_inicial")
        End If
        'cmbInicial.SelectedValue = IIf(IsDBNull(dtAuxiliaresC.Rows.Item(0).Item("valor_inicial")), "", dtAuxiliaresC.Rows.Item(0).Item("valor_inicial"))
    End Sub

    Private Sub cmbInicial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInicial.SelectedIndexChanged

    End Sub
End Class