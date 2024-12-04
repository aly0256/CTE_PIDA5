Public Class frmCatArbolSintomas

    Dim path_fotos As String = ""

    Private Sub frmCatArbolSintomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtPathFotos As DataTable = sqlExecute("select * from parametros_sermed where path_foto is not null", "sermed")
        If dtPathFotos.Rows.Count > 0 Then
            path_fotos = RTrim(dtPathFotos.Rows(0)("path_foto"))
            If Not System.IO.Directory.Exists(path_fotos) Then
                System.IO.Directory.CreateDirectory(path_fotos)
            End If
            btnEditarImagen.Visible = True
        Else
            MessageBox.Show("No se ha especificado el directorio de imágenes, las ayudas visuales no se podrán modificar", "Directorio de imágenes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnEditarImagen.Visible = False
        End If

        llenar_arbol()
    End Sub

    Private Sub llenar_arbol()
        Try
            Dim dtSintomas As DataTable = sqlExecute("select * from arbol_sintomas where parent is null", "sermed")
            AdvSintomas.Nodes.Clear()
            For Each row As DataRow In dtSintomas.Rows
                Dim n As New DevComponents.AdvTree.Node
                n.Tag = RTrim(row("cod_sin"))
                n.Name = n.Tag
                n.Text = (RTrim(row("nombre")))
                agregar_nodos(n)
                AdvSintomas.Nodes.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub agregar_nodos(n As DevComponents.AdvTree.Node)
        Try
            Dim cod_sin As String = n.Tag
            Dim dtSintomas As DataTable = sqlExecute("select * from arbol_sintomas where parent = '" & cod_sin & "'", "sermed")
            For Each row As DataRow In dtSintomas.Rows
                Dim n_ As New DevComponents.AdvTree.Node
                n_.Tag = row("cod_sin")
                n_.Text = (RTrim(row("nombre")))
                agregar_nodos(n_)
                n.Nodes.Add(n_)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Dim nodo_seleccionado As DevComponents.AdvTree.Node

    Private Sub AdvSintomas_NodeDoubleClick(sender As Object, e As DevComponents.AdvTree.TreeNodeMouseEventArgs) Handles AdvSintomas.NodeDoubleClick
        Try
            nodo_seleccionado = e.Node
            AgregarNivelToolStripMenuItem.PerformClick()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AdvSintomas_NodeClick(sender As Object, e As DevComponents.AdvTree.TreeNodeMouseEventArgs) Handles AdvSintomas.NodeClick
        Try
            nodo_seleccionado = e.Node

            If e.Button = Windows.Forms.MouseButtons.Right Then

                AgregarNivelToolStripMenuItem.Text = "Agregar nivel a " & e.Node.Text.Trim
                ContextMenuStrip1.Show(frmCapturaCursosMasivos.MousePosition)
            Else
                Dim dtIMG As DataTable = sqlExecute("select * from arbol_sintomas where cod_sin = '" & e.Node.Tag & "' and imagen is not null and imagen <> ''", "sermed")
                If dtIMG.Rows.Count > 0 Then
                    Dim img As String = path_fotos & RTrim(dtIMG.Rows(0)("imagen"))
                    PictureBox1.ImageLocation = img
                Else
                    PictureBox1.Image = My.Resources.NoImagen
                End If

                lblCadena.Text = e.Node.Text
                Dim n__ As DevComponents.AdvTree.Node = e.Node
                While n__.Parent IsNot Nothing
                    lblCadena.Text = n__.Parent.Text & " - " & lblCadena.Text
                    n__ = n__.Parent
                End While

                If e.Node.HasChildNodes Then
                    AdvSintomas.CollapseAll()
                    Dim n As DevComponents.AdvTree.Node = e.Node
                    While n.Parent IsNot Nothing
                        n.Parent.Expand()
                        n = n.Parent
                    End While
                    e.Node.Expand()
                    AdvSintomas.SelectedNode = e.Node
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AgregarNivelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarNivelToolStripMenuItem.Click
        Try
            Dim frm As New frmAgregarNivelSintomas
            Dim parent As String = nodo_seleccionado.Tag

            frm.id_parent = nodo_seleccionado.Tag
            frm.label = nodo_seleccionado.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                llenar_arbol()                
                Dim n As DevComponents.AdvTree.Node = encontrar(AdvSintomas.Nodes, parent)
                If n IsNot Nothing Then
                    n.Expand()
                    While n.Parent IsNot Nothing
                        n = n.Parent
                        n.Expand()
                    End While
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function encontrar(nodes As DevComponents.AdvTree.NodeCollection, tag As String) As DevComponents.AdvTree.Node
        For Each n As DevComponents.AdvTree.Node In nodes
            If n.Tag = tag Then
                Return n
            Else
                If n.HasChildNodes Then
                    Dim n_ As DevComponents.AdvTree.Node = encontrar(n.Nodes, tag)
                    If n_ IsNot Nothing Then
                        Return n_                    
                    End If               
                End If                
            End If
        Next    
    End Function

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Try
            Dim dtUtilizado As DataTable = sqlExecute("select * from bitacora_personal where sintomas like '%" & nodo_seleccionado.Tag & "%'")
            If dtUtilizado.Rows.Count > 0 Then
                MessageBox.Show("El síntoma " & nodo_seleccionado.Text.Trim & " ya ha sido utilizado en " & dtUtilizado.Rows.Count & " ocasiones, contacte al administrador del sistema en caso de necesitar eliminarlo", "Eliminar síntoma", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Else
                If MessageBox.Show("¿Está seguro de eliminar el síntoma " & nodo_seleccionado.Text.Trim & "? ", "Eliminar síntoma", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    Dim parent As String = "'"
                    If nodo_seleccionado.Parent IsNot Nothing Then
                        parent = nodo_seleccionado.Parent.Tag
                    End If

                    sqlExecute("delete from arbol_sintomas where cod_sin = '" & nodo_seleccionado.Tag & "'", "sermed")

                    llenar_arbol()
                    If parent <> "" Then
                        Dim n As DevComponents.AdvTree.Node = encontrar(AdvSintomas.Nodes, parent)
                        If n IsNot Nothing Then
                            n.Expand()
                            While n.Parent IsNot Nothing
                                n = n.Parent
                                n.Expand()
                            End While
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnEditarImagen_Click(sender As Object, e As EventArgs) Handles btnEditarImagen.Click
        Try
            Dim frm As New OpenFileDialog
            frm.Multiselect = False

            Dim id_sintoma As Integer = Integer.Parse(nodo_seleccionado.Tag)

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim dtActual As DataTable = sqlExecute("select cod_sin, rtrim(isnull(imagen, '')) as imagen from arbol_sintomas where cod_sin = '" & id_sintoma & "'", "sermed")
                If dtActual.Rows.Count > 0 Then
                    Dim actual As String = RTrim(dtActual.Rows(0)("imagen"))

                    Dim img As Image = Image.FromFile(frm.FileName)

                    img.Save(path_fotos & frm.SafeFileName)

                    actualizar_imagen(id_sintoma, frm.SafeFileName, actual)

                    Dim parent As String = "'"
                    If nodo_seleccionado.Parent IsNot Nothing Then
                        parent = nodo_seleccionado.Parent.Tag
                    End If

                    llenar_arbol()
                    If parent <> "" Then
                        Dim n As DevComponents.AdvTree.Node = encontrar(AdvSintomas.Nodes, parent)
                        If n IsNot Nothing Then
                            n.Expand()
                            While n.Parent IsNot Nothing
                                n = n.Parent
                                n.Expand()
                            End While
                        End If
                    End If
                Else
                    Exit Sub
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub actualizar_imagen(id_sintoma As String, nueva As String, anterior As String)
        Try
            sqlExecute("update arbol_sintomas set imagen = '" & nueva & "' where cod_sin = '" & id_sintoma & "'", "sermed")

            Dim dtHijos As DataTable = sqlExecute("select cod_sin, rtrim(isnull(imagen, '')) as imagen from arbol_sintomas where parent = '" & id_sintoma & "'", "sermed")
            For Each row As DataRow In dtHijos.Rows
                Dim actual As String = RTrim(row("imagen"))
                If actual = "" Or actual = anterior Then
                    actualizar_imagen(row("cod_sin"), nueva, actual)
                End If
            Next
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

    Private Sub PictureBox1_DoubleClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.Click
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

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        Try
            Dim frm As New frmAgregarNivelSintomas

            Dim parent As String = "'"

            If nodo_seleccionado.Parent IsNot Nothing Then
                parent = nodo_seleccionado.Parent.Tag
            End If

            frm.id_parent = parent
            frm.cod_sin = nodo_seleccionado.Tag
            frm.editar = True

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                llenar_arbol()
                If parent <> "" Then
                    Dim n As DevComponents.AdvTree.Node = encontrar(AdvSintomas.Nodes, parent)
                    If n IsNot Nothing Then
                        n.Expand()
                        While n.Parent IsNot Nothing
                            n = n.Parent
                            n.Expand()
                        End While
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class