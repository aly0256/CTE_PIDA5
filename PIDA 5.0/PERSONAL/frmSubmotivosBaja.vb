Public Class frmSubmotivosBaja
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtBajaInterno As New DataTable

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region

    Private Sub frmSubmotivosBaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_sub_ba as 'Código',motivo as 'Motivo' FROM cod_sub_baj")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtBajaInterno = sqlExecute("SELECT * FROM cod_mot_baj")
            'dtBajaInterno.DefaultView.Sort = "cod_mot_ba"
            cmbBajaInterno.DataSource = dtBajaInterno
            cmbBajaInterno.ValueMember = "cod_mot_ba"
            'cmbBajaInterno.DisplayMembers = "cod_mot_ba, nombre"

            btnPrimero.PerformClick()
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
        txtCodigo.Text = dtRegistro.Rows(0).Item("cod_sub_ba")
        txtNombre.Text = dtRegistro.Rows(0).Item("motivo").ToString.Trim
        '  cmbBajaInterno.SelectedValue = dtRegistro.Rows(0).Item("cod_mot_ba")
        Try : cmbBajaInterno.SelectedValue = dtRegistro.Rows(0).Item("cod_mot_ba") : Catch ex As Exception : cmbBajaInterno.Text = "N/A" : End Try
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
        Cod = Buscar("cod_sub_baj", "cod_sub_ba", "Submotivos de baja", False, "Motivo")
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM cod_sub_baj WHERE cod_sub_ba = '" & Cod & "'")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("cod_sub_baj", "cod_sub_ba", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("cod_sub_baj", "cod_sub_ba", txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("cod_sub_baj", "cod_sub_ba", txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Codigo = txtCodigo.Text
        dtTemporal = sqlExecute("SELECT reloj from personalvw WHERE cod_sub_ba = '" & Codigo & "'")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & Codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM cod_sub_baj WHERE cod_sub_ba = '" & Codigo & "'")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, nom As String

        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value
        nom = dgTabla.Item("Motivo", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * FROM cod_sub_baj WHERE cod_sub_ba = '" & cod & "' AND motivo = '" & nom & "'")
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
        Ultimo("cod_sub_baj", "cod_sub_ba", dtRegistro)
        MostrarInformacion()
    End Sub

    '==Modificada para agregar o modificar un tercer criterio WME       31agosto2021
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            Dim CambioEfectuado As Boolean
            CambioEfectuado = True
            If Agregar Then
                ' Si Agregar, revisar si existe cod_mot_ba
                dtTemporal = sqlExecute("SELECT cod_sub_ba FROM cod_sub_baj where cod_sub_ba = '" & txtCodigo.Text & "'")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe el motivo '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                Else
                    sqlExecute("INSERT INTO cod_sub_baj (cod_sub_ba,motivo,cod_mot_ba) VALUES ('" & txtCodigo.Text & "','" & txtNombre.Text & "','" & cmbBajaInterno.SelectedValue & "')")
                    Agregar = False
                End If
            ElseIf Editar Then
                ' Si Editar, entonces guardar cambios a registro
                sqlExecute("UPDATE cod_sub_baj SET motivo = '" & txtNombre.Text & "' , cod_mot_ba = '" & cmbBajaInterno.SelectedValue & "' WHERE cod_sub_ba = '" & txtCodigo.Text & "'")
            Else
                Agregar = True
            End If
            Editar = False
            HabilitarBotones()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("Submotivos de baja", sqlExecute("select cod_sub_baj.cod_sub_ba,cod_sub_baj.cod_mot_ba,cod_sub_baj.motivo,cod_mot_baj.COD_MOT_BA as 'codigo motivo',cod_mot_baj.NOMBRE from cod_mot_baj LEFT JOIN cod_sub_baj on cod_sub_baj.cod_mot_ba = cod_mot_baj.cod_mot_ba where cod_sub_baj.cod_mot_ba=cod_mot_baj.COD_MOT_BA"))
        frmVistaPrevia.ShowDialog()
    End Sub
End Class