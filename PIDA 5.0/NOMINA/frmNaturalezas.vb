Public Class frmNaturalezas
#Region "Declaraciones"
    Dim dtLista As New DataTable               'Lista de datos para grid
    Dim dtRegistro As New DataTable            'Mantiene el registro actual
    Dim dtNaturaleza As New DataTable          'Tabla de naturaleza

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region
    Private Sub pnlDatos_Click(sender As Object, e As EventArgs) Handles pnlDatos.Click

    End Sub

    Private Sub frmNaturalezas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_naturaleza as 'Código',nombre as 'Descripción' FROM naturalezas", "nomina")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM naturalezas ORDER BY cod_naturaleza", "nomina")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub MostrarInformacion()
        Dim i As Integer

        Try

            txtCodigo.Text = dtRegistro.Rows(0).Item("cod_naturaleza")
            txtNombre.Text = dtRegistro.Rows(0).Item("nombre")
            
            If Not DesdeGrid Then 'si no estoy en dg toma ubica el valor dentro del dg
                i = dtLista.DefaultView.Find(txtCodigo.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If
            DesdeGrid = False
            HabilitarBotones()

        Catch ex As Exception    '  pone si hay erro en pantalla de abajo
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub HabilitarBotones()
        Dim NoRec As Boolean
        NoRec = dgTabla.Rows.Count = 0
        btnPrimero.Enabled = Not (Agregar Or Editar Or NoRec)    'se va a habilitar cuando no este agregando  ni editando y haya por lo menos 1 registro
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
            btnNuevo.Image = My.Resources.Ok16
            btnEditar.Image = My.Resources.CancelX
            btnNuevo.Text = "Aceptar"
            btnEditar.Text = "Cancelar"
            tabBuscar.SelectedTabIndex = 0
        Else

            btnNuevo.Image = My.Resources.NewRecord
            btnEditar.Image = My.Resources.Edit

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
    Private Sub btnCiasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("nomina.dbo.naturalezas", "cod_naturaleza", "CODIGO", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from naturalezas WHERE cod_naturaleza = '" & Cod & "'", "nomina")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("naturalezas", "cod_naturaleza", dtRegistro, "nomina")
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior(" naturalezas", "cod_naturaleza", txtCodigo.Text, dtRegistro, "nomina")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente(" naturalezas", "cod_naturaleza", txtCodigo.Text, dtRegistro, "nomina")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String
        codigo = txtCodigo.Text
        If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            sqlExecute("DELETE FROM  naturalezas WHERE cod_naturaleza = '" & codigo & "'", "nomina")
            btnSiguiente.PerformClick()
        End If
    End Sub



    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, nom As String

        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value.ToString.Trim
        nom = dgTabla.Item("descripcion", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * from  naturalezas WHERE cod_naturaleza = '" & cod & "'", "nomina")
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
        Ultimo(" naturalezas", "cod_naturaleza", dtRegistro, "nomina")
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe cod_naturaleza+concepto
            dtTemporal = sqlExecute("SELECT cod_naturaleza FROM  naturalezas where cod_naturaleza = '" & txtCodigo.Text & "'", "nomina")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe la Naturaleza '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                sqlExecute("INSERT INTO  naturalezas (cod_naturaleza) VALUES ('" & txtCodigo.Text & "')", "nomina")
                sqlExecute("UPDATE  naturalezas SET nombre = '" & txtNombre.Text & "' " & _
                " WHERE cod_naturaleza = '" & txtCodigo.Text & "'", "nomina")

                Agregar = False
            End If
        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE  naturalezas SET nombre = '" & txtNombre.Text & "' " & _
                           " WHERE cod_naturaleza = '" & txtCodigo.Text & "'", "nomina")
        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()
    End Sub

    Private Sub dgTabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellContentClick

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("Naturalezas de nómina", New DataTable)
        frmVistaPrevia.ShowDialog()
    End Sub
End Class