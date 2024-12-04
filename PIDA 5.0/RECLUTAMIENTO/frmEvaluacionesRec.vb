Public Class frmEvaluacionesRec
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtCampos As New DataTable
    Dim dtValores As New DataTable
    Dim dtResultado As New DataTable

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean

    Dim evaluacion As String
#End Region

    Private Sub frmEvaluacionesRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtCuestionarios As New DataTable
        Dim itCuestionario As System.Windows.Forms.ListViewItem
        Try

            btnBuscaCuestionario.Location = txtBuscaCuestionario.Location
            txtBuscaCuestionario.Width = 0

            dtLista = sqlExecute("SELECT cod_evaluacion as 'Código',Nombre FROM evaluaciones", "RECLUTAMIENTO")
            dtLista.DefaultView.Sort = "Código"
            dtLista.PrimaryKey = New DataColumn() {dtLista.Columns("Código")}

            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


            dtCuestionarios = sqlExecute("SELECT cod_cuestionario,nombre FROM cuestionarios", "RECLUTAMIENTO")
            lstCuestionario.Items.Clear()
            For Each dCuestionario As DataRow In dtCuestionarios.Rows
                itCuestionario = New ListViewItem
                itCuestionario.Text = dCuestionario("cod_cuestionario")
                itCuestionario.Checked = False
                itCuestionario.SubItems.Add(dCuestionario("nombre"))
                lstCuestionario.Items.Add(itCuestionario)
            Next

            cmbEntrevistas.Items.Add("Entrevista RH")
            cmbEntrevistas.Items.Add("Entrevista Supervisor")

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM evaluaciones ORDER BY cod_evaluacion ASC ", "RECLUTAMIENTO")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub MostrarInformacion()
        Dim i As Integer
        Dim dtCuestionarios As New DataTable
        Dim Cuestionarios As String = ""
        Dim arCuestionarios() As String
        Dim itCuestionario As System.Windows.Forms.ListViewItem

        Try
            If dtRegistro.Rows.Count > 0 Then
                txtCodigo.Text = dtRegistro.Rows(0).Item("cod_evaluacion")
                txtNombre.Text = dtRegistro.Rows(0).Item("nombre").ToString.Trim
                Cuestionarios = IIf(IsDBNull(dtRegistro.Rows(0).Item("cuestionarios")), "", dtRegistro.Rows(0).Item("cuestionarios"))
                cmbEntrevistas.Text = dtRegistro.Rows(0).Item("filtro").ToString.Trim
            End If
            evaluacion = txtCodigo.Text
            arCuestionarios = Cuestionarios.Split(",")

            For Each chk As Windows.Forms.ListViewItem In lstCuestionario.CheckedItems
                chk.Checked = False
            Next

            For Each Cuestionarios In arCuestionarios
                itCuestionario = lstCuestionario.FindItemWithText(Cuestionarios.Trim.Replace("'", ""))
                If Not itCuestionario Is Nothing Then
                    itCuestionario.Checked = True
                End If
            Next
            txtBuscaCuestionario.Width = 0
            btnBuscaCuestionario.Location = txtBuscaCuestionario.Location

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
            Stop
        End Try
    End Sub

    Private Sub HabilitarBotones()
        btnPrimero.Enabled = Not (Agregar Or Editar)
        btnAnterior.Enabled = Not (Agregar Or Editar)
        btnSiguiente.Enabled = Not (Agregar Or Editar)
        btnUltimo.Enabled = Not (Agregar Or Editar)

        btnBuscar.Enabled = Not (Agregar Or Editar)
        btnBorrar.Enabled = Not (Agregar Or Editar)
        btnCerrar.Enabled = Not (Agregar Or Editar)
        btnReporte.Enabled = Not (Agregar Or Editar)
        pnlDatos.Enabled = Agregar Or Editar

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

        If Agregar Then
            txtCodigo.Text = ""
            txtNombre.Text = ""
            txtCodigo.Focus()
        ElseIf Editar Then
            txtCodigo.Focus()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("reclutamiento.dbo.evaluaciones", "cod_evaluacion", "estado evaluaciones", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM evaluaciones WHERE cod_evaluacion = '" & Cod & "' ", "RECLUTAMIENTO")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("evaluaciones", "cod_evaluacion", dtRegistro, "RECLUTAMIENTO")
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("evaluaciones", "cod_evaluacion", txtCodigo.Text, dtRegistro, "RECLUTAMIENTO")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("evaluaciones", "cod_evaluacion", txtCodigo.Text, dtRegistro, "RECLUTAMIENTO")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            dtTemporal = sqlExecute("SELECT cod_pregunta FROM preguntas WHERE cod_evaluacion = '" & txtCodigo.Text & "'", "RECLUTAMIENTO")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("No puede borrarse un registro que ya se encuentre asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If MessageBox.Show("¿Está seguro de borrar el registro " & evaluacion & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    sqlExecute("DELETE FROM evaluaciones WHERE cod_evaluacion = '" & evaluacion & "'", "RECLUTAMIENTO")
                    btnSiguiente.PerformClick()
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgTabla_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, nom As String

        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value
        nom = dgTabla.Item("Nombre", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * FROM evaluaciones WHERE cod_evaluacion = '" & cod & "' AND nombre = '" & nom & "'", "RECLUTAMIENTO")
        MostrarInformacion()
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

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("evaluaciones", "cod_evaluacion", dtRegistro, "RECLUTAMIENTO")
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim CambioEfectuado As Boolean
        CambioEfectuado = True
        Dim Cuestionarios As String = ""
        Try
            If Agregar Or Editar Then
                For Each itCuestionario As Windows.Forms.ListViewItem In lstCuestionario.CheckedItems
                    Cuestionarios = Cuestionarios & itCuestionario.Text & ","
                Next
                Cuestionarios = (Cuestionarios.Trim & "@").Replace(",@", "")
            End If

            If Agregar Then
                ' Si Agregar, revisar si existe evaluacion
                dtTemporal = sqlExecute("SELECT cod_evaluacion FROM evaluaciones where cod_evaluacion = '" & txtCodigo.Text & "'", "RECLUTAMIENTO")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                Else
                    dtTemporal = sqlExecute("INSERT INTO evaluaciones (cod_evaluacion,nombre,filtro,cuestionarios) VALUES ('" & _
                                            txtCodigo.Text & "','" & txtNombre.Text & "','" & cmbEntrevistas.Text.Trim & "','" & Cuestionarios & "')", "RECLUTAMIENTO")
                    CambioEfectuado = Not (dtTemporal Is New DataTable)
                    Agregar = False
                    evaluacion = txtCodigo.Text
                End If

            ElseIf Editar Then
                ' Si Editar, entonces guardar cambios a registro
                sqlExecute("UPDATE evaluaciones SET nombre = '" & txtNombre.Text & _
                           "', cod_evaluacion = '" & txtCodigo.Text & _
                           "', filtro = '" & cmbEntrevistas.Text.Trim & _
                           "', cuestionarios = '" & Cuestionarios & _
                           "' WHERE cod_evaluacion = '" & evaluacion & "'", "RECLUTAMIENTO")
            Else
                Agregar = True
            End If
            Editar = False


            Dim dr As DataRow
            dr = dtLista.Rows.Find(evaluacion)
            If IsNothing(dr) Then
                dtLista.Rows.Add({txtCodigo.Text, txtNombre.Text})
            Else
                dr("Código") = txtCodigo.Text
                dr("nombre") = txtNombre.Text
            End If

            dtRegistro = sqlExecute("SELECT * FROM evaluaciones WHERE cod_evaluacion = '" & evaluacion & "' ORDER BY cod_evaluacion ASC ", "RECLUTAMIENTO")
            MostrarInformacion()
            HabilitarBotones()
        Catch
            If Not Agregar Then
                MessageBox.Show("Se detectó un error y el cambio no pudo ser guardado. Favor de verificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("EvaluacionesRec", Nothing)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub txtCodigo_Validated(sender As Object, e As EventArgs) Handles txtCodigo.Validated
        If Editar Or Agregar Then
            txtCodigo.Text = txtCodigo.Text.Trim.PadLeft(txtCodigo.MaxLength, "0")
        End If
    End Sub

    Private Sub btnBuscaCuestionario_Click(sender As Object, e As EventArgs) Handles btnBuscaCuestionario.Click
        Static Buscar As Boolean = False
        Try
            If Buscar Then
                For x = 145 To 1 Step -1
                    txtBuscaCuestionario.Width = x
                    btnBuscaCuestionario.Location = New Point(txtBuscaCuestionario.Location.X + x + 10, txtBuscaCuestionario.Location.Y)
                    Application.DoEvents()
                Next
                btnBuscaCuestionario.Image = My.Resources.Find16
            Else
                For x = 0 To 145
                    txtBuscaCuestionario.Width = x
                    btnBuscaCuestionario.Location = New Point(txtBuscaCuestionario.Location.X + x + 10, txtBuscaCuestionario.Location.Y)
                    Application.DoEvents()
                Next
                btnBuscaCuestionario.Image = My.Resources.DoorOut16
                txtBuscaCuestionario.Focus()
            End If
            Buscar = Not Buscar

        Catch ex As Exception
            Buscar = False
            txtBuscaCuestionario.Visible = False
            btnBuscaCuestionario.Visible = False
        End Try
    End Sub

    Private Sub txtBuscaCuestionario_TextChanged(sender As Object, e As EventArgs) Handles txtBuscaCuestionario.TextChanged
        Dim itCuestionario As Windows.Forms.ListViewItem

        For Each itCuestionario In lstCuestionario.Items
            If itCuestionario.Text.ToUpper.Contains(txtBuscaCuestionario.Text.ToUpper) Or _
                itCuestionario.SubItems(1).Text.ToUpper.Contains(txtBuscaCuestionario.Text.ToUpper) Then

                lstCuestionario.TopItem = itCuestionario
                itCuestionario.Selected = True
                Exit For
            End If
        Next
    End Sub
End Class