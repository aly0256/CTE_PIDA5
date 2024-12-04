Public Class frmTipoDisciplinario
#Region "Declaraciones"
    Dim dtLista As New DataTable
    Dim dtRegistro As New DataTable
    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region

    Private Sub MostrarInformacion()
        Dim i As Integer

        txtTipo.Text = dtRegistro.Rows(0).Item("tipo_accion_disciplinaria")

        txtCodigo.Text = dtRegistro.Rows(0).Item("cod_tipo_accion")


        DesdeGrid = False
        HabilitarBotones()

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
            txtTipo.Text = ""

            txtCodigo.Text = ""
            txtCodigo.Focus()
        ElseIf Editar Then

        End If
    End Sub
    Private Sub frmTipoDisciplinario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtLista = sqlExecute("select COD_TIPO_ACCION as Código, TIPO_ACCION_DISCIPLINARIA as Tipo from tipo_disciplinaria order by cod_tipo_accion asc")
        dtLista.DefaultView.Sort = "Código"
        dgTabla.DataSource = dtLista
        dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        dtRegistro = sqlExecute("select top 1 * from tipo_disciplinaria order by cod_tipo_accion asc")
        MostrarInformacion()

    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("tipo_disciplinaria", "(cod_tipo_accion)", dtRegistro)
        MostrarInformacion()

    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("tipo_disciplinaria", "(cod_tipo_accion)", dtRegistro)
        MostrarInformacion()

    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("tipo_disciplinaria", "(cod_tipo_accion)", txtCodigo.Text, dtRegistro)
        MostrarInformacion()

    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("tipo_disciplinaria", "(cod_tipo_accion)", txtCodigo.Text, dtRegistro)
        MostrarInformacion()

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If Agregar Then
            dtTemporal = sqlExecute("select cod_tipo_accion from tipo_disciplinaria where cod_tipo_accion='" & txtCodigo.Text & "' and tipo_accion_disciplinaria='" & txtTipo.Text & "'")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe el codigo'" & RTrim(txtCodigo.Text) & "' u el tipo deaccion disciplinaria '" & RTrim(txtTipo.Text) & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                sqlExecute("INSERT INTO tipo_disciplinaria (cod_tipo_accion, tipo_accion_disciplinaria) VALUES ('" & RTrim(txtCodigo.Text) & "', '" & txtTipo.Text & "')")
                Agregar = False
            End If
        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE tipo_disciplinaria SET   tipo_accion_disciplinaria = '" & txtTipo.Text & "' where cod_tipo_accion='" & txtCodigo.Text & "'")

        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            HabilitarBotones()
            txtTipo.Focus()
        Else
            Editar = False
            Agregar = False
            dtRegistro = sqlExecute("select top 1 * from tipo_disciplinaria where cod_tipo_accion='" & txtCodigo.Text & "' by cod_tipo_accion asc")
            MostrarInformacion()
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub


    Private Sub tabTabla_Click(sender As Object, e As EventArgs) Handles tabTabla.Click
        dtLista = sqlExecute("select COD_TIPO_ACCION as Código, TIPO_ACCION_DISCIPLINARIA as Tipo from tipo_disciplinaria order by cod_tipo_accion asc")
        dtLista.DefaultView.Sort = "Código"
        dgTabla.DataSource = dtLista
        dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        dtTemporal = sqlExecute("select * from accion_disciplinaria where cod_tipo_accion = '" & txtCodigo.Text & "'")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & RTrim(txtCodigo.Text) & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM tipo_disciplinaria WHERE cod_tipo_accion = '" & RTrim(txtCodigo.Text) & "'")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("tipo_disciplinaria", "cod_tipo_accion", "Tipo Accion Disciplinaria", False, "TIPO_ACCION_DISCIPLINARIA")
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM tipo_disciplinaria WHERE cod_tipo_accion = '" & Cod & "'")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            frmVistaPrevia.LlamarReporte("Tipo de acción disciplinaria", sqlExecute("select * from tipo_disciplinaria"))
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgTabla_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        DesdeGrid = True
        Dim cod_motivo_tabla As String = dgTabla.Rows(e.RowIndex).Cells("Código").Value
        dtRegistro = sqlExecute("SELECT * FROM tipo_disciplinaria WHERE cod_tipo_accion = '" & cod_motivo_tabla & "'")
        MostrarInformacion()
    End Sub
End Class