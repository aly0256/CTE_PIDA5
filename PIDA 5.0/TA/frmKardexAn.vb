Public Class frmKardexAn
    Dim dtCalendario As New DataTable
    Dim dtPersonal As New DataTable
    Dim dtNavegacion As New DataTable           '== 3mayo2022       Ernesto


    Dim FAlta As Date
    Dim FBaja As Date
    Dim CX As Integer
    Dim RY As Integer

    Private Sub frmKardexAn_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape And pnlAusentismo.Visible Then
            tmrDelay.Enabled = False
            pnlAusentismo.Visible = False
        ElseIf e.KeyCode = Keys.F12 Then
            btnBuscar.PerformClick()
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
        Dim CodFestivo As String = ""
        Dim Fecha As Date
        Try
            R = txtReloj.Text
            If R = "" Then Exit Sub
            dtInfo = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE UPPER(nombre) LIKE ('%FESTIVO')", "TA")
            If dtInfo.Rows.Count > 0 Then
                CodFestivo = dtInfo.Rows(0).Item("tipo_aus")
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
                            '    dgCalendario.Item(D, M).Style.BackColor = Color.FromArgb(GetColorFondo(CodFestivo))
                            '    dgCalendario.Item(D, M).Style.ForeColor = Color.FromArgb(GetColorLetra(CodFestivo))
                            '    dgCalendario.Item(D, M).ToolTipText = "Festivo"
                            '    dgCalendario.Item(D, M).Value = CodFestivo
                        Else
                            dgCalendario.Item(D, M).Style.BackColor = dgCalendario.Item(0, M).Style.BackColor
                            dgCalendario.Item(D, M).ToolTipText = "Asistencia"
                            dgCalendario.Item(D, M).Value = ""
                        End If
                    End If
                Next
            Next

            'Revisar retardo
            'INSERTAR EN TIPO DE AUSENTISMO, TIPO "R", PARA PERMITIR AL USUARIO MODIFICAR COLORES
            '*** RETARDOS Y SALIDAS ANTICIPADAS NO ENTRAN EN AUSENTISMO ***
            'dtInfo = sqlExecute("SELECT fecha_entro,al_des_ent,entro,salio FROM asist WHERE reloj = '" & R & "' AND al_des_ent<0 AND YEAR(fecha_entro) = " & Fecha.Year, "TA")
            dtInfo = sqlExecute("SELECT fecha_entro,entro,salio FROM asist WHERE reloj = '" & R & "' AND YEAR(fecha_entro) = '" & Fecha.Year & "' and UPPER(COMENTARIO) LIKE '%RETARDO%'", "TA")
            For Each dRow As DataRow In dtInfo.Rows
                D = dRow("fecha_entro").Day
                M = dRow("fecha_entro").Month - 1
                dgCalendario.Item(D, M).ToolTipText = "Retardo - Entró a las " & dRow("entro") & " y salió a las " & dRow("salio")

                dgCalendario.Item(D, M).Style.BackColor = Color.FromArgb(GetColorFondo("R"))
                dgCalendario.Item(D, M).Style.ForeColor = Color.FromArgb(GetColorLetra("R"))
                dgCalendario.Item(D, M).Value = "R"
            Next

            'Revisar salida anticipada
            'INSERTAR EN TIPO DE AUSENTISMO, TIPO "SA", PARA PERMITIR AL USUARIO MODIFICAR COLORES
            '*** RETARDOS Y SALIDAS ANTICIPADAS NO ENTRAN EN AUSENTISMO ***
            dtInfo = sqlExecute("SELECT fecha_entro,entro,salio FROM asist WHERE reloj = '" & R & "' AND YEAR(fecha_entro) = '" & Fecha.Year & "' and UPPER(COMENTARIO) LIKE '%SALIDA ANTICIPADA%'", "TA")
            For Each dRow As DataRow In dtInfo.Rows
                D = dRow("fecha_entro").Day
                M = dRow("fecha_entro").Month - 1
                dgCalendario.Item(D, M).ToolTipText = "Salida anticipada - Entró a las " & dRow("entro") & " y salió a las " & dRow("salio")

                dgCalendario.Item(D, M).Style.BackColor = Color.FromArgb(GetColorFondo("SA"))
                dgCalendario.Item(D, M).Style.ForeColor = Color.FromArgb(GetColorLetra("SA"))
                dgCalendario.Item(D, M).Value = "SA"
            Next

            'Revisar ausentismo
            dtInfo = sqlExecute("SELECT fecha,ausentismo.tipo_aus,tipo_ausentismo.nombre FROM ausentismo LEFT JOIN tipo_ausentismo ON ausentismo.tipo_aus=tipo_ausentismo.TIPO_AUS WHERE reloj = '" & R & "' and YEAR(fecha) = " & Fecha.Year, "TA")
            For x = 0 To dtInfo.Rows.Count - 1
                D = dtInfo.Rows(x).Item("fecha").Day
                M = dtInfo.Rows(x).Item("fecha").Month - 1
                dgCalendario.Item(D, M).ToolTipText = dtInfo.Rows(x).Item("nombre")
                dgCalendario.Item(D, M).Style.BackColor = Color.FromArgb(GetColorFondo(dtInfo.Rows(x).Item("tipo_aus")))
                dgCalendario.Item(D, M).Style.ForeColor = Color.FromArgb(GetColorLetra(dtInfo.Rows(x).Item("tipo_aus")))
                dgCalendario.Item(D, M).Value = dtInfo.Rows(x).Item("tipo_aus")

            Next

            '=====Vacaciones programadas  ColorBack = -256; COLORLetra= -16777216
            dtInfo = sqlExecute("select reloj,fecha from vacs_prog where isnull(APLICADO,0)=0 and reloj='" & R & "'", "PERSONAL")
            If Not dtInfo.Columns.Contains("Error") And dtInfo.Rows.Count > 0 Then
                For x = 0 To dtInfo.Rows.Count - 1
                    D = dtInfo.Rows(x).Item("fecha").Day
                    M = dtInfo.Rows(x).Item("fecha").Month - 1
                    dgCalendario.Item(D, M).ToolTipText = "Vacación programada"
                    dgCalendario.Item(D, M).Style.BackColor = Color.FromArgb(-256)
                    dgCalendario.Item(D, M).Style.ForeColor = Color.FromArgb(-16777216)
                    dgCalendario.Item(D, M).Value = "VAP"
                Next
            End If

        Catch ex As Exception
            Debug.Print("Error en kárdex" & ex.Message)
        End Try
    End Sub

    Private Sub tmrAusentismo_Tick(sender As Object, e As EventArgs) Handles tmrDelay.Tick
        tmrDelay.Enabled = False
        pnlAusentismo.Visible = False
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
        Dim CodFestivo As String = ""
        Try
            pnlAusentismo.Visible = False
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
            'Determinar qué código de ausentismo corresponde al festivo
            dtTemporal = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE UPPER(nombre) LIKE ('%FESTIVO')", "TA")
            If dtTemporal.Rows.Count > 0 Then
                CodFestivo = dtTemporal.Rows(0).Item("tipo_aus").ToString.Trim
            End If

            If Dato = CodFestivo Then
                'Si el detalle del día corresponde al festivo
                dtTemporal = sqlExecute("SELECT nombre FROM festivos WHERE festivo = '" & FechaSQL(Fecha) & "'", "TA")
                Dato = "Ausentismo" & vbCrLf & "FESTIVO"
                If dtTemporal.Rows.Count > 0 Then
                    If Not IsDBNull(dtTemporal.Rows(0).Item("nombre")) Then
                        If dtTemporal.Rows(0).Item("nombre").ToString.Trim.Length > 0 Then
                            Dato = Dato & vbCrLf & dtTemporal.Rows(0).Item("nombre")
                        End If
                    End If
                End If
                lblTexto.Text = Dato.Trim
            ElseIf Dato = "R" Then
                'Si el detalle corresponde a un retardo
                lblTexto.Text = dgCalendario.Item(X, Y).ToolTipText.Trim
            ElseIf Dato = "SA" Then
                'Si el detalle corresponde a un retardo
                lblTexto.Text = dgCalendario.Item(X, Y).ToolTipText.Trim
            ElseIf Dato <> "" Then
                'Si el detalle no está en blanco, debe ser un ausentismo
                dtTemporal = sqlExecute("SELECT fecha,ausentismo.tipo_aus,referencia,tipo_ausentismo.nombre FROM ausentismo LEFT JOIN tipo_ausentismo ON ausentismo.tipo_aus=tipo_ausentismo.TIPO_AUS WHERE reloj = '" & txtReloj.Text & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                If dtTemporal.Rows.Count > 0 Then
                    Dato = "AUSENTISMO" & vbCrLf & dtTemporal.Rows(0).Item("nombre")

                    If Not IsDBNull(dtTemporal.Rows(0).Item("referencia")) Then
                        If dtTemporal.Rows(0).Item("referencia").ToString.Trim.Length > 0 Then
                            Dato = Dato & vbCrLf & dtTemporal.Rows(0).Item("referencia")
                        End If
                    End If
                    lblTexto.Text = Dato.Trim
                Else
                    lblTexto.Text = "AUSENTISMO" & vbCrLf & "Sin detalle"
                End If
            ElseIf Fecha >= FBaja And Fecha <= Now.Date Then
                'Si la fecha seleccionada es posterior a la fecha de baja
                lblTexto.Text = "INACTIVO" & vbCrLf & "Baja el día " & FBaja
            ElseIf Fecha < FAlta And Fecha <= Now.Date Then
                'Si la fecha seleccionada es anterior a la fecha de alta
                lblTexto.Text = "INACTIVO" & vbCrLf & "Alta el día " & FAlta
            ElseIf Dato = "" And Fecha <= Now.Date Then
                'Si el detalle está en blanco, debe ser asistencia
                dtTemporal = sqlExecute("SELECT dia_entro,dia_salio,entro,salio,comentario FROM asist WHERE reloj= '" & txtReloj.Text & "' AND fecha_entro = '" & FechaSQL(Fecha) & "'", "TA")
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
                pnlAusentismo.Visible = False
                Exit Sub
            End If



            'Si el día es mayor a 25, o el mes después de septiembre, el panel no cabe, hay que colocarlo arriba y/o a la izquierda de la celda
            If X > 25 Then X = X - 6
            If Y > 8 Then Y = Y - 3

            'Ubicar el panel de acuerdo a la celda seleccionada
            pnlAusentismo.Left = dgCalendario.GetCellDisplayRectangle(X, Y, True).Location.X + dgCalendario.Left + 15
            pnlAusentismo.Top = dgCalendario.GetCellDisplayRectangle(X, Y, True).Location.Y + dgCalendario.Top + 15

            'Habilitar el timer que cierra el panel, y poner el panel visible
            tmrDelay.Enabled = True
            pnlAusentismo.Visible = True

        Catch ex As Exception
            'Inhabilitar el timer que cierra el panel, y poner el panel invisible
            tmrDelay.Enabled = False
            pnlAusentismo.Visible = False
        End Try
    End Sub

    Private Sub btnCerrarPanel_Click(sender As Object, e As EventArgs) Handles btnCerrarPanel.Click
        pnlAusentismo.Visible = False
        tmrDelay.Enabled = False
    End Sub
    Public Sub MostrarInformacion(ByVal rl As String)
        Dim dtInfo As New DataTable
        Dim ArchivoFoto As String
        Dim Comp As String
        Dim dtTemp As New DataTable
        Try
            If rl <> "" Then
                'dtInfo = consultapersonalvw("SELECT * from personalvw WHERE reloj = '" & rl & "'")
                dtPersonal = ConsultaPersonalVW("SELECT * from personalvw WHERE reloj = '" & rl & "'")
            Else
                '== Comentado               2 mayo 2022         Ernesto
                'dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw ORDER BY reloj")
                '== Se agrega filtro segun el tipo de perfil (en este caso gerente medico: solo sus empleados)                  2mayo2022       Ernesto
                dtPersonal = FiltraInformacion(ConsultaPersonalVW("SELECT  * from personalvw ORDER BY reloj"), "cod_super")

                rl = IIf(IsDBNull(dtPersonal.Rows.Item(0).Item("reloj")), "", dtPersonal.Rows.Item(0).Item("reloj"))
            End If

            '==Ernesto      2mayo2022
            dtTemp = dtPersonal.Clone
            dtTemp = dtPersonal.Select("reloj='" & rl & "'").CopyToDataTable

            With dtTemp.Rows.Item(0)
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
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
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
         reloj = txtReloj.Text
        dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw WHERE reloj >'" & Reloj & "' ORDER BY reloj ASC")
        If dtPersonal.Rows.Count < 1 Then
            btnLast.PerformClick()
        Else
            Reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
            MostrarInformacion(Reloj)
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
        formaAbierta = True

        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                '== Comentado                   2mayo2022           Ernesto
                'dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw WHERE reloj ='" & Reloj & "' ORDER BY reloj ASC")
                MostrarInformacion(Reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtPersonal = dtTemp
        End Try
        formaAbierta = False
    End Sub

    Private Sub frmKardexAn_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        MostrarInformacion(txtReloj.Text)
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            dtFiltroPersonal = ConsultaPersonalVW("SELECT * FROM personalvw WHERE reloj = '" & txtReloj.Text & "'")
            frmVistaPrevia.LlamarReporte("KardexAnual", dtfiltropersonal, "", {cmbAno.Text, txtReloj.Text})
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
        Dim dtAnio_Actual As New DataTable
        Dim anio_actual As String = ""
        Try
            dtAños = sqlExecute("SELECT DISTINCT ano FROM periodos ORDER BY ano DESC", "TA")
            cmbAno.DataSource = dtAños

            dtAnio_Actual = sqlExecute("SELECT YEAR(GETDATE()) AS ANO_ACTUAL", "TA")
            If (Not dtAnio_Actual.Columns.Contains("ERROR") And dtAnio_Actual.Rows.Count > 0) Then
                anio_actual = IIf(IsDBNull(dtAnio_Actual.Rows(0).Item("ANO_ACTUAL")), "", dtAnio_Actual.Rows(0).Item("ANO_ACTUAL"))
                cmbAno.SelectedValue = anio_actual.ToString.Trim
            End If

            CrearCalendario()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgCalendario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCalendario.CellContentClick

    End Sub

    Private Sub Label69_Click(sender As Object, e As EventArgs) Handles Label69.Click

    End Sub

    Private Sub txtTurno_TextChanged(sender As Object, e As EventArgs) Handles txtTurno.TextChanged

    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click

    End Sub

    Private Sub txtHorario_TextChanged(sender As Object, e As EventArgs) Handles txtHorario.TextChanged

    End Sub

    Public Overloads Sub Show(ByVal Reloj As String)
        MyBase.Show()
        MostrarInformacion(Reloj)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

    End Sub
End Class