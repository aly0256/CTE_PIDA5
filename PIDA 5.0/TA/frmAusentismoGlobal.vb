Public Class frmAusentismoGlobal
    Dim dtAusentismo As New DataTable
    Dim dtFiltroPerfil As New DataTable
    Dim FiltroAusentismo As String = ""


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
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
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
                dtTemporal = consultapersonalvw("SELECT RELOJ from personalvw WHERE " & FL)

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
        Dim TipoAus As String = ""
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
            If Math.Abs(DateDiff(DateInterval.Day, txtFecha.Value, Today)) > 15 Then
                MessageBox.Show("La diferencia entre la fecha de ausentismo y el día de hoy, no puede ser mayor a 15 días.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtFecha.Focus()
                Exit Sub
            End If

            If txtDias.Text > 30 Or txtDias.Text < 0 Then
                MessageBox.Show("El número de días de ausentismo debe ser entre 0 y 30.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDias.Focus()
                Exit Sub
            End If

            If btnArchivo.Checked Then
                'Archivo = txtArchivo.Text
                'If System.IO.File.Exists(Archivo) = False Then
                '    MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
                'End If


                'objReader = New System.IO.StreamReader(Archivo)

                'x = 0
                'y = objReader.BaseStream.Length
                'cpActualizacion.Maximum = 100
                'cpActualizacion.Visible = True
                'Application.DoEvents()
                'ReDim ArLista(4, 1000)

                'Do Until objReader.EndOfStream
                '    LN = objReader.ReadLine
                '    ArLista(x) = LN.Substring(0, 6)

                '    x = x + 1
                '    If UBound(ArLista) < x Then
                '        ReDim Preserve ArLista(x)
                '    End If
                'Loop
                'x = x - 1
                'ReDim Preserve ArLista(x)
                '    ArLista = ExcelTOArrayList(Archivo, "C")
                '    x = ArLista.GetUpperBound(1)
                'Else
                '    ArTexto = txtLista.Text.Split(",")
                '    x = ArLista.Length - 1
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
            Else
                ArTexto = txtLista.Text.Split(",")
                x = ArTexto.Length - 1
                ReDim ArLista(3, x)
                For i = 0 To x
                    ArLista(1, i) = ArTexto(i)
                    ArLista(2, i) = txtFecha.Value
                    ArLista(3, i) = cmbAusentismo.SelectedValue
                Next
            End If
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
                    fecha_aus = ArLista(2, y)
                    TipoAus = ArLista(3, y)
                    Naturaleza = TipoNaturaleza(TipoAus)
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
                    '*****Si el perfil es de clerk, solo se podra cargar convenio %50
                    If Perfil.Contains("CLERK") Then
                        If Trim(TipoAus) <> "C50" Then
                            ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                            ArErrores(z, 1) = "Ausentismo no permitido para su perfil"
                            z = z + 1
                            Continue For
                        End If
                    End If

                    ''MCR 19/NOV/2015
                    ''Revisar si la compañía del empleado es editable
                    ''Si no lo es, no permitir modificarlo
                    'dtTemporal = sqlExecute("SELECT editable FROM cias " & _
                    '                            "LEFT JOIN Personal ON cias.cod_comp = personal.cod_comp " & _
                    '                            "WHERE personal.reloj = '" & Reloj & "' AND (editable IS NULL OR editable = 1)")
                    'If dtTemporal.Rows.Count = 0 Then
                    '    ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                    '    ArErrores(z, 1) = "Compañía no editable"
                    '    z = z + 1
                    '    Continue For
                    'End If
                    '******************************






                    gpValores.Enabled = False
                    'gpEmpleados.Enabled = False
                    gpAceptarCancelar.Enabled = False

                    cpActualizacion.Visible = True
                    cpActualizacion.Value = y
                    cpActualizacion.Text = Reloj
                    Application.DoEvents()

                    IniAus = fecha_aus
                    FinAus = IniAus
                    d = 0
                    If DiaDescanso(FinAus, Reloj) Or Festivo(FinAus, Reloj) Then
                        ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                        ArErrores(z, 1) = "Dia descanso o Festivo"
                        z = z + 1
                        Continue For
                    End If


                    CambioValido = True

                    If Trim(TipoAus) = "C50" Then
                        Dim dtAus50 As DataTable = sqlExecute("select tipo_aus from ausentismo where fecha = '" & FechaSQL(FinAus) & "' and reloj = '" & Reloj & "' and tipo_aus in (select tipo_aus from tipo_ausentismo where afecta_asistencia_perfecta = '0')", "TA")
                        If dtAus50.Rows.Count > 0 Then
                            ArErrores(z, 0) = Reloj
                            ArErrores(z, 1) = "Tiene ausentismo mayor a C50, " & FechaSQL(FinAus)
                            CambioValido = False
                            z = z + 1
                        End If
                    End If


                    dtTemp = sqlExecute("SELECT tipo_aus FROM ausentismo WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(FinAus) & "'", "TA")
                    If dtTemp.Rows.Count > 0 Then
                        AusentismoActual = IIf(IsDBNull(dtTemp.Rows(0).Item("tipo_aus")), "", dtTemp.Rows(0).Item("tipo_aus")).ToString.Trim
                        NaturalezaActual = TipoNaturaleza(AusentismoActual)
                        If NaturalezaActual = "I" Then
                            ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                            ArErrores(z, 1) = "Incapacidad " & FechaSQL(FinAus)
                            CambioValido = False
                            z = z + 1
                        ElseIf NaturalezaActual <> "A" Then
                            If CambioValido Then
                                ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                                ArErrores(z, 1) = "Se sustituyó ausentismo " & AusentismoActual & " el " & FechaSQL(FinAus)
                                z = z + 1
                            End If
                        End If
                    End If


                    Dim dtAsistencia As DataTable = sqlExecute("select * from asist where fha_ent_hor = '" & FechaSQL(FinAus) & "' and reloj = '" & Reloj & "' and (entro <> '' or salio <> '')", "TA")
                    If dtAsistencia.Rows.Count > 0 Then
                        ArErrores(z, 0) = Reloj
                        ArErrores(z, 1) = "Tiene registro de asistencia, " & FechaSQL(FinAus)
                        CambioValido = False
                        z = z + 1
                    End If



                    If CambioValido Then
                        'MCR 19/OCT/2015
                        'Insertar en bitácora borrado de ausentismo
                        sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                      "(reloj,fecha,tipo_aus,tipo_movimiento,fecha_movimiento,usuario_movimiento,notas) " & _
                                   "SELECT reloj,fecha,tipo_aus,'A',GETDATE(),'" & Usuario & _
                                   "','/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/Met: " & _
                                   "<AUSENTISMO GLOBAL>'" & _
                                   "FROM ausentismo WHERE reloj = '" & Reloj & _
                                   "' AND  fecha = '" & FechaSQL(FinAus) & "'", "TA")

                        sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & Reloj & "' AND  fecha = '" & FechaSQL(FinAus) & "'", "TA")
                        sqlExecute("INSERT INTO ausentismo (cod_comp,reloj,fecha,tipo_aus,referencia,usuario,fecha_hora) VALUES ('" & _
                                   CodComp & "','" & _
                                   Reloj & "','" & _
                                   FechaSQL(FinAus) & "','" & _
                                   TipoAus & "'," & _
                                   "'','" & _
                                   Usuario & "', " & _
                                   "GETDATE())", "TA")
                        Try
                            ArCorrectos(w, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                            ArCorrectos(w, 1) = "Correcto"
                        Catch ex As Exception
                            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message, "Archivo w:" & w & "  y:" & y & "  ArCorrectos(w,1):" & ArCorrectos.GetUpperBound(0) & "  ArLista(1,y):" & ArLista.GetUpperBound(1))
                        End Try
                        w = w + 1
                        analisis_independiente(Reloj, FinAus)
                    End If

                    d = 0
                    FinAus = IniAus
                Next

            Else
                TipoAus = cmbAusentismo.SelectedValue
                Naturaleza = TipoNaturaleza(TipoAus)
                For y = 0 To x
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

                        If dtEmpleado.Rows(0).Item("alta") > DateAdd(DateInterval.Day, txtDias.Value, txtFecha.Value) Or _
                            IIf(IsDBNull(dtEmpleado.Rows(0).Item("baja")), DateSerial(2099, 10, 10), dtEmpleado.Rows(0).Item("baja")) < txtFecha.Value Then
                            CodComp = ""
                            ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                            ArErrores(z, 1) = "Empleado no activo en la fecha seleccionada"
                            z = z + 1
                            Continue For
                        End If

                        Dim dtAsistencia As DataTable = sqlExecute("select * from asist where fha_ent_hor = '" & FechaSQL(txtFecha.Value) & "' and reloj = '" & Reloj & "' and (entro <> '' or salio <> '')", "TA")
                        If dtAsistencia.Rows.Count > 0 Then
                            ArErrores(z, 0) = Reloj
                            ArErrores(z, 1) = "Tiene registro de asistencia, " & FechaSQL(txtFecha.Value)
                            CambioValido = False
                            z = z + 1
                            Continue For
                        End If

                    End If

                    ''MCR 19/NOV/2015
                    ''Revisar si la compañía del empleado es editable
                    ''Si no lo es, no permitir modificarlo
                    'dtTemporal = sqlExecute("SELECT editable FROM cias " & _
                    '                            "LEFT JOIN Personal ON cias.cod_comp = personal.cod_comp " & _
                    '                            "WHERE personal.reloj = '" & Reloj & "' AND (editable IS NULL OR editable = 1)")
                    'If dtTemporal.Rows.Count = 0 Then
                    '    ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                    '    ArErrores(z, 1) = "Compañía no editable"
                    '    z = z + 1
                    '    Continue For
                    'End If
                    ''******************************

                    gpValores.Enabled = False
                    'gpEmpleados.Enabled = False
                    gpAceptarCancelar.Enabled = False

                    cpActualizacion.Visible = True
                    cpActualizacion.Value = y
                    cpActualizacion.Text = Reloj
                    Application.DoEvents()

                    IniAus = txtFecha.Text
                    FinAus = IniAus
                    d = 0

                    Do While d < txtDias.Value
                        CambioValido = True


                        If Trim(TipoAus) = "C50" Then
                            Dim dtAus50 As DataTable = sqlExecute("select tipo_aus from ausentismo where fecha = '" & FechaSQL(FinAus) & "' and reloj = '" & Reloj & "' and tipo_aus in (select tipo_aus from tipo_ausentismo where afecta_asistencia_perfecta = '0')", "TA")
                            If dtAus50.Rows.Count > 0 Then
                                ArErrores(z, 0) = Reloj
                                ArErrores(z, 1) = "Tiene ausentismo mayor a C50, " & FechaSQL(FinAus)
                                CambioValido = False
                                z = z + 1
                            End If
                        End If


                        dtTemp = sqlExecute("SELECT tipo_aus FROM ausentismo WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(FinAus) & "'", "TA")
                        If dtTemp.Rows.Count > 0 Then
                            AusentismoActual = IIf(IsDBNull(dtTemp.Rows(0).Item("tipo_aus")), "", dtTemp.Rows(0).Item("tipo_aus")).ToString.Trim
                            NaturalezaActual = TipoNaturaleza(AusentismoActual)
                            If NaturalezaActual = "I" Then
                                ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                                ArErrores(z, 1) = "Incapacidad " & FechaSQL(FinAus)
                                CambioValido = False
                                z = z + 1
                            ElseIf NaturalezaActual <> "A" Then
                                If CambioValido Then
                                    ArErrores(z, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                                    ArErrores(z, 1) = "Se sustituyó ausentismo " & AusentismoActual & " el " & FechaSQL(FinAus)
                                    z = z + 1
                                End If
                            End If
                        End If

                        If CambioValido Then
                            'MCR 19/OCT/2015
                            'Insertar en bitácora borrado de ausentismo
                            sqlExecute("INSERT INTO bitacora_ausentismo " & _
                                          "(reloj,fecha,tipo_aus,tipo_movimiento,fecha_movimiento,usuario_movimiento,notas) " & _
                                       "SELECT reloj,fecha,tipo_aus,'A',GETDATE(),'" & Usuario & _
                                       "','/Usr:' + RTRIM(ISNULL(usuario,'')) + ' /Fha:' + CONVERT(char(20),ISNULL(fecha_hora,GETDATE()),20) + ' /Nta:' + RTRIM(ISNULL(subclasi,''))+'/Ref:'+RTRIM(ISNULL(referencia,''))+'/Met: " & _
                                       "<AUSENTISMO GLOBAL>'" & _
                                       "FROM ausentismo WHERE reloj = '" & Reloj & _
                                       "' AND  fecha = '" & FechaSQL(FinAus) & "'", "TA")

                            sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & Reloj & "' AND  fecha = '" & FechaSQL(FinAus) & "'", "TA")
                            sqlExecute("INSERT INTO ausentismo (cod_comp,reloj,fecha,tipo_aus,referencia,usuario,fecha_hora) VALUES ('" & _
                                       CodComp & "','" & _
                                       Reloj & "','" & _
                                       FechaSQL(FinAus) & "','" & _
                                       TipoAus & "'," & _
                                       "'','" & _
                                       Usuario & "', " & _
                                       "GETDATE())", "TA")
                            Try
                                ArCorrectos(w, 0) = ArLista(1, y).PadLeft(LongReloj, "0")
                                ArCorrectos(w, 1) = "Correcto"
                            Catch ex As Exception
                                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message, "Lista w:" & w & "  y:" & y & "  ArCorrectos(w,1):" & ArCorrectos.GetUpperBound(0) & "  ArLista(1,y):" & ArLista.GetUpperBound(1))
                            End Try
                            w = w + 1
                            analisis_independiente(Reloj, FinAus)
                        End If

                        FinAus = DateAdd(DateInterval.Day, 1, FinAus)
                        If Not (DiaDescanso(FinAus, Reloj) Or Festivo(FinAus, Reloj)) Then
                            d = d + 1
                        End If
                    Loop
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
            MessageBox.Show("Se detectaron errores durante la carga. A los siguientes empleados no se asignó ausentismo: " & Lista, "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf er > 0 Then
            MessageBox.Show("Se detecto un error antes de cargar el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("La carga de ausentismo concluyó exitosamente.", "Ausentismo masivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles btnArchivo.CheckedChanged
        btnBuscaArchivo.Enabled = btnArchivo.Checked
        txtArchivo.Enabled = btnArchivo.Checked
        txtLista.Enabled = btnLista.Checked
        btnBuscaLista.Enabled = btnLista.Checked
        cmbAusentismo.Enabled = btnLista.Checked
        txtFecha.Enabled = btnLista.Checked
        txtDias.Enabled = btnLista.Checked

        If btnArchivo.Checked Then
            txtArchivo.Focus()
        End If
    End Sub

    Private Sub btnLista_CheckedChanged(sender As Object, e As EventArgs) Handles btnLista.CheckedChanged
        btnBuscaArchivo.Enabled = btnArchivo.Checked
        txtArchivo.Enabled = btnArchivo.Checked
        txtLista.Enabled = btnLista.Checked
        btnBuscaLista.Enabled = btnLista.Checked
        cmbAusentismo.Enabled = btnLista.Checked
        txtFecha.Enabled = btnLista.Checked
        txtDias.Enabled = btnLista.Checked

        If btnLista.Checked Then
            txtLista.Focus()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ReflectionLabel1_Click(sender As Object, e As EventArgs) Handles ReflectionLabel1.Click

    End Sub

    Private Sub frmAusentismoGlobal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            NFiltros = 0

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub frmAusentismoGlobal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            'MCR 2017-10-10
            'Cambio para filtrar tipo de ausentismo por perfil 
            If Perfil.Contains("CLERK") Then
                FiltroAusentismo = "tipo_aus = 'C50'"
            Else
                dtFiltroPerfil = sqlExecute("SELECT filtro_ausentismo FROM perfiles WHERE cod_perfil " & Perfil, "SEGURIDAD")
                If dtFiltroPerfil.Rows.Count > 0 Then
                    FiltroAusentismo = IIf(IsDBNull(dtFiltroPerfil.Rows(0).Item("filtro_ausentismo")), "", dtFiltroPerfil.Rows(0).Item("filtro_ausentismo")).ToString.Trim
                End If
            End If
          
            txtFecha.Value = Today
            dtAusentismo = sqlExecute("SELECT tipo_aus,nombre FROM tipo_ausentismo WHERE tipo_naturaleza<>'I' " & _
                                      IIf(FiltroAusentismo.length > 0, " AND (" & FiltroAusentismo & ")", "") & " ORDER BY tipo_aus", "TA")
            cmbAusentismo.DataSource = dtAusentismo
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub frmAusentismoGlobal_MdiChildActivate(sender As Object, e As EventArgs) Handles Me.MdiChildActivate

    End Sub

    Private Sub gpAceptarCancelar_Enter(sender As Object, e As EventArgs) Handles gpAceptarCancelar.Enter

    End Sub
End Class