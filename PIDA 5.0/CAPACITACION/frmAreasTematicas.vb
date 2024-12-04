Public Class frmAreasTematicas

#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region

    Private Sub frmAreasTematicas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_area as 'Código',Nombre FROM areas_tematicas", "capacitacion")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM areas_tematicas ORDER BY cod_area ASC ", "capacitacion")
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
            txtCodigo.Text = ""
            txtNombre.Text = ""
            txtCodigo.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If
    End Sub
    Private Sub MostrarInformacion()
        Dim i As Integer

        txtCodigo.Text = dtRegistro.Rows(0).Item("cod_area")
        txtNombre.Text = dtRegistro.Rows(0).Item("nombre").ToString.Trim
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
        Cod = Buscar("capacitacion.dbo.areas_tematicas", "cod_area", "ÁREAS TEMÁTICAS", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM areas_tematicas WHERE cod_area = '" & Cod & "' ", "capacitacion")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("areas_tematicas", "cod_area", dtRegistro, "capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("areas_tematicas", "cod_area", txtCodigo.Text, dtRegistro, "capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("areas_tematicas", "cod_area", txtCodigo.Text, dtRegistro, "capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Codigo = txtCodigo.Text
        dtTemporal = sqlExecute("SELECT cod_curso FROM cursos WHERE area_tematica = '" & Codigo & "'", "capacitacion")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & Codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM areas_tematicas WHERE cod_area = '" & Codigo & "'", "capacitacion")

                '**** ACTUALIZA TABLA *****
                'AGREGAR ESTE CODIGO
                dtLista = sqlExecute("SELECT cod_area as 'Código',Nombre FROM areas_tematicas", "capacitacion")
                dtLista.DefaultView.Sort = "Código"
                dgTabla.DataSource = dtLista
                '**************************

                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub dgTabla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellClick
        '**** ACTUALIZA TABLA *****
        'CAMBIAR DE RowEnter A CellClick

        On Error Resume Next

        Dim cod As String, nom As String
        If dgTabla.SelectedCells.Count <= 0 Then Exit Sub
        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value
        nom = dgTabla.Item("Nombre", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * FROM areas_tematicas WHERE cod_area = '" & cod & "'", "capacitacion")
        MostrarInformacion()
        '***************************

        '---- AO: Revisar perfiles para ver si tiene acceso a los botones
        Dim _visible As Boolean = True
        _visible = revisarPerfiles(Perfil, Me, _visible, "WME", "")
        btnNuevo.Visible = _visible
        btnEditar.Visible = _visible
        btnBorrar.Visible = _visible

    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter

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
        Ultimo("areas_tematicas", "cod_area", dtRegistro, "capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe cod_area
            dtTemporal = sqlExecute("SELECT cod_area FROM areas_tematicas where cod_area = '" & txtCodigo.Text & "'", "capacitacion")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                sqlExecute("INSERT INTO areas_tematicas (cod_area,nombre) VALUES ('" & txtCodigo.Text & "','" & txtNombre.Text & "')", "capacitacion")
                Agregar = False
            End If

        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE areas_tematicas SET nombre = '" & txtNombre.Text & "' WHERE cod_area = '" & txtCodigo.Text & "'", "capacitacion")
        Else
            Agregar = True
        End If
        Editar = False

        '**** ACTUALIZA TABLA *****
        'AGREGAR ESTE CODIGO
        dtLista = sqlExecute("SELECT cod_area as 'Código',Nombre FROM areas_tematicas", "capacitacion")
        dtLista.DefaultView.Sort = "Código"
        dgTabla.DataSource = dtLista

        dtRegistro = sqlExecute("SELECT * FROM areas_tematicas WHERE cod_area = '" & txtCodigo.Text & "'", "capacitacion")
        MostrarInformacion()
        '**************************
        HabilitarBotones()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("Areas temáticas", Nothing)
        frmVistaPrevia.ShowDialog()
    End Sub

End Class