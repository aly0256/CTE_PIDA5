Public Class frmSeleccionarSintomas

    Public id_bitacora As String = ""
    Private sintomas As String = ""

    Dim path_fotos As String = ""

    Private dtBusqueda As New DataTable
    Private dtFallback As New DataTable

    Private Sub llenar_busqueda()
        Try
            dtBusqueda.Columns.Add("cod_sin")
            dtBusqueda.Columns.Add("nombre")
            dtBusqueda.Columns.Add("imagen")

            dtFallback = dtBusqueda.Clone

            Dim dtSintomas As DataTable = sqlExecute("select * from arbol_sintomas where parent is null", "sermed")
            For Each row As DataRow In dtSintomas.Rows
                Dim codigo As String = RTrim(row("cod_sin"))
                Dim nombre As String = EliminaAcentos(RTrim(row("nombre")))
                Dim imagen As String = IIf(IsDBNull(row("imagen")), "", Trim(row("imagen").ToString))

                llenar_busqueda(codigo, nombre)
            Next

            dgvBusquedaSintomas.DataSource = dtBusqueda

        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenar_busqueda(cod_sin As String, parents As String)
        Try
            Dim dtSintomas As DataTable = sqlExecute("select * from arbol_sintomas where parent = '" & cod_sin & "'", "sermed")
            For Each row As DataRow In dtSintomas.Rows
                Dim codigo As String = RTrim(row("cod_sin"))
                Dim nombre As String = parents & " - " & RTrim(row("nombre"))
                Dim imagen As String = IIf(IsDBNull(row("imagen")), "", Trim(row("imagen").ToString))

                dtBusqueda.Rows.Add({codigo, nombre, imagen})
                llenar_busqueda(codigo, nombre)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmSeleccionarSintomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        llenar_busqueda()

        Dim dtPathFotos As DataTable = sqlExecute("select * from parametros_sermed where path_foto is not null", "sermed")
        If dtPathFotos.Rows.Count > 0 Then
            path_fotos = RTrim(dtPathFotos.Rows(0)("path_foto"))
            If Not System.IO.Directory.Exists(path_fotos) Then
                System.IO.Directory.CreateDirectory(path_fotos)
            End If            
        Else
            MessageBox.Show("No se ha especificado el directorio de imágenes, las ayudas visuales no se podrán modificar", "Directorio de imágenes", MessageBoxButtons.OK, MessageBoxIcon.Warning)            
        End If
        Dim img As String = path_fotos & dgvBusquedaSintomas.SelectedRows(0).Cells("columnaimagen").Value
        PictureBox1.ImageLocation = img
        Dim dtRegistro As DataTable = sqlExecute("select * from bitacora_enfermeria where id_bitacora = '" & id_bitacora & "'", "sermed")
        If dtRegistro.Rows.Count > 0 Then
            txtReloj.Text = dtRegistro.Rows(0)("reloj")
            Dim dtPersonal As DataTable = sqlExecute("select * from personalvw where reloj = '" & txtReloj.Text & "'")
            If dtPersonal.Rows.Count > 0 Then
                txtNombres.Text = dtPersonal.Rows(0)("nombres")
            End If

            If IsDBNull(dtRegistro.Rows(0)("sintomas")) Then
                sintomas = ""
            Else
                sintomas = RTrim(dtRegistro.Rows(0)("sintomas"))
            End If

        Else
            DialogResult = Windows.Forms.DialogResult.Cancel
        End If

        cargar_sintomas()

    End Sub


    Private Sub cargar_sintomas()

        Try
            dgvSintomas.AutoGenerateColumns = False
            Dim dtTablaSintomas As New DataTable
            dtTablaSintomas.Columns.Add("cod_sin")
            dtTablaSintomas.Columns.Add("descripcion")

            Dim s As String() = sintomas.Split(";")
            Dim c As String = ""

            For Each sintoma As String In s
                If sintoma <> "" Then
                    Dim s_ As String = sintoma
                    c = ""
                    Dim parent As Boolean = True

                    While parent
                        Dim dtCodSin As DataTable = sqlExecute("select * from arbol_sintomas where cod_sin = '" & s_ & "'", "sermed")
                        If dtCodSin.Rows.Count > 0 Then
                            If sintoma = s_ Then
                                c = RTrim(dtCodSin.Rows(0)("nombre"))
                            Else
                                c = RTrim(dtCodSin.Rows(0)("nombre")) & " - " & c
                            End If

                            If IsDBNull(dtCodSin.Rows(0)("parent")) Then
                                parent = False
                            Else
                                s_ = RTrim(dtCodSin.Rows(0)("parent"))
                            End If
                        Else
                            parent = False
                        End If
                    End While
                    dtTablaSintomas.Rows.Add({sintoma, c})
                End If
            Next

            dgvSintomas.DataSource = dtTablaSintomas

            btnBorrar.Visible = False

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If sintomas <> "" Then
                sqlExecute("update bitacora_enfermeria set sintomas = '" & sintomas & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
            Else
                sqlExecute("update bitacora_enfermeria set sintomas = null where id_bitacora = '" & id_bitacora & "'", "sermed")
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If Not dgvSintomas.Visible And (dgvBusquedaSintomas.SelectedRows.Count > 0) Then
                Dim sintoma As String = dgvBusquedaSintomas.SelectedRows(0).Cells("ColumnCodSinBusqueda").Value
                If sintomas = "" Then
                    sintomas = sintoma
                Else
                    sintomas &= ";" & sintoma
                End If
                cargar_sintomas()
            End If

            TextBox1.Text = ""

            dgvSintomas.Visible = Not dgvSintomas.Visible
            If dgvSintomas.Visible Then
                LabelVista.Text = "Síntomas"
            Else
                LabelVista.Text = "Busqueda"
            End If

            btnAgregar.Text = IIf(dgvSintomas.Visible, "Agregar", "Aceptar")
            btnAgregar.Image = IIf(dgvSintomas.Visible, My.Resources.Add, My.Resources.Ok16)
            btnAceptar.Visible = dgvSintomas.Visible

            If Not dgvSintomas.Visible Then
                TextBox1.Focus()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            If dgvSintomas.SelectedRows.Count > 0 Then
                Dim s As String = ""
                For Each row As DataGridViewRow In dgvSintomas.Rows
                    If row.Index <> dgvSintomas.SelectedRows(0).Index Then
                        If s = "" Then
                            s = RTrim(row.Cells("ColumnCodSintoma").Value)
                        Else
                            s = s & ";" & RTrim(row.Cells("ColumnCodSintoma").Value)
                        End If
                    End If
                Next

                sintomas = s
                cargar_sintomas()
            Else
                MessageBox.Show("Es necesario seleccionar primero un síntoma a borrar", "Sin síntoma seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvSintomas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSintomas.Click
        Try
            If dgvSintomas.SelectedRows.Count > 0 Then
                btnBorrar.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs)
        Try
            Dim frm As New frmCatArbolSintomas
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                cargar_sintomas()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        Try
            Cursor = Cursors.Cross
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        Try
            Cursor = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            Dim frm As New frmFoto
            frm.Text = "Ayuda visual"
            frm.Width = 940
            frm.Height = 720
            frm.picFoto.ImageLocation = PictureBox1.ImageLocation
            frm.ShowDialog()
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
                query &= "(nombre like '%" & RTrim(s) & "%') AND"
            Next
            query = query.Substring(0, query.Length - 3)


            dgvBusquedaSintomas.DataSource = dtBusqueda.Select(query).CopyToDataTable

        Catch ex As Exception
            dgvBusquedaSintomas.DataSource = dtFallback
        End Try
    End Sub

    Private Sub dgvSintomas_DoubleClick(sender As Object, e As EventArgs) Handles dgvBusquedaSintomas.DoubleClick
        If dgvBusquedaSintomas.SelectedRows.Count > 0 Then
            btnAgregar.PerformClick()
        End If
    End Sub

    Private Sub dgvBusquedaSintomas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBusquedaSintomas.CellClick
        If dgvBusquedaSintomas.SelectedRows(0).Cells("columnaimagen").Value <> "" Then
            Dim img As String = path_fotos & dgvBusquedaSintomas.SelectedRows(0).Cells("columnaimagen").Value
            PictureBox1.ImageLocation = img
        Else
            PictureBox1.Image = My.Resources.NoImagen
        End If
    End Sub
End Class