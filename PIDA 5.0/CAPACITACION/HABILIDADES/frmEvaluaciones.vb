Public Class frmEvaluaciones
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


    Private Sub frmEvaluaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtCuestionarios As New DataTable
        Dim itCuestionario As System.Windows.Forms.ListViewItem
        Try

            btnBuscaCuestionario.Location = txtBuscaCuestionario.Location
            txtBuscaCuestionario.Width = 0

            gpFiltro.Location = pnlCriterio.Location
            gpFiltro.Visible = False

            dtCampos = sqlExecute("SELECT nombre AS 'NOMBRE',UPPER(cod_campo) as 'COD_CAMPO',tipo FROM campos WHERE tipo='char' ORDER BY nombre")
            cbCampos.DataSource = dtCampos

            dtLista = sqlExecute("SELECT cod_evaluacion as 'Código',Nombre FROM evaluaciones", "CAPACITACION")
            dtLista.DefaultView.Sort = "Código"
            dtLista.PrimaryKey = New DataColumn() {dtLista.Columns("Código")}

            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


            dtCuestionarios = sqlExecute("SELECT cod_cuestionario,nombre FROM cuestionarios", "CAPACITACION")
            lstCuestionario.Items.Clear()
            For Each dCuestionario As DataRow In dtCuestionarios.Rows
                itCuestionario = New ListViewItem
                itCuestionario.Text = dCuestionario("cod_cuestionario")
                itCuestionario.Checked = False
                itCuestionario.SubItems.Add(dCuestionario("nombre"))
                lstCuestionario.Items.Add(itCuestionario)
            Next

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM evaluaciones ORDER BY cod_evaluacion ASC ", "CAPACITACION")
            MostrarInformacion()

            '---- AO: Revisar perfiles para ver si tiene acceso a los botones
            Dim _visible As Boolean = True
            _visible = revisarPerfiles(Perfil, Me, _visible, "WME", "")
            btnNuevo.Visible = _visible
            btnEditar.Visible = _visible
            btnBorrar.Visible = _visible
            btnAgregarCriterio.Visible = _visible

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
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
            txtCriterio.Text = ""
            chkTodos.Checked = True
            txtCodigo.Focus()
        ElseIf Editar Then
            txtCodigo.Focus()
        End If
    End Sub
    Private Sub MostrarInformacion()
        Dim i As Integer
        Dim f As Boolean
        Dim dtCuestionarios As New DataTable
        Dim Cuestionarios As String = ""
        Dim arCuestionarios() As String
        Dim itCuestionario As System.Windows.Forms.ListViewItem

        Try
            If dtRegistro.Rows.Count > 0 Then
                txtCodigo.Text = dtRegistro.Rows(0).Item("cod_evaluacion")
                txtNombre.Text = dtRegistro.Rows(0).Item("nombre").ToString.Trim
                f = IIf(IsDBNull(dtRegistro.Rows(0).Item("filtro")), "", dtRegistro.Rows(0).Item("filtro")) <> ""
                txtCriterio.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("filtro")), "", dtRegistro.Rows(0).Item("filtro"))

                chkTodos.Checked = Not f
                chkFiltros.Checked = f
                Cuestionarios = IIf(IsDBNull(dtRegistro.Rows(0).Item("cuestionarios")), "", dtRegistro.Rows(0).Item("cuestionarios"))

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

    Private Sub btnCiasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("capacitacion.dbo.evaluaciones", "cod_evaluacion", "estado evaluaciones", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM evaluaciones WHERE cod_evaluacion = '" & Cod & "' ", "CAPACITACION")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("evaluaciones", "cod_evaluacion", dtRegistro, "CAPACITACION")
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("evaluaciones", "cod_evaluacion", txtCodigo.Text, dtRegistro, "CAPACITACION")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("evaluaciones", "cod_evaluacion", txtCodigo.Text, dtRegistro, "CAPACITACION")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        dtTemporal = sqlExecute("SELECT cod_pregunta FROM preguntas WHERE cod_evaluacion = '" & txtCodigo.Text & "'", "CAPACITACION")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que ya se encuentre asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & evaluacion & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM evaluaciones WHERE cod_evaluacion = '" & evaluacion & "'", "CAPACITACION")
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
        dtRegistro = sqlExecute("SELECT * FROM evaluaciones WHERE cod_evaluacion = '" & cod & "' AND nombre = '" & nom & "'", "CAPACITACION")
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
        Ultimo("evaluaciones", "cod_evaluacion", dtRegistro, "CAPACITACION")
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim CambioEfectuado As Boolean
        Dim Criterio As String = ""
        CambioEfectuado = True
        Dim Cuestionarios As String = ""
        Try
            If Agregar Or Editar Then
                Criterio = txtCriterio.Text.Replace("'", "''").Trim
                For Each itCuestionario As Windows.Forms.ListViewItem In lstCuestionario.CheckedItems
                    Cuestionarios = Cuestionarios & itCuestionario.Text & ","
                Next
                Cuestionarios = (Cuestionarios.Trim & "@").Replace(",@", "")
            End If

            If Agregar Then
                ' Si Agregar, revisar si existe evaluacion
                dtTemporal = sqlExecute("SELECT cod_evaluacion FROM evaluaciones where cod_evaluacion = '" & txtCodigo.Text & "'", "CAPACITACION")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                Else
                    dtTemporal = sqlExecute("INSERT INTO evaluaciones (cod_evaluacion,nombre,filtro,cuestionarios) VALUES ('" & _
                                            txtCodigo.Text & "','" & txtNombre.Text & "','" & Criterio & "','" & Cuestionarios & "')", "CAPACITACION")
                    CambioEfectuado = Not (dtTemporal Is New DataTable)
                    Agregar = False
                    evaluacion = txtCodigo.Text
                End If

            ElseIf Editar Then
                ' Si Editar, entonces guardar cambios a registro
                sqlExecute("UPDATE evaluaciones SET nombre = '" & txtNombre.Text & _
                           "', cod_evaluacion = '" & txtCodigo.Text & _
                           "', filtro = '" & Criterio & _
                           "', cuestionarios = '" & Cuestionarios & _
                           "' WHERE cod_evaluacion = '" & evaluacion & "'", "CAPACITACION")
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

            dtRegistro = sqlExecute("SELECT * FROM evaluaciones WHERE cod_evaluacion = '" & evaluacion & "' ORDER BY cod_evaluacion ASC ", "CAPACITACION")
            MostrarInformacion()
            HabilitarBotones()
        Catch
            If Not Agregar Then
                MessageBox.Show("Se detectó un error y el cambio no pudo ser guardado. Favor de verificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try


    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        Dim Resultado As New DataTable
        Dim R As String
        Dim c As Integer = 0
        Resultado = FiltrarDatos(txtFiltro.Text.Trim, False)

        lstFiltro.Items.Clear()
        For x = 0 To Resultado.Rows.Count - 1
            R = Resultado.Rows.Item(x).Item(0)
            If lstFiltro.FindString(R) < 0 Then
                lstFiltro.Items.Add(Resultado.Rows.Item(x).Item(0))
                lstFiltro.SetItemChecked(c, True)
                c = c + 1
            End If
        Next
    End Sub

    Private Function FiltrarDatos(Texto As String, Excepcion As Boolean) As DataTable
        Dim x As Integer
        Dim Campo As String
        Dim Valores() As String
        Valores = Split(Texto, ",")
        Dim FiltraValor As String = ""

        If cbCampos.SelectedIndex >= 0 Then
            Campo = cbCampos.SelectedValue.ToString.Trim
        Else
            Campo = ""
        End If

        If UBound(Valores) = 0 And Valores(0) = "" Then
            FiltraValor = Campo & " <> '' AND NOT " & Campo & " IS NULL"
        Else
            For x = 0 To UBound(Valores)
                If Valores(x).Length = 0 Then
                    'Si el valor está en blanco, utilizar una cadena siempre verdadera para no obstruir la consulta
                    Valores(x) = "1=1"
                ElseIf Not Valores(x).Contains("*") Then
                    'Si no se incluye el asterisco, agregarlo al final
                    Valores(x) = Valores(x) & "*"
                End If
                'Formar la cadena con los valores a filtrar
                FiltraValor = FiltraValor & Campo & " LIKE ('" & Valores(x).Replace("*", "%") & "')"

                If x < UBound(Valores) Then
                    'Si no es el último elemento del arreglo, agregar el OR
                    FiltraValor = FiltraValor & " OR "
                End If
            Next
        End If
        'End If

        If Excepcion Then
            FiltraValor = "NOT (" & FiltraValor & ")"
        End If

        dtValores = sqlExecute("SELECT DISTINCT " & Campo & " from personalvw WHERE " & FiltraValor)

        Return dtValores
    End Function

    Private Sub cbCampos_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cbCampos.SelectionChanged
        Dim x As Integer
        Dim Campo As String


        If cbCampos.SelectedIndex >= 0 Then
            Campo = cbCampos.SelectedValue.ToString.Trim
        Else : lstFiltro.Items.Clear()
            Exit Sub
        End If

        'pnlCaracter.Visible = cbCampos.SelectedNode.NodesColumns.Item("tipo")

        'Si el campo es de tipo caracter
        dtValores = sqlExecute("SELECT DISTINCT " & Campo & " from personalvw WHERE " & Campo & " <> ''  AND NOT " & Campo & " IS NULL")
        lstFiltro.Items.Clear()
        lstFiltro.Items.Add(" ")
        For x = 0 To dtValores.Rows.Count - 1
            lstFiltro.Items.Add(dtValores.Rows.Item(x).Item(0))
        Next

    End Sub

    Private Sub cbCampos_TextChanged(sender As Object, e As EventArgs) Handles cbCampos.TextChanged

    End Sub

    Private Sub btnCriterio_Click(sender As Object, e As EventArgs) Handles btnCriterio.Click
        gpFiltro.Visible = True
        pnlCriterio.Visible = False
    End Sub

    Private Sub chkFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltros.CheckedChanged
        pnlCriterio.Enabled = chkFiltros.Checked
        If chkFiltros.Checked Then
            txtCriterio.Focus()
        End If
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        pnlCriterio.Enabled = chkFiltros.Checked
    End Sub

    Private Sub btnAgregarCriterio_Click(sender As Object, e As EventArgs) Handles btnAgregarCriterio.Click
        Dim Campo As String = cbCampos.SelectedValue.ToString.Trim
        Dim FiltraValor As String

        Campo = "personalvw." & Campo
        FiltraValor = ""


        For x = 0 To lstFiltro.CheckedItems.Count - 1
            FiltraValor = FiltraValor & IIf(FiltraValor.Length > 0, ",", "") & "'" & lstFiltro.CheckedItems(x) & "'"
        Next
        FiltraValor = Campo & IIf(cbComparacion.Text = "<>", " NOT ", "") & " IN (" & FiltraValor & ")"

        txtCriterio.Text = txtCriterio.Text.Trim & IIf(txtCriterio.TextLength > 0, " AND ", "") & FiltraValor

        pnlCriterio.Visible = True
        gpFiltro.Visible = False

    End Sub

    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        Dim dtResultado As New DataTable
        Dim Valido As Boolean

        dtResultado = sqlExecute("SELECT reloj from personalvw" & IIf(txtCriterio.Text.Length > 0, " WHERE ", "") & txtCriterio.Text)
        Valido = Not (dtResultado Is Nothing)
        If Valido Then
            MessageBox.Show("El criterio es válido. Se  " & IIf(dtResultado.Rows.Count = 1, " se obtuvo 1 registro que cumple", "obtuvieron " & dtResultado.Rows.Count & " registros que cumplen") & " con esta condición.", "Criterio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("El criterio no es válido. Favor de verificar.", "Criterio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

        frmVistaPrevia.LlamarReporte("Evaluaciones", Nothing)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub lstFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFiltro.SelectedIndexChanged

    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged

    End Sub

    Private Sub txtCodigo_Validated(sender As Object, e As EventArgs) Handles txtCodigo.Validated
        If Editar Or Agregar Then
            txtCodigo.Text = txtCodigo.Text.Trim.PadLeft(txtCodigo.MaxLength, "0")
        End If
    End Sub

    Private Sub ReflectionLabel1_Click(sender As Object, e As EventArgs) Handles ReflectionLabel1.Click

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
        'itCuestionario = lstCuestionario.FindItemWithText(txtBuscaCuestionario.Text, True, 0, False)

        'If Not itCuestionario Is Nothing Then
        '    lstCuestionario.TopItem = itCuestionario
        '    itCuestionario.Selected = True
        '    ' txtBuscaCuestionario.Focus()
        'End If
    End Sub
End Class