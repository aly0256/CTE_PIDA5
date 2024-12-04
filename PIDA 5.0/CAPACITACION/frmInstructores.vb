Public Class frmInstructores
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtCias As New DataTable         'Tabla de compañías
    Dim dtSuper As New DataTable        'Tabla de supervisores

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim Firma As String
#End Region


    Private Sub frmInstructores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_instructor as 'Código',Nombre FROM Instructores", "Capacitacion")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM Instructores ORDER BY cod_instructor ASC ", "Capacitacion")
            MostrarInformacion()

            '---- AO: Revisar perfiles para ver si tiene acceso a los botones
            Dim _visible As Boolean = True
            _visible = revisarPerfiles(Perfil, Me, _visible, "WME", "")
            btnNuevo.Visible = _visible
            btnEditar.Visible = _visible
            btnBorrar.Visible = _visible
            btnBuscarFirma.Visible = _visible
            btnVerFirma.Visible = _visible
            btnBorrarFirma.Visible = _visible
        Catch ex As Exception
            MessageBox.Show("Se ha detectado un error en la tabla de Instructores", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        'pnlDatos.Enabled = Agregar Or Editar

        txtCodigo.Enabled = Agregar Or Editar
        txtNombre.Enabled = Agregar Or Editar
        btnExterno.Enabled = Agregar Or Editar
        txtRegstps.Enabled = Agregar Or Editar
        btnBuscarFirma.Enabled = Agregar Or Editar




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
            txtRegstps.Text = ""
            btnExterno.Value = False
            txtCodigo.Focus()
            Firma = ""
        ElseIf Editar Then
            txtNombre.Focus()
        End If

        txtRegstps.Enabled = btnExterno.Value And (Editar Or Agregar)

    End Sub
    Private Sub MostrarInformacion()
        Dim i As Integer

        Try
            txtCodigo.Text = dtRegistro.Rows(0).Item("cod_instructor")
            txtNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre")), "", dtRegistro.Rows(0).Item("nombre")).ToString.Trim
            txtRegstps.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("reg_stps")), "", dtRegistro.Rows(0).Item("reg_stps")).ToString.Trim
            btnExterno.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("Externo")), 0, dtRegistro.Rows(0).Item("Externo")) = 1
            Firma = PathFirma & Trim(txtCodigo.Text) & ".jpg"
            If Dir(Firma).Length <> 0 Then
                btnVerFirma.Visible = True
                btnBorrarFirma.Visible = True
            Else
                btnVerFirma.Visible = False
                btnBorrarFirma.Visible = False
                Firma = ""
            End If
            If Not DesdeGrid Then
                i = dtLista.DefaultView.Find(txtCodigo.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If
            DesdeGrid = False
            HabilitarBotones()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("capacitacion.dbo.instructores", "cod_instructor", "Instructores", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from Instructores WHERE cod_instructor = '" & Cod & "'", "Capacitacion")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("Instructores", "cod_instructor", dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("Instructores", "cod_instructor", txtCodigo.Text, dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String
        codigo = txtCodigo.Text
        dtTemporal = sqlExecute("SELECT reloj FROM cursos_empleado WHERE cod_instructor = '" & codigo & "'", "Capacitacion")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM Instructores WHERE cod_instructor = '" & codigo & "'", "Capacitacion")
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
        dtRegistro = sqlExecute("SELECT * from Instructores WHERE cod_instructor = '" & cod & "' AND nombre = '" & nom & "'", "Capacitacion")
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
        Ultimo("Instructores", "cod_instructor", dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe cod_instructor
            dtTemporal = sqlExecute("SELECT cod_instructor FROM Instructores where cod_instructor = '" & txtCodigo.Text & "'", "Capacitacion")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe el instructor '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                sqlExecute("INSERT INTO Instructores (cod_instructor,nombre,reg_stps,externo) VALUES ('" & txtCodigo.Text & "','" & txtNombre.Text & "','" & txtRegstps.Text & "'," & IIf(btnExterno.Value, 1, 0) & ")", "Capacitacion")
                cargar_firma()
                Agregar = False
            End If

        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE Instructores SET nombre = '" & txtNombre.Text & "', reg_stps = '" & txtRegstps.Text & "', externo = " & IIf(btnExterno.Value, 1, 0) & " WHERE cod_instructor = '" & txtCodigo.Text & "'", "Capacitacion")
            dtRegistro = sqlExecute("SELECT top 1 * from Instructores WHERE cod_instructor = '" & txtCodigo.Text & "'", "Capacitacion")
            cargar_firma()
        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("Instructores", New DataTable)
        frmVistaPrevia.ShowDialog()

    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("Instructores", "cod_instructor", txtCodigo.Text, dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnExterno_ValueChanged(sender As Object, e As EventArgs) Handles btnExterno.ValueChanged
        txtRegstps.Enabled = btnExterno.Value And (Editar Or Agregar)
    End Sub

    Private Sub txtCodigo_Validated(sender As Object, e As EventArgs) Handles txtCodigo.Validated
        txtCodigo.Text = txtCodigo.Text.Trim.PadLeft(5, "0")
    End Sub

    Private Sub btnBuscarFirma_Click(sender As Object, e As EventArgs) Handles btnBuscarFirma.Click
        openFirma.Filter = "JPEG files (*.jpg)|*.jpg| All Files|*.*"
        openFirma.CheckFileExists = True
        Dim lDialogResult As DialogResult = openFirma.ShowDialog()

        If lDialogResult = Windows.Forms.DialogResult.Cancel Then           
            Exit Sub
        Else
            Firma = openFirma.FileName
        End If
    End Sub

    Private Sub cargar_firma()
        Dim origen As String = Firma
        If PathFirma <> Nothing Then
            Dim destino As String = PathFirma & Trim(txtCodigo.Text) & ".jpg"
            If Not My.Computer.FileSystem.DirectoryExists(PathFirma) Then
                My.Computer.FileSystem.CreateDirectory(PathFirma)
            End If
            If origen.Trim.Length > 0 Then
                If origen.Equals(destino) Then
                Else
                    My.Computer.FileSystem.CopyFile(origen, Trim(destino), True)
                End If
            End If
        End If
        MostrarInformacion()

    End Sub

    Private Sub btnVerFirma_Click(sender As Object, e As EventArgs) Handles btnVerFirma.Click
        If Firma <> "" Then
            picFirma.Visible = True
            picFirma.ImageLocation = Firma
        End If
    End Sub

    Private Sub btnVerFirma_MouseLeave(sender As Object, e As EventArgs) Handles btnVerFirma.MouseLeave
        picFirma.Visible = False
    End Sub


    Private Sub btnBorrarFirma_Click(sender As Object, e As EventArgs) Handles btnBorrarFirma.Click
        If MessageBox.Show("¿Estas seguro que quieres borrar la firma?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Firma)
            MostrarInformacion()
        End If
    End Sub
End Class