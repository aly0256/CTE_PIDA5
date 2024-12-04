Public Class frmCapturaCursosMasivos
    Dim dtPeriodos As New DataTable
    Dim dtCursos As New DataTable
    Dim dtTemp As New DataTable

    Private Sub frmCapturaCursosMasivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtInfoPersonal As New DataTable
        Dim dtConfiguracion As New DataTable
        Dim dtcalif As New DataTable
        Dim calif As Integer
        Try
            cmbCurso.DataSource = sqlExecute("SELECT cod_curso,nombre FROM cursos where activo = 1 ORDER BY cod_curso", "capacitacion")
            cmbInstituto.DataSource = sqlExecute("SELECT cod_instituto,nombre FROM institutos ORDER BY cod_instituto", "capacitacion")
            cmbInstructor.DataSource = sqlExecute("SELECT cod_instructor,nombre FROM instructores ORDER BY cod_instructor", "capacitacion")

            'Buscar en la tabla de configuracion_cursos, si hay información predefinida para captura por este usuario
            dtConfiguracion = sqlExecute("SELECT configuracion_cursos.*,calificacion_minima," & _
                                            "case when calificacion<calificacion_minima then 0 else 1 end  as aprobado FROM seguridad.dbo.configuracion_cursos " & _
                                            "LEFT JOIN capacitacion.dbo.cursos ON configuracion_cursos.cod_curso = cursos.cod_curso " & _
                                            "WHERE usuario = '" & Usuario & "'", "capacitacion")
            If dtConfiguracion.Rows.Count = 0 Then
                'Si no hay información, insertar registro para el usuario
                sqlExecute("INSERT INTO configuracion_cursos (Usuario) VALUES ('" & Usuario & "')", "seguridad")
                'Actualizar info de configuración para el usuario
                dtConfiguracion = sqlExecute("UPDATE configuracion_cursos SET " & _
                                             "cod_curso = '" & cmbCurso.SelectedValue & "'," & _
                                             "cod_instituto = '" & cmbInstituto.SelectedValue & "'," & _
                                             "cod_instructor = '" & cmbInstructor.SelectedValue & "'," & _
                                             "inicio = '" & FechaSQL(txtFechaInicio.Value) & "'," & _
                                             "fin = '" & FechaSQL(txtFechaFin.Value) & "'," & _
                                             "calificacion = '" & txtCalificacion.Text & "'," & _
                                             "comentario = '" & txtComentario.Text & "'" & _
                                             "WHERE usuario = '" & Usuario & "'", "seguridad")


                dtConfiguracion = sqlExecute("SELECT configuracion_cursos.*,calificacion_minima," & _
                                           "case when calificacion<calificacion_minima then 0 else 1 end as aprobado FROM configuracion_cursos " & _
                                           "LEFT JOIN capacitacion.dbo.cursos ON configuracion_cursos.cod_curso = cursos.cod_curso " & _
                                           "WHERE usuario = '" & Usuario & "'", "seguridad")
            End If

            cmbCurso.SelectedValue = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("cod_curso")), "", dtConfiguracion.Rows(0).Item("cod_curso"))
            cmbInstituto.SelectedValue = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("cod_instituto")), "", dtConfiguracion.Rows(0).Item("cod_instituto"))
            cmbInstructor.SelectedValue = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("cod_instructor")), "", dtConfiguracion.Rows(0).Item("cod_instructor"))
            txtCalificacion.Text = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("calificacion")), 0, dtConfiguracion.Rows(0).Item("calificacion"))
            btnAprobado.Value = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("aprobado")), 0, dtConfiguracion.Rows(0).Item("aprobado")) = 1
            txtFechaInicio.Value = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("inicio")), Now.Date, dtConfiguracion.Rows(0).Item("inicio"))
            txtFechaFin.Value = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("fin")), Now.Date, dtConfiguracion.Rows(0).Item("fin"))
            txtComentario.Text = IIf(IsDBNull(dtConfiguracion.Rows(0).Item("comentario")), 0, dtConfiguracion.Rows(0).Item("comentario"))

            calif = txtCalificacion.Text
            dtcalif = sqlExecute("select calificacion_minima from cursos where cod_curso = '" & cmbCurso.SelectedValue & "'", "CAPACITACION")
            lblcalifminima.Text = "Calif. min. " & dtcalif.Rows(0).Item("calificacion_minima")
            If dtcalif.Rows(0).Item("calificacion_minima") = 0 Then
                lblaprobado.Visible = False
                btnAprobado.Visible = True
                Dim calif_min As Boolean
                calif_min = IIf(IsDBNull(dtcalif.Rows(0).Item("calificacion_minima")), False, IIf(dtcalif.Rows(0).Item("calificacion_minima") = 0, False, True))
                btnAprobado.IsReadOnly = calif_min
            Else
                btnAprobado.Visible = False
                lblaprobado.Visible = True
                If calif >= dtcalif.Rows(0).Item("calificacion_minima") Then
                    lblaprobado.Text = "APROBADO"
                Else
                    lblaprobado.Text = "NO APROBADO"
                End If
            End If




        Catch ex As Exception
            MessageBox.Show("Se encontraron errores al cargar los datos. Si el problema persiste, contacte al administrador del sistema." & _
                             vbCrLf & vbCrLf & "Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles btnArchivo.CheckedChanged
        btnBuscaArchivo.Enabled = btnArchivo.Checked
        txtArchivo.Enabled = btnArchivo.Checked
        txtLista.Enabled = btnLista.Checked
        txtLista.BackColor = IIf(txtLista.Enabled, SystemColors.Window, SystemColors.Control)
        btnBuscaLista.Enabled = btnLista.Checked
        txtCalificacion.Enabled = btnLista.Checked
        If btnArchivo.Checked Then
            txtArchivo.Focus()
        End If
    End Sub

    Private Sub btnLista_CheckedChanged(sender As Object, e As EventArgs) Handles btnLista.CheckedChanged
        btnBuscaArchivo.Enabled = btnArchivo.Checked
        txtArchivo.Enabled = btnArchivo.Checked
        txtLista.Enabled = btnLista.Checked
        txtLista.BackColor = IIf(txtLista.Enabled, SystemColors.Window, SystemColors.Control)
        btnBuscaLista.Enabled = btnLista.Checked
        txtCalificacion.Enabled = btnLista.Checked

        If btnLista.Checked Then
            txtLista.Focus()
        End If
    End Sub

    Private Sub btnBuscaArchivo_Click(sender As Object, e As EventArgs) Handles btnBuscaArchivo.Click
        Dim Archivo As String
        Try
            dlgArchivo.Multiselect = False
            dlgArchivo.FileName = ""
            dlgArchivo.Filter = "Listas de empleados|*.txt;*.xls;*.xlsx|Archivos excel|*.xls;*.xlsx|Archivos texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

            Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()
            If lDialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                Archivo = dlgArchivo.FileName
            End If

            If System.IO.File.Exists(Archivo) = False Then
                MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            txtArchivo.Text = Archivo
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim ArLista(,) As String
        Dim ArTexto() As String
        Dim ArErrores(,) As String
        Dim Notas As String
        Dim CambioValido As Boolean
        Dim Archivo As String
        Dim LN As String
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim z As Integer = 0
        Dim objReader As System.IO.StreamReader = Nothing
        Dim Cambios As Integer = 0
        Dim dtCurso As New DataTable
        Dim Minima As Double = 0
        Dim dtInfo As New DataTable
        Dim Baja As String

        Try
            'validarlista()
            'If validar Then
            If txtFechaFin.Value < txtFechaInicio.Value Then
                MessageBox.Show("La fecha de terminación del curso no puede ser anterior al inicio del mismo. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFechaFin.Focus()
                txtFechaFin.Select()
                Exit Sub
            End If

            ReDim ArErrores(x, 2)

            'A las notas, cambiar comillas y apóstrofes por doble apóstrofe, para evitar errores en SQL
            Notas = txtComentario.Text.Trim
            Notas = Notas.Replace("'", "''")
            Notas = Notas.Replace(Chr(34), "''")

            'Buscar calificación mínima del curso, para saber si está aprobado
            dtCurso = sqlExecute("SELECT calificacion_minima FROM cursos WHERE cod_curso = '" & cmbCurso.SelectedValue & "'", "capacitacion")
            If dtCurso.Rows.Count = 0 Then
                ArErrores(z, 0) = cmbCurso.SelectedValue
                ArErrores(z, 1) = "Curso no localizado"
                CambioValido = False
                z = z + 1
                Minima = 0
            Else
                Minima = IIf(IsDBNull(dtCurso.Rows(0).Item("calificacion_minima")), 0, dtCurso.Rows(0).Item("calificacion_minima"))
            End If

            'Si se seleccionó por archivo
            If btnArchivo.Checked Then
                Archivo = txtArchivo.Text.Trim

                If System.IO.File.Exists(Archivo) = False Then
                    MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                'Redimensionar el arreglo principal de inicio a 1000
                ReDim ArLista(2, 1000)

                'Si el archivo es tipo texto
                If Archivo.Substring(Archivo.Length - 4).ToLower = ".txt" Then
                    objReader = New System.IO.StreamReader(Archivo)

                    x = 0
                    y = objReader.BaseStream.Length
                    cpActualizacion.Maximum = 100
                    cpActualizacion.Visible = True
                    Application.DoEvents()

                    'Repasar todo el archivo
                    Do Until objReader.EndOfStream
                        LN = objReader.ReadLine
                        'Espera 2 columnas (reloj y calificacion), separadas por tab
                        ArTexto = Split(LN, vbTab)

                        'La primer columna, es reloj
                        If ArTexto.Length > 0 Then ArLista(1, x) = ArTexto(0)
                        'La segunda columna, es calificacion
                        If ArTexto.Length > 1 Then ArLista(2, x) = ArTexto(1)

                        x = x + 1
                        If UBound(ArLista, 2) < x Then
                            ReDim Preserve ArLista(2, x)
                        End If
                    Loop
                    x = x - 1
                    'Redimensionar el arreglo principal, de acuerdo al número de registros
                    ReDim Preserve ArLista(2, x)
                Else
                    'Llenar arreglo con datos de excel
                    ArLista = ExcelTOArrayList(Archivo)
                    x = ArLista.GetUpperBound(1)
                End If
            Else
                'Si no es archivo, llenar desde lista de números de reloj
                'el calificacion se carga desde txtCalificacion
                ArTexto = txtLista.Text.Split(",")
                x = ArTexto.Length - 1
                ReDim ArLista(2, x)
                For i = 0 To x
                    ArLista(1, i) = ArTexto(i)
                    ArLista(2, i) = txtCalificacion.Value
                Next
            End If
            z = 0
            'Activar progress bar
            cpActualizacion.Visible = True
            cpActualizacion.Maximum = x
            For y = 0 To x
                Reloj = ArLista(1, y).PadLeft(LongReloj, "0")

                cpActualizacion.Value = x
                cpActualizacion.Text = Reloj

                'Validar que el reloj sea válido y activo
                CambioValido = True
                If ArLista(1, y) = "00000" Then
                    ArErrores(z, 0) = ArLista(1, y)
                    ArErrores(z, 1) = "Reloj en blanco"
                    CambioValido = False
                    z = z + 1
                End If

                If Not CambioValido Then Continue For

                dtInfo = ConsultaPersonalVW("SELECT alta,baja,sexo,cod_depto,cod_turno,cod_puesto,cod_super,cod_tipo,personalVW.cod_comp,cod_planta " & _
                                          "FROM personalVW WHERE reloj= '" & Reloj & "'", False)
                If dtInfo.Rows.Count < 1 Then
                    ArErrores(z, 0) = ArLista(1, y)
                    ArErrores(z, 1) = "Empleado no localizado"
                    CambioValido = False
                    z = z + 1
                End If
                If Not CambioValido Then Continue For

                'Abraham, no validar bajas
                'If Not IsDBNull(dtInfo.Rows.Item(0).Item("baja")) Then
                '    ArErrores(z, 0) = ArLista(1, y)
                '    ArErrores(z, 1) = "Empleado dado de baja"
                '    CambioValido = False
                '    z = z + 1
                'End If

                'Si el cambio no es válido, pasar al siguiente índice
                'If Not CambioValido Then Continue For

                dtTemporal = sqlExecute("SELECT * FROM cursos_empleado WHERE reloj = '" & Reloj & "' AND cod_curso = '" & cmbCurso.SelectedValue & _
                                        "' AND inicio = '" & FechaSQL(txtFechaInicio.Value) & "'", "capacitacion")
                If dtTemporal.Rows.Count > 0 Then
                    ArErrores(z, 0) = ArLista(1, y)
                    ArErrores(z, 1) = "Ya tomó el curso en esta fecha"
                    CambioValido = False
                    z = z + 1
                End If
                If Not CambioValido Then Continue For



                'Si el cambio fue válido, insertar en la tabla de cursos_empleado
                If CambioValido Then
                    If IsDBNull(dtInfo.Rows(0).Item("baja")) Then
                        Baja = "NULL"
                    Else
                        Baja = "'" & FechaSQL(dtInfo.Rows(0).Item("baja")) & "'"
                    End If

                    sqlExecute("INSERT INTO cursos_empleado (reloj,cod_curso,alta," + IIf(IsDBNull(dtInfo.Rows(0).Item("baja")), "", "BAJA,") + "sexo,cod_depto,cod_turno,cod_puesto," & _
                               "cod_super,cod_tipo,cod_comp,cod_planta,cod_instructor,cod_instituto,inicio,fin,calificacion,aprobado," & _
                               "comentario,aplicado, duracion) VALUES (" & _
                               "'" & ArLista(1, y) & "'," & _
                               "'" & cmbCurso.SelectedValue & "'," & _
                               "'" & FechaSQL(dtInfo.Rows(0).Item("alta")) & "'," & _
                        IIf(IsDBNull(dtInfo.Rows(0).Item("baja")), "", Baja & ",") & _
                                    "'" & dtInfo.Rows(0).Item("sexo") & "'," & _
                               "'" & dtInfo.Rows(0).Item("cod_depto") & "'," & _
                               "'" & dtInfo.Rows(0).Item("cod_turno") & "'," & _
                               "'" & dtInfo.Rows(0).Item("cod_puesto") & "'," & _
                               "'" & dtInfo.Rows(0).Item("cod_super") & "'," & _
                               "'" & dtInfo.Rows(0).Item("cod_tipo") & "'," & _
                               "'" & dtInfo.Rows(0).Item("cod_comp") & "'," & _
                               "'" & dtInfo.Rows(0).Item("cod_planta") & "'," & _
                               "'" & cmbInstructor.SelectedValue & "'," & _
                               "'" & cmbInstituto.SelectedValue & "'," & _
                               "'" & FechaSQL(txtFechaInicio.Value) & "'," & _
                               "'" & FechaSQL(txtFechaFin.Value) & "','" & _
                               ArLista(2, y) & "'," & _
                               IIf(lblaprobado.Text = "APROBADO", 1, 0) & ", " & _
                               "'" & txtComentario.Text.Trim & "',0, '" & txtDuracion.Value & "')", "capacitacion")

                    PlaneacionCursada(ArLista(1, y), cmbCurso.SelectedValue, txtFechaInicio.Text)
                    Cambios += 1
                End If
            Next

            cpActualizacion.Visible = False
            If z > 0 Then
                'z cuenta los errores. Si es >0, notificar que hubo errores, y cuáles

                Dim Lista As String = ""
                For x = 0 To z - 1
                    Lista = Lista & vbCrLf & "  " & ArErrores(x, 0) & " " & ArErrores(x, 1)
                Next
                MessageBox.Show("Se detectaron errores durante la carga, en los siguientes empleados no pudo agregarse el ajuste: " & Lista, "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("La carga masiva de ajustes se realizó exitosamente, con " & Cambios & " registros agregados.", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Me.Dispose()
            End If
            'Else
            'MessageBox.Show("El numero de reloj '" & relojnovalido & "' no es valido", "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Catch ex As Exception
            MessageBox.Show("Se detectaron errores durante la carga, por lo que no pudieron agregarse el ajuste.", "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
        End Try

    End Sub

    Private Sub btnBuscaLista_Click(sender As Object, e As EventArgs) Handles btnBuscaLista.Click
        'Dim dtFaltantes As New DataTable
        'Dim FL As String = ""
        'Dim Resulta As String = ""

        'frmTrabajando.Show(Me)
        'frmTrabajando.Avance.Value = 0
        'frmTrabajando.Avance.IsRunning = True
        'frmTrabajando.lblAvance.Text = "Preparando datos..."
        'Application.DoEvents()
        'dtResultadoCapacitacion = sqlExecute("SELECT * FROM cursos_empleadoVW", "capacitacion")

        ''Buscar los empleados que no tengan cursos registrados, para incluirlos en filtro
        'dtFaltantes = ConsultaPersonalVW("SELECT RELOJ,NOMBRES,COD_DEPTO,COD_PUESTO,COD_TURNO,COD_SUPER,COD_TIPO,ALTA,BAJA,SEXO," & _
        '                         "NOMBRE_DEPTO,NOMBRE_TURNO,NOMBRE_PUESTO,NOMBRE_SUPER,NOMBRE_TIPOEMP,COMPANIA AS NOMBRE_COMPANIA," & _
        '                         "NOMBRE_PLANTA FROM PERSONALVW WHERE BAJA IS NULL AND RELOJ NOT IN " & _
        '                         "(SELECT DISTINCT RELOJ FROM CAPACITACION.dbo.CURSOS_EMPLEADOVW)", False)
        'For Each dR As DataRow In dtFaltantes.Rows
        '    frmTrabajando.lblAvance.Text = "Agregando " & dR("reloj")
        '    Application.DoEvents()
        '    dtResultadoCapacitacion.ImportRow(dR)
        'Next
        'ActivoTrabajando = False
        'frmTrabajando.Close()
        'frmTrabajando.Dispose()

        'frmFiltroCapacitacion.ShowDialog()
        'If NFiltrosCapacitacion > 0 Then

        '    Dim i As Integer
        '    Try
        '        For i = 0 To NFiltrosCapacitacion - 1
        '            FL = FL & IIf(i > 0, " AND (", "(") & FiltrosCapacitacion(2, i) & ")"
        '        Next

        '        For Each dR As DataRow In dtResultadoCapacitacion.Select(FL)
        '            Resulta = Resulta & IIf(Resulta.Length > 0, ",", "") & dR("Reloj")
        '        Next
        '        txtLista.Text = Resulta
        '        txtLista.SelectionStart = 0
        '    Catch ex As Exception
        '        txtLista.Text = "ERROR " & ex.Message
        '    End Try
        'End If

        Dim FL As String = ""
        Dim dtDatosPersonal As New DataTable
        frmTrabajando.Show(Me)
        frmTrabajando.Avance.Value = 0
        frmTrabajando.Avance.IsRunning = False
        frmTrabajando.lblAvance.Text = "Preparando datos..."
        Application.DoEvents()
        dtDatosPersonal = sqlExecute("EXEC MaestroPersonal @Nivel = " & NivelConsulta & ", @Reloj = ''")
        dtResultado = dtDatosPersonal.Clone
        frmTrabajando.Avance.IsRunning = True

        For Each dRow As DataRow In dtDatosPersonal.Select(FiltroXUsuario)
            frmTrabajando.lblAvance.Text = "Reloj " & dRow.Item("reloj")
            Application.DoEvents()

            dRow.Item("sactual") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("sactual"), 0)
            dRow.Item("integrado") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("integrado"), 0)
            dRow.Item("pro_var") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("pro_var"), 0)
            dRow.Item("factor_int") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("factor_int"), 0)
            dRow.Item("sal_ant") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("sal_ant"), 0)
            dtResultado.ImportRow(dRow)
        Next
        ActivoTrabajando = False

        frmTrabajando.Close()
        frmTrabajando.Dispose()


        frmFiltro.ShowDialog()
        If NFiltros > 0 Then
            Dim i As Integer
            Try
                For i = 0 To NFiltros - 1
                    FL = FL & IIf(i > 0, " AND (", "(") & Filtros(2, i) & ")"
                Next
                dtTemporal = ConsultaPersonalVW("SELECT RELOJ from personal WHERE " & FL)

                FL = ""
                For i = 0 To dtTemporal.Rows.Count - 1
                    FL = FL & IIf(i > 0, ",", "") & dtTemporal.Rows.Item(i).Item("Reloj")
                Next
                txtLista.Text = FL

            Catch ex As Exception
                FL = "ERROR"
            End Try
        End If

    End Sub

    Private Sub cmbCurso_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            dtTemp = sqlExecute("SELECT cod_naturaleza,misce_calificacion FROM Cursos WHERE Curso = '" & cmbCurso.SelectedValue & "'", "nomina")
            If dtTemp.Rows.Count And btnLista.Checked Then
                txtCalificacion.Value = IIf(IsDBNull(dtTemp.Rows(0).Item("misce_calificacion")), 0, dtTemp.Rows(0).Item("misce_calificacion"))
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub cmbCurso_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbCurso.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("CAPACITACION.DBO.cursos", "cod_curso", "cursos", False)
        If Cod <> "CANCELAR" Then
            'Dim dtCol As DataTable = sqlExecute("SELECT * from colonias WHERE cod_col = '" & Cod & "'")            
            cmbCurso.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbInstituto_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbInstituto.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("CAPACITACION.DBO.institutos", "cod_instituto", "institutos", False)
        If Cod <> "CANCELAR" Then
            'Dim dtCol As DataTable = sqlExecute("SELECT * from colonias WHERE cod_col = '" & Cod & "'")            
            cmbInstituto.SelectedValue = Cod
        End If
    End Sub


    Private Sub cmbInstructor_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbInstructor.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("CAPACITACION.DBO.instructores", "cod_instructor", "instructores", False)
        If Cod <> "CANCELAR" Then
            'Dim dtCol As DataTable = sqlExecute("SELECT * from colonias WHERE cod_col = '" & Cod & "'")            
            cmbInstructor.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbCurso_SelectedValueChanged_1(sender As Object, e As EventArgs) Handles cmbCurso.SelectedValueChanged
        Try
            Dim dtCurso As DataTable = sqlExecute("select cod_curso, isnull(duracion, 0) as duracion, isnull(calificacion_minima, 0) as minima from cursos where cod_curso = '" & cmbCurso.SelectedValue & "'", "capacitacion")
            If dtCurso.Rows.Count > 0 Then
                txtDuracion.Value = dtCurso.Rows(0)("duracion")
                If dtCurso.Rows(0).Item("minima") = 0 Then
                    lblaprobado.Visible = False
                    btnAprobado.Visible = True
                    btnAprobado.IsReadOnly = False
                Else
                    btnAprobado.Visible = False
                    lblaprobado.Visible = True
                    If txtCalificacion.Value >= dtCurso.Rows(0).Item("minima") Then
                        lblaprobado.Text = "APROBADO"
                    Else
                        lblaprobado.Text = "NO APROBADO"
                    End If
                End If

                lblcalifminima.Text = "Calif. min. " & dtCurso.Rows(0)("minima")

            Else
                txtDuracion.Value = 0
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtCalificacion_ValueChanged(sender As Object, e As EventArgs) Handles txtCalificacion.ValueChanged
        Dim dtCurso As New DataTable
        Dim minima As Integer
        dtCurso = sqlExecute("SELECT calificacion_minima FROM cursos WHERE cod_curso = '" & cmbCurso.SelectedValue & "'", "capacitacion")
        minima = IIf(IsDBNull(dtCurso.Rows(0).Item("calificacion_minima")), 0, dtCurso.Rows(0).Item("calificacion_minima"))
        If minima = 0 Then
            'btnAprobado.Value = False
        Else
            'btnAprobado.Value = (txtCalificacion.Value >= IIf(IsDBNull(dtCurso.Rows(0).Item("calificacion_minima")), 0, dtCurso.Rows(0).Item("calificacion_minima")))
            lblaprobado.Text = IIf((txtCalificacion.Value >= IIf(IsDBNull(dtCurso.Rows(0).Item("calificacion_minima")), 0, dtCurso.Rows(0).Item("calificacion_minima"))), "APROBADO", "NO APROBADO")
        End If
    End Sub

    Private Sub btnAprobado_ValueChanged(sender As Object, e As EventArgs) Handles btnAprobado.ValueChanged
        If btnAprobado.Value = False Then
            lblaprobado.Text = "NO APROBADO"
        ElseIf btnAprobado.Value = True Then
            lblaprobado.Text = "APROBADO"
        End If
    End Sub
    Dim validar As Boolean
    Dim relojnovalido As String
    Private Sub validarlista()
        Dim ArLista(,) As String
        Dim ArTexto() As String
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim z As Integer = 0
        Dim cambiovalido As Boolean

        ArTexto = txtLista.Text.Split(",")
        x = ArTexto.Length - 1
        ReDim ArLista(2, x)
        For i = 0 To x
            ArLista(1, i) = ArTexto(i)
            ArLista(2, i) = txtCalificacion.Value
        Next

        For y = 0 To x
            Reloj = ArLista(1, y).PadLeft(LongReloj, "0")

            Dim dtinfo As DataTable
            cambiovalido = True
            If ArLista(1, y) = "00000" Then

                cambiovalido = False
                z = z + 1
            End If

            dtinfo = ConsultaPersonalVW("SELECT alta,baja,sexo,cod_depto,cod_turno,cod_puesto,cod_super,cod_tipo,personalVW.cod_comp,cod_planta " & _
                                      "FROM personalVW WHERE reloj= '" & Reloj & "'", False)
            If dtinfo.Rows.Count < 1 Then

                Validar = False
                cambiovalido = False
                z = z + 1
                relojnovalido = Reloj
                Exit For
            Else
                validar = True
            End If

        Next

    End Sub

End Class
