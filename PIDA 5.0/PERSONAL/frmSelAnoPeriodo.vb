Public Class frmSelAnoPeriodo

    Private Sub frmSelAnoPeriodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarPeriodos()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            seleccionado = cmbPeriodos.SelectedValue
            Dim _anoPagaNom As String = "", _perPagaNom As String = ""
            If seleccionado.ToString.Trim <> "" Then
                _anoPagaNom = seleccionado.Substring(0, 4)
                _perPagaNom = seleccionado.Substring(4, 2)
                Dim dtNomPag As DataTable = sqlExecute("select TOP 1 * from NOMINA.dbo.nomina where ano+periodo='" & _anoPagaNom & _perPagaNom & "'", "NOMINA")
                If Not dtNomPag.Columns.Contains("Error") And dtNomPag.Rows.Count > 0 Then
                    MessageBox.Show("El periodo seleccionado para pago de nómina ya se encuentra cerrado y pagado, favor de seleccionar otro", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If

            If seleccionado = Nothing Then
                MessageBox.Show("Favor de seleccionar un periodo para pago en nómina", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Me.Close()
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try

    End Sub

    ''' <summary>
    ''' 'Método para cargar periodos al comboBox en la captura de vacaciones para el pago de la nómina
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub CargarPeriodos(Optional ByVal fecha As Date = Nothing)
        Try
            Dim fHoy As Date = Date.Now, Query As String = "", dtTemp As New DataTable, dtPeriodos As New DataTable

            If fecha = Nothing Then fecha = fHoy

            Query = "select top 1 ANO+PERIODO as 'seleccionado' from TA.dbo.periodos where FECHA_INI<='" & FechaSQL(fecha) & "' and FECHA_FIN>='" & FechaSQL(fecha) & "'"
            dtTemp = sqlExecute(Query, "TA")

            If Not dtTemp.Columns.Contains("Error") And dtTemp.Rows.Count > 0 Then

                Query = "select distinct ano+periodo as seleccionado,ANO,PERIODO,FECHA_INI,FECHA_FIN,FECHA_PAGO from periodos order by ANO desc,periodo"
                dtPeriodos = sqlExecute(Query, "TA")
                cmbPeriodos.DataSource = dtPeriodos

                cmbPeriodos.SelectedValue = dtTemp.Rows(0).Item("seleccionado")
                seleccionado = dtTemp.Rows(0).Item("seleccionado")
            Else
                cmbPeriodos.SelectedIndex = 0
                seleccionado = Nothing
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class