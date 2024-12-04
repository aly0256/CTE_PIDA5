Imports Newtonsoft.Json

Public Class frmAjustesProcesoNom

#Region "Variables"
    Dim dtAjustesGral As New DataTable
    Dim dtPeriodos As New DataTable
    Dim dtReportes As New DataTable
    Dim dtRespaldos As New DataTable
    Dim dtRespaldosVacio As New DataTable
    Dim tipoPer As String = ""
    Dim strAno = "", strPer = "", strTipo = ""
#End Region

    Public Sub New(ano As String, periodo As String, tipoPer As String)
        InitializeComponent()
        strAno = ano
        strPer = periodo
        strTipo = tipoPer
    End Sub

#Region "Funciones"

    Private Sub OpcionesGenerales()
        Try
            dtAjustesGral = sqlExecute("select * from nomina.dbo.validaciones_procnomina where variable like 'SQLITE_%'")

            If dtAjustesGral.Rows.Count > 0 Then
                For Each x In dtAjustesGral.Rows
                    If x("variable").ToString.Trim = "SQLITE_ARCHIVO_PROCESO" Then txtArchivoProc.Text = x("valor").ToString.Trim
                    If x("variable").ToString.Trim = "SQLITE_RESPALDOS" Then txtRutaResp.Text = x("valor").ToString.Trim
                    If x("variable").ToString.Trim = "SQLITE_RESTAURA_DE_BD" Then chkSQL.Checked = If(Not IsDBNull(x("valor")) AndAlso x("valor") = "1", True, False)
                Next
            End If

        Catch ex As Exception : End Try
    End Sub

    Private Sub Reportes()
        Try
            Dim dtR As DataTable = sqlExecute("select variable,valor from nomina.dbo.validaciones_procnomina where variable like 'BRPQro_%'")
            dtReportes = dtR.Copy
            If dtR.Rows.Count > 0 Then dgvReportes.DataSource = dtR
        Catch ex As Exception : End Try
    End Sub

    Private Sub MarcarReportes(ByVal estado As Boolean)
        Try
            If dgvReportes.RowCount > 0 Then
                For Each row As DataGridViewRow In dgvReportes.Rows
                    row.Cells(1).Value = If(estado, 1, 0)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SeleccionTipoPer() Handles rbS.CheckedChanged, rbQ.CheckedChanged
        Try
            If rbS.Checked Then tipoPer = "periodos"
            If rbQ.Checked Then tipoPer = "periodos_quincenal"
            dtPeriodos = sqlExecute("select ano,periodo from ta.dbo." & tipoPer & " where isnull(periodo_especial,0)=0")
            If dtPeriodos.Rows.Count > 0 Then cmbAno.DataSource = New DataView(dtPeriodos, "", "ano desc", DataViewRowState.CurrentRows).ToTable("", True, "ano")
            If cmbAno.SelectedValue("ano") <> "" Then
                Dim per = New DataView(dtPeriodos, "ano='" & cmbAno.SelectedValue("ano").ToString.Trim & "'", "periodo asc", DataViewRowState.CurrentRows).ToTable("", True, "periodo")
                cmbPer.DataSource = per
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Respaldos(ano As String, periodo As String, tipoPer As String)
        Try
            dtRespaldos = sqlExecute("select id,ano,periodo,tipo_periodo,version,datetime from nomina.dbo.bitacora_proceso where ano+periodo='" &
                                     ano & periodo & "' and tipo_periodo='" & tipoPer & "' order by convert(int,version) desc")
            If dtRespaldos.Rows.Count > 0 Then dgvResp.DataSource = dtRespaldos Else dgvResp.DataSource = dtRespaldos.Clone

        Catch ex As Exception : End Try
    End Sub


#End Region

    Private Sub frmAjustesProcesoNom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpcionesGenerales()
        Reportes()
        SeleccionTipoPer()
    End Sub

    Private Sub chkMarcar_CheckedChanged(sender As Object, e As EventArgs) Handles chkMarcar.CheckedChanged
        MarcarReportes(chkMarcar.Checked)
    End Sub

    Private Sub cmbAno_TextChanged(sender As Object, e As EventArgs) Handles cmbAno.TextChanged
        If cmbAno.SelectedValue("ano") <> "" Then
            Dim per = New DataView(dtPeriodos, "ano='" & cmbAno.SelectedValue("ano").ToString.Trim & "'", "periodo asc", DataViewRowState.CurrentRows).ToTable("", True, "periodo")
            cmbPer.DataSource = per
        End If
    End Sub

    Private Sub cmbPer_TextChanged(sender As Object, e As EventArgs) Handles cmbPer.TextChanged
        If cmbPer.SelectedValue("periodo") <> "" And cmbAno.SelectedValue("ano") <> "" Then
            Respaldos(cmbAno.SelectedValue("ano").ToString.Trim,
                      cmbPer.SelectedValue("periodo").ToString.Trim,
                      If(rbS.Checked, "S", "Q"))
        End If
    End Sub

    Private Sub chkRespaldos_CheckedChanged(sender As Object, e As EventArgs) Handles chkRespaldos.CheckedChanged
        If dgvResp.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvResp.Rows
                row.Cells("Seleccionar").Value = chkRespaldos.Checked
            Next
        End If
    End Sub

    Private Sub btnElimina_Click(sender As Object, e As EventArgs) Handles btnElimina.Click
        If dgvResp.Rows.Count > 0 Then
            Dim info = "Version: "
            Dim strQrys As New System.Text.StringBuilder

            For Each row As DataGridViewRow In dgvResp.Rows
                If row.Cells("Seleccionar").Value Then
                    strQrys.Append("delete from nomina.dbo.bitacora_proceso where id=" & row.Cells("id").Value & ";")
                    info &= row.Cells("Version").Value & ","
                End If
            Next
            If strQrys.ToString.Length > 0 Then
                If MessageBox.Show("Desea eliminar lo siguiente seleccionado de bitacora del año: " & cmbAno.SelectedValue("ano").ToString.Trim &
                                   " periodo: " & cmbPer.SelectedValue("periodo").ToString.Trim & "?" & vbNewLine & vbNewLine & info.Substring(0, info.Length - 1),
                                   "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) =
                                    Windows.Forms.DialogResult.OK Then
                    sqlExecute(strQrys.ToString)
                    Respaldos(cmbAno.SelectedValue("ano").ToString.Trim, cmbPer.SelectedValue("periodo").ToString.Trim, If(rbS.Checked, "S", "Q"))
                End If
            End If
        End If
    End Sub


    ''' <summary>
    ''' Convertir diccionario a datarow
    ''' </summary>
    ''' <param name="data">Datos generales.</param>
    ''' <remarks></remarks>
    Private Function dicTabla(ByVal table As DataTable, data As Dictionary(Of String, String)) As DataTable
        Dim dt = table.Clone
        For Each item In data
            Dim row = dt.NewRow()
            row("variable") = item.Key
            row("valor") = item.Value
            dt.Rows.Add(row)
        Next
        Return dt
    End Function

    Private Sub ActualizaRutas(op As String, variable As String)
        Try
            Dim msj = If(txtArchivoProc.Text.ToString = "",
                    "¿Deseas asignar una ruta de " & op & " para el archivo de proceso de nómina?",
                    "Atención. Estás a punto de modificar la ruta de " & op & " del archivo de proceso de nómina, ¿Deseas continuar?")

            If MessageBox.Show(msj, "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then

                Dim FD As New FolderBrowserDialog
                Dim strRuta = ""

                FD.Description = "Seleccione una ruta"
                FD.RootFolder = Environment.SpecialFolder.Desktop

                If FD.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    strRuta = FD.SelectedPath.ToString.Trim & If(op = "ejecución", "\ProcesoNomina.sqlite", "\")

                    If txtArchivoProc.Text.ToString <> strRuta Then
                        Dim dtInfo = sqlExecute("select * from nomina.dbo.validaciones_procnomina where variable='" & variable & "'")
                        Dim strValidacion = "select * from nomina.dbo.validaciones_procnomina where variable='" & variable & "' and valor='" & strRuta & "'"
                        Dim dtValidacion As New DataTable

                        If dtInfo.Rows.Count > 0 Then
                            sqlExecute("update nomina.dbo.validaciones_procnomina set valor='" & strRuta & "' where variable='" & variable & "'")
                        Else
                            sqlExecute("insert into nomina.dbo.validaciones_procnomina values ('" & variable & "','" & strRuta & "'")
                        End If

                        dtValidacion = sqlExecute(strValidacion)
                        If dtValidacion.Rows.Count > 0 Then
                            MessageBox.Show("Ruta actualizada con éxito. Favor de reiniciar PIDA para aplicar los cambios.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            If op = "ejecución" Then
                                txtArchivoProc.Text = dtValidacion.Rows(0)("valor")
                            Else
                                txtRutaResp.Text = dtValidacion.Rows(0)("valor")
                            End If
                        Else
                            MessageBox.Show("Ocurrió un error durante la actualización, por favor, intentalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Else
                    Exit Sub
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error durante la actualización, por favor, intentalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLocRuta_Click(sender As Object, e As EventArgs) Handles btnLocRuta.Click
        ActualizaRutas("ejecución", "SQLITE_ARCHIVO_PROCESO")
    End Sub

    Private Sub btnLocRutaResp_Click(sender As Object, e As EventArgs) Handles btnLocRutaResp.Click
        ActualizaRutas("respaldo", "SQLITE_RESPALDOS")
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            '-- Reportes
            Dim strCambios As New System.Text.StringBuilder

            For Each row As DataGridViewRow In dgvReportes.Rows
                If dtReportes.Select("variable='" & row.Cells(0).Value.ToString & "'").First.Item("valor") <> row.Cells(1).Value.ToString Then
                    strCambios.Append("update nomina.dbo.validaciones_procnomina set valor='" & row.Cells(1).Value & "' where variable='" & row.Cells(0).Value & "';")
                End If
            Next

            If strCambios.ToString.Length > 0 Then
                If MessageBox.Show("Existen cambios realizados a la lista de reporte de prenómina, ¿Deseas continuar?",
                                   "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    sqlExecute(strCambios.ToString)
                End If
            End If

            MessageBox.Show("Cambios realizados", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub
End Class