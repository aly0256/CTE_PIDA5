Public Class frmConsulta
    Dim dtPersonal As New DataTable
    Dim dtTemp As New DataTable
    Dim dtCapacitacion As New DataTable
    Dim dtPlaneacion As New DataTable

    Dim ArchivoFoto As String

    '==nombre completo      julio2021
    Dim nombre_completo As String = ""
    Dim cod_puesto As String = ""

    Dim puesto As String = ""

    Private Sub frmConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '== Desde forma de empleados por curso              1oct2021
        If _varRelojCurso.Length > 1 Then
            dtPersonal = ConsultaPersonalVW("select top 1 * from personalvw where reloj='" & _varRelojCurso & "'")
            _varRelojCurso = ""
        Else
            dtPersonal = ConsultaPersonalVW("select top 1 * from personalvw order by reloj")
        End If
        MostrarInformacion()

        Dim _visible As Boolean = True
        _visible = revisarPerfiles(Perfil, Me, _visible, "WME", txtReloj.Text.ToString.Trim)
        btnNuevo.Visible = _visible
        btnEditar.Visible = _visible
        btnBorrar.Visible = _visible
        tabPlaneados.Visible = False

    End Sub

    Private Sub MostrarInformacion()
        Try
            Dim drPersonal As DataRow
            drPersonal = dtPersonal.Rows(0)
            txtReloj.Text = drPersonal("reloj")
            txtNombre.Text = IIf(IsDBNull(drPersonal("nombre")), "", drPersonal("nombre").ToString.Trim)
            txtApaterno.Text = IIf(IsDBNull(drPersonal("apaterno")), "", drPersonal("apaterno").ToString.Trim)
            txtAmaterno.Text = IIf(IsDBNull(drPersonal("amaterno")), "", drPersonal("amaterno").ToString.Trim)
            txtTurno.Text = drPersonal("cod_turno") & IIf(IsDBNull(drPersonal("nombre_turno")), "", ", " & drPersonal("nombre_turno"))
            txtTipoEmp.Text = drPersonal("cod_tipo") & IIf(IsDBNull(drPersonal("nombre_tipoemp")), "", ", " & drPersonal("nombre_tipoemp"))
            txtDepto.Text = drPersonal("cod_depto") & IIf(IsDBNull(drPersonal("nombre_depto")), "", ", " & drPersonal("nombre_depto"))
            txtSupervisor.Text = drPersonal("cod_super") & IIf(IsDBNull(drPersonal("nombre_super")), "", ", " & drPersonal("nombre_super").ToString.ToUpper.Trim)
            txtClase.Text = drPersonal("cod_clase") & IIf(IsDBNull(drPersonal("nombre_clase")), "", ", " & drPersonal("nombre_clase"))
            txtHorario.Text = drPersonal("cod_hora") & IIf(IsDBNull(drPersonal("nombre_horario")), "", ", " & drPersonal("nombre_horario"))
            txtPuesto.Text = drPersonal("cod_puesto") & IIf(IsDBNull(drPersonal("nombre_puesto")), "", ", " & drPersonal("nombre_puesto"))

            txtAlta.Value = IIf(IsDBNull(drPersonal("alta")), Nothing, drPersonal("alta"))
            EsBaja = Not IsDBNull(drPersonal("baja"))
            txtBaja.Value = IIf(EsBaja, drPersonal("baja"), Nothing)

            '-- Habilitar botón de transferencia de cursos [solo si el empleado es baja]        Ernesto     16Junio22
            btnTraspasar.Enabled = EsBaja
            puesto = IIf(IsDBNull(drPersonal("nombre_puesto")), "", drPersonal("nombre_puesto").ToString.Trim)

            '==VALIDAR SI ESTA CERTIFICADO      JULIO2021       ERNESTO
            nombre_completo = txtNombre.Text.ToString.Trim & " " & txtApaterno.Text.ToString.Trim & " " & txtAmaterno.Text.ToString.Trim
            ValidarCertificacion(txtReloj.Text.ToString.Trim, nombre_completo, FechaSQL(txtAlta.Value))
            ValidarRecertificacion(txtReloj.Text.ToString.Trim, nombre_completo, FechaSQL(txtAlta.Value))
            '==


            ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
            Try
                ArchivoFoto = drPersonal("foto")

                ''Dim ft As New Bitmap(ArchivoFoto)
                'picFoto.Width = picFoto.MinimumSize.Width
                'picFoto.Height = picFoto.MinimumSize.Height
                'picFoto.Left = 900
                ''picFoto.Image = ft
                picFoto.ImageLocation = ArchivoFoto
            Catch
                picFoto.Image = picFoto.ErrorImage
            End Try

            '*** Cambios en bajas ****
            txtBaja.Visible = EsBaja
            lblBaja.Visible = EsBaja
            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtReloj.BackColor = lblEstado.BackColor
            '*************************

            dtCapacitacion = sqlExecute("SELECT cursos_empleado.cod_curso, RTRIM(cursos.NOMBRE) as nombre_curso, cursos_empleado.cod_instituto, " & _
                                        "RTRIM(institutos.NOMBRE) as nombre_instituto, cursos_empleado.cod_instructor, RTRIM(instructores.NOMBRE) as nombre_instructor," & _
                                        "inicio, fin, calificacion, aprobado, RTRIM(cursos_empleado.comentario) AS comentario, cursos_empleado.duracion  as duracion " & _
                                        "FROM cursos_empleado " & _
                                        "LEFT JOIN cursos ON cursos_empleado.COD_CURSO = cursos.COD_CURSO LEFT JOIN institutos ON " & _
                                        "cursos_empleado.COD_INSTITUTO = institutos.COD_INSTITUTO LEFT JOIN instructores ON " & _
                                        "cursos_empleado.cod_instructor = instructores.cod_instructor where reloj ='" & drPersonal("reloj") & _
                                        "' AND aplicado = 1 " & _
                                        "ORDER BY inicio DESC,fin,cod_curso ", "Capacitacion")

            dgCapacitacion.DataSource = dtCapacitacion

            dtPlaneacion = sqlExecute("SELECT planeacion_empleados.cod_curso,cursos.nombre,ano,mes,obligatorio," & _
                                      "CASE WHEN fecha_curso IS NULL THEN 0 ELSE 1 END AS cursado,fecha_curso,usuario,fecha_captura,fecha_maxima " & _
                                      "FROM planeacion_empleados LEFT JOIN cursos ON planeacion_empleados.cod_curso = cursos.cod_curso " & _
                                      "WHERE RELOJ = '" & drPersonal("reloj") & "' ORDER BY ano DESC,mes,planeacion_empleados.cod_curso", _
                                      "capacitacion")

            dgPlaneados.DataSource = dtPlaneacion


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            MessageBox.Show("Ocurrió un error, por lo que la información no pudo actualizarse correctamente. " & _
                            "Si el error persiste, contacte al administrador del sistema." & vbCrLf & vbCrLf & "Error: " & _
                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim reloj As String
        reloj = txtReloj.Text
        dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * FROM PersonalVW WHERE reloj >'" & reloj & "' ORDER BY reloj ASC")
        If dtPersonal.Rows.Count < 1 Then
            btnLast.PerformClick()
        Else
            reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
            MostrarInformacion()
        End If
    End Sub


    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        Dim reloj As String
        reloj = txtReloj.Text
        dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * FROM PersonalVW ORDER BY reloj DESC")

        'EmpIdx = dtPersonal.Rows.Count - 1
        reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
        MostrarInformacion()
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        Dim reloj As String
        reloj = txtReloj.Text
        dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * FROM PersonalVW ORDER BY reloj ASC")
        reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
        MostrarInformacion()
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Dim reloj As String
        reloj = txtReloj.Text
        dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * FROM PersonalVW WHERE reloj <'" & reloj & "' ORDER BY reloj DESC")
        If dtPersonal.Rows.Count < 1 Then
            btnFirst.PerformClick()
        Else
            reloj = dtPersonal.Rows.Item(0).Item("RELOJ")

            MostrarInformacion()
        End If


    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtTemp = dtPersonal
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * FROM PersonalVW WHERE reloj = '" & Reloj & "' ORDER BY reloj ASC")
                If dtPersonal.Rows.Count = 0 Then
                    MessageBox.Show("El empleado " & Reloj & " no fue localizado, o tiene un nivel al que su usuario no tiene acceso.", "Empleado no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dtPersonal = dtTemp
                Else
                    MostrarInformacion()
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            dtPersonal = dtTemp
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim dtAjuste As New DataTable
        Try
            keyReloj = txtReloj.Text
            keyCurso = dgCapacitacion.Item("cl_cod_curso", dgCapacitacion.CurrentRow.Index).Value.ToString.Trim
            keyFechaInicio = dgCapacitacion.Item("cl_inicio", dgCapacitacion.CurrentRow.Index).Value
            AplicarCurso = True
            If frmEditarCursosEmpleado.ShowDialog(Me) = Windows.Forms.DialogResult.Abort Then
                Err.Raise(-1)
            End If
            MostrarInformacion()
        Catch ex As Exception
            MessageBox.Show("El registro no puede ser modificado. Favor de verificar.", "Editar ajuste", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim Respuesta As Windows.Forms.DialogResult

        'Insertar núm. de crédito para formar registro base
        keyReloj = txtReloj.Text
        keyCurso = "NVO"
        keyFechaInicio = Now
        AplicarCurso = True
        Respuesta = frmEditarCursosEmpleado.ShowDialog(Me)
        If Respuesta = Windows.Forms.DialogResult.Abort Then
            MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf Respuesta = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        MostrarInformacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            Dim dtAjuste As New DataTable
            keyReloj = txtReloj.Text
            keyCurso = dgCapacitacion.Item("cl_cod_curso", dgCapacitacion.CurrentRow.Index).Value.ToString.Trim
            keyFechaInicio = dgCapacitacion.Item("cl_inicio", dgCapacitacion.CurrentRow.Index).Value

            If MessageBox.Show("¿Está seguro de querer borrar el curso " & keyCurso & " al empleado " & keyReloj & "?", "Borrar ajustes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                sqlExecute("DELETE FROM cursos_empleado WHERE reloj = '" & keyReloj & "' AND cod_curso = '" & keyCurso & _
                           "' AND inicio = '" & FechaSQL(keyFechaInicio) & "'", "capacitacion")
            End If

            MostrarInformacion()
        Catch ex As Exception
            MessageBox.Show("El ajuste no pudo ser borrado. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
    End Sub

    Private Sub dgCapacitacion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCapacitacion.CellDoubleClick
        btnEditar.PerformClick()
    End Sub

    '==Modificado       14sep2021       Ernesto
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtCapa As New DataTable
        'Dim dtPlan As New DataTable

        '==Se agrega la fecha de alta del empleado      1sep2021
        Dim dtAlta As New DataTable
        Dim fAlta As String = ""
        dtAlta = sqlExecute("select alta from personal.dbo.personal where reloj='" & txtReloj.Text & "'")
        Try
            If dtAlta.Rows.Count > 0 Then fAlta = FechaSQL(dtAlta.Rows(0)("alta"))
        Catch ex As Exception
            fAlta = ""
        End Try
        '==

        dtCapa = sqlExecute("SELECT '" & txtReloj.Text & "' AS RELOJ, (SELECT TOP 1 NOMBRES FROM CAPACITACION.dbo.cursos_empleadoVW WHERE RELOJ = '" & txtReloj.Text & "') AS 'NOMBRES', " & _
                            "(SELECT TOP 1 NOMBRE_PUESTO FROM CAPACITACION.dbo.cursos_empleadoVW WHERE RELOJ = '" & txtReloj.Text & "') AS 'NOMBRE_PUESTO', " &
                            "(SELECT TOP 1 NOMBRE_DEPTO FROM CAPACITACION.dbo.cursos_empleadoVW WHERE RELOJ = '" & txtReloj.Text & "') AS 'NOMBRE_DEPTO', " &
                            "cursos_empleado.cod_curso, RTRIM(cursos.NOMBRE) as nombre_curso, cursos_empleado.cod_instituto," &
                            "RTRIM(institutos.NOMBRE) as nombre_instituto, cursos_empleado.cod_instructor, RTRIM(instructores.NOMBRE) as nombre_instructor, " &
                            "inicio, fin, CASE WHEN calificacion IS NULL OR CALIFICACION = '' THEN '' ELSE 'CM' END AS 'calificacion', aprobado, RTRIM(cursos_empleado.comentario) AS comentario, cursos_empleado.duracion  as duracion " &
                            "FROM cursos_empleado " &
                            "LEFT JOIN cursos ON cursos_empleado.COD_CURSO = cursos.COD_CURSO LEFT JOIN institutos ON " &
                            "cursos_empleado.COD_INSTITUTO = institutos.COD_INSTITUTO LEFT JOIN instructores ON " &
                            "cursos_empleado.cod_instructor = instructores.cod_instructor where reloj ='" & txtReloj.Text & "'" &
                            " AND aplicado = 1 " &
                            "ORDER BY inicio DESC,fin,cod_curso ", "Capacitacion")

        'dtPlan = sqlExecute("SELECT planeacion_empleados.cod_curso,cursos.nombre,ano,mes,obligatorio, " & _
        '                          "CASE WHEN fecha_curso IS NULL THEN 'PL' ELSE 'CM' END AS cursado,fecha_curso,usuario,fecha_captura,fecha_maxima " & _
        '                          "FROM planeacion_empleados LEFT JOIN cursos ON planeacion_empleados.cod_curso = cursos.cod_curso " & _
        '                          "WHERE RELOJ = '" & txtReloj.Text & "' ORDER BY ano DESC,mes,planeacion_empleados.cod_curso", _
        '                          "capacitacion")

        '== Agregar columna alta                1-sep-21
        dtCapa.Columns.Add("alta")

        For Each x As DataRow In dtCapa.Rows
            x.Item("alta") = fAlta
        Next
        '==

        'Dim Contador As Integer = 1
        'Dim a As Integer = dtCapa.Rows.Count

        Try
            'For i As Integer = 0 To dtPlan.Rows.Count - 1
            '    Dim row As DataRow = dtCapa.NewRow()
            '    'dtCapa.Rows.Add()
            '    ' dtCapa.Rows(dtCapa.Rows.Count - 1).Item("cod_curso").value = dtPlan.Rows(i).Item("cod_curso").ToString.Trim
            '    row("RELOJ") = txtReloj.Text
            '    row("NOMBRES") = dtCapa.Rows(0).Item("NOMBRES").ToString.Trim
            '    row("NOMBRE_PUESTO") = dtCapa.Rows(0).Item("NOMBRE_PUESTO").ToString.Trim
            '    row("NOMBRE_DEPTO") = dtCapa.Rows(0).Item("NOMBRE_DEPTO").ToString.Trim
            '    row("cod_instituto") = dtCapa.Rows(0).Item("cod_instituto").ToString.Trim
            '    row("nombre_instituto") = dtCapa.Rows(0).Item("nombre_instituto").ToString.Trim
            '    row("cod_curso") = dtPlan.Rows(i).Item("cod_curso").ToString.Trim
            '    row("nombre_curso") = dtPlan.Rows(i).Item("nombre").ToString.Trim
            '    row("inicio") = CDate(dtPlan.Rows(i).Item("fecha_captura").ToString.Trim)
            '    row("fin") = CDate(dtPlan.Rows(i).Item("fecha_maxima").ToString.Trim)
            '    row("calificacion") = dtPlan.Rows(i).Item("cursado").ToString.Trim
            '    row("aprobado") = 1

            '    dtCapa.Rows.Add(row)
            'Next

            frmVistaPrevia.LlamarReporte("Matriz Capacitacion Empleado", dtCapa)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    '==Certificar curso seleccionado        julio2021       Ernesto
    Private Sub btnCertificar_Click(sender As Object, e As EventArgs) Handles btnCertificar.Click
        Try

            frmCertificaCurso.txtReloj.Text = txtReloj.Text.ToString.Trim
            frmCertificaCurso.nombre_empleado = nombre_completo
            frmCertificaCurso.fecha_alta = FechaSQL(txtAlta.Value)
            frmCertificaCurso.cod_puesto = cod_puesto
            frmCertificaCurso.ShowDialog()
            ValidarCertificacion(txtReloj.Text.ToString.Trim, nombre_completo, FechaSQL(txtAlta.Value))

        Catch ex As Exception

        End Try
    End Sub

    '==Corroborar si esta certificado       julio2021       Ernesto
    Private Sub ValidarCertificacion(clock As String, nom As String, alta As String)
        Try
            '==Puesto de empleado
            btnCertificar.Enabled = True
            Dim dtValida As DataTable
            Dim puesto As String = "select RELOJ,rtrim(COD_PUESTO) as cod_puesto,nombre_puesto,baja from personal.dbo.personalvw where RELOJ='" & clock & "'"
            dtValida = sqlExecute(puesto)

            If Not dtValida.Rows(0)("baja") Is DBNull.Value Then
                'Label9.BackColor = Color.DarkGray
                'Label9.Text = "DADO DE BAJA"
                'pnlDatosCertificacion.BackColor = Color.Silver
                'btnCertificar.Enabled = False
            Else
                Try : puesto = dtValida.Rows(0)("cod_puesto").ToString : Catch ex As Exception : puesto = "" : End Try

                cod_puesto = puesto

                '==Si esta certificado
                Dim valida As String = "select * from capacitacion.dbo.certi where reloj='" & clock & "' and nombres='" & nom & "' and alta='" & alta & "' and cod_puesto='" & puesto & "' and aprobado='1'"
                dtValida = sqlExecute(valida)

                If dtValida.Rows.Count > 0 Then
                    'Label9.BackColor = Color.DarkGreen
                    'Label9.Text = "CERTIFICADO"
                    'pnlDatosCertificacion.BackColor = Color.Green
                Else
                    valida = "select reloj,alta,DATEDIFF(MONTH,ALTA,GETDATE()) as dif_meses from personal.dbo.personal where reloj='" & clock & "'"
                    dtValida = sqlExecute(valida)

                    If dtValida.Rows(0)("dif_meses") >= 3 Then
                        'Label9.BackColor = Color.DarkRed
                        'Label9.Text = "VENCIDO"
                        'pnlDatosCertificacion.BackColor = Color.IndianRed
                    Else
                        'Label9.BackColor = Color.Goldenrod
                        'Label9.Text = "EN TIEMPO"
                        'pnlDatosCertificacion.BackColor = Color.Gold
                    End If
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ValidarRecertificacion(clock As String, nom As String, alta As String)
        Dim recerti As Integer = 0, fecha_certificacion As Date, diaHoy As Date = Date.Now()
        Try
            '==Puesto de empleado
            btnRecertif.Enabled = True
            Dim dtValida As DataTable
            Dim puesto As String = "select RELOJ,rtrim(COD_PUESTO) as cod_puesto,nombre_puesto,baja from personal.dbo.personalvw where RELOJ='" & clock & "'"
            dtValida = sqlExecute(puesto)

            If Not dtValida.Rows(0)("baja") Is DBNull.Value Then
                'lblRecertif.BackColor = Color.DarkGray
                'lblRecertif.Text = "DADO DE BAJA"
                'pnlRecertifica.BackColor = Color.Silver
                'btnRecertif.Enabled = False
            Else
                Try : puesto = dtValida.Rows(0)("cod_puesto").ToString : Catch ex As Exception : puesto = "" : End Try

                cod_puesto = puesto

                '==Si esta certificado
                Dim valida As String = "select * from capacitacion.dbo.certi where reloj='" & clock & "' and nombres='" & nom & "' and alta='" & alta & "' and cod_puesto='" & puesto & "' and aprobado='1'"
                dtValida = sqlExecute(valida)

                If dtValida.Rows.Count > 0 Then
                    lblRecertif.Visible = True
                    pnlRecertifica.Visible = True
                    btnRecertif.Visible = True

                    Try : recerti = (dtValida.Rows(0).Item("recerti")) : Catch ex As Exception : recerti = 0 : End Try
                    Try : fecha_certificacion = Date.Parse(FechaSQL((dtValida.Rows(0).Item("inicio")))) : Catch ex As Exception : fecha_certificacion = Nothing : End Try

                    If (recerti = 1) Then '1-- Validar si ya está recertificado (recerti=1)
                        'lblRecertif.BackColor = Color.DarkGreen
                        'lblRecertif.Text = "RE-CERTIFICADO"
                        'pnlRecertifica.BackColor = Color.Green
                    Else
                        '2-- Si no esta recertif, en base a su fecha de certif (inicio), validar que tenga <=12 para estar a tiempo (amarillo)
                        Dim difDias As Integer = DateDiff(DateInterval.Day, fecha_certificacion, diaHoy) + 1
                        If difDias <= 365 Then
                            'lblRecertif.BackColor = Color.Goldenrod
                            'lblRecertif.Text = "EN TIEMPO"
                            'pnlRecertifica.BackColor = Color.Gold
                        Else '3-- Si es > 12 meses, mostrar que ya esta VENCIDO (color Rojo)
                            'lblRecertif.BackColor = Color.DarkRed
                            'lblRecertif.Text = "VENCIDO"
                            'pnlRecertifica.BackColor = Color.IndianRed
                        End If

                    End If

                Else
                    '4-- Si  dtValida.Rows.Count <=0, no mostrar el boton de recertif ya que debe de estar primero certificado
                    lblRecertif.Visible = False
                    pnlRecertifica.Visible = False
                    btnRecertif.Visible = False
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    '==Si se le da click al boton de eliminar de la fila            14sep2021           Ernesto
    Private Sub dgPlaneados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPlaneados.CellContentClick
        Try
            If e.RowIndex < 0 Then
                Exit Sub
            End If

            Dim grid = DirectCast(sender, DataGridView)

            If TypeOf grid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If grid.Columns(e.ColumnIndex).Name = "colBorrar" Then

                    Dim indice As Integer = e.RowIndex

                    Dim _nomCurso As String = dgPlaneados.Rows(indice).Cells(1).Value & " " & dgPlaneados.Rows(indice).Cells(2).Value.ToString.Trim

                    If MessageBox.Show("¿Desea eliminar el siguiente curso planeado?" & vbNewLine & vbNewLine &
                                       _nomCurso, "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                        Dim camposValores(5) As String : Dim _var As String = "" : Dim cont As Integer = 0

                        '==Se obtienen los valores de los campos que se van eliminar            14sep2021
                        For i As Integer = 1 To dgPlaneados.ColumnCount - 1
                            If dgPlaneados.Columns(i).Name = "plCodCurso" Or dgPlaneados.Columns(i).Name = "plAno" Or dgPlaneados.Columns(i).Name = "plMes" Or
                                dgPlaneados.Columns(i).Name = "plFechaMaxima" Or dgPlaneados.Columns(i).Name = "plFechaCaptura" Then
                                _var = dgPlaneados.Rows(indice).Cells(dgPlaneados.Columns(i).Name).Value
                                camposValores(cont) = dgPlaneados.Columns(i).DataPropertyName & "," & _var
                                cont += 1
                            End If
                        Next

                        '==Confirmación de eliminación                      15sep21
                        camposValores(5) = "reloj," & txtReloj.Text.Trim
                        Dim _query As String = "delete from capacitacion.dbo.planeacion_empleados where "
                        Dim _sum As Integer = 0

                        For Each x As String In camposValores
                            cont = 0
                            Dim cadena() As String = Split(x, ",")

                            If _sum >= camposValores.Length - 1 Then
                                _query = _query & cadena(cont) & "='" & cadena(cont + 1) & "'"
                                sqlExecute(_query)
                                MessageBox.Show("Se ha eliminado el registro seleccionado", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                MostrarInformacion()
                                Exit For
                            End If

                            If cadena(cont) <> "fecha_captura" And cadena(cont) <> "fecha_maxima" Then
                                _query = _query & cadena(cont) & "='" & cadena(cont + 1) & "' and "
                            Else
                                _query = _query & cadena(cont) & "='" & FechaSQL(cadena(cont + 1)) & "' and "
                            End If
                            _sum += 1
                        Next
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Botón que se encarga de traspasar el historial de cursos de un empleado dado de baja a uno activo.
    ''' Ernesto G.  -- 16Junio22
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTraspasar_Click(sender As Object, e As EventArgs) Handles btnTraspasar.Click
        Try
            Dim TraspasarCurso As frmPasarCursos = New frmPasarCursos()
            TraspasarCurso._strRelojEmp = txtReloj.Text.Trim
            TraspasarCurso._strNombreEmp = txtNombre.Text.Trim & " " & txtApaterno.Text.Trim & " " & txtAmaterno.Text.Trim
            TraspasarCurso._strPuestoEmp = puesto
            TraspasarCurso._strEstatusEmp = IIf(lblEstado.Text.Trim = "ACTIVO", "Activo", IIf(lblEstado.Text.Trim = "INACTIVO", "Inactivo", ""))
            TraspasarCurso._strRutaFoto = ArchivoFoto

            TraspasarCurso.Show()
            'TraspasarCurso.BringToFront()
            'TraspasarCurso.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRecertif_Click(sender As Object, e As EventArgs) Handles btnRecertif.Click
        Try

            frmRecertificaCurso.txtReloj.Text = txtReloj.Text.ToString.Trim
            frmRecertificaCurso.nombre_empleado = nombre_completo
            frmRecertificaCurso.fecha_alta = FechaSQL(txtAlta.Value)
            frmRecertificaCurso.cod_puesto = cod_puesto
            frmRecertificaCurso.ShowDialog()
            ValidarRecertificacion(txtReloj.Text.ToString.Trim, nombre_completo, FechaSQL(txtAlta.Value))

        Catch ex As Exception

        End Try
    End Sub
End Class
