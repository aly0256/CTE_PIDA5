Public Class frmClasificacionesHerramientas
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region
    Private Sub frmClasificaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT COD_CLAS as 'Código',NOMBRE as 'Nombre' FROM clasificacion", "HERRAMIENTAS")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM clasificacion ORDER BY COD_CLAS ASC", "HERRAMIENTAS")
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
        tabTabla.Enabled = Not (Agregar Or Editar Or NoRec)
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
            txtCodigo.Text = ""
            txtNombre.Text = ""
            txtCodigo.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If

    End Sub
    Private Sub MostrarInformacion()
        Dim i As Integer
        On Error Resume Next
        txtCodigo.Text = dtRegistro.Rows(0).Item("COD_CLAS")
        txtNombre.Text = dtRegistro.Rows(0).Item("NOMBRE").ToString.Trim
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

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("HERRAMIENTAS.dbo.clasificacion", "COD_CLAS", "NOMBRE", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from clasificacion WHERE COD_CLAS = '" & Cod & "'", "HERRAMIENTAS")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("clasificacion", "COD_CLAS", dtRegistro, "HERRAMIENTAS")
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("clasificacion", "COD_CLAS", txtCodigo.Text, dtRegistro, "HERRAMIENTAS")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("clasificacion", "COD_CLAS", txtCodigo.Text, dtRegistro, "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Ultimo("clasificacion", "COD_CLAS", dtRegistro, "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String
        codigo = txtCodigo.Text
        dtTemporal = sqlExecute("SELECT COD_ART FROM articulos WHERE COD_CLAS = '" & codigo & "'", "HERRAMIENTAS")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a alguna herramienta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                dtTemporal = sqlExecute("DELETE FROM clasificacion WHERE COD_CLAS = '" & codigo & "'", "HERRAMIENTAS")
                dtLista = sqlExecute("SELECT COD_CLAS as 'Código',NOMBRE as 'Nombre' FROM clasificacion", "HERRAMIENTAS")
                dtLista.DefaultView.Sort = "Código"
                dgTabla.DataSource = dtLista
                btnSiguiente.PerformClick()
            End If
        End If
        dgTabla.DataSource = sqlExecute("SELECT COD_CLAS as 'Código',NOMBRE as 'Nombre' FROM clasificacion", "HERRAMIENTAS")
    End Sub

    Private Sub dgTabla_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.CellClick
        On Error Resume Next
        Dim cod As String, nom As String
        DesdeGrid = True
        cod = dgTabla.Item("Código", e.RowIndex).Value
        nom = dgTabla.Item("Nombre", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * from clasificacion WHERE COD_CLAS= '" & cod & "' AND NOMBRE = '" & nom & "'", "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe COD_TALLA
            dtTemporal = sqlExecute("SELECT COD_CLAS FROM clasificacion WHERE COD_CLAS= '" & txtCodigo.Text & "'", "HERRAMIENTAS")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe ese codigo de clsificacion '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                sqlExecute("INSERT INTO clasificacion (COD_CLAS,NOMBRE) VALUES ('" & txtCodigo.Text & "','" & txtNombre.Text & "')", "HERRAMIENTAS")
                dtRegistro = sqlExecute("SELECT TOP 1 * FROM clasificacion WHERE COD_CLAS='" & txtCodigo.Text & "' ORDER BY COD_CLAS ASC", "HERRAMIENTAS")
                Agregar = False
            End If
        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE clasificacion SET NOMBRE = '" & txtNombre.Text & "' WHERE COD_CLAS = '" & txtCodigo.Text & "'", "HERRAMIENTAS")
        Else
            Agregar = True
        End If
        Editar = False
        dtLista = sqlExecute("SELECT COD_CLAS as 'Código',NOMBRE as 'Nombre' FROM clasificacion", "HERRAMIENTAS")
        dtLista.DefaultView.Sort = "Código"
        dgTabla.DataSource = dtLista
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM clasificacion WHERE COD_CLAS='" & txtCodigo.Text & "' ORDER BY COD_CLAS ASC", "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM clasificacion WHERE COD_CLAS='" & txtCodigo.Text & "' ORDER BY COD_CLAS ASC", "HERRAMIENTAS")
            MostrarInformacion()
            txtNombre.Focus()
        Else
            Editar = False
        End If
        Agregar = False
        MostrarInformacion()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("clasificaciones herramientas", Nothing)
        frmVistaPrevia.ShowDialog()
    End Sub
    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class