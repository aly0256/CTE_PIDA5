Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Xml

Public Class frmValidaTimbradoTabla

    Dim _anio As Integer = 0
    Private archivosTimbrado As New ArrayList
    Dim _xmlSource As String = "", _xmlDestination As String = "", _path_xml As String = "", _ano As String = "", _tipoPer As String = "", _numPer As String = ""
    Dim _codComp As String = ""
    Dim actualizados As Integer = 0 : Dim sinIngresar As Integer = 0
    Dim relojesTimbrados As New ArrayList
    Dim resumenInfoTimb As New ArrayList
    Dim paramCriterios As New ArrayList

    Dim a As String = ""
    Dim c As String = ""
    Dim t As String = ""
    Dim strFiltro As String = ""

    Dim infoValidada As Boolean
    Dim msjSinRuta As Boolean = True
    Dim filtroUsado As String = ""

    Dim dispFiltro As Boolean = False

    Dim conceptosExistentesXML As New ArrayList
    Dim ingresaTblDet As Integer = 0
    Dim contDet As Integer = 0
    Dim llavePrincipal As String = ""


    Private Sub frmValidaTimbradoTabla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            EstadoIinicialControles()
            LimpiarPantalla()
            txtRuta.Focus()
        Catch ex As Exception
        End Try
    End Sub

    '== Cargar información en comboboxes
    Private Sub CargaCombos()
        Try
            Dim qry As String = ""

            '== Años
            Dim fecha_Actual As Date = Date.Now
            _anio = fecha_Actual.Year
            For i As Integer = _anio To _anio - 1 Step -1
                cmbAño.Items.Add(i.ToString)
            Next

            qry = "select * from PERSONAL.dbo.tipo_periodo"
            Dim dtPeriodos As DataTable = sqlExecute(qry)
            If dtPeriodos.Rows.Count > 0 Then
                For Each drow As DataRow In dtPeriodos.Rows
                    cmbTipoPer.Items.Add(drow.Item("tipo_periodo").ToString.Trim)
                Next
            End If

            '== Compañia
            qry = "SELECT cod_comp,nombre FROM PERSONAL.dbo.cias ORDER BY cia_default DESC,cod_comp"
            Dim dtCias As DataTable = sqlExecute(qry)
            If dtCias.Rows.Count > 0 Then
                For Each row As DataRow In dtCias.Rows
                    cmbCias.Items.Add(row.Item("cod_comp").ToString.Trim)
                Next
            End If

            '== Criterios adicionales de validación
            '== Todos los posibles criterios de validación para un archivo XML
            qry = "SELECT COLUMN_NAME AS name FROM Nomina.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='timbrado'"
            Dim dtCriterios As DataTable = sqlExecute(qry)

            If dtCriterios.Rows.Count > 0 Then
                For Each x As DataRow In dtCriterios.Rows
                    If Not x.Item("name").ToString = "ano" And Not x.Item("name").ToString = "periodo" And Not x.Item("name").ToString = "reloj" And
                        Not x.Item("name").ToString = "cod_comp" And Not x.Item("name").ToString = "tipo_periodo" And Not x.Item("name").ToString = "xml" And
                        Not x.Item("name").ToString = "isr_sep" And Not x.Item("name").ToString = "ISR" Then
                        cmbCriterios.Items.Add(x.Item("name").ToString.ToUpper)
                    End If
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    '== Se valida la información del panel izquierdo
    Private Function ValidacionInfo() As Boolean
        Try
            '== Reinicia arreglos de archivos de timbrado
            archivosTimbrado.Clear()
            relojesTimbrados.Clear()
            resumenInfoTimb.Clear()
            conceptosExistentesXML.Clear()
            listXML.Items.Clear()
            btnResumen.Enabled = False

            '== La ruta donde se tomarán los XMLs (será especificada por el usuario)
            _xmlSource = txtRuta.Text
            Try : _tipoPer = cmbTipoPer.SelectedItem.ToString.Trim : Catch ex As Exception : _tipoPer = "" : End Try
            Try : _ano = cmbAño.SelectedItem.ToString.Trim : Catch ex As Exception : _ano = "" : End Try
            Try : _numPer = cmbPeriodos.SelectedItem.ToString.Trim : Catch ex As Exception : _numPer = "" : End Try
            Try : _codComp = cmbCias.SelectedItem.ToString.Trim : Catch ex As Exception : _codComp = "" : End Try

            '== Si falta información, salir de proceso
            If _xmlSource = "" Or _ano = "" Or _tipoPer = "" Or _numPer = "" Or _codComp = "" Then
                MessageBox.Show("Por favor, complete la información requerida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btnAceptar.Enabled = False
                txtRuta.Focus()
                Return False
            Else

                '== Se revisa cuantos archivos XMLs se encuentran en la ruta y se compara con la cantidad de registros de la BD
                '== Se modificó de la versión original (solo para saber cual es la ruta del path)
                Dim QryRegistros As String = "" : Dim dtNoTimbrados As New DataTable

                For Each archivos As String In My.Computer.FileSystem.GetFiles(_xmlSource, FileIO.SearchOption.SearchTopLevelOnly, "*.xml")
                    Dim xmlName As String = ""
                    xmlName = archivos.Trim.Split("\").Last()

                    '== Guardar la info del XML en una estructura y que con esta actualice la tabla de timbrado
                    Dim archivo As New FilesTimbrado
                    archivo.FileName = _xmlSource & xmlName
                    If Path.GetExtension(archivo.FileName).Equals(".xml") Then
                        archivosTimbrado.Add(archivo)
                    End If
                Next

                '== No. de registros para los parametros introducidos por el usuario
                QryRegistros = "SELECT * FROM NOMINA.dbo.timbrado WHERE ano+periodo='" & _ano + _numPer & "' AND cod_comp='" & _codComp & "' AND tipo_periodo='" & _tipoPer & "'"
                dtNoTimbrados = sqlExecute(QryRegistros)

                '== XMLs y registros de la tabla timbrado
                Dim noXML As Integer = archivosTimbrado.Count : Dim noReg As Integer = dtNoTimbrados.Rows.Count

                '== Llenar listas de XML y registros
                Dim nomDoc As String = ""
                Dim relojDoc As String = ""
                Dim regDoc As String = ""
                Dim selloDoc As String = ""
                Dim flag As Integer = 1
                pbEstatus.Value = 0
                pbEstatus.Maximum = 100

                '== Info del xml
                Dim infoXML As New ArrayList

                For Each docTimbrado As FilesTimbrado In archivosTimbrado

                    Dim doc As XDocument = XDocument.Load(docTimbrado.FileName)
                    Dim cfdi As XNamespace = "http://www.sat.gob.mx/cfd/3"
                    Dim nomina12 As XNamespace = "http://www.sat.gob.mx/nomina12"
                    Dim tfd As XNamespace = "http://www.sat.gob.mx/TimbreFiscalDigital"
                    nomDoc = docTimbrado.FileName.Trim.Split("\").Last()
                    relojDoc = doc.Descendants(nomina12 + "Receptor").First.Attribute("NumEmpleado").Value

                    '== Info principal
                    docTimbrado.sello = doc.Element(cfdi + "Comprobante").Attribute("Sello").Value : infoXML.Add("[1]_" & docTimbrado.sello)
                    docTimbrado.certificado = doc.Element(cfdi + "Comprobante").Attribute("Certificado").Value : infoXML.Add("[2]_" & docTimbrado.certificado)
                    docTimbrado.serie = doc.Element(cfdi + "Comprobante").Attribute("Serie").Value : infoXML.Add("[3]_" & docTimbrado.serie)
                    docTimbrado.total = doc.Element(cfdi + "Comprobante").Attribute("Total").Value.PadLeft(17, "0") : infoXML.Add("[4]_" & docTimbrado.total)
                    docTimbrado.rfcEmisor = doc.Descendants(cfdi + "Emisor").First.Attribute("Rfc").Value : infoXML.Add("[5]_" & docTimbrado.rfcEmisor)
                    docTimbrado.rfcReceptor = doc.Descendants(cfdi + "Receptor").First.Attribute("Rfc").Value : infoXML.Add("[6]_" & docTimbrado.rfcReceptor)
                    docTimbrado.FechaPago = doc.Descendants(nomina12 + "Nomina").First.Attribute("FechaPago").Value : infoXML.Add("[7]_" & docTimbrado.FechaPago)
                    docTimbrado.UUID = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("UUID").Value : infoXML.Add("[8]_" & docTimbrado.UUID)
                    docTimbrado.FechaTimbrado = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("FechaTimbrado").Value : infoXML.Add("[9]_" & docTimbrado.FechaTimbrado)
                    docTimbrado.selloCFD = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("SelloCFD").Value : infoXML.Add("[10]_" & docTimbrado.selloCFD)
                    docTimbrado.noCertificadoSAT = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("NoCertificadoSAT").Value : infoXML.Add("[11]_" & docTimbrado.noCertificadoSAT)
                    docTimbrado.selloSat = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("SelloSAT").Value : infoXML.Add("[12]_" & docTimbrado.selloSat)
                    '==

                    regDoc = relojDoc & " - " & _ano + _numPer & " - " & _tipoPer & " - " & _codComp
                    Dim filtro As String = CriteriosAdicionalesValidacion(infoXML, relojDoc)

                    '== En base a los filtros seleccionados en el panel izquierdo, se busca información que coincida en la tabla timbrado
                    '== 'sinFiltro'. Para meter cualquier registro sin importar si existe o no.
                    If dispFiltro Then
                        For Each timb As DataRow In dtNoTimbrados.Select(filtro)
                            listXML.Items.Add(regDoc)
                            relojesTimbrados.Add(relojDoc)
                            resumenInfoTimb.Add(relojDoc & "," & _ano + _numPer & "," & _tipoPer & "," & "Tabla timbrado. No ingresado, ya existe el reloj en la tabla." & "," & docTimbrado.FileName.Trim.Split("\").Last())
                            sinIngresar += 1
                            Exit For
                        Next
                    End If

                    flag += 1
                    lblEstatus.Text = "Validando Reloj: " & relojDoc
                    pbEstatus.Value = Math.Round((100 / archivosTimbrado.Count) * flag)

                    '== Limpia arreglo de infoXML para tener solo la información de un XML
                    infoXML.Clear()

                    Application.DoEvents()
                Next

                lblCoincidencias.Text = listXML.Items.Count
                btnAceptar.Enabled = True
                lblNoXML.Text = noXML.ToString
                lblNoReg.Text = noReg.ToString
                lblNoCoincide.Text = (CInt(lblNoXML.Text) - relojesTimbrados.Count).ToString
                lblEstatus.Text = "Listo"

                If dispFiltro Then
                    filtroUsado = IIf(txtCriterio.Text = "", "RELOJ", "RELOJ," & txtCriterio.Text)
                    lblFiltroApp.Text = "- Filtro aplicado : " & IIf(txtCriterio.Text = "", "RELOJ", "RELOJ," & txtCriterio.Text) & " -"
                Else
                    filtroUsado = "SIN FILTRO"
                    lblFiltroApp.Text = "- Filtro aplicado : SIN FILTRO -"
                End If

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    '== Conceptos para los criterios del filtro
    Private Function CriteriosAdicionalesValidacion(informacionXML As ArrayList, reloj As String) As String
        Try

            Dim filtro As String = "" : Dim pos As String = ""
            If txtCriterio.Text = "" Then
                filtro = "reloj='" & reloj & "'"
            Else
                filtro = "reloj='" & reloj & "' and "
                For Each x As String In paramCriterios
                    Select Case x
                        Case "SELLO"
                            pos = "1"
                        Case "CERTIFICADO"
                            pos = "2"
                        Case "SERIE"
                            pos = "3"
                        Case "TOTAL"
                            pos = "4"
                        Case "EMISOR"
                            pos = "5"
                        Case "RECEPTOR"
                            pos = "6"
                        Case "FECHAPAGO"
                            pos = "7"
                        Case "UUID"
                            pos = "8"
                        Case "FECHATIMBRADO"
                            pos = "9"
                        Case "SELLOCFD"
                            pos = "10"
                        Case "NOCERTIFICADOSAT"
                            pos = "11"
                        Case "SELLOSAT"
                            pos = "12"
                    End Select
                    filtro &= x & "='" & RecorreArreglo(informacionXML, pos) & "',"
                Next

                '== Quita la última coma
                If filtro.Substring(filtro.Length - 1, 1) = "," Then
                    filtro = filtro.Substring(0, filtro.Length - 1)
                End If

                '== Quitar la coma y agregar el 'and' para la sintaxis
                filtro = filtro.Replace(",", " and ")
            End If

            Return filtro
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '== Recorre el arreglo con la información del XML
    Private Function RecorreArreglo(ByVal arreglo As ArrayList, pos As String) As String
        Try
            For Each x As String In arreglo
                Dim val() As String = Split(x, "_")
                If val(0).Contains(pos) Then
                    Return val(1)
                End If
            Next
            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '== Estado inicial de los controles
    Private Sub EstadoIinicialControles()
        Try
            infoValidada = False
            btnAceptar.Enabled = False

            txtRuta.Text = ""

            cmbCias.Items.Clear()
            cmbAño.Items.Clear()
            cmbTipoPer.Items.Clear()
            cmbPeriodos.Items.Clear()
            cmbCriterios.Items.Clear()
            CargaCombos()

            lblNoXML.Text = "--"
            lblNoReg.Text = "--"

            lblEstatus.Text = "Estatus"

            '== Variables
            archivosTimbrado.Clear()
            _xmlSource = ""
            _xmlDestination = ""
            _path_xml = ""
            _ano = ""
            _tipoPer = ""
            _numPer = ""
            _codComp = ""

            lblCoincidencias.Text = "--"
            lblNoCoincide.Text = "--"
            listXML.Items.Clear()

            a = ""
            c = ""
            t = ""
            strFiltro = ""

            lblFiltroApp.Text = "- Filtro aplicado: <> -"
            txtCriterio.Text = ""
            paramCriterios.Clear()

            msjSinRuta = True

            chkFiltro.CheckValue = False
            dispFiltro = False

            lblNoTimb.Text = "--"
            lblNoDet.Text = "--"
            contDet = 0

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try : InsertaTablaTimbrado() : Catch ex As Exception : End Try
    End Sub

    '== Función modificada de timbrado para que ingrese la nueva información obtenida del XML a la tabla timbrado
    Private Sub InsertaTablaTimbrado()

        Try
            Dim restantes As Integer = CInt(lblNoXML.Text) - relojesTimbrados.Count
            Dim contador As Integer = 1
            btnResumen.Enabled = False
            actualizados = 0
            sinIngresar = 0
            pbEstatus.Value = 0
            pbEstatus.Maximum = 100

            '== Llave principal para identificar registros
            llavePrincipal = _codComp & "," & _ano & "," & _numPer & "," & _tipoPer

            '== Si la cantidad de restantes es menor que 0, entonces salir
            If restantes > 0 Then

                If (MessageBox.Show("¿Desea ingresar la información de " & restantes & " XML(s) restante(s) a la tabla de 'Timbrado'?",
                                     "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) And infoValidada Then

                    For Each archivo As FilesTimbrado In archivosTimbrado

                        Dim doc As XDocument = XDocument.Load(archivo.FileName)
                        Dim cfdi As XNamespace = "http://www.sat.gob.mx/cfd/3"
                        Dim nomina12 As XNamespace = "http://www.sat.gob.mx/nomina12"
                        Dim tfd As XNamespace = "http://www.sat.gob.mx/TimbreFiscalDigital"
                        archivo.sello = doc.Element(cfdi + "Comprobante").Attribute("Sello").Value
                        archivo.certificado = doc.Element(cfdi + "Comprobante").Attribute("Certificado").Value
                        archivo.serie = doc.Element(cfdi + "Comprobante").Attribute("Serie").Value
                        archivo.total = doc.Element(cfdi + "Comprobante").Attribute("Total").Value.PadLeft(17, "0")
                        archivo.rfcEmisor = doc.Descendants(cfdi + "Emisor").First.Attribute("Rfc").Value
                        archivo.rfcReceptor = doc.Descendants(cfdi + "Receptor").First.Attribute("Rfc").Value
                        archivo.FechaPago = doc.Descendants(nomina12 + "Nomina").First.Attribute("FechaPago").Value
                        archivo.reloj = doc.Descendants(nomina12 + "Receptor").First.Attribute("NumEmpleado").Value
                        archivo.isr_sep = 0

                        If Not relojesTimbrados.Contains(archivo.reloj) Then

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
                                    '== TBC
                                    If (percepcion.Attribute("Clave") = "PRIANT") Then archivo.isr_sep = 1
                                    If (percepcion.Attribute("Clave") = "NOREST") Then archivo.isr_sep = 1
                                    If (percepcion.Attribute("Clave") = "INDEMN") Then archivo.isr_sep = 1
                                    If (percepcion.Attribute("Clave") = "PENSEP") Then archivo.isr_sep = 1
                                    If (percepcion.Attribute("Clave") = "OTRSEP") Then archivo.isr_sep = 1
                                    If (percepcion.Attribute("Clave") = "PAGSEP") Then archivo.isr_sep = 1
                                Next
                            End If

                            archivo.UUID = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("UUID").Value
                            archivo.FechaTimbrado = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("FechaTimbrado").Value
                            archivo.selloCFD = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("SelloCFD").Value
                            archivo.noCertificadoSAT = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("NoCertificadoSAT").Value
                            archivo.selloSat = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("SelloSAT").Value
                            archivo.cod_comp = _codComp
                            archivo.ano = _ano
                            archivo.periodo = _numPer
                            archivo.tipo_periodo_t = _tipoPer

                            '----AOS: 14/05/2021 :: Validar primero si existe dicho registro para insertarlo, en base al tipo de periodo que tiene actualmente

                            Dim varTipoPer As String = _tipoPer
                            Dim insertarTimb As Boolean = True

                            '======================= VALIDACION EN NOMINA ======================= 
                            '== Verifica que el reloj junto con los parametros definidos por el usuario existan en la tabla de nomina. (A pesar de que ya este timbrado por cuestiones extras de validación de info)
                            'Dim dtPers As DataTable = sqlExecute("select reloj,tipo_periodo from nominavw where reloj='" & archivo.reloj & "' and cod_comp='" & _codComp & _
                            '"' and tipo_periodo='" & varTipoPer & "' and ano+periodo='" & _ano & _numPer & "'", "NOMINA")

                            '== BRP. No existe la columna tipo_periodo
                            'Dim dtPers As DataTable = sqlExecute("select reloj,tipo_periodo from nominavw where reloj='" & archivo.reloj & "' and cod_comp='" & _codComp & _
                            '                                     "' and ano+periodo='" & _ano & _numPer & "'", "NOMINA")

                            'If (Not dtPers.Columns.Contains("Error") And dtPers.Rows.Count > 0) Then
                            '    Try : varTipoPer = dtPers.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : varTipoPer = "" : End Try

                            '    '== BRP. No existe la columna tipo_periodo
                            '    'Try : varTipoPer = "S" : Catch ex As Exception : varTipoPer = "" : End Try
                            'Else
                            '    insertarTimb = False
                            '    sinIngresar += 1
                            '    'resumenInfoTimb.Add(archivo.reloj & "," & _ano + _numPer & "," & _tipoPer & "," & "No ingresado. No hay registro del empleado en nomina con los datos del XML." & "," & archivo.FileName.Trim.Split("\").Last())
                            'End If
                            '======================= FIN NOMINA =======================

                            '== Si existe en nomina y si no fue registrado en la tabla de Timbrado previamente
                            If insertarTimb Then
                                '== Establecer la ruta del XML (de acuerdo a los parametros introducidos por el usuario)
                                Dim PathXml As String = ""
                                Dim dtParametros As DataTable = sqlExecute("SELECT RTRIM(path_xml) as path_xml FROM PERSONAL.dbo.parametros")
                                If dtParametros.Rows.Count > 0 Then
                                    PathXml = IIf(IsDBNull(dtParametros.Rows(0)("path_xml")), "", dtParametros.Rows(0)("path_xml").ToString)
                                    If PathXml = "" Then
                                        '== Mostrar mensaje de aviso una sola vez
                                        If msjSinRuta Then
                                            MessageBox.Show("No existe una ruta definida para los XML en los parámetros de la BD. Por favor, contacte al administrador.", "Error",
                                                                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            msjSinRuta = False
                                        End If
                                        resumenInfoTimb.Add(archivo.reloj & "," & _ano + _numPer & "," & _tipoPer & "," & "No ingresado. No hay ruta para XMLs en los registros de la BD." & "," & archivo.FileName.Trim.Split("\").Last())
                                        sinIngresar += 1
                                        Continue For
                                    Else
                                        '== Para Wollsdorf y tbc
                                        Dim xmlNombre As String = archivo.FileName.Trim.Split("\").Last()
                                        PathXml &= _ano & "\" & _tipoPer & "\" & _numPer & "\" & xmlNombre
                                    End If
                                End If

                                '== Si hay filtro, que elimine los viejos registros para insertar los nuevos. En caso contrario, respetar los que ya existen
                                If Not dispFiltro Then
                                    Dim qDelXml As String = ""
                                    qDelXml = "delete from timbrado where ano+periodo='" & _ano & _numPer & "' and reloj='" & archivo.reloj & _
                                        "' and cod_comp='" & _codComp & "' and tipo_periodo='" & _tipoPer & "' AND isnull(isr_sep,0)=" & archivo.isr_sep
                                    sqlExecute(qDelXml, "NOMINA")
                                End If

                                Dim QInsert As String = "insert into timbrado (cod_comp, reloj, ano, periodo, tipo_periodo,isr_sep) values ('" & _codComp & "','" & archivo.reloj & _
                                    "', '" & _ano & "', '" & _numPer & "', '" & _tipoPer & "', " & archivo.isr_sep & ")"
                                sqlExecute(QInsert, "nomina")

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
                                        "ISR ='" & archivo.ISR & "' where cod_comp='" & _codComp & "' and reloj = '" & archivo.reloj & _
                                         "' and ano = '" & archivo.ano & "' and periodo = '" & archivo.periodo & "' and tipo_periodo = '" & _tipoPer & "' and isr_sep=" & archivo.isr_sep

                                sqlExecute(QUpT, "nomina")

                                '== Se ingresan los conceptos en la tabla de 'detalle_timb_empl'
                                Dim claveRegistro() As String = {_codComp, _ano, _numPer, _tipoPer, archivo.isr_sep}
                                InsertaTablaDetalleEmpTimb(archivo, doc, nomina12, cfdi, claveRegistro, actualizados, sinIngresar)

                                '== Para el resumen
                                'resumenInfoTimb.Add(archivo.reloj & "," & _ano + _numPer & "," & _tipoPer & "," & "Tabla timbrado: Registro agregado correctamente" & "," & archivo.FileName.Trim.Split("\").Last())
                                'actualizados += 1
                            End If
                            contador += 1
                            lblEstatus.Text = "Reloj: " & archivo.reloj & "  Año y periodo: " & archivo.ano + archivo.periodo & "  Tipo periodo: " & _tipoPer
                            pbEstatus.Value = Math.Round((100 / restantes) * contador)
                            Application.DoEvents()

                        End If
sigRec:
                    Next

                    ingresaTblDet = conceptosExistentesXML.Count

                    Dim exito As String = IIf(actualizados = 1, "Se ha insertado 1 registro con éxito", "Se han insertado " & actualizados & " registros con éxito a la tabla de 'Timbrado' junto a " &
                                                                                                                                                          ingresaTblDet & " registro(s) a la tabla de 'Detalle timbrado'.")
                    Dim fail As String = "No se lograron insertar los registros restantes [" & restantes & "]. Por favor, revise el resumen para más información."
                    Dim msjFinal As String = IIf(actualizados = 0, fail, exito)

                    MessageBox.Show(msjFinal, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnResumen.Enabled = True
                    EstadoIinicialControles()
                End If
            Else
                MessageBox.Show("Sin información actualizada que agregar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub

    '== Función para ingresar información a la tabla 'detalle_timb_empl'
    Private Sub InsertaTablaDetalleEmpTimb(ByVal datos As FilesTimbrado, ByVal archivo As XDocument, nomina12 As XNamespace, cfdi As XNamespace,
                                                                       claveReg() As String, ByRef ingresado As Integer, ByRef noIngresado As Integer)
        Try
            '== Se comprueba que el registro del reloj timbrado exista en la tabla timbrado, si no, entonces salir de esta función
            Dim QryComprueba As String = "SELECT * FROM NOMINA.dbo.timbrado WHERE reloj='" & datos.reloj & "' AND cod_comp='" & claveReg(0) & "' " & _
                                                                 "AND ano+periodo='" & claveReg(1) + claveReg(2) & "' AND tipo_periodo='" & claveReg(3) & "' AND isr_sep='" & claveReg(4) & "'"

            Dim dtComprobar As DataTable = sqlExecute(QryComprueba)

            '== Se agregan las incidencias en un arreglo
            If dtComprobar.Rows.Count = 0 Then
                resumenInfoTimb.Add(datos.reloj & "," & claveReg(1) + claveReg(2) & "," & claveReg(3) & "," & "Tabla Timbrado. No ingresado, error al momento del ingreso. (SQL)" & "," & datos.FileName.Trim.Split("\").Last())
                noIngresado += 1
                Exit Sub
            Else
                resumenInfoTimb.Add(datos.reloj & "," & claveReg(1) + claveReg(2) & "," & claveReg(3) & "," & "Tabla Timbrado. Registro ingresado correctamente." & "," & datos.FileName.Trim.Split("\").Last())
                ingresado += 1
                lblNoTimb.Text = ingresado
            End If

            '== Se eliminan todos los registros de la tabla 'detalle timbrado' para agregar la información actualizada
            sqlExecute("delete from NOMINA.dbo.detalle_timb_empl where cod_comp='" & claveReg(0) & "' and ano+periodo='" &
                              claveReg(1) + claveReg(2) & "' and reloj='" & datos.reloj & "' and isnull(isr_sep,0)=" & claveReg(4) & " and tipo_periodo='" & claveReg(3) & "'")

            '== Si se borraron con éxito, proceder a meter la nueva información
            Dim dtExBorro As DataTable = sqlExecute("SELECT * FROM NOMINA.dbo.detalle_timb_empl WHERE reloj='" & datos.reloj & "' " & _
                                                                                 "and cod_comp='" & claveReg(0) & "' and ano+periodo='" & claveReg(1) + claveReg(2) & _
                                                                                 "' and tipo_periodo='" & claveReg(3) & "' and isnull(isr_sep,0)=" & claveReg(4) & "")

            If dtExBorro.Rows.Count = 0 Then
                '== Si el registro existe, entonces proceder a llenar la información en la tabla 'detalle_timb_empl'
                Dim naturalezas() As String = {"Percepciones,Percepcion", "Deducciones,Deduccion", "OtrosPagos,OtroPago"}
                Dim QryInsert As String = "INSERT INTO NOMINA.DBO.detalle_timb_empl VALUES " & _
                                                            "('" & claveReg(0) & "','" & _
                                                                      claveReg(1) & "','" & _
                                                                      claveReg(2) & "'," & _
                                                                    "'[fini]'," & _
                                                                    "'[ffin]','" & _
                                                                     claveReg(3) & "','" & _
                                                                     datos.reloj & _
                                                                     "','[nombres]','" & _
                                                                     datos.rfcReceptor & _
                                                                     "','[sueldo]'," & _
                                                                     "'[integrado]','" & _
                                                                     datos.total & _
                                                                     "','[naturaleza]'," & _
                                                                     "'[cod_sat]'," & _
                                                                     "'[cod_pida]'," & _
                                                                     "'[descripcion]','" & _
                                                                     datos.rfcEmisor & _
                                                                     "',[gravado]," & _
                                                                     "[exento]," & _
                                                                     "[monto],'" & _
                                                                     datos.FechaPago & _
                                                                     "','" & datos.FechaTimbrado & _
                                                                     "','" & datos.UUID & _
                                                                     "','[grupo]','" & _
                                                                     claveReg(4) & "')"

                Dim QryTemp As String = QryInsert

                '== Información fija
                Dim finiXML As String = archivo.Descendants(nomina12 + "Nomina").First.Attribute("FechaInicialPago").Value
                Dim ffinXML As String = archivo.Descendants(nomina12 + "Nomina").First.Attribute("FechaFinalPago").Value
                Dim nombresXML As String = archivo.Descendants(cfdi + "Receptor").First.Attribute("Nombre").Value

                Dim sueldoXML As String = ""
                Try : sueldoXML = archivo.Descendants(nomina12 + "Receptor").First.Attribute("SalarioBaseCotApor").Value : Catch ex As Exception : sueldoXML = "0.0" : End Try

                Dim integradoXML As String = ""
                Try : integradoXML = archivo.Descendants(nomina12 + "Receptor").First.Attribute("SalarioDiarioIntegrado").Value : Catch ex As Exception : integradoXML = "0.0" : End Try

                '== Recorreo el xml para obtener los conceptos
                For Each natArreglo As String In naturalezas
                    Dim natXML() As String = Split(natArreglo, ",")

                    If archivo.Descendants(nomina12 + natXML(0)).Count > 0 Then
                        Dim natVar = archivo.Descendants(nomina12 + natXML(0)).Descendants(nomina12 + natXML(1))
                        For Each concepto In natVar

                            Dim naturalezaXML As String = IIf(natXML(0) = "OtrosPagos", "OTROS PAGOS", natXML(0).ToUpper)
                            Dim codSatXML As String = concepto.Attribute("Tipo" & natXML(1))
                            Dim codPidaXML As String = concepto.Attribute("Clave")
                            Dim descripcionXML As String = concepto.Attribute("Concepto")
                            Dim gravadoXML As Double = 0.0 : If naturalezaXML = "PERCEPCIONES" Then gravadoXML = CDbl(concepto.Attribute("ImporteGravado"))
                            Dim exentoXML As Double = 0.0 : If naturalezaXML = "PERCEPCIONES" Then exentoXML = CDbl(concepto.Attribute("ImporteExento")) Else exentoXML = CDbl(concepto.Attribute("Importe"))
                            Dim montoXML As Double = Math.Round(gravadoXML + exentoXML, 2)
                            Dim grupoXML As String = IIf(natXML(0) = "Percepciones", "1", IIf(natXML(0) = "OtrosPagos", "2", "3"))

                            '== Reemplazar en cadena
                            QryInsert = QryInsert.Replace("[fini]", finiXML)
                            QryInsert = QryInsert.Replace("[ffin]", ffinXML)
                            QryInsert = QryInsert.Replace("[nombres]", nombresXML)
                            QryInsert = QryInsert.Replace("[sueldo]", sueldoXML)
                            QryInsert = QryInsert.Replace("[integrado]", integradoXML)
                            QryInsert = QryInsert.Replace("[naturaleza]", naturalezaXML)
                            QryInsert = QryInsert.Replace("[cod_sat]", codSatXML)
                            QryInsert = QryInsert.Replace("[cod_pida]", codPidaXML)
                            QryInsert = QryInsert.Replace("[descripcion]", descripcionXML)
                            QryInsert = QryInsert.Replace("[gravado]", gravadoXML)
                            QryInsert = QryInsert.Replace("[exento]", exentoXML)
                            QryInsert = QryInsert.Replace("[monto]", montoXML)
                            QryInsert = QryInsert.Replace("[grupo]", grupoXML)

                            '== Se va guardando en un arreglo todos los conceptos existentes del XML, y posteriormente, se compara con lo que se registró en la BD para ver que no falta alguno.
                            '== Llave de comprobacion: reloj, codcomp, anio+periodo, tipoper, isr_sep, codpida, grupo
                            conceptosExistentesXML.Add(datos.reloj & "," & claveReg(0) & "," & claveReg(1) & claveReg(2) & "," & claveReg(3) & "," & claveReg(4) & "," & codPidaXML & "," & grupoXML)

                            '== Insertar registro
                            sqlExecute(QryInsert)

                            '== Progreso
                            contDet += 1
                            lblNoDet.Text = contDet

                            '== Reestablecer query
                            QryInsert = QryTemp
                        Next
                    End If
                Next
            End If

        Catch ex As Exception : End Try
    End Sub

    '== Función para validar que se ingresó correctamente un registro a la tabla 'detalle_timb_empl'
    Private Function ValidaIngresosTablaDetalleTimb(ByVal existen As ArrayList) As Integer
        Try
            'llavePrincipal = _codComp & "," & _ano & "," & _numPer & "," & _tipoPer
            Dim llave() As String = Split(llavePrincipal, ",")
            Dim contRegistros As Integer = 0
            Dim contProg As Integer = 0

            Dim Qry As String = "SELECT * FROM NOMINA.dbo.detalle_timb_empl WHERE cod_comp='" & llave(0) & "' and ano+periodo='" & llave(1) & llave(2) & "' and tipo_periodo='" & llave(3) & "' "
            Dim dtDetTimb As DataTable = sqlExecute(Qry)

            If dtDetTimb.Rows.Count > 0 Then
                For Each datos As String In existen
                    Dim info() As String = Split(datos, ",")
                    Dim filtrVar As String = "reloj='" & info(0) & "' and cod_comp='" & info(1) & "' and ano+periodo='" & info(2) & "' " & _
                                                            "and tipo_periodo='" & info(3) & "' and isr_sep='" & info(4) & "' and cod_pida='" & info(5) & "' and grupo='" & info(6) & "'"

                    For Each row As DataRow In dtDetTimb.Select(filtrVar)
                        contRegistros += 1
                    Next

                    contProg += 1
                    lblEstatus.Text = "Validando registros detalle timb. Reloj: " & info(0)
                    pbEstatus.Value = Math.Round((100 / ingresaTblDet) * contProg)
                    Application.DoEvents()
                Next
            End If

            Return contRegistros
        Catch ex As Exception
        End Try
    End Function

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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    '== Valida la información del panel izquierdo
    Private Sub btnValida_Click(sender As Object, e As EventArgs) Handles btnValida.Click
        Try : infoValidada = ValidacionInfo() : Catch ex As Exception : End Try
    End Sub

    '== Archivo txt de resumen
    Private Sub btnResumen_Click(sender As Object, e As EventArgs) Handles btnResumen.Click
        Try
            Dim registrosValidados As Integer = ValidaIngresosTablaDetalleTimb(conceptosExistentesXML)

            Dim texto As String = ""
            texto = "No. de registros a la tabla 'Timbrado': " & actualizados & vbNewLine
            texto &= "No. de registros a la tabla de 'DetallesTimbrado': " & registrosValidados & " de " & conceptosExistentesXML.Count & vbNewLine
            texto &= "XMLs no ingresados: " & sinIngresar & vbNewLine
            texto &= "Filtro usado: " & filtroUsado & vbNewLine
            texto &= "****************************************************************************************************************************" & vbNewLine

            For Each elem As String In resumenInfoTimb
                Dim arreglo() As String = Split(elem, ",")
                texto &= "Reloj: " & arreglo(0) & "   Año y periodo: " & arreglo(1) & "   Tipo de periodo: " & arreglo(2) & vbNewLine
                texto &= "Estatus: " & arreglo(3) & vbNewLine
                texto &= "Archivo XML: " & arreglo(4) & vbNewLine & vbNewLine
            Next

            Dim fbd As New SaveFileDialog
            fbd.DefaultExt = ".txt"
            fbd.FileName = "Resumen actualizacion tabla Timbrado " & FechaSQL(Date.Now)
            fbd.OverwritePrompt = True

            If fbd.ShowDialog() = DialogResult.OK Then
                Dim nomTxt As String = fbd.FileName
                Dim writer As New StreamWriter(nomTxt)
                writer.WriteLine(texto)
                writer.Close()
                MessageBox.Show("Archivo guardado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al generar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '== Directorio de la ruta de los XMLs
    Private Sub btnDir_Click(sender As Object, e As EventArgs) Handles btnDir.Click
        Try
            Dim flb As New FolderBrowserDialog
            flb.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop

            If flb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtRuta.Text = flb.SelectedPath & "\"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LimpiarPantalla()
        Try
            EstadoIinicialControles()
            archivosTimbrado.Clear()
            relojesTimbrados.Clear()
            resumenInfoTimb.Clear()
            paramCriterios.Clear()
            conceptosExistentesXML.Clear()
            btnResumen.Enabled = False
            actualizados = 0
            sinIngresar = 0
            ingresaTblDet = 0
            pbEstatus.Value = 0
            pbEstatus.Maximum = 100
        Catch ex As Exception
        End Try
    End Sub

    '== Se carga el número de periodo en el combobox
    Private Sub CargaPeriodos()
        Try
            '== Limpiar periodos cada vez que cargue de nuevo
            cmbPeriodos.Items.Clear()

            Try : a = cmbAño.SelectedItem.ToString : Catch ex As Exception : a = "" : End Try
            Try : c = cmbCias.SelectedItem.ToString : Catch ex As Exception : c = "" : End Try
            Try : t = cmbTipoPer.SelectedItem.ToString : Catch ex As Exception : t = "" : End Try

            If a = "" Or c = "" Or t = "" Then
                cmbPeriodos.Enabled = False
            Else
                '== Para wollsdorf y TBC
                Dim qry As String = "SELECT DISTINCT PERIODO FROM NOMINA.dbo.nomina " & _
                                                    "WHERE ANO='" & a & "' AND tipo_periodo='" & t & "' and COD_COMP='" & c & "' ORDER BY PERIODO"

                Dim dtPeriodos As DataTable = sqlExecute(qry)
                If dtPeriodos.Rows.Count > 0 Then
                    For Each row As DataRow In dtPeriodos.Rows
                        cmbPeriodos.Items.Add(row.Item("periodo").ToString.Trim)
                    Next
                End If
                cmbPeriodos.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try : LimpiarPantalla() : Catch ex As Exception : End Try
    End Sub

    Private Sub cmbCias_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCias.SelectedValueChanged
        Try : CargaPeriodos() : Catch ex As Exception : End Try
    End Sub

    Private Sub cmbTipoPer_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoPer.SelectedValueChanged
        Try : CargaPeriodos() : Catch ex As Exception : End Try
    End Sub

    Private Sub cmbAño_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAño.SelectedValueChanged
        Try : CargaPeriodos() : Catch ex As Exception : End Try
    End Sub

    Private Sub btnLimpiaCriterio_Click(sender As Object, e As EventArgs) Handles btnLimpiaCriterio.Click
        Try : txtCriterio.Text = "" : paramCriterios.Clear() : Catch ex As Exception : End Try
    End Sub

    '== Agrega criterio al filtro
    Private Sub btnAgrega_Click(sender As Object, e As EventArgs) Handles btnAgrega.Click
        Try
            If Not txtCriterio.Text.Contains(cmbCriterios.SelectedItem.ToString) Then
                If txtCriterio.Text = "" Then
                    strFiltro &= cmbCriterios.SelectedItem.ToString
                Else
                    strFiltro &= "," & cmbCriterios.SelectedItem.ToString
                End If
                paramCriterios.Add(cmbCriterios.SelectedItem.ToString)
                txtCriterio.Text = strFiltro
            End If
        Catch ex As Exception
        End Try
    End Sub

    '== Quitar criterio del filtro
    Private Sub btnQuita_Click(sender As Object, e As EventArgs) Handles btnQuita.Click
        Try
            If strFiltro = Nothing Then strFiltro = ""

            If txtCriterio.Text.Contains(cmbCriterios.SelectedItem.ToString) Then
                If Not txtCriterio.Text = "" Then
                    strFiltro = Replace(strFiltro, cmbCriterios.SelectedItem.ToString, "")
                End If

                If paramCriterios.Contains(cmbCriterios.SelectedItem.ToString) Then
                    paramCriterios.Remove(cmbCriterios.SelectedItem.ToString)
                End If

                '== Quitar comas inexactas
                Try : If strFiltro.Substring(0, 1).Equals(",") Then strFiltro = strFiltro.Substring(1, strFiltro.Length - 1)
                Catch ex As Exception : End Try

                Try : If strFiltro.Substring(strFiltro.Length - 1, 1).Equals(",") Then strFiltro = strFiltro.Substring(0, strFiltro.Length - 1)
                Catch ex As Exception : End Try

                Try : strFiltro = Replace(strFiltro, ",,", ",")
                Catch ex As Exception : End Try

                txtCriterio.Text = strFiltro
            End If
        Catch ex As Exception
        End Try
    End Sub

    '== Inhabilitar filtros
    Private Sub FiltrosDisp(disp As Boolean)
        Try
            cmbCriterios.Enabled = disp
            btnAgrega.Enabled = disp
            btnQuita.Enabled = disp
            btnLimpiaCriterio.Enabled = disp
        Catch ex As Exception : End Try
    End Sub

    Private Sub chkFiltro_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltro.CheckedChanged
        Try
            If (chkFiltro.Checked) Then
                dispFiltro = True
                lblAvisoCrit.Text = "Filtro por default es 'Reloj' aún sin seleccionar otro."
            Else
                dispFiltro = False
                lblAvisoCrit.Text = "Sin filtros aplicados."
            End If

            FiltrosDisp(dispFiltro)
        Catch ex As Exception

        End Try
    End Sub
End Class