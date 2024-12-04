Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmAsentarNom_esp

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

    Private Sub frmAsentarNom_esp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If (nombreNomEspecial = "agui" Or nombreNomEspecial = "liq_fah" Or nombreNomEspecial = "ptu") Then
                '---Obtener anio y periodo procesado
                Dim dtAnioPer As DataTable = sqlExecute("select * from status_proceso_esp", "NOMINA")

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

                Dim dtFechasPer As DataTable = sqlExecute("SELECT * from periodos where ano+PERIODO='" & anioPer & "'", "TA")
                If (Not dtFechasPer.Columns.Contains("Error") And dtFechasPer.Rows.Count > 0) Then
                    Try : fIniPerSem = FechaSQL(dtFechasPer.Rows(0).Item("fini_nom").ToString.Trim) : Catch ex As Exception : fIniPerSem = "" : End Try
                    Try : fFinPerSem = FechaSQL(dtFechasPer.Rows(0).Item("ffin_nom").ToString.Trim) : Catch ex As Exception : fFinPerSem = "" : End Try
                    Try : asentado = dtFechasPer.Rows(0).Item("asentado").ToString.Trim : Catch ex As Exception : asentado = "" : End Try
                End If
                lblAnioPer.Text = anio & " - " & per & " - Del " & fIniPerSem & " al " & fFinPerSem
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnAsentarNom_Click(sender As Object, e As EventArgs) Handles btnAsentarNom.Click
        Try
            '-- liq_fah  ' --- HERE AOS
            ' If (nombreNomEspecial = "agui") Then
            Dim nameNomClose As String = ""
            If (nombreNomEspecial = "agui") Then nameNomClose = "aguinaldo"
            If (nombreNomEspecial = "liq_fah") Then nameNomClose = "liquidación de fondo de ahorro"
            If (nombreNomEspecial = "ptu") Then nameNomClose = "PTU - Utilidades"


            If (asentado = "1") Then
                MessageBox.Show("El periodo ya encuentra asentado/cerrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If

            If MessageBox.Show("¿Está seguro de asentar/cerrar el periodo de " & nameNomClose & "?", "Asentar Periodo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
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

            '----AOS: 2022-03-14 : Validar a cada uno de los empleados que la suma del totalper y totalded coincida con la suma de cada uno de sus conceptos
            Dim dtDistinctRj As DataTable = sqlExecute("select distinct reloj from movimientos_pro_esp order by reloj asc", "NOMINA")
            Dim dtMovsPro As DataTable = sqlExecute("select * from movimientos_pro_esp", "NOMINA")
            Dim mensajeNoCuadra As String = ""

            If (Not dtDistinctRj.Columns.Contains("Error") And dtDistinctRj.Rows.Count > 0) Then

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

                    Dim QtotPer As String = "select ISNULL(SUM(convert(float,m.monto)),0) AS 'totalpercep' from movimientos_pro_esp m left outer join conceptos c  on m.concepto=c.CONCEPTO " & _
                    "where m.reloj='" & rj & "' and c.COD_NATURALEZA='P' and m.CONCEPTO not in ('BONDES')"

                    Dim QTotDed As String = "select ISNULL(SUM(convert(float,m.monto)),0) AS 'totalded' from movimientos_pro_esp m left outer join conceptos c on m.concepto=c.CONCEPTO " & _
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
                    Try : drwMovs = dtMovsPro.Select("reloj ='" & rj & "' and concepto in('TOTPER')")(0) : Catch ex As Exception : drwMovs = Nothing : End Try
                    If (Not IsNothing(drwMovs)) Then
                        Try : totper = drwMovs("monto") : Catch ex As Exception : totper = 0.0 : End Try
                    End If

                    Try : drMovsDed = dtMovsPro.Select("reloj ='" & rj & "' and concepto in('TOTDED')")(0) : Catch ex As Exception : drMovsDed = Nothing : End Try
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
                    MessageBox.Show("No se encontraron diferencias en los totales por empleado, se procederá a ralizar el cierre de la nómina especial", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                End If
            End If

            '---Mostrar Progress
            Dim i As Integer = -1
            frmTrabajando.Text = "Asentar nómina de " & nameNomClose
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Asentando nómina de " & nameNomClose
            ActivoTrabajando = True
            frmTrabajando.Show()
            Application.DoEvents()

            '---***************** actualizar  periodos que ya fue cerrado en la tabla PERIODOS.asentado Y periodos_catorcenal.asentado
            '      - Buscar en nomina_pro los distintos anios, periodos y tipo_periodo para insertarlos
            Dim dtDistPer As DataTable = sqlExecute("select distinct ano,periodo,tipo_periodo from nomina_pro_esp", "NOMINA")
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
            sqlExecute("update status_proceso_esp set avance='4',usuario='" & Usuario & "',datetime=getdate()", "NOMINA")

            '---********************* Pasar de movimientos_pro_esp a movimientos
            '       --Eliminar de movimientos_pro  los periodos que vamos a cerrar si es qeu estuvieran,tanto semanal como 14nal
            If (TotalPeriodos = 1) Then
                sqlExecute("delete from movimientos where ano+periodo='" & anio & per & "' and isnull(TIPO_NOMINA,'')=''", "NOMINA")
            End If
            If (TotalPeriodos = 2) Then
                sqlExecute("delete from movimientos where ano+periodo='" & anio_cat & per_cat & "' and isnull(TIPO_NOMINA,'')=''", "NOMINA")
                sqlExecute("delete from movimientos where ano+periodo='" & anio & per & "' and isnull(TIPO_NOMINA,'')=''", "NOMINA")
            End If

            sqlExecute("insert into movimientos select * from movimientos_pro_esp", "NOMINA")

            '---******** Pasar de nomina_pro_esp a nomina
            If (TotalPeriodos = 1) Then
                sqlExecute("delete from nomina where ano+periodo='" & anio & per & "' and isnull(mes,'')<>''", "NOMINA")
            End If
            If (TotalPeriodos = 2) Then
                sqlExecute("delete from nomina where ano+periodo='" & anio_cat & per_cat & "' and isnull(mes,'')<>''", "NOMINA")
                sqlExecute("delete from nomina where ano+periodo='" & anio & per & "' and isnull(mes,'')<>''", "NOMINA")
            End If

            dtNomina_pro = sqlExecute("select * from nomina_pro_esp", "NOMINA")
            dtMovimientos_pro = sqlExecute("select * from movimientos_pro_esp", "NOMINA")

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

                    '-----2021-10-28 - AOS: Cargar cod_comp dinámicamente
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

                Next

                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()

            End If

            ' End If


            MessageBox.Show("El proceso fue concluído satisfactoriamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            Me.Dispose()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class