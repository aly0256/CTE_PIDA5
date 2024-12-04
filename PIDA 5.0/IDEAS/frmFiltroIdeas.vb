Public Class frmFiltroIdeas
    Dim dtCampos As New DataTable
    Dim dtIncluyendo As New DataTable
    Dim dtExcepto As New DataTable

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
        On Error Resume Next
        Acumulado = FiltrosAcumulados()

        pnlFechas.Parent = pnlCaracter.Parent
        pnlNumerico.Parent = pnlCaracter.Parent
        pnlinchr.Parent = pnlCaracter.Parent
        pnlLogico.Parent = pnlCaracter.Parent

        pnlFechas.Location = pnlCaracter.Location
        pnlNumerico.Location = pnlCaracter.Location
        pnlinchr.Location = pnlCaracter.Location

        pnlLogico.Location = pnlCaracter.Location

        pnlFechas.Size = pnlCaracter.Size
        pnlNumerico.Size = pnlCaracter.Size
        pnlinchr.Size = pnlCaracter.Size

        pnlLogico.Size = pnlCaracter.Size

        dtCampos = sqlExecute("SELECT RTRIM(UPPER(nombre)) AS 'NOMBRE',UPPER(cod_campo) as 'COD_CAMPO',tipo,ISNULL(tabla,'ideasVW') as tabla," & _
                              "ISNULL(campo_en_tabla,cod_campo) as campo_en_tabla FROM campos ", "IDEAS")
        dtCampos.DefaultView.Sort = "nombre"
        cbCampos.DataSource = dtCampos
        dgLista.AutoGenerateColumns = False
        ListarResultado(Acumulado)

        cbCampos.SelectedIndex = -1
        cbCampos.Focus()
        Iniciando = False
    End Sub

    Private Sub cbCampos_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cbCampos.SelectionChanged
        Dim x As Integer
        Dim y As Integer
        Dim c As String
        Dim Campo As String
        Dim Tipo As String
        Dim Tabla As String
        Dim CampoTabla As String

        Try

            dtIncluyendo = New DataTable
            If cbCampos.SelectedIndex >= 0 And Not Iniciando Then
                Campo = cbCampos.SelectedValue.ToString.Trim
            Else
                Exit Sub
            End If

            Tipo = cbCampos.SelectedNode.Cells(2).Text.Trim.ToLower
            Tabla = cbCampos.SelectedNode.Cells(3).Text.Trim
            CampoTabla = cbCampos.SelectedNode.Cells(4).Text.Trim

            pnlCaracter.Visible = Tipo = "char" Or Tipo = "aux"
            pnlFechas.Visible = Tipo = "date"
            pnlNumerico.Visible = Tipo = "num"
            pnlLogico.Visible = Tipo = "logical"
            pnlinchr.Visible = Tipo = "inchr"

            Select Case Tipo
                Case "date"
                    'Si el campo es de tipo fecha
                    chkBlanco.Parent = txtFecha1.Parent
                    chkNoBlanco.Parent = txtFecha1.Parent

                    txtFecha1.Value = RangoFInicial
                    txtExceptoFecha1.Value = RangoFInicial

                    txtFecha2.Value = RangoFFinal
                    txtExceptoFecha2.Value = RangoFFinal
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

                    dtIncluyendo = sqlExecute("SELECT DISTINCT " & CampoTabla & "  FROM " & Tabla & " WHERE " & CampoTabla & " <> ''  AND NOT " & CampoTabla & " IS NULL", "IDEAS")

                    lstIncluyendo.DataSource = dtIncluyendo
                    lstIncluyendo.DisplayMember = CampoTabla
                    lstExcepto.DataSource = dtIncluyendo
                    lstExcepto.DisplayMember = CampoTabla
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
                    txtIncluyendo.Focus()
                Case "inchr"
                    'Si el campo es de tipo caracter
                    chkBlanco.Parent = lstIncluyendo.Parent
                    chkNoBlanco.Parent = lstIncluyendo.Parent

                    dtIncluyendo = sqlExecute("SELECT DISTINCT TOP 1000 " & CampoTabla & "  FROM " & Tabla & " WHERE " & CampoTabla & " <> ''  AND NOT " & CampoTabla & " IS NULL", "IDEAS")

                    lstContenga.DataSource = dtIncluyendo
                    lstContenga.DisplayMember = CampoTabla

                    x = lstFiltros.FindString(Campo)
                    If x > -1 Then
                        c = Filtros(2, x)
                        Dim cAr() = c.Split("'")
                        If c.Contains("IS NULL") Then
                            chkBlanco.Checked = True
                        ElseIf c.Contains("NOT IS NULL") Then
                            chkNoBlanco.Checked = True
                        Else

                            For y = 1 To UBound(cAr) Step 2
                                x = lstContenga.FindString(cAr(y))
                                If x >= 0 Then
                                    lstContenga.SetItemChecked(x, True)
                                End If
                            Next
                            chkContenga.Checked = True
                        End If
                    Else
                        For x = 0 To lstContenga.Items.Count - 1
                            lstContenga.SetItemChecked(x, chkTodosContenga.Checked)
                        Next
                    End If
                    chkContenga.Checked = True
                    txtIncluyendo.Text = ""
                    txtIncluyendo.Focus()
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
                    txtIncluyendo.Focus()
            End Select

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkIncluyendo_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluyendo.CheckedChanged
        txtIncluyendo.Enabled = chkIncluyendo.Checked
        lstIncluyendo.Enabled = chkIncluyendo.Checked

        txtExcepto.Enabled = chkExcepto.Checked
        lstExcepto.Enabled = chkExcepto.Checked
    End Sub

    Private Sub chkExcepto_CheckedChanged(sender As Object, e As EventArgs) Handles chkExcepto.CheckedChanged
        txtIncluyendo.Enabled = chkIncluyendo.Checked
        lstIncluyendo.Enabled = chkIncluyendo.Checked

        txtExcepto.Enabled = chkExcepto.Checked
        lstExcepto.Enabled = chkExcepto.Checked

    End Sub

    Private Sub chkBlanco_CheckedChanged(sender As Object, e As EventArgs) Handles chkBlanco.CheckedChanged
        txtIncluyendo.Enabled = chkIncluyendo.Checked
        lstIncluyendo.Enabled = chkIncluyendo.Checked

        txtExcepto.Enabled = chkExcepto.Checked
        lstExcepto.Enabled = chkExcepto.Checked

        FiltrarDatos("", True)
    End Sub

    Private Sub chkNoBlanco_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoBlanco.CheckedChanged
        txtIncluyendo.Enabled = chkIncluyendo.Checked
        lstIncluyendo.Enabled = chkIncluyendo.Checked

        txtExcepto.Enabled = chkExcepto.Checked
        lstExcepto.Enabled = chkExcepto.Checked

        FiltrarDatos("", False)
    End Sub

    Private Sub txtIncluyendo_TextChanged(sender As Object, e As EventArgs) Handles txtIncluyendo.TextChanged
        Dim Resultado As New DataTable
        Try
            Dim Tipo As String = cbCampos.SelectedNode.Cells(2).Text.Trim
            If Tipo = "aux" Then

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
        Dim CampoTabla As String
        Dim Tabla As String
        If cbCampos.SelectedIndex >= 0 Then
            Campo = cbCampos.SelectedValue.ToString.Trim
            CampoTabla = cbCampos.SelectedNode.Cells(4).Text.Trim
            Tabla = cbCampos.SelectedNode.Cells(3).Text.Trim
        Else
            Return New DataTable
        End If
        dtValores = sqlExecute("SELECT DISTINCT " & CampoTabla & "  FROM " & Tabla & " WHERE " & CampoTabla & " LIKE '%" & Texto & "%'", "IDEAS")
        Return dtValores
    End Function

    Private Function FiltraValor(Campo As String, Texto As String, Excepcion As Boolean) As String
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
                    'Si no se incluye el asterisco, agregarlo al principio y al final
                    Valores(x) = "*" & Valores(x) & "*"
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
                Tipo = cbCampos.SelectedNode.Cells(2).Text.Trim.ToLower
            Else
                Exit Sub
            End If

            If Tipo = "time" Then Campo = Campo & "_FH"

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
                        valor = Campo & " >= '" & FechaSQL(txtFecha1.Text) & "' AND " & Campo & "<='" & FechaSQL(txtFecha2.Text) & "'"
                    ElseIf chkExceptoFecha.Checked Then
                        valor = "NOT (" & Campo & " >= '" & FechaSQL(txtExceptoFecha1.Text) & "' AND " & Campo & "<='" & FechaSQL(txtExceptoFecha2.Text) & "')"
                    ElseIf chkBlanco.Checked Then
                        valor = "(" & Campo & " = '' OR " & Campo & " IS NULL)"
                    ElseIf chkNoBlanco.Checked Then
                        valor = "(" & Campo & " <> '' AND NOT " & Campo & " IS NULL)"
                    End If

                Case "logical"
                    If chkLogico.Checked Then
                        valor = "(" & Campo & " IS NULL)"
                    ElseIf chkNoBlanco.Checked Then
                        valor = "(" & "NOT " & Campo & " IS NULL)"
                    End If
                Case "num"
                    If chkIncluyendoNum.Checked Then
                        valor = Campo & " >=" & txtNum1.Text & " AND " & Campo & "<=" & txtNum2.Text
                    ElseIf chkExceptoNum.Checked Then
                        valor = Campo & " <" & txtExceptoNum1.Text & " AND " & Campo & ">" & txtExceptoNum2.Text
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
                                valor = valor & IIf(valor.Length > 0, ",", "") & "'" & lstIncluyendo.CheckedItems(x).Item(0).ToString.Trim & "'"
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
                Case "inchr"
                    If chkContenga.Checked Then
                        chk = lstContenga.CheckedItems.Count
                        If chk = 0 Then
                            msg = MessageBox.Show("No seleccionó ninguna de las opciones para el filtro por <<" & Campo & ">>,  ¿Desea que se seleccione la lista completa?", "Filtros", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                            If msg = Windows.Forms.DialogResult.Yes Then
                                valor = FiltraValor(Campo, txtIncluyendo.Text, False)
                            ElseIf msg = Windows.Forms.DialogResult.No Then
                                Exit Sub
                            End If
                        Else
                            valor = ""
                            For x = 0 To chk - 1
                                valor = valor & IIf(valor.Length > 0, " OR ", "") & Campo & " LIKE '*" & lstContenga.CheckedItems(x).Item(0).ToString.Trim & "*'"
                            Next
                            valor = " (" & valor & ")"
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

        Dim dtResultado As New DataTable
        Try

            dtResultado = dtResultadoIdeas.Clone
            For Each dRow In dtResultadoIdeas.Select(valor)
                dtResultado.ImportRow(dRow)
            Next

            dgLista.DataSource = dtResultado
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
        lblRegistros.Text = dgLista.Rows.Count & " registros"
    End Sub
    Private Sub lstFiltros_KeyUp(sender As Object, e As KeyEventArgs) Handles lstFiltros.KeyUp
        Dim FiltraValor As String
        Dim i As Integer
        Dim x As Integer
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
    End Sub

    Private Sub txtExcepto_TextChanged(sender As Object, e As EventArgs) Handles txtExcepto.TextChanged
        Dim Resultado As New DataTable
        dtIncluyendo = FiltrarDatos(txtExcepto.Text.Trim, False)

        lstExcepto.DataSource = dtIncluyendo
        lstExcepto.DisplayMember = dtIncluyendo.Columns(0).ColumnName

        Dim x As Integer
        For x = 0 To lstExcepto.Items.Count - 1
            lstExcepto.SetItemChecked(x, chkTodosExcepto.Checked)
        Next
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        NFiltros = 0
        lstFiltros.Items.Clear()
        dtIncluyendo = New DataTable
        'lstIncluyendo.DataSource = Nothing
        'lstExcepto.DataSource = Nothing
        'lstIncluyendo.Items.Clear()
        'lstExcepto.Items.Clear()
        txtIncluyendo.Text = ""
        txtExcepto.Text = ""

        'ConsultaPersonalVW("SELECT reloj + '     ' + nombres AS reloj FROM personalVW", dtResultado, False)
        ListarResultado("")
        dgLista.Refresh()
    End Sub

    Private Sub chkIncluyeFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluyeFecha.CheckedChanged
        txtFecha1.Enabled = chkIncluyeFecha.Checked
        txtFecha2.Enabled = chkIncluyeFecha.Checked

        txtFecha1.Focus()
    End Sub

    Private Sub chkExceptoFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkExceptoFecha.CheckedChanged
        txtExceptoFecha1.Enabled = chkExceptoFecha.Checked
        txtExceptoFecha2.Enabled = chkExceptoFecha.Checked

        txtExceptoFecha1.Focus()
    End Sub


    Private Sub chkIncluyendoNum_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluyendoNum.CheckedChanged
        txtNum1.Enabled = chkIncluyendoNum.Checked
        txtNum2.Enabled = chkIncluyendoNum.Checked

        txtNum1.Focus()
    End Sub

    Private Sub chkExceptoNum_CheckedChanged(sender As Object, e As EventArgs) Handles chkExceptoNum.CheckedChanged
        txtExceptoNum1.Enabled = chkExceptoNum.Checked
        txtExceptoNum2.Enabled = chkExceptoNum.Checked

        txtExceptoNum1.Focus()
    End Sub

    Private Sub cbCampos_TextChanged(sender As Object, e As EventArgs) Handles cbCampos.TextChanged

    End Sub

    Private Sub lstIncluyendo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstIncluyendo.SelectedIndexChanged

    End Sub

    Private Sub chkTodosIncluyendo_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosIncluyendo.CheckedChanged
        Dim x As Integer
        For x = 0 To lstIncluyendo.Items.Count - 1
            lstIncluyendo.SetItemChecked(x, chkTodosIncluyendo.Checked)
        Next
    End Sub

    Private Sub chkTodosExcepto_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosExcepto.CheckedChanged
        Dim x As Integer
        For x = 0 To lstExcepto.Items.Count - 1
            lstExcepto.SetItemChecked(x, chkTodosExcepto.Checked)
        Next
    End Sub

    Private Sub chkTodosContenga_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosContenga.CheckedChanged
        Dim x As Integer
        For x = 0 To lstContenga.Items.Count - 1
            lstContenga.SetItemChecked(x, chkTodosContenga.Checked)
        Next
    End Sub

    Private Sub txtContenga_TextChanged(sender As Object, e As EventArgs) Handles txtContenga.TextChanged
        Dim Resultado As New DataTable
        Dim dtContenga As New DataTable

        Try
            Dim Tipo As String = cbCampos.SelectedNode.Cells(2).Text.Trim
            If Tipo = "aux" Then

            Else
                dtContenga = FiltrarDatos(txtContenga.Text.Trim, False)
            End If

            lstContenga.DataSource = dtContenga
            If dtContenga.Columns.Count > 0 Then
                lstContenga.DisplayMember = dtContenga.Columns(0).ColumnName
            End If

            Dim x As Integer
            For x = 0 To lstContenga.Items.Count - 1

                lstContenga.SetItemChecked(x, chkTodosContenga.Checked)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class