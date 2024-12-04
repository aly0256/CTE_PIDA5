Public Class frmEditarPrestamoU
    Dim CodigoDePrestamo As String
    Dim RelojPrestamo As String
    Dim FechaSal As String
    Dim vista_herramientas As String
    Dim dtRegistro As DataTable

    Private Sub frmEditarPrestamoU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CodigoDePrestamo = frmUniformesPersonal.Codigouniforme
        RelojPrestamo = frmUniformesPersonal.RelojEmp
        FechaSal = frmUniformesPersonal.FechaSal

        cmbUniforme.DataSource = sqlExecute("SELECT uniformes.cod_unif As 'Código',uniformes.NOMBRE as 'Nombre' FROM uniformes", "HERRAMIENTAS")
        dtRegistro = sqlExecute("SELECT  uniformes_por_empleado.*,personalvw.NOMBRES,baja,uniformes.*  " & _
                                "FROM uniformes_por_empleado JOIN personal.dbo.personalVW ON uniformes_por_empleado.RELOJ = personalvw.RELOJ " & _
                                "JOIN uniformes ON uniformes_por_empleado.cod_unif = uniformes.cod_unif " & _
                                "WHERE uniformes_por_empleado.reloj = '" & RelojPrestamo & "' AND uniformes.cod_unif = '" & CodigoDePrestamo & _
                                "' AND FECHA_SAL='" & FechaSal & "'", "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub MostrarInformacion(Optional ByRef RELOJ As String = "", Optional ByRef NOMBRE As String = "")
        If dtRegistro.Rows.Count=0 then Exit Sub 
        Dim dRow = dtRegistro.Rows(0)

        txtReloj.Text = dtRegistro.Rows(0).Item("RELOJ")
        txtNombre.Text = dtRegistro.Rows(0).Item("NOMBRES")
        cmbUniforme.SelectedValue = dtRegistro.Rows(0).Item("COD_UNIF")
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
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim dtTemp As DataTable = sqlExecute("SELECT * FROM uniformes WHERE cod_unif ='" & cmbuniforme.SelectedValue.ToString & "'", "HERRAMIENTAS")


        If txtPrestados.Value <> txtAPrestar.Value Then
            If txtAPrestar.Value > IIf(IsDBNull(dtTemp.Rows(0).Item("IN_STOCK")), 0, dtTemp.Rows(0).Item("IN_STOCK")) Or txtAPrestar.Value = 0 Then
                MessageBox.Show("La cantidad que deseas prestar no es válida o es insuficiente.", "Cantidad insuficiente de uniformes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                sqlExecute("UPDATE uniformes_por_empleado SET cantidad = " & txtAPrestar.Value & " WHERE reloj = '" & RelojPrestamo & "' AND cod_unif = '" & CodigoDePrestamo & _
                           "' AND FECHA_SAL = '" & FechaSal & "'", "HERRAMIENTAS")

                sqlExecute("UPDATE uniformes SET IN_STOCK = IN_STOCK - " & txtAPrestar.Value & ",OUT_STOCK = OUT_STOCK + " & txtAPrestar.Value & _
                           " WHERE cod_unif = '" & cmbuniforme.SelectedValue & "'", "HERRAMIENTAS")
            End If
        End If

        sqlExecute("UPDATE uniformes_por_empleado SET FECHA_ENT = '" & txtFechaEntrada.Text & "',TALLA = '" & cmbTallas.SelectedValue & "',OBSERVACION = '" & _
           txtObservacion.Text & "' WHERE reloj = '" & RelojPrestamo & "' AND cod_unif = '" & CodigoDePrestamo & _
           "' AND FECHA_SAL = '" & FechaSal & "'", "HERRAMIENTAS")
        Me.Close()
    End Sub
    Private Sub txtAPrestar_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub Recibir_Click(sender As Object, e As EventArgs) Handles Recibir.Click
        Dim dtTemp As DataTable = sqlExecute("SELECT * FROM uniformes WHERE cod_unif ='" & cmbuniforme.SelectedValue & "'", "HERRAMIENTAS")

        If MessageBox.Show("El empleado está regresando el artículo " & cmbuniforme.SelectedValue.ToString.Trim & " con fecha del día de hoy. " & _
                           vbCrLf & "¿Está seguro de continuar?", "Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sqlExecute("UPDATE uniformes_por_empleado SET ENTREGADO = '1',USUARIO = '" & Usuario & "',FECHA_DEV ='" & FechaSQL(Date.Now) & _
                       "' WHERE reloj = '" & RelojPrestamo & "' AND cod_unif = '" & CodigoDePrestamo & _
                       "' AND FECHA_SAL = '" & FechaSal & "'", "HERRAMIENTAS")
            sqlExecute("UPDATE uniformes SET IN_STOCK = IN_STOCK + '" & dtRegistro.Rows(0).Item("CANTIDAD") & _
                       "',OUT_STOCK = OUT_STOCK - '" & dtRegistro.Rows(0).Item("CANTIDAD") & _
                       "' WHERE cod_unif = '" & cmbUniforme.SelectedValue & "'", "HERRAMIENTAS")
            Me.Close()
        End If

    End Sub
End Class