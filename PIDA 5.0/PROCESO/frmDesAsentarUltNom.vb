Public Class frmDesAsentarUltNom

    Dim dtPeriodosProc As New DataTable
    Dim anio1 As String = "", anio2 As String = "", per1 As String = "", per2 As String = "", tper1 As String = "", tper2 As String = ""
    Dim TotalPeriodos As Integer = 0

    Private Sub frmDesAsentarUltNom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtPeriodosProc = sqlExecute("select distinct ano,periodo,tipo_periodo from nomina_pro order by periodo asc", "NOMINA")

        If (Not dtPeriodosProc.Columns.Contains("Error") And dtPeriodosProc.Rows.Count > 0) Then
            If dtPeriodosProc.Rows.Count = 2 Then ' Son los dos periodos
                TotalPeriodos = 2
                Dim item = (From x In dtPeriodosProc.Rows Where x("tipo_periodo").ToString.Trim = "S").ToList()
                Try : anio1 = (item.First()("ano")) : Catch ex As Exception : anio1 = "" : End Try
                Try : per1 = (item.First()("periodo")) : Catch ex As Exception : per1 = "" : End Try
                Try : tper1 = (item.First()("tipo_periodo")) : Catch ex As Exception : tper1 = "" : End Try

                Dim item2 = (From x In dtPeriodosProc.Rows Where x("tipo_periodo").ToString.Trim = "C").ToList()
                Try : anio2 = (item2.First()("ano")) : Catch ex As Exception : anio2 = "" : End Try
                Try : per2 = (item2.First()("periodo")) : Catch ex As Exception : per2 = "" : End Try
                Try : tper2 = (item2.First()("tipo_periodo")) : Catch ex As Exception : tper2 = "" : End Try

                lblUltNomProc.Text = "Ultimas nóminas procesadas:" & anio1 + "-" + per1 + "-" + tper1 + " ; y " + anio2 + "-" + per2 + "-" + tper2
            End If
            If dtPeriodosProc.Rows.Count = 1 Then
                TotalPeriodos = 1
                Dim item = (From x In dtPeriodosProc.Rows Where x("tipo_periodo").ToString.Trim = "S").ToList()
                Try : anio1 = (item.First()("ano")) : Catch ex As Exception : anio1 = "" : End Try
                Try : per1 = (item.First()("periodo")) : Catch ex As Exception : per1 = "" : End Try
                Try : tper1 = (item.First()("tipo_periodo")) : Catch ex As Exception : tper1 = "" : End Try
                lblUltNomProc.Text = "Ultima nómina procesada:" & anio1 + "-" + per1 + "-" + tper1
            End If
        End If



    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnDesAsentarNom_Click(sender As Object, e As EventArgs) Handles btnDesAsentarNom.Click

        Try

            '1 - Validar que los periodos que esten en nomina pro ya esten cerrados (que esten en NOMINA)

            If (TotalPeriodos = 2) Then
                Dim Q1 As String = "", Q2 As String = ""
                Q1 = "select TOP 1 * from nomina where ano='" & anio1 & "' and PERIODO='" & per1 & "' and tipo_periodo='" & tper1 & "' and isnull(COD_TIPO_NOMINA,'')<>'F'"
                Q2 = "select TOP 1 * from nomina where ano='" & anio2 & "' and PERIODO='" & per2 & "' and tipo_periodo='" & tper2 & "' and isnull(COD_TIPO_NOMINA,'')<>'F'"

                Dim dtQ1 As DataTable = sqlExecute(Q1, "NOMINA")
                Dim dtQ2 As DataTable = sqlExecute(Q2, "NOMINA")

                If dtQ1.Rows.Count <= 0 Or dtQ2.Rows.Count <= 0 Then
                    MessageBox.Show("El último periodo abierto aun no se encuentra asentado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                    Me.Dispose()
                    Exit Sub
                End If

            End If
            If (TotalPeriodos = 1) Then
                Dim Q1 As String = ""
                Q1 = "select TOP 1 * from nomina where ano='" & anio1 & "' and PERIODO='" & per1 & "' and tipo_periodo='" & tper1 & "' and isnull(COD_TIPO_NOMINA,'')<>'F'"

                Dim dtQ1 As DataTable = sqlExecute(Q1, "NOMINA")

                If dtQ1.Rows.Count <= 0 Then
                    MessageBox.Show("El último periodo abierto aun no se encuentra asentado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                    Me.Dispose()
                    Exit Sub
                End If
            End If

            '2 - Validar que ni uno de los periodos este timbrado
            If (TotalPeriodos = 2) Then
                Dim Q1 As String = "", Q2 As String = "", dt1 As DataTable, dt2 As DataTable
                Q1 = "select top 1 * from timbrado where ano+periodo+tipo_periodo='" & anio1 & per1 & tper1 & "'"
                Q2 = "select top 1 * from timbrado where ano+periodo+tipo_periodo='" & anio2 & per2 & tper2 & "'"

                dt1 = sqlExecute(Q1, "NOMINA")
                dt2 = sqlExecute(Q2, "NOMINA")

                If (dt1.Rows.Count > 0) Then
                    MessageBox.Show("El periodo " & anio1 & "-" & per1 & " tipo periodo: " & tper1 & ", ya se encuentra timbrado, por lo que no se puede proceder a desaentar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                    Me.Dispose()
                    Exit Sub
                End If

                If (dt2.Rows.Count > 0) Then
                    MessageBox.Show("El periodo " & anio2 & "-" & per2 & " tipo periodo: " & tper2 & ", ya se encuentra timbrado, por lo que no se puede proceder a desaentar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                    Me.Dispose()
                    Exit Sub
                End If

            End If

            If (TotalPeriodos = 1) Then
                Dim Q1 As String = "", dt1 As DataTable
                Q1 = "select top 1 * from timbrado where ano+periodo+tipo_periodo='" & anio1 & per1 & tper1 & "'"

                dt1 = sqlExecute(Q1, "NOMINA")

                If (dt1.Rows.Count > 0) Then
                    MessageBox.Show("El periodo " & anio1 & "-" & per1 & " tipo periodo: " & tper1 & ", ya se encuentra timbrado, por lo que no se puede proceder a desaentar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                    Me.Dispose()
                    Exit Sub
                End If

            End If

            '3 ------------- Se procede a DesAsentar la(s) Ultima(s) nomina(s) procesada(s)

            If MessageBox.Show("¿Está seguro de desasentar la(s) última(s) nómina(s) procesada(s)?", "Desansentar nómina", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("¿Está realmente seguro? ", "Desasentar nómina", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Me.Close()
                    Me.Dispose()
                    Exit Sub
                End If
            Else
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If

            '--Eliminar los saldos
            sqlExecute("truncate table MTRO_DED", "NOMINA")
            sqlExecute("truncate table saldos_ca", "NOMINA")
            sqlExecute("insert into mtro_ded select * from MTRO_DED_resp", "NOMINA")
            sqlExecute("insert into saldos_ca select * from saldos_ca_resp", "NOMINA")

            ' ---Eliminar todos los registros excepto los que son finiquitos (cod_tipo_nomina='F')
            If (TotalPeriodos = 1) Then
                sqlExecute("delete from nomina where ano+PERIODO='" & anio1 & per1 & "' and tipo_periodo='" & tper1 & "' and isnull(COD_TIPO_NOMINA,'')<>'F'", "NOMINA")
                sqlExecute("delete from movimientos where ano+PERIODO='" & anio1 & per1 & "' and tipo_periodo='" & tper1 & "' and isnull(TIPO_NOMINA,'')<>'F'", "NOMINA")
                sqlExecute("update status_proceso set avance=2 where ano+PERIODO='" & anio1 & per1 & "'", "NOMINA")
                sqlExecute("delete from movimientos_imss  where ano+PERIODO='" & anio1 & per1 & "' and tipo_periodo='" & tper1 & "' and isnull(TIPO_NOMINA,'')=''", "NOMINA")
            End If

            If (TotalPeriodos = 2) Then
                sqlExecute("delete from nomina where ano+PERIODO='" & anio1 & per1 & "' and tipo_periodo='" & tper1 & "' and isnull(COD_TIPO_NOMINA,'')<>'F'", "NOMINA")
                sqlExecute("delete from nomina where ano+PERIODO='" & anio2 & per2 & "' and tipo_periodo='" & tper2 & "' and isnull(COD_TIPO_NOMINA,'')<>'F'", "NOMINA")
                sqlExecute("delete from movimientos where ano+PERIODO='" & anio1 & per1 & "' and tipo_periodo='" & tper1 & "' and isnull(TIPO_NOMINA,'')<>'F'", "NOMINA")
                sqlExecute("delete from movimientos where ano+PERIODO='" & anio2 & per2 & "' and tipo_periodo='" & tper2 & "' and isnull(TIPO_NOMINA,'')<>'F'", "NOMINA")
                sqlExecute("update status_proceso set avance=2 where ano+PERIODO='" & anio1 & per1 & "'", "NOMINA")
                sqlExecute("delete from movimientos_imss  where ano+PERIODO='" & anio1 & per1 & "' and tipo_periodo='" & tper1 & "' and isnull(TIPO_NOMINA,'')=''", "NOMINA")
                sqlExecute("delete from movimientos_imss  where ano+PERIODO='" & anio2 & per2 & "' and tipo_periodo='" & tper2 & "' and isnull(TIPO_NOMINA,'')=''", "NOMINA")
            End If


            '---Actualizar los periodos indicando que no esté asentado

            If (TotalPeriodos = 1) Then sqlExecute("update ta.dbo.periodos set asentado=0 where ano+PERIODO='" & anio1 & per1 & "'", "TA")

            If (TotalPeriodos = 2) Then
                sqlExecute("update ta.dbo.periodos set asentado=0 where ano+PERIODO='" & anio1 & per1 & "'", "TA")
                sqlExecute("update ta.dbo.periodos_catorcenal set asentado=0 where ano+PERIODO='" & anio2 & per2 & "'", "TA")
            End If

            MessageBox.Show("Proceso concluído satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class