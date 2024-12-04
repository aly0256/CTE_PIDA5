Public Class frmCentroCostos

#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtCias As New DataTable         'Tabla de compañías
    Dim dtAreas As New DataTable        'Tabla de supervisores
    Dim dtSuper As New DataTable
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
            txtNombreIngles.Text = ""

            txtCodigo.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If
    End Sub

    Private Sub MostrarInformacion()
        Dim i As Integer

        txtCodigo.Text = dtRegistro.Rows(0).Item("centro_costos")
        txtNombre.Text = dtRegistro.Rows(0).Item("nombre").ToString.Trim
        txtNombreIngles.Text = dtRegistro.Rows(0).Item("nombre_ingles").ToString.Trim
        '  cmbArea.SelectedValue = dtRegistro.Rows(0).Item("cod_area")

        Try : sbDistribuible.Value = dtRegistro.Rows(0).Item("distribuible") : Catch ex As Exception : sbDistribuible.Value = Nothing : End Try

        'cmbSupervisor.SelectedValue = dtRegistro.Rows(0).Item("cod_super")
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

    Private Sub frmCentroCostos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT centro_costos as 'Centro costos',rtrim(nombre) as 'nombre',cod_area as 'Código área' FROM c_costos")
            dtLista.DefaultView.Sort = "Centro costos"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtCias = sqlExecute("SELECT * FROM areas")
            '    cmbArea.DataSource = dtCias
            '  cmbArea.SelectedValue = ""

            'dtSuper = sqlExecute("SELECT cod_super, nombre FROM super")
            'cmbSupervisor.DataSource = dtSuper
            'cmbSupervisor.DisplayMembers = "nombre"
            'cmbSupervisor.ValueMember = "cod_super"

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM c_costos ORDER BY centro_costos ASC")
            btnPrimero.PerformClick()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCiasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        'Cod = Buscar("super", "cod_super", "super", False)
        Cod = Buscar("c_costos", "centro_costos", "centro_costos", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from c_costos WHERE centro_costos = '" & Cod & "'")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("c_costos", "centro_costos", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("c_costos", "centro_costos", txtCodigo.Text, dtRegistro)
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
        Ultimo("c_costos", "centro_costos", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe cod_comp+centro_costos
            dtTemporal = sqlExecute("SELECT centro_costos FROM c_costos where centro_costos = '" & txtCodigo.Text & "'")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe el centro de costos '" & txtCodigo.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                '   sqlExecute("insert into c_costos(centro_costos, nombre,distribuible,cod_area) values ('" & txtCodigo.Text & "', '" & txtNombre.Text & "','" & IIf(sbDistribuible.Value = True, IIf(sbDistribuible.Value = True, 1, 0), 0) & "','" & cmbArea.SelectedValue & "')")

                sqlExecute("insert into c_costos(centro_costos, nombre,distribuible,nombre_ingles) values ('" & txtCodigo.Text & "', '" & txtNombre.Text & "','" & IIf(sbDistribuible.Value = True, IIf(sbDistribuible.Value = True, 1, 0), 0) & "','" & txtNombreIngles.Text & "')")

                Agregar = False
            End If

        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro

            sqlExecute("UPDATE c_costos SET nombre = '" & txtNombre.Text & "',distribuible='" & IIf(sbDistribuible.Value = True, IIf(sbDistribuible.Value = True, 1, 0), 0) & "',nombre_ingles='" & txtNombreIngles.Text & "' WHERE centro_costos = '" & txtCodigo.Text & "'")
        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("c_costos", "centro_costos", txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String, comp As String
        codigo = txtCodigo.Text
        ' comp = cmbArea.SelectedValue
        'dtTemporal = sqlExecute("SELECT reloj from personalvw WHERE cod_area = '" & codigo & "' AND cod_comp = '" & comp & "'")
        'If dtTemporal.Rows.Count > 0 Then
        'MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Else
        If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            sqlExecute("DELETE FROM c_costos WHERE centro_costos = '" & codigo & "' AND cod_area = '" & comp & "'")
            btnSiguiente.PerformClick()
        End If
        'End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click        
        'frmVistaPrevia.LlamarReporte("Centro de Costos", sqlExecute("select c_costos.cod_comp,c_costos.centro_costos,c_costos.nombre,c_costos.cod_super,super.NOMBRE from c_costos LEFT JOIN super on super.COD_SUPER = c_costos.cod_super"))
        frmVistaPrevia.LlamarReporte("Centro de Costos", sqlExecute("select * from c_costos"))
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        DesdeGrid = True
        Dim ccostos As String = dgTabla.Rows(e.RowIndex).Cells("Centro Costos").Value
        dtRegistro = sqlExecute("SELECT * from c_costos WHERE centro_costos = '" & ccostos & "'")
        MostrarInformacion()
    End Sub
End Class