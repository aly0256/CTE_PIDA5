Public Class frmImportacion
    Public ImportaAnoPer As String
    Public ImportaArchivo As String

    Private Sub frmImportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'BERE
        'cmbPeriodo.DataSource = sqlExecute("SELECT concat(ano,periodo) AS unico,ano,periodo,fecha_ini,fecha_fin FROM periodos ORDER BY ano DESC,periodo", "TA")
        cmbPeriodo.DataSource = sqlExecute("SELECT (ano + periodo) AS unico,ano,periodo,fecha_ini,fecha_fin FROM periodos ORDER BY ano DESC,periodo", "TA")
        cmbPeriodo.SelectedValue = ImportaAnoPer

        txtArchivo.Text = ImportaArchivo
    End Sub

    Private Sub btnArchivo_Click(sender As Object, e As EventArgs) Handles btnArchivo.Click
        'dbArchivos.Title = "Ubicación de logotipo"
        'dbArchivos.FileName = txtLogo.Text
        'If dbArchivos.ShowDialog <> DialogResult.Cancel Then
        '    txtLogo.Text = dbArchivos.FileName
        'End If
        Try
            dbArchivos.FileName = ""
            dbArchivos.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            If dbArchivos.ShowDialog <> DialogResult.Cancel Then
                ImportaArchivo = dbArchivos.FileName
                txtArchivo.Text = ImportaArchivo
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim ResultadoImportacion As System.Exception
        Try
            'ResultadoImportacion = ImportacionManual(cmbPeriodo.SelectedValue)
            ResultadoImportacion = ImportacionMySQL(cmbPeriodo.SelectedValue)
            If Not ResultadoImportacion Is Nothing Then
                Err.Raise(ResultadoImportacion.HResult, Nothing, ResultadoImportacion.Message)
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Abort
            MessageBox.Show("Se detectaron errores durante la importación." & vbCrLf & "Error.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub pnlPeriodo_Resize(sender As Object, e As EventArgs) Handles pnlPeriodo.Resize
        cmbPeriodo.Top = (pnlPeriodo.Height - cmbPeriodo.Height) / 2
        lblPeriodo.Top = (pnlPeriodo.Height - lblPeriodo.Height) / 2
    End Sub
End Class