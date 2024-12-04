Public Class frmCambiosMasivos
    Dim dtValores As New DataTable
    Dim dtBajaInterno As New DataTable
    Dim dtBajaIMSS As New DataTable
    Dim dtCampos As New DataTable
    Dim FechaMod As Date = Today
    Dim TipoMod As String = "A"

    Private Sub frmCambiosMasivos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        NFiltros = 0
        Me.Dispose()
    End Sub

    Private Sub frmModSalMasivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Width = 640
            txtValorNuevo.Size = cmbValorNuevo.Size
            txtValorNuevo.Location = cmbValorNuevo.Location
            btnLogico.Location = cmbValorNuevo.Location
            txtFecha.Location = cmbValorNuevo.Location

            txtEBaja.Value = Today
            txtBajaTrans.Value = Today
            txtAltaTrans.Value = Today
            txtFecha.Value = Today

            txtRelojInicial.MaxLength = LongReloj

            gpTransferencias.Location = gpBajas.Location

            dtCampos = sqlExecute("SELECT UPPER(RTRIM(nombre)) AS 'NOMBRE',UPPER(cod_campo) as 'COD_CAMPO',tipo,tabla FROM campos WHERE editable=1 ORDER BY nombre")
            cmbCampo.DataSource = dtCampos

            cmbBajaInterno.DataSource = sqlExecute("SELECT cod_mot_ba AS 'CÓDIGO',nombre AS 'MOTIVO' FROM cod_mot_baj")
            cmbBajaInternoTrans.DataSource = sqlExecute("SELECT cod_mot_ba AS 'CÓDIGO',nombre AS 'MOTIVO' FROM cod_mot_baj")

            dtBajaIMSS = sqlExecute("SELECT cod_mot AS 'CÓDIGO',MOTIVO FROM cod_mot_baj_imss")
            'dtBajaIMSS.DefaultView.Sort = "CÓDIGO"
            cmbBajaImss.DataSource = dtBajaIMSS
            cmbBajaImssTrans.DataSource = dtBajaIMSS

            dtValores = sqlExecute("SELECT * FROM niveles")
            'Dim N As DataRow = dtValores.NewRow
            'N("nivel") = -1
            'N("nombre") = "No cambiar"
            'dtValores.Rows.Add(N)

            cmbValorNuevo.DataSource = dtValores

        Catch ex As Exception
            MessageBox.Show("Se encontraron errores durante la carga, por lo que pudiera no funcionar correctamente. Si el error persiste, se recomienda contactar a su administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub btnArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles btnArchivo.CheckedChanged
        btnBuscaArchivo.Enabled = btnArchivo.Checked
        txtArchivo.Enabled = btnArchivo.Checked
        txtLista.Enabled = btnLista.Checked
        btnBuscaLista.Enabled = btnLista.Checked
        If btnArchivo.Checked Then
            txtArchivo.Focus()
        End If
    End Sub

    Private Sub btnLista_CheckedChanged(sender As Object, e As EventArgs) Handles btnLista.CheckedChanged
        btnBuscaArchivo.Enabled = btnArchivo.Checked
        txtArchivo.Enabled = btnArchivo.Checked
        txtLista.Enabled = btnLista.Checked
        btnBuscaLista.Enabled = btnLista.Checked

        If btnLista.Checked Then
            txtLista.Focus()
        End If
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

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim dtInfoEmp As New DataTable
        Dim dtTemp As New DataTable
        Dim ArLista() As String
        Dim ArNuevos() As String
        Dim ArErrores(,) As String
        Dim ArReingresos(,) As String
        Dim Cadena As String
        Dim CodComp As String = ""
        Dim CompEmpleado As String = ""
        Dim Reloj As String = ""
        Dim RelojNvo As String = ""
        Dim CambioValido As Boolean
        Dim Archivo As String
        Dim LN As String
        Dim x As Integer
        Dim y As Integer
        Dim z As Integer
        Dim i As Integer
        Dim Reingresos As Integer = 0
        Dim ValorNvo As String = ""
        Dim ValorAnt As String = ""
        Dim Campo As String
        Dim DarDeBaja As Boolean
        Dim Transferencia As Boolean
        Dim AnoPeriodo As String

        If MessageBox.Show("Al continuar se aplicarán los cambios seleccionados al archivo de personal. ¿Está seguro de continuar?", "Aplicar cambios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Campo = cmbCampo.SelectedValue.ToString.Trim
        DarDeBaja = Campo = "BAJA"
        Transferencia = Campo = "COD_COMP"

        If txtValorNuevo.Visible Then
            ValorNvo = txtValorNuevo.Text
        ElseIf cmbValorNuevo.Visible Then
            CodComp = cmbValorNuevo.SelectedNode.Cells(1).Text.Trim
            ValorNvo = cmbValorNuevo.SelectedValue
        ElseIf btnLogico.Visible Then
            ValorNvo = IIf(btnLogico.Value, 1, 0)
        ElseIf txtFecha.Visible Then
            ValorNvo = FechaSQL(txtFecha.Value)
        End If

        Dim objReader As System.IO.StreamReader = Nothing

        Try
            If Transferencia Then
                ProcesarTransferencias()
                Exit Sub
            End If

            ReDim ArLista(1000)
            ReDim ArNuevos(1000)
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

                Try
                    Do Until objReader.EndOfStream
                        LN = objReader.ReadLine
                        ArLista(x) = LN.Trim.ToString.PadLeft(LongReloj, "0").Substring(0, LongReloj)
                        'If Transferencia Then
                        '    ArNuevos(x) = LN.Substring(LongReloj).Trim.PadLeft(LongReloj, "0")
                        'End If
                        x = x + 1
                        If UBound(ArLista) < x Then
                            ReDim Preserve ArLista(x)
                            ReDim Preserve ArNuevos(x)
                        End If
                    Loop

                    If Transferencia Then
                        For i = 0 To x
                            RelojNvo = Val(txtRelojInicial.Text) + i
                            ArNuevos(i) = RelojNvo.ToString.PadLeft(LongReloj, "0")
                            If UBound(ArNuevos) < i Then
                                ReDim Preserve ArLista(i)
                                ReDim Preserve ArNuevos(i)
                                ReDim ArReingresos(2, i)
                            End If
                        Next
                    End If
                Catch ex As Exception
                    MessageBox.Show("El archivo no es válido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                x = x - 1
                ReDim Preserve ArLista(x)
                ReDim Preserve ArNuevos(x)
                ReDim ArReingresos(2, x)
            Else
                ArLista = txtLista.Text.Split(",")
                x = ArLista.Length - 1
                If Transferencia Then
                    For i = 0 To x
                        RelojNvo = Val(txtRelojInicial.Text) + i
                        ArNuevos(i) = RelojNvo.ToString.PadLeft(LongReloj, "0")
                        If UBound(ArNuevos) < i Then
                            ReDim Preserve ArLista(i)
                            ReDim Preserve ArNuevos(i)
                            ReDim ArReingresos(2, i)
                        End If
                    Next
                End If
            End If
            ReDim ArErrores(x, 2)
            ReDim ArReingresos(x, 2)
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
                    dtTemporal = sqlExecute("SELECT cod_comp, reloj," & Campo & IIf(Not DarDeBaja, ",baja", "") & " from personal WHERE reloj = '" & Reloj & "'")
                    If dtTemporal.Rows.Count < 1 Then
                        ArErrores(z, 0) = ArLista(y)
                        ArErrores(z, 1) = "Empleado no localizado"
                        CambioValido = False
                        z = z + 1
                    Else
                        CompEmpleado = dtTemporal.Rows.Item(0).Item("cod_comp")
                        ValorAnt = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item(2)), "", dtTemporal.Rows.Item(0).Item(2))

                        If Not IsDBNull(dtTemporal.Rows.Item(0).Item("baja")) Then
                            ArErrores(z, 0) = ArLista(y)
                            ArErrores(z, 1) = "Empleado dado de baja"
                            CambioValido = False
                            z = z + 1
                        End If

                        If CompEmpleado <> CodComp And CodComp <> "" And Not Transferencia And CambioValido Then
                            ArErrores(z, 0) = ArLista(y)
                            ArErrores(z, 1) = "Diferente compañía"
                            CambioValido = False
                            z = z + 1
                        End If

                    End If
                End If

                If CambioValido Then
                    Dim mot_baj As String
                    Dim mot_ims As String
                    Dim sub_baj As String
                    Dim fBaja As Date
                    Dim fAlta As Date
                    Dim tipo As String
                    Dim Comentario As String

                    'sqlExecute("SELECT cod_comp, reloj,alta, baja,cod_mot_ba,cod_mot_im,cod_tipo,comentario from personalvw WHERE reloj = '" & Reloj & "'", dtTemporal)
                    dtInfoEmp = sqlExecute("SELECT * from personal WHERE reloj = '" & Reloj & "'")
                    fBaja = IIf(IsDBNull(dtInfoEmp.Rows.Item(0).Item("baja")), Nothing, dtInfoEmp.Rows.Item(0).Item("baja"))
                    fAlta = dtInfoEmp.Rows.Item(0).Item("alta")
                    mot_baj = IIf(IsDBNull(dtInfoEmp.Rows.Item(0).Item("cod_mot_ba")), "", dtInfoEmp.Rows.Item(0).Item("cod_mot_ba"))
                    mot_ims = IIf(IsDBNull(dtInfoEmp.Rows.Item(0).Item("cod_mot_im")), "", dtInfoEmp.Rows.Item(0).Item("cod_mot_im"))
                    sub_baj = IIf(IsDBNull(dtInfoEmp.Rows.Item(0).Item("cod_mot_ba")), "", dtInfoEmp.Rows.Item(0).Item("cod_mot_ba"))
                    tipo = dtInfoEmp.Rows.Item(0).Item("cod_tipo")
                    Comentario = IIf(IsDBNull(dtInfoEmp.Rows.Item(0).Item("comentario")), "", dtInfoEmp.Rows.Item(0).Item("comentario"))

                    If Transferencia Then
                        Cadena = ""
                        For i = 0 To dtInfoEmp.Columns.Count - 1
                            Cadena = Cadena & IIf(i > 0, ",", "") & dtInfoEmp.Columns(i).ColumnName
                        Next
                        RelojNvo = ArNuevos(y)
                        dtTemp = sqlExecute("SELECT reloj,baja from personal WHERE reloj = '" & RelojNvo & "'")
                        If dtTemp.Rows.Count > 0 Then
                            If IsDBNull(dtTemp.Rows(0).Item("baja")) Then
                                ArErrores(z, 0) = Reloj
                                ArErrores(z, 1) = "Transferencia a reloj activo (" & RelojNvo & ")"
                                CambioValido = False
                            Else
                                ArReingresos(Reingresos, 0) = Reloj
                                ArReingresos(Reingresos, 1) = RelojNvo
                                Reingresos = Reingresos + 1
                                Dim Respuesta As System.Windows.Forms.DialogResult
                                Respuesta = MessageBox.Show("El número de reloj asignado ya existe, aunque se encuentra dado de baja. ¿Desea manejarlo como reingreso?", "Transferencia duplicada", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                                If Respuesta = Windows.Forms.DialogResult.Yes Then
                                    'Cadena = Cadena.Replace("RELOJ", "'" & RelojNvo & "'")
                                    'sqlExecute("INSERT INTO personal SELECT " & Cadena & " from personalvw WHERE reloj = '" & Reloj & "'", dtTemp)

                                    sqlExecute("UPDATE personal SET alta = '" & FechaSQL(txtAltaTrans.Value) & "', baja = NULL, reingreso = 1, cod_comp = '" & ValorNvo & "' WHERE reloj = '" & RelojNvo & "'")

                                    DarDeBaja = True
                                    Reloj = RelojNvo
                                ElseIf Respuesta = Windows.Forms.DialogResult.No Then
                                    CambioValido = False
                                Else
                                    Exit For
                                End If
                            End If
                        Else
                            Cadena = Cadena.Replace("RELOJ", "'" & RelojNvo & "'")
                            sqlExecute("INSERT INTO personal SELECT " & Cadena & " from personal WHERE reloj = '" & Reloj & "'")
                            If btnAntiguedad.Value Then
                                'Si se respeta antigüedad


                                'campos de antiguedad abraham

                                'sqlExecute("UPDATE personal SET alta_imss = '" & FechaSQL(txtAltaTrans.Value) & "', " & _
                                '           "baja = NULL, reingreso = 0, cod_comp = '" & ValorNvo & "' WHERE reloj = '" & RelojNvo & "'")

                                sqlExecute("UPDATE personal SET  baja = NULL, cod_comp = '" & ValorNvo & "' WHERE reloj = '" & RelojNvo & "'")

                            Else
                                'Si no se va a respetar la antigüedad
                                'sqlExecute("UPDATE personal SET alta_imss = '" & FechaSQL(txtAltaTrans.Value) & _
                                '           "', alta = '" & FechaSQL(txtAltaTrans.Value) & "', " & _
                                '           "baja = NULL, reingreso = 0, cod_comp = '" & ValorNvo & "' WHERE reloj = '" & RelojNvo & "'")

                                sqlExecute("UPDATE personal SET  alta = '" & FechaSQL(txtAltaTrans.Value) & "', " & _
                                           "baja = NULL,  cod_comp = '" & ValorNvo & "' WHERE reloj = '" & RelojNvo & "'")
                            End If

                            DarDeBaja = True
                            'Reloj = RelojNvo
                            txtEBaja.Value = txtBajaTrans.Value
                        End If

                    End If

                    If DarDeBaja Then
                        Dim SaldoVacaciones As Double
                        Dim Aguinaldo As Double
                        Dim Ano As String
                        Dim Periodo As String

                        Dim ClaveAG As String
                        Dim ClaveVA As String

                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','baja'," & IIf(IsNothing(fBaja) Or fBaja = New Date, "NULL", "'" & FechaSQL(fBaja) & "'") & ",'" & FechaSQL(txtEBaja.Value) & "','" & Usuario & "',GETDATE(),'B')"
                        sqlExecute(Cadena)

                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','baja_imss'," & IIf(IsNothing(fBaja) Or fBaja = New Date, "NULL", "'" & FechaSQL(fBaja) & "'") & ",'" & FechaSQL(txtEBaja.Value) & "','" & Usuario & "',GETDATE(),'B')"
                        sqlExecute(Cadena)

                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','cod_mot_ba','" & mot_baj & "','" & cmbBajaInterno.Text & "','" & Usuario & "',GETDATE(),'B')"
                        sqlExecute(Cadena)

                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','cod_sub_ba','" & sub_baj & "','" & cmbSubBaja.Text & "','" & Usuario & "',GETDATE(),'B')"
                        sqlExecute(Cadena)

                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','cod_mot_im','" & mot_ims & "','" & cmbBajaImss.Text & "','" & Usuario & "',GETDATE(),'B')"
                        sqlExecute(Cadena)

                        ''******* FINIQUITO ********
                        ' VACACIONES
                        dtTemp = sqlExecute("SELECT TOP 1 saldo_dinero FROM saldos_vacaciones WHERE reloj = '" & Reloj & "' ORDER BY fecha_fin DESC")
                        If dtTemp.Rows.Count > 0 Then
                            SaldoVacaciones = dtTemp.Rows.Item(0).Item("saldo_dinero")
                        Else
                            SaldoVacaciones = 0
                        End If
                        SaldoVacaciones = SaldoVacaciones + ProporcionVacaciones(fAlta, txtEBaja.Value, tipo, CompEmpleado)
                        ' AGUINALDO 
                        Aguinaldo = ProporcionAguinaldo(fAlta, txtEBaja.Value, tipo, CompEmpleado)


                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','dias_vacaciones'," & SaldoVacaciones & ",'" & Usuario & "',GETDATE(),'B')"
                        sqlExecute(Cadena)

                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','dias_aguinaldo'," & Aguinaldo & ",'" & Usuario & "',GETDATE(),'B')"
                        sqlExecute(Cadena)

                        '**** PROCESO PARA APLICAR VACACIONES EN MISCELANEOS DE NOMINA *******
                        dtTemp = sqlExecute("SELECT ano, periodo FROM periodos WHERE GETDATE() BETWEEN fecha_ini AND fecha_fin AND periodo_especial IS NULL OR periodo_especial = 0", "TA")
                        If dtTemp.Rows.Count > 0 Then
                            Ano = dtTemp.Rows.Item(0).Item("ano")
                            Periodo = dtTemp.Rows.Item(0).Item("periodo")
                        Else
                            Ano = "XXXX"
                            Periodo = "XX"
                        End If

                        dtTemp = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = 'DIASVA'", "NOMINA")
                        If dtTemp.Rows.Count > 0 Then
                            ClaveVA = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("misce_clave")), "", dtTemp.Rows.Item(0).Item("misce_clave"))
                        Else
                            ClaveVA = ""
                        End If

                        dtTemp = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = 'DIASAG'", "NOMINA")
                        If dtTemp.Rows.Count > 0 Then
                            ClaveAG = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("misce_clave")), "", dtTemp.Rows.Item(0).Item("misce_clave"))
                        Else
                            ClaveAG = ""
                        End If

                        Cadena = "INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha) VALUES ('"
                        Cadena = Cadena & Reloj & "','" & Ano & "','" & Periodo & "','P','" & ClaveVA & "'," & SaldoVacaciones & ",'Días de vacaciones por finiquito','DIASVA','"
                        Cadena = Cadena & Usuario & "', GETDATE())"
                        sqlExecute(Cadena, "Nomina")

                        Cadena = "INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha) VALUES ('"
                        Cadena = Cadena & Reloj & "','" & Ano & "','" & Periodo & "','P','" & ClaveAG & "'," & Aguinaldo & ",'Días de aguinaldo por finiquito','DIASAG','"
                        Cadena = Cadena & Usuario & "', GETDATE())"
                        sqlExecute(Cadena, "Nomina")
                        '*****************************************

                        Comentario = IIf(Comentario <> "", Comentario & vbCrLf & vbCrLf, "") & txtComentarios.Text
                        sqlExecute("UPDATE personal SET  baja = '" & FechaSQL(txtEBaja.Value) & _
                                   "', cod_mot_ba = '" & cmbBajaInterno.SelectedValue & "',cod_mot_im = '" & cmbBajaImss.SelectedValue & _
                                   "',dias_vacaciones = " & SaldoVacaciones & ",dias_aguinaldo = " & Aguinaldo & ",comentario = '" & _
                                   Comentario & "' WHERE reloj = '" & Reloj & "'")


                    ElseIf CambioValido Then
                        If Transferencia Then
                            Reloj = RelojNvo
                        End If

                        sqlExecute("UPDATE personal SET " & Campo & " = '" & ValorNvo & "' WHERE reloj = '" & Reloj & "'")

                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','" & Campo & "','" & ValorAnt & "','" & ValorNvo & "','" & Usuario & "',GETDATE(),'S')"
                        sqlExecute(Cadena)

                        'MCR (6-OCT-2015)
                        'Si el campo es cod_depto o cod_super, modificar asist en el periodo actual
                        If Campo.Trim.ToUpper = "COD_DEPTO" Or Campo.Trim.ToUpper = "COD_SUPER" Then
                            AnoPeriodo = ObtenerAnoPeriodo(Now)
                            sqlExecute("UPDATE asist SET " & Campo & " = '" & ValorNvo & "' WHERE reloj = '" & Reloj & _
                                       "' AND ano = '" & AnoPeriodo.Substring(0, 4) & "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'", "TA")
                        End If
                    End If

                    If Transferencia And CambioValido Then
                        dtInfoEmp = sqlExecute("SELECT * from personal WHERE reloj = '" & RelojNvo & "'")

                        For Each fld As System.Data.DataColumn In dtInfoEmp.Columns
                            Try


                                If fld.ColumnName.Trim.ToLower = "baja" Then

                                End If
                                If fld.ColumnName.ToLower.Trim <> "reloj" And Not IsDBNull(dtInfoEmp.Rows(0).Item(fld.ColumnName.Trim)) Then
                                    If fld.DataType = GetType(System.DateTime) Then
                                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                                        Cadena = Cadena & RelojNvo & "','" & fld.ColumnName & "',NULL,'" & FechaSQL(dtInfoEmp.Rows(0).Item(fld.ColumnName).ToString) & "','" & Usuario & "',GETDATE(),'A')"
                                    Else
                                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                                        Cadena = Cadena & RelojNvo & "','" & fld.ColumnName & "',NULL,'" & dtInfoEmp.Rows(0).Item(fld.ColumnName) & "','" & Usuario & "',GETDATE(),'A')"
                                        Debug.Print(fld.DataType.ToString)
                                    End If
                                    sqlExecute(Cadena)
                                End If

                            Catch ex As Exception

                            End Try

                        Next
                    End If

                End If
            Next

            cpActualizacion.Visible = False
            If z > 0 Then
                Dim Lista As String = ""
                For x = 0 To z - 1
                    Lista = Lista & vbCrLf & "  " & ArErrores(x, 0) & " " & ArErrores(x, 1)
                Next
                MessageBox.Show("Se detectaron errores durante la carga. Estos empleados no fueron modificados: " & Lista & vbCrLf & vbCrLf & "Los registros que no presentaron error fueron aplicados.", "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Todos los cambios fueron aplicados exitosamente.", "Cambios aplicados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se detectó un error durante la aplicación de los cambios." & vbCrLf & vbCrLf & ex.HResult & ".-" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Structure transferencia
        Dim reloj_anterior As String
        Dim reloj_nuevo As String
        Dim cod_comp_anterior As String
        Dim Alta_anterior As Date
        Dim Baja_anterior As Date
        Dim IMSS As String
    End Structure

    Private Sub ProcesarTransferencias()
        Try
            Dim dtPersonal As DataTable

            Dim transferencias As New ArrayList
            Dim errores As New ArrayList
            Dim ID As Integer
            Dim sdo As Double
            Dim Factor As Double
            Dim Integrado As Double
            Dim Tipo As String = ""
            Dim Dato As String
            Dim i As Integer = 0

            If btnArchivo.Checked Then
                If System.IO.File.Exists(txtArchivo.Text.Trim) Then
                    Dim f As New System.IO.StreamReader(txtArchivo.Text.Trim)
                    'MCR 19/NOV/2015
                    'Cambio para tomar número de reloj nuevo desde archivo texto (si lo trae)
                    Do Until f.EndOfStream
                        Dim t As New transferencia
                        Dato = f.ReadLine
                        t.reloj_anterior = Dato.Substring(0, LongReloj)
                        t.reloj_nuevo = Dato.Substring(LongReloj).Trim
                        If t.reloj_nuevo = "" Then
                            If txtRelojInicial.TextLength = 0 Then
                                Err.Raise(-1, "ProcesarTransferencias", "Es necesario asignar el número de reloj inicial.")
                            Else
                                t.reloj_nuevo = ((txtRelojInicial.Text + i).ToString.Trim.PadLeft(LongReloj, "0")).ToString
                                i += 1
                            End If

                        End If

                        transferencias.Add(t)
                    Loop
                Else
                    MessageBox.Show("No se encontró el archivo indicado", "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            ElseIf btnLista.Checked Then
                If txtRelojInicial.TextLength = 0 Then
                    Err.Raise(-1, "ProcesarTransferencias", "Es necesario asignar el número de reloj inicial.")
                End If
                Dim relojes() As String = txtLista.Text.Split(",")
                For Each r As String In relojes
                    Dim t As New transferencia
                    t.reloj_anterior = r.Trim.PadLeft(LongReloj, "0")
                    t.reloj_nuevo = ((txtRelojInicial.Text + i).ToString.Trim.PadLeft(LongReloj, "0")).ToString
                    i += 1
                    transferencias.Add(t)
                Next
            End If

            If cmbNivel.SelectedValue Is Nothing And btnSueldo.Value = False Then
                'Validar si no se mantiene el sueldo, que el nivel no está en blanco
                MessageBox.Show("El nivel no puede quedar en blanco cuando no se mantiene el sueldo.", "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf btnSueldo.Value = False Then
                dtTemporal = sqlExecute("SELECT cod_tipo FROM niveles WHERE cod_comp ='" & cmbValorNuevo.SelectedValue & _
                                        "' AND nivel = '" & cmbNivel.SelectedValue & "'")
                If dtTemporal.Rows.Count > 0 Then
                    Tipo = dtTemporal.Rows(0).Item("cod_tipo").ToString.Trim
                Else
                    Tipo = ""
                End If
            End If

            'Validaciones
            For Each t As transferencia In transferencias
                'MCR 19/NOV/2015
                'Revisar si la compañía del empleado es editable
                'Si no lo es, no permitir modificarlo
                dtTemporal = sqlExecute("SELECT editable FROM cias " & _
                                            "LEFT JOIN Personal ON cias.cod_comp = personal.cod_comp " & _
                                            "WHERE personal.reloj = '" & t.reloj_anterior.ToString.Trim & "' AND (editable IS NULL OR editable = 1)")
                If dtTemporal.Rows.Count = 0 Then
                    errores.Add(t.reloj_anterior.ToString & " Compañía no editable")
                End If
                '******************************

                'Longitud de número nuevo
                If t.reloj_nuevo.Length > LongReloj Then
                    errores.Add(t.reloj_nuevo.ToString & " Número de reloj demasiado largo")
                End If

                'Empleados existentes en personal
                dtPersonal = sqlExecute("select reloj from personal where reloj = '" & t.reloj_anterior & "'")
                If dtPersonal.Rows.Count <= 0 Then
                    errores.Add(t.reloj_anterior.ToString & " Empleado no localizado")
                End If

                'Que no exista el número de reloj a asignar
                dtPersonal = sqlExecute("select reloj from personal where reloj = '" & t.reloj_nuevo & "'")
                If dtPersonal.Rows.Count > 0 Then
                    errores.Add(t.reloj_anterior.ToString & " Reloj nuevo ya existe (NVO: " & t.reloj_nuevo & ")")
                End If

                dtPersonal = sqlExecute("select reloj,alta, baja,cod_comp,imss+dig_ver as imss,sactual,cod_tipo from personal where reloj = '" & t.reloj_anterior & "'")
                If dtPersonal.Rows.Count > 0 Then
                    Dim Row As DataRow = dtPersonal.Rows(0)
                    ' Bajas o ya forman parte de la compania a transferir

                    If Not IsDBNull(Row("baja")) Then
                        errores.Add(t.reloj_anterior.ToString & " Empleado dado de baja")
                    ElseIf (Row("cod_comp")) = cmbValorNuevo.SelectedValue Then
                        errores.Add(t.reloj_anterior.ToString & " El empleado ya forma parte de la compañía " & Row("cod_comp"))
                    ElseIf Row("sactual") = 0 And btnSueldo.Value Then
                        errores.Add(t.reloj_anterior.ToString & " El sueldo está en 0")
                    ElseIf Not btnSueldo.Value And Row("cod_tipo").ToString.Trim <> Tipo Then
                        errores.Add(t.reloj_anterior.ToString & " El tipo de empleado no coincide con el nivel")
                    Else
                        'Tomar datos anteriores
                        t.cod_comp_anterior = Row("cod_comp")
                        t.Alta_anterior = Row("alta")
                        t.Baja_anterior = IIf(IsDBNull(Row("baja")), Nothing, Row("baja"))
                        t.IMSS = IIf(IsDBNull(Row("imss")), "", Row("imss"))
                    End If
                End If
            Next

            If errores.Count > 0 Then
                Dim m As String = ""
                For Each e As String In errores
                    m &= e & vbCrLf
                Next
                MsgBox(m, MsgBoxStyle.OkOnly, "Errores")
                Exit Sub
            Else
                For Each t As transferencia In transferencias
                    Dim dtActual As DataTable = sqlExecute("select * from personal where reloj = '" & t.reloj_anterior & "'")
                    If dtActual.Rows.Count > 0 Then
                        Dim dr As DataRow = dtActual.Rows(0)

                        ' TRANSFERENCIA
                        sqlExecute("insert into personal (cod_comp, reloj) values ('" & cmbValorNuevo.SelectedValue & "', '" & t.reloj_nuevo & "')")

                        ' transferir campos similares
                        For Each column As DataColumn In dtActual.Columns
                            If column.ColumnName.ToLower.Trim <> "reloj" And _
                                    column.ColumnName.ToLower.Trim <> "cod_comp" And _
                                    column.ColumnName.ToLower.Trim <> "rowguid" Then

                                Dim valor_nuevo As String = ""

                                If column.DataType = Type.GetType("System.Date") Or column.DataType = Type.GetType("System.DateTime") Then
                                    If IsDBNull(dr(column.ColumnName)) Then
                                        valor_nuevo = "NULL"
                                    Else
                                        valor_nuevo = FechaSQL(dr(column.ColumnName))

                                    End If
                                Else
                                    valor_nuevo = IIf(IsDBNull(dr(column.ColumnName)), "NULL", dr(column.ColumnName))
                                End If

                                ' actualizar campo
                                If valor_nuevo <> "NULL" Then
                                    sqlExecute("update personal set " & column.ColumnName & " = '" & valor_nuevo & "' where reloj = '" & t.reloj_nuevo & "'")
                                    ' guardar registro en la bitacora
                                    sqlExecute("insert into bitacora_personal (reloj,campo,valoranterior,valornuevo,usuario,fecha,tipo_movimiento) values ('" & _
                                               t.reloj_nuevo & "', '" & _
                                               column.ColumnName & "', " & _
                                               "'', '" & _
                                               valor_nuevo & "', '" & _
                                               Usuario & "', GETDATE(), " & _
                                               "'A')")
                                End If

                            End If
                        Next

                        ' transferir fecha de alta nueva
                        sqlExecute("update personal set alta = '" & FechaSQL(txtAltaTrans.Value) & "' where reloj = '" & t.reloj_nuevo & "'")
                        ' asegurarse que la baja sea null
                        sqlExecute("update personal set baja = NULL where reloj = '" & t.reloj_nuevo & "'")

                        'Recalcular integrado
                        If btnSueldo.Value Then
                            sdo = IIf(IsDBNull(dr("sactual")), 0, dr("sactual"))
                        Else
                            sdo = CDbl(txtSActual.Text)
                            'Actualizar el nivel y sueldo cuando se seleccione NO mantener
                            sqlExecute("update personal set sactual = " & sdo & " where reloj = '" & t.reloj_nuevo & "'")
                            sqlExecute("update personal set nivel = '" & cmbNivel.SelectedValue & "' where reloj = '" & t.reloj_nuevo & "'")
                        End If

                        Factor = Format(FactorIntegracion(cmbValorNuevo.SelectedValue, dr("cod_tipo"), DateDiff(DateInterval.Year, txtAltaTrans.Value, UltimoDiaBimestre(Today))), "0.0000")
                        Integrado = Math.Round(sdo * Factor, 4)
                        sqlExecute("update personal set integrado = " & Integrado & ", factor_int = " & Factor & ", pro_var = 0 where reloj = '" & t.reloj_nuevo & "'")

                        'Dar de baja el reloj anterior
                        sqlExecute("update personal set baja = '" & FechaSQL(txtBajaTrans.Value) & "' where reloj = '" & t.reloj_anterior & "'")
                        sqlExecute("insert into bitacora_personal (reloj, campo, valoranterior, valornuevo, usuario, fecha, tipo_movimiento) values ('" & t.reloj_anterior & "', 'baja', '', '" & FechaSQL(txtBajaTrans.Value) & "', '" & Usuario & "', GETDATE(), 'B')")

                        sqlExecute("update personal set cod_mot_ba = '" & cmbBajaInternoTrans.SelectedValue & "' where reloj = '" & t.reloj_anterior & "'")
                        sqlExecute("insert into bitacora_personal (reloj, campo, valoranterior, valornuevo, usuario, fecha, tipo_movimiento) values ('" & t.reloj_anterior & "', 'cod_mot_ba', '', '" & cmbBajaInternoTrans.SelectedValue & "', '" & Usuario & "', GETDATE(), 'B')")

                        sqlExecute("update personal set cod_sub_ba = '" & cmbSubTransferencia.SelectedValue & "' where reloj = '" & t.reloj_anterior & "'")
                        sqlExecute("insert into bitacora_personal (reloj, campo, valoranterior, valornuevo, usuario, fecha, tipo_movimiento) values ('" & t.reloj_anterior & "', 'cod_sub_ba', '', '" & cmbSubTransferencia.SelectedValue & "', '" & Usuario & "', GETDATE(), 'B')")

                        sqlExecute("update personal set cod_mot_im = '" & cmbBajaImssTrans.SelectedValue & "' where reloj = '" & t.reloj_anterior & "'")
                        sqlExecute("insert into bitacora_personal (reloj, campo, valoranterior, valornuevo, usuario, fecha, tipo_movimiento) values ('" & t.reloj_anterior & "', 'cod_mot_im', '', '" & cmbBajaImssTrans.SelectedValue & "', '" & Usuario & "', GETDATE(), 'B')")

                        Dim vacaciones As Double = ProporcionVacaciones(dr("alta"), txtBajaTrans.Value, dr("cod_tipo"), dr("cod_comp"))
                        sqlExecute("update personal set dias_vacaciones = '" & vacaciones & "' where reloj = '" & t.reloj_anterior & "'")
                        sqlExecute("insert into bitacora_personal (reloj, campo, valoranterior, valornuevo, usuario, fecha, tipo_movimiento) values ('" & t.reloj_anterior & "', 'dias_vacaciones', '', '" & vacaciones & "', '" & Usuario & "', GETDATE(), 'B')")

                        Dim agui As Double = ProporcionAguinaldo(dr("alta"), txtBajaTrans.Value, dr("cod_tipo"), dr("cod_comp"))
                        sqlExecute("update personal set dias_aguinaldo = '" & agui & "' where reloj = '" & t.reloj_anterior & "'")
                        sqlExecute("insert into bitacora_personal (reloj, campo, valoranterior, valornuevo, usuario, fecha, tipo_movimiento) values ('" & t.reloj_anterior & "', 'dias_aguinaldo', '', '" & agui & "', '" & Usuario & "', GETDATE(), 'B')")

                        sqlExecute("INSERT INTO transferencias (reloj_anterior,cod_comp_anterior,imss,alta_anterior,baja_anterior,reloj_nuevo,cod_comp_nuevo,alta) " & _
                                   "VALUES (" & _
                                   "'" & t.reloj_anterior & "'," & _
                                   "'" & dr("cod_comp") & "'," & _
                                   "'" & dr("imss") & dr("dig_ver") & "'," & _
                                   "'" & FechaSQL(dr("alta")) & "'," & _
                                   "'" & FechaSQL(txtBajaTrans.Value) & "'," & _
                                   "'" & t.reloj_nuevo & "'," & _
                                   "'" & cmbValorNuevo.SelectedValue & "'," & _
                                   "'" & FechaSQL(txtAltaTrans.Value) & "')")

                        'Transferir capacitación
                        sqlExecute("UPDATE cursos_empleado SET reloj = '" & t.reloj_nuevo & "', comentario = comentario + 'TRANSFERENCIA DE #" & t.reloj_anterior & _
                                   "' WHERE RELOJ = '" & t.reloj_anterior & "'", "CAPACITACION")
                        sqlExecute("UPDATE evaluaciones_empleados SET reloj = '" & t.reloj_nuevo & "'" & _
                                   " WHERE RELOJ = '" & t.reloj_anterior & "'", "CAPACITACION")
                        sqlExecute("UPDATE planeacion_empleados SET reloj = '" & t.reloj_nuevo & "'" & _
                                   " WHERE RELOJ = '" & t.reloj_anterior & "'", "CAPACITACION")
                        sqlExecute("UPDATE respuestas_empleados SET reloj = '" & t.reloj_nuevo & "'" & _
                                   " WHERE RELOJ = '" & t.reloj_anterior & "'", "CAPACITACION")
                        sqlExecute("UPDATE licencias_pallet SET reloj = '" & t.reloj_nuevo & "'" & _
                                   " WHERE RELOJ = '" & t.reloj_anterior & "'", "CAPACITACION")
                        sqlExecute("UPDATE licencias SET reloj = '" & t.reloj_nuevo & "'" & _
                                   " WHERE RELOJ = '" & t.reloj_anterior & "'", "CAPACITACION")
                        ' transferir foto
                        Try
                            Dim dtFotoAnterior As DataTable = sqlExecute("select foto from personalvw where reloj = '" & t.reloj_anterior & "'")
                            Dim dtFotoNuevo As DataTable = sqlExecute("select foto from personalvw where reloj = '" & t.reloj_nuevo & "'")
                            If dtFotoAnterior.Rows.Count > 0 And dtFotoNuevo.Rows.Count Then
                                If System.IO.File.Exists(dtFotoAnterior.Rows(0)("foto")) Then
                                    If System.IO.File.Exists(dtFotoNuevo.Rows(0)("foto")) Then
                                        System.IO.File.Delete(dtFotoNuevo.Rows(0)("foto"))
                                    End If
                                    System.IO.File.Copy(dtFotoAnterior.Rows(0)("foto"), dtFotoNuevo.Rows(0)("foto"))
                                End If
                            End If
                        Catch ex As Exception
                            errores.Add(t.reloj_anterior.ToString & " No fue posible transferir la fotografía")
                        End Try

                        Try
                            ' transferir familiares
                            Dim dtFamilia As DataTable = sqlExecute("select * from familiares where reloj = '" & t.reloj_anterior & "'")
                            For Each row As DataRow In dtFamilia.Rows
                                sqlExecute("insert into familiares (cod_comp, reloj, cod_familia, nombre, fecha_nac) values ('" & _
                                           cmbValorNuevo.SelectedValue & "', '" & _
                                           t.reloj_nuevo & "', '" & _
                                           row("cod_familia") & "', '" & _
                                           row("nombre") & "', " & _
                                           IIf(IsDBNull(row("fecha_nac")), "NULL", "'" & FechaSQL(row("fecha_nac")) & "'") & ")")
                            Next

                            'transferir escolaridad
                            Dim dtEscolaridad As DataTable = sqlExecute("select * from escolaridad where reloj = '" & t.reloj_anterior & "'")
                            For Each row As DataRow In dtEscolaridad.Rows
                                sqlExecute("insert into escolaridad (cod_comp, reloj, cod_escuela, anos, finalizo,nombre_escuela) values ('" & _
                                           cmbValorNuevo.SelectedValue & "', '" & _
                                           t.reloj_nuevo & "', '" & _
                                           row("cod_escuela") & "', " & _
                                           row("anos") & ", " & _
                                           row("finalizo") & ", '" & _
                                           row("nombre_escuela") & "')")
                            Next

                            'transferir auxiliares
                            Dim dtAuxiliares As DataTable = sqlExecute("select max(idFld) AS ID from detalle_auxiliares")
                            If dtAuxiliares.Rows.Count = 0 Then
                                ID = 0
                            Else
                                ID = dtAuxiliares.Rows(0).Item("ID")
                            End If
                            dtAuxiliares = sqlExecute("select * from detalle_auxiliares where reloj = '" & t.reloj_anterior & "'")
                            For Each row As DataRow In dtAuxiliares.Rows
                                ID += 1
                                sqlExecute("insert into detalle_auxiliares (cod_comp, reloj, campo, contenido,idfld) values ('" & _
                                           cmbValorNuevo.SelectedValue & "', '" & _
                                           t.reloj_nuevo & "', '" & _
                                           row("campo") & "', '" & _
                                           row("contenido") & "', " & _
                                           ID & ")")
                            Next

                            'Transferir T&A
                            sqlExecute("UPDATE asist SET reloj = '" & t.reloj_nuevo & "', cod_comp = '" & cmbValorNuevo.SelectedValue & _
                                       "' WHERE reloj = '" & t.reloj_anterior & "' AND fha_ent_hor>='" & FechaSQL(txtAltaTrans.Value) & "'", "TA")
                            sqlExecute("UPDATE ausentismo SET reloj = '" & t.reloj_nuevo & "', cod_comp = '" & cmbValorNuevo.SelectedValue & _
                                       "' WHERE reloj = '" & t.reloj_anterior & "' AND fecha>='" & FechaSQL(txtAltaTrans.Value) & "'", "TA")
                            sqlExecute("UPDATE bitacora_hrs_brt SET reloj = '" & t.reloj_nuevo & _
                                       "' WHERE reloj = '" & t.reloj_anterior & "' AND fecha>='" & FechaSQL(txtAltaTrans.Value) & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET reloj = '" & t.reloj_nuevo & _
                                       "' WHERE reloj = '" & t.reloj_anterior & "' AND fecha>='" & FechaSQL(txtAltaTrans.Value) & "'", "TA")
                            sqlExecute("UPDATE hrs_brt SET reloj = '" & t.reloj_nuevo & "', cod_comp = '" & cmbValorNuevo.SelectedValue & _
                                       "' WHERE reloj = '" & t.reloj_anterior & "' AND fecha>='" & FechaSQL(txtAltaTrans.Value) & "'", "TA")
                            sqlExecute("UPDATE nomsem SET reloj = '" & t.reloj_nuevo & "', cod_comp = '" & cmbValorNuevo.SelectedValue & _
                                       "' WHERE ano + periodo >='" & ObtenerAnoPeriodo(txtAltaTrans.Value) & "' AND reloj = '" & t.reloj_anterior & "'", "TA")
                            sqlExecute("UPDATE nomsem_ref_horas SET reloj = '" & t.reloj_nuevo & _
                                       "' WHERE reloj = '" & t.reloj_anterior & "' AND ano+periodo>='" & ObtenerAnoPeriodo(txtAltaTrans.Value) & "'", "TA")
                        Catch ex As Exception
                            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                        End Try


                    Else
                        Err.Raise(-1, , "Empleado no localizado (por el sistema) " & t.reloj_anterior)
                    End If
                Next

                cpActualizacion.Visible = False
                MessageBox.Show("Todos los cambios fueron aplicados exitosamente.", "Cambios aplicados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se detectó un error durante la aplicación de los cambios." & vbCrLf & vbCrLf & ex.HResult & ".-" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                dtTemporal = ConsultaPersonalVW("SELECT RELOJ from personal WHERE " & FL)

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

    Private Sub cmbValorNuevo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbValorNuevo.SelectedIndexChanged
        If cmbCampo.SelectedValue.ToString.Trim = "COD_COMP" And Not cmbValorNuevo.SelectedValue Is Nothing Then
            cmbComentariosTrans.Text = "Transferencia a la compañía " & cmbValorNuevo.SelectedValue
            cmbNivel.DataSource = sqlExecute("SELECT * FROM niveles WHERE cod_comp = '" & cmbValorNuevo.SelectedValue & "'")
        End If
    End Sub

    Private Sub cmbCampo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCampo.SelectedValueChanged

        Dim Campo As String
        Dim Tipo As String
        Dim Tabla As String
        Dim Cadena As String
        Try
            If cmbCampo.SelectedIndex >= 0 Then
                Campo = cmbCampo.SelectedValue.ToString.Trim
            Else
                Exit Sub
            End If

            Tipo = cmbCampo.SelectedNode.Cells(2).Text.Trim
            Tabla = cmbCampo.SelectedNode.Cells(3).Text.Trim
            'pnlCaracter.Visible = cbCampos.SelectedNode.NodesColumns.Item("tipo")
            gpBajas.Enabled = Campo = "BAJA"
            cmbValorNuevo.Enabled = Campo <> "BAJA"
            txtValorNuevo.Enabled = Campo <> "BAJA"

            gpTransferencias.Enabled = Campo = "COD_COMP"
            gpBajas.Visible = Campo <> "COD_COMP"
            gpTransferencias.Visible = Campo = "COD_COMP"
            txtRelojInicial.Enabled = True

            If Tabla = "" Then
                'Si el campo no está relacionado a una tabla, permitir introducir texto
                btnLogico.Visible = (Tipo = "bool")
                cmbValorNuevo.Visible = False
                txtValorNuevo.Visible = (Tipo = "char" Or Tipo = "num")
                txtFecha.Visible = (Tipo = "date" And Campo <> "BAJA")

                If Tipo = "bool" Then
                    btnLogico.Focus()
                ElseIf Campo = "BAJA" Then
                    txtEBaja.Focus()
                ElseIf Tipo = "date" Then
                    txtFecha.Focus()
                Else
                    txtValorNuevo.Text = ""
                    txtValorNuevo.Focus()
                End If
            Else
                'Si el campo está relacionado a una tabla, cargar datos en combo, y mostrar
                btnLogico.Visible = False
                txtValorNuevo.Visible = False
                cmbValorNuevo.Visible = True

                cmbValorNuevo.Columns(0).Visible = True
                cmbValorNuevo.Columns(1).Visible = True
                cmbValorNuevo.Columns(2).Visible = True

                If Tabla = "cias" Then
                    'MCR 19/NOV/2015
                    'Si el cambio es de compañía (transferencia), permitir solo las compañías editables (SUCCESS FACTOR BRP)
                    Cadena = "SELECT cod_comp AS 'CODIGO',NOMBRE FROM cias WHERE editable = 1"
                    cmbValorNuevo.Columns(1).Visible = False
                Else

                    'Buscar si existe el campo 'NOMBRE'
                    dtTemporal = sqlExecute("SELECT COL_LENGTH('" & Tabla & "','nombre') AS campo")
                    If dtTemporal.Rows.Count = 0 Then
                        'Si no regresó registros, no mostrar
                        Cadena = "SELECT " & Campo & " AS 'NOMBRE' FROM " & Tabla
                        cmbValorNuevo.Columns("ColCiaValor").Visible = False
                        cmbValorNuevo.Columns("ColCodValor").Visible = False
                    Else
                        'Si el "campo" es nulo, no existe el campo nombre en la tabla
                        'por lo tanto, ocultar las otras columnas, y utilizar solo el valor como nombre
                        If IsDBNull(dtTemporal.Rows(0).Item("campo")) Then
                            Cadena = "SELECT " & Campo & " AS 'NOMBRE' FROM " & Tabla
                            cmbValorNuevo.Columns("ColCiaValor").Visible = False
                            cmbValorNuevo.Columns("ColCodValor").Visible = False
                        Else
                            'Si sí hay campo "nombre", buscar campo "cod_comp", y seguir el mismo procedimiento
                            Cadena = "SELECT " & Campo & " AS 'CODIGO',cod_comp AS COMP,NOMBRE FROM " & Tabla
                            dtTemporal = sqlExecute("SELECT COL_LENGTH('" & Tabla & "','cod_comp') AS campo")
                            If dtTemporal.Rows.Count = 0 Then
                                Cadena = "SELECT " & Campo & " AS 'CODIGO','' AS COMP,NOMBRE FROM " & Tabla
                                cmbValorNuevo.Columns("ColCiaValor").Visible = False
                            Else
                                If IsDBNull(dtTemporal.Rows(0).Item("campo")) Then
                                    Cadena = "SELECT " & Campo & " AS 'CODIGO','' AS COMP,NOMBRE FROM " & Tabla
                                    cmbValorNuevo.Columns("ColCiaValor").Visible = False
                                Else
                                    'MCR 19/NOV/2015
                                    'Si la tabla contiene el campo de compañía, permitir solo las compañías editables (SUCCESS FACTOR BRP)
                                    Cadena = "SELECT " & Tabla & "." & Campo & " AS 'CODIGO'," & Tabla & ".cod_comp AS COMP," & _
                                        Tabla & ".NOMBRE FROM " & Tabla & " left join cias on " & Tabla & ".cod_comp = cias.cod_comp " & _
                                        "where cias.editable = 1"
                                End If
                            End If
                        End If
                    End If
                End If
                'Obtener los registros de la tabla seleccionada, y mostrar en el combo
                dtValores = New DataTable
                dtValores = sqlExecute(Cadena)
                cmbValorNuevo.DataSource = dtValores
                cmbValorNuevo.Focus()
            End If
        Catch ex As Exception
            'Si hubo un error, considerar como texto
            txtValorNuevo.Visible = True
            cmbValorNuevo.Visible = False

            txtValorNuevo.Text = ""
            txtValorNuevo.Focus()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbCampo_TextChanged(sender As Object, e As EventArgs) Handles cmbCampo.TextChanged

    End Sub

    Private Sub gpTransferencias_Click(sender As Object, e As EventArgs) Handles gpTransferencias.Click

    End Sub

    Private Sub btnAntiguedad_ValueChanged(sender As Object, e As EventArgs) Handles btnAntiguedad.ValueChanged
        lblAltaTrans.Text = IIf(btnAntiguedad.Value, "Fecha de alta IMSS", "Fecha de alta")
        lblBajaTrans.Text = IIf(btnAntiguedad.Value, "Fecha de baja IMSS", "Fecha de baja")
    End Sub

    Private Sub cmbBajaInterno_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBajaInterno.SelectedValueChanged
        If cmbBajaInterno.SelectedValue Is Nothing Then Exit Sub
        cmbSubBaja.DataSource = sqlExecute("SELECT cod_sub_ba AS 'CÓDIGO',MOTIVO FROM cod_sub_baj WHERE cod_mot_ba = '" & cmbBajaInterno.SelectedValue & "'")
    End Sub

    Private Sub cmbBajaInterno_TextChanged(sender As Object, e As EventArgs) Handles cmbBajaInterno.TextChanged

    End Sub

    Private Sub cmbBajaInternoTrans_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBajaInternoTrans.SelectedValueChanged
        If cmbBajaInternoTrans.SelectedValue Is Nothing Then Exit Sub
        cmbSubTransferencia.DataSource = sqlExecute("SELECT cod_sub_ba AS 'CÓDIGO',MOTIVO FROM cod_sub_baj WHERE cod_mot_ba = '" & cmbBajaInternoTrans.SelectedValue & "'")

    End Sub

    Private Sub ActualizaSueldo()
        Try
            Dim dtSdo As New DataTable
            Dim dtTemp As New DataTable
            Dim sdo As Double
            'Dim Factor As Double
            'Dim Integrado As Double

            If cmbNivel.SelectedValue Is Nothing Then
                sdo = 0
            Else
                dtSdo = sqlExecute("SELECT sueldo FROM niveles WHERE cod_comp = '" & cmbValorNuevo.SelectedValue & "' AND nivel = '" & cmbNivel.SelectedValue & "'")
                If dtSdo.Rows.Count > 0 Then
                    sdo = IIf(IsDBNull(dtSdo.Rows.Item(0).Item("sueldo")), 0, dtSdo.Rows.Item(0).Item("sueldo"))
                Else
                    sdo = 0
                End If
            End If
            'If sdo <> 0 Then
            txtSActual.Text = FormatCurrency(sdo)
            'End If

            txtSActual.Enabled = (sdo = 0) And Not btnSueldo.Value
            'Factor = Format(FactorIntegracion(cmbCia.SelectedValue, cmbTipo.SelectedValue, DateDiff(DateInterval.Year, txtAlta.Value, UltimoDiaBimestre(Today))), "0.0000")
            'Integrado = (txtSActual.Text * Factor) + txtProVar.Text

            'txtFactorInt.Text = Factor
            'txtIntegrado.Text = FormatCurrency(Integrado)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            txtSActual.Text = FormatCurrency(0)
            txtSActual.Enabled = False
            'txtFactorInt.Text = Format(0, "0.0000")
            'txtIntegrado.Text = FormatCurrency(0)
        End Try
    End Sub

    Private Sub cmbNivel_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNivel.SelectedValueChanged
        ActualizaSueldo()
    End Sub


    Private Sub cmbNivel_Validated(sender As Object, e As EventArgs) Handles cmbNivel.Validated
        ActualizaSueldo()
    End Sub

    Private Sub txtSActual_TextChanged(sender As Object, e As EventArgs) Handles txtSActual.TextChanged

    End Sub

    Private Sub txtSActual_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSActual.Validating
        Try
            txtSActual.Text = FormatCurrency(txtSActual.Text)
        Catch
            MessageBox.Show("El sueldo no es válido. Favor de verificar.", "Sueldo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSActual.Focus()
        End Try
    End Sub

    Private Sub btnSueldo_ValueChanged(sender As Object, e As EventArgs) Handles btnSueldo.ValueChanged
        cmbNivel.Enabled = Not btnSueldo.Value
        txtSActual.Enabled = Not btnSueldo.Value
        lblNivel.Enabled = Not btnSueldo.Value
        lblSueldo.Enabled = Not btnSueldo.Value
    End Sub

    Private Sub cmbNivel_TextChanged(sender As Object, e As EventArgs) Handles cmbNivel.TextChanged

    End Sub
End Class
