Imports System.Data.DataTable

Public Class frmHerramientas
    Dim dtLista As New DataTable()
    Dim dtRegistro As New DataTable()
    Dim DesdeGrid As New Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim ConsultaDeLista As String = "SELECT articulos.COD_ART as 'Código',articulos.NOMBRE as 'Nombre',articulos.COD_CLAS as 'Código clasificación',clasificacion.nombre as 'Clasificación',articulos.DIAS_REP as 'Reposición',articulos.COSTO 'Costo' ,articulos.IN_STOCK as 'En Inventario',articulos.OUT_STOCK as 'Prestados' from  articulos left JOIN clasificacion on articulos.COD_CLAS = clasificacion.COD_CLAS"
    Private Sub frmHerramientas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute(ConsultaDeLista, "HERRAMIENTAS")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            cmbClasificacion.DataSource = sqlExecute("SELECT COD_CLAS ,NOMBRE FROM clasificacion", "HERRAMIENTAS")
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM articulos ORDER BY COD_ART ASC", "HERRAMIENTAS")
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
    Private Sub MostrarInformacion()
        Dim i As Integer
        On Error Resume Next
        txtCodigo.Text = dtRegistro.Rows(0).Item("COD_ART").ToString.Trim
        txtNombre.Text = dtRegistro.Rows(0).Item("NOMBRE").ToString.Trim
        txtReposicion.Value = dtRegistro.Rows(0).Item("DIAS_REP")
        txtCosto.Value = dtRegistro.Rows(0).Item("COSTO")
        cmbClasificacion.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("COD_CLAS")), "", dtRegistro.Rows(0).Item("COD_CLAS"))
        txtPrestados.Value = dtRegistro.Rows(0).Item("OUT_STOCK")
        txtInventario.Value = dtRegistro.Rows(0).Item("IN_STOCK")
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
        Siguiente("articulos", "COD_ART", txtCodigo.Text, dtRegistro, "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("articulos", "COD_ART", txtCodigo.Text, dtRegistro, "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("articulos", "COD_ART", dtRegistro, "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("articulos", "COD_ART", dtRegistro, "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("HERRAMIENTAS.dbo.articulos", "COD_ART", "articulos", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM articulos WHERE COD_ART = '" & Cod & "' ", "HERRAMIENTAS")
            MostrarInformacion()
        End If
    End Sub
    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe COD_ART
            dtTemporal = sqlExecute("SELECT COD_ART FROM articulos where COD_ART = '" & txtCodigo.Text & "'", "HERRAMIENTAS")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe esa herramienta'" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                sqlExecute("INSERT INTO articulos (COD_ART,NOMBRE,COD_CLAS,DIAS_REP,COSTO,IN_STOCK,OUT_STOCK) VALUES ('" & _
                           txtCodigo.Text & "','" & txtNombre.Text & "','" & cmbClasificacion.SelectedValue & "','" & _
                           txtReposicion.Value & "','" & txtCosto.Value & "','" & txtInventario.Value & "','0')", "HERRAMIENTAS")
                dtRegistro = sqlExecute("SELECT TOP 1 * FROM articulos WHERE COD_ART ='" & txtCodigo.Text & "' ORDER BY COD_ART ASC ", "HERRAMIENTAS")
                Agregar = False
            End If
        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE articulos SET NOMBRE = '" & txtNombre.Text & "', COD_CLAS = '" & cmbClasificacion.SelectedValue & "',DIAS_REP = '" & txtReposicion.Text & "',COSTO = '" & txtCosto.Text & "',IN_STOCK = '" & txtInventario.Text & "',OUT_STOCK = '" & txtPrestados.Text & "' WHERE COD_ART= '" & txtCodigo.Text & "'", "HERRAMIENTAS")
        Else
            cmbClasificacion.DataSource = sqlExecute("SELECT COD_CLAS ,NOMBRE FROM clasificacion", "HERRAMIENTAS")
            Agregar = True
        End If
        Editar = False
        dtLista = sqlExecute(ConsultaDeLista, "HERRAMIENTAS")
        dtLista.DefaultView.Sort = "Código"
        dgTabla.DataSource = dtLista
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM articulos WHERE COD_ART ='" & txtCodigo.Text & "' ORDER BY COD_ART ASC ", "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub LimpiarTextos()
        txtCodigo.Clear()
        txtNombre.Clear()
        txtCosto.Text = "1"
        txtReposicion.Text = 1
        txtInventario.Text = 0
        txtPrestados.Text = 0
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            cmbClasificacion.DataSource = sqlExecute("SELECT COD_CLAS ,NOMBRE FROM clasificacion", "HERRAMIENTAS")
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM articulos WHERE COD_ART ='" & txtCodigo.Text & "' ORDER BY COD_ART ASC ", "HERRAMIENTAS")
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
        dtTemporal = sqlExecute("SELECT reloj FROM articulos_por_empleado WHERE COD_ART = '" & codigo & "'", "HERRAMIENTAS")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM articulos WHERE COD_ART = '" & codigo & "'", "HERRAMIENTAS")
                dtLista = sqlExecute(ConsultaDeLista, "HERRAMIENTAS")
                dtLista.DefaultView.Sort = "Código"
                dgTabla.DataSource = dtLista


                btnSiguiente.PerformClick()
            End If
        End If
    
    End Sub
    Private Sub dgTabla_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.CellClick
        On Error Resume Next
        Dim cod As String, nom As String
        DesdeGrid = True
        cod = dgTabla.Item("Código", e.RowIndex).Value
        nom = dgTabla.Item("Nombre", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * from articulos WHERE COD_ART = '" & cod & "' AND NOMBRE = '" & nom & "'", "HERRAMIENTAS")
        MostrarInformacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("herramientas", Nothing)
        frmVistaPrevia.ShowDialog()
    End Sub

End Class