Imports DevComponents.DotNetBar.Schedule
Imports DevComponents.Schedule.Model
Imports System.IO

Public Class frmTA

    'MCR 2017-10-06
    'Periodo SEMANAL
    'Dim tipo_periodo = "S"

    Dim TablaTemporal As DataTable                '12/dic/20 para pruebas
    Dim salidaAnt As Boolean                      '12/dic/20  

    Dim TipoPeriodoEmpleado As String

    Dim Comp As String

    Public dtPersonal As New DataTable
    Dim dtTemp As New DataTable
    Dim dtPeriodos As New DataTable
    Dim dtAsist As New DataTable
    Dim dtNomSem As New DataTable
    Dim dtDias As New DataTable
    Dim dtAusentismo As New DataTable
    Dim dtTipoAusentismo As New DataTable
    Dim dtCambiosAus As DataTable
    Dim dtCambiosHrsBrt As New DataTable
    Dim dtCiasTA As New DataTable
    Dim dtHistorialHB As New DataTable
    Dim dtTipoTransaccion As New DataTable
    Dim dtCafeteria As New DataTable


    Dim IniciaLunes As Boolean
    Dim Periodo As String
    Dim Año As String

    Dim PeriodoActivo As String
    Dim FechaIniPeriodo As Date
    Dim FechaFinPeriodo As Date

    Dim Editar As Boolean
    Dim Acumulado As String
    Dim CambiaHoras As Boolean  'Bandera para saber si se modificaron las horas, o se debe utilizar las calculadas

    Public ValorUnico As String
    Public AgregarHrsBrt As Boolean
    Public DesdeCalendario As Boolean

    Dim TransaccionCerrada As Boolean = False

    Dim FontBold = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
    Dim FontRegular = New Font("Microsoft Sans Serif", 9)

    Dim Iniciando As Boolean = True

    '== Variable para table de tipo faltas      abril 2021      Ernesto
    Dim dtFaltasTipo As New DataTable

    '==Variable para guardar o editar faltas justificadas o injustificadas      2sep2021
    Dim var_just As Boolean = True

    Private Function FiltrosAcumulados() As String
        Dim FL As String
        Dim i As Integer
        Dim FiltrosAsist As String = "" 'Filtros por asistencia
        Dim FiltrosTran As String = ""  'Filtros por transacciones
        Dim FiltrosActivo As String = ""
        Dim FiltrosBaja As String = ""
        Dim A As String
        Dim P As String
        Try
            If cmbPeriodos.SelectedValue Is Nothing Then
                Return ""
            End If
            A = cmbPeriodos.SelectedValue.ToString.Substring(0, 4)
            P = cmbPeriodos.SelectedValue.ToString.Substring(4, 2)
            lstFiltros.Items.Clear()
            FL = ""
            For i = 0 To NFiltros - 1
                If Filtros(1, i) = "ACTIVOS" Then
                    FiltrosActivo = " AND (" & Filtros(2, i) & ")"
                ElseIf Filtros(1, i) = "BAJAS" Then
                    FiltrosBaja = " AND (" & Filtros(2, i) & ")"
                Else
                    FL = FL & " AND (" & Filtros(2, i) & ")"
                End If
                lstFiltros.Items.Add(Filtros(2, i))
            Next
            If FL.Length > 0 Then
                FL = " AND reloj IN (SELECT DISTINCT reloj FROM ta.dbo.tavw WHERE ((ano = '" & A & "' AND periodo = '" & P & "') OR periodo IS NULL) AND reloj = PersonalVW.reloj " & FL & ")"
            End If

            If chkFiltroChequeos.Checked Then
                FiltrosAsist = " AND reloj IN (SELECT reloj FROM TA.dbo.hrs_brt WHERE reloj = PersonalVW.reloj AND ano = '" & A & "' AND periodo = '" & P & "') "
            ElseIf chkFiltroError.Checked Then
                FiltrosAsist = " AND reloj IN (SELECT reloj FROM ta.dbo.asist WHERE reloj = PersonalVW.reloj AND ano = '" & A & "' AND periodo = '" & P & _
                    "' AND ((entro is null or RTRIM(entro) = '') or (salio is null or rtrim(salio) = '')))"
            End If

            If chkFiltroAbiertas.Checked Then
                FiltrosTran = " AND reloj IN (SELECT reloj FROM TA.dbo.nomsem WHERE reloj = PersonalVW.reloj AND ano = '" & A & "' AND periodo = '" & P & _
                    "' AND (tran_cerrada IS NULL OR tran_cerrada = 0))"
            ElseIf chkFiltroCerradas.Checked Then
                FiltrosTran = " AND reloj IN (SELECT reloj FROM TA.dbo.nomsem WHERE reloj = PersonalVW.reloj AND ano = '" & A & "' AND periodo = '" & P & _
                    "' AND (tran_cerrada = 1))"
            End If

            FL = FiltrosActivo & FiltrosBaja & FL & FiltrosAsist & FiltrosTran
        Catch ex As Exception
            FL = "ERROR"
        End Try

        Return FL
    End Function


    Private EditarAusentismo As Boolean = True
    Private EditarHorasParaNomina As Boolean = True
    Private EditarRegistros As Boolean = True


    Private Sub frmTa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F12 Then
                btnBuscar.PerformClick()
            ElseIf e.KeyCode = Keys.F5 Then
                btnAnalisis.RaiseClick()
            ElseIf e.KeyCode = Keys.PageDown Then
                btnNext.PerformClick()
            ElseIf e.KeyCode = Keys.PageUp Then
                btnPrev.PerformClick()
            ElseIf e.KeyCode = Keys.Home Then
                btnFirst.PerformClick()
            ElseIf e.KeyCode = Keys.End Then
                btnLast.PerformClick()
            ElseIf e.KeyCode = Keys.M Then
                chkNotaUsuario.Checked = Not chkNotaUsuario.Checked
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmTA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.KeyPreview = True

        Dim dtPermisosTA As DataTable = sqlExecute("select * from permisos_ta where cod_perfil " & Perfil & "", "seguridad")
        dgAsist.AutoGenerateColumns = False

        Dim dtFiltroPerfil As New DataTable
        Dim FiltroAusentismo As String = ""

        For Each row As DataRow In dtPermisosTA.Rows
            Try
                If RTrim(row("tipo")) = "T" Then
                    Dim tab As DevComponents.DotNetBar.BaseItem = tbInfo.Tabs(RTrim(row("control")))
                    tab.Visible = IIf(IsDBNull(row("acceso")), 0, row("acceso"))
                ElseIf RTrim(row("tipo")) = "B" Then
                    Dim button As DevComponents.DotNetBar.BaseItem = rbnAcciones.Items(RTrim(row("control")))
                    button.Visible = IIf(IsDBNull(row("acceso")), 0, row("acceso"))
                ElseIf RTrim(row("tipo")) = "E" Then
                    Select Case RTrim(row("control"))
                        Case "EditarAusentismo"
                            EditarAusentismo = IIf(IsDBNull(row("acceso")), 0, row("acceso"))
                        Case "EditarHorasParaNomina"
                            EditarHorasParaNomina = IIf(IsDBNull(row("acceso")), 0, row("acceso"))
                        Case "EditarRegistros"
                            EditarRegistros = IIf(IsDBNull(row("acceso")), 0, row("acceso"))
                    End Select
                End If

            Catch ex As Exception

            End Try
        Next


        Dim x As Integer
        Dim A As String
        Dim B As Integer
        Dim T As Integer
        Dim itTransaccion As DevComponents.DotNetBar.ButtonItem
        'Dim itTransaccion As DevComponents.DotNetBar.CheckBoxItem


        '== Para los botones de excepcion y correcciones            27sep2021
        Dim QBotones As String = "SELECT * FROM TA.dbo.tipo_transaccion ORDER BY tipo_tran"

        If Perfil.Contains("SUPERV") Or Perfil.Contains("LIDER") Then
            QBotones = "select * from TA.dbo.tipo_transaccion where nombre not in ('SISTEMA','EXCEPCION HORARIO MASIVO','TIEMPO COMPLETO MASIVO')"
        End If

        'Dim itTransaccion As DevComponents.DotNetBar.CheckBoxItem
        Try
            '== Modificado          27sep2021
            dtTipoTransaccion = sqlExecute(QBotones)

            For Each dRow As DataRow In dtTipoTransaccion.Rows
                itTransaccion = New DevComponents.DotNetBar.ButtonItem
                itTransaccion.Text = dRow("nombre")
                itTransaccion.Visible = True
                itTransaccion.Image = My.Resources.list_16
                AddHandler itTransaccion.Click, AddressOf SeleccionCorregirTransaccion

                Dim grupo As String = dRow("Grupo")

                '== Modificar esta parte para los perfiles de supervisor para que no tome en cuenta las siguientes transacciones, solo puede hacer "EXCEPCIÓN HORARIO"
                '== 12/04/2023       AOS
                'If Perfil.Contains("SUPERV") And (itTransaccion.Text.Contains("EXCEPCION HORARIO MASIVO") Or
                '                                  itTransaccion.Text.Contains("TIEMPO COMPLETO MASIVO") Or itTransaccion.Text.Contains("OLVIDO GAFETE") Or itTransaccion.Text.Contains("OLVIDO CHECAR") Or
                '                                  itTransaccion.Text.Contains("RETARDO TRANSPORTE") Or itTransaccion.Text.Contains("SISTEMA") Or itTransaccion.Text.Contains("TIEMPO X TIEMPO") Or
                '                                  itTransaccion.Text.Contains("CANCELAR TIEMPO POR TIEMPO") Or itTransaccion.Text.Contains("CANCELACIÓN RETARDO TRANSPORTE") Or itTransaccion.Text.Contains("TIEMPO COMPLETO")) Then
                '    Continue For
                'End If

                '== 2023-04-28: Solicita Miriam que la transacción "Olvido Checar" si la puedan visualizar, quitar entonces de la lista:
                If Perfil.Contains("SUPERV") And (itTransaccion.Text.Contains("EXCEPCION HORARIO MASIVO") Or
                                    itTransaccion.Text.Contains("TIEMPO COMPLETO MASIVO") Or itTransaccion.Text.Contains("OLVIDO GAFETE") Or
                                    itTransaccion.Text.Contains("RETARDO TRANSPORTE") Or itTransaccion.Text.Contains("SISTEMA") Or itTransaccion.Text.Contains("TIEMPO X TIEMPO") Or
                                    itTransaccion.Text.Contains("CANCELAR TIEMPO POR TIEMPO") Or itTransaccion.Text.Contains("CANCELACIÓN RETARDO TRANSPORTE") Or itTransaccion.Text.Contains("TIEMPO COMPLETO")) Then
                    Continue For
                End If

                '--- 2023-05-31: Solicita Miriam que el perfil de ASIST solo pueda tener la de excepcion de horario y la de olvidó checar
                If Perfil.Contains("ASIST") And (itTransaccion.Text.Contains("EXCEPCION HORARIO MASIVO") Or
                            itTransaccion.Text.Contains("TIEMPO COMPLETO MASIVO") Or itTransaccion.Text.Contains("OLVIDO GAFETE") Or
                            itTransaccion.Text.Contains("RETARDO TRANSPORTE") Or itTransaccion.Text.Contains("SISTEMA") Or itTransaccion.Text.Contains("TIEMPO X TIEMPO") Or
                            itTransaccion.Text.Contains("CANCELAR TIEMPO POR TIEMPO") Or itTransaccion.Text.Contains("CANCELACIÓN RETARDO TRANSPORTE") Or itTransaccion.Text.Contains("TIEMPO COMPLETO")) Then
                    Continue For
                End If

                If grupo = "X" Then
                    btnExcepcion.SubItems.Add(itTransaccion)
                Else
                    btnCorreccion.SubItems.Add(itTransaccion)
                End If


                ' mnuAjusteEntrada.DropDownItems.Add(dRow("nombre"), , itTransaccion.ClickAutoRepeat)
            Next

            dtCiasTA = sqlExecute("SELECT ausentismo,inicia_sem,analizar_entrada_salida FROM parametros")
            If dtCiasTA.Rows.Count = 0 Then
                MessageBox.Show("Es necesario capturar <PARAMETROS>.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                IniciaLunes = True
                _aus_natural = "FI"
                AnalizarES = True
            Else
                If IsDBNull(dtCiasTA.Rows.Item(0).Item("inicia_sem")) Then
                    MessageBox.Show("Es necesario definir en qué día inicia la semana, en la tabla <PARAMETROS>.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    IniciaLunes = True
                Else
                    IniciaLunes = dtCiasTA.Rows.Item(0).Item("inicia_sem") = 2
                End If

                AnalizarES = IIf(IsDBNull(dtCiasTA.Rows(0).Item("analizar_entrada_salida")), True, dtCiasTA.Rows(0).Item("analizar_entrada_salida"))

                _aus_natural = IIf(IsDBNull(dtCiasTA.Rows(0).Item("ausentismo")), "FI", dtCiasTA.Rows(0).Item("ausentismo")).ToString.Trim
            End If

            txtFechaAusentismo.Value = Now


            dtPeriodos = sqlExecute("SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin,(CASE activo WHEN 1 THEN '   *' ELSE '' END) AS activo " & _
                                "FROM periodos WHERE periodo_especial IS NULL OR periodo_especial = 0 ORDER BY ano DESC,periodo ASC", "TA")

            cmbPeriodos.DataSource = dtPeriodos

            dtTemp = sqlExecute("SELECT ano + periodo as anoPeriodo FROM periodos WHERE activo = 1 ORDER BY ano DESC,periodo DESC", "TA")
            If dtTemp.Rows.Count > 0 Then
                PeriodoActivo = dtTemp.Rows(0).Item("anoPeriodo")
                cmbPeriodos.SelectedValue = dtTemp.Rows(0).Item("anoPeriodo")
            End If

            'MCR 2017-10-10
            'Cambio para filtrar tipo de ausentismo por perfil 
            dtFiltroPerfil = sqlExecute("SELECT filtro_ausentismo FROM perfiles WHERE cod_perfil " & Perfil, "SEGURIDAD")
            If dtFiltroPerfil.Rows.Count > 0 Then
                FiltroAusentismo = IIf(IsDBNull(dtFiltroPerfil.Rows(0).Item("filtro_ausentismo")), "", dtFiltroPerfil.Rows(0).Item("filtro_ausentismo")).ToString.Trim
            End If

            dtTipoAusentismo = sqlExecute("SELECT tipo_aus AS 'AUSENTISMO',NOMBRE,color_letra,color_back FROM tipo_ausentismo " & _
                                      IIf(FiltroAusentismo.Length > 0, " WHERE isnull(TIPO_NATURALEZA,'')<>'' and (" & FiltroAusentismo & ") ", "WHERE isnull(TIPO_NATURALEZA,'')<>'' ") &
                                          "ORDER By tipo_aus", "TA")
            '**********************************

            cmbAusentismo.DataSource = dtTipoAusentismo
            cmbAusentismo.SelectedValue = ""

            calAusentismo.DateSelectionStart = Now
            calAusentismo.DateSelectionEnd = Now

            For x = 0 To dtTipoAusentismo.Rows.Count - 1
                A = dtTipoAusentismo.Rows(x).Item("ausentismo")
                B = IIf(IsDBNull(dtTipoAusentismo.Rows(x).Item("color_back")), -1, dtTipoAusentismo.Rows(x).Item("color_back"))
                T = IIf(IsDBNull(dtTipoAusentismo.Rows(x).Item("color_letra")), -16777216, dtTipoAusentismo.Rows(x).Item("color_letra"))

                calAusentismo.CategoryColors.Add(New AppointmentCategoryColor(A, Color.FromArgb(T), Color.FromArgb(T), New ColorDef(Color.FromArgb(B))))
            Next

            'Determinar el tipo de ausentismo para día festivo 
            dtTemp = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE UPPER(nombre) LIKE '%FESTIVO%'", "TA")
            If dtTemp.Rows.Count = 0 Then
                _aus_festivo = _aus_natural
            Else
                _aus_festivo = IIf(IsDBNull(dtTemp.Rows(0).Item("tipo_aus")), "FES", dtTemp.Rows(0).Item("tipo_aus")).ToString.Trim
            End If


            '== Cargar combobox de faltas con la tabla 'tipo_faltas' desde el comienzo      Abril 2021      Ernesto
            dtFaltasTipo = sqlExecute("select * from TA.dbo.tipo_faltas")
            cmbClasFalta.DataSource = dtFaltasTipo


            '==Revisar de acuerdo al perfil no visualizar ciertos botones        29julio2021     ernesto
            revisarPerfiles(Perfil, Me, False, "CIA", txtReloj.Text.ToString.Trim)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            tbInfo.SelectedTabIndex = 1
            btnEditar.Visible = True
            NFiltros = 0
            tabFiltros.Tooltip = ""
            chkActivos.Checked = True
            Iniciando = False

        End Try

        'chkActivos_CheckedChanged(chkActivos, Nothing)
    End Sub

    '== Función para determinar los días de descanso  (carácter informativo solamente)          27sep2021
    Private Function DiasDescanso(ByVal dtAsistencias As DataTable) As DataTable
        Dim dtDiasDescanso As New DataTable
        Dim insertaDescanso As Boolean = True
        Dim descanso As String = ""

        Try
            '== Fechas periodo
            Dim dtFechaPeriodos As DataTable = sqlExecute("select * from TA.dbo.periodos where ano+PERIODO='" & PeriodoActivo & "'")

            '== Horarios en personal y bitácora
            Dim dtTemporal As DataTable = sqlExecute("SELECT RELOJ,COD_HORA as HorarioActual,(SELECT VALORANTERIOR FROM PERSONAL.dbo.bitacora_personal " & _
                                                                                                    "WHERE reloj = '" & txtReloj.Text.Trim & "' AND FECHA = (SELECT MIN(FECHA) AS FECHA FROM dbo.bitacora_personal AS BITACORA " & _
                                                                                                    "WHERE CAST(fecha AS DATE) > '" & FechaSQL(dtFechaPeriodos.Rows(0)("fecha_fin")) & "' AND campo = bitacora_personal.campo and reloj= bitacora_personal.reloj) " & _
                                                                                                    "AND tipo_movimiento = 'C' AND campo='cod_hora') as cod_hora " & _
                                                                                                    "FROM PERSONAL.dbo.personal where RELOJ='" & txtReloj.Text.Trim & "'")

            '== Días de descanso, asistencia del empleado e inserción de los días de descanso
            If dtTemporal.Rows.Count > 0 Then
                Dim horario_emp As String = IIf(IsDBNull(dtTemporal.Rows(0)("cod_hora")), dtTemporal.Rows(0)("HorarioActual").ToString.Trim, dtTemporal.Rows(0)("cod_hora").ToString)
                dtTemporal = sqlExecute("select * from PERSONAL.dbo.dias where COD_HORA='" & horario_emp.Trim & "' and descanso='1'")

                If dtTemporal.Rows.Count > 0 Then

                    If dtAsistencias.Rows.Count > 0 Then
                        dtDiasDescanso = dtAsistencias.Clone

                        For Each i As DataRow In dtTemporal.Rows
                            descanso = "[DÍA ENTRADA] in ('" & i.Item("dia_ent").ToString.Trim & "')"
                            For Each j As DataRow In dtAsistencias.Select(descanso)
                                insertaDescanso = False
                            Next
                            If insertaDescanso Then
                                Dim row As DataRow = dtAsistencias.NewRow
                                row.Item("FECHA ENTRADA") = "1900-01-01"
                                row.Item("DÍA ENTRADA") = i.Item("dia_ent").ToString.Trim
                                row.Item("ENTRADA") = "--"
                                row.Item("HORARIO ENTRADA") = "--"
                                row.Item("DIF. ENT.") = "--"
                                row.Item("FECHA SALIDA") = "1900-01-01"
                                row.Item("DÍA SALIDA") = i.Item("dia_sal").ToString.Trim
                                row.Item("SALIDA") = "--"
                                row.Item("HORARIO SALIDA") = "--"
                                row.Item("DIF. SAL.") = "--"
                                row.Item("HRS.") = "00:00"
                                row.Item("HRS. NOR.") = "00:00"
                                row.Item("HRS. COMP.") = "00:00"
                                row.Item("HRS. EXT.") = "00:00"
                                row.Item("EXT. AUT.") = "00:00"
                                row.Item("COMENTARIO") = "DESCANSO (INFORMATIVO)"
                                row.Item("DOBLES 33") = DBNull.Value
                                row.Item("TRIPLES 33") = DBNull.Value
                                row.Item("PERIODO") = ""
                                row.Item("USUARIO") = ""
                                row.Item("FECHA") = "1900-01-01"
                                row.Item("HORA") = "00:00"
                                row.Item("AUSENTISMO") = "99"
                                row.Item("PAREJA") = "0"
                                row.Item("fal_tran_ent") = "0"
                                row.Item("fal_tran_sal") = "0"
                                row.Item("fha_ent_hor") = "1900-01-01"
                                row.Item("TIPO_AUS") = "--"
                                row.Item("horas_tarde") = "00:00"
                                row.Item("horas_anticipadas") = "00:00"
                                dtAsistencias.Rows.Add(row)
                            End If
                            insertaDescanso = True
                        Next
                    End If

                    '== Insertar los registros en una nueva tabla (ordenados)
                    Dim diasNom() As String = {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"}
                    For Each x As String In diasNom
                        descanso = "[DÍA ENTRADA] in ('" & x & "')"
                        For Each z As DataRow In dtAsistencias.Select(descanso)
                            dtDiasDescanso.ImportRow(z)
                        Next
                    Next
                End If
            End If

        Catch ex As Exception
        End Try

        Return dtDiasDescanso
    End Function

    Public Sub MostrarInformacion(ByVal rl As String)
        Dim drEmpleado As DataRow
        '---2022-02-09
        Dim cod_turno As String = "", nombre_turno As String = "", cod_hora As String = "", nombre_horario As String = "" '2022-02-09 - AOS
        Try
            If Iniciando Then Exit Sub
            rl = rl.Trim

            If rl = "" Or dtPeriodos.Rows.Count = 0 Or cmbPeriodos.SelectedValue Is Nothing Then
                txtReloj.Text = ""
                txtNombre.Text = "NINGÚN REGISTRO LOCALIZADO"

                txtAlta.Value = Now.Date
                EsBaja = True
                txtBaja.Value = Now.Date

                Reingreso = False
                lblReingreso.Visible = Reingreso

                txtTipoEmp.Text = ""
                txtDepto.Text = ""
                txtSupervisor.Text = ""
                txtClase.Text = ""
                txtTurno.Text = ""
                txtHorario.Text = ""
                txtGafete.Text = ""
            Else
                drEmpleado = dtPersonal.Rows.Item(0)
                If cbBitacora.Checked Then
                    'MCR 13/OCT/2015
                    'Si se debe revisar bitácora, buscar valores al fin del periodo
                    ConsultaBitacora(dtPersonal, drEmpleado, FechaFinPeriodo)
                    '----2022-02-09 AOS
                    cod_turno = ConsultaBitacoraHorarios(dtPersonal, drEmpleado, FechaFinPeriodo, "cod_turno")
                    cod_hora = ConsultaBitacoraHorarios(dtPersonal, drEmpleado, FechaFinPeriodo, "cod_hora")
                End If
                '---AOS
                If (cod_turno <> "") Then
                    Dim dtCodTurno As DataTable = sqlExecute("SELECT nombre FROM turnos WHERE cod_comp = '" & drEmpleado("cod_comp") & "' AND COD_TURNO = '" & cod_turno & "'", "PERSONAL")
                    If (Not dtCodTurno.Columns.Contains("Error") And dtCodTurno.Rows.Count > 0) Then
                        Try : nombre_turno = dtCodTurno.Rows(0).Item("nombre").ToString.Trim : Catch ex As Exception : nombre_turno = "" : End Try
                    End If
                End If

                If (cod_hora <> "") Then
                    Dim dtcodHora As DataTable = sqlExecute("SELECT nombre FROM horarios WHERE cod_comp = '" & drEmpleado("cod_comp") & "' AND cod_hora = '" & cod_hora & "'", "PERSONAL")
                    If (Not dtcodHora.Columns.Contains("Error") And dtcodHora.Rows.Count > 0) Then
                        Try : nombre_horario = dtcodHora.Rows(0).Item("nombre").ToString.Trim : Catch ex As Exception : nombre_horario = "" : End Try
                    End If
                End If

                '---Aos:
                drEmpleado("cod_hora") = cod_hora
                drEmpleado("nombre_horario") = nombre_horario
                drEmpleado("cod_turno") = cod_turno
                drEmpleado("nombre_turno") = nombre_turno

                Comp = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp"))

                txtReloj.Text = IIf(IsDBNull(drEmpleado("reloj")), "", drEmpleado("reloj")).ToString.Trim
                txtNombre.Text = IIf(IsDBNull(drEmpleado("nombres")), "", drEmpleado("nombres")).ToString.Trim

                'Comentado Wollsdorf
                'Try
                '    Dim dtSF As DataTable = sqlExecute("select sf_id from personalvw where reloj = '" & txtReloj.Text & "'")
                '    If dtSF.Rows.Count > 0 Then
                '        labelSF.Text = RTrim(dtSF.Rows(0)("sf_id"))
                '    Else
                '        labelSF.Text = "N/A"
                '    End If
                'Catch ex As Exception

                'End Try
                'Comentado Wollsdorf
                'Try
                '    Dim dtClerk As DataTable = sqlExecute("select cod_clerk, nombre_clerk from personalvw where reloj = '" & txtReloj.Text & "'")
                '    If dtClerk.Rows.Count > 0 Then
                '        If Len(Trim(dtClerk.Rows(0)("cod_clerk"))) > 0 Then
                '            txtClerk.Text = RTrim(dtClerk.Rows(0)("cod_clerk")) & "(" & RTrim(dtClerk.Rows(0)("nombre_clerk")) & ")"
                '        Else
                '            txtClerk.Text = "000(Indefinido)"
                '        End If
                '    Else
                '        labelSF.Text = "N/A"
                '    End If
                'Catch ex As Exception
                '    labelSF.Text = "N/A"
                'End Try

                txtAlta.Value = IIf(IsDBNull(drEmpleado("alta")), Nothing, drEmpleado("alta"))
                EsBaja = Not IsDBNull(drEmpleado("baja"))
                txtBaja.Value = IIf(EsBaja, drEmpleado("baja"), Nothing)


                Try
                    Dim dtMarca As DataTable = sqlExecute("select * from nomsem where reloj = '" & txtReloj.Text & "' and ano+periodo = '" & cmbPeriodos.SelectedValue & "' and usuario_nota is not null", "TA")
                    If dtMarca.Rows.Count > 0 Then
                        chkNotaUsuario.Checked = True
                        chkNotaUsuario.Text = "Marcado para revisión (" & RTrim(dtMarca.Rows(0)("usuario_nota")) & ")"
                    Else
                        chkNotaUsuario.Checked = False
                        chkNotaUsuario.Text = "Marcar para revisión"
                    End If
                Catch ex As Exception
                    chkNotaUsuario.Checked = False
                    chkNotaUsuario.Text = "Marcar para revisión"
                End Try

                'Reingreso = (IIf(IsDBNull(drEmpleado("reingreso")), 0, drEmpleado("reingreso")) = 1)
                dtTemp = sqlExecute("SELECT TOP 1 reloj FROM reingresos WHERE reloj = '" & rl & "'")
                Reingreso = dtTemp.Rows.Count > 0
                lblReingreso.Visible = Reingreso

                txtCia.Text = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp").ToString.Trim) & _
                    IIf(IsDBNull(drEmpleado("compania")), "", " (" & drEmpleado("compania").ToString.Trim & ")")

                Dim comp_ta As String = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp").ToString.Trim)
                If comp_ta.Trim = "610" Then
                    Label15.Text = "SuccessFactors"
                ElseIf comp_ta.Trim = "002" Then
                    Label15.Text = "RelojAlterno"
                Else
                    Label15.Text = "ID"
                End If
                txtplanta.Text = IIf(IsDBNull(drEmpleado("cod_planta")), "", drEmpleado("cod_planta").ToString.Trim) & _
                    IIf(IsDBNull(drEmpleado("nombre_planta")), "", " (" & drEmpleado("nombre_planta").ToString.Trim & ")")

                'txtArea.Text = IIf(IsDBNull(drEmpleado("cod_area")), "", drEmpleado("cod_area").ToString.Trim) & _
                '    IIf(IsDBNull(drEmpleado("nombre_area")), "", " (" & drEmpleado("nombre_area").ToString.Trim & ")")


                Dim dttempc As DataTable = sqlExecute("select nombre from c_costos where centro_costos = '" & IIf(IsDBNull(drEmpleado("centro_costos")), "", drEmpleado("centro_costos").ToString.Trim) & "'")
                If dttempc.Rows.Count > 0 Then
                    txtArea.Text = IIf(IsDBNull(drEmpleado("centro_costos")), "", drEmpleado("centro_costos").ToString.Trim) & _
                   IIf(dttempc.Rows.Count > 0, IIf(IsDBNull(dttempc.Rows(0).Item("nombre")), "", " (" & dttempc.Rows(0).Item("nombre").ToString.Trim & ")"), "")
                End If

                txtTipoEmp.Text = IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo").ToString.Trim) & _
                    IIf(IsDBNull(drEmpleado("nombre_tipoemp")), "", " (" & drEmpleado("nombre_tipoemp").ToString.Trim & ")")

                txtDepto.Text = IIf(IsDBNull(drEmpleado("cod_depto")), "", drEmpleado("cod_depto").ToString.Trim) & _
                    IIf(IsDBNull(drEmpleado("nombre_depto")), "", " (" & drEmpleado("nombre_depto").ToString.Trim & ")")

                txtSupervisor.Text = IIf(IsDBNull(drEmpleado("cod_super")), "", drEmpleado("cod_super").ToString.Trim) & _
                    IIf(IsDBNull(drEmpleado("nombre_super")), "", " (" & drEmpleado("nombre_super").ToString.Trim & ")")

                txtClase.Text = IIf(IsDBNull(drEmpleado("cod_clase")), "", drEmpleado("cod_clase").ToString.Trim) & _
                    IIf(IsDBNull(drEmpleado("nombre_clase")), "", " (" & drEmpleado("nombre_clase").ToString.Trim & ")")

                Try
                    Dim dtturno As DataTable = sqlExecute("select cod_turno from rol_horarios where cod_hora = '" & IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora").ToString.Trim) & "' " & _
                                                          "and ano = '" & cmbPeriodos.SelectedValue.ToString.Substring(0, 4) & "' " & _
                                                          "and cod_comp = '" & Comp & "' and periodo = '" & cmbPeriodos.SelectedValue.ToString.Substring(4, 2) & "' " & _
                                                          "and semana = '" & SemanaHorarioMixto(cmbPeriodos.SelectedValue.ToString, drEmpleado("reloj").ToString.Trim).NumSemana & "'")
                    If dtturno.Rows.Count > 0 Then
                        txtTurno.Text = IIf(IsDBNull(dtturno.Rows(0).Item("cod_turno")), "", dtturno.Rows(0).Item("cod_turno"))
                    Else
                        txtTurno.Text = ""
                    End If
                Catch
                    txtTurno.Text = ""
                End Try

                'txtTurno.Text = IIf(IsDBNull(drEmpleado("cod_turno")), "", drEmpleado("cod_turno").ToString.Trim) & _
                '    IIf(IsDBNull(drEmpleado("nombre_turno")), "", " (" & drEmpleado("nombre_turno").ToString.Trim & ")")

                txtHorario.Text = IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora").ToString.Trim) & _
                    IIf(IsDBNull(drEmpleado("nombre_horario")), "", " (" & drEmpleado("nombre_horario").ToString.Trim & ")")

                ''==Aqui se le asigna el horario de acuerdo a la bitacora, a la variable global de declaraciones             22sep2021
                'HorBitEmp = IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora").ToString.Trim)

                txtGafete.Text = IIf(IsDBNull(drEmpleado("GAFETE")), "", drEmpleado("GAFETE").ToString.Trim)

                'Etiquetas de checar tarjeta y tiempo completo
                chkChecaTarjeta.Checked = IIf(IsDBNull(drEmpleado("checa_tarjeta")), True, drEmpleado("checa_tarjeta"))
                pnlChecaTarjeta.BackColor = IIf(chkChecaTarjeta.Checked, SystemColors.ActiveCaption, Color.Aquamarine)
                chkChecaTarjeta.TextColor = IIf(chkChecaTarjeta.Checked, Color.White, Color.Black)

                pnlTiempoCompleto.Visible = TiempoCompleto(drEmpleado("reloj").ToString.Trim)
                picFoto.ImageLocation = drEmpleado("foto")

                'MCR 2017-10-09
                'Indicar si el periodo es SEMANAL, QUINCENAL O MENSUAL (informativo)
                Try
                    TipoPeriodoEmpleado = IIf(IsDBNull(drEmpleado("tipo_periodo")), "S", drEmpleado("tipo_periodo"))
                Catch ex As Exception

                End Try

                pnlTipoPeriodo.BackColor = Color.White
                lblTipoPeriodo.ForeColor = IIf(TipoPeriodoEmpleado = "S", Color.MidnightBlue, IIf(TipoPeriodoEmpleado = "Q", Color.DarkSlateGray, Color.DarkSlateBlue))
                lblTipoPeriodo.Text = "TIPO DE NÓMINA: " & vbCrLf & vbCrLf & IIf(TipoPeriodoEmpleado = "S", "SEMANAL", IIf(TipoPeriodoEmpleado = "Q", "QUINCENAL", "MENSUAL"))
                '******************
                'dgvCafeteria.DataSource = sqlExecute("select Reloj, Fecha, Hora, horario as Servicio, horarios_cafeteria.nombre as Nombre_servicio, subsidio as Subsidio, subsidio_cafeteria.nombre_subsidio as Tipo_de_descuento from hrs_brt_cafeteria left join horarios_cafeteria on hrs_brt_cafeteria.horario = horarios_cafeteria.cod_hora_cafe left join subsidio_cafeteria on subsidio_cafeteria.cod_subsidio = hrs_brt_cafeteria.subsidio where reloj = '" & txtReloj.Text & "' and fecha between '" & FechaHoraSQL(FechaIniPeriodo) & "' AND '" & FechaHoraSQL(FechaIniPeriodo.AddDays(6)) & "' order by fecha, hora, id_registro", "TA")
                '*****HORARIOS EXCEPCIONES*******'
                Dim dtexcepciones As New DataTable
                dtexcepciones = sqlExecute("SELECT excepciones_horarios.reloj, RTRIM(APATERNO)+' ' + RTRIM(AMATERNO)+' '+RTRIM(NOMBRE) AS nombres," & _
                                          "excepciones_horarios.cod_hora,excepciones_horarios.cod_hora_personal,excepciones_horarios.fecha,excepciones_horarios.comentario " & _
                                          "FROM excepciones_horarios LEFT JOIN personal ON excepciones_horarios.cod_comp = personal.cod_comp " & _
                                          "AND excepciones_horarios.reloj = personal.reloj where excepciones_horarios.fecha between '" & FechaSQL(FechaIniPeriodo) & "' and '" & FechaSQL(FechaFinPeriodo) & "' and excepciones_horarios.reloj = '" & rl & "' ORDER BY fecha DESC")
                dgExcepcionHorarios.PrimaryGrid.DataSource = dtexcepciones

                My.Application.DoEvents()


            End If
            '****************************************
            dtTemp = sqlExecute("SELECT inicia_sem FROM parametros")
            If dtTemp.Rows.Count = 0 Then
                IniciaLunes = True
            Else
                If IsDBNull(dtTemp.Rows.Item(0).Item(0)) Then
                    IniciaLunes = True
                Else
                    IniciaLunes = dtTemp.Rows.Item(0).Item(0) = 2
                End If
            End If

            '*** Cambios en bajas ****
            txtBaja.Visible = EsBaja
            lblBaja.Visible = EsBaja
            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtReloj.BackColor = lblEstado.BackColor

            If EsBaja Then
                Highlighter1.SetHighlightColor(txtReloj, DevComponents.DotNetBar.Validator.eHighlightColor.Red)
            Else
                Highlighter1.SetHighlightColor(txtReloj, DevComponents.DotNetBar.Validator.eHighlightColor.Green)
            End If

            lblReingreso.Visible = Not EsBaja And Reingreso
            '*************************      
            ActualizaInformacionTA()
        Catch ex As Exception
            'MessageBox.Show("La información no pudo ser cargada correctamente. Si el problema persiste, contacte al administrador del sistema." & _
            ' vbCrLf & vbCrLf & "Err. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            HabilitarBotones()
        End Try
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Try
            Dim reloj As String
            reloj = txtReloj.Text
            Acumulado = FiltrosAcumulados()
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * FROM personalvw WHERE 1=1 " & Acumulado & " ORDER BY reloj ASC", False)

            If dtPersonal.Rows.Count > 0 Then
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
            Else
                reloj = ""
            End If
            MostrarInformacion(reloj)

            '==Revisar de acuerdo al perfil         29julio2021     ernesto
            revisarPerfiles(Perfil, Me, False, "CIA", txtReloj.Text.ToString.Trim)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Try
            Dim reloj As String
            reloj = txtReloj.Text
            Acumulado = FiltrosAcumulados()
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * FROM personalvw WHERE reloj <'" & reloj & "' " & Acumulado & " ORDER BY reloj DESC", False)

            If dtPersonal.Rows.Count < 1 Then
                btnFirst.PerformClick()
            Else
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")

                MostrarInformacion(reloj)
            End If

            '==Revisar de acuerdo al perfil         29julio2021     ernesto
            revisarPerfiles(Perfil, Me, False, "CIA", txtReloj.Text.ToString.Trim)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            Dim reloj As String
            reloj = txtReloj.Text
            Acumulado = FiltrosAcumulados()

            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * FROM personalvw WHERE reloj >'" & reloj & "' " & Acumulado & " ORDER BY reloj ASC", False)
            If dtPersonal.Rows.Count < 1 Then
                btnLast.PerformClick()
            Else
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
                MostrarInformacion(reloj)
            End If

            '==Revisar de acuerdo al perfil         29julio2021     ernesto
            revisarPerfiles(Perfil, Me, False, "CIA", txtReloj.Text.ToString.Trim)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Try

            Dim reloj As String
            reloj = txtReloj.Text
            Acumulado = FiltrosAcumulados()
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * FROM personalvw WHERE 1 = 1 " & Acumulado & " ORDER BY reloj DESC", False)

            'EmpIdx = dtPersonal.Rows.Count - 1 
            If dtPersonal.Rows.Count > 0 Then
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
            Else
                reloj = ""
            End If
            MostrarInformacion(reloj)

            '==Revisar de acuerdo al perfil         29julio2021     ernesto
            revisarPerfiles(Perfil, Me, False, "CIA", txtReloj.Text.ToString.Trim)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtTemp = dtPersonal
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                'dtPersonal = ConsultaPersonalVW("SELECT * FROM personalvw WHERE reloj ='" & Reloj & "'", False)
                dtPersonal = ConsultaPersonalVW("SELECT * FROM personalvw WHERE reloj ='" & Reloj & "' " & Acumulado & " ORDER BY reloj ASC", False)

                If dtPersonal.Rows.Count > 0 Then
                    MostrarInformacion(Reloj)
                Else
                    MessageBox.Show("El empleado " & Reloj & " no fue localizado, no cumple con el filtro aplicado, o tiene un nivel al que su usuario no tiene acceso.", "Empleado no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            '==Revisar de acuerdo al perfil         29julio2021     ernesto
            revisarPerfiles(Perfil, Me, False, "CIA", txtReloj.Text.ToString.Trim)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtPersonal = dtTemp
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmbPeriodos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodos.SelectedIndexChanged
        Dim PeriodoSeleccionado As String
        Dim R As String
        Try
            If cmbPeriodos.SelectedValue Is Nothing Then Exit Sub
            R = txtReloj.Text.Trim

            PeriodoSeleccionado = cmbPeriodos.SelectedValue
            CambioFecha()
            'Si están seleccionados los fitros de activos o bajas, se deben regenerar para actualizar el periodo 
            If chkActivos.Checked Then
                chkActivos.Checked = False
                chkActivos.Checked = True
            ElseIf chkBajas.Checked Then
                chkBajas.Checked = False
                chkActivos.Checked = True
            End If
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * FROM personalvw WHERE RELOJ = '" & R & "'", False)
            If dtPersonal.Rows.Count = 0 Then
                btnNext.PerformClick()
            End If


            Try
                ' QUE POR DEFAULT ESTE CHECADO SOLO HOY AL INICIAR
                Dim dtPeriodoActual As DataTable = sqlExecute("select ano+periodo as anoper FROM periodos where fecha_ini <= '" & FechaSQL(Now.Date) & "' and fecha_fin >= '" & FechaSQL(Now.Date) & "' and periodo_especial = '0' ", "TA")
                If dtPeriodoActual.Rows.Count Then
                    If PeriodoSeleccionado = dtPeriodoActual.Rows(0)("anoper") Then
                        chkSemana.Checked = False

                        Select Case Now.DayOfWeek
                            Case DayOfWeek.Monday
                                chkLun.Checked = True
                            Case DayOfWeek.Tuesday
                                chkMar.Checked = True
                            Case DayOfWeek.Wednesday
                                chkMie.Checked = True
                            Case DayOfWeek.Thursday
                                chkJue.Checked = True
                            Case DayOfWeek.Friday
                                chkVie.Checked = True
                            Case DayOfWeek.Saturday
                                chkSab.Checked = True
                            Case DayOfWeek.Sunday
                                chkDom.Checked = True
                        End Select
                    Else
                        chkSemana.Checked = False
                        chkLun.Checked = True
                    End If
                Else
                    chkSemana.Checked = False
                    chkLun.Checked = True
                End If

            Catch ex As Exception
                chkSemana.Checked = False
                chkLun.Checked = True
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub iniciardesdeTE(ByVal rl As String)
        dtTemp = dtPersonal
        Try
            'frmBuscar.ShowDialog(Me)

            'dtPersonal = ConsultaPersonalVW("SELECT * FROM personalvw WHERE reloj ='" & Reloj & "'", False)
            dtPersonal = sqlExecute("select * from personalvw where reloj = '" & rl & "'")

            If dtPersonal.Rows.Count > 0 Then
                MostrarInformacion(rl)
            Else
                MessageBox.Show("El empleado " & Reloj & " no fue localizado, no cumple con el filtro aplicado, o tiene un nivel al que su usuario no tiene acceso.", "Empleado no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            desdeTE = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtPersonal = dtTemp
        End Try
    End Sub
    Private Sub ActualizaInformacionTA()
        Dim P As String
        Dim R As String
        Dim I As Integer
        Dim FIni As Date = Now
        Dim FFin As Date = Now
        Dim Tipo As String = ""
        Dim Referencia As String = ""
        Dim C As Integer
        Dim Dt As Date
        Dim PeriodoSeleccionado As String
        Dim EsPeriodoActivo As Boolean
        Dim dtActivo As New DataTable
        'Dim Activo As Boolean
        Dim dtHorario As New DataTable
        Dim Rango As Double

        Dim dtPerfil As New DataTable
        Dim PermisoInactivos As Boolean

        Try
            If cmbPeriodos.SelectedValue Is Nothing Then
                Exit Sub
            End If
            P = cmbPeriodos.SelectedValue
            R = txtReloj.Text.Trim
            Semana = SemanaHorarioMixto(cmbPeriodos.SelectedValue, R)
            If Semana.NumSemana = -1 Then
                'MessageBox.Show("No hay registro de horario para el empleado " & R & ".", "Información faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            pnlHorarioMixto.Visible = Semana.Mixto
            chkMixto.Text = "HORARIO" & vbCrLf & "MIXTO" & vbCrLf & "(SEMANA " & Semana.NumSemana & ")"

            CambioDiasDescanso(R)

            '*** Permitir hacer cambios solamente si se encuentra seleccionado el periodo activo, ***
            '*** la transacción no está cerrada
            '*** y el empleado se encuentra activo
            PeriodoSeleccionado = cmbPeriodos.SelectedValue

            dtPerfil = sqlExecute("SELECT TAperiodos_inactivos FROM perfiles WHERE cod_perfil " & Perfil, "SEGURIDAD")
            If dtPerfil.Rows.Count = 0 Then
                PermisoInactivos = False
            Else
                PermisoInactivos = IIf(IsDBNull(dtPerfil.Rows(0)(0)), 0, dtPerfil.Rows(0)(0)) = 1
            End If
            PeriodoSeleccionado = cmbPeriodos.SelectedValue
            '*** Permitir hacer cambios solamente si se encuentra seleccionado el periodo activo ***
            '*** y la transacción no está cerrada
            dtTemp = sqlExecute("SELECT fecha_ini,fecha_fin,activo FROM periodos WHERE ano = '" & PeriodoSeleccionado.Substring(0, 4) & _
                                "' AND periodo = '" & PeriodoSeleccionado.Substring(4, 2) & "'", "TA")
            If dtTemp.Rows.Count = 0 Then
                FIni = New Date
                FFin = New Date
                EsPeriodoActivo = False
            Else
                FIni = dtTemp.Rows(0).Item("fecha_ini")
                FFin = dtTemp.Rows(0).Item("fecha_fin")

                If PermisoInactivos Then
                    'MCR 15/OCT/2015
                    'Si el usuario tiene acceso a editar periodos inactivos, de acuerdo a su perfil, no necesita revisar
                    EsPeriodoActivo = True
                Else
                    EsPeriodoActivo = IIf(IsDBNull(dtTemp.Rows(0).Item("activo")), 0, dtTemp.Rows(0).Item("activo")) = 1
                End If
            End If


            'MCR 20/OCT/2015
            'Rango mínimo para primer día
            dtHorario = sqlExecute("SELECT TOP 1 rango_hrs FROM dias LEFT JOIN personal " & _
                                              "ON dias.cod_comp = personal.cod_comp AND dias.cod_hora = personal.cod_hora " & _
                                              "WHERE reloj = '" & R & "' ORDER BY cod_dia, TA.DBO.HORA12A24(ENTRA)")
            Rango = HtoD(IIf(IsDBNull(dtHorario.Rows(0).Item("rango_hrs")), "03:00", dtHorario.Rows(0).Item("rango_hrs"))) * 60
            FIni = DateAdd(DateInterval.Minute, Rango, FIni)

            ''Determinar la hora en que termina el día, de acuerdo al rango de horas definido
            ''Rango máximo para último día
            'dtHorario = sqlExecute("SELECT TOP 1 rango_hrs FROM dias LEFT JOIN personal " & _
            '           "ON dias.cod_comp = personal.cod_comp AND dias.cod_hora = personal.cod_hora " & _
            '           "WHERE reloj = '" & R & "' ORDER BY cod_dia DESC, TA.DBO.HORA12A24(ENTRA) DESC")

            'Determinar la hora en que termina el día, de acuerdo al rango de horas definido
            'Rango máximo para último día
            'Abraham Casas 2017/11/1
            'Considerar sumar 24 horas cuando la salida es el mismo dia, y no sumar cuando la salida es al dia siguiente

            dtHorario = sqlExecute("SELECT TOP 1 rango_hrs FROM dias LEFT JOIN personal " & _
                       "ON dias.cod_comp = personal.cod_comp AND dias.cod_hora = personal.cod_hora " & _
                       "WHERE reloj = '" & R & "' ORDER BY cod_dia DESC, TA.DBO.HORA12A24(ENTRA) DESC")

            Rango = HtoD(IIf(IsDBNull(dtHorario.Rows(0).Item("rango_hrs")), "03:00", dtHorario.Rows(0).Item("rango_hrs"))) * 60

            FFin = DateAdd(DateInterval.Minute, Rango + (24 * 60), FFin)


            dtHrsBrt = New DataTable

            dtHrsBrt = sqlExecute("SELECT PERIODO,GAFETE,FECHA,HORA,DIA AS 'DÍA',tipo_tran AS 'TIPO TRANSACCIÓN'," & _
                                  "CONVERT(char(11),FECHA,23) + ' ' + HORA AS UNICO,FECHA_EFVA AS 'FECHA EFECTIVA'," & _
                                  "ENTRADA_SALIDA AS 'ENTRADA/ SALIDA' FROM hrs_brt " & _
                                  "WHERE reloj = '" & R & "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & _
                                  FechaHoraSQL(FIni) & "' AND '" & FechaHoraSQL(FFin) & "' ORDER BY fecha,hora", "TA")
            dgHorasBruto.DataSource = dtHrsBrt

            dgHorasBruto.Columns("PERIODO").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgHorasBruto.Columns("GAFETE").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgHorasBruto.Columns("FECHA").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgHorasBruto.Columns("DÍA").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgHorasBruto.Columns("PERIODO").ReadOnly = True
            dgHorasBruto.Columns("GAFETE").ReadOnly = True
            dgHorasBruto.Columns("DÍA").ReadOnly = True
            dgHorasBruto.Columns("TIPO TRANSACCIÓN").ReadOnly = True
            dgHorasBruto.Columns("UNICO").Visible = False
            dgHorasBruto.Columns("FECHA EFECTIVA").ReadOnly = True
            dgHorasBruto.Columns("ENTRADA/ SALIDA").ReadOnly = True

            dtCafeteria = sqlExecute("select Id_registro as Registro, Reloj, Fecha, Hora, horario as Servicio, horarios_cafeteria.nombre as 'Nombre Servicio', subsidio as Subsidio, subsidio_cafeteria.nombre_subsidio as 'Tipo de Descuento' from hrs_brt_cafeteria left join horarios_cafeteria on hrs_brt_cafeteria.horario = horarios_cafeteria.cod_hora_cafe left join subsidio_cafeteria on subsidio_cafeteria.cod_subsidio = hrs_brt_cafeteria.subsidio where reloj = '" & txtReloj.Text & "' and fecha between '" & FechaHoraSQL(FIni) & "' AND '" & FechaHoraSQL(FIni.AddDays(6)) & "' order by fecha, hora, id_registro", "TA")
            dgvCafeteria.DataSource = dtCafeteria
            dgvCafeteria.Columns("Registro").Visible = False
            dgvCafeteria.Columns("Reloj").ReadOnly = True
            dgvCafeteria.Columns("Fecha").ReadOnly = True
            dgvCafeteria.Columns("Servicio").ReadOnly = True
            dgvCafeteria.Columns("Nombre Servicio").ReadOnly = True
            dgvCafeteria.Columns("Subsidio").ReadOnly = True
            dgvCafeteria.Columns("Tipo de Descuento").ReadOnly = True


            dgvCafeteria.AllowUserToAddRows = False
            dgvCafeteria.AllowUserToOrderColumns = False
            dgvCafeteria.AllowUserToResizeColumns = False
            dgvCafeteria.AllowUserToResizeRows = False

            dgvCafeteria.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)

            dgvCafeteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvCafeteria.Columns(dgvCafeteria.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill




            For C = 0 To dgHorasBruto.RowCount - 1
                Dt = IIf(IsDBNull(dgHorasBruto.Item("FECHA EFECTIVA", C).Value), New Date, dgHorasBruto.Item("FECHA EFECTIVA", C).Value)
                dgHorasBruto.Rows(C).DefaultCellStyle.BackColor = IIf(Dt.DayOfWeek Mod 3 = 0, Color.PowderBlue, _
                                                                      IIf(Dt.DayOfWeek Mod 3 = 1, Color.White, Color.LightSteelBlue))
            Next

            dtHistorialHB = sqlExecute("SELECT fecha_original AS 'FECHA CAMBIO DE',hora_original AS 'HORA CAMBIO DE',FECHA AS 'FECHA CAMBIO A'," & _
                                       "HORA AS 'HORA CAMBIO A',TIPO_TRAN AS 'TIPO TRANSACCIÓN',USUARIO,FECHA_CAMBIO AS 'FECHA' " & _
                                       "FROM bitacora_hrs_brt WHERE RELOJ = '" & R & _
                                       "' AND FECHA BETWEEN '" & FechaSQL(FIni) & "' AND '" & FechaSQL(FFin) & _
                                       "' ORDER BY FECHA_CAMBIO DESC ", "TA")
            dgHistorialHB.DataSource = dtHistorialHB
            dgHistorialHB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            dgHistorialHB.Columns(dgHistorialHB.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtAsist = New DataTable
            dtAsist = sqlExecute("SELECT FECHA_ENTRO AS 'FECHA ENTRADA',DIA_ENTRO AS 'DÍA ENTRADA',ENTRO AS 'ENTRADA',HORARIO_ENT AS 'HORARIO ENTRADA'," & _
                                 "DIF_ENT AS 'DIF. ENT.',FECHA_SALIO AS 'FECHA SALIDA',DIA_SALIO AS 'DÍA SALIDA',SALIO AS 'SALIDA',HORARIO_SAL AS 'HORARIO SALIDA'," & _
                                 "DIF_SAL AS 'DIF. SAL.',HORAS AS 'HRS.',HORAS_NORMALES AS 'HRS. NOR.',HORAS_CONVENIO AS 'HRS. COMP.',HORAS_EXTRAS AS 'HRS. EXT.'," & _
                                 "EXTRAS_AUTORIZADAS AS 'EXT. AUT.',RTRIM(COMENTARIO) AS COMENTARIO,dobles_33 AS 'DOBLES 33',triples_33 AS 'TRIPLES 33'," & _
                                 "PERIODO,USUARIO,FECHA,HORA,AUSENTISMO,PAREJA,fal_tran_ent,fal_tran_sal,fha_ent_hor,TIPO_AUS,horas_tarde,horas_anticipadas FROM asist " & _
                                 "WHERE COD_COMP = '" & Comp & "' AND reloj = '" & R & _
                                  "' AND ano = '" & P.Substring(0, 4) & "' AND periodo =  '" & P.Substring(4, 2) & _
                                 "' ORDER BY 'FECHA ENTRADA','FECHA SALIDA',CAST((CASE ENTRO WHEN '' THEN SALIO ELSE ENTRO END) AS TIME)", "TA")

            'MCR 2017-10-09
            'Indicar a qué periodo corresponde la checada, cuando el periodo no es semanal (
            If TipoPeriodoEmpleado <> "S" Then
                For Each dRow As DataRow In dtAsist.Rows
                    dRow("periodo") = ObtenerPeriodo(dRow("fha_ent_hor").ToString, TipoPeriodoEmpleado)
                Next
            End If

            '== AGREGAR DIAS DE DESCANSO A LA VISTA             28SEP2021
            'dgAsist.DataSource = dtAsist
            dgAsist.DataSource = DiasDescanso(dtAsist)



            dtNomSem = sqlExecute("select * FROM nomsem WHERE reloj = '" & R & "' AND ano = '" & P.Substring(0, 4) & "' AND periodo =  '" & P.Substring(4, 2) & "'", "TA")
            If dtNomSem.Rows.Count = 0 Then

                txtHrsNor.Text = 0
                txtHrsDobles.Text = 0
                txtHrsTriples.Text = 0
                txtHrsDobles33.Text = 0
                txtHrsTriples33.Text = 0
                txtHrsDescanso.Text = 0
                txtHrsFestivas.Text = 0
                txtHrsPrimaDom.Text = 0
                txtHrsFel.Text = 0
                txtDiasPagoNomina.Text = 0
                txtBonoProduct.Text = 0


                txtVac.Text = 0
                txtInc.Text = 0
                txtPsin.Text = 0
                txtHrsin.Text = 0
                txtFaltas.Text = 0
                txtRetardos.Text = 0





                btnTransaccion.Checked = False
            Else
                txtHrsNor.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("hrs_normales")), "0.00", dtNomSem.Rows(0).Item("hrs_normales"))
                txtHrsDobles.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("HRS_DOBLES")), "0.00", dtNomSem.Rows(0).Item("HRS_DOBLES"))
                txtHrsTriples.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("hrs_triples")), "0.00", dtNomSem.Rows(0).Item("hrs_triples"))
                txtHrsDobles33.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("DOBLES_33")), 0, dtNomSem.Rows(0).Item("DOBLES_33"))
                txtHrsTriples33.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("TRIPLES_33")), 0, dtNomSem.Rows(0).Item("TRIPLES_33"))
                txtHrsDescanso.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("HRS_DESCANSO")), "0.00", dtNomSem.Rows(0).Item("HRS_DESCANSO"))
                txtHrsFel.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("HRS_FEL")), "0.00", dtNomSem.Rows(0).Item("HRS_FEL"))
                txtHrsFestivas.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("HRS_FESTIVO")), "0.00", dtNomSem.Rows(0).Item("HRS_FESTIVO"))
                txtHrsPrimaDom.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("HRS_PRIM_DOM")), "0.00", dtNomSem.Rows(0).Item("HRS_PRIM_DOM"))
                txtDiasPagoNomina.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("bono06")), "0.00", dtNomSem.Rows(0).Item("bono06"))
                Try : txtBonoProduct.Text = dtNomSem.Rows(0).Item("BONO10") : Catch ex As Exception : txtBonoProduct.Text = "0.00" : End Try



                swPrimaDom.Value = IIf(IsDBNull(dtNomSem.Rows(0).Item("PRIMA_DOM")), 0, dtNomSem.Rows(0).Item("PRIMA_DOM")) = 1
                swPrimaSab.Value = IIf(IsDBNull(dtNomSem.Rows(0).Item("PRIMA_SAB")), 0, dtNomSem.Rows(0).Item("PRIMA_SAB")) = 1

                dblNormalesOrig.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("hrs_normales_original")), "0.00", dtNomSem.Rows(0).Item("hrs_normales_original"))
                dblFestivasOrig.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("hrs_festivo_original")), "0.00", dtNomSem.Rows(0).Item("hrs_festivo_original"))
                btnTransaccion.Checked = IIf(IsDBNull(dtNomSem.Rows(0).Item("TRAN_CERRADA")), 0, dtNomSem.Rows(0).Item("TRAN_CERRADA")) = 1

                txtHrsin.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("hrs_nopag")), "0.00", dtNomSem.Rows(0).Item("hrs_nopag"))
                txtRetardos.Text = IIf(IsDBNull(dtNomSem.Rows(0).Item("hrs_tarde")), "0.00", dtNomSem.Rows(0).Item("hrs_tarde"))

                Dim vacaciones As Integer = 0
                Dim incapacidadeds As Integer = 0
                Dim permiso_sin As Integer = 0
                Dim permiso_con As Integer = 0
                Dim faltas As Integer = 0

                Dim dtausentismos As New DataTable
                dtausentismos = sqlExecute("select * from ausentismo where reloj = '" & R & "' and fecha between '" & FechaSQL(FechaIniPeriodo) & "' and '" & FechaSQL(FechaFinPeriodo) & "'", "TA")

                For Each dr As DataRow In dtausentismos.Rows

                    Select Case Trim(dr("TIPO_AUS"))

                        Case "VAC"
                            vacaciones = vacaciones + 1
                        Case "INA", "ING", "INR", "IMA", "MAT", "RT", "EG"
                            incapacidadeds = incapacidadeds + 1
                        Case "PSG"
                            permiso_sin = permiso_sin + 1
                        Case "FI", "FJ"
                            faltas = faltas + 1
                    End Select

                Next

                txtVac.Text = vacaciones.ToString
                txtInc.Text = incapacidadeds.ToString

                txtPsin.Text = permiso_sin.ToString
                txtFaltas.Text = faltas.ToString
            End If

            TransaccionCerrada = btnTransaccion.Checked
            '*** COLORES DEL GRID DE ASIST ***
            ColoresAsist()
            CrearCambiosHrsBrt()
            CrearDTCambiosAus()
            calAusentismo.CalendarModel.Appointments.Clear()

            'GenerarAppointments()

            If R <> "" Then
                dtAusentismo = sqlExecute("SELECT FECHA,ausentismo.TIPO_AUS as 'TIPO',NOMBRE AS 'DESCRIPCIÓN',REFERENCIA FROM ausentismo " & _
                                          "LEFT JOIN tipo_ausentismo ON  ausentismo.tipo_aus = tipo_ausentismo.tipo_aus WHERE reloj = '" & R & _
                                          "' ORDER BY fecha", "TA")
                C = dtAusentismo.Rows.Count - 1

                Dim Continuo As Boolean = True

                For I = 0 To C
                    FIni = dtAusentismo.Rows(I).Item("fecha")
                    Tipo = dtAusentismo.Rows(I).Item("tipo")
                    Referencia = IIf(IsDBNull(dtAusentismo.Rows(I).Item("REFERENCIA")), "", dtAusentismo.Rows(I).Item("REFERENCIA"))
                    FFin = FIni

                    '*** Si el registro actual no es el último, comparar con el sig. registro, a ver si es ausentismo continuo ***
                    If I < C Then
                        'Si el siguiente registro es el mismo ausentismo
                        Continuo = True
                        Do While Continuo
                            FFin = dtAusentismo.Rows(I).Item("Fecha")
                            If I < C Then
                                Continuo = (IIf(IsDBNull(dtAusentismo.Rows(I + 1).Item("REFERENCIA")), "", dtAusentismo.Rows(I + 1).Item("REFERENCIA")) = Referencia) And dtAusentismo.Rows(I + 1).Item("tipo") = Tipo And (DateDiff(DateInterval.Day, FFin, dtAusentismo.Rows(I + 1).Item("fecha")) = 1 Or FFin = dtAusentismo.Rows(I + 1).Item("fecha"))
                            Else
                                Continuo = False
                            End If
                            If Continuo Then
                                I = I + 1
                            End If
                        Loop
                    End If
                    '*****************************************************************************************************************
                    'ABRAHAM
                    NuevoAusentismo(dtAusentismo.Rows(I).Item("tipo"), IIf(IsDBNull(dtAusentismo.Rows(I).Item("DESCRIPCIÓN")), "", dtAusentismo.Rows(I).Item("DESCRIPCIÓN")), IIf(IsDBNull(dtAusentismo.Rows(I).Item("REFERENCIA")), "", dtAusentismo.Rows(I).Item("REFERENCIA")), FIni, DateAdd(DateInterval.Day, 1, FFin), "", True)
                Next
                calAusentismo.Refresh()
                calAusentismo.ShowDate(txtFechaAusentismo.Value)

                'dgAusentismo.DataSource = dtAusentismo
                'dgAusentismo.Columns("FECHA").Width = 74
                'dgAusentismo.Columns("TIPO").Width = 40
                'dgAusentismo.Columns("DESCRIPCIÓN").Width = 90
                'dgAusentismo.Columns("REFERENCIA").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                HabilitaActivo(R)

                '***************************************************************************************

            End If
            dtCambiosHrsBrt.Rows.Clear()
            dtCambiosAus.Rows.Clear()
            CambioEstiloAsist()

        Catch ex As Exception
            'MessageBox.Show("La información de asistencias no pudo ser cargada correctamente. Si el problema persiste, contacte al administrador del sistema." & _
            '                vbCrLf & vbCrLf & "Err. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub HabilitaActivo(ByVal R As String)
        Dim dtActivo As New DataTable
        Dim PeriodoSeleccionado As String
        Dim PermisoInactivos As Boolean
        Dim EsPeriodoActivo As Boolean
        Dim Activo As Boolean
        Dim dtPerfil As New DataTable
        Dim CodComp As String
        Dim bloquear_reloj As Boolean = False
        Try
            'MCR 12/OCT/2015
            'Habilitar/inhabilitar controles de acuerdo a si es periodo activo, 
            'o el perfil permite cambios a periodo inactivo (15/oct/2015)
            'y si el empleado se encuentra activo en la fecha

            dtPerfil = sqlExecute("SELECT TAperiodos_inactivos FROM perfiles WHERE cod_perfil " & Perfil, "SEGURIDAD")
            If dtPerfil.Rows.Count = 0 Then
                PermisoInactivos = False
            Else
                PermisoInactivos = IIf(IsDBNull(dtPerfil.Rows(0)(0)), 0, dtPerfil.Rows(0)(0)) = 1
            End If
            PeriodoSeleccionado = cmbPeriodos.SelectedValue
            '*** Permitir hacer cambios solamente si se encuentra seleccionado el periodo activo ***
            '*** y la transacción no está cerrada

            If PermisoInactivos Then
                'MCR 15/OCT/2015
                'Si el usuario tiene acceso a editar periodos inactivos, de acuerdo a su perfil, no necesita revisar
                EsPeriodoActivo = True
            Else
                dtTemp = sqlExecute("SELECT activo FROM periodos WHERE ano = '" & PeriodoSeleccionado.Substring(0, 4) & _
                                    "' AND periodo = '" & PeriodoSeleccionado.Substring(4, 2) & "'", "TA")
                If dtTemp.Rows.Count = 0 Then
                    EsPeriodoActivo = False
                Else
                    EsPeriodoActivo = IIf(IsDBNull(dtTemp.Rows(0).Item("activo")), 0, dtTemp.Rows(0).Item("activo")) = 1
                End If
            End If

            If R = "" Then
                Activo = True
                CodComp = ""
            Else
                dtActivo = sqlExecute("select reloj from personal WHERE (baja IS NULL OR baja>='" & FechaSQL(FechaIni) & "') AND (alta<='" & FechaSQL(FechaFin) & _
                                                  "') AND " & "reloj = '" & R & "'")
                Activo = dtActivo.Rows.Count > 0

                dtTemp = sqlExecute("SELECT cod_comp FROM personal WHERE reloj = '" & R & "'")
                CodComp = dtTemp.Rows(0)("cod_comp")
            End If


            Dim asist_perfecta As Boolean = True
            Dim dtasistenciaperf As DataTable = sqlExecute("select * from perfiles where cod_perfil " & Perfil & " and asist_perfecta = '1'", "seguridad")
            If dtasistenciaperf.Rows.Count > 0 Then
                asist_perfecta = True
            Else
                asist_perfecta = False
            End If

            Dim dtRelojUsuario As DataTable = sqlExecute("select reloj as reloj from appuser where username = '" & Usuario & "' and reloj is not null", "seguridad")
            If dtRelojUsuario.Rows.Count > 0 Then
                Dim reloj_usuario As String = dtRelojUsuario.Rows(0)("reloj")
                If reloj_usuario = R Then
                    bloquear_reloj = True
                Else
                    bloquear_reloj = False
                End If
            Else
                bloquear_reloj = False
            End If

            '------AO: 2023-07-31 : Solicita Miriam/Eli que para el perfil de ASIST, solo en el periodo activo de la semana pueda editar a sus empleados
            If Perfil.Contains("ASIST") Then
                Dim fechaHoy As Date = Date.Now(), QBusca As String = "", dtBuscaPer As DataTable, _anio As String = "", _per As String = "", anioPerSel As String = ""
                QBusca = "select ano,PERIODO,FECHA_INI,FECHA_FIN,ACTIVO from ta.dbo.periodos where FECHA_INI<='" & FechaSQL(fechaHoy) & "' and FECHA_FIN>='" & FechaSQL(fechaHoy) & "'"
                dtBuscaPer = sqlExecute(QBusca, "TA")
                If Not dtBuscaPer.Columns.Contains("Error") And dtBuscaPer.Rows.Count > 0 Then
                    Try : _anio = dtBuscaPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : _anio = "" : End Try
                    Try : _per = dtBuscaPer.Rows(0).Item("PERIODO").ToString.Trim : Catch ex As Exception : _per = "" : End Try
                End If
                anioPerSel = PeriodoSeleccionado.Substring(0, 4) & PeriodoSeleccionado.Substring(4, 2)
                If _anio & _per = anioPerSel Then EsPeriodoActivo = True Else EsPeriodoActivo = False

                btnEditar.Visible = Not bloquear_reloj
                btnEditar.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And Not bloquear_reloj
                btnBorrar.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Not bloquear_reloj
                chkPEUS.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And Not bloquear_reloj
                chkPares.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And Not bloquear_reloj
                btnTransaccion.Enabled = EsPeriodoActivo And Activo And Not bloquear_reloj
                btnAnalisis.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And Not bloquear_reloj
                btnCorreccion.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And Not bloquear_reloj
                btnAsistenciaPerfecta.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And asist_perfecta And Not bloquear_reloj
                btnExcepcion.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And Not bloquear_reloj

            Else ' Realizarlo normal
                btnEditar.Visible = Not bloquear_reloj
                btnEditar.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And Not bloquear_reloj
                btnBorrar.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Not bloquear_reloj
                chkPEUS.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And Not bloquear_reloj
                chkPares.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And Not bloquear_reloj
                btnTransaccion.Enabled = EsPeriodoActivo And Activo And Not bloquear_reloj
                btnAnalisis.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And Not bloquear_reloj
                btnCorreccion.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And Not bloquear_reloj
                btnAsistenciaPerfecta.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And asist_perfecta And Not bloquear_reloj
                btnExcepcion.Enabled = EsPeriodoActivo And Not TransaccionCerrada And Activo And Not bloquear_reloj

            End If


            If bloquear_reloj Then
                lblEstado.BackColor = Color.DodgerBlue
            End If

            'MCR 21/OCT/2015
            RevisaExcepciones(Me, CodComp)

            '29/DIC/20          Deshabilitar boton analisis y asistencia Perfecta
            If (Perfil.Contains("SUPERV") Or Perfil.Contains("LIDER") Or Perfil.Contains("GER_AREA")) Then
                'btnAnalisis.Enabled = False
                ' btnAsistenciaPerfecta.Visible = False
                'btnAsistenciaPerfecta.Enabled = False
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub
    Private Sub CambioDiasDescanso(ByVal Rl As String)
        Dim P As String
        Dim F As Date
        Try
            P = cmbPeriodos.SelectedValue
            dtTemp = sqlExecute("SELECT fecha_ini,fecha_fin FROM periodos WHERE ano = '" & P.Substring(0, 4) & _
                                "' AND periodo = '" & P.Substring(4, 2) & "'", "TA")

            F = dtTemp.Rows.Item(0).Item("fecha_ini")
            '***** Refresca días activos del empleado *****
            IDLunes.BackColor = IIf(DiaDescanso(F, Rl), SystemColors.InactiveCaption, SystemColors.HotTrack)
            IDMartes.BackColor = IIf(DiaDescanso(DateAdd(DateInterval.Day, 1, F), Rl), SystemColors.InactiveCaption, SystemColors.HotTrack)
            IDMiercoles.BackColor = IIf(DiaDescanso(DateAdd(DateInterval.Day, 2, F), Rl), SystemColors.InactiveCaption, SystemColors.HotTrack)
            IDJueves.BackColor = IIf(DiaDescanso(DateAdd(DateInterval.Day, 3, F), Rl), SystemColors.InactiveCaption, SystemColors.HotTrack)
            IDViernes.BackColor = IIf(DiaDescanso(DateAdd(DateInterval.Day, 4, F), Rl), SystemColors.InactiveCaption, SystemColors.HotTrack)
            idSabado.BackColor = IIf(DiaDescanso(DateAdd(DateInterval.Day, 5, F), Rl), SystemColors.InactiveCaption, SystemColors.HotTrack)
            idDomingo.BackColor = IIf(DiaDescanso(DateAdd(DateInterval.Day, 6, F), Rl), SystemColors.InactiveCaption, SystemColors.HotTrack)

            '******************************

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub CambioFecha()

        Dim P As String
        Dim D As String = ""
        Try
            P = cmbPeriodos.SelectedValue
            If P Is Nothing Then Exit Sub
            dtTemp = sqlExecute("SELECT fecha_ini,fecha_fin FROM periodos WHERE ano = '" & P.Substring(0, 4) & "' AND periodo = '" & P.Substring(4, 2) & "' and isnull(periodo_especial,0)=0", "TA")
            If dtTemp.Rows.Count = 0 Then
                FechaIni = Now
                FechaFin = Now
            Else
                FechaIni = dtTemp.Rows.Item(0).Item("fecha_ini")
                FechaFin = dtTemp.Rows.Item(0).Item("fecha_fin")
                FechaIniPeriodo = FechaIni
                FechaFinPeriodo = FechaFin
            End If

            If chkSemana.Checked Then
                DiaSemana = 0
                'lblFecha.Text = "Semana del " & FechaCortaLetra(FechaIni) & " al " & FechaCortaLetra(FechaFin)
            Else
                If chkLun.Checked Then
                    DiaSemana = 0
                ElseIf chkMar.Checked Then
                    DiaSemana = 1
                ElseIf chkMie.Checked Then
                    DiaSemana = 2
                ElseIf chkJue.Checked Then
                    DiaSemana = 3
                ElseIf chkVie.Checked Then
                    DiaSemana = 4
                ElseIf chkSab.Checked Then
                    DiaSemana = 5
                ElseIf chkDom.Checked Then
                    DiaSemana = 6
                End If
                If Not IniciaLunes Then
                    'Si la semana no inicia en lunes, ajustar los días considerando que inicia en domingo
                    DiaSemana = IIf(DiaSemana = 6, 0, DiaSemana + 1)
                End If
                FechaIni = DateAdd(DateInterval.Day, DiaSemana, FechaIni)
                FechaFin = FechaIni
                D = DiaSem(FechaIni)
            End If
            If P Is Nothing Then
                Periodo = ""
                Año = ""
            Else
                Año = P.Substring(0, 4)
                Periodo = P.Substring(4)
            End If
            lblDia.Text = FechaLetra(FechaIni)
            lblDia.Visible = Not chkSemana.Checked

            'MCR 12/OCT/2015
            'Habilitar/inhabilitar controles, de acuerdo al día seleccionado
            HabilitaActivo(txtReloj.Text)

            CambioEstiloAsist()
            'For C = 0 To dgAsist.RowCount - 1
            '    'Si selecciona un día en específico, poner negritas el renglón correspondiente a la fecha
            '    dgAsist.Rows(C).DefaultCellStyle.Font = IIf(chkSemana.Checked = False And FechaIni = dgAsist.Item("fha_ent_hor", C).Value, FontBold, FontRegular)
            'Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub CambioEstiloAsist()
        Try

            If chkSemana.Checked Then
                For Each dRw As System.Windows.Forms.DataGridViewRow In dgAsist.Rows
                    dRw.Cells("DIA_ENTRADA").Style.Font = FontBold
                    dRw.Cells("ENTRADA").Style.Font = FontBold
                    dRw.Cells("SALIDA").Style.Font = FontBold
                Next
            Else
                For Each dRw As System.Windows.Forms.DataGridViewRow In dgAsist.Rows
                    If FechaIni = dRw.Cells("fha_ent_hor").Value Then
                        dRw.Cells("DIA_ENTRADA").Style.Font = FontBold
                        dRw.Cells("ENTRADA").Style.Font = FontBold
                        dRw.Cells("SALIDA").Style.Font = FontBold
                    Else
                        dRw.Cells("DIA_ENTRADA").Style.Font = FontRegular
                        dRw.Cells("ENTRADA").Style.Font = FontRegular
                        dRw.Cells("SALIDA").Style.Font = FontRegular
                    End If
                Next
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub chkSemana_CheckedChanged(sender As Object, e As EventArgs) Handles chkSemana.CheckedChanged
        If Not chkSemana.Checked Then chkPares.Checked = False
        pnlSemana.Enabled = Not chkSemana.Checked
        CambioFecha()
    End Sub

    Private Sub chkLun_CheckedChanged(sender As Object, e As EventArgs) Handles chkLun.CheckedChanged
        CambioFecha()
    End Sub

    Private Sub chkMar_CheckedChanged(sender As Object, e As EventArgs) Handles chkMar.CheckedChanged
        CambioFecha()
    End Sub

    Private Sub chkMie_CheckedChanged(sender As Object, e As EventArgs) Handles chkMie.CheckedChanged
        CambioFecha()
    End Sub

    Private Sub chkJue_CheckedChanged(sender As Object, e As EventArgs) Handles chkJue.CheckedChanged
        CambioFecha()
    End Sub

    Private Sub chkVie_CheckedChanged(sender As Object, e As EventArgs) Handles chkVie.CheckedChanged
        CambioFecha()
    End Sub

    Private Sub chkSab_CheckedChanged(sender As Object, e As EventArgs) Handles chkSab.CheckedChanged
        CambioFecha()
    End Sub

    Private Sub chkDom_CheckedChanged(sender As Object, e As EventArgs) Handles chkDom.CheckedChanged
        CambioFecha()
    End Sub



    Private Sub btnAsistenciaPerfecta_Click(sender As Object, e As EventArgs) Handles btnAsistenciaPerfecta.Click
        Dim dtEmpleados As New DataTable
        Dim dtHorarios As New DataTable
        Dim dtErrores As New DataTable
        Dim _cadena As String
        Dim _cod_comp As String
        Dim _cod_tipo As String
        Dim _cod_turno As String
        Dim _cod_hora As String
        Dim _alta As Date
        Dim _baja As Date
        Dim _gafete As String
        Dim i As Integer
        Dim _reloj_analisis As String
        Dim _fecha_analisis As Date
        Dim _periodo As String
        Dim _comentario_criterio_de_evaluacion As String = ""
        Dim _checa_tarjeta As Boolean

        Try
            If chkGlobal.Checked Then
                'MessageBox.Show("Por política de la empresa, no está permitido ingresar asistencia perfecta de forma global", "Asistencia perfecta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Exit Sub
                If MessageBox.Show("¿Está seguro de poner asistencia perfecta a todos los empleados seleccionados?", _
                                   "Asistencia perfecta", _
                                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            ElseIf MessageBox.Show("¿Está seguro de poner asistencia perfecta a empleado " & Reloj & _
                                   ", borrando todos sus registros de entradas/salidas para la(s) fecha(s) seleccionada(s)?", _
                                   "Asistencia perfecta", _
                                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            dtErrores.Columns.Add("DESCRIPCION")

            'Cambiar el cursor a "Modo de espera", para avisar al usuario que está corriendo un proceso
            Me.Cursor = Cursors.WaitCursor

            'Abrir forma para mostrar progress bar
            frmTrabajando.Text = "Asistencia perfecta"
            frmTrabajando.Show(Me)
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Text = "Analizando..."
            frmTrabajando.Avance.IsRunning = True
            Application.DoEvents()

            _reloj_analisis = txtReloj.Text
            _pri_ent_ult_sal = IIf(chkPEUS.Checked, 1, 0)
            _periodo = cmbPeriodos.SelectedValue

            'Consulta de personal de acuerdo a filtros seleccionados
            _cadena = "SELECT reloj,nombres,gafete,personal.cod_comp,cod_depto,personal.cod_planta,cod_puesto,cod_tipo,cod_super,cod_turno,cod_hora,checa_tarjeta,personal.cod_clase," & _
                "alta,baja FROM personal"
            If chkIndividual.Checked Then
                _cadena = _cadena & " WHERE reloj = '" & _reloj_analisis & "'"
            Else
                _cadena = _cadena & IIf(Acumulado.Length > 0, " WHERE 1=1 " & Acumulado, "")
            End If



            ' Si la cadena ya contiene la condición 'WHERE', solo AgregarHrsBrtle el 'AND' para la siguiente condición
            ' Filtrar activos a la fecha final
            _cadena = _cadena & IIf(_cadena.Contains("WHERE"), " AND ", " WHERE ") & " (baja IS NULL OR baja >= '" & FechaSQL(FechaIni) & "')"
            dtEmpleados = ConsultaPersonalVW(_cadena)

            If dtEmpleados.Rows.Count < 0 Then
                MessageBox.Show("No se localizaron empleados para analizar", "Análisis", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            'Determinar el tipo de ausentismo para día festivo 
            dtTemp = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE UPPER(nombre) LIKE '%FESTIVO%'", "TA")
            If dtTemp.Rows.Count = 0 Then
                _aus_festivo = "FES"
            Else
                _aus_festivo = IIf(IsDBNull(dtTemp.Rows(0).Item("tipo_aus")), "FES", dtTemp.Rows(0).Item("tipo_aus")).ToString.Trim
            End If

            frmTrabajando.Avance.Maximum = dtEmpleados.Rows.Count
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = False

            Dim dtper As DataTable
            Dim FIni As Date = Now
            Dim FFin As Date = Now
            dtper = sqlExecute("SELECT fecha_ini,fecha_fin,activo FROM periodos WHERE ano = '" & cmbPeriodos.SelectedValue.ToString.Substring(0, 4) & _
                                    "' AND periodo = '" & cmbPeriodos.SelectedValue.ToString.Substring(4, 2) & "'", "TA")
            FIni = dtper.Rows(0).Item("fecha_ini")
            FFin = dtper.Rows(0).Item("fecha_fin")


            '********** TERMINA ANALISIS CAFETERIA

            ' Evaluar cada empleado seleccionado
            i = 0
            frmTrabajando.Text = "Análisis de asistencia"

            ' Evaluar cada empleado seleccionado
            For Each drEmpleado As DataRow In dtEmpleados.Rows

                Dim alta As Date = drEmpleado("alta")

                '**************BERE
                'Dim dtalta As DataTable


                ' dtalta = sqlExecute("select * from personalvw where alta between '" & FechaSQL(FIni) & "' and '" & FechaSQL(FFin) & "'")
                If alta >= FIni And alta <= FFin Then
                    'For Each row As DataRow In dtalta.Rows
                    'AgregarAsistencia(drEmpleado()
                    CorrigeTransaccion(drEmpleado, alta, cmbPeriodos.SelectedValue, "S")
                    CorrigeTransaccion(drEmpleado, alta.AddDays(1), cmbPeriodos.SelectedValue, "S")
                    'Next
                End If


                i += 1
                frmTrabajando.Avance.Value = i
                frmTrabajando.lblAvance.Text = _reloj_analisis
                My.Application.DoEvents()

                Dim cod_turno As String = "", cod_hora As String = "" '2022-02-09 - AOS

                If cbBitacora.Checked Then
                    'MCR 12/OCT/2015
                    'Si seleccionan revisar bitácora, regresar los campos al último día del periodo anterior
                    ConsultaBitacora(dtEmpleados, drEmpleado, FechaFinPeriodo)
                    cod_turno = ConsultaBitacoraHorarios(dtEmpleados, drEmpleado, FechaFinPeriodo, "cod_turno") ' aos
                    cod_hora = ConsultaBitacoraHorarios(dtEmpleados, drEmpleado, FechaFinPeriodo, "cod_hora")  ' aos
                End If


                drEmpleado("cod_hora") = cod_hora ' AOS
                drEmpleado("cod_turno") = cod_turno ' AOS

                If Not ActivoTrabajando Then Exit For

                _reloj_analisis = drEmpleado("reloj")
                _cod_comp = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp"))
                _cod_tipo = IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo"))
                _cod_turno = IIf(IsDBNull(drEmpleado("cod_turno")), "", drEmpleado("cod_turno"))
                _cod_hora = IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora"))
                _gafete = IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("reloj"), drEmpleado("gafete"))
                _checa_tarjeta = IIf(IsDBNull(drEmpleado("checa_tarjeta")), True, drEmpleado("checa_tarjeta"))
                _fecha_analisis = FechaIni
                _alta = drEmpleado("alta")
                'Si la fecha de baja está en blanco,poner una fecha muuuy adelante, para que siempre sea mayor que la actual
                _baja = IIf(IsDBNull(drEmpleado("baja")), DateSerial(2100, 1, 1), drEmpleado("baja"))

                'Manejo de tipo de semana, considerando horario mixto
                'si no es horario mixto, semana = 1 y factor = 1
                Semana = SemanaHorarioMixto(_periodo, _reloj_analisis)
                dtHorarios = sqlExecute("SELECT horarios.*,dias.*,TA.DBO.HORA12A24(ENTRA) AS ENTRADA24 FROM horarios " & _
                                        "LEFT JOIN dias ON horarios.cod_hora = dias.cod_hora AND horarios.cod_comp = dias.cod_comp " & _
                                        "WHERE horarios.cod_comp = '" & _cod_comp & "' AND horarios.cod_hora = '" & _cod_hora & _
                                        "' AND semana = " & Semana.NumSemana)
                If dtHorarios.Rows.Count = 0 Then
                    'Si no hay información del horario, regresar al ciclo "FOR"
                    dtErrores.Rows.Add({"Falta horario " & IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora")) & " del empleado " & drEmpleado("reloj")})
                    _fecha_analisis = DateAdd(DateInterval.Day, 1, _fecha_analisis)
                    Continue For
                End If

                'Borrar lo que hubiera en asist en este periodo
                sqlExecute("DELETE FROM asist WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & _reloj_analisis & _
                                 "' AND fecha_entro BETWEEN '" & FechaSQL(_fecha_analisis) & "' AND '" & FechaSQL(FechaFin) & "'", "TA")

                Do While _fecha_analisis <= FechaFin
                    If _fecha_analisis >= _alta And _fecha_analisis <= _baja Then
                        DiaSemana = Weekday(_fecha_analisis, IIf(IniciaLunes, FirstDayOfWeek.Monday, FirstDayOfWeek.Sunday))
                        'Tomar información de horarios y días

                        drHorarios = dtHorarios.Select("cod_dia = " & DiaSemana, "entrada24")

                        If drHorarios.Count > 0 Then
                            drHorario = drHorarios(0)
                        Else
                            dtErrores.Rows.Add({"Falta horario " & IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora")) & " del empleado " & drEmpleado("reloj")})
                            Continue For
                        End If

                        AsistenciaPerfecta(drEmpleado, _fecha_analisis, _periodo, _pri_ent_ult_sal)
                        AnalisisHrsBrt(drEmpleado, _fecha_analisis, _periodo.Substring(4, 2), _periodo.Substring(0, 4))
                        Evaluador(drEmpleado, _fecha_analisis, _periodo.Substring(4, 2), _periodo.Substring(0, 4), True)
                    End If
                    _fecha_analisis = DateAdd(DateInterval.Day, 1, _fecha_analisis)
                Loop
                'Llenar tabla de NomSem, para el periodo
                LlenaNomSem(drEmpleado, _periodo, dtAsist)
            Next
            Dim Errores As String = ""
            If dtErrores.Rows.Count > 0 Then
                For Each dr As DataRow In dtErrores.Rows
                    Errores = Errores & IIf(Errores.Length > 0, vbCrLf, "") & dr("descripcion").ToString.Trim
                Next

                Err.Raise(-1, Nothing, Errores)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se encontraron errores durante el proceso. Favor de verificar." & vbCrLf & vbCrLf & "Error.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tpBarra.Enabled = True
            tbInfo.Enabled = True
            Panel1.Enabled = True
            Me.Cursor = Cursors.Default
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            ActualizaInformacionTA()
            chkIndividual.Checked = True
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try

            Dim seltab = tbInfo.SelectedTab.Name

            If seltab = "tabRegistrosCafeteria" Then
                BorrarCafeteria = True
                'dgvCafeteria.Columns.Remove("Subsidio")
                'Dim dgvCombo As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn
                'With dgvCombo
                '    .Width = 150
                '    .AutoCompleteSource = AutoCompleteSource.ListItems
                '    .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                '    dtTemp = sqlExecute("SELECT COD_subsidio FROM subsidio_cafeteria ORDER BY COD_subsidio", "TA")
                '    For x = 0 To dtTemp.Rows.Count - 1
                '        .Items.Add(dtTemp.Rows.Item(x).Item("COD_subsidio"))
                '    Next

                '    .DataPropertyName = "Subsidio"
                '    .HeaderText = "Subsidio"
                '    .Name = "Subsidio"
                'End With
                'dgvCafeteria.Columns.Insert(6, dgvCombo)

            End If

            If seltab = "tabExcepcionhrs" Then
                Dim i As Integer
                Dim dtperiodoseleccionado As New DataTable
                Dim dtperiodoactual As New DataTable
                Dim periodoactual As String
                Dim periodoseleccionado As String

                i = dgExcepcionHorarios.PrimaryGrid.ActiveRow.RowIndex

                dtperiodoactual = sqlExecute("select * from periodos where (fecha_ini <= '" & FechaSQL(Date.Today) & "' and fecha_fin >= '" & FechaSQL(Date.Today) & "' )", "TA")
                periodoactual = dtperiodoactual.Rows(0).Item("periodo")

                dtperiodoseleccionado = sqlExecute("select * from periodos where (fecha_ini <= '" & FechaSQL(dgExcepcionHorarios.PrimaryGrid.GetCell(i, 2).Value) & "' and fecha_fin >= '" & FechaSQL(dgExcepcionHorarios.PrimaryGrid.GetCell(i, 2).Value) & "' )", "TA")
                periodoseleccionado = dtperiodoseleccionado.Rows(0).Item("periodo")

                If Not sqlExecute("select * from periodos where periodo = '" & periodoseleccionado & "' and activo = '1'", "TA").Rows.Count > 0 Then
                    If periodoactual <> periodoseleccionado Then
                        MessageBox.Show("No puedes editar la excepción de un periodo no activo pasado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        frmExcepcionHorarios.RlExcep = dgExcepcionHorarios.PrimaryGrid.GetCell(i, 0).Value & dgExcepcionHorarios.PrimaryGrid.GetCell(i, 2).Value
                        frmEditarExcepcionHorarios.ShowDialog()
                    End If
                Else
                    frmExcepcionHorarios.RlExcep = dgExcepcionHorarios.PrimaryGrid.GetCell(i, 0).Value & dgExcepcionHorarios.PrimaryGrid.GetCell(i, 2).Value
                    frmEditarExcepcionHorarios.ShowDialog()
                End If




                Me.btnRefrescar.RaiseClick()
            Else
                CambiaHoras = False
                If EsBaja And txtBaja.Value < FechaIni Then
                    MessageBox.Show("El empleado no estuvo activo en este periodo, por lo que no puede modificarse su información de asistencias.", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If Not Editar Then
                        Editar = True
                        txtNombre.Focus()

                    Else
                        Editar = False

                        ActualizaInformacionTA()
                    End If
                    HabilitarBotones()
                End If

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub HabilitarBotones()
        Try
            'Dim SI As Integer
            btnFirst.Enabled = Not Editar
            btnPrev.Enabled = Not Editar
            btnNext.Enabled = Not Editar
            btnLast.Enabled = Not Editar

            btnBuscar.Enabled = Not Editar
            btnCerrar.Enabled = Not Editar
            btnBorrar.Enabled = Not Editar

            btnNuevo.Visible = Editar
            If EditarRegistros Then
                dgHorasBruto.ReadOnly = (Not Editar)
            Else
                dgHorasBruto.ReadOnly = True
            End If


            '****Controles de Horas para nómina *****
            For Each Control In gpHoras.Controls
                If TypeOf Control Is DevComponents.Editors.DoubleInput Then
                    Control.enabled = Editar And EditarHorasParaNomina
                ElseIf TypeOf Control Is DevComponents.DotNetBar.Controls.SwitchButton Then
                    Control.IsReadOnly = (Not Editar) And (Not EditarHorasParaNomina)
                End If
            Next

            For Each Control In gpPrimaDS.Controls
                If TypeOf Control Is DevComponents.Editors.DoubleInput Then
                    Control.IsInputReadOnly = Not Editar
                ElseIf TypeOf Control Is DevComponents.DotNetBar.Controls.SwitchButton Then
                    Control.IsReadOnly = Not Editar
                End If
            Next

            '===Dejar deshabilitado el bono de productividad
            txtBonoProduct.Enabled = False

            '***************************************
            pnlEditarAusentismo.Enabled = Editar And EditarAusentismo

            btnAgregarAus.Visible = EditarAusentismo
            btnBorrarAus.Visible = EditarAusentismo

            'Abraham()

            'mnuAgregarAusentismo.Enabled = Editar
            'mnuBorrarAusentismo.Enabled = Editar

            If dgHorasBruto.Columns.Count > 0 Then
                dgHorasBruto.Columns("PERIODO").ReadOnly = True
                dgHorasBruto.Columns("GAFETE").ReadOnly = True
                dgHorasBruto.Columns("GAFETE").ReadOnly = True
                dgHorasBruto.Columns("DÍA").ReadOnly = True
                dgHorasBruto.Columns("TIPO TRANSACCIÓN").ReadOnly = True
                dgHorasBruto.Columns("FECHA").DefaultCellStyle.Font = IIf(Editar, FontBold, FontRegular)
                dgHorasBruto.Columns("HORA").DefaultCellStyle.Font = IIf(Editar, FontBold, FontRegular)
            End If


            If Editar Then
                ' Si está activa la edición o nuevo registro
                btnNuevo.Image = PIDA.My.Resources.Ok16
                btnEditar.Image = PIDA.My.Resources.CancelX
                btnNuevo.Text = "Aceptar"
                btnEditar.Text = "Cancelar"
                dgHorasBruto.Item(2, 0).Selected = True


            Else
                btnNuevo.Image = PIDA.My.Resources.NewRecord
                btnEditar.Image = PIDA.My.Resources.Edit

                btnNuevo.Text = "Agregar"
                btnEditar.Text = "Editar"

                BorrarCafeteria = False
                pnlDetalleAusentismo.Enabled = False
                cmbAusentismo.SelectedValue = ""
                txt1.Value = Nothing
                txtDias.Value = 1
                txtReferencia.Text = ""

                '== Cuando se da en cancelar a la edición, los botones de las faltas se vuelven nuevamente invisibles       Abril 2021      Ernesto
                lblClas.Visible = False
                cmbClasFalta.SelectedValue = ""
                cmbClasFalta.Enabled = False
                cmbClasFalta.Visible = False

            End If
            btnEditar.Enabled = Editar Or btnTransaccion.Checked = False

            'MCR 19/OCT/2015
            'Agregar en cada forma que requiera excepciones en los controles
            'Se controlan desde PERFILES
            'Considerar mandar llamar este procedimiento cada vez que se habiliten/inhabiliten controles que aplican
            RevisaExcepciones(Me)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try


    End Sub

    Private Sub chkActivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivos.CheckedChanged
        'Dim Filtro As String
        Try
            Dim I As Integer = -1
            If chkActivos.Checked Then
                chkBajas.Checked = False
                chkTodos.Checked = False
                chkRevision.Checked = False
                Dim Filtro As String

                Filtro = "ALTA <= '" & FechaSQL(FechaFinPeriodo) & "' AND (BAJA IS NULL OR BAJA >= '" & FechaSQL(FechaIniPeriodo) & "')"

                Filtros(1, NFiltros) = "ACTIVOS"
                Filtros(2, NFiltros) = Filtro

                NFiltros = NFiltros + 1

                ReDim Preserve Filtros(2, NFiltros)
                lstFiltros.Items.Add(Filtro)
            Else
                'Actualiza lista de filtros
                Dim x As Integer

                For x = 0 To NFiltros - 1
                    If Filtros(1, x) = "ACTIVOS" Then
                        I = x
                        Exit For
                    End If
                Next

                If I < 0 Then Exit Sub
                lstFiltros.Items.RemoveAt(I)

                For x = I To NFiltros - 1
                    Filtros(1, x) = Filtros(1, x + 1)
                    Filtros(2, x) = Filtros(2, x + 1)
                Next
                NFiltros = NFiltros - 1
                ReDim Preserve Filtros(2, x)

            End If

            FiltrosActivos()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub FiltrosActivos()
        Dim R As String
        Try
            R = txtReloj.Text.Trim
            tabFiltros.Text = "Filtros "
            If chkActivos.Checked Then
                tabFiltros.Text = tabFiltros.Text & " - ACTIVOS"
            ElseIf chkBajas.Checked Then
                tabFiltros.Text = tabFiltros.Text & " - BAJAS"
            End If

            If chkOtrosFiltros.Checked Then
                tabFiltros.Text = tabFiltros.Text & " - OTROS"
            End If

            If Not (chkActivos.Checked Or chkBajas.Checked Or chkOtrosFiltros.Checked) Then
                chkTodos.Checked = True
                tabFiltros.PredefinedColor = tabAsistencias.PredefinedColor
                tabFiltros.Image = Nothing
            Else
                chkTodos.Checked = False
                tabFiltros.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Green
                tabFiltros.Image = My.Resources.FiltroHC
            End If
            Acumulado = FiltrosAcumulados()

            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * FROM personalvw WHERE reloj = '" & R & "' " & _
                                          Acumulado & " ORDER BY reloj ASC", False)
            If dtTemp.Rows.Count = 0 Then
                btnNext.PerformClick()
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub chkBajas_CheckedChanged(sender As Object, e As EventArgs) Handles chkBajas.CheckedChanged
        Try
            Dim I As Integer = -1
            If chkBajas.Checked Then
                chkActivos.Checked = False
                chkTodos.Checked = False
                chkRevision.Checked = False
                Dim Filtro As String
                Filtro = "BAJA >= '" & FechaSQL(FechaIniPeriodo) & "' AND BAJA <= '" & FechaSQL(FechaFinPeriodo) & "'"

                Filtros(1, NFiltros) = "BAJAS"
                Filtros(2, NFiltros) = Filtro

                NFiltros = NFiltros + 1

                ReDim Preserve Filtros(2, NFiltros)
                lstFiltros.Items.Add(Filtro)
            Else
                'Actualiza lista de filtros
                Dim x As Integer

                For x = 0 To NFiltros - 1
                    If Filtros(1, x) = "BAJAS" Then
                        I = x
                        Exit For
                    End If
                Next

                If I < 0 Then Exit Sub
                lstFiltros.Items.RemoveAt(I)

                For x = I To NFiltros - 1
                    Filtros(1, x) = Filtros(1, x + 1)
                    Filtros(2, x) = Filtros(2, x + 1)
                Next
                NFiltros = NFiltros - 1
                ReDim Preserve Filtros(2, x)
            End If

            FiltrosActivos()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnSeleccionarFiltros_Click(sender As Object, e As EventArgs) Handles btnSeleccionarFiltros.Click
        Dim dtPersonalFaltante As New DataTable
        Try
            RangoFInicial = FechaIni
            RangoFFinal = FechaFin

            dtResultadoTA = sqlExecute("SELECT * FROM TAVW WHERE FHA_ENT_HOR between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & _
                                       "'", "ta")

            dtPersonalFaltante = sqlExecute("SELECT RELOJ,COD_COMP,ALTA,AMATERNO,APATERNO,NOMBRE,NOMBRES,AVISO_ACC,BAJA,BANCO," & _
                                            "CHECA_TARJETA,COD_CD,COD_CIVIL,COD_CLASE AS 'COD_CLASE_PERSONAL',COD_COL,COD_COMP AS 'COD_COMP_PERSONAL'," & _
                                            "COD_DEPTO AS 'COD_DEPTO_PERSONAL',COD_EDO,COD_HORA,COD_LINEA,COD_MOT_BA,COD_MOT_IM,COD_PLANTA," & _
                                            "COD_PUESTO AS 'COD_PUESTO_PERSONAL',COD_SUPER AS 'COD_SUPER_PERSONAL',COD_TIPO AS 'COD_TIPO_PERSONAL'," & _
                                            "COD_TURNO AS 'COD_TURNO_PERSONAL',COMENTARIO AS 'COMENTARIO_PERSONAL',CREDITO_IN,CUENTA_BANCO,CURP," & _
                                            "DIAS_AGUINALDO,DIAS_VACACIONES,DIG_VER,DIG_VER_IN,DIRECCION,FACTOR_INT,FAH_PARTIC,FAH_PORCEN,FECHA_CRE," & _
                                            "FHA_NAC,FHA_ULT_EV,FHA_ULT_MO,GAFETE AS 'GAFETE_PERSONAL',IMSS,INFONAVIT,INTEGRADO," & _
                                            "LUGARN,NIVEL,NOMBRE,NOMBRE_DEPTO AS 'NOMBRE_DEPTO_PERSONAL',NOMBRE_HORARIO AS 'NOMBRE_HORARIO_PERSONAL'," & _
                                            "NOMBRE_PUESTO AS 'NOMBRE_PUESTO_PERSONAL',NOMBRE_SUPER AS 'NOMBRE_SUPER_PERSONAL',NOMBRE_PLANTA," & _
                                            "PAGO_INF,PAGO_SEGVI,PRO_VAR,RECONTRATA,RFC,SACTUAL,SAL_ANT,SEXO,TELEFONO,TIPO_CRE," & _
                                            "TIPO_PAGO,HORAS AS HORAS_TURNO,UMF,EDAD,ESCOLARIDAD,ANTIGUEDAD,FOTO,NOMBRE_COLONIA,NOMBRE_TIPOEMP," & _
                                            "NOMBRE_TURNO,NOMBRE_CLASE,LUGAR_NAC,MOTIVO_BAJA " & _
                                            "FROM PERSONALVW WHERE RELOJ not in " & _
                                            "(SELECT RELOJ FROM ta.dbo.TAVW WHERE FHA_ENT_HOR between '" & FechaSQL(RangoFInicial) & "' and '" & _
                                            FechaSQL(RangoFFinal) & "') AND (BAJA IS NULL OR baja>' " & FechaSQL(RangoFInicial) & "')" & _
                                            " AND alta <= '" & FechaSQL(RangoFFinal) & "'")

            For Each dEmp As DataRow In dtPersonalFaltante.Rows
                dtResultadoTA.ImportRow(dEmp)
            Next

            Dim Filtro As String
            frmFiltroTA.ShowDialog()
            Acumulado = FiltrosAcumulados()

            chkOtrosFiltros.Checked = NFiltros > 0

            Filtro = ""
            lstFiltros.Items.Clear()
            For x = 0 To NFiltros - 1
                lstFiltros.Items.Add(Filtros(2, x))
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try


    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        Try
            If chkTodos.Checked Then
                chkActivos.Checked = False
                chkBajas.Checked = False
                chkRevision.Checked = False
                chkOtrosFiltros.Checked = False
                lstFiltros.Items.Clear()
                NFiltros = 0
            End If

            If Not (chkActivos.Checked Or chkBajas.Checked Or chkOtrosFiltros.Checked) Then
                chkTodos.Checked = True
            End If

            'FiltrosActivos()

            Try
                Dim reloj As String
                reloj = txtReloj.Text
                Acumulado = FiltroXUsuario

                'MCR 25/Ene/2016
                'Agregar IIf(Acumulado.Length > 0, " AND " & Acumulado, "") para corregir error en query
                'Producto del error, al cambiar periodo se cambia de registro
                dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * FROM personalvw WHERE reloj ='" & reloj & "' " & _
                                                IIf(Acumulado.Length > 0, " AND " & Acumulado, "") & " ORDER BY reloj ASC", False)
                If dtPersonal.Rows.Count > 0 Then
                    reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
                    MostrarInformacion(reloj)
                Else
                    btnNext.PerformClick()
                End If


            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkOtrosFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtrosFiltros.CheckedChanged
        Try
            If Not chkOtrosFiltros.Checked Then

                Dim I As Integer = -1

                'Limpiar todos los filtros
                NFiltros = 0
                lstFiltros.Items.Clear()

                'Si estaban seleccionados los activos, agregar el filtro nuevamente
                If chkActivos.Checked Then
                    Dim Filtro As String

                    Filtro = "ALTA <= '" & FechaSQL(FechaFinPeriodo) & "' AND (BAJA IS NULL OR BAJA >= '" & FechaSQL(FechaIniPeriodo) & "')"

                    Filtros(1, NFiltros) = "ACTIVOS"
                    Filtros(2, NFiltros) = Filtro

                    NFiltros = NFiltros + 1
                    ReDim Preserve Filtros(2, NFiltros)
                    lstFiltros.Items.Add(Filtro)
                End If

                'Si estaban seleccionadas las bajas, agregar el filtro nuevamente
                If chkBajas.Checked Then
                    chkActivos.Checked = False
                    chkTodos.Checked = False
                    Dim Filtro As String
                    Filtro = "BAJA BETWEEN '" & FechaSQL(FechaIniPeriodo) & "' AND '" & FechaSQL(FechaFinPeriodo) & "'"

                    Filtros(1, NFiltros) = "BAJAS"
                    Filtros(2, NFiltros) = Filtro

                    NFiltros = NFiltros + 1

                    ReDim Preserve Filtros(2, NFiltros)
                    lstFiltros.Items.Add(Filtro)
                End If

                If chkRevision.Checked Then
                    chkBajas.Checked = False
                    chkActivos.Checked = False
                    chkOtrosFiltros.Checked = False
                    chkTodos.Checked = False
                    Dim Filtro As String
                    Filtro = "USUARIO_NOTA IS NOT NULL"

                    Filtros(1, NFiltros) = "REVISAR"
                    Filtros(2, NFiltros) = Filtro

                    NFiltros = NFiltros + 1

                    ReDim Preserve Filtros(2, NFiltros)
                    lstFiltros.Items.Add(Filtro)
                End If
            End If
            FiltrosActivos()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonMonth_Click(sender As Object, e As EventArgs)
        Try
            calAusentismo.SelectedView = eCalendarView.Month
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAnual_Click(sender As Object, e As EventArgs)
        Try
            calAusentismo.SelectedView = eCalendarView.Year
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregarAus.Click

        If pnlDetalleAusentismo.Enabled = False Then
            pnlDetalleAusentismo.Enabled = True
            cmbAusentismo.SelectedValue = ""
            txt1.Value = Nothing
            txtDias.Value = 1
            txtReferencia.Text = ""
            txtNotasAusentismo.Text = ""
        End If

    End Sub

    Public Sub NuevoAusentismo(Tipo As String, Descripcion As String, Referencia As String, FechaInicio As Date, FechaFin As Date, Optional Reloj As String = "", Optional Inicial As Boolean = False)
        Try
            Dim appointment As New DevComponents.Schedule.Model.Appointment
            Dim aptAjuste As New DevComponents.Schedule.Model.Appointment
            Dim dAus As DataRow

            Dim D As Boolean
            Dim Unico As String
            Dim Naturaleza As String
            Dim NaturalezaOverLap() As String
            Dim Sustituir As Boolean
            Dim Incapacidad As Boolean
            Dim x As Integer


            Static ID As Integer = 0
            ID = ID + 1
            'If calAusentismo.DateSelectionStart.GetValueOrDefault <> New Date Then
            D = DiaDescanso(FechaInicio, Reloj)
            Unico = IIf(Inicial, FechaSQL(FechaInicio) & "A" & FechaSQL(FechaFin), "NUEVO" & ID.ToString.PadLeft(6, "0"))
            appointment.Tag = Unico
            appointment.StartTime = FechaInicio ' New Date(startdate.Year, startdate.Month, startdate.Day)
            appointment.EndTime = FechaFin ' New Date(enddate.Year, enddate.Month, enddate.Day)
            appointment.CategoryColor = Tipo.Trim
            appointment.Subject = Tipo
            appointment.Description = Descripcion & IIf(Referencia.Length > 0, vbCrLf & "Referencia: " & Referencia, "")
            appointment.Tooltip = Descripcion.ToUpper.Trim

            dtTemp = sqlExecute("SELECT tipo_naturaleza FROM tipo_ausentismo WHERE tipo_aus ='" & Tipo & "'", "TA")
            If dtTemp.Rows.Count > 0 Then
                Naturaleza = dtTemp.Rows(0).Item(0)
            Else
                Naturaleza = "A"
            End If


            If calAusentismo.CalendarModel.ContainsOverlappingAppointments(appointment) Then
                Dim apEmp() As DevComponents.Schedule.Model.AppointmentSubsetCollection
                Dim rwEmpalme() As DataRow

                'Buscar en dtCambiosAus el ausentismo ya capturado para este rango de fecha
                rwEmpalme = dtCambiosAus.Select("(fecha_ini>='" & FechaSQL(FechaInicio) & "' AND fecha_ini<='" & FechaSQL(FechaFin) & "') OR (fecha_fin>='" & FechaSQL(FechaInicio) & "' AND fecha_fin<='" & FechaSQL(FechaFin) & "') AND movimiento <> 'B'")

                ReDim apEmp(rwEmpalme.Count - 1)
                ReDim NaturalezaOverLap(rwEmpalme.Count - 1)
                For x = 0 To rwEmpalme.Count - 1
                    apEmp(x) = calAusentismo.CalendarModel.GetDay(rwEmpalme(x).Item("FECHA_INI")).Appointments

                    NaturalezaOverLap(x) = TipoNaturaleza(apEmp(x).Item(0).Subject)
                    If NaturalezaOverLap(x) = "INC" Then
                        Incapacidad = True
                    End If
                Next

                If Not Inicial Then
                    If Incapacidad Then
                        MessageBox.Show("En este periodo se encuentra una incapacidad capturada. Favor de verificar.", "Incapacidad", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If Naturaleza = "A" Then
                        Sustituir = MessageBox.Show("Hay " & x & IIf(x = 1, " ausentismo capturado", " diferentes ausentismos capturados") & " para este rango de fechas. ¿Desea sustituirlo?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        Sustituir = True
                    End If
                Else
                    Sustituir = True
                End If
                If Sustituir Then
                    Dim FI As Date
                    Dim FF As Date

                    For x = 0 To apEmp.Count - 1
                        If apEmp(x).Item(0).StartTime < FechaInicio Then
                            aptAjuste = apEmp(x).Item(0)
                            FI = aptAjuste.StartTime
                            FF = FechaInicio

                            apEmp(x).Item(0).EndTime = FechaInicio

                            If aptAjuste.EndTime > FechaFin Then
                                apEmp(x).Item(0).StartTime = FechaFin

                                calAusentismo.CalendarModel.Appointments.Add(aptAjuste)
                                calAusentismo.EnsureVisible(aptAjuste)
                            End If
                        ElseIf apEmp(x).Item(0).EndTime > FechaFin Then
                            apEmp(x).Item(0).StartTime = FechaFin
                        Else
                            calAusentismo.CalendarModel.Appointments.Remove(apEmp(x).Item(0))
                        End If
                    Next
                End If
            End If
            'dtCambiosAus.PrimaryKey = New DataColumn() {dtCambiosAus.Columns("UNICO")}
            dAus = dtCambiosAus.Rows.Find(Unico)
            If dAus Is Nothing Then
                dtCambiosAus.Rows.Add({FechaInicio, FechaFin, Tipo, Referencia, Unico, IIf(Inicial, "I", "A"), txtNotasAusentismo.Text})
            Else

            End If

            calAusentismo.CalendarModel.Appointments.Add(appointment)
            calAusentismo.EnsureVisible(appointment)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnHoy_Click(sender As Object, e As EventArgs)
        calAusentismo.ShowDate(txtFechaAusentismo.Value)
    End Sub

    Private Sub calAusentismo_AppointmentViewChanged(sender As Object, e As AppointmentViewChangedEventArgs) Handles calAusentismo.AppointmentViewChanged
        Dim Unico As String
        Dim startdate As Date
        Dim enddate As Date
        Dim Tipo As String
        Dim Notas As String
        Dim Referencias As String
        Dim UI As Date
        Dim N As Integer
        Try
            Static ID As Integer = 100
            ID = ID + 1

            Unico = calAusentismo.SelectedAppointments.Item(0).Appointment.Tag
            startdate = calAusentismo.SelectedAppointments.Item(0).Appointment.StartTime
            enddate = calAusentismo.SelectedAppointments.Item(0).Appointment.EndTime
            Tipo = calAusentismo.SelectedAppointments.Item(0).Appointment.Subject

            'MCR 22/OCT/2015
            'Cambio para tomar valores que solo están en la tabla, no en el "appointment"
            N = Unico.IndexOf("A")
            If N > 0 Then
                UI = Unico.Substring(0, N)
            Else
                UI = startdate
            End If

            dtTemp = sqlExecute("SELECT subclasi,referencia FROM ausentismo WHERE reloj = '" & txtReloj.Text.Trim & "' AND fecha = '" & FechaSQL(UI) & "'", "TA")
            If dtTemp.Rows.Count > 0 Then
                Notas = IIf(IsDBNull(dtTemp.Rows(0).Item("subclasi")), "", dtTemp.Rows(0).Item("subclasi")).ToString.Trim
                Referencias = IIf(IsDBNull(dtTemp.Rows(0).Item("referencia")), "", dtTemp.Rows(0).Item("referencia")).ToString.Trim
            Else
                Notas = ""
                Referencias = ""
            End If

            Dim dR As DataRow
            dR = dtCambiosAus.Rows.Find(Unico)

            If IsNothing(dR) Then
                'MCR 22/OCT/2015
                'Agregar tipo, referencias y notas desde variables
                dtCambiosAus.Rows.Add(startdate, enddate, Tipo, Referencias, Unico, "X", Notas)
            Else
                'MCR 22/OCT/2015
                'Agregar tipo, referencias y notas desde variables

                dR.Item("FECHA_INI") = startdate
                dR.Item("FECHA_FIN") = enddate
                dR.Item("TIPO") = Tipo
                dR.Item("REFERENCIA") = Referencias
                If dR.Item("MOVIMIENTO") = "I" Then
                    dR.Item("MOVIMIENTO") = "C"
                End If
                dR.Item("SUBCLASI") = Notas
            End If
            cmbAusentismo.SelectedValue = calAusentismo.SelectedAppointments.Item(0).Appointment.Subject

            txt1.Value = calAusentismo.SelectedAppointments.Item(0).Appointment.StartTime
            txtDias.Value = 0
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub calAusentismo_ItemDoubleClick(sender As Object, e As MouseEventArgs) Handles calAusentismo.ItemDoubleClick
        Try
            Dim item As AppointmentView = TryCast(sender, AppointmentView)

            If item IsNot Nothing Then
                Dim ap As Appointment = item.Appointment
                Dim Ref As String = ""
                Dim Des As String = ""
                Dim i As Integer
                If ap.Description.Trim.ToUpper.Contains("REFERENCIA") Then
                    i = ap.Description.Trim.IndexOf("Referencia")
                    Ref = ap.Description.Substring(i).Trim
                    If Ref.Length < 12 Then Ref = ""
                ElseIf ap.Description.ToUpper.Contains("FESTIVO") Then
                    dtTemp = sqlExecute("SELECT nombre FROM festivos WHERE festivo =  '" & FechaSQL(ap.StartTime) & "'", "TA")
                    If dtTemp.Rows.Count = 0 Then
                        Ref = "NO IDENTIFICADO"
                    Else
                        Ref = IIf(IsDBNull(dtTemp.Rows(0).Item("NOMBRE")), "", dtTemp.Rows(0).Item("NOMBRE")).ToString.Trim
                    End If
                    i = ap.Description.Trim.Length
                Else
                    i = ap.Description.Trim.Length
                End If
                Des = ap.Description.Trim.Substring(0, i).Trim.ToUpper

                Dim s As String = String.Format("{0}" & vbLf & "   Del día {1}" & vbLf & "   al día {2}", _
                                               Des & vbCrLf & "   " & Ref, FechaLetra(ap.StartTime), FechaLetra(DateAdd(DateInterval.Second, -1, ap.EndTime)))
                MessageBox.Show(s, "AUSENTISMO - " & ap.Subject.Trim, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub calAusentismo_SelectedViewChanged(sender As Object, e As SelectedViewEventArgs) Handles calAusentismo.SelectedViewChanged
        Try
            sbVista.Value = (calAusentismo.SelectedView = eCalendarView.Month)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub calAusentismo_KeyUp(sender As Object, e As KeyEventArgs) Handles calAusentismo.KeyUp
        Try
            If e.KeyData = Keys.Delete And Editar Then
                BorrarAusentismo()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub BorrarAusentismo()
        Try
            Dim Unico As String
            Unico = calAusentismo.SelectedAppointments.Item(0).Appointment.Tag

            Dim dR As DataRow
            dR = dtCambiosAus.Rows.Find(Unico)
            If Not IsNothing(dR) Then
                If dR.Item("MOVIMIENTO") = "I" Then
                    If MessageBox.Show("Este ausentismo ya se encuentra almacenado en la base de datos. ¿Está seguro de querer eliminarlo?", "Borrar ausentismo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then
                        Exit Sub

                    End If
                End If
                dR.Item("MOVIMIENTO") = "B"
            Else
                dR = dtCambiosAus.NewRow
                dR("movimiento") = "B"
                dR("unico") = Unico
                dR("fecha_ini") = calAusentismo.SelectedAppointments.Item(0).StartTime
                dR("fecha_fin") = calAusentismo.SelectedAppointments.Item(0).EndTime
                dtCambiosAus.Rows.Add(dR)
            End If
            calAusentismo.CalendarModel.Appointments.Remove(calAusentismo.SelectedAppointments(0).Appointment)
            ActualizarCambiosAus()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub calAusentismo_BeforeAppointmentViewChange(sender As Object, e As BeforeAppointmentViewChangeEventArgs) Handles calAusentismo.BeforeAppointmentViewChange
        e.Cancel = Not Editar
    End Sub

    Private Sub txt1_Click(sender As Object, e As EventArgs) Handles txt1.Click
        DesdeCalendario = False
    End Sub

    Private Sub txt1_GotFocus(sender As Object, e As EventArgs) Handles txt1.GotFocus
        DesdeCalendario = False
    End Sub

    Private Sub txt1_Validated(sender As Object, e As EventArgs) Handles txt1.Validated
        Try
            If txt1.Value = New Date Then
                txt1.Value = Now
            End If
            calAusentismo.DateSelectionStart = txt1.Value
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            'SelTab = tbInfo.SelectedTab.Name
            'Select Case SelTab
            'Case "tabHorasNomina"
            ActualizarCambiosHrsBrt()
            'ActualizarHorasNomina()
            'Case "tabHorasBruto"

            'Case "tabAusentismo"

            'MCR 11/NOV/2015
            'Si se editaron las horas, guardar dato registrado
            If CambiaHoras Then
                Dim R As String = txtReloj.Text
                ActualizaNomSem(R, "hrs_normales", txtHrsNor.Value, Año, Periodo)

                ActualizaNomSem(R, "hrs_dobles", txtHrsDobles.Value, Año, Periodo)
                ActualizaNomSem(R, "hrs_triples", txtHrsTriples.Value, Año, Periodo)

                ActualizaNomSem(R, "hrs_prim_dom", txtHrsPrimaDom.Value, Año, Periodo)
                ActualizaNomSem(R, "hrs_descanso", txtHrsDescanso.Value, Año, Periodo)
                ActualizaNomSem(R, "hrs_fel", txtHrsFel.Value, Año, Periodo)
                ActualizaNomSem(R, "hrs_festivo", txtHrsFestivas.Value, Año, Periodo)


                ActualizaNomSem(R, "dobles_33", txtHrsDobles33.Value, Año, Periodo)
                ActualizaNomSem(R, "triples_33", txtHrsTriples33.Value, Año, Periodo)
                ActualizaNomSem(R, "bono06", txtDiasPagoNomina.Value, Año, Periodo)
                ActualizaNomSem(R, "BONO10", txtBonoProduct.Value, Año, Periodo)

                CambiaHoras = False
            End If

            ActualizarCambiosAus()
            'End Select
            ActualizaInformacionTA()

            Editar = False
            CambiaHoras = False
            HabilitarBotones()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub ActualizarHorasNomina()
        Try
            Dim R As String
            R = txtReloj.Text
            dtTemp = sqlExecute("SELECT reloj FROM nomsem WHERE reloj = '" & R & "' AND ano = '" & Año & "' AND periodo = '" & Periodo & "'", "TA")
            If dtTemp.Rows.Count = 0 Then
                dtTemp = sqlExecute("INSERT INTO nomsem (reloj,ano,periodo,tran_cerrada) VALUES ('" & R & "','" & Año & "','" & Periodo & _
                                    "',0)", "TA")
            End If
            ActualizaNomSem(R, "hrs_normales", txtHrsNor.Value, Año, Periodo)
            ActualizaNomSem(R, "hrs_dobles", txtHrsDobles.Value, Año, Periodo)
            ActualizaNomSem(R, "hrs_triples", txtHrsTriples.Value, Año, Periodo)
            ActualizaNomSem(R, "hrs_prim_dom", txtHrsPrimaDom.Value, Año, Periodo)
            ActualizaNomSem(R, "hrs_descanso", txtHrsDescanso.Value, Año, Periodo)
            ActualizaNomSem(R, "hrs_fel", txtHrsFel.Value, Año, Periodo)
            ActualizaNomSem(R, "hrs_festivo", txtHrsFestivas.Value, Año, Periodo)
            ActualizaNomSem(R, "bono06", txtDiasPagoNomina.Value, Año, Periodo)
            ActualizaNomSem(R, "BONO10", txtBonoProduct.Value, Año, Periodo)

            ActualizaNomSem(R, "dobles_33", txtHrsDobles33.Value, Año, Periodo)
            ActualizaNomSem(R, "triples_33", txtHrsTriples33.Value, Año, Periodo)
            ActualizaNomSem(R, "semana", SemanaHorarioMixto(Año & Periodo, R).NumSemana, Año, Periodo)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub ActBorradoHrsBrt(fecHora As String, fecha As String)
        Dim NoReloj As String = ""
        Dim Unico As String = ""
        Dim FecOriginal As Date
        Dim cadenaFec_Hora As String = ""
        Dim HoraOriginal As String = ""
        NoReloj = txtReloj.Text
        FecOriginal = FechaSQL(fecha)
        cadenaFec_Hora = fecHora
        HoraOriginal = cadenaFec_Hora.Substring(11).Trim
        Try
            sqlExecute("INSERT INTO bitacora_hrs_brt (reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) " & _
                       "VALUES('" & NoReloj & " ','" & FecOriginal & "','','" & Usuario & "',GETDATE(),'B','" & FecOriginal & "','" & HoraOriginal & "')", "TA")
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ActualizarCambiosHrsBrt()
        Dim I As Integer
        Dim M As String
        Dim U As String
        Dim R As String
        Dim G As String
        Dim C As String
        Dim F As Date
        Dim H As String
        Dim T As String = ""
        Dim CH As Boolean
        Dim Inserta As Boolean
        Try
            R = txtReloj.Text
            dtTemp = sqlExecute("SELECT cod_comp,gafete FROM personal WHERE reloj = '" & R & "'")
            G = IIf(IsDBNull(dtTemp.Rows(0).Item("gafete")), R, dtTemp.Rows(0).Item("gafete"))
            C = dtTemp.Rows(0).Item("cod_comp")
            CH = CambiaHoras

            For I = 0 To dtCambiosHrsBrt.Rows.Count - 1
                Inserta = True
                M = dtCambiosHrsBrt.Rows(I).Item("movimiento")
                U = dtCambiosHrsBrt.Rows(I).Item("unico")
                F = dtCambiosHrsBrt.Rows(I).Item("fecha")
                H = IIf(IsDBNull(dtCambiosHrsBrt.Rows(I).Item("hora")), "", dtCambiosHrsBrt.Rows(I).Item("hora"))
                Select Case M
                    Case "A"
                        sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,dia,periodo,tipo_tran,pareja,preus,ano) VALUES ('" & _
                                   C & "','" & R & "','" & G & "','" & FechaSQL(F) & "','" & MerMilitar(H) & "','" & DiaSem(F) & "','" & _
                                   Periodo & "','A',1," & IIf(chkPEUS.Checked, 1, 0) & ",'" & Año & "')", "TA")
                        T = "N"
                        U = FechaSQL(F) & " " & H
                    Case "B"
                        sqlExecute("DELETE FROM hrs_brt WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(U) & _
                                   "' AND hora = '" & U.Substring(U.IndexOf(" ")).Trim & "'", "TA")
                        T = "B"
                    Case "C"
                        If FechaSQL(F) & "  " & H = U Or FechaSQL(F) & " " & H = U Then
                            'MCR 21/OCT/2015
                            'Se registra cambio simplemente con dejar la celda
                            'Hay que validar que realmente haya cambiado algo para modificar la tabla
                            Inserta = False
                        Else
                            sqlExecute("UPDATE hrs_brt SET fecha = '" & FechaSQL(F) & _
                                       "', hora = '" & MerMilitar(H) & _
                                       "', dia = '" & DiaSem(F) & _
                                       "', tipo_tran = 'A' " & _
                                       "WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(U.Substring(0, U.IndexOf(" "))) & "' AND hora = '" & _
                                       U.Substring(U.IndexOf(" ")).Trim & "'", "TA")
                        End If
                        T = "A"
                End Select
                If Inserta Then
                    'MCR 21/OCT/2015
                    'Solo si hubo cambio, se inserta y reanaliza
                    'Insertar en bitácora de horas en bruto
                    sqlExecute("INSERT INTO bitacora_hrs_brt " & _
                               "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                               R & "','" & _
                               FechaSQL(F) & "','" & _
                               MerMilitar(H) & "','" & _
                               Usuario & "'," & _
                               "GETDATE(),'" & _
                               T & "','" & _
                               U.Substring(0, 10) & "','" & _
                               U.Substring(11).Trim & "')", "TA")


                    ReEvaluar(R, F.AddDays(-1))
                    CambiaHoras = CH
                    ReEvaluar(R, F)
                    CambiaHoras = CH
                End If
            Next
            dtCambiosHrsBrt.Rows.Clear()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ReEvaluar(R As String, F As Date)
        Dim dtEmpleados As New DataTable
        Dim dtHorarios As New DataTable
        Dim drEmpleado As DataRow

        Dim _cadena As String
        Dim _cod_comp As String
        Dim _cod_tipo As String
        Dim _cod_turno As String
        Dim _cod_hora As String
        Dim _gafete As String

        Dim _reloj_analisis As String
        Dim _fecha_analisis As Date
        Dim _periodo As String
        Dim _comentario_criterio_de_evaluacion As String = ""
        Dim _descanso As Boolean = False
        Dim _festivo As Boolean = False
        Dim _abierto As Boolean = False
        Dim _checa_tarjeta As Boolean

        Dim _seg_horas_ex As Integer = 0
        Dim _comentario As String = ""
        Dim tm As DateTime = Now

        Try
            _reloj_analisis = R
            _pri_ent_ult_sal = IIf(chkPEUS.Checked, 1, 0)
            _periodo = cmbPeriodos.SelectedValue

            dtTemp = sqlExecute("SELECT fecha_ini,fecha_fin FROM periodos WHERE ano = '" & _periodo.Substring(0, 4) & "' AND periodo = '" & _periodo.Substring(4, 2) & "'", "TA")
            If dtTemp.Rows(0).Item("fecha_ini") > F Or F > dtTemp.Rows(0).Item("fecha_fin") Then
                Exit Sub
            End If

            'Formar la cadena de búsqueda, dependiendo de si el análisis es individual o global
            'MCR OCT-30-2020 (INCLUIR TIPO_PERIODO)
            _cadena = "SELECT reloj,nombres,gafete,alta,baja,personalvw.cod_comp,cod_depto,personalvw.cod_planta,cod_puesto,cod_tipo,cod_super,cod_turno,cod_hora,checa_tarjeta,personalvw.cod_clase,tipo_periodo FROM personalvw "
            _cadena = _cadena & " WHERE reloj = '" & _reloj_analisis & "'"

            ' Filtrar activos a la fecha final
            dtEmpleados = ConsultaPersonalVW(_cadena, False)

            If dtEmpleados.Rows.Count < 0 Then
                MessageBox.Show("No se localizaron empleados para analizar", "Análisis", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Evaluar cada empleado seleccionado
            drEmpleado = dtEmpleados.Rows(0)

            Dim cod_hora As String = "", cod_turno As String = "" ' ' aos 2022-02-10
            If cbBitacora.Checked Then
                'MCR 12/OCT/2015
                'Si seleccionan revisar bitácora, regresar los campos al último día del periodo anterior
                ConsultaBitacora(dtEmpleados, drEmpleado, FechaFinPeriodo)
                cod_turno = ConsultaBitacoraHorarios(dtEmpleados, drEmpleado, FechaFinPeriodo, "cod_turno") ' ' aos 2022-02-10
                cod_hora = ConsultaBitacoraHorarios(dtEmpleados, drEmpleado, FechaFinPeriodo, "cod_hora") ' ' aos 2022-02-10
            End If
            drEmpleado("cod_hora") = cod_hora ' ' aos 2022-02-10
            drEmpleado("cod_turno") = cod_turno ' ' aos 2022-02-10

            frmTrabajando.lblAvance.Text = _reloj_analisis
            '& " " & _fecha_analisis.ToShortDateString
            Application.DoEvents()
            _cod_comp = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp"))
            _cod_tipo = IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo"))
            _cod_turno = IIf(IsDBNull(drEmpleado("cod_turno")), "", drEmpleado("cod_turno"))

            _cod_hora = IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora"))
            '_cod_hora = ValorBitacora(R, "cod_hora", F)

            _gafete = IIf(IsDBNull(drEmpleado("gafete")), "", drEmpleado("gafete"))
            _checa_tarjeta = IIf(IsDBNull(drEmpleado("checa_tarjeta")), True, drEmpleado("checa_tarjeta"))
            _fecha_analisis = F


            'Revisar si la transacción está cerrada
            dtTemp = sqlExecute("SELECT tran_cerrada FROM nomsem WHERE reloj = '" & Reloj & "' AND ano + periodo = '" & _periodo & "'", "TA")
            If dtTemp.Rows.Count > 0 Then
                'Si el registro se localiza en NomSem, y está registrado como transacción cerrada, regresa al siguiente registro del FOR
                If IIf(IsDBNull(dtTemp.Rows(0).Item("tran_cerrada")), 0, dtTemp.Rows(0).Item("tran_cerrada")) = 1 Then
                    Exit Sub
                End If
            End If

            Semana = SemanaHorarioMixto(_periodo, _reloj_analisis)
            DiaSemana = Weekday(_fecha_analisis, IIf(IniciaLunes, FirstDayOfWeek.Monday, FirstDayOfWeek.Sunday))
            'Tomar información de horarios y días
            dtHorarios = sqlExecute("SELECT horarios.*,dias.*,TA.DBO.HORA12A24(ENTRA) AS ENTRADA24 FROM horarios " & _
                                    "LEFT JOIN dias ON horarios.cod_hora = dias.cod_hora AND horarios.cod_comp = dias.cod_comp " & _
                                    "WHERE horarios.cod_comp = '" & _cod_comp & "' AND horarios.cod_hora = '" & _cod_hora & _
                                    "' and dias.cod_dia = " & DiaSemana & " AND semana = " & Semana.NumSemana & " ORDER BY TA.DBO.HORA12A24(ENTRA)")


            If dtHorarios.Rows.Count > 0 Then
                drHorario = dtHorarios.Rows(0)
                'MCR 25/Ene/2016
                'Corrección de error NO horas en nómina, descanso trabajado
                drHorarios = dtHorarios.Select("cod_dia = " & DiaSemana, "entrada24")
            Else
                'Si no hay información del horario, regresar al ciclo "DO"
                Debug.Print("No hay información de horarios para empleado " & Reloj)
                _fecha_analisis = DateAdd(DateInterval.Day, 1, _fecha_analisis)
                Exit Sub
            End If

            'MCR OCT-29-2020
            'TIEMPO COMPLETO EN FECHA DE ALTA
            If (drEmpleado("alta")) = _fecha_analisis Then
                dtTemp = sqlExecute("select reloj from ta.dbo.TiempoCompleto where reloj = '" & _reloj_analisis & "' and fecha = '" & FechaSQL(_fecha_analisis) & "'", "TA")
                If dtTemp.Rows.Count <= 0 Then
                    sqlExecute("insert into ta.dbo.TiempoCompleto (reloj, fecha, usuario, registro) values ('" & _reloj_analisis & "', '" & drEmpleado("alta") & "', '" & Usuario & "', getdate())")
                End If
            End If
            'MCR ****************************

            'Borrar datos de asist que pudiera haber de esta fecha
            sqlExecute("DELETE FROM asist WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & _reloj_analisis & _
                                  "' AND fha_ent_hor ='" & FechaSQL(_fecha_analisis) & "'", "TA")
            'Borrar fecha efectiva del hrs_brt, que pudiera haber quedado de evaluaciones anteriores
            sqlExecute("UPDATE hrs_brt SET fecha_efva = NULL WHERE RELOJ ='" & _reloj_analisis & "' AND fecha_efva = '" & FechaSQL(_fecha_analisis) & "'", "TA")

            'Analizar horas en bruto, para asignar entradas y salidas
            If drHorario("descanso") Then
                AnalisisHrsBrtPares(drEmpleado, _periodo.Substring(0, 4), _periodo.Substring(4, 2), _fecha_analisis, _fecha_analisis)
            Else
                AnalisisHrsBrt(drEmpleado, _fecha_analisis, _periodo.Substring(4, 2), _periodo.Substring(0, 4))
            End If
            'Evaluar las horas en bruto, para llenar el asist
            Evaluador(drEmpleado, _fecha_analisis, _periodo.Substring(4, 2), _periodo.Substring(0, 4))
            'Llenar tabla de NomSem, para el periodo
            LlenaNomSem(drEmpleado, _periodo, dtAsist)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ActualizarCambiosAus()
        Dim N As Integer
        Dim M As String
        Dim U As String
        Dim R As String
        Dim C As String
        Dim Fecha As Date
        Dim FI As Date
        Dim FF As Date
        Dim T As String
        Dim E As String

        Dim notas As String = ""

        Dim UI As Date
        Dim UF As Date

        Dim cnt As Integer
        Dim _saldo_tiempo As Double
        Dim _saldo_dinero As Double
        Dim _prima As Double
        Dim Ano As String
        Dim D As Integer
        Dim drEmpleado As DataRow
        Dim dtExiste As DataTable
        Dim resultado As String
        Dim guardar As Boolean
        Dim aus_anterior As String
        Dim dtEmp As New DataTable
        Try
            R = txtReloj.Text
            dtEmp = sqlExecute("SELECT cod_comp,gafete,reloj,tipo_periodo FROM personal WHERE reloj = '" & R & "'")
            drEmpleado = dtEmp.Rows(0)
            C = dtEmp.Rows(0).Item("cod_comp")
            dtCambiosAus.Rows.Find("movimiento='A'")
            For Each dr In dtCambiosAus.Select("movimiento <> 'I'")
                M = dr("movimiento")
                U = dr("unico")
                FI = dr("fecha_ini")
                FF = dr("fecha_fin")
                T = IIf(IsDBNull(dr("tipo")), "", dr("tipo"))
                E = IIf(IsDBNull(dr("referencia")), "", dr("referencia"))
                Try
                    notas = IIf(IsDBNull(dr("subclasi")), "", dr("subclasi"))


                Catch ex As Exception

                End Try

                N = U.IndexOf("A")
                If N > 0 Then
                    UI = U.Substring(0, N)
                    UF = U.Substring(N + 1)
                Else
                    UI = FI
                    UF = FF
                End If

                If TipoNaturaleza(T) = "V" Then
                    'Si son vacaciones, tratar diferente para actualizar saldos
                    dtTemp = sqlExecute("SELECT fecha FROM ausentismo WHERE reloj = '" & R & _
                                        "' AND fecha BETWEEN '" & FechaSQL(FI) & "' AND '" & FechaSQL(FF) & "'" & _
                                        "AND tipo_aus = '" & T & "'", "TA")
                    cnt = dtTemp.Rows.Count

                    dtTemp = sqlExecute("SELECT TOP 1 saldo_tiempo,saldo_dinero,prima,ano FROM saldos_vacaciones WHERE " & _
                                        "RELOJ = '" & R & "' ORDER BY  fecha_captura DESC")
                    If dtTemp.Rows.Count > 0 Then
                        _saldo_tiempo = dtTemp.Rows(0).Item("saldo_tiempo")
                        _saldo_dinero = dtTemp.Rows(0).Item("saldo_dinero")
                        _prima = dtTemp.Rows(0).Item("prima")
                        Ano = dtTemp.Rows(0).Item("ano")
                    Else
                        _saldo_tiempo = 0
                        _saldo_dinero = 0
                        Ano = Now.Year
                        _prima = 0
                    End If

                    D = 0
                    Fecha = FI
                    Select Case M
                        Case "A"
                            Do Until FI = FF
                                'MCR 15/OCT/2015
                                'Insertar en bitácora borrado de ausentismo
                                sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                              "(reloj,fecha,tipo_aus,fecha_movimiento,usuario_movimiento,notas) " & _
                                           "SELECT reloj,fecha,tipo_aus,GETDATE(),'" & Usuario & _
                                           "','/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/Met: " & _
                                           System.Reflection.MethodBase.GetCurrentMethod.Name() & _
                                           " para insertar vacaciones' FROM ausentismo WHERE reloj = '" & R & _
                                           "' AND  fecha = '" & FechaSQL(FI) & "'", "TA")

                                sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & R & "' AND  fecha = '" & FechaSQL(FI) & "'", "TA")

                                If Not Festivo(FI, R) And Not DiaDescanso(FI, R) Then
                                    sqlExecute("INSERT INTO ausentismo (cod_comp,reloj,fecha,tipo_aus,referencia, subclasi,usuario,fecha_hora) VALUES ('" & _
                                               C & "','" & _
                                               R & "','" & _
                                               FechaSQL(FI) & "','" & _
                                               T & "','" & _
                                               E & "', '" & _
                                               notas.Replace("'", "") & "', '" & _
                                               Usuario & "', " & _
                                               "GETDATE())", "TA")
                                    D += 1
                                End If
                                FI = DateAdd(DateInterval.Day, 1, FI)

                            Loop

                            sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                                   "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                                   R & "','" & _
                                   Ano & "'," & _
                                   _prima & "," & _
                                   _saldo_dinero & "," & _
                                   _saldo_tiempo - D & "," & _
                                   D & "," & _
                                   0 & _
                                   ",'VACACIONES CAPTURADAS DESDE T&A " & "','" & _
                                   FechaSQL(Fecha) & "','" & _
                                   FechaSQL(FF) & "',GETDATE())")
                        Case "B"
                            'MCR 15/OCT/2015
                            'Insertar en bitácora borrado de ausentismo
                            sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                          "(reloj,fecha,tipo_aus,fecha_movimiento,usuario_movimiento,notas) " & _
                                       "SELECT reloj,fecha,tipo_aus,GETDATE(),'" & Usuario & _
                                       "','/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/','Borrar vacaciones desde " & _
                                       System.Reflection.MethodBase.GetCurrentMethod.Name() & "' FROM ausentismo WHERE reloj = '" & R & _
                                       "' AND  fecha BETWEEN '" & FechaSQL(UI) & "' AND '" & FechaSQL(UF) & "'", "TA")

                            sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & R & "' AND fecha BETWEEN '" & FechaSQL(UI) & "' AND '" & FechaSQL(UF) & "'", "TA")

                            D = 0
                            Do Until FI = FF
                                If Not Festivo(FI, R) And Not DiaDescanso(FI, R) Then
                                    D += 1
                                End If
                                FI = DateAdd(DateInterval.Day, 1, FI)
                            Loop

                            sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                                       "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                                       R & "','" & _
                                       Ano & "'," & _
                                       _prima & "," & _
                                       _saldo_dinero & "," & _
                                       _saldo_tiempo + D & "," & _
                                       -D & "," & _
                                       0 & _
                                       ",'CANCELAR VACACIONES DESDE T&A','" & _
                                       FechaSQL(FI) & "','" & _
                                       FechaSQL(FF) & "',GETDATE())")
                        Case "C", "X"
                            'MCR 15/OCT/2015
                            'Insertar en bitácora borrado de ausentismo
                            sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                          "(reloj,fecha,tipo_aus,fecha_movimiento,usuario_movimiento,notas) " & _
                                       "SELECT reloj,fecha,tipo_aus,GETDATE(),'" & Usuario & _
                                       "','/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/Met: " & _
                                       System.Reflection.MethodBase.GetCurrentMethod.Name() & " para reemplazar por vacaciones' FROM ausentismo WHERE reloj = '" & R & _
                                       "' AND  fecha BETWEEN '" & FechaSQL(UI) & "' AND '" & FechaSQL(UF) & "'", "TA")

                            sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & R & "' AND fecha BETWEEN '" & FechaSQL(UI) & "' AND '" & FechaSQL(UF) & "'", "TA")

                            D = 0
                            Do Until FI = FF
                                If Not Festivo(FI, R) And Not DiaDescanso(FI, R) Then
                                    sqlExecute("INSERT INTO ausentismo (cod_comp,reloj,fecha,tipo_aus,referencia, subclasi) VALUES ('" & _
                                               C & "','" & _
                                               R & "','" & _
                                               FechaSQL(FI) & "','" & _
                                               T & "','" & _
                                               E & "', '" & _
                                               notas.Replace("'", "") & "','" & _
                                               Usuario & "', " & _
                                               "GETDATE())", "TA")

                                    D += 1
                                End If
                                FI = DateAdd(DateInterval.Day, 1, FI)
                            Loop

                            sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                                       "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                                       R & "','" & _
                                       Ano & "'," & _
                                       _prima & "," & _
                                       _saldo_dinero & "," & _
                                       _saldo_tiempo - (D - cnt) & "," & _
                                       (D - cnt) & "," & _
                                       0 & _
                                       ",'MODIFICAR VACACIONES DESDE T&A " & "','" & _
                                       FechaSQL(Fecha) & "','" & _
                                       FechaSQL(FF) & "',GETDATE())")
                            ''" &  FechaHoraSQL(Now, False, False) & "'
                    End Select

                Else
                    'Cualquier otro tipo de ausentismo, simplemente actualizar cambios
                    Select Case M
                        Case "A"
                            Do Until FI = FF
                                'MCR 15/OCT/2015
                                'Insertar en bitácora borrado de ausentismo
                                sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                              "(reloj,fecha,tipo_aus,fecha_movimiento,usuario_movimiento,notas) " & _
                                           "SELECT reloj,fecha,tipo_aus,,GETDATE(),'" & Usuario & _
                                           "','/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/Met: " & _
                                           System.Reflection.MethodBase.GetCurrentMethod.Name() & " para insertar " & T & "' FROM ausentismo WHERE reloj = '" & R & _
                                           "' AND  fecha = '" & FechaSQL(FI) & "'", "TA")

                                sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & R & "' AND  fecha = '" & FechaSQL(FI) & "'", "TA")

                                sqlExecute("INSERT INTO ausentismo (cod_comp,reloj,fecha,tipo_aus,referencia, subclasi) VALUES ('" & _
                                                                    C & "','" & _
                                                                    R & "','" & _
                                                                    FechaSQL(FI) & "','" & _
                                                                    T & "','" & _
                                                                    E & "', '" & _
                                                                    notas & "','" & _
                                                                    Usuario & "', " & _
                                                                    "GETDATE())", "TA")
                                FI = DateAdd(DateInterval.Day, 1, FI)
                            Loop
                        Case "B"
                            'MCR 15/OCT/2015
                            'Insertar en bitácora borrado de ausentismo
                            sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                          "(reloj,fecha,tipo_aus,fecha_movimiento,usuario_movimiento,notas) " & _
                                       "SELECT reloj,fecha,tipo_aus,GETDATE(),'" & Usuario & _
                                            "','/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/Met: " & _
                                            System.Reflection.MethodBase.GetCurrentMethod.Name() & " (borrar)' FROM ausentismo WHERE reloj = '" & R & _
                                            "' AND  fecha BETWEEN '" & FechaSQL(UI) & "' AND '" & FechaSQL(UF) & "'", "TA")

                            sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & R & "' AND fecha BETWEEN '" & FechaSQL(UI) & "' AND '" & FechaSQL(UF) & "'", "TA")

                        Case "C", "X"
                            'MCR 15/OCT/2015
                            'Insertar en bitácora borrado de ausentismo

                            Fecha = FI

                            dtExiste = sqlExecute("select tipo_aus from ausentismo where cod_comp = '" & drEmpleado("cod_comp") & _
                                                                          "' and reloj = '" & drEmpleado("reloj") & "' and fecha BETWEEN '" & _
                                                                          FechaSQL(FI) & "' AND '" & FechaSQL(FF) & "'", "TA")
                            If dtExiste.Rows.Count Then
                                aus_anterior = dtExiste.Rows(0)("tipo_aus")
                                If aus_anterior <> T Then
                                    If MessageBox.Show("¿Desea sustituir el ausentimo " & aus_anterior & ", existente entre la fecha " & FechaSQL(FI) & _
                                                     " y " & FechaSQL(FF) & "?", "PIDA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                        guardar = False
                                    Else
                                        guardar = True
                                    End If
                                End If
                            End If
                            FI = Fecha

                            sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                          "(reloj,fecha,tipo_aus,fecha_movimiento,usuario_movimiento,notas) " & _
                                       "SELECT reloj,fecha,tipo_aus,GETDATE(),'" & Usuario & _
                                            "','/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/Met: " & _
                                            System.Reflection.MethodBase.GetCurrentMethod.Name() & " por edición' FROM ausentismo WHERE reloj = '" & R & _
                                            "' AND  fecha BETWEEN '" & FechaSQL(UI) & "' AND '" & FechaSQL(UF) & "'", "TA")


                            sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & R & "' AND fecha BETWEEN '" & FechaSQL(UI) & "' AND '" & FechaSQL(UF) & "'", "TA")

                            Do Until FI = FF
                                'MCR 2017-10-12
                                'Revisar si existe, y debe hacer una devolución de ausentismo
                                resultado = DevolucionAusentismo(drEmpleado, FI, T)
                                If Not resultado Is Nothing Then
                                    Err.Raise(-1, resultado)
                                End If
                                sqlExecute("INSERT INTO ausentismo (cod_comp,reloj,fecha,tipo_aus,referencia,subclasi,usuario,fecha_hora) VALUES ('" & _
                                           C & "','" & _
                                           R & "','" & _
                                           FechaSQL(FI) & "','" & _
                                           T & "','" & _
                                           E & "',  '" & _
                                           notas.Replace("'", "") & "','" & _
                                           Usuario & "', " & _
                                           "GETDATE())", "TA")
                                FI = DateAdd(DateInterval.Day, 1, FI)
                            Loop
                    End Select
                End If

            Next
            dtCambiosAus.Rows.Clear()

            pnlDetalleAusentismo.Enabled = False
            cmbAusentismo.SelectedValue = ""
            txt1.Value = Nothing
            txtDias.Value = 1
            txtReferencia.Text = ""

            'GenerarAppointments()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub tbInfo_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles tbInfo.SelectedTabChanged
        Try
            Dim SelTab As String
            SelTab = tbInfo.SelectedTab.Name
            btnBorrar.Visible = ((SelTab = "tabHorasBruto") And btnTransaccion.Checked = False) Or (SelTab = "tabExcepcionhrs")
            Acumulado = FiltrosAcumulados()
            'MCR 21/OCT/2015
            'Revisar nuevamente las excepciones, en caso de que incluyan al botón de borrar
            RevisaExcepciones(Me)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgHorasBruto_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgHorasBruto.CellBeginEdit

        Try

            If IsDBNull(dgHorasBruto.Item("UNICO", e.RowIndex).Value) Then
                ValorUnico = ""
            Else
                ValorUnico = dgHorasBruto.Item("UNICO", e.RowIndex).Value
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgHorasBruto_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgHorasBruto.CellEndEdit
        Dim OldVal As String, NewVal As String
        Dim Fecha As String
        Dim Hora As String
        Dim Indice As String
        Try
            If IsDBNull(dgHorasBruto.Item("FECHA", e.RowIndex).Value) Then
                Fecha = ""
            Else
                Fecha = FechaSQL(dgHorasBruto.Item("FECHA", e.RowIndex).Value)

                Try
                    Dim _f As Date = Date.Parse(Fecha)


                    If Not (_f >= FechaIniPeriodo And _f <= DateAdd(DateInterval.Day, 1, FechaFinPeriodo)) Then
                        MessageBox.Show("La fecha no se encuentra dentro del periodo seleccionado. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    ElseIf (_f < txtAlta.Value) Then
                        MessageBox.Show("La fecha es menor a la fecha de alta. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    ElseIf (_f > txtBaja.Value) And txtBaja.Visible = True Then
                        MessageBox.Show("La fecha es mayor a la fecha de baja. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Catch ex As Exception

                End Try

            End If
            Hora = IIf(IsDBNull(dgHorasBruto.Item("HORA", e.RowIndex).Value), "", dgHorasBruto.Item("HORA", e.RowIndex).Value)

            If Hora Is Nothing Or Fecha = "0001-01-01" Or Fecha = "" Then Exit Sub
            OldVal = ValorUnico
            NewVal = Fecha + " " + Hora

            If OldVal <> NewVal Then
                Select Case e.ColumnIndex
                    Case 2
                        If Not IsDBNull(dgHorasBruto.Item(2, e.RowIndex).Value) Then
                            dgHorasBruto.Item(4, e.RowIndex).Value = DiaSem(dgHorasBruto.Item(2, e.RowIndex).Value)
                        End If
                    Case 3
                        If Not IsDBNull(dgHorasBruto.Item(3, e.RowIndex).Value) Then
                            dgHorasBruto.Item(3, e.RowIndex).Value = MerMilitar(CtoHSimple(dgHorasBruto.Item(3, e.RowIndex).Value))
                        End If

                End Select
                dgHorasBruto.Item(5, e.RowIndex).Value = "A"

                If AgregarHrsBrt Then
                    Indice = "NUEVO" & e.RowIndex
                    dgHorasBruto.Item("UNICO", e.RowIndex).Value = Indice
                Else
                    Indice = dgHorasBruto.Item("UNICO", e.RowIndex).Value
                End If
                Dim dR As DataRow
                dR = dtCambiosHrsBrt.Rows.Find(Indice)
                If IsNothing(dR) Then
                    dtCambiosHrsBrt.Rows.Add(dgHorasBruto.Item("FECHA", e.RowIndex).Value, dgHorasBruto.Item("HORA", e.RowIndex).Value, Indice, IIf(AgregarHrsBrt, "A", "C"))
                Else
                    dR.Item("FECHA") = dgHorasBruto.Item("FECHA", e.RowIndex).Value
                    dR.Item("HORA") = dgHorasBruto.Item("HORA", e.RowIndex).Value
                End If
                AgregarHrsBrt = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgHorasBruto_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgHorasBruto.UserAddedRow
        Try
            AgregarHrsBrt = True
            dgHorasBruto.Item("PERIODO", e.Row.Index - 1).Value = Periodo
            dgHorasBruto.Item("GAFETE", e.Row.Index - 1).Value = IIf(IsDBNull(dtPersonal.Rows(0).Item("gafete")), dtPersonal.Rows(0).Item("RELOJ"), dtPersonal.Rows(0).Item("gafete"))
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgHorasBruto_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgHorasBruto.UserDeletingRow
        Try
            If Editar Then
                e.Cancel = Not BorrarRegistro(e.Row.Index)
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Function BorrarRegistro(ByVal idx As Integer) As Boolean
        Dim Indice As String
        Dim dR As DataRow
        Try
            Indice = dgHorasBruto.Item("UNICO", idx).Value
            If MessageBox.Show("¿Está seguro de borrar el registro " & Indice & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                dR = dtCambiosHrsBrt.Rows.Find(Indice)
                If IsNothing(dR) Then
                    dtCambiosHrsBrt.Rows.Add(dgHorasBruto.Item("FECHA", idx).Value, dgHorasBruto.Item("HORA", idx).Value, Indice, "B")
                Else
                    dR.Item("MOVIMIENTO") = "B"
                End If
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function
    Private Function CrearDTCambiosAus() As Boolean
        Try
            Dim Columnas(6) As DataColumn

            dtCambiosAus = New DataTable("CambiosAus")
            Columnas(0) = New DataColumn("FECHA_INI")
            Columnas(0).DataType = System.Type.GetType("System.DateTime")
            Columnas(1) = New DataColumn("FECHA_FIN")
            Columnas(1).DataType = System.Type.GetType("System.DateTime")
            Columnas(2) = New DataColumn("TIPO")
            Columnas(2).DataType = System.Type.GetType("System.String")
            Columnas(3) = New DataColumn("REFERENCIA")
            Columnas(3).DataType = System.Type.GetType("System.String")
            Columnas(4) = New DataColumn("UNICO")
            Columnas(4).DataType = System.Type.GetType("System.String")
            Columnas(5) = New DataColumn("MOVIMIENTO")
            Columnas(5).DataType = System.Type.GetType("System.String")
            Columnas(6) = New DataColumn("SUBCLASI")
            Columnas(6).DataType = System.Type.GetType("System.String")

            For x = 0 To UBound(Columnas)
                dtCambiosAus.Columns.Add(Columnas(x))
            Next
            dtCambiosAus.PrimaryKey = New DataColumn() {dtCambiosAus.Columns("UNICO")}
            'dgCambiosAus.DataSource = dtCambiosAus
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CrearCambiosHrsBrt() As Boolean
        Try
            Dim Columnas(3) As DataColumn

            dtCambiosHrsBrt = New DataTable("CambiosHrsBrt")
            Columnas(0) = New DataColumn("FECHA")
            Columnas(0).DataType = System.Type.GetType("System.DateTime")
            Columnas(1) = New DataColumn("HORA")
            Columnas(1).DataType = System.Type.GetType("System.String")
            Columnas(2) = New DataColumn("UNICO")
            Columnas(2).DataType = System.Type.GetType("System.String")
            Columnas(3) = New DataColumn("MOVIMIENTO")
            Columnas(3).DataType = System.Type.GetType("System.String")

            For x = 0 To UBound(Columnas)
                dtCambiosHrsBrt.Columns.Add(Columnas(x))
            Next
            dtCambiosHrsBrt.PrimaryKey = New DataColumn() {dtCambiosHrsBrt.Columns("UNICO")}
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub dgHorasBruto_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgHorasBruto.CellValidating
        Dim x As Date
        Try
            If Editar And e.ColumnIndex = 2 And EditarRegistros Then
                If tbInfo.SelectedTab.Equals(tabHorasBruto) Then
                    If Not DateTime.TryParse(e.FormattedValue, x) Then

                        MessageBox.Show("La fecha no es válida. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgHorasBruto.CancelEdit()
                        e.Cancel = True
                    ElseIf Not IsDBNull(dgHorasBruto.Item(2, e.RowIndex).Value) Then
                        If Not (e.FormattedValue >= FechaIniPeriodo And e.FormattedValue <= DateAdd(DateInterval.Day, 1, FechaFinPeriodo)) Then
                            MessageBox.Show("La fecha no se encuentra dentro del periodo seleccionado. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            e.Cancel = True
                        ElseIf (e.FormattedValue < txtAlta.Value) Then
                            MessageBox.Show("La fecha es menor a la fecha de alta. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            e.Cancel = True
                        ElseIf (e.FormattedValue > txtBaja.Value) And txtBaja.Visible = True Then
                            MessageBox.Show("La fecha es mayor a la fecha de baja. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            e.Cancel = True
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub btnTransaccion_CheckedChanged(sender As Object, e As EventArgs) Handles btnTransaccion.CheckedChanged
        TransaccionCerrada = btnTransaccion.Checked
    End Sub

    Private Sub btnTransaccion_Click(sender As Object, e As EventArgs) Handles btnTransaccion.Click
        Dim dtEmpleados As New DataTable
        Dim _reloj_analisis As String
        'Dim PeriodoSeleccionado As String
        Dim _cadena As String = ""

        Try

            If chkGlobal.Checked Then
                If MessageBox.Show("¿Está seguro de querer " & IIf(btnTransaccion.Checked, "cerrar", "abrir ") & " transacción a todos los empleados seleccionados?", "Cerrar transacción", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                    'Si se cancela el proceso, devolver el botón a su estado anterior
                    'y salir del procedimiento
                    btnTransaccion.Checked = Not btnTransaccion.Checked
                    Exit Sub
                End If

                'Inhabilitar la forma actual, para evitar el usuario presione otra opción mientras se está evaluando
                tpBarra.Enabled = False
                tbInfo.Enabled = False
                Panel1.Enabled = False
                'Abrir forma para mostrar progress bar
                frmTrabajando.Show(Me)
                frmTrabajando.Avance.Value = 0
                frmTrabajando.Avance.IsRunning = False
                frmTrabajando.lblAvance.Text = IIf(btnTransaccion.Checked, "Cerrando ", "Abriendo ") & "transacciones"
                frmTrabajando.Avance.IsRunning = True
                Application.DoEvents()

                'Cambiar el cursor a "Modo de espera", para avisar al usuario que está corriendo un proceso
                Me.Cursor = Cursors.WaitCursor

            End If

            _reloj_analisis = txtReloj.Text

            'Formar la cadena de búsqueda, dependiendo de si el análisis es individual o global
            Acumulado = FiltrosAcumulados()
            _cadena = "SELECT reloj,nombres,gafete,personalvw.cod_comp,cod_depto,personalvw.cod_planta,cod_puesto,cod_tipo,cod_super,cod_turno,cod_hora,checa_tarjeta,personalvw.cod_clase FROM personalvw "
            If chkIndividual.Checked Then
                _cadena = _cadena & " WHERE reloj = '" & _reloj_analisis & "'"
            Else
                _cadena = _cadena & IIf(Acumulado.Length > 0, " WHERE 1=1 " & Acumulado, "")
            End If

            ' Filtrar activos a la fecha final
            _cadena = _cadena & IIf(_cadena.Contains("WHERE"), " AND ", " WHERE ") & " (baja IS NULL OR baja >= '" & FechaSQL(FechaFin) & "')"
            dtEmpleados = ConsultaPersonalVW(_cadena, False)

            If dtEmpleados.Rows.Count < 0 Then
                MessageBox.Show("No se localizaron empleados para analizar", "Análisis", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim cod_hora As String = "", cod_turno As String = "" ' AOS 2022-02-10
            For Each drEmpleado As DataRow In dtEmpleados.Rows
                If cbBitacora.Checked Then
                    'MCR 12/OCT/2015
                    'Si seleccionan revisar bitácora, regresar los campos al último día del periodo anterior
                    ConsultaBitacora(dtEmpleados, drEmpleado, FechaFinPeriodo)
                    cod_turno = ConsultaBitacoraHorarios(dtEmpleados, drEmpleado, FechaFinPeriodo, "cod_turno") ' AOS 2022-02-10
                    cod_hora = ConsultaBitacoraHorarios(dtEmpleados, drEmpleado, FechaFinPeriodo, "cod_hora") ' AOS 2022-02-10
                End If
                drEmpleado("cod_hora") = cod_hora ' AOS 2022-02-10
                drEmpleado("cod_turno") = cod_turno ' AOS 2022-02-10

                frmTrabajando.lblAvance.Text = _reloj_analisis
                Application.DoEvents()
                _reloj_analisis = drEmpleado("reloj")
                dtTemp = sqlExecute("SELECT reloj FROM nomsem WHERE reloj = '" & _reloj_analisis & "' AND ano = '" & Año & "' AND periodo = '" & Periodo & "'", "TA")
                If dtTemp.Rows.Count = 0 Then
                    sqlExecute("INSERT INTO nomsem (reloj,ano,periodo) VALUES ('" & _reloj_analisis & "','" & Año & "','" & Periodo & "')", "TA")
                End If
                ActualizaNomSem(_reloj_analisis, "tran_cerrada", IIf(btnTransaccion.Checked, 1, 0), Año, Periodo)
            Next

            HabilitaActivo(_reloj_analisis)
            '***************************************************************************************
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            If chkGlobal.Checked Then
                tpBarra.Enabled = True
                tbInfo.Enabled = True
                Panel1.Enabled = True
                Me.Cursor = Cursors.Default
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
            End If
            ActualizaInformacionTA()
            chkIndividual.Checked = True
        End Try
    End Sub

    Private Sub frmTA_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlCentrarControles.Left = (Me.Width - pnlCentrarControles.Size.Width) / 2
    End Sub


    Private Sub frmTA_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'MostrarInformacion("")
        If Not desdeTE Then
            btnFirst.PerformClick()
        End If
        HabilitarBotones()
    End Sub

    Private Sub txtDias_Click(sender As Object, e As EventArgs) Handles txtDias.Click
        DesdeCalendario = False
    End Sub

    Private Sub txtDias_GotFocus(sender As Object, e As EventArgs) Handles txtDias.GotFocus
        DesdeCalendario = False
    End Sub
    Private Sub calAusentismo_Click(sender As Object, e As EventArgs) Handles calAusentismo.Click
        If calAusentismo.SelectedAppointments.Count > 0 Then
            btnBorrarAus.Enabled = True
        Else
            btnBorrarAus.Enabled = False
        End If

        If pnlDetalleAusentismo.Enabled = True Then
            txt1.Value = calAusentismo.DateSelectionStart.GetValueOrDefault
        End If

    End Sub

    '==MODIFICADA   6SEPTIEMBRE2021
    Private Sub btnBorrarAus_Click(sender As Object, e As EventArgs) Handles btnBorrarAus.Click
        If calAusentismo.SelectedAppointments.Count > 0 Then
            BorrarAusentismo()
            '==Para que se puedan agregar valores nuevamente en la tabla 'faltas_justificadas_reporte'      3sep2021
            Tabla_faltas_justificadas_reporte(1)
            var_just = True
        End If
    End Sub

    Private Sub calAusentismo_ItemClick(sender As Object, e As EventArgs) Handles calAusentismo.ItemClick
        Try

            Dim Descripcion As String

            Dim i As Integer
            If calAusentismo.SelectedAppointments.Count = 1 Then
                cmbAusentismo.SelectedValue = calAusentismo.SelectedAppointments.Item(0).Appointment.Subject
                txt1.Value = calAusentismo.SelectedAppointments.Item(0).Appointment.StartTime
                txtDias.Value = DateDiff(DateInterval.Day, txt1.Value, calAusentismo.SelectedAppointments.Item(0).Appointment.EndTime)
                Descripcion = calAusentismo.SelectedAppointments.Item(0).Appointment.Description

                i = Descripcion.IndexOf("Referencia")
                If i > 0 Then
                    txtReferencia.Text = Descripcion.Substring(i + 12)
                End If

                Try
                    '== Para que se visualicen notas de cada dia            1dic2021        Ernesto
                    Dim noDias As Integer = CInt(txtDias.Value)
                    Dim dtAusNotas As New DataTable
                    Dim noNotas As String = ""
                    Dim varNota As String = ""

                    If noDias = 1 Then
                        dtAusNotas = sqlExecute("select * from ausentismo where reloj = '" & txtReloj.Text & "' and fecha = '" & FechaSQL(txt1.Value) &
                                                                 "' and tipo_aus = '" & cmbAusentismo.SelectedValue & "'", "TA")
                        varNota = IIf(IsDBNull(dtAusNotas.Rows(0)("subclasi")), "--", dtAusNotas.Rows(0)("subclasi").ToString.Trim)
                        noNotas = IIf(varNota.Length < 1, "--", varNota)
                    Else
                        Dim noFecha As New Date
                        noFecha = txt1.Value
                        noFecha = noFecha.AddDays(noDias - 1)

                        dtAusNotas = sqlExecute("select * from TA.dbo.ausentismo where reloj= '" & txtReloj.Text & "' and fecha between '" & FechaSQL(txt1.Value) &
                                                "' and '" & FechaSQL(noFecha) & "' and tipo_aus='" & cmbAusentismo.SelectedValue & "'")

                        For Each x As DataRow In dtAusNotas.Select("reloj is not null", "fecha")
                            varNota = IIf(IsDBNull(x.Item("subclasi")), "*Sin nota*", x.Item("subclasi").ToString.Trim)
                            noNotas += (FechaSQL(x.Item("fecha")) & " -- " & IIf(varNota.Length < 1, "*Sin nota*", varNota) & vbNewLine)
                        Next
                    End If
                    '==

                    If dtAusNotas.Rows.Count > 0 Then

                        '== Para que se visualicen notas de cada dia            1dic2021        Ernesto
                        'txtNotasAusentismo.Text = IIf(IsDBNull(dtAusNotas.Rows(0)("subclasi")), "", dtAusNotas.Rows(0)("subclasi"))
                        txtNotasAusentismo.Text = noNotas
                        '==

                        '==AQUI SE AGREGA UNA LINEA DE CODIGO PARA QUE EL MOTIVO DEL AUSENTISMO SELECCIONADO (FALTA JUSTIFICADA O INJUSTIFICADA) APAREZCA
                        '==EN EL COMBOBOX ULTIMO        3SEP2021
                        ' Dim clasificacion_faltas As String = IIf(IsDBNull(dtAusNotas.Rows(0)("detalle_aus")), "", dtAusNotas.Rows(0)("detalle_aus").ToString) ' SE Deshabilita
                        Dim clasificacion_faltas As String = ""
                        cmbClasFalta.SelectedValue = clasificacion_faltas
                    Else
                        txtNotasAusentismo.Text = ""
                    End If
                Catch ex As Exception
                    txtNotasAusentismo.Text = ""
                End Try

            End If
            DesdeCalendario = True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnKardex_Click(sender As Object, e As EventArgs) Handles btnKardex.Click
        Try
            frmKardexAn.MdiParent = frmMain
            frmKardexAn.txtReloj.Text = txtReloj.Text
            frmKardexAn.Show()
            frmKardexAn.Focus()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub mnuAgregarAusentismo_Click(sender As Object, e As EventArgs) Handles mnuAgregarAusentismo.Click
        btnAgregarAus.PerformClick()
    End Sub

    Private Sub mnuBorrarAusentismo_Click(sender As Object, e As EventArgs) Handles mnuBorrarAusentismo.Click
        btnBorrarAus.PerformClick()
    End Sub


    Private Sub ColoresAsist()
        Try
            For C = 0 To dgAsist.RowCount - 1

                'Si la diferencia de la entrada o salida son negativos
                dgAsist.Item("DIF_ENT", C).Style.ForeColor = IIf(HtoD(dgAsist.Item("DIF_ENT", C).Value) < 0, Color.Red, SystemColors.ControlText)
                dgAsist.Item("DIF_SAL", C).Style.ForeColor = IIf(HtoD(dgAsist.Item("DIF_SAL", C).Value) < 0, Color.Red, SystemColors.ControlText)
                dgAsist.Item("DIF_ENT", C).Style.BackColor = IIf(HtoD(dgAsist.Item("DIF_ENT", C).Value) <> 0, Color.Yellow, SystemColors.Window)
                dgAsist.Item("DIF_SAL", C).Style.BackColor = IIf(HtoD(dgAsist.Item("DIF_SAL", C).Value) <> 0, Color.Yellow, SystemColors.Window)

                'Si hay ausentismo o no tiene pareja, color de día, fecha y comentario
                If IsDBNull(dgAsist.Item("AUSENTISMO", C).Value) Then
                    dgAsist.Item("AUSENTISMO", C).Value = 0
                End If
                dgAsist.Item("DIA_ENTRADA", C).Style.ForeColor = IIf(dgAsist.Item("AUSENTISMO", C).Value = 1 Or dgAsist.Item("PAREJA", C).Value <> 1, Color.FromArgb(128, 0, 64), SystemColors.ControlText)
                dgAsist.Item("FECHA_ENTRADA", C).Style.ForeColor = IIf(dgAsist.Item("AUSENTISMO", C).Value = 1 Or dgAsist.Item("PAREJA", C).Value <> 1, Color.FromArgb(128, 0, 64), SystemColors.ControlText)
                dgAsist.Item("COMENTARIO", C).Style.ForeColor = IIf(dgAsist.Item("AUSENTISMO", C).Value = 1 Or dgAsist.Item("PAREJA", C).Value <> 1, Color.FromArgb(128, 0, 64), SystemColors.ControlText)

                dgAsist.Item("DIA_ENTRADA", C).Style.BackColor = IIf(dgAsist.Item("AUSENTISMO", C).Value = 1 Or dgAsist.Item("PAREJA", C).Value <> 1, Color.LightGray, SystemColors.Window)
                dgAsist.Item("FECHA_ENTRADA", C).Style.BackColor = IIf(dgAsist.Item("AUSENTISMO", C).Value = 1 Or dgAsist.Item("PAREJA", C).Value <> 1, Color.LightGray, SystemColors.Window)
                dgAsist.Item("COMENTARIO", C).Style.BackColor = IIf(dgAsist.Item("AUSENTISMO", C).Value = 1 Or dgAsist.Item("PAREJA", C).Value <> 1, Color.LightGray, SystemColors.Window)

                '== COLORES PARA LOS DIAS DE DESCANSO           28se2021
                If dgAsist.Item("AUSENTISMO", C).Value = 99 Then
                    dgAsist.Item("DIA_ENTRADA", C).Style.ForeColor = Color.Black
                    dgAsist.Item("FECHA_ENTRADA", C).Style.ForeColor = Color.LightGreen
                    dgAsist.Item("FECHA_SALIDA", C).Style.ForeColor = Color.White
                    dgAsist.Item("FECHA", C).Style.ForeColor = Color.White
                    dgAsist.Item("COMENTARIO", C).Style.ForeColor = Color.Black

                    dgAsist.Item("DIA_ENTRADA", C).Style.BackColor = Color.LightGreen
                    dgAsist.Item("FECHA_ENTRADA", C).Style.BackColor = Color.LightGreen
                    dgAsist.Item("COMENTARIO", C).Style.BackColor = Color.LightGreen
                End If

                'Si no tiene pareja, color de entrada y salida
                dgAsist.Item("ENTRADA", C).Style.ForeColor = IIf(dgAsist.Item("PAREJA", C).Value <> 1 And dgAsist.Item("AUSENTISMO", C).Value = 0, SystemColors.Window, SystemColors.ControlText)
                dgAsist.Item("SALIDA", C).Style.ForeColor = IIf(dgAsist.Item("PAREJA", C).Value <> 1 And dgAsist.Item("AUSENTISMO", C).Value = 0, SystemColors.Window, SystemColors.ControlText)

                dgAsist.Item("ENTRADA", C).Style.BackColor = IIf(dgAsist.Item("PAREJA", C).Value <> 1 And dgAsist.Item("AUSENTISMO", C).Value = 0, Color.FromArgb(128, 0, 64), SystemColors.Window)
                dgAsist.Item("SALIDA", C).Style.BackColor = IIf(dgAsist.Item("PAREJA", C).Value <> 1 And dgAsist.Item("AUSENTISMO", C).Value = 0, Color.FromArgb(128, 0, 64), SystemColors.Window)

                'Tiempo extra
                dgAsist.Item("HRS_EXT", C).Style.BackColor = IIf(HtoD(dgAsist.Item("HRS_EXT", C).Value) > 0 And HtoD(dgAsist.Item("HRS", C).Value) > 0, Color.Orange, SystemColors.Window)

                'Faltaba transacción de entrada o salida, se puso por ajuste
                dgAsist.Item("ENTRADA", C).Style.BackColor = IIf(dgAsist.Item("fal_tran_ent", C).Value = 1, Color.FromArgb(0, 128, 255), dgAsist.Item("ENTRADA", C).Style.BackColor)
                dgAsist.Item("SALIDA", C).Style.BackColor = IIf(dgAsist.Item("fal_tran_sal", C).Value = 1, Color.FromArgb(0, 128, 255), dgAsist.Item("SALIDA", C).Style.BackColor)

                Dim dtRegistroAutorizadas As DataTable = sqlExecute("select extras_autorizadas,autori_a1 from extras_autorizadas where reloj = '" & txtReloj.Text.Trim & _
                                                                    "' and fecha = '" & FechaSQL(dgAsist.Item("FHA_ENT_HOR", C).Value) & "'", "TA")
                Dim autori_a1 As Boolean = False
                ' si ya hay un registro de autorizadas en a_1, tomar ese valor
                dgAsist.Item("EXT_AUT", C).Style.BackColor = SystemColors.Window

                If dtRegistroAutorizadas.Rows.Count > 0 Then
                    autori_a1 = IIf(IsDBNull(dtRegistroAutorizadas.Rows(0).Item("autori_a1")), False, dtRegistroAutorizadas.Rows(0).Item("autori_a1"))
                    If IIf(IsDBNull(dtRegistroAutorizadas.Rows(0).Item("extras_autorizadas")), "00:00", dtRegistroAutorizadas.Rows(0).Item("extras_autorizadas")).ToString.Trim = "TODO" Then
                        If autori_a1 And dtRegistroAutorizadas.Rows(0).Item("extras_autorizadas") <> "00:00" Then
                            dgAsist.Item("EXT_AUT", C).Style.BackColor = Color.Orange
                        End If
                    Else
                        If autori_a1 Then
                            dgAsist.Item("EXT_AUT", C).Style.BackColor = Color.Moccasin
                        End If
                    End If
                End If

            Next
            '*********************************
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub CorrigeTransaccion(drEmpleado As DataRow, Fecha As Date, Periodo As String, TipoTransaccion As String)

        Dim R As String
        Dim FaltaEntrada As Boolean
        Dim FaltaSalida As Boolean
        Dim Comp As String
        Dim Preus As Boolean
        Dim Entrada As String
        Dim Salida As String
        Dim Dif As Integer
        Dim FechaSalida As Date
        Dim Descanso As Boolean
        Dim fAlta As Date
        Dim fBaja As Date
        Dim procesarSalida As Boolean = False

        Try
            R = drEmpleado("reloj")
            Comp = drEmpleado("cod_comp")
            fAlta = drEmpleado("alta")
            fBaja = IIf(IsDBNull(drEmpleado("baja")), DateSerial(2100, 1, 1), drEmpleado("baja"))
            Preus = chkPEUS.Checked

            Entrada = drHorario("entra")
            Salida = drHorario("sale")
            Dif = IIf(drHorario("dia_ent") <> drHorario("dia_sal"), 1, 0)
            FechaSalida = DateAdd(DateInterval.Day, Dif, Fecha)
            Descanso = DiaDescanso(Fecha, R)


            If Not Descanso And Fecha >= fAlta And Fecha <= fBaja And Not Festivo(Fecha, R) Then
                dtTemp = sqlExecute("SELECT entro,salio FROM asist WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & R & _
                                  "' AND fha_ent_hor = '" & FechaSQL(Fecha) & "'", "TA")
                If dtTemp.Rows.Count = 0 Then
                    FaltaEntrada = True
                    FaltaSalida = True
                Else
                    FaltaEntrada = IIf(IsDBNull(dtTemp.Rows(0).Item("entro")), "", dtTemp.Rows(0).Item("entro")).ToString.Trim = ""
                    FaltaSalida = IIf(IsDBNull(dtTemp.Rows(0).Item("salio")), "", dtTemp.Rows(0).Item("salio")).ToString.Trim = ""
                End If

                'Si no hay transacción para esta fecha, poner asistencia perfecta
                If FaltaEntrada And FaltaSalida Then
                    'MCR 15/OCT/2015
                    'Insertar en bitácora borrado de ausentismo
                    'ANTES DE BORRAR, PUES SE LLENA DESDE AUSENTISMO
                    sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                  "(reloj,fecha,tipo_aus,fecha_movimiento,usuario_movimiento,notas) " & _
                               "SELECT reloj,fecha,tipo_aus,GETDATE(),'" & Usuario & _
                               "','/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/Met: " & _
                               System.Reflection.MethodBase.GetCurrentMethod.Name() & "' FROM ausentismo WHERE reloj = '" & Reloj & _
                               "' AND fecha ='" & FechaSQL(Fecha) & _
                               "' AND tipo_aus NOT IN ('" & _aus_natural & "','" & _aus_festivo & "','FI')", "TA")


                    'Borrar ausentismo (si hay) del tipo natural - falta injustificada -
                    sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & Reloj & "' AND fecha ='" & FechaSQL(Fecha) & _
                               "' AND tipo_aus NOT IN ('" & _aus_natural & "','" & _aus_festivo & "','FI')", "TA")

                    'Revisar si hay otro tipo de ausentismo registrado para ese día.
                    dtTemp = sqlExecute("SELECT tipo_aus FROM ausentismo " & _
                                        "WHERE tipo_aus NOT IN ('" & _aus_natural & "','" & _aus_festivo & "','FI') AND reloj = '" & R & _
                                        "' AND (fecha = '" & FechaSQL(Fecha) & "' OR  fecha = '" & FechaSQL(FechaSalida) & "')", "TA")
                    If dtTemp.Rows.Count > 0 Then
                        'Solo corrige la transacción si no hay ausentismo capturado en este día
                        'Poner ambas banderas en falso, para que no inserte las transacciones
                        FaltaEntrada = False
                        FaltaSalida = False
                    End If
                End If

                '****************************************************AO: 2023-08-04: Poner solo lo que falte, entrada o Salida, para el caso de la transacción de "Olvidó Checar"**********************************************
                '**************************************************************************************************************************************************************************************************************
                '**************************************************************************************************************************************************************************************************************
                If TipoTransaccion = "O" Then
                    '---------------------------------------------------------------------------------------------------------------------------------------------------
                    '---------------------------------------------------------------------------------------------------------------------------------------------------
                    '----------------------------------------------------CASO 1 Falta Entrada y salida, poner solo Entrada----------------------------------------------
                    '---------------------------------------------------------------------------------------------------------------------------------------------------
                    '---------------------------------------------------------------------------------------------------------------------------------------------------
                    If FaltaEntrada And FaltaSalida Then ' Poner solo entrada

                        dtTemp = sqlExecute("SELECT reloj FROM hrs_brt WHERE fecha = '" & FechaSQL(Fecha) & "' AND hora = '" & MerMilitar(drHorario("entra")) & _
                    "' AND reloj = '" & drEmpleado("reloj") & "' ", "TA")
                        If dtTemp.Rows.Count = 0 Then
                            sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,dia,periodo,tipo_tran,pareja,preus,ano,faltaba_tran) VALUES ('" & _
                                       Comp & "','" & R & "','" & IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("reloj"), drEmpleado("gafete")) & "','" & _
                                       FechaSQL(Fecha) & "','" & MerMilitar(drHorario("entra")) & "','" & DiaSem(Fecha) & "','" & _
                                       Periodo.Substring(4, 2) & "','" & _
                                       TipoTransaccion & "',1," & IIf(Preus, 1, 0) & ",'" & Periodo.Substring(0, 4) & "',1)", "TA")

                            sqlExecute("INSERT INTO bitacora_hrs_brt " & _
                                   "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                                   R & "','" & FechaSQL(Fecha) & "','" & MerMilitar(drHorario("entra")) & _
                                       "','" & Usuario & "',GETDATE(),'" & TipoTransaccion & "',NULL,NULL)", "TA")
                        End If

                        '---------------------------------------------------------------------------------------------------------------------------------------------------
                        '---------------------------------------------------------------------------------------------------------------------------------------------------
                        '----------------------------------------------------CASO 2 Falta solo SALIDA, poner salida---------------------------------------------------------
                        '---------------------------------------------------------------------------------------------------------------------------------------------------
                        '---------------------------------------------------------------------------------------------------------------------------------------------------

                    ElseIf Not FaltaEntrada And FaltaSalida Then ' Poner solo Salida 

                        Dim hora_salida As String = "", hora_salid_d As Double = 0.0
                        Try
                            hora_salid_d = HtoD(MerMilitar(drHorario("sale"))) + HtoD(drHorario("extra_fijo"))
                        Catch ex As Exception
                            hora_salid_d = HtoD(MerMilitar(drHorario("sale")))
                        End Try

                        hora_salida = DtoH(hora_salid_d)

                        dtTemp = sqlExecute("SELECT reloj FROM hrs_brt WHERE  fecha = '" & FechaSQL(FechaSalida) & "' AND hora = '" & hora_salida & _
                                            "' AND reloj = '" & drEmpleado("reloj") & "' ", "TA")
                        If dtTemp.Rows.Count = 0 Then
                            sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,dia,periodo,tipo_tran,pareja,preus,ano,faltaba_tran) VALUES ('" & _
                                       Comp & "','" & R & "','" & IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("reloj"), drEmpleado("gafete")) & "','" & _
                                       FechaSQL(FechaSalida) & "','" & hora_salida & "','" & DiaSem(FechaSalida) & "','" & _
                                       Periodo.Substring(4, 2) & "','" & _
                                       TipoTransaccion & "',1," & IIf(Preus, 1, 0) & ",'" & Periodo.Substring(0, 4) & "',1)", "TA")
                            sqlExecute("INSERT INTO bitacora_hrs_brt" & _
                                   "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                                   R & "','" & FechaSQL(FechaSalida) & "','" & hora_salida & _
                                       "','" & Usuario & "',GETDATE(),'" & TipoTransaccion & "',NULL,NULL)", "TA")
                        End If

                        '---------------------------------------------------------------------------------------------------------------------------------------------------
                        '---------------------------------------------------------------------------------------------------------------------------------------------------
                        '----------------------------------------------------CASO 3 Falta Entrada y salida ya existe -------------------------------------------------------
                        '---------------------------------------------------------------------------------------------------------------------------------------------------
                        '---------------------------------------------------------------------------------------------------------------------------------------------------

                    ElseIf FaltaEntrada And Not FaltaSalida Then ' Poner solo Entrada, pero como ya hay una salida registrada, preguntar si se desea reemplazar

                        dtTemp = sqlExecute("SELECT reloj FROM hrs_brt WHERE fecha = '" & FechaSQL(Fecha) & "' AND hora = '" & MerMilitar(drHorario("entra")) & _
"' AND reloj = '" & drEmpleado("reloj") & "' ", "TA")
                        If dtTemp.Rows.Count = 0 Then
                            sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,dia,periodo,tipo_tran,pareja,preus,ano,faltaba_tran) VALUES ('" & _
                                       Comp & "','" & R & "','" & IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("reloj"), drEmpleado("gafete")) & "','" & _
                                       FechaSQL(Fecha) & "','" & MerMilitar(drHorario("entra")) & "','" & DiaSem(Fecha) & "','" & _
                                       Periodo.Substring(4, 2) & "','" & _
                                       TipoTransaccion & "',1," & IIf(Preus, 1, 0) & ",'" & Periodo.Substring(0, 4) & "',1)", "TA")

                            sqlExecute("INSERT INTO bitacora_hrs_brt " & _
                                   "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                                   R & "','" & FechaSQL(Fecha) & "','" & MerMilitar(drHorario("entra")) & _
                                       "','" & Usuario & "',GETDATE(),'" & TipoTransaccion & "',NULL,NULL)", "TA")
                        End If

                        If MessageBox.Show("¿Desea reemplazar la hora de salida existente por la real de acuerdo a su horario actual?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then procesarSalida = True

                        'Si falta la salida, insertarla de acuerdo al horario
                        If procesarSalida Then

                            Dim hora_salida As String = "", hora_salid_d As Double = 0.0
                            Try
                                hora_salid_d = HtoD(MerMilitar(drHorario("sale"))) + HtoD(drHorario("extra_fijo"))
                            Catch ex As Exception
                                hora_salid_d = HtoD(MerMilitar(drHorario("sale")))
                            End Try

                            hora_salida = DtoH(hora_salid_d)

                            dtTemp = sqlExecute("SELECT reloj FROM hrs_brt WHERE  fecha = '" & FechaSQL(FechaSalida) & "' AND hora = '" & hora_salida & _
                                                "' AND reloj = '" & drEmpleado("reloj") & "' ", "TA")
                            If dtTemp.Rows.Count = 0 Then
                                sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,dia,periodo,tipo_tran,pareja,preus,ano,faltaba_tran) VALUES ('" & _
                                           Comp & "','" & R & "','" & IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("reloj"), drEmpleado("gafete")) & "','" & _
                                           FechaSQL(FechaSalida) & "','" & hora_salida & "','" & DiaSem(FechaSalida) & "','" & _
                                           Periodo.Substring(4, 2) & "','" & _
                                           TipoTransaccion & "',1," & IIf(Preus, 1, 0) & ",'" & Periodo.Substring(0, 4) & "',1)", "TA")
                                sqlExecute("INSERT INTO bitacora_hrs_brt" & _
                                       "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                                       R & "','" & FechaSQL(FechaSalida) & "','" & hora_salida & _
                                           "','" & Usuario & "',GETDATE(),'" & TipoTransaccion & "',NULL,NULL)", "TA")
                            End If
                        End If

                        '---------------------------------------------------------------------------------------------------------------------------------------------------
                        '---------------------------------------------------------------------------------------------------------------------------------------------------
                        '----------------------------------------------------CASO 4 No falta ni entrada ni salida--- -------------------------------------------------------
                        '---------------------------------------------------------------------------------------------------------------------------------------------------
                        '---------------------------------------------------------------------------------------------------------------------------------------------------

                    ElseIf Not FaltaEntrada And Not FaltaSalida Then ' Como ya hay una salida registrada, preguntar si solo se desea reemplazar por el horario correcto

                        If MessageBox.Show("¿Desea reemplazar la hora de salida existente por la real de acuerdo a su horario actual?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then procesarSalida = True

                        'Si falta la salida, insertarla de acuerdo al horario
                        If procesarSalida Then

                            Dim hora_salida As String = "", hora_salid_d As Double = 0.0
                            Try
                                hora_salid_d = HtoD(MerMilitar(drHorario("sale"))) + HtoD(drHorario("extra_fijo"))
                            Catch ex As Exception
                                hora_salid_d = HtoD(MerMilitar(drHorario("sale")))
                            End Try

                            hora_salida = DtoH(hora_salid_d)

                            dtTemp = sqlExecute("SELECT reloj FROM hrs_brt WHERE  fecha = '" & FechaSQL(FechaSalida) & "' AND hora = '" & hora_salida & _
                                                "' AND reloj = '" & drEmpleado("reloj") & "' ", "TA")
                            If dtTemp.Rows.Count = 0 Then
                                sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,dia,periodo,tipo_tran,pareja,preus,ano,faltaba_tran) VALUES ('" & _
                                           Comp & "','" & R & "','" & IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("reloj"), drEmpleado("gafete")) & "','" & _
                                           FechaSQL(FechaSalida) & "','" & hora_salida & "','" & DiaSem(FechaSalida) & "','" & _
                                           Periodo.Substring(4, 2) & "','" & _
                                           TipoTransaccion & "',1," & IIf(Preus, 1, 0) & ",'" & Periodo.Substring(0, 4) & "',1)", "TA")
                                sqlExecute("INSERT INTO bitacora_hrs_brt" & _
                                       "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                                       R & "','" & FechaSQL(FechaSalida) & "','" & hora_salida & _
                                           "','" & Usuario & "',GETDATE(),'" & TipoTransaccion & "',NULL,NULL)", "TA")
                            End If
                        End If

                    End If

                    '---------------------------------------------------------------------------------------------------------------------------------------------------
                    '---------------------------------------------------------------------------------------------------------------------------------------------------
                    '----------------------------------------------------CUANDO LA TRANSACCION ES DIFERENTE A "O", realizar lo habitual---------------------------------
                    '---------------------------------------------------------------------------------------------------------------------------------------------------
                    '---------------------------------------------------------------------------------------------------------------------------------------------------

                Else ' Realizar lo habitual con cualquier otra transacción

                    'Si falta la entrada, insertarla de acuerdo al horario
                    If FaltaEntrada Then
                        dtTemp = sqlExecute("SELECT reloj FROM hrs_brt WHERE fecha = '" & FechaSQL(Fecha) & "' AND hora = '" & MerMilitar(drHorario("entra")) & _
                                            "' AND reloj = '" & drEmpleado("reloj") & "' ", "TA")
                        If dtTemp.Rows.Count = 0 Then
                            sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,dia,periodo,tipo_tran,pareja,preus,ano,faltaba_tran) VALUES ('" & _
                                       Comp & "','" & R & "','" & IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("reloj"), drEmpleado("gafete")) & "','" & _
                                       FechaSQL(Fecha) & "','" & MerMilitar(drHorario("entra")) & "','" & DiaSem(Fecha) & "','" & _
                                       Periodo.Substring(4, 2) & "','" & _
                                       TipoTransaccion & "',1," & IIf(Preus, 1, 0) & ",'" & Periodo.Substring(0, 4) & "',1)", "TA")

                            sqlExecute("INSERT INTO bitacora_hrs_brt " & _
                                   "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                                   R & "','" & FechaSQL(Fecha) & "','" & MerMilitar(drHorario("entra")) & _
                                       "','" & Usuario & "',GETDATE(),'" & TipoTransaccion & "',NULL,NULL)", "TA")
                        End If
                    End If

                    '---AO : 2023-08-02 Poder modificar el horario de salida si pone Olvido Checar, siempre y cuando ya este la salida registrada
                    If TipoTransaccion = "O" And Not FaltaSalida Then
                        If MessageBox.Show("¿Desea reemplazar la hora de salida existente por la real de acuerdo a su horario actual?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then procesarSalida = True
                    End If

                    'Si falta la salida, insertarla de acuerdo al horario
                    If FaltaSalida Or procesarSalida Then

                        Dim hora_salida As String = "", hora_salid_d As Double = 0.0
                        Try
                            hora_salid_d = HtoD(MerMilitar(drHorario("sale"))) + HtoD(drHorario("extra_fijo"))
                        Catch ex As Exception
                            hora_salid_d = HtoD(MerMilitar(drHorario("sale")))
                        End Try

                        hora_salida = DtoH(hora_salid_d)

                        dtTemp = sqlExecute("SELECT reloj FROM hrs_brt WHERE  fecha = '" & FechaSQL(FechaSalida) & "' AND hora = '" & hora_salida & _
                                            "' AND reloj = '" & drEmpleado("reloj") & "' ", "TA")
                        If dtTemp.Rows.Count = 0 Then
                            sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,dia,periodo,tipo_tran,pareja,preus,ano,faltaba_tran) VALUES ('" & _
                                       Comp & "','" & R & "','" & IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("reloj"), drEmpleado("gafete")) & "','" & _
                                       FechaSQL(FechaSalida) & "','" & hora_salida & "','" & DiaSem(FechaSalida) & "','" & _
                                       Periodo.Substring(4, 2) & "','" & _
                                       TipoTransaccion & "',1," & IIf(Preus, 1, 0) & ",'" & Periodo.Substring(0, 4) & "',1)", "TA")
                            sqlExecute("INSERT INTO bitacora_hrs_brt" & _
                                   "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                                   R & "','" & FechaSQL(FechaSalida) & "','" & hora_salida & _
                                       "','" & Usuario & "',GETDATE(),'" & TipoTransaccion & "',NULL,NULL)", "TA")
                        End If
                    End If


                End If
                '****************************************************---Termina AO: 2023-08-04:  valida el tipo de transaccion ************************************************************************************************
                '**************************************************************************************************************************************************************************************************************
                '**************************************************************************************************************************************************************************************************************


            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkFiltroChequeos_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltroChequeos.CheckedChanged
        Acumulado = FiltrosAcumulados()
        If Not Iniciando Then btnFirst.PerformClick()

    End Sub

    Private Sub chkFiltroError_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltroError.CheckedChanged
        Acumulado = FiltrosAcumulados()
        If Not Iniciando Then btnFirst.PerformClick()
    End Sub

    Private Sub chkFiltroTodosAsist_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltroTodosAsist.CheckedChanged
        Acumulado = FiltrosAcumulados()
        If Not Iniciando Then btnFirst.PerformClick()
    End Sub

    Private Sub chkFiltroAbiertas_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltroAbiertas.CheckedChanged
        Acumulado = FiltrosAcumulados()
        If Not Iniciando Then btnFirst.PerformClick()
    End Sub

    Private Sub chkFiltroCerradas_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltroCerradas.CheckedChanged
        Acumulado = FiltrosAcumulados()
        If Not Iniciando Then btnFirst.PerformClick()
    End Sub

    Private Sub chkFiltroTodasTran_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltroTodasTran.CheckedChanged
        Acumulado = FiltrosAcumulados()
        If Not Iniciando Then btnFirst.PerformClick()
    End Sub


    Private Sub btnAnalisis_Click(sender As Object, e As EventArgs) Handles btnAnalisis.Click
        Dim dtEmpleados As New DataTable
        Dim dtHorarios As New DataTable
        Dim dtErrores As New DataTable
        Dim SemanaCompleta As Boolean
        Dim i As Integer
        Dim _cadena As String

        Dim _reloj_analisis As String

        Dim _periodo As String
        Dim _comentario_criterio_de_evaluacion As String = ""
        Dim _descanso As Boolean = False
        Dim _festivo As Boolean = False
        Dim _abierto As Boolean = False

        Dim _seg_horas_ex As Integer = 0
        Dim _comentario As String = ""
        Dim tm As DateTime = Now
        Dim FIni As Date = Now
        Dim FFin As Date = Now
        Dim dtPer As DataTable

        Try

            If chkGlobal.Checked And Not ANALISIS_AUTOMATICO Then
                If MessageBox.Show("¿Está seguro de querer analizar a todos los empleados seleccionados?", "Análisis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            End If

            dtErrores.Columns.Add("DESCRIPCION")
            SemanaCompleta = chkSemana.Checked
            'Inhabilitar la forma actual, para evitar el usuario presione otra opción mientras se está evaluando
            tpBarra.Enabled = False
            tbInfo.Enabled = False
            Panel1.Enabled = False
            'Abrir forma para mostrar progress bar
            frmTrabajando.Text = "Análisis T&A"
            frmTrabajando.Show(Me)
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Text = "Analizando..."
            frmTrabajando.Avance.IsRunning = True
            Application.DoEvents()

            'Cambiar el cursor a "Modo de espera", para avisar al usuario que está corriendo un proceso
            Me.Cursor = Cursors.WaitCursor

            _reloj_analisis = txtReloj.Text
            _pri_ent_ult_sal = IIf(chkPEUS.Checked, 1, 0)
            _periodo = cmbPeriodos.SelectedValue

            'Formar la cadena de búsqueda, dependiendo de si el análisis es individual o global
            Acumulado = FiltrosAcumulados()
            _cadena = "SELECT reloj,nombres,alta,baja,gafete,personalvw.cod_planta,personalvw.cod_comp,cod_depto,cod_puesto,cod_tipo,cod_super,cod_turno,cod_hora,checa_tarjeta," & _
                "personalvw.cod_clase FROM personalvw "
            If chkIndividual.Checked Then
                _cadena = _cadena & " WHERE reloj = '" & _reloj_analisis & "'"
            Else
                _cadena = _cadena & IIf(Acumulado.Length > 0, " WHERE 1=1 " & Acumulado, "")
            End If

            ' Filtrar activos a la fecha final
            _cadena = _cadena & IIf(_cadena.Contains("WHERE"), " AND ", " WHERE ") & " (baja IS NULL OR baja >= '" & FechaSQL(FechaIni) & "')"
            dtEmpleados = ConsultaPersonalVW(_cadena, False)

            If dtEmpleados.Rows.Count <= 0 Then
                MessageBox.Show("No se localizaron empleados para analizar", "Análisis", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            frmTrabajando.Avance.Maximum = dtEmpleados.Rows.Count
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = True
            i = 0

            dtPer = sqlExecute("SELECT fecha_ini,fecha_fin,activo FROM periodos WHERE ano = '" & cmbPeriodos.SelectedValue.ToString.Substring(0, 4) & _
                                "' AND periodo = '" & cmbPeriodos.SelectedValue.ToString.Substring(4, 2) & "'", "TA")
            FIni = dtPer.Rows(0).Item("fecha_ini")
            FFin = dtPer.Rows(0).Item("fecha_fin")


            i = 0

            '************************************
            Dim total As Double = dtEmpleados.Rows.Count
            Dim contador As Double = 0

            If ANALISIS_AUTOMATICO Then
                frmAnalisisAutomatico.agregar_elemento("iniciando: " & FechaHoraSQL(Now))
            End If


            For Each drEmpleado As DataRow In dtEmpleados.Rows
                If ActivoTrabajando Then

                    contador += 1

                    If ANALISIS_AUTOMATICO Then
                        frmAnalisisAutomatico.agregar_elemento("analizando: " & drEmpleado("reloj") & Space(1) & contador & "/" & total)
                    End If

                    Application.DoEvents()
                    frmTrabajando.lblAvance.Text = drEmpleado("reloj")

                    'AGREGADO 15/DIC/2020 SOLO ESTO
                    SabadoDomingo(drEmpleado("reloj"))

                    analisis_independiente(drEmpleado("reloj"), FechaIni, chkSemana.Checked, chkPares.Checked, chkPEUS.Checked, chkSolo33.Checked)
                End If
            Next


            If ANALISIS_AUTOMATICO Then
                frmAnalisisAutomatico.agregar_elemento("finalizando: " & FechaHoraSQL(Now))
            End If

            Dim Errores As String = ""
            If dtErrores.Rows.Count > 0 Then
                For Each dr As DataRow In dtErrores.Rows
                    Errores = Errores & IIf(Errores.Length > 0, vbCrLf, "") & dr("descripcion").ToString.Trim
                Next

                Err.Raise(-1, Nothing, Errores)
            End If
        Catch ex As Exception
            frmTrabajando.Hide()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se encontraron errores durante el análisis. Favor de verificar." & vbCrLf & vbCrLf & "Error.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tpBarra.Enabled = True
            tbInfo.Enabled = True
            Panel1.Enabled = True
            Me.Cursor = Cursors.Default
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            ActualizaInformacionTA()
            chkIndividual.Checked = True

        End Try
    End Sub



    Private Sub SeleccionCorregirTransaccion(sender As Object, e As EventArgs)
        Dim dtEmpleados As New DataTable
        Dim dtHorarios As New DataTable
        Dim _cadena As String
        Dim _cod_comp As String
        Dim _cod_tipo As String
        Dim _cod_turno As String
        Dim _cod_hora As String
        Dim _gafete As String

        Dim _reloj_analisis As String
        Dim _fecha_analisis As Date
        Dim _periodo As String
        Dim _comentario_criterio_de_evaluacion As String = ""
        Dim _checa_tarjeta As Boolean
        Dim TipoTransaccion As String = ""
        Dim NombreTransaccion As String = sender.ToString.Trim
        Dim frmTr As New frmTrabajando


        If NombreTransaccion = "Tiempo x tiempo" Then
            frmTiempoxTiempo.horario_t = txtHorario.Text
            frmTiempoxTiempo.reloj_t = txtReloj.Text
            frmTiempoxTiempo.ShowDialog()
            btnAnalisis.RaiseClick()
        ElseIf NombreTransaccion = "Retardo transporte" Then
            _fecha_analisis = FechaIni
            Dim dtRetardo As DataTable = sqlExecute("select * from asist where reloj = '" & txtReloj.Text & "' and fha_ent_hor = '" & FechaSQL(_fecha_analisis) & "' and dif_ent <> '00:00'", "TA")
            If dtRetardo.Rows.Count > 0 Then
                Dim difent As String = dtRetardo.Rows(0)("dif_ent")
                sqlExecute("delete from retardo_transporte where reloj = '" & txtReloj.Text & "' and fecha = '" & FechaSQL(_fecha_analisis) & "'", "TA")
                sqlExecute("insert into retardo_transporte values ('" & txtReloj.Text & "', '" & FechaSQL(_fecha_analisis) & "', '" & difent.Replace("-", "") & "', '" & Usuario & "', '" & FechaHoraSQL(Date.Now) & "')", "TA")
            End If
            btnAnalisis.RaiseClick()
        ElseIf NombreTransaccion = "Excepción horario" Then
            horario_exc = txtHorario.Text
            nombres_exc = txtNombre.Text
            reloj_exc = txtReloj.Text
            frmExcepcionHorarios.RlExcep = "NUEVO"

            frmEditarExcepcionHorarios.ShowDialog()

        ElseIf NombreTransaccion = "Excepción horario masivo" Then

            Dim frm_ As New frmExcepcionesHorariosMasivos
            frm_.tipo_ajuste = "excepciones"
            frm_.ShowDialog()

        ElseIf NombreTransaccion = "Tiempo completo masivo" Then

            Dim frm_ As New frmExcepcionesHorariosMasivos
            frm_.tipo_ajuste = "t_completos"
            frm_.ShowDialog()


        ElseIf NombreTransaccion = "Cancelación Retardo transporte" Then
            _fecha_analisis = FechaIni
            Dim dtRetardo As DataTable = sqlExecute("select * from retardo_transporte where reloj = '" & txtReloj.Text & "' and fecha = '" & FechaSQL(_fecha_analisis) & "'", "TA")
            If dtRetardo.Rows.Count > 0 Then
                sqlExecute("delete from retardo_transporte where reloj = '" & txtReloj.Text & "' and fecha = '" & FechaSQL(_fecha_analisis) & "'", "TA")
                'sqlExecute("update asist set comentario = '' where reloj = '" & txtReloj.Text & "' and fha_ent_hor = '" & FechaSQL(_fecha_analisis) & "'", "TA")
            Else
                MessageBox.Show("No se encontro registro de Retardo por trasporte", "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            btnAnalisis.RaiseClick()
        ElseIf NombreTransaccion = "Cancelar Tiempo por tiempo" Then
            _fecha_analisis = FechaIni
            Dim dttxt As DataTable = sqlExecute("select * from tiempo_x_tiempo where reloj = '" & txtReloj.Text & "' and fecha_intercambio = '" & FechaSQL(_fecha_analisis) & "'", "PERSONAL")
            If dttxt.Rows.Count > 0 Then

                frmTiempoxTiempos.reloj_t = txtReloj.Text
                frmTiempoxTiempos.txtfechaor.Text = dttxt.Rows(0).Item("fecha_original")
                frmTiempoxTiempos.txtfechain.Text = dttxt.Rows(0).Item("fecha_intercambio")
                frmTiempoxTiempos.ShowDialog()
                chkSemana.Checked = True
                btnAnalisis.RaiseClick()
                chkSemana.Checked = False
            Else
                MessageBox.Show("No se encontro registro de Tiempo x tiempo", "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf NombreTransaccion = "Tiempo completo" Then
            _fecha_analisis = FechaIni
            Dim dtTiempoCompleto As DataTable = sqlExecute("select * from ta.dbo.TiempoCompleto where reloj = '" & txtReloj.Text & "' and fecha = '" & FechaSQL(_fecha_analisis) & "'", "TA")
            If dtTiempoCompleto.Rows.Count <= 0 Then
                If MessageBox.Show("¿Desea aplicar un ajuste de tiempo completo del empleado " & txtReloj.Text & " el día " & FechaSQL(_fecha_analisis) & "?", "Aplicar tiempo completo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    sqlExecute("insert into ta.dbo.TiempoCompleto (reloj, fecha, usuario, registro) values ('" & txtReloj.Text & "', '" & FechaSQL(_fecha_analisis) & "', '" & Usuario & "', getdate())")

                    btnAnalisis.RaiseClick()
                End If
            Else
                If MessageBox.Show("¿Desea cancelar el ajuste de tiempo completo del empleado " & txtReloj.Text & " el día " & FechaSQL(_fecha_analisis) & "?", "Cancelar tiempo completo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    sqlExecute("delete from ta.dbo.TiempoCompleto where reloj = '" & txtReloj.Text & "' and fecha = '" & FechaSQL(_fecha_analisis) & "'", "ta")

                    btnAnalisis.RaiseClick()
                End If
            End If
        Else
            Try
                If chkGlobal.Checked Then
                    If MessageBox.Show("¿Está seguro de querer corregir transacciones a todos los empleados seleccionados?", "Corregir transacción", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                        Exit Sub
                    End If
                End If

                dtTemp = sqlExecute("SELECT tipo_tran FROM tipo_transaccion WHERE nombre = '" & NombreTransaccion & "'", "TA")
                If dtTemp.Rows.Count > 0 Then
                    TipoTransaccion = IIf(IsDBNull(dtTemp.Rows(0).Item("tipo_tran")), "A", dtTemp.Rows(0).Item("tipo_tran"))
                End If

                'Inhabilitar la forma actual, para evitar el usuario presione otra opción mientras se está evaluando
                tpBarra.Enabled = False
                tbInfo.Enabled = False
                Panel1.Enabled = False
                'Abrir forma para mostrar progress bar
                frmTr.Text = "Corrección de transacción"
                frmTr.Show(Me)
                frmTr.Avance.Value = 0
                frmTr.Avance.IsRunning = False
                frmTr.lblAvance.Text = "Analizando..."
                frmTr.Avance.IsRunning = True

                'Cambiar el cursor a "Modo de espera", para avisar al usuario que está corriendo un proceso
                Me.Cursor = Cursors.WaitCursor

                _reloj_analisis = txtReloj.Text
                _pri_ent_ult_sal = IIf(chkPEUS.Checked, 1, 0)
                _periodo = cmbPeriodos.SelectedValue

                'Formar cadena de consulta de acuerdo a los filtros
                _cadena = "SELECT reloj,nombres,gafete,personal.cod_comp,personal.cod_planta,cod_depto,cod_puesto,cod_tipo,cod_super,cod_turno,cod_hora,checa_tarjeta," & _
                    "personal.cod_clase,alta,baja FROM personalvw"
                If chkIndividual.Checked Then
                    _cadena = _cadena & " WHERE reloj = '" & _reloj_analisis & "'"
                Else
                    _cadena = _cadena & IIf(Acumulado.Length = 0, "", " WHERE 1 = 1 " & Acumulado)
                End If

                ' Si la cadena ya contiene la condición 'WHERE', solo agregarle el 'AND' para la siguiente condición
                ' Filtrar activos a la fecha final
                _cadena = _cadena & IIf(_cadena.Contains("WHERE"), " AND ", " WHERE ") & " (baja IS NULL OR baja >= '" & FechaSQL(FechaFin) & "')"
                dtEmpleados = ConsultaPersonalVW(_cadena)

                If dtEmpleados.Rows.Count < 0 Then
                    MessageBox.Show("No se localizaron empleados para analizar", "Análisis", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                ' Evaluar cada empleado seleccionado
                For Each drEmpleado As DataRow In dtEmpleados.Rows
                    frmTr.lblAvance.Text = _reloj_analisis
                    Application.DoEvents()

                    Dim cod_hora As String = "", cod_turno As String = "" ' AOS 2022-02-10
                    If cbBitacora.Checked Then
                        'MCR 12/OCT/2015
                        'Si seleccionan revisar bitácora, regresar los campos al último día del periodo anterior
                        ConsultaBitacora(dtEmpleados, drEmpleado, FechaFinPeriodo)
                        cod_turno = ConsultaBitacoraHorarios(dtEmpleados, drEmpleado, FechaFinPeriodo, "cod_turno") ' AOS 2022-02-10
                        cod_hora = ConsultaBitacoraHorarios(dtEmpleados, drEmpleado, FechaFinPeriodo, "cod_hora") ' aos
                    End If
                    drEmpleado("cod_hora") = cod_hora ' AOS 2022-02-10
                    drEmpleado("cod_turno") = cod_turno ' AOS 2022-02-10

                    If Not ActivoTrabajando Then Exit For

                    _reloj_analisis = drEmpleado("reloj")
                    _cod_comp = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp"))
                    _cod_tipo = IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo"))
                    _cod_turno = IIf(IsDBNull(drEmpleado("cod_turno")), "", drEmpleado("cod_turno"))
                    _cod_hora = IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora"))
                    _gafete = IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("RELOJ"), drEmpleado("gafete"))
                    _checa_tarjeta = IIf(IsDBNull(drEmpleado("checa_tarjeta")), True, drEmpleado("checa_tarjeta"))
                    _fecha_analisis = FechaIni

                    Do While _fecha_analisis <= FechaFin
                        'Tomar datos de horarios y días para esta fecha
                        If Not ActivoTrabajando Then Exit Do
                        DiaSemana = Weekday(_fecha_analisis, IIf(IniciaLunes, FirstDayOfWeek.Monday, FirstDayOfWeek.Sunday))
                        Semana = SemanaHorarioMixto(_periodo, _reloj_analisis)
                        dtHorarios = sqlExecute("SELECT horarios.*,dias.*,TA.DBO.HORA12A24(ENTRA) AS ENTRADA24 FROM horarios " & _
                                               "LEFT JOIN dias ON horarios.cod_hora = dias.cod_hora AND horarios.cod_comp = dias.cod_comp " & _
                                               "WHERE horarios.cod_comp = '" & _cod_comp & "' AND horarios.cod_hora = '" & _cod_hora & _
                                               "' and dias.cod_dia = " & DiaSemana & " AND semana = " & Semana.NumSemana)

                        If dtHorarios.Rows.Count > 0 Then
                            drHorario = dtHorarios.Rows(0)
                        Else
                            'Si no hay información del horario, regresar al ciclo "DO"
                            If Not chkGlobal.Checked Then
                                ActivoTrabajando = False
                                MessageBox.Show("No se localizó detalle para el horario " & _cod_comp & "/" & _cod_hora & ".", "Información incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Continue For
                            Else
                                Debug.Print("No hay información de horarios para empleado " & Reloj)
                                _fecha_analisis = DateAdd(DateInterval.Day, 1, _fecha_analisis)
                                Continue Do
                            End If
                        End If

                        CorrigeTransaccion(drEmpleado, _fecha_analisis, cmbPeriodos.SelectedValue, TipoTransaccion)
                        'Borrar datos de asist que pudiera haber de esta fecha
                        sqlExecute("DELETE FROM asist WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & _reloj_analisis & _
                                      "' AND fha_ent_hor ='" & FechaSQL(_fecha_analisis) & "'", "TA")
                        'Borrar fecha efectiva del hrs_brt, que pudiera haber quedado de evaluaciones anteriores
                        sqlExecute("UPDATE hrs_brt SET fecha_efva = NULL WHERE RELOJ ='" & _reloj_analisis & "' AND fecha_efva = '" & FechaSQL(_fecha_analisis) & "'", "TA")

                        'Analizar nuevamente el día, tras corregir la transacción
                        AnalisisHrsBrt(drEmpleado, _fecha_analisis, _periodo.Substring(4, 2), _periodo.Substring(0, 4))
                        Evaluador(drEmpleado, _fecha_analisis, _periodo.Substring(4, 2), _periodo.Substring(0, 4))

                        'Incrementar la fecha
                        _fecha_analisis = DateAdd(DateInterval.Day, 1, _fecha_analisis)
                    Loop
                    LlenaNomSem(drEmpleado, _periodo, dtAsist)
                Next
                My.Application.DoEvents()
            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            End Try

        End If

        Try

            tpBarra.Enabled = True
            tbInfo.Enabled = True
            Panel1.Enabled = True
            Me.Cursor = Cursors.Default
            ActivoTrabajando = False
            frmTr.Close()
            frmTr.Dispose()
            ActualizaInformacionTA()
            chkIndividual.Checked = True

        Catch ex As Exception
            Stop
        End Try
    End Sub

    Private Sub btnImportacion_Click(sender As Object, e As EventArgs) Handles btnImportacion.Click
        Try
            Dim dtPath As New DataTable
            Dim Archivo As String

            'Inhabilitar la forma para que no pueda seleccionar otro proceso mientras se completa la importación
            Me.Enabled = False
            dtPath = sqlExecute("SELECT path_hrs FROM parametros")
            If dtPath.Rows.Count = 0 Then
                Archivo = ""
            Else
                Archivo = IIf(IsDBNull(dtPath.Rows(0).Item(0)), "", dtPath.Rows(0).Item(0).ToString.Trim)
            End If

            frmImportacion.ImportaAnoPer = cmbPeriodos.SelectedValue
            frmImportacion.ImportaArchivo = Archivo
            frmImportacion.ShowDialog(Me)

        Catch ex As Exception
            MessageBox.Show("Se detectaron errores durante la importación." & vbCrLf & "Error.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    Private Sub txtFechaAusentismo_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaAusentismo.ValueChanged
        calAusentismo.ShowDate(txtFechaAusentismo.Value)
    End Sub

    Private Sub sbVista_ValueChanged(sender As Object, e As EventArgs) Handles sbVista.ValueChanged
        Try
            If sbVista.Value Then
                calAusentismo.SelectedView = eCalendarView.Month
            Else
                calAusentismo.SelectedView = eCalendarView.Year
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim idx As Integer
        Dim U As String
        Dim R As String
        Dim F As Date
        Dim seltab As String

        Try
            seltab = tbInfo.SelectedTab.Name
            If seltab = "tabExcepcionhrs" Then
                Dim R2 As String
                Dim F2 As String
                Dim Autorizado As Boolean = False
                Dim Aplicado As Boolean = False
                Dim Borrar As Boolean = True
                Dim I As Integer

                I = dgExcepcionHorarios.PrimaryGrid.ActiveRow.RowIndex
                R2 = dgExcepcionHorarios.PrimaryGrid.GetCell(I, 0).Value.ToString.Trim
                F2 = FechaSQL(dgExcepcionHorarios.PrimaryGrid.GetCell(I, 2).Value)

                Borrar = MessageBox.Show("¿Está seguro de eliminar la autorización " & vbCrLf & " de tiempo extra  al empleado " & dgExcepcionHorarios.PrimaryGrid.GetCell(I, 0).Value.ToString.Trim _
                                          & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes


                If Borrar Then
                    sqlExecute("DELETE FROM excepciones_horarios WHERE reloj = '" & R2 & "' AND fecha = '" & F2 & "'")
                    Me.btnRefrescar.RaiseClick()
                Else
                End If

            Else
                idx = dgHorasBruto.CurrentCell.RowIndex
                U = dgHorasBruto.Item("UNICO", idx).Value
                F = dgHorasBruto.Item("fecha", idx).Value
                Dim TF As Date

                R = txtReloj.Text.Trim
                If MessageBox.Show("¿Está seguro de borrar el registro " & U & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Try
                        TF = Date.Parse(U.Substring(0, 10))
                        sqlExecute("DELETE FROM hrs_brt WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(TF) & _
                                     "' AND hora = '" & U.Substring(U.IndexOf(" ")).Trim & "'", "TA")
                    Catch ex As Exception
                        Err.Raise(-1, ex)
                    End Try
                    'sqlExecute("DELETE FROM hrs_brt WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(U) & _
                    '                 "' AND hora = '" & U.Substring(U.IndexOf(" ")).Trim & "'", "TA")

                    dtHrsBrt.Rows.RemoveAt(dgHorasBruto.CurrentCell.RowIndex)

                    ReEvaluar(R, F.AddDays(-1))
                    ReEvaluar(R, F)
                    '--Actualizar Bitacora hrs_brt indicando que se borró ese registro
                    ActBorradoHrsBrt(U, F) '- Mandamos los parámetros de fecha/hora y el de solo fecha

                    If DiaDescanso(F, R) Then
                        Me.btnRefrescar.RaiseClick()
                    End If

                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Hubo errores al tratar de borrar el registro. Si el problema persiste, contacte al administrador del sistema.", "ERROR" _
                            , MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub

    Private Sub chkOtrosFiltros_Click(sender As Object, e As EventArgs) Handles chkOtrosFiltros.Click
        If Not chkOtrosFiltros.Checked Then
            btnSeleccionarFiltros.PerformClick()
        End If
    End Sub


    Private Sub dgAsist_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgAsist.CellMouseDown
        Dim TipoAus As String
        Dim Retardo As Boolean
        Dim SalidaAnt As Boolean
        Dim FaltaEnt As Boolean
        Dim FaltaSal As Boolean
        Try

            '== PARA QUE NO APAREZCA EL MENU DE CLICK DERECHO SI SE TRATA DE DESCANSO               28SEP2021
            If dgAsist.Item("COMENTARIO", e.RowIndex).Value <> "DESCANSO (INFORMATIVO)" Then
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    If e.ColumnIndex = dgAsist.Columns("EXT_AUT").Index Then
                        dtTemp = sqlExecute("SELECT autorizar_extra,filtro_extra,filtro_extra_aut FROM cias_ta WHERE cod_comp = '" & txtCia.Text.Substring(0, 3) & "'", "TA")
                        If dtTemp.Rows.Count = 0 Then
                            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, 0, "Falta información de CiasTa para " & txtCia.Text)
                            Exit Sub
                        Else
                            AutorizarExtra = IIf(IsDBNull(dtTemp.Rows(0).Item("autorizar_extra")), 0, dtTemp.Rows(0).Item("autorizar_extra"))
                            FiltroExtras = IIf(IsDBNull(dtTemp.Rows(0).Item("filtro_extra")), "", dtTemp.Rows(0).Item("filtro_extra"))
                            FiltroExtrasAutorizadas = IIf(IsDBNull(dtTemp.Rows(0).Item("filtro_extra_aut")), "", dtTemp.Rows(0).Item("filtro_extra_aut"))
                        End If

                        mnuTxtLimite.Text = dgAsist.Item("HRS_EXT", e.RowIndex).Value
                    End If

                    dgAsist.CurrentCell = dgAsist.Item(e.ColumnIndex, e.RowIndex)
                    TipoAus = IIf(IsDBNull(dgAsist.Item("TIPO_AUS", e.RowIndex).Value), "", dgAsist.Item("TIPO_AUS", e.RowIndex).Value)
                    Retardo = IIf(IsDBNull(dgAsist.Item("HORAS_TARDE", e.RowIndex).Value), "00:00", dgAsist.Item("HORAS_TARDE", e.RowIndex).Value).ToString.Trim <> "00:00"
                    SalidaAnt = IIf(IsDBNull(dgAsist.Item("HORAS_ANTICIPADAS", e.RowIndex).Value), "00:00", dgAsist.Item("HORAS_ANTICIPADAS", e.RowIndex).Value).ToString.Trim <> "00:00"
                    FaltaEnt = IIf(IsDBNull(dgAsist.Item("ENTRADA", e.RowIndex).Value), "", dgAsist.Item("ENTRADA", e.RowIndex).Value).ToString.Trim = ""
                    FaltaSal = IIf(IsDBNull(dgAsist.Item("SALIDA", e.RowIndex).Value), "", dgAsist.Item("SALIDA", e.RowIndex).Value).ToString.Trim = ""

                    mnuEliminarAusNat.Visible = TipoAus = _aus_natural
                    mnuEliminarAusNatS.Visible = TipoAus = _aus_natural
                    mnuEliminarRetardo.Visible = Retardo
                    mnuEliminarSalAnt.Visible = SalidaAnt
                    mnuAjusteEntrada.Visible = FaltaEnt
                    mnuAjustarSalida.Visible = FaltaSal

                End If
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub chkPEUS_CheckedChanged(sender As Object, e As EventArgs) Handles chkPEUS.CheckedChanged
        If chkPEUS.Checked And chkPares.Checked Then
            chkPares.Checked = False
        End If
    End Sub

    Private Sub chkPares_CheckedChanged(sender As Object, e As EventArgs) Handles chkPares.CheckedChanged
        If chkPEUS.Checked And chkPares.Checked Then
            chkPEUS.Checked = False
        ElseIf chkPares.Checked Then
            chkSemana.Checked = True
        End If
    End Sub

    Private Sub cmbAusentismo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAusentismo.SelectedValueChanged
        If TipoNaturaleza(cmbAusentismo.SelectedValue) = "V" Then
            DevComponents.DotNetBar.ToastNotification.ToastFont = FontRegular
            DevComponents.DotNetBar.ToastNotification.ToastBackColor = Color.Yellow
            DevComponents.DotNetBar.ToastNotification.ToastForeColor = Color.Black

            DevComponents.DotNetBar.ToastNotification.Show(Me.pnlEditarAusentismo, "Las vacaciones agregadas/modificadas " & vbCrLf & _
                                                           "desde la sección de <Tiempo y asistencia> " & vbCrLf & _
                                                           "solo afectarán el saldo de días" & _
                                                           vbCrLf & "para disfrutar, no el pago." _
                                                           , My.Resources.calendar_selection_week16, 10000, DevComponents.DotNetBar.eToastGlowColor.Blue, _
                                                           DevComponents.DotNetBar.eToastPosition.BottomCenter)
        Else
            DevComponents.DotNetBar.ToastNotification.Close(pnlEditarAusentismo)
        End If

        '== Aquí se agregan cambios para que aparezcan los controles de faltas justificadas o injustificadas solamente      Abril 2021      Ernesto
        If cmbAusentismo.SelectedValue <> "" Then
            If cmbAusentismo.SelectedValue.ToString.Trim = "FI" Or cmbAusentismo.SelectedValue.ToString.Trim = "JUS" Then
                lblClas.Visible = True
                cmbClasFalta.Enabled = True
                cmbClasFalta.Visible = True
                cmbClasFalta.SelectedValue = "01 "
            Else
                lblClas.Visible = False
                cmbClasFalta.Enabled = False
                cmbClasFalta.Visible = False
            End If
        End If
    End Sub



    Private Sub btnAceptarAusentismo_Click(sender As Object, e As EventArgs) Handles btnAceptarAusentismo.Click
        Try
            Dim dtEmpleado As DataTable = sqlExecute("select * from personal where reloj = '" & txtReloj.Text & "'")
            Dim aus_anterior As String = ""
            Dim resultado As String

            '==Informacion para la tabla "faltas_justificadas_reporte"          sep2021
            Dim info_faltas As New ArrayList

            If dtEmpleado.Rows.Count Then
                Dim drEmpleado As DataRow = dtEmpleado.Rows(0)

                Dim tipo_aus As String = cmbAusentismo.SelectedValue
                Dim fecha As Date = txt1.Value
                Dim dias As Integer = txtDias.Value
                Dim referencia As String = txtReferencia.Text

                Dim dtAusentismo As DataTable = sqlExecute("select * from tipo_ausentismo where tipo_aus = '" & tipo_aus & "'", "TA")
                If dtAusentismo.Rows.Count Then
                    Dim ausentismo As DataRow = dtAusentismo.Rows(0)

                    Dim i As Integer = 0

                    If ausentismo("tipo_naturaleza") = "I" Then
                        If referencia.Trim.Length >= 8 Then
                            While i < dias
                                Dim dtPeriodo As DataTable = sqlExecute("select * FROM periodos where fecha_ini <= '" & FechaSQL(fecha) & _
                                                                        " ' and fecha_fin >= '" & FechaSQL(fecha) & "' and periodo_especial = '0'", "TA")
                                If dtPeriodo.Rows.Count Then
                                    Dim guardar As Boolean = True

                                    Dim dtExiste As DataTable = sqlExecute("select * from ausentismo where cod_comp = '" & drEmpleado("cod_comp") & _
                                                                           "' and reloj = '" & drEmpleado("reloj") & "' and fecha = '" & FechaSQL(fecha) & _
                                                                           "' and tipo_aus <> 'FI'", "TA")
                                    If dtExiste.Rows.Count Then
                                        If MessageBox.Show("¿Desea sustituir el ausentimo " & aus_anterior & ", existente en la fecha " & FechaSQL(fecha) & "?", "PIDA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                            guardar = False
                                        Else
                                            'MCR 2017-10-12
                                            'Revisar si existe, y debe hacer una devolución de ausentismo
                                            resultado = DevolucionAusentismo(drEmpleado, fecha, tipo_aus)
                                            If Not resultado Is Nothing Then
                                                Err.Raise(-1, resultado)
                                            End If

                                            'MCR 15/OCT/2015
                                            'Insertar en bitácora borrado de ausentismo
                                            sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                                          "(reloj,fecha,tipo_aus,fecha_movimiento,usuario_movimiento,notas) " & _
                                                       "SELECT reloj,fecha,tipo_aus,GETDATE(),'" & Usuario & _
                                                       "','/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/Met: " & _
                                                       System.Reflection.MethodBase.GetCurrentMethod.Name() & "' FROM ausentismo WHERE cod_comp = '" & _
                                                       drEmpleado("cod_comp") & "' and reloj = '" & drEmpleado("reloj") & "' and fecha = '" & FechaSQL(fecha) & _
                                                       "' ", "TA")

                                            sqlExecute("delete from ausentismo where cod_comp = '" & drEmpleado("cod_comp") & "' and reloj = '" & drEmpleado("reloj") & "' and fecha = '" & FechaSQL(fecha) & "' ", "TA")

                                        End If
                                    End If

                                    If guardar Then
                                        sqlExecute("insert into ausentismo (cod_comp, reloj, fecha, tipo_aus, referencia, periodo, subclasi,usuario,fecha_hora) values ('" & _
                                                   drEmpleado("cod_comp") & "', '" & _
                                                   drEmpleado("reloj") & "', '" & _
                                                   FechaSQL(fecha) & "', '" & _
                                                   tipo_aus & "', '" & _
                                                   referencia & "', '" & _
                                                   dtPeriodo.Rows(0)("periodo") & "', '" & _
                                                   txtNotasAusentismo.Text.Replace("'", "") & "', '" & _
                                                   Usuario & "'," & _
                                                   "GETDATE())", "TA")
                                    End If

                                    i += 1

                                    fecha = fecha.AddDays(1)
                                Else
                                    MsgBox("No se encontró un periodo para la fecha solicitada", MsgBoxStyle.OkOnly, "Error")
                                    Exit Sub
                                End If
                            End While
                        Else
                            MsgBox("Referencia no válida", MsgBoxStyle.OkOnly, "Error")
                            Exit Sub
                        End If

                    Else
                        While i < dias
                            Dim dtPeriodo As DataTable = sqlExecute("select * FROM periodos where fecha_ini <= '" & FechaSQL(fecha) & " ' and fecha_fin >= '" & FechaSQL(fecha) & "' and periodo_especial = '0'", "TA")
                            If dtPeriodo.Rows.Count Then

                                If Not (DiaDescanso(fecha, drEmpleado("reloj")) Or Festivo(fecha, drEmpleado("reloj"))) Then
                                    Dim guardar As Boolean = True

                                    Dim dtExiste As DataTable = sqlExecute("select * from ausentismo where cod_comp = '" & drEmpleado("cod_comp") & _
                                                                           "' and reloj = '" & drEmpleado("reloj") & "' and fecha = '" & FechaSQL(fecha) & _
                                                                           "'", "TA")


                                    If dtExiste.Rows.Count Then

                                        aus_anterior = dtExiste.Rows(0)("tipo_aus").ToString.Trim

                                        '==Si hay una edicion sobre las faltas justificadas o injustificadas var_just = true                6sep2021
                                        var_just = False
                                        If tipo_aus.Trim = "FI" Or tipo_aus.Trim = "JUS" Then
                                            var_just = True
                                        End If

                                        'MCR 2017-10-12
                                        'También la falta injustificada consulta para sustituir, y si cancela devolución
                                        'If aus_anterior <> _aus_natural Then

                                        If MessageBox.Show("¿Desea sustituir el ausentimo " & aus_anterior & ", existente en la fecha " & FechaSQL(fecha) & "?", "PIDA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                            guardar = False
                                        Else
                                            'MCR 2017-10-12
                                            'Revisar si existe, y debe hacer una devolución de ausentismo
                                            resultado = DevolucionAusentismo(drEmpleado, fecha, tipo_aus)
                                            If Not resultado Is Nothing Then
                                                Err.Raise(-1, resultado)
                                            End If

                                            guardar = True
                                        End If



                                    End If

                                    If guardar Then

                                        '== Aqui se agregara la clasificacion de falta ya sea justificada o injustificada       Abril 2021      Ernesto
                                        If tipo_aus.Trim = "FI" Or tipo_aus.Trim = "JUS" Then

                                            Dim tipo_falta As String = cmbClasFalta.SelectedValue

                                            '== Como el campo de la tabla de ausentismo: 'datalle_aus' no soporta mas de dos caracteres, entonces se utilizara el codigo numero de la falta     abril 2021      Ernesto

                                            'MCR 15/OCT/2015
                                            'Insertar en bitácora borrado de ausentismo
                                            sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                                          "(reloj,fecha,tipo_aus,fecha_movimiento,usuario_movimiento,notas) " & _
                                                       "SELECT reloj,fecha,tipo_aus,GETDATE(),'" & Usuario & "'," & _
                                                       "'/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/Met: " & _
                                                       System.Reflection.MethodBase.GetCurrentMethod.Name() & "' FROM ausentismo WHERE cod_comp = '" & _
                                                       drEmpleado("cod_comp") & "' and reloj = '" & _
                                                       drEmpleado("reloj") & "' and fecha = '" & FechaSQL(fecha) & "' ", "TA")

                                            sqlExecute("delete from ausentismo where cod_comp = '" & drEmpleado("cod_comp") & "' and reloj = '" & _
                                                       drEmpleado("reloj") & "' and fecha = '" & FechaSQL(fecha) & "' ", "TA")

                                            '== En esta parte del código, se insertará el campo de 'DETALLE_AUS' de la tabla 'ausentismo' ya que actualmente no está en uso, y 
                                            '== se utilizaró para anexar la clasificación de las faltas justificadas e injustificadas            Abril 2021      Ernesto
                                            '== ao 2025-01-16: Se desahbilita campo 'DETALLE_AUS' para que ya no se registre, ya que se utilizará para validar quien tenía FI, y se le cambió por VAC, solicitado por CTE

                                            sqlExecute("insert into ausentismo (cod_comp, reloj, fecha, tipo_aus, periodo, subclasi,usuario,fecha_hora) values  ('" & _
                                                       drEmpleado("cod_comp") & "', '" & _
                                                       drEmpleado("reloj") & "', '" & _
                                                       FechaSQL(fecha) & "', '" & _
                                                       tipo_aus & "', '" & _
                                                       dtPeriodo.Rows(0)("periodo") & "', '" & _
                                                       txtNotasAusentismo.Text.Replace("'", "") & "', '" & _
                                                       Usuario & "'," & _
                                                       "GETDATE())", "TA")

                                            '==Aqui se ingresan los registros de faltas justificadas o injustificadas en la tabla "faltas_justificadas_reporte"     3sep2021
                                            If var_just Then

                                                info_faltas.Add(drEmpleado("reloj").ToString.Trim)
                                                info_faltas.Add(FechaSQL(fecha))
                                                info_faltas.Add(tipo_aus)
                                                info_faltas.Add(dtPeriodo.Rows(0)("periodo"))
                                                info_faltas.Add(tipo_falta.Trim)
                                                info_faltas.Add(txtNotasAusentismo.Text.Replace("'", ""))
                                                info_faltas.Add(Usuario)
                                                info_faltas.Add("GETDATE())")

                                                'sqlExecute("insert into ta.dbo.faltas_justificadas_reporte values('" & _
                                                '            drEmpleado("reloj").ToString.Trim & "', '" & _
                                                '            FechaSQL(fecha) & "', '" & _
                                                '            tipo_aus & "', '" & _
                                                '            dtPeriodo.Rows(0)("periodo") & "', '" & _
                                                '            tipo_falta.Trim & "','" & _
                                                '            txtNotasAusentismo.Text.Replace("'", "") & "', '" & _
                                                '            Usuario & "'," & _
                                                '            "GETDATE())")

                                                '==Si es una edicion de la misma fecha por otro tipo de falta justificada o injustificada, se borra de la tabla de tipos faltas
                                                Tabla_faltas_justificadas_reporte(2, info_faltas)

                                                Tabla_faltas_justificadas_reporte(0, info_faltas)
                                                info_faltas.Clear()
                                            End If

                                        Else
                                            'MCR 15/OCT/2015
                                            'Insertar en bitácora borrado de ausentismo
                                            sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                                          "(reloj,fecha,tipo_aus,fecha_movimiento,usuario_movimiento,notas) " & _
                                                       "SELECT reloj,fecha,tipo_aus,GETDATE(),'" & Usuario & "'," & _
                                                       "'/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/Met: " & _
                                                       System.Reflection.MethodBase.GetCurrentMethod.Name() & "' FROM ausentismo WHERE cod_comp = '" & _
                                                       drEmpleado("cod_comp") & "' and reloj = '" & _
                                                       drEmpleado("reloj") & "' and fecha = '" & FechaSQL(fecha) & "' ", "TA")

                                            sqlExecute("delete from ausentismo where cod_comp = '" & drEmpleado("cod_comp") & "' and reloj = '" & _
                                                       drEmpleado("reloj") & "' and fecha = '" & FechaSQL(fecha) & "' ", "TA")

                                            sqlExecute("insert into ausentismo (cod_comp, reloj, fecha, tipo_aus, periodo, subclasi,usuario,fecha_hora) values  ('" & _
                                                       drEmpleado("cod_comp") & "', '" & _
                                                       drEmpleado("reloj") & "', '" & _
                                                       FechaSQL(fecha) & "', '" & _
                                                       tipo_aus & "', '" & _
                                                       dtPeriodo.Rows(0)("periodo") & "', '" & _
                                                       txtNotasAusentismo.Text.Replace("'", "") & "', '" & _
                                                       Usuario & "'," & _
                                                       "GETDATE())", "TA")

                                        End If
                                    End If

                                    i += 1

                                End If

                                fecha = fecha.AddDays(1)
                            Else
                                MsgBox("No se encontró un periodo para la fecha solicitada", MsgBoxStyle.OkOnly, "Error")
                                Exit Sub
                            End If
                        End While
                    End If

                Else
                    MsgBox("No se encontró el tipo de ausentimo solicitado", MsgBoxStyle.OkOnly, "Error")
                    Exit Sub
                End If
            Else
                MsgBox("No se encontró la información del empleado", MsgBoxStyle.OkOnly, "Error")
                Exit Sub

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.OkOnly, "Error")
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Exit Sub
        End Try

        pnlDetalleAusentismo.Enabled = False
        cmbAusentismo.SelectedValue = ""
        txt1.Value = Nothing
        txtDias.Value = 1
        txtReferencia.Text = ""

        '== Oculta los controles para faltas injustificadas         Abril 2021      Ernesto
        lblClas.Visible = False
        cmbClasFalta.SelectedValue = ""
        cmbClasFalta.Enabled = False
        cmbClasFalta.Visible = False

        'ActualizarCambiosAus()
        btnNuevo.PerformClick()

    End Sub

    '==Funcion para agregar o borrar valores de la tabla de 'faltas_justificadas_reporte'           3sep2021
    Private Sub Tabla_faltas_justificadas_reporte(op As Integer, Optional lista As ArrayList = Nothing)
        Try
            Select Case op
                Case 0              '==Agregar
                    sqlExecute("insert into ta.dbo.faltas_justificadas_reporte values('" & _
                                       lista.Item(0) & "', '" & _
                                       lista.Item(1) & "', '" & _
                                       lista.Item(2) & "', '" & _
                                       lista.Item(3) & "', '" & _
                                       lista.Item(4) & "','" & _
                                       lista.Item(5) & "', '" & _
                                       lista.Item(6) & "'," & _
                                       "" & lista.Item(7) & "")

                Case 1              '==Borrar
                    Dim f_ini As Date = Nothing : Dim f_fin As Date = Nothing
                    f_ini = calAusentismo.SelectedAppointments.Item(0).StartTime
                    f_fin = calAusentismo.SelectedAppointments.Item(0).EndTime
                    sqlExecute("delete from ta.dbo.faltas_justificadas_reporte where " & _
                               "reloj='" & txtReloj.Text.ToString.Trim & "' and fecha between '" & FechaSQL(f_ini) & "' and '" & FechaSQL(f_fin) & "'")

                Case 2              '==Edicion
                    sqlExecute("delete from ta.dbo.faltas_justificadas_reporte where reloj='" & txtReloj.Text.ToString.Trim & "' and fecha='" & FechaSQL(lista.Item(1)) & "'")

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelarAusentismo_Click(sender As Object, e As EventArgs) Handles btnCancelarAusentismo.Click
        Try
            pnlDetalleAusentismo.Enabled = False
            cmbAusentismo.SelectedValue = ""
            txt1.Value = Nothing
            txtDias.Value = 1
            txtReferencia.Text = ""

            '=== Ocultar controles de faltas injustificadas     Abril 2021       Ernesto
            lblClas.Visible = False
            cmbClasFalta.Enabled = False
            cmbClasFalta.Visible = False

        Catch ex As Exception

        End Try
    End Sub



    Private Sub txtHrsDobles_ValueChanged(sender As Object, e As EventArgs) Handles txtHrsDobles.ValueChanged
        txtHorasExtras.Value = txtHrsDobles.Value + txtHrsTriples.Value
        CambiaHoras = Editar
    End Sub

    Private Sub txtHrsTriples_ValueChanged(sender As Object, e As EventArgs) Handles txtHrsTriples.ValueChanged
        txtHorasExtras.Value = txtHrsDobles.Value + txtHrsTriples.Value
        CambiaHoras = Editar
    End Sub

    Private Sub txtHrsNor_ValueChanged(sender As Object, e As EventArgs) Handles txtHrsNor.ValueChanged
        CambiaHoras = Editar
    End Sub

    Private Sub txtHorasExtras_ValueChanged(sender As Object, e As EventArgs) Handles txtHorasExtras.ValueChanged
        CambiaHoras = Editar
    End Sub

    Private Sub txtHrsDobles33_ValueChanged(sender As Object, e As EventArgs) Handles txtHrsDobles33.ValueChanged
        CambiaHoras = Editar
    End Sub

    Private Sub txtHrsTriples33_ValueChanged(sender As Object, e As EventArgs) Handles txtHrsTriples33.ValueChanged
        CambiaHoras = Editar
    End Sub

    Private Sub txtHrsPrimaDom_ValueChanged(sender As Object, e As EventArgs) Handles txtHrsPrimaDom.ValueChanged
        CambiaHoras = Editar
    End Sub

    Private Sub txtHrsDescanso_ValueChanged(sender As Object, e As EventArgs) Handles txtHrsDescanso.ValueChanged
        CambiaHoras = Editar
    End Sub



    Private Sub txtHrsFestivas_ValueChanged(sender As Object, e As EventArgs) Handles txtHrsFestivas.ValueChanged
        CambiaHoras = Editar
    End Sub

    Private Sub TodoElTiempoTrabajadoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TiempoLímiteToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim ID As String

        Try
            ID = txtReloj.Text & cmbPeriodos.SelectedValue
            frmAutorizacionTEEmpleado.MostrarInformacion(ID)
            Dim ess As Windows.Forms.DialogResult
            ess = frmAutorizacionTEEmpleado.ShowDialog()

            chkSemana.Checked = True
            btnAnalisis.RaiseClick()



            ActualizaInformacionTA()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgAsist_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAsist.CellContentClick

    End Sub

    Private Sub mnuTxtLimite_Click(sender As Object, e As EventArgs) Handles mnuTxtLimite.Click
        mnuTxtLimite.SelectionStart = 0
        mnuTxtLimite.SelectionLength = mnuTxtLimite.Text.Length
    End Sub

    Private Sub mnuTxtLimite_GotFocus(sender As Object, e As EventArgs) Handles mnuTxtLimite.GotFocus
        mnuTxtLimite.SelectionStart = 0
        mnuTxtLimite.SelectionLength = mnuTxtLimite.Text.Length
    End Sub

    Private Sub mnuTiempoLimite_Click(sender As Object, e As EventArgs) Handles mnuTiempoLimite.Click
        Try
            Dim HExtras As String
            Dim i As Integer
            Dim Tm As TimeSpan
            Dim F As Date
            Dim HE As String
            Dim HS As String
            Dim aut_limite As Boolean = True
            Dim R As String
            Dim suma_final As Double = 0
            i = dgAsist.SelectedCells(0).RowIndex
            HExtras = dgAsist.Item("HRS_EXT", i).Value.ToString.Trim
            F = dgAsist.Item("FECHA_ENTRADA", i).Value
            HE = dgAsist.Item("ENTRADA", i).Value
            HS = dgAsist.Item("SALIDA", i).Value
            Tm = TimeSpan.Parse(HExtras)
            R = txtReloj.Text

            frmLimiteTE.TimeSelector1.SelectedTime = Tm

            If frmLimiteTE.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                HExtras = strRespuesta



                Dim dtsuma As DataTable = sqlExecute("select * from extras_autorizadas where reloj = '" & R & "' and fecha between '" & FechaSQL(FechaIniPeriodo) & "' and '" & FechaSQL(FechaFinPeriodo) & "'", "TA")

                If dtsuma.Rows.Count > 0 Then
                    For Each dr As DataRow In dtsuma.Rows
                        suma_final = suma_final + HtoD(dr("extras_autorizadas"))
                    Next
                End If

                suma_final = suma_final + HtoD(HExtras)


                If suma_final <= HtoD(Limite_TE) Then
                    aut_limite = False
                End If


                If aut_limite Then
                    MessageBox.Show("El monto excede el límite máximo de horas a autorizar" & vbNewLine & "Total de horas a autorizar en la semana: " & DtoH(suma_final).ToString & vbNewLine & "Límite de horas: " & Limite_TE, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    dtTemporal = sqlExecute("SELECT reloj FROM extras_autorizadas WHERE reloj = '" & txtReloj.Text & "' AND fecha = '" & F & "'", "TA")

                    If dtTemporal.Rows.Count = 0 Then
                        sqlExecute("INSERT INTO extras_autorizadas (reloj,fecha) VALUES ('" & txtReloj.Text & "','" & F & "')", "ta")
                    End If

                    dtTemporal = sqlExecute("SELECT cod_depto FROM asist WHERE COD_COMP = '" & Comp & "' AND reloj = '" & R & _
                                      "' AND fecha_entro = '" & FechaSQL(F) & "' AND entro = '" & HE & "'", "TA")
                    If dtTemporal.Rows.Count > 0 Then
                        sqlExecute("UPDATE extras_autorizadas SET cod_depto = '" & dtTemporal.Rows(0).Item("COD_DEPTO") & "'," & _
                                   "depto_transferencia = '" & dtTemporal.Rows(0).Item("COD_DEPTO") & "' " & _
                                   "WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                    End If

                    'De momento, no se requiere autorización de director. Aprobar todo si el supervisor lo captura 
                    sqlExecute("UPDATE extras_autorizadas SET " & _
                               "entrada = '" & HE & "', " & _
                               "salida = '" & HS & "', " & _
                               "extras_reales = '" & HExtras & "', " & _
                               "extras_autorizadas = '" & HExtras & "', " & _
                               "periodo = '" & cmbPeriodos.SelectedValue.ToString.Substring(4, 2) & "', " & _
                               "ano = '" & cmbPeriodos.SelectedValue.ToString.Substring(0, 4) & "', " & _
                               "usuario_s = '" & Usuario & "', " & _
                               "fecha_s = '" & FechaSQL(Now.Date) & "', " & _
                               "envio_s = 1," & _
                               "usuario_a1 = '" & Usuario & "', " & _
                               "fecha_a1 = '" & FechaSQL(Now.Date) & "', " & _
                               "autori_a1 = 1 , " & _
                               "envio_a1 = 1," & _
                               "usuario_a2 = '" & Usuario & "', " & _
                               "fecha_a2 = '" & FechaSQL(Now.Date) & "', " & _
                               "autori_a2 = 1 , " & _
                               "envio_a2 = 1,aplicado = 1,analizado = 0  " & _
                               "WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(F) & "'", "TA")
                    bitacora_tiempo_extra(R, F, HExtras)
                    ReEvaluar(R, F)
                    ActualizaInformacionTA()
                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub mnuTodoTE_Click(sender As Object, e As EventArgs) Handles mnuTodoTE.Click
        Try
            Dim HExtras As String
            Dim i As Integer
            Dim Tm As TimeSpan
            Dim F As Date
            Dim HE As String
            Dim HS As String

            Dim R As String

            i = dgAsist.SelectedCells(0).RowIndex
            HExtras = dgAsist.Item("HRS_EXT", i).Value.ToString.Trim
            F = dgAsist.Item("FECHA_ENTRADA", i).Value
            HE = dgAsist.Item("ENTRADA", i).Value
            HS = dgAsist.Item("SALIDA", i).Value
            Tm = TimeSpan.Parse(HExtras)
            R = txtReloj.Text

            dtTemporal = sqlExecute("SELECT reloj FROM extras_autorizadas WHERE reloj = '" & txtReloj.Text & "' AND fecha = '" & FechaSQL(F) & "'", "TA")

            If dtTemporal.Rows.Count = 0 Then
                sqlExecute("INSERT INTO extras_autorizadas (reloj,fecha) VALUES ('" & txtReloj.Text & "','" & FechaSQL(F) & "')", "ta")
            End If

            dtTemporal = sqlExecute("SELECT cod_depto FROM asist WHERE reloj = '" & R & _
                                  "' AND fecha_entro = '" & FechaSQL(F) & "' AND entro = '" & HE & "'", "TA")
            If dtTemporal.Rows.Count > 0 Then
                sqlExecute("UPDATE extras_autorizadas SET cod_depto = '" & dtTemporal.Rows(0).Item("COD_DEPTO") & "'," & _
                           "depto_transferencia = '" & dtTemporal.Rows(0).Item("COD_DEPTO") & "' " & _
                           "WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(F) & "'", "TA")
            End If

            'De momento, no se requiere autorización de gerente. Aprobar todo si el supervisor lo captura 
            'De momento, no se requiere autorización de director. Aprobar todo si el supervisor lo captura  
            sqlExecute("UPDATE extras_autorizadas SET " & _
                       "entrada = '" & HE & "', " & _
                       "salida = '" & HS & "', " & _
                       "extras_reales = '" & HExtras & "', " & _
                       "extras_autorizadas = 'TODO', " & _
                       "periodo = '" & cmbPeriodos.SelectedValue.ToString.Substring(4, 2) & "', " & _
                       "ano = '" & cmbPeriodos.SelectedValue.ToString.Substring(0, 4) & "', " & _
                       "usuario_s = '" & Usuario & "', " & _
                       "fecha_s = '" & FechaSQL(Now.Date) & "', " & _
                       "envio_s = 1, " & _
                       "usuario_a1 = '" & Usuario & "', " & _
                       "fecha_a1 = '" & FechaSQL(Now.Date) & "', " & _
                       "autori_a1 = 1 , " & _
                       "envio_a1 = 1,aplicado = 1,analizado = 0, " & _
                       "usuario_a2 = '" & Usuario & "', " & _
                       "fecha_a2 = '" & FechaSQL(Now.Date) & "', " & _
                       "autori_a2 = 1 , " & _
                       "envio_a2 = 1 " & _
                       "WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(F) & "'", "TA")
            ReEvaluar(R, F)
            ActualizaInformacionTA()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub mnuEntrada_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuEntrada.Opening

    End Sub

    Private Sub cmbPeriodos_TextChanged(sender As Object, e As EventArgs) Handles cmbPeriodos.TextChanged

    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        Reloj = txtReloj.Text
        dtPersonal = ConsultaPersonalVW("SELECT * FROM personalvw WHERE reloj ='" & Reloj & "' " & Acumulado & " ORDER BY reloj ASC", False)
        MostrarInformacion(txtReloj.Text.Trim)
    End Sub

    Private Sub mnuAjusteEntrada_Click(sender As Object, e As EventArgs) Handles mnuAjusteEntrada.Click

    End Sub

    Private Sub EliminarTiempoExtraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarTiempoExtraToolStripMenuItem.Click
        Try
            Dim HExtras As String
            Dim i As Integer
            Dim Tm As TimeSpan
            Dim F As Date
            Dim HE As String
            Dim HS As String

            Dim R As String

            i = dgAsist.SelectedCells(0).RowIndex
            HExtras = dgAsist.Item("HRS_EXT", i).Value.ToString.Trim
            F = dgAsist.Item("FECHA_ENTRADA", i).Value
            HE = dgAsist.Item("ENTRADA", i).Value
            HS = dgAsist.Item("SALIDA", i).Value
            Tm = TimeSpan.Parse(HExtras)
            R = txtReloj.Text

            dtTemporal = sqlExecute("SELECT reloj FROM extras_autorizadas WHERE reloj = '" & txtReloj.Text & "' AND fecha = '" & F & "'", "TA")

            If dtTemporal.Rows.Count = 0 Then
                sqlExecute("INSERT INTO extras_autorizadas (reloj,fecha) VALUES ('" & txtReloj.Text & "','" & F & "')", "ta")
            End If

            dtTemporal = sqlExecute("SELECT cod_depto FROM asist WHERE COD_COMP = '" & Comp & "' AND reloj = '" & R & _
                                  "' AND fecha_entro = '" & FechaSQL(F) & "' AND entro = '" & HE & "'", "TA")
            If dtTemporal.Rows.Count > 0 Then
                sqlExecute("UPDATE extras_autorizadas SET cod_depto = '" & dtTemporal.Rows(0).Item("COD_DEPTO") & "'," & _
                           "depto_transferencia = '" & dtTemporal.Rows(0).Item("COD_DEPTO") & "' " & _
                           "WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(F) & "'", "TA")
            End If

            'De momento, no se requiere autorización de gerente. Aprobar todo si el supervisor lo captura 
            'De momento, no se requiere autorización de director. Aprobar todo si el supervisor lo captura  
            sqlExecute("UPDATE extras_autorizadas SET " & _
                       "entrada = '" & HE & "', " & _
                       "salida = '" & HS & "', " & _
                       "extras_reales = '" & HExtras & "', " & _
                       "extras_autorizadas = '00:00', " & _
                       "periodo = '" & cmbPeriodos.SelectedValue.ToString.Substring(4, 2) & "', " & _
                       "ano = '" & cmbPeriodos.SelectedValue.ToString.Substring(0, 4) & "', " & _
                       "usuario_s = '" & Usuario & "', " & _
                       "fecha_s = '" & FechaSQL(Now.Date) & "', " & _
                       "envio_s = 1, " & _
                       "usuario_a1 = '" & Usuario & "', " & _
                       "fecha_a1 = '" & FechaSQL(Now.Date) & "', " & _
                       "autori_a1 = 1 , " & _
                       "envio_a1 = 1,aplicado = 1,analizado = 0, " & _
                       "usuario_a2 = '" & Usuario & "', " & _
                       "fecha_a2 = '" & FechaSQL(Now.Date) & "', " & _
                       "autori_a2 = 1 , " & _
                       "envio_a2 = 1 " & _
                       "WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(F) & "'", "TA")
            ReEvaluar(R, F)
            ActualizaInformacionTA()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Public Sub LlenaNomSem33(ByVal drEmpleado As DataRow, Periodo As String)
        Try
            Dim registros As Integer = 0
            Dim hrs_normal As Double = 0
            Dim hrs_extras As Double = 0
            Dim hrs_dobles As Double = 0
            Dim hrs_triples As Double = 0
            Dim hrs_tarde As Double = 0
            Dim hrs_prim_dom As Double = 0
            Dim hrs_descanso As Double = 0
            Dim hrs_festivo As Double = 0
            Dim shrs_dia As Double = 0
            Dim hrs_conv As Double = 0
            Dim pareja As Boolean = True
            Dim bono_puntualidad As Boolean = True
            Dim bono_asistencia As Boolean = True
            Dim asistencia_perfecta As Boolean = True
            Dim ausentismo As Boolean = True
            Dim periodo_act As Double = 0
            Dim dobles_exentas As Double = 0
            Dim dobles_33 As Double = 0
            Dim triples_33 As Double = 0
            Dim tran_cerrada As Boolean = False
            Dim ExtrasDiarias As Double = 0
            Dim DiasExtras As Integer = 0
            Dim DiasTrab As Integer = 0

            'MCR 11/NOV/2015
            'Variables cálculo 3/3
            Dim DoblesIntegrables As Double = 0
            Dim TriplesIntegrables As Double = 0
            Dim Total33 As Double = 0
            Dim Excedente As Double = 0

            Dim DblDiarias As Double
            Dim TrplDiarias As Double
            Dim DblDiariasIntegrables As Double
            Dim TrplDiariasIntegrables As Double

            'calcular bonos

            Dim BONASI As Double = 0
            Dim BONPUN As Double = 0
            Dim BONDES As Double = 0

            Dim FestivoSeparado As Boolean
            Dim FestivoDescanso As Boolean

            Dim EsFestivo As Boolean = False
            Dim EsDescanso As Boolean = False
            Dim EsDomingo As Boolean = False
            Dim Fecha As Date

            Dim dtTAsist As New DataTable
            Dim drAsist As DataRow

            Dim R As String

            Dim Cadena As String = ""
            R = drEmpleado("reloj")



            FestivoSeparado = False
            FestivoDescanso = False

            'Actualizar datos de personal que hay en asist, para todos los registros del periodo
            'De acuerdo a:
            '*** EL 23 ENERO 07 SUSY PIDIO QUE SE ACTUALIZARAN LOS DATOS DE TODA LA SEMANA
            '*** IVO

            '
            dtAsist = sqlExecute("SELECT MIN(pareja) as pareja,MAX(ausentismo) as ausentismo," & _
                                 "SUM(dbo.htod(extras_autorizadas)) as extras_autorizadas," & _
                                 "SUM(dbo.HTOD(horas_normales)) AS horas_normales," & _
                                 "SUM(dbo.HTOD(horas_tarde)) AS horas_tarde," & _
                                 "SUM(dbo.HTOD(horas_convenio)) AS horas_convenio," & _
                                 "fha_ent_hor,MIN(fecha_entro) AS fecha_entro,MIN(entro) AS entro FROM asist " & _
                                 "WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & R & _
                                  "'ano = '" & Periodo.Substring(0, 4) & "' AND periodo = '" & Periodo.Substring(4, 2) & _
                                  "'  GROUP BY FHA_ENT_HOR", "TA")
            For Each drAsist In dtAsist.Rows
                'Contar registros
                registros = registros + 1

                'Utilizar la fecha de su horario como base
                Fecha = drAsist("fha_ent_hor")

                'Definir si esta fecha corresponde a un día festivo, domingo o descanso
                EsDomingo = DiaSem(Fecha).ToLower = "domingo"
                EsDescanso = DiaDescanso(Fecha, R)
                EsFestivo = Festivo(Fecha, R)

                'Sumar horas
                If Not FestivoSeparado Or Not EsFestivo Then
                    'Si no se separan las horas del festivo
                    'o no es festivo
                    hrs_normal = hrs_normal + drAsist("horas_normales")
                    hrs_tarde = hrs_tarde + drAsist("horas_tarde")
                    hrs_conv = hrs_conv + drAsist("horas_convenio")
                Else
                    hrs_festivo = hrs_festivo + drAsist("horas_normales")
                    hrs_tarde = hrs_tarde + drAsist("horas_tarde")
                End If

                'Contabilizar horas extras
                If FestivoSeparado Then
                    If EsFestivo And FestivoDescanso Then
                        hrs_descanso = hrs_descanso + drAsist("extras_autorizadas")
                    Else
                        hrs_extras = hrs_extras + drAsist("extras_autorizadas")
                    End If
                Else
                    hrs_extras = hrs_extras + drAsist("extras_autorizadas")
                End If

                ExtrasDiarias = drAsist("extras_autorizadas")

                'Si es domingo
                If EsDomingo Then
                    'If drEmpleado("cod_turno") = "5" Then
                    '************  Lineas para agregar prima dominical al turno 5  ********************
                    hrs_prim_dom = hrs_prim_dom + drAsist("extras_autorizadas") + drAsist("horas_normales")
                    'Else
                    'hrs_prim_dom = hrs_prim_dom + HtoD(drAsist("extras_autorizadas"))
                    ' End If
                End If

                If ExtrasDiarias > 0 Then
                    'Contabilizar horas dobles y triples
                    If hrs_extras > 9 Then
                        DblDiarias = 9 - hrs_dobles
                        TrplDiarias = ExtrasDiarias - DblDiarias

                        hrs_dobles = 9
                        hrs_triples = hrs_extras - hrs_dobles
                    Else
                        hrs_dobles = hrs_extras
                        DblDiarias = ExtrasDiarias
                    End If

                    '****** Sistema 3x3 ******
                    'MCR 12/NOV/2015
                    'Dim Aplica33 As Integer = sqlExecute("select isnull(regla_33, 0) as regla_33 from cias_ta where cod_comp = '" & _
                    '                                     drEmpleado("cod_comp") & "'", "ta").Rows(0)("regla_33")
                    Dim aplica33 As Boolean = True
                    If aplica33 Then
                        DiasExtras += 1

                        'Todas las triples se integran
                        TrplDiariasIntegrables = TrplDiarias

                        If EsDescanso Or EsFestivo Then
                            'Si es descanso o festivo, las horas extras son todas integrables
                            DblDiariasIntegrables = DblDiarias
                        Else
                            If DiasExtras > 3 Then
                                'Después de 3 días con tiempo extra, todas las extras son integrables
                                DblDiariasIntegrables = DblDiarias
                            ElseIf DblDiarias > 3 Then
                                'Las primeras 3 horas extras del día no son integrables
                                DblDiariasIntegrables = DblDiarias - 3
                            Else
                                'Si no son más de 3 días, ni más de 3 horas, no hay dobles integrables
                                DblDiariasIntegrables = 0
                            End If
                        End If
                        'Acumular integrables semanales
                        DoblesIntegrables += DblDiariasIntegrables
                        TriplesIntegrables += TrplDiariasIntegrables

                        'Actualizar tabla de ASIST
                        sqlExecute("UPDATE asist SET analizado_33 = 1, " & _
                                   "dobles_33 = " & Math.Round(DblDiariasIntegrables, 4) & ", " & _
                                   "triples_33 = " & Math.Round(TrplDiariasIntegrables, 4) & _
                                   " WHERE reloj = '" & R & "' AND fha_ent_hor = '" & FechaSQL(drAsist("fecha_entro")) & "' AND " & _
                                   "entro = '" & drAsist("entro") & "'", "TA")
                    End If ' Aplica33
                    '***** ***** ****
                End If

                'Revisar si todos tienen pareja
                pareja = pareja And (drAsist("pareja") = 1)



                'Revisar si hubo ausentismo
                ausentismo = ausentismo And (IIf(IsDBNull(drAsist("ausentismo")), 0, drAsist("ausentismo")) = 1)
            Next

            dtTemp = sqlExecute("SELECT DISTINCT FHA_ENT_HOR FROM asist WHERE COD_COMP = '" & drEmpleado("cod_comp") & "' AND reloj = '" & R & _
                                  "' AND ano = '" & Periodo.Substring(0, 4) & "' AND periodo = '" & Periodo.Substring(4, 2) & _
                                  "' AND RTRIM(entro) <>'' and RTRIM(salio) <> ''", "TA")
            DiasTrab = dtTemp.Rows.Count



        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCalculo33_Click(sender As Object, e As EventArgs) Handles btnCalculo33.Click
        Dim PeriodoC As String
        PeriodoC = cmbPeriodos.SelectedValue

        Dim dtNomSem As New DataTable

        dtNomSem = sqlExecute("SELECT reloj FROM nomsem WHERE ano = '" & PeriodoC.Substring(0, 4) & "' and periodo = '" & _
                              PeriodoC.Substring(4, 2) & "' and hrs_dobles+hrs_triples>0", "TA")
        For Each dEmp As DataRow In dtNomSem.Rows
            LlenaNomSem33(dEmp, PeriodoC)
        Next
        MessageBox.Show("Terminado")
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Try
            Dim PeriodoSeleccionado As String = cmbPeriodos.SelectedValue
            Dim dtPeriodos As DataTable = sqlExecute("select ano, periodo FROM periodos where isnull(periodo_especial, '0') = '0' and ano + periodo < '" & PeriodoSeleccionado & "' order by ano + periodo desc", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                PeriodoSeleccionado = dtPeriodos.Rows(0)("ANO") & dtPeriodos.Rows(0)("PERIODO")
                cmbPeriodos.SelectedValue = PeriodoSeleccionado
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Try
            Dim PeriodoSeleccionado As String = cmbPeriodos.SelectedValue
            Dim dtPeriodos As DataTable = sqlExecute("select ano, periodo FROM periodos where isnull(periodo_especial, '0') = '0' and ano + periodo > '" & PeriodoSeleccionado & "' order by ano + periodo asc", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                PeriodoSeleccionado = dtPeriodos.Rows(0)("ANO") & dtPeriodos.Rows(0)("PERIODO")
                cmbPeriodos.SelectedValue = PeriodoSeleccionado
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try

            Dim dtPeriodo As DataTable = sqlExecute("select * FROM periodos where ano+periodo = '" & cmbPeriodos.SelectedValue & "'", "ta")
            If dtPeriodo.Rows.Count > 0 Then

                Dim frm As New frmRangoFechas

                FechaInicial = dtPeriodo.Rows(0)("fecha_ini")
                FechaFinal = dtPeriodo.Rows(0)("fecha_fin")

                frmRangoFechas.frmRangoFechas_fecha_ini = FechaInicial
                frmRangoFechas.frmRangoFechas_fecha_fin = FechaFinal

                If frmRangoFechas.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim dtAsist As DataTable = sqlExecute("select * from tavw where reloj = '" & txtReloj.Text & "' and fha_ent_hor between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'", "TA")
                    If dtAsist.Rows.Count > 0 Then
                        frmVistaPrevia.LlamarReporte("Prenómina semanal", dtAsist)
                        frmVistaPrevia.ShowDialog()
                    End If
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs)
        Try

            Dim dtPeriodo As DataTable = sqlExecute("select * FROM periodos where ano+periodo = '" & cmbPeriodos.SelectedValue & "'", "ta")
            If dtPeriodo.Rows.Count > 0 Then

                Dim frm As New frmRangoFechas

                FechaInicial = dtPeriodo.Rows(0)("fecha_ini")
                FechaFinal = dtPeriodo.Rows(0)("fecha_fin")

                frmRangoFechas.frmRangoFechas_fecha_ini = FechaInicial
                frmRangoFechas.frmRangoFechas_fecha_fin = FechaFinal

                If frmRangoFechas.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim dtAsist As DataTable = sqlExecute("select * from tavw where reloj = '" & txtReloj.Text & "' and fha_ent_hor between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'", "TA")
                    If dtAsist.Rows.Count > 0 Then
                        frmVistaPrevia.LlamarReporte("Prenómina semanal", dtAsist)
                        frmVistaPrevia.ShowDialog()
                    End If
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkRevisar_CheckedChanged(sender As Object, e As EventArgs) Handles chkNotaUsuario.CheckedChanged
        Try
            If chkNotaUsuario.Checked Then
                sqlExecute("update nomsem set usuario_nota = '" & Usuario & "' where reloj = '" & txtReloj.Text & "' and ano+periodo = '" & _
                           cmbPeriodos.SelectedValue & "'", "TA")
                chkNotaUsuario.Font = New Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Bold)
            Else
                sqlExecute("update nomsem set usuario_nota = null where reloj = '" & txtReloj.Text & "' and ano+periodo = '" & cmbPeriodos.SelectedValue & _
                           "'", "TA")
                chkNotaUsuario.Font = New Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Regular)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkRevision_CheckedChanged(sender As Object, e As EventArgs) Handles chkRevision.CheckedChanged
        Try
            Dim I As Integer = -1
            If chkRevision.Checked Then

                Dim Filtro As String
                Filtro = "USUARIO_NOTA IS NOT NULL"

                Filtros(1, NFiltros) = "REVISAR"
                Filtros(2, NFiltros) = Filtro

                NFiltros = NFiltros + 1

                ReDim Preserve Filtros(2, NFiltros)
                lstFiltros.Items.Add(Filtro)
            Else
                'Actualiza lista de filtros
                Dim x As Integer

                For x = 0 To NFiltros - 1
                    If Filtros(1, x) = "REVISAR" Then
                        I = x
                        Exit For
                    End If
                Next

                If I < 0 Then Exit Sub
                lstFiltros.Items.RemoveAt(I)

                For x = I To NFiltros - 1
                    Filtros(1, x) = Filtros(1, x + 1)
                    Filtros(2, x) = Filtros(2, x + 1)
                Next
                NFiltros = NFiltros - 1
                ReDim Preserve Filtros(2, x)
            End If

            FiltrosActivos()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Public Function DevolucionAusentismo(ByVal drEmpleado As DataRow, ByVal Fecha As Date, ByVal AusentismoNuevo As String) As String

        Return Nothing

        Try
            Dim concepto As String = ""
            Dim ano As String
            Dim periodo As String
            Dim naturaleza As String
            Dim numcredito As String = ""
            Dim ausentismo As String = ""
            Dim AnoPeriodo As String

            Dim dtExiste As DataTable = sqlExecute("select ISNULL(tipo_aus,'') from ausentismo where cod_comp = '" & drEmpleado("cod_comp") & _
                                                                          "' and reloj = '" & drEmpleado("reloj") & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
            If dtExiste.Rows.Count Then
                ausentismo = dtExiste.Rows(0)(0)
                If ausentismo = AusentismoNuevo Then
                    Return Nothing
                Else
                    If ObtenerAnoPeriodo(Fecha, drEmpleado("tipo_periodo")) < ObtenerAnoPeriodo(Now, drEmpleado("tipo_periodo")) Then
                        If MessageBox.Show("¿Desea procesar la devolución/cancelación del ausentismo en la nómina para el día " & FechaSQL(Fecha) & "?", "PIDA", MessageBoxButtons.YesNo, _
                                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                            Return Nothing
                        End If
                    End If
                End If
            End If

            AnoPeriodo = ObtenerAnoPeriodo(Fecha, drEmpleado("tipo_periodo"))
            ano = AnoPeriodo.Substring(0, 4)
            periodo = AnoPeriodo.Substring(4, 2)

            numcredito = Fecha.Year & Fecha.Month.ToString.PadLeft(2, "0") & Fecha.Day.ToString.PadLeft(2, "0") & ausentismo
            AjustesNomKey = ano + periodo & txtReloj.Text & concepto & numcredito

            dtTemp = sqlExecute("SELECT ISNULL(envio_nom,0) as envio_nom FROM ajustes_nom WHERE (ano + periodo + reloj + rtrim(concepto) + numcredito) = '" & _
                       AjustesNomKey & "'", "nomina")

            If dtTemp.Rows.Count > 0 Then
                If dtTemp.Rows(0)(0) = 1 Then
                    Err.Raise(-1, "La devolución ya fue enviada a nómina, por lo que no puede ser modificada. Favor de verificar.")
                End If
            End If

            dtTemp = sqlExecute("SELECT cancelacion,devolucion FROM tipo_ausentismo WHERE tipo_aus = '" & ausentismo & "'", "TA")
            If dtTemp.Rows.Count > 0 Then
                concepto = IIf(IsDBNull(dtTemp.Rows(0)("cancelacion")), IIf(IsDBNull(dtTemp.Rows(0)("devolucion")), "", dtTemp.Rows(0)("devolucion")), dtTemp.Rows(0)("cancelacion"))
                If concepto = "" Then
                    Err.Raise(-1, "No se localizó concepto de cancelación/devolución para el ausentismo " & ausentismo & ". Empleado " & Reloj)
                End If
            Else
                Err.Raise(-1, "No se localizó ausentismo " & ausentismo & " para devoluciones. Empleado " & Reloj)
            End If


            sqlExecute("INSERT INTO ajustes_nom (reloj,ano,periodo,concepto,numcredito,tipo_ajuste) " & _
                           "VALUES ('" & txtReloj.Text & "','" & ano & "','" & _
                           periodo & "','" & concepto & "','" & _
                           numcredito & "','D')", "nomina")

            dtTemp = sqlExecute("SELECT cod_naturaleza FROM conceptos WHERE concepto= '" & concepto & "'", "nomina")
            If dtTemp.Rows.Count = 0 Then
                naturaleza = "I"
            Else
                naturaleza = IIf(IsDBNull(dtTemp.Rows(0).Item(0)), "I", dtTemp.Rows(0).Item(0))
            End If

            sqlExecute("UPDATE ajustes_nom SET " & _
                       "ano = '" & ano & _
                       "', periodo = '" & periodo & _
                       "',per_ded = '" & naturaleza.Trim & _
                       "', clave = (SELECT misce_clave FROM conceptos WHERE concepto like '%" & concepto & "%'), " & _
                       "monto = " & 1 & _
                       ",comentario = 'Cancelación/devolución de ausentismo, desde TA" & _
                       "',concepto = '" & concepto & _
                       "', usuario = '" & Usuario & _
                       "',fecha = '" & FechaSQL(Now) & _
                       "',cap_nomina = 1  " & _
                       ", numcredito = '" & numcredito & "' " & _
                       ", tipo_ajuste = 'D' " & _
                       ", fecha_incidencia = '" & FechaSQL(Fecha) & _
                       "', numperiodos = 1 " & _
                       ", tipo_periodo = '" & drEmpleado("tipo_periodo") & "'" & _
                       "WHERE (ano + periodo + reloj + rtrim(concepto) + numcredito) = '" & _
                       AjustesNomKey & "'", "nomina")

            Return Nothing
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


    'FUNCIONES ACTUALIZAR SABADOS Y DOMINGOS DOBLES
    '------------------------------------------------------
    'CONSULTA PARA HORAS BRUTO DE EMPLEADO POR PERIODO                  10/DIC/20
    Public Function ConsultarHrsBrutasPorPeriodo(clock As String) As DataTable

        Dim HorasBruto As New DataTable
        Dim dthorario As New DataTable
        Dim PeriodoSeleccionado As String = cmbPeriodos.SelectedValue
        Dim rango As Double
        Dim FIni As Date = Now
        Dim FFin As Date = Now

        dtTemp = sqlExecute("SELECT fecha_ini,fecha_fin,activo FROM periodos WHERE ano = '" & PeriodoSeleccionado.Substring(0, 4) & "' AND periodo = '" & PeriodoSeleccionado.Substring(4, 2) & "'", "TA")

        FIni = dtTemp.Rows(0).Item("fecha_ini")
        FFin = dtTemp.Rows(0).Item("fecha_fin")

        dthorario = sqlExecute("SELECT TOP 1 rango_hrs FROM dias LEFT JOIN personal " & "ON dias.cod_comp = personal.cod_comp AND dias.cod_hora = personal.cod_hora " & _
                              "WHERE reloj = '" & clock & "' ORDER BY cod_dia, TA.DBO.HORA12A24(ENTRA)")

        rango = HtoD(IIf(IsDBNull(dthorario.Rows(0).Item("rango_hrs")), "03:00", dthorario.Rows(0).Item("rango_hrs"))) * 60
        FIni = DateAdd(DateInterval.Minute, rango, FIni)

        dthorario = sqlExecute("SELECT TOP 1 rango_hrs FROM dias LEFT JOIN personal " & "ON dias.cod_comp = personal.cod_comp AND dias.cod_hora = personal.cod_hora " & _
                   "WHERE reloj = '" & clock & "' ORDER BY cod_dia DESC, TA.DBO.HORA12A24(ENTRA) DESC")

        rango = HtoD(IIf(IsDBNull(dthorario.Rows(0).Item("rango_hrs")), "03:00", dthorario.Rows(0).Item("rango_hrs"))) * 60

        FFin = DateAdd(DateInterval.Minute, rango + (24 * 60), FFin)

        HorasBruto = sqlExecute("SELECT PERIODO,GAFETE,FECHA,HORA,DIA AS 'DÍA',tipo_tran AS 'TIPO TRANSACCIÓN'," & "CONVERT(char(11),FECHA,23) + ' ' + HORA AS UNICO,FECHA_EFVA AS 'FECHA EFECTIVA'," & _
                  "ENTRADA_SALIDA AS 'ENTRADA/ SALIDA' FROM hrs_brt " & "WHERE reloj = '" & clock & "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & _
                  FechaHoraSQL(FIni) & "' AND '" & FechaHoraSQL(FFin) & "' ORDER BY fecha,hora", "TA")

        Return HorasBruto
    End Function

    'FUNCION PRINCIPAL                                                  15/DIC/20
    Public Sub SabadoDomingo(clock As String)

        Dim dtHorasBruto As New DataTable
        Dim dtHorarioSabadoDomingo As New DataTable
        Dim filaCont As Integer = 0
        Dim listaFilas As New List(Of Integer)
        Dim listaDias As New List(Of String)
        Dim S As Integer = 0
        Dim D As Integer = 0
        Dim sabadoydomingo As Integer
        Dim diaTrabajando As String
        Dim diaAnterior As String

        dtHorasBruto = ConsultarHrsBrutasPorPeriodo(clock)
        dtHorarioSabadoDomingo = dtHorasBruto

        'Registra las filas de los sábados y domingo disponibles
        For Each x As DataRow In dtHorasBruto.Rows
            If x.Item("DÍA") = "Sábado   " Or x.Item("DÍA") = "Domingo  " Then
                If x.Item("DÍA") = "Sábado   " Then
                    S = 1
                    listaFilas.Add(filaCont)
                    listaDias.Add("s")
                End If

                If x.Item("DÍA") = "Domingo  " Then
                    D = 1
                    listaFilas.Add(filaCont)
                    listaDias.Add("d")
                End If
            End If
            filaCont += 1
        Next

        sabadoydomingo = S + D
        filaCont = 0

        If sabadoydomingo = 1 Then
            If S = 1 Then
                diaTrabajando = "Sábado   "
                diaAnterior = "Viernes  "
            End If
            If D = 1 Then
                diaTrabajando = "Domingo  "
                diaAnterior = "Sábado   "
            End If
        End If

        For Each x As DataRow In dtHorarioSabadoDomingo.Rows

            'Si el día el sábado o domingo
            If x.Item("DÍA") = "Sábado   " Or x.Item("DÍA") = "Domingo  " Then
                'Si es un dia (sab o domingo)
                If sabadoydomingo = 1 Then
                    EvaluarSabDom(clock, diaTrabajando, diaAnterior, dtHorarioSabadoDomingo, filaCont, listaFilas, x, S, D, listaDias)
                    'Ambos días
                ElseIf sabadoydomingo = 2 Then
                    If x.Item("DÍA") = "Sábado   " Then
                        diaTrabajando = "Sábado   "
                        diaAnterior = "Viernes  "
                        EvaluarSabDom(clock, diaTrabajando, diaAnterior, dtHorarioSabadoDomingo, filaCont, listaFilas, x, S, D, listaDias)
                    End If
                    If x.Item("DÍA") = "Domingo  " Then
                        diaTrabajando = "Domingo  "
                        diaAnterior = "Sábado   "
                        EvaluarSabDom(clock, diaTrabajando, diaAnterior, dtHorarioSabadoDomingo, filaCont, listaFilas, x, S, D, listaDias)
                    End If
                End If

            End If
            filaCont += 1
        Next
    End Sub

    'EVALUAR PRIMER Y ULTIMO REGISTRO DE SABADOS Y DOMINGOS             ultima actualizacion: abril 20 2021   
    Public Sub EvaluarSabDom(varClock As String, diaPresente As String, diaPasado As String, tabla As DataTable, x As Integer, lista As List(Of Integer),
                             fila As DataRow, S As Integer, D As Integer, sabdom As List(Of String))

        Dim TablaTemp As DataTable = tabla
        Dim iniSab As Integer
        Dim iniDom As Integer
        Dim final As Integer = 0
        Dim ini As Integer = 0
        Dim suma As Integer = 0
        Dim condicion1 As Boolean
        Dim condicion2 As Boolean
        'Variables query
        Dim fechaDia As String
        Dim hora As String
        hora = fila.Item("HORA")
        fechaDia = FechaSQL(fila.Item("FECHA"))

        Try
            For Each elem As String In sabdom
                If elem = "s" Then
                    iniSab += 1
                End If
                If elem = "d" Then
                    iniDom += 1
                End If
            Next

            'Para ambos días presentes
            If iniSab > 0 And iniDom > 0 Then
                If fila.Item("DÍA") = "Sábado   " Then
                    suma = iniSab - 1
                    final = suma
                    ini = 0
                End If

                If fila.Item("DÍA") = "Domingo  " Then
                    suma = iniSab + iniDom - 1
                    final = suma
                    ini = iniSab
                End If

                'Solo sábado
            ElseIf iniSab > 0 Then
                ini = 0
                final = iniSab - 1
                'Solo domingo
            ElseIf iniDom > 0 Then
                ini = 0
                final = iniDom - 1
            End If

            'Casos especiales
            Try
                '=== Caso especial para un dia en sábado y otro en domingo           1/nov/2021
                If iniSab = 1 And iniDom = 1 Then
                    If IsDBNull(TablaTemp.Rows(x).Item("ENTRADA/ SALIDA")) Or TablaTemp.Rows(x).Item("ENTRADA/ SALIDA").ToString.Trim.Length < 1 Then
                        If x + 1 < TablaTemp.Rows.Count Then
                            If diaPresente.Contains("Sábado") And TablaTemp.Rows(x + 1).Item("ENTRADA/ SALIDA").ToString.Trim = "S" And
                                TablaTemp.Rows(x + 1).Item("DÍA").ToString.Trim = "Domingo" Then
                                TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                                ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)
                            End If
                        End If
                        If diaPresente.Contains("Domingo") And TablaTemp.Rows(x - 1).Item("ENTRADA/ SALIDA").ToString.Trim = "E" And
                            TablaTemp.Rows(x - 1).Item("DÍA").ToString.Trim = "Sábado" Then
                            TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S"
                            ActualizaSabDom(0, varClock, "S", hora, fechaDia, diaPresente)
                        End If
                    End If
                End If
                '===

                If iniSab = 2 Or iniDom = 2 Then

                    Try
                        condicion1 = IIf(fila.Item("FECHA") = fila.Item("FECHA EFECTIVA"), True, False) And
                                     IIf(IsDBNull(fila.Item("ENTRADA/ SALIDA")), True, False)
                    Catch ex As Exception
                        '--Si hay valores nulos en la fecha efectiva, entonces la condicion es falsa        Abril 2021
                        condicion1 = False
                    End Try

                    'Para el primer registro
                    If lista.Item(ini) = x Then

                        '--Esto es para un caso especial. Ej. Si el primer registro de sabado no tiene ni fecha efectiva ni marca entrada o salida pero si tiene un registro de salida
                        '--el dia anterior que seria viernes, entonces corresponde una entrada en el primer registro    abril 2021
                        Dim condicion3 As Boolean

                        Try : condicion1 = condicion1 And IIf(TablaTemp.Rows(x - 1).Item("ENTRADA/ SALIDA") = "S", True, False) : Catch ex As Exception : condicion1 = False : End Try
                        '--Si hay valores nulos en la entrada y salida, entonces la condicion es falsa        Abril 2021
                        Try : condicion2 = IIf(TablaTemp.Rows(x + 1).Item("ENTRADA/ SALIDA") = "S", True, False) : Catch ex As Exception : condicion2 = False : End Try

                        '--- Si son falsas las primeras dos condiciones, entonces la tercer condicion debe ser true si hay registro de salida el dia anterior   Abril 2021
                        If condicion1 = False And condicion2 = False Then
                            Try : condicion3 = IIf(TablaTemp.Rows(x - 1).Item("ENTRADA/ SALIDA") = "S", True, False) : Catch ex As Exception : condicion3 = False : End Try
                        End If

                        If condicion1 Then
                            TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                            ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)
                        ElseIf condicion2 Then
                            TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                            ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)
                        ElseIf condicion3 Then      'Abril 2021
                            TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                            ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)
                        End If

                        '== CASO ESPECIAL: SI ES DOMINGO Y SI LA CHECADA ANTERIOR ES NULL Y ES SOLO UN REGISTRO, ENTONCES       abril 2021
                        '== SE AGREGO EL TRY CATCH              9/NOV/2021
                        Try
                            If diaPresente.Contains("Domingo") And (condicion1 And condicion2 And condicion3) = False Then
                                '== POR SI ACASO, CHECAR QUE AMBOS REGISTROS DE DOMINGO SEAN NULOS
                                If IsDBNull(TablaTemp.Rows(x).Item("ENTRADA/ SALIDA")) And IsDBNull(TablaTemp.Rows(x + 1).Item("ENTRADA/ SALIDA")) Then
                                    TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                                    ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)
                                End If
                            End If
                        Catch ex As Exception
                        End Try

                        '== CASO ESPECIAL: SI EL PRIMER SABADO CORRESPONDE A LA SALIDA DE UN VIERNES, SE VERIFICAN SUS FECHAS EFECTIVAS         9/nov/2021
                        Try
                            If diaPresente.Contains("Sábado") And TablaTemp.Rows(x - 1).Item("DÍA").ToString = diaPasado And
                             TablaTemp.Rows(x - 1).Item("FECHA EFECTIVA").ToString = TablaTemp.Rows(x).Item("FECHA EFECTIVA").ToString And
                             TablaTemp.Rows(x - 1).Item("ENTRADA/ SALIDA").ToString = "E" And TablaTemp.Rows(x).Item("FECHA EFECTIVA").ToString <> TablaTemp.Rows(x + 1).Item("FECHA EFECTIVA").ToString Then

                                TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S"
                                ActualizaSabDom(0, varClock, "S", hora, fechaDia, diaPresente)
                            End If
                        Catch ex As Exception
                        End Try

                        '== CASO ESPECIAL. SI EL DIA PASADO ES SABADO, PRESENTE DOMINGO, Y EL ANTERIOR TIENE UNA ENTRADA CON LA MISMA FECHA EFECTIVA QUE EL DIA PRESENTE
                        '== Y EL SIGUIENTE UNA FECHA EFECTIVA DISTINTA AL ACTUAL, ENTONCES ES UNA SALIDA            6/DIC/2021
                        Try
                            If TablaTemp.Rows(x - 1)("DÍA").ToString.Contains("Sábado") And diaPresente.Contains("Domingo") And TablaTemp.Rows(x - 1)("FECHA EFECTIVA") = TablaTemp.Rows(x)("FECHA EFECTIVA") And
                               TablaTemp.Rows(x)("FECHA EFECTIVA") <> TablaTemp.Rows(x + 1)("FECHA EFECTIVA") And TablaTemp.Rows(x - 1)("ENTRADA/ SALIDA") = "E" Then
                                TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S"
                                ActualizaSabDom(0, varClock, "S", hora, fechaDia, diaPresente)
                            End If
                        Catch ex As Exception

                        End Try

                    End If

                    'Para el ultimo registro
                    If lista.Item(final) = x Then
                        If diaPresente = "Sábado   " Then
                            Try : condicion1 = condicion1 And IIf(TablaTemp.Rows(x - 1).Item("ENTRADA/ SALIDA") = "E", True, False) : Catch ex As Exception : condicion1 = False : End Try

                            If iniDom > 0 Then
                                Try : condicion2 = IIf(TablaTemp.Rows(x + 1).Item("ENTRADA/ SALIDA") = "E", True, False) : Catch ex As Exception : condicion2 = False : End Try

                                '=====SE AGREGA LA SALIDA QUE LE CORRESPONDE A LA TABLA TEMPORAL            13SEP2021           ERNESTO
                                TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S"
                                '==

                                ActualizaSabDom(0, varClock, "S", hora, fechaDia, diaPresente)
                            Else
                                condicion2 = True
                            End If

                            If condicion1 Then
                                TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S"
                                ActualizaSabDom(0, varClock, "S", hora, fechaDia, diaPresente)
                            ElseIf condicion2 Then
                                TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S"
                                ActualizaSabDom(0, varClock, "S", hora, fechaDia, diaPresente)
                            End If

                            '== CASO ESPECIAL: SI LA SALIDA DEL REGISTRO ANTERIOR ES UN DIA SABADO CON FECHA EFECTIVA EL DIA PRESENTE, ENTONCES EL PRESENTE ES UNA ENTRADA
                            '= DE UN NUEVO DIA                  6/dic/2021

                            Try
                                If TablaTemp.Rows(x - 1).Item("DÍA").ToString.Contains("Sábado") And diaPresente.Contains("Sábado") And TablaTemp.Rows(x - 1)("ENTRADA/ SALIDA") = "S" And
                                    TablaTemp.Rows(x - 1)("FECHA EFECTIVA") <> TablaTemp.Rows(x)("FECHA EFECTIVA") And
                                    TablaTemp.Rows(x)("FECHA EFECTIVA") = TablaTemp.Rows(x + 1)("FECHA EFECTIVA") Then

                                    TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                                    ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)
                                End If
                            Catch ex As Exception

                            End Try

                            '== CASO ESPECIAL: SI LAS FECHAS EFECTIVAS DE SABADO Y DOMINGO SON CORRECTAS Y SOLO HAY UNA ENTRADA EN DOMINGO, ENTONCES
                            '== EL DIA PRESENTE (SABADO), EN CASO DE QUE SEA EL PRIMER REGISTRO DE FECHA EFVA, ES ENTRADA.             9/nov/2021          
                            If iniDom = 1 Then
                                Try
                                    If TablaTemp.Rows(x - 1).Item("FECHA EFECTIVA").ToString <> TablaTemp.Rows(x).Item("FECHA EFECTIVA").ToString And
                                        TablaTemp.Rows(x - 1)("ENTRADA/ SALIDA").ToString = "S" And
                                        TablaTemp.Rows(x).Item("FECHA EFECTIVA").ToString = TablaTemp.Rows(x + 1).Item("FECHA EFECTIVA").ToString Then

                                        TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                                        ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)
                                    End If
                                Catch ex As Exception
                                End Try
                            End If
                        End If

                        If diaPresente = "Domingo  " Then
                            '== TRY PARA LOS NULOS      abril 2021
                            Try : condicion1 = condicion1 And IIf(TablaTemp.Rows(x - 1).Item("ENTRADA/ SALIDA") = "E", True, False) : Catch ex As Exception : condicion1 = False : End Try
                            Try : condicion2 = IIf(TablaTemp.Rows(x - 1).Item("ENTRADA/ SALIDA") = "E", True, False) : Catch ex As Exception : condicion2 = False : End Try

                            If condicion1 Then
                                TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S"
                                ActualizaSabDom(0, varClock, "S", hora, fechaDia, diaPresente)
                            ElseIf condicion2 Then
                                TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S"
                                ActualizaSabDom(0, varClock, "S", hora, fechaDia, diaPresente)
                            End If

                            '==CASO ESPECIAL. Si la salida es en Lunes y la entrada en domingo.             22-nov-2021
                            If (TablaTemp.Rows(x - 1).Item("FECHA EFECTIVA").ToString <> TablaTemp.Rows(x).Item("FECHA EFECTIVA").ToString) Then
                                If (x < TablaTemp.Rows.Count - 1) Then
                                    If TablaTemp.Rows(x + 1).Item("DÍA").ToString.Contains("Lunes") And
                                        (TablaTemp.Rows(x).Item("FECHA EFECTIVA").ToString = TablaTemp.Rows(x + 1).Item("FECHA EFECTIVA").ToString) Then

                                        TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                                        ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)
                                    End If
                                End If
                            End If


                        End If
                    End If
                End If
            Catch ex As Exception : End Try


            If iniSab > 2 Or iniDom > 2 Then
                'Primer registro
                If lista.Item(ini) = x Then
                    If fila.Item("DÍA") = diaPresente Then
                        If fila.Item("FECHA") = fila.Item("FECHA EFECTIVA") Then
                            If IIf(IsDBNull(fila.Item("ENTRADA/ SALIDA")), True, False) Then

                                'Actualizar registros...
                                TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                                ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)

                            End If

                            '== CASO MEGAESPECIAL
                            '== Si es domingo y tiene marcado un entrada o salida incorrecta, y su fecha con su fecha efectiva coinciden, ademas de que el dia anterior es salida, entonces es una entrada
                            '== abril 2021      ernesto
                            If diaPresente.Contains("Domingo") And (TablaTemp.Rows(x - 1).Item("ENTRADA/ SALIDA") = "S" And TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S") Then

                                If TablaTemp.Rows(x - 1).Item("FECHA EFECTIVA") <> TablaTemp.Rows(x).Item("FECHA EFECTIVA") Then

                                    'Actualizar registros...
                                    TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                                    ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)

                                End If
                            End If
                            '======
                        ElseIf fila.Item("FECHA") <> fila.Item("FECHA EFECTIVA") Then

                            'Si no hay fecha efectiva ni marca de entrada o salida
                            If IIf(IsDBNull(fila.Item("FECHA EFECTIVA")), True, False) And IIf(IsDBNull(fila.Item("ENTRADA/ SALIDA")), True, False) Then

                                'Si es sábado el dia
                                If S = 1 Then
                                    'Si hay un dia anterior que no es viernes
                                    If TablaTemp.Rows(lista.Item(0) - 1).Item("DÍA") <> diaPasado Then

                                        'Actualizar registros...
                                        TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                                        ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)

                                        'Si hay una salida marcada el dia viernes
                                    ElseIf TablaTemp.Rows(lista.Item(0) - 1).Item("DÍA") = diaPasado And
                                        TablaTemp.Rows(lista.Item(0) - 1).Item("ENTRADA/ SALIDA") = "S" Then

                                        'Actualizar registros...
                                        TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                                        ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)

                                    End If
                                End If
                                'Si es domingo el dia
                                If D = 1 Then
                                    'Si hay un dia anterior que no es sábado
                                    If TablaTemp.Rows(lista.Item(0) - 1).Item("DÍA") <> diaPasado Then

                                        'Actualizar registros...
                                        TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                                        ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)

                                        'Si hay una salida marcada el dia sábado
                                    ElseIf TablaTemp.Rows(lista.Item(0) - 1).Item("DÍA") = diaPasado And
                                        TablaTemp.Rows(lista.Item(0) - 1).Item("ENTRADA/ SALIDA") = "S" Then

                                        'Actualizar registros...
                                        TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                                        ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)

                                    End If
                                End If
                            End If

                            'Siginifica que el registro en ese dia fue la salida del dia anterior
                            If fila.Item("ENTRADA/ SALIDA") = "S" And TablaTemp.Rows(x - 1).Item("DÍA") = diaPasado Then
                                salidaAnt = True
                            End If
                        End If
                    End If
                End If

                'Intermedio del bloque
                'Si solo hay un registro de sabado que corresponde a la salida del dia anterior
                Try
                    If iniSab = 1 And IIf(TablaTemp.Rows(x - 1).Item("ENTRADA/ SALIDA") = "S", True, False) And IIf(TablaTemp.Rows(x).Item("DÍA") = "Domingo  ", True, False) Then

                        'Por lo tanto, si hay registros de domingo, el primer registro correspondera a la entrada del mismo
                        If iniDom > 1 Then
                            salidaAnt = False
                        End If

                    End If
                Catch ex As Exception : End Try

                If x > lista.Item(ini) Then

                    'No toca el primer registro valido de la fecha efectiva que corresponde al día por ser correcto
                    If salidaAnt = False Then
                        'Actualizar registros...
                        TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = DBNull.Value
                        ActualizaSabDom(1, varClock, hora, fechaDia, diaPresente)
                    End If

                    Try
                        'Si tiene null en la primera entrada de registro con fecha efectiva de ese dia y el anterior tiene una salida
                        If IIf(IsDBNull(fila.Item("ENTRADA/ SALIDA")), True, False) And TablaTemp.Rows(x - 1).Item("ENTRADA/ SALIDA") = "S" And
                            TablaTemp.Rows(x - 1).Item("DÍA") = diaPresente And lista.Item(1) = x Then

                            TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                            ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)

                        End If
                    Catch ex As Exception : End Try

                    'Si tiene null en la primera entrada de registro con fecha efectiva de ese dia y marca una salida ese mismo dia con una fecha efectiva distinta
                    'para domingo
                    Try
                        If IIf(TablaTemp.Rows(x - 1).Item("ENTRADA/ SALIDA") = "S", True, False) And IIf(TablaTemp.Rows(x - 1).Item("DÍA") = "Domingo  ", True, False) And
                            lista.Item(ini) = x - 1 Then

                            TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                            ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)

                        End If
                    Catch ex As Exception : End Try


                    salidaAnt = False
                End If

                'Si falta la fecha efectiva, se completa el campo de entrada con un registro de domingo con salida
                If iniDom = 1 And x = lista.Item(final) Then
                    If TablaTemp.Rows(x + 1).Item("ENTRADA/ SALIDA") = "S" Then
                        Exit Sub
                    End If
                End If

                Try
                    'Final del bloque
                    If lista.Item(final) = x And fila.Item("FECHA") = fila.Item("FECHA EFECTIVA") Then
                        'Actualizar registros...
                        TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S"
                        ActualizaSabDom(0, varClock, "S", hora, fechaDia, diaPresente)
                    End If
                Catch ex As Exception : End Try

                'Caso especial
                If lista.Item(final) = x Then
                    TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S"
                    ActualizaSabDom(0, varClock, "S", hora, fechaDia, diaPresente)
                End If

                Try
                    'Si es el ultimo registro de sabado con fecha efectiva pero su salida la marca el siguiente dia, entonces es null
                    If diaPresente = "Sábado   " And IIf(TablaTemp.Rows(x + 1).Item("ENTRADA/ SALIDA") = "S", True, False) And
                        IIf(TablaTemp.Rows(x + 1).Item("DÍA") = "Domingo  ", True, False) Then

                        TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = DBNull.Value
                        ActualizaSabDom(1, varClock, hora, fechaDia, diaPresente)

                        '== Caso ultra especial: Si el siguiente dia es domingo, y tiene su fecha efectiva que coincide con su fecha normal, pero marca erroneamente la marca de entrada o salida
                        '== entonces este sera el ultimo registro de sabado     ABRIL 2021

                        '-- Si el registro actual es null
                        If IsDBNull(TablaTemp.Rows(x).Item("ENTRADA/ SALIDA")) And (TablaTemp.Rows(x + 1).Item("FECHA") = TablaTemp.Rows(x + 1).Item("FECHA EFECTIVA")) Then

                            Dim fecha_caso As String = ""
                            fecha_caso = CStr(fila.Item("FECHA EFECTIVA"))

                            '-- Si su fecha efectiva coicide con su fecha normal
                            If fecha_caso <> "Null" Then
                                TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S"
                                ActualizaSabDom(0, varClock, "S", hora, fechaDia, diaPresente)
                            End If

                        End If

                    End If
                Catch ex As Exception : End Try

                '== 25ene2022
                '== Caso especial
                Try
                    If diaPresente.Contains("Sábado") And IsDBNull(TablaTemp.Rows(x)("entrada/ salida")) And TablaTemp.Rows(x - 1)("entrada/ salida") = "S" And
                        (TablaTemp.Rows(x)("fecha efectiva") = TablaTemp.Rows(x)("fecha")) And TablaTemp.Rows(x + 1)("entrada/ salida") = "S" And
                        TablaTemp.Rows(x + 1)("DÍA").ToString.Trim = "Domingo" Then

                        TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                        ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)
                    End If
                Catch ex As Exception : End Try

                '==25ene2022
                '== Caso especial
                Try
                    If diaPresente.Contains("Sábado") And TablaTemp.Rows(x - 1)("entrada/ salida") = "S" And (TablaTemp.Rows(x)("fecha efectiva") = TablaTemp.Rows(x)("fecha")) And
                        (TablaTemp.Rows(x)("fecha efectiva") <> TablaTemp.Rows(x - 1)("fecha efectiva")) And iniSab = 1 Then
                        TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "E"
                        ActualizaSabDom(0, varClock, "E", hora, fechaDia, diaPresente)
                    End If
                Catch ex As Exception : End Try

                '==25ene2022
                '== Caso especial
                Try
                    If diaPresente.Contains("Domingo") And TablaTemp.Rows(x - 1)("entrada/ salida") = "E" And (TablaTemp.Rows(x)("fecha efectiva") = TablaTemp.Rows(x - 1)("fecha efectiva")) And
                        iniSab = 1 And (TablaTemp.Rows(x)("fecha efectiva") <> TablaTemp.Rows(x + 1)("fecha efectiva")) Then

                        TablaTemp.Rows(x).Item("ENTRADA/ SALIDA") = "S"
                        ActualizaSabDom(0, varClock, "S", hora, fechaDia, diaPresente)
                    End If
                Catch ex As Exception : End Try

            End If
            TablaTemporal = TablaTemp
        Catch ex As Exception : End Try

    End Sub

    'ACTUALIZAR LA TABLA HRS_BRT PARA SABADOS Y DOMINGOS
    Public Sub ActualizaSabDom(opcion As Integer, clock As String, Optional param1 As String = "", Optional param2 As String = "", Optional param3 As String = "",
                                Optional param4 As String = "")

        Dim query As String

        Try
            Select Case opcion
                Case 0
                    query = "UPDATE hrs_brt set ENTRADA_SALIDA = '" & param1 & "' WHERE reloj = '" & clock & "' AND HORA = '" & param2 & _
                                        "' AND FECHA = '" & param3 & "' AND DIA = '" & param4 & "'"
                    sqlExecute(query, "TA")
                Case 1
                    query = "UPDATE hrs_brt set ENTRADA_SALIDA = null WHERE reloj = '" & clock & "' AND HORA = '" & param1 & _
                    "' AND FECHA = '" & param2 & "' AND DIA = '" & param3 & "'"
                    sqlExecute(query, "TA")
            End Select
        Catch ex As Exception : End Try

    End Sub
    '--------------------------------------------------------


    Private Sub ButtonX3_Click_1(sender As Object, e As EventArgs)

        Dim FIni As Date = Now
        Dim FFin As Date = Now

        Try
            '********** ANALISIS CAFETERIA, VALIDAR A DONDE SE MOVERA
            Dim _cadena As String = ""
            Dim dtEmpleados As DataTable

            Dim dtper As DataTable

            dtper = sqlExecute("SELECT fecha_ini,fecha_fin,activo FROM periodos WHERE ano = '" & cmbPeriodos.SelectedValue.ToString.Substring(0, 4) & _
                                    "' AND periodo = '" & cmbPeriodos.SelectedValue.ToString.Substring(4, 2) & "'", "TA")
            FIni = dtper.Rows(0).Item("fecha_ini")
            FFin = dtper.Rows(0).Item("fecha_fin")

            Acumulado = FiltrosAcumulados()
            _cadena = "SELECT reloj,nombres,alta,baja,gafete,personalvw.cod_planta,personalvw.cod_comp,cod_depto,cod_puesto,cod_tipo,cod_super,cod_turno,cod_hora,checa_tarjeta," & _
                "personalvw.cod_clase FROM personalvw "
            If chkIndividual.Checked Then
                _cadena = _cadena & " WHERE reloj = '" & txtReloj.Text & "'"
            Else
                _cadena = _cadena & IIf(Acumulado.Length > 0, " WHERE 1=1 " & Acumulado, "")
            End If

            ' Filtrar activos a la fecha final
            _cadena = _cadena & IIf(_cadena.Contains("WHERE"), " AND ", " WHERE ") & " (baja IS NULL OR baja >= '" & FechaSQL(FIni) & "')"
            dtEmpleados = ConsultaPersonalVW(_cadena, False)

            If dtEmpleados.Rows.Count <= 0 Then
                MessageBox.Show("No se localizaron empleados para analizar", "Análisis", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            Dim i As Integer = 0
            frmTrabajando.Text = "Análisis de cafetería"
            frmTrabajando.Show()

            For Each drEmpleado As DataRow In dtEmpleados.Rows
                i += 1
                frmTrabajando.Avance.Value = i
                Dim f As Date = FIni
                While f <= FFin
                    analisis_cafeteria(drEmpleado("reloj"), f)
                    frmTrabajando.lblAvance.Text = drEmpleado("reloj")
                    Application.DoEvents()
                    f = f.AddDays(1)
                End While
            Next

            ActivoTrabajando = False
            frmTrabajando.Close()

        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
        End Try

        dtCafeteria = sqlExecute("select Id_registro as Registro, Reloj, Fecha, Hora, horario as Servicio, horarios_cafeteria.nombre as 'Nombre Servicio', subsidio as Subsidio, subsidio_cafeteria.nombre_subsidio as 'Tipo de Descuento' from hrs_brt_cafeteria left join horarios_cafeteria on hrs_brt_cafeteria.horario = horarios_cafeteria.cod_hora_cafe left join subsidio_cafeteria on subsidio_cafeteria.cod_subsidio = hrs_brt_cafeteria.subsidio where reloj = '" & txtReloj.Text & "' and fecha between '" & FechaHoraSQL(FIni) & "' AND '" & FechaHoraSQL(FIni.AddDays(6)) & "' order by fecha, hora, id_registro", "TA")
        dgvCafeteria.DataSource = dtCafeteria
        dgvCafeteria.Columns("Registro").ReadOnly = True
        dgvCafeteria.Columns("Reloj").ReadOnly = True
        dgvCafeteria.Columns("Fecha").ReadOnly = True
        dgvCafeteria.Columns("Servicio").ReadOnly = True
        dgvCafeteria.Columns("Nombre Servicio").ReadOnly = True
        dgvCafeteria.Columns("Subsidio").ReadOnly = True
        dgvCafeteria.Columns("Tipo de Descuento").ReadOnly = True


        dgvCafeteria.AllowUserToAddRows = False
        dgvCafeteria.AllowUserToOrderColumns = False
        dgvCafeteria.AllowUserToResizeColumns = False
        dgvCafeteria.AllowUserToResizeRows = False

        dgvCafeteria.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)

        dgvCafeteria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCafeteria.Columns(dgvCafeteria.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub


    Private Sub ButtonX4_Click(sender As Object, e As EventArgs)
        Try
            Dim frm As New frmAnalisisIndependiente
            frm.txtReloj.Text = txtReloj.Text
            frm.ShowDialog()
            MostrarInformacion(txtReloj.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgHorasBruto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgHorasBruto.CellContentClick

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Dim HExtras As String
            Dim i As Integer
            Dim Tm As TimeSpan
            Dim F As Date
            Dim HE As String
            Dim HS As String

            Dim R As String

            i = dgAsist.SelectedCells(0).RowIndex
            HExtras = dgAsist.Item("HRS_EXT", i).Value.ToString.Trim
            F = dgAsist.Item("FECHA_ENTRADA", i).Value
            HE = dgAsist.Item("ENTRADA", i).Value
            HS = dgAsist.Item("SALIDA", i).Value
            Tm = TimeSpan.Parse(HExtras)
            R = txtReloj.Text

            dtTemporal = sqlExecute("SELECT reloj FROM extras_autorizadas WHERE reloj = '" & txtReloj.Text & "' AND fecha = '" & FechaSQL(F) & "'", "TA")

            If dtTemporal.Rows.Count = 0 Then
                sqlExecute("INSERT INTO extras_autorizadas (reloj,fecha) VALUES ('" & txtReloj.Text & "','" & FechaSQL(F) & "')", "ta")
            End If

            dtTemporal = sqlExecute("SELECT cod_depto FROM asist WHERE reloj = '" & R & _
                                  "' AND fecha_entro = '" & FechaSQL(F) & "' AND entro = '" & HE & "'", "TA")
            If dtTemporal.Rows.Count > 0 Then
                sqlExecute("UPDATE extras_autorizadas SET cod_depto = '" & dtTemporal.Rows(0).Item("COD_DEPTO") & "'," & _
                           "depto_transferencia = '" & dtTemporal.Rows(0).Item("COD_DEPTO") & "' " & _
                           "WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(F) & "'", "TA")
            End If

            'De momento, no se requiere autorización de gerente. Aprobar todo si el supervisor lo captura 
            'De momento, no se requiere autorización de director. Aprobar todo si el supervisor lo captura  
            sqlExecute("UPDATE extras_autorizadas SET " & _
                       "entrada = '" & HE & "', " & _
                       "salida = '" & HS & "', " & _
                       "extras_reales = '" & HExtras & "', " & _
                       "extras_autorizadas = 'R-30', " & _
                       "periodo = '" & cmbPeriodos.SelectedValue.ToString.Substring(4, 2) & "', " & _
                       "ano = '" & cmbPeriodos.SelectedValue.ToString.Substring(0, 4) & "', " & _
                       "usuario_s = '" & Usuario & "', " & _
                       "fecha_s = '" & FechaSQL(Now.Date) & "', " & _
                       "envio_s = 1, " & _
                       "usuario_a1 = '" & Usuario & "', " & _
                       "fecha_a1 = '" & FechaSQL(Now.Date) & "', " & _
                       "autori_a1 = 1 , " & _
                       "envio_a1 = 1,aplicado = 1,analizado = 0, " & _
                       "usuario_a2 = '" & Usuario & "', " & _
                       "fecha_a2 = '" & FechaSQL(Now.Date) & "', " & _
                       "autori_a2 = 1 , " & _
                       "envio_a2 = 1 " & _
                       "WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(F) & "'", "TA")
            ReEvaluar(R, F)
            ActualizaInformacionTA()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtHorario_TextChanged(sender As Object, e As EventArgs) Handles lblHorarios.DoubleClick
        Try
            Dim frm As New frmConsultaHorarios
            frm.cod_hora = txtHorario.Text.Substring(0, 3)
            frm.periodoactivo = cmbPeriodos.SelectedValue
            frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX3_Click_2(sender As Object, e As EventArgs) Handles ButtonX3.Click

        Dim dtEmpleados As New DataTable
        Dim dtHorarios As New DataTable
        Dim dtErrores As New DataTable
        Dim SemanaCompleta As Boolean
        Dim i As Double
        Dim _cadena As String

        Dim _reloj_analisis As String

        Dim _periodo As String
        Dim _comentario_criterio_de_evaluacion As String = ""
        Dim _descanso As Boolean = False
        Dim _festivo As Boolean = False
        Dim _abierto As Boolean = False

        Dim _seg_horas_ex As Integer = 0
        Dim _comentario As String = ""
        Dim tm As DateTime = Now
        Dim FIni As Date = Now
        Dim FFin As Date = Now
        Dim dtPer As DataTable

        Try

            If chkGlobal.Checked Then
                If MessageBox.Show("¿Está seguro de querer analizar a todos los empleados seleccionados?", "Análisis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            End If

            dtErrores.Columns.Add("DESCRIPCION")
            SemanaCompleta = chkSemana.Checked
            'Inhabilitar la forma actual, para evitar el usuario presione otra opción mientras se está evaluando
            tpBarra.Enabled = False
            tbInfo.Enabled = False
            Panel1.Enabled = False
            'Abrir forma para mostrar progress bar
            frmTrabajando.Text = "Análisis T&A"
            frmTrabajando.Show(Me)
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Text = "Analizando..."
            frmTrabajando.Avance.IsRunning = True
            Application.DoEvents()

            'Cambiar el cursor a "Modo de espera", para avisar al usuario que está corriendo un proceso
            Me.Cursor = Cursors.WaitCursor

            _reloj_analisis = txtReloj.Text
            _pri_ent_ult_sal = IIf(chkPEUS.Checked, 1, 0)
            _periodo = cmbPeriodos.SelectedValue

            'Formar la cadena de búsqueda, dependiendo de si el análisis es individual o global
            Acumulado = FiltrosAcumulados()
            _cadena = "SELECT reloj,nombres,alta,baja,gafete,personalvw.cod_planta,personalvw.cod_comp,cod_depto,cod_puesto,cod_tipo,cod_super,cod_turno,cod_hora,checa_tarjeta," & _
                "personalvw.cod_clase FROM personalvw "
            If chkIndividual.Checked Then
                _cadena = _cadena & " WHERE reloj = '" & _reloj_analisis & "'"
            Else
                _cadena = _cadena & IIf(Acumulado.Length > 0, " WHERE 1=1 " & Acumulado, "")
            End If

            ' Filtrar activos a la fecha final
            _cadena = _cadena & IIf(_cadena.Contains("WHERE"), " AND ", " WHERE ") & " (baja IS NULL OR baja >= '" & FechaSQL(FechaIni) & "')"
            dtEmpleados = ConsultaPersonalVW(_cadena, False)

            If dtEmpleados.Rows.Count <= 0 Then
                MessageBox.Show("No se localizaron empleados para analizar", "Análisis", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            frmTrabajando.Avance.Maximum = dtEmpleados.Rows.Count
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = True
            i = 0

            dtPer = sqlExecute("SELECT fecha_ini,fecha_fin,activo FROM periodos WHERE ano = '" & cmbPeriodos.SelectedValue.ToString.Substring(0, 4) & _
                                "' AND periodo = '" & cmbPeriodos.SelectedValue.ToString.Substring(4, 2) & "'", "TA")
            FIni = dtPer.Rows(0).Item("fecha_ini")
            FFin = dtPer.Rows(0).Item("fecha_fin")


            i = 0

            Dim t As Double = dtEmpleados.Rows.Count
            For Each drEmpleado As DataRow In dtEmpleados.Rows
                i += 1

                frmTrabajando.lblAvance.Text = (Math.Round(i / t * 100, 2)) & "%"

                Application.DoEvents()
                If ActivoTrabajando Then
                    Try
                        If chkSemana.Checked = True Then
                            Dim dtPeriodos As DataTable = sqlExecute("select * from periodos where '" & FechaSQL(FechaIni) & "' between fecha_ini and fecha_fin and periodo_especial = 0", "ta")
                            If dtPeriodos.Rows.Count > 0 Then
                                Dim f_ini As Date = dtPeriodos.Rows(0)("fecha_ini")
                                Dim f_fin As Date = dtPeriodos.Rows(0)("fecha_fin")
                                While f_ini <= f_fin
                                    analisis_cafeteria(drEmpleado("reloj"), f_ini)
                                    f_ini = f_ini.AddDays(1)
                                End While
                            End If
                        Else
                            analisis_cafeteria(drEmpleado("reloj"), FechaIni)
                        End If


                    Catch ex As Exception

                    End Try
                End If
            Next


            Dim Errores As String = ""
            If dtErrores.Rows.Count > 0 Then
                For Each dr As DataRow In dtErrores.Rows
                    Errores = Errores & IIf(Errores.Length > 0, vbCrLf, "") & dr("descripcion").ToString.Trim
                Next

                Err.Raise(-1, Nothing, Errores)
            End If
        Catch ex As Exception
            frmTrabajando.Hide()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se encontraron errores durante el análisis. Favor de verificar." & vbCrLf & vbCrLf & "Error.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tpBarra.Enabled = True
            tbInfo.Enabled = True
            Panel1.Enabled = True
            Me.Cursor = Cursors.Default
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            ActualizaInformacionTA()
            chkIndividual.Checked = True

        End Try
    End Sub

    Delegate Sub SetColumnIndex(ByVal i As Integer)
    Dim id_registro_cafeteria As String
    Private Sub dgvCafeteria_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvCafeteria.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo
            ht = Me.dgvCafeteria.HitTest(e.X, e.Y)
            'If BorrarCafeteria Then
            If ht.Type = DataGridViewHitTestType.Cell Then
                If ht.ColumnIndex.ToString = "6" Then
                    dgvCafeteria.ContextMenuStrip = mnuCell
                    id_registro_cafeteria = dgvCafeteria.Rows(ht.RowIndex).Cells(0).Value
                    '  dgvCafeteria.ContextMenuStrip.Visible = True
                    'mnuCell.Items(0).Text = String.Format("This is the cell at {0}, {1}", ht.ColumnIndex, ht.RowIndex)\
                Else
                    dgvCafeteria.ContextMenuStrip = Nothing
                End If
            End If
            'End If
        End If
    End Sub

    Private Sub mnuCell_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles mnuCell.ItemClicked
        Dim opcion As String = e.ClickedItem.ToString
        If opcion.ToUpper = "CANCELAR" Then
            Dim result As Integer = MessageBox.Show("Esta por cancelar un registro de cafetería, desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                sqlExecute("update hrs_brt_cafeteria set subsidio = 'B' where id_registro = '" & id_registro_cafeteria & "'", "TA")
                dgvCafeteria.ContextMenuStrip = Nothing
                BorrarCafeteria = False
                Reloj = txtReloj.Text
                dtPersonal = ConsultaPersonalVW("SELECT * FROM personalvw WHERE reloj ='" & Reloj & "' " & Acumulado & " ORDER BY reloj ASC", False)
                MostrarInformacion(txtReloj.Text.Trim)

                Editar = False
                CambiaHoras = False
                HabilitarBotones()
            End If
        End If


    End Sub

    Private Sub txtDiasPagoNomina_ValueChanged(sender As Object, e As EventArgs) Handles txtDiasPagoNomina.ValueChanged
        CambiaHoras = Editar
    End Sub
End Class


