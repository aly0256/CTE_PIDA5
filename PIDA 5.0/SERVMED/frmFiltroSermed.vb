Public Class frmFiltroSermed

    Dim dtCampos As New DataTable
    Dim dtIncluyendo As New DataTable
    Dim dtExcepto As New DataTable
    Dim ctrlFocus As Object

    Dim Acumulado As String
    Dim Iniciando As Boolean = True

    Private Function FiltrosAcumulados() As String
        Dim FL As String = ""
        Dim i As Integer
        Try
            lstFiltros.Items.Clear()
            For i = 0 To NFiltros - 1
                FL = FL & IIf(i > 0, " AND (", "(") & Filtros(2, i) & ")"
                lstFiltros.Items.Add(Filtros(2, i))
            Next
        Catch ex As Exception
            FL = "ERROR"
        End Try

        Return FL
    End Function
    Private Sub frmFiltro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Acumulado = FiltrosAcumulados()
            dgLista.AutoGenerateColumns = False

            pnlFechas.Parent = pnlCaracter.Parent
            pnlNumerico.Parent = pnlCaracter.Parent

            pnlFechas.Location = pnlCaracter.Location
            pnlNumerico.Location = pnlCaracter.Location

            pnlFechas.Size = pnlCaracter.Size
            pnlNumerico.Size = pnlCaracter.Size

            dtCampos = sqlExecute("SELECT UPPER(nombre) AS 'NOMBRE',UPPER(cod_campo) as 'COD_CAMPO',tipo, isnull(tabla, 'consultasvw') as tabla FROM campos ORDER BY cod_campo", "sermed")

            '"SELECT UPPER(nombre) AS 'NOMBRE',UPPER(cod_campo) as 'COD_CAMPO',tipo, FROM campos ORDER BY nombre"
            'Dim dtAuxiliares As New DataTable
            'dtAuxiliares = sqlExecute("SELECT campo,nombre,'char' AS tipo FROM auxiliares ORDER BY campo")

            ''Agregar columnas para auxiliares
            'For x = 0 To dtAuxiliares.Rows.Count - 1
            '    dtCampos.Rows.Add({dtAuxiliares.Rows(x).Item("nombre").ToString.Trim.ToUpper, dtAuxiliares.Rows(x).Item("campo").ToString.Trim.ToUpper, "aux", "AUXILIARES"})
            'Next
            dtCampos.DefaultView.Sort = "nombre"
            cbCampos.DataSource = dtCampos
            'cbCampos.DisplayMembers = "nombre,cod_campo,tipo"
            'ConsultaPersonalVW("SELECT reloj + '     ' + nombres AS reloj FROM personalVW " & IIf(Acumulado.Length > 0, " WHERE " & Acumulado, ""), dtResultado, False)

            ListarResultado(Acumulado)
            cbCampos.KeyboardSearchEnabled = True
            cbCampos.KeyboardSearchNoSelectionAllowed = False
            cbCampos.SelectedIndex = -1
            cbCampos.Focus()
            Iniciando = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkIncluyendo_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluyendo.CheckedChanged
        Try
            txtIncluyendo.Enabled = chkIncluyendo.Checked
            lstIncluyendo.Enabled = chkIncluyendo.Checked

            txtExcepto.Enabled = chkExcepto.Checked
            lstExcepto.Enabled = chkExcepto.Checked
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkExcepto_CheckedChanged(sender As Object, e As EventArgs) Handles chkExcepto.CheckedChanged
        Try
            txtIncluyendo.Enabled = chkIncluyendo.Checked
            lstIncluyendo.Enabled = chkIncluyendo.Checked

            txtExcepto.Enabled = chkExcepto.Checked
            lstExcepto.Enabled = chkExcepto.Checked
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkBlanco_CheckedChanged(sender As Object, e As EventArgs) Handles chkBlanco.CheckedChanged
        Try
            txtIncluyendo.Enabled = chkIncluyendo.Checked
            lstIncluyendo.Enabled = chkIncluyendo.Checked

            txtExcepto.Enabled = chkExcepto.Checked
            lstExcepto.Enabled = chkExcepto.Checked

            FiltrarDatos("", True)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkNoBlanco_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoBlanco.CheckedChanged
        Try
            txtIncluyendo.Enabled = chkIncluyendo.Checked
            lstIncluyendo.Enabled = chkIncluyendo.Checked

            txtExcepto.Enabled = chkExcepto.Checked
            lstExcepto.Enabled = chkExcepto.Checked

            FiltrarDatos("", False)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtIncluyendo_TextChanged(sender As Object, e As EventArgs) Handles txtIncluyendo.TextChanged
        Dim Resultado As New DataTable
        Try
            Dim Tipo As String = cbCampos.SelectedNode.Cells(2).Text.Trim
            If Tipo = "aux" Then
                dtIncluyendo = FiltrarAuxiliares(txtIncluyendo.Text.Trim, False)
            Else
                dtIncluyendo = FiltrarDatos(txtIncluyendo.Text.Trim, False)
            End If

            lstIncluyendo.DataSource = dtIncluyendo
            If dtIncluyendo.Columns.Count > 0 Then
                lstIncluyendo.DisplayMember = dtIncluyendo.Columns(0).ColumnName
            End If

            Dim x As Integer
            For x = 0 To lstIncluyendo.Items.Count - 1
                lstIncluyendo.SetItemChecked(x, chkTodosIncluyendo.Checked)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Function FiltrarDatos(Texto As String, Excepcion As Boolean) As DataTable
        Dim dtValores As New DataTable
        Dim Campo As String
        Try
            If cbCampos.SelectedIndex >= 0 Then
                Campo = cbCampos.SelectedValue.ToString.Trim
            Else
                Campo = ""
            End If
            dtValores = ConsultaPersonalVW("SELECT DISTINCT TOP 100 " & Campo & "  FROM personalVW WHERE " & FiltraValor(Campo, Texto, Excepcion), False)
            Return dtValores
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return New DataTable
        End Try
    End Function

    Private Function FiltrarAuxiliares(Texto As String, Excepcion As Boolean) As DataTable
        Dim Valores() As String
        Valores = Split(Texto, ";")
        Dim Valor As String = ""
        Dim dtValores As New DataTable
        Dim Campo As String
        Try
            If cbCampos.SelectedIndex >= 0 Then
                Campo = cbCampos.SelectedValue.ToString.Trim
            Else
                Campo = ""
            End If

            If UBound(Valores) = 0 And Valores(0) = "" Then
                Valor = "contenido <> '' AND NOT contenido IS NULL"
            Else
                For x = 0 To UBound(Valores)
                    If Valores(x).Length = 0 Then
                        'Si el valor está en blanco, utilizar una cadena siempre verdadera para no obstruir la consulta
                        Valores(x) = "1=1"
                    ElseIf Not Valores(x).Contains("*") Then
                        'Si no se incluye el asterisco, agregarlo al final
                        Valores(x) = Valores(x) & "*"
                    End If
                    'Formar la cadena con los valores a filtrar
                    Valor = Valor & " contenido LIKE ('" & Valores(x).Replace("*", "%") & "')"

                    If x < UBound(Valores) Then
                        'Si no es el último elemento del arreglo, agregar el OR
                        Valor = Valor & " OR "
                    End If
                Next
            End If
            'End If

            If Excepcion Then
                Valor = "NOT (" & Valor & ")"
            End If

            dtValores = sqlExecute("SELECT DISTINCT contenido FROM DETALLE_AUXILIARES WHERE CAMPO = '" & Campo & "' AND " & Valor)
            Return dtValores
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return New DataTable
        End Try

    End Function

    Private Function FiltraValor(Campo As String, Texto As String, Excepcion As Boolean) As String
        Try
            Dim x As Integer
            Dim Valores() As String
            Valores = Split(Texto, ";")
            Dim Valor As String = ""

            If UBound(Valores) = 0 And Valores(0) = "" Then
                Valor = Campo & " <> '' AND NOT " & Campo & " IS NULL"
            Else
                For x = 0 To UBound(Valores)
                    If Valores(x).Length = 0 Then
                        'Si el valor está en blanco, utilizar una cadena siempre verdadera para no obstruir la consulta
                        Valores(x) = "1=1"
                    ElseIf Not Valores(x).Contains("*") Then
                        'Si no se incluye el asterisco, agregarlo al final
                        Valores(x) = Valores(x) & "*"
                    End If
                    'Formar la cadena con los valores a filtrar
                    Valor = Valor & Campo & " LIKE ('" & Valores(x).Replace("*", "%") & "')"

                    If x < UBound(Valores) Then
                        'Si no es el último elemento del arreglo, agregar el OR
                        Valor = Valor & " OR "
                    End If
                Next
            End If
            'End If

            If Excepcion Then
                Valor = "NOT (" & Valor & ")"
            End If
            Return Valor
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return "ERROR"
        End Try
    End Function
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim Campo As String = ""
        Dim valor As String
        Dim Tipo As String = ""
        Dim x As Integer
        Dim chk As Integer = 0
        Dim msg As System.Windows.Forms.DialogResult = Windows.Forms.DialogResult.Yes


        Try
            If cbCampos.SelectedIndex >= 0 Then
                Campo = cbCampos.SelectedValue.ToString.Trim
                Tipo = cbCampos.SelectedNode.Cells(2).Text.Trim
            Else
                Exit Sub
            End If
            'Actualiza lista de filtros
            Dim I As Integer = -1
            For x = 0 To NFiltros - 1
                If Filtros(1, x) = campo Then
                    I = x
                    Exit For
                End If
            Next

            If I = -1 Then
                I = NFiltros
                NFiltros = NFiltros + 1

                If UBound(Filtros, 2) < NFiltros Then
                    ReDim Preserve Filtros(2, NFiltros)
                End If
            End If

            Campo = campo
            valor = ""
            Select Case Tipo
                Case "date"

                    If chkIncluyeFecha.Checked Then
                        valor = Campo & " >= '" & FechaSQL(txtFecha1.Text) & "' AND " & Campo & " <= '" & FechaSQL(txtFecha2.Text) & "'"
                    ElseIf chkExceptoFecha.Checked Then
                        valor = " NOT (Campo " & " >= '" & FechaSQL(txtFecha1.Text) & "' AND " & Campo & " <= '" & FechaSQL(txtFecha2.Text) & "')"
                    ElseIf chkBlanco.Checked Then
                        valor = "(" & Campo & " IS NULL)"
                    ElseIf chkNoBlanco.Checked Then
                        valor = "(NOT " & Campo & " IS NULL)"
                    End If
                Case "num"
                    If chkIncluyendoNum.Checked Then
                        valor = Campo & " >=" & txtNum1.Text & " AND " & Campo & "<=" & txtNum2.Text & "'"
                    ElseIf chkExceptoNum.Checked Then
                        valor = Campo & " <" & txtExceptoNum1.Text & " AND " & Campo & ">" & txtExceptoNum2.Text & "'"
                    ElseIf chkBlanco.Checked Then
                        valor = "(" & Campo & " = 0 OR " & Campo & " IS NULL)"
                    ElseIf chkNoBlanco.Checked Then
                        valor = "(" & Campo & " <> 0 AND NOT " & Campo & " IS NULL)"
                    End If
                Case "char", "aux"
                    'If chkIncluyendo.Checked Then
                    '    valor = FiltraValor(Campo, txtIncluyendo.Text, False)
                    'ElseIf chkExcepto.Checked Then
                    '    valor = FiltraValor(Campo, txtExcepto.Text, True)
                    'ElseIf chkBlanco.Checked Then
                    '    valor = "(" & Campo & " = '' OR " & Campo & " IS NULL)"
                    'ElseIf chkNoBlanco.Checked Then
                    '    valor = "(" & Campo & " <> '' AND NOT " & Campo & " IS NULL)"
                    'End If

                    If chkIncluyendo.Checked Then
                        chk = lstIncluyendo.CheckedItems.Count
                        If chk = 0 Then
                            msg = MessageBox.Show("No seleccionó ninguna de las opciones para el filtro por <<" & Campo & ">>,  ¿Desea que se seleccione la lista completa?", "Filtros", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                            If msg = Windows.Forms.DialogResult.Yes Then
                                valor = FiltraValor(Campo, txtIncluyendo.Text, False)
                            ElseIf msg = Windows.Forms.DialogResult.No Then
                                Exit Sub
                            End If
                        Else
                            For x = 0 To chk - 1
                                valor = valor & IIf(valor.Length > 0, ",", "") & "'" & lstIncluyendo.CheckedItems(x).Item(0) & "'"
                            Next
                            valor = Campo & " IN (" & valor & ")"
                        End If

                    ElseIf chkExcepto.Checked Then

                        chk = lstExcepto.CheckedItems.Count
                        If chk = 0 Then
                            msg = MessageBox.Show("No seleccionó ninguna de las excepciones para el filtro por <<" & Campo & ">>,  ¿Desea que se seleccione la lista completa?", "Filtros", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                            If msg = Windows.Forms.DialogResult.Yes Then
                                valor = FiltraValor(Campo, txtExcepto.Text, True)
                            ElseIf msg = Windows.Forms.DialogResult.No Then
                                Exit Sub
                            End If
                        Else
                            For x = 0 To lstExcepto.CheckedItems.Count - 1
                                valor = valor & IIf(valor.Length > 0, ",", "") & "'" & lstExcepto.CheckedItems(x).Item(0) & "'"
                            Next
                            valor = Campo & " NOT IN (" & valor & ")"
                        End If
                    ElseIf chkBlanco.Checked Then
                        valor = "(" & Campo & " = '' OR " & Campo & " IS NULL)"
                    ElseIf chkNoBlanco.Checked Then
                        valor = "(" & Campo & " <> '' AND NOT " & Campo & " IS NULL)"
                    End If
            End Select
            valor = valor.Replace("()", "('*')")
            Filtros(1, I) = Campo
            Filtros(2, I) = valor

            valor = ""
            lstFiltros.Items.Clear()
            For x = 0 To NFiltros - 1
                lstFiltros.Items.Add(Filtros(2, x))
                valor = valor & IIf(valor.Length = 0, "", " AND ") & Filtros(2, x)
            Next

            'Crear un dataset para pasar el resultado del filtro
            ListarResultado(valor)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub ListarResultado(valor As String)
        Dim dtResultadoPersonal As New DataTable
        Try
            If valor.Length > 0 Then
                dtResultadoPersonal = dtResultado.Clone
                For Each dRow In dtResultado.Select(valor)
                    dtResultadoPersonal.ImportRow(dRow)
                Next
            Else
                dtResultadoPersonal = dtResultado.Copy
            End If

            dgLista.DataSource = dtResultadoPersonal
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
        lblRegistros.Text = dgLista.Rows.Count & " registros"
    End Sub
    Private Sub lstFiltros_KeyUp(sender As Object, e As KeyEventArgs) Handles lstFiltros.KeyUp
        Dim FiltraValor As String
        Dim i As Integer
        Dim x As Integer
        Try
            If e.KeyValue = Keys.Delete Then
                i = lstFiltros.SelectedIndex

                If i < 0 Then Exit Sub
                lstFiltros.Items.RemoveAt(i)

                For x = i To NFiltros - 1
                    Filtros(1, x) = Filtros(1, x + 1)
                    Filtros(2, x) = Filtros(2, x + 1)
                Next
                NFiltros = NFiltros - 1
                ReDim Preserve Filtros(2, x)

                FiltraValor = ""
                lstFiltros.Items.Clear()
                For x = 0 To NFiltros - 1
                    lstFiltros.Items.Add(Filtros(2, x))
                    FiltraValor = FiltraValor & IIf(FiltraValor.Length = 0, "", " AND ") & Filtros(2, x)
                Next
                ListarResultado(FiltraValor)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtExcepto_TextChanged(sender As Object, e As EventArgs) Handles txtExcepto.TextChanged
        Dim x As Integer
        Dim Resultado As New DataTable
        Try
            Dim Tipo As String = cbCampos.SelectedNode.Cells(2).Text.Trim
            If Tipo = "aux" Then
                dtIncluyendo = FiltrarAuxiliares(txtIncluyendo.Text.Trim, False)
            Else
                dtIncluyendo = FiltrarDatos(txtIncluyendo.Text.Trim, False)
            End If

            lstExcepto.DataSource = dtIncluyendo
            If dtIncluyendo.Columns.Count > 0 Then
                lstExcepto.DisplayMember = dtIncluyendo.Columns(0).ColumnName
            End If

            For x = 0 To lstIncluyendo.Items.Count - 1
                lstExcepto.SetItemChecked(x, chkTodosIncluyendo.Checked)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try
            NFiltros = 0
            lstFiltros.Items.Clear()
            'dtIncluyendo = New DataTable
            txtIncluyendo.Text = ""
            txtExcepto.Text = ""
            ListarResultado("")
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkIncluyeFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluyeFecha.CheckedChanged
        Try
            txtFecha1.Enabled = chkIncluyeFecha.Checked
            txtFecha2.Enabled = chkIncluyeFecha.Checked

            txtFecha1.Focus()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkExceptoFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkExceptoFecha.CheckedChanged
        Try
            txtExceptoFecha1.Enabled = chkExceptoFecha.Checked
            txtExceptoFecha2.Enabled = chkExceptoFecha.Checked

            txtExceptoFecha1.Focus()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub chkIncluyendoNum_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluyendoNum.CheckedChanged
        Try
            txtNum1.Enabled = chkIncluyendoNum.Checked
            txtNum2.Enabled = chkIncluyendoNum.Checked

            txtNum1.Focus()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkExceptoNum_CheckedChanged(sender As Object, e As EventArgs) Handles chkExceptoNum.CheckedChanged
        Try
            txtExceptoNum1.Enabled = chkExceptoNum.Checked
            txtExceptoNum2.Enabled = chkExceptoNum.Checked

            txtExceptoNum1.Focus()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cbCampos_PopupClose(sender As Object, e As EventArgs) Handles cbCampos.PopupClose
        Try
            ActualizarCampos()
            Application.DoEvents()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ActualizarCampos()
        Dim x As Integer
        Dim y As Integer
        Dim c As String
        Dim Campo As String
        Dim Tipo As String
        Dim Tabla As String

        Try
            dtIncluyendo = New DataTable
            If cbCampos.SelectedIndex >= 0 And Not Iniciando Then
                Campo = cbCampos.SelectedValue.ToString.Trim
            Else
                Exit Sub
            End If

            Tipo = cbCampos.SelectedNode.Cells(2).Text.Trim
            Tabla = cbCampos.SelectedNode.Cells(3).Text.Trim

            pnlCaracter.Visible = Tipo = "char" Or Tipo = "aux"
            pnlFechas.Visible = Tipo = "date"
            pnlNumerico.Visible = Tipo = "num"

            Select Case Tipo
                Case "date"
                    'Si el campo es de tipo fecha
                    chkBlanco.Parent = txtFecha1.Parent
                    chkNoBlanco.Parent = txtFecha1.Parent

                    dtIncluyendo = sqlExecute("SELECT MIN(" & Campo & ") AS minimo, MAX(" & Campo & ") AS maximo FROM " & Tabla)
                    txtFecha1.Value = dtIncluyendo.Rows.Item(0).Item("minimo")
                    txtExceptoFecha1.Value = dtIncluyendo.Rows.Item(0).Item("minimo")

                    txtFecha2.Value = dtIncluyendo.Rows.Item(0).Item("maximo")
                    txtExceptoFecha2.Value = dtIncluyendo.Rows.Item(0).Item("maximo")
                Case "num"
                    'Si el campo es de tipo numérico
                    chkBlanco.Parent = txtNum1.Parent
                    chkNoBlanco.Parent = txtNum1.Parent
                    chkBlanco.BringToFront()

                    'DirectCast(sender, chkblanco).parent = pnlNumerico

                    txtNum1.Value = 0
                    txtExceptoNum1.Value = 0

                    txtNum2.Value = 0
                    txtExceptoNum2.Value = 0

                Case "char"
                    'Si el campo es de tipo caracter
                    chkBlanco.Parent = lstIncluyendo.Parent
                    chkNoBlanco.Parent = lstIncluyendo.Parent

                    dtIncluyendo = sqlExecute("SELECT DISTINCT TOP 100 " & Campo & "  FROM " & Tabla & " WHERE " & Campo & " <> ''  AND NOT " & Campo & " IS NULL", "sermed")

                    lstIncluyendo.DataSource = dtIncluyendo
                    lstIncluyendo.DisplayMember = Campo
                    lstExcepto.DataSource = dtIncluyendo
                    lstExcepto.DisplayMember = Campo
                    x = lstFiltros.FindString(Campo)
                    If x > -1 Then
                        c = Filtros(2, x)
                        Dim cAr() = c.Split("'")
                        If c.Contains("IS NULL") Then
                            chkBlanco.Checked = True
                        ElseIf c.Contains("NOT IS NULL") Then
                            chkNoBlanco.Checked = True
                        ElseIf c.Contains("NOT IN") Then
                            For y = 1 To UBound(cAr) Step 2
                                x = lstExcepto.FindString(cAr(y))
                                If x >= 0 Then
                                    lstExcepto.SetItemChecked(x, True)
                                End If
                            Next
                            chkExcepto.Checked = True
                        Else

                            For y = 1 To UBound(cAr) Step 2
                                x = lstIncluyendo.FindString(cAr(y))
                                If x >= 0 Then
                                    lstIncluyendo.SetItemChecked(x, True)
                                End If
                            Next
                            chkIncluyendo.Checked = True
                        End If
                    Else
                        For x = 0 To lstIncluyendo.Items.Count - 1
                            lstIncluyendo.SetItemChecked(x, chkTodosIncluyendo.Checked)
                            lstExcepto.SetItemChecked(x, chkTodosExcepto.Checked)
                        Next
                    End If
                    chkIncluyendo.Checked = True
                    txtIncluyendo.Text = ""
                    txtExcepto.Text = ""
                    'txtIncluyendo.Focus()
                    'ctrlFocus = txtIncluyendo

                Case "aux"
                    'Si el campo es un auxiliar
                    chkBlanco.Parent = lstIncluyendo.Parent
                    chkNoBlanco.Parent = lstIncluyendo.Parent

                    dtIncluyendo = sqlExecute("SELECT DISTINCT contenido FROM DETALLE_AUXILIARES WHERE CAMPO = '" & Campo & "' AND NOT contenido IS NULL")

                    lstIncluyendo.DataSource = dtIncluyendo
                    lstIncluyendo.DisplayMember = "contenido"
                    lstExcepto.DataSource = dtIncluyendo
                    lstExcepto.DisplayMember = "contenido"

                    x = lstFiltros.FindString(Campo)
                    If x > -1 Then
                        c = Filtros(2, x)
                        Dim cAr() = c.Split("'")
                        If c.Contains("IS NULL") Then
                            chkBlanco.Checked = True
                        ElseIf c.Contains("NOT IS NULL") Then
                            chkNoBlanco.Checked = True
                        ElseIf c.Contains("NOT IN") Then
                            For y = 1 To UBound(cAr) Step 2
                                x = lstExcepto.FindString(cAr(y))
                                If x >= 0 Then
                                    lstExcepto.SetItemChecked(x, True)
                                End If
                            Next
                            chkExcepto.Checked = True
                        Else

                            For y = 1 To UBound(cAr) Step 2
                                x = lstIncluyendo.FindString(cAr(y))
                                If x >= 0 Then
                                    lstIncluyendo.SetItemChecked(x, True)
                                End If
                            Next
                            chkIncluyendo.Checked = True
                        End If
                    Else
                        For x = 0 To lstIncluyendo.Items.Count - 1
                            lstIncluyendo.SetItemChecked(x, chkTodosIncluyendo.Checked)
                            lstExcepto.SetItemChecked(x, chkTodosExcepto.Checked)
                        Next
                    End If
                    chkIncluyendo.Checked = True
                    txtIncluyendo.Text = ""
                    txtExcepto.Text = ""
                    'txtIncluyendo.Focus()
                    'ctrlFocus = txtIncluyendo
            End Select

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub
    Private Sub chkTodosIncluyendo_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosIncluyendo.CheckedChanged
        Try
            Dim x As Integer
            For x = 0 To lstIncluyendo.Items.Count - 1
                lstIncluyendo.SetItemChecked(x, chkTodosIncluyendo.Checked)
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkTodosExcepto_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosExcepto.CheckedChanged
        Try
            Dim x As Integer
            For x = 0 To lstExcepto.Items.Count - 1
                lstExcepto.SetItemChecked(x, chkTodosExcepto.Checked)
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cbCampos_Validated(sender As Object, e As EventArgs) Handles cbCampos.Validated
        txtIncluyendo.Focus()
    End Sub

    Private Sub lstIncluyendo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstIncluyendo.SelectedIndexChanged

    End Sub

End Class