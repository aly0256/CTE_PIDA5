Public Class frmAgregarPrestamoU
    Dim CambiarReloj As Boolean
    Dim dtArticulo As DataTable
    Dim dtRegistro As DataTable
    Private Sub frmAgregarPrestamoU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmbUniforme.DataSource = sqlExecute("SELECT COD_UNIF As 'Código',NOMBRE as 'Nombre'FROM uniformes", "HERRAMIENTAS")
            MostrarInformacion(Reloj)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub MostrarInformacion(Optional ByRef RELOJ As String = "")
        If cmbUniforme.SelectedValue Is Nothing Then Exit Sub

        If RELOJ <> "" Then
            dtRegistro = sqlExecute("SELECT RELOJ,NOMBRES,BAJA from personalvw WHERE RELOJ ='" & RELOJ & "'", )
            txtReloj.Text = dtRegistro.Rows(0).Item("RELOJ")
            txtNombre.Text = dtRegistro.Rows(0).Item("NOMBRES")
        End If
        dtArticulo = sqlExecute("SELECT * FROM uniformes WHERE COD_UNIF ='" & cmbUniforme.SelectedValue & "'", "HERRAMIENTAS")

        If dtArticulo.Rows.Count > 0 Then
            Dim dRow = dtArticulo.Rows(0)
            txtReposicion.Text = IIf(IsDBNull(dRow("DIAS_REP")), "", dRow("DIAS_REP").ToString.Trim)
            txtCosto.Text = IIf(IsDBNull(dRow("COSTO")), "", dRow("COSTO").ToString.Trim)
            txtFechaSalida.Value = Date.Now
            txtFechaEntrada.Value = Date.Now.AddDays(Integer.Parse(txtReposicion.Text))
            txtDisponibles.Text = IIf(IsDBNull(dRow("IN_STOCK")), "", dRow("IN_STOCK").ToString.Trim)
            txtPrestados.Text = IIf(IsDBNull(dRow("OUT_STOCK")), "", dRow("OUT_STOCK").ToString.Trim)
            cmbTallas.DataSource = getTallas()
            txtAPrestar.Value = 1
            txtAPrestar.MaxValue = IIf(IsDBNull(dRow("IN_STOCK")), 0, dRow("IN_STOCK"))
            txtObservacion.Text = ""
        Else
            txtReposicion.Text = "-"
            txtCosto.Value = 0
            txtFechaSalida.Value = Date.Now
            txtFechaEntrada.Value = Date.Now
            txtDisponibles.Text = "-"
            txtPrestados.Text = "-"
            txtAPrestar.Value = 0
            txtAPrestar.MaxValue = 0
            cmbTallas.SelectedValue = Nothing
            txtObservacion.Text = "-"
        End If

    End Sub
    Private Function getTallas() As DataTable
        Dim size As String = sqlExecute("SELECT TALLAS FROM uniformes WHERE COD_UNIF='" & cmbUniforme.SelectedValue & "'", "HERRAMIENTAS").Rows(0).Item("TALLAS")
        Dim TALLAS As DataTable = New DataTable

        TALLAS.Columns.Add("Tallas")
        Dim Talla() As String
        Talla = size.Split(";")
        For Each t In Talla
            TALLAS.Rows.Add({t})
        Next

        Return TALLAS
    End Function
    Private Function GenerarID() As String
        Return Date.Now.ToString.Replace(" ", "").Replace("/", "").Replace(".", "").Replace(":", "").Replace("PM", "").Replace("AM", "").Replace(",", "").Replace("pm", "").Replace("am", "")
    End Function
 
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim dtTemp As DataTable = sqlExecute("SELECT * FROM uniformes_por_empleado WHERE reloj = '" & txtReloj.Text & _
                                             "' AND cod_unif = '" & cmbUniforme.SelectedValue & "' AND FECHA_SAL = '" & txtFechaSalida.Text & "'", "HERRAMIENTAS")
        Dim dtTemp2 As DataTable = sqlExecute("SELECT * FROM uniformes WHERE cod_unif ='" & cmbUniforme.SelectedValue & "'", "HERRAMIENTAS")
        If dtTemp.Rows.Count > 0 Then
            MessageBox.Show("El empleado ya tiene este artículo asignado con la misma fecha. " & _
                            "Para agregarlo, incremente la cantidad prestada en el anterior registro.", _
                            "Artículo ya registrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbUniforme.Focus()
        Else

            If txtAPrestar.Value > IIf(IsDBNull(dtTemp2.Rows(0).Item("IN_STOCK")), 0, dtTemp2.Rows(0).Item("IN_STOCK")) Or txtAPrestar.Value = 0 Then
                MessageBox.Show("La cantidad que deseas prestar no es válida o es insuficiente.", "Cantidad insuficiente de artículos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                sqlExecute("INSERT INTO uniformes_por_empleado (ID,RELOJ,COD_UNIF,FECHA_SAL,FECHA_ENT,TALLA,OBSERVACION,CANTIDAD,ENTREGADO) VALUES ('" & _
                           GenerarID() & "','" & txtReloj.Text & "','" & cmbUniforme.SelectedValue & "','" & FechaSQL(txtFechaSalida.Value) & "','" & _
                           FechaSQL(txtFechaEntrada.Value) & "','" & cmbTallas.SelectedValue & "','" & txtObservacion.Text & "','" & txtAPrestar.Value & "','" & _
                           IIf(txtReposicion.Value = 0, 1, 0) & "')", "HERRAMIENTAS")
                sqlExecute("UPDATE uniformes SET IN_STOCK = IN_STOCK - " & txtAPrestar.Value & ",OUT_STOCK = OUT_STOCK + " & txtAPrestar.Value & _
                           " WHERE cod_unif = '" & cmbUniforme.SelectedValue & "'", "HERRAMIENTAS")
            End If
        End If
        Me.Close()

    End Sub
 
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmbUniforme_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbUniforme.SelectedValueChanged
        MostrarInformacion()
    End Sub

    Private Sub txtFechaEntrada_Validated(sender As Object, e As EventArgs) Handles txtFechaEntrada.Validated
        txtReposicion.Value = DateDiff(DateInterval.Day, txtFechaSalida.Value, txtFechaEntrada.Value) + 1
    End Sub


    Private Sub txtFechaEntrada_Click(sender As Object, e As EventArgs) Handles txtFechaEntrada.Click

    End Sub

    Private Sub txtReposicion_ValueChanged(sender As Object, e As EventArgs) Handles txtReposicion.ValueChanged

    End Sub
End Class