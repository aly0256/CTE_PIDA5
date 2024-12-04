Public Class frmCapturaSubAusentismo

    Dim dtMiPersonal As DataTable
    Dim dtColoresAus As DataTable
    Dim filtroGeneral As String

    Dim estilo_non As DataGridViewCellStyle
    Dim estilo_par As DataGridViewCellStyle

    Dim estilo_bold As Font
    Dim estilo_regular As Font

    Dim dtSubAusentismo As New DataTable
    Dim dtLider As New DataTable

    Private Sub frmCapturaSubAusentismo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        advSupervisores.Nodes.Clear()
        dtColoresAus = sqlExecute("select tipo_aus, color_letra, color_back from tipo_ausentismo", "TA")
        Try
            Dim dtPeriodos As DataTable
            dtPeriodos = sqlExecute("  select distinct ano+num_mes as anomes, ano as ano, mes as num_mes, convert(char(10), ano+'-'+NUM_MES+'-01', 120) as fecha_ini,  convert(char(10), DATEADD(month, ((ano - 1900) * 12) + num_mes, -1), 120) as fecha_fin from TA.dbo.periodos  where isnull(periodo_especial, 0) = 0", "TA")
            cmbPeriodo.DataSource = dtPeriodos
            cmbPeriodo.ValueMember = "anomes"
            dtPeriodos = sqlExecute("  select distinct ano+num_mes as anomes from TA.dbo.periodos  where isnull(periodo_especial, 0) = 0 and activo = '1'", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                cmbPeriodo.SelectedValue = dtPeriodos.Rows(0).Item("anomes").ToString.Trim()
            Else
                cmbPeriodo.SelectedIndex = 0
            End If


            estilos()
        Catch ex As Exception
        End Try

        'carga_estructura()
    End Sub

    Public Sub carga_estructura(Optional VerPrimerSupervisor As Boolean = True)
        cmbPeriodo.Enabled = False
        btnRefresh.Enabled = False
        btnPeriodoAnterior.Enabled = False
        btnPeriodoSiguiente.Enabled = False
        advSupervisores.Enabled = False

        Dim anoper As String
        If TypeOf cmbPeriodo.SelectedValue Is String Then
            anoper = cmbPeriodo.SelectedValue
        Else
            anoper = cmbPeriodo.SelectedValue(0)
        End If
        Dim dtPeriodo As DataTable = sqlExecute("select distinct convert(char(10), ano+'-'+NUM_MES+'-01', 120) as fecha_ini,  convert(char(10), DATEADD(month, ((ano - 1900) * 12) + num_mes, -1), 120) as fecha_fin from ta.dbo.periodos where ano+num_mes = '" & anoper & "'")
        If dtPeriodo.Rows.Count > 0 Then
            dgvExtraAut.Rows.Clear()
            dgvExtraAut.Columns.Clear()
            advSupervisores.Nodes.Clear()
            dgvExtraAut.Columns.Add(ColumnReloj)
            dgvExtraAut.Columns.Add(ColumnNombre)
            dgvExtraAut.Columns.Add(ColumnTurno)
            dgvExtraAut.Columns.Add(ColumnDepto)
            dgvExtraAut.Columns.Add(ColumnClase)

            Dim fini As Date = dtPeriodo.Rows(0)("fecha_ini")
            Dim ffin As Date = dtPeriodo.Rows(0)("fecha_fin")
            Dim f As Date = fini
            Dim i As Integer = 0
            While f <= ffin
                Dim c_ausentismo As New DataGridViewColumn()
                c_ausentismo.Name = "AUS" & FechaSQL(f).Replace("-", "")
                c_ausentismo.HeaderText = "Aus." & vbCrLf & f.Day & "/" & MesLetra(f, 3)
                c_ausentismo.CellTemplate = New DataGridViewTextBoxCell()
                c_ausentismo.Width = 60
                c_ausentismo.ReadOnly = True
                dgvExtraAut.Columns.Add(c_ausentismo)

                f = f.AddDays(1)
                i += 1
            End While


            frmTrabajando.Show()
            Application.DoEvents()
            Dim dtSupervisores As New DataTable
            dtSupervisores.Columns.Add("cod_super")
            dtSupervisores.Columns.Add("nombre")
            dtSupervisores.Columns.Add("cuantos")
            dtSupervisores.PrimaryKey = New DataColumn() {dtSupervisores.Columns("cod_super")}

            dtMiPersonal = ConsultaPersonalVW("select reloj,cod_comp, nombres, cod_planta, cod_turno, cod_hora, cod_depto, cod_clase, isnull(cod_super, '') as cod_super, isnull(nombre_super, 'Sin Supervisor') as nombre_super from personalvw where baja is null and isnull(cod_super, '') <> '' order by reloj", False)

            For Each row As DataRow In dtMiPersonal.Rows

                Application.DoEvents()

                Try
                    Dim drow As DataRow = dtSupervisores.Rows.Find(row("cod_super"))
                    If drow Is Nothing Then
                        dtSupervisores.Rows.Add(row("cod_super"), row("nombre_super"), 1)
                    Else
                        Dim i_ As Integer = drow("cuantos")
                        drow("cuantos") = i_ + 1
                    End If

                Catch ex As Exception

                End Try
            Next

            advSupervisores.Nodes.Clear()

            Dim n_s As New DevComponents.AdvTree.Node
            n_s.Text = "Supervisores"
            n_s.Tag = "TODOS"

            For Each row As DataRow In dtSupervisores.Select("", "nombre")
                Dim n As New DevComponents.AdvTree.Node
                n.Text = RTrim(row("nombre")) & Space(1) & "- " & row("cuantos") & ""
                n.Tag = row("cod_super")
                n.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Hidden
                n_s.Nodes.Add(n)
            Next

            advSupervisores.Nodes.Add(n_s)

            n_s.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Hidden
            advSupervisores.ExpandAll()
            ActivoTrabajando = False
            frmTrabajando.Close()
            Application.DoEvents()
        End If

        cmbPeriodo.Enabled = True
        btnRefresh.Enabled = True
        btnPeriodoAnterior.Enabled = True
        btnPeriodoSiguiente.Enabled = True
        advSupervisores.Enabled = True
    End Sub

    Private Sub cmbPeriodo_TextChanged(sender As Object, e As EventArgs) Handles cmbPeriodo.TextChanged
        carga_estructura()
    End Sub

    Private Sub btnPeriodoAnterior_Click(sender As Object, e As EventArgs) Handles btnPeriodoAnterior.Click
        Try
            Dim PeriodoSeleccionado As String = cmbPeriodo.SelectedValue
            Dim dtPeriodos As DataTable = sqlExecute("select ano, num_mes from periodos where isnull(periodo_especial, '0') = '0' and ano + num_mes < '" & PeriodoSeleccionado & "' order by ano + num_mes desc", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                PeriodoSeleccionado = dtPeriodos.Rows(0)("ANO") & dtPeriodos.Rows(0)("num_mes")
                cmbPeriodo.SelectedValue = PeriodoSeleccionado
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPeriodoSiguiente_Click(sender As Object, e As EventArgs) Handles btnPeriodoSiguiente.Click
        Try
            Dim PeriodoSeleccionado As String = cmbPeriodo.SelectedValue
            Dim dtPeriodos As DataTable = sqlExecute("select ano, num_mes from periodos where isnull(periodo_especial, '0') = '0' and ano + num_mes > '" & PeriodoSeleccionado & "' order by ano + num_mes asc", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                PeriodoSeleccionado = dtPeriodos.Rows(0)("ANO") & dtPeriodos.Rows(0)("num_mes")
                cmbPeriodo.SelectedValue = PeriodoSeleccionado
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        carga_estructura()
    End Sub

    Private Sub advSupervisores_SelectionChanged(sender As Object, e As EventArgs) Handles advSupervisores.SelectionChanged
        frmTrabajando.Show()
        Application.DoEvents()
        Try

            tabDatos.Enabled = False

            Dim cod_super As String = advSupervisores.SelectedNode.Tag
            cargar_informacion(cmbPeriodo.SelectedValue, cod_super)

            tabDatos.Enabled = True

        Catch ex As Exception

        End Try

        ActivoTrabajando = False
        frmTrabajando.Close()
    End Sub

    Public Sub cargar_informacion(anoper As String, cod_super As String)
        Try
            Dim fini As Date = cmbPeriodo.SelectedNode.ToString.Split(",")(3)
            Dim ffin As Date = cmbPeriodo.SelectedNode.ToString.Split(",")(4)
            dgvExtraAut.Rows.Clear()
            filtroGeneral = IIf(cod_super = "TODOS", "", "cod_super = '" & cod_super & "'")
            For Each row As DataRow In dtMiPersonal.Select(filtroGeneral, "reloj")
                Dim row_id As Integer = dgvExtraAut.Rows.Add()
                Dim dgrv As DataGridViewRow = dgvExtraAut.Rows(row_id)
                dgrv.Cells("ColumnReloj").Value = row("reloj")
                dgrv.Cells("ColumnNombre").Value = row("nombres")
                dgrv.Cells("ColumnTurno").Value = row("cod_hora")
                dgrv.Cells("ColumnDepto").Value = row("cod_depto")
                dgrv.Cells("ColumnClase").Value = row("cod_clase")
                'Dim dtAus As DataTable = sqlExecute("select ausentismo.fecha, ausentismo.tipo_aus from ausentismo where fecha between '" & FechaSQL(fini) & "' and '" & FechaSQL(ffin) & "' and reloj = '" & row("reloj") & "'", "TA")
                Dim dtAus As DataTable = sqlExecute("select primer_ausentismo.fecha, primer_ausentismo.tipo_aus from primer_ausentismo where fecha between '" & FechaSQL(fini) & "' and '" & FechaSQL(ffin) & "' and reloj = '" & row("reloj") & "'", "TA")
                For Each row_ausentismo As DataRow In dtAus.Rows
                    Dim h As String = "AUS" & FechaSQL(row_ausentismo("fecha")).Replace("-", "")
                    Dim codSubAus As String = ""
                    Dim dtSubAus As DataTable = sqlExecute("select cod_sub_aus from ta.dbo.SubAusentismos where reloj = '" & row("reloj") & "' and fecha_AUS = '" & FechaSQL(row_ausentismo("fecha")) & "'")
                    If dtSubAus.Rows.Count > 0 Then
                        codSubAus = "*" '& dtSubAus.Rows(0).Item("cod_sub_aus").ToString.Trim()
                    Else
                        codSubAus = ""
                    End If
                    dgrv.Cells(h).Value = row_ausentismo("tipo_aus")
                    Try
                        'dgrv.Cells(h).Style.Font = estilo_bold
                        dgrv.Cells(h).Style.BackColor = Color.FromArgb(dtColoresAus.Select("tipo_aus = '" & dgrv.Cells(h).Value & "'")(0)("color_back"))
                        dgrv.Cells(h).Style.ForeColor = Color.FromArgb(dtColoresAus.Select("tipo_aus = '" & dgrv.Cells(h).Value & "'")(0)("color_letra"))
                        'dgrv.Cells(h).Tag = cod_super
                        'dgrv.Cells("TRAB" & FechaSQL(row_ausentismo("fecha")).Replace("-", "")).Style.Font = estilo_bold
                        'dgrv.Cells("AUT" & FechaSQL(row_ausentismo("fecha")).Replace("-", "")).Style.Font = estilo_bold
                        dgrv.Cells(h).Value = row_ausentismo("tipo_aus") & codSubAus
                    Catch ex As Exception

                    End Try
                Next
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Captura sub ausentismo", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub estilos()
        estilo_non = New DataGridViewCellStyle
        estilo_non.BackColor = Color.White

        estilo_par = New DataGridViewCellStyle
        estilo_par.BackColor = Color.FromArgb(200, 200, 200)

        estilo_bold = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
        estilo_regular = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)

    End Sub

    Private Sub dgvExtraAut_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExtraAut.CellClick
        ActualizarInformacionPanel(e.ColumnIndex, e.RowIndex)
    End Sub

    Private Sub ActualizarInformacionPanel(X As Integer, Y As Integer)
        Dim Fecha As Date
        Dim Dato As String
        Dim CodFestivo As String = ""
        Try
            lblX.Text = X
            lblY.Text = Y
            pnlAusentismo.Visible = False
            'Si no hay renglón o columna seleccionados, o la columna es la del mes, salir de la rutina
            If Y < 0 Or X < 5 Then
                Exit Sub
            End If

            'Tomar los valores de acuerdo a la celda
            Fecha = DateSerial(cmbPeriodo.SelectedValue.ToString.Substring(0, 4), cmbPeriodo.SelectedValue.ToString.Substring(4, 2), X - 4)
            Dato = IIf(IsDBNull(dgvExtraAut.Item(X, Y).Value), "", dgvExtraAut.Item(X, Y).Value)
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
                Dato = "FESTIVO"
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
                lblTexto.Text = dgvExtraAut.Item(X, Y).ToolTipText.Trim
            ElseIf Dato = "SA" Then
                'Si el detalle corresponde a un retardo
                lblTexto.Text = dgvExtraAut.Item(X, Y).ToolTipText.Trim
            ElseIf Dato <> "" Then
                'Si el detalle no está en blanco, debe ser un ausentismo
                'dtTemporal = sqlExecute("SELECT fecha,ausentismo.tipo_aus,referencia,tipo_ausentismo.nombre FROM ausentismo LEFT JOIN tipo_ausentismo ON ausentismo.tipo_aus=tipo_ausentismo.TIPO_AUS WHERE reloj = '" & txtReloj.Text & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                'dtTemporal = sqlExecute("SELECT fecha,ausentismo.tipo_aus,referencia,tipo_ausentismo.nombre FROM ausentismo LEFT JOIN tipo_ausentismo ON ausentismo.tipo_aus=tipo_ausentismo.TIPO_AUS WHERE reloj = '" & dgvExtraAut.Item(0, Y).Value & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                dtTemporal = sqlExecute("SELECT fecha,primer_ausentismo.tipo_aus,referencia,tipo_ausentismo.nombre FROM primer_ausentismo LEFT JOIN tipo_ausentismo ON ausentismo.tipo_aus=tipo_ausentismo.TIPO_AUS WHERE reloj = '" & dgvExtraAut.Item(0, Y).Value & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                If dtTemporal.Rows.Count > 0 Then
                    Dato = dtTemporal.Rows(0).Item("nombre")

                    If Not IsDBNull(dtTemporal.Rows(0).Item("referencia")) Then
                        If dtTemporal.Rows(0).Item("referencia").ToString.Trim.Length > 0 Then
                            Dato = Dato & vbCrLf & dtTemporal.Rows(0).Item("referencia")
                        End If
                    End If
                    lblTexto.Text = Dato.Trim
                Else
                    lblTexto.Text = "Sin detalle"
                End If
                'ElseIf Fecha >= FBaja And Fecha <= Now.Date Then
                'Si la fecha seleccionada es posterior a la fecha de baja
                'lblTexto.Text = "INACTIVO" & vbCrLf & "Baja el día " & FBaja
                'ElseIf Fecha < FAlta And Fecha <= Now.Date Then
                'Si la fecha seleccionada es anterior a la fecha de alta
                'lblTexto.Text = "INACTIVO" & vbCrLf & "Alta el día " & FAlta
            ElseIf Dato = "" And Fecha <= Now.Date Then
                'Si el detalle está en blanco, debe ser asistencia
                'dtTemporal = sqlExecute("SELECT dia_entro,dia_salio,entro,salio,comentario FROM asist WHERE reloj= '" & txtReloj.Text & "' AND fecha_entro = '" & FechaSQL(Fecha) & "'", "TA")
                dtTemporal = sqlExecute("SELECT dia_entro,dia_salio,entro,salio,comentario FROM asist WHERE reloj= '" & dgvExtraAut.Item(0, Y).Value & "' AND fecha_entro = '" & FechaSQL(Fecha) & "'", "TA")
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
                pnlAusentismo.Visible = False
                Exit Sub
            End If

            'advSupervisores.SelectedNode


            dtLider = sqlExecute("SELECT '00000' reloj,'Seleccione Team Leader' as nombres union select reloj,rtrim(nombre)+' '+rtrim(apaterno)+' '+rtrim(amaterno) nombres FROM personal where cod_puesto in ('68092','69702') and cod_super = '" & advSupervisores.SelectedNode.TagString & "' and baja is null ORDER BY reloj")
            cmbLider.DataSource = dtLider
            cmbLider.ValueMember = "reloj"
            cmbLider.SelectedIndex = 0
            cmbLider.Columns(0).Visible = False
            cmbLider.Columns(1).StretchToFill = True

            dtSubAusentismo = sqlExecute("select '000' as tipo_sub_aus, 'Seleccione el Subausentismo' as nombre union SELECT tipo_sub_aus,nombre FROM tipo_sub_ausentismo ORDER BY tipo_sub_aus", "TA")
            cmbSubAusentismo.DataSource = dtSubAusentismo
            cmbSubAusentismo.ValueMember = "tipo_sub_aus"
            cmbSubAusentismo.SelectedIndex = 0
            cmbSubAusentismo.Columns(0).Visible = False
            cmbSubAusentismo.Columns(1).StretchToFill = True

            lblReloj.Text = dgvExtraAut.Item(0, Y).Value
            lblFecha.Text = Fecha.ToShortDateString
            txtComentarios.Text = ""

            Dim dtDatosActuales = sqlExecute("select cod_sub_aus, Teamleader, Comentarios from TA.dbo.subAusentismos where reloj = '" & lblReloj.Text & "' and Fecha_AUS = '" & FechaSQL(lblFecha.Text) & "' ")
            If dtDatosActuales.Rows.Count > 0 Then
                If dtDatosActuales.Rows(0).Item("cod_sub_aus").ToString.Trim.Length = 0 Then
                    cmbSubAusentismo.SelectedIndex = 0
                Else
                    cmbSubAusentismo.SelectedValue = dtDatosActuales.Rows(0).Item("cod_sub_aus")
                End If
                If dtDatosActuales.Rows(0).Item("Teamleader").ToString.Trim.Length = 0 Then
                    cmbLider.SelectedIndex = 0
                Else
                    cmbLider.SelectedValue = dtDatosActuales.Rows(0).Item("Teamleader")
                End If
                txtComentarios.Text = dtDatosActuales.Rows(0).Item("Comentarios")
            End If



            'Ubicar el panel de acuerdo a la celda seleccionada
            pnlAusentismo.Left = dgvExtraAut.GetCellDisplayRectangle(X, Y, True).Location.X + dgvExtraAut.Left + 15
            pnlAusentismo.Top = dgvExtraAut.GetCellDisplayRectangle(X, Y, True).Location.Y + dgvExtraAut.Top + 15

            'Si el panel se sale de la pantalla a la derecha o a la izquierda hay que colocarlo donde se alcance a ver sin salirse
            If Me.Right - pnlAusentismo.Left <= 580 Then
                pnlAusentismo.Left = Me.Right - 650
            End If
            If Me.Bottom - pnlAusentismo.Top <= 500 Then
                pnlAusentismo.Top = Me.Bottom - 510
            End If

            'poner el panel visible
            pnlAusentismo.Visible = True

        Catch ex As Exception
            'poner el panel invisible
            pnlAusentismo.Visible = False
        End Try
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim strSql As String = ""
        dgvExtraAut.Rows(lblY.Text).Cells(Convert.ToInt32(lblX.Text)).Value = dgvExtraAut.Rows(lblY.Text).Cells(Convert.ToInt32(lblX.Text)).Value.ToString.Replace("*", "")
        If cmbLider.SelectedValue.ToString = "00000" And cmbSubAusentismo.SelectedValue.ToString = "000" And txtComentarios.Text.Length = 0 Then
            strSql = "delete from TA.dbo.subAusentismos where reloj = '" & lblReloj.Text & "' and Fecha_AUS = '" & FechaSQL(lblFecha.Text) & "'"
            sqlExecute(strSql)
        Else
            strSql = "if exists (select * from ta.dbo.subAusentismos where reloj = '" & lblReloj.Text & "' and Fecha_AUS = '" & FechaSQL(lblFecha.Text) & "') " & _
                                 "   Update TA.dbo.subAusentismos " & _
                                 "      set TeamLeader = '" & IIf(cmbLider.SelectedValue.ToString = "00000", "", cmbLider.SelectedValue.ToString) & "', COD_SUB_AUS = '" & IIf(cmbSubAusentismo.SelectedValue.ToString = "000", "", cmbSubAusentismo.SelectedValue.ToString) & "', Comentarios = '" & txtComentarios.Text & "' " & _
                                 "   where reloj = '" & lblReloj.Text & "' and Fecha_AUS = '" & FechaSQL(lblFecha.Text) & "' " & _
                                 "else " & _
                                 "  insert into ta.dbo.subAusentismos(reloj, COD_SUB_AUS, TeamLeader,Comentarios,Fecha_AUS,Usuario,Fecha) " & _
                                 "  values ('" & lblReloj.Text & "', '" & cmbSubAusentismo.SelectedValue & "', '" & cmbLider.SelectedValue & "','" & txtComentarios.Text & "','" & FechaSQL(lblFecha.Text) & "','" & Usuario & "',getdate())"
            sqlExecute(strSql)
            dgvExtraAut.Rows(lblY.Text).Cells(Convert.ToInt32(lblX.Text)).Value &= "*"
        End If
        pnlAusentismo.Visible = False
    End Sub

    Private Sub dgvExtraAut_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExtraAut.CellEnter
        ActualizarInformacionPanel(e.ColumnIndex, e.RowIndex)
    End Sub

    Private Sub btnCerrarPanel_Click(sender As Object, e As EventArgs) Handles btnCerrarPanel.Click
        pnlAusentismo.Visible = False
    End Sub

    Private Sub frmCapturaSubAusentismo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape And pnlAusentismo.Visible Then
            pnlAusentismo.Visible = False
        End If
    End Sub

    Private Sub dgvExtraAut_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExtraAut.CellDoubleClick
        'if click is on new row or header row
        If e.RowIndex = dgvExtraAut.NewRowIndex Or e.RowIndex < 0 Then
            Exit Sub
        End If
        frmKardexAn.MdiParent = frmMain
        frmKardexAn.WindowState = FormWindowState.Maximized
        frmKardexAn.Show(dgvExtraAut.CurrentRow.Cells("ColumnReloj").Value.ToString.Trim)
        frmKardexAn.Focus()
    End Sub
End Class