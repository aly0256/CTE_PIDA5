Public Class frmCatExternos
    Public id As String = ""
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

    Private Sub frmCatExternos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT externos.ID as 'Código',RTRIM(externos.NOMBRE) + ' ' + RTRIM(externos.APATERNO) + ' '+ RTRIM(externos.AMATERNO) as 'Nombre',cias_externas.nombre as 'Compañía' FROM externos LEFT JOIN cias_externas on externos.compania=cias_externas.cia", "sermed")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            Dim dtCia As DataTable = sqlExecute("select cia as 'codigo',nombre as 'nombre' from cias_externas", "sermed")
            cmbCia.DataSource = dtCia
            cmbCia.ValueMember = "codigo"

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM externos ORDER BY ID ASC", "sermed")
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

        'chkTodasLasCias.Visible = (Agregar Or Editar Or NoRec)

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

        'txtCodigo.Enabled = Agregar
        'cmbCia.Enabled = Agregar


        If Agregar Then
            txtID.Text = ""
            txtNombre.Text = ""
            txtAmaterno.Text = ""
            txtApaterno.Text = ""
            cmbCia.SelectedIndex = 0
            txtComentario.Text = ""
            txtDireccion.Text = ""
            txtIMSS.Text = ""
            txtTel1.Text = ""
            txtTel2.Text = ""
            txtTel3.Text = ""

            txtNombre.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If
    End Sub
    Private Sub MostrarInformacion()
        Dim i As Integer
        txtID.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("id").ToString.Trim), "", dtRegistro.Rows(0).Item("id").ToString.Trim)

        txtNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre").ToString.Trim), "", dtRegistro.Rows(0).Item("nombre").ToString.Trim)
        txtApaterno.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("apaterno").ToString.Trim), "", dtRegistro.Rows(0).Item("apaterno").ToString.Trim)
        txtAmaterno.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("amaterno").ToString.Trim), "", dtRegistro.Rows(0).Item("amaterno").ToString.Trim)

        txtIMSS.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("imss").ToString.Trim), "", dtRegistro.Rows(0).Item("imss").ToString.Trim)


        If IsDBNull(dtRegistro.Rows(0)("fha_nac")) Then
            CheckBoxX1.Checked = True
        Else
            CheckBoxX1.Checked = False
            txtFhaNac.Value = IIf(IsDBNull(dtRegistro.Rows(0)("fha_nac")), Now, dtRegistro.Rows(0)("fha_nac"))
        End If



        If IsDBNull(dtRegistro.Rows(0)("sexo")) Then
            btnSexo.Value = False
        Else
            btnSexo.Value = IIf(dtRegistro.Rows(0)("sexo") = "M", False, True)
        End If


        cmbCia.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("compania").ToString.Trim), "", dtRegistro.Rows(0).Item("compania").ToString.Trim)

        txtComentario.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("comentario").ToString.Trim), "", dtRegistro.Rows(0).Item("comentario").ToString.Trim)

        txtDireccion.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("direccion").ToString.Trim), "", dtRegistro.Rows(0).Item("direccion").ToString.Trim)

        txtTel1.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("telefono1").ToString.Trim), "", dtRegistro.Rows(0).Item("telefono1").ToString.Trim)
        txtTel2.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("telefono2").ToString.Trim), "", dtRegistro.Rows(0).Item("telefono2").ToString.Trim)
        txtTel3.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("telefono3").ToString.Trim), "", dtRegistro.Rows(0).Item("telefono3").ToString.Trim)

        If Not DesdeGrid Then
            i = dtLista.DefaultView.Find(txtID.Text)
            If i >= 0 Then
                dgTabla.FirstDisplayedScrollingRowIndex = i
                dgTabla.Rows(i).Selected = True
            End If
        End If
        DesdeGrid = False
        HabilitarBotones()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        id = txtID.Text
        Me.Close()
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("externos", "ID", "USUARIOS EXTERNOS", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from externos WHERE ID = '" & Cod & "'", "SERMED")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("externos", "ID", dtRegistro, "sermed")
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("externos", "ID", txtID.Text, dtRegistro, "sermed")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("externos", "ID", txtID.Text, dtRegistro, "sermed")
        MostrarInformacion()
    End Sub
    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Ultimo("externos", "ID", dtRegistro, "sermed")
        MostrarInformacion()
    End Sub
    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Codigo = txtID.Text
        If MessageBox.Show("¿Está seguro de borrar el registro " & Codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            sqlExecute("DELETE FROM SERMED.DBO.externos WHERE ID = '" & Codigo & "'")
            btnSiguiente.PerformClick()
        End If
    End Sub
    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next
        Dim cod As String, nom As String
        DesdeGrid = True
        Dim familiar As String = dgTabla.Rows(e.RowIndex).Cells("Código").Value
        dtRegistro = sqlExecute("SELECT * FROM EXTERNOS WHERE ID= '" & familiar & "'", "SERMED")
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
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe cod_familia
            dtTemporal = sqlExecute("SELECT ID FROM externos where ID = '" & txtID.Text & "'", "sermed")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe el usuario '" & txtID.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNombre.Focus()
                Exit Sub
            Else
                Dim dtNvoID As DataTable
                dtNvoID = sqlExecute("select MAX(ID)+1 as 'id_nuevo' from externos", "sermed")
                txtID.Text = dtNvoID.Rows(0)("id_nuevo")
                sqlExecute("INSERT INTO sermed.dbo.externos (nombre, apaterno, amaterno, compania, alta, usuario_alta)" & _
                           "VALUES ('" & txtNombre.Text & "', '" & txtApaterno.Text & "', '" & txtAmaterno.Text & "', '" & cmbCia.SelectedValue & "', '" & FechaSQL(Now) & "', '" & Usuario & "')")

                If Not CheckBoxX1.Checked Then
                    sqlExecute("UPDATE sermed.dbo.externos SET fha_nac='" & txtFhaNac.Value & "' WHERE ID = '" & txtID.Text & "'")
                Else
                    sqlExecute("UPDATE sermed.dbo.externos SET fha_nac= null WHERE ID = '" & txtID.Text & "'")
                End If

                sqlExecute("UPDATE sermed.dbo.externos SET sexo = '" & IIf(btnSexo.Value, "F", "M") & "' WHERE ID = '" & txtID.Text & "'")
                sqlExecute("UPDATE sermed.dbo.externos SET imss='" & txtIMSS.Text & "' WHERE ID = '" & txtID.Text & "'")
                sqlExecute("UPDATE sermed.dbo.externos SET direccion='" & txtDireccion.Text & "' WHERE ID = '" & txtID.Text & "'")
                sqlExecute("UPDATE sermed.dbo.externos SET telefono1='" & txtTel1.Text & "',telefono2='" & txtTel2.Text & "',telefono3='" & txtTel3.Text & "' WHERE ID = '" & txtID.Text & "'")

                sqlExecute("UPDATE sermed.dbo.externos SET comentario='" & txtComentario.Text & "'  WHERE ID = '" & txtID.Text & "'")
                id = txtID.Text
                Agregar = False
            End If

        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE sermed.dbo.externos SET nombre = '" & txtNombre.Text & "',apaterno='" & txtApaterno.Text & "',amaterno='" & txtAmaterno.Text & "' WHERE ID = '" & txtID.Text & "'")

            If Not CheckBoxX1.Checked Then
                sqlExecute("UPDATE sermed.dbo.externos SET fha_nac='" & txtFhaNac.Value & "' WHERE ID = '" & txtID.Text & "'")
            Else
                sqlExecute("UPDATE sermed.dbo.externos SET fha_nac= null WHERE ID = '" & txtID.Text & "'")
            End If


            sqlExecute("UPDATE sermed.dbo.externos SET sexo = '" & IIf(btnSexo.Value, "F", "M") & "' WHERE ID = '" & txtID.Text & "'")
            sqlExecute("UPDATE sermed.dbo.externos SET imss='" & txtIMSS.Text & "' WHERE ID = '" & txtID.Text & "'")
            sqlExecute("UPDATE sermed.dbo.externos SET compania='" & cmbCia.SelectedValue & "' WHERE ID = '" & txtID.Text & "'")
            sqlExecute("UPDATE sermed.dbo.externos SET direccion='" & txtDireccion.Text & "' WHERE ID = '" & txtID.Text & "'")
            sqlExecute("UPDATE sermed.dbo.externos SET telefono1='" & txtTel1.Text & "',telefono2='" & txtTel2.Text & "',telefono3='" & txtTel3.Text & "' WHERE ID = '" & txtID.Text & "'")

            sqlExecute("UPDATE sermed.dbo.externos SET comentario='" & txtComentario.Text & "'  WHERE ID = '" & txtID.Text & "'")

            'sqlExecute("UPDATE sermed.dbo.externos SET alta='" & FechaSQL(Now) & "',usuario_alta='" & Usuario & "' WHERE ID = '" & txtID.Text & "'")            

        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()
    End Sub

    Private Sub CheckBoxX1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX1.CheckedChanged
        txtFhaNac.Enabled = Not CheckBoxX1.Checked

        If CheckBoxX1.Checked Then
            txtFhaNac.AllowEmptyState = True
            txtFhaNac.IsEmpty = True
        End If

    End Sub
End Class