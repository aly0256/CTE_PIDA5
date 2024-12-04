

Public Class frmImportaciondatos
    Dim Archivo As String
    Dim dtPeriodos As New DataTable
    Dim dtUbicacion As New DataTable
    Dim dtCias As New DataTable
    Dim dtTipoPeriodo As New DataTable


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtTemp As New DataTable
        Try
            dtCias = sqlExecute("SELECT cod_comp,nombre FROM cias ORDER BY cia_default DESC,cod_comp")
            cmbCia.DataSource = dtCias
            cmbCia.SelectedIndex = 0
            cmbCia.Enabled = False

            dtTipoPeriodo = sqlExecute("select * from tipo_periodo")
            cmbTipoPeriodo.DataSource = dtTipoPeriodo
            Try
                cmbTipoPeriodo.SelectedIndex = 1
                cmbTipoPeriodo.SelectedIndex = 0
            Catch ex As Exception

            End Try

            dtUbicacion = sqlExecute("SELECT TOP 1 * FROM importar", "nomina")
            If dtUbicacion.Rows.Count = 0 Then
                sqlExecute("INSERT INTO importar (fecha_hora) VALUES (GETDATE())", "nomina")
            End If
            txtRecib.Text = IIf(IsDBNull(dtUbicacion.Rows(0).Item("nomina")), "", dtUbicacion.Rows(0).Item("nomina"))
            txtGenerales.Text = IIf(IsDBNull(dtUbicacion.Rows(0).Item("retiros")), "", dtUbicacion.Rows(0).Item("retiros"))

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click

        Dim dtInfo As New DataTable
        Dim dtTempC As New DataTable

        Dim Metodo As String

        Dim _anoPer As String = ""
        Dim S As Integer
        Dim _ano As String
        Dim _periodo As String

        Dim N As Integer = 0
        Dim M As Integer = 0
        Dim T As Double = 0

        Try
            _anoPer = cmbPeriodos.SelectedValue
            _ano = _anoPer.Substring(0, 4)
            _periodo = _anoPer.Substring(4, 2)

            'Validar que los archivos existan
            If Dir(txtRecib.Text.Trim) = "" Then
                MessageBox.Show("El archivo seleccionado para carga de nómina no existe. Favor de verificar.", "Archivo no existente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtRecib.Focus()
                Exit Sub
            End If

            If Dir(txtGenerales.Text.Trim) = "" Then
                MessageBox.Show("El archivo seleccionado para carga de datos generales no existe. Favor de verificar.", "Archivo no existente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtGenerales.Focus()
                Exit Sub
            End If

            If Dir(txtPensiones.Text.Trim) = "" Then
                MessageBox.Show("El archivo seleccionado para carga de pensiones alimenticias no existe. Favor de verificar.", "Archivo no existente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtPensiones.Focus()
                Exit Sub
            End If

            'Revisar si se encuentran datos del periodo
            dtInfo = sqlExecute("SELECT TOP 1 reloj FROM nomina WHERE cod_comp = '" & cmbCia.SelectedValue & "' AND ano = '" & _
                                _anoPer.Substring(0, 4) & "' AND periodo = '" & _anoPer.Substring(4, 2) & "'", "nomina")
            If dtInfo.Rows.Count > 0 Then
                MessageBox.Show("Este periodo ya se encuentra cargado, es necesario borrarlo e intentar nuevamente.", "Periodo ya existente", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                'Revisar si es periodo especial
                If cmbPeriodos.SelectedValue.ToString.Substring(4, 2) > "53" Then
                    AnoSelec = cmbPeriodos.SelectedValue.ToString.Substring(0, 4)
                    PeriodoSelec = cmbPeriodos.SelectedValue.ToString.Substring(4, 2)

                    'Si es periodo especial, solicitar el detalle
                    If frmInfoPeriodosEspeciales.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
                        Exit Sub
                    End If
                End If

                dtTempC = sqlExecute("SELECT metodo_pago_deducciones FROM parametros")
                If dtTempC.Rows.Count > 0 Then
                    Metodo = IIf(IsDBNull(dtTempC.Rows(0).Item(0)), "O", dtTempC.Rows(0).Item(0))
                Else
                    Metodo = "O"
                End If

                If MessageBox.Show("Se cargarán los datos a la nómina. ¿Está seguro de continuar?", "Carga de nómina", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = vbYes Then
                    btnActualizar.Enabled = False
                    BtnBorrar.Enabled = False
                    btnSalir.Enabled = False

                    'Guardar información en la tabla de importar, para cargas posteriores
                    sqlExecute("UPDATE importar SET nomina = '" & txtRecib.Text & "', retiros = '" & txtGenerales.Text & "', fecha_hora = GETDATE(), ano = '" & _ano & "', periodo = '" & _periodo & "'", "nomina")

                    '*** ERRORES QUE PUEDEN RESULTAR ****
                    'S > 0  No hubo errores
                    'S = -1 Errores en la carga
                    'S = -5 Se canceló selección de archivo 

                    'Cargar información de nómina
                    S = CargaArchivo()

                    ' Abraham - Validar los netos antes de continuar
                    dtTemporal = sqlExecute("SELECT SUM(monto) FROM movimientos WHERE ano = '" & _ano & "' AND periodo = '" & _periodo & "' AND concepto = 'NETO'", "nomina")
                    If dtTemporal.Rows.Count > 0 Then
                        T = IIf(IsDBNull(dtTemporal.Rows(0).Item(0)), 0, dtTemporal.Rows(0).Item(0))
                    End If

                    ' Validacion de netos
                    Dim diferencia As Double = RoundUp(T, 2) - RoundUp(NETO_CAPTURA, 2)
                    If (diferencia * diferencia) >= 1 Then
                        MessageBox.Show("Has cargado una nómina con una diferencia de " & FormatCurrency(diferencia) & ", los datos serán eliminados. Favor de revisar", "Diferencias en la carga", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        'Borrar los movimientos del periodo, que correspondan a la compañía seleccionada
                        sqlExecute("DELETE FROM MOVIMIENTOS WHERE ano = '" & _ano & "' AND periodo='" & _periodo & "' AND reloj IN " & _
                                   "(SELECT reloj FROM nomina WHERE cod_comp = '" & cmbCia.SelectedValue & "' AND ano = '" & _ano & "' AND periodo='" & _
                                   _periodo & "')", "nomina")

                        'Borrar los movimientos provisionados del periodo, que correspondan a la compañía seleccionada
                        sqlExecute("DELETE FROM movtos_provision WHERE ano = '" & _ano & "' AND periodo='" & _periodo & "' AND reloj IN " & _
                                   "(SELECT reloj FROM nomina WHERE cod_comp = '" & cmbCia.SelectedValue & "' AND ano = '" & _ano & "' AND periodo='" & _
                                   _periodo & "')", "nomina")

                        'Borrar los registros de la nómina del periodo y compañía seleccionados
                        sqlExecute("DELETE FROM NOMINA WHERE cod_comp = '" & cmbCia.SelectedValue & "' AND ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")

                        'PRUEBAS
                        'S = -5
                    End If

                    If S >= 0 Then
                        S = complementar_periodo()
                    End If

                    'Si no hubo errores, cargar generales
                    If S >= 0 Then
                        S = cargar_generales()
                    End If

                    'Si no hubo errores, cargar pensiones
                    If Dir(txtPensiones.Text.Trim) <> "" Then
                        If S >= 0 Then
                            S = cargar_pensiones()
                        End If
                    End If



                    'Abraham Casas
                    'Por el momento en BRP todo esto queda pendiente
                    ''Si no hubo errores, cargar deducciones al maestro
                    'If S >= 0 Then
                    '    S = AplicarDeducciones(Metodo)
                    'End If

                Else
                    S = -5
                End If

                If S >= 0 Then
                    'Actualizar tabla de 'PERMITIR PRESTAMOS' para activar
                    'si la semana de inicio de préstamos es anterior al periodo cargado
                    sqlExecute("UPDATE parametros SET permitir_prestamos = 1 WHERE semana_inicio_prestamos<='" & _anoPer & "'")


                    lblReloj.Text = "Calculando totales..."
                    My.Application.DoEvents()

                    dtTemporal = sqlExecute("SELECT SUM(1) FROM nomina WHERE ano = '" & _ano & "' AND periodo = '" & _periodo & "'", "nomina")
                    If dtTemporal.Rows.Count > 0 Then
                        N = IIf(IsDBNull(dtTemporal.Rows(0).Item(0)), 0, dtTemporal.Rows(0).Item(0))
                    End If

                    dtTemporal = sqlExecute("SELECT SUM(1) FROM movimientos WHERE ano = '" & _ano & "' AND periodo = '" & _periodo & "'", "nomina")
                    If dtTemporal.Rows.Count > 0 Then
                        M = IIf(IsDBNull(dtTemporal.Rows(0).Item(0)), 0, dtTemporal.Rows(0).Item(0))
                    End If

                    dtTemporal = sqlExecute("SELECT SUM(monto) FROM movimientos WHERE ano = '" & _ano & "' AND periodo = '" & _periodo & "' AND concepto = 'NETO'", "nomina")
                    If dtTemporal.Rows.Count > 0 Then
                        T = IIf(IsDBNull(dtTemporal.Rows(0).Item(0)), 0, dtTemporal.Rows(0).Item(0))
                    End If
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            gpAvance.Visible = False
            btnActualizar.Enabled = True
            btnSalir.Enabled = True
            BtnBorrar.Enabled = True

            If S = -5 Then
                MessageBox.Show("La carga de nómina fue cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf S < 0 Then
                MessageBox.Show("La nómina no pudo ser cargada, porque se encontró algún error durante el proceso. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("La nómina del periodo " & _anoPer & " fue cargada exitosamente, con los siguientes resultados: " & vbCrLf & vbCrLf & _
                                "     Registros de nómina: " & N & vbCrLf & _
                                "     Movimientos: " & M & vbCrLf & _
                                "     Neto total: " & FormatCurrency(T), "Carga finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Try
    End Sub


    Private Sub BorraNomina()
        Dim _ano As String
        Dim _periodo As String
        Dim dtinfo As New DataTable

        Try

            _ano = cmbPeriodos.SelectedValue.ToString.Substring(0, 4)
            _periodo = cmbPeriodos.SelectedValue.ToString.Substring(4, 2)

            dtinfo = sqlExecute("SELECT TOP 1 * FROM nomina WHERE cod_comp = '" & cmbCia.SelectedValue & "' AND ano = '" & _ano & _
                                "' and periodo='" & _periodo & "'", "nomina")
            If dtinfo.Rows.Count = 0 Then
                MessageBox.Show("No existe este periodo.", "Borrar datos de nómina", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                'Borrar los movimientos del periodo, que correspondan a la compañía seleccionada
                sqlExecute("DELETE FROM MOVIMIENTOS WHERE ano = '" & _ano & "' AND periodo='" & _periodo & "' AND reloj IN " & _
                           "(SELECT reloj FROM nomina WHERE cod_comp = '" & cmbCia.SelectedValue & "' AND ano = '" & _ano & "' AND periodo='" & _
                           _periodo & "')", "nomina")

                'Borrar los movimientos provisionados del periodo, que correspondan a la compañía seleccionada
                sqlExecute("DELETE FROM movtos_provision WHERE ano = '" & _ano & "' AND periodo='" & _periodo & "' AND reloj IN " & _
                           "(SELECT reloj FROM nomina WHERE cod_comp = '" & cmbCia.SelectedValue & "' AND ano = '" & _ano & "' AND periodo='" & _
                           _periodo & "')", "nomina")


                sqlExecute("DELETE FROM pensiones_alimenticias WHERE cod_comp = '" & cmbCia.SelectedValue & "' and ano = '" & _ano & "' AND periodo='" & _periodo & "'", "nomina")


                'Borrar los registros de la nómina del periodo y compañía seleccionados
                sqlExecute("DELETE FROM NOMINA WHERE cod_comp = '" & cmbCia.SelectedValue & "' AND ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")

                MessageBox.Show("Nómina borrada satisfactoriamente.", "Borrar nómina", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Los datos de la nómina correspondiente al periodo " & cmbPeriodos.SelectedValue & " no pudieron ser eliminados. Favor de verificar.", "Borrar nómina", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Dim NETO_CAPTURA As Double
    Private Function CargaArchivo() As Integer
        Dim _reloj_compa As String
        Dim _reloj As String
        Dim _Concepto As String
        Dim _monto As Double
        Dim _signo As String
        Dim _tipodep As String
        Dim _planta As String
        Dim _ano As String
        Dim _periodo As String
        Dim _cod_tipo_nomina As String
        Dim _fecha_ini As Date
        Dim _fecha_fin As Date

        Dim dtinfo As New DataTable

        Dim LN As String
        Dim _fbaja As String
        Dim x As Integer
        Dim y As Integer
        Dim p As Double
        Dim d As Integer = 0
        Dim Cadena As String
        Dim dtUpdate As New DataTable
        Dim dtNomina As New DataTable
        Dim dtPersonal As New DataTable
        Dim dRow As DataRow
        Dim dtNoRelacionados As New DataTable

        'Tabla para guardar los conceptos no localizados en la tabla
        dtNoRelacionados.Columns.Add("reloj")
        dtNoRelacionados.Columns.Add("concepto")

        _ano = cmbPeriodos.SelectedValue.ToString.Substring(0, 4)
        _periodo = cmbPeriodos.SelectedValue.ToString.Substring(4, 2)

        dtinfo = sqlExecute("SELECT fecha_ini,fecha_fin FROM periodos where  ano = '" & _ano & "' and periodo='" & _periodo & "'", "ta")
        _fecha_ini = dtinfo.Rows(0).Item("fecha_ini")
        _fecha_fin = dtinfo.Rows(0).Item("fecha_fin")

        '*** agregar datos a movimientos y a nómina ****
        Dim objReader As System.IO.StreamReader = Nothing

        Try
            Archivo = txtRecib.Text.Trim

            If System.IO.File.Exists(Archivo) = False Then
                MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return -10
            End If


            NETO_CAPTURA = 0
            Dim captura As New frmCapturaNeto
            If captura.ShowDialog() = Windows.Forms.DialogResult.OK Then
                NETO_CAPTURA = Double.Parse(captura.TextBox1.Text)
            Else
                Return -5
            End If

            Dim consecutivo_dap As String = "00"
            Try
                Dim dtDAP As DataTable = sqlExecute("select * from bitacora_dap where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                If dtDAP.Rows.Count > 0 Then
                    consecutivo_dap = dtDAP.Rows(0)("consecutivo")
                Else
                    sqlExecute("insert into bitacora_dap (ano, periodo, incluir_penali, consecutivo) values ('" & _ano & "', '" & _periodo & "', '1', '" & consecutivo_dap & "')", "nomina")
                End If
            Catch ex As Exception

            End Try

            objReader = New System.IO.StreamReader(Archivo)

            x = 0
            y = objReader.BaseStream.Length
            cpActualizacion.Maximum = 100
            gpAvance.visible = True
            _reloj_compa = ""

            LongReloj = 5

            Do Until objReader.EndOfStream
                LN = objReader.ReadLine
                If IsNumeric(LN.Substring(0, 3)) Then
                    x = x + LN.Length
                    p = (x / y) * 100

                    cpActualizacion.Value = Math.Truncate(p)
                    'cpActualizacion.ProgressText = Math.Truncate(p)
                    LN = LN.Replace(",", "")
                    LN = LN.PadRight(50, Space(1))

                    _reloj = LN.Substring(0, LongReloj).PadLeft(6, "0")
                    _Concepto = LN.Substring(LongReloj, 6)
                    _monto = Val(LN.Substring(LongReloj + 6, 12))
                    _signo = LN.Substring(LongReloj + 18, 1)
                    _tipodep = LN.Substring(LongReloj + 24, 1)
                    If LN.Length > LongReloj + 27 Then
                        _planta = LN.Substring(LongReloj + 25, 2)
                    Else
                        _planta = ""
                    End If

                    _cod_tipo_nomina = "N"

                    If _signo = "-" Then
                        _monto = _monto * (-1)
                    End If

                    lblReloj.Text = "Reloj " & _reloj
                    Application.DoEvents()

                    dtTemporal = sqlExecute("SELECT concepto FROM conceptos WHERE concepto = '" & _Concepto & "'", "nomina")
                    If dtTemporal.Rows.Count = 0 Then
                        'Si el concepto no existe, solicitar la información para insertarlo en la tabla
                        NvoConcepto = _Concepto
                        If frmConceptoNVO.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                            'Si se canceló la captura del concepto, activar el botón de borrar 
                            '(es opcional borrar lo que se haya cargado, pero no se puede cargar nuevamente sin borrar lo existente del periodo)
                            BtnBorrar.PerformClick()
                            'Independientemente de lo que resulte del borrado, salir del procedimiento. 
                            'No se puede continuar si un concepto no está registrado
                            Return -5
                        End If
                    End If

                    If _reloj_compa <> _reloj Then
                        dtPersonal = sqlExecute("select reloj, nombres, sactual, integrado, " & _
                                                " cod_comp, cod_planta, cod_depto, cod_turno, cod_puesto, " & _
                                                " cod_super, cod_hora, cod_tipo, cod_clase, " & _
                                                " alta, baja from personalvw where reloj = '" & _reloj & "'")
                        _reloj_compa = _reloj
                    End If

                    If dtPersonal.Rows.Count > 0 Then
                        dRow = dtPersonal.Rows(0)
                        'dtpersonal.rows(0).item("reloj")
                        sqlExecute("INSERT INTO movimientos (ano,periodo,tipo_nomina,reloj,concepto,monto) VALUES ('" & _
                                 _ano & "','" & _periodo & "', 'N','" & _reloj & "','" & _Concepto & "'," & _monto & ")", "nomina")

                        dtNomina = sqlExecute("SELECT reloj FROM nomina where  reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                        If dtNomina.Rows.Count = 0 Then

                            '' Para que las bajas de la semana se marquen como finiquitos aunque no tengan ningun pago 
                            If Not IsDBNull(dRow("baja")) Then
                                _fbaja = "'" & FechaSQL(dRow("baja")) & "'"
                                If dRow("baja") >= _fecha_ini And dRow("baja") <= _fecha_fin Then
                                    'nada
                                Else
                                    Dim fBaja As Date = Date.Parse(dRow("baja"))
                                    If fBaja > _fecha_fin Then
                                        _fbaja = "NULL"
                                    End If
                                End If
                            Else
                                _fbaja = "NULL"
                            End If

                            Cadena = "INSERT INTO nomina (" & _
                                "periodo, " & _
                                "ano," & _
                                "reloj," & _
                                "nombres," & _
                                "sactual," & _
                                "integrado," & _
                                "cod_depto," & _
                                "cod_turno," & _
                                "cod_puesto," & _
                                "cod_super," & _
                                "cod_hora," & _
                                "cod_tipo," & _
                                "cod_clase," & _
                                "alta," & _
                                "baja," & _
                                "cod_pago," & _
                                "deposito," & _
                                "periodo_act," & _
                                "cod_planta," & _
                                "cod_comp," & _
                                "cod_tipo_nomina)"

                            Cadena = Cadena & " VALUES (" & _
                                "'" & _periodo & "'," & _
                                "'" & _ano & "'," & _
                                "'" & _reloj & "'," & _
                                "'" & dRow("nombres") & "'," & _
                                IIf(IsDBNull(dRow("sactual")), 0, dRow("sactual")) & "," & _
                                IIf(IsDBNull(dRow("integrado")), 0, dRow("integrado")) & "," & _
                                "'" & dRow("cod_depto") & "'," & _
                                "'" & dRow("cod_turno") & "'," & _
                                "'" & dRow("cod_puesto") & "'," & _
                                "'" & dRow("cod_super") & "'," & _
                                "'" & dRow("cod_hora") & "'," & _
                                "'" & dRow("cod_tipo") & "'," & _
                                "'" & dRow("cod_clase") & "'," & _
                                "'" & FechaSQL(dRow("alta")) & "'," & _
                                _fbaja & "," & _
                                "'" & _tipodep & "'," & _
                                IIf(_tipodep = "D", 1, 0) & "," & _
                                "'" & _ano + _periodo & "'," & _
                                "'" & dRow("cod_planta") & "'," & _
                                "'" & dRow("cod_comp") & "'," & _
                                "'" & _cod_tipo_nomina & "')"
                            sqlExecute(Cadena, "nomina")

                        End If
                        'fechasql  convierte a ano,mes dia  asi lo identifica sql

                        If _Concepto = "PEREX2" Or _Concepto = "PEREX3" Then
                            Dim dtExistePEXNOR As DataTable = sqlExecute("select * from movimientos where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "' and concepto = 'PEXNOR'", "nomina")
                            If dtExistePEXNOR.Rows.Count = 0 Then
                                sqlExecute("INSERT INTO movimientos (ano,periodo,tipo_nomina,reloj,concepto,monto) VALUES ('" & _
                                 _ano & "','" & _periodo & "', 'N','" & _reloj & "','" & "PEXNOR" & "'," & 0 & ")", "nomina")
                            End If

                            Dim dtExistePEXTRA As DataTable = sqlExecute("select * from movimientos where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "' and concepto = 'PEXTRA'", "nomina")
                            If dtExistePEXTRA.Rows.Count = 0 Then
                                sqlExecute("INSERT INTO movimientos (ano,periodo,tipo_nomina,reloj,concepto,monto) VALUES ('" & _
                                 _ano & "','" & _periodo & "', 'N','" & _reloj & "','" & "PEXTRA" & "'," & 0 & ")", "nomina")
                            End If
                        End If

                        Select Case _Concepto
                            Case "HRSNOR"
                                sqlExecute("UPDATE nomina set horas_normales =" & _monto & " where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                            Case "HRSEX2"
                                sqlExecute("UPDATE nomina set horas_dobles = " & _monto & " where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                            Case "HRSEX3"
                                sqlExecute("UPDATE nomina set horas_triples =" & _monto & " where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                            Case "HRSFES"
                                sqlExecute("UPDATE nomina set horas_festivas =" & _monto & " where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                            Case "HRSDOM"
                                sqlExecute("UPDATE nomina set horas_domingo =" & _monto & " where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                            Case "HRSCOM"
                                sqlExecute("UPDATE nomina set horas_compensa =" & _monto & " where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                            Case "DIASVA"
                                sqlExecute("UPDATE nomina set dias_vac =" & _monto & " where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                            Case "DIASAG"
                                sqlExecute("UPDATE nomina set dias_agui =" & _monto & " where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                            Case "PERAGI"
                                sqlExecute("UPDATE nomina set cod_tipo_nomina ='F' where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                            Case "PEREX2"
                                sqlExecute("UPDATE movimientos set monto = monto + '" & _monto - RoundUp(_monto * 0.5, 2) & "' where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "' and concepto = 'PEXNOR'", "nomina")
                                sqlExecute("UPDATE movimientos set monto = monto + '" & RoundUp(_monto * 0.5, 2) & "' where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "' and concepto = 'PEXTRA'", "nomina")
                            Case "PEREX3"                                
                                sqlExecute("UPDATE movimientos set monto = monto + '" & _monto & "' where reloj='" & _reloj & "' and ano = '" & _ano & "' and periodo='" & _periodo & "' and concepto = 'PEXTRA'", "nomina")
                        End Select
                    End If
                End If
                'Application.DoEvents()
            Loop
            lblReloj.Text = ""
            CalculaNetos(_ano, _periodo)

            gpAvance.visible = False
            Application.DoEvents()
            objReader.Close()

            Return dtNoRelacionados.Rows.Count
        Catch ex As Exception
            lblReloj.Text = ""
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            Return -1
        Finally
            d = 1
        End Try
    End Function

    Private Function complementar_periodo() As Integer
        Try

            Dim _ano As String = cmbPeriodos.SelectedValue.ToString.Substring(0, 4)
            Dim _periodo As String = cmbPeriodos.SelectedValue.ToString.Substring(4, 2)

            ' Antes de complementar de la bitacora, insertar faltantes en periodos normales
            Dim dtInfoPeriodo As DataTable = sqlExecute("select ano, periodo, fecha_ini, fecha_fin from periodos where ano = '" & _ano & "' and periodo = '" & _periodo & "' and isnull(periodo_especial, 0) = 0", "TA")
            If dtInfoPeriodo.Rows.Count > 0 Then

                Dim fecha_ini As Date = dtInfoPeriodo.Rows(0)("fecha_ini")
                Dim fecha_fin As Date = dtInfoPeriodo.Rows(0)("fecha_fin")

                Dim dtFaltantes As DataTable = sqlExecute("select PERSONAL.reloj from PERSONAL.dbo.personal" & _
                Space(1) & "left join nomina.dbo.nomina on nomina.RELOJ = personal.RELOJ and ANO = '" & _ano & "' and PERIODO = '" & _periodo & "'" & _
                Space(1) & "where nomina.RELOJ is null and personal.COD_COMP = '" & cmbCia.SelectedValue & "' and personal.alta <= '" & FechaSQL(fecha_fin) & "' and (personal.baja is null or personal.BAJA >= '" & FechaSQL(fecha_ini) & "')")

                For Each row As DataRow In dtFaltantes.Rows

                    Dim dtPersonal As DataTable = sqlExecute("select reloj, nombres, sactual, integrado, " & _
                                               " cod_comp, cod_planta, cod_depto, cod_turno, cod_puesto, " & _
                                               " cod_super, cod_hora, cod_tipo, cod_clase, " & _
                                               " alta, baja from personalvw where reloj = '" & row("reloj") & "'")

                    Dim _fbaja As String
                    If Not IsDBNull(dtPersonal.Rows(0)("baja")) Then
                        _fbaja = "'" & FechaSQL(dtPersonal.Rows(0)("baja")) & "'"
                        If dtPersonal.Rows(0)("baja") >= fecha_ini And dtPersonal.Rows(0)("baja") <= fecha_ini Then
                            'nada
                        Else
                            Dim fBaja As Date = Date.Parse(dtPersonal.Rows(0)("baja"))
                            If fBaja > fecha_fin Then
                                _fbaja = "NULL"
                            End If
                        End If
                    Else
                        _fbaja = "NULL"
                    End If


                    If dtPersonal.Rows.Count > 0 Then
                        Dim drow As DataRow = dtPersonal.Rows(0)
                        Dim Cadena As String = "INSERT INTO nomina (" & _
                              "periodo, " & _
                              "ano," & _
                              "reloj," & _
                              "nombres," & _
                              "sactual," & _
                              "integrado," & _
                              "cod_depto," & _
                              "cod_turno," & _
                              "cod_puesto," & _
                              "cod_super," & _
                              "cod_hora," & _
                              "cod_tipo," & _
                              "cod_clase," & _
                              "alta," & _
                              "baja," & _
                              "cod_pago," & _
                              "deposito," & _
                              "periodo_act," & _
                              "cod_planta," & _
                              "cod_comp," & _
                              "cod_tipo_nomina)"

                        Cadena = Cadena & " VALUES (" & _
                            "'" & _periodo & "'," & _
                            "'" & _ano & "'," & _
                            "'" & row("reloj") & "'," & _
                            "'" & drow("nombres") & "'," & _
                            IIf(IsDBNull(drow("sactual")), 0, drow("sactual")) & "," & _
                            IIf(IsDBNull(drow("integrado")), 0, drow("integrado")) & "," & _
                            "'" & drow("cod_depto") & "'," & _
                            "'" & drow("cod_turno") & "'," & _
                            "'" & drow("cod_puesto") & "'," & _
                            "'" & drow("cod_super") & "'," & _
                            "'" & drow("cod_hora") & "'," & _
                            "'" & drow("cod_tipo") & "'," & _
                            "'" & drow("cod_clase") & "'," & _
                            "'" & FechaSQL(drow("alta")) & "'," & _
                            _fbaja & "," & _
                            "'" & "E" & "'," & _
                            0 & "," & _
                            "'" & _ano + _periodo & "'," & _
                            "'" & drow("cod_planta") & "'," & _
                            "'" & drow("cod_comp") & "'," & _
                            "'N')"
                        sqlExecute(Cadena, "nomina")

                        sqlExecute("UPDATE nomina set horas_normales =" & 0 & " where reloj='" & row("reloj") & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                        sqlExecute("UPDATE nomina set horas_dobles = " & 0 & " where reloj='" & row("reloj") & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                        sqlExecute("UPDATE nomina set horas_triples =" & 0 & " where reloj='" & row("reloj") & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                        sqlExecute("UPDATE nomina set horas_festivas =" & 0 & " where reloj='" & row("reloj") & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                        sqlExecute("UPDATE nomina set horas_domingo =" & 0 & " where reloj='" & row("reloj") & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                        sqlExecute("UPDATE nomina set horas_compensa =" & 0 & " where reloj='" & row("reloj") & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                        sqlExecute("UPDATE nomina set dias_vac =" & 0 & " where reloj='" & row("reloj") & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")
                        sqlExecute("UPDATE nomina set dias_agui =" & 0 & " where reloj='" & row("reloj") & "' and ano = '" & _ano & "' and periodo='" & _periodo & "'", "nomina")

                    End If

                Next

            End If

            Dim dtCambios As DataTable = sqlExecute(
                "select bitacora_personal.reloj, campo, ValorAnterior, ValorNuevo, fecha, fecha_mantenimiento from bitacora_personal " & _
                Space(1) & "left join nomina.dbo.nomina on nomina.reloj = bitacora_personal.reloj and nomina.ANO = '" & _ano & "' and nomina.PERIODO = '" & _periodo & "'" & _
                Space(1) & "left join ta.dbo.periodos on periodos.ANO = nomina.ano and periodos.periodo = nomina.periodo" & _
                Space(1) & "where bitacora_personal.fecha > periodos.fecha_fin and nomina.RELOJ is not null" & _
                Space(1) & "and campo in('nombres', 'cod_comp', 'cod_planta', 'cod_depto', 'cod_turno', 'cod_tipo', 'cod_clase')" & _
                Space(1) & "and tipo_movimiento in ('C') " & _
                Space(1) & "order by bitacora_personal.reloj, campo, fecha_mantenimiento desc, fecha desc")

            For Each row As DataRow In dtCambios.Rows
                sqlExecute("update nomina set " & RTrim(row("campo")) & " = '" & RTrim(row("valoranterior")) & "' where ano = '" & _ano & "' and periodo = '" & _periodo & "' and reloj = '" & row("reloj") & "'", "nomina")
            Next

            Return 1
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Function cargar_generales() As Integer
        Try
            Dim objReader As System.IO.StreamReader = Nothing

            Archivo = txtGenerales.Text.Trim

            If System.IO.File.Exists(Archivo) = False Then
                MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return -10
            End If

            Dim _ano As String = cmbPeriodos.SelectedValue.ToString.Substring(0, 4)
            Dim _periodo As String = cmbPeriodos.SelectedValue.ToString.Substring(4, 2)

            objReader = New System.IO.StreamReader(Archivo)

            Dim x As Long = 0
            Dim p As Double = 0
            Dim y As Long = objReader.BaseStream.Length
            cpActualizacion.Maximum = 100
            gpAvance.Visible = True

            LongReloj = 5

            'Campos a actualizar desde generales
            Dim _reloj As String

            Dim _fah_porc As Double ' porcentaje fondo de ahorro

            'infonavit
            Dim _info_cred As String
            Dim _info_porc As Double
            Dim _info_cuota As Double
            Dim _info_vsm As Double

            'tipo de proceso
            Dim _cvliq As String
            Dim _status As String
            Dim _tipo_nomina As String

            'datos generales
            Dim _sactual_grles As Double = 0
            Dim _integrado_grles As Double = 0

            Dim _depto_grles As String = ""
            Dim _turno_grles As String = ""
            Dim _clase_grles As String = ""
            Dim _tipo_grles As String = ""

            'cuenta de banco
            Dim _cuenta As String = ""
            Dim _cla_ban As String = ""
            Dim _tipo_pago As String = ""
            Dim _banco As Boolean

            Do Until objReader.EndOfStream
                Dim LN As String = objReader.ReadLine

                LN = LN.PadRight(301, Space(1))

                If IsNumeric(LN.Substring(0, 3)) Then
                    x = x + LN.Length
                    p = (x / y) * 100

                    cpActualizacion.Value = Math.Truncate(p)

                    '************

                    _reloj = LN.Substring(0, LongReloj).PadLeft(6, "0")

                    lblReloj.Text = "Reloj " & _reloj
                    Application.DoEvents()

                    '************

                    Try : _fah_porc = Val(LN.Substring(105, 2)) / 100 : Catch ex As Exception : _fah_porc = 0 : End Try 'ok

                    '************

                    Try : _info_cred = LN.Substring(210, 10) : Catch ex As Exception : _info_cred = "" : End Try
                    Try : _info_porc = Val(LN.Substring(102, 3)) / 10 : Catch ex As Exception : _info_porc = 0 : End Try
                    Try : _info_cuota = Val(LN.Substring(164, 7)) / 100 : Catch ex As Exception : _info_cuota = 0 : End Try
                    Try : _info_vsm = Val(LN.Substring(164, 7)) / 10000 : Catch ex As Exception : _info_vsm = 0 : End Try

                    If _info_porc = 0 Then
                        _info_cuota = 0
                    ElseIf _info_porc = 99.9 Then
                        _info_porc = 0
                        _info_vsm = 0
                    Else
                        _info_cuota = 0
                        _info_vsm = 0
                    End If

                    '************

                    Try : _cvliq = LN.Substring(122, 1) : Catch ex As Exception : _cvliq = "" : End Try
                    Try : _status = LN.Substring(299, 1) : Catch ex As Exception : _status = "" : End Try

                    _tipo_nomina = "N"
                    If _status = "B" Then
                        _tipo_nomina = "B"                    
                    End If

                    If _cvliq = "L" Then
                        _tipo_nomina = "F"
                    End If

                    '************

                    Try : _depto_grles = LN.Substring(142, 6) : Catch ex As Exception : _depto_grles = "" : End Try
                    Try : _turno_grles = LN.Substring(91, 1) : Catch ex As Exception : _turno_grles = "" : End Try

                    Try : _clase_grles = LN.Substring(101, 1) : Catch ex As Exception : _clase_grles = "" : End Try
                    _tipo_grles = IIf(_clase_grles = "2" Or _clase_grles = "3", "A", "O")

                    _clase_grles = IIf(_tipo_grles = "A", "A", IIf(_clase_grles = "0", "D", "I"))

                    Try : _sactual_grles = Val(LN.Substring(149, 7)) / 100 : Catch ex As Exception : _sactual_grles = 0 : End Try
                    Try : _integrado_grles = Val(LN.Substring(156, 7)) / 100 : Catch ex As Exception : _integrado_grles = 0 : End Try

                    Try : _cuenta = LN.Substring(228, 16) : Catch ex As Exception : _cuenta = "" : End Try
                    Try : _cla_ban = RTrim(LN.Substring(171, 3)) : Catch ex As Exception : _cla_ban = "" : End Try
                    Try : _tipo_pago = RTrim(LN.Substring(93, 1)) : Catch ex As Exception : _tipo_pago = "" : End Try

                    _banco = True

                    If _cla_ban <> "" And _tipo_pago = "D" Then
                        _banco = False
                    End If

                    If _tipo_pago = "" Then
                        _banco = False
                    End If


                    If _banco Then

                        _cuenta = _cuenta.Substring(6, 10)

                        If _cuenta.Contains("000000000") Then
                            _cuenta = ""
                        End If

                    Else
                        _cuenta = _cla_ban & _cuenta
                    End If

                    '************

                    sqlExecute("update nomina set cod_tipo_nomina  = '" & _tipo_nomina & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                    sqlExecute("update nomina set fah_porc  = '" & _fah_porc & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                    sqlExecute("update nomina set info_cred  = '" & _info_cred & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                    sqlExecute("update nomina set info_porc  = '" & _info_porc & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                    sqlExecute("update nomina set info_cuota  = '" & _info_cuota & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                    sqlExecute("update nomina set info_vsm  = '" & _info_vsm & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                    sqlExecute("update nomina set cod_depto  = '" & _depto_grles & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                    sqlExecute("update nomina set cod_turno  = '" & _turno_grles & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                    sqlExecute("update nomina set cod_clase  = '" & _clase_grles & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                    sqlExecute("update nomina set cod_tipo  = '" & _tipo_grles & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                    sqlExecute("update nomina set sactual = '" & _sactual_grles & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                    sqlExecute("update nomina set integrado = '" & _integrado_grles & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                    If _tipo_pago = "" Then
                        sqlExecute("update nomina set cuenta  = '" & "" & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                        sqlExecute("update nomina set cla_ban  = '" & "" & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                    Else
                        sqlExecute("update nomina set cuenta  = '" & _cuenta & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                        sqlExecute("update nomina set cla_ban  = '" & _cla_ban & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                    End If

                    'sqlExecute("update nomina set cuenta  = '" & _cuenta & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                    'sqlExecute("update nomina set cla_ban  = '" & _cla_ban & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                    sqlExecute("update nomina set banco  = " & IIf(_banco, "'01'", "null") & " where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                End If
                'Application.DoEvents()
            Loop

            Return 1
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Function cargar_pensiones() As Integer
        Try
            Dim objReader As System.IO.StreamReader = Nothing

            Archivo = txtPensiones.Text.Trim

            If System.IO.File.Exists(Archivo) = False Then
                MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return -10
            End If

            Dim _ano As String = cmbPeriodos.SelectedValue.ToString.Substring(0, 4)
            Dim _periodo As String = cmbPeriodos.SelectedValue.ToString.Substring(4, 2)
            Dim _cod_comp As String = cmbCia.SelectedValue

            objReader = New System.IO.StreamReader(Archivo)

            Dim x As Long = 0
            Dim p As Double = 0
            Dim y As Long = objReader.BaseStream.Length
            cpActualizacion.Maximum = 100
            gpAvance.Visible = True

            LongReloj = 5

            'Campos a actualizar desde generales
            Dim _reloj As String
            Dim _monto As Double = 0        
            Dim _cuenta As String
            Dim _nombre As String
            Dim _inter As String
            Dim _b As String

            Dim n_pension As Integer = 0

            Do Until objReader.EndOfStream
                Dim LN As String = objReader.ReadLine
                If IsNumeric(LN.Substring(0, 3)) Then
                    x = x + LN.Length
                    p = (x / y) * 100

                    cpActualizacion.Value = Math.Truncate(p)

                    _reloj = LN.Substring(0, LongReloj).PadLeft(6, "0")

                    lblReloj.Text = "Reloj " & _reloj
                    Application.DoEvents()

                    LN = LN.PadRight(120, Space(1))

                    Try : _monto = Val(LN.Substring(33, 10)) / 100 : Catch ex As Exception : _monto = 0 : End Try
                    Try : _cuenta = LN.Substring(14, 18) : Catch ex As Exception : _cuenta = "" : End Try 'ok                    
                    Try : _nombre = LN.Substring(43, 50) : Catch ex As Exception : _nombre = "" : End Try 'ok    
                    Try : _inter = LN.Substring(12, 2) : Catch ex As Exception : _inter = "99" : End Try 'ok    
                    Try : _b = RTrim(LN.Substring(99, 1)) : Catch ex As Exception : _b = "" : End Try 'ok    

                    'Condicion para determinar que una pension sea interbancaria
                    ' Longitud de la cuenta > 13

                    If _monto > 0 And _b = "" Then

                        sqlExecute("insert into pensiones_alimenticias (cod_comp, ano, periodo, reloj, pension) values ('" & _cod_comp & "', '" & _ano & "', '" & _periodo & "', '" & _reloj & "', '" & n_pension & "') ", "nomina")
                        sqlExecute("update pensiones_alimenticias set monto  = '" & _monto & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "' and pension = '" & n_pension & "'", "nomina")
                        sqlExecute("update pensiones_alimenticias set cuenta  = '" & _cuenta & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "' and pension = '" & n_pension & "'", "nomina")
                        sqlExecute("update pensiones_alimenticias set nombre  = '" & _nombre & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "' and pension = '" & n_pension & "'", "nomina")
                        sqlExecute("update pensiones_alimenticias set inter  = '" & IIf(_inter = "99", 0, 1) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "' and pension = '" & n_pension & "'", "nomina")

                        n_pension += 1

                    End If

                End If
                'Application.DoEvents()
            Loop

            Return 1
        Catch ex As Exception
            Return -1
        End Try
    End Function

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

        dtTemp = sqlExecute("SELECT concepto FROM conceptos WHERE concepto = 'TOTPER'", "nomina")
        If dtTemp.Rows.Count = 0 Then
            sqlExecute("INSERT INTO conceptos (cod_naturaleza,concepto,nombre,suma_neto,positivo,activo) VALUES (" & _
                       "'I','TOTPER','Total de percepciones',0,1,1)", "nomina")
        End If

        dtTemp = sqlExecute("SELECT concepto FROM conceptos WHERE concepto = 'TOTDED'", "nomina")
        If dtTemp.Rows.Count = 0 Then
            sqlExecute("INSERT INTO conceptos (cod_naturaleza,concepto,nombre,suma_neto,positivo,activo) VALUES (" & _
                       "'I','TOTDED','Total de deducciones',0,0,1)", "nomina")
        End If

        dtTemp = sqlExecute("SELECT concepto FROM conceptos WHERE concepto = 'NETO'", "nomina")
        If dtTemp.Rows.Count = 0 Then
            sqlExecute("INSERT INTO conceptos (cod_naturaleza,concepto,nombre,suma_neto,positivo,activo) VALUES (" & _
                       "'I','NETO','Neto',0,1,1)", "nomina")
        End If


        'Empleados en nómina, que no tengan NETO en movimientos
        dtNom = sqlExecute("SELECT reloj,cod_tipo_nomina FROM nomina WHERE nomina.ano = '" & _ano & "' AND nomina.periodo = '" & _periodo & "'" & _
                           "AND reloj NOT IN (SELECT reloj FROM movimientos WHERE concepto IN('NETO','TOTPER','TOTDED') AND ano = '" & _ano & "' " & _
                           "AND periodo = '" & _periodo & "' AND reloj = nomina.reloj)", "nomina")

        'Calcular netos, e insertarlos en movimientos
        cpActualizacion.Value = 0
        cpActualizacion.Maximum = 100
        y = dtNom.Rows.Count
        x = 0
        For Each dRow In dtNom.Rows
            lblReloj.Text = "Calculando neto " & dRow("reloj")
            x = x + 1
            p = (x / y) * 100

            cpActualizacion.Value = Math.Truncate(P)
            'cpActualizacion.ProgressText = Math.Truncate(P)
            My.Application.DoEvents()

            TotPer = TotalPercepciones(dRow("reloj"), _ano & _periodo)
            TotDed = TotalDeducciones(dRow("reloj"), _ano & _periodo)

            _monto = TotPer - TotDed

            If _monto < 0.01 Then
                _monto = 0
            End If

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

    End Sub

    ''' <summary>
    ''' Proceso para regresar la información al fin del periodo, revisando la bitácora
    ''' </summary>
    Private Function ConsultaBitacora(ByRef dtPersonal As DataTable, Ano As String, Periodo As String) As Boolean
        Dim dtInfoPer As New DataTable
        Dim dtBitacora As New DataTable
        Dim FechaTopeIni As Date
        Dim FechaTopeFin As Date
        Dim FechaMto As Date

        Try
            dtInfoPer = sqlExecute("SELECT fecha_ini,fecha_fin,ano,periodo FROM periodos WHERE ano+periodo = '" & Ano & Periodo & "'", "TA")
            'Fechas topes para buscar en el mantenimiento, lo que se haya generado en los mantenimientos de ese rango
            'La fecha tope inicial es un día después del fin del periodo
            FechaTopeIni = DateAdd(DateInterval.Day, 1, dtInfoPer.Rows(0).Item("fecha_fin"))
            'Fecha tope final, es 3 días después del fin del periodo
            FechaTopeFin = DateAdd(DateInterval.Day, 3, dtInfoPer.Rows(0).Item("fecha_fin"))

            'Revisar en la bitácora cuando se hizo el último mantenimiento en el rango
            dtBitacora = sqlExecute("SELECT MAX(fecha_mantenimiento) AS fecha FROM bitacora_personal WHERE fecha_mantenimiento " & _
                                    "BETWEEN '" & FechaSQL(FechaTopeIni) & "' AND '" & FechaSQL(FechaTopeFin) & "'")
            If dtBitacora.Rows.Count = 0 Then
                FechaMto = Now.Date
            Else
                FechaMto = IIf(IsDBNull(dtBitacora.Rows(0).Item("fecha")), Now.Date, dtBitacora.Rows(0).Item("fecha"))
            End If

            'Realizar para cada registro de la tabla
            For Each dRow As DataRow In dtPersonal.Rows
                '... con cada columna
                For Each dCol As DataColumn In dtPersonal.Columns
                    '.... excepto con el reloj
                    If dCol.ColumnName.ToLower <> "reloj" Then
                        'buscar si hay movimientos efectuados entre el mantenimiento y la fecha actual, y regresa el más antiguo
                        dtBitacora = sqlExecute("SELECT TOP 1 ValorAnterior FROM bitacora_personal WHERE " & _
                                                "fecha BETWEEN '" & FechaHoraSQL(DateAdd(DateInterval.Second, 1, FechaMto)) & _
                                                "' AND '" & FechaHoraSQL(Now) & "'" & _
                                                " AND reloj = '" & dRow("reloj") & "' and campo = '" & dCol.ColumnName & _
                                                "' ORDER BY fecha")
                        If dtBitacora.Rows.Count > 0 Then
                            'Si hubo registro, pasar el valor anterior a la tabla, para regresar al punto del mantenimiento
                            dRow(dCol.ColumnName) = dtBitacora.Rows(0).Item("ValorAnterior")
                        End If
                    End If
                Next
            Next

            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnBorrar_Click(sender As Object, e As EventArgs) Handles BtnBorrar.Click
        Dim Clave As String = ""
        Try
            If MessageBox.Show("Se borrará la nómina seleccionada. ¿Está seguro de continuar?", "Borrar nómina", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = vbYes Then
                'Solicitar clave para borrar (igual al acceso a PIDA)
                Clave = InputBox("Clave de acceso a borrar nómina:", "Clave", "")
                'Si se seleccionó cancelar, o la clave está en blanco, salir del procedimiento
                If Clave = "" Then Exit Sub
                'Buscar la clave del usuario que ingresó a PIDA
                dtTemporal = sqlExecute("SELECT userpass FROM appuser WHERE username = '" & Usuario & "'", "seguridad")
                If dtTemporal.Rows.Count = 0 Then
                    'Si no se encontró registro de usuario, generar error
                    Err.Raise(-10)
                Else
                    'Encriptar clave para comparar con la registrada para el usuario
                    If getMD5Hash(Clave) = dtTemporal.Rows(0).Item("userpass").ToString.Trim Then
                        'Si la clave es correcta, borrar la nómina
                        BorraNomina()
                    Else
                        'Si la clave es incorrecta, notificar al usuario
                        MessageBox.Show("La clave es incorrecta. Favor de verificar.", "Borrar nómina", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Se detectó un error en el borrado de la nómina, y no pudo ser eliminada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNomina_Click(sender As Object, e As EventArgs) Handles btnNomina.Click
        Try
            Dim Sep As Integer
            'Buscar la última diagonal, para tomar nombre de archivo
            Sep = txtRecib.Text.LastIndexOf("\")
            If Sep > 0 Then
                'Si se encontró diagonal, tomar los caracteres antes, para el nombre de la carpeta
                dlgArchivo.InitialDirectory = txtRecib.Text.Substring(0, Sep)
                'tomar los caracteres después, para el nombre del archivo
                dlgArchivo.FileName = txtRecib.Text.Substring(Sep + 1).Trim
            End If
            'No permitir seleccionar varios archivos
            dlgArchivo.Multiselect = False
            'Filtrar solo archivos de texto
            dlgArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"

            'Mostrar pantalla de "Open", y el resultado asignarlo a la variable
            Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()

            'Si se seleccionó Aceptar, tomar nombre de archivo y mostrarlo en textbox
            If lDialogResult = Windows.Forms.DialogResult.OK Then
                txtRecib.Text = dlgArchivo.FileName
                txtRecib.Focus()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnRetiros_Click(sender As Object, e As EventArgs) Handles btnGenerales.Click
        Try
            Dim Sep As Integer
            Sep = txtGenerales.Text.LastIndexOf("\")
            If Sep > 0 Then
                dlgArchivo.InitialDirectory = txtGenerales.Text.Substring(0, Sep)
                dlgArchivo.FileName = txtGenerales.Text.Substring(Sep + 1).Trim
            End If
            dlgArchivo.Multiselect = False
            dlgArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"

            Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()

            If lDialogResult = Windows.Forms.DialogResult.OK Then
                txtGenerales.Text = dlgArchivo.FileName
                txtGenerales.Focus()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnPensiones.Click
        Try
            Dim Sep As Integer
            Sep = txtPensiones.Text.LastIndexOf("\")
            If Sep > 0 Then
                dlgArchivo.InitialDirectory = txtPensiones.Text.Substring(0, Sep)
                dlgArchivo.FileName = txtPensiones.Text.Substring(Sep + 1).Trim
            End If
            dlgArchivo.Multiselect = False
            dlgArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"

            Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()

            If lDialogResult = Windows.Forms.DialogResult.OK Then
                txtPensiones.Text = dlgArchivo.FileName
                txtPensiones.Focus()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbPeriodos_TextChanged(sender As Object, e As EventArgs) Handles cmbPeriodos.TextChanged

    End Sub

    Private Sub cmbTipoPeriodo_TextChanged(sender As Object, e As EventArgs) Handles cmbTipoPeriodo.SelectedValueChanged
        Dim tipo As String = cmbTipoPeriodo.SelectedValue
        Dim dtTemp As DataTable
        Select Case tipo
            Case "S"
                dtPeriodos = sqlExecute("SELECT ano+periodo as 'seleccionado',ano,periodo,fecha_ini,fecha_fin FROM periodos ORDER BY ano DESC,periodo ASC", "TA")
                cmbPeriodos.DataSource = dtPeriodos
                'cmbPeriodos.Columns("ColSeleccionado").Visible = False

                dtTemp = sqlExecute("SELECT TOP 1 ano+periodo AS seleccionado FROM nomina WHERE periodo<='53' ORDER BY ano DESC, periodo DESC", "NOMINA")
                If dtTemp.Rows.Count > 0 Then
                    cmbPeriodos.SelectedValue = dtTemp.Rows(0).Item("seleccionado")
                End If
            Case "Q"
                dtPeriodos = sqlExecute("SELECT ano+periodo as 'seleccionado',ano,periodo,fecha_ini,fecha_fin FROM periodos_quincenal ORDER BY ano DESC,periodo ASC", "TA")
                cmbPeriodos.DataSource = dtPeriodos


            Case "M"
                dtPeriodos = sqlExecute("SELECT ano+periodo as 'seleccionado',ano,periodo,fecha_ini,fecha_fin FROM periodos_mensual ORDER BY ano DESC,periodo ASC", "TA")
                cmbPeriodos.DataSource = dtPeriodos

            Case Else
                dtPeriodos = sqlExecute("SELECT ano+periodo as 'seleccionado',ano,periodo,fecha_ini,fecha_fin FROM periodos ORDER BY ano DESC,periodo ASC", "TA")
                cmbPeriodos.DataSource = dtPeriodos
                'cmbPeriodos.Columns("ColSeleccionado").Visible = False

                dtTemp = sqlExecute("SELECT TOP 1 ano+periodo AS seleccionado FROM nomina WHERE periodo<='53' ORDER BY ano DESC, periodo DESC", "NOMINA")
                If dtTemp.Rows.Count > 0 Then
                    cmbPeriodos.SelectedValue = dtTemp.Rows(0).Item("seleccionado")
                End If
        End Select

    End Sub
End Class
