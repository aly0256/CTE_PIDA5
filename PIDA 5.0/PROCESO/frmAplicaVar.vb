Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmAplicaVar
    Dim dtLista As New DataTable

    Dim anio As String = ""
    Dim bim As String = ""
    Dim avance As String = ""


    Private Sub frmAplicaVar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowInformation()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        '----- Aplicar VARIABLES como TAL
        Dim dtAPlican As New DataTable
        Try

            If MessageBox.Show("¿Está seguro de aplicar el nuevo integrado a los empleados seleccionados?", "Aplicación de variables", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("¿Está realmente seguro? Una vez aplicadas las variables ya no se podrán modificar", "Aplicación de variables", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Me.Close()
                    Me.Dispose()
                    Exit Sub
                End If
            Else
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If

            '---Mostrar Progress
            Dim i As Integer = -1
            frmTrabajando.Text = "Aplicando variables"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Aplicando variables"
            ActivoTrabajando = True
            frmTrabajando.Show()
            Application.DoEvents()

            '--- Actualizar quienes si aplican o no en base al dataGridView

            For x As Integer = 0 To dgAplVar.RowCount - 1
                Dim Reloj As String = "", aplica As String = ""
                Try : Reloj = dgAplVar.Item(3, x).Value.ToString : Catch ex As Exception : Reloj = "" : End Try
                Try : aplica = dgAplVar.Item(10, x).Value.ToString : Catch ex As Exception : aplica = "0" : End Try

                sqlExecute("update variables_nom_pro set aplica=" & aplica & " where ano+bimestre='" & anio & bim & "' and reloj='" & Reloj & "'", "NOMINA")
            Next

            '--- Obtener a todos los que si aplican
            dtAPlican = sqlExecute(" select * from  variables_nom_pro where isnull(aplica,0)=1", "NOMINA")

            If (dtAPlican.Rows.Count = 0) Then
                MessageBox.Show("No hay empleados a aplicar el nuevo integrado IMSS", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            '--Mostrar progress
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Text = "Procesando datos"
            Application.DoEvents()
            frmTrabajando.Avance.Maximum = dtAPlican.Rows.Count

            If (Not dtAPlican.Columns.Contains("Error") And dtAPlican.Rows.Count > 0) Then

                '---- Hacer un respaldo de la tabla personal, llamandola personal_antesvariable
                sqlExecute("DROP TABLE personal_antesvariable", "PERSONAL")
                sqlExecute("select * into personal_antesvariable from personal", "PERSONAL")

                For Each rw As DataRow In dtAPlican.Rows
                    '--- Actualizar en la tabla de personal los nuevos integrados, los campos son: FACTOR_INT,PRO_VAR,INTEGRADO
                    Dim rj As String = "", nvo_fi As Double = 0.0, nvo_provar As Double = 0.0, nvo_integrado As Double = 0.0, qUpdate As String = ""
                    Try : rj = rw("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                    Try : nvo_fi = Double.Parse(rw("nvo_fi")) : Catch ex As Exception : nvo_fi = 0.0 : End Try
                    Try : nvo_provar = Double.Parse(rw("nvo_provar")) : Catch ex As Exception : nvo_provar = 0.0 : End Try
                    Try : nvo_integrado = Double.Parse(rw("nvo_integrado")) : Catch ex As Exception : nvo_integrado = 0.0 : End Try

                    i += 1
                    frmTrabajando.Avance.Value = i
                    frmTrabajando.lblAvance.Text = rj
                    Application.DoEvents()
                    '----Ends Avance

                    qUpdate = "update personal set FACTOR_INT=" & nvo_fi & ",PRO_VAR=" & nvo_provar & ",INTEGRADO=" & nvo_integrado & " where reloj='" & rj & "'"
                    sqlExecute(qUpdate, "PERSONAL")
                Next

                '---- actualizar tabla de periodos_variables que ya fue asentado
                sqlExecute("update periodos_variables set asentado=1 where ano+bimestre='" & anio & bim & "'", "TA")

                '---- actualilzar tabla variable_status_proc con el 4
                sqlExecute("update variable_status_proc set avance=4 where ano+bimestre='" & anio & bim & "'", "NOMINA")

                '---- Pasar toda la data a variables_nom y a variables_mov
                sqlExecute("insert into variables_nom select * from variables_nom_pro", "NOMINA")
                sqlExecute("insert into variables_mov select * from variables_mov_pro", "NOMINA")

                '---- Reactivar cobro de los 15 pesos en INFONAVIT para la prox nomina
                sqlExecute("update infonavit set cobro_segv=1 where isnull(activo,0)=1", "PERSONAL")


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

    Private Sub ShowInformation()

        Try
            Dim dtStatusProc As DataTable = sqlExecute("SELECT * from variable_status_proc", "NOMINA")
            If (dtStatusProc.Rows.Count = 0) Then
                MessageBox.Show("No existe bimestre calculado abierto de variables", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If

            If (Not dtStatusProc.Columns.Contains("Error") And dtStatusProc.Rows.Count > 0) Then
                Try : avance = dtStatusProc.Rows(0).Item("avance") : Catch ex As Exception : avance = "" : End Try
                Try : anio = dtStatusProc.Rows(0).Item("ano") : Catch ex As Exception : anio = "" : End Try
                Try : bim = dtStatusProc.Rows(0).Item("bimestre") : Catch ex As Exception : bim = "" : End Try
            End If

            If avance = "4" Then
                MessageBox.Show("El bimestre ya fue aplicado a todos los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If

            ActualizardgvAplVar()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ActualizardgvAplVar()
        Dim QUERY As String = ""
        '     QUERY = "EXEC ReporteadorVariableTipoBimestre_PRO @Cia = '', @ano = '" & anio & "', @periodo = '" & bim & "',@Nivel = '5', @reloj = ''"
        QUERY = "SELECT cod_comp,ano,bimestre,reloj,nombres,sactual,nvo_fi,nvo_provar,nvo_integrado,comentario,aplica from variables_nom_pro"
        dtLista = sqlExecute(QUERY, "NOMINA")

        dgAplVar.DataSource = dtLista
    End Sub

End Class