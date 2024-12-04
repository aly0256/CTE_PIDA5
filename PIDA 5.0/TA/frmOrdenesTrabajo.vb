Public Class frmOrdenesTrabajo
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region


    Private Sub frmOrdenesTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_orden as 'Código',Nombre FROM ordenes_trabajo", "TA")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM ordenes_trabajo ORDER BY cod_orden ASC ", "TA")
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
        btnCerrar.Enabled = Not (Agregar Or Editar)
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
        Try
            If dtRegistro.Rows.Count = 0 Then Exit Sub
            txtCodigo.Text = dtRegistro.Rows(0).Item("cod_orden")
            txtNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre")), "", dtRegistro.Rows(0).Item("nombre").ToString.Trim)
            dtOpening.ValueObject = dtRegistro.Rows(0).Item("opening_date")
            dtClosing.ValueObject = dtRegistro.Rows(0).Item("closing_date")
            txtProducto.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("product")), "", dtRegistro.Rows(0).Item("product").ToString.Trim)

            If Not DesdeGrid Then
                i = dtLista.DefaultView.Find(txtCodigo.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If
            DesdeGrid = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            HabilitarBotones()
        End Try
    End Sub

    Private Sub btnCiasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("ta.dbo.ordenes_trabajo", "cod_orden", "ÓRDENES DE TRABAJO", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM ordenes_trabajo WHERE cod_orden = '" & Cod & "' ", "TA")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("ordenes_trabajo", "cod_orden", dtregistro, "TA")
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("ordenes_trabajo", "cod_orden", txtCodigo.Text, dtregistro, "TA")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("ordenes_trabajo", "cod_orden", txtCodigo.Text, dtregistro, "TA")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Codigo = txtCodigo.Text
        dtTemporal = sqlExecute("SELECT TOP 1 FROM time_allocation WHERE cod_orden = '" & Codigo & "'", "TA")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & Codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM ordenes_trabajo WHERE cod_orden = '" & Codigo & "'", "TA")
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
        dtRegistro = sqlExecute("SELECT * FROM ordenes_trabajo WHERE cod_orden = '" & cod & "' AND nombre = '" & nom & "'", "TA")
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
        Ultimo("ordenes_trabajo", "cod_orden", dtregistro, "TA")
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim CambioEfectuado As Boolean
        CambioEfectuado = True
        If Agregar Then
            ' Si Agregar, revisar si existe cod_orden
            dtTemporal = sqlExecute("SELECT cod_orden FROM ordenes_trabajo where cod_orden = '" & txtCodigo.Text & "'", "TA")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe el estado '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                sqlExecute("INSERT INTO ordenes_trabajo (cod_orden) VALUES ('" & txtCodigo.Text & "')", "TA")

                Try
                    sqlExecute("UPDATE ordenes_trabajo SET " & _
                                          "  nombre = '" & RTrim(txtNombre.Text) & "'" & _
                                          ", opening_date = " & IIf(dtOpening.ValueObject Is Nothing, "NULL", "'" & FechaSQL(dtOpening.Value) & "'") & _
                                          ", closing_date = " & IIf(dtClosing.ValueObject Is Nothing, "NULL", "'" & FechaSQL(dtClosing.Value) & "'") & _
                                          ", product = '" & txtProducto.Text & "'" & _
                                          "WHERE cod_orden = '" & txtCodigo.Text & "'", "TA")
                Catch ex As Exception

                End Try


                Agregar = False

                dtRegistro = sqlExecute("SELECT * FROM ordenes_trabajo WHERE cod_orden = '" & txtCodigo.Text & "' ", "TA")

                MostrarInformacion()

            End If
        End If

        If Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE ordenes_trabajo SET " & _
                       "  nombre = '" & RTrim(txtNombre.Text) & "'" & _
                       ", opening_date = " & IIf(dtOpening.ValueObject Is Nothing, "NULL", "'" & FechaSQL(dtOpening.Value) & "'") & _
                       ", closing_date = " & IIf(dtClosing.ValueObject Is Nothing, "NULL", "'" & FechaSQL(dtClosing.Value) & "'") & _
                       ", product = '" & txtProducto.Text & "'" & _
                       "WHERE cod_orden = '" & txtCodigo.Text & "'", "TA")

            dtRegistro = sqlExecute("SELECT * FROM ordenes_trabajo WHERE cod_orden = '" & txtCodigo.Text & "' ", "TA")

            MostrarInformacion()
        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()


    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtordenes As DataTable = sqlExecute("select * from ordenes_trabajo", "TA")
        frmVistaPrevia.LlamarReporte("Ordenes de trabajo", dtordenes)
        frmVistaPrevia.ShowDialog()
    End Sub
End Class