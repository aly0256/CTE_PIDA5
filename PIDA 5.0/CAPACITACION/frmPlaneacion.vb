Public Class frmPlaneacion
    Dim FiltroPlan As String = ""
    Dim _dtPlaneadosEmp As DataTable
    Dim _dtPlaneadosCursos As DataTable
    Dim _strNomCurso = ""
    Dim _dicLlave As New Dictionary(Of String, String)
    Dim _intFila = -1
    Dim _fhaInicio As New Date
    Dim _fhaFinal As New Date

    Private Sub frmPlaneacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        NFiltros = 0
        Me.Dispose()
    End Sub

    Private Sub frmPlaneacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            NFiltros = 0
            bgw.WorkerReportsProgress = True
            dgVistaPrevia.AutoGenerateColumns = False

            cmbCurso.DataSource = sqlExecute("SELECT cod_curso,nombre FROM cursos", "capacitacion")
            cmbAno.DataSource = sqlExecute("SELECT DISTINCT ano FROM periodos ORDER BY ano DESC", "ta")
            cmbMes.DataSource = sqlExecute("SELECT mes_may FROM meses ORDER BY num_mes")

            chkFecha.Checked = True
            txtFecha.Value = Now.Date
            dgTabla.DataSource = sqlExecute("SELECT planeacion_cursos.cod_curso AS 'codigo',RTRIM(cursos.NOMBRE) AS nombre,ano,mes,SPACE(10) AS mes_letra," & _
                                              "obligatorio FROM planeacion_cursos " & "LEFT JOIN cursos ON planeacion_cursos.cod_curso = cursos.cod_curso " & _
                                              "ORDER BY ano desc,mes,cursos.cod_curso", "capacitacion")
            dgTabla.Columns("mes").Visible = False
            For Each dRow As System.Windows.Forms.DataGridViewRow In dgTabla.Rows
                dRow.Cells("colMes").Value = IIf(IsDBNull(dRow.Cells("mes").Value), "", MesLetra(dRow.Cells("mes").Value.ToString))
            Next

            '-- Cursos planeados de empleados       Ernesto     13Junio2022
            CargaInfo(cmbCurso.SelectedValue.ToString.Trim, "Inicio")

            '   Revisar perfil para habilitar o deshabilitar controles:
            Dim _visible As Boolean = True
            _visible = revisarPerfiles(Perfil, Me, _visible, "WME", "")
            btnCriterio.Visible = _visible
            btnVerificar.Visible = _visible
            btnAceptar.Visible = _visible
            btnCancelar.Visible = _visible
            btnEdita.Visible = _visible
            btnEliminaSel.Visible = _visible
            btnEliminaTodos.Visible = _visible

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    '== Carga la info de los empleados por curso planeado.          Ernesto         13junio2022
    Private Sub CargaInfo(codCurso As String, op As String)
        Try
            Select Case op
                Case "Inicio"
                    '== Cursos planeados de empleados
                    _dtPlaneadosEmp = sqlExecute("select c.cod_curso,cu.nombre,c.reloj,c.fecha_captura,c.fecha_maxima,c.obligatorio,c.ano,c.mes,p.nombres " & _
                                                                            "from capacitacion.dbo.planeacion_empleados c  " & _
                                                                            "left join personal.dbo.personalvw p on p.reloj=c.reloj " & _
                                                                            "left join capacitacion.dbo.cursos cu on cu.cod_curso=c.cod_curso")
                    _dtPlaneadosCursos = sqlExecute("select cod_curso,ano,mes,condicion,obligatorio from capacitacion.dbo.planeacion_cursos order by cod_curso")
                    EstadoBotonesInicialCursosEmp(True)
                    CargaInfo(cmbCurso.SelectedValue.ToString.Trim, "Seleccion")
                Case "Seleccion"
                    '-- Carga los años existentes para ese curso
                    Dim dtAnio = (New DataView(_dtPlaneadosCursos, "cod_curso='" & codCurso & "'", "", DataViewRowState.CurrentRows)).ToTable("", True, "ano")
                    lblCursosPlaneados.Text = "Empleados cursos planeados - Curso " & codCurso
                    If dtAnio.Rows.Count > 0 Then cmbPlAnio.DataSource = dtAnio : cmbPlAnio.Enabled = True Else EstadoBotonesInicialCursosEmp(True)

                    '-- Carga los meses existentes para ese curso
                Case "CargaMes"
                    Dim dtMes = (New DataView(_dtPlaneadosCursos, "cod_curso='" & codCurso & "' and ano='" & cmbPlAnio.SelectedValue.ToString & "'", "", DataViewRowState.CurrentRows)).ToTable("", True, "mes")
                    If dtMes.Rows.Count > 0 Then cmbPlMes.DataSource = dtMes : cmbPlMes.Enabled = True

                    '-- Carga el datagrid con el lote seleccionado
                Case "CargaDataGrid"
                    Dim dvCursoSel = New DataView(_dtPlaneadosEmp, "cod_curso='" & codCurso & "' and ano='" & cmbPlAnio.SelectedValue.ToString.Trim & "' and mes='" & cmbPlMes.SelectedValue.ToString.Trim & "'",
                                                                                 "", DataViewRowState.CurrentRows)
                    Dim dtCursoSel = dvCursoSel.ToTable("", False, "reloj", "nombres", "ano", "mes", "fecha_captura", "fecha_maxima", "obligatorio")
                    Dim dtFhaMax = dvCursoSel.ToTable("", True, "fecha_maxima")

                    dgCursosPlaneados.DataSource = dtCursoSel

                    Try : dtiInicio.Value = dtCursoSel.Rows(0)("fecha_captura") : Catch ex As Exception : dtiInicio.Value = Nothing : End Try : _fhaInicio = dtiInicio.ValueObject
                    Try : dtiMax.Value = IIf(dtFhaMax.Rows.Count = 1, dtCursoSel.Rows(0)("fecha_maxima"), Nothing) : Catch ex As Exception : dtiMax.Value = Nothing : End Try : _fhaFinal = dtiMax.ValueObject
                    Try : _strNomCurso = dvCursoSel.Item(0)("cod_curso").ToString.Trim & " - " & dvCursoSel.Item(0)("nombre").ToString.Trim : Catch ex As Exception : _strNomCurso = "" : End Try
                    chkFhaIni.Enabled = dtCursoSel.Rows.Count > 0 : chkFhaIni.Checked = False
                    chkFhaMax.Enabled = dtCursoSel.Rows.Count > 0 : chkFhaMax.Checked = False
                    dtiInicio.Enabled = dtCursoSel.Rows.Count > 0 And chkFhaIni.Checked
                    dtiMax.Enabled = dtCursoSel.Rows.Count > 0 And chkFhaIni.Checked
                    btnEdita.Enabled = dtCursoSel.Rows.Count > 0 And (chkFhaIni.Checked OrElse chkFhaMax.Checked)
                    btnEliminaSel.Enabled = dtCursoSel.Rows.Count > 0
                    btnEliminaTodos.Enabled = dtCursoSel.Rows.Count > 0
                  
                    '-- Fila del dgv por default
                    _fhaInicio = IIf(dtiInicio.ValueObject IsNot Nothing, dtiInicio.Value, Nothing)
                    _intFila = -1
            End Select
        Catch ex As Exception
        End Try
    End Sub

    '== Estado botones          Ernesto         14Junio2022
    Private Sub EstadoBotonesInicialCursosEmp(edoVacio As Boolean, Optional validaNoReg As Boolean = False)

        If edoVacio Then
            Dim dtEstructuraEmp = creaDt("reloj,nombres,ano,mes,fecha_captura,fecha_maxima,obligatorio", "String,String,String,String,Date,Date,Bool")
            Dim dtEstructuraCursoAnio = creaDt("ano", "String")
            Dim dtEstructuraCursoMes = creaDt("mes", "String")

            dgCursosPlaneados.DataSource = dtEstructuraEmp
            cmbPlAnio.DataSource = dtEstructuraCursoAnio
            cmbPlAnio.Enabled = False
            cmbPlMes.DataSource = dtEstructuraCursoMes
            cmbPlMes.Enabled = False

            dtiInicio.Value = Nothing
            dtiInicio.Enabled = False
            dtiMax.Value = Nothing
            dtiMax.Enabled = False
            btnEdita.Enabled = False
            btnEliminaSel.Enabled = False
            btnEliminaTodos.Enabled = False

            _fhaInicio = Nothing
            _fhaFinal = Nothing
            chkFhaIni.Enabled = False
            chkFhaMax.Enabled = False
            chkFhaIni.Checked = False
            chkFhaMax.Checked = False
        End If

        '-- Si no existen empleados en ese curso planeado, se elimina el curso de la tabla 'planeacion_curso'
        If validaNoReg Then
            If sqlExecute("select * from capacitacion.dbo.planeacion_empleados where cod_curso='" & cmbCurso.SelectedValue.ToString.Trim & "' and ano='" & cmbPlAnio.SelectedValue.ToString.Trim & "' and mes='" & cmbPlMes.SelectedValue.ToString.Trim & "'").Rows.Count = 0 Then
                sqlExecute("delete from capacitacion.dbo.planeacion_cursos where cod_curso='" & cmbCurso.SelectedValue.ToString.Trim & "' and ano='" & cmbPlAnio.SelectedValue.ToString.Trim & "' and mes='" & cmbPlMes.SelectedValue.ToString.Trim & "'")
            End If
        End If

    End Sub

    Private Sub btnObligatorio_ValueChanged(sender As Object, e As EventArgs) Handles btnObligatorio.ValueChanged
        pnlObligatorio.Enabled = btnObligatorio.Value
    End Sub

    Private Sub btnCriterio_Click(sender As Object, e As EventArgs) Handles btnCriterio.Click

        frmTrabajando.Show(Me)
        frmTrabajando.Avance.Value = 0
        frmTrabajando.Avance.IsRunning = True
        frmTrabajando.lblAvance.Text = "Preparando datos..."
        Application.DoEvents()
        bgw.RunWorkerAsync()

    End Sub

    Private Function AsignaPlaneacionEmpleados(ByRef Condicion As String) As DataTable
        Try
            Dim dtPlaneacion As New DataTable
            Dim drPlan As DataRow
            Dim dtEmpleados As New DataTable
            Dim drEmpleado As DataRow

            If Condicion = "ERROR" Then
                Err.Raise(-1)
            End If
            'Condición en falso, para obtener solo la estructura
            dtPlaneacion = sqlExecute("SELECT *,space(70) AS nombres FROM planeacion_empleados WHERE 1=2", "capacitacion")
            'Independientemente del filtro, solo se puede programar curso a empleados activos
            dtEmpleados = sqlExecute("SELECT RELOJ,NOMBRES,ALTA FROM PERSONALVW WHERE BAJA IS NULL " & _
                                    IIf(Condicion.Length > 0, " AND ", "") & Condicion)
            For Each drEmpleado In dtEmpleados.Rows
                drPlan = dtPlaneacion.NewRow
                drPlan("reloj") = drEmpleado("reloj")
                drPlan("cod_curso") = cmbCurso.SelectedValue
                drPlan("ano") = cmbAno.Text
                drPlan("mes") = MesNumero(cmbMes.Text)
                drPlan("obligatorio") = btnObligatorio.Value
                drPlan("usuario") = Usuario
                drPlan("fecha_captura") = Now.Date
                drPlan("nombres") = drEmpleado("nombres")
                If btnObligatorio.Value Then
                    If chkAlta.Checked Then
                        drPlan("fecha_maxima") = DateAdd(DateInterval.Month, txtMeses.Value, drEmpleado("alta"))
                    Else
                        drPlan("fecha_maxima") = DateAdd(DateInterval.Month, txtMeses.Value, txtFecha.Value)
                    End If
                End If
                dtPlaneacion.Rows.Add(drPlan)
            Next
            Return dtPlaneacion

        Catch ex As Exception
            MessageBox.Show("Hay un error en la condición indicada, por lo que no puede asignarse empleados a este curso. Favor de verificar.", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return New DataTable
        End Try

    End Function

    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click

        dgVistaPrevia.DataSource = AsignaPlaneacionEmpleados(txtCriterio.Text.Trim)
        lblEmpleados.Text = dgVistaPrevia.Rows.Count - 1 & " empleados por asignar"
        sprTabPlaneacion.SelectedTabIndex = 1
    End Sub

    Private Sub bgw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        Dim dtDatosPersonal As New DataTable
        'No utilizar nivel actual, pues se accesa a todo el personal (solo para capacitación)
        dtDatosPersonal = sqlExecute("EXEC MaestroPersonal @Nivel = " & NivelConsulta & ", @Reloj = ''")
        dtResultado = dtDatosPersonal.Clone

        frmTrabajando.Avance.IsRunning = True
        dtResultado = dtDatosPersonal.Clone

        'dtResultado = sqlExecute("SELECT * FROM CURSOS_EMPLEADOVW" W", "CAPACITACION")

        For Each dRow As DataRow In dtDatosPersonal.Select("baja IS NULL" & IIf(FiltroXUsuario.Length > 0, " AND " & FiltroXUsuario, ""))
            bgw.ReportProgress(0, "Reloj " & dRow.Item("reloj"))

            dRow.Item("sactual") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("sactual"), 0)
            dRow.Item("integrado") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("integrado"), 0)
            dRow.Item("pro_var") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("pro_var"), 0)
            dRow.Item("factor_int") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("factor_int"), 0)
            dRow.Item("sal_ant") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("sal_ant"), 0)
            dtResultado.ImportRow(dRow)
        Next
    End Sub

    Private Sub bgw_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgw.ProgressChanged
        frmTrabajando.lblAvance.Text = e.UserState
    End Sub

    Private Sub bgw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted

        ActivoTrabajando = False

        frmTrabajando.Close()
        frmTrabajando.Dispose()
        frmFiltro.ShowDialog()
        If NFiltros > 0 Then
            Dim i As Integer
            Try
                FiltroPlan = ""
                For i = 0 To NFiltros - 1
                    FiltroPlan = FiltroPlan & IIf(i > 0, " AND (", "(") & Filtros(2, i) & ")"
                Next

            Catch ex As Exception
                FiltroPlan = "ERROR"
            Finally
                txtCriterio.Text = FiltroPlan
                dgVistaPrevia.DataSource = AsignaPlaneacionEmpleados(txtCriterio.Text.Trim)
                lblEmpleados.Text = dgVistaPrevia.Rows.Count & " empleados por asignar"
                sprTabPlaneacion.SelectedTabIndex = 1
                MessageBox.Show("Hay " & dgVistaPrevia.Rows.Count & " empleados que cumplen con el criterio para tomar el curso." & _
                                vbCrLf & "Revise la pestaña de 'Vista previa de personal asignado' para mayor detalle.", _
                                "Planeación por criterio", MessageBoxButtons.OK)
            End Try
        End If
    End Sub

    Private Sub chkAlta_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlta.CheckedChanged
    End Sub

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged
        txtFecha.Enabled = chkFecha.Checked
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            Dim dtPlaneacion As New DataTable
            dtPlaneacion = AsignaPlaneacionEmpleados(txtCriterio.Text.Trim)
            lblEmpleados.Text = dgVistaPrevia.Rows.Count & " empleados por asignar"
            If dgVistaPrevia.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron empleados que cumplan el criterio. Favor de verificar.", "Condición inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            frmTrabajando.Show(Me)
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.Text = "Planeación"
            frmTrabajando.lblAvance.Text = "Preparando datos..."
            Application.DoEvents()

            sqlExecute("INSERT INTO planeacion_cursos (cod_curso,ano,mes,obligatorio,condicion) VALUES (" & _
                       "'" & cmbCurso.SelectedValue & "'," & _
                       "'" & cmbAno.SelectedValue & "'," & _
                       "'" & MesNumero(cmbMes.SelectedValue) & "'," & _
                       IIf(btnObligatorio.Value, 1, 0) & "," & _
                       "'" & txtCriterio.Text.Trim.Replace("'", "''") & "')", "capacitacion")

            For Each dEmp As DataRow In dtPlaneacion.Rows
                frmTrabajando.lblAvance.Text = "Reloj " & dEmp("reloj")
                Application.DoEvents()
                'sqlExecute("INSERT INTO planeacion_empleados (reloj,cod_curso,ano,mes,obligatorio,usuario,fecha_captura,fecha_maxima) VALUES (" & _
                '           "'" & dEmp("reloj") & "'," & _
                '           "'" & dEmp("cod_curso") & "'," & _
                '           "'" & dEmp("ano") & "'," & _
                '           "'" & dEmp("mes") & "'," & _
                '           "'" & dEmp("obligatorio") & "'," & _
                '           "'" & dEmp("usuario") & "'," & _
                '           "'" & dEmp("fecha_captura") & "'," & _
                '           "'" & dEmp("fecha_maxima") & "')", "capacitacion")

                '==Modificacion para que tome el formato de fecha correcto              14sep2021
                sqlExecute("INSERT INTO planeacion_empleados (reloj,cod_curso,ano,mes,obligatorio,usuario,fecha_captura,fecha_maxima) VALUES (" & _
            "'" & dEmp("reloj") & "'," & _
            "'" & dEmp("cod_curso") & "'," & _
            "'" & dEmp("ano") & "'," & _
            "'" & dEmp("mes") & "'," & _
            "'" & dEmp("obligatorio") & "'," & _
            "'" & dEmp("usuario") & "'," & _
            "'" & FechaSQL(dEmp("fecha_captura")) & "'," & _
            "'" & FechaSQL(dEmp("fecha_maxima")) & "')", "capacitacion")
            Next

            dgTabla.DataSource = sqlExecute("SELECT planeacion_cursos.cod_curso AS 'codigo',RTRIM(cursos.NOMBRE) AS nombre,ano,mes,SPACE(10) AS mes_letra," & _
                                            "obligatorio FROM planeacion_cursos " & "LEFT JOIN cursos ON planeacion_cursos.cod_curso = cursos.cod_curso " & _
                                            "ORDER BY ano desc,mes,cursos.cod_curso", "capacitacion")
           For Each dRow As System.Windows.Forms.DataGridViewRow In dgTabla.Rows
                dRow.Cells("colMes").Value = IIf(IsDBNull(dRow.Cells("mes").Value), "", MesLetra(dRow.Cells("mes").Value.ToString))
            Next
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            MessageBox.Show("Se programó el curso [" & cmbCurso.SelectedValue.ToString.Trim & "] para " & dtPlaneacion.Rows.Count & " empleados.", "Planeación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            '== Refrescar interfaz              Ernesto         15Junio2022
            CargaInfo(cmbCurso.SelectedValue.ToString.Trim, "Inicio")
            txtCriterio.Text = ""
            lblEmpleados.Text = "# Registros"
            dgVistaPrevia.DataSource = Nothing

        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()

            MessageBox.Show("Se detectaron errores durante el proceso. Si el problema persiste, favor de contactar al administrador del sistema." & _
                            vbCrLf & vbCrLf & "Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        If frmCursos.obligatorioCurso Then '------------Antonio
            btnCancelar.PerformClick()
            frmCursos.obligatorioCurso = False
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    '== Curso seleccionado - Ernesto - 13Junio2022
    Private Sub cmbCurso_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCurso.SelectedValueChanged
        Try : CargaInfo(cmbCurso.SelectedValue.ToString.Trim, "Seleccion") : _intFila = -1 : Catch ex As Exception : End Try
    End Sub

    '== Fila seleccionada - Ernesto - 13Junio2022
    Private Sub dgCursosPlaneados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCursosPlaneados.CellClick
        Try
            '-- Llena diccionario con info. del curso. Selección del fila.
            _dicLlave.Clear()
            _dicLlave.Add("cod_curso", "'" & cmbCurso.SelectedValue.ToString.Trim & "'")
            _dicLlave.Add("reloj", "'" & dgCursosPlaneados.Rows(e.RowIndex).Cells("reloj").Value.ToString.Trim & "'")
            _dicLlave.Add("fecha_captura", "'" & FechaSQL(dgCursosPlaneados.Rows(e.RowIndex).Cells("fecha_captura").Value) & "'")
            _dicLlave.Add("ano", "'" & dgCursosPlaneados.Rows(e.RowIndex).Cells("ano").Value.ToString.Trim & "'")
            _dicLlave.Add("mes", "'" & dgCursosPlaneados.Rows(e.RowIndex).Cells("mes").Value.ToString.Trim & "'")
            _intFila = e.RowIndex
        Catch ex As Exception : End Try
    End Sub

    '== Edita las fechas del curso planeado (manera masiva) - Ernesto - 14Junio2022
    Private Sub btnEdita_Click(sender As Object, e As EventArgs) Handles btnEdita.Click
        Try
            '-- Validaciones
            Dim boolFhasVacias = (Not dtiInicio.ValueObject Is Nothing And Not dtiMax.ValueObject Is Nothing)
            Dim boolFhasCorrectas = dtiInicio.Value <= dtiMax.Value
            Dim strMsj = "¿Desea modificar las fecha(s) del curso planeado: [" & _strNomCurso & "] con año-mes: [" & cmbPlAnio.SelectedValue.ToString.Trim & "-" & cmbPlMes.SelectedValue.ToString.Trim & "]? " & _
                                     "(Los cambios se aplicarán a todos los empleados del curso)." & vbNewLine & vbNewLine
            Dim strQry = "update capacitacion.dbo.planeacion_empleados set [val1][val2] where cod_curso='" & cmbCurso.SelectedValue.ToString.Trim & "' and ano+mes='" & cmbPlAnio.SelectedValue.ToString.Trim & cmbPlMes.SelectedValue.ToString.Trim & "'"

            Dim boolFhaInicial = chkFhaIni.Checked And (dtiInicio.ValueObject <> _fhaInicio)
            If boolFhaInicial And boolFhasVacias Then strMsj &= "Fecha inicial original: " & FechaSQL(_fhaInicio) & vbNewLine & "Fecha inicial nueva: " & FechaSQL(dtiInicio.Value) & vbNewLine : strQry = strQry.Replace("[val1]", "fecha_captura='" & FechaSQL(dtiInicio.Value) & "',") Else strQry = strQry.Replace("[val1]", "")
            Dim boolFhaFinal = chkFhaMax.Checked And (dtiMax.ValueObject <> _fhaFinal)
            If boolFhaFinal And boolFhasVacias Then strMsj &= "Fecha final original: " & FechaSQL(_fhaFinal) & vbNewLine & "Fecha final nueva: " & FechaSQL(dtiMax.Value) : strQry = strQry.Replace("[val2]", "fecha_maxima='" & FechaSQL(dtiMax.Value) & "'") Else strQry = strQry.Replace(",[val2]", "")

            '-- Actualizar fechas
            If (boolFhasVacias AndAlso boolFhasCorrectas) And (boolFhaInicial Or boolFhaFinal) Then
                If MessageBox.Show(strMsj, "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    sqlExecute(strQry)
                    CargaInfo(cmbCurso.SelectedValue.ToString.Trim, "Inicio")
                    MessageBox.Show("La actualización de la(s) fecha(s) se realizó con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                If Not boolFhasVacias Then MessageBox.Show("Por favor, complete los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If Not boolFhasCorrectas Then MessageBox.Show("La fecha inicial siempre debe ser menor que la fecha máxima.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                MessageBox.Show("Los valores nuevos deben ser distintos de los originales para poder actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub

    '== Elimina registro seleccionado   -   Ernesto     -   14Junio2022
    Private Sub btnEliminaSel_Click(sender As Object, e As EventArgs) Handles btnEliminaSel.Click
        Try
            If _intFila < 0 Then
                MessageBox.Show("Primero seleccione un registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If MessageBox.Show("¿Desea eliminar el registro seleccionado?" & vbNewLine & vbNewLine & "Reloj: " & _dicLlave("reloj") & vbNewLine & "Cod. curso: " & _dicLlave("cod_curso") & _
                                                      vbNewLine & "Fecha inicio: " & _dicLlave("fecha_captura") & vbNewLine & "Año: " & _dicLlave("ano") & vbNewLine & "Mes: " & _dicLlave("mes"), "Confirmación",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                    Dim strQry = "delete from capacitacion.dbo.planeacion_empleados where "
                    For Each i As KeyValuePair(Of String, String) In _dicLlave : strQry &= i.Key & "=" & i.Value & " and " : Next
                    strQry = strQry.Substring(0, strQry.Length - 5)
                    sqlExecute(strQry)
                    EstadoBotonesInicialCursosEmp(False, True)
                    CargaInfo(cmbCurso.SelectedValue.ToString.Trim, "Inicio")
                    MessageBox.Show("El registro se ha eliminado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la eliminación del registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '== Elimina todos los registros     -       Ernesto     -   14Junio2022
    Private Sub btnEliminaTodos_Click(sender As Object, e As EventArgs) Handles btnEliminaTodos.Click
        Try
            If MessageBox.Show("¿Desea eliminar el siguiente lote de manera completa?" & vbNewLine & vbNewLine & "Curso: " & _strNomCurso & vbNewLine &
                                                  "Año: " & cmbPlAnio.SelectedValue.ToString.Trim & vbNewLine & "Mes: " & cmbPlMes.SelectedValue.ToString.Trim,
                                                  "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                '-- Eliminar de tabla 'planeacion_empleados'
                sqlExecute("delete from capacitacion.dbo.planeacion_empleados where cod_curso='" & cmbCurso.SelectedValue.ToString.Trim & "' and ano='" & cmbPlAnio.SelectedValue.ToString.Trim & "' and mes='" & cmbPlMes.SelectedValue.ToString.Trim & "'")
                '-- Eliminar de tabla 'planeacion_cursos'
                sqlExecute("delete from capacitacion.dbo.planeacion_cursos where cod_curso='" & cmbCurso.SelectedValue.ToString.Trim & "' and ano='" & cmbPlAnio.SelectedValue.ToString.Trim & "' and mes='" & cmbPlMes.SelectedValue.ToString.Trim & "'")
                '-- Refrescar interfaz
                CargaInfo(cmbCurso.SelectedValue.ToString.Trim, "Inicio")
                MessageBox.Show("El lote se ha eliminado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la eliminación del lote.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '== Selecciona año     -       Ernesto     -   14Junio2022
    Private Sub cmbPlAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPlAnio.SelectedValueChanged
        Try : CargaInfo(cmbCurso.SelectedValue.ToString.Trim, "CargaMes") : Catch ex As Exception : End Try
    End Sub

    '== Selecciona mes     -       Ernesto     -   14Junio2022
    Private Sub cmbPlMes_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPlMes.SelectedValueChanged
        Try : CargaInfo(cmbCurso.SelectedValue.ToString.Trim, "CargaDataGrid") : Catch ex As Exception : End Try
    End Sub

    '== Selecciona fecha inicial     -       Ernesto     -   14Junio2022
    Private Sub chkFhaIni_CheckedChanged(sender As Object, e As EventArgs) Handles chkFhaIni.CheckedChanged
        dtiInicio.Enabled = chkFhaIni.Checked
        dtiInicio.Value = _fhaInicio
        If Not chkFhaIni.Checked And Not chkFhaMax.Checked Then btnEdita.Enabled = False Else btnEdita.Enabled = True
    End Sub

    '== Selecciona fecha final     -       Ernesto     -   14Junio2022
    Private Sub chkFhaMax_CheckedChanged(sender As Object, e As EventArgs) Handles chkFhaMax.CheckedChanged
        dtiMax.Enabled = chkFhaMax.Checked
        dtiMax.Value = _fhaFinal
        If Not chkFhaIni.Checked And Not chkFhaMax.Checked Then btnEdita.Enabled = False Else btnEdita.Enabled = True
    End Sub
End Class