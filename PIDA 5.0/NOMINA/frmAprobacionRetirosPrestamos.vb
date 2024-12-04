Imports OfficeOpenXml
Imports System.Globalization
Public Class frmAprobacionRetirosPrestamos
    Dim grupo As String
    Dim identificador As String
    Private Sub frmAprobacionRetirosPrestamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim query As String = "" & _
        '    "update prestamos set prestamos.ano= periodos.ano,prestamos.periodo = periodos.periodo " & _
        '    "from prestamos left join periodos  on prestamos.FECHA_SOL >= periodos.FECHA_INI and prestamos.fecha_sol <= periodos.FECHA_FIN AND PERIODos.PERIODO < 53 where prestamos.exportado = 0;" & _
        '    "update retiros set retiros.ano= periodos.ano,retiros.periodo = periodos.periodo " & _
        '    "from retiros left join periodos  on retiros.FECHA_SOL >= periodos.FECHA_INI and retiros.fecha_sol <= periodos.FECHA_FIN AND PERIODos.PERIODO < 53 where retiros.exportado = 0;" & _
        '    "update solicitudes set solicitudes.ano= periodos.ano,solicitudes.periodo = periodos.periodo " & _
        '    "from solicitudes left join periodos  on solicitudes.FECHA_SOL >= periodos.FECHA_INI and solicitudes.fecha_sol <= periodos.FECHA_FIN AND PERIODos.PERIODO < 53 where solicitudes.exportado = 0;"
        'sqlExecute(query)
        ' ActualizarAltaYBajasAhorro()
        RefrescarArbol()
    End Sub
    Private Sub ActualizarAltaYBajasAhorro()
        'Dim queryAltas As String = "" & _
        '                    "select personal.reloj,personal.nombres,'0' as confirmado,'0' as EXPORTADO " & _
        '                    "from personal left join alta_fondo on personal.reloj = alta_fondo.reloj " & _
        '                    "where  PARTICIPA_FONDO = '' and personal.PORC_FONDO = '00' and baja is NULL and datediff(day,alta,GETDATE())>31 and alta_fondo.reloj is NULL"

        'Dim dtAltasFondo As DataTable = sqlExecute(queryAltas)
        'For Each r As DataRow In dtAltasFondo.Rows
        '    Dim id As String
        '    id = Now.TimeOfDay.ToString

        '    sqlExecute("insert into alta_fondo(id,reloj,nombre,confirmado,exportado) values('" + id + "','" + r.Item("reloj") + "','" + r.Item("nombres") + "','0','0')")
        '    Threading.Thread.Sleep(1)
        'Next
        'sqlExecute("delete alta_fondo  from alta_fondo left join personal on alta_fondo.reloj = personal.reloj where personal.baja is not NULL")
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        Try
            grupo = advSolicitudes.SelectedNode.Parent.Parent.Parent.ToString
            identificador = advSolicitudes.SelectedNode.Cells(4).Text

            If MessageBox.Show("¿Estás seguro que eliminarás de la exportación este registro?", "Eliminar registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                If grupo.Equals("RETIRO FONDO DE AHORRO") Then
                    sqlExecute("insert into prestamos_cancelados select id,reloj,nombre,fecha_sol,fecha_rev,cantidad,confirmado,tipo_pago,plazo_semanas,depto,abono,interes,exportado,ano,periodo,'" + FechaSQL(Date.Now) + "' as 'FECHA_CAN','" + Usuario + "' as 'USUARIO_CAN' from prestamos WHERE ID = '" & identificador & "' ;delete from prestamos  where id = '" & identificador & "' and exportado = '0'", "KIOSCO")
                Else
                    MessageBox.Show("El registro seleccionado no puede ser borrado ", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
        End Try
        RefrescarArbol()

    End Sub
    Private Sub RefrescarArbol()

        'ACTUALIZAR ARBOL DE SOLICITUDES
        Dim query As String = "" & _
            "SELECT id , RELOJ,NOMBRE, CONFIRMADO,cast(cantidad as decimal(10,2))as cantidad, exportado,cast(FECHA_SOL as nvarchar) as 'Fecha de Solicitud','RETIRO FONDO DE AHORRO' AS 'Grupo1',ano as 'Grupo2', periodo as 'Grupo3' from prestamos  where confirmado = 1 and exportado = 0 "
        Dim dtArbol As DataTable = sqlExecute(query, "KIOSCO")
        For Each drow As DataRow In dtArbol.Select("Grupo1 = 'RETIRO FONDO DE AHORRO'")

            Dim dttemp As New DataTable
            dttemp = sqlExecute("select *  from pensiones where reloj = '" & drow("reloj") & "'", "KIOSCO")
            If dttemp.Rows.Count > 0 Then
                drow("NOMBRE") = drow("NOMBRE") & " (CON PENSION)"
            End If


        Next


        advSolicitudes.DataSource = dtArbol
        'AdvTree1.DisplayMembers = "reloj,nombre,Fecha de Solicitud,id"
        '  AdvTree1.ValueMember = "ID"
        advSolicitudes.GroupingMembers = "Grupo1,Grupo2,Grupo3"
        For Each n As DevComponents.AdvTree.Node In advSolicitudes.Nodes
            If n.Text = "RETIRO FONDO DE AHORRO" Then
                For Each k As DevComponents.AdvTree.Node In n.Nodes
                    For Each l As DevComponents.AdvTree.Node In k.Nodes
                        For Each m As DevComponents.AdvTree.Node In l.Nodes
                            m.CheckBoxVisible = True
                            If m.Cells(5).Text = "1" Then
                                m.Checked = True
                            End If
                        Next
                    Next
                Next
            End If
        Next
        'ACTUALIZAR ARBOL DE CANCELACIONESS
        query = "" & _
            "SELECT id , RELOJ,NOMBRE, CONFIRMADO,usuario_can, exportado,cast(FECHA_CAN as nvarchar) as 'Fecha de cancelación','RETIROS FONDO DE AHORRO' AS 'Grupo1',ano as 'Grupo2', periodo as 'Grupo3' from prestamos_cancelados "
        dtArbol = sqlExecute(query, "KIOSCO")
        advCancelaciones.DataSource = dtArbol
        advCancelaciones.GroupingMembers = "Grupo1,Grupo2,Grupo3"
    End Sub
    Private Sub AdvTree1_NodeDoubleClick(sender As Object, e As EventArgs)
        'On Error Resume Next
        'For Each n As DevComponents.AdvTree.Node In advSolicitudes.CheckedNodes
        '    MessageBox.Show(n.ToString.Split(",").Last)
        'Next
    End Sub

    Public Function ElegirDirectorio() As String
        Dim fbd As FolderBrowserDialog = New FolderBrowserDialog
        Dim path As String = "NO"
        If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            path = fbd.SelectedPath

        End If
        Return path
    End Function
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim dtPrestamos As New DataTable
        Dim dtRetiros As New DataTable
        Dim dtItems As New DataTable
        Dim dtAltasFondo As New DataTable
        Dim dtTemp As New DataTable
        Dim directorio As String = ""

        Dim ano As String = ""
        Dim periodo As String = ""


        Dim dtArchivoExcel As New DataTable
        dtArchivoExcel.Columns.Add("tipo_movimiento")
        dtArchivoExcel.Columns.Add("tipo_aportacion")
        dtArchivoExcel.Columns.Add("codigo_empleado")
        dtArchivoExcel.Columns.Add("sucursal")
        dtArchivoExcel.Columns.Add("departamento")
        dtArchivoExcel.Columns.Add("importe")
        dtArchivoExcel.Columns.Add("nombre")
        dtArchivoExcel.Columns.Add("fecha")
        dtArchivoExcel.Columns.Add("adicional")
        dtArchivoExcel.Columns.Add("numero_prestamo")
        dtArchivoExcel.Columns.Add("clabe")
        dtArchivoExcel.Columns.Add("id")
        dtArchivoExcel.Columns.Add("fecha_sol")

        Dim dias As Integer = 1

        Try



            directorio = ElegirDirectorio()
            If Not directorio.Equals("NO") Then


                dtPrestamos = sqlExecute("select * from prestamos where reloj = 'ccccc'", "KIOSCO")
                For Each n As DevComponents.AdvTree.Node In advSolicitudes.Nodes
                    If n.Text = "RETIRO FONDO DE AHORRO" Then
                        For Each k As DevComponents.AdvTree.Node In n.Nodes
                            For Each l As DevComponents.AdvTree.Node In k.Nodes
                                For Each m As DevComponents.AdvTree.Node In l.Nodes
                                    If m.Checked Then
                                        dtTemp = sqlExecute("select * from prestamos where reloj = '" + m.Cells(0).Text + "' and id= '" + m.Cells(4).Text + "' and exportado='0'", "KIOSCO")
                                        If dtTemp.Rows.Count > 0 Then
                                            ' dtPrestamos.ImportRow(dtTemp.Rows(0))
                                            Dim drAbonoPrestamo As DataRow = dtArchivoExcel.NewRow
                                            drAbonoPrestamo("tipo_movimiento") = "5"
                                            drAbonoPrestamo("tipo_aportacion") = "S"
                                            drAbonoPrestamo("codigo_empleado") = dtTemp.Rows(0).Item("reloj")
                                            drAbonoPrestamo("sucursal") = ""
                                            drAbonoPrestamo("departamento") = ""
                                            drAbonoPrestamo("importe") = dtTemp.Rows(0).Item("cantidad")
                                            drAbonoPrestamo("nombre") = dtTemp.Rows(0).Item("nombre")
                                            Do While DiaSem(Date.Now.AddDays(dias)) <> "Miércoles"

                                                dias = dias + 1

                                            Loop


                                            drAbonoPrestamo("fecha") = FechaSQL(Now.AddDays(dias))
                                            drAbonoPrestamo("adicional") = ""
                                            drAbonoPrestamo("numero_prestamo") = ""
                                            drAbonoPrestamo("clabe") = dtTemp.Rows(0).Item("clabe")
                                            drAbonoPrestamo("id") = dtTemp.Rows(0).Item("id")
                                            drAbonoPrestamo("fecha_sol") = dtTemp.Rows(0).Item("fecha_sol")
                                            dtArchivoExcel.Rows.Add(drAbonoPrestamo)


                                        End If
                                    End If
                                Next
                            Next
                        Next


                    End If
                Next


                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook
                'VectorFahCSV(nombre_archivo, dtArchivoExcel)
                VectorFahCSV(directorio & "\BRP Retiros fah Vector.xlsx", dtArchivoExcel, wb)
                archivo.SaveAs(New System.IO.FileInfo(directorio & "\BRP Retiros fah Vector.xlsx"))

                Dim archivo2 As ExcelPackage = New ExcelPackage()
                Dim wb2 As ExcelWorkbook = archivo2.Workbook
                'VectorFahCSV(nombre_archivo, dtArchivoExcel)
                RetiroFahSem(directorio & "\BRP RETIROS SEMANALES.xlsx", dtArchivoExcel, wb2)
                archivo2.SaveAs(New System.IO.FileInfo(directorio & "\BRP RETIROS SEMANALES.xlsx"))



                'If System.IO.File.Exists("BRPPRESTAMOS.txt") Then
                '    System.IO.File.Delete("BRPPRESTAMOS.txt")
                'End If
                If dtArchivoExcel.Rows.Count > 0 Then
                    'For Each r As DataRow In dtPrestamos.Rows
                    '    RegistrarPrestamo(r)
                    'Next
                    frmVistaPrevia.LlamarReporte("Resumen de prestamos", dtArchivoExcel)
                    frmVistaPrevia.ShowDialog()

                    For Each r As DataRow In dtArchivoExcel.Rows
                        sqlExecute("update prestamos set EXPORTADO = '1', fecha_export = getdate() WHERE CONFIRMADO ='1' and EXPORTADO='0' and reloj = '" + r.Item("codigo_empleado").ToString.Trim + "' and id='" + r.Item("id").ToString.Trim + "'", "KIOSCO")
                    Next
                    ActivityLog(Usuario, "EXPORTACION DE RETIROS", "", "")
                    'RefrescarArbol()
                End If





                RefrescarArbol()
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub RetiroFahSem(nombre_archivo As String, dtCSV As DataTable, ByRef wb As ExcelWorkbook)
        Dim x As Integer = 1
        Dim y As Integer = 1
        Dim hoja As String() = nombre_archivo.Split("\")
        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(hoja(hoja.Length - 1))

        hoja_excel.Cells(x, y).Value = "NUMPROM"
        hoja_excel.Cells(x, y).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 1).Value = "CONTRATO"
        hoja_excel.Cells(x, y + 1).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 2).Value = "BANCODE"
        hoja_excel.Cells(x, y + 2).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 3).Value = "CTACHEQUDE"
        hoja_excel.Cells(x, y + 3).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 4).Value = "BENEFICIARIO"
        hoja_excel.Cells(x, y + 4).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 5).Value = "MONTO"
        hoja_excel.Cells(x, y + 5).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 6).Value = "INSTRUCCION"
        hoja_excel.Cells(x, y + 6).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 7).Value = "No. DE EMPLEADO"
        hoja_excel.Cells(x, y + 7).Style.Font.Bold = True
  
        x = x + 1

        Dim dtBancosClabe As DataTable = sqlExecute("select * from bancos_clabe where vector is not null")


        For Each drAbonoPrestamo As DataRow In dtCSV.Rows

            Dim banco_vector As String = "X"

            Try
                Dim clabe3 As String = drAbonoPrestamo("clabe").ToString.Substring(0, 3)
                For Each row As DataRow In dtBancosClabe.Select("cod_banco = '" & clabe3 & "'")
                    banco_vector = row("vector").ToString
                Next
            Catch ex As Exception

            End Try



            hoja_excel.Cells(x, y).Value = "1616"
            hoja_excel.Cells(x, y + 1).Value = "170182"
            hoja_excel.Cells(x, y + 2).Value = banco_vector
            hoja_excel.Cells(x, y + 3).Value = drAbonoPrestamo("clabe")
            hoja_excel.Cells(x, y + 4).Value = drAbonoPrestamo("nombre").ToString.Replace("/", "")
            hoja_excel.Cells(x, y + 5).Value = Convert.ToDouble(drAbonoPrestamo("importe"))
            hoja_excel.Cells(x, y + 6).Value = "DEBE"
            hoja_excel.Cells(x, y + 7).Value = drAbonoPrestamo("codigo_empleado")
            x = x + 1
        Next


        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

    End Sub

    Private Sub VectorFahCSV(nombre_archivo As String, dtCSV As DataTable, ByRef wb As ExcelWorkbook)
        Try

            ' Reporte a detalle Excel
            Dim x As Integer = 1
            Dim y As Integer = 1
            Dim hoja As String() = nombre_archivo.Split("\")
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(hoja(hoja.Length - 1))
            'hoja_excel.Cells(x, y).Value = "Mov"
            'hoja_excel.Cells(x, y).Style.Font.Bold = True
            'hoja_excel.Cells(x, y + 1).Value = "Apo"
            'hoja_excel.Cells(x, y + 1).Style.Font.Bold = True
            'hoja_excel.Cells(x, y + 2).Value = "Codigo de Empleado"
            'hoja_excel.Cells(x, y + 2).Style.Font.Bold = True
            'hoja_excel.Cells(x, y + 3).Value = "Suc"
            'hoja_excel.Cells(x, y + 3).Style.Font.Bold = True
            'hoja_excel.Cells(x, y + 4).Value = "Dp"
            'hoja_excel.Cells(x, y + 4).Style.Font.Bold = True
            'hoja_excel.Cells(x, y + 5).Value = "Importe"
            'hoja_excel.Cells(x, y + 5).Style.Font.Bold = True
            'hoja_excel.Cells(x, y + 6).Value = "Nombre"
            'hoja_excel.Cells(x, y + 6).Style.Font.Bold = True
            'hoja_excel.Cells(x, y + 7).Value = "Fecha"
            'hoja_excel.Cells(x, y + 7).Style.Font.Bold = True
            'hoja_excel.Cells(x, y + 8).Value = "Adicional"
            'hoja_excel.Cells(x, y + 8).Style.Font.Bold = True
            'hoja_excel.Cells(x, y + 9).Value = "No. Pago Prest"
            'hoja_excel.Cells(x, y + 9).Style.Font.Bold = True
            'x = x + 1

            For Each drAbonoPrestamo As DataRow In dtCSV.Rows
                hoja_excel.Cells(x, y).Value = Convert.ToInt32(drAbonoPrestamo("tipo_movimiento"))
                hoja_excel.Cells(x, y + 1).Value = drAbonoPrestamo("tipo_aportacion")
                hoja_excel.Cells(x, y + 2).Value = Convert.ToInt32(drAbonoPrestamo("codigo_empleado"))
                hoja_excel.Cells(x, y + 3).Value = drAbonoPrestamo("sucursal")
                hoja_excel.Cells(x, y + 4).Value = drAbonoPrestamo("departamento")
                hoja_excel.Cells(x, y + 5).Value = Convert.ToDouble(drAbonoPrestamo("importe"))
                hoja_excel.Cells(x, y + 6).Value = drAbonoPrestamo("nombre")
                hoja_excel.Cells(x, y + 7).Value = Date.Parse(drAbonoPrestamo("fecha")).ToShortDateString
                hoja_excel.Cells(x, y + 8).Value = drAbonoPrestamo("adicional")
                hoja_excel.Cells(x, y + 9).Value = drAbonoPrestamo("numero_prestamo")
                x = x + 1
            Next


            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()
            ''Dim oWrite As System.IO.StreamWriter
            ''Try
            ''    oWrite = File.CreateText(nombre_archivo)

            ''    Dim reloj_actual As String = ""

            ''    Try

            ''        For Each drAbonoPrestamo As DataRow In dtCSV.Rows

            ''            Dim linea As String = ""


            ''            linea &= drAbonoPrestamo("tipo_movimiento") & ","
            ''            linea &= drAbonoPrestamo("tipo_aportacion") & ","
            ''            linea &= drAbonoPrestamo("codigo_empleado") & ","
            ''            linea &= drAbonoPrestamo("sucursal") & ","
            ''            linea &= drAbonoPrestamo("departamento") & ","
            ''            linea &= drAbonoPrestamo("importe") & ","
            ''            linea &= drAbonoPrestamo("nombre") & ","
            ''            linea &= drAbonoPrestamo("fecha")

            ''            oWrite.WriteLine(linea)

            ''        Next
            ''    Catch ex As Exception
            ''        oWrite.WriteLine(reloj_actual & Space(1) & ex.Message)
            ''    End Try

            ''    oWrite.Close()
            ''Catch ex As Exception
            ''    oWrite = Nothing
            ''End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RegistrarDescuento(tabla As DataRow)
        'Dim cadena As String = ""
        'cadena = cadena + tabla.Item("RELOJ").ToString.Substring(1)
        'cadena = cadena + "04"
        'cadena = cadena & Date.Now.Year.ToString & Date.Now.Month.ToString.PadLeft(2, "0") & Date.Now.Day.ToString.PadLeft(2, "0")
        'cadena = cadena + "       "
        'cadena = cadena + "00"
        'cadena = cadena + (tabla.Item("CANTIDAD") * 100).ToString.PadLeft(9, "0")
        'cadena = cadena + "        "
        'cadena = cadena + " "
        'EscribirArchivo(cadena, "BRPDESCUENTOS.txt")
    End Sub
    Private Sub RegistrarPrestamo(tabla As DataRow)
        '    Dim cadena As String = ""
        '    cadena = cadena + tabla.Item("RELOJ").ToString.Trim
        '    cadena = cadena + "08"
        '    cadena = cadena & Date.Now.Year.ToString & Date.Now.Month.ToString.PadLeft(2, "0") & Date.Now.Day.ToString.PadLeft(2, "0")
        '    ' cadena = cadena + tabla.Item("INTERES").ToString.Replace(".", "").PadLeft(7, "0")
        '    cadena = cadena + Format(tabla.Item("INTERES"), "f").ToString.Replace(".", "").PadLeft(7, "0")
        '    cadena = cadena + tabla.Item("PLAZO_SEMANAS").ToString.PadLeft(2, "0")
        '    cadena = cadena + (tabla.Item("CANTIDAD") * 100).ToString.PadLeft(9, "0")
        '    cadena = cadena + "        "
        '    cadena = cadena + " "
        '    EscribirArchivo(cadena, "BRPPRESTAMOS.txt")
    End Sub
    Private Sub RegistrarAltaFondo(tabla As DataRow)
        'Dim cadena As String = ""
        'cadena = cadena + tabla.Item("RELOJ").ToString.Trim
        'cadena = cadena + "      "
        'cadena = cadena + "08"
        'EscribirArchivo(cadena, "BRPPORFA.txt")
    End Sub
    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs)
        'ConsultaAhorro.ShowDialog()
        'RefrescarArbol()
    End Sub

    Private Sub AdvTree1_DoubleClick(sender As Object, e As EventArgs) Handles advSolicitudes.DoubleClick
        If advSolicitudes.SelectedNode.Checked Then
            advSolicitudes.SelectedNode.Checked = False
        Else
            advSolicitudes.SelectedNode.Checked = True
        End If
    End Sub


    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        ConsultaAhorro.ShowDialog()
        RefrescarArbol()
    End Sub
End Class