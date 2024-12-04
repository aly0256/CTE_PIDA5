Public Class frmEmpleadosCurso
    Dim dtCursos As New DataTable
    Dim dtTemp As New DataTable
    Dim _archivoFoto As String = ""
    Dim dtComp As New DataTable
    Dim dtPlan As New DataTable
    Dim _btnDisponible As Boolean = False
    Dim _CursoCodigo As String = ""
    Dim _ConsultaOriginal As String = ""
    Dim _tipoCurso As Boolean
    Dim dtDocsCursosEmpl As New DataTable ' Aos: Cargar los docs en pdf de los empleados

    '== Para eliminar
    Dim _fechaIni As String = ""
    Dim _fechaFin As String = ""
    Dim _fechaCap As String = ""
    Dim _fechaMax As String = ""


    Private Sub frmEmpleadosCurso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _tipoCurso = True
        Try : NavegacionInfo("ORDER BY CR.COD_CURSO ASC") : Catch ex As Exception : End Try

        '---- AO: Revisar perfil para ver si tiene acceso a los botones
        Dim _visible As Boolean = True
        _visible = revisarPerfiles(Perfil, Me, _visible, "WME", txtReloj.Text.ToString.Trim)
        btnGuardaDocs.Visible = _visible
        btnNuevo.Visible = _visible
        btnEditar.Visible = _visible
        btnBorrar.Visible = _visible

    End Sub

    '== Navegación en información
    Private Function NavegacionInfo(condicion As String) As DataTable
        Try
            _ConsultaOriginal = "SELECT TOP 1 RTRIM(CR.COD_CURSO) AS COD_CURSO,RTRIM(CR.NOMBRE) AS NOMBRE_CURSO,RTRIM(CR.DURACION) AS DURACION," & _
                                             "RTRIM(CR.COD_AREA+' - '+AT.NOMBRE) AS AREA_TEMATICA,RTRIM(RTRIM(CL.COD_CLASIF)+' - '+CL.NOMBRE) AS CLASIFICACION," & _
                                             "(CASE WHEN CR.REQUIERE_CALIFICACION=1 THEN CONVERT(VARCHAR,CR.CALIFICACION_MINIMA) ELSE 'No requiere calificación' END) AS CALIFICACION," & _
                                             "RTRIM(RTRIM(CR.MODALIDAD)+' - '+MD.NOMBRE) AS MODALIDAD," & _
                                             "RTRIM(RTRIM(CR.OBJETIVO)+' - '+OB.NOMBRE) AS OBJETIVO," & _
                                             "RTRIM(CAT.CATEGORIA) AS CATEGORIA, CR.ACTIVO,CR.COMENTARIO " & _
                                             "FROM CAPACITACION.DBO.cursos CR LEFT JOIN CAPACITACION.DBO.clasificacion CL " & _
                                             "ON CL.COD_CLASIF=CR.COD_CLASIF LEFT JOIN CAPACITACION.DBO.areas_tematicas AT " & _
                                             "ON AT.COD_AREA=CR.COD_AREA LEFT JOIN CAPACITACION.DBO.modalidades MD " & _
                                             "ON MD.MODALIDAD=CR.MODALIDAD LEFT JOIN CAPACITACION.DBO.objetivos OB " & _
                                             "ON OB.OBJETIVO=CR.OBJETIVO LEFT JOIN CAPACITACION.DBO.Categorias_cursos CAT " & _
                                             "ON RTRIM(CR.ORDEN_NIVEL) LIKE RTRIM(CONVERT(varchar,CAT.ORDEN))+'%' " & _
                                             "$Condicion_query$"

            _ConsultaOriginal = Replace(_ConsultaOriginal, "$Condicion_query$", condicion)
            dtCursos = sqlExecute(_ConsultaOriginal)

            If dtCursos.Rows.Count > 0 Then
                _CursoCodigo = dtCursos.Rows(0)("cod_curso")
                MostrarInformacion()

                '---AOS Mostrar docs 2022-09-09
                dtDocsCursosEmpl = sqlExecute("select * from docs_cursos_empleado", "CAPACITACION")
                MostrarDocsPdf()
            End If

        Catch ex As Exception

        End Try
    End Function

    '== Carga toda la info
    Private Sub MostrarInformacion()
        Try
            '== Muestra la info en controles
            ValoresOriginales()
            lblCodCurso.Text = _CursoCodigo

            For Each i As DataColumn In dtCursos.Columns
                For Each j As Control In pnlCursoInfo.Controls
                    Dim txtControl As DevComponents.DotNetBar.Controls.TextBoxX = TryCast(j, DevComponents.DotNetBar.Controls.TextBoxX)
                    If TypeOf txtControl Is DevComponents.DotNetBar.Controls.TextBoxX Then
                        Dim nomCol As String = "txt" & LCase(i.ColumnName).ToString
                        If txtControl.Name.Contains(nomCol) Then
                            txtControl.Text = IIf(IsDBNull(dtCursos.Rows(0)(i.ColumnName)), "- Sin registro -", dtCursos.Rows(0)(i.ColumnName))
                        End If
                    End If
                Next
            Next

            '== Cuenta de empleados
            CuentaEmpleados(0)

            '== Muestra a los empleados de ese curso
            btnBorrar.Enabled = IIf(InformacionGrids(0).Rows.Count > 0, True, False)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Ocurrió un error, por lo que la información no pudo actualizarse correctamente. " & _
                            "Si el error persiste, contacte al administrador del sistema." & vbCrLf & vbCrLf & "Error: " & _
                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' AOS
    Private Sub MostrarDocsPdf()
        Try
            ' dtDocsCursosEmpl trae la info en base a lblCodCurso.txt
            Dim pathpdf1 As String = "", pathpdf2 As String = "", pathpdf3 As String = ""
            Dim item = (From x In dtDocsCursosEmpl.Rows Where x("COD_CURSO").ToString.Trim = _CursoCodigo).ToList()

            If (item.Count > 0) Then
                Try : pathpdf1 = (item.First()("PATH_PDF1")) : Catch ex As Exception : pathpdf1 = "" : End Try
                Try : pathpdf2 = (item.First()("PATH_PDF2")) : Catch ex As Exception : pathpdf2 = "" : End Try
                Try : pathpdf3 = (item.First()("PATH_PDF3")) : Catch ex As Exception : pathpdf3 = "" : End Try

                txtPathPdf.Text = pathpdf1
                txtPathPdf2.Text = pathpdf2
                txtPathPdf3.Text = pathpdf3
            Else
                txtPathPdf.Text = ""
                txtPathPdf2.Text = ""
                txtPathPdf3.Text = ""
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    '== Información para datagrid
    Private Function InformacionGrids(op As Integer, Optional cuenta As Boolean = False) As DataTable
        Try
            Dim consulta As String = ""
            Dim dtInfo As New DataTable

            dgCapacitacion.DataSource = IIf(cuenta = False, Nothing, dgCapacitacion.DataSource)

            Select Case op
                Case 0
                    '== Los empleados de ese curso
                    consulta = "SELECT RTRIM(CE.RELOJ) AS RELOJ,RTRIM(P.NOMBRES) AS NOMBRE_EMPLEADO,CE.INICIO,CE.FIN," & _
                                        "UPPER(RTRIM(I.NOMBRE)) AS INSTRUCTOR," & _
                                        "CE.CALIFICACION,CE.APROBADO," & _
                                        "(RTRIM(CE.COD_DEPTO)+' - '+RTRIM(P.nombre_depto)) AS DEPARTAMENTO," & _
                                        "(RTRIM(CE.COD_PUESTO)+' - '+RTRIM(P.nombre_puesto)) AS PUESTO," & _
                                        "(RTRIM(CE.COD_TIPO)+' - '+RTRIM(P.nombre_tipoEmp)) AS TIPO_EMP," & _
                                        "CE.ALTA,CE.BAJA,RTRIM(CE.SEXO) AS SEXO " & _
                                        "FROM CAPACITACION.DBO.cursos C INNER JOIN CAPACITACION.DBO.cursos_empleado CE " & _
                                        "ON C.COD_CURSO=CE.COD_CURSO INNER JOIN PERSONAL.DBO.personalvw P " & _
                                        "ON P.RELOJ=CE.RELOJ INNER JOIN CAPACITACION.DBO.instructores I " & _
                                        "ON I.COD_INSTRUCTOR=CE.COD_INSTRUCTOR " & _
                                        "WHERE CE.COD_CURSO='" & _CursoCodigo & "' " & _
                                        "ORDER BY CE.RELOJ ASC"
                Case 1
                    '== Los empleados con cursos planeados
                    consulta = "SELECT RTRIM(PL.RELOJ) AS RELOJ,RTRIM(P.NOMBRES) AS NOMBRE_EMPLEADO,('AÑO:'+RTRIM(PL.ano)+' - MES:'+RTRIM(PL.mes)) as FECHA_PLANEACION," & _
                                        "PL.fecha_captura as FECHA_CAPTURA,PL.fecha_maxima AS FECHA_LIMITE, PL.obligatorio AS ES_OBLIGATORIO," & _
                                        "(RTRIM(P.COD_DEPTO)+' - '+RTRIM(P.nombre_depto)) AS DEPARTAMENTO," & _
                                        "(RTRIM(P.COD_PUESTO)+' - '+RTRIM(P.nombre_puesto)) AS PUESTO," & _
                                        "(RTRIM(P.COD_TIPO)+' - '+RTRIM(P.nombre_tipoEmp)) AS TIPO_EMP," & _
                                        "P.ALTA,P.BAJA,RTRIM(P.SEXO) AS SEXO " & _
                                        "FROM CAPACITACION.DBO.cursos C INNER JOIN CAPACITACION.DBO.planeacion_empleados PL " & _
                                        "ON C.COD_CURSO=PL.COD_CURSO INNER JOIN PERSONAL.DBO.personalvw P " & _
                                        "ON P.RELOJ=PL.RELOJ " & _
                                        "WHERE PL.COD_CURSO='" & _CursoCodigo & "' " & _
                                        "ORDER BY PL.RELOJ ASC"
            End Select

            dtInfo = sqlExecute(consulta)

            If cuenta = False Then
                dgCapacitacion.DataSource = dtInfo
            End If

            Return dtInfo

        Catch ex As Exception
        End Try
    End Function

    '== Categorias: Planeados o completos
    Private Sub SeleccionarCategoria(sender As Object, e As EventArgs) Handles lblComp.Click, lblCompletados.Click, lblPlnds.Click, lblPlaneados.Click
        Try
            Dim cont As Integer = 0

            If sender.name = "lblComp" Or sender.name = "lblCompletados" Then
                pnlCompletados.Style.BackColor1.Color = Color.Gainsboro
                pnlCompletados.Style.BackColor2.Color = Color.Gainsboro
                pnlPlaneados.Style.BackColor1.Color = Color.Silver
                pnlPlaneados.Style.BackColor2.Color = Color.Silver
                cont = InformacionGrids(0).Rows.Count
                _tipoCurso = True
            Else
                pnlCompletados.Style.BackColor1.Color = Color.Silver
                pnlCompletados.Style.BackColor2.Color = Color.Silver
                pnlPlaneados.Style.BackColor1.Color = Color.Gainsboro
                pnlPlaneados.Style.BackColor2.Color = Color.Gainsboro
                cont = InformacionGrids(1).Rows.Count
                _tipoCurso = False
            End If

            btnBorrar.Enabled = IIf(cont > 0, True, False)
            CuentaEmpleados(0)
        Catch ex As Exception

        End Try
    End Sub

    '== Cuenta de empleados
    Private Sub CuentaEmpleados(Optional op As Integer = 0)
        Try
            '== Cuenta por empleado
            Select Case op
                Case 0
                    dtComp = InformacionGrids(0, True)
                    dtPlan = InformacionGrids(1, True)

                    lblTotalEmp.Text = dtComp.Rows.Count + dtPlan.Rows.Count
                    lblCompletados.Text = dtComp.Rows.Count
                    lblPlaneados.Text = dtPlan.Rows.Count
                Case 1
                    Dim dtCuenta As DataTable = Nothing
                    Dim _consulta As String = ""

                    _consulta = "SELECT COUNT(RELOJ) AS CUENTA FROM CAPACITACION.DBO.cursos_empleado WHERE RELOJ='" & txtReloj.Text & "'"
                    dtCuenta = sqlExecute(_consulta)
                    txtCursosCompletados.Text = IIf(dtCuenta.Rows.Count > 0, dtCuenta.Rows(0)("cuenta"), "-- Sin registros --")
                    btnCursosEmpleado.Enabled = IIf(dtCuenta.Rows.Count > 0, True, False)

                    _consulta = "SELECT COUNT(RELOJ) AS CUENTA FROM CAPACITACION.DBO.planeacion_empleados WHERE RELOJ='" & txtReloj.Text & "'"
                    dtCuenta = sqlExecute(_consulta)
                    txtCursosPlaneados.Text = IIf(dtCuenta.Rows.Count > 0, dtCuenta.Rows(0)("cuenta"), "-- Sin registros --")
                    btnCursosEmpleado.Enabled = btnCursosEmpleado.Enabled Or IIf(dtCuenta.Rows.Count > 0, True, False)
            End Select
        Catch ex As Exception
        End Try
    End Sub

    '== Información de empleado
    Private Sub dgCapacitacion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCapacitacion.CellClick
        Try
            If dgCapacitacion.RowCount > 0 Then
                txtReloj.Text = dgCapacitacion.Item("reloj", e.RowIndex).Value
                txtNombreEmpleado.Text = dgCapacitacion.Item("nombre_empleado", e.RowIndex).Value
                dtTemp = ConsultaPersonalVW("select top 1 * from personalvw where reloj='" & txtReloj.Text & "'")

                If _tipoCurso Then
                    _fechaIni = FechaSQL(dgCapacitacion.Item("inicio", e.RowIndex).Value)
                    _fechaFin = FechaSQL(dgCapacitacion.Item("fin", e.RowIndex).Value)
                Else
                    _fechaCap = FechaSQL(dgCapacitacion.Item("fecha_captura", e.RowIndex).Value)
                    _fechaMax = FechaSQL(dgCapacitacion.Item("fecha_limite", e.RowIndex).Value)
                End If

                If dtTemp.Rows.Count > 0 Then
                    Try
                        _archivoFoto = dtTemp.Rows(0)("foto").ToString.Trim
                        picFoto.Width = picFoto.MinimumSize.Width
                        picFoto.Height = picFoto.MinimumSize.Height
                        picFoto.ImageLocation = _archivoFoto
                    Catch
                        picFoto.Image = picFoto.ErrorImage
                    End Try

                    '== Estado del empleado
                    lblEdoEmpleado.Text = IIf(IsDBNull(dtTemp.Rows(0)("baja")), "ACTIVO", "INACTIVO")
                    lblEdoEmpleado.BackColor = IIf(IsDBNull(dtTemp.Rows(0)("baja")), Color.LimeGreen, Color.IndianRed)

                    '== Numero cursos por empleado
                    CuentaEmpleados(1)

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    '== Valores originales
    Private Sub ValoresOriginales()
        Try
            '== Datos curso
            For Each i As Control In pnlCursoInfo.Controls
                Dim txtControl As DevComponents.DotNetBar.Controls.TextBoxX = TryCast(i, DevComponents.DotNetBar.Controls.TextBoxX)
                If TypeOf txtControl Is DevComponents.DotNetBar.Controls.TextBoxX Then
                    txtControl.Text = ""
                End If
            Next

            '== Datos empleado
            For Each j As Control In gpDatosEmp.Controls
                Dim txtControl As DevComponents.DotNetBar.Controls.TextBoxX = TryCast(j, DevComponents.DotNetBar.Controls.TextBoxX)
                If TypeOf txtControl Is DevComponents.DotNetBar.Controls.TextBoxX Then
                    txtControl.Text = "---"
                End If
            Next
            pnlCompletados.Style.BackColor1.Color = Color.Gainsboro
            pnlCompletados.Style.BackColor2.Color = Color.Gainsboro
            pnlPlaneados.Style.BackColor1.Color = Color.Silver
            pnlPlaneados.Style.BackColor2.Color = Color.Silver
            lblEdoEmpleado.Text = "---"
            lblEdoEmpleado.BackColor = Color.DimGray

            btnCursosEmpleado.Enabled = False
            picFoto.Image = PIDA.My.Resources.NoFoto
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        _tipoCurso = True
        Try : NavegacionInfo("ORDER BY CR.COD_CURSO ASC") : Catch ex As Exception : End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        _tipoCurso = True
        Try : NavegacionInfo("WHERE CR.COD_CURSO > '" & _CursoCodigo & "' ORDER BY CR.COD_CURSO ASC") : Catch ex As Exception : End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        _tipoCurso = True
        Try : NavegacionInfo("WHERE CR.COD_CURSO < '" & _CursoCodigo & "' ORDER BY CR.COD_CURSO DESC") : Catch ex As Exception : End Try
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        _tipoCurso = True
        Try : NavegacionInfo("ORDER BY CR.COD_CURSO DESC") : Catch ex As Exception : End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            If _CursoCodigo.Length > 1 And txtReloj.Text.Length > 3 Then
                If MessageBox.Show("¿Desea borrar el siguiente empleado de los cursos " & IIf(_tipoCurso = True, "completados?", "planeados?") & vbNewLine & vbNewLine & _
                                                    "Empleado: " & txtReloj.Text & vbNewLine & "Curso: " & txtnombre_curso.Text, "Confirmación",
                                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                    Dim query As String = "DELETE FROM CAPACITACION.dbo." & IIf(_tipoCurso = True, "cursos_empleado ", "planeacion_empleados ")

                    Select Case _tipoCurso
                        Case True
                            query = query & "WHERE COD_CURSO='" & lblCodCurso.Text & "' AND RELOJ='" & txtReloj.Text & "' AND INICIO='" & _fechaIni & "' AND FIN='" & _fechaFin & "'"
                        Case False
                            query = query & "WHERE COD_CURSO='" & lblCodCurso.Text & "' AND RELOJ='" & txtReloj.Text & "' AND fecha_captura='" & _fechaCap & "' AND fecha_maxima='" & _fechaMax & "'"
                    End Select

                    If Not sqlExecute(query).Columns.Contains("Error") Then
                        MessageBox.Show("Se ha eliminado el registro con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        NavegacionInfo("WHERE CR.COD_CURSO='" & lblCodCurso.Text & "'")
                    Else
                        MessageBox.Show("Ha ocurrido un error durante la eliminación, por favor contacte al administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                MessageBox.Show("Por favor, seleccione primero un empleado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCursosEmpleado_Click(sender As Object, e As EventArgs) Handles btnCursosEmpleado.Click
        Try
            _varRelojCurso = txtReloj.Text
            'frmMain.btnCursosEmpleado.RaiseClick()
            Dim cursos As frmConsulta = New frmConsulta
            cursos.Show()
            cursos.Focus()
            cursos.MdiParent = frmMain
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim Cod As String
            Cod = Buscar("capacitacion.dbo.Cursos", "cod_curso", "Cursos", False)
            If Cod <> "CANCELAR" Then
                NavegacionInfo("WHERE CR.COD_CURSO='" & Codigo & "'")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Dim consultaReporte As String = ""
            Dim dtData As New DataTable
            Dim dtTemporal As New DataTable

            '== Para empleados con el curso planeado
            consultaReporte = "SELECT RTRIM(PL.RELOJ) AS RELOJ,RTRIM(P.NOMBRES) AS NOMBRE_EMPLEADO,('') as INICIO,('') as FIN," & _
                                "('') as INSTRUCTOR,('') AS ESTATUS,(RTRIM(P.COD_DEPTO)+' - '+RTRIM(P.nombre_depto)) AS DEPARTAMENTO," & _
                                "(RTRIM(P.COD_PUESTO)+' - '+RTRIM(P.nombre_puesto)) AS PUESTO,P.ALTA,('') as COMENTARIO,('') as COD_CURSO " & _
                                "FROM CAPACITACION.DBO.cursos C INNER JOIN CAPACITACION.DBO.planeacion_empleados PL " & _
                                "ON C.COD_CURSO=PL.COD_CURSO INNER JOIN PERSONAL.DBO.personalvw P " & _
                                "ON P.RELOJ=PL.RELOJ " & _
                                "WHERE PL.COD_CURSO='" & lblCodCurso.Text & "' " & _
                                "ORDER BY PL.RELOJ ASC"

            dtTemporal = sqlExecute(consultaReporte)
            dtData = dtTemporal.Clone

            If dtTemporal.Rows.Count > 0 Then
                For Each x As DataRow In dtTemporal.Rows
                    x.Item("inicio") = "---"
                    x.Item("fin") = "---"
                    x.Item("instructor") = "---"
                    x.Item("estatus") = "PL"
                    x.Item("comentario") = "Planeado"
                    x.Item("cod_curso") = lblCodCurso.Text
                    dtData.ImportRow(x)
                Next
            End If

            '== Para empleados con el curso completado
            consultaReporte = "SELECT RTRIM(CE.RELOJ) AS RELOJ,RTRIM(P.NOMBRES) AS NOMBRE_EMPLEADO,CE.INICIO,CE.FIN," & _
                                              "UPPER(RTRIM(I.NOMBRE)) AS INSTRUCTOR,('') AS ESTATUS," & _
                                               "(RTRIM(CE.COD_DEPTO)+' - '+RTRIM(P.nombre_depto)) AS DEPARTAMENTO," & _
                                                "(RTRIM(CE.COD_PUESTO)+' - '+RTRIM(P.nombre_puesto)) AS PUESTO," & _
                                                "CE.ALTA,('') AS COMENTARIO,('') AS COD_CURSO " & _
                                                "FROM CAPACITACION.DBO.cursos C INNER JOIN CAPACITACION.DBO.cursos_empleado CE " & _
                                                "ON C.COD_CURSO=CE.COD_CURSO INNER JOIN PERSONAL.DBO.personalvw P " & _
                                                "ON P.RELOJ=CE.RELOJ INNER JOIN CAPACITACION.DBO.instructores I " & _
                                                "ON I.COD_INSTRUCTOR=CE.COD_INSTRUCTOR " & _
                                                "WHERE CE.COD_CURSO='" & lblCodCurso.Text & "' " & _
                                                "ORDER BY CE.RELOJ ASC"

            dtTemporal = sqlExecute(consultaReporte)
            Dim fechaTemp As String = ""

            If dtTemporal.Rows.Count > 0 Then
                For Each x As DataRow In dtTemporal.Rows
                    x.Item("estatus") = "CM"
                    x.Item("comentario") = "Completado"
                    x.Item("cod_curso") = lblCodCurso.Text
                    dtData.ImportRow(x)
                Next
            End If

            frmVistaPrevia.LlamarReporte("Matriz Capacitacion Cursos", dtData)
            frmVistaPrevia.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSubirPDF_Click(sender As Object, e As EventArgs) Handles btnSubirPDF.Click
        SubePdf("1")
    End Sub

    Private Sub btnVerPDF_Click(sender As Object, e As EventArgs) Handles btnVerPDF.Click
        VerDocPdf(txtPathPdf.Text.ToString.Trim)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

    End Sub

    Private Sub btnGuardaDocs_Click(sender As Object, e As EventArgs) Handles btnGuardaDocs.Click

        Try
            Dim _cod_curso As String = "", path1 As String = "", path2 As String = "", path3 As String = ""
            _cod_curso = lblCodCurso.Text.Trim
            path1 = txtPathPdf.Text.ToString.Trim
            path2 = txtPathPdf2.Text.ToString.Trim
            path3 = txtPathPdf3.Text.ToString.Trim

            Dim item = (From x In dtDocsCursosEmpl.Rows Where x("COD_CURSO").ToString.Trim = _cod_curso).ToList()
            If (item.Count > 0) Then ' Existe, hacer el UPDATE
                Dim QUpdate As String = "update docs_cursos_empleado set path_pdf1='" & path1 & "',path_pdf2='" & path2 & "',path_pdf3='" & path3 & "' where cod_curso='" & _cod_curso & "'"
                sqlExecute(QUpdate, "CAPACITACION")
                MessageBox.Show("Se actualizaron correctamente los documentos", "Actualiza", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else ' No existe, hacer el insert
                Dim QInsert As String = "insert into docs_cursos_empleado values ('" & _cod_curso & "','" & path1 & "','" & path2 & "','" & path3 & "')"
                sqlExecute(QInsert, "CAPACITACION")
                MessageBox.Show("Se guardaron correctamente los documentos", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub SubePdf(path_pdf As String)
        Try
            Dim File As New OpenFileDialog
            Dim ruta_origen As String = ""
            Dim ruta_destino As String = ""

            ruta_destino = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"

            File.Title = "Abrir..."
            File.Multiselect = False
            File.Filter = "PDF Files(*.pdf)|*.pdf|All Files(*.*)|*.*"
            Dim rs As DialogResult = File.ShowDialog()

            If rs = Windows.Forms.DialogResult.OK Then
                ruta_origen = File.FileName
                Dim newNameFile As String = ruta_origen.Trim.Split("\").Last()
                newNameFile = newNameFile.Replace(".pdf", "")
                '    newNameFile = newNameFile.Trim & "_" + Folio.ToString.Trim & "_" & txtReloj.Text.ToString.Trim & ".pdf"

                Select Case path_pdf
                    Case "1"
                        newNameFile = newNameFile.Trim & "_curso_" + _CursoCodigo.ToString.Trim & "_01.pdf"
                    Case "2"
                        newNameFile = newNameFile.Trim & "_curso_" + _CursoCodigo.ToString.Trim & "_02.pdf"
                    Case "3"
                        newNameFile = newNameFile.Trim & "_curso_" + _CursoCodigo.ToString.Trim & "_03.pdf"
                End Select



                Dim ruta_sin_file As String = ruta_origen.Replace(ruta_origen.Trim.Split("\").Last(), "")
                ruta_destino = ruta_sin_file & newNameFile

                My.Computer.FileSystem.CopyFile(ruta_origen, ruta_destino, True)

                Select Case path_pdf
                    Case "1"
                        txtPathPdf.Text = ruta_destino
                    Case "2"
                        txtPathPdf2.Text = ruta_destino
                    Case "3"
                        txtPathPdf3.Text = ruta_destino
                End Select

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub VerDocPdf(path_pdf As String)
        '---Tomar ruta de la BD para mandarlo a RutaPDF
        Dim pdfVer As New frmVisualizaPDF
        Dim RutaPDF As String = path_pdf

        '----Validar si el archivo existe
        If System.IO.File.Exists(RutaPDF) = False Then
            MessageBox.Show("El archivo '" & RutaPDF & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            frmCapturaAccionDisciplinaria.BotonVisualizaPDF(RutaPDF, pdfVer)
        End If
    End Sub

    Private Sub btnSubirPdf2_Click(sender As Object, e As EventArgs) Handles btnSubirPdf2.Click
        SubePdf("2")
    End Sub

    Private Sub btnSubirPdf3_Click(sender As Object, e As EventArgs) Handles btnSubirPdf3.Click
        SubePdf("3")
    End Sub

    Private Sub btnVerPDF2_Click(sender As Object, e As EventArgs) Handles btnVerPDF2.Click
        VerDocPdf(txtPathPdf2.Text.ToString.Trim)
    End Sub

    Private Sub btnVerPDF3_Click(sender As Object, e As EventArgs) Handles btnVerPDF3.Click
        VerDocPdf(txtPathPdf3.Text.ToString.Trim)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

    End Sub
End Class
