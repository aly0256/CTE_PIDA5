﻿Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms

Public Class ImprimirReportViewer
    Implements IDisposable
    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)

    Private Function LoadSalesData() As DataTable
        ' Create a new DataSet and read sales data file 
        ' data.xml into the first DataTable.
        Dim dataSet As New DataSet()
        dataSet.ReadXml("..\..\data.xml")
        Return dataSet.Tables(0)
    End Function

    ' Routine to provide to the report renderer, in order to
    ' save an image for each page of the report.
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function

    ' Export the given report as an EMF (Enhanced Metafile) file.
    Private Sub Export(ByVal report As LocalReport)
        Dim deviceInfo As String = "<DeviceInfo>" & _
            "<OutputFormat>EMF</OutputFormat>" & _
            "<PageWidth>" & PageWidth & "in</PageWidth>" & _
            "<PageHeight>" & PageHeight & "in</PageHeight>" & _
            "<MarginTop>" & TopMargin & "in</MarginTop>" & _
            "<MarginLeft>" & LeftMargin & "in</MarginLeft>" & _
            "<MarginRight>" & RightMargin & "in</MarginRight>" & _
            "<MarginBottom>" & BottomMargin & "in</MarginBottom>" & _
            "</DeviceInfo>"
        Dim warnings As Warning()
        warnings = Nothing
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        For Each stream As Stream In m_streams
            stream.Position = 0
        Next
    End Sub

    ' Handler for PrintPageEvents
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

        ' Adjust rectangular area with printer margins.
        Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX), _
                                          ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY), _
                                          ev.PageBounds.Width, _
                                          ev.PageBounds.Height)

        ' Draw a white background for the report
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

        ' Draw the report content
        ev.Graphics.DrawImage(pageImage, adjustedRect)

        ' Prepare for the next page. Make sure we haven't hit the end.
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Sub Print(ByVal PrinterName As String)
        If m_streams Is Nothing OrElse m_streams.Count = 0 Then
            Throw New Exception("Error: no stream to print.")
        End If
        Dim printDoc As New PrintDocument()
        printDoc.PrinterSettings.PrinterName = PrinterName
        If Not printDoc.PrinterSettings.IsValid Then
            Throw New Exception("Error: cannot find the default printer.")
        Else
            AddHandler printDoc.PrintPage, AddressOf PrintPage
            m_currentPageIndex = 0
            ' printDoc.PrinterSettings.DefaultPageSettings.PaperSize = PrinterSettings.PaperSizeCollection  legal
            printDoc.DefaultPageSettings.Landscape = landscape
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("LegalRecibos", PageWidth * 100, PageHeight * 100)
            printDoc.DefaultPageSettings.Margins.Top = TopMargin * 100
            printDoc.Print()
        End If
    End Sub

    ' Create a local report for Report.rdlc, load the data,
    ' export the report to an .emf file, and print it.
    Public Sub Run(report As LocalReport, printerName As String)
        'Dim report As New LocalReport()
        'report.ReportPath = "..\..\Report.rdlc"
        'report.DataSources.Add(New ReportDataSource("Sales", LoadSalesData()))
        Export(report)
        Print(printerName)
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If m_streams IsNot Nothing Then
            For Each stream As Stream In m_streams
                stream.Close()
            Next
            m_streams = Nothing
        End If
    End Sub

    Public Shared Sub Main(ByVal args As String())
        'Using ImprimirReportViewer As New ImprimirReportViewer()
        '    'ImprimirReportViewer.Run()
        'End Using
    End Sub
End Class