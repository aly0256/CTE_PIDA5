Public Class frmSeleccionarTratamientos

    Public id_bitacora As String = ""
    Private tratamientos As String = ""

    Dim dtBusqueda As New DataTable
    Dim dtFallback As New DataTable

    Private Sub llenar_busqueda()
        Try
            dtBusqueda.Columns.Add("id_recurso")
            dtBusqueda.Columns.Add("descripcion")
            dtBusqueda.Columns.Add("servicio")
            dtBusqueda.Columns.Add("posologia")
            dtBusqueda.Columns.Add("recurso")
            dtBusqueda.Columns.Add("tipo")
            dtBusqueda.Columns.Add("dias")

            dtFallback = dtBusqueda.Clone

            Dim dtSintomas As DataTable = sqlExecute("select * from tratamientos", "sermed")
            For Each row As DataRow In dtSintomas.Rows
                Dim codigo As String = RTrim(row("id_recurso"))
                Dim nombre As String = EliminaAcentos(RTrim(row("descripcion")))
                Dim servicio As String = EliminaAcentos(RTrim(row("servicio")))
                Dim posologia As String = EliminaAcentos(RTrim(row("posologia")))
                Dim recurso As String = EliminaAcentos(RTrim(row("recurso")))
                Dim tipo As String = EliminaAcentos(RTrim(row("clasificacion")))
                Dim dias As String = EliminaAcentos(RTrim(row("dias_tratamiento")))

                dtBusqueda.Rows.Add({codigo, nombre, servicio, posologia, recurso, tipo, dias})

            Next

            dgvBusquedaTratamientos.DataSource = dtBusqueda

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmSeleccionarTratamientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_busqueda()

        dgvBusquedaTratamientos.AutoGenerateColumns = False

        Dim dtRegistro As DataTable = sqlExecute("select * from bitacora_enfermeria where id_bitacora = '" & id_bitacora & "'", "sermed")
        If dtRegistro.Rows.Count > 0 Then
            txtReloj.Text = dtRegistro.Rows(0)("reloj")
            Dim dtPersonal As DataTable = sqlExecute("select * from personalvw where reloj = '" & txtReloj.Text & "'")
            If dtPersonal.Rows.Count > 0 Then
                txtNombres.Text = dtPersonal.Rows(0)("nombres")
            End If

            If IsDBNull(dtRegistro.Rows(0)("tratamiento")) Then
                tratamientos = ""
            Else
                tratamientos = RTrim(dtRegistro.Rows(0)("tratamiento"))
            End If

        Else
            DialogResult = Windows.Forms.DialogResult.Cancel
        End If

        cargar_tratamientos()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If tratamientos <> "" Then
                sqlExecute("update bitacora_enfermeria set tratamiento = '" & tratamientos & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
            Else
                sqlExecute("update bitacora_enfermeria set tratamiento = null where id_bitacora = '" & id_bitacora & "'", "sermed")
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception

        End Try
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Dim query As String = ""
            Dim texto As String = RTrim(TextBox1.Text)
            texto = EliminaAcentos(texto)
            texto = texto.Replace(" ", "*")

            For Each s As String In texto.Split("*")
                query &= "(descripcion like '%" & RTrim(s) & "%') AND"
            Next
            query = query.Substring(0, query.Length - 3)


            dgvBusquedaTratamientos.DataSource = dtBusqueda.Select(query).CopyToDataTable

        Catch ex As Exception
            dgvBusquedaTratamientos.DataSource = dtFallback
        End Try
    End Sub

    Private Sub dgvBusquedaTratamientos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvBusquedaTratamientos.SelectionChanged
        Try
            Dim drow As DataGridViewRow = dgvBusquedaTratamientos.SelectedRows(0)

            Dim recurso As String = RTrim(drow.Cells("ColumnRecurso").Value)
            txtRecurso.Text = recurso
            txtRecurso.Visible = recurso <> ""

            Dim servicio As String = RTrim(drow.Cells("ColumnServicioTratamiento").Value)
            txtServicio.Text = servicio
            txtServicio.Visible = servicio <> ""

            Dim posologia As String = RTrim(drow.Cells("ColumnPosologia").Value)
            txtPosologia.Text = posologia
            txtPosologia.Visible = posologia <> ""

            Dim tipo As String = RTrim(drow.Cells("ColumnTipoTratamiento").Value)
            txtTipo.Text = tipo
            txtTipo.Visible = tipo <> ""

            Dim dias As String = RTrim(drow.Cells("ColumnDiasTratamiento").Value)
            If dias = "NA" Or dias = "" Then
                txtDiasTratamiento.Visible = False
                LabelDiasTra.Visible = False
                txtDiasTratamiento.Value = 0
            Else
                txtDiasTratamiento.Visible = True
                LabelDiasTra.Visible = True
                txtDiasTratamiento.Value = Integer.Parse(dias)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If Not dgvTratamientos.Visible And (dgvBusquedaTratamientos.SelectedRows.Count > 0) Then

                Dim tratamiento As String = dgvBusquedaTratamientos.SelectedRows(0).Cells("ColumnCodBusqueda").Value
                Dim diastra As String = "0"
                If txtDiasTratamiento.Visible = True Then
                    diastra = txtDiasTratamiento.Value.ToString
                End If

                If tratamientos = "" Then
                    tratamientos = tratamiento & "-" & diastra
                Else
                    tratamientos &= ";" & tratamiento & "-" & diastra
                End If
                cargar_tratamientos()
            End If

            TextBox1.Text = ""

            dgvTratamientos.Visible = Not dgvTratamientos.Visible
            If dgvTratamientos.Visible Then
                LabelVista.Text = "Tratamientos"
            Else
                LabelVista.Text = "Busqueda"
            End If

            btnAgregar.Text = IIf(dgvTratamientos.Visible, "Agregar", "Aceptar")
            btnAceptar.Visible = dgvTratamientos.Visible

            If Not dgvTratamientos.Visible Then
                TextBox1.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargar_tratamientos()

        Try
            dgvTratamientos.AutoGenerateColumns = False
            Dim dtTablaTratamientos As New DataTable
            dtTablaTratamientos.Columns.Add("id_recurso")
            dtTablaTratamientos.Columns.Add("descripcion")
            dtTablaTratamientos.Columns.Add("posologia")
            dtTablaTratamientos.Columns.Add("dias_tratamiento")

            Dim t As String() = tratamientos.Split(";")            

            For Each tratamiento As String In t
                If tratamiento <> "" Then

                    Dim _t As String = tratamiento.Split("-")(0)
                    Dim _d As String = tratamiento.Split("-")(1)

                    Dim _n As String = ""
                    Dim _p As String = ""
                    Dim dtTratamiento As DataTable = sqlExecute("select * from tratamientos where id_recurso = '" & _t & "'", "sermed")
                    If dtTratamiento.Rows.Count > 0 Then
                        _n = dtTratamiento.Rows(0)("descripcion")
                        _p = dtTratamiento.Rows(0)("posologia")
                    End If

                    dtTablaTratamientos.Rows.Add({_t, _n, _p, _d})
                End If
            Next

            dgvTratamientos.DataSource = dtTablaTratamientos

            btnBorrar.Visible = False

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvTratamientos_Click(sender As Object, e As EventArgs) Handles dgvTratamientos.Click
        Try
            If dgvTratamientos.SelectedRows.Count > 0 Then
                btnBorrar.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvTratamientos_DoubleClick(sender As Object, e As EventArgs) Handles dgvBusquedaTratamientos.DoubleClick
        If dgvBusquedaTratamientos.SelectedRows.Count > 0 Then
            btnAgregar.PerformClick()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try

            If dgvTratamientos.SelectedRows.Count > 0 Then
                Dim t As String = ""
                For Each row As DataGridViewRow In dgvTratamientos.Rows
                    If row.Index <> dgvTratamientos.SelectedRows(0).Index Then
                        Dim tratamiento As String = RTrim(row.Cells("ColumnCodTratamiento").Value)
                        Dim diastra As String = "0"

                        Try
                            diastra = RTrim(row.Cells("ColumnDiasTratamientoT").Value)
                        Catch ex As Exception

                        End Try

                        If t = "" Then
                            t = tratamiento & "-" & diastra
                        Else
                            t = t & ";" & tratamiento & "-" & diastra
                        End If
                    End If
                Next

                tratamientos = t
                cargar_tratamientos()
            Else
                MessageBox.Show("Es necesario seleccionar primero un tratamiento a borrar", "Sin tratamiento seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class