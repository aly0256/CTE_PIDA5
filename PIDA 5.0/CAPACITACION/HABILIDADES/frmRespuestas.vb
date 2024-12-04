Public Class frmRespuestas

    Dim curStepIt As DevComponents.DotNetBar.StepItem

    Dim Agregar As Boolean
    Dim Editar As Boolean
    Dim DesdeGrid As Boolean
    Dim dtRegistro As New DataTable
    Dim dtLista As New DataTable

    Private Sub AgregarNuevaClasificaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarNuevaClasificaciónToolStripMenuItem.Click
        Dim bi As New DevComponents.DotNetBar.StepItem
        Dim txt As String
        Dim i As Integer
        txt = InputBox("Nuevo nivel: ", "Agregar", "")
        If txt.Length > 0 Then
            bi.Text = txt
            bi.TextColor = SystemColors.ControlText
            bi.Padding.All = 10
            i = stpClasificacion.Items.IndexOf(curStepIt)
            If i < 0 Then
                stpClasificacion.Items.Add(bi)
            Else
                stpClasificacion.Items.Add(bi, i + 1)
            End If
            stpClasificacion.Refresh()
        End If

    End Sub

    Private Sub ModificarTextoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarTextoToolStripMenuItem.Click
        If Not curStepIt Is Nothing Then

            Dim txt As String
            txt = InputBox("Cambiar clasificación: ", "Modificar", curStepIt.Text)
            If txt.Length > 0 Then
                curStepIt.Text = txt
                stpClasificacion.Refresh()
            End If
        End If
    End Sub

    Private Sub stpClasificacion_MouseDown(sender As Object, e As MouseEventArgs) Handles stpClasificacion.MouseDown
        If TypeOf sender Is DevComponents.DotNetBar.StepItem Then
            curStepIt = sender

            EliminarClasificaciónToolStripMenuItem.Text = "Eliminar nivel " & sender.text
            ModificarTextoToolStripMenuItem.Text = "Modificar " & sender.text
            EliminarClasificaciónToolStripMenuItem.Enabled = True
            ModificarTextoToolStripMenuItem.Enabled = True
        Else
            curStepIt = Nothing
            EliminarClasificaciónToolStripMenuItem.Text = "Eliminar nivel"
            ModificarTextoToolStripMenuItem.Text = "Modificar"

            EliminarClasificaciónToolStripMenuItem.Enabled = False
            ModificarTextoToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub EliminarClasificaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarClasificaciónToolStripMenuItem.Click
        stpClasificacion.Items.Remove(curStepIt)
        stpClasificacion.Refresh()
    End Sub

    Private Sub frmTipoRespuestas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Constantes, puesto que de su definición depende el tipo de controles a utilizar.
            'Si se requiere otro estilo, se debe agregar programación para manejarlo
            cmbEstilo.Items.Add("LOGICO")
            cmbEstilo.Items.Add("NIVEL")
            cmbEstilo.Items.Add("NUMERICO")
            cmbEstilo.Items.Add("OPCION MULTIPLE")
            cmbEstilo.Items.Add("RANGO")


            dtLista = sqlExecute("SELECT cod_respuesta as 'Código',Nombre,RTRIM(Estilo) AS Estilo FROM tipos_respuestas", "Capacitacion")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(2).Width = 200
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM tipos_respuestas ORDER BY cod_respuesta ASC ", "Capacitacion")

            pnlNumerico.Location = pnlOpcionMultiple.Location
            pnlLogico.Location = pnlOpcionMultiple.Location
            pnlClasificacion.Location = pnlOpcionMultiple.Location
            pnlRango.Location = pnlOpcionMultiple.Location

            MostrarInformacion()

            '---- AO: Revisar perfiles para ver si tiene acceso a los botones
            Dim _visible As Boolean = True
            _visible = revisarPerfiles(Perfil, Me, _visible, "WME", "")
            btnNuevo.Visible = _visible
            btnEditar.Visible = _visible
            btnBorrar.Visible = _visible

        Catch ex As Exception
            MessageBox.Show("Se ha detectado un error en la tabla", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub cmbEstilo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstilo.SelectedIndexChanged
        pnlNumerico.Visible = cmbEstilo.Text = "NUMERICO"
        pnlLogico.Visible = cmbEstilo.Text = "LOGICO"
        pnlClasificacion.Visible = cmbEstilo.Text = "NIVEL"
        pnlRango.Visible = cmbEstilo.Text = "RANGO"
        pnlOpcionMultiple.Visible = cmbEstilo.Text = "OPCION MULTIPLE"
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
            cmbEstilo.Text = "LOGICO"
            txtCodigo.Focus()

        ElseIf Editar Then
            txtNombre.Focus()
        End If

    End Sub

    Private Sub MostrarInformacion()
        Dim i As Integer
        Dim j As Integer
        Dim Estilo As String
        Dim Valores As String
        Dim Op As String
        Dim Val As Integer
        Dim Val2 As Integer
        Dim arValores() As String
        Try
            txtCodigo.Text = dtRegistro.Rows(0).Item("cod_respuesta")
            txtNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre")), "", dtRegistro.Rows(0).Item("nombre")).ToString.Trim
            Estilo = IIf(IsDBNull(dtRegistro.Rows(0).Item("estilo")), "", dtRegistro.Rows(0).Item("estilo")).ToString.Trim
            cmbEstilo.Text = Estilo
            Valores = IIf(IsDBNull(dtRegistro.Rows(0).Item("opciones")), "", dtRegistro.Rows(0).Item("opciones")).ToString.Trim
            arValores = Valores.Split(vbCrLf)

            If Estilo = "LOGICO" Then
                If arValores.Count >= 2 Then
                    txtVerdadero.Text = arValores(0)
                    txtFalso.Text = arValores(1)
                    txtNoRequerido.Text = arValores(2)
                End If
            ElseIf Estilo = "NUMERICO" Then
                If arValores.Count >= 0 Then
                    intMinimo.Value = arValores(0)
                Else
                    intMinimo.Value = 0
                End If

                If arValores.Count >= 1 Then
                    intMaximo.Value = arValores(1)
                Else
                    intMaximo.Value = 0
                End If
            ElseIf Estilo = "NIVEL" Then
                stpClasificacion.Items.Clear()
                Dim bi As New DevComponents.DotNetBar.StepItem

                For Each Opcion In arValores
                    bi = New DevComponents.DotNetBar.StepItem
                    i = Opcion.ToUpper.IndexOf("&V")
                    If i < 0 Then
                        Op = Opcion.Trim
                        Val = 0
                    Else
                        Op = Opcion.Substring(0, i).Trim
                        Val = Opcion.Substring(i + 2)
                    End If

                    bi.Text = Op
                    bi.Padding.All = 10
                    bi.TextColor = SystemColors.ControlText
                    stpClasificacion.Items.Add(bi)
                Next
                stpClasificacion.Refresh()

            ElseIf Estilo = "OPCION MULTIPLE" Then
                dgValidas.Rows.Clear()

                For Each Opcion In arValores
                    i = Opcion.ToUpper.IndexOf("&V")
                    If i < 0 Then
                        Op = Opcion
                        Val = 0
                    Else
                        Op = Opcion.Substring(0, i).Trim
                        Val = Opcion.Substring(i + 2)
                    End If
                    dgValidas.Rows.Add({Op, Val})
                Next
                chkUnaRespuesta.Checked = IIf(IsDBNull(dtRegistro.Rows(0).Item("seleccion_multiple")), 0, dtRegistro.Rows(0).Item("seleccion_multiple")).ToString.Trim
                chkSeleccionMultiple.Checked = IIf(IsDBNull(dtRegistro.Rows(0).Item("seleccion_multiple")), 0, dtRegistro.Rows(0).Item("seleccion_multiple")).ToString.Trim
            ElseIf Estilo = "RANGO" Then
                dgRango.Rows.Clear()

                For Each Opcion In arValores
                    i = Opcion.ToUpper.IndexOf("&V")
                    j = Opcion.IndexOf("-")
                    If i < 0 Then
                        Op = Opcion
                        Val = 0
                        Val2 = 0
                    Else
                        Op = Opcion.Substring(0, i).Trim
                        If j < 0 Then
                            Val = Opcion.Substring(i + 2)
                            Val2 = Val
                        Else
                            Val = Opcion.Substring(i + 2, j - i - 2)
                            Val2 = Opcion.Substring(j + 1)
                        End If
                    End If
                    dgRango.Rows.Add({Op, Val, Val2})
                Next
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
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("capacitacion.dbo.tipos_respuestas", "cod_respuesta", "tipos_respuestas", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from tipos_respuestas WHERE cod_respuesta = '" & Cod & "'", "Capacitacion")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("tipos_respuestas", "cod_respuesta", dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("tipos_respuestas", "cod_respuesta", txtCodigo.Text, dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String
        codigo = txtCodigo.Text
        dtTemporal = sqlExecute("SELECT cod_respuesta FROM preguntas WHERE cod_respuesta = '" & codigo & "'", "Capacitacion")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a alguna pregunta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM tipos_respuestas WHERE cod_respuesta = '" & codigo & "'", "Capacitacion")
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
        dtRegistro = sqlExecute("SELECT * from tipos_respuestas WHERE cod_respuesta = '" & cod & "' AND nombre = '" & nom & "'", "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            'HabilitarBotones()
            txtNombre.Focus()
        Else
            Editar = False
        End If
        Agregar = False
        MostrarInformacion()
        HabilitarBotones()
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Ultimo("tipos_respuestas", "cod_respuesta", dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            Dim Cadena As String
            Dim Estilo As String
            Dim Opciones As String = ""
            Dim Multiple As Integer = 0
            Estilo = cmbEstilo.Text

            If Estilo = "LOGICO" Then
                Opciones = txtVerdadero.Text.Trim & vbCrLf & txtFalso.Text.Trim & vbCrLf & txtNoRequerido.Text.Trim
            ElseIf Estilo = "NUMERICO" Then
                Opciones = intMinimo.Value & vbCrLf & intMaximo.Value
            ElseIf Estilo = "NIVEL" Then
                Dim bi As New DevComponents.DotNetBar.StepItem
                Opciones = ""
                For Each bi In stpClasificacion.Items
                    Opciones = Opciones & IIf(Opciones.Length = 0, "", vbCrLf) & bi.Text
                Next
            ElseIf Estilo = "OPCION MULTIPLE" Then
                Multiple = chkSeleccionMultiple.Checked
                Opciones = ""
                For Each it As DataGridViewRow In dgValidas.Rows
                    If Not IsDBNull(it) Then
                        Opciones = Opciones & IIf(Opciones.Length = 0, "", vbCrLf) & it.Cells(0).Value & "&V" & it.Cells(1).Value
                    End If
                Next
            ElseIf Estilo = "RANGO" Then
                Opciones = ""
                For Each it As DataGridViewRow In dgRango.Rows
                    Opciones = Opciones & IIf(Opciones.Length = 0, "", vbCrLf) & it.Cells(0).Value & "&V" & it.Cells(1).Value & "-" & it.Cells(2).Value
                Next
            End If

            If Agregar Then
                ' Si Agregar, revisar si existe cod_respuesta
                dtTemporal = sqlExecute("SELECT cod_respuesta FROM tipos_respuestas where cod_respuesta = '" & txtCodigo.Text & "'", "Capacitacion")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe el curso '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                Else 'falta agregar valores de tabla
                    sqlExecute("INSERT INTO tipos_respuestas (cod_respuesta,nombre,seleccion_multiple,opciones,estilo) VALUES ('" & txtCodigo.Text & "','" & txtNombre.Text & "','" & Multiple & "','" & Opciones & "','" & Estilo & "')", "CAPACITACION")
                    Agregar = False
                End If

            ElseIf Editar Then
                Editar = False
                ' Si Editar, entonces guardar cambios a registro
                Cadena = "UPDATE tipos_respuestas SET " & _
                            "nombre = '" & txtNombre.Text & "'," & _
                            "estilo = '" & cmbEstilo.Text & "', " & _
                            "opciones = '"

             
                Opciones = Opciones.Replace("'", "''")
                Cadena = Cadena & Opciones & "',seleccion_multiple = " & Multiple & " WHERE cod_respuesta = '" & txtCodigo.Text & "'"
                sqlExecute(Cadena, "Capacitacion")
            Else
                Agregar = True
                Editar = False
            End If


            HabilitarBotones()
        

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se encontraron errores al guardar los cambios. Si el problema persiste, contactar al " & _
                            "administrador del sistema." & vbCrLf & vbCrLf & "Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtCompanias As New DataTable

        dtCompanias = sqlExecute("SELECT cod_comp FROM cias", "Capacitacion")
        frmVistaPrevia.LlamarReporte("tipos_respuestas", dtCompanias)
        frmVistaPrevia.ShowDialog()

    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("tipos_respuestas", "cod_respuesta", txtCodigo.Text, dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtCodigo_Validated(sender As Object, e As EventArgs) Handles txtCodigo.Validated
        txtCodigo.Text = txtCodigo.Text.Trim.PadLeft(txtCodigo.MaxLength, "0")
    End Sub

    Private Sub stpClasificacion_ItemClick(sender As Object, e As EventArgs) Handles stpClasificacion.ItemClick

        'For Each item As DevComponents.DotNetBar.StepItem In stpClasificacion.Items
        '    If item.Id <= sender.id Then
        '        item.Value = 100
        '    Else
        '        item.Value = 0
        '    End If
        'Next
    End Sub

    Private Sub mnuClasificacion_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuClasificacion.Opening

    End Sub

    Private Sub StepItem1_Click(sender As Object, e As EventArgs) Handles StepItem1.Click

    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged

    End Sub
End Class
