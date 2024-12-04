Public Class frmCargaCafeteria

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
        Dim ArTexto() As String
        Dim ArErrores(,) As String
        Dim ArCorrectos(,) As String

        Dim IniAus As Date
        Dim FinAus As Date
        Dim Naturaleza As String
        Dim AusentismoActual As String
        Dim NaturalezaActual As String
        Dim w As Integer
        Dim x As Integer
        Dim y As Integer
        Dim z As Integer
        Dim er As Integer

        Dim d As Integer
        Dim Archivo As String = ""
        Dim objReader As System.IO.StreamReader = Nothing
        Dim LN As String
        Dim hora As String = ""
        Dim CambioValido As Boolean
        Dim Lista As String = ""
        Dim lista2 As String = ""
        Dim fecha_aus As Date
        Dim dtResultado As New DataTable
        Dim dRegistro As DataRow
        Dim CodComp As String
        Try
            dtResultado.Columns.Add("MENSAJE")
            dtResultado.Columns.Add("RELOJ")
            dtResultado.Columns.Add("COMENTARIO")

            z = -1
            w = -1
            er = 0
        


            
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


            ReDim ArErrores(x + 5, 2)
            ReDim ArCorrectos(x + 5, 2)
            z = 0
            w = 0
            cpActualizacion.Maximum = x
            d = 0
            'TipoAus = cmbAusentismo.SelectedValue
            'Naturaleza = TipoNaturaleza(TipoAus)
            'd = 0


            If btnArchivo.Checked Then

                For y = 0 To x
                    fecha_aus = FechaSQL(ArLista(2, y))
                    hora = (New DateTime()).AddDays(ArLista(3, y).ToString).ToString("HH:MM")

                    Reloj = ArLista(1, y).PadLeft(LongReloj, "0")

                    dtEmpleado = sqlExecute("SELECT cod_comp,alta,baja from personalvw WHERE reloj = '" & Reloj & "'")
                    If dtEmpleado.Rows.Count = 0 Then
                        CodComp = ""
                        ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                        ArErrores(z, 1) = "Empleado no localizado"
                        z = z + 1
                        Continue For
                    Else
                        CodComp = dtEmpleado.Rows(0).Item("cod_comp")

                        If dtEmpleado.Rows(0).Item("alta") > FechaSQL(fecha_aus) Or _
                            IIf(IsDBNull(dtEmpleado.Rows(0).Item("baja")), DateSerial(2099, 10, 10), dtEmpleado.Rows(0).Item("baja")) < FechaSQL(fecha_aus) Then
                            CodComp = ""
                            ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                            ArErrores(z, 1) = "Empleado no activo en la fecha seleccionada"
                            z = z + 1
                            Continue For
                        End If
                    End If
                  
                 

                    gpValores.Enabled = False
                    'gpEmpleados.Enabled = False
                    gpAceptarCancelar.Enabled = False

                    cpActualizacion.Visible = True
                    cpActualizacion.Value = y
                    cpActualizacion.Text = Reloj
                    Application.DoEvents()

                 


                    CambioValido = True

                 

                    If CambioValido Then
                        'MCR 19/OCT/2015
                        'Insertar en bitácora borrado de ausentismo
                        sqlExecute("insert into hrs_brt_cafeteria (reloj, fecha, hora, nEventLogIdn) values ('" & Reloj & "', '" & fecha_aus & "', '" & hora & "','0')", "TA")
                        Try
                            ArCorrectos(w, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                            ArCorrectos(w, 1) = "Correcto"
                        Catch ex As Exception
                            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message, "Archivo w:" & w & "  y:" & y & "  ArCorrectos(w,1):" & ArCorrectos.GetUpperBound(0) & "  ArLista(1,y):" & ArLista.GetUpperBound(1))
                        End Try
                        w = w + 1
                        analisis_cafeteria(Reloj, fecha_aus)

                    End If

                    d = 0
                    FinAus = IniAus
                Next
            End If


            'cpActualizacion.Visible = False
            'gpValores.Enabled = True
            'gpEmpleados.Enabled = True
            'GroupBox1.Enabled = True

            If z > 0 Then
                For x = 0 To z - 1
                    Lista = Lista & vbCrLf & "  " & ArErrores(x, 0) & " " & ArErrores(x, 1)
                    dRegistro = dtResultado.NewRow
                    dRegistro("MENSAJE") = "ERRORES DETECTADOS"
                    dRegistro("RELOJ") = ArErrores(x, 0)
                    dRegistro("COMENTARIO") = ArErrores(x, 1)
                    dtResultado.Rows.Add(dRegistro)
                Next
            End If

            If w > 0 Then
                For x = 0 To w - 1
                    lista2 = lista2 & vbCrLf & "  " & ArCorrectos(x, 0) & " " & ArCorrectos(x, 1)
                    dRegistro = dtResultado.NewRow
                    dRegistro("MENSAJE") = "REGISTROS GUARDADOS EXITOSAMENTE"
                    dRegistro("RELOJ") = ArCorrectos(x, 0)
                    dRegistro("COMENTARIO") = ArCorrectos(x, 1)
                    dtResultado.Rows.Add(dRegistro)
                Next
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

            er = 1
        Finally
            cpActualizacion.Visible = False
            gpValores.Enabled = True
            ' gpEmpleados.Enabled = True
            gpAceptarCancelar.Enabled = True

        End Try

        If z > 0 Then
            MessageBox.Show("Se detectaron errores durante la carga.: " & Lista, "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf er > 0 Then
            MessageBox.Show("Se detecto un error antes de cargar el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("La carga de registros concluyó exitosamente.", "Carga Masiva", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class