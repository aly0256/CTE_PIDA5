Public Class frmMotivoAccionDisciplinaria
#Region "Declaraciones"
    Dim dtLista As New DataTable
    Dim dtRegistro As New DataTable
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
            txtDetalle.Text = ""

            txtCodigo.Focus()
        ElseIf Editar Then
            txtDetalle.Focus()
        End If
    End Sub
    Private Sub MostrarInformacion()
        Dim i As Integer
        If dtRegistro.Rows.Count > 0 Then
            txtCodigo.Text = dtRegistro.Rows(0).Item("cod_motivo")
            txtDetalle.Text = dtRegistro.Rows(0).Item("nombre").ToString.Trim

            If Not DesdeGrid Then
                i = dtLista.DefaultView.Find(txtCodigo.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If
            DesdeGrid = False
            HabilitarBotones()
        End If
    End Sub
    Private Sub frmMotivoAccionDisciplinaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("select COD_MOTIVO as Código, NOMBRE as Detalle from cod_motivo_disciplinario")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtRegistro = sqlExecute("select top 1 * from cod_motivo_disciplinario order by cod_motivo asc")
            MostrarInformacion()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If Agregar Then
            If txtCodigo.Text.Trim.Length > 0 Then
                dtTemporal = sqlExecute("select cod_motivo from cod_motivo_disciplinario where cod_motivo='" & RTrim(txtCodigo.Text) & "'")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe el código'" & RTrim(txtCodigo.Text) & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                Else
                    sqlExecute("INSERT INTO cod_motivo_disciplinario (cod_motivo, nombre) VALUES ('" & RTrim(txtCodigo.Text) & "', '" & txtDetalle.Text & "')")
                    Agregar = False
                End If
            End If
        ElseIf Editar Then
            If txtCodigo.Text.Trim.Length > 0 Then
                ' Si Editar, entonces guardar cambios a registro
                sqlExecute("UPDATE cod_motivo_disciplinario SET nombre= '" & txtDetalle.Text & "' where cod_motivo = '" & txtCodigo.Text & "' ")
            End If
        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()

    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("cod_motivo_disciplinario", "(cod_motivo + nombre)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("cod_motivo_disciplinario", "(cod_motivo + nombre)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("cod_motivo_disciplinario", "(cod_motivo)", txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("cod_motivo_disciplinario", "(cod_motivo)", txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            HabilitarBotones()
            txtDetalle.Focus()
        Else
            Editar = False

            Agregar = False
            If txtCodigo.Text.Trim.Length > 0 Then
                dtRegistro = sqlExecute("select top 1 * from cod_motivo_disciplinario where cod_motivo = '" & txtCodigo.Text & "' order by cod_motivo asc")
            Else
                dtRegistro = sqlExecute("select top 1 * from cod_motivo_disciplinario order by cod_motivo asc")
            End If
            MostrarInformacion()
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("cod_motivo_disciplinario", "cod_motivo", "Motivos Disciplinarios", False, "Nombre")
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM cod_motivo_disciplinario WHERE cod_motivo = '" & Cod & "'")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        dtTemporal = sqlExecute("select * from accion_disciplinaria where cod_motivo = '" & txtCodigo.Text & "'")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & RTrim(txtCodigo.Text) & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM cod_motivo_disciplinario WHERE cod_motivo = '" & RTrim(txtCodigo.Text) & "'")
                btnSiguiente.PerformClick()
            End If
        End If

    End Sub

    Private Sub tabTabla_Click(sender As Object, e As EventArgs) Handles tabTabla.Click
        dtLista = sqlExecute("select COD_MOTIVO as Código, NOMBRE as Detalle from cod_motivo_disciplinario")
        dtLista.DefaultView.Sort = "Código"
        dgTabla.DataSource = dtLista
        dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            frmVistaPrevia.LlamarReporte("Motivos de Acciones Disciplinarias", sqlExecute("select * from cod_motivo_disciplinario"))
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub dgTabla_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        DesdeGrid = True
        Dim cod_motivo_tabla As String = dgTabla.Rows(e.RowIndex).Cells("Código").Value
        dtRegistro = sqlExecute("SELECT * FROM cod_motivo_disciplinario WHERE cod_motivo = '" & cod_motivo_tabla & "'")
        MostrarInformacion()
    End Sub
End Class