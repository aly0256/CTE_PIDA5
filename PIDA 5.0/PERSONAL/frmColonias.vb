Public Class frmColonias

#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region


    Private Sub frmcolonias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_col as 'Código',Nombre FROM colonias")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM colonias ORDER BY cod_col ASC ")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub HabilitarBotones()
        Dim NoRec As Boolean
        NoRec = dgTabla.Rows.Count = 0
        btnPrimero.Enabled = Not (Agregar Or Editar Or NoRec)
        btnAnterior.Enabled = Not (Agregar Or Editar Or NoRec)
        btnSiguiente.Enabled = Not (Agregar Or Editar Or NoRec)
        btnUltimo.Enabled = Not (Agregar Or Editar Or NoRec)

        btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBuscar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBorrar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnCerrar.Enabled = Not (Agregar Or Editar Or NoRec)
        pnlDatos.Enabled = Agregar Or Editar

        btnEditar.Enabled = Not (Not (Editar Or Agregar) And NoRec)


        If Agregar Or Editar Then
            ' Si está activa la edición o nuevo registro
            btnNuevo.Image = PIDA.My.Resources.Ok16
            btnEditar.Image = PIDA.My.Resources.CancelX
            btnNuevo.Text = "Aceptar"
            btnEditar.Text = "Cancelar"
            tabBuscar.SelectedTabIndex = 0
        Else

            btnNuevo.Image = PIDA.My.Resources.NewRecord
            btnEditar.Image = PIDA.My.Resources.Edit

            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"
        End If

        txtCodigo.Enabled = Agregar

        If Agregar Then
            Dim cod_col As String = ""
            cod_col = NoCodConsec()
            txtCodigo.Text = cod_col

            ';  txtCodigo.Text = ""
            txtNombre.Text = ""
            txtCodigo.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If
    End Sub

    Private Function NoCodConsec() As String
        Dim _cod As String = "", dtCodCol As DataTable

        Try
            dtCodCol = sqlExecute("SELECT TOp 1 COD_COL from colonias order by COD_COL desc", "PERSONAL")
            If Not dtCodCol.Columns.Contains("Error") And dtCodCol.Rows.Count > 0 Then
                Dim _cod_Int As Integer = 0
                Try : _cod_Int = Integer.Parse(dtCodCol.Rows(0).Item("COD_COL").ToString.Trim) : Catch ex As Exception : _cod_Int = 0 : End Try

                _cod_Int += 1

                _cod = _cod_Int.ToString.Trim.PadLeft(4, "0")
            Else
                _cod = "0001"
            End If

            Return _cod
        Catch ex As Exception
            Return _cod
        End Try

    End Function
    Private Sub MostrarInformacion()
        Dim i As Integer
        On Error Resume Next

        txtCodigo.Text = dtRegistro.Rows(0).Item("cod_col")
        txtNombre.Text = dtRegistro.Rows(0).Item("nombre").tostring.trim
        txtUMF.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("umf")), "", dtRegistro.Rows(0).Item("umf"))
        txtCp.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("cp")), "", dtRegistro.Rows(0).Item("cp"))
        If Not DesdeGrid Then
            i = dtLista.DefaultView.Find(txtCodigo.Text)
            If i >= 0 Then
                dgTabla.FirstDisplayedScrollingRowIndex = i
                dgTabla.Rows(i).Selected = True
            End If
        End If
        DesdeGrid = False
        HabilitarBotones()
    End Sub

    Private Sub btnCiasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("colonias", "cod_col", "colonias", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from colonias WHERE cod_col = '" & Cod & "'")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("colonias", "cod_col", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("colonias", "cod_col", txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("colonias", "cod_col", txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String
        codigo = txtCodigo.Text
        dtTemporal = sqlExecute("SELECT reloj from personalvw WHERE cod_col = '" & codigo & "'")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM colonias WHERE cod_col = '" & codigo & "'")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, nom As String

        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value
        nom = dgTabla.Item("Nombre", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * from colonias WHERE cod_col = '" & cod & "'")
        MostrarInformacion()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
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

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Ultimo("colonias", "cod_col", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe cod_col
            dtTemporal = sqlExecute("SELECT cod_col FROM colonias where cod_col = '" & txtCodigo.Text & "'")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe la colonia '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                sqlExecute("INSERT INTO colonias (cod_col,nombre,cp,umf) VALUES ('" & txtCodigo.Text & "','" & txtNombre.Text & "','" & txtCp.Text & "','" & txtUMF.Text & "')")
                Agregar = False
            End If

        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE colonias SET nombre = '" & txtNombre.Text & "', umf = '" & txtCp.Text & "',cp = '" & txtUMF.Text & "' WHERE cod_col = '" & txtCodigo.Text & "'")
        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("Colonias", sqlExecute("select * from colonias"))
        frmVistaPrevia.ShowDialog()
    End Sub
    'Private Sub dgTabla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellClick
    '    Dim colonia As String = dgTabla.Rows(e.RowIndex).Cells("Código").Value
    '    dtRegistro = sqlExecute("SELECT * from colonias WHERE cod_col = '" & colonia & "'")
    '    MostrarInformacion()
    'End Sub
End Class