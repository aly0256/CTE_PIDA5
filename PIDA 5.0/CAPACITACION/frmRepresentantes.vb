Public Class frmRepresentantes
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim Firma As String
    Dim Repre As String
    Private Sub frmRepresentantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkEmpresa.Checked = True
        Repre = "where cod_representantes like '%C0%'"
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM representantes " & Repre & "  ORDER BY cod_representantes ASC ", "Capacitacion")
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
            txtCodigo.Focus()
            Firma = ""
        ElseIf Editar Then
            txtNombre.Focus()
        End If

    End Sub
    Private Sub chkEmpresa_CheckedChanged(sender As Object, e As EventArgs) Handles chkEmpresa.CheckedChanged
        If chkEmpresa.Checked = True Then
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM representantes where cod_representantes like '%C0%'  ORDER BY cod_representantes ASC ", "Capacitacion")
            MostrarInformacion()
        End If
    End Sub

    Private Sub chkEmpleados_CheckedChanged(sender As Object, e As EventArgs) Handles chkEmpleados.CheckedChanged
        If chkEmpleados.Checked = True Then
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM representantes where cod_representantes like '%E0%'  ORDER BY cod_representantes ASC ", "Capacitacion")
            MostrarInformacion()
        End If
    End Sub

    Private Sub MostrarInformacion()
        If chkEmpresa.Checked = True Then
            Repre = "where cod_representantes like '%C0%'"
        ElseIf chkEmpleados.Checked = True Then
            Repre = "where cod_representantes like '%E0%'"
        End If

        dtLista = sqlExecute("SELECT cod_representantes as 'Código',Nombre FROM representantes " & Repre & " ", "Capacitacion")
        dtLista.DefaultView.Sort = "Código"
        dgTabla.DataSource = dtLista
        dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


        Dim i As Integer

        Try
            txtCodigo.Text = dtRegistro.Rows(0).Item("cod_representantes")
            txtNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre")), "", dtRegistro.Rows(0).Item("nombre")).ToString.Trim           
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

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click       
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM representantes " & Repre & "  ORDER BY cod_representantes ASC ", "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM representantes " & Repre & " and cod_representantes <'" & txtCodigo.Text & "' ORDER BY cod_representantes DESC", "Capacitacion")
        If dtRegistro.Rows.Count < 1 Then
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM representantes " & Repre & " ORDER BY cod_representantes ASC", "Capacitacion")
        End If
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click       
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM representantes " & Repre & " and cod_representantes >'" & txtCodigo.Text & "' ORDER BY cod_representantes ASC", "Capacitacion")
        If dtRegistro.Rows.Count < 1 Then
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM representantes " & Repre & " ORDER BY cod_representantes DESC", "Capacitacion")
        End If
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM representantes " & Repre & " ORDER BY cod_representantes DESC", "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("capacitacion.dbo.representantes", "cod_representantes", "representantes", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from representantes where cod_representantes = '" & Cod & "'", "Capacitacion")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If Agregar Then
            If txtCodigo.Text.StartsWith("C") Or txtCodigo.Text.StartsWith("E") Then
                If txtCodigo.Text.Length > 4 Then
                    MessageBox.Show("El codigo de representante debe ser de 4 digitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If chkEmpresa.Checked = True Then
                    If txtCodigo.Text.StartsWith("E") Then
                        MessageBox.Show("Para empresa usar ""C"" en el codigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                ElseIf chkEmpleados.Checked = True Then
                    If txtCodigo.Text.StartsWith("C") Then
                        MessageBox.Show("Para empleado usar ""E"" en el codigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
            Else
                If txtCodigo.Text.Length > 3 Then
                    MessageBox.Show("El codigo de representante debe ser de 3 digitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If chkEmpresa.Checked = True Then
                    txtCodigo.Text = "C" & txtCodigo.Text
                ElseIf chkEmpleados.Checked = True Then
                    txtCodigo.Text = "E" & txtCodigo.Text
                End If
            End If
            ' Si Agregar, revisar si existe cod_instructor
            dtTemporal = sqlExecute("SELECT cod_representantes FROM representantes where cod_representantes = '" & txtCodigo.Text & "'", "Capacitacion")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe el representante '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                sqlExecute("INSERT INTO representantes (cod_representantes,nombre) VALUES ('" & txtCodigo.Text & "','" & txtNombre.Text & "')", "Capacitacion")
                cargar_firma()
                Agregar = False
            End If

        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE representantes SET nombre = '" & txtNombre.Text & "' WHERE cod_representantes = '" & txtCodigo.Text & "'", "Capacitacion")
            dtRegistro = sqlExecute("SELECT top 1 * from representantes where cod_representantes = '" & txtCodigo.Text & "'", "Capacitacion")
            cargar_firma()
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
            txtNombre.Focus()
        Else
            Editar = False
        End If
        Agregar = False
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If MessageBox.Show("¿Está seguro de borrar el registro " & Codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            sqlExecute("DELETE FROM representantes WHERE cod_representantes = '" & txtCodigo.Text & "'", "Capacitacion")
            btnSiguiente.PerformClick()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
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

    Private Sub btnVerFirma_Click(sender As Object, e As EventArgs) Handles btnVerFirma.Click
        If Firma <> "" Then
            picFirma.Visible = True
            picFirma.ImageLocation = Firma
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

    Private Sub btnVerFirma_MouseLeave(sender As Object, e As EventArgs) Handles btnVerFirma.MouseLeave
        picFirma.Visible = False
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("Representantes", sqlExecute("select * from representantes " & Repre & "", "Capacitacion"))
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub btnBorrarFirma_Click(sender As Object, e As EventArgs) Handles btnBorrarFirma.Click
        If MessageBox.Show("¿Estas seguro que quieres borrar la firma?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Firma)
            MostrarInformacion()
        End If
    End Sub
End Class