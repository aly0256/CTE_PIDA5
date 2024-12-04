Public Class frmRetardoTransporte

    Private Sub btnBuscaArchivo_Click(sender As Object, e As EventArgs) Handles btnBuscaArchivo.Click
        Dim Archivo As String

        dlgArchivo.Multiselect = False
        dlgArchivo.Filter = "Listas de empleados|*.xls;*.xlsx|Archivos excel|*.xls;*.xlsx"
        Try
            Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()
            If lDialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                Archivo = dlgArchivo.FileName
            End If

            If System.IO.File.Exists(Archivo) = False Then
                MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            txtArchivo.Text = Archivo
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim dtTemp As New DataTable
        Dim dtEmpleado As New DataTable
        Dim ArLista(,) As String
        Dim ArErrores(,) As String
        Dim ArCorrectos(,) As String
        Dim w As Integer
        Dim x As Integer
        Dim y As Integer
        Dim z As Integer
        Dim Archivo As String = ""
        Dim objReader As System.IO.StreamReader = Nothing
        Dim tiempo_tra As String = ""
        Dim CambioValido As Boolean
        Dim Lista As String = ""
        Dim lista2 As String = ""
        Dim fecha_tra As Date

        z = -1
        w = -1

        Try
            Archivo = txtArchivo.Text.Trim

            If System.IO.File.Exists(Archivo) = False Then
                MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Redimensionar el arreglo principal de inicio a 1000
            ReDim ArLista(4, 1000)
            'Llenar arreglo con datos de excel
            ArLista = ExcelTOArrayList(Archivo, "C")
            x = ArLista.GetUpperBound(1)
            ReDim ArErrores(x, 2)
            ReDim ArCorrectos(x, 2)
            z = 0
            w = 0
            cpActualizacion.Maximum = x

            For y = 0 To x
                Reloj = ArLista(1, y).PadLeft(LongReloj, "0")
                If Reloj <> "" Then
                    fecha_tra = ArLista(2, y)
                    tiempo_tra = ArLista(3, y).PadLeft(5, "0")
                    tiempo_tra = tiempo_tra.Replace(".", ":")
                    Reloj = ArLista(1, y).PadLeft(LongReloj, "0")

                    gpValores.Enabled = False
                    gpAceptarCancelar.Enabled = False

                    cpActualizacion.Visible = True
                    cpActualizacion.Value = y
                    cpActualizacion.Text = Reloj
                    Application.DoEvents()

                    CambioValido = True

                    If CambioValido Then
                        sqlExecute("delete from retardo_transporte where reloj = '" & Reloj & "' and fecha = '" & FechaSQL(fecha_tra) & "'", "TA")
                        sqlExecute("insert into retardo_transporte values ('" & Reloj & "', '" & FechaSQL(fecha_tra) & "', '" & tiempo_tra & "', '" & Usuario & "', '" & FechaHoraSQL(Date.Now) & "')", "TA")
                        w = w + 1
                    End If
                End If
            Next

            MessageBox.Show("La carga de ausentismo concluyó exitosamente.", "Ausentismo masivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("No se pudo finalizar la carga", "Ausentismo masivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            cpActualizacion.Visible = False
            gpValores.Enabled = True
            ' gpEmpleados.Enabled = True
            gpAceptarCancelar.Enabled = True
        End Try

      
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class