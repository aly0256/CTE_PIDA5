Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Xml
Public Class frmCargaXML
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

    Private periodo_catorc As String = ""
    Private nom_cat As String = ""

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Me.Close()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try

            If (txtarchivo.Text.Trim = "") Then
                MessageBox.Show("No ha seleccionado ningun archivo con extensión .pida para cargar lox xml", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If (txtanotim.Text.Trim = "" Or txtperiodotim.Text.Trim = "") Then
                MessageBox.Show("Falta información en el año y periodo a cargar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            CircularProgress4.Value = 0
            CircularProgress4.Maximum = 100
            Dim contador As Integer = 0
            Dim tipo_periodo As String = ""
            If (chkPerS.Checked) Then tipo_periodo = "S"
            If (chkPerC.Checked) Then tipo_periodo = "C"
            cod_comp = "WME"

            If True Then
                Try

                    Try

                        Dim dt_periodos As DataTable


                        Dim QP As String = "select * from periodos where ano = '" & txtanotim.Text.Trim & "' and periodo = '" & txtperiodotim.Text.Trim & "'"
                        dt_periodos = sqlExecute(QP, "TA")

                        If (Not dt_periodos.Columns.Contains("Error") And dt_periodos.Rows.Count > 0) Then
                            Try : nom_cat = dt_periodos.Rows(0)("nom_cat").ToString.Trim : Catch ex As Exception : nom_cat = "" : End Try

                            '----Mandar el periodo tanto de los semanales como de los 14nales para meterlos a nomina_pro
                            If (nom_cat = "1") Then
                                periodo_catorc = (Double.Parse(txtperiodotim.Text.Trim) / 2).ToString.Trim
                            End If
                        End If

                    Catch ex As Exception

                    End Try


                    For Each archivo As ArchivoTimbrado In archivosTimbrado

                        contador += 1
                        CircularProgress4.Value = Math.Round((100 / archivosTimbrado.Count()) * contador)
                        Application.DoEvents()

                        Dim output As StringBuilder = New StringBuilder()

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
                        archivo.UUID = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("UUID").Value
                        archivo.FechaTimbrado = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("FechaTimbrado").Value
                        archivo.selloCFD = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("SelloCFD").Value
                        archivo.noCertificadoSAT = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("NoCertificadoSAT").Value
                        archivo.selloSat = doc.Descendants(tfd + "TimbreFiscalDigital").First.Attribute("SelloSAT").Value

                        archivo.cod_comp = cod_comp
                        archivo.ano = txtanotim.Text
                        archivo.periodo = txtperiodotim.Text

                        archivo.tipo_periodo_t = tipo_periodo

                        '--AOS: Que inserte si es ISR Ret o de separacion

                        Dim QInsert As String = "insert into timbrado (cod_comp, reloj, ano, periodo, tipo_periodo,isr_sep) values ('" & cod_comp & "','" & archivo.reloj & "', '" & txtanotim.Text & "', '" & txtperiodotim.Text & "', '" & tipo_periodo & "', " & archivo.isr_sep & ")"

                        sqlExecute(QInsert, "nomina")

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
            "ISR ='" & archivo.ISR & "' where reloj = '" & archivo.reloj & "' and ano = '" & archivo.ano & "' and periodo = '" & archivo.periodo & "' and tipo_periodo = '" & tipo_periodo & "' and isr_sep=" & archivo.isr_sep

                        sqlExecute(QUpT, "nomina")


                    Next

                    '------------Actualizar el periodo y tipo de periodo en la tabla Timbrado para los 14nales
                    'If (nom_cat = "1" And periodo_catorc <> "") Then
                    '    Dim AnioPerAct As String = txtanotim.Text.Trim & txtperiodotim.Text.Trim
                    '    Dim AnioPerCat As String = txtanotim.Text.Trim & periodo_catorc
                    '    Dim tipo_Per As String = "C"
                    '    Dim QAct As String = "update timbrado set ano='" & txtanotim.Text.Trim & "', periodo='" & periodo_catorc & "',tipo_periodo='" & tipo_Per & "' where ano+periodo='" & AnioPerAct & "'  and reloj in ( " & _
                    '        "SELECT t.reloj from timbrado t left outer join nomina n on t.reloj=n.RELOJ where t.ano+t.periodo='" & AnioPerAct & "' and n.ANO+n.PERIODO='" & AnioPerCat & "' and n.tipo_periodo='" & tipo_Per & "' )"

                    '    sqlExecute(QAct, "NOMINA")
                    'End If

                    MessageBox.Show("Se cargaron los xml seleccionados con su ruta respectiva", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                Catch ex As Exception
                    MessageBox.Show("Error al procesar el archivo. Error: " & ex.Message)
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

                Dim archivo As New ArchivoTimbrado

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

    Private Sub frmCargaXML_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtpath.Text = My.Computer.FileSystem.SpecialDirectories.Desktop
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

    Private Sub chkPerS_CheckedChanged(sender As Object, e As EventArgs) Handles chkPerS.CheckedChanged
        If (chkPerS.Checked) Then
            chkPerC.Checked = False
        End If
    End Sub

    Private Sub chkPerC_CheckedChanged(sender As Object, e As EventArgs) Handles chkPerC.CheckedChanged
        If (chkPerC.Checked) Then
            chkPerS.Checked = False
        End If
    End Sub
End Class

Public Class ArchivoTimbrado
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