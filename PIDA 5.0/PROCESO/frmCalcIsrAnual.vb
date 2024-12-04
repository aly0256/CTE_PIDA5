Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmCalcIsrAnual

    Dim avance As String = ""
    Dim cod_comp As String = ""
    Dim anio As String = ""

    Private Sub frmCalcIsrAnual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatosInicialesIsrAnual()
    End Sub

    Private Sub btnCalcVariable_Click(sender As Object, e As EventArgs) Handles btnCalcVariable.Click

        '---Validar si no está aplicado/asentado

        CalcularIsrAnual(txtAnio.Text.Trim)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub CargarDatosInicialesIsrAnual()
        Try
            '-----2021-10-28 - AOS: Cargar cod_comp dinámicamente
            Dim dtCod_Comp As DataTable
            dtCod_Comp = sqlExecute("select COD_COMP from cias where CIA_DEFAULT=1", "PERSONAL")
            If (Not dtCod_Comp.Columns.Contains("Error") And dtCod_Comp.Rows.Count > 0) Then
                Try : cod_comp = dtCod_Comp.Rows(0).Item("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try
            End If

            Dim dtAnioPer As DataTable = sqlExecute("select * from isranual_status_proc", "nomina")
            If (Not dtAnioPer.Columns.Contains("Error") And dtAnioPer.Rows.Count > 0) Then
                Try : anio = dtAnioPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio = "" : End Try
                Try : avance = dtAnioPer.Rows(0).Item("avance").ToString.Trim : Catch ex As Exception : avance = "" : End Try

                txtAnio.Text = anio
            Else
                MessageBox.Show("No hay un año para calcular el ISR Anual", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If avance = "4" Then
                MessageBox.Show("El año a calcular ya fue aplicado (asentado)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show("No se pudo inicializar el cálculo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Error al iniciar cálculo de ISR Anual", Err.Number, ex.Message)

        End Try
    End Sub

    Public Function CalcularIsrAnual(ByRef anio As String) As Integer
        Try
            '---Mostrar Progress
            Dim i As Integer = -1
            frmTrabajando.Text = "Calculando isr anual"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Calculando isr anual"
            ActivoTrabajando = True
            frmTrabajando.Show()
            Application.DoEvents()

            Dim dtEmplIsrAnual As New DataTable

            If (anio <> "") Then
                dtEmplIsrAnual = sqlExecute("select * from isranual_nom_pro ORDER by reloj asc", "NOMINA")

                If ((dtEmplIsrAnual.Columns.Contains("Error")) Or (Not dtEmplIsrAnual.Columns.Contains("Error") And dtEmplIsrAnual.Rows.Count = 0)) Then
                    MessageBox.Show("No existen empleados para calcular el ISR anual", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Function
                Else

                    '--Mostrar progress
                    frmTrabajando.Avance.IsRunning = False
                    frmTrabajando.lblAvance.Text = "Procesando datos"
                    Application.DoEvents()
                    frmTrabajando.Avance.Maximum = dtEmplIsrAnual.Rows.Count

                    For Each drRow As DataRow In dtEmplIsrAnual.Rows  ' Calcular para cada empleado
                        '----Inicializar cada una de las variables para cada empleado
                        Dim diaPrimEneroAnioActual As New Date(Now.Year, 1, 1)
                        Dim altaCompara As String
                        Dim diaUltimoAnioActual As New Date(Now.Year, 12, 31)
                        Dim reloj As String = "", dias As Integer = 0, alta As String = "", baja = "", cod_comp As String = ""
                        Dim neto_anual As Double = 0.0, totper As Double = 0.0, totexe As Double = 0.0, totgra As Double = 0.0, subcau As Double = 0.0, isrret As Double = 0.0, isrcau As Double = 0.0
                        Dim aplica As Integer = 1

                        '----Dar el valor para cada variable 
                        Try : reloj = drRow("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try

                        '----Mostrar Progress - avance
                        i += 1
                        frmTrabajando.Avance.Value = i
                        frmTrabajando.lblAvance.Text = reloj
                        Application.DoEvents()
                        '----Ends Avance

                        Try : alta = FechaSQL(drRow("alta")) : Catch ex As Exception : alta = "" : End Try
                        Try : baja = FechaSQL(drRow("baja")) : Catch ex As Exception : baja = "" : End Try
                        Try : cod_comp = drRow("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try

                        '---Si la alta es antes del 1/1 del anio actual, entonces comparar contra el 1/1/ del anio actual
                        If (Date.Parse(alta) < diaPrimEneroAnioActual) Then altaCompara = FechaSQL(diaPrimEneroAnioActual) Else altaCompara = alta


                        '---Calcular los días (De su fecha de alta al 31/12/ del año en curso) ' HERE AOS 11/08/2021
                        If (baja = "") Then
                            Try : dias = DateDiff(DateInterval.Day, Date.Parse(altaCompara), diaUltimoAnioActual) + 1 : Catch ex As Exception : dias = 0 : End Try
                        Else
                            Try : dias = DateDiff(DateInterval.Day, Date.Parse(altaCompara), Date.Parse(baja)) + 1 : Catch ex As Exception : dias = 0 : End Try
                        End If

                        If (dias >= 365) Then dias = 365
                        sqlExecute("update isranual_nom_pro set dias=" & dias & " where cod_comp='" & cod_comp & "' and ano='" & anio & "' and reloj='" & Reloj & "'", "NOMINA")

                        '--- NETO ANUAL
                        Dim dtNeto As DataTable = sqlExecute("select ISNULL(SUM(convert(float,monto)),0) AS 'monto' from movimientos where  ANO='" & anio & "' and concepto='NETO'  AND reloj='" & Reloj & "'", "NOMINA")
                        If (Not dtNeto.Columns.Contains("Error") And dtNeto.Rows.Count > 0) Then
                            Try : neto_anual = Double.Parse(dtNeto.Rows(0).Item("monto")) : Catch ex As Exception : neto_anual = 0.0 : End Try
                        End If
                        sqlExecute("update isranual_nom_pro set neto_anual=" & neto_anual & " where cod_comp='" & cod_comp & "' and ano='" & anio & "' and reloj='" & Reloj & "'", "NOMINA")

                        '--- TOTPER : Total de percepciones
                        Dim dtTotPer As DataTable = sqlExecute("select ISNULL(SUM(convert(float,monto)),0) AS 'monto' from movimientos where  ANO='" & anio & "' and concepto='TOTPER'  AND reloj='" & Reloj & "'", "NOMINA")
                        If (Not dtTotPer.Columns.Contains("Error") And dtTotPer.Rows.Count > 0) Then
                            Try : totper = Double.Parse(dtTotPer.Rows(0).Item("monto")) : Catch ex As Exception : totper = 0.0 : End Try
                        End If
                        sqlExecute("update isranual_nom_pro set totper=" & totper & " where cod_comp='" & cod_comp & "' and ano='" & anio & "' and reloj='" & Reloj & "'", "NOMINA")

                        '--- TOTEXE : Total exento
                        Dim dtTotExe As DataTable = sqlExecute("select ISNULL(SUM(convert(float,monto)),0) AS 'monto' from movimientos where  ANO='" & anio & "' and concepto='PEREXE'  AND reloj='" & Reloj & "'", "NOMINA")
                        If (Not dtTotExe.Columns.Contains("Error") And dtTotExe.Rows.Count > 0) Then
                            Try : totexe = Double.Parse(dtTotExe.Rows(0).Item("monto")) : Catch ex As Exception : totexe = 0.0 : End Try
                        End If
                        sqlExecute("update isranual_nom_pro set totexe=" & totexe & " where cod_comp='" & cod_comp & "' and ano='" & anio & "' and reloj='" & Reloj & "'", "NOMINA")

                        '--- TOTGRA : Total Gravado
                        Dim dtTotGra As DataTable = sqlExecute("select ISNULL(SUM(convert(float,monto)),0) AS 'monto' from movimientos where  ANO='" & anio & "' and concepto='PERGRA'  AND reloj='" & Reloj & "'", "NOMINA")
                        If (Not dtTotGra.Columns.Contains("Error") And dtTotGra.Rows.Count > 0) Then
                            Try : totgra = Double.Parse(dtTotGra.Rows(0).Item("monto")) : Catch ex As Exception : totgra = 0.0 : End Try
                        End If
                        sqlExecute("update isranual_nom_pro set totgra=" & totgra & " where cod_comp='" & cod_comp & "' and ano='" & anio & "' and reloj='" & Reloj & "'", "NOMINA")

                        '--- ISRRET : ISR RETENIDO EN EL AÑO
                        Dim dtIsrRet As DataTable = sqlExecute("select ISNULL(SUM(convert(float,monto)),0) AS 'monto' from movimientos where  ANO='" & anio & "' and concepto in('ISPTRE','ISRSEP')  AND reloj='" & reloj & "'", "NOMINA")
                        If (Not dtIsrRet.Columns.Contains("Error") And dtIsrRet.Rows.Count > 0) Then
                            Try : isrret = Double.Parse(dtIsrRet.Rows(0).Item("monto")) : Catch ex As Exception : isrret = 0.0 : End Try
                        End If
                        sqlExecute("update isranual_nom_pro set isrret=" & isrret & " where cod_comp='" & cod_comp & "' and ano='" & anio & "' and reloj='" & Reloj & "'", "NOMINA")

                        '--- SUBCAU : Subsidio Causado en el año
                        Dim dtSubCau As DataTable = sqlExecute("select ISNULL(SUM(convert(float,monto)),0) AS 'monto' from movimientos where  ANO='" & anio & "' and concepto='SUBCAU'  AND reloj='" & Reloj & "'", "NOMINA")
                        If (Not dtSubCau.Columns.Contains("Error") And dtSubCau.Rows.Count > 0) Then
                            Try : subcau = Double.Parse(dtSubCau.Rows(0).Item("monto")) : Catch ex As Exception : subcau = 0.0 : End Try
                        End If
                        sqlExecute("update isranual_nom_pro set subcau=" & subcau & " where cod_comp='" & cod_comp & "' and ano='" & anio & "' and reloj='" & Reloj & "'", "NOMINA")


                        '---- Evaluar si aplica o no 
                        '---Por default viene que si aplica (aplica = 1)
                        If (dias < 365) Then aplica = 0
                        If (baja <> "") Then aplica = 0
                        If (neto_anual >= 400000) Then aplica = 0

                        sqlExecute("update isranual_nom_pro set aplica=" & aplica & " where cod_comp='" & cod_comp & "' and ano='" & anio & "' and reloj='" & Reloj & "'", "NOMINA")

                        '---- Cálculo del ISR ANUAL CAUSADO
                        isrcau = CalcISRAnual(Reloj, totgra, "A", "Imp", isrret, subcau, cod_comp, anio, aplica)
                        sqlExecute("update isranual_nom_pro set isrcau=" & isrcau & " where cod_comp='" & cod_comp & "' and ano='" & anio & "' and reloj='" & Reloj & "'", "NOMINA")


                    Next ' Final para cada empleado

                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()

                    '---Mensaje con el resúmen
                    If i < 0 Then
                        'No hubo archivos para analizar
                        MessageBox.Show("No se calculó ningun registro", "Cálculo de isr anual", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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
                MessageBox.Show("No hay un año inicializado para calcular", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Function
            End If


        Catch ex As Exception
            MessageBox.Show("Ocurrió un error durante el cálculo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Error al calcular el ISR Anual", Err.Number, ex.Message)
            Return 0
        End Try
    End Function
End Class