Public Class frmFiniquitos
    Dim dtperiodos As DataTable
    Dim tipo_periodo As String = ""
    Private Sub frmFiniquitos_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        dgRetiros.DataSource = sqlExecute("select  nomina_finiquito.reloj, nomina_finiquito.nombres, nomina_finiquito.baja, nomina_finiquito.ano+nomina_finiquito.periodo as periodo, nomina_finiquito.tipo_periodo, nomina_finiquito.fecha_exportacion, " & _
                                          "movimientos_finiquito.monto  from nomina_finiquito " & _
                                          "left join movimientos_finiquito on nomina_finiquito.reloj = movimientos_finiquito.reloj and nomina_finiquito.ano + nomina_finiquito.periodo = movimientos_finiquito.ano + movimientos_finiquito.PERIODO " & _
                                          "where confirma = '0'  and CONCEPTO = 'NETO'", "nomina")
        dgRetiros.ReadOnly = False


    End Sub
    Private Sub MostrarInformacion()

    End Sub
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtResultadoNominaF As New DataTable
        Dim dtdatos As New DataTable
        Dim dtinfoB As DataTable
        Dim dtinfoD As DataTable
        Dim dtinfoT As DataTable
        Dim directorio_archivos As String = ""
        dtResultadoNominaF = sqlExecute("EXEC ReporteadorNominaTipoPeriodo_finiquitos @Cia = '610',@ano = '', @periodo = '" & _
                                        "',@Nivel = '5', @reloj = '', @TipoPeriodo = ''", "nomina")

        dtinfoB = dtResultadoNominaF.Clone
        dtinfoD = dtResultadoNominaF.Clone
        dtinfoT = dtResultadoNominaF.Clone
        For Each oRow As DataGridViewRow In dgRetiros.Rows

            If oRow.Cells("clConfirma").Value = True Then

                For Each dr As DataRow In dtResultadoNominaF.Select("ano+periodo = '" & oRow.Cells("clPeriodo").Value & "' AND reloj = '" & oRow.Cells("clReloj").Value & "' AND cod_pago = 'B'")

                    dtinfoB.ImportRow(dr)

                    'sqlExecute("update nomina_finiquito set confirma = '1', fecha_exportacion = '" & FechaHoraSQL(Date.Now) & "', usuario_exportacion = '" & Usuario & "' where reloj = '" & oRow.Cells("clReloj").Value & "' and ano + periodo = '" & oRow.Cells("clperiodo").Value & "'", "NOMINA")
                Next
                For Each dr As DataRow In dtResultadoNominaF.Select("ano+periodo = '" & oRow.Cells("clPeriodo").Value & "' AND reloj = '" & oRow.Cells("clReloj").Value & "' AND cod_pago = 'D'")

                    dtinfoD.ImportRow(dr)

                    ' sqlExecute("update nomina_finiquito set confirma = '1', fecha_exportacion = '" & FechaHoraSQL(Date.Now) & "', usuario_exportacion = '" & Usuario & "' where reloj = '" & oRow.Cells("clReloj").Value & "' and ano + periodo = '" & oRow.Cells("clperiodo").Value & "'", "NOMINA")
                Next
                For Each dr As DataRow In dtResultadoNominaF.Select("ano+periodo = '" & oRow.Cells("clPeriodo").Value & "' AND reloj = '" & oRow.Cells("clReloj").Value & "'")

                    dtinfoT.ImportRow(dr)

                    sqlExecute("update nomina_finiquito set confirma = '1', fecha_exportacion = '" & FechaHoraSQL(Date.Now) & "', usuario_exportacion = '" & Usuario & "' where reloj = '" & oRow.Cells("clReloj").Value & "' and ano + periodo = '" & oRow.Cells("clperiodo").Value & "'", "NOMINA")
                Next
            End If

        Next


        Dim fbd As New FolderBrowserDialog
        fbd.SelectedPath = directorio_archivos
        If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            directorio_archivos = fbd.SelectedPath.Trim & "\"
        End If


 
        If directorio_archivos <> "" Then
            frmVistaPrevia.LlamarReporte("Pagos electrónicos", dtinfoB, "", {directorio_archivos & "C1", Ano, Periodo, "0"})
            frmVistaPrevia.LlamarReporte("Pagos electrónicos", dtinfoD, "", {directorio_archivos & "C2", Ano, Periodo, "1"})

            frmVistaPrevia.LlamarReporte("Pagos electrónicos", dtinfoT, "", {directorio_archivos & "C3", Ano, Periodo, "3"})
            frmVistaPrevia.ShowDialog()
        End If
        dgRetiros.DataSource = sqlExecute("select  reloj, nombres, baja, ano+periodo as periodo, tipo_periodo, fecha_exportacion, usuario_exportacion from nomina_finiquito where confirma = '0' ", "nomina")
        dgRetiros.ReadOnly = False
        'Public Sub PagosElectronicos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional nombre_archivo As String = "", Optional _ano As String = "", Optional _periodo As String = "", Optional _inter As String = "0")

    End Sub



    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        If chkAll.Checked = True Then
            For Each oRow As DataGridViewRow In dgRetiros.Rows
                oRow.Cells("clConfirma").Value = True
            Next
        Else
            For Each oRow As DataGridViewRow In dgRetiros.Rows
                oRow.Cells("clConfirma").Value = False
            Next
        End If
    End Sub

    Private Sub chkTodas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodas.CheckedChanged
        If chkTodas.Checked = False Then
            dgRetiros.DataSource = sqlExecute("select  nomina_finiquito.reloj, nomina_finiquito.nombres, nomina_finiquito.baja, nomina_finiquito.ano+nomina_finiquito.periodo as periodo, nomina_finiquito.tipo_periodo, nomina_finiquito.fecha_exportacion, " & _
                                          "movimientos_finiquito.monto  from nomina_finiquito " & _
                                          "left join movimientos_finiquito on nomina_finiquito.reloj = movimientos_finiquito.reloj and nomina_finiquito.ano + nomina_finiquito.periodo = movimientos_finiquito.ano + movimientos_finiquito.PERIODO " & _
                                          "where confirma = '0'  and CONCEPTO = 'NETO'", "nomina")
        Else
            dgRetiros.DataSource = sqlExecute("select  nomina_finiquito.reloj, nomina_finiquito.nombres, nomina_finiquito.baja, nomina_finiquito.ano+nomina_finiquito.periodo as periodo, nomina_finiquito.tipo_periodo, nomina_finiquito.fecha_exportacion, " & _
                                          "movimientos_finiquito.monto  from nomina_finiquito " & _
                                          "left join movimientos_finiquito on nomina_finiquito.reloj = movimientos_finiquito.reloj and nomina_finiquito.ano + nomina_finiquito.periodo = movimientos_finiquito.ano + movimientos_finiquito.PERIODO " & _
                                          "where confirma = '1'  and CONCEPTO = 'NETO'", "nomina")
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class