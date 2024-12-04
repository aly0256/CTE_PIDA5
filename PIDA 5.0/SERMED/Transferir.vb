Public Class Transferir

    Public directorioOrigen As String = ""
    Public baseDestino As String = "personal"
    Public tablaOrigen As String = ""
    Public tablaDestino As String = ""

    Public campos As New ArrayList

    Public valoresOrigen As New ArrayList
    Public valoresDestino As New ArrayList


    Public nueva As Boolean = False

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles botonSeleccionarDirectorio.Click
        Try
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                directorioOrigen = FolderBrowserDialog1.SelectedPath
                campoDirectorio.Text = directorioOrigen
                OpenFileDialog1.InitialDirectory = directorioOrigen
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub botonSeleccionarTabla_Click(sender As Object, e As EventArgs) Handles botonSeleccionarTabla.Click
        Try            
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                tablaOrigen = OpenFileDialog1.SafeFileName
                campoTabla.Text = tablaOrigen
            End If

            If directorioOrigen <> "" And tablaOrigen <> "" Then
                'DataGridView1.DataSource = consultaDBase("select * from '" & tablaOrigen & "'", directorioOrigen)

                Try

                    Dim MyConnection As System.Data.OleDb.OleDbConnection
                    'Dim DtSet As System.Data.DataSet                    
                    Dim dtPersonalVFP As New DataTable

                    MyConnection = New System.Data.OleDb.OleDbConnection("Provider=vfpoledb;" & _
                    "Data Source=" + directorioOrigen + ";Extended Properties=dBase IV")

                    MyConnection.Open()
                    'MyCommand = New System.Data.OleDb.OleDbDataAdapter(strQuery, MyConnection)

                    Dim dtCampos As DataTable = MyConnection.GetSchema("columns", New String() {directorioOrigen, "", tablaOrigen})

                    If dtCampos.Rows.Count > 0 Then

                        'DataGridView2.DataSource = dtCampos

                        For Each row As DataRow In dtCampos.Rows                            
                            campos.Add(row("column_name"))
                        Next
                        ListBox1.Items.Clear()
                        For Each campo As String In campos
                            ListBox1.Items.Add(campo)
                        Next
                    End If

                    'MyCommand.Fill(dtPersonalVFP)
                    MyConnection.Close()
                Catch ex As Exception
                End Try

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim myconnection = New System.Data.SqlClient.SqlConnection(campoHost.Text & ";Initial Catalog=" & campoBase.Text & ";Persist Security Info=True; User ID=" & campoUsuario.Text & "; Password=" & campoPassword.Text & ";")
            

            MyConnection.Open()            

            Dim dtCampos As DataTable = myconnection.GetSchema("tables")

            If dtCampos.Rows.Count > 0 Then

                ComboBox1.Items.Clear()

                For Each row As DataRow In dtCampos.Rows
                    ComboBox1.Items.Add(row("table_name"))
                Next
                ComboBox1.SelectedIndex = 0
            End If

            MyConnection.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim dtPrueba As DataTable = consultaDBase("select * from " & tablaOrigen, directorioOrigen)

            sqlExecute("truncate table " & tablaDestino, baseDestino)

            If dtPrueba.Rows.Count > 0 Then

                pb1.Value = 0
                pb1.Maximum = dtPrueba.Rows.Count
                For Each row As DataRow In dtPrueba.Rows

                    Dim q As String

                    If tablaDestino = "visitas" Or tablaDestino = "expediente_med" Then
                        q = construirQuery(row, completar(pb1.Value, 6))
                    Else
                        q = construirQuery(row)
                    End If

                    'Dim q As String = construirQuery(row)
                    sqlExecute(q, campoBase.Text)

                    pb1.Value += 1

                Next
                DataGridView2.DataSource = sqlExecute("select * from " & tablaDestino, baseDestino)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function completar(i As Integer, l As Integer) As String
        Dim s As String = i.ToString

        While s.Length < l
            s = "0" & s
        End While

        Return s
    End Function

    Public Function construirQuery(row As DataRow, Optional ByVal i As String = "000000")
        Dim q As String = ""
        q += "insert into "
        q += tablaDestino ' aqui va la tabla destino
        q += " ( "

        If tablaDestino = "visitas" Then
            q += "cod_visita,"
        End If

        If tablaDestino = "expediente_med" Then
            q += "cod_consulta,"
        End If

        For Each campo As String In campos
            q += " " & campo & ","
        Next

        q = q.Substring(0, q.Length - 1)

        q += " ) "
        q += " values "
        q += " ( "

        If tablaDestino = "visitas" Then
            q += " '" & i & "',"
        End If

        If tablaDestino = "expediente_med" Then
            q += " '" & i & "',"
        End If

        For Each campo As String In campos
            q += " '" & row(campo) & "',"
        Next

        q = q.Substring(0, q.Length - 1)

        q += " ) "
        Return q
    End Function

    Private Sub Transferir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        campoHost.Text = Declaraciones.SQLConn
        campoUsuario.Text = Declaraciones.sUserAdmin
        campoPassword.Text = Declaraciones.sPassword
        campoBase.Text = "personal"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        tablaDestino = ComboBox1.Text
    End Sub

    Private Sub campoBase_TextChanged(sender As Object, e As EventArgs) Handles campoBase.TextChanged
        baseDestino = campoBase.Text
    End Sub
End Class