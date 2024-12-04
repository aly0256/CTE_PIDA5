Imports System.IO
Imports System.Data.OleDb

Public Class frmCargaMasivaTarjetas

    Dim sArchivo As String = ""
    Dim EsError As Boolean = False

    Private Sub btnSeleccionarArchivo_Click(sender As Object, e As EventArgs) Handles btnSeleccionarArchivo.Click
        Try

            Dim ofd As New OpenFileDialog

            ofd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            ofd.Filter = "Excel(CSV)|*.CSV"
            ofd.Title = "Seleccione el archivo csv"
            ofd.Multiselect = False
            ofd.RestoreDirectory = True

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                sArchivo = ofd.FileName.ToString.Trim
                txtArchivoCarga.Text = Path.GetFileName(sArchivo)
                btnIniciarCarga.Enabled = True

            Else
                btnIniciarCarga.Enabled = False
            End If

        Catch ex As Exception
            btnIniciarCarga.Enabled = False
            EsError = True
            MessageBox.Show("Se presentó un error al seleccionar archivo para carga masiva.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnIniciarCarga_Click(sender As Object, e As EventArgs) Handles btnIniciarCarga.Click

        Dim conn As OleDbConnection = Nothing
        Dim dtTargetasMasivo As New DataTable
        Dim i As Long = 0

        Try

            cpActualizacion.Visible = False
            cpActualizacion.Text = "Procesando..."
            cpActualizacion.Minimum = 0
            cpActualizacion.Value = 0


            Try
                Dim strConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Path.GetDirectoryName(sArchivo) & ";Extended Properties='text;HDR=Yes;FMT=Delimited;CharacterSet=65001;'"

                conn = New OleDbConnection(strConnString)

                conn.Open()

                Dim query = "SELECT * FROM [" + Path.GetFileName(sArchivo) + "]"

                Dim da As New OleDbDataAdapter(query, conn)

                da.Fill(dtTargetasMasivo)
                da.Dispose()

                EsError = False

            Catch ex As Exception
                EsError = True
                MessageBox.Show("Se presentó un error al intentar importar los numeros de tarjeta masiva", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
                conn.Dispose()
            End Try


            If Not EsError Then

                If Not dtTargetasMasivo.Columns.Contains("Reloj") Then
                    MessageBox.Show("No se encontró el encabezado 'Reloj'", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If Not dtTargetasMasivo.Columns.Contains("Num_Tarjeta") Then
                    MessageBox.Show("No se encontró el encabezado 'Num_Tarjeta'", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                If Not dtTargetasMasivo.Rows.Count > 0 Then
                    MessageBox.Show("No hay información de tarjetas que cargar.", "No hay datos para cargar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                cpActualizacion.Text = "Procesando..."
                cpActualizacion.Visible = True
                cpActualizacion.Maximum = dtTargetasMasivo.Rows.Count

                For Each dRow As DataRow In dtTargetasMasivo.Rows

                    Dim rl As String = Trim(IIf(IsDBNull(dRow("Reloj")), "", dRow("Reloj")))
                    Dim num_tarjeta As String = Trim(IIf(IsDBNull(dRow("Num_Tarjeta")), "", dRow("Num_Tarjeta")))

                    If rl <> "" Then

                        rl = rl.PadLeft(6, "0")

                        If Not sqlExecute("update personal set tarjeta_bonos = '" & num_tarjeta & "' where reloj = '" & rl & "'").Columns.Contains("ERROR") Then

                            i = i + 1

                            cpActualizacion.Value = i

                            Application.DoEvents()

                        End If

                    End If

                Next

            End If

            cpActualizacion.Text = "Finalizado..."

            MessageBox.Show("Se cargaron: " & i & " de " & dtTargetasMasivo.Rows.Count, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar cargar los numeros de targeta masivos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmCargaMasivaTargetas_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnIniciarCarga.Enabled = False
        cpActualizacion.Visible = False
    End Sub

    Private Sub frmCargaMasivaTargetas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class

