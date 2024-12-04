Public Class frmAgregarPrestamo
    Dim dtArticulo As DataTable
    Dim dtRegistro As DataTable
    Private Sub frmAgregarPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmbArticulo.DataSource = sqlExecute("SELECT articulos.COD_ART As 'Código',articulos.NOMBRE as 'Nombre',clasificacion.NOMBRE as 'Clasificación' " & _
                                                "FROM articulos JOIN clasificacion on articulos.COD_CLAS = clasificacion.COD_CLAS", "HERRAMIENTAS")
            MostrarInformacion(Reloj)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
        MostrarInformacion(Reloj)
    End Sub
    Private Sub MostrarInformacion(Optional ByRef RELOJ As String = "")
        If RELOJ <> "" Then
            dtRegistro = sqlExecute("SELECT RELOJ,NOMBRES,BAJA from personalvw WHERE RELOJ ='" & RELOJ & "'", )
            txtReloj.Text = dtRegistro.Rows(0).Item("RELOJ")
            txtNombre.Text = dtRegistro.Rows(0).Item("NOMBRES")
        End If

        If cmbArticulo.SelectedValue Is Nothing Then Exit Sub

        dtArticulo = sqlExecute("SELECT articulos.*,clasificacion.NOMBRE as 'Clasificación' " & _
                                "FROM articulos JOIN clasificacion on articulos.COD_CLAS = clasificacion.COD_CLAS " & _
                                "WHERE articulos.COD_ART ='" & cmbArticulo.SelectedValue & "'", "HERRAMIENTAS")

        If dtArticulo.Rows.Count > 0 Then
            Dim dRow = dtArticulo.Rows(0)
            txtReposicion.Text = IIf(IsDBNull(dRow("DIAS_REP")), "", dRow("DIAS_REP").ToString.Trim)
            txtCosto.Text = IIf(IsDBNull(dRow("COSTO")), "", dRow("COSTO").ToString.Trim)
            txtFechaSalida.Value = Date.Now
            txtFechaEntrada.Value = Date.Now.AddDays(Integer.Parse(txtReposicion.Text))
            txtDisponibles.Text = IIf(IsDBNull(dRow("IN_STOCK")), "", dRow("IN_STOCK").ToString.Trim)
            txtPrestados.Text = IIf(IsDBNull(dRow("OUT_STOCK")), "", dRow("OUT_STOCK").ToString.Trim)
            txtAPrestar.Value = 1
            txtAPrestar.MaxValue = IIf(IsDBNull(dRow("IN_STOCK")), 0, dRow("IN_STOCK"))
            txtControl.Text = ""
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
            txtControl.Text = "-"
            txtObservacion.Text = "-"

        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim dtTemp As DataTable = sqlExecute("SELECT * FROM articulos_por_empleado WHERE reloj = '" & txtReloj.Text & _
                                             "' AND cod_art = '" & cmbArticulo.SelectedValue & "' AND FECHA_SAL = '" & txtFechaSalida.Text & "'", "HERRAMIENTAS")
        Dim dtTemp2 As DataTable = sqlExecute("SELECT * FROM articulos WHERE COD_ART ='" & cmbArticulo.SelectedValue & "'", "HERRAMIENTAS")
        If dtTemp.Rows.Count > 0 Then
            MessageBox.Show("El empleado ya tiene este artículo asignado con la misma fecha. " & _
                            "Para agregarlo, incremente la cantidad prestada en el anterior registro.", _
                            "Artículo ya registrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbArticulo.Focus()
        Else

            If txtAPrestar.Value > IIf(IsDBNull(dtTemp2.Rows(0).Item("IN_STOCK")), 0, dtTemp2.Rows(0).Item("IN_STOCK")) Or txtAPrestar.Value = 0 Then
                MessageBox.Show("La cantidad que deseas prestar no es válida o es insuficiente.", "Cantidad insuficiente de artículos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                sqlExecute("INSERT INTO articulos_por_empleado (ID,RELOJ,COD_ART,FECHA_SAL,FECHA_ENT,CONTROL,OBSERVACION,CANTIDAD,ENTREGADO) VALUES ('" & _
                           GenerarID() & "','" & txtReloj.Text & "','" & cmbArticulo.SelectedValue & "','" & FechaSQL(txtFechaSalida.Value) & "','" & _
                           FechaSQL(txtFechaEntrada.Value) & "','" & txtControl.Text & "','" & txtObservacion.Text & "','" & txtAPrestar.Value & "','" & _
                           IIf(txtReposicion.Value = 0, 1, 0) & "')", "HERRAMIENTAS")
                sqlExecute("UPDATE articulos SET IN_STOCK = IN_STOCK - " & txtAPrestar.Value & ",OUT_STOCK = OUT_STOCK + " & txtAPrestar.Value & _
                           " WHERE COD_ART = '" & cmbArticulo.SelectedValue & "'", "HERRAMIENTAS")
            End If
        End If
        Me.Close()
    End Sub
    Private Function GenerarID() As String
        Return Date.Now.ToString.Replace(" ", "").Replace("/", "").Replace(".", "").Replace(":", "").Replace("PM", "").Replace("AM", "").Replace(",", "").Replace("pm", "").Replace("am", "")
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Me.Close()
    End Sub

    Private Sub cmbArticulo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbArticulo.SelectedValueChanged
        MostrarInformacion()
    End Sub

    Private Sub txtFechaEntrada_Click(sender As Object, e As EventArgs) Handles txtFechaEntrada.Click

    End Sub

    Private Sub txtFechaEntrada_Validated(sender As Object, e As EventArgs) Handles txtFechaEntrada.Validated
        txtReposicion.Value = DateDiff(DateInterval.Day, txtFechaSalida.Value, txtFechaEntrada.Value) + 1
    End Sub

    Private Sub txtReposicion_ValueChanged(sender As Object, e As EventArgs) Handles txtReposicion.ValueChanged

    End Sub
End Class