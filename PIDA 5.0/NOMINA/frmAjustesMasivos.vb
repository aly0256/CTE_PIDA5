Public Class frmAjustesMasivos
    Dim dtPeriodos As New DataTable
    Dim dtConceptos As New DataTable
    Dim dtTemp As New DataTable

    Private Sub frmAjustesMasivos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        NFiltros = 0
        Me.Dispose()
    End Sub

    Private Sub frmAjustesMasivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'dtPeriodos = sqlExecute("SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin FROM periodos ORDER BY ano DESC,periodo ASC", "TA")
        'cmbAnoPeriodo.DataSource = dtPeriodos
        cmbTipoPeriodo.SelectedIndex = 0
        dtConceptos = sqlExecute("SELECT concepto,RTRIM(conceptos.nombre) AS nombre,convert(char(75), naturalezas.nombre) as naturaleza FROM " & _
                     "conceptos LEFT JOIN naturalezas ON " & _
                     "conceptos.cod_naturaleza = naturalezas.cod_naturaleza WHERE NOT misce_clave IS NULL", "nomina")
        cmbconcepto.datasource = dtConceptos

    End Sub

    Private Sub btnArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles btnArchivo.CheckedChanged
        Try
            btnBuscaArchivo.Enabled = btnArchivo.Checked
            txtArchivo.Enabled = btnArchivo.Checked
            txtLista.Enabled = btnLista.Checked
            btnBuscaLista.Enabled = btnLista.Checked
            txtMonto.Enabled = btnLista.Checked

            pnlFecha.Visible = False
            If btnArchivo.Checked Then
                txtArchivo.Focus()

                dtConceptos = sqlExecute("SELECT concepto,RTRIM(conceptos.nombre) AS nombre,convert(char(75), naturalezas.nombre) as naturaleza FROM " & _
                                    "conceptos LEFT JOIN naturalezas ON " & _
                                    "conceptos.cod_naturaleza = naturalezas.cod_naturaleza WHERE NOT misce_clave IS NULL", "nomina")
            Else
                'MCR 2017-10-17
                'SOLAMENTE DESDE ARCHIVO SE PUEDE CAPTURAR DE FORMA MASIVA LOS CONCEPTOS DE MAESTRO DE DEDUCCIONES,
                'PORQUE REQUIEREN FOLIO/NUM_CREDITO
                dtConceptos = sqlExecute("SELECT concepto,RTRIM(conceptos.nombre) AS nombre,convert(char(75), naturalezas.nombre) as naturaleza FROM " & _
                        "conceptos LEFT JOIN naturalezas ON " & _
                        "conceptos.cod_naturaleza = naturalezas.cod_naturaleza WHERE NOT misce_clave IS NULL AND ISNULL(aplica_mtro_ded,0) = 0 ", "nomina")
            End If
            cmbConcepto.DataSource = dtConceptos
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnLista_CheckedChanged(sender As Object, e As EventArgs) Handles btnLista.CheckedChanged
        Try
            btnBuscaArchivo.Enabled = btnArchivo.Checked
            txtArchivo.Enabled = btnArchivo.Checked
            txtLista.Enabled = btnLista.Checked
            btnBuscaLista.Enabled = btnLista.Checked
            txtMonto.Enabled = btnLista.Checked



            If btnLista.Checked Then
                txtLista.Focus()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBuscaArchivo_Click(sender As Object, e As EventArgs) Handles btnBuscaArchivo.Click
        Dim Archivo As String
        Try
            dlgArchivo.Multiselect = False
            dlgArchivo.FileName = ""
            dlgArchivo.Filter = "Listas de empleados|*.txt;*.xls;*.xlsx|Archivos excel|*.xls;*.xlsx|Archivos texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

            Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()
            If lDialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                Archivo = dlgArchivo.FileName
            End If

            If System.IO.File.Exists(Archivo) = False Then
                MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            txtArchivo.Text = Archivo
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click


        'SI ES CONCEPTO QUE UTILICE FECHA DE INCIDENCIA, EL FORMATO DEL ARCHIVO ES
        'RELOJ, MONTO, FECHA
        'SI ES CONCEPTO QUE UTILICE MAESTRO DE DEDUCCIONES, EL FORMATO DEL ARCHIVO ES
        'RELOJ, MONTO, PERIODOS DE DESCUENTO (semanas / quincenas)

        Dim ArLista(,) As String
        Dim ArTexto() As String
        Dim ArErrores(,) As String
        Dim Notas As String
        Dim Naturaleza As String
        Dim Clave As String = ""
        Dim Concepto As String
        Dim CambioValido As Boolean
        Dim Archivo As String
        Dim LN As String
        Dim i As Integer
        Dim x As Integer
        Dim y As Integer
        Dim z As Integer
        Dim AnoPeriodo As String
        Dim objReader As System.IO.StreamReader = Nothing
        Dim Cambios As Integer = 0

        Dim DesdeArchivo As Boolean
        Dim numcredito As String = ""
        Dim fecha As String
        Dim tipo As String
        Dim nombre As String = ""
        Dim nombre_concepto As String = ""
        Dim dtResultado As New DataTable
        Dim dRegistro As DataRow


        Dim dtaus As DataTable
        Dim dtdev As DataTable
        Dim aplicar_dev As Boolean = False
        Dim tipoaus As String = ""
        Dim dtpersona As New DataTable
        Dim res, ress As String
        Dim mto_ded As String = ""
        tipo = cmbTipoPeriodo.Text.Substring(0, 1)
        Dim consec As Integer = 0

        Try
            AnoPeriodo = cmbAnoPeriodo.SelectedValue
            DesdeArchivo = btnArchivo.Checked

            'MCR 2017-10-18
            'Solo crear estructura en blanco
            dtResultado = sqlExecute("SELECT SPACE(40) AS MENSAJE,'SEMANAL' AS TIPO_PERIODO,ANO,PERIODO,CONCEPTO,AJUSTES_NOM.RELOJ,'NOMBRE COMPLETO' AS NOMBRES," & _
                                     "'' as MONTO,FECHA_INCIDENCIA,AJUSTES_NOM.COMENTARIO FROM NOMINA.DBO.AJUSTES_NOM WHERE 1=2", "NOMINA")

            'A las notas, cambiar comillas y apóstrofes por doble apóstrofe, para evitar errores en SQL
            Notas = txtComentario.Text
            Notas = Notas.Replace("'", "''")
            Notas = Notas.Replace(Chr(34), "''")

            AnoPeriodo = cmbAnoPeriodo.SelectedValue
            Concepto = cmbConcepto.SelectedValue.trim

            'Tomar la naturaleza del concepto
            dtTemporal = sqlExecute("SELECT cod_naturaleza,misce_clave,aplica_mtro_ded,nombre FROM conceptos WHERE concepto = '" & cmbConcepto.SelectedValue & "'", "nomina")
            If dtTemporal.Rows.Count > 0 Then

                Naturaleza = IIf(IsDBNull(dtTemporal.Rows(0).Item("cod_naturaleza")), "D", dtTemporal.Rows(0).Item("cod_naturaleza"))
                Clave = IIf(IsDBNull(dtTemporal.Rows(0).Item("misce_clave")), "XX", dtTemporal.Rows(0).Item("misce_clave"))
                nombre_concepto = IIf(IsDBNull(dtTemporal.Rows(0).Item("nombre")), "NO IDENTIFICADO", dtTemporal.Rows(0).Item("nombre")).ToString.Trim
            Else
                Naturaleza = ""
                CambioValido = False
                Err.Raise(-1, "Concepto " & Concepto & " no localizado")
                nombre_concepto = ""
            End If


            'Si se seleccionó por archivo
            If DesdeArchivo Then
                Archivo = txtArchivo.Text.Trim

                If System.IO.File.Exists(Archivo) = False Then
                    MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                'Redimensionar el arreglo principal de inicio a 1000
                ReDim ArLista(4, 1000)

                'Si el archivo es tipo texto
                If Archivo.Substring(Archivo.Length - 4).ToLower = ".txt" Then
                    objReader = New System.IO.StreamReader(Archivo)

                    x = 0
                    y = objReader.BaseStream.Length
                    cpActualizacion.Maximum = 100
                    cpActualizacion.Visible = True
                    Application.DoEvents()

                    'Repasar todo el archivo
                    Do Until objReader.EndOfStream
                        LN = objReader.ReadLine
                        'Espera 3 columnas (reloj, monto y crédito), separadas por tab
                        If LN = Nothing Then
                            Continue Do
                        End If
                        ArTexto = Split(LN, vbTab)
                        If ArTexto(0) = "RELOJ" Then
                            Continue Do
                        End If
                        'La primer columna, es reloj
                        If ArTexto.Length > 0 Then ArLista(1, x) = ArTexto(0)
                        'La segunda columna, es monto
                        If ArTexto.Length > 1 Then ArLista(2, x) = ArTexto(1)
                        'La tercer columna, es folio o número de crédito
                        'Se cambio a fecha, ya no se usa el numero de credito
                        'Si el concepto es para el mto_ded sera la cantidad de periodos
                        If ArTexto.Length > 2 Then ArLista(3, x) = ArTexto(2)
                        ArLista(4, x) = ""

                        x = x + 1
                        If UBound(ArLista, 2) < x Then
                            ReDim Preserve ArLista(4, x)
                        End If
                    Loop
                    x = x - 1
                    'Redimensionar el arreglo principal, de acuerdo al número de registros
                    ReDim Preserve ArLista(4, x)
                Else
                    'Llenar arreglo con datos de excel
                    ArLista = ExcelTOArrayList(Archivo, "D")
                    x = ArLista.GetUpperBound(1)
                End If
            Else
                'Si no es archivo, llenar desde lista de números de reloj
                'el monto se carga desde txtMonto
                ArTexto = txtLista.Text.Split(",")
                x = ArTexto.Length - 1
                ReDim ArLista(4, x)
                For i = 0 To x
                    ArLista(1, i) = ArTexto(i)
                    ArLista(2, i) = txtMonto.Text
                    ArLista(3, i) = txtFecha.Value
                    ArLista(4, i) = ""
                Next
            End If
            ReDim ArErrores(x, 3)
            z = 0
            'Activar progress bar
            cpActualizacion.Visible = True
            cpActualizacion.Maximum = x
            For y = 0 To x
                nombre = ""
                Reloj = ArLista(1, y).PadLeft(LongReloj, "0")
                'If ArLista.GetUpperBound(0) > 2 Then
                '    numcredito = ArLista(3, y)
                'Else
                '    numcredito = ""
                'End If
                If ArLista.GetUpperBound(0) > 2 Then
                    Dim concepto_mto As DataTable = sqlExecute("select * from conceptos where concepto = '" & Concepto & "' and aplica_mtro_ded = '1'", "NOMINA")
                    If concepto_mto.Rows.Count > 0 Then
                        mto_ded = ArLista(3, y)
                    Else
                        fecha = ArLista(3, y)
                    End If
                Else
                    fecha = ""
                End If

                cpActualizacion.Value = x
                cpActualizacion.Text = Reloj

                'Validar que el reloj sea válido y activo
                CambioValido = True
                If ArLista(1, y) = "00000" Then
                    ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                    ArErrores(z, 1) = "Reloj en blanco"
                    ArErrores(z, 2) = nombre
                    CambioValido = False
                    z = z + 1
                End If



                dtTemp = sqlExecute("select * from conceptos where misce_fecha = '1' and concepto = '" & Concepto & "'", "nomina")
                If Not dtTemp.Rows.Count > 0 Then
                    fecha = ""
                Else
                    If fecha = "" Then
                        ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                        ArErrores(z, 1) = "No se capturo fecha de incidencia"
                        ArErrores(z, 2) = nombre
                        CambioValido = False
                        z = z + 1
                    End If
                End If


                If Not CambioValido Then Continue For
                If devolucion Then
                    dtdev = sqlExecute("select * from tipo_ausentismo where cancelacion = '" & Concepto & "' or devolucion = '" & Concepto & "'", "TA")
                    tipoaus = dtdev.Rows(0).Item("tipo_aus")
                    dtaus = sqlExecute("select * from ausentismo where reloj = '" & ArLista(1, y).PadLeft(LongReloj, "0") & "' and fecha = '" & FechaSQL(fecha) & "' and tipo_aus = '" & tipoaus & "'", "TA")

                    If Not dtaus.Rows.Count > 0 Then
                        'MessageBox.Show("No hay ausentismo registrado en la fecha indicada para aplicar la devolución.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        'Exit Sub
                        ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                        ArErrores(z, 1) = "Sin ausentismo " & tipoaus & " registrado"
                        ArErrores(z, 2) = nombre
                        CambioValido = False
                        z = z + 1
                    Else
                        aplicar_dev = True
                    End If
                End If

                If Not CambioValido Then Continue For

                dtTemporal = sqlExecute("SELECT reloj,baja,tipo_periodo,inactivo,RTRIM(apaterno)+' '+RTRIM(amaterno)+' '+RTRIM(nombre) AS nombres " & _
                                        "FROM personal WHERE reloj = '" & Reloj.PadLeft(LongReloj, "0") & "'")
                If dtTemporal.Rows.Count < 1 Then
                    ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                    ArErrores(z, 1) = "Empleado no localizado"
                    ArErrores(z, 2) = nombre
                    CambioValido = False
                    nombre = ""
                    z = z + 1
                Else
                    nombre = IIf(IsDBNull(dtTemporal.Rows(0).Item("nombres")), "", dtTemporal.Rows(0).Item("nombres"))
                End If

                If Not CambioValido Then Continue For

                If Not IsDBNull(dtTemporal.Rows.Item(0).Item("baja")) Then
                    If Not cbInactivos.Checked Then
                        ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                        ArErrores(z, 1) = "Empleado dado de baja"
                        ArErrores(z, 2) = nombre
                        CambioValido = False
                        z = z + 1
                    End If
                End If

                If Not CambioValido Then Continue For

                If IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("tipo_periodo")), "S", dtTemporal.Rows.Item(0).Item("tipo_periodo")) <> tipo Then
                    If Not cbInactivos.Checked Then
                        ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                        ArErrores(z, 1) = "El tipo de periodo << " & tipo & " >> no corresponde al empleado"
                        ArErrores(z, 2) = nombre
                        CambioValido = False
                        z = z + 1
                    End If
                End If

                If Not CambioValido Then Continue For

                If IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("inactivo")), 0, dtTemporal.Rows.Item(0).Item("inactivo")) = 1 And Not cbInactivos.Checked Then
                    If Not cbInactivos.Checked Then
                        ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                        ArErrores(z, 1) = "Empleado inactivo"
                        ArErrores(z, 2) = nombre
                        CambioValido = False
                        z = z + 1
                    End If
                End If

                'Si el cambio no es válido, pasar al siguiente índice
                If Not CambioValido Then Continue For

                If fecha <> "" Then
                    fecha = FechaSQL(fecha)

                    dtTemporal = sqlExecute("select * from conceptos where concepto = '" & Concepto & "' and misce_fecha = '1'", "NOMINA")

                    If Not dtTemporal.Rows.Count > 0 Then
                        ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                        ArErrores(z, 1) = "Concepto no admite captura de fecha de incidencia"
                        ArErrores(z, 2) = nombre
                        CambioValido = False
                        z = z + 1
                    End If
                End If

                If Not CambioValido Then Continue For


                '  If numcredito = "" Then
                numcredito = Year(Now) & Month(Now).ToString.Trim.PadLeft(2, "0") & Now.Day.ToString.Trim.PadLeft(2, "0") & _
                    Hour(Now).ToString.Trim.PadLeft(2, "0") & Minute(Now).ToString.Trim.PadLeft(2, "0") & Second(Now).ToString.Trim.PadLeft(2, "0") & consec.ToString.Trim
                '  End If

                'Si el cambio fue válido, insertar en la tabla de ajustes_nom
                If CambioValido Then
                    Dim monto As Double = 0.0
                    Dim NumPerDbl As Double = 0.0
                    Dim numperiodos As String = IIf(mto_ded = "", ", null", ", '" & mto_ded & "'")
                    Dim tipo_ajuste As String = ""
                    If (Concepto.Trim = "AHOALC") Then tipo_ajuste = "M"

                    Try
                        monto = Double.Parse(ArLista(2, y))
                        NumPerDbl = Double.Parse(mto_ded)
                    Catch ex As Exception
                    End Try

                    Dim Q1 As String = "INSERT INTO ajustes_nom (reloj,ano,periodo,concepto,TIPO_AJUSTE,monto, numcredito, numperiodos, fecha_incidencia,tipo_periodo) " & _
                                            "VALUES ('" & ArLista(1, y).PadLeft(LongReloj, "0") & "','" & AnoPeriodo.Substring(0, 4) & "','" & _
                                            AnoPeriodo.ToString.Substring(4, 2) & "','" & Concepto & "','" & tipo_ajuste & "', '" & ArLista(2, y) & "','" & numcredito & "'" & numperiodos & IIf(fecha = "", ", null,", ",'" & fecha & "'") & "'S')"


                    If (Not ExistRecCred(ArLista(1, y).PadLeft(LongReloj, "0"), AnoPeriodo.Substring(0, 4), AnoPeriodo.ToString.Substring(4, 2), Concepto, numcredito)) Then
                        sqlExecute(Q1, "nomina")
                    End If

                    AjustesNomKey = AnoPeriodo & ArLista(1, y).PadLeft(LongReloj, "0") & Concepto & numcredito


                    If Concepto = "HRSEXA" Or Concepto = "HRSEXT" Then
                        HrsExtrasMiscelaneos(AjustesNomKey, Concepto, tipo, FechaSQL(fecha), ArLista(1, y).PadLeft(LongReloj, "0"), ArLista(2, y), AnoPeriodo)
                        ' HrsExtrasMiscelaneos(AjustesNomKey, Concepto, tipo_periodo, FechaSQL(txtFechaIncidencia.Value), txtReloj.Text, txtMonto.Value)
                        anComentario = anComentario & ".     " & vbCrLf & txtComentario.Text.Trim
                    Else
                        anComentario = txtComentario.Text.Trim
                    End If

                    Dim ajustarsaldoact As String = ""
                    'If Len(mto_ded) > 0 Then
                    '    ajustarsaldoact = ",monto = monto / numperiodos, saldo_act = monto "
                    'End If
                    If (monto > 0 And NumPerDbl > 0) Then ajustarsaldoact = ",monto = monto / numperiodos, saldo_act = monto "

                    Dim Q2 As String = "UPDATE ajustes_nom SET " & _
                      "ano = '" & AnoPeriodo.Substring(0, 4) & _
                      "', periodo = '" & AnoPeriodo.Substring(4, 2) & _
                      "',per_ded = '" & Naturaleza.Trim & _
                      "', clave = (SELECT misce_clave FROM conceptos WHERE concepto like '%" & Concepto & "%') " & _
                      " ,comentario = '" & anComentario & _
                      "',concepto = '" & Concepto & _
                      "', usuario = '" & Usuario & _
                      "',fecha = '" & FechaSQL(Now) & _
                      "',cap_nomina = 1  " & _
                      ajustarsaldoact & _
                      ", tipo_periodo = '" & tipo & "'" & _
                      ", hrs_dobles = " & IIf(Math.Round(anDobles, 2) > 0, Math.Round(anDobles, 2) & " ", "NULL ") & _
                      ", hrs_triples = " & IIf(Math.Round(anTriples, 2) > 0, Math.Round(anTriples, 2) & " ", "NULL ") & _
                      ", semana_pago = " & IIf((anPerS + anSem).ToString.Length > 0, "'" & anPerS & IIf(anSem.Length > 0, "_" & anSem & "' ", "'"), "NULL ") & _
                      "WHERE (ano + periodo + reloj + rtrim(concepto) + numcredito) = '" & _
                      AjustesNomKey & "'"

                    sqlExecute(Q2, "nomina")
                    consec += 1


                    '2019-04-17 RETROACTIVO ES_RETRO ABRAHAM CASAS
                    Try
                        Dim es_retro As Boolean = False

                        If Concepto.Trim.ToLower = "retro" Then
                            es_retro = True
                        Else

                            If txtFecha.Visible = True Then

                                Dim dtAplicaRetro As DataTable = sqlExecute("" & _
                                "select ajustes_nom.reloj, ajustes_nom.concepto, ajustes_nom.FECHA_INCIDENCIA, ajustes_nom.ano, ajustes_nom.periodo, ajustes_nom.es_retro from" & Space(1) & _
                                "ajustes_nom left join ta.dbo.periodos on ajustes_nom.ano = periodos.ano and ajustes_nom.PERIODO = periodos.periodo where" & Space(1) & _
                                "ajustes_nom.TIPO_PERIODO = 'S' and " & Space(1) & _
                                "ajustes_nom.concepto in (select concepto from conceptos where MISCE_FECHA = '1') and" & Space(1) & _
                                "(ajustes_nom.FECHA_INCIDENCIA < periodos.FECHA_INI or ajustes_nom.FECHA_INCIDENCIA is null)" & Space(1) & _
                                "and ajustes_nom.ano >= '2019'" & Space(1) & _
                                "and ajustes_nom.reloj = '" & ArLista(1, y).PadLeft(LongReloj, "0") & "' and ajustes_nom.concepto = '" & Concepto & "' and ajustes_nom.FECHA_INCIDENCIA = '" & FechaSQL(txtFecha.Value) & "'", "nomina")

                                If dtAplicaRetro.Rows.Count > 0 Then
                                    es_retro = True
                                End If

                            End If

                        End If

                        If es_retro = True Then
                            sqlExecute("update ajustes_nom set es_retro = '1' WHERE (ano + periodo + reloj + rtrim(concepto) + numcredito) = '" & AjustesNomKey & "'", "nomina")
                        End If
                    Catch ex As Exception

                    End Try


                    If aplicar_dev Then
                        sqlExecute("update ausentismo set tipo_aus = 'D" & tipoaus & "' where reloj = '" & ArLista(1, y).PadLeft(LongReloj, "0") & "' and fecha = '" & FechaSQL(txtFecha.Value) & "' and tipo_aus = '" & tipoaus & "'", "TA")
                        aplicar_dev = False
                    End If
                    'MCR 2017-10-18
                    'Insertar registro para reporte
                    dRegistro = dtResultado.NewRow
                    dRegistro("MENSAJE") = "REGISTROS GUARDADOS EXITOSAMENTE"
                    dRegistro("TIPO_PERIODO") = cmbTipoPeriodo.Text
                    dRegistro("ANO") = AnoPeriodo.Substring(0, 4)
                    dRegistro("PERIODO") = AnoPeriodo.Substring(4, 2)
                    dRegistro("CONCEPTO") = nombre_concepto
                    dRegistro("RELOJ") = ArLista(1, y).PadLeft(LongReloj, "0")
                    dRegistro("NOMBRES") = nombre
                    If fecha = "" Then
                        dRegistro("MONTO") = ArLista(2, y)
                    Else
                        dRegistro("MONTO") = ArLista(2, y)
                        dRegistro("FECHA_INCIDENCIA") = fecha
                    End If
                    dRegistro("COMENTARIO") = txtComentario.Text.Trim

                    dtResultado.Rows.Add(dRegistro)
                    Cambios += 1
                End If
            Next

            cpActualizacion.Visible = False
            If z > 0 Then
                'z cuenta los errores. Si es >0, notificar que hubo errores, y cuáles

                Dim Lista As String = ""
                For x = 0 To z - 1
                    Lista = Lista & vbCrLf & "  " & ArErrores(x, 0) & " " & ArErrores(x, 1)


                    dRegistro = dtResultado.NewRow
                    dRegistro("MENSAJE") = "ERRORES DETECTADOS"
                    dRegistro("TIPO_PERIODO") = cmbTipoPeriodo.Text
                    dRegistro("ANO") = AnoPeriodo.Substring(0, 4)
                    dRegistro("PERIODO") = AnoPeriodo.Substring(4, 2)
                    dRegistro("CONCEPTO") = nombre_concepto
                    dRegistro("RELOJ") = ArErrores(x, 0)
                    dRegistro("NOMBRES") = ArErrores(x, 2)
                    dRegistro("COMENTARIO") = ArErrores(x, 1)
                    dtResultado.Rows.Add(dRegistro)

                Next
                MessageBox.Show("Se detectaron errores durante la carga, en algunos empleados no pudo agregarse el ajuste", "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("La carga masiva de ajustes se realizó exitosamente, con " & Cambios & " registros agregados.", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'MCR 2017-10-18
            'Ver reporte
            frmVistaPrevia.LlamarReporte("Resumen carga misceláneos masivos", dtResultado, "")
            frmVistaPrevia.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Se detectaron errores durante la carga, por lo que no pudieron agregarse el ajuste.", "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally

            Me.Close()
            Me.Dispose()
        End Try


    End Sub

    Private Function ExistRecCred(ByVal R As String, ByVal A As String, ByVal P As String, ByVal C As String, ByVal NC As String) As Boolean
        Try
            Dim dtRec As DataTable = sqlExecute("SELECT * from ajustes_nom where RELOJ='" & R & "' AND ANO='" & A & "' AND PERIODO='" & P & "' AND CONCEPTO='" & C & "' AND NUMCREDITO='" & NC & "'", "NOMINA")
            If (Not dtRec.Columns.Contains("ERROR") And dtRec.Rows.Count > 0) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnBuscaLista_Click(sender As Object, e As EventArgs) Handles btnBuscaLista.Click
        Dim FL As String = ""
        Dim dtDatosPersonal As New DataTable
        frmTrabajando.Show(Me)
        frmTrabajando.Avance.Value = 0
        frmTrabajando.Avance.IsRunning = False
        frmTrabajando.lblAvance.Text = "Preparando datos..."
        Application.DoEvents()
        dtDatosPersonal = sqlExecute("EXEC MaestroPersonal @Nivel = " & NivelConsulta & ", @Reloj = ''")
        dtResultado = dtDatosPersonal.Clone
        frmTrabajando.Avance.IsRunning = True

        For Each dRow As DataRow In dtDatosPersonal.Select(FiltroXUsuario)
            frmTrabajando.lblAvance.Text = "Reloj " & dRow.Item("reloj")
            Application.DoEvents()

            dRow.Item("sactual") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("sactual"), 0)
            dRow.Item("integrado") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("integrado"), 0)
            dRow.Item("pro_var") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("pro_var"), 0)
            dRow.Item("factor_int") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("factor_int"), 0)
            dRow.Item("sal_ant") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("sal_ant"), 0)
            dtResultado.ImportRow(dRow)
        Next
        ActivoTrabajando = False

        frmTrabajando.Close()
        frmTrabajando.Dispose()


        frmFiltro.ShowDialog()
        If NFiltros > 0 Then
            Dim i As Integer
            Try
                For i = 0 To NFiltros - 1
                    FL = FL & IIf(i > 0, " AND (", "(") & Filtros(2, i) & ")"
                Next
                dtTemporal = ConsultaPersonalVW("SELECT RELOJ from personalvw WHERE " & FL)

                FL = ""
                For i = 0 To dtTemporal.Rows.Count - 1
                    FL = FL & IIf(i > 0, ",", "") & dtTemporal.Rows.Item(i).Item("Reloj")
                Next
                txtLista.Text = FL

            Catch ex As Exception
                FL = "ERROR"
            End Try
        End If

    End Sub
    Dim devolucion As Boolean = False
    Private Sub cmbConcepto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbConcepto.SelectedValueChanged
        Try
            dtTemp = sqlExecute("SELECT cod_naturaleza,misce_monto FROM conceptos WHERE concepto = '" & cmbConcepto.SelectedValue & "'", "nomina")
            If dtTemp.Rows.Count And btnLista.Checked Then
                txtMonto.Value = IIf(IsDBNull(dtTemp.Rows(0).Item("misce_monto")), 0, dtTemp.Rows(0).Item("misce_monto"))
            End If

            'dtTemp = sqlExecute("SELECT ISNULL(cancelacion,devolucion) FROM tipo_ausentismo WHERE cancelacion = '" & cmbConcepto.SelectedValue & _
            '                    "' OR devolucion = '" & cmbConcepto.SelectedValue & "'", "ta")

            dtTemp = sqlExecute("select * from conceptos where misce_fecha = '1' and concepto = '" & cmbConcepto.SelectedValue & "'", "nomina")
            If btnLista.Checked = True Then
                pnlFecha.Visible = dtTemp.Rows.Count
            End If

            If dtTemp.Rows.Count Then
                Dim dtTempd As DataTable = sqlExecute("SELECT ISNULL(cancelacion,devolucion) FROM tipo_ausentismo WHERE cancelacion = '" & cmbConcepto.SelectedValue & _
                                    "' OR devolucion = '" & cmbConcepto.SelectedValue & "'", "ta")
                If dtTempd.Rows.Count Then
                    devolucion = True
                    txtMonto.Visible = False
                    Label1.Visible = False
                    txtMonto.Value = 1
                Else
                    devolucion = False
                    txtMonto.Visible = True
                    Label1.Visible = True
                    txtMonto.Value = 1
                End If

            Else
                devolucion = False
                txtMonto.Visible = True
                Label1.Visible = True
                txtMonto.Value = 1
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub cmbTipoPeriodo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoPeriodo.SelectedValueChanged
        Dim Tipo As String
        Dim tabla As String

        Try
            If cmbTipoPeriodo.Text.Length < 1 Then Exit Sub

            Tipo = cmbTipoPeriodo.Text.Substring(0, 1)
            tabla = IIf(Tipo = "Q", "periodos_quincenal", IIf(Tipo = "M", "periodos_mensual", "periodos"))

            dtPeriodos = sqlExecute("SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin FROM " & tabla & " ORDER BY ano DESC,periodo ASC ", "TA")
            cmbAnoPeriodo.DataSource = dtPeriodos
            cmbAnoPeriodo.SelectedIndex = 0
            'cmbAnoPeriodo.SelectedValue = ObtenerAnoPeriodo(DateAdd(DateInterval.Day, -7, Now), Tipo)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbTipoPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbConcepto_TextChanged(sender As Object, e As EventArgs) Handles cmbConcepto.TextChanged

    End Sub
End Class
