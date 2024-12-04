Public Class frmClerks
#Region "Declaraciones"

    Dim dtLista As DataTable        'Lista de datos para grid
    Dim dtRegistro As DataTable     'Mantiene el registro actual

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

        txtCodigo.Enabled = False

        If Agregar Then
            txtCodigo.Text = CodClerkDisponible()
            txtNombre.Text = ""
            txtCorreo.Text = ""
            swActivo.ValueObject = False
            txtCodigo.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If

    End Sub

    Private Sub MostrarInformacion()
        Dim i As Integer

        txtCodigo.Text = dtRegistro.Rows(0).Item("cod_clerk")
        txtNombre.Text = dtRegistro.Rows(0).Item("nombre").ToString.Trim
        txtCorreo.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("correo")), "", dtRegistro.Rows(0).Item("correo"))
        swActivo.ValueObject = IIf(IsDBNull(dtRegistro.Rows(0).Item("activo")), 0, dtRegistro.Rows(0).Item("activo"))

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

    Private Function CodClerkDisponible() As String

        Dim dtCodClerkDisponible As New DataTable
        Dim valor As String = ""

        Try

            dtCodClerkDisponible = sqlExecute("select top 1 (convert(int,cod_clerk) + 1) as cod_clerk from clerks order by cod_clerk desc")

            If Not dtCodClerkDisponible.Columns.Contains("ERROR") Then

                If dtCodClerkDisponible.Rows.Count > 0 Then

                    valor = dtCodClerkDisponible.Rows(0).Item("cod_clerk").ToString.PadLeft(3, "0")

                Else

                    valor = "000"

                End If

                If valor.Length > 3 Then
                    valor = ""
                End If

            End If

        Catch ex As Exception
            valor = ""
        End Try


        Return valor
    End Function

    Private Sub frmClerks_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            dtLista = sqlExecute("SELECT cod_clerk as 'Código',rtrim(isnull(nombre,'')) as 'Nombre' FROM clerks")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM clerks ORDER BY cod_clerk ASC")
            MostrarInformacion()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmClerks_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("clerks", "cod_clerk", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("clerks", "cod_clerk", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("clerks", "cod_clerk", txtCodigo.Text.Trim, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("clerks", "cod_clerk", txtCodigo.Text.Trim, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try

            If Agregar Then

                If txtCodigo.Text.Trim = "" Then
                    MessageBox.Show("Código Clerk no asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If txtNombre.Text.Trim = "" Then
                    MessageBox.Show("Favor de ingresar un nombre de clerk.", "Nombre de clerk en blanco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtNombre.Focus()
                    Exit Sub
                End If

                dtTemporal = sqlExecute("SELECT top 1 cod_clerk FROM clerks where cod_clerk = '" & txtCodigo.Text & "'")

                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe el clerk '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                End If

                sqlExecute("INSERT INTO clerks (cod_clerk,nombre,correo,activo) VALUES ('" & txtCodigo.Text.Trim & "','" & txtNombre.Text.Trim & "','" & txtCorreo.Text.Trim & "'," & IIf(swActivo.Value, 1, 0) & ")")

                Agregar = False

            ElseIf Editar Then

                If txtCodigo.Text.Trim = "" Then
                    MessageBox.Show("Código Clerk no asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If txtNombre.Text.Trim = "" Then
                    MessageBox.Show("Favor de ingresar un nombre de clerk.", "Nombre de clerk en blanco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtNombre.Focus()
                    Exit Sub
                End If

                sqlExecute("UPDATE clerks SET nombre = '" & txtNombre.Text.Trim & "', correo = '" & txtCorreo.Text.Trim & "', activo = " & IIf(swActivo.Value, 1, 0) & " WHERE cod_clerk = '" & txtCodigo.Text.Trim & "'")

            Else
                Agregar = True

            End If

            Editar = False

            HabilitarBotones()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
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

        Dim codigo As String = txtCodigo.Text.Trim

        dtTemporal = sqlExecute("SELECT top 1 reloj from personalvw WHERE cod_clerk = '" & codigo & "'")

        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM clerks WHERE cod_clerk = '" & codigo & "'")
                btnSiguiente.PerformClick()
            End If
        End If

    End Sub

    Private Sub dgTabla_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String

        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * from clerks WHERE cod_clerk = '" & cod & "'")
        MostrarInformacion()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("clerks", "cod_clerk", "Clerk", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from clerks WHERE cod_clerk = '" & Cod & "'")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtDatos As New DataTable
        dtDatos = sqlExecute("SELECT * FROM clerks")
        frmVistaPrevia.LlamarReporte("Clerks", dtDatos)
        frmVistaPrevia.ShowDialog()
    End Sub
End Class