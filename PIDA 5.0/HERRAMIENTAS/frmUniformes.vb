Public Class frmUniformes
    Dim dtLista As New DataTable()
    Dim dtRegistro As New DataTable()
    Dim DesdeGrid As New Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
    Private Sub frmUniformes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT COD_UNIF as 'Código',NOMBRE as 'Nombre',TALLAS as 'Tallas',COSTO AS 'Costo',DIAS_REP as 'Reposición',IN_STOCK AS 'En Inventario',OUT_STOCK as 'Prestados'  FROM uniformes", "HERRAMIENTAS")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM uniformes ORDER BY COD_UNIF ASC", "HERRAMIENTAS")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub HabilitarBotones()
        Dim NoRec As Boolean
        NoRec = dgTabla.Rows.Count = 0
        tabTabla.Enabled = Not (Agregar Or Editar Or NoRec)
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
            LimpiarTextos()
            txtCodigo.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If
    End Sub
    Private Sub LimpiarTextos()
        txtCodigo.Clear()
        txtNombre.Clear()
        txtTalla.Clear()
        txtCosto.Text = "1"
        txtReposicion.Text = 1
        txtInventario.Text = 0
        txtPrestados.Text = 0
    End Sub
    Private Sub MostrarInformacion()
        Dim i As Integer
        On Error Resume Next
        txtCodigo.Text = dtRegistro.Rows(0).Item("COD_UNIF")
        txtNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("NOMBRE")), "", dtRegistro.Rows(0).Item("NOMBRE")).ToString.Trim
        txtTalla.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("TALLAS")), "", dtRegistro.Rows(0).Item("TALLAS")).ToString.Trim
        txtReposicion.Text = dtRegistro.Rows(0).Item("DIAS_REP")
        txtCosto.Text = dtRegistro.Rows(0).Item("COSTO")
        txtPrestados.Text = dtRegistro.Rows(0).Item("OUT_STOCK")
        txtInventario.Text = dtRegistro.Rows(0).Item("IN_STOCK")
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
    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("uniformes", "COD_UNIF", txtCodigo.Text, dtRegistro, "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("uniformes", "COD_UNIF", txtCodigo.Text, dtRegistro, "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("uniformes", "COD_UNIF", dtRegistro, "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("uniformes", "COD_UNIF", dtRegistro, "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("HERRAMIENTAS.dbo.uniformes", "COD_UNIF", "uniformes", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM uniformes WHERE COD_UNIF = '" & Cod & "' ", "HERRAMIENTAS")
            MostrarInformacion()
        End If
    End Sub
    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If Agregar Then

            ' Si Agregar, revisar si existe COD_UNIF
            dtTemporal = sqlExecute("SELECT COD_UNIF FROM uniformes where COD_UNIF = '" & txtCodigo.Text & "'", "HERRAMIENTAS")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe ese Uniforme'" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                If txtTalla.Text.Substring(txtTalla.Text.Trim.Length - 1) <> ";" Then
                    txtTalla.Text = txtTalla.Text.Trim & ";"
                End If
                sqlExecute("INSERT INTO uniformes (COD_UNIF,NOMBRE,TALLAS,IN_STOCK,OUT_STOCK,DIAS_REP,COSTO) VALUES ('" & _
                           txtCodigo.Text & "','" & txtNombre.Text & "','" & txtTalla.Text & "','" & txtInventario.Text & "','0','" & _
                           txtReposicion.Text & "','" & txtCosto.Text & "')", "HERRAMIENTAS")
                dtRegistro = sqlExecute("SELECT TOP 1 * FROM uniformes WHERE COD_UNIF ='" & txtCodigo.Text & "' ORDER BY COD_UNIF ASC ", "HERRAMIENTAS")
                Agregar = False
            End If
        ElseIf Editar Then
            If txtTalla.Text.Substring(txtTalla.Text.Trim.Length - 1) <> ";" Then
                txtTalla.Text = txtTalla.Text.Trim & ";"
            End If
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE uniformes SET NOMBRE = '" & txtNombre.Text & "',TALLAS = '" & txtTalla.Text & "',IN_STOCK = '" & txtInventario.Text & "',OUT_STOCK = '" & txtPrestados.Text & "',DIAS_REP = '" & txtReposicion.Text & "',COSTO = '" & txtCosto.Text & "' WHERE COD_UNIF= '" & txtCodigo.Text & "'", "HERRAMIENTAS")

        Else
            Agregar = True
        End If
        Editar = False

        dtLista = sqlExecute("SELECT COD_UNIF as 'Código',NOMBRE as 'Nombre',TALLAS as 'Tallas',COSTO AS 'Costo',DIAS_REP as 'Reposición',IN_STOCK AS 'En Inventario',OUT_STOCK as 'Prestados'  FROM uniformes", "HERRAMIENTAS")
        dtLista.DefaultView.Sort = "Código"
        dgTabla.DataSource = dtLista

        dtRegistro = sqlExecute("SELECT TOP 1 * FROM uniformes WHERE COD_UNIF ='" & txtCodigo.Text & "' ORDER BY COD_UNIF ASC ", "HERRAMIENTAS")
        MostrarInformacion()

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM uniformes WHERE COD_UNIF ='" & txtCodigo.Text & "' ORDER BY COD_UNIF ASC ", "HERRAMIENTAS")
            MostrarInformacion()
            txtNombre.Focus()
        Else
        
            Editar = False
        End If
        Agregar = False
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim codigo As String
        codigo = txtCodigo.Text
        dtTemporal = sqlExecute("SELECT reloj FROM uniformes_por_empleado WHERE COD_UNIF = '" & codigo & "'", "HERRAMIENTAS")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo.Trim & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM uniformes WHERE COD_UNIF = '" & codigo & "'", "HERRAMIENTAS")
                dtLista = sqlExecute("SELECT COD_UNIF as 'Código',NOMBRE as 'Nombre',TALLAS as 'Tallas',COSTO AS 'Costo',DIAS_REP as 'Reposición',IN_STOCK AS 'En Inventario',OUT_STOCK as 'Prestados'  FROM uniformes", "HERRAMIENTAS")
                dtLista.DefaultView.Sort = "Código"
                dgTabla.DataSource = dtLista


                btnSiguiente.PerformClick()
            End If
        End If
      End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("uniformes", Nothing)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub dgTabla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellClick
        On Error Resume Next
        Dim cod As String, nom As String
        DesdeGrid = True
        cod = dgTabla.Item("Código", e.RowIndex).Value
        nom = dgTabla.Item("Nombre", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * from uniformes WHERE COD_UNIF = '" & cod & "' AND NOMBRE = '" & nom & "'", "HERRAMIENTAS")
        MostrarInformacion()
    End Sub

End Class