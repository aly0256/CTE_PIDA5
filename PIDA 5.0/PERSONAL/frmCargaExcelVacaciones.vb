Imports OfficeOpenXml
Imports System.IO

Public Class frmCargaExcelVacaciones

    Dim dir As String = ""
    Dim archivos As New ArrayList
    Dim dtDias As New DataTable
    Dim dtAdvertencias As New DataTable

    '**************************
    Dim dtSuccess As DataTable
    '**************************

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs)
        Try
            dtDias.Rows.Clear()
            dtAdvertencias.Rows.Clear()

            Dim flb As New FolderBrowserDialog
            If flb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dir = flb.SelectedPath & "\"
            End If

            Dim di As New IO.DirectoryInfo(dir)
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo

          

            archivos.Clear()
            For Each dra In diar1
                If dra.Extension = ".xlsx" Then
                    archivos.Add(dra.FullName)
                Else

                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub advertencia(advertencia As String, archivo As String, reloj As String, fila As Integer)
        Dim dr As DataRow = dtAdvertencias.NewRow
        dr("reloj") = reloj
        dr("archivo") = archivo
        dr("advertencia") = advertencia
        dr("fila") = fila
        dtAdvertencias.Rows.Add(dr)
    End Sub

   


    Private Sub ButtonX3_Click(sender As Object, e As EventArgs)
        Try
            Dim f_ini As Date = DateSerial(2016, 7, 18)
            Dim f_fin As Date = DateSerial(2016, 8, 7)

            Dim sfd As New SaveFileDialog

            sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            sfd.Filter = "Directorios|*.xlsx"
            sfd.FileName = "Advertencias.xlsx"

            If sfd.ShowDialog = DialogResult.OK Then
                Dim fn As String = sfd.FileName
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("Advertencias")

                Dim i As Integer = 1
                Dim j As Integer = 1

                For Each column As DataColumn In dtAdvertencias.Columns
                    hoja_excel.Cells(i, j).Value = column.ColumnName
                    hoja_excel.Cells(i, j).Style.Font.Size = 9
                    hoja_excel.Cells(i, j).Style.Font.Bold = True
                    j += 1
                Next

                i += 1
                For Each row As DataRow In dtAdvertencias.Rows
                    j = 1
                    For Each column As DataColumn In dtAdvertencias.Columns
                        hoja_excel.Cells(i, j).Value = row(column.ColumnName)
                        hoja_excel.Cells(i, j).Style.Font.Size = 9
                        j += 1
                    Next
                    i += 1
                Next
                hoja_excel.Cells.AutoFitColumns()
                archivo.SaveAs(New System.IO.FileInfo(fn))

                Try
                    System.Diagnostics.Process.Start(fn)
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function CreateSheet(p As ExcelPackage, sheetName As String) As ExcelWorksheet
        p.Workbook.Worksheets.Add(sheetName)
        Dim ws As ExcelWorksheet = p.Workbook.Worksheets(1)
        ws.Name = sheetName ' //Setting Sheet's name
        ws.Cells.Style.Font.Size = 9 ' //Default font size for whole sheet
        ws.Cells.Style.Font.Name = "Calibri" ' //Default Font name for whole sheet
        Return ws
    End Function

   

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs)
        Try

            Dim sfd As New SaveFileDialog
            sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            sfd.FileName = "Employee_time_off.csv"
            sfd.Filter = "Archivos CSV|*.csv"

            Dim dtCSV As DataTable = New DataTable

            dtCSV.Columns.Add("reloj", Type.GetType("System.String"))
            dtCSV.Columns.Add("sf_id", Type.GetType("System.String"))
            dtCSV.Columns.Add("tipo", Type.GetType("System.String"))
            dtCSV.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
            dtCSV.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))
            dtCSV.Columns.Add("dias", Type.GetType("System.Int32"))

            dtCSV.PrimaryKey = New DataColumn() {dtCSV.Columns("reloj"), dtCSV.Columns("tipo")}

            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each row As DataRow In dtDias.Select("", "reloj, valor, fecha")
                    Dim reloj As String = row("reloj")
                    Dim sf_id As String = row("sf_id")
                    Dim tipo As String = row("valor")
                    Dim fecha As Date = row("fecha")

                    Dim drow As DataRow = dtCSV.Rows.Find({reloj, tipo})
                    If drow Is Nothing Then
                        drow = dtCSV.NewRow
                        drow("reloj") = reloj
                        drow("sf_id") = sf_id
                        drow("tipo") = tipo
                        drow("fecha_ini") = fecha
                        drow("dias") = 0
                        dtCSV.Rows.Add(drow)
                    End If

                    Dim fecha_ini As Date = drow("fecha_ini")
                    Dim dias As Integer = drow("dias")

                    drow("fecha_fin") = fecha
                    drow("dias") = dias + 1

                Next

                Dim file_name As String = sfd.FileName

                Dim oWrite As System.IO.StreamWriter
                oWrite = File.CreateText(file_name)

                Dim encabezado As String = ""
                encabezado &= "[OPERATOR]" & ","
                encabezado &= "userId" & ","
                encabezado &= "undeterminedEndDate" & ","
                encabezado &= "recurrenceGroup.externalCode" & ","
                encabezado &= "startTime" & ","
                encabezado &= "endTime" & ","
                encabezado &= "deductionQuantity" & ","
                encabezado &= "flexibleRequesting" & ","
                encabezado &= "timeType.externalCode" & ","
                encabezado &= "startDate" & ","
                encabezado &= "endDate" & ","
                encabezado &= "approvalStatus" & ","
                encabezado &= "quantityInDays" & ","
                encabezado &= "quantityInHours" & ","
                encabezado &= "workflowRequestId" & ","
                encabezado &= "cancellationWorkflowRequestId" & ","
                encabezado &= "fractionQuantity" & ","
                encabezado &= "editable" & ","
                encabezado &= "loaStartJobInfoId" & ","
                encabezado &= "loaEndJobInfoId" & ","
                encabezado &= "loaExpectedReturnDate" & ","
                encabezado &= "loaActualReturnDate" & ","
                encabezado &= "externalCode"
                oWrite.WriteLine(encabezado)

                Dim encabezado2 As String = ""
                encabezado2 &= "Supported operators: Delimit Clear" & ","
                encabezado2 &= "User" & ","
                encabezado2 &= "Undetermined End Date(Valid Values : TRUE/FALSE)" & ","
                encabezado2 &= "Employee Time Group.externalCode" & ","
                encabezado2 &= "Start Time" & ","
                encabezado2 &= "End Time" & ","
                encabezado2 &= "Deduction Quantity" & ","
                encabezado2 &= "Flexible Requesting(Valid Values : TRUE/FALSE)" & ","
                encabezado2 &= "timeType" & ","
                encabezado2 &= "Start Date" & ","
                encabezado2 &= "End Date" & ","
                encabezado2 &= "Approval Status" & ","
                encabezado2 &= "Number Of Days" & ","
                encabezado2 &= "Number Of Hours" & ","
                encabezado2 &= "Workflow Request" & ","
                encabezado2 &= "Cancellation Workflow Request" & ","
                encabezado2 &= "Fraction Quantity" & ","
                encabezado2 &= "Editable(Valid Values : TRUE/FALSE)" & ","
                encabezado2 &= "Leave Of Absence Job Info ID (Start)" & ","
                encabezado2 &= "Leave Of Absence Job Info ID (Return To Work)" & ","
                encabezado2 &= "Leave Of Absence Expected Return Date" & ","
                encabezado2 &= "Leave Of Absence Actual Return Date" & ","
                encabezado2 &= "External Code"
                oWrite.WriteLine(encabezado2)

                Dim i As Integer = 1000

                For Each row As DataRow In dtCSV.Rows
                    Dim linea As String = ""

                    linea &= row("reloj") & "," ' [OPERATOR]

                    linea &= row("sf_id") & "," ' userId
                    linea &= "FALSE" & "," ' undeterminedEndDate

                    linea &= "," 'recurrenceGroup.externalCode
                    linea &= "," 'startTime
                    linea &= "," 'startTime

                    If RTrim(row("tipo")) = "V" Then ' deductionQuantity
                        linea &= row("dias") & ","
                    Else
                        linea &= "0" & ","
                    End If

                    linea &= "FALSE" & "," ' flexibleRequesting

                    If RTrim(row("tipo")) = "V" Then ' timeType.externalCode
                        linea &= "J_VAC_HLY" & ","
                    ElseIf RTrim(row("tipo")) = "P" Then
                        linea &= "J_PSV" & ","
                    Else
                        linea &= "ERROR" & ","
                    End If

                    Dim ini As Date = Date.Parse(row("fecha_ini"))
                    Dim fin As Date = Date.Parse(row("fecha_fin"))

                    linea &= ini.Month & "/" & ini.Day & "/" & ini.Year & "," ' startDate
                    linea &= fin.Month & "/" & fin.Day & "/" & fin.Year & "," ' endDate

                    linea &= "APPROVED" & "," ' approvalStatus
                    linea &= row("dias") & "," ' quantityInDays
                    linea &= "9," ' quantityInHours

                    linea &= "," ' workflowRequestId
                    linea &= "," ' cancellationWorkflowRequestId

                    linea &= "1" & "," ' fractionQuantity
                    linea &= "FALSE" & "," ' editable

                    linea &= "," ' loaStartJobInfoId
                    linea &= "," ' loaEndJobInfoId
                    linea &= "," ' loaExpectedReturnDate
                    linea &= "," ' loaActualReturnDate

                    linea &= "IMPORT_" & Now.Month & "/" & Now.Day & "/" & Now.Year & "_TIME_" & i ' externalCode

                    i += 1
                    oWrite.WriteLine(linea)
                Next
                oWrite.Close()

                MessageBox.Show("Archivo creado satisfactoriamente")
                Try
                    System.Diagnostics.Process.Start(New FileInfo(file_name).DirectoryName)
                Catch ex As Exception
                End Try

            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Try

            'Dim fecha_ini As Date = DateSerial(2016, 12, 19)
            'Dim fecha_fin As Date = DateSerial(2017, 1, 8)

            Dim dtExportar As DataTable = sqlExecute("select programacion_vacaciones.*, personalvw.sf_id, personalvw.nombres, personalvw.cod_planta, personalvw.cod_turno, personalvw.cod_depto from programacion_vacaciones left join personal.dbo.personalvw on personalvw.reloj = programacion_vacaciones.reloj where fecha between '" & FechaSQL(f_ini) & "' and '" & FechaSQL(f_fin) & "' and export is null", "TA")

            dtSuccess = New DataTable
            dtSuccess.Columns.Add("reloj")
            dtSuccess.Columns.Add("nombres")

            dtSuccess.Columns.Add("cod_planta")
            dtSuccess.Columns.Add("cod_turno")
            dtSuccess.Columns.Add("cod_depto")

            dtSuccess.Columns.Add("transaccion", Type.GetType("System.Int32"))
            dtSuccess.Columns.Add("sf_id")
            dtSuccess.Columns.Add("tipo")
            dtSuccess.Columns.Add("f_ini")
            dtSuccess.Columns.Add("f_fin")
            dtSuccess.Columns.Add("dias", Type.GetType("System.Int32"))
            dtSuccess.PrimaryKey = New DataColumn() {dtSuccess.Columns("reloj"), dtSuccess.Columns("transaccion")}

            Dim reloj As String = ""
            Dim tipo As String = ""
            Dim transaccion As Int32 = 0
            Dim dias As Int32 = 0
            Dim fecha_ant As Date = Date.MinValue

            Dim consecutivo As Integer = 0

            For Each row As DataRow In dtExportar.Select("", "reloj, fecha")

                consecutivo += 1

                Dim _reloj As String = row("reloj")
                Dim _fecha As Date = row("fecha")
                Dim _tipo As String = row("valor")

                If _reloj <> reloj Then
                    reloj = _reloj
                    tipo = _tipo
                    fecha_ant = _fecha
                    dias = 1
                    transaccion = 1
                ElseIf _tipo <> tipo Then
                    tipo = _tipo
                    fecha_ant = _fecha
                    dias = 1
                    transaccion += 1
                ElseIf _fecha <> fecha_ant.AddDays(1) Then

                    If fecha_ant.DayOfWeek = DayOfWeek.Friday And _fecha.DayOfWeek = DayOfWeek.Monday Then
                        transaccion = transaccion
                        dias += 1
                    Else
                        transaccion += 1
                        dias = 1
                    End If

                    fecha_ant = _fecha

                Else
                    fecha_ant = _fecha
                    dias += 1
                End If

                Dim drow As DataRow = dtSuccess.Rows.Find({reloj, transaccion})

                If chkDiaPorDia.Checked = True Then
                    drow = Nothing
                    transaccion = consecutivo.ToString.PadLeft(10, "0")
                    dias = 1
                End If

                If IsNothing(drow) Then
                    drow = dtSuccess.NewRow
                    drow("reloj") = reloj
                    drow("sf_id") = RTrim(IIf(IsDBNull(row("sf_id")), "", row("sf_id")))
                    drow("nombres") = RTrim(IIf(IsDBNull(row("nombres")), "", row("nombres")))

                    drow("cod_planta") = RTrim(IIf(IsDBNull(row("cod_planta")), "", row("cod_planta")))
                    drow("cod_turno") = RTrim(IIf(IsDBNull(row("cod_turno")), "", row("cod_turno")))
                    drow("cod_depto") = RTrim(IIf(IsDBNull(row("cod_depto")), "", row("cod_depto")))

                    drow("transaccion") = transaccion
                    drow("f_ini") = _fecha
                    drow("f_fin") = _fecha
                    drow("tipo") = valor(tipo)

                    drow("dias") = dias
                    dtSuccess.Rows.Add(drow)

                Else
                    drow("f_fin") = _fecha
                    drow("dias") = dias
                End If


            Next

            dgvExportar.DataSource = dtSuccess

        Catch ex As Exception

        End Try
    End Sub

    Dim PERIODO_VACACIONAL As String = ""

    Dim f_ini As Date = Date.MinValue
    Dim f_fin As Date = Date.MinValue

    Private Sub frmCargaExcelVacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvExportar.AutoGenerateColumns = False
        dgvExcepciones.AutoGenerateColumns = False

        Try
            Dim dtPeriodoVacacional As DataTable = sqlExecute("select * from periodos_vacacionales where activo = '1'", "TA")
            If dtPeriodoVacacional.Rows.Count > 0 Then
                PERIODO_VACACIONAL = dtPeriodoVacacional.Rows(0)("cod_periodo")

                LabelPeriodoVac.Text = dtPeriodoVacacional.Rows(0)("descripcion")
                f_ini = dtPeriodoVacacional.Rows(0)("fecha_ini")
                f_fin = dtPeriodoVacacional.Rows(0)("fecha_fin")
            End If
        Catch ex As Exception

        End Try


        'Excepciones
        Try
            Dim dtExcepcionesCaptura As DataTable = sqlExecute("select * from excepciones_captura where periodo_vacacional = '" & PERIODO_VACACIONAL & "'", "TA")
            dgvExcepciones.Rows.Clear()
            Dim i As Integer = 0
            For Each row As DataRow In dtExcepcionesCaptura.Rows
                dgvExcepciones.Rows.Add()                
                dgvExcepciones.Rows(i).Cells("ColumnUsuario").Value = row("username")
                dgvExcepciones.Rows(i).Cells("ColumnFecha").Value = IIf(IsDBNull(row("fecha_corte")), "2016-12-31", row("fecha_corte"))
                dgvExcepciones.Rows(i).Cells("ColumnHora").Value = IIf(IsDBNull(row("hora_corte")), "13:00", row("hora_corte"))
                i += 1
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Function valor(v As String) As String
        Dim val As String = ""
        Select Case v
            Case "V"
                Return "Q_VAC_HLY"
            Case "P"
                Return "Q_SHUT"
            Case Else
                Return val
        End Select
    End Function

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Try

            Dim separar_planta As Boolean = sbPorPlanta.Value
            Dim separar_turno As Boolean = sbPorTurno.Value
            Dim separar_depto As Boolean = sbPorDepto.Value

            Dim sfd As New SaveFileDialog            
            sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            sfd.FileName = "Employee_time_off.csv"
            sfd.Filter = "Archivos CSV|*.csv"

            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim file_name As String = sfd.FileName

                Dim encabezado As String = ""
                encabezado &= "[OPERATOR]" & ","
                encabezado &= "userId" & ","
                encabezado &= "undeterminedEndDate" & ","
                encabezado &= "recurrenceGroup.externalCode" & ","
                encabezado &= "startTime" & ","
                encabezado &= "endTime" & ","
                encabezado &= "deductionQuantity" & ","
                encabezado &= "flexibleRequesting" & ","
                encabezado &= "timeType.externalCode" & ","
                encabezado &= "startDate" & ","
                encabezado &= "endDate" & ","
                encabezado &= "approvalStatus" & ","
                encabezado &= "quantityInDays" & ","
                encabezado &= "quantityInHours" & ","
                encabezado &= "workflowRequestId" & ","
                encabezado &= "cancellationWorkflowRequestId" & ","
                encabezado &= "comment" & ","
                encabezado &= "fractionQuantity" & ","
                encabezado &= "editable" & ","
                encabezado &= "loaStartJobInfoId" & ","
                encabezado &= "loaEndJobInfoId" & ","
                encabezado &= "loaExpectedReturnDate" & ","
                encabezado &= "loaActualReturnDate" & ","
                encabezado &= "externalCode" & ","
                encabezado &= "cust_AdvancePay.externalCode" & ","
                encabezado &= "workflowInitiatedByAdmin"

                Dim encabezado2 As String = ""
                encabezado2 &= "Supported operators: Delimit Clear" & ","
                encabezado2 &= "User" & ","
                encabezado2 &= "Undetermined End Date(Valid Values : TRUE/FALSE)" & ","
                encabezado2 &= "Employee Time Group.externalCode" & ","
                encabezado2 &= "Start Time" & ","
                encabezado2 &= "End Time" & ","
                encabezado2 &= "Deduction Quantity" & ","
                encabezado2 &= "Flexible Requesting(Valid Values : TRUE/FALSE)" & ","
                encabezado2 &= "timeType" & ","
                encabezado2 &= "Start Date" & ","
                encabezado2 &= "End Date" & ","
                encabezado2 &= "Approval Status" & ","
                encabezado2 &= "Number Of Days" & ","
                encabezado2 &= "Number Of Hours" & ","
                encabezado2 &= "Workflow Request" & ","
                encabezado2 &= "Cancellation Workflow Request" & ","
                encabezado2 &= "Comment" & ","
                encabezado2 &= "Fraction Quantity" & ","
                encabezado2 &= "Editable(Valid Values : TRUE/FALSE)" & ","
                encabezado2 &= "Leave Of Absence Job Info ID (Start)" & ","
                encabezado2 &= "Leave Of Absence Job Info ID (Return To Work)" & ","
                encabezado2 &= "Leave Of Absence Expected Return Date" & ","
                encabezado2 &= "Leave Of Absence Actual Return Date" & ","
                encabezado2 &= "External Code" & ","
                encabezado2 &= "Picklist Value.External Code" & ","
                encabezado2 &= "Workflow Initiated By Admin(Valid Values : TRUE/FALSE)"

                Dim primer_row As DataRow = dtSuccess.Select("", IIf(separar_planta, "cod_planta, ", "") & IIf(separar_turno, "cod_turno, ", "") & IIf(separar_depto, "cod_depto, ", "") & "reloj")(0)

                Dim planta As String = primer_row("cod_planta")
                Dim turno As String = primer_row("cod_turno")
                Dim depto As String = primer_row("cod_depto")

                Dim f_base As String = file_name

                file_name = f_base.Replace(".csv", IIf(separar_planta, "_P" & planta, "") & IIf(separar_turno, "_T" & turno, "") & IIf(separar_depto, "_D" & depto, "") & ".csv")

                Dim oWrite As System.IO.StreamWriter
                oWrite = File.CreateText(file_name)

                oWrite.WriteLine(encabezado)
                oWrite.WriteLine(encabezado2)

                Dim corte As Boolean = False

                Dim i As Integer = 1000
                For Each row As DataRow In dtSuccess.Select("", IIf(separar_planta, "cod_planta, ", "") & IIf(separar_turno, "cod_turno, ", "") & IIf(separar_depto, "cod_depto, ", "") & "reloj")

                    sqlExecute("update programacion_vacaciones set export = getdate() where reloj = '" & row("reloj") & "'", "TA")

                    If separar_planta Then
                        If row("cod_planta") <> planta Then
                            planta = row("cod_planta")
                            corte = True
                        End If
                    End If

                    If separar_turno Then
                        If row("cod_turno") <> turno Then
                            turno = row("cod_turno")
                            corte = True
                        End If
                    End If

                    If separar_depto Then
                        If row("cod_depto") <> depto Then
                            depto = row("cod_depto")
                            corte = True
                        End If
                    End If

                    If corte Then
                        oWrite.Close()

                        file_name = f_base.Replace(".csv", IIf(separar_planta, "_P" & planta, "") & IIf(separar_turno, "_T" & turno, "") & IIf(separar_depto, "_D" & depto, "") & ".csv")

                        oWrite = File.CreateText(file_name)

                        oWrite.WriteLine(encabezado)
                        oWrite.WriteLine(encabezado2)

                        corte = False

                    End If

                    Dim linea As String = ""

                    'linea &= row("reloj") & "," ' [OPERATOR]
                    linea &= "," ' [OPERATOR]

                    linea &= row("sf_id") & "," ' userId
                    linea &= "FALSE" & "," ' undeterminedEndDate

                    linea &= "," 'recurrenceGroup.externalCode
                    linea &= "," 'startTime
                    linea &= "," 'startTime

                    If RTrim(row("tipo")).Contains("VAC") Then ' deductionQuantity
                        linea &= row("dias") & ","
                    Else
                        linea &= "0" & ","
                    End If

                    linea &= "FALSE" & "," ' flexibleRequesting

                    linea &= row("tipo") & "," 'timeType

                    Dim ini As Date = Date.Parse(row("f_ini"))
                    Dim fin As Date = Date.Parse(row("f_fin"))

                    linea &= ini.Month & "/" & ini.Day & "/" & ini.Year & "," ' startDate
                    linea &= fin.Month & "/" & fin.Day & "/" & fin.Year & "," ' endDate

                    linea &= "APPROVED" & "," ' approvalStatus
                    linea &= row("dias") & "," ' quantityInDays
                    linea &= "9," ' quantityInHours

                    linea &= "," ' workflowRequestId
                    linea &= "," ' cancellationWorkflowRequestId
                    linea &= "," ' comment
                    linea &= "1" & "," ' fractionQuantity
                    linea &= "TRUE" & "," ' editable

                    linea &= "," ' loaStartJobInfoId
                    linea &= "," ' loaEndJobInfoId
                    linea &= "," ' loaExpectedReturnDate
                    linea &= "," ' loaActualReturnDate

                    linea &= "IMPORT_" & Now.Month & "/" & Now.Day & "/" & Now.Year & "_T_" & row("reloj") & "_" & row("transaccion") & "," 'externalCode

                    linea &= "," ' cust_AdvancePay
                    linea &= "" ' workflowInitiatedByAdmin

                    i += 1
                    oWrite.WriteLine(linea)
                Next

                oWrite.Close()

                MessageBox.Show("Archivo(s) creado(s) satisfactoriamente", "Archivo creado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Try
                    System.Diagnostics.Process.Start(New FileInfo(file_name).DirectoryName)
                Catch ex As Exception
                End Try

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvExportar_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvExportar.DataBindingComplete
        Try
            If dgvExportar.Rows.Count > 0 Then
                Panel7.Enabled = True
            Else
                Panel7.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvExcepciones_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExcepciones.CellValueChanged
        Try
            Dim celda As String = dgvExcepciones.Columns(e.ColumnIndex).Name
            Dim valor As String = dgvExcepciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Select Case celda
                Case "ColumnUsuario"
                    Dim dtUsuario As DataTable = sqlExecute("select * from appuser where username = '" & valor & "'", "seguridad")
                    If dtUsuario.Rows.Count > 0 Then
                        dgvExcepciones.Rows(e.RowIndex).Cells("ColumnDescripcion").Value = RTrim(dtUsuario.Rows(0)("nombre"))
                        dgvExcepciones.Rows(e.RowIndex).Cells("ColumnFiltro").Value = RTrim(IIf(IsDBNull(dtUsuario.Rows(0)("filtro")), "", dtUsuario.Rows(0)("filtro")))
                        Dim dtExiste As DataTable = sqlExecute("select * from excepciones_captura where username = '" & valor & "' and periodo_vacacional = '" & PERIODO_VACACIONAL & "'", "TA")
                        If dtExiste.Rows.Count <= 0 Then
                            sqlExecute("insert into excepciones_captura (username, autoriza, autorizacion, periodo_vacacional) values ('" & valor & "', '" & Usuario & "', getdate(), '" & PERIODO_VACACIONAL & "')", "TA")
                            dgvExcepciones.Rows(e.RowIndex).Cells("ColumnFecha").Value = Now.Date.AddDays(1)
                            dgvExcepciones.Rows(e.RowIndex).Cells("ColumnHora").Value = 12.0
                        End If
                    End If
                Case "ColumnFecha"
                    Dim username As String = dgvExcepciones.Rows(e.RowIndex).Cells("ColumnUsuario").Value
                    Dim fecha_extension As Date = Date.Parse(valor)
                    Dim dtExiste As DataTable = sqlExecute("select * from excepciones_captura where username = '" & username & "' and periodo_vacacional = '" & PERIODO_VACACIONAL & "'", "TA")
                    If dtExiste.Rows.Count > 0 Then
                        sqlExecute("update excepciones_captura set fecha_corte = '" & FechaSQL(fecha_extension) & "' where username = '" & username & "' and periodo_vacacional = '" & PERIODO_VACACIONAL & "'", "TA")
                    End If
                Case "ColumnHora"
                    Dim username As String = dgvExcepciones.Rows(e.RowIndex).Cells("ColumnUsuario").Value
                    Dim hora_extension As String = DtoH_local(valor.Replace(":", "."))
                    Dim dtExiste As DataTable = sqlExecute("select * from excepciones_captura where username = '" & username & "' and periodo_vacacional = '" & PERIODO_VACACIONAL & "'", "TA")
                    If dtExiste.Rows.Count > 0 Then
                        sqlExecute("update excepciones_captura set hora_corte = '" & hora_extension & "' where username = '" & username & "' and periodo_vacacional = '" & PERIODO_VACACIONAL & "'", "TA")
                    End If
                    dgvExcepciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = hora_extension
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Function DtoH_local(Hora As Double) As String
        Try
            Dim H As Integer
            Dim M As Integer

            H = Int(Math.Abs(Hora))
            M = (Math.Abs(Hora) - Int(Math.Abs(Hora))) * 100
            If M > 59 Then
                M = 59
            End If
            Return IIf(Hora < 0, "-", "") & H.ToString.PadLeft(2, "0") & ":" & M.ToString.PadLeft(2, "0")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub PanelGenerar_Paint(sender As Object, e As PaintEventArgs) Handles PanelGenerar.Paint

    End Sub

    Private Sub ButtonX3_Click_1(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Try
            Dim dt_extra As DataTable = sqlExecute(TextBox1.Text)
            DataGridViewX1.DataSource = dt_extra
        Catch ex As Exception

        End Try
    End Sub
End Class