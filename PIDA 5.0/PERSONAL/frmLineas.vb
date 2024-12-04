Public Class frmLineas
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtCias As New DataTable         'Tabla de compañías
    Dim dtSuper As New DataTable        'Tabla de supervisores

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region


    Private Sub frmlineas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_comp as 'Compañía',cod_linea as 'Código',Nombre FROM lineas")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


            dtCias = sqlExecute("SELECT * FROM cias")
            cmbCia.DataSource = dtCias

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM lineas ORDER BY cod_comp ASC, cod_linea ASC ")
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
        cmbCia.Enabled = Agregar

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


            txtCodigo.Text = dtRegistro.Rows(0).Item("cod_linea")
            txtNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre")), "", dtRegistro.Rows(0).Item("nombre"))
            cmbCia.SelectedValue = dtRegistro.Rows(0).Item("cod_comp")
            If Not DesdeGrid Then
                i = dtLista.DefaultView.Find(txtCodigo.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If
            DesdeGrid = False
            HabilitarBotones()

        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCiasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmbCia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCia.SelectedIndexChanged
        dtSuper = sqlExecute("SELECT nombre FROM super WHERE cod_comp = '" & cmbCia.SelectedValue & "' ORDER BY nombre")
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("lineas", "cod_linea", "lineaS", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from lineas WHERE cod_linea = '" & Cod & "' AND cod_comp = '" & Compania & "'")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("lineas", "(cod_comp + cod_linea)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("lineas", "(cod_comp + cod_linea)", cmbCia.SelectedValue + txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("lineas", "(cod_comp + cod_linea)", cmbCia.SelectedValue + txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String, comp As String
        codigo = txtCodigo.Text
        comp = cmbCia.SelectedValue
        dtTemporal = sqlExecute("SELECT reloj from personalvw WHERE cod_linea = '" & codigo & "' AND cod_comp = '" & comp & "'")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM lineas WHERE cod_linea = '" & codigo & "' AND cod_comp = '" & comp & "'")
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
        dtRegistro = sqlExecute("SELECT * from lineas WHERE cod_linea = '" & cod & "' AND nombre = '" & nom & "'")
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
        Ultimo("lineas", "(cod_comp + cod_linea)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe cod_comp+cod_linea
            dtTemporal = sqlExecute("SELECT cod_linea FROM lineas where cod_comp = '" & cmbCia.SelectedValue & "' AND cod_linea = '" & txtCodigo.Text & "'")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe la línea '" & txtCodigo.Text & "' asignado a la compañía '" & cmbCia.SelectedValue & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                sqlExecute("INSERT INTO lineas (cod_comp,cod_linea,nombre) VALUES ('" & cmbCia.SelectedValue & "','" & txtCodigo.Text & "','" & txtNombre.Text & "')")
                Agregar = False
            End If

        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE lineas SET nombre = '" & txtNombre.Text & "' WHERE cod_linea = '" & txtCodigo.Text & "' AND cod_comp = '" & cmbCia.SelectedValue & "'")
        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

        Dim dtDatos As New DataTable
        dtDatos = sqlExecute("SELECT * FROM lineas WHERE cod_comp = '" & cmbCia.Text & "'")
        frmVistaPrevia.LlamarReporte("Lineas", dtDatos, cmbCia.Text)
        frmVistaPrevia.ShowDialog()
    End Sub
    Private Sub dgTabla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellClick
        DesdeGrid = True
        Dim linea As String = dgTabla.Rows(e.RowIndex).Cells("Código").Value
        Dim comp As String = dgTabla.Rows(e.RowIndex).Cells("Compañía").Value
        dtRegistro = sqlExecute("SELECT * from lineas WHERE cod_linea = '" & linea & "' AND cod_comp = '" & comp & "'")
        MostrarInformacion()
    End Sub
End Class