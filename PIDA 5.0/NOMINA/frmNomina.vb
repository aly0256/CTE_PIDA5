Imports System.Drawing.Printing
Imports System.IO

Public Class frmNomina

    ' Tablas
    Dim dtperiodos As New DataTable
    Dim dtNomina As New DataTable
    Dim dtconceptos As New DataTable
    Dim dtmovimientos As New DataTable
    Dim Seleccionado As String
    Dim dtTemp As New DataTable
    Dim Cargando As Boolean = True
    Dim dtPeriodi1 As New DataTable
    Dim tipo_per As String = ""
    Dim ultimo_per As String = ""
    Dim cambio_op As Boolean
    Dim per_emp As String = ""

    Private Sub frmNomina_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtTemp As New DataTable
        Try
            dtPeriodi1 = sqlExecute("Select tipo_periodo, nombre from tipo_periodo", "personal")
            cmbTipoPer.DataSource = dtPeriodi1


            '== COMENTADO               18nov2021
            'Dim tempreloj As DataTable = sqlExecute("select top 1 * from personal where cod_tipo = 'O' and baja is null order by reloj asc")
            'dtTemporal = sqlExecute("SELECT TOP 1 ano+periodo as 'seleccionado' FROM nomina WHERE periodo<='55' ORDER BY ano DESC, periodo DESC", "nomina")
            '==

            '== NUEVO                   18nov2021
            Dim tempreloj As DataTable = sqlExecute("select top 1 RELOJ,(case when tipo_periodo='S' THEN 'SEMANAL' ELSE 'CATORCENAL' end) AS tipo_periodo " & _
                                                                                      "from personal.dbo.personal where cod_tipo = 'O' and baja is null order by reloj asc")
            dtTemporal = sqlExecute("select top 1 ano+periodo as 'seleccionado' from ta.dbo.periodos where isnull(asentado,0)=1 and isnull(PERIODO_ESPECIAL,0)=0 order by ano desc,periodo desc")
            '==

            If dtTemporal.Rows.Count > 0 Then
                comboPeriodos()
                cmbPeriodos.SelectedValue = dtTemporal.Rows(0).Item("seleccionado")
                Seleccionado = dtTemporal.Rows(0).Item("seleccionado")
            Else
                cmbPeriodos.SelectedIndex = 0
                Seleccionado = Nothing
            End If
            Cargando = False
            MostrarInformacion(tempreloj.Rows(0).Item("reloj"))
        Catch ex As Exception
            Stop
        End Try
    End Sub

    Public Sub MostrarInformacion(Optional ByVal reloj As String = "")
        Dim dRow As DataRow
        Dim Per As Double, Ded As Double
        Dim infoPersonal As Boolean

        Try
            'Si no hay periodo seleccionado, salir del procedimiento
            If Seleccionado = Nothing Then Exit Sub

            'Buscar el reloj indicado, para el periodo seleccionado
            dtNomina = sqlExecute("SELECT TOP 1 nomina.*,nombre_tipoemp,nombre_depto,nombre_super,nombre_clase,nombre_turno,nombre_horario,foto" & _
                           " FROM nomina left join personal.dbo.personalvw on nomina.reloj=personalvw.reloj WHERE nomina.reloj = '" & reloj & "' AND ano+periodo='" & Seleccionado & "'", "Nomina")

            '==MODIFICADO. SI NO HAY REGISTROS ENTONCES SOLO TOMAR LA INFO PERSONAL DEL EMPLEADO                 18Nov2021
            'Si no encontró registros que cumplan el periodo y reloj, buscar el primero del periodo
            If dtNomina.Rows.Count = 0 Then
                dtNomina = sqlExecute("SELECT TOP 1 nomina.*,nombre_tipoemp,nombre_depto,nombre_super,nombre_clase,nombre_turno,nombre_horario,foto" & _
               " FROM nomina left join personal.dbo.personalvw on nomina.reloj=personalvw.reloj WHERE nomina.reloj='" & reloj & "' ORDER BY reloj", "Nomina")
                infoPersonal = True
            End If

            per_emp = dtNomina.Rows(0)("tipo_periodo").ToString.Trim

            'Si aún no hay registros, mostrar anuncio, y salir del procedimiento
            If dtNomina.Rows.Count = 0 Then
                Exit Sub
            End If

            reloj = IIf(IsDBNull(dtNomina.Rows.Item(0).Item("reloj")), "", dtNomina.Rows.Item(0).Item("reloj"))
            dRow = dtNomina.Rows(0)

            'Mostrar información
            txtReloj.Text = reloj
            txtNombre.Text = IIf(IsDBNull(dRow("nombres")), "", dRow("nombres"))

            txtAlta.Text = IIf(IsDBNull(dRow("alta")), Nothing, dRow("alta"))
            EsBaja = Not IsDBNull(dRow("baja"))
            txtBaja.Text = IIf(EsBaja, dRow("baja"), Nothing)

            txtTipoEmp.Text = IIf(IsDBNull(dRow("cod_tipo")), "", dRow("cod_tipo").ToString.Trim) & IIf(IsDBNull(dRow("nombre_tipoemp")), "", " (" & dRow("nombre_tipoemp").ToString.Trim & ")")
            txtDepto.Text = IIf(IsDBNull(dRow("cod_depto")), "", dRow("cod_depto").ToString.Trim) & IIf(IsDBNull(dRow("nombre_depto")), "", " (" & dRow("nombre_depto").ToString.Trim & ")")
            txtSupervisor.Text = IIf(IsDBNull(dRow("cod_super")), "", dRow("cod_super").ToString.Trim) & IIf(IsDBNull(dRow("nombre_super")), "", " (" & dRow("nombre_super").ToString.Trim & ")")
            txtClase.Text = IIf(IsDBNull(dRow("cod_clase")), "", dRow("cod_clase").ToString.Trim) & IIf(IsDBNull(dRow("nombre_clase")), "", " (" & dRow("nombre_clase").ToString.Trim & ")")
            txtTurno.Text = IIf(IsDBNull(dRow("cod_turno")), "", dRow("cod_turno").ToString.Trim) & IIf(IsDBNull(dRow("nombre_turno")), "", " (" & dRow("nombre_turno").ToString.Trim & ")")
            txtHorario.Text = IIf(IsDBNull(dRow("cod_hora")), "", dRow("cod_hora").ToString.Trim) & IIf(IsDBNull(dRow("nombre_horario")), "", " (" & dRow("nombre_horario").ToString.Trim & ")")

            'txtNormales.Text = IIf(IsDBNull(dRow("horas_normales")), 0, dRow("horas_normales"))
            'txtDobles.Text = IIf(IsDBNull(dRow("horas_dobles")), 0, dRow("horas_dobles"))
            'txtTriples.Text = IIf(IsDBNull(dRow("horas_triples")), 0, dRow("horas_triples"))
            'txtFestivas.Text = IIf(IsDBNull(dRow("horas_festivas")), 0, dRow("horas_festivas"))
            'txtDomingo.Text = IIf(IsDBNull(dRow("horas_domingo")), 0, dRow("horas_domingo"))
            'txtDescanso.Text = IIf(IsDBNull(dRow("horas_descanso")), 0, dRow("horas_descanso"))
            'txtVac.Text = IIf(IsDBNull(dRow("dias_vac")), 0, dRow("dias_vac"))
            'txtAgui.Text = IIf(IsDBNull(dRow("dias_agui")), 0, dRow("dias_agui"))

            ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
            Try
                picFoto.Width = picFoto.MinimumSize.Width
                picFoto.Height = picFoto.MinimumSize.Height
                picFoto.Left = 900
                'picFoto.Image = ft
                picFoto.ImageLocation = dRow("foto").ToString.Trim
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
            '*************************

            '== SI SOLO HAY INFORMACION PERSONAL, NO LLENAR DATAGRIDVIEW                18Nov2021
            If Not infoPersonal Then
                dtmovimientos = sqlExecute("SELECT movimientos.concepto,nombre as descripcion,monto,cod_naturaleza,movimientos.PRIORIDAD, case when cod_naturaleza = 'P' then 1 else case when cod_naturaleza = 'D' then 2 else case when cod_naturaleza = 'E' then 4 else case when cod_naturaleza = 'I' then 5 else case when cod_naturaleza = 'T' then 3 end end end end end as orden  " & _
           "FROM movimientos LEFT JOIN conceptos ON conceptos.concepto=movimientos.concepto " & _
           "WHERE reloj='" & reloj & "' AND ano ='" & Seleccionado.Substring(0, 4) & "' AND periodo='" & Seleccionado.Substring(4, 2) & _
           "' AND cod_naturaleza IN ('P','D','A','E','I','T') ", "Nomina")
                '"ORDER BY conceptos.prioridad,movimientos.concepto", "Nomina")
                dgMovimientos.AutoGenerateColumns = False
                dgMovimientos.DataSource = dtmovimientos.Select("", "orden asc,prioridad asc").CopyToDataTable
                Per = TotalPercepciones(reloj, Seleccionado)
                Ded = TotalDeducciones(reloj, Seleccionado)
                'txtPer.Text = FormatCurrency(Per, 2)
                'txtDed.Text = FormatCurrency(Ded, 2)
                'txtNeto.Text = FormatCurrency(Per - Ded, 2)
            Else
                dtmovimientos.Rows.Clear()
                dgMovimientos.AutoGenerateColumns = False
                dgMovimientos.DataSource = dtmovimientos
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            'Stop
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Try
            dtTemp = sqlExecute("SELECT TOP 1 reloj FROM nomina where ano+periodo='" & Seleccionado & "' and tipo_periodo ='" & tipo_per & "' ORDER BY reloj ASC ", "Nomina")
            If dtTemp.Rows.Count <> 0 Then
                MostrarInformacion(dtTemp.Rows(0).Item("reloj"))
            Else
                MessageBox.Show("No hay datos de nómina para el periodo seleccionado.", "Periodo " & Seleccionado, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            Stop
        End Try
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Try
            dtTemp = sqlExecute("SELECT TOP 1 reloj FROM nomina where ano+periodo='" & Seleccionado & "' and tipo_periodo ='" & tipo_per & "' ORDER BY reloj DESC ", "Nomina")
            If dtTemp.Rows.Count <> 0 Then
                MostrarInformacion(dtTemp.Rows(0).Item("reloj"))
            Else
                MessageBox.Show("No hay datos de nómina para el periodo seleccionado.", "Periodo " & Seleccionado, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            Stop
        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        dtTemp = sqlExecute("SELECT TOP 1 reloj FROM nomina where reloj < '" & txtReloj.Text & "' AND ano+periodo='" & Seleccionado & "' and tipo_periodo ='" & tipo_per & "' ORDER BY reloj DESC ", "Nomina")
        If dtTemp.Rows.Count = 0 Then
            btnFirst.PerformClick()
        Else
            MostrarInformacion(dtTemp.Rows(0).Item("reloj"))
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        dtTemp = sqlExecute("SELECT TOP 1 reloj FROM nomina where reloj > '" & txtReloj.Text & "' AND ano+periodo='" & Seleccionado & "' and tipo_periodo ='" & tipo_per & "' ORDER BY reloj ASC ", "Nomina")
        If dtTemp.Rows.Count = 0 Then
            btnLast.PerformClick()
        Else
            MostrarInformacion(dtTemp.Rows(0).Item("reloj"))
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtTemp = dtNomina
        Try
            Dim joel1 As String = Reloj
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj)
                cmbTipoPer.SelectedValue = per_emp
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtNomina = dtTemp
        End Try
    End Sub

    Private Sub dgMovimientos_Paint(sender As Object, e As PaintEventArgs)
        Dim y As Integer
        Dim BColor As System.Drawing.Color
        For y = 0 To dgMovimientos.RowCount - 1

            If dgMovimientos.Item("cod_naturaleza", y).Value.ToString.Trim = "P" Then
                BColor = Color.LightGreen
            ElseIf dgMovimientos.Item("cod_naturaleza", y).Value.ToString.Trim = "D" Then
                BColor = Color.LightYellow
            ElseIf dgMovimientos.Item("cod_naturaleza", y).Value.ToString.Trim = "E" Then
                BColor = Color.White
            ElseIf dgMovimientos.Item("cod_naturaleza", y).Value.ToString.Trim = "I" Then
                BColor = Color.White
            ElseIf dgMovimientos.Item("concepto", y).Value.ToString.Trim = "NETO" Then
                BColor = Color.FromArgb(221, 111, 0)
            ElseIf dgMovimientos.Item("cod_naturaleza", y).Value.ToString.Trim = "T" Then
                BColor = Color.LightPink
            Else
                BColor = Color.White
            End If

            dgMovimientos.Item("concepto", y).Style.BackColor = BColor
            dgMovimientos.Item("monto", y).Style.BackColor = BColor
            dgMovimientos.Item("descripcion", y).Style.BackColor = BColor
        Next
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            If dgMovimientos.Rows.Count > 0 Then
                Dim dtResultado As New DataTable
                Dim P, J As String
                J = cmbTipoPer.SelectedValue
                P = cmbPeriodos.SelectedValue
                dtResultado = sqlExecute("EXEC ReporteadorNominaTipoPeriodo @Cia = '" & CiaReporteador & "',@ano = '" & P.Substring(0, 4) & "', @periodo = '" & P.Substring(4, 2) & _
                                                 "',@Nivel = '" & NivelConsulta & "', @reloj = '" & txtReloj.Text & "', @TipoPeriodo = '" & J & "'", "nomina")
                generar_recibos(dtResultado)
            Else
                MessageBox.Show("No hay registros en nómina", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmbPeriodos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPeriodos.SelectedValueChanged
        If Not Cargando Then
            Seleccionado = cmbPeriodos.SelectedValue
            If cambio_op Then Seleccionado = UltimoPeriodo(tipo_per)
            MostrarInformacion(txtReloj.Text)
        End If
    End Sub

    Private Sub btnTotales_Click(sender As Object, e As EventArgs) Handles btnTotales.Click
        Dim dtNomina As New DataTable

        'dtNomina = sqlExecute("SELECT DISTINCT ano,periodo FROM nomina ORDER BY ano DESC,periodo DESC", "nomina")
        dtNomina = sqlExecute("SELECT DISTINCT ano,periodo FROM nomina WHERE periodo<'53' AND ano = '2014' ORDER BY ano DESC,periodo DESC", "nomina")
        For Each dRow As DataRow In dtNomina.Rows
            txtNombre.Text = dRow("ano") & dRow("periodo")
            My.Application.DoEvents()
            CalculaNetos(dRow("ano"), dRow("periodo"))
        Next
    End Sub

    Private Sub CalculaNetos(ByVal _ano As String, ByVal _periodo As String)
        Dim _monto As Double = 0
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim P As Integer
        Dim Cadena As String = ""
        Dim dtNom As New DataTable
        Dim TotPer As Double = 0
        Dim TotDed As Double = 0
        Dim dtTemp As New DataTable
        Try

            dtTemp = sqlExecute("SELECT concepto FROM conceptos WHERE concepto = 'TOTPER'", "nomina")
            If dtTemp.Rows.Count = 0 Then
                sqlExecute("INSERT INTO conceptos (cod_naturaleza,concepto,nombre,suma_neto,positivo,activo) VALUES (" & _
                           "'I','TOTPER','Total de percepciones',0,1,0)", "nomina")
            End If

            dtTemp = sqlExecute("SELECT concepto FROM conceptos WHERE concepto = 'TOTDED'", "nomina")
            If dtTemp.Rows.Count = 0 Then
                sqlExecute("INSERT INTO conceptos (cod_naturaleza,concepto,nombre,suma_neto,positivo,activo) VALUES (" & _
                           "'I','TOTDED','Total de deducciones',0,0,0)", "nomina")
            End If

            dtTemp = sqlExecute("SELECT concepto FROM conceptos WHERE concepto = 'NETO'", "nomina")
            If dtTemp.Rows.Count = 0 Then
                sqlExecute("INSERT INTO conceptos (cod_naturaleza,concepto,nombre,suma_neto,positivo,activo) VALUES (" & _
                           "'I','NETO','Neto',0,1,0)", "nomina")
            End If


            'Empleados en nómina, que no tengan NETO en movimientos
            dtNom = sqlExecute("SELECT reloj,cod_tipo_nomina FROM nomina WHERE nomina.ano = '" & _ano & "' AND nomina.periodo = '" & _periodo & "'" & _
                               "AND reloj NOT IN (SELECT reloj FROM movimientos WHERE concepto IN('NETO','TOTPER','TOTDED') AND ano = '" & _ano & "' " & _
                               "AND periodo = '" & _periodo & "' AND reloj = nomina.reloj)", "nomina")

            'Calcular netos, e insertarlos en movimientos
            y = dtNom.Rows.Count
            x = 0
            For Each dRow In dtNom.Rows
                x = x + 1
                P = (x / y) * 100
                My.Application.DoEvents()

                TotPer = TotalPercepciones(dRow("reloj"), _ano & _periodo)
                TotDed = TotalDeducciones(dRow("reloj"), _ano & _periodo)
                _monto = TotPer - TotDed
                If TotPer <> 0 Or TotDed <> 0 Then
                    dtTemporal = sqlExecute("SELECT reloj FROM movimientos WHERE reloj = '" & dRow("reloj") & "' AND ano = '" & _ano & _
                                        "' AND periodo = '" & _periodo & "'" & " AND  concepto = 'NETO'", "nomina")
                    If dtTemporal.Rows.Count = 0 Then
                        Cadena = "INSERT INTO movimientos (ano,periodo,tipo_nomina,reloj,concepto,monto) VALUES ('"
                        Cadena = Cadena & _ano & "','" & _periodo & "', '" & dRow("cod_tipo_nomina") & "','" & dRow("reloj") & "','NETO'," & _monto & ")"
                        sqlExecute(Cadena, "nomina")
                    End If
                End If

                dtTemporal = sqlExecute("SELECT reloj FROM movimientos WHERE reloj = '" & dRow("reloj") & "' AND ano = '" & _ano & _
                                        "' AND periodo = '" & _periodo & "'" & " AND  concepto = 'TOTPER'", "nomina")
                If dtTemporal.Rows.Count = 0 And TotPer <> 0 Then
                    Cadena = "INSERT INTO movimientos (ano,periodo,tipo_nomina,reloj,concepto,monto) VALUES ('"
                    Cadena = Cadena & _ano & "','" & _periodo & "', '" & dRow("cod_tipo_nomina") & "','" & dRow("reloj") & "','TOTPER'," & TotPer & ")"
                    sqlExecute(Cadena, "nomina")
                End If

                dtTemporal = sqlExecute("SELECT reloj FROM movimientos WHERE reloj = '" & dRow("reloj") & "' AND ano = '" & _ano & _
                        "' AND periodo = '" & _periodo & "'" & " AND  concepto = 'TOTDED'", "nomina")
                If dtTemporal.Rows.Count = 0 And TotDed <> 0 Then
                    Cadena = "INSERT INTO movimientos (ano,periodo,tipo_nomina,reloj,concepto,monto) VALUES ('"
                    Cadena = Cadena & _ano & "','" & _periodo & "', '" & dRow("cod_tipo_nomina") & "','" & dRow("reloj") & "','TOTDED'," & TotDed & ")"
                    sqlExecute(Cadena, "nomina")
                End If

            Next dRow

        Catch ex As Exception
            Stop
        End Try
    End Sub

    Private Sub dgMovimientos_Paint1(sender As Object, e As PaintEventArgs) Handles dgMovimientos.Paint
        Dim y As Integer
        Dim BColor As System.Drawing.Color
        For y = 0 To dgMovimientos.RowCount - 1

            If dgMovimientos.Item("cod_naturaleza", y).Value.ToString.Trim = "P" Then
                BColor = Color.LightGreen
            ElseIf dgMovimientos.Item("cod_naturaleza", y).Value.ToString.Trim = "D" Then
                BColor = Color.LightYellow
            ElseIf dgMovimientos.Item("cod_naturaleza", y).Value.ToString.Trim = "E" Then
                BColor = Color.White
            ElseIf dgMovimientos.Item("cod_naturaleza", y).Value.ToString.Trim = "I" Then
                BColor = Color.White
            ElseIf dgMovimientos.Item("concepto", y).Value.ToString.Trim = "NETO" Then
                BColor = Color.FromArgb(221, 111, 0)
            ElseIf dgMovimientos.Item("cod_naturaleza", y).Value.ToString.Trim = "T" Then
                BColor = Color.LightPink
            Else
                BColor = Color.White
            End If

            dgMovimientos.Item("concepto", y).Style.BackColor = BColor
            dgMovimientos.Item("monto", y).Style.BackColor = BColor
            dgMovimientos.Item("descripcion", y).Style.BackColor = BColor
        Next
    End Sub

    Private Function UltimoPeriodo(ByRef per As String) As String
        Try
            Dim dtTabla As New DataTable
            Select Case per
                Case "S"
                    dtTabla = sqlExecute("select top 1 ano+periodo as 'seleccionado' from ta.dbo.periodos where isnull(asentado,0)=1 and isnull(PERIODO_ESPECIAL,0)=0 order by ano desc,periodo desc")
                Case "C"
                    dtTabla = sqlExecute("select top 1 ano+periodo as 'seleccionado' from ta.dbo.periodos_catorcenal where isnull(asentado,0)=1 and isnull(PERIODO_ESPECIAL,0)=0 order by ano desc,periodo desc")
            End Select
            If dtTabla.Rows.Count > 0 Then
                cmbPeriodos.SelectedValue = dtTabla.Rows(0).Item("seleccionado")
                Return dtTabla.Rows(0)("seleccionado").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub comboPeriodos(Optional ByRef dtEmp As DataTable = Nothing)
        Try
            If cmbTipoPer.SelectedValue = "S" Then
                dtperiodos = sqlExecute("SELECT distinct periodos.ano+periodos.periodo AS seleccionado, periodos.ano,periodos.periodo,fecha_ini,fecha_fin,periodos.nombre " & _
                                    "FROM ta.dbo.periodos LEFT JOIN nomina.dbo.nomina ON nomina.ano = periodos.ano AND nomina.periodo = periodos.periodo " & _
                                    "ORDER BY ano desc,periodo", "ta")
                dtEmp = sqlExecute("select top 1 RELOJ,(case when tipo_periodo='S' THEN 'SEMANAL' ELSE 'CATORCENAL' end) AS tipo_periodo " & _
                                                    "from personal.dbo.personal where tipo_periodo = 'S' and baja is null order by reloj asc")
                tipo_per = "S"

                '== SE AGREGO PERIODO CATORCENAL                18nov2021
            ElseIf cmbTipoPer.SelectedValue = "C" Then
                dtperiodos = sqlExecute("SELECT distinct periodos_catorcenal.ano+periodos_catorcenal.periodo AS seleccionado, periodos_catorcenal.ano,periodos_catorcenal.periodo,fecha_ini,fecha_fin,periodos_catorcenal.nombre " & _
                                    "FROM ta.dbo.periodos_catorcenal LEFT JOIN nomina.dbo.nomina ON nomina.ano = periodos_catorcenal.ano AND nomina.periodo = periodos_catorcenal.periodo " & _
                                    "ORDER BY ano desc,periodo", "ta")
                dtEmp = sqlExecute("select top 1 RELOJ,(case when tipo_periodo='S' THEN 'SEMANAL' ELSE 'CATORCENAL' end) AS tipo_periodo " & _
                                                    "from personal.dbo.personal where tipo_periodo = 'C' and baja is null order by reloj asc")
                tipo_per = "C"

            ElseIf cmbTipoPer.SelectedValue = "Q" Then
                dtperiodos = sqlExecute("SELECT distinct periodos_quincenal.ano+periodos_quincenal.periodo AS seleccionado, periodos_quincenal.ano,periodos_quincenal.periodo,fecha_ini,fecha_fin,periodos_quincenal.nombre " & _
                                    "FROM ta.dbo.periodos_quincenal LEFT JOIN nomina.dbo.nomina ON nomina.ano = periodos_quincenal.ano AND nomina.periodo = periodos_quincenal.periodo " & _
                                    "ORDER BY ano desc,periodo", "ta")
                'dtEmp = sqlExecute("select top 1 RELOJ,(case when tipo_periodo='S' THEN 'SEMANAL' ELSE 'QUINCENAL' end) AS tipo_periodo " & _
                '                                    "from personal.dbo.personal where tipo_periodo = 'Q' and baja is null order by reloj asc")
                'tipo_per = "Q"

            ElseIf cmbTipoPer.SelectedValue = "M" Then
                dtperiodos = sqlExecute("SELECT distinct periodos_mensual.ano+periodos_mensual.periodo AS seleccionado, periodos_mensual.ano,periodos_mensual.periodo,fecha_ini,fecha_fin,periodos_mensual.nombre " & _
                                    "FROM ta.dbo.periodos_mensual LEFT JOIN nomina.dbo.nomina ON nomina.ano = periodos_mensual.ano AND nomina.periodo = periodos_mensual.periodo " & _
                                    "ORDER BY ano desc,periodo", "ta")
                'dtEmp = sqlExecute("select top 1 RELOJ,(case when tipo_periodo='S' THEN 'SEMANAL' ELSE 'MENSUAL' end) AS tipo_periodo " & _
                '                                    "from personal.dbo.personal where tipo_periodo = 'M' and baja is null order by reloj asc")
                'tipo_per = "M"

            End If
            cmbPeriodos.DataSource = dtperiodos
            cambio_op = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbTipoPer_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoPer.SelectedValueChanged
        Try
            Dim dtEmp As New DataTable
            Dim relojEmp As String = ""

            If Not Cargando Then
                cambio_op = True
                comboPeriodos(dtEmp)
                relojEmp = dtEmp.Rows(0)("reloj").ToString.Trim
                MostrarInformacion(relojEmp)
            End If

        Catch ex As Exception
        End Try
    End Sub

End Class