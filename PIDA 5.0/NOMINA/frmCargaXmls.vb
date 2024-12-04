Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Xml

Public Class frmCargaXmls
    Private archivosTimbrado As New ArrayList
    Dim version_Timbrado As String = ""

    Private Sub frmCargaXmls_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnInicCarga_Click(sender As Object, e As EventArgs) Handles btnInicCarga.Click
        '*****-----------Nota: Lo que hace este proceso es leer los xmls y guardar la info en la tabla NOMINA.DBO.TIMBRADO de acuerdo al año, periodo, tipo de periodo, y cia.
        '***** y guarda los xmls, .pdfs y .sat en la ruta del paht-xml donde se guardan con el cliente para ver los recibos ya timbrados.
        Guarda_Act_xmls()
    End Sub

    Private Sub Guarda_Act_xmls()

        CircularProgress4.Value = 0
        CircularProgress4.Maximum = 100

        Dim xmlSource As String = "", xmlDestination As String = "", path_xml As String = "", ano As String = "", tipo_per As String = "", num_per As String = ""
        Dim cod_comp As String = ""

        xmlSource = txtSource.Text.Trim
        If (xmlSource.Substring(xmlSource.Length() - 1) <> "\") Then xmlSource = xmlSource + "\" '**- Valida que el ultimo caracter sea "\" si no, lo agrega
        Dim dtPathTimb As DataTable = sqlExecute("select path_xml from parametros", "PERSONAL")
        If (Not dtPathTimb.Columns.Contains("Error") And dtPathTimb.Rows.Count > 0) Then
            Try : path_xml = dtPathTimb.Rows(0).Item("path_xml").ToString.Trim : Catch ex As Exception : path_xml = "" : End Try
        End If

        ano = txtAno.Text.Trim
        tipo_per = txtTipoPeriodo.Text.Trim
        num_per = txtPeriodo.Text.Trim
        version_Timbrado = txtVersion.Text.Trim


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
        cod_comp = txtCodComp.Text.Trim
        Dim contador As Integer = 0


        Try


            For Each archivo As FilesTimbrado In archivosTimbrado

                contador += 1
                CircularProgress4.Value = Math.Round((100 / archivosTimbrado.Count()) * contador)
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
                    If version_Timbrado.Contains("4") Then cfdi = "http://www.sat.gob.mx/cfd/4"
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
                _tipo_periodo_ = txtTipoPeriodo.Text.Trim
                Dim dtPers As DataTable = sqlExecute("select reloj,tipo_periodo from nominavw where reloj='" & archivo.reloj & "' and cod_comp='" & cod_comp & "' and tipo_periodo='" & _tipo_periodo_ & "' and ano+periodo='" & ano & num_per & "'", "NOMINA")
                If (Not dtPers.Columns.Contains("Error") And dtPers.Rows.Count > 0) Then
                    Try : _tipo_periodo_ = dtPers.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : _tipo_periodo_ = "" : End Try
                Else
                    insertarTimb = False
                End If

                If Not insertarTimb Then GoTo sigRec ' Si no encontró al empleado que no lo inserte y continue con el sig registro

                Dim dtExiste As DataTable = sqlExecute("SELECT * from timbrado where cod_comp='" & cod_comp & "' and ano+periodo='" & ano & num_per & "' and reloj='" & archivo.reloj & "'  and tipo_periodo='" & _tipo_periodo_ & "' and isnull(isr_sep,0)=" & archivo.isr_sep, "NOMINA")
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

                    '---Obtener nombre de archivo para guardar el path de los XML
                    '  Dim UltCar As String = txtPathXml.Text.Substring(txtPathXml.Text.Length() - 1)
                    '    If (UltCar.Trim <> "\") Then UltCar = "\"

                    Dim xmlNombre As String = archivo.FileName.Trim.Split("\").Last()
                    Dim PathXml As String = xmlDestination & xmlNombre

                    '-- Añadir que tipo de version es apartir de la version 4.0 CFDI
                    Dim _version As String = ""
                    If version_Timbrado.Contains("4") Then _version = "4.0" Else _version = "3.3"


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
        "ISR ='" & archivo.ISR & "',version='" & _version & "' where cod_comp='" & cod_comp & "' and reloj = '" & archivo.reloj & "' and ano = '" & archivo.ano & "' and periodo = '" & archivo.periodo & "' and tipo_periodo = '" & tipo_per & "' and isr_sep=" & archivo.isr_sep

                    sqlExecute(QUpT, "nomina")
                End If

sigRec:
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            CircularProgress4.Visible = False
            MessageBox.Show("Hubo un error en la carga de los xmls, favor de revisar log de errores", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        CircularProgress4.Visible = False
        MessageBox.Show("Proceso de carga de xmls concluyó satisfactoriamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Me.Close()
    End Sub
End Class