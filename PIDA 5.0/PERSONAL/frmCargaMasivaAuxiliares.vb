Public Class frmCargaMasivaAuxiliares
    Dim dtCampoaux As DataTable
    Dim dtCiaDefault As DataTable
    Dim dtValorexis As DataTable
    Dim dtCampoDefault As DataTable
    Private Sub frmCargaMasivaAuxiliares_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbCia.DataSource = sqlExecute("SELECT cod_comp,nombre FROM cias")
        cmbCia.ValueMember = "cod_comp"
        cmbCia.DisplayMembers = "cod_comp,nombre"
        dtCiaDefault = sqlExecute("select top 1 * from cias where cia_default = '1'")
        If dtCiaDefault.Rows.Count Then
            cmbCia.SelectedValue = dtCiaDefault.Rows(0)("cod_comp")
        End If

        cmbCia.Columns(0).Width.AutoSize = True
        cmbCia.Columns(1).StretchToFill = True

    End Sub
    Dim valor_ini As String = ""
    Private Sub cmbCia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCia.SelectedValueChanged
        Try
            dtCampoaux = sqlExecute("SELECT cod_comp, campo,nombre,valor_inicial FROM auxiliares where cod_comp = '" & cmbCia.SelectedValue & "'", "personal")
            If dtCampoaux.Rows.Count Then
                cmbCampoaux.DataSource = dtCampoaux
                cmbCampoaux.ValueMember = "campo"
                cmbCampoaux.DisplayMembers = "cod_comp, campo, nombre"


            End If


        Catch ex As Exception

        End Try

    End Sub
    Private Sub cmbCampoaux_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCampoaux.SelectedValueChanged
        Try
            dtValorexis = sqlExecute("select auxiliares_validos.cod_comp,auxiliares_validos.campo,auxiliares_validos.campo_valido, auxiliares.VALOR_INICIAL from auxiliares_validos left join auxiliares on auxiliares_validos.CAMPO = auxiliares.CAMPO where auxiliares_validos.campo='" & cmbCampoaux.SelectedValue & "'", "personal")
            If dtValorexis.Rows.Count Then
                cmbValorexis.Visible = True
                txtValor.Visible = False

                cmbValorexis.DataSource = dtValorexis
                cmbValorexis.ValueMember = "campo_valido"
                cmbValorexis.DisplayMembers = "campo_valido"

                valor_ini = IIf(IsDBNull(dtValorexis.Rows(0)("valor_inicial")), "", dtValorexis.Rows(0)("valor_inicial"))

                If valor_ini.Trim <> "" Then
                    cmbValorexis.SelectedValue = valor_ini.Trim
                End If
            Else
                cmbValorexis.Visible = False
                txtValor.Visible = True
            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub btnArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles btnArchivo.CheckedChanged
        btnBuscaArchivo.Enabled = btnArchivo.Checked
        txtArchivo.Enabled = btnArchivo.Checked
        txtLista.Enabled = btnLista.Checked
        btnBuscaLista.Enabled = btnLista.Checked

        txtValor.Enabled = btnLista.Checked
        cmbValorexis.Enabled = btnLista.Checked

        If btnArchivo.Checked Then
            txtArchivo.Focus()
        End If
    End Sub

    Private Sub btnLista_CheckedChanged(sender As Object, e As EventArgs) Handles btnLista.CheckedChanged
        btnBuscaArchivo.Enabled = btnArchivo.Checked
        txtArchivo.Enabled = btnArchivo.Checked
        txtLista.Enabled = btnLista.Checked
        btnBuscaLista.Enabled = btnLista.Checked

        txtValor.Enabled = btnLista.Checked
        cmbValorexis.Enabled = btnLista.Checked

        If btnLista.Checked Then
            txtLista.Focus()
        End If
    End Sub

    Private Sub btnBuscaArchivo_Click(sender As Object, e As EventArgs) Handles btnBuscaArchivo.Click
        Dim Archivo As String
        Try
            dlgArchivo.Multiselect = False
            dlgArchivo.FileName = ""
            dlgArchivo.Filter = "Listas de empleados|*.txt;*.xls;*.xlsx|Archivos excel|*.xls;*.xlsx|Archivos texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub
    
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim ArLista(,) As String
        Dim ArTexto() As String
        Dim ArErrores(,) As String
        Dim Clave As String = ""
        Dim Campoaux As String
        Dim Valor As String
        Dim Valorexistente As String
        Dim CambioValido As Boolean
        Dim Archivo As String
        Dim dtconsulta1 As DataTable
        Dim dtconsulta2 As DataTable
        Dim LN As String
        Dim i As Integer
        Dim x As Integer
        Dim y As Integer
        Dim z As Integer
        Dim Comp As String
        Dim objReader As System.IO.StreamReader = Nothing
        Dim Cambios As Integer = 0

        Try
            Comp = cmbCia.SelectedValue

            'Si se seleccionó por archivo
            If btnArchivo.Checked Then
                Archivo = txtArchivo.Text.Trim

                If System.IO.File.Exists(Archivo) = False Then
                    MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                'Redimensionar el arreglo principal de inicio a 1000
                ReDim ArLista(2, 1000)

                'Si el archivo es tipo texto
                If Archivo.Substring(Archivo.Length - 4).ToLower = ".txt" Then
                    objReader = New System.IO.StreamReader(Archivo)

                    x = 0
                    y = objReader.BaseStream.Length
                    cpActualizacion.Maximum = 100
                    cpActualizacion.Visible = True
                    Application.DoEvents()

                    'Repasar todo el archivo
                    Do Until objReader.EndOfStream
                        LN = objReader.ReadLine
                        'Espera 2 columnas (reloj y monto), separadas por tab
                        ArTexto = Split(LN, vbTab)

                        'La primer columna, es reloj
                        If ArTexto.Length > 0 Then ArLista(1, x) = ArTexto(0)
                        'La segunda columna, es monto
                        If ArTexto.Length > 1 Then ArLista(2, x) = ArTexto(1)

                        x = x + 1
                        If UBound(ArLista, 2) < x Then
                            ReDim Preserve ArLista(2, x)
                        End If
                    Loop
                    x = x - 1
                    'Redimensionar el arreglo principal, de acuerdo al número de registros
                    ReDim Preserve ArLista(2, x)
                Else
                    'Llenar arreglo con datos de excel
                    ArLista = ExcelTOArrayList(Archivo)
                    x = ArLista.GetUpperBound(1)
                End If
            Else
                'Si no es archivo, llenar desde lista de números de reloj
                'el monto se carga desde txtMonto
                ArTexto = txtLista.Text.Split(",")
                x = ArTexto.Length - 1
                ReDim ArLista(2, x)
                For i = 0 To x
                    ArLista(1, i) = ArTexto(i)
                    ArLista(2, i) = cmbValorexis.Text
                Next
            End If
            ReDim ArErrores(x, 2)
            z = 0

            'Activar progress bar
            cpActualizacion.Visible = True
            cpActualizacion.Maximum = x
            For y = 0 To x
                Reloj = ArLista(1, y).PadLeft(LongReloj, "0")


                Valor = ArLista(2, y)
                cpActualizacion.Value = x
                cpActualizacion.Text = Reloj

                'Validar que el reloj sea válido y activo
                CambioValido = True
                If ArLista(1, y) = "00000" Then
                    ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                    ArErrores(z, 1) = "Reloj en blanco"
                    CambioValido = False
                    z = z + 1
                End If

                If Not CambioValido Then Continue For

                dtTemporal = sqlExecute("SELECT reloj,baja from personalvw WHERE reloj = '" & Reloj.PadLeft(LongReloj, "0") & "'")
                If dtTemporal.Rows.Count < 1 Then
                    ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                    ArErrores(z, 1) = "Empleado no localizado"
                    CambioValido = False
                    z = z + 1
                End If

                If Not CambioValido Then Continue For

                If Not IsDBNull(dtTemporal.Rows.Item(0).Item("baja")) Then
                    If Not cbInactivos.Checked Then
                        ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                        ArErrores(z, 1) = "Empleado dado de baja"
                        CambioValido = False
                        z = z + 1
                    End If
                End If

                'Si el cambio no es válido, pasar al siguiente índice
                'If Not CambioValido Then Continue For

                Comp = cmbCia.SelectedValue
                Campoaux = cmbCampoaux.SelectedValue
                Valorexistente = cmbValorexis.SelectedValue

                'Si el cambio fue válido, insertar en la tabla de detalle_auxiliares
                dtconsulta1 = sqlExecute("SELECT * FROM detalle_auxiliares where reloj='" & Reloj.PadLeft(LongReloj, "0") & "' and campo='" & Campoaux.Trim & "' and contenido is null", "personal")
                dtconsulta2 = sqlExecute("SELECT * FROM detalle_auxiliares where reloj='" & Reloj.PadLeft(LongReloj, "0") & "' and campo='" & Campoaux.Trim & "' and contenido is not null", "personal")
                If CambioValido Then
                    If dtconsulta1.Rows.Count Then
                        CambioValido = True
                        sqlExecute("UPDATE detalle_auxiliares SET contenido='" & Valor & "'where reloj='" & Reloj.PadLeft(LongReloj, "0") & "' and campo='" & Campoaux.Trim & "'")
                        Cambios += 1

                    ElseIf dtconsulta2.Rows.Count Then
                        If cbactualizar.Checked Then
                            CambioValido = True
                            sqlExecute("UPDATE detalle_auxiliares SET contenido='" & Valor & "'where reloj='" & Reloj.PadLeft(LongReloj, "0") & "' and campo='" & Campoaux.Trim & "'")
                            Cambios += 1

                        Else
                            ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                            ArErrores(z, 1) = "Empleado con auxiliar existente"
                            CambioValido = False
                            z = z + 1
                        End If

                    Else
                        Dim dtid As DataTable = sqlExecute("select top 1 idfld from detalle_auxiliares order by idfld desc")
                        Dim id As Double = (Double.Parse(dtid.Rows(0)("idfld"), 0) + 1).ToString.PadLeft(5, "0")

                        sqlExecute("INSERT INTO detalle_auxiliares(idfld,reloj,cod_comp,campo,contenido) " & _
                              "VALUES ('" & id & "','" & Reloj.PadLeft(LongReloj, "0") & "','" & Comp.Substring(0, 3) & "','" & _
                              Campoaux.Trim & "','" & Valor & "')", "personal")

                        Cambios += 1
                    End If
                Else
                    ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                    ArErrores(z, 1) = "Empleado existente"
                    CambioValido = False
                    z = z + 1
                End If

            Next

            cpActualizacion.Visible = False
            If z > 0 Then
                'z cuenta los errores. Si es >0, notificar que hubo errores, y cuáles

                Dim Lista As String = ""
                For x = 0 To z - 1
                    Lista = Lista & vbCrLf & "  " & ArErrores(x, 0) & " " & ArErrores(x, 1)
                Next
                MessageBox.Show("Se detectaron errores durante la carga, en los siguientes empleados no pudo agregarse el ajuste: " & Lista, "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("La carga masiva de ajustes se realizó exitosamente, con " & Cambios & " registros actualizados.", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Se detectaron errores durante la carga, por lo que no pudieron agregarse el ajuste.", "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally

            Me.Close()
            Me.Dispose()
        End Try
    End Sub
    Private Sub btnBuscaLista_Click(sender As Object, e As EventArgs) Handles btnBuscaLista.Click
        Dim FL As String = ""
        Dim dtDatosPersonal As New DataTable
        frmTrabajando.Show(Me)
        frmTrabajando.Avance.Value = 0
        frmTrabajando.Avance.IsRunning = False
        frmTrabajando.lblAvance.Text = "Preparando datos..."
        Application.DoEvents()
        dtDatosPersonal = sqlExecute("EXEC MaestroPersonal @Nivel = " & NivelConsulta & ", @Reloj = ''")
        dtResultado = dtDatosPersonal.Clone
        frmTrabajando.Avance.IsRunning = True

        For Each dRow As DataRow In dtDatosPersonal.Select(FiltroXUsuario)
            frmTrabajando.lblAvance.Text = "Reloj " & dRow.Item("reloj")
            Application.DoEvents()

            dRow.Item("sactual") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("sactual"), 0)
            dRow.Item("integrado") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("integrado"), 0)
            dRow.Item("pro_var") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("pro_var"), 0)
            dRow.Item("factor_int") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("factor_int"), 0)
            dRow.Item("sal_ant") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("sal_ant"), 0)
            dtResultado.ImportRow(dRow)
        Next
        ActivoTrabajando = False

        frmTrabajando.Close()
        frmTrabajando.Dispose()

        frmFiltro.ShowDialog()
        If NFiltros > 0 Then
            Dim i As Integer
            Try
                For i = 0 To NFiltros - 1
                    FL = FL & IIf(i > 0, " AND (", "(") & Filtros(2, i) & ")"
                Next
                dtTemporal = ConsultaPersonalVW("SELECT RELOJ from personalvw WHERE " & FL)

                FL = ""
                For i = 0 To dtTemporal.Rows.Count - 1
                    FL = FL & IIf(i > 0, ",", "") & dtTemporal.Rows.Item(i).Item("Reloj")
                Next
                txtLista.Text = FL

            Catch ex As Exception
                FL = "ERROR"
            End Try
        End If
    End Sub

    Private Sub dlgArchivo_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dlgArchivo.FileOk

    End Sub
    

    Private Sub cmbValorexis_TextChanged(sender As Object, e As EventArgs) Handles cmbValorexis.TextChanged

    End Sub

    Private Sub frmCargaMasivaAuxiliares_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            NFiltros = 0
           
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbCampoaux_TextChanged(sender As Object, e As EventArgs) Handles cmbCampoaux.TextChanged

    End Sub
End Class