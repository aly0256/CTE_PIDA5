Public Class frmKardexAcd
    Dim dtCalendario As New DataTable
    Dim dtPersonal As New DataTable

    Dim FAlta As Date
    Dim FBaja As Date
    Dim CX As Integer
    Dim RY As Integer

    Private Sub frmKardexAn_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape And pnlAccdisciplina.Visible Then
            tmrDelay.Enabled = False
            pnlAccdisciplina.Visible = False
        End If
    End Sub

    Private Function CrearCalendario() As Boolean
        Try
            Dim D As Integer
            Dim Columnas(35) As DataColumn

            dtCalendario = New DataTable("Calendario")
            Columnas(0) = New DataColumn("MES")
            Columnas(0).DataType = System.Type.GetType("System.String")

            For D = 1 To 31
                Columnas(D) = New DataColumn(D)
                Columnas(D).DataType = System.Type.GetType("System.String")
            Next

            Columnas(32) = New DataColumn("COLOR_LETRA")
            Columnas(32).DataType = System.Type.GetType("System.String")
            Columnas(33) = New DataColumn("COLOR_FONDO")
            Columnas(33).DataType = System.Type.GetType("System.String")
            Columnas(34) = New DataColumn("DESCRIPCION")
            Columnas(34).DataType = System.Type.GetType("System.String")
            Columnas(35) = New DataColumn("FECHA")
            Columnas(35).DataType = System.Type.GetType("System.DateTime")

            For x = 0 To UBound(Columnas)
                dtCalendario.Columns.Add(Columnas(x))
            Next

            dgCalendario.DataSource = dtCalendario

            For x = 1 To 31
                dgCalendario.Columns(x).Width = 28
                dgCalendario.Columns(x).SortMode = DataGridViewColumnSortMode.NotSortable
                dgCalendario.Columns(x).DefaultCellStyle.Font = New Font("DIA", 6)
            Next

            dgCalendario.Columns(32).Visible = False
            dgCalendario.Columns(33).Visible = False
            dgCalendario.Columns(34).Visible = False
            dgCalendario.Columns(35).Visible = False
            dgCalendario.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            dgCalendario.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtCalendario.Rows.Add("ENERO")
            dtCalendario.Rows.Add("FEBRERO")
            dtCalendario.Rows.Add("MARZO")
            dtCalendario.Rows.Add("ABRIL")
            dtCalendario.Rows.Add("MAYO")
            dtCalendario.Rows.Add("JUNIO")
            dtCalendario.Rows.Add("JULIO")
            dtCalendario.Rows.Add("AGOSTO")
            dtCalendario.Rows.Add("SEPTIEMBRE")
            dtCalendario.Rows.Add("OCTUBRE")
            dtCalendario.Rows.Add("NOVIEMBRE")
            dtCalendario.Rows.Add("DICIEMBRE")

            For x = 0 To dgCalendario.Rows.Count - 1
                dgCalendario.Rows(x).Height = 24
            Next
            dgCalendario.Columns(0).DefaultCellStyle.Font = New Font("MES", 10, FontStyle.Bold)
            dgCalendario.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            dgCalendario.GridColor = pnlKardex.BackColor
            dgCalendario.BackgroundColor = pnlKardex.BackColor
            dgCalendario.Refresh()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub cmbAno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAno.SelectedIndexChanged
        ActualizaKardex()
    End Sub

    Private Sub ActualizaKardex()
        Dim dtInfo As New DataTable
        Dim DM As Integer
        Dim M As Integer
        Dim D As Integer
        Dim R As String
        Dim CodAcc As String = ""
        Dim Fecha As Date
        Try
            R = txtReloj.Text
            If R = "" Then Exit Sub
            dtInfo = sqlExecute("SELECT fecha,COD_TIPO_ACCION FROM accion_disciplinaria WHERE reloj = '" & R & "'", "PERSONAL")

            If dtInfo.Rows.Count > 0 Then
                CodAcc = dtInfo.Rows(0).Item("COD_TIPO_ACCION")
            End If
            'dgCalendario.GridColor = SystemColors.Control
            For M = 0 To 11
                DM = System.DateTime.DaysInMonth(cmbAno.SelectedValue, M + 1)
                For D = 1 To 31
                    If D > DM Then
                        'Si el día es mayor al número de días del mes, "ocultar" la celda mediante el color 
                        dgCalendario.Item(D, M).Style.BackColor = dgCalendario.GridColor
                        dgCalendario.Item(D, M).ToolTipText = ""
                    Else
                        'Asistencia general
                        Fecha = DateSerial(cmbAno.SelectedValue, M + 1, D)
                        If Fecha > Now.Date Then
                            dgCalendario.Item(D, M).Style.BackColor = dgCalendario.GridColor
                            dgCalendario.Item(D, M).Value = ""
                            dgCalendario.Item(D, M).ToolTipText = ""
                        ElseIf Fecha < FAlta Or Fecha > FBaja Then
                            dgCalendario.Item(D, M).Style.BackColor = SystemColors.ControlDark
                            dgCalendario.Item(D, M).ToolTipText = "Inactivo"
                            dgCalendario.Item(D, M).Value = ""
                            'ElseIf Festivo(Fecha, R) Then
                            '   dgCalendario.Item(D, M).Style.BackColor = Color.FromArgb(GetColorFondoDisip(CodAcc))
                            '  dgCalendario.Item(D, M).Style.ForeColor = Color.FromArgb(GetColorLetraDisip(CodAcc))
                            ' dgCalendario.Item(D, M).ToolTipText = "Acción Disciplinaria"
                            'dgCalendario.Item(D, M).Value = CodAcc
                        Else
                            dgCalendario.Item(D, M).Style.BackColor = dgCalendario.Item(0, M).Style.BackColor
                            dgCalendario.Item(D, M).ToolTipText = "Asistencia"
                            dgCalendario.Item(D, M).Value = ""
                        End If
                    End If
                Next
            Next

            'Revisar Acción Disciplinaria
            dtInfo = sqlExecute("SELECT fecha,accion_disciplinariaVW.COD_TIPO_ACCION,tipo_disciplinaria.TIPO_ACCION_DISCIPLINARIA " & _
                                "FROM PersonalVW LEFT JOIN accion_disciplinariaVW ON PersonalVW.RELOJ=accion_disciplinariaVW.reloj LEFT JOIN tipo_disciplinaria ON accion_disciplinariaVW.COD_TIPO_ACCION = tipo_disciplinaria.COD_TIPO_ACCION " & _
                                "WHERE PersonalVW.reloj = '" & R & "' and YEAR(fecha) = " & Fecha.Year, "Personal")

            For x = 0 To dtInfo.Rows.Count - 1
                D = dtInfo.Rows(x).Item("fecha").Day
                M = dtInfo.Rows(x).Item("fecha").Month - 1
                dgCalendario.Item(D, M).ToolTipText = dtInfo.Rows(x).Item("TIPO_ACCION_DISCIPLINARIA")
                dgCalendario.Item(D, M).Style.BackColor = Color.FromArgb(GetColorFondoDisip(dtInfo.Rows(x).Item("COD_TIPO_ACCION")))
                dgCalendario.Item(D, M).Style.ForeColor = Color.FromArgb(GetColorLetraDisip(dtInfo.Rows(x).Item("COD_TIPO_ACCION")))
                dgCalendario.Item(D, M).Value = dtInfo.Rows(x).Item("COD_TIPO_ACCION")

            Next


            dtInfo = sqlExecute(" select reloj, fecha, ausentismo.tipo_aus, tipo_ausentismo.NOMBRE from ausentismo left join tipo_ausentismo on ausentismo.TIPO_AUS = tipo_ausentismo.TIPO_AUS " & _
                            "where RELOJ = '" & R & "' and ausentismo.TIPO_AUS = 'SUS' and YEAR(FECHA) = '" & Fecha.Year & "'", "TA")

            For x = 0 To dtInfo.Rows.Count - 1
                D = dtInfo.Rows(x).Item("fecha").Day
                M = dtInfo.Rows(x).Item("fecha").Month - 1
                dgCalendario.Item(D, M).ToolTipText = dtInfo.Rows(x).Item("NOMBRE")
                dgCalendario.Item(D, M).Style.BackColor = Color.MediumPurple
                dgCalendario.Item(D, M).Style.ForeColor = Color.Black
                dgCalendario.Item(D, M).Value = "SUS"

            Next
        Catch ex As Exception
            Debug.Print("Error en kárdex" & ex.Message)
        End Try
    End Sub

    Private Sub dgCalendario_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCalendario.CellClick
        ActualizarInformacionPanel(e.ColumnIndex, e.RowIndex)
    End Sub

    Private Sub dgCalendario_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgCalendario.CellEnter
        ActualizarInformacionPanel(e.ColumnIndex, e.RowIndex)
    End Sub

    Private Sub ActualizarInformacionPanel(X As Integer, Y As Integer)
        Dim Fecha As Date
        Dim Dato As String
        Dim CodMotivo As String = ""
        Dim R As String
        Try
            pnlAccdisciplina.Visible = False
            tmrDelay.Enabled = False
            'Si no hay renglón o columna seleccionados, o la columna es la del mes, salir de la rutina
            If Y < 0 Or X < 1 Then
                Exit Sub
            End If

            'Tomar los valores de acuerdo a la celda
            Fecha = DateSerial(cmbAno.SelectedValue, Y + 1, X)
            Dato = IIf(IsDBNull(dgCalendario.Item(X, Y).Value), "", dgCalendario.Item(X, Y).Value)
            Dato = Dato.Trim
            lblDato.Text = "<b>" & FechaLetra(Fecha) & "</b>"
            'Determinar qué código de Acción disciplinaria correspondiente
            R = txtReloj.Text
            If Dato <> "" And Dato <> "SUS" Then
                'Si el detalle del día corresponde a la Acción disciplinaria
                dtTemporal = sqlExecute("SELECT tipo_accion_disciplinaria FROM tipo_disciplinaria WHERE COD_TIPO_ACCION = '" & Dato & "'", "PERSONAL")
                If dtTemporal.Rows.Count > 0 Then
                    If Not IsDBNull(dtTemporal.Rows(0).Item("tipo_accion_disciplinaria")) Then
                        If dtTemporal.Rows(0).Item("tipo_accion_disciplinaria").ToString.Trim.Length > 0 Then
                            Dato = "Acción disciplinaria " & Dato & vbCrLf & dtTemporal.Rows(0).Item("tipo_accion_disciplinaria")
                        End If
                    End If
                End If
                lblTexto.Text = Dato.Trim
            ElseIf Dato = "SUS" Then
                'Si el detalle corresponde a un retardo
                lblTexto.Text = "Suspensión Administrativa"
            ElseIf Dato = "R" Then
                'Si el detalle corresponde a un retardo
                lblTexto.Text = dgCalendario.Item(X, Y).ToolTipText.Trim
            ElseIf Dato = "SA" Then
                'Si el detalle corresponde a un retardo
                lblTexto.Text = dgCalendario.Item(X, Y).ToolTipText.Trim

            ElseIf Fecha >= FBaja And Fecha <= Now.Date Then
                'Si la fecha seleccionada es posterior a la fecha de baja
                lblTexto.Text = "INACTIVO" & vbCrLf & "Baja el día " & FBaja
            ElseIf Fecha < FAlta And Fecha <= Now.Date Then
                'Si la fecha seleccionada es anterior a la fecha de alta
                lblTexto.Text = "INACTIVO" & vbCrLf & "Alta el día " & FAlta
            ElseIf Dato = "" And Fecha <= Now.Date Then
                'Si el detalle está en blanco, debe ser asistencia
                dtTemporal = sqlExecute("SELECT dia_entro,dia_salio,entro,salio,comentario FROM asist WHERE reloj= '" & R & "' AND fecha_entro = '" & FechaSQL(Fecha) & "'", "TA")
                If dtTemporal.Rows.Count > 0 Then
                    'Si se encuentra información de la fecha en tabla Asist, desplegarla
                    Dato = "ASISTENCIA" & vbCrLf & "Entrada - " & dtTemporal.Rows(0).Item("dia_entro").ToString.Trim & " " & dtTemporal.Rows(0).Item("entro") & vbCrLf
                    Dato = Dato & "Salida - " & dtTemporal.Rows(0).Item("dia_salio").ToString.Trim & " " & dtTemporal.Rows(0).Item("salio") & vbCrLf

                    If Not IsDBNull(dtTemporal.Rows(0).Item("comentario")) Then
                        Dato = Dato & vbCrLf & vbCrLf & dtTemporal.Rows(0).Item("comentario")
                    End If
                    lblTexto.Text = Dato.Trim
                Else
                    If DiaDescanso(Fecha) Then
                        'Si no se encontró información en tabla Asist, revisar si fue día de descanso
                        lblTexto.Text = DiaSem(Fecha).ToUpper & vbCrLf & "Día de descanso"
                    Else
                        'Si no fue descanso, y no hay información en Asist, indicar que no hay detalle
                        lblTexto.Text = "ASISTENCIA" & vbCrLf & "Sin detalle"
                    End If
                End If
            Else
                tmrDelay.Enabled = False
                pnlAccdisciplina.Visible = False
                Exit Sub
            End If

            'Si el día es mayor a 25, o el mes después de septiembre, el panel no cabe, hay que colocarlo arriba y/o a la izquierda de la celda
            If X > 25 Then X = X - 6
            If Y > 8 Then Y = Y - 3

            'Ubicar el panel de acuerdo a la celda seleccionada
            pnlAccdisciplina.Left = dgCalendario.GetCellDisplayRectangle(X, Y, True).Location.X + dgCalendario.Left + 15
            pnlAccdisciplina.Top = dgCalendario.GetCellDisplayRectangle(X, Y, True).Location.Y + dgCalendario.Top + 15

            'Habilitar el timer que cierra el panel, y poner el panel visible
            tmrDelay.Enabled = True
            pnlAccdisciplina.Visible = True

        Catch ex As Exception
            'Inhabilitar el timer que cierra el panel, y poner el panel invisible
            tmrDelay.Enabled = False
            pnlAccdisciplina.Visible = False
        End Try
    End Sub

    Private Sub btnCerrarPanel_Click(sender As Object, e As EventArgs) Handles btnCerrarPanel.Click
        pnlAccdisciplina.Visible = False
        tmrDelay.Enabled = False
    End Sub
    Public Sub MostrarInformacion(ByVal rl As String)
        Dim dtInfo As New DataTable
        Dim ArchivoFoto As String
        Dim Comp As String
        Dim dtTemp As New DataTable
        Try
            If rl <> "" Then
                dtInfo = ConsultaPersonalVW("SELECT * from personalvw WHERE reloj = '" & rl & "'")

            Else
                dtInfo = ConsultaPersonalVW("SELECT TOP 1 * from personalvw ORDER BY reloj")
                rl = IIf(IsDBNull(dtInfo.Rows.Item(0).Item("reloj")), "", dtInfo.Rows.Item(0).Item("reloj"))
            End If

            With dtInfo.Rows.Item(0)
                Comp = IIf(IsDBNull(.Item("cod_comp")), "", .Item("cod_comp"))

                txtReloj.Text = IIf(IsDBNull(.Item("reloj")), "", .Item("reloj"))
                txtNombre.Text = IIf(IsDBNull(.Item("nombres")), "", .Item("nombres"))
                'txtApaterno.Text = IIf(IsDBNull(.Item("apaterno")), "", .Item("apaterno"))
                'txtAmaterno.Text = IIf(IsDBNull(.Item("amaterno")), "", .Item("amaterno"))

                txtAlta.Value = IIf(IsDBNull(.Item("alta")), Nothing, .Item("alta"))
                EsBaja = Not IsDBNull(.Item("baja"))
                txtBaja.Value = IIf(EsBaja, .Item("baja"), Nothing)

                Reingreso = (IIf(IsDBNull(.Item("reingreso")), 0, .Item("reingreso")) = 1)
                lblReingreso.Visible = Reingreso

                txtCia.Text = IIf(IsDBNull(.Item("cod_comp")), "", .Item("cod_comp").ToString.Trim) & _
                    IIf(IsDBNull(.Item("compania")), "", " (" & .Item("compania").ToString.Trim & ")")

                txtArea.Text = IIf(IsDBNull(.Item("cod_area")), "", .Item("cod_area").ToString.Trim) & _
                    IIf(IsDBNull(.Item("nombre_area")), "", " (" & .Item("nombre_area").ToString.Trim & ")")

                txtTipoEmp.Text = IIf(IsDBNull(.Item("cod_tipo")), "", .Item("cod_tipo").ToString.Trim) & _
                    IIf(IsDBNull(.Item("nombre_tipoemp")), "", " (" & .Item("nombre_tipoemp").ToString.Trim & ")")

                txtDepto.Text = IIf(IsDBNull(.Item("cod_depto")), "", .Item("cod_depto").ToString.Trim) & _
                    IIf(IsDBNull(.Item("nombre_depto")), "", " (" & .Item("nombre_depto").ToString.Trim & ")")

                txtSupervisor.Text = IIf(IsDBNull(.Item("cod_super")), "", .Item("cod_super").ToString.Trim) & _
                    IIf(IsDBNull(.Item("nombre_super")), "", " (" & .Item("nombre_super").ToString.Trim & ")")

                txtClase.Text = IIf(IsDBNull(.Item("cod_clase")), "", .Item("cod_clase").ToString.Trim) & _
                    IIf(IsDBNull(.Item("nombre_clase")), "", " (" & .Item("nombre_clase").ToString.Trim & ")")

                txtTurno.Text = IIf(IsDBNull(.Item("cod_turno")), "", .Item("cod_turno").ToString.Trim) & _
                    IIf(IsDBNull(.Item("nombre_turno")), "", " (" & .Item("nombre_turno").ToString.Trim & ")")

                txtHorario.Text = IIf(IsDBNull(.Item("cod_hora")), "", .Item("cod_hora").ToString.Trim) & _
                    IIf(IsDBNull(.Item("nombre_horario")), "", " (" & .Item("nombre_horario").ToString.Trim & ")")

                txtplanta.Text = IIf(IsDBNull(.Item("cod_planta")), "", .Item("cod_planta").ToString.Trim) & _
                    IIf(IsDBNull(.Item("nombre_planta")), "", " (" & .Item("nombre_planta").ToString.Trim & ")")

                FAlta = .Item("alta")
                FBaja = IIf(IsDBNull(.Item("baja")), DateSerial(9999, 12, 31), .Item("baja"))

            End With

            ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
            Try
                ArchivoFoto = PathFoto & rl.Trim & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    ArchivoFoto = PathFoto & "nofoto.png"
                End If

                'Dim ft As New Bitmap(ArchivoFoto)
                picFoto.Width = picFoto.MinimumSize.Width
                picFoto.Height = picFoto.MinimumSize.Height
                picFoto.Left = 900
                'picFoto.Image = ft
                picFoto.ImageLocation = ArchivoFoto
            Catch
                picFoto.Image = picFoto.ErrorImage
            End Try

            '****************************************

            '*** Cambios en bajas ****
            txtBaja.Visible = EsBaja
            lblBaja.Visible = EsBaja
            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtReloj.BackColor = lblEstado.BackColor

            lblReingreso.Visible = Not EsBaja And Reingreso
            '*************************
            ActualizaKardex()

            Exit Sub
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Dim reloj As String
        reloj = txtReloj.Text
        dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw ORDER BY reloj ASC")
        reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
        MostrarInformacion(reloj)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Dim reloj As String
        reloj = txtReloj.Text
        dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw WHERE reloj <'" & reloj & "' ORDER BY reloj DESC")
        If dtPersonal.Rows.Count < 1 Then
            btnFirst.PerformClick()
        Else
            reloj = dtPersonal.Rows.Item(0).Item("RELOJ")

            MostrarInformacion(reloj)
        End If
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim reloj As String
        reloj = txtReloj.Text
        dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw WHERE reloj >'" & reloj & "' ORDER BY reloj ASC")
        If dtPersonal.Rows.Count < 1 Then
            btnLast.PerformClick()
        Else
            reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
            MostrarInformacion(reloj)
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Dim reloj As String
        reloj = txtReloj.Text
        dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw ORDER BY reloj DESC")

        'EmpIdx = dtPersonal.Rows.Count - 1
        reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
        MostrarInformacion(reloj)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim dtTemp As New DataTable
        dtTemp = dtPersonal
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtPersonal = dtTemp
        End Try
    End Sub

    Private Sub frmKardexAn_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        MostrarInformacion(txtReloj.Text)
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            dtFiltroPersonal = ConsultaPersonalVW("SELECT * FROM personalvw WHERE reloj = '" & txtReloj.Text & "'")
            frmVistaPrevia.LlamarReporte("KardexAnual Acciones Disciplinarias", dtFiltroPersonal, "", {cmbAno.Text, txtReloj.Text})
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmKardexAn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim dtPersonal As New DataTable
        Dim dtAños As New DataTable
        Try
            dtAños = sqlExecute("SELECT DISTINCT ano FROM periodos ORDER BY ano DESC", "TA")
            cmbAno.DataSource = dtAños

            CrearCalendario()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnPeriodoAnterior_Click(sender As Object, e As EventArgs) Handles btnPeriodoAnterior.Click
        Try
            Dim ano As Integer = cmbAno.SelectedValue
            ano -= 1
            cmbAno.SelectedValue = ano
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPeriodoSiguiente_Click(sender As Object, e As EventArgs) Handles btnPeriodoSiguiente.Click
        Try
            Dim ano As Integer = cmbAno.SelectedValue
            ano -= 1
            cmbAno.SelectedValue = ano
        Catch ex As Exception

        End Try
    End Sub
End Class