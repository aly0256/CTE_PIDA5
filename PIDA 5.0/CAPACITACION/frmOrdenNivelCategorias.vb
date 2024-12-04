Public Class frmOrdenNivelCategorias
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtCias As New DataTable         'Tabla de compañías
    Dim dtSuper As New DataTable        'Tabla de supervisores
    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim query As String = ""

    Dim _vaOrden As String = ""
    Dim _vaNivel As String = ""
    Dim _vaVistaR As String = ""
#End Region

    Private Sub frmInstitutos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'dtLista = sqlExecute("SELECT categoria,orden,niveles FROM Categorias_cursos", "Capacitacion")
            'dtLista.DefaultView.Sort = "orden"
            'dgTabla.DataSource = dtLista
            'dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'dtRegistro = sqlExecute("SELECT TOP 1 * FROM Categorias_cursos ORDER BY orden ASC ", "Capacitacion")
            RefrescarInfo()
            MostrarInformacion()

            '---- AO: Revisar perfiles para ver si tiene acceso a los botones
            Dim _visible As Boolean = True
            _visible = revisarPerfiles(Perfil, Me, _visible, "WME", "")
            btnNuevo.Visible = _visible
            btnEditar.Visible = _visible
            btnBorrar.Visible = _visible

        Catch ex As Exception
            MessageBox.Show("Se ha detectado un error en la tabla de orden de categorias", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub RefrescarInfo()
        Try
            dtLista = sqlExecute("select categoria,orden,niveles from CAPACITACION.dbo.Categorias_cursos order by orden asc", "Capacitacion")
            dtLista.DefaultView.Sort = "orden"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dtRegistro = sqlExecute("SELECT TOP 1 categoria,orden,niveles,rtrim(detalles) as detalles from CAPACITACION.dbo.Categorias_cursos ORDER BY orden ASC ", "Capacitacion")
        Catch ex As Exception

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

        txtCategoria.Enabled = Agregar

        If Agregar Then
            txtOrden.Text = ""
            txtNiveles.Text = ""
            txtCategoria.Focus()
        ElseIf Editar Then
            txtOrden.Focus()
        End If
    End Sub

    Private Sub MostrarInformacion()
        Dim i As Integer
        Try
            query = ""
            If dtRegistro.Rows.Count > 0 Then
                txtCategoria.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("categoria")), "", dtRegistro.Rows(0).Item("categoria")).ToString.Trim
                txtOrden.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("orden")), "", dtRegistro.Rows(0).Item("orden")).ToString.Trim
                txtNiveles.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("niveles")), "",
                                      IIf(dtRegistro.Rows(0).Item("niveles").ToString.Substring(0, 1) = "0",
                                          dtRegistro.Rows(0)("niveles").ToString.Substring(1),
                                          dtRegistro.Rows(0)("niveles"))).ToString.Trim
                swbReporte.Value = IIf(dtRegistro.Rows(0)("detalles").ToString.Contains("[visible_reporte]=1"), True, False)
            Else
                txtCategoria.Text = ""
                txtOrden.Text = ""
                txtNiveles.Text = ""
            End If

            If Not DesdeGrid Then
                i = dtLista.DefaultView.Find(txtOrden.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If

            DesdeGrid = False
            HabilitarBotones()
            dgTabla.Refresh()
        Catch ex As Exception
        End Try
    End Sub

    '==VERIFICAR CURSOS ASIGNADOS CON LAS CATEGORIAS Y NIVELES       2-SEP-2021
    Private Function ValidacionCursos(orden As String) As Boolean
        Try
            Dim consulta As String = "select * from capacitacion.dbo.cursos"
            Dim dtCursos As DataTable = sqlExecute(consulta)

            If dtCursos.Rows.Count > 0 Then
                For Each x As DataRow In dtCursos.Rows
                    Dim orden_nivel() As String = Split(x.Item("orden_nivel").ToString.Trim, "-")
                    If orden_nivel(0) = orden Then
                        Return False
                    End If
                Next
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    '==

    '==Verfica que no se metan las misma categorias u ordenes           6-septiembre-2021
    Private Function ValidacionCategorias(cat As String, orden As String) As Boolean
        Try
            If cat = "0" Or orden = "0" Then
                Return False
            End If
            Dim consulta As String = "select * from capacitacion.dbo.Categorias_cursos where categoria='" & cat & "' or orden='" & orden & "'"
            Dim dttemp As DataTable = sqlExecute(consulta)

            If dttemp.Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    '==Funcion para validar la actualizacion del registro           7-septiembre-2021
    Private Function ValidaActualizacion(orden As String, nivel As String, vistaR As String) As Boolean
        Try

            '==Si se intenta actualizar con los mismos valores
            If (orden = _vaOrden And nivel = _vaNivel And vistaR = _vaVistaR) Then
                Return False
            End If

            '==Si no hay nada en los campos
            If txtOrden.Text.Length < 1 Or txtNiveles.Text.Length < 1 Then
                MessageBox.Show("Por favor, llene los campos correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If

            Dim consulta As String = "select * from capacitacion.dbo.cursos where orden_nivel='" & orden & "'"
            Dim dtTemp As DataTable = sqlExecute(consulta)

            '==Si hay registros en los cursos con la categoria asignados, mandar mensaje al usuario de advertencia
            If dtTemp.Rows.Count > 0 Then
                MessageBox.Show("Existen cursos que actualmente poseen esta categoria." & vbNewLine &
                                "Contacte al administrador del sistema para mas información", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            '==Si hay registros en las categorias que ya tienen ese orden en la base de datos
            consulta = "select * from capacitacion.dbo.Categorias_cursos where orden='" & orden & "' and categoria not in ('" & txtCategoria.Text.Trim & "')"
            dtTemp = sqlExecute(consulta)

            If dtTemp.Rows.Count > 0 Then
                MessageBox.Show("Existen registros en categorias que actualmente poseen este orden." & vbNewLine &
                               "Contacte al administrador del sistema para mas información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Return True
        Catch ex As Exception

        End Try
    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("capacitacion.dbo.Categorias_cursos", "categoria", "Categoria", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from Categorias_cursos WHERE categoria = '" & Cod & "'", "Capacitacion")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("capacitacion.dbo.Categorias_cursos", "orden", dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Ultimo("capacitacion.dbo.Categorias_cursos", "orden", dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("capacitacion.dbo.Categorias_cursos", "orden", txtOrden.Text, dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("capacitacion.dbo.Categorias_cursos", "orden", txtOrden.Text, dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim categoria As String
        categoria = txtCategoria.Text
        If ValidacionCursos(txtOrden.Text) Then
            If MessageBox.Show("¿Está seguro de borrar el registro " & categoria & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM capacitacion.dbo.Categorias_cursos  WHERE categoria = '" & categoria & "'", "Capacitacion")
                btnSiguiente.PerformClick()
                RefrescarInfo()
            End If
        Else
            If MessageBox.Show("La categoria que desea eliminar actualmente se encuentra asignada a cursos.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error) = Windows.Forms.DialogResult.OK Then
                'sqlExecute("DELETE FROM capacitacion.dbo.Categorias_cursos  WHERE categoria = '" & categoria & "'", "Capacitacion")
                'btnSiguiente.PerformClick()
                'RefrescarInfo()
            End If
        End If
    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next
        Dim categoria_nom As String, nom As String
        DesdeGrid = True
        categoria_nom = dgTabla.Item("categoria", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT categoria,orden,niveles from capacitacion.dbo.Categorias_cursos WHERE categoria = '" & categoria_nom.ToString.Trim & "'", "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            '== Almacena los valores de los campos de orden y nivel en variable para no actualizar con los mismo datos          septiembre2021
            _vaOrden = txtOrden.Text
            _vaNivel = txtNiveles.Text
            _vaVistaR = swbReporte.Value

            Editar = True
            HabilitarBotones()
            txtOrden.Focus()
        Else
            Editar = False
        End If
        Agregar = False
        MostrarInformacion()
    End Sub


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        If Agregar Then
            ' Si Agregar, revisar si existe cod_instituto
            dtTemporal = sqlExecute("SELECT categoria FROM Categorias_cursos where categoria = '" & txtCategoria.Text & "'", "Capacitacion")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe la categoria: '" & txtCategoria.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCategoria.Focus()
                Exit Sub
            Else
                Dim id_registro As TimeSpan
                Dim detalles As String = ""
                id_registro = Date.Now.TimeOfDay

                '==Ingresa el registro
                Try
                    If txtCategoria.Text.Length < 2 Or txtOrden.Text.Length < 1 Or txtNiveles.Text.Length < 1 Then
                        MessageBox.Show("Por favor, llene todos los campos antes de aceptar", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                        txtCategoria.Text = ""
                        txtOrden.Text = ""
                        txtNiveles.Text = ""
                    Else
                        If ValidacionCategorias(txtCategoria.Text, txtOrden.Text) Then
                            detalles = "[visible_reporte]=" & IIf(swbReporte.Value = True, swbReporte.ValueTrue, swbReporte.ValueFalse)
                            query = "insert into capacitacion.dbo.categorias_cursos " & _
                                                           "values ('" & id_registro.ToString & "','" & txtCategoria.Text & "','" & txtOrden.Text & "','0" & txtNiveles.Text & "','" & detalles & "')"
                            sqlExecute(query)
                        Else
                            MessageBox.Show("Ingrese un orden o nivel correcto, por favor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If

                    End If

                Catch ex As Exception
                    MessageBox.Show("Ha ocurrido un erro durante el ingreso del registro", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                End Try
                Agregar = False
            End If

        ElseIf Editar Then
            ' ==Si Editar, entonces guardar cambios a registro
            Try
                If ValidaActualizacion(txtOrden.Text, txtNiveles.Text, swbReporte.Value.ToString) Then
                    Dim detalleReporte As String = "[visible_reporte]=" & IIf(swbReporte.Value = True, swbReporte.ValueTrue, swbReporte.ValueFalse)

                    sqlExecute("update capacitacion.dbo.Categorias_cursos set orden='" & txtOrden.Text & "',niveles='0" &
                                           txtNiveles.Text & "',detalles='" & detalleReporte & "' where categoria='" & txtCategoria.Text & "'")
                    MessageBox.Show("Se ha actualizado con éxito el registro", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("Ha ocurrido un error durante la actualización del registro", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Agregar = True
        End If

        Editar = False
        HabilitarBotones()
        RefrescarInfo()
    End Sub

    'Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
    '    frmVistaPrevia.LlamarReporte("Institutos", New DataTable)
    '    frmVistaPrevia.ShowDialog()
    'End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtOrden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrden.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNiveles_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNiveles.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class