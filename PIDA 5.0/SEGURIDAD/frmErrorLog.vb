Public Class frmErrorLog

    Public dtErrorLog As DataTable


    Private Sub frmErrorLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Try

            dtpFecha.Value = Now

            Dim dtUsuarios As DataTable = sqlExecute("select rtrim(username) as username, cod_perfil from appuser", "seguridad")
            dtUsuarios.Rows.Add({"TODOS", "TODOS"})
            cmbUsuarios.DataSource = dtUsuarios
            cmbUsuarios.DisplayMembers = "username, cod_perfil"
            cmbUsuarios.ValueMember = "username"
            cmbUsuarios.GroupingMembers = "cod_perfil"
            cmbUsuarios.SelectedValue = "TODOS"

            Dim dtVersiones As DataTable = sqlExecute("select distinct version from errorlog order by version desc", "seguridad")
            dtVersiones.Rows.Add({"TODOS"})
            cmbVersion.DataSource = dtVersiones
            cmbVersion.DisplayMembers = "version"
            cmbVersion.ValueMember = "version"
            cmbVersion.SelectedValue = "TODOS"

            Dim dtorigen As DataTable = sqlExecute("select distinct rtrim(origen) as origen from errorlog order by origen asc", "seguridad")
            dtorigen.Rows.Add({"TODOS"})
            cmbOrigen.DataSource = dtorigen
            cmbOrigen.DisplayMembers = "origen"
            cmbOrigen.ValueMember = "origen"
            cmbOrigen.SelectedValue = "TODOS"


        Catch ex As Exception

        End Try
    End Sub


    Private Sub mostrarinformacion()
        Try
            Dim q As String = "select ID,  convert(date, fechahora) as Fecha, convert(time, fechahora) as Hora, rtrim(Usuario) as Usuario, rtrim(Origen) as Origen, rtrim(Version) as Version, rtrim(Procedimiento) as Procedimiento, rtrim(Forma) as Forma, ErrNum, ErrDesc, Comentarios from errorlog where convert(date, fechahora) = '" & FechaSQL(dtpFecha.Value) & "'"
            q &= IIf(cmbUsuarios.SelectedValue <> "TODOS", " and usuario = '" & RTrim(cmbUsuarios.SelectedValue) & "'", "") & ""
            q &= IIf(cmbVersion.SelectedValue <> "TODOS", " and version = '" & RTrim(cmbVersion.SelectedValue) & "'", "") & ""
            q &= IIf(cmbOrigen.SelectedValue <> "TODOS", " and origen = '" & RTrim(cmbOrigen.SelectedValue) & "'", "") & ""
            q &= " order by fecha desc, hora desc "
            dtErrorLog = sqlExecute(q, "seguridad")

            DataGridViewX1.DataSource = dtErrorLog            
            DataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbUsuarios_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbUsuarios.SelectedValueChanged
        Try
            mostrarinformacion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbVersion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVersion.SelectedValueChanged
        Try
            mostrarinformacion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbOrigen_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbOrigen.SelectedValueChanged
        Try
            mostrarinformacion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFechas_DateSelected(sender As Object, e As System.EventArgs) Handles dtpFecha.ValueChanged
        Try
            mostrarinformacion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            frmVistaPrevia.LlamarReporte("ErrorLog", dtErrorLog)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

   

    Private Sub DataGridViewX1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellClick
        Try
            RichTextBox1.Text = ""
            Try
                For Each cell As DataGridViewCell In DataGridViewX1.SelectedCells
                    RichTextBox1.Text &= cell.Value
                Next
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub
End Class