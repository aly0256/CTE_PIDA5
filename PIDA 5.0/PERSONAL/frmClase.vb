Public Class frmClase
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtCias As New DataTable         'Tabla de compañías
    Dim dtclase As New DataTable        'Tabla de clasevisores

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region


    Private Sub frmclase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_comp as 'Compañía',cod_clase as 'Código',Nombre,nivel_seguridad AS 'Nivel' FROM clase")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtCias = sqlExecute("SELECT * FROM cias")
            cmbCia.DataSource = dtCias

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM clase ORDER BY cod_comp ASC, cod_clase ASC")
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
            txtNombreIngles.Text = ""
            txtCodigo.Focus()
            sldNivel.Value = 0
        ElseIf Editar Then
            txtNombre.Focus()
        End If
    End Sub
    Private Sub MostrarInformacion()
        Dim i As Integer
        On Error Resume Next

        txtCodigo.Text = dtRegistro.Rows(0).Item("cod_clase")
        txtNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre").ToString.Trim), "", dtRegistro.Rows(0).Item("nombre").ToString.Trim)
        txtNombreIngles.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre_ingles").ToString.Trim), "", dtRegistro.Rows(0).Item("nombre_ingles").ToString.Trim)
        cmbCia.SelectedValue= dtRegistro.Rows(0).Item("cod_comp")
        sldNivel.Value = dtRegistro.Rows(0).Item("nivel_seguridad")
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

    Private Sub cmbCia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCia.SelectedIndexChanged
        dtclase = sqlExecute("SELECT nombre FROM clase WHERE cod_comp = '" & cmbCia.SelectedValue & "' ORDER BY nombre")
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("clase", "cod_clase", "clase", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM clase WHERE cod_clase = '" & Cod & "' AND cod_comp = '" & Compania & "'")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("clase", "(cod_comp + cod_clase)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("clase", "(cod_comp + cod_clase)", cmbCia.SelectedValue + txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("clase", "(cod_comp + cod_clase)", cmbCia.SelectedValue + txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String, comp As String
        codigo = txtCodigo.Text
        comp = cmbCia.SelectedValue
        dtTemporal = sqlExecute("SELECT reloj from personalvw WHERE cod_clase = '" & codigo & "' AND cod_comp = '" & comp & "'")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                dtTemporal = sqlExecute("DELETE FROM clase WHERE cod_clase = '" & codigo & "' AND cod_comp = '" & comp & "'")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, comp As String

        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value
        comp = dgTabla.Item("Compañía", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * FROM clase WHERE cod_clase = '" & cod & "' AND cod_comp = '" & comp & "'")
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
        Ultimo("clase", "(cod_comp + cod_clase)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim dtCias As DataTable
        If Agregar Then

            ' Si Agregar, revisar si existe cod_comp+cod_depto


            dtCias = sqlExecute("select * from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))

            For Each row As DataRow In dtCias.Rows
                dtTemporal = sqlExecute("SELECT cod_clase FROM clase where cod_comp = '" & row("cod_comp") & "' AND cod_clase = '" & txtCodigo.Text & "'")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe la clase '" & txtCodigo.Text & "' asignado a la compañía '" & row("cod_comp") & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                End If
            Next
            For Each row As DataRow In dtCias.Rows
                sqlExecute("INSERT INTO clase (cod_comp,cod_clase,nombre,nombre_ingles,nivel_seguridad) VALUES ('" & _
                                      row("cod_comp") & "','" & _
                                      txtCodigo.Text & "','" & _
                                      txtNombre.Text & "','" & _
                                      txtNombreIngles.Text & "'," & _
                                      sldNivel.Value & ")")
                Agregar = False
            Next


        ElseIf Editar Then
            dtCias = sqlExecute("select * from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))

            For Each row As DataRow In dtCias.Rows
                ' Si Editar, entonces guardar cambios a registro
                sqlExecute("UPDATE clase SET " & _
                           "nombre = '" & txtNombre.Text & _
                           "', nombre_ingles = '" & txtNombreIngles.Text & _
                           "', nivel_seguridad = " & sldNivel.Value & _
                           " WHERE cod_clase = '" & txtCodigo.Text & "' AND cod_comp = '" & row("cod_comp") & "'")
            Next

        Else
            Agregar = True
        End If
        Editar = False
        HabilitarBotones()
    End Sub


    Private Sub sldNivel_ValueChanged(sender As Object, e As EventArgs) Handles sldNivel.ValueChanged
        sldNivel.Text = sldNivel.Value
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtCompanias As New DataTable
        'Dim x As Integer

        'dtCompanias = sqlExecute("SELECT cod_comp FROM cias")
        'For x = 0 To dtCompanias.Rows.Count - 1
        '    frmVistaPrevia.LlamarReporte("Clases", dtCompanias.Rows(x).Item(0))
        '    frmVistaPrevia.ShowDialog() 
        'Next

        Dim dtDatos As New DataTable
        dtDatos = sqlExecute("SELECT * FROM clase WHERE cod_comp = '" & cmbCia.Text & "'")
        dtCompanias = sqlExecute("SELECT cod_comp FROM cias WHERE cod_comp = '" & cmbCia.Text & "'")

        frmVistaPrevia.LlamarReporte("Clases", dtDatos, cmbCia.Text)
        frmVistaPrevia.ShowDialog()
    End Sub
    'Private Sub dgTabla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellClick
    '    DesdeGrid = True
    '    Dim clase As String = dgTabla.Rows(e.RowIndex).Cells("Código").Value
    '    Dim comp As String = dgTabla.Rows(e.RowIndex).Cells("Compañía").Value
    '    dtRegistro = sqlExecute("SELECT * FROM clase WHERE cod_clase = '" & clase & "' AND cod_comp = '" & comp & "'")
    '    MostrarInformacion()
    'End Sub
End Class