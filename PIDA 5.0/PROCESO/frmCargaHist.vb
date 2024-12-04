Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Xml

Public Class frmCargaHist

    Private eliminarinformacionexistente As Boolean = False
    '  Private ValidarNomina As frmValidacionNomina
    Private archivosTimbrado As New ArrayList
    Private archivoGenerales As String
    Private archivoNomina As String

    Private dtPeriodos As DataTable

    Private nombreDelArchivo As String = ""
    Private ubicacionDelArchivo As String = ""
    Private directorioExtraccion As String = ""
    Private dirPathXML As String = ""
    Private cod_comp As String = ""

    Private anoSeleccionado As String = ""
    Private periodoSeleccionado As String = ""


    Private Sub frmCargaHist_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Me.Close()
    End Sub

    Public Class ArchivosTimbCargaHist

        Public FileName As String = ""
        Public ano As String = ""
        Public periodo As String = ""
        Public reloj As String = ""
        Public sactual As String = ""
        Public integrado As String = ""
        Public cuenta As String = ""
        Public concepto As String = ""
        Public monto As String
        Public tipo_periodo As String = ""
        Public TotalOtrosPagos As String = ""
        Public TotalDeducciones As String = ""
        Public TotalPercepciones As String = ""
        Public TotalExento As String = ""
        Public TotalGravado As String = ""

        Public sello As String = ""
        Public certificado As String = ""
        Public serie As String = ""
        Public selloCFD As String = "" ' Sello Digital del SAT
        Public selloSat As String = "" ' Sello Digital del SAT
        Public UUID As String = "" ' Folio Fiscal
        Public noCertificadoSAT As String = "" ' No. Serie de Certificado de Sello Digital del SAT
        Public FechaTimbrado As String = ""
        Public rfcEmisor As String = ""
        Public rfcReceptor As String = ""
        Public total As String
        Public FechaPago As String
        Public ISR As String = ""
        Public isr_sep As String = ""
        Public numdiaspag As String = ""

    End Class

    Private Sub btnCargaXmlHist_Click(sender As Object, e As EventArgs) Handles btnCargaXmlHist.Click
        Try


            'If (txtarchivo.Text.Trim = "") Then
            '    MessageBox.Show("No ha seleccionado ningun archivo con extensión .pida para cargar lox xml", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If

            'If (txtanotim.Text.Trim = "" Or txtperiodotim.Text.Trim = "") Then
            '    MessageBox.Show("Falta información en el año y periodo a cargar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If

            CircularProgress4.Value = 0
            CircularProgress4.Maximum = 100
            Dim contador As Integer = 0
            Dim tipo_periodo As String = ""

            tipo_periodo = "S"
            '     cod_comp = "WME"

            Dim dtCod_Comp As DataTable
            dtCod_Comp = sqlExecute("select COD_COMP from cias where CIA_DEFAULT=1", "PERSONAL")
            If (Not dtCod_Comp.Columns.Contains("Error") And dtCod_Comp.Rows.Count > 0) Then
                Try : cod_comp = dtCod_Comp.Rows(0).Item("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try
            End If

            If True Then
                Try

                    '---- NOTA: PENDIENTES PARA QUE QUEDE BIEN 
                    '---- NOTA: Pedirle al cliente que nos pase un catalogo de las pecep y deduc que manejaban en NOMIPAQ, para hacer la traduccion al concepto PIDA, por ejemplo,
                    '          si en Nomipaq se llamaba "Bono por productividad" , en pida lo transformamos a BONPRO, y asi con cada uno, pero eso nos lo tiene que pasar el cliente, ya que
                    '          si no nos lo pasa, todo lo demas se va a ir a OTPNOG y OTRASD respectivamente
                    '---- Poner un textbox para indicar el año, periodo y tipo_periodo , pero que NO sea obligatorio el año, ya que se supone que lo correcto es cargar los xml por anio, periodo y tipo_periodo
                    'L---- Si no se cuenta  con el tipo_periodo, se podria sacar con NumDiasPagados si es > 7 es Catorcenal,  o con PeriodicidadPago si es <> "02" entonces es "C"
                    'L---- Determinar el periodo en base a las fechas inicial y fin, y que no sea fijo NOTA: Solo en caso de que no nos lo manden ordenadito por anio, periodo y tipo de periodo que es lo correcto.
                    'L---- Agregar mas conceptos para las percepciones, pero que sea por ocurrencia, ejemplo: para el aguinaldo donde concPida LIKE '%agui%', mandar al concepto PERAGI, por ejmplo
                    'L---- Hacer lo mismo para las deducciones
                    'L---- Caso para las percepciones  que traen exento y gravado, sobre todo para el caso del Aguinaldo, vac y prima_vac, agregar su concepto exento, ejemplo: PEXAGI para tenerlo cargado
                    '-- Hay que insertar a la tabla timbrado


                    For Each archivo As ArchivosTimbCargaHist In archivosTimbrado

                        contador += 1
                        CircularProgress4.Value = Math.Round((100 / archivosTimbrado.Count()) * contador)
                        Application.DoEvents()

                        Dim output As StringBuilder = New StringBuilder()

                        '---Variables locales
                        Dim Reloj As String = "", mes As String = ""
                        Dim QInsNeto As String = "", QInsTotper As String = "", QInsTotded As String = "", QInsPergra As String = "", QInsPerexe As String = ""
                        Dim neto As Double = 0.0, totper As Double = 0.0, totded As Double = 0.0, pergra As Double = 0.0, perexe As Double = 0.0
                        Dim tablaPer As String = ""
                        Dim dtPeriodo As New DataTable

                        '--Variables para el timbrado
                        'Dim nameArchivo As String = archivo.FileName
                        'Dim doc As XDocument = XDocument.Load(archivo.FileName)
                        'Dim cfdi As XNamespace = "http://www.sat.gob.mx/cfd/3"
                        'Dim nomina12 As XNamespace = "http://www.sat.gob.mx/nomina12"
                        'Dim tfd As XNamespace = "http://www.sat.gob.mx/TimbreFiscalDigital"

                        Dim nameArchivo As String = Nothing
                        Dim doc As XDocument
                        Dim cfdi As XNamespace
                        Dim nomina12 As XNamespace
                        Dim tfd As XNamespace

                        Try : nameArchivo = archivo.FileName : Catch ex As Exception : nameArchivo = Nothing : End Try
                        Try : doc = XDocument.Load(archivo.FileName) : Catch ex As Exception : doc = Nothing : End Try
                        Try : cfdi = "http://www.sat.gob.mx/cfd/3" : Catch ex As Exception : cfdi = Nothing : End Try
                        Try : nomina12 = "http://www.sat.gob.mx/nomina12" : Catch ex As Exception : nomina12 = Nothing : End Try
                        Try : tfd = "http://www.sat.gob.mx/TimbreFiscalDigital" : Catch ex As Exception : tfd = Nothing : End Try



                        If (nameArchivo Is Nothing Or doc Is Nothing Or cfdi Is Nothing Or nomina12 Is Nothing Or tfd Is Nothing) Then
                            GoTo sigRec
                        End If

                        '--Asignacion de valor a las variables
                        '   archivo.reloj = doc.Descendants(nomina12 + "Receptor").First.Attribute("NumEmpleado").Value
                        Try : archivo.reloj = doc.Descendants(nomina12 + "Receptor").First.Attribute("NumEmpleado").Value : Catch ex As Exception : archivo.reloj = "" : End Try
                        Try : archivo.sello = doc.Element(cfdi + "Comprobante").Attribute("Sello").Value : Catch ex As Exception : archivo.sello = "" : End Try
                        Try : archivo.certificado = doc.Element(cfdi + "Comprobante").Attribute("Certificado").Value : Catch ex As Exception : archivo.certificado = "" : End Try
                        Try : archivo.serie = doc.Element(cfdi + "Comprobante").Attribute("Serie").Value : Catch ex As Exception : archivo.serie = "" : End Try
                        Try : archivo.total = doc.Element(cfdi + "Comprobante").Attribute("Total").Value.PadLeft(17, "0") : Catch ex As Exception : archivo.total = "" : End Try
                        Try : archivo.rfcEmisor = doc.Descendants(cfdi + "Emisor").First.Attribute("Rfc").Value : Catch ex As Exception : archivo.rfcEmisor = "" : End Try
                        Try : archivo.rfcReceptor = doc.Descendants(cfdi + "Receptor").First.Attribute("Rfc").Value : Catch ex As Exception : archivo.rfcReceptor = "" : End Try
                        Try : archivo.FechaPago = doc.Descendants(nomina12 + "Nomina").First.Attribute("FechaPago").Value : Catch ex As Exception : archivo.FechaPago = "" : End Try

                        Try : archivo.numdiaspag = doc.Descendants(nomina12 + "Nomina").First.Attribute("NumDiasPagados").Value : Catch ex As Exception : archivo.numdiaspag = "" : End Try
                        archivo.isr_sep = 0
                        Try : archivo.ano = doc.Element(cfdi + "Comprobante").Attribute("Serie").Value : Catch ex As Exception : archivo.ano = "" : End Try
                        Try : archivo.periodo = doc.Element(cfdi + "Comprobante").Attribute("Folio").Value.PadLeft(2, "0") : Catch ex As Exception : archivo.periodo = "" : End Try
                        Try : archivo.UUID = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("UUID").Value : Catch ex As Exception : archivo.UUID = "" : End Try
                        Try : archivo.FechaTimbrado = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("FechaTimbrado").Value : Catch ex As Exception : archivo.FechaTimbrado = "" : End Try
                        Try : archivo.selloCFD = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("SelloCFD").Value : Catch ex As Exception : archivo.selloCFD = "" : End Try
                        Try : archivo.noCertificadoSAT = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("NoCertificadoSAT").Value : Catch ex As Exception : archivo.noCertificadoSAT = "" : End Try
                        Try : archivo.selloSat = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("SelloSAT").Value : Catch ex As Exception : archivo.selloSat = "" : End Try
                        Try : archivo.sactual = doc.Descendants(nomina12 + "Receptor").First.Attribute("SalarioDiarioIntegrado").Value : Catch ex As Exception : archivo.sactual = "" : End Try
                        Try : archivo.integrado = doc.Descendants(nomina12 + "Receptor").First.Attribute("SalarioBaseCotApor").Value : Catch ex As Exception : archivo.integrado = "" : End Try
                        Try : archivo.cuenta = doc.Descendants(nomina12 + "Receptor").First.Attribute("CuentaBancaria").Value : Catch ex As Exception : archivo.cuenta = "" : End Try

                        If (archivo.reloj = "") Then GoTo sigRec

                        Reloj = "00" + archivo.reloj ' Se le agregan dos ceros ya que es de 5 dígitos el numero de PIDA


                        If (Double.Parse(archivo.numdiaspag) <= 7.0) Then
                            archivo.tipo_periodo = "S"
                            tablaPer = "ta.dbo.periodos"
                        Else
                            archivo.tipo_periodo = "C" ' Seria catorcenal
                            tablaPer = "ta.dbo.periodos_catorcenal"
                        End If

                        '--Obtener info del periodo
                        Dim QPer As String = "SELECT * from " & tablaPer & " where ano+PERIODO='" & archivo.ano & archivo.periodo & "'"
                        dtPeriodo = sqlExecute(QPer, "TA")
                        If (Not dtPeriodo.Columns.Contains("Error") And dtPeriodo.Rows.Count > 0) Then
                            Try : mes = dtPeriodo.Rows(0).Item("NUM_MES").ToString.Trim : Catch ex As Exception : mes = "" : End Try
                        End If

                        '***********************Insertarlo en TIMBRADO
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

                        Dim QInsertTimb As String = "insert into timbrado (cod_comp, reloj, ano, periodo, tipo_periodo,isr_sep) values ('" & cod_comp & "','" & Reloj & "', '" & archivo.ano & "', '" & archivo.periodo & "', '" & archivo.tipo_periodo & "', " & archivo.isr_sep & ")"

                        sqlExecute(QInsertTimb, "nomina")

                        '---Obtener nombre de archivo para guardar el path de los XML
                        Dim UltCar As String = txtPathXml.Text.Substring(txtPathXml.Text.Length() - 1)
                        If (UltCar.Trim <> "\") Then UltCar = "\"

                        Dim XmlName As String = archivo.FileName.Trim.Split("\").Last()
                        Dim PathXml As String = txtPathXml.Text.Trim & UltCar.Trim & XmlName

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
            "ISR ='" & archivo.ISR & "' where reloj = '" & Reloj & "' and ano = '" & archivo.ano & "' and periodo = '" & archivo.periodo & "' and tipo_periodo = '" & archivo.tipo_periodo & "' and isr_sep=" & archivo.isr_sep

                        sqlExecute(QUpT, "nomina")


                        '************************Agregarlo en Nomina
                        Dim QInsNom As String = "insert into nomina (cod_comp,COD_TIPO_NOMINA,COD_PAGO,ano,PERIODO,RELOJ,MES,SACTUAL,INTEGRADO,CUENTA,tipo_periodo) values (" & _
                            "'" & cod_comp & "','N','D','" & archivo.ano & "','" & archivo.periodo & "','" & Reloj & "','" & mes & "'," & archivo.sactual & " ," & archivo.integrado & ",'" & archivo.cuenta & " ','" & archivo.tipo_periodo & "')"
                        sqlExecute(QInsNom, "nomina")

                        '--- Datos que irán en Movimientos
                        Try : archivo.TotalOtrosPagos = doc.Descendants(nomina12 + "Nomina").First.Attribute("TotalOtrosPagos").Value : Catch ex As Exception : archivo.TotalOtrosPagos = "0" : End Try
                        Try : archivo.TotalDeducciones = doc.Descendants(nomina12 + "Nomina").First.Attribute("TotalDeducciones").Value : Catch ex As Exception : archivo.TotalDeducciones = "0" : End Try
                        Try : archivo.TotalPercepciones = doc.Descendants(nomina12 + "Nomina").First.Attribute("TotalPercepciones").Value : Catch ex As Exception : archivo.TotalPercepciones = "0" : End Try

                        'archivo.TotalOtrosPagos = doc.Descendants(nomina12 + "Nomina").First.Attribute("TotalOtrosPagos").Value
                        'archivo.TotalDeducciones = doc.Descendants(nomina12 + "Nomina").First.Attribute("TotalDeducciones").Value
                        'archivo.TotalPercepciones = doc.Descendants(nomina12 + "Nomina").First.Attribute("TotalPercepciones").Value
                        '-- El NETO sería TotalPercepciones +  TotalOtrosPagos - TotalDeducciones
                        neto = Double.Parse(archivo.TotalPercepciones) + Double.Parse(archivo.TotalOtrosPagos) - Double.Parse(archivo.TotalDeducciones)
                        totper = Double.Parse(archivo.TotalPercepciones) + Double.Parse(archivo.TotalOtrosPagos)
                        totded = Double.Parse(archivo.TotalDeducciones)

                        Try : archivo.TotalExento = doc.Descendants(nomina12 + "Percepciones").First.Attribute("TotalExento").Value : Catch ex As Exception : archivo.TotalExento = "0" : End Try
                        Try : archivo.TotalGravado = doc.Descendants(nomina12 + "Percepciones").First.Attribute("TotalGravado").Value : Catch ex As Exception : archivo.TotalGravado = "0" : End Try

                        'archivo.TotalExento = doc.Descendants(nomina12 + "Percepciones").First.Attribute("TotalExento").Value
                        'archivo.TotalGravado = doc.Descendants(nomina12 + "Percepciones").First.Attribute("TotalGravado").Value
                        '-- NOTA: PERGRA = archivo.TotalGravado y PEREXE = archivo.TotalExento
                        pergra = Double.Parse(archivo.TotalGravado) ' Total Gravado
                        perexe = Double.Parse(archivo.TotalExento) ' Total Exento

                        '************Insertar a movimientos los totales
                        QInsNeto = "INSERT INTO movimientos (ano,PERIODO,RELOJ,CONCEPTO,MONTO,PRIORIDAD,IMPORTAR,tipo_periodo) VALUES ('" & archivo.ano & "','" & archivo.periodo & "','" & Reloj & "','NETO'," & neto & ",'120',1,'" & archivo.tipo_periodo & "')"
                        QInsTotper = "INSERT INTO movimientos (ano,PERIODO,RELOJ,CONCEPTO,MONTO,PRIORIDAD,IMPORTAR,tipo_periodo) VALUES ('" & archivo.ano & "','" & archivo.periodo & "','" & Reloj & "','TOTPER'," & totper & ",'120',1,'" & archivo.tipo_periodo & "')"
                        QInsTotded = "INSERT INTO movimientos (ano,PERIODO,RELOJ,CONCEPTO,MONTO,PRIORIDAD,IMPORTAR,tipo_periodo) VALUES ('" & archivo.ano & "','" & archivo.periodo & "','" & Reloj & "','TOTDED'," & totded & ",'120',1,'" & archivo.tipo_periodo & "')"
                        QInsPergra = "INSERT INTO movimientos (ano,PERIODO,RELOJ,CONCEPTO,MONTO,PRIORIDAD,IMPORTAR,tipo_periodo) VALUES ('" & archivo.ano & "','" & archivo.periodo & "','" & Reloj & "','PERGRA'," & pergra & ",'120',1,'" & archivo.tipo_periodo & "')"
                        QInsPerexe = "INSERT INTO movimientos (ano,PERIODO,RELOJ,CONCEPTO,MONTO,PRIORIDAD,IMPORTAR,tipo_periodo) VALUES ('" & archivo.ano & "','" & archivo.periodo & "','" & Reloj & "','PEREXE'," & perexe & ",'120',1,'" & archivo.tipo_periodo & "')"

                        sqlExecute(QInsNeto, "NOMINA")
                        sqlExecute(QInsTotper, "NOMINA")
                        sqlExecute(QInsTotded, "NOMINA")
                        sqlExecute(QInsPergra, "NOMINA")
                        sqlExecute(QInsPerexe, "NOMINA")

                        '-----Insertar El detalle de cada percepción y deducción

                        '--PERCEPCIONES
                        If doc.Descendants(nomina12 + "Percepciones").Count > 0 Then
                            Dim percepciones = doc.Descendants(nomina12 + "Percepciones").Descendants(nomina12 + "Percepcion")

                            For Each percepcion In percepciones
                                Dim concepto As String = "", ImporteGravado As Double = 0.0, ImporteExento As Double = 0.0
                                Dim concPida As String = "", total As Double = 0.0, concExento As String = ""
                                concepto = percepcion.Attribute("Concepto") ' NOTA: El nombre del concepto es del proveedor donde se timbro, en este caso, es de NOMIPAQ como llama a cada concepto
                                ImporteGravado = Double.Parse(percepcion.Attribute("ImporteGravado"))
                                ImporteExento = Double.Parse(percepcion.Attribute("ImporteExento"))
                                total = ImporteGravado + ImporteExento
                                Select Case concepto
                                    Case "Sueldo"
                                        concPida = "PERNOR"
                                    Case "Séptimo día"
                                        concPida = "SEPDIA"
                                    Case "Bono de Asistencia"
                                        concPida = "BONASI"
                                    Case "Fondo ahorro empresa"
                                        concPida = "APOCIA"
                                    Case "Vales Despensa"
                                        concPida = "BONDES"
                                    Case "Dobles"
                                        concPida = "PEREX2"
                                    Case "Triples"
                                        concPida = "PEREX3"
                                    Case "Prima dominical"
                                        concPida = "PRIDOM"
                                    Case "Retroactivo"
                                        concPida = "RETROA"
                                    Case "Vacaciones a tiempo", "Vacaciones"
                                        concPida = "PERVAC"
                                    Case "Prima de vacaciones a tiempo", "Prima de vacaciones reportada $", "Prima de vacaciones", "Prima de vacaciones reportada"
                                        concPida = "PRIVAC"
                                    Case "Aguinaldo"
                                        concPida = "PERAGI"
                                    Case "Día festivo / descanso"
                                        concPida = "PERDES"
                                    Case "PTU", "Reparto de utilidades", "Utilidades", "Reparto de PTU"
                                        concPida = "PERPTU"
                                    Case "Separación Unica"
                                        concPida = "SEPUNI"
                                    Case "Indemnizaciones", "Indemnización"
                                        concPida = "INDEMN"
                                    Case "Prima de antiguedad"
                                        concPida = "PRIANT"
                                    Case "Bono de productividad"
                                        concPida = "BONPRO"
                                    Case "Despensa en efectivo"
                                        concPida = "DESEFE"
                                    Case "Viáticos", "Viaticos", "Comprobación de viáticos", "Viáticos entregados al trabajador"
                                        concPida = "COMVIA"
                                    Case Else
                                        concPida = "OTPNOG" ' Concepto desconocido que no está en la lista
                                End Select
                                Dim QInsertMov As String = ""
                                If concPida.Trim <> "" Then
                                    QInsertMov = "INSERT INTO movimientos (ano,PERIODO,RELOJ,CONCEPTO,MONTO,PRIORIDAD,IMPORTAR,tipo_periodo) VALUES ('" & archivo.ano & "','" & archivo.periodo & "','" & Reloj & "','" & concPida & "'," & total & ",'120',1,'" & archivo.tipo_periodo & "')"
                                    sqlExecute(QInsertMov, "nomina")
                                End If

                                '---- Agregar el exento para cada concepto que lo requiera:
                                ' APOCIA - PEXFAH, INDEMN - PEXIND ,NOREST-PEXNOR, PERAGI-PEXAGI ,PEREX2-PEXEXT ,PERPTU-PEXPTU ,PRIANT-PEXPAN ,PRIDOM-PEXDOM ,PRIVAC - PEXVAC              
                                If (ImporteExento > 0) Then
                                    Select Case concPida
                                        Case "APOCIA"
                                            concExento = "PEXFAH"
                                        Case "PERAGI"
                                            concExento = "PEXAGI"
                                        Case "PEREX2"
                                            concExento = "PEXEXT"
                                        Case "PERPTU"
                                            concExento = "PEXPTU"
                                        Case "PRIDOM"
                                            concExento = "PEXDOM"
                                        Case "PRIVAC"
                                            concExento = "PEXVAC"
                                        Case "INDEMN"
                                            concExento = "PEXIND"
                                        Case "PRIANT"
                                            concExento = "PEXPAN"
                                    End Select

                                    Dim QInsConcExento As String = ""
                                    If (concExento.Trim <> "") Then
                                        QInsConcExento = "INSERT INTO movimientos (ano,PERIODO,RELOJ,CONCEPTO,MONTO,PRIORIDAD,IMPORTAR,tipo_periodo) VALUES ('" & archivo.ano & "','" & archivo.periodo & "','" & Reloj & "','" & concExento & "'," & ImporteExento & ",'120',1,'" & archivo.tipo_periodo & "')"
                                        sqlExecute(QInsConcExento, "nomina")
                                    End If

                                End If
                            Next
                        End If

                        '-- DEDUCCIONES
                        If doc.Descendants(nomina12 + "Deducciones").Count > 0 Then
                            Dim deducciones = doc.Descendants(nomina12 + "Deducciones").Descendants(nomina12 + "Deduccion")
                            For Each deduccion In deducciones
                                Dim concepto As String = ""
                                Dim concPida As String = "", importe As Double = 0.0
                                concepto = deduccion.Attribute("Concepto") ' NOTA: El nombre del concepto es del proveedor donde se timbro, en este caso, es de NOMIPAQ como llama a cada concepto
                                importe = Double.Parse(deduccion.Attribute("Importe"))

                                Select Case concepto
                                    Case "IMSS"
                                        concPida = "IMSS"
                                    Case "Fondo de ahorro"
                                        concPida = "APOFAH"
                                    Case "ISR mes", "ISR", "ISPT", "ISR Separación", "ISRSEP", "Impuesto"
                                        concPida = "ISPTRE"
                                    Case "Préstamo Infonavit vsm", "Préstamo Infonavit cf", "Infonavit", "Préstamo Infonavit"
                                        concPida = "DESINF"
                                    Case "Alimentos"
                                        concPida = "CUOCAF"
                                    Case "Préstamo FONACOT"
                                        concPida = "FNAALC"
                                    Case Else
                                        concPida = "OTRASD"
                                End Select

                                Dim QInsMovD As String = ""
                                If concPida.Trim <> "" Then
                                    QInsMovD = "INSERT INTO movimientos (ano,PERIODO,RELOJ,CONCEPTO,MONTO,PRIORIDAD,IMPORTAR,tipo_periodo) VALUES ('" & archivo.ano & "','" & archivo.periodo & "','" & Reloj & "','" & concPida & "'," & importe & ",'120',1,'" & archivo.tipo_periodo & "')"
                                    sqlExecute(QInsMovD, "nomina")
                                End If

                            Next
                        End If

sigRec:

                    Next

                    MessageBox.Show("Se cargaron los xml seleccionados con su ruta respectiva", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                Catch ex As Exception
                    MessageBox.Show("Error al procesar el archivo Reloj='" & Reloj & "'. Error: " & ex.Message)
                End Try

            End If



        Catch ex As Exception
            MessageBox.Show("Error en carga xml. Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnVerBuscar_Click(sender As Object, e As EventArgs) Handles btnVerBuscar.Click
        Try
            Dim ofd As New OpenFileDialog
            ofd.Filter = "Archivos PIDA|*.pida"
            ofd.Multiselect = False
            ofd.AddExtension = True
            ofd.CheckFileExists = True
            ofd.CheckPathExists = True
            ofd.Title = "Selecciona el archivo de timbrados: " & nombreDelArchivo
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                If System.IO.File.Exists(ofd.FileName) Then

                    txtarchivo.Text = ofd.FileName

                    If txtpath.Text <> "" Then
                        analizarArchivoDeCargas()
                    End If

                End If
            End If
        Catch ex As Exception
            '  ErrorLog(Usuario.getUSERNAME, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Carga xml", Err.Number, ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub analizarArchivoDeCargas()
        ubicacionDelArchivo = txtarchivo.Text
        Using archive As ZipArchive = ZipFile.OpenRead(ubicacionDelArchivo)


            Dim contador As Integer = 0

            For Each entry As ZipArchiveEntry In archive.Entries

                entry.ExtractToFile(Path.Combine(txtpath.Text, entry.FullName))

                Dim archivo As New ArchivosTimbCargaHist

                archivo.FileName = Path.Combine(txtpath.Text, entry.FullName)
                If Path.GetExtension(archivo.FileName).Equals(".xml") Then
                    archivosTimbrado.Add(archivo)
                End If
                Try
                    contador += 1
                    ' CircularProgress1.Value = Math.Round((100 / archive.Entries.Count) * contador)
                    Application.DoEvents()
                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Carga xml", Err.Number, ex.Message)
                End Try
            Next
        End Using

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Try
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                directorioExtraccion = fbd.SelectedPath
                txtpath.Text = directorioExtraccion
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscarRutaXML_Click(sender As Object, e As EventArgs) Handles btnBuscarRutaXML.Click
        Try
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                dirPathXML = fbd.SelectedPath & "\"
                txtPathXml.Text = dirPathXML
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class