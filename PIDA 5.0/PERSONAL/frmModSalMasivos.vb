Public Class frmModSalMasivos
    Dim dtNivel As New DataTable
    Dim dtModSal As New DataTable
    Dim FechaMod As Date = Today
    Dim TipoMod As String = "A"

    Private Sub frmModSalMasivos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        NFiltros = 0
        Me.Dispose()
    End Sub

    Private Sub frmModSalMasivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtTemporal = sqlExecute("SELECT cod_tipo_mod,fecha_mod FROM configuracion WHERE usuario = '" & Usuario & "'", "Seguridad")
            If dtTemporal.Rows.Count > 0 Then
                FechaMod = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("fecha_mod")), Today, dtTemporal.Rows.Item(0).Item("fecha_mod"))
                TipoMod = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("cod_tipo_mod")), "A", dtTemporal.Rows.Item(0).Item("cod_tipo_mod"))
            End If
            dtModSal = sqlExecute("SELECT * FROM tipo_mod_sal where cod_tipo_mod='IPP'")
            'Dim R As DataRow = dtModSal.NewRow
            'R("cod_tipo_mod") = -1
            'R("nombre") = "No cambiar"
            'dtModSal.Rows.Add(R)

            cmbTipoModSal.DataSource = dtModSal
            cmbTipoModSal.SelectedValue = TipoMod

            dtNivel = sqlExecute("SELECT * FROM niveles")
            'Dim N As DataRow = dtNivel.NewRow
            'N("nivel") = -1
            'N("nombre") = "No cambiar"
            'dtNivel.Rows.Add(N)

            cmbNiveles.DataSource = dtNivel

            txtFecha.Value = FechaMod

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub

    Private Sub btnArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles btnArchivo.CheckedChanged
        Try
            btnBuscaArchivo.Enabled = btnArchivo.Checked
            txtArchivo.Enabled = btnArchivo.Checked
            txtLista.Enabled = btnLista.Checked
            btnBuscaLista.Enabled = btnLista.Checked
            If btnArchivo.Checked Then
                txtArchivo.Focus()
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub

    Private Sub btnLista_CheckedChanged(sender As Object, e As EventArgs) Handles btnLista.CheckedChanged
        Try
            btnBuscaArchivo.Enabled = btnArchivo.Checked
            txtArchivo.Enabled = btnArchivo.Checked
            txtLista.Enabled = btnLista.Checked
            btnBuscaLista.Enabled = btnLista.Checked

            If btnLista.Checked Then
                txtLista.Focus()
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBuscaArchivo_Click(sender As Object, e As EventArgs) Handles btnBuscaArchivo.Click
        Dim Archivo As String

        dlgArchivo.Multiselect = False
        dlgArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
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
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub cmbNiveles_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNiveles.SelectedValueChanged
        Try
            Dim sdo As Double
            Dim Cmp As String
            If cmbNiveles.Text.Length > 3 Then
                Cmp = cmbNiveles.Text.Substring(0, 3)
            Else
                Cmp = ""
            End If
            dtTemporal = sqlExecute("SELECT sueldo FROM niveles WHERE cod_comp = '" & Cmp & "' AND nivel = '" & cmbNiveles.SelectedValue & "'")
            If dtTemporal.Rows.Count > 0 Then
                sdo = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("sueldo")), 0, dtTemporal.Rows.Item(0).Item("sueldo"))

                txtCambioA.Text = sdo
                txtCambioA.Enabled = (sdo = 0)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub



    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim ArLista() As String
        Dim ArErrores(,) As String
        Dim Notas As String
        Dim Nivel As String
        Dim dtCompaRatio As New DataTable
        Dim ID As Integer
        Dim Cadena As String
        Dim CodComp As String = ""
        Dim Reloj As String = ""
        Dim sActual As Double
        Dim ProVar As Double
        Dim FactorInt As Double
        Dim Integrado As Double
        Dim Compa_ratio_ant As Double
        Dim Compa_ratio_nvo As Double
        Dim MidPoint As Double
        Dim CambioValido As Boolean
        Dim Archivo As String
        Dim LN As String
        Dim x As Integer
        Dim y As Integer
        Dim z As Integer
        Dim Cmp As String
        Dim objReader As System.IO.StreamReader = Nothing

        Try
            If cmbNiveles.Text.Length > 3 Then
                Cmp = cmbNiveles.Text.Substring(0, 3)
            Else
                Cmp = ""
            End If


            If DateDiff(DateInterval.Day, txtFecha.Value, Today) > 15 Then
                MessageBox.Show("La diferencia entre la fecha de aplicación del movimiento y el día de hoy, no puede ser mayor a 15 días.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtFecha.Focus()
                Exit Sub
            End If

            If txtCambioA.Text = 0 Then
                MessageBox.Show("El nuevo sueldo debe ser mayor a 0. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCambioA.Focus()
                Exit Sub
            End If

            Notas = txtNotas.Text
            Notas = Notas.Replace("'", "''")
            Notas = Notas.Replace(Chr(34), "''")

            Nivel = cmbNiveles.SelectedValue
            sqlExecute("UPDATE configuracion SET cod_tipo_mod = '" & cmbTipoModSal.SelectedValue & "', fecha_mod = '" & FechaSQL(txtFecha.Value) & "' WHERE usuario = '" & Usuario & "'", "seguridad")

            If btnArchivo.Checked Then
                Archivo = txtArchivo.Text
                If System.IO.File.Exists(Archivo) = False Then
                    MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                objReader = New System.IO.StreamReader(Archivo)

                x = 0
                y = objReader.BaseStream.Length
                cpActualizacion.Maximum = 100
                cpActualizacion.Visible = True
                Application.DoEvents()
                ReDim ArLista(1000)

                Do Until objReader.EndOfStream
                    LN = objReader.ReadLine
                    ArLista(x) = LN.Substring(0, 6)

                    x = x + 1
                    If UBound(ArLista) < x Then
                        ReDim Preserve ArLista(x)
                    End If
                Loop
                x = x - 1
                ReDim Preserve ArLista(x)
            Else
                ArLista = txtLista.Text.Split(",")
                x = ArLista.Length - 1
            End If
            ReDim ArErrores(x, 2)
            z = 0
            cpActualizacion.Maximum = x
            For y = 0 To x
                Reloj = ArLista(y).PadLeft(LongReloj, "0")

                cpActualizacion.Value = x
                cpActualizacion.Text = Reloj


                CambioValido = True
                If ArLista(y) = "00000" Then
                    ArErrores(z, 0) = ArLista(y)
                    ArErrores(z, 1) = "Reloj en blanco"
                    CambioValido = False
                    z = z + 1
                End If


                'MCR 19/NOV/2015
                'Revisar si la compañía del empleado es editable
                'Si no lo es, no permitir modificarlo
                If CambioValido Then
                    dtTemporal = sqlExecute("SELECT editable FROM cias " & _
                                            "LEFT JOIN Personal ON cias.cod_comp = personal.cod_comp " & _
                                            "WHERE personal.reloj = '" & Reloj & "' AND (editable IS NULL OR editable = 1)")
                    If dtTemporal.Rows.Count = 0 Then
                        ArErrores(z, 0) = ArLista(y)
                        ArErrores(z, 1) = "Compañía no editable"
                        CambioValido = False
                        z = z + 1
                    End If
                End If
                '******************************


                If CambioValido Then
                    dtTemporal = sqlExecute("SELECT cod_comp,reloj,sactual,integrado,pro_var,factor_int,baja,COMPA_RATIO from personalvw WHERE reloj = '" & Reloj & "'")
                    If dtTemporal.Rows.Count < 1 Then
                        ArErrores(z, 0) = ArLista(y)
                        ArErrores(z, 1) = "Empleado no localizado"
                        CambioValido = False
                        z = z + 1
                    Else
                        CodComp = dtTemporal.Rows.Item(0).Item("cod_comp")

                        sActual = dtTemporal.Rows.Item(0).Item("sactual")
                        Integrado = dtTemporal.Rows.Item(0).Item("integrado")
                        ProVar = dtTemporal.Rows.Item(0).Item("pro_var")
                        FactorInt = dtTemporal.Rows.Item(0).Item("factor_int")
                        Compa_ratio_ant = dtTemporal.Rows(0).Item("COMPA_RATIO")

                        If Not IsDBNull(dtTemporal.Rows.Item(0).Item("baja")) Then
                            ArErrores(z, 0) = ArLista(y)
                            ArErrores(z, 1) = "Empleado dado de baja"
                            CambioValido = False
                            z = z + 1
                        End If

                        If dtTemporal.Rows.Item(0).Item("cod_comp") <> Cmp And CambioValido Then
                            ArErrores(z, 0) = ArLista(y)
                            ArErrores(z, 1) = "Diferente compañía"
                            CambioValido = False
                            z = z + 1
                        End If

                        If dtTemporal.Rows.Item(0).Item("sactual") > CDbl(txtCambioA.Text) And CambioValido Then
                            ArErrores(z, 0) = ArLista(y)
                            ArErrores(z, 1) = "Sueldo nuevo menor al actual"
                            CambioValido = False
                            z = z + 1
                        End If

                        dtCompaRatio = sqlExecute("select * from niveles where cod_comp = '" & CodComp & "' and nivel = '" & Nivel & "'")
                        For Each row As DataRow In dtCompaRatio.Rows
                            MidPoint = IIf(IsDBNull(row.Item("MED")), 0, row.Item("MED"))
                            If MidPoint <> 0 Then
                                Compa_ratio_nvo = ((((Double.Parse(txtCambioA.Text)) * 30.4) / MidPoint) * 100)
                            Else
                                Compa_ratio_nvo = 0
                            End If
                        Next


                    End If
                End If

                If CambioValido Then

                    dtTemporal = sqlExecute("SELECT MAX(ID)+ 1 AS ID FROM mod_sal")
                    If dtTemporal.Rows.Count <= 0 Then
                        ID = 0
                    Else
                        ID = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("ID")), 0, dtTemporal.Rows.Item(0).Item("ID"))
                    End If

                    Cadena = "INSERT INTO mod_sal (cod_comp,reloj,cod_tipo_mod,cambio_de,cambio_a,provar,fact_int,fecha,notas,nivel,integrado,hoy,compa_ratio_ant,compa_ratio_nvo) VALUES ('"
                    Cadena = Cadena & CodComp & "','" & Reloj & "','" & cmbTipoModSal.SelectedValue & "'," & sActual & "," & txtCambioA.Text & ","
                    Cadena = Cadena & ProVar & "," & FactorInt & ",'" & FechaSQL(txtFecha.Value) & "','" & Notas & "','" & Nivel & "',"
                    Cadena = Cadena & Integrado & ", GETDATE(),'" & Format(Compa_ratio_ant, "f") & "','" & Format(Compa_ratio_nvo, "f") & "')"

                    sqlExecute(Cadena)
                End If
            Next

            cpActualizacion.Visible = False
            If z > 0 Then
                Dim Lista As String = ""
                For x = 0 To z - 1
                    Lista = Lista & vbCrLf & "  " & ArErrores(x, 0) & " " & ArErrores(x, 1)
                Next
                MessageBox.Show("Se detectaron errores durante la carga, estos empleados no fueron modificados: " & Lista, "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            GenerarMultiforma()
            Me.Close()
            Me.Dispose()


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub GenerarMultiforma()
        Dim dtinfo As DataTable = sqlExecute("select personalvw.reloj,'mod_sal' as tipo_reporte from personalvw left join mod_sal on personalvw.reloj = mod_sal.reloj where mod_sal.aplicado='0' and mod_sal.hoy = '" + FechaSQL(Date.Now) + "'")
        If dtinfo.Rows.Count > 0 Then
            frmVistaPrevia.LlamarReporte("Formato Multiple", dtinfo)
            frmVistaPrevia.ShowDialog()
        End If

    End Sub
    Private Sub btnBuscaLista_Click(sender As Object, e As EventArgs) Handles btnBuscaLista.Click
        Try
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
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class
