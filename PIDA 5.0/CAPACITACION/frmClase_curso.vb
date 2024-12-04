Public Class frmClase_curso

#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region

    Private Sub frmClase_curso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_clase_curso as 'Código', Nombre FROM clase_curso", "capacitacion")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            'dtRegistro = sqlExecute("SELECT TOP 1 * FROM clase_curso where activo=1 ORDER BY cod_clase_curso ASC ", "capacitacion")
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM clase_curso ORDER BY cod_clase_curso ASC ", "capacitacion")
            MostrarInformacion()
            'Exit Sub
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

        Try

            If dtRegistro.Rows.Count > 0 Then
                txtCodigo.Text = dtRegistro.Rows(0).Item("cod_clase_curso")
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
            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar mostrar la información de clase curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub btnCiasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("capacitacion.dbo.clase_curso", "cod_clase_curso", "clase_curso", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM clase_curso WHERE cod_clase_curso = '" & Cod & "' ", "Capacitacion")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("clase_curso", "cod_clase_curso", dtRegistro, "capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("clase_curso", "cod_clase_curso", txtCodigo.Text, dtRegistro, "capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("clase_curso", "cod_clase_curso", txtCodigo.Text, dtRegistro, "capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Codigo = txtCodigo.Text.Trim
        'dtTemporal = sqlExecute("SELECT clase_curso FROM cursos WHERE cod_clase_curso = '" & Codigo & "'", "capacitacion")
        dtTemporal = sqlExecute("SELECT cod_clase_curso FROM cursos WHERE cod_clase_curso = '" & Codigo & "'", "capacitacion")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & Codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM clase_curso WHERE cod_clase_curso = '" & Codigo & "'", "capacitacion")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, nom As String

        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value
        nom = dgTabla.Item("Nombre", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * FROM clase_curso WHERE cod_clase_curso = '" & cod & "' AND nombre = '" & nom & "'", "capacitacion")
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
        Ultimo("clase_curso", "cod_clase_curso", dtRegistro, "capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Agregar Then
            'Validar que no se intente insertar campos vacios
            If txtCodigo.Text.Trim = "" Then
                MessageBox.Show("El código de clase curso no puede estar en blanco.", "Código de clase curso en blanco", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                txtCodigo.Focus()
                Exit Sub
            End If

            If txtNombre.Text.Trim = "" Then
                MessageBox.Show("El nonbre de clase curso no puede estar en blanco.", "Nombre de clase curso en blanco", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                txtNombre.Focus()
                Exit Sub
            End If

            ' Si Agregar, revisar si existe cod_clase_curso
            dtTemporal = sqlExecute("SELECT cod_clase_curso FROM clase_curso where cod_clase_curso = '" & txtCodigo.Text.Trim & "'", "capacitacion")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe '" & txtCodigo.Text.Trim & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                sqlExecute("INSERT INTO clase_curso (cod_clase_curso,nombre,activo) VALUES ('" & txtCodigo.Text.Trim & "','" & txtNombre.Text.Trim & "',1)", "capacitacion")
                Agregar = False
            End If

        ElseIf Editar Then
            'Validar que no se intente actualizar campos vacios
            If txtCodigo.Text.Trim = "" Then
                MessageBox.Show("El código de clase curso no puede estar en blanco.", "Código de clase curso en blanco", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                txtCodigo.Focus()
                Exit Sub
            End If

            If txtNombre.Text.Trim = "" Then
                MessageBox.Show("El nonbre de clase curso no puede estar en blanco.", "Nombre de clase curso en blanco", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                txtNombre.Focus()
                Exit Sub
            End If

            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE clase_curso SET nombre = '" & txtNombre.Text.Trim & "' WHERE cod_clase_curso = '" & txtCodigo.Text.Trim & "'", "capacitacion")
        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("Clase_curso", Nothing)
        frmVistaPrevia.ShowDialog()

    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged

    End Sub

    Private Sub picImagen_Click(sender As Object, e As EventArgs) Handles picImagen.Click

    End Sub

    Private Sub frmClase_curso_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class