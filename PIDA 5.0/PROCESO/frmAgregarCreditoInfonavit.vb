Public Class frmAgregarCreditoInfonavit

    Public _reloj_agregar_infonavit As String = ""
    Public _nombres_agregar_infonavit As String = ""
    Public _fecha_alta As Date

    Private Sub frmAgregarCreditoInfonavit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtReloj.Text = _reloj_agregar_infonavit
            lblNombres.Text = _nombres_agregar_infonavit
            '      dtpAlta.Value = _fecha_alta

            Dim dtTipoInfonavit As New DataTable
            dtTipoInfonavit.Columns.Add("tipo")
            dtTipoInfonavit.Columns.Add("nombre")

            dtTipoInfonavit.Rows.Add({"1", "Porcentaje"})
            dtTipoInfonavit.Rows.Add({"2", "Cuota fija"})
            dtTipoInfonavit.Rows.Add({"3", "VSM"})

            cmbTipoInfonavit.DataSource = dtTipoInfonavit
            cmbTipoInfonavit.ValueMember = "tipo"

            dtpFechaInicioCreditoInfonavit.Value = Today
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim reloj As String = "", INFONAVIT As String = "", DIG_VER_IN As String = "", FECHA_CRE As String = "", TIPO_CRE As String = "", PAGO_INF As Double = 0.0, PAGO_SEGVI As Integer = 0, CREDITO_IN As Integer = 0
        Try : reloj = _reloj_agregar_infonavit : Catch ex As Exception : reloj = "" : End Try
        Try : INFONAVIT = txtNumeroCredito.Text.Trim : Catch ex As Exception : INFONAVIT = "" : End Try
        Try : DIG_VER_IN = INFONAVIT.Substring(10, 1).ToString.Trim : Catch ex As Exception : DIG_VER_IN = "" : End Try

        Try : FECHA_CRE = FechaSQL(dtpFechaInicioCreditoInfonavit.Value) : Catch ex As Exception : FECHA_CRE = "" : End Try
        Try : TIPO_CRE = cmbTipoInfonavit.SelectedValue : Catch ex As Exception : TIPO_CRE = "" : End Try
        Try : PAGO_INF = Double.Parse(txtFactorDeDescuentoInfonavit.Text) : Catch ex As Exception : PAGO_INF = 0.0 : End Try
        PAGO_SEGVI = 1
        CREDITO_IN = 1

        '----- Insertar en INFONAVIT
        sqlExecute("insert into infonavit (reloj, infonavit, activo, cobro_segv,usuario,fechahora) values ('" & reloj & "', '" & INFONAVIT & "', 1, 1,'" & Usuario & "',getdate())")

        sqlExecute("update infonavit set nombres = '" & _nombres_agregar_infonavit & "' where reloj = '" & reloj & "' and infonavit = '" & INFONAVIT & "'")
        sqlExecute("update infonavit set alta = '" & FechaSQL(_fecha_alta) & "' where reloj = '" & reloj & "' and infonavit = '" & INFONAVIT & "'")

        sqlExecute("update infonavit set tipo_cred = '" & cmbTipoInfonavit.SelectedValue & "' where reloj = '" & reloj & "' and infonavit = '" & INFONAVIT & "'")
        sqlExecute("update infonavit set cuota_cred = '" & txtFactorDeDescuentoInfonavit.Text & "' where reloj = '" & reloj & "' and infonavit = '" & INFONAVIT & "'")
        sqlExecute("update infonavit set inicio_cre = '" & FECHA_CRE & "' where reloj = '" & reloj & "' and infonavit = '" & INFONAVIT & "'")

        '--- Actualizar en PERSONAL  ::   update personal set INFONAVIT='',DIG_VER_IN='',FECHA_CRE='',TIPO_CRE='',PAGO_INF=0.0,PAGO_SEGVI=1,CREDITO_IN=1 where reloj='00002'
        Dim QUp As String = "update personal set INFONAVIT='" & INFONAVIT & "',DIG_VER_IN='" & DIG_VER_IN & "',FECHA_CRE='" & FECHA_CRE & "',TIPO_CRE='" & TIPO_CRE & "',PAGO_INF=" & PAGO_INF & ",PAGO_SEGVI=" & PAGO_SEGVI & ",CREDITO_IN=" & CREDITO_IN & " where reloj='" & reloj & "'"
        sqlExecute(QUp, "PERSONAL")

        Me.Dispose()
    End Sub



    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Me.Dispose()
    End Sub
End Class