Public Class frmDeptos
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtCias As New DataTable         'Tabla de compañías
    Dim dtSuper As New DataTable        'Tabla de supervisores
    Dim dtCostos As New DataTable

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region


    Private Sub frmDeptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_comp as 'Compañía',cod_depto as 'Código',Nombre,centro_costos as 'Centro de costos'  FROM deptos")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


            dtCias = sqlExecute("SELECT * FROM cias")
            cmbCia.DataSource = dtCias
            cmbCia.DisplayMembers = "cod_comp, nombre"
            cmbCia.ValueMember = "cod_comp"

            'dtCostos = sqlExecute("SELECT centro_costos,nombre FROM c_costos")
            'cmbCC.DataSource = dtCostos
            'cmbCC.DisplayMembers = "centro_costos,nombre"
            'cmbCC.ValueMember = "centro_costos"

            
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
        ElseIf Editar Then
            txtNombre.Focus()
        End If
    End Sub
    Private Sub MostrarInformacion()
        Dim i As Integer


        txtCodigo.Text = dtRegistro.Rows(0).Item("cod_depto")
        txtNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre").ToString.Trim), "", dtRegistro.Rows(0).Item("nombre").ToString.Trim)
        txtNombreIngles.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre_ingles").ToString.Trim), "", dtRegistro.Rows(0).Item("nombre_ingles").ToString.Trim)
        '   cmbCC.SelectedValue = dtRegistro.Rows(0).Item("centro_costos")
        cmbCia.SelectedValue = dtRegistro.Rows(0).Item("cod_comp")
        '   cmbSuper.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_super")), "", dtRegistro.Rows(0).Item("cod_super"))
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
       
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("deptos", "cod_depto", "DEPARTAMENTOS", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from deptos WHERE cod_depto = '" & Cod & "' AND cod_comp = '" & Compania & "'")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("deptos", "(cod_comp + cod_depto)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("deptos", "(cod_comp + cod_depto)", cmbCia.SelectedValue + txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("deptos", "(cod_comp + cod_depto)", cmbCia.SelectedValue + txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String, comp As String
        codigo = txtCodigo.Text
        comp = cmbCia.SelectedValue
        dtTemporal = sqlExecute("SELECT reloj from personalvw WHERE cod_depto = '" & codigo & "' AND cod_comp = '" & comp & "'")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM deptos WHERE cod_depto = '" & codigo & "' AND cod_comp = '" & comp & "'")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub dgTabla_RowDividerHeightChanged(sender As Object, e As DataGridViewRowEventArgs) Handles dgTabla.RowDividerHeightChanged

    End Sub

    'Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
    '    On Error Resume Next

    '    Dim cod As String, nom As String

    '    DesdeGrid = True

    '    Dim depto As String = dgTabla.Rows(e.RowIndex).Cells("Código").Value
    '    Dim comp As String = dgTabla.Rows(e.RowIndex).Cells("Compañía").Value
    '    dtRegistro = sqlExecute("SELECT * from deptos WHERE cod_depto = '" & depto & "' AND cod_comp = '" & comp & "'")
    '    MostrarInformacion()
    'End Sub

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
        'BERE
        'Ultimo("deptos", "CONCAT(cod_comp,cod_depto)", dtRegistro)
        Ultimo("deptos", "(cod_comp + cod_depto)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim dtCias As DataTable
        If Agregar Then

            ' Si Agregar, revisar si existe cod_comp+cod_depto


            dtCias = sqlExecute("select * from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))

            For Each row As DataRow In dtCias.Rows
                dtTemporal = sqlExecute("SELECT cod_depto FROM deptos where cod_comp = '" & row("cod_comp") & "' AND cod_depto = '" & txtCodigo.Text & "'")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe el departamento '" & txtCodigo.Text & "' asignado a la compañía '" & row("cod_comp") & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                End If
            Next

            For Each row As DataRow In dtCias.Rows
                Dim CC As String = ""
                Dim super As String = ""

                sqlExecute("INSERT INTO deptos (cod_comp,cod_depto,nombre,nombre_ingles,centro_costos,cod_super) VALUES ('" & _
                                           row("cod_comp") & "','" & _
                                           txtCodigo.Text & "','" & _
                                           txtNombre.Text & "','" & _
                                           txtNombreIngles.Text & "','" & _
                                           CC & "','" & super & "')")

                Agregar = False

            Next

        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro

            dtCias = sqlExecute("select * from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))

            For Each row As DataRow In dtCias.Rows
                Dim dttabla As DataTable = sqlExecute("select *  from deptos where cod_comp = '" & row("cod_comp") & "' and cod_depto = '" & txtCodigo.Text & "'")


                Dim CC As String = ""
                Dim Super As String = ""
                sqlExecute("UPDATE deptos SET " & _
                           "nombre = '" & txtNombre.Text & _
                           "', nombre_ingles = '" & txtNombreIngles.Text & _
                           "', centro_costos = '" & CC & _
                           "', cod_super = '" & Super & _
                           "' WHERE cod_depto = '" & txtCodigo.Text & "' AND cod_comp = '" & row("cod_comp") & "'")
            Next
            'If MessageBox.Show("¿Desea actualizar a todos los empleados de este departamento?", "Actualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '    For Each fila As DataRow In dtCias.Rows
            '        'sqlExecute("select cod_super, cod_depto from personal where cod_comp='" & fila("cod_comp") & "' and cod_depto='" & txtCodigo.Text & "'")
            '        sqlExecute("update personal set cod_super='" & cmbSuper.SelectedValue & "' where cod_depto='" & txtCodigo.Text & "'AND cod_comp = '" & fila("cod_comp") & "'")
            '    Next
            'End If

        Else
            Agregar = True
        End If
        Editar = False


        HabilitarBotones()
    End Sub


    Private Sub dgTabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellContentClick

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
       frmVistaPrevia.LlamarReporte("Departamentos", sqlExecute("select distinct deptos.cod_comp,deptos.COD_DEPTO,deptos.nombre,deptos.NOMBRE_INGLES,deptos.CENTRO_COSTOS,deptos.COD_SUPER,super.NOMBRE as 'nombre_super' from personal.dbo.deptos LEFT JOIN personal.dbo.super on super.COD_SUPER = deptos.cod_super where deptos.cod_comp='" & cmbCia.SelectedValue & "'"))
        frmVistaPrevia.ShowDialog()

    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged

    End Sub

    Private Sub cmbCC_SelectedValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbCia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCia.SelectedValueChanged
        Try
            'dtSuper = sqlExecute("SELECT cod_super, nombre FROM super WHERE cod_comp = '" & cmbCia.SelectedValue & "' ORDER BY nombre")
            'cmbSuper.DataSource = dtSuper
            'cmbSuper.DisplayMembers = "cod_super, nombre"
            'cmbSuper.ValueMember = "cod_super"
        Catch ex As Exception

        End Try
        Try


            'dtSuper = sqlExecute("SELECT centro_costos, nombre FROM c_costos order by nombre asc")
            'cmbCC.DataSource = dtSuper
            'cmbCC.DisplayMembers = "centro_costos, nombre"
            'cmbCC.ValueMember = "centro_costos"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmpNav_Enter(sender As Object, e As EventArgs) Handles EmpNav.Enter

    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        DesdeGrid = True
        Dim depto As String = dgTabla.Rows(e.RowIndex).Cells("Código").Value
        Dim comp As String = dgTabla.Rows(e.RowIndex).Cells("Compañía").Value
        dtRegistro = sqlExecute("SELECT * from deptos WHERE cod_depto = '" & depto & "' AND cod_comp = '" & comp & "'")
        MostrarInformacion()
    End Sub
End Class