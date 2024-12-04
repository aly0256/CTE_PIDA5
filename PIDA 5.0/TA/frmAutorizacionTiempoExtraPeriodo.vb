Public Class frmAutorizacionTiempoExtraPeriodo

    Dim dtMiPersonal As DataTable
    Dim dtColoresAus As DataTable
    Dim filtroGeneral As String
    Dim contadorConPago As Integer
    Dim contadorSinPago As Integer
    Dim oh_visisible As Boolean = False
    Dim reloj_usuario As String = ""
    'Los valores de sbPlanta tienen la planta seleccionada

    Private Sub frmAutorizacionTiempoExtraPeriodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtRelojUsuario As DataTable = sqlExecute("select reloj from appuser where username = '" & Usuario & "' and reloj is not null", "seguridad")
        If dtRelojUsuario.Rows.Count > 0 Then
            reloj_usuario = dtRelojUsuario.Rows(0)("reloj")
        End If
        If My.Computer.Name.Contains("MXJZ") Then
            sbPlanta.Value = True
        Else
            sbPlanta.Value = False
        End If

        '--- Checkbox para marcar y desmarcar todos los empledos        Marzo/21
        chkConfirmarOH.Visible = True
        chkConfirmarOH.Enabled = True
        chkConfirmarOH.Text = "Marcar/Desmarcar a todos los empleados"
        chkConfirmarOH.Location = New Point(4, 4)
        '---

        advSupervisores.Nodes.Clear()

        tabDatos.SelectedTab = SuperTabItem2
        tabDatos.SelectedTab = SuperTabItem1


        dtColoresAus = sqlExecute("select tipo_aus, color_letra, color_back from tipo_ausentismo", "TA")

        Try
            Dim dtPeriodos As DataTable
            dtPeriodos = sqlExecute("select ano+periodo as anoper, ano as ano, periodo as per, convert(char(10), fecha_ini, 103) as fecha_ini,  convert(char(10), fecha_fin, 103) as fecha_fin from periodos where isnull(periodo_especial, 0) = 0", "TA")
            cmbPeriodo.DataSource = dtPeriodos
            cmbPeriodo.ValueMember = "anoper"

            estilos()

            dtiFechaAutorizacion.MonthCalendar.TodayButton.Text = "Hoy"
            dtiFechaAutorizacion.MonthCalendar.DayNames = {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"}
            dtiFechaAutorizacion.MonthCalendar.YearSelectionEnabled = False

            Timer1.Start()

        Catch ex As Exception

        End Try
    End Sub

    Dim estilo_non As DataGridViewCellStyle
    Dim estilo_par As DataGridViewCellStyle

    Dim estilo_bold As Font
    Dim estilo_regular As Font

    Private Sub estilos()
        estilo_non = New DataGridViewCellStyle
        estilo_non.BackColor = Color.White

        estilo_par = New DataGridViewCellStyle
        estilo_par.BackColor = Color.FromArgb(200, 200, 200)

        estilo_bold = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
        estilo_regular = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)

    End Sub
    'Jose R Hdez 2019-Feb-07 opcionalmente no mostrar el primer supervisor
    Public Sub carga_estructura(Optional VerPrimerSupervisor As Boolean = True)
        cmbPeriodo.Enabled = False
        sbPlanta.Enabled = False
        btnRefresh.Enabled = False
        btnReporteAvance.Enabled = False
        'btnReporteExtra.Enabled = False
        btnExtraNO.Enabled = False
        btnPeriodoAnterior.Enabled = False
        btnPeriodoSiguiente.Enabled = False
        advSupervisores.Enabled = False

        Try
            Dim anoper As String = cmbPeriodo.SelectedValue
            Dim dtPeriodo As DataTable = sqlExecute("select * from ta.dbo.periodos where ano+periodo = '" & anoper & "'")
            If dtPeriodo.Rows.Count > 0 Then

                dgvExtraAut.Rows.Clear()
                dgvExtraAut.Columns.Clear()
                dgvNomSem.Rows.Clear()
                advSupervisores.Nodes.Clear()

                dgvExtraAut.Columns.Add(ColumnReloj)
                dgvExtraAut.Columns.Add(ColumnNombre)
                dgvExtraAut.Columns.Add(ColumnTurno)
                dgvExtraAut.Columns.Add(ColumnDepto)
                dgvExtraAut.Columns.Add(ColumnClase)
                dgvExtraAut.Columns.Add(ColumnReporteExt)
                ' - INFORMACION DEL PERIODO A CARGAR

                '--Linea 99
                '---Agregar header a la columna ColumnReporteExt llamado "Seleccion"    28/ene/21   Ernesto
                dgvExtraAut.Columns(5).HeaderCell.Value = "Seleccion"
                ColumnReporteExt.ReadOnly = False
                '---

                Dim fini As Date = dtPeriodo.Rows(0)("fecha_ini")
                Dim ffin As Date = dtPeriodo.Rows(0)("fecha_fin")
                Dim f As Date = fini

                dtiFechaAutorizacion.MinDate = fini
                dtiFechaAutorizacion.MaxDate = ffin


                dtiFechaAutorizacion.Value = Nothing

                ' - CREAR COLUMNAS PARA FECHAS AUTORIZACION PERIODO


                Dim i As Integer = 0
                While f <= ffin
                    Dim c_ausentismo As New DataGridViewColumn()
                    Dim c_real As New DataGridViewColumn()
                    Dim c_autorizado As New DataGridViewColumn()
                    Dim c_depto As New DataGridViewColumn()
                    Dim c_filler As New DataGridViewColumn()

                    c_filler.Name = "FILL" & FechaSQL(f).Replace("-", "")
                    c_filler.HeaderText = ""
                    c_filler.CellTemplate = New DataGridViewTextBoxCell()
                    c_filler.Width = 5
                    c_filler.DefaultCellStyle = estilo_par
                    dgvExtraAut.Columns.Add(c_filler)

                    c_ausentismo.Name = "AUS" & FechaSQL(f).Replace("-", "")
                    c_ausentismo.HeaderText = "Aus." & vbCrLf & f.Day & "/" & MesLetra(f, 3)
                    c_ausentismo.CellTemplate = New DataGridViewTextBoxCell()
                    c_ausentismo.Width = 60
                    c_ausentismo.ReadOnly = True
                    dgvExtraAut.Columns.Add(c_ausentismo)

                    c_real.Name = "TRAB" & FechaSQL(f).Replace("-", "")
                    c_real.HeaderText = "Trab." & vbCrLf & f.Day & "/" & MesLetra(f, 3)
                    c_real.CellTemplate = New DataGridViewTextBoxCell()
                    c_real.Width = 60
                    c_real.ReadOnly = True
                    dgvExtraAut.Columns.Add(c_real)

                    c_autorizado.Name = "AUT" & FechaSQL(f).Replace("-", "")
                    c_autorizado.HeaderText = "Aut." & vbCrLf & f.Day & "/" & MesLetra(f, 3)
                    c_autorizado.CellTemplate = New DataGridViewTextBoxCell()
                    c_autorizado.Width = 60
                    dgvExtraAut.Columns.Add(c_autorizado)

                    ' Por el momento no se utilizará el departamento
                    'c_depto.Name = "DEPTO" & FechaSQL(f).Replace("-", "")
                    'c_depto.HeaderText = "Depto." & vbCrLf & f.Day & "/" & MesLetra(f, 3)
                    'c_depto.CellTemplate = New DataGridViewTextBoxCell()
                    'c_depto.Width = 60
                    'dgvExtraAut.Columns.Add(c_depto)

                    f = f.AddDays(1)
                    i += 1

                End While

                frmTrabajando.Show()
                panelAutorizacion.Enabled = False

                Dim dtSupervisores As New DataTable
                dtSupervisores.Columns.Add("cod_super")
                dtSupervisores.Columns.Add("nombre")
                dtSupervisores.Columns.Add("cuantos")
                dtSupervisores.PrimaryKey = New DataColumn() {dtSupervisores.Columns("cod_super")}


                ' Dim Q1 As String = "select reloj,cod_comp, nombres, cod_planta, cod_turno, cod_hora, cod_depto, cod_clase, isnull(cod_super, '') as cod_super, isnull(nombre_super, 'Sin Supervisor') as nombre_super from personalvw where cod_tipo = 'O' AND alta <= '" & FechaSQL(ffin) & "' and (baja is null or baja >= '" & FechaSQL(fini) & "')   and isnull(cod_super, '') <> '' and cod_planta = '" & IIf(sbPlanta.Value, sbPlanta.ValueTrue, sbPlanta.ValueFalse) & "' order by reloj"

                Dim Q1 As String = "select reloj,cod_comp, nombres, cod_planta, cod_turno, cod_hora, cod_depto, cod_clase, isnull(cod_super, '') as cod_super, isnull(nombre_super, 'Sin Supervisor') as nombre_super from personalvw where cod_tipo = 'O' AND alta <= '" & FechaSQL(ffin) & "' and (baja is null or baja >= '" & FechaSQL(fini) & "')   and isnull(cod_super, '') <> '' order by reloj"

                'Dim Q2 As String = "select distinct reloj,cod_comp, nombres, cod_planta, cod_turno,cod_hora, cod_depto, cod_clase, isnull(cod_super, '') as cod_super, isnull(nombre_super, 'Sin Supervisor') as nombre_super from tavw " & _
                '                              "where cod_tipo = 'O' AND " & IIf(FiltroXUsuario.Length > 0, FiltroXUsuario & " and ", "") & " FHA_ENT_HOR between '" & FechaSQL(fini) & "' and '" & FechaSQL(ffin) & "'  and " & _
                '                              "isnull(cod_super, '') <> '' and COD_PLANTA = '" & IIf(sbPlanta.Value, sbPlanta.ValueTrue, sbPlanta.ValueFalse) & "' " & _
                '                              "and alta <= '" & FechaSQL(ffin) & "' and (baja is null or baja >= '" & FechaSQL(ffin) & "')  order by RELOJ asc"

                Dim Q2 As String = "select distinct reloj,cod_comp, nombres, cod_planta, cod_turno,cod_hora, cod_depto, cod_clase, isnull(cod_super, '') as cod_super, isnull(nombre_super, 'Sin Supervisor') as nombre_super from tavw " & _
                              "where cod_tipo = 'O' AND " & IIf(FiltroXUsuario.Length > 0, FiltroXUsuario & " and ", "") & " FHA_ENT_HOR between '" & FechaSQL(fini) & "' and '" & FechaSQL(ffin) & "'  and " & _
                              "isnull(cod_super, '') <> '' " & _
                              "and alta <= '" & FechaSQL(ffin) & "' and (baja is null or baja >= '" & FechaSQL(ffin) & "')  order by RELOJ asc"

                If fini >= Date.Today Then
                    dtMiPersonal = ConsultaPersonalVW(Q1, False)
                Else

                    dtMiPersonal = sqlExecute(Q2, "TA")
                End If



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
                panelAutorizacion.Enabled = True

                'Jose R Hdez 2019-Feb-07 por default mostrar el primer supervisor
                If VerPrimerSupervisor Then
                    advSupervisores.SelectedNode = n_s.Nodes(0)
                End If

                If ffin >= Date.Now Then
                    chkConfirmarTodo.Enabled = True
                    dgvNomSem.Columns("ColumnConfirmacion").ReadOnly = False
                    dgvExtraAut.ReadOnly = False
                Else
                    Dim dtPeriodoActivo As DataTable = sqlExecute("select ano+periodo as anoper from periodos where ano+periodo = '" & cmbPeriodo.SelectedValue & "' and activo = 1 and isnull(periodo_especial, 0) = 0 order by ano+periodo desc", "TA")
                    If dtPeriodoActivo.Rows.Count > 0 Then
                        chkConfirmarTodo.Enabled = True
                        dgvNomSem.Columns("ColumnConfirmacion").ReadOnly = False
                        dgvExtraAut.ReadOnly = False
                    Else
                        chkConfirmarTodo.Enabled = False
                        dgvNomSem.Columns("ColumnConfirmacion").ReadOnly = True

                        '--Bloquea a la datagriedview si no hay periodo         se cambio de true a false       mar/21
                        dgvExtraAut.ReadOnly = False
                    End If
                End If
            End If

        Catch ex As Exception

        End Try

        cmbPeriodo.Enabled = True
        'EN QTO siempre deshabilitado ya que solo hay una planta 2017/10/10 Acasas
        sbPlanta.Enabled = False
        btnRefresh.Enabled = True
        btnReporteAvance.Enabled = True
        'btnReporteExtra.Enabled = True
        btnExtraNO.Enabled = True
        btnPeriodoAnterior.Enabled = True
        btnPeriodoSiguiente.Enabled = True
        advSupervisores.Enabled = True
    End Sub

    Private Sub ComboTree1_TextChanged(sender As Object, e As EventArgs) Handles cmbPeriodo.TextChanged
        carga_estructura()
    End Sub

    Private Sub sbPlanta_ValueChanged(sender As Object, e As EventArgs) Handles sbPlanta.ValueChanged
        carga_estructura()
    End Sub


    Public Sub cargar_informacion(anoper As String, cod_super As String)
        Try

            Dim dtPeriodo As DataTable = sqlExecute("select * from ta.dbo.periodos where ano+periodo = '" & anoper & "'")
            If dtPeriodo.Rows.Count > 0 Then
                Dim fini As Date = dtPeriodo.Rows(0)("fecha_ini")
                Dim ffin As Date = dtPeriodo.Rows(0)("fecha_fin")


                '--------- CARGA AUTORIZACION TIEMPO EXTRA

                filtroGeneral = IIf(cod_super = "TODOS", "", "cod_super = '" & cod_super & "'")

                dgvExtraAut.Rows.Clear()

                dgvExtraAut.ScrollBars = ScrollBars.None
                Application.DoEvents()

                For Each row As DataRow In dtMiPersonal.Select(filtroGeneral, "reloj")

                    Dim row_id As Integer = dgvExtraAut.Rows.Add()

                    Dim dgrv As DataGridViewRow = dgvExtraAut.Rows(row_id)

                    dgrv.Cells("ColumnReloj").Value = row("reloj")
                    dgrv.Cells("ColumnNombre").Value = row("nombres")
                    dgrv.Cells("ColumnTurno").Value = row("cod_hora")
                    dgrv.Cells("ColumnDepto").Value = row("cod_depto")
                    dgrv.Cells("ColumnClase").Value = row("cod_clase")

                    Dim dtAus As DataTable = sqlExecute("select ausentismo.fecha, ausentismo.tipo_aus from ausentismo where fecha between '" & FechaSQL(fini) & "' and '" & FechaSQL(ffin) & "' and reloj = '" & row("reloj") & "'", "TA")
                    For Each row_ausentismo As DataRow In dtAus.Rows
                        Dim h As String = "AUS" & FechaSQL(row_ausentismo("fecha")).Replace("-", "")
                        dgrv.Cells(h).Value = row_ausentismo("tipo_aus")
                        Try
                            'dgrv.Cells(h).Style.Font = estilo_bold
                            dgrv.Cells(h).Style.BackColor = Color.FromArgb(dtColoresAus.Select("tipo_aus = '" & dgrv.Cells(h).Value & "'")(0)("color_back"))
                            dgrv.Cells(h).Style.ForeColor = Color.FromArgb(dtColoresAus.Select("tipo_aus = '" & dgrv.Cells(h).Value & "'")(0)("color_letra"))

                            'dgrv.Cells("TRAB" & FechaSQL(row_ausentismo("fecha")).Replace("-", "")).Style.Font = estilo_bold
                            'dgrv.Cells("AUT" & FechaSQL(row_ausentismo("fecha")).Replace("-", "")).Style.Font = estilo_bold
                        Catch ex As Exception

                        End Try
                    Next

                    Dim dtTrab As DataTable = sqlExecute("select fha_ent_hor, sum(dbo.htod(horas_extras)) as trabajadas from asist where fha_ent_hor between '" & FechaSQL(fini) & "' and '" & FechaSQL(ffin) & "' and reloj = '" & row("reloj") & "' group by fha_ent_hor", "TA")
                    For Each row_trab As DataRow In dtTrab.Rows
                        Dim h As String = "TRAB" & FechaSQL(row_trab("fha_ent_hor")).Replace("-", "")
                        dgrv.Cells(h).Value = DtoH(row_trab("trabajadas"))
                    Next

                    Dim dtAut As DataTable = sqlExecute("select reloj, fecha, extras_autorizadas from extras_autorizadas where fecha between '" & FechaSQL(fini) & "' and '" & FechaSQL(ffin) & "' and reloj = '" & row("reloj") & "'", "TA")
                    For Each row_aut As DataRow In dtAut.Rows
                        Dim h As String = "AUT" & FechaSQL(row_aut("fecha")).Replace("-", "")
                        dgrv.Cells(h).Value = row_aut("extras_autorizadas")
                    Next

                    Dim dttempo As DataTable = sqlExecute("select * from nomsem where reloj = '" & row("reloj") & "' and ano+periodo = '" & anoper & "' and tran_cerrada = '1'", "TA")
                    If dttempo.Rows.Count > 0 Then
                        Dim f = fini
                        While f <= ffin
                            Dim h As String = "AUT" & FechaSQL(f).Replace("-", "")
                            dgrv.Cells(h).ReadOnly = True
                            f = f.AddDays(1)
                        End While


                    End If


                    Application.DoEvents()
                    'Jose R Hdez 2019-Feb-07 detener cuando cancelen
                    If Not ActivoTrabajando Then
                        carga_estructura(False)
                        Exit Sub
                    End If
                Next

                dgvExtraAut.ScrollBars = ScrollBars.Both
                Application.DoEvents()

                '--------- CARGA APROBACION NOMSEM


                dgvNomSem.Rows.Clear()

                Try
                    dgvNomSem.Columns("ColumnEstatus").HeaderCell.Style.Font = New Font("Wingdings", 12, FontStyle.Bold)
                    dgvNomSem.Columns("ColumnEstatus").HeaderCell.Style.Padding = New Padding(0)
                Catch ex As Exception

                End Try

                dgvNomSem.ScrollBars = ScrollBars.None
                Application.DoEvents()

                Dim todo_confirmado As Boolean = True
                Dim OH_confirmado As Boolean = True
                oh_visisible = False
                For Each row As DataRow In dtMiPersonal.Select(filtroGeneral, "reloj")



                    Dim row_id As Integer = dgvNomSem.Rows.Add()

                    Dim dgrv As DataGridViewRow = dgvNomSem.Rows(row_id)

                    dgrv.Cells("ColumnNomSemReloj").Value = row("reloj")
                    dgrv.Cells("ColumnNomSemNombre").Value = row("nombres")
                    dgrv.Cells("ColumnNomSemTurno").Value = row("cod_turno")
                    dgrv.Cells("ColumnNomSemDepto").Value = row("cod_depto")
                    dgrv.Cells("ColumnNomSemClase").Value = row("cod_clase")
                    dgrv.Cells("colComp").Value = row("cod_comp")

                    Dim ver_bonos As Boolean = False
                    Try
                        Dim clase As String = row("cod_clase")
                        If clase.Contains("D") Or clase.Contains("I") Then
                            ver_bonos = True
                        End If
                    Catch ex As Exception

                    End Try

                    RemoveHandler chkConfirmarTodo.CheckedChanged, AddressOf chkConfirmarTodo_CheckedChanged
                    'RemoveHandler chkConfirmarOH.CheckedChanged, AddressOf chkConfirmarOH_CheckedChanged
                    Dim dtNomSem As DataTable = sqlExecute("select * from nomsem where ano+periodo = '" & anoper & "' and reloj = '" & row("reloj") & "'", "TA")
                    For Each row_nomsem As DataRow In dtNomSem.Rows
                        dgrv.Cells("ColumnHrsNormales").Value = String.Format("{0:00.00}", row_nomsem("hrs_normales") + row_nomsem("hrs_festivo"))
                        dgrv.Cells("ColumnHrsExtra").Value = String.Format("{0:00.00}", row_nomsem("hrs_dobles") + row_nomsem("hrs_triples"))


                        Dim horas_normales As Double = row_nomsem("hrs_normales") + row_nomsem("hrs_festivo")
                        If horas_normales = 0 Then
                            Try
                                dgrv.Cells("ColumnEstatus").Value = New Bitmap(My.Resources.warning_16)
                            Catch ex As Exception

                            End Try
                        Else
                            Try
                                dgrv.Cells("ColumnEstatus").Value = New Bitmap(My.Resources.empty_16)
                            Catch ex As Exception

                            End Try
                        End If

                        Dim q_ausentismo As String = "select reloj, sum(case when ausentismo.tipo_aus = 'FI' then 1 else 0 end) as faltas," & _
                            "sum(case when ausentismo.tipo_aus = 'VAC' then 1 else 0 end) as vacaciones," & _
                                "sum(case when goce_sdo = '1' then 1 else 0 end) as con_pago," & _
                                    "sum(case when goce_sdo = '0' and ausentismo.tipo_aus not in ('VAC', 'FI') then 1 else 0 end) as sin_pago " & _
                                        "from ausentismo left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus  where reloj = '" & row("reloj") & "' and fecha between '" & FechaSQL(fini) & "' and '" & FechaSQL(ffin) & "' group by reloj"

                        Dim dtAusentismo As DataTable = sqlExecute(q_ausentismo, "ta")
                        If dtAusentismo.Rows.Count > 0 Then
                            dgrv.Cells("ColumnDIAFIN").Value = dtAusentismo.Rows(0)("faltas")
                            dgrv.Cells("ColumnVacpago").Value = dtAusentismo.Rows(0)("vacaciones")
                            dgrv.Cells("ColumnConPago").Value = dtAusentismo.Rows(0)("con_pago")
                            dgrv.Cells("ColumnSinPago").Value = dtAusentismo.Rows(0)("sin_pago")
                        End If



                        If IsDBNull(row_nomsem("prima_dom")) Then
                            dgrv.Cells("ColumnPrimaDom").Value = New Bitmap(My.Resources.empty_16)
                        Else
                            If row_nomsem("prima_dom") = 0 Then
                                dgrv.Cells("ColumnPrimaDom").Value = New Bitmap(My.Resources.empty_16)
                            Else
                                dgrv.Cells("ColumnPrimaDom").Value = New Bitmap(My.Resources.Checked16)
                            End If
                        End If
                        If IsDBNull(row_nomsem("prima_sab")) Then
                            dgrv.Cells("ColumnPrimaSab").Value = New Bitmap(My.Resources.empty_16)
                        Else
                            If row_nomsem("prima_sab") = 0 Then
                                dgrv.Cells("ColumnPrimaSab").Value = New Bitmap(My.Resources.empty_16)
                            Else
                                dgrv.Cells("ColumnPrimaSab").Value = New Bitmap(My.Resources.Checked16)
                            End If
                        End If


                        'If ver_bonos Then
                        '    
                        '    dgrv.Cells("ColumnBonPun").Value = String.Format("{0:0.00}", row_nomsem("bono02"))
                        '    dgrv.Cells("ColumnBonDes").Value = String.Format("{0:0.00}", row_nomsem("bono03"))
                        'Else
                        '    dgrv.Cells("ColumnBonAsi").Value = "-"
                        '    dgrv.Cells("ColumnBonPun").Value = "-"
                        '    dgrv.Cells("ColumnBonDes").Value = "-"
                        'End If

                        dgrv.Cells("ColumnConfirmacion").Value = IIf(IIf(IsDBNull(row_nomsem("fecha_firma")), False, True), True, False)

                        If dgrv.Cells("ColumnConfirmacion").Value = True Then
                            ' dgrv.Cells("ColumnConfirmacion").ReadOnly = True

                            dgrv.Cells("ColumnUsuarioFirma").Value = RTrim(row_nomsem("usuario_firma"))
                            dgrv.Cells("ColumnFechaFirma").Value = FechaHoraSQL(DateTime.Parse(row_nomsem("fecha_firma")), False, False)
                        End If

                        If row("cod_comp") = "610" Then
                            todo_confirmado = todo_confirmado And dgrv.Cells("ColumnConfirmacion").Value

                        Else
                            OH_confirmado = OH_confirmado And dgrv.Cells("ColumnConfirmacion").Value
                            oh_visisible = True
                        End If
                        'todo_confirmado = todo_confirmado And dgrv.Cells("ColumnConfirmacion").Value

                    Next

                    chkConfirmarTodo.Checked = todo_confirmado

                    'If chkConfirmarTodo.Checked = True Then
                    '    Dim prueba = row("reloj").ToString
                    '    chkConfirmarTodo.Enabled = False
                    'Else
                    '    chkConfirmarTodo.Enabled = True
                    'End If

                    'If chkConfirmarOH.Checked = True Then
                    '    chkConfirmarOH.Enabled = False
                    'Else
                    '    chkConfirmarOH.Enabled = True
                    'End If


                    AddHandler chkConfirmarTodo.CheckedChanged, AddressOf chkConfirmarTodo_CheckedChanged
                    'AddHandler chkConfirmarOH.CheckedChanged, AddressOf chkConfirmarOH_CheckedChanged



                    'Dim dtVacsPago As DataTable = sqlExecute("select sum(monto) as total from ajustes_nom where ano+periodo = '" & anoper & "' and reloj = '" & row("reloj") & "' and concepto = 'DiasVa'", "nomina")
                    'If dtVacsPago.Rows.Count > 0 Then
                    '    Dim vacs As String = IIf(IsDBNull(dtVacsPago.Rows(0)("total")), 0, dtVacsPago.Rows(0)("total"))
                    '    dgrv.Cells("ColumnVacpago").Value = String.Format("{0:0.00}", vacs)
                    'Else
                    '    dgrv.Cells("ColumnVacpago").Value = String.Format("{0:0.00}", 0)
                    'End If

                    'Dim dtPriTem As DataTable = sqlExecute("select sum(monto) as total from ajustes_nom where ano+periodo = '" & anoper & "' and reloj = '" & row("reloj") & "' and concepto = 'PriTem'", "nomina")
                    'If dtPriTem.Rows.Count > 0 Then
                    '    Dim pritem As String = IIf(IsDBNull(dtPriTem.Rows(0)("total")), 0, dtPriTem.Rows(0)("total"))
                    '    dgrv.Cells("ColumnPriTem").Value = String.Format("{0:0.00}", pritem)
                    'Else
                    '    dgrv.Cells("ColumnPriTem").Value = String.Format("{0:0.00}", 0)
                    'End If



                    Application.DoEvents()
                    'Jose R Hdez 2019-Feb-07 detener cuando cancelen
                    If Not ActivoTrabajando Then
                        carga_estructura(False)
                        Exit Sub
                    End If
                Next

                revisar_colores(fini, ffin, , True)

                dgvNomSem.ScrollBars = ScrollBars.Both
                Application.DoEvents()

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "TA/TE", ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub dgvExtraAut_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvExtraAut.CellBeginEdit
        Dim _reloj As String = dgvExtraAut.Rows(e.RowIndex).Cells("ColumnReloj").Value
        If _reloj.Trim = reloj_usuario.Trim Then
            MessageBox.Show("No es posible realizar ajustes al empleado [" & reloj_usuario & "] asignado al usuario [" & Usuario & "]", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
        End If
    End Sub
    Private Sub dgvExtraAut_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExtraAut.CellEndEdit
        Try
            Dim h As String = dgvExtraAut.Columns(e.ColumnIndex).Name

            If h.Contains("AUT") Then
                Dim _reloj As String = dgvExtraAut.Rows(e.RowIndex).Cells("ColumnReloj").Value
                Dim _fecha As Date = DateSerial(h.Substring(3, 4), h.Substring(7, 2), h.Substring(9, 2))
                Dim _valor As String = dgvExtraAut.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                Dim _trab As String = dgvExtraAut.Rows(e.RowIndex).Cells(h.Replace("AUT", "TRAB")).Value

                Dim aut_trab As Boolean = True
                Dim aut_limite As Boolean = True
                Dim suma_final As Double = 0
                Dim valor_final As String = ""

                'If _valor.ToUpper.Trim = "TODO" Or _valor.ToUpper.Trim = "T" Then
                '    valor_final = "TODO"
                'Else
                If _valor.ToUpper.Trim = "R-30" Or _valor.ToUpper.Trim = "R" Then
                    valor_final = "R-30"
                Else
                    Try
                        _valor = _valor.Replace(":", ".")
                        Dim horas As Double = -1

                        horas = Double.Parse(_valor)


                        If horas >= 0 Then
                            'MCR OCT-26-2020
                            'Solo permitir horas completas
                            'valor_final = MerMilitar(CtoH(_valor))

                            valor_final = MerMilitar(CtoH(Int(_valor)))
                        End If

                    Catch ex As Exception
                        valor_final = ""
                    End Try
                End If

                For Each dr As DataGridViewRow In dgvExtraAut.Rows
                    If _reloj = dr.Cells("ColumnReloj").Value Then
                        For Each cl As DataGridViewColumn In dgvExtraAut.Columns
                            If cl.Name.Contains("AUT") Then
                                Dim _autorizado As String = dr.Cells(cl.Name).Value
                                If _autorizado IsNot Nothing Then
                                    _autorizado = _autorizado.Replace(":", ".")
                                    Dim horas As Double = -1
                                    'horas = Double.Parse(_autorizado)          COMENTADO 4/ENE/20
                                    'horas = IIf(_autorizado = "R-30 ", -1, _autorizado)    agregado pero comentado 5/ene/20
                                    If horas >= 0 Then

                                        'MCR OCT-26-2020
                                        'Solo permitir horas completas
                                        '_autorizado = MerMilitar(CtoH(_autorizado))
                                        _autorizado = MerMilitar(CtoH(Int(_autorizado)))
                                        suma_final += HtoD(_autorizado)
                                    End If
                                End If

                            End If
                        Next
                    End If
                Next

                If valor_final = "R-30" Then
                    aut_trab = False
                Else
                    If _trab <> "" Then
                        If HtoD(_trab) >= HtoD(valor_final) Then
                            aut_trab = False
                        End If
                    End If
                End If

                '---Comentado   29/ene/21
                If valor_final.Trim <> "" Then
                    'dgvExtraAut.Rows(e.RowIndex).Cells("ColumnReporteExt").Value = "True"
                End If

                If valor_final.Trim = "00:00" Or valor_final.Trim = "" Then
                    'dgvExtraAut.Rows(e.RowIndex).Cells("ColumnReporteExt").Value = "False"
                End If


                If aut_limite And aut_trab Then
                    MessageBox.Show("El monto excede el límite máximo de horas a autorizar" & vbNewLine & "Total de horas a autorizar en la semana: " & DtoH(suma_final).ToString & vbNewLine & "Límite de horas: " & Limite_TE, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvExtraAut.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
                Else
                    Dim dtExiste As DataTable = sqlExecute("select * from extras_autorizadas where reloj = '" & _reloj & "' and fecha = '" & FechaSQL(_fecha) & "'", "TA")
                    If dtExiste.Rows.Count <= 0 Then
                        sqlExecute("insert into extras_autorizadas (reloj, fecha, extras_autorizadas, autori_a1) values ('" & _reloj & "', '" & FechaSQL(_fecha) & "', '" & valor_final & "', '1')", "TA")
                    End If

                    sqlExecute("update extras_autorizadas set analizado = '0', autori_a1 = '1', extras_autorizadas = '" & valor_final & "' where reloj = '" & _reloj & "' and fecha = '" & FechaSQL(_fecha) & "'", "TA")

                    'JOSE BITACORA TIEMPO EXTRA
                    bitacora_tiempo_extra(_reloj, _fecha, valor_final)
                    dgvExtraAut.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = valor_final


                    If valor_final.Trim <> "" Then
                        dgvExtraAut.Rows(e.RowIndex).Cells("ColumnReporteExt").Value = "True"
                    End If

                    If valor_final.Trim = "00:00" Or valor_final.Trim = "" Then
                        dgvExtraAut.Rows(e.RowIndex).Cells("ColumnReporteExt").Value = "False"
                    End If


                    revisar_colores(_fecha, _fecha, e.RowIndex)

                    Me.Cursor = Cursors.WaitCursor
                    analisis_independiente(_reloj, _fecha)
                    Me.Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles tabDatos.SelectedTabChanged
        lblTituloPantalla.Text = tabDatos.SelectedTab.Text
        If lblTituloPantalla.Text.Contains("extra") Then
            panelAutorizacion.Visible = True
            btnReporteAutorizacion.Visible = False
            picAyuda.Visible = True
            lblAyuda.Visible = True
            chkConfirmarTodo.Visible = False
            btnReporteAvance.Visible = False

            'btnReporteExtra.Visible = True
            btnExtraNO.Visible = True
            btnReporteExtra.Visible = False          'MODIFICADO     18/ENE/20
        Else
            panelAutorizacion.Visible = False
            btnReporteAutorizacion.Visible = False      'MODIFICADO     18/ENE/20
            picAyuda.Visible = False
            lblAyuda.Visible = False
            chkConfirmarTodo.Visible = True
            btnReporteAvance.Visible = True
            'btnReporteExtra.Visible = False
            btnExtraNO.Visible = False
            btnReporteExtra.Visible = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtHorasAutorizacion.Validating
        Try
            Dim horas As Double = -1
            horas = Double.Parse(txtHorasAutorizacion.Text.Replace(":", "."))
            If horas >= 0 Then
                Dim valor As String = txtHorasAutorizacion.Text.Replace(":", ".")
                txtHorasAutorizacion.Text = MerMilitar(CtoH(txtHorasAutorizacion.Text.Replace(":", ".")))
                btnAutorizarGlobal.Enabled = True
            Else
                btnAutorizarGlobal.Enabled = False
            End If
        Catch ex As Exception
            txtHorasAutorizacion.Text = ""
            btnAutorizarGlobal.Enabled = False
        End Try
    End Sub

    Private Sub txtHorasAutorizacion_Click(sender As Object, e As EventArgs) Handles txtHorasAutorizacion.Click
        Try
            txtHorasAutorizacion.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbTodoElTiempoExtra_CheckedChanged(sender As Object, e As EventArgs) Handles cbTodoElTiempoExtra.CheckedChanged
        Try
            If cbTodoElTiempoExtra.Checked = True Then
                txtHorasAutorizacion.Enabled = False
                btnAutorizarGlobal.Enabled = True
            Else
                txtHorasAutorizacion.Enabled = True
                txtHorasAutorizacion.SelectAll()
                txtHorasAutorizacion.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAutorizarGlobal_Click(sender As Object, e As EventArgs) Handles btnAutorizarGlobal.Click
        Try

            frmTrabajando.Show()
            panelAutorizacion.Enabled = False

            Dim _fecha As Date = dtiFechaAutorizacion.Value
            Dim _valor As String = IIf(cbTodoElTiempoExtra.Checked, "R-30", txtHorasAutorizacion.Text)
            Dim relojes_no_aut As String = ""
            Dim suma_final As Double = 0
            Dim aut_trab As Boolean = True
            Dim mostrar_mensaje As Boolean = False
            Dim aut_limite As Boolean = True
            Dim autorizar_global As Boolean = False
            Dim dtPeriodo As DataTable = sqlExecute("select * from ta.dbo.periodos where ano+periodo = '" & cmbPeriodo.SelectedValue & "'")
            Dim fini_p As Date = dtPeriodo.Rows(0)("fecha_ini")
            Dim ffin_p As Date = dtPeriodo.Rows(0)("fecha_fin")

            If ffin_p >= Date.Now Then
                autorizar_global = True
            Else
                Dim dtPeriodoActivo As DataTable = sqlExecute("select ano+periodo as anoper from periodos where ano+periodo = '" & cmbPeriodo.SelectedValue & "' and activo = 1 and isnull(periodo_especial, 0) = 0 order by ano+periodo desc", "TA")
                If dtPeriodoActivo.Rows.Count > 0 Then
                    autorizar_global = True
                Else
                    autorizar_global = False
                    MessageBox.Show("No es posible autorizar tiempo extra en periodos cerrados.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            '---Para realizar cambios solo en los relojes seleccionados     29/ene/21       Ernesto
            Dim checado_masivo As Boolean

            If autorizar_global Then

                For Each drow As DataGridViewRow In dgvExtraAut.Rows

                    '---A partir de aquí inicia la selección de acuerdo al checkbox de selección        29/ene/21       Ernesto
                    checado_masivo = IIf(drow.Cells("ColumnReporteExt").Value = True, True, False)

                    '---Si está seleccionado, entonces mete los cambios     29/ene/21   Ernesto
                    If checado_masivo Then

                        suma_final = 0
                        aut_trab = True
                        aut_limite = True
                        Dim _reloj As String = drow.Cells("ColumnReloj").Value

                        If _reloj.Trim = reloj_usuario.Trim Then
                            mostrar_mensaje = True
                            Continue For
                        End If
                        Dim _trabajadas As String = RTrim(drow.Cells("TRAB" & FechaSQL(_fecha).Replace("-", "")).Value)

                        Dim valor_final As String = ""


                        For Each cl As DataGridViewColumn In dgvExtraAut.Columns
                            If cl.Name.Contains("AUT") Then
                                '== Cambio 9junio2021       Ernesto
                                Dim _autorizado As String = ""
                                Try
                                    _autorizado = drow.Cells(cl.Name).Value
                                Catch ex As Exception
                                    _autorizado = Nothing
                                End Try
                                '==
                                If _autorizado IsNot Nothing Then
                                    _autorizado = _autorizado.Replace(":", ".")
                                    Dim horas As Double = -1
                                    'horas = Double.Parse(_autorizado)          COMENTADO 4/ENE/20
                                    'horas = horas = IIf(_autorizado = "R-30 ", -1, _autorizado) agregado pero comentado 5/ene/20

                                    If horas >= 0 Then

                                        Dim prueba = CtoH(_autorizado)

                                        _autorizado = MerMilitar(CtoH(_autorizado))
                                        suma_final += HtoD(_autorizado)
                                    End If
                                End If

                            End If
                        Next



                        Dim dttempo As DataTable = sqlExecute("select * from nomsem where reloj = '" & _reloj & "' and ano+periodo = '" & cmbPeriodo.SelectedValue & "' and tran_cerrada = '1'", "TA")
                        If Not dttempo.Rows.Count > 0 Then

                            If _valor.ToUpper.Trim = "R-30" Or _valor.ToUpper.Trim = "T" Then
                                valor_final = "R-30"
                            Else
                                If _trabajadas = "" Then
                                    valor_final = _valor
                                Else
                                    Dim _trab As Double = HtoD(_trabajadas)
                                    Dim _val As Double = HtoD(_valor)

                                    If _trab > _val Then
                                        valor_final = _valor
                                    ElseIf _trab = 0 Then
                                        valor_final = _valor
                                    Else
                                        valor_final = _trabajadas
                                    End If

                                End If
                            End If


                            If valor_final = "R-30" Then
                                aut_trab = False
                            Else
                                If _trabajadas <> "" Then
                                    If HtoD(_trabajadas) >= HtoD(valor_final) Then
                                        aut_trab = False
                                    End If
                                End If
                            End If

                            suma_final = suma_final + HtoD(valor_final)
                            If Limite_TE <> "00:00" Then
                                If suma_final <= HtoD(Limite_TE) Then
                                    aut_limite = False
                                End If
                            Else
                                aut_limite = False
                            End If

                            If aut_limite And aut_trab Then
                                '  MessageBox.Show("El monto excede el limite maximo de horas a autorizar" & vbNewLine & "Total de horas a autorizar en la semana: " & DtoH(suma_final).ToString & vbNewLine & "Limite de horas: " & Limite_TE, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                relojes_no_aut = relojes_no_aut & _reloj & vbNewLine
                            Else


                                Dim dtExiste As DataTable = sqlExecute("select * from extras_autorizadas where reloj = '" & _reloj & "' and fecha = '" & FechaSQL(_fecha) & "'", "TA")
                                If dtExiste.Rows.Count <= 0 Then
                                    sqlExecute("insert into extras_autorizadas (reloj, fecha, extras_autorizadas, autori_a1) values ('" & _reloj & "', '" & FechaSQL(_fecha) & "', '" & valor_final & "', '1')", "TA")
                                End If

                                sqlExecute("update extras_autorizadas set autori_a1 = '1', analizado = '0', extras_autorizadas = '" & valor_final & "' where reloj = '" & _reloj & "' and fecha = '" & FechaSQL(_fecha) & "'", "TA")
                                'JOSE BITACORA TIEMPO EXTRA
                                bitacora_tiempo_extra(_reloj, _fecha, valor_final)
                                drow.Cells("AUT" & FechaSQL(_fecha).Replace("-", "")).Value = valor_final

                                '---Comentado 29/ene/21
                                If valor_final.Trim <> "" Then
                                    'drow.Cells("ColumnReporteExt").Value = "True"
                                End If

                                If valor_final.Trim = "00:00" Or valor_final.Trim = "" Then
                                    'drow.Cells("ColumnReporteExt").Value = "False"
                                End If



                                frmTrabajando.lblAvance.Text = _reloj
                                Application.DoEvents()
                            End If
                        End If
                    End If
                Next

            End If
            If mostrar_mensaje Then
                MessageBox.Show("No se realizaron ajustes al empleado [" & reloj_usuario & "] asignado al usuario [" & Usuario & "]", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
            frmTrabajando.lblAvance.Text = "Procesando"
            revisar_colores(_fecha, _fecha)


            ActivoTrabajando = False
            frmTrabajando.Close()
            panelAutorizacion.Enabled = True


            If relojes_no_aut <> "" Then
                MessageBox.Show("Los siguentes empleados excedierón el tiempo extra límite para autorizar : " & vbNewLine & relojes_no_aut, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub revisar_colores(fini As Date, ffin As Date, Optional fila As Integer = -1, Optional cargaestructura As Boolean = False)
        'For Each row As DataGridViewRow In dgvExtraAut.Rows
        Dim f As Date = fini
        While f <= ffin

            Dim _f_t As String = FechaSQL(f).Replace("-", "")

            If fila > -1 Then
                revisar_colores_aux(_f_t, dgvExtraAut.Rows(fila))
                Application.DoEvents()
            Else
                For Each dgv_row As DataGridViewRow In dgvExtraAut.Rows
                    revisar_colores_aux(_f_t, dgv_row)
                    Application.DoEvents()
                Next
            End If
            'Jose R Hdez 2019-Feb-07 detener cuando cancelen
            If Not ActivoTrabajando And cargaestructura Then
                carga_estructura(False)
                Exit Sub
            End If
            f = f.AddDays(1)

        End While
        'Next
    End Sub

    Public Sub revisar_colores_aux(_f_t As String, dgv_row As DataGridViewRow)
        Try
            Dim reales_t As String = dgv_row.Cells("TRAB" & _f_t).Value
            Dim autorizadas_t As String = RTrim(dgv_row.Cells("AUT" & _f_t).Value)

            If autorizadas_t = "TODO" Or autorizadas_t = "R-30" Then
                Dim reales As Double = HtoD(reales_t)
                If reales > 0 Then
                    dgv_row.Cells("TRAB" & _f_t).Style.BackColor = Color.FromArgb(204, 245, 204)
                    dgv_row.Cells("AUT" & _f_t).Style.BackColor = Color.FromArgb(204, 245, 204)
                Else
                    dgv_row.Cells("TRAB" & _f_t).Style.BackColor = Color.FromArgb(204, 204, 245)
                    dgv_row.Cells("AUT" & _f_t).Style.BackColor = Color.FromArgb(204, 204, 245)
                End If
            Else
                Try
                    Dim reales As Double = HtoD(reales_t)
                    Dim autorizadas As Double = HtoD(autorizadas_t)

                    If reales > 0 Then
                        If reales - autorizadas = 0 Then
                            dgv_row.Cells("TRAB" & _f_t).Style.BackColor = Color.FromArgb(204, 245, 204)
                            dgv_row.Cells("AUT" & _f_t).Style.BackColor = Color.FromArgb(204, 245, 204)
                        ElseIf reales - autorizadas < 0 Then
                            dgv_row.Cells("TRAB" & _f_t).Style.BackColor = Color.White
                            dgv_row.Cells("AUT" & _f_t).Style.BackColor = Color.White
                        ElseIf autorizadas = 0 Then
                            dgv_row.Cells("TRAB" & _f_t).Style.BackColor = Color.FromArgb(245, 204, 204)
                            dgv_row.Cells("AUT" & _f_t).Style.BackColor = Color.FromArgb(245, 204, 204)
                        ElseIf reales - autorizadas > 0 Then
                            dgv_row.Cells("TRAB" & _f_t).Style.BackColor = Color.FromArgb(245, 245, 204)
                            dgv_row.Cells("AUT" & _f_t).Style.BackColor = Color.FromArgb(245, 245, 204)
                        End If
                    ElseIf autorizadas > 0 Then
                        dgv_row.Cells("TRAB" & _f_t).Style.BackColor = Color.FromArgb(204, 204, 245)
                        dgv_row.Cells("AUT" & _f_t).Style.BackColor = Color.FromArgb(204, 204, 245)
                    Else
                        dgv_row.Cells("TRAB" & _f_t).Style.BackColor = Color.White
                        dgv_row.Cells("AUT" & _f_t).Style.BackColor = Color.White
                    End If

                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Stop()

            Dim dtPeriodoActivo As DataTable = sqlExecute("select ano+periodo as anoper from periodos where activo = 1 and  isnull(periodo_especial, 0) = 0 order by ano+periodo desc", "TA")
            If dtPeriodoActivo.Rows.Count > 0 Then
                Dim activo As String = dtPeriodoActivo.Rows(0)("anoper")
                cmbPeriodo.SelectedValue = activo
                Application.DoEvents()
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub AdvTree1_SelectionChanged(sender As Object, e As EventArgs) Handles advSupervisores.SelectionChanged
        frmTrabajando.Show()
        panelAutorizacion.Enabled = False

        Try

            tabDatos.Enabled = False

            Dim cod_super As String = advSupervisores.SelectedNode.Tag
            cargar_informacion(cmbPeriodo.SelectedValue, cod_super)

            tabDatos.Enabled = True

        Catch ex As Exception

        End Try

        ActivoTrabajando = False
        frmTrabajando.Close()
        panelAutorizacion.Enabled = True
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles btnPeriodoAnterior.Click
        Try
            Dim PeriodoSeleccionado As String = cmbPeriodo.SelectedValue
            Dim dtPeriodos As DataTable = sqlExecute("select ano, periodo from periodos where isnull(periodo_especial, '0') = '0' and ano + periodo < '" & PeriodoSeleccionado & "' order by ano + periodo desc", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                PeriodoSeleccionado = dtPeriodos.Rows(0)("ANO") & dtPeriodos.Rows(0)("PERIODO")
                cmbPeriodo.SelectedValue = PeriodoSeleccionado
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnPeriodoSiguiente.Click
        Try
            Dim PeriodoSeleccionado As String = cmbPeriodo.SelectedValue
            Dim dtPeriodos As DataTable = sqlExecute("select ano, periodo from periodos where isnull(periodo_especial, '0') = '0' and ano + periodo > '" & PeriodoSeleccionado & "' order by ano + periodo asc", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                PeriodoSeleccionado = dtPeriodos.Rows(0)("ANO") & dtPeriodos.Rows(0)("PERIODO")
                cmbPeriodo.SelectedValue = PeriodoSeleccionado
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub picAyuda_Click(sender As Object, e As EventArgs)
        Try
            Dim frm As New frmFoto
            frm.Text = "Código de colores"
            frm.Size = New Size(700, 400)
            frm.picFoto.Image = Image.FromFile(PathFoto & "AyudaExtraGrande.png")
            frm.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvNomSem_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNomSem.CellContentDoubleClick
        Try

            'frmTrabajando.Show()
            'Application.DoEvents()

            'Dim _reloj As String = dgvNomSem.Rows(e.RowIndex).Cells("ColumnNomSemReloj").Value

            'frmTA.MdiParent = frmMain
            'frmTA.Show()
            'frmTA.cmbPeriodos.SelectedValue = "201701"
            'frmTA.cmbPeriodos.SelectedValue = cmbPeriodo.SelectedValue
            'frmTA.dtPersonal = sqlExecute("select * from personalvw where reloj = '" & _reloj & "'")
            'frmTA.MostrarInformacion(_reloj)
            'frmTA.Focus()

            'ActivoTrabajando = False
            'frmTrabajando.Close()
            frmTrabajando.Show()
            Application.DoEvents()
            desdeTE = True
            Dim _reloj As String = dgvNomSem.Rows(e.RowIndex).Cells("ColumnNomSemReloj").Value
            frmTA.MdiParent = frmMain
            frmTA.Show()

            ' frmTA.cmbPeriodos.SelectedValue = "201701"
            frmTA.cmbPeriodos.SelectedValue = cmbPeriodo.SelectedValue
            '   frmTA.dtPersonal = sqlExecute("select * from personalvw where reloj = '" & _reloj & "'")
            frmTA.iniciardesdeTE(_reloj)
            frmTA.Focus()

            ActivoTrabajando = False
            frmTrabajando.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvExtraAut_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExtraAut.CellContentDoubleClick
        Try

            'If dgvExtraAut.Columns(e.ColumnIndex).ReadOnly = True Then
            '    frmTrabajando.Show()
            '    Application.DoEvents()

            '    Dim _reloj As String = dgvExtraAut.Rows(e.RowIndex).Cells("ColumnReloj").Value

            '    frmTA.MdiParent = frmMain
            '    frmTA.Show()
            '    frmTA.cmbPeriodos.SelectedValue = "201701"
            '    frmTA.cmbPeriodos.SelectedValue = cmbPeriodo.SelectedValue
            '    frmTA.dtPersonal = sqlExecute("select * from personalvw where reloj = '" & _reloj & "'")
            '    frmTA.MostrarInformacion(_reloj)
            '    frmTA.Focus()

            '    ActivoTrabajando = False
            '    frmTrabajando.Close()

            'End If
            If dgvExtraAut.Columns(e.ColumnIndex).ReadOnly = True Then
                frmTrabajando.Show()
                Application.DoEvents()
                desdeTE = True
                Dim _reloj As String = dgvExtraAut.Rows(e.RowIndex).Cells("ColumnReloj").Value

                frmTA.MdiParent = frmMain
                frmTA.Show()
                '  frmTA.cmbPeriodos.SelectedValue = "201701"
                frmTA.cmbPeriodos.SelectedValue = cmbPeriodo.SelectedValue
                frmTA.iniciardesdeTE(_reloj)
                frmTA.Focus()

                ActivoTrabajando = False
                frmTrabajando.Close()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvNomSem_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNomSem.CellEndEdit
        Try
            'If dgvNomSem.Columns(e.ColumnIndex).Name = "ColumnConfirmacion" Then
            '    Dim valor As Boolean = dgvNomSem.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            '    If valor Then
            '        Dim _reloj As String = dgvNomSem.Rows(e.RowIndex).Cells("ColumnNomSemReloj").Value
            '        Dim _ano_periodo As String = cmbPeriodo.SelectedValue.ToString
            '        sqlExecute("update nomsem set tran_cerrada = 1, usuario_firma = '" & Usuario & "', fecha_firma = getdate() where reloj = '" & _reloj & "' and ano + periodo = '" & _ano_periodo & "'", "TA")

            '        dgvNomSem.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            '        dgvNomSem.Rows(e.RowIndex).Cells("ColumnUsuarioFirma").Value = Usuario
            '        dgvNomSem.Rows(e.RowIndex).Cells("ColumnFechaFirma").Value = FechaHoraSQL(Now, False, False)

            '    End If

            'End If

            If dgvNomSem.Columns(e.ColumnIndex).Name = "ColumnConfirmacion" Then
                Dim valor As Boolean = dgvNomSem.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

                If valor Then
                    Dim _reloj As String = dgvNomSem.Rows(e.RowIndex).Cells("ColumnNomSemReloj").Value
                    Dim _ano_periodo As String = cmbPeriodo.SelectedValue.ToString
                    sqlExecute("update nomsem set tran_cerrada = 1, usuario_firma = '" & Usuario & "', fecha_firma = getdate() where reloj = '" & _reloj & "' and ano + periodo = '" & _ano_periodo & "'", "TA")

                    'dgvNomSem.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                    dgvNomSem.Rows(e.RowIndex).Cells("ColumnUsuarioFirma").Value = Usuario
                    dgvNomSem.Rows(e.RowIndex).Cells("ColumnFechaFirma").Value = FechaHoraSQL(Now, False, False)
                Else
                    Dim _reloj As String = dgvNomSem.Rows(e.RowIndex).Cells("ColumnNomSemReloj").Value
                    Dim _ano_periodo As String = cmbPeriodo.SelectedValue.ToString
                    sqlExecute("update nomsem set tran_cerrada = 0, usuario_firma = null, fecha_firma = null where reloj = '" & _reloj & "' and ano + periodo = '" & _ano_periodo & "'", "TA")

                    'dgvNomSem.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                    dgvNomSem.Rows(e.RowIndex).Cells("ColumnUsuarioFirma").Value = ""
                    dgvNomSem.Rows(e.RowIndex).Cells("ColumnFechaFirma").Value = ""
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    '--PARA LOS EMPLEADOS       MARZO/21
    Private Sub chkConfirmarOH_CheckedChanged(sender As Object, e As EventArgs) Handles chkConfirmarOH.CheckedChanged
        Try

            If chkConfirmarOH.Checked = True Then
                For Each drow As DataGridViewRow In dgvExtraAut.Rows
                    drow.Cells("ColumnReporteExt").Value = True
                Next
            ElseIf chkConfirmarOH.Checked = False Then
                For Each drow As DataGridViewRow In dgvExtraAut.Rows
                    drow.Cells("ColumnReporteExt").Value = False
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkConfirmarTodo_CheckedChanged(sender As Object, e As EventArgs) ' Handles chkConfirmarTodo.CheckedChanged

        Try

            If chkConfirmarTodo.Checked = True Then
                If MessageBox.Show("¿Desea marcar como confirmados todos los registros de los empleados en la lista para la compañia BRP?", "Confirmar todo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    frmTrabajando.Show()
                    Application.DoEvents()

                    For Each dgrv As DataGridViewRow In dgvNomSem.Rows
                        If dgrv.Cells("colComp").Value = "610" Then
                            dgrv.Cells("ColumnConfirmacion").Value = True
                            Dim _reloj As String = dgrv.Cells("ColumnNomSemReloj").Value
                            Dim _ano_periodo As String = cmbPeriodo.SelectedValue.ToString
                            sqlExecute("update nomsem set tran_cerrada = 1, usuario_firma = '" & Usuario & "', fecha_firma = getdate() where reloj = '" & _reloj & "' and ano + periodo = '" & _ano_periodo & "' and fecha_firma is null", "TA")
                        End If
                    Next

                    ActivoTrabajando = False
                    frmTrabajando.Close()

                    'chkConfirmarTodo.Enabled = False
                Else

                    chkConfirmarTodo.Checked = False
                End If
            ElseIf chkConfirmarTodo.Checked = False Then
                If MessageBox.Show("¿Desea marcar como no confirmados todos los registros de los empleados en la lista para la compañia BRP?", "Confirmar todo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    frmTrabajando.Show()
                    Application.DoEvents()

                    For Each dgrv As DataGridViewRow In dgvNomSem.Rows
                        If dgrv.Cells("colComp").Value = "610" Then
                            dgrv.Cells("ColumnConfirmacion").Value = False
                            Dim _reloj As String = dgrv.Cells("ColumnNomSemReloj").Value
                            Dim _ano_periodo As String = cmbPeriodo.SelectedValue.ToString
                            sqlExecute("update nomsem set tran_cerrada = 0, usuario_firma = null, fecha_firma = null where reloj = '" & _reloj & "' and ano + periodo = '" & _ano_periodo & "' and fecha_firma is not null", "TA")
                        End If
                    Next

                    ActivoTrabajando = False
                    frmTrabajando.Close()

                    'chkConfirmarTodo.Enabled = False
                Else

                    chkConfirmarTodo.Checked = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReporteAvance_Click(sender As Object, e As EventArgs) Handles btnReporteAvance.Click
        Try

            Dim MaxFHAFirm As DateTime = Nothing
            Dim FHAFirm As DateTime = Nothing
            Dim dtPeriodo As DataTable = sqlExecute("select * from ta.dbo.periodos where ano+periodo = '" & cmbPeriodo.SelectedValue & "'")
            If dtPeriodo.Rows.Count > 0 Then

                frmTrabajando.Show()
                Application.DoEvents()

                Dim fini As Date = dtPeriodo.Rows(0)("fecha_ini")
                Dim ffin As Date = dtPeriodo.Rows(0)("fecha_fin")

                '   Dim dtPersonalReporte As DataTable = ConsultaPersonalVW("select reloj, nombres, cod_planta, cod_turno, cod_depto, cod_clase, isnull(cod_super, '') as cod_super, isnull(nombre_super, 'Sin Supervisor') as nombre_super from personalvw where alta <= '" & FechaSQL(ffin) & "' and (baja is null or baja >= '" & FechaSQL(fini) & "') and cod_comp in ('610') and isnull(cod_super, '') <> '' and  cod_planta = '" & IIf(sbPlanta.Value, sbPlanta.ValueTrue, sbPlanta.ValueFalse) & "' order by cod_super, reloj", False)

                Dim dtPersonalReporte As DataTable = ConsultaPersonalVW("select reloj, nombres, cod_planta, cod_turno, cod_depto, cod_clase, isnull(cod_super, '') as cod_super, isnull(nombre_super, 'Sin Supervisor') as nombre_super from personalvw where alta <= '" & FechaSQL(ffin) & "' and (baja is null or baja >= '" & FechaSQL(fini) & "') and cod_comp in ('WME') and isnull(cod_super, '') <> '' order by cod_super, reloj", False)

                Dim dtAvanceSupervisores As New DataTable
                dtAvanceSupervisores.Columns.Add("ano")
                dtAvanceSupervisores.Columns.Add("periodo")
                dtAvanceSupervisores.Columns.Add("fecha_ini")
                dtAvanceSupervisores.Columns.Add("fecha_fin")
                dtAvanceSupervisores.Columns.Add("cod_planta")
                dtAvanceSupervisores.Columns.Add("cod_super")
                dtAvanceSupervisores.Columns.Add("nombre_super")
                dtAvanceSupervisores.Columns.Add("empleados", Type.GetType("System.Int32"))
                dtAvanceSupervisores.Columns.Add("confirmados", Type.GetType("System.Int32"))
                dtAvanceSupervisores.Columns.Add("fecha_firma", Type.GetType("System.DateTime"))
                dtAvanceSupervisores.Columns.Add("avance", Type.GetType("System.Double"))
                dtAvanceSupervisores.Columns.Add("hrsnor", Type.GetType("System.Double"))
                dtAvanceSupervisores.Columns.Add("hrsext", Type.GetType("System.Double"))
                dtAvanceSupervisores.PrimaryKey = New DataColumn() {dtAvanceSupervisores.Columns("cod_planta"), dtAvanceSupervisores.Columns("cod_super")}

                Dim todos As Integer = 0

                For Each row As DataRow In dtPersonalReporte.Rows
                    Dim cod_planta As String = ""
                    Dim cod_super As String = ""
                    Dim dtinfoasist As DataTable = sqlExecute("select reloj, COD_PLANTA, COD_TURNO, COD_DEPTO, COD_CLASE,  isnull(asist.cod_super, '') as cod_super from asist where reloj = '" & row("reloj") & "' " & _
                                                          " and fha_ent_hor between '" & FechaSQL(fini) & "' and '" & FechaSQL(ffin) & "'", "TA")
                    Application.DoEvents()

                    If dtinfoasist.Rows.Count > 0 Then
                        cod_planta = IIf(IsDBNull(dtinfoasist.Rows(0).Item("cod_planta")), row("cod_planta"), dtinfoasist.Rows(0).Item("cod_planta"))
                        cod_super = IIf(IsDBNull(dtinfoasist.Rows(0).Item("cod_super")), row("cod_super"), dtinfoasist.Rows(0).Item("cod_super"))
                    Else
                        cod_planta = row("cod_planta")
                        cod_super = row("cod_super")
                    End If


                    Dim drow As DataRow = dtAvanceSupervisores.Rows.Find({cod_planta, cod_super})
                    todos += 1
                    Dim dtConfirmado As DataTable = sqlExecute("select * from nomsem where ano + periodo = '" & cmbPeriodo.SelectedValue & "' and reloj = '" & row("reloj") & "' and fecha_firma is not null", "ta")
                    Dim dtNomsemEmpleado As DataTable = sqlExecute("select * from nomsem where ano + periodo = '" & cmbPeriodo.SelectedValue & "' and reloj = '" & row("reloj") & "'", "ta")
                    If drow Is Nothing Then
                        drow = dtAvanceSupervisores.NewRow

                        drow("cod_planta") = cod_planta
                        drow("cod_super") = cod_super


                        drow("ano") = cmbPeriodo.SelectedValue.ToString.Substring(0, 4)
                        drow("periodo") = cmbPeriodo.SelectedValue.ToString.Substring(4, 2)
                        drow("fecha_ini") = fini
                        drow("fecha_fin") = ffin

                        'drow("cod_planta") = row("cod_planta")
                        'drow("cod_super") = row("cod_super")
                        drow("empleados") = 1
                        drow("confirmados") = 0
                        drow("hrsnor") = 0
                        drow("hrsext") = 0
                        If IIf(sbPlanta.Value, sbPlanta.ValueTrue, sbPlanta.ValueFalse) = drow("cod_planta") Then
                            dtAvanceSupervisores.Rows.Add(drow)
                        End If

                        If dtConfirmado.Rows.Count > 0 Then
                            MaxFHAFirm = dtConfirmado.Rows(0)("Fecha_Firma")
                            drow("Fecha_Firma") = MaxFHAFirm
                        End If
                        If dtNomsemEmpleado.Rows.Count > 0 Then
                            drow("hrsnor") = dtNomsemEmpleado.Rows(0)("hrs_normales") + dtNomsemEmpleado.Rows(0)("hrs_festivo")
                            drow("hrsext") = dtNomsemEmpleado.Rows(0)("hrs_dobles") + dtNomsemEmpleado.Rows(0)("hrs_triples")
                        End If

                    Else
                        If dtConfirmado.Rows.Count > 0 Then
                            FHAFirm = dtConfirmado.Rows(0)("Fecha_Firma")
                            If FHAFirm > MaxFHAFirm Then MaxFHAFirm = FHAFirm
                            drow("Fecha_Firma") = MaxFHAFirm
                        End If
                        If dtNomsemEmpleado.Rows.Count > 0 Then
                            drow("hrsnor") += dtNomsemEmpleado.Rows(0)("hrs_normales") + dtNomsemEmpleado.Rows(0)("hrs_festivo")
                            drow("hrsext") += dtNomsemEmpleado.Rows(0)("hrs_dobles") + dtNomsemEmpleado.Rows(0)("hrs_triples")
                        End If

                        Dim empleados As Integer = drow("empleados")
                        drow("empleados") += 1
                    End If

                    If dtConfirmado.Rows.Count > 0 Then
                        Dim confirmados As Integer = drow("confirmados")
                        drow("confirmados") += 1
                    End If

                Next

                Dim dSuper As DataTable = sqlExecute("select distinct cod_super, nombre from super where cod_comp in ('610')")

                For Each row As DataRow In dtAvanceSupervisores.Rows

                    Application.DoEvents()

                    Try
                        row("nombre_super") = dSuper.Select("cod_super = '" & row("cod_super") & "'")(0)("nombre")
                    Catch ex As Exception

                    End Try

                    row("avance") = (row("confirmados") / row("empleados")) * 100
                Next

                ActivoTrabajando = False
                frmTrabajando.Close()

                frmVistaPrevia.LlamarReporte("Avance autorización", dtAvanceSupervisores)
                frmVistaPrevia.Show()

            End If

        Catch ex As Exception

            ActivoTrabajando = False
            frmTrabajando.Close()

        End Try
    End Sub



    Private Sub ButtonX3_Click(sender As Object, e As EventArgs)
        Try
            Dim dtExtraAutorizado As New DataTable

            dtExtraAutorizado.Columns.Add("reloj")
            dtExtraAutorizado.Columns.Add("nombre")
            dtExtraAutorizado.Columns.Add("fecha")
            dtExtraAutorizado.Columns.Add("cod_depto")
            dtExtraAutorizado.Columns.Add("cod_turno")
            dtExtraAutorizado.Columns.Add("colonia")
            dtExtraAutorizado.Columns.Add("ruta")
            dtExtraAutorizado.Columns.Add("cod_planta")
            dtExtraAutorizado.Columns.Add("tipo_autorizacion")
            dtExtraAutorizado.Columns.Add("autorizado")
            dtExtraAutorizado.Columns.Add("comentario")
            dtExtraAutorizado.Columns.Add("desde")
            dtExtraAutorizado.Columns.Add("hasta")

            frmTrabajando.Show()
            Application.DoEvents()

            For Each dgvr As DataGridViewRow In dgvExtraAut.Rows

                Application.DoEvents()

                Dim _reloj As String = dgvr.Cells("ColumnReloj").Value
                Dim _nombre As String = dgvr.Cells("ColumnNombre").Value
                Dim _cod_depto As String = dgvr.Cells("ColumnDepto").Value
                Dim _cod_turno As String = dgvr.Cells("ColumnTurno").Value


                For Each column As DataGridViewColumn In dgvExtraAut.Columns

                    Application.DoEvents()

                    If column.Name.Contains("AUT") Then
                        Dim _autorizado As String = dgvr.Cells(column.Name).Value
                        Dim _fecha As String = column.Name.Replace("AUT", "")


                        If _autorizado IsNot Nothing Then

                            Dim _trabajadas As String = dgvr.Cells("TRAB" & _fecha).Value
                            If _trabajadas Is Nothing Then
                                _trabajadas = "00:00"
                            End If

                            Dim drow As DataRow = dtExtraAutorizado.NewRow

                            drow("reloj") = _reloj
                            drow("nombre") = _nombre
                            drow("cod_turno") = RTrim(_cod_turno)
                            drow("cod_depto") = _cod_depto

                            Try
                                Dim dtColonia As DataTable = sqlExecute("select nombre_colonia from personalvw where reloj = '" & _reloj & "'")
                                If dtColonia.Rows.Count > 0 Then
                                    drow("colonia") = RTrim(dtColonia.Rows(0)("nombre_colonia"))
                                End If
                            Catch ex As Exception
                                drow("colonia") = ""
                            End Try

                            Try
                                Dim dtRuta As DataTable = sqlExecute("select * from detalle_auxiliares where reloj = '" & _reloj & "' and campo = 'RUTA' and contenido is not null")
                                If dtRuta.Rows.Count > 0 Then
                                    drow("ruta") = " + " & RTrim(dtRuta.Rows(0)("contenido"))
                                End If
                            Catch ex As Exception
                                drow("ruta") = ""
                            End Try

                            Try
                                Dim _f_f As String = ""
                                _f_f &= _fecha.Substring(0, 4) & "-"
                                _f_f &= _fecha.Substring(4, 2) & "-"
                                _f_f &= _fecha.Substring(6, 2)
                                drow("fecha") = _f_f
                            Catch ex As Exception

                            End Try


                            '  drow("cod_planta") = IIf(sbPlanta.Value = False, "Planta 1", "Planta 2")
                            drow("cod_planta") = "Planta"

                            If RTrim(_autorizado) = "TODO" Then
                                drow("tipo_autorizacion") = RTrim(_autorizado)
                            Else
                                drow("tipo_autorizacion") = "LIMITE"
                            End If

                            If RTrim(_autorizado) = "TODO" Then
                                drow("autorizado") = _trabajadas
                            Else
                                drow("autorizado") = RTrim(_autorizado)
                            End If

                            dtExtraAutorizado.Rows.Add(drow)
                        End If

                    End If
                Next


            Next

            ActivoTrabajando = False
            frmTrabajando.Close()

            'frmVistaPrevia.LlamarReporte("Tiempo extra autorizado", dtExtraAutorizado)
            'frmVistaPrevia.Show()

            Dim frm As New frmCondicionesReporteTextra
            frm.dtDatosReportes = dtExtraAutorizado

            frm.fini = dtiFechaAutorizacion.MinDate
            frm.ffin = dtiFechaAutorizacion.MaxDate

            frm.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        carga_estructura()
    End Sub

    Private Sub btnReporteAutorizacion_Click(sender As Object, e As EventArgs) Handles btnReporteAutorizacion.Click
        Try


            Dim dtPeriodo As DataTable = sqlExecute("select * from ta.dbo.periodos where ano+periodo = '" & cmbPeriodo.SelectedValue & "'")
            Dim cod_super As String = advSupervisores.SelectedNode.Tag



            If cod_super = "TODOS" Then
                MessageBox.Show("Este reporte solamente puede ser generado por supervisor", "Seleccione un supervisor", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim filtro As String = "cod_super = '" & cod_super & "' AND cod_comp = '610'"
                Dim filtro_text As String = RTrim(advSupervisores.SelectedNode.Text.Split("-")(0))

                Dim dtReporteAutorizacion As New DataTable
                dtReporteAutorizacion.Columns.Add("reloj", Type.GetType("System.String"))
                dtReporteAutorizacion.Columns.Add("ano", Type.GetType("System.String"))
                dtReporteAutorizacion.Columns.Add("periodo", Type.GetType("System.String"))
                dtReporteAutorizacion.Columns.Add("nombres", Type.GetType("System.String"))
                dtReporteAutorizacion.Columns.Add("confirm", Type.GetType("System.Int32"))
                dtReporteAutorizacion.Columns.Add("usuario", Type.GetType("System.String"))
                dtReporteAutorizacion.Columns.Add("filtro", Type.GetType("System.String"))

                dtReporteAutorizacion.Columns.Add("cod_turno", Type.GetType("System.String"))
                dtReporteAutorizacion.Columns.Add("alta", Type.GetType("System.String"))

                dtReporteAutorizacion.Columns.Add("hrsnor", Type.GetType("System.Double"))
                dtReporteAutorizacion.Columns.Add("hrsext", Type.GetType("System.Double"))

                dtReporteAutorizacion.Columns.Add("bono01", Type.GetType("System.String"))
                dtReporteAutorizacion.Columns.Add("bono02", Type.GetType("System.String"))
                dtReporteAutorizacion.Columns.Add("bono03", Type.GetType("System.String"))
                dtReporteAutorizacion.Columns.Add("pritem", Type.GetType("System.Double"))

                dtReporteAutorizacion.Columns.Add("diasva", Type.GetType("System.Int32"))
                dtReporteAutorizacion.Columns.Add("fecha_firma", Type.GetType("System.String"))
                dtReporteAutorizacion.Columns.Add("depto", Type.GetType("System.String"))

                Dim anoper As String = cmbPeriodo.SelectedValue

                For Each row As DataRow In dtMiPersonal.Select(filtro, "reloj")
                    Dim txtQry As String = "select Reloj, (Ano + Periodo) as Periodos, Fecha_Firma from nomsem where ano + periodo = '" & cmbPeriodo.SelectedValue & "' and reloj = '" & row("reloj") & "'"
                    Dim dtFirma As DataTable = sqlExecute(txtQry, "ta")

                    Dim dtNomsemEmpleado As DataTable = sqlExecute("select nomsem.*,personalvw.cod_depto, personalvw.cod_turno, personalvw.alta, personalvw.cod_tipo, case when fecha_firma is null then 0 else 1 end as confirm, rtrim(isnull(usuario_firma, '')) as usuario_auth, personalvw.nombres from nomsem left join personal.dbo.personalvw on personalvw.reloj = nomsem.reloj where nomsem.reloj = '" & row("reloj") & "' and nomsem.ano+nomsem.periodo = '" & anoper & "'", "TA")

                    If dtNomsemEmpleado.Rows.Count > 0 Then
                        Dim drow As DataRow = dtReporteAutorizacion.NewRow

                        drow("reloj") = dtNomsemEmpleado.Rows(0)("reloj")
                        drow("ano") = dtNomsemEmpleado.Rows(0)("ano")
                        drow("periodo") = dtNomsemEmpleado.Rows(0)("periodo")
                        drow("nombres") = dtNomsemEmpleado.Rows(0)("nombres")
                        drow("depto") = dtNomsemEmpleado.Rows(0)("cod_depto")
                        drow("cod_turno") = dtNomsemEmpleado.Rows(0)("cod_turno")
                        drow("alta") = FechaSQL(dtNomsemEmpleado.Rows(0)("alta"))

                        drow("confirm") = dtNomsemEmpleado.Rows(0)("confirm")
                        drow("filtro") = filtro_text

                        drow("hrsnor") = dtNomsemEmpleado.Rows(0)("hrs_normales") + dtNomsemEmpleado.Rows(0)("hrs_festivo")
                        drow("hrsext") = dtNomsemEmpleado.Rows(0)("hrs_dobles") + dtNomsemEmpleado.Rows(0)("hrs_triples")
                        drow("Fecha_Firma") = IIf(IsDBNull(dtFirma.Rows.Item(0)("Fecha_Firma")), "", dtFirma.Rows.Item(0)("Fecha_Firma").ToString)

                        Dim tipo As String = RTrim(dtNomsemEmpleado.Rows(0)("cod_tipo"))
                        If tipo = "O" Then
                            drow("bono01") = dtNomsemEmpleado.Rows(0)("bono01")
                            drow("bono02") = dtNomsemEmpleado.Rows(0)("bono02")
                            drow("bono03") = dtNomsemEmpleado.Rows(0)("bono03")
                        Else
                            drow("bono01") = ""
                            drow("bono02") = ""
                            drow("bono03") = ""
                        End If

                        drow("usuario") = dtNomsemEmpleado.Rows(0)("usuario_auth")

                        Dim dtVacsPago As DataTable = sqlExecute("select sum(monto) as total from ajustes_nom where ano+periodo = '" & anoper & "' and reloj = '" & row("reloj") & "' and concepto = 'DiasVa'", "nomina")
                        If dtVacsPago.Rows.Count > 0 Then
                            Dim vacs As Integer = IIf(IsDBNull(dtVacsPago.Rows(0)("total")), 0, dtVacsPago.Rows(0)("total"))
                            drow("diasva") = vacs
                        Else
                            drow("diasva") = 0
                        End If

                        Dim dtPriTem As DataTable = sqlExecute("select sum(monto) as total from ajustes_nom where ano+periodo = '" & anoper & "' and reloj = '" & row("reloj") & "' and concepto = 'PriTem'", "nomina")
                        If dtPriTem.Rows.Count > 0 Then
                            Dim pritem As String = IIf(IsDBNull(dtPriTem.Rows(0)("total")), 0, dtPriTem.Rows(0)("total"))
                            drow("pritem") = pritem
                        Else
                            drow("pritem") = 0
                        End If

                        dtReporteAutorizacion.Rows.Add(drow)
                    End If

                Next

                frmVistaPrevia.LlamarReporte("Resumen de autorización semanal", dtReporteAutorizacion)
                frmVistaPrevia.Show()
            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExtraNO_Click(sender As Object, e As EventArgs) Handles btnExtraNO.Click
        Try
            Dim dtExtraAutorizado As New DataTable

            dtExtraAutorizado.Columns.Add("reloj")
            dtExtraAutorizado.Columns.Add("nombre")
            dtExtraAutorizado.Columns.Add("fecha")
            dtExtraAutorizado.Columns.Add("cod_depto")
            dtExtraAutorizado.Columns.Add("cod_turno")
            dtExtraAutorizado.Columns.Add("trabajado")
            dtExtraAutorizado.Columns.Add("autorizado")
            dtExtraAutorizado.Columns.Add("ano")
            dtExtraAutorizado.Columns.Add("periodo")


            frmTrabajando.Show()
            Application.DoEvents()

            Dim anoper As String = cmbPeriodo.SelectedValue

            For Each dgvr As DataGridViewRow In dgvExtraAut.Rows

                Application.DoEvents()

                Dim _reloj As String = dgvr.Cells("ColumnReloj").Value
                Dim _nombre As String = dgvr.Cells("ColumnNombre").Value
                Dim _cod_depto As String = dgvr.Cells("ColumnDepto").Value
                Dim _cod_turno As String = dgvr.Cells("ColumnTurno").Value

                Dim _trabajado As String = ""
                Dim _autorizado As String = ""

                For Each column As DataGridViewColumn In dgvExtraAut.Columns

                    Application.DoEvents()

                    If column.Name.Contains("TRAB") Then
                        _trabajado = dgvr.Cells(column.Name).Value
                        Dim _fecha As String = column.Name.Replace("TRAB", "")


                        If _trabajado IsNot Nothing Then

                            _autorizado = dgvr.Cells("AUT" & _fecha).Value
                            If _autorizado Is Nothing Then
                                _autorizado = "00:00"
                            End If



                        Else
                            _autorizado = dgvr.Cells("AUT" & _fecha).Value
                            If _autorizado Is Nothing Then
                                Continue For
                            Else
                                _trabajado = "00:00"
                            End If
                        End If

                        Dim drow As DataRow = dtExtraAutorizado.NewRow

                        drow("reloj") = _reloj
                        drow("nombre") = _nombre
                        drow("cod_turno") = RTrim(_cod_turno)
                        drow("cod_depto") = _cod_depto

                        drow("trabajado") = _trabajado
                        drow("autorizado") = _autorizado

                        drow("ano") = anoper.Substring(0, 4)
                        drow("periodo") = anoper.Substring(4, 2)

                        Try
                            Dim _f_f As String = ""
                            _f_f &= _fecha.Substring(0, 4) & "-"
                            _f_f &= _fecha.Substring(4, 2) & "-"
                            _f_f &= _fecha.Substring(6, 2)
                            drow("fecha") = _f_f
                        Catch ex As Exception

                        End Try


                        If HtoD(_trabajado) > 0 Or HtoD(_autorizado) > 0 Then
                            dtExtraAutorizado.Rows.Add(drow)
                        End If

                    End If
                Next


            Next

            ActivoTrabajando = False
            frmTrabajando.Close()

            frmVistaPrevia.LlamarReporte("Tiempo extra no autorizado", dtExtraAutorizado)
            frmVistaPrevia.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Try

            Dim dtcompa As DataTable = sqlExecute("select * from cias order by cod_comp desc")
            Dim compa As String = ""

            For Each dr As DataRow In dtcompa.Rows
                compa = dr("cod_comp")
                contadorSinPago = 0
                contadorConPago = 0

                Dim dtResumen As DataTable = New DataTable
                dtResumen.Columns.Add("reloj")
                dtResumen.Columns.Add("prioridad", Type.GetType("System.Double"))
                dtResumen.Columns.Add("concepto")
                dtResumen.Columns.Add("nombre_concepto")
                dtResumen.Columns.Add("valor", Type.GetType("System.Double"))
                dtResumen.Columns.Add("usuario")
                dtResumen.Columns.Add("encabezado")

                Dim usuario_reporte As String = ""
                Dim dtUsuario As DataTable = sqlExecute("select * from appuser where username = '" & Usuario.Trim & "'", "seguridad")
                If dtUsuario.Rows.Count > 0 Then
                    usuario_reporte = RTrim(dtUsuario.Rows(0)("nombre"))
                Else
                    usuario_reporte = "USUARIO NO IDENTIFICADO"
                End If

                frmTrabajando.Show()

                Dim dtPeriodo As DataTable = sqlExecute("select * from periodos where ano+periodo = '" & cmbPeriodo.SelectedValue & "'", "TA")
                Dim f_ini As Date = dtPeriodo.Rows(0)("fecha_ini")
                Dim f_fin As Date = dtPeriodo.Rows(0)("fecha_fin")

                Dim encabezado As String = dtPeriodo.Rows(0)("ano") & "-" & dtPeriodo.Rows(0)("periodo") & " (" & "Del " & FechaSQL(f_ini).Replace("-", "/") & " al " & FechaSQL(f_fin).Replace("-", "/") & ")"

                If dtPeriodo.Rows.Count > 0 Then

                    For Each row1 As DataRow In dtMiPersonal.Select("cod_comp = '" & compa & "'")

                        Application.DoEvents()
                        Dim vacaciones As Integer
                        Dim anoper As String = cmbPeriodo.SelectedValue
                        Dim r As String = row1("reloj")

                        'CONSULTA DIAS DE VACACIONES**************************************************************************************************************
                        Dim q_ausentismo As String = "select reloj, sum(case when ausentismo.tipo_aus = 'VAC' then 1 else 0 end) as vacaciones from ausentismo left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus  where reloj = '" & r & "' and  CONVERT(varchar(10), year(FECHA))+PERIODO = '" & anoper & "' group by reloj"

                        'Guarda los dias de vacaciones en variable 'vacaciones'**************************************************************************************************************
                        Dim dtAusentismo As DataTable = sqlExecute(q_ausentismo, "ta")
                        If dtAusentismo.Rows.Count > 0 Then
                            vacaciones = Convert.ToInt32(dtAusentismo.Rows(0)("vacaciones"))
                        End If

                        'Verifica si hay algun pago (hrs normales, hrs dobles, hrs triples, hrs festivo vacaciones, prima sab, prima dom)**************************************************************************************************************
                        Dim dtNomsem1 As DataTable = sqlExecute("select * from nomsem where reloj = '" & r & "' and ano+periodo = '" & cmbPeriodo.SelectedValue & "'", "TA")
                        If dtNomsem1.Rows.Count > 0 Then
                            Dim suma As Double = Convert.ToDouble(vacaciones) + Convert.ToDouble(dtNomsem1.Rows(0)("hrs_normales")) + Convert.ToDouble(dtNomsem1.Rows(0)("hrs_dobles")) + Convert.ToDouble(dtNomsem1.Rows(0)("hrs_triples")) + Convert.ToDouble(dtNomsem1.Rows(0)("PRIMA_SAB")) + Convert.ToDouble(dtNomsem1.Rows(0)("PRIMA_DOM")) + Convert.ToDouble(dtNomsem1.Rows(0)("HRS_FESTIVO"))
                            If (suma = 0) Then
                                contadorSinPago += 1
                            Else
                                contadorConPago += 1
                            End If

                        End If
                    Next

                    For Each row As DataRow In dtMiPersonal.Select("cod_comp = '" & compa & "'")
                        Application.DoEvents()

                        Dim r As String = row("reloj")

                        Dim dtNomsem As DataTable = sqlExecute("select * from nomsem where reloj = '" & r & "' and ano+periodo = '" & cmbPeriodo.SelectedValue & "'", "TA")
                        If dtNomsem.Rows.Count > 0 Then
                            dtResumen.Rows.Add({r, 0, "CON_PAGO", "Empleados con pago", contadorConPago, usuario_reporte, encabezado})
                            dtResumen.Rows.Add({r, 1, "SIN_PAGO", "Empleados sin pago", contadorSinPago, usuario_reporte, encabezado})
                            ' dtResumen.Rows.Add({r, 2, "HRS_EXTRAS", "Horas extras autorizadas", dtNomsem.Rows(0)("hrs_dobles") + dtNomsem.Rows(0)("hrs_triples"), usuario_reporte, encabezado})
                            dtResumen.Rows.Add({r, 2, "hrs_dobles", "Horas extras autorizadas dobles", dtNomsem.Rows(0)("hrs_dobles"), usuario_reporte, encabezado})
                            dtResumen.Rows.Add({r, 3, "HRS_TRIPLES", "Horas extras autorizadas triples", dtNomsem.Rows(0)("hrs_triples"), usuario_reporte, encabezado})
                            dtResumen.Rows.Add({r, 4, "HRS_FEL", "Horas festivas laboradas", dtNomsem.Rows(0)("hrs_fel"), usuario_reporte, encabezado})
                            dtResumen.Rows.Add({r, 5, "HRS_NOPAG", "Horas permiso sin goce de sueldo", dtNomsem.Rows(0)("hrs_nopag"), usuario_reporte, encabezado})
                            dtResumen.Rows.Add({r, 6, "HRS_RETARDO", "Horas retardo", dtNomsem.Rows(0)("hrs_retardo"), usuario_reporte, encabezado})
                            dtResumen.Rows.Add({r, 7, "PRIMA_SAB", "Prima sabatina", dtNomsem.Rows(0)("PRIMA_SAB"), usuario_reporte, encabezado})
                            dtResumen.Rows.Add({r, 8, "PRIMA_DOM", "Prima dominical", dtNomsem.Rows(0)("PRIMA_DOM"), usuario_reporte, encabezado})
                        End If

                        Dim dtAusentismo As DataTable = sqlExecute("select * from asist where reloj = '" & r & "' and ano+periodo=" & cmbPeriodo.SelectedValue & " and tipo_aus = 'FI'", "TA")
                        If dtAusentismo.Rows.Count > 0 Then
                            dtResumen.Rows.Add({r, 0, "DIAFIN", "xyz", dtAusentismo.Rows.Count, usuario_reporte, encabezado})
                        End If

                        Dim dtAusentismo50 As DataTable = sqlExecute("select * from asist where reloj = '" & r & "' and ano+periodo=" & cmbPeriodo.SelectedValue & " and tipo_aus = 'C50'", "TA")
                        If dtAusentismo50.Rows.Count > 0 Then
                            dtResumen.Rows.Add({r, 0, "DIAC50", "xyz", dtAusentismo50.Rows.Count, usuario_reporte, encabezado})
                        End If

                        Dim dtAjustesNom As DataTable = sqlExecute("select * from ajustes_nom where reloj = '" & r & "' and ano+periodo = '" & cmbPeriodo.SelectedValue & "' and tipo_periodo = 'S' and fecha_incidencia is not null", "nomina")
                        For Each row_ajustes As DataRow In dtAjustesNom.Rows
                            dtResumen.Rows.Add({r, 1000, row_ajustes("concepto"), "xyz", row_ajustes("monto"), usuario_reporte, encabezado})
                        Next

                    Next

                    Dim dtNombresConceptos As DataTable = sqlExecute("select rtrim(concepto) as concepto, isnull(prioridad, 1) as prioridad, rtrim(nombre) as nombre from conceptos", "nomina")
                    dtNombresConceptos.PrimaryKey = New DataColumn() {dtNombresConceptos.Columns("concepto")}

                    For Each row As DataRow In dtResumen.Select("nombre_concepto = 'xyz'")
                        Application.DoEvents()
                        Dim r_nombre As DataRow = dtNombresConceptos.Rows.Find({RTrim(row("concepto"))})
                        If r_nombre Is Nothing Then
                            row("nombre_concepto") = row("concepto")
                            row("prioridad") = 1999
                        Else
                            row("nombre_concepto") = r_nombre("nombre")
                            row("prioridad") = row("prioridad") + r_nombre("prioridad")
                        End If
                    Next


                    ActivoTrabajando = False
                    frmTrabajando.Close()



                    frmVistaPrevia.LlamarReporte("Resumen de autorización", dtResumen, compa)
                    frmVistaPrevia.ShowDialog(Me)

                End If
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            ActivoTrabajando = False
            frmTrabajando.Close()
        End Try
    End Sub

    Private Sub btnReporteExtra_Click(sender As Object, e As EventArgs) Handles btnReporteExtra.Click
        Try
            Dim dtExtraAutorizado As New DataTable

            dtExtraAutorizado.Columns.Add("reloj")
            dtExtraAutorizado.Columns.Add("nombre")
            dtExtraAutorizado.Columns.Add("fecha")
            dtExtraAutorizado.Columns.Add("cod_depto")
            dtExtraAutorizado.Columns.Add("cod_turno")
            dtExtraAutorizado.Columns.Add("colonia")
            dtExtraAutorizado.Columns.Add("ruta")
            dtExtraAutorizado.Columns.Add("cod_planta")
            dtExtraAutorizado.Columns.Add("tipo_autorizacion")
            dtExtraAutorizado.Columns.Add("autorizado")
            dtExtraAutorizado.Columns.Add("comentario")
            dtExtraAutorizado.Columns.Add("desde")
            dtExtraAutorizado.Columns.Add("hasta")
            dtExtraAutorizado.Columns.Add("super")
            dtExtraAutorizado.Columns.Add("cod_area")
            dtExtraAutorizado.Columns.Add("nombre_area")
            dtExtraAutorizado.Columns.Add("Hrs_Trabajadas")
            dtExtraAutorizado.Columns.Add("Hrs_Pagar")
            dtExtraAutorizado.Columns.Add("cod_super")
            frmTrabajando.Show()
            Application.DoEvents()

            For Each dgvr As DataGridViewRow In dgvExtraAut.Rows

                Application.DoEvents()

                Dim _reloj As String = dgvr.Cells("ColumnReloj").Value
                Dim _nombre As String = dgvr.Cells("ColumnNombre").Value
                Dim _cod_depto As String = dgvr.Cells("ColumnDepto").Value
                Dim _cod_turno As String = dgvr.Cells("ColumnTurno").Value


                Dim _reporte As String = dgvr.Cells("ColumnReporteExt").Value
                Dim _generar_reporte As Boolean = False
                Try
                    _generar_reporte = Boolean.Parse(RTrim(_reporte))
                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "1" & Me.Name, ex.HResult, ex.Message)
                End Try

                If _generar_reporte Then
                    For Each column As DataGridViewColumn In dgvExtraAut.Columns

                        Application.DoEvents()

                        If column.Name.Contains("AUT") Then
                            Dim _autorizado As String = dgvr.Cells(column.Name).Value
                            Dim _fecha As String = column.Name.Replace("AUT", "")


                            If _autorizado IsNot Nothing Then

                                Dim _trabajadas As String = dgvr.Cells("TRAB" & _fecha).Value
                                If _trabajadas Is Nothing Then
                                    _trabajadas = "00:00"
                                End If

                                Dim drow As DataRow = dtExtraAutorizado.NewRow
                                frmTrabajando.lblAvance.Text = "RELOJ -" & _reloj.ToString
                                drow("reloj") = _reloj
                                drow("nombre") = _nombre
                                drow("cod_turno") = RTrim(_cod_turno)
                                drow("cod_depto") = _cod_depto
                                drow("Hrs_Trabajadas") = _trabajadas
                                Try
                                    Dim dtColonia As DataTable = sqlExecute("select cod_super,ISNULL(nombre_colonia,'') as nombre_colonia, cod_area, nombre_area, nombre_super from personalvw where reloj = '" & _reloj & "'")
                                    If dtColonia.Rows.Count > 0 Then
                                        drow("colonia") = RTrim(dtColonia.Rows(0)("nombre_colonia"))
                                        drow("cod_area") = RTrim(dtColonia.Rows(0)("cod_area"))
                                        drow("nombre_area") = RTrim(dtColonia.Rows(0)("nombre_area"))
                                        drow("super") = RTrim(dtColonia.Rows(0)("nombre_super"))
                                        drow("cod_super") = RTrim(dtColonia.Rows(0)("cod_super"))
                                    End If
                                Catch ex As Exception
                                    drow("colonia") = ""
                                    drow("cod_area") = ""
                                    drow("nombre_area") = ""
                                    drow("super") = ""
                                End Try


                                Dim _f_f As String = ""
                                Try
                                    _f_f &= _fecha.Substring(0, 4) & "-"
                                    _f_f &= _fecha.Substring(4, 2) & "-"
                                    _f_f &= _fecha.Substring(6, 2)
                                    drow("fecha") = _f_f
                                Catch ex As Exception
                                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "2" & Me.Name, ex.HResult, ex.Message)
                                End Try

                                Try
                                    Dim temp As DataTable = sqlExecute("select ruta from extras_autorizadas where reloj = '" & _reloj & "' and fecha= '" & FechaSQL(_f_f) & "'", "TA")
                                    If temp.Rows.Count > 0 Then
                                        If IsDBNull(temp.Rows(0)("ruta")) Then
                                            Dim dtRuta As DataTable = sqlExecute("select * from detalle_auxiliares where reloj = '" & _reloj & "' and campo = 'RUTA' and contenido is not null")
                                            If dtRuta.Rows.Count > 0 Then
                                                drow("ruta") = " + " & RTrim(dtRuta.Rows(0)("contenido"))
                                            End If
                                        Else
                                            drow("ruta") = temp.Rows(0)("ruta")
                                        End If
                                    End If

                                Catch ex As Exception
                                    drow("ruta") = ""
                                End Try

                                '    drow("cod_planta") = IIf(sbPlanta.Value = False, "Juárez 1", "Juárez 2")

                                drow("cod_planta") = "Woll"

                                If RTrim(_autorizado) = "TODO" Then
                                    drow("tipo_autorizacion") = RTrim(_autorizado)
                                Else
                                    drow("tipo_autorizacion") = "LIMITE"
                                End If

                                If RTrim(_autorizado) = "TODO" Then
                                    drow("autorizado") = _trabajadas
                                Else
                                    drow("autorizado") = RTrim(_autorizado)
                                End If

                                If _trabajadas = "00:00" Then drow("Hrs_Pagar") = "00:00" Else If RTrim(_autorizado) < RTrim(_trabajadas) Then drow("Hrs_Pagar") = _autorizado Else If RTrim(_trabajadas) < RTrim(_autorizado) Then drow("Hrs_Pagar") = _trabajadas

                                dtExtraAutorizado.Rows.Add(drow)
                            End If

                        End If
                    Next
                End If

            Next

            ActivoTrabajando = False
            frmTrabajando.Close()

            'frmVistaPrevia.LlamarReporte("Tiempo extra autorizado", dtExtraAutorizado)
            'frmVistaPrevia.Show()

            Dim frm As New frmCondicionesReporteTextra
            frm.dtDatosReportes = dtExtraAutorizado

            frm.fini = dtiFechaAutorizacion.MinDate
            frm.ffin = dtiFechaAutorizacion.MaxDate

            frm.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub advSupervisores_Click(sender As Object, e As EventArgs) Handles advSupervisores.Click

    End Sub

    Private Sub dgvNomSem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNomSem.CellContentClick

    End Sub
End Class