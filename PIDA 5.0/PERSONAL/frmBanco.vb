Public Class frmBanco
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtCias As New DataTable         'Tabla de compañías

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region


    Private Sub frmbanco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT * FROM bancos")

            dtLista.DefaultView.Sort = "banco"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM bancos ORDER BY banco ASC")
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
        btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)


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

        'txtNombre.Enabled = Agregar
        txtCodigo.Enabled = Agregar
        If Agregar Then
            txtNombre.Text = ""
            txtCodigo.Text = ""
            txtNombre.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If
    End Sub
    Private Sub MostrarInformacion()
        Dim i As Integer

        'txtCodigo.Text = dtRegistro.Rows(0).Item("cod_banco")
        txtNombre.Text = dtRegistro.Rows(0).Item("banco")
        If Not DesdeGrid Then
            i = dtLista.DefaultView.Find(RTrim(RTrim(txtNombre.Text)))
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
        Me.Dispose()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("bancos", "banco", "BANCOS", False, "Banco")
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT banco FROM bancos")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("bancos", "banco", dtRegistro)
        MostrarInformacion()
    End Sub
    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("bancos", "banco", RTrim(txtNombre.Text), dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("bancos", "banco", RTrim(txtNombre.Text), dtRegistro)
        MostrarInformacion()
    End Sub
    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Ultimo("bancos", "banco", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Codigo = txtNombre.Text
        dtTemporal = sqlExecute("SELECT reloj from personalvw WHERE banco = '" & RTrim(txtNombre.Text) & "'")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & RTrim(txtNombre.Text) & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM bancos WHERE banco = '" & RTrim(txtNombre.Text) & "'")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, bancos As String

        DesdeGrid = True

        'cod = dgTabla.Item("Código", e.RowIndex).Value
        bancos = dgTabla.Rows(e.RowIndex).Cells("banco").Value
        dtRegistro = sqlExecute("SELECT * from bancos WHERE banco = '" & bancos & "'")
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



    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe banco
            dtTemporal = sqlExecute("SELECT banco FROM bancos where banco = '" & RTrim(txtNombre.Text) & "'")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe el banco '" & RTrim(txtNombre.Text) & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNombre.Focus()
                Exit Sub
            Else
                sqlExecute("INSERT INTO bancos (banco) VALUES ('" & RTrim(txtNombre.Text) & "')")
                Agregar = False
            End If

        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE bancos SET banco = '" & RTrim(txtNombre.Text) & "'")
        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()
    End Sub


    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        'frmVistaPrevia.MdiParent = frmMain
        frmVistaPrevia.LlamarReporte("Bancos", sqlExecute("select * from bancos"))
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub dgTabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellContentClick

    End Sub

    Private Sub dgTabla_RowErrorTextChanged(sender As Object, e As DataGridViewRowEventArgs) Handles dgTabla.RowErrorTextChanged

    End Sub
    'Private Sub dgTabla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellClick
    '    Dim bancos As String = dgTabla.Rows(e.RowIndex).Cells("banco").Value
    '    dtRegistro = sqlExecute("SELECT * from bancos WHERE banco = '" & bancos & "'")
    '    MostrarInformacion()
    'End Sub

End Class