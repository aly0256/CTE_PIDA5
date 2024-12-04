Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Xml



Public Class frmTimbrado
    Dim dtDatosCFDI As New DataTable

    Dim InfoPrueba As InfoCFDI
    Dim Parametros As InfoCFDI
    Dim strFileName As String
    Dim strFileName_SEP As String
    Dim ArchivosExistentes As Integer
    Dim HoraInicio As Date
    Dim sfd As New SaveFileDialog
    Dim dtNoTimbradosSep As New DataTable
    Private archivosTimbrado As New ArrayList
    Dim sitimbrar As Boolean = False
    Dim percep_dedInCero As Boolean = False
    Dim timbrado As Boolean = False ' Indicará si ese .txtFolios se timbró
    Dim GenResumenRegPat As Boolean = False
    Dim empleados As Double = 0.0 ' Total de empleados a timbrar
    Dim lista_rj_sep As String = ""
    Dim erroresCurp As Boolean
    Dim timbro_Vers_4 As Boolean = False  ' Indica si timbró con la versión 4.0

    Dim xmlDestination As String = ""


    Private Sub frmRecibosCFDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbTipoPeriodo.DataSource = sqlExecute("select tipo_periodo, nombre from tipo_periodo where activo = 1 order by orden")
        cmbTipoPeriodo.ValueMember = "tipo_periodo"

        cmbCia.DataSource = sqlExecute("SELECT cod_comp,nombre FROM cias ORDER BY cia_default DESC,cod_comp")

        '---Version 4.0 CFDI
        InfoPrueba.DireccionKey = "XIA190128J61.key"
        InfoPrueba.DireccionCer = "XIA190128J61.cer"
        InfoPrueba.PasswordKey = "12345678a"
        InfoPrueba.UsuarioWeb = "AAA010101AAA"
        InfoPrueba.PasswordWeb = "PWD"

        '---Version 3.3
        'InfoPrueba.DireccionKey = "aaa010101aaa.key"
        'InfoPrueba.DireccionCer = "aaa010101aaa.cer"
        'InfoPrueba.PasswordKey = "12345678a"
        'InfoPrueba.UsuarioWeb = "AAA010101AAA"
        'InfoPrueba.PasswordWeb = "PWD"

        btnPrueba.Value = False
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
            txtEntidad.Text = IIf(IsDBNull(dDatos("ENTIDAD")), "", dDatos("ENTIDAD").ToString.Trim)
        Catch ex As Exception
            Stop
        End Try
    End Sub

    Private Sub AcumCFDI_Empl(ByRef dtResumen_Empl As DataTable, ByRef strFileName As String, ByRef dConcepto_empl As DataRow, ByRef ano As String, ByRef per As String)
        Try
            Dim CompruebaTXT As System.IO.StreamReader = Nothing
            Dim Linea As String
            Dim Datos() As String

            CompruebaTXT = File.OpenText(strFileName)

            Dim reg_patron As String = "", reloj As String = "", nombres As String = "", sueldo As Double = 0.0, integrado As Double = 0.0, empleados As Double = 0.0
            Do Until CompruebaTXT.EndOfStream
                Linea = CompruebaTXT.ReadLine
                Datos = Linea.Split("|")
                If Datos(0) = "NOM" Then
                    reg_patron = ""
                    reg_patron = Datos(1)
                ElseIf Datos(0) = "E01" Then

                    reloj = ""
                    nombres = ""
                    sueldo = 0.0
                    integrado = 0.0

                    reloj = Datos(1)
                    nombres = Datos(2)
                    sueldo = Double.Parse(Datos(17))
                    integrado = Double.Parse(Datos(19))

                    empleados += 1


                ElseIf Datos(0) = "P01" Or Datos(0) = "D01" Or Datos(0) = "OTP" Then
                    Dim naturaleza As String = "", cod_sat As String = "", cod_pida As String = "", descripcion As String = "", gravado As Double = 0.0, exento As Double = 0.0, monto As Double = 0.0
                    Dim grupo As String = ""
                    naturaleza = IIf(Datos(0) = "P01", "PERCEPCIONES", IIf(Datos(0) = "D01", "DEDUCCIONES", "OTROS PAGOS"))
                    cod_sat = Datos(1)
                    cod_pida = Datos(2)
                    descripcion = Datos(3)

                    Select Case naturaleza
                        Case "PERCEPCIONES"
                            grupo = "1"
                            gravado = Double.Parse(Datos(4))
                            exento = Double.Parse(Datos(5))
                            monto = gravado + exento
                        Case "OTROS PAGOS"
                            grupo = "2"
                            gravado = 0
                            exento = Double.Parse(Datos(4))
                            monto = gravado + exento
                        Case "DEDUCCIONES"
                            grupo = "3"
                            gravado = 0
                            exento = Double.Parse(Datos(4))
                            monto = gravado + exento
                    End Select

                    dConcepto_empl = dtResumen_Empl.NewRow
                    dConcepto_empl("reloj") = reloj
                    dConcepto_empl("nombres") = nombres
                    dConcepto_empl("sueldo") = sueldo
                    dConcepto_empl("integrado") = integrado

                    dConcepto_empl("naturaleza") = naturaleza
                    dConcepto_empl("cod_sat") = cod_sat
                    dConcepto_empl("cod_pida") = cod_pida
                    dConcepto_empl("descripcion") = descripcion
                    dConcepto_empl("reg_patron") = reg_patron

                    dConcepto_empl("gravado") = gravado
                    dConcepto_empl("exento") = exento
                    dConcepto_empl("monto") = monto

                    dConcepto_empl("ano") = ano
                    dConcepto_empl("periodo") = per

                    dConcepto_empl("empleados") = empleados
                    dConcepto_empl("grupo") = grupo

                    dtResumen_Empl.Rows.Add(dConcepto_empl)

                End If

            Loop
            CompruebaTXT.Close()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reporte detalle por empleado", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Inicia el timbrado
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        If (btnPrueba.Value) Then
            If MessageBox.Show("Está intentando realizar un timbrado de prueba, desea continuar?", "VALIDACION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) <>
                Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If
        End If

        If rbLista.Checked Then
            Try
                Dim advertencias As New ArrayList
                Dim continuar As Boolean = True
                Dim relojes As String() = txtListaRelojes.Text.Split(",")

                If txtListaRelojes.Text.Trim = "" Then
                    advertencias.Add("No se han especificado números de reloj")
                    continuar = False
                End If

                Dim ano As String = cmbAnoPeriodo.SelectedValue.ToString.Substring(0, 4)
                Dim periodo As String = cmbAnoPeriodo.SelectedValue.ToString.Substring(4, 2)
                Dim cod_comp As String = cmbCia.SelectedValue

                If continuar Then
                    For i As Integer = 0 To relojes.Length - 1

                        Dim r As String = relojes(i).PadLeft(5, "0")
                        Dim dtExiste As DataTable = sqlExecute("select * from personal where reloj = '" & r & "'") ' AOS: 17/08/2021 Que solo lo tome de personal
                        Dim dtExisteEnNom As DataTable = sqlExecute("select * from nomina where cod_comp='" & cod_comp & "' and reloj = '" & r & "' and ano = '" & ano &
                                                                    "' and periodo = '" & periodo & "'", "NOMINA")

                        If (dtExisteEnNom.Rows.Count = 0) Then
                            MessageBox.Show("El empleado " & r & " no tiene un registro de nómina en el periodo " & ano & periodo, "Validación",
                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        If dtExiste.Rows.Count > 0 Then
                            '--Validar que empleados ya tienen un registro de timbrado, pero tambien validar si tienen conceptos de separacion, que aun no estén timbrados
                            Dim QExistePer As String = "select reloj, isnull(selloCFD, '') as folio_cfdi from timbrado  where cod_comp='" & cod_comp &
                                "' and reloj = '" & r & "' and ano = '" & ano & "' and periodo = '" & periodo & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' " & _
                                "and reloj not in(" & _
                                "select distinct  movimientos.reloj FROM movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                                "WHERE ano+periodo = '" & cmbAnoPeriodo.SelectedValue & "'" & _
                                "AND ISNULL(CONCEPTOS.SEP,0)=1 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' " & _
                                "and movimientos.reloj not in (select reloj from timbrado where cod_comp='" & cod_comp & "' and ano+periodo='" & cmbAnoPeriodo.SelectedValue &
                                "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and isnull(isr_sep,0)=1)" & _
                                ")"

                            Dim dtExisteEnPeriodo As DataTable = sqlExecute(QExistePer, "nomina")

                            If dtExisteEnPeriodo.Rows.Count > 0 Then
                                Dim folio_cfdi As String = RTrim(dtExisteEnPeriodo.Rows(0)("folio_cfdi"))
                                If folio_cfdi <> "" Then
                                    advertencias.Add("El empleado " & r & " ya tiene un registro de CFDI en el periodo " & ano & periodo)
                                End If
                            End If
                        Else
                            advertencias.Add("El empleado " & r & " no existe en la base de datos de personal")
                        End If

                    Next
                End If

                Dim m As String = ""
                If advertencias.Count > 0 Then

                    m &= "ADVERTENCIA" & vbCrLf

                    For Each a As String In advertencias
                        m &= a & vbCrLf
                    Next

                    m &= "¿Está seguro que desea continuar?"

                    If MessageBox.Show(m, "Validación", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.OK Then
                        Exit Sub
                    End If
                End If
            Catch ex As Exception

            End Try
        End If

        Dim dDatos As DataRow
        Try
            If cmbCia.SelectedValue Is Nothing Then Exit Sub
            dtDatosCFDI = sqlExecute("SELECT * FROM DATOS_CFDI WHERE cod_comp = '" & cmbCia.SelectedValue & "'", "NOMINA")

            If dtDatosCFDI.Rows.Count = 0 Then
                sqlExecute("INSERT INTO datos_CFDI (cod_comp,dir_key,dir_cer,pass_key,USER_WEB,pass_web,dircomdig,dirdestino,banco,riesgo_pto,entidad) VALUES (" & _
                         "'" & cmbCia.SelectedValue & "','" & txtArchivoKEY.Text.Trim & "','" & txtArchivoCER.Text.Trim & "','" & txtClaveKEY.Text.Trim & "'," & _
                         "'" & txtUsuarioWeb.Text.Trim & "','" & txtClaveWeb.Text.Trim & "','" & txtDirectorioCD.Text.Trim & "','" & txtDirectorioArchivos.Text.Trim & "'," & _
                         "'" & txtBanco.Text.Trim & "','" & txtRiesgo.Text.Trim & "','" & txtEntidad.Text.Trim & "')", "NOMINA")

                dtDatosCFDI = sqlExecute("SELECT * FROM DATOS_CFDI WHERE cod_comp = '" & cmbCia.SelectedValue & "'", "NOMINA")
            End If

            dDatos = dtDatosCFDI.Rows(0)

            Dim QueryUpdate As String = "UPDATE datos_CFDI SET dir_key = '" & txtArchivoKEY.Text.Trim & "'," & _
                       "dir_cer = '" & txtArchivoCER.Text.Trim & "'," & _
                       "pass_key = '" & txtClaveKEY.Text.Trim & "'," & _
                       "user_web = '" & txtUsuarioWeb.Text.Trim & "'," & _
                       "pass_web = '" & txtClaveWeb.Text.Trim & "'," & _
                       "dircomdig = '" & txtDirectorioCD.Text.Trim & "'," & _
                       "dirdestino = '" & txtDirectorioArchivos.Text.Trim & "'," & _
                       "banco = '" & txtBanco.Text.Trim & "'," & _
                       "riesgo_pto = '" & txtRiesgo.Text.Trim & "', " & _
                          "entidad = '" & txtEntidad.Text.Trim & "' " & _
                       "WHERE cod_comp = '" & cmbCia.SelectedValue & "'"

            sqlExecute(QueryUpdate, "NOMINA")

            If Not Directory.Exists(txtDirectorioArchivos.Text.Trim) Then
                MessageBox.Show("El directorio " & txtDirectorioArchivos.Text.Trim & " no es válido", "Directorio no válido", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            gpParametros.Enabled = False
            gpControles.Enabled = False
            Me.ControlBox = False

            HoraInicio = Now
            tmrTranscurre.Tag = "INICIO"
            tmrTranscurre.Enabled = True

            ArchivosExistentes = Directory.EnumerateFiles(txtDirectorioArchivos.Text.Trim, "*.PDF").Count
            gpAvance.Visible = True
            bgTimbrado_DoWork() '-- Comienza el timbrado
            bgTimbrado_RunWorkerCompleted()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPrueba_ValueChanged(sender As Object, e As EventArgs) Handles btnPrueba.ValueChanged
        '---2024-05-29, a partir del 2024 tomar datos de la empresa para timbrar de prueba
        If btnPrueba.Value Then
            MostrarInformacion()

            'txtArchivoKEY.Text = InfoPrueba.DireccionKey
            'txtArchivoCER.Text = InfoPrueba.DireccionCer
            'txtClaveKEY.Text = InfoPrueba.PasswordKey
            'txtUsuarioWeb.Text = InfoPrueba.UsuarioWeb
            'txtClaveWeb.Text = InfoPrueba.PasswordWeb
        Else
            MostrarInformacion()
        End If

        txtArchivoKEY.Enabled = Not btnPrueba.Value
        txtArchivoCER.Enabled = Not btnPrueba.Value
        txtClaveKEY.Enabled = Not btnPrueba.Value
        txtUsuarioWeb.Enabled = Not btnPrueba.Value
        txtClaveWeb.Enabled = Not btnPrueba.Value
    End Sub

    Private Function InterfaceComDigSep(ByVal strFileName As String, ByVal ParametrosCFDI As InfoCFDI, ByVal AnoPeriodo As String, ByVal Pruebas As Boolean, ByVal dtMovSep As DataTable, ByVal _pathNom33 As String) As Exception
        sitimbrar = False
        Dim dtCias As New DataTable
        Dim dtPeriodos As New DataTable
        Dim dtAuxiliares As New DataTable
        Dim dtPersonal As New DataTable
        Dim dtErrores As New DataTable

        Dim _serie As String = cmbCia.SelectedValue & "NOM" & AnoPeriodo & "_SEP" '-- Archivo de seperación
        Dim _folio As Integer = 1
        Dim _lugar_expedicion As String = "CD. JUAREZ, CHIH"
        Dim _fecha_expedicion As String = DatePart(DateInterval.Year, Now) & _
            DatePart(DateInterval.Month, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Day, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Hour, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Minute, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Second, Now).ToString.Trim.PadLeft(2, "0")

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
        Dim _sncf As String
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
        Dim entidad As String

        Dim i As Integer

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

        Dim _total_otros_pagos As Double

        Dim _texto As String = ""

        Dim SumaPercepciones As Double = 0
        Dim SumaDeducciones As Double = 0
        Dim SumaOTP As Double = 0
        Dim SumaEmpleados As Integer = 0

        Dim CompruebaTXT As System.IO.StreamReader = Nothing
        Dim Linea As String
        Dim Datos() As String
        Dim FNErrores As String
        Dim T As Integer = 0
        Dim UbicacionArchivo As String

        Dim objFS As New FileStream(strFileName, FileMode.Create, FileAccess.Write)
        Dim ArchivoTXT As New StreamWriter(objFS, System.Text.Encoding.UTF8)
        Dim dtCREPAG As New DataTable
        Dim _total_crepag As Double

        Try
            Try
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
            entidad = ParametrosCFDI.entidad

            dtCias = sqlExecute("SELECT * FROM cias WHERE cod_comp = '" & ParametrosCFDI.Compania & "'")
            If dtCias.Rows.Count = 0 Then Err.Raise(999, Nothing, "No se encontro informacion de la compañia.")

            _registro_patronal = IIf(IsDBNull(dtCias.Rows(0).Item("reg_pat")), "SIN REGISTRO", dtCias.Rows(0).Item("reg_pat").ToString.Trim)
            _registro_patronal = _registro_patronal.Replace(" ", "").Replace("-", "")


            If Not Pruebas Then
                _rfc_cia = IIf(IsDBNull(dtCias.Rows(0).Item("rfc")), "SIN REGISTRO", dtCias.Rows(0).Item("rfc").ToString.Trim)
                _rfc_cia = _rfc_cia.Replace(" ", "").Replace("-", "")
            Else
                '----A partir del 2024 tomar datos de la empresa para timbrar de prueba
                _rfc_cia = IIf(IsDBNull(dtCias.Rows(0).Item("rfc")), "SIN REGISTRO", dtCias.Rows(0).Item("rfc").ToString.Trim)
                _rfc_cia = _rfc_cia.Replace(" ", "").Replace("-", "")
                ' _rfc_cia = "AAA010101AAA"
            End If

            _minimo = IIf(IsDBNull(dtCias.Rows(0).Item("minimo")), 0, dtCias.Rows(0).Item("minimo"))

            _sncf = "IP"

            _nombre_cia = EliminaAcentos(IIf(IsDBNull(dtCias.Rows(0).Item("nombre")), "SIN NOMBRE", dtCias.Rows(0).Item("nombre").ToString.Trim))

            _regimen_cia = "612"

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

            Dim tabla_periodos As String = "periodos"

            Select Case cmbTipoPeriodo.SelectedValue
                Case "S"
                    tabla_periodos = "periodos"
                Case "C"
                    tabla_periodos = "periodos_catorcenal"
                Case "Q"
                    tabla_periodos = "periodos_quincenal"
                Case "M"
                    tabla_periodos = "periodos_mensual"
            End Select

            dtPeriodos = sqlExecute("SELECT fecha_ini,fecha_fin,fini_nom,ffin_nom,fecha_pago FROM " & tabla_periodos & " WHERE ano = '" & AnoPeriodo.Substring(0, 4) & _
                                    "' AND periodo ='" & AnoPeriodo.Substring(4, 2) & "'", "TA")
            If dtPeriodos.Rows.Count = 0 Then Err.Raise(999, Nothing, "No se encontró el periodo seleccionado.")

            _fechapago = IIf(IsDBNull(dtPeriodos.Rows(0).Item("fecha_pago")), _
                             DateAdd(DateInterval.Day, 5, dtPeriodos.Rows(0).Item("fecha_fin")), _
                             dtPeriodos.Rows(0).Item("fecha_pago"))

            '_fechainicialpago = dtPeriodos.Rows(0).Item("fecha_ini")
            '_fechafinalpago = dtPeriodos.Rows(0).Item("fecha_fin")

            '--Para el caso de WME las fechas son las de fecha de pago de la nomina
            _fechainicialpago = dtPeriodos.Rows(0).Item("fini_nom")
            _fechafinalpago = dtPeriodos.Rows(0).Item("ffin_nom")

            _fecha_fin = _fechafinalpago


            dtMovimientosDetalle.Columns.Add("reloj", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("naturaleza", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("tipo_percepcion", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("concepto", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("descripcion", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("monto", System.Type.GetType("System.Double"))
            dtMovimientosDetalle.Columns.Add("gravado", System.Type.GetType("System.Double"))
            dtMovimientosDetalle.Columns.Add("exento", System.Type.GetType("System.Double"))
            dtMovimientosDetalle.Columns.Add("prioridad", System.Type.GetType("System.Int16"))
            dtMovimientosDetalle.Columns.Add("OTP", System.Type.GetType("System.Int16"))
            dtMovimientosDetalle.PrimaryKey = New DataColumn() {dtMovimientosDetalle.Columns("reloj"), dtMovimientosDetalle.Columns("concepto")}

            'Busca a todo el universo de empleados que van a entrar en base al año y periodo seleccionado que estan en Nomina

            Dim Qnom As String = ""
            If rbLista.Checked Then ' Ciertos empleados
                Qnom = "SELECT RELOJ,NOMBRES,RFC,CURP,NUMIMSS,COD_DEPTO,NOMBRE_DEPTO,ALTA,COD_PUESTO,NOMBRE_PUESTO,COD_TURNO," & _
                                  "NOMBRE_TURNO,SACTUAL,cuenta,INTEGRADO,HORAS_DOBLES,HORAS_TRIPLES, nominavw.cod_pago, " & _
                                  "ISNULL((SELECT contenido FROM personal.dbo.detalle_auxiliares WHERE campo = 'EMAIL' and reloj = NominaVW.reloj),'') AS EMAIL,banco " & _
                                  "FROM nominaVW WHERE cod_comp = '" & Parametros.Compania & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                                  "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' " & _
                                  " and nominavw.reloj in ('" & lista_relojes() & "') and " & _
                                  " tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and nominavw.reloj in(" & lista_rj_sep & ")"
            Else
                Qnom = "SELECT RELOJ,NOMBRES,RFC,CURP,NUMIMSS,COD_DEPTO,NOMBRE_DEPTO,ALTA,COD_PUESTO,NOMBRE_PUESTO,COD_TURNO," & _
                  "NOMBRE_TURNO,SACTUAL,cuenta,INTEGRADO,HORAS_DOBLES,HORAS_TRIPLES, nominavw.cod_pago, " & _
                  "ISNULL((SELECT contenido FROM personal.dbo.detalle_auxiliares WHERE campo = 'EMAIL' and reloj = NominaVW.reloj),'') AS EMAIL,banco " & _
                  "FROM nominaVW WHERE cod_comp = '" & Parametros.Compania & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                  "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' " & _
                  " and nominavw.reloj in(" & lista_rj_sep & ") and " & _
                  " tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'"

            End If
            dtNomina = sqlExecute(Qnom, "nomina")

            If dtNomina.Rows.Count = 0 Then
                Err.Raise(999, Nothing, "No se encontraron registros de nómina pendientes de timbrar, que cumplan con las condiciones especificadas.")
            End If

            dtNomina.Columns.Add("COD_PAGO_SAT")

            dtNomina.Columns.Add("INCLUIR")
            pbAvance.Maximum = dtNomina.Rows.Count

            T = 0

            '--Evaluar a cada empleado de la nomina en ese año y periodo  (------SEPARACION ------)
            For Each dReg As DataRow In dtNomina.Rows
                T += 1

                pbAvance.IsRunning = True
                pbAvance.Value = T
                lblAvance.Text = "Preparando"

                Dim _rfc As String = "", _curp As String = ""
                Try : _rfc = dReg("rfc").ToString.Trim : Catch ex As Exception : _rfc = "" : End Try
                Try : _curp = dReg("curp").ToString.Trim : Catch ex As Exception : _curp = "" : End Try

                If _rfc = "" Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    MessageBox.Show("Errores en RFC...Empleado: - " & dReg("reloj").ToString & " - no tiene capturado su RFC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    ArchivoTXT.Close() ' AOS 2021-08-09
                    Exit Function
                End If

                If _curp = "" Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    MessageBox.Show("Errores en CURP...Empleado: - " & dReg("reloj").ToString & " - no tiene capturado su CURP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    ArchivoTXT.Close() ' AOS 2021-08-09
                    Exit Function
                End If

                If Not ValidaRFC(dReg("rfc")) Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    dtErrores.Rows.Add({dReg("reloj"), "RFC inválido (" & dReg("rfc").ToString.Trim & ")"})
                    MessageBox.Show("Errores en RFC...Empleado: - " & dReg("reloj") & " -", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    Exit Function
                    '  Continue For
                End If

                If Not ValidaCURP(dReg("curp")) Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    dtErrores.Rows.Add({dReg("reloj"), "CURP inválido (" & dReg("rfc").ToString.Trim & ")"})
                    MessageBox.Show("Errores en CURP...Empleado: - " & dReg("reloj") & " -", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    Exit Function
                    '  Continue For
                End If



                '--Evaluar cada movimiento de separación de cada empleado
                For Each dMov In dtMovSep.Select("reloj = '" & dReg("reloj") & "'")
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
                            dMovDetalle("OTP") = dMov("OTP")

                            dtMovimientosDetalle.Rows.Add(dMovDetalle)
                        Else
                            dMovDetalle("monto") += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                        End If

                        If Not IsDBNull(dMov("exento")) Then

                            dtExento = dtMovSep.Clone
                            Try
                                dtExento = dtMovSep.Select("concepto = '" & dMov("exento").ToString.Trim & _
                                                  "' AND reloj = '" & dReg("reloj") & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                                                  "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'").CopyToDataTable
                            Catch ex As Exception

                            End Try


                            If dtExento.Rows.Count = 0 Then
                                _exento = 0
                            Else
                                _exento = dtExento.Rows(0).Item("monto")
                            End If
                            dMovDetalle("exento") = _exento
                        Else '--AOS: Para que no mande en Nulo el exento
                            _exento = 0
                            dMovDetalle("exento") = _exento
                        End If
                    End If
                Next
            Next

            For Each row As DataRow In dtNomina.Select("INCLUIR = 'SI'")
                Dim cod_pago As String = row("cod_pago")
                Select Case cod_pago
                    Case "C"
                        row("cod_pago_sat") = "02"
                    Case "D"
                        row("cod_pago_sat") = "03"
                    Case "E"
                        row("cod_pago_sat") = "99"
                    Case "L"
                        row("cod_pago_sat") = "99"
                End Select
            Next

            FNErrores = Parametros.DirDestino
            FNErrores = IIf(strFileName.Substring(FNErrores.Trim.Length - 1) <> "\", FNErrores.Trim & "\", FNErrores) & "ErroresDetectados.xlsx"
            '   If dtErrores.Rows.Count > 0 Then MessageBox.Show("Errores en CURP...")

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
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                MessageBox.Show("Hay empleados con cantidades exentas mayores a los montos, no es posible continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim advertencias As New ArrayList
                For Each dr As DataRow In dtMovimientosDetalle.Select("exento > monto AND exento <> 0")
                    Dim Rj As String = dr("Reloj").ToString.Trim
                    Dim Concepto As String = dr("concepto").ToString.Trim
                    Dim monto As Double = Double.Parse(dr("monto"))
                    Dim exento As Double = Double.Parse(dr("exento"))
                    Dim descrip As String = dr("descripcion").ToString.Trim
                    advertencias.Add("-Empleado " & Rj & " -Concepto: " & Concepto & " - Monto:" & monto & "   - Exento:" & exento)
                Next

                Dim m As String = ""
                If advertencias.Count > 0 Then
                    m &= "ADVERTENCIA" & vbCrLf
                    For Each a As String In advertencias
                        m &= a & vbCrLf
                    Next
                    MessageBox.Show(m, "Empleados no Timbrados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Exit Function
                '    Err.Raise(999, Nothing, "¡ALERTA!" & vbCrLf & "Existen cantidades exentas mayores a los montos. No es posible continuar")
            End If

            '//*** Para cambiar la naturaleza de cuales conceptos en negativo, ya que la interface de Comercio Digital no acepta montos negativos IVO
            For Each dMov In dtMovimientosDetalle.Select("monto<0 AND naturaleza= 'D'")
                dMov("tipo_percepcion") = "038"
                dMov("naturaleza") = "P"
                dMov("concepto") = "MARCAP"
                dMov("descripcion") = "Otras Percepciones Exentas"
                dMov("monto") = -IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                dMov("gravado") = -IIf(IsDBNull(dMov("gravado")), 0, dMov("gravado"))
                dMov("exento") = IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
            Next

            For Each dMov In dtMovimientosDetalle.Select("monto<0 AND naturaleza= 'P'")
                dMov("tipo_percepcion") = "004"
                dMov("naturaleza") = "D"
                dMov("concepto") = "MARCAD"
                dMov("descripcion") = "Otras Deducciones"
                dMov("monto") = -IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                dMov("gravado") = -IIf(IsDBNull(dMov("gravado")), 0, dMov("gravado"))
                dMov("exento") = IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
            Next
            For Each dMov In dtMovimientosDetalle.Select("concepto='MARCAP'")
                dMov("concepto") = "OTPNOG"
            Next
            For Each dMov In dtMovimientosDetalle.Select("concepto='MARCAD'")
                dMov("concepto") = "OTRASD"
            Next

            i = dtMovimientosDetalle.Select("exento > monto AND exento <> 0").Count
            If i > 0 Then
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                MessageBox.Show("Hay empleados con cantidades exentas mayores a los montos, no es posible continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim advertencias As New ArrayList
                For Each dr As DataRow In dtMovimientosDetalle.Select("exento > monto AND exento <> 0")
                    Dim Rj As String = dr("Reloj").ToString.Trim
                    Dim Concepto As String = dr("concepto").ToString.Trim
                    Dim monto As Double = Double.Parse(dr("monto"))
                    Dim exento As Double = Double.Parse(dr("exento"))
                    Dim descrip As String = dr("descripcion").ToString.Trim
                    advertencias.Add("-Empleado " & Rj & " -Concepto: " & Concepto & " - Monto:" & monto & "   - Exento:" & exento)
                Next

                Dim m As String = ""
                If advertencias.Count > 0 Then
                    m &= "ADVERTENCIA" & vbCrLf
                    For Each a As String In advertencias
                        m &= a & vbCrLf
                    Next
                    MessageBox.Show(m, "Empleados no Timbrados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Exit Function
                '    Err.Raise(999, Nothing, "¡ALERTA!" & vbCrLf & "Existen cantidades exentas mayores a los montos. No es posible continuar")
            End If

            _total_crepag = 0

            dtCREPAG.Columns.Add("reloj", System.Type.GetType("System.String"))
            dtCREPAG.Columns.Add("nombres", System.Type.GetType("System.String"))
            dtCREPAG.Columns.Add("monto", System.Type.GetType("System.Double"))

            For Each dc As DataRow In dtMovSep.Select("concepto = 'CREFIS'")

                Dim rows() As DataRow = dtMovimientosDetalle.Select("concepto = 'CREPAG' and reloj = '" & dc("reloj") & "'")
                If Not rows.Count > 0 Then
                    dtMovimientosDetalle.Rows.Add({dc("reloj"),
                                            "O",
                                            "002",
                                            "CREPAG",
                                            "SUBSIDIO AL EMPLEO PAGADO",
                                            0.01,
                                            0,
                                            0.01,
                                             1160})
                    _total_crepag = _total_crepag + 0.01

                    Dim tempo As DataTable = sqlExecute("select * from personalvw where reloj = '" & dc("reloj") & "'")
                    dtCREPAG.Rows.Add({dc("reloj"),
                                       IIf(IsDBNull(tempo.Rows(0).Item("nombres")), "N/A", tempo.Rows(0).Item("nombres")),
                                       0.01
                                      })

                End If

            Next

            'TOTAL OTROS PAGOS [CONCEPTOS.OTP = 1]
            For Each dMov In dtMovimientosDetalle.Rows
                Dim _mnto As Double = 0.0
                Dim Exen As Double = 0.0
                Try : _mnto = Double.Parse(dMov("monto")) : Catch ex As Exception : _mnto = 0.0 : End Try
                Try : Exen = Double.Parse(dMov("exento")) : Catch ex As Exception : Exen = 0.0 : End Try

                ' dMov("gravado") = dMov("monto") - IIf(IsDBNull(dMov("exento")), 0, dMov("exento"))
                dMov("gravado") = Math.Round(_mnto - Exen, 2)

                ' If RTrim(dMov("concepto")) = "COMVIA" Then  ' Conceptos para OTROS PAGOS (OTP = COD_SAT = 999), van aqui fijos
                If RTrim(dMov("OTP")) = "1" Then
                    _total_otros_pagos += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))

                ElseIf dMov("naturaleza").ToString.Trim = "P" Then
                    _total_percepciones += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))

                ElseIf dMov("naturaleza").ToString.Trim = "D" Then
                    Dim monto As Double = IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                    If monto >= 0 Then
                        _total_deducciones += monto
                    ElseIf monto < 0 Then
                        _total_otros_pagos += (monto * -1)
                    End If

                End If
            Next

            _total_empleados = dtNomina.Select("incluir = 'SI'").Count

            If (_total_otros_pagos > 0 And (_total_percepciones = 0 And _total_deducciones = 0)) Then  ' Solo viene el concepto de OTP (Otros pagos)
                GoTo SaltarPer
            End If

            If _total_percepciones <= 0 Or _total_deducciones < 0 Then Err.Raise(999, Nothing, "Falta información. Favor de revisar")
SaltarPer:

            sqlExecute("UPDATE bitacora_timbrados SET tot_per = " & _total_percepciones & "," & _
           "tot_ded = " & _total_deducciones & "," & _
           "tot_neto = " & _total_percepciones - _total_deducciones & " WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")

            Dim cod_pago_sat As String = "03"

            '--AOS - 03/12/2019: Validar fecha de pago si la va a tomar del campo correspondiente o de TA.dbo.Periodos
            If (chkFecPago.Checked) Then
                Dim FPag As String = ""
                Try : FPag = FechaSQL(txtFecPago.Value) : Catch ex As Exception : FPag = "" : End Try
                If (FPag <> "" And FPag <> "0001-01-01") Then
                    _fechapago = txtFecPago.Value
                End If
            End If
            '--Ends

            '	*** ENCABEZADO DE ARCHIVO CON DATOS DEL PATRON, donde va la fecha de pago
            Dim tNom As String = "E" ' En separación siempre es Extraordinaria
            _texto = "EMP|" & _rfc_cia & "|" & _nombre_cia & "|" & _regimen_cia & "|||" & tNom & "|" & vbCrLf '** Esto se quita en la version 3.3 & _sncf & "||" & vbCrLf
            _texto = _texto & "KEY|" & ParametrosCFDI.DireccionKey.Trim.Replace("\", "/") & "|" & vbCrLf
            _texto = _texto & "CER|" & ParametrosCFDI.DireccionCer.Trim.Replace("\", "/") & "|" & vbCrLf
            _texto = _texto & "PVE|" & ParametrosCFDI.PasswordKey.Trim & "|" & vbCrLf
            _texto = _texto & "WS0|" & ParametrosCFDI.UsuarioWeb.Trim & "|" & ParametrosCFDI.PasswordWeb.Trim & "|" & vbCrLf
            '    _texto = _texto & "NOM|" & _registro_patronal & "|" & FechaSQL(_fechapago) & "|" & FechaSQL(_fechainicialpago) & "|" & FechaSQL(_fechafinalpago) & "|" & vbCrLf
            _texto = _texto & "NOM||" & FechaSQL(_fechapago) & "|" & FechaSQL(_fechainicialpago) & "|" & FechaSQL(_fechafinalpago) & "|" & vbCrLf
            _texto = _texto & "CFD|" & _serie & "|" & _folio & "|" & _cp_cia & "|" & _fecha_expedicion & "|" & vbCrLf
            _texto = _texto & "TOT|" & String.Format("{0:0.00}", _total_percepciones) & "|" & String.Format("{0:0.00}", _total_deducciones) & "|" & _total_empleados.ToString.Trim & "|" & String.Format("{0:0.00}", _total_otros_pagos) & "|" & vbCrLf
            _texto = _texto & "INI|"

            ArchivoTXT.WriteLine(_texto)

            Dim _perc_totalgravado As Double
            Dim _perc_totalexento As Double
            Dim _ded_totalgravado As Double
            Dim _ded_totalexento As Double
            Dim _otros_pagos_empleado As Double
            Dim _textoMov As String = ""

            pbAvance.Maximum = dtNomina.Select("incluir = 'SI'").Count

            T = 0

            '--- Detalle de cada empleado (E01)
            For Each dMov In dtNomina.Select("incluir = 'SI'")
                T += 1

                pbAvance.IsRunning = True
                pbAvance.Value = T
                lblAvance.Text = "Exportando"

                Dim Rj As String = ""
                Rj = dMov("reloj").ToString.Trim

                _texto = "E01|" & dMov("reloj").ToString.Trim & "|"
                _texto = _texto & dMov("nombres").ToString.Trim.Replace(",", " ") & "|"
                _texto = _texto & dMov("rfc").ToString.Trim.Replace("-", "").PadRight(13, "X") & "|"
                _texto = _texto & dMov("curp").ToString.Trim & "|"
                '   _texto = _texto & "02|" ' Tipo regimen empleado
                _texto = _texto & "13|" ' Tipo regimen empleado, en Separacion = 13
                '  _texto = _texto & dMov("numimss").ToString.Trim & "|"
                _texto = _texto & "|" ' Quitamos el NO.Imss en separación


                'Dias pagados desde movimientos (SEPARACION)

                Dim dias_pag_default As String = "14" ' TBC Dias pagados por default  dependiendo de los dias del periodo AOS 18/08/2021
                Dim concepDiasPag As String = "DIASPA" ' &&_ Concepto que viene desde movs  que trae los diasPag OJO: No debe de mandarse en decimales, siempre en Enteros
                Dim montoDiasPag As String = "14", periodicidad As String = "99"

                '---Define el tipo de periodicidad
                Select Case cmbTipoPeriodo.SelectedValue.ToString.Trim
                    Case "S"
                        periodicidad = "99" ' Para los de separación, el tipo de periodicidad es 99
                        dias_pag_default = "7"
                        montoDiasPag = "7"
                    Case "C"
                        periodicidad = "99" ' Para los de separación, el tipo de periodicidad es 99
                        dias_pag_default = "14"
                        montoDiasPag = "14"
                    Case "Q"
                        periodicidad = "99" ' Para los de separación, el tipo de periodicidad es 99
                        dias_pag_default = "15"
                        montoDiasPag = "15"
                    Case "M"
                        periodicidad = "99" ' Para los de separación, el tipo de periodicidad es 99
                        dias_pag_default = "30"
                        montoDiasPag = "30"
                    Case Else
                        periodicidad = "99" ' Para los de separación, el tipo de periodicidad es 99
                        dias_pag_default = "7"
                        montoDiasPag = "7"
                End Select

                Try
                    'NOTA: Los días pagados (numDiasPagados) deben de ir enteros, pero si traen decimal, a tres dig, ejemplo: 7.8 --> 7.800 (-----------SEPARACION ----------)
                    'NOTA2: En archivos de separación, los DIASPA tienen que equivaler  a los de dias de Indem, si no trae, que equivalgan a los dias por PRIANT, y si no trae nada, que tome en base a los dias del periodo
                    '     Dim dtDiasPagados As DataTable = sqlExecute("select * from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "' and reloj='" & dMov("reloj").ToString.Trim & "' and cod_comp='" & Parametros.Compania & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and concepto='" & concepDiasPag & "'", "NOMINA") ' Buscando por COD_COMP
                    Dim dtDiasPagados As DataTable = sqlExecute("select * from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "' and reloj='" & dMov("reloj").ToString.Trim & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and concepto='" & concepDiasPag & "'", "NOMINA")
                    If (Not dtDiasPagados.Columns.Contains("Error") And dtDiasPagados.Rows.Count > 0) Then
                        Try : montoDiasPag = dtDiasPagados.Rows(0).Item("MONTO").ToString.Trim : Catch ex As Exception : montoDiasPag = dias_pag_default : End Try
                    Else
                        montoDiasPag = dias_pag_default
                    End If

                    '---Validar que los dias pagados sean mayor a cero 2022-11-29
                    Dim numdiaspagados As Double = 0.0
                    Try : numdiaspagados = Double.Parse(montoDiasPag) : Catch ex As Exception : numdiaspagados = 1 : End Try
                    If numdiaspagados <= 1 Then montoDiasPag = "1"

                    '---Si trae decimales, dejarlo  a 7.800 por ejemplo, siempre a 3 digitos
                    If (montoDiasPag.Contains(".")) Then
                        Dim cade1 As String = "", cade2 As String = ""
                        cade1 = montoDiasPag.Split(".")(0)
                        cade2 = montoDiasPag.Split(".")(1).PadRight(3, "0")
                        cade2 = cade2.Substring(0, 3) ' Siempre a 3 dígitos
                        montoDiasPag = cade1 & "." & cade2
                    End If

                    _texto = _texto & montoDiasPag & "|"  '&& Días pagados desde movimientos

                Catch ex As Exception
                    _texto = _texto & montoDiasPag & "|"  '&& Default
                End Try
                '---- ENDS  [numDiasPagados]


                _texto = _texto & EliminaAcentos(dMov("nombre_depto").ToString.ToUpper.Trim) & "|"

                '--- Obtener el codigo del banco de acuerdo al banco que debe de trae el empleado
                Dim nombreBanco As String = ""
                Try : nombreBanco = dMov("BANCO").ToString.Trim.ToUpper : Catch ex As Exception : nombreBanco = "" : End Try

                Select Case nombreBanco
                    Case "BANCOMER"
                        _banco = "012"
                    Case "HSBC"
                        _banco = "021"
                    Case "SANTANDER"
                        _banco = "014"
                    Case "BBVA BANCOMER"
                        _banco = "012"
                    Case Else
                        _banco = ParametrosCFDI.Banco
                End Select


                If dMov("cod_pago_sat") = "03" Then
                    _texto = _texto & dMov("cuenta").ToString.Trim.PadLeft(11, "0") & "|" ' cuenta bancaria
                    _texto = _texto & (_banco) & "|"  '&& CLABE PENDIENTE
                Else
                    _texto = _texto & "|" ' cuenta bancaria
                    _texto = _texto & "|"  '&& CLABE PENDIENTE
                End If

                Dim antigEmpl As String = ""
                Try : antigEmpl = Math.Truncate((DateDiff(DateInterval.Day, dMov("alta"), _fecha_fin) + 1) / 7).ToString.Trim : Catch ex As Exception : antigEmpl = "1" : End Try

                '    _texto = _texto & FechaSQL(dMov("alta")) & "|"
                _texto = _texto & "|" ' Quitamos el Alta en Separación
                _texto = _texto & antigEmpl & "|" ' Antiguedad del empleado
                _texto = _texto & dMov("nombre_puesto").ToString.ToUpper.Trim & "|"
                ' _texto = _texto & "01|"   ' tipo contrato PENDIENTE
                _texto = _texto & "99|" ' Dejamos el 99 en Separación
                _texto = _texto & IIf(dMov("cod_turno") = "2" Or dMov("cod_turno") = "9", "03", IIf(dMov("cod_turno") = "3", "02", "01")) & "|" ' tipo jornada
                _texto = _texto & periodicidad & "|" ' periodicidad 
                _texto = _texto & String.Format("{0:0.00}", dMov("sactual")) & "|"
                '   _texto = _texto & _riesgo_pto & "|"
                _texto = _texto & "|" ' Quitamos Riesgo de puesto en separación
                '  _texto = _texto & String.Format("{0:0.00}", dMov("integrado")) & "|"
                _texto = _texto & "|" ' Quitamos Integrado en Separación
                _texto = _texto & "No|" ' sindicalizado
                _texto = _texto & entidad & "|" ' sindicalizado

                If (dMov("email").ToString.Length > 0 And Not Pruebas) And sbEmail.Value = True Then
                    _texto = _texto & dMov("email").ToString.Trim & "|"
                Else
                    _texto = _texto & "|"
                End If

                _perc_totalgravado = 0
                _perc_totalexento = 0
                _ded_totalgravado = 0
                _ded_totalexento = 0

                _otros_pagos_empleado = 0

                '** PERCEPCIONES
                _textoMov = ""

                'Manejar indemnizaciones
                ' SE INCLUYE EL REGISTRO PARA LOS 3 CONCEPTOS (INDEMN, PRIANT, NOREST)
                Try
                    Dim dtINDEMN As DataTable = dtMovimientosDetalle.Select("concepto in ('INDEMN', 'PRIANT', 'NOREST') AND reloj = '" & dMov("reloj").ToString.Trim & "'").CopyToDataTable
                    If dtINDEMN.Rows.Count > 0 Then
                        Dim dtDatosPersonal As DataTable = sqlExecute("select reloj, sactual, alta, baja from personal where reloj = '" & dMov("reloj") & "' and baja is not null")
                        If dtDatosPersonal.Rows.Count > 0 Then
                            Dim sactual As Double = dtDatosPersonal.Rows(0)("sactual")
                            Dim alta As Date = dtDatosPersonal.Rows(0)("alta")
                            Dim baja As Date = dtDatosPersonal.Rows(0)("baja")
                            Dim antig As Integer = DateDiff(DateInterval.Year, alta, baja) + 1

                            Dim ddetalle As Double = 0

                            For Each row As DataRow In dtINDEMN.Rows
                                ddetalle += row("monto")
                            Next

                            _textoMov = _textoMov & "S01|" & String.Format("{0:0.00}", ddetalle) ' Total pagado
                            _textoMov = _textoMov & "|" & antig ' anios servicio
                            _textoMov = _textoMov & "|" & String.Format("{0:0.00}", sactual * 30.4) ' ultimo sueldo mensual
                            _textoMov = _textoMov & "|" & String.Format("{0:0.00}", 0) ' ingreso acumulable
                            _textoMov = _textoMov & "|" & String.Format("{0:0.00}", 0) ' ingreso no acumulable
                            _textoMov = _textoMov & "|" & vbCrLf
                        End If
                    End If

                Catch ex As Exception

                End Try

                'HABRA UNA EXCEPCION SI EL EMPLEADO NO TIENE OTPs
                Try ' Conceptos para OTP otros pagos (OTP = COD_SAT = 999), van fijos aquí, En la tabla CONCEPTOS ya debe de venir el campo de OTP = 1 refiriendo que es como Otros Pagos
                    Dim dtOTP As DataTable = dtMovimientosDetalle.Select("OTP = 1 AND reloj = '" & dMov("reloj").ToString.Trim & "'", "PRIORIDAD,TIPO_PERCEPCION").CopyToDataTable

                    For Each dDetalle As DataRow In dtOTP.Rows

                        _textoMov = _textoMov & "OTP|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                        _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                        _textoMov = _textoMov & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                        _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto")) & "|"

                        '--- Interface SEPARCION

                        Dim _subsidio_causado As Double = 0
                        Dim _concepto_otp As String = RTrim(dDetalle("concepto").ToString.Trim)

                        Select Case _concepto_otp
                            Case "CREPAG"
                                '   For Each row As DataRow In dtMovimientos.Select("concepto in ('CREFIS') AND reloj = '" & dMov("reloj").ToString.Trim & "'")
                                For Each row As DataRow In dtMovimientos.Select("concepto in ('SUBEMP') AND reloj = '" & dMov("reloj").ToString.Trim & "'")
                                    Try
                                        _subsidio_causado += Double.Parse(row("monto"))
                                    Catch ex As Exception

                                    End Try
                                Next
                                '12/02/2020: AOS - Agregar CREPAG de 0.01 para timbrado
                                If _subsidio_causado = 0 Then
                                    _subsidio_causado = 0.01
                                End If
                                If (_subsidio_causado < 0) Then _subsidio_causado = _subsidio_causado * -1
                                _textoMov = _textoMov & String.Format("{0:0.00}", _subsidio_causado) & "|||"
                        End Select

                        _textoMov = _textoMov & "|" & vbCrLf

                        _otros_pagos_empleado += dDetalle("monto")

                    Next
                Catch ex As Exception

                End Try

                '** DEDUCCIONES NEGATIVAS
                For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'D' AND reloj = '" & dMov("reloj").ToString.Trim & "' and isnull(exento,0) < 0", "PRIORIDAD,TIPO_PERCEPCION")

                    Dim _concepto As String = dDetalle("concepto").ToString.Trim

                    _textoMov = _textoMov & "OTP|" & IIf(_concepto = "ISRCOM", "004", "999") & "|" & _concepto & "|" & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                    _textoMov = _textoMov & String.Format("{0:0.00}", Double.Parse(dDetalle("exento")) * -1) & "|"

                    If _concepto = "ISRCOM" Then
                        _textoMov = _textoMov & "|" & String.Format("{0:0.00}", Double.Parse(dDetalle("exento")) * -1) & "|" & Now.Year - 1 & "|0.00"
                    Else
                        _textoMov = _textoMov & "|||"
                    End If

                    _textoMov = _textoMov & "|" & vbCrLf

                    _otros_pagos_empleado += Double.Parse(dDetalle("exento")) * -1

                Next

                '--Excluir los conceptos que son Otros Pagos (OTP) (Otros pagos con cod_sat = 999 ya que esos no entran al total de percepciones)
                '  For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'P' AND reloj = '" & dMov("reloj").ToString.Trim & "' and concepto not in ('COMVIA')", "PRIORIDAD,TIPO_PERCEPCION")
                For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'P' AND reloj = '" & dMov("reloj").ToString.Trim & "' and ISNULL(OTP,0)=0 and monto>0", "PRIORIDAD,TIPO_PERCEPCION")
                    _textoMov = _textoMov & "P01|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                    _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                    _textoMov = _textoMov & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("gravado")) & "|"
                    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("exento")) & "|"

                    'El detalle de la percepción extra se incluye dentro de la misma línea

                    If dDetalle("tipo_percepcion").ToString.Trim = "019" Then
                        _textoMov = _textoMov & "1|" ' && DIAS EN QUE SE PAGA TIEMPO EXTRA
                        If dDetalle("concepto").ToString.Trim = "PEREX2" Then
                            _textoMov = _textoMov & "01|"
                            Dim horas As Integer = Math.Truncate(dMov("horas_dobles"))
                            If horas > 0 Then
                                _textoMov = _textoMov & horas & "|"
                            Else
                                _textoMov = _textoMov & "1|"
                            End If

                        ElseIf dDetalle("concepto").ToString.Trim = "PEREX3" Then
                            _textoMov = _textoMov & "02|"
                            Dim horas As Integer = Math.Truncate(dMov("horas_triples"))
                            If horas > 0 Then
                                _textoMov = _textoMov & horas & "|"
                            Else
                                _textoMov = _textoMov & "1|"
                            End If
                        End If
                        _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto"))
                    Else
                        _textoMov = _textoMov & "|||"
                    End If

                    _textoMov = _textoMov & "|" & vbCrLf

                    _perc_totalgravado += IIf(IsDBNull(dDetalle("gravado")), 0, dDetalle("gravado"))
                    _perc_totalexento += IIf(IsDBNull(dDetalle("exento")), 0, dDetalle("exento"))

                Next

                '** DEDUCCIONES
                For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'D' AND reloj = '" & dMov("reloj").ToString.Trim & "' and isnull(exento,0) >= 0 ", "PRIORIDAD,TIPO_PERCEPCION")

                    _textoMov = _textoMov & "D01|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                    _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                    _textoMov = _textoMov & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"


                    '--12/02/2020 AOS: Agregar CREPAG de 0.01 para timbrado
                    If dDetalle("concepto").ToString.Trim = "AJUSUB" Then
                        '   dDetalle("exento") = "0.01"
                        dDetalle("monto") = "0.01"
                    End If

                    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto")) & "|" & vbCrLf
                    _ded_totalexento += IIf(IsDBNull(dDetalle("monto")), 0, dDetalle("monto"))
                Next

                _textoMov = _textoMov & "F01|" & vbCrLf

                _texto = _texto & String.Format("{0:0.00}", _perc_totalexento + _perc_totalgravado) & "|"
                _texto = _texto & String.Format("{0:0.00}", _ded_totalexento + _ded_totalgravado) & "|"
                '   _texto = _texto & String.Format("{0:0.00}", _otros_pagos_empleado) & "|" & vbCrLf
                _texto = _texto & String.Format("{0:0.00}", _otros_pagos_empleado) & "|"

                ''--AOS: 04/02/2020: Validar si es retimbrado, para que coloque el UUID CANCELADO
                Dim uuid_canc As String = ""
                Dim KeyEmp As String = AnoPeriodo.ToString.Trim & Rj
                Dim dtRetimb As DataTable = sqlExecute("SELECT UUID from retimbrado where isnull(sep,0)=1 and ano+periodo+reloj='" & KeyEmp & "'", "NOMINA")
                If (Not dtRetimb.Columns.Contains("Error") And dtRetimb.Rows.Count > 0) Then
                    Try : uuid_canc = dtRetimb.Rows(0).Item("UUID").ToString.Trim : Catch ex As Exception : uuid_canc = "" : End Try
                    _texto = _texto & uuid_canc & "|"
                Else
                    _texto = _texto & "|"
                End If

                _texto = _texto & vbCrLf
                ''----ENDS

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

        '************/// RESUMEN FINAL / Generacion de reporte de resumen final / Timbrado

        Dim dtResumen As New DataTable
        Dim dConcepto As DataRow
        dtResumen.Columns.Add("naturaleza")
        dtResumen.Columns.Add("concepto_sat")
        dtResumen.Columns.Add("concepto_pida")
        dtResumen.Columns.Add("descripcion")
        dtResumen.Columns.Add("gravado", System.Type.GetType("System.Double"))
        dtResumen.Columns.Add("exento", System.Type.GetType("System.Double"))
        'Luis campo nuevo
        dtResumen.Columns.Add("periodo")
        dtResumen.PrimaryKey = New DataColumn() {dtResumen.Columns("naturaleza"), dtResumen.Columns("concepto_pida")}


        Try

            SumaDeducciones = 0
            SumaPercepciones = 0
            SumaEmpleados = 0
            SumaOTP = 0

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
                ElseIf Datos(0) = "P01" Or Datos(0) = "D01" Or Datos(0) = "OTP" Then
                    Dim naturaleza As String = IIf(Datos(0) = "P01", "PERCEPCIONES", IIf(Datos(0) = "D01", "DEDUCCIONES", "OTROS PAGOS"))
                    dConcepto = dtResumen.Rows.Find({naturaleza, Datos(2)})
                    If dConcepto Is Nothing Then
                        dConcepto = dtResumen.NewRow
                        dConcepto("naturaleza") = naturaleza
                        dConcepto("concepto_sat") = Datos(1)
                        dConcepto("concepto_pida") = Datos(2)
                        dConcepto("descripcion") = Datos(3)
                        'Luis campo nuevo
                        dConcepto("periodo") = "Periodo " & AnoPeriodo.Substring(4, 2) & " " & AnoPeriodo.Substring(0, 4)

                        If Datos(0) = "P01" Then
                            dConcepto("gravado") = Datos(4)
                            dConcepto("exento") = Datos(5)

                        ElseIf Datos(0) = "D01" Or Datos(0) = "OTP" Then
                            dConcepto("exento") = Datos(4)
                            dConcepto("gravado") = 0

                        End If

                        dtResumen.Rows.Add(dConcepto)
                    Else

                        If Datos(0) = "P01" Then
                            dConcepto("gravado") += Datos(4)
                            dConcepto("exento") += Datos(5)

                        ElseIf Datos(0) = "D01" Or Datos(0) = "OTP" Then
                            dConcepto("exento") += Datos(4)
                            'dConcepto("gravado") += 0

                        End If

                    End If

                    If Datos(0) = "P01" Then
                        SumaPercepciones = SumaPercepciones + Datos(4) + Datos(5)

                    ElseIf Datos(0) = "D01" Then
                        SumaDeducciones = SumaDeducciones + Datos(4)

                    ElseIf Datos(0) = "OTP" Then
                        SumaOTP = SumaOTP + Datos(4)

                    End If
                End If
            Loop
            CompruebaTXT.Close()

            SumaPercepciones = Math.Round(SumaPercepciones, 2)
            SumaDeducciones = Math.Round(SumaDeducciones, 2)

            SumaOTP = Math.Round(SumaOTP, 2)
            _total_otros_pagos = Math.Round(_total_otros_pagos, 2)

            If _total_empleados <> SumaEmpleados Then
                Err.Raise(999, Nothing, "El número de empleados no coincide con el detalle. Favor de revisar. [" & (SumaEmpleados - _total_empleados) & "]")
            ElseIf _total_percepciones <> SumaPercepciones Then
                Err.Raise(999, Nothing, "El acumulado de PERCEPCIONES no coincide con el detalle. Favor de revisar. [" & (SumaPercepciones - _total_percepciones) & "]")
            ElseIf _total_deducciones <> SumaDeducciones Then
                Err.Raise(999, Nothing, "El acumulado de DEDUCCIONES no coincide con el detalle. Favor de revisar. [" & (SumaDeducciones - _total_deducciones) & "]")
            ElseIf _total_otros_pagos <> SumaOTP Then
                Err.Raise(999, Nothing, "El acumulado de OTROS PAGOS no coincide con el detalle. Favor de revisar. [" & (SumaOTP - _total_otros_pagos) & "]")
            End If
            sqlExecute("UPDATE bitacora_timbrados SET comprueba = 1 WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")
            Try
                frmVistaPrevia.LlamarReporte("Acumulado CFDI", dtResumen, Parametros.Compania)
                frmVistaPrevia.ShowDialog()

            Catch ex As Exception

            End Try

            Dim _random As Single = 0

            If MessageBox.Show("¿Desea realizar el timbrado de los recibos de conceptos de separación?", "PIDA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                sitimbrar = True
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



                '******AOS: Se desactiva captura de valor de comprobación
                'Dim valor_capturado As Double = 0
                'Dim captura As New frmCapturaNeto

                'Dim rand As Integer = New Random().Next(0, 2)

                'Dim valor_esperado As Double = 0
                'Select Case rand
                '    Case 0
                '        valor_esperado = _total_percepciones
                '        captura.texto = "total de percepciones"
                '    Case 1
                '        valor_esperado = _total_deducciones
                '        captura.texto = "total de deducciones"
                '    Case 2
                '        valor_esperado = _total_deducciones + _total_otros_pagos - _total_deducciones
                '        captura.texto = "neto a timbrar"
                'End Select



                'If captura.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '    valor_capturado = Double.Parse(captura.TextBox1.Text)
                'Else
                '    MessageBox.Show("Es necesario realizar la captura de validación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Return Nothing
                'End If

                'If valor_capturado <> valor_esperado Then
                '    MessageBox.Show("Los valores no coinciden [Esperado:  " & valor_esperado & ", Capturado: " & valor_capturado & "], favor de confirmar la información que está timbrando", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Return Nothing
                'End If

                '*****ENDS Comprobación

                ' Eliminamos el archivo con extension Folios para que lo vuelva a crear
                Try
                    Kill(_pathNom33 & "\" & _serie & ".txt.folios")
                Catch ex As Exception
                End Try

                '---- Aquí es donde ejecuta el programa CD NOM 33 para hacer el timbrado como tal
                ss = Shell("cd_nomina33 " & _serie & ".txt " & IIf(Pruebas, "pruebas2 ", "ws ") & Chr(34) & ParametrosCFDI.DirDestino.Trim & Chr(34), AppWinStyle.Hide, True) ' a partir del 2024 será pruebas2 para timbrar de prueba
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

                        '--- AOS: Para de separacion que no aplique llenar la tabla de nomina por si hay real
                        '  If Not btnPrueba.Value Then  ' &&_AOS : Se quita para que lo actualice
                        'sqlExecute("UPDATE nomina SET folio_cfdi = '" & Datos(2) & "'," & _
                        '      "fecha_cfdi = '" & Datos(3) & "'," & _
                        '      "certificado_cfdi = '" & Datos(4) & "'," & _
                        '      "ubicacion_archivo_cfdi = '" & UbicacionArchivo & "' " & _
                        '      "WHERE reloj = '" & Datos(1) & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                        '       "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "'", "nomina")
                        '    End If

                    Loop
                    CompruebaTXT.Close()


                End If
                bgTimbrado.ReportProgress(-2)

            End If


            If (sitimbrar) Then
                Guarda_Act_xmls()  '-----AOS --- -Leer cada uno de los archivos XML's, colocarlos en el path correcto y actualizar tabla de NOMINA.dbo.timbrado
            End If

            '-----ADRIAN ORTEGA (AOS) -- Mandar detalle de los no timbrados en proceso de separación

            Dim QNoTimbSep As String = ""
            If rbLista.Checked Then
                QNoTimbSep = "select ano + '-' + PERIODO as 'Periodo',* from nomina where reloj in('" & lista_relojes() & "') and ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' " & _
                    "and reloj in (" & _
                "select distinct  movimientos.reloj FROM  movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                "WHERE ano+periodo = '" & cmbAnoPeriodo.SelectedValue & "' AND ISNULL(CONCEPTOS.SEP,0)=1 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' " & _
                "and movimientos.reloj not in (select reloj from timbrado where cod_comp='" & cmbCia.SelectedValue & "' and ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and isnull(isr_sep,0)=1)" & _
                ")"
            Else
                '--Todos los empleados
                QNoTimbSep = "select ano + '-' + PERIODO as 'Periodo',* from nomina where ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' " & _
                    "and reloj in (" & _
                "select distinct  movimientos.reloj FROM  movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                "WHERE ano+periodo = '" & cmbAnoPeriodo.SelectedValue & "' AND ISNULL(CONCEPTOS.SEP,0)=1 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' " & _
                "and movimientos.reloj not in (select reloj from timbrado where cod_comp='" & cmbCia.SelectedValue & "' and ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and isnull(isr_sep,0)=1)" & _
                ")"
            End If

            dtNoTimbradosSep = sqlExecute(QNoTimbSep, "NOMINA")

            If dtNoTimbradosSep.Rows.Count = 0 Then '------ANTONIO
                MessageBox.Show("El proceso de timbrado de separación concluyó exitosamente." & vbCrLf & vbCrLf & "Puede encontrar los archivos resultantes en " & _
            vbCrLf & "<" & ParametrosCFDI.DirDestino.Trim & ">", "Timbrado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Hubo algunos elementos no timbrados en el proceso de separación." & vbNewLine & "Se mostraran a continuacion los empleados no timbrados ",
                 "Detalle no timbrados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                frmVistaPrevia.LlamarReporte("No Timbrados", dtNoTimbradosSep, Parametros.Compania)
                frmVistaPrevia.ShowDialog()
            End If

            '---- Detalle de los no timbrados en proceso de separación

            Return Nothing
        Catch ex As Exception
            CompruebaTXT.Close()

            If Dir(strFileName).Length > 0 Then
                If MessageBox.Show("Ocurrió un error de comprobación, ¿Desea eliminar el archivo generado hasta el momento?", "Error de comprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    Kill(strFileName)
                End If
            End If

            Return New Exception("Error en comprobación." & vbCrLf & vbCrLf & ex.Message)

        End Try

    End Function

    Private Function InterfaceComercioDigital(ByVal strFileName As String, ByVal ParametrosCFDI As InfoCFDI, ByVal AnoPeriodo As String, ByVal Pruebas As Boolean, _reg_pat_planta As String, _pathNom33 As String, ByVal _dtResRegPat As DataTable, ByVal _drRP As DataRow) As Exception

        sitimbrar = False
        percep_dedInCero = False
        Dim dtCias As New DataTable
        Dim dtPeriodos As New DataTable
        Dim dtAuxiliares As New DataTable
        Dim dtPersonal As New DataTable
        Dim dtErrores As New DataTable
        Dim dtNoTimbrados As New DataTable

        Dim _serie As String = cmbCia.SelectedValue & "NOM" & AnoPeriodo
        Dim _folio As Integer = 1
        Dim _lugar_expedicion As String = "CD. JUAREZ, CHIH"
        Dim _fecha_expedicion As String = DatePart(DateInterval.Year, Now) & _
            DatePart(DateInterval.Month, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Day, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Hour, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Minute, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Second, Now).ToString.Trim.PadLeft(2, "0")

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
        Dim _sncf As String
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
        Dim entidad As String

        Dim i As Integer

        'Dim ArchivoTXT As System.IO.StreamWriter = Nothing
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

        Dim _total_otros_pagos As Double

        Dim _texto As String = ""

        Dim SumaPercepciones As Double = 0
        Dim SumaDeducciones As Double = 0
        Dim SumaOTP As Double = 0
        Dim SumaEmpleados As Integer = 0

        Dim CompruebaTXT As System.IO.StreamReader = Nothing
        Dim Linea As String
        Dim Datos() As String
        Dim FNErrores As String
        Dim T As Integer = 0
        Dim UbicacionArchivo As String

        Dim objFS As New FileStream(strFileName, FileMode.Create, FileAccess.Write)
        Dim ArchivoTXT As New StreamWriter(objFS, System.Text.Encoding.UTF8)
        Dim dtCREPAG As New DataTable
        Dim _total_crepag As Double
        Try



            Try
                'ArchivoTXT = File.CreateText(strFileName)
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
            entidad = ParametrosCFDI.entidad

            dtCias = sqlExecute("SELECT * FROM cias WHERE cod_comp = '" & ParametrosCFDI.Compania & "'")
            If dtCias.Rows.Count = 0 Then
                Err.Raise(999, Nothing, "No se encontro informacion de la compañia.")
            End If


            '    _registro_patronal = IIf(IsDBNull(dtCias.Rows(0).Item("reg_pat")), "SIN REGISTRO", dtCias.Rows(0).Item("reg_pat").ToString.Trim)
            '  _registro_patronal = _registro_patronal.Replace(" ", "").Replace("-", "")

            _registro_patronal = _reg_pat_planta ' AOS- El registro patronal va a venir por nominavw.reg_pat_planta

            '----A partir del 2024 tomar datos de la empresa para timbrar
            _rfc_cia = IIf(IsDBNull(dtCias.Rows(0).Item("rfc")), "SIN REGISTRO", dtCias.Rows(0).Item("rfc").ToString.Trim)
            _rfc_cia = _rfc_cia.Replace(" ", "").Replace("-", "")

            'If Not Pruebas Then
            '    _rfc_cia = IIf(IsDBNull(dtCias.Rows(0).Item("rfc")), "SIN REGISTRO", dtCias.Rows(0).Item("rfc").ToString.Trim)
            '    _rfc_cia = _rfc_cia.Replace(" ", "").Replace("-", "")
            'Else
            '    _rfc_cia = "AAA010101AAA"
            'End If

            _minimo = IIf(IsDBNull(dtCias.Rows(0).Item("minimo")), 0, dtCias.Rows(0).Item("minimo"))
            '_sncf = IIf(IsDBNull(dtCias.Rows(0).Item("sncf")), "", dtCias.Rows(0).Item("sncf"))

            _sncf = "IP"

            _nombre_cia = EliminaAcentos(IIf(IsDBNull(dtCias.Rows(0).Item("nombre")), "SIN NOMBRE", dtCias.Rows(0).Item("nombre").ToString.Trim))

            '_regimen_cia = IIf(IsDBNull(dtCias.Rows(0).Item("regimen")), "", dtCias.Rows(0).Item("regimen"))
            _regimen_cia = "612"

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

            Dim tabla_periodos As String = "periodos"

            Select Case cmbTipoPeriodo.SelectedValue
                Case "S"
                    tabla_periodos = "periodos"
                Case "C"
                    tabla_periodos = "periodos_catorcenal"
                Case "Q"
                    tabla_periodos = "periodos_quincenal"
                Case "M"
                    tabla_periodos = "periodos_mensual"
            End Select

            dtPeriodos = sqlExecute("SELECT fecha_ini,fecha_fin,fini_nom,ffin_nom,fecha_pago FROM " & tabla_periodos & " WHERE ano = '" & AnoPeriodo.Substring(0, 4) & _
                                    "' AND periodo ='" & AnoPeriodo.Substring(4, 2) & "'", "TA")
            If dtPeriodos.Rows.Count = 0 Then
                Err.Raise(999, Nothing, "No se encontro el periodo seleccionado.")
            End If
            _fechapago = IIf(IsDBNull(dtPeriodos.Rows(0).Item("fecha_pago")), _
                             DateAdd(DateInterval.Day, 5, dtPeriodos.Rows(0).Item("fecha_fin")), _
                             dtPeriodos.Rows(0).Item("fecha_pago"))
            '_fechainicialpago = dtPeriodos.Rows(0).Item("fecha_ini")
            '_fechafinalpago = dtPeriodos.Rows(0).Item("fecha_fin")

            '--Para el caso de WME las fechas son las de fecha de pago de la nomina
            _fechainicialpago = dtPeriodos.Rows(0).Item("fini_nom")
            _fechafinalpago = dtPeriodos.Rows(0).Item("ffin_nom")
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
            dtMovimientosDetalle.Columns.Add("OTP", System.Type.GetType("System.Int16"))
            dtMovimientosDetalle.PrimaryKey = New DataColumn() {dtMovimientosDetalle.Columns("reloj"), dtMovimientosDetalle.Columns("concepto")}

            'Busca a todo el universo de empleados que van a entrar en base al año y periodo seleccionado que estan en Nomina, y que no hayan sido timbrados
            '--AOS : Se agrega el filtro del registro patronal que lo tome de nominavw.reg_pat_planta

            '********************* Validar si está activado el botón de PTU
            Dim QN As String = ""
            If (chkPtu.Checked = True) Then
                QN = "SELECT RELOJ,NOMBRES,RFC,CURP,NUMIMSS,COD_DEPTO,NOMBRE_DEPTO,ALTA,COD_PUESTO,NOMBRE_PUESTO,COD_TURNO," & _
  "NOMBRE_TURNO,SACTUAL,cuenta,INTEGRADO,HORAS_DOBLES,HORAS_TRIPLES, nominavw.cod_pago, " & _
  "ISNULL((SELECT contenido FROM personal.dbo.detalle_auxiliares WHERE campo = 'EMAIL' and reloj = NominaVW.reloj),'') AS EMAIL,banco " & _
  "FROM nominaVW WHERE cod_comp = '" & Parametros.Compania & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
  "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' " & _
  IIf(rbLista.Checked, " and nominavw.reloj in ('" & lista_relojes() & "')", "") & _
  "AND folio_cfdi IS NULL and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'  and reg_pat_planta='" & _reg_pat_planta & "' " & _
  "and nominavw.reloj not in (select reloj from timbrado where ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "' and isnull(isr_sep,0)=0) " & _
  "and " & IIf(chkPtuAltas.Checked, "isnull(baja,'')=''", "isnull(baja,'')<>''")

                '              If (chkPtuAltas.Checked = True) Then  '--- Si está activado ALTAS (Solo activos)
                '                  QN = "SELECT RELOJ,NOMBRES,RFC,CURP,NUMIMSS,COD_DEPTO,NOMBRE_DEPTO,ALTA,COD_PUESTO,NOMBRE_PUESTO,COD_TURNO," & _
                '                    "NOMBRE_TURNO,SACTUAL,cuenta,INTEGRADO,HORAS_DOBLES,HORAS_TRIPLES, nominavw.cod_pago, " & _
                '                    "ISNULL((SELECT contenido FROM personal.dbo.detalle_auxiliares WHERE campo = 'EMAIL' and reloj = NominaVW.reloj),'') AS EMAIL,banco " & _
                '                    "FROM nominaVW WHERE cod_comp = '" & Parametros.Compania & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                '                    "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' " & _
                '                    IIf(rbLista.Checked, " and nominavw.reloj in ('" & lista_relojes() & "')", "") & _
                '                    "AND folio_cfdi IS NULL and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'  and reg_pat_planta='" & _reg_pat_planta & "' " & _
                '                    "and " & IIf(chkPtuAltas.Checked = True, "isnull(baja,'')=''", "isnull(baja,'')<>''")

                '              End If
                '              If (chkPtuBajas.Checked = True) Then   '----Si está activado BAJAS (Solo bajas)
                '                  QN = "SELECT RELOJ,NOMBRES,RFC,CURP,NUMIMSS,COD_DEPTO,NOMBRE_DEPTO,ALTA,COD_PUESTO,NOMBRE_PUESTO,COD_TURNO," & _
                '"NOMBRE_TURNO,SACTUAL,cuenta,INTEGRADO,HORAS_DOBLES,HORAS_TRIPLES, nominavw.cod_pago, " & _
                '"ISNULL((SELECT contenido FROM personal.dbo.detalle_auxiliares WHERE campo = 'EMAIL' and reloj = NominaVW.reloj),'') AS EMAIL,banco " & _
                '"FROM nominaVW WHERE cod_comp = '" & Parametros.Compania & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                '"' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' " & _
                'IIf(rbLista.Checked, " and nominavw.reloj in ('" & lista_relojes() & "')", "") & _
                '"AND folio_cfdi IS NULL and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'  and reg_pat_planta='" & _reg_pat_planta & "' " & _
                '"and isnull(baja,'')<>'' "
                '              End If
            End If

            If (chkPtu.Checked = False) Then
                '----Si no está el botón de PTU,  Hacer lo normal
                QN = "SELECT RELOJ,NOMBRES,RFC,CURP,NUMIMSS,COD_DEPTO,NOMBRE_DEPTO,ALTA,COD_PUESTO,NOMBRE_PUESTO,COD_TURNO," & _
                                      "NOMBRE_TURNO,SACTUAL,cuenta,INTEGRADO,HORAS_DOBLES,HORAS_TRIPLES, nominavw.cod_pago, " & _
                                      "ISNULL((SELECT contenido FROM personal.dbo.detalle_auxiliares WHERE campo = 'EMAIL' and reloj = NominaVW.reloj),'') AS EMAIL,banco " & _
                                      "FROM nominaVW WHERE cod_comp = '" & Parametros.Compania & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                                      "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' " & _
                                      IIf(rbLista.Checked, " and nominavw.reloj in ('" & lista_relojes() & "')", "") & _
                                      "AND folio_cfdi IS NULL and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'  and reg_pat_planta='" & _reg_pat_planta & "' " & _
                                      "and nominavw.reloj not in (select reloj from timbrado where ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "' and isnull(isr_sep,0)=0)"
            End If

            dtNomina = sqlExecute(QN, "nomina")

            If dtNomina.Rows.Count = 0 Then
                Err.Raise(999, Nothing, "No se encontraron registros de nómina pendientes de timbrar, que cumplan con las condiciones especificadas.")
            End If

            dtNomina.Columns.Add("COD_PAGO_SAT")

            dtNomina.Columns.Add("INCLUIR")
            pbAvance.Maximum = dtNomina.Rows.Count

            T = 0

            '---AOS - Busca todos los movimientos existentes que hay en ese año y periodo seleccionado (Solo los que sean referentes a Sueldos y Salarios [CONCEPTOS.SEP=0])
            Dim QCambiaCrepag As String = ""
            Dim QAddCrepag As String = ""

            Dim ConcePag As String = "CREPAG" ' AOS - NOTA: En algunas empresas lo manejan como CREPAG como TBC, y en otras como WME como SUBPAG

            If (rbLista.Checked) Then
                '---Solo los empleados seleccionados
                dtMovimientos = sqlExecute("SELECT movimientos.reloj, movimientos.ano, movimientos.periodo, movimientos.concepto,conceptos.nombre,ISNULL(cod_sat,'') AS cod_sat,exento,concepto_sat,ISNULL(cod_naturaleza,'I') as cod_naturaleza," & _
                               "monto,conceptos.prioridad,ISNULL(CONCEPTOS.OTP,0) AS OTP,ISNULL(CONCEPTOS.SEP,0) AS SEP FROM " & _
                               "movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                               "WHERE ano = '" & AnoPeriodo.Substring(0, 4) & _
                               "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' AND ISNULL(CONCEPTOS.SEP,0)=0 and  tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and reloj in('" & lista_relojes() & "')", "nomina")

                QCambiaCrepag = "SELECT distinct reloj from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "'  and CONCEPTO='" & ConcePag & "' and monto<> 0 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and reloj in('" & lista_relojes() & "')"

                QAddCrepag = "select distinct reloj from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and reloj not in(SELECT distinct reloj from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and CONCEPTO='" & ConcePag & "' and monto<> 0) and reloj in('" & lista_relojes() & "')"
            Else
                '---- Todos los empleados
                dtMovimientos = sqlExecute("SELECT movimientos.reloj, movimientos.ano, movimientos.periodo, movimientos.concepto,conceptos.nombre,ISNULL(cod_sat,'') AS cod_sat,exento,concepto_sat,ISNULL(cod_naturaleza,'I') as cod_naturaleza," & _
                               "monto,conceptos.prioridad,ISNULL(CONCEPTOS.OTP,0) AS OTP,ISNULL(CONCEPTOS.SEP,0) AS SEP FROM " & _
                               "movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                               "WHERE ano = '" & AnoPeriodo.Substring(0, 4) & _
                               "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' AND ISNULL(CONCEPTOS.SEP,0)=0 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'", "nomina")

                QCambiaCrepag = "SELECT distinct reloj from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "'  and CONCEPTO='" & ConcePag & "' and monto<> 0 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'"
                QAddCrepag = "select distinct reloj from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and reloj not in(SELECT distinct reloj from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'  and CONCEPTO='" & ConcePag & "' and monto<> 0)"
            End If


            ''---Busca todos los movimientos existentes que hay en ese año y periodo seleccionado (Solo los que sean referentes a Sueldos y Salarios [CONCEPTOS.SEP=0])
            'dtMovimientos = sqlExecute("SELECT movimientos.reloj, movimientos.ano, movimientos.periodo, movimientos.concepto,conceptos.nombre,ISNULL(cod_sat,'') AS cod_sat,exento,concepto_sat,ISNULL(cod_naturaleza,'I') as cod_naturaleza," & _
            '                               "monto,conceptos.prioridad,ISNULL(CONCEPTOS.OTP,0) AS OTP,ISNULL(CONCEPTOS.SEP,0) AS SEP FROM " & _
            '                               "movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
            '                               "WHERE ano = '" & AnoPeriodo.Substring(0, 4) & _
            '                               "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' AND ISNULL(CONCEPTOS.SEP,0)=0 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'", "nomina")



            '----AOS: 26/FEB/2021  -  Proceso para CREPAG (Subempleo pagado efectivamente), siemprey cuando no haya CREFIS
            '---Si ya traen CREPAG, solo es cambiarlo por OTP y hacerlo positivo en caso de que venga negativo
            Dim dtCambiarCrepag As DataTable = sqlExecute(QCambiaCrepag, "NOMINA")
            If (Not dtCambiarCrepag.Columns.Contains("Error") And dtCambiarCrepag.Rows.Count > 0) Then
                For Each rowCambia In dtCambiarCrepag.Rows
                    Dim myRow() As DataRow
                    myRow = dtMovimientos.Select("concepto = '" & ConcePag & "' and reloj = '" & rowCambia("reloj") & "'")
                    Dim monto As Double = myRow(0)("monto")
                    If (monto < 0) Then monto = monto * -1 ' Lo hacemos positivo
                    myRow(0)("cod_sat") = "002"
                    myRow(0)("concepto_sat") = "002"
                    myRow(0)("cod_naturaleza") = "P"
                    myRow(0)("monto") = monto
                    myRow(0)("prioridad") = "470"
                    myRow(0)("otp") = "1"
                Next
            End If

            '---Si no traen CREPAG o SUBPAG, hay que agregarlo
            Dim dtAddCrepag As DataTable = sqlExecute(QAddCrepag, "NOMINA")
            If (Not dtAddCrepag.Columns.Contains("Error") And dtAddCrepag.Rows.Count > 0) Then
                For Each rowAddCre In dtAddCrepag.Rows
                    dtMovimientos.Rows.Add(rowAddCre("reloj"), AnoPeriodo.Substring(0, 4), AnoPeriodo.Substring(4, 2), ConcePag, "SUBSIDIO AL EMPLEO PAGADO", "002", ConcePag, "", "P", "0.01", "470", "1", "0")
                    dtMovimientos.Rows.Add(rowAddCre("reloj"), AnoPeriodo.Substring(0, 4), AnoPeriodo.Substring(4, 2), "AJUSUB", "AJUSTE POR SUBSIDIO", "071", "AJUSUB", "", "D", "0.01", "999", "0", "0")
                Next
            End If


            '---Recorrer a cada uno de los empleados y validar (----NORMAL ---)
            For Each dReg As DataRow In dtNomina.Rows
                T += 1
                'bgTimbrado.ReportProgress(T, "Preparando" & vbCrLf & dReg("reloj"))

                pbAvance.IsRunning = True
                pbAvance.Value = T
                lblAvance.Text = "Preparando"

                Dim _rfc As String = "", _curp As String = ""
                Try : _rfc = dReg("rfc").ToString.Trim : Catch ex As Exception : _rfc = "" : End Try
                Try : _curp = dReg("curp").ToString.Trim : Catch ex As Exception : _curp = "" : End Try

                If _rfc = "" Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    MessageBox.Show("Errores en RFC...Empleado: - " & dReg("reloj").ToString & " - no tiene capturado su RFC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    ArchivoTXT.Close() ' AOS 2021-08-09
                    Exit Function
                End If

                If _curp = "" Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    MessageBox.Show("Errores en CURP...Empleado: - " & dReg("reloj").ToString & " - no tiene capturado su CURP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    ArchivoTXT.Close() ' AOS 2021-08-09
                    Exit Function
                End If

                If Not ValidaRFC(dReg("rfc")) Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    dtErrores.Rows.Add({dReg("reloj"), "RFC inválido (" & dReg("rfc").ToString.Trim & ")"})
                    MessageBox.Show("Errores en RFC...Empleado: - " & dReg("reloj") & " -", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    ArchivoTXT.Close() ' AOS 2021-08-09
                    Exit Function
                    '  Continue For
                End If

                If Not ValidaCURP(dReg("curp")) Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    dtErrores.Rows.Add({dReg("reloj"), "CURP inválido (" & dReg("rfc").ToString.Trim & ")"})
                    MessageBox.Show("Errores en CURP...Empleado: - " & dReg("reloj") & " -", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    ArchivoTXT.Close() ' AOS 2021-08-09
                    Exit Function
                    '  Continue For
                End If


                For Each dMov In dtMovimientos.Select("reloj = '" & dReg("reloj") & "'")
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
                            dMovDetalle("OTP") = dMov("OTP")

                            dtMovimientosDetalle.Rows.Add(dMovDetalle)
                        Else
                            dMovDetalle("monto") += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                        End If

                        If Not IsDBNull(dMov("exento")) Then
                            'dtExento = sqlExecute("SELECT monto FROM movimientos WHERE concepto = '" & dMov("exento").ToString.Trim & _
                            '                      "' AND reloj = '" & dReg("reloj") & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                            '                      "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'", "nomina")

                            dtExento = dtMovimientos.Clone
                            Try
                                dtExento = dtMovimientos.Select("concepto = '" & dMov("exento").ToString.Trim & _
                                                  "' AND reloj = '" & dReg("reloj") & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                                                  "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'").CopyToDataTable
                            Catch ex As Exception

                            End Try

                            If dtExento.Rows.Count = 0 Then
                                _exento = 0
                            Else
                                _exento = dtExento.Rows(0).Item("monto")
                            End If
                            dMovDetalle("exento") = _exento

                        Else '--AOS: Para que no mande en Nulo el exento
                            _exento = 0
                            dMovDetalle("exento") = _exento

                        End If
                    End If
                    '--
                Next
            Next

            For Each row As DataRow In dtNomina.Select("INCLUIR = 'SI'")
                Dim cod_pago As String = row("cod_pago")
                Select Case cod_pago
                    Case "C"
                        row("cod_pago_sat") = "02"
                    Case "D"
                        row("cod_pago_sat") = "03"
                    Case "E"
                        row("cod_pago_sat") = "99"
                    Case "L"
                        row("cod_pago_sat") = "99"
                End Select
            Next

            FNErrores = Parametros.DirDestino
            FNErrores = IIf(strFileName.Substring(FNErrores.Trim.Length - 1) <> "\", FNErrores.Trim & "\", FNErrores) & "ErroresDetectados.xlsx"

            ' If dtErrores.Rows.Count > 0 Then MessageBox.Show("Errores en CURP...")

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
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                MessageBox.Show("Hay empleados con cantidades exentas mayores a los montos, no es posible continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim advertencias As New ArrayList
                For Each dr As DataRow In dtMovimientosDetalle.Select("exento > monto AND exento <> 0")
                    Dim Rj As String = dr("Reloj").ToString.Trim
                    Dim Concepto As String = dr("concepto").ToString.Trim
                    Dim monto As Double = Double.Parse(dr("monto"))
                    Dim exento As Double = Double.Parse(dr("exento"))
                    Dim descrip As String = dr("descripcion").ToString.Trim
                    advertencias.Add("-Empleado " & Rj & " -Concepto: " & Concepto & " - Monto:" & monto & "   - Exento:" & exento)
                Next

                Dim m As String = ""
                If advertencias.Count > 0 Then
                    m &= "ADVERTENCIA" & vbCrLf
                    For Each a As String In advertencias
                        m &= a & vbCrLf
                    Next
                    MessageBox.Show(m, "Empleados no Timbrados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Exit Function
                '    Err.Raise(999, Nothing, "¡ALERTA!" & vbCrLf & "Existen cantidades exentas mayores a los montos. No es posible continuar")
            End If

            '//*** Enrique Meza Para cambiar la naturaleza de cuales queir conceptos en negativo, ya que la interface de Comercio Digital no acepta montos negativos IVO
            For Each dMov In dtMovimientosDetalle.Select("monto<0 AND naturaleza= 'D'")
                dMov("tipo_percepcion") = "038"
                dMov("naturaleza") = "P"
                dMov("concepto") = "MARCAP"
                dMov("descripcion") = "Otras Percepciones Exentas"
                dMov("monto") = -IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                dMov("gravado") = -IIf(IsDBNull(dMov("gravado")), 0, dMov("gravado"))
                dMov("exento") = IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
            Next
            For Each dMov In dtMovimientosDetalle.Select("monto<0 AND naturaleza= 'P'")
                dMov("tipo_percepcion") = "004"
                dMov("naturaleza") = "D"
                dMov("concepto") = "MARCAD"
                dMov("descripcion") = "Otras Deducciones"
                dMov("monto") = -IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                dMov("gravado") = -IIf(IsDBNull(dMov("gravado")), 0, dMov("gravado"))
                dMov("exento") = IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
            Next
            For Each dMov In dtMovimientosDetalle.Select("concepto='MARCAP'")
                dMov("concepto") = "OTPNOG"
            Next
            For Each dMov In dtMovimientosDetalle.Select("concepto='MARCAD'")
                dMov("concepto") = "OTRASD"
            Next

            i = dtMovimientosDetalle.Select("exento > monto AND exento <> 0").Count

            If i > 0 Then
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                MessageBox.Show("Hay empleados con cantidades exentas mayores a los montos, no es posible continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim advertencias As New ArrayList
                For Each dr As DataRow In dtMovimientosDetalle.Select("exento > monto AND exento <> 0")
                    Dim Rj As String = dr("Reloj").ToString.Trim
                    Dim Concepto As String = dr("concepto").ToString.Trim
                    Dim monto As Double = Double.Parse(dr("monto"))
                    Dim exento As Double = Double.Parse(dr("exento"))
                    Dim descrip As String = dr("descripcion").ToString.Trim
                    advertencias.Add("-Empleado " & Rj & " -Concepto: " & Concepto & " - Monto:" & monto & "   - Exento:" & exento)
                Next

                Dim m As String = ""
                If advertencias.Count > 0 Then
                    m &= "ADVERTENCIA" & vbCrLf
                    For Each a As String In advertencias
                        m &= a & vbCrLf
                    Next
                    MessageBox.Show(m, "Empleados no Timbrados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Exit Function
                '    Err.Raise(999, Nothing, "¡ALERTA!" & vbCrLf & "Existen cantidades exentas mayores a los montos. No es posible continuar")
            End If



            _total_crepag = 0

            dtCREPAG.Columns.Add("reloj", System.Type.GetType("System.String"))
            dtCREPAG.Columns.Add("nombres", System.Type.GetType("System.String"))
            dtCREPAG.Columns.Add("monto", System.Type.GetType("System.Double"))
            For Each dc As DataRow In dtMovimientos.Select("concepto = 'CREFIS'")

                Dim rows() As DataRow = dtMovimientosDetalle.Select("concepto = 'CREPAG' and reloj = '" & dc("reloj") & "'")
                If Not rows.Count > 0 Then
                    dtMovimientosDetalle.Rows.Add({dc("reloj"),
                                            "O",
                                            "002",
                                            "CREPAG",
                                            "SUBSIDIO AL EMPLEO PAGADO",
                                            0.01,
                                            0,
                                            0.01,
                                             1160})
                    _total_crepag = _total_crepag + 0.01

                    Dim tempo As DataTable = sqlExecute("select * from personalvw where reloj = '" & dc("reloj") & "'")
                    dtCREPAG.Rows.Add({dc("reloj"),
                                       IIf(IsDBNull(tempo.Rows(0).Item("nombres")), "N/A", tempo.Rows(0).Item("nombres")),
                                       0.01
                                      })

                End If

            Next






            'TOTAL OTROS PAGOS
            For Each dMov In dtMovimientosDetalle.Rows
                Dim _mnto As Double = 0.0
                Dim Exen As Double = 0.0
                Try : _mnto = Double.Parse(dMov("monto")) : Catch ex As Exception : _mnto = 0.0 : End Try
                Try : Exen = Double.Parse(dMov("exento")) : Catch ex As Exception : Exen = 0.0 : End Try

                ' dMov("gravado") = dMov("monto") - IIf(IsDBNull(dMov("exento")), 0, dMov("exento"))
                dMov("gravado") = Math.Round(_mnto - Exen, 2)

                'SI EL CODIGO DE SAT ES acumular como otros pagos

                ' If RTrim(dMov("concepto")) = "COMVIA" Then  ' Conceptos para OTROS PAGOS (OTP = COD_SAT = 999), van aqui fijos
                If RTrim(dMov("OTP")) = "1" Then
                    _total_otros_pagos += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))

                ElseIf dMov("naturaleza").ToString.Trim = "P" Then
                    _total_percepciones += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))

                ElseIf dMov("naturaleza").ToString.Trim = "D" Then
                    Dim monto As Double = IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                    If monto >= 0 Then
                        _total_deducciones += monto
                    ElseIf monto < 0 Then
                        _total_otros_pagos += (monto * -1)
                    End If

                End If
            Next

            _total_empleados = dtNomina.Select("incluir = 'SI'").Count

            If (_total_otros_pagos > 0 And (_total_percepciones = 0 And _total_deducciones = 0)) Then  ' Solo viene el concepto de OTP (Otros pagos)
                GoTo SaltarPer_2
            End If


            If _total_percepciones <= 0 Or _total_deducciones < 0 Then
                percep_dedInCero = True
                GoTo noIncluir
                ' Err.Raise(999, Nothing, "Falta información. Favor de revisar")
            End If

SaltarPer_2:

            sqlExecute("UPDATE bitacora_timbrados SET tot_per = " & _total_percepciones & "," & _
                       "tot_ded = " & _total_deducciones & "," & _
                       "tot_neto = " & _total_percepciones - _total_deducciones & " WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")

            Dim cod_pago_sat As String = "03"

            '--AOS - 03/12/2019: Validar fecha de pago si la va a tomar del campo correspondiente o de TA.dbo.Periodos
            If (chkFecPago.Checked) Then
                Dim FPag As String = ""
                Try : FPag = FechaSQL(txtFecPago.Value) : Catch ex As Exception : FPag = "" : End Try
                If (FPag <> "" And FPag <> "0001-01-01") Then
                    _fechapago = txtFecPago.Value
                End If
            End If
            '--Ends

            '	*** ENCABEZADO DE ARCHIVO CON DATOS DEL PATRON, donde va la fecha de pago
            '-----AOS: 2021-11-12 Saber si va a ser una nom Ordinaria o Extraordinaria
            Dim tNom As String = "O", periodicidad As String = "", tablas_periodos As String = ""
            Dim dias_pag_default As String = "14" ' TBC Dias pagados por default  dependiendo de los dias del periodo AOS 18/08/2021
            Dim concepDiasPag As String = "DIASPA" ' &&_ Concepto que viene desde movs  que trae los diasPag OJO: No debe de mandarse en decimales, siempre en Enteros
            Dim montoDiasPag As String = "14"


            '---Define el tipo de periodicidad, los dias default a pagar, y en que tabla buscar para saber si es periodoi extraordinario
            Select Case cmbTipoPeriodo.SelectedValue.ToString.Trim
                Case "S"
                    periodicidad = "02"
                    dias_pag_default = "7"
                    montoDiasPag = "7"
                    tabla_periodos = "ta.dbo.periodos"
                Case "C"
                    periodicidad = "03"
                    dias_pag_default = "14"
                    montoDiasPag = "14"
                    tabla_periodos = "ta.dbo.periodos_catorcenal"
                Case "Q"
                    periodicidad = "04"
                    dias_pag_default = "15"
                    montoDiasPag = "15"
                    tabla_periodos = "ta.dbo.periodos_quincenal"
                Case "M"
                    periodicidad = "05"
                    dias_pag_default = "30"
                    montoDiasPag = "30"
                    tabla_periodos = "ta.dbo.periodos_mensual"
                Case Else
                    periodicidad = "99"
                    dias_pag_default = "7"
                    montoDiasPag = "7"
                    tabla_periodos = "ta.dbo.periodos"
            End Select

            Dim dtPerEspecial As DataTable = sqlExecute("select * from " & tabla_periodos & " where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "'")
            Dim periodo_especial As Integer = 0
            If (Not dtPerEspecial.Columns.Contains("Error") And dtPerEspecial.Rows.Count > 0) Then Try : periodo_especial = dtPerEspecial.Rows(0).Item("periodo_especial") : Catch ex As Exception : periodo_especial = 0 : End Try

            If (periodo_especial = 1) Then
                tNom = "E"
                periodicidad = "99"
            End If

            _texto = "EMP|" & _rfc_cia & "|" & _nombre_cia & "|" & _regimen_cia & "|||" & tNom & "|" & vbCrLf '** Esto se quita en la version 3.3 & _sncf & "||" & vbCrLf
            _texto = _texto & "KEY|" & ParametrosCFDI.DireccionKey.Trim.Replace("\", "/") & "|" & vbCrLf
            _texto = _texto & "CER|" & ParametrosCFDI.DireccionCer.Trim.Replace("\", "/") & "|" & vbCrLf
            _texto = _texto & "PVE|" & ParametrosCFDI.PasswordKey.Trim & "|" & vbCrLf
            _texto = _texto & "WS0|" & ParametrosCFDI.UsuarioWeb.Trim & "|" & ParametrosCFDI.PasswordWeb.Trim & "|" & vbCrLf
            _texto = _texto & "NOM|" & _registro_patronal & "|" & FechaSQL(_fechapago) & "|" & FechaSQL(_fechainicialpago) & "|" & FechaSQL(_fechafinalpago) & "|" & vbCrLf
            _texto = _texto & "CFD|" & _serie & "|" & _folio & "|" & _cp_cia & "|" & _fecha_expedicion & "|" & vbCrLf
            _texto = _texto & "TOT|" & String.Format("{0:0.00}", _total_percepciones) & "|" & String.Format("{0:0.00}", _total_deducciones) & "|" & _total_empleados.ToString.Trim & "|" & String.Format("{0:0.00}", _total_otros_pagos) & "|" & vbCrLf
            _texto = _texto & "INI|"

            ArchivoTXT.WriteLine(_texto)

            Dim _perc_totalgravado As Double
            Dim _perc_totalexento As Double
            Dim _ded_totalgravado As Double
            Dim _ded_totalexento As Double

            Dim _otros_pagos_empleado As Double

            Dim _textoMov As String = ""

            pbAvance.Maximum = dtNomina.Select("incluir = 'SI'").Count
            T = 0
            For Each dMov In dtNomina.Select("incluir = 'SI'")
                Try


                    T += 1
                    'bgTimbrado.ReportProgress(T, "Exportando" & vbCrLf & dMov("reloj"))

                    pbAvance.IsRunning = True
                    pbAvance.Value = T
                    lblAvance.Text = "Exportando"

                    Dim Rj As String = dMov("reloj").ToString.Trim
                    Dim _sactual As Double = 0.0, _integrado As Double = 0.0

                    Try : _sactual = Double.Parse(dMov("sactual")) : Catch ex As Exception : _sactual = 0.0 : End Try
                    Try : _integrado = Double.Parse(dMov("integrado")) : Catch ex As Exception : _integrado = 0.0 : End Try

                    _texto = "E01|" & dMov("reloj").ToString.Trim & "|"
                    _texto = _texto & dMov("nombres").ToString.Trim.Replace(",", " ") & "|"
                    _texto = _texto & dMov("rfc").ToString.Trim.Replace("-", "").PadRight(13, "X") & "|"
                    _texto = _texto & dMov("curp").ToString.Trim & "|"
                    _texto = _texto & "02|" ' Tipo regimen empleado
                    _texto = _texto & dMov("numimss").ToString.Trim & "|"



                    'Dias pagados desde movimientos (NORMAL) [numDiasPagados]
                    Try
                        'NOTA: Los días pagados (numDiasPagados) deben de ir enteros, pero si traen decimal, a tres dig, ejemplo: 7.8 --> 7.800
                        '    Dim dtDiasPagados As DataTable = sqlExecute("select * from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "' and reloj='" & dMov("reloj").ToString.Trim & "' and cod_comp='" & Parametros.Compania & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and concepto='" & concepDiasPag & "'", "NOMINA") ' BUSCA POR COD_COMP
                        Dim dtDiasPagados As DataTable = sqlExecute("select * from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "' and reloj='" & dMov("reloj").ToString.Trim & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and concepto='" & concepDiasPag & "'", "NOMINA")
                        If (Not dtDiasPagados.Columns.Contains("Error") And dtDiasPagados.Rows.Count > 0) Then
                            Try : montoDiasPag = dtDiasPagados.Rows(0).Item("MONTO").ToString.Trim : Catch ex As Exception : montoDiasPag = dias_pag_default : End Try
                        Else
                            montoDiasPag = dias_pag_default
                        End If

                        '---Validar que los dias pagados sean mayor a cero 2022-11-29
                        Dim numdiaspagados As Double = 0.0
                        Try : numdiaspagados = Double.Parse(montoDiasPag) : Catch ex As Exception : numdiaspagados = 1 : End Try
                        If numdiaspagados <= 1 Then montoDiasPag = "1"

                        '---Si trae decimales, dejarlo  a 7.800 por ejemplo, siempre a 3 digitos
                        If (montoDiasPag.Contains(".")) Then
                            Dim cade1 As String = "", cade2 As String = ""
                            cade1 = montoDiasPag.Split(".")(0)
                            cade2 = montoDiasPag.Split(".")(1).PadRight(3, "0")
                            cade2 = cade2.Substring(0, 3) ' Siempre a 3 dígitos
                            montoDiasPag = cade1 & "." & cade2
                        End If

                        _texto = _texto & montoDiasPag & "|"  '&& Días pagados desde movimientos

                    Catch ex As Exception
                        _texto = _texto & montoDiasPag & "|"  '&& Default
                    End Try
                    '---- ENDS (NORMAL) [numDiasPagados]


                    _texto = _texto & EliminaAcentos(dMov("nombre_depto").ToString.ToUpper.Trim) & "|"

                    '--- Obtener el codigo del banco de acuerdo al banco que debe de trae el empleado
                    Dim nombreBanco As String = ""
                    Try : nombreBanco = dMov("BANCO").ToString.Trim.ToUpper : Catch ex As Exception : nombreBanco = "" : End Try

                    Select Case nombreBanco
                        Case "BANCOMER"
                            _banco = "012"
                        Case "HSBC"
                            _banco = "021"
                        Case "SANTANDER"
                            _banco = "014"
                        Case "BBVA BANCOMER"
                            _banco = "012"
                        Case Else
                            _banco = ParametrosCFDI.Banco
                    End Select


                    If dMov("cod_pago_sat") = "03" Then
                        _texto = _texto & dMov("cuenta").ToString.Trim.PadLeft(11, "0") & "|" ' cuenta bancaria
                        _texto = _texto & (_banco) & "|"  '&& CLABE PENDIENTE
                    Else
                        _texto = _texto & "|" ' cuenta bancaria
                        _texto = _texto & "|"  '&& CLABE PENDIENTE
                    End If

                    Dim antigEmpl As String = ""
                    Try : antigEmpl = Math.Truncate((DateDiff(DateInterval.Day, dMov("alta"), _fecha_fin) + 1) / 7).ToString.Trim : Catch ex As Exception : antigEmpl = "1" : End Try

                    '   If (antigEmpl = "0" Or antigEmpl = "") Then antigEmpl = "1"

                    _texto = _texto & FechaSQL(dMov("alta")) & "|"
                    _texto = _texto & antigEmpl & "|" ' Antiguedad del empleado
                    _texto = _texto & dMov("nombre_puesto").ToString.ToUpper.Trim & "|"
                    _texto = _texto & "01|"   ' tipo contrato PENDIENTE
                    _texto = _texto & IIf(dMov("cod_turno") = "2" Or dMov("cod_turno") = "9", "03", IIf(dMov("cod_turno") = "3", "02", "01")) & "|" ' tipo jornada
                    _texto = _texto & periodicidad & "|" ' periodicidad 
                    _texto = _texto & String.Format("{0:0.00}", dMov("sactual")) & "|"
                    _texto = _texto & _riesgo_pto & "|"
                    _texto = _texto & String.Format("{0:0.00}", dMov("integrado")) & "|"
                    _texto = _texto & "No|" ' sindicalizado
                    _texto = _texto & entidad & "|" ' entidad
                    If (dMov("email").ToString.Length > 0 And Not Pruebas) And sbEmail.Value = True Then
                        _texto = _texto & dMov("email").ToString.Trim & "|"
                    Else
                        _texto = _texto & "|"
                    End If

                    _perc_totalgravado = 0
                    _perc_totalexento = 0
                    _ded_totalgravado = 0
                    _ded_totalexento = 0

                    _otros_pagos_empleado = 0



                    '** PERCEPCIONES
                    _textoMov = ""

                    'Manejar indemnizaciones
                    'ABRAHAM CASAS DICIEMBRE 2018, SE INCLUYE EL REGISTRO PARA LOS CUATRO CONCEPTOS (INDEMN, PRIANT, NOREST, ISRSEP)
                    Try
                        Dim dtINDEMN As DataTable = dtMovimientosDetalle.Select("concepto in ('INDEMN', 'PRIANT', 'NOREST')  AND reloj = '" & dMov("reloj").ToString.Trim & "'").CopyToDataTable
                        If dtINDEMN.Rows.Count > 0 Then
                            Dim dtDatosPersonal As DataTable = sqlExecute("select reloj, sactual, alta, baja from personal where reloj = '" & dMov("reloj") & "' and baja is not null")
                            If dtDatosPersonal.Rows.Count > 0 Then
                                Dim sactual As Double = dtDatosPersonal.Rows(0)("sactual")
                                Dim alta As Date = dtDatosPersonal.Rows(0)("alta")
                                Dim baja As Date = dtDatosPersonal.Rows(0)("baja")
                                Dim antig As Integer = DateDiff(DateInterval.Year, alta, baja) + 1

                                Dim ddetalle As Double = 0

                                For Each row As DataRow In dtINDEMN.Rows
                                    ddetalle += row("monto")
                                Next

                                _textoMov = _textoMov & "S01|" & String.Format("{0:0.00}", ddetalle) ' Total pagado
                                _textoMov = _textoMov & "|" & antig ' anios servicio
                                _textoMov = _textoMov & "|" & String.Format("{0:0.00}", sactual * 30.4) ' ultimo sueldo mensual
                                _textoMov = _textoMov & "|" & String.Format("{0:0.00}", 0) ' ingreso acumulable
                                _textoMov = _textoMov & "|" & String.Format("{0:0.00}", 0) ' ingreso no acumulable
                                _textoMov = _textoMov & "|" & vbCrLf
                            End If
                        End If

                    Catch ex As Exception

                    End Try

                    'HABRA UNA EXCEPCION SI EL EMPLEADO NO TIENE OTPs
                    Try ' Conceptos para OTP otros pagos (OTP = COD_SAT = 999), van fijos aquí, En la tabla CONCEPTOS ya debe de venir el campo de OTP = 1 refiriendo que es como Otros Pagos
                        '   Dim dtOTP As DataTable = dtMovimientosDetalle.Select("concepto in ('COMVIA') AND reloj = '" & dMov("reloj").ToString.Trim & "'", "PRIORIDAD,TIPO_PERCEPCION").CopyToDataTable
                        Dim dtOTP As DataTable = dtMovimientosDetalle.Select("OTP = 1  AND reloj = '" & dMov("reloj").ToString.Trim & "'", "PRIORIDAD,TIPO_PERCEPCION").CopyToDataTable

                        Dim concPag As String = "CREPAG" ' AOS - Nota: En algunas empresas se maneja como CREPAG como en TBC, y en WME se maneja el SUBPAG
                        Dim concSubCau As String = "CREFIS" ' AOS -  Nota: En otros estác omo SUBEMP y es el Subsidio Causado que se generó y debe de ir en la línea del Subempleo pagado
                        For Each dDetalle As DataRow In dtOTP.Rows

                            _textoMov = _textoMov & "OTP|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                            _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                            _textoMov = _textoMov & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                            _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto")) & "|"

                            Dim _subsidio_causado As Double = 0
                            Dim _concepto_otp As String = RTrim(dDetalle("concepto").ToString.Trim)

                            '--- Interface NORMAL  AOS: En este caso el subsidio causado va en el concepto SUBEMP, por eso se coloca ahí, y si va como negativo, lo hacemos Positivo

                            Select Case _concepto_otp
                                Case concPag
                                    ' For Each row As DataRow In dtMovimientos.Select("concepto in ('CREFIS') AND reloj = '" & dMov("reloj").ToString.Trim & "'")
                                    For Each row As DataRow In dtMovimientos.Select("concepto in ('" & concSubCau & "') AND reloj = '" & dMov("reloj").ToString.Trim & "'")
                                        Try
                                            _subsidio_causado += Double.Parse(row("monto"))
                                        Catch ex As Exception

                                        End Try
                                    Next
                                    '12/02/2020: AOS - Agregar CREPAG de 0.01 para timbrado
                                    If _subsidio_causado = 0 Then
                                        _subsidio_causado = 0.01
                                    End If
                                    '--ENDS
                                    If (_subsidio_causado < 0) Then _subsidio_causado = _subsidio_causado * -1

                                    _textoMov = _textoMov & String.Format("{0:0.00}", _subsidio_causado) & "|||"
                            End Select

                            _textoMov = _textoMov & "|" & vbCrLf

                            _otros_pagos_empleado += dDetalle("monto")

                        Next
                    Catch ex As Exception

                    End Try

                    '** DEDUCCIONES NEGATIVAS
                    For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'D' AND reloj = '" & dMov("reloj").ToString.Trim & "' and isnull(exento,0) < 0", "PRIORIDAD,TIPO_PERCEPCION")

                        Dim _concepto As String = dDetalle("concepto").ToString.Trim

                        _textoMov = _textoMov & "OTP|" & IIf(_concepto = "ISRCOM", "004", "999") & "|" & _concepto & "|" & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                        _textoMov = _textoMov & String.Format("{0:0.00}", Double.Parse(dDetalle("exento")) * -1) & "|"

                        If _concepto = "ISRCOM" Then
                            _textoMov = _textoMov & "|" & String.Format("{0:0.00}", Double.Parse(dDetalle("exento")) * -1) & "|" & Now.Year - 1 & "|0.00"
                        Else
                            _textoMov = _textoMov & "|||"
                        End If

                        _textoMov = _textoMov & "|" & vbCrLf

                        _otros_pagos_empleado += Double.Parse(dDetalle("exento")) * -1

                    Next

                    '--Excluir los conceptos que son Otros Pagos (OTP) (Otros pagos con cod_sat = 999 ya que esos no entran al total de percepciones)
                    '  For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'P' AND reloj = '" & dMov("reloj").ToString.Trim & "' and concepto not in ('COMVIA')", "PRIORIDAD,TIPO_PERCEPCION")
                    For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'P' AND reloj = '" & dMov("reloj").ToString.Trim & "' and OTP=0 and monto>0", "PRIORIDAD,TIPO_PERCEPCION")

                        '-----AOS- 28/01/2020 - Hacer separación de lo gravado y exento del Fondo de Ahorro (APOCIA) : 11/02/2020: Ya no es necesario ya que su exento viene todo en "PEXFAH", tiene el mismo tratamiento que los demas conceptos

                        Dim Concep As String = "", gravado As String = "", exento As String = ""

                        Try : Concep = dDetalle("concepto").ToString.Trim : Catch ex As Exception : Concep = "" : End Try
                        Try : gravado = dDetalle("gravado").ToString.Trim : Catch ex As Exception : gravado = "0" : End Try
                        Try : exento = dDetalle("exento").ToString.Trim : Catch ex As Exception : exento = "0" : End Try
                        If gravado = "" Then gravado = "0"
                        If exento = "" Then exento = "0"

                        '--AOS: 11/02/2020 Ya el monto exento viene en el concepto de PEXFAH y ya no es necesario hacer la inversa para este concepto de aportación de Fah Cia
                        'If (Concep = "APOCIA") Then
                        '    gravado = dDetalle("exento")
                        '    exento = dDetalle("gravado")
                        'End If


                        _textoMov = _textoMov & "P01|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                        _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                        _textoMov = _textoMov & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                        '_textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("gravado")) & "|"
                        '_textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("exento")) & "|"

                        _textoMov = _textoMov & String.Format("{0:0.00}", gravado) & "|"
                        _textoMov = _textoMov & String.Format("{0:0.00}", exento) & "|"

                        'El detalle de la percepción extra se incluye dentro de la misma línea

                        If dDetalle("tipo_percepcion").ToString.Trim = "019" Then
                            _textoMov = _textoMov & "1|" ' && DIAS EN QUE SE PAGA TIEMPO EXTRA
                            If dDetalle("concepto").ToString.Trim = "PEREX2" Then
                                _textoMov = _textoMov & "01|"
                                Dim horas As Integer = Math.Truncate(dMov("horas_dobles"))
                                If horas > 0 Then
                                    _textoMov = _textoMov & horas & "|"
                                Else
                                    _textoMov = _textoMov & "1|"
                                End If

                            ElseIf dDetalle("concepto").ToString.Trim = "PEREX3" Then
                                _textoMov = _textoMov & "02|"
                                Dim horas As Integer = Math.Truncate(dMov("horas_triples"))
                                If horas > 0 Then
                                    _textoMov = _textoMov & horas & "|"
                                Else
                                    _textoMov = _textoMov & "1|"
                                End If
                            End If
                            _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto"))
                        Else
                            _textoMov = _textoMov & "|||"
                        End If

                        _textoMov = _textoMov & "|" & vbCrLf

                        _perc_totalgravado += IIf(IsDBNull(dDetalle("gravado")), 0, dDetalle("gravado"))
                        _perc_totalexento += IIf(IsDBNull(dDetalle("exento")), 0, dDetalle("exento"))

                    Next

                    '** DEDUCCIONES  AOS - Se cambio para que el monto lo tome de monto y no de la columna exento, ya que exento no aplica para deducciones
                    '   For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'D' AND reloj = '" & dMov("reloj").ToString.Trim & "' and isnull(exento,0) >= 0 ", "PRIORIDAD,TIPO_PERCEPCION")
                    For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'D' AND reloj = '" & dMov("reloj").ToString.Trim & "' and isnull(exento,0) > 0 ", "PRIORIDAD,TIPO_PERCEPCION")

                        _textoMov = _textoMov & "D01|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                        _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                        _textoMov = _textoMov & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                        '_textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("gravado")) & "|"

                        '--12/02/2020 AOS: Agregar CREPAG de 0.01 para timbrado
                        If dDetalle("concepto").ToString.Trim = "AJUSUB" Then
                            '   dDetalle("exento") = "0.01"
                            dDetalle("monto") = "0.01"
                        End If

                        '    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("exento")) & "|" & vbCrLf
                        _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto")) & "|" & vbCrLf

                        '   _ded_totalexento += IIf(IsDBNull(dDetalle("exento")), 0, dDetalle("exento"))
                        _ded_totalexento += IIf(IsDBNull(dDetalle("monto")), 0, dDetalle("monto"))
                    Next

                    '** AOS: Add datos de Incapacidades (I01) 
                    For Each dDetalle As DataRow In dtMovimientosDetalle.Select("tipo_percepcion in('014') and naturaleza in ('P')  AND reloj = '" & dMov("reloj").ToString.Trim & "'", "PRIORIDAD,TIPO_PERCEPCION")
                        Dim diasIncap As String = "3", tipo_incap As String = "", monto_incap As String = "", monto_inc_dbl As Double = 0.0, sueldo As Double = 0.0, sd As Double = 0.0, integrado As Double = 0.0
                        Dim descrip As String = ""
                        Try : descrip = dDetalle("descripcion").ToString.Trim : Catch ex As Exception : descrip = "" : End Try

                        Try : monto_inc_dbl = Double.Parse(dDetalle("monto")) : Catch ex As Exception : monto_inc_dbl = 0.0 : End Try

                        If (_sactual <> 0.0) Then sueldo = _sactual
                        If (_integrado <> 0.0 And _sactual = 0.0) Then sueldo = _integrado
                        '-- Dias de incap
                        Try : diasIncap = Convert.ToString(CInt(monto_inc_dbl / sueldo)) : Catch ex As Exception : diasIncap = "0" : End Try
                        '-- Monto de la incap
                        Try : monto_incap = String.Format("{0:0.00}", dDetalle("monto")) : Catch ex As Exception : monto_incap = "0.00" : End Try

                        '-- Tipo de incapacidad
                        If (descrip.ToString.ToUpper.Contains("RIESGO")) Then tipo_incap = "01" ' Riesgo de trabajo
                        If (descrip.ToString.ToUpper.Contains("MATERNI")) Then tipo_incap = "03" ' Incap por Maternidad
                        If (tipo_incap = "") Then tipo_incap = "02" 'Enf. Gral


                        _textoMov = _textoMov & "I01|" & diasIncap & "|"
                        _textoMov = _textoMov & tipo_incap & "|"
                        _textoMov = _textoMov & monto_incap & "|" & vbCrLf
                    Next


                    _textoMov = _textoMov & "F01|" & vbCrLf

                    _texto = _texto & String.Format("{0:0.00}", _perc_totalexento + _perc_totalgravado) & "|"
                    _texto = _texto & String.Format("{0:0.00}", _ded_totalexento + _ded_totalgravado) & "|"
                    _texto = _texto & String.Format("{0:0.00}", _otros_pagos_empleado) & "|"

                    '--AOS: 04/02/2020: Validar si es retimbrado, para que coloque el UUID CANCELADO
                    Dim uuid_canc As String = ""
                    Dim KeyEmp As String = AnoPeriodo.ToString.Trim & Rj
                    Dim dtRetimb As DataTable = sqlExecute("SELECT UUID from retimbrado where isnull(sep,0)=0 and ano+periodo+reloj='" & KeyEmp & "'", "NOMINA")
                    If (Not dtRetimb.Columns.Contains("Error") And dtRetimb.Rows.Count > 0) Then
                        Try : uuid_canc = dtRetimb.Rows(0).Item("UUID").ToString.Trim : Catch ex As Exception : uuid_canc = "" : End Try
                        _texto = _texto & uuid_canc & "|"
                    Else
                        _texto = _texto & "|"
                    End If

                    _texto = _texto & vbCrLf


                    ArchivoTXT.Write(_texto)
                    ArchivoTXT.Write(_textoMov)

                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "timbrado", Err.Number, ex.Message)
                End Try
            Next

            ArchivoTXT.WriteLine("FIN|")
            ArchivoTXT.Close()

noIncluir:
            ArchivoTXT.Close()

            sqlExecute("UPDATE bitacora_timbrados SET archivo = 1," & _
                       "nombrearch  = '" & strFileName & "' WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")
        Catch ex As Exception
            ArchivoTXT.Close()
            Return ex
        End Try


        Dim _random As Single = 0

        If percep_dedInCero Then
            sitimbrar = False
            GoTo noTimbrar
        End If

        '   If MessageBox.Show("¿Desea realizar el timbrado de los recibos?", "PIDA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then  ' AOS: Se desactiva pregunta que si se desea timbrar

        sitimbrar = True
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

        Dim valor_capturado As Double = 0
        Dim captura As New frmCapturaNeto

        Dim rand As Integer = New Random().Next(0, 2)

        Dim valor_esperado As Double = 0
        Select Case rand
            Case 0
                valor_esperado = _total_percepciones
                captura.texto = "total de percepciones"
            Case 1
                valor_esperado = _total_deducciones
                captura.texto = "total de deducciones"
            Case 2
                valor_esperado = _total_deducciones + _total_otros_pagos - _total_deducciones
                captura.texto = "neto a timbrar"
        End Select



        '------AOS: Se desactiva que no pida captura de montos
        'If captura.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    valor_capturado = Double.Parse(captura.TextBox1.Text)
        'Else
        '    MessageBox.Show("Es necesario realizar la captura de validación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return Nothing
        'End If

        'If valor_capturado <> valor_esperado Then
        '    MessageBox.Show("Los valores no coinciden [Esperado:  " & valor_esperado & ", Capturado: " & valor_capturado & "], favor de confirmar la información que está timbrando", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return Nothing
        'End If

        ' Eliminamos el archivo con extension Folios para que lo vuelva a crear
        Try
            Kill(_pathNom33 & "\" & _serie & ".txt.folios")
        Catch ex As Exception
        End Try

        '---- Aquí es donde ejecuta el programa CD NOM 33 para hacer el timbrado como tal
        ss = Shell("cd_nomina33 " & _serie & ".txt " & IIf(Pruebas, "pruebas2 ", "ws ") & Chr(34) & ParametrosCFDI.DirDestino.Trim & Chr(34), AppWinStyle.Hide, True) ' a partir del 2024 sera pruebas2 para timbrado de prueba
        Directory.SetCurrentDirectory(dirActual)

        '---AOS: Si no se timbró, agregar detalle de Reg Patronales no timbrados
        If Dir(dirCFDI & _serie & ".txt.folios") = "" Then
            timbrado = False
            GenResumenRegPat = True
            _drRP = _dtResRegPat.Rows.Find({_reg_pat_planta})
            If (_drRP Is Nothing) Then  ' Si no encuentra el registro patronal en la lista, hay que agregarlo
                _drRP = _dtResRegPat.NewRow
                _drRP("reg_pat_planta") = _reg_pat_planta
                _dtResRegPat.Rows.Add(_drRP)
            End If

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

                '--- Timbrado normal si es de prueba no debe de actualizar la tabla de nomina
                If Not btnPrueba.Value Then ' &&_AOS: Se quita solo de prueba para que se registren
                    sqlExecute("UPDATE nomina SET folio_cfdi = '" & Datos(2) & "'," & _
                          "fecha_cfdi = '" & Datos(3) & "'," & _
                          "certificado_cfdi = '" & Datos(4) & "'," & _
                          "ubicacion_archivo_cfdi = '" & UbicacionArchivo & "' " & _
                          "WHERE reloj = '" & Datos(1) & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                         "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "'", "nomina")
                End If

            Loop
            CompruebaTXT.Close()

            '-----ADRIAN ORTEGA (AOS)
            If rbLista.Checked Then
                dtNoTimbrados = sqlExecute("select ano + '-' + PERIODO as 'Periodo',* from nomina where cod_comp='" & cmbCia.SelectedValue & "' and reloj in('" & lista_relojes() & "') and ano+periodo='" & AnoPeriodo.Trim & "' and (isnull(folio_cfdi,'')='' or isnull(CERTIFICADO_CFDI,null)='')", "NOMINA")
            Else
                '--Todos los empleados
                dtNoTimbrados = sqlExecute("select ano + '-' + PERIODO as 'Periodo',* from nomina where cod_comp='" & cmbCia.SelectedValue & "' and ano+periodo='" & AnoPeriodo.Trim & "' and (isnull(folio_cfdi,'')='' or isnull(CERTIFICADO_CFDI,null)='')", "NOMINA")
            End If


        End If
        bgTimbrado.ReportProgress(-2)

        '   End If

        '---AOS - Si se mandó a timbrar
        If (timbrado) Then
            Guarda_Act_xmls()  '-----AOS --- -Leer cada uno de los archivos XML's, colocarlos en el path correcto y actualizar tabla de NOMINA.dbo.timbrado
        End If

        Return Nothing
        '    Catch ex As Exception

        CompruebaTXT.Close()

noTimbrar:

        If (sitimbrar) Then

            If Dir(strFileName).Length > 0 Then
                If MessageBox.Show("Ocurrió un error de comprobación, ¿Desea eliminar el archivo generado hasta el momento?", "Error de comprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    Kill(strFileName)
                End If
            End If

        End If

        '  Return New Exception("Error en comprobación." & vbCrLf & vbCrLf & ex.Message)

        Return New Exception("Error en comprobación")

        '  End Try

    End Function

    Private Sub Guarda_Act_xmls()

        Dim xmlSource As String = "", path_xml As String = "", ano As String = "", tipo_per As String = "", num_per As String = ""
        Dim cod_comp As String = ""

        xmlSource = txtDirectorioArchivos.Text.Trim
        Dim dtPathTimb As DataTable = sqlExecute("select path_xml from parametros", "PERSONAL")
        If (Not dtPathTimb.Columns.Contains("Error") And dtPathTimb.Rows.Count > 0) Then
            Try : path_xml = dtPathTimb.Rows(0).Item("path_xml").ToString.Trim : Catch ex As Exception : path_xml = "" : End Try
        End If

        ano = cmbAnoPeriodo.SelectedValue.ToString.Substring(0, 4).Trim
        tipo_per = cmbTipoPeriodo.SelectedValue.ToString.Trim
        num_per = cmbAnoPeriodo.SelectedValue.ToString.Substring(4, 2).Trim


        '---Validar si existe carpeta de anio\tipoPer\num_per para guardar los archivos
        Dim PathFull As String = path_xml & ano & "\" & tipo_per & "\" & num_per & "\"
        If Not Directory.Exists(PathFull) Then MkDir(PathFull)

        xmlDestination = path_xml & ano & "\" & tipo_per & "\" & num_per & "\" ' Ejemplo:  "\\pida-fs01\TBC\timbrado\xmls\2021\Q\03\"

        Try
            Try
                '---- Guardar archivos .pdf
                For Each archivos As String In My.Computer.FileSystem.GetFiles(xmlSource, FileIO.SearchOption.SearchTopLevelOnly, "*.pdf")
                    Dim fileName As String = ""
                    fileName = archivos.Trim.Split("\").Last()
                    FileCopy(xmlSource & "\" & fileName, xmlDestination & fileName)
                    My.Computer.FileSystem.DeleteFile(xmlSource & "\" & fileName) ' Elimina archivo de la ruta donde estaba temporal una vez guardado
                Next

            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            End Try

            '---- Guardar archivos .sat
            For Each archivos As String In My.Computer.FileSystem.GetFiles(xmlSource, FileIO.SearchOption.SearchTopLevelOnly, "*.sat")
                Dim fileName As String = ""
                fileName = archivos.Trim.Split("\").Last()
                Dim filePdfSat As String = xmlDestination & fileName.Replace(".sat", ".pdf")  ' Validar que el .pdf se haya generado para guardar realmente el xml
                If System.IO.File.Exists(filePdfSat) = True Then FileCopy(xmlSource & "\" & fileName, xmlDestination & fileName)

                My.Computer.FileSystem.DeleteFile(xmlSource & "\" & fileName) ' Elimina archivo de la ruta donde estaba temporal una vez guardado
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try


        Try

            For Each archivos As String In My.Computer.FileSystem.GetFiles(xmlSource, FileIO.SearchOption.SearchTopLevelOnly, "*.xml")
                Dim xmlName As String = ""
                xmlName = archivos.Trim.Split("\").Last()

                Dim filePdfSat As String = xmlDestination & xmlName.Replace(".xml", ".pdf")  ' Validar que el .pdf se haya generado para guardar realmente el xml
                If System.IO.File.Exists(filePdfSat) = True Then
                    FileCopy(xmlSource & "\" & xmlName, xmlDestination & xmlName)

                    '---Guardar el archivo para que lea el xml y actualize la tabla de timbrado
                    Dim archivo As New FilesTimbrado
                    archivo.FileName = xmlDestination & xmlName
                    If Path.GetExtension(archivo.FileName).Equals(".xml") Then
                        archivosTimbrado.Add(archivo)
                    End If
                End If
                My.Computer.FileSystem.DeleteFile(xmlSource & "\" & xmlName) ' Elimina xml una vez de la ruta temporal donde lo guardo
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

        '----LEER CADA UNO DE LOS XML'S y actualizar tabla de NOMINA.DBO.timbrado
        cod_comp = cmbCia.SelectedValue
        'lblCargaXml.Visible = True
        'lblCargaXml.Text = "Cargando XML"

        lblAvance.Text = "Cargando XML"
        Application.DoEvents()
        Dim contador As Integer = 0

        Try
            For Each archivo As FilesTimbrado In archivosTimbrado

                contador += 1
                'CircularProgress4.Value = Math.Round((100 / archivosTimbrado.Count()) * contador)
                lblAvance.Text = "Cargando XML " & Math.Round((100 / archivosTimbrado.Count()) * contador) & "%"
                Application.DoEvents()

                Dim output As StringBuilder = New StringBuilder()
                Dim doc As XDocument
                Try : doc = XDocument.Load(archivo.FileName) : Catch ex As Exception : GoTo sigRec : End Try ' Valida que sea un xml valido, si no, pasa al sig registro
                Dim cfdi As XNamespace
                Dim nomina12 As XNamespace
                Dim tfd As XNamespace
                nomina12 = "http://www.sat.gob.mx/nomina12"
                tfd = "http://www.sat.gob.mx/TimbreFiscalDigital"

                Dim esVersion4 As Boolean = True

                Try ' VERSION 4.0 CFDI
                    If btnVers4Cfdi.Value Then cfdi = "http://www.sat.gob.mx/cfd/4"
                    archivo.sello = doc.Element(cfdi + "Comprobante").Attribute("Sello").Value
                    archivo.certificado = doc.Element(cfdi + "Comprobante").Attribute("Certificado").Value
                    archivo.serie = doc.Element(cfdi + "Comprobante").Attribute("Serie").Value
                    archivo.total = doc.Element(cfdi + "Comprobante").Attribute("Total").Value.PadLeft(17, "0")
                    archivo.rfcEmisor = doc.Descendants(cfdi + "Emisor").First.Attribute("Rfc").Value
                    archivo.rfcReceptor = doc.Descendants(cfdi + "Receptor").First.Attribute("Rfc").Value
                    esVersion4 = True

                Catch ex As Exception
                    esVersion4 = False
                End Try

                If (Not esVersion4) Then ' Version anterior a la VERS 4.0 (En este caso la 3.3)
                    Try
                        cfdi = "http://www.sat.gob.mx/cfd/3"
                        archivo.sello = doc.Element(cfdi + "Comprobante").Attribute("Sello").Value
                        archivo.certificado = doc.Element(cfdi + "Comprobante").Attribute("Certificado").Value
                        archivo.serie = doc.Element(cfdi + "Comprobante").Attribute("Serie").Value
                        archivo.total = doc.Element(cfdi + "Comprobante").Attribute("Total").Value.PadLeft(17, "0")
                        archivo.rfcEmisor = doc.Descendants(cfdi + "Emisor").First.Attribute("Rfc").Value
                        archivo.rfcReceptor = doc.Descendants(cfdi + "Receptor").First.Attribute("Rfc").Value
                    Catch ex As Exception
                    End Try
                End If

                archivo.FechaPago = doc.Descendants(nomina12 + "Nomina").First.Attribute("FechaPago").Value
                archivo.reloj = doc.Descendants(nomina12 + "Receptor").First.Attribute("NumEmpleado").Value
                archivo.isr_sep = 0

                If doc.Descendants(nomina12 + "Deducciones").Count > 0 Then
                    Dim deducciones = doc.Descendants(nomina12 + "Deducciones").Descendants(nomina12 + "Deduccion")
                    '--AOS:  20/02/2020 - Que agrege los timbrados de archivos de separación por separado y que todo lo que venga en "002" lo inserte como ISR
                    Dim dblISR = 0.0
                    Dim dblImporte = 0.0
                    For Each deduccion In deducciones

                        If (deduccion.Attribute("TipoDeduccion") = "002") Then
                            dblImporte = 0.0

                            If Double.TryParse(deduccion.Attribute("Importe"), dblImporte) Then
                                dblISR += dblImporte
                            Else
                                dblISR += 0.0
                            End If

                            archivo.ISR = deduccion.Attribute("Importe")

                            '--AOS: Que inserte si es ISR Ret o de separacion
                            If (deduccion.Attribute("Clave") = "ISRSEP") Then archivo.isr_sep = 1 Else archivo.isr_sep = 0
                        End If
                    Next
                    archivo.ISR = dblISR
                End If

                '----Determinar si es pago or separación
                If doc.Descendants(nomina12 + "Percepciones").Count > 0 Then
                    Dim percepciones = doc.Descendants(nomina12 + "Percepciones").Descendants(nomina12 + "Percepcion")
                    For Each percepcion In percepciones
                        If (percepcion.Attribute("Clave") = "PRIANT") Then archivo.isr_sep = 1
                        If (percepcion.Attribute("Clave") = "NOREST") Then archivo.isr_sep = 1
                        If (percepcion.Attribute("Clave") = "INDEMN") Then archivo.isr_sep = 1
                    Next
                End If

                archivo.UUID = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("UUID").Value
                archivo.FechaTimbrado = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("FechaTimbrado").Value
                archivo.selloCFD = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("SelloCFD").Value
                archivo.noCertificadoSAT = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("NoCertificadoSAT").Value
                archivo.selloSat = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("SelloSAT").Value
                archivo.cod_comp = cod_comp
                archivo.ano = ano
                archivo.periodo = num_per
                archivo.tipo_periodo_t = tipo_per

                '----AOS: 14/05/2021 :: Validar primero si existe dicho registro para insertarlo, en base al tipo de periodo que tiene actualmente

                Dim _tipo_periodo_ As String = "", insertarTimb As Boolean = True
                _tipo_periodo_ = cmbTipoPeriodo.SelectedValue.ToString.Trim
                Dim dtPers As DataTable = sqlExecute("select reloj,tipo_periodo from nominavw where reloj='" & archivo.reloj &
                                                     "' and cod_comp='" & cod_comp & "' and tipo_periodo='" & _tipo_periodo_ & "' and ano+periodo='" & ano & num_per & "'", "NOMINA")

                If (Not dtPers.Columns.Contains("Error") And dtPers.Rows.Count > 0) Then
                    Try : _tipo_periodo_ = dtPers.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : _tipo_periodo_ = "" : End Try
                Else
                    insertarTimb = False
                End If

                If Not insertarTimb Then GoTo sigRec ' Si no encontró al empleado que no lo inserte y continue con el sig registro

                Dim dtExiste As DataTable = sqlExecute("SELECT * from timbrado where cod_comp='" & cod_comp &
                                                       "' and ano+periodo='" & ano & num_per & "' and reloj='" & archivo.reloj &
                                                       "'  and tipo_periodo='" & _tipo_periodo_ & "' and isnull(isr_sep,0)=" & archivo.isr_sep, "NOMINA")
                If (Not dtExiste.Columns.Contains("Error") And dtExiste.Rows.Count > 0) Then
                    insertarTimb = False
                End If
                '--Ends valilda si existe ya dicho registro

                If insertarTimb Then ' Si se va insertar
                    Dim qDelXml As String = ""
                    qDelXml = "delete from timbrado where ano+periodo='" & ano & num_per & "' and reloj='" & archivo.reloj & "' and cod_comp='" & cod_comp & "' and tipo_periodo='" & tipo_per & "' AND isnull(isr_sep,0)=" & archivo.isr_sep
                    sqlExecute(qDelXml, "NOMINA")

                    Dim QInsert As String = "insert into timbrado (cod_comp, reloj, ano, periodo, tipo_periodo,isr_sep) values ('" & cod_comp & "','" & archivo.reloj & "', '" & ano & "', '" & num_per & "', '" & tipo_per & "', " & archivo.isr_sep & ")"
                    sqlExecute(QInsert, "nomina")

                    Dim xmlNombre As String = archivo.FileName.Trim.Split("\").Last()
                    Dim PathXml As String = xmlDestination & xmlNombre

                    '-- Añadir que tipo de version es apartir de la version 4.0 CFDI
                    Dim _version As String = ""
                    If btnVers4Cfdi.Value Then _version = "4.0" Else _version = "3.3"

                    '--AOS: Que valide si es ISR Ret o de Isr de separacion
                    Dim QUpT As String = "update timbrado set serie = '" & archivo.serie & "',  " & _
                                        "sello ='" & archivo.sello & "',  " & _
                                        "certificado = '" & archivo.certificado & "',  " & _
                                        "selloCFD ='" & archivo.selloCFD & "',  " & _
                                        "selloSat='" & archivo.selloSat & "',  " & _
                                        "UUID='" & archivo.UUID & "',  " & _
                                        "noCertificadoSAT='" & archivo.noCertificadoSAT & "',  " & _
                                        "total='" & archivo.total & "',  " & _
                                        "emisor='" & archivo.rfcEmisor & "',  " & _
                                        "receptor='" & archivo.rfcReceptor & "',  " & _
                                        "FechaPago='" & archivo.FechaPago & "',  " & _
                                        "xml='" & PathXml & "',  " & _
                                        "FechaTimbrado='" & archivo.FechaTimbrado & "',  " & _
                                        "ISR ='" & archivo.ISR & "',version='" & _version & "' where cod_comp='" & cod_comp &
                                        "' and reloj = '" & archivo.reloj & "' and ano = '" & archivo.ano & "' and periodo = '" &
                                        archivo.periodo & "' and tipo_periodo = '" & tipo_per & "' and isr_sep=" & archivo.isr_sep
                    sqlExecute(QUpT, "nomina")
                End If
sigRec:
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            'lblCargaXml.Text = ""
            lblAvance.Text = ""
            'lblCargaXml.Visible = False
        End Try
        'lblCargaXml.Text = ""
        lblAvance.Text = ""
        'lblCargaXml.Visible = False
    End Sub

    Private Sub bgTimbrado_DoWork()

        Dim timbraConcepNormales As Boolean = True

        '---Mostrar Progress
        Dim i As Integer = -1
        frmTrabajando.Text = "Generando timbrado"
        frmTrabajando.Avance.IsRunning = True
        frmTrabajando.lblAvance.Text = "Procesando timbrado"
        ActivoTrabajando = True
        frmTrabajando.Show()
        Application.DoEvents()

        Dim anio As String = cmbAnoPeriodo.SelectedValue.ToString.Trim.Substring(0, 4)
        Dim periodo As String = cmbAnoPeriodo.SelectedValue.ToString.Trim.Substring(4, 2)

        '--- Validar que no haya conceptos sin cod_sat 
        Dim qCodSat As String = "select distinct m.CONCEPTO,c.cod_naturaleza,c.NOMBRE,c.COD_SAT,c.concepto_sat from movimientos m left outer join conceptos c " &
                                "on m.concepto=c.concepto " & _
                                "where m.ano+m.periodo='" & cmbAnoPeriodo.SelectedValue &
                                "'  and c.cod_naturaleza in ('P','D') and m.MONTO<>0  and (isnull(cod_sat,'')='' or isnull(concepto_sat,'')='')"
        Dim dtCodSat As DataTable = sqlExecute(qCodSat, "NOMINA")

        If (Not dtCodSat.Columns.Contains("Error") And dtCodSat.Rows.Count > 0) Then
            MessageBox.Show("Hay conceptos de timbrado que no tienen definido el código SAT, favor de revisar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            gpAvance.Visible = False
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            Exit Sub
        End If

        '--- Validar que no haya  conceptos de deduc sin conc_exento ya que marcaría error
        Dim qDeducExen As String = "select distinct m.CONCEPTO,c.cod_naturaleza,c.NOMBRE,c.conc_exento,c.exento from movimientos m left outer join conceptos c " &
                                    "on m.concepto=c.concepto " & _
                                    "where m.ano+m.periodo='" & cmbAnoPeriodo.SelectedValue &
                                    "'  and c.cod_naturaleza in ('D') and m.MONTO<>0  and (isnull(conc_exento,'')='' or isnull(exento,'')='')"
        Dim dtDeducExen As DataTable = sqlExecute(qDeducExen, "NOMINA")

        If (Not dtDeducExen.Columns.Contains("Error") And dtDeducExen.Rows.Count > 0) Then
            MessageBox.Show("Hay conceptos tipo deducción, que no tienen registrado su concepto exento", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            gpAvance.Visible = False
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            Exit Sub
        End If

        '----AOS - Validar que todos tengan su Registro patronal
        Dim qRegPat As String = "select * from nominavw where ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" &
                                cmbTipoPeriodo.SelectedValue & "' and isnull(reg_pat_planta,'')='' and cod_comp='" & cmbCia.SelectedValue & "'"
        Dim dtRegPat As DataTable = sqlExecute(qRegPat, "NOMINA")

        If (Not dtRegPat.Columns.Contains("Error") And dtRegPat.Rows.Count > 0) Then
            MessageBox.Show("Hay empleados que no tienen capturados su registro patronal, no se puede continuar con el proceso de timbrado",
                            "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '---Cerrar Progress
            gpAvance.Visible = False
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            Exit Sub
        End If

        '--- VERS 4.0 CFDI, revisar quien no tiene capturado su CP_SAT para mandar advertencia
        If (btnVers4Cfdi.Value) Then
            sqlExecute("update personal set cp_sat='00000' where isnull(cp_sat,'')=''", "PERSONAL")
        End If

        '--- AOS: 2021-08-06 : Obtener los diferentes reg patronales que hay siempre y cuando no esten timbrados
        Dim dtDistintosRegPat As DataTable
        Dim QDistRegPat As String = ""

        If (rbLista.Checked) Then
            '--- Solo ciertos empleados seleccionados
            QDistRegPat = "select distinct reg_pat_planta from nominavw where cod_comp='" & cmbCia.SelectedValue &
                        "' and ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' AND folio_cfdi IS NULL and nominavw.reloj in ('" & lista_relojes() &
                        "') and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "' " & _
                        "and reloj not in (select reloj from timbrado where ano+periodo='" & cmbAnoPeriodo.SelectedValue &
                        "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "' and isnull(isr_sep,0)=0)"
        Else
            '--- Todos los empleados
            QDistRegPat = "select distinct reg_pat_planta from nominavw where cod_comp='" & cmbCia.SelectedValue &
                        "' and ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' AND folio_cfdi IS NULL and tipo_periodo='" & cmbTipoPeriodo.SelectedValue &
                        "' and cod_comp='" & cmbCia.SelectedValue & "' " & _
                        "and reloj not in (select reloj from timbrado where ano+periodo='" & cmbAnoPeriodo.SelectedValue &
                        "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "' and isnull(isr_sep,0)=0)"
        End If
        dtDistintosRegPat = sqlExecute(QDistRegPat, "NOMINA")

        '------------Si no hay empleados, que mande mensaje que no hay empleados
        If (Not dtDistintosRegPat.Columns.Contains("Error") And dtDistintosRegPat.Rows.Count <= 0) Then
            MessageBox.Show("No hay empleados a timbrar para la compañía seleccionada", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            timbraConcepNormales = False
        End If

        '---- Estructura para reporte ACUMULADO CFDI:
        Dim dtResumen As New DataTable
        Dim dConcepto As DataRow
        dtResumen.Columns.Add("naturaleza")
        dtResumen.Columns.Add("concepto_sat")
        dtResumen.Columns.Add("concepto_pida")
        dtResumen.Columns.Add("descripcion")
        dtResumen.Columns.Add("gravado", System.Type.GetType("System.Double"))
        dtResumen.Columns.Add("exento", System.Type.GetType("System.Double"))
        dtResumen.Columns.Add("ano")
        dtResumen.Columns.Add("periodo")
        dtResumen.Columns.Add("empleados", System.Type.GetType("System.Double"))
        dtResumen.PrimaryKey = New DataColumn() {dtResumen.Columns("naturaleza"), dtResumen.Columns("concepto_pida")}

        '---- Estructura para reporte detalle de los Reg Patronales que no se timbraron
        Dim dtResRegPat As New DataTable
        Dim dRP As DataRow
        dtResRegPat.Columns.Add("reg_pat_planta")
        dtResRegPat.PrimaryKey = New DataColumn() {dtResRegPat.Columns("reg_pat_planta")}

        Try
            Parametros.Compania = cmbCia.SelectedValue.ToString.Trim
            Parametros.Banco = txtBanco.Text.Trim
            Parametros.Riesgo = txtRiesgo.Text.Trim
            Parametros.PasswordKey = txtClaveKEY.Text.Trim
            Parametros.UsuarioWeb = txtUsuarioWeb.Text.Trim
            Parametros.PasswordWeb = txtClaveWeb.Text.Trim
            Parametros.entidad = txtEntidad.Text
            Parametros.DirDestino = txtDirectorioArchivos.Text.Trim

            If (btnVers4Cfdi.Value) Then '----Version 4.0 CFDI
                Parametros.DirComercioDigital = txtDirectorioCD.Text.Trim
                Parametros.DireccionKey = txtArchivoKEY.Text.Trim
                Parametros.DireccionCer = txtArchivoCER.Text.Trim
            End If

            '--- Obtener ruta de guardado temporal
            Dim dtPathTimb As DataTable = sqlExecute("select path_xml from parametros", "PERSONAL")
            Dim path_xml As String = ""
            If (Not dtPathTimb.Columns.Contains("Error") And dtPathTimb.Rows.Count > 0) Then
                Try : path_xml = dtPathTimb.Rows(0).Item("path_xml").ToString.Trim : Catch ex As Exception : path_xml = "" : End Try
            End If

            If (path_xml = "") Then
                MessageBox.Show("No existe ruta de guardado de los XML's", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            '------ Limpiar archivo de Log de Errores "cd_nomina33.txt"
            Dim path_nom33 As String = "", path_nom40 As String = "" ' Vers 3.3 y 4.0
            Dim dtPathNom33 As DataTable = sqlExecute("select * from datos_cfdi where cod_comp='" & cmbCia.SelectedValue.ToString.Trim & "'", "NOMINA")
            If (Not dtPathNom33.Columns.Contains("Error") And dtPathNom33.Rows.Count > 0) Then
                Try : path_nom40 = dtPathNom33.Rows(0).Item("DIRCOMDIG").ToString.Trim : Catch ex As Exception : path_nom40 = "" : End Try
            End If
            path_nom33 = path_nom40.Replace("nom40", "nom33")

            '--- Guardar archivo antes de limpiarlo
            Dim logSource As String = "", logDestination As String = ""
            Dim fecha_hora As String = Now
            fecha_hora = fecha_hora.Replace(" ", "_").Replace("-", "_").Replace(":", "_").Replace("/", "_").Replace("\", "_")
            If Not btnVers4Cfdi.Value Then logSource = path_nom33 & "\cd_nomina33.log" Else logSource = path_nom40 & "\cd_nomina40.log" ' Indicar vers 3.3 o 4.0 CFDI
            '  logSource = path_nom33 & "\cd_nomina33.log"
            logDestination = path_xml & "LogDetalle_" & fecha_hora & ".log"

            FileCopy(logSource, logDestination) ' Copiarlo antes de limpiarlo
            System.IO.File.WriteAllText(logSource, "") ' Limpiar archivo

            GenResumenRegPat = False  ' No genera resumen de detalle de Reg Pat no timbrados
            empleados = 0.0 ' Total de empleados timbrados
            '********************************************Conceptos normales
            '---- Recorrer cada uno de los registros patronales para generar cada uno de los archivos:
            '--Mostrar progress
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Text = "Procesando datos"
            Application.DoEvents()
            frmTrabajando.Avance.Maximum = dtDistintosRegPat.Rows.Count

            For Each rowRegPat As DataRow In dtDistintosRegPat.Rows
                Dim reg_pat_planta As String = ""
                Try : reg_pat_planta = rowRegPat("reg_pat_planta").ToString.Trim : Catch ex As Exception : reg_pat_planta = "" : End Try
                erroresCurp = False

                '----Mostrar Progress - avance
                i += 1
                frmTrabajando.Avance.Value = i
                frmTrabajando.lblAvance.Text = reg_pat_planta
                Application.DoEvents()

                '-----Generacion del archivo con conceptos de Sueldos y Salarios
                Dim Resultado As Exception
                sfd.DefaultExt = "Archivo de texto|*.txt"
                sfd.Title = "Guardar como"
                sfd.FileName = "Archivo" & cmbCia.SelectedValue & "NOM" & cmbAnoPeriodo.SelectedValue.ToString.Trim & "_" & reg_pat_planta & ".txt"
                sfd.OverwritePrompt = True
                strFileName = path_xml & sfd.FileName
                System.IO.File.CreateText(strFileName).Dispose()

                If (sfd.FileName.Length > 0) Then
                    timbrado = True
                    timbro_Vers_4 = False

                    If btnVers4Cfdi.Value Then
                        timbro_Vers_4 = True
                        Resultado = InterfaceComercioDigital_V40(strFileName, Parametros, cmbAnoPeriodo.SelectedValue, btnPrueba.Value, reg_pat_planta, path_nom40, dtResRegPat, dRP) ' Vers 4.0
                    End If

                    If (timbrado) Then ' Si el archivo fue timbrado entonces va a acumular
                        AcumuladoCFDI(dtResumen, strFileName, dConcepto, anio, periodo)  '---- Ir leyendo cada archivo para obtener los totales y mandarlos al resúmen final

                        '--Actualizar total de empleados
                        For Each drEmp As DataRow In dtResumen.Rows
                            drEmp("empleados") = empleados
                        Next
                    End If
                End If
            Next

            '---Cerrar Progress
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()

            '---- Mandar detalle con el resumen final:
            Try
                If (dtResumen.Rows.Count > 0 And Not dtResumen.Columns.Contains("Error")) Then
                    frmVistaPrevia.LlamarReporte("Acumulado CFDI", dtResumen, Parametros.Compania)
                    frmVistaPrevia.ShowDialog()
                End If
            Catch ex As Exception
            End Try
            '----Ends Reprote con resumen final

            '----- AOS - Mandar detalle del log de errores de los empleados que marcaron error que no se pudieron timbrar
            Dim dtDetalleLogTimb As New DataTable
            Dim dDetLog As DataRow
            dtDetalleLogTimb.Columns.Add("DETALLE")
            dtDetalleLogTimb.Columns.Add("ANO")
            dtDetalleLogTimb.Columns.Add("PERIODO")
            dtDetalleLogTimb.PrimaryKey = New DataColumn() {dtDetalleLogTimb.Columns("DETALLE")}
            Dim str_File_Log As String = logSource
            DetalleLogTimb(dtDetalleLogTimb, dDetLog, anio, periodo, str_File_Log)

            If (dtDetalleLogTimb.Rows.Count > 0 And Not dtDetalleLogTimb.Columns.Contains("Error")) Then
                Dim mensaje As String = ""

                If timbro_Vers_4 Then
                    mensaje = "NOTA: Hubo errores en el timbrado con la versión 4.0 CFDI, favor de timbrarlos con la Versión 3.3" & vbNewLine & "Se mostraran a continuación el log de errores encontrados "
                Else
                    mensaje = "NOTA: Hubo errores en el timbrado." & vbNewLine & "Se mostraran a continuación el log de errores encontrados "
                End If

                MessageBox.Show(mensaje, "Detalle Log timbrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                frmVistaPrevia.LlamarReporte("Detalle_log_timbrado", dtDetalleLogTimb, Parametros.Compania)
                frmVistaPrevia.ShowDialog()
                MessageBox.Show("Favor de corregir dichos errores y volver a timbrar a dichos empleados", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            '----- - ENDS Reporte detalle del log de errores
            '---- Mandar detalle de Registros patronales no timbrados
            If (GenResumenRegPat) Then
                Try
                    Dim mensaje As String = ""
                    If timbro_Vers_4 Then
                        mensaje = "Los empleados con los siguientes Registros patronales no fueron timbrados con la versión 4.0 CFDI"
                    Else
                        mensaje = "Los empleados con los siguientes Registros patronales no fueron timbrados"
                    End If

                    MessageBox.Show(mensaje, "Detalle Reg Pat no timbrados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    frmVistaPrevia.LlamarReporte("Detalle RegPat NoTimb", dtResRegPat, Parametros.Compania)
                    frmVistaPrevia.ShowDialog()
                Catch ex As Exception
                End Try
            End If
            '----Ends detalle de Regs patronales no timbrados

            '---- Mandar detalle de los empleados pendientes aún por timbrar en el periodo actual
            Dim QEmplPendTimb As String = "SELECT * from nominavw where cod_comp='" & cmbCia.SelectedValue & "' and ano+periodo='" &
                                            cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue &
                                            "' and reloj not in(select reloj from timbrado where cod_comp='" & cmbCia.SelectedValue &
                                            "' and ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "')"
            Dim dtNoTimbrados As DataTable = sqlExecute(QEmplPendTimb, "NOMINA")

            If (Not dtNoTimbrados.Columns.Contains("Error") And dtNoTimbrados.Rows.Count > 0) Then
                MessageBox.Show("NOTA: Hay elementos aun pendientes de timbrar." & vbNewLine & "Se mostraran a continuacion los empleados que no están timbrados ",
                 "Detalle pendientes de timbrar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                frmVistaPrevia.LlamarReporte("No Timbrados", dtNoTimbrados, Parametros.Compania)
                frmVistaPrevia.ShowDialog()
            End If

            '---- Enviar Mensaje de timbrado exitoso en caso de no haber rechazos
            If (Not GenResumenRegPat And dtDetalleLogTimb.Rows.Count = 0 And Not erroresCurp And timbraConcepNormales) Then
                MessageBox.Show("El proceso de timbrado concluyó satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            '***********************************Conceptos de separación (NOTA: No se requiere el detalle de registro patronal por empleado)
            '--Mostrar progress
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Text = "Procesando datos de conceptos de separación"
            Application.DoEvents()

            Dim QSep As String = "", QDistRj As String = ""
            Dim ResultadoSep As Exception

            '--Generación del 2do archivo con conceptos de INdemnización (INDEMN,PRIANT,NOREST,ISRSEP (CONCEPTOS.SEP = 1))
            'AOS

            '--- Saber que empleados son los que tren conceptos de separación y aun no están timbrados (timbrado.isr_sep=0 o Null)
            Dim QDistRjMovsSep As String = "select distinct  movimientos.reloj FROM " & _
                                            "movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                                            "WHERE ano+periodo = '" & cmbAnoPeriodo.SelectedValue & "' " & _
                                            "AND ISNULL(CONCEPTOS.SEP,0)=1 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' " & _
                                            "and movimientos.reloj not in " & _
                                            "(select reloj from timbrado where ano+periodo='" & cmbAnoPeriodo.SelectedValue &
                                            "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "' and isnull(isr_sep,0)=1)"

            Dim dtDistRjMovsSep As DataTable = sqlExecute(QDistRjMovsSep, "NOMINA")
            lista_rj_sep = ""

            '----AOS: 2021-08-06 1er Validación, si no hay empleados ya por timbrar, ya sea que estan timbrados o no haya
            If (Not dtDistRjMovsSep.Columns.Contains("Error") And dtDistRjMovsSep.Rows.Count <= 0) Then
                MessageBox.Show("No hay empleados con conceptos de separación por timbrar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '---Cerrar Progress
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                Exit Sub
            End If

            If (Not dtDistRjMovsSep.Columns.Contains("Error") And dtDistRjMovsSep.Rows.Count > 0) Then

                For Each drDM As DataRow In dtDistRjMovsSep.Rows
                    Dim rj As String = ""
                    Try : rj = drDM("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                    lista_rj_sep &= "'" & rj & "',"
                Next

                lista_rj_sep = lista_rj_sep.TrimStart(",")
                lista_rj_sep = lista_rj_sep.TrimEnd(",")
            End If


            If rbLista.Checked Then
                '--Por empleados
                QSep = "SELECT movimientos.reloj, movimientos.ano, movimientos.periodo, movimientos.concepto,conceptos.nombre,ISNULL(cod_sat,'') AS cod_sat," &
                        "exento,concepto_sat,ISNULL(cod_naturaleza,'I') as cod_naturaleza," & _
                       "monto,conceptos.prioridad,ISNULL(CONCEPTOS.OTP,0) AS OTP,ISNULL(CONCEPTOS.SEP,0) AS SEP FROM " & _
                       "movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                       "WHERE  ano+periodo = '" & cmbAnoPeriodo.SelectedValue & _
                       "' AND ISNULL(CONCEPTOS.SEP,0)=1 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue &
                       "' and movimientos.reloj in('" & lista_relojes() & "') " & _
                       "and movimientos.reloj not in (select reloj from timbrado where ano+periodo='" & cmbAnoPeriodo.SelectedValue &
                       "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "' and isnull(isr_sep,0)=1)"
            Else
                '-- Todos los empelados
                QSep = "SELECT movimientos.reloj, movimientos.ano, movimientos.periodo, movimientos.concepto,conceptos.nombre,ISNULL(cod_sat,'') AS cod_sat," &
                        "exento,concepto_sat,ISNULL(cod_naturaleza,'I') as cod_naturaleza," & _
                       "monto,conceptos.prioridad,ISNULL(CONCEPTOS.OTP,0) AS OTP,ISNULL(CONCEPTOS.SEP,0) AS SEP FROM " & _
                       "movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                       "WHERE ano+periodo = '" & cmbAnoPeriodo.SelectedValue & _
                       "' AND ISNULL(CONCEPTOS.SEP,0)=1 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' " & _
                       "and movimientos.reloj not in (select reloj from timbrado where ano+periodo='" & cmbAnoPeriodo.SelectedValue &
                       "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "' and isnull(isr_sep,0)=1)"
            End If

            Dim dtMovSep As DataTable

            If rbLista.Checked Then '--Solo si trae realmente empleados de separación
                If (lista_rj_sep <> "") Then dtMovSep = sqlExecute(QSep, "NOMINA")
            Else
                dtMovSep = sqlExecute(QSep, "NOMINA")
            End If

            '----AOS: 2021-08-06 2Da Validación, si no hay empleados ya por timbrar, ya sea que estan timbrados o no haya
            If (Not dtMovSep.Columns.Contains("Error") And dtMovSep.Rows.Count <= 0) Then
                MessageBox.Show("No hay empleados con conceptos de separación por timbrar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '---Cerrar Progress
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                Exit Sub
            End If

            If (dtMovSep Is Nothing) Then GoTo contin

            If (Not dtMovSep.Columns.Contains("Error") And dtMovSep.Rows.Count > 0) Then ' Si existen movimientos de separación (Finiquitos), generar un segundo archivo

                MessageBox.Show("Se encontraron empleados con conceptos de separación, se procesará con su timbrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                sfd.DefaultExt = "Archivo de texto|*.txt"
                sfd.Title = "Guardar como"
                sfd.FileName = "Archivo" & cmbCia.SelectedValue & "NOM" & cmbAnoPeriodo.SelectedValue.ToString.Trim & "_SEP.txt"
                sfd.OverwritePrompt = True
                strFileName_SEP = path_xml & sfd.FileName
                System.IO.File.CreateText(strFileName_SEP).Dispose()

                If (strFileName_SEP.Length > 0) Then
                    '---Mostrar progress
                    frmTrabajando.Avance.Value = 1
                    frmTrabajando.lblAvance.Text = "Procesando timbrado de separación - " & strFileName_SEP
                    Application.DoEvents()
                    timbro_Vers_4 = False

                    If btnVers4Cfdi.Value Then
                        timbro_Vers_4 = True
                        ResultadoSep = InterfaceComDigSep_V40(strFileName_SEP, Parametros, cmbAnoPeriodo.SelectedValue, btnPrueba.Value, dtMovSep, path_nom40) ' Vers 4.0
                    End If

                    If Not ResultadoSep Is Nothing Then
                        MessageBox.Show(ResultadoSep.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ActivoTrabajando = False
                        frmTrabajando.Close()
                        frmTrabajando.Dispose()
                    End If
                End If
            End If

contin:

            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()

            '----Detalle de errores de Separación
            Dim dtDetErrTimbSep As New DataTable
            Dim dDetLogSep As DataRow
            dtDetErrTimbSep.Columns.Add("DETALLE")
            dtDetErrTimbSep.Columns.Add("ANO")
            dtDetErrTimbSep.Columns.Add("PERIODO")
            dtDetErrTimbSep.PrimaryKey = New DataColumn() {dtDetErrTimbSep.Columns("DETALLE")}
            Dim str_File_Log_Sep As String = logSource
            DetalleLogTimb(dtDetErrTimbSep, dDetLogSep, anio, periodo, str_File_Log_Sep)

            If (dtDetErrTimbSep.Rows.Count > 0 And Not dtDetErrTimbSep.Columns.Contains("Error")) Then
                Dim m1 As String = "", m2 As String = ""
                If timbro_Vers_4 Then
                    m1 = "NOTA: Hubo errores en el timbrado de SEPARACION con la versión 4.0 CFDI" & vbNewLine & "Se mostraran a continuación el log de errores encontrados en el proceso de timbrado de separación "
                    m2 = "Favor de corregir dichos errores y volver a timbrar a dichos empleados, o timbrarlos con la versión 3.3 CFDI"
                Else
                    m1 = "NOTA: Hubo errores en el timbrado de SEPARACION" & vbNewLine & "Se mostraran a continuación el log de errores encontrados en el proceso de timbrado de separación "
                    m2 = "Favor de corregir dichos errores y volver a timbrar a dichos empleados"
                End If

                MessageBox.Show(m1, "Detalle Log timbrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                frmVistaPrevia.LlamarReporte("Detalle_log_timbrado", dtDetErrTimbSep, Parametros.Compania)
                frmVistaPrevia.ShowDialog()
                MessageBox.Show(m2, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

       

        Catch ex As Exception
            gpAvance.Visible = False
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
        End Try
    End Sub

    '---Proceso para leer  del log de errores los detalles cuando haya error
    Private Sub DetalleLogTimb(ByRef _dtDetalleLogTimb As DataTable, ByRef _dDetLog As DataRow, ByRef ano As String, ByRef per As String, ByRef _strFile As String)
        Try
            Dim CompruebaTXT As System.IO.StreamReader = Nothing
            Dim Linea As String
            Dim Datos() As String

            CompruebaTXT = File.OpenText(_strFile)

            Do Until CompruebaTXT.EndOfStream
                Linea = CompruebaTXT.ReadLine
                Datos = Linea.Split("|")
                Dim lin As String = Datos(0).ToUpper

                If (lin.Contains("ERROR EMPL") Or lin.Contains("CODIGO") Or lin.Contains("ERROR VERIF") Or lin.Contains("NOM221 ") Or lin.Contains("NOM226 ") Or lin.Contains("NOM225 ") Or lin.Contains("ERROR CANC") Or lin.Contains("CUENTA BANCARIA") Or lin.Contains("ERROR AL PEDIR SALDO") Or lin.Contains("ERROR LEER XML EMP") Or lin.Contains("RFC RECEPTOR INVALIDO")) Then

                    lin.Replace("'", " ")
                    sqlExecute("insert into log_timbrado values('" & ano & "','" & per & "','" & lin & "',getdate())", "NOMINA")

                    _dDetLog = _dtDetalleLogTimb.Rows.Find(lin)

                    If _dDetLog Is Nothing Then
                        _dDetLog = _dtDetalleLogTimb.NewRow
                        _dDetLog("DETALLE") = lin
                        _dDetLog("ANO") = ano
                        _dDetLog("PERIODO") = per
                        _dtDetalleLogTimb.Rows.Add(_dDetLog)
                    End If
                End If
            Loop

            CompruebaTXT.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AcumuladoCFDI(ByRef _dtResumen As DataTable, ByRef _strFile As String, ByRef _dConcepto As DataRow, ByRef ano As String, ByRef per As String)
        Try
            Dim _total_percepciones As Double
            Dim _total_deducciones As Double
            Dim _total_empleados As Integer
            Dim _total_otros_pagos As Double
            Dim SumaPercepciones As Double = 0
            Dim SumaDeducciones As Double = 0
            Dim SumaOTP As Double = 0
            Dim SumaEmpleados As Integer = 0
            Dim CompruebaTXT As System.IO.StreamReader = Nothing
            Dim Linea As String
            Dim Datos() As String
            Dim T As Integer = 0

            SumaDeducciones = 0
            SumaPercepciones = 0
            SumaEmpleados = 0
            SumaOTP = 0

            CompruebaTXT = File.OpenText(_strFile)

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

                ElseIf Datos(0) = "P01" Or Datos(0) = "D01" Or Datos(0) = "OTP" Then

                    Dim naturaleza As String = IIf(Datos(0) = "P01", "PERCEPCIONES", IIf(Datos(0) = "D01", "DEDUCCIONES", "OTROS PAGOS"))
                    _dConcepto = _dtResumen.Rows.Find({naturaleza, Datos(2)})

                    If _dConcepto Is Nothing Then
                        _dConcepto = _dtResumen.NewRow
                        _dConcepto("naturaleza") = naturaleza
                        _dConcepto("concepto_sat") = Datos(1)
                        _dConcepto("concepto_pida") = Datos(2)
                        _dConcepto("descripcion") = Datos(3)
                        _dConcepto("ano") = ano
                        _dConcepto("periodo") = per

                        If Datos(0) = "P01" Then
                            _dConcepto("gravado") = Datos(4)
                            _dConcepto("exento") = Datos(5)

                        ElseIf Datos(0) = "D01" Or Datos(0) = "OTP" Then
                            _dConcepto("exento") = Datos(4)
                            _dConcepto("gravado") = 0

                        End If
                        _dConcepto("empleados") = _total_empleados
                        _dtResumen.Rows.Add(_dConcepto)
                    Else

                        If Datos(0) = "P01" Then
                            _dConcepto("gravado") += Datos(4)
                            _dConcepto("exento") += Datos(5)

                        ElseIf Datos(0) = "D01" Or Datos(0) = "OTP" Then
                            _dConcepto("exento") += Datos(4)
                        End If

                    End If

                    If Datos(0) = "P01" Then
                        SumaPercepciones = SumaPercepciones + Datos(4) + Datos(5)

                    ElseIf Datos(0) = "D01" Then
                        SumaDeducciones = SumaDeducciones + Datos(4)

                    ElseIf Datos(0) = "OTP" Then
                        SumaOTP = SumaOTP + Datos(4)

                    End If
                End If
            Loop

            CompruebaTXT.Close()
            SumaPercepciones = Math.Round(SumaPercepciones, 2)
            SumaDeducciones = Math.Round(SumaDeducciones, 2)
            SumaOTP = Math.Round(SumaOTP, 2)
            _total_otros_pagos = Math.Round(_total_otros_pagos, 2)
            empleados += _total_empleados

        Catch ex As Exception
        End Try
    End Sub

    Private Sub bgTimbrado_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)

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

        '-- Se abre la ruta donde se guardaron los recibos XML
        If xmlDestination <> "" Then
            If Directory.Exists(txtDirectorioArchivos.Text.Trim) Then
                Process.Start(xmlDestination)
            End If
        End If
    End Sub

    'Private Sub tmrTranscurre_Tick(sender As Object, e As EventArgs)
    '    Dim Procesados As Integer
    '    Dim Total As Integer = pbAvance.Maximum

    '    Dim Transcurrido As Integer
    '    Transcurrido = DateDiff(DateInterval.Second, HoraInicio, Now)

    '    If tmrTranscurre.Tag = "TIMBRADO" Then

    '        Procesados = Directory.EnumerateFiles(Parametros.DirDestino, "*.PDF").Count - ArchivosExistentes
    '        If Procesados = 0 Then
    '            lblAvance.Text = "PREPARANDO TIMBRADO"
    '        ElseIf Procesados < Total Then
    '            lblAvance.Text = Procesados & " registros procesados"
    '        Else
    '            lblAvance.Text = "COMPLETANDO TIMBRADO"
    '        End If
    '    End If

    '    lblTiempo.Text = "Tiempo transcurrido: " & Transcurrido & " segundos."
    'End Sub

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

    Private Sub btnValidarLista_Click(sender As Object, e As EventArgs) Handles btnValidarLista.Click
        Try
            Dim advertencias As New ArrayList
            Dim continuar As Boolean = True
            Dim relojes As String() = txtListaRelojes.Text.Split(",")

            If txtListaRelojes.Text.Trim = "" Then
                advertencias.Add("No se han especificado números de reloj")
                continuar = False
            End If

            Dim ano As String = cmbAnoPeriodo.SelectedValue.ToString.Substring(0, 4)
            Dim periodo As String = cmbAnoPeriodo.SelectedValue.ToString.Substring(4, 2)


            If continuar Then
                For i As Integer = 0 To relojes.Length - 1
                    Dim r As String = relojes(i).PadLeft(5, "0")

                    Dim dtExiste As DataTable = sqlExecute("select * from personal where reloj = '" & r & "'")
                    If dtExiste.Rows.Count > 0 Then
                        Dim dtExisteEnPeriodo As DataTable = sqlExecute("select reloj, isnull(folio_cfdi, '') as folio_cfdi from nomina where reloj = '" & r & "' and ano = '" & ano & "' and periodo = '" & periodo & "'", "nomina")
                        If dtExisteEnPeriodo.Rows.Count > 0 Then
                            Dim folio_cfdi As String = RTrim(dtExisteEnPeriodo.Rows(0)("folio_cfdi"))
                            If folio_cfdi <> "" Then
                                advertencias.Add("El empleado " & r & " ya tiene un registro de CFDI en el periodo " & ano & periodo)
                            End If
                        Else
                            advertencias.Add("El empleado " & r & " no tiene registro de nómina en el periodo " & ano & periodo)
                        End If
                    Else
                        advertencias.Add("El empleado " & r & " no existe en la base de datos de personal")
                    End If

                Next
            End If

            Dim m As String = ""
            If advertencias.Count > 0 Then
                For Each a As String In advertencias
                    m &= a & vbCrLf
                Next
                MessageBox.Show(m, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                m = "Todos los números de reloj son validos para el periodo " & ano & periodo
                MessageBox.Show(m, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function lista_relojes() As String
        Try
            Dim relojes As String() = txtListaRelojes.Text.Split(",")

            Dim l_relojes As String = ""
            For i As Integer = 0 To relojes.Length - 1
                Dim r As String = relojes(i).PadLeft(5, "0")
                l_relojes &= r & " "
            Next

            Return l_relojes.Trim.Replace(" ", "','")
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub rbLista_CheckedChanged(sender As Object, e As EventArgs) Handles rbLista.CheckedChanged, rbTodos.CheckedChanged
        Try

            txtListaRelojes.Text = ""
            btnValidarLista.Enabled = rbLista.Checked
            txtListaRelojes.ReadOnly = Not rbLista.Checked

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBitacora_Click(sender As Object, e As EventArgs) Handles btnBitacora.Click
        Try
            If File.Exists(txtDirectorioCD.Text & "cd_nomina33.log") Then
                Process.Start("explorer.exe", "/select,""" & txtDirectorioCD.Text & "cd_nomina33.log" & """")
            Else
                MessageBox.Show("No se localizó la bitacora (cd_nomina33.log)", "cd_nomina33.log", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbTipoPeriodo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoPeriodo.SelectedValueChanged
        Try
            Dim tabla_periodos As String = "periodos"

            Select Case cmbTipoPeriodo.SelectedValue
                Case "S"
                    tabla_periodos = "periodos"
                Case "C"
                    tabla_periodos = "periodos_catorcenal"
                Case "Q"
                    tabla_periodos = "periodos_quincenal"
                Case "M"
                    tabla_periodos = "periodos_mensual"
            End Select

            Dim q As String = "SELECT ano+periodo as 'unico',ano,periodo,fini_nom as 'fecha_ini',ffin_nom as 'fecha_fin' FROM " & tabla_periodos & " ORDER BY ano DESC,periodo ASC"
            cmbAnoPeriodo.DataSource = sqlExecute(q, "TA")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkFecPago_Click(sender As Object, e As EventArgs) Handles chkFecPago.Click

        If (chkFecPago.Checked = True) Then
            txtFecPago.Enabled = True
            txtFecPago.Value = Date.Now
            txtFecPago.Focus()
        End If
        If (chkFecPago.Checked = False) Then
            txtFecPago.Enabled = False
        End If
    End Sub

    Private Sub chkPtu_CheckStateChanged(sender As Object, e As EventArgs) Handles chkPtu.CheckStateChanged
        If (chkPtu.Checked = False) Then
            chkPtuAltas.Checked = False
            chkPtuBajas.Checked = False
            chkPtuAltas.Enabled = False
            chkPtuBajas.Enabled = False
        End If

        If (chkPtu.Checked = True) Then
            chkPtuAltas.Checked = True
            chkPtuAltas.Enabled = True
            chkPtuBajas.Enabled = True
        End If
    End Sub

    Private Sub chkPtuAltas_CheckStateChanged(sender As Object, e As EventArgs) Handles chkPtuAltas.CheckStateChanged
        If (chkPtuAltas.Checked = True) Then
            chkPtuBajas.Checked = False
        End If

        If (chkPtuAltas.Checked = False) Then

            chkPtuBajas.Checked = True
        End If
    End Sub

    Private Sub chkPtuBajas_CheckStateChanged(sender As Object, e As EventArgs) Handles chkPtuBajas.CheckStateChanged
        If (chkPtuBajas.Checked = True) Then
            chkPtuAltas.Checked = False
        End If

        If (chkPtuBajas.Checked = False) Then
            chkPtuAltas.Checked = True
        End If

    End Sub

    ''' <summary>
    ''' Interfaz comercio digital 4.0
    ''' </summary>
    ''' <param name="strFileName"></param>
    ''' <param name="ParametrosCFDI"></param>
    ''' <param name="AnoPeriodo"></param>
    ''' <param name="Pruebas"></param>
    ''' <param name="_reg_pat_planta"></param>
    ''' <param name="_pathNom33"></param>
    ''' <param name="_dtResRegPat"></param>
    ''' <param name="_drRP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InterfaceComercioDigital_V40(ByVal strFileName As String, ByVal ParametrosCFDI As InfoCFDI,
                                                  ByVal AnoPeriodo As String, ByVal Pruebas As Boolean, _reg_pat_planta As String,
                                                  _pathNom33 As String, ByVal _dtResRegPat As DataTable, ByVal _drRP As DataRow) As Exception

        sitimbrar = False
        percep_dedInCero = False

        Dim dtCias As New DataTable
        Dim dtPeriodos As New DataTable
        Dim dtAuxiliares As New DataTable
        Dim dtPersonal As New DataTable
        Dim dtErrores As New DataTable
        Dim dtNoTimbrados As New DataTable
        Dim _fechapago As Date
        Dim _fechainicialpago As Date
        Dim _fechafinalpago As Date
        Dim _fecha_fin As Date
        Dim _continuar As Boolean = True
        Dim _banco As String
        Dim _riesgo_pto As String
        Dim _registro_patronal As String
        Dim _rfc_cia As String
        Dim _curp_cia As String
        Dim _nombre_cia As String
        Dim _regimen_cia As String
        Dim _sncf As String
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
        Dim entidad As String
        Dim i As Integer
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
        Dim _total_otros_pagos As Double
        Dim _texto As String = ""
        Dim SumaPercepciones As Double = 0
        Dim SumaDeducciones As Double = 0
        Dim SumaOTP As Double = 0
        Dim SumaEmpleados As Integer = 0
        Dim CompruebaTXT As System.IO.StreamReader = Nothing
        Dim Linea As String
        Dim Datos() As String
        Dim FNErrores As String
        Dim T As Integer = 0
        Dim UbicacionArchivo As String
        Dim objFS As New FileStream(strFileName, FileMode.Create, FileAccess.Write)
        Dim ArchivoTXT As New StreamWriter(objFS, System.Text.Encoding.UTF8)
        Dim dtCREPAG As New DataTable
        Dim _total_crepag As Double
        Dim _serie As String = cmbCia.SelectedValue & "NOM" & AnoPeriodo
        Dim _folio As Integer = 1
        Dim _lugar_expedicion As String = "CD. JUAREZ, CHIH"
        Dim _fecha_expedicion As String = DatePart(DateInterval.Year, Now) & _
            DatePart(DateInterval.Month, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Day, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Hour, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Minute, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Second, Now).ToString.Trim.PadLeft(2, "0")

        Try
            Try
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

            entidad = ParametrosCFDI.entidad
            dtCias = sqlExecute("SELECT * FROM cias WHERE cod_comp = '" & ParametrosCFDI.Compania & "'")

            If dtCias.Rows.Count = 0 Then
                Err.Raise(999, Nothing, "No se encontro informacion de la compañia.")
            End If

            _registro_patronal = _reg_pat_planta ' AOS- El registro patronal va a venir por nominavw.reg_pat_planta
            _rfc_cia = IIf(IsDBNull(dtCias.Rows(0).Item("rfc")), "SIN REGISTRO", dtCias.Rows(0).Item("rfc").ToString.Trim)
            _rfc_cia = _rfc_cia.Replace(" ", "").Replace("-", "")
            _curp_cia = IIf(IsDBNull(dtCias.Rows(0).Item("curp")), "SIN REGISTRO", dtCias.Rows(0).Item("curp").ToString.Trim)
            _curp_cia = _curp_cia.Replace(" ", "").Replace("-", "")
            _minimo = IIf(IsDBNull(dtCias.Rows(0).Item("minimo")), 0, dtCias.Rows(0).Item("minimo"))
            _sncf = "IP"
            _nombre_cia = EliminaAcentos(IIf(IsDBNull(dtCias.Rows(0).Item("nombre")), "SIN NOMBRE", dtCias.Rows(0).Item("nombre").ToString.Trim.ToUpper)) ' VERS 4.0 : Validar que siempre venga en Mayusculas
            _regimen_cia = "612"
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

            Dim tabla_periodos As String = "periodos"

            Select Case cmbTipoPeriodo.SelectedValue
                Case "S"
                    tabla_periodos = "periodos"
                Case "C"
                    tabla_periodos = "periodos_catorcenal"
                Case "Q"
                    tabla_periodos = "periodos_quincenal"
                Case "M"
                    tabla_periodos = "periodos_mensual"
            End Select

            dtPeriodos = sqlExecute("SELECT fecha_ini,fecha_fin,fini_nom,ffin_nom,fecha_pago FROM " & tabla_periodos & " WHERE ano = '" & AnoPeriodo.Substring(0, 4) & _
                                    "' AND periodo ='" & AnoPeriodo.Substring(4, 2) & "'", "TA")

            If dtPeriodos.Rows.Count = 0 Then
                Err.Raise(999, Nothing, "No se encontro el periodo seleccionado.")
            End If

            _fechapago = IIf(IsDBNull(dtPeriodos.Rows(0).Item("fecha_pago")), _
                             DateAdd(DateInterval.Day, 5, dtPeriodos.Rows(0).Item("fecha_fin")), _
                             dtPeriodos.Rows(0).Item("fecha_pago"))

            '--Para el caso de WME las fechas son las de fecha de pago de la nomina
            _fechainicialpago = dtPeriodos.Rows(0).Item("fini_nom")
            _fechafinalpago = dtPeriodos.Rows(0).Item("ffin_nom")
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
            dtMovimientosDetalle.Columns.Add("OTP", System.Type.GetType("System.Int16"))
            dtMovimientosDetalle.PrimaryKey = New DataColumn() {dtMovimientosDetalle.Columns("reloj"), dtMovimientosDetalle.Columns("concepto")}

            'Busca a todo el universo de empleados que van a entrar en base al año y periodo seleccionado que estan en Nomina, y que no hayan sido timbrados
            '--AOS : Se agrega el filtro del registro patronal que lo tome de nominavw.reg_pat_planta

            '********************* Validar si está activado el botón de PTU

            '--AOS: VERS 4.0 colocar que agregue el cp_sat y cod_reg_sat, nombre, apaterno y amaterno del empleado de nominavw
            Dim QN As String = ""

            If (chkPtu.Checked = True) Then
                QN = "SELECT RELOJ,NOMBRES,RFC,CURP,NUMIMSS,COD_DEPTO,NOMBRE_DEPTO,ALTA,COD_PUESTO,NOMBRE_PUESTO,COD_TURNO," & _
                      "NOMBRE_TURNO,SACTUAL,cuenta,INTEGRADO,HORAS_DOBLES,HORAS_TRIPLES, nominavw.cod_pago, " & _
                      "ISNULL((SELECT contenido FROM personal.dbo.detalle_auxiliares WHERE campo = 'EMAIL' and reloj = NominaVW.reloj),'') AS EMAIL," &
                      "banco,cp_sat,cod_reg_sat,nombre,apaterno,amaterno " & _
                      "FROM nominaVW WHERE cod_comp = '" & Parametros.Compania & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                      "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' " & _
                      IIf(rbLista.Checked, " and nominavw.reloj in ('" & lista_relojes() & "')", "") & _
                      "AND folio_cfdi IS NULL and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'  and reg_pat_planta='" & _reg_pat_planta & "' " & _
                      "and nominavw.reloj not in (select reloj from timbrado where ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" &
                      cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "' and isnull(isr_sep,0)=0) " & _
                      "and " & IIf(chkPtuAltas.Checked, "isnull(baja,'')=''", "isnull(baja,'')<>''")
            End If

            If (chkPtu.Checked = False) Then
                '----Si no está el botón de PTU,  Hacer lo normal
                QN = "SELECT RELOJ,NOMBRES,RFC,CURP,NUMIMSS,COD_DEPTO,NOMBRE_DEPTO,ALTA,COD_PUESTO,NOMBRE_PUESTO,COD_TURNO," & _
                                      "NOMBRE_TURNO,SACTUAL,cuenta,INTEGRADO,HORAS_DOBLES,HORAS_TRIPLES, nominavw.cod_pago, " & _
                                      "ISNULL((SELECT contenido FROM personal.dbo.detalle_auxiliares WHERE campo = 'EMAIL' and reloj = NominaVW.reloj),'') AS EMAIL," &
                                      "banco,cp_sat,cod_reg_sat,nombre,apaterno,amaterno " & _
                                      "FROM nominaVW WHERE cod_comp = '" & Parametros.Compania & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                                      "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' " & _
                                      IIf(rbLista.Checked, " and nominavw.reloj in ('" & lista_relojes() & "')", "") & _
                                      "AND folio_cfdi IS NULL and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'  and reg_pat_planta='" & _reg_pat_planta & "' " & _
                                      "and nominavw.reloj not in (select reloj from timbrado where ano+periodo='" & cmbAnoPeriodo.SelectedValue &
                                      "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "' and isnull(isr_sep,0)=0)"
            End If

            dtNomina = sqlExecute(QN, "nomina")

            If dtNomina.Rows.Count = 0 Then
                Err.Raise(999, Nothing, "No se encontraron registros de nómina pendientes de timbrar, que cumplan con las condiciones especificadas.")
            End If

            dtNomina.Columns.Add("COD_PAGO_SAT")
            dtNomina.Columns.Add("INCLUIR")
            pbAvance.Maximum = dtNomina.Rows.Count
            T = 0

            '---AOS - Busca todos los movimientos existentes que hay en ese año y periodo seleccionado (Solo los que sean referentes a Sueldos y Salarios [CONCEPTOS.SEP=0])
            Dim QCambiaCrepag As String = ""
            Dim QAddCrepag As String = ""
            Dim ConcePag As String = "CREPAG" ' AOS - NOTA: En algunas empresas lo manejan como CREPAG como TBC, y en otras como WME como SUBPAG

            If (rbLista.Checked) Then
                '---Solo los empleados seleccionados
                dtMovimientos = sqlExecute("SELECT movimientos.reloj, movimientos.ano, movimientos.periodo, movimientos.concepto,conceptos.nombre,ISNULL(cod_sat,'') AS cod_sat,exento,concepto_sat,ISNULL(cod_naturaleza,'I') as cod_naturaleza," & _
                               "monto,conceptos.prioridad,ISNULL(CONCEPTOS.OTP,0) AS OTP,ISNULL(CONCEPTOS.SEP,0) AS SEP FROM " & _
                               "movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                               "WHERE ano = '" & AnoPeriodo.Substring(0, 4) & _
                               "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' AND ISNULL(CONCEPTOS.SEP,0)=0 and  tipo_periodo='" &
                               cmbTipoPeriodo.SelectedValue & "' and reloj in('" & lista_relojes() & "')", "nomina")

                QCambiaCrepag = "SELECT distinct reloj from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) &
                    "'  and CONCEPTO='" & ConcePag & "' and monto<> 0 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and reloj in('" & lista_relojes() & "')"

                QAddCrepag = "select distinct reloj from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) &
                    "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and reloj not in(SELECT distinct reloj from movimientos where ano+periodo='" &
                    AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and CONCEPTO='" &
                    ConcePag & "' and monto<> 0) and reloj in('" & lista_relojes() & "')"
            Else
                '---- Todos los empleados
                dtMovimientos = sqlExecute("SELECT movimientos.reloj, movimientos.ano, movimientos.periodo, movimientos.concepto,conceptos.nombre,ISNULL(cod_sat,'') AS cod_sat," &
                                           "exento,concepto_sat,ISNULL(cod_naturaleza,'I') as cod_naturaleza," & _
                               "monto,conceptos.prioridad,ISNULL(CONCEPTOS.OTP,0) AS OTP,ISNULL(CONCEPTOS.SEP,0) AS SEP FROM " & _
                               "movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                               "WHERE ano = '" & AnoPeriodo.Substring(0, 4) & _
                               "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' AND ISNULL(CONCEPTOS.SEP,0)=0 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'", "nomina")

                QCambiaCrepag = "SELECT distinct reloj from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) &
                    "'  and CONCEPTO='" & ConcePag & "' and monto<> 0 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'"

                QAddCrepag = "select distinct reloj from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) &
                    "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and reloj not in(SELECT distinct reloj from movimientos where ano+periodo='" &
                    AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue &
                    "'  and CONCEPTO='" & ConcePag & "' and monto<> 0)"
            End If

            '----AOS: 26/FEB/2021  -  Proceso para CREPAG (Subempleo pagado efectivamente), siemprey cuando no haya CREFIS
            '---Si ya traen CREPAG, solo es cambiarlo por OTP y hacerlo positivo en caso de que venga negativo
            Dim dtCambiarCrepag As DataTable = sqlExecute(QCambiaCrepag, "NOMINA")
            If (Not dtCambiarCrepag.Columns.Contains("Error") And dtCambiarCrepag.Rows.Count > 0) Then
                For Each rowCambia In dtCambiarCrepag.Rows
                    Dim myRow() As DataRow
                    myRow = dtMovimientos.Select("concepto = '" & ConcePag & "' and reloj = '" & rowCambia("reloj") & "'")
                    Dim monto As Double = myRow(0)("monto")
                    If (monto < 0) Then monto = monto * -1 ' Lo hacemos positivo
                    myRow(0)("cod_sat") = "002"
                    myRow(0)("concepto_sat") = "002"
                    myRow(0)("cod_naturaleza") = "P"
                    myRow(0)("monto") = monto
                    myRow(0)("prioridad") = "470"
                    myRow(0)("otp") = "1"
                Next
            End If

            '---Si no traen CREPAG o SUBPAG, hay que agregarlo
            Dim dtAddCrepag As DataTable = sqlExecute(QAddCrepag, "NOMINA")
            If (Not dtAddCrepag.Columns.Contains("Error") And dtAddCrepag.Rows.Count > 0) Then
                For Each rowAddCre In dtAddCrepag.Rows
                    dtMovimientos.Rows.Add(rowAddCre("reloj"), AnoPeriodo.Substring(0, 4), AnoPeriodo.Substring(4, 2),
                                           ConcePag, "SUBSIDIO AL EMPLEO PAGADO", "002", ConcePag, "", "P", "0.01", "470", "1", "0")
                    dtMovimientos.Rows.Add(rowAddCre("reloj"), AnoPeriodo.Substring(0, 4), AnoPeriodo.Substring(4, 2),
                                           "AJUSUB", "AJUSTE POR SUBSIDIO", "071", "AJUSUB", "", "D", "0.01", "999", "0", "0")
                Next
            End If

            '---Recorrer a cada uno de los empleados y validar (----NORMAL ---)
            For Each dReg As DataRow In dtNomina.Rows
                T += 1
                pbAvance.IsRunning = True
                pbAvance.Value = T
                lblAvance.Text = "Preparando"
                Application.DoEvents()

                Dim _rfc As String = "", _curp As String = ""
                Try : _rfc = dReg("rfc").ToString.Trim : Catch ex As Exception : _rfc = "" : End Try
                Try : _curp = dReg("curp").ToString.Trim : Catch ex As Exception : _curp = "" : End Try

                If _rfc = "" Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    MessageBox.Show("Errores en RFC...Empleado: - " & dReg("reloj").ToString & " - no tiene capturado su RFC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    ArchivoTXT.Close() ' AOS 2021-08-09
                    Exit Function
                End If

                If _curp = "" Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    MessageBox.Show("Errores en CURP...Empleado: - " & dReg("reloj").ToString & " - no tiene capturado su CURP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    ArchivoTXT.Close() ' AOS 2021-08-09
                    Exit Function
                End If

                If Not ValidaRFC(dReg("rfc")) Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    dtErrores.Rows.Add({dReg("reloj"), "RFC inválido (" & dReg("rfc").ToString.Trim & ")"})
                    MessageBox.Show("Errores en RFC...Empleado: - " & dReg("reloj") & " -", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    ArchivoTXT.Close() ' AOS 2021-08-09
                    Exit Function
                End If

                If Not ValidaCURP(dReg("curp")) Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    dtErrores.Rows.Add({dReg("reloj"), "CURP inválido (" & dReg("rfc").ToString.Trim & ")"})
                    MessageBox.Show("Errores en CURP...Empleado: - " & dReg("reloj") & " -", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    ArchivoTXT.Close() ' AOS 2021-08-09
                    Exit Function
                End If

                For Each dMov In dtMovimientos.Select("reloj = '" & dReg("reloj") & "'")

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
                            dMovDetalle("OTP") = dMov("OTP")

                            dtMovimientosDetalle.Rows.Add(dMovDetalle)
                        Else
                            dMovDetalle("monto") += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                        End If

                        If Not IsDBNull(dMov("exento")) Then

                            dtExento = dtMovimientos.Clone

                            Try
                                dtExento = dtMovimientos.Select("concepto = '" & dMov("exento").ToString.Trim & _
                                                  "' AND reloj = '" & dReg("reloj") & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                                                  "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'").CopyToDataTable
                            Catch ex As Exception
                            End Try

                            If dtExento.Rows.Count = 0 Then
                                _exento = 0
                            Else
                                _exento = dtExento.Rows(0).Item("monto")
                            End If

                            dMovDetalle("exento") = _exento

                        Else '--AOS: Para que no mande en Nulo el exento
                            _exento = 0
                            dMovDetalle("exento") = _exento
                        End If
                    End If
                Next
            Next

            For Each row As DataRow In dtNomina.Select("INCLUIR = 'SI'")
                Dim cod_pago As String = row("cod_pago")
                Select Case cod_pago
                    Case "C"
                        row("cod_pago_sat") = "02"
                    Case "D"
                        row("cod_pago_sat") = "03"
                    Case "E"
                        row("cod_pago_sat") = "99"
                    Case "L"
                        row("cod_pago_sat") = "99"
                    Case "B"
                        row("cod_pago_sat") = "03"
                End Select
            Next

            FNErrores = Parametros.DirDestino
            FNErrores = IIf(strFileName.Substring(FNErrores.Trim.Length - 1) <> "\", FNErrores.Trim & "\", FNErrores) & "ErroresDetectados.xlsx"

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
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                MessageBox.Show("Hay empleados con cantidades exentas mayores a los montos, no es posible continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim advertencias As New ArrayList

                For Each dr As DataRow In dtMovimientosDetalle.Select("exento > monto AND exento <> 0")
                    Dim Rj As String = dr("Reloj").ToString.Trim
                    Dim Concepto As String = dr("concepto").ToString.Trim
                    Dim monto As Double = Double.Parse(dr("monto"))
                    Dim exento As Double = Double.Parse(dr("exento"))
                    Dim descrip As String = dr("descripcion").ToString.Trim
                    advertencias.Add("-Empleado " & Rj & " -Concepto: " & Concepto & " - Monto:" & monto & "   - Exento:" & exento)
                Next

                Dim m As String = ""
                If advertencias.Count > 0 Then
                    m &= "ADVERTENCIA" & vbCrLf
                    For Each a As String In advertencias
                        m &= a & vbCrLf
                    Next
                    MessageBox.Show(m, "Empleados no Timbrados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Exit Function
            End If

            '//*** Enrique Meza Para cambiar la naturaleza de cuales queir conceptos en negativo, ya que la interface de Comercio Digital no acepta montos negativos IVO
            For Each dMov In dtMovimientosDetalle.Select("monto<0 AND naturaleza= 'D'")
                dMov("tipo_percepcion") = "038"
                dMov("naturaleza") = "P"
                dMov("concepto") = "MARCAP"
                dMov("descripcion") = "Otras Percepciones Exentas"
                dMov("monto") = -IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                dMov("gravado") = -IIf(IsDBNull(dMov("gravado")), 0, dMov("gravado"))
                dMov("exento") = IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
            Next

            For Each dMov In dtMovimientosDetalle.Select("monto<0 AND naturaleza= 'P'")
                dMov("tipo_percepcion") = "004"
                dMov("naturaleza") = "D"
                dMov("concepto") = "MARCAD"
                dMov("descripcion") = "Otras Deducciones"
                dMov("monto") = -IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                dMov("gravado") = -IIf(IsDBNull(dMov("gravado")), 0, dMov("gravado"))
                dMov("exento") = IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
            Next

            For Each dMov In dtMovimientosDetalle.Select("concepto='MARCAP'")
                dMov("concepto") = "OTPNOG"
            Next

            For Each dMov In dtMovimientosDetalle.Select("concepto='MARCAD'")
                dMov("concepto") = "OTRASD"
            Next

            i = dtMovimientosDetalle.Select("exento > monto AND exento <> 0").Count

            If i > 0 Then
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                MessageBox.Show("Hay empleados con cantidades exentas mayores a los montos, no es posible continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim advertencias As New ArrayList

                For Each dr As DataRow In dtMovimientosDetalle.Select("exento > monto AND exento <> 0")
                    Dim Rj As String = dr("Reloj").ToString.Trim
                    Dim Concepto As String = dr("concepto").ToString.Trim
                    Dim monto As Double = Double.Parse(dr("monto"))
                    Dim exento As Double = Double.Parse(dr("exento"))
                    Dim descrip As String = dr("descripcion").ToString.Trim
                    advertencias.Add("-Empleado " & Rj & " -Concepto: " & Concepto & " - Monto:" & monto & "   - Exento:" & exento)
                Next

                Dim m As String = ""
                If advertencias.Count > 0 Then
                    m &= "ADVERTENCIA" & vbCrLf
                    For Each a As String In advertencias
                        m &= a & vbCrLf
                    Next
                    MessageBox.Show(m, "Empleados no Timbrados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Exit Function
            End If

            _total_crepag = 0
            dtCREPAG.Columns.Add("reloj", System.Type.GetType("System.String"))
            dtCREPAG.Columns.Add("nombres", System.Type.GetType("System.String"))
            dtCREPAG.Columns.Add("monto", System.Type.GetType("System.Double"))

            For Each dc As DataRow In dtMovimientos.Select("concepto = 'CREFIS'")

                Dim rows() As DataRow = dtMovimientosDetalle.Select("concepto = 'CREPAG' and reloj = '" & dc("reloj") & "'")

                If Not rows.Count > 0 Then
                    dtMovimientosDetalle.Rows.Add({dc("reloj"),
                                            "O",
                                            "002",
                                            "CREPAG",
                                            "SUBSIDIO AL EMPLEO PAGADO",
                                            0.01,
                                            0,
                                            0.01,
                                             1160})
                    _total_crepag = _total_crepag + 0.01

                    Dim tempo As DataTable = sqlExecute("select * from personalvw where reloj = '" & dc("reloj") & "'")
                    dtCREPAG.Rows.Add({dc("reloj"),
                                       IIf(IsDBNull(tempo.Rows(0).Item("nombres")), "N/A", tempo.Rows(0).Item("nombres")),
                                       0.01
                                      })
                End If
            Next

            'TOTAL OTROS PAGOS
            For Each dMov In dtMovimientosDetalle.Rows
                Dim _mnto As Double = 0.0
                Dim Exen As Double = 0.0
                Try : _mnto = Double.Parse(dMov("monto")) : Catch ex As Exception : _mnto = 0.0 : End Try
                Try : Exen = Double.Parse(dMov("exento")) : Catch ex As Exception : Exen = 0.0 : End Try

                dMov("gravado") = Math.Round(_mnto - Exen, 2)

                'SI EL CODIGO DE SAT ES acumular como otros pagos

                If RTrim(dMov("OTP")) = "1" Then
                    _total_otros_pagos += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))

                ElseIf dMov("naturaleza").ToString.Trim = "P" Then
                    _total_percepciones += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))

                ElseIf dMov("naturaleza").ToString.Trim = "D" Then
                    Dim monto As Double = IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                    If monto >= 0 Then
                        _total_deducciones += monto
                    ElseIf monto < 0 Then
                        _total_otros_pagos += (monto * -1)
                    End If
                End If
            Next

            _total_empleados = dtNomina.Select("incluir = 'SI'").Count

            If (_total_otros_pagos > 0 And (_total_percepciones = 0 And _total_deducciones = 0)) Then  ' Solo viene el concepto de OTP (Otros pagos)
                GoTo SaltarPer_2
            End If

            If _total_percepciones <= 0 Or _total_deducciones < 0 Then
                percep_dedInCero = True
                GoTo noIncluir
            End If

SaltarPer_2:
            sqlExecute("UPDATE bitacora_timbrados SET tot_per = " & _total_percepciones & "," & _
                       "tot_ded = " & _total_deducciones & "," & _
                       "tot_neto = " & _total_percepciones - _total_deducciones & " WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")

            Dim cod_pago_sat As String = "03"

            '--AOS - 03/12/2019: Validar fecha de pago si la va a tomar del campo correspondiente o de TA.dbo.Periodos
            If (chkFecPago.Checked) Then
                Dim FPag As String = ""
                Try : FPag = FechaSQL(txtFecPago.Value) : Catch ex As Exception : FPag = "" : End Try
                If (FPag <> "" And FPag <> "0001-01-01") Then
                    _fechapago = txtFecPago.Value
                End If
            End If
            '--Ends

            '	*** ENCABEZADO DE ARCHIVO CON DATOS DEL PATRON, donde va la fecha de pago
            '-----AOS: 2021-11-12 Saber si va a ser una nom Ordinaria o Extraordinaria
            Dim tNom As String = "O", periodicidad As String = "", tablas_periodos As String = ""
            Dim dias_pag_default As String = "14" ' TBC Dias pagados por default  dependiendo de los dias del periodo AOS 18/08/2021
            Dim concepDiasPag As String = "DIASPA" ' &&_ Concepto que viene desde movs  que trae los diasPag OJO: No debe de mandarse en decimales, siempre en Enteros
            Dim montoDiasPag As String = "14"

            '---Define el tipo de periodicidad, los dias default a pagar, y en que tabla buscar para saber si es periodoi extraordinario
            Select Case cmbTipoPeriodo.SelectedValue.ToString.Trim
                Case "S"
                    periodicidad = "02"
                    dias_pag_default = "7"
                    montoDiasPag = "7"
                    tabla_periodos = "ta.dbo.periodos"
                Case "C"
                    periodicidad = "03"
                    dias_pag_default = "14"
                    montoDiasPag = "14"
                    tabla_periodos = "ta.dbo.periodos_catorcenal"
                Case "Q"
                    periodicidad = "04"
                    dias_pag_default = "15"
                    montoDiasPag = "15"
                    tabla_periodos = "ta.dbo.periodos_quincenal"
                Case "M"
                    periodicidad = "05"
                    dias_pag_default = "30"
                    montoDiasPag = "30"
                    tabla_periodos = "ta.dbo.periodos_mensual"
                Case Else
                    periodicidad = "99"
                    dias_pag_default = "7"
                    montoDiasPag = "7"
                    tabla_periodos = "ta.dbo.periodos"
            End Select

            Dim dtPerEspecial As DataTable = sqlExecute("select * from " & tabla_periodos & " where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "'")
            Dim periodo_especial As Integer = 0

            If (Not dtPerEspecial.Columns.Contains("Error") And dtPerEspecial.Rows.Count > 0) Then Try : periodo_especial = dtPerEspecial.Rows(0).Item("periodo_especial") : Catch ex As Exception : periodo_especial = 0 : End Try

            If (periodo_especial = 1) Then
                tNom = "E"
                periodicidad = "99"
            End If

            _texto = "EMP|" & _rfc_cia & "|" & _nombre_cia & "|" & _regimen_cia & "|" & _curp_cia & "||" & tNom & "|" & vbCrLf '** Esto se quita en la version 3.3 & _sncf & "||" & vbCrLf
            _texto = _texto & "KEY|" & ParametrosCFDI.DireccionKey.Trim.Replace("\", "/") & "|" & vbCrLf
            _texto = _texto & "CER|" & ParametrosCFDI.DireccionCer.Trim.Replace("\", "/") & "|" & vbCrLf
            _texto = _texto & "PVE|" & ParametrosCFDI.PasswordKey.Trim & "|" & vbCrLf
            _texto = _texto & "WS0|" & ParametrosCFDI.UsuarioWeb.Trim & "|" & ParametrosCFDI.PasswordWeb.Trim & "|" & vbCrLf
            _texto = _texto & "NOM|" & _registro_patronal & "|" & FechaSQL(_fechapago) & "|" & FechaSQL(_fechainicialpago) & "|" & FechaSQL(_fechafinalpago) & "|" & vbCrLf
            _texto = _texto & "CFD|" & _serie & "|" & _folio & "|" & _cp_cia & "|" & _fecha_expedicion & "|" & vbCrLf
            _texto = _texto & "TOT|" & String.Format("{0:0.00}", _total_percepciones) & "|" & String.Format("{0:0.00}", _total_deducciones) & "|" & _total_empleados.ToString.Trim & "|" & String.Format("{0:0.00}", _total_otros_pagos) & "|" & vbCrLf
            _texto = _texto & "INI|"

            ArchivoTXT.WriteLine(_texto)

            Dim _perc_totalgravado As Double
            Dim _perc_totalexento As Double
            Dim _ded_totalgravado As Double
            Dim _ded_totalexento As Double
            Dim _otros_pagos_empleado As Double
            Dim _textoMov As String = ""

            pbAvance.Maximum = dtNomina.Select("incluir = 'SI'").Count
            T = 0

            For Each dMov In dtNomina.Select("incluir = 'SI'")
                Try
                    T += 1
                    pbAvance.IsRunning = True
                    pbAvance.Value = T
                    lblAvance.Text = "Exportando"
                    Application.DoEvents()

                    Dim Rj As String = dMov("reloj").ToString.Trim
                    Dim _sactual As Double = 0.0, _integrado As Double = 0.0

                    Try : _sactual = Double.Parse(dMov("sactual")) : Catch ex As Exception : _sactual = 0.0 : End Try
                    Try : _integrado = Double.Parse(dMov("integrado")) : Catch ex As Exception : _integrado = 0.0 : End Try

                    '---VERS 4.0 cambiar a NOMBRE+APATERNO+AMATERNO
                    Dim nombre_completo_empleado As String = "", n As String = "", ap As String = "", am As String = ""
                    Try : n = dMov("NOMBRE").ToString.Trim.ToUpper : Catch ex As Exception : n = "" : End Try
                    Try : ap = dMov("APATERNO").ToString.Trim.ToUpper : Catch ex As Exception : ap = "" : End Try
                    Try : am = dMov("AMATERNO").ToString.Trim.ToUpper : Catch ex As Exception : am = "" : End Try
                    nombre_completo_empleado = n + " " + ap + " " + am

                    _texto = "E01|" & dMov("reloj").ToString.Trim & "|"
                    _texto = _texto & nombre_completo_empleado.ToString.Trim.Replace(",", " ") & "|" ' VERS 4.0 cambia forma de mandar el nombre
                    _texto = _texto & dMov("rfc").ToString.Trim.Replace("-", "").PadRight(13, "X") & "|"
                    _texto = _texto & dMov("curp").ToString.Trim & "|"
                    _texto = _texto & "02|" ' Tipo regimen empleado
                    _texto = _texto & dMov("numimss").ToString.Trim & "|"

                    'Dias pagados desde movimientos (NORMAL) [numDiasPagados]
                    Try
                        'NOTA: Los días pagados (numDiasPagados) deben de ir enteros, pero si traen decimal, a tres dig, ejemplo: 7.8 --> 7.800
                        Dim dtDiasPagados As DataTable = sqlExecute("select * from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) &
                                                                    AnoPeriodo.Substring(4, 2) & "' and reloj='" & dMov("reloj").ToString.Trim &
                                                                    "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and concepto='" & concepDiasPag & "'", "NOMINA")
                        If (Not dtDiasPagados.Columns.Contains("Error") And dtDiasPagados.Rows.Count > 0) Then
                            Try : montoDiasPag = dtDiasPagados.Rows(0).Item("MONTO").ToString.Trim : Catch ex As Exception : montoDiasPag = dias_pag_default : End Try
                        Else
                            montoDiasPag = dias_pag_default
                        End If

                        '---Validar que los dias pagados sean mayor a cero 2022-11-29
                        Dim numdiaspagados As Double = 0.0
                        Try : numdiaspagados = Double.Parse(montoDiasPag) : Catch ex As Exception : numdiaspagados = 1 : End Try
                        If numdiaspagados <= 1 Then montoDiasPag = "1"

                        '---Si trae decimales, dejarlo  a 7.800 por ejemplo, siempre a 3 digitos
                        If (montoDiasPag.Contains(".")) Then
                            Dim cade1 As String = "", cade2 As String = ""
                            cade1 = montoDiasPag.Split(".")(0)
                            cade2 = montoDiasPag.Split(".")(1).PadRight(3, "0")
                            cade2 = cade2.Substring(0, 3) ' Siempre a 3 dígitos
                            montoDiasPag = cade1 & "." & cade2
                        End If

                        _texto = _texto & montoDiasPag & "|"  '&& Días pagados desde movimientos

                    Catch ex As Exception
                        _texto = _texto & montoDiasPag & "|"  '&& Default
                    End Try
                    '---- ENDS (NORMAL) [numDiasPagados]

                    _texto = _texto & EliminaAcentos(dMov("nombre_depto").ToString.ToUpper.Trim) & "|"

                    '--- Obtener el codigo del banco de acuerdo al banco que debe de trae el empleado
                    Dim nombreBanco As String = ""
                    Try : nombreBanco = dMov("BANCO").ToString.Trim.ToUpper : Catch ex As Exception : nombreBanco = "" : End Try

                    Select Case nombreBanco
                        Case "BANCOMER"
                            _banco = "012"
                        Case "HSBC"
                            _banco = "021"
                        Case "SANTANDER"
                            _banco = "014"
                        Case "BBVA BANCOMER"
                            _banco = "012"
                        Case Else
                            _banco = ParametrosCFDI.Banco
                    End Select

                    If dMov("cod_pago_sat") = "03" Then
                        _texto = _texto & dMov("cuenta").ToString.Trim.PadLeft(11, "0") & "|" ' cuenta bancaria
                        _texto = _texto & (_banco) & "|"  '&& CLABE PENDIENTE
                    Else
                        _texto = _texto & "|" ' cuenta bancaria
                        _texto = _texto & "|"  '&& CLABE PENDIENTE
                    End If

                    Dim antigEmpl As String = ""
                    Try : antigEmpl = Math.Truncate((DateDiff(DateInterval.Day, dMov("alta"), _fecha_fin) + 1) / 7).ToString.Trim : Catch ex As Exception : antigEmpl = "1" : End Try

                    _texto = _texto & FechaSQL(dMov("alta")) & "|"
                    _texto = _texto & antigEmpl & "|" ' Antiguedad del empleado
                    _texto = _texto & dMov("nombre_puesto").ToString.ToUpper.Trim & "|"
                    _texto = _texto & "01|"   ' tipo contrato PENDIENTE
                    _texto = _texto & IIf(dMov("cod_turno") = "2" Or dMov("cod_turno") = "9", "03", IIf(dMov("cod_turno") = "3", "02", "01")) & "|" ' tipo jornada
                    _texto = _texto & periodicidad & "|" ' periodicidad 
                    _texto = _texto & String.Format("{0:0.00}", dMov("sactual")) & "|"
                    _texto = _texto & _riesgo_pto & "|"
                    _texto = _texto & String.Format("{0:0.00}", dMov("integrado")) & "|"
                    _texto = _texto & "No|" ' sindicalizado
                    _texto = _texto & entidad & "|" ' entidad

                    If (dMov("email").ToString.Length > 0 And Not Pruebas) And sbEmail.Value = True Then
                        _texto = _texto & dMov("email").ToString.Trim & "|"
                    Else
                        _texto = _texto & "|"
                    End If

                    _perc_totalgravado = 0
                    _perc_totalexento = 0
                    _ded_totalgravado = 0
                    _ded_totalexento = 0
                    _otros_pagos_empleado = 0

                    '** PERCEPCIONES
                    _textoMov = ""

                    'Manejar indemnizaciones
                    'ABRAHAM CASAS DICIEMBRE 2018, SE INCLUYE EL REGISTRO PARA LOS CUATRO CONCEPTOS (INDEMN, PRIANT, NOREST, ISRSEP)
                    Try
                        Dim dtINDEMN As DataTable = dtMovimientosDetalle.Select("concepto in ('INDEMN', 'PRIANT', 'NOREST')  AND reloj = '" &
                                                                                dMov("reloj").ToString.Trim & "'").CopyToDataTable
                        If dtINDEMN.Rows.Count > 0 Then
                            Dim dtDatosPersonal As DataTable = sqlExecute("select reloj, sactual, alta, baja from personal where reloj = '" &
                                                                          dMov("reloj") & "' and baja is not null")

                            If dtDatosPersonal.Rows.Count > 0 Then

                                Dim sactual As Double = dtDatosPersonal.Rows(0)("sactual")
                                Dim alta As Date = dtDatosPersonal.Rows(0)("alta")
                                Dim baja As Date = dtDatosPersonal.Rows(0)("baja")
                                Dim antig As Integer = DateDiff(DateInterval.Year, alta, baja) + 1
                                Dim ddetalle As Double = 0

                                For Each row As DataRow In dtINDEMN.Rows
                                    ddetalle += row("monto")
                                Next

                                _textoMov = _textoMov & "S01|" & String.Format("{0:0.00}", ddetalle) ' Total pagado
                                _textoMov = _textoMov & "|" & antig ' anios servicio
                                _textoMov = _textoMov & "|" & String.Format("{0:0.00}", sactual * 30.4) ' ultimo sueldo mensual
                                _textoMov = _textoMov & "|" & String.Format("{0:0.00}", 0) ' ingreso acumulable
                                _textoMov = _textoMov & "|" & String.Format("{0:0.00}", 0) ' ingreso no acumulable
                                _textoMov = _textoMov & "|" & vbCrLf
                            End If
                        End If

                    Catch ex As Exception

                    End Try

                    'HABRA UNA EXCEPCION SI EL EMPLEADO NO TIENE OTPs
                    Try ' Conceptos para OTP otros pagos (OTP = COD_SAT = 999), van fijos aquí, En la tabla CONCEPTOS ya debe de venir el campo de OTP = 1 refiriendo que es como Otros Pagos
                        Dim dtOTP As DataTable = dtMovimientosDetalle.Select("OTP = 1  AND reloj = '" & dMov("reloj").ToString.Trim & "'", "PRIORIDAD,TIPO_PERCEPCION").CopyToDataTable
                        Dim concPag As String = "CREPAG" ' AOS - Nota: En algunas empresas se maneja como CREPAG como en TBC, y en WME se maneja el SUBPAG
                        Dim concSubCau As String = "CREFIS" ' AOS -  Nota: En otros estác omo SUBEMP y es el Subsidio Causado que se generó y debe de ir en la línea del Subempleo pagado

                        For Each dDetalle As DataRow In dtOTP.Rows
                            _textoMov = _textoMov & "OTP|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                            _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                            _textoMov = _textoMov & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                            _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto")) & "|"

                            Dim _subsidio_causado As Double = 0
                            Dim _concepto_otp As String = RTrim(dDetalle("concepto").ToString.Trim)

                            '--- Interface NORMAL  AOS: En este caso el subsidio causado va en el concepto SUBEMP, por eso se coloca ahí, y si va como negativo, lo hacemos Positivo
                            Select Case _concepto_otp
                                Case concPag
                                    For Each row As DataRow In dtMovimientos.Select("concepto in ('" & concSubCau & "') AND reloj = '" & dMov("reloj").ToString.Trim & "'")
                                        Try
                                            _subsidio_causado += Double.Parse(row("monto"))
                                        Catch ex As Exception

                                        End Try
                                    Next
                                    '12/02/2020: AOS - Agregar CREPAG de 0.01 para timbrado
                                    If _subsidio_causado = 0 Then
                                        _subsidio_causado = 0.01
                                    End If
                                    '--ENDS
                                    If (_subsidio_causado < 0) Then _subsidio_causado = _subsidio_causado * -1
                                    _textoMov = _textoMov & String.Format("{0:0.00}", _subsidio_causado) & "|||"
                            End Select
                            _textoMov = _textoMov & "|" & vbCrLf
                            _otros_pagos_empleado += dDetalle("monto")
                        Next
                    Catch ex As Exception

                    End Try

                    '** DEDUCCIONES NEGATIVAS
                    For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'D' AND reloj = '" & dMov("reloj").ToString.Trim & "' and isnull(exento,0) < 0", "PRIORIDAD,TIPO_PERCEPCION")

                        Dim _concepto As String = dDetalle("concepto").ToString.Trim
                        _textoMov = _textoMov & "OTP|" & IIf(_concepto = "ISRCOM", "004", "999") & "|" & _concepto & "|" & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                        _textoMov = _textoMov & String.Format("{0:0.00}", Double.Parse(dDetalle("exento")) * -1) & "|"

                        If _concepto = "ISRCOM" Then
                            _textoMov = _textoMov & "|" & String.Format("{0:0.00}", Double.Parse(dDetalle("exento")) * -1) & "|" & Now.Year - 1 & "|0.00"
                        Else
                            _textoMov = _textoMov & "|||"
                        End If

                        _textoMov = _textoMov & "|" & vbCrLf
                        _otros_pagos_empleado += Double.Parse(dDetalle("exento")) * -1
                    Next

                    '--Excluir los conceptos que son Otros Pagos (OTP) (Otros pagos con cod_sat = 999 ya que esos no entran al total de percepciones)
                    For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'P' AND reloj = '" & dMov("reloj").ToString.Trim & "' and OTP=0 and monto>0", "PRIORIDAD,TIPO_PERCEPCION")
                        '-----AOS- 28/01/2020 - Hacer separación de lo gravado y exento del Fondo de Ahorro (APOCIA) : 11/02/2020: Ya no es necesario ya que su exento viene todo en "PEXFAH", tiene el mismo tratamiento que los demas conceptos

                        Dim Concep As String = "", gravado As String = "", exento As String = ""
                        Try : Concep = dDetalle("concepto").ToString.Trim : Catch ex As Exception : Concep = "" : End Try
                        Try : gravado = dDetalle("gravado").ToString.Trim : Catch ex As Exception : gravado = "0" : End Try
                        Try : exento = dDetalle("exento").ToString.Trim : Catch ex As Exception : exento = "0" : End Try
                        If gravado = "" Then gravado = "0"
                        If exento = "" Then exento = "0"

                        _textoMov = _textoMov & "P01|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                        _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                        _textoMov = _textoMov & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                        _textoMov = _textoMov & String.Format("{0:0.00}", gravado) & "|"
                        _textoMov = _textoMov & String.Format("{0:0.00}", exento) & "|"

                        'El detalle de la percepción extra se incluye dentro de la misma línea
                        If dDetalle("tipo_percepcion").ToString.Trim = "019" Then
                            _textoMov = _textoMov & "1|" ' && DIAS EN QUE SE PAGA TIEMPO EXTRA
                            If dDetalle("concepto").ToString.Trim = "PEREX2" Then
                                _textoMov = _textoMov & "01|"
                                Dim horas As Integer = Math.Truncate(dMov("horas_dobles"))
                                If horas > 0 Then
                                    _textoMov = _textoMov & horas & "|"
                                Else
                                    _textoMov = _textoMov & "1|"
                                End If

                            ElseIf dDetalle("concepto").ToString.Trim = "PEREX3" Then
                                _textoMov = _textoMov & "02|"
                                Dim horas As Integer = Math.Truncate(dMov("horas_triples"))
                                If horas > 0 Then
                                    _textoMov = _textoMov & horas & "|"
                                Else
                                    _textoMov = _textoMov & "1|"
                                End If
                            End If
                            _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto"))
                        Else
                            _textoMov = _textoMov & "|||"
                        End If

                        _textoMov = _textoMov & "|" & vbCrLf
                        _perc_totalgravado += IIf(IsDBNull(dDetalle("gravado")), 0, dDetalle("gravado"))
                        _perc_totalexento += IIf(IsDBNull(dDetalle("exento")), 0, dDetalle("exento"))
                    Next

                    '** DEDUCCIONES  AOS - Se cambio para que el monto lo tome de monto y no de la columna exento, ya que exento no aplica para deducciones
                    For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'D' AND reloj = '" & dMov("reloj").ToString.Trim & "' and isnull(exento,0) > 0 ", "PRIORIDAD,TIPO_PERCEPCION")

                        _textoMov = _textoMov & "D01|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                        _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                        _textoMov = _textoMov & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"

                        '--12/02/2020 AOS: Agregar CREPAG de 0.01 para timbrado
                        If dDetalle("concepto").ToString.Trim = "AJUSUB" Then
                            dDetalle("monto") = "0.01"
                        End If

                        _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto")) & "|" & vbCrLf
                        _ded_totalexento += IIf(IsDBNull(dDetalle("monto")), 0, dDetalle("monto"))
                    Next

                    '** AOS: Add datos de Incapacidades (I01) 
                    For Each dDetalle As DataRow In dtMovimientosDetalle.Select("tipo_percepcion in('014') and naturaleza in ('P')  AND reloj = '" &
                                                                                dMov("reloj").ToString.Trim & "'", "PRIORIDAD,TIPO_PERCEPCION")

                        Dim diasIncap As String = "3", tipo_incap As String = "", monto_incap As String = "", monto_inc_dbl As Double = 0.0,
                            sueldo As Double = 0.0, sd As Double = 0.0, integrado As Double = 0.0
                        Dim descrip As String = ""

                        Try : descrip = dDetalle("descripcion").ToString.Trim : Catch ex As Exception : descrip = "" : End Try
                        Try : monto_inc_dbl = Double.Parse(dDetalle("monto")) : Catch ex As Exception : monto_inc_dbl = 0.0 : End Try

                        If (_sactual <> 0.0) Then sueldo = _sactual
                        If (_integrado <> 0.0 And _sactual = 0.0) Then sueldo = _integrado
                        Try : diasIncap = Convert.ToString(CInt(monto_inc_dbl / sueldo)) : Catch ex As Exception : diasIncap = "0" : End Try
                        Try : monto_incap = String.Format("{0:0.00}", dDetalle("monto")) : Catch ex As Exception : monto_incap = "0.00" : End Try

                        '-- Tipo de incapacidad
                        If (descrip.ToString.ToUpper.Contains("RIESGO")) Then tipo_incap = "01" ' Riesgo de trabajo
                        If (descrip.ToString.ToUpper.Contains("MATERNI")) Then tipo_incap = "03" ' Incap por Maternidad
                        If (tipo_incap = "") Then tipo_incap = "02" 'Enf. Gral

                        _textoMov = _textoMov & "I01|" & diasIncap & "|"
                        _textoMov = _textoMov & tipo_incap & "|"
                        _textoMov = _textoMov & monto_incap & "|" & vbCrLf
                    Next

                    _textoMov = _textoMov & "F01|" & vbCrLf
                    _texto = _texto & String.Format("{0:0.00}", _perc_totalexento + _perc_totalgravado) & "|"
                    _texto = _texto & String.Format("{0:0.00}", _ded_totalexento + _ded_totalgravado) & "|"
                    _texto = _texto & String.Format("{0:0.00}", _otros_pagos_empleado) & "|"

                    '----VERS 4.0 - 2022-05-23: Add el CP_SAT del empleado
                    Dim cp_sat As String = ""
                    Try : cp_sat = dMov("cp_sat").ToString.Trim : Catch ex As Exception : cp_sat = "" : End Try
                    _texto = _texto & cp_sat & "|"

                    '--AOS: 04/02/2020: Validar si es retimbrado, para que coloque el UUID CANCELADO
                    Dim uuid_canc As String = ""
                    Dim KeyEmp As String = AnoPeriodo.ToString.Trim & Rj
                    Dim dtRetimb As DataTable = sqlExecute("SELECT UUID from retimbrado where isnull(sep,0)=0 and ano+periodo+reloj='" & KeyEmp & "'", "NOMINA")

                    If (Not dtRetimb.Columns.Contains("Error") And dtRetimb.Rows.Count > 0) Then
                        Try : uuid_canc = dtRetimb.Rows(0).Item("UUID").ToString.Trim : Catch ex As Exception : uuid_canc = "" : End Try
                        _texto = _texto & uuid_canc & "|"
                    Else
                        _texto = _texto & "|"
                    End If

                    _texto = _texto & vbCrLf
                    ArchivoTXT.Write(_texto)
                    ArchivoTXT.Write(_textoMov)
                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "timbrado", Err.Number, ex.Message)
                End Try
            Next

            ArchivoTXT.WriteLine("FIN|")
            ArchivoTXT.Close()

noIncluir:
            ArchivoTXT.Close()
            sqlExecute("UPDATE bitacora_timbrados SET archivo = 1," & _
                       "nombrearch  = '" & strFileName & "' WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")
        Catch ex As Exception
            ArchivoTXT.Close()
            Return ex
        End Try

        Dim _random As Single = 0

        If percep_dedInCero Then
            sitimbrar = False
            GoTo noTimbrar
        End If

        sitimbrar = True
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
        pbAvance.IsRunning = True
        tmrTranscurre.Tag = "TIMBRADO"
        lblAvance.Text = "Generando timbrado"
        Application.DoEvents()

        Dim valor_capturado As Double = 0
        Dim captura As New frmCapturaNeto
        Dim rand As Integer = New Random().Next(0, 2)
        Dim valor_esperado As Double = 0

        Select Case rand
            Case 0
                valor_esperado = _total_percepciones
                captura.texto = "total de percepciones"
            Case 1
                valor_esperado = _total_deducciones
                captura.texto = "total de deducciones"
            Case 2
                valor_esperado = _total_deducciones + _total_otros_pagos - _total_deducciones
                captura.texto = "neto a timbrar"
        End Select

        ' Eliminamos el archivo con extension Folios para que lo vuelva a crear
        Try
            Kill(_pathNom33 & "\" & _serie & ".txt.folios")
        Catch ex As Exception
        End Try

        '---- Aquí es donde ejecuta el programa CD NOM 33 para hacer el timbrado como tal

        Dim Q As String = "cd_nomina40 " & _serie & ".txt " & IIf(Pruebas, "pruebas2 ", "ws ") & Chr(34) & ParametrosCFDI.DirDestino.Trim & Chr(34)
        ss = Shell("cd_nomina40 " & _serie & ".txt " & IIf(Pruebas, "pruebas2 ", "ws ") & Chr(34) & ParametrosCFDI.DirDestino.Trim & Chr(34), AppWinStyle.Hide, True) 'Vers 4.0 CFDI ORGINAL a partir del 2024 sera pruebas2 para timbrado de prueba
        Directory.SetCurrentDirectory(dirActual)

        '---AOS: Si no se timbró, agregar detalle de Reg Patronales no timbrados
        If Dir(dirCFDI & _serie & ".txt.folios") = "" Then
            timbrado = False
            GenResumenRegPat = True
            _drRP = _dtResRegPat.Rows.Find({_reg_pat_planta})
            If (_drRP Is Nothing) Then  ' Si no encuentra el registro patronal en la lista, hay que agregarlo
                _drRP = _dtResRegPat.NewRow
                _drRP("reg_pat_planta") = _reg_pat_planta
                _dtResRegPat.Rows.Add(_drRP)
            End If

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

                '--- Timbrado normal si es de prueba no debe de actualizar la tabla de nomina
                If Not btnPrueba.Value Then ' &&_AOS: Se quita solo de prueba para que se registren
                    sqlExecute("UPDATE nomina SET folio_cfdi = '" & Datos(2) & "'," & _
                          "fecha_cfdi = '" & Datos(3) & "'," & _
                          "certificado_cfdi = '" & Datos(4) & "'," & _
                          "ubicacion_archivo_cfdi = '" & UbicacionArchivo & "' " & _
                          "WHERE reloj = '" & Datos(1) & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                         "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "'", "nomina")
                End If

            Loop
            CompruebaTXT.Close()

            '-----ADRIAN ORTEGA (AOS)
            If rbLista.Checked Then
                dtNoTimbrados = sqlExecute("select ano + '-' + PERIODO as 'Periodo',* from nomina where cod_comp='" & cmbCia.SelectedValue & "' and reloj in('" & lista_relojes() & "') and ano+periodo='" & AnoPeriodo.Trim & "' and (isnull(folio_cfdi,'')='' or isnull(CERTIFICADO_CFDI,null)='')", "NOMINA")
            Else
                '--Todos los empleados
                dtNoTimbrados = sqlExecute("select ano + '-' + PERIODO as 'Periodo',* from nomina where cod_comp='" & cmbCia.SelectedValue & "' and ano+periodo='" & AnoPeriodo.Trim & "' and (isnull(folio_cfdi,'')='' or isnull(CERTIFICADO_CFDI,null)='')", "NOMINA")
            End If
        End If

        bgTimbrado.ReportProgress(-2)

        '---AOS - Si se mandó a timbrar
        If (timbrado) Then
            Guarda_Act_xmls()  '-----AOS --- -Leer cada uno de los archivos XML's, colocarlos en el path correcto y actualizar tabla de NOMINA.dbo.timbrado
        End If

        Return Nothing

        CompruebaTXT.Close()
noTimbrar:

        If (sitimbrar) Then
            If Dir(strFileName).Length > 0 Then
                If MessageBox.Show("Ocurrió un error de comprobación, ¿Desea eliminar el archivo generado hasta el momento?", "Error de comprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    Kill(strFileName)
                End If
            End If
        End If

        Return New Exception("Error en comprobación")
    End Function


    Private Function InterfaceComDigSep_V40(ByVal strFileName As String, ByVal ParametrosCFDI As InfoCFDI, ByVal AnoPeriodo As String, ByVal Pruebas As Boolean, ByVal dtMovSep As DataTable, ByVal _pathNom33 As String) As Exception
        sitimbrar = False
        Dim dtCias As New DataTable
        Dim dtPeriodos As New DataTable
        Dim dtAuxiliares As New DataTable
        Dim dtPersonal As New DataTable
        Dim dtErrores As New DataTable

        Dim _serie As String = cmbCia.SelectedValue & "NOM" & AnoPeriodo & "_SEP" '-- Archivo de seperación
        Dim _folio As Integer = 1
        Dim _lugar_expedicion As String = "CD. JUAREZ, CHIH"
        Dim _fecha_expedicion As String = DatePart(DateInterval.Year, Now) & _
            DatePart(DateInterval.Month, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Day, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Hour, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Minute, Now).ToString.Trim.PadLeft(2, "0") & _
            DatePart(DateInterval.Second, Now).ToString.Trim.PadLeft(2, "0")

        Dim _fechapago As Date
        Dim _fechainicialpago As Date
        Dim _fechafinalpago As Date
        Dim _fecha_fin As Date
        Dim _continuar As Boolean = True

        Dim _banco As String
        Dim _riesgo_pto As String
        Dim _registro_patronal As String
        Dim _rfc_cia As String
        Dim _curp_cia As String


        Dim _nombre_cia As String
        Dim _regimen_cia As String
        Dim _sncf As String
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
        Dim entidad As String

        Dim i As Integer

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

        Dim _total_otros_pagos As Double

        Dim _texto As String = ""

        Dim SumaPercepciones As Double = 0
        Dim SumaDeducciones As Double = 0
        Dim SumaOTP As Double = 0
        Dim SumaEmpleados As Integer = 0

        Dim CompruebaTXT As System.IO.StreamReader = Nothing
        Dim Linea As String
        Dim Datos() As String
        Dim FNErrores As String
        Dim T As Integer = 0
        Dim UbicacionArchivo As String

        Dim objFS As New FileStream(strFileName, FileMode.Create, FileAccess.Write)
        Dim ArchivoTXT As New StreamWriter(objFS, System.Text.Encoding.UTF8)
        Dim dtCREPAG As New DataTable
        Dim _total_crepag As Double

        Try
            Try
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
            entidad = ParametrosCFDI.entidad

            dtCias = sqlExecute("SELECT * FROM cias WHERE cod_comp = '" & ParametrosCFDI.Compania & "'")
            If dtCias.Rows.Count = 0 Then Err.Raise(999, Nothing, "No se encontro informacion de la compañia.")

            _registro_patronal = IIf(IsDBNull(dtCias.Rows(0).Item("reg_pat")), "SIN REGISTRO", dtCias.Rows(0).Item("reg_pat").ToString.Trim)
            _registro_patronal = _registro_patronal.Replace(" ", "").Replace("-", "")

            _rfc_cia = IIf(IsDBNull(dtCias.Rows(0).Item("rfc")), "SIN REGISTRO", dtCias.Rows(0).Item("rfc").ToString.Trim)
            _rfc_cia = _rfc_cia.Replace(" ", "").Replace("-", "")
            _curp_cia = IIf(IsDBNull(dtCias.Rows(0).Item("curp")), "SIN REGISTRO", dtCias.Rows(0).Item("curp").ToString.Trim)
            _curp_cia = _curp_cia.Replace(" ", "").Replace("-", "")


            _minimo = IIf(IsDBNull(dtCias.Rows(0).Item("minimo")), 0, dtCias.Rows(0).Item("minimo"))
            _sncf = "IP"
            _nombre_cia = EliminaAcentos(IIf(IsDBNull(dtCias.Rows(0).Item("nombre")), "SIN NOMBRE", dtCias.Rows(0).Item("nombre").ToString.Trim)) ' Vers 4.0, validar que siempre venga en Mayusculas
            _regimen_cia = "612"
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

            Dim tabla_periodos As String = "periodos"

            Select Case cmbTipoPeriodo.SelectedValue
                Case "S"
                    tabla_periodos = "periodos"
                Case "C"
                    tabla_periodos = "periodos_catorcenal"
                Case "Q"
                    tabla_periodos = "periodos_quincenal"
                Case "M"
                    tabla_periodos = "periodos_mensual"
            End Select

            dtPeriodos = sqlExecute("SELECT fecha_ini,fecha_fin,fini_nom,ffin_nom,fecha_pago FROM " & tabla_periodos & " WHERE ano = '" & AnoPeriodo.Substring(0, 4) & _
                                    "' AND periodo ='" & AnoPeriodo.Substring(4, 2) & "'", "TA")
            If dtPeriodos.Rows.Count = 0 Then Err.Raise(999, Nothing, "No se encontró el periodo seleccionado.")

            _fechapago = IIf(IsDBNull(dtPeriodos.Rows(0).Item("fecha_pago")), _
                             DateAdd(DateInterval.Day, 5, dtPeriodos.Rows(0).Item("fecha_fin")), _
                             dtPeriodos.Rows(0).Item("fecha_pago"))

            '_fechainicialpago = dtPeriodos.Rows(0).Item("fecha_ini")
            '_fechafinalpago = dtPeriodos.Rows(0).Item("fecha_fin")

            '--Para el caso de WME las fechas son las de fecha de pago de la nomina
            _fechainicialpago = dtPeriodos.Rows(0).Item("fini_nom")
            _fechafinalpago = dtPeriodos.Rows(0).Item("ffin_nom")

            _fecha_fin = _fechafinalpago


            dtMovimientosDetalle.Columns.Add("reloj", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("naturaleza", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("tipo_percepcion", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("concepto", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("descripcion", System.Type.GetType("System.String"))
            dtMovimientosDetalle.Columns.Add("monto", System.Type.GetType("System.Double"))
            dtMovimientosDetalle.Columns.Add("gravado", System.Type.GetType("System.Double"))
            dtMovimientosDetalle.Columns.Add("exento", System.Type.GetType("System.Double"))
            dtMovimientosDetalle.Columns.Add("prioridad", System.Type.GetType("System.Int16"))
            dtMovimientosDetalle.Columns.Add("OTP", System.Type.GetType("System.Int16"))
            dtMovimientosDetalle.PrimaryKey = New DataColumn() {dtMovimientosDetalle.Columns("reloj"), dtMovimientosDetalle.Columns("concepto")}

            'Busca a todo el universo de empleados que van a entrar en base al año y periodo seleccionado que estan en Nomina

            ' VERS 4.0 CFDI , tomar nuevos campos para el timbrado 4.0
            Dim Qnom As String = ""
            If rbLista.Checked Then ' Ciertos empleados
                Qnom = "SELECT RELOJ,NOMBRES,RFC,CURP,NUMIMSS,COD_DEPTO,NOMBRE_DEPTO,ALTA,COD_PUESTO,NOMBRE_PUESTO,COD_TURNO," & _
                                  "NOMBRE_TURNO,SACTUAL,cuenta,INTEGRADO,HORAS_DOBLES,HORAS_TRIPLES, nominavw.cod_pago, " & _
                                  "ISNULL((SELECT contenido FROM personal.dbo.detalle_auxiliares WHERE campo = 'EMAIL' and reloj = NominaVW.reloj),'') AS EMAIL,banco,cp_sat,cod_reg_sat,nombre,apaterno,amaterno " & _
                                  "FROM nominaVW WHERE cod_comp = '" & Parametros.Compania & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                                  "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' " & _
                                  " and nominavw.reloj in ('" & lista_relojes() & "') and " & _
                                  " tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and nominavw.reloj in(" & lista_rj_sep & ")"
            Else
                Qnom = "SELECT RELOJ,NOMBRES,RFC,CURP,NUMIMSS,COD_DEPTO,NOMBRE_DEPTO,ALTA,COD_PUESTO,NOMBRE_PUESTO,COD_TURNO," & _
                  "NOMBRE_TURNO,SACTUAL,cuenta,INTEGRADO,HORAS_DOBLES,HORAS_TRIPLES, nominavw.cod_pago, " & _
                  "ISNULL((SELECT contenido FROM personal.dbo.detalle_auxiliares WHERE campo = 'EMAIL' and reloj = NominaVW.reloj),'') AS EMAIL,banco,cp_sat,cod_reg_sat,nombre,apaterno,amaterno " & _
                  "FROM nominaVW WHERE cod_comp = '" & Parametros.Compania & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                  "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' " & _
                  " and nominavw.reloj in(" & lista_rj_sep & ") and " & _
                  " tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "'"

            End If
            dtNomina = sqlExecute(Qnom, "nomina")

            If dtNomina.Rows.Count = 0 Then
                Err.Raise(999, Nothing, "No se encontraron registros de nómina pendientes de timbrar, que cumplan con las condiciones especificadas.")
            End If

            dtNomina.Columns.Add("COD_PAGO_SAT")

            dtNomina.Columns.Add("INCLUIR")
            pbAvance.Maximum = dtNomina.Rows.Count

            T = 0


            '--Evaluar a cada empleado de la nomina en ese año y periodo  (------SEPARACION ------)
            For Each dReg As DataRow In dtNomina.Rows
                T += 1

                pbAvance.IsRunning = True
                pbAvance.Value = T
                lblAvance.Text = "Preparando"
                Application.DoEvents()

                Dim _rfc As String = "", _curp As String = ""
                Try : _rfc = dReg("rfc").ToString.Trim : Catch ex As Exception : _rfc = "" : End Try
                Try : _curp = dReg("curp").ToString.Trim : Catch ex As Exception : _curp = "" : End Try

                If _rfc = "" Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    MessageBox.Show("Errores en RFC...Empleado: - " & dReg("reloj").ToString & " - no tiene capturado su RFC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    ArchivoTXT.Close() ' AOS 2021-08-09
                    Exit Function
                End If

                If _curp = "" Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    MessageBox.Show("Errores en CURP...Empleado: - " & dReg("reloj").ToString & " - no tiene capturado su CURP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    ArchivoTXT.Close() ' AOS 2021-08-09
                    Exit Function
                End If

                If Not ValidaRFC(dReg("rfc")) Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    dtErrores.Rows.Add({dReg("reloj"), "RFC inválido (" & dReg("rfc").ToString.Trim & ")"})
                    MessageBox.Show("Errores en RFC...Empleado: - " & dReg("reloj") & " -", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    Exit Function
                    '  Continue For
                End If

                If Not ValidaCURP(dReg("curp")) Then
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    dtErrores.Rows.Add({dReg("reloj"), "CURP inválido (" & dReg("rfc").ToString.Trim & ")"})
                    MessageBox.Show("Errores en CURP...Empleado: - " & dReg("reloj") & " -", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    erroresCurp = True
                    Exit Function
                    '  Continue For
                End If



                '--Evaluar cada movimiento de separación de cada empleado
                For Each dMov In dtMovSep.Select("reloj = '" & dReg("reloj") & "'")
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
                            dMovDetalle("OTP") = dMov("OTP")

                            dtMovimientosDetalle.Rows.Add(dMovDetalle)
                        Else
                            dMovDetalle("monto") += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                        End If

                        If Not IsDBNull(dMov("exento")) Then

                            dtExento = dtMovSep.Clone
                            Try
                                dtExento = dtMovSep.Select("concepto = '" & dMov("exento").ToString.Trim & _
                                                  "' AND reloj = '" & dReg("reloj") & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                                                  "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'").CopyToDataTable
                            Catch ex As Exception

                            End Try


                            If dtExento.Rows.Count = 0 Then
                                _exento = 0
                            Else
                                _exento = dtExento.Rows(0).Item("monto")
                            End If
                            dMovDetalle("exento") = _exento
                        Else '--AOS: Para que no mande en Nulo el exento
                            _exento = 0
                            dMovDetalle("exento") = _exento
                        End If
                    End If
                Next
            Next

            For Each row As DataRow In dtNomina.Select("INCLUIR = 'SI'")
                Dim cod_pago As String = row("cod_pago")
                Select Case cod_pago
                    Case "C"
                        row("cod_pago_sat") = "02"
                    Case "D"
                        row("cod_pago_sat") = "03"
                    Case "E"
                        row("cod_pago_sat") = "99"
                    Case "L"
                        row("cod_pago_sat") = "99"
                    Case "B"
                        row("cod_pago_sat") = "03"
                End Select
            Next

            FNErrores = Parametros.DirDestino
            FNErrores = IIf(strFileName.Substring(FNErrores.Trim.Length - 1) <> "\", FNErrores.Trim & "\", FNErrores) & "ErroresDetectados.xlsx"
            '   If dtErrores.Rows.Count > 0 Then MessageBox.Show("Errores en CURP...")

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
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                MessageBox.Show("Hay empleados con cantidades exentas mayores a los montos, no es posible continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim advertencias As New ArrayList
                For Each dr As DataRow In dtMovimientosDetalle.Select("exento > monto AND exento <> 0")
                    Dim Rj As String = dr("Reloj").ToString.Trim
                    Dim Concepto As String = dr("concepto").ToString.Trim
                    Dim monto As Double = Double.Parse(dr("monto"))
                    Dim exento As Double = Double.Parse(dr("exento"))
                    Dim descrip As String = dr("descripcion").ToString.Trim
                    advertencias.Add("-Empleado " & Rj & " -Concepto: " & Concepto & " - Monto:" & monto & "   - Exento:" & exento)
                Next

                Dim m As String = ""
                If advertencias.Count > 0 Then
                    m &= "ADVERTENCIA" & vbCrLf
                    For Each a As String In advertencias
                        m &= a & vbCrLf
                    Next
                    MessageBox.Show(m, "Empleados no Timbrados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Exit Function
                '    Err.Raise(999, Nothing, "¡ALERTA!" & vbCrLf & "Existen cantidades exentas mayores a los montos. No es posible continuar")
            End If

            '//*** Para cambiar la naturaleza de cuales conceptos en negativo, ya que la interface de Comercio Digital no acepta montos negativos IVO
            For Each dMov In dtMovimientosDetalle.Select("monto<0 AND naturaleza= 'D'")
                dMov("tipo_percepcion") = "038"
                dMov("naturaleza") = "P"
                dMov("concepto") = "MARCAP"
                dMov("descripcion") = "Otras Percepciones Exentas"
                dMov("monto") = -IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                dMov("gravado") = -IIf(IsDBNull(dMov("gravado")), 0, dMov("gravado"))
                dMov("exento") = IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
            Next

            For Each dMov In dtMovimientosDetalle.Select("monto<0 AND naturaleza= 'P'")
                dMov("tipo_percepcion") = "004"
                dMov("naturaleza") = "D"
                dMov("concepto") = "MARCAD"
                dMov("descripcion") = "Otras Deducciones"
                dMov("monto") = -IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                dMov("gravado") = -IIf(IsDBNull(dMov("gravado")), 0, dMov("gravado"))
                dMov("exento") = IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
            Next
            For Each dMov In dtMovimientosDetalle.Select("concepto='MARCAP'")
                dMov("concepto") = "OTPNOG"
            Next
            For Each dMov In dtMovimientosDetalle.Select("concepto='MARCAD'")
                dMov("concepto") = "OTRASD"
            Next

            i = dtMovimientosDetalle.Select("exento > monto AND exento <> 0").Count
            If i > 0 Then
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                MessageBox.Show("Hay empleados con cantidades exentas mayores a los montos, no es posible continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim advertencias As New ArrayList
                For Each dr As DataRow In dtMovimientosDetalle.Select("exento > monto AND exento <> 0")
                    Dim Rj As String = dr("Reloj").ToString.Trim
                    Dim Concepto As String = dr("concepto").ToString.Trim
                    Dim monto As Double = Double.Parse(dr("monto"))
                    Dim exento As Double = Double.Parse(dr("exento"))
                    Dim descrip As String = dr("descripcion").ToString.Trim
                    advertencias.Add("-Empleado " & Rj & " -Concepto: " & Concepto & " - Monto:" & monto & "   - Exento:" & exento)
                Next

                Dim m As String = ""
                If advertencias.Count > 0 Then
                    m &= "ADVERTENCIA" & vbCrLf
                    For Each a As String In advertencias
                        m &= a & vbCrLf
                    Next
                    MessageBox.Show(m, "Empleados no Timbrados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Exit Function
                '    Err.Raise(999, Nothing, "¡ALERTA!" & vbCrLf & "Existen cantidades exentas mayores a los montos. No es posible continuar")
            End If

            _total_crepag = 0

            dtCREPAG.Columns.Add("reloj", System.Type.GetType("System.String"))
            dtCREPAG.Columns.Add("nombres", System.Type.GetType("System.String"))
            dtCREPAG.Columns.Add("monto", System.Type.GetType("System.Double"))

            For Each dc As DataRow In dtMovSep.Select("concepto = 'CREFIS'")

                Dim rows() As DataRow = dtMovimientosDetalle.Select("concepto = 'CREPAG' and reloj = '" & dc("reloj") & "'")
                If Not rows.Count > 0 Then
                    dtMovimientosDetalle.Rows.Add({dc("reloj"),
                                            "O",
                                            "002",
                                            "CREPAG",
                                            "SUBSIDIO AL EMPLEO PAGADO",
                                            0.01,
                                            0,
                                            0.01,
                                             1160})
                    _total_crepag = _total_crepag + 0.01

                    Dim tempo As DataTable = sqlExecute("select * from personalvw where reloj = '" & dc("reloj") & "'")
                    dtCREPAG.Rows.Add({dc("reloj"),
                                       IIf(IsDBNull(tempo.Rows(0).Item("nombres")), "N/A", tempo.Rows(0).Item("nombres")),
                                       0.01
                                      })

                End If

            Next

            'TOTAL OTROS PAGOS [CONCEPTOS.OTP = 1]
            For Each dMov In dtMovimientosDetalle.Rows
                Dim _mnto As Double = 0.0
                Dim Exen As Double = 0.0
                Try : _mnto = Double.Parse(dMov("monto")) : Catch ex As Exception : _mnto = 0.0 : End Try
                Try : Exen = Double.Parse(dMov("exento")) : Catch ex As Exception : Exen = 0.0 : End Try

                ' dMov("gravado") = dMov("monto") - IIf(IsDBNull(dMov("exento")), 0, dMov("exento"))
                dMov("gravado") = Math.Round(_mnto - Exen, 2)

                ' If RTrim(dMov("concepto")) = "COMVIA" Then  ' Conceptos para OTROS PAGOS (OTP = COD_SAT = 999), van aqui fijos
                If RTrim(dMov("OTP")) = "1" Then
                    _total_otros_pagos += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))

                ElseIf dMov("naturaleza").ToString.Trim = "P" Then
                    _total_percepciones += IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))

                ElseIf dMov("naturaleza").ToString.Trim = "D" Then
                    Dim monto As Double = IIf(IsDBNull(dMov("monto")), 0, dMov("monto"))
                    If monto >= 0 Then
                        _total_deducciones += monto
                    ElseIf monto < 0 Then
                        _total_otros_pagos += (monto * -1)
                    End If

                End If
            Next

            _total_empleados = dtNomina.Select("incluir = 'SI'").Count

            If (_total_otros_pagos > 0 And (_total_percepciones = 0 And _total_deducciones = 0)) Then  ' Solo viene el concepto de OTP (Otros pagos)
                GoTo SaltarPer
            End If

            If _total_percepciones <= 0 Or _total_deducciones < 0 Then Err.Raise(999, Nothing, "Falta información. Favor de revisar")
SaltarPer:

            sqlExecute("UPDATE bitacora_timbrados SET tot_per = " & _total_percepciones & "," & _
           "tot_ded = " & _total_deducciones & "," & _
           "tot_neto = " & _total_percepciones - _total_deducciones & " WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")

            Dim cod_pago_sat As String = "03"

            '--AOS - 03/12/2019: Validar fecha de pago si la va a tomar del campo correspondiente o de TA.dbo.Periodos
            If (chkFecPago.Checked) Then
                Dim FPag As String = ""
                Try : FPag = FechaSQL(txtFecPago.Value) : Catch ex As Exception : FPag = "" : End Try
                If (FPag <> "" And FPag <> "0001-01-01") Then
                    _fechapago = txtFecPago.Value
                End If
            End If
            '--Ends

            '	*** ENCABEZADO DE ARCHIVO CON DATOS DEL PATRON, donde va la fecha de pago
            Dim tNom As String = "E" ' En separación siempre es Extraordinaria
            _texto = "EMP|" & _rfc_cia & "|" & _nombre_cia & "|" & _regimen_cia & "|" & _curp_cia & "||" & tNom & "|" & vbCrLf '** Esto se quita en la version 3.3 & _sncf & "||" & vbCrLf
            _texto = _texto & "KEY|" & ParametrosCFDI.DireccionKey.Trim.Replace("\", "/") & "|" & vbCrLf
            _texto = _texto & "CER|" & ParametrosCFDI.DireccionCer.Trim.Replace("\", "/") & "|" & vbCrLf
            _texto = _texto & "PVE|" & ParametrosCFDI.PasswordKey.Trim & "|" & vbCrLf
            _texto = _texto & "WS0|" & ParametrosCFDI.UsuarioWeb.Trim & "|" & ParametrosCFDI.PasswordWeb.Trim & "|" & vbCrLf
            '    _texto = _texto & "NOM|" & _registro_patronal & "|" & FechaSQL(_fechapago) & "|" & FechaSQL(_fechainicialpago) & "|" & FechaSQL(_fechafinalpago) & "|" & vbCrLf
            _texto = _texto & "NOM||" & FechaSQL(_fechapago) & "|" & FechaSQL(_fechainicialpago) & "|" & FechaSQL(_fechafinalpago) & "|" & vbCrLf
            _texto = _texto & "CFD|" & _serie & "|" & _folio & "|" & _cp_cia & "|" & _fecha_expedicion & "|" & vbCrLf
            _texto = _texto & "TOT|" & String.Format("{0:0.00}", _total_percepciones) & "|" & String.Format("{0:0.00}", _total_deducciones) & "|" & _total_empleados.ToString.Trim & "|" & String.Format("{0:0.00}", _total_otros_pagos) & "|" & vbCrLf
            _texto = _texto & "INI|"

            ArchivoTXT.WriteLine(_texto)

            Dim _perc_totalgravado As Double
            Dim _perc_totalexento As Double
            Dim _ded_totalgravado As Double
            Dim _ded_totalexento As Double
            Dim _otros_pagos_empleado As Double
            Dim _textoMov As String = ""

            pbAvance.Maximum = dtNomina.Select("incluir = 'SI'").Count

            T = 0

            '--- Detalle de cada empleado (E01)
            For Each dMov In dtNomina.Select("incluir = 'SI'")
                T += 1

                pbAvance.IsRunning = True
                pbAvance.Value = T
                lblAvance.Text = "Exportando"

                Dim Rj As String = ""
                Rj = dMov("reloj").ToString.Trim

                '---VERS 4.0 cambiar a NOMBRE+APATERNO+AMATERNO
                Dim nombre_completo_empleado As String = "", n As String = "", ap As String = "", am As String = ""
                Try : n = dMov("NOMBRE").ToString.Trim.ToUpper : Catch ex As Exception : n = "" : End Try
                Try : ap = dMov("APATERNO").ToString.Trim.ToUpper : Catch ex As Exception : ap = "" : End Try
                Try : am = dMov("AMATERNO").ToString.Trim.ToUpper : Catch ex As Exception : am = "" : End Try
                nombre_completo_empleado = n + " " + ap + " " + am

                _texto = "E01|" & dMov("reloj").ToString.Trim & "|"
                ' _texto = _texto & dMov("nombres").ToString.Trim.Replace(",", " ") & "|" 
                _texto = _texto & nombre_completo_empleado.ToString.Trim.Replace(",", " ") & "|" ' VERS 4.0 Cambiar a NOMBRE(S)+ APATERNO + AMATERNO (Siempre en mayúsculas)
                _texto = _texto & dMov("rfc").ToString.Trim.Replace("-", "").PadRight(13, "X") & "|"
                _texto = _texto & dMov("curp").ToString.Trim & "|"
                '   _texto = _texto & "02|" ' Tipo regimen empleado
                _texto = _texto & "13|" ' Tipo regimen empleado, en Separacion = 13
                '  _texto = _texto & dMov("numimss").ToString.Trim & "|"
                _texto = _texto & "|" ' Quitamos el NO.Imss en separación


                'Dias pagados desde movimientos (SEPARACION)

                Dim dias_pag_default As String = "14" ' TBC Dias pagados por default  dependiendo de los dias del periodo AOS 18/08/2021
                Dim concepDiasPag As String = "DIASPA" ' &&_ Concepto que viene desde movs  que trae los diasPag OJO: No debe de mandarse en decimales, siempre en Enteros
                Dim montoDiasPag As String = "14", periodicidad As String = "99"

                '---Define el tipo de periodicidad
                Select Case cmbTipoPeriodo.SelectedValue.ToString.Trim
                    Case "S"
                        periodicidad = "99" ' Para los de separación, el tipo de periodicidad es 99
                        dias_pag_default = "7"
                        montoDiasPag = "7"
                    Case "C"
                        periodicidad = "99" ' Para los de separación, el tipo de periodicidad es 99
                        dias_pag_default = "14"
                        montoDiasPag = "14"
                    Case "Q"
                        periodicidad = "99" ' Para los de separación, el tipo de periodicidad es 99
                        dias_pag_default = "15"
                        montoDiasPag = "15"
                    Case "M"
                        periodicidad = "99" ' Para los de separación, el tipo de periodicidad es 99
                        dias_pag_default = "30"
                        montoDiasPag = "30"
                    Case Else
                        periodicidad = "99" ' Para los de separación, el tipo de periodicidad es 99
                        dias_pag_default = "7"
                        montoDiasPag = "7"
                End Select

                Try
                    'NOTA: Los días pagados (numDiasPagados) deben de ir enteros, pero si traen decimal, a tres dig, ejemplo: 7.8 --> 7.800 (-----------SEPARACION ----------)
                    'NOTA2: En archivos de separación, los DIASPA tienen que equivaler  a los de dias de Indem, si no trae, que equivalgan a los dias por PRIANT, y si no trae nada, que tome en base a los dias del periodo
                    '     Dim dtDiasPagados As DataTable = sqlExecute("select * from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "' and reloj='" & dMov("reloj").ToString.Trim & "' and cod_comp='" & Parametros.Compania & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and concepto='" & concepDiasPag & "'", "NOMINA") ' Buscando por COD_COMP
                    Dim dtDiasPagados As DataTable = sqlExecute("select * from movimientos where ano+periodo='" & AnoPeriodo.Substring(0, 4) & AnoPeriodo.Substring(4, 2) & "' and reloj='" & dMov("reloj").ToString.Trim & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and concepto='" & concepDiasPag & "'", "NOMINA")
                    If (Not dtDiasPagados.Columns.Contains("Error") And dtDiasPagados.Rows.Count > 0) Then
                        Try : montoDiasPag = dtDiasPagados.Rows(0).Item("MONTO").ToString.Trim : Catch ex As Exception : montoDiasPag = dias_pag_default : End Try
                    Else
                        montoDiasPag = dias_pag_default
                    End If

                    '---Validar que los dias pagados sean mayor a cero 2022-11-29
                    Dim numdiaspagados As Double = 0.0
                    Try : numdiaspagados = Double.Parse(montoDiasPag) : Catch ex As Exception : numdiaspagados = 1 : End Try
                    If numdiaspagados <= 1 Then montoDiasPag = "1"

                    '---Si trae decimales, dejarlo  a 7.800 por ejemplo, siempre a 3 digitos
                    If (montoDiasPag.Contains(".")) Then
                        Dim cade1 As String = "", cade2 As String = ""
                        cade1 = montoDiasPag.Split(".")(0)
                        cade2 = montoDiasPag.Split(".")(1).PadRight(3, "0")
                        cade2 = cade2.Substring(0, 3) ' Siempre a 3 dígitos
                        montoDiasPag = cade1 & "." & cade2
                    End If

                    _texto = _texto & montoDiasPag & "|"  '&& Días pagados desde movimientos

                Catch ex As Exception
                    _texto = _texto & montoDiasPag & "|"  '&& Default
                End Try
                '---- ENDS  [numDiasPagados]


                _texto = _texto & EliminaAcentos(dMov("nombre_depto").ToString.ToUpper.Trim) & "|"

                '--- Obtener el codigo del banco de acuerdo al banco que debe de trae el empleado
                Dim nombreBanco As String = ""
                Try : nombreBanco = dMov("BANCO").ToString.Trim.ToUpper : Catch ex As Exception : nombreBanco = "" : End Try

                Select Case nombreBanco
                    Case "BANCOMER"
                        _banco = "012"
                    Case "HSBC"
                        _banco = "021"
                    Case "SANTANDER"
                        _banco = "014"
                    Case "BBVA BANCOMER"
                        _banco = "012"
                    Case Else
                        _banco = ParametrosCFDI.Banco
                End Select


                If dMov("cod_pago_sat") = "03" Then
                    _texto = _texto & dMov("cuenta").ToString.Trim.PadLeft(11, "0") & "|" ' cuenta bancaria
                    _texto = _texto & (_banco) & "|"  '&& CLABE PENDIENTE
                Else
                    _texto = _texto & "|" ' cuenta bancaria
                    _texto = _texto & "|"  '&& CLABE PENDIENTE
                End If

                Dim antigEmpl As String = ""
                Try : antigEmpl = Math.Truncate((DateDiff(DateInterval.Day, dMov("alta"), _fecha_fin) + 1) / 7).ToString.Trim : Catch ex As Exception : antigEmpl = "1" : End Try

                '    _texto = _texto & FechaSQL(dMov("alta")) & "|"
                _texto = _texto & "|" ' Quitamos el Alta en Separación
                _texto = _texto & antigEmpl & "|" ' Antiguedad del empleado
                _texto = _texto & dMov("nombre_puesto").ToString.ToUpper.Trim & "|"
                ' _texto = _texto & "01|"   ' tipo contrato PENDIENTE
                _texto = _texto & "99|" ' Dejamos el 99 en Separación
                _texto = _texto & IIf(dMov("cod_turno") = "2" Or dMov("cod_turno") = "9", "03", IIf(dMov("cod_turno") = "3", "02", "01")) & "|" ' tipo jornada
                _texto = _texto & periodicidad & "|" ' periodicidad 
                _texto = _texto & String.Format("{0:0.00}", dMov("sactual")) & "|"
                '   _texto = _texto & _riesgo_pto & "|"
                _texto = _texto & "|" ' Quitamos Riesgo de puesto en separación
                '  _texto = _texto & String.Format("{0:0.00}", dMov("integrado")) & "|"
                _texto = _texto & "|" ' Quitamos Integrado en Separación
                _texto = _texto & "No|" ' sindicalizado
                _texto = _texto & entidad & "|" ' sindicalizado

                If (dMov("email").ToString.Length > 0 And Not Pruebas) And sbEmail.Value = True Then
                    _texto = _texto & dMov("email").ToString.Trim & "|"
                Else
                    _texto = _texto & "|"
                End If

                _perc_totalgravado = 0
                _perc_totalexento = 0
                _ded_totalgravado = 0
                _ded_totalexento = 0

                _otros_pagos_empleado = 0

                '** PERCEPCIONES
                _textoMov = ""

                'Manejar indemnizaciones
                ' SE INCLUYE EL REGISTRO PARA LOS 3 CONCEPTOS (INDEMN, PRIANT, NOREST)
                Try
                    Dim dtINDEMN As DataTable = dtMovimientosDetalle.Select("concepto in ('INDEMN', 'PRIANT', 'NOREST') AND reloj = '" & dMov("reloj").ToString.Trim & "'").CopyToDataTable
                    If dtINDEMN.Rows.Count > 0 Then
                        Dim dtDatosPersonal As DataTable = sqlExecute("select reloj, sactual, alta, baja from personal where reloj = '" & dMov("reloj") & "' and baja is not null")
                        If dtDatosPersonal.Rows.Count > 0 Then
                            Dim sactual As Double = dtDatosPersonal.Rows(0)("sactual")
                            Dim alta As Date = dtDatosPersonal.Rows(0)("alta")
                            Dim baja As Date = dtDatosPersonal.Rows(0)("baja")
                            Dim antig As Integer = DateDiff(DateInterval.Year, alta, baja) + 1

                            Dim ddetalle As Double = 0

                            For Each row As DataRow In dtINDEMN.Rows
                                ddetalle += row("monto")
                            Next

                            _textoMov = _textoMov & "S01|" & String.Format("{0:0.00}", ddetalle) ' Total pagado
                            _textoMov = _textoMov & "|" & antig ' anios servicio
                            _textoMov = _textoMov & "|" & String.Format("{0:0.00}", sactual * 30.4) ' ultimo sueldo mensual
                            _textoMov = _textoMov & "|" & String.Format("{0:0.00}", 0) ' ingreso acumulable
                            _textoMov = _textoMov & "|" & String.Format("{0:0.00}", 0) ' ingreso no acumulable
                            _textoMov = _textoMov & "|" & vbCrLf
                        End If
                    End If

                Catch ex As Exception

                End Try

                'HABRA UNA EXCEPCION SI EL EMPLEADO NO TIENE OTPs
                Try ' Conceptos para OTP otros pagos (OTP = COD_SAT = 999), van fijos aquí, En la tabla CONCEPTOS ya debe de venir el campo de OTP = 1 refiriendo que es como Otros Pagos
                    Dim dtOTP As DataTable = dtMovimientosDetalle.Select("OTP = 1 AND reloj = '" & dMov("reloj").ToString.Trim & "'", "PRIORIDAD,TIPO_PERCEPCION").CopyToDataTable

                    For Each dDetalle As DataRow In dtOTP.Rows

                        _textoMov = _textoMov & "OTP|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                        _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                        _textoMov = _textoMov & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                        _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto")) & "|"

                        '--- Interface SEPARCION

                        Dim _subsidio_causado As Double = 0
                        Dim _concepto_otp As String = RTrim(dDetalle("concepto").ToString.Trim)

                        Select Case _concepto_otp
                            Case "CREPAG"
                                '   For Each row As DataRow In dtMovimientos.Select("concepto in ('CREFIS') AND reloj = '" & dMov("reloj").ToString.Trim & "'")
                                For Each row As DataRow In dtMovimientos.Select("concepto in ('SUBEMP') AND reloj = '" & dMov("reloj").ToString.Trim & "'")
                                    Try
                                        _subsidio_causado += Double.Parse(row("monto"))
                                    Catch ex As Exception

                                    End Try
                                Next
                                '12/02/2020: AOS - Agregar CREPAG de 0.01 para timbrado
                                If _subsidio_causado = 0 Then
                                    _subsidio_causado = 0.01
                                End If
                                If (_subsidio_causado < 0) Then _subsidio_causado = _subsidio_causado * -1
                                _textoMov = _textoMov & String.Format("{0:0.00}", _subsidio_causado) & "|||"
                        End Select

                        _textoMov = _textoMov & "|" & vbCrLf

                        _otros_pagos_empleado += dDetalle("monto")

                    Next
                Catch ex As Exception

                End Try

                '** DEDUCCIONES NEGATIVAS
                For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'D' AND reloj = '" & dMov("reloj").ToString.Trim & "' and isnull(exento,0) < 0", "PRIORIDAD,TIPO_PERCEPCION")

                    Dim _concepto As String = dDetalle("concepto").ToString.Trim

                    _textoMov = _textoMov & "OTP|" & IIf(_concepto = "ISRCOM", "004", "999") & "|" & _concepto & "|" & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                    _textoMov = _textoMov & String.Format("{0:0.00}", Double.Parse(dDetalle("exento")) * -1) & "|"

                    If _concepto = "ISRCOM" Then
                        _textoMov = _textoMov & "|" & String.Format("{0:0.00}", Double.Parse(dDetalle("exento")) * -1) & "|" & Now.Year - 1 & "|0.00"
                    Else
                        _textoMov = _textoMov & "|||"
                    End If

                    _textoMov = _textoMov & "|" & vbCrLf

                    _otros_pagos_empleado += Double.Parse(dDetalle("exento")) * -1

                Next

                '--Excluir los conceptos que son Otros Pagos (OTP) (Otros pagos con cod_sat = 999 ya que esos no entran al total de percepciones)
                '  For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'P' AND reloj = '" & dMov("reloj").ToString.Trim & "' and concepto not in ('COMVIA')", "PRIORIDAD,TIPO_PERCEPCION")
                For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'P' AND reloj = '" & dMov("reloj").ToString.Trim & "' and ISNULL(OTP,0)=0 and monto>0", "PRIORIDAD,TIPO_PERCEPCION")
                    _textoMov = _textoMov & "P01|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                    _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                    _textoMov = _textoMov & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"
                    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("gravado")) & "|"
                    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("exento")) & "|"

                    'El detalle de la percepción extra se incluye dentro de la misma línea

                    If dDetalle("tipo_percepcion").ToString.Trim = "019" Then
                        _textoMov = _textoMov & "1|" ' && DIAS EN QUE SE PAGA TIEMPO EXTRA
                        If dDetalle("concepto").ToString.Trim = "PEREX2" Then
                            _textoMov = _textoMov & "01|"
                            Dim horas As Integer = Math.Truncate(dMov("horas_dobles"))
                            If horas > 0 Then
                                _textoMov = _textoMov & horas & "|"
                            Else
                                _textoMov = _textoMov & "1|"
                            End If

                        ElseIf dDetalle("concepto").ToString.Trim = "PEREX3" Then
                            _textoMov = _textoMov & "02|"
                            Dim horas As Integer = Math.Truncate(dMov("horas_triples"))
                            If horas > 0 Then
                                _textoMov = _textoMov & horas & "|"
                            Else
                                _textoMov = _textoMov & "1|"
                            End If
                        End If
                        _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto"))
                    Else
                        _textoMov = _textoMov & "|||"
                    End If

                    _textoMov = _textoMov & "|" & vbCrLf

                    _perc_totalgravado += IIf(IsDBNull(dDetalle("gravado")), 0, dDetalle("gravado"))
                    _perc_totalexento += IIf(IsDBNull(dDetalle("exento")), 0, dDetalle("exento"))

                Next

                '** DEDUCCIONES
                For Each dDetalle As DataRow In dtMovimientosDetalle.Select("naturaleza = 'D' AND reloj = '" & dMov("reloj").ToString.Trim & "' and isnull(exento,0) >= 0 ", "PRIORIDAD,TIPO_PERCEPCION")

                    _textoMov = _textoMov & "D01|" & dDetalle("tipo_percepcion").ToString.Trim & "|"
                    _textoMov = _textoMov & dDetalle("concepto").ToString.Trim & "|"
                    _textoMov = _textoMov & EliminaAcentos(dDetalle("descripcion").ToString.Trim).Replace(".", "").Replace("ñ", "n") & "|"


                    '--12/02/2020 AOS: Agregar CREPAG de 0.01 para timbrado
                    If dDetalle("concepto").ToString.Trim = "AJUSUB" Then
                        '   dDetalle("exento") = "0.01"
                        dDetalle("monto") = "0.01"
                    End If

                    _textoMov = _textoMov & String.Format("{0:0.00}", dDetalle("monto")) & "|" & vbCrLf
                    _ded_totalexento += IIf(IsDBNull(dDetalle("monto")), 0, dDetalle("monto"))
                Next

                _textoMov = _textoMov & "F01|" & vbCrLf

                _texto = _texto & String.Format("{0:0.00}", _perc_totalexento + _perc_totalgravado) & "|"
                _texto = _texto & String.Format("{0:0.00}", _ded_totalexento + _ded_totalgravado) & "|"
                '   _texto = _texto & String.Format("{0:0.00}", _otros_pagos_empleado) & "|" & vbCrLf
                _texto = _texto & String.Format("{0:0.00}", _otros_pagos_empleado) & "|"

                ' VERS 4.0 CFDI: Add el CP_SAT del empleado
                Dim cp_sat As String = ""
                Try : cp_sat = dMov("cp_sat").ToString.Trim : Catch ex As Exception : cp_sat = "" : End Try
                _texto = _texto & cp_sat & "|"

                ''--AOS: 04/02/2020: Validar si es retimbrado, para que coloque el UUID CANCELADO
                Dim uuid_canc As String = ""
                Dim KeyEmp As String = AnoPeriodo.ToString.Trim & Rj
                Dim dtRetimb As DataTable = sqlExecute("SELECT UUID from retimbrado where isnull(sep,0)=1 and ano+periodo+reloj='" & KeyEmp & "'", "NOMINA")
                If (Not dtRetimb.Columns.Contains("Error") And dtRetimb.Rows.Count > 0) Then
                    Try : uuid_canc = dtRetimb.Rows(0).Item("UUID").ToString.Trim : Catch ex As Exception : uuid_canc = "" : End Try
                    _texto = _texto & uuid_canc & "|"
                Else
                    _texto = _texto & "|"
                End If

                _texto = _texto & vbCrLf
                ''----ENDS

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

        '************/// RESUMEN FINAL / Generacion de reporte de resumen final / Timbrado

        Dim dtResumen As New DataTable
        Dim dConcepto As DataRow
        dtResumen.Columns.Add("naturaleza")
        dtResumen.Columns.Add("concepto_sat")
        dtResumen.Columns.Add("concepto_pida")
        dtResumen.Columns.Add("descripcion")
        dtResumen.Columns.Add("gravado", System.Type.GetType("System.Double"))
        dtResumen.Columns.Add("exento", System.Type.GetType("System.Double"))
        'Luis campo nuevo
        dtResumen.Columns.Add("periodo")
        dtResumen.PrimaryKey = New DataColumn() {dtResumen.Columns("naturaleza"), dtResumen.Columns("concepto_pida")}


        Try

            SumaDeducciones = 0
            SumaPercepciones = 0
            SumaEmpleados = 0
            SumaOTP = 0

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
                ElseIf Datos(0) = "P01" Or Datos(0) = "D01" Or Datos(0) = "OTP" Then
                    Dim naturaleza As String = IIf(Datos(0) = "P01", "PERCEPCIONES", IIf(Datos(0) = "D01", "DEDUCCIONES", "OTROS PAGOS"))
                    dConcepto = dtResumen.Rows.Find({naturaleza, Datos(2)})
                    If dConcepto Is Nothing Then
                        dConcepto = dtResumen.NewRow
                        dConcepto("naturaleza") = naturaleza
                        dConcepto("concepto_sat") = Datos(1)
                        dConcepto("concepto_pida") = Datos(2)
                        dConcepto("descripcion") = Datos(3)
                        'Luis campo nuevo
                        dConcepto("periodo") = "Periodo " & AnoPeriodo.Substring(4, 2) & " " & AnoPeriodo.Substring(0, 4)

                        If Datos(0) = "P01" Then
                            dConcepto("gravado") = Datos(4)
                            dConcepto("exento") = Datos(5)

                        ElseIf Datos(0) = "D01" Or Datos(0) = "OTP" Then
                            dConcepto("exento") = Datos(4)
                            dConcepto("gravado") = 0

                        End If

                        dtResumen.Rows.Add(dConcepto)
                    Else

                        If Datos(0) = "P01" Then
                            dConcepto("gravado") += Datos(4)
                            dConcepto("exento") += Datos(5)

                        ElseIf Datos(0) = "D01" Or Datos(0) = "OTP" Then
                            dConcepto("exento") += Datos(4)
                            'dConcepto("gravado") += 0

                        End If

                    End If

                    If Datos(0) = "P01" Then
                        SumaPercepciones = SumaPercepciones + Datos(4) + Datos(5)

                    ElseIf Datos(0) = "D01" Then
                        SumaDeducciones = SumaDeducciones + Datos(4)

                    ElseIf Datos(0) = "OTP" Then
                        SumaOTP = SumaOTP + Datos(4)

                    End If
                End If
            Loop
            CompruebaTXT.Close()

            SumaPercepciones = Math.Round(SumaPercepciones, 2)
            SumaDeducciones = Math.Round(SumaDeducciones, 2)

            SumaOTP = Math.Round(SumaOTP, 2)
            _total_otros_pagos = Math.Round(_total_otros_pagos, 2)

            If _total_empleados <> SumaEmpleados Then
                Err.Raise(999, Nothing, "El número de empleados no coincide con el detalle. Favor de revisar. [" & (SumaEmpleados - _total_empleados) & "]")
            ElseIf _total_percepciones <> SumaPercepciones Then
                Err.Raise(999, Nothing, "El acumulado de PERCEPCIONES no coincide con el detalle. Favor de revisar. [" & (SumaPercepciones - _total_percepciones) & "]")
            ElseIf _total_deducciones <> SumaDeducciones Then
                Err.Raise(999, Nothing, "El acumulado de DEDUCCIONES no coincide con el detalle. Favor de revisar. [" & (SumaDeducciones - _total_deducciones) & "]")
            ElseIf _total_otros_pagos <> SumaOTP Then
                Err.Raise(999, Nothing, "El acumulado de OTROS PAGOS no coincide con el detalle. Favor de revisar. [" & (SumaOTP - _total_otros_pagos) & "]")
            End If
            sqlExecute("UPDATE bitacora_timbrados SET comprueba = 1 WHERE fhahoraini = (SELECT max(fhahoraini) FROM bitacora_timbrados)", "nomina")
            Try
                frmVistaPrevia.LlamarReporte("Acumulado CFDI", dtResumen, Parametros.Compania)
                frmVistaPrevia.ShowDialog()

            Catch ex As Exception

            End Try

            Dim _random As Single = 0

            If MessageBox.Show("¿Desea realizar el timbrado de los recibos de conceptos de separación?", "PIDA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                sitimbrar = True
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



                ' Eliminamos el archivo con extension Folios para que lo vuelva a crear
                Try
                    Kill(_pathNom33 & "\" & _serie & ".txt.folios")
                Catch ex As Exception
                End Try

                '---- Aquí es donde ejecuta el programa CD NOM 33 para hacer el timbrado como tal ' cd_nomina40
                '  ss = Shell("cd_nomina33 " & _serie & ".txt " & IIf(Pruebas, "pruebas ", "ws ") & Chr(34) & ParametrosCFDI.DirDestino.Trim & Chr(34), AppWinStyle.Hide, True) ' Vers 3.0 CFDI PRUEBA
                '   ss = Shell("PRUEBAS_cd_nomina40 " & _serie & ".txt " & IIf(Pruebas, "pruebas ", "pruebas ") & Chr(34) & ParametrosCFDI.DirDestino.Trim & Chr(34), AppWinStyle.Hide, True) ' Vers 4.0 CFDI PRUEBA
                ss = Shell("cd_nomina40 " & _serie & ".txt " & IIf(Pruebas, "pruebas2 ", "ws ") & Chr(34) & ParametrosCFDI.DirDestino.Trim & Chr(34), AppWinStyle.Hide, True) ' VERS 4.0 CFDI  a partir del 2024 sera pruebas2 para pruebas

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

                        '--- AOS: Para de separacion que no aplique llenar la tabla de nomina por si hay real
                        '  If Not btnPrueba.Value Then  ' &&_AOS : Se quita para que lo actualice
                        'sqlExecute("UPDATE nomina SET folio_cfdi = '" & Datos(2) & "'," & _
                        '      "fecha_cfdi = '" & Datos(3) & "'," & _
                        '      "certificado_cfdi = '" & Datos(4) & "'," & _
                        '      "ubicacion_archivo_cfdi = '" & UbicacionArchivo & "' " & _
                        '      "WHERE reloj = '" & Datos(1) & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & _
                        '       "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and cod_comp='" & cmbCia.SelectedValue & "'", "nomina")
                        '    End If

                    Loop
                    CompruebaTXT.Close()


                End If
                bgTimbrado.ReportProgress(-2)

            End If


            If (sitimbrar) Then
                Guarda_Act_xmls()  '-----AOS --- -Leer cada uno de los archivos XML's, colocarlos en el path correcto y actualizar tabla de NOMINA.dbo.timbrado
            End If

            '-----ADRIAN ORTEGA (AOS) -- Mandar detalle de los no timbrados en proceso de separación

            Dim QNoTimbSep As String = ""
            If rbLista.Checked Then
                QNoTimbSep = "select ano + '-' + PERIODO as 'Periodo',* from nomina where reloj in('" & lista_relojes() & "') and ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' " & _
                    "and reloj in (" & _
                "select distinct  movimientos.reloj FROM  movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                "WHERE ano+periodo = '" & cmbAnoPeriodo.SelectedValue & "' AND ISNULL(CONCEPTOS.SEP,0)=1 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' " & _
                "and movimientos.reloj not in (select reloj from timbrado where cod_comp='" & cmbCia.SelectedValue & "' and ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and isnull(isr_sep,0)=1)" & _
                ")"
            Else
                '--Todos los empleados
                QNoTimbSep = "select ano + '-' + PERIODO as 'Periodo',* from nomina where ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' " & _
                    "and reloj in (" & _
                "select distinct  movimientos.reloj FROM  movimientos LEFT JOIN conceptos ON movimientos.concepto = conceptos.concepto " & _
                "WHERE ano+periodo = '" & cmbAnoPeriodo.SelectedValue & "' AND ISNULL(CONCEPTOS.SEP,0)=1 and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' " & _
                "and movimientos.reloj not in (select reloj from timbrado where cod_comp='" & cmbCia.SelectedValue & "' and ano+periodo='" & cmbAnoPeriodo.SelectedValue & "' and tipo_periodo='" & cmbTipoPeriodo.SelectedValue & "' and isnull(isr_sep,0)=1)" & _
                ")"
            End If

            dtNoTimbradosSep = sqlExecute(QNoTimbSep, "NOMINA")

            If dtNoTimbradosSep.Rows.Count = 0 Then '------ANTONIO
                MessageBox.Show("El proceso de timbrado de separación concluyó exitosamente." & vbCrLf & vbCrLf & "Puede encontrar los archivos resultantes en " & _
            vbCrLf & "<" & ParametrosCFDI.DirDestino.Trim & ">", "Timbrado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Hubo algunos elementos no timbrados en el proceso de separación." & vbNewLine & "Se mostraran a continuacion los empleados no timbrados ",
                 "Detalle no timbrados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                frmVistaPrevia.LlamarReporte("No Timbrados", dtNoTimbradosSep, Parametros.Compania)
                frmVistaPrevia.ShowDialog()
            End If

            '---- Detalle de los no timbrados en proceso de separación
            Return Nothing


        Catch ex As Exception
            CompruebaTXT.Close()

            If Dir(strFileName).Length > 0 Then
                If MessageBox.Show("Ocurrió un error de comprobación, ¿Desea eliminar el archivo generado hasta el momento?", "Error de comprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    Kill(strFileName)
                End If
            End If

            Return New Exception("Error en comprobación." & vbCrLf & vbCrLf & ex.Message)

        End Try

    End Function
End Class

Public Class FilesTimbrado
    Public FileName As String = ""

    Public sello As String = ""
    Public certificado As String = ""
    Public reloj As String = "" ' reloj  

    Public serie As String = ""
    Public cod_comp As String = ""
    Public ano As String = ""
    Public periodo As String = ""

    Public selloCFD As String = "" ' Sello Digital del SAT
    Public selloSat As String = "" ' Sello Digital del SAT

    Public UUID As String = "" ' Folio Fiscal
    Public noCertificadoSAT As String = "" ' No. Serie de Certificado de Sello Digital del SAT
    Public FechaTimbrado As String = ""

    Public rfcEmisor As String = ""
    Public rfcReceptor As String = ""
    Public total As String

    Public tipo_periodo_t As String = ""

    Public FechaPago As String

    'Jose Hdez 2019-ENE-11
    Public ISR As String = ""

    '--AOS 20/02/2020 - Que agregue si es Isr de Sep
    Public isr_sep As String = ""

End Class