Imports Microsoft.Reporting.WinForms
Imports System.IO

Imports System.Xml

Public Class frmVistaPrevia
    '= "C:\PIDA\PIDA NET\Personal\Reportes\Personal\ReportesPersonal\ReportesPersonal\"
    Dim dtCompa As New DataTable
    Dim dtDatos As New DataTable
    Dim dtCompanias As New DataTable

    Private Sub frmVistaPrevia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmVistaPrevia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            dtCompa = sqlExecute("SELECT * FROM personal.dbo.cias")
            dtCompanias = sqlExecute("SELECT  COD_COMP,NOMBRE FROM personal.dbo.cias")
            vwrReportes.ShowProgress = True
            vwrReportes.ZoomMode = ZoomMode.Percent
            Me.vwrReportes.RefreshReport()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub GenerarReporteTMP()
        ReporteTMP = vwrReportes.LocalReport
    End Sub
    Public Sub LlamarReporte(ByVal Nombre As String, ByVal dtDatosFiltrados As DataTable, Optional FiltroCompania As String = "", Optional ParametrosAdicionales As String() = Nothing, Optional MostrarReporte As Boolean = True, Optional ExportarArchivo As String = "", Optional VistaPrevia As Boolean = True, Optional Impresora As String = "", Optional CopiarReporteTMP As Boolean = False, Optional ByRef dtDatosFilt_2 As DataTable = Nothing, Optional payment_date As String = Nothing)
        Try
            ReporteDiario = True 'Regresa la variable de preguntar fecha en el reporte dario
            Dim dtPersonalEspecial As New DataTable
            Dim dtAuxiliares As New DataTable
            Dim IncluyePersonal As Boolean = False
            Dim Reporte As String = DireccionReportes & Nombre.Trim & ".rdl"
            Dim HayDatos As Boolean = True

            Dim DatosDLL As New DataTable
            Dim dtInfo As New DataTable
            Dim dtResult As New DataTable
            Application.DoEvents()

            'Asignar datos a dtCompa para asignarlo al reporte, de acuerdo al valor de FiltroCompania
            If FiltroCompania = "" Then
                'Si no se incluye filtro, tomar el primero de la tabla
                dtCompa = sqlExecute("SELECT COD_COMP,RTRIM(NOMBRE) AS NOMBRE,RFC,REG_PAT,INFONAVIT,LOGO,GUIA,DIRECCION,COLONIA,CIUDAD," & _
                                     "ESTADO,COD_POSTAL,TELEFONO1,REP_LEGAL,PUESTO,GIRO,'' AS FILTROS,'' AS ENCABEZADO FROM personal.dbo.cias " & _
                                     "WHERE cia_default = 1")

                FiltroCompania = dtCompa.Rows(0).Item("cod_comp")
            Else
                dtCompa = sqlExecute("SELECT COD_COMP,RTRIM(NOMBRE) AS NOMBRE,RFC,REG_PAT,INFONAVIT,LOGO,GUIA,DIRECCION,COLONIA,CIUDAD," & _
                                     "ESTADO,COD_POSTAL,TELEFONO1,REP_LEGAL,PUESTO,GIRO,'' AS FILTROS,'' AS ENCABEZADO FROM personal.dbo.cias " & _
                                     "WHERE COD_COMP = '" & FiltroCompania & "'")
            End If
            If IsNothing(FiltroReporte) Then
                FiltroReporte = ""
            End If

            If IsNothing(EncabezadoReporte) Then
                EncabezadoReporte = ""
            End If

            dtCompa.Rows(0).Item("FILTROS") = IIf(FiltroReporte.Trim.Length > 0, "Filtros: ", "") & FiltroReporte.Trim
            dtCompa.Rows(0).Item("ENCABEZADO") = EncabezadoReporte.Trim

            'Limpiar el ReportViewer, por si hubiera algún reporte cargado
            vwrReportes.Clear()
            'Indicar que se ejecutarán reportes de forma local (no desde servidor SSRS)
            vwrReportes.ProcessingMode = ProcessingMode.Local
            vwrReportes.LocalReport.ReportPath = Reporte
            vwrReportes.LocalReport.DataSources.Clear()
            '**** PROCESO PARA ABRIR ARCHIVO .RDL.DATA Y OBTENER LOS DATASET DEL REPORTE
            Dim cmd As New System.Data.SqlClient.SqlCommand
            Dim XRep As New XmlDocument
            XRep.Load(Reporte)
            Dim xmlnsManager As New System.Xml.XmlNamespaceManager(XRep.NameTable)
            Dim DefaultNSURI As String = XRep.GetElementsByTagName("Width")(0).NamespaceURI
            xmlnsManager.AddNamespace("rep", DefaultNSURI)

            '*** Conexión de SQL
            cmd.Connection = New System.Data.SqlClient.SqlConnection(SQLConn & ";Persist Security Info=True; User ID=" & sUserAdmin & "; Password=" & sPassword & ";")

            '*** Para cada DataSet encontrado
            For Each nd As XmlNode In XRep.SelectNodes("/rep:Report/rep:DataSets/rep:DataSet", xmlnsManager)
                'DataSourceName can be used to find iformation about connection' 
                Dim DataSourceName As String = nd.SelectSingleNode("rep:Query/rep:DataSourceName", xmlnsManager).InnerText
                Dim DSName As String = nd.Attributes("Name").Value
                If DSName.ToUpper.Contains("_COD") Then
                    'Si el nombre del dataset incluye '_COD', quiere decir que se debe llamar una función para procesar los datos                
                    '--- Solo para los pagos electronicos
                    If Nombre.Trim = "Pagos electrónicos" Then
                        dtPersonalEspecial = PreparaDatos(Nombre, dtDatosFiltrados, DSName, ParametrosAdicionales, cod_comp:=FiltroCompania, payment_date:=payment_date)
                    Else
                        dtPersonalEspecial = PreparaDatos(Nombre, dtDatosFiltrados, DSName, ParametrosAdicionales)
                    End If

                    HayDatos = HayDatos And dtPersonalEspecial.Rows.Count > 0
                    vwrReportes.LocalReport.DataSources.Add(New ReportDataSource(DSName, dtPersonalEspecial))

                ElseIf DSName.ToUpper.Contains("_ESP") Then ' Mandar la info del segundo dt 
                    If (DSName.ToUpper = "TA_ESP") Then
                        dtPersonalEspecial = PreparaDatos(Nombre, dtDatosFilt_2, DSName, ParametrosAdicionales)
                        HayDatos = HayDatos And dtPersonalEspecial.Rows.Count > 0
                        vwrReportes.LocalReport.DataSources.Add(New ReportDataSource(DSName, dtPersonalEspecial))
                    End If

                ElseIf DSName = "Compa" Or DSName = "Compañía" Then
                    'Si el dataset corresponde a 'Compa', crear dataset para filtrar por compañía, o ubicar la primer compañía de la tabla
                    vwrReportes.LocalReport.DataSources.Add(New ReportDataSource(DSName, dtCompa))
                ElseIf DSName = "Datos" Then
                    'Si es 'Datos', utilizar la información integrada en el reporte
                    cmd.CommandText = nd.SelectSingleNode("rep:Query/rep:CommandText", xmlnsManager).InnerText
                    sqlAdaptador.SelectCommand = cmd

                    HayDatos = HayDatos And dtResulta.Rows.Count > 0
                    sqlAdaptador.Fill(dtResulta)
                    vwrReportes.LocalReport.DataSources.Add(New ReportDataSource(DSName, dtResulta))
                    sqlAdaptador.Dispose()
                    dtResulta = New DataTable
                Else
                    'Si el dataset es cualquier otro, utilizar los datos como se recibieron en la función
                    'Crear dataset para filtrar y asignar orden requerido
                    HayDatos = HayDatos And dtDatosFiltrados.Rows.Count > 0
                    vwrReportes.LocalReport.DataSources.Add(New ReportDataSource(DSName, dtDatosFiltrados))
                End If
            Next

            If CopiarReporteTMP Then
                ReporteTMP = vwrReportes.LocalReport
            End If

            '*************************************

            vwrReportes.LocalReport.EnableExternalImages = True
            'If Not HayDatos And MostrarReporte Then
            '    MessageBox.Show("No se encontraron datos para mostrar en el reporte.", "Reporte en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If

            If ExportarArchivo.Length > 0 Then
                'Si se va a exportar el reporte
                Dim warnings As Warning() = Nothing
                Dim streamids As String() = Nothing
                Dim mimeType As String = Nothing
                Dim encoding As String = Nothing
                Dim extension As String = Nothing
                Dim bytes As Byte()

                'Get folder on web server from web.config

                'Borrar archivo existente
                Dim FilePath As String = ExportarArchivo
                File.Delete(FilePath)

                If ExportarArchivo.Substring(ExportarArchivo.Length - 3).ToUpper = "PDF" Then
                    'Crear archivo PDF
                    bytes = vwrReportes.LocalReport.Render("PDF", Nothing)

                    Dim fs As New FileStream(FilePath, FileMode.Create)
                    fs.Write(bytes, 0, bytes.Length)
                    fs.Close()
                ElseIf ExportarArchivo.Substring(ExportarArchivo.Length - 3).ToUpper = "XLS" Then
                    'Crear archivo PDF
                    bytes = vwrReportes.LocalReport.Render("Excel", Nothing)

                    Dim fs As New FileStream(FilePath, FileMode.Create)
                    fs.Write(bytes, 0, bytes.Length)
                    fs.Close()

                    '== Crear archivo word                  10mar22             Ernesto
                ElseIf ExportarArchivo.Substring(ExportarArchivo.Length - 3) = "doc" Then
                    bytes = vwrReportes.LocalReport.Render("Word", Nothing)
                    Dim fs As New FileStream(FilePath, FileMode.Create)
                    fs.Write(bytes, 0, bytes.Length)
                    fs.Close()
                End If
            End If

            If MostrarReporte Then
                vwrReportes.RefreshReport()
            End If

            If Not VistaPrevia Then
                Dim pr As New ImprimirReportViewer
                pr.Run(vwrReportes.LocalReport, Impresora)
            End If

            'Me.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Public Sub LlamarCondensado(ByVal Nombre As String, ByVal dtDatosFiltrados As DataTable, ByVal FiltroCompania As String, ByVal ExportarArchivo As String)
        Try
            Dim dtPersonalEspecial As New DataTable
            Dim dtAuxiliares As New DataTable
            Dim IncluyePersonal As Boolean = False
            Dim Reporte As String = DireccionReportes & Nombre & ".rdl"

            ' Dim DatosDLL As New DLLReportes.DatosReporteador.MyFunctions
            Dim dtInfo As New DataTable
            Dim dtResult As New DataTable
            Application.DoEvents()

            'Asignar datos a dtCompa para asignarlo al reporte, de acuerdo al valor de FiltroCompania
            dtCompa = sqlExecute("SELECT COD_COMP,RTRIM(NOMBRE) AS NOMBRE,RFC,REG_PAT,INFONAVIT,LOGO,GUIA FROM personal.dbo.cias " & _
                                 "WHERE COD_COMP = '" & FiltroCompania & "'")

            'Limpiar el ReportViewer, por si hubiera algún reporte cargado
            vwrReportes.Clear()
            'Indicar que se ejecutarán reportes de forma local (no desde servidor SSRS)
            vwrReportes.ProcessingMode = ProcessingMode.Local
            vwrReportes.LocalReport.ReportPath = Reporte
            vwrReportes.LocalReport.DataSources.Clear()
            '**** PROCESO PARA ABRIR ARCHIVO .RDL.DATA Y OBTENER LOS DATASET DEL REPORTE
            Dim cmd As New System.Data.SqlClient.SqlCommand
            Dim XRep As New XmlDocument
            XRep.Load(Reporte)
            Dim xmlnsManager As New System.Xml.XmlNamespaceManager(XRep.NameTable)
            Dim DefaultNSURI As String = XRep.GetElementsByTagName("Width")(0).NamespaceURI
            xmlnsManager.AddNamespace("rep", DefaultNSURI)

            '*** Conexión de SQL
            cmd.Connection = New System.Data.SqlClient.SqlConnection(SQLConn & ";Persist Security Info=True; User ID=sa; Password=" & sPassword & ";")

            '*** Para cada DataSet encontrado
            For Each nd As XmlNode In XRep.SelectNodes("/rep:Report/rep:DataSets/rep:DataSet", xmlnsManager)
                'DataSourceName can be used to find iformation about connection' 
                Dim DataSourceName As String = nd.SelectSingleNode("rep:Query/rep:DataSourceName", xmlnsManager).InnerText
                Dim DSName As String = nd.Attributes("Name").Value
                If DSName.ToUpper.Contains("_COD") Then
                    'Si el nombre del dataset incluye '_COD', quiere decir que se debe llamar el DLLReportes para procesar los datos
                    dtPersonalEspecial = PreparaDatos(Nombre, dtDatosFiltrados, DSName, {"CONDENSADO", ExportarArchivo})
                    ExportaExcel(DataTableTORecordset(dtPersonalEspecial), ExportarArchivo.Replace("PDF", "XLSX"))

                    vwrReportes.LocalReport.DataSources.Add(New ReportDataSource(DSName, dtPersonalEspecial))
                ElseIf DSName = "Compa" Or DSName = "Compañía" Then
                    'Si el dataset corresponde a 'Compa', crear dataset para filtrar por compañía, o ubicar la primer compañía de la tabla

                    vwrReportes.LocalReport.DataSources.Add(New ReportDataSource(DSName, dtCompa))
                ElseIf DSName = "Datos" Then
                    'Si es 'Datos', utilizar la información integrada en el reporte
                    cmd.CommandText = nd.SelectSingleNode("rep:Query/rep:CommandText", xmlnsManager).InnerText
                    sqlAdaptador.SelectCommand = cmd

                    'Si no se ha asignado el parámetro COMP, asignarlo
                    If Not sqlAdaptador.SelectCommand.Parameters.Contains("@COMP") Then
                        sqlAdaptador.SelectCommand.Parameters.Add("@COMP", SqlDbType.Char).Value = FiltroCompania.Trim
                    End If

                    sqlAdaptador.Fill(dtResulta)
                    vwrReportes.LocalReport.DataSources.Add(New ReportDataSource(DSName, dtResulta))
                    sqlAdaptador.Dispose()
                    dtResulta = New DataTable
                Else
                    'Si el dataset es cualquier otro, utilizar los datos como se recibieron en la función
                    'Crear dataset para filtrar y asignar orden requerido
                    vwrReportes.LocalReport.DataSources.Add(New ReportDataSource(DSName, dtDatosFiltrados.DefaultView))
                End If
            Next
            '*************************************

            Try
                vwrReportes.LocalReport.EnableExternalImages = True
                vwrReportes.LocalReport.SetParameters(New ReportParameter("COMP", FiltroCompania.Trim))
            Catch ex As Exception
                Debug.Print("No parámetro COMP. " & ex.Message)
            End Try

            Dim warnings As Warning() = Nothing
            Dim streamids As String() = Nothing
            Dim mimeType As String = Nothing
            Dim encoding As String = Nothing
            Dim extension As String = Nothing
            Dim bytes As Byte()

            'Borrar archivo existente 
            Dim FilePath As String = ExportarArchivo
            File.Delete(FilePath)

            'Crear archivo PDF
            bytes = vwrReportes.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)

            Dim fs As New FileStream(FilePath, FileMode.Create)
            fs.Write(bytes, 0, bytes.Length)
            fs.Close()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub ReporteDinamico(drInfoReporte As DataRow, dtDatosReporte As DataTable, Titulo As String)
        Try
            Dim Reporte As String = DireccionReportes & "Reporte dinámico.rdl"
            Dim dtCampos As New DataTable

            'Dim DatosDLL As New DLLReportes.DatosReporteador.MyFunctions
            Dim dtInfo As New DataTable
            Dim dtResult As New DataTable
            Dim dtCompa As New DataTable
            Dim c As String
            Dim i As Integer = 0
            Dim f As Integer = 0
            Dim Campos() As String
            Dim Grupo1 As String
            Dim Grupo2 As String
            Dim Grupo3 As String
            Dim MostrarDetalle As Byte
            Dim MostrarResumen As Byte

            Application.DoEvents()
            'Asignar datos a dtCompa para asignarlo al reporte, de acuerdo al valor de FiltroCompania

            If FiltroReporte.ToUpper.Contains("COD_COMP") Then
                'Si no se incluye filtro, tomar el primero de la tabla
                i = FiltroReporte.ToUpper.IndexOf("COD_COMP")
                f = FiltroReporte.ToUpper.IndexOf(")", i)

                c = FiltroReporte.ToUpper.Substring(i, f - i + 1)

                dtCompa = sqlExecute("SELECT COD_COMP,RTRIM(NOMBRE) AS NOMBRE, RFC, REG_PAT, INFONAVIT, LOGO, GUIA, DIRECCION, COLONIA, CIUDAD, ESTADO, COD_POSTAL, TELEFONO1, REP_LEGAL ,PUESTO FROM personal.dbo.cias WHERE " & c)

            Else
                dtCompa = sqlExecute("SELECT TOP 1 COD_COMP,RTRIM(NOMBRE) AS NOMBRE,RFC,REG_PAT,INFONAVIT,LOGO,GUIA FROM personal.dbo.cias WHERE cia_default = 1")
            End If

            'sqlExecute("select upper(cod_campo) as campo,nombre,tipo FROM campos UNION select upper(campo),nombre,'char' as tipo from auxiliares", dtCampos, Replace(ReporteadorFuente, "&", ""))
            dtCampos = dtDisponibles.Copy
            dtCampos.PrimaryKey = New DataColumn() {dtCampos.Columns("campo")}


            Campos = Split(IIf(IsDBNull(drInfoReporte("campos")), "", drInfoReporte("campos")), ",")
            Grupo1 = IIf(IsDBNull(drInfoReporte("grupo1")), "", drInfoReporte("grupo1").ToString.Trim)
            Grupo2 = IIf(IsDBNull(drInfoReporte("grupo2")), "", drInfoReporte("grupo2").ToString.Trim)
            Grupo3 = IIf(IsDBNull(drInfoReporte("grupo3")), "", drInfoReporte("grupo3").ToString.Trim)
            MostrarDetalle = IIf(IsDBNull(drInfoReporte("mostrar_detalle")), 0, drInfoReporte("mostrar_detalle"))
            MostrarResumen = IIf(IsDBNull(drInfoReporte("mostrar_resumen")), 0, drInfoReporte("mostrar_resumen"))


            Dim x As Integer
            Dim Columnas(5) As DataColumn

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reloj", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("campo", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("valor", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("grupo1", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("grupo2", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("grupo3", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            Dim G1 As String = ""
            Dim G2 As String = ""
            Dim G3 As String = ""
            Dim Valor As String = ""
            Dim dr As DataRow

            For Each dRow As DataRow In dtDatosReporte.Rows
                If Grupo1 = "<Ninguno>" Then
                    G1 = ""
                Else
                    dr = dtCampos.Rows.Find(Grupo1)
                    If IsNothing(dr) Then
                        G1 = Grupo1 & " " & dRow(Grupo1)
                    Else
                        G1 = dr.Item("nombre").ToString.Trim & " " & dRow(Grupo1)
                    End If
                End If
                If Grupo2 = "<Ninguno>" Then
                    G2 = ""
                Else
                    dr = dtCampos.Rows.Find(Grupo2)
                    If IsNothing(dr) Then
                        G2 = Grupo2 & " " & dRow(Grupo2)
                    Else
                        G2 = dr.Item("nombre").ToString.Trim & " " & dRow(Grupo2)
                    End If
                End If
                If Grupo3 = "<Ninguno>" Then
                    G3 = ""
                Else
                    dr = dtCampos.Rows.Find(Grupo3)
                    If IsNothing(dr) Then
                        G3 = Grupo3 & " " & dRow(Grupo3)
                    Else
                        G3 = dr.Item("nombre").ToString.Trim & " " & dRow(Grupo3)
                    End If
                End If
                For x = 0 To UBound(Campos)
                    dr = dtCampos.Rows.Find(Campos(x))
                    If Not IsNothing(dr) Then
                        If dr("tipo").ToString.Trim = "num" Then
                            Try
                                Valor = String.Format("{0:0.00}", dRow(Campos(x)))
                            Catch ex As Exception
                                Valor = String.Format("{0:0.00}", 0)
                            End Try
                        Else
                            Valor = IIf(IsDBNull(dRow(Campos(x))), "", dRow(Campos(x)))
                        End If
                    Else
                        Valor = IIf(IsDBNull(dRow(Campos(x))), "", dRow(Campos(x)))
                    End If
                    dtDatos.Rows.Add({dRow("reloj"), dr("NOMBRE").ToString.Trim, Valor, G1, G2, G3})
                Next
            Next

            'Limpiar el ReportViewer, por si hubiera algún reporte cargado
            vwrReportes.Clear()
            'Indicar que se ejecutarán reportes de forma local (no desde servidor SSRS)
            vwrReportes.ProcessingMode = ProcessingMode.Local
            vwrReportes.LocalReport.ReportPath = Reporte
            vwrReportes.LocalReport.DataSources.Clear()

            vwrReportes.LocalReport.DataSources.Add(New ReportDataSource("Datos", dtDatos))
            vwrReportes.LocalReport.DataSources.Add(New ReportDataSource("Compañía", dtCompa))

            Dim Parametros(0) As ReportParameter

            Parametros(0) = New ReportParameter("TITULO", Titulo)


            vwrReportes.LocalReport.EnableExternalImages = True
            vwrReportes.LocalReport.SetParameters(Parametros)
            vwrReportes.RefreshReport()

            Me.ShowDialog()

        Catch ex As Exception
            Debug.Print(ex.Message & vbCrLf & ex.StackTrace)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Application.DoEvents()
        End Try

    End Sub

    Public Function EmitirRecibos(ByVal Nombre As String, ByVal Impresora As String, ByVal dtInformacion As DataTable, ByVal Filtro As String, ByVal Orden As String, ByVal Folio As Integer, Optional ByVal VistaPrevia As Boolean = False, Optional ByVal DatoExportacion As String = "") As Boolean
        Try
            Dim dtRecibos As New DataTable

            Try
                'Incluir referencia System.Data.DataSetExtensions para poder utilizar el CopyToDataTable
                dtRecibos = dtInformacion.Select(Filtro, Orden).CopyToDataTable
                For Each dRow As DataRow In dtRecibos.Rows
                    dRow("folio") = Folio.ToString.PadLeft(5, "0")
                    dRow("cod_tipo") = Strings.Left(dRow("cod_tipo"), 1)
                    Folio += 1
                Next
                dtRecibos.PrimaryKey = New DataColumn() {dtRecibos.Columns("nombres")}
                '== En esta linea de código ocurre un error cuando se ingresa desde la forma "frmNómina"            18nov2021
                Try : dtRecibosGlobal.Merge(dtRecibos.DefaultView.ToTable(False, "folio", "reloj", "nombres", "cod_depto", "periodo", "cod_tipo")) : Catch ex As Exception : End Try

            Catch ex As Exception
                Return False
            End Try
            Dim Reporte As String = DireccionReportes & Nombre & ".rdl"
            Application.DoEvents()


            vwrReportes.Clear()
            'Indicar que se ejecutarán reportes de forma local (no desde servidor SSRS)
            vwrReportes.LocalReport.EnableExternalImages = True
            vwrReportes.ProcessingMode = ProcessingMode.Local
            vwrReportes.LocalReport.ReportPath = Reporte
            vwrReportes.LocalReport.DataSources.Clear()
            vwrReportes.LocalReport.DataSources.Add(New ReportDataSource("Datos", dtRecibos))
            vwrReportes.RefreshReport()

            If (Not VistaPrevia) Then

                If DatoExportacion.Trim.Length > 0 Then 'Proceso que guarda el documento pdf en la ruta path_recibos para luego mandarlo por correo
                    ExportarReciboPDF(DatoExportacion)
                Else
                    Dim pr As New ImprimirReportViewer
                    pr.Run(vwrReportes.LocalReport, Impresora)
                End If
                Return False
            Else
                Me.ShowDialog()
            End If

            Return True
        Catch ex As Exception
            Return False
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Function

    Private Sub ExportarReciboPDF(PathReciboPDF As String)
        'Crear archivo PDF
        Dim warnings As Warning() = Nothing
        Dim streamids As String() = Nothing
        Dim mimeType As String = Nothing
        Dim encoding As String = Nothing
        Dim extension As String = Nothing
        Dim bytes As Byte()
        Dim FilePath As String = PathReciboPDF
        ' Dim FilePath As String = PathRecursos + "recibos_pdf\" + Info + ".pdf"
        bytes = vwrReportes.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)
        Dim fs As New FileStream(FilePath, FileMode.Create)
        fs.Write(bytes, 0, bytes.Length)
        fs.Close()
    End Sub

    Private Sub vwrReportes_Load(sender As Object, e As EventArgs) Handles vwrReportes.Load

    End Sub


End Class