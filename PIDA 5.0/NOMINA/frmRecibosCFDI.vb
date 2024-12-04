Imports System.IO
Public Class frmRecibosCFDI
    Dim dtDatosCFDI As New DataTable

    Dim InfoPrueba As InfoCFDI
    Dim Parametros As InfoCFDI
    Dim strFileName As String
    Dim ArchivosExistentes As Integer
    Dim HoraInicio As Date

    Private Sub frmRecibosCFDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbAnoPeriodo.DataSource = sqlExecute("SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin FROM periodos ORDER BY ano DESC,periodo ASC", "TA")
        cmbCia.DataSource = sqlExecute("SELECT cod_comp,nombre FROM cias ORDER BY cia_default DESC,cod_comp")
        InfoPrueba.DireccionKey = "aaa010101aaa.key"
        InfoPrueba.DireccionCer = "aaa010101aaa.cer"
        InfoPrueba.PasswordKey = "12345678a"
        InfoPrueba.UsuarioWeb = "AAA010101AAA"
        InfoPrueba.PasswordWeb = "PWD"

        btnPrueba.Value = True
    End Sub

    Private Sub btnArchivoKEY_Click(sender As Object, e As EventArgs) Handles btnArchivoKEY.Click
        Dim Archivo As String
        Try
            dlgArchivo.Multiselect = False
            dlgArchivo.FileName = ""
            dlgArchivo.Filter = "Archivos .KEY|*.KEY|Todos los archivos (*.*)|*.*"

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

            txtArchivoKEY.Text = Archivo
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnArchivoCER_Click(sender As Object, e As EventArgs) Handles btnArchivoCER.Click
        Dim Archivo As String
        Try
            dlgArchivo.Multiselect = False
            dlgArchivo.FileName = ""
            dlgArchivo.Filter = "Archivos .CER|*.CER|Todos los archivos (*.*)|*.*"

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

            txtArchivoCER.Text = Archivo
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbCia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCia.SelectedValueChanged
        Try
            If cmbCia.SelectedValue Is Nothing Then Exit Sub

            MostrarInformacion()
        Catch ex As Exception
            Stop
        End Try
    End Sub
    Private Sub MostrarInformacion()
        Dim dDatos As DataRow

        Try
            dtDatosCFDI = sqlExecute("SELECT * FROM DATOS_CFDI WHERE cod_comp = '" & cmbCia.SelectedValue & "'", "NOMINA")
            If dtDatosCFDI.Rows.Count = 0 Then
                sqlExecute("INSERT INTO datos_CFDI (cod_comp,USER_WEB) " & _
                                                     "(SELECT COD_COMP,REPLACE(REPLACE(RFC,'-',''),' ','') FROM personal.dbo.CIAS WHERE COD_COMP = '" & cmbCia.SelectedValue & "')", "NOMINA")
                dtDatosCFDI = sqlExecute("SELECT * FROM DATOS_CFDI WHERE cod_comp = '" & cmbCia.SelectedValue & "'", "NOMINA")
            End If
            dDatos = dtDatosCFDI.Rows(0)

            txtArchivoKEY.Text = IIf(IsDBNull(dDatos("dir_key")), "", dDatos("dir_key").ToString.Trim)
            txtArchivoCER.Text = IIf(IsDBNull(dDatos("dir_cer")), "", dDatos("dir_cer").ToString.Trim)
            txtClaveKEY.Text = IIf(IsDBNull(dDatos("pass_key")), "", dDatos("pass_key").ToString.Trim)
            txtUsuarioWeb.Text = IIf(IsDBNull(dDatos("user_web")), "", dDatos("user_web").ToString.Trim)
            txtClaveWeb.Text = IIf(IsDBNull(dDatos("pass_web")), "", dDatos("pass_web").ToString.Trim)
            txtDirectorioCD.Text = IIf(IsDBNull(dDatos("dircomdig")), "", dDatos("dircomdig").ToString.Trim)
            txtDirectorioArchivos.Text = IIf(IsDBNull(dDatos("dirdestino")), "", dDatos("dirdestino").ToString.Trim)
            txtBanco.Text = IIf(IsDBNull(dDatos("banco")), "", dDatos("banco").ToString.Trim)
            txtRiesgo.Text = IIf(IsDBNull(dDatos("riesgo_pto")), "", dDatos("riesgo_pto").ToString.Trim)
        Catch ex As Exception
            Stop
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim dDatos As DataRow
        Try
            If cmbCia.SelectedValue Is Nothing Then Exit Sub

            If Not btnPrueba.Value Then
                dtDatosCFDI = sqlExecute("SELECT * FROM DATOS_CFDI WHERE cod_comp = '" & cmbCia.SelectedValue & "'", "NOMINA")
                If dtDatosCFDI.Rows.Count = 0 Then
                    sqlExecute("INSERT INTO datos_CFDI (cod_comp,USER_WEB) " & _
                                                         "(SELECT COD_COMP,REPLACE(REPLACE(RFC,'-',''),' ','') FROM personal.dbo.CIAS WHERE COD_COMP = '" & cmbCia.SelectedValue & "')", "NOMINA")
                    dtDatosCFDI = sqlExecute("SELECT * FROM DATOS_CFDI WHERE cod_comp = '" & cmbCia.SelectedValue & "'", "NOMINA")
                End If
                dDatos = dtDatosCFDI.Rows(0)

                sqlExecute("UPDATE datos_CFDI SET dir_key = '" & txtArchivoKEY.Text.Trim & "'," & _
                           "dir_cer = '" & txtArchivoCER.Text.Trim & "'," & _
                           "pass_key = '" & txtClaveKEY.Text.Trim & "'," & _
                           "user_web = '" & txtUsuarioWeb.Text.Trim & "'," & _
                           "pass_web = '" & txtClaveWeb.Text.Trim & "'," & _
                           "dircomdig = '" & txtDirectorioCD.Text.Trim & "'," & _
                           "dirdestino = '" & txtDirectorioArchivos.Text.Trim & "'," & _
                           "banco = '" & txtBanco.Text.Trim & "'," & _
                           "riesgo_pto = '" & txtRiesgo.Text.Trim & "')", "nomina")
            End If


            PreguntaArchivo.Filter = "Archivo de texto|*.txt"
            PreguntaArchivo.FileName = "Archivo" & cmbCia.SelectedValue & "NOM" & cmbAnoPeriodo.SelectedValue.ToString.Trim & ".txt"
            If PreguntaArchivo.ShowDialog = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName

                If Dir(strFileName).Length > 0 Then
                    Kill(strFileName)
                End If
            End If

            If strFileName.Length > 0 Then
                gpParametros.Enabled = False
                gpControles.Enabled = False
                'gpAvance.Parent = Me
                Me.ControlBox = False

                HoraInicio = Now
                tmrTranscurre.Tag = "INICIO"
                tmrTranscurre.Enabled = True
                ArchivosExistentes = Directory.EnumerateFiles(txtDirectorioArchivos.Text.Trim, "*.PDF").Count
                gpAvance.Visible = True
                'bgTimbrado.RunWorkerAsync()
                bgTimbrado_DoWork()
                bgTimbrado_RunWorkerCompleted()
            End If

        Catch ex As Exception
            Stop
        End Try
    End Sub


    Private Sub btnPrueba_ValueChanged(sender As Object, e As EventArgs) Handles btnPrueba.ValueChanged
        If btnPrueba.Value Then
            txtArchivoKEY.Text = InfoPrueba.DireccionKey
            txtArchivoCER.Text = InfoPrueba.DireccionCer
            txtClaveKEY.Text = InfoPrueba.PasswordKey
            txtUsuarioWeb.Text = InfoPrueba.UsuarioWeb
            txtClaveWeb.Text = InfoPrueba.PasswordWeb
        Else
            MostrarInformacion()
        End If

        txtArchivoKEY.Enabled = Not btnPrueba.Value
        txtArchivoCER.Enabled = Not btnPrueba.Value
        txtClaveKEY.Enabled = Not btnPrueba.Value
        txtUsuarioWeb.Enabled = Not btnPrueba.Value
        txtClaveWeb.Enabled = Not btnPrueba.Value
    End Sub

    Private Function InterfaceComercioDigital(ByVal strFileName As String, ByVal ParametrosCFDI As InfoCFDI, ByVal AnoPeriodo As String, ByVal Pruebas As Boolean) As Exception
        Dim dtCias As New DataTable
        Dim dtPeriodos As New DataTable
        Dim dtAuxiliares As New DataTable
        Dim dtPersonal As New DataTable
        Dim dtErrores As New DataTable

        Dim _serie As String = cmbCia.SelectedValue & "NOM" & AnoPeriodo
        Dim _folio As Integer = 1
        Dim _lugar_expedicion As String = "CD. JUAREZ, CHIH"
        Dim _fecha_expedicion As String = DatePart(DateInterval.Year, Now) & _
            DatePart(DateInterval.Month, Now).ToString.Trim.PadLeft(2) & _
            DatePart(DateInterval.Day, Now).ToString.Trim.PadLeft(2) & _
            DatePart(DateInterval.Hour, Now).ToString.Trim.PadLeft(2) & _
            DatePart(DateInterval.Minute, Now).ToString.Trim.PadLeft(2) & _
            DatePart(DateInterval.Second, Now).ToString.Trim.PadLeft(2)

        Dim _fechapago As Date
        Dim _fechainicialpago As Date
        Dim _fechafinalpago As Date
        Dim _fecha_fin As Date
        Dim _continuar As Boolean = True

        Dim _banco As String
        Dim _riesgo_pto As String
        Dim _registro_patronal As String
        Dim _rfc_cia As String
        Dim _nombre_cia As String
        Dim _regimen_cia As String
        Dim _minimo As Double
        Dim _calle_cia As String
        Dim _num_cia As String
        Dim _domicilio_cia As String
        Dim _colonia_cia As String
        Dim _localidad_cia As String
        Dim _referencia_cia As String
        Dim _municipio_cia As String
        Dim _estado_cia As String
        Dim _pais_cia As String
        Dim _cp_cia As String

        Dim i As Integer

        Dim ArchivoTXT As System.IO.StreamWriter = Nothing
        'Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog
        'Dim strFileName As String
        Dim GuardaArchivo As Boolean

        Dim dtMovimientosDetalle As New DataTable
        Dim dtExento As New DataTable
        Dim dtConceptos As New DataTable
        Dim dtNomina As New DataTable
        Dim dtMovimientos As New DataTable
        Dim dMovDetalle As DataRow
        Dim dMov As DataRow

        Dim _apofah_total As Double = 0
        Dim _apofah_gravado As Double = 0
        Dim _apofah_exento As Double = 0
        Dim _exento As Double

        Dim _total_percepciones As Double
        Dim _total_deducciones As Double
        Dim _total_empleados As Integer

        Dim _texto As String = ""

        Dim SumaPercepciones As Double = 0
        Dim SumaDeducciones As Double = 0
        Dim SumaEmpleados As Integer = 0

        Dim CompruebaTXT As System.IO.StreamReader = Nothing
        Dim Linea As String
        Dim Datos() As String
        Dim FNErrores As String
        Dim T As Integer = 0
        Dim UbicacionArchivo As String

        Try
          
            Try
                ArchivoTXT = File.CreateText(strFileName)
                GuardaArchivo = True
            Catch ex As Exception
                Return ex
                ArchivoTXT = Nothing
                GuardaArchivo = False
            End Try

            dtErrores.Columns.Add("reloj")
            dtErrores.Columns.Add("detalle")

            _banco = ParametrosCFDI.Banco
            _riesgo_pto = ParametrosCFDI.Riesgo

            dtCias = sqlExecute("SELECT * FROM cias WHERE cod_comp = '" & ParametrosCFDI.Compania & "'")
            _registro_patronal = IIf(IsDBNull(dtCias.Rows(0).Item("reg_pat")), "SIN REGISTRO", dtCias.Rows(0).Item("reg_pat").ToString.Trim)
            _registro_patronal = _registro_patronal.Replace(" ", "").Replace("-", "")

            If Not Pruebas Then
                _rfc_cia = IIf(IsDBNull(dtCias.Rows(0).Item("rfc")), "SIN REGISTRO", dtCias.Rows(0).Item("rfc").ToString.Trim)
                _rfc_cia = _rfc_cia.Replace(" ", "").Replace("-", "")
            Else
                _rfc_cia = "AAA010101AAA"
            End If

            _minimo = IIf(IsDBNull(dtCias.Rows(0).Item("minimo")), 0, dtCias.Rows(0).Item("minimo"))
            _nombre_cia = EliminaAcentos(IIf(IsDBNull(dtCias.Rows(0).Item("nombre")), "SIN NOMBRE", dtCias.Rows(0).Item("nombre").ToString.Trim))
            _regimen_cia = "REGIMEN GENERAL DE PERSONAS MORALES (MAQUILADORA)"
            _domicilio_cia = EliminaAcentos(IIf(IsDBNull(dtCias.Rows(0).Item("direccion")), "SIN CALLE", dtCias.Rows(0).Item("direccion").ToString.Trim.ToUpper))
            i = _domicilio_cia.LastIndexOf(" ")
            If i = 0 Then
                _num_cia = ""
                _calle_cia = _domicilio_cia
            Else
                _num_cia = _domicilio_cia.Substring(i).ToLower
                _num_cia = _num_cia.Replace("#", "").Replace("num", "").Replace("no", "").Replace("núm", "").Replace(".", "").Trim
                If Not IsNumeric(_num_cia) Then
                    _calle_cia = "DOMICILIO INCORRECTO"
                    _num_cia = "###"
                Else
                    _calle_cia = _domicilio_cia.Substring(0, i - 1)
                    _calle_cia = _calle_cia.Replace("#", "").Replace(" num.", "").Replace(" no.", "").Replace(" núm.", "").Replace(" no", "")
                End If
            End If
            _colonia_cia = EliminaAcentos(IIf(IsDBNull(dtCias.Rows(0).Item("colonia")), "SIN COLONIA", dtCias.Rows(0).Item("colonia").ToString.Trim.ToUpper))
            _localidad_cia = EliminaAcentos(IIf(IsDBNull(dtCias.Rows(0).Item("ciudad")), "SIN COLONIA", dtCias.Rows(0).Item("ciudad").ToString.Trim.ToUpper))
            _municipio_cia = _localidad_cia
            _referencia_cia = ""
            _cp_cia = IIf(IsDBNull(dtCias.Rows(0).Item("cod_postal")), "", dtCias.Rows(0).Item("cod_postal").ToString.Trim)
            _cp_cia = IIf(_cp_cia = "", "32000", _cp_cia)
            _estado_cia = EliminaAcentos(IIf(IsDBNull(dtCias.Rows(0).Item("estado")), "SIN ESTADO", dtCias.Rows(0).Item("estado").ToString.Trim.ToUpper))
            _pais_cia = "MEXICO"
            dtPeriodos = sqlExecute("SELECT fecha_ini,fecha_fin,fecha_pago FROM periodos WHERE ano = '" & AnoPeriodo.Substring(0, 4) & _
                                    "' AND periodo ='" & AnoPeriodo.Substring(4, 2) & "'", "TA")
            _fechapago = IIf(IsDBNull(dtPeriodos.Rows(0).Item("fecha_pago")), _
                             DateAdd(DateInterval.Day, 5, dtPeriodos.Rows(0).Item("fecha_fin")), _
                             dtPeriodos.Rows(0).Item("fecha_pago"))
            _fechainicialpago = dtPeriodos.Rows(0).Item("fecha_ini")
            _fechafinalpago = dtPeriodos.Rows(0).Item("fecha_fin")
            _fecha_fin = _fechafinalpago



            '*** OJO, el Tipo de Percepcion depende del catalogo del SAT
            '*** la Clave SAT es la equivalencia interna que pidio Gabriel para que no se vean tan obvios los conceptos, sobre todos los bonos de asistencia y puntualidad mensual
            dtMovimientosDetalle.Columns.Add("reloj", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("naturaleza", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("tipo_percepcion", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("concepto", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("descripcion", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("monto", System.Type.GetType("System.Double"))
            dtMovimientosDetalle.Columns.Add("gravado", System.Type.GetType("System.Double"))
            dtMovimientosDetalle.Columns.Add("exento", System.Type.GetType("System.Double"))
            dtMovimientosDetalle.Columns.Add("prioridad", System.Type.GetType("System.Int16"))
            dtMovimientosDetalle.PrimaryKey = New DataColumn() {dtMovimientosDetalle.Columns("reloj"), dtMovimientosDetalle.Columns("concepto")}

            dtNomina = sqlExecute("SELECT RELOJ,NOMBRES,RFC,CURP,NUMIMSS,COD_DEPTO,NOMBRE_DEPTO,ALTA,COD_PUESTO,NOMBRE_PUESTO,COD_TURNO," & _
                                  "NOMBRE_TURNO,SACTUAL,INTEGRADO,HORAS_DOBLES,HORAS_TRIPLES," & _
                                  "ISNULL((SELECT contenido FROM personal.dbo.detalle_auxiliares WHERE campo = 'EMAIL' and reloj = NominaVW.reloj),'') AS EMAIL " & _
                                  "FROM nominaVW WHERE cod_comp = '" & Parametros.Compania & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                                  "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' AND folio_cfdi IS NULL", "nomina")

            If dtNomina.Rows.Count = 0 Then
                Err.Raise(999, Nothing, "No se encontraron registros de nómina pendientes de timbrar, que cumplan con las condiciones especificadas.")
            End If
            dtNomina.Columns.Add("INCLUIR")
            pbAvance.Maximum = dtNomina.Rows.Count

            T = 0
            For Each dReg As DataRow In dtNomina.Rows
                T += 1
                'bgTimbrado.ReportProgress(T, "Preparando" & vbCrLf & dReg("reloj"))

                pbAvance.IsRunning = True
                pbAvance.Value = T
                lblAvance.Text = "Preparando"

                If Not ValidaRFC(dReg("rfc")) Then
                    dtErrores.Rows.Add({dReg("reloj"), "RFC inválido (" & dReg("rfc").ToString.Trim & ")"})
                    Continue For
                End If

                If Not ValidaCURP(dReg("curp")) Then
                    dtErrores.Rows.Add({dReg("reloj"), "CURP inválida (" & dReg("curp").ToString.Trim & ")"})
                    Continue For
                End If

                dtMovimientos = sqlExecute("SELECT movimientos.concepto,conceptos.nombre,ISNULL(cod_sat,'') AS cod_sat,exento,concepto_sat,ISNULL(cod_naturaleza,'I') as cod_naturaleza," & _
                                           "monto,conceptos.prioridad FROM " & _
                                           "movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                                           "WHERE reloj = '" & dReg("reloj") & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                                           "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'", "nomina")
                For Each dMov In dtMovimientos.Rows
                    If dMov("concepto").ToString.Trim = "APOFAH" Then
                        _apofah_total = dMov("monto")
                        _apofah_exento = dMov("monto")
                    ElseIf dMov("concepto").ToString.Trim = "EXEDFA" Then
                        _apofah_gravado = dMov("monto")
                    End If

                    If dMov("cod_sat").ToString.Trim = "" Then
                        If (dMov("cod_naturaleza") = "D" Or dMov("cod_naturaleza") = "P") Then
                            Err.Raise(999, Nothing, "El concepto " & dMov("concepto") & " NO tiene equivalencia con los códigos del SAT, favor de revisar")
                        End If
                    Else
                        dReg("incluir") = "SI"

                        dMovDetalle = dtMovimientosDetalle.Rows.Find({dReg("reloj"), dMov("concepto")})
                        If IsNothing(dMovDetalle) Then
                            dMovDetalle = dtMovimientosDetalle.NewRow
                            dMovDetalle("reloj") = dReg("reloj")
                            dMovDetalle("naturaleza") = IIf(dMov("concepto").ToString.Trim = "BONDES" Or dMov("concepto").ToString.Trim = "BONASP", _
                                                            "P", dMov("cod_naturaleza"))
                            dMovDetalle("tipo_percepcion") = dMov("cod_sat")
                            dMovDetalle("concepto") = dMov("concepto")
                            dMovDetalle("descripcion") = EliminaAcentos(dMov("nombre"))
                            dMovDetalle("monto") = dMov("monto")
                            dMovDetalle("prioridad") = dMov("prioridad")

                            dtMovimientosDetalle.Rows.Add(dMovDetalle)
                        Else
                            dMovDetalle("monto") += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                        End If

                        If Not IsDBNull(dMov("exento")) Then
                            dtExento = sqlExecute("SELECT monto FROM movimientos WHERE concepto = '" & dMov("exento").ToString.Trim & _
                                                  "' AND reloj = '" & dReg("reloj") & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                                                  "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'", "nomina")
                            If dtExento.Rows.Count = 0 Then
                                _exento = 0
                            Else
                                _exento = dtExento.Rows(0).Item("monto")
                            End If
                            dMovDetalle("exento") = _exento
                        End If
                    End If

                    If _apofah_total > 0 Then
                        Try
                            dMovDetalle = dtMovimientosDetalle.NewRow
                            dtMovimientosDetalle.Rows.Add({
                            dReg("reloj"),
                            "P",
                            "005",
                            "APOCIA",
                            "Fondo Ahorro Patrón",
                             _apofah_total,
                            _apofah_gravado,
                            _apofah_exento - _apofah_gravado,
                            500
                            })

                            dtMovimientosDetalle.Rows.Add({
                           dReg("reloj"),
                           "D",
                           "018",
                           "RETCIA",
                           "Aportación Fondo Ahorro Patrón",
                            _apofah_total,
                           0,
                          _apofah_total,
                           900
                           })

                            _apofah_total = 0
                        Catch ex As Exception

                        End Try
                    End If
                Next
            Next

            FNErrores = Parametros.DirDestino
            FNErrores = IIf(strFileName.Substring(FNErrores.Trim.Length - 1) <> "\", FNErrores.Trim & "\", FNErrores) & "ErroresDetectados.xlsx"
            If dtErrores.Rows.Count > 0 Then
                MessageBox.Show("Errores en CURP...")

                ' ExportaExcel(dtErrores, strFileName)
                'Err.Raise(999, Nothing, "Se detectaron errores en CURP y/o RFC que deben ser corregidos antes de continuar." & vbCrLf & vbCrLf & _
                '          "Encontrará el detalle en el archivo <" & strFileName & ">")
            End If

            '*** Para cambiar la naturaleza de los conceptos en negativo, ya que la interface de Comercio Digital no acepta montos negativos IVO
            For Each dMov In dtMovimientosDetalle.Select("monto<0 AND naturaleza= 'D' AND concepto = 'CREFIS'")
                dMov("tipo_percepcion") = "017"
                dMov("naturaleza") = "P"
                dMov("monto") = -IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                dMov("gravado") = -IIf(IsDBNull(dMov("gravado")), 0, dMov("gravado"))
                dMov("exento") = -dMov("exento")
            Next
            For Each dMov In dtMovimientosDetalle.Select("monto<0 AND naturaleza= 'P'")
                dMov("exento") = 0
            Next
            i = dtMovimientosDetalle.Select("exento > monto AND exento <> 0").Count
            If i > 0 Then
                Err.Raise(999, Nothing, "¡ALERTA!" & vbCrLf & "Existen cantidades exentas mayores a los montos. No es posible continuar")
            End If

            For Each dMov In dtMovimientosDetalle.Rows
                dMov("gravado") = dMov("monto") - IIf(IsDBNull(dMov("exento")), 0, dMov("exento"))
                If dMov("naturaleza").ToString.Trim = "P" Then
                    _total_percepciones += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                ElseIf dMov("naturaleza").ToString.Trim = "D" Then
                    _total_deducciones += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                End If
            Next

            _total_empleados = dtNomina.Select("incluir = 'SI'").Count

            If _total_percepciones <= 0 Or _total_deducciones < 0 Then
                Err.Raise(999, Nothing, "Falta información. Favor de revisar")
            End If

            sqlExecute("UPDATE bitacora_timbrados SET tot_per = " & _total_percepciones & "," & _
                       "tot_ded = " & _total_deducciones & "," & _
                       "tot_neto = " & _total_percepciones - _total_deducciones & " WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")

            'INDEX on reloj+IIF(naturaleza="P","01","02")+TIPO_PERCEPCION TAG reloj_idx  && Orden para que se vea bonito en el recibo digital

            '	*** ENCABEZADO DE ARCHIVO CON DATOS DEL PATRON
            _texto = "EMP|" & _rfc_cia & "|" & _nombre_cia & "|" & _regimen_cia & "|" & vbCrLf
            _texto = _texto & "DMF|" & _calle_cia & "|" & _num_cia & "||" & _colonia_cia & "|" & _localidad_cia & "|" & _referencia_cia & "|" & _municipio_cia & "|" & _estado_cia & "|" & _pais_cia & "|" & _cp_cia & "|" & vbCrLf
            _texto = _texto & "DME|" & _calle_cia & "|" & _num_cia & "||" & _colonia_cia & "|" & _localidad_cia & "|" & _referencia_cia & "|" & _municipio_cia & "|" & _estado_cia & "|" & _pais_cia & "|" & _cp_cia & "|" & vbCrLf
            _texto = _texto & "KEY|" & ParametrosCFDI.DireccionKey.Trim.Replace("\", "/") & "|" & vbCrLf
            _texto = _texto & "CER|" & ParametrosCFDI.DireccionCer.Trim.Replace("\", "/") & "|" & vbCrLf
            _texto = _texto & "PVE|" & ParametrosCFDI.PasswordKey.Trim & "|" & vbCrLf
            _texto = _texto & "WS0|" & ParametrosCFDI.UsuarioWeb.Trim & "|" & ParametrosCFDI.PasswordWeb.Trim & "|" & vbCrLf
            _texto = _texto & "NOM|" & _registro_patronal & "|" & FechaSQL(_fechapago) & "|" & FechaSQL(_fechainicialpago) & "|" & FechaSQL(_fechafinalpago) & "|" & vbCrLf
            _texto = _texto & "CFD|" & _serie & "|" & _folio & "|" & _lugar_expedicion & "|" & _fecha_expedicion & "|" & vbCrLf
            _texto = _texto & "CF2|CONTADO|TRANSFERENCIA ELECTRONICA|8568|" & vbCrLf
            _texto = _texto & "TOT|" & String.Format("{0:0.00}", _total_percepciones) & "|" & String.Format("{0:0.00}", _total_deducciones) & "|" & _total_empleados.ToString.Trim & "|" & vbCrLf
            _texto = _texto & "INI|"

            ArchivoTXT.WriteLine(_texto)

            Dim _perc_totalgravado As Double
            Dim _perc_totalexento As Double
            Dim _ded_totalgravado As Double
            Dim _ded_totalexento As Double

            Dim _textoMov As String = ""

            pbAvance.Maximum = dtNomina.Select("incluir = 'SI'").Count
            T = 0
            For Each dMov In dtNomina.Select("incluir = 'SI'")
                T += 1
                'bgTimbrado.ReportProgress(T, "Exportando" & vbCrLf & dMov("reloj"))

                pbAvance.IsRunning = True
                pbAvance.Value = T
                lblAvance.Text = "Exportando"

                _texto = "E01|" & dMov("reloj").ToString.Trim & "|"
                _texto = _texto & dMov("nombres").ToString.Trim.Replace(",", " ") & "|"
                _texto = _texto & dMov("rfc").ToString.Trim.Replace("-", "").PadRight(13, "X") & "|"
                _texto = _texto & dMov("curp").ToString.Trim & "|"
                _texto = _texto & "2|"
                _texto = _texto & dMov("numimss").ToString.Trim & "|"
                _texto = _texto & "7|"  '&& DIAS PAGADOS PENDIENTE
                _texto = _texto & dMov("nombre_depto").ToString.ToUpper.Trim & "|"
                _texto = _texto & "|" & (_banco) & "|"  '&& CLABE PENDIENTE
                _texto = _texto & FechaSQL(dMov("alta")) & "|"
                _texto = _texto & Math.Truncate((DateDiff(DateInterval.Day, dMov("alta"), _fecha_fin) + 1) / 7).ToString.Trim & "|"
                _texto = _texto & dMov("nombre_puesto").ToString.ToUpper.Trim & "|"
                _texto = _texto & "Base|"
                _texto = _texto & IIf(dMov("cod_turno") = "2", "Vespertina", IIf(dMov("cod_turno") = "3", "Nocturna", "Diurna")) & "|"
                _texto = _texto & "Semanal|"
                _texto = _texto & String.Format("{0:0.00}", dMov("sactual")) & "|"
                _texto = _texto & _riesgo_pto & "|"
                _texto = _texto & String.Format("{0:0.00}", dMov("integrado")) & "|"

                _perc_totalgravado = 0
                _perc_totalexento = 0
                _ded_totalgravado = 0
                _ded_totalexento = 0
                '** PERCEPCIONES
                _textoMov = ""
                For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'P' AND reloj = '" & dMov("reloj").ToString.Trim & "'", "PRIORIDAD,TIPO_PERCEPCION")
                    _textoMov = _textoMov & "P01|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                    _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                    _textoMov = _textoMov & dDetalle("descripcion").ToString.Trim & "|"
                    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("gravado")) & "|"
                    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("exento")) & "|" & vbCrLf
                    _perc_totalgravado += IIf(IsDBNull(dDetalle("gravado")), 0, dDetalle("gravado"))
                    _perc_totalexento += IIf(IsDBNull(dDetalle("exento")), 0, dDetalle("exento"))
                Next
                '** DEDUCCIONES
                For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'D' AND reloj = '" & dMov("reloj").ToString.Trim & "'", "PRIORIDAD,TIPO_PERCEPCION")
                    _textoMov = _textoMov & "D01|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                    _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                    _textoMov = _textoMov & dDetalle("descripcion").ToString.Trim & "|"
                    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("gravado")) & "|"
                    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("exento")) & "|" & vbCrLf
                    _ded_totalgravado += IIf(IsDBNull(dDetalle("gravado")), 0, dDetalle("gravado"))
                    _ded_totalexento += IIf(IsDBNull(dDetalle("exento")), 0, dDetalle("exento"))
                Next

                '** HORAS EXTRAS DOBLES
                For Each dDetalle As DataRow In dtMovimientosDetalle.Select("concepto = 'PEREX2' AND reloj = '" & dMov("reloj").ToString.Trim & "'")
                    _textoMov = _textoMov & "H01|"
                    _textoMov = _textoMov & "1|" ' && DIAS EN QUE SE PAGA TIEMPO EXTRA
                    _textoMov = _textoMov & "Dobles|"
                    _textoMov = _textoMov & Math.Truncate(dMov("horas_dobles")).ToString.Trim & "|"
                    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto")) & "|" & vbCrLf
                Next

                '** HORAS EXTRAS TRIPLES
                For Each dDetalle As DataRow In dtMovimientosDetalle.Select("concepto = 'PEREX3' AND reloj = '" & dMov("reloj").ToString.Trim & "'")
                    _textoMov = _textoMov & "H01|"
                    _textoMov = _textoMov & "1|" ' && DIAS EN QUE SE PAGA TIEMPO EXTRA
                    _textoMov = _textoMov & "Triples|"
                    _textoMov = _textoMov & Math.Truncate(dMov("horas_triples")).ToString.Trim & "|"
                    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto")) & "|" & vbCrLf
                Next
                _textoMov = _textoMov & "F01|" & vbCrLf

                _texto = _texto & String.Format("{0:0.00}", _perc_totalexento + _perc_totalgravado) & "|"
                _texto = _texto & String.Format("{0:0.00}", _ded_totalexento + _ded_totalgravado) & "|" & vbCrLf

                If dMov("email").ToString.Length > 0 And Not Pruebas Then
                    _texto = _texto & "EM1|" & dMov("email").ToString.Trim & "|" & vbCrLf
                End If

                ArchivoTXT.Write(_texto)
                ArchivoTXT.Write(_textoMov)
            Next

            ArchivoTXT.WriteLine("FIN|")
            ArchivoTXT.Close()

            sqlExecute("UPDATE bitacora_timbrados SET archivo = 1," & _
                       "nombrearch  = '" & strFileName & "' WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")
        Catch ex As Exception
            ArchivoTXT.Close()
            Return ex
        End Try
        Dim dtResumen As New DataTable
        Dim dConcepto As DataRow
        dtResumen.Columns.Add("naturaleza")
        dtResumen.Columns.Add("concepto_sat")
        dtResumen.Columns.Add("concepto_pida")
        dtResumen.Columns.Add("descripcion")
        dtResumen.Columns.Add("gravado", System.Type.GetType("System.Double"))
        dtResumen.Columns.Add("exento", System.Type.GetType("System.Double"))
        dtResumen.PrimaryKey = New DataColumn() {dtResumen.Columns("concepto_pida")}

        Try
            CompruebaTXT = File.OpenText(strFileName)

            _total_percepciones = 0
            _total_deducciones = 0
            _total_empleados = 0

            Do Until CompruebaTXT.EndOfStream
                Linea = CompruebaTXT.ReadLine
                Datos = Linea.Split("|")
                If Datos(0) = "TOT" Then
                    _total_percepciones = Datos(1)
                    _total_deducciones = Datos(2)
                    _total_empleados = Datos(3)
                ElseIf Datos(0) = "E01" Then
                    SumaEmpleados += 1
                ElseIf Datos(0) = "P01" Or Datos(0) = "D01" Then
                    dConcepto = dtResumen.Rows.Find(Datos(2))
                    If dConcepto Is Nothing Then
                        dConcepto = dtResumen.NewRow
                        dConcepto("naturaleza") = IIf(Datos(0) = "P01", "PERCEPCIONES", "DEDUCCIONES")
                        dConcepto("concepto_sat") = Datos(1)
                        dConcepto("concepto_pida") = Datos(2)
                        dConcepto("descripcion") = Datos(3)
                        dConcepto("gravado") = Datos(4)

                        dConcepto("exento") = Datos(5)


                        dtResumen.Rows.Add(dConcepto)
                    Else

                        dConcepto("gravado") += Datos(4)
                        dConcepto("exento") += Datos(5)

                    End If

                    If Datos(0) = "P01" Then
                        SumaPercepciones = SumaPercepciones + Datos(4) + Datos(5)
                    ElseIf Datos(0) = "D01" Then
                        SumaDeducciones = SumaDeducciones + Datos(4) + Datos(5)
                    End If
                End If
            Loop
            CompruebaTXT.Close()

            SumaPercepciones = Math.Round(SumaPercepciones, 2)
            SumaDeducciones = Math.Round(SumaDeducciones, 2)
            If _total_empleados <> SumaEmpleados Then
                Err.Raise(999, Nothing, "El número de empleados no coincide con el detalle. Favor de revisar.")
            ElseIf _total_percepciones <> SumaPercepciones Then
                Err.Raise(999, Nothing, "El acumulado de PERCEPCIONES no coincide con el detalle. Favor de revisar.")
            ElseIf _total_deducciones <> SumaDeducciones Then
                Err.Raise(999, Nothing, "El acumulado de DEDUCCIONES no coincide con el detalle. Favor de revisar.")
            End If
            sqlExecute("UPDATE bitacora_timbrados SET comprueba = 1 WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")
            Try
                frmVistaPrevia.LlamarReporte("Acumulado CFDI", dtResumen, Parametros.Compania)
                frmVistaPrevia.ShowDialog()                
            Catch ex As Exception

            End Try

            Dim _random As Single = 0

            If MessageBox.Show("¿Desea realizar el timbrado de los recibos?", "PIDA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim Random As New Random
                Dim Respuesta As String = ""
                _random = Random.Next(1, 3)

                'SOLO PARA EVITAR RETRASOS AL PROBAR
                Respuesta = "CORRECTO"
                Do Until Respuesta = "CORRECTO"
                    _random = Random.Next(1, 3)

                    Select Case _random
                        Case 1 '&& Percepciones
                            Respuesta = InputBox("Total de PERCEPCIONES", "VALIDAR")
                            If Not IsNumeric(Respuesta) Then
                                If MessageBox.Show("El monto no es válido. Favor de verificar", "Validación", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then
                                    Err.Raise(999, Nothing, "Validación incorrecta.")
                                End If
                            ElseIf Not Int(Respuesta) = SumaPercepciones Then
                                If MessageBox.Show("La cantidad no coincide con el monto requerido. Favor de verificar", "Validación", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then
                                    Err.Raise(999, Nothing, "Validación incorrecta.")
                                End If
                            Else
                                Respuesta = "CORRECTO"
                            End If
                        Case 2 '&& Deducciones
                            Respuesta = InputBox("Total de DEDUCCIONES", "VALIDAR")
                            If Not IsNumeric(Respuesta) Then
                                If MessageBox.Show("El monto no es válido. Favor de verificar", "Validación", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then
                                    Err.Raise(999, Nothing, "Validación incorrecta.")
                                End If
                            ElseIf Not Int(Respuesta) = SumaDeducciones Then
                                If MessageBox.Show("La cantidad no coincide con el monto requerido. Favor de verificar", "Validación", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then
                                    Err.Raise(999, Nothing, "Validación incorrecta.")
                                End If
                            Else
                                Respuesta = "CORRECTO"
                            End If
                        Case 3 '&& Neto
                            Respuesta = InputBox("Total NETO", "VALIDAR")
                            If Not IsNumeric(Respuesta) Then
                                If MessageBox.Show("El monto no es válido. Favor de verificar", "Validación", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then
                                    Err.Raise(999, Nothing, "Validación incorrecta.")
                                End If
                            ElseIf Not Int(Respuesta) = SumaPercepciones - SumaDeducciones Then
                                If MessageBox.Show("La cantidad no coincide con el monto requerido. Favor de verificar", "Validación", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then
                                    Err.Raise(999, Nothing, "Validación incorrecta.")
                                End If
                            Else
                                Respuesta = "CORRECTO"
                            End If
                    End Select
                Loop

                sqlExecute("UPDATE bitacora_timbrados SET verificar = 1 WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")

                Dim dirActual As String = Directory.GetCurrentDirectory
                Dim dirCFDI As String = ParametrosCFDI.DirComercioDigital
                dirCFDI = IIf(dirCFDI.Substring(dirCFDI.Trim.Length - 1) <> "\", dirCFDI.Trim & "\", dirCFDI)

                Directory.SetCurrentDirectory(dirCFDI)
                If Dir(dirCFDI & _serie & ".txt").Length > 0 Then
                    Kill(dirCFDI & _serie & ".txt")
                End If
                File.Copy(strFileName, dirCFDI & _serie & ".txt")

                Dim ss As Integer
                'bgTimbrado.ReportProgress(-1)

                pbAvance.IsRunning = True
                tmrTranscurre.Tag = "TIMBRADO"
                lblAvance.Text = "Generando timbrado"

                ss = Shell("cd_nomina " & _serie & ".txt " & IIf(Pruebas, "pruebas ", "ws ") & Chr(34) & ParametrosCFDI.DirDestino.Trim & Chr(34), AppWinStyle.Hide, True)
                Directory.SetCurrentDirectory(dirActual)

                If Dir(dirCFDI & _serie & ".txt.folios") = "" Then
                    Err.Raise(999, Nothing, "No fue posible concluir el timbrado. Favor de revisar la bitácora.")
                Else
                    sqlExecute("UPDATE bitacora_timbrados SET timbrado = 1, fhahorafin = GETDATE() WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")

                    CompruebaTXT = File.OpenText(dirCFDI & _serie & ".txt.folios")

                    Do Until CompruebaTXT.EndOfStream
                        Linea = CompruebaTXT.ReadLine
                        Datos = Linea.Split("|")
                        UbicacionArchivo = Dir(ParametrosCFDI.DirDestino.Trim & "\" & _serie & "*" & Datos(1) & "*.pdf")
                        If UbicacionArchivo.Length > 0 Then
                            UbicacionArchivo = ParametrosCFDI.DirDestino.Trim & "\" & UbicacionArchivo
                        End If

                        If Not btnPrueba.Value Then
                            sqlExecute("UPDATE nomina SET folio_cfdi = '" & Datos(2) & "'," & _
                                  "fecha_cfdi = '" & Datos(3) & "'," & _
                                  "certificado_cfdi = '" & Datos(4) & "'," & _
                                  "ubicacion_archivo_cfdi = '" & UbicacionArchivo & "' " & _
                                  "WHERE reloj = '" & Datos(1) & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                                  "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'", "nomina")
                        End If

                    Loop
                    CompruebaTXT.Close()

                End If
                bgTimbrado.ReportProgress(-2)
                MessageBox.Show("El proceso de timbrado concluyó exitosamente." & vbCrLf & vbCrLf & "Puede encontrar los archivos resultantes en " & _
                                vbCrLf & "<" & ParametrosCFDI.DirDestino.Trim & ">", "Timbrado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Return Nothing
        Catch ex As Exception
            CompruebaTXT.Close()
            If Dir(strFileName).Length > 0 Then
                Kill(strFileName)
            End If

            Return New Exception("Error en comprobación." & vbCrLf & vbCrLf & ex.Message)
        End Try

    End Function

    'Private Sub bgTimbrado_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgTimbrado.DoWork
    Private Sub bgTimbrado_DoWork()
        Try
            Parametros.Compania = cmbCia.SelectedValue.ToString.Trim
            Parametros.Banco = txtBanco.Text.Trim
            Parametros.Riesgo = txtRiesgo.Text.Trim
            Parametros.DirComercioDigital = txtDirectorioCD.Text.Trim
            Parametros.DirDestino = txtDirectorioArchivos.Text.Trim
            Parametros.DireccionKey = txtArchivoKEY.Text.Trim
            Parametros.DireccionCer = txtArchivoCER.Text.Trim
            Parametros.PasswordKey = txtClaveKEY.Text.Trim
            Parametros.UsuarioWeb = txtUsuarioWeb.Text.Trim
            Parametros.PasswordWeb = txtClaveWeb.Text.Trim

            sqlExecute("INSERT INTO bitacora_timbrados (usuario,fhahoraini,ano,periodo) VALUES ('" & Usuario & "',GETDATE(),'" & _
                       cmbAnoPeriodo.SelectedValue.ToString.Substring(0, 4) & "','" & cmbAnoPeriodo.SelectedValue.ToString.Substring(4, 2) & "')", "nomina")

            Dim Resultado As Exception
            Resultado = InterfaceComercioDigital(strFileName, Parametros, cmbAnoPeriodo.SelectedValue, btnPrueba.Value)
            If Not Resultado Is Nothing Then
                MessageBox.Show(Resultado.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            gpAvance.Visible = False
        End Try
    End Sub

    Private Sub bgTimbrado_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgTimbrado.ProgressChanged

        If e.ProgressPercentage = -1 Then
            pbAvance.IsRunning = True
            tmrTranscurre.Tag = "TIMBRADO"
            lblAvance.Text = "Generando timbrado"
        ElseIf e.ProgressPercentage = -2 Then
            tmrTranscurre.Enabled = False
            pbAvance.IsRunning = False
            gpAvance.Visible = False
        Else
            pbAvance.IsRunning = False
            pbAvance.Value = e.ProgressPercentage
            lblAvance.Text = CType(e.UserState, String)
            'pbAvance.Value = e.ProgressPercentage
        End If
    End Sub

    'Private Sub bgTimbrado_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgTimbrado.RunWorkerCompleted
    Private Sub bgTimbrado_RunWorkerCompleted()
        gpAvance.Visible = False
        tmrTranscurre.Enabled = False
        'Me.Enabled = True
        gpParametros.Enabled = True
        gpControles.Enabled = True
        Me.ControlBox = True
    End Sub

    Private Sub tmrTranscurre_Tick(sender As Object, e As EventArgs) Handles tmrTranscurre.Tick
        Dim Procesados As Integer
        Dim Total As Integer = pbAvance.Maximum

        Dim Transcurrido As Integer
        Transcurrido = DateDiff(DateInterval.Second, HoraInicio, Now)

        If tmrTranscurre.Tag = "TIMBRADO" Then

            Procesados = Directory.EnumerateFiles(Parametros.DirDestino, "*.PDF").Count - ArchivosExistentes
            If Procesados = 0 Then
                lblAvance.Text = "PREPARANDO TIMBRADO"
            ElseIf Procesados < Total Then
                lblAvance.Text = Procesados & " registros procesados"
            Else
                lblAvance.Text = "COMPLETANDO TIMBRADO"
            End If
        End If

        lblTiempo.Text = "Tiempo transcurrido: " & Transcurrido & " segundos."
    End Sub

    Private Sub btnDirectorioCD_Click(sender As Object, e As EventArgs) Handles btnDirectorioCD.Click
        Dim dg As New FolderBrowserDialog
        dg.ShowDialog()
        If dg.SelectedPath <> "" Then
            txtDirectorioCD.Text = dg.SelectedPath
        End If
    End Sub

    Private Sub btnDirectorioArchivos_Click(sender As Object, e As EventArgs) Handles btnDirectorioArchivos.Click
        Dim dg As New FolderBrowserDialog
        dg.ShowDialog()
        If dg.SelectedPath <> "" Then
            txtDirectorioArchivos.Text = dg.SelectedPath
        End If
    End Sub
End Class