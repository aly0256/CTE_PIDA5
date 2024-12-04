Public Class frmEditarPrestamo
    Dim CodigoDePrestamo As String
    Dim RelojPrestamo As String
    Dim FechaSal As String
    Dim vista_herramientas As String
    Dim dtRegistro As DataTable

    Private Sub frmEditarPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CodigoDePrestamo = frmHerramientasPersonal.CodigoArticulo
        RelojPrestamo = frmHerramientasPersonal.RelojEmp
        FechaSal = frmHerramientasPersonal.FechaSal

        cmbArticulo.DataSource = sqlExecute("SELECT articulos.COD_ART As 'Código',articulos.NOMBRE as 'Nombre',clasificacion.NOMBRE as 'Clasificación' FROM articulos JOIN clasificacion on articulos.COD_CLAS = clasificacion.COD_CLAS", "HERRAMIENTAS")
        dtRegistro = sqlExecute("SELECT  articulos_por_empleado.*,personalvw.NOMBRES,baja,articulos.*  " & _
                                "FROM articulos_por_empleado JOIN personal.dbo.personalVW ON articulos_por_empleado.RELOJ = personalvw.RELOJ " & _
                                "JOIN articulos ON articulos_por_empleado.COD_ART = articulos.COD_ART " & _
                                "WHERE articulos_por_empleado.reloj = '" & RelojPrestamo & "' AND articulos.cod_art = '" & CodigoDePrestamo & _
                                "' AND FECHA_SAL='" & FechaSal & "'", "HERRAMIENTAS")
        MostrarInformacion()
    End Sub
    Private Sub MostrarInformacion(Optional ByRef RELOJ As String = "", Optional ByRef NOMBRE As String = "")
        If dtRegistro.Rows.Count=0 then Exit Sub 
        Dim dRow = dtRegistro.Rows(0)
        txtReloj.Text = dRow("RELOJ")
        txtNombre.Text = dRow("NOMBRES")
        EsBaja = Not IsDBNull(dRow("BAJA"))
        lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
        lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
     
        txtReposicion.Text = IIf(IsDBNull(dRow("DIAS_REP")), "", dRow("DIAS_REP").ToString.Trim)
        txtCosto.Text = IIf(IsDBNull(dRow("COSTO")), "", dRow("COSTO").ToString.Trim)
        txtFechaSalida.Value = IIf(IsDBNull(dRow("FECHA_SAL")), "", dRow("FECHA_SAL").ToString.Trim)
        txtFechaEntrada.Value = IIf(IsDBNull(dRow("FECHA_ENT")), "", dRow("FECHA_ENT").ToString.Trim)
        txtDisponibles.Text = IIf(IsDBNull(dRow("IN_STOCK")), "", dRow("IN_STOCK").ToString.Trim)
        txtPrestados.Text = IIf(IsDBNull(dRow("CANTIDAD")), "", dRow("CANTIDAD").ToString.Trim)
        txtControl.Text = IIf(IsDBNull(dRow("CONTROL")), "", dRow("CONTROL").ToString.Trim)
        cmbArticulo.SelectedValue = IIf(IsDBNull(dRow("COD_ART")), "", dRow("COD_ART").ToString.Trim)
        txtObservacion.Text = IIf(IsDBNull(dRow("OBSERVACION")), "", dRow("OBSERVACION").ToString.Trim)
        txtAPrestar.Value = IIf(IsDBNull(dRow("CANTIDAD")), 0, dRow("CANTIDAD"))
        txtAPrestar.MaxValue = IIf(IsDBNull(dRow("IN_STOCK")), 0, dRow("IN_STOCK"))
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim dtTemp As DataTable = sqlExecute("SELECT * FROM articulos WHERE COD_ART ='" & cmbArticulo.SelectedValue.ToString & "'", "HERRAMIENTAS")
        sqlExecute("UPDATE articulos_por_empleado SET FECHA_ENT = '" & txtFechaEntrada.Text & "',CONTROL = '" & txtControl.Text & "',OBSERVACION = '" & _
                   txtObservacion.Text & "' WHERE reloj = '" & RelojPrestamo & "' AND cod_art = '" & CodigoDePrestamo & _
                   "' AND FECHA_SAL = '" & FechaSal & "'", "HERRAMIENTAS")

        If txtPrestados.Value <> txtAPrestar.Value Then
            If txtAPrestar.Value > IIf(IsDBNull(dtTemp.Rows(0).Item("IN_STOCK")), 0, dtTemp.Rows(0).Item("IN_STOCK")) Or txtAPrestar.Value = 0 Then
                MessageBox.Show("La cantidad que deseas prestar no es válida o es insuficiente.", "Cantidad insuficiente de articulos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else

                sqlExecute("UPDATE articulos_por_empleado SET cantidad = " & txtAPrestar.Value & " WHERE reloj = '" & RelojPrestamo & "' AND cod_art = '" & CodigoDePrestamo & _
                           "' AND FECHA_SAL = '" & FechaSal & "'", "HERRAMIENTAS")

                sqlExecute("UPDATE articulos SET IN_STOCK = IN_STOCK - " & txtAPrestar.Value & ",OUT_STOCK = OUT_STOCK + " & txtAPrestar.Value & _
                           " WHERE COD_ART = '" & cmbArticulo.SelectedValue & "'", "HERRAMIENTAS")
            End If
        End If
        Me.Close()
    End Sub
    Private Sub txtAPrestar_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub Recibir_Click(sender As Object, e As EventArgs) Handles Recibir.Click
        Dim dtTemp As DataTable = sqlExecute("SELECT * FROM articulos WHERE COD_ART ='" & cmbArticulo.SelectedValue & "'", "HERRAMIENTAS")

        If MessageBox.Show("El empleado está regresando el artículo " & cmbArticulo.SelectedValue.ToString.Trim & " con fecha del día de hoy. " & _
                           vbCrLf & "¿Está seguro de continuar?", "Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sqlExecute("UPDATE articulos_por_empleado SET ENTREGADO = '1',USUARIO = '" & Usuario & "',FECHA_DEV ='" & FechaSQL(Date.Now) & _
                       "' WHERE reloj = '" & RelojPrestamo & "' AND cod_art = '" & CodigoDePrestamo & _
                       "' AND FECHA_SAL = '" & FechaSal & "'", "HERRAMIENTAS")
            sqlExecute("UPDATE articulos SET IN_STOCK = IN_STOCK + '" & dtRegistro.Rows(0).Item("CANTIDAD") & _
                       "',OUT_STOCK = OUT_STOCK - '" & dtRegistro.Rows(0).Item("CANTIDAD") & _
                       "' WHERE COD_ART = '" & cmbArticulo.SelectedValue & "'", "HERRAMIENTAS")
            Me.Close()
        End If
       
    End Sub
End Class