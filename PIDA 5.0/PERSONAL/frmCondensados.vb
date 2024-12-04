Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing

Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports System.Windows.Forms


Public Class frmCondensados

    Public dtCondensados As New DataTable
    Public dtInfo As New DataTable
    Public condensado As String
    Private generarVistaPrevia As Boolean = False

    Dim dtReportesCondensado As DataTable


    Private Sub frmCondensados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtCondensados = sqlExecute("select tipo, nombre  from reportes where tipo = 'Z'")
            comboCondensados.DataSource = dtCondensados
            comboCondensados.ValueMember = "nombre"

            dgvReportesCondensado.AutoGenerateColumns = False

            ListarImpresoras()

            RadioButton2.Checked = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListarImpresoras()
        Dim i As Integer
        Dim pkInstalledPrinters As String
        Dim ndImpresora As DevComponents.AdvTree.Node
        Dim prtdoc As New PrintDocument
        Dim strDefaultPrinter As String = prtdoc.PrinterSettings.PrinterName
        Try

            For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
                ndImpresora = New DevComponents.AdvTree.Node
                ndImpresora.Name = "Impresora" & i
                ndImpresora.Text = pkInstalledPrinters
                ndImpresora.Image = My.Resources.Printer16

                cmbImpresoras.Nodes.Add(ndImpresora)

                If pkInstalledPrinters = strDefaultPrinter Then
                    cmbImpresoras.SelectedIndex = cmbImpresoras.Nodes.IndexOf(ndImpresora)
                End If
            Next
        Catch ex As Exception
            Stop
        End Try
    End Sub


    Public Sub MostrarInformacion()
        If condensado <> "" Then
            comboCondensados.SelectedValue = condensado
        Else
            Exit Sub

        End If
    End Sub


    Private Sub comboCondensados_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboCondensados.SelectedValueChanged
        Try
            dgvReportesCondensado.AutoGenerateColumns = False
            dtReportesCondensado = sqlExecute("select * from condensados where nombreCondensado = '" & comboCondensados.SelectedValue & "' order by orden asc")
            dgvReportesCondensado.DataSource = dtReportesCondensado
        Catch ex As Exception

        End Try
    End Sub


    Structure ReporteCondensado
        Public NombreDelReporte As String
        Public detalle As String

        Public PageHeight As Double
        Public PageWidth As Double

        Public TopMargin As Double
        Public BottomMargin As Double
        Public LeftMargin As Double
        Public RightMargin As Double

        Public landscape As Boolean

        Public filtro As String

    End Structure

    Dim m_streams As IList(Of Stream) = New List(Of Stream)()
    Private m_currentPageIndex As Integer = 0

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        Try
            btnGenerarReporte.Enabled = False

            Dim ReportesAGenerar As New ArrayList
            Dim DatosDelCondensado As DataTable = dtInfo.Copy
            Dim ContratoNew As frmContratos = New frmContratos("Condensado")

            Dim DocumentoFinal As New PrintDocument


            Dim warnings As Warning()
            warnings = Nothing
            m_streams = New List(Of Stream)()
            m_currentPageIndex = 0


            Dim hayContratos As Boolean = False
            'obtener nombres y tipo de los reportes a generar a generar
            For Each row As DataGridViewRow In dgvReportesCondensado.Rows
                Try
                    If row.Cells("marcarImpresion").Value Then

                        Dim r As New ReporteCondensado
                        r.NombreDelReporte = row.Cells("nombreReporte").Value

                        Dim drow As DataRow = dtReportesCondensado.Select("nombreReporte = '" & r.NombreDelReporte & "'")(0)

                        If r.NombreDelReporte.ToUpper.Contains("CONTRATO") Then
                            hayContratos = True
                        End If

                        r.filtro = RTrim(drow("filtro"))

                        r.TopMargin = drow("top")
                        r.BottomMargin = drow("bottom")
                        r.LeftMargin = drow("left")
                        r.RightMargin = drow("right")

                        r.landscape = drow("landscape")

                        If r.landscape Then
                            r.PageHeight = 8.5
                            r.PageWidth = 11
                        Else
                            r.PageHeight = 11
                            r.PageWidth = 8.5
                        End If

                        ReportesAGenerar.Add(r)
                    End If
                Catch ex As Exception
                End Try
            Next

            If hayContratos Then
                If MessageBox.Show("Se generarán " & DatosDelCondensado.Rows.Count & " contratos." & vbCrLf & "¿Es correcto?", "Contratos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                    btnGenerarReporte.Enabled = True
                    btnCerrar.PerformClick()
                    Exit Sub
                End If
            End If
            

            '*******PREGUNTAR POR EL TIPO DE CONTRATO***************
            For Each i As ReporteCondensado In ReportesAGenerar
                If i.NombreDelReporte.ToString.Equals("Contrato") Then
                    ContratoNew.ShowDialog()
                End If
            Next

            ToolStripProgressBar1.Maximum = DatosDelCondensado.Rows.Count * ReportesAGenerar.Count
            ToolStripProgressBar1.Value = 0


            For Each row As DataRow In DatosDelCondensado.Rows

                Dim dt As DataTable = DatosDelCondensado.Clone
                dt.ImportRow(row)

                For Each reporte As ReporteCondensado In ReportesAGenerar

                    If dt.Rows.Count > 0 Then

                        Try

                            Dim deviceInfo As String =
                               "<DeviceInfo>" & _
                                   "<OutputFormat>EMF</OutputFormat>" & _
                                   "<PageWidth>" & reporte.PageWidth & "in</PageWidth>" & _
                                   "<PageHeight>" & reporte.PageHeight & "in</PageHeight>" & _
                                   "<MarginTop>" & reporte.TopMargin & "in</MarginTop>" & _
                                   "<MarginLeft>" & reporte.LeftMargin & "in</MarginLeft>" & _
                                   "<MarginRight>" & reporte.RightMargin & "in</MarginRight>" & _
                                   "<MarginBottom>" & reporte.BottomMargin & "in</MarginBottom>" & _
                               "</DeviceInfo>"

                            If reporte.NombreDelReporte.Equals("Contrato") Then
                                ContratoNew.GeneraContrato(dt)
                            Else
                                frmVistaPrevia.LlamarReporte(reporte.NombreDelReporte, dt, , , , , , , True)
                            End If

                            ReporteTMP.Render("Image", deviceInfo, AddressOf CreateStream, warnings)

                            Try
                                ToolStripStatusLabel1.Text = row("reloj") & " - " & IIf(reporte.NombreDelReporte.Length > 30, reporte.NombreDelReporte.Substring(0, 25) & "...", reporte.NombreDelReporte)
                                ToolStripProgressBar1.Value += 1
                                Application.DoEvents()
                            Catch ex As Exception

                            End Try
                        Catch ex As Exception

                        End Try
                    End If
                Next

            Next

            ToolStripStatusLabel1.Text = ""
            ToolStripProgressBar1.Value = 0

            'Export
            If m_streams Is Nothing Then
                Throw New Exception("Error: no hay información por imprimir.")
            Else
                DocumentoFinal.PrinterSettings.PrinterName = cmbImpresoras.Text


                If Not DocumentoFinal.PrinterSettings.IsValid Then
                    Throw New Exception("Error: la impresora no fue localizada.")
                Else
                    AddHandler DocumentoFinal.PrintPage, AddressOf PrintPage
                    AddHandler DocumentoFinal.QueryPageSettings, AddressOf MyPrintQueryPageSettingsEvent
                    AddHandler DocumentoFinal.BeginPrint, AddressOf beginprint

                End If

                Dim prev As New PrintPreviewDialog
                prev.ShowIcon = False
                prev.PrintPreviewControl.Columns = 1
                prev.PrintPreviewControl.Rows = 1
                prev.Document = DocumentoFinal
                prev.Width = 600
                prev.Height = 800
                prev.PrintPreviewControl.AutoZoom = True

                prev.ShowDialog()

            End If

            PageHeight = 8.5 : PageWidth = 14 : TopMargin = 0.1 : BottomMargin = 0 : LeftMargin = 0 : RightMargin = 0 : landscape = True

        Catch ex As Exception
            PageHeight = 8.5 : PageWidth = 14 : TopMargin = 0.1 : BottomMargin = 0 : LeftMargin = 0 : RightMargin = 0 : landscape = True
            btnGenerarReporte.Enabled = True
            Debug.Print(ex.Message)
        End Try

        btnGenerarReporte.Enabled = True
        
    End Sub

    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function

    ' Handler for PrintPageEvents
    Private Sub beginprint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        Try
            For Each stream As Stream In m_streams
                stream.Position = 0
            Next
            m_currentPageIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    ' Handler for PrintPageEvents
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Try
            Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

            Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX), _
                                              ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY), _
                                              (pageImage.Width - 1) / 3, _
                                              (pageImage.Height - 1) / 3)


            ev.Graphics.FillRectangle(Brushes.White, adjustedRect)
            ev.Graphics.DrawImage(pageImage, adjustedRect)

            m_currentPageIndex += 1
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
        Catch ex As Exception

        End Try
    End Sub

    ' Handler for PrintPageEvents
    Private Sub MyPrintQueryPageSettingsEvent(ByVal sender As Object, ByVal e As QueryPageSettingsEventArgs)
        Try
            Dim pageImage As New Metafile(m_streams(m_currentPageIndex))
            m_streams(m_currentPageIndex).Position = 0

            e.PageSettings.Landscape = IIf(pageImage.Width > pageImage.Height, True, False)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvReportesCondensado_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvReportesCondensado.ColumnHeaderMouseClick
        Try

            If e.ColumnIndex = 4 Then

                Dim seleccionarTodo As Boolean = True

                For Each row As DataGridViewRow In dgvReportesCondensado.Rows
                    Dim valor As Boolean = (row.Cells("marcarImpresion").Value - 1) * -1
                    seleccionarTodo = seleccionarTodo And valor
                Next

                For Each row As DataGridViewRow In dgvReportesCondensado.Rows
                    If seleccionarTodo Then
                        row.Cells("marcarImpresion").Value = 1
                    Else
                        row.Cells("marcarImpresion").Value = 0
                    End If
                Next

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        generarVistaPrevia = Not RadioButton2.Checked
        cmbImpresoras.Enabled = Not generarVistaPrevia
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        PrintDialog1.AllowPrintToFile = False
        'PrintDialog1.Document
        PrintDialog1.PrinterSettings.PrinterName = cmbImpresoras.Text
        PrintDialog1.ShowDialog()
    End Sub

End Class