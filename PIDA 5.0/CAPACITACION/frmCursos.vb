Public Class frmCursos
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtClasificacion As New DataTable ' Tabla de Clasificaciones

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
    Public obligatorioCurso As Boolean '-----Antonio
    Dim cursoH As Boolean   '== Ernesto     mayo 2021

    '==Info del combo de orden      sep2021
    Dim dtDataGrid As New DataTable
    Dim orden_nivel As String = ""

#End Region

    Private Sub frmCursos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_curso as 'Código',Nombre,orden_matriz AS 'Orden en matriz',Activo FROM Cursos", "Capacitacion")
            'dtLista = sqlExecute("SELECT cod_curso as 'Código',Nombre,orden_matriz AS 'Orden en matriz' FROM Cursos", "Capacitacion")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            ' dtRegistro = sqlExecute("SELECT TOP 1 * FROM Cursos ORDER BY activo DESC", "Capacitacion")
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM Cursos ORDER BY cod_curso ASC", "Capacitacion")

            cmbClasificacion.DataSource = sqlExecute("SELECT cod_clasif, nombre FROM clasificacion", "Capacitacion")
            cmbAreaTematica.DataSource = sqlExecute("SELECT * FROM areas_tematicas ORDER BY cod_area", "Capacitacion")
            cmbModalidad.DataSource = sqlExecute("SELECT * FROM modalidades ORDER BY modalidad", "Capacitacion")
            cmbObjetivo.DataSource = sqlExecute("SELECT * FROM objetivos ORDER BY objetivo", "Capacitacion")
            '  cmbTipo.DataSource = sqlExecute("SELECT * FROM tipo_curso ORDER BY cod_tipo_curso", "Capacitacion")
            'cmbClase.DataSource = sqlExecute("SELECT * FROM Clase_curso ORDER BY cod_clase_curso", "Capacitacion")

            '== Departamento        mayo 2021   ernesto
            ' cmbDepto.DataSource = sqlExecute("select RTRIM(COD_DEPTO) as cod_depto,RTRIM(NOMBRE) as nombre from PERSONAL.dbo.deptos where LEN(COD_DEPTO)>1")

            dtDataGrid.Columns.Add("categoria")
            dtDataGrid.Columns.Add("orden")
            dtDataGrid.Columns.Add("nivel")

            MostrarInformacion()

            '---- AO: Revisar perfiles para ver si tiene acceso a los botones
            Dim _visible As Boolean = True
            _visible = revisarPerfiles(Perfil, Me, _visible, "WME", "")
            btnNuevo.Visible = _visible
            btnEditar.Visible = _visible
            btnBorrar.Visible = _visible

            ''==Ordenes y niveles        sep2021     ernesto
            'CargarOrdenNiveles()
        Catch ex As Exception
            MessageBox.Show("Se ha detectado un error en la tabla de cursos", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    '==Carga el orden y los niveles disponibles         9sep2021
    Private Sub CargarOrdenNiveles()
        Try
            dtDataGrid.Rows.Clear()
            Dim orden As Integer = 0 : Dim nivel As Integer = 0
            Dim listaOrdenNivel As New ArrayList

            Dim consulta As String = "select * from capacitacion.dbo.cursos"
            Dim dtCursos As DataTable = sqlExecute(consulta)

            consulta = "select * from capacitacion.dbo.Categorias_cursos order by orden asc"
            Dim dtCategorias As DataTable = sqlExecute(consulta)

            '==Muestra la categoria actual del curso
            Dim c As String = "cod_curso ='" & txtCodigo.Text.ToString.Trim & "'"
            For Each x As DataRow In dtCursos.Select(c)
                Dim _orden() As String = Split(x.Item("orden_nivel").ToString.Trim, "-")
                c = "orden='" & _orden(0) & "'"

                '==Si no tiene asignado ningun orden y nivel
                If _orden(0) = "" Then
                    lblOrdenActual.Text = "Categoria actual:   -Sin registro-   Orden:   -Sin registro-"
                    Exit For
                End If

                For Each y As DataRow In dtCategorias.Select(c)
                    lblOrdenActual.Text = "Categoria actual:   " & y.Item("Categoria").ToString.Trim & "   Orden:   " & x.Item("orden_nivel").ToString.Trim
                Next
            Next

            '==Analiza los cursos en busqueda de los ordenes y niveles que tienen asignados, y los almacena en una lista
            If dtCursos.Rows.Count > 0 Then
                For Each i As DataRow In dtCursos.Rows
                    If Not IsDBNull(i.Item("orden_nivel")) Then
                        listaOrdenNivel.Add(i.Item("orden_nivel").ToString.Trim)
                    End If
                Next
            End If

            '==Asigna los ordenes y niveles que quedan en base a una comparacion con la lista anterior
            If dtCategorias.Rows.Count > 0 Then
                For Each x As DataRow In dtCategorias.Rows
                    orden = x.Item("orden").ToString.Trim
                    nivel = CInt(x.Item("niveles").ToString)
                    For i As Integer = 1 To nivel
                        If listaOrdenNivel.Contains(orden & "-0" & i.ToString) Then
                            Continue For
                        End If
                        Dim row As DataRow = dtDataGrid.NewRow
                        row("categoria") = x.Item("categoria").ToString.Trim
                        row("orden") = orden
                        row("nivel") = i.ToString
                        dtDataGrid.Rows.Add(row)
                    Next
                Next
            Else
                Exit Sub
            End If

            cmbOrdenNivel.DataSource = dtDataGrid

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

        ' txtCodigo.Enabled = Agregar
        txtCodigo.Enabled = False

        If Agregar Then
            '------here 2024-05-21
            txtCodigo.Text = GenConsec("COD_CURSO", "cursos", "CAPACITACION", "00000")
            txtNombre.Text = ""
            txtCosto.Value = 0
            txtDuracion.Value = 0
            btnStps.Value = True
            btnActivar.Value = True    'AMG
            txtComentarios.Text = ""
            txtOrdenMatriz.Value = 0

            cmbAreaTematica.SelectedValue = ""
            cmbClase.SelectedValue = ""
            cmbClasificacion.SelectedValue = ""
            cmbModalidad.SelectedValue = ""
            cmbObjetivo.SelectedValue = ""
            cmbTipo.SelectedValue = ""

            sbRequiereCalificacion.Value = False

            txtCodigo.Focus()

        ElseIf Editar Then
            txtNombre.Focus()
        End If

    End Sub

    Private Sub MostrarInformacion()
        Dim i As Integer

        Try
            txtCodigo.Text = dtRegistro.Rows(0).Item("cod_curso")
            txtNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre")), "", dtRegistro.Rows(0).Item("nombre")).ToString.Trim
            cmbClasificacion.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_clasif")), "", dtRegistro.Rows(0).Item("cod_clasif"))
            txtCosto.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("costo")), 0, dtRegistro.Rows(0).Item("costo")).ToString.Trim
            txtDuracion.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("duracion")), 0, dtRegistro.Rows(0).Item("duracion")).ToString.Trim
            txtCalificacion.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("calificacion_minima")), 0, dtRegistro.Rows(0).Item("calificacion_minima")).ToString.Trim
            btnStps.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("stps")), False, dtRegistro.Rows(0).Item("stps"))
            btnActivar.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("activo")), False, dtRegistro.Rows(0).Item("activo"))
            txtComentarios.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("comentario")), "", dtRegistro.Rows(0).Item("comentario")).ToString.Trim
            cmbAreaTematica.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_area")), "", dtRegistro.Rows(0).Item("cod_area")).ToString.Trim
            cmbModalidad.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("modalidad")), "", dtRegistro.Rows(0).Item("modalidad")).ToString.Trim
            cmbObjetivo.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("objetivo")), "", dtRegistro.Rows(0).Item("objetivo")).ToString.Trim
            '  cmbClase.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_clase_curso")), "", dtRegistro.Rows(0).Item("cod_clase_curso")).ToString.Trim
            ' cmbTipo.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_tipo_curso")), "", dtRegistro.Rows(0).Item("cod_tipo_curso")).ToString.Trim
            txtOrdenMatriz.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("ORDEN_MATRIZ")), "", dtRegistro.Rows(0).Item("ORDEN_MATRIZ")).ToString.Trim

            '== Se agrega el campo del departamento seleccionado            mayo 2021       Ernesto
            'cmbDepto.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_depto")), "", dtRegistro.Rows(0).Item("cod_depto")).ToString.Trim

            sbRequiereCalificacion.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("requiere_calificacion")), True, IIf(dtRegistro.Rows(0).Item("requiere_calificacion") = 1, True, False))

            If Not DesdeGrid Then
                i = dtLista.DefaultView.Find(txtCodigo.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If
            DesdeGrid = False
            HabilitarBotones()

            '==Ordenes y niveles        sep2021     ernesto
            ' CargarOrdenNiveles()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("capacitacion.dbo.Cursos", "cod_curso", "Cursos", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from Cursos WHERE cod_curso = '" & Cod & "' ", "Capacitacion")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("Cursos", "cod_curso", dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("Cursos", "cod_curso", txtCodigo.Text, dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String
        codigo = txtCodigo.Text
        dtTemporal = sqlExecute("SELECT reloj FROM cursos_empleado WHERE cod_curso = '" & codigo & "'", "Capacitacion")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM Cursos WHERE cod_curso = '" & codigo & "'", "Capacitacion")
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
        dtRegistro = sqlExecute("SELECT * from Cursos WHERE cod_curso = '" & cod & "' AND nombre = '" & nom & "'", "Capacitacion")
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
        Ultimo("Cursos", "cod_curso", dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    '==Se agrego el orden y nivel al momento de acctualizar o agregar cursos            sep2021     Ernesto
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            If Agregar Then
                ' Si Agregar, revisar si existe cod_curso
                btnObligatorio.Enabled = True          '-----Antonio
                dtTemporal = sqlExecute("SELECT cod_curso FROM Cursos where cod_curso = '" & txtCodigo.Text & "'", "Capacitacion")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe el curso '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                Else 'falta agregar valores de tabla

                    'If cmbClase.SelectedIndex = -1 Then
                    '    MessageBox.Show("Debe seleccionar la clase del curso.", "Clase curso obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '    cmbClase.Focus()
                    '    Exit Sub
                    'End If

                    '== Si se trata de un curso de Certificacion/habilidad, entonces agregar en el query el depto al que pertenece      mayo 2021       ernesto
                    Dim Q As String = ""
                    If cursoH Then
                        Q = "INSERT INTO Cursos (cod_curso,nombre,cod_clasif,costo,duracion,stps,comentario,orden_matriz," & _
                                        "cod_area,modalidad,ACTIVO,objetivo) VALUES ('" & _
                                        txtCodigo.Text & "','" & _
                                        txtNombre.Text & "','" & _
                                        cmbClasificacion.SelectedValue & "'," & _
                                        txtCosto.Value & "," & _
                                        txtDuracion.Value & "," & _
                                        IIf(btnStps.Value, 1, 0) & ",'" & _
                                        txtComentarios.Text & "'," & _
                                        txtOrdenMatriz.Value & ",'" & _
                                        cmbAreaTematica.SelectedValue & "','" & _
                                        cmbModalidad.SelectedValue & "','" & _
                                        IIf(btnActivar.Value, 1, 0) & "','" & _
                                        cmbObjetivo.SelectedValue & "')" 
                        sqlExecute(Q, "Capacitacion")
                    Else
                        Q = "INSERT INTO Cursos (cod_curso,nombre,cod_clasif,costo,duracion,stps,comentario,orden_matriz," & _
                                        "cod_area,modalidad,ACTIVO,objetivo) VALUES ('" & _
                                        txtCodigo.Text & "','" & _
                                        txtNombre.Text & "','" & _
                                        cmbClasificacion.SelectedValue & "'," & _
                                        txtCosto.Value & "," & _
                                        txtDuracion.Value & "," & _
                                        IIf(btnStps.Value, 1, 0) & ",'" & _
                                        txtComentarios.Text & "'," & _
                                        txtOrdenMatriz.Value & ",'" & _
                                        cmbAreaTematica.SelectedValue & "','" & _
                                        cmbModalidad.SelectedValue & "','" & _
                                        IIf(btnActivar.Value, 1, 0) & "','" & _
                                        cmbObjetivo.SelectedValue & "')"
                        sqlExecute(Q, "Capacitacion")
                    End If

                    sqlExecute("update cursos set requiere_calificacion = '" & IIf(sbRequiereCalificacion.Value = True, 1, 0) & "' where cod_curso = '" & txtCodigo.Text & "'", "capacitacion")
                    sqlExecute("update cursos set calificacion_minima = '" & IIf(sbRequiereCalificacion.Value = True, IIf(txtCalificacion.Value = 0, 1, txtCalificacion.Value), 0) & "' where cod_curso = '" & txtCodigo.Text & "'", "capacitacion")

                    'SI ES UN CURSO OBLIGATORIO, MANDA VENTANA DE PLANEACION PARA AGREGAR A TODOS LOS EMPLEADOS     '----Antonio
                    '  MostrarPlaneacion()

                    Agregar = False
                    RefreshLista() ' Refrescar Grilla
                End If

            ElseIf Editar Then

                'If cmbClase.SelectedIndex = -1 Then
                '    MessageBox.Show("Debe seleccionar la clase del curso.", "Clase curso obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    cmbClase.Focus()
                '    Exit Sub
                'End If

                ' Si Editar, entonces guardar cambios a registro
                If MessageBox.Show("¿Está seguro de guardar los cambios?", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    '== Si la edicion se trata de un curso de clasificacion 'H', agregar el depto           mayo 2021       Ernesto
                    If cursoH Then
                        sqlExecute("UPDATE cursos SET " & _
                                       "nombre = '" & txtNombre.Text & "'," & _
                                       "cod_clasif = '" & cmbClasificacion.SelectedValue & "'," & _
                                       "costo = " & txtCosto.Value & "," & _
                                       "duracion = " & txtDuracion.Value & "," & _
                                       "calificacion_minima = " & txtCalificacion.Value & "," & _
                                       "stps = " & IIf(btnStps.Value, 1, 0) & "," & _
                                       "comentario = '" & txtComentarios.Text & "'," & _
                                       "orden_matriz = " & txtOrdenMatriz.Value & "," & _
                                       "cod_area = '" & cmbAreaTematica.SelectedValue & "'," & _
                                       "modalidad = '" & cmbModalidad.SelectedValue & "'," & _
                                       "objetivo = '" & cmbObjetivo.SelectedValue & "'," & _
                                       "activo = " & IIf(btnActivar.Value, 1, 0) & " " & _
                                       "WHERE COD_CURSO = '" & txtCodigo.Text & "'", "Capacitacion")
                    Else
                        sqlExecute("UPDATE cursos SET " & _
                                        "nombre = '" & txtNombre.Text & "'," & _
                                        "cod_clasif = '" & cmbClasificacion.SelectedValue & "'," & _
                                        "costo = " & txtCosto.Value & "," & _
                                        "duracion = " & txtDuracion.Value & "," & _
                                        "calificacion_minima = " & txtCalificacion.Value & "," & _
                                        "stps = " & IIf(btnStps.Value, 1, 0) & "," & _
                                        "comentario = '" & txtComentarios.Text & "'," & _
                                        "orden_matriz = " & txtOrdenMatriz.Value & "," & _
                                        "cod_area = '" & cmbAreaTematica.SelectedValue & "'," & _
                                        "modalidad = '" & cmbModalidad.SelectedValue & "'," & _
                                        "objetivo = '" & cmbObjetivo.SelectedValue & "'," & _
                                        "activo = " & IIf(btnActivar.Value, 1, 0) & " " & _
                                        "WHERE COD_CURSO = '" & txtCodigo.Text & "'", "Capacitacion")
                    End If

                    sqlExecute("update cursos set requiere_calificacion = '" & IIf(sbRequiereCalificacion.Value = True, 1, 0) & "' where cod_curso = '" & txtCodigo.Text & "'", "capacitacion")

                End If
            Else
                Agregar = True
            End If
            Editar = False

            HabilitarBotones()

            '==Actualizar combobox de niveles       sep2021
            ' CargarOrdenNiveles()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se encontraron errores al guardar los cambios. Si el problema persiste, contactar al " & _
                            "administrador del sistema." & vbCrLf & vbCrLf & "Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RefreshLista()
        dtLista = sqlExecute("SELECT cod_curso as 'Código',Nombre,orden_matriz AS 'Orden en matriz',Activo FROM Cursos", "Capacitacion")
        dtLista.DefaultView.Sort = "Código"
        dgTabla.DataSource = dtLista
        dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtCompanias As New DataTable

        dtCompanias = sqlExecute("SELECT cod_comp FROM cias", "Capacitacion")
        frmVistaPrevia.LlamarReporte("Cursos", dtCompanias)
        frmVistaPrevia.ShowDialog()

    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("Cursos", "cod_curso", txtCodigo.Text, dtRegistro, "Capacitacion")
        MostrarInformacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtCodigo_Validated(sender As Object, e As EventArgs) Handles txtCodigo.Validated
        'txtCodigo.Text = txtCodigo.Text.Trim.PadLeft(5, "0")
    End Sub


    Private Sub sbRequiereCalificacion_ValueChanged(sender As Object, e As EventArgs) Handles sbRequiereCalificacion.ValueChanged

        If sbRequiereCalificacion.Value = True Then
            txtCalificacion.Visible = True
            Label8.Visible = True
        Else
            txtCalificacion.Visible = False
            Label8.Visible = False
        End If


        If Agregar Or Editar Then
            If sbRequiereCalificacion.Value = True Then
                txtCalificacion.Value = 100
            Else
                txtCalificacion.Value = 0
            End If
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress

        'If IsNumeric(e.KeyChar) Or e.KeyChar = vbBack Then
        'Else
        '    e.KeyChar = ""
        'End If

    End Sub

    'SI ES UN CURSO OBLIGATORIO, MANDA VENTANA DE PLANEACION PARA AGREGAR A TODOS LOS EMPLEADOS '------Antonio
    Public Sub MostrarPlaneacion()
        Try
            If btnObligatorio.Value Then
                frmPlaneacion.Show()
                frmPlaneacion.Focus()
                frmPlaneacion.StartPosition = FormStartPosition.CenterScreen
                frmPlaneacion.cmbCurso.SelectedValue = txtCodigo.Text
                frmPlaneacion.cmbCurso.Enabled = False
                frmPlaneacion.btnVerificar.PerformClick()
                frmPlaneacion.sprTabPlaneacion.SelectedTabIndex = 0
                obligatorioCurso = True
            End If
        Catch ex As Exception
            MessageBox.Show("Se detectaron errores durante el proceso. Si el problema persiste, favor de contactar al administrador del sistema." & _
                            vbCrLf & vbCrLf & "Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            obligatorioCurso = False
        End Try
    End Sub

    '== Si el valor del combo cambia a uno de clasificación 'H', que aparezca el combo de departamento      mayo 2021       ernesto
    Private Sub cmbClasificacion_SelectedValueChanged(sender As Object, e As EventArgs)
        If cmbClasificacion.SelectedValue <> "H " Then
            cursoH = False
            lblDep.Visible = False
            cmbDepto.Enabled = False
            cmbDepto.Visible = False
        Else
            cursoH = True
            lblDep.Visible = True
            cmbDepto.Enabled = True
            cmbDepto.Visible = True
        End If
    End Sub

    '==Si cambia el combo de orden y nivel que tambien cambie el label de lado              sep2021         Ernesto
    Private Sub cmbOrdenNivel_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbOrdenNivel.SelectedValueChanged
        Try
            Dim indice As Integer = cmbOrdenNivel.SelectedIndex
            OrdenesNiveles(indice)
        Catch ex As Exception

        End Try
    End Sub

    '==Funcion para obtener la info del combobox del orden y niveles        sep2021     Ernesto
    Private Sub OrdenesNiveles(indice As Integer)
        Try
            If dtDataGrid.Rows.Count > 0 Then
                Dim cont As Integer = 0
                For Each x As DataRow In dtDataGrid.Rows
                    If cont = indice Then
                        lblOrden.Text = "Categoria: " & x.Item("categoria").ToString & " Orden: " & x.Item("orden").ToString & "-0" & x.Item("nivel").ToString
                        orden_nivel = x.Item("orden").ToString & "-0" & x.Item("nivel")
                    End If
                    cont += 1
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class