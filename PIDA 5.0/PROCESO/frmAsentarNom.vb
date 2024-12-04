Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmAsentarNom

    Dim anio As String = ""
    Dim per As String = ""
    Dim fIniPerSem As String = ""
    Dim fFinPerSem As String = ""
    Dim _reloj_consulta As String = ""
    Dim Editar As Boolean
    Dim asentado As String = ""
    Dim TotalPeriodos As Integer = 0
    Dim anio_cat As String = ""
    Dim per_cat As String = "'"
    Dim dtNomina_pro As New DataTable
    Dim dtMovimientos_pro As New DataTable
    Dim dtUltPerAportFAH As New DataTable
    Dim UltPerAporFah As Boolean = False
    Dim dtEmplSaldosFah As DataTable

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmAsentarNom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '---Obtener anio y periodo procesado
            Dim dtAnioPer As DataTable = sqlExecute("select * from status_proceso", "NOMINA")

            If (dtAnioPer.Columns.Contains("Error") Or dtAnioPer.Rows.Count = 0) Then
                MessageBox.Show("No existe periodo abierto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If

            If (Not dtAnioPer.Columns.Contains("Error") And dtAnioPer.Rows.Count > 0) Then
                Try : anio = dtAnioPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio = "" : End Try
                Try : per = dtAnioPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per = "" : End Try
            End If
            Dim anioPer As String = anio & per

            '----Validar que el periodo no esté asentado ya


            Dim dtFechasPer As DataTable = sqlExecute("SELECT * from periodos where ano+PERIODO='" & anioPer & "'", "TA")
            If (Not dtFechasPer.Columns.Contains("Error") And dtFechasPer.Rows.Count > 0) Then
                Try : fIniPerSem = FechaSQL(dtFechasPer.Rows(0).Item("FECHA_INI").ToString.Trim) : Catch ex As Exception : fIniPerSem = "" : End Try
                Try : fFinPerSem = FechaSQL(dtFechasPer.Rows(0).Item("FECHA_FIN").ToString.Trim) : Catch ex As Exception : fFinPerSem = "" : End Try
                Try : asentado = dtFechasPer.Rows(0).Item("asentado").ToString.Trim : Catch ex As Exception : asentado = "" : End Try
            End If

            lblAnioPer.Text = anio & " - " & per & " - Del " & fIniPerSem & " al " & fFinPerSem

            '-----Validar si es el últimio periodo a aportar para la liq del fondo de ahorro
            Dim QBuscaCicloFah As String = "select * from config_per_liqfah where anio_liq='" & anio & "'"
            dtUltPerAportFAH = sqlExecute(QBuscaCicloFah, "NOMINA")
            If (Not dtUltPerAportFAH.Columns.Contains("Error") And dtUltPerAportFAH.Rows.Count > 0) Then
                Dim perFin As String = ""
                Try : perFin = dtUltPerAportFAH.Rows(0).Item("per_fin").ToString.Trim : Catch ex As Exception : perFin = "" : End Try
                If (per.Trim = perFin.Trim) Then UltPerAporFah = True
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnAsentarNom_Click(sender As Object, e As EventArgs) Handles btnAsentarNom.Click
        Try

            If (asentado = "1") Then
                MessageBox.Show("El periodo ya encuentra asentado/cerrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If

            If MessageBox.Show("¿Está seguro de asentar/cerrar el periodo de  nómina actual abierto?", "Asentar Periodo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("¿Está realmente seguro? Una vez asentado ya no podrá realizar ajustes al mismo", "Asentar Periodo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Me.Close()
                    Me.Dispose()
                    Exit Sub
                End If
            Else
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If

            ''----AOS: 2022-03-14 : Validar a cada uno de los empleados que la suma del totalper y totalded coincida con la suma de cada uno de sus conceptos
            Dim dtDistinctRj As DataTable = sqlExecute("select distinct reloj from movimientos_pro order by reloj asc", "NOMINA")
            Dim dtMovisPro As DataTable = sqlExecute("select * from movimientos_pro", "NOMINA")
            Dim mensajeNoCuadra As String = ""

            If (Not dtDistinctRj.Columns.Contains("Error") And dtDistinctRj.Rows.Count > 0) Then

                '---AOS 2022-08-18: Hacer un respaldo de las tablas mtro_ded y saldos_ca donde se guarda el detalle de los saldos que se actualizan
                sqlExecute("drop table MTRO_DED_resp", "NOMINA")
                sqlExecute("drop table saldos_ca_resp", "NOMINA")
                sqlExecute("select * into MTRO_DED_resp from MTRO_DED", "NOMINA")
                sqlExecute("select * into saldos_ca_resp from saldos_ca", "NOMINA")

                '---Mostrar Progress
                Dim y As Integer = -1
                frmTrabajando.Text = "Validando totales por empleado"
                frmTrabajando.Avance.IsRunning = True
                frmTrabajando.lblAvance.Text = "Validando totales por empleado"
                ActivoTrabajando = True
                frmTrabajando.Show()
                Application.DoEvents()



                '--Mostrar progress
                frmTrabajando.Avance.IsRunning = False
                frmTrabajando.lblAvance.Text = "Validando datos"
                Application.DoEvents()
                frmTrabajando.Avance.Maximum = dtDistinctRj.Rows.Count

                For Each drM As DataRow In dtDistinctRj.Rows
                    Dim rj As String = "", totalpercep As Double = 0.0, totalded As Double = 0.0, totper As Double = 0.0, totded As Double = 0.0
                    Try : rj = drM("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try

                    '----Mostrar Progress - avance
                    y += 1
                    frmTrabajando.Avance.Value = y
                    frmTrabajando.lblAvance.Text = rj
                    Application.DoEvents()
                    '----Ends Avance

                    Dim QtotPer As String = "select ISNULL(SUM(convert(float,m.monto)),0) AS 'totalpercep' from movimientos_pro m left outer join conceptos c  on m.concepto=c.CONCEPTO " & _
                    "where m.reloj='" & rj & "' and c.COD_NATURALEZA='P' and m.CONCEPTO not in ('BONDES','SUBPAG')"

                    Dim QTotDed As String = "select ISNULL(SUM(convert(float,m.monto)),0) AS 'totalded' from movimientos_pro m left outer join conceptos c on m.concepto=c.CONCEPTO " & _
                        "where m.reloj='" & rj & "' and c.COD_NATURALEZA='D'"

                    Dim dtTotPer As DataTable = sqlExecute(QtotPer, "NOMINA")
                    Dim dtTotDed As DataTable = sqlExecute(QTotDed, "NOMINA")

                    If (Not dtTotPer.Columns.Contains("Error") And dtTotPer.Rows.Count > 0) Then
                        Try : totalpercep = dtTotPer.Rows(0).Item("totalpercep") : Catch ex As Exception : totalpercep = 0.0 : End Try
                    End If

                    If (Not dtTotDed.Columns.Contains("Error") And dtTotDed.Rows.Count > 0) Then
                        Try : totalded = dtTotDed.Rows(0).Item("totalded") : Catch ex As Exception : totalded = 0.0 : End Try
                    End If

                    '---Validar vs lo que tiene en TOTPER y TOTDED
                    Dim drwMovs As DataRow = Nothing, drMovsDed As DataRow = Nothing
                    Try : drwMovs = dtMovisPro.Select("reloj ='" & rj & "' and concepto in('TOTPER')")(0) : Catch ex As Exception : drwMovs = Nothing : End Try
                    If (Not IsNothing(drwMovs)) Then
                        Try : totper = drwMovs("monto") : Catch ex As Exception : totper = 0.0 : End Try
                    End If

                    Try : drMovsDed = dtMovisPro.Select("reloj ='" & rj & "' and concepto in('TOTDED')")(0) : Catch ex As Exception : drMovsDed = Nothing : End Try
                    If (Not IsNothing(drMovsDed)) Then
                        Try : totded = drMovsDed("monto") : Catch ex As Exception : totded = 0.0 : End Try
                    End If

                    totalpercep = Math.Round(totalpercep, 2)
                    totalded = Math.Round(totalded, 2)

                    If (totalpercep <> totper) Then
                        mensajeNoCuadra &= vbCrLf & "El reloj " & rj & " no cuadra el total de percep. la suma es " & totalpercep & " y lo calculado es " & totper & ". Favor de verificar y corregir"
                    End If

                    If (totalded <> totded) Then
                        mensajeNoCuadra &= vbCrLf & "El reloj " & rj & " no cuadra el total de deduc. la suma es " & totalded & " y lo calculado es " & totded & ". Favor de verificar y corregir"
                    End If

                Next

                If (mensajeNoCuadra <> "") Then
                    MessageBox.Show("Hubo diferencias en los totales de ciertos empleados, los cuales son: " & vbCrLf & mensajeNoCuadra, "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                    Exit Sub
                Else
                    MessageBox.Show("No se encontraron diferencias en los totales por empleado, se procederá a ralizar el cierre de la nómina", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                End If
            End If

            '---Mostrar Progress
            Dim i As Integer = -1
            frmTrabajando.Text = "Asentar nómina"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Asentando nómina"
            ActivoTrabajando = True
            frmTrabajando.Show()
            Application.DoEvents()

            '---***************** actualizar  periodos que ya fue cerrado en la tabla PERIODOS.asentado Y periodos_catorcenal.asentado
            '      - Buscar en nomina_pro los distintos anios, periodos y tipo_periodo para insertarlos
            Dim dtDistPer As DataTable = sqlExecute("select distinct ano,periodo,tipo_periodo from nomina_pro", "NOMINA")
            If (Not dtDistPer.Columns.Contains("Error") And dtDistPer.Rows.Count > 0) Then
                TotalPeriodos = dtDistPer.Rows.Count
                For Each drPer As DataRow In dtDistPer.Rows
                    Dim ano As String = "", periodo As String = "", tipo_periodo As String = "", tabla As String = "", anoper As String = ""
                    Try : ano = drPer("ano").ToString.Trim : Catch ex As Exception : ano = "" : End Try
                    Try : periodo = drPer("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
                    Try : tipo_periodo = drPer("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_periodo = "" : End Try
                    anoper = ano & periodo

                    If (tipo_periodo = "C") Then
                        tabla = "periodos_catorcenal"
                        anio_cat = ano
                        per_cat = periodo
                    End If

                    If (tipo_periodo = "S") Then tabla = "periodos"
                    sqlExecute("update " & tabla & " set asentado=1 where ano+periodo='" & anoper & "'", "TA")

                Next
            End If

            '---********************* Actualizar status_proceso a que ya es paso 4
            sqlExecute("update status_proceso set avance='4',usuario='" & Usuario & "',datetime=getdate()", "NOMINA")

            '---NOTA: Eliminar todo excepto los registros que vienen del proceso de finiquitos los cuales ya fueron asentados, los cuales vienen distinguidos por TIPO_NOMINA='F' ó mes=''

            '---********************* Pasar de movimientos_pro a movimientos
            '       --Eliminar de movimientos_pro  los periodos que vamos a cerrar si es qeu estuvieran,tanto semanal como 14nal
            If (TotalPeriodos = 1) Then
                sqlExecute("delete from movimientos where ano+periodo='" & anio & per & "' and isnull(TIPO_NOMINA,'')='' and tipo_periodo='S'", "NOMINA")
            End If
            If (TotalPeriodos = 2) Then
                sqlExecute("delete from movimientos where ano+periodo='" & anio_cat & per_cat & "' and isnull(TIPO_NOMINA,'')='' and tipo_periodo='C'", "NOMINA")
                sqlExecute("delete from movimientos where ano+periodo='" & anio & per & "' and isnull(TIPO_NOMINA,'')='' and tipo_periodo='S'", "NOMINA")
            End If

            sqlExecute("insert into movimientos select * from movimientos_pro", "NOMINA")


            '---************ Pasar de movimientos_imss_pro a  movimientos_imss
            If (TotalPeriodos = 1) Then
                sqlExecute("delete from movimientos_imss where ano+periodo='" & anio & per & "' and isnull(TIPO_NOMINA,'')='' and tipo_periodo='S'", "NOMINA")
            End If
            If (TotalPeriodos = 2) Then
                sqlExecute("delete from movimientos_imss where ano+periodo='" & anio_cat & per_cat & "' and isnull(TIPO_NOMINA,'')='' and tipo_periodo='C'", "NOMINA")
                sqlExecute("delete from movimientos_imss where ano+periodo='" & anio & per & "' and isnull(TIPO_NOMINA,'')='' and tipo_periodo='S'", "NOMINA")
            End If
            sqlExecute("insert into movimientos_imss select * from movimientos_imss_pro", "NOMINA")


            '---******** Pasar de nomina_pro a nomina
            If (TotalPeriodos = 1) Then
                sqlExecute("delete from nomina where ano+periodo='" & anio & per & "' and isnull(mes,'')<>'' and tipo_periodo='S'", "NOMINA")
            End If
            If (TotalPeriodos = 2) Then
                sqlExecute("delete from nomina where ano+periodo='" & anio_cat & per_cat & "' and isnull(mes,'')<>'' and tipo_periodo='C'", "NOMINA")
                sqlExecute("delete from nomina where ano+periodo='" & anio & per & "' and isnull(mes,'')<>'' and tipo_periodo='S'", "NOMINA")
            End If

            dtNomina_pro = sqlExecute("select * from nomina_pro", "NOMINA")
            dtMovimientos_pro = sqlExecute("select * from movimientos_pro", "NOMINA")

            '--Mostrar progress
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Text = "Procesando datos"
            Application.DoEvents()
            frmTrabajando.Avance.Maximum = dtNomina_pro.Rows.Count

            If (Not dtNomina_pro.Columns.Contains("Error") And dtNomina_pro.Rows.Count > 0) Then
                For Each drNom As DataRow In dtNomina_pro.Rows
                    Dim cod_comp As String = "", ano As String = "", periodo As String = "", reloj As String = ""
                    Dim mes As String = "", nombres As String = "", SACTUAL As Double = 0.0, INTEGRADO As Double = 0.0, alta As String = "", baja As String = "", COD_TIPO_NOMINA As String = "", COD_PAGO As String = ""
                    Dim COD_DEPTO As String = "", COD_TURNO As String = "", COD_PUESTO As String = "", COD_SUPER As String = "", COD_HORA As String = "", COD_TIPO As String = "", COD_CLASE As String = "", cod_area As String = "", tipo_periodo As String = ""
                    Dim cod_costos As String = "", COD_PLANTA As String = "", DEPOSITO As Integer = 0, recalc_nom As Integer = 0, CUENTA As String = "", banco As String = "", CLABE As String = ""
                    Dim infonavit As String = "", tipo_cred As String = ""

                    Dim saldo_act As Double = 0.0, abono_act As Double = 0.0

                    Dim dtCod_Comp As DataTable
                    dtCod_Comp = sqlExecute("select COD_COMP from cias where CIA_DEFAULT=1", "PERSONAL")
                    If (Not dtCod_Comp.Columns.Contains("Error") And dtCod_Comp.Rows.Count > 0) Then
                        Try : cod_comp = dtCod_Comp.Rows(0).Item("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try
                    End If

                    Try : ano = drNom("ano").ToString.Trim : Catch ex As Exception : ano = "" : End Try
                    Try : periodo = drNom("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
                    Try : reloj = drNom("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try

                    '----Mostrar Progress - avance
                    i += 1
                    frmTrabajando.Avance.Value = i
                    frmTrabajando.lblAvance.Text = reloj
                    Application.DoEvents()
                    '----Ends Avance

                    Try : mes = drNom("mes").ToString.Trim : Catch ex As Exception : mes = "" : End Try
                    Try : nombres = drNom("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
                    Try : SACTUAL = Double.Parse(drNom("SACTUAL")) : Catch ex As Exception : SACTUAL = 0.0 : End Try
                    Try : INTEGRADO = Double.Parse(drNom("INTEGRADO")) : Catch ex As Exception : INTEGRADO = 0.0 : End Try
                    Try : alta = FechaSQL(drNom("alta").ToString.Trim) : Catch ex As Exception : alta = "NULL" : End Try
                    Try : baja = FechaSQL(drNom("baja").ToString.Trim) : Catch ex As Exception : baja = "NULL" : End Try
                    Try : COD_TIPO_NOMINA = drNom("COD_TIPO_NOMINA").ToString.Trim : Catch ex As Exception : COD_TIPO_NOMINA = "" : End Try
                    Try : COD_PAGO = drNom("COD_PAGO").ToString.Trim : Catch ex As Exception : COD_PAGO = "" : End Try
                    Try : COD_DEPTO = drNom("COD_DEPTO").ToString.Trim : Catch ex As Exception : COD_DEPTO = "" : End Try
                    Try : COD_TURNO = drNom("COD_TURNO").ToString.Trim : Catch ex As Exception : COD_TURNO = "" : End Try
                    Try : COD_PUESTO = drNom("COD_PUESTO").ToString.Trim : Catch ex As Exception : COD_PUESTO = "" : End Try
                    Try : COD_SUPER = drNom("COD_SUPER").ToString.Trim : Catch ex As Exception : COD_SUPER = "" : End Try
                    Try : COD_HORA = drNom("COD_HORA").ToString.Trim : Catch ex As Exception : COD_HORA = "" : End Try
                    Try : COD_TIPO = drNom("COD_TIPO").ToString.Trim : Catch ex As Exception : COD_TIPO = "" : End Try
                    Try : COD_CLASE = drNom("COD_CLASE").ToString.Trim : Catch ex As Exception : COD_CLASE = "" : End Try
                    Try : cod_area = drNom("cod_area").ToString.Trim : Catch ex As Exception : cod_area = "" : End Try
                    Try : tipo_periodo = drNom("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_periodo = "" : End Try
                    Try : cod_costos = drNom("cod_costos").ToString.Trim : Catch ex As Exception : cod_costos = "" : End Try
                    Try : COD_PLANTA = drNom("COD_PLANTA").ToString.Trim : Catch ex As Exception : COD_PLANTA = "" : End Try
                    Try : DEPOSITO = Convert.ToInt32(drNom("DEPOSITO")) : Catch ex As Exception : DEPOSITO = 0 : End Try
                    Try : recalc_nom = Convert.ToInt32(drNom("recalc_nom")) : Catch ex As Exception : recalc_nom = 0 : End Try
                    Try : CUENTA = drNom("CUENTA_BANCO").ToString.Trim : Catch ex As Exception : CUENTA = "" : End Try
                    Try : banco = drNom("banco").ToString.Trim : Catch ex As Exception : banco = "" : End Try
                    Try : CLABE = drNom("CLABE").ToString.Trim : Catch ex As Exception : CLABE = "" : End Try
                    Try : infonavit = drNom("infonavit_credito").ToString.Trim : Catch ex As Exception : infonavit = "" : End Try
                    Try : tipo_cred = drNom("tipo_credito").ToString.Trim : Catch ex As Exception : tipo_cred = "" : End Try

                    '---Validar si la cuenta del banco no viene, que tome el campo Clabe
                    If CUENTA = "" Then CUENTA = CLABE
                    If COD_TIPO_NOMINA = "F" Then COD_PAGO = "E"

                    Dim KeyUpdate As String = cod_comp & ano & periodo & reloj

                    sqlExecute("insert into nomina (cod_comp,ano,PERIODO,RELOJ) VALUES ('" & cod_comp & "','" & ano & "','" & periodo & "','" & reloj & "')", "NOMINA")

                    sqlExecute("Update nomina set MES='" & mes & "' WHERE ISNULL(MES,'')='' AND COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set nombres='" & nombres & "'WHERE ISNULL(nombres,'')='' AND  COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set SACTUAL='" & SACTUAL & "' WHERE ISNULL(SACTUAL,'')='' AND COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set INTEGRADO='" & INTEGRADO & "' WHERE ISNULL(INTEGRADO,'')='' AND COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set alta='" & alta & "' WHERE ISNULL(alta,'')='' AND COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set baja='" & baja & "' WHERE ISNULL(baja,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set COD_TIPO_NOMINA='" & COD_TIPO_NOMINA & "' WHERE ISNULL(cod_tipo_nomina,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set COD_PAGO='" & COD_PAGO & "' WHERE ISNULL(cod_pago,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set COD_DEPTO='" & COD_DEPTO & "' WHERE ISNULL(cod_depto,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set COD_TURNO='" & COD_TURNO & "' WHERE ISNULL(cod_turno,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set COD_PUESTO='" & COD_PUESTO & "' WHERE ISNULL(cod_puesto,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set COD_SUPER='" & COD_SUPER & "' WHERE ISNULL(cod_super,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set COD_HORA='" & COD_HORA & "' WHERE ISNULL(cod_hora,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set COD_TIPO='" & COD_TIPO & "' WHERE ISNULL(cod_tipo,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set COD_CLASE='" & COD_CLASE & "' WHERE ISNULL(cod_clase,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set cod_area='" & cod_area & "' WHERE ISNULL(cod_area,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set tipo_periodo='" & tipo_periodo & "' WHERE ISNULL(tipo_periodo,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set cod_costos='" & cod_costos & "' WHERE ISNULL(cod_costos,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set COD_PLANTA='" & COD_PLANTA & "' WHERE ISNULL(cod_planta,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set DEPOSITO='" & DEPOSITO & "' WHERE ISNULL(deposito,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set recalc_nom='" & recalc_nom & "' WHERE ISNULL(recalc_nom,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set CUENTA='" & CUENTA & "' WHERE ISNULL(cuenta,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")
                    sqlExecute("Update nomina set banco='" & banco & "' WHERE ISNULL(banco,'')='' and COD_COMP+ano+PERIODO+RELOJ='" & KeyUpdate & "'", "NOMINA")

                    '**********************************************************Actualizar cobro_seg_viv de Infonavit y personal en 0 para que no vuelva a descontar la proxima nómina
                    If (dtMovimientos_pro.Select("RELOJ='" & reloj & "' and CONCEPTO='SEGVIV' and monto>0").Count > 0) Then
                        sqlExecute("update infonavit set cobro_segv=0 where infonavit='" & infonavit & "' and reloj='" & reloj & "'", "PERSONAL")
                        sqlExecute("UPDATE PERSONAL set PAGO_SEGVI=0 where infonavit='" & infonavit & "' and reloj='" & reloj & "'", "PERSONAL")
                    End If


                    '***********************************************************Actualizar MTRO_DED y SALDOS_CA

                    Dim QBuscaConcep As String = "select distinct mtro_ded.CONCEPTO from MTRO_DED LEFT JOIN CONCEPTOS ON mtro_ded.CONCEPTO = CONCEPTOS.CONCEPTO " & _
                        "where isnull(STATUS,0)=1 and isnull(saldo_act,0)>0 and isnull(ABONO_ACT,0)>0 and isnull(anoper_aplicado,'')<'" & anio & per & "' and reloj='" & reloj & "' and ano+PERIODO<='" & anio & per & "' " & _
                        "and mtro_ded.CONCEPTO not in ('SAFAHC','SAFAHE')"

                    Dim dtQbuscaConcep As DataTable = sqlExecute(QBuscaConcep, "NOMINA")
                    If (Not dtQbuscaConcep.Columns.Contains("Error") And dtQbuscaConcep.Rows.Count > 0) Then

                        '-- Recorrer cada uno de los conceptos que tiene
                        For Each drConc As DataRow In dtQbuscaConcep.Rows
                            Dim concepto As String = "", queryDetalle As String = ""
                            Try : concepto = drConc("CONCEPTO").ToString.Trim : Catch ex As Exception : concepto = "" : End Try

                            queryDetalle = "select reloj,mtro_ded.CONCEPTO,RTRIM(CONCEPTOS.NOMBRE) AS DESCRIP,NUMCREDITO,ano,PERIODO,status,SALDO_ACT,ABONO_ACT,SEM_RESTAN,anoper_aplicado " & _
                                "from MTRO_DED LEFT JOIN CONCEPTOS ON mtro_ded.CONCEPTO = CONCEPTOS.CONCEPTO " & _
                                "where isnull(STATUS,0)=1 and isnull(saldo_act,0)>0 and isnull(ABONO_ACT,0)>0 and ano+PERIODO<='" & anio & per & "' and isnull(anoper_aplicado,'')<'" & anio & per & "' and reloj='" & reloj & "' and mtro_ded.CONCEPTO='" & concepto & "' "
                            Dim dtDetMtroDed As DataTable = sqlExecute(queryDetalle, "NOMINA")
                            If (Not dtDetMtroDed.Columns.Contains("Error") And dtDetMtroDed.Rows.Count > 0) Then
                                Dim MontoQueda As Double = 0.0

                                '        '-- Buscar lo total descontado en movs_pro
                                Dim QMovsPro As String = "select * from movimientos_pro where reloj='" & reloj & "' and concepto='" & concepto & "'"
                                Dim dtMovsPro As DataTable = sqlExecute(QMovsPro, "NOMINA")
                                If (Not dtMovsPro.Columns.Contains("Error") And dtMovsPro.Rows.Count > 0) Then
                                    Try : MontoQueda = Double.Parse(dtMovsPro.Rows(0).Item("monto")) : Catch ex As Exception : MontoQueda = 0.0 : End Try
                                End If

                                '--- Recorrer cada uno de los préstamos de ese mismo concepto
                                For Each drow As DataRow In dtDetMtroDed.Rows
                                    saldo_act = 0.0
                                    abono_act = 0.0
                                    Dim numcredito As String = "", descrip As String = "", sem_restan As Integer = 0, saldo_original As Double = 0.0, status As Integer = 1

                                    Try : saldo_original = Double.Parse(drow("saldo_act")) : Catch ex As Exception : saldo_original = 0.0 : End Try
                                    Try : saldo_act = Double.Parse(drow("saldo_act")) : Catch ex As Exception : saldo_act = 0.0 : End Try
                                    Try : abono_act = Double.Parse(drow("abono_act")) : Catch ex As Exception : abono_act = 0.0 : End Try
                                    Try : numcredito = drow("numcredito").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                                    Try : descrip = drow("descrip").ToString.Trim : Catch ex As Exception : descrip = "" : End Try
                                    Try : sem_restan = Convert.ToInt32(drow("sem_restan")) : Catch ex As Exception : sem_restan = 0 : End Try

                                    If (saldo_act <= abono_act) Then abono_act = saldo_act ' Validar que el abono no sea mayor al saldo que queda de ese préstamo


                                    '        '---Validar el monto que va quedando
                                    If (MontoQueda >= abono_act) Then
                                        MontoQueda = MontoQueda - abono_act
                                        abono_act = abono_act
                                    Else
                                        abono_act = MontoQueda
                                        MontoQueda = 0
                                    End If
                                    '--Actualizar el saldo q va quedando para ese num de credito
                                    saldo_act = saldo_act - abono_act

                                    '        '-- Llenar detalle en saldos_sa
                                    Dim coment As String = "Saldo Inicial: " & saldo_original & " ;Usuario: " & Usuario
                                    Dim QInsSaldos As String = "insert into saldos_ca (reloj,PERIODO,ANO,CONCEPTO,NUMCREDITO,ABONO_ALC,SALDO_ACT,COMENTARIO) " & _
                                        "values ('" & reloj & "','" & per & "','" & anio & "','" & concepto & "','" & numcredito & "'," & abono_act & "," & saldo_act & ",'" & coment & "')"
                                    sqlExecute(QInsSaldos, "NOMINA")

                                    '        '--- Actualizar el mtro_ded
                                    If saldo_act <= 0 Then status = 0 ' Si el saldo ya se completó, inactivarlo, status = 0

                                    '--- Validar si existe dicho registro, si existe que ya no actualice
                                    Dim dtExisteMtroDed As DataTable = sqlExecute("select * from mtro_ded where reloj='" & reloj & "' and CONCEPTO='" & concepto & "' AND anoper_aplicado='" & anio & per & "'", "NOMINA")
                                    Dim QUpMtroDed As String = "update mtro_ded set SALDO_ACT=" & saldo_act & ",SEM_RESTAN=" & sem_restan - 1 & ",anoper_aplicado='" & anio & per & "',STATUS=" & status & ",ano='" & anio & "',PERIODO='" & per & "' where reloj='" & reloj & "' and CONCEPTO='" & concepto & "' and NUMCREDITO='" & numcredito & "' and STATUS=1 and isnull(saldo_act,0)>0"
                                    Dim actualizaMtroDed As Boolean = True
                                    If (Not dtDetMtroDed.Columns.Contains("Error") And dtExisteMtroDed.Rows.Count > 0) Then actualizaMtroDed = False
                                    If actualizaMtroDed Then sqlExecute(QUpMtroDed, "NOMINA")

                                Next

                            End If

                        Next
                    End If

                    '***-----Asentar saldos de Fondo de ahorro
                    ' /*** Al ASENTAR: NOTA: en SALDO_ACT ya debe de mandar lo que trae en SAFAHC ó SAFAHE que venga en Movimientos_pro 
                    '  y abono_act va a ser lo de APOCIA, que es lo del abono, que es lo que está en Movimientos */

                    If (dtMovimientos_pro.Select("RELOJ='" & reloj & "' and CONCEPTO in('APOCIA','SAFAHC','SAFAHE') and monto>0").Count > 0) Then
                        saldo_act = 0.0
                        abono_act = 0.0
                        Dim Q1 As String = "", Q2 As String = "", Q3 As String = "", Q4 As String = ""

                        Dim drApoc As DataRow = Nothing
                        Dim drSafhac As DataRow = Nothing

                        Try : drApoc = dtMovimientos_pro.Select("RELOJ='" & reloj & "' and CONCEPTO in('APOCIA') and monto>0")(0) : Catch ex As Exception : drApoc = Nothing : End Try
                        If (Not IsNothing(drApoc)) Then abono_act = Double.Parse(drApoc("monto"))

                        Try : drSafhac = dtMovimientos_pro.Select("RELOJ='" & reloj & "' and CONCEPTO in('SAFAHC') and monto>0")(0) : Catch ex As Exception : drSafhac = Nothing : End Try
                        If (Not IsNothing(drSafhac)) Then saldo_act = Double.Parse(drSafhac("monto"))

                        saldo_act += abono_act ' Actualizamos el saldo sumandole el monto de lo aportado del periodo

                        Q1 = "UPDATE mtro_ded set anoper_aplicado='" & anio.Trim & per.Trim & "',SALDO_ACT=" & saldo_act & ", ABONO_ACT=" & abono_act & " where ano='" & anio & "'and periodo='" & per & "' and CONCEPTO='SAFAHC' and reloj='" & reloj & "'"
                        Q2 = "UPDATE mtro_ded set anoper_aplicado='" & anio.Trim & per.Trim & "',SALDO_ACT=" & saldo_act & ", ABONO_ACT=" & abono_act & " where ano='" & anio & "'and periodo='" & per & "' and CONCEPTO='SAFAHE' and reloj='" & reloj & "'"
                        Q3 = "insert into saldos_ca (RELOJ,PERIODO,ANO,CONCEPTO,NUMCREDITO,ABONO_ALC,SALDO_ACT,COMENTARIO) " & _
                            "VALUES ('" & reloj & "','" & per & "','" & anio & "','SAFAHC','" & anio.Trim & per.Trim & "'," & abono_act & "," & saldo_act & ",'Saldo inicial " & Date.Today & " Usuario: " & Usuario & "')"
                        Q4 = "insert into saldos_ca (RELOJ,PERIODO,ANO,CONCEPTO,NUMCREDITO,ABONO_ALC,SALDO_ACT,COMENTARIO) " & _
    "VALUES ('" & reloj & "','" & per & "','" & anio & "','SAFAHE','" & anio.Trim & per.Trim & "'," & abono_act & "," & saldo_act & ",'Saldo inicial " & Date.Today & " Usuario: " & Usuario & "')"

                        '-- Validar si existe ya en mtro_ded aplicado, para que no lo vuelva a aplicar
                        Dim dtExisteMtroDed As DataTable = sqlExecute("select * from mtro_ded where reloj='" & reloj & "' and concepto in ('SAFAHC','SAFAHE') and anoper_aplicado='" & anio.Trim & per.Trim & "'", "NOMINA")
                        Dim ActMtroDed As Boolean = True
                        If (Not dtExisteMtroDed.Columns.Contains("Error") And dtExisteMtroDed.Rows.Count > 0) Then ActMtroDed = False

                        If (ActMtroDed) Then
                            sqlExecute(Q1, "NOMINA")
                            sqlExecute(Q2, "NOMINA")
                        End If
                        sqlExecute(Q3, "NOMINA")
                        sqlExecute(Q4, "NOMINA")


                    End If

                    '*************************************ENDS Actualiza mtro_ded y saldos_ca

                Next

                '**************************************LIQ FONDO DE AHORRO (Pasar los saldos finales a la tabla donde se procesará la nómina de liq de fah, e inactivar a todos con status = 0)
                If (UltPerAporFah) Then
                    Dim QBuscaSaldosFAH As String = "SELECT reloj,CONCEPTO,ano,PERIODO,STATUS,SALDO_ACT,ABONO_ACT,anoper_aplicado from mtro_ded where concepto in('SAFAHC','SAFAHE') and ano='" & anio & "' and STATUS=1 order by reloj asc" ' Traerse a todos los activos
                    dtEmplSaldosFah = sqlExecute(QBuscaSaldosFAH, "NOMINA")
                    If (Not dtEmplSaldosFah.Columns.Contains("Error") And dtEmplSaldosFah.Rows.Count > 0) Then
                        For Each drRfah As DataRow In dtEmplSaldosFah.Rows
                            Dim rj As String = "", saldo As Double = 0.0, abono As Double = 0.0, concepto As String = "", QInsert As String = ""
                            Try : rj = drRfah("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                            Try : concepto = drRfah("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                            Try : saldo = Double.Parse(drRfah("saldo_act")) : Catch ex As Exception : saldo = 0.0 : End Try
                            Try : abono = Double.Parse(drRfah("abono_act")) : Catch ex As Exception : abono = 0.0 : End Try

                            QInsert = "insert into saldos_liq_fah (ano,per,reloj,concepto,status,saldo_act,abono_act,anoper_aplicado) values('" & anio.Trim & "','" & per & "','" & rj & "','" & concepto & "','1'," & saldo & "," & abono & ",'" & anio.Trim & per.Trim & "')"
                            sqlExecute(QInsert, "NOMINA")
                        Next
                    End If

                    sqlExecute("update mtro_ded SET SALDO_ACT=0 where concepto in('SAFAHC','SAFAHE') and ano='" & anio & "' and STATUS=1", "NOMINA")  ' Dejar el saldo en Cero a todos los que aplicaron para la nóm de Liq del FAH
                    sqlExecute("UPDATE config_per_liqfah SET activo=0", "NOMINA") ' Inactivamos los periodos para descuento del Fondo de ahorro

                End If

                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()

            End If




            MessageBox.Show("El proceso fue concluído satisfactoriamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            Me.Dispose()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class