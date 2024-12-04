Public Class frmProgramacionVacaciones

    Dim dtPersonalProgramable As DataTable
    Dim dtProgramacion As New DataTable

    Dim f_ini As Date
    Dim f_fin As Date

    Dim COLUMNAS_BASE As Integer = 6
    Dim T_ESPERA As Integer = 0
    Dim PERIODO_VACACIONAL As String = ""
    Dim PERIODO_CORTE As String = ""

    Dim fecha_hora_corte As DateTime

    Dim administrador As Boolean = False

    Dim termino_periodo As Boolean = False

    Dim extension As Boolean = False
    Dim termino_extension As Boolean = False

    Private Sub frmProgramacionVacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            administrador = Perfil.ToUpper.Contains("ADMIN")
            labelAdmin.Visible = administrador

            Dim periodo_captura As String = ""
            Try
                Dim dtuser As DataTable = sqlExecute("select isnull(captura_shutdown, '') as captura_shutdown from appuser where username = '" & Usuario & "'", "seguridad")
                periodo_captura = dtuser.Rows(0)("captura_shutdown")
            Catch ex As Exception

            End Try

            Dim dtPeriodoVacacional As New DataTable

            If periodo_captura = "" Then
                dtPeriodoVacacional = sqlExecute("select top 1 * from periodos_vacacionales where activo = '1'", "TA")
            Else
                dtPeriodoVacacional = sqlExecute("select * from periodos_vacacionales where activo = '1' and cod_periodo = '" & periodo_captura & "'", "TA")
            End If

            If dtPeriodoVacacional.Rows.Count > 0 Then
                PERIODO_VACACIONAL = dtPeriodoVacacional.Rows(0)("cod_periodo")
                PERIODO_CORTE = dtPeriodoVacacional.Rows(0)("periodo_corte")
                LabelPeriodoVac.Text = dtPeriodoVacacional.Rows(0)("descripcion")
                f_ini = dtPeriodoVacacional.Rows(0)("fecha_ini")
                f_fin = dtPeriodoVacacional.Rows(0)("fecha_fin")

                ' FECHA CORTE DEFAULT

                fecha_hora_corte = dtPeriodoVacacional.Rows(0)("fecha_corte")
                fecha_hora_corte = fecha_hora_corte.AddHours(dtPeriodoVacacional.Rows(0)("hora_corte").ToString.Split(":")(0))
                fecha_hora_corte = fecha_hora_corte.AddMinutes(dtPeriodoVacacional.Rows(0)("hora_corte").ToString.Split(":")(1))

                If fecha_hora_corte <= Now Then
                    LabelTermino.Text = "El periodo de captura concluyó: " & fecha_hora_corte.ToString
                    LabelTermino.ForeColor = Color.FromArgb(156, 0, 6)
                    LabelTermino.BackColor = Color.FromArgb(255, 199, 206)

                    termino_periodo = True

                    If Not administrador Then
                        dgvProgramacion.Enabled = False
                    End If
                Else
                    LabelTermino.Text = "La captura estará habilitada hasta: " & fecha_hora_corte.ToString
                    LabelTermino.ForeColor = Color.FromArgb(0, 97, 0)
                    LabelTermino.BackColor = Color.FromArgb(198, 239, 206)

                    termino_periodo = False
                    TimerExtension.Start()
                End If

                Dim dtExtension As DataTable = sqlExecute("select * from excepciones_captura where periodo_vacacional = '" & PERIODO_VACACIONAL & "' and username = '" & Usuario & "'", "TA")
                If dtExtension.Rows.Count > 0 Then

                    If termino_periodo Then
                        fecha_hora_corte = dtExtension.Rows(0)("fecha_corte")
                        fecha_hora_corte = fecha_hora_corte.AddHours(dtExtension.Rows(0)("hora_corte").ToString.Split(":")(0))
                        fecha_hora_corte = fecha_hora_corte.AddMinutes(dtExtension.Rows(0)("hora_corte").ToString.Split(":")(1))
                        extension = True

                        If fecha_hora_corte <= Now Then
                            LabelExtension.Text = "El periodo de extensión concluyó: " & fecha_hora_corte.ToString
                            LabelExtension.Visible = True
                            LabelExtension.ForeColor = Color.FromArgb(156, 0, 6)
                            LabelExtension.BackColor = Color.FromArgb(255, 199, 206)

                            termino_extension = True

                            If Not administrador Then
                                dgvProgramacion.Enabled = False
                            End If
                        Else
                            LabelExtension.Text = "La extensión estará habilitada hasta: " & fecha_hora_corte.ToString
                            LabelExtension.Visible = True
                            LabelExtension.ForeColor = Color.FromArgb(156, 87, 0)
                            LabelExtension.BackColor = Color.FromArgb(255, 235, 156)

                            termino_extension = False
                            dgvProgramacion.Enabled = True
                            TimerExtension.Start()
                        End If
                    Else
                        extension = False
                        LabelExtension.Visible = False
                    End If
                Else
                    extension = False
                    LabelExtension.Visible = False
                End If
            Else
                estatus(-2, "No existen periodos vacacionales por capturar")
                AdvTreeFiltros.Enabled = False
                dgvProgramacion.Enabled = False

                LabelTermino.Visible = False
                LabelExtension.Visible = False
                labelAdmin.Visible = False

                AdvTreeFiltros.Nodes.Clear()
                Exit Sub
            End If

            Dim f As Date
            ' f20161112

            f = f_ini
            While f <= f_fin
                Dim col As New DataGridViewTextBoxColumn
                col.DataPropertyName = "f_" & FechaSQL(f).Replace("-", "")
                col.HeaderText = FechaSQL(f)
                col.Name = "f_" & FechaSQL(f).Replace("-", "")
                '                col.ReadOnly = False
                col.SortMode = DataGridViewColumnSortMode.NotSortable
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                col.MaxInputLength = 1

                col.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                col.Width = 40

                dgvProgramacion.Columns.Add(col)
                f = f.AddDays(1)
            End While




            If FiltroXUsuario = "" Then
                dtPersonalProgramable = ConsultaPersonalVW("select * from personal where baja is null and cod_comp = '610' and cod_hora is not null and cod_super is not null", False)
            Else
                dtPersonalProgramable = ConsultaPersonalVW("select * from personal where baja is null and cod_comp = '610' and cod_hora is not null and cod_super is not null and " & FiltroXUsuario & "", False)
            End If

            dtProgramacion.Columns.Add("reloj") ' visible
            dtProgramacion.Columns.Add("nombres") ' visible
            dtProgramacion.Columns.Add("cod_super")
            dtProgramacion.Columns.Add("nombre_super")
            dtProgramacion.Columns.Add("cod_hora") ' visible
            dtProgramacion.Columns.Add("saldo") ' visible
            dtProgramacion.Columns.Add("dias_disp") ' visible

            COLUMNAS_BASE = 6

            f = f_ini
            While f <= f_fin
                dtProgramacion.Columns.Add("f_" & FechaSQL(f).Replace("-", ""))
                f = f.AddDays(1)
            End While

            AdvTreeFiltros.Nodes.Clear()

            For Each row As DataRow In dtPersonalProgramable.Select("", "cod_super,cod_hora")

                Dim cod_super As String = RTrim(IIf(IsDBNull(row("cod_super")), "", row("cod_super")))
                Dim nombre_super As String = RTrim(IIf(IsDBNull(row("nombre_super")), "", row("nombre_super")))
                '  Dim cod_depto As String = RTrim(IIf(IsDBNull(row("cod_depto")), "", row("cod_depto")))
                Dim cod_hora As String = RTrim(IIf(IsDBNull(row("cod_hora")), "", row("cod_hora")))

                If AdvTreeFiltros.Nodes.Find(cod_super, False).Length > 0 Then
                    Dim node_super As DevComponents.AdvTree.Node = AdvTreeFiltros.Nodes.Find(cod_super, False)(0)

                    If node_super.Nodes.Find(cod_hora, False).Length > 0 Then
                    Else
                        Dim node_hora As New DevComponents.AdvTree.Node
                        node_hora.Text = "Horario " & cod_hora
                        node_hora.Name = cod_hora
                        node_hora.Tag = "cod_hora," & cod_hora
                        node_hora.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Hidden
                        node_hora.Style = ElementStyle11
                        node_hora.StyleExpanded = ElementStyle11
                        'node_hora.StyleSelected = ElementStyle8
                        node_hora.FullRowBackground = True
                        node_super.Nodes.Add(node_hora)
                    End If



                Else
                    Dim node_super As New DevComponents.AdvTree.Node
                    node_super.Text = cod_super & " - " & nombre_super
                    node_super.Name = cod_super
                    node_super.Tag = "cod_super," & cod_super
                    node_super.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Hidden
                    node_super.Style = ElementStyle9
                    node_super.StyleExpanded = ElementStyle9
                    node_super.StyleSelected = ElementStyle8
                    node_super.FullRowBackground = True

                    If administrador Then
                        ' node_super.CheckBoxVisible = True
                    End If

                    Dim node_hora As New DevComponents.AdvTree.Node
                    node_hora.Text = "Horario " & cod_hora
                    node_hora.Name = cod_hora
                    node_hora.Tag = "cod_hora," & cod_hora
                    node_hora.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Hidden
                    node_hora.Style = ElementStyle11
                    node_hora.StyleExpanded = ElementStyle11
                    '  node_hora.StyleSelected = ElementStyle8
                    node_hora.FullRowBackground = True

                    'node_depto.Nodes.Add(node_hora)
                    node_super.Nodes.Add(node_hora)
                    AdvTreeFiltros.Nodes.Add(node_super)

                    Application.DoEvents()

                End If

            Next

            'MostrarInformacion()
            AdvTreeFiltros.SelectedNode = AdvTreeFiltros.Nodes(0).Nodes(0)
        Catch ex As Exception

        End Try

    End Sub

    Dim cod_super_filtro As String = ""

    Dim cod_hora_filtro As String = ""
    Dim dtAusentismo As DataTable = sqlExecute("select * from ausentismo where fecha between '" & FechaSQL(f_ini) & "' and '" & FechaSQL(f_fin) & "' and tipo_aus <> 'FI'", "TA")
    Private Sub MostrarInformacion()

        Cursor = Cursors.WaitCursor

        Try

            Dim filtro As String = IIf(cod_super_filtro <> "", "cod_super = '" & cod_super_filtro & "'", "")
            filtro &= IIf(filtro <> "" And cod_hora_filtro <> "", " AND ", "")
            filtro &= IIf(cod_hora_filtro <> "", "cod_hora = '" & cod_hora_filtro & "'", "")

            'LabelFiltro.Text = filtro
            Application.DoEvents()


            dtProgramacion.Rows.Clear()
            RemoveHandler dgvProgramacion.CellValidated, AddressOf dgvProgramacion_CellValidated
            RemoveHandler dgvProgramacion.CellValueChanged, AddressOf dgvProgramacion_CellValueChanged

            For Each row As DataRow In dtPersonalProgramable.Select(filtro, "cod_super,cod_hora")
                Dim drow As DataRow = dtProgramacion.NewRow

                drow("reloj") = row("reloj")
                drow("nombres") = row("nombres")
                drow("cod_super") = row("cod_super")
                drow("nombre_super") = row("nombre_super")
                drow("cod_hora") = row("cod_hora")

                Dim _saldo As Integer = 0

                Dim dtSaldos As DataTable = sqlExecute("select * from programacion_saldos where cod_periodo = '" & PERIODO_VACACIONAL & "' and reloj = '" & row("reloj") & "'", "TA")
                If dtSaldos.Rows.Count > 0 Then
                    _saldo = Math.Floor(Double.Parse(dtSaldos.Rows(0)("saldo")))
                End If

                Dim dtPendientes As DataTable = sqlExecute("select ajustes_nom.reloj, ajustes_nom.monto from ajustes_nom left join ta.dbo.periodos on ajustes_nom.ano = periodos.ano and ajustes_nom.periodo = periodos.periodo where concepto = 'diasva' and periodos.ano+periodos.periodo > '" & PERIODO_CORTE & "' and reloj = '" & row("reloj") & "'", "nomina")
                For Each row_p As DataRow In dtPendientes.Rows
                    _saldo -= row_p("monto")
                Next

                Dim _dias_disp As Integer = _saldo
                drow("saldo") = _saldo


                Dim dtVacacionesProgramadas As DataTable = sqlExecute("select * from programacion_vacaciones where reloj = '" & row("reloj") & "' and fecha between '" & FechaSQL(f_ini) & "' and '" & FechaSQL(f_fin) & "'", "TA")
                If dtVacacionesProgramadas.Rows.Count > 0 Then
                    For Each row_vacs As DataRow In dtVacacionesProgramadas.Rows
                        Dim _valor As String = row_vacs("valor")
                        drow("f_" & FechaSQL(row_vacs("fecha")).Replace("-", "")) = _valor
                        If _valor = "V" Then
                            _dias_disp -= 1
                        End If
                    Next
                End If

                drow("dias_disp") = _dias_disp
                dtProgramacion.Rows.Add(drow)
            Next

            dgvProgramacion.AutoGenerateColumns = False
            dgvProgramacion.DataSource = dtProgramacion

            'For Each column As DataGridViewColumn In dgvProgramacion.Columns
            '    Dim columna As String = column.Name
            '    If columna.Substring(0, 2) = "f_" Then
            '        Dim v_fecha As Date = DateSerial(columna.Substring(2, 4), columna.Substring(6, 2), columna.Substring(8, 2))
            '        If DiaDescanso(v_fecha) Then
            '            column.DefaultCellStyle.BackColor = Color.Gainsboro
            '            column.ReadOnly = True
            '        End If
            '    End If
            'Next

            For Each row_dgv As DataGridViewRow In dgvProgramacion.Rows
                ' Dim dtAusentismo As DataTable = sqlExecute("select * from ausentismo where reloj = '" & row_dgv.Cells("ColumnReloj").Value & "' and fecha between '" & FechaSQL(f_ini) & "' and '" & FechaSQL(f_fin) & "' and tipo_aus <> 'FI'", "TA")
                For Each row_aus As DataRow In dtAusentismo.Select("reloj = '" & row_dgv.Cells("ColumnReloj").Value & "'")
                    row_dgv.Cells("f_" & FechaSQL(row_aus("fecha")).Replace("-", "")).ReadOnly = True
                    row_dgv.Cells("f_" & FechaSQL(row_aus("fecha")).Replace("-", "")).Value = row_aus("tipo_aus")
                Next

                For Each column As DataGridViewColumn In dgvProgramacion.Columns
                    Dim columna As String = column.Name
                    If columna.Substring(0, 2) = "f_" Then
                        Dim v_fecha As Date = DateSerial(columna.Substring(2, 4), columna.Substring(6, 2), columna.Substring(8, 2))
                        If DiaDescanso(v_fecha, row_dgv.Cells("ColumnReloj").Value) Then
                            row_dgv.Cells(columna).Style.BackColor = Color.Gainsboro
                        End If
                    End If
                Next

            Next

            AdvTreeFiltros.ExpandAll()

            AddHandler dgvProgramacion.CellValidated, AddressOf dgvProgramacion_CellValidated
            AddHandler dgvProgramacion.CellValueChanged, AddressOf dgvProgramacion_CellValueChanged

            estatus(1, "Información actualizada " & Now.ToString)

        Catch ex As Exception

        End Try

        Cursor = Cursors.Default

    End Sub


    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvProgramacion.CellPainting
        ' Vertical text from column 0, or adjust below, if first column(s) to be skipped
        If (e.RowIndex = -1 And e.ColumnIndex >= COLUMNAS_BASE) Then
            e.PaintBackground(e.CellBounds, True)
            e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom)
            e.Graphics.RotateTransform(270)
            e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5)
            e.Graphics.ResetTransform()
            e.Handled = True
        End If
    End Sub

    Private Sub AdvTreeFiltros_SelectionChanged(sender As Object, e As EventArgs) Handles AdvTreeFiltros.SelectionChanged
        Try
            Dim c As String = AdvTreeFiltros.SelectedNode.Tag.ToString.Split(",")(0)
            Dim v As String = AdvTreeFiltros.SelectedNode.Tag.ToString.Split(",")(1)

            If c = "cod_hora" Then
                cod_hora_filtro = v

                cod_super_filtro = AdvTreeFiltros.SelectedNode.Parent.Tag.ToString.Split(",")(1)
            ElseIf c = "cod_super" Then
                cod_hora_filtro = ""

                cod_super_filtro = v
            End If

            MostrarInformacion()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvProgramacion_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) ' Handles dgvProgramacion.CellValueChanged
        Try
            Dim columna As String = dgvProgramacion.Columns(e.ColumnIndex).Name

            If columna.Substring(0, 2) = "f_" Then
                Dim v_reloj As String = dgvProgramacion.Rows(e.RowIndex).Cells("ColumnReloj").Value
                Dim v_fecha As Date = DateSerial(columna.Substring(2, 4), columna.Substring(6, 2), columna.Substring(8, 2))
                Dim v_valor As String = dgvProgramacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

                Dim guardar As Boolean = False
                Dim borrar As Boolean = False

                If (v_valor = "V") Then
                    guardar = True
                    borrar = False
                ElseIf (v_valor = "P") Then
                    guardar = True
                    borrar = False
                ElseIf (v_valor = Space(1)) Then
                    guardar = False
                    borrar = True
                ElseIf (v_valor = "") Then
                    guardar = False
                    borrar = False
                    Exit Sub
                Else
                    dgvProgramacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Space(1)
                    guardar = False
                    borrar = False
                End If


                Dim saldo As Integer = dgvProgramacion.Rows(e.RowIndex).Cells("ColumnSaldo").Value
                Dim dias_disp As Integer = saldo

                For Each column As DataGridViewColumn In dgvProgramacion.Columns
                    If column.Name.Substring(0, 2) = "f_" Then
                        Try
                            Dim pv As String = dgvProgramacion.Rows(e.RowIndex).Cells(column.Name).Value
                            If pv = "V" Then
                                dias_disp -= 1
                            End If
                        Catch ex As Exception

                        End Try

                    End If
                Next

                If dias_disp < 0 Then
                    'estatus(-1, "No existen suficientes días disponibles")
                    'dgvProgramacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
                    'Exit Sub
                End If

                dgvProgramacion.Rows(e.RowIndex).Cells("ColumnDiasDisp").Value = dias_disp

                If guardar Then
                    Dim dtExiste As DataTable = sqlExecute("select * from programacion_vacaciones where reloj = '" & v_reloj & "' and fecha = '" & FechaSQL(v_fecha) & "'", "TA")
                    If dtExiste.Rows.Count > 0 Then
                        sqlExecute("update programacion_vacaciones set valor = '" & v_valor & "', usuario = '" & Usuario & "', captura = getdate() where reloj = '" & v_reloj & "' and fecha = '" & FechaSQL(v_fecha) & "'", "TA")
                        sqlExecute("update programacion_vacaciones set export = null where reloj = '" & v_reloj & "'", "TA")

                        estatus(1, "Registro actualizado: " & v_reloj & ", " & FechaSQL(v_fecha) & ", " & v_valor)
                    Else
                        sqlExecute("insert into programacion_vacaciones (reloj, fecha, valor, usuario, captura) values ('" & v_reloj & "', '" & FechaSQL(v_fecha) & "', '" & v_valor & "', '" & Usuario & "', getdate())", "TA")
                        sqlExecute("update programacion_vacaciones set export = null where reloj = '" & v_reloj & "'", "TA")

                        estatus(1, "Registro nuevo: " & v_reloj & ", " & FechaSQL(v_fecha) & ", " & v_valor)
                    End If
                ElseIf borrar Then
                    Dim dtExiste As DataTable = sqlExecute("select * from programacion_vacaciones where reloj = '" & v_reloj & "' and fecha = '" & FechaSQL(v_fecha) & "'", "TA")
                    If dtExiste.Rows.Count > 0 Then
                        sqlExecute("delete from programacion_vacaciones where reloj = '" & v_reloj & "' and fecha = '" & FechaSQL(v_fecha) & "'", "TA")
                        estatus(-1, "Registro eliminado: " & v_reloj & ", " & FechaSQL(v_fecha) & ", " & v_valor)
                    Else
                        estatus(-1, "Registro no válido")
                    End If
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvProgramacion_CellValidated(sender As Object, e As DataGridViewCellEventArgs) 'Handles dgvProgramacion.CellValidated
        Try
            Dim columna As String = dgvProgramacion.Columns(e.ColumnIndex).Name

            If columna.Substring(0, 2) = "f_" Then
                Dim v_valor As String = dgvProgramacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                v_valor = v_valor.ToUpper
                dgvProgramacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = v_valor
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvProgramacion_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvProgramacion.CellBeginEdit
        Try
            If dgvProgramacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Length > 1 Then
                estatus(-1, "Ya existe ausentismo programado para esta fecha")
                e.Cancel = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub estatus(estatus As Integer, mensaje As String)

        LabelEstatus.Text = mensaje

        If estatus = 1 Then
            LabelEstatus.ForeColor = Color.FromArgb(0, 97, 0)
            LabelEstatus.BackColor = Color.FromArgb(198, 239, 206)
        ElseIf estatus = 0 Then
            LabelEstatus.ForeColor = Color.FromArgb(156, 87, 0)
            LabelEstatus.BackColor = Color.FromArgb(255, 235, 156)
        ElseIf estatus = -1 Then
            LabelEstatus.ForeColor = Color.FromArgb(156, 0, 6)
            LabelEstatus.BackColor = Color.FromArgb(255, 199, 206)
        ElseIf estatus = -2 Then
            LabelEstatus.ForeColor = Color.FromArgb(156, 0, 6)
            LabelEstatus.BackColor = Color.FromArgb(255, 199, 206)
        End If

        T_ESPERA = 2
        If Not Timer1.Enabled Then
            Timer1.Start()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If T_ESPERA <= 0 Then
                Timer1.Stop()
                LabelEstatus.Text = "-"
                LabelEstatus.ForeColor = Color.Black
                LabelEstatus.BackColor = Color.White
            Else
                T_ESPERA -= 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Try

            Dim dtVacacionesProgramadas As New DataTable
            dtVacacionesProgramadas.Columns.Add("reloj", Type.GetType("System.String"))
            dtVacacionesProgramadas.Columns.Add("nombres", Type.GetType("System.String"))
            dtVacacionesProgramadas.Columns.Add("cod_super", Type.GetType("System.String"))
            dtVacacionesProgramadas.Columns.Add("nombre_super", Type.GetType("System.String"))
            dtVacacionesProgramadas.Columns.Add("cod_hora", Type.GetType("System.String"))
            dtVacacionesProgramadas.Columns.Add("fecha", Type.GetType("System.DateTime"))
            dtVacacionesProgramadas.Columns.Add("periodo", Type.GetType("System.String"))
            dtVacacionesProgramadas.Columns.Add("valor", Type.GetType("System.String"))
            dtVacacionesProgramadas.Columns.Add("saldo", Type.GetType("System.String"))
            dtVacacionesProgramadas.Columns.Add("dias_disp", Type.GetType("System.String"))

            For Each row As DataGridViewRow In dgvProgramacion.Rows
                Dim _reloj As String = row.Cells("ColumnReloj").Value
                Dim _nombres As String = row.Cells("ColumnNombres").Value



                Dim _cod_super As String = cod_super_filtro
                Dim _nombre_super As String = ""



                Dim dt_nombresuper As DataTable = sqlExecute("select * from super where cod_super = '" & _cod_super & "'")
                If dt_nombresuper.Rows.Count > 0 Then
                    _nombre_super = dt_nombresuper.Rows(0)("nombre")
                End If

                Dim _cod_hora As String = row.Cells("ColumnHora").Value

                Dim _saldo As Integer
                Dim dtSaldos As DataTable = sqlExecute("select * from programacion_saldos where cod_periodo = '" & PERIODO_VACACIONAL & "' and reloj = '" & _reloj & "'", "TA")
                If dtSaldos.Rows.Count > 0 Then
                    _saldo = Math.Floor(Double.Parse(dtSaldos.Rows(0)("saldo")))
                End If

                Dim dtPendientes As DataTable = sqlExecute("select ajustes_nom.reloj, ajustes_nom.monto from ajustes_nom left join ta.dbo.periodos on ajustes_nom.ano = periodos.ano and ajustes_nom.periodo = periodos.periodo where concepto = 'diasva' and periodos.ano+periodos.periodo > '" & PERIODO_CORTE & "' and reloj = '" & _reloj & "'", "nomina")
                For Each row_p As DataRow In dtPendientes.Rows
                    _saldo -= row_p("monto")
                Next

                Dim _dias_disp As Integer = _saldo



                Dim _f As Date = f_ini
                While _f <= f_fin

                    If False Then
                        '_f = _f.AddDays(1)
                    Else
                        Dim _valor As String = ""

                        Dim drow As DataRow = dtVacacionesProgramadas.NewRow

                        Dim dtVacaciones As DataTable = sqlExecute("select * from programacion_vacaciones where reloj = '" & _reloj & "' and fecha = '" & FechaSQL(_f) & "'", "TA")
                        If dtVacaciones.Rows.Count > 0 Then
                            _valor = dtVacaciones.Rows(0)("valor")
                        Else
                            Dim dtAusentismo As DataTable = sqlExecute("select * from ausentismo where reloj = '" & _reloj & "' and fecha = '" & FechaSQL(_f) & "'", "TA")
                            If dtAusentismo.Rows.Count > 0 Then
                                _valor = RTrim(dtAusentismo.Rows(0)("tipo_aus"))
                                _valor = IIf(_valor = "FES", "F", _valor)
                            End If
                        End If

                        drow("reloj") = _reloj
                        drow("nombres") = _nombres

                        drow("cod_super") = _cod_super


                        drow("nombre_super") = _nombre_super

                        drow("cod_hora") = _cod_hora
                        drow("fecha") = _f

                        Dim dtPeriodo As DataTable = sqlExecute("select ano+periodo as anoper from periodos where isnull(periodo_especial, 0) = 0 and '" & FechaSQL(_f) & "' between fecha_ini and fecha_fin", "TA")
                        If dtPeriodo.Rows.Count > 0 Then
                            drow("periodo") = dtPeriodo.Rows(0)("anoper")
                        Else
                            drow("fecha") = ""
                        End If

                        drow("valor") = _valor

                        drow("saldo") = _saldo

                        dtVacacionesProgramadas.Rows.Add(drow)

                        _f = _f.AddDays(1)
                    End If


                End While
            Next

            frmVistaPrevia.LlamarReporte("VacacionesProgramacion", dtVacacionesProgramadas)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles TimerExtension.Tick
        If fecha_hora_corte <= Now Then
            TimerExtension.Stop()

            If termino_periodo = False Then
                termino_periodo = True
                LabelTermino.Text = "El periodo de captura concluyó: " & fecha_hora_corte.ToString
                LabelTermino.ForeColor = Color.FromArgb(156, 0, 6)
                LabelTermino.BackColor = Color.FromArgb(255, 199, 206)
            Else
                If extension Then
                    termino_extension = True
                    LabelExtension.Text = "El periodo de extensión concluyó: " & fecha_hora_corte.ToString
                    LabelExtension.ForeColor = Color.FromArgb(156, 0, 6)
                    LabelExtension.BackColor = Color.FromArgb(255, 199, 206)
                End If
            End If

            MessageBox.Show("El periodo de " & IIf(extension, "extensión", "captura") & " concluyó: " & fecha_hora_corte.ToString, "Periodo de " & IIf(extension, "extensión", "captura") & "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If Not administrador Then
                dgvProgramacion.Enabled = False
            End If
        End If
    End Sub


    Private Sub dgvProgramacion_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProgramacion.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Dim c As DataGridViewCell = dgvProgramacion.SelectedCells(0)
                If c IsNot Nothing Then
                    c.Value = Space(1)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class