
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Public Class frmCalcVariable
    Dim dtVarNomPro As New DataTable
    Dim dtConceptos As New DataTable
    Dim dtEmplIncap As New DataTable  ' Empleados incap

    Dim avance As String = ""
    Dim cod_comp As String = ""
    Dim anio As String = ""
    Dim bimestre As String = ""
    Dim uma As Double = 0.0
    Dim tope_integrado As Double = 0.0
    Dim fec_proy As Date  ' Fecha de proyección a calcular la variable, es la fecha final del bimestre adelante
    Dim CantSem_Sem As Integer = 0
    Dim CantSem_Cat As Integer = 0
    Dim mes1 As String = ""
    Dim mes2 As String = ""
    Dim fec_ini_sem As String = ""
    Dim fec_fin_sem As String = ""
    Dim fec_ini_cat As String = ""
    Dim fec_fin_cat As String = ""
    Dim finiBim As Date ' Fecha inicio del bimestre
    Dim ffinbim As Date ' Fecha fin del bimestre 
    Dim fBimAdel As Date ' Fecha final del bimestre adelantado
    Dim fApli As Date  ' Fecha de aplicacion de las variables





    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmCalcVariable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaDatosIniciales()
    End Sub

    Private Sub CargaDatosIniciales()
        Try
            '-----2021-10-28 - AOS: Cargar cod_comp dinámicamente
            Dim dtCod_Comp As DataTable
            dtCod_Comp = sqlExecute("select COD_COMP from cias where CIA_DEFAULT=1", "PERSONAL")
            If (Not dtCod_Comp.Columns.Contains("Error") And dtCod_Comp.Rows.Count > 0) Then
                Try : cod_comp = dtCod_Comp.Rows(0).Item("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try
            End If

            Dim dtAnioPer As DataTable = sqlExecute("select * from variable_status_proc", "nomina")
            If (Not dtAnioPer.Columns.Contains("Error") And dtAnioPer.Rows.Count > 0) Then
                Try : anio = dtAnioPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio = "" : End Try
                Try : bimestre = dtAnioPer.Rows(0).Item("bimestre").ToString.Trim : Catch ex As Exception : bimestre = "" : End Try
                Try : avance = dtAnioPer.Rows(0).Item("avance").ToString.Trim : Catch ex As Exception : avance = "" : End Try

                txtAnio.Text = anio
                txtBimestre.Text = bimestre

            Else
                MessageBox.Show("No hay un bimestre de variable a inicializar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If avance = "4" Then
                MessageBox.Show("El bimestre ya fue aplicado a todos los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If


        Catch ex As Exception

            MessageBox.Show("No se pudo inicializar el proceso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

        End Try
    End Sub

    Private Sub btnCalcVariable_Click(sender As Object, e As EventArgs) Handles btnCalcVariable.Click
        Try
            CalcularPromVar(txtAnio.Text, txtBimestre.Text)
        Catch ex As Exception

        End Try
    End Sub

    Public Function CalcularPromVar(ByRef anio As String, bimestre As String) As Integer
        Try
            '---Mostrar Progress
            Dim i As Integer = -1
            frmTrabajando.Text = "Calculando variables"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Calculando variable"
            ActivoTrabajando = True
            frmTrabajando.Show()
            Application.DoEvents()

            If (anio <> "" And bimestre <> "") Then
                Dim Q1 As String = ""
                Q1 = "select * from variables_nom_pro order by reloj asc"
                dtVarNomPro = sqlExecute(Q1, "NOMINA")

                If ((dtVarNomPro.Columns.Contains("Error")) Or (Not dtVarNomPro.Columns.Contains("Error") And dtVarNomPro.Rows.Count = 0)) Then
                    MessageBox.Show("No existen empleados para calcular su variable en este bimestre", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Function
                Else

                    sqlExecute("truncate table variables_mov_pro", "NOMINA")  '--Limpiar tabla de movim
                    dtConceptos = sqlExecute("select * from conceptos where ISNULL(aplica_variable,0)=1 and CONCEPTO not in('TOTVAR')", "NOMINA")

                    '-- Calcular variables globales

                    '- Obtener valor de CIAS que se usaran de forma general
                    Dim dtValCias As DataTable = sqlExecute("SELECT * from cias where cod_comp='" & cod_comp & "'", "PERSONAL")
                    If (Not dtValCias.Columns.Contains("Error") And dtValCias.Rows.Count > 0) Then
                        Try : uma = dtValCias.Rows(0).Item("uma") : Catch ex As Exception : uma = 0.0 : End Try
                        tope_integrado = Math.Round(uma * 25, 2)
                    End If

                    '--- Obtener el total de semanas tanto para cat como semanales
                    CantSem_Cat = 0
                    CantSem_Sem = 0
                    Select Case bimestre
                        Case "01"
                            mes1 = "01"
                            mes2 = "02"
                        Case "02"
                            mes1 = "03"
                            mes2 = "04"
                        Case "03"
                            mes1 = "05"
                            mes2 = "06"
                        Case "04"
                            mes1 = "07"
                            mes2 = "08"
                        Case "05"
                            mes1 = "09"
                            mes2 = "10"
                        Case "06"
                            mes1 = "11"
                            mes2 = "12"
                    End Select
                    Dim dtTotSem_Sem As DataTable = sqlExecute("select count(periodo) as 'totsem' from periodos where ano='" & anio & "' and acumula=1 and isnull(PERIODO_ESPECIAL,0)=0 and num_mes in('" & mes1 & "','" & mes2 & "') ", "TA")
                    Dim dtTotSem_Cat As DataTable = sqlExecute("select count(periodo) as 'totsem' from periodos_catorcenal where ano='" & anio & "' and acumula=1 and isnull(PERIODO_ESPECIAL,0)=0 and num_mes in('" & mes1 & "','" & mes2 & "') ", "TA")

                    '   Try : CantSem_Sem = dtTotSem_Sem.Rows.Count : Catch ex As Exception : CantSem_Sem = 0 : End Try
                    '    Try : CantSem_Cat = dtTotSem_Cat.Rows.Count : Catch ex As Exception : CantSem_Cat = 0 : End Try

                    Try : CantSem_Sem = Integer.Parse(dtTotSem_Sem.Rows(0).Item("totsem")) : Catch ex As Exception : CantSem_Sem = 0 : End Try
                    Try : CantSem_Cat = Integer.Parse(dtTotSem_Cat.Rows(0).Item("totsem")) : Catch ex As Exception : CantSem_Cat = 0 : End Try



                    '--- Obtener la fecha de proyección del bimestre adelante
                    fec_proy = GetFecProyVar(anio, bimestre)

                    '--- Obtener fecha inicio y fin del bimestre tanto para semanales como catorcenales
                    Dim dtFecIniSem As DataTable = sqlExecute("select top 1 fecha_ini  from periodos where ano='" & anio & "' and acumula=1 and isnull(PERIODO_ESPECIAL,0)=0 and num_mes in('" & mes1 & "','" & mes2 & "')  order by periodo asc", "TA")
                    Dim dtFecFinSem As DataTable = sqlExecute("select top 1 FECHA_FIN  from periodos where ano='" & anio & "' and acumula=1 and isnull(PERIODO_ESPECIAL,0)=0 and num_mes in('" & mes1 & "','" & mes2 & "')  order by periodo desc", "TA")
                    Dim dtFecIniCat As DataTable = sqlExecute("select top 1 fecha_ini  from periodos_catorcenal where ano='" & anio & "' and acumula=1 and isnull(PERIODO_ESPECIAL,0)=0 and num_mes in('" & mes1 & "','" & mes2 & "')  order by periodo asc", "TA")
                    Dim dtFecFinCat As DataTable = sqlExecute("select top 1 FECHA_FIN  from periodos_catorcenal where ano='" & anio & "' and acumula=1 and isnull(PERIODO_ESPECIAL,0)=0 and num_mes in('" & mes1 & "','" & mes2 & "')  order by periodo desc", "TA")

                    If (Not dtFecIniSem.Columns.Contains("Error") And dtFecIniSem.Rows.Count > 0) Then
                        Try : fec_ini_sem = FechaSQL(dtFecIniSem.Rows(0).Item("fecha_ini").ToString.Trim) : Catch ex As Exception : fec_ini_sem = "" : End Try
                    End If

                    If (Not dtFecFinSem.Columns.Contains("Error") And dtFecFinSem.Rows.Count > 0) Then
                        Try : fec_fin_sem = FechaSQL(dtFecFinSem.Rows(0).Item("FECHA_FIN").ToString.Trim) : Catch ex As Exception : fec_fin_sem = "" : End Try
                    End If

                    If (Not dtFecIniCat.Columns.Contains("Error") And dtFecIniCat.Rows.Count > 0) Then
                        Try : fec_ini_cat = FechaSQL(dtFecIniCat.Rows(0).Item("fecha_ini").ToString.Trim) : Catch ex As Exception : fec_ini_cat = "" : End Try
                    End If

                    If (Not dtFecFinCat.Columns.Contains("Error") And dtFecFinCat.Rows.Count > 0) Then
                        Try : fec_fin_cat = FechaSQL(dtFecFinCat.Rows(0).Item("FECHA_FIN").ToString.Trim) : Catch ex As Exception : fec_fin_cat = "" : End Try
                    End If

                    '--- Obtener la fecha fin del bimestre adelantado
                    Dim anio_bim_adel As String = ""
                    Dim bim_adel As String = ""
                    Dim fec_Ini_Bim As String = ""
                    Dim fec_fin_bim As String = ""
                    Dim fec_apli As String = "" ' Fecha de aplicacion de la variable
                    Dim fec_bim_adel As String = ""

                    Select Case bimestre
                        Case "01"
                            bim_adel = "02"
                            fec_apli = anio & "-" & "03-01"
                            fec_bim_adel = anio & "-" & "04-30"
                            fec_Ini_Bim = anio & "-" & "01-01"
                            fec_fin_bim = anio & "-" & "02-28"
                        Case "02"
                            bim_adel = "03"
                            fec_apli = anio & "-" & "05-01"
                            fec_bim_adel = anio & "-" & "06-30"
                            fec_Ini_Bim = anio & "-" & "03-01"
                            fec_fin_bim = anio & "-" & "04-30"
                        Case "03"
                            bim_adel = "04"
                            fec_apli = anio & "-" & "07-01"
                            fec_bim_adel = anio & "-" & "08-31"
                            fec_Ini_Bim = anio & "-" & "05-01"
                            fec_fin_bim = anio & "-" & "06-30"
                        Case "04"
                            bim_adel = "05"
                            fec_apli = anio & "-" & "09-01"
                            fec_bim_adel = anio & "-" & "10-31"
                            fec_Ini_Bim = anio & "-" & "07-01"
                            fec_fin_bim = anio & "-" & "08-31"
                        Case "05"
                            bim_adel = "06"
                            fec_apli = anio & "-" & "11-01"
                            fec_bim_adel = anio & "-" & "12-31"
                            fec_Ini_Bim = anio & "-" & "09-01"
                            fec_fin_bim = anio & "-" & "10-31"
                        Case "06"
                            anio_bim_adel = (Convert.ToInt32(anio) + 1).ToString.Trim
                            bim_adel = "01"
                            fec_apli = anio_bim_adel & "-" & "01-01"
                            fec_bim_adel = anio_bim_adel & "-" & "02-28"
                            fec_Ini_Bim = anio & "-" & "11-01"
                            fec_fin_bim = anio & "-" & "12-31"

                    End Select

                    finiBim = Date.Parse(fec_Ini_Bim) ' Fecha inicial del bim actual
                    ffinbim = Date.Parse(fec_fin_bim)  ' Fecha fin del bimestre actual
                    fApli = Date.Parse(fec_apli)  ' Fecha de aplicacion de las variables, ejemplo si estamos en el 6to bim del 2020, la fec de apli es el 01/01/2021
                    fBimAdel = Date.Parse(fec_bim_adel) ' Fecha fin del bimestre adelante

                    '------Conocer que empleados estan incapacitados a la fecha de aplicación, ejemplo, si estamos calculando el 6to Bim del 2020, seria saber quien está incap al 01/01/2021
                    Dim QIncap As String = "select * from ausentismo where FECHA='" & FechaSQL(fApli) & "' and TIPO_AUS in('ING','INI','ISS')"
                    dtEmplIncap = sqlExecute(QIncap, "TA")

                    '--Mostrar progress
                    frmTrabajando.Avance.IsRunning = False
                    frmTrabajando.lblAvance.Text = "Procesando datos"
                    Application.DoEvents()
                    frmTrabajando.Avance.Maximum = dtVarNomPro.Rows.Count


                    For Each drVarPro As DataRow In dtVarNomPro.Rows    '---Calcular a cada empleado

                        '-Variables globales que tienen que inicializarse al calcular cada nomina

                        '----------------Vars por cada empleado a inicializarse por calculo
                        Dim reloj As String = ""
                        Dim tipo_periodo As String = ""
                        Dim sactual As Double = 0.0
                        Dim integrado As Double = 0.0
                        Dim alta As String = ""
                        Dim dias_trab As Double = 0.0
                        Dim difDias As Double = 0.0
                        Dim dias_aus As Double = 0.0
                        Dim tot_dias As Double = 0.0
                        Dim nvo_antig As Double = 0.0
                        Dim difDiasAntig As Double = 0.0
                        Dim cod_tipo As String = ""
                        Dim nvo_fi As Double = 0.0
                        Dim nvo_provar As Double = 0.0
                        Dim nvo_integrado As Double = 0.0
                        Dim aplica As Integer = 0
                        Dim comentario As String = ""
                        Dim totalAcum As Double = 0.0
                        Dim newIngreso As Boolean = False
                        Dim incapacitado As Boolean = False
                        Dim incapPrimerDia As Boolean = False

                        '--Dar el valor para cada var
                        Try : reloj = drVarPro("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try

                        '----Mostrar Progress - avance
                        i += 1
                        frmTrabajando.Avance.Value = i
                        frmTrabajando.lblAvance.Text = reloj
                        Application.DoEvents()
                        '----Ends Avance

                        Try : tipo_periodo = drVarPro("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_periodo = "" : End Try
                        Try : sactual = Double.Parse(drVarPro("sactual")) : Catch ex As Exception : sactual = 0.0 : End Try
                        Try : integrado = Double.Parse(drVarPro("integrado")) : Catch ex As Exception : integrado = 0.0 : End Try
                        Try : alta = FechaSQL(drVarPro("alta").ToString.Trim) : Catch ex As Exception : alta = "" : End Try
                        Try : cod_tipo = drVarPro("cod_tipo").ToString.Trim : Catch ex As Exception : cod_tipo = "" : End Try


                        '********************************* DIAS_TRAB
                        '***** DUDA -- PEND :  Como sacan los dias trab para los empleados que su alta es entre el periodo ????
                        If (tipo_periodo = "S") Then dias_trab = CantSem_Sem * 7
                        If (tipo_periodo = "C") Then dias_trab = CantSem_Cat * 14

                        '---Si es alta entre el periodo del bimestre, los dias_trab serian menos
                        If (Date.Parse(alta) > finiBim) Then
                            difDias = DateDiff(DateInterval.Day, Date.Parse(alta), ffinbim)  '- Obtener total dif de dias de la fecha de alta  a la fecha fin del bimestre actual
                            dias_trab = ConversionDiasSemana(difDias) ' Obtener el total de semanas trabajadas desde su alta a la fecha fin del bim para tener el total de días
                            If dias_trab <= 0 Then newIngreso = True
                        End If

                        sqlExecute("update variables_nom_pro set dias_trab=" & dias_trab & " where ano='" & anio & "' and bimestre='" & bimestre & "' and reloj='" & reloj & "'", "NOMINA")

                        '********************************* DIAS_AUS
                        Dim QAus As String = ""
                        Dim dtDiasAus As New DataTable
                        ' select count(reloj) as 'tot_aus' from ausentismo where TIPO_AUS IN ('FI') and reloj='00008' and FECHA between '2020-08-10' and '2020-08-21'
                        If (tipo_periodo = "S") Then
                            QAus = "select count(reloj) as 'tot_aus' from ausentismo where TIPO_AUS IN ('FI','PSG','JUS','ING','SUS','ISS') and reloj='" & reloj & "' and FECHA between '" & fec_ini_sem & "' and '" & fec_fin_sem & "'"
                            dtDiasAus = sqlExecute(QAus, "TA")
                        End If

                        If (tipo_periodo = "C") Then
                            QAus = "select count(reloj) as 'tot_aus' from ausentismo where TIPO_AUS IN ('FI','PSG','JUS','ING','SUS','ISS') and reloj='" & reloj & "' and FECHA between '" & fec_ini_cat & "' and '" & fec_fin_cat & "'"
                            dtDiasAus = sqlExecute(QAus, "TA")
                        End If

                        If (Not dtDiasAus.Columns.Contains("Error") And dtDiasAus.Rows.Count > 0) Then
                            Try : dias_aus = Double.Parse(dtDiasAus.Rows(0).Item("tot_aus")) : Catch ex As Exception : dias_aus = 0.0 : End Try
                        End If

                        If (dias_aus >= 15) Then incapacitado = True

                        sqlExecute("update variables_nom_pro set dias_aus=" & dias_aus & " where ano='" & anio & "' and bimestre='" & bimestre & "' and reloj='" & reloj & "'", "NOMINA")

                        '***********************************TOT_DIAS
                        tot_dias = dias_trab - dias_aus

                        If (tot_dias <= 0) Then tot_dias = 0
                        sqlExecute("update variables_nom_pro set tot_dias=" & tot_dias & " where ano='" & anio & "' and bimestre='" & bimestre & "' and reloj='" & reloj & "'", "NOMINA")

                        '**********************************nvo_antig (Nuevo antiguedad)
                        '--Calc la nueva antig en años al próximo bimestre adelantado
                        Dim x As String = reloj
                        Dim dtNvoAntig As DataTable = sqlExecute("select DATEDIFF(dd, '" & FechaSQL(Date.Parse(alta)) & "', '" & FechaSQL(fBimAdel) & "')+1 as difDiasAntig")
                        Dim anios As Double = 0.0
                        If (Not dtNvoAntig.Columns.Contains("Error") And dtNvoAntig.Rows.Count > 0) Then
                            Try : difDiasAntig = Double.Parse(dtNvoAntig.Rows(0).Item("difDiasAntig")) : Catch ex As Exception : difDiasAntig = 0.0 : End Try
                        End If
                        anios = difDiasAntig / 365
                        Dim _aniosEnt As Integer = CInt(anios)
                        If (_aniosEnt < anios) Then nvo_antig = _aniosEnt + 1 Else nvo_antig = _aniosEnt

                        sqlExecute("update variables_nom_pro set nvo_antig=" & nvo_antig & " where ano='" & anio & "' and bimestre='" & bimestre & "' and reloj='" & reloj & "'", "NOMINA")


                        '********************************** Nuevo factor de integracion (nvo_fi)
                        '   select * from factores where cod_comp='WME' and COD_TIPO='A' and ANOS=2
                        Dim dtNvoFi As DataTable = sqlExecute("select * from factores where cod_comp='" & cod_comp & "' and COD_TIPO='" & cod_tipo & "' and ANOS=" & nvo_antig & "", "PERSONAL")
                        If (Not dtNvoFi.Columns.Contains("Error") And dtNvoFi.Rows.Count > 0) Then
                            Try : nvo_fi = Double.Parse(dtNvoFi.Rows(0).Item("FACTOR_INT")) : Catch ex As Exception : nvo_fi = 0.0 : End Try
                        End If

                        sqlExecute("update variables_nom_pro set nvo_fi=" & nvo_fi & " where ano='" & anio & "' and bimestre='" & bimestre & "' and reloj='" & reloj & "'", "NOMINA")

                        '*****-----*****************************ACUMULAR POR CADA CONCEPTO E INSERTAR A variables_mov_pro
                        For Each rwConc As DataRow In dtConceptos.Rows
                            Dim concepto As String = "", nombre_tabla_periodo As String = "", monto As Double = 0.0
                            Dim bondesExe As Double = 0.0, bonasiExe As Double = 0.0
                            Dim dtAcumTotal As New DataTable
                            If (tipo_periodo = "C") Then nombre_tabla_periodo = "TA.dbo.periodos_catorcenal"
                            If (tipo_periodo = "S") Then nombre_tabla_periodo = "TA.dbo.periodos"


                            concepto = rwConc("CONCEPTO").ToString.Trim
                            Dim QAcum As String = "select ISNULL(SUM(convert(float,monto)),0) AS 'TotalAcum' from movimientos where RELOJ='" & reloj & "' and ANO='" & anio & "' and concepto='" & concepto & "'  and periodo in " & _
                                "(select PERIODO from " & nombre_tabla_periodo & " where isnull(PERIODO_ESPECIAL,0)=0 and num_mes in ('" & mes1 & "','" & mes2 & "') and ano='" & anio & "' and acumula=1)"
                            dtAcumTotal = sqlExecute(QAcum, "NOMINA")

                            If (Not dtAcumTotal.Columns.Contains("Error") And dtAcumTotal.Rows.Count > 0) Then

                                Try : monto = Double.Parse(dtAcumTotal.Rows(0).Item("TotalAcum")) : Catch ex As Exception : monto = 0.0 : End Try

                                If (concepto = "BONDES") Then ' Bono de despensa
                                    bondesExe = uma * tot_dias * 0.4
                                    monto = monto - bondesExe
                                End If

                                If (concepto = "BONASI" Or concepto = "BONPUN") Then ' Bono de asistencia o de puntualidad
                                    bonasiExe = integrado * tot_dias * 0.1
                                    monto = monto - bonasiExe

                                End If

                            End If
                            If monto <= 0 Then monto = 0
                            '--Insertar cada uno de los movimientos
                            If (monto <> 0 And concepto <> "") Then
                                sqlExecute("insert into variables_mov_pro values ('" & anio & "','" & bimestre & "','" & reloj & "','" & tipo_periodo & "','" & concepto & "'," & monto & ",500,1)", "NOMINA")
                                totalAcum += monto
                            End If

                        Next
                        '***************************************ENDS ACUMULAR
                        '--- Guardamos el total acumulado (TOTVAR)
                        sqlExecute("insert into variables_mov_pro values ('" & anio & "','" & bimestre & "','" & reloj & "','" & tipo_periodo & "','TOTVAR'," & totalAcum & ",500,1)", "NOMINA")


                        '********************************** Nuevo PROM VARIABLE  (variables_nom_pro.nvo_provar)
                        nvo_provar = Math.Round(totalAcum / tot_dias, 2)
                        sqlExecute("update variables_nom_pro set nvo_provar=" & nvo_provar & " where ano='" & anio & "' and bimestre='" & bimestre & "' and reloj='" & reloj & "'", "NOMINA")

                        '********************************** Nuevo Integrado (nvo_integrado)
                        Dim topeInt As Double = uma * 25
                        nvo_integrado = Math.Round((sactual * nvo_fi) + nvo_provar, 2)
                        If (nvo_integrado >= topeInt) Then nvo_integrado = topeInt
                        sqlExecute("update variables_nom_pro set nvo_integrado=" & nvo_integrado & " where ano='" & anio & "' and bimestre='" & bimestre & "' and reloj='" & reloj & "'", "NOMINA")

                        '*********************************** DETERMINAR SI APLICA O NO PARA ENVIAR COMENTARIO EN CASO DE QUE NO APLIQUE
                        '  If (reloj = "00362") Then
                        If (dtEmplIncap.Select("reloj='" & reloj & "'").Count > 0) Then incapPrimerDia = True
                        '   End If


                        If (incapPrimerDia) Then  ' incapacitados en el primer dia en que aplica la variable, ejemplo, si estamos en el 6to bim del 2020, esta incap el 01/01/2021
                            aplica = 0
                            comentario = "No Enviar, incap.Primer.Día"
                            GoTo SigEmpl
                        End If

                        If ((nvo_integrado = integrado) And nvo_integrado = topeInt) Then
                            aplica = 0
                            comentario = "No Enviar, topado anterior"
                            GoTo SigEmpl
                        End If

                        '    Dim difIntegrados As Double = 0.0
                        '    difIntegrados = nvo_integrado

                        If (nvo_integrado = integrado) Then
                            aplica = 0
                            comentario = "No Enviar, mismo integrado anterior"
                            GoTo SigEmpl
                        End If

                        If (newIngreso) Then
                            aplica = 0
                            comentario = "No Enviar, ingresó en la última semana"
                            GoTo SigEmpl
                        End If

                        If (incapacitado) Then
                            aplica = 0
                            comentario = "No Enviar, estuvo incapacitado por 15 días o mas"
                            GoTo SigEmpl
                        End If



                        If (nvo_integrado < integrado) Then
                            aplica = 1
                            comentario = "Nuevo integrado es menor al anterior"
                            GoTo SigEmpl
                        End If


                        aplica = 1
                        comentario = ""

SigEmpl:
                        sqlExecute("update variables_nom_pro set aplica=" & aplica & ",comentario='" & comentario & "' where ano='" & anio & "' and bimestre='" & bimestre & "' and reloj='" & reloj & "'", "NOMINA")

                    Next ' Final de que evalua a cada empleado


                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()

                    '---Mensaje con el resúmen
                    If i < 0 Then
                        'No hubo archivos para analizar
                        MessageBox.Show("No se calculó ningun registro", "Cálculo de nómina", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Me.Close()
                    Else
                        MessageBox.Show("Proceso concluído satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If


                End If


            Else

                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                MessageBox.Show("No hay un bimestre inicializado a calcular", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Function
            End If



        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function GetFecProyVar(_ano, _bim) As Date
        Dim Res As Date = Nothing
        Try
            If (_ano <> "" And _bim <> "") Then
                Dim anioSig As String = "", fecha As String = "", dia_bis As String = ""
                anioSig = (Integer.Parse(_ano) + 1).ToString.Trim
                Dim EsBisiesto As Integer = anioSig Mod 4
                If (EsBisiesto = 1) Then dia_bis = "28" Else dia_bis = "29"
                Select Case _bim
                    Case "01"
                        fecha = _ano & "-04-30"
                    Case "02"
                        fecha = _ano & "-06-30"
                    Case "03"
                        fecha = _ano & "-08-31"
                    Case "04"
                        fecha = _ano & "-10-31"
                    Case "05"
                        fecha = _ano & "-12-31"
                    Case "06"
                        fecha = anioSig & "-02-" & dia_bis
                End Select
                Res = Date.Parse(fecha)
            End If

            Return Res
        Catch ex As Exception
            Return Res
        End Try
    End Function

    Private Function ConversionDiasSemana(ByVal _DifDiasTrab) As Double
        Dim x As Double = 0.0
        Try
            If (_DifDiasTrab >= 0 And _DifDiasTrab <= 6) Then
                x = 0.0
                Return x
            End If

            If (_DifDiasTrab >= 7 And _DifDiasTrab <= 13) Then
                x = 7.0
                Return x
            End If

            If (_DifDiasTrab >= 14 And _DifDiasTrab <= 20) Then
                x = 14.0
                Return x
            End If

            If (_DifDiasTrab >= 21 And _DifDiasTrab <= 27) Then
                x = 21.0
                Return x
            End If

            If (_DifDiasTrab >= 28 And _DifDiasTrab <= 34) Then
                x = 28.0
                Return x
            End If

            If (_DifDiasTrab >= 35 And _DifDiasTrab <= 41) Then
                x = 35.0
                Return x
            End If

            If (_DifDiasTrab >= 42 And _DifDiasTrab <= 48) Then
                x = 42.0
                Return x
            End If

            If (_DifDiasTrab >= 49 And _DifDiasTrab <= 55) Then
                x = 49.0
                Return x
            End If

            If (_DifDiasTrab >= 56 And _DifDiasTrab <= 62) Then
                x = 56.0
                Return x
            End If

            If (_DifDiasTrab >= 63 And _DifDiasTrab <= 69) Then
                x = 63.0
                Return x
            End If

            If (_DifDiasTrab >= 70 And _DifDiasTrab <= 76) Then
                x = 70.0
                Return x
            End If

            If (_DifDiasTrab >= 77 And _DifDiasTrab <= 83) Then
                x = 77.0
                Return x
            End If


            Return x
        Catch ex As Exception
            Return x
        End Try
    End Function

    Public Sub GenRepVar_PRO(ByRef anio As String, periodo As String)
        Try
            Dim dtResultadoVariable As New DataTable
            Dim dtDatos As New DataTable
            Dim NombreReporte As String = "Variables imss detalle"

            Dim Q As String = "EXEC ReporteadorVariableTipoBimestre_PRO @Cia = '', @ano = '" & anio & "', @periodo = '" & periodo & "',@Nivel = '5', @reloj = ''"

            dtResultadoVariable = sqlExecute(Q, "NOMINA")
            If (Not dtResultadoVariable.Columns.Contains("Error") And dtResultadoVariable.Rows.Count > 0) Then
                dtResultadoVariable.Columns.Add("periodos")
                VariablesExcel_Pro(dtDatos, dtResultadoVariable, False, True, "Variables imss detalle", False, "", anio, periodo) ' Genera el excel con el detalle de las variables 
            Else
                MessageBox.Show("No hay información para generar el reporte de variables con el detalle", "Generación de variables imss detalle", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub


End Class