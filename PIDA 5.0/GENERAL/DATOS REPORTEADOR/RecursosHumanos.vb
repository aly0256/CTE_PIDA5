Option Compare Text

Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports Microsoft.Office.Interop

Module RecursosHumanos
    Public FechaRetiro As String '-----Agregadas por Antonio
    Public MontoRetiro As String '-----Agregadas por Antonio

    Public Sub DetInfonavit(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("cod_comp", Type.GetType("System.String"))
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
            dtDatos.Columns.Add("infonavit", Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo_cred", Type.GetType("System.String"))
            dtDatos.Columns.Add("cuota_cred", Type.GetType("System.String"))
            dtDatos.Columns.Add("inicio_cre", Type.GetType("System.String"))
            dtDatos.Columns.Add("suspension", Type.GetType("System.String"))
            dtDatos.Columns.Add("activo", Type.GetType("System.String"))
            dtDatos.Columns.Add("periodo_fechas", Type.GetType("System.String"))

            MessageBox.Show("Favor de ingresar el rango de fechas de inicio de crédito de infonavit", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            '----Solicitar rango de fechas
            Dim fr As New frmRangoFechas
            fr.frmRangoFechas_fecha_ini = New Date(Now.Year, Now.Month, 1) '--El primero del mes actual
            fr.frmRangoFechas_fecha_fin = New Date(Now.Year, Now.Month, Now.Day) '-- El dia actual

            fr.ShowDialog()     'Solicitar rango de fechas
            FechaInicial = FechaInicial.Date
            FechaFinal = FechaFinal.Date                   ' ------ filtros para poder comparar sin HRS y sea comparable desde el dia 1

            If FechaInicial = Nothing Then Exit Sub
            Dim _fini As Date, _ffin As Date
            _fini = FechaInicial
            _ffin = FechaFinal
            '---ENDS

            ' select * from infonavit where inicio_cre between '2018-01-01' and '2021-06-10' order by reloj asc,inicio_cre desc,activo desc
            Dim dtPersonal As DataTable = sqlExecute("select * from infonavit where inicio_cre between '" & FechaSQL(_fini) & "' and '" & FechaSQL(_ffin) & "' order by reloj asc,inicio_cre desc,activo desc")
            If dtPersonal.Rows.Count = 0 Then Exit Sub
            If (dtPersonal.Columns.Contains("Error")) Then Exit Sub

            '---Depurar a solo el personal que filtramos
            Dim dtTemp As New DataTable
            dtTemp = dtPersonal.Clone

            For Each drow As DataRow In dtPersonal.Rows
                Dim rj As String = ""
                rj = drow("reloj").ToString.Trim
                If (dtInformacion.Select("reloj='" & rj & "'").Count > 0) Then  ' Si ese # Rj se encuentra en el dtInformacion que es el que nos dice que empleados incluir
                    dtTemp.ImportRow(drow)   ' Lo agregamos al dtTemp
                End If
            Next

            dtPersonal = dtTemp.Copy

            For Each rPers As DataRow In dtPersonal.Rows
                Dim drow As DataRow = dtDatos.NewRow
                Dim rj As String = "", cod_comp As String = "", nombres As String = "", infonavit As String = "", tipo_cred As String = "", cuota_cred As String = "", inicio_cre As String = "", suspension As String = ""
                Dim activo As String = "", periodo_fechas As String = ""


                cod_comp = "WME" ' Se deja fija por el momento
                Try : rj = rPers("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                Try : nombres = rPers("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
                Try : infonavit = rPers("infonavit").ToString.Trim : Catch ex As Exception : infonavit = "" : End Try
                Try : tipo_cred = rPers("tipo_cred").ToString.Trim : Catch ex As Exception : tipo_cred = "" : End Try
                Try : cuota_cred = Double.Parse(rPers("cuota_cred")) : Catch ex As Exception : cuota_cred = "" : End Try
                Try : inicio_cre = FechaSQL(rPers("inicio_cre").ToString.Trim) : Catch ex As Exception : inicio_cre = "" : End Try
                Try : suspension = FechaSQL(rPers("suspension").ToString.Trim) : Catch ex As Exception : suspension = "" : End Try
                Try : activo = rPers("activo").ToString.Trim : Catch ex As Exception : activo = "" : End Try
                If activo = "True" Then activo = "Si" Else activo = "No"
                periodo_fechas = "Del " & FechaSQL(_fini) & " al " & FechaSQL(_ffin)

                Select Case tipo_cred
                    Case "1"
                        tipo_cred = "Porcentaje"
                    Case "2"
                        tipo_cred = "Cuota Fija"
                    Case "3"
                        tipo_cred = "VSM"
                End Select


                drow("reloj") = rj
                drow("cod_comp") = cod_comp
                drow("nombres") = nombres
                drow("infonavit") = infonavit
                drow("tipo_cred") = tipo_cred
                drow("cuota_cred") = cuota_cred
                drow("inicio_cre") = inicio_cre
                drow("suspension") = suspension
                drow("activo") = activo
                drow("periodo_fechas") = periodo_fechas



                dtDatos.Rows.Add(drow)
            Next


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Debug.Print(ex.StackTrace)
        End Try
    End Sub

    Public Sub CambioRoles(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim frm As New frmTrabajando
            frm.Show()
            Application.DoEvents()
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("reloj_alt")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("cod_hora")
            dtDatos.Columns.Add("centro_costos")
            dtDatos.Columns.Add("cod_depto")
            dtDatos.Columns.Add("sf_super")
            dtDatos.Columns.Add("nombre_super")

            Dim sf_super As String = ""
            For Each row In dtInformacion.Rows
                Dim dtsupersf As DataTable = sqlExecute("select * from super where cod_super = '" & row("cod_super") & "' and cod_comp = '610'")

                If dtsupersf.Rows.Count > 0 Then
                    sf_super = IIf(IsDBNull(dtsupersf.Rows(0).Item("cod_sf")), "", dtsupersf.Rows(0).Item("cod_sf"))
                End If

                dtDatos.Rows.Add({row("reloj"),
                                  row("reloj_alt"),
                                  row("nombres"),
                                  row("cod_hora"),
                                  row("centro_costos"),
                                  row("cod_depto"),
                                  sf_super,
                                  row("nombre_super")})

            Next


            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = ".xlsx"
            sfd.FileName = "BRP Formato rol_promociones.xlsx"

            sfd.OverwritePrompt = True
            If sfd.ShowDialog() = DialogResult.OK Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                ExcelCambioRoles("Roles", "", wb, dtDatos)
                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
            End If

            ActivoTrabajando = False
            frm.Close()

            MessageBox.Show("EL archivo a sido creado exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try


    End Sub
    Public Sub ExcelCambioRoles(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, dtDatos As DataTable)
        Try
            Dim x As Integer = 1
            Dim y As Integer = 1
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)




            hoja_excel.Cells(x, y).Value = "RELOJ"
            hoja_excel.Cells(x, y).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 1).Value = "ID SF"
            hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 2).Value = "NOMBRE COMPLETO"
            hoja_excel.Cells(x, y + 2).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 3).Value = "HORARIO"
            hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 4).Value = "CENTRO COSTOS"
            hoja_excel.Cells(x, y + 4).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 5).Value = "DEPARTAMENTO CODIGO"
            hoja_excel.Cells(x, y + 5).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 6).Value = "ID SF SUPERVISOR"
            hoja_excel.Cells(x, y + 6).Style.Font.Bold = True

            hoja_excel.Cells(x, y + 7).Value = "NOMBRE SUPERVISOR"
            hoja_excel.Cells(x, y + 7).Style.Font.Bold = True

            x = x + 1
            For Each row As DataRow In dtDatos.Select(filtro, "reloj")



                hoja_excel.Cells(x, y).Value = row("reloj")
                hoja_excel.Cells(x, y + 1).Value = row("reloj_alt")
                hoja_excel.Cells(x, y + 2).Value = row("nombres")
                hoja_excel.Cells(x, y + 3).Value = row("cod_hora")
                hoja_excel.Cells(x, y + 4).Value = row("centro_costos")
                hoja_excel.Cells(x, y + 5).Value = row("cod_depto")
                hoja_excel.Cells(x, y + 6).Value = row("sf_super")
                hoja_excel.Cells(x, y + 7).Value = row("nombre_super")


                x = x + 1
            Next

            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub ReporteBudgetSoloBRPQTO()
        Try


            If NivelSueldos < 5 Then
                MessageBox.Show("Su usuario no tiene el nivel de consulta necesario para generar esta información", "Accesos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If NivelSueldos >= 5 Then

                Dim dtPersonal As DataTable = sqlExecute("select cod_comp, reloj, nombres, alta, case when alta_vacacion is null then alta else alta_vacacion end as alta_vacacion, estatus, nombre_puesto, nombre_area, centro_costos, cod_clase, sactual from personalvw where cod_clase in ('A', 'G', 'I') and baja is null and estatus = 'ACTIVO' and cod_comp = '610'")

                dtPersonal.Rows.Add("salario_mensual")
                dtPersonal.Rows.Add("dias_vacaciones")
                dtPersonal.Rows.Add("gerente")

                Dim fecha_ini As Date = DateSerial(Now.Year, 2, 1)
                Dim fecha_fin As Date = fecha_ini.AddYears(1).AddDays(-1)




                Dim file_name As String = "Reporte para budget " & fecha_ini.Year & ".xlsx"

                Dim sfd As New SaveFileDialog
                sfd.FileName = file_name
                sfd.Title = "Reporte para budget"
                sfd.DefaultExt = "xlsx"
                sfd.Filter = "Archivos de excel|*.xlsx"

                If sfd.ShowDialog = DialogResult.OK Then

                    Dim frm As New frmTrabajando
                    frm.Text = "REPORTE"
                    frm.lblAvance.Text = "REPORTE"

                    frm.Show()

                    Application.DoEvents()

                    fecha_ini = FechaInicial
                    fecha_fin = FechaFinal

                    Dim dtVacaciones As DataTable = sqlExecute("select * from vacaciones where cod_comp = '610'")

                    Dim dtVacacionesEspeciales As DataTable = sqlExecute("select '' as reloj, * from vacaciones where cod_comp = '610'")

                    For Each row_personal As DataRow In dtPersonal.Rows

                        Application.DoEvents()
                        Try
                            ' // SALARIO MENSUAL
                            Dim cod_Clase As String = row_personal("cod_clase")
                            If cod_Clase = "I" Then
                                row_personal("salario_mensual") = row_personal("sactual") * 30.4
                            ElseIf cod_Clase = "A" Or cod_Clase = "G" Then
                                row_personal("salario_mensual") = row_personal("sactual") * 30
                            End If

                            ' // VACACIONES
                            Dim alta_vacacion As Date = row_personal("alta_vacacion")
                            Dim aniversario_vacacion As Date = DateSerial(Now.Year, alta_vacacion.Month, alta_vacacion.Day)

                            If aniversario_vacacion < fecha_ini Then
                                aniversario_vacacion = aniversario_vacacion.AddYears(1)
                            End If

                            Dim anos As Integer = DateDiff(DateInterval.Year, aniversario_vacacion, alta_vacacion)

                            Dim cod_tipo As String = "O"
                            If cod_Clase = "A" Or cod_Clase = "G" Then
                                cod_tipo = "A"
                            End If


                            Dim dias_vacaciones As Integer = 0

                            For Each row_vacaciones As DataRow In dtVacaciones.Select("cod_tipo = '" & cod_tipo & "' and anos = '" & anos & "'")
                                dias_vacaciones = row_vacaciones("dias")
                            Next

                            For Each row_vacaciones As DataRow In dtVacacionesEspeciales.Select("reloj = '" & row_personal("reloj") & "' and anos = '" & anos & "'")
                                dias_vacaciones = row_vacaciones("dias")
                            Next

                            row_personal("dias_vacaciones") = dias_vacaciones


                            ' // GERENTE
                            row_personal("gerente") = ""
                        Catch ex As Exception

                        End Try
                    Next

                    file_name = sfd.FileName

                    Dim archivo As ExcelPackage = New ExcelPackage()
                    Dim wb As ExcelWorkbook = archivo.Workbook

                    Dim hoja_general As ExcelWorksheet = wb.Worksheets.Add("Reporte")

                    Dim x As Integer = 3
                    Dim y As Integer = 1

                    For Each column As DataColumn In dtPersonal.Columns
                        Application.DoEvents()

                        Try
                            hoja_general.Cells(x, y).Value = column.ColumnName
                            hoja_general.Cells(x, y).Style.Font.Bold = True
                        Catch ex As Exception

                        End Try

                        y += 1
                    Next

                    x += 1
                    For Each row As DataRow In dtPersonal.Rows
                        For Each column As DataColumn In dtPersonal.Columns
                            Try
                                hoja_general.Cells(x, y).Value = row(column.ColumnName)
                            Catch ex As Exception

                            End Try

                            Application.DoEvents()
                            y += 1
                        Next
                        x += 1
                    Next

                    hoja_general.Cells(hoja_general.Dimension.Address).AutoFitColumns()

                    hoja_general.Cells(1, 1).Value = "BRP Querétaro"
                    hoja_general.Cells(1, 1).Style.Font.Bold = True

                    hoja_general.Cells(2, 1).Value = "Reporte para budget " & fecha_ini.Year
                    hoja_general.Cells(2, 1).Style.Font.Bold = True

                    ActivoTrabajando = False
                    frm.Close()

                    archivo.SaveAs(New System.IO.FileInfo(file_name))

                    MessageBox.Show("Archivo generado correctamente", "Mensaje", MessageBoxButtons.OK)


                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub ReporteBudget(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)

        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ", GetType(System.String))
            dtDatos.Columns.Add("nombres", GetType(System.String))
            dtDatos.Columns.Add("ALTA", GetType(System.String))
            dtDatos.Columns.Add("alta_vacacion", GetType(System.String))
            dtDatos.Columns.Add("ESTATUS", GetType(System.String))
            dtDatos.Columns.Add("nombre_puesto", GetType(System.String))
            dtDatos.Columns.Add("nombre_area", GetType(System.String))
            dtDatos.Columns.Add("CENTRO_COSTOS", GetType(System.String))
            dtDatos.Columns.Add("COD_CLASE", GetType(System.String))
            dtDatos.Columns.Add("SACTUAL", GetType(System.Double))
            dtDatos.Columns.Add("SMENSUAL", GetType(System.Double))
            dtDatos.Columns.Add("DIAS_VAC", GetType(System.Double))
            dtDatos.Columns.Add("ANTIG", GetType(System.Double))

            '---Solo va a arrojar personal activo y de la clase A,G e I
            Dim QP As String = "SELECT * from personalvw where isnull(baja,'')='' and isnull(inactivo,0)=0  and cod_clase in ('A', 'G', 'I') and isnull(cod_comp,'')='610'"
            Dim dtPersonal As DataTable = sqlExecute(QP, "PERSONAL")

            frmTrabajando.Show()
            Application.DoEvents()

            If (Not dtPersonal.Columns.Contains("Error") And dtPersonal.Rows.Count > 0) Then
                For Each row As DataRow In dtPersonal.Rows
                    Dim RELOJ As String = IIf(IsDBNull(row("RELOJ")), "", row("RELOJ"))
                    frmTrabajando.lblAvance.Text = RELOJ.Trim
                    Application.DoEvents()

                    Dim nombres As String = IIf(IsDBNull(row("nombres")), "", row("nombres"))
                    Dim ALTA As String = IIf(IsDBNull(row("ALTA")), "", row("ALTA"))
                    Dim alta_vacacion As String = IIf(IsDBNull(row("alta_vacacion")), "", row("alta_vacacion"))
                    Dim ESTATUS As String = IIf(IsDBNull(row("ESTATUS")), "", row("ESTATUS"))
                    Dim nombre_puesto As String = IIf(IsDBNull(row("nombre_puesto")), "", row("nombre_puesto"))
                    Dim nombre_area As String = IIf(IsDBNull(row("nombre_area")), "", row("nombre_area"))
                    Dim CENTRO_COSTOS As String = IIf(IsDBNull(row("CENTRO_COSTOS")), "", row("CENTRO_COSTOS"))
                    Dim COD_CLASE As String = IIf(IsDBNull(row("COD_CLASE")), "", row("COD_CLASE"))
                    Dim Descrip_Clase As String = ""
                    If (COD_CLASE.Trim <> "") Then
                        Select Case COD_CLASE.Trim
                            Case "G", "A"
                                Descrip_Clase = "Salary"
                            Case "I"
                                Descrip_Clase = "Hourly"
                            Case Else
                                Descrip_Clase = "Hourly"
                        End Select
                    End If
                    Dim SACTUAL As Double = IIf(IsDBNull(row("SACTUAL")), 0, Double.Parse(row("SACTUAL")))
                    Dim SMENSUAL As Double = Math.Round(IIf(COD_CLASE.Trim = "A" Or COD_CLASE.Trim = "G", SACTUAL * 30, SACTUAL * 30.4), 2)
                    Dim DIAS_VAC As Double = 0.0
                    Dim ANTIG As Double = 0.0

                    '--Calcular la antiguedad en base a la fecha actual que se esta corriendo el reporte y en base al año fiscal (01/02/AnioActual Al 31/01/AnioProximo)
                    Dim AnioActual As Integer = 0
                    Dim MesActual As Integer = Date.Now.Month
                    If MesActual <> 1 Then AnioActual = Date.Now.Year Else AnioActual = Date.Now.Year - 1
                    Dim RangoLimite As String = AnioActual & "-02-01"

                    Dim AltaRealEmpleado As Date
                    If (alta_vacacion.Trim <> "") Then AltaRealEmpleado = Convert.ToDateTime(FechaSQL(alta_vacacion.Trim)) Else AltaRealEmpleado = Convert.ToDateTime(FechaSQL(ALTA.Trim))
                    Dim MesEmpl As Integer = AltaRealEmpleado.Month
                    Dim diaEmpl As Integer = AltaRealEmpleado.Day
                    Dim ResiduoAniv As Integer = AnioActual Mod 4
                    If (MesEmpl = 2 And diaEmpl >= 29 And ResiduoAniv <> 0) Then diaEmpl = 28 ' Si el año actual no es bisiesto, dejarlo a 28 en caso que su dia fuese mayor a 29
                    '-Obtener Aniv del empleado en base al año actual
                    Dim FechAnivEmpl As String = AnioActual & "-" & IIf(MesEmpl.ToString.Length = 1, "0" & Convert.ToString(MesEmpl), Convert.ToString(MesEmpl)) & "-" & IIf(diaEmpl.ToString.Length = 1, "0" & Convert.ToString(diaEmpl), Convert.ToString(diaEmpl))


                    Dim AnioAntigEmpl As Integer = 0
                    Dim X As Integer = 0 ' Cant de años a sumar de acuerdo al día que se genere y la fecha de antiguedad

                    '-Si la fec Aniv en base al anio actual es < al RangoLimite (01/02/AñoActual), sumar 2 años  (Empleados que caen del 01/01 al 31/01 )
                    If (Convert.ToDateTime(FechAnivEmpl) < Convert.ToDateTime(RangoLimite)) Then X = 2 Else X = 1
                    AnioAntigEmpl = AltaRealEmpleado.Year
                    ANTIG = AnioActual - AnioAntigEmpl + X

                    '--Calc los días de vacaciones en base a la Antiguedad obtenida del empleado en base al año fiscal (01/02/AnioActual Al 31/01/AnioProximo)
                    Dim COD_TIPO As String = IIf(IsDBNull(row("COD_TIPO")), "", row("COD_TIPO"))
                    Dim dtVacas As DataTable = sqlExecute("Select top 1 * from vacaciones where cod_comp='610' and COD_TIPO='" & COD_TIPO.Trim & "' AND ANOS=" & ANTIG & "", "PERSONAL")
                    If (Not dtVacas.Columns.Contains("Error") And dtVacas.Rows.Count > 0) Then
                        DIAS_VAC = IIf(IsDBNull(dtVacas.Rows(0).Item("DIAS")), 0, Double.Parse(dtVacas.Rows(0).Item("DIAS")))
                    End If

                    Dim drow As DataRow = dtDatos.NewRow
                    drow("RELOJ") = RELOJ
                    drow("nombres") = nombres
                    drow("ALTA") = FechaSQL(ALTA.Trim)
                    If (alta_vacacion.Trim <> "") Then drow("alta_vacacion") = FechaSQL(alta_vacacion) Else drow("alta_vacacion") = FechaSQL(ALTA.Trim)
                    drow("ESTATUS") = ESTATUS
                    drow("nombre_puesto") = nombre_puesto
                    drow("nombre_area") = nombre_area
                    drow("CENTRO_COSTOS") = CENTRO_COSTOS
                    '   drow("COD_CLASE") = COD_CLASE
                    drow("COD_CLASE") = Descrip_Clase
                    drow("SACTUAL") = SACTUAL
                    drow("SMENSUAL") = SMENSUAL
                    drow("DIAS_VAC") = DIAS_VAC
                    drow("ANTIG") = ANTIG

                    dtDatos.Rows.Add(drow)
                Next
            End If

            ActivoTrabajando = False
            frmTrabajando.Close()
        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

    End Sub


    Public Sub HorariosDetalle()
        Try


            Dim yyyy As String = Now.Year

            Dim file_name As String = "Horarios detalle " & yyyy & ".xlsx"

            Dim sfd As New SaveFileDialog
            sfd.FileName = file_name
            sfd.Title = "Horarios detalle " & yyyy
            sfd.DefaultExt = "xlsx"
            sfd.Filter = "Archivos de excel|*.xlsx"

            If sfd.ShowDialog = DialogResult.OK Then

                file_name = sfd.FileName

                Dim dtPeriodos As DataTable = sqlExecute("select * from ta.dbo.periodos where ano = '" & yyyy & "' and isnull(periodo_especial, 0) = 0")
                Dim dtHorarios As DataTable = sqlExecute("select cod_hora, isnull(cod_sf, '') as cod_sf, isnull(nombre, '') as nombre, isnull(descripcion_larga, '') as descripcion_larga from horarios where cod_comp = '610'")

                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                Dim hoja_general As ExcelWorksheet = wb.Worksheets.Add("General")
                Dim dtDatos As New DataTable
                dtDatos.Columns.Add("cod_hora")
                dtDatos.Columns.Add("cod_sf")
                dtDatos.Columns.Add("nombre")
                dtDatos.Columns.Add("desc")

                For Each row_periodos As DataRow In dtPeriodos.Rows
                    dtDatos.Columns.Add(row_periodos("periodo"))
                Next

                dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("cod_hora")}

                For Each row_horario As DataRow In dtHorarios.Rows
                    Dim r As DataRow = dtDatos.NewRow

                    r("cod_hora") = row_horario("cod_hora")
                    r("cod_sf") = "Q_" & row_horario("cod_sf")
                    r("nombre") = row_horario("nombre")
                    r("desc") = row_horario("descripcion_larga")

                    dtDatos.Rows.Add(r)
                Next

                Dim frm As New frmTrabajando
                frm.Show()

                For Each row_periodos As DataRow In dtPeriodos.Rows

                    Try

                        frm.lblAvance.Text = row_periodos("ano") & "-" & row_periodos("periodo")
                        Application.DoEvents()

                        Dim fecha_ini As Date = row_periodos("fecha_ini")
                        Dim fecha_fin As Date = row_periodos("fecha_fin")

                        Dim hoja_periodo As ExcelWorksheet = wb.Worksheets.Add(row_periodos("ano") & "-" & row_periodos("periodo"))

                        Dim q As String = "" & _
                        " select" & _
                        " horarios.cod_hora," & _
                        " horarios.cod_sf," & _
                        " horarios.nombre," & _
                        " rol_horarios.ano," & _
                        " rol_horarios.periodo," & _
                        " rol_horarios.SEMANA," & _
                        " max(case when dias.cod_dia = '1' then case when descanso = 1 then 'DESCANSO|0' else dias.ENTRA + ' a ' + dias.SALE + '|' + dias.grupo_ent end else '' end) as L," & _
                        " max(case when dias.cod_dia = '2' then case when descanso = 1 then 'DESCANSO|0' else dias.ENTRA + ' a ' + dias.SALE + '|' + dias.grupo_ent end else '' end) as M," & _
                        " max(case when dias.cod_dia = '3' then case when descanso = 1 then 'DESCANSO|0' else dias.ENTRA + ' a ' + dias.SALE + '|' + dias.grupo_ent end else '' end) as W," & _
                        " max(case when dias.cod_dia = '4' then case when descanso = 1 then 'DESCANSO|0' else dias.ENTRA + ' a ' + dias.SALE + '|' + dias.grupo_ent end else '' end) as J," & _
                        " max(case when dias.cod_dia = '5' then case when descanso = 1 then 'DESCANSO|0' else dias.ENTRA + ' a ' + dias.SALE + '|' + dias.grupo_ent end else '' end) as V," & _
                        " max(case when dias.cod_dia = '6' then case when descanso = 1 then 'DESCANSO|0' else dias.ENTRA + ' a ' + dias.SALE + '|' + dias.grupo_ent end else '' end) as S," & _
                        " max(case when dias.cod_dia = '7' then case when descanso = 1 then 'DESCANSO|0' else dias.ENTRA + ' a ' + dias.SALE + '|' + dias.grupo_ent end else '' end) as D " & _
                        " from horarios" & _
                        " left join rol_horarios on rol_horarios.cod_hora = horarios.cod_hora" & _
                        " left join dias on dias.cod_hora = horarios.cod_hora and dias.semana = rol_horarios.semana" & _
                        " where" & _
                        " rol_horarios.ano = '" & row_periodos("ano") & "' and rol_horarios.periodo = '" & row_periodos("periodo") & "'" & _
                        " group by" & _
                        " horarios.cod_hora," & _
                        " horarios.cod_sf," & _
                        " horarios.nombre," & _
                        " rol_horarios.ano," & _
                        " rol_horarios.periodo," & _
                        " rol_horarios.SEMANA "

                        Dim dtRolPeriodo As DataTable = sqlExecute(q)


                        Dim x As Integer = 2

                        hoja_periodo.Cells(x, 1).Value = "Horario"
                        hoja_periodo.Cells(x, 1).Style.Font.Bold = True

                        hoja_periodo.Cells(x, 2).Value = "Cód. SF"
                        hoja_periodo.Cells(x, 2).Style.Font.Bold = True

                        hoja_periodo.Cells(x, 3).Value = "Nombre"
                        hoja_periodo.Cells(x, 3).Style.Font.Bold = True

                        hoja_periodo.Cells(x, 4).Value = "Año"
                        hoja_periodo.Cells(x, 4).Style.Font.Bold = True

                        hoja_periodo.Cells(x, 5).Value = "Periodo"
                        hoja_periodo.Cells(x, 5).Style.Font.Bold = True

                        hoja_periodo.Cells(x, 6).Value = "Semana"
                        hoja_periodo.Cells(x, 6).Style.Font.Bold = True

                        hoja_periodo.Cells(x, 7).Value = "Lunes " & fecha_ini.AddDays(0).Day & "/" & fecha_ini.AddDays(0).Month
                        hoja_periodo.Cells(x, 7).Style.Font.Bold = True

                        hoja_periodo.Cells(x, 8).Value = "Martes " & fecha_ini.AddDays(1).Day & "/" & fecha_ini.AddDays(1).Month
                        hoja_periodo.Cells(x, 8).Style.Font.Bold = True

                        hoja_periodo.Cells(x, 9).Value = "Miércoles " & fecha_ini.AddDays(2).Day & "/" & fecha_ini.AddDays(2).Month
                        hoja_periodo.Cells(x, 9).Style.Font.Bold = True

                        hoja_periodo.Cells(x, 10).Value = "Jueves " & fecha_ini.AddDays(3).Day & "/" & fecha_ini.AddDays(3).Month
                        hoja_periodo.Cells(x, 10).Style.Font.Bold = True

                        hoja_periodo.Cells(x, 11).Value = "Viernes " & fecha_ini.AddDays(4).Day & "/" & fecha_ini.AddDays(4).Month
                        hoja_periodo.Cells(x, 11).Style.Font.Bold = True

                        hoja_periodo.Cells(x, 12).Value = "Sábado " & fecha_ini.AddDays(5).Day & "/" & fecha_ini.AddDays(5).Month
                        hoja_periodo.Cells(x, 12).Style.Font.Bold = True

                        hoja_periodo.Cells(x, 13).Value = "Domingo " & fecha_ini.AddDays(6).Day & "/" & fecha_ini.AddDays(6).Month
                        hoja_periodo.Cells(x, 13).Style.Font.Bold = True


                        For Each row_horario As DataRow In dtRolPeriodo.Rows

                            Application.DoEvents()

                            x += 1

                            hoja_periodo.Cells(x, 1).Value = row_horario("cod_hora")
                            hoja_periodo.Cells(x, 2).Value = "Q_" & row_horario("cod_sf")
                            hoja_periodo.Cells(x, 3).Value = row_horario("nombre")
                            hoja_periodo.Cells(x, 4).Value = row_horario("ano")
                            hoja_periodo.Cells(x, 5).Value = row_horario("periodo")
                            hoja_periodo.Cells(x, 6).Value = row_horario("semana")

                            Dim grupos As String = "x"

                            Dim l As String = row_horario("L").ToString.Split("|")(0)
                            Dim lg As String = row_horario("L").ToString.Split("|")(1)
                            grupos = IIf(lg = "0", grupos, IIf(grupos.Contains(lg), grupos, grupos & "-" & lg))

                            Dim m As String = row_horario("M").ToString.Split("|")(0)
                            Dim mg As String = row_horario("M").ToString.Split("|")(1)
                            grupos = IIf(mg = "0", grupos, IIf(grupos.Contains(mg), grupos, grupos & "-" & mg))

                            Dim w As String = row_horario("W").ToString.Split("|")(0)
                            Dim wg As String = row_horario("W").ToString.Split("|")(1)
                            grupos = IIf(wg = "0", grupos, IIf(grupos.Contains(wg), grupos, grupos & "-" & wg))

                            Dim j As String = row_horario("J").ToString.Split("|")(0)
                            Dim jg As String = row_horario("J").ToString.Split("|")(1)
                            grupos = IIf(jg = "0", grupos, IIf(grupos.Contains(jg), grupos, grupos & "-" & jg))

                            Dim v As String = row_horario("V").ToString.Split("|")(0)
                            Dim vg As String = row_horario("V").ToString.Split("|")(1)
                            grupos = IIf(vg = "0", grupos, IIf(grupos.Contains(vg), grupos, grupos & "-" & vg))

                            Dim s As String = row_horario("S").ToString.Split("|")(0)
                            Dim sg As String = row_horario("S").ToString.Split("|")(1)
                            grupos = IIf(sg = "0", grupos, IIf(grupos.Contains(sg), grupos, grupos & "-" & sg))

                            Dim d As String = row_horario("D").ToString.Split("|")(0)
                            Dim dg As String = row_horario("D").ToString.Split("|")(1)
                            grupos = IIf(dg = "0", grupos, IIf(grupos.Contains(dg), grupos, grupos & "-" & dg))

                            grupos = grupos.Replace("x-", "")


                            hoja_periodo.Cells(x, 7).Value = l
                            hoja_periodo.Cells(x, 8).Value = m
                            hoja_periodo.Cells(x, 9).Value = w
                            hoja_periodo.Cells(x, 10).Value = j
                            hoja_periodo.Cells(x, 11).Value = v
                            hoja_periodo.Cells(x, 12).Value = s
                            hoja_periodo.Cells(x, 13).Value = d

                            Try
                                Dim dr As DataRow = dtDatos.Rows.Find(row_horario("cod_hora"))
                                dr(row_horario("periodo")) = grupos
                            Catch ex As Exception

                            End Try

                        Next

                        hoja_periodo.Cells(hoja_periodo.Dimension.Address).AutoFitColumns()

                        hoja_periodo.Cells(1, 1).Value = "Periodo " & row_periodos("ano") & "-" & row_periodos("periodo") & " del " & FechaSQL(fecha_ini) & " al " & FechaSQL(fecha_fin)
                        hoja_periodo.Cells(1, 1).Style.Font.Bold = True
                        hoja_periodo.Cells(1, 1).Style.Font.Size = 12


                    Catch ex As Exception

                    End Try

                Next

                Dim x_g As Integer = 2
                Dim y_g As Integer = 1
                For Each column As DataColumn In dtDatos.Columns
                    hoja_general.Cells(x_g, y_g).Value = column.ColumnName.ToUpper
                    hoja_general.Cells(x_g, y_g).Style.Font.Bold = True

                    y_g += 1
                Next


                For Each row As DataRow In dtDatos.Rows
                    x_g += 1
                    y_g = 1
                    For Each column As DataColumn In dtDatos.Columns
                        hoja_general.Cells(x_g, y_g).Value = row(column.ColumnName)
                        y_g += 1
                    Next
                Next

                hoja_general.Cells(hoja_general.Dimension.Address).AutoFitColumns()

                hoja_general.Cells(1, 1).Value = "Distribución anual de horarios"
                hoja_general.Cells(1, 1).Style.Font.Bold = True
                hoja_general.Cells(1, 1).Style.Font.Size = 12


                archivo.SaveAs(New System.IO.FileInfo(file_name))

                ActivoTrabajando = False
                frm.Close()

                MessageBox.Show("Archivo generado: " & file_name, "Archivo generado", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Catch ex As Exception

        End Try
    End Sub

    Public Sub ConstanciaBaja(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim drDatos As DataRow

        Try

            dtDatos = New DataTable
            dtDatos.Columns.Add("fha_actual", GetType(System.String))
            dtDatos.Columns.Add("sexo", GetType(System.String))
            dtDatos.Columns.Add("nombre", GetType(System.String))
            dtDatos.Columns.Add("apaterno", GetType(System.String))
            dtDatos.Columns.Add("amaterno", GetType(System.String))
            dtDatos.Columns.Add("fha_alta", GetType(System.String))
            dtDatos.Columns.Add("fha_baja", GetType(System.String))
            dtDatos.Columns.Add("nom_puesto", GetType(System.String))


            If Not dtInformacion.Select("baja is not null").Count > 0 Then
                MsgBox("No hay bajas o no se filtraron las bajas. Favor de verificar", MsgBoxStyle.Exclamation, "Aviso")
                Exit Sub
            End If



            For Each drInformacion As DataRow In dtInformacion.Select("baja is not null")

                drDatos = dtDatos.NewRow

                drDatos("fha_actual") = FechaLetra(Now).Replace("-", " de ").Trim
                drDatos("sexo") = Trim(IIf(IsDBNull(drInformacion("sexo")), "I", drInformacion("sexo"))).ToUpper
                drDatos("nombre") = Trim(IIf(IsDBNull(drInformacion("nombre")), "", drInformacion("nombre"))).ToUpper
                drDatos("apaterno") = Trim(IIf(IsDBNull(drInformacion("apaterno")), "", drInformacion("apaterno"))).ToUpper
                drDatos("amaterno") = Trim(IIf(IsDBNull(drInformacion("amaterno")), "", drInformacion("amaterno"))).ToUpper
                drDatos("fha_alta") = Trim(IIf(IsDBNull(drInformacion("alta")), "", FechaLetra(drInformacion("alta")))).Replace("-", " de ").Trim
                drDatos("fha_baja") = Trim(IIf(IsDBNull(drInformacion("baja")), "", FechaLetra(drInformacion("baja")))).Replace("-", " de ").Trim
                drDatos("nom_puesto") = Trim(IIf(IsDBNull(drInformacion("nombre_puesto")), "INDEFINIDO", drInformacion("nombre_puesto"))).ToUpper


                dtDatos.Rows.Add(drDatos)

            Next


        Catch ex As Exception

        End Try

    End Sub

    Public Sub BitacoraCambios(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim archivo As ExcelPackage = New ExcelPackage()
        Dim wb As ExcelWorkbook = archivo.Workbook
        Dim dtBitacora As New DataTable
        'Dim dtAux As New DataTable
        'Dim dtAnterior As New DataTable
        'Dim dtNuevo As New DataTable
        'Dim fIni As String = ""
        'Dim fFin As String =""
        Dim Campo As String = ""
        Dim valor1 As String = ""
        Dim valor2 As String = ""
        Dim drNuevo As DataRow
        Dim dtValor1 As DataTable
        Dim dtValor2 As DataTable

        Try
            dtDatos = New DataTable

            frmRangoFechas.ShowDialog()

            If FechaInicial = Nothing And FechaFinal = Nothing Then
                Exit Sub
            End If



            dtDatos.Columns.Add("CAMPO")
            dtDatos.Columns.Add("FECHA")
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("TURNO")
            dtDatos.Columns.Add("DATO_ANTERIOR")
            dtDatos.Columns.Add("DATO_NUEVO")
            dtDatos.Columns.Add("USUARIO")
            dtDatos.Columns.Add("HORA")
            dtDatos.Columns.Add("ENCABEZADO")

            dtBitacora = sqlExecute("SELECT campo,CAST(fecha as date) as fecha,reloj,ValorAnterior,ValorNuevo,usuario, CAST(fecha as time(0)) as hora " & _
                                    "FROM bitacora_personal WHERE CAST(fecha as date) BETWEEN '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' ORDER BY fecha")


            If dtBitacora.Rows.Count > 0 Then


                For Each drBitacora As DataRow In dtBitacora.Rows

                    Dim dRow As DataRow = dtInformacion.Rows.Find(drBitacora("reloj"))

                    dtValor1 = New DataTable
                    dtValor2 = New DataTable

                    If Not dRow Is Nothing Then

                        Try

                            Campo = drBitacora("campo").ToString.ToLower.Trim
                            Dim strTmpCampo As String = Campo.Replace("cod_", "")
                            ' Dim dtTurno As DataTable = sqlExecute("SELECT TOP 1 ValorNuevo FROM bitacora_personal WHERE RELOJ = '" & drBitacora("reloj").ToString.Trim & "' AND CAMPO = 'COD_TURNO' ORDER BY CAST(fecha as date) DESC")

                            drNuevo = dtDatos.NewRow

                            drNuevo("CAMPO") = strTmpCampo.Replace("_", " ").ToUpper.Trim
                            drNuevo("FECHA") = FechaSQL(drBitacora("fecha")).Trim
                            drNuevo("RELOJ") = drBitacora("reloj").ToString.Trim
                            drNuevo("NOMBRES") = dRow("nombres")
                            drNuevo("ENCABEZADO") = "Del " & FechaSQL(FechaInicial) & " al " & FechaSQL(FechaFinal)
                            'If dtTurno.Rows.Count > 0 Then
                            '    drNuevo("TURNO") = dtTurno.Rows(0).Item(0).ToString.Trim
                            'Else
                            '    drNuevo("TURNO") = dRow("cod_turno")
                            'End If

                            'drNuevo("TURNO") = dRow("cod_turno")
                            drNuevo("TURNO") = dRow("cod_turno")
                            drNuevo("USUARIO") = drBitacora("usuario")
                            drNuevo("HORA") = drBitacora("hora")


                            Select Case Campo
                                Case "cod_tipo"

                                    valor1 = Trim(IIf(IsDBNull(drBitacora("ValorAnterior")), "SINDATO", drBitacora("ValorAnterior")))
                                    dtValor1 = sqlExecute("SELECT nombre FROM tipo_emp WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_tipo = '" & valor1 & "'")

                                    valor2 = Trim(IIf(IsDBNull(drBitacora("ValorNuevo")), "SINDATO", drBitacora("ValorNuevo")))
                                    dtValor2 = sqlExecute("SELECT nombre FROM tipo_emp WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_tipo = '" & valor2 & "'")

                                    If dtValor1.Rows.Count > 0 Then
                                        drNuevo("DATO_ANTERIOR") = valor1 & "," & dtValor1.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_ANTERIOR") = ""
                                    End If

                                    If dtValor2.Rows.Count > 0 Then
                                        drNuevo("DATO_NUEVO") = valor2 & "," & dtValor2.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_NUEVO") = ""
                                    End If

                                Case "cod_clase"

                                    valor1 = Trim(IIf(IsDBNull(drBitacora("ValorAnterior")), "SINDATO", drBitacora("ValorAnterior")))
                                    dtValor1 = sqlExecute("SELECT nombre FROM clase WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_clase = '" & valor1 & "'")

                                    valor2 = Trim(IIf(IsDBNull(drBitacora("ValorNuevo")), "SINDATO", drBitacora("ValorNuevo")))
                                    dtValor2 = sqlExecute("SELECT nombre FROM clase WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_clase = '" & valor2 & "'")

                                    If dtValor1.Rows.Count > 0 Then
                                        drNuevo("DATO_ANTERIOR") = valor1 & "," & dtValor1.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_ANTERIOR") = ""
                                    End If

                                    If dtValor2.Rows.Count > 0 Then
                                        drNuevo("DATO_NUEVO") = valor2 & "," & dtValor2.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_NUEVO") = ""
                                    End If

                                Case "cod_comp"

                                    valor1 = Trim(IIf(IsDBNull(drBitacora("ValorAnterior")), "SINDATO", drBitacora("ValorAnterior")))
                                    dtValor1 = sqlExecute("SELECT nombre FROM cias WHERE cod_comp = '" & valor1 & "'")

                                    valor2 = Trim(IIf(IsDBNull(drBitacora("ValorNuevo")), "SINDATO", drBitacora("ValorNuevo")))
                                    dtValor2 = sqlExecute("SELECT nombre FROM cias WHERE cod_comp = '" & valor2 & "'")

                                    If dtValor1.Rows.Count > 0 Then
                                        drNuevo("DATO_ANTERIOR") = valor1 & "," & dtValor1.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_ANTERIOR") = ""
                                    End If

                                    If dtValor2.Rows.Count > 0 Then
                                        drNuevo("DATO_NUEVO") = valor2 & "," & dtValor2.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_NUEVO") = ""
                                    End If

                                Case "cod_area"

                                    valor1 = Trim(IIf(IsDBNull(drBitacora("ValorAnterior")), "SINDATO", drBitacora("ValorAnterior")))
                                    dtValor1 = sqlExecute("SELECT nombre FROM areas WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_area = '" & valor1 & "'")

                                    valor2 = Trim(IIf(IsDBNull(drBitacora("ValorNuevo")), "SINDATO", drBitacora("ValorNuevo")))
                                    dtValor2 = sqlExecute("SELECT nombre FROM areas WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_area = '" & valor2 & "'")

                                    If dtValor1.Rows.Count > 0 Then
                                        drNuevo("DATO_ANTERIOR") = valor1 & "," & dtValor1.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_ANTERIOR") = ""
                                    End If

                                    If dtValor2.Rows.Count > 0 Then
                                        drNuevo("DATO_NUEVO") = valor2 & "," & dtValor2.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_NUEVO") = ""
                                    End If

                                Case "cod_depto"

                                    valor1 = Trim(IIf(IsDBNull(drBitacora("ValorAnterior")), "SINDATO", drBitacora("ValorAnterior")))
                                    dtValor1 = sqlExecute("SELECT nombre FROM deptos WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_depto = '" & valor1 & "'")

                                    valor2 = Trim(IIf(IsDBNull(drBitacora("ValorNuevo")), "SINDATO", drBitacora("ValorNuevo")))
                                    dtValor2 = sqlExecute("SELECT nombre FROM deptos WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_depto = '" & valor2 & "'")

                                    If dtValor1.Rows.Count > 0 Then
                                        drNuevo("DATO_ANTERIOR") = valor1 & "," & dtValor1.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_ANTERIOR") = ""
                                    End If

                                    If dtValor2.Rows.Count > 0 Then
                                        drNuevo("DATO_NUEVO") = valor2 & "," & dtValor2.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_NUEVO") = ""
                                    End If


                                Case "cod_super"

                                    valor1 = Trim(IIf(IsDBNull(drBitacora("ValorAnterior")), "SINDATO", drBitacora("ValorAnterior")))
                                    dtValor1 = sqlExecute("SELECT nombre FROM super WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_super = '" & valor1 & "'")

                                    valor2 = Trim(IIf(IsDBNull(drBitacora("ValorNuevo")), "SINDATO", drBitacora("ValorNuevo")))
                                    dtValor2 = sqlExecute("SELECT nombre FROM super WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_super = '" & valor2 & "'")

                                    If dtValor1.Rows.Count > 0 Then
                                        drNuevo("DATO_ANTERIOR") = valor1 & "," & dtValor1.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_ANTERIOR") = ""
                                    End If

                                    If dtValor2.Rows.Count > 0 Then
                                        drNuevo("DATO_NUEVO") = valor2 & "," & dtValor2.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_NUEVO") = ""
                                    End If


                                Case "cod_planta"

                                    valor1 = Trim(IIf(IsDBNull(drBitacora("ValorAnterior")), "SINDATO", drBitacora("ValorAnterior")))
                                    dtValor1 = sqlExecute("SELECT nombre FROM plantas WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_planta = '" & valor1 & "'")

                                    valor2 = Trim(IIf(IsDBNull(drBitacora("ValorNuevo")), "SINDATO", drBitacora("ValorNuevo")))
                                    dtValor2 = sqlExecute("SELECT nombre FROM plantas WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_planta = '" & valor2 & "'")

                                    If dtValor1.Rows.Count > 0 Then
                                        drNuevo("DATO_ANTERIOR") = valor1 & "," & dtValor1.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_ANTERIOR") = ""
                                    End If

                                    If dtValor2.Rows.Count > 0 Then
                                        drNuevo("DATO_NUEVO") = valor2 & "," & dtValor2.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_NUEVO") = ""
                                    End If

                                Case "cod_turno"

                                    valor1 = Trim(IIf(IsDBNull(drBitacora("ValorAnterior")), "SINDATO", drBitacora("ValorAnterior")))
                                    dtValor1 = sqlExecute("SELECT nombre FROM turnos WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_turno = '" & valor1 & "'")

                                    valor2 = Trim(IIf(IsDBNull(drBitacora("ValorNuevo")), "SINDATO", drBitacora("ValorNuevo")))
                                    dtValor2 = sqlExecute("SELECT nombre FROM turnos WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_turno = '" & valor2 & "'")

                                    If dtValor1.Rows.Count > 0 Then
                                        drNuevo("DATO_ANTERIOR") = valor1 & "," & dtValor1.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_ANTERIOR") = ""
                                    End If

                                    If dtValor2.Rows.Count > 0 Then
                                        drNuevo("DATO_NUEVO") = valor2 & "," & dtValor2.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_NUEVO") = ""
                                    End If

                                Case "cod_puesto"

                                    valor1 = Trim(IIf(IsDBNull(drBitacora("ValorAnterior")), "SINDATO", drBitacora("ValorAnterior")))
                                    dtValor1 = sqlExecute("SELECT nombre FROM puestos WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_puesto = '" & valor1 & "'")

                                    valor2 = Trim(IIf(IsDBNull(drBitacora("ValorNuevo")), "SINDATO", drBitacora("ValorNuevo")))
                                    dtValor2 = sqlExecute("SELECT nombre FROM puestos WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_puesto = '" & valor2 & "'")

                                    If dtValor1.Rows.Count > 0 Then
                                        drNuevo("DATO_ANTERIOR") = valor1 & "," & dtValor1.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_ANTERIOR") = ""
                                    End If

                                    If dtValor2.Rows.Count > 0 Then
                                        drNuevo("DATO_NUEVO") = valor2 & "," & dtValor2.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_NUEVO") = ""
                                    End If

                                Case "cod_hora"

                                    valor1 = Trim(IIf(IsDBNull(drBitacora("ValorAnterior")), "SINDATO", drBitacora("ValorAnterior")))
                                    dtValor1 = sqlExecute("SELECT nombre FROM horarios WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_hora = '" & valor1 & "'")

                                    valor2 = Trim(IIf(IsDBNull(drBitacora("ValorNuevo")), "SINDATO", drBitacora("ValorNuevo")))
                                    dtValor2 = sqlExecute("SELECT nombre FROM horarios WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_hora = '" & valor2 & "'")

                                    If dtValor1.Rows.Count > 0 Then
                                        drNuevo("DATO_ANTERIOR") = valor1 & "," & dtValor1.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_ANTERIOR") = ""
                                    End If

                                    If dtValor2.Rows.Count > 0 Then
                                        drNuevo("DATO_NUEVO") = valor2 & "," & dtValor2.Rows(0).Item(0).ToString
                                    Else
                                        drNuevo("DATO_NUEVO") = ""
                                    End If

                                Case Else
                                    drNuevo("DATO_ANTERIOR") = Trim(IIf(IsDBNull(drBitacora("ValorAnterior")), "", drBitacora("ValorAnterior")))
                                    drNuevo("DATO_NUEVO") = Trim(IIf(IsDBNull(drBitacora("ValorNuevo")), "", drBitacora("ValorNuevo")))
                            End Select

                            dtDatos.Rows.Add(drNuevo)

                        Catch ex As Exception

                        End Try

                    End If


                Next

            Else
                If dtBitacora.Columns.Count = 0 Or dtBitacora.Columns(0).ColumnName.ToString.Trim = "ERROR" Then

                    MsgBox("Se presentó un problema al intentar leer la información de bitacora de cambios." & vbCr & _
                           "Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "ERROR")

                Else
                    MsgBox("No hay información para mostrar. Favor de verificar el rango de fechas", MsgBoxStyle.Exclamation, "Aviso")
                End If

            End If


            ''**** Exporta a Excel ****

            'Dim sfd As New SaveFileDialog
            'Dim hoja_bitacora_cambios As ExcelWorksheet = wb.Worksheets.Add("Del " & FechaSQL(FechaInicial) & " al " & FechaSQL(FechaFinal))
            'Dim current_row_bc As Integer = 4
            'Dim current_col_bc As Integer = 1


            'Try

            '    If Not (dtDatos.Rows.Count > 0) Then
            '        Exit Sub
            '    End If

            '    sfd.Title = "Guardar Reporte"
            '    sfd.CheckFileExists = False
            '    sfd.CheckPathExists = False
            '    sfd.FileName = "Reporte_Bitacora_Cambios.xlsx"
            '    sfd.DefaultExt = "xlsx"
            '    sfd.Filter = "Excel (*.xlsx)|*.xlsx"
            '    sfd.RestoreDirectory = True

            '    If sfd.ShowDialog = DialogResult.OK Then


            '        '**** Nombre de las columnas ****
            '        hoja_bitacora_cambios.Cells(4, 1).Value = "CAMPO"
            '        hoja_bitacora_cambios.Cells(4, 2).Value = "FECHA"
            '        hoja_bitacora_cambios.Cells(4, 3).Value = "RELOJ"
            '        hoja_bitacora_cambios.Cells(4, 4).Value = "NOMBRES"
            '        hoja_bitacora_cambios.Cells(4, 5).Value = "TURNO"
            '        hoja_bitacora_cambios.Cells(4, 6).Value = "DATO ANTERIOR"
            '        hoja_bitacora_cambios.Cells(4, 7).Value = "DATO NUEVO"
            '        hoja_bitacora_cambios.Cells(4, 8).Value = "USUARIO"
            '        hoja_bitacora_cambios.Cells(4, 9).Value = "HORA"

            '        hoja_bitacora_cambios.Cells("A4:I4").Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            '        hoja_bitacora_cambios.Cells("A4:I4").Style.Fill.BackgroundColor.SetColor(Color.FromArgb(28, 58, 112))
            '        hoja_bitacora_cambios.Cells("A4:I4").Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255))
            '        hoja_bitacora_cambios.Cells("A4:I4").Style.Font.Size = 11
            '        hoja_bitacora_cambios.Cells("A4:I4").Style.Font.Bold = True
            '        hoja_bitacora_cambios.Cells("A4:I4").Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center

            '        For Each drFila As DataRow In dtDatos.Select("", "CAMPO,FECHA,RELOJ")
            '            current_row_bc += 1

            '            hoja_bitacora_cambios.Cells(current_row_bc, 1).Value = Trim(IIf(IsDBNull(drFila("CAMPO")), "", drFila("CAMPO")))
            '            hoja_bitacora_cambios.Cells(current_row_bc, 2).Value = Trim(IIf(IsDBNull(drFila("FECHA")), "", drFila("FECHA")))
            '            hoja_bitacora_cambios.Cells(current_row_bc, 3).Value = Trim(IIf(IsDBNull(drFila("RELOJ")), "", drFila("RELOJ")))
            '            hoja_bitacora_cambios.Cells(current_row_bc, 4).Value = Trim(IIf(IsDBNull(drFila("NOMBRES")), "", drFila("NOMBRES")))
            '            hoja_bitacora_cambios.Cells(current_row_bc, 5).Value = Trim(IIf(IsDBNull(drFila("TURNO")), "", drFila("TURNO")))
            '            hoja_bitacora_cambios.Cells(current_row_bc, 6).Value = Trim(IIf(IsDBNull(drFila("DATO_ANTERIOR")), "", drFila("DATO_ANTERIOR")))
            '            hoja_bitacora_cambios.Cells(current_row_bc, 7).Value = Trim(IIf(IsDBNull(drFila("DATO_NUEVO")), "", drFila("DATO_NUEVO")))
            '            hoja_bitacora_cambios.Cells(current_row_bc, 8).Value = Trim(IIf(IsDBNull(drFila("USUARIO")), "", drFila("USUARIO")))
            '            hoja_bitacora_cambios.Cells(current_row_bc, 9).Value = Trim(IIf(IsDBNull(drFila("HORA")), "", drFila("HORA")))
            '        Next

            '        hoja_bitacora_cambios.Cells(hoja_bitacora_cambios.Dimension.Address).AutoFitColumns()

            '        '**** Nombre de la compañia ****
            '        hoja_bitacora_cambios.Cells(1, 1).Value = "Datamark de México, S.A. de C.V."
            '        hoja_bitacora_cambios.Cells(1, 1).Style.Font.Bold = True
            '        hoja_bitacora_cambios.Cells(1, 1).Style.Font.Size = 12
            '        hoja_bitacora_cambios.Cells("A1:I1").Merge = True
            '        hoja_bitacora_cambios.Cells(1, 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center

            '        '**** Nombre del reporte ****
            '        hoja_bitacora_cambios.Cells(2, 1).Value = "BITACORA DE CAMBIOS"
            '        hoja_bitacora_cambios.Cells(2, 1).Style.Font.Bold = True
            '        hoja_bitacora_cambios.Cells(2, 1).Style.Font.Size = 14
            '        hoja_bitacora_cambios.Cells(2, 1).Style.Font.Color.SetColor(Color.FromArgb(28, 58, 112))
            '        hoja_bitacora_cambios.Cells("A2:I2").Merge = True
            '        hoja_bitacora_cambios.Cells(2, 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center

            '        '**** Rango de fechas consultadas para la bitacora de cambios ****
            '        hoja_bitacora_cambios.Cells(3, 1).Value = "Del " & FechaSQL(FechaInicial) & " al " & FechaSQL(FechaFinal)
            '        hoja_bitacora_cambios.Cells(3, 1).Style.Font.Bold = True
            '        hoja_bitacora_cambios.Cells(3, 1).Style.Font.Size = 12
            '        hoja_bitacora_cambios.Cells("A3:I3").Merge = True
            '        hoja_bitacora_cambios.Cells(3, 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center


            '        Try
            '            archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
            '            Process.Start(sfd.FileName)
            '        Catch ex As Exception
            '            MsgBox("El archivo no se pudo procesar. Favor de verificar", MsgBoxStyle.Critical, "Aviso")
            '        End Try



            '    End If

            'Catch ex As Exception
            '    MsgBox("El archivo no se pudo procesar. Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "Aviso")
            'End Try

        Catch ex As Exception
            MsgBox("Se presentó un problema al procesar la información. Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "ERROR")
        End Try

    End Sub


    Public Sub RespEncTot(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        '-----------Totales resumen
        Try
            Dim f1 As Date = FechaInicial
            Dim f2 As Date = FechaFinal

            dtDatos = New DataTable
            ' dtDatos.Columns.Add("reloj", GetType(System.String))
            dtDatos.Columns.Add("cod_pregunta", GetType(System.Int32))
            dtDatos.Columns.Add("pregunta", GetType(System.String))
            dtDatos.Columns.Add("respuesta", GetType(System.String))
            dtDatos.Columns.Add("total", GetType(System.Double))

            '--Cada tipo de pregunta
            Dim dtCodPreg As DataTable = sqlExecute("select distinct ed.COD_PREGUNTA,ep.TEXTO as PREGUNTA from encuestas_detalles ed left join encuestas_preguntas ep on ed.COD_PREGUNTA=ep.COD_PREGUNTA left join encuestas_respuestas er on ed.COD_RESPUESTA=er.COD_RESPUESTA " & _
                                                    "WHERE ep.COD_ENCUESTA='10005' and er.VALOR<>'RESPUESTA LIBRE' and ed.FECHA between '" & FechaSQL(f1) & "' and '" & FechaSQL(f2) & "' and ed.COD_PREGUNTA<>'' and ed.COD_PREGUNTA is not null ORDER by ed.COD_PREGUNTA asc", "KIOSCO")

            '--Obt Dist respuesta para cada pregunta
            For Each row As DataRow In dtCodPreg.Rows
                Dim cod_pregunta As Integer = IIf(IsDBNull(row("COD_PREGUNTA")), 0, Convert.ToInt32(row("COD_PREGUNTA")))
                Dim pregunta As String = IIf(IsDBNull(row("PREGUNTA")), "", row("PREGUNTA"))

                Dim dtRespuesta As DataTable = sqlExecute("select distinct er.VALOR AS RESPUESTA " & _
                                                          "from encuestas_detalles ed left join encuestas_preguntas ep on ed.COD_PREGUNTA=ep.COD_PREGUNTA left join encuestas_respuestas er on ed.COD_RESPUESTA=er.COD_RESPUESTA " & _
                                                          "WHERE ep.COD_ENCUESTA='10005' and er.VALOR<>'RESPUESTA LIBRE' and ed.FECHA between '" & FechaSQL(f1) & "' and '" & FechaSQL(f2) & "' and ed.COD_PREGUNTA=" & cod_pregunta & " and er.VALOR<>'' and er.VALOR is not null", "KIOSCO")

                '--Tener el total para cada respuesta
                For Each row2 In dtRespuesta.Rows
                    Dim respuesta As String = IIf(IsDBNull(row2("RESPUESTA")), "", row2("RESPUESTA"))
                    Dim dtTotal As DataTable = sqlExecute("select COUNT(ed.RELOJ) AS total " & _
                                                          "from encuestas_detalles ed left join encuestas_preguntas ep on ed.COD_PREGUNTA=ep.COD_PREGUNTA left join encuestas_respuestas er on ed.COD_RESPUESTA=er.COD_RESPUESTA " & _
                                                          "WHERE ep.COD_ENCUESTA='10005' and er.VALOR<>'RESPUESTA LIBRE' and ed.FECHA between '" & FechaSQL(f1) & "' and '" & FechaSQL(f2) & "' and ed.COD_PREGUNTA=" & cod_pregunta & " and er.VALOR='" & respuesta.ToString.Trim & "'", "KIOSCO")
                    Dim total As Double = IIf(IsDBNull(dtTotal.Rows(0)("total")), 0, Double.Parse(dtTotal.Rows(0)("total")))

                    Dim drow As DataRow = dtDatos.NewRow
                    drow("cod_pregunta") = cod_pregunta
                    drow("pregunta") = pregunta.Trim
                    drow("respuesta") = respuesta.Trim
                    drow("total") = total
                    dtDatos.Rows.Add(drow)

                Next

            Next


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub RespEncuestasKiosco(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", GetType(System.String))
            dtDatos.Columns.Add("cod_pregunta", GetType(System.Int32))
            dtDatos.Columns.Add("texto", GetType(System.String))
            dtDatos.Columns.Add("cod_respuesta", GetType(System.Int32))
            dtDatos.Columns.Add("valor", GetType(System.String))
            dtDatos.Columns.Add("fecha", GetType(System.String))
            dtDatos.Columns.Add("detalle_libre", GetType(System.String))
            dtDatos.Columns.Add("f_ini", GetType(System.String))
            dtDatos.Columns.Add("f_fin", GetType(System.String))
            dtDatos.Columns.Add("grupo", GetType(System.String))

            ' Definir rangos de fecha inicio y fin
            Dim _fini As Date = Now.Date
            Dim _ffin As Date = _fini.AddDays(7).Date

            Dim frm As New frmRangoFechas
            If frm.ShowDialog = DialogResult.OK Then
                _fini = FechaInicial
                _ffin = FechaFinal
            End If
            frmTrabajando.Show()
            Application.DoEvents()

            '--Para BRP J1/J2 el cod_encuesta = 10005,?? 
            Dim dtEncDetalle As DataTable = sqlExecute("select ed.RELOJ,ed.COD_PREGUNTA,ep.TEXTO,ed.COD_RESPUESTA,er.VALOR,ed.FECHA,ed.detalle_libre,ep.COD_ENCUESTA " & _
                                                       "from encuestas_detalles ed left join encuestas_preguntas ep on ed.COD_PREGUNTA=ep.COD_PREGUNTA left join encuestas_respuestas er on ed.COD_RESPUESTA=er.COD_RESPUESTA " & _
                                                       "WHERE ep.COD_ENCUESTA='10005' and ed.FECHA between '" & FechaSQL(_fini) & "' and '" & FechaSQL(_ffin) & "'order by FECHA desc", "KIOSCO")

            For Each row As DataRow In dtEncDetalle.Rows
                Dim reloj As String = IIf(IsDBNull(row("RELOJ")), "", row("RELOJ"))
                frmTrabajando.lblAvance.Text = reloj.Trim
                Application.DoEvents()
                Dim cod_pregunta As Integer = IIf(IsDBNull(row("COD_PREGUNTA")), 0, Convert.ToInt32(row("COD_PREGUNTA")))
                Dim texto As String = IIf(IsDBNull(row("TEXTO")), "", row("TEXTO"))
                Dim cod_respuesta As Integer = IIf(IsDBNull(row("COD_RESPUESTA")), 0, Convert.ToInt32(row("COD_RESPUESTA")))
                Dim valor As String = IIf(IsDBNull(row("VALOR")), "", row("VALOR"))
                Dim fecha As String = IIf(IsDBNull(row("FECHA")), "", row("FECHA"))
                Dim detalle_libre As String = IIf(IsDBNull(row("detalle_libre")), "", row("detalle_libre"))
                Dim grupo As String = IIf(valor = "RESPUESTA LIBRE", "Detalle Libre", "Detalle Opciones")

                Dim drow As DataRow = dtDatos.NewRow
                drow("reloj") = reloj.Trim
                drow("cod_pregunta") = cod_pregunta
                drow("texto") = texto.Trim
                drow("cod_respuesta") = cod_respuesta
                drow("valor") = valor.Trim
                drow("fecha") = FechaSQL(fecha)
                drow("detalle_libre") = detalle_libre.Trim
                drow("f_ini") = FechaSQL(_fini)
                drow("f_fin") = FechaSQL(_ffin)
                drow("grupo") = grupo.Trim

                dtDatos.Rows.Add(drow)
            Next

            ActivoTrabajando = False
            frmTrabajando.Close()
        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

    End Sub

    Public Sub EstadisticaKiosco(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", GetType(System.String))
            dtDatos.Columns.Add("nombre_grupo", GetType(System.String))
            dtDatos.Columns.Add("actividad", GetType(System.String))
            dtDatos.Columns.Add("periodo", GetType(System.String))
            dtDatos.Columns.Add("f_inic", GetType(System.String))
            dtDatos.Columns.Add("f_fin", GetType(System.String))
            dtDatos.Columns.Add("cuantos", GetType(System.Double))


            ' Definir rangos de fecha inicio y fin
            Dim _fini As Date = Now.Date
            Dim _ffin As Date = _fini.AddDays(7).Date

            Dim frm As New frmRangoFechas
            If frm.ShowDialog = DialogResult.OK Then
                _fini = FechaInicial
                _ffin = FechaFinal
            End If

            frmTrabajando.Show()
            Application.DoEvents()

            Dim dtPeriodos As DataTable = sqlExecute("SELECT * from periodos where FECHA_INI>='" & FechaSQL(_fini) & "' and FECHA_FIN<='" & FechaSQL(_ffin) & "' and PERIODO_ESPECIAL<>1 order by PERIODO asc", "TA")
            Dim dtActividad As DataTable = sqlExecute("select distinct ACTIVIDAD AS ACTIVIDAD from ActivityLog", "KIOSCO")
            '  Dim dtReloj As DataTable = sqlExecute("SELECT distinct RELOJ as RELOJ from ActivityLog WHERE CONVERT(date, FECHA_HORA) BETWEEN '" & FechaSQL(_fini) & "' and  '" & FechaSQL(_ffin) & "' and RELOJ is not null and RELOJ<>'' order by RELOJ asc", "KIOSCO")

            For Each row As DataRow In dtPeriodos.Rows ' Recorrer cada uno de los periodos

                Dim Periodo As String = IIf(IsDBNull(row("PERIODO")), "", row("PERIODO"))
                Dim f_iniPer As String = IIf(IsDBNull(row("FECHA_INI")), "", row("FECHA_INI"))
                Dim f_finPer As String = IIf(IsDBNull(row("FECHA_FIN")), "", row("FECHA_FIN"))

                frmTrabajando.lblAvance.Text = FechaSQL(f_iniPer)
                Application.DoEvents()


                For Each row2 As DataRow In dtActividad.Rows
                    Dim actividad As String = IIf(IsDBNull(row2("ACTIVIDAD")), "", row2("ACTIVIDAD"))
                    Dim nombre_grupo As String = ObtNombreGrupoAct(actividad.ToString.Trim)
                    Dim dtCtos As DataTable = sqlExecute("select count(RELOJ) as cuantos from ActivityLog where ACTIVIDAD like'%" & actividad.Trim & "%' and  CONVERT(date, FECHA_HORA) BETWEEN '" & FechaSQL(f_iniPer.ToString.Trim) & "' and  '" & FechaSQL(f_finPer.ToString.Trim) & "'", "KIOSCO")
                    Dim cuantos As Double = IIf(IsDBNull(dtCtos.Rows(0)("cuantos")), 0, Double.Parse(dtCtos.Rows(0)("cuantos")))
                    If (actividad <> "" And cuantos > 0 And actividad <> "SOLICITAR PRESTAMO") Then
                        Dim drow As DataRow = dtDatos.NewRow
                        drow("periodo") = Periodo.ToString.Trim
                        drow("f_inic") = FechaSQL(_fini)
                        drow("f_fin") = FechaSQL(_ffin)
                        drow("nombre_grupo") = nombre_grupo.ToString.Trim
                        drow("actividad") = actividad.ToString.Trim
                        drow("cuantos") = cuantos
                        dtDatos.Rows.Add(drow)
                    End If
                Next

                '--Add el Retiro de Fondo de Ahorro el cual es aparte
                Dim dtCtosRetFAH As DataTable = sqlExecute("SELECT count(RELOJ) as cuantos from prestamos where fecha_sol between '" & FechaSQL(f_iniPer.ToString.Trim) & "' and '" & FechaSQL(f_finPer.ToString.Trim) & "'", "KIOSCO")
                Dim cuantosRetFAH As Double = IIf(IsDBNull(dtCtosRetFAH.Rows(0)("cuantos")), 0, Double.Parse(dtCtosRetFAH.Rows(0)("cuantos")))
                Dim drow2 As DataRow = dtDatos.NewRow
                drow2("periodo") = Periodo.ToString.Trim
                drow2("f_inic") = FechaSQL(_fini)
                drow2("f_fin") = FechaSQL(_ffin)
                drow2("nombre_grupo") = "Nómina"
                drow2("actividad") = "RETIRO FONDO DE AHORRO"
                drow2("cuantos") = cuantosRetFAH
                dtDatos.Rows.Add(drow2)

                '---Add detalle por empleado
                Dim dtGroupReloj As DataTable = sqlExecute("Select RELOJ,COUNT(reloj) as cuantos,ACTIVIDAD from ActivityLog where ACTIVIDAD like'%LOGUEO%' and  CONVERT(date, FECHA_HORA) BETWEEN '" & FechaSQL(f_iniPer.ToString.Trim) & "' and  '" & FechaSQL(f_finPer.ToString.Trim) & "' Group by reloj,ACTIVIDAD order by RELOJ asc", "KIOSCO")
                For Each row3 As DataRow In dtGroupReloj.Rows
                    Dim NoReloj As String = IIf(IsDBNull(row3("RELOJ")), "", row3("RELOJ"))
                    Dim ctosReloj As Double = IIf(IsDBNull(row3("cuantos")), 0, Double.Parse((row3("cuantos"))))
                    If (NoReloj <> "" And ctosReloj > 0) Then
                        Dim drow3 As DataRow = dtDatos.NewRow
                        drow3("periodo") = Periodo.ToString.Trim
                        drow3("f_inic") = FechaSQL(_fini)
                        drow3("f_fin") = FechaSQL(_ffin)
                        drow3("nombre_grupo") = "Reloj (# Empleado)"
                        drow3("actividad") = NoReloj.Trim
                        drow3("cuantos") = ctosReloj
                        dtDatos.Rows.Add(drow3)
                    End If
                Next

                '----Add Family Center
                Dim dtGroupFC As DataTable = sqlExecute("select SUBSTRING(codigo,1,3) as reloj, COUNT(reloj) as cuantos from SOLICITUDES_PRESTAMO " & _
                                                        "where CONVERT(date,fecha_solicita)  between '" & FechaSQL(f_iniPer.ToString.Trim) & "' and '" & FechaSQL(f_finPer.ToString.Trim) & "' group by SUBSTRING(codigo,1,3)", "KIOSCO")
                If (dtGroupFC.Rows.Count > 0) Then
                    For Each row4 As DataRow In dtGroupFC.Rows
                        Dim nombreTipo As String = ObtNomFC(IIf(IsDBNull(row4("reloj")), "", row4("reloj")))
                        Dim ctosFC As Double = IIf(IsDBNull(row4("cuantos")), 0, Double.Parse((row4("cuantos"))))
                        If (nombreTipo.Trim <> "" And ctosFC > 0) Then
                            Dim drow4 As DataRow = dtDatos.NewRow
                            drow4("periodo") = Periodo.ToString.Trim
                            drow4("f_inic") = FechaSQL(_fini)
                            drow4("f_fin") = FechaSQL(_ffin)
                            drow4("nombre_grupo") = "Family Center"
                            drow4("actividad") = nombreTipo.Trim
                            drow4("cuantos") = ctosFC
                            dtDatos.Rows.Add(drow4)
                        End If
                    Next
                End If

            Next
            ActivoTrabajando = False
            frmTrabajando.Close()
        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Private Function ObtNombreGrupoAct(ByRef _act As String) As String
        Try
            If (_act <> "") Then
                Select Case _act
                    Case "LoginSF", "LOGUEO"
                        Return "Menu Principal"
                    Case "CONSULTA DE ESCOLARIDAD", "CONSULTA DE EXPEDIENTE", "CONSULTA DE KARDEX", "IMPRIMIR CARTA", "RESPONDER ENCUESTA", "CONSULTA DE FAMILIARES", "SOLICITUD DE MISCELANEO"
                        Return "Recursos Humanos"
                    Case "CONSULTA DE AHORRO", "APROBACION DE PRESTAMO", "CONSULTA PDF", "REIMPRIMIR RECIBO", "CONSULTA XML", "EXPORTACION DE RETIROS", "IMPRIMIR RECIBO", "Deshabilitar envio", "SOLICITAR PRESTAMO"
                        Return "Nómina"
                    Case Else
                        Return "Otros"
                End Select
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Function ObtNomFC(ByRef _tipo As String) As String
        Try
            If (_tipo.Trim <> "" And _tipo.Trim <> "-") Then
                Select Case _tipo.Trim
                    Case "BR-"
                        Return "SOLICITUD BLUE RAY"
                    Case "DVD"
                        Return "SOLICITUD DVD"
                    Case "HER"
                        Return "SOLICITUD HERRAMIENTAS"
                    Case "LIT"
                        Return "SOLICITUD LIBROS"
                    Case "MUS", "MS-"
                        Return "SOLICITUD MUSICA"
                    Case "SER"
                        Return "SOLICITUD SERIES"
                    Case Else
                        Return "SOLICITUD HERRAMIENTAS"
                End Select
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub DatosSerMed(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", GetType(System.String))
            dtDatos.Columns.Add("nombres", GetType(System.String))
            dtDatos.Columns.Add("COD_DEPTO", GetType(System.String))
            dtDatos.Columns.Add("COD_PUESTO", GetType(System.String))
            dtDatos.Columns.Add("nombre_depto", GetType(System.String))
            dtDatos.Columns.Add("nombre_puesto", GetType(System.String))
            dtDatos.Columns.Add("ALTA")
            dtDatos.Columns.Add("alta_vacacion")
            dtDatos.Columns.Add("IMSS", GetType(System.String))
            dtDatos.Columns.Add("CURP", GetType(System.String))
            dtDatos.Columns.Add("tipo_periodo", GetType(System.String))
            dtDatos.Columns.Add("ESTATUS", GetType(System.String))
            dtDatos.Columns.Add("BAJA")
            dtDatos.Columns.Add("sexo", GetType(System.String))
            dtDatos.Columns.Add("TELEFONO5", GetType(System.String))
            dtDatos.Columns.Add("FHA_NAC")
            dtDatos.Columns.Add("edad", GetType(System.String))

            frmTrabajando.Show()
            Application.DoEvents()

            For Each row As DataRow In dtInformacion.Rows
                Dim drow As DataRow = dtDatos.NewRow
                frmTrabajando.lblAvance.Text = row("reloj").ToString.Trim ' Si no incluyeramos fecha, solo el no
                Application.DoEvents()

                '--Definicion de variables que se inicializan
                Dim NoReloj As String = row("reloj").ToString.Trim
                Dim ALTA As String = ""
                ALTA = row("ALTA").ToString.Trim
                Dim alta_vacacion As String = ""
                alta_vacacion = row("alta_vacacion").ToString.Trim
                Dim BAJA As String = ""
                BAJA = row("BAJA").ToString.Trim
                Dim FHA_NAC As String = ""
                FHA_NAC = row("FHA_NAC").ToString.Trim
                Dim edad As String = ""
                '----Validar Estatus
                Dim ESTATUS As String = ""
                If (ALTA <> "" And BAJA <> "") Then
                    ESTATUS = "INACTIVO"
                Else
                    ESTATUS = "ACTIVO"
                End If
                '--Ends

                drow("reloj") = NoReloj
                drow("nombres") = row("nombres").ToString.Trim
                drow("COD_DEPTO") = row("COD_DEPTO").ToString.Trim
                drow("COD_PUESTO") = row("COD_PUESTO").ToString.Trim
                drow("nombre_depto") = row("nombre_depto").ToString.Trim
                drow("nombre_puesto") = row("nombre_puesto").ToString.Trim
                If (ALTA <> "") Then
                    drow("ALTA") = FechaSQL(ALTA)
                End If
                If (alta_vacacion <> "") Then
                    drow("alta_vacacion") = FechaSQL(alta_vacacion)
                End If
                drow("IMSS") = IIf(IsDBNull(row("IMSS")), "", row("IMSS").ToString.Trim)
                drow("CURP") = IIf(IsDBNull(row("CURP")), "", row("CURP").ToString.Trim)
                drow("tipo_periodo") = IIf(IsDBNull(row("tipo_periodo")), "", row("tipo_periodo").ToString.Trim)
                drow("ESTATUS") = ESTATUS
                If (BAJA <> "") Then
                    drow("BAJA") = FechaSQL(BAJA)
                End If
                drow("sexo") = IIf(IsDBNull(row("sexo")), "", row("sexo").ToString.Trim)
                drow("TELEFONO5") = IIf(IsDBNull(row("TELEFONO5")), "", row("TELEFONO5").ToString.Trim)
                If (FHA_NAC <> "") Then
                    drow("FHA_NAC") = FechaSQL(FHA_NAC)
                End If
                edad = IIf(IsDBNull(row("edad")), "", row("edad").ToString.Trim)
                edad = IIf((edad <> "" And edad.ToString.Contains("-")), edad.Replace("-", ""), edad)
                'If (edad <> "" And edad.ToString.Contains("-")) Then
                '    edad = edad.Replace("-", "")
                'End If
                drow("edad") = edad
                dtDatos.Rows.Add(drow)
            Next

            ActivoTrabajando = False ' Desactivamos el LOADING
            frmTrabajando.Close()

        Catch ex As Exception
            ActivoTrabajando = False ' Desactivamos el LOADING
            frmTrabajando.Close()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

    End Sub

    Public Sub ModificacionesIMSS_Topados(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            Dim dtEmpleadosTopados As New DataTable
            Dim QBuscar As String = ""
            Dim tope_ant As Double = 0.0
            Dim tope_new As Double = 0.0
            Dim dtTemp As New DataTable

            Dim Columnas(20) As DataColumn
            Dim ArchivoFoto As String = ""

            Dim PathFoto As String = ""
            Dim strFileName As String = ""

            Dim oWrite As System.IO.StreamWriter
            Dim x As Integer = 0
            Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
            Dim z As Integer = 0
            Dim GuardaArchivo As Boolean = True


            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("rfc", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("infonavit", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("cod_comp", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("compañia", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("paterno", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("materno", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("nombre", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("integrado", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("tipo_trab", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("tipo_sdo", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("sem_jorred", System.Type.GetType("System.String"))
            Columnas(14) = New DataColumn("modi", System.Type.GetType("System.String"))
            Columnas(15) = New DataColumn("umf", System.Type.GetType("System.String"))
            Columnas(16) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(17) = New DataColumn("guia", System.Type.GetType("System.String"))
            Columnas(18) = New DataColumn("reloj", System.Type.GetType("System.String"))
            Columnas(19) = New DataColumn("curp", System.Type.GetType("System.String"))
            Columnas(20) = New DataColumn("identifica", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            '---Enviar fecha de la modif de salario
            Dim fecModifDate As Date, fecModSal As String = ""
            Dim selFecha As frmSeleccionarFecha = New frmSeleccionarFecha()
            selFecha.ShowDialog()
            fecModifDate = selFecha.dtFechaInicial.Value
            fecModSal = FechaSQL(selFecha.dtFechaInicial.Value)

            '---Obtener tope actual

            If (dtInformacion.Rows.Count > 0) Then
                dtTemp = sqlExecute("  SELECT rfc, infonavit, reg_pat, nombre, guia, uma * 25 AS tope_new, uma_ant *25 as tope_ant FROM cias WHERE cod_comp='" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                If (Not dtTemp.Columns.Contains("Error") And dtTemp.Rows.Count > 0) Then
                    Try : tope_ant = Double.Parse(dtTemp.Rows(0).Item("tope_ant").ToString.Trim) : Catch ex As Exception : tope_ant = 0.0 : End Try
                    Try : tope_new = Double.Parse(dtTemp.Rows(0).Item("tope_new").ToString.Trim) : Catch ex As Exception : tope_new = 0.0 : End Try
                End If
            Else
                MessageBox.Show("No hay información en la tabla CIAS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            QBuscar = "select * from personalvw where isnull(baja,'')='' and INTEGRADO>=" & tope_ant
            dtEmpleadosTopados = sqlExecute(QBuscar, "PERSONAL")

            If (Not dtEmpleadosTopados.Columns.Contains("Error") And dtEmpleadosTopados.Rows.Count > 0) Then

                Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog
                PreguntaArchivo.Filter = "Text file|*.txt"
                PreguntaArchivo.FileName = ""
                If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    strFileName = PreguntaArchivo.FileName
                    'Dim objFSx As New FileStream(strFileName, FileMode.Create, FileAccess.Write)
                    'Dim objSW as StreamWriter(objFS)

                End If
                Try
                    oWrite = File.CreateText(strFileName)
                    GuardaArchivo = True
                Catch ex As Exception
                    oWrite = Nothing
                    GuardaArchivo = False
                End Try

                For Each dRow As DataRowView In dtEmpleadosTopados.DefaultView

                    Dim rj As String = "", sactual As Double = 0.0, factor_int As Double = 0.0, pro_var As Double = 0.0, integTemp As Double = 0.0

                    Try : rj = dRow("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                    Try : sactual = Double.Parse(dRow("sactual")) : Catch ex As Exception : sactual = 0.0 : End Try
                    Try : factor_int = Double.Parse(dRow("factor_int")) : Catch ex As Exception : factor_int = 0.0 : End Try
                    Try : pro_var = Double.Parse(dRow("pro_var")) : Catch ex As Exception : pro_var = 0.0 : End Try

                    Dim integ As String = "0"

                    integTemp = Math.Round(((sactual * factor_int) + pro_var), 2)

                    If (integTemp >= tope_new) Then integTemp = tope_new

                    integ = Format(integTemp, "f")

                    dtDatos.Rows.Add(dtTemp.Rows(0).Item("rfc"), dtTemp.Rows(0).Item("infonavit"), dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), dRow("cod_comp"), dtTemp.Rows(0).Item("nombre"), dRow("apaterno"), dRow("amaterno"), dRow("nombre"),
integ,
                 "1", "2", "0", FechaDMY(fecModSal), dRow("umf"), "07", dtTemp.Rows(0).Item("guia"), rj, dRow("curp"), "9")
                    x = dtDatos.Rows.Count - 1

                    If GuardaArchivo Then
                        oWrite.WriteLine(dtDatos.Rows(x).Item("reg_pat").ToString.Trim.PadRight(11) & _
                                        dtDatos.Rows(x).Item("imss").ToString.Trim.PadRight(10) & _
                                        dtDatos.Rows(x).Item("dig_ver").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("paterno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(x).Item("materno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(x).Item("nombre").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(x).Item("integrado").ToString.Trim.Replace(".", "").PadLeft(6, "0") & _
                                        Space(6) & _
                                        dtDatos.Rows(x).Item("tipo_trab").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("tipo_sdo").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("sem_jorred").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("modi").ToString.Trim.PadRight(8) & _
                                        dtDatos.Rows(x).Item("umf").ToString.Trim.PadRight(3) & _
                                        Space(2) & _
                                        dtDatos.Rows(x).Item("tipo_mov").ToString.Trim.PadRight(2) & _
                                        dtDatos.Rows(x).Item("guia").ToString.Trim.PadRight(5) & _
                                        dtDatos.Rows(x).Item("reloj").ToString.Trim.PadRight(10) & _
                                        " " & _
                                        dtDatos.Rows(x).Item("curp").ToString.Trim.PadRight(18) & _
                                        dtDatos.Rows(x).Item("identifica").ToString.Trim.PadRight(1))
                    End If

                Next

                If GuardaArchivo Then
                    oWrite.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
                    oWrite.Close()
                End If

                Console.WriteLine("")
                Console.WriteLine("File creation complete. Press <Enter> to close this window.")

            Else
                MessageBox.Show("No se encontraron empleados topados para procesar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Debug.Print(ex.StackTrace)
        End Try
    End Sub

  
    Public Sub EmpleadosSinRuta(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("cod_comp")
            dtDatos.Columns.Add("fecha_alta")
            dtDatos.Columns.Add("codigo_area")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("nombre_area")
            dtDatos.Columns.Add("codigo_puesto")
            dtDatos.Columns.Add("rfc")
            dtDatos.Columns.Add("nombre_puesto")
            dtDatos.Columns.Add("COD_TIPO")

            ' Personal que no tiene Ruta asignado
            Dim dtPersonalSinRuta As DataTable = sqlExecute("select ps.reloj,ps.cod_comp,ps.nombres,ps.ALTA,ps.cod_area,ps.nombre_area,ps.COD_PUESTO,ps.nombre_puesto,ps.RFC from personalvw ps" & _
                                                            " WHERE NOT EXISTS (select * from detalle_auxiliares da where da.RELOJ = ps.RELOJ and campo like'%RUTA%')" & _
                                                            " AND ps.BAJA IS NULL and ps.COD_COMP in('610','002')")
            Dim total As Integer
            total = dtInformacion.Rows.Count ' Var para sacar el total de registros

            'Mostrar avance de resultados
            frmTrabajando.Show()
            Application.DoEvents()


            For Each row As DataRow In dtInformacion.Rows
                'Mostrar avance para cada registro
                frmTrabajando.lblAvance.Text = row("reloj")
                Application.DoEvents()

                Dim drow As DataRow = dtDatos.NewRow
                drow("reloj") = row("reloj")

                Dim drow_sinRuta As DataRow = Nothing
                Try
                    drow_sinRuta = dtPersonalSinRuta.Select("reloj = '" & row("reloj") & "'")(0)
                Catch ex As Exception

                End Try

                If Not IsNothing(drow_sinRuta) Then
                    drow("cod_comp") = row("cod_comp")
                    drow("fecha_alta") = FechaSQL(row("alta"))
                    drow("codigo_area") = row("cod_area")
                    drow("nombres") = row("nombres")
                    drow("nombre_area") = row("nombre_area")
                    drow("codigo_puesto") = row("COD_PUESTO")
                    drow("rfc") = row("rfc")
                    drow("nombre_puesto") = row("nombre_puesto")
                    Select Case (row("COD_TIPO").ToString.Trim())
                        Case "A"
                            drow("COD_TIPO") = "Administrativo"
                        Case "O"
                            drow("COD_TIPO") = "Operativo"
                        Case Else
                            drow("COD_TIPO") = "No definido"
                    End Select
                    dtDatos.Rows.Add(drow)
                End If
            Next

            ActivoTrabajando = False
            frmTrabajando.Close()

        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub ReporteDeRutasEnt_Sal(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("COD_COMP")
            dtDatos.Columns.Add("reloj_alt")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("cod_clerk")
            dtDatos.Columns.Add("nombre_clerk")
            dtDatos.Columns.Add("cod_hora")
            dtDatos.Columns.Add("fecha")
            dtDatos.Columns.Add("cod_ruta")
            dtDatos.Columns.Add("cod_grupo")
            'AOS 04/09/2018 - Cliente solicita columna que traiga el nombre del área de cada empleado
            dtDatos.Columns.Add("cod_area")
            dtDatos.Columns.Add("nombre_area")
            dtDatos.Columns.Add("te_aut") 'Indicador para saber si tiene tiempo extra
            dtDatos.Columns.Add("desc_grp_ent")
            dtDatos.Columns.Add("desc_grp_sal")
            '-AOS : Para mandar en un solo reporte tanto Entrada como Salida
            dtDatos.Columns.Add("cod_grupo_ent")
            dtDatos.Columns.Add("nombre_grupo_ent")
            dtDatos.Columns.Add("cod_ruta_ent")
            dtDatos.Columns.Add("nombre_puesto")

            Dim _teaut As Integer = 0

            ' Definir rangos de fecha inicio y fin
            Dim _fini As Date = Now.Date
            Dim _ffin As Date = _fini.AddDays(7).Date

            Dim frm As New frmRangoFechas
            If frm.ShowDialog = DialogResult.OK Then
                _fini = FechaInicial
                _ffin = FechaFinal
            End If

            'Mostrar avance de resultados
            frmTrabajando.Show()
            Application.DoEvents()

            ' Definir la var _campo_ruta que va a ser el tipo a filtrar, si sería el concepto de "RUTA" O "PARADA"
            '  Dim _campo_ruta As String = "prueba_r"
            Dim _campo_ruta As String = "RUTA"

            'Dim dtParametros As DataTable = sqlExecute("select auxiliar_ruta from parametros where auxiliar_ruta is not null")
            'If dtParametros.Rows.Count > 0 Then
            '    _campo_ruta = RTrim(dtParametros.Rows(0)("auxiliar_ruta"))
            'End If

            Dim dtPeriodos As DataTable = sqlExecute("select * from periodos where isnull(periodo_especial, 0) = 0", "ta")
            Dim dtCalendario As DataTable = sqlExecute(" select " & _
" rol_horarios.ano, " & _
" rol_horarios.periodo, " & _
" dias.cod_hora, " & _
" dias.semana, " & _
" dias.COD_DIA, " & _
" dias.COD_DIA_SAL, " & _
" dias.entra, " & _
" dias.sale, " & _
" dias.cod_grupo, " & _
" dias.cod_grupo_sal, " & _
" dias.desc_grp_ent, " & _
" dias.desc_grp_sal " & _
" from dias " & _
" left join rol_horarios on rol_horarios.cod_hora = dias.cod_hora and rol_horarios.semana = dias.semana " & _
" where rol_horarios.ano is not null  and dias.descanso = 0 ")

            Dim dtExtrasAutor As DataTable = sqlExecute("SELECT RELOJ,FECHA,EXTRAS_REALES,EXTRAS_AUTORIZADAS,ANALIZADO FROM extras_autorizadas where  fecha BETWEEN '" & FechaSQL(_fini) & "' and '" & FechaSQL(_fini) & "' order by fecha asc", "TA")

            'Obtener todas las rutas de todos los empleados asignado
            Dim dtRutas As DataTable = sqlExecute("select * from detalle_auxiliares where campo = '" & _campo_ruta & "' and rtrim(isnull(contenido, '')) <> ''")

            'Recorrer en ciclo mientras la fecha inicial no sea mayor a la fecha final
            While _fini <= _ffin
                'Definir en un DATAROW el periodo que cae en esa fecha específicamente que estamos analizando en este momento
                Dim drow_periodos As DataRow = Nothing
                Try
                    drow_periodos = dtPeriodos.Select("fecha_ini <= '" & FechaSQL(_fini) & "' and fecha_fin >= '" & FechaSQL(_fini) & "'")(0)
                Catch ex As Exception

                End Try

                'Si no encontró un periodo, si es nulo
                If IsNothing(drow_periodos) Then
                    Err.Raise(-1, "", "No existe periodo para la fecha seleccionada")
                End If

                'Definir en la var dia_sem el numero de del día de la semana_
                Dim dia_sem As Integer = _fini.DayOfWeek

                For Each row As DataRow In dtInformacion.Rows
                    'Mostrar avance para cada registro
                    frmTrabajando.lblAvance.Text = FechaSQL(_fini) & "/" & row("reloj")
                    Application.DoEvents()
                    Dim entrada As Boolean = False
                    Dim salida As Boolean = False

                    Dim drow As DataRow = dtDatos.NewRow
                    Dim cod_grp_ent As String = ""
                    Dim cod_grp_Sal As String = ""
                    drow("reloj") = row("reloj")
                    drow("cod_comp") = row("cod_comp")
                    drow("nombres") = row("nombres") ' Columna para los nombres
                    drow("cod_hora") = row("cod_hora") 'Columna para el cod_hora
                    drow("cod_clerk") = row("cod_clerk") 'Columna para el cod_clrerk
                    drow("nombre_clerk") = row("nombre_clerk") 'Columna para el nombre_clerk
                    drow("cod_area") = row("cod_area") 'Columna para el Código del Area
                    drow("nombre_area") = row("nombre_area") 'Columna para la descrip del Area
                    drow("nombre_puesto") = row("nombre_puesto") 'Columna para el nombre del Puesto

                    If drow("cod_comp").ToString.Trim = "002" Then
                        drow("reloj_alt") = row("reloj_alt")
                    Else
                        drow("reloj_alt") = ""
                    End If

                    'La columna fecha la insertamos con el día que vaya en ese momento
                    drow("fecha") = FechaSQL(_fini)

                    Dim drow_ruta As DataRow = Nothing
                    Try
                        drow_ruta = dtRutas.Select("reloj = '" & row("reloj") & "'")(0) 'Aqui capturamos en este ROW todo ese registro encontrado
                    Catch ex As Exception

                    End Try

                    'Validar si tiene

                    'Si no es nulo, es decir, si se encontró ese numero de reloj, entonces mete al campo cod_ruta lo que traiga la columna contenido
                    If Not IsNothing(drow_ruta) Then

                        drow("cod_ruta") = drow_ruta("contenido") 'Inserta al cod_ruta lo encontrado o lo que traes  en el DATAROW drow_ruta

                        'Lo mismo hacemos para obtener el cod_grupo, pero esto es mas complejo
                        Dim drow_rol As DataRow = Nothing 'Generamos una var drow_rol que va a ser un DR que va a contener un solo registro
                        Try
                            '---------------Definir Grupos de Entrada

                            drow_rol = dtCalendario.Select(" ano = '" & drow_periodos("ano") & "' and periodo = '" & drow_periodos("periodo") & "' and cod_hora = '" & row("cod_hora") & "' and cod_dia = '" & dia_sem & "'")(0)
                            If Not IsNothing(drow_rol) Then
                                drow("cod_grupo_ent") = drow_rol("cod_grupo").ToString.Trim 'Metemos al registro cod_grup lo encontrado en el Row anterior que es drow_rol
                                drow("desc_grp_ent") = drow_rol("desc_grp_ent")
                                'Si tiene Grupo de Entrada insertar el registro
                                If (drow("cod_grupo_ent") <> "") Then
                                    entrada = True
                                End If
                            End If

                            '-------------------Definir Grupos de Salida
                            'Validar si ese empleado tiene T.Extra Autorizado y si tiene y cumple el formato mandarla a una var double para sumar
                            Dim _tExtAutor As String = "" 'Var que va a contener el Tiempo Extra Autorizado tipo string
                            Dim _tExtAutorDbl As Double = 0.0 'Ya va a estar convertida en tipo Double para sumar

                            Dim drow_teAutor As DataRow = Nothing
                            Try
                                drow_teAutor = dtExtrasAutor.Select("FECHA = '" & FechaSQL(_fini) & "' AND RELOJ='" & row("reloj") & "'")(0)
                            Catch ex As Exception

                            End Try

                            If Not IsNothing(drow_teAutor) Then 'Si encontró un registro de tiempo extra autorizado
                                _tExtAutor = drow_teAutor("extras_autorizadas") 'Capturamos el valor que trae ese campo y lo validamos si cumple con el formato

                                If ((_tExtAutor <> "" Or _tExtAutor <> "TODO" Or _tExtAutor <> "NULL") And (_tExtAutor.Substring(2, 1) = ":")) Then 'Si viene 02:15 x ejemplo
                                    _tExtAutor = _tExtAutor.Substring(0, 2) & "." & _tExtAutor.Substring(3, 2) 'Lo mandamos 02.15 x ejemplo
                                    _tExtAutorDbl = Double.Parse(_tExtAutor) 'Lista para sumar, se convierte a 2.15

                                End If
                            End If

                            If _tExtAutorDbl > 0 Then
                                ' Si hay tiempo extra autorizado para ese empleado
                                drow("te_aut") = 1  ' Para indicar en el reporte que SI tiene TE_Aut
                                drow_rol = dtCalendario.Select(" ano = '" & drow_periodos("ano") & "' and periodo = '" & drow_periodos("periodo") & "' and cod_hora = '" & row("cod_hora") & "' and cod_dia_sal = '" & dia_sem & "'")(0)
                                If Not IsNothing(drow_rol) Then 'Encontrando el Rol
                                    Dim GrupoSal As String = ""
                                    GrupoSal = drow_rol("cod_grupo_sal").ToString.Trim
                                    GrupoSal = GrupoSal.Substring(0, 1).ToUpper

                                    Select Case GrupoSal
                                        Case "A"
                                            If (_tExtAutorDbl >= 3 And _tExtAutorDbl <= 10) Then
                                                drow("cod_grupo") = "B-02:45 PM"
                                                drow("desc_grp_sal") = "2do Turno"
                                            End If
                                        Case "B"
                                            If (_tExtAutorDbl >= 0.3 And _tExtAutorDbl <= 1.5) Then
                                                drow("cod_grupo") = "C-04:20 PM"
                                                drow("desc_grp_sal") = "Mixto"
                                            End If
                                            If (_tExtAutorDbl >= 2 And _tExtAutorDbl <= 2.5) Then
                                                drow("cod_grupo") = "D-06:45 PM"
                                                drow("desc_grp_sal") = "12 X 12"
                                            End If
                                            If (_tExtAutorDbl >= 7 And _tExtAutorDbl <= 8.5) Then
                                                drow("cod_grupo") = "E-10:15 PM"
                                                drow("desc_grp_sal") = "3er Turno"
                                            End If
                                            If (_tExtAutorDbl > 8.5) Then
                                                drow("cod_grupo") = "F-00:45 AM"
                                                drow("desc_grp_sal") = "Mixto"
                                            End If
                                        Case "C"
                                            If (_tExtAutorDbl >= 0.5 And _tExtAutorDbl <= 1.5) Then
                                                drow("cod_grupo") = "D-06:45 PM"
                                                drow("desc_grp_sal") = "12 X 12"
                                            End If
                                            If (_tExtAutorDbl > 5.9 And _tExtAutorDbl <= 8) Then
                                                drow("cod_grupo") = "E-10:15 PM"
                                                drow("desc_grp_sal") = "3er Turno"
                                            End If
                                            If (_tExtAutorDbl > 8) Then
                                                drow("cod_grupo") = "F-00:45 AM"
                                                drow("desc_grp_sal") = "Mixto"
                                            End If
                                        Case "D"

                                            If (_tExtAutorDbl >= 3 And _tExtAutorDbl <= 6.5) Then
                                                drow("cod_grupo") = "E-10:15 PM"
                                                drow("desc_grp_sal") = "3er Turno"
                                            End If
                                            If (_tExtAutorDbl > 6.5) Then
                                                drow("cod_grupo") = "F-00:45 AM"
                                                drow("desc_grp_sal") = "Mixto"
                                            End If
                                        Case "E"

                                            If (_tExtAutorDbl >= 1 And _tExtAutorDbl <= 3) Then
                                                drow("cod_grupo") = "F-00:45 AM"
                                                drow("desc_grp_sal") = "Mixto"
                                            End If
                                            If (_tExtAutorDbl > 3) Then
                                                drow("cod_grupo") = "A-06:45 AM"
                                                drow("desc_grp_sal") = "1er Turno"
                                            End If
                                        Case "F"
                                            If (_tExtAutorDbl >= 5) Then
                                                drow("cod_grupo") = "A-06:45 AM"
                                                drow("desc_grp_sal") = "1er Turno"
                                            End If
                                        Case Else
                                            drow("cod_grupo") = "SIN RUTA"
                                            drow("desc_grp_sal") = "SIN RUTA"
                                    End Select
                                    drow("cod_grupo") = drow("cod_grupo").ToString.Trim
                                    If (drow("cod_grupo") <> "") Then 'Agregar solo si tiene un grupo asignado
                                        cod_grp_Sal = drow("cod_grupo")
                                        dtDatos.Rows.Add(drow)
                                    End If

                                End If

                            Else ' Lo deja en su rol normal ya que no tiene tiempo extra autorizado
                                drow("te_aut") = 0 ' Para indicar en el reporte que NO tiene TE_Aut
                                drow_rol = dtCalendario.Select(" ano = '" & drow_periodos("ano") & "' and periodo = '" & drow_periodos("periodo") & "' and cod_hora = '" & row("cod_hora") & "' and cod_dia_sal = '" & dia_sem & "'")(0)

                                If Not IsNothing(drow_rol) Then
                                    drow("cod_grupo") = drow_rol("cod_grupo_sal").ToString.Trim 'Metemos al registro cod_grup lo encontrado en el Row anterior que es drow_rol
                                    drow("desc_grp_sal") = drow_rol("desc_grp_sal")

                                    'Si tiene Grupo de salida insertar el registro                                  
                                    If (drow("cod_grupo") <> "") Then
                                        cod_grp_Sal = drow("cod_grupo")
                                        salida = True
                                    End If
                                End If
                            End If

                            '--Si hay grupo de ent o salida que lo agregue
                            If entrada Or salida Then
                                dtDatos.Rows.Add(drow)
                            End If

                        Catch ex As Exception

                        End Try

                    End If

                Next
                _fini = _fini.AddDays(1)

            End While
            ActivoTrabajando = False
            frmTrabajando.Close()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            ActivoTrabajando = False
            frmTrabajando.Close()
        End Try
    End Sub

    Public Sub ReporteDeRutas(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable, ByRef tipo As Integer)
        Try
            'Esta clase está en GENERAL\DATOS REPORTEADOR\RecursosHumanos.vb
            'Ir agregando los nombres de las columnas al dtDatos  que es un DATATABLE
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("COD_COMP")
            dtDatos.Columns.Add("reloj_alt")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("cod_clerk")
            dtDatos.Columns.Add("nombre_clerk")
            dtDatos.Columns.Add("cod_hora")
            dtDatos.Columns.Add("fecha")
            dtDatos.Columns.Add("cod_ruta")
            dtDatos.Columns.Add("cod_grupo")
            'AOS 04/09/2018 - Cliente solicita columna que traiga el nombre del área de cada empleado
            dtDatos.Columns.Add("cod_area")
            dtDatos.Columns.Add("nombre_area")
            dtDatos.Columns.Add("te_aut") 'Indicador para saber si tiene tiempo extra
            dtDatos.Columns.Add("desc_grp_ent")
            dtDatos.Columns.Add("desc_grp_sal")
            dtDatos.Columns.Add("nombre_puesto")

            Dim _teaut As Integer = 0

            ' Definir rangos de fecha inicio y fin
            Dim _fini As Date = Now.Date
            Dim _ffin As Date = _fini.AddDays(7).Date

            Dim frm As New frmRangoFechas
            If frm.ShowDialog = DialogResult.OK Then
                _fini = FechaInicial
                _ffin = FechaFinal
            End If

            'Mostrar avance de resultados
            frmTrabajando.Show()
            Application.DoEvents()

            ' Definir la var _campo_ruta que va a ser el tipo a filtrar, si sería el concepto de "RUTA" O "PARADA"
            Dim _campo_ruta As String = "prueba_r"

            Dim dtParametros As DataTable = sqlExecute("select auxiliar_ruta from parametros where auxiliar_ruta is not null")
            If dtParametros.Rows.Count > 0 Then
                _campo_ruta = RTrim(dtParametros.Rows(0)("auxiliar_ruta"))
            End If

            Dim dtPeriodos As DataTable = sqlExecute("select * from periodos where isnull(periodo_especial, 0) = 0", "ta")
            Dim dtCalendario As DataTable = sqlExecute(" select " & _
" rol_horarios.ano, " & _
" rol_horarios.periodo, " & _
" dias.cod_hora, " & _
" dias.semana, " & _
" dias.COD_DIA, " & _
" dias.COD_DIA_SAL, " & _
" dias.entra, " & _
" dias.sale, " & _
" dias.cod_grupo, " & _
" dias.cod_grupo_sal, " & _
" dias.desc_grp_ent, " & _
" dias.desc_grp_sal " & _
" from dias " & _
" left join rol_horarios on rol_horarios.cod_hora = dias.cod_hora and rol_horarios.semana = dias.semana " & _
" where rol_horarios.ano is not null  and dias.descanso = 0 ")

            Dim dtExtrasAutor As DataTable = sqlExecute("SELECT RELOJ,FECHA,EXTRAS_REALES,EXTRAS_AUTORIZADAS,ANALIZADO FROM extras_autorizadas where  fecha BETWEEN '" & FechaSQL(_fini) & "' and '" & FechaSQL(_fini) & "' order by fecha asc", "TA")

            'Obtener todas las rutas de todos los empleados asignado
            Dim dtRutas As DataTable = sqlExecute("select * from detalle_auxiliares where campo = '" & _campo_ruta & "' and rtrim(isnull(contenido, '')) <> ''")

            'Recorrer en ciclo mientras la fecha inicial no sea mayor a la fecha final
            While _fini <= _ffin

                'Definir en un DATAROW el periodo que cae en esa fecha específicamente que estamos analizando en este momento
                Dim drow_periodos As DataRow = Nothing
                Try
                    drow_periodos = dtPeriodos.Select("fecha_ini <= '" & FechaSQL(_fini) & "' and fecha_fin >= '" & FechaSQL(_fini) & "'")(0)
                Catch ex As Exception

                End Try

                'Si no encontró un periodo, si es nulo
                If IsNothing(drow_periodos) Then
                    Err.Raise(-1, "", "No existe periodo para la fecha seleccionada")
                End If

                'Definir en la var dia_sem el numero de del día de la semana_
                Dim dia_sem As Integer = _fini.DayOfWeek

                'Analizar para cada registro que trae la tabla personal, ya que dtInformacion trae todo el contenido de la tabla PERSONALVW
                For Each row As DataRow In dtInformacion.Rows

                    'Mostrar avance para cada registro
                    frmTrabajando.lblAvance.Text = FechaSQL(_fini) & "/" & row("reloj")
                    Application.DoEvents()

                    'Ir agregando a dtDatos cada nuevo registro, se hace esto para agregar al nuevo dtDatos solo los registros que realmente nos interesa
                    Dim drow As DataRow = dtDatos.NewRow
                    drow("reloj") = row("reloj")
                    drow("cod_comp") = row("cod_comp")
                    drow("nombres") = row("nombres") ' Columna para los nombres
                    drow("cod_hora") = row("cod_hora") 'Columna para el cod_hora
                    drow("cod_clerk") = row("cod_clerk") 'Columna para el cod_clrerk
                    drow("nombre_clerk") = row("nombre_clerk") 'Columna para el nombre_clerk
                    drow("cod_area") = row("cod_area") 'Columna para el Código del Area
                    drow("nombre_area") = row("nombre_area") 'Columna para la descrip del Area
                    drow("nombre_puesto") = row("nombre_puesto")

                    If drow("cod_comp").ToString.Trim = "002" Then
                        drow("reloj_alt") = row("reloj_alt")
                    Else
                        drow("reloj_alt") = ""
                    End If

                    'La columna fecha la insertamos con el día que vaya en ese momento
                    drow("fecha") = FechaSQL(_fini)

                    Dim drow_ruta As DataRow = Nothing
                    Try
                        drow_ruta = dtRutas.Select("reloj = '" & row("reloj") & "'")(0) 'Aqui capturamos en este ROW todo ese registro encontrado
                    Catch ex As Exception

                    End Try

                    'Validar si tiene

                    'Si no es nulo, es decir, si se encontró ese numero de reloj, entonces mete al campo cod_ruta lo que traiga la columna contenido
                    If Not IsNothing(drow_ruta) Then

                        drow("cod_ruta") = drow_ruta("contenido") 'Inserta al cod_ruta lo encontrado o lo que traes  en el DATAROW drow_ruta

                        'Lo mismo hacemos para obtener el cod_grupo, pero esto es mas complejo
                        Dim drow_rol As DataRow = Nothing 'Generamos una var drow_rol que va a ser un DR que va a contener un solo registro

                        Try
                            Select Case tipo
                                Case 1 'Entrada
                                    drow_rol = dtCalendario.Select(" ano = '" & drow_periodos("ano") & "' and periodo = '" & drow_periodos("periodo") & "' and cod_hora = '" & row("cod_hora") & "' and cod_dia = '" & dia_sem & "'")(0)

                                    If Not IsNothing(drow_rol) Then
                                        drow("cod_grupo") = drow_rol("cod_grupo").ToString.Trim 'Metemos al registro cod_grup lo encontrado en el Row anterior que es drow_rol
                                        drow("desc_grp_ent") = drow_rol("desc_grp_ent")
                                        'Si tiene Grupo de Entrada insertar el registro
                                        If (drow_rol("cod_grupo") <> "") Then
                                            dtDatos.Rows.Add(drow) 'Agregamos todos los registros finalmente y con este terminamos este registro, y así nos vamos con cada registro hasta que termine de analizar todos los registros que trae dtInformacion que es la tabla de PERSONAL
                                        End If
                                    End If

                                Case 2  'SALIDA

                                    '************Validar si ese empleado tiene T.Extra Autorizado y si tiene y cumple el formato mandarla a una var double para sumar
                                    Dim _tExtAutor As String = "" 'Var que va a contener el Tiempo Extra Autorizado tipo string
                                    Dim _tExtAutorDbl As Double = 0.0 'Ya va a estar convertida en tipo Double para sumar

                                    Dim drow_teAutor As DataRow = Nothing
                                    Try
                                        drow_teAutor = dtExtrasAutor.Select("FECHA = '" & FechaSQL(_fini) & "' AND RELOJ='" & row("reloj") & "'")(0)
                                    Catch ex As Exception

                                    End Try

                                    If Not IsNothing(drow_teAutor) Then 'Si encontró un registro de tiempo extra autorizado
                                        _tExtAutor = drow_teAutor("extras_autorizadas") 'Capturamos el valor que trae ese campo y lo validamos si cumple con el formato

                                        If ((_tExtAutor <> "" Or _tExtAutor <> "TODO" Or _tExtAutor <> "NULL") And (_tExtAutor.Substring(2, 1) = ":")) Then 'Si viene 02:15 x ejemplo
                                            _tExtAutor = _tExtAutor.Substring(0, 2) & "." & _tExtAutor.Substring(3, 2) 'Lo mandamos 02.15 x ejemplo
                                            _tExtAutorDbl = Double.Parse(_tExtAutor) 'Lista para sumar, se convierte a 2.15

                                        End If
                                    End If

                                    If _tExtAutorDbl > 0 Then ' Si hay tiempo extra autorizado para ese empleado
                                        drow("te_aut") = 1  ' Para indicar en el reporte que SI tiene TE_Aut
                                        drow_rol = dtCalendario.Select(" ano = '" & drow_periodos("ano") & "' and periodo = '" & drow_periodos("periodo") & "' and cod_hora = '" & row("cod_hora") & "' and cod_dia_sal = '" & dia_sem & "'")(0)

                                        If Not IsNothing(drow_rol) Then 'Encontrando el Rol
                                            Dim GrupoSal As String = ""
                                            GrupoSal = drow_rol("cod_grupo_sal").ToString.Trim
                                            GrupoSal = GrupoSal.Substring(0, 1).ToUpper

                                            Select Case GrupoSal
                                                Case "A"
                                                    If (_tExtAutorDbl >= 3 And _tExtAutorDbl <= 10) Then
                                                        drow("cod_grupo") = "B-02:45 PM"
                                                        drow("desc_grp_sal") = "2do Turno"
                                                    End If
                                                Case "B"
                                                    If (_tExtAutorDbl >= 0.3 And _tExtAutorDbl <= 1.5) Then
                                                        drow("cod_grupo") = "C-04:20 PM"
                                                        drow("desc_grp_sal") = "Mixto"
                                                    End If
                                                    If (_tExtAutorDbl >= 2 And _tExtAutorDbl <= 2.5) Then
                                                        drow("cod_grupo") = "D-05:00 PM"
                                                        drow("desc_grp_sal") = "Salary"
                                                    End If
                                                    If (_tExtAutorDbl >= 7 And _tExtAutorDbl <= 8.5) Then
                                                        drow("cod_grupo") = "E-10:06 PM"
                                                        drow("desc_grp_sal") = "3er Turno"
                                                    End If
                                                    If (_tExtAutorDbl > 8.5) Then
                                                        drow("cod_grupo") = "F-00:45 AM"
                                                        drow("desc_grp_sal") = "Mixto"
                                                    End If
                                                Case "C"
                                                    If (_tExtAutorDbl >= 0.5 And _tExtAutorDbl <= 1.5) Then
                                                        drow("cod_grupo") = "D-05:00 PM"
                                                        drow("desc_grp_sal") = "Salary"
                                                    End If
                                                    If (_tExtAutorDbl > 5.9 And _tExtAutorDbl <= 8) Then
                                                        drow("cod_grupo") = "E-10:06 PM"
                                                        drow("desc_grp_sal") = "3er Turno"
                                                    End If
                                                    If (_tExtAutorDbl > 8) Then
                                                        drow("cod_grupo") = "F-00:45 AM"
                                                        drow("desc_grp_sal") = "Mixto"
                                                    End If
                                                Case "D"

                                                    If (_tExtAutorDbl >= 3 And _tExtAutorDbl <= 6.5) Then
                                                        drow("cod_grupo") = "E-10:06 PM"
                                                        drow("desc_grp_sal") = "3er Turno"
                                                    End If
                                                    If (_tExtAutorDbl > 6.5) Then
                                                        drow("cod_grupo") = "F-00:45 AM"
                                                        drow("desc_grp_sal") = "Mixto"
                                                    End If
                                                Case "E"

                                                    If (_tExtAutorDbl >= 1 And _tExtAutorDbl <= 3) Then
                                                        drow("cod_grupo") = "F-00:45 AM"
                                                        drow("desc_grp_sal") = "Mixto"
                                                    End If
                                                    If (_tExtAutorDbl > 3) Then
                                                        drow("cod_grupo") = "A-06:45 AM"
                                                        drow("desc_grp_sal") = "1er Turno"
                                                    End If
                                                Case "F"
                                                    If (_tExtAutorDbl >= 5) Then
                                                        drow("cod_grupo") = "A-06:45 AM"
                                                        drow("desc_grp_sal") = "1er Turno"
                                                    End If
                                                Case Else
                                                    drow("cod_grupo") = ""
                                                    drow("desc_grp_sal") = ""
                                            End Select
                                            drow("cod_grupo") = drow("cod_grupo").ToString.Trim
                                            If (drow("cod_grupo") <> "") Then 'Agregar solo si tiene un grupo asignado
                                                dtDatos.Rows.Add(drow)
                                            End If

                                        End If
                                    Else ' Lo deja en su rol normal ya que no tiene tiempo extra autorizado
                                        drow("te_aut") = 0 ' Para indicar en el reporte que NO tiene TE_Aut
                                        drow_rol = dtCalendario.Select(" ano = '" & drow_periodos("ano") & "' and periodo = '" & drow_periodos("periodo") & "' and cod_hora = '" & row("cod_hora") & "' and cod_dia_sal = '" & dia_sem & "'")(0)

                                        If Not IsNothing(drow_rol) Then
                                            drow("cod_grupo") = drow_rol("cod_grupo_sal").ToString.Trim 'Metemos al registro cod_grup lo encontrado en el Row anterior que es drow_rol
                                            drow("desc_grp_sal") = drow_rol("desc_grp_sal")
                                            'Si tiene Grupo de salida insertar el registro                                  
                                            If (drow("cod_grupo") <> "") Then
                                                dtDatos.Rows.Add(drow) 'Agregamos todos los registros finalmente y con este terminamos este registro, y así nos vamos con cada registro hasta que termine de analizar todos los registros que trae dtInformacion que es la tabla de PERSONAL
                                            End If
                                        End If
                                    End If

                            End Select

                        Catch ex As Exception

                        End Try
                    End If

                Next
                _fini = _fini.AddDays(1)
            End While

            ActivoTrabajando = False
            frmTrabajando.Close()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)

            ActivoTrabajando = False
            frmTrabajando.Close()
        End Try
    End Sub


    'Inicio procesos Kardex Anual Global por empleados, Enrique Meza
    Public Sub KardexAnualGlobal(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Dim dtPersonal As New DataTable
        Dim dtPersonalVW As New DataTable
        Dim DatosAUS As New DataTable
        Dim FAlta As Date
        Dim FBaja As Date
        Dim _CountReg As Integer = 1
        Dim _CountReg1 As Integer = 1
        Dim _x As Integer = 1
        Dim _y As Integer = 1

        'La forma regresa un DataRow llamado drAños, que contiene la información sobre el grupo seleccionado
        Dim fr As New frmAño
        fr.ShowDialog()

        If drAño = Nothing Then
            Exit Sub
        End If

        Try

            Dim Ano As Integer = drAño
            Dim Fecha As New Date(Ano, 1, 1)
            Dim FinAno As New Date(Ano, 12, 31)

            dtDatos = New DataTable
            dtDatos.Columns.Add("numMes", GetType(System.Int16))
            dtDatos.Columns.Add("mes")
            dtDatos.Columns.Add("dia", GetType(System.Int16))
            dtDatos.Columns.Add("detalle")
            dtDatos.Columns.Add("color_back", GetType(System.Double))
            dtDatos.Columns.Add("color_letra", GetType(System.Double))
            dtDatos.Columns.Add("reloj", GetType(System.String))
            dtDatos.Columns.Add("año")
            dtDatos.Columns.Add("dia2", GetType(System.String))

            dtPersonalVW = New DataTable
            dtPersonalVW.Columns.Add("reloj", GetType(System.String))
            dtPersonalVW.Columns.Add("nombres", GetType(System.String))
            dtPersonalVW.Columns.Add("cod_depto", GetType(System.String))
            dtPersonalVW.Columns.Add("cod_puesto", GetType(System.String))
            dtPersonalVW.Columns.Add("cod_turno", GetType(System.String))
            dtPersonalVW.Columns.Add("cod_tipo", GetType(System.String))
            dtPersonalVW.Columns.Add("cod_clase", GetType(System.String))
            dtPersonalVW.Columns.Add("cod_super", GetType(System.String))
            dtPersonalVW.Columns.Add("alta", GetType(System.String))
            dtPersonalVW.Columns.Add("baja", GetType(System.String))
            dtPersonalVW.Columns.Add("foto", GetType(System.String))
            dtPersonalVW.Columns.Add("nombre_depto", GetType(System.String))
            dtPersonalVW.Columns.Add("nombre_super", GetType(System.String))
            dtPersonalVW.Columns.Add("nombre_puesto", GetType(System.String))
            dtPersonalVW.Columns.Add("cod_planta", GetType(System.String))
            dtPersonalVW.Columns.Add("cod_hora", GetType(System.String))

            DatosAUS = New DataTable
            DatosAUS.Columns.Add("reloj", GetType(System.String))
            DatosAUS.Columns.Add("AUS", GetType(System.String))
            DatosAUS.Columns.Add("Cuantos", GetType(System.Int16))

            For Each dRow As DataRow In dtInformacion.Rows
                Dim Reloj As String = dRow("Reloj")
                Dim FHAAlta As String = IIf(IsDBNull(dRow("alta")), "-", dRow("alta"))
                Dim FHABaja As String = IIf(IsDBNull(dRow("baja")), "-", dRow("baja"))

                dtPersonalVW.Rows.Add({dRow("reloj"), RTrim(dRow("nombres")), dRow("cod_depto"), dRow("cod_puesto"), _
                                       dRow("cod_turno"), dRow("cod_tipo"), dRow("cod_clase"), dRow("cod_super"), FHAAlta, FHABaja, dRow("foto"), RTrim(dRow("nombre_depto")), _
                                       RTrim(dRow("nombre_super")), RTrim(dRow("nombre_puesto")), dRow("cod_planta"), dRow("cod_hora")})

                Dim dtPerAus As DataTable = sqlExecute("SELECT ausentismo.Reloj, RTrim(tipo_ausentismo.TIPO_AUS) + ': ' + RTrim(tipo_ausentismo.NOMBRE) AS Aus, COUNT(ausentismo.TIPO_AUS) AS Cuantos " & _
                                                       "FROM ausentismo RIGHT OUTER JOIN tipo_ausentismo ON ausentismo.TIPO_AUS = tipo_ausentismo.TIPO_AUS " & _
                                                       "WHERE (ausentismo.RELOJ = '" & Reloj & "') AND (YEAR(ausentismo.FECHA) = '" & Ano & "') " & _
                                                       "GROUP BY tipo_ausentismo.TIPO_AUS, tipo_ausentismo.NOMBRE, ausentismo.Reloj " & _
                                                       "ORDER BY ausentismo.RELOJ, tipo_ausentismo.TIPO_AUS", "TA")
                For Each drRow As DataRow In dtPerAus.Rows
                    DatosAUS.Rows.Add({drRow("Reloj"), drRow("Aus"), drRow("Cuantos")})
                Next
            Next

            _CountReg1 = dtInformacion.Rows.Count
            frmTrabajando.Show()
            For Each r As DataRow In dtInformacion.Rows
                frmTrabajando.lblAvance.Text = "Reloj: " & r("Reloj")
                frmTrabajando.Text = "Conf. Kardex Anual: " & CDbl(_x / _CountReg1).ToString("0%") & " Terminado"
                Application.DoEvents()
                Fecha = New Date(Ano, 1, 1)

                Dim Rlj As String = r("Reloj")
                dtPersonal = sqlExecute("SELECT alta,baja from personalvw WHERE reloj = '" & Rlj & "'")
                FAlta = dtPersonal.Rows(0).Item("alta")
                FBaja = IIf(IsDBNull(dtPersonal.Rows(0).Item("baja")), DateSerial(2100, 1, 1), dtPersonal.Rows(0).Item("baja"))

                Do Until Fecha = FinAno
                    Dim StrDia2 As String = Fecha.ToString("ddd")
                    If (Fecha < FAlta Or Fecha > FBaja) And Fecha < Now Then
                        dtDatos.Rows.Add({Fecha.Month, MesLetra(Fecha), Fecha.Day, "---", -1, -16777216, Rlj, Ano, StrDia2})
                    Else
                        'dtDatos.Rows.Add({Month(Fecha), MesLetra(Fecha), Fecha.Day, ""})
                        dtTemporal = sqlExecute("select ausentismo.tipo_aus,color_letra,color_back FROM ausentismo " & _
                                                "LEFT JOIN tipo_ausentismo on ausentismo.tipo_aus=tipo_ausentismo.tipo_aus " & _
                                                "WHERE ausentismo.reloj= '" & Rlj & "' AND fecha = '" & FechaSQL(Fecha) & "'", "TA")
                        If dtTemporal.Rows.Count = 0 Then
                            dtDatos.Rows.Add({Fecha.Month, MesLetra(Fecha), Fecha.Day, "", -1, -16777216, Rlj, Ano, StrDia2})
                        Else
                            dtDatos.Rows.Add({Fecha.Month, MesLetra(Fecha), Fecha.Day, _
                                          IIf(IsDBNull(dtTemporal.Rows(0).Item("tipo_aus")), "AUS", dtTemporal.Rows(0).Item("tipo_aus")), _
                                          IIf(IsDBNull(dtTemporal.Rows(0).Item("color_back")), -1, dtTemporal.Rows(0).Item("color_back")), _
                                          IIf(IsDBNull(dtTemporal.Rows(0).Item("color_letra")), -16777216, dtTemporal.Rows(0).Item("color_letra")), Rlj, Ano, StrDia2})
                        End If
                    End If
                    Fecha = DateAdd(DateInterval.Day, 1, Fecha)
                    Application.DoEvents()
                Loop
                _x += 1
            Next

            Debug.Print("Terminado")
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

    End Sub
    'Inicio procesos para el SUA, AOS
    Public Sub AltasSUA(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim Columnas(15) As DataColumn
        Dim ArchivoFoto As String = ""
        Dim PathFoto As String = ""
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 0
        Dim GuardaArchivo As Boolean = True
        Dim sfd As New SaveFileDialog
        Dim AltasSUA As String = ""


        Try
            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("rfc", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("curp", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("nombres", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("tipo_trab", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("jornada", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("alta", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("integrado", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("puesto", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("Nombre", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("Reloj", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(14) = New DataColumn("fecha_ini", System.Type.GetType("System.String"))
            Columnas(15) = New DataColumn("fecha_fin", System.Type.GetType("System.String"))


            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            'dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            Dim frm_cia As New frmSeleccionarCia
            frm_cia.ShowDialog()

            '--- Rango de fechas para mandar las altas
            Dim frm_fechas As New frmRangoFechas
            frm_fechas.Text = "Filtrar fecha para altas al sua"
            frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 12)
            frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>FECHAS DE ALTAS</b></font>
            frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
            frm_fechas.frmRangoFechas_fecha_fin = Now
            frm_fechas.ShowDialog()


            Dim QAltas As String = "select * from personalvw where  cod_comp='" & dtInformacion.Rows(0).Item("cod_comp") & "' and alta between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'"
            Dim dtAltas As DataTable = sqlExecute(QAltas, "PERSONAL")
            Dim QBitacora As String = "select b.*,Convert(date,b.fecha) as 'fecha_aplica' from bitacora_personal b where campo='integrado'  and CONVERT(date,fecha) between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' " & _
                "and reloj in(select reloj from personalvw where  cod_comp='" & dtInformacion.Rows(0).Item("cod_comp") & "' and alta between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "') order by b.fecha asc"
            Dim dtBitacora As DataTable = sqlExecute(QBitacora, "PERSONAL")

            If (Not dtAltas.Columns.Contains("Error") And dtAltas.Rows.Count > 0) Then

                dtTemp = sqlExecute("SELECT rfc,infonavit,reg_pat,nombre,guia,minimo*25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

                sfd.DefaultExt = ".txt"
                sfd.Title = "Crear Disco de Altas al SUA"
                sfd.FileName = Compania & "_Disco_Altas_SUA_" & FechaSQL(Date.Now) & ".txt"
                sfd.OverwritePrompt = True

                If sfd.ShowDialog() = DialogResult.OK Then
                    AltasSUA = sfd.FileName
                End If

                Dim objFS As New FileStream(AltasSUA, FileMode.Create, FileAccess.Write)
                Dim objSW As New StreamWriter(objFS)

                GuardaArchivo = AltasSUA <> ""

                For Each dRow As DataRowView In dtAltas.DefaultView
                    Try
                        Dim integ As String = "0"
                        Dim integTemp As Double = 0


                        'AO: 2023-03-29 Obtener el integrado de bitacora en base a la fecha de alta
                        Dim _AltaEmpl As String = "", reloj As String = "", valorNuevo As String = ""
                        Try : reloj = dRow("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                        Try : _AltaEmpl = FechaSQL(dRow("Alta")) : Catch ex As Exception : _AltaEmpl = "" : End Try
                        If (_AltaEmpl <> "") Then
                            Dim item = (From a In dtBitacora.Rows Where a("reloj").ToString.Trim = reloj And a("fecha_aplica") = _AltaEmpl).ToList()
                            If item.Count > 0 Then
                                Try : valorNuevo = Double.Parse(item.First()("ValorNuevo")) : Catch ex As Exception : valorNuevo = "" : End Try
                                If (valorNuevo <> "") Then integTemp = valorNuevo
                            Else ' Si no lo encontró que tome el primero que encuentre
                                Dim item2 = (From b In dtBitacora.Rows Where b("reloj").ToString.Trim = reloj).ToList()
                                If (item2.Count > 0) Then
                                    Try : valorNuevo = Double.Parse(item2.First()("ValorNuevo")) : Catch ex As Exception : valorNuevo = "" : End Try
                                    If (valorNuevo <> "") Then integTemp = valorNuevo
                                End If
                            End If

                        End If

                        If (integTemp = 0) Then ' Si no se encontró en bitacora, que lo tome de personal                   
                            If Not IsDBNull(dRow("integrado")) Then
                                If dRow("integrado") > dtTemp.Rows(0).Item("tope") Then
                                    integTemp = dtTemp.Rows(0).Item("tope")
                                Else
                                    integTemp = dRow("integrado")
                                End If
                            End If
                        End If




                        integ = Format(integTemp, "f")
                        Dim NomPto As String = StrConv(dRow("nombre_puesto"), VbStrConv.Uppercase)
                        NomPto = Left(NomPto, 17)
                        dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), dRow("rfc"), dRow("curp"), dRow("nombres").ToString.Replace(",", "$"), "1", "0", FechaDMY(IIf(IsDBNull(dRow("alta")), Nothing, dRow("alta"))), integ, NomPto, dRow("nombres"), dRow("Reloj"), "01", FechaSQL(FechaInicial), FechaSQL(FechaFinal))
                        x = dtDatos.Rows.Count - 1

                        If GuardaArchivo Then
                            objSW.WriteLine(dtDatos.Rows(x).Item("reg_pat").ToString.Trim.PadRight(11) & _
                                            dtDatos.Rows(x).Item("imss").ToString.Trim.PadRight(10) & _
                                            dtDatos.Rows(x).Item("dig_ver").ToString.Trim.PadRight(1) & _
                                            dtDatos.Rows(x).Item("rfc").ToString.Trim.PadRight(13) & _
                                            dtDatos.Rows(x).Item("curp").ToString.Trim.PadRight(18) & _
                                            dtDatos.Rows(x).Item("nombres").ToString.Trim.PadRight(50).Replace("Ñ", "N") & _
                                            dtDatos.Rows(x).Item("tipo_trab").ToString.Trim.PadRight(1) & _
                                            dtDatos.Rows(x).Item("jornada").ToString.Trim.PadRight(1) & _
                                            dtDatos.Rows(x).Item("alta").ToString.Trim.PadRight(8) & _
                                            dtDatos.Rows(x).Item("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0") & _
                                            dtDatos.Rows(x).Item("puesto").ToString.Trim.PadRight(44))
                        End If
                    Catch ex As Exception
                        'MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
                    End Try
                Next

                objSW.Close()

                Console.WriteLine("")
                Console.WriteLine("File creation complete. Press <Enter> to close this window.")
                MessageBox.Show("Archivo fue genereado exitosamente en la ruta indicada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("No existen altas en el rango de fechas seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            'If dtInformacion.Rows.Count > 0 Then
            '    ' Dim frm_cia As New frmSeleccionarCia
            '    frm_cia.ShowDialog()


            '    dtTemp = sqlExecute("SELECT rfc,infonavit,reg_pat,nombre,guia,minimo*25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
            '    Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

            '    sfd.DefaultExt = ".txt"
            '    sfd.Title = "Crear Disco de Altas al SUA"
            '    sfd.FileName = Compania & "_Disco_Altas_SUA_" & FechaSQL(Date.Now) & ".txt"
            '    sfd.OverwritePrompt = True

            '    If sfd.ShowDialog() = DialogResult.OK Then
            '        AltasSUA = sfd.FileName
            '    End If

            '    Dim objFS As New FileStream(AltasSUA, FileMode.Create, FileAccess.Write)
            '    Dim objSW As New StreamWriter(objFS)

            '    GuardaArchivo = AltasSUA <> ""

            '    For Each dRow As DataRowView In dtInformacion.DefaultView
            '        Try
            '            Dim integ As String = "0"
            '            Dim integTemp As Double = 0

            '            If Not IsDBNull(dRow("integrado")) Then
            '                If dRow("integrado") > dtTemp.Rows(0).Item("tope") Then
            '                    integTemp = dtTemp.Rows(0).Item("tope")
            '                Else
            '                    integTemp = dRow("integrado")
            '                End If
            '                'dRow.Item("integrado") = Double.Parse(Format(dRow.Item("integrado"), "f"))
            '            End If
            '            integ = Format(integTemp, "f")
            '            Dim NomPto As String = StrConv(dRow("nombre_puesto"), VbStrConv.Uppercase)
            '            NomPto = Left(NomPto, 17)
            '            dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), dRow("rfc"), dRow("curp"), dRow("nombres").ToString.Replace(",", "$"), "1", "0", FechaDMY(IIf(IsDBNull(dRow("alta")), Nothing, dRow("alta"))), integ, NomPto, dRow("nombres"), dRow("Reloj"), "01", FechaSQL(FechaInicial), FechaSQL(FechaFinal))
            '            x = dtDatos.Rows.Count - 1

            '            If GuardaArchivo Then
            '                objSW.WriteLine(dtDatos.Rows(x).Item("reg_pat").ToString.Trim.PadRight(11) & _
            '                                dtDatos.Rows(x).Item("imss").ToString.Trim.PadRight(10) & _
            '                                dtDatos.Rows(x).Item("dig_ver").ToString.Trim.PadRight(1) & _
            '                                dtDatos.Rows(x).Item("rfc").ToString.Trim.PadRight(13) & _
            '                                dtDatos.Rows(x).Item("curp").ToString.Trim.PadRight(18) & _
            '                                dtDatos.Rows(x).Item("nombres").ToString.Trim.PadRight(50).Replace("Ñ", "N") & _
            '                                dtDatos.Rows(x).Item("tipo_trab").ToString.Trim.PadRight(1) & _
            '                                dtDatos.Rows(x).Item("jornada").ToString.Trim.PadRight(1) & _
            '                                dtDatos.Rows(x).Item("alta").ToString.Trim.PadRight(8) & _
            '                                dtDatos.Rows(x).Item("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0") & _
            '                                dtDatos.Rows(x).Item("puesto").ToString.Trim.PadRight(44))
            '            End If
            '        Catch ex As Exception
            '            'MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
            '        End Try
            '    Next

            '    objSW.Close()

            '    Console.WriteLine("")
            '    Console.WriteLine("File creation complete. Press <Enter> to close this window.")
            'End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Debug.Print(ex.StackTrace)
        End Try

    End Sub

    'Original
    'Public Sub ModificacionesAusenSUA(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
    '    Dim Columnas(17) As DataColumn
    '    Dim x As Integer = 0
    '    Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
    '    Dim z As Integer = 1
    '    Dim ausentismo As String = ""
    '    Dim GuardaArchivo As Boolean = True
    '    Dim sfd As New SaveFileDialog
    '    Dim _x As Integer = 1

    '    Try
    '        dtDatos = New DataTable("Datos")
    '        Columnas(0) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
    '        Columnas(1) = New DataColumn("imss", System.Type.GetType("System.String"))
    '        Columnas(2) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
    '        Columnas(3) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
    '        Columnas(4) = New DataColumn("fecha_mov", System.Type.GetType("System.String"))
    '        Columnas(5) = New DataColumn("num_incap", System.Type.GetType("System.String"))
    '        Columnas(6) = New DataColumn("dias_incap_Ausen", System.Type.GetType("System.String"))
    '        Columnas(7) = New DataColumn("integrado", System.Type.GetType("System.String"))
    '        Columnas(8) = New DataColumn("Nombres", System.Type.GetType("System.String"))
    '        Columnas(9) = New DataColumn("Reloj", System.Type.GetType("System.String"))
    '        Columnas(10) = New DataColumn("curp", System.Type.GetType("System.String"))
    '        Columnas(11) = New DataColumn("cod_clase", System.Type.GetType("System.String"))
    '        Columnas(12) = New DataColumn("cod_hora", System.Type.GetType("System.String"))
    '        Columnas(13) = New DataColumn("tipo_aus_nombre", System.Type.GetType("System.String"))
    '        Columnas(14) = New DataColumn("tipo_aus", System.Type.GetType("System.String"))
    '        Columnas(15) = New DataColumn("tipo", System.Type.GetType("System.String"))
    '        Columnas(16) = New DataColumn("fecha_ini", System.Type.GetType("System.String"))
    '        Columnas(17) = New DataColumn("fecha_fin", System.Type.GetType("System.String"))

    '        For x = 0 To UBound(Columnas)
    '            dtDatos.Columns.Add(Columnas(x))
    '        Next
    '        'dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

    '        Dim frm_cia As New frmSeleccionarCia
    '        frm_cia.ShowDialog()

    '        Dim frm_fechas As New frmRangoFechas
    '        frm_fechas.Text = "Filtrar fecha para el Ausentismo"
    '        frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 12)
    '        frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>FECHAS PARA AUSENTISMO</b></font>
    '        frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
    '        frm_fechas.frmRangoFechas_fecha_fin = Now
    '        frm_fechas.ShowDialog()

    '        dtTemp = sqlExecute("SELECT rfc, infonavit, reg_pat, nombre, guia, minimo*25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
    '        Dim _tope As Double = dtTemp.Rows(0).Item("tope")

    '        sfd.DefaultExt = ".txt"
    '        sfd.Title = "Crear Disco Ausentismo al SUA"
    '        sfd.FileName = Compania & "_Disco_Ausentismo_SUA_" & FechaSQL(Date.Now) & ".txt"
    '        sfd.OverwritePrompt = True

    '        If sfd.ShowDialog() = DialogResult.OK Then
    '            ausentismo = sfd.FileName
    '        End If

    '        Dim objFS As New FileStream(ausentismo, FileMode.Create, FileAccess.Write)
    '        Dim objSW As New StreamWriter(objFS)

    '        frmTrabajando.Show()

    '        'Dim dtAusentismo As DataTable = sqlExecute("select reloj, ausentismo.tipo_aus, tipo_ausentismo.NOMBRE from ausentismo left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus where ausentismo.tipo_aus in (select tipo_aus from tipo_ausentismo where afecta_sua = 1 and tipo_naturaleza <> 'I' and not(Reloj like 'X1') and not(Reloj like 'X2')) and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and cod_comp = '" & Compania & "' ORDER BY RELOJ", "TA")
    '        Dim dtAusentismo As DataTable = sqlExecute("SELECT RELOJ, count(distinct(fecha)) as DIAS " & _
    '                                             "FROM ausentismo left join tipo_ausentismo ON tipo_ausentismo.TIPO_AUS = ausentismo.TIPO_AUS " & _
    '                                             "WHERE (ausentismo.FECHA BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "') AND " & _
    '                                             "(ausentismo.TIPO_AUS IN (SELECT TIPO_AUS FROM tipo_ausentismo AS tipo_ausentismo_1 " & _
    '                                             "WHERE (AFECTA_SUA = 1) AND (TIPO_NATURALEZA <> 'I') AND (NOT(RELOJ LIKE 'X1')) AND (NOT(dbo.ausentismo.RELOJ LIKE 'X2')))) " & _
    '                                             "GROUP BY RELOJ " & _
    '                                             "ORDER BY DIAS DESC", "TA")
    '        Try
    '            Dim _CountReg As Integer = dtAusentismo.Rows.Count
    '            For Each row As DataRow In dtAusentismo.Rows
    '                frmTrabajando.lblAvance.Text = "Reloj: " & row("Reloj")
    '                frmTrabajando.Text = "Generando archivo " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
    '                Application.DoEvents()

    '                Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj = '" & row("reloj") & "'")
    '                Dim dtDias As DataTable = sqlExecute("SELECT Top 7 RELOJ, FECHA, ausentismo.TIPO_AUS, tipo_ausentismo.NOMBRE " & _
    '                                                    "FROM ausentismo left join tipo_ausentismo ON tipo_ausentismo.TIPO_AUS = ausentismo.TIPO_AUS " & _
    '                                                    "WHERE (Reloj = '" & row("reloj") & "') AND (ausentismo.FECHA BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "') AND " & _
    '                                                    "(ausentismo.TIPO_AUS IN (SELECT TIPO_AUS FROM tipo_ausentismo AS tipo_ausentismo_1 " & _
    '                                                    "WHERE (AFECTA_SUA = 1) AND (TIPO_NATURALEZA <> 'I') AND (NOT(RELOJ LIKE 'X1')) AND (NOT(dbo.ausentismo.RELOJ LIKE 'X2')))) " & _
    '                                                    "ORDER BY Reloj, FECHA ASC", "TA")

    '                For Each dRow As DataRow In dtDias.Rows
    '                    dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dtPersona.Rows(0).Item("imss"), dtPersona.Rows(0).Item("dig_ver"), "11", FechaDMY(IIf(IsDBNull(dRow("fecha")), Nothing, dRow("fecha"))), "", "01",
    '                                         IIf(dtPersona.Rows(0).Item("integrado") > _tope, _tope.ToString("N2"), dtPersona.Rows(0).Item("integrado")), dtPersona.Rows(0).Item("nombres"), dtPersona.Rows(0).Item("Reloj"), dtPersona.Rows(0).Item("curp"), dtPersona.Rows(0).Item("cod_clase"),
    '                                         dtPersona.Rows(0).Item("cod_hora"), dRow("nombre"), dRow("tipo_aus"), "A", FechaSQL(FechaInicial), FechaSQL(FechaFinal))
    '                Next
    '                _x += 1
    '            Next
    '        Catch ex As Exception
    '            MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
    '        End Try
    '        Try
    '            For Each row As DataRow In dtDatos.Select("imss Is Not Null", "imss")
    '                objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
    '                                row("imss").ToString.Trim.PadRight(10) & _
    '                                row("dig_ver").ToString.Trim.PadRight(1) & _
    '                                row("tipo_mov").ToString.Trim.PadRight(2) & _
    '                                row("fecha_mov").ToString.Trim.PadRight(8) & _
    '                                row("num_incap").ToString.Trim.PadRight(8) & _
    '                                row("dias_incap_Ausen").ToString.Trim.PadRight(2).PadLeft(2, "0") & _
    '                                row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
    '            Next
    '        Catch ex As Exception
    '            MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
    '        End Try
    '        ' GuardaArchivo Then
    '        ' objSW.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
    '        ' End If
    '        objSW.Close()

    '        Console.WriteLine("")
    '        Console.WriteLine("File creation complete. Press <Enter> to close this window.")

    '        ActivoTrabajando = False
    '        frmTrabajando.Close()
    '        frmTrabajando.Dispose()

    '    Catch ex As Exception
    '        MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    'Modificacion, Luis Andrade
    Public Sub ModificacionesAusenSUA(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim Columnas(17) As DataColumn
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 1
        Dim ausentismo As String = ""
        Dim GuardaArchivo As Boolean = True
        Dim sfd As New SaveFileDialog
        Dim _x As Integer = 1
        Dim lclCompania As String = ""
        Try
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("fecha_mov", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("num_incap", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("dias_incap_Ausen", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("integrado", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("Nombres", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("Reloj", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("curp", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("cod_clase", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("cod_hora", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("tipo_aus_nombre", System.Type.GetType("System.String"))
            Columnas(14) = New DataColumn("tipo_aus", System.Type.GetType("System.String"))
            Columnas(15) = New DataColumn("tipo", System.Type.GetType("System.String"))
            Columnas(16) = New DataColumn("fecha_ini", System.Type.GetType("System.String"))
            Columnas(17) = New DataColumn("fecha_fin", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            'dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            Dim frm_cia As New frmSeleccionarCia
            frm_cia.ShowDialog()

            lclCompania = Compania.Trim

            Dim frm_fechas As New frmRangoFechas
            frm_fechas.Text = "Filtrar fecha para el Ausentismo"
            frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 12)
            frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>FECHAS PARA AUSENTISMO</b></font>
            frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
            frm_fechas.frmRangoFechas_fecha_fin = Now
            frm_fechas.ShowDialog()

            'Cambiar a UMA*25
            dtTemp = sqlExecute("SELECT rfc, infonavit, reg_pat, nombre, guia, minimo*25 AS tope FROM cias WHERE cod_comp = '" & lclCompania & "'")
            Dim _tope As Double = dtTemp.Rows(0).Item("tope")

            sfd.DefaultExt = ".txt"
            sfd.Title = "Crear Disco Ausentismo al SUA"
            sfd.FileName = Compania & "_Disco_Ausentismo_SUA_" & FechaSQL(Date.Now) & ".txt"
            sfd.OverwritePrompt = True

            If sfd.ShowDialog() = DialogResult.OK Then
                ausentismo = sfd.FileName
            End If

            Dim objFS As New FileStream(ausentismo, FileMode.Create, FileAccess.Write)
            Dim objSW As New StreamWriter(objFS)

            frmTrabajando.Show()

            'Dim dtAusentismo As DataTable = sqlExecute("select reloj, ausentismo.tipo_aus, tipo_ausentismo.NOMBRE from ausentismo left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus where ausentismo.tipo_aus in (select tipo_aus from tipo_ausentismo where afecta_sua = 1 and tipo_naturaleza <> 'I' and not(Reloj like 'X1') and not(Reloj like 'X2')) and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and cod_comp = '" & Compania & "' ORDER BY RELOJ", "TA")
            Dim dtAusentismo As DataTable = sqlExecute("SELECT RELOJ, count(distinct(fecha)) as DIAS " & _
                                                 "FROM ausentismo left join tipo_ausentismo ON tipo_ausentismo.TIPO_AUS = ausentismo.TIPO_AUS " & _
                                                 "WHERE (ausentismo.FECHA BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "') AND " & _
                                                 "(ausentismo.TIPO_AUS IN (SELECT TIPO_AUS FROM tipo_ausentismo AS tipo_ausentismo_1 " & _
                                                 "WHERE (AFECTA_SUA = 1) AND (TIPO_NATURALEZA <> 'I') AND (NOT(RELOJ LIKE 'X1')) AND (NOT(dbo.ausentismo.RELOJ LIKE 'X2')))) " & _
                                                 "GROUP BY RELOJ " & _
                                                 "ORDER BY DIAS DESC", "TA")
            Try
                Dim _CountReg As Integer = dtAusentismo.Rows.Count
                For Each row As DataRow In dtAusentismo.Rows
                    frmTrabajando.lblAvance.Text = "Reloj: " & row("Reloj")
                    frmTrabajando.Text = "Generando archivo " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
                    Application.DoEvents()

                    Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj = '" & row("reloj").ToString.Trim & "'")
                    Dim dtDias As DataTable = sqlExecute("SELECT Top 7 RELOJ, FECHA, ausentismo.TIPO_AUS, tipo_ausentismo.NOMBRE " & _
                                                        "FROM ausentismo left join tipo_ausentismo ON tipo_ausentismo.TIPO_AUS = ausentismo.TIPO_AUS " & _
                                                        "WHERE (Reloj = '" & row("reloj") & "') AND (ausentismo.FECHA BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "') AND " & _
                                                        "(ausentismo.TIPO_AUS IN (SELECT TIPO_AUS FROM tipo_ausentismo AS tipo_ausentismo_1 " & _
                                                        "WHERE (AFECTA_SUA = 1) AND (TIPO_NATURALEZA <> 'I') AND (NOT(RELOJ LIKE 'X1')) AND (NOT(dbo.ausentismo.RELOJ LIKE 'X2')))) " & _
                                                        "ORDER BY Reloj, FECHA ASC", "TA")

                    For Each dRow As DataRow In dtDias.Rows
                        dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dtPersona.Rows(0).Item("imss"), dtPersona.Rows(0).Item("dig_ver"), "11", FechaDMY(IIf(IsDBNull(dRow("fecha")), Nothing, dRow("fecha"))), "", "01",
                                             IIf(IIf(IsDBNull(dtPersona.Rows(0).Item("integrado")), 0, dtPersona.Rows(0).Item("integrado")) > _tope, _tope.ToString("N2"), IIf(IsDBNull(dtPersona.Rows(0).Item("integrado")), 0, dtPersona.Rows(0).Item("integrado"))), dtPersona.Rows(0).Item("nombres"), dtPersona.Rows(0).Item("Reloj"), dtPersona.Rows(0).Item("curp"), dtPersona.Rows(0).Item("cod_clase"),
                                             dtPersona.Rows(0).Item("cod_hora"), dRow("nombre"), dRow("tipo_aus"), "A", FechaSQL(FechaInicial), FechaSQL(FechaFinal))
                    Next
                    _x += 1
                Next
            Catch ex As Exception
                MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
            End Try
            Try
                For Each row As DataRow In dtDatos.Select("imss Is Not Null", "imss")
                    objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
                                    row("imss").ToString.Trim.PadRight(10) & _
                                    row("dig_ver").ToString.Trim.PadRight(1) & _
                                    row("tipo_mov").ToString.Trim.PadRight(2) & _
                                    row("fecha_mov").ToString.Trim.PadRight(8) & _
                                    row("num_incap").ToString.Trim.PadRight(8) & _
                                    row("dias_incap_Ausen").ToString.Trim.PadRight(2).PadLeft(2, "0") & _
                                    row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
                Next
            Catch ex As Exception
                MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
            End Try
            ' GuardaArchivo Then
            ' objSW.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
            ' End If
            objSW.Close()

            'Console.WriteLine("")
            'Console.WriteLine("File creation complete. Press <Enter> to close this window.")

            'ActivoTrabajando = False
            'frmTrabajando.Close()
            'frmTrabajando.Dispose()

        Catch ex As Exception
            MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
        End Try

        ActivoTrabajando = False
        frmTrabajando.Close()
        frmTrabajando.Dispose()

    End Sub

    Public drMes As Date
    Public drMes1 As Date
    Public drAño As Integer
    Public Sub BonusSalWProm(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim dtBonus As DataTable
        Dim _x As Integer = 1
        Try
            dtDatos.Columns.Add("MANAGER", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOMBRES", Type.GetType("System.String"))
            dtDatos.Columns.Add("AF", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("RELOJ", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOMBRE", Type.GetType("System.String"))
            dtDatos.Columns.Add("APATERNO", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOM_DIVISION", Type.GetType("System.String"))
            dtDatos.Columns.Add("RESU_DIVISION", Type.GetType("System.String"))
            dtDatos.Columns.Add("BONO_PORCEN1", Type.GetType("System.String"))
            dtDatos.Columns.Add("BONO_OBJETIVO", Type.GetType("System.String"))
            dtDatos.Columns.Add("BONO_PORCEN2", Type.GetType("System.String"))
            dtDatos.Columns.Add("BONO_DERECHO", Type.GetType("System.String"))
            dtDatos.Columns.Add("PTU_MONTO", Type.GetType("System.String"))
            dtDatos.Columns.Add("BONO_BRP", Type.GetType("System.String"))
            dtDatos.Columns.Add("TOTAL_BONOS", Type.GetType("System.String"))
            dtDatos.Columns.Add("FECHA_DOC", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("FECHA_DEPO", Type.GetType("System.DateTime"))

            'Dim fr As New frmSeleccionaPeriodo
            Dim fr As New frmMes
            fr.ShowDialog()
            'La forma regresa un DataRow llamado drMes, que contiene la información sobre el grupo seleccionado
            If drMes = Nothing Then
                Exit Sub
            End If
            ActivoTrabajando = True
            frmTrabajando.Show()
            Dim _CountReg1 As Integer = dtInformacion.Rows.Count
            Try
                For Each dRow As DataRow In dtInformacion.Rows

                    frmTrabajando.lblAvance.Text = dRow("reloj")
                    frmTrabajando.Text = "Cualculando... " & CDbl(_x / _CountReg1).ToString("0%") & " Terminado"
                    Application.DoEvents()

                    dtBonus = sqlExecute("SELECT [Personal Bonos AF PTU].MANAGER, RTrim(personal.NOMBRE) + ' ' + RTrim(personal.APATERNO) AS NOMBRES, [Personal Bonos AF PTU].AF, [Personal Bonos AF PTU].RELOJ, personal.NOMBRE, personal.APATERNO, [Personal Bonos AF PTU].NOM_DIVISION, [Personal Bonos AF PTU].RESU_DIVISION, " & _
                                         "[Personal Bonos AF PTU].BONO_PORCEN1, [Personal Bonos AF PTU].BONO_OBJETIVO, [Personal Bonos AF PTU].BONO_PORCEN2, [Personal Bonos AF PTU].BONO_DERECHO, [Personal Bonos AF PTU].PTU_MONTO, " & _
                                         "[Personal Bonos AF PTU].BONO_BRP, [Personal Bonos AF PTU].TOTAL_BONOS " & _
                                         "FROM [Personal Bonos AF PTU] LEFT OUTER JOIN personal ON [Personal Bonos AF PTU].RELOJ = personal.RELOJ " & _
                                         "WHERE [Personal Bonos AF PTU].RELOJ = '" & dRow("reloj") & "' and [Personal Bonos AF PTU].AF = '" & drAño & "'", "PERSONAL")
                    If dtBonus.Rows.Count > 0 Then
                        dtDatos.Rows.Add({dtBonus.Rows(0)("MANAGER"), _
                                          dtBonus.Rows(0)("NOMBRES"), _
                                          dtBonus.Rows(0)("AF"), _
                                          dtBonus.Rows(0)("RELOJ"), _
                                          RTrim(dtBonus.Rows(0)("NOMBRE")), _
                                          RTrim(dtBonus.Rows(0)("APATERNO")), _
                                          dtBonus.Rows(0)("NOM_DIVISION"), _
                                          dtBonus.Rows(0)("RESU_DIVISION"), _
                                          dtBonus.Rows(0)("BONO_PORCEN1"), _
                                          dtBonus.Rows(0)("BONO_OBJETIVO"), _
                                          dtBonus.Rows(0)("BONO_PORCEN2"), _
                                          dtBonus.Rows(0)("BONO_DERECHO"), _
                                          dtBonus.Rows(0)("PTU_MONTO"), _
                                          dtBonus.Rows(0)("BONO_BRP"), _
                                          dtBonus.Rows(0)("TOTAL_BONOS"), _
                                          drMes, _
                                          drMes1})
                    End If
                    _x += 1
                Next
                'dtDatos = dtBonus.Copy
            Catch ex As Exception
                ActivoTrabajando = False
                frmTrabajando.Close()
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
            End Try
            ActivoTrabajando = False
            frmTrabajando.Close()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub BonusHourlyPlan(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim dtBonus As DataTable
        Dim _x As Integer = 1
        Try

            dtDatos.Columns.Add("MANAGER", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOMBRES", Type.GetType("System.String"))
            dtDatos.Columns.Add("AF", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("RELOJ", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOMBRE", Type.GetType("System.String"))
            dtDatos.Columns.Add("APATERNO", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOM_DIVISION", Type.GetType("System.String"))
            dtDatos.Columns.Add("RESU_DIVISION", Type.GetType("System.String"))
            dtDatos.Columns.Add("BONO_PORCEN1", Type.GetType("System.String"))
            dtDatos.Columns.Add("BONO_OBJETIVO", Type.GetType("System.String"))
            dtDatos.Columns.Add("BONO_PORCEN2", Type.GetType("System.String"))
            dtDatos.Columns.Add("BONO_DERECHO", Type.GetType("System.String"))
            dtDatos.Columns.Add("PTU_MONTO", Type.GetType("System.String"))
            dtDatos.Columns.Add("BONO_BRP", Type.GetType("System.String"))
            dtDatos.Columns.Add("TOTAL_BONOS", Type.GetType("System.String"))
            dtDatos.Columns.Add("FECHA_DOC", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("FECHA_DEPO", Type.GetType("System.DateTime"))

            'Dim fr As New frmSeleccionaPeriodo
            Dim fr As New frmMes
            fr.ShowDialog()
            'La forma regresa un DataRow llamado drMes, que contiene la información sobre el grupo seleccionado
            If drMes = Nothing Then
                Exit Sub
            End If
            Try
                dtBonus = sqlExecute("SELECT TOP 1 [Personal Bonos AF PTU].MANAGER, RTrim(personal.NOMBRE) + ' ' + RTrim(personal.APATERNO) AS NOMBRES, [Personal Bonos AF PTU].AF, [Personal Bonos AF PTU].RELOJ, personal.NOMBRE, personal.APATERNO, [Personal Bonos AF PTU].NOM_DIVISION, [Personal Bonos AF PTU].RESU_DIVISION, " & _
                                     "[Personal Bonos AF PTU].BONO_PORCEN1, [Personal Bonos AF PTU].BONO_OBJETIVO, [Personal Bonos AF PTU].BONO_PORCEN2, [Personal Bonos AF PTU].BONO_DERECHO, [Personal Bonos AF PTU].PTU_MONTO, " & _
                                     "[Personal Bonos AF PTU].BONO_BRP, [Personal Bonos AF PTU].TOTAL_BONOS " & _
                                     "FROM [Personal Bonos AF PTU] LEFT OUTER JOIN personal ON [Personal Bonos AF PTU].RELOJ = personal.RELOJ " & _
                                     "WHERE [Personal Bonos AF PTU].AF = '" & drAño & "'", "PERSONAL")
                If dtBonus.Rows.Count > 0 Then
                    dtDatos.Rows.Add({dtBonus.Rows(0)("MANAGER"), _
                                      dtBonus.Rows(0)("NOMBRES"), _
                                      dtBonus.Rows(0)("AF"), _
                                      dtBonus.Rows(0)("RELOJ"), _
                                      RTrim(dtBonus.Rows(0)("NOMBRE")), _
                                      RTrim(dtBonus.Rows(0)("APATERNO")), _
                                      dtBonus.Rows(0)("NOM_DIVISION"), _
                                      dtBonus.Rows(0)("RESU_DIVISION"), _
                                      dtBonus.Rows(0)("BONO_PORCEN1"), _
                                      dtBonus.Rows(0)("BONO_OBJETIVO"), _
                                      dtBonus.Rows(0)("BONO_PORCEN2"), _
                                      dtBonus.Rows(0)("BONO_DERECHO"), _
                                      dtBonus.Rows(0)("PTU_MONTO"), _
                                      dtBonus.Rows(0)("BONO_BRP"), _
                                      dtBonus.Rows(0)("TOTAL_BONOS"), _
                                      drMes, _
                                      drMes1})
                End If
            Catch ex As Exception
                ActivoTrabajando = False
                frmTrabajando.Close()
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
            End Try
            ActivoTrabajando = False
            frmTrabajando.Close()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub BajasSUA(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim Columnas(12) As DataColumn
        Dim ArchivoFoto As String = ""
        Dim PathFoto As String = ""
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 0
        Dim GuardaArchivo As Boolean = True
        Dim sfd As New SaveFileDialog
        Dim BajasSUA As String = ""
        Try
            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("fecha_mov", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("num_incap", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("dias_incap_Ausen", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("integrado", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("Nombre", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("Reloj", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("Motivo", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("fecha_ini", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("fecha_fin", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            'dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            If dtInformacion.Rows.Count > 0 Then
                Dim frm_cia As New frmSeleccionarCia
                frm_cia.ShowDialog()

                'Dim frm_fechas As New frmRangoFechas
                'frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
                'frm_fechas.frmRangoFechas_fecha_fin = Now
                'frm_fechas.ShowDialog()

                dtTemp = sqlExecute("SELECT rfc,infonavit,reg_pat,nombre,guia,minimo*25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                Dim _tope As Double = dtTemp.Rows(0).Item("tope")
                Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

                sfd.DefaultExt = ".txt"
                sfd.Title = "Crear Disco de Bajas al SUA"
                sfd.FileName = Compania & "_Disco_Bajas_SUA_" & FechaSQL(Date.Now) & ".txt"
                sfd.OverwritePrompt = True

                If sfd.ShowDialog() = DialogResult.OK Then
                    BajasSUA = sfd.FileName
                End If

                Dim objFS As New FileStream(BajasSUA, FileMode.Create, FileAccess.Write)
                Dim objSW As New StreamWriter(objFS)

                GuardaArchivo = BajasSUA <> ""

                For Each dRow As DataRow In dtInformacion.Select("Baja Is Not Null", "imss")
                    Dim integ As String = "0"
                    Dim integTemp As Double = 0

                    If Not IsDBNull(dRow("integrado")) Then
                        If dRow("integrado") > dtTemp.Rows(0).Item("tope") Then
                            integTemp = dtTemp.Rows(0).Item("tope")
                        Else
                            integTemp = dRow("integrado")
                        End If
                        'dRow.Item("integrado") = Double.Parse(Format(dRow.Item("integrado"), "f"))
                    End If
                    integ = Format(integTemp, "f")

                    dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), "02", FechaDMY(IIf(IsDBNull(dRow("baja")), Nothing, dRow("baja"))), "", "", integ, dRow("nombres"), dRow("Reloj"), dRow("motivo_baja_im"), FechaSQL(FechaInicial), FechaSQL(FechaFinal))

                    x = dtDatos.Rows.Count - 1

                    If GuardaArchivo Then
                        objSW.WriteLine(dtDatos.Rows(x).Item("reg_pat").ToString.Trim.PadRight(11) & _
                                        dtDatos.Rows(x).Item("imss").ToString.Trim.PadRight(10) & _
                                        dtDatos.Rows(x).Item("dig_ver").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("tipo_mov").ToString.Trim.PadRight(2) & _
                                        dtDatos.Rows(x).Item("fecha_mov").ToString.Trim.PadRight(8) & _
                                        dtDatos.Rows(x).Item("num_incap").ToString.Trim.PadRight(8) & _
                                        dtDatos.Rows(x).Item("dias_incap_Ausen").ToString.Trim.PadRight(2) & _
                                        dtDatos.Rows(x).Item("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
                    End If
                Next
                'If GuardaArchivo Then
                'objSW.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
                'End If
                objSW.Close()

                Console.WriteLine("")
                Console.WriteLine("File creation complete. Press <Enter> to close this window.")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Debug.Print(ex.StackTrace)
        End Try

    End Sub
    Public Sub ModificacionesIncapSUA(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim Columnas(19) As DataColumn
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 1
        Dim ausentismo As String = ""
        Dim GuardaArchivo As Boolean = True
        Dim sfd As New SaveFileDialog
        Dim _x As Integer = 1
        Dim nFecha As Date
        Dim nFecha1 As Date

        Try
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("fecha_mov", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("num_incap", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("dias_incap_Ausen", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("integrado", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("Nombres", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("Reloj", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("curp", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("cod_clase", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("cod_hora", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("tipo_aus_nombre", System.Type.GetType("System.String"))
            Columnas(14) = New DataColumn("tipo_aus", System.Type.GetType("System.String"))
            Columnas(15) = New DataColumn("tipo", System.Type.GetType("System.String"))
            Columnas(16) = New DataColumn("tipo_nombre", System.Type.GetType("System.String"))
            Columnas(17) = New DataColumn("fecha_ini", System.Type.GetType("System.String"))
            Columnas(18) = New DataColumn("fecha_fin", System.Type.GetType("System.String"))
            Columnas(19) = New DataColumn("tipo_naturaleza", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            'dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            Dim frm_cia As New frmSeleccionarCia
            frm_cia.ShowDialog()

            Dim frm_fechas As New frmRangoFechas
            frm_fechas.Text = "Filtrar fecha para la Incapacidad"
            frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 12)
            frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>FECHAS PARA INCAPACIDAD</b></font>
            frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
            frm_fechas.frmRangoFechas_fecha_fin = Now
            frm_fechas.ShowDialog()

            dtTemp = sqlExecute("SELECT rfc, infonavit, reg_pat, nombre, guia, minimo*25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
            Dim _tope As Double = dtTemp.Rows(0).Item("tope")

            sfd.DefaultExt = ".txt"
            sfd.Title = "Crear Disco Incapacidad al SUA"
            sfd.FileName = Compania & "_Disco_Incapacidad_SUA_" & FechaSQL(Date.Now) & ".txt"
            sfd.OverwritePrompt = True

            If sfd.ShowDialog() = DialogResult.OK Then
                ausentismo = sfd.FileName
            End If

            Dim objFS As New FileStream(ausentismo, FileMode.Create, FileAccess.Write)
            Dim objSW As New StreamWriter(objFS)

            frmTrabajando.Show()
            Try
                Dim dtIncapacidades As DataTable = sqlExecute("select DISTINCT reloj, referencia, ausentismo.tipo_aus, tipo_ausentismo.NOMBRE from ausentismo left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus where ausentismo.tipo_aus in (select tipo_aus from tipo_ausentismo where tipo_naturaleza = 'I') and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and cod_comp = '" & Compania & "'", "TA")
                Dim _CountReg As Integer = dtIncapacidades.Rows.Count

                For Each row As DataRow In dtIncapacidades.Rows
                    frmTrabajando.lblAvance.Text = "Reloj: " & row("Reloj")
                    frmTrabajando.Text = "Generando archivo " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
                    Application.DoEvents()

                    Dim dtFechas As DataTable = sqlExecute("select top 1 fecha from ausentismo where reloj = '" & row("reloj") & "' and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and referencia = '" & RTrim(IIf(IsDBNull(row("referencia")), "", row("referencia"))) & "' order by fecha asc", "TA")
                    nFecha = FechaSQL(dtFechas.Rows(0).Item("fecha"))
                    nFecha1 = FechaSQL(FechaInicial)
                    If nFecha >= nFecha1 Then
                        Dim dtDias As DataTable = sqlExecute("select referencia, count(distinct(fecha)) as dias from ausentismo where reloj = '" & row("reloj") & "' and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and referencia = '" & RTrim(IIf(IsDBNull(row("referencia")), "", row("referencia"))) & "' group by referencia", "TA")
                        Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj = '" & row("reloj") & "'")

                        dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""),
                                         dtPersona.Rows(0).Item("imss"),
                                         dtPersona.Rows(0).Item("dig_ver"), "12",
                                         FechaDMY(IIf(IsDBNull(dtFechas.Rows(0).Item("fecha")), Nothing, dtFechas.Rows(0).Item("fecha"))),
                                         row("referencia").ToString.Substring(0, 8),
                                         dtDias.Rows(0).Item("dias"),
                                         IIf(dtPersona.Rows(0).Item("integrado") > _tope, _tope.ToString("N2"), dtPersona.Rows(0).Item("integrado")),
                                         dtPersona.Rows(0).Item("nombres"),
                                         dtPersona.Rows(0).Item("Reloj"),
                                         dtPersona.Rows(0).Item("curp"),
                                         dtPersona.Rows(0).Item("cod_clase"),
                                         dtPersona.Rows(0).Item("cod_hora"),
                                         row("nombre"),
                                         row("tipo_aus"), "I", "INCAPACIDADES",
                                         FechaSQL(FechaInicial), FechaSQL(FechaFinal), "I")

                        Dim fechafin As Date = Date.Parse(dtFechas.Rows(0)("fecha")).AddDays(dtDias.Rows(0)("dias"))
                    End If
                    _x += 1
                Next
            Catch ex As Exception
                MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
            End Try

            Try
                For Each row As DataRow In dtDatos.Select("imss Is Not Null", "imss")
                    objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
                                    row("imss").ToString.Trim.PadRight(10) & _
                                    row("dig_ver").ToString.Trim.PadRight(1) & _
                                    row("tipo_mov").ToString.Trim.PadRight(2) & _
                                    row("fecha_mov").ToString.Trim.PadRight(8) & _
                                    row("num_incap").ToString.Trim.PadRight(8) & _
                                    row("dias_incap_Ausen").ToString.Trim.PadLeft(2, "0") & _
                                    row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
                Next
            Catch ex As Exception
                MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
            End Try

            'If GuardaArchivo Then
            'objSW.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
            'End If
            objSW.Close()

            Console.WriteLine("")
            Console.WriteLine("File creation complete. Press <Enter> to close this window.")

            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()

        Catch ex As Exception
            MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
        End Try

    End Sub
    Public Sub ModificacionesSUA(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim aplica_Variables As Boolean = False
        ' Dim dtInfoPersonal As New DataTable
        Dim Columnas(12) As DataColumn
        Dim ArchivoFoto As String = ""
        'Dim imgConnection As New SqlClient.SqlConnection(SQLConn & ";Initial Catalog='Personal';Persist Security Info=True; User ID=sa; Password=" & sPassword & ";")
        Dim PathFoto As String = ""
        Dim strFileName As String = ""
        Dim _CountReg As Integer = 0
        Dim _X As Integer = 1
        Dim GuardaArchivo As Boolean = True
        Dim sfd As New SaveFileDialog
        Dim ModiSUA As String = ""
        Dim oWrite As System.IO.StreamWriter
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 0
        'Dim i As Integer

        Try

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("fecha_mov", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("num_incap", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("dias_incap_Ausen", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("integrado", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("Nombres", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("Reloj", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("curp", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("fecha_ini", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("fecha_fin", System.Type.GetType("System.String"))

            'copy fields reg_pat,imss,dig_ver,paterno,materno,nombre,integrado,f1,tipo_trab,tipo_sdo,;
            '	sem_jorred,modi,f2,tipo_mov,guia,reloj,filler,curp,identifica to &_archivo type sdf		

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            'dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            If dtInformacion.Rows.Count > 0 Then
                Dim frm_cia As New frmSeleccionarCia
                frm_cia.ShowDialog()

                If MessageBox.Show("¿Desea generar el archivo haciendo referencia a la aplicación de variables ?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    aplica_Variables = True
                End If

                Dim frm_fechas As New frmRangoFechas
                frm_fechas.Text = "Filtrar fecha por Mod. Salario"
                frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 12)
                frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>FECHAS DE MOD. SALARIOS</b></font>
                frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
                frm_fechas.frmRangoFechas_fecha_fin = Now
                frm_fechas.ShowDialog()

                dtTemp = sqlExecute("SELECT rfc,infonavit,reg_pat,nombre,guia,minimo*25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                Dim _tope As Double = dtTemp.Rows(0).Item("tope")
                Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

                sfd.DefaultExt = ".txt"
                sfd.Title = "Crear Disco de Modificaciones al SUA"
                sfd.FileName = Compania & "_Disco_Modificaciones_SUA_" & FechaSQL(Date.Now) & ".txt"
                sfd.OverwritePrompt = True

                If sfd.ShowDialog() = DialogResult.OK Then
                    ModiSUA = sfd.FileName
                End If

                Dim objFS As New FileStream(ModiSUA, FileMode.Create, FileAccess.Write)
                Dim objSW As New StreamWriter(objFS)

                frmTrabajando.Show()
                Dim QConsulta As String = ""
                If aplica_Variables Then
                    QConsulta = "select p.*,n.nvo_integrado from personalvw p left outer join NOMINA.dbo.variables_nom n on p.RELOJ=n.reloj where isnull(aplica,0)=1 and " & _
                        "n.ano+n.bimestre=(select ano+bimestre from ta.dbo.periodos_variables where fec_aplica between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "')"
                Else
                    QConsulta = "Select * from personalvw where fha_ult_mo is not null and fha_ult_mo between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'"
                End If

                Dim dtModiSalario As DataTable = sqlExecute(QConsulta)
                _X = 1
                _CountReg = dtModiSalario.Rows.Count
                For Each dRow As DataRowView In dtModiSalario.DefaultView
                    frmTrabajando.lblAvance.Text = "Reloj: " & dRow("Reloj")
                    frmTrabajando.Text = "Mod. Salarios " & CDbl(_X / _CountReg).ToString("0%") & " Terminado"
                    Application.DoEvents()

                    Dim integ As String = "0"
                    Dim integTemp As Double = 0
                    Dim integrado_enviar As Double = 0

                    If aplica_Variables Then
                        Try : integrado_enviar = Double.Parse(dRow("nvo_integrado")) : Catch ex As Exception : integrado_enviar = 0.0 : End Try
                    Else
                        Try : integrado_enviar = Double.Parse(dRow("integrado")) : Catch ex As Exception : integrado_enviar = 0.0 : End Try
                    End If

                    If integrado_enviar <> 0 Then
                        If integrado_enviar > dtTemp.Rows(0).Item("tope") Then
                            integTemp = dtTemp.Rows(0).Item("tope")
                        Else
                            integTemp = integrado_enviar
                        End If
                    End If

                    '---AOS: Codigo Original
                    'If Not IsDBNull(dRow("integrado")) Then
                    '    If dRow("integrado") > dtTemp.Rows(0).Item("tope") Then
                    '        integTemp = dtTemp.Rows(0).Item("tope")
                    '    Else
                    '        integTemp = dRow("integrado")
                    '    End If
                    'End If

                    integ = Format(integTemp, "f")
                    If aplica_Variables Then
                        dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), "07", FechaDMY(FechaInicial), "", "", integ, dRow("nombres"), dRow("Reloj"), dRow("curp"), FechaSQL(FechaInicial), FechaSQL(FechaFinal))
                    Else
                        dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), "07", FechaDMY(IIf(IsDBNull(dRow("fha_ult_mo")), Nothing, dRow("fha_ult_mo"))), "", "", integ, dRow("nombres"), dRow("Reloj"), dRow("curp"), FechaSQL(FechaInicial), FechaSQL(FechaFinal))
                    End If

                    '   dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), "07", FechaDMY(IIf(IsDBNull(dRow("fha_ult_mo")), Nothing, dRow("fha_ult_mo"))), "", "", integ, dRow("nombres"), dRow("Reloj"), dRow("curp"), FechaSQL(FechaInicial), FechaSQL(FechaFinal))
                    _X += 1
                Next
                For Each row As DataRow In dtDatos.Select("tipo_mov = 07", "imss")
                    objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
                                    row("imss").ToString.Trim.PadRight(10) & _
                                    row("dig_ver").ToString.Trim.PadRight(1) & _
                                    row("tipo_mov").ToString.Trim.PadRight(2) & _
                                    row("fecha_mov").ToString.Trim.PadRight(8) & _
                                    row("num_incap").ToString.Trim.PadRight(8) & _
                                    row("dias_incap_Ausen").ToString.Trim.PadRight(2).PadLeft(2, "0") & _
                                    row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
                Next
                'If GuardaArchivo Then
                'oWrite.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
                'End If
                objSW.Close()

                Console.WriteLine("")
                Console.WriteLine("File creation complete. Press <Enter> to close this window.")

                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Debug.Print(ex.StackTrace)
        End Try

    End Sub
    Public Sub ReingresoSUA(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim Columnas(11) As DataColumn
        Dim ArchivoFoto As String = ""
        Dim PathFoto As String = ""
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 0
        Dim GuardaArchivo As Boolean = True
        Dim sfd As New SaveFileDialog
        Dim ReinSUA As String = ""
        Try
            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("fecha_mov", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("num_incap", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("dias_incap_Ausen", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("integrado", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("Nombre", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("Reloj", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("fecha_ini", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("fecha_fin", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            'dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            If dtInformacion.Rows.Count > 0 Then

                Dim frm_cia As New frmSeleccionarCia
                frm_cia.ShowDialog()

                Dim frm_fechas As New frmRangoFechas
                frm_fechas.Text = "Filtrar fecha por Reingreso"
                frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 13)
                frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>FECHAS DE REINGRESO</b></font>
                frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
                frm_fechas.frmRangoFechas_fecha_fin = Now
                frm_fechas.ShowDialog()

                dtTemp = sqlExecute("SELECT rfc,infonavit,reg_pat,nombre,guia,minimo*25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                Dim _tope As Double = dtTemp.Rows(0).Item("tope")
                Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

                sfd.DefaultExt = ".txt"
                sfd.Title = "Crear Disco de Reingresos al SUA"
                sfd.FileName = Compania & "_Disco_Reingresos_SUA_" & FechaSQL(Date.Now) & ".txt"
                sfd.OverwritePrompt = True

                If sfd.ShowDialog() = DialogResult.OK Then
                    ReinSUA = sfd.FileName
                End If

                Dim objFS As New FileStream(ReinSUA, FileMode.Create, FileAccess.Write)
                Dim objSW As New StreamWriter(objFS)

                GuardaArchivo = ReinSUA <> ""
                Dim dtReingresos As DataTable = sqlExecute("Select reloj, alta From reingresos where alta between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' order by reloj", "PERSONAL")
                For Each dRow As DataRowView In dtReingresos.DefaultView
                    Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj = '" & dRow("reloj") & "'")
                    dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dtPersona.Rows(0).Item("imss"), dtPersona.Rows(0).Item("dig_ver"), "08", FechaDMY(IIf(IsDBNull(dRow("alta")), Nothing, dRow("alta"))), "", "", IIf(dtPersona.Rows(0).Item("integrado") > _tope, _tope.ToString("N2"), dtPersona.Rows(0).Item("integrado")), dtPersona.Rows(0).Item("nombres"), dtPersona.Rows(0).Item("Reloj"), FechaSQL(FechaInicial), FechaSQL(FechaFinal))
                    x = dtDatos.Rows.Count - 1
                    If GuardaArchivo Then
                        objSW.WriteLine(dtDatos.Rows(x).Item("reg_pat").ToString.Trim.PadRight(11) & _
                                        dtDatos.Rows(x).Item("imss").ToString.Trim.PadRight(10) & _
                                        dtDatos.Rows(x).Item("dig_ver").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("tipo_mov").ToString.Trim.PadRight(2) & _
                                        dtDatos.Rows(x).Item("fecha_mov").ToString.Trim.PadRight(8) & _
                                        dtDatos.Rows(x).Item("num_incap").ToString.Trim.PadRight(8) & _
                                        dtDatos.Rows(x).Item("dias_incap_Ausen").ToString.Trim.PadRight(2) & _
                                        dtDatos.Rows(x).Item("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
                    End If
                Next
                'If GuardaArchivo Then
                'objSW.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
                'End If
                objSW.Close()
                Console.WriteLine("")
                Console.WriteLine("File creation complete. Press <Enter> to close this window.")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Debug.Print(ex.StackTrace)
        End Try

    End Sub

    'Original
    'Public Sub SUAGlobal(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
    '    Dim Columnas(20) As DataColumn
    '    Dim x As Integer = 0
    '    Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
    '    Dim z As Integer = 1
    '    Dim GlobalSUA As String = ""
    '    Dim GuardaArchivo As Boolean = True
    '    Dim sfd As New SaveFileDialog
    '    Dim _x As Integer = 1
    '    Dim nFecha As Date
    '    Dim nFecha1 As Date
    '    Dim _CountReg As Integer = 0
    '    Try
    '        dtDatos = New DataTable("Datos")
    '        Columnas(0) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
    '        Columnas(1) = New DataColumn("imss", System.Type.GetType("System.String"))
    '        Columnas(2) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
    '        Columnas(3) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
    '        Columnas(4) = New DataColumn("fecha_mov", System.Type.GetType("System.String"))
    '        Columnas(5) = New DataColumn("num_incap", System.Type.GetType("System.String"))
    '        Columnas(6) = New DataColumn("dias_incap_Ausen", System.Type.GetType("System.String"))
    '        Columnas(7) = New DataColumn("integrado", System.Type.GetType("System.String"))
    '        Columnas(8) = New DataColumn("Nombres", System.Type.GetType("System.String"))
    '        Columnas(9) = New DataColumn("Reloj", System.Type.GetType("System.String"))
    '        Columnas(10) = New DataColumn("Motivo", System.Type.GetType("System.String"))
    '        Columnas(11) = New DataColumn("curp", System.Type.GetType("System.String"))
    '        Columnas(12) = New DataColumn("cod_clase", System.Type.GetType("System.String"))
    '        Columnas(13) = New DataColumn("cod_hora", System.Type.GetType("System.String"))
    '        Columnas(14) = New DataColumn("tipo_aus_nombre", System.Type.GetType("System.String"))
    '        Columnas(15) = New DataColumn("tipo_aus", System.Type.GetType("System.String"))
    '        Columnas(16) = New DataColumn("tipo", System.Type.GetType("System.String"))
    '        Columnas(17) = New DataColumn("tipo_nombre", System.Type.GetType("System.String"))
    '        Columnas(18) = New DataColumn("fecha_ini", System.Type.GetType("System.String"))
    '        Columnas(19) = New DataColumn("fecha_fin", System.Type.GetType("System.String"))
    '        Columnas(20) = New DataColumn("tipo_naturaleza", System.Type.GetType("System.String"))

    '        For x = 0 To UBound(Columnas)
    '            dtDatos.Columns.Add(Columnas(x))
    '        Next
    '        'dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

    '        Dim frm_cia As New frmSeleccionarCia
    '        frm_cia.ShowDialog()

    '        Dim frm_fechas As New frmRangoFechas
    '        frm_fechas.Text = "Filtrar fecha para el SUA Global"
    '        frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 11)
    '        frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>FECHAS PARA SUA GLOBAL</b></font>
    '        frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
    '        frm_fechas.frmRangoFechas_fecha_fin = Now
    '        frm_fechas.ShowDialog()

    '        dtTemp = sqlExecute("SELECT rfc, infonavit, reg_pat, nombre, guia, minimo*25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
    '        Dim _tope As Double = dtTemp.Rows(0).Item("tope")

    '        sfd.DefaultExt = ".txt"
    '        sfd.Title = "Crear Disco Global al SUA"
    '        sfd.FileName = Compania & "_Disco_Global_SUA_" & FechaSQL(Date.Now) & ".txt"
    '        sfd.OverwritePrompt = True

    '        If sfd.ShowDialog() = DialogResult.OK Then
    '            GlobalSUA = sfd.FileName
    '        End If

    '        Dim objFS As New FileStream(GlobalSUA, FileMode.Create, FileAccess.Write)
    '        Dim objSW As New StreamWriter(objFS)

    '        frmTrabajando.Show()
    '        '//*********************************** Bajas
    '        For Each dRow As DataRow In dtInformacion.Select("Baja Is Not Null", "imss")
    '            If _CountReg = 0 Then _CountReg = dtInformacion.Rows.Count
    '            frmTrabajando.lblAvance.Text = "Reloj: " & dRow("Reloj")
    '            frmTrabajando.Text = "Bajas " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
    '            Application.DoEvents()
    '            dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), "02", FechaDMY(IIf(IsDBNull(dRow("baja")), Nothing, dRow("baja"))), "", "", IIf(dRow("integrado") > _tope, _tope.ToString("N2"), dRow("integrado")), dRow("nombres"), dRow("Reloj"), dRow("motivo_baja_im"), dRow("curp"), "", "", "", "", "B", "BAJAS", FechaSQL(FechaInicial), FechaSQL(FechaFinal), "")
    '            _x += 1
    '        Next
    '        For Each row As DataRow In dtDatos.Select("tipo_mov = 02", "imss")
    '            objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
    '                            row("imss").ToString.Trim.PadRight(10) & _
    '                            row("dig_ver").ToString.Trim.PadRight(1) & _
    '                            row("tipo_mov").ToString.Trim.PadRight(2) & _
    '                            row("fecha_mov").ToString.Trim.PadRight(8) & _
    '                            row("num_incap").ToString.Trim.PadRight(8) & _
    '                            row("dias_incap_Ausen").ToString.Trim.PadRight(2).PadLeft(2, "0") & _
    '                            row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
    '        Next

    '        '//********************************** Incapacidades
    '        Dim dtIncapacidades As DataTable = sqlExecute("select DISTINCT reloj, referencia, ausentismo.tipo_aus, tipo_ausentismo.NOMBRE from ausentismo left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus where ausentismo.tipo_aus in (select tipo_aus from tipo_ausentismo where tipo_naturaleza = 'I') and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and cod_comp = '" & Compania & "'", "TA")
    '        _x = 1
    '        _CountReg = dtIncapacidades.Rows.Count
    '        For Each row As DataRowView In dtIncapacidades.DefaultView
    '            frmTrabajando.lblAvance.Text = "Reloj: " & row("Reloj")
    '            frmTrabajando.Text = "Incapacidades " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
    '            Application.DoEvents()

    '            Dim dtFechas As DataTable = sqlExecute("select top 1 fecha from ausentismo where reloj = '" & row("reloj") & "' and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and referencia = '" & RTrim(IIf(IsDBNull(row("referencia")), "", row("referencia"))) & "' order by fecha asc", "TA")
    '            nFecha = FechaSQL(dtFechas.Rows(0).Item("fecha"))
    '            nFecha1 = FechaSQL(FechaInicial)
    '            If nFecha >= nFecha1 Then
    '                Dim dtDias As DataTable = sqlExecute("select referencia, count(distinct(fecha)) as dias from ausentismo where reloj = '" & row("reloj") & "' and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and referencia = '" & RTrim(IIf(IsDBNull(row("referencia")), "", row("referencia"))) & "' group by referencia", "TA")
    '                Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj = '" & row("reloj") & "'")

    '                dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""),
    '                                 dtPersona.Rows(0).Item("imss"),
    '                                 dtPersona.Rows(0).Item("dig_ver"), "12",
    '                                 FechaDMY(IIf(IsDBNull(dtFechas.Rows(0).Item("fecha")), Nothing, dtFechas.Rows(0).Item("fecha"))),
    '                                 row("referencia").ToString.Substring(0, 8),
    '                                 dtDias.Rows(0).Item("dias"),
    '                                 IIf(dtPersona.Rows(0).Item("integrado") > _tope, _tope.ToString("N2"), dtPersona.Rows(0).Item("integrado")),
    '                                 dtPersona.Rows(0).Item("nombres"),
    '                                 dtPersona.Rows(0).Item("Reloj"), "",
    '                                 dtPersona.Rows(0).Item("curp"),
    '                                 dtPersona.Rows(0).Item("cod_clase"),
    '                                 dtPersona.Rows(0).Item("cod_hora"),
    '                                 row("nombre"),
    '                                 row("tipo_aus"), "I", "INCAPACIDADES",
    '                                 FechaSQL(FechaInicial), FechaSQL(FechaFinal), "I")

    '                Dim fechafin As Date = Date.Parse(dtFechas.Rows(0)("fecha")).AddDays(dtDias.Rows(0)("dias"))
    '            End If
    '            _x += 1
    '        Next
    '        For Each row As DataRow In dtDatos.Select("tipo_mov = 12", "imss")
    '            objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
    '                            row("imss").ToString.Trim.PadRight(10) & _
    '                            row("dig_ver").ToString.Trim.PadRight(1) & _
    '                            row("tipo_mov").ToString.Trim.PadRight(2) & _
    '                            row("fecha_mov").ToString.Trim.PadRight(8) & _
    '                            row("num_incap").ToString.Trim.PadRight(8) & _
    '                            row("dias_incap_Ausen").ToString.Trim.PadRight(2).PadLeft(2, "0") & _
    '                            row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
    '        Next
    '        '//******************************************* Modificaciones al Salario
    '        Dim dtModiSalario As DataTable = sqlExecute("Select * from personalvw where fha_ult_mo is not null and fha_ult_mo between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'")
    '        _x = 1
    '        _CountReg = dtModiSalario.Rows.Count
    '        For Each dRow As DataRowView In dtModiSalario.DefaultView
    '            frmTrabajando.lblAvance.Text = "Reloj: " & dRow("Reloj")
    '            frmTrabajando.Text = "Mod. Salarios " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
    '            Application.DoEvents()

    '            Dim integ As String = "0"
    '            Dim integTemp As Double = 0

    '            If Not IsDBNull(dRow("integrado")) Then
    '                If dRow("integrado") > dtTemp.Rows(0).Item("tope") Then
    '                    integTemp = dtTemp.Rows(0).Item("tope")
    '                Else
    '                    integTemp = dRow("integrado")
    '                End If
    '                'dRow.Item("integrado") = Double.Parse(Format(dRow.Item("integrado"), "f"))
    '            End If
    '            integ = Format(integTemp, "f")

    '            dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), "07", FechaDMY(IIf(IsDBNull(dRow("fha_ult_mo")), Nothing, dRow("fha_ult_mo"))), "", "", integ, dRow("nombres"), dRow("Reloj"), "", dRow("curp"), "", "", "", "", "M", "MODIFICACIONES DE SALARIOS", FechaSQL(FechaInicial), FechaSQL(FechaFinal), "")
    '            _x += 1
    '        Next
    '        For Each row As DataRow In dtDatos.Select("tipo_mov = 07", "imss")
    '            objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
    '                            row("imss").ToString.Trim.PadRight(10) & _
    '                            row("dig_ver").ToString.Trim.PadRight(1) & _
    '                            row("tipo_mov").ToString.Trim.PadRight(2) & _
    '                            row("fecha_mov").ToString.Trim.PadRight(8) & _
    '                            row("num_incap").ToString.Trim.PadRight(8) & _
    '                            row("dias_incap_Ausen").ToString.Trim.PadRight(2).PadLeft(2, "0") & _
    '                            row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
    '        Next
    '        '//********************************************* Reingresos
    '        Dim dtReingresos As DataTable = sqlExecute("Select reloj, alta From reingresos where alta between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' order by reloj", "PERSONAL")
    '        _x = 1
    '        _CountReg = dtReingresos.Rows.Count
    '        For Each dRow As DataRowView In dtReingresos.DefaultView
    '            frmTrabajando.lblAvance.Text = "Reloj: " & dRow("Reloj")
    '            frmTrabajando.Text = "Reingresos " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
    '            Application.DoEvents()

    '            Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj = '" & dRow("reloj") & "'")
    '            dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dtPersona.Rows(0).Item("imss"), dtPersona.Rows(0).Item("dig_ver"), "08", FechaDMY(IIf(IsDBNull(dRow("alta")), Nothing, dRow("alta"))), "", "", IIf(dtPersona.Rows(0).Item("integrado") > _tope, _tope.ToString("N2"), dtPersona.Rows(0).Item("integrado")), dtPersona.Rows(0).Item("nombres"), dtPersona.Rows(0).Item("Reloj"), "", dtPersona.Rows(0).Item("curp"), "", "", "", "", "R", "REINGRESOS", FechaSQL(FechaInicial), FechaSQL(FechaFinal), "")
    '            _x += 1
    '        Next

    '        For Each row As DataRow In dtDatos.Select("tipo_mov = 08", "imss")
    '            objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
    '                            row("imss").ToString.Trim.PadRight(10) & _
    '                            row("dig_ver").ToString.Trim.PadRight(1) & _
    '                            row("tipo_mov").ToString.Trim.PadRight(2) & _
    '                            row("fecha_mov").ToString.Trim.PadRight(8) & _
    '                            row("num_incap").ToString.Trim.PadRight(8) & _
    '                            row("dias_incap_Ausen").ToString.Trim.PadRight(2).PadLeft(2, "0") & _
    '                            row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
    '        Next

    '        ' GuardaArchivo Then
    '        ' objSW.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
    '        ' End If
    '        objSW.Close()

    '        Console.WriteLine("")
    '        Console.WriteLine("File creation complete. Press <Enter> to close this window.")

    '        ActivoTrabajando = False
    '        frmTrabajando.Close()
    '        frmTrabajando.Dispose()

    '    Catch ex As Exception
    '        MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
    '    End Try

    'End Sub

    '****** Modificado, Adrian Ortega 2024-11-15 ******
    Public Sub SUAGlobal(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        '====Seleccionar el tipo de moviento
        Dim frm_Sel_Tipo_Mov As New frmSelTipoMovSUA
        frm_Sel_Tipo_Mov.ShowDialog()

        Dim _index_tipo_mov_sel As Integer = -1
        _index_tipo_mov_sel = frm_Sel_Tipo_Mov.cmbTipoMov.SelectedIndex ' 0=Reingre ; 1= Bajas 2= ModSal 3 = Incap 4= AUS ; 5 = Todos '
        If _index_tipo_mov_sel <= -1 Then
            '===No se seleccionó nada, cerrar todo
            MessageBox.Show("No se seleccionó ningún tipo de movimiento, por lo que se cerrará este proceso sin generar el archivo SUA", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        '====End

        Dim Columnas(20) As DataColumn
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 1
        Dim GlobalSUA As String = ""
        Dim GuardaArchivo As Boolean = True
        Dim sfd As New SaveFileDialog
        Dim _x As Integer = 1
        Dim nFecha As Date
        Dim nFecha1 As Date
        Dim _CountReg As Integer = 0
        Dim lclCompania As String = ""
        Dim fha_ini As String = ""
        Dim fha_fin As String = ""

        Try
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("fecha_mov", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("num_incap", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("dias_incap_Ausen", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("integrado", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("Nombres", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("Reloj", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("Motivo", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("curp", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("cod_clase", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("cod_hora", System.Type.GetType("System.String"))
            Columnas(14) = New DataColumn("tipo_aus_nombre", System.Type.GetType("System.String"))
            Columnas(15) = New DataColumn("tipo_aus", System.Type.GetType("System.String"))
            Columnas(16) = New DataColumn("tipo", System.Type.GetType("System.String"))
            Columnas(17) = New DataColumn("tipo_nombre", System.Type.GetType("System.String"))
            Columnas(18) = New DataColumn("fecha_ini", System.Type.GetType("System.String"))
            Columnas(19) = New DataColumn("fecha_fin", System.Type.GetType("System.String"))
            Columnas(20) = New DataColumn("tipo_naturaleza", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            'dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            Dim frm_cia As New frmSeleccionarCia
            frm_cia.ShowDialog()

            lclCompania = Compania




            Dim frm_fechas As New frmRangoFechas
            frm_fechas.Text = "Filtrar fecha para el SUA Global"
            frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 11)
            frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>FECHAS PARA SUA GLOBAL</b></font>
            frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
            frm_fechas.frmRangoFechas_fecha_fin = Now
            frm_fechas.ShowDialog()

            fha_ini = FechaSQL(FechaInicial)
            fha_fin = FechaSQL(FechaFinal)


            'dtTemp = sqlExecute("SELECT rfc, infonavit, reg_pat, nombre, guia, minimo*25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")

            dtTemp = sqlExecute("SELECT rfc, infonavit, reg_pat, nombre, guia, minimo*25 AS tope FROM cias WHERE cod_comp = '" & lclCompania & "'")

            Dim _tope As Double = dtTemp.Rows(0).Item("tope")

            sfd.DefaultExt = ".txt"
            sfd.Title = "Crear Disco Global al SUA"
            sfd.FileName = Compania & "_Disco_Global_SUA_" & fha_ini & "_al_" & fha_fin & ".txt"
            sfd.OverwritePrompt = True

            If sfd.ShowDialog() = DialogResult.OK Then
                GlobalSUA = sfd.FileName
            End If

            Dim objFS As New FileStream(GlobalSUA, FileMode.Create, FileAccess.Write)
            Dim objSW As New StreamWriter(objFS)

            frmTrabajando.Show()

            '//*********************************** Bajas
            If (_index_tipo_mov_sel = 1 Or _index_tipo_mov_sel = 5) Then

                '===AO: 2024-11-06: Que las bajas no dependan del filtro del reporteador, que se haga de acuerdo a las bajas que hubo en las fechas enviadas
                Dim dtBajas As New DataTable, query As String = ""
                query = "select reloj,imss,DIG_VER,baja,integrado,nombres,reloj,curp, motivo_baja_im from  personalvw where cod_comp in ('" & lclCompania & "') and baja between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'"
                dtBajas = sqlExecute(query, "PERSONAL")
                If Not dtBajas.Columns.Contains("Error") And dtBajas.Rows.Count > 0 Then
                    For Each dRow As DataRow In dtBajas.Rows
                        If _CountReg = 0 Then _CountReg = dtBajas.Rows.Count
                        frmTrabajando.lblAvance.Text = "Reloj: " & dRow("Reloj")
                        frmTrabajando.Text = "Bajas " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
                        Application.DoEvents()
                        dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), "02", FechaDMY(IIf(IsDBNull(dRow("baja")), Nothing, dRow("baja"))), "", "", IIf(IIf(IsDBNull(dRow("integrado")), 0, dRow("integrado")) > _tope, _tope.ToString("N2"), IIf(IsDBNull(dRow("integrado")), 0, dRow("integrado"))), dRow("nombres"), dRow("Reloj"), dRow("motivo_baja_im"), dRow("curp"), "", "", "", "", "B", "BAJAS", FechaSQL(FechaInicial), FechaSQL(FechaFinal), "")
                        _x += 1
                    Next


                    For Each row As DataRow In dtDatos.Select("tipo_mov = 02", "imss")
                        objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
                                        row("imss").ToString.Trim.PadRight(10) & _
                                        row("dig_ver").ToString.Trim.PadRight(1) & _
                                        row("tipo_mov").ToString.Trim.PadRight(2) & _
                                        row("fecha_mov").ToString.Trim.PadRight(8) & _
                                        row("num_incap").ToString.Trim.PadRight(8) & _
                                        row("dias_incap_Ausen").ToString.Trim.PadRight(2).PadLeft(2, "0") & _
                                        row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
                    Next

                End If

            End If


            '//********************************************* Reingresos

            If (_index_tipo_mov_sel = 0 Or _index_tipo_mov_sel = 5) Then

                Dim dtReingresos As DataTable = sqlExecute("select reloj,alta from personalvw where cod_comp in ('" & lclCompania & "') and  isnull(baja,'')=''  and ALTA between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' order by reloj asc", "PERSONAL")
                ' Dim dtReingresos As DataTable = sqlExecute("Select reloj, alta From reingresos where alta between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' order by reloj", "PERSONAL")
                _x = 1
                _CountReg = dtReingresos.Rows.Count
                For Each dRow As DataRowView In dtReingresos.DefaultView
                    frmTrabajando.lblAvance.Text = "Reloj: " & dRow("Reloj")
                    frmTrabajando.Text = "Reingresos " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
                    Application.DoEvents()

                    Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj = '" & dRow("reloj").ToString.Trim & "'")
                    dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dtPersona.Rows(0).Item("imss"), dtPersona.Rows(0).Item("dig_ver"), "08", FechaDMY(IIf(IsDBNull(dRow("alta")), Nothing, dRow("alta"))), "", "", IIf(IIf(IsDBNull(dtPersona.Rows(0).Item("integrado")), 0, dtPersona.Rows(0).Item("integrado")) > _tope, _tope.ToString("N2"), IIf(IsDBNull(dtPersona.Rows(0).Item("integrado")), 0, dtPersona.Rows(0).Item("integrado"))), dtPersona.Rows(0).Item("nombres"), dtPersona.Rows(0).Item("Reloj"), "", dtPersona.Rows(0).Item("curp"), "", "", "", "", "R", "REINGRESOS", FechaSQL(FechaInicial), FechaSQL(FechaFinal), "")
                    _x += 1
                Next

                For Each row As DataRow In dtDatos.Select("tipo_mov = 08", "imss")
                    objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
                                    row("imss").ToString.Trim.PadRight(10) & _
                                    row("dig_ver").ToString.Trim.PadRight(1) & _
                                    row("tipo_mov").ToString.Trim.PadRight(2) & _
                                    row("fecha_mov").ToString.Trim.PadRight(8) & _
                                    row("num_incap").ToString.Trim.PadRight(8) & _
                                    row("dias_incap_Ausen").ToString.Trim.PadRight(2).PadLeft(2, "0") & _
                                    row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
                Next

            End If

            '//******************************************* Modificaciones al Salario

            If (_index_tipo_mov_sel = 2 Or _index_tipo_mov_sel = 5) Then

                '===Lo toma solo de personal
                ' Dim dtModiSalario As DataTable = sqlExecute("Select * from personalvw where fha_ult_mo is not null and fha_ult_mo between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'")

                '===Lo toma de acuerdo o por registro personal en modsal
                ' Dim dtModiSalario As DataTable = sqlExecute("SelecT A.*, B.IMSS, B.DIG_VER, B.CURP, B.NOMBRES from MOD_SAL A LEFT JOIN personalVW B on A.RELOJ = B.RELOJ where A.fecha is not null and A.fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' AND A.COD_COMP IN (SELECT COD_COMP FROM CIAS WHERE REG_PAT = '" & lclCompania & "')")

                '===Lo toma de compañia en modsal (el mas usual)
                Dim dtModiSalario As DataTable = sqlExecute("SelecT A.*, B.IMSS, B.DIG_VER, B.CURP, B.NOMBRES from MOD_SAL A LEFT JOIN personalVW B on A.RELOJ = B.RELOJ where A.fecha is not null and A.fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' AND A.COD_COMP IN (SELECT COD_COMP FROM CIAS WHERE COD_COMP = '" & lclCompania & "')")


                _x = 1
                _CountReg = dtModiSalario.Rows.Count
                For Each dRow As DataRowView In dtModiSalario.DefaultView
                    frmTrabajando.lblAvance.Text = "Reloj: " & dRow("Reloj")
                    frmTrabajando.Text = "Mod. Salarios " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
                    Application.DoEvents()

                    Dim integ As String = "0"
                    Dim integTemp As Double = 0

                    If Not IsDBNull(dRow("integrado")) Then
                        If dRow("integrado") > dtTemp.Rows(0).Item("tope") Then
                            integTemp = dtTemp.Rows(0).Item("tope")
                        Else
                            integTemp = dRow("integrado")
                        End If
                        'dRow.Item("integrado") = Double.Parse(Format(dRow.Item("integrado"), "f"))
                    End If
                    integ = Format(integTemp, "f")

                    dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), "07", FechaDMY(IIf(IsDBNull(dRow("fha_ult_mo")), Nothing, dRow("fha_ult_mo"))), "", "", integ, dRow("nombres"), dRow("Reloj"), "", dRow("curp"), "", "", "", "", "M", "MODIFICACIONES DE SALARIOS", FechaSQL(FechaInicial), FechaSQL(FechaFinal), "")
                    _x += 1
                Next
                For Each row As DataRow In dtDatos.Select("tipo_mov = 07", "imss")
                    objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
                                    row("imss").ToString.Trim.PadRight(10) & _
                                    row("dig_ver").ToString.Trim.PadRight(1) & _
                                    row("tipo_mov").ToString.Trim.PadRight(2) & _
                                    row("fecha_mov").ToString.Trim.PadRight(8) & _
                                    row("num_incap").ToString.Trim.PadRight(8) & _
                                    row("dias_incap_Ausen").ToString.Trim.PadRight(2).PadLeft(2, "0") & _
                                    row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
                Next

            End If


            '//********************************** Incapacidades

            If (_index_tipo_mov_sel = 3 Or _index_tipo_mov_sel = 5) Then

                Dim dtIncapacidades As DataTable = sqlExecute("select DISTINCT reloj, referencia, ausentismo.tipo_aus, tipo_ausentismo.NOMBRE from ausentismo left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus where ausentismo.tipo_aus in (select tipo_aus from tipo_ausentismo where tipo_naturaleza = 'I') and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and cod_comp = '" & Compania & "' and ltrim(rtrim(isnull(referencia,''))) <> ''", "TA")
                _x = 1
                _CountReg = dtIncapacidades.Rows.Count
                For Each row As DataRowView In dtIncapacidades.DefaultView
                    frmTrabajando.lblAvance.Text = "Reloj: " & row("Reloj")
                    frmTrabajando.Text = "Incapacidades " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
                    Application.DoEvents()

                    Dim dtFechas As DataTable = sqlExecute("select top 1 fecha from ausentismo where reloj = '" & row("reloj").ToString.Trim & "' and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and ltrim(rtrim(isnull(referencia,''))) = '" & Trim(IIf(IsDBNull(row("referencia")), "", row("referencia"))) & "' order by fecha asc", "TA")
                    nFecha = FechaSQL(dtFechas.Rows(0).Item("fecha"))
                    nFecha1 = FechaSQL(FechaInicial)
                    If nFecha >= nFecha1 Then
                        Dim dtDias As DataTable = sqlExecute("select referencia, count(distinct(fecha)) as dias from ausentismo where reloj = '" & row("reloj").ToString.Trim & "' and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and ltrim(rtrim(isnull(referencia,''))) = '" & Trim(IIf(IsDBNull(row("referencia")), "", row("referencia"))) & "' group by referencia", "TA")
                        Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj = '" & row("reloj").ToString.Trim & "'")

                        dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""),
                                         dtPersona.Rows(0).Item("imss"),
                                         dtPersona.Rows(0).Item("dig_ver"), "12",
                                         FechaDMY(IIf(IsDBNull(dtFechas.Rows(0).Item("fecha")), Nothing, dtFechas.Rows(0).Item("fecha"))),
                                         row("referencia").ToString.Substring(0, 8),
                                         dtDias.Rows(0).Item("dias"),
                                         IIf(IIf(IsDBNull(dtPersona.Rows(0).Item("integrado")), 0, dtPersona.Rows(0).Item("integrado")) > _tope, _tope.ToString("N2"), IIf(IsDBNull(dtPersona.Rows(0).Item("integrado")), 0, dtPersona.Rows(0).Item("integrado"))),
                                         dtPersona.Rows(0).Item("nombres"),
                                         dtPersona.Rows(0).Item("Reloj"), "",
                                         dtPersona.Rows(0).Item("curp"),
                                         dtPersona.Rows(0).Item("cod_clase"),
                                         dtPersona.Rows(0).Item("cod_hora"),
                                         row("nombre"),
                                         row("tipo_aus"), "I", "INCAPACIDADES",
                                         FechaSQL(FechaInicial), FechaSQL(FechaFinal), "I")

                        Dim fechafin As Date = Date.Parse(dtFechas.Rows(0)("fecha")).AddDays(dtDias.Rows(0)("dias"))
                    End If
                    _x += 1
                Next
                For Each row As DataRow In dtDatos.Select("tipo_mov = 12", "imss")
                    objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
                                    row("imss").ToString.Trim.PadRight(10) & _
                                    row("dig_ver").ToString.Trim.PadRight(1) & _
                                    row("tipo_mov").ToString.Trim.PadRight(2) & _
                                    row("fecha_mov").ToString.Trim.PadRight(8) & _
                                    row("num_incap").ToString.Trim.PadRight(8) & _
                                    row("dias_incap_Ausen").ToString.Trim.PadLeft(2, "0") & _
                                    row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
                Next

            End If

            '=============================*************AUSENTISMOS ******************************************=========================

            If (_index_tipo_mov_sel = 4 Or _index_tipo_mov_sel = 5) Then

                Dim dtAusentismo As DataTable = sqlExecute("SELECT RELOJ, count(distinct(fecha)) as DIAS " & _
                                            "FROM ausentismo left join tipo_ausentismo ON tipo_ausentismo.TIPO_AUS = ausentismo.TIPO_AUS " & _
                                            "WHERE ausentismo.cod_comp in ('" & lclCompania & "') and (ausentismo.FECHA BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "') AND " & _
                                            "(ausentismo.TIPO_AUS IN (SELECT TIPO_AUS FROM tipo_ausentismo AS tipo_ausentismo_1 " & _
                                            "WHERE (AFECTA_SUA = 1) AND (TIPO_NATURALEZA <> 'I') AND (NOT(RELOJ LIKE 'X1')) AND (NOT(dbo.ausentismo.RELOJ LIKE 'X2')))) " & _
                                            "GROUP BY RELOJ " & _
                                            "ORDER BY DIAS DESC", "TA")


                _CountReg = dtAusentismo.Rows.Count
                For Each row As DataRow In dtAusentismo.Rows
                    frmTrabajando.lblAvance.Text = "Reloj: " & row("Reloj")
                    frmTrabajando.Text = "Generando archivo " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
                    Application.DoEvents()

                    Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj = '" & row("reloj").ToString.Trim & "'")
                    Dim dtDias As DataTable = sqlExecute("SELECT Top 7 RELOJ, FECHA, ausentismo.TIPO_AUS, tipo_ausentismo.NOMBRE " & _
                                                        "FROM ausentismo left join tipo_ausentismo ON tipo_ausentismo.TIPO_AUS = ausentismo.TIPO_AUS " & _
                                                        "WHERE (Reloj = '" & row("reloj") & "') AND (ausentismo.FECHA BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "') AND " & _
                                                        "(ausentismo.TIPO_AUS IN (SELECT TIPO_AUS FROM tipo_ausentismo AS tipo_ausentismo_1 " & _
                                                        "WHERE (AFECTA_SUA = 1) AND (TIPO_NATURALEZA <> 'I') AND (NOT(RELOJ LIKE 'X1')) AND (NOT(dbo.ausentismo.RELOJ LIKE 'X2')))) " & _
                                                        "ORDER BY Reloj, FECHA ASC", "TA")

                    For Each dRow As DataRow In dtDias.Rows
                        dtDatos.Rows.Add(dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dtPersona.Rows(0).Item("imss"), dtPersona.Rows(0).Item("dig_ver"), "11", FechaDMY(IIf(IsDBNull(dRow("fecha")), Nothing, dRow("fecha"))), "", "01",
                                             IIf(IIf(IsDBNull(dtPersona.Rows(0).Item("integrado")), 0, dtPersona.Rows(0).Item("integrado")) > _tope, _tope.ToString("N2"), IIf(IsDBNull(dtPersona.Rows(0).Item("integrado")), 0, dtPersona.Rows(0).Item("integrado"))), dtPersona.Rows(0).Item("nombres"), dtPersona.Rows(0).Item("Reloj"), dtPersona.Rows(0).Item("curp"), dtPersona.Rows(0).Item("cod_clase"),
                                             dtPersona.Rows(0).Item("cod_hora"), dRow("nombre"), dRow("tipo_aus"), "A", "AUSENTISMOS", FechaSQL(FechaInicial), FechaSQL(FechaFinal), "")
                    Next
                    _x += 1
                Next

                For Each row As DataRow In dtDatos.Select("tipo_mov = 11", "imss")
                    objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
                                    row("imss").ToString.Trim.PadRight(10) & _
                                    row("dig_ver").ToString.Trim.PadRight(1) & _
                                    row("tipo_mov").ToString.Trim.PadRight(2) & _
                                    row("fecha_mov").ToString.Trim.PadRight(8) & _
                                    row("num_incap").ToString.Trim.PadRight(8) & _
                                    row("dias_incap_Ausen").ToString.Trim.PadRight(2).PadLeft(2, "0") & _
                                    row("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(7, "0"))
                Next

            End If


            ' GuardaArchivo Then
            ' objSW.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
            ' End If
            objSW.Close()

            Console.WriteLine("")
            Console.WriteLine("File creation complete. Press <Enter> to close this window.")

            'ActivoTrabajando = False
            'frmTrabajando.Close()
            'frmTrabajando.Dispose()

        Catch ex As Exception
            MsgBox("Los archivos no pudieron ser exportados correctamente" & vbCrLf & ex.Message)
        End Try

        ActivoTrabajando = False
        frmTrabajando.Close()
        frmTrabajando.Dispose()

    End Sub

    '**************   Compensaciones
    Public Sub RptCompen(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim Columnas(10) As DataColumn
        Dim dtCompen As New DataTable
        Dim _Rlj, _Rlj1 As String
        Dim _CountReg As Integer = 1
        Dim _CountReg1 As Integer = 1
        Dim _x As Integer = 1
        Try

            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("Id", System.Type.GetType("System.Int32"))
            Columnas(1) = New DataColumn("RELOJ", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("NOMBRES", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("ALTA", System.Type.GetType("System.DateTime"))
            Columnas(4) = New DataColumn("FHA_INICIO", System.Type.GetType("System.DateTime"))
            Columnas(5) = New DataColumn("FHA_FINAL", System.Type.GetType("System.DateTime"))
            Columnas(6) = New DataColumn("SCOBER", System.Type.GetType("System.Double"))
            Columnas(7) = New DataColumn("TIPO_COMPEN", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("ESTATUS", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("FHA_SUSPEN", System.Type.GetType("System.DateTime"))
            Columnas(10) = New DataColumn("COMENTARIOS", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next

            dtCompen = sqlExecute("SELECT * FROM Compensaciones ORDER BY Reloj ASC", "Personal")
            _CountReg = dtInformacion.Rows.Count
            _CountReg1 = dtCompen.Rows.Count
            frmTrabajando.Show()
            For Each dRow As DataRow In dtCompen.Rows
                For Each dRow1 As DataRow In dtInformacion.Rows
                    frmTrabajando.lblAvance.Text = "Reloj: " & dRow("Reloj")
                    frmTrabajando.Text = "Compensación: " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
                    Application.DoEvents()
                    _Rlj = dRow("Reloj")
                    _Rlj1 = dRow1("Reloj")
                    If _Rlj = _Rlj1 Then
                        dtDatos.Rows.Add(dRow("Id"), dRow("RELOJ"), dRow("NOMBRES"), dRow("ALTA"), dRow("FHA_INICIO"), dRow("FHA_FINAL"), dRow("SCOBER"), dRow("TIPO_COMPEN"), dRow("ESTATUS"), dRow("FHA_SUSPEN"), dRow("COMENTARIOS"))
                    End If
                    _x += 1
                Next
            Next
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    ' FILTRAR POR CENTRO DE COSTOS Y NO AGREGAR FIRMA
    Public Sub ProgramacionVacacionesCC(ByVal dtInformacion As DataTable)
        Try

            Dim f_ini As Date = DateSerial(2016, 7, 18)
            Dim f_fin As Date = DateSerial(2016, 8, 7)

            Dim sfd As New SaveFileDialog
            sfd.AddExtension = True
            sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            sfd.FileName = "Vacaciones por CC"
            sfd.Filter = "Directorios|*.*"
            sfd.Title = "Se creará un archivo por centro de costos"
            sfd.AddExtension = False
            sfd.CheckFileExists = False
            sfd.CheckPathExists = False
            sfd.AddExtension = False

            If sfd.ShowDialog = DialogResult.OK Then

                Dim file_name As String = Path.GetDirectoryName(sfd.FileName)
                Dim folder As String = Path.GetFileNameWithoutExtension(sfd.FileName)

                'Obtener la lista de departamentos disponibles en dtInformacion
                Dim lista_deptos As New DataTable
                lista_deptos.Columns.Add("centro_costos")
                lista_deptos.Columns.Add("nombre_depto")
                lista_deptos.PrimaryKey = {lista_deptos.Columns("centro_costos")}

                For Each row As DataRow In dtInformacion.Select("cod_tipo = 'O'")
                    Dim drow As DataRow = lista_deptos.Rows.Find(row("centro_costos"))
                    If drow Is Nothing Then
                        lista_deptos.Rows.Add({row("centro_costos"), row("nombre_depto")})
                    End If
                Next

                ' Logo de la empresa
                Dim logo As Image
                Dim dtCias As DataTable = sqlExecute("select * from cias where cia_default = '1'")
                If Not IsDBNull(dtCias.Rows(0).Item("logo")) Then
                    Dim imageInBytes As Byte() = dtCias.Rows(0).Item("logo")
                    Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(imageInBytes, False)
                    Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream)
                    logo = image
                Else
                    logo = Nothing
                End If

                ' Crear un excel por cada departamento
                For Each row_deptos As DataRow In lista_deptos.Select("", "centro_costos")



                    Dim archivo As ExcelPackage = New ExcelPackage()
                    Dim wb As ExcelWorkbook = archivo.Workbook

                    Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(row_deptos("centro_costos"))

                    Dim x As Integer = 1
                    Dim y As Integer = 1

                    'Encabezados
                    hoja_excel.Cells(x, y).Value = "Programación de vacaciones"
                    hoja_excel.Cells(x, y).Style.Font.Bold = True
                    hoja_excel.Cells(x, y).Style.Font.Size = 10
                    x += 1

                    hoja_excel.Cells(x, y).Value = "Instrucciones: Colocar una V en los días a tomar como vacaciones y una P para los permisos de cierre sin goce de sueldo"
                    hoja_excel.Cells(x, y).Style.Font.Size = 9
                    x += 1

                    hoja_excel.Cells(x, y).Value = "Centro de costos:" & Space(1) & RTrim(row_deptos("centro_costos")) & " | " & RTrim(row_deptos("nombre_depto"))
                    hoja_excel.Cells(x, y).Style.Font.Size = 9
                    hoja_excel.Cells(x, y).Style.Font.Bold = True

                    x += 2
                    ''Obtener la lista de supervisores disponibles en el departamento actual
                    'Dim lista_super As New DataTable
                    'lista_super.Columns.Add("cod_super")
                    'lista_super.Columns.Add("nombre_super")
                    'lista_super.PrimaryKey = {lista_super.Columns("cod_super")}

                    'For Each row As DataRow In dtInformacion.Select("cod_tipo = 'O' and centro_costos = '" & RTrim(row_deptos("centro_costos")) & "'")
                    '    Try
                    '        Dim drow As DataRow = lista_super.Rows.Find(row("cod_super"))
                    '        If drow Is Nothing Then
                    '            lista_super.Rows.Add({row("cod_super"), row("nombre_super")})
                    '        End If
                    '    Catch ex As Exception

                    '    End Try
                    'Next

                    Dim columnas_division As New ArrayList
                    Dim columnas_fecha As New ArrayList

                    ''Informacion por supervisor
                    'For Each row_super As DataRow In lista_super.Rows

                    'Dim lista_horario As New DataTable
                    'lista_horario.Columns.Add("cod_hora")
                    'lista_horario.PrimaryKey = {lista_horario.Columns("cod_hora")}
                    'For Each row As DataRow In dtInformacion.Select("cod_tipo = 'O' and centro_costos = '" & RTrim(row_deptos("centro_costos")) & "'")
                    '    Try
                    '        Dim drow As DataRow = lista_horario.Rows.Find(row("cod_hora"))
                    '        If drow Is Nothing Then
                    '            lista_horario.Rows.Add({row("cod_hora")})
                    '        End If
                    '    Catch ex As Exception

                    '    End Try
                    'Next

                    ''Informacion por horario
                    'For Each row_horario As DataRow In lista_horario.Rows

                    hoja_excel.Cells(x, y).Value = "Reloj"
                    hoja_excel.Cells(x, y).Style.Font.Bold = True
                    hoja_excel.Cells(x, y).Style.Font.Size = 9

                    hoja_excel.Cells(x, y + 1).Value = "Nombre"
                    hoja_excel.Cells(x, y + 1).Style.Font.Bold = True
                    hoja_excel.Cells(x, y + 1).Style.Font.Size = 9

                    hoja_excel.Cells(x, y + 2).Value = "Depto"
                    hoja_excel.Cells(x, y + 2).Style.Font.Bold = True
                    hoja_excel.Cells(x, y + 2).Style.Font.Size = 9

                    hoja_excel.Cells(x, y + 3).Value = "Supervisor"
                    hoja_excel.Cells(x, y + 3).Style.Font.Bold = True
                    hoja_excel.Cells(x, y + 3).Style.Font.Size = 9

                    hoja_excel.Cells(x, y + 4).Value = "Turno"
                    hoja_excel.Cells(x, y + 4).Style.Font.Bold = True
                    hoja_excel.Cells(x, y + 4).Style.Font.Size = 9

                    hoja_excel.Cells(x, y + 5).Value = "Saldo vacaciones disponible"
                    hoja_excel.Cells(x, y + 5).Style.Font.Bold = True
                    hoja_excel.Cells(x, y + 5).Style.WrapText = True
                    hoja_excel.Cells(x, y + 5).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    hoja_excel.Cells(x, y + 5).Style.Font.Size = 9


                    Dim dtHorario As DataTable = sqlExecute("select * from dias where cod_hora = '01' and cod_comp  = '090'")

                    Dim i As Integer = 6
                    Dim f As Date = f_ini
                    Dim periodo As String = ""
                    While f <= f_fin
                        Try
                            Dim row_dia As DataRow = dtHorario.Select("cod_dia = '" & IIf(f.DayOfWeek = 0, 7, f.DayOfWeek) & "'")(0)

                            Dim p As String = ""
                            Dim dtPeriodo As DataTable = sqlExecute("select * from ta.dbo.periodos where periodo_especial <> '1' and '" & FechaSQL(f) & "' between fecha_ini and fecha_fin ")
                            If dtPeriodo.Rows.Count > 0 Then
                                p = dtPeriodo.Rows(0)("periodo")
                            End If

                            If p <> periodo Then
                                periodo = p
                                columnas_division.Add(y + i)
                                i += 1
                                hoja_excel.Cells(x - 1, y + i).Value = "Semana " & periodo
                                hoja_excel.Cells(x - 1, y + i).Style.Font.Bold = True
                                hoja_excel.Cells(x - 1, y + i).Style.Font.Size = 9
                            End If

                            If row_dia("descanso") = 0 Then
                                columnas_fecha.Add(y + i)

                                hoja_excel.Cells(x, y + i).Value = FechaSQL(f)
                                hoja_excel.Cells(x, y + i).Style.Font.Bold = True
                                hoja_excel.Cells(x, y + i).Style.TextRotation = 90
                                hoja_excel.Cells(x, y + i).Style.Font.Size = 9
                                i += 1
                            End If
                        Catch ex As Exception

                        End Try

                        f = f.AddDays(1)
                    End While

                    columnas_division.Add(y + i)
                    i += 1
                    hoja_excel.Cells(x, y + i).Value = "Firma del empleado"
                    hoja_excel.Cells(x, y + i).Style.Font.Bold = True
                    hoja_excel.Cells(x, y + i).Style.Font.Size = 9

                    'Informacion por empleado
                    Dim j As Integer = 0
                    For Each row_personal As DataRow In dtInformacion.Select("cod_tipo = 'O' and centro_costos = '" & RTrim(row_deptos("centro_costos")) & "'")
                        x += 1
                        hoja_excel.Cells(x, y).Value = row_personal("reloj")
                        hoja_excel.Cells(x, y).Style.Font.Size = 9

                        hoja_excel.Cells(x, y + 1).Value = row_personal("Nombres")
                        hoja_excel.Cells(x, y + 1).Style.Font.Size = 9

                        hoja_excel.Cells(x, y + 2).Value = row_personal("cod_depto")
                        hoja_excel.Cells(x, y + 2).Style.Font.Size = 9

                        hoja_excel.Cells(x, y + 3).Value = row_personal("nombre_super")
                        hoja_excel.Cells(x, y + 3).Style.Font.Size = 9

                        hoja_excel.Cells(x, y + 4).Value = row_personal("cod_turno")
                        hoja_excel.Cells(x, y + 4).Style.Font.Size = 9


                        Dim _r As String = row_personal("reloj")
                        Dim dtSaldo As DataTable = sqlExecute("select reloj, isnull(saldo, 0) as saldo from saldos_vac_reporte where reloj = '" & _r & "'")
                        If dtSaldo.Rows.Count > 0 Then
                            Dim saldo As Integer = Math.Floor(dtSaldo.Rows(0)("saldo"))
                            hoja_excel.Cells(x, y + 5).Value = saldo
                            hoja_excel.Cells(x, y + 5).Style.Font.Size = 9
                            hoja_excel.Cells(x, y + 5).Style.Font.Bold = True
                        Else
                            hoja_excel.Cells(x, y + 5).Value = 0
                            hoja_excel.Cells(x, y + 5).Style.Font.Size = 9
                            hoja_excel.Cells(x, y + 5).Style.Font.Bold = True
                        End If

                        j += 1
                        If j Mod 2 = 0 Then
                            hoja_excel.Row(x).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                            hoja_excel.Row(x).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                        End If

                    Next

                    x += 1
                    'Next



                    ''Firma del supervisor
                    'x += 3
                    'hoja_excel.Cells(x, y).Value = "Firma supervisor"
                    'hoja_excel.Cells(x, y).Style.Font.Bold = True
                    'hoja_excel.Cells(x, y).Style.Font.Size = 9
                    'x += 2

                    'hoja_excel.Cells(x, y).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                    'hoja_excel.Cells(x, y).Style.Border.Bottom.Color.SetColor(Color.Black)
                    'hoja_excel.Cells(x, y + 1).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                    'hoja_excel.Cells(x, y + 1).Style.Border.Bottom.Color.SetColor(Color.Black)
                    'x += 1

                    'hoja_excel.Cells(x, y).Value = RTrim(IIf(IsDBNull(row_super("nombre_super")), "", row_super("nombre_super")))
                    'hoja_excel.Cells(x, y).Style.Font.Size = 11

                    'x += 1
                    'Next

                    'Ajustes finales
                    hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()
                    hoja_excel.Column(1).Width = 6

                    hoja_excel.Column(2).Width = 35

                    hoja_excel.Column(3).Width = 10

                    For Each i_ As Integer In columnas_division
                        hoja_excel.Column(i_).Width = 1
                        hoja_excel.Column(i_).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Column(i_).Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                    Next

                    For Each i_ As Integer In columnas_fecha
                        hoja_excel.Column(i_).Width = 3
                    Next

                    hoja_excel.Cells(3, 5).Value = "Solicito permiso sin goce de sueldo para los dias abajo seleccionados"
                    hoja_excel.Cells(3, 5).Style.Font.Size = 9
                    hoja_excel.Cells(3, 5).Style.Font.Bold = True

                    'Siempre landscape
                    hoja_excel.PrinterSettings.Orientation = eOrientation.Landscape

                    'Crear directorio para guardar archivos
                    If (Not System.IO.Directory.Exists(file_name & "\" & folder.Trim & "\")) Then
                        System.IO.Directory.CreateDirectory(file_name & "\" & folder.Trim & "\")
                    End If

                    archivo.SaveAs(New System.IO.FileInfo(file_name & "\" & folder.Trim & "\Centro de costos_" & RTrim(row_deptos("centro_costos")) & ".xlsx"))

                Next

                'Abrir directorio
                If MessageBox.Show("El archivo o archivos fueron creados con exito", "Archivo creado", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
                    Try
                        System.Diagnostics.Process.Start(file_name & "\" & folder.Trim & "\")
                    Catch ex As Exception
                        MessageBox.Show("No fue posible abrir el archivo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub BajasGMM(ByVal dtInformacion As DataTable)
        Try

            If File.Exists(DireccionReportes & "bajasgmm.xlsx") Then

                Dim directorio As String = ""

                Dim flb As New FolderBrowserDialog
                flb.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop

                If flb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    directorio = flb.SelectedPath & "\"

                    Dim i As Integer = 0

                    For Each row As DataRow In dtInformacion.Select("baja is not null and cod_tipo = 'A'")

                        Dim plantilla As New ExcelPackage(New System.IO.FileInfo(DireccionReportes & "bajasgmm.xlsx"))
                        Dim wb As ExcelWorkbook = plantilla.Workbook
                        Dim hoja As ExcelWorksheet = wb.Worksheets(1)

                        hoja.Cells(8, 9).Value = FechaCortaLetra(Now).Replace("-", " ")
                        hoja.Cells(14, 9).Value = "Baja en póliza de GMM"
                        hoja.Cells(14, 8).Value = Date.Parse(row("baja")).ToString("dd/MM/yyyy")
                        hoja.Cells(14, 7).Value = "B"
                        hoja.Cells(14, 6).Value = "T"
                        'hoja.Cells(14, 5).Value = Date.Parse(row("fha_nac")).ToString("dd/MM/yyyy")
                        If IsDBNull(row("fha_nac")) Then
                            hoja.Cells(14, 5).Value = "N/A"
                        Else
                            hoja.Cells(14, 5).Value = Date.Parse(row("fha_nac")).ToString("dd/MM/yyyy")
                        End If
                        hoja.Cells(14, 4).Value = row("sexo")

                        hoja.Cells(14, 3).Value = RTrim(row("nombre")) & Space(1) & RTrim((row("apaterno"))) & Space(1) & RTrim(row("amaterno")) & " y dependientes"
                        'hoja.Cells(15, 3).Value = "Y dependientes"
                        hoja.Cells(14, 2).Value = "A"
                        hoja.Cells(14, 1).Value = row("reloj")

                        plantilla.SaveAs(New System.IO.FileInfo(directorio & "BajaGMM_" & row("reloj") & ".xlsx"))
                        i += 1
                    Next

                    MessageBox.Show(i & " Archivos generados", "Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    System.Diagnostics.Process.Start(directorio)

                End If
            Else
                MessageBox.Show("No se encontró el archivo base, contacte al administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub ProgramacionVacaciones(ByVal dtInformacion As DataTable)
        Try

            Dim f_ini As Date = DateSerial(2016, 7, 18)
            Dim f_fin As Date = DateSerial(2016, 8, 7)

            Dim sfd As New SaveFileDialog
            sfd.AddExtension = True
            sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            sfd.FileName = "Vacaciones"
            sfd.Filter = "Directorios|*.*"
            sfd.Title = "Se creará un archivo por departamento"
            sfd.AddExtension = False
            sfd.CheckFileExists = False
            sfd.CheckPathExists = False
            sfd.AddExtension = False

            If sfd.ShowDialog = DialogResult.OK Then

                Dim file_name As String = Path.GetDirectoryName(sfd.FileName)
                Dim folder As String = Path.GetFileNameWithoutExtension(sfd.FileName)

                'Obtener la lista de departamentos disponibles en dtInformacion
                Dim lista_deptos As New DataTable
                lista_deptos.Columns.Add("cod_depto")
                lista_deptos.Columns.Add("nombre_depto")
                lista_deptos.PrimaryKey = {lista_deptos.Columns("cod_depto")}

                For Each row As DataRow In dtInformacion.Select("cod_tipo = 'O'")
                    Dim drow As DataRow = lista_deptos.Rows.Find(row("cod_depto"))
                    If drow Is Nothing Then
                        lista_deptos.Rows.Add({row("cod_depto"), row("nombre_depto")})
                    End If
                Next

                ' Logo de la empresa
                Dim logo As Image
                Dim dtCias As DataTable = sqlExecute("select * from cias where cia_default = '1'")
                If Not IsDBNull(dtCias.Rows(0).Item("logo")) Then
                    Dim imageInBytes As Byte() = dtCias.Rows(0).Item("logo")
                    Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(imageInBytes, False)
                    Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream)
                    logo = image
                Else
                    logo = Nothing
                End If

                ' Crear un excel por cada departamento
                For Each row_deptos As DataRow In lista_deptos.Select("", "cod_depto")



                    Dim archivo As ExcelPackage = New ExcelPackage()
                    Dim wb As ExcelWorkbook = archivo.Workbook

                    Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(row_deptos("cod_depto"))

                    Dim x As Integer = 1
                    Dim y As Integer = 1

                    'Encabezados
                    hoja_excel.Cells(x, y).Value = "Programación de vacaciones"
                    hoja_excel.Cells(x, y).Style.Font.Bold = True
                    hoja_excel.Cells(x, y).Style.Font.Size = 10
                    x += 1

                    hoja_excel.Cells(x, y).Value = "Instrucciones: Colocar una V en los días a tomar como vacaciones y una P para los permisos de cierre sin goce de sueldo"
                    hoja_excel.Cells(x, y).Style.Font.Size = 9
                    x += 1

                    hoja_excel.Cells(x, y).Value = "Departamento:" & Space(1) & RTrim(row_deptos("cod_depto")) & " | " & RTrim(row_deptos("nombre_depto"))
                    hoja_excel.Cells(x, y).Style.Font.Size = 9
                    hoja_excel.Cells(x, y).Style.Font.Bold = True

                    'Obtener la lista de supervisores disponibles en el departamento actual
                    Dim lista_super As New DataTable
                    lista_super.Columns.Add("cod_super")
                    lista_super.Columns.Add("nombre_super")
                    lista_super.PrimaryKey = {lista_super.Columns("cod_super")}

                    For Each row As DataRow In dtInformacion.Select("cod_tipo = 'O' and cod_depto = '" & RTrim(row_deptos("cod_depto")) & "'")
                        Try
                            Dim drow As DataRow = lista_super.Rows.Find(row("cod_super"))
                            If drow Is Nothing Then
                                lista_super.Rows.Add({row("cod_super"), row("nombre_super")})
                            End If
                        Catch ex As Exception

                        End Try
                    Next

                    Dim columnas_division As New ArrayList
                    Dim columnas_fecha As New ArrayList

                    'Informacion por supervisor
                    For Each row_super As DataRow In lista_super.Rows

                        Dim lista_horario As New DataTable
                        lista_horario.Columns.Add("cod_hora")
                        lista_horario.PrimaryKey = {lista_horario.Columns("cod_hora")}
                        For Each row As DataRow In dtInformacion.Select("cod_tipo = 'O' and cod_depto = '" & RTrim(row_deptos("cod_depto")) & "' and cod_super = '" & row_super("cod_super") & "'")
                            Try
                                Dim drow As DataRow = lista_horario.Rows.Find(row("cod_hora"))
                                If drow Is Nothing Then
                                    lista_horario.Rows.Add({row("cod_hora")})
                                End If
                            Catch ex As Exception

                            End Try
                        Next

                        'Informacion por horario
                        For Each row_horario As DataRow In lista_horario.Rows

                            x += 1
                            hoja_excel.Cells(x, y).Value = "Horario: " & row_horario("COD_HORA")
                            x += 1

                            hoja_excel.Cells(x, y).Value = "Reloj"
                            hoja_excel.Cells(x, y).Style.Font.Bold = True
                            hoja_excel.Cells(x, y).Style.Font.Size = 9

                            hoja_excel.Cells(x, y + 1).Value = "Nombre"
                            hoja_excel.Cells(x, y + 1).Style.Font.Bold = True
                            hoja_excel.Cells(x, y + 1).Style.Font.Size = 9

                            hoja_excel.Cells(x, y + 2).Value = "Saldo vacaciones disponible"
                            hoja_excel.Cells(x, y + 2).Style.Font.Bold = True
                            hoja_excel.Cells(x, y + 2).Style.WrapText = True
                            hoja_excel.Cells(x, y + 2).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                            hoja_excel.Cells(x, y + 2).Style.Font.Size = 9


                            Dim dtHorario As DataTable = sqlExecute("select * from dias where cod_hora = '" & row_horario("cod_hora") & "' and cod_comp  = '090'")

                            Dim i As Integer = 3
                            Dim f As Date = f_ini
                            Dim periodo As String = ""
                            While f <= f_fin
                                Try
                                    Dim row_dia As DataRow = dtHorario.Select("cod_dia = '" & IIf(f.DayOfWeek = 0, 7, f.DayOfWeek) & "'")(0)

                                    Dim p As String = ""
                                    Dim dtPeriodo As DataTable = sqlExecute("select * from ta.dbo.periodos where periodo_especial <> '1' and '" & FechaSQL(f) & "' between fecha_ini and fecha_fin ")
                                    If dtPeriodo.Rows.Count > 0 Then
                                        p = dtPeriodo.Rows(0)("periodo")
                                    End If

                                    If p <> periodo Then
                                        periodo = p
                                        columnas_division.Add(y + i)
                                        i += 1
                                        hoja_excel.Cells(x - 1, y + i).Value = "Semana " & periodo
                                        hoja_excel.Cells(x - 1, y + i).Style.Font.Bold = True
                                        hoja_excel.Cells(x - 1, y + i).Style.Font.Size = 9
                                    End If

                                    If row_dia("descanso") = 0 Then
                                        columnas_fecha.Add(y + i)

                                        hoja_excel.Cells(x, y + i).Value = FechaSQL(f)
                                        hoja_excel.Cells(x, y + i).Style.Font.Bold = True
                                        hoja_excel.Cells(x, y + i).Style.TextRotation = 90
                                        hoja_excel.Cells(x, y + i).Style.Font.Size = 9
                                        i += 1
                                    End If
                                Catch ex As Exception

                                End Try

                                f = f.AddDays(1)
                            End While

                            columnas_division.Add(y + i)
                            i += 1
                            hoja_excel.Cells(x, y + i).Value = "Firma del empleado"
                            hoja_excel.Cells(x, y + i).Style.Font.Bold = True
                            hoja_excel.Cells(x, y + i).Style.Font.Size = 9

                            'Informacion por empleado
                            Dim j As Integer = 0
                            For Each row_personal As DataRow In dtInformacion.Select("cod_hora = '" & row_horario("cod_hora") & "' and cod_tipo = 'O' and cod_depto = '" & RTrim(row_deptos("cod_depto")) & "' and cod_super = '" & row_super("cod_super") & "'")
                                x += 1
                                hoja_excel.Cells(x, y).Value = row_personal("reloj")
                                hoja_excel.Cells(x, y).Style.Font.Size = 9

                                hoja_excel.Cells(x, y + 1).Value = row_personal("Nombres")
                                hoja_excel.Cells(x, y + 1).Style.Font.Size = 9

                                Dim _r As String = row_personal("reloj")
                                Dim dtSaldo As DataTable = sqlExecute("select reloj, isnull(saldo, 0) as saldo from saldos_vac_reporte where reloj = '" & _r & "'")
                                If dtSaldo.Rows.Count > 0 Then
                                    Dim saldo As Integer = Math.Floor(dtSaldo.Rows(0)("saldo"))
                                    hoja_excel.Cells(x, y + 2).Value = saldo
                                    hoja_excel.Cells(x, y + 2).Style.Font.Size = 9
                                    hoja_excel.Cells(x, y + 2).Style.Font.Bold = True
                                Else
                                    hoja_excel.Cells(x, y + 2).Value = 0
                                    hoja_excel.Cells(x, y + 2).Style.Font.Size = 9
                                    hoja_excel.Cells(x, y + 2).Style.Font.Bold = True
                                End If

                                j += 1
                                If j Mod 2 = 0 Then
                                    hoja_excel.Row(x).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    hoja_excel.Row(x).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
                                End If

                            Next

                            x += 1
                        Next



                        'Firma del supervisor
                        x += 3
                        hoja_excel.Cells(x, y).Value = "Firma supervisor"
                        hoja_excel.Cells(x, y).Style.Font.Bold = True
                        hoja_excel.Cells(x, y).Style.Font.Size = 9
                        x += 2

                        hoja_excel.Cells(x, y).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                        hoja_excel.Cells(x, y).Style.Border.Bottom.Color.SetColor(Color.Black)
                        hoja_excel.Cells(x, y + 1).Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                        hoja_excel.Cells(x, y + 1).Style.Border.Bottom.Color.SetColor(Color.Black)
                        x += 1

                        hoja_excel.Cells(x, y).Value = RTrim(IIf(IsDBNull(row_super("nombre_super")), "", row_super("nombre_super")))
                        hoja_excel.Cells(x, y).Style.Font.Size = 11

                        x += 1
                    Next

                    'Ajustes finales
                    hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()
                    hoja_excel.Column(1).Width = 6

                    hoja_excel.Column(2).Width = 35

                    hoja_excel.Column(3).Width = 10

                    For Each i As Integer In columnas_division
                        hoja_excel.Column(i).Width = 1
                        hoja_excel.Column(i).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        hoja_excel.Column(i).Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                    Next

                    For Each i As Integer In columnas_fecha
                        hoja_excel.Column(i).Width = 3
                    Next

                    hoja_excel.Cells(3, 5).Value = "Solicito permiso sin goce de sueldo para los dias abajo seleccionados"
                    hoja_excel.Cells(3, 5).Style.Font.Size = 9
                    hoja_excel.Cells(3, 5).Style.Font.Bold = True

                    'Siempre landscape
                    hoja_excel.PrinterSettings.Orientation = eOrientation.Landscape

                    'Crear directorio para guardar archivos
                    If (Not System.IO.Directory.Exists(file_name & "\" & folder.Trim & "\")) Then
                        System.IO.Directory.CreateDirectory(file_name & "\" & folder.Trim & "\")
                    End If

                    archivo.SaveAs(New System.IO.FileInfo(file_name & "\" & folder.Trim & "\Departamento_" & RTrim(row_deptos("COD_DEPTO")) & ".xlsx"))

                Next

                'Abrir directorio
                If MessageBox.Show("El archivo o archivos fueron creados con exito", "Archivo creado", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
                    Try
                        System.Diagnostics.Process.Start(file_name & "\" & folder.Trim & "\")
                    Catch ex As Exception
                        MessageBox.Show("No fue posible abrir el archivo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Function CreateSheet(p As ExcelPackage, sheetName As String) As ExcelWorksheet
        p.Workbook.Worksheets.Add(sheetName)
        Dim ws As ExcelWorksheet = p.Workbook.Worksheets(1)
        ws.Name = sheetName ' //Setting Sheet's name
        ws.Cells.Style.Font.Size = 10 ' //Default font size for whole sheet
        ws.Cells.Style.Font.Name = "Calibri" ' //Default Font name for whole sheet
        Return ws
    End Function



    Dim dtTemp As New DataTable

    Public Function AddMyValues(ByVal Value1 As Double, ByVal Value2 As Double)
        Dim Result As Double
        Result = Value1 * Value2
        Return Result
    End Function
    Public Sub DetallePersonalConHijos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        ActivoTrabajando = True
        frmTrabajando.Show()

        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_comp", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_planta", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
        dtDatos.Columns.Add("depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("alta", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("parentesco", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_hijo", Type.GetType("System.String"))
        dtDatos.Columns.Add("fecha_nac", Type.GetType("System.String"))
        dtDatos.Columns.Add("anos", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("meses", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sexo", Type.GetType("System.String"))
        dtDatos.Columns.Add("CENTRO_COSTOS", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_costos", Type.GetType("System.String"))


        Try
            For Each dRow As DataRow In dtInformacion.Rows
                frmTrabajando.lblAvance.Text = dRow("reloj")
                Application.DoEvents()

                Dim dtHijos As DataTable = sqlExecute("select familiares.*, familia.nombre as parentesco from familiares " &
                                                      "left join familia on familiares.COD_FAMILIA = familia.COD_FAMILIA " &
                                                      "where reloj = '" & dRow("reloj") & "' -- and familiares.cod_familia in ('07','08','14')")
                For Each hrow As DataRow In dtHijos.Rows
                    dRow("cod_comp") = IIf(IsDBNull(dRow("cod_comp")), "", dRow("cod_comp"))
                    dRow("cod_planta") = IIf(IsDBNull(dRow("cod_planta")), "", dRow("cod_planta"))
                    dRow("nombre_super") = IIf(IsDBNull(dRow("nombre_super")), "", dRow("nombre_super"))
                    dRow("nombre_area") = IIf(IsDBNull(dRow("nombre_area")), "", dRow("nombre_area"))
                    dRow("cod_depto") = IIf(IsDBNull(dRow("cod_depto")), "", dRow("cod_depto"))
                    dRow("alta") = IIf(IsDBNull(dRow("alta")), "", dRow("alta"))
                    dRow("sexo") = IIf(IsDBNull(dRow("sexo")), "", dRow("sexo"))
                    dRow("CENTRO_COSTOS") = IIf(IsDBNull(dRow("CENTRO_COSTOS")), "", dRow("CENTRO_COSTOS"))
                    dRow("nombre_costos") = IIf(IsDBNull(dRow("nombre_costos")), "", dRow("nombre_costos"))



                    hrow("parentesco") = IIf(IsDBNull(hrow("parentesco")), "", hrow("parentesco"))
                    'hrow("apaterno") = IIf(IsDBNull(hrow("apaterno")), "", hrow("apaterno"))
                    'hrow("amaterno") = IIf(IsDBNull(hrow("amaterno")), "", hrow("amaterno"))
                    hrow("nombres") = IIf(IsDBNull(hrow("nombres")), "", hrow("nombres"))
                    hrow("nombre") = IIf(IsDBNull(hrow("nombre")), "", hrow("nombre"))
                    Dim fecha = IIf(IsDBNull(hrow("fecha_nac")), 0, 1)

                    If fecha = 1 Then
                        Dim fechanac As Date = CDate(hrow("fecha_nac"))
                        Dim fechaact As Date = CDate(DateTime.Now.ToString("yyyy/MM/dd"))

                        Dim anos As Integer = CInt((fechaact.Year - fechanac.Year))
                        Dim meses As Integer = CInt((fechaact.Month - fechanac.Month))

                        If meses < 0 Then
                            anos = anos - 1
                            meses = meses - (meses * 2)
                        End If
                        dtDatos.Rows.Add({dRow("reloj"), _
                                  Trim(dRow("nombres")), _
                                  dRow("cod_comp"), _
                                  dRow("cod_planta"), _
                                  dRow("cod_turno"), _
                                  dRow("nombre_super"), _
                                  dRow("nombre_area"), _
                                  dRow("cod_depto"), _
                                  dRow("alta"), _
                                  hrow("parentesco"), _
                                  hrow("nombre"), _
                                  hrow("fecha_nac"), _
                                  anos, _
                                  meses, _
                                  dRow("sexo"), _
                                  dRow("CENTRO_COSTOS"), _
                                 dRow("nombre_costos")})


                        'Trim(hrow("apaterno")) & " " & Trim(hrow("amaterno")) & " " & Trim(hrow("nombres")), _

                    ElseIf fecha = 0 Then
                        Dim anos As Integer = 0
                        Dim meses As Integer = 0
                        dtDatos.Rows.Add({dRow("reloj"), _
                                  Trim(dRow("nombres")), _
                                  dRow("cod_comp"), _
                                  dRow("cod_planta"), _
                                  dRow("cod_turno"), _
                                  dRow("nombre_super"), _
                                  dRow("nombre_area"), _
                                  dRow("cod_depto"), _
                                  dRow("alta"), _
                                  hrow("parentesco"), _
                                  hrow("nombre"), _
                                  hrow("fecha_nac"), _
                                   anos, _
                                  meses, _
                                  dRow("sexo"), _
                                  dRow("CENTRO_COSTOS"), _
                                 dRow("nombre_costos")})

                        'Trim(hrow("apaterno")) & " " & Trim(hrow("amaterno")) & " " & Trim(hrow("nombres")), _
                    End If
                Next
            Next
            Dim sfd As New SaveFileDialog

            Try
                sfd.DefaultExt = ".xlsx"
                sfd.FileName = "detalle_personal_hijos " & FechaSQL(Date.Now) & ".xlsx"
                sfd.OverwritePrompt = True
                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim archivo As ExcelPackage = New ExcelPackage()
                    Dim wb As ExcelWorkbook = archivo.Workbook
                    ExcelDetallesHijos("Detalles", wb, dtDatos)
                    'ExportaExcel(dtDatos, sfd.FileName, "reloj", "Reporte Detalle Personal con hijos")
                    archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
                End If

            Catch ex As Exception

            End Try


        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try

        ActivoTrabajando = False
        frmTrabajando.Close()

    End Sub
    Public Sub ExcelDetallesHijos(nombre_hoja As String, ByRef wb As ExcelWorkbook, dtDatos As DataTable)
        Dim x As Integer = 1
        Dim y As Integer = 2
        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

        hoja_excel.Cells(1, 1).Value = "Reporte detalles personal con hijos"
        hoja_excel.Cells(1, 1).Style.Font.Bold = True

        hoja_excel.Cells(y, x).Value = "RELOJ"
        hoja_excel.Cells(y, x).Style.Font.Bold = True
        hoja_excel.Cells(y, x).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 1).Value = "NOMBRE"
        hoja_excel.Cells(y, x + 1).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 1).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 1).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 2).Value = "COD_COMP"
        hoja_excel.Cells(y, x + 2).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 2).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 2).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 2).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 3).Value = "COD_PLANTA"
        hoja_excel.Cells(y, x + 3).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 3).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 3).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 4).Value = "COD_TURNO"
        hoja_excel.Cells(y, x + 4).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 4).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 4).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 4).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 5).Value = "SUPERVISOR"
        hoja_excel.Cells(y, x + 5).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 5).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 5).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 5).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 6).Value = "AREA"
        hoja_excel.Cells(y, x + 6).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 6).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 6).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 6).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 7).Value = "DEPTO"
        hoja_excel.Cells(y, x + 7).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 7).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 7).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 7).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 8).Value = "ALTA"
        hoja_excel.Cells(y, x + 8).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 8).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 8).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 8).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 9).Value = "PARENTESCO"
        hoja_excel.Cells(y, x + 9).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 9).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 9).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 9).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 10).Value = "NOMBRE HIJO/A"
        hoja_excel.Cells(y, x + 10).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 10).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 10).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 10).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 11).Value = "FECHA_NAC"
        hoja_excel.Cells(y, x + 11).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 11).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 11).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 11).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 12).Value = "AÑOS"
        hoja_excel.Cells(y, x + 12).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 12).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 12).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 12).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 13).Value = "MESES"
        hoja_excel.Cells(y, x + 13).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 13).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 13).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 13).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 14).Value = "SEXO"
        hoja_excel.Cells(y, x + 14).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 14).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 14).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 14).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)

        hoja_excel.Cells(y, x + 15).Value = "CENTRO COSTO"
        hoja_excel.Cells(y, x + 15).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 15).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(y, x + 15).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(y, x + 15).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)


        Dim i As Integer = 1
        For Each dRow As DataRow In dtDatos.Rows
            hoja_excel.Cells(y + i, x).Value = dRow("reloj")
            hoja_excel.Cells(y + i, x + 1).Value = dRow("nombres")
            hoja_excel.Cells(y + i, x + 2).Value = dRow("cod_comp")
            hoja_excel.Cells(y + i, x + 3).Value = dRow("cod_planta")
            hoja_excel.Cells(y + i, x + 4).Value = dRow("cod_turno")
            hoja_excel.Cells(y + i, x + 5).Value = dRow("nombre_super")
            hoja_excel.Cells(y + i, x + 6).Value = dRow("nombre_area")
            hoja_excel.Cells(y + i, x + 7).Value = dRow("depto")
            hoja_excel.Cells(y + i, x + 8).Value = FechaSQL(dRow("alta"))
            hoja_excel.Cells(y + i, x + 9).Value = dRow("parentesco")
            hoja_excel.Cells(y + i, x + 10).Value = dRow("nombre_hijo")
            hoja_excel.Cells(y + i, x + 11).Value = dRow("fecha_nac")
            hoja_excel.Cells(y + i, x + 12).Value = dRow("anos")
            hoja_excel.Cells(y + i, x + 13).Value = dRow("meses")
            hoja_excel.Cells(y + i, x + 14).Value = dRow("sexo")
            hoja_excel.Cells(y + i, x + 15).Value = dRow("CENTRO_COSTOS")

            i = i + 1
        Next

        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

    End Sub

    Public Sub PersonalConHijos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        ActivoTrabajando = True
        frmTrabajando.Show()


        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_comp", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_planta", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("area", Type.GetType("System.String"))
        dtDatos.Columns.Add("depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("alta", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("sexo", Type.GetType("System.String"))
        dtDatos.Columns.Add("t_hijos", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("hijos_15", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("hijos_sin", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("t_familiares", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("filtro_edad", Type.GetType("System.String"))
        dtDatos.Columns.Add("CENTRO_COSTOS", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
        Try
            For Each row As DataRow In dtInformacion.Rows

                frmTrabajando.lblAvance.Text = row("reloj")
                Application.DoEvents()

                Dim dtHijos As DataTable = sqlExecute("select * from familiares where reloj = '" & row("reloj") & "' and cod_familia in ('07','08','14')")
                Dim dtFam As DataTable = sqlExecute("select * from familiares where reloj = '" & row("reloj") & "'")
                Dim dtHijos15 As New DataTable
                Dim dtHijos0 As New DataTable
                dtHijos15.Columns.Add("menor", Type.GetType("System.Int32"))
                dtHijos0.Columns.Add("sin_edad", Type.GetType("System.Int32"))
                For Each hrow As DataRow In dtHijos.Rows
                    Dim fecha_nac = IIf(IsDBNull(hrow("fecha_nac")), 0, 1)

                    If fecha_nac <> 0 Then
                        'fecha_nac = CInt(Edad(hrow("fecha_nac"), DateTime.Now.ToString("yyyy/MM/dd")))
                        Dim fechanac As Date = CDate(hrow("fecha_nac"))
                        Dim fechaact As Date = CDate(DateTime.Now.ToString("yyyy/MM/dd"))

                        Dim anos As Integer = CInt((fechaact.Year - fechanac.Year))
                        Dim meses As Integer = CInt((fechaact.Month - fechanac.Month))

                        If meses < 0 Then
                            anos = anos - 1
                        End If
                        If anos <= EdadHijos Then
                            dtHijos15.Rows.Add({anos})
                        End If
                    ElseIf fecha_nac = 0 Then
                        dtHijos0.Rows.Add({fecha_nac})
                    End If

                Next

                If dtHijos.Rows.Count > 0 Then
                    Dim drow As DataRow = dtDatos.NewRow

                    drow("reloj") = row("reloj")
                    drow("nombres") = Trim(row("nombres"))
                    drow("cod_comp") = row("cod_comp")
                    drow("cod_planta") = row("cod_planta")
                    drow("cod_turno") = row("cod_turno")
                    drow("nombre_super") = row("nombre_super")
                    drow("area") = row("cod_area")
                    drow("depto") = row("cod_depto")
                    drow("alta") = row("alta")
                    drow("sexo") = row("sexo")
                    drow("t_hijos") = dtHijos.Rows.Count
                    drow("hijos_15") = dtHijos15.Rows.Count
                    drow("hijos_sin") = dtHijos0.Rows.Count
                    drow("t_familiares") = dtFam.Rows.Count
                    drow("filtro_edad") = CStr(EdadHijos)
                    drow("CENTRO_COSTOS") = row("CENTRO_COSTOS")
                    drow("nombre_area") = row("nombre_area")
                    dtDatos.Rows.Add(drow)

                End If
            Next
        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
        End Try

        ActivoTrabajando = False
        frmTrabajando.Close()

    End Sub

    'BRP ABRAHAM
    Friend campo_ultimo_movimiento As String
    Friend solo_promociones_reporte As Boolean
    Public Sub UltimoMovimiento(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            Dim campo As String = "cod_puesto"
            Dim nombre_campo As String = "Puesto"

            If frmElegirCampo.ShowDialog() = DialogResult.OK Then

                campo = campo_ultimo_movimiento
                Select Case campo
                    Case "cod_puesto"
                        nombre_campo = "Puesto"
                    Case "cod_clase"
                        nombre_campo = "Clasificación"
                    Case "cod_planta"
                        nombre_campo = "Planta"
                    Case "cod_depto"
                        nombre_campo = "Departamento"
                    Case "cod_super"
                        nombre_campo = "Supervisor"
                    Case "cod_turno"
                        nombre_campo = "Turno"
                    Case "cod_hora"
                        nombre_campo = "Horario"
                    Case "cod_super"
                        nombre_campo = "Supervisor"
                    Case "promocion"
                        nombre_campo = "Promoción"
                    Case "nivel"
                        nombre_campo = "Nivel"
                    Case Else
                        campo = "cod_puesto"
                        nombre_campo = "Puesto"
                End Select
            End If

            dtDatos = dtInformacion.Copy
            dtDatos.Columns.Add("campo_filtro", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_campo", Type.GetType("System.String"))
            dtDatos.Columns.Add("valor_ultimo_cambio", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_ultimo_cambio", Type.GetType("System.DateTime"))

            ActivoTrabajando = True
            frmTrabajando.Show()

            For Each row As DataRow In dtDatos.Rows
                frmTrabajando.lblAvance.Text = row("reloj")
                Application.DoEvents()

                row("campo_filtro") = campo
                row("nombre_campo") = nombre_campo

                If campo = "promocion" Then
                    Dim dtUltimoCambio As DataTable = sqlExecute("select * from mod_sal where reloj = '" & row("reloj") & "' and cod_tipo_mod = 'PR' and cast(fecha as date) <= '" & FechaSQL(Now) & "' order by fecha desc")
                    If dtUltimoCambio.Rows.Count > 0 Then
                        row("valor_ultimo_cambio") = FechaSQL(dtUltimoCambio.Rows(0)("fecha"))
                        row("fecha_ultimo_cambio") = dtUltimoCambio.Rows(0)("fecha")

                    Else
                        row("valor_ultimo_cambio") = ""
                        row("fecha_ultimo_cambio") = DateTime.MinValue
                    End If
                Else
                    Dim dtUltimoCambio As DataTable = sqlExecute("select * from bitacora_personal where reloj = '" & row("reloj") & "' and campo = '" & campo & "' and cast(fecha as date) <= '" & FechaSQL(Now) & "' order by fecha desc")
                    If dtUltimoCambio.Rows.Count > 0 Then
                        row("valor_ultimo_cambio") = dtUltimoCambio.Rows(0)("ValorNuevo")
                        row("fecha_ultimo_cambio") = dtUltimoCambio.Rows(0)("fecha")

                    Else
                        row("valor_ultimo_cambio") = row(campo)
                        row("fecha_ultimo_cambio") = row("alta")

                    End If
                End If

            Next

            If campo = "promocion" And solo_promociones_reporte Then
                dtDatos = dtDatos.Select("valor_ultimo_cambio <> ''").CopyToDataTable
            End If

            ActivoTrabajando = False
            frmTrabajando.Close()

        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
        End Try
    End Sub
    Public Sub AccidenteDeTrabajo(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            dtDatos = New DataTable

            dtDatos.Columns.Add("RELOJ", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOMBRES", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_puesto", Type.GetType("System.String"))
            dtDatos.Columns.Add("COD_AREA", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_turno", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_planta", Type.GetType("System.String"))
            dtDatos.Columns.Add("edad", Type.GetType("System.String"))
            dtDatos.Columns.Add("escolaridad", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_civil", Type.GetType("System.String"))
            dtDatos.Columns.Add("dependientes", Type.GetType("System.Int32")) 'faltante
            dtDatos.Columns.Add("DIRECCION", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_colonia", Type.GetType("System.String"))
            dtDatos.Columns.Add("c_postal", Type.GetType("System.String"))
            dtDatos.Columns.Add("RFC", Type.GetType("System.String"))
            dtDatos.Columns.Add("CURP", Type.GetType("System.String"))
            dtDatos.Columns.Add("IMSS", Type.GetType("System.String"))
            dtDatos.Columns.Add("DIG_VER", Type.GetType("System.String"))
            dtDatos.Columns.Add("Antiguedad_Empresa", Type.GetType("System.String"))
            dtDatos.Columns.Add("Antiguedad_Puesto", Type.GetType("System.String")) ' ultimo ya mejorado
            dtDatos.Columns.Add("SACTUAL", Type.GetType("System.String"))
            dtDatos.Columns.Add("INTEGRADO", Type.GetType("System.String"))
            dtDatos.Columns.Add("TELEFONO", Type.GetType("System.String"))

            For Each row As DataRow In dtInformacion.Rows
                Dim drow As DataRow = dtDatos.NewRow
                drow("RELOJ") = row("RELOJ")
                drow("NOMBRES") = row("NOMBRES")
                drow("nombre_puesto") = row("nombre_puesto")
                drow("COD_AREA") = row("COD_AREA")
                drow("nombre_puesto") = row("nombre_puesto")
                drow("nombre_area") = row("nombre_area")
                drow("nombre_super") = row("nombre_super")
                drow("nombre_turno") = row("nombre_turno")
                drow("nombre_planta") = row("nombre_planta")
                drow("edad") = row("edad")
                drow("escolaridad") = row("escolaridad")
                drow("nombre_civil") = row("nombre_civil")
                drow("DIRECCION") = row("DIRECCION")
                drow("nombre_colonia") = row("nombre_colonia")
                drow("c_postal") = row("c_postal")
                drow("RFC") = row("RFC")
                drow("CURP") = row("CURP")
                drow("IMSS") = row("IMSS")
                drow("DIG_VER") = row("DIG_VER")
                drow("SACTUAL") = row("SACTUAL")
                drow("INTEGRADO") = row("INTEGRADO")
                drow("TELEFONO") = row("TELEFONO")

                dtDatos.Rows.Add(drow)
            Next

            For Each row As DataRow In dtDatos.Rows
                Dim _reloj As String = row("reloj")
                Dim Dependientes As DataTable = sqlExecute(" SELECT count(idfld) as cuantos from familiares where reloj = '" & _reloj & "' and COD_FAMILIA in ('05','06','07','08','11','12','13','14') group by reloj ", "PERSONAL")

                If Dependientes.Rows.Count > 0 Then
                    Dim Depen As Int32 = Dependientes.Rows(0)("cuantos")
                    row("Dependientes") = Depen

                Else
                    Dim Depen As Int32 = 0
                    row("Dependientes") = Depen
                End If

                '-------------------------------------------------------------
                Dim AntiguedadEmp As DataTable = sqlExecute(" SELECT alta from PersonalVW where reloj = '" & _reloj & "'")

                If AntiguedadEmp.Rows.Count > 0 Then
                    Dim antigued As Date = AntiguedadEmp.Rows(0)("alta")
                    Dim actuali As Date = Date.Now
                    Dim antiguedadtotal As String

                    antiguedadtotal = AntiguedadExacta(antigued.Date, actuali.Date)

                    row("Antiguedad_Empresa") = antiguedadtotal
                End If

                '-------------------------------------------------------------

                Dim Antiguedad_Puesto As DataTable = sqlExecute(" SELECT fecha  from bitacora_personal where campo = 'cod_puesto' and reloj = '" & _reloj & "' order by fecha desc")

                If Antiguedad_Puesto.Rows.Count > 0 Then
                    Dim antig As Date = Antiguedad_Puesto.Rows(0)("fecha")
                    Dim actual As Date = Date.Now
                    Dim antigalta As Date = AntiguedadEmp.Rows(0)("alta")
                    Dim antigpuest As String

                    If antig < antigalta Then

                        antigpuest = AntiguedadExacta(antigalta.Date, actual.Date)
                    Else

                        antigpuest = AntiguedadExacta(antig.Date, actual.Date)
                    End If

                    row("Antiguedad_Puesto") = antigpuest
                Else
                    Dim actual As Date = Date.Now
                    Dim antigalta As Date = AntiguedadEmp.Rows(0)("alta")
                    Dim antigpuest As String
                    antigpuest = AntiguedadExacta(antigalta.Date, actual.Date)
                    row("Antiguedad_Puesto") = antigpuest
                End If


            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub ReporteCafeteriaQTO(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable) '--
        Try
            Dim frm_fechas As New frmRangoFechas
            frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
            frm_fechas.frmRangoFechas_fecha_fin = Now
            frm_fechas.ShowDialog()

            frmTrabajando.Show()

            Dim fecha_ini As Date = FechaInicial

            Dim fecha_fin As Date = FechaFinal

            Try
                dtDatos = New DataTable
                dtDatos.Columns.Add("reloj")
                dtDatos.Columns.Add("nombres")
                dtDatos.Columns.Add("horario")
                dtDatos.Columns.Add("horario_orden")
                dtDatos.Columns.Add("cod_tipo")
                dtDatos.Columns.Add("cod_depto")
                dtDatos.Columns.Add("fecha")
                dtDatos.Columns.Add("hora")
                dtDatos.Columns.Add("nombre_servicio")
                dtDatos.Columns.Add("subsidio")
                dtDatos.Columns.Add("id")

                Dim f As Date = FechaInicial.ToShortDateString
                For Each dRow As DataRow In dtInformacion.Rows

                    frmTrabajando.lblAvance.Text = "Cargando Información"
                    Application.DoEvents()

                    f = FechaInicial

                    While f <= fecha_fin

                        Dim dtcafe As DataTable = sqlExecute("select hrs_brt_cafeteria.reloj, hrs_brt_cafeteria.fecha, hrs_brt_cafeteria.hora," & _
                                                             "hrs_brt_cafeteria.horario, hrs_brt_cafeteria.subsidio, hrs_brt_cafeteria.id_registro," & _
                                                             "horarios_cafeteria.nombre, horarios_cafeteria.orden " & _
                                                             "from hrs_brt_cafeteria " & _
                                                             "left join horarios_cafeteria on horarios_cafeteria.cod_hora_cafe = hrs_brt_cafeteria.horario " & _
                                                             "where reloj = '" & dRow("reloj") & "' and fecha = '" & FechaSQL(f) & "'", "TA")

                        dRow("reloj") = IIf(IsDBNull(dRow("reloj")), "", dRow("reloj"))
                        dRow("nombres") = IIf(IsDBNull(dRow("nombres")), "", dRow("nombres"))
                        dRow("cod_tipo") = IIf(IsDBNull(dRow("cod_tipo")), "", dRow("cod_tipo"))
                        dRow("cod_depto") = IIf(IsDBNull(dRow("cod_depto")), "", dRow("cod_depto"))
                        dRow("cod_hora") = IIf(IsDBNull(dRow("cod_hora")), "", dRow("cod_hora"))

                        For Each hrow As DataRow In dtcafe.Rows

                            hrow("horario") = IIf(IsDBNull(hrow("horario")), "", hrow("horario"))
                            hrow("fecha") = IIf(IsDBNull(hrow("fecha")), "", hrow("fecha"))
                            hrow("hora") = IIf(IsDBNull(hrow("hora")), "", hrow("hora"))
                            hrow("subsidio") = IIf(IsDBNull(hrow("subsidio")), "", hrow("subsidio"))
                            hrow("orden") = IIf(IsDBNull(hrow("orden")), 0, hrow("orden"))
                            hrow("nombre") = IIf(IsDBNull(hrow("nombre")), "5. Fuera de Horario", hrow("nombre"))

                            Dim dregistro As DataRow = dtDatos.NewRow
                            dregistro("reloj") = dRow("reloj")
                            dregistro("nombres") = dRow("nombres")
                            dregistro("horario") = dRow("cod_hora")                            
                            dregistro("cod_tipo") = dRow("cod_tipo")
                            dregistro("cod_depto") = dRow("cod_depto")

                            dregistro("fecha") = FechaSQL(hrow("fecha"))
                            dregistro("hora") = hrow("hora")
                            dregistro("nombre_servicio") = hrow("nombre")
                            dregistro("horario_orden") = hrow("orden")
                            dregistro("subsidio") = hrow("subsidio")
                            dregistro("id") = hrow("id_registro")

                            dtDatos.Rows.Add(dregistro)

                        Next
                        f = f.AddDays(1)
                    End While

                Next
                ActivoTrabajando = False
                frmTrabajando.Close()

            Catch ex As Exception
                dtDatos.Rows.Clear()
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            End Try
        Catch ex As Exception

        End Try
    End Sub



    Public Sub DiasParaPTU(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOMBRES", Type.GetType("System.String"))
            dtDatos.Columns.Add("BAJA", Type.GetType("System.String"))
            dtDatos.Columns.Add("ALTA", Type.GetType("System.String"))

            dtDatos.Columns.Add("limite_min", Type.GetType("System.String"))
            dtDatos.Columns.Add("limite_max", Type.GetType("System.String"))

            dtDatos.Columns.Add("DIAS", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("COD_TIPO", Type.GetType("System.String"))
            dtDatos.Columns.Add("REGISTRO", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("Ausentismo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("Tipo_Registro", Type.GetType("System.String"))

            If frmseleccionarano.ShowDialog() = DialogResult.OK Then
                Dim y As Integer = frmseleccionarano.ComboBox1.Text

                Dim personal As DataTable = sqlExecute("select reloj, nombres, baja, alta, COD_TIPO from personalvw where alta < '" & FechaSQL(DateSerial(y + 1, 1, 1)) & "' and (BAJA is null or BAJA >=  '" & FechaSQL(DateSerial(y, 1, 1)) & "') and COD_COMP in (select COD_COMP from cias where cia_default = 1) ")

                For Each row As DataRow In personal.Rows
                    Dim drow As DataRow = dtDatos.NewRow
                    drow("RELOJ") = row("RELOJ")
                    drow("NOMBRES") = row("NOMBRES")
                    'drow("BAJA") = IIf(IsDBNull(row("BAJA")), "", row("BAJA"))
                    'drow("ALTA") = row("ALTA")
                    drow("COD_TIPO") = row("COD_TIPO")
                    drow("Tipo_Registro") = "p"

                    drow("ALTA") = Date.Parse(row("ALTA")).ToShortDateString
                    'drow("BAJA") = IIf(IsDBNull(row("BAJA")), "", Date.Parse(row("BAJA")).ToShortDateString)

                    If IsDBNull(row("BAJA")) Then
                        drow("BAJA") = ""
                    Else
                        drow("BAJA") = Date.Parse(row("BAJA")).ToShortDateString
                    End If



                    Dim dias As Integer
                    Dim inicio As Date
                    Dim fin As Date

                    Dim alta As Date = Date.Parse(row("ALTA"))
                    Dim baja As Date = Date.Parse(IIf(IsDBNull(row("BAJA")), FechaSQL(DateSerial(y, 12, 31)), row("BAJA")))

                    If alta < DateSerial(y, 1, 1) Then
                        inicio = DateSerial(y, 1, 1).Date
                    Else
                        inicio = alta.Date
                    End If

                    If baja > DateSerial(y, 12, 31) Then
                        fin = DateSerial(y, 12, 31).Date

                    Else
                        fin = baja.Date
                    End If

                    drow("limite_min") = inicio.ToShortDateString
                    drow("limite_max") = fin.ToShortDateString

                    dias = DateDiff(DateInterval.Day, inicio, fin) + 1

                    drow("dias") = dias
                    drow("registro") = 1

                    dtDatos.Rows.Add(drow)
                Next

                ' Dim reingresos As DataTable = sqlExecute("select reingresos.reloj, personalvw.nombres, reingresos.baja_ant, reingresos.alta_ant, PersonalVW.COD_TIPO, PersonalVW.alta from reingresos left join personalvw on PersonalVW.reloj = reingresos.reloj where alta_ant between '" & FechaSQL(DateSerial(y, 1, 1)) & "' and '" & FechaSQL(DateSerial(y, 12, 31)) & "' or baja_ant between '" & FechaSQL(DateSerial(y, 1, 1)) & "' and '" & FechaSQL(DateSerial(y, 12, 31)) & "'")
                Dim reingresos As DataTable = sqlExecute("select reingresos.reloj, personalvw.nombres, reingresos.baja_ant, reingresos.alta_ant, PersonalVW.COD_TIPO, PersonalVW.alta from reingresos left join personalvw on PersonalVW.reloj = reingresos.reloj where ( alta_ant <= '" & FechaSQL(DateSerial(y, 12, 31)) & "' and baja_ant >= '" & FechaSQL(DateSerial(y, 1, 1)) & "'")


                For Each row As DataRow In reingresos.Rows

                    Dim drow As DataRow = dtDatos.NewRow
                    drow("RELOJ") = row("RELOJ")
                    drow("NOMBRES") = row("NOMBRES")
                    drow("BAJA") = IIf(IsDBNull(row("baja_ant")), "", row("baja_ant"))
                    drow("ALTA") = row("alta_ant")
                    drow("COD_TIPO") = row("COD_TIPO")
                    drow("Tipo_Registro") = "r"

                    Dim dias As Integer
                    Dim inicio As Date
                    Dim fin As Date

                    Dim alta As Date = Date.Parse(row("alta_ant"))
                    Dim baja As Date = Date.Parse(IIf(IsDBNull(row("baja_ant")), FechaSQL(DateSerial(y, 12, 31)), row("baja_ant")))

                    If alta < DateSerial(y, 1, 1) Then
                        inicio = DateSerial(y, 1, 1).Date
                    Else
                        inicio = alta.Date
                    End If

                    If baja > DateSerial(y, 12, 31) Then
                        fin = DateSerial(y, 12, 31).Date
                    Else
                        fin = baja.Date
                    End If

                    drow("limite_min") = inicio.ToShortDateString
                    drow("limite_max") = fin.ToShortDateString

                    dias = DateDiff(DateInterval.Day, inicio, fin) + 1

                    drow("dias") = dias

                    drow("registro") = 2 ' 1

                    dtDatos.Rows.Add(drow)

                Next


                For Each row As DataRow In dtDatos.Rows
                    'Dim drow As DataRow = dtDatos.NewRow
                    Dim _reloj As String = row("reloj")
                    Dim limite_min As Date = row("limite_min")
                    Dim limite_max As Date = row("limite_max")

                    Dim Ausentismo As DataTable = sqlExecute("select count(reloj) cuantos from ausentismo where reloj = '" & _reloj & "' and FECHA BETWEEN '" & FechaSQL(limite_min) & "'and'" & FechaSQL(limite_max) & "' and TIPO_AUS = 'FI' group by reloj having count(reloj)>1 ", "TA")

                    Try
                        Dim Ausen As Int32 = Ausentismo.Rows(0)("cuantos")
                        row("Ausentismo") = Ausen
                    Catch ex As Exception
                        row("Ausentismo") = 0
                    End Try

                Next

            End If

        Catch ex As Exception

        End Try

    End Sub


    Public Sub ModificacionesPorAntiguedadBRP(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim dtMod As New DataTable
        dtMod.Columns.Add("reloj", Type.GetType("System.String"))
        dtMod.Columns.Add("cod_comp", Type.GetType("System.String"))
        dtMod.Columns.Add("cod_planta", Type.GetType("System.String"))
        dtMod.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtMod.Columns.Add("cod_puesto", Type.GetType("System.String"))
        dtMod.Columns.Add("alta", Type.GetType("System.String"))
        dtMod.Columns.Add("nombres", Type.GetType("System.String"))

        dtMod.Columns.Add("tipo")
        dtMod.Columns.Add("desde")
        dtMod.Columns.Add("meses")

        For Each row As DataRow In dtMod.Rows
            Dim _alta As Date = row("alta")
            Dim _baja As Date = row("baja")

            Dim _desde As Date
            Dim _tipo As String

            If _alta > _baja Then
                Dim dtCambioPuesto As DataTable = sqlExecute("select top 1 * from mod_sal where reloj = '" & row("reloj") & "' order by fecha desc")
                If dtCambioPuesto.Rows.Count Then
                    _desde = dtCambioPuesto.Rows(0)("fecha")
                Else
                    _desde = _alta
                End If

                If _desde <> _alta Then
                    _tipo = "posicion"
                Else
                    _tipo = "alta"
                End If



            End If

        Next

    End Sub

    'Public Sub NuevoReporteDiario(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
    '    Try

    '        ' Seleccionar fecha y planta(s)

    '        frmSeleccionarPlanta.ShowDialog()
    '        frmSeleccionarFecha.ShowDialog()

    '        Dim _planta_filtro As String = PlantaReporteDiario
    '        Dim _fecha_filtro As Date = FechaInicial.Date

    '        '------------------------------------------------------------------------

    '        ' Crear estrutura de dtDatos
    '        dtDatos = New DataTable
    '        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("tipo_registro", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("fecha_registro", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("encabezado_fechas", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("fecha_reporte", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("filtro_planta", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("cod_comp", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("compania", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("cod_planta", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("nombre_clase", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("cod_area", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
    '        dtDatos.Columns.Add("cuenta_area", Type.GetType("System.Int32"))

    '        dtDatos.Columns.Add("dias", Type.GetType("System.Int32"))
    '        dtDatos.Columns.Add("inactivo", Type.GetType("System.Int32"))
    '        dtDatos.Columns.Add("fecha_inactivo", Type.GetType("System.String"))

    '        dtDatos.Columns.Add("headcount", Type.GetType("System.Int32"))
    '        dtDatos.Columns.Add("alta", Type.GetType("System.Int32"))
    '        dtDatos.Columns.Add("baja", Type.GetType("System.Int32"))
    '        dtDatos.Columns.Add("falta", Type.GetType("System.Int32"))
    '        dtDatos.Columns.Add("vacacion", Type.GetType("System.Int32"))
    '        dtDatos.Columns.Add("permiso", Type.GetType("System.Int32"))
    '        dtDatos.Columns.Add("incapacidad", Type.GetType("System.Int32"))

    '        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj"), dtDatos.Columns("tipo_registro")}

    '        '------------------------------------------------------------------------

    '        'Crear tabla con las fechas del reporte, 
    '        ' 1.- Fecha seleccionada
    '        ' 2.- Fechas del periodo anterior a la fecha seleccionada

    '        Dim dtFechas As DataTable = New DataTable
    '        dtFechas.Columns.Add("fecha", Type.GetType("System.DateTime"))
    '        dtFechas.Columns.Add("tipo_registro", Type.GetType("System.String"))

    '        dtFechas.Rows.Add({_fecha_filtro, "D"})

    '        Dim encabezado_fechas As String = ""

    '        Dim dtPeriodos As DataTable = sqlExecute("select top 1 * from periodos where fecha_fin < '" & _fecha_filtro & "' and isnull(periodo_especial, 0) = 0 order by ano+periodo desc", "TA")
    '        If dtPeriodos.Rows.Count > 0 Then
    '            Dim _ano_ As String = dtPeriodos.Rows(0)("ano")
    '            Dim _periodo_ As String = dtPeriodos.Rows(0)("periodo")

    '            Dim _fini As Date = dtPeriodos.Rows(0)("fecha_ini")
    '            Dim _ffin As Date = dtPeriodos.Rows(0)("fecha_fin")

    '            encabezado_fechas = "Periodo " & _ano_ & "-" & _periodo_ & ", del " & FechaCortaLetra(_fini) & " al " & FechaCortaLetra(_ffin)

    '            While _fini <= _ffin
    '                dtFechas.Rows.Add({_fini, "S"})
    '                _fini = _fini.AddDays(1)
    '            End While

    '        End If

    '        '------------------------------------------------------------------------

    '        'Para cada una de las fechas
    '        'Identificar empleados activos en esa fecha (Incluyendo bajas de la fecha)
    '        'Identificar ausentismo de empleados en fecha

    '        For Each row As DataRow In dtFechas.Rows
    '            Dim _f_registro As Date = row("fecha")
    '            Dim _tipo_registro As String = row("tipo_registro")

    '            ' Ausentismo de la fecha
    '            Dim dtAusentismo As DataTable = sqlExecute("select * from ausentismo where fecha = '" & FechaSQL(_f_registro) & "'", "TA")

    '            'Deptos / Areas de la fecha
    '            Dim dtDeptosAreasTurnos As DataTable = sqlExecute("select distinct asist.reloj, asist.cod_depto, c_costos.cod_area, asist.cod_turno " & _
    '                                                  "from asist left join personal.dbo.deptos on deptos.cod_depto = asist.cod_depto left join personal.dbo.c_costos on c_costos.centro_costos = deptos.centro_costos where asist.fha_ent_hor = '" & FechaSQL(_f_registro) & "' and deptos.cod_comp = '090'", "TA")
    '            dtDeptosAreasTurnos.PrimaryKey = New DataColumn() {dtDeptosAreasTurnos.Columns("reloj")}

    '            Dim q As String
    '            q = "select personalvw.reloj, "
    '            q &= "personalvw.nombres, "
    '            q &= "personalvw.cod_comp, "
    '            q &= "personalvw.compania, "
    '            q &= "personalvw.cod_planta, "
    '            q &= "personalvw.cod_tipo, "
    '            q &= "personalvw.cod_clase, "
    '            q &= "personalvw.nombre_clase, "
    '            q &= "personalvw.cod_turno, "
    '            q &= "personalvw.cod_area, "
    '            q &= "isnull(personalvw.inactivo, 0) as inactivo, "
    '            q &= "personalvw.alta, "
    '            q &= "personalvw.baja, "
    '            q &= "case when personalvw.baja = '" & FechaSQL(_f_registro) & "' and personalvw.cod_mot_ba NOT in ('03', '04', '09', '07') then 1 else 0 end as cuenta_baja, "
    '            q &= "case when personalvw.alta = '" & FechaSQL(_f_registro) & "' then 1 else 0 end as cuenta_alta "
    '            q &= "from personalvw "
    '            'Solamente companias brp/caseem/us
    '            q &= "where personalvw.cod_comp in ('093', '092', '090') and personalvw.alta <= '" & FechaSQL(_f_registro) & "' and (personalvw.baja is null or personalvw.baja >= '" & FechaSQL(_f_registro) & "') "
    '            Dim dtPersonal As DataTable = sqlExecute(q)

    '            For Each drow As DataRow In dtPersonal.Rows

    '                Dim nrow As DataRow = dtDatos.Rows.Find({drow("reloj"), _tipo_registro})
    '                If nrow Is Nothing Then

    '                    nrow = dtDatos.NewRow

    '                    nrow("reloj") = drow("reloj")
    '                    nrow("nombres") = drow("nombres")

    '                    nrow("encabezado_fechas") = encabezado_fechas

    '                    nrow("tipo_registro") = _tipo_registro
    '                    nrow("fecha_registro") = FechaSQL(_f_registro)

    '                    nrow("fecha_reporte") = FechaSQL(_fecha_filtro)
    '                    nrow("filtro_planta") = _planta_filtro

    '                    nrow("dias") = 1

    '                    nrow("headcount") = 1
    '                    nrow("falta") = 0
    '                    nrow("vacacion") = 0
    '                    nrow("permiso") = 0
    '                    nrow("incapacidad") = 0

    '                    nrow("alta") = drow("cuenta_alta")
    '                    nrow("baja") = drow("cuenta_baja")

    '                    nrow("inactivo") = drow("inactivo")

    '                    nrow("cod_comp") = drow("cod_comp")
    '                    nrow("compania") = RTrim(IIf(IsDBNull(drow("compania")), "", drow("compania")))

    '                    nrow("cod_turno") = RTrim(IIf(IsDBNull(drow("cod_turno")), "", drow("cod_turno")))
    '                    nrow("cod_tipo") = RTrim(IIf(IsDBNull(drow("cod_tipo")), "", drow("cod_tipo")))

    '                    nrow("cod_planta") = drow("cod_planta")

    '                    nrow("cod_clase") = drow("cod_clase")
    '                    nrow("nombre_clase") = RTrim(IIf(IsDBNull(drow("nombre_clase")), "", drow("nombre_clase")))

    '                    nrow("cod_area") = drow("cod_area")
    '                    nrow("cuenta_area") = 0
    '                    nrow("nombre_area") = ""

    '                    'Actualizar area de acuerdo a lo sucedido
    '                    Dim row_area As DataRow = dtDeptosAreasTurnos.Rows.Find(nrow("reloj"))
    '                    If Not row_area Is Nothing Then
    '                        Try : nrow("cod_area") = RTrim(row_area("cod_area")) : Catch ex As Exception : End Try
    '                        Try : nrow("cod_turno") = RTrim(row_area("cod_turno")) : Catch ex As Exception : End Try
    '                    End If

    '                    '
    '                    dtDatos.Rows.Add(nrow)

    '                Else                        
    '                    Dim row_area As DataRow = dtDeptosAreasTurnos.Rows.Find(nrow("reloj"))
    '                    If Not row_area Is Nothing Then
    '                        Dim dias As Integer = nrow("dias")
    '                        nrow("dias") = dias + 1
    '                    End If

    '                    If _tipo_registro = "S" Then
    '                        Dim baja As Integer = nrow("baja")
    '                        Dim baja_sem As Integer = drow("cuenta_baja")
    '                        If baja = 0 And baja_sem = 1 Then
    '                            nrow("baja") = baja_sem
    '                        End If
    '                    End If

    '                End If

    '                'Actualizar ausentismo de acuerdo a lo sucedido

    '                Dim falta As Integer = nrow("falta")
    '                nrow("falta") = falta + dtAusentismo.Select("reloj = '" & nrow("reloj") & "' and tipo_aus in ('FI')").Count

    '                Dim vacacion As Integer = nrow("vacacion")
    '                nrow("vacacion") = vacacion + dtAusentismo.Select("reloj = '" & nrow("reloj") & "' and tipo_aus in ('VAC')").Count

    '                Dim permiso As Integer = nrow("permiso")
    '                nrow("permiso") = permiso + dtAusentismo.Select("reloj = '" & nrow("reloj") & "' and tipo_aus in ('MAT','NAC','PGO','PSG','FUN','PSV')").Count

    '                Dim incapacidad As Integer = nrow("incapacidad")
    '                nrow("incapacidad") = incapacidad + dtAusentismo.Select("reloj = '" & nrow("reloj") & "' and tipo_aus in ('IMP','IMS','INA','ING','INR')").Count

    '            Next

    '        Next

    '        ' Asignar nombre de areas
    '        Dim dtNombreAreas As DataTable = sqlExecute("select cod_area, nombre from areas")
    '        For Each row As DataRow In dtDatos.Rows
    '            Try
    '                Dim nombre_area As String = RTrim(dtNombreAreas.Select("cod_area = '" & row("cod_area") & "'")(0)("nombre"))
    '                row("nombre_area") = nombre_area
    '            Catch ex As Exception

    '            End Try
    '        Next

    '        '------------------------------------------------------------------------

    '        ' Para empleados inactivos, obtener fecha de inactividad desde bitacora personal
    '        For Each row As DataRow In dtDatos.Select("inactivo = 1")
    '            row("headcount") = 0
    '            Dim dtBitacora As DataTable = sqlExecute("select * from bitacora_personal where reloj = '" & row("reloj") & "' and campo = 'inactivo' and valornuevo = '1' order by fecha desc")
    '            If dtBitacora.Rows.Count > 0 Then
    '                Dim f_inact As Date = dtBitacora.Rows(0)("fecha")
    '                row("fecha_inactivo") = f_inact.ToShortDateString
    '            Else
    '                row("fecha_inactivo") = "N/A"
    '            End If
    '        Next

    '        '2017/7/12 Las bajas no se consideran dentro del heacount
    '        For Each row As DataRow In dtDatos.Select("baja = 1")
    '            row("headcount") = 0
    '        Next

    '        '------------------------------------------------------------------------

    '        ' Marcar areas que se mostraran en el reporte
    '        ' Las áreas están en el orden en que deben mostrarse en el reporte

    '        Dim dtAreas As New DataTable
    '        dtAreas.Columns.Add("cod_clase")
    '        dtAreas.Columns.Add("cod_area")

    '        dtAreas.Rows.Add({"D", "03"}) ' ATV
    '        dtAreas.Rows.Add({"D", "08"}) ' SSV
    '        dtAreas.Rows.Add({"D", "33"}) ' Fabricacion
    '        dtAreas.Rows.Add({"D", "07"}) ' Retrabajo
    '        dtAreas.Rows.Add({"D", "11"}) ' Calidad
    '        dtAreas.Rows.Add({"D", "16"}) ' Materiales

    '        dtAreas.Rows.Add({"I", "26"}) ' Mantenimiento
    '        dtAreas.Rows.Add({"I", "02"}) ' Seguridad industrial
    '        dtAreas.Rows.Add({"I", "20"}) ' Shipping

    '        Dim cuenta_area As Integer = 1
    '        For Each row As DataRow In dtAreas.Rows
    '            Dim _clase As String = row("cod_clase")
    '            Dim _area As String = row("cod_area")

    '            For Each area_row In dtDatos.Select("cod_clase = '" & _clase & "' and cod_area = '" & _area & "' and tipo_registro = 'D' and inactivo = 0")
    '                area_row("cuenta_area") = cuenta_area
    '            Next

    '            cuenta_area += 1
    '        Next

    '        '------------------------------------------------------------------------

    '        'Finalmente filtrar datos en caso de que solo se haya seleccionado una planta
    '        If _planta_filtro <> "***" Then
    '            dtDatos = dtDatos.Select("cod_planta = '" & _planta_filtro & "'").CopyToDataTable
    '        End If

    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
    '    End Try
    'End Sub

    Public Sub NuevoReporteDiario(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            ' Seleccionar fecha y planta(s)

            frmSeleccionarPlanta.ShowDialog()
            frmSeleccionarFecha.ShowDialog()

            Dim _planta_filtro As String = PlantaReporteDiario
            Dim _fecha_filtro As Date = FechaInicial.Date

            '------------------------------------------------------------------------

            ' Crear estrutura de dtDatos
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("tipo_registro", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_registro", Type.GetType("System.String"))
            dtDatos.Columns.Add("encabezado_fechas", Type.GetType("System.String"))

            dtDatos.Columns.Add("fecha_reporte", Type.GetType("System.String"))
            dtDatos.Columns.Add("filtro_planta", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_comp", Type.GetType("System.String"))
            dtDatos.Columns.Add("compania", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_planta", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_clase", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_clase", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_area", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
            dtDatos.Columns.Add("cuenta_area", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("dias", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("inactivo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("fecha_inactivo", Type.GetType("System.String"))

            dtDatos.Columns.Add("headcount", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("alta", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("baja", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("falta", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("vacacion", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("permiso", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("incapacidad", Type.GetType("System.Int32"))

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj"), dtDatos.Columns("tipo_registro")}

            '------------------------------------------------------------------------

            'Crear tabla con las fechas del reporte, 
            ' 1.- Fecha seleccionada
            ' 2.- Fechas del periodo anterior a la fecha seleccionada

            Dim dtFechas As DataTable = New DataTable
            dtFechas.Columns.Add("fecha", Type.GetType("System.DateTime"))
            dtFechas.Columns.Add("tipo_registro", Type.GetType("System.String"))

            dtFechas.Rows.Add({_fecha_filtro, "D"})

            Dim encabezado_fechas As String = ""

            Dim dtPeriodos As DataTable = sqlExecute("select top 1 * from periodos where fecha_fin < '" & _fecha_filtro & "' and isnull(periodo_especial, 0) = 0 order by ano+periodo desc", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                Dim _ano_ As String = dtPeriodos.Rows(0)("ano")
                Dim _periodo_ As String = dtPeriodos.Rows(0)("periodo")

                Dim _fini As Date = dtPeriodos.Rows(0)("fecha_ini")
                Dim _ffin As Date = dtPeriodos.Rows(0)("fecha_fin")

                encabezado_fechas = "Periodo " & _ano_ & "-" & _periodo_ & ", del " & FechaCortaLetra(_fini) & " al " & FechaCortaLetra(_ffin)

                While _fini <= _ffin
                    dtFechas.Rows.Add({_fini, "S"})
                    _fini = _fini.AddDays(1)
                End While

            End If

            '------------------------------------------------------------------------

            'Para cada una de las fechas
            'Identificar empleados activos en esa fecha (Incluyendo bajas de la fecha)
            'Identificar ausentismo de empleados en fecha

            For Each row As DataRow In dtFechas.Rows
                Dim _f_registro As Date = row("fecha")
                Dim _tipo_registro As String = row("tipo_registro")

                ' Ausentismo de la fecha
                Dim dtAusentismo As DataTable = sqlExecute("select * from ausentismo where fecha = '" & FechaSQL(_f_registro) & "'", "TA")

                'Deptos / Areas de la fecha
                Dim dtDeptosAreasTurnos As DataTable = sqlExecute("select distinct asist.reloj, asist.cod_depto, c_costos.cod_area, asist.cod_turno " & _
                                                      "from asist left join personal.dbo.deptos on deptos.cod_depto = asist.cod_depto left join personal.dbo.c_costos on c_costos.centro_costos = deptos.centro_costos where asist.fha_ent_hor = '" & FechaSQL(_f_registro) & "' and deptos.cod_comp = '610'", "TA")
                dtDeptosAreasTurnos.PrimaryKey = New DataColumn() {dtDeptosAreasTurnos.Columns("reloj")}

                Dim q As String
                q = "select personalvw.reloj, "
                q &= "personalvw.nombres, "
                q &= "personalvw.cod_comp, "
                q &= "personalvw.compania, "
                q &= "personalvw.cod_planta, "
                q &= "personalvw.cod_tipo, "
                q &= "personalvw.cod_clase, "
                q &= "personalvw.nombre_clase, "
                q &= "personalvw.cod_turno, "
                q &= "personalvw.cod_area, "
                q &= "isnull(personalvw.inactivo, 0) as inactivo, "
                q &= "personalvw.alta, "
                q &= "personalvw.baja, "
                q &= "case when personalvw.baja = '" & FechaSQL(_f_registro) & "' and personalvw.cod_mot_ba NOT in ('03', '04', '09', '07') then 1 else 0 end as cuenta_baja, "
                q &= "case when personalvw.alta = '" & FechaSQL(_f_registro) & "' then 1 else 0 end as cuenta_alta "
                q &= "from personalvw "
                'Solamente companias brp/caseem/us
                q &= "where personalvw.cod_comp in ('610') and personalvw.alta <= '" & FechaSQL(_f_registro) & "' and (personalvw.baja is null or personalvw.baja >= '" & FechaSQL(_f_registro) & "') "
                Dim dtPersonal As DataTable = sqlExecute(q)

                For Each drow As DataRow In dtPersonal.Rows

                    Dim nrow As DataRow = dtDatos.Rows.Find({drow("reloj"), _tipo_registro})
                    If nrow Is Nothing Then

                        nrow = dtDatos.NewRow

                        nrow("reloj") = drow("reloj")
                        nrow("nombres") = drow("nombres")

                        nrow("encabezado_fechas") = encabezado_fechas

                        nrow("tipo_registro") = _tipo_registro
                        nrow("fecha_registro") = FechaSQL(_f_registro)

                        nrow("fecha_reporte") = FechaSQL(_fecha_filtro)
                        nrow("filtro_planta") = _planta_filtro

                        nrow("dias") = 1

                        nrow("headcount") = 1
                        nrow("falta") = 0
                        nrow("vacacion") = 0
                        nrow("permiso") = 0
                        nrow("incapacidad") = 0

                        nrow("alta") = drow("cuenta_alta")
                        nrow("baja") = drow("cuenta_baja")

                        nrow("inactivo") = drow("inactivo")

                        nrow("cod_comp") = drow("cod_comp")
                        nrow("compania") = RTrim(IIf(IsDBNull(drow("compania")), "", drow("compania")))

                        nrow("cod_turno") = RTrim(IIf(IsDBNull(drow("cod_turno")), "", drow("cod_turno")))
                        nrow("cod_tipo") = RTrim(IIf(IsDBNull(drow("cod_tipo")), "", drow("cod_tipo")))

                        nrow("cod_planta") = drow("cod_planta")

                        nrow("cod_clase") = drow("cod_clase")
                        nrow("nombre_clase") = RTrim(IIf(IsDBNull(drow("nombre_clase")), "", drow("nombre_clase")))

                        nrow("cod_area") = drow("cod_area")
                        nrow("cuenta_area") = 0
                        nrow("nombre_area") = ""

                        'Actualizar area de acuerdo a lo sucedido
                        Dim row_area As DataRow = dtDeptosAreasTurnos.Rows.Find(nrow("reloj"))
                        If Not row_area Is Nothing Then
                            Try : nrow("cod_area") = RTrim(row_area("cod_area")) : Catch ex As Exception : End Try
                            Try : nrow("cod_turno") = RTrim(row_area("cod_turno")) : Catch ex As Exception : End Try
                        End If

                        '
                        dtDatos.Rows.Add(nrow)

                    Else
                        Dim row_area As DataRow = dtDeptosAreasTurnos.Rows.Find(nrow("reloj"))
                        If Not row_area Is Nothing Then
                            Dim dias As Integer = nrow("dias")
                            nrow("dias") = dias + 1
                        End If

                        If _tipo_registro = "S" Then
                            Dim baja As Integer = nrow("baja")
                            Dim baja_sem As Integer = drow("cuenta_baja")
                            If baja = 0 And baja_sem = 1 Then
                                nrow("baja") = baja_sem
                            End If
                        End If

                    End If

                    'Actualizar ausentismo de acuerdo a lo sucedido

                    Dim falta As Integer = nrow("falta")
                    nrow("falta") = falta + dtAusentismo.Select("reloj = '" & nrow("reloj") & "' and tipo_aus in ('FI')").Count

                    Dim vacacion As Integer = nrow("vacacion")
                    nrow("vacacion") = vacacion + dtAusentismo.Select("reloj = '" & nrow("reloj") & "' and tipo_aus in ('VAC')").Count

                    Dim permiso As Integer = nrow("permiso")
                    nrow("permiso") = permiso + dtAusentismo.Select("reloj = '" & nrow("reloj") & "' and tipo_aus in ('MAT','NAC','PGO','PSG','FUN','PSV')").Count

                    Dim incapacidad As Integer = nrow("incapacidad")
                    nrow("incapacidad") = incapacidad + dtAusentismo.Select("reloj = '" & nrow("reloj") & "' and tipo_aus in ('IMP','IMS','INA','ING','INR')").Count

                Next

            Next

            ' Asignar nombre de areas
            Dim dtNombreAreas As DataTable = sqlExecute("select cod_area, nombre from areas")
            For Each row As DataRow In dtDatos.Rows
                Try
                    Dim nombre_area As String = RTrim(dtNombreAreas.Select("cod_area = '" & row("cod_area") & "'")(0)("nombre"))
                    row("nombre_area") = nombre_area
                Catch ex As Exception

                End Try
            Next

            '------------------------------------------------------------------------

            ' Para empleados inactivos, obtener fecha de inactividad desde bitacora personal
            For Each row As DataRow In dtDatos.Select("inactivo = 1")
                row("headcount") = 0
                row("falta") = 0
                row("vacacion") = 0
                row("permiso") = 0
                row("incapacidad") = 0
                row("alta") = 0
                row("baja") = 0
                row("dias") = 0

                Dim dtBitacora As DataTable = sqlExecute("select * from bitacora_personal where reloj = '" & row("reloj") & "' and campo = 'inactivo' and valornuevo = '1' order by fecha desc")
                If dtBitacora.Rows.Count > 0 Then
                    Dim f_inact As Date = dtBitacora.Rows(0)("fecha")
                    row("fecha_inactivo") = f_inact.ToShortDateString
                Else
                    row("fecha_inactivo") = "N/A"
                End If
            Next

            '2017/7/12 Las bajas no se consideran dentro del heacount
            For Each row As DataRow In dtDatos.Select("baja = 1")
                row("headcount") = 0
                row("falta") = 0
                row("vacacion") = 0
                row("permiso") = 0
                row("incapacidad") = 0
            Next

            '------------------------------------------------------------------------

            ' Marcar areas que se mostraran en el reporte
            ' Las áreas están en el orden en que deben mostrarse en el reporte

            Dim dtAreas As New DataTable
            dtAreas.Columns.Add("cod_clase")
            dtAreas.Columns.Add("cod_area")

            dtAreas.Rows.Add({"D", "03"}) ' ATV
            dtAreas.Rows.Add({"D", "08"}) ' SSV
            dtAreas.Rows.Add({"D", "33"}) ' Fabricacion
            dtAreas.Rows.Add({"D", "07"}) ' Retrabajo
            dtAreas.Rows.Add({"D", "11"}) ' Calidad
            dtAreas.Rows.Add({"D", "16"}) ' Materiales

            dtAreas.Rows.Add({"I", "26"}) ' Mantenimiento
            dtAreas.Rows.Add({"I", "02"}) ' Seguridad industrial
            dtAreas.Rows.Add({"I", "20"}) ' Shipping

            Dim cuenta_area As Integer = 1
            For Each row As DataRow In dtAreas.Rows
                Dim _clase As String = row("cod_clase")
                Dim _area As String = row("cod_area")

                For Each area_row In dtDatos.Select("cod_clase = '" & _clase & "' and cod_area = '" & _area & "' and tipo_registro = 'D' and inactivo = 0")
                    area_row("cuenta_area") = cuenta_area
                Next

                cuenta_area += 1
            Next

            '------------------------------------------------------------------------

            'Finalmente filtrar datos en caso de que solo se haya seleccionado una planta
            If _planta_filtro <> "***" Then
                dtDatos = dtDatos.Select("cod_planta = '" & _planta_filtro & "'").CopyToDataTable
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub BRP_ReporteDiario(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal DataSet As String)
        If ReporteDiario Then
            frmSeleccionarPlanta.ShowDialog()
            frmSeleccionarFecha.ShowDialog()
        End If
        If DataSet.Equals("Diario_COD") Then
            'If ReporteDiario Then
            '    ReporteDiario = False
            'Else
            '    ReporteDiario = True
            'End If
            ReporteDiario = False

            Dim query As String = "" & _
            "select " & _
             "personalvw.COD_TIPO," & _
            "personalvw.COD_CLASE," & _
            "personalvw.nombre_clase," & _
            "personalvw.COD_PLANTA," & _
            "PersonalVW.nombre_planta," & _
            "case when PersonalVW.COD_AREA in ('04','09','28', '33') then 'FAB' else personalvw.cod_area end as cod_Area," & _
            "case when PersonalVW.COD_AREA in ('04','09','28', '33') then 'Fabricación' else personalvw.nombre_area end as Area," & _
            "personalvw.COD_TURNO," & _
            "personalvw.COD_COMP," & _
            "personalvw.compania," & _
            "'" & FechaMediaLetra(FechaInicial) & "' as fechaReporte," & _
            "sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end) as Headcount," & _
            "sum (case when rtrim(tavw.tipo_aus)='FI'  then 1 else 0 end) as Faltas," & _
            "sum (case when rtrim(tavw.tipo_aus) in ('VAC') then 1 else 0 end) as Vacaciones," & _
            "sum (case when rtrim(tavw.tipo_aus) in ('MAT','NAC','PGO','PSG','FUN','PSV') then 1 else 0 end) as Permisos," & _
            "sum (case when rtrim(tavw.tipo_aus) in ('IMP','IMS','INA','ING','INR') then 1 else 0 end) as Incapacidad," & _
            "sum (case when personalvw.baja  = '" & FechaSQL(FechaInicial) & "' and rtrim(personalvw.COD_MOT_BA)<> '06' then 1 else 0 end) as Bajas," & _
            "case when sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end) = 0 then 0 else (1-(CONVERT(FLOAT(53),((sum (case when rtrim(tipo_aus)='FI' then 1 else 0 end))  + (sum (case when rtrim(tipo_aus) in ('MAT','NAC','PGO','PSG','FUN','PSV') then 1 else 0 end)) ))/sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end)))*100 end as PorcentajeAsistencia," & _
            "case when sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end) = 0 then 0  else (CAST(sum (case when personalvw.baja  = '" & FechaSQL(FechaInicial) & "' and rtrim(personalvw.COD_MOT_BA) <> '06' then 1 else 0 end) AS FLOAT(53))/CAST(sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end) AS FLOAT(53)))*100 end  as PorcentajeRotacion," & _
            "sum (case when tavw.fecha_entro  is not null  then 1 else 0 end) as TotalDiasHabiles," & _
            "sum (case when personalvw.alta  = '" & FechaSQL(FechaInicial) & "' then 1 else 0 end) as Altas " & _
            "from  (select * from personalvw where personalvw.inactivo <> '1' or PersonalVW.inactivo is null)PersonalVW  " & _
            "left join (select distinct reloj,fecha_entro,max(tipo_aus) as tipo_aus	 from ta.dbo.tavw where fecha_entro = '" & FechaSQL(FechaInicial) & "' GROUP BY reloj,fecha_entro)tavw " & _
            "on personalvw.reloj = tavw.reloj " & _
            " " & _
            "GROUP BY " & _
            "personalvw.COD_TIPO," & _
            "personalvw.COD_CLASE," & _
            "personalvw.nombre_clase," & _
            "personalvw.COD_PLANTA," & _
            "PersonalVW.nombre_planta," & _
            "case when PersonalVW.COD_AREA in ('04','09','28', '33') then 'FAB' else personalvw.cod_area end," & _
            "case when PersonalVW.COD_AREA in ('04','09','28', '33') then 'Fabricación' else personalvw.nombre_area end," & _
            "personalvw.COD_TURNO," & _
            "personalvw.COD_COMP," & _
            "personalvw.compania " & _
            "ORDER BY personalvw.COD_TIPO," & _
            "personalvw.COD_CLASE," & _
            "personalvw.nombre_clase," & _
            "personalvw.COD_PLANTA," & _
            "PersonalVW.nombre_planta," & _
            "case when PersonalVW.COD_AREA in ('04','09','28', '33') then 'FAB' else personalvw.cod_area end," & _
            "case when PersonalVW.COD_AREA in ('04','09','28', '33') then 'Fabricación' else personalvw.nombre_area end," & _
            "personalvw.COD_TURNO," & _
            "personalvw.COD_COMP," & _
            "personalvw.compania"
            dtDatos = sqlExecute(query)

            If PlantaReporteDiario <> "***" Then
                dtDatos = dtDatos.Select("cod_planta = '" & PlantaReporteDiario & "'").CopyToDataTable
            End If

            dtDatos.Columns.Add("filtro_planta")
            For Each row As DataRow In dtDatos.Rows
                row("filtro_planta") = PlantaReporteDiario
            Next

        ElseIf DataSet.Equals("Semanal_COD") Then
            
            ReporteDiario = False
            Dim NumSem As String = ""
            Dim fechaTemp As Date = FechaInicial
            Dim fechaPivote As Date = FechaInicial.AddDays(-7)
            Dim dtPeriodo As DataTable = sqlExecute("select * from  periodos where fecha_ini <= '" & FechaSQL(fechaPivote) & "' and fecha_fin >= '" & FechaSQL(fechaPivote) & "'", "ta")
            If dtPeriodo.Rows.Count > 0 Then
                FechaInicial = dtPeriodo.Rows(0).Item("fecha_ini")
                FechaFinal = dtPeriodo.Rows(0).Item("fecha_fin")
                NumSem = dtPeriodo.Rows(0).Item("periodo")
            End If
            Dim query As String = "" & _
            "select  " & _
            "tavw.cod_tipo, " & _
            "tavw.COD_CLASE, " & _
            "clase.nombre as nombre_clase, " & _
            "tavw.cod_planta, " & _
            "tavw.nombre_planta, " & _
            "A.COD_AREA as cod_area, " & _
            "A.NOMBRE as Area, " & _
            "tavw.COD_TURNO,tavw.cod_comp,tavw.compania,'' as fechareporte,count(PersonalVW.reloj) as Headcount, " & _
            "sum (case when rtrim(tipo_aus)='FI' then 1 else 0 end) as Faltas, " & _
            "sum (case when rtrim(tipo_aus) in ('VAC') then 1 else 0 end) as Vacaciones, " & _
            "sum (case when rtrim(tipo_aus) in ('MAT','NAC','PGO','PSG','FUN','PSV') then 1 else 0 end) as Permisos, " & _
            "sum (case when rtrim(tipo_aus) in ('IMP','IMS','INA','ING','INR') then 1 else 0 end) as Incapacidad,  " & _
            "count(distinct case when personalvw.baja is NULL then null else personalvw.reloj + cast(personalvw.baja as  nvarchar(10))end) as Bajas, " & _
            "0 as PorcentajeAsistencia, " & _
            "0.0 as PorcentajeRotacion, " & _
            "count(PersonalVW.reloj) as TotalDiasHabiles " & _
            "from (select * from personalvw where personalvw.inactivo <> '1' or PersonalVW.inactivo is null)PersonalVW " & _
            "left join TA.dbo.tavw " & _
            "on personalvw.reloj = tavw.reloj and  personalvw.cod_comp = tavw.cod_comp " & _
            "left join personal.dbo.clase  " & _
            "on tavw.cod_clase = clase.COD_CLASE  and tavw.cod_comp = clase.COD_COMP " & _
            "left join personal.dbo.deptos " & _
            "on tavw.cod_depto = deptos.COD_DEPTO and tavw.cod_comp = deptos.COD_COMP  " & _
            "left join (select areas.cod_area,areas.nombre,c_costos.centro_costos,areas.COD_COMP from personal.dbo.c_costos left join personal.dbo.areas on c_costos.cod_area = areas.cod_area)A  " & _
            "on deptos.CENTRO_COSTOS = A.centro_costos and deptos.COD_COMP = A.COD_COMP " & _
            "where tavw.fecha_entro BETWEEN '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and  (personalvw.inactivo <> '1' or personalvw.inactivo is null) " & _
            "GROUP BY tavw.cod_tipo,tavw.COD_CLASE,clase.nombre,tavw.cod_planta,tavw.nombre_planta,A.COD_AREA,A.NOMBRE,tavw.COD_TURNO,tavw.cod_comp,tavw.compania " & _
            "ORDER BY tavw.cod_tipo,tavw.COD_CLASE,clase.nombre,tavw.cod_planta,tavw.nombre_planta,A.COD_AREA,A.NOMBRE,tavw.COD_TURNO,tavw.cod_comp,tavw.compania "
            dtDatos = sqlExecute(query)
            query = "select distinct FECHA_ENTRO from asist where FECHA_ENTRO between '" + FechaSQL(FechaInicial) + "' and '" + FechaSQL(FechaFinal) + "' and tipo_aus = 'FES'"
            Dim dtCuentaFestivos As DataTable = sqlExecute(query, "TA")
            Dim CuentaFestivos As Integer = dtCuentaFestivos.Rows.Count

            For x As Integer = 0 To dtDatos.Rows.Count - 1 Step 1
                dtDatos.Rows(x).Item("PorcentajeAsistencia") = IIf(dtDatos.Rows(x).Item("headcount") = 0, 0, (1 - ((dtDatos.Rows(x).Item("Faltas") + dtDatos.Rows(x).Item("Permisos")) / dtDatos.Rows(x).Item("headcount"))) * 100)
                query = "" & _
                "select " & _
                "count(*) as Headcount " & _
                "from  personalvw " & _
                "where " & _
                "cod_tipo ='" & dtDatos.Rows(x).Item("COD_TIPO") & "' and " & _
                "COD_CLASE= '" & dtDatos.Rows(x).Item("COD_CLASE") & "' and  " & _
                "cod_planta= '" & dtDatos.Rows(x).Item("COD_PLANTA") & "' and " & _
                "cod_turno = '" & dtDatos.Rows(x).Item("COD_TURNO") & "' and " & _
                "COD_COMP = '" & dtDatos.Rows(x).Item("COD_COMP") & "' and " & _
                "nombre_AREA = '" & dtDatos.Rows(x).Item("AREA") & "' and " & _
                " (baja is NULL or baja > '" & FechaSQL(fechaTemp) & "') " & _
                "and alta <= '" & FechaSQL(fechaTemp) & "' and (personalvw.inactivo <> '1' or personalvw.inactivo is null)"
                Dim dtHeadcount As DataTable = sqlExecute(query)
                Dim valorAnterior As String = dtDatos.Rows(x).Item("headcount")
                Dim valorNuevo As String = dtHeadcount.Rows(0).Item("headcount")
                If dtHeadcount.Rows.Count > 0 Then
                    dtDatos.Rows(x).Item("headcount") = dtHeadcount.Rows(0).Item("headcount")
                End If
                query = "" & _
                "select " & _
                "count(*) as Bajas " & _
                "from  personalvw " & _
                "where " & _
                "cod_tipo ='" & dtDatos.Rows(x).Item("COD_TIPO") & "' and " & _
                "COD_CLASE= '" & dtDatos.Rows(x).Item("COD_CLASE") & "' and  " & _
                "cod_planta= '" & dtDatos.Rows(x).Item("COD_PLANTA") & "' and " & _
                "cod_turno = '" & dtDatos.Rows(x).Item("COD_TURNO") & "' and " & _
                "COD_COMP = '" & dtDatos.Rows(x).Item("COD_COMP") & "' and " & _
                "nombre_AREA = '" & dtDatos.Rows(x).Item("AREA") & "' and " & _
                "COD_MOT_BA <> '06' " & _
                "and baja BETWEEN '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and (personalvw.inactivo <> '1' or personalvw.inactivo is null) "
                Dim dtbajas As DataTable = sqlExecute(query)
                If dtbajas.Rows.Count > 0 Then
                    dtDatos.Rows(x).Item("Bajas") = dtbajas.Rows(0).Item("Bajas")
                End If
                'If dtDatos.Rows(x).Item("bajas") > 0 Then
                '    Stop
                'End If
                Dim pr As Double = IIf(dtDatos.Rows(x).Item("headcount") = 0, 0, dtDatos.Rows(x).Item("bajas") / dtDatos.Rows(x).Item("headcount"))
                dtDatos.Rows(x).Item("TotalDiasHabiles") = 5 - CuentaFestivos
                dtDatos.Rows(x).Item("PorcentajeRotacion") = pr
                dtDatos.Rows(x).Item("fechareporte") = "Semana " + NumSem + " del " + FechaLetra(FechaInicial) + " al " + FechaLetra(FechaFinal)
            Next

            If PlantaReporteDiario <> "***" Then
                dtDatos = dtDatos.Select("cod_planta = '" & PlantaReporteDiario & "'").CopyToDataTable
            End If

            dtDatos.Columns.Add("filtro_planta")
            For Each row As DataRow In dtDatos.Rows
                row("filtro_planta") = PlantaReporteDiario
            Next

        Else
            'If ReporteDiario Then
            '    ReporteDiario = False
            'Else
            '    ReporteDiario = True
            'End If
            ReporteDiario = False
            Dim qu As String = "" & _
                "SELECT PersonalVW.*,I.fecha_inac " & _
                "from personalvw left join " & _
                "(SELECT distinct reloj,max(fecha) as fecha_inac " & _
                " FROM BITACORA_PERSONAL " & _
                " WHERE CAMPO = 'INACTIVO' " & _
                " group by reloj)I " & _
                "ON PERSONALVW.RELOJ = I.RELOJ " & _
                "WHERE PERSONALVW.INACTIVO = '1' and personalvw.baja is null "

            Dim dtPersonalInactivo As DataTable = sqlExecute(qu)
            dtDatos = dtPersonalInactivo.Copy

            'If PlantaReporteDiario <> "***" Then
            '    dtDatos = dtDatos.Select("cod_planta = '" & PlantaReporteDiario & "'").CopyToDataTable
            'End If

        End If

    End Sub


#Region "backup 3 de junio Reporte_Diario"
    'Public Sub BRP_ReporteDiario(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal DataSet As String)
    '    If ReporteDiario Then
    '        frmSeleccionarFecha.ShowDialog()
    '    End If
    '    If DataSet.Equals("Diario_COD") Then
    '        If ReporteDiario Then
    '            ReporteDiario = False
    '        Else
    '            ReporteDiario = True
    '        End If
    '        Dim query As String = "" & _
    '        "select " & _
    '         "personalvw.COD_TIPO," & _
    '        "personalvw.COD_CLASE," & _
    '        "personalvw.nombre_clase," & _
    '        "personalvw.COD_PLANTA," & _
    '        "PersonalVW.nombre_planta," & _
    '        "case when PersonalVW.COD_AREA in ('04','09','28') then 'FAB' else personalvw.cod_area end as cod_Area," & _
    '        "case when PersonalVW.COD_AREA in ('04','09','28') then 'Fabricación' else personalvw.nombre_area end as Area," & _
    '        "personalvw.COD_TURNO," & _
    '        "personalvw.COD_COMP," & _
    '        "personalvw.compania," & _
    '"'" & FechaMediaLetra(FechaInicial) & "' as fechaReporte," & _
    '"sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end) as Headcount," & _
    '"sum (case when rtrim(tavw.tipo_aus)='FI'  then 1 else 0 end) as Faltas," & _
    '"sum (case when rtrim(tavw.tipo_aus) in ('SU1','SU3','SU8') then 1 else 0 end) as Suspenciones," & _
    '"sum (case when rtrim(tavw.tipo_aus) in ('MAT','NAC','PGO','PSG','FUN') then 1 else 0 end) as Permisos," & _
    '"sum (case when rtrim(tavw.tipo_aus) in ('ING','INR') then 1 else 0 end) as Incapacidad," & _
    '"sum (case when personalvw.baja  = '" & FechaSQL(FechaInicial) & "' and rtrim(personalvw.COD_MOT_BA)<> '06' then 1 else 0 end) as Bajas," & _
    '"case when sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end) = 0 then 0 else (1-(CONVERT(FLOAT(53),((sum (case when rtrim(tipo_aus)='FI' then 1 else 0 end)) + (sum (case when rtrim(tipo_aus) in ('SU1','SU3','SU8') then 1 else 0 end)) + (sum (case when rtrim(tipo_aus) in ('MAT','NAC','PGO','PSG','FUN') then 1 else 0 end)) ))/sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end)))*100 end as PorcentajeAsistencia," & _
    '"case when sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end) = 0 then 0  else (CAST(sum (case when personalvw.baja  = '" & FechaSQL(FechaInicial) & "' and rtrim(personalvw.COD_MOT_BA) <> '06' then 1 else 0 end) AS FLOAT(53))/CAST(sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end) AS FLOAT(53)))*100 end  as PorcentajeRotacion," & _
    '"sum (case when tavw.fecha_entro  is not null  then 1 else 0 end) as TotalDiasHabiles," & _
    '"sum (case when personalvw.alta  = '" & FechaSQL(FechaInicial) & "' then 1 else 0 end) as Altas " & _
    '"from personal.dbo.PersonalVW " & _
    '"left join (select distinct reloj,fecha_entro,max(tipo_aus) as tipo_aus	 from ta.dbo.tavw where fecha_entro = '" & FechaSQL(FechaInicial) & "' GROUP BY reloj,fecha_entro)tavw " & _
    '"on personalvw.reloj = tavw.reloj " & _
    '"GROUP BY " & _
    '"personalvw.COD_TIPO," & _
    '"personalvw.COD_CLASE," & _
    '"personalvw.nombre_clase," & _
    '"personalvw.COD_PLANTA," & _
    '"PersonalVW.nombre_planta," & _
    '"case when PersonalVW.COD_AREA in ('04','09','28') then 'FAB' else personalvw.cod_area end," & _
    '"case when PersonalVW.COD_AREA in ('04','09','28') then 'Fabricación' else personalvw.nombre_area end," & _
    '"personalvw.COD_TURNO," & _
    '"personalvw.COD_COMP," & _
    '"personalvw.compania " & _
    '"ORDER BY personalvw.COD_TIPO," & _
    '"personalvw.COD_CLASE," & _
    '"personalvw.nombre_clase," & _
    '"personalvw.COD_PLANTA," & _
    '"PersonalVW.nombre_planta," & _
    '"case when PersonalVW.COD_AREA in ('04','09','28') then 'FAB' else personalvw.cod_area end," & _
    '"case when PersonalVW.COD_AREA in ('04','09','28') then 'Fabricación' else personalvw.nombre_area end," & _
    '"personalvw.COD_TURNO," & _
    '"personalvw.COD_COMP," & _
    '"personalvw.compania"
    '        dtDatos = sqlExecute(query)
    '    Else
    '        If ReporteDiario Then
    '            ReporteDiario = False
    '        Else
    '            ReporteDiario = True
    '        End If

    '        Dim NumSem As String = ""
    '        Dim fechaTemp As Date = FechaInicial
    '        Dim fechaPivote As Date = FechaInicial.AddDays(-7)
    '        Dim dtPeriodo As DataTable = sqlExecute("select * from  periodos where fecha_ini <= '" & FechaSQL(fechaPivote) & "' and fecha_fin >= '" & FechaSQL(fechaPivote) & "'", "ta")
    '        If dtPeriodo.Rows.Count > 0 Then
    '            FechaInicial = dtPeriodo.Rows(0).Item("fecha_ini")
    '            FechaFinal = dtPeriodo.Rows(0).Item("fecha_fin")
    '            NumSem = dtPeriodo.Rows(0).Item("periodo")
    '        End If
    '        Dim query As String = "" & _
    '        "select  " & _
    '        "tavw.cod_tipo, " & _
    '        "tavw.COD_CLASE, " & _
    '        "clase.nombre as nombre_clase, " & _
    '        "tavw.cod_planta, " & _
    '        "tavw.nombre_planta, " & _
    '        "A.COD_AREA as cod_area, " & _
    '        "A.NOMBRE as Area, " & _
    '        "tavw.COD_TURNO,tavw.cod_comp,tavw.compania,'' as fechareporte,count(PersonalVW.reloj) as Headcount, " & _
    '        "sum (case when rtrim(tipo_aus)='FI' then 1 else 0 end) as Faltas, " & _
    '        "sum (case when rtrim(tipo_aus) in ('SU1','SU3','SU8') then 1 else 0 end) as Suspenciones, " & _
    '        "sum (case when rtrim(tipo_aus) in ('MAT','NAC','PGO','PSG','FUN') then 1 else 0 end) as Permisos, " & _
    '        "sum (case when rtrim(tipo_aus) in ('ING','INR') then 1 else 0 end) as Incapacidad,  " & _
    '        "count(distinct case when personalvw.baja is NULL then null else personalvw.reloj + cast(personalvw.baja as  nvarchar(10))end) as Bajas, " & _
    '        "0 as PorcentajeAsistencia, " & _
    '        "0.0 as PorcentajeRotacion, " & _
    '        "count(PersonalVW.reloj) as TotalDiasHabiles " & _
    '        "from personal.dbo.PersonalVW  " & _
    '        "left join TA.dbo.tavw " & _
    '        "on personalvw.reloj = tavw.reloj and  personalvw.cod_comp = tavw.cod_comp " & _
    '        "left join personal.dbo.clase  " & _
    '        "on tavw.cod_clase = clase.COD_CLASE  and tavw.cod_comp = clase.COD_COMP " & _
    '        "left join personal.dbo.deptos " & _
    '        "on tavw.cod_depto = deptos.COD_DEPTO and tavw.cod_comp = deptos.COD_COMP  " & _
    '        "left join (select areas.cod_area,areas.nombre,c_costos.centro_costos,areas.COD_COMP from personal.dbo.c_costos left join personal.dbo.areas on c_costos.cod_area = areas.cod_area)A  " & _
    '        "on deptos.CENTRO_COSTOS = A.centro_costos and deptos.COD_COMP = A.COD_COMP " & _
    '        "where tavw.fecha_entro BETWEEN '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'  " & _
    '        "GROUP BY tavw.cod_tipo,tavw.COD_CLASE,clase.nombre,tavw.cod_planta,tavw.nombre_planta,A.COD_AREA,A.NOMBRE,tavw.COD_TURNO,tavw.cod_comp,tavw.compania " & _
    '        "ORDER BY tavw.cod_tipo,tavw.COD_CLASE,clase.nombre,tavw.cod_planta,tavw.nombre_planta,A.COD_AREA,A.NOMBRE,tavw.COD_TURNO,tavw.cod_comp,tavw.compania "
    '        dtDatos = sqlExecute(query)
    '        For x As Integer = 0 To dtDatos.Rows.Count - 1 Step 1
    '            dtDatos.Rows(x).Item("PorcentajeAsistencia") = IIf(dtDatos.Rows(x).Item("headcount") = 0, 0, (1 - ((dtDatos.Rows(x).Item("Faltas") + dtDatos.Rows(x).Item("Suspenciones") + dtDatos.Rows(x).Item("Permisos")) / dtDatos.Rows(x).Item("headcount"))) * 100)
    '            query = "" & _
    '            "select " & _
    '            "count(*) as Headcount " & _
    '            "from  personalvw " & _
    '            "where " & _
    '            "cod_tipo ='" & dtDatos.Rows(x).Item("COD_TIPO") & "' and " & _
    '            "COD_CLASE= '" & dtDatos.Rows(x).Item("COD_CLASE") & "' and  " & _
    '            "cod_planta= '" & dtDatos.Rows(x).Item("COD_PLANTA") & "' and " & _
    '            "cod_turno = '" & dtDatos.Rows(x).Item("COD_TURNO") & "' and " & _
    '            "COD_COMP = '" & dtDatos.Rows(x).Item("COD_COMP") & "' and " & _
    '            "nombre_AREA = '" & dtDatos.Rows(x).Item("AREA") & "' and " & _
    '            " (baja is NULL or baja > '" & FechaSQL(fechaTemp) & "') " & _
    '            "and alta <= '" & FechaSQL(fechaTemp) & "'"
    '            Dim dtHeadcount As DataTable = sqlExecute(query)
    '            Dim valorAnterior As String = dtDatos.Rows(x).Item("headcount")
    '            Dim valorNuevo As String = dtHeadcount.Rows(0).Item("headcount")
    '            If dtHeadcount.Rows.Count > 0 Then
    '                dtDatos.Rows(x).Item("headcount") = dtHeadcount.Rows(0).Item("headcount")
    '            End If
    '            query = "" & _
    '            "select " & _
    '            "count(*) as Bajas " & _
    '            "from  personalvw " & _
    '            "where " & _
    '            "cod_tipo ='" & dtDatos.Rows(x).Item("COD_TIPO") & "' and " & _
    '            "COD_CLASE= '" & dtDatos.Rows(x).Item("COD_CLASE") & "' and  " & _
    '            "cod_planta= '" & dtDatos.Rows(x).Item("COD_PLANTA") & "' and " & _
    '            "cod_turno = '" & dtDatos.Rows(x).Item("COD_TURNO") & "' and " & _
    '            "COD_COMP = '" & dtDatos.Rows(x).Item("COD_COMP") & "' and " & _
    '            "nombre_AREA = '" & dtDatos.Rows(x).Item("AREA") & "' and " & _
    '            "COD_MOT_BA <> '06' " & _
    '            "and baja BETWEEN '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'  "
    '            Dim dtbajas As DataTable = sqlExecute(query)
    '            If dtbajas.Rows.Count > 0 Then
    '                dtDatos.Rows(x).Item("Bajas") = dtbajas.Rows(0).Item("Bajas")
    '            End If
    '            'If dtDatos.Rows(x).Item("bajas") > 0 Then
    '            '    Stop
    '            'End If
    '            Dim pr As Double = IIf(dtDatos.Rows(x).Item("headcount") = 0, 0, dtDatos.Rows(x).Item("bajas") / dtDatos.Rows(x).Item("headcount"))
    '            dtDatos.Rows(x).Item("PorcentajeRotacion") = pr
    '            dtDatos.Rows(x).Item("fechareporte") = "Semana " + NumSem + " del " + FechaLetra(FechaInicial) + " al " + FechaLetra(FechaFinal)
    '        Next


    '    End If

    'End Sub

#End Region

#Region "BkVIejo Reporte diario"
    'BRP_Reporte diario creado por carlos
    '    Public Sub BRP_ReporteDiario(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
    '        frmSeleccionarFecha.ShowDialog()
    '        Dim query As String = "" & _
    '    "select " & _
    '"personalvw.COD_TIPO," & _
    '"personalvw.COD_CLASE," & _
    '"personalvw.nombre_clase," & _
    '"personalvw.COD_PLANTA," & _
    '"PersonalVW.nombre_planta," & _
    '"case when PersonalVW.COD_AREA in ('04','09','28') then 'FAB' else personalvw.cod_area end as cod_Area," & _
    '"case when PersonalVW.COD_AREA in ('04','09','28') then 'Fabricación' else personalvw.nombre_area end as Area," & _
    '"personalvw.COD_TURNO," & _
    '"personalvw.COD_COMP," & _
    '"personalvw.compania," & _
    '"'" & FechaMediaLetra(FechaInicial) & "' as fechaReporte," & _
    '"sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end) as Headcount," & _
    '"sum (case when rtrim(tavw.tipo_aus)='FI'  then 1 else 0 end) as Faltas," & _
    '"sum (case when rtrim(tavw.tipo_aus) in ('SU1','SU3','SU8') then 1 else 0 end) as Suspenciones," & _
    '"sum (case when rtrim(tavw.tipo_aus) in ('MAT','NAC','PGO','PSG','FUN') then 1 else 0 end) as Permisos," & _
    '"sum (case when rtrim(tavw.tipo_aus) in ('ING','INR') then 1 else 0 end) as Incapacidad," & _
    '"sum (case when personalvw.baja  = '" & FechaSQL(FechaInicial) & "' and rtrim(personalvw.COD_MOT_BA)<> '06' then 1 else 0 end) as Bajas," & _
    '"case when sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end) = 0 then 0 else (1-(CONVERT(FLOAT(53),((sum (case when rtrim(tipo_aus)='FI' then 1 else 0 end)) + (sum (case when rtrim(tipo_aus) in ('SU1','SU3','SU8') then 1 else 0 end)) + (sum (case when rtrim(tipo_aus) in ('MAT','NAC','PGO','PSG','FUN') then 1 else 0 end)) ))/sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end)))*100 end as PorcentajeAsistencia," & _
    '"case when sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end) = 0 then 0  else (CAST(sum (case when personalvw.baja  = '" & FechaSQL(FechaInicial) & "' and rtrim(personalvw.COD_MOT_BA) <> '06' then 1 else 0 end) AS FLOAT(53))/CAST(sum (case when personalvw.alta <='" & FechaSQL(FechaInicial) & "'  and (personalvw.baja > '" & FechaSQL(FechaInicial) & "' or  personalvw.baja is null) then 1 else 0 end) AS FLOAT(53)))*100 end  as PorcentajeRotacion," & _
    '"sum (case when tavw.fecha_entro  is not null  then 1 else 0 end) as TotalDiasHabiles," & _
    '"sum (case when personalvw.alta  = '" & FechaSQL(FechaInicial) & "' then 1 else 0 end) as Altas " & _
    '"from personal.dbo.PersonalVW " & _
    '"left join (select distinct reloj,fecha_entro,max(tipo_aus) as tipo_aus	 from ta.dbo.tavw where fecha_entro = '" & FechaSQL(FechaInicial) & "' GROUP BY reloj,fecha_entro)tavw " & _
    '"on personalvw.reloj = tavw.reloj " & _
    '"GROUP BY " & _
    '"personalvw.COD_TIPO," & _
    '"personalvw.COD_CLASE," & _
    '"personalvw.nombre_clase," & _
    '"personalvw.COD_PLANTA," & _
    '"PersonalVW.nombre_planta," & _
    '"case when PersonalVW.COD_AREA in ('04','09','28') then 'FAB' else personalvw.cod_area end," & _
    '"case when PersonalVW.COD_AREA in ('04','09','28') then 'Fabricación' else personalvw.nombre_area end," & _
    '"personalvw.COD_TURNO," & _
    '"personalvw.COD_COMP," & _
    '"personalvw.compania " & _
    '"ORDER BY personalvw.COD_TIPO," & _
    '"personalvw.COD_CLASE," & _
    '"personalvw.nombre_clase," & _
    '"personalvw.COD_PLANTA," & _
    '"PersonalVW.nombre_planta," & _
    '"case when PersonalVW.COD_AREA in ('04','09','28') then 'FAB' else personalvw.cod_area end," & _
    '"case when PersonalVW.COD_AREA in ('04','09','28') then 'Fabricación' else personalvw.nombre_area end," & _
    '"personalvw.COD_TURNO," & _
    '"personalvw.COD_COMP," & _
    '"personalvw.compania"


    '        '"select  " & _
    '        '"personalvw.COD_TIPO," & _
    '        '"personalvw.COD_CLASE," & _
    '        '"personalvw.nombre_clase," & _
    '        '"personalvw.COD_PLANTA," & _
    '        '"PersonalVW.nombre_planta," & _
    '        '"personalvw.nombre_area AS Area," & _
    '        '"personalvw.COD_TURNO," & _
    '        '"personalvw.COD_COMP," & _
    '        '"personalvw.compania," & _
    '        '"'" & FechaMediaLetra(FechaInicial) & "' as fechaReporte," & _
    '        '"sum (case when  personalvw.ALTA <=  '" & FechaSQL(FechaInicial) & "'  and (personalvw.baja is null or personalvw.baja > '" & FechaSQL(FechaInicial) & "' )  then 1 else 0 end) as Headcount," & _
    '        '"sum (case when rtrim(tavw.tipo_aus)='FI'  then 1 else 0 end) as Faltas," & _
    '        '"sum (case when rtrim(tavw.tipo_aus) in ('SU1','SU3','SU8') then 1 else 0 end) as Suspenciones," & _
    '        '"sum (case when rtrim(tavw.tipo_aus) in ('MAT','NAC','PGO','PSG','FUN') then 1 else 0 end) as Permisos," & _
    '        '"sum (case when rtrim(tavw.tipo_aus) in ('ING','INR') then 1 else 0 end) as Incapacidad, " & _
    '        '"sum (case when personalvw.baja  = '" & FechaSQL(FechaInicial) & "' and rtrim(personalvw.COD_MOT_BA)<> '06' then 1 else 0 end) as Bajas," & _
    '        '"case when sum (case when personalvw.baja is null then 1 else 0 end) = 0 then 0 else (1-(CONVERT(FLOAT(53),((sum (case when rtrim(tipo_aus)='FI' then 1 else 0 end)) + (sum (case when rtrim(tipo_aus) in ('SU1','SU3','SU8') then 1 else 0 end)) + (sum (case when rtrim(tipo_aus) in ('MAT','NAC','PGO','PSG','FUN') then 1 else 0 end)) + (sum (case when rtrim(tipo_aus) in ('ING','INR') then 1 else 0 end))))/sum (case when personalvw.baja is null then 1 else 0 end)))*100 end as PorcentajeAsistencia," & _
    '        '"case when sum (case when personalvw.baja is null then 1 else 0 end) = 0 then 0  else (CAST(sum (case when personalvw.baja  = '" & FechaSQL(FechaInicial) & "' and rtrim(personalvw.COD_MOT_BA) <> '06' then 1 else 0 end) AS FLOAT(53)) / CAST(sum (case when personalvw.baja is null then 1 else 0 end) AS FLOAT(53)))*100 end  as PorcentajeRotacion," & _
    '        '"sum (case when tavw.fecha_entro  is not null  then 1 else 0 end) as TotalDiasHabiles " & _
    '        '"from personal.dbo.PersonalVW " & _
    '        '"left join (select distinct reloj,fecha_entro,tipo_aus  from ta.dbo.tavw where fecha_entro = '" & FechaSQL(FechaInicial) & "' GROUP BY reloj,fecha_entro,tipo_aus)tavw " & _
    '        '"on personalvw.reloj = tavw.reloj " & _
    '        '"GROUP BY personalvw.COD_TIPO,personalvw.COD_CLASE,personalvw.nombre_clase,personalvw.COD_PLANTA,PersonalVW.nombre_planta,personalvw.nombre_area,personalvw.COD_TURNO,personalvw.COD_COMP,personalvw.compania " & _
    '        '"ORDER BY personalvw.COD_TIPO,personalvw.COD_CLASE,personalvw.nombre_clase,personalvw.COD_PLANTA,PersonalVW.nombre_planta,personalvw.nombre_area,personalvw.COD_TURNO,personalvw.COD_COMP,personalvw.compania"
    '        dtDatos = sqlExecute(query)
    '    End Sub
    'Ausentismo y rotacion creado por Carlos para monica.
#End Region

    Public Sub AusentismoYRotacion(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim frm_fechas As New frmRangoFechas
        frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-31)
        frm_fechas.frmRangoFechas_fecha_fin = Now
        frm_fechas.ShowDialog()
        If frm_fechas.DialogResult = DialogResult.Cancel Then
            FechaInicial = Now.AddDays(-31)
            FechaFinal = Now
        End If
        Dim query As String = "" & _
        "select  " & _
        "tavw.cod_tipo, " & _
        "tavw.COD_CLASE, " & _
        "clase.nombre as nombre_clase, " & _
        "tavw.cod_planta, " & _
        "tavw.nombre_planta, " & _
        "A.NOMBRE as Area, " & _
        "tavw.COD_TURNO,tavw.cod_comp,tavw.compania,count(DISTINCT personalvw.reloj) as Headcount, " & _
        "sum (case when rtrim(tipo_aus)='FI' then 1 else 0 end) as Faltas, " & _
        "sum (case when rtrim(tipo_aus) in ('SU1','SU3','SU8') then 1 else 0 end) as Suspenciones, " & _
        "sum (case when rtrim(tipo_aus) in ('MAT','NAC','PGO','PSG','FUN') then 1 else 0 end) as Permisos, " & _
        "sum (case when rtrim(tipo_aus) in ('ING','INR') then 1 else 0 end) as Incapacidad,  " & _
        "count(distinct case when personalvw.baja is NULL then null else personalvw.reloj + cast(personalvw.baja as  nvarchar(10))end) as Bajas, " & _
        "(1-(CONVERT(FLOAT(53),((sum (case when rtrim(tipo_aus)='FI' then 1 else 0 end)) + (sum (case when rtrim(tipo_aus) in ('SU1','SU3','SU8') then 1 else 0 end)) + (sum (case when rtrim(tipo_aus) in ('MAT','NAC','PGO','PSG','FUN') then 1 else 0 end)) + (sum (case when rtrim(tipo_aus) in ('ING','INR') then 1 else 0 end))))/COUNT(PersonalVW.RELOJ)))*100 as PorcentajeAsistencia, " & _
        "(CAST(count(distinct case when personalvw.baja is NULL then null else personalvw.reloj + cast(personalvw.baja as  nvarchar(10))end)  AS FLOAT(53)) / CAST(count(DISTINCT personalvw.reloj) AS FLOAT(53)))*100 as PorcentajeRotacion, " & _
        "count(PersonalVW.reloj) as TotalDiasHabiles  " & _
        "from personal.dbo.PersonalVW  " & _
        "left join TA.dbo.tavw " & _
        "on personalvw.reloj = tavw.reloj and  personalvw.cod_comp = tavw.cod_comp " & _
        "left join personal.dbo.clase  " & _
        "on tavw.cod_clase = clase.COD_CLASE  and tavw.cod_comp = clase.COD_COMP " & _
        "left join personal.dbo.deptos " & _
        "on tavw.cod_depto = deptos.COD_DEPTO and tavw.cod_comp = deptos.COD_COMP  " & _
        "left join (select areas.nombre,c_costos.centro_costos,areas.COD_COMP from personal.dbo.c_costos left join personal.dbo.areas on c_costos.cod_area = areas.cod_area)A  " & _
        "on deptos.CENTRO_COSTOS = A.centro_costos and deptos.COD_COMP = A.COD_COMP " & _
        "where (personalvw.BAJA >= '" & FechaSQL(FechaInicial) & "' or personalvw.baja is null)  " & _
        "and personalvw.ALTA <= '" & FechaSQL(FechaFinal) & "'  " & _
        "and tavw.fecha_entro BETWEEN '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'  " & _
        "GROUP BY tavw.cod_tipo,tavw.COD_CLASE,clase.nombre,tavw.cod_planta,tavw.nombre_planta,A.NOMBRE,tavw.COD_TURNO,tavw.cod_comp,tavw.compania " & _
        "ORDER BY tavw.cod_tipo,tavw.COD_CLASE,clase.nombre,tavw.cod_planta,tavw.nombre_planta,A.NOMBRE,tavw.COD_TURNO,tavw.cod_comp,tavw.compania "
        dtDatos = sqlExecute(query)
        For x As Integer = 0 To dtDatos.Rows.Count - 1 Step 1
            query = "" & _
            "select " & _
            "count(*) as Headcount " & _
            "from  personalvw " & _
            "where " & _
            "cod_tipo ='" & dtDatos.Rows(x).Item("COD_TIPO") & "' and " & _
            "COD_CLASE= '" & dtDatos.Rows(x).Item("COD_CLASE") & "' and  " & _
            "cod_planta= '" & dtDatos.Rows(x).Item("COD_PLANTA") & "' and " & _
            "cod_turno = '" & dtDatos.Rows(x).Item("COD_TURNO") & "' and " & _
            "COD_COMP = '" & dtDatos.Rows(x).Item("COD_COMP") & "' and " & _
            "nombre_AREA = '" & dtDatos.Rows(x).Item("AREA") & "' and " & _
            "baja is NULL " & _
            "and alta <= '" & FechaSQL(FechaFinal) & "'"
            Dim dtHeadcount As DataTable = sqlExecute(query)
            Dim valorAnterior As String = dtDatos.Rows(x).Item("headcount")
            Dim valorNuevo As String = dtHeadcount.Rows(0).Item("headcount")
            If dtHeadcount.Rows.Count > 0 Then
                dtDatos.Rows(x).Item("headcount") = dtHeadcount.Rows(0).Item("headcount")
            End If
            query = "" & _
            "select " & _
            "count(*) as Bajas " & _
            "from  personalvw " & _
            "where " & _
            "cod_tipo ='" & dtDatos.Rows(x).Item("COD_TIPO") & "' and " & _
            "COD_CLASE= '" & dtDatos.Rows(x).Item("COD_CLASE") & "' and  " & _
            "cod_planta= '" & dtDatos.Rows(x).Item("COD_PLANTA") & "' and " & _
            "cod_turno = '" & dtDatos.Rows(x).Item("COD_TURNO") & "' and " & _
            "COD_COMP = '" & dtDatos.Rows(x).Item("COD_COMP") & "' and " & _
            "nombre_AREA = '" & dtDatos.Rows(x).Item("AREA") & "' and " & _
            "COD_MOT_BA <> '06' " & _
            "and baja BETWEEN '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'  "
            Dim dtbajas As DataTable = sqlExecute(query)
            If dtbajas.Rows.Count > 0 Then
                dtDatos.Rows(x).Item("Bajas") = dtbajas.Rows(0).Item("Bajas")
            End If
        Next
        EncabezadoReporte = "Del " & FechaMediaLetra(FechaInicial) & " al " & FechaMediaLetra(FechaFinal)

    End Sub
    'Compa ratio *************carlos************************
    Public Sub CompaRatio(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim RelojFiltro As String = "("
        For Each row As DataRow In dtInformacion.Rows
            RelojFiltro = RelojFiltro & "'" & row.Item("reloj") & "',"
        Next
        RelojFiltro = RelojFiltro & ")"
        If RelojFiltro.Equals("()") Then
            RelojFiltro = ""

        Else
            RelojFiltro = "and reloj in " & RelojFiltro.Replace(",)", ")")

        End If
        dtDatos = sqlExecute("select personalvw.*,niveles.med from personalvw left join niveles on niveles.nivel = personalvw.nivel and niveles.cod_comp = personalvw.cod_comp  where personalvw.cod_tipo='A' " & RelojFiltro)
    End Sub
    Public Sub Cambiosporantiguedad(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos = New DataTable
        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
        dtDatos.Columns.Add("alta", Type.GetType("System.String"))
        dtDatos.Columns.Add("nivel", Type.GetType("System.String"))
        dtDatos.Columns.Add("sactual", Type.GetType("System.String"))
        dtDatos.Columns.Add("nuevo_nivel", Type.GetType("System.String"))
        dtDatos.Columns.Add("nuevo_sueldo", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_puesto", Type.GetType("System.String"))
        dtDatos.Columns.Add("fecha_cambio", Type.GetType("System.String"))
        dtDatos.Columns.Add("tipo_antiguedad", Type.GetType("System.String"))
        dtDatos.Columns.Add("fecha_aplicacion", Type.GetType("System.String"))
        dtDatos.Columns.Add("FECHA_INICIO", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("FECHA_FIN", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("cod_comp", Type.GetType("System.String"))

        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}

        Dim filtros As String = frmReporteador.FiltrosAcumulados
        Dim frm_fechas As New frmRangoFechas
        frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
        frm_fechas.frmRangoFechas_fecha_fin = Now
        frm_fechas.ShowDialog()

        Dim dtMod As DataTable
        'BG 09/03/16 ***CAMBIOS POR ANTIGUEDAD DE TRANSFERENCIAS***
        Dim dtTransferencias As DataTable = sqlExecute("SELECT transferencias.reloj_nuevo,alta_anterior,PersonalVW.* FROM transferencias LEFT JOIN PERSONALVW ON transferencias.reloj_nuevo=PersonalVW.RELOJ WHERE transferencias.reloj_nuevo in (select reloj from personalvw where baja is null and cod_tipo='O' and " & filtros & ") order by alta_anterior desc")
        For Each row As DataRow In dtTransferencias.Rows
            dtMod = sqlExecute("select top 1 * from mod_sal where reloj='" & row("reloj_nuevo") & "' order by fecha desc")
            If dtMod.Rows.Count > 0 Then
                If Trim(dtMod.Rows(0)("cod_tipo_mod")) <> "PR" Or dtMod.Rows(0)("cod_tipo_mod") <> "IPP" Then
                    Try
                        Dim alta As Date = row("alta_anterior")
                        Dim fila As DataRow
                        'BG 14/09/15 Antiguedad por 6 meses
                        If alta.AddMonths(6) >= FechaSQL(FechaInicial) And alta.AddMonths(6) <= FechaSQL(FechaFinal) Then

                            fila = dtDatos.NewRow

                            fila("reloj") = row("reloj_nuevo") & " -T"
                            fila("nombres") = row("nombres")
                            fila("cod_tipo") = row("cod_tipo")
                            fila("cod_depto") = row("cod_depto")
                            fila("cod_super") = row("cod_super")
                            fila("nombre_super") = row("nombre_super")
                            fila("nombre_puesto") = row("nombre_puesto")
                            fila("cod_turno") = row("cod_turno")
                            fila("nivel") = row("nivel")
                            fila("fecha_inicio") = FechaSQL(FechaInicial)
                            fila("fecha_fin") = FechaSQL(FechaFinal)
                            Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                            If dtNuevoNivel.Rows.Count > 0 Then
                                fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                                fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                            Else
                                fila("nuevo_nivel") = ""
                                fila("nuevo_sueldo") = 0
                            End If
                            Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(6)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(6)) & "'")
                            fila("sactual") = row("sactual")
                            fila("alta") = alta
                            fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                            fila("tipo_antiguedad") = "Antigüedad 06 meses "
                            If fila("sactual") < fila("nuevo_sueldo") Or fila("nuevo_sueldo") = 0 Then dtDatos.Rows.Add(fila)

                            'BG 14/09/15 Antiguedad por 12 meses
                        ElseIf alta.AddMonths(12) >= FechaSQL(FechaInicial) And alta.AddMonths(12) <= FechaSQL(FechaFinal) Then
                            fila = dtDatos.NewRow

                            fila("reloj") = row("reloj_nuevo") & " -T"
                            fila("nombres") = row("nombres")
                            fila("cod_tipo") = row("cod_tipo")
                            fila("cod_depto") = row("cod_depto")
                            fila("cod_super") = row("cod_super")
                            fila("nombre_puesto") = row("nombre_puesto")
                            fila("nombre_super") = row("nombre_super")
                            fila("cod_turno") = row("cod_turno")
                            fila("nivel") = row("nivel")
                            fila("sactual") = row("sactual")
                            fila("fecha_inicio") = FechaSQL(FechaInicial)
                            fila("fecha_fin") = FechaSQL(FechaFinal)
                            Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                            If dtNuevoNivel.Rows.Count > 0 Then
                                fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                                fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                            Else
                                fila("nuevo_nivel") = ""
                                fila("nuevo_sueldo") = 0
                            End If

                            Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(12)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(12)) & "'")
                            fila("sactual") = row("sactual")
                            fila("alta") = alta
                            fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                            fila("tipo_antiguedad") = "Antigüedad 12 meses "

                            If fila("sactual") < fila("nuevo_sueldo") Or fila("nuevo_sueldo") = 0 Then dtDatos.Rows.Add(fila)

                            'BG 14/09/15 Antiguedad por 24 meses
                        ElseIf alta.AddMonths(24) >= FechaSQL(FechaInicial) And alta.AddMonths(24) <= FechaSQL(FechaFinal) Then
                            fila = dtDatos.NewRow

                            fila("reloj") = row("reloj_nuevo") & " -T"
                            fila("nombres") = row("nombres")
                            fila("cod_tipo") = row("cod_tipo")
                            fila("cod_depto") = row("cod_depto")
                            fila("cod_super") = row("cod_super")
                            fila("nombre_super") = row("nombre_super")
                            fila("nombre_puesto") = row("nombre_puesto")
                            fila("cod_turno") = row("cod_turno")
                            fila("nivel") = row("nivel")
                            fila("sactual") = row("sactual")
                            fila("fecha_inicio") = FechaSQL(FechaInicial)
                            fila("fecha_fin") = FechaSQL(FechaFinal)

                            Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                            If dtNuevoNivel.Rows.Count > 0 Then
                                fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                                fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                            Else
                                fila("nuevo_nivel") = ""
                                fila("nuevo_sueldo") = 0
                            End If

                            Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(24)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(24)) & "'")
                            fila("sactual") = row("sactual")
                            fila("alta") = alta
                            fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                            fila("tipo_antiguedad") = "Antigüedad 24 meses "

                            If fila("sactual") < fila("nuevo_sueldo") Or fila("nuevo_sueldo") = 0 Then dtDatos.Rows.Add(fila)


                        End If


                    Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
                    End Try
                Else
                    Continue For
                End If
            Else
                Try
                    Dim alta As Date = row("alta_anterior")
                    Dim fila As DataRow
                    'BG 09/03/16 ***CAMBIOS POR ANTIGUEDAD SIN NINGUNA PROMOCION/IPP (TRANSFERENCIAS)***

                    'BG 14/09/15 Antiguedad por 6 meses
                    If alta.AddMonths(6) >= FechaSQL(FechaInicial) And alta.AddMonths(6) <= FechaSQL(FechaFinal) Then

                        fila = dtDatos.NewRow

                        fila("reloj") = row("reloj_nuevo") & " -T"
                        fila("nombres") = row("nombres")
                        fila("cod_tipo") = row("cod_tipo")
                        fila("cod_depto") = row("cod_depto")
                        fila("cod_super") = row("cod_super")
                        fila("nombre_super") = row("nombre_super")
                        fila("nombre_puesto") = row("nombre_puesto")
                        fila("cod_turno") = row("cod_turno")
                        fila("nivel") = row("nivel")
                        fila("fecha_inicio") = FechaSQL(FechaInicial)
                        fila("fecha_fin") = FechaSQL(FechaFinal)
                        Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                        If dtNuevoNivel.Rows.Count > 0 Then
                            fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                            fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                        Else
                            fila("nuevo_nivel") = ""
                            fila("nuevo_sueldo") = 0
                        End If
                        Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(6)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(6)) & "'")
                        fila("sactual") = row("sactual")
                        fila("alta") = alta
                        fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                        fila("tipo_antiguedad") = "Antigüedad 06 meses "
                        If fila("sactual") < fila("nuevo_sueldo") Or fila("nuevo_sueldo") = 0 Then dtDatos.Rows.Add(fila)

                        'BG 14/09/15 Antiguedad por 12 meses
                    ElseIf alta.AddMonths(12) >= FechaSQL(FechaInicial) And alta.AddMonths(12) <= FechaSQL(FechaFinal) Then
                        fila = dtDatos.NewRow

                        fila("reloj") = row("reloj_nuevo") & " -T"
                        fila("nombres") = row("nombres")
                        fila("cod_tipo") = row("cod_tipo")
                        fila("cod_depto") = row("cod_depto")
                        fila("cod_super") = row("cod_super")
                        fila("nombre_puesto") = row("nombre_puesto")
                        fila("nombre_super") = row("nombre_super")
                        fila("cod_turno") = row("cod_turno")
                        fila("nivel") = row("nivel")
                        fila("sactual") = row("sactual")
                        fila("fecha_inicio") = FechaSQL(FechaInicial)
                        fila("fecha_fin") = FechaSQL(FechaFinal)
                        Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                        If dtNuevoNivel.Rows.Count > 0 Then
                            fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                            fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                        Else
                            fila("nuevo_nivel") = ""
                            fila("nuevo_sueldo") = 0
                        End If

                        Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(12)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(12)) & "'")
                        fila("sactual") = row("sactual")
                        fila("alta") = alta
                        fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                        fila("tipo_antiguedad") = "Antigüedad 12 meses "

                        If fila("sactual") < fila("nuevo_sueldo") Or fila("nuevo_sueldo") = 0 Then dtDatos.Rows.Add(fila)

                        'BG 14/09/15 Antiguedad por 24 meses
                    ElseIf alta.AddMonths(24) >= FechaSQL(FechaInicial) And alta.AddMonths(24) <= FechaSQL(FechaFinal) Then
                        fila = dtDatos.NewRow

                        fila("reloj") = row("reloj_nuevo") & " -T"
                        fila("nombres") = row("nombres")
                        fila("cod_tipo") = row("cod_tipo")
                        fila("cod_depto") = row("cod_depto")
                        fila("cod_super") = row("cod_super")
                        fila("nombre_super") = row("nombre_super")
                        fila("nombre_puesto") = row("nombre_puesto")
                        fila("cod_turno") = row("cod_turno")
                        fila("nivel") = row("nivel")
                        fila("sactual") = row("sactual")
                        fila("fecha_inicio") = FechaSQL(FechaInicial)
                        fila("fecha_fin") = FechaSQL(FechaFinal)
                        Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                        If dtNuevoNivel.Rows.Count > 0 Then
                            fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                            fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                        Else
                            fila("nuevo_nivel") = ""
                            fila("nuevo_sueldo") = 0
                        End If

                        Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(24)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(24)) & "'")
                        fila("sactual") = row("sactual")
                        fila("alta") = alta
                        fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                        fila("tipo_antiguedad") = "Antigüedad 24 meses "

                        If fila("sactual") < fila("nuevo_sueldo") Or fila("nuevo_sueldo") = 0 Then dtDatos.Rows.Add(fila)
                    End If
                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
                End Try
            End If
        Next
        'BG 09/03/16 ****CAMBIOS POR ANTIGUEDADES BRP****
        Dim dtInfo As DataTable
        dtInfo = sqlExecute("select personalvw.* from personalvw where cod_tipo='O' and baja is null and reloj not in (select reloj_nuevo from transferencias where transferencias.reloj_nuevo in (select reloj from personalvw where baja is null and cod_tipo='O')) and " & filtros & "")
        For Each row As DataRow In dtInfo.Rows
            dtMod = sqlExecute("select top 1 * from mod_sal where reloj='" & row("reloj") & "' order by fecha desc")
            If dtMod.Rows.Count > 0 Then
                If Trim(dtMod.Rows(0)("cod_tipo_mod")) <> "PR" Or dtMod.Rows(0)("cod_tipo_mod") <> "IPP" Then
                    Try
                        Dim alta As Date = row("alta")
                        Dim fila As DataRow
                        'BG 14/09/15 Antiguedad por 6 meses
                        If alta.AddMonths(6) >= FechaSQL(FechaInicial) And alta.AddMonths(6) <= FechaSQL(FechaFinal) Then

                            fila = dtDatos.NewRow

                            fila("reloj") = row("reloj")
                            fila("nombres") = row("nombres")
                            fila("cod_tipo") = row("cod_tipo")
                            fila("cod_depto") = row("cod_depto")
                            fila("cod_super") = row("cod_super")
                            fila("nombre_super") = row("nombre_super")
                            fila("nombre_puesto") = row("nombre_puesto")
                            fila("cod_turno") = row("cod_turno")
                            fila("nivel") = row("nivel")
                            fila("fecha_inicio") = FechaSQL(FechaInicial)
                            fila("fecha_fin") = FechaSQL(FechaFinal)
                            Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                            If dtNuevoNivel.Rows.Count > 0 Then
                                fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                                fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                            Else
                                fila("nuevo_nivel") = ""
                                fila("nuevo_sueldo") = 0
                            End If
                            Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(6)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(6)) & "'")
                            fila("sactual") = row("sactual")
                            fila("alta") = alta
                            fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                            fila("tipo_antiguedad") = "Antigüedad 06 meses "
                            If fila("sactual") < fila("nuevo_sueldo") Or fila("nuevo_sueldo") = 0 Then dtDatos.Rows.Add(fila)

                            'BG 14/09/15 Antiguedad por 12 meses
                        ElseIf alta.AddMonths(12) >= FechaSQL(FechaInicial) And alta.AddMonths(12) <= FechaSQL(FechaFinal) Then
                            fila = dtDatos.NewRow

                            fila("reloj") = row("reloj")
                            fila("nombres") = row("nombres")
                            fila("cod_tipo") = row("cod_tipo")
                            fila("cod_depto") = row("cod_depto")
                            fila("cod_super") = row("cod_super")
                            fila("nombre_puesto") = row("nombre_puesto")
                            fila("nombre_super") = row("nombre_super")
                            fila("cod_turno") = row("cod_turno")
                            fila("nivel") = row("nivel")
                            fila("sactual") = row("sactual")
                            fila("fecha_inicio") = FechaSQL(FechaInicial)
                            fila("fecha_fin") = FechaSQL(FechaFinal)
                            Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                            If dtNuevoNivel.Rows.Count > 0 Then
                                fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                                fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                            Else
                                fila("nuevo_nivel") = ""
                                fila("nuevo_sueldo") = 0
                            End If

                            Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(12)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(12)) & "'")
                            fila("sactual") = row("sactual")
                            fila("alta") = alta
                            fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                            fila("tipo_antiguedad") = "Antigüedad 12 meses "

                            If fila("sactual") < fila("nuevo_sueldo") Or fila("nuevo_sueldo") = 0 Then dtDatos.Rows.Add(fila)

                            'BG 14/09/15 Antiguedad por 24 meses
                        ElseIf alta.AddMonths(24) >= FechaSQL(FechaInicial) And alta.AddMonths(24) <= FechaSQL(FechaFinal) Then
                            fila = dtDatos.NewRow

                            fila("reloj") = row("reloj")
                            fila("nombres") = row("nombres")
                            fila("cod_tipo") = row("cod_tipo")
                            fila("cod_depto") = row("cod_depto")
                            fila("cod_super") = row("cod_super")
                            fila("nombre_super") = row("nombre_super")
                            fila("nombre_puesto") = row("nombre_puesto")
                            fila("cod_turno") = row("cod_turno")
                            fila("nivel") = row("nivel")
                            fila("sactual") = row("sactual")
                            fila("fecha_inicio") = FechaSQL(FechaInicial)
                            fila("fecha_fin") = FechaSQL(FechaFinal)

                            Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                            If dtNuevoNivel.Rows.Count > 0 Then
                                fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                                fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                            Else
                                fila("nuevo_nivel") = ""
                                fila("nuevo_sueldo") = 0
                            End If

                            Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(24)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(24)) & "'")
                            fila("sactual") = row("sactual")
                            fila("alta") = alta
                            fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                            fila("tipo_antiguedad") = "Antigüedad 24 meses "

                            If fila("sactual") < fila("nuevo_sueldo") Or fila("nuevo_sueldo") = 0 Then dtDatos.Rows.Add(fila)


                        End If


                    Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
                    End Try
                Else
                    Continue For
                End If
            Else
                Try
                    Dim alta As Date = row("alta")
                    Dim fila As DataRow
                    'BG 14/09/15 ***CAMBIOS POR ANTIGUEDAD SIN NINGUNA PROMOCION/IPP***

                    'BG 14/09/15 Antiguedad por 6 meses
                    If alta.AddMonths(6) >= FechaSQL(FechaInicial) And alta.AddMonths(6) <= FechaSQL(FechaFinal) Then

                        fila = dtDatos.NewRow

                        fila("reloj") = row("reloj")
                        fila("nombres") = row("nombres")
                        fila("cod_tipo") = row("cod_tipo")
                        fila("cod_depto") = row("cod_depto")
                        fila("cod_super") = row("cod_super")
                        fila("nombre_super") = row("nombre_super")
                        fila("nombre_puesto") = row("nombre_puesto")
                        fila("cod_turno") = row("cod_turno")
                        fila("nivel") = row("nivel")
                        fila("fecha_inicio") = FechaSQL(FechaInicial)
                        fila("fecha_fin") = FechaSQL(FechaFinal)
                        Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                        If dtNuevoNivel.Rows.Count > 0 Then
                            fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                            fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                        Else
                            fila("nuevo_nivel") = ""
                            fila("nuevo_sueldo") = 0
                        End If
                        Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(6)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(6)) & "'")
                        fila("sactual") = row("sactual")
                        fila("alta") = alta
                        fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                        fila("tipo_antiguedad") = "Antigüedad 06 meses "
                        If fila("sactual") < fila("nuevo_sueldo") Or fila("nuevo_sueldo") = 0 Then dtDatos.Rows.Add(fila)

                        'BG 14/09/15 Antiguedad por 12 meses
                    ElseIf alta.AddMonths(12) >= FechaSQL(FechaInicial) And alta.AddMonths(12) <= FechaSQL(FechaFinal) Then
                        fila = dtDatos.NewRow

                        fila("reloj") = row("reloj")
                        fila("nombres") = row("nombres")
                        fila("cod_tipo") = row("cod_tipo")
                        fila("cod_depto") = row("cod_depto")
                        fila("cod_super") = row("cod_super")
                        fila("nombre_puesto") = row("nombre_puesto")
                        fila("nombre_super") = row("nombre_super")
                        fila("cod_turno") = row("cod_turno")
                        fila("nivel") = row("nivel")
                        fila("sactual") = row("sactual")
                        fila("fecha_inicio") = FechaSQL(FechaInicial)
                        fila("fecha_fin") = FechaSQL(FechaFinal)
                        Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                        If dtNuevoNivel.Rows.Count > 0 Then
                            fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                            fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                        Else
                            fila("nuevo_nivel") = ""
                            fila("nuevo_sueldo") = 0
                        End If

                        Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(12)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(12)) & "'")
                        fila("sactual") = row("sactual")
                        fila("alta") = alta
                        fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                        fila("tipo_antiguedad") = "Antigüedad 12 meses "

                        If fila("sactual") < fila("nuevo_sueldo") Or fila("nuevo_sueldo") = 0 Then dtDatos.Rows.Add(fila)

                        'BG 14/09/15 Antiguedad por 24 meses
                    ElseIf alta.AddMonths(24) >= FechaSQL(FechaInicial) And alta.AddMonths(24) <= FechaSQL(FechaFinal) Then
                        fila = dtDatos.NewRow

                        fila("reloj") = row("reloj")
                        fila("nombres") = row("nombres")
                        fila("cod_tipo") = row("cod_tipo")
                        fila("cod_depto") = row("cod_depto")
                        fila("cod_super") = row("cod_super")
                        fila("nombre_super") = row("nombre_super")
                        fila("nombre_puesto") = row("nombre_puesto")
                        fila("cod_turno") = row("cod_turno")
                        fila("nivel") = row("nivel")
                        fila("sactual") = row("sactual")
                        fila("fecha_inicio") = FechaSQL(FechaInicial)
                        fila("fecha_fin") = FechaSQL(FechaFinal)
                        Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                        If dtNuevoNivel.Rows.Count > 0 Then
                            fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                            fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                        Else
                            fila("nuevo_nivel") = ""
                            fila("nuevo_sueldo") = 0
                        End If

                        Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(24)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(24)) & "'")
                        fila("sactual") = row("sactual")
                        fila("alta") = alta
                        fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                        fila("tipo_antiguedad") = "Antigüedad 24 meses "

                        If fila("sactual") < fila("nuevo_sueldo") Or fila("nuevo_sueldo") = 0 Then dtDatos.Rows.Add(fila)
                    End If
                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
                End Try
            End If
        Next

        'BG 14/09/15 ***PROMOCIONES***
        Try
            'Dim dtEmpleado As DataTable = sqlExecute("select personalvw.*,mod_sal.* from personalvw left join mod_sal on personalvw.reloj=mod_sal.reloj where mod_sal.cod_tipo_mod in ('IPP','PR') and personalvw.cod_tipo='O' and baja is null and " & filtros & " ORDER BY MOD_SAL.RELOJ")
            Dim dtModSalPromociones As DataTable = sqlExecute("select  PersonalVW.*,  mod_sal.reloj, mod_sal.fecha, mod_sal.cod_tipo_mod, dateadd(month, 5, fecha) as mes_6 , dateadd(month, 11, fecha) as mes_12 , dateadd(month, 23, fecha) as mes_24 from mod_sal left join personalvw on personalvw.reloj = mod_sal.reloj where RTRIM(COD_TIPO_MOD) = 'PR' and mod_sal.reloj in (select reloj from personalvw where cod_tipo='O' and baja is null and " & filtros & ") and fecha is not null order by mod_sal.reloj asc, fecha asc")

            For Each row As DataRow In dtModSalPromociones.Rows
                Dim dtTipo As DataTable
                dtTipo = sqlExecute("select top 1 * from mod_sal where reloj='" & row("reloj") & "' and cod_tipo_mod = 'PR' order by fecha desc")
                Dim _r As String = row("reloj")
                Dim drDatos As DataRow = dtDatos.Rows.Find(_r)

                If drDatos Is Nothing Then
                    drDatos = dtDatos.Rows.Find(_r & " -T")
                End If

                If RTrim(dtTipo.Rows(0)("cod_tipo_mod")) = "PR" And drDatos IsNot Nothing Then
                    dtDatos.Rows.Remove(drDatos)
                End If
            Next
            Dim dtPromocionesDobles As DataTable = dtModSalPromociones

            For Each row As DataRow In dtModSalPromociones.Rows
                Dim dtTipo As DataTable
                dtTipo = sqlExecute("select top 1 * from mod_sal where reloj='" & row("reloj") & "' and cod_tipo_mod = 'PR' order by fecha desc")
                Dim _reloj As String = row("reloj")

                Dim _row_mas_reciente As DataRow = dtPromocionesDobles.Select("reloj = '" & _reloj & "'", "fecha desc")(0)

                Dim drDatos As DataRow
                drDatos = dtDatos.Rows.Find(_reloj)

                Dim existe As Boolean = True

                Try
                    Dim alta As Date = row("fecha")
                    Dim fila As DataRow



                    'BG 14/09/15 Promoción por 6 meses
                    If alta.AddMonths(5) >= FechaSQL(FechaInicial) And alta.AddMonths(5) <= FechaSQL(FechaFinal) Then
                        If RTrim(dtTipo.Rows(0)("cod_tipo_mod")) = "PR" And drDatos Is Nothing Then
                            existe = False
                            fila = dtDatos.NewRow

                            fila("reloj") = row("reloj")
                            fila("nombres") = row("nombres")
                            fila("cod_tipo") = row("cod_tipo")
                            fila("cod_depto") = row("cod_depto")
                            fila("cod_super") = row("cod_super")
                            fila("nombre_super") = row("nombre_super")
                            fila("nombre_puesto") = row("nombre_puesto")
                            fila("cod_turno") = row("cod_turno")
                            fila("nivel") = row("nivel")
                            fila("fecha_inicio") = FechaSQL(FechaInicial)
                            fila("fecha_fin") = FechaSQL(FechaFinal)
                            Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                            If dtNuevoNivel.Rows.Count > 0 Then
                                fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                                fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                            Else
                                fila("nuevo_nivel") = ""
                                fila("nuevo_sueldo") = 0
                            End If

                            Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(5)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(5)) & "'")
                            fila("sactual") = row("sactual")
                            fila("alta") = alta
                            fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                            fila("tipo_antiguedad") = "Promoción 05 meses "
                            If existe = False Then
                                dtDatos.Rows.Add(fila)
                            End If
                        End If

                        'BG 14/09/15 Promoción por 12 meses
                    ElseIf alta.AddMonths(11) >= FechaSQL(FechaInicial) And alta.AddMonths(11) <= FechaSQL(FechaFinal) Then
                        If RTrim(dtTipo.Rows(0)("cod_tipo_mod")) = "PR" And drDatos Is Nothing Then
                            existe = False
                            fila = dtDatos.NewRow

                            fila("reloj") = row("reloj")
                            fila("nombres") = row("nombres")
                            fila("cod_tipo") = row("cod_tipo")
                            fila("cod_depto") = row("cod_depto")
                            fila("cod_super") = row("cod_super")
                            fila("nombre_puesto") = row("nombre_puesto")
                            fila("nombre_super") = row("nombre_super")
                            fila("cod_turno") = row("cod_turno")
                            fila("nivel") = row("nivel")
                            fila("sactual") = row("sactual")
                            fila("fecha_inicio") = FechaSQL(FechaInicial)
                            fila("fecha_fin") = FechaSQL(FechaFinal)
                            Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                            If dtNuevoNivel.Rows.Count > 0 Then
                                fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                                fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                            Else
                                fila("nuevo_nivel") = ""
                                fila("nuevo_sueldo") = 0
                            End If
                            Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(11)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(11)) & "'")
                            fila("sactual") = row("sactual")
                            fila("alta") = alta
                            fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                            fila("tipo_antiguedad") = "Promoción 11 meses "

                            If existe = False Then
                                dtDatos.Rows.Add(fila)
                            End If
                        End If

                        'BG 14/09/15 Promoción por 24 meses
                    ElseIf alta.AddMonths(23) >= FechaSQL(FechaInicial) And alta.AddMonths(23) <= FechaSQL(FechaFinal) Then
                        If RTrim(dtTipo.Rows(0)("cod_tipo_mod")) = "PR" And drDatos Is Nothing Then
                            existe = False
                            fila = dtDatos.NewRow

                            fila("reloj") = row("reloj")
                            fila("nombres") = row("nombres")
                            fila("cod_tipo") = row("cod_tipo")
                            fila("cod_depto") = row("cod_depto")
                            fila("cod_super") = row("cod_super")
                            fila("nombre_super") = row("nombre_super")
                            fila("nombre_puesto") = row("nombre_puesto")
                            fila("cod_turno") = row("cod_turno")
                            fila("nivel") = row("nivel")
                            fila("sactual") = row("sactual")
                            fila("fecha_inicio") = FechaSQL(FechaInicial)
                            fila("fecha_fin") = FechaSQL(FechaFinal)
                            Dim dtNuevoNivel As DataTable = sqlExecute("select top 1 * from niveles where nivel > '" & row("nivel") & "' and cod_comp='" & row("cod_comp") & "' and cod_tipo='" & row("cod_tipo") & "'" & IIf(RTrim(row("cod_tipo")) = "A", "", " and sueldo is not null and substring(nivel, 1, 3) = '" & IIf(IsDBNull(row("nivel")), "", row("nivel")).ToString.PadRight(4, " ").Substring(0, 3) & "'"))
                            If dtNuevoNivel.Rows.Count > 0 Then
                                fila("nuevo_nivel") = dtNuevoNivel.Rows(0)("nivel")
                                fila("nuevo_sueldo") = dtNuevoNivel.Rows(0)("sueldo")
                            Else
                                fila("nuevo_nivel") = ""
                                fila("nuevo_sueldo") = 0
                            End If
                            Dim fecha As DataTable = sqlExecute("select fecha_ini from ta.dbo.periodos where periodo_especial= 0 and fecha_ini<='" & FechaSQL(alta.AddMonths(23)) & "' and fecha_fin>='" & FechaSQL(alta.AddMonths(23)) & "'")
                            fila("sactual") = row("sactual")
                            fila("alta") = alta
                            fila("fecha_cambio") = fecha.Rows(0)("fecha_ini")
                            fila("tipo_antiguedad") = "Promoción 23 meses "
                            If existe = False Then
                                dtDatos.Rows.Add(fila)
                            End If
                        End If
                    End If


                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
                End Try
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try
        'BG 14/09/15 ***PERIODO DE PRUEBA***
        Try
            'Dim dtEmpleado As DataTable = sqlExecute("select personalvw.*,mod_sal.* from personalvw left join mod_sal on personalvw.reloj=mod_sal.reloj where mod_sal.cod_tipo_mod in ('IPP','PR') and personalvw.cod_tipo='O' and baja is null and " & filtros & " ORDER BY MOD_SAL.RELOJ")
            Dim dtPeriodoPruebas As DataTable = sqlExecute("select * from mod_sal")
            Dim dtModSalPromociones As DataTable = sqlExecute("select  PersonalVW.*,  mod_sal.reloj, mod_sal.fecha, mod_sal.cod_tipo_mod, dateadd(month, 1, fecha) as mes_1 from mod_sal left join personalvw on personalvw.reloj = mod_sal.reloj where RTRIM(COD_TIPO_MOD) = 'IPP' and mod_sal.reloj in (select reloj from personalvw where cod_tipo='O' and baja is null and " & filtros & ") order by mod_sal.reloj asc, fecha asc")
            'Dim dtModSalPromociones As DataTable = sqlExecute("select  PersonalVW.* from personalvw where baja is null and " & filtros & "")

            For Each row As DataRow In dtModSalPromociones.Rows
                Dim dtTipo As DataTable
                dtTipo = sqlExecute("select top 1 * from mod_sal where reloj='" & row("reloj") & "'  and cod_tipo_mod = 'IPP' order by fecha desc")
                Dim _r As String = row("reloj")
                Dim drDatos As DataRow = dtDatos.Rows.Find(_r)
                If dtTipo.Rows(0)("cod_tipo_mod") = "IPP" And drDatos IsNot Nothing Then
                    If Date.Parse(drDatos("alta")) < Date.Parse(row("fecha")) Then
                        dtDatos.Rows.Remove(drDatos)
                    End If

                End If
            Next



            Dim dtPromocionesDobles As DataTable = dtModSalPromociones
            For Each row As DataRow In dtModSalPromociones.Rows
                Dim dtTipo As DataTable
                dtTipo = sqlExecute("select top 1 * from mod_sal where reloj='" & row("reloj") & "'  and cod_tipo_mod = 'IPP' order by fecha desc")

                Dim _reloj As String = row("reloj")

                Dim _row_mas_reciente As DataRow = dtPromocionesDobles.Select("reloj = '" & _reloj & "'", "fecha desc")(0)

                Dim drDatos As DataRow
                drDatos = dtDatos.Rows.Find(_reloj)

                Dim existe As Boolean = True

                If dtTipo.Rows(0)("cod_tipo_mod") = "IPP" And drDatos Is Nothing Then
                    Dim fha_fin As DataTable = sqlExecute("select top 1 fecha from mod_sal left join personalvw on personalvw.reloj = mod_sal.reloj where COD_TIPO_MOD ='IPP' and mod_sal.reloj = '" & _reloj & "' order by mod_sal.reloj asc, fecha desc")

                    existe = False

                    drDatos = dtDatos.NewRow

                    drDatos("reloj") = _row_mas_reciente("reloj")
                    drDatos("nombres") = _row_mas_reciente("nombres")
                    drDatos("cod_tipo") = _row_mas_reciente("cod_tipo")
                    drDatos("cod_depto") = _row_mas_reciente("cod_depto")
                    drDatos("cod_super") = _row_mas_reciente("cod_super")
                    drDatos("nombre_super") = _row_mas_reciente("nombre_super")
                    drDatos("cod_turno") = _row_mas_reciente("cod_turno")
                    drDatos("alta") = fha_fin.Rows(0)("fecha")
                    drDatos("nivel") = _row_mas_reciente("nivel")
                    drDatos("sactual") = _row_mas_reciente("sactual")
                    drDatos("nuevo_nivel") = ""
                    drDatos("nuevo_sueldo") = 0
                    drDatos("nombre_puesto") = _row_mas_reciente("nombre_puesto")
                    drDatos("fecha_aplicacion") = ""
                    drDatos("FECHA_INICIO") = FechaSQL(FechaInicial)
                    drDatos("FECHA_FIN") = FechaSQL(FechaFinal)
                    drDatos("cod_comp") = _row_mas_reciente("cod_comp")

                End If

                For Each column As DataColumn In dtModSalPromociones.Columns
                    If column.ColumnName.Contains("mes_") Then
                        Dim fecha As Date = _row_mas_reciente(column.ColumnName)
                        If fecha >= FechaInicial And fecha <= FechaFinal Then

                            Dim fecha_ini_periodo As Date = fecha

                            Dim dtFechaIniPeriodo As DataTable = sqlExecute("select * from periodos where isnull(periodo_especial, 0) = 0 and '" & FechaSQL(fecha) & "' between fecha_ini and fecha_fin ", "ta")
                            If dtFechaIniPeriodo.Rows.Count > 0 Then
                                fecha_ini_periodo = dtFechaIniPeriodo.Rows(0)("fecha_ini")
                            End If

                            drDatos("fecha_cambio") = FechaSQL(fecha_ini_periodo)
                            Dim meses As String = column.ColumnName.Replace("mes_", "").PadLeft(2, "0")
                            drDatos("tipo_antiguedad") = "Promoción " & meses & If(meses = "01", " mes  ", " meses")

                            If existe = False Then
                                dtDatos.Rows.Add(drDatos)
                            End If

                        End If
                    End If

                Next
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try

        dtDatosPostFunciones = dtDatos
    End Sub   

    Public Sub HeadcountActivos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        frmRangoFechas.frmRangoFechas_fecha_fin = Date.Now
        frmRangoFechas.frmRangoFechas_fecha_ini = Date.Now.AddDays(-30)
        frmRangoFechas.ShowDialog()
        Dim dtTemp As New DataTable
        Dim query As String = "select cod_comp,compania,cod_tipo,nombre_tipoemp," & _
                    "case when cod_clase='G' or COD_CLASE = 'O' then 'A' else (case when cod_clase='P'  then 'I' else COD_CLASE end) end as COD_CLASE," & _
                    "case when rtrim(NOMBRE_clase)='Gerentes' or rtrim(NOMBRE_clase)='Oficinas' then 'Administrativos' else (case when rtrim(NOMBRE_clase)='Practicante' then 'Indirectos' else NOMBRE_clase end) end as NOMBRE_clase," & _
                    "alta,baja from personal.dbo.personalvw where (cod_comp in ('090','093','099')) and (baja is null or baja >= '" + FechaSQL(FechaInicial) + "') and (alta <= '" + FechaSQL(FechaFinal) + "')"
        dtTemp = sqlExecute(query)
        dtDatos = dtTemp.Clone

        For Each row As DataRow In dtInformacion.Rows
            query = "select cod_comp,compania,cod_tipo,nombre_tipoemp," & _
                    "case when cod_clase='G' or COD_CLASE = 'O' then 'A' else (case when cod_clase='P'  then 'I' else COD_CLASE end) end as COD_CLASE," & _
                    "case when rtrim(NOMBRE_clase)='Gerentes' or rtrim(NOMBRE_clase)='Oficinas' then 'Administrativos' else (case when rtrim(NOMBRE_clase)='Practicante' then 'Indirectos' else NOMBRE_clase end) end as NOMBRE_clase," & _
                    "alta,baja from personal.dbo.personalvw where (cod_comp in ('090','093','099')) and (baja is null or baja >= '" + FechaSQL(FechaInicial) + "') and (alta <= '" + FechaSQL(FechaFinal) + "') and reloj = '" + row.Item("reloj") + "'"
            dtTemp = sqlExecute(query)
            If dtTemp.Rows.Count > 0 Then
                dtDatos.ImportRow(dtTemp.Rows(0))
            End If

        Next

    End Sub


    Public Sub SaldosDíasVacaciones(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            Dim dtTemporal As New DataTable
            Dim query As String = "" & _
            "SELECT PERSONAL.dbo.saldos_vacaciones.RELOJ, PERSONAL.dbo.saldos_vacaciones.ANO, PERSONAL.dbo.saldos_vacaciones.DIAS, PERSONAL.dbo.saldos_vacaciones.PRIMA," & _
            "PERSONAL.dbo.saldos_vacaciones.SALDO_DINERO, PERSONAL.dbo.saldos_vacaciones.SALDO_TIEMPO, PERSONAL.dbo.saldos_vacaciones.DINERO, PERSONAL.dbo.saldos_vacaciones.TIEMPO," & _
            "PERSONAL.dbo.saldos_vacaciones.COMENTARIO, PERSONAL.dbo.saldos_vacaciones.ANIVERSARIO, PERSONAL.dbo.saldos_vacaciones.FECHA_INI, PERSONAL.dbo.saldos_vacaciones.FECHA_FIN," & _
            "PERSONAL.dbo.saldos_vacaciones.FECHA_CAPTURA, PERSONAL.dbo.PersonalVW.COD_TIPO, PERSONAL.dbo.PersonalVW.COD_DEPTO, PERSONAL.dbo.PersonalVW.nombre_depto," & _
            "PERSONAL.dbo.PersonalVW.nombres, PERSONAL.dbo.PersonalVW.ALTA " & _
            "FROM PERSONAL.dbo.saldos_vacaciones " & _
            "LEFT OUTER JOIN " & _
            "PERSONAL.dbo.PersonalVW ON PERSONAL.dbo.PersonalVW.RELOJ = PERSONAL.dbo.saldos_vacaciones.RELOJ " & " where saldos_vacaciones.reloj = 'xt912' "
            dtDatos = sqlExecute(query)
            For Each row As DataRow In dtInformacion.Rows
                query = "" & _
            "SELECT top 1 PERSONAL.dbo.saldos_vacaciones.RELOJ, PERSONAL.dbo.saldos_vacaciones.ANO, PERSONAL.dbo.saldos_vacaciones.DIAS, PERSONAL.dbo.saldos_vacaciones.PRIMA," & _
            "PERSONAL.dbo.saldos_vacaciones.SALDO_DINERO, PERSONAL.dbo.saldos_vacaciones.SALDO_TIEMPO, PERSONAL.dbo.saldos_vacaciones.DINERO, PERSONAL.dbo.saldos_vacaciones.TIEMPO," & _
            "PERSONAL.dbo.saldos_vacaciones.COMENTARIO, PERSONAL.dbo.saldos_vacaciones.ANIVERSARIO, PERSONAL.dbo.saldos_vacaciones.FECHA_INI, PERSONAL.dbo.saldos_vacaciones.FECHA_FIN," & _
            "PERSONAL.dbo.saldos_vacaciones.FECHA_CAPTURA, PERSONAL.dbo.PersonalVW.COD_TIPO, PERSONAL.dbo.PersonalVW.COD_DEPTO, PERSONAL.dbo.PersonalVW.nombre_depto," & _
            "PERSONAL.dbo.PersonalVW.nombres, PERSONAL.dbo.PersonalVW.ALTA " & _
            "FROM PERSONAL.dbo.saldos_vacaciones " & _
            "LEFT OUTER JOIN " & _
            "PERSONAL.dbo.PersonalVW ON PERSONAL.dbo.PersonalVW.RELOJ = PERSONAL.dbo.saldos_vacaciones.RELOJ " & " where saldos_vacaciones.reloj = '" & row.Item("reloj") & "' " & "ORDER BY saldos_vacaciones.FECHA_CAPTURA DESC"

                dtTemporal = sqlExecute(query)
                If dtTemporal.Rows.Count > 0 Then
                    dtDatos.ImportRow(dtTemporal.Rows(0))
                End If
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub
    Public Sub Employeerecord(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtChina As DataTable = sqlExecute("select * from catalogo_china")
            dtDatos = New DataTable

            dtDatos.Columns.Add("ID", Type.GetType("System.String"))
            dtDatos.Columns.Add("EMPLOYEE_CODE", Type.GetType("System.String"))
            dtDatos.Columns.Add("NAME", Type.GetType("System.String"))
            dtDatos.Columns.Add("LAST_NAME_1", Type.GetType("System.String"))
            dtDatos.Columns.Add("LAST_NAME_2", Type.GetType("System.String"))
            dtDatos.Columns.Add("ALIAS", Type.GetType("System.String"))
            dtDatos.Columns.Add("EMPLOYEE_STATUS", Type.GetType("System.String"))
            dtDatos.Columns.Add("ORGANIZATION_UNIT", Type.GetType("System.String"))
            dtDatos.Columns.Add("DEPARTMENT", Type.GetType("System.String"))
            dtDatos.Columns.Add("RANKING", Type.GetType("System.String"))
            dtDatos.Columns.Add("POSITION", Type.GetType("System.String"))
            dtDatos.Columns.Add("DIRECT_SUPERVISOR", Type.GetType("System.String"))
            dtDatos.Columns.Add("ID_SHIFT", Type.GetType("System.String"))
            dtDatos.Columns.Add("SHIFT", Type.GetType("System.String"))
            dtDatos.Columns.Add("CATEGORY", Type.GetType("System.String"))
            dtDatos.Columns.Add("AGREEMENT_TYPE", Type.GetType("System.String"))
            dtDatos.Columns.Add("GENDER", Type.GetType("System.String"))
            dtDatos.Columns.Add("DATE_OF_BIRTH", Type.GetType("System.String"))
            dtDatos.Columns.Add("AGE", Type.GetType("System.String"))
            dtDatos.Columns.Add("BIRTH_PLACE", Type.GetType("System.String"))
            dtDatos.Columns.Add("RACE", Type.GetType("System.String"))
            dtDatos.Columns.Add("MARITAL_STATUS", Type.GetType("System.String"))
            dtDatos.Columns.Add("FEDERAL_TAXPAYER_REGISTRATION", Type.GetType("System.String"))
            dtDatos.Columns.Add("POPULATION_RECORD_UNIQUE_KEY", Type.GetType("System.String"))
            dtDatos.Columns.Add("DAILY_SALARY", Type.GetType("System.String"))
            dtDatos.Columns.Add("SOCIAL_SECURITY_NUMBER", Type.GetType("System.String"))
            dtDatos.Columns.Add("SSN_ISSUE_DATE", Type.GetType("System.String"))
            dtDatos.Columns.Add("SSN_EXPIRY_DATE", Type.GetType("System.String"))
            dtDatos.Columns.Add("SSN_ISSUING_AUTHORITY", Type.GetType("System.String"))
            dtDatos.Columns.Add("QUALIFICATION", Type.GetType("System.String"))
            dtDatos.Columns.Add("ACCOUNT_TYPE", Type.GetType("System.String"))
            dtDatos.Columns.Add("DATE_ON_BOARD", Type.GetType("System.String"))
            dtDatos.Columns.Add("TERMINATION_DATE", Type.GetType("System.String"))
            dtDatos.Columns.Add("DORMITORY_TYPE", Type.GetType("System.String"))
            dtDatos.Columns.Add("DORMITORY_STANDARD", Type.GetType("System.String"))
            dtDatos.Columns.Add("DORMITORY_ROOM_NO", Type.GetType("System.String"))
            dtDatos.Columns.Add("BED_NO", Type.GetType("System.String"))
            dtDatos.Columns.Add("RESIDENTIAL_ADDRESS", Type.GetType("System.String"))
            dtDatos.Columns.Add("PASSPORT_No", Type.GetType("System.String"))
            dtDatos.Columns.Add("PASSPORT_ISSUE_DATE", Type.GetType("System.String"))
            dtDatos.Columns.Add("PASSPORT_EXPIRY_DATE", Type.GetType("System.String"))
            dtDatos.Columns.Add("PASSPORT_ISSUE_DEPT", Type.GetType("System.String"))
            dtDatos.Columns.Add("WORKING_VISA", Type.GetType("System.String"))
            dtDatos.Columns.Add("WORKING_VISA_ISSUE_DATE", Type.GetType("System.String"))
            dtDatos.Columns.Add("WORKING_VISA_EXPIRY_DATE", Type.GetType("System.String"))
            dtDatos.Columns.Add("No_OF_CHILDREN", Type.GetType("System.String"))
            dtDatos.Columns.Add("ALLOWANCES", Type.GetType("System.String"))
            dtDatos.Columns.Add("RETIREMENT_PLAN", Type.GetType("System.String"))
            dtDatos.Columns.Add("A_C_HOLDER_NAME", Type.GetType("System.String"))
            dtDatos.Columns.Add("BANK_NAME", Type.GetType("System.String"))
            dtDatos.Columns.Add("ROUTING", Type.GetType("System.String"))
            dtDatos.Columns.Add("ACCOUNT_No", Type.GetType("System.String"))
            dtDatos.Columns.Add("HOME_PHONE_No", Type.GetType("System.String"))
            dtDatos.Columns.Add("MOBILE_PHONE_No", Type.GetType("System.String"))
            dtDatos.Columns.Add("EMERGENCY_CONTACT", Type.GetType("System.String"))
            dtDatos.Columns.Add("RELATIONSHIP", Type.GetType("System.String"))
            dtDatos.Columns.Add("EMERGENCY_CONTACT_PHONE_No", Type.GetType("System.String"))
            dtDatos.Columns.Add("SEMIMONTHLY", Type.GetType("System.String"))
            dtDatos.Columns.Add("_401K", Type.GetType("System.String"))
            dtDatos.Columns.Add("MEDICAL", Type.GetType("System.String"))
            dtDatos.Columns.Add("DENTAL", Type.GetType("System.String"))
            dtDatos.Columns.Add("_Total", Type.GetType("System.String"))


            Dim contador As Integer = 1

            For Each row As DataRow In dtChina.Rows
                dtDatos.Rows.Add({
                    contador,
                    row("EMPLOYEE_CODE"),
                    row("NAME"),
                    row("LAST_NAME_1"),
                    row("LAST_NAME_2"),
                    row("ALIAS"),
                    row("EMPLOYEE_STATUS"),
                    row("ORGANIZATION_UNIT"),
                    row("DEPARTMENT"),
                    row("RANKING"),
                    row("POSITION"),
                    row("DIRECT_SUPERVISOR"),
                    row("ID_SHIFT"),
                    row("SHIFT"),
                    row("CATEGORY"),
                    row("AGREEMENT_TYPE"),
                    row("GENDER"),
                    FechaSQL(row("DATE_OF_BIRTH")),
                    row("AGE"),
                    row("BIRTH_PLACE"),
                    row("RACE"),
                    row("MARITAL_STATUS"),
                    row("FEDERAL_TAXPAYER_REGISTRATION"),
                    row("POPULATION_RECORD_UNIQUE_KEY"),
                    "$" & Math.Round(row("DAILY_SALARY"), 2),
                    row("SOCIAL_SECURITY_NUMBER"),
                    row("SSN_ISSUE_DATE"),
                    row("SSN_EXPIRY_DATE"),
                    row("SSN_ISSUING_AUTHORITY"),
                    row("QUALIFICATION"),
                    row("ACCOUNT_TYPE"),
                    FechaSQL(row("DATE_ON_BOARD")),
                    row("TERMINATION_DATE"),
                    row("DORMITORY_TYPE"),
                    row("DORMITORY_STANDARD"),
                    row("DORMITORY_ROOM_NO"),
                    row("BED_NO"),
                    row("RESIDENTIAL_ADDRESS"),
                    row("PASSPORT_No"),
                    row("PASSPORT_ISSUE_DATE"),
                    row("PASSPORT_EXPIRY_DATE"),
                    row("PASSPORT_ISSUE_DEPT"),
                    row("WORKING_VISA"),
                    row("WORKING_VISA_ISSUE_DATE"),
                    row("WORKING_VISA_EXPIRY_DATE"),
                    row("No_OF_CHILDREN"),
                    row("ALLOWANCES"),
                    row("RETIREMENT_PLAN"),
                    row("A_C_HOLDER_NAME"),
                    row("BANK_NAME"),
                    row("ROUTING"),
                    row("ACCOUNT_No"),
                    row("HOME_PHONE_No"),
                    row("MOBILE_PHONE_No"),
                    row("EMERGENCY_CONTACT"),
                    row("RELATIONSHIP"),
                    row("EMERGENCY_CONTACT_PHONE_No"),
                    row("SEMIMONTHLY"),
                    row("_401K"),
                    row("MEDICAL"),
                    row("DENTAL"),
                    row("_Total")
                })
                contador += 1
            Next


            Dim sfd As New SaveFileDialog

            Try
                sfd.DefaultExt = ".xlsx"
                sfd.FileName = "employee_record_" & FechaSQL(Date.Now) & ".xlsx"
                sfd.OverwritePrompt = True
                If sfd.ShowDialog() = DialogResult.OK Then
                    ExportaExcel(dtDatos, sfd.FileName, "EMPLOYEE_CODE", "Example information for Mexico - Data provided on " & FechaSQL(Now))
                End If

            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Sub Listadobajas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj_alt", Type.GetType("System.String"))
            dtDatos.Columns.Add("RELOJ", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOMBRES", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_planta", Type.GetType("System.String"))
            dtDatos.Columns.Add("COD_DEPTO", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOMBRE_DEPTO", Type.GetType("System.String"))
            dtDatos.Columns.Add("COD_SUPER", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOMBRE_SUPER", Type.GetType("System.String"))
            dtDatos.Columns.Add("COD_HORA", Type.GetType("System.String"))
            dtDatos.Columns.Add("BAJA", Type.GetType("System.String"))
            dtDatos.Columns.Add("ALTA", Type.GetType("System.String"))
            dtDatos.Columns.Add("COD_MOT_IM", Type.GetType("System.String"))
            dtDatos.Columns.Add("MOTIVO_BAJA_IM", Type.GetType("System.String"))
            dtDatos.Columns.Add("COD_CLASE", Type.GetType("System.String"))
            dtDatos.Columns.Add("COD_MOT_BA", Type.GetType("System.String"))
            dtDatos.Columns.Add("MOTIVO_BAJA", Type.GetType("System.String"))
            dtDatos.Columns.Add("COD_PUESTO", Type.GetType("System.String"))
            dtDatos.Columns.Add("COD_TURNO", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOMBRE_PUESTO", Type.GetType("System.String"))
            dtDatos.Columns.Add("FECHA_INICIO", Type.GetType("System.String"))
            dtDatos.Columns.Add("FECHA_FIN", Type.GetType("System.String"))
            dtDatos.Columns.Add("DIAS", Type.GetType("System.String"))
            dtDatos.Columns.Add("RFC", Type.GetType("System.String"))
            dtDatos.Columns.Add("CURP", Type.GetType("System.String"))
            dtDatos.Columns.Add("IMSS", Type.GetType("System.String"))
            dtDatos.Columns.Add("NOMBRE_CLERK", Type.GetType("System.String"))  'Jose Hernandez 1 NOV 2018

            Dim frm_fechas As New frmRangoFechas
            frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
            frm_fechas.frmRangoFechas_fecha_fin = Now

            frm_fechas.ShowDialog()


            For Each row As DataRow In dtInformacion.Select("baja >= '" & FechaSQL(FechaInicial) & "' and baja <= '" & FechaSQL(FechaFinal) & "'")
                dtDatos.Rows.Add({row("reloj_alt"), row("reloj"), row("nombres"), row("nombre_planta"), row("cod_depto"), row("nombre_depto"), row("cod_super"), row("nombre_super"), row("cod_hora"),
                                  FechaSQL(row("baja")), FechaSQL(row("alta")), row("cod_mot_im"), row("motivo_baja_im"), row("cod_clase"),
                                  row("cod_mot_ba"), row("motivo_baja"), row("cod_puesto"), row("cod_turno"), row("nombre_puesto"),
                                  FechaSQL(FechaInicial), FechaSQL(FechaFinal), Antiguedad_Dias(row("alta"), row("baja")), row("RFC"), row("CURP"), row("IMSS").ToString.Trim & row("DIG_VER").ToString.Trim, row("nombre_clerk")})  'Jose Hernandez 1 NOV 2018
            Next
        Catch ex As Exception

        End Try


    End Sub
    Public Sub Listadoaltas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos = New DataTable
        dtDatos.Columns.Add("RELOJ")
        dtDatos.Columns.Add("SEXO")
        dtDatos.Columns.Add("RFC")
        dtDatos.Columns.Add("IMSS")
        dtDatos.Columns.Add("CURP")
        dtDatos.Columns.Add("COD_HORA")
        dtDatos.Columns.Add("COD_DEPTO")
        dtDatos.Columns.Add("NOMBRE_DEPTO")
        dtDatos.Columns.Add("COD_SUPER")
        dtDatos.Columns.Add("NOMBRE_SUPER")
        dtDatos.Columns.Add("COD_PUESTO")
        dtDatos.Columns.Add("SACTUAL")
        dtDatos.Columns.Add("nombre_puesto")
        dtDatos.Columns.Add("FECHA_INICIO")
        dtDatos.Columns.Add("FECHA_FIN")
        dtDatos.Columns.Add("ALTA")
        dtDatos.Columns.Add("NOMBRES")
        dtDatos.Columns.Add("COD_PLANTA")
        dtDatos.Columns.Add("nombre_planta")
        dtDatos.Columns.Add("COD_TURNO")
        dtDatos.Columns.Add("integrado")
        Dim frm_fechas As New frmRangoFechas
        frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
        frm_fechas.frmRangoFechas_fecha_fin = Now

        frm_fechas.ShowDialog()

        Try
            For Each row As DataRow In dtInformacion.Select("alta >= '" & FechaSQL(FechaInicial) & "' and alta <= '" & FechaSQL(FechaFinal) & "'")
                dtDatos.Rows.Add({
                                 row("reloj"),
                                 row("sexo"),
                                 row("rfc"),
                                 row("imss") & row("dig_ver"),
                                 row("curp"),
                                 row("cod_hora"),
                                 row("cod_depto"),
                                 row("nombre_depto"),
                                 row("cod_super"),
                                 row("nombre_super"),
                                 row("cod_puesto"),
                                 row("sactual"),
                                 row("nombre_puesto"),
                                 FechaSQL(FechaInicial),
                                 FechaSQL(FechaFinal),
                                 FechaSQL(Date.Parse(row("alta"))),
                                 row("nombres"),
                                 row("cod_planta"),
                                 row("nombre_planta"),
                                 row("cod_turno"),
                                 row("integrado")
                                 })
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try

    End Sub
    Public Sub Listadocambiossalario(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim dt_sal As DataTable

        Try
            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("cod_puesto")
            dtDatos.Columns.Add("cod_hora")
            dtDatos.Columns.Add("cambio_de")
            dtDatos.Columns.Add("cambio_a")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("cod_clase")
            dtDatos.Columns.Add("fecha")
            dtDatos.Columns.Add("nombre_puesto")
            dtDatos.Columns.Add("nombre")
            dtDatos.Columns.Add("FECHA_INICIO")
            dtDatos.Columns.Add("FECHA_FIN")
            dtDatos.Columns.Add("COD_COMP")
            dtDatos.Columns.Add("compania")
            dtDatos.Columns.Add("provar")
            dtDatos.Columns.Add("fact_int")
            dtDatos.Columns.Add("INTEGRADO")
            Dim filtros As String = frmReporteador.FiltrosAcumulados
            Dim frm_fechas As New frmRangoFechas
            frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
            frm_fechas.frmRangoFechas_fecha_fin = Now

            frm_fechas.ShowDialog()
            filtros = Replace(filtros, "COD_COMP", "PersonalVW.COD_COMP")
            filtros = Replace(filtros, "RELOJ", "PersonalVW.RELOJ")

            If filtros <> "" Then
                filtros = filtros & " and"
            End If

            Dim query As String =
            "select  " & _
            "personalvw.reloj," & _
            "PersonalVW.nombres," & _
            "PersonalVW.COD_HORA," & _
            "PersonalVW.COD_COMP," & _
            "PersonalVW.compania," & _
            "PersonalVW.cod_clase," & _
            "PersonalVW.COD_PUESTO," & _
            "PersonalVW.nombre_puesto," & _
            "mod_sal.CAMBIO_DE," & _
            "mod_sal.CAMBIO_A," & _
            "mod_sal.PROVAR," & _
            "mod_sal.FACT_INT," & _
            "mod_sal.INTEGRADO," & _
            "mod_sal.FECHA," & _
            "mod_sal.COD_TIPO_MOD," & _
            "tipo_mod_sal.NOMBRE " & _
            "from mod_sal " & _
            "join PersonalVW on PersonalVW.RELOJ = mod_sal.RELOJ " & _
            "join tipo_mod_sal on tipo_mod_sal.COD_TIPO_MOD = mod_sal.COD_TIPO_MOD " & _
            "where " & filtros & " mod_sal.FECHA BETWEEN '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' and aplicado = '1' and mod_sal.cod_tipo_mod <> 'IPP'"

            query = query.Replace(",mod_sal.CAMBIO_DE,", ",CASE WHEN personalvw.nivel_seguridad > " & NivelSueldos & " THEN 0 ELSE mod_sal.CAMBIO_DE END AS CAMBIO_DE,")
            query = query.Replace(",mod_sal.CAMBIO_A,", ",CASE WHEN personalvw.nivel_seguridad>" & NivelSueldos & " THEN 0 ELSE mod_sal.CAMBIO_A END AS CAMBIO_A,")
            query = query.Replace(",mod_sal.PROVAR,", ",CASE WHEN personalvw.nivel_seguridad>" & NivelSueldos & " THEN 0 ELSE mod_sal.PROVAR END AS PROVAR,")
            query = query.Replace(",mod_sal.INTEGRADO,", ",CASE WHEN personalvw.nivel_seguridad>" & NivelSueldos & " THEN 0 ELSE mod_sal.INTEGRADO END AS INTEGRADO,")

            dt_sal = sqlExecute(query)

            For Each row As DataRow In dt_sal.Rows
                dtDatos.Rows.Add({
                                     row("reloj"),
                                     row("cod_puesto"),
                                     row("cod_hora"),
                                     row("cambio_de"),
                                     row("cambio_a"),
                                     row("nombres"),
                                     row("cod_clase"),
                                     FechaSQL(row("fecha")),
                                     row("nombre_puesto"),
                                     row("nombre"),
                                     FechaSQL(FechaInicial),
                                     FechaSQL(FechaFinal),
                                     row("COD_COMP"),
                                     row("compania"),
                                     row("provar"),
                                     row("fact_int"),
                                     row("INTEGRADO")
                                     })
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try



    End Sub

    Public Sub CentroCostos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos = New DataTable
        dtDatos.Columns.Add("centro_costos")
        dtDatos.Columns.Add("nombre")
        dtDatos.Columns.Add("cod_super")
        dtDatos.Columns.Add("supervisor")

    End Sub




    'Public Sub CumplePizarron(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
    '    Try
    '        Dim Columnas(19) As DataColumn
    '        Dim i As Integer = 0
    '        Dim j As Integer
    '        Dim k As Integer = 0
    '        Dim FechaCumple As Date
    '        Dim fr As New frmRangoFechas

    '        Dim dtDatosCia As New DataTable

    '        'Crear estructura de datos
    '        dtDatos = New DataTable("Datos")
    '        Columnas(0) = New DataColumn("reloj1", System.Type.GetType("System.String"))
    '        Columnas(1) = New DataColumn("nombre1", System.Type.GetType("System.String"))
    '        Columnas(2) = New DataColumn("nombre_depto1", System.Type.GetType("System.String"))
    '        Columnas(3) = New DataColumn("cod_turno1", System.Type.GetType("System.String"))
    '        Columnas(4) = New DataColumn("fecha_cumple1", System.Type.GetType("System.String"))
    '        Columnas(5) = New DataColumn("reloj2", System.Type.GetType("System.String"))
    '        Columnas(6) = New DataColumn("nombre2", System.Type.GetType("System.String"))
    '        Columnas(7) = New DataColumn("nombre_depto2", System.Type.GetType("System.String"))
    '        Columnas(8) = New DataColumn("cod_turno2", System.Type.GetType("System.String"))
    '        Columnas(9) = New DataColumn("fecha_cumple2", System.Type.GetType("System.String"))
    '        Columnas(10) = New DataColumn("reloj3", System.Type.GetType("System.String"))
    '        Columnas(11) = New DataColumn("nombre3", System.Type.GetType("System.String"))
    '        Columnas(12) = New DataColumn("nombre_depto3", System.Type.GetType("System.String"))
    '        Columnas(13) = New DataColumn("cod_turno3", System.Type.GetType("System.String"))
    '        Columnas(14) = New DataColumn("fecha_cumple3", System.Type.GetType("System.String"))
    '        Columnas(15) = New DataColumn("foto1", System.Type.GetType("System.String"))
    '        Columnas(16) = New DataColumn("foto2", System.Type.GetType("System.String"))
    '        Columnas(17) = New DataColumn("foto3", System.Type.GetType("System.String"))
    '        Columnas(18) = New DataColumn("FechaInicial", System.Type.GetType("System.DateTime"))
    '        Columnas(19) = New DataColumn("FechaFinal", System.Type.GetType("System.DateTime"))

    '        For x = 0 To UBound(Columnas)
    '            dtDatos.Columns.Add(Columnas(x))
    '        Next

    '        'Solicitar rango de fechas
    '        fr.ShowDialog()

    '        If FechaInicial = Nothing Then
    '            'Si el rango de fecha está en blanco, salir del procedimiento
    '            Exit Sub
    '        End If

    '        k = 0
    '        For Each dRow As DataRowView In dtInformacion.DefaultView
    '            If Not IsDBNull(dRow.Item("fha_nac")) Then
    '                Try
    '                    FechaCumple = New Date(FechaInicial.Year, Month(dRow.Item("fha_nac")), Day(dRow.Item("fha_nac")))
    '                Catch ex As Exception
    '                    FechaCumple = New Date(FechaInicial.Year, Month(dRow.Item("fha_nac")), Day(dRow.Item("fha_nac")) - 1)
    '                End Try

    '                If FechaCumple >= FechaInicial.Date And FechaCumple <= FechaFinal.Date Then
    '                    j = (i Mod 3) + 1
    '                    If j = 1 Then
    '                        dtDatos.Rows.Add()
    '                        dtDatos.Rows(k).Item("FechaInicial") = FechaInicial.Date
    '                        dtDatos.Rows(k).Item("FechaFinal") = FechaFinal.Date
    '                    End If

    '                    dtDatos.Rows(k).Item("reloj" & j) = dRow.Item("reloj")
    '                    dtDatos.Rows(k).Item("nombre" & j) = dRow.Item("nombre").ToString.Trim & " " & dRow.Item("apaterno").ToString.Trim
    '                    dtDatos.Rows(k).Item("nombre_depto" & j) = dRow.Item("nombre_depto")
    '                    dtDatos.Rows(k).Item("cod_turno" & j) = dRow.Item("cod_turno")
    '                    dtDatos.Rows(k).Item("fecha_cumple" & j) = FechaLetra(FechaCumple)


    '                    If Dir(PathFoto & dRow.Item("reloj") & ".jpg") = "" Then
    '                        dtDatos.Rows(k).Item("foto" & j) = PathFoto & "nofoto.png"
    '                    Else
    '                        dtDatos.Rows(k).Item("foto" & j) = PathFoto & dRow.Item("reloj") & ".jpg"
    '                    End If
    '                    i = i + 1

    '                    If j = 3 Then
    '                        k = k + 1
    '                    End If
    '                End If
    '            End If
    '        Next
    '        Debug.Print(dtDatos.Rows.Count)
    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
    '    End Try
    'End Sub
    Public dtMultiformaExtraModSal As New DataTable

    Public Sub FormatoMultiple(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtRegistros As New DataTable
            Dim dtDatosTemp As New DataTable

            Dim dtTemp As New DataTable
            Dim _tipo_reporte As String = ""
            Try
                _tipo_reporte = dtInformacion.Rows(0).Item("tipo_reporte").ToString()
            Catch ex As Exception
                _tipo_reporte = "reporteador"
            End Try
            Dim _reloj As String = dtInformacion.Rows(0).Item("reloj").ToString
            Dim query As String = "" & _
            "select " & _
            "PersonalVW.APATERNO, PersonalVW.AMATERNO, PersonalVW.NOMBRE, personalVW.RELOJ," & _
            "PersonalVW.COD_DEPTO, PersonalVW.nombre_depto, PersonalVW.COD_SUPER, PersonalVW.nombre_super,personalvw.Centro_costos," & _
       "PersonalVW.COD_AREA, PersonalVW.nombre_area, PersonalVW.COD_PUESTO, PersonalVW.nombre_puesto," & _
       "PersonalVW.COD_TURNO, PersonalVW.nombre_turno," & _
       "PersonalVW.COD_HORA, PersonalVW.nombre_horario," & _
       "'' as FECHA_BAJA,'' AS MOTIVO_BAJA," & _
       "'' AS MOTIVO_AUSENTISMO,'' AS FECHA_INICIO,'' as CANTIDAD_DIAS," & _
       "'' AS NUEVO_DEPTO  ,'' AS NUEVO_PUESTO,'' AS NUEVO_SUPER,'' AS NUEVA_AREA," & _
       "'' AS NUEVO_TURNO,'' as NUEVO_HORARIO,'' AS SACTUAL,'' AS SACTUAL_NUEVO,'' AS SALMES,'' AS SALMES_NUEVO,'' AS FECHA_EFECTIVA,'' AS FECHA_CAPTURA,'0' as compa_ratio_ant,'0'  as compa_ratio_nvo " & _
       "from personal.dbo.PersonalVW " & _
       "where personalvw.reloj = 'XT912'"
            dtDatos = sqlExecute(query)
            If _tipo_reporte.Equals("mod_sal") Then

                dtDatos.Columns.Add("nivel")
                dtDatos.Columns.Add("nuevo_nivel")
                dtDatos.Columns.Add("notas")
                '' dtDatos.Columns.Add("compa_ratio_ant")
                ''dtDatos.Columns.Add("compa_ratio_nvo")
                For Each row As DataRow In dtInformacion.Rows
                    dtRegistros = sqlExecute("select * from mod_sal where aplicado= '0'  and reloj ='" & row.Item("reloj") & "'")
                    For Each r As DataRow In dtRegistros.Rows
                        query = "" & _
                        "select " & _
                        "PersonalVW.APATERNO, PersonalVW.AMATERNO, PersonalVW.NOMBRE, personalVW.RELOJ," & _
                        "PersonalVW.COD_DEPTO, PersonalVW.nombre_depto, PersonalVW.COD_SUPER, PersonalVW.nombre_super,personalvw.Centro_costos," & _
                        "PersonalVW.COD_AREA, PersonalVW.nombre_area, PersonalVW.COD_PUESTO, PersonalVW.nombre_puesto, personalvw.nivel," & _
                        "PersonalVW.COD_TURNO, PersonalVW.nombre_turno," & _
                        "PersonalVW.COD_HORA, PersonalVW.nombre_horario," & _
                        "'' as FECHA_BAJA,'' AS MOTIVO_BAJA," & _
                        "'' AS MOTIVO_AUSENTISMO,'' AS FECHA_INICIO,'' as CANTIDAD_DIAS," & _
                        "'' AS NUEVO_DEPTO  ,'' AS NUEVO_PUESTO,'' AS NUEVO_SUPER, '' as nuevo_nivel, '' AS NUEVA_AREA," & _
                        "'' AS NUEVO_TURNO,'' as NUEVO_HORARIO,'' AS SACTUAL,'' AS SACTUAL_NUEVO,'' AS SALMES,'' AS SALMES_NUEVO,'' AS FECHA_EFECTIVA,'' AS FECHA_CAPTURA,'0' as COMPA_RATIO_ANT,'0' AS COMPA_RATIO_NVO,'' AS notas " & _
                        "from personal.dbo.PersonalVW " & _
                        "where personalvw.reloj = '" + r.Item("reloj") + "'"
                        dtTemp = sqlExecute(query)
                        dtTemp.Rows(0).Item("SACTUAL") = r.Item("CAMBIO_DE")
                        dtTemp.Rows(0).Item("SACTUAL_NUEVO") = r.Item("CAMBIO_A")
                        dtTemp.Rows(0).Item("SALMES") = Format(r.Item("CAMBIO_DE") * 30.4, "f")
                        dtTemp.Rows(0).Item("SALMES_NUEVO") = Format(r.Item("CAMBIO_A") * 30.4, "f")
                        dtTemp.Rows(0).Item("FECHA_CAPTURA") = FechaSQL(r.Item("FECHA"))
                        dtTemp.Rows(0).Item("nuevo_nivel") = (r.Item("nivel"))
                        dtTemp.Rows(0).Item("notas") = r.Item("notas")
                        dtTemp.Rows(0).Item("COMPA_RATIO_ANT") = (r.Item("COMPA_RATIO_ANT"))
                        dtTemp.Rows(0).Item("COMPA_RATIO_NVO") = (r.Item("COMPA_RATIO_NVO"))

                        '**********************************************************************************************
                        Dim dtCAmbioPosicion As DataTable = sqlExecute("select  * from formato_multiple where confirmado = '0' and reloj ='" + _reloj + "'")

                        For Each puesto As DataRow In dtCAmbioPosicion.Rows
                            Dim dtPos As New DataTable
                            dtTemp.Rows(0).Item("FECHA_CAPTURA") = FechaSQL(puesto.Item("FECHA_CAPTURA"))
                            dtTemp.Rows(0).Item("FECHA_EFECTIVA") = FechaSQL(puesto.Item("FECHA_EFECTIVA"))

                            If puesto.Item("CAMPO").ToString.Equals("COD_SUPER") Then
                                dtPos = sqlExecute("select nombre from SUPER where cod_super ='" + puesto.Item("valor_nuevo") + "'")
                                If dtPos.Rows.Count > 0 Then
                                    dtTemp.Rows(0).Item("NUEVO_SUPER") = puesto.Item("valor_nuevo").ToString.Trim + ", " + dtPos.Rows(0).Item("nombre").ToString.Trim
                                Else
                                    dtTemp.Rows(0).Item("NUEVO_SUPER") = puesto.Item("valor_nuevo").ToString.Trim
                                End If

                            ElseIf puesto.Item("CAMPO").ToString.Equals("COD_DEPTO") Then
                                dtPos = sqlExecute("select nombre from deptos where cod_depto ='" + puesto.Item("valor_nuevo") + "'")
                                If dtPos.Rows.Count > 0 Then
                                    dtTemp.Rows(0).Item("NUEVO_DEPTO") = puesto.Item("valor_nuevo").ToString.Trim + ", " + dtPos.Rows(0).Item("nombre").ToString.Trim
                                Else
                                    dtTemp.Rows(0).Item("NUEVO_DEPTO") = puesto.Item("valor_nuevo").ToString.Trim
                                End If
                            End If
                            If puesto.Item("CAMPO").ToString.Equals("COD_PUESTO") Then
                                dtPos = sqlExecute("select nombre from puestos where cod_puesto ='" + puesto.Item("valor_nuevo") + "'")
                                If dtPos.Rows.Count > 0 Then
                                    dtTemp.Rows(0).Item("NUEVO_PUESTO") = puesto.Item("valor_nuevo").ToString.Trim + ", " + dtPos.Rows(0).Item("nombre").ToString.Trim
                                Else
                                    dtTemp.Rows(0).Item("NUEVO_PUESTO") = puesto.Item("valor_nuevo").ToString.Trim
                                End If

                            ElseIf puesto.Item("CAMPO").ToString.Equals("COD_AREA") Then
                                dtPos = sqlExecute("select nombre from areas where cod_area ='" + puesto.Item("valor_nuevo") + "'")
                                If dtPos.Rows.Count > 0 Then
                                    dtTemp.Rows(0).Item("NUEVA_AREA") = puesto.Item("valor_nuevo").ToString.Trim + ", " + dtPos.Rows(0).Item("nombre").ToString.Trim
                                Else
                                    dtTemp.Rows(0).Item("NUEVA_AREA") = puesto.Item("valor_nuevo").ToString.Trim
                                End If
                            End If
                        Next

                        '**********************************************************************************************
                        ','' as COMPA_RATIO_ANT,'' AS COMPA_RATIO_NVO
                        dtDatos.ImportRow(dtTemp.Rows(0))
                    Next

                Next
                If dtMultiformaExtraModSal.Rows.Count > 0 Then
                    For Each drow As DataRow In dtMultiformaExtraModSal.Rows
                        query = "" & _
                                               "select " & _
                                               "PersonalVW.APATERNO, PersonalVW.AMATERNO, PersonalVW.NOMBRE, personalVW.RELOJ," & _
                                               "PersonalVW.COD_DEPTO, PersonalVW.nombre_depto, PersonalVW.COD_SUPER, PersonalVW.nombre_super,personalvw.Centro_costos," & _
                                               "PersonalVW.COD_AREA, PersonalVW.nombre_area, PersonalVW.COD_PUESTO, PersonalVW.nombre_puesto, personalvw.nivel," & _
                                               "PersonalVW.COD_TURNO, PersonalVW.nombre_turno," & _
                                               "PersonalVW.COD_HORA, PersonalVW.nombre_horario," & _
                                               "'' as FECHA_BAJA,'' AS MOTIVO_BAJA," & _
                                               "'' AS MOTIVO_AUSENTISMO,'' AS FECHA_INICIO,'' as CANTIDAD_DIAS," & _
                                               "'' AS NUEVO_DEPTO  ,'' AS NUEVO_PUESTO,'' AS NUEVO_SUPER, '' as nuevo_nivel, '' AS NUEVA_AREA," & _
                                               "'' AS NUEVO_TURNO,'' as NUEVO_HORARIO,'' AS SACTUAL,'' AS SACTUAL_NUEVO,'' AS SALMES,'' AS SALMES_NUEVO,'' AS FECHA_EFECTIVA,'' AS FECHA_CAPTURA,'0' as COMPA_RATIO_ANT,'0' AS COMPA_RATIO_NVO " & _
                                               "from personal.dbo.PersonalVW " & _
                                               "where personalvw.reloj = '" + drow.Item("reloj") + "'"
                        dtTemp = sqlExecute(query)
                        dtTemp.Rows(0).Item("SACTUAL") = drow.Item("CAMBIO_DE")
                        dtTemp.Rows(0).Item("SACTUAL_NUEVO") = ""
                        dtTemp.Rows(0).Item("SALMES") = Format(drow.Item("CAMBIO_DE") * 30.4, "f")
                        dtTemp.Rows(0).Item("SALMES_NUEVO") = ""
                        dtTemp.Rows(0).Item("FECHA_CAPTURA") = FechaSQL(drow.Item("FECHA"))
                        dtTemp.Rows(0).Item("nuevo_nivel") = ""
                        dtTemp.Rows(0).Item("COMPA_RATIO_ANT") = drow.Item("COMPA_RATIO_ANT")
                        dtTemp.Rows(0).Item("COMPA_RATIO_NVO") = drow.Item("COMPA_RATIO_NVO")
                        dtDatos.ImportRow(dtTemp.Rows(0))
                    Next
                End If


                '''''''''''''''''''''''''''BERE

            ElseIf _tipo_reporte.Equals("antiguedad") Then

                dtDatos.Columns.Add("nivel")
                dtDatos.Columns.Add("nuevo_nivel")
                dtDatos.Columns.Add("notas")
                '' dtDatos.Columns.Add("compa_ratio_ant")
                ''dtDatos.Columns.Add("compa_ratio_nvo")
                'For Each row As DataRow In dtInformacion.Rows
                'dtRegistros = sqlExecute("select * from mod_sal where aplicado= '0'  and reloj ='" & row.Item("reloj") & "'")
                For Each r As DataRow In dtDatosPost.Rows
                    query = "" & _
                    "select " & _
                    "PersonalVW.APATERNO, PersonalVW.AMATERNO, PersonalVW.NOMBRE, personalVW.RELOJ," & _
                    "PersonalVW.COD_DEPTO, PersonalVW.nombre_depto, PersonalVW.COD_SUPER, PersonalVW.nombre_super,personalvw.Centro_costos," & _
                    "PersonalVW.COD_AREA, PersonalVW.nombre_area, PersonalVW.COD_PUESTO, PersonalVW.nombre_puesto, personalvw.nivel," & _
                    "PersonalVW.COD_TURNO, PersonalVW.nombre_turno," & _
                    "PersonalVW.COD_HORA, PersonalVW.nombre_horario," & _
                    "'' as FECHA_BAJA,'' AS MOTIVO_BAJA," & _
                    "'' AS MOTIVO_AUSENTISMO,'' AS FECHA_INICIO,'' as CANTIDAD_DIAS," & _
                    "'' AS NUEVO_DEPTO  ,'' AS NUEVO_PUESTO,'' AS NUEVO_SUPER, '' as nuevo_nivel, '' AS NUEVA_AREA," & _
                    "'' AS NUEVO_TURNO,'' as NUEVO_HORARIO,'' AS SACTUAL,'' AS SACTUAL_NUEVO,'' AS SALMES,'' AS SALMES_NUEVO,'' AS FECHA_EFECTIVA,'' AS FECHA_CAPTURA,'0' as COMPA_RATIO_ANT,'0' AS COMPA_RATIO_NVO,'' AS notas " & _
                    "from personal.dbo.PersonalVW " & _
                    "where personalvw.reloj = '" + r.Item("reloj").ToString.Substring(0, 6) + "'"
                    dtTemp = sqlExecute(query)
                    dtTemp.Rows(0).Item("SACTUAL") = r.Item("sactual")
                    dtTemp.Rows(0).Item("SACTUAL_NUEVO") = r.Item("nuevo_sueldo")
                    dtTemp.Rows(0).Item("SALMES") = Format(r.Item("sactual") * 30.4, "f")
                    dtTemp.Rows(0).Item("SALMES_NUEVO") = Format(r.Item("nuevo_sueldo") * 30.4, "f")
                    dtTemp.Rows(0).Item("FECHA_CAPTURA") = FechaSQL(Now)
                    dtTemp.Rows(0).Item("FECHA_EFECTIVA") = FechaSQL(r.Item("fecha_cambio")) 'REV.
                    dtTemp.Rows(0).Item("nuevo_nivel") = (r.Item("nuevo_nivel"))
                    dtTemp.Rows(0).Item("notas") = r.Item("tipo_antiguedad")
                    dtTemp.Rows(0).Item("COMPA_RATIO_ANT") = 0
                    dtTemp.Rows(0).Item("COMPA_RATIO_NVO") = 0
                    dtDatos.ImportRow(dtTemp.Rows(0))
                Next

                If dtMultiformaExtraModSal.Rows.Count > 0 Then
                    'For Each drow As DataRow In dtMultiformaExtraModSal.Rows
                    '    query = "" & _
                    '                           "select " & _
                    '                           "PersonalVW.APATERNO, PersonalVW.AMATERNO, PersonalVW.NOMBRE, personalVW.RELOJ," & _
                    '                           "PersonalVW.COD_DEPTO, PersonalVW.nombre_depto, PersonalVW.COD_SUPER, PersonalVW.nombre_super,personalvw.Centro_costos," & _
                    '                           "PersonalVW.COD_AREA, PersonalVW.nombre_area, PersonalVW.COD_PUESTO, PersonalVW.nombre_puesto, personalvw.nivel," & _
                    '                           "PersonalVW.COD_TURNO, PersonalVW.nombre_turno," & _
                    '                           "PersonalVW.COD_HORA, PersonalVW.nombre_horario," & _
                    '                           "'' as FECHA_BAJA,'' AS MOTIVO_BAJA," & _
                    '                           "'' AS MOTIVO_AUSENTISMO,'' AS FECHA_INICIO,'' as CANTIDAD_DIAS," & _
                    '                           "'' AS NUEVO_DEPTO  ,'' AS NUEVO_PUESTO,'' AS NUEVO_SUPER, '' as nuevo_nivel, '' AS NUEVA_AREA," & _
                    '                           "'' AS NUEVO_TURNO,'' as NUEVO_HORARIO,'' AS SACTUAL,'' AS SACTUAL_NUEVO,'' AS SALMES,'' AS SALMES_NUEVO,'' AS FECHA_EFECTIVA,'' AS FECHA_CAPTURA,'0' as COMPA_RATIO_ANT,'0' AS COMPA_RATIO_NVO " & _
                    '                           "from personal.dbo.PersonalVW " & _
                    '                           "where personalvw.reloj = '" + drow.Item("reloj") + "'"
                    '    dtTemp = sqlExecute(query)
                    '    dtTemp.Rows(0).Item("SACTUAL") = drow.Item("CAMBIO_DE")
                    '    dtTemp.Rows(0).Item("SACTUAL_NUEVO") = ""
                    '    dtTemp.Rows(0).Item("SALMES") = Format(drow.Item("CAMBIO_DE") * 30.4, "f")
                    '    dtTemp.Rows(0).Item("SALMES_NUEVO") = ""
                    '    dtTemp.Rows(0).Item("FECHA_CAPTURA") = FechaSQL(drow.Item("FECHA"))
                    '    dtTemp.Rows(0).Item("nuevo_nivel") = ""

                    '    dtDatos.ImportRow(dtTemp.Rows(0))
                    'Next
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            ElseIf _tipo_reporte.Equals("reporteador") Then
                For Each i As DataRow In dtInformacion.Rows
                    _reloj = i.Item("reloj")
                    query = "" & _
                              "select " & _
                              "PersonalVW.APATERNO, PersonalVW.AMATERNO, PersonalVW.NOMBRE, personalVW.RELOJ," & _
                              "PersonalVW.COD_DEPTO, PersonalVW.nombre_depto, PersonalVW.COD_SUPER, PersonalVW.nombre_super,personalvw.Centro_costos," & _
                              "PersonalVW.COD_AREA, PersonalVW.nombre_area, PersonalVW.COD_PUESTO, PersonalVW.nombre_puesto," & _
                              "PersonalVW.COD_TURNO, PersonalVW.nombre_turno," & _
                              "PersonalVW.COD_HORA, PersonalVW.nombre_horario," & _
                              "'' as FECHA_BAJA,'' AS MOTIVO_BAJA," & _
                              "'' AS MOTIVO_AUSENTISMO,'' AS FECHA_INICIO,'' as CANTIDAD_DIAS," & _
                              "'' AS NUEVO_DEPTO  ,'' AS NUEVO_PUESTO,'' AS NUEVO_SUPER,'' AS NUEVA_AREA," & _
                              "'' AS NUEVO_TURNO,'' as NUEVO_HORARIO,'' AS SACTUAL,'' AS SACTUAL_NUEVO,'' AS SALMES,'' AS SALMES_NUEVO,'' AS FECHA_EFECTIVA,'' AS FECHA_CAPTURA " & _
                              "from personal.dbo.PersonalVW " & _
                              "where personalvw.reloj = '" + _reloj + "'"
                    dtDatosTemp = sqlExecute(query)
                    dtDatos.ImportRow(dtDatosTemp.Rows(0))

                Next

            Else
                For Each f As DataRow In dtInformacion.Rows
                    _reloj = f.Item("reloj")
                    dtRegistros = sqlExecute("select  * from formato_multiple where confirmado = '0' and reloj ='" + _reloj + "'")
                    query = "" & _
                               "select " & _
                               "PersonalVW.APATERNO, PersonalVW.AMATERNO, PersonalVW.NOMBRE, personalVW.RELOJ," & _
                               "PersonalVW.COD_DEPTO, PersonalVW.nombre_depto, PersonalVW.COD_SUPER, PersonalVW.nombre_super,personalvw.Centro_costos," & _
                               "PersonalVW.COD_AREA, PersonalVW.nombre_area, PersonalVW.COD_PUESTO, PersonalVW.nombre_puesto," & _
                               "PersonalVW.COD_TURNO, PersonalVW.nombre_turno," & _
                               "PersonalVW.COD_HORA, PersonalVW.nombre_horario," & _
                               "'' as FECHA_BAJA,'' AS MOTIVO_BAJA," & _
                               "'' AS MOTIVO_AUSENTISMO,'' AS FECHA_INICIO,'' as CANTIDAD_DIAS," & _
                               "'' AS NUEVO_DEPTO  ,'' AS NUEVO_PUESTO,'' AS NUEVO_SUPER,'' AS NUEVA_AREA," & _
                               "'' AS NUEVO_TURNO,'' as NUEVO_HORARIO,'' AS SACTUAL,'' AS SACTUAL_NUEVO,'' AS SALMES,'' AS SALMES_NUEVO,'' AS FECHA_EFECTIVA,'' AS FECHA_CAPTURA,'0' as compa_ratio_nvo,'0' as compa_ratio_ant  " & _
                               "from personal.dbo.PersonalVW " & _
                               "where personalvw.reloj = '" + _reloj + "'"
                    dtDatosTemp = sqlExecute(query)
                    For Each r As DataRow In dtRegistros.Rows
                        If r.Item("tipo_movimiento").ToString.Equals("BAJA") Then
                            dtDatosTemp.Rows(0).Item("FECHA_BAJA") = FechaSQL(r.Item("FECHA_BAJA"))
                            dtDatosTemp.Rows(0).Item("FECHA_CAPTURA") = FechaSQL(r.Item("FECHA_CAPTURA"))
                            dtDatosTemp.Rows(0).Item("FECHA_EFECTIVA") = FechaSQL(r.Item("FECHA_BAJA"))
                            dtTemp = sqlExecute("select nombre from cod_mot_baj where cod_mot_ba ='" + r.Item("COD_MOT_BA") + "'")
                            If dtTemp.Rows.Count > 0 Then
                                dtDatosTemp.Rows(0).Item("MOTIVO_BAJA") = r.Item("cod_mot_ba") + ", " + dtTemp.Rows(0).Item("nombre").ToString.Trim
                            Else
                                dtDatosTemp.Rows(0).Item("MOTIVO_BAJA") = r.Item("cod_mot_ba")
                            End If
                        ElseIf r.Item("tipo_movimiento").ToString.Equals("AUSENTISMO") Then
                            dtDatosTemp.Rows(0).Item("FECHA_INICIO") = FechaSQL(r.Item("FECHA_INICIO"))
                            'dtDatosTemp.Rows(0).Item("FECHA_FIN") = FechaSQL(Date.Parse(r.Item("FECHA_INICIO").ToString).AddDays(r.Item("CANTIDAD_DIAS") - 1))
                            dtDatosTemp.Rows(0).Item("FECHA_CAPTURA") = FechaSQL(r.Item("FECHA_CAPTURA"))
                            dtDatosTemp.Rows(0).Item("FECHA_EFECTIVA") = FechaSQL(r.Item("FECHA_INICIO"))
                            dtTemp = sqlExecute("select nombre from tipo_ausentismo where tipo_aus ='" + r.Item("tipo_aus") + "'", "TA")
                            dtDatosTemp.Rows(0).Item("CANTIDAD_DIAS") = r.Item("CANTIDAD_DIAS")
                            If dtTemp.Rows.Count > 0 Then
                                dtDatosTemp.Rows(0).Item("MOTIVO_AUSENTISMO") = r.Item("TIPO_AUS") + ", " + dtTemp.Rows(0).Item("nombre").ToString.Trim
                            Else
                                dtDatosTemp.Rows(0).Item("MOTIVO_AUSENTISMO") = r.Item("TIPO_AUS")
                            End If
                        ElseIf r.Item("tipo_movimiento").ToString.Equals("TURNO") Then
                            '  dtDatosTemp.Rows(0).Item("FECHA_EFECTIVA_H") = FechaSQL(r.Item("FECHA_EFECTIVA"))
                            dtDatosTemp.Rows(0).Item("FECHA_CAPTURA") = FechaSQL(r.Item("FECHA_CAPTURA"))
                            dtDatosTemp.Rows(0).Item("FECHA_EFECTIVA") = FechaSQL(r.Item("FECHA_EFECTIVA"))

                            If r.Item("CAMPO").ToString.Equals("COD_TURNO") Then
                                dtTemp = sqlExecute("select nombre from turnos where cod_turno ='" + r.Item("valor_nuevo") + "'")
                                If dtTemp.Rows.Count > 0 Then
                                    dtDatosTemp.Rows(0).Item("NUEVO_TURNO") = r.Item("valor_nuevo").ToString.Trim + ", " + dtTemp.Rows(0).Item("nombre").ToString.Trim
                                Else
                                    dtDatosTemp.Rows(0).Item("NUEVO_TURNO") = r.Item("valor_nuevo").ToString.Trim
                                End If

                            ElseIf r.Item("CAMPO").ToString.Equals("COD_HORA") Then
                                dtTemp = sqlExecute("select nombre from horarios where cod_hora ='" + r.Item("valor_nuevo") + "'")
                                If dtTemp.Rows.Count > 0 Then
                                    dtDatosTemp.Rows(0).Item("NUEVO_HORARIO") = r.Item("valor_nuevo").ToString.Trim + ", " + dtTemp.Rows(0).Item("nombre").ToString.Trim
                                Else
                                    dtDatosTemp.Rows(0).Item("NUEVO_HORARIO") = r.Item("valor_nuevo").ToString.Trim
                                End If
                            End If
                        ElseIf r.Item("tipo_movimiento").ToString.Equals("POSICION") Then
                            'dtDatosTemp.Rows(0).Item("FECHA_EFECTIVA_P") = FechaSQL(r.Item("FECHA_EFECTIVA"))
                            dtDatosTemp.Rows(0).Item("FECHA_CAPTURA") = FechaSQL(r.Item("FECHA_CAPTURA"))
                            dtDatosTemp.Rows(0).Item("FECHA_EFECTIVA") = FechaSQL(r.Item("FECHA_EFECTIVA"))

                            If r.Item("CAMPO").ToString.Equals("COD_SUPER") Then
                                dtTemp = sqlExecute("select nombre from SUPER where cod_super ='" + r.Item("valor_nuevo") + "'")
                                If dtTemp.Rows.Count > 0 Then
                                    dtDatosTemp.Rows(0).Item("NUEVO_SUPER") = r.Item("valor_nuevo").ToString.Trim + ", " + dtTemp.Rows(0).Item("nombre").ToString.Trim
                                Else
                                    dtDatosTemp.Rows(0).Item("NUEVO_SUPER") = r.Item("valor_nuevo").ToString.Trim
                                End If

                            ElseIf r.Item("CAMPO").ToString.Equals("COD_DEPTO") Then
                                dtTemp = sqlExecute("select nombre from deptos where cod_depto ='" + r.Item("valor_nuevo") + "'")
                                If dtTemp.Rows.Count > 0 Then
                                    dtDatosTemp.Rows(0).Item("NUEVO_DEPTO") = r.Item("valor_nuevo").ToString.Trim + ", " + dtTemp.Rows(0).Item("nombre").ToString.Trim
                                Else
                                    dtDatosTemp.Rows(0).Item("NUEVO_DEPTO") = r.Item("valor_nuevo").ToString.Trim
                                End If
                            End If
                            If r.Item("CAMPO").ToString.Equals("COD_PUESTO") Then
                                dtTemp = sqlExecute("select nombre from puestos where cod_puesto ='" + r.Item("valor_nuevo") + "'")
                                If dtTemp.Rows.Count > 0 Then
                                    dtDatosTemp.Rows(0).Item("NUEVO_PUESTO") = r.Item("valor_nuevo").ToString.Trim + ", " + dtTemp.Rows(0).Item("nombre").ToString.Trim
                                Else
                                    dtDatosTemp.Rows(0).Item("NUEVO_PUESTO") = r.Item("valor_nuevo").ToString.Trim
                                End If

                            ElseIf r.Item("CAMPO").ToString.Equals("COD_AREA") Then
                                dtTemp = sqlExecute("select nombre from areas where cod_area ='" + r.Item("valor_nuevo") + "'")
                                If dtTemp.Rows.Count > 0 Then
                                    dtDatosTemp.Rows(0).Item("NUEVA_AREA") = r.Item("valor_nuevo").ToString.Trim + ", " + dtTemp.Rows(0).Item("nombre").ToString.Trim
                                Else
                                    dtDatosTemp.Rows(0).Item("NUEVA_AREA") = r.Item("valor_nuevo").ToString.Trim
                                End If
                            End If
                        ElseIf r.Item("tipo_movimiento").ToString.Equals("SALARIO") Then

                            'dtDatosTemp.Rows(0).Item("SACTUAL") = r.Item("valor_actual").ToString.Trim
                            'dtDatosTemp.Rows(0).Item("SACTUAL_NUEVO") = r.Item("valor_nuevo").ToString.Trim
                            'dtDatosTemp.Rows(0).Item("FECHA_CAPTURA") = FechaSQL(r.Item("FECHA_CAPTURA"))
                            'dtDatosTemp.Rows(0).Item("FECHA_EFECTIVA") = FechaSQL(r.Item("FECHA_EFECTIVA"))
                            dtRegistros = sqlExecute("select * from mod_sal where aplicado= '0'  and reloj ='" & _reloj & "'")
                            For Each p As DataRow In dtRegistros.Rows
                                query = "" & _
                                "select " & _
                                "PersonalVW.APATERNO, PersonalVW.AMATERNO, PersonalVW.NOMBRE, personalVW.RELOJ," & _
                                "PersonalVW.COD_DEPTO, PersonalVW.nombre_depto, PersonalVW.COD_SUPER, PersonalVW.nombre_super,personalvw.Centro_costos," & _
                                "PersonalVW.COD_AREA, PersonalVW.nombre_area, PersonalVW.COD_PUESTO, PersonalVW.nombre_puesto, personalvw.nivel," & _
                                "PersonalVW.COD_TURNO, PersonalVW.nombre_turno," & _
                                "PersonalVW.COD_HORA, PersonalVW.nombre_horario," & _
                                "'' as FECHA_BAJA,'' AS MOTIVO_BAJA," & _
                                "'' AS MOTIVO_AUSENTISMO,'' AS FECHA_INICIO,'' as CANTIDAD_DIAS," & _
                                "'' AS NUEVO_DEPTO  ,'' AS NUEVO_PUESTO,'' AS NUEVO_SUPER, '' as nuevo_nivel, '' AS NUEVA_AREA," & _
                                "'' AS NUEVO_TURNO,'' as NUEVO_HORARIO,'' AS SACTUAL,'' AS SACTUAL_NUEVO,'' AS SALMES,'' AS SALMES_NUEVO,'' AS FECHA_EFECTIVA,'' AS FECHA_CAPTURA,'0' as COMPA_RATIO_ANT,'0' AS COMPA_RATIO_NVO " & _
                                "from personal.dbo.PersonalVW " & _
                                "where personalvw.reloj = '" + p.Item("reloj") + "'"
                                dtTemp = sqlExecute(query)
                                dtTemp.Rows(0).Item("SACTUAL") = p.Item("CAMBIO_DE")
                                dtTemp.Rows(0).Item("SACTUAL_NUEVO") = p.Item("CAMBIO_A")
                                dtTemp.Rows(0).Item("SALMES") = Format(p.Item("CAMBIO_DE") * 30.4, "f")
                                dtTemp.Rows(0).Item("SALMES_NUEVO") = Format(p.Item("CAMBIO_A") * 30.4, "f")
                                dtTemp.Rows(0).Item("FECHA_CAPTURA") = FechaSQL(p.Item("FECHA"))
                                dtTemp.Rows(0).Item("nuevo_nivel") = (p.Item("nivel"))
                                dtTemp.Rows(0).Item("COMPA_RATIO_ANT") = (p.Item("COMPA_RATIO_ANT"))
                                dtTemp.Rows(0).Item("COMPA_RATIO_NVO") = (p.Item("COMPA_RATIO_NVO"))

                                ','' as COMPA_RATIO_ANT,'' AS COMPA_RATIO_NVO
                                dtDatos.ImportRow(dtTemp.Rows(0))
                            Next

                        End If
                    Next
                    dtDatos.ImportRow(dtDatosTemp.Rows(0))
                Next
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Multiforma", ex.HResult, ex.Message)

        End Try
    End Sub



    Public Sub IncluyeBeneficiarios(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal cod_prestacion As String)
        Try

            Dim i As Integer = sqlExecute("select maximo from prestaciones_con_beneficiarios where cod_prestacion = '" & cod_prestacion & "'").Rows(0)("maximo")

            Dim DatosBeneficiarios As String() =
                {"nombre_beneficiario",
                 "parentesco_beneficiario",
                 "nacimiento_beneficiario",
                 "porcentaje_beneficiario",
                 "sexo_beneficiario"
                }

            Dim c As Integer = DatosBeneficiarios.Length

            Dim columnas(7 + (i * c)) As DataColumn
            columnas(0) = New DataColumn("compania", System.Type.GetType("System.String"))
            columnas(1) = New DataColumn("reloj", System.Type.GetType("System.String"))
            columnas(2) = New DataColumn("nombre", System.Type.GetType("System.String"))
            columnas(3) = New DataColumn("amaterno", System.Type.GetType("System.String"))
            columnas(4) = New DataColumn("apaterno", System.Type.GetType("System.String"))
            columnas(5) = New DataColumn("fha_nac", System.Type.GetType("System.String"))
            columnas(6) = New DataColumn("alta", System.Type.GetType("System.String"))
            columnas(7) = New DataColumn("nombre_puesto", System.Type.GetType("System.String"))

            Dim x As Integer = 1
            For n As Integer = 8 To 8 + (i * c) Step (c)
                If x <= i Then

                    For j As Integer = 0 To (c - 1)
                        Dim index As Integer = n + j
                        Try
                            columnas(index) = New DataColumn(DatosBeneficiarios(j) & "_" & x, System.Type.GetType("System.String"))
                        Catch ex As Exception

                        End Try
                    Next
                    x += 1
                End If
            Next

            For x = 0 To UBound(columnas)
                dtDatos.Columns.Add(columnas(x))
            Next

            Dim dr As DataRow
            For Each row As DataRowView In dtInformacion.DefaultView
                dr = dtDatos.NewRow
                dr("compania") = row("compania")
                dr("reloj") = row("reloj")
                dr("nombre") = row("nombre")
                dr("apaterno") = row("apaterno")
                dr("amaterno") = row("amaterno")
                dr("fha_nac") = row("fha_nac")
                dr("alta") = FechaSQL(Date.Parse(row("alta")))
                dr("nombre_puesto") = row("nombre_puesto")

                Dim q As String = "select top " & i & " nombre_beneficiario, familia.nombre as 'parentesco_beneficiario', fecha_nacimiento as 'nacimiento_beneficiario', porcentaje as 'porcentaje_beneficiario', familia.sexo as 'sexo_beneficiario' from beneficiarios left join familia on familia.COD_FAMILIA = beneficiarios.cod_familia where reloj = '" & row("reloj") & "' and cod_prestacion = '" & cod_prestacion & "'"

                Dim dtBeneficiarios As DataTable = sqlExecute(q)
                If dtBeneficiarios.Rows.Count Then
                    For x = 0 To i - 1
                        If dtBeneficiarios.Rows.Count > x Then
                            For j As Integer = 0 To c
                                Try
                                    dr(DatosBeneficiarios(j) & "_" & x + 1) = dtBeneficiarios.Rows(x)(DatosBeneficiarios(j))
                                Catch ex As Exception

                                End Try
                            Next
                        Else
                            For j As Integer = 0 To c
                                Try
                                    dr(DatosBeneficiarios(j) & "_" & x + 1) = ""
                                Catch ex As Exception

                                End Try
                            Next
                        End If
                    Next
                End If

                dtDatos.Rows.Add(dr)
            Next

            x = x

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try
    End Sub


    Public Sub ResumenBajas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim Columnas(3) As DataColumn

            Dim modif As String = ""
            Dim dr As DataRow

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("descripcion", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("codigo", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("detalle", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("total", System.Type.GetType("System.Decimal"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("descripcion"), dtDatos.Columns("codigo")}

            Dim CodMotBa As String
            Dim Antiguedad As Integer
            Dim RangoAnt As String = ""
            Dim CodAnt As String = ""

            For Each dRow As DataRowView In dtInformacion.DefaultView
                If Not IsDBNull(dRow.Item("baja")) Then
                    Antiguedad = Antiguedad_Dias(dRow.Item("alta"), IIf(IsDBNull(dRow.Item("baja")), Now, dRow.Item("baja")))
                    Select Case Antiguedad
                        Case 0 To 90
                            CodAnt = 1
                            RangoAnt = "Antiguedad De 0-3 Meses"
                        Case 91 To 180
                            CodAnt = 2
                            RangoAnt = "Antiguedad De 3-6 Meses"
                        Case 181 To 365
                            CodAnt = 3
                            RangoAnt = "Antiguedad De 6-12 Meses"
                        Case 366 To 1095
                            CodAnt = 4
                            RangoAnt = "Antiguedad De 1-3 Años"
                        Case 1096 To 1825
                            CodAnt = 5
                            RangoAnt = "Antiguedad De 3-5 Años"
                        Case Is > 1826
                            CodAnt = 6
                            RangoAnt = "Antiguedad Mas de 5 Años"
                    End Select

                    'Por motivo de baja
                    CodMotBa = IIf(IsDBNull(dRow.Item("cod_mot_ba")), "", dRow.Item("cod_mot_ba"))
                    dr = dtDatos.Rows.Find({"MOTIVOS DE BAJA", CodMotBa})
                    If IsNothing(dr) Then
                        'Buscar descripción de motivo de baja
                        dtTemp = sqlExecute("SELECT nombre FROM cod_mot_baj WHERE cod_mot_ba = '" & CodMotBa & "'")
                        If dtTemp.Rows.Count > 0 Then
                            dtDatos.Rows.Add("MOTIVOS DE BAJA", CodMotBa, dtTemp.Rows(0).Item("nombre"), 1)
                        Else
                            dtDatos.Rows.Add("MOTIVOS DE BAJA", CodMotBa, "NO CAPTURADO", 1)
                        End If
                    Else
                        'Si ya se agregó la descripción, sumar 1 a la columna del total
                        dr.Item("total") = dr.Item("total") + 1
                    End If

                    'Por departamento
                    dr = dtDatos.Rows.Find({"DEPARTAMENTO", dRow.Item("cod_depto")})
                    If IsNothing(dr) Then
                        dtDatos.Rows.Add("DEPARTAMENTO", dRow.Item("cod_depto"), dRow.Item("nombre_depto"), 1)
                    Else
                        'Si ya se agregó la descripción, sumar 1 a la columna del total
                        dr.Item("total") = dr.Item("total") + 1
                    End If

                    'Por turno
                    dr = dtDatos.Rows.Find({"TURNO", dRow.Item("cod_turno")})
                    If IsNothing(dr) Then
                        dtDatos.Rows.Add("TURNO", dRow.Item("cod_turno"), dRow.Item("nombre_turno"), 1)
                    Else
                        'Si ya se agregó la descripción, sumar 1 a la columna del total
                        dr.Item("total") = dr.Item("total") + 1
                    End If

                    'Por supervisor
                    dr = dtDatos.Rows.Find({"SUPERVISOR", dRow.Item("cod_super")})
                    If IsNothing(dr) Then
                        dtDatos.Rows.Add("SUPERVISOR", dRow.Item("cod_super"), dRow.Item("nombre_super"), 1)
                    Else
                        'Si ya se agregó la descripción, sumar 1 a la columna del total
                        dr.Item("total") = dr.Item("total") + 1
                    End If

                    'Por puesto
                    dr = dtDatos.Rows.Find({"PUESTO", dRow.Item("cod_puesto")})
                    If IsNothing(dr) Then
                        dtDatos.Rows.Add("PUESTO", dRow.Item("cod_puesto"), dRow.Item("nombre_puesto"), 1)
                    Else
                        'Si ya se agregó la descripción, sumar 1 a la columna del total
                        dr.Item("total") = dr.Item("total") + 1
                    End If

                    'Por antiguedad
                    dr = dtDatos.Rows.Find({"ANTIGÜEDAD", CodAnt})
                    If IsNothing(dr) Then
                        dtDatos.Rows.Add("ANTIGÜEDAD", CodAnt, RangoAnt, 1)
                    Else
                        'Si ya se agregó la descripción, sumar 1 a la columna del total
                        dr.Item("total") = dr.Item("total") + 1
                    End If
                End If
            Next

            dtDatos.Select("select * order by descripcion,codigo")

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub UltimaModificacion(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim Columnas(10) As DataColumn

            Dim modif As String = ""

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reloj", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("nombres", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("nombre_depto", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("cod_tipo", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("cod_clase", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("cod_turno", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("alta", System.Type.GetType("System.DateTime"))
            Columnas(7) = New DataColumn("fha_ult_mo", System.Type.GetType("System.DateTime"))
            Columnas(8) = New DataColumn("sactual", System.Type.GetType("System.Decimal"))
            Columnas(9) = New DataColumn("modif", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("fha_ult_ev", System.Type.GetType("System.DateTime"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next

            For Each dRow As DataRowView In dtInformacion.DefaultView
                modif = ""
                dtTemp = sqlExecute("SELECT cod_tipo_mod FROM mod_sal WHERE reloj='" & dRow.Item("reloj") & "' AND fecha = '" & FechaSQL(dRow.Item("fha_ult_mo")) & "' AND cambio_a = " & dRow.Item("sactual"))
                If dtTemp.Rows.Count > 0 Then
                    modif = dtTemp.Rows(0).Item("cod_tipo_mod")
                End If
                dtDatos.Rows.Add(dRow.Item("reloj"), dRow.Item("nombres"), dRow.Item("nombre_depto"), dRow.Item("cod_tipo"), dRow.Item("cod_clase"), dRow.Item("cod_turno"), dRow.Item("alta"), IIf(IsDBNull(dRow.Item("fha_ult_mo")), dRow.Item("alta"), dRow.Item("fha_ult_mo")), dRow.Item("sactual"), modif, IIf(IsDBNull(dRow.Item("fha_ult_ev")), dRow.Item("alta"), dRow.Item("fha_ult_ev")))

            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub


    Public Sub SaldosVacaciones(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Try
            Dim Columnas(9) As DataColumn

            Dim antig As Integer
            Dim dias As Integer
            Dim saldo As Integer

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reloj", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("nombres", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("cod_super", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("nombre_super", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("cod_tipo", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("alta", System.Type.GetType("System.DateTime"))
            Columnas(6) = New DataColumn("antiguedad", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("dias_ganados", System.Type.GetType("System.Int16"))
            Columnas(8) = New DataColumn("dias_pagados", System.Type.GetType("System.Int16"))
            Columnas(9) = New DataColumn("saldo", System.Type.GetType("System.Int16"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            'dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}

            For Each dRow As DataRowView In dtInformacion.DefaultView
                antig = Antiguedad_Dias(dRow.Item("alta"), IIf(IsDBNull(dRow.Item("baja")), Now.Date, dRow.Item("baja"))) / 365
                dias = 0
                saldo = 0
                dtTemp = sqlExecute("SELECT TOP 1 dinero,saldo_dinero FROM saldos_vacaciones WHERE reloj = '" & dRow.Item("reloj") & "' ORDER BY fecha_fin DESC")
                If dtTemp.Rows.Count > 0 Then
                    dias = IIf(IsDBNull(dtTemp.Rows(0).Item("dinero")), 0, dtTemp.Rows(0).Item("dinero"))
                    saldo = IIf(IsDBNull(dtTemp.Rows(0).Item("saldo_dinero")), 0, dtTemp.Rows(0).Item("saldo_dinero"))
                End If
                dtDatos.Rows.Add(dRow.Item("reloj"), dRow.Item("nombres"), dRow.Item("cod_super"), dRow.Item("nombre_super"), dRow.Item("cod_tipo"), dRow.Item("alta"), antig, saldo + dias, dias, saldo)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Stop
        End Try

    End Sub

    Public Sub RotacionXPuesto(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtTemp As New DataTable
            Dim Puesto As String
            Dim Columnas(4) As DataColumn

            Dim dr As DataRow
            Dim Baja As Integer = 0
            Dim Activo As Integer = 0

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("nombre_puesto", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("activos", System.Type.GetType("System.Int16"))
            Columnas(2) = New DataColumn("bajas", System.Type.GetType("System.Int16"))
            Columnas(3) = New DataColumn("FechaInicial", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("FechaFinal", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("nombre_puesto")}
            Dim fr As New frmRangoFechas

            'Solicitar rango de fechas
            fr.ShowDialog()

            If FechaInicial = Nothing Then
                'Si el rango de fecha está en blanco, salir del procedimiento
                Exit Sub
            End If

            For Each dRow As DataRowView In dtInformacion.DefaultView
                Activo = 0
                Baja = 0
                If IsDBNull(dRow.Item("baja")) Then
                    'Si no está dado de baja...
                    If dRow.Item("alta") <= FechaFinal Then
                        'Si su fecha de alta fue antes a la fecha final del rango, estuvo activo
                        Activo = 1
                    End If
                Else
                    'Si tiene fecha de baja...
                    If dRow.Item("baja") >= FechaInicial And dRow.Item("baja") <= FechaFinal Then
                        'Si su fecha de baja fue en el rango, cuenta en rotación
                        Baja = 1
                    End If

                    If dRow.Item("alta") <= FechaFinal And dRow.Item("baja") > FechaFinal Then
                        'Si tiene fecha de baja, pero fue posterior al rango, y su fecha de alta fue antes del final del rango, estuvo activo
                        Activo = 1
                    End If
                End If

                Puesto = IIf(IsDBNull(dRow.Item("nombre_puesto")), "SIN PUESTO", dRow.Item("nombre_puesto"))
                dr = dtDatos.Rows.Find(Puesto)
                If IsNothing(dr) Then
                    'Si no existe el depto., agregarlo e inicializar la columna de hombres y mujeres
                    dtDatos.Rows.Add(Puesto, Activo, Baja, FechaInicial.ToShortDateString, FechaFinal.ToShortDateString)
                Else
                    'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
                    dr.Item("activos") = (dr.Item("activos")) + Activo
                    dr.Item("bajas") = (dr.Item("bajas")) + Baja
                End If
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Stop
        End Try
    End Sub

    Public Sub RotacionXTipo(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtTemp As New DataTable
            Dim Antiguedad As Integer
            Dim RangoAnt As String = ""
            Dim Columnas(10) As DataColumn

            Dim dr As DataRow
            Dim Baja As Integer = 0
            Dim ActivoInicio As Integer = 0
            Dim ActivoFinal As Integer = 0
            Dim Activos As Integer = 0
            Dim TipoEmp As String = ""

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("rango_antig", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("salary_activosInicio", System.Type.GetType("System.Int16"))
            Columnas(2) = New DataColumn("salary_activosFinal", System.Type.GetType("System.Int16"))
            Columnas(3) = New DataColumn("salary_headcount", System.Type.GetType("System.Int16"))
            Columnas(4) = New DataColumn("salary_bajas", System.Type.GetType("System.Int16"))
            Columnas(5) = New DataColumn("operativo_activosInicio", System.Type.GetType("System.Int16"))
            Columnas(6) = New DataColumn("operativo_activosFinal", System.Type.GetType("System.Int16"))
            Columnas(7) = New DataColumn("operativo_headcount", System.Type.GetType("System.Int16"))
            Columnas(8) = New DataColumn("operativo_bajas", System.Type.GetType("System.Int16"))
            Columnas(9) = New DataColumn("FechaInicial", System.Type.GetType("System.DateTime"))
            Columnas(10) = New DataColumn("FechaFinal", System.Type.GetType("System.DateTime"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("rango_antig")}
            Dim fr As New frmRangoFechas

            'Solicitar rango de fechas
            fr.ShowDialog()

            If FechaInicial = Nothing Then
                'Si el rango de fecha está en blanco, salir del procedimiento
                Exit Sub
            End If

            For Each dRow As DataRowView In dtInformacion.DefaultView
                ActivoInicio = 0
                ActivoFinal = 0
                Baja = 0

                If IsDBNull(dRow.Item("baja")) Then
                    'Si no está dado de baja...
                    If dRow.Item("alta") <= FechaFinal Then
                        'Si su fecha de alta fue antes a la fecha final del rango, estuvo ActivoFinal
                        ActivoFinal = 1
                    End If
                    If dRow.Item("alta") <= FechaInicial Then
                        'Si su fecha de alta fue antes a la fecha final del rango, estuvo ActivoInicio
                        ActivoInicio = 1
                    End If
                Else
                    'Si tiene fecha de baja...
                    If dRow.Item("baja") >= FechaInicial And dRow.Item("alta") <= FechaInicial And IIf(IsDBNull(dRow.Item("cod_mot_ba")), "", dRow.Item("cod_mot_ba")) <> "19" Then
                        ActivoInicio = 1
                    End If

                    If dRow.Item("baja") >= FechaFinal And dRow.Item("alta") <= FechaInicial And IIf(IsDBNull(dRow.Item("cod_mot_ba")), "", dRow.Item("cod_mot_ba")) <> "19" Then
                        ActivoFinal = 1
                    End If

                    If dRow.Item("baja") >= FechaInicial And dRow.Item("baja") <= FechaFinal And IIf(IsDBNull(dRow.Item("cod_mot_ba")), "", dRow.Item("cod_mot_ba")) <> "19" Then
                        'Si tiene fecha de baja dentro del rango y el motivo no es 19
                        Baja = 1
                    End If
                End If

                Antiguedad = Antiguedad_Dias(dRow.Item("alta"), IIf(IsDBNull(dRow.Item("baja")), Now, dRow.Item("baja")))
                Select Case Antiguedad
                    Case 0 To 90
                        RangoAnt = "1 Antiguedad De 0-3 Meses"
                    Case 91 To 180
                        RangoAnt = "2 Antiguedad De 3-6 Meses"
                    Case 181 To 365
                        RangoAnt = "3 Antiguedad De 6-12 Meses"
                    Case 366 To 1095
                        RangoAnt = "4 Antiguedad De 1-3 Años"
                    Case 1096 To 1825
                        RangoAnt = "5 Antiguedad De 3-5 Años"
                    Case Is > 1826
                        RangoAnt = "6 Antiguedad Mas de 5 Años"
                End Select

                TipoEmp = IIf(dRow.Item("cod_tipo") = "O", "O", "A")
                dr = dtDatos.Rows.Find(RangoAnt)
                If IsNothing(dr) Then
                    'Si no existe el depto., agregarlo e inicializar la columna de hombres y mujeres
                    dtDatos.Rows.Add(RangoAnt, IIf(TipoEmp = "A", ActivoInicio, 0), IIf(TipoEmp = "A", ActivoFinal, 0), 0, IIf(TipoEmp = "A", Baja, 0), IIf(TipoEmp = "O", ActivoInicio, 0), IIf(TipoEmp = "O", ActivoFinal, 0), 0, IIf(TipoEmp = "O", Baja, 0), Now.Date, Now.Date)
                Else
                    'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
                    If TipoEmp = "A" Then
                        dr.Item("salary_activosInicio") = dr.Item("salary_activosInicio") + ActivoInicio
                        dr.Item("salary_activosFinal") = dr.Item("salary_activosFinal") + ActivoFinal
                        dr.Item("salary_bajas") = dr.Item("salary_bajas") + Baja
                    Else
                        dr.Item("operativo_activosInicio") = dr.Item("operativo_activosInicio") + ActivoInicio
                        dr.Item("operativo_activosFinal") = dr.Item("operativo_activosFinal") + ActivoFinal
                        dr.Item("operativo_bajas") = dr.Item("operativo_bajas") + Baja
                    End If
                End If
            Next

            '*** El 6 de Noviembre 2008 Tere Moreno pidio que se manejara un promedio de activos como Headcount
            '*** dividiendo los activos al ultimo mas los activos al primer dia entre 2 IVO

            For Each dr In dtDatos.Rows
                dr.Item("operativo_headcount") = (dr.Item("operativo_activosInicio") + dr.Item("operativo_activosFinal")) / 2
                dr.Item("salary_headcount") = (dr.Item("salary_activosInicio") + dr.Item("salary_activosFinal")) / 2
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Stop
        End Try
    End Sub
    Public Sub ReporteBajasNomina(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtTemp As New DataTable
            Dim Columnas(14) As DataColumn
            Dim x As Integer
            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reloj", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("nombres", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("cod_depto", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("nombre_puesto", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("nombre_supervisor", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("cod_turno", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("alta", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("baja", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("cod_mot_ba", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("unidad", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("comentario", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("antiguedad", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("ant_dias", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("motivo_baja", System.Type.GetType("System.String"))
            Columnas(14) = New DataColumn("agrupa_anti", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            x = 0
            For Each dRow As DataRowView In dtInformacion.DefaultView
                dtDatos.Rows.Add(dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_puesto"), dRow("nombre_supervisor"), dRow("cod_turno"), dRow("alta"), dRow("baja"), dRow("cod_mot_ba"), dRow("unidad"), dRow("comentario"))

                'Buscar detalle de motivo de baja
                If Not IsDBNull(dRow("cod_mot_ba")) Then
                    dtTemp = sqlExecute("SELECT nombre FROM cod_mot_baj WHERE cod_mot_ba = '" & dRow("cod_mot_ba") & "'")
                    dtDatos.Rows(x).Item("motivo_baja") = dtTemp.Rows(0).Item("nombre")
                End If

                'Calcular antiguedad en años y días
                dtDatos.Rows(x).Item("antiguedad") = Antiguedad(dRow("alta"), IIf(IsDBNull(dRow("baja")), Now.Date, dRow("baja")))
                dtDatos.Rows(x).Item("ant_dias") = Antiguedad_Dias(dRow("alta"), IIf(IsDBNull(dRow("baja")), Now.Date, dRow("baja")))

                'Determinar grupo de antiguedad
                Select Case dtDatos.Rows(x).Item("ant_dias")
                    Case 0 To 90
                        dtDatos.Rows(x).Item("agrupa_anti") = "1 Antiguedad De 0-3 Meses"
                    Case 91 To 180
                        dtDatos.Rows(x).Item("agrupa_anti") = "2 Antiguedad De 3-6 Meses"
                    Case 181 To 365
                        dtDatos.Rows(x).Item("agrupa_anti") = "3 Antiguedad De 6-12 Meses"
                    Case 366 To 1095
                        dtDatos.Rows(x).Item("agrupa_anti") = "4 Antiguedad De 1-3 Años"
                    Case 1096 To 1825
                        dtDatos.Rows(x).Item("agrupa_anti") = "5 Antiguedad De 3-5 Años"
                    Case Is > 1826
                        dtDatos.Rows(x).Item("agrupa_anti") = "6 Antiguedad Mas de 5 Años"
                End Select
                If IsDBNull(dtDatos.Rows(x).Item("unidad")) Then
                    dtDatos.Rows(x).Item("unidad") = "SIN UNIDAD DE NEGOCIOS"
                End If
                x = x + 1
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub ReporteAMAC(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Try
            Dim Cadena As String
            Dim dtTemp As New DataTable
            Dim fr As New frmRangoFechas

            'Solicitar rango de fechas
            fr.ShowDialog()

            If FechaInicial = Nothing Then
                'Si el rango de fecha está en blanco, salir del procedimiento
                Exit Sub
            End If

            Cadena = "SELECT "
            ' Hombres directos a inicio de mes
            Cadena = Cadena & "COUNT(case when sexo = 'M' AND cod_clase ='D' AND (baja IS NULL OR baja>='" & FechaSQL(FechaInicial) & "') then 1 else null end) AS ODIH,"
            ' Hombres directos a fin de mes
            Cadena = Cadena & "COUNT(case when sexo = 'M' AND cod_clase ='D' AND (baja IS NULL OR baja>='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS ODFH,"
            ' Mujeres directos a inicio de mes
            Cadena = Cadena & "COUNT(case when sexo = 'F' AND cod_clase ='D' AND (baja IS NULL OR baja>='" & FechaSQL(FechaInicial) & "') then 1 else null end) AS ODIM,"
            ' Mujeres directos a fin de mes
            Cadena = Cadena & "COUNT(case when sexo = 'F' AND cod_clase ='D' AND (baja IS NULL OR baja>='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS ODFM,"

            ' Hombres indirectos a inicio de mes
            Cadena = Cadena & "COUNT(case when sexo = 'M' AND cod_clase ='I' AND (baja IS NULL OR baja>='" & FechaSQL(FechaInicial) & "') then 1 else null end) AS OIIH,"
            ' Hombres indirectos a fin de mes
            Cadena = Cadena & "COUNT(case when sexo = 'M' AND cod_clase ='I' AND (baja IS NULL OR baja>='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS OIFH,"
            ' Mujeres indirectos a inicio de mes
            Cadena = Cadena & "COUNT(case when sexo = 'F' AND cod_clase ='I' AND (baja IS NULL OR baja>='" & FechaSQL(FechaInicial) & "') then 1 else null end) AS OIIM,"
            ' Mujeres indirectos a fin de mes
            Cadena = Cadena & "COUNT(case when sexo = 'F' AND cod_clase ='I' AND (baja IS NULL OR baja>='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS OIFM,"

            ' Hombres administrativos a inicio de mes
            Cadena = Cadena & "COUNT(case when sexo = 'M' AND cod_clase ='A' AND (baja IS NULL OR baja>='" & FechaSQL(FechaInicial) & "') then 1 else null end) AS AIH,"
            ' Hombres administrativos a fin de mes
            Cadena = Cadena & "COUNT(case when sexo = 'M' AND cod_clase ='A' AND (baja IS NULL OR baja>='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS AFH,"
            ' Mujeres administrativos a inicio de mes
            Cadena = Cadena & "COUNT(case when sexo = 'F' AND cod_clase ='A' AND (baja IS NULL OR baja>='" & FechaSQL(FechaInicial) & "') then 1 else null end) AS AIM,"
            ' Mujeres administrativos a fin de mes
            Cadena = Cadena & "COUNT(case when sexo = 'F' AND cod_clase ='A' AND (baja IS NULL OR baja>='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS AFM,"

            ' Hombres indirectos banda a inicio de mes
            Cadena = Cadena & "COUNT(case when sexo = 'M' AND cod_clase ='B' AND (baja IS NULL OR baja>='" & FechaSQL(FechaInicial) & "') then 1 else null end) AS OBIH,"
            ' Hombres indirectos banda a fin de mes
            Cadena = Cadena & "COUNT(case when sexo = 'M' AND cod_clase ='B' AND (baja IS NULL OR baja>='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS OBFH,"
            ' Mujeres indirectos banda a inicio de mes
            Cadena = Cadena & "COUNT(case when sexo = 'F' AND cod_clase ='B' AND (baja IS NULL OR baja>='" & FechaSQL(FechaInicial) & "') then 1 else null end) AS OBIM,"
            ' Mujeres indirectos banda a fin de mes
            Cadena = Cadena & "COUNT(case when sexo = 'F' AND cod_clase ='B' AND (baja IS NULL OR baja>='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS OBFM,"

            ' Directos altas a fin de mes
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND (alta>='" & FechaSQL(FechaInicial) & "' AND alta<='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS ODALTAS,"
            ' Indirectos altas a fin de mes
            Cadena = Cadena & "COUNT(case when cod_clase ='I' AND (alta>='" & FechaSQL(FechaInicial) & "' AND alta<='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS OIALTAS,"
            ' Administrativos altas a fin de mes
            Cadena = Cadena & "COUNT(case when cod_clase ='A' AND (alta>='" & FechaSQL(FechaInicial) & "' AND alta<='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS OAALTAS,"
            ' Indirectos banda altas a fin de mes
            Cadena = Cadena & "COUNT(case when cod_clase ='B' AND (alta>='" & FechaSQL(FechaInicial) & "' AND alta<='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS OBALTAS,"

            ' Directos bajas a fin de mes
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND (baja>='" & FechaSQL(FechaInicial) & "' AND baja<='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS ODBAJAS,"
            ' Indirectos bajas a fin de mes
            Cadena = Cadena & "COUNT(case when cod_clase ='I' AND (baja>='" & FechaSQL(FechaInicial) & "' AND baja<='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS OIBAJAS,"
            ' Administrativos bajas a fin de mes
            Cadena = Cadena & "COUNT(case when cod_clase ='A' AND (baja>='" & FechaSQL(FechaInicial) & "' AND baja<='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS OABAJAS,"
            ' Indirectos banda bajas a fin de mes
            Cadena = Cadena & "COUNT(case when cod_clase ='B' AND (baja>='" & FechaSQL(FechaInicial) & "' AND baja<='" & FechaSQL(FechaFinal) & "') then 1 else null end) AS OBBAJAS,"

            ' Hombres directos baja por antiguedad 
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND sexo = 'M' AND (baja>='" & FechaSQL(FechaInicial) & "' AND baja<='" & FechaSQL(FechaFinal) & "') AND DATEDIFF(dd, alta, baja)<91 then 1 else null end) AS BAJASHOMBRES90,"
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND sexo = 'M' AND (baja>='" & FechaSQL(FechaInicial) & "' AND baja<='" & FechaSQL(FechaFinal) & "') AND DATEDIFF(dd, alta, baja)<180 AND DATEDIFF(dd, alta, baja)>90  then 1 else null end) AS BAJASHOMBRES180,"
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND sexo = 'M' AND (baja>='" & FechaSQL(FechaInicial) & "' AND baja<='" & FechaSQL(FechaFinal) & "') AND DATEDIFF(dd, alta, baja)>180  then 1 else null end) AS BAJASHOMBRESMAS,"

            ' Mujeres directos baja por antiguedad 
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND sexo = 'F' AND (baja>='" & FechaSQL(FechaInicial) & "' AND baja<='" & FechaSQL(FechaFinal) & "') AND DATEDIFF(dd, alta, baja)<91 then 1 else null end) AS BAJASMUJERES90,"
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND sexo = 'F' AND (baja>='" & FechaSQL(FechaInicial) & "' AND baja<='" & FechaSQL(FechaFinal) & "') AND DATEDIFF(dd, alta, baja)<180 AND DATEDIFF(dd, alta, baja)>90  then 1 else null end) AS BAJASMUJERES180,"
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND sexo = 'F' AND (baja>='" & FechaSQL(FechaInicial) & "' AND baja<='" & FechaSQL(FechaFinal) & "') AND DATEDIFF(dd, alta, baja)>180  then 1 else null end) AS BAJASMUJERESMAS,"


            ' Hombres directos activos por antiguedad 
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND sexo = 'M' AND (baja IS NULL OR baja>'" & FechaSQL(FechaFinal) & "') AND DATEDIFF(dd, alta, '" & FechaSQL(FechaFinal) & "')<91 then 1 else null end) AS ACTHOMBRES90,"
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND sexo = 'M' AND (baja IS NULL OR baja>'" & FechaSQL(FechaFinal) & "') AND DATEDIFF(dd, alta, '" & FechaSQL(FechaFinal) & "')<180 AND DATEDIFF(dd, alta, '" & FechaSQL(FechaFinal) & "')>90  then 1 else null end) AS ACTHOMBRES180,"
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND sexo = 'M' AND (baja IS NULL OR baja>'" & FechaSQL(FechaFinal) & "') AND DATEDIFF(dd, alta, '" & FechaSQL(FechaFinal) & "')>180  then 1 else null end) AS ACTHOMBRESMAS,"

            ' Mujeres directos activos por antiguedad 
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND sexo = 'F' AND (baja IS NULL OR baja>'" & FechaSQL(FechaFinal) & "') AND DATEDIFF(dd, alta, '" & FechaSQL(FechaFinal) & "')<91 then 1 else null end) AS ACTMUJERES90,"
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND sexo = 'F' AND (baja IS NULL OR baja>'" & FechaSQL(FechaFinal) & "') AND DATEDIFF(dd, alta, '" & FechaSQL(FechaFinal) & "')<180 AND DATEDIFF(dd, alta, '" & FechaSQL(FechaFinal) & "')>90  then 1 else null end) AS ACTMUJERES180,"
            Cadena = Cadena & "COUNT(case when cod_clase ='D' AND sexo = 'F' AND (baja IS NULL OR baja>'" & FechaSQL(FechaFinal) & "') AND DATEDIFF(dd, alta, '" & FechaSQL(FechaFinal) & "')>180  then 1 else null end) AS ACTMUJERESMAS,"

            ' Directos bajas por motivo
            Cadena = Cadena & "COUNT(case when cod_mot_ba='00' AND cod_clase ='D' AND NOT baja IS NULL then 1 else null end) AS HORARIOS,"
            Cadena = Cadena & "COUNT(case when cod_mot_ba='11' AND cod_clase ='D' AND NOT baja IS NULL then 1 else null end) AS AMBIENTE,"
            Cadena = Cadena & "COUNT(case when cod_mot_ba='04' AND cod_clase ='D' AND NOT baja IS NULL then 1 else null end) AS JEFES,"
            Cadena = Cadena & "COUNT(case when cod_mot_ba='00' AND cod_clase ='D' AND NOT baja IS NULL then 1 else null end) AS SERVICIOS,"
            Cadena = Cadena & "COUNT(case when cod_mot_ba='10' AND cod_clase ='D' AND NOT baja IS NULL then 1 else null end) AS FALTAS,"
            Cadena = Cadena & "COUNT(case when cod_mot_ba='07' AND cod_clase ='D' AND NOT baja IS NULL then 1 else null end) AS RESCISION,"
            Cadena = Cadena & "COUNT(case when cod_mot_ba='03' AND cod_clase ='D' AND NOT baja IS NULL then 1 else null end) AS SALARIO,"
            Cadena = Cadena & "COUNT(case when cod_mot_ba='02' AND cod_clase ='D' AND NOT baja IS NULL then 1 else null end) AS CAMBIOCD,"
            Cadena = Cadena & "COUNT(case when cod_mot_ba='16' AND cod_clase ='D' AND NOT baja IS NULL then 1 else null end) AS FAMILIARES,"
            Cadena = Cadena & "COUNT(case when cod_mot_ba='13' AND cod_clase ='D' AND NOT baja IS NULL then 1 else null end) AS ESTUDIOS,"
            Cadena = Cadena & "COUNT(case when cod_mot_ba='08' AND cod_clase ='D' AND NOT baja IS NULL then 1 else null end) AS RENUNCIA,"
            Cadena = Cadena & "COUNT(case when cod_mot_ba NOT IN('02','03','04','07','08','10','11','13','16') AND cod_clase ='D' AND NOT baja IS NULL then 1 else null end) AS OTROS,"
            Cadena = Cadena & "0 AS ODAUSENTISMO,0 AS OIAUSENTISMO,0 AS OBAUSENTISMO,0 AS AAUSENTISMO,"
            Cadena = Cadena & "'" & FechaSQL(FechaInicial) & "' AS FechaInicial,'" & FechaSQL(FechaFinal) & "' AS FechaFinal FROM personal.dbo.personal WHERE alta<='" & FechaSQL(FechaFinal) & "' AND (BAJA IS NULL OR (baja>='" & FechaSQL(FechaInicial) & "' AND baja<='" & FechaSQL(FechaFinal) & "')) AND NOT personalvw.reloj IS NULL AND NOT alta IS NULL "
            dtDatos = sqlExecute(Cadena)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub EmpleadosDeptoSexo(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim Columnas(3) As DataColumn
        Dim Depto As String
        Dim Sexo As String
        Dim dr As DataRow
        Try
            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("cod_depto", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("nombre_depto", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("hombres", System.Type.GetType("System.Int16"))
            Columnas(3) = New DataColumn("mujeres", System.Type.GetType("System.Int16"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("cod_depto")}

            'Repasar cada registro original para agruparlo en su depto. correspondiente y contabilizar sexo
            For Each dtRow In dtInformacion.DefaultView
                Depto = dtRow.item("cod_depto")
                Sexo = dtRow.item("sexo")
                dr = dtDatos.Rows.Find(Depto)
                If IsNothing(dr) Then
                    'Si no existe el depto., agregarlo e inicializar la columna de hombres y mujeres
                    dtDatos.Rows.Add(dtRow.item("cod_depto"), dtRow.item("nombre_depto"), IIf(Sexo = "M", 1, 0), IIf(Sexo = "F", 1, 0))
                Else
                    'Si ya se agregó el depto., sumar 1 a la columna de hombres o de mujeres, dependiendo del registro
                    dr.Item("hombres") = dr.Item("hombres") + IIf(Sexo = "M", 1, 0)
                    dr.Item("mujeres") = dr.Item("mujeres") + IIf(Sexo = "F", 1, 0)
                End If
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

    End Sub

    Public Sub ModificacionesIMSS(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        ' Dim dtInfoPersonal As New DataTable
        Dim Columnas(20) As DataColumn
        Dim ArchivoFoto As String = ""
        'Dim imgConnection As New SqlClient.SqlConnection(SQLConn & ";Initial Catalog='Personal';Persist Security Info=True; User ID=sa; Password=" & sPassword & ";")
        Dim PathFoto As String = ""
        Dim strFileName As String = ""

        Dim oWrite As System.IO.StreamWriter
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 0
        Dim GuardaArchivo As Boolean = True
        'Dim i As Integer

        Try

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("rfc", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("infonavit", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("cod_comp", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("compañia", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("paterno", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("materno", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("nombre", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("integrado", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("tipo_trab", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("tipo_sdo", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("sem_jorred", System.Type.GetType("System.String"))
            Columnas(14) = New DataColumn("modi", System.Type.GetType("System.String"))
            Columnas(15) = New DataColumn("umf", System.Type.GetType("System.String"))
            Columnas(16) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(17) = New DataColumn("guia", System.Type.GetType("System.String"))
            Columnas(18) = New DataColumn("reloj", System.Type.GetType("System.String"))
            Columnas(19) = New DataColumn("curp", System.Type.GetType("System.String"))
            Columnas(20) = New DataColumn("identifica", System.Type.GetType("System.String"))

            'copy fields reg_pat,imss,dig_ver,paterno,materno,nombre,integrado,f1,tipo_trab,tipo_sdo,;
            '	sem_jorred,modi,f2,tipo_mov,guia,reloj,filler,curp,identifica to &_archivo type sdf		

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            If dtInformacion.Rows.Count > 0 Then
                dtTemp = sqlExecute("SELECT rfc, infonavit, reg_pat, nombre, guia, uma * 25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

                PreguntaArchivo.Filter = "Text file|*.txt"
                PreguntaArchivo.FileName = ""
                If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    strFileName = PreguntaArchivo.FileName
                    'Dim objFSx As New FileStream(strFileName, FileMode.Create, FileAccess.Write)
                    'Dim objSW as StreamWriter(objFS)

                End If
                Try
                    oWrite = File.CreateText(strFileName)
                    GuardaArchivo = True
                Catch ex As Exception
                    oWrite = Nothing
                    GuardaArchivo = False
                End Try

                For Each dRow As DataRowView In dtInformacion.DefaultView
                    Dim integ As String = "0"
                    Dim integTemp As Double = 0

                    If Not IsDBNull(dRow("integrado")) Then
                        If dRow("integrado") > dtTemp.Rows(0).Item("tope") Then
                            integTemp = dtTemp.Rows(0).Item("tope")
                        Else
                            integTemp = dRow("integrado")
                        End If
                        'dRow.Item("integrado") = Double.Parse(Format(dRow.Item("integrado"), "f"))
                    End If
                    integ = Format(integTemp, "f")

                    dtDatos.Rows.Add(dtTemp.Rows(0).Item("rfc"), dtTemp.Rows(0).Item("infonavit"), dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), dRow("cod_comp"), dtTemp.Rows(0).Item("nombre"), dRow("apaterno"), dRow("amaterno"), dRow("nombre"),
                    integ,
                                     "1", "2", "0", FechaDMY(IIf(IsDBNull(dRow("fha_ult_mo")), Nothing, dRow("fha_ult_mo"))), dRow("umf"), "07", dtTemp.Rows(0).Item("guia"), dRow("reloj"), dRow("curp"), "9")
                    x = dtDatos.Rows.Count - 1


                    If GuardaArchivo Then
                        oWrite.WriteLine(dtDatos.Rows(x).Item("reg_pat").ToString.Trim.PadRight(11) & _
                                        dtDatos.Rows(x).Item("imss").ToString.Trim.PadRight(10) & _
                                        dtDatos.Rows(x).Item("dig_ver").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("paterno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(x).Item("materno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(x).Item("nombre").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(x).Item("integrado").ToString.Trim.Replace(".", "").PadLeft(6, "0") & _
                                        Space(6) & _
                                        dtDatos.Rows(x).Item("tipo_trab").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("tipo_sdo").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("sem_jorred").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("modi").ToString.Trim.PadRight(8) & _
                                        dtDatos.Rows(x).Item("umf").ToString.Trim.PadRight(3) & _
                                        Space(2) & _
                                        dtDatos.Rows(x).Item("tipo_mov").ToString.Trim.PadRight(2) & _
                                        dtDatos.Rows(x).Item("guia").ToString.Trim.PadRight(5) & _
                                        dtDatos.Rows(x).Item("reloj").ToString.Trim.PadRight(10) & _
                                        " " & _
                                        dtDatos.Rows(x).Item("curp").ToString.Trim.PadRight(18) & _
                                        dtDatos.Rows(x).Item("identifica").ToString.Trim.PadRight(1))
                    End If
                Next

                If GuardaArchivo Then
                    oWrite.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
                    oWrite.Close()
                End If

                Console.WriteLine("")
                Console.WriteLine("File creation complete. Press <Enter> to close this window.")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Debug.Print(ex.StackTrace)
        End Try

    End Sub


    Public Sub ModificacionesPorAntiguedad(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        ' Dim dtInfoPersonal As New DataTable
        Dim Columnas(20) As DataColumn
        Dim ArchivoFoto As String = ""
        'Dim imgConnection As New SqlClient.SqlConnection(SQLConn & ";Initial Catalog='Personal';Persist Security Info=True; User ID=sa; Password=" & sPassword & ";")
        Dim PathFoto As String = ""
        Dim strFileName As String = ""

        Dim oWrite As System.IO.StreamWriter
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 0
        Dim GuardaArchivo As Boolean = True
        'Dim i As Integer

        Dim frm As New frmRangoFechas
        frm.ReflectionLabel1.Text = "Aniversario entre:"
        frm.ShowDialog()

        Try

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("rfc", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("infonavit", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("cod_comp", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("compañia", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("paterno", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("materno", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("nombre", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("integrado", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("tipo_trab", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("tipo_sdo", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("sem_jorred", System.Type.GetType("System.String"))
            Columnas(14) = New DataColumn("modi", System.Type.GetType("System.String"))
            Columnas(15) = New DataColumn("umf", System.Type.GetType("System.String"))
            Columnas(16) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(17) = New DataColumn("guia", System.Type.GetType("System.String"))
            Columnas(18) = New DataColumn("reloj", System.Type.GetType("System.String"))
            Columnas(19) = New DataColumn("curp", System.Type.GetType("System.String"))
            Columnas(20) = New DataColumn("identifica", System.Type.GetType("System.String"))

            'copy fields reg_pat,imss,dig_ver,paterno,materno,nombre,integrado,f1,tipo_trab,tipo_sdo,;
            '	sem_jorred,modi,f2,tipo_mov,guia,reloj,filler,curp,identifica to &_archivo type sdf		

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            If dtInformacion.Rows.Count > 0 Then

                Dim mensaje As String =
                   "¿Desea aplicar las modificaciones de salario integrado por antiguedad a los siguientes empleados?"
                For Each dRow As DataRow In dtInformacion.Select("alta >= '" & FechaSQL(FechaInicial.AddYears(-1)) & "' and alta <= '" & FechaSQL(FechaFinal.AddYears(-1)) & "'")
                    mensaje &= vbCrLf & dRow("reloj") & " - " & "Aniv. " & FechaSQL(Date.Parse(dRow("alta")).AddYears(1)) & " - " & dRow("nombres").ToString.Trim
                Next


                If MsgBox(mensaje, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    For Each dRow As DataRow In dtInformacion.Select("alta >= '" & FechaSQL(FechaInicial.AddYears(-1)) & "' and alta <= '" & FechaSQL(FechaFinal.AddYears(-1)) & "'")

                        Dim nuevo_factor As Double = sqlExecute("select factor_int from factores where cod_comp = '" & dRow("cod_comp") & "' and cod_tipo = '" & dRow("cod_tipo") & "' and anos = '" & AntiguedadVac(dRow("alta"), FechaFinal) + 1 & "'").Rows(0)("factor_int")
                        Dim sactual As Double = dRow("sactual")
                        Dim provar As Double = dRow("pro_var")
                        Dim nuevo_integrado As Double = Math.Round((sactual * nuevo_factor) + provar, 2)
                        Dim fecha As Date = sqlExecute("select * from periodos where '" & FechaSQL(Date.Now) & "' >= FECHA_INI and '" & FechaSQL(Date.Now) & "' <= FECHA_FIN and PERIODO_ESPECIAL = 0", "TA").Rows(0)("fecha_ini")

                        sqlExecute("insert into mod_sal (cod_comp, reloj, cod_tipo_mod, cambio_de, cambio_a, provar, fact_int, fecha, notas, nivel, integrado, hoy, aplicado, fecha_aplicacion, usuario_aplicacion) values (" & _
                                    "'" & dRow("cod_comp") & "'," & _
                                    "'" & dRow("reloj") & "'," & _
                                    "'AN'," & _
                                    "'" & dRow("sactual") & "'," & _
                                    "'" & dRow("sactual") & "'," & _
                                    "'0'," & _
                                    "'" & nuevo_factor & "'," & _
                                    "'" & FechaSQL(fecha) & "'," & _
                                    "'AJUSTE AL FACTOR DE INTEGRACION POR ANIVERSARIO'," & _
                                    "''," & _
                                    "'" & nuevo_integrado & "'," & _
                                    "'" & FechaSQL(Date.Now) & "'," & _
                                    "'1'," & _
                                    "'" & FechaSQL(Date.Now) & "'," & _
                                    "'" & Usuario & "'" & _
                                   ")")

                        sqlExecute("update personal set factor_int = '" & nuevo_factor & "', integrado = '" & nuevo_integrado & "' where reloj = '" & dRow("reloj") & "'")


                        sqlExecute("insert into bitacora_personal (reloj, campo, valoranterior, valornuevo, tipo_movimiento, usuario, fecha) values ('" & dRow("reloj") & "', 'factor_int', '" & dRow("factor_int") & "', '" & nuevo_factor & "' ,'C', '" & Usuario & "', '" & FechaHoraSQL(DateTime.Now) & "')")
                        sqlExecute("insert into bitacora_personal (reloj, campo, valoranterior, valornuevo, tipo_movimiento, usuario, fecha) values ('" & dRow("reloj") & "', 'integrado', '" & dRow("integrado") & "', '" & nuevo_integrado & "','C', '" & Usuario & "', '" & FechaHoraSQL(DateTime.Now) & "')")
                    Next

                    dtTemp = sqlExecute("SELECT rfc,infonavit,reg_pat,nombre,guia,minimo*25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                    Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

                    PreguntaArchivo.Filter = "Text file|*.txt"
                    PreguntaArchivo.FileName = ""
                    If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        strFileName = PreguntaArchivo.FileName
                        'Dim objFSx As New FileStream(strFileName, FileMode.Create, FileAccess.Write)
                        'Dim objSW as StreamWriter(objFS)

                    End If
                    Try
                        oWrite = File.CreateText(strFileName)
                        GuardaArchivo = True
                    Catch ex As Exception
                        oWrite = Nothing
                        GuardaArchivo = False
                    End Try


                    Dim conteo As Integer = 0


                    For Each dRow As DataRow In dtInformacion.Select("alta >= '" & FechaSQL(FechaInicial.AddYears(-1)) & "' and alta <= '" & FechaSQL(FechaFinal.AddYears(-1)) & "'")

                        Dim nuevo_factor As Double = sqlExecute("select factor_int from factores where cod_comp = '" & dRow("cod_comp") & "' and cod_tipo = '" & dRow("cod_tipo") & "' and anos = '" & AntiguedadVac(dRow("alta"), FechaFinal) + 1 & "'").Rows(0)("factor_int")
                        Dim nuevo_integrado As Double = 0
                        Dim provar As Double = dRow("pro_var")
                        Dim sactual As Double = dRow("sactual")

                        Dim integ As Double = 0


                        If (sactual * nuevo_factor) > dtTemp.Rows(0).Item("tope") Then
                            integ = Math.Round(dtTemp.Rows(0).Item("tope"), 2)
                        Else
                            integ = Math.Round((sactual * nuevo_factor) + provar, 2)
                        End If

                        Dim fecha As Date = sqlExecute("select * from periodos where '" & FechaSQL(Date.Now) & "' >= FECHA_INI and '" & FechaSQL(Date.Now) & "' <= FECHA_FIN and PERIODO_ESPECIAL = 0", "TA").Rows(0)("fecha_ini")

                        dtDatos.Rows.Add(dtTemp.Rows(0).Item("rfc"), dtTemp.Rows(0).Item("infonavit"), dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), dRow("cod_comp"), dtTemp.Rows(0).Item("nombre"), dRow("apaterno"), dRow("amaterno"), dRow("nombre"),
                        integ,
                                         "1", "2", "0", FechaDMY(fecha), dRow("umf"), "07", dtTemp.Rows(0).Item("guia"), dRow("reloj"), dRow("curp"), "9")
                        x = dtDatos.Rows.Count - 1
                        If sactual < dtTemp.Rows(0).Item("tope") Then
                            If GuardaArchivo Then
                                conteo += 1
                                oWrite.WriteLine(dtDatos.Rows(x).Item("reg_pat").ToString.Trim.PadRight(11) & _
                                                dtDatos.Rows(x).Item("imss").ToString.Trim.PadRight(10) & _
                                                dtDatos.Rows(x).Item("dig_ver").ToString.Trim.PadRight(1) & _
                                                dtDatos.Rows(x).Item("paterno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                                dtDatos.Rows(x).Item("materno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                                dtDatos.Rows(x).Item("nombre").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                                String.Format("{0:N2}", Double.Parse(dtDatos.Rows(x).Item("integrado"))).Trim.Replace(".", "").PadLeft(6, "0") & _
                                                Space(6) & _
                                                dtDatos.Rows(x).Item("tipo_trab").ToString.Trim.PadRight(1) & _
                                                dtDatos.Rows(x).Item("tipo_sdo").ToString.Trim.PadRight(1) & _
                                                dtDatos.Rows(x).Item("sem_jorred").ToString.Trim.PadRight(1) & _
                                                dtDatos.Rows(x).Item("modi").ToString.Trim.PadRight(8) & _
                                                dtDatos.Rows(x).Item("umf").ToString.Trim.PadRight(3) & _
                                                Space(2) & _
                                                dtDatos.Rows(x).Item("tipo_mov").ToString.Trim.PadRight(2) & _
                                                dtDatos.Rows(x).Item("guia").ToString.Trim.PadRight(5) & _
                                                dtDatos.Rows(x).Item("reloj").ToString.Trim.PadRight(10) & _
                                                " " & _
                                                dtDatos.Rows(x).Item("curp").ToString.Trim.PadRight(18) & _
                                                dtDatos.Rows(x).Item("identifica").ToString.Trim.PadRight(1))
                            End If
                        End If
                    Next

                    If GuardaArchivo Then
                        oWrite.WriteLine("*************" & Space(43) & conteo.ToString.PadLeft(6, "0"))
                        oWrite.Close()
                    End If

                    Console.WriteLine("")
                    Console.WriteLine("File creation complete. Press <Enter> to close this window.")

                Else

                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Debug.Print(ex.StackTrace)
        End Try
    End Sub

    Public Sub BajasIMSS(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim Columnas(15) As DataColumn
        Dim ArchivoFoto As String = ""
        'Dim imgConnection As New SqlClient.SqlConnection(SQLConn & ";Initial Catalog='Personal';Persist Security Info=True; User ID=sa; Password=" & sPassword & ";")
        Dim PathFoto As String = ""
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 0
        Dim GuardaArchivo As Boolean = True
        'Dim i As Integer
        Try
            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("rfc", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("infonavit", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("cod_comp", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("compañia", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("paterno", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("materno", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("nombre", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("baja", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("guia", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("reloj", System.Type.GetType("System.String"))
            Columnas(14) = New DataColumn("mot_baja", System.Type.GetType("System.String"))
            Columnas(15) = New DataColumn("identifica", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            If dtInformacion.Rows.Count > 0 Then
                dtTemp = sqlExecute("SELECT rfc, infonavit, reg_pat, nombre, guia, uma * 25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

                PreguntaArchivo.Filter = "Text file|*.txt"
                PreguntaArchivo.FileName = ""
                If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                    PreguntaArchivo.FileName = ""
                End If
                Dim strFileName As String = PreguntaArchivo.FileName
                Dim objFS As New FileStream(strFileName, FileMode.Create, FileAccess.Write)
                Dim objSW As New StreamWriter(objFS)

                GuardaArchivo = strFileName <> ""

                For Each dRow As DataRowView In dtInformacion.DefaultView
                    dtDatos.Rows.Add(dtTemp.Rows(0).Item("rfc"), dtTemp.Rows(0).Item("infonavit"), dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", "").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), dRow("cod_comp"), dtTemp.Rows(0).Item("nombre"), dRow("apaterno"), dRow("amaterno"), dRow("nombre"), FechaDMY(IIf(IsDBNull(dRow("baja")), Nothing, dRow("baja"))), "02", dtTemp.Rows(0).Item("guia"), dRow("reloj"), dRow("cod_mot_im"), "9")
                    x = dtDatos.Rows.Count - 1
                    If GuardaArchivo Then
                        objSW.WriteLine(dtDatos.Rows(x).Item("reg_pat").ToString.Trim.PadRight(11) & _
                                        dtDatos.Rows(x).Item("imss").ToString.Trim.PadRight(10) & _
                                        dtDatos.Rows(x).Item("dig_ver").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("paterno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(x).Item("materno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(x).Item("nombre").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        Space(15) & _
                                        dtDatos.Rows(x).Item("baja").ToString.Trim.PadRight(8) & _
                                        Space(5) & _
                                        dtDatos.Rows(x).Item("tipo_mov").ToString.Trim.PadRight(2) & _
                                        dtDatos.Rows(x).Item("guia").ToString.Trim.PadRight(5) & _
                                        dtDatos.Rows(x).Item("reloj").ToString.Trim.PadRight(10) & _
                                        dtDatos.Rows(x).Item("mot_baja").ToString.Trim.PadRight(1) & _
                                        Space(18) & _
                                        dtDatos.Rows(x).Item("identifica").ToString.Trim.PadRight(1))
                    End If
                Next
                If GuardaArchivo Then
                    objSW.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
                End If
                objSW.Close()

                Console.WriteLine("")
                Console.WriteLine("File creation complete. Press <Enter> to close this window.")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Debug.Print(ex.StackTrace)
        End Try

    End Sub

    Public Sub AltasIMSS(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim Columnas(20) As DataColumn
        Dim ArchivoFoto As String = ""
        'Dim imgConnection As New SqlClient.SqlConnection(SQLConn & ";Initial Catalog='Personal';Persist Security Info=True; User ID=sa; Password=" & sPassword & ";")
        Dim PathFoto As String = ""
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 0
        Dim GuardaArchivo As Boolean = True
        'Dim i As Integer
        Try
            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("rfc", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("infonavit", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("cod_comp", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("compañia", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("paterno", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("materno", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("nombre", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("integrado", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("tipo_trab", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("tipo_sal", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("sem", System.Type.GetType("System.String"))
            Columnas(14) = New DataColumn("alta", System.Type.GetType("System.String"))
            Columnas(15) = New DataColumn("umf", System.Type.GetType("System.String"))
            Columnas(16) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(17) = New DataColumn("guia", System.Type.GetType("System.String"))
            Columnas(18) = New DataColumn("reloj", System.Type.GetType("System.String"))
            Columnas(19) = New DataColumn("curp", System.Type.GetType("System.String"))
            Columnas(20) = New DataColumn("formato", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            If dtInformacion.Rows.Count > 0 Then
                dtTemp = sqlExecute("SELECT rfc, infonavit, reg_pat, nombre, guia, uma * 25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                Dim _tope As Double = dtTemp.Rows(0).Item("tope")
                Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

                PreguntaArchivo.Filter = "Text file|*.txt"
                PreguntaArchivo.FileName = ""
                If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                    PreguntaArchivo.FileName = ""
                End If
                Dim strFileName As String = PreguntaArchivo.FileName
                Dim objFS As New FileStream(strFileName, FileMode.Create, FileAccess.Write)
                Dim objSW As New StreamWriter(objFS)

                GuardaArchivo = strFileName <> ""

                For Each dRow As DataRowView In dtInformacion.DefaultView
                    Try
                        dtDatos.Rows.Add(dtTemp.Rows(0).Item("rfc"), dtTemp.Rows(0).Item("infonavit"), dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), dRow("cod_comp"), dtTemp.Rows(0).Item("nombre"), dRow("apaterno"), dRow("amaterno"), dRow("nombre"), IIf(dRow("integrado") > _tope, _tope.ToString("N2"), dRow("integrado")), "1", "2", "0", FechaDMY(IIf(IsDBNull(dRow("alta")), Nothing, dRow("alta"))), dRow("umf"), "08", dtTemp.Rows(0).Item("guia"), dRow("reloj"), dRow("curp"), "9")
                        x = dtDatos.Rows.Count - 1

                        If GuardaArchivo Then
                            objSW.WriteLine(dtDatos.Rows(x).Item("reg_pat").ToString.Trim.PadRight(11) & _
                                            dtDatos.Rows(x).Item("imss").ToString.Trim.PadRight(10) & _
                                            dtDatos.Rows(x).Item("dig_ver").ToString.Trim.PadRight(1) & _
                                            dtDatos.Rows(x).Item("paterno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                            dtDatos.Rows(x).Item("materno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                            dtDatos.Rows(x).Item("nombre").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                            dtDatos.Rows(x).Item("integrado").ToString.Trim.Replace(".", "").Replace(",", "").PadLeft(6, "0") & _
                                            Space(6) & _
                                            dtDatos.Rows(x).Item("tipo_trab").ToString.Trim.PadRight(1) & _
                                            dtDatos.Rows(x).Item("tipo_sal").ToString.Trim.PadRight(1) & _
                                            dtDatos.Rows(x).Item("sem").ToString.Trim.PadRight(1) & _
                                            dtDatos.Rows(x).Item("alta").ToString.Trim.PadRight(8) & _
                                            dtDatos.Rows(x).Item("umf").ToString.Trim.PadRight(3) & _
                                            Space(2) & _
                                            dtDatos.Rows(x).Item("tipo_mov").ToString.Trim.PadRight(2) & _
                                            dtDatos.Rows(x).Item("guia").ToString.Trim.PadRight(5) & _
                                            dtDatos.Rows(x).Item("reloj").ToString.Trim.PadRight(10) & _
                                            Space(1) & _
                                            dtDatos.Rows(x).Item("curp").ToString.Trim.PadRight(18) & _
                                            dtDatos.Rows(x).Item("formato").ToString.Trim.PadRight(1))
                        End If
                    Catch ex As Exception

                    End Try
                Next
                If GuardaArchivo Then
                    objSW.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
                End If
                objSW.Close()

                Console.WriteLine("")
                Console.WriteLine("File creation complete. Press <Enter> to close this window.")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Debug.Print(ex.StackTrace)
        End Try

    End Sub



    Public Sub Cumpleaños(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            Dim fr As New frmRangoFechas

            Dim Cumple As Date


            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_turno", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_nacimiento", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_cumpleanos", Type.GetType("System.String"))
            dtDatos.Columns.Add("FechaInicial", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("FechaFinal", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_area", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
            dtDatos.Columns.Add("CENTRO_COSTOS", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_costos", Type.GetType("System.String"))




            fr.frmRangoFechas_fecha_ini = New Date(Now.Year, Now.Month, 1)
            fr.frmRangoFechas_fecha_fin = New Date(Now.Year, Now.Month, Now.Day)
            'Solicitar rango de fechas
            fr.ShowDialog()

            FechaInicial = FechaInicial.Date
            FechaFinal = FechaFinal.Date                   ' ------ filtros para poder comparar sin HRS y sea comparable desde el dia 1


            If FechaInicial = Nothing Then
                'Si el rango de fecha está en blanco, salir del procedimiento
                Exit Sub
            End If

            For Each dRow As DataRowView In dtInformacion.DefaultView
                'Para cada registro en la tabla, revisar fecha de cumpleaños
                Try
                    If Not IsDBNull(dRow("fha_nac")) Then
                        Dim reloj As String = dRow("reloj")
                        Cumple = FechaAniversario(Date.Parse(dRow("fha_nac")))
                        'Cambie el uso de FechaCumple() por FechaAniversario() y cambie la codicion que se revisa **************************CARLOS****************************
                        If Cumple < FechaInicial Then
                            Cumple = Cumple.AddYears(1)
                        End If

                        If Cumple >= FechaInicial.Date And Cumple <= FechaFinal.Date Then
                            dtDatos.Rows.Add(reloj, dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_super"), dRow("nombre_super"), dRow("cod_turno"), dRow("nombre_turno"), dRow("nombres"), FechaSQL(Date.Parse(dRow("fha_nac"))), FechaSQL(Cumple), FechaSQL(FechaInicial), FechaSQL(FechaFinal), dRow("cod_area"), dRow("nombre_area"), dRow("CENTRO_COSTOS"), dRow("nombre_costos"))
                        End If
                    End If
                Catch ex As Exception

                End Try

            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos.Rows.Clear()
            Debug.Print("ERROR EN " & System.Reflection.MethodBase.GetCurrentMethod.Name() & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub


    '***************Agregue este metodo para identificar los tipos de contratos de cada empleado en polygroup segun la antiguedad *******************CARLOS*********************
    Public Sub PersonalTiposContratoPG(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim Alta As Date
            dtDatos.Columns.Add(New DataColumn("reloj", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("nombres", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("alta", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("baja", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("cod_depto", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("cod_turno", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("nombre_turno", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("cod_hora", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("nombre_horario", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("cod_clase", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("nombre_depto", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("nombre_clase", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("tipo_contrato", System.Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("terminacion_contrato", System.Type.GetType("System.String")))
            dtInformacion.Columns.Add(New DataColumn("tipo_contrato", System.Type.GetType("System.String")))
            dtInformacion.Columns.Add(New DataColumn("terminacion_contrato", System.Type.GetType("System.String")))
            For Each row As DataRow In dtInformacion.Rows
                Alta = Date.Parse(row.Item("alta").ToString())
                If DateDiff(DateInterval.Day, Alta, Date.Now) > 30 Then
                    row.Item("terminacion_contrato") = DateDiff(DateInterval.Day, Alta, Date.Now).ToString + " días"
                    row.Item("tipo_contrato") = "indeterminado"
                Else
                    row.Item("terminacion_contrato") = FechaSQL(Alta.AddDays(30).ToString)
                    row.Item("tipo_contrato") = "determinado"
                End If

                dtDatos.ImportRow(row)
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    'Abraham Casas 2016-05-02
    Public Sub ReporteAntiguedadPromedio(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        dtDatos = New DataTable
        dtDatos.Columns.Add("reloj")
        dtDatos.Columns.Add("nombres")

        dtDatos.Columns.Add("cod_comp")
        dtDatos.Columns.Add("compania")

        dtDatos.Columns.Add("cod_planta")
        dtDatos.Columns.Add("nombre_planta")

        dtDatos.Columns.Add("cod_super")
        dtDatos.Columns.Add("nombre_super")

        dtDatos.Columns.Add("cod_depto")
        dtDatos.Columns.Add("nombre_depto")

        dtDatos.Columns.Add("cod_clase")
        dtDatos.Columns.Add("nombre_clase")

        dtDatos.Columns.Add("alta", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("fecha_calculo", Type.GetType("System.DateTime"))

        dtDatos.Columns.Add("es_baja")

        dtDatos.Columns.Add("antiguedad")


        dtDatos.Columns.Add("anos", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dias", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("cod_area")
        dtDatos.Columns.Add("CENTRO_COSTOS")
        dtDatos.Columns.Add("nombre_area")


        For Each row As DataRow In dtInformacion.Rows

            Dim drow As DataRow = dtDatos.NewRow

            drow("reloj") = row("reloj")
            drow("nombres") = row("nombres")

            drow("cod_comp") = row("cod_comp")
            drow("compania") = row("compania")

            drow("cod_planta") = row("cod_planta")
            drow("nombre_planta") = row("nombre_planta")

            drow("cod_super") = row("cod_super")
            drow("nombre_super") = row("nombre_super")

            drow("cod_depto") = row("cod_depto")
            drow("nombre_depto") = row("nombre_depto")

            drow("cod_clase") = row("cod_clase")
            drow("nombre_clase") = row("nombre_clase")

            drow("alta") = row("alta")

            Dim fecha_alta As Date = row("alta")
            Dim fecha_calculo As Date = Now

            If (IsDBNull(row("baja"))) Then
                drow("fecha_calculo") = Now
                fecha_calculo = Now
                drow("es_baja") = 0
            Else
                drow("fecha_calculo") = row("baja")
                fecha_calculo = row("baja")
                drow("es_baja") = 1
            End If

            drow("antiguedad") = AntiguedadExacta(fecha_alta, fecha_calculo)

            drow("anos") = DateDiff(DateInterval.Year, fecha_alta, fecha_calculo)
            drow("dias") = DateDiff(DateInterval.Day, fecha_alta, fecha_calculo)

            drow("cod_area") = row("cod_area")
            drow("CENTRO_COSTOS") = row("CENTRO_COSTOS")
            drow("nombre_area") = row("nombre_area")

            dtDatos.Rows.Add(drow)
        Next

    End Sub

    Public Sub MatrizCursosYIELD(ByRef dtDatos As DataTable, ByRef dtInfoPersonal As DataTable, Optional NombreDataSet As String = "")
        Dim dtInformacion As New DataTable
        ' Dim dtInfoPersonal As New DataTable
        Dim Columnas(150) As DataColumn
        Dim ArchivoFoto As String = ""
        'Dim imgConnection As New SqlClient.SqlConnection(SQLConn & ";Initial Catalog='Personal';Persist Security Info=True; User ID=sa; Password=" & sPassword & ";")
        Dim PathFoto As String = ""
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 0
        Dim i As Integer

        Dim ArCursos = {"00678", "gpiel_p1", "00679", "gpiel_p2", "00680", "gpiel_p3", "00681", "acabados_p1", "00682", "acabados_p2", "00683", "acabados_p3", "00684", "ticket_p1", "00685", "ticket_p2", "00686", "ticket_p3", "00708", "marcado_p1", "00709", "marcado_p2", "00710", "marcado_p3", "00687", "division_p1", "00688", "division_p2", "00689", "division_p3", "00711", "acomodo_p1", "00712", "acomodo_p2", "00713", "acomodo_p3", "00690", "dados_p1", "00691", "dados_p2", "00692", "dados_p3", "00711", "acomodo_p1", "00712", "acomodo_p2", "00713", "acomodo_p3"}

        Try
            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reloj", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("cod_super", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("supervisor", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("cod_puesto", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("puesto", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("nombres", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("cod_turno", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("cod_comp", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("foto", System.Type.GetType("System.String"))

            Columnas(9) = New DataColumn("gpiel_eval", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("acabados_eval", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("ticket_eval", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("marcadoy_eval", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("acomodoy_eval", System.Type.GetType("System.String"))
            Columnas(14) = New DataColumn("dados_eval", System.Type.GetType("System.String"))
            Columnas(15) = New DataColumn("inspeccion_eval", System.Type.GetType("System.String"))
            Columnas(16) = New DataColumn("corte_eval", System.Type.GetType("System.String"))
            Columnas(17) = New DataColumn("rclientes_eval", System.Type.GetType("System.String"))
            Columnas(18) = New DataColumn("recupera_eval", System.Type.GetType("System.String"))
            Columnas(19) = New DataColumn("planchado_eval", System.Type.GetType("System.String"))
            Columnas(20) = New DataColumn("retoque_eval", System.Type.GetType("System.String"))

            Columnas(21) = New DataColumn("gpiel_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(22) = New DataColumn("gpiel_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(23) = New DataColumn("gpiel_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(24) = New DataColumn("gpiel_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(25) = New DataColumn("gpiel_p2_calif", System.Type.GetType("System.Int32"))
            Columnas(26) = New DataColumn("gpiel_p2_nivel", System.Type.GetType("System.Char"))
            Columnas(27) = New DataColumn("gpiel_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(28) = New DataColumn("gpiel_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(29) = New DataColumn("gpiel_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(30) = New DataColumn("gpiel_prox_eval", System.Type.GetType("System.DateTime"))

            Columnas(31) = New DataColumn("acabados_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(32) = New DataColumn("acabados_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(33) = New DataColumn("acabados_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(34) = New DataColumn("acabados_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(35) = New DataColumn("acabados_p2_calif", System.Type.GetType("System.Int32"))
            Columnas(36) = New DataColumn("acabados_p2_nivel", System.Type.GetType("System.Char"))
            Columnas(37) = New DataColumn("acabados_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(38) = New DataColumn("acabados_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(39) = New DataColumn("acabados_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(40) = New DataColumn("acabados_prox_eval", System.Type.GetType("System.DateTime"))

            Columnas(41) = New DataColumn("ticket_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(42) = New DataColumn("ticket_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(43) = New DataColumn("ticket_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(44) = New DataColumn("ticket_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(45) = New DataColumn("ticket_p2_calif", System.Type.GetType("System.Char"))
            Columnas(46) = New DataColumn("ticket_p2_nivel", System.Type.GetType("System.Int32"))
            Columnas(47) = New DataColumn("ticket_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(48) = New DataColumn("ticket_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(49) = New DataColumn("ticket_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(50) = New DataColumn("ticket_prox_eval", System.Type.GetType("System.DateTime"))

            Columnas(51) = New DataColumn("marcado_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(52) = New DataColumn("marcado_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(53) = New DataColumn("marcado_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(54) = New DataColumn("marcado_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(55) = New DataColumn("marcado_p2_calif", System.Type.GetType("System.Char"))
            Columnas(56) = New DataColumn("marcado_p2_nivel", System.Type.GetType("System.Int32"))
            Columnas(57) = New DataColumn("marcado_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(58) = New DataColumn("marcado_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(59) = New DataColumn("marcado_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(60) = New DataColumn("marcado_prox_eval", System.Type.GetType("System.DateTime"))

            Columnas(61) = New DataColumn("division_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(62) = New DataColumn("division_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(63) = New DataColumn("division_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(64) = New DataColumn("division_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(65) = New DataColumn("division_p2_calif", System.Type.GetType("System.Char"))
            Columnas(66) = New DataColumn("division_p2_nivel", System.Type.GetType("System.Int32"))
            Columnas(67) = New DataColumn("division_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(68) = New DataColumn("division_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(69) = New DataColumn("division_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(70) = New DataColumn("division_prox_eval", System.Type.GetType("System.DateTime"))

            Columnas(71) = New DataColumn("acomodo_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(72) = New DataColumn("acomodo_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(73) = New DataColumn("acomodo_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(74) = New DataColumn("acomodo_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(75) = New DataColumn("acomodo_p2_calif", System.Type.GetType("System.Char"))
            Columnas(76) = New DataColumn("acomodo_p2_nivel", System.Type.GetType("System.Int32"))
            Columnas(77) = New DataColumn("acomodo_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(78) = New DataColumn("acomodo_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(79) = New DataColumn("acomodo_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(80) = New DataColumn("acomodo_prox_eval", System.Type.GetType("System.DateTime"))

            Columnas(81) = New DataColumn("dados_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(82) = New DataColumn("dados_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(83) = New DataColumn("dados_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(84) = New DataColumn("dados_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(85) = New DataColumn("dados_p2_calif", System.Type.GetType("System.Char"))
            Columnas(86) = New DataColumn("dados_p2_nivel", System.Type.GetType("System.Int32"))
            Columnas(87) = New DataColumn("dados_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(88) = New DataColumn("dados_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(89) = New DataColumn("dados_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(90) = New DataColumn("dados_prox_eval", System.Type.GetType("System.DateTime"))

            Columnas(91) = New DataColumn("inspeccion_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(92) = New DataColumn("inspeccion_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(93) = New DataColumn("inspeccion_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(94) = New DataColumn("inspeccion_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(95) = New DataColumn("inspeccion_p2_calif", System.Type.GetType("System.Char"))
            Columnas(96) = New DataColumn("inspeccion_p2_nivel", System.Type.GetType("System.Int32"))
            Columnas(97) = New DataColumn("inspeccion_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(98) = New DataColumn("inspeccion_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(99) = New DataColumn("inspeccion_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(100) = New DataColumn("inspeccion_prox_eval", System.Type.GetType("System.DateTime"))

            Columnas(101) = New DataColumn("corte_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(102) = New DataColumn("corte_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(103) = New DataColumn("corte_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(104) = New DataColumn("corte_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(105) = New DataColumn("corte_p2_calif", System.Type.GetType("System.Char"))
            Columnas(106) = New DataColumn("corte_p2_nivel", System.Type.GetType("System.Int32"))
            Columnas(107) = New DataColumn("corte_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(108) = New DataColumn("corte_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(109) = New DataColumn("corte_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(110) = New DataColumn("corte_prox_eval", System.Type.GetType("System.DateTime"))

            Columnas(111) = New DataColumn("rclientes_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(112) = New DataColumn("rclientes_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(113) = New DataColumn("rclientes_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(114) = New DataColumn("rclientes_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(115) = New DataColumn("rclientes_p2_calif", System.Type.GetType("System.Char"))
            Columnas(116) = New DataColumn("rclientes_p2_nivel", System.Type.GetType("System.Int32"))
            Columnas(117) = New DataColumn("rclientes_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(118) = New DataColumn("rclientes_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(119) = New DataColumn("rclientes_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(120) = New DataColumn("rclientes_prox_eval", System.Type.GetType("System.DateTime"))

            Columnas(121) = New DataColumn("recupera_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(122) = New DataColumn("recupera_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(123) = New DataColumn("recupera_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(124) = New DataColumn("recupera_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(125) = New DataColumn("recupera_p2_calif", System.Type.GetType("System.Char"))
            Columnas(126) = New DataColumn("recupera_p2_nivel", System.Type.GetType("System.Int32"))
            Columnas(127) = New DataColumn("recupera_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(128) = New DataColumn("recupera_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(129) = New DataColumn("recupera_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(130) = New DataColumn("recupera_prox_eval", System.Type.GetType("System.DateTime"))

            Columnas(131) = New DataColumn("planchado_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(132) = New DataColumn("planchado_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(133) = New DataColumn("planchado_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(134) = New DataColumn("planchado_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(135) = New DataColumn("planchado_p2_calif", System.Type.GetType("System.Char"))
            Columnas(136) = New DataColumn("planchado_p2_nivel", System.Type.GetType("System.Int32"))
            Columnas(137) = New DataColumn("planchado_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(138) = New DataColumn("planchado_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(139) = New DataColumn("planchado_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(140) = New DataColumn("planchado_prox_eval", System.Type.GetType("System.DateTime"))

            Columnas(141) = New DataColumn("retoque_p1_fecha", System.Type.GetType("System.DateTime"))
            Columnas(142) = New DataColumn("retoque_p1_calif", System.Type.GetType("System.Int32"))
            Columnas(143) = New DataColumn("retoque_p1_nivel", System.Type.GetType("System.Char"))
            Columnas(144) = New DataColumn("retoque_p2_fecha", System.Type.GetType("System.DateTime"))
            Columnas(145) = New DataColumn("retoque_p2_calif", System.Type.GetType("System.Char"))
            Columnas(146) = New DataColumn("retoque_p2_nivel", System.Type.GetType("System.Int32"))
            Columnas(147) = New DataColumn("retoque_p3_fecha", System.Type.GetType("System.DateTime"))
            Columnas(148) = New DataColumn("retoque_p3_calif", System.Type.GetType("System.Int32"))
            Columnas(149) = New DataColumn("retoque_p3_nivel", System.Type.GetType("System.Char"))
            Columnas(150) = New DataColumn("retoque_prox_eval", System.Type.GetType("System.DateTime"))


            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}


            Dim fr As New frmRangoFechas
            fr.ShowDialog()

            If FechaInicial = Nothing Then
                Exit Sub
            End If

            For x = 0 To dtInfoPersonal.Rows.Count - 1
                'sqlExecute("SELECT personalvw.nombres,personalvw.cod_comp,personalvw.cod_puesto,personalvw.cod_turno,personalvw.cod_super,puestos.nombre as 'nombre_puesto',super.nombre as 'nombre_super' from personalvw LEFT JOIN puestos ON personalvw.cod_puesto = puestos.cod_puesto AND personalvw.cod_comp = puestos.cod_comp LEFT JOIN super ON personalvw.cod_super = super.cod_super AND personalvw.cod_comp = super.cod_comp WHERE RELOJ = '" & dRow("reloj") & "'", dtInfoPersonal)

                'Revisar si tomó alguno de los cursos en el periodo indicado

                ArchivoFoto = PathFoto & dtInfoPersonal.Rows(x).Item("reloj").ToString.Trim & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    ArchivoFoto = PathFoto & "nofoto.png"
                End If

                If Dir(ArchivoFoto) = "" Then
                    ArchivoFoto = PathFoto & "nofoto.jpg"
                End If

                dtInformacion = sqlExecute("SELECT reloj,cod_curso FROM capacitacion.dbo.cursos_empleado WHERE ((cod_curso>='00592' AND cod_curso<='00594') OR(cod_curso>='00678' AND cod_curso<='00713')) AND inicio BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "' AND reloj = '" & dtInfoPersonal.Rows(x).Item("reloj") & "'", "Capacitacion")

                For z = 0 To dtInformacion.Rows.Count - 1
                    If z = 0 Then
                        dtDatos.Rows.Add(dtInfoPersonal.Rows(x).Item("reloj"), dtInfoPersonal.Rows(x).Item("cod_super"), dtInfoPersonal.Rows(x).Item("nombre_super"), dtInfoPersonal.Rows(x).Item("cod_puesto"), dtInfoPersonal.Rows(x).Item("nombre_puesto"), dtInfoPersonal.Rows(x).Item("nombres"), dtInfoPersonal.Rows(x).Item("cod_turno"), dtInfoPersonal.Rows(x).Item("cod_comp"), ArchivoFoto)
                        y = y + 1
                    End If

                    i = Array.IndexOf(ArCursos, dtInformacion.Rows(z).Item("cod_curso"))
                    'Si localiza el curso, el nombre del campo será el siguiente índice
                    If i >= 0 Then
                        InfoCurso(dtInfoPersonal.Rows(x).Item("reloj"), dtInformacion.Rows(z).Item("cod_curso"), ArCursos(i + 1), dtDatos.Rows(y))
                    End If
                Next
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Debug.Print("ERROR EN " & System.Reflection.MethodBase.GetCurrentMethod.Name() & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Public Sub InsertaFoto(ByVal Reloj As String, PathFoto As String, ByRef dtRow As DataRow)
        Dim ArchivoFoto As String = ""
        ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
        Try
            ArchivoFoto = PathFoto & Reloj & ".jpg"
            If Dir(ArchivoFoto) = "" Then
                ArchivoFoto = PathFoto & "nofoto.png"
            End If
            'picFoto.ImageLocation = ArchivoFoto

            Dim Result As Byte() = Nothing
            Using fsSource As System.IO.FileStream = New System.IO.FileStream(ArchivoFoto, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                Dim bytes() As Byte = New Byte(CInt((fsSource.Length) - 1)) {}
                Dim numBytesToRead As Integer = CType(fsSource.Length, Integer)
                Dim numBytesRead As Integer = 0
                While (numBytesToRead > 0)
                    Dim n As Integer = fsSource.Read(bytes, numBytesRead, numBytesToRead)
                    If (n = 0) Then
                        Exit While
                    End If
                End While
                Result = bytes
            End Using
            dtRow.Item("Foto") = Result
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

    End Sub

    Public Sub InfoCurso(Reloj As String, Curso As String, DescripCampo As String, ByRef dtRow As DataRow)
        Dim dtCursos As New DataTable
        dtCursos = sqlExecute("SELECT inicio,calificaci FROM certi WHERE reloj = '" & Reloj.Trim & "' AND cod_curso = '" & Curso.Trim & "' AND inicio = (SELECT MAX(inicio) FROM CAPACITACION.dbo.certi WHERE reloj = '" & Reloj.Trim & "' AND cod_curso = '" & Curso.Trim & "')", "Capacitacion")
        If dtCursos.Rows.Count > 0 Then
            dtRow.Item(DescripCampo & "_fecha") = dtCursos.Rows(0).Item("inicio")
            dtRow.Item(DescripCampo & "_calif") = dtCursos.Rows(0).Item("calificaci")
            dtRow.Item(DescripCampo & "_nivel") = IIf(dtCursos.Rows(0).Item("calificaci") >= 85, "A", IIf(dtCursos.Rows(0).Item("calificaci") >= 70, "B", "C"))
        End If
    End Sub

    Private Function Day(p1 As Object) As Object
        Throw New NotImplementedException
    End Function

    Public Sub TarjetasDespensa(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos.Columns.Add("fijo1")
        dtDatos.Columns.Add("fijo2")
        dtDatos.Columns.Add("fijo3")
        dtDatos.Columns.Add("RELOJ")
        dtDatos.Columns.Add("NOMBRE")
        dtDatos.Columns.Add("APATERNO")
        dtDatos.Columns.Add("AMATERNO")
        dtDatos.Columns.Add("RFC")
        dtDatos.Columns.Add("CIA")
        dtDatos.Columns.Add("NOMBRE_AP")
        dtDatos.Columns.Add("fijo4")
        dtDatos.Columns.Add("CURP")
        dtDatos.Columns.Add("IMSS_DV")
        dtDatos.Columns.Add("RFC_CIA")
        dtDatos.Columns.Add("fecha_ini")
        dtDatos.Columns.Add("fecha_fin")

        'Dim frm_fechas As New frmRangoFechas
        'frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
        'frm_fechas.frmRangoFechas_fecha_fin = Now
        'frm_fechas.ShowDialog()

        Dim filtros As String = frmReporteador.FiltrosAcumulados

        Dim dtPersona As DataTable = sqlExecute("select 1 as fijo1,1 as fijo2,10 as fijo3,RELOJ,NOMBRE,APATERNO,AMATERNO,RFC,'BRP MEXICO' as CIA,(RTRIM(LEFT(NOMBRE, CHARINDEX(' ', NOMBRE) - 1))+' '+ APATERNO) AS NOMBRE_AP,'1' as fijo4,CURP,(IMSS+DIG_VER) AS IMSS_DV,'A8316472100' AS RFC_CIA,'' as fecha_ini,'' as fecha_fin from PERSONAL.dbo.PersonalVW where " & filtros & "")
        Try
            For Each drow As DataRow In dtPersona.Rows
                dtDatos.Rows.Add({
                                                                    drow("fijo1"),
                                                                    drow("fijo2"),
                                                                    drow("fijo3"),
                                                                    drow("Reloj"),
                                                                    drow("NOMBRE"),
                                                                    drow("APATERNO"),
                                                                    drow("AMATERNO"),
                                                                    drow("RFC"),
                                                                    drow("CIA"),
                                                                    drow("NOMBRE_AP"),
                                                                    drow("fijo4"),
                                                                    drow("CURP"),
                                                                    drow("IMSS_DV"),
                                                                    drow("RFC_CIA"),
                                                                    FechaSQL(FechaInicial),
                                                                    FechaSQL(FechaFinal)
                                                                    })
            Next

        Catch ex As Exception

        End Try


        'Next

    End Sub

    Public Sub ReporteIngMunoz(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos.Columns.Add("RELOJ")
        dtDatos.Columns.Add("ALTA")
        dtDatos.Columns.Add("N_COMPLETO")
        dtDatos.Columns.Add("TELEFONO")
        dtDatos.Columns.Add("D_COMPLETA")

        Dim filtros As String = frmReporteador.FiltrosAcumulados

        Dim dtPersona As DataTable = sqlExecute("SELECT RELOJ,ALTA,(RTRIM(NOMBRE) + '  ' +  RTRIM(APATERNO) + '  ' + RTRIM(AMATERNO)) AS N_COMPLETO,TELEFONO,D_COMPLETA FROM personal.dbo.PERSONALVW WHERE " & filtros & "")
        Try
            For Each drow As DataRow In dtPersona.Rows
                dtDatos.Rows.Add({
                                  drow("RELOJ"),
                                  drow("ALTA"),
                                  drow("N_COMPLETO"),
                                  drow("TELEFONO"),
                                  drow("D_COMPLETA")
                                 })
            Next

        Catch ex As Exception

        End Try

    End Sub
    Public Sub ReportedeAntiguedades(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos = New DataTable
        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
        dtDatos.Columns.Add("alta", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_planta", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_planta", Type.GetType("System.String"))
        dtDatos.Columns.Add("FECHA_INICIO", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("FECHA_FIN", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("tipo_antiguedad", Type.GetType("System.String"))
        dtDatos.Columns.Add("aniversario", Type.GetType("System.DateTime"))
        'dtDatos.Columns.Add("cod_comp", Type.GetType("System.String"))
        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}

        Dim frm_fechas As New frmRangoFechas
        frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
        frm_fechas.frmRangoFechas_fecha_fin = Now
        frm_fechas.ShowDialog()
        Dim i As Integer = 5
        While i >= 5 And i <= 80
            For Each row As DataRow In dtInformacion.Select("baja is null")
                Try
                    Dim alta As Date = row("alta")
                    Dim fila As DataRow
                    'BG 14/09/15 ***CAMBIOS POR ANTIGUEDAD***

                    'BG 14/09/15 Antiguedad por 6 meses

                    If alta.AddYears(i) >= FechaSQL(FechaInicial) And alta.AddYears(i) <= FechaSQL(FechaFinal) Then

                        fila = dtDatos.NewRow

                        fila("reloj") = row("reloj")
                        fila("nombres") = row("nombres")
                        fila("cod_tipo") = row("cod_tipo")
                        fila("cod_depto") = row("cod_depto")
                        fila("cod_super") = row("cod_super")
                        fila("nombre_super") = row("nombre_super")
                        fila("cod_turno") = row("cod_turno")
                        fila("alta") = alta
                        fila("cod_planta") = row("cod_planta")
                        fila("nombre_planta") = row("nombre_planta")
                        fila("fecha_inicio") = FechaSQL(FechaInicial)
                        fila("fecha_fin") = FechaSQL(FechaFinal)

                        fila("tipo_antiguedad") = "Antigüedad " + IIf(i.ToString.Length = 2, i.ToString, "0" + i.ToString) + " años"
                        fila("aniversario") = FechaSQL(alta.AddYears(i))
                        dtDatos.Rows.Add(fila)
                    End If

                Catch ex As Exception

                End Try
            Next
            i = i + 5
        End While
    End Sub
    Public Sub Antidoping(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos = New DataTable
        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_comp", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
        Dim dtSeleccion As DataTable
        Dim frm_antidoping As New frmElegirAntidoping
        frm_antidoping.ShowDialog()
        Dim filtros As String = frmReporteador.FiltrosAcumulados
        Try
            dtSeleccion = sqlExecute("SELECT TOP " & frm_antidoping.x & " reloj,nombres,cod_comp,cod_depto,cod_super,nombre_super,cod_turno FROM PersonalVW where baja is null and " & filtros & " ORDER BY NEWID()")
            For Each registro As DataRow In dtSeleccion.Rows
                Dim fila As DataRow
                fila = dtDatos.NewRow
                fila("reloj") = registro("reloj")
                fila("nombres") = registro("nombres")
                fila("cod_comp") = registro("cod_comp")
                fila("cod_depto") = registro("cod_depto")
                fila("cod_super") = registro("cod_super")
                fila("nombre_super") = registro("nombre_super")
                fila("cod_turno") = registro("cod_turno")
                dtDatos.Rows.Add(fila)
            Next
        Catch ex As Exception

        End Try
    End Sub

    'Modificado para reporte de beneficiarios Wollsdorf - Ernesto - 23/dic/2020
    Public Sub Beneficiarios(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
           dtDatos = New DataTable
        dtDatos.Columns.Add("RELOJ", Type.GetType("System.String"))
        dtDatos.Columns.Add("NOMBRE", Type.GetType("System.String"))
        dtDatos.Columns.Add("APATERNO", Type.GetType("System.String"))
        dtDatos.Columns.Add("AMATERNO", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_puesto", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_beneficiario", Type.GetType("System.String"))
        dtDatos.Columns.Add("porcentaje", Type.GetType("System.String"))
        dtDatos.Columns.Add("fecha_nacimiento", Type.GetType("System.String"))
        dtDatos.Columns.Add("Parentesco", Type.GetType("System.String"))
        dtDatos.Columns.Add("Edad", Type.GetType("System.String"))
        Dim dtSeleccion As DataTable

        Try
            For Each row As DataRow In dtInformacion.Rows
                dtSeleccion = sqlExecute("select distinct personalvw.RELOJ," & _
                                    "personalvw.NOMBRE," & _
                                    "personalvw.APATERNO," & _
                                    "personalvw.AMATERNO," & _
                                    "personalvw.nombre_puesto," & _
                                    "personalvw.nombre_area," & _
                                    "beneficiarios.nombre_beneficiario," & _
                                    "beneficiarios.porcentaje," & _
                                    "beneficiarios.fecha_nacimiento," & _
                                    "familia.NOMBRE AS Parentesco," & _
                                    "(DATEDIFF(YEAR,beneficiarios.fecha_nacimiento,GETDATE())) as Edad " & _
                                    "FROM personalvw LEFT JOIN beneficiarios ON personalvw.RELOJ = beneficiarios.RELOJ " & _
                                    "LEFT JOIN familia on beneficiarios.cod_familia = familia.COD_FAMILIA " & _
                                    "WHERE personalvw.RELOJ = '" & dtInformacion.Rows(0)("RELOJ") & "'")

                For Each registro As DataRow In dtSeleccion.Rows
                    Dim fila As DataRow
                    fila = dtDatos.NewRow
                    fila("RELOJ") = registro("RELOJ")
                    fila("NOMBRE") = registro("NOMBRE")
                    fila("APATERNO") = registro("APATERNO")
                    fila("AMATERNO") = registro("AMATERNO")
                    fila("nombre_puesto") = registro("nombre_puesto")
                    fila("nombre_area") = registro("nombre_area")
                    fila("nombre_beneficiario") = registro("nombre_beneficiario")
                    fila("porcentaje") = registro("porcentaje")
                    fila("fecha_nacimiento") = FechaSQL(registro("fecha_nacimiento"))
                    fila("Parentesco") = registro("Parentesco")
                    fila("Edad") = registro("Edad")
                    dtDatos.Rows.Add(fila)
                Next
            Next

        Catch ex As Exception : End Try
    End Sub

    Public Sub PeriodoPruebas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos = New DataTable
        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        'dtDatos.Columns.Add("cod_tipo_mod", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_planta", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_puesto", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_turno", Type.GetType("System.String"))
        dtDatos.Columns.Add("fecha_aplicacion", Type.GetType("System.DateTime"))
        'Dim dtSeleccion As DataTable
        Dim dtTipo As DataTable
        Dim filtros As String = frmReporteador.FiltrosAcumulados
        Try
            For Each drow As DataRow In dtInformacion.Select(filtros)
                'dtSeleccion = sqlExecute("select mod_sal.* from personal.dbo.mod_sal where reloj='" & drow("reloj") & "'")
                'For Each registro As DataRow In dtSeleccion.Rows
                Dim reloj As String = drow("reloj")
                'dtTipo = sqlExecute("select cod_tipo_mod from mod_sal where reloj='" & reloj & "' and FECHA_APLICACION in (SELECT max(distinct FECHA_APLICACION) as fecha_mayor FROM mod_sal)")
                dtTipo = sqlExecute("select top 1 * from mod_sal where reloj='" & reloj & "' order by FECHA desc")
                For Each registro2 As DataRow In dtTipo.Rows
                    Dim tipo As String = registro2("cod_tipo_mod")
                    Dim fila As DataRow
                    If tipo = "IPP" Then
                        fila = dtDatos.NewRow
                        fila("reloj") = drow("reloj")
                        fila("nombres") = drow("nombres")
                        fila("nombre_planta") = drow("nombre_planta")
                        fila("cod_depto") = drow("cod_depto")
                        fila("nombre_depto") = drow("nombre_depto")
                        fila("cod_super") = drow("cod_super")
                        fila("nombre_super") = drow("nombre_super")
                        fila("nombre_area") = drow("nombre_area")
                        fila("nombre_puesto") = drow("nombre_puesto")
                        fila("nombre_turno") = drow("nombre_turno")
                        fila("fecha_aplicacion") = FechaSQL(registro2("fecha"))
                        dtDatos.Rows.Add(fila)
                    End If
                Next
                'Next
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    'Public Sub CentroFamiliar(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
    '    Dim filtros As String = frmReporteador.FiltrosAcumulados
    '    dtDatos = New DataTable
    '    dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("nombre", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("cod_familia", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("imprimir", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("id_familiar", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("adicionales", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("nomreloj", Type.GetType("System.String"))
    '    dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("id_familiar")}

    '    Dim dtSeleccion As DataTable

    '    Try

    '        For Each registro As DataRow In dtInformacion.Rows

    '            dtSeleccion = sqlExecute("select familiares.* from  personal.dbo.familiares where (familiares.cod_familia in(05,06) or familiares.COD_FAMILIA in(07,08)) and DATEDIFF(y, GETDATE(), fecha_nac) <= 16 and reloj='" & registro("reloj") & "'")
    '            For Each record As DataRow In dtSeleccion.Rows
    '                Dim fila As DataRow
    '                fila = dtDatos.NewRow

    '                fila("id_familiar") = record("idfld")

    '                fila("reloj") = registro("reloj")

    '                Dim nombre_familiar As String = ""

    '                Try
    '                    For Each n As String In record("nombre").ToString.Split(",")
    '                        nombre_familiar &= n & " "
    '                    Next
    '                    fila("nombre") = nombre_familiar

    '                Catch ex As Exception
    '                    fila("nombre") = record("nombre")
    '                End Try

    '                fila("cod_familia") = record("cod_familia")

    '                fila("imprimir") = 0

    '                fila("nombres") = registro("nombres")

    '                fila("cod_turno") = registro("cod_turno")

    '                fila("nomreloj") = registro("reloj") + " " + registro("nombres")

    '                Dim adicionales As String = ""

    '                For Each f As DataRow In dtSeleccion.Rows
    '                    adicionales &= RTrim(f("nombre")) & vbCrLf
    '                Next

    '                fila("adicionales") = adicionales

    '                dtDatos.Rows.Add(fila)
    '            Next


    '        Next

    '        Dim Familiares As New SeleccionarFamiliares
    '        Familiares.dtFamiliares = dtDatos
    '        If Familiares.ShowDialog() = DialogResult.OK Then
    '            dtDatos = Familiares.dtFamiliares.Select("imprimir=1").CopyToDataTable()
    '        End If

    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
    '        dtDatos.Rows.Clear()
    '        Debug.Print("ERROR EN " & System.Reflection.MethodBase.GetCurrentMethod.Name() & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
    '    End Try
    'End Sub
    Public Sub CentroFamiliar(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim edad_maxima As Integer = 22

        Dim filtros As String = frmReporteador.FiltrosAcumulados
        dtDatos = New DataTable
        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
        dtDatos.Columns.Add("parentesco", Type.GetType("System.String"))
        dtDatos.Columns.Add("edad", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("elegible", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_turno", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_familia", Type.GetType("System.String"))
        dtDatos.Columns.Add("imprimir", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("id_familiar", Type.GetType("System.String"))
        dtDatos.Columns.Add("adicionales", Type.GetType("System.String"))
        dtDatos.Columns.Add("nomreloj", Type.GetType("System.String"))
        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("id_familiar")}

        Dim dtSeleccion As DataTable

        Try

            For Each registro As DataRow In dtInformacion.Rows

                'dtSeleccion = sqlExecute("select familiares.*, familia.nombre as parentesco from  personal.dbo.familiares left join familia on familia.cod_familia = familiares.cod_familia where ((familiares.cod_familia in(05,06)) or (familiares.COD_FAMILIA in(07,08) and DATEDIFF(year, FECHA_NAC, getdate()) >= 15 and DATEDIFF(year, FECHA_NAC, getdate()) < 18)) and reloj = '" & registro("reloj") & "'")
                dtSeleccion = sqlExecute("select familiares.*, familia.nombre as parentesco, isnull(datediff(year, fecha_nac, getdate()), 0) as edad from  personal.dbo.familiares left join familia on familia.cod_familia = familiares.cod_familia where reloj = '" & registro("reloj") & "' and familiares.cod_familia in ('05', '06','07','08', '11', '12','13','14')")
                For Each record As DataRow In dtSeleccion.Rows
                    Dim fila As DataRow
                    fila = dtDatos.NewRow

                    fila("reloj") = registro("reloj")
                    fila("elegible") = "No"
                    fila("id_familiar") = record("idfld")

                    If record("cod_familia") = "05" Or record("cod_familia") = "06" Or record("cod_familia") = "11" Or record("cod_familia") = "12" Or record("cod_familia") = "13" Or record("cod_familia") = "14" Then
                        fila("elegible") = "Si"
                    End If

                    If record("cod_familia") = "07" Or record("cod_familia") = "08" Or record("cod_familia") = "14" Then
                        If record("edad") >= 15 And record("edad") < edad_maxima Then
                            fila("elegible") = "Si"
                        End If
                    End If

                    Dim nombre_familiar As String = ""

                    Try
                        For Each n As String In record("nombre").ToString.Split(",")
                            nombre_familiar &= n & " "
                        Next
                        If record("cod_familia") = "07" Or record("cod_familia") = "08" Or record("cod_familia") = "14" Then
                            If record("edad") < edad_maxima Then
                                fila("nombre") = RTrim(nombre_familiar)
                                fila("parentesco") = record("parentesco")

                                fila("edad") = record("edad")
                                fila("cod_familia") = record("cod_familia")

                            Else
                                fila("nombre") = Nothing
                                fila("parentesco") = Nothing

                                fila("edad") = DBNull.Value

                                fila("cod_familia") = DBNull.Value

                            End If
                        Else
                            fila("nombre") = RTrim(nombre_familiar)
                            fila("parentesco") = record("parentesco")

                            fila("edad") = record("edad")
                            fila("cod_familia") = record("cod_familia")
                        End If
                    Catch ex As Exception
                        fila("nombre") = record("nombre")
                    End Try

                    fila("imprimir") = 0

                    fila("nombres") = registro("nombres")

                    fila("cod_turno") = registro("cod_turno")

                    fila("nomreloj") = registro("reloj") + " " + registro("nombres")

                    Dim adicionales As String = ""

                    If record("edad") >= 15 And record("edad") < edad_maxima Then
                        adicionales = ""
                    Else
                        For Each f As DataRow In dtSeleccion.Rows
                            If f("idfld") <> record("idfld") Then
                                If f("cod_familia") = "07" Or f("cod_familia") = "08" Or f("cod_familia") = "14" Then
                                    adicionales &= IIf(f("edad") < edad_maxima, RTrim(f("nombre")) & vbCrLf, Nothing)
                                End If
                            End If

                        Next
                    End If

                    fila("adicionales") = RTrim(adicionales)

                    If IsNothing(adicionales) = False Or IsDBNull(fila("cod_familia")) = False Then
                        dtDatos.Rows.Add(fila)
                    End If
                Next


            Next

            Dim Familiares As New SeleccionarFamiliares
            Familiares.dtFamiliares = dtDatos
            If Familiares.ShowDialog() = DialogResult.OK Then
                dtDatos = Familiares.dtFamiliares.Select("imprimir=1").CopyToDataTable()
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos.Rows.Clear()
            Debug.Print("ERROR EN " & System.Reflection.MethodBase.GetCurrentMethod.Name() & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Public Sub ContratosVencidos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos = New DataTable
        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_planta", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_puesto", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_turno", Type.GetType("System.String"))
        dtDatos.Columns.Add("fecha_vencimiento", Type.GetType("System.String"))
        Dim dtTipo As DataTable
        Dim filtros As String = frmReporteador.FiltrosAcumulados
        Try
            For Each drow As DataRow In dtInformacion.Select(filtros)
                Dim reloj As String = drow("reloj")
                dtTipo = sqlExecute("select top 1 * from contratos_generados where reloj='" & reloj & "' order by fecha desc")
                For Each registro2 As DataRow In dtTipo.Rows
                    Dim tipo As String = registro2("tipo_contrato")
                    Dim fecha As String = IIf(IsDBNull(registro2("fecha_vencimiento")), Nothing, registro2("fecha_vencimiento"))
                    Dim fila As DataRow
                    If tipo = "003" And fecha < FechaSQL(Now) Then
                        fila = dtDatos.NewRow
                        fila("reloj") = drow("reloj")
                        fila("nombres") = drow("nombres")
                        fila("cod_planta") = drow("cod_planta")
                        fila("cod_depto") = drow("cod_depto")
                        fila("nombre_depto") = drow("nombre_depto")
                        fila("cod_super") = drow("cod_super")
                        fila("nombre_super") = drow("nombre_super")
                        fila("nombre_area") = drow("nombre_area")
                        fila("nombre_puesto") = drow("nombre_puesto")
                        fila("nombre_turno") = drow("nombre_turno")
                        fila("fecha_vencimiento") = registro2("fecha_vencimiento")
                        dtDatos.Rows.Add(fila)
                    End If
                Next
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub AsignacionSF(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim dtfiltrosf As DataTable

        dtfiltrosf = sqlExecute("select PersonalVW.reloj, PersonalVW.reloj_alt, PersonalVW.cod_depto, PersonalVW.centro_costos, PersonalVW.COD_SUPER, SF_Hirings.sf_id as sfid_super from super " &
                                "LEFT JOIN SF_Hirings on super.RELOJ = SF_Hirings.reloj " &
                                "LEFT JOIN PersonalVW on super.COD_SUPER = PersonalVW.COD_SUPER and super.COD_COMP = PersonalVW.COD_COMP")
        Dim resultado = (From tabla1 In dtfiltrosf
        Join tabla2 In dtFiltroPersonal On tabla1.Field(Of String)("Reloj") Equals tabla2.Field(Of String)("Reloj")
        Select tabla1)

        If resultado.Count() > 0 Then
            dtDatos = resultado.CopyToDataTable()
        End If

        Dim cl7t7e As New Data.DataColumn("c7T7E", GetType(System.String))
        cl7t7e.DefaultValue = "7T7E"
        dtDatos.Columns.Add(cl7t7e)

    End Sub
    Public Sub ExEmpleado(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos.Columns.Add("reloj")
        dtDatos.Columns.Add("mensaje")
        dtDatos.Columns.Add("nombre_rep")
        dtDatos.Columns.Add("path_firma")
        dtDatos.Columns.Add("fecha_letra")
        dtDatos.Columns.Add("telefono")

        Dim fecha As Date = Date.Now
        Dim fecha_completa As String = fecha.Day & " DE " & MesLetra(fecha) & " DEL " & fecha.Year
        Dim mensaje As String
        Dim fecha_baja As String
        Dim fecha_alta As String
        Dim telefono As String = ""
        For Each dR As DataRow In dtInformacion.Select("baja is not NULL")

            fecha_alta = dR("alta").Day & " de " & MesLetra(dR("alta")) & " del " & dR("alta").Year
            fecha_baja = dR("baja").Day & " de " & MesLetra(dR("baja")) & " del " & dR("baja").Year

            dR("nombres") = IIf(IsDBNull(dR("nombres")), "", dR("nombres"))
            dR("nombre_puesto") = IIf(IsDBNull(dR("nombre_puesto")), "", dR("nombre_puesto"))
            dR("nombre_horario") = IIf(IsDBNull(dR("nombre_horario")), "", dR("nombre_horario"))
            dR("nombre_planta") = IIf(IsDBNull(dR("nombre_planta")), "", dR("nombre_planta"))

            mensaje = "    Por medio de la presente hacemos constar que el C.<b>" & Trim(dR("nombres")) & "</b>, prestó sus servicios en esta " & _
                "empresa como: " & Trim(dR("nombre_puesto")) & ". Desde el " & Trim(fecha_alta) & " hasta el " & Trim(fecha_baja) & ", " & _
                "tenía un horario de " & Trim(dR("nombre_horario")) & " hrs."

            If Trim(dR("nombre_planta")) = "Juarez 1" Then
                telefono = "Tel. 656 1466000"
            ElseIf Trim(dR("nombre_planta")) = "Juarez 2" Then
                telefono = "Tel. 656 8007901"
            End If

            dtDatos.Rows.Add({dR("reloj"), _
                              mensaje, _
                              dR("nombre_rep"), _
                              dR("path_firma_rep"), _
                              fecha_completa, _
                              telefono
                             })



        Next

    End Sub
    Public Sub AfiliacionBNC(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim frm_fechas As New frmRangoFechas
        frm_fechas.frmRangoFechas_fecha_ini = Now.AddDays(-7)
        frm_fechas.frmRangoFechas_fecha_fin = Now

        frm_fechas.ShowDialog()

        Dim sfd As New SaveFileDialog

        Try
            sfd.DefaultExt = ".xlsx"
            sfd.FileName = "Afiliación BNC.xlsx"

            sfd.OverwritePrompt = True
            If sfd.ShowDialog() = DialogResult.OK Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook
                AfiliacionBNCexcel("afilia planta1", "cod_planta = 001 and alta >= '" & FechaSQL(FechaInicial) & "' and alta <= '" & FechaSQL(FechaFinal) & "'", wb, dtInformacion)
                AfiliacionBNCexcel("afilia planta2", "cod_planta = 002 and alta >= '" & FechaSQL(FechaInicial) & "' and alta <= '" & FechaSQL(FechaFinal) & "'", wb, dtInformacion)
                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub AfiliacionBNCexcel(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, dtDatos As DataTable)

        Dim x As Integer = 1
        Dim y As Integer = 1
        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

        hoja_excel.Cells(x, y).Value = "AFILIACION DE TARJETAS Y APERTURA DE CUENTAS POR BANCOMER NET CASH"
        hoja_excel.Cells(x, y).Style.Font.Name = "Courier New"
        hoja_excel.Cells(x, y).Style.Font.Size = 12
        hoja_excel.Cells(x, y).Style.Font.Bold = True
        hoja_excel.SelectedRange("A1:K1").Merge = True



        hoja_excel.Cells(x + 2, y).Value = "No. de Contrato de Nómina:"
        hoja_excel.Cells(x + 3, y).Value = "Número de lote:"
        hoja_excel.Cells(x + 3, y).AddComment("Valor consecutivo si se va a enviar mas de un archivo el mismo dia", "Detalle")
        hoja_excel.Cells(x + 3, y).Comment.Font.Size = 8
        hoja_excel.Cells(x + 4, y).Value = "RFC de la Empresa:"
        hoja_excel.Cells(x + 4, y).AddComment("Sin guiones y/o espacios. Debe incluir la homoclave", "Detalle")
        hoja_excel.Cells(x + 4, y).Comment.Font.Size = 8
        hoja_excel.Cells(x + 5, y).Value = "Sucursal Gestora de las cuentas:"
        hoja_excel.Cells(x + 5, y).AddComment("Sucursal de Banca comercial a la que llegaran los kits o que administrará las cuentas o tarjetas de los empleados", "Detalle")
        hoja_excel.Cells(x + 5, y).Comment.Font.Size = 8
        hoja_excel.Cells(x + 6, y).Value = "Descripción:"
        hoja_excel.Cells(x + 6, y).AddComment("descripción de lote, pe aperturas cuentas(máximo 30 posiciones sin Ñ o caracteres especiales)", "Detalle")
        hoja_excel.Cells(x + 6, y).Comment.Font.Size = 8
        hoja_excel.Cells(x + 7, y).Value = "Fecha de aplicación (AAAAMMDD):"
        hoja_excel.Cells(x + 8, y).Value = "Tipo de Servicio:"


        For val As Integer = 2 To 8
            hoja_excel.Cells(x + val, y).Style.Font.Name = "Courier New"
            hoja_excel.Cells(x + val, y).Style.Font.Size = 9
            hoja_excel.Cells(x + val, y).Style.Font.Bold = True
            hoja_excel.Cells(x + val, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            hoja_excel.Cells(x + val, y).Style.Fill.BackgroundColor.SetColor(Color.Blue)
            hoja_excel.Cells(x + val, y).Style.Font.Color.SetColor(Color.White)

        Next

        For val As Integer = 2 To 8
            hoja_excel.Cells(x + val, y + 1).Style.Font.Name = "Courier New"
            hoja_excel.Cells(x + val, y + 1).Style.Font.Size = 9
            hoja_excel.Cells(x + val, y + 1).Style.Font.Bold = True
            hoja_excel.Cells(x + val, y + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            hoja_excel.Cells(x + val, y + 1).Style.Fill.BackgroundColor.SetColor(Color.SkyBlue)
            hoja_excel.Cells(x + val, y + 1).Style.Font.Color.SetColor(Color.Black)

        Next

        x = 11
        y = 1

        hoja_excel.Cells(x, y).Value = "NOMBRE"
        hoja_excel.Row(x).Height = 38
        hoja_excel.Column(y).Width = 33
        hoja_excel.Cells(x, y + 1).Value = "APELLIDO PATERNO"
        hoja_excel.Column(y + 1).Width = 24
        hoja_excel.Cells(x, y + 2).Value = "APELLIDO MATERNO"
        hoja_excel.Column(y + 2).Width = 20
        hoja_excel.Cells(x, y + 3).Value = "FECHA DE NACIMIENTO (AAAA-MM-DD)"
        hoja_excel.Column(y + 3).Width = 15.9
        hoja_excel.Cells(x, y + 4).Value = "ESTADO CIVIL"
        hoja_excel.Cells(x, y + 4).AddComment("Estado civil: S = Soltero C = Casado V = Viudo D = Divorciad U = Unión Libre", "Detalle")
        hoja_excel.Cells(x, y + 4).Comment.Font.Size = 8
        hoja_excel.Column(y + 4).Width = 9
        hoja_excel.Cells(x, y + 5).Value = "CURP"
        hoja_excel.Column(y + 5).Width = 25
        hoja_excel.Cells(x, y + 6).Value = "SEXO"
        hoja_excel.Cells(x, y + 6).AddComment("Sexo: F = Femenino M = Masculino", "Detalle")
        hoja_excel.Cells(x, y + 6).Comment.Font.Size = 8
        hoja_excel.Column(y + 6).Width = 5
        hoja_excel.Cells(x, y + 7).Value = "NACIONALIDAD"
        hoja_excel.Cells(x, y + 7).AddComment("Nacionalidad: M = Mexicano E  = Extranjero", "Detalle")
        hoja_excel.Cells(x, y + 7).Comment.Font.Size = 8
        hoja_excel.Column(y + 7).Width = 13
        hoja_excel.Cells(x, y + 8).Value = "PAIS DE ORIGEN"
        hoja_excel.Column(y + 8).Width = 8
        hoja_excel.Cells(x, y + 9).Value = "OCUPACION"
        hoja_excel.Cells(x, y + 9).AddComment("Ocupación: PRI = Empleado Sector Privado GOB = Gobierno y Servidores Públicos OTR = Otros", "Detalle")
        hoja_excel.Cells(x, y + 9).Comment.Font.Size = 8
        hoja_excel.Column(y + 9).Width = 11
        hoja_excel.Cells(x, y + 10).Value = "FECHA DE INGRESO A LA EMPRESA (AAAA-MM-DD)"
        hoja_excel.Column(y + 10).Width = 22
        hoja_excel.Cells(x, y + 11).Value = "CALLE"
        hoja_excel.Column(y + 11).Width = 28
        hoja_excel.Cells(x, y + 12).Value = "No. EXTERIOR"
        hoja_excel.Column(y + 12).Width = 10
        hoja_excel.Cells(x, y + 13).Value = "No. INTERIOR"
        hoja_excel.Column(y + 13).Width = 9
        hoja_excel.Cells(x, y + 14).Value = "COLONIA"
        hoja_excel.Column(y + 14).Width = 30
        hoja_excel.Cells(x, y + 15).Value = "CODIGO POSTAL"
        hoja_excel.Column(y + 15).Width = 11
        hoja_excel.Cells(x, y + 16).Value = "POBLACION"
        hoja_excel.Column(y + 16).Width = 30
        hoja_excel.Cells(x, y + 17).Value = "ESTADO"
        hoja_excel.Column(y + 17).Width = 25
        hoja_excel.Cells(x, y + 18).Value = "TELEFONO PARTICULAR"
        hoja_excel.Cells(x, y + 18).AddComment("10 Dígitos", "Detalle")
        hoja_excel.Cells(x, y + 18).Comment.Font.Size = 8
        hoja_excel.Column(y + 18).Width = 21
        hoja_excel.Cells(x, y + 19).Value = "TELEFONO OFICINA"
        hoja_excel.Cells(x, y + 19).AddComment("10 Dígitos", "Detalle")
        hoja_excel.Cells(x, y + 19).Comment.Font.Size = 8
        hoja_excel.Column(y + 19).Width = 15
        hoja_excel.Cells(x, y + 20).Value = "EXTENCION OFICINA"
        hoja_excel.Cells(x, y + 20).AddComment("Máximo 4 caracteres", "Detalle")
        hoja_excel.Cells(x, y + 20).Comment.Font.Size = 8
        hoja_excel.Column(y + 20).Width = 12
        hoja_excel.Cells(x, y + 21).Value = "TIPO DE CLIENTE"
        hoja_excel.Cells(x, y + 21).AddComment("Tipo de cliente:    A = Empleado B = Becario P = Pensionado S = Subsidio", "Detalle")
        hoja_excel.Cells(x, y + 21).Comment.Font.Size = 8
        hoja_excel.Column(y + 21).Width = 9
        hoja_excel.Cells(x, y + 22).Value = "NUMERO DE TDD"
        hoja_excel.Cells(x, y + 22).AddComment("Ingresar el numero de la tarjeta (servicios 110,111 y 112)", "Detalle")
        hoja_excel.Cells(x, y + 22).Comment.Font.Size = 8
        hoja_excel.Column(y + 22).Width = 42
        hoja_excel.Cells(x, y + 23).Value = "INGRESO DEL TRABAJADOR"
        hoja_excel.Cells(x, y + 23).AddComment("Sin punto decimal, los dos último dígitos representan los decimales", "Detalle")
        hoja_excel.Cells(x, y + 23).Comment.Font.Size = 8
        hoja_excel.Column(y + 23).Width = 15
        hoja_excel.Cells(x, y + 24).Value = "NUMERO DE DISPERSIONES AL MES"
        hoja_excel.Cells(x, y + 24).AddComment("Número de Dispersiones al mes: 1 = Semanal 2 = Quincenal 4 = Semanal ", "Detalle")
        hoja_excel.Cells(x, y + 24).Comment.Font.Size = 8
        hoja_excel.Column(y + 24).Width = 13
        hoja_excel.Cells(x, y + 25).Value = "RELOJ"
        hoja_excel.Column(y + 25).Width = 13


        For val As Integer = 0 To 25

            If val = 22 Then
                hoja_excel.Cells(x, y + val).Style.Font.Name = "Calibri"
                hoja_excel.Cells(x, y + val).Style.Font.Size = 14
            Else
                hoja_excel.Cells(x, y + val).Style.Font.Name = "Courier New"
                hoja_excel.Cells(x, y + val).Style.Font.Size = 9
            End If
            hoja_excel.Cells(x, y + val).Style.Font.Bold = True
            hoja_excel.Cells(x, y + val).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            hoja_excel.Cells(x, y + val).Style.Fill.BackgroundColor.SetColor(Color.Blue)
            hoja_excel.Cells(x, y + val).Style.Font.Color.SetColor(Color.White)
            hoja_excel.Cells(x, y + val).Style.WrapText = True
            hoja_excel.Cells(x, y + val).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
            hoja_excel.Cells(x, y + val).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center
            hoja_excel.Cells(x, y + val).Style.Border.Right.Style = Style.ExcelBorderStyle.Thin
            hoja_excel.Cells(x, y + val).Style.Border.Right.Color.SetColor(Color.White)

        Next

        For Each row As DataRow In dtDatos.Select(filtro)


            hoja_excel.Cells(x + 1, y).Value = row("nombre")
            hoja_excel.Cells(x + 1, y + 1).Value = row("apaterno")
            hoja_excel.Cells(x + 1, y + 2).Value = row("amaterno")
            If IsDBNull(row("fha_nac")) Then
                hoja_excel.Cells(x + 1, y + 3).Value = ""
            Else
                hoja_excel.Cells(x + 1, y + 3).Value = Date.Parse(row("fha_nac")).ToString("yyyy-MM-dd")
            End If

            hoja_excel.Cells(x + 1, y + 4).Value = "S"
            hoja_excel.Cells(x + 1, y + 5).Value = row("curp")
            hoja_excel.Cells(x + 1, y + 6).Value = row("sexo")
            hoja_excel.Cells(x + 1, y + 7).Value = "M"
            hoja_excel.Cells(x + 1, y + 8).Value = "MEX"
            hoja_excel.Cells(x + 1, y + 9).Value = "PRI"
            hoja_excel.Cells(x + 1, y + 10).Value = Date.Parse(row("alta")).ToString("yyyy-MM-dd")
            hoja_excel.Cells(x + 1, y + 11).Value = "AVE DE LAS INDUSTRIAS"
            hoja_excel.Cells(x + 1, y + 12).Value = "2250"
            hoja_excel.Cells(x + 1, y + 13).Value = ""
            hoja_excel.Cells(x + 1, y + 14).Value = "ANTONIO J BERMUDEZ"
            hoja_excel.Cells(x + 1, y + 15).Value = "32649"
            hoja_excel.Cells(x + 1, y + 16).Value = "JUAREZ"
            hoja_excel.Cells(x + 1, y + 17).Value = "CHIHUAHUA"
            hoja_excel.Cells(x + 1, y + 18).Value = "6561466000"
            hoja_excel.Cells(x + 1, y + 19).Value = "6561466000"
            hoja_excel.Cells(x + 1, y + 20).Value = "0000"
            hoja_excel.Cells(x + 1, y + 21).Value = "A"
            hoja_excel.Cells(x + 1, y + 22).Value = ""
            hoja_excel.Cells(x + 1, y + 23).Value = "3600"
            hoja_excel.Cells(x + 1, y + 24).Value = "4"
            hoja_excel.Cells(x + 1, y + 25).Value = row("reloj")

            x = x + 1
        Next

    End Sub
    Public Sub Etiquetas_empleado(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim z As Integer
            Dim dtEtiquetas As DataTable = sqlExecute("select * from etiquetas where etiqueta = 'AVERY 5161'")
            Dim Reporte As String = ""
            For Each row As DataRow In dtEtiquetas.Rows
                z = row.Item("numero_etiquetas")
                Reporte = row.Item("Reporte").ToString.Trim
            Next

            'Dim dtDatos As New DataTable
            Dim x As Integer
            Dim dtpares As New DataTable
            dtpares.Columns.Add("reloj")
            Dim Columnas(1) As DataColumn
            Dim fr As New frmEtiquetas
            Dim dtDatosCia As New DataTable

            ReDim EtiquetasDisponibles(40)

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reloj011", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("reloj012", System.Type.GetType("System.String"))



            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next

            For x = 0 To EtiquetasDisponibles.Count - 1
                EtiquetasDisponibles(x) = 1
            Next
            fr.MAXIMO_ETIQUETAS = z
            fr.ShowDialog()
            x = 0
            Dim dReg As DataRow = Nothing
            Dim y As Integer = 0
            Dim conteo As Integer = 0
            Dim relojes As String = ""

            'Crear tabla con doble registro, para que aparescan 2 relojes por etiqueta
            For Each dRe As DataRowView In dtInformacion.DefaultView

                If y < 1 Then
                    relojes = "*" & dRe("reloj") & "*"
                    y = y + 1

                    If conteo = dtInformacion.Rows.Count - 1 Then
                        dtpares.Rows.Add({relojes})
                    End If
                Else
                    relojes = relojes & " " & "*" & dRe("reloj") & "*"
                    dtpares.Rows.Add({relojes})
                    y = 0
                End If

                conteo = conteo + 1

            Next

            For Each dRow As DataRowView In dtpares.DefaultView
                Do While x < z
                    If EtiquetasDisponibles(x) = 1 Then
                        'Si esta etiqueta está disponible, salir del ciclo y pasar información
                        Exit Do
                    Else

                        'Si la etiqueta no está disponible, ignorarla
                        If x Mod 2 = 0 Then
                            'Si x es par, agregar registro en blanco
                            dReg = dtDatos.NewRow
                        Else
                            'Si x es non, insertar el registro en la tabla
                            dtDatos.Rows.Add(dReg)
                        End If

                        x = x + 1

                    End If
                Loop
                If x Mod 2 = 0 Then
                    'Si x es par, generar registro en blanco
                    dReg = dtDatos.NewRow
                End If
                'Pasar la información a la tabla. Si la x es par, ponerlo en la columna 1, si es non, en columna 2.
                Dim prueba = dRow.Item("reloj")


                dReg("reloj01" & (x Mod 2) + 1) = dRow.Item("reloj")
                If x Mod 2 = 1 Then
                    'Si x es non, insertar el registro en la tabla 
                    dtDatos.Rows.Add(dReg)
                End If
                x = x + 1

                'BG 19/10/15
                Dim a As Integer
                a = dtpares.Rows.Count
                If x = a And x Mod 2 = 1 Then
                    dtDatos.Rows.Add(dReg)
                End If


                If x >= z Then
                    'Si ya se completaron las 30 etiquetas, 
                    'considerar que la siguiente hoja de etiquetas está completa, y poner todas como disponibles
                    For x = 0 To z
                        EtiquetasDisponibles(x) = 1
                    Next
                    'Reiniciar X para iniciar en el tope de la hoja
                    x = 0
                End If
            Next


            dtDatos.Rows.Add(dReg)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)

        End Try
    End Sub
    Public Sub DifFechasAltas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        dtDatos.Columns.Add("reloj")
        dtDatos.Columns.Add("nombres")
        dtDatos.Columns.Add("depto")
        dtDatos.Columns.Add("nombre_depto")
        dtDatos.Columns.Add("tipo")
        dtDatos.Columns.Add("planta")
        dtDatos.Columns.Add("sf")
        dtDatos.Columns.Add("f_alta")
        dtDatos.Columns.Add("f_vac")



        For Each Dr As DataRow In dtInformacion.Select("alta <> alta_vacacion")

            dtDatos.Rows.Add({Dr("reloj"),
                              Trim(Dr("nombres")),
                              Dr("cod_depto"),
                              Trim(Dr("nombre_depto")),
                              Dr("cod_tipo"),
                              Dr("cod_planta"),
                              Trim(Dr("reloj_alt")),
                              Dr("alta"),
                              Dr("alta_vacacion")
                             })

        Next


    End Sub
    Public Sub BRPHC(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim dia, fecha As String
        dia = "Lunes"
        Dim pantalla As New frmSeleccionaPeriodo
        pantalla.ShowDialog()

        Dim tdfecha As DataTable = sqlExecute("select * from periodos where ano='" & AnoSelec & "' and periodo='" & PeriodoSelec & "'", "TA")
        FechaInicial = tdfecha.Rows(0)("fecha_ini")
        dtDatos.Columns.Add("COMPAÑIA")
        dtDatos.Columns.Add("CENTRO")
        dtDatos.Columns.Add("CLASE")
        dtDatos.Columns.Add("LUNES", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("MARTES", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("MIERCOLES", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("JUEVES", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("VIERNES", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("SABADO", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("DOMINGO", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("PROMEDIO", Type.GetType("System.Int32"))
        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("COMPAÑIA"), dtDatos.Columns("CENTRO"), dtDatos.Columns("CLASE")}
        'Lunes------------------------------------------------
        If (dia = "Lunes") Then
            fecha = String.Format(FechaInicial.Date.AddDays(0))
            Dim tdlunes As DataTable = sqlExecute("select cod_comp,centro_costos,nombre_clase,count(reloj)  " + dia + " from dbo.personalvw where cod_comp='610' and alta<='" + FechaSQL(fecha) + "' and (baja is null or baja >'" + FechaSQL(fecha) + "') group by cod_comp,centro_costos,nombre_clase ORDER BY CENTRO_COSTOS asc")
            For Each row As DataRow In tdlunes.Rows
                Dim rowlunes As DataRow = dtDatos.Rows.Find({row("cod_comp").ToString, row("centro_costos").ToString, row("nombre_clase").ToString})
                If rowlunes Is Nothing Then
                    rowlunes = dtDatos.NewRow
                    rowlunes("COMPAÑIA") = row("cod_comp")
                    rowlunes("CENTRO") = IIf(IsDBNull(row("centro_costos")), "", row("centro_costos")).ToString.Trim  'row("centro_costos") 
                    rowlunes("CLASE") = IIf(IsDBNull(row("nombre_clase")), "", row("nombre_clase")).ToString.Trim   'row("nombre_clase")
                    rowlunes("LUNES") = row(dia)
                    dtDatos.Rows.Add(rowlunes)
                End If

            Next
            dia = "Martes"
        End If
        'Martes-----------------------------------------------
        If (dia = "Martes") Then
            fecha = String.Format(FechaInicial.Date.AddDays(1))
            Dim tdmartes As DataTable = sqlExecute("select cod_comp,centro_costos,nombre_clase,count(reloj)  " + dia + " from dbo.personalvw where cod_comp='610' and alta<='" + FechaSQL(fecha) + "' and (baja is null or baja >'" + FechaSQL(fecha) + "') group by cod_comp,centro_costos,nombre_clase ORDER BY CENTRO_COSTOS asc")
            For Each row As DataRow In tdmartes.Rows
                Dim rowmartes As DataRow = dtDatos.Rows.Find({row("cod_comp").ToString, row("centro_costos").ToString, row("nombre_clase").ToString})
                If rowmartes Is Nothing Then
                    rowmartes = dtDatos.NewRow
                    rowmartes("COMPAÑIA") = row("cod_comp")
                    rowmartes("CENTRO") = IIf(IsDBNull(row("centro_costos")), "", row("centro_costos")).ToString.Trim  'row("centro_costos") 
                    rowmartes("CLASE") = IIf(IsDBNull(row("nombre_clase")), "", row("nombre_clase")).ToString.Trim   'row("nombre_clase")
                    rowmartes("MARTES") = row(dia)
                    dtDatos.Rows.Add(rowmartes)
                Else
                    rowmartes("MARTES") = row(dia)
                End If

            Next
            dia = "Miercoles"
        End If
        'Miercoles---------------------------------------------
        If (dia = "Miercoles") Then
            fecha = String.Format(FechaInicial.Date.AddDays(2))
            Dim tdmartes As DataTable = sqlExecute("select cod_comp,centro_costos,nombre_clase,count(reloj)  " + dia + " from dbo.personalvw where cod_comp='610' and alta<='" + FechaSQL(fecha) + "' and (baja is null or baja >'" + FechaSQL(fecha) + "') group by cod_comp,centro_costos,nombre_clase ORDER BY CENTRO_COSTOS asc")
            For Each row As DataRow In tdmartes.Rows
                Dim rowmartes As DataRow = dtDatos.Rows.Find({row("cod_comp".ToString), row("centro_costos").ToString, row("nombre_clase").ToString})
                If rowmartes Is Nothing Then
                    rowmartes = dtDatos.NewRow
                    rowmartes("COMPAÑIA") = row("cod_comp")
                    rowmartes("CENTRO") = IIf(IsDBNull(row("centro_costos")), "", row("centro_costos")).ToString.Trim  'row("centro_costos")
                    rowmartes("CLASE") = IIf(IsDBNull(row("nombre_clase")), "", row("nombre_clase")).ToString.Trim   'row("nombre_clase")
                    rowmartes("MIERCOLES") = row(dia)
                    dtDatos.Rows.Add(rowmartes)
                Else
                    rowmartes("MIERCOLES") = row(dia)
                End If

            Next
            dia = "Jueves"
        End If
        'Jueves--------------------------------------------------
        If (dia = "Jueves") Then
            fecha = String.Format(FechaInicial.Date.AddDays(3))
            Dim tdmartes As DataTable = sqlExecute("select cod_comp,centro_costos,nombre_clase,count(reloj)  " + dia + " from dbo.personalvw where cod_comp='610' and alta<='" + FechaSQL(fecha) + "' and (baja is null or baja >'" + FechaSQL(fecha) + "') group by cod_comp,centro_costos,nombre_clase ORDER BY CENTRO_COSTOS asc")
            For Each row As DataRow In tdmartes.Rows
                Dim rowmartes As DataRow = dtDatos.Rows.Find({row("cod_comp").ToString, row("centro_costos").ToString, row("nombre_clase").ToString})
                If rowmartes Is Nothing Then
                    rowmartes = dtDatos.NewRow
                    rowmartes("COMPAÑIA") = row("cod_comp")
                    rowmartes("CENTRO") = IIf(IsDBNull(row("centro_costos")), "", row("centro_costos")).ToString.Trim  'row("centro_costos")
                    rowmartes("CLASE") = IIf(IsDBNull(row("nombre_clase")), "", row("nombre_clase")).ToString.Trim   'row("nombre_clase")
                    rowmartes("JUEVES") = row(dia)
                    dtDatos.Rows.Add(rowmartes)
                Else
                    rowmartes("JUEVES") = row(dia)
                End If

            Next
            dia = "Viernes"
        End If
        'Viernes-------------------------------------------------
        If (dia = "Viernes") Then
            fecha = String.Format(FechaInicial.Date.AddDays(4))
            Dim tdmartes As DataTable = sqlExecute("select cod_comp,centro_costos,nombre_clase,count(reloj)  " + dia + " from dbo.personalvw where cod_comp='610' and alta<='" + FechaSQL(fecha) + "' and (baja is null or baja >'" + FechaSQL(fecha) + "') group by cod_comp,centro_costos,nombre_clase ORDER BY CENTRO_COSTOS asc")
            For Each row As DataRow In tdmartes.Rows
                Dim rowmartes As DataRow = dtDatos.Rows.Find({row("cod_comp").ToString, row("centro_costos").ToString, row("nombre_clase").ToString})
                If rowmartes Is Nothing Then
                    rowmartes = dtDatos.NewRow
                    rowmartes("COMPAÑIA") = row("cod_comp")
                    rowmartes("CENTRO") = IIf(IsDBNull(row("centro_costos")), "", row("centro_costos")).ToString.Trim  'row("centro_costos")
                    rowmartes("CLASE") = IIf(IsDBNull(row("nombre_clase")), "", row("nombre_clase")).ToString.Trim   'row("nombre_clase")
                    rowmartes("VIERNES") = row(dia)
                    dtDatos.Rows.Add(rowmartes)
                Else
                    rowmartes("VIERNES") = row(dia)
                End If

            Next
            dia = "Sabado"
        End If
        'Sabado---------------------------------------------------
        If (dia = "Sabado") Then
            fecha = String.Format(FechaInicial.Date.AddDays(5))
            Dim tdmartes As DataTable = sqlExecute("select cod_comp,centro_costos,nombre_clase,count(reloj)  " + dia + " from dbo.personalvw where cod_comp='610' and alta<='" + FechaSQL(fecha) + "' and (baja is null or baja >'" + FechaSQL(fecha) + "') group by cod_comp,centro_costos,nombre_clase ORDER BY CENTRO_COSTOS asc")
            For Each row As DataRow In tdmartes.Rows
                Dim rowmartes As DataRow = dtDatos.Rows.Find({row("cod_comp").ToString, row("centro_costos").ToString, row("nombre_clase").ToString})
                If rowmartes Is Nothing Then
                    rowmartes = dtDatos.NewRow
                    rowmartes("COMPAÑIA") = row("cod_comp")
                    rowmartes("CENTRO") = IIf(IsDBNull(row("centro_costos")), "", row("centro_costos")).ToString.Trim  'row("centro_costos")
                    rowmartes("CLASE") = IIf(IsDBNull(row("nombre_clase")), "", row("nombre_clase")).ToString.Trim   'row("nombre_clase")
                    rowmartes("SABADO") = row(dia)
                    dtDatos.Rows.Add(rowmartes)
                Else
                    rowmartes("SABADO") = row(dia)
                End If

            Next
            dia = "Domingo"
        End If
        'Domingo--------------------------------------------------
        If (dia = "Domingo") Then
            fecha = String.Format(FechaInicial.Date.AddDays(6))
            Dim tdmartes As DataTable = sqlExecute("select cod_comp,centro_costos,nombre_clase,count(reloj)  " + dia + " from dbo.personalvw where cod_comp='610' and alta<='" + FechaSQL(fecha) + "' and (baja is null or baja >'" + FechaSQL(fecha) + "') group by cod_comp,centro_costos,nombre_clase ORDER BY CENTRO_COSTOS asc")
            For Each row As DataRow In tdmartes.Rows
                Dim rowmartes As DataRow = dtDatos.Rows.Find({row("cod_comp").ToString, row("centro_costos").ToString, row("nombre_clase").ToString})
                If rowmartes Is Nothing Then
                    rowmartes = dtDatos.NewRow
                    rowmartes("COMPAÑIA") = row("cod_comp")
                    rowmartes("CENTRO") = IIf(IsDBNull(row("centro_costos")), "", row("centro_costos")).ToString.Trim  'row("centro_costos")
                    rowmartes("CLASE") = IIf(IsDBNull(row("nombre_clase")), "", row("nombre_clase")).ToString.Trim   'row("nombre_clase")
                    rowmartes("DOMINGO") = row(dia)
                    dtDatos.Rows.Add(rowmartes)
                Else
                    rowmartes("DOMINGO") = row(dia)
                End If

            Next
            dia = "null"
        End If

    End Sub
    Public Sub segurosmonterrey(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        'Dim Renglon As DataRow = dtDatos.NewRow()
        dtDatos.Columns.Add("RELOJ")
        dtDatos.Columns.Add("COD_TIPO")
        dtDatos.Columns.Add("NOMBRES")
        dtDatos.Columns.Add("SEXO")
        dtDatos.Columns.Add("FHA_NAC")
        dtDatos.Columns.Add("PARENTESCO")
        dtDatos.Columns.Add("MOVIMIENTO")
        dtDatos.Columns.Add("FECHA_MOVIMIENTO")
        dtDatos.Columns.Add("OBSERVACIONES")
        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("RELOJ"), dtDatos.Columns("COD_TIPO"), dtDatos.Columns("NOMBRES")}

        'Dim tdseguros As DataTable = sqlExecute("select reloj,cod_tipo,nombres,sexo,fha_nac,alta,baja from personal.dbo.personalvw")

        For Each row As DataRow In dtInformacion.Rows
            Dim rowseguros As DataRow = dtDatos.Rows.Find({row("RELOJ"), row("COD_TIPO"), row("NOMBRES")})
            If rowseguros Is Nothing Then
                rowseguros = dtDatos.NewRow
                rowseguros("RELOJ") = row("reloj")
                rowseguros("COD_TIPO") = row("cod_tipo")
                rowseguros("NOMBRES") = row("nombres")
                rowseguros("SEXO") = row("sexo")
                rowseguros("FHA_NAC") = String.Format(row("fha_nac"), "yyyy-MM-dd")
                rowseguros("PARENTESCO") = "T"
                If IsDBNull(row("baja")) Then
                    rowseguros("MOVIMIENTO") = "A"
                    rowseguros("FECHA_MOVIMIENTO") = FechaSQL(row("alta"))
                Else
                    rowseguros("MOVIMIENTO") = "B"
                    rowseguros("FECHA_MOVIMIENTO") = FechaSQL(row("baja"))
                End If

            End If
            dtDatos.Rows.Add(rowseguros)
        Next

    End Sub
    Public Sub ReporteVacacionesQRO(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        dtDatos = New DataTable()
        Dim fechaproy As Date
        Dim selFecha As frmSeleccionarFecha = New frmSeleccionarFecha()
        selFecha.ShowDialog()
        fechaproy = selFecha.dtFechaInicial.Value
        dtDatos.Merge(SaldosVacacionesQRO(fechaproy))
    End Sub

    Public Sub ResultadosEncuestaCafeteriaExcel()
        Dim sfd As New SaveFileDialog
        Try

            frmRangoFechas.ShowDialog()

            Dim F_ini As String = FechaSQL(FechaInicial)
            Dim F_fin As String = FechaSQL(FechaFinal)
            sfd.DefaultExt = ".xlsx"
            sfd.FileName = "Resultados encuesta cafetería " & F_ini & " - " & F_fin & ".xlsx"

            sfd.OverwritePrompt = True
            If sfd.ShowDialog() = DialogResult.OK Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                '

                frmTrabajando.Show()

                CafeteriaResultados("Planta 1", "", wb, F_ini, F_fin)
                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))

                ActivoTrabajando = False
                frmTrabajando.Close()



            End If
            MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub CafeteriaResultados(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, f_ini As String, f_fin As String)

        Dim dtencuesta As DataTable = sqlExecute("select encuestas_detalles.RELOJ,encuestas_detalles.COD_PREGUNTA, encuestas_preguntas.texto," & _
                                                 "encuestas_detalles.COD_RESPUESTA, encuestas_respuestas.valor, encuestas_detalles.fecha, encuestas_detalles.detalle_libre " & _
                                                 "from encuestas_detalles left join encuestas_preguntas on " & _
                                                 "encuestas_detalles.COD_PREGUNTA=encuestas_preguntas.COD_PREGUNTA " & _
                                                 "left join encuestas_respuestas on encuestas_detalles.COD_RESPUESTA=encuestas_respuestas.COD_RESPUESTA " & _
                                                 "left join personal.dbo.personalvw on encuestas_detalles.RELOJ = PersonalVW.reloj " & _
                                                 "where encuestas_preguntas.COD_ENCUESTA='10006' and encuestas_detalles.fecha between '" & f_ini & "' and '" & f_fin & "' order by FECHA desc", "KIOSCO")

        Dim x As Integer = 1
        Dim y As Integer = 1
        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

        hoja_excel.Cells(x, y).Value = "RELOJ"
        hoja_excel.Cells(x, y).Style.Font.Bold = True
        hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
        hoja_excel.Cells(x, y).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(x, y + 1).Value = "PREGUNTA"
        hoja_excel.Cells(x, y + 1).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(x, y + 1).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
        hoja_excel.Cells(x, y + 1).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(x, y + 2).Value = "RESPUESTA"
        hoja_excel.Cells(x, y + 2).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 2).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(x, y + 2).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
        hoja_excel.Cells(x, y + 2).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(x, y + 3).Value = "FECHA"
        hoja_excel.Cells(x, y + 3).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(x, y + 3).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
        hoja_excel.Cells(x, y + 3).Style.Font.Color.SetColor(Color.White)

        For Each dr As DataRow In dtencuesta.Rows
            x += 1
            frmTrabajando.lblAvance.Text = dr("reloj")
            Application.DoEvents()
            hoja_excel.Cells(x, y).Value = dr("reloj")
            hoja_excel.Cells(x, y + 1).Value = dr("texto")
            hoja_excel.Cells(x, y + 2).Value = dr("valor")
            hoja_excel.Cells(x, y + 3).Value = Date.Parse(dr("fecha")).ToString("yyyy-MM-dd")

        Next
        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()
    End Sub
    Public Sub Recomendaciones(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Try
            frmRangoFechas.ShowDialog()

            Dim monto30 As Double = 0
            Dim monto90 As Double = 0
            Dim ret30 As Integer = 0
            Dim ret90 As Integer = 0
            Dim per30 As Integer = 0
            Dim per90 As Integer = 0
            Dim fecha_i As String = FechaSQL(FechaInicial)
            Dim fecha_f As String = FechaSQL(FechaFinal)


            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre", Type.GetType("System.String"))
            dtDatos.Columns.Add("relojrec", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombrerec", Type.GetType("System.String"))
            dtDatos.Columns.Add("turnorec", Type.GetType("System.String"))
            dtDatos.Columns.Add("altarec", Type.GetType("System.String"))
            dtDatos.Columns.Add("monto30", Type.GetType("System.Double"))
            dtDatos.Columns.Add("monto90", Type.GetType("System.Double"))
            dtDatos.Columns.Add("capturado_por", Type.GetType("System.String"))
            dtDatos.Columns.Add("fechai", Type.GetType("System.String"))
            dtDatos.Columns.Add("fechaf", Type.GetType("System.String"))
            dtDatos.Columns.Add("altas_t", Type.GetType("System.Int32"))

            'dtDatos.Columns.Add("ret_30", Type.GetType("System.Int32"))
            'dtDatos.Columns.Add("ret_90", Type.GetType("System.Int32"))
            'dtDatos.Columns.Add("per_30", Type.GetType("System.Int32"))
            'dtDatos.Columns.Add("per_90", Type.GetType("System.Int32"))



            dtDatos.Columns.Item("fechai").DefaultValue = fecha_i
            dtDatos.Columns.Item("fechaf").DefaultValue = fecha_f

            Dim altas As DataTable = sqlExecute("select * from personal where alta between '" & FechaSQL(fecha_i) & "' and '" & FechaSQL(fecha_f) & "'")

            dtDatos.Columns.Item("altas_t").DefaultValue = altas.Rows.Count
            Dim dttemp As DataTable = sqlExecute("select detalle_auxiliares.*, personal1.nombres as nombre1, personal2.nombres as nombre2, personal2.cod_turno,personal2.alta, personal2.baja " & _
                                                 "from detalle_auxiliares " & _
                                                 "left join personalvw as personal1 on detalle_auxiliares.contenido = personal1.reloj " & _
                                                 "left join personalvw as personal2 on detalle_auxiliares.reloj = personal2.reloj " & _
                                                 "where detalle_auxiliares.campo = 'RECOMEN' and personal2.alta between '" & FechaSQL(fecha_i) & "' and '" & FechaSQL(fecha_f) & "'")


            If dttemp.Rows.Count > 0 Then
                For Each dx As DataRow In dttemp.Rows
                    ConsultaBitacora(dttemp, dx, dx("alta"))
                    monto30 = 0
                    monto90 = 0
                    Dim dtnomina As DataTable = sqlExecute("select * from ajustes_nom where concepto = 'BONREC' and reloj = '" & dx("contenido") & "' and comentario like '%" & dx("reloj") & "%' and usuario = 'EXPORT'", "NOMINA")
                    If dtnomina.Rows.Count > 0 Then
                       
                        For Each dn As DataRow In dtnomina.Rows
                            Dim coment As String = dn("comentario")


                            If coment.Contains("Bono 90") Then
                                monto90 = dn("monto")
                                ret90 = ret90 + 1
                            ElseIf coment.Contains("Bono 200") Then
                                monto30 = dn("monto")
                                'ret30 = ret30 + 1
                            ElseIf coment.Contains("Bono 800") Then
                                monto90 = dn("monto")
                                ret90 = ret90 + 1
                            End If

                        Next
                    End If

                    If Not IsDBNull(dx("baja")) Then
                        Dim totaldias As Integer = DateDiff(DateInterval.Day, dx("alta"), dx("baja"))
                        If totaldias < 30 Then
                            per30 = per30 + 1
                        ElseIf totaldias < 90 Then
                            per90 = per90 + 1
                        End If

                    End If


                    dtDatos.Rows.Add({dx("contenido"),
                                      dx("nombre1"),
                                      dx("reloj"),
                                      dx("nombre2"),
                                    dx("cod_turno"),
                                      dx("alta"),
                                      monto30,
                                      monto90,
                                      dx("usuario")
                                     })

                Next


                Dim ret_30 As New Data.DataColumn("ret_30", Type.GetType("System.Int32"))
                Dim ret_90 As New Data.DataColumn("ret_90", Type.GetType("System.Int32"))
                Dim per_30 As New Data.DataColumn("per_30", Type.GetType("System.Int32"))
                Dim per_90 As New Data.DataColumn("per_90", Type.GetType("System.Int32"))
                ret_30.DefaultValue = ret30
                ret_90.DefaultValue = ret90
                per_30.DefaultValue = per30
                per_90.DefaultValue = per90
                dtDatos.Columns.Add(ret_30)
                dtDatos.Columns.Add(ret_90)
                dtDatos.Columns.Add(per_30)
                dtDatos.Columns.Add(per_90)



            End If




        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Recomendaciones", ex.HResult, ex.Message)
        End Try

    End Sub
    Public Sub ReporteRecomendacionNomina(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal tipo_periodo As String)
        Try
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("reloj_rec", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_rec", Type.GetType("System.String"))
            dtDatos.Columns.Add("captura", Type.GetType("System.String"))
            dtDatos.Columns.Add("planta", Type.GetType("System.String"))
            dtDatos.Columns.Add("turno", Type.GetType("System.String"))
            dtDatos.Columns.Add("alta", Type.GetType("System.String"))
            dtDatos.Columns.Add("monto", Type.GetType("System.Double"))
            dtDatos.Columns.Add("anoperiodo", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha", Type.GetType("System.DateTime"))
            Dim reloj_rec As String = ""
            Dim nombre_rec As String = ""
            Dim turno As String = ""
            Dim captura As String = ""
            Dim planta As String = ""
            Dim alta As String = ""
            Dim anoperiodo As String = ""
            Dim fecha As DateTime
            frmSeleccionaPeriodo.ShowDialog()

            anoperiodo = "Periodo " & AnoSelec & "-" & PeriodoSelec
            Dim dtnomina As DataTable = sqlExecute("select * from ajustes_nom where ano = '" & AnoSelec & "' and periodo = '" & PeriodoSelec & "' and concepto = 'BONREC' and tipo_periodo = '" & tipo_periodo & "'", "NOMINA")
            For Each dr As DataRow In dtInformacion.Rows



                For Each db As DataRow In dtnomina.Select("reloj = '" & dr("reloj") & "'")
                    reloj_rec = ""
                    nombre_rec = ""
                    captura = ""
                    planta = ""
                    turno = ""
                    alta = ""
                    fecha = Nothing
                    If Trim(db("usuario")) = "EXPORT" Then
                        reloj_rec = Trim(db("comentario")).Substring(Trim(db("comentario")).Length - 6, 6)
                        Dim dtpersonal As DataTable = sqlExecute("select * from personalvw where reloj = '" & reloj_rec & "'")
                        If dtpersonal.Rows.Count > 0 Then
                            nombre_rec = IIf(IsDBNull(dtpersonal.Rows(0).Item("nombres")), "N/A", dtpersonal.Rows(0).Item("nombres"))
                            turno = IIf(IsDBNull(dtpersonal.Rows(0).Item("cod_turno")), "N/A", dtpersonal.Rows(0).Item("cod_turno"))
                            planta = IIf(IsDBNull(dtpersonal.Rows(0).Item("cod_planta")), "N/A", dtpersonal.Rows(0).Item("cod_planta"))
                            alta = IIf(IsDBNull(dtpersonal.Rows(0).Item("alta")), "N/A", dtpersonal.Rows(0).Item("alta"))
                        End If
                        Dim dtauxiliar As DataTable = sqlExecute("select * from detalle_auxiliares where reloj = '" & reloj_rec & "' and contenido = '" & dr("reloj") & "' and campo = 'RECOMEN'")
                        If dtauxiliar.Rows.Count > 0 Then
                            captura = IIf(IsDBNull(dtauxiliar.Rows(0).Item("usuario")), "N/A", dtauxiliar.Rows(0).Item("usuario"))
                            fecha = IIf(IsDBNull(dtauxiliar.Rows(0).Item("fecha")), Nothing, dtauxiliar.Rows(0).Item("fecha"))
                        End If


                    End If

                    dtDatos.Rows.Add({dr("reloj"),
                                      reloj_rec,
                                      dr("nombres"),
                                      nombre_rec,
                                      captura.TrimEnd,
                                      planta,
                                      turno,
                                      alta,
                                      db("monto"),
                                      anoperiodo,
                                      fecha})
                Next

            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Recomendaciones", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub vacaciones_prueba(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim fecha_proy_vac As Date


        frmSeleccionarFecha.ShowDialog()


        Try
            fecha_proy_vac = fechaultimo


            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
            dtDatos.Columns.Add("alta")
            dtDatos.Columns.Add("alta_antiguedad")


            dtDatos.Columns.Add("dias_vac", Type.GetType("System.Double"))
            dtDatos.Columns.Add("dias_tomados", Type.GetType("System.Double"))
            dtDatos.Columns.Add("total_dias", Type.GetType("System.Double"))

            dtDatos.Columns.Add("fecha_ini", Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_fin", Type.GetType("System.String"))
            dtDatos.Columns.Add("dias_proporcion", Type.GetType("System.String"))
            dtDatos.Columns.Add("formula", Type.GetType("System.String"))
            Dim drDatos As DataRow
            For Each dr As DataRow In dtInformacion.Select("COD_COMP = '610' and baja is NULL")
                drDatos = dtDatos.NewRow
                Dim f_inicio As Date = Nothing
                Dim f_fin As Date = Nothing
                Dim f_antiguedad As Date = Nothing
                Dim saldo_ant As Double = 0
                Dim ganados As Double = 0
                Dim pagados As Integer = 0
                Dim saldo_nuevo As Double = 0
                Dim comentario As String = ""

                Dim dtvac As New DataTable
                Dim dtvac_aus As New DataTable

                drDatos("reloj") = dr("reloj")
                drDatos("nombre") = dr("nombres")
                drDatos("cod_tipo") = dr("cod_tipo")
                drDatos("cod_depto") = dr("cod_depto")
                drDatos("alta") = dr("alta")
                drDatos("alta_antiguedad") = dr("alta_vacacion")

                If IsDBNull(dr("alta_vacacion")) Then
                    Continue For
                End If

                Dim dtperiodos_vac_sum As DataTable = sqlExecute("SELECT reloj, sum(dias_ganados) as total FROM periodos_vac where reloj = '" & dr("reloj") & "' and fecha_fin < '" & FechaSQL(fecha_proy_vac) & "' GROUP BY reloj")

                If dtperiodos_vac_sum.Rows.Count > 0 Then

                    Dim periodos_vac_fechas As DataTable = sqlExecute("select * from periodos_vac where reloj = '" & dr("reloj") & "' and fecha_fin < '" & FechaSQL(fecha_proy_vac) & "' order by orden desc")
                    Dim dias As Integer = 0
                    Dim anos As Integer = Integer.Parse(periodos_vac_fechas.Rows(0).Item("orden")) + 1
                    Dim fecha_ini As Date = Date.Parse(periodos_vac_fechas.Rows(0).Item("fecha_fin")).AddDays(1)
                    Dim fecha_fin As Date = Date.Parse(periodos_vac_fechas.Rows(0).Item("fecha_fin")).AddYears(1)
                    Dim total_periodos_vac As Double = dtperiodos_vac_sum.Rows(0).Item("total")
                    Dim vac_iniciales As Double = 0
                    Dim dtvac_ini As DataTable = sqlExecute("select * from vac_inicial where reloj = '" & dr("reloj") & "'")

                    If dtvac_ini.Rows.Count > 0 Then
                        vac_iniciales = dtvac_ini.Rows(0).Item("DIAS")
                    End If

                    Dim dtVac_ausentismo As DataTable = sqlExecute("select reloj from ausentismo where reloj = '" & dr("reloj") & "' and tipo_aus = 'VAC' and fecha between '2018-02-16' and '" & FechaSQL(fecha_proy_vac) & "'", "TA")

                    'If Date.Parse(FechaSQL(dr("alta"))) > "2018-02-16" And Date.Parse(FechaSQL(dr("alta"))) < fecha_fin Then
                    '    fecha_ini = Date.Parse(FechaSQL(dr("alta")))
                    'End If
                    Dim dias_prop As Double = Integer.Parse(DateDiff(DateInterval.Day, fecha_ini, fecha_proy_vac))
                    dias = Integer.Parse(DateDiff(DateInterval.Day, fecha_ini, fecha_fin))

                    Dim dtdias_vac_ As DataTable = sqlExecute("select * from vacaciones where anos = '" & anos & "' and cod_tipo = '" & dr("cod_tipo").ToString.Trim & "' and cod_comp= '610'")
                    Dim dias_proporcion As Double = (dias_prop * dtdias_vac_.Rows(0).Item("DIAS")) / dias

                    Dim reloj As String = dr("reloj")
                    drDatos("fecha_ini") = FechaSQL(fecha_ini).ToString
                    drDatos("fecha_fin") = FechaSQL(fecha_fin).ToString
                    drDatos("dias_proporcion") = dias_proporcion.ToString
                    drDatos("formula") = vac_iniciales.ToString & " + " & total_periodos_vac.ToString & "+" & dias_proporcion.ToString
                    drDatos("dias_vac") = vac_iniciales + total_periodos_vac + dias_proporcion
                    drDatos("dias_tomados") = dtVac_ausentismo.Rows.Count()
                    drDatos("total_dias") = (vac_iniciales + total_periodos_vac + dias_proporcion) - dtVac_ausentismo.Rows.Count()
                    dtDatos.Rows.Add(drDatos)

                Else
                    Dim dias As Integer = 0
                    Dim anos As Integer = 1
                    Dim fecha_ini As Date = Date.Parse(dr("alta_vacacion"))
                    Dim fecha_fin As Date = Date.Parse(dr("alta_vacacion")).AddYears(1).AddDays(-1)
                    Dim total_periodos_vac As Double = 0
                    Dim vac_iniciales As Double = 0
                    Dim dtvac_ini As DataTable = sqlExecute("select * from vac_inicial where reloj = '" & dr("reloj") & "'")

                    If dtvac_ini.Rows.Count > 0 Then
                        vac_iniciales = dtvac_ini.Rows(0).Item("DIAS")
                    End If



                    Dim dtVac_ausentismo As DataTable = sqlExecute("select reloj from ausentismo where reloj = '" & dr("reloj") & "' and tipo_aus = 'VAC' and fecha between '2018-02-16' and '" & FechaSQL(fecha_proy_vac) & "'", "TA")



                    Dim dias_prop As Double = Integer.Parse(DateDiff(DateInterval.Day, fecha_ini, fecha_proy_vac))
                    dias = Integer.Parse(DateDiff(DateInterval.Day, fecha_ini, fecha_fin))

                    Dim dtdias_vac_ As DataTable = sqlExecute("select * from vacaciones where anos = '" & anos & "' and cod_tipo = '" & dr("cod_tipo").ToString.Trim & "' and cod_comp= '610'")
                    Dim dias_proporcion As Double = (dias_prop * dtdias_vac_.Rows(0).Item("DIAS")) / dias

                    Dim reloj As String = dr("reloj")
                    drDatos("fecha_ini") = FechaSQL(fecha_ini).ToString
                    drDatos("fecha_fin") = FechaSQL(fecha_fin).ToString
                    drDatos("dias_proporcion") = dias_proporcion.ToString
                    drDatos("formula") = vac_iniciales.ToString & " + " & total_periodos_vac.ToString & "+" & dias_proporcion.ToString
                    drDatos("dias_vac") = vac_iniciales + total_periodos_vac + dias_proporcion
                    drDatos("dias_tomados") = dtVac_ausentismo.Rows.Count()
                    drDatos("total_dias") = (vac_iniciales + total_periodos_vac + dias_proporcion) - dtVac_ausentismo.Rows.Count()
                    dtDatos.Rows.Add(drDatos)




                End If

            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "VacPrueba", ex.HResult, ex.Message)
        End Try






        'Dim fecha_proy_vac As Date


        'frmSeleccionarFecha.ShowDialog()
        'Try
        '    fecha_proy_vac = fechaultimo

        '    dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        '    dtDatos.Columns.Add("nombre", Type.GetType("System.String"))
        '    dtDatos.Columns.Add("cod_tipo", Type.GetType("System.String"))
        '    dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        '    dtDatos.Columns.Add("alta")
        '    dtDatos.Columns.Add("alta_antiguedad")

        '    dtDatos.Columns.Add("sueldo", Type.GetType("System.String"))
        '    dtDatos.Columns.Add("fecha_fin", Type.GetType("System.String"))

        '    dtDatos.Columns.Add("antiguedad_anos", Type.GetType("System.Int32"))
        '    dtDatos.Columns.Add("saldo_ultimo_periodo", Type.GetType("System.Double"))
        '    dtDatos.Columns.Add("dias_vac", Type.GetType("System.Double"))
        '    dtDatos.Columns.Add("dias_tomados", Type.GetType("System.Double"))
        '    dtDatos.Columns.Add("total_dias", Type.GetType("System.Double"))

        '    Dim drDatos As DataRow

        '    For Each dr As DataRow In dtInformacion.Select("COD_COMP = '610' and baja is NULL")
        '        drDatos = dtDatos.NewRow
        '        Dim f_inicio As Date = Nothing
        '        Dim f_fin As Date = Nothing
        '        Dim f_antiguedad As Date = Nothing
        '        Dim saldo_ant As Double = 0
        '        Dim ganados As Double = 0
        '        Dim pagados As Integer = 0
        '        Dim saldo_nuevo As Double = 0
        '        Dim comentario As String = ""
        '        Dim anos As Integer = 0
        '        Dim dtvac As New DataTable
        '        Dim dtvac_aus As New DataTable

        '        drDatos("reloj") = dr("reloj")
        '        drDatos("nombre") = dr("nombres")
        '        drDatos("cod_tipo") = dr("cod_tipo")
        '        drDatos("cod_depto") = dr("cod_depto")
        '        drDatos("alta") = dr("alta")
        '        drDatos("alta_antiguedad") = dr("alta_vacacion")

        '        If IsDBNull(dr("alta_vacacion")) Then
        '            Continue For
        '        End If

        '        drDatos("sueldo") = dr("sactual")



        '        '******Revisar si ya hay un periodo anterior
        '        Dim dtsaldos As DataTable = sqlExecute("select top(1)* from saldo_vac_nueva where reloj = '" & dr("reloj") & "' order by fin desc")

        '        If dtsaldos.Rows.Count > 0 Then

        '            '******Obtener fechas y anos
        '            f_inicio = Date.Parse(dtsaldos.Rows(0).Item("fin")).AddDays(1)
        '            f_fin = fecha_proy_vac
        '            f_antiguedad = dr("alta_vacacion")
        '            anos = f_fin.Year - f_antiguedad.Year

        '            '******Obtener cuantos dias le corresponden segun los anos y el tipo de empleado
        '            dtvac = sqlExecute("select * from vacaciones where anos = '" & anos & "' and cod_tipo = '" & dr("cod_tipo").ToString.Trim & "' and cod_comp = '610'")

        '            '*******Calcular los dias ganados en el periodo
        '            If dtvac.Rows.Count > 0 Then
        '                ganados = (Double.Parse(dtvac.Rows(0).Item("DIAS")) / 365) * (f_fin.Subtract(f_inicio).Days + 1)
        '            End If

        '            '******Obtener vac tomadas en el periodo
        '            dtvac_aus = sqlExecute("select * from ausentismo where reloj = '" & dr("reloj") & "' and tipo_aus = 'VAC' and fecha between '" & FechaSQL(f_inicio) & "' and '" & FechaSQL(f_fin) & "'", "TA")
        '            pagados = dtvac_aus.Rows.Count

        '            '******Calcular el saldo_nuevo
        '            saldo_nuevo = (ganados + dtsaldos.Rows(0).Item("saldo")) - pagados

        '            drDatos("fecha_fin") = FechaCortaLetra(f_fin)

        '            drDatos("antiguedad_anos") = anos
        '            drDatos("saldo_ultimo_periodo") = dtsaldos.Rows(0).Item("saldo")
        '            drDatos("dias_vac") = ganados
        '            drDatos("dias_tomados") = pagados
        '            drDatos("total_dias") = saldo_nuevo
        '            dtDatos.Rows.Add(drDatos)
        '        Else

        '            '******Obtener fechas y anos
        '            f_inicio = Date.Parse(dr("alta"))
        '            f_fin = fecha_proy_vac
        '            f_antiguedad = dr("alta_vacacion")
        '            anos = YearsBetweenDates(f_inicio, fecha_proy_vac) + 1

        '            '******Obtener cuantos dias le corresponden segun los anos y el tipo de empleado
        '            dtvac = sqlExecute("select * from vacaciones where anos = '" & anos & "' and cod_tipo = '" & dr("cod_tipo").ToString.Trim & "' and cod_comp = '610'")

        '            '*******Calcular los dias ganados en el periodo
        '            If dtvac.Rows.Count > 0 Then
        '                ganados = (Double.Parse(dtvac.Rows(0).Item("DIAS")) / 365) * (f_fin.Subtract(f_inicio).Days + 1)
        '            End If

        '            '******Obtener vac tomadas en el periodo
        '            dtvac_aus = sqlExecute("select * from ausentismo where reloj = '" & dr("reloj") & "' and tipo_aus = 'VAC' and fecha between '" & FechaSQL(f_inicio) & "' and '" & FechaSQL(f_fin) & "'", "TA")
        '            pagados = dtvac_aus.Rows.Count

        '            '******Calcular el saldo_nuevo
        '            saldo_nuevo = ganados - pagados

        '            drDatos("fecha_fin") = FechaCortaLetra(f_fin)

        '            drDatos("antiguedad_anos") = anos
        '            drDatos("saldo_ultimo_periodo") = 0
        '            drDatos("dias_vac") = ganados
        '            drDatos("dias_tomados") = pagados
        '            drDatos("total_dias") = saldo_nuevo
        '            dtDatos.Rows.Add(drDatos)
        '        End If





        '    Next


        'Catch ex As Exception

        'End Try
    End Sub
    Public Function YearsBetweenDates(ByVal StartDate As DateTime, _
       ByVal EndDate As DateTime) As Integer
        ' Returns the number of years between the passed dates
        If Month(EndDate) < Month(StartDate) Or (Month(EndDate) = Month(StartDate) And (EndDate.Day) < (StartDate.Day)) Then
            Return Year(EndDate) - Year(StartDate) - 1
        Else
            Return Year(EndDate) - Year(StartDate)
        End If
    End Function
    Public Sub rep_vac(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, ByRef dtinfo As DataTable)
        Dim x As Integer = 1
        Dim y As Integer = 1
        Try
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

            hoja_excel.Cells(x, y).Value = "reloj"
            hoja_excel.Cells(x, y).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 1).Value = "cod_tipo"
            hoja_excel.Cells(x, y + 1).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 2).Value = "cod_depto"
            hoja_excel.Cells(x, y + 2).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 3).Value = "alta"
            hoja_excel.Cells(x, y + 3).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 4).Value = "alta_antiguedad"
            hoja_excel.Cells(x, y + 4).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 5).Value = "baja"
            hoja_excel.Cells(x, y + 5).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 6).Value = "sueldo"
            hoja_excel.Cells(x, y + 6).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 7).Value = "periodo_fecha_inicio"
            hoja_excel.Cells(x, y + 7).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 8).Value = "periodo_fecha_fin"
            hoja_excel.Cells(x, y + 8).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 9).Value = "antiguedad_anos"
            hoja_excel.Cells(x, y + 9).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 10).Value = "dias_periodo"
            hoja_excel.Cells(x, y + 10).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 11).Value = "dias_corresponden"
            hoja_excel.Cells(x, y + 11).Style.Font.Bold = True
            hoja_excel.Cells(x, y + 12).Value = "dias_proporcion"
            hoja_excel.Cells(x, y + 12).Style.Font.Bold = True


            x = x + 1
            For Each dr As DataRow In dtinfo.Rows
                hoja_excel.Cells(x, y).Value = dr("reloj")
                hoja_excel.Cells(x, y + 1).Value = IIf(IsDBNull(dr("cod_tipo")), "", dr("cod_tipo"))
                hoja_excel.Cells(x, y + 2).Value = IIf(IsDBNull(dr("cod_depto")), "", dr("cod_depto"))
                If Not IsDBNull(dr("alta")) Then
                    'formatRange.NumberFormat = "mm/dd/yyyy hh:mm:ss";
                    hoja_excel.Cells(x, y + 3).Value = Date.Parse(dr("alta"))
                Else
                    hoja_excel.Cells(x, y + 3).Value = ""
                End If
                If Not IsDBNull(dr("alta_antiguedad")) Then
                    hoja_excel.Cells(x, y + 4).Value = Date.Parse(dr("alta_antiguedad"))
                Else
                    hoja_excel.Cells(x, y + 4).Value = ""
                End If
                If Not IsDBNull(dr("baja")) Then
                    hoja_excel.Cells(x, y + 5).Value = Date.Parse(dr("baja"))
                Else
                    hoja_excel.Cells(x, y + 5).Value = ""
                End If
                hoja_excel.Cells(x, y + 6).Value = IIf(IsDBNull(dr("sueldo")), "", dr("sueldo"))
                hoja_excel.Cells(x, y + 7).Value = Date.Parse(dr("fecha_inicio"))
                hoja_excel.Cells(x, y + 8).Value = Date.Parse(dr("fecha_fin"))
                hoja_excel.Cells(x, y + 9).Value = IIf(IsDBNull(dr("antiguedad_anos")), "", dr("antiguedad_anos"))
                hoja_excel.Cells(x, y + 10).Value = IIf(IsDBNull(dr("dias_periodo")), "", dr("dias_periodo"))
                hoja_excel.Cells(x, y + 11).Value = IIf(IsDBNull(dr("dias_vac")), "", dr("dias_vac"))
                hoja_excel.Cells(x, y + 12).Value = IIf(IsDBNull(dr("total_dias")), "", dr("total_dias"))

                x = x + 1
            Next
            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()
        Catch ex As Exception

        End Try
    End Sub

    Public Function ReporteTurnover(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim file_name As String = ""
        Try


            dtDatos.Columns.Add("reloj", GetType(System.String))
            dtDatos.Columns.Add("id_sf", GetType(System.String))
            dtDatos.Columns.Add("nombres", GetType(System.String))
            dtDatos.Columns.Add("alta", GetType(System.String))
            dtDatos.Columns.Add("baja", GetType(System.String))
            dtDatos.Columns.Add("mot_baj", GetType(System.String))
            dtDatos.Columns.Add("sub_baj")
            dtDatos.Columns.Add("antiguedad")
            dtDatos.Columns.Add("fecha_nac", GetType(System.String))
            dtDatos.Columns.Add("comp", GetType(System.String))
            dtDatos.Columns.Add("nombre_super", GetType(System.String))
            dtDatos.Columns.Add("cod_depto", GetType(System.String))
            dtDatos.Columns.Add("nombre_depto")
            dtDatos.Columns.Add("centro_costos", GetType(System.String))
            dtDatos.Columns.Add("nombre_area", GetType(System.String))
            dtDatos.Columns.Add("cod_hora")
            dtDatos.Columns.Add("cod_tipo", GetType(System.String))
            dtDatos.Columns.Add("cod_clase", GetType(System.String))
            dtDatos.Columns.Add("sexo", GetType(System.String))
            dtDatos.Columns.Add("ruta", GetType(System.String))

            frmRangoFechas.ShowDialog()



            Dim sfd As New SaveFileDialog
            Dim fecha_ini As String = FechaInicial
            Dim fecha_fin As String = FechaFinal


            ' Dim dtinformacion As DataTable = sqlExecute("select * from personalvw where baja is not null and baja between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "'")
            For Each row As DataRow In dtInformacion.Select("baja >= '" & FechaSQL(fecha_ini) & "' and baja <= '" & FechaSQL(fecha_fin) & "'")
                Dim drow As DataRow = dtDatos.NewRow
                'frmTrabajando.lblAvance.Text = row("reloj").ToString.Trim ' Si no incluyeramos fecha, solo el no
                'Application.DoEvents()

                '--Definicion de variables que se inicializan
                Dim NoReloj As String = row("reloj").ToString.Trim
                Dim ALTA As String = ""
                ALTA = row("ALTA").ToString.Trim
                Dim alta_vacacion As String = ""
                alta_vacacion = row("alta_vacacion").ToString.Trim
                Dim BAJA As String = ""
                BAJA = row("BAJA").ToString.Trim
                Dim FHA_NAC As String = ""
                FHA_NAC = row("FHA_NAC").ToString.Trim
                If FHA_NAC <> "" Then
                    FHA_NAC = FechaSQL(FHA_NAC)
                End If
                Dim edad As String = ""

                '--Ends

                drow("reloj") = NoReloj
                drow("id_sf") = row("reloj_alt")
                drow("nombres") = row("nombres").ToString.Trim
                drow("alta") = FechaSQL(ALTA)
                drow("baja") = FechaSQL(BAJA)
                drow("mot_baj") = row("motivo_baja")
                drow("sub_baj") = row("submotivo_baja")

                drow("antiguedad") = AntiguedadExacta(ALTA, Date.Today)
                drow("fecha_nac") = FHA_NAC
                drow("comp") = row("compania")
                drow("nombre_super") = row("nombre_super")
                drow("cod_depto") = row("cod_depto")
                drow("nombre_depto") = row("nombre_depto").ToString.Trim
                drow("centro_costos") = row("centro_costos").ToString.Trim
                drow("nombre_area") = row("nombre_area")
                drow("cod_hora") = row("cod_hora")
                drow("cod_tipo") = row("cod_tipo")
                drow("cod_clase") = row("cod_clase")
                drow("sexo") = row("sexo")

                Dim dtrutas As DataTable = sqlExecute("select * from detalle_auxiliares where campo = 'RUTA' and reloj = '" & NoReloj & "'")
                If dtrutas.Rows.Count > 0 Then
                    drow("ruta") = dtrutas.Rows(0).Item("contenido")
                Else
                    drow("ruta") = "N/A"
                End If

                dtDatos.Rows.Add(drow)
            Next

            sfd.DefaultExt = ".xlsx"
            sfd.FileName = "HC Turnover " & FechaSQL(fecha_ini) & " - " & FechaSQL(fecha_fin) & ".xlsx"

            sfd.OverwritePrompt = True
            If sfd.ShowDialog() = DialogResult.OK Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                '

                frmTrabajando.Show()

                contenidoTurnover("Headcount Turnover", "", wb, dtDatos)
                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))

                ActivoTrabajando = False
                frmTrabajando.Close()



            End If
            MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'file_name = "\\mxqtvas24\pida\reportes\Reporte Turnover\" & "HC Turnover - " & FechaSQL(fecha_ini) & " a " & FechaSQL(fecha_fin) & ".xlsx"

        Catch ex As Exception
            'ActivoTrabajando = False ' Desactivamos el LOADING
            'frmTrabajando.Close()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
        Return file_name
    End Function
    Public Sub contenidoTurnover(nombre_hoja As String, filtro As String, ByRef wb As ExcelWorkbook, ByRef dtinfo As DataTable)
        ' Reporte a detalle Excel
        Dim x As Integer = 1
        Dim y As Integer = 1
        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(nombre_hoja)

        hoja_excel.Cells(y, x).Value = "Reloj"
        hoja_excel.Cells(y, x).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 1).Value = "SF ID"
        hoja_excel.Cells(y, x + 1).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 2).Value = "Nombre"
        hoja_excel.Cells(y, x + 2).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 3).Value = "Alta"
        hoja_excel.Cells(y, x + 3).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 4).Value = "Baja"
        hoja_excel.Cells(y, x + 4).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 5).Value = "Motivo baja"
        hoja_excel.Cells(y, x + 5).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 6).Value = "Submotivo baja"
        hoja_excel.Cells(y, x + 6).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 7).Value = "Antiguedad"
        hoja_excel.Cells(y, x + 7).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 8).Value = "Fecha de nacimiento"
        hoja_excel.Cells(y, x + 8).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 9).Value = "Compañia"
        hoja_excel.Cells(y, x + 9).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 10).Value = "Supervisor"
        hoja_excel.Cells(y, x + 10).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 11).Value = "Cod Departamento"
        hoja_excel.Cells(y, x + 11).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 12).Value = "Departamento"
        hoja_excel.Cells(y, x + 12).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 13).Value = "Centro costos"
        hoja_excel.Cells(y, x + 13).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 14).Value = "Area"
        hoja_excel.Cells(y, x + 14).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 15).Value = "Horario"
        hoja_excel.Cells(y, x + 15).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 16).Value = "Tipo"
        hoja_excel.Cells(y, x + 16).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 17).Value = "Clase"
        hoja_excel.Cells(y, x + 17).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 18).Value = "Sexo"
        hoja_excel.Cells(y, x + 18).Style.Font.Bold = True
        hoja_excel.Cells(y, x + 19).Value = "Ruta"
        hoja_excel.Cells(y, x + 19).Style.Font.Bold = True


        y = 2
        For Each dr As DataRow In dtinfo.Rows
            hoja_excel.Cells(y, x).Value = dr("reloj").ToString
            hoja_excel.Cells(y, x + 1).Value = dr("id_sf").ToString
            hoja_excel.Cells(y, x + 2).Value = dr("nombres").ToString
            hoja_excel.Cells(y, x + 3).Value = dr("alta").ToString
            hoja_excel.Cells(y, x + 4).Value = dr("baja").ToString
            hoja_excel.Cells(y, x + 5).Value = dr("mot_baj").ToString
            hoja_excel.Cells(y, x + 6).Value = dr("sub_baj").ToString
            hoja_excel.Cells(y, x + 7).Value = dr("antiguedad").ToString
            hoja_excel.Cells(y, x + 8).Value = dr("fecha_nac").ToString
            hoja_excel.Cells(y, x + 9).Value = dr("comp").ToString
            hoja_excel.Cells(y, x + 10).Value = dr("nombre_super").ToString
            hoja_excel.Cells(y, x + 11).Value = dr("cod_depto").ToString
            hoja_excel.Cells(y, x + 12).Value = dr("nombre_depto").ToString
            hoja_excel.Cells(y, x + 13).Value = dr("centro_costos").ToString
            hoja_excel.Cells(y, x + 14).Value = dr("nombre_area").ToString
            hoja_excel.Cells(y, x + 15).Value = dr("cod_hora").ToString
            hoja_excel.Cells(y, x + 16).Value = dr("cod_tipo").ToString
            hoja_excel.Cells(y, x + 17).Value = dr("cod_clase").ToString
            hoja_excel.Cells(y, x + 18).Value = dr("sexo").ToString
            hoja_excel.Cells(y, x + 19).Value = dr("ruta").ToString

            y = y + 1
        Next

        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

    End Sub

    '*************Llenado para cartas y contratos determinados e indeterminados
    Public Sub LlenarWORDWME(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, SRep As String)
        Dim wapp As New Word.Application
        Dim wdoc As Word.Document = Nothing

        Try

            Dim SF As New SaveFileDialog
            Dim Reporte As String = SRep
            SF.FileName = Reporte & "-"
            SF.Filter = "Word file (*.docx)|*.docx"
            SF.FilterIndex = 1

            Dim FD As New FolderBrowserDialog
            FD.RootFolder = Environment.SpecialFolder.MyComputer
            Dim resultado As Integer = SF.ShowDialog()
            ' Dim resultado As Integer = FD.ShowDialog() 'CAMBIO A SAVE FILE DIALOG

            '-----------------------------ESTE IF SE AGREGO PARA RECICLAR ESTA FUNCION, PERO ESTA COMPARATIVA ES PROPIA DE LA SECCION DE NOMINA
            If SRep = "Solicitud de Retiro" Then
                Dim Source As String = DireccionReportes + Reporte + ".docx" ' Aqui busca el archivo en Word
                Dim Destination As String = ""

                Destination = SF.FileName.Replace(".docx", ".docx") ' Es en donde será guardado
                System.IO.File.Copy(Source, Destination, True)
                wapp = New Word.Application
                wdoc = wapp.Documents.Open(Destination)
                Dim FM As New frmFechaYMonto
                FM.ShowDialog()
                Dim Fcha As String = ""
                Fcha = FechaSQL(FechaRetiro)
                Dim NumMesRetiro As String = Fcha.Trim.Substring(5, 2)
                Dim MesLetraRetiro As String = MesLetra(NumMesRetiro)
                Dim MesR As String = Fcha.Trim.Substring(5, 2)
                ReemplazarEnWord("[diaP]", Fcha.Trim.Substring(8, 2), wapp)
                ReemplazarEnWord("[mesP]", MesLetraRetiro, wapp)
                ReemplazarEnWord("[anioP]", CDate(FechaRetiro).ToString("yyyy"), wapp)
                ReemplazarEnWord("[Cantidad_Letra]", ConvNvo(MontoRetiro), wapp)
                ReemplazarEnWord("[Cantidad]", Format(CDec(MontoRetiro), "n"), wapp)
                Dim FHoy As String = ""
                Try : FHoy = FechaSQL(Date.Now) : Catch ex As Exception : FHoy = "" : End Try
                Dim NumMes As String = FHoy.Trim.Substring(5, 2)
                Dim MonthName As String = MesLetra(NumMes)
                Dim YearName As String = AnioLetra(FHoy.Trim.Substring(2, 2)) '--- Agregado por Antonio
                ReemplazarEnWord("[dia]", FHoy.Trim.Substring(8, 2), wapp)
                ReemplazarEnWord("[mes]", MonthName, wapp)
                ReemplazarEnWord("[anio]", Date.Now.Year, wapp) '-----Se hizo cambio por Antonio
                ReemplazarEnWord("[anio_letra]", YearName, wapp) '----Agregado por antonio
                Dim Contador As Integer = 1
                dtDatos = dtInformacion.Copy
                For i As Integer = 0 To 500 - 1
                    If Contador <= dtDatos.Rows.Count Then
                        ReemplazarEnWord("[NOM" + CStr(Contador) + "]", dtDatos.Rows(i).Item("NOMBRES").ToString.Trim, wapp)
                        ReemplazarEnWord("[NOCUEN" + CStr(Contador) + "]", dtDatos.Rows(i).Item("CLABE").ToString.Trim, wapp)
                        ReemplazarEnWord("[MONTO" + CStr(Contador) + "]", Format(CDec(Val(dtDatos.Rows(i).Item("MONTO").ToString.Trim)), "n"), wapp)
                    Else
                        ReemplazarEnWord("[NOM" + CStr(Contador) + "]", "", wapp)
                        ReemplazarEnWord("[NOCUEN" + CStr(Contador) + "]", "", wapp)
                        ReemplazarEnWord("[MONTO" + CStr(Contador) + "]", "", wapp)
                    End If

                    Contador += 1
                Next
                wdoc.Save()
                wdoc.Close()
                wapp.Quit()
                releaseObject(wdoc)
                releaseObject(wapp)
                MessageBox.Show("Archivo generado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            '-----------------------------TERMINO DEL IF DE NOMINA

            If resultado = DialogResult.OK Then
                dtDatos = dtInformacion.Copy
                dtInformacion.Columns.Add("expr1", Type.GetType("System.String"))
                dtInformacion.Columns.Add("expr2", Type.GetType("System.String"))
                dtInformacion.Columns.Add("expr3", Type.GetType("System.String"))
                dtInformacion.Columns.Add("Nombre_Sexo", Type.GetType("System.String"))
                dtInformacion.Columns.Add("Colonia", Type.GetType("System.String"))
                dtInformacion.Columns.Add("SActual_Letra", Type.GetType("System.String"))

                For Each row As DataRow In dtInformacion.Rows
                    row("expr1") = Now.Day
                    row("expr2") = MesLetra(Now.Month)
                    row("expr3") = Now.Year
                    If row("sexo") = "F" Then row("Nombre_Sexo") = "Femenino" Else row("Nombre_Sexo") = "Masculino"
                    row("Colonia") = row("nombre_colonia")
                    row("SActual_Letra") = ConvNvo(row("sactual"))
                Next

                Dim dtCia As DataTable = sqlExecute("select * from cias where cia_default = '1'")
                For Each row As DataRow In dtInformacion.Rows
                    Dim Source As String = DireccionReportes + Reporte + ".docx" ' Aqui busca el archivo en Word
                    Dim Destination As String = ""

                    Destination = SF.FileName.Replace(".docx", row.Item("RELOJ") + ".docx") ' Es en donde será guardado

                    System.IO.File.Copy(Source, Destination, True)
                    wapp = New Word.Application
                    wdoc = wapp.Documents.Open(Destination)
                    If dtCia.Rows.Count > 0 Then
                        ReemplazarEnWord("[representante_legal]", dtCia.Rows(0).Item("rep_legal").ToString.Trim, wapp) ' Empieza a reemplazar lo que queremos que remplace
                    End If

                    '-----Reemplazar en word todo el contenido que enciere en corchetes "[Ejemplo]"
                    Try
                        LlenarCamposWord(row, wapp)
                    Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "EditarWord", ex.HResult, ex.Message)
                    End Try

                    'Dim dtFamiliares As DataTable = sqlExecute("select familiares.reloj,familiares.COD_FAMILIA,rtrim(ltrim(familiares.nombre)) +' '+ isnull(familiares.apaterno,'') +' '+isnull(familiares.amaterno,'') as familiar,familiares.fecha_nac,familia.NOMBRE  as Parentesco,familia.sexo from familiares left join familia on familiares.COD_FAMILIA = familia.COD_FAMILIA where familiares.reloj = '" + row("reloj").ToString.Trim + "' ")
                    'For x As Integer = 1 To 10
                    '    Try
                    '        ReemplazarEnWord("[nombre_dep" + x.ToString + "]", dtFamiliares.Rows(x - 1).Item("familiar"), wapp)
                    '        ReemplazarEnWord("[parent_dep" + x.ToString + "]", dtFamiliares.Rows(x - 1).Item("parentesco"), wapp)
                    '        ReemplazarEnWord("[fha_nac_dep" + x.ToString + "]", IIf(IsDBNull(dtFamiliares.Rows(x - 1).Item("fecha_nac")), "", dtFamiliares.Rows(x).Item("fecha_nac").Day.ToString.PadLeft(2, "0") & "/" & dtFamiliares.Rows(x).Item("fecha_nac").Month.ToString.PadLeft(2, "0") & "/" & dtFamiliares.Rows(x).Item("fecha_nac").Year.ToString), wapp)
                    '        ReemplazarEnWord("[sexo_dep" + x.ToString + "]", IIf(dtFamiliares.Rows(x - 1).Item("sexo") = "F", "Femenino", "Masculino"), wapp)

                    '    Catch ex As Exception
                    '        ReemplazarEnWord("[nombre_dep" + x.ToString + "]", "", wapp)
                    '        ReemplazarEnWord("[fha_nac_dep" + x.ToString + "]", "", wapp)
                    '        ReemplazarEnWord("[parent_dep" + x.ToString + "]", "", wapp)
                    '        ReemplazarEnWord("[sexo_dep" + x.ToString + "]", "", wapp)
                    '    End Try
                    'Next

                    '------Obtener Fecha actual (Los Ultimos 2 Dígitos de dia, mes y año):
                    Dim FHoy As String = ""
                    Try : FHoy = FechaSQL(Date.Now) : Catch ex As Exception : FHoy = "" : End Try
                    If (FHoy.Trim = "") Then GoTo Continuar
                    Dim NumMes As String = FHoy.Trim.Substring(5, 2)
                    Dim MonthName As String = MesLetra(NumMes)
                    Dim YearName As String = AnioLetra(FHoy.Trim.Substring(2, 2)) '--- Agregado por Antonio
                    ReemplazarEnWord("[dia]", FHoy.Trim.Substring(8, 2), wapp)
                    ReemplazarEnWord("[mes]", MonthName, wapp)
                    ReemplazarEnWord("[anio]", Date.Now.Year, wapp) '-----Se hizo cambio por Antonio
                    ReemplazarEnWord("[anio_letra]", YearName, wapp) '----Agregado por antonio
Continuar:

                    wdoc.Save()
                    wdoc.Close()
                    wapp.Quit()
                    releaseObject(wdoc)
                    releaseObject(wapp)
                Next
                MessageBox.Show("Archivo generado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ' Process.Start("EXPLORER.EXE", Chr(34) + FD.SelectedPath + Chr(34))
        Catch ex As Exception
            MessageBox.Show("Error al generar el reporte, recuerda cerrar todas las ventanas de Word que tenga este reporte abierto", "Error al generar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "EditarWord", ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub ReemplazarEnWord(Original As String, Nuevo As String, wapp As Word.Application)
        With wapp.Selection.Find
            .ClearFormatting()
            .Text = Original
            .Replacement.ClearFormatting()
            .Replacement.Text = Nuevo
            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
        End With
    End Sub

    '-- AOS:: Funcion que reemplaza directamente en word los campos
    Private Sub LlenarCamposWord(row As DataRow, wapp As Word.Application)
        On Error Resume Next
        Dim Nombre As String = "", reloj As String = ""
        reloj = row("RELOJ").ToString.Trim
        Nombre = row("nombre").ToString.Trim & " " & row("APATERNO").ToString.Trim & " " & row("AMATERNO").ToString.Trim
        ReemplazarEnWord("[RELOJ]", reloj, wapp)
        ReemplazarEnWord("[NOMBRE_COMPLETO]", Nombre, wapp)
        ReemplazarEnWord("[EDAD]", GetEdad(row("fha_nac")), wapp)
        Dim Sexo As String = IIf(IsDBNull(row("SEXO")), "", row("SEXO").ToString.Trim)
        Dim Nombre_Sexo As String = ""
        If Sexo = "M" Then Nombre_Sexo = "Masculino" Else Nombre_Sexo = "Femenino"
        ReemplazarEnWord("[SEXO]", Nombre_Sexo, wapp)

        Dim COD_CIVIL As String = IIf(IsDBNull(row("COD_CIVIL")), "", row("COD_CIVIL").ToString.Trim)
        Dim EDO_CIVIL As String = ""
        Select Case Sexo
            Case "M"
                If COD_CIVIL = "C" Then
                    EDO_CIVIL = "Casado"
                ElseIf COD_CIVIL = "S" Then
                    EDO_CIVIL = "Soltero"
                ElseIf COD_CIVIL = "D" Then
                    EDO_CIVIL = "Divorciado"
                ElseIf COD_CIVIL = "V" Then
                    EDO_CIVIL = "Viudo"
                ElseIf COD_CIVIL = "X" Then
                    EDO_CIVIL = "Separado"
                ElseIf COD_CIVIL = "U" Then
                    EDO_CIVIL = "Unión libre"
                End If
                ReemplazarEnWord("[PREF]", "el", wapp) '---------Agregado por Antonio
            Case "F"
                If COD_CIVIL = "C" Then
                    EDO_CIVIL = "Casada"
                ElseIf COD_CIVIL = "S" Then
                    EDO_CIVIL = "Soltera"
                ElseIf COD_CIVIL = "D" Then
                    EDO_CIVIL = "Divorciada"
                ElseIf COD_CIVIL = "V" Then
                    EDO_CIVIL = "Viuda"
                ElseIf COD_CIVIL = "X" Then
                    EDO_CIVIL = "Separada"
                ElseIf COD_CIVIL = "U" Then
                    EDO_CIVIL = "Unión libre"
                End If
                ReemplazarEnWord("[PREF]", "la", wapp) '---------Agregado por Antonio
            Case Else
                EDO_CIVIL = ""

        End Select
        ReemplazarEnWord("[EDO_CIVIL]", EDO_CIVIL, wapp)

        ReemplazarEnWord("[CURP]", row("CURP"), wapp)
        ReemplazarEnWord("[RFC]", row("RFC"), wapp)
        ReemplazarEnWord("[IMSS]", row("IMSS"), wapp)
        ReemplazarEnWord("[DIREC_EMPL]", IIf(IsDBNull(row("DIRECCION_EMPL")), "", row("DIRECCION_EMPL").ToString.Trim), wapp)

        ' Dias vac del 1er anio de acuerdo al tipo de empl 
        Dim COD_COMP As String = IIf(IsDBNull(row("COD_COMP")), "", row("COD_COMP").ToString.Trim)
        Dim COD_TIPO As String = IIf(IsDBNull(row("COD_TIPO")), "", row("COD_TIPO").ToString.Trim)
        ReemplazarEnWord("[DIAS_VAC]", GetDiasVac(COD_COMP, COD_TIPO), wapp)

        '--- Nombre del Puesto
        ReemplazarEnWord("[NOMBRE_PUESTO]", row("nombre_puesto").ToString.Trim, wapp)

        '-- Nombre de la Planta
        ReemplazarEnWord("[NOMBRE_PLANTA]", row("nombre_planta").ToString.Trim, wapp)

        '--Sueldo Mensual normal y en Letra
        ReemplazarEnWord("[SMENSUAL]", Format(row("salario_mensual"), "c"), wapp)
        ReemplazarEnWord("[SALARIO_MENSUAL_LETRA]", ConvNvo(row("salario_mensual")), wapp)

        '-- Sueldo Mensual normal y en Letra para WME (SACTUAL * 31.78)
        Dim SACTUAL As Double = 0.0
        Dim SMENSUAL As Double = 0.0
        SACTUAL = Double.Parse(row("SACTUAL"))
        SMENSUAL = SACTUAL * 31.78
        ReemplazarEnWord("[SALMENS]", Format(SMENSUAL, "c"), wapp)
        ReemplazarEnWord("[SALMENSLETRA]", ConvNvo(SMENSUAL), wapp)

        ReemplazarEnWord("[ALTA]", FechaLetra(row("alta")), wapp)
        ReemplazarEnWord("[BAJA]", FechaLetra(row("baja")), wapp)
        ReemplazarEnWord("[FECHA_HOY]", FechaLetra(Date.Now), wapp)

        '-----------Ernesto -   22/dic/20
        ReemplazarEnWord("[F_ACTUAL]", FechaMediaLetra(FechaSQL(Date.Now)), wapp)
        ReemplazarEnWord("[DEPTO]", row("nombre_depto").ToString.Trim, wapp)
        ReemplazarEnWord("[F_ALTA]", FechaMediaLetra(row("alta").ToString.Trim), wapp)
        ReemplazarEnWord("[F_BAJA]", FechaMediaLetra(row("baja").ToString.Trim), wapp)
        ReemplazarEnWord("[ANTIG]", row("antiguedad").ToString.Trim, wapp)
        ReemplazarEnWord("[S_VAC]", GetSaldoVac(row("reloj")), wapp)
        '------------

        '-------------------------Agregado por Antonio-----------------------------------
        Dim Concatena As Integer = 1
        Dim dtBeneficiarios As New DataTable
        Dim Beneficiario As String
        Dim Parentesco As String
        Dim Porcentaje As String
        dtBeneficiarios = sqlExecute("SELECT nombre_beneficiario, (SELECT NOMBRE FROM familia WHERE familia.COD_FAMILIA = beneficiarios.cod_familia) as CodFamiliar, porcentaje FROM beneficiarios WHERE reloj = '" & row("reloj") & "'") 'Consulta a todos los beneficiarios que tiene este No de Reloj
        'Se puso 7 en el for por la cantidad de renglones que se tiene en el Word en la tabla
        For j As Integer = 0 To 7 - 1
            If dtBeneficiarios.Rows.Count > j Then
                Beneficiario = "[NOMBRE_BEN" & Concatena & "]"
                ReemplazarEnWord(Beneficiario, dtBeneficiarios.Rows(j)("nombre_beneficiario").ToString.Trim, wapp)
                Parentesco = "[PARENTESCO" & Concatena & "]"
                ReemplazarEnWord(Parentesco, dtBeneficiarios.Rows(j)("CodFamiliar").ToString.Trim, wapp)
                Porcentaje = "[PORCEN" & Concatena & "]"
                ReemplazarEnWord(Porcentaje, dtBeneficiarios.Rows(j)("porcentaje").ToString.Trim, wapp)
                'aqui va un for  
                Concatena += 1
            Else
                Beneficiario = "[NOMBRE_BEN" & Concatena & "]"
                ReemplazarEnWord(Beneficiario, "", wapp)
                Parentesco = "[PARENTESCO" & Concatena & "]"
                ReemplazarEnWord(Parentesco, "", wapp)
                Porcentaje = "[PORCEN" & Concatena & "]"
                ReemplazarEnWord(Porcentaje, "", wapp)
                'aqui va un for  
                Concatena += 1
            End If
        Next
        '-----------------Fin de lo de Antonio-------------------------------

        '--Obt el Dia, mes y año 90 días después de su fecha de alta, ejemplo: "19-12-2019"
        ReemplazarEnWord("[DMA_90D]", GetFec90Dias(FechaSQL(row("alta"))), wapp)
        ReemplazarEnWord("[DESCRIP_PUESTO]", IIf(IsDBNull(row("DESCRIP_PUESTO")), "", row("DESCRIP_PUESTO").ToString.Trim), wapp) ' Responsabilidades del puesto


    End Sub

    '---Obtener saldo de vacaciones - Ernesto - 22/dic/20
    Private Function GetSaldoVac(ByVal reloj As String) As String

        Dim dtVac As New DataTable : Dim sVac As String
        Try
            dtVac = sqlExecute("select top 1 SALDO_DINERO from saldos_vacaciones where reloj ='" & reloj & "' order by FECHA_FIN desc")
            sVac = IIf(IsDBNull(dtVac.Rows(0)("SALDO_DINERO")), "", dtVac.Rows(0)("SALDO_DINERO").ToString)
        Catch ex As Exception
            sVac = ""
        End Try

        Return sVac
    End Function

    Private Function GetEdad(ByRef FecNac As String) As String
        Dim Edad As String = "0"
        Try
            Try : FecNac = FechaSQL(FecNac) : Catch ex As Exception : FecNac = "" : End Try
            If FecNac = "" Then Return Edad
            Dim Dias As Double = 0.0
            Dim Anios As Integer = 0
            Dias = Math.Round(Antiguedad_Dias(Convert.ToDateTime(FecNac), Date.Now()), 2)
            Anios = Int((Dias / 365))
            Edad = Anios.ToString
            Return Edad
        Catch ex As Exception
            Return Edad
        End Try
    End Function

    Private Function GetDiasVac(ByRef _codComp As String, _codTipo As String) As String
        Dim diasVac As String = "0"
        Dim dtDiasVac As New DataTable
        Try
            If (_codComp <> "" And _codTipo <> "") Then
                dtDiasVac = sqlExecute("select TOP 1 dias AS 'Dias_Vac' from vacaciones where COD_COMP='" & _codComp & "' AND COD_TIPO='" & _codTipo & "' AND ANOS='1'", "PERSONAL")
                If (Not dtDiasVac.Columns.Contains("Error") And dtDiasVac.Rows.Count > 0) Then
                    diasVac = IIf(IsDBNull(dtDiasVac.Rows(0).Item("Dias_Vac")), "0", dtDiasVac.Rows(0).Item("Dias_Vac").ToString.Trim)
                End If

                Return diasVac
            Else
                Return diasVac
            End If
        Catch ex As Exception
            Return diasVac
        End Try
    End Function

    Private Function GetFec90Dias(ByRef FAlta As String) As String
        '- Obtener 90 dias despues de su alta
        Dim Fec90Dias As String = ""
        Try
            If (FAlta.ToString.Trim = "") Then Return Fec90Dias
            '08/11/2019 AOS - Aqui me quedé
            '-- El resultado final debe de ser ejemplo: "19-12-2019"
            Dim NewDate As Date = Nothing
            Dim dia As String = ""
            Dim Mes As String = ""
            Dim anio As String = ""
            NewDate = DateAdd(DateInterval.Day, 90, Convert.ToDateTime(FAlta))
            Try : Fec90Dias = FechaLetra(FechaSQL(NewDate)) : Catch ex As Exception : Fec90Dias = "" : End Try
            'If (Fec90Dias.Trim <> "") Then
            '    dia = Fec90Dias.Substring(8, 2)
            '    Mes = Fec90Dias.Substring(5, 2)
            '    anio = Fec90Dias.Substring(0, 4)
            '    Fec90Dias = dia.Trim & "-" & Mes.Trim & "-" & anio.Trim
            'End If

            Return Fec90Dias
        Catch ex As Exception
            Return Fec90Dias
        End Try
    End Function

    Public Sub ExcelPermisoAusencia(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        '-----------Llenar archivo de excel 
        Try

            '--Obtener la ruta de la plantilla:
            Dim PathPlantilla As String = ""
            Dim dtPathPlantilla As DataTable = sqlExecute("select path_reportes from parametros", "PERSONAL")
            If (Not dtPathPlantilla.Columns.Contains("Error") And dtPathPlantilla.Rows.Count > 0) Then
                PathPlantilla = IIf(IsDBNull(dtPathPlantilla.Rows(0).Item("path_reportes")), "", dtPathPlantilla.Rows(0).Item("path_reportes").ToString.Trim)
            End If
            PathPlantilla = PathPlantilla.Trim & "Permiso de ausencia.xlsx" ' El path donde vamos a tomar la plantilla NOTA: La plantilla de excel ya debe de estar aqui en la ruta
            '--Ends
            dtDatos = dtInformacion.Copy ' Para que mande el resumen de todos los empleados

            '---Solicitar Ruta de Guardado

            Dim PathSave As String = ""
            Dim fbd As New FolderBrowserDialog
            fbd.SelectedPath = PathSave
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                PathSave = fbd.SelectedPath.Trim & "\"
            Else
                MessageBox.Show("No se seleccionó ruta de guardado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' ''--Cod que toma librerias para no abrir el office o que tenga que estar instalado:
            'Dim archivo As ExcelPackage = New ExcelPackage(New FileInfo(PathPlantilla))
            'Dim wb As ExcelWorkbook = archivo.Workbook

            LlenarPlantillaExcel("PERMISO", "", dtInformacion, PathSave, PathPlantilla)     '- Metodo para Generar varias plantillas en excel si es que se mandan mas de 1 empleado y llenar cada una a partir de una plantilla base

            MessageBox.Show("Archivo(s) generado(s) correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
        '-----------ENDS archivo de excel 

    End Sub


    '== MODIFICADO          23nov2021           Ernesto
    Public Sub LlenarPlantillaExcel(nombre_hoja As String, filtro As String, ByRef dtInfo As DataTable, ByRef _PathSave As String, ByRef _PathPlantilla As String) ' Cod que toma librerias para no abrir el office o tenga que estar instalado
        Try

            '--Rellenar ya con los datos a partir del renglón 7, Columna 3 
            '-- Aqui que genere todas las plantillas y que guarde cada una con su No.Reloj en la ruta especificada
            If (dtInfo.Rows.Count > 0) Then
                For Each row As DataRow In dtInfo.Rows

                    ''--Cod que toma librerias para no abrir el office o que tenga que estar instalado:
                    Dim archivo As ExcelPackage = New ExcelPackage(New FileInfo(_PathPlantilla))
                    Dim wb As ExcelWorkbook = archivo.Workbook
                    Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Item(1)
                    Dim FileName As String = ""
                    Dim reloj As String = IIf(IsDBNull(row("RELOJ")), "", row("RELOJ"))
                    FileName = _PathSave & "Permiso de ausencia_" & reloj.Trim & ".xlsx"

                    Dim FechaSol As String = FechaLetra(Date.Now)

                    '   Dim Nombres As String = IIf(IsDBNull(row("nombres")), "", row("nombres"))
                    Dim Nombres As String = "", name As String = "", apaterno As String = "", amaterno As String = ""
                    Try : name = row("nombre").ToString.Trim : Catch ex As Exception : name = "" : End Try
                    Try : apaterno = row("apaterno").ToString.Trim : Catch ex As Exception : apaterno = "" : End Try
                    Try : amaterno = row("amaterno").ToString.Trim : Catch ex As Exception : amaterno = "" : End Try
                    Nombres = apaterno & " " & amaterno & " " & name

                    Dim nombre_puesto As String = IIf(IsDBNull(row("nombre_puesto")), "", row("nombre_puesto"))
                    Dim nombre_depto As String = IIf(IsDBNull(row("nombre_depto")), "", row("nombre_depto"))

                    '--- Como las columnas son fijas en la plantilla, no es necesario ir de una en una, se dejan fijas Renglones y columnas
                    hoja_excel.Cells(13, 4).Value = FechaSol
                    hoja_excel.Cells(15, 4).Value = reloj.Trim
                    hoja_excel.Cells(15, 12).Value = Nombres.Trim
                    hoja_excel.Cells(17, 2).Value = nombre_puesto.Trim
                    hoja_excel.Cells(17, 13).Value = nombre_depto.Trim

                    '== Incluir información como el nombre del empleado, supervisor y el gerente de recursos humanos
                    Dim dtTemp As DataTable = sqlExecute("select (rtrim(pv.NOMBRE)+' '+rtrim(pv.APATERNO)+' '+rtrim(pv.AMATERNO)) as gerente_rh,s.NOMBRE as supervisor_emp," & _
                                                                "(rtrim(p.NOMBRE)+' '+rtrim(p.APATERNO)+' '+rtrim(p.AMATERNO)) as empleado_nom from PERSONAL.dbo.personalvw pv,PERSONAL.dbo.personal p " & _
                                                                "left join PERSONAL.dbo.super s on p.COD_SUPER=s.COD_SUPER " & _
                                                                "where p.RELOJ='" & reloj.Trim & "' and pv.nombre_puesto='GERENTE DE RECURSOS HUMANOS'")
                    Dim super As String = "--"
                    Dim gerente_rh As String = "--"
                    Dim nombre_emp As String = "--"

                    If dtTemp.Rows.Count > 0 Then
                        super = dtTemp.Rows(0)("supervisor_emp").ToString.Trim.ToUpper
                        gerente_rh = dtTemp.Rows(0)("gerente_rh").ToString.Trim.ToUpper
                        nombre_emp = dtTemp.Rows(0)("empleado_nom").ToString.Trim.ToUpper
                    End If

                    hoja_excel.Cells(57, 2).Value = nombre_emp
                    hoja_excel.Cells(57, 8).Value = super
                    hoja_excel.Cells(57, 13).Value = gerente_rh

                    archivo.SaveAs(New FileInfo(FileName))  '--Cod que toma librerias para no abrir el office o que tenga que estar instalado:
                    archivo.Dispose() ' Cerramos toda la instancia de excel para que no marque error
                Next
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Dispersión de despensa", ex.HResult, ex.Message)
        End Try

    End Sub

    Public Sub GafetesQR(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        '**************************************************************
        'Código para agregar código QR
        'MCR NOV/03/2020

        Try
            Dim Num As String
            Dim Txt As String
            Dim QR As Bitmap
            Dim FechaVigencia As Date
            Dim Dias As Integer

            dtDatos = dtInformacion.Copy
            dtDatos.Columns.Add("CodigoQR", GetType(Byte()))
            dtDatos.Columns.Add("vigencia", GetType(Date))


            frmTiempoVigencia.lblTitulo.Text = "<font color=""#1F497D""><b>GAFETES</b></font>"
            If frmTiempoVigencia.ShowDialog() = DialogResult.OK Then
                FechaVigencia = FechaIni
                Dias = NumControl
                For Each dRow In dtDatos.Rows
                    Num = Int(dRow.Item("reloj"))
                    Txt = Num.ToString.Trim & dRow("apaterno").ToString.Trim & dRow("amaterno").ToString.Trim & dRow("imss").ToString.Trim & dRow("dig_ver").ToString.Trim & dRow("nombre_depto").ToString.Trim

                    If FechaIni = Nothing Then
                        dRow("vigencia") = DateAdd("d", NumControl, dRow("alta"))
                    Else
                        dRow("vigencia") = FechaIni
                    End If

                    'Generar código QR
                    QR = GenerateQRCode(Txt, Color.Black, Color.White, 3)
                    Application.DoEvents()

                    dRow.Item("CodigoQR") = imageToByteArray(QR)
                Next
                '**************************************************************
            Else
                dtDatos.Rows.Clear()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Function GenerateQRCode(URL As String, DarkColor As System.Drawing.Color, LightColor As System.Drawing.Color, escala As Integer) As Bitmap
        Dim Encoder As New Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.L)
        Dim Code As Gma.QrCodeNet.Encoding.QrCode = Encoder.Encode(URL)

        Dim contadorx As Integer = 1
        Dim contadory As Integer = 1

        Dim TempBMP As New Bitmap(Code.Matrix.Width * escala, Code.Matrix.Height * escala)
        For X As Integer = 0 To (Code.Matrix.Width) - 1
            For Y As Integer = 0 To (Code.Matrix.Height) - 1
                Try
                    If Code.Matrix.InternalArray(X, Y) Then
                        For i As Integer = 0 To escala Step 1
                            For j As Integer = 0 To escala - 1 Step 1
                                TempBMP.SetPixel((X * escala) + i, (Y * escala) + j, DarkColor)
                            Next
                        Next
                    Else
                        For i As Integer = 0 To escala Step 1
                            For j As Integer = 0 To escala - 1 Step 1
                                TempBMP.SetPixel((X * escala) + i, (Y * escala) + j, LightColor)
                            Next
                        Next
                    End If
                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
                End Try
            Next
        Next
        Return TempBMP
    End Function

    Public Function imageToByteArray(ByVal imageIn As System.Drawing.Image) As Byte()
        Dim ms As New System.IO.MemoryStream
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
        Return ms.ToArray()
    End Function

    '--Modificado para incluir dias ganados y dias tomados totales      marzo/21        Ernesto
    Public Sub ProyeccionVacas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        '---Reporte de proyección de saldos de vacaciones
        Try

            Dim NoReloj As String = ""
            Dim FecAlta As Date

            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ", GetType(System.String))
            dtDatos.Columns.Add("nocontrol", GetType(System.String))
            dtDatos.Columns.Add("nombres", GetType(System.String))
            dtDatos.Columns.Add("cod_emp", GetType(System.String))
            dtDatos.Columns.Add("descrip_tipoEmp", GetType(System.String))
            dtDatos.Columns.Add("cod_depto", GetType(System.String))
            dtDatos.Columns.Add("nombre_depto", GetType(System.String))
            dtDatos.Columns.Add("alta") '- A las de tipo fecha no le defino nada

            '--Se agregaron dias ganados y dias tomados     marzo/21
            dtDatos.Columns.Add("dias_ganados", GetType(System.Double))
            dtDatos.Columns.Add("dias_tomados", GetType(System.Double))
            dtDatos.Columns.Add("dias_pago", GetType(System.Double))

            dtDatos.Columns.Add("dias_deveng", GetType(System.Double))
            dtDatos.Columns.Add("saldo_final", GetType(System.Double))
            dtDatos.Columns.Add("fec_proy") '- A las de tipo fecha no le defino nada

            Dim dtNoControl As New DataTable  'Obt Num control
            Dim dtPolVaca As New DataTable  ' Politica Vacas

            dtNoControl = sqlExecute("select * from detalle_auxiliares WHERE CAMPO='NUMCONTROL' AND (CONTENIDO is not null and CONTENIDO<>'')", "PERSONAL")
            dtPolVaca = sqlExecute("select * from vacaciones where cod_tipo is not null and COD_TIPO<>'' AND ANOS is not null and ANOS<>''", "PERSONAL")

            Dim fechaproy As Date
            Dim selFecha As frmSeleccionarFecha = New frmSeleccionarFecha()
            selFecha.ShowDialog()
            fechaproy = FechaSQL(selFecha.dtFechaInicial.Value)

            frmTrabajando.Show()
            Application.DoEvents()

            For Each row As DataRow In dtInformacion.Rows
                Dim drow As DataRow = dtDatos.NewRow

                Dim NoControl As String = ""
                Dim cod_tipo As String = ""
                Dim descrip_tipoEmp As String = ""
                Dim alta As String = ""
                Dim ano As String = ""
                Dim cadenaFecAlta As String = ""
                Dim FecAniv As Date

                '--Comentado        marzo/21
                'Dim _fecCorteVac As String = "2020-11-18" '-Dejamos fijo el corte de vacas, pero puede ir cambiando
                'Dim FCorteVac As Date = FechaSQL(Date.Parse(_fecCorteVac))

                Dim Anios As Integer = 0
                Dim AniosProp As Integer = 0
                Dim diasVacPol As Double = 0
                Dim diasVacPolProp As Double = 0
                Dim difAnios As Integer = 0
                Dim saldo_din As Double = 0
                Dim saldo_time As Double = 0
                Dim difDias2 As Integer
                Dim propVac As Double = 0
                Dim saldoFinal As Double = 0

                '--variables dias ganados y totales     marzo/21
                Dim dias_ganados As Integer = 0
                Dim dias_tomados As Integer = 0


                drow("RELOJ") = row("RELOJ").ToString.Trim
                NoReloj = drow("RELOJ")

                frmTrabajando.lblAvance.Text = NoReloj
                Application.DoEvents()

                drow("nombres") = row("nombres").ToString.Trim
                drow("cod_emp") = row("cod_tipo").ToString.Trim
                cod_tipo = drow("cod_emp")
                Select Case cod_tipo
                    Case "O"
                        descrip_tipoEmp = "Operativo"
                    Case Else
                        descrip_tipoEmp = "Administrativo"
                End Select

                drow("descrip_tipoEmp") = descrip_tipoEmp
                drow("cod_depto") = row("cod_tipo").ToString.Trim
                drow("nombre_depto") = row("nombre_depto").ToString.Trim
                drow("fec_proy") = FechaSQL(fechaproy)
                alta = row("ALTA").ToString.Trim

                If (alta <> "") Then
                    drow("alta") = FechaSQL(alta)
                    FecAlta = FechaSQL(alta)
                End If

                '2- Obtener No Control
                Dim drow_NoControl As DataRow = Nothing
                Try
                    drow_NoControl = dtNoControl.Select("Reloj ='" & NoReloj & "'")(0)
                Catch ex As Exception
                End Try
                If Not IsNothing(drow_NoControl) Then
                    NoControl = drow_NoControl("CONTENIDO").ToString.Trim
                End If
                '2-ENDS
                drow("nocontrol") = NoControl

                '------Obtener datos para vacaciones

                If (alta <> "") Then
                    '-Obtener Antig Anios
                    Dim difDias1 As Double = DateDiff(DateInterval.Day, FecAlta, fechaproy)
                    Dim AnioTotal As Double = Math.Round((difDias1 / 365), 2) ' Obtenemos la cantid de anios 
                    Dim AnioEntero As Integer = Int(AnioTotal) ' Obtenemos la cant de anios en entero, ejemp: 16
                    difAnios = AnioEntero '- Dif de anios entre la fecha de proy y la fecha de alta del empleado
                    Dim PropAnio As Double = AnioTotal - AnioEntero ' Obtenemos la dif en decimal
                    Anios = AnioEntero
                    AniosProp = IIf(PropAnio > 0, AnioEntero + 1, AnioEntero) ' Obtenemos los anios para la politica de vac
                    '-ENDS
                    '--Obtener los politica de vacaciones

                    '-------Obtener dias del Aniv cumplido los cuales son los días ganados
                    Dim drow_diasVacPol As DataRow = Nothing
                    Try
                        drow_diasVacPol = dtPolVaca.Select("COD_TIPO='" & cod_tipo & "' and ANOS=" & Anios)(0)
                    Catch ex As Exception

                    End Try
                    If Not IsNothing(drow_diasVacPol) Then
                        diasVacPol = Double.Parse(drow_diasVacPol("DIAS").ToString.Trim)
                    End If

                    '----Obtener los dias para la proporcion
                    Dim drow_diasVacPolProp As DataRow = Nothing
                    Try
                        drow_diasVacPolProp = dtPolVaca.Select("COD_TIPO='" & cod_tipo & "' and ANOS=" & AniosProp)(0)
                    Catch ex As Exception

                    End Try
                    If Not IsNothing(drow_diasVacPolProp) Then
                        diasVacPolProp = Double.Parse(drow_diasVacPolProp("DIAS").ToString.Trim)
                    End If
                    '--ENDS

                    '--Add la dif de años a la fecha de alta para obtener la fecha de aniv, y obtener el proporcional (devengado)
                    FecAniv = FechaSQL(DateAdd("yyyy", difAnios, FecAlta))
                    If (fechaproy >= FecAniv) Then ' Si la fecha proy es mayor a la fecha de Aniv
                        '- Obtener Proporcion, y sumarle los días ganados si la fec aniv > a la fechadeCorte
                        difDias2 = DateDiff(DateInterval.Day, FecAniv, fechaproy)

                        '--Vacaciones devengadas        modificado marzo/21
                        'propVac = Math.Round((difDias2 / 365) * diasVacPolProp, 2) '-Esta seria la prop a sumar al total (Dias devengados)
                        propVac = VacacionesDevengadas(NoReloj, Now.Date)

                        '--Comentado        Marzo/21
                        '--Si la FecAniv es mayor a la fecha de corte de vacs, si hay que sumar los dias ganados a las prop
                        'If (FecAniv > FCorteVac) Then
                        '    propVac = propVac + diasVacPol
                        'End If

                    Else
                        '-Si la fec de aniv es mayor a la fecha de proy, le restamos un aÑo a la Fec Aniv para obtener la prop correcta, y aquí no suma los días ganados
                        FecAniv = DateAdd("yyyy", -1, FecAniv)
                        difDias2 = DateDiff(DateInterval.Day, FecAniv, fechaproy)

                        '--Vacaciones devengadas        modificado marzo/21
                        'propVac = Math.Round((difDias2 / 365) * diasVacPolProp, 2) '-Esta seria la prop a sumar al total (Dias devengados)
                        propVac = VacacionesDevengadas(NoReloj, Now.Date)
                    End If

                    '--Obtener Saldos de vacaciones
                    Dim dtSaldosVacas As New DataTable
                    '--Comentado            marzo/21
                    'dtSaldosVacas = sqlExecute("select TOP 1 * from saldos_vacaciones where RELOJ='" & NoReloj & "' order by FECHA_FIN desc", "PERSONAL")

                    dtSaldosVacas = sqlExecute("SELECT TOP 1 saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & NoReloj & _
                                "' ORDER BY fecha_captura DESC,fecha_fin DESC")


                    If (dtSaldosVacas.Rows.Count > 0) Then
                        Dim drow_salVacas As DataRow = Nothing
                        Try
                            drow_salVacas = dtSaldosVacas(0)  ' Como arroja solo un resultado lo dejamos x default el primer rec que encuentra (0)
                        Catch ex As Exception
                        End Try

                        If Not IsNothing(drow_salVacas) Then
                            saldo_din = Double.Parse(drow_salVacas("SALDO_DINERO").ToString.Trim)
                            saldo_time = Double.Parse(drow_salVacas("SALDO_TIEMPO").ToString.Trim)
                        End If
                    End If

                    '==DIAS TOTALES Y GANADOS==         MARZO/21
                    Dim dtTotalesGanados As New DataTable
                    dtTotalesGanados = sqlExecute("select reloj,SUM(CAST(dias as int)) as dias_ganados, SUM(CAST(tiempo as int)) as dias_tomados  from saldos_vacaciones " & _
                                                                 "where RELOJ= '" & NoReloj & "' group by RELOJ ")
                    '--AGREGADO MARZO 23
                    Try
                        dias_ganados = IIf(IsDBNull(dtTotalesGanados.Rows(0)("dias_ganados")), 0, dtTotalesGanados.Rows(0)("dias_ganados"))
                        dias_tomados = IIf(IsDBNull(dtTotalesGanados.Rows(0)("dias_tomados")), 0, dtTotalesGanados.Rows(0)("dias_tomados"))
                    Catch ex As Exception
                        dias_ganados = 0
                        dias_tomados = 0
                    End Try
                    '--
                    drow("dias_ganados") = dias_ganados
                    drow("dias_tomados") = dias_tomados

                    '   saldoFinal = Math.Round((propVac + saldo_time), 2)
                    saldoFinal = Math.Round((dias_ganados - dias_tomados + propVac), 2) ' AOS 2022-11-30
                    drow("dias_pago") = saldo_din
                    drow("dias_deveng") = propVac
                    drow("saldo_final") = saldoFinal
                    dtDatos.Rows.Add(drow)
                End If

            Next

            ActivoTrabajando = False
            frmTrabajando.Close()

        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub ReporteCuentasYClabes(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable) 'Funcion para guardar los datos en la tabla del dataset en en rdl para que se muestren los nombres y relojes que no se les hizo timbrado
        Try
            'dtInformacion = sqlExecute("SELECT Reloj,Reloj_alt as 'Id_Sap',Nombres,Cuenta_Banco,[CLABE] from personalvw")
            Dim z As Integer = dtInformacion.Rows.Count
            Dim reloj As String = "", IDSap As String = "", nombres As String = "", CuentaBanco As String = "", CLABE As String
            dtDatos.Columns.Add("Reloj")
            dtDatos.Columns.Add("Id_Sap")
            dtDatos.Columns.Add("Nombres")
            dtDatos.Columns.Add("Cuenta_Banco")
            dtDatos.Columns.Add("CLABE")

            For Each drRw In dtInformacion.Rows
                reloj = drRw("RELOJ").ToString.Trim
                IDSap = drRw("reloj_alt").ToString.Trim
                nombres = drRw("NOMBRES").ToString.Trim
                CuentaBanco = drRw("Cuenta_Banco").ToString.Trim
                CLABE = drRw("CLABE").ToString.Trim

                Dim drow As DataRow = dtDatos.NewRow
                drow("Reloj") = reloj
                drow("Id_Sap") = IDSap
                drow("Nombres") = nombres
                drow("Cuenta_Banco") = CuentaBanco
                drow("CLABE") = CLABE
                dtDatos.Rows.Add(drow)

            Next
        Catch ex As Exception

        End Try
    End Sub


    '---------ANTONIO---------'         Agregados motivos de baja       12abril2022     Ernesto
    Public Sub ReporteEmpleadosBaja(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable) 'Funcion para guardar los datos en la tabla del dataset y que se muestren todos los empledos que se han dado de baja
        Try
            Dim Alta As Date
            Dim Baja As Date
            Dim z As Integer = dtInformacion.Rows.Count
            Dim mot_baja = ""
            Dim sub_baja = ""
            dtDatos.Columns.Add("Reloj")
            dtDatos.Columns.Add("Id_Sap")
            dtDatos.Columns.Add("ALTA")
            dtDatos.Columns.Add("BAJA")
            dtDatos.Columns.Add("MOTIVO_BAJA")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("NOMBRE_PUESTO")
            dtDatos.Columns.Add("NOMBRE_DEPTO")
            dtDatos.Columns.Add("CENTRO_COSTOS")
            dtDatos.Columns.Add("COD_SUPER")
            dtDatos.Columns.Add("NOMBRE_SUPER")
            dtDatos.Columns.Add("MOT_BAJA_INT")
            dtDatos.Columns.Add("SUBMOT_BAJA_INT")

            For Each drRw In dtInformacion.Rows
                Alta = CDate(drRw("alta").ToString.Trim)
                Baja = CDate(drRw("baja").ToString.Trim)
                Dim drow As DataRow = dtDatos.NewRow
                drow("Reloj") = drRw("Reloj").ToString.Trim
                drow("Id_Sap") = drRw("Id_Sap").ToString.Trim
                drow("ALTA") = Alta.ToShortDateString
                drow("BAJA") = Baja.ToShortDateString
                drow("MOTIVO_BAJA") = drRw("motivo_baja").ToString.Trim
                drow("NOMBRES") = drRw("nombres").ToString.Trim
                drow("NOMBRE_PUESTO") = drRw("nombre_puesto").ToString.Trim
                drow("NOMBRE_DEPTO") = drRw("Nombre_depto").ToString.Trim
                drow("CENTRO_COSTOS") = drRw("CENTRO_COSTOS").ToString.Trim
                drow("COD_SUPER") = drRw("COD_SUPER").ToString.Trim
                drow("nombre_super") = drRw("nombre_super").ToString.Trim

                '==COD_MOT_BA,motivo_baja,cod_sub_ba,SUBMOTIVO_BAJA
                mot_baja = IIf(IsDBNull(drRw("COD_MOT_BA")), "N/A", Trim(drRw("COD_MOT_BA").ToString)) & " - " & IIf(IsDBNull(drRw("motivo_baja")), "N/A", Trim(drRw("motivo_baja").ToString))
                sub_baja = IIf(IsDBNull(drRw("cod_sub_ba")), "N/A", Trim(drRw("cod_sub_ba").ToString)) & " - " & IIf(IsDBNull(drRw("SUBMOTIVO_BAJA")), "N/A", Trim(drRw("SUBMOTIVO_BAJA").ToString))

                drow("MOT_BAJA_INT") = mot_baja
                drow("SUBMOT_BAJA_INT") = sub_baja

                dtDatos.Rows.Add(drow)

            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    '---------------------FIN DE LO DE ANTONIO------------------

    Public Sub ModificacionesIMSS_Variables(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, ByVal fec_aplicacion As String)
        ' Dim dtInfoPersonal As New DataTable
        Dim Columnas(20) As DataColumn
        Dim ArchivoFoto As String = ""
        'Dim imgConnection As New SqlClient.SqlConnection(SQLConn & ";Initial Catalog='Personal';Persist Security Info=True; User ID=sa; Password=" & sPassword & ";")
        Dim PathFoto As String = ""
        Dim strFileName As String = ""

        Dim oWrite As System.IO.StreamWriter
        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 0
        Dim GuardaArchivo As Boolean = True
        'Dim i As Integer

        Try

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("rfc", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("infonavit", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("imss", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("cod_comp", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("compañia", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("paterno", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("materno", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("nombre", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("integrado", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("tipo_trab", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("tipo_sdo", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("sem_jorred", System.Type.GetType("System.String"))
            Columnas(14) = New DataColumn("modi", System.Type.GetType("System.String"))
            Columnas(15) = New DataColumn("umf", System.Type.GetType("System.String"))
            Columnas(16) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
            Columnas(17) = New DataColumn("guia", System.Type.GetType("System.String"))
            Columnas(18) = New DataColumn("reloj", System.Type.GetType("System.String"))
            Columnas(19) = New DataColumn("curp", System.Type.GetType("System.String"))
            Columnas(20) = New DataColumn("identifica", System.Type.GetType("System.String"))

            'copy fields reg_pat,imss,dig_ver,paterno,materno,nombre,integrado,f1,tipo_trab,tipo_sdo,;
            '	sem_jorred,modi,f2,tipo_mov,guia,reloj,filler,curp,identifica to &_archivo type sdf		

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

            If dtInformacion.Rows.Count > 0 Then
                dtTemp = sqlExecute("SELECT rfc, infonavit, reg_pat, nombre, guia, uma * 25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")
                Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

                PreguntaArchivo.Filter = "Text file|*.txt"
                PreguntaArchivo.FileName = ""
                If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    strFileName = PreguntaArchivo.FileName
                    'Dim objFSx As New FileStream(strFileName, FileMode.Create, FileAccess.Write)
                    'Dim objSW as StreamWriter(objFS)

                End If
                Try
                    oWrite = File.CreateText(strFileName)
                    GuardaArchivo = True
                Catch ex As Exception
                    oWrite = Nothing
                    GuardaArchivo = False
                End Try

                For Each dRow As DataRowView In dtInformacion.DefaultView
                    Dim integ As String = "0"
                    Dim integTemp As Double = 0

                    If Not IsDBNull(dRow("integrado")) Then
                        If dRow("integrado") > dtTemp.Rows(0).Item("tope") Then
                            integTemp = dtTemp.Rows(0).Item("tope")
                        Else
                            integTemp = dRow("integrado")
                        End If
                        'dRow.Item("integrado") = Double.Parse(Format(dRow.Item("integrado"), "f"))
                    End If
                    integ = Format(integTemp, "f")

                    '-- fha_ult_mo --> Es la fecha de aplicacion, ejemplo: 2021-01-01
                    dRow("fha_ult_mo") = fec_aplicacion

                    dtDatos.Rows.Add(dtTemp.Rows(0).Item("rfc"), dtTemp.Rows(0).Item("infonavit"), dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), dRow("cod_comp"), dtTemp.Rows(0).Item("nombre"), dRow("apaterno"), dRow("amaterno"), dRow("nombre"),
                    integ,
                                     "1", "2", "0", FechaDMY(IIf(IsDBNull(dRow("fha_ult_mo")), Nothing, dRow("fha_ult_mo"))), dRow("umf"), "07", dtTemp.Rows(0).Item("guia"), dRow("reloj"), dRow("curp"), "9")
                    x = dtDatos.Rows.Count - 1


                    If GuardaArchivo Then
                        oWrite.WriteLine(dtDatos.Rows(x).Item("reg_pat").ToString.Trim.PadRight(11) & _
                                        dtDatos.Rows(x).Item("imss").ToString.Trim.PadRight(10) & _
                                        dtDatos.Rows(x).Item("dig_ver").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("paterno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(x).Item("materno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(x).Item("nombre").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(x).Item("integrado").ToString.Trim.Replace(".", "").PadLeft(6, "0") & _
                                        Space(6) & _
                                        dtDatos.Rows(x).Item("tipo_trab").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("tipo_sdo").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("sem_jorred").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(x).Item("modi").ToString.Trim.PadRight(8) & _
                                        dtDatos.Rows(x).Item("umf").ToString.Trim.PadRight(3) & _
                                        Space(2) & _
                                        dtDatos.Rows(x).Item("tipo_mov").ToString.Trim.PadRight(2) & _
                                        dtDatos.Rows(x).Item("guia").ToString.Trim.PadRight(5) & _
                                        dtDatos.Rows(x).Item("reloj").ToString.Trim.PadRight(10) & _
                                        " " & _
                                        dtDatos.Rows(x).Item("curp").ToString.Trim.PadRight(18) & _
                                        dtDatos.Rows(x).Item("identifica").ToString.Trim.PadRight(1))
                    End If
                Next

                If GuardaArchivo Then
                    oWrite.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
                    oWrite.Close()
                End If

                Console.WriteLine("")
                Console.WriteLine("File creation complete. Press <Enter> to close this window.")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            Debug.Print(ex.StackTrace)
        End Try

    End Sub

    '== Reporte de acciones disciplinarias general  --  29marzo22   --  Ernesto
    Public Sub ReporteAccionDisciplinaria(ByRef dtDatos As DataTable)
        Try

            '== Rango de fechas de acuerdo a la seleccion en la forma
            Dim frm_fechas As New frmRangoFechas
            frm_fechas.Text = "Medidas disciplinarias"
            frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 12)
            frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>Seleccione fecha</b></font>
            frm_fechas.frmRangoFechas_fecha_ini = RangoFInicial
            frm_fechas.frmRangoFechas_fecha_fin = RangoFFinal
            frm_fechas.ShowDialog()

            Dim fecha_ini As Date = FechaInicial
            Dim fecha_fin As Date = FechaFinal

            Dim Qry As String = "select cod_cat_disciplinaria.nombre as categoria, accion_disciplinaria.folio, accion_disciplinaria.reloj, personalVW.nombres, accion_disciplinaria.cod_motivo, " & _
                                                                                                "plantas.NOMBRE as planta, deptos.NOMBRE as depto, super.NOMBRE as supervisor, " & _
                                                                                                "turnos.NOMBRE as turno, cod_motivo_disciplinario.NOMBRE as motivo, tipo_disciplinaria.TIPO_ACCION_DISCIPLINARIA, " & _
                                                                                                "accion_disciplinaria.FECHA, " & _
                                                                                                "accion_disciplinaria.COMENT_SUPER, accion_disciplinaria.COMENT_EMPLEADO " & _
                                                                                                "from accion_disciplinaria " & _
                                                                                                "LEFT JOIN personalVW on accion_disciplinaria.reloj = personalVW.reloj " & _
                                                                                                "LEFT JOIN plantas on  accion_disciplinaria.COD_PLANTA = plantas.COD_PLANTA and accion_disciplinaria.COD_COMP = plantas.COD_COMP " & _
                                                                                                "LEFT JOIN deptos on accion_disciplinaria.COD_DEPTO = deptos.COD_DEPTO and accion_disciplinaria.COD_COMP = deptos.COD_COMP " & _
                                                                                                "LEFT JOIN super on accion_disciplinaria.COD_SUPER = super.COD_SUPER and accion_disciplinaria.COD_COMP = super.COD_COMP " & _
                                                                                                "LEFT JOIN turnos on accion_disciplinaria.COD_TURNO = turnos.COD_TURNO and accion_disciplinaria.COD_COMP = turnos.COD_COMP " & _
                                                                                                "LEFT JOIN cod_motivo_disciplinario on accion_disciplinaria.COD_MOTIVO = cod_motivo_disciplinario.COD_MOTIVO " & _
                                                                                                "LEFT JOIN tipo_disciplinaria on accion_disciplinaria.COD_TIPO_ACCION = tipo_disciplinaria.COD_TIPO_ACCION " & _
                                                                                                "LEFT JOIN cod_cat_disciplinaria on accion_disciplinaria.categoria = cod_cat_disciplinaria.cod_categoria " & _
                                                                                                "where accion_disciplinaria.FECHA between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "' order by accion_disciplinaria.FECHA,accion_disciplinaria.RELOJ"

            Dim dtAccionDisc As DataTable = sqlExecute(Qry)

            If dtAccionDisc.Rows.Count > 0 Then
                dtDatos = dtAccionDisc.Copy
            End If

        Catch ex As Exception

        End Try
    End Sub

    '== Reporte de quejas general  --  22febrero23   --  Ernesto
    Public Sub ReporteQuejasGeneral(ByRef dtDatos As DataTable)
        Try

            '== Rango de fechas de acuerdo a la seleccion en la forma
            Dim frm_fechas As New frmRangoFechas
            frm_fechas.Text = "Quejas"
            frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 12)
            frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>Seleccione fecha</b></font>
            frm_fechas.frmRangoFechas_fecha_ini = RangoFInicial
            frm_fechas.frmRangoFechas_fecha_fin = RangoFFinal
            frm_fechas.ShowDialog()

            Dim fecha_ini As Date = FechaInicial
            Dim fecha_fin As Date = FechaFinal

            Dim Qry As String = "select p.RELOJ,p.NOMBRES,(pl.COD_PLANTA+', '+pl.NOMBRE) as PLANTA,p.DEPARTAMENTO as DEPTO,UPPER(pr.COD_SUPER+', '+s.nombre) as SUPERVISOR," &
                                "(RTRIM(p.ACUSADO)+', '+(select RTRIM(nombres) as nombres from personal.dbo.personalvw pv where pv.RELOJ=p.ACUSADO)) AS ACUSADO," &
                                "p.FECHA,UPPER(c.COD_MOTIVO+', '+c.NOMBRE) as MOTIVO,p.COMENT_SUPER,p.COMENT_EMPLEADO " &
                                "from personal.dbo.presentacion_quejas p " &
                                "left join personal.dbo.cod_queja c on c.COD_MOTIVO=p.COD_MOTIVO " &
                                "left join personal.dbo.plantas pl on pl.COD_PLANTA=p.COD_PLANTA " &
                                "left join personal.dbo.personal pr on pr.RELOJ=p.RELOJ " &
                                "left join personal.dbo.super s on s.COD_SUPER=pr.COD_SUPER " &
                                "where p.FECHA between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'"

            Dim dtAccionDisc As DataTable = sqlExecute(Qry)

            If dtAccionDisc.Rows.Count > 0 Then
                dtDatos = dtAccionDisc.Copy
            End If

        Catch ex As Exception

        End Try
    End Sub

    '== Reporte de excel para bajas con motivos     --      16marzo     --      Ernesto
    Public Sub ReporteExcelBajasMotivos()
        Try
            '== Dirección del reporte
            Dim dir As String = DireccionReportes & "BAJAS 2023.xlsx"

            If File.Exists(dir) Then

                '== Rango de fechas de acuerdo a la selección en la forma
                Dim frm_fechas As New frmRangoFechas
                frm_fechas.Text = "Filtrar fecha para bajas"
                frm_fechas.ReflectionLabel1.Font = New Font(frm_fechas.ReflectionLabel1.Font.FontFamily, 12)
                frm_fechas.ReflectionLabel1.Text = <font color="#1F497D"><b>Filtrar fecha para bajas</b></font>
                frm_fechas.frmRangoFechas_fecha_ini = RangoFInicial
                frm_fechas.frmRangoFechas_fecha_fin = RangoFFinal

                If frm_fechas.ShowDialog() = DialogResult.OK Then

                    '== Ruta de guardado
                    Dim fbd As New SaveFileDialog
                    fbd.DefaultExt = ".xlsx"
                    fbd.FileName = "Bajas " & Date.Now.Year.ToString
                    fbd.OverwritePrompt = True

                    If fbd.ShowDialog() = DialogResult.OK Then
                        Dim fecha_ini As Date = frm_fechas.dtFechaInicial.Value
                        Dim fecha_fin As Date = frm_fechas.dtFechaFinal.Value

                        '== Info para el excel
                        Dim strQry = "select rtrim(reloj) as codigo," &
                                     "concat(rtrim(p.apaterno),' ',rtrim(p.amaterno),' ',rtrim(p.nombre)) as nombre," &
                                     "p.alta as fecha_ingreso," &
                                     "rtrim(p.nombre_puesto) as puesto," &
                                     "rtrim(p.nombre_depto) as departamento," &
                                     "p.baja as fecha_baja," &
                                     "rtrim(p.motivo_baja) as motivos_baja_internos," &
                                     "upper(case when p.notas_baja is null or len(rtrim(p.notas_baja))<1 then null else rtrim(p.notas_baja) end) as notas," &
                                     "upper(rtrim(p.submotivo_baja)) as submotivo_baja_interno," &
                                     "(datediff(day,p.alta,p.baja)) as antiguedad " &
                                     "from personal.dbo.personalvw p where p.baja is not null and p.baja between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "'"

                        Dim dtInfo = sqlExecute(strQry)

                        If dtInfo.Rows.Count > 0 Then
                            '== Se abre la plantilla de excel
                            Dim plantilla As New ExcelPackage(New System.IO.FileInfo(DireccionReportes & "BAJAS 2023.xlsx"))
                            Dim wb As ExcelWorkbook = plantilla.Workbook
                            Dim hoja As ExcelWorksheet = wb.Worksheets(1)

                            '== Llenado de excel
                            Dim x = 2, y = 1, renglon = 0, col = 0
                            For Each row In dtInfo.Select("", "fecha_baja asc") : col = 0
                                For Each columna In dtInfo.Columns : hoja.Cells(x + renglon, y + col).Value = row(columna) : col += 1 : Next
                                renglon += 1
                            Next

                            '== Guardado de archivo
                            'Try : hoja.Cells(hoja.Dimension.Address).AutoFitColumns() : Catch ex As Exception : End Try
                            plantilla.SaveAs(New System.IO.FileInfo(fbd.FileName))
                            MessageBox.Show("Archivo generado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Process.Start(fbd.FileName)

                        Else
                            MessageBox.Show("Sin faltas registradas durante el rango seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            Else
                MessageBox.Show("No existe el archivo base para generar el reporte. Por favor, contacte al admin. del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la generación del reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ReporteExcelBajasMotivos", ex.HResult, ex.Message)
        End Try
    End Sub

    '--- AO 2023-05-24: Reporte de checadas de cafetería
    Public Sub ChecadasCafeteria(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            Dim fr As New frmRangoFechas

            '  fr.frmRangoFechas_fecha_ini = New Date(Now.Year, Now.Month, Now.Day - 7)
            '   fr.frmRangoFechas_fecha_fin = New Date(Now.Year, Now.Month, Now.Day)

            fr.frmRangoFechas_fecha_ini = Date.Now.AddDays(-7)
            fr.frmRangoFechas_fecha_fin = Date.Now()

            'Solicitar rango de fechas
            fr.ShowDialog()

            FechaInicial = FechaInicial.Date
            FechaFinal = FechaFinal.Date                   ' ------ filtros para poder comparar sin HRS y sea comparable desde el dia 1


            If FechaInicial = Nothing Then
                'Si el rango de fecha está en blanco, salir del procedimiento
                Exit Sub
            End If

            Dim Query As String = "SELECT c.*,p.nombres from ta.dbo.checadas_qr_caf c left outer join PERSONAL.dbo.personalvw p on c.id=p.reloj where c.fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' order by c.fecha asc"
            Dim dtEmpl As DataTable = sqlExecute(Query, "PERSONAL")

            If Not dtEmpl.Columns.Contains("Error") And dtEmpl.Rows.Count > 0 Then

                dtDatos = New DataTable
                If Not dtDatos.Columns.Contains("reloj") Then dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("nombres") Then dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("fecha") Then dtDatos.Columns.Add("fecha", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("hora") Then dtDatos.Columns.Add("hora", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FechaInicial") Then dtDatos.Columns.Add("FechaInicial", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FechaFinal") Then dtDatos.Columns.Add("FechaFinal", Type.GetType("System.String"))


                For Each dr As DataRow In dtEmpl.Rows
                    Dim reloj As String = "", nombres As String = "", fecha As String = "", hora As String = ""

                    Try : reloj = dr("id").ToString.Trim : Catch ex As Exception : reloj = "" : End Try

                    If dtInformacion.Select("reloj='" & reloj & "'").Count > 0 Then ' Depende de acuerdo al filtro que se haya mandando en el reporteador de Personal, solo tomara en cuenta a esos empleados
                        Try : nombres = dr("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
                        Try : fecha = FechaSQL(Date.Parse(dr("fecha"))) : Catch ex As Exception : fecha = "" : End Try
                        Try : hora = dr("hora").ToString.Trim : Catch ex As Exception : hora = "" : End Try

                        dtDatos.Rows.Add(reloj, nombres, fecha, hora, FechaSQL(FechaInicial), FechaSQL(FechaFinal))

                    End If

                Next
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos.Rows.Clear()
            Debug.Print("ERROR EN " & System.Reflection.MethodBase.GetCurrentMethod.Name() & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    '== Reporte de solicitud de vacaciones desde KIOSCO -- AO 2023-07-19
    Public Sub RepSolVacsDesdeKiosco(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            Dim fIni As Date, fFin As Date, query As String = "", dtUniversoInfo As New DataTable

            '--- Solicitar rango de fechas
            Dim fr As New frmRangoFechas
            fr.frmRangoFechas_fecha_ini = Date.Now.AddDays(-30)
            fr.frmRangoFechas_fecha_fin = Date.Now()

            fr.ShowDialog()
            FechaInicial = FechaInicial.Date
            FechaFinal = FechaFinal.Date

            If FechaInicial = Nothing Then Exit Sub
            fIni = FechaInicial.Date
            fFin = FechaFinal.Date

            If Not dtDatos.Columns.Contains("reloj") Then dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("nombres") Then dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("nombre_depto") Then dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("nombre_puesto") Then dtDatos.Columns.Add("nombre_puesto", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("fecha_solicitud") Then dtDatos.Columns.Add("fecha_solicitud", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("dias_solicitados") Then dtDatos.Columns.Add("dias_solicitados", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("fecha_inicio") Then dtDatos.Columns.Add("fecha_inicio", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("fecha_fin") Then dtDatos.Columns.Add("fecha_fin", Type.GetType("System.String"))
            If Not dtDatos.Columns.Contains("aprobado") Then dtDatos.Columns.Add("aprobado", Type.GetType("System.Int32"))
            If Not dtDatos.Columns.Contains("motivo_rechazo") Then dtDatos.Columns.Add("motivo_rechazo", Type.GetType("System.String"))


            '---- 2023-08-15: Agregar filtros de usuarios:  
            Dim dtFiltroUser As New DataTable, _filtroUser As String = ""
            dtFiltroUser = sqlExecute("SELECT filtro from appuser where USERNAME='" & Usuario & "'", "SEGURIDAD")
            If Not dtFiltroUser.Columns.Contains("Error") And dtFiltroUser.Rows.Count > 0 Then Try : _filtroUser = dtFiltroUser.Rows(0).Item("filtro").ToString.Trim : Catch ex As Exception : _filtroUser = "" : End Try


            query = "SELECT s.RELOJ,s.NOMBRE as 'nombres',p.nombre_depto,p.nombre_puesto,s.FECHA_SOLICITUD,s.DIAS_SOLICITADOS,s.FECHA_INICIO,s.FECHA_FIN,s.aprobado,s.motivo_rechazo from Solicitudes_Vacaciones s left outer join PERSONAL.dbo.personalvw p " & _
                "on s.RELOJ=p.RELOJ where CONVERT(date,s.FECHA_SOLICITUD) between '" & FechaSQL(fIni) & "' and '" & FechaSQL(fFin) & "' " & _
                IIf(_filtroUser <> "", "and " & _filtroUser & " ", "") & "order by FECHA_SOLICITUD asc"

            dtUniversoInfo = sqlExecute(query, "KIOSCO")

            If Not dtUniversoInfo.Columns.Contains("Error") And dtUniversoInfo.Rows.Count > 0 Then

                For Each dr As DataRow In dtUniversoInfo.Rows
                    Dim reloj As String = "", nombres As String = "", nombre_depto As String = "", nombre_puesto As String = "", fecha_solicitud As String = "", dias_solicitados As String = ""
                    Dim fecha_inicio As String = "", fecha_fin As String = "", aprobado As Integer = 0, motivo_rechazo As String = ""

                    Try : reloj = dr("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                    Try : nombres = dr("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
                    Try : nombre_depto = dr("nombre_depto").ToString.Trim : Catch ex As Exception : nombre_depto = "" : End Try
                    Try : nombre_puesto = dr("nombre_puesto").ToString.Trim : Catch ex As Exception : nombre_puesto = "" : End Try
                    Try : fecha_solicitud = FechaSQL(dr("fecha_solicitud")) : Catch ex As Exception : fecha_solicitud = "" : End Try
                    Try : dias_solicitados = dr("dias_solicitados").ToString.Trim : Catch ex As Exception : dias_solicitados = "0" : End Try
                    Try : fecha_inicio = FechaSQL(dr("fecha_inicio")) : Catch ex As Exception : fecha_inicio = "" : End Try
                    Try : fecha_fin = FechaSQL(dr("fecha_fin")) : Catch ex As Exception : fecha_fin = "" : End Try
                    Try : aprobado = Convert.ToInt32(dr("aprobado")) : Catch ex As Exception : aprobado = 2 : End Try
                    Try : motivo_rechazo = dr("motivo_rechazo").ToString.Trim : Catch ex As Exception : motivo_rechazo = "" : End Try

                    Dim drow As DataRow = dtDatos.NewRow
                    dtDatos.Rows.Add({reloj, nombres, nombre_depto, nombre_puesto, fecha_solicitud, dias_solicitados, fecha_inicio, fecha_fin, aprobado, motivo_rechazo})

                Next

            End If

            '----- AO Agregar los dias que se capturaron en el maestro de empleados en la pantalla de vacaciones
            Dim dtUniv2 As DataTable
            query = "select s.reloj,p.nombres,p.nombre_depto,p.nombre_puesto,s.FECHA_CAPTURA as 'fecha_solicitud',s.DINERO as 'dias_solicitados',s.FECHA_INI as 'fecha_inicio',s.FECHA_FIN as 'fecha_fin',1 as 'aprobado','' as 'motivo_rechazo' " & _
                   "from saldos_vacaciones s left outer join personalvw p on s.RELOJ=p.RELOJ " & _
                   "where s.FECHA_INI between '" & FechaSQL(fIni) & "' and '" & FechaSQL(fFin) & "'" & IIf(_filtroUser <> "", " and " & _filtroUser & " ", "") & " order by s.FECHA_FIN desc, s.FECHA_CAPTURA desc"

            dtUniv2 = sqlExecute(query, "PERSONAL")

            If Not dtUniv2.Columns.Contains("Error") And dtUniv2.Rows.Count > 0 Then
                For Each dr As DataRow In dtUniv2.Rows
                    Dim reloj As String = "", nombres As String = "", nombre_depto As String = "", nombre_puesto As String = "", fecha_solicitud As String = "", dias_solicitados As String = ""
                    Dim fecha_inicio As String = "", fecha_fin As String = "", aprobado As Integer = 0, motivo_rechazo As String = ""

                    Try : reloj = dr("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                    Try : nombres = dr("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
                    Try : nombre_depto = dr("nombre_depto").ToString.Trim : Catch ex As Exception : nombre_depto = "" : End Try
                    Try : nombre_puesto = dr("nombre_puesto").ToString.Trim : Catch ex As Exception : nombre_puesto = "" : End Try
                    Try : fecha_solicitud = FechaSQL(dr("fecha_solicitud")) : Catch ex As Exception : fecha_solicitud = "" : End Try
                    Try : dias_solicitados = dr("dias_solicitados").ToString.Trim : Catch ex As Exception : dias_solicitados = "0" : End Try
                    Try : fecha_inicio = FechaSQL(dr("fecha_inicio")) : Catch ex As Exception : fecha_inicio = "" : End Try
                    Try : fecha_fin = FechaSQL(dr("fecha_fin")) : Catch ex As Exception : fecha_fin = "" : End Try
                    Try : aprobado = Convert.ToInt32(dr("aprobado")) : Catch ex As Exception : aprobado = 0 : End Try
                    Try : motivo_rechazo = dr("motivo_rechazo").ToString.Trim : Catch ex As Exception : motivo_rechazo = "" : End Try

                    Dim drow As DataRow = dtDatos.NewRow
                    dtDatos.Rows.Add({reloj, nombres, nombre_depto, nombre_puesto, fecha_solicitud, dias_solicitados, fecha_inicio, fecha_fin, aprobado, motivo_rechazo})
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la generación del reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reporte sol vacas desde kiosco", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 'Método para generar reporte de Registro de personal Activo con fotografía
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub RegistroPersAct(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            Dim ENCABEZADO_EMPRESA As String = "", DIR_EMPRESA As String = "", path_fotos As String = ""
            Dim dtDetalleAuxiliares As New DataTable, dtAuxEmpleados As New DataTable

            If Not dtInformacion.Columns.Contains("Error") And dtInformacion.Rows.Count > 0 Then

                dtDatos = New DataTable
                If Not dtDatos.Columns.Contains("RELOJ") Then dtDatos.Columns.Add("RELOJ", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("NOMBRES") Then dtDatos.Columns.Add("NOMBRES", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("IMSS") Then dtDatos.Columns.Add("IMSS", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("RFC") Then dtDatos.Columns.Add("RFC", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FOTO_EMPLEADO") Then dtDatos.Columns.Add("FOTO_EMPLEADO", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("ENCABEZADO_EMPRESA") Then dtDatos.Columns.Add("ENCABEZADO_EMPRESA", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("DIR_EMPRESA") Then dtDatos.Columns.Add("DIR_EMPRESA", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("LICENCIA") Then dtDatos.Columns.Add("LICENCIA", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FECHA_VIG_LIC") Then dtDatos.Columns.Add("FECHA_VIG_LIC", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("RUTA_CLIENTE") Then dtDatos.Columns.Add("RUTA_CLIENTE", Type.GetType("System.String"))

                '---Obtener detalle de auxiliares, NO_Licencia y Vigencia de la Fecha 
                dtDetalleAuxiliares = sqlExecute("select * from detalle_auxiliares where campo in ('002','003') order by reloj asc", "PERSONAL")
                dtAuxEmpleados = sqlExecute("select reloj,contenido from detalle_auxiliares where campo='001' order by reloj asc ", "PERSONAL") ' Obtener ruta del cliente

                '----Obtener Encabezado y direccion de la empresa
                Dim dtCia As DataTable = sqlExecute("select * from PERSONAL.dbo.cias where CIA_DEFAULT=1", "PERSONAL")
                If Not dtCia.Columns.Contains("Error") And dtCia.Rows.Count > 0 Then
                    Dim rep_legal As String = "", rfc As String = "", direccion As String = "", colonia As String = "", cod_postal As String = "", telefono1 As String = "", ciudad As String = "", estado As String = ""

                    Try : rep_legal = dtCia.Rows(0).Item("rep_legal").ToString.Trim.ToUpper : Catch ex As Exception : rep_legal = "" : End Try
                    Try : rfc = dtCia.Rows(0).Item("rfc").ToString.Trim.ToUpper : Catch ex As Exception : rfc = "" : End Try
                    Try : direccion = dtCia.Rows(0).Item("direccion").ToString.Trim.ToUpper : Catch ex As Exception : direccion = "" : End Try
                    Try : colonia = dtCia.Rows(0).Item("colonia").ToString.Trim.ToUpper : Catch ex As Exception : colonia = "" : End Try
                    Try : cod_postal = dtCia.Rows(0).Item("cod_postal").ToString.Trim.ToUpper : Catch ex As Exception : cod_postal = "" : End Try
                    Try : telefono1 = dtCia.Rows(0).Item("telefono1").ToString.Trim.ToUpper : Catch ex As Exception : telefono1 = "" : End Try
                    Try : ciudad = dtCia.Rows(0).Item("ciudad").ToString.Trim.ToUpper : Catch ex As Exception : ciudad = "" : End Try
                    Try : estado = dtCia.Rows(0).Item("estado").ToString.Trim.ToUpper : Catch ex As Exception : estado = "" : End Try

                    ENCABEZADO_EMPRESA = rep_legal & "  RFC:" & rfc
                    DIR_EMPRESA = "CALLE " & direccion & " " & colonia & " C.P." & cod_postal & ", TEL:" & telefono1 & " " & ciudad & ", " & estado
                End If

                '---- Obtener ruta de fotos
                Dim dtPathFoto As DataTable = sqlExecute("select path_foto from parametros", "PERSONAL")
                If Not dtPathFoto.Columns.Contains("Error") And dtPathFoto.Rows.Count > 0 Then Try : path_fotos = dtPathFoto.Rows(0).Item("path_foto").ToString.Trim : Catch ex As Exception : path_fotos = "" : End Try



                '----Recorrer cada uno de los empleados
                For Each dr As DataRow In dtInformacion.Rows
                    Dim reloj As String = "", nombres As String = "", foto_empleado As String = "", IMSS As String = "", DIG_VER_IMSS As String = "", LICENCIA As String = "", FECHA_VIG_LIC As String = ""
                    Dim archivo_foto As String = "", RFC As String = "", ruta_cliente As String = ""

                    Try : reloj = dr("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                    Try : nombres = dr("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try

                    '---Obtener FOTO
                    archivo_foto = path_fotos & reloj & ".jpg"
                    If System.IO.File.Exists(archivo_foto) Then foto_empleado = archivo_foto Else foto_empleado = path_fotos & "sinfoto.jpg"

                    '---Get IMSS IMSS
                    Try : IMSS = dr("IMSS").ToString.Trim : Catch ex As Exception : IMSS = "" : End Try
                    Try : DIG_VER_IMSS = dr("DIG_VER").ToString.Trim : Catch ex As Exception : DIG_VER_IMSS = "" : End Try
                    IMSS = IMSS & "-" & DIG_VER_IMSS

                    '---GET RFC
                    Try : RFC = dr("rfc").ToString.Trim : Catch ex As Exception : RFC = "" : End Try

                    '--- Get Numero de licencia y fecha de vencimiento de la licencia de auxilares
                    If dtDetalleAuxiliares.Rows.Count > 0 Then
                        Dim item = (From x In dtDetalleAuxiliares Where x("RELOJ").ToString.Trim = reloj And x("CAMPO").ToString.Trim = "002").ToList() ' No Lic
                        Dim item2 = (From x In dtDetalleAuxiliares Where x("RELOJ").ToString.Trim = reloj And x("CAMPO").ToString.Trim = "003").ToList() ' Fecha vig

                        If item.Count > 0 Then Try : LICENCIA = (item.First()("CONTENIDO").ToString.Trim) : Catch ex As Exception : LICENCIA = "" : End Try
                        If item2.Count > 0 Then Try : FECHA_VIG_LIC = (item2.First()("CONTENIDO").ToString.Trim) : Catch ex As Exception : FECHA_VIG_LIC = "" : End Try
                    End If

                    '---Obtener la ruta_cliente del empleado
                    Dim item3 = (From x In dtAuxEmpleados.Rows Where x("reloj").ToString.Trim = reloj).ToList()
                    If (item3.Count > 0) Then Try : ruta_cliente = (item3.First()("contenido").ToString.Trim) : Catch ex As Exception : ruta_cliente = "" : End Try


                    dtDatos.Rows.Add({reloj, nombres, IMSS, RFC, foto_empleado, ENCABEZADO_EMPRESA, DIR_EMPRESA, LICENCIA, FECHA_VIG_LIC, ruta_cliente})
                Next



            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la generación del reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Rep.Registro de Personal activo", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 'Método para generar reporte de Empleados con modificacion de salario en un rango de fechas
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub ModSalRangoFec(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            Dim dtModSal As New DataTable, Query As String = ""

            If Not dtInformacion.Columns.Contains("Error") And dtInformacion.Rows.Count > 0 Then

                '----Solicitar rango de fechas
                Dim fr As New frmRangoFechas

                '---O usar este que funciona
                fr.frmRangoFechas_fecha_ini = Date.Now.AddDays(-7)
                fr.frmRangoFechas_fecha_fin = Date.Now()

                fr.ShowDialog()     'Solicitar rango de fechas
                FechaInicial = FechaInicial.Date
                FechaFinal = FechaFinal.Date                   ' ------ filtros para poder comparar sin HRS y sea comparable desde el dia 1

                If FechaInicial = Nothing Then Exit Sub
                Dim _fini As Date, _ffin As Date
                _fini = FechaInicial
                _ffin = FechaFinal
                '---ENDS Y ya _fini y _ffin los utilizamos a lo largo del código

                Query = "SELECT * from mod_sal where fecha between '" & FechaSQL(_fini) & "' and '" & FechaSQL(_ffin) & "'"
                dtModSal = sqlExecute(Query, "PERSONAL")

                If dtModSal.Columns.Contains("Error") Or dtModSal.Rows.Count <= 0 Then
                    MessageBox.Show("No hay empleados con modificación de salario en el rango de fechas enviado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                '---Crear columnas
                dtDatos = New DataTable
                If Not dtDatos.Columns.Contains("reloj") Then dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("nombres") Then dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FechaInicial") Then dtDatos.Columns.Add("FechaInicial", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("FechaFinal") Then dtDatos.Columns.Add("FechaFinal", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("fechamodif") Then dtDatos.Columns.Add("fechamodif", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("fechaapl") Then dtDatos.Columns.Add("fechaapl", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("santerior") Then dtDatos.Columns.Add("santerior", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("sactual") Then dtDatos.Columns.Add("sactual", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("aplicado") Then dtDatos.Columns.Add("aplicado", Type.GetType("System.String"))
                If Not dtDatos.Columns.Contains("notas") Then dtDatos.Columns.Add("notas", Type.GetType("System.String"))

                Dim contEmpl As Integer = 0
                '----==========Recorrer a cada uno de los empleados enviados en el filtro
                For Each dr As DataRow In dtInformacion.Rows
                    Dim _reloj As String = "", santerior As String = "", sactual As String = "", fec_apl As String = "", fec_modif As String = "", aplicado As Boolean = False
                    Dim _nombres As String = "", FechaInicial As String = "", FechaFinal As String = "", _aplicadoSINO As String = "", notas As String = ""

                    Try : _reloj = dr("reloj").ToString.Trim : Catch ex As Exception : _reloj = "" : End Try
                    Try : _nombres = dr("nombres").ToString.Trim : Catch ex As Exception : _nombres = "" : End Try


                    FechaInicial = FechaSQL(_fini)
                    FechaFinal = FechaSQL(_ffin)

                    Dim items = (From x In dtModSal.Rows Where x("reloj").ToString.Trim = _reloj).ToList()

                    If items.Count >= 1 Then
                        For x = 0 To items.Count - 1
                            Try : santerior = "$" & String.Format("{0:##0.00}", (items(x)("CAMBIO_DE"))) : Catch ex As Exception : santerior = "$0.00" : End Try
                            Try : sactual = "$" & String.Format("{0:##0.00}", (items(x)("CAMBIO_A"))) : Catch ex As Exception : sactual = "$0.00" : End Try
                            Try : fec_apl = FechaSQL((items(x)("FECHA"))) : Catch ex As Exception : fec_apl = "" : End Try
                            Try : fec_modif = FechaSQL((items(x)("HOY"))) : Catch ex As Exception : fec_modif = "" : End Try
                            Try : aplicado = (items(x)("aplicado")) : Catch ex As Exception : aplicado = False : End Try
                            Try : notas = (items(x)("NOTAS")) : Catch ex As Exception : notas = "" : End Try

                            ' santerior = "$" & String.Format("{0:##0.00}", santerior)
                            ' sactual = "$" & String.Format("{0:##0.00}", sactual)

                            If aplicado Then _aplicadoSINO = "SI" Else _aplicadoSINO = "NO"

                            dtDatos.Rows.Add({_reloj, _nombres, FechaInicial, FechaFinal, fec_modif, fec_apl, santerior, sactual, _aplicadoSINO, notas})

                            contEmpl += 1
                        Next
                    End If

                Next


                If contEmpl = 0 Then
                    MessageBox.Show("No hay empleados con modificación de salario en el rango de fechas enviado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If


            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la generación del reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Rep.Empl Modif Sal En RangoFechas", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 'Método para generar reporte de detalle del saldo de vcaciones x empleado
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub DetSalVacas(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try

            Dim NoReloj As String = "", FecAlta As Date

            dtDatos = New DataTable
            dtDatos.Columns.Add("RELOJ", GetType(System.String))
            dtDatos.Columns.Add("nombres", GetType(System.String))
            dtDatos.Columns.Add("cod_emp", GetType(System.String))
            dtDatos.Columns.Add("descrip_tipoEmp", GetType(System.String))
            dtDatos.Columns.Add("cod_depto", GetType(System.String))
            dtDatos.Columns.Add("nombre_depto", GetType(System.String))
            dtDatos.Columns.Add("alta") '- A las de tipo fecha no le defino nada

            '--Se agregaron dias ganados y dias tomados     marzo/21
            dtDatos.Columns.Add("dias_ganados", GetType(System.Double))
            dtDatos.Columns.Add("dias_tomados", GetType(System.Double))
            dtDatos.Columns.Add("dias_pago", GetType(System.Double))

            dtDatos.Columns.Add("dias_deveng", GetType(System.Double))
            dtDatos.Columns.Add("saldo_final", GetType(System.Double))
            dtDatos.Columns.Add("fec_proy") '- A las de tipo fecha no le defino nada


            Dim dtPolVaca As New DataTable  ' Politica Vacas

            dtPolVaca = sqlExecute("select * from vacaciones where cod_tipo is not null and COD_TIPO<>'' AND ANOS is not null and ANOS<>''", "PERSONAL")

            Dim fechaproy As Date = Now.Date()
            'Dim selFecha As frmSeleccionarFecha = New frmSeleccionarFecha()
            'selFecha.ShowDialog()
            'fechaproy = FechaSQL(selFecha.dtFechaInicial.Value)

            frmTrabajando.Show()
            Application.DoEvents()

            For Each row As DataRow In dtInformacion.Rows
                Dim drow As DataRow = dtDatos.NewRow

                Dim cod_tipo As String = ""
                Dim descrip_tipoEmp As String = ""
                Dim alta As String = ""
                Dim ano As String = ""
                Dim cadenaFecAlta As String = ""
                Dim FecAniv As Date


                Dim Anios As Integer = 0
                Dim AniosProp As Integer = 0
                Dim diasVacPol As Double = 0
                Dim diasVacPolProp As Double = 0
                Dim difAnios As Integer = 0
                Dim saldo_din As Double = 0
                Dim saldo_time As Double = 0
                Dim difDias2 As Integer
                Dim propVac As Double = 0
                Dim saldoFinal As Double = 0

                '--variables dias ganados y totales     marzo/21
                Dim dias_ganados As Integer = 0
                Dim dias_tomados As Integer = 0


                drow("RELOJ") = row("RELOJ").ToString.Trim
                NoReloj = drow("RELOJ")

                frmTrabajando.lblAvance.Text = NoReloj
                Application.DoEvents()

                drow("nombres") = row("nombres").ToString.Trim
                drow("cod_emp") = row("cod_tipo").ToString.Trim
                cod_tipo = drow("cod_emp")
                Select Case cod_tipo
                    Case "O"
                        descrip_tipoEmp = "Operativo"
                    Case Else
                        descrip_tipoEmp = "Administrativo"
                End Select

                drow("descrip_tipoEmp") = descrip_tipoEmp
                drow("cod_depto") = row("cod_tipo").ToString.Trim
                drow("nombre_depto") = row("nombre_depto").ToString.Trim
                drow("fec_proy") = FechaSQL(fechaproy)
                alta = row("ALTA").ToString.Trim

                If (alta <> "") Then
                    drow("alta") = FechaSQL(alta)
                    FecAlta = FechaSQL(alta)
                End If


                '------Obtener datos para vacaciones

                If (alta <> "") Then
                    '-Obtener Antig Anios
                    Dim difDias1 As Double = DateDiff(DateInterval.Day, FecAlta, fechaproy)
                    Dim AnioTotal As Double = Math.Round((difDias1 / 365), 2) ' Obtenemos la cantid de anios 
                    Dim AnioEntero As Integer = Int(AnioTotal) ' Obtenemos la cant de anios en entero, ejemp: 16
                    difAnios = AnioEntero '- Dif de anios entre la fecha de proy y la fecha de alta del empleado
                    Dim PropAnio As Double = AnioTotal - AnioEntero ' Obtenemos la dif en decimal
                    Anios = AnioEntero
                    AniosProp = IIf(PropAnio > 0, AnioEntero + 1, AnioEntero) ' Obtenemos los anios para la politica de vac
                    '-ENDS
                    '--Obtener los politica de vacaciones

                    '-------Obtener dias del Aniv cumplido los cuales son los días ganados
                    Dim drow_diasVacPol As DataRow = Nothing
                    Try
                        drow_diasVacPol = dtPolVaca.Select("COD_TIPO='" & cod_tipo & "' and ANOS=" & Anios)(0)
                    Catch ex As Exception

                    End Try
                    If Not IsNothing(drow_diasVacPol) Then
                        diasVacPol = Double.Parse(drow_diasVacPol("DIAS").ToString.Trim)
                    End If

                    '----Obtener los dias para la proporcion
                    Dim drow_diasVacPolProp As DataRow = Nothing
                    Try
                        drow_diasVacPolProp = dtPolVaca.Select("COD_TIPO='" & cod_tipo & "' and ANOS=" & AniosProp)(0)
                    Catch ex As Exception

                    End Try
                    If Not IsNothing(drow_diasVacPolProp) Then
                        diasVacPolProp = Double.Parse(drow_diasVacPolProp("DIAS").ToString.Trim)
                    End If
                    '--ENDS

                    '--Add la dif de años a la fecha de alta para obtener la fecha de aniv, y obtener el proporcional (devengado)
                    FecAniv = FechaSQL(DateAdd("yyyy", difAnios, FecAlta))
                    If (fechaproy >= FecAniv) Then ' Si la fecha proy es mayor a la fecha de Aniv
                        '- Obtener Proporcion, y sumarle los días ganados si la fec aniv > a la fechadeCorte
                        difDias2 = DateDiff(DateInterval.Day, FecAniv, fechaproy)

                        '--Vacaciones devengadas        modificado marzo/21
                        'propVac = Math.Round((difDias2 / 365) * diasVacPolProp, 2) '-Esta seria la prop a sumar al total (Dias devengados)
                        propVac = VacacionesDevengadas(NoReloj, Now.Date)

                    Else
                        '-Si la fec de aniv es mayor a la fecha de proy, le restamos un aÑo a la Fec Aniv para obtener la prop correcta, y aquí no suma los días ganados
                        FecAniv = DateAdd("yyyy", -1, FecAniv)
                        difDias2 = DateDiff(DateInterval.Day, FecAniv, fechaproy)

                        '--Vacaciones devengadas        modificado marzo/21
                        'propVac = Math.Round((difDias2 / 365) * diasVacPolProp, 2) '-Esta seria la prop a sumar al total (Dias devengados)
                        propVac = VacacionesDevengadas(NoReloj, Now.Date)
                    End If

                    '--Obtener Saldos de vacaciones
                    Dim dtSaldosVacas As New DataTable
                    '--Comentado            marzo/21
                    'dtSaldosVacas = sqlExecute("select TOP 1 * from saldos_vacaciones where RELOJ='" & NoReloj & "' order by FECHA_FIN desc", "PERSONAL")

                    dtSaldosVacas = sqlExecute("SELECT TOP 1 saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & NoReloj & _
                                "' ORDER BY fecha_captura DESC,fecha_fin DESC")


                    If (dtSaldosVacas.Rows.Count > 0) Then
                        Dim drow_salVacas As DataRow = Nothing
                        Try
                            drow_salVacas = dtSaldosVacas(0)  ' Como arroja solo un resultado lo dejamos x default el primer rec que encuentra (0)
                        Catch ex As Exception
                        End Try

                        If Not IsNothing(drow_salVacas) Then
                            saldo_din = Double.Parse(drow_salVacas("SALDO_DINERO").ToString.Trim)
                            saldo_time = Double.Parse(drow_salVacas("SALDO_TIEMPO").ToString.Trim)
                        End If
                    End If

                    '==DIAS TOTALES Y GANADOS==         MARZO/21
                    Dim dtTotalesGanados As New DataTable
                    dtTotalesGanados = sqlExecute("select reloj,SUM(CAST(dias as int)) as dias_ganados, SUM(CAST(tiempo as int)) as dias_tomados  from saldos_vacaciones " & _
                                                                 "where RELOJ= '" & NoReloj & "' group by RELOJ ")
                    '--AGREGADO MARZO 23
                    Try
                        dias_ganados = IIf(IsDBNull(dtTotalesGanados.Rows(0)("dias_ganados")), 0, dtTotalesGanados.Rows(0)("dias_ganados"))
                        dias_tomados = IIf(IsDBNull(dtTotalesGanados.Rows(0)("dias_tomados")), 0, dtTotalesGanados.Rows(0)("dias_tomados"))
                    Catch ex As Exception
                        dias_ganados = 0
                        dias_tomados = 0
                    End Try
                    '--
                    drow("dias_ganados") = dias_ganados
                    drow("dias_tomados") = dias_tomados

                    '   saldoFinal = Math.Round((propVac + saldo_time), 2)
                    saldoFinal = Math.Round((dias_ganados - dias_tomados + propVac), 2) ' AOS 2022-11-30
                    drow("dias_pago") = saldo_din
                    drow("dias_deveng") = propVac
                    drow("saldo_final") = saldoFinal
                    dtDatos.Rows.Add(drow)
                End If

            Next

            ActivoTrabajando = False
            frmTrabajando.Close()

        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            MessageBox.Show("Ha ocurrido un error durante la generación del reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Rep.Saldo.Vacaciones", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 'Método para generar reporte de infonavit al SUA
    ''' </summary>
    ''' <remarks></remarks>
    ''' 

    Public Sub SUAInfonavit(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable) ' Funcion para reporte SUA INFONAVIT

        Dim x As Integer = 0
        Dim y As Integer = -1   'Inicializado a -1, para que la primera vez que se incremente, de un indice 0 para el registro
        Dim z As Integer = 1
        Dim GlobalSUA As String = ""
        Dim GuardaArchivo As Boolean = True
        Dim sfd As New SaveFileDialog
        Dim _x As Integer = 1
        Dim nFecha As Date
        Dim nFecha1 As Date
        Dim _CountReg As Integer = 0

        Dim dtGrupos As DataTable   'MCR 20210525
        Dim drGrupo() As DataRow    'MCR 20210525

        Dim dtCias As DataTable
        Dim drCias() As DataRow = Nothing

        Dim Archivo As String = ""
        Dim fha_ini As String = ""
        Dim fha_fin As String = ""

        Dim dtPlantas As New DataTable

        Try

            dtCias = New DataTable("companias")
            dtCias.Columns.Add("cod_comp", System.Type.GetType("System.String"))
            dtCias.Rows.Add({"CTE"}) ' CTE
            dtCias.Rows.Add({"CT2"}) ' CT2

            dtDatos = New DataTable("Datos")

            'MCR 20210525
            'REEMPLAZAR FORMA DE AGREGAR COLUMNAS (ANTERIORMENTE CON ARREGLO COLUMNAS())
            dtDatos.Columns.Add("cod_comp", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("grupo_sua", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("reg_pat", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("imss", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("dig_ver", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo_mov", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_mov", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("num_incap", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("dias_incap_Ausen", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("integrado", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("Nombres", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("Reloj", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("Motivo", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("curp", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_clase", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_hora", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo_aus_nombre", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo_aus", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo_nombre", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_ini", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_fin", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo_naturaleza", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("infonavit", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("tipo_cred", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("cuota_cred", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("aplica_tasa", System.Type.GetType("System.String"))

            Dim frm_fechas_bimestre As New frmSeleccionaBimestre

            If frm_fechas_bimestre.ShowDialog() = DialogResult.Cancel Then
                Exit Sub
            End If

            If frm_fechas_bimestre.fha_ini_bim = Nothing Or frm_fechas_bimestre.fha_fin_bim = Nothing Then
                Exit Sub
            End If

            dtGrupos = sqlExecute("SELECT DISTINCT rtrim(ltrim(cod_comp)) as cod_comp, rtrim(ltrim(cod_comp)) as grupo_sua FROM plantas where cod_comp in ('CTE','CT2')")
            '  dtPlantas = sqlExecute("Select rtrim(ltrim(plantas.COD_COMP)) as COD_COMP,rtrim(ltrim(cias.NOMBRE)) as 'razon_social',rtrim(ltrim(plantas.COD_PLANTA)) as COD_PLANTA,rtrim(ltrim(plantas.REG_PAT)) as REG_PAT,plantas.GRUPO_SUA, isnull(plantas.uma * 25,0) as tope from plantas inner join cias on plantas.COD_COMP = cias.COD_COMP")

            fha_ini = FechaSQL(frm_fechas_bimestre.fha_ini_bim)
            fha_fin = FechaSQL(frm_fechas_bimestre.fha_fin_bim)

            Dim FD As New FolderBrowserDialog
            FD.Description = "Disco Infonavit al SUA"
            FD.RootFolder = Environment.SpecialFolder.Desktop

            If Not FD.ShowDialog() = Windows.Forms.DialogResult.OK Then Exit Sub

            Archivo = "CTE_Disco_Infonavit_SUA.txt"

            Dim v_Carpeta As String = "Discos_Infonavit_SUA_" & fha_ini & "_al_" & fha_fin
            Dim v_directorio As String = Path.Combine(FD.SelectedPath.ToString.Trim, v_Carpeta)


            frmTrabajando.Show()

            'MCR 20210525
            '//********************************************* INFONAVIT
            Dim dtDatosInfonavit As New DataTable()
            dtDatosInfonavit = dtDatos.Clone
            dtDatosInfonavit.Columns.Add("cuota", System.Type.GetType("System.String"))

            '//******************************************** AOS : 2022-05-04 Validar empleados con cambio de sucursal para que se agreguen al infonavit como  nuevo inicio de cred con el nuevo regpat (tipo_mov=15)
            'Dim dtDistinctRj As DataTable = sqlExecute("select distinct reloj from bitacora_personal where fecha>='" & fha_ini & "' and fecha<='" & fha_fin & "' and campo in ('alta_planta','cod_planta','reg_pat') and tipo_movimiento='C' ", "PERSONAL")
            'Dim dtBitaCambioSuc As DataTable = sqlExecute("select * from bitacora_personal where fecha>='" & fha_ini & "' and fecha<='" & fha_fin & "' and campo in ('alta_planta','cod_planta','reg_pat') and tipo_movimiento='C'", "PERSONAL")
            'Dim dtAllMovsInfo As DataTable = sqlExecute("SELECT * FROM infonavit WHERE fecha_aplicacion BETWEEN '" & fha_ini & "' and '" & fha_fin & "' order by reloj", "PERSONAL")

            'If (Not dtDistinctRj.Columns.Contains("Error") And dtDistinctRj.Rows.Count > 0) Then
            '    For Each drRow As DataRow In dtDistinctRj.Rows
            '        Dim rj As String = "", alta_planta As String = "", reg_pat As String = "", QInsertMovInfo As String = ""
            '        rj = drRow("reloj").ToString.Trim

            '        Dim drowAltaPlanta As DataRow = Nothing
            '        Try : drowAltaPlanta = dtBitaCambioSuc.Select("reloj='" & rj & "' and campo='alta_planta'")(0) : Catch ex As Exception : drowAltaPlanta = Nothing : End Try
            '        If (Not IsNothing(drowAltaPlanta)) Then alta_planta = FechaSQL(drowAltaPlanta("ValorNuevo").ToString.Trim)

            '        Dim drwRegPat As DataRow = Nothing
            '        Try : drwRegPat = dtBitaCambioSuc.Select("reloj='" & rj & "' and campo='reg_pat'")(0) : Catch ex As Exception : drwRegPat = Nothing : End Try
            '        If (Not IsNothing(drwRegPat)) Then reg_pat = drwRegPat("ValorNuevo").ToString.Trim

            '        '---AOS: 2022-04-25: Si la alta_planta no trae valor, entonces sería la alta_vacacion
            '        If (alta_planta = "") Then
            '            Dim dtAltaVaca As DataTable = sqlExecute("select alta_vacacion from personal where reloj='" & rj & "'", "PERSONAL")
            '            If (Not dtAltaVaca.Columns.Contains("Error") And dtAltaVaca.Rows.Count > 0) Then
            '                Try : alta_planta = FechaSQL(dtAltaVaca.Rows(0).Item("alta_vacacion")) : Catch ex As Exception : alta_planta = "" : End Try
            '            End If
            '        End If

            '        If (alta_planta <> "") Then
            '            '--Valida que la alta del cambio de planta este dentro del rango de fechas y que si  haya cambiado de registro patronal
            '            If ((Date.Parse(alta_planta) >= Date.Parse(fha_ini)) And (Date.Parse(alta_planta) <= Date.Parse(fha_fin)) And reg_pat <> "") Then
            '                '--Validar que el registro no exista ya en la tabla de infonavit
            '                If (dtAllMovsInfo.Select("reloj='" & rj & "' and fecha_aplicacion='" & alta_planta & "' and cod_movimiento='15'").Count <= 0) Then
            '                    Dim dtPersonal As DataTable = sqlExecute("select reloj,INFONAVIT,alta_planta,TIPO_CRE,pago_inf from personal where reloj='" & rj & "'", "PERSONAL")
            '                    If (Not dtPersonal.Columns.Contains("Error") And dtPersonal.Rows.Count > 0) Then
            '                        Dim infonavit As String = "", tipo_cre As String = "", pago_inf As Double = 0.0
            '                        Try : infonavit = dtPersonal.Rows(0).Item("infonavit").ToString.Trim : Catch ex As Exception : infonavit = "" : End Try
            '                        Try : tipo_cre = dtPersonal.Rows(0).Item("tipo_cre").ToString.Trim : Catch ex As Exception : tipo_cre = "" : End Try
            '                        Try : pago_inf = Double.Parse(dtPersonal.Rows(0).Item("pago_inf")) : Catch ex As Exception : pago_inf = 0.0 : End Try


            '                        If (infonavit <> "" And tipo_cre <> "" And pago_inf > 0.0) Then  '---2022-05-12 Insertar solo si tiene infonavit, tipo_cre y pago_inf
            '                            QInsertMovInfo = "insert into infonavit (reloj,infonavit,tipo_cred,cuota_cred,inicio_cre,activo,comentario,fecha_captura,usuario_captura,fecha_aplicacion,cod_movimiento) " & _
            '                              "values ('" & rj & "','" & infonavit & "','" & tipo_cre & "'," & pago_inf & ",'" & alta_planta & "',0,'Cambio de sucursal',getdate(),'Pida','" & alta_planta & "','15')"
            '                            sqlExecute(QInsertMovInfo, "PERSONAL")
            '                        End If

            '                    End If

            '                End If
            '            End If
            '        End If

            '    Next
            'End If

            '**AOS/******************************************** Termina lo de validar los empleados por cambio de sucursal

            Dim dtInfonavit As DataTable = sqlExecute("SELECT * FROM infonavit WHERE fecha_aplicacion BETWEEN '" & _
                                                      fha_ini & "' AND '" & fha_fin & "' ORDER BY reloj", "PERSONAL")

            Dim drNew As DataRow
            Dim Mov As String
            Dim Fecha As Date
            Dim Cuota As String

            _x = 1
            _CountReg = dtInfonavit.Rows.Count

            For Each dRow As DataRowView In dtInfonavit.DefaultView
                frmTrabajando.lblAvance.Text = "Reloj: " & dRow("Reloj")
                frmTrabajando.Text = "Infonavit " & CDbl(_x / _CountReg).ToString("0%") & " Terminado"
                Application.DoEvents()

                'Dim dtPersona As DataTable = sqlExecute("select personalvw.*,grupo_sua,isnull(plantas.uma * 25,0) as tope from personalvw left join plantas " & _
                '                                  "on personalvw.cod_comp = plantas.cod_comp and " & _
                '                                  "personalvw.cod_planta = plantas.cod_planta where reloj = '" & dRow("reloj") & "'")

                Dim dtPersona As DataTable = sqlExecute("select * from personalvw where reloj='" & dRow("reloj").ToString.Trim & "'", "PERSONAL")


                If dtPersona.Rows.Count > 0 Then


                    Dim dtPersonaTmp As DataTable = dtPersona.DefaultView.ToTable(False, "cod_comp", "cod_planta", "reloj", "cia_reg_pat")

                    Dim Movtmp As String = dRow("cod_movimiento")
                    Dim FechaTmp As Date = Nothing

                    If Movtmp = "15" Then
                        FechaTmp = dRow("inicio_cre")

                        If Not (FechaTmp >= CDate(fha_ini) And FechaTmp <= CDate(fha_fin)) Then
                            MessageBox.Show("Se detectó que la fecha de inicio de crédito '" & FechaSQL(FechaTmp) & "' para el empleado " & dtPersona.Rows(0)("reloj").ToString.Trim & "-" & dtPersona.Rows(0)("nombres").ToString.Trim & " está fuera del rango de fechas bimistral seleccionado, por lo que no será agregado al archivo SUA de Infonavit.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            _x += 1
                            Continue For
                        End If

                    ElseIf Movtmp = "16" Then
                        FechaTmp = dRow("suspension")

                        If Not (FechaTmp >= CDate(fha_ini) And FechaTmp <= CDate(fha_fin)) Then
                            MessageBox.Show("Se detectó que la fecha de suspensión del crédito '" & FechaSQL(FechaTmp) & "' para el empleado " & dtPersona.Rows(0)("reloj").ToString.Trim & "-" & dtPersona.Rows(0)("nombres").ToString.Trim & " está fuera del rango de fechas bimistral seleccionado, por lo que no será agregado al archivo SUA de Infonavit.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            _x += 1
                            Continue For
                        End If

                    Else
                        FechaTmp = dRow("fecha_aplicacion")
                    End If

                    '   ConsultaBitacora(dtPersonaTmp, dtPersonaTmp.Rows(0), FechaTmp)

                    dtPersona.Rows(0)("cod_comp") = dtPersonaTmp.Rows(0)("cod_comp")
                    dtPersona.Rows(0)("cod_planta") = dtPersonaTmp.Rows(0)("cod_planta")

                    'Dim drPlanta() As DataRow = dtPlantas.Select("cod_comp = '" & dtPersona.Rows(0)("cod_comp") & "' and cod_planta = '" & dtPersona.Rows(0)("cod_planta") & "'")

                    'If drPlanta.Count > 0 Then
                    '    If drPlanta(0)("cod_comp").ToString.Trim = "TBS" Then
                    '        dtPersona.Rows(0)("reg_pat") = drPlanta(0)("reg_pat").ToString.Trim
                    '        dtPersona.Rows(0)("grupo_sua") = drPlanta(0)("grupo_sua").ToString.Trim
                    '    Else
                    '        dtPersona.Rows(0)("reg_pat") = dtPersonaTmp.Rows(0)("reg_pat").ToString.Trim
                    '    End If
                    'Else
                    '    dtPersona.Rows(0)("reg_pat") = dtPersonaTmp.Rows(0)("reg_pat").ToString.Trim
                    '  End If

                    dtPersona.Rows(0)("cia_reg_pat") = dtPersonaTmp.Rows(0)("cia_reg_pat").ToString.Trim
                    drNew = dtDatosInfonavit.NewRow

                    drNew("cod_comp") = dtPersona.Rows(0).Item("cod_comp").ToString

                    '--Aos: Valida si no tiene reg patronal, lo tomará de la bitácora
                    'If (dtPersona.Rows(0)("reg_pat").ToString.Trim = "") Then
                    '    Dim _regPat
                    '    Dim drwRegPat As DataRow = Nothing
                    '    Try : drwRegPat = dtBitaCambioSuc.Select("reloj='" & dRow("reloj").ToString.Trim & "' and campo='reg_pat'")(0) : Catch ex As Exception : drwRegPat = Nothing : End Try
                    '    If (Not IsNothing(drwRegPat)) Then _regPat = drwRegPat("ValorNuevo").ToString.Trim

                    '    dtPersona.Rows(0)("reg_pat") = _regPat ' Aos para que tome el reg patronal que viene de bitácora y es el que le corresponde
                    'End If

                    drNew("reg_pat") = dtPersona.Rows(0).Item("cia_reg_pat").ToString.Trim.Replace("-", "")
                    '  drNew("grupo_sua") = dtPersona.Rows(0)("grupo_sua")
                    drNew("grupo_sua") = dtPersona.Rows(0).Item("cod_comp").ToString
                    drNew("imss") = dtPersona.Rows(0)("imss")
                    drNew("dig_ver") = dtPersona.Rows(0)("dig_ver")
                    drNew("nombres") = dtPersona.Rows(0)("nombres")
                    drNew("reloj") = dtPersona.Rows(0)("Reloj")
                    drNew("curp") = dtPersona.Rows(0)("curp")
                    drNew("num_incap") = dRow("infonavit") 'Referencia para el reporte
                    drNew("tipo") = "N" 'Referencia para el reporte
                    drNew("tipo_nombre") = "INFONAVIT" 'Referencia para el reporte

                    Mov = dRow("cod_movimiento")

                    If Mov = "15" Then
                        Fecha = dRow("inicio_cre")
                    ElseIf Mov = "16" Then
                        Fecha = dRow("suspension")
                    Else
                        Fecha = dRow("fecha_aplicacion")
                    End If

                    ' AOS: Validar que la fecha del mov no sea menor a la fecha de alta vacacion que es la que manda al inicio de credito
                    If (Mov = "15") Then
                        Dim alta_vaca As String = ""
                        Try : alta_vaca = FechaSQL(dtPersona.Rows(0)("alta_vacacion")) : Catch ex As Exception : alta_vaca = "" : End Try
                        If (alta_vaca <> "") Then
                            If (Fecha < Date.Parse(alta_vaca)) Then
                                Fecha = Date.Parse(alta_vaca)
                            End If
                        End If

                    End If

                    drNew("fecha_mov") = FechaDMY(Fecha)
                    drNew("tipo_mov") = Mov
                    drNew("tipo_aus") = Mov 'referencia para el reporte
                    drNew("tipo_aus_nombre") = "Movimiento " & Mov 'referencia para el reporte
                    drNew("infonavit") = dRow("infonavit")
                    drNew("tipo_cred") = dRow("tipo_cred")

                    Select Case dRow("tipo_cred").ToString.Trim
                        Case 1
                            'Formato: 00EEDD00
                            Cuota = CInt(dRow("cuota_cred") * 100)
                            Cuota = Cuota.PadLeft(6, "0") & "00"
                        Case 2
                            'Formato: EEEEEDD0
                            Cuota = CInt(dRow("cuota_cred") * 100)
                            Cuota = Cuota.PadLeft(7, "0") & "0"
                        Case 3
                            'Formato: 0EEEDDDD
                            Cuota = CInt(dRow("cuota_cred") * 10000)
                            Cuota = "0" & Cuota.PadLeft(7, "0")
                        Case Else
                            Cuota = "00000000"
                    End Select

                    drNew("cuota") = Double.Parse(IIf(IsDBNull(dRow("cuota_cred")), 0, dRow("cuota_cred")))
                    drNew("cuota_cred") = Cuota
                    drNew("aplica_tasa") = "N"
                    drNew("fecha_ini") = fha_ini
                    drNew("fecha_fin") = fha_fin

                    dtDatosInfonavit.Rows.Add(drNew)

                End If

                _x += 1

            Next

            If dtDatosInfonavit.Rows.Count > 0 Then

                If Not Create_Directory(v_directorio) Then
                    frmTrabajando.Text = ""
                    frmTrabajando.lblAvance.Text = ""
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    MessageBox.Show("La carpeta '" & v_directorio & "' no pudo ser creada.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                _x = 1
                frmTrabajando.Text = "Generando archivos..."

                '*** Infonavit
                For Each dC As DataRow In dtCias.Rows
                    Dim v_compania As String = dC("cod_comp").ToString.Trim
                    drCias = dtDatosInfonavit.Select("cod_comp = '" & v_compania & "'")
                    Application.DoEvents()

                    If drCias.Count > 0 Then

                        For Each dG As DataRow In dtGrupos.Select("cod_comp = '" & v_compania & "'", "grupo_sua")
                            Dim v_grupo_sua As String = dG("grupo_sua").ToString.Trim

                            drGrupo = dtDatosInfonavit.Select("tipo_mov >=15 and tipo_mov <= 20 and cod_comp = '" & v_compania & "' and grupo_sua = '" & v_grupo_sua & "'")
                            Application.DoEvents()

                            If drGrupo.Count > 0 Then

                                Dim NuevoDirectorio As String = Path.Combine(v_directorio & "\" & IIf(v_compania.Trim = "CTE", "CTE", "CT2"), v_grupo_sua & "_Disco_Infonavit_SUA")

                                If Not Directory.Exists(NuevoDirectorio) Then
                                    Directory.CreateDirectory(NuevoDirectorio)
                                End If

                                Dim NuevoArchivo As String = Path.Combine(NuevoDirectorio, Archivo.Replace(Archivo, v_grupo_sua & "_Disco_Infonavit_SUA.txt"))

                                Dim objFS As New FileStream(NuevoArchivo, FileMode.Create, FileAccess.Write)
                                Dim objSW As New StreamWriter(objFS, System.Text.Encoding.Default)
                                Dim EsError As Boolean = True

                                Try

                                    For Each row As DataRow In dtDatosInfonavit.Select("tipo_mov >=15 and tipo_mov <= 20 and cod_comp = '" & v_compania & "' and grupo_sua = '" & v_grupo_sua & "'", "imss")
                                        Application.DoEvents()
                                        objSW.WriteLine(row("reg_pat").ToString.Trim.PadRight(11) & _
                                                    row("imss").ToString.Trim.PadRight(10) & _
                                                    row("dig_ver").ToString.Trim.PadRight(1) & _
                                                    row("infonavit").ToString.Trim.PadRight(10) & _
                                                    row("tipo_mov").ToString.Trim.PadRight(2) & _
                                                    row("fecha_mov").ToString.Trim.PadRight(8) & _
                                                    row("tipo_cred").ToString.Trim.PadRight(1) & _
                                                    row("cuota_cred").ToString.Trim.PadRight(8, "0") & _
                                                    row("aplica_tasa").ToString.Trim.PadRight(1))
                                    Next

                                    EsError = False


                                Catch ex As Exception
                                    frmTrabajando.Text = "Terminado"
                                    ActivoTrabajando = False
                                    frmTrabajando.Close()
                                    frmTrabajando.Dispose()
                                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
                                    MessageBox.Show("La información de infonavit no pudo ser generada correctamente.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try

                                objSW.Close()

                                If EsError Then
                                    Exit Sub
                                End If

                                Application.DoEvents()

                                Dim dtFiltroInfonavit As DataTable = dtDatosInfonavit.Select("cod_comp = '" & v_compania & "' and  grupo_sua = '" & v_grupo_sua & "'").CopyToDataTable
                                If v_compania.Trim = "CTE" Then 'CTE
                                    frmVistaPrevia.LlamarReporte("CTE_Disco de infonavit al SUA", dtFiltroInfonavit, "", Nothing, True, NuevoArchivo.Replace(".txt", ".PDF"))
                                ElseIf v_compania.Trim = "CT2" Then ' CT2
                                    frmVistaPrevia.LlamarReporte("CT2_Disco de infonavit al SUA", dtFiltroInfonavit, "", Nothing, True, NuevoArchivo.Replace(".txt", ".PDF"))
                                End If

                            End If

                        Next

                    End If

                Next



            Else
                frmTrabajando.Text = ""
                frmTrabajando.lblAvance.Text = ""
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                MessageBox.Show("No se encontraron datos para generar el archivo de 'Disco Infonavit SUA'.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            MessageBox.Show("La información de infonavit no pudo ser generada correctamente.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        frmTrabajando.Text = "Terminado"
        ActivoTrabajando = False
        frmTrabajando.Close()
        frmTrabajando.Dispose()

        MessageBox.Show("La información de infonavit se generó correctamente.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    ''' <summary>
    ''' 'Función para crear un directorio
    ''' </summary>
    ''' <remarks></remarks>
    ''' 

    Public Function Create_Directory(ByRef Directory As String) As Boolean

        Dim _done As Boolean = False
        Dim _NameTmp As String = ""
        Static _numCopia As Integer = 0
        Static _DirectorioOriginal As String = ""

        Try

            If Not System.IO.Directory.Exists(Directory) Then
                System.IO.Directory.CreateDirectory(Directory)
                _numCopia = 0
                _DirectorioOriginal = ""
                _done = True
            Else
                If _numCopia = 0 Then _DirectorioOriginal = Directory.Trim
                _numCopia = _numCopia + 1
                _NameTmp = _DirectorioOriginal & IIf(_numCopia > 1, "-Copia(" & _numCopia.ToString & ")", "-Copia")
                Directory = _NameTmp
                _done = Create_Directory(Directory)
            End If

        Catch ex As Exception
            _done = False
        End Try

        Return _done
    End Function

    Public Sub ModificacionesIMSSPromediosVariables(ByVal dtInformacion As DataTable, ByVal directorioBase As String)
        Dim Columnas(20) As DataColumn
        Dim strFileName As String = ""

        ' Configura las columnas para el DataTable dtDatos
        Dim dtDatos = New DataTable
        Columnas(0) = New DataColumn("rfc", System.Type.GetType("System.String"))
        Columnas(1) = New DataColumn("infonavit", System.Type.GetType("System.String"))
        Columnas(2) = New DataColumn("reg_pat", System.Type.GetType("System.String"))
        Columnas(3) = New DataColumn("imss", System.Type.GetType("System.String"))
        Columnas(4) = New DataColumn("dig_ver", System.Type.GetType("System.String"))
        Columnas(5) = New DataColumn("cod_comp", System.Type.GetType("System.String"))
        Columnas(6) = New DataColumn("compañia", System.Type.GetType("System.String"))
        Columnas(7) = New DataColumn("paterno", System.Type.GetType("System.String"))
        Columnas(8) = New DataColumn("materno", System.Type.GetType("System.String"))
        Columnas(9) = New DataColumn("nombre", System.Type.GetType("System.String"))
        Columnas(10) = New DataColumn("integrado_imss", System.Type.GetType("System.String"))
        Columnas(11) = New DataColumn("tipo_trab", System.Type.GetType("System.String"))
        Columnas(12) = New DataColumn("tipo_sdo", System.Type.GetType("System.String"))
        Columnas(13) = New DataColumn("sem_jorred", System.Type.GetType("System.String"))
        Columnas(14) = New DataColumn("modi", System.Type.GetType("System.String"))
        Columnas(15) = New DataColumn("umf", System.Type.GetType("System.String"))
        Columnas(16) = New DataColumn("tipo_mov", System.Type.GetType("System.String"))
        Columnas(17) = New DataColumn("guia", System.Type.GetType("System.String"))
        Columnas(18) = New DataColumn("reloj", System.Type.GetType("System.String"))
        Columnas(19) = New DataColumn("curp", System.Type.GetType("System.String"))
        Columnas(20) = New DataColumn("identifica", System.Type.GetType("System.String"))
        Dim dtTemp As New DataTable
        For x = 0 To UBound(Columnas)
            dtDatos.Columns.Add(Columnas(x))
        Next
        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("Reloj")}

        If dtInformacion.Rows.Count > 0 Then
            dtTemp = sqlExecute("SELECT rfc, infonavit, reg_pat, nombre, guia, uma * 25 AS tope FROM cias WHERE cod_comp = '" & dtInformacion.Rows(0).Item("cod_comp") & "'")

            ' Definir el nombre del archivo
            strFileName = Path.Combine(directorioBase, "Reporte_" & dtInformacion.Rows(0).Item("cod_comp") & ".txt")

            Try
                Using oWrite As System.IO.StreamWriter = New System.IO.StreamWriter(strFileName)
                    For Each dRow As DataRowView In dtInformacion.DefaultView
                        Dim integ As String = "0"
                        Dim integTemp As Double = 0

                        If Not IsDBNull(dRow("integrado_imss")) Then
                            If dRow("integrado_imss") > dtTemp.Rows(0).Item("tope") Then
                                integTemp = dtTemp.Rows(0).Item("tope")
                            Else
                                integTemp = dRow("integrado_imss")
                            End If
                        End If
                        integ = Format(integTemp, "f")

                        dtDatos.Rows.Add(dtTemp.Rows(0).Item("rfc"), dtTemp.Rows(0).Item("infonavit"), dtTemp.Rows(0).Item("reg_pat").ToString.Replace("-", ""), dRow("imss"), dRow("dig_ver"), dRow("cod_comp"), dtTemp.Rows(0).Item("nombre"), dRow("apaterno"), dRow("amaterno"), dRow("nombre"),
                        integ,
                                         "1", "2", "0", FechaDMY(IIf(IsDBNull(dRow("fha_ult_mo")), Nothing, dRow("fha_ult_mo"))), dRow("umf"), "07", dtTemp.Rows(0).Item("guia"), dRow("reloj"), dRow("curp"), "9")

                        oWrite.WriteLine(dtDatos.Rows(dtDatos.Rows.Count - 1).Item("reg_pat").ToString.Trim.PadRight(11) & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("imss").ToString.Trim.PadRight(10) & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("dig_ver").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("paterno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("materno").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("nombre").ToString.Trim.PadRight(27).Replace("Ñ", "N") & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("integrado_imss").ToString.Trim.Replace(".", "").PadLeft(6, "0") & _
                                        Space(6) & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("tipo_trab").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("tipo_sdo").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("sem_jorred").ToString.Trim.PadRight(1) & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("modi").ToString.Trim.PadRight(8) & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("umf").ToString.Trim.PadRight(3) & _
                                        Space(2) & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("tipo_mov").ToString.Trim.PadRight(2) & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("guia").ToString.Trim.PadRight(5) & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("reloj").ToString.Trim.PadRight(10) & _
                                        " " & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("curp").ToString.Trim.PadRight(18) & _
                                        dtDatos.Rows(dtDatos.Rows.Count - 1).Item("identifica").ToString.Trim.PadRight(1))
                    Next
                    oWrite.WriteLine("*************" & Space(43) & dtDatos.Rows.Count.ToString.PadLeft(6, "0"))
                End Using

                MessageBox.Show("La creación del archivo ha finalizado correctamente.")

            Catch ex As Exception
                MessageBox.Show("Se produjo un error al crear el archivo: " & ex.Message)
                Debug.Print(ex.StackTrace)
            End Try

        End If
    End Sub

End Module

