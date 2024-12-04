Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Reporting.WinForms

Public Class frmHorasMasivas

    Dim IniciaLunes As Boolean
    Dim Semana As DetalleSemana

    Dim drHorarios() As DataRow
    Dim drHorario As DataRow

    Dim AutorizarExtra As Boolean

    Dim FiltroExtras As String = ""
    Dim FiltroExtrasAutorizadas As String = ""

    Dim FEntradaReal As Date
    Dim FSalidaReal As Date

    Dim _anoPeriodo As String = ""
    Dim _anoNomSem As String = ""
    Dim _periodoNomSem As String = ""

    Dim dtHorasPorAplicar As New DataTable

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            LabelStatus.Text = "Estatus: Aplicando registros"
            Cursor = Cursors.WaitCursor
            Application.DoEvents()

            btnAceptar.Enabled = False
            btnCancelar.Enabled = False
            btnBuscaArchivo.Enabled = False
            DateTimeInput1.Enabled = False

            Dim total As Integer = dtHorasPorAplicar.Rows.Count
            Dim actual As Integer = 0
            Dim validos As Integer = 0

            If dtHorasPorAplicar.Rows.Count > 0 Then

                For Each row As DataRow In dtHorasPorAplicar.Rows

                    actual += 1

                    If row("valida") = 1 Then
                        Dim dtExiste As DataTable = sqlExecute("select * from hrs_brt where reloj = '" & row("reloj") & "' and fecha = '" & row("fecha") & "' and hora = '" & row("hora") & "' ", "ta")
                        If dtExiste.Rows.Count <= 0 Then
                            sqlExecute("insert into hrs_brt (reloj, fecha, hora, tipo_tran) values ('" & row("reloj") & "', '" & row("fecha") & "', '" & row("hora") & "', 'A')", "ta")
                            AnalizarTA(row("reloj"), row("fecha"))

                            LabelStatus.Text = "Estatus: Analizando registros " & actual & " de " & total
                            Application.DoEvents()

                            validos += 1

                        End If
                    End If
                Next
            End If

            LabelStatus.Text = "Estatus: -"
            Cursor = Cursors.Default
            Application.DoEvents()

            btnAceptar.Enabled = True
            btnCancelar.Enabled = True
            btnBuscaArchivo.Enabled = True
            DateTimeInput1.Enabled = True

            MessageBox.Show("Se aplicaron " & validos & " registros validos de " & total & " registros totales", "Registros aplicados")

        Catch ex As Exception
            LabelStatus.Text = "Estatus: -"
            Cursor = Cursors.Default
            Application.DoEvents()

            btnAceptar.Enabled = True
            btnCancelar.Enabled = True
            btnBuscaArchivo.Enabled = True
            DateTimeInput1.Enabled = True

        End Try
    End Sub

    Private Sub btnBuscaArchivo_Click(sender As Object, e As EventArgs) Handles btnBuscaArchivo.Click
        Dim ofd As New OpenFileDialog        
        ofd.Multiselect = False
        ofd.Filter = "Listas de horas |*.xls;*.xlsx|Archivos excel|*.xls;*.xlsx"

        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtArchivo.Text = ofd.FileName

            AnalizarArchivo()
        Else

        End If
    End Sub

    Private Sub DateTimeInput1_Click(sender As Object, e As EventArgs) Handles DateTimeInput1.ValueChanged
        AnalizarArchivo()
    End Sub

    Private Sub frmHorasMasivas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimeInput1.Value = Now.Date
        DataGridViewX1.AutoGenerateColumns = False
    End Sub

    Private Sub AnalizarArchivo()
        Try

            LabelStatus.Text = "Estatus: Analizando archivo ... "
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()

            btnAceptar.Enabled = False
            btnCancelar.Enabled = False
            btnBuscaArchivo.Enabled = False
            DateTimeInput1.Enabled = False

            dtHorasPorAplicar = New DataTable
            dtHorasPorAplicar.Columns.Add("reloj", Type.GetType("System.String"))
            dtHorasPorAplicar.Columns.Add("nombres", Type.GetType("System.String"))
            dtHorasPorAplicar.Columns.Add("cod_depto", Type.GetType("System.String"))
            dtHorasPorAplicar.Columns.Add("cod_hora", Type.GetType("System.String"))
            dtHorasPorAplicar.Columns.Add("fecha", Type.GetType("System.String"))
            dtHorasPorAplicar.Columns.Add("hora", Type.GetType("System.String"))
            dtHorasPorAplicar.Columns.Add("valida", Type.GetType("System.Int32"))
            dtHorasPorAplicar.Columns.Add("comentario", Type.GetType("System.String"))

            DataGridViewX1.Columns("ColumnReloj").CellTemplate.Style.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
            DataGridViewX1.Columns("ColumnFecha").CellTemplate.Style.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
            DataGridViewX1.Columns("ColumnHora").CellTemplate.Style.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)


            Dim xlApp As New Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim arRango(,) As String
            Dim x As Integer
            Dim y As Integer

            Dim no_validos As Integer = 0
            Dim validos As Integer = 0

            If txtArchivo.Text.Trim <> "" Then
                Try
                    xlApp.Workbooks.Open(txtArchivo.Text.Trim)
                    xlWorkBook = xlApp.ActiveWorkbook

                    Dim lastrow As Excel.Range = xlApp.Rows.End(Excel.XlDirection.xlDown)
                    Dim myRange As Excel.Range
                    myRange = xlApp.Range("A1:B" & lastrow.Row)

                    Dim myArray As Object(,)
                    myArray = myRange.Value

                    'El arreglo myRange es a partir de 1, 
                    'el arreglo myArray, inicia en 0
                    If myArray(1, 1).ToString.ToLower = "reloj" Then
                        'Si tiene encabezado, reducir 1 por la diferencia, más el del encabezado
                        y = 2
                    Else
                        'Si no hay encabezado, solo reducir 1
                        y = 1
                    End If

                    ReDim arRango(2, lastrow.Row - y)

                    no_validos = 0
                    validos = 0

                    For x = y To lastrow.Row

                        Try
                            Dim dr As DataRow = dtHorasPorAplicar.NewRow

                            Dim reloj_row As String = myArray(x, 1)

                            reloj_row = reloj_row.PadLeft(LongReloj, "0")

                            dr("reloj") = reloj_row

                            Try
                                Dim dtPersonal As DataTable = sqlExecute("select * from personalvw where reloj = '" & reloj_row & "'")
                                If dtPersonal.Rows.Count > 0 Then

                                    dr("valida") = 1
                                    validos += 1

                                    Dim alta As Date = dtPersonal.Rows(0)("alta")
                                    If alta <= DateTimeInput1.Value.Date Then
                                        dr("valida") = 1
                                    Else
                                        dr("valida") = 0
                                        no_validos += 1
                                        validos -= 1
                                        dr("comentario") = "Fecha anterior al alta"
                                    End If

                                    If dr("valida") = 1 Then
                                        If IsDBNull(dtPersonal.Rows(0)("baja")) Then
                                            dr("valida") = 1
                                        Else
                                            Dim baja As Date = dtPersonal.Rows(0)("baja")

                                            If baja > DateTimeInput1.Value.Date Then
                                                dr("valida") = 1
                                            Else
                                                dr("valida") = 0
                                                no_validos += 1
                                                validos -= 1

                                                dr("comentario") = "Fecha posterior a la baja"
                                            End If

                                        End If

                                    End If


                                    dr("nombres") = dtPersonal.Rows(0)("nombres")
                                    dr("cod_depto") = ValorBitacora(reloj_row, "cod_depto", DateTimeInput1.Value)
                                    dr("cod_hora") = ValorBitacora(reloj_row, "cod_hora", DateTimeInput1.Value)

                                Else
                                    dr("nombres") = ""
                                    dr("cod_depto") = "NA"
                                    dr("cod_hora") = "NA"
                                    dr("valida") = 0

                                    no_validos += 1                                    

                                    dr("comentario") = "Empleado no existe"
                                End If

                            Catch ex As Exception

                            End Try

                            dr("fecha") = FechaSQL(DateTimeInput1.Value)
                            dr("hora") = CtoHSimpleAbraham(myArray(x, 2))
                            dtHorasPorAplicar.Rows.Add(dr)

                        Catch ex As Exception

                        End Try

                    Next

                    xlWorkBook.Close()
                    xlApp.Quit()

                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)

                    DataGridViewX1.DataSource = dtHorasPorAplicar

                    For Each row As DataGridViewRow In DataGridViewX1.Rows
                        If row.Cells("ColumnComentario").Value.ToString.Trim <> "" Then
                            row.DefaultCellStyle.BackColor = Color.LightCoral
                            'row.DefaultCellStyle.BackColor = Color.LightCoral
                        End If
                    Next

                    

                Catch ex As Exception

                    btnAceptar.Enabled = True
                    btnCancelar.Enabled = True
                    btnBuscaArchivo.Enabled = True
                    DateTimeInput1.Enabled = True

                    LabelStatus.Text = "Estatus: -"
                    Cursor = Cursors.Default
                    Application.DoEvents()

                End Try
            End If

            btnAceptar.Enabled = True
            btnCancelar.Enabled = True
            btnBuscaArchivo.Enabled = True
            DateTimeInput1.Enabled = True

            LabelStatus.Text = "Estatus: " & no_validos & " registros no válidos, " & validos & " registros válidos"
            
            Cursor = Cursors.Default
            Application.DoEvents()

        Catch ex As Exception
            btnAceptar.Enabled = True
            btnCancelar.Enabled = True
            btnBuscaArchivo.Enabled = True
            DateTimeInput1.Enabled = True

            LabelStatus.Text = "Estatus: -"
            Cursor = Cursors.Default
            Application.DoEvents()

        End Try
    End Sub

    Public Function CtoHSimpleAbraham(_hora As String) As String
        Dim _tamano As Integer, _pos As Integer
        Dim _horas As String, _minutos As String
        Try
            If _hora.Contains("*") Then
                _hora = "**:**"
                Return _hora
            End If
            _tamano = _hora.Trim.Length
            _hora = _hora.Replace(".", ":")
            _pos = _hora.IndexOf(":")
            If _pos >= 0 Then
                _horas = _hora.Substring(0, _pos)
                _minutos = _hora.Substring(_pos + 1, _tamano - _horas.Length - 1).PadRight(2, "0")
            Else
                _minutos = "0"
                _horas = _hora
            End If
            _horas = CDbl(IIf(_horas = "", "0", _horas))
            _minutos = CDbl(IIf(_minutos = "", "0", _minutos))

            If _horas >= 24 Or _minutos >= 60 Then
                _hora = "**:**"
            ElseIf Not IsNumeric(_horas) Or Not IsNumeric(_minutos) Then
                _hora = "**:**"
            Else
                _hora = _horas.Trim.PadLeft(2, "0") & ":" & _minutos.Trim.PadLeft(2, "0")
            End If
            Return _hora

        Catch ex As Exception
            Return "**:**"
        End Try
    End Function


    

    Public Sub AnalizarTA(_reloj_analisis As String, _fecha_analisis As Date)

        Dim dtAnoPeriodo As DataTable = sqlExecute("select ano + periodo as anoperiodo, isnull(activo, 0) as activo from periodos where '" & FechaSQL(_fecha_analisis) & "' between fecha_ini and fecha_fin and periodo_especial = '0'", "TA")
        If dtAnoPeriodo.Rows.Count > 0 Then
            _anoPeriodo = dtAnoPeriodo.Rows(0)("anoperiodo")
            _anoNomSem = _anoPeriodo.Substring(0, 4)
            _periodoNomSem = _anoPeriodo.Substring(4, 2)

        End If


        Dim dtTemp As New DataTable
        Dim dtCiasTA As New DataTable
        Dim _aus_natural As String = ""
        Dim AnalizarES As Boolean = True

        dtCiasTA = sqlExecute("SELECT ausentismo,inicia_sem,analizar_entrada_salida FROM parametros")
        If dtCiasTA.Rows.Count = 0 Then
            MessageBox.Show("Es necesario capturar <PARAMETROS>.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Application.DoEvents()
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

        Dim dtEmpleados As New DataTable
        Dim dtHorarios As New DataTable
        Dim dtErrores As New DataTable
        Dim SemanaCompleta As Boolean

        Dim i As Integer
        '        Dim _cadena As String
        Dim _cod_comp As String
        Dim _cod_tipo As String
        Dim _cod_turno As String
        Dim _cod_hora As String
        Dim _gafete As String
        Dim _alta As Date
        Dim _baja As Date
        Dim DiaSemana As Integer

        'Dim _reloj_analisis As String

        'Dim _fecha_analisis As Date

        Dim _comentario_criterio_de_evaluacion As String = ""
        Dim _descanso As Boolean = False
        Dim _festivo As Boolean = False
        Dim _abierto As Boolean = False
        Dim _checa_tarjeta As Boolean

        Dim _seg_horas_ex As Integer = 0
        Dim _comentario As String = ""
        Dim tm As DateTime = Now
        Dim FIni As Date = Now
        Dim FFin As Date = Now
        Dim dtPer As DataTable
        Dim Alta As Date

        Try

            dtErrores.Columns.Add("DESCRIPCION")

            dtEmpleados = sqlExecute("select * from personal where reloj = '" & _reloj_analisis & "'")


            dtPer = sqlExecute("SELECT * FROM periodos WHERE periodo_especial = '0' and '" & FechaSQL(_fecha_analisis) & "' between fecha_ini and fecha_fin ", "TA")
            FIni = dtPer.Rows(0).Item("fecha_ini")
            FFin = dtPer.Rows(0).Item("fecha_fin")

            ' Evaluar cada empleado seleccionado
            For Each drEmpleado As DataRow In dtEmpleados.Rows
                i += 1
                'frmTrabajando.Avance.Value = i

                'frmTrabajando.lblAvance.Text = drEmpleado("reloj")
                'Application.DoEvents()
                Dim cod_hora As String = "", cod_turno As String = "" ' AOS 2022-02-10
                If True Then
                    'MCR 12/OCT/2015
                    'Si seleccionan revisar bitácora, regresar los campos al último día del periodo anterior
                    ConsultaBitacora(dtEmpleados, drEmpleado, FFin)
                    cod_turno = ConsultaBitacoraHorarios(dtEmpleados, drEmpleado, FFin, "cod_turno") ' AOS 2022-02-10
                    cod_hora = ConsultaBitacoraHorarios(dtEmpleados, drEmpleado, FFin, "cod_hora") ' AOS 2022-02-10
                End If
                drEmpleado("cod_hora") = cod_hora ' AOS 2022-02-10
                drEmpleado("cod_turno") = cod_turno ' AOS 2022-02-10
                Alta = drEmpleado("alta")

                'Correr el ciclo en el rango de fechas seleccionadas
                'Si se seleccionó un solo día, FechaIni = FechaFin

                Semana = SemanaHorarioMixto(_anoPeriodo, _reloj_analisis)
                dtHorarios = sqlExecute("SELECT horarios.*,dias.* " & _
                                        "FROM horarios LEFT JOIN dias ON horarios.cod_hora = dias.cod_hora AND horarios.cod_comp = dias.cod_comp " & _
                                        "WHERE horarios.cod_comp = '" & drEmpleado("cod_comp") & "' AND horarios.cod_hora = '" & drEmpleado("cod_hora") & _
                                        "' AND semana = " & Semana.NumSemana)

                If dtHorarios.Rows.Count = 0 Then
                    Err.Raise(-1, Nothing, "No se encontró registro del horario " & drEmpleado("cod_hora"))
                End If

                '**************BERE
                'Dim dtalta As DataTable

                If Alta >= FIni And Alta <= FFin Then
                    If Not Festivo(Alta, _reloj_analisis) Then

                        DiaSemana = Weekday(Alta, IIf(IniciaLunes, FirstDayOfWeek.Monday, FirstDayOfWeek.Sunday))
                        'Tomar información de horarios y días

                        drHorarios = dtHorarios.Select("cod_dia = " & DiaSemana)

                        If drHorarios.Count > 0 Then
                            drHorario = drHorarios(0)
                        Else
                            dtErrores.Rows.Add({"Falta horario " & IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora")) & " del empleado " & drEmpleado("reloj")})
                            Continue For
                        End If

                        CorrigeTransaccion(drEmpleado, Alta, _anoPeriodo, "S")
                    End If

                    If Not Festivo(Alta.AddDays(1), _reloj_analisis) Then
                        DiaSemana = Weekday(Alta.AddDays(1), IIf(IniciaLunes, FirstDayOfWeek.Monday, FirstDayOfWeek.Sunday))
                        'Tomar información de horarios y días

                        drHorarios = dtHorarios.Select("cod_dia = " & DiaSemana)
                        If drHorarios.Count > 0 Then
                            drHorario = drHorarios(0)
                        Else
                            dtErrores.Rows.Add({"Falta horario " & IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora")) & " del empleado " & drEmpleado("reloj")})
                            Continue For
                        End If
                        CorrigeTransaccion(drEmpleado, Alta.AddDays(1), _anoPeriodo, "S")
                    End If
                End If

                _reloj_analisis = drEmpleado("reloj")

                'Variables por usuario
                _cod_comp = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp")).ToString.Trim
                _cod_tipo = IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo")).ToString.Trim
                _cod_turno = IIf(IsDBNull(drEmpleado("cod_turno")), "", drEmpleado("cod_turno")).ToString.Trim

                _cod_hora = IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora")).ToString.Trim

                _gafete = IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("reloj"), drEmpleado("gafete"))
                _alta = drEmpleado("alta")
                'Si la fecha de baja está en blanco, poner una fecha muuuy adelante, para que siempre sea mayor que la fecha a revisar
                _baja = IIf(IsDBNull(drEmpleado("baja")), DateSerial(2100, 1, 1), drEmpleado("baja"))
                _checa_tarjeta = IIf(IsDBNull(drEmpleado("checa_tarjeta")), True, drEmpleado("checa_tarjeta"))


                'Revisar si la transacción está cerrada
                dtTemp = sqlExecute("SELECT tran_cerrada FROM nomsem WHERE reloj = '" & drEmpleado("reloj") & "' AND ano + periodo = '" & _anoPeriodo & "'", "TA")
                If dtTemp.Rows.Count > 0 Then
                    'Si el registro se localiza en NomSem, y está registrado como transacción cerrada, regresa al siguiente registro del FOR
                    If IIf(IsDBNull(dtTemp.Rows(0).Item("tran_cerrada")), 0, dtTemp.Rows(0).Item("tran_cerrada")) = 1 Then
                        Continue For
                    End If
                End If

                'Correr el ciclo en el rango de fechas seleccionadas
                'Si se seleccionó un solo día, FechaIni = FechaFin
                Semana = SemanaHorarioMixto(_anoPeriodo, _reloj_analisis)
                dtHorarios = sqlExecute("SELECT horarios.*,dias.* " & _
                                        "FROM horarios LEFT JOIN dias ON horarios.cod_hora = dias.cod_hora AND horarios.cod_comp = dias.cod_comp " & _
                                        "WHERE horarios.cod_comp = '" & _cod_comp & "' AND horarios.cod_hora = '" & _cod_hora & _
                                        "' AND semana = " & Semana.NumSemana)

                If dtHorarios.Rows.Count = 0 Then
                    Err.Raise(-1, Nothing, "No se encontró registro del horario " & _cod_hora)
                End If

                Dim _fecha_original As Date = _fecha_analisis

                If False Then
                Else
                    Do While _fecha_analisis <= _fecha_original
                        'Si la pantalla de frmTrabajando fue cerrada, cancelar procedimiento
                        'If Not ActivoTrabajando Then Exit For

                        DiaSemana = Weekday(_fecha_analisis, IIf(IniciaLunes, FirstDayOfWeek.Monday, FirstDayOfWeek.Sunday))
                        'Tomar información de horarios y días

                        drHorarios = dtHorarios.Select("cod_dia = " & DiaSemana)

                        If drHorarios.Count > 0 Then
                            drHorario = drHorarios(0)
                        Else
                            dtErrores.Rows.Add({"Falta horario " & IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora")) & " del empleado " & drEmpleado("reloj")})
                            Continue For
                        End If

                        If Not SemanaCompleta Then
                            'Borrar datos de asist que pudiera haber de esta fecha
                            sqlExecute("DELETE FROM asist WHERE RELOJ ='" & _reloj_analisis & "' AND fha_ent_hor ='" & _
                                       FechaSQL(_fecha_analisis) & "'", "TA")
                            'Borrar fecha efectiva del hrs_brt, que pudiera haber quedado de evaluaciones anteriores
                            sqlExecute("UPDATE hrs_brt SET fecha_efva = NULL WHERE RELOJ ='" & _reloj_analisis & "' AND fecha_efva = '" & FechaSQL(_fecha_analisis) & "'", "TA")
                        End If

                        'Analizar solo si estuvo activo en el periodo
                        If _fecha_analisis >= _alta And _fecha_analisis <= _baja Then
                            'Analizar horas en bruto, para asignar entradas y salidas
                            If drHorario("descanso") Then
                                'Día de descanso analizar tipo forzar pares
                                AnalisisHrsBrtPares(drEmpleado, _anoPeriodo.Substring(0, 4), _anoPeriodo.Substring(4, 2), _fecha_analisis, _fecha_analisis)
                            Else
                                AnalisisHrsBrt(drEmpleado, _fecha_analisis, _anoPeriodo.Substring(4, 2), _anoPeriodo.Substring(0, 4))

                            End If
                            My.Application.DoEvents()
                            'Evaluar las horas en bruto, para llenar el asist
                            Evaluador(drEmpleado, _fecha_analisis, _anoPeriodo.Substring(4, 2), _anoPeriodo.Substring(0, 4))
                        End If
                        'Incrementar la fecha en 1 día
                        _fecha_analisis = DateAdd(DateInterval.Day, 1, _fecha_analisis)
                    Loop
                End If

                'Llenar tabla de NomSem, para el periodo
                LlenaNomSem(drEmpleado, _anoPeriodo)
            Next

            Dim Errores As String = ""
            If dtErrores.Rows.Count > 0 Then
                For Each dr As DataRow In dtErrores.Rows
                    Errores = Errores & IIf(Errores.Length > 0, vbCrLf, "") & dr("descripcion").ToString.Trim
                Next

                Err.Raise(-1, Nothing, Errores)
            End If
        Catch ex As Exception
            'frmTrabajando.Hide()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "AnalisisTA", ex.HResult, ex.Message)
            MessageBox.Show("Se encontraron errores durante el análisis. Favor de verificar." & vbCrLf & vbCrLf & "Error.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.DoEvents()
        Finally
         
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

        Dim dtTemp As DataTable

        Try
            R = drEmpleado("reloj")
            Comp = drEmpleado("cod_comp")
            fAlta = drEmpleado("alta")
            fBaja = IIf(IsDBNull(drEmpleado("baja")), DateSerial(2100, 1, 1), drEmpleado("baja"))
            Preus = False

            Entrada = drHorario("entra")
            Salida = drHorario("sale")
            Dif = IIf(drHorario("dia_ent") <> drHorario("dia_sal"), 1, 0)
            FechaSalida = DateAdd(DateInterval.Day, Dif, Fecha)
            Descanso = DiaDescanso(Fecha, R)


            If Not Descanso And Fecha >= fAlta And Fecha <= fBaja And Not Festivo(Fecha, R) Then
                dtTemp = sqlExecute("SELECT entro,salio FROM asist WHERE reloj = '" & R & "' AND fha_ent_hor = '" & FechaSQL(Fecha) & "'", "TA")
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
                                  "(reloj,fecha,tipo_aus,fecha_movimiento,usuario_movimiento,valor_anterior,notas) " & _
                               "SELECT reloj,fecha,tipo_aus,GETDATE(),'" & Usuario & _
                               "','/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/','" & _
                               System.Reflection.MethodBase.GetCurrentMethod.Name() & "' FROM ausentismo WHERE reloj = '" & R & _
                               "' AND fecha ='" & FechaSQL(Fecha) & _
                               "' AND tipo_aus NOT IN ('FI','FES','FI')", "TA")


                    'Borrar ausentismo (si hay) del tipo natural - falta injustificada -
                    sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & R & "' AND fecha ='" & FechaSQL(Fecha) & _
                               "' AND tipo_aus NOT IN ('FI','FES','FI')", "TA")

                    'Revisar si hay otro tipo de ausentismo registrado para ese día.
                    dtTemp = sqlExecute("SELECT tipo_aus FROM ausentismo " & _
                                        "WHERE tipo_aus NOT IN ('FI','FES','FI') AND reloj = '" & R & _
                                        "' AND (fecha = '" & FechaSQL(Fecha) & "' OR  fecha = '" & FechaSQL(FechaSalida) & "')", "TA")
                    If dtTemp.Rows.Count > 0 Then
                        'Solo corrige la transacción si no hay ausentismo capturado en este día
                        'Poner ambas banderas en falso, para que no inserte las transacciones
                        FaltaEntrada = False
                        FaltaSalida = False
                    End If
                End If

                'Si falta la entrada, insertarla de acuerdo al horario
                If FaltaEntrada Then
                    dtTemp = sqlExecute("SELECT reloj FROM hrs_brt WHERE fecha = '" & FechaSQL(Fecha) & "' AND hora = '" & MerMilitar(drHorario("entra")) & _
                                        "' AND reloj = '" & drEmpleado("reloj") & "' ", "TA")
                    If dtTemp.Rows.Count = 0 Then
                        sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,dia,periodo,tipo_tran,pareja,preus,ano,faltaba_tran) VALUES ('" & _
                                   Comp & "','" & R & "','" & IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("reloj"), drEmpleado("gafete")) & "','" & _
                                   FechaSQL(Fecha) & "','" & MerMilitar(drHorario("entra")) & "','" & DiaSem(Fecha) & "','" & Periodo.Substring(4, 2) & "','" & _
                                   TipoTransaccion & "',1," & IIf(Preus, 1, 0) & ",'" & Periodo.Substring(0, 4) & "',1)", "TA")

                        sqlExecute("INSERT INTO bitacora_hrs_brt " & _
                               "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                               R & "','" & FechaSQL(Fecha) & "','" & MerMilitar(drHorario("entra")) & _
                                   "','" & Usuario & "',GETDATE(),'" & TipoTransaccion & "',NULL,NULL)", "TA")
                    End If
                End If

                'Si falta la salida, insertarla de acuerdo al horario
                If FaltaSalida Then
                    dtTemp = sqlExecute("SELECT reloj FROM hrs_brt WHERE  fecha = '" & FechaSQL(FechaSalida) & "' AND hora = '" & MerMilitar(drHorario("sale")) & _
                                        "' AND reloj = '" & drEmpleado("reloj") & "' ", "TA")
                    If dtTemp.Rows.Count = 0 Then
                        sqlExecute("INSERT INTO hrs_brt (cod_comp,reloj,gafete,fecha,hora,dia,periodo,tipo_tran,pareja,preus,ano,faltaba_tran) VALUES ('" & _
                                   Comp & "','" & R & "','" & IIf(IsDBNull(drEmpleado("gafete")), drEmpleado("reloj"), drEmpleado("gafete")) & "','" & _
                                   FechaSQL(FechaSalida) & "','" & MerMilitar(drHorario("sale")) & "','" & DiaSem(FechaSalida) & "','" & Periodo.Substring(4, 2) & "','" & _
                                   TipoTransaccion & "',1," & IIf(Preus, 1, 0) & ",'" & Periodo.Substring(0, 4) & "',1)", "TA")
                        sqlExecute("INSERT INTO bitacora_hrs_brt" & _
                               "(reloj,fecha,hora,usuario,fecha_cambio,tipo_tran,fecha_original,hora_original) VALUES ('" & _
                               R & "','" & FechaSQL(FechaSalida) & "','" & MerMilitar(drHorario("SALE")) & _
                                   "','" & Usuario & "',GETDATE(),'" & TipoTransaccion & "',NULL,NULL)", "TA")
                    End If
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "AnalisisTA", ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub AnalisisHrsBrt(ByVal drEmpleado As DataRow, Fecha As Date, Periodo As String, Ano As String)
        Dim HoraInicial As DateTime = Now

        '*************** Análisis de entradas/salidas en hrs_brt ******************
        Dim dtBrt As New DataTable
        Dim dtBrtSalida As New DataTable
        Dim dtBrtEntrada As New DataTable

        Dim fIni As Date
        Dim fFin As Date

        Dim DifEnt As Double
        Dim DifSal As Double

        Dim UltimaTran As String = ""
        Dim FechaEntro As String = ""
        Dim FechaSalio As String = ""
        Dim HoraEntro As String = ""
        Dim HoraSalio As String = ""
        Dim drHoras As DataRow

        Dim reloj As String = ""

        Try
            Reloj = drEmpleado("reloj")

            'Definir si la hora de entrada es cercana a las 0hrs
            '*** ATENCION: AL CAPTURAR TABLA DIAS, TENER CUIDADO EN EL RANGO_HRS, PARA QUE ALCANCE LA ENTRADA Y EL TIEMPO EXTRA ESTIMADO... ****

            If HtoD(MerMilitar(drHorario("entra"))) < 2 Then
                'Si la hora de entrada es menor a las 2:00 AM
                fIni = DateAdd(DateInterval.Minute, -HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))) * 60, Fecha)
                'Determinar la hora en que termina el día, de acuerdo al rango de horas definido
                fFin = DateAdd(DateInterval.Minute, (-HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))) + 24) * 60, Fecha)
            Else
                'Determinar la hora en que inicia el día, de acuerdo al rango de horas definido
                fIni = DateAdd(DateInterval.Minute, HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))) * 60, Fecha)
                fIni = DateAdd(DateInterval.Second, -1, fIni)

                'Determinar la hora en que terminia el día, de acuerdo al rango de horas definido
                fFin = DateAdd(DateInterval.Minute, (HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))) + 24) * 60, Fecha)
            End If


            If False Then
            Else
                'Si no es PREUS
                dtBrt = sqlExecute("SELECT fecha,hora,preus,entrada_salida,fecha_efva FROM hrs_brt WHERE reloj = '" & reloj & _
                                   "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora BETWEEN '" & _
                                   FechaHoraSQL(fIni) & "' AND '" & FechaHoraSQL(fFin) & _
                                   "' AND fecha_efva IS NULL ORDER BY fecha,hora", "TA")

                For Each drHoras In dtBrt.Rows
                    If UltimaTran = "" Then
                        'Si es el primer movimiento, revisar si está más cerca de la entrada o de la salida

                        DifEnt = HtoD(RestaHrs(drHorario("entra"), drHoras("hora")))
                        If DifEnt < -1 Then
                            'Si la diferencia es mayor a una hora antes de su entrada, revisar si al día anterior le falta una salida
                            dtTemporal = sqlExecute("SELECT TOP 1 * FROM hrs_brt WHERE reloj = '" & reloj & _
                                                "' AND RTRIM(CAST(fecha as CHAR))+' ' + hora < '" & FechaHoraSQL(fIni) & _
                                                "' ORDER BY RTRIM(CAST(fecha as CHAR))+' ' + hora DESC", "TA")
                            If dtTemporal.Rows.Count = 0 Then
                                UltimaTran = "S"
                            Else
                                If IsDBNull(dtTemporal.Rows(0).Item("fecha_efva")) Then
                                    UltimaTran = "S"
                                ElseIf DateDiff(DateInterval.Day, dtTemporal.Rows(0).Item("fecha_efva"), Fecha) > 1 Then
                                    UltimaTran = "S"
                                Else
                                    UltimaTran = IIf(IsDBNull(dtTemporal.Rows(0).Item("entrada_salida")), "S", dtTemporal.Rows(0).Item("entrada_salida"))
                                End If
                            End If

                            If UltimaTran <> "S" Then
                                'Si la última transacción no fue una salida, pasar este registro como salida del día anterior
                                sqlExecute("UPDATE hrs_brt SET " & IIf(True, " entrada_salida = 'S',", "") & " ano = '" & Ano & "', periodo = '" & Periodo & _
                                       "', fecha_efva = '" & FechaSQL(DateAdd(DateInterval.Day, -1, Fecha)) & _
                                           "' WHERE reloj = '" & reloj & "' AND fecha = '" & FechaSQL(drHoras("fecha")) & _
                                           "' AND hora = '" & drHoras("hora") & "'", "TA")
                                sqlExecute("DELETE FROM asist WHERE RELOJ ='" & reloj & "' AND fha_ent_hor ='" & FechaSQL(DateAdd(DateInterval.Day, -1, Fecha)) & "'", "TA")
                                Evaluador(drEmpleado, DateAdd(DateInterval.Day, -1, Fecha), Periodo, Ano)
                                UltimaTran = "X"
                            Else
                                DifSal = HtoD(RestaHrs(drHoras("hora"), drHorario("sale")))
                                If Math.Abs(DifEnt) < Math.Abs(DifSal) Or DifEnt > 23 Then
                                    'Si el movimiento está más cerca de la entrada, marcar última transacción como salida, para que tome el movimiento como entrada
                                    'Si la diferencia con la entrada es >23, es hora cercana a la media noche
                                    UltimaTran = "S"
                                Else
                                    UltimaTran = "E"
                                End If
                            End If
                        Else
                            DifSal = HtoD(RestaHrs(drHoras("hora"), drHorario("sale")))
                            If Math.Abs(DifEnt) < Math.Abs(DifSal) Then
                                'Si el movimiento está más cerca de la entrada, marcar última transacción como salida, para que tome el movimiento como entrada
                                UltimaTran = "S"
                            Else
                                UltimaTran = "E"
                            End If
                        End If
                    End If


                    If UltimaTran = "E" Then
                        'Si la última transacción fue una entrada, esta es una salida
                        sqlExecute("UPDATE hrs_brt SET " & IIf(True, "entrada_salida = 'S',", "") & " ano = '" & Ano & "', periodo = '" & Periodo & _
                                       "',fecha_efva = '" & FechaSQL(Fecha) & _
                                   "' WHERE reloj = '" & reloj & "' AND fecha = '" & FechaSQL(drHoras("fecha")) & _
                                   "' AND hora = '" & drHoras("hora") & "'", "TA")

                        UltimaTran = "S"
                    ElseIf UltimaTran <> "X" Then
                        'Si la última transacción fue una salida, o no ha habido movimiento, esta es una entrada
                        sqlExecute("UPDATE hrs_brt SET " & IIf(True, " entrada_salida = 'E', ", "") & "  ano = '" & Ano & "', periodo = '" & Periodo & _
                                       "',fecha_efva = '" & FechaSQL(Fecha) & _
                                   "' WHERE reloj = '" & reloj & "' AND fecha = '" & FechaSQL(drHoras("fecha")) & _
                                   "' AND hora = '" & drHoras("hora") & "'", "TA")

                        UltimaTran = "E"
                    ElseIf UltimaTran = "X" Then
                        UltimaTran = ""
                    End If
                Next

                If dtBrt.Rows.Count Mod 2 <> 0 And dtBrt.Rows.Count > 1 And UltimaTran <> "S" Then
                    drHoras = dtBrt.Rows(dtBrt.Rows.Count - 1)
                    DifEnt = HtoD(RestaHrs(drHorario("entra"), drHoras("hora")))
                    DifSal = HtoD(RestaHrs(drHoras("hora"), drHorario("sale")))
                    If DifEnt > DifSal Then
                        'Si hay menos diferencia con la salida, es salida
                        sqlExecute("UPDATE hrs_brt SET " & IIf(True, " entrada_salida = 'S',", "") & "  ano = '" & Ano & "', periodo = '" & Periodo & _
                                       "',fecha_efva = '" & FechaSQL(Fecha) & _
                                    "' WHERE reloj = '" & reloj & "' AND fecha = '" & FechaSQL(drHoras("fecha")) & _
                                    "' AND hora = '" & drHoras("hora") & "'", "TA")
                    End If

                End If
            End If 'PREUS

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "AnalisisTA", ex.HResult, ex.Message)
        End Try

    End Sub

    

    Public Sub Evaluador(ByVal drEmpleado As DataRow, Fecha As Date, Periodo As String, Ano As String, Optional DesdeAsistenciaPerfecta As Boolean = False)


        'sqlExecute("EXEC DiasSemana @fecha = '" & FechaSQL(Fecha) & "'", "TA")

        Dim fIni As DateTime            'Fecha de entrada, considerando rango de horas
        Dim fFin As DateTime            'Fecha de salida, considerando rango de horas

        Dim FechaEntro As Date              'Fecha de entrada
        Dim FechaSalio As Date              'Fecha de salida
        Dim HoraEntro As String = ""        'Hora de entrada
        Dim HoraSalio As String = ""        'Hora de salida
        Dim FechaSalida As Date             'Fecha de salida, de acuerdo a su horario

        Dim dtEvNomSem As New DataTable
        Dim dtCiasTA As New DataTable
        Dim dtHrsBrt As New DataTable
        Dim dtEntrada As New DataTable
        Dim dtSalida As New DataTable

        Dim ChecaTarjeta As Boolean
        Dim Cadena As String = ""
        Dim Hrs As String = "00:00"
        Dim Cafeteria As Double = 0
        Dim HrsNor As String = "00:00"
        Dim Extras As String = "00:00"
        Dim HrsExt As String = "00:00"

        Dim HrsTotales As Double

        Dim ExtrasAutorizadas As String = "00:00"
        Dim ExtrasRealesTabla As String = "00:00"

        Dim HorasTarde As String = "00:00"
        Dim HorasSalidaAnticipada As String = "00:00"
        Dim HorasConvenio As String = "00:00"
        Dim DescansoTrabajado As Boolean = False
        Dim FestivoTrabajado As Boolean = False
        Dim VacacionesTrabajadas As Boolean = False
        Dim EntradaReal As String = "00:00"
        Dim SalidaReal As String = "00:00"
        Dim FEntradaReal As Date
        Dim FSalidaReal As Date

        Dim EsFestivo As Boolean
        Dim EsDescanso As Boolean


        '-----------------------------------------------------------------------
        'inicializacion de variables de memoria

        ' _pareja .- El la base de datos de horas en bruto (hrs_brt) existe un campo que define 
        '			 si la transaccion tiene pareja con otra transaccion, al igual que con la variable
        '			 esta indica si el registro activo tiene o no pareja.

        ' _cuenta_extra .- La variable es cargada de horarios.aviso_ex la cual no indica si para determinado 
        '				horario se tomara en cuenta el tiempo extra, esto es si sera tomado en 
        '				cuenta en la tarjeta

        ' _cuenta_extra_antes .- La varieble es cargada de horarios.aviso_ex la cual no indica si para determinado 
        '				horario se tomara en cuenta el tiempo extra, esto es si sera tomado en 
        '				cuenta en la tarjeta


        ' _descanso.-	La variable es cargada de dias.descanso y no indica si el dia es de descanso,
        ' 				si es esto el dia sera tratado de modio especial. (todo el tiempo trabajado 
        '				pasara a tiempo extra)

        ' _seg_horas_ex.- Nos cuanta las horas extras expresadas en segundos

        ' _comentario.- Esta variable guarda los mensajes para la tarjeta, cada paraja (entrada, salida)
        '				tiene un comentario ya sea retardo, ajuste, salida anticipada, etc.

        '**** VARIABLES NO UTILIZADAS ****

        'Dim _descanso As Boolean = False
        'Dim _festivo As Boolean = False
        'Dim _seg_horas_ex As Integer = 0

        'Dim _rango_hrs As String = "00:00"

        'Dim DifEnt As Double
        'Dim DifSal As Double
        '**********************************

        Dim _pareja As Boolean = True
        Dim _abierto As Boolean = False
        Dim _tipo_aus As String = ""
        Dim _comentario As String = ""


        Dim DifEnt As String = ""
        Dim DifSal As String = ""

        Dim _al_ant_ent As Integer = 0
        Dim _al_des_ent As Integer = 0
        Dim _al_ant_sal As Integer = 0
        Dim _al_des_sal As Integer = 0
        Dim _al_horas_ex As Integer = 0

        Dim _cuenta_extra As Boolean = False
        Dim _cuenta_extra_antes As Boolean = False

        Dim ExtraAntes As String = ""                   'Tiempo extra antes de la entrada
        Dim ExtraDespues As String = ""                 'Tiempo extra después de la salida

        Dim FaltaEntrada As Boolean = False
        Dim FaltaSalida As Boolean = False

        Dim AjusteEntrada As Boolean = False
        Dim AjusteSalida As Boolean = False
        Dim TipoTran As String = ""                    'Tipo de transacción. Por default R = Reloj
        Dim MinCafeteria As Decimal
        Dim EsTiempoCompleto As Boolean
        Dim AutorizaTodo As Boolean = False
        Dim DescontoCafeteria As Boolean = False

        Dim reloj As String = ""

        Dim dtTemp As New DataTable
        Try
            Reloj = drEmpleado("reloj").ToString.Trim
            'My.Application.DoEvents()

            'Modificar el día con letra en hrs_brt, porque del reloj no traen este campo
            sqlExecute("UPDATE hrs_brt SET dia = '" & DiaSem(Fecha) & "' WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(Fecha) & "'", "TA")

            ChecaTarjeta = IIf(IsDBNull(drEmpleado("checa_tarjeta")), True, drEmpleado("checa_tarjeta"))


            'Determinar la hora en que inicia el día, de acuerdo al rango de horas definido
            fIni = DateAdd(DateInterval.Hour, HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))), Fecha)
            'Determinar la hora en que termina el día, de acuerdo al rango de horas definido
            fFin = DateAdd(DateInterval.Hour, HtoD(IIf(IsDBNull(drHorario("rango_hrs")), "03:00", drHorario("rango_hrs"))) + 24, Fecha)
            FechaSalida = IIf(drHorario("cod_dia") <> drHorario("cod_dia_sal"), DateAdd(DateInterval.Day, 1, Fecha), Fecha)

            'MCR 22/OCT/2015
            'No insertar en bitácora de ausentismo desde el evaluador

            ''MCR 15/OCT/2015
            ''Insertar en bitácora borrado de ausentismo (INSERTAR EN BITACORA ANTES DE BORRAR, PUES SE LLENA DESDE AUSENTISMO)
            'sqlExecute("INSERT INTO bitacora_ausentismo " & _
            '              "(reloj,fecha,tipo_aus,tipo_movimiento,fecha_movimiento,usuario_movimiento,valor_anterior,notas) " & _
            '           "SELECT reloj,fecha,tipo_aus,'B',GETDATE(),'" & Usuario & "','','Borrar ausentismo desde " & _
            '           System.Reflection.MethodBase.GetCurrentMethod.Name() & "' FROM ausentismo WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(Fecha) & _
            '           "' AND tipo_aus IN ('" & _aus_natural & "','AUS')", "TA")

            'Borrar ausentismo de ese día, que sea de tipo ausentismo natural
            sqlExecute("DELETE from ausentismo WHERE reloj = '" & reloj & "' AND fecha = '" & FechaSQL(Fecha) & _
                       "' AND tipo_aus IN ('FI','FI')", "TA")



            'Buscar ausentismo ya registrado para esta fecha (incapacidades, vacaciones, etc.)
            dtTemp = sqlExecute("SELECT ausentismo.tipo_aus FROM ausentismo WHERE reloj = '" & Reloj & "' AND fecha = '" & _
                                FechaSQL(Fecha) & "'", "TA")
            If dtTemp.Rows.Count > 0 Then
                _tipo_aus = dtTemp.Rows(0).Item("tipo_aus")
            End If

            dtTemp = sqlExecute("SELECT autorizar_extra,filtro_extra,filtro_extra_aut FROM cias_ta WHERE cod_comp = '" & drEmpleado("cod_comp") & "'", "TA")
            If dtTemp.Rows.Count = 0 Then
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "AnalisisTA", 0, "Falta información de CiasTa para " & drEmpleado("cod_comp"))
                Exit Sub
            Else
                AutorizarExtra = IIf(IsDBNull(dtTemp.Rows(0).Item("autorizar_extra")), 0, dtTemp.Rows(0).Item("autorizar_extra"))
                FiltroExtras = IIf(IsDBNull(dtTemp.Rows(0).Item("filtro_extra")), "", dtTemp.Rows(0).Item("filtro_extra"))
                FiltroExtrasAutorizadas = IIf(IsDBNull(dtTemp.Rows(0).Item("filtro_extra_aut")), "", dtTemp.Rows(0).Item("filtro_extra_aut"))
            End If

            'Revisar si es día festivo o descanso
            EsFestivo = Festivo(Fecha, Reloj)
            EsDescanso = drHorario("descanso")

            If EsFestivo Then
                'Agregar festivo en ausentismo
                If _tipo_aus <> "FES" And TipoNaturaleza(_tipo_aus) <> "I" Then
                    'Si el tipo de ausentismo encontrado es diferente al festivo (si no hay ausentismo, _tipo_aus = "")  y no es incapacidad

                    'Borrar ausentismo existente
                    sqlExecute("DELETE from ausentismo WHERE reloj = '" & reloj & "' AND fecha = '" & FechaSQL(Fecha) & "'", "TA")

                    'Insertar día festivo en tabla de ausentismo
                    sqlExecute("INSERT INTO ausentismo (cod_comp,reloj,fecha,tipo_aus,periodo,subclasi,usuario,fecha_hora) VALUES ('" & _
                               drEmpleado("cod_comp") & "','" & _
                               drEmpleado("reloj") & "','" & _
                               FechaSQL(Fecha) & "','" & _
                               "FES" & "','" & _
                               Periodo & "','" & _
                               "Evaluador" & "','" & _
                               Usuario & "', " & _
                               "GETDATE())", "TA")
                    _tipo_aus = "FES"
                End If
            End If

            'Obtener todos los registros en esta fecha
            dtEntrada = sqlExecute("SELECT fecha,hora,entrada_salida,faltaba_tran,tipo_tran FROM hrs_brt WHERE RELOJ = '" & Reloj & _
                                   "' AND  fecha_efva = '" & FechaSQL(Fecha) & _
                                   "' AND NOT entrada_salida IS NULL ORDER BY fecha ASC,hora ASC", "TA")

            If dtEntrada.Rows.Count = 0 Then
                'Si no se obtuvieron registros de hrs_brt, agregar un registro solo para referencia. 
                'La X indica que no debe considerarlo Entrada ni Salida
                dtEntrada.Rows.Add({Nothing, "", "X", 0, "S"})

                If EsDescanso Then
                    'Si es día de descanso, salir del procedimiento
                    Exit Sub
                ElseIf Not EsFestivo And _tipo_aus.Length = 0 And Fecha <= Now Then
                    'Si no es descanso ni festivo, y no tiene ausentismo registrado, poner el natural
                    'MCR 11/NOV/2015
                    'Cambio de condición a fecha máxima
                    If IIf(IsDBNull(drEmpleado("BAJA")), DateSerial(2999, 1, 1), drEmpleado("BAJA")) > Fecha Then
                        'MCR 8/Oct/2015
                        'Siempre que la fecha de baja sea anterior a la fecha analizada, o en blanco
                        _tipo_aus = "FI"
                        sqlExecute("INSERT INTO ausentismo (cod_comp,reloj,fecha,tipo_aus,periodo,subclasi,usuario,fecha_hora) VALUES ('" & _
                                   drEmpleado("cod_comp") & "','" & _
                                   drEmpleado("reloj") & "','" & _
                                   FechaSQL(Fecha) & "','" & _
                                   _tipo_aus & "','" & _
                                   Periodo & "','" & _
                                   "Evaluador','" & _
                                   Usuario & "', " & _
                                   "GETDATE())", "TA")
                    Else
                        'MCR 8/Oct/2015
                        'El día de la baja no cuenta ausentismo. No es forzoso que asista.
                        Exit Sub
                    End If

                ElseIf Fecha > Now And _tipo_aus = "FI" Then
                    _tipo_aus = ""
                End If
            ElseIf EsDescanso Then
                'MCR 14/OCT/2015
                'Si es descanso, y hay checadas, revisar a qué registro de horario pertenecen, basados en la entrada
                Dim Dif() As Integer
                ReDim Dif(drHorarios.Count - 1)
                Dim i As Integer = 0
                Dim x As Integer
                Dim Min As Integer = 1000

                For Each dRow As DataRow In drHorarios
                    Dif(i) = Math.Abs(HtoD(RestaHrs(dRow("entra"), dtEntrada(0)("hora"))))
                    i += 1
                Next

                For i = 0 To Dif.Count - 1
                    If Dif(i) < Min Then
                        Min = Dif(i)
                        x = i
                    End If
                Next

                drHorario = drHorarios(x)
            End If

            For x = 0 To dtEntrada.Rows.Count - 1
                FechaEntro = Fecha
                HoraEntro = ""
                FechaSalio = FechaSalida
                HoraSalio = ""

                FaltaEntrada = True
                FaltaSalida = True
                _pareja = False
                _comentario = ""
                _al_ant_ent = 0
                _al_ant_sal = 0
                _al_des_ent = 0
                _al_des_sal = 0
                _al_horas_ex = 0

                'TipoTran = IIf(IsDBNull(dtEntrada.Rows(x).Item("tipo_tran")), "", dtEntrada.Rows(x).Item("tipo_tran"))

                If IsDBNull(dtEntrada.Rows(x).Item("tipo_tran")) Then
                    TipoTran = ""
                ElseIf dtEntrada.Rows(x).Item("tipo_tran") = "O" Then
                    TipoTran = "Olvidó gafete"
                ElseIf dtEntrada.Rows(x).Item("tipo_tran") = "P" Then
                    TipoTran = "Perdió gafete"
                Else
                    TipoTran = ""
                End If

                If dtEntrada.Rows(x).Item("entrada_salida") = "E" Then
                    'Si el registro es una entrada
                    'Poner en falso la variable _pareja, porque aún no sabemos si tiene salida
                    _pareja = False
                    'Llenar las variables con los datos de la entrada
                    FaltaEntrada = False

                    'Si faltaba una transacción, y se puso por ajuste
                    AjusteEntrada = IIf(IsDBNull(dtEntrada.Rows(x).Item("faltaba_tran")), 0, dtEntrada.Rows(x).Item("faltaba_tran")) = 1

                    'Hora y fecha de entrada
                    HoraEntro = MilitarMer(dtEntrada.Rows(x).Item("hora"))
                    FechaEntro = dtEntrada.Rows(x).Item("fecha")
                    If HoraEntro = "**:**" Then
                        HoraEntro = ""
                    End If

                    'Buscar si hay un siguiente registro
                    If x < dtEntrada.Rows.Count - 1 Then
                        'Si hay, revisar si es una salida
                        x = x + 1
                        If dtEntrada.Rows(x).Item("entrada_salida") = "S" Then
                            'Como ya tuvo entrada y salida, poner en verdadero la variable _pareja
                            _pareja = True

                            'Si faltaba una transacción, y se puso por ajuste
                            AjusteSalida = IIf(IsDBNull(dtEntrada.Rows(x).Item("faltaba_tran")), 0, dtEntrada.Rows(x).Item("faltaba_tran")) = 1

                            'Llenar las variables con los datos de la salida
                            FaltaSalida = False
                            HoraSalio = MilitarMer(dtEntrada.Rows(x).Item("hora"))
                            FechaSalio = dtEntrada.Rows(x).Item("fecha")
                            If HoraSalio = "**:**" Then
                                HoraSalio = ""
                            End If
                        Else
                            'Si el siguiente registro no es una salida, devolver el contador para tomar nuevamente el registro
                            'Aunque es casi imposible que haya dos entradas seguidas el mismo día...
                            x = x - 1
                        End If
                    End If
                ElseIf dtEntrada.Rows(x).Item("entrada_salida") = "S" Then
                    'Si el registro es una salida
                    _pareja = False
                    FaltaSalida = False
                    'Si faltaba una transacción, y se puso por ajuste
                    AjusteSalida = IIf(IsDBNull(dtEntrada.Rows(x).Item("faltaba_tran")), 0, dtEntrada.Rows(x).Item("faltaba_tran")) = 1

                    HoraSalio = MilitarMer(dtEntrada.Rows(x).Item("hora"))
                    FechaSalio = dtEntrada.Rows(x).Item("fecha")

                    If HoraSalio = "**:**" Then
                        HoraSalio = ""
                    End If
                End If

                'Obtener el número total de horas
                If FaltaEntrada Or FaltaSalida Then
                    Hrs = "00:00"
                    HrsNor = "00:00"
                Else
                    Hrs = RestaHrs(FechaEntro, HoraEntro, FechaSalio, HoraSalio)

                    If Hrs.Substring(0, 1) = "-" Or Hrs = "**.**" Then
                        'Si las horas son negativas, o error, hacer 0
                        Hrs = "00:00"
                    End If

                    'Entradas y salidas para contar horas
                    If Not FaltaEntrada Then
                        'If HtoD(HoraEntro) - HtoD(drHorario("min_des_ent")) <= HtoD(drHorario("entra")) Then
                        ''''' REVISAR MCR
                        If HtoD(RestaHrs(Fecha, drHorario("entra"), FechaEntro, HoraEntro)) <= HtoD(drHorario("min_des_ent")) Then
                            'Si el empleado llegó tarde, pero dentro del margen, o llegó antes de la hora, se maneja su horario
                            EntradaReal = drHorario("entra")
                            FEntradaReal = Fecha
                        Else
                            'Si llegó tarde, se utiliza su hora de llegada
                            EntradaReal = HoraEntro
                            FEntradaReal = FechaEntro
                        End If
                    End If
                    Dim DifSalida As Double

                    If Not FaltaSalida Then
                        'If HtoD(MerMilitar(HoraSalio)) + HtoD(drHorario("min_ant_sal")) >= HtoD(MerMilitar(drHorario("sale"))) Then
                        DifSalida = HtoD(RestaHrs(FechaSalio, HoraSalio, FechaSalida, drHorario("sale")))
                        If DifSalida < HtoD(drHorario("min_des_sal")) Then

                            'Si el empleado salió a su hora o antes, pero dentro del margen, 
                            SalidaReal = drHorario("sale")
                            'Obtener el número total de horas con las entradas y salidas ajustadas
                            FSalidaReal = FechaSalida

                        Else
                            'Si salió antes, se utiliza su hora de llegada
                            SalidaReal = HoraSalio
                            FSalidaReal = FechaSalio
                            'Obtener el número total de horas con las entradas y salidas ajustadas
                        End If
                    End If
                    'Obtener el número total de horas con las entradas y salidas ajustadas
                    HrsNor = RestaHrs(FEntradaReal, EntradaReal, FSalidaReal, SalidaReal)
                    If HtoD(HrsNor) < 0 Then
                        'Si las horas son negativas, o error, hacer 0
                        HrsNor = "00:00"
                    End If
                End If
                'Si se descuenta proporción de cafetería, y las horas trabajadas son mayores o iguales al mínimo para descontar cafetería
                'MCR 11/NOV/2015
                'Acumular horas trabajadas, por si hay varias entradas/salidas
                HrsTotales += HtoD(HrsNor)
                MinCafeteria = HtoD(IIf(IsDBNull(drHorario("minimo_cafeteria")), "", drHorario("minimo_cafeteria")))
                If HrsTotales >= MinCafeteria Then
                    If IIf(IsDBNull(drHorario("com_prop")), False, drHorario("com_prop")) Then
                        Cafeteria = (HtoD(IIf(IsDBNull(drHorario("comida")), "00:00", drHorario("comida"))) * HtoD(Hrs)) / HtoD(drHorario("hrs_dia"))
                    Else
                        Cafeteria = HtoD(IIf(IsDBNull(drHorario("comida")), "00:00", drHorario("comida")))
                    End If
                Else
                    'MCR 11/NOV/2015
                    'Si no cumple el mínimo, reiniciar cafetería a 0, 
                    'por si hay más entradas/salidas del mismo día
                    Cafeteria = 0
                End If

                If HtoD(Hrs) > 0 Then
                    If EsDescanso Then
                        DescansoTrabajado = True
                        _comentario = IIf(_comentario.Length > 0, _comentario & ", ", "") & "Descanso trabajado"
                    ElseIf Festivo(Fecha, Reloj) Then
                        FestivoTrabajado = True
                    ElseIf TipoNaturaleza(_tipo_aus) = "V" Then
                        VacacionesTrabajadas = True
                    End If
                End If

                'Descontar proporción cafetería al total de horas 
                'Si no se descuenta proporción, Cafetería = 0. Como Cafetería es numérico, se debe convertir a caracter antes de enviarlo como parámtetro 
                If (DescansoTrabajado Or VacacionesTrabajadas Or FestivoTrabajado) Then
                    'Si es día de descanso trabajado, descontar cafetería de las horas totales
                    Hrs = RestaHrs(DtoH(Cafeteria), Hrs, True)
                Else
                    'Si es día de trabajo regular, descontar cafetería de las horas normales
                    HrsNor = RestaHrs(DtoH(Cafeteria), HrsNor)
                End If

                'Si es horario abierto, y las horas normales son mayores al tiempo que debió trabajar, se ponen las horas de su horario
                'o bien, son vacaciones o festivo
                'o aplica tiempo completo y tiene al menos entrada o salida
                _abierto = IIf(IsDBNull(drHorario("abierto")), False, drHorario("abierto"))
                EsTiempoCompleto = False
                If (_abierto And HtoD(HrsNor) > HtoD(drHorario("hrs_dia"))) _
                        Or TipoNaturaleza(_tipo_aus) = "V" _
                        Or _tipo_aus = "FES" Then
                    HrsNor = drHorario("hrs_dia")
                ElseIf EsTiempoCompleto And Not (FaltaEntrada And FaltaSalida) And Not EsDescanso Then
                    If x <= 1 Then
                        HrsNor = drHorario("hrs_dia")
                    Else
                        HrsNor = "00:00"
                    End If
                End If
                If x > 1 Then
                    'Stop
                End If

                'Si cuenta el tiempo extra después de la salida o antes de la entrada
                _cuenta_extra = IIf(IsDBNull(drHorario("cuenta_ex")), False, drHorario("cuenta_ex"))
                _cuenta_extra_antes = IIf(IsDBNull(drHorario("cuenta_ex_antes")), False, drHorario("cuenta_ex_antes"))

                If _cuenta_extra Or _cuenta_extra_antes Then

                    If DescansoTrabajado Then
                        'NO--- Si trabajó el día de descanso, todas las horas son extras
                        'HrsExt = Hrs

                        HrsNor = "00:00"
                        'MCR 13/OCT/2015
                        'Aún en descanso, solo tomar el tiempo extra antes de la entrada si así se define

                        If Not _cuenta_extra_antes And Not FaltaEntrada Then
                            If HtoD(RestaHrs(Fecha, drHorario("entra"), FechaSalio, HoraSalio)) < 0 Then
                                'Si entró y salió antes de su horario de entrada, las extras solo son las que trabajó
                                ExtraAntes = Hrs
                            Else
                                'Si entró temprano, luego continuó con su horario, las extras antes son las que falten entre su entrada y la entrada del horario
                                ExtraAntes = RestaHrs(FechaEntro, HoraEntro, Fecha, EntradaReal)
                            End If
                        Else
                            ExtraAntes = ""
                        End If

                        HrsExt = DtoH(HtoD(Hrs) - HtoD(ExtraAntes))

                    ElseIf FestivoTrabajado Then
                        'MCR 8/OCT/2015
                        'Las vacaciones trabajadas se pagan como día normal
                        'a petición de Magdalena Belmont
                        'Or VacacionesTrabajadas Then
                        '

                        'Si trabajó en vacaciones o festivo, todas las horas son extras
                        'y las horas normales son las que trabaja por día de acuerdo a su horario
                        HrsExt = Hrs
                    ElseIf _abierto Then
                        'Si es horario abierto, ver condiciones
                        MessageBox.Show("PENDIENTE HORARIO ABIERTO")
                        Application.DoEvents()
                    ElseIf Not EsFestivo Then
                        If _cuenta_extra_antes And Not FaltaEntrada Then
                            If HtoD(RestaHrs(Fecha, drHorario("entra"), FechaSalio, HoraSalio)) < 0 Then
                                'Si entró y salió antes de su horario de entrada, las extras solo son las que trabajó
                                ExtraAntes = Hrs
                            Else
                                'Si entró temprano, luego continuó con su horario, las extras antes son las que falten entre su entrada y la entrada del horario
                                ExtraAntes = RestaHrs(FechaEntro, HoraEntro, Fecha, EntradaReal)
                            End If
                        Else
                            ExtraAntes = ""
                        End If

                        If _cuenta_extra And Not FaltaSalida Then
                            If HtoD(RestaHrs(FechaEntro, HoraEntro, FechaSalio, drHorario("sale"))) < 0 And x > 1 Then
                                'Si entró y salió después de su horario de entrada, las extras solo son las que trabajó
                                ExtraDespues = Hrs
                            Else
                                'Si entró temprano, luego continuó con su horario, las extras antes son las que falten entre su entrada y la entrada del horario
                                ExtraDespues = RestaHrs(FechaSalida, SalidaReal, FechaSalio, HoraSalio)
                            End If

                            If HtoD(ExtraDespues) < 0 Then ExtraDespues = ""
                        Else
                            ExtraDespues = ""
                        End If

                        Extras = DtoH(HtoD(ExtraAntes) + HtoD(ExtraDespues))
                        If HtoD(Extras) >= HtoD(drHorario("aviso_extra")) Then
                            HrsExt = Extras
                        Else
                            HrsExt = "00:00"
                        End If
                    End If
                End If

                'Alerta de tiempo antes o después de entrada
                'Si no es descanso, festivo, o incapacidad
                If Not EsDescanso And Not EsFestivo And TipoNaturaleza(_tipo_aus) <> "I" Then
                    DifEnt = RestaHrs(FechaEntro, HoraEntro, Fecha, drHorario("entra"))
                    DifSal = RestaHrs(FechaSalida, drHorario("sale"), FechaSalio, HoraSalio)

                    If Not FaltaEntrada And HtoD(DifEnt) * -1 > HtoD(drHorario("min_des_ent")) Then
                        _al_des_ent = (HtoD(DifEnt) - HtoD(drHorario("min_des_ent"))) * 3600
                        If _al_des_ent > 0 Then _al_des_ent = 0
                        _al_ant_ent = -_al_des_ent
                    End If
                    'Alerta de tiempo antes o después de entrada
                    If Not FaltaSalida And HtoD(DifSal) * -1 > HtoD(drHorario("min_ant_sal")) Then
                        _al_ant_sal = (HtoD(DifSal) - HtoD(drHorario("min_ant_sal"))) * 3600
                        If _al_ant_sal > 0 Then _al_ant_sal = 0
                        _al_des_sal = -_al_ant_sal
                    End If
                    'Alerta de tiempo extra
                    _al_horas_ex = HtoD(Extras) * 3600

                    'Mensaje de retardo
                    If _al_des_ent < 0 Then
                        dtTemp = sqlExecute("select TOP 1 hora from hrs_brt where fecha_efva = '" & FechaSQL(Fecha) & "' and reloj = '" & Reloj & _
                                            "' and entrada_salida = 'E'", "TA")
                        If dtTemp.Rows.Count <> 0 Then
                            'Solo poner retardo en la primer entrada del día
                            If dtTemp.Rows(0).Item("hora") = MerMilitar(HoraEntro) Then
                                _comentario = IIf(_comentario.Length > 0, _comentario & ", ", "") & "Retardo"
                                HorasTarde = DifEnt.Substring(1)
                            End If
                        End If
                    End If

                    'Mensaje salida anticipada
                    If _al_ant_sal < 0 Then
                        dtTemp = sqlExecute("select TOP 1 hora from hrs_brt where fecha_efva = '" & FechaSQL(Fecha) & "' and reloj = '" & Reloj & _
                                            "' AND entrada_salida = 'S' order by hora DESC", "TA")
                        If dtTemp.Rows.Count <> 0 Then
                            'Solo poner salida anticipada en la  última salida del día
                            If dtTemp.Rows(0).Item("hora") = MerMilitar(HoraSalio) Then
                                _comentario = IIf(_comentario.Length > 0, _comentario & ", ", "") & "Salida anticipada"
                                HorasSalidaAnticipada = DifSal
                            End If
                        End If
                    End If
                End If
                'Agregar al comentario si falta entrada o salida. Si faltan las dos, será ausentismo, y el comentario es el tipo de ausentismo
                _comentario = _comentario & IIf(FaltaEntrada And Not FaltaSalida, IIf(_comentario.Length > 0, ", ", "") & "Falta entrada", "")
                _comentario = _comentario & IIf(FaltaSalida And Not FaltaEntrada, IIf(_comentario.Length > 0, ", ", "") & "Falta salida", "")

                'Agregar al comentario si se hizo ajuste en la transacción

                If AjusteEntrada And AjusteSalida Then
                    _comentario = IIf(_comentario.Length > 0, _comentario & ", ", "") & "Doble ajuste"
                ElseIf AjusteEntrada Or AjusteSalida Then
                    _comentario = IIf(_comentario.Length > 0, _comentario & ", ", "") & "Ajuste"
                End If

                'Si hubo ajuste de entrada y salida, agregar al comentario el tipo de transacción (olvidó o perdió gafete)
                If AjusteEntrada And AjusteSalida Then
                    _comentario = TipoTran & IIf(TipoTran.Length > 0 And _comentario.Length > 0, ", ", "") & _comentario
                End If

                'Revisar si aplica filtro para considerar tiempo extra (p.ej. solo a operativos)
                If FiltroExtras.Length > 0 Then
                    'Si hay un filtro para contar horas extras, revisar
                    dtTemp = sqlExecute("SELECT reloj FROM personal WHERE reloj = '" & drEmpleado("reloj") & "' AND " & FiltroExtras)
                    If dtTemp.Rows.Count = 0 Then
                        'Si no se encontró registro cumpliendo la condición, no considerar tiempo extra
                        HrsExt = "00:00"
                    End If
                End If
                If FaltaEntrada Or FaltaSalida Then
                    HrsExt = "00:00"
                End If

                'Revisar horas extras autorizadas
                If AutorizarExtra And HtoD(HrsExt) > 0 Then
                    'Si se requiere autorización para tiempo extra

                    If RTrim(FiltroExtrasAutorizadas) <> "" Then

                        'Saber si por default las tiene autorizadas
                        Dim dtAutorizar As DataTable = sqlExecute("select * from personalvw where reloj = '" & Reloj & "' and " & _
                                                                  FiltroExtrasAutorizadas)
                        Dim dtRegistroAutorizadas As DataTable = sqlExecute("select * from extras_autorizadas where reloj = '" & Reloj & _
                                                                            "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                        Dim autori_a1 As Boolean = False
                        ' si ya hay un registro de autorizadas en a_1, tomar ese valor

                        If dtRegistroAutorizadas.Rows.Count > 0 Then
                            ExtrasRealesTabla = IIf(IsDBNull(dtRegistroAutorizadas.Rows(0).Item("extras_reales")), "00:00", dtRegistroAutorizadas.Rows(0).Item("extras_reales"))
                            ExtrasAutorizadas = IIf(IsDBNull(dtRegistroAutorizadas.Rows(0).Item("extras_autorizadas")), "00:00", dtRegistroAutorizadas.Rows(0).Item("extras_autorizadas")).ToString.Trim
                            'Si la tabla indica "TODO", reemplazar SIEMPRE por el tiempo extra trabajado
                            If ExtrasAutorizadas = "TODO" Then
                                ExtrasRealesTabla = HrsExt
                                ExtrasAutorizadas = HrsExt
                                AutorizaTodo = True
                            End If
                            autori_a1 = IIf(IsDBNull(dtRegistroAutorizadas.Rows(0).Item("autori_a1")), False, dtRegistroAutorizadas.Rows(0).Item("autori_a1"))
                        Else
                            ExtrasRealesTabla = HrsExt
                            ExtrasAutorizadas = HrsExt
                            autori_a1 = False
                        End If

                        If dtRegistroAutorizadas.Rows.Count <= 0 Then
                            If dtAutorizar.Rows.Count > 0 Then
                                autori_a1 = False
                            Else
                                autori_a1 = True
                            End If
                        End If

                        If dtRegistroAutorizadas.Rows.Count <= 0 Then
                            sqlExecute("insert into extras_autorizadas (reloj, fecha, extras_reales, extras_autorizadas, entrada, salida, autori_a1) values ('" & _
                                       Reloj & "', '" & _
                                       FechaSQL(Fecha) & "', '" & _
                                       ExtrasRealesTabla & "', '" & _
                                       IIf(AutorizaTodo, "TODO", ExtrasAutorizadas) & "', '" & _
                                       HoraEntro & "', '" & _
                                       HoraSalio & "', '" & _
                                       IIf(autori_a1, 1, 0) & "')", "TA")
                        Else
                            sqlExecute("update extras_autorizadas set extras_autorizadas = '" & IIf(AutorizaTodo, "TODO", ExtrasAutorizadas) & _
                                       "' where reloj = '" & Reloj & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                        End If


                        sqlExecute("update extras_autorizadas set entrada = '" & EntradaReal & _
                                   "', salida = '" & SalidaReal & _
                                   "' where reloj = '" & Reloj & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")

                        If Not autori_a1 Then
                            ExtrasAutorizadas = "00:00"
                        End If
                    Else
                        ExtrasAutorizadas = HrsExt
                    End If
                Else
                    ExtrasAutorizadas = HrsExt
                End If

                If AutorizarExtra Then
                    sqlExecute("update extras_autorizadas set extras_reales = '" & HrsExt & _
                               "' where reloj = '" & Reloj & "' and fecha = '" & FechaSQL(Fecha) & "'", "TA")
                End If

                'Insertar información en asist
                Cadena = "INSERT INTO asist (reloj,cod_comp,cod_depto,cod_puesto,cod_tipo,cod_super,cod_turno,cod_clase,gafete,periodo,ano,"
                Cadena = Cadena & "fha_ent_hor,fha_sal_hor,horario_ent,horario_sal,fecha_entro,entro,fecha_salio,salio,dia_entro,dia_salio,pareja"
                Cadena = Cadena & ",tipo_aus,ausentismo,horas,dif_ent,dif_sal,horas_normales,horas_extras,horas_tarde,horas_anticipadas,horas_convenio,"
                Cadena = Cadena & "fal_tran_ent,fal_tran_sal"
                Cadena = Cadena & ",al_ant_ent,al_des_ent,al_ant_sal,al_des_sal,al_horas_ex,fecha,hora,extras_autorizadas"
                Cadena = Cadena & ",comentario,periodo_act,usuario)"
                Cadena = Cadena & "VALUES ('" & Reloj & "','" & drEmpleado("cod_comp") & "','" & drEmpleado("cod_depto") & "','"
                Cadena = Cadena & drEmpleado("cod_puesto") & "','" & drEmpleado("cod_tipo") & "','" & drEmpleado("cod_super") & "','" & drEmpleado("cod_turno") & "','"
                Cadena = Cadena & drEmpleado("cod_clase") & "','" & drEmpleado("gafete")
                Cadena = Cadena & "','" & Periodo & "','" & Ano & "','"
                'Fecha de entrada y salida por horario
                Cadena = Cadena & FechaSQL(Fecha) & "','" & FechaSQL(FechaSalida) & "','"
                'Hora de entrada y salida por horario
                Cadena = Cadena & drHorario("entra") & "','" & drHorario("sale") & "','"
                'Hora en que entró y salió
                Cadena = Cadena & FechaSQL(FechaEntro) & "','" & HoraEntro & "','"
                Cadena = Cadena & FechaSQL(FechaSalio) & "','" & HoraSalio & "','"
                'Día de la semana que entró y salió
                Cadena = Cadena & DiaSem(FechaEntro) & "','" & DiaSem(FechaSalio) & "',"
                'Si tiene pareja
                Cadena = Cadena & IIf(_pareja, 1, 0) & ","
                'Ausentismo, en caso de haber
                If _tipo_aus.Length > 0 Then
                    DifEnt = ""
                    DifSal = ""
                    Cadena = Cadena & "'" & _tipo_aus & "',1"
                    'Buscar el nombre del ausentismo, 
                    dtTemp = sqlExecute("SELECT nombre,ISNULL(porcentaje,0) AS porcentaje,acumula_horas_convenio FROM tipo_ausentismo where tipo_aus = '" & _tipo_aus & "'", "TA")
                    If dtTemp.Rows.Count > 0 Then

                        _comentario = IIf(_comentario.Length > 0, _comentario & ", ", "") & dtTemp.Rows(0).Item("nombre")
                        'If dtTemp.Rows(0).Item("porcentaje") > 0 Then Stop

                        If dtTemp.Rows(0).Item("porcentaje") > 0 Then
                            'MCR 8/OCT/2015
                            'Si el porcentaje > 0, es ausentismo con goce de sueldo
                            If (HrsNor = "00:00" Or HrsNor < drHorario("hrs_dia")) Then
                                If x <= 1 And Not EsDescanso And Not EsFestivo Then
                                    HrsNor = drHorario("hrs_dia")
                                Else
                                    HrsNor = "00:00"
                                End If
                            End If

                            If IIf(IsDBNull(dtTemp.Rows(0).Item("acumula_horas_convenio")), 0, dtTemp.Rows(0).Item("acumula_horas_convenio")) Then
                                HorasConvenio = DtoH(HtoD(HrsNor) * (100 - dtTemp.Rows(0).Item("porcentaje")) / 100)
                                HrsNor = DtoH(HtoD(HrsNor) * dtTemp.Rows(0).Item("porcentaje") / 100)
                            Else
                                HorasConvenio = "00:00"
                                HrsNor = DtoH(HtoD(HrsNor) * dtTemp.Rows(0).Item("porcentaje") / 100)
                            End If
                        ElseIf Hrs = "00:00" Then
                            'MCR 8/OCT/2015
                            'Si es ausentismo sin goce de sueldo, pero no tiene horas,
                            'todo regresa a 0 (asumiendo que se hayan asignado las horas x día)
                            HrsNor = "00:00"
                            HrsExt = "00:00"
                        End If
                    End If
                    If VacacionesTrabajadas Or DescansoTrabajado Or FestivoTrabajado Then
                        _comentario = _comentario & " trab."
                    End If
                Else
                    Cadena = Cadena & "NULL,0"
                End If
                _comentario = _comentario.ToUpper

                'Horas trabajadas
                Cadena = Cadena & ",'" & IIf(FaltaEntrada Or FaltaSalida, "00:00", RestaHrs(FechaEntro, HoraEntro, FechaSalio, HoraSalio)) & "','"
                'Diferencia de tiempo respecto a entrada y salida
                Cadena = Cadena & DifEnt & "','" & DifSal & "','"
                'Horas normales
                Cadena = Cadena & HrsNor & "','"
                'Horas extras
                Cadena = Cadena & HrsExt & "','"
                'Horas tarde
                Cadena = Cadena & HorasTarde & "','"
                'Horas salida anticipada
                Cadena = Cadena & HorasSalidaAnticipada & "','"
                'Horas por convenio
                Cadena = Cadena & HorasConvenio & "',"
                'Faltaba transacción de entrada y/o salida, y se hizo ajuste (desde hrs_brt)
                Cadena = Cadena & IIf(AjusteEntrada, 1, 0) & ","
                Cadena = Cadena & IIf(AjusteSalida, 1, 0) & ","
                'Alerta antes y después de la entrada y salida 
                Cadena = Cadena & _al_ant_ent & ","
                Cadena = Cadena & _al_des_ent & ","
                Cadena = Cadena & _al_ant_sal & ","
                Cadena = Cadena & _al_des_sal & ","
                'Alerta de tiempo extra
                Cadena = Cadena & _al_horas_ex & ",'"
                'Fecha y hora actuales
                Cadena = Cadena & FechaSQL(Now.Date) & "','"
                Cadena = Cadena & Now.Hour.ToString.PadLeft(2, "0") & ":" & Now.Minute.ToString.PadLeft(2, "0") & ":" & Now.Second.ToString.PadLeft(2, "0") & "','"
                'Extras autorizadas (si las trabajadas son menores, usar las extras trabajadas)
                Cadena = Cadena & IIf(HrsExt < ExtrasAutorizadas, HrsExt, ExtrasAutorizadas) & "','"
                'Comentario
                Cadena = Cadena & Mid(_comentario, 1, 100) & "','"
                'periodo_act y usuario
                Cadena = Cadena & Ano & Periodo & "A" & "','" & Usuario & "')"

                'Ejecutar cadena
                dtTemp = sqlExecute(Cadena, "TA")

                If AutorizarExtra And HtoD(HrsExt) > 0 Then
                    'Si hay horas extras autorizadas, registrar en la tabla que ya se analizaron
                    sqlExecute("UPDATE extras_autorizadas SET analizado = 1,extras_reales = '" & HrsExt & _
                               "' WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(Fecha) & "'", "TA")
                End If
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "AnalisisTA", ex.HResult, ex.Message)

        End Try
    End Sub

   

    Public Function RestaHrs(HoraIni As String, HoraFin As String, Optional cafeteria As Boolean = False) As String
        Try
            Dim _tiempo As String = "**.**"
            Dim _positivo As Boolean = True
            Dim _segundos As Integer
            Dim _horas As Decimal
            Dim _frac_horas As String
            Dim _minutos As String

            _segundos = DateDiff(DateInterval.Second, Convert.ToDateTime(HoraIni), Convert.ToDateTime(HoraFin))
            If _segundos < 0 Then
                _positivo = False
                _segundos = Math.Abs(_segundos)
            End If
            _horas = _segundos / 3600
            If _horas > 12 And Not cafeteria Then
                _horas = 24 - _horas
            End If

            If _horas <= 99 Then
                _frac_horas = _horas - Int(_horas)
                _minutos = Math.Round((_horas - Int(_horas)) * 60, 0)
                _tiempo = Int(_horas).ToString.PadLeft(2, "0") & ":" & Int(_minutos).ToString.PadLeft(2, "0")
            End If

            If Not _positivo Then _tiempo = "-" + _tiempo
            Return _tiempo
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return "**:**"
        End Try
    End Function

    Public Function RestaHrs(FechaIni As Date, HoraIni As String, FechaFin As Date, HoraFin As String) As String
        Dim EntradaCompleta As Date
        Dim SalidaCompleta As Date
        Dim Horas As Double
        Try
            EntradaCompleta = DateAdd(DateInterval.Second, HtoD(MerMilitar(HoraIni)) * 3600 + 1, FechaIni)
            SalidaCompleta = DateAdd(DateInterval.Second, HtoD(MerMilitar(HoraFin)) * 3600, FechaFin)

            'Calcula la diferencia en segundos, luego lo convierte a horas, redondeando a 2 decimales
            Horas = Math.Round(DateDiff(DateInterval.Second, EntradaCompleta, SalidaCompleta) / 3600, 2)
            'Antes de devolver el resultado, lo convierte a formato de hora en String
            Return DtoH(Horas)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Module.Name, ex.HResult, ex.Message)
            Return "**:**"
        End Try

    End Function

    Private Sub AnalisisHrsBrtPares(ByVal drEmpleado As DataRow, ByVal Ano As String, ByVal Periodo As String, ByVal FIni As Date, ByVal FFin As Date)
        Dim R As String
        Dim Rango As Double
        Dim dtHorario As New DataTable
        Dim Fecha As Date
        Dim Tipo As String

        Dim dtHrsBrt As New DataTable

        Try
            R = drEmpleado("reloj").ToString.Trim
            If DateDiff(DateInterval.Day, FIni, FFin) > 0 Then
                dtHorario = sqlExecute("SELECT MAX(rango_hrs) AS rango_hrs FROM dias LEFT JOIN personal " & _
                                           "ON dias.cod_comp = personal.cod_comp AND dias.cod_hora = personal.cod_hora " & _
                                           "WHERE reloj = '" & R & "'")
                Rango = HtoD(IIf(IsDBNull(dtHorario.Rows(0).Item("rango_hrs")), "03:00", dtHorario.Rows(0).Item("rango_hrs")))
            Else
                dtHorario = sqlExecute("SELECT rango_hrs FROM dias LEFT JOIN personal " & _
                                         "ON dias.cod_comp = personal.cod_comp AND dias.cod_hora = personal.cod_hora " & _
                                         "WHERE reloj = '" & R & "' and dia_ent = '" & DiaSem(FIni) & "'")
                Rango = HtoD(IIf(IsDBNull(dtHorario.Rows(0).Item("rango_hrs")), "03:00", dtHorario.Rows(0).Item("rango_hrs")))
            End If

            FIni = DateAdd(DateInterval.Hour, Rango, FIni)
            'Determinar la hora en que termina el día, de acuerdo al rango de horas definido
            FFin = DateAdd(DateInterval.Hour, Rango + 24, FFin)

            'dtHrsBrt = sqlExecute("SELECT reloj,fecha,hora FROM hrs_brt WHERE RELOJ ='" & R & "' AND fecha BETWEEN '" & FechaSQL(FIni) & "' AND '" & FechaSQL(FFin) & "'", "TA")

            dtHrsBrt = sqlExecute("SELECT reloj,fecha,hora,fecha_efva,entrada_salida FROM hrs_brt WHERE RELOJ ='" & R & "' AND CONVERT(char(11),fecha,23)+ hora >=  '" & _
                                  FechaHoraSQL(FIni, False, False) & "' AND CONVERT(char(11),fecha,23)+ hora <= '" & FechaHoraSQL(FFin, False, False) & "' order by (cast(fecha as datetime)+cast(hora as datetime))", "TA")
            Dim Inserta As Boolean = True
            Tipo = "S"
            For Each dHrs As DataRow In dtHrsBrt.Rows
                Inserta = True
                If Tipo = "S" Then
                    Fecha = dHrs("fecha")
                    'MCR 15/OCT/2015
                    'En descanso, se forzan pares, pero puede haber una salida del día anterior que se confunda
                    'ya que no se hace de toda la semana
                    'Si hay una salida con fecha_efva del día anterior, ignorarla
                    If Not IsDBNull(dHrs("fecha_efva")) And Not IsDBNull(dHrs("entrada_salida")) Then
                        If dHrs("fecha_efva") = DateAdd(DateInterval.Day, -1, Fecha) And dHrs("entrada_salida") = "S" Then
                            Inserta = False
                        End If
                    End If
                End If

                If Inserta Then
                    Tipo = IIf(Tipo = "E", "S", "E")
                    sqlExecute("UPDATE hrs_brt SET fecha_efva = '" & FechaSQL(Fecha) & "'" & IIf(True, ",entrada_salida = '" & Tipo & "'", "") & _
                               " WHERE RELOJ ='" & R & _
                               "' AND fecha = '" & FechaSQL(dHrs("fecha")) & "' AND hora = '" & dHrs("hora") & "'", "TA")
                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "AnalisisTA", ex.HResult, ex.Message)
        End Try

    End Sub

    Public Sub LlenaNomSem(ByVal drEmpleado As DataRow, Periodo As String)
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

            Dim dtTemp As New DataTable
            Dim dtAsist As New DataTable

            Dim R As String

            Dim Cadena As String = ""
            R = drEmpleado("reloj")

            'Borrar los datos que pudiera haber en nomsem
            sqlExecute("DELETE FROM nomsem WHERE reloj = '" & R & "' AND ano = '" & Periodo.Substring(0, 4) & "' AND periodo = '" & Periodo.Substring(4, 2) & "'", "TA")

            dtTemp = sqlExecute("SELECT festivo_sep,festivo_a_descanso FROM cias_ta WHERE cod_comp = '" & drEmpleado("cod_comp") & "'", "TA")
            If dtTemp.Rows.Count = 0 Then
                Exit Sub
                Debug.Print("Falta información de CiasTa para " & drEmpleado("cod_comp"))
            Else
                FestivoSeparado = IIf(IsDBNull(dtTemp.Rows(0).Item("festivo_sep")), True, dtTemp.Rows(0).Item("festivo_sep"))
                FestivoDescanso = IIf(IsDBNull(dtTemp.Rows(0).Item("festivo_a_descanso")), True, dtTemp.Rows(0).Item("festivo_a_descanso"))
            End If

            'Actualizar datos de personal que hay en asist, para todos los registros del periodo
            'De acuerdo a:
            '*** EL 23 ENERO 07 SUSY PIDIO QUE SE ACTUALIZARAN LOS DATOS DE TODA LA SEMANA
            '*** IVO

            Cadena = "UPDATE asist SET cod_comp = '" & drEmpleado("cod_comp") & "',"
            Cadena = Cadena & " cod_depto = '" & drEmpleado("cod_depto") & "', cod_puesto = '" & drEmpleado("cod_puesto") & "', cod_tipo = '" & drEmpleado("cod_tipo") & "',"
            Cadena = Cadena & " cod_super = '" & drEmpleado("cod_super") & "', cod_turno = '" & drEmpleado("cod_turno") & "', cod_clase = '" & drEmpleado("cod_clase") & "'"
            Cadena = Cadena & " WHERE reloj = '" & R & "' AND ano = '" & Periodo.Substring(0, 4) & "' AND periodo = '" & Periodo.Substring(4, 2) & "'"
            dtTemp = sqlExecute(Cadena, "TA")

            dtAsist = sqlExecute("SELECT MIN(pareja) as pareja,MAX(ausentismo) as ausentismo," & _
                                 "SUM(dbo.htod(extras_autorizadas)) as extras_autorizadas," & _
                                 "SUM(dbo.HTOD(horas_normales)) AS horas_normales," & _
                                 "SUM(dbo.HTOD(horas_tarde)) AS horas_tarde," & _
                                 "SUM(dbo.HTOD(horas_convenio)) AS horas_convenio," & _
                                 "fha_ent_hor,MIN(fecha_entro) AS fecha_entro,MIN(entro) AS entro FROM asist " & _
                                 "WHERE ano = '" & Periodo.Substring(0, 4) & "' AND periodo = '" & Periodo.Substring(4, 2) & _
                                  "' AND reloj = '" & R & "'  GROUP BY FHA_ENT_HOR", "TA")
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
                    Dim Aplica33 As Integer = sqlExecute("select isnull(regla_33, 0) as regla_33 from cias_ta where cod_comp = '" & _
                                                         drEmpleado("cod_comp") & "'", "ta").Rows(0)("regla_33")
                    If Aplica33 Then
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

                ''Si las horas normales son >45, y es empleado tipo 3, dejar en 45
                'If hrs_normal > 45 And drEmpleado("cod_tipo") = "3" Then
                '    hrs_normal = 45
                'End If

                'Revisar si todos tienen pareja
                pareja = pareja And (drAsist("pareja") = 1)

                'If Not EsDescanso Then
                '    'Evaluar asistencia perfecta
                '    asistencia_perfecta = asistencia_perfecta And BonoAsistenciaPerfecta(drEmpleado, Periodo)
                '    'Evaluar bono de asistencia
                '    bono_asistencia = bono_asistencia And BonoAsistencia(drAsist, Periodo)
                '    'Evaluar bono de puntualidad
                '    bono_puntualidad = bono_puntualidad And BonoPuntualidad(drAsist, Periodo)
                'End If

                'Revisar si hubo ausentismo
                ausentismo = ausentismo And (IIf(IsDBNull(drAsist("ausentismo")), 0, drAsist("ausentismo")) = 1)
            Next


            'CALCULO DE BONOS BRP (ABRAHAM)
            BONASI = bonos_asistencia(R, Periodo)
            BONPUN = bonos_puntualidad(R, Periodo)
            BONDES = bonos_cupon(R, Periodo)

            dtTemp = sqlExecute("SELECT DISTINCT FHA_ENT_HOR FROM asist WHERE ano = '" & Periodo.Substring(0, 4) & "' AND periodo = '" & Periodo.Substring(4, 2) & _
                                  "' AND reloj = '" & R & "' AND RTRIM(entro) <>'' and RTRIM(salio) <> ''", "TA")
            DiasTrab = dtTemp.Rows.Count

            sqlExecute("INSERT INTO nomsem (reloj,ano,periodo,tran_cerrada) VALUES ('" & R & "','" & Periodo.Substring(0, 4) & "','" & Periodo.Substring(4, 2) & "',0)", "TA")

            ActualizaNomSem(R, "hrs_normales_original", hrs_normal)
            ActualizaNomSem(R, "hrs_festivo_original", hrs_festivo)


            If True Then
                ActualizaNomSem(R, "hrs_normales", hrs_normal)

                ActualizaNomSem(R, "hrs_dobles", hrs_dobles)
                ActualizaNomSem(R, "hrs_triples", hrs_triples)

                ActualizaNomSem(R, "hrs_prim_dom", hrs_prim_dom)
                ActualizaNomSem(R, "hrs_descanso", hrs_descanso)
                ActualizaNomSem(R, "hrs_festivo", hrs_festivo)


                ActualizaNomSem(R, "dobles_33", dobles_33)
                ActualizaNomSem(R, "triples_33", triples_33)
            Else
                'MCR 11/NOV/2015
                'Si no se editaron horas manualmente, tomar calculadas
                If Semana.Mixto Then
                    ActualizaNomSem(R, "hrs_normales", hrs_normal * Semana.Factor)
                    ActualizaNomSem(R, "hrs_festivo", hrs_festivo * Semana.Factor)
                Else
                    ActualizaNomSem(R, "hrs_normales", hrs_normal)
                    ActualizaNomSem(R, "hrs_festivo", hrs_festivo)
                End If

                ActualizaNomSem(R, "hrs_dobles", hrs_dobles)
                ActualizaNomSem(R, "hrs_triples", hrs_triples)
                ActualizaNomSem(R, "hrs_prim_dom", hrs_prim_dom)
                ActualizaNomSem(R, "hrs_descanso", hrs_descanso)
                ActualizaNomSem(R, "dobles_33", DoblesIntegrables)
                ActualizaNomSem(R, "triples_33", TriplesIntegrables)
            End If
            ActualizaNomSem(R, "hrs_convenio", hrs_conv)
            ActualizaNomSem(R, "hrs_tarde", hrs_tarde)
            ActualizaNomSem(R, "pareja", IIf(pareja, 1, 0))
            ActualizaNomSem(R, "semana", Semana.NumSemana)
            ActualizaNomSem(R, "dias_trabajados", DiasTrab)


            ' ORDEN IMPORTANTE!!
            ActualizaNomSem(R, "bono01", BONASI)
            ActualizaNomSem(R, "bono02", BONPUN)

            ActualizaNomSem(R, "bono_asistencia", BONASI)
            ActualizaNomSem(R, "bono_puntualidad", BONPUN)


            ActualizaNomSem(R, "bono03", BONDES)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "AnalisisTA", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ActualizaNomSem(R As String, Campo As String, Valor As String)
        Try
            sqlExecute("UPDATE nomsem SET " & Campo & " = " & Valor & " WHERE ano = '" & _anoNomSem & _
                       "' AND periodo = '" & _periodoNomSem & "' AND reloj = '" & R & "'", "TA")
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "AnalisisTA", ex.HResult, ex.Message)
        End Try
    End Sub

  

End Class