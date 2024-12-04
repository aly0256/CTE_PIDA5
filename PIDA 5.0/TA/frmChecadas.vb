Public Class frmChecadas

    Private Sub TextBoxX1_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Dim duracionregistro As Integer = 0


    Private Sub frmChecadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1133, 526)
        Me.TopMost = True
        txtReloj.Focus()

        Application.DoEvents()
        PictureBox2.Image = My.Resources.NoFoto
        lblNombre.Text = "Nombre, Nombre Nombre"
        lblReloj.Text = "000000"
        lblDepto.Text = "N/A"
        lblSuper.Text = "N/A"
        lblTurno.Text = "N/A"
        lblHorario.Text = "N/A"
        ' dtPersonal = sqlExecute("select * from personalvw where baja is null")
        '    dtPersonal.PrimaryKey = New DataColumn() {dtPersonal.Columns("gafete")}
        lblAviso.Text = "<<Desliza tu gafete por el lector>>"
        Application.DoEvents()
        Timer1.Start()
        Timer3.Start()
        txtReloj.Text = "0000000000"
        txtReloj.Focus()
        txtReloj.Select(0, 10)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If lblAviso.ForeColor = Color.PaleVioletRed Then
            lblAviso.ForeColor = Color.Blue
        Else
            lblAviso.ForeColor = Color.PaleVioletRed
        End If



    End Sub

    Private Sub txtReloj_TextChanged(sender As Object, e As EventArgs) Handles txtReloj.TextChanged


        'Dim largo_reloj As Integer = 0

        'If txtReloj.Text.Length >= 6 Then

        'Else
        '    largo_reloj = txtReloj.Text.Length
        'End If
        'If Not RevisarAccesos("HABILITAR_TECLADO") Then
        '    MessageBox.Show("La captura por teclado esta deshabilitada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        '    txtReloj.Text = "000000"
        '    txtReloj.Focus()
        '    txtReloj.Select(0, 6)
        'End If


    End Sub

    Private Sub txtReloj_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReloj.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            Application.DoEvents()
            Timer2.Stop()
            tiempo_teclado = 0
            '  Dim dtreloj As DataRow = dtPersonal.Rows.Find(txtReloj.Text)
            Dim compa As String = ""

            Dim dtpersonal_temp As DataTable = sqlExecute("select * from personalvw where gafete = '" & txtReloj.Text & "'")
            If dtpersonal_temp.Rows.Count > 0 Then
                Dim dr_temp As DataRow = dtpersonal_temp.Rows(0)
                PictureBox2.ImageLocation = IIf(IsDBNull(dr_temp("foto")), "N/A", dr_temp("foto").ToString.Trim)
                lblNombre.Text = IIf(IsDBNull(dr_temp("nombres")), "N/A", dr_temp("nombres").ToString.Trim)
                lblReloj.Text = IIf(IsDBNull(dr_temp("reloj")), "N/A", dr_temp("reloj").ToString.Trim)
                lblDepto.Text = IIf(IsDBNull(dr_temp("nombre_depto")), "N/A", dr_temp("nombre_depto").ToString.Trim)
                lblSuper.Text = IIf(IsDBNull(dr_temp("nombre_super")), "N/A", dr_temp("nombre_super").ToString.Trim)
                lblTurno.Text = IIf(IsDBNull(dr_temp("cod_turno")), "N/A", dr_temp("cod_turno").ToString.Trim)
                lblHorario.Text = IIf(IsDBNull(dr_temp("nombre_horario")), "N/A", dr_temp("nombre_horario").ToString.Trim)
                compa = IIf(IsDBNull(dr_temp("cod_comp")), "N/A", dr_temp("cod_comp").ToString.Trim)
                lblAviso.Text = "<<Correcto>>"
                Timer4.Start()
            Else
                PictureBox2.Image = My.Resources.NoFoto
                lblNombre.Text = "Nombre, Nombre Nombre"
                lblReloj.Text = "000000"
                lblDepto.Text = "N/A"
                lblSuper.Text = "N/A"
                lblTurno.Text = "N/A"
                lblHorario.Text = "N/A"
                compa = "090"
                lblAviso.Text = "<<No encontrado>>"
                Timer4.Start()
                txtReloj.Focus()
                txtReloj.Select(0, 10)
                Exit Sub
            End If




            Dim horasql As DataTable = sqlExecute("select getdate() as hora")
            Dim hora As String = "00:00"
            If horasql.Rows.Count > 0 Then
                hora = Date.Parse(horasql.Rows(0).Item("hora")).Hour.ToString.PadLeft(2, "0") & ":" & Date.Parse(horasql.Rows(0).Item("hora")).Minute.ToString.PadLeft(2, "0")
            End If

            sqlExecute("insert into hrs_brt_cafeteria (cod_comp,reloj,fecha,hora,nEventLogIdn) values ('" & compa & "', '" & lblReloj.Text & "',getdate(),'" & hora & "','99999')", "TA")
            txtReloj.Focus()
            txtReloj.Select(0, 10)

            Application.DoEvents()
        ElseIf Not IsNumeric(e.KeyChar) Then
            e.Handled = True

        Else
            If tiempo_teclado = 0 Then
                Timer2.Start()
            End If


        End If
    End Sub


    Private Sub frmChecadas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        PictureBox2.Image = My.Resources.NoFoto
        lblNombre.Text = "Nombre, Nombre Nombre"
        lblReloj.Text = "000000"
        lblDepto.Text = "N/A"
        lblSuper.Text = "N/A"
        lblTurno.Text = "N/A"
        lblHorario.Text = "N/A"

    End Sub

    Private Sub txtReloj_Click(sender As Object, e As EventArgs) Handles txtReloj.Click

        If Not RevisarAccesos("HABILITAR_TECLADO_CAFE") Then

            MessageBox.Show("La captura por teclado esta deshabilitada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


            txtReloj.Text = "0000000000"
            txtReloj.Focus()
            txtReloj.Select(0, 10)
        Else
            txtReloj.Text = "0000000000"
            txtReloj.Focus()
            txtReloj.Select(0, 10)
        End If

    End Sub
    Public Function RevisarAccesos(caracteristica As String) As Boolean
        Try

            Dim dtAcceso As DataTable
            dtAcceso = sqlExecute("select top  1 * from variables where variable  = '" & caracteristica & "'", "Kiosco")
            If dtAcceso.Rows.Count > 0 Then
                If dtAcceso.Rows(0).Item("valor").ToString.Equals("1") Then
                    Return True
                Else
                 
                    Return False
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Dim tiempo_teclado As Integer = 0
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        tiempo_teclado = tiempo_teclado + 1

        If tiempo_teclado > 1 Then
            If Not RevisarAccesos("HABILITAR_TECLADO_CAFE") Then
                Timer2.Stop()
                tiempo_teclado = 0
                MessageBox.Show("La captura por teclado esta deshabilitada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                PictureBox2.Image = My.Resources.NoFoto
                lblNombre.Text = "N/A"
                lblReloj.Text = "000000"
                lblDepto.Text = "N/A"
                lblSuper.Text = "N/A"
                lblTurno.Text = "N/A"
                lblHorario.Text = "N/A"
                txtReloj.Text = "0000000000"
                txtReloj.Focus()
                txtReloj.Select(0, 10)

            End If
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Dim horasql As DataTable = sqlExecute("select getdate() as hora")
        Dim hora As String = "00:00"
        If horasql.Rows.Count > 0 Then
            hora = Date.Parse(horasql.Rows(0).Item("hora")).Hour.ToString.PadLeft(2, "0") & ":" & Date.Parse(horasql.Rows(0).Item("hora")).Minute.ToString.PadLeft(2, "0")
            lblHora.Text = hora.ToString
            lblFecha.Text = FechaLetra(Date.Parse(horasql.Rows(0).Item("hora")))
        End If
    End Sub
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        If duracionregistro > 4 Then 'cambiar tiempo de mostrar empleado
            duracionregistro = 0
            Timer4.Stop()
            lblAviso.Text = "<<Desliza tu gafete por el lector>>"

        Else
            duracionregistro = duracionregistro + 1
        End If
    End Sub
End Class