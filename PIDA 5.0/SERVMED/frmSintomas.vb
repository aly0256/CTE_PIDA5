Public Class frmSintomas
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtCias As New DataTable         'Tabla de compañías
    Dim dtSubsintomas As New DataTable

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim a As String
#End Region

    Private Sub Sintomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("select  sintomas.cod_grupo + ' - ' + grupos_sintomas.nombre as titulo, sintomas.cod_grupo, grupos_sintomas.nombre as grupo, sintomas.cod_sintoma , sintomas.nombre as sintoma from sintomas left join grupos_sintomas on grupos_sintomas.cod_grupo = sintomas.cod_grupo", "sermed")

            AdvTree1.DataSource = dtLista
            AdvTree1.DisplayMembers = "cod_grupo, grupo, cod_sintoma, sintoma"
            AdvTree1.GroupingMembers = "titulo"
            AdvTree1.ValueMember = "cod_sintoma"
            AdvTree1.DeepSort = True

            For Each n As DevComponents.AdvTree.Node In AdvTree1.Nodes
                AddHandler n.NodeMouseUp, AddressOf Node1_NodeMouseUp
            Next

            dtCias = sqlExecute("SELECT * FROM grupos_sintomas", "sermed")
            cmbCodigo.DataSource = dtCias
            cmbCodigo.ValueMember = "cod_grupo"

            dtSubsintomas = sqlExecute("select cod_sintoma,rtrim(nombre) from sintomas", "sermed")

            dtRegistro = sqlExecute("SELECT sintomas.* FROM sintomas left join grupos_sintomas on sintomas.cod_grupo=grupos_sintomas.cod_grupo ORDER BY cod_sintoma ASC", "sermed")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub HabilitarBotones()
        Dim NoRec As Boolean
        NoRec = dtLista.Rows.Count = 0


        btnPrimero.Enabled = Not (Agregar Or Editar Or NoRec)
        btnAnterior.Enabled = Not (Agregar Or Editar Or NoRec)
        btnSiguiente.Enabled = Not (Agregar Or Editar Or NoRec)
        btnUltimo.Enabled = Not (Agregar Or Editar Or NoRec)

        btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBuscar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBorrar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnCerrar.Enabled = Not (Agregar Or Editar Or NoRec)
        pnlDatos.Enabled = Agregar Or Editar
        btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)

        btnNuevo.Enabled = Not (Not (Editar Or Agregar) And DesdeGrid)
        btnEditar.Enabled = Not (Not (Editar Or Agregar) And DesdeGrid)

        If Agregar Or Editar Then

            'Si está activa la edición o nuevo registro
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

        cmbCodigo.Enabled = Agregar
        If Agregar Then
            cmbCodigo.SelectedIndex = -1
            txtNombre.Text = ""
            txtCodigo.Text = ""
            txtNombre.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If
    End Sub
    Private Sub MostrarInformacion()
        Dim cadena As String()
        cadena = AdvTree1.SelectedNode.ToString.Split(",")
        Try
            If True Then
                cmbCodigo.SelectedValue = dtRegistro.Rows(0).Item("cod_grupo")
                txtCodigo.Text = dtRegistro.Rows(0).Item("cod_sintoma").ToString.Trim
                txtNombre.Text = dtRegistro.Rows(0).Item("nombre").ToString.Trim
            Else
                cmbCodigo.SelectedValue = AdvTree1.SelectedNode.ToString.Substring(0, 1)
                txtCodigo.Text = cadena(2).Trim
                txtNombre.Text = cadena(3).Trim
            End If
            HabilitarBotones()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCiasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("sermed.dbo.sintomas", "cod_sintoma", "SINTOMAS", False, "Nombre")
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM sintomas WHERE cod_sintoma = '" & Cod & "'", "sermed")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("sintomas", "cod_sintoma", dtRegistro, "sermed")
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Dim codenf As String
        codenf = txtNombre.Text.Split(" ")(0)
        Anterior("sintomas", "(cod_grupo + cod_sintoma)", cmbCodigo.SelectedValue + txtCodigo.Text, dtRegistro, "sermed")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("sintomas", "(cod_grupo + cod_sintoma)", cmbCodigo.SelectedValue + txtCodigo.Text, dtRegistro, "sermed")
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("sintomas", "cod_sintoma", dtRegistro, "sermed")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim codsin As String
        Dim cadena As String()
        cadena = AdvTree1.SelectedNode.ToString.Split(",")
        cmbCodigo.SelectedValue = AdvTree1.SelectedNode.ToString.Substring(0, 1)
        txtCodigo.Text = cadena(2).Trim
        Codigo = cmbCodigo.SelectedValue
        codsin = txtCodigo.Text

        If MessageBox.Show("¿Está seguro de borrar el registro " & IIf(Not DesdeGrid, txtNombre.Text, cadena(3).Trim) & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            sqlExecute("DELETE FROM sintomas WHERE cod_grupo = '" & IIf(Not DesdeGrid, cmbCodigo.SelectedValue, AdvTree1.SelectedNode.ToString.Substring(0, 1)) & "' and cod_sintoma='" & IIf(Not DesdeGrid, codsin, cadena(2).Trim) & "'", "sermed")
            btnSiguiente.PerformClick()
            RefrescarArbol()
        End If
    End Sub
    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        On Error Resume Next

        Dim cod As String, nom As String

        DesdeGrid = True

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            HabilitarBotones()
            txtNombre.Focus()
        Else
            Editar = False
        End If
        Agregar = False
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If Agregar Then
            If Not DesdeGrid Then
                dtTemporal = sqlExecute("select * from sintomas where cod_sintoma = '" & txtCodigo.Text.Trim & "'", "sermed")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe la síntoma '" & txtCodigo.Text & "' asignado al grupo '" & cmbCodigo.SelectedValue & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                Else
                    sqlExecute("insert into sintomas (cod_grupo, cod_sintoma, nombre) values ('" & cmbCodigo.SelectedValue.ToString.Trim & "', '" & txtCodigo.Text.Trim & "', '" & txtNombre.Text & "')", "sermed")
                    Agregar = False
                End If
            Else

            End If
            ' Si Agregar, revisar si existe cod_comp+cod_clase


        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            If DesdeGrid Then
                txtNombre.Text = LTrim(AdvTree1.SelectedNode.ToString.Split(",").Last)
                Dim s As String = AdvTree1.SelectedNode.ToString
                sqlExecute("UPDATE sintomas SET nombre = '" & RTrim(txtNombre.Text) & "' WHERE cod_sintoma = '" & Trim(txtCodigo.Text) & "'", "sermed")
                AdvTree1.SelectedNode.Editable = False
                RefrescarArbol()
            Else
                sqlExecute("UPDATE sintomas SET nombre = '" & txtNombre.Text & "' WHERE cod_sintoma = '" & txtCodigo.Text & "'", "sermed")
            End If
        Else
            Agregar = True
        End If
        Editar = False
        HabilitarBotones()
    End Sub

    Private Sub AdvTree1_SelectedValueChanged(sender As Object, e As EventArgs) Handles AdvTree1.SelectedValueChanged
        Try
            Dim cod As String = RTrim(AdvTree1.SelectedNode.Parent.ToString)
            dtRegistro = sqlExecute("SELECT * from sintomas WHERE cod_grupo = '" & cod & "'", "sermed")
         
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCodigo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCodigo.SelectedValueChanged
        Try
            If Agregar Then
                Dim nuevo_cod As String = ""

                Dim dtCodigoSiguiente As DataTable = sqlExecute("select top 1 cod_grupo, cast(replace(cod_sintoma, '" & IIf(False, RTrim(AdvTree1.SelectedNode.Parent.ToString), cmbCodigo.SelectedValue.ToString.Trim) & "', '') as int) as contador from sintomas where cod_grupo = '" & IIf(DesdeGrid, RTrim(AdvTree1.SelectedNode.Parent.ToString), cmbCodigo.SelectedValue) & "' order by contador desc", "sermed")
                If dtCodigoSiguiente.Rows.Count Then
                    nuevo_cod = dtCodigoSiguiente.Rows(0)("cod_grupo").ToString.Trim & (dtCodigoSiguiente.Rows(0)("contador") + 1).ToString.PadLeft(3, "0")
                Else
                    nuevo_cod = IIf(False, RTrim(AdvTree1.SelectedNode.Parent.ToString), cmbCodigo.SelectedValue.ToString.Trim) & "001"
                End If
                txtCodigo.Text = nuevo_cod.Trim
                txtNombre.Text = ""
            ElseIf Editar Then
                dtRegistro = sqlExecute("SELECT TOP 1 * FROM sintomas WHERE cod_grupo='" & IIf(False, RTrim(AdvTree1.SelectedNode.Parent.ToString), cmbCodigo.SelectedValue) & "'", "sermed")
                MostrarInformacion()
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefrescarArbol()
        dtLista = sqlExecute("select sintomas.cod_grupo + ' - ' + grupos_sintomas.nombre as titulo, sintomas.cod_grupo, grupos_sintomas.nombre as grupo, sintomas.cod_sintoma , sintomas.nombre as sintoma from sintomas left join grupos_sintomas on grupos_sintomas.cod_grupo = sintomas.cod_grupo", "sermed")
        AdvTree1.DataSource = dtLista
        AdvTree1.DisplayMembers = "cod_grupo, grupo, cod_sintoma, sintoma"
        AdvTree1.GroupingMembers = "titulo"
        AdvTree1.ValueMember = "cod_sintoma"

        For Each n As DevComponents.AdvTree.Node In AdvTree1.Nodes
            AddHandler n.NodeMouseUp, AddressOf Node1_NodeMouseUp
        Next
    End Sub

    Private Sub tabTabla_Click(sender As Object, e As EventArgs) Handles tabTabla.Click
        DesdeGrid = True
        HabilitarBotones()
        RefrescarArbol()
    End Sub

    Private Sub AdvTree1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AdvTree1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then

        End If
    End Sub


    Private Sub Node1_NodeClick(sender As Object, e As EventArgs) Handles Node1.NodeClick
        MessageBox.Show(e.GetType.ToString)
    End Sub

    Private Sub Node1_NodeMouseUp(sender As Object, e As MouseEventArgs) ' Handles Node1.NodeMouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim n As DevComponents.AdvTree.Node = TryCast(sender, DevComponents.AdvTree.Node)
            If n IsNot Nothing Then
                'MessageBox.Show(n.Text)
                AgregarToolStripMenuItem.Text = "Agregar nuevo: " & n.Text.Trim
                grupo = n.Text.Split("-")(0).Trim
                Dim MousePosition As Point
                MousePosition = Cursor.Position
                ContextMenuStrip1.Show(MousePosition)

            End If
        End If
    End Sub

    Dim grupo As String = "X"

    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click
        If True Then
            Dim g As String = grupo.ToUpper.Trim
            grupo = "X"
            Dim nuevo_codigo As String = g
            Dim dtSiguiente As DataTable = sqlExecute("select * from sermed.dbo.sintomas where cod_grupo = '" & g & "' order by cod_sintoma desc")
            If dtSiguiente.Rows.Count >= 0 Then
                Dim n As Integer = Integer.Parse(dtSiguiente.Rows(0)("cod_sintoma").ToString.Trim.Replace(g, "")) + 1
                nuevo_codigo = g & n.ToString.PadLeft(3, "0")
            End If
            sqlExecute("insert into sintomas (cod_grupo, cod_sintoma, nombre) values ('" & g & "', '" & nuevo_codigo & "', 'Introduzca nuevo síntoma')", "sermed")
            RefrescarArbol()
            Try
                For Each n As DevComponents.AdvTree.Node In AdvTree1.Nodes
                    If n.HasChildNodes Then
                        For Each n_ As DevComponents.AdvTree.Node In n.Nodes
                            If n_.Cells(2).Text.Trim = nuevo_codigo Then
                                Dim c As DevComponents.AdvTree.Cell = n_.Cells(3)
                                n_.SelectedCell = c
                                n_.BeginEdit(3)
                                Exit For
                            End If
                        Next
                    End If
                Next
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub AdvTree1_CellEditEnding(sender As Object, e As DevComponents.AdvTree.CellEditEventArgs) Handles AdvTree1.AfterCellEditComplete
        Try
            For Each n As DevComponents.AdvTree.Node In AdvTree1.Nodes
                If n.HasChildNodes Then
                    For Each n_ As DevComponents.AdvTree.Node In n.Nodes
                        sqlExecute("update sintomas set nombre = '" & n_.Cells(3).Text.Trim & "' where cod_sintoma = '" & n_.Cells(2).Text.Trim & "'", "sermed")
                    Next
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tabEmpleado_Click(sender As Object, e As EventArgs) Handles tabEmpleado.Click
        DesdeGrid = False
        HabilitarBotones()
    End Sub

    Private Sub AdvTree1_Enter(sender As Object, e As EventArgs) Handles AdvTree1.Enter
        On Error Resume Next
        Dim cadena As String()
        cadena = AdvTree1.SelectedNode.ToString.Split(",")
        Dim cod As String, nom As String

        DesdeGrid = True
        dtRegistro = sqlExecute("SELECT * from sintomas WHERE cod_sintoma = '" & cadena(2).Trim & "'", "sermed")
        MostrarInformacion()

    End Sub
End Class