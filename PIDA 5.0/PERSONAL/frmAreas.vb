Public Class frmAreas
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtCias As New DataTable         'Tabla de compañías
    Dim dtAreas As New DataTable        'Tabla de supervisores
    'Dim dtReloj As New DataTable

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region


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

        chkTodasLasCias.Visible = (Agregar Or Editar Or NoRec)

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


        txtCodigo.Text = dtRegistro.Rows(0).Item("cod_area")
        txtNombre.Text = dtRegistro.Rows(0).Item("nombre").ToString.Trim
        cmbCia.SelectedValue = dtRegistro.Rows(0).Item("cod_comp")
        'cmbReloj.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("reloj")), "", dtRegistro.Rows(0).Item("reloj"))
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
        'Cod = Buscar("super", "cod_super", "super", False)
        Cod = Buscar("areas", "cod_area", "areas", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from areas WHERE cod_area = '" & Cod & "' AND cod_comp = '" & Compania & "'")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        'Primero("super", "(cod_comp + cod_super)", dtRegistro)
        Primero("areas", "(cod_comp + cod_area)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("areas", "(cod_comp + cod_area)", cmbCia.SelectedValue & txtCodigo.Text, dtRegistro)
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
        Ultimo("areas", "(cod_comp + cod_area)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe cod_comp+cod_super
            dtCias = sqlExecute("select * from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))
            For Each row As DataRow In dtCias.Rows
                dtTemporal = sqlExecute("SELECT cod_area FROM areas where cod_comp = '" & row("cod_comp") & "' AND cod_area = '" & txtCodigo.Text & "'")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe el área '" & txtCodigo.Text & "' asignado a la compañía '" & row("cod_comp") & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                End If
            Next
            For Each row As DataRow In dtCias.Rows
                sqlExecute("INSERT INTO areas (cod_comp,cod_area,nombre) VALUES ('" & row("cod_comp") & "','" & txtCodigo.Text & "','" & txtNombre.Text & "')")
                Agregar = False
            Next


        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            dtCias = sqlExecute("select * from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))

            For Each row As DataRow In dtCias.Rows
                sqlExecute("UPDATE areas SET nombre = '" & txtNombre.Text & "' WHERE cod_area = '" & txtCodigo.Text & "' AND cod_comp = '" & row("cod_comp") & "'")
            Next

        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()
    End Sub

    Private Sub frmAreas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_comp as 'Compañía',cod_area as 'Código',Nombre FROM areas")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtCias = sqlExecute("SELECT * FROM cias")
            cmbCia.DataSource = dtCias

            'dtReloj = sqlExecute("SELECT reloj from personalvw ORDER BY reloj")
            'cmbReloj.DataSource = dtReloj

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM areas ORDER BY cod_comp ASC, cod_area ASC")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("areas", "(cod_comp + cod_area)", cmbCia.SelectedValue & txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String, comp As String
        codigo = txtCodigo.Text
        comp = cmbCia.SelectedValue
        'dtTemporal = sqlExecute("SELECT reloj from personalvw WHERE cod_area = '" & codigo & "' AND cod_comp = '" & comp & "'")
        'If dtTemporal.Rows.Count > 0 Then
        'MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Else
        If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            sqlExecute("DELETE FROM areas WHERE cod_area = '" & codigo & "' AND cod_comp = '" & comp & "'")
            btnSiguiente.PerformClick()
        End If
        'End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtDatos As New DataTable
        dtDatos = sqlExecute("SELECT * FROM areas WHERE cod_comp = '" & cmbCia.Text & "'")
        frmVistaPrevia.LlamarReporte("Areas", dtDatos, cmbCia.Text)
        frmVistaPrevia.ShowDialog()
    End Sub
    'Private Sub cmbReloj_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbReloj.Validating
    '    If cmbReloj.Text <> "" Then
    '        dtTemporal = sqlExecute("SELECT nombre,apaterno from personalvw WHERE reloj = '" & cmbReloj.Text & "'")
    '        If dtTemporal.Rows.Count = 0 Then
    '            txtNombre.Text = "NO LOCALIZADO"
    '        Else
    '            txtNombre.Text = dtTemporal.Rows(0).Item("nombre").ToString.Trim & " " & dtTemporal.Rows(0).Item("apaterno").ToString.Trim
    '        End If
    '    End If
    'End Sub
    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        DesdeGrid = True
        Dim area As String = dgTabla.Rows(e.RowIndex).Cells("Código").Value
        Dim comp As String = dgTabla.Rows(e.RowIndex).Cells("Compañía").Value
        dtRegistro = sqlExecute("SELECT * from areas WHERE cod_area = '" & area & "' AND cod_comp = '" & comp & "'")
        MostrarInformacion()
    End Sub
End Class