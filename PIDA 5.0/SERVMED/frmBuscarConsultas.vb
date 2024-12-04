Public Class frmBuscarConsultas


    Dim dtPersonal As DataTable

    Dim BS As New BindingSource

    Private Sub frmBuscarConsultas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtPersonal = sqlExecute("select * from personalvw " & IIf(FiltroXUsuario.Trim <> "", "where " & FiltroXUsuario, "") & "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)
        Try
            Me.DialogResult = Windows.Forms.DialogResult.OK

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        Dim vl As String

        Try
            Dim dtSeleccion As New DataTable
            Dim vlAnt As String
            Dim vlDes As String
            Dim i As Integer
            dtSeleccion = dtPersonal.Clone
            vl = txtBusca.Text.Replace("*", "%")
            i = vl.IndexOf("%")

            If i >= 0 Then
                vlAnt = vl.Substring(0, i)
                vlDes = vl.Substring(i + 1)

                vl = "(reloj LIKE '%" & vlAnt & "%' OR nombres LIKE '%" & vlAnt & "%') AND (" & _
                    "reloj LIKE '%" & vlDes & "%' OR nombres LIKE '%" & vlDes & "%')"
            Else
                vl = "reloj LIKE '%" & vl & "%' OR nombres LIKE '%" & vl & "%'"
            End If


            For Each dDato As DataRow In dtPersonal.Select(vl)
                dtSeleccion.ImportRow(dDato)
            Next

            BS.DataSource = dtSeleccion
            navPersonal.BindingSource = BS

            'dgTabla.DataSource = BS
            'dgTabla.Columns("FOTO").Visible = False
            'dgTabla.Columns("CAMPOS_EXTRA").Visible = False

            txtReloj.DataBindings.Add("Text", BS, "reloj")
            txtNombre.DataBindings.Add("Text", BS, "nombres")
            txtCodComp.DataBindings.Add("Text", BS, "cod_comp")
            txtCia.DataBindings.Add("Text", BS, "compania")
            txtSuper.DataBindings.Add("Text", BS, "cod_super")
            txtSuperNombre.DataBindings.Add("Text", BS, "nombre_super")
            txtCodPlanta.DataBindings.Add("Text", BS, "cod_planta")
            txtPlanta.DataBindings.Add("Text", BS, "nombre_planta")
            txtCodTipo.DataBindings.Add("Text", BS, "cod_tipo")
            txtTipoEmp.DataBindings.Add("Text", BS, "nombre_tipoEmp")
            txtCodTurno.DataBindings.Add("Text", BS, "cod_hora")
            txtTurno.DataBindings.Add("Text", BS, "nombre_horario")
            txtCodPuesto.DataBindings.Add("Text", BS, "cod_puesto")
            txtPuesto.DataBindings.Add("Text", BS, "nombre_puesto")
            txtCodDepto.DataBindings.Add("Text", BS, "cod_depto")
            txtDepto.DataBindings.Add("Text", BS, "nombre_depto")
            txtImss.DataBindings.Add("Text", BS, "imss")
            txtDireccion.DataBindings.Add("Text", BS, "d_completa")
            txtEmergencia.DataBindings.Add("Text", BS, "aviso_acc")


            txtAlta.DataBindings.Add("Text", BS, "alta", True, DataSourceUpdateMode.Never, Nothing, "d")
            txtBaja.DataBindings.Add("Text", BS, "baja", True, DataSourceUpdateMode.Never, "------", "d")
            picFoto.DataBindings.Add("ImageLocation", BS, "foto")
            'lblDatoExtra.DataBindings.Add("Text", BS, "campos_extra")

           


        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtReloj_TextChanged(sender As Object, e As EventArgs) Handles txtReloj.TextChanged
        Try
            Dim dtConsultas As DataTable = sqlExecute("select consultas.folio, convert(date, consultas.inicio) as fecha, convert(time, consultas.inicio) as hora, consultas.cod_servicio, servicios.nombre as nombre_servicio, consultas.familiar, consultas.concluida from consultas left join servicios on servicios.cod_servicio = consultas.cod_servicio where consultas.reloj = '" & txtReloj.Text & "' order by fecha desc", "SERMED")
            dgDatos.DataSource = dtConsultas
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDatos.CellDoubleClick
        Try
            Dim folio As String = dgDatos.Rows(e.RowIndex).Cells("colFolio").Value
            Dim frm As New frmDetalleConsulta
            frm.folio = folio
            frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgDatos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDatos.CellContentClick

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub txtBaja_TextChanged(sender As Object, e As EventArgs) Handles txtBaja.TextChanged
        Try
            If txtBaja.Text = "------" Then
                LabelX1.Text = "ACTIVO"
                LabelX1.BackColor = Color.LimeGreen
            Else
                LabelX1.Text = "INACTIVO"
                LabelX1.BackColor = Color.IndianRed
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class