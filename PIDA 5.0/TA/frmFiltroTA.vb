Public Class frmFiltroTA
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
        pnlHoras.Parent = pnlCaracter.Parent
        pnlHorasNum.Parent = pnlCaracter.Parent
        pnlLogico.Parent = pnlCaracter.Parent

        pnlFechas.Location = pnlCaracter.Location
        pnlNumerico.Location = pnlCaracter.Location
        pnlHoras.Location = pnlCaracter.Location
        pnlHorasNum.Location = pnlCaracter.Location
        pnlLogico.Location = pnlCaracter.Location

        pnlFechas.Size = pnlCaracter.Size
        pnlNumerico.Size = pnlCaracter.Size
        pnlHoras.Size = pnlCaracter.Size
        pnlHorasNum.Size = pnlCaracter.Size
        pnlLogico.Size = pnlCaracter.Size

        dtCampos = sqlExecute("SELECT RTRIM(UPPER(nombre)) AS 'NOMBRE',UPPER(cod_campo) as 'COD_CAMPO',tipo,'TAVW' as tabla FROM TA.dbo.campos ", "TA")
        dtCampos.DefaultView.Sort = "nombre"
        cbCampos.DataSource = dtCampos

        dgLista.AutoGenerateColumns = False ' Para que no muestre todos los campos incluyendo sueldos
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
            pnlHoras.Visible = Tipo = "time"
            pnlNumerico.Visible = Tipo = "num"
            pnlHorasNum.Visible = Tipo = "hour"
            pnlLogico.Visible = Tipo = "logical"

            Select Case Tipo
                Case "date"
                    'Si el campo es de tipo fecha
                    chkBlanco.Parent = txtFecha1.Parent
                    chkNoBlanco.Parent = txtFecha1.Parent

                    txtFecha1.Value = RangoFInicial
                    txtExceptoFecha1.Value = RangoFInicial

                    txtFecha2.Value = RangoFFinal
                    txtExceptoFecha2.Value = RangoFFinal
                Case "time"
                    'Si el campo es de tipo fecha
                    chkBlanco.Parent = txtHora1.Parent
                    chkNoBlanco.Parent = txtHora1.Parent

                    txtHora1.Value = "06:00 AM"
                    txtExceptoHora1.Value = "06:00 AM"

                    txtHora2.Value = "03:30 PM"
                    txtExceptoHora2.Value = "03:30 PM"
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

                    dtIncluyendo = sqlExecute("SELECT DISTINCT TOP 100 " & Campo & "  FROM " & Tabla & " WHERE " & Campo & " <> ''  AND NOT " & Campo & " IS NULL", "TA")

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
        If cbCampos.SelectedIndex >= 0 Then
            Campo = cbCampos.SelectedValue.ToString.Trim
        Else
            Campo = ""
        End If
        dtValores = sqlExecute("SELECT DISTINCT " & Campo & "  FROM TAVW WHERE " & FiltraValor(Campo, Texto, Excepcion), "ta")
        Return dtValores
    End Function

    Private Function FiltrarAuxiliares(Texto As String, Excepcion As Boolean) As DataTable
        Dim Valores() As String
        Valores = Split(Texto, ";")
        Dim Valor As String = ""
        Dim dtValores As New DataTable
        Dim Campo As String

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

        dtValores = ConsultaPersonalVW("SELECT DISTINCT contenido FROM DETALLE_AUXILIARES WHERE CAMPO = '" & Campo & "' AND " & Valor, False)
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
                Tipo = cbCampos.SelectedNode.Cells(2).Text.Trim
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
                Case "time"
                    'Para campos de tiempo, como hora de entrada, salida, etc.
                    'Ya que estos campos tienen la hora como caracter, en formato 12 hrs,
                    'en el view se genera otro campo con esta hora en formato tipo Time de 24 hrs.
                    'Este campo termina en '_FH', y es el que se utiliza para comparar
                    If chkIncluyeHora.Checked Then
                        ' valor = Campo & " >= '" & (txtHora1.Value.TimeOfDay.ToString) & "' AND " & Campo & "<='" & (txtHora2.Value.TimeOfDay.ToString) & "'"
                        valor = Campo & " >= '" & txtHora1.Value.TimeOfDay.ToString & "' AND " & Campo & " <= '" & txtHora2.Value.TimeOfDay.ToString & "' "

                    ElseIf chkExceptoHora.Checked Then
                        valor = "NOT (" & Campo & " >= '" & txtExceptoHora1.Value.TimeOfDay.ToString & "' AND " & Campo & " <= '" & txtExceptoHora2.Value.TimeOfDay.ToString & "') "

                    ElseIf chkBlanco.Checked Then
                        valor = "(" & Campo & " = '00:00:00' OR " & Campo & " IS NULL)"
                    ElseIf chkNoBlanco.Checked Then
                        valor = "(" & Campo & " <> '00:00:00' AND NOT " & Campo & " IS NULL)"
                    End If
                Case "hour"
                    'Para horas como normales, dobles, triples, etc.

                    'Dar formato a las horas, porque el MaskTextBox regresa en blanco los ceros
                    Dim Hora1 As String = txtHoraNum1.Text.Substring(0, 2).Trim.PadLeft(2, "0") & ":" & txtHoraNum1.Text.Substring(3).Trim.PadRight(2, "0")
                    Dim Hora2 As String = txtHoraNum2.Text.Substring(0, 2).Trim.PadLeft(2, "0") & ":" & txtHoraNum2.Text.Substring(3).Trim.PadRight(2, "0")
                    Dim ExHora1 As String = txtExceptoHoraNum1.Text.Substring(0, 2).Trim.PadLeft(2, "0") & ":" & txtExceptoHoraNum1.Text.Substring(3).Trim.PadRight(2, "0")
                    Dim ExHora2 As String =txtExceptoHoraNum2.Text.Substring(0, 2).Trim.PadLeft(2, "0") & ":" & txtExceptoHoraNum2.Text.Substring(3).Trim.PadRight(2, "0")

                    If chkIncluyeHora.Checked Then
                        valor = Campo & " >= '" & Hora1 & "' AND " & Campo & "<='" & Hora2 & "'"
                    ElseIf chkExceptoHora.Checked Then
                        valor = "NOT (" & Campo & " >= '" & ExHora1 & "' AND " & Campo & "<='" & ExHora2 & "')"
                    ElseIf chkBlanco.Checked Then
                        valor = "(" & Campo & " = '' OR " & Campo & " IS NULL)"
                    ElseIf chkNoBlanco.Checked Then
                        valor = "(" & Campo & " <> '' AND NOT " & Campo & " IS NULL)"
                    End If
                Case "logical"
                    If chkIncluyeHora.Checked Then
                        valor = Campo & " = " & IIf(btnLogico.Value, 1, 0)
                    ElseIf chkExceptoHora.Checked Then
                        valor = Campo & " = " & IIf(btnLogico.Value, 1, 0)
                    ElseIf chkBlanco.Checked Then
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

            dtResultado = dtResultadoTA.Clone
            For Each dRow In dtResultadoTA.Select(valor)
                dtResultado.ImportRow(dRow)
            Next

            '== SE APLICA EL FILTRO TAMBIEN PARA LA SEGUNDA EMPRESA         12ene2022           Ernesto
            Dim dtResultado2 As DataTable = dtInfoPlanta2.Clone
            Try
                For Each x In dtInfoPlanta2.Select(valor)
                    dtResultado2.ImportRow(x)
                Next
                dtInfoPlanta2 = dtResultado2.Copy
            Catch ex As Exception
                dtInfoPlanta2 = dtResultado2.Copy
            End Try
            '==

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

    Private Sub chkIncluyeHora_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluyeHora.CheckedChanged
        txtHora1.Enabled = chkIncluyeHora.Checked
        txtHora2.Enabled = chkIncluyeHora.Checked

        txtHora1.Focus()
    End Sub

    Private Sub chkExceptoHora_CheckedChanged(sender As Object, e As EventArgs) Handles chkExceptoHora.CheckedChanged
        txtExceptoHora1.Enabled = chkExceptoHora.Checked
        txtExceptoHora2.Enabled = chkExceptoHora.Checked

        txtExceptoHora1.Focus()
    End Sub

    Private Sub chkIncluyeHorasNum_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluyeHorasNum.CheckedChanged
        txtHoraNum1.Enabled = chkIncluyeHorasNum.Checked
        txtHoraNum2.Enabled = chkIncluyeHorasNum.Checked

        txtHoraNum1.Focus()
    End Sub

    Private Sub chkExceptoHorasNum_CheckedChanged(sender As Object, e As EventArgs) Handles chkExceptoHorasNum.CheckedChanged
        txtExceptoHoraNum1.Enabled = chkExceptoHorasNum.Checked
        txtExceptoHoraNum2.Enabled = chkExceptoHorasNum.Checked

        txtExceptoHoraNum1.Focus()
    End Sub

    Private Sub txtHoraNum1_Enter(sender As Object, e As EventArgs) Handles txtHoraNum1.GotFocus
        txtHoraNum1.SelectionLength = 5
    End Sub

    Private Sub txtHoraNum1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtHoraNum1.Validating
        txtHoraNum1.Text = CtoHSimple(txtHoraNum1.Text)
    End Sub

    Private Sub txtHoraNum2_Enter(sender As Object, e As EventArgs) Handles txtHoraNum2.GotFocus
        txtHoraNum2.SelectionLength = 5
    End Sub

    Private Sub txtHoraNum2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtHoraNum2.Validating
        txtHoraNum2.Text = CtoHSimple(txtHoraNum2.Text)
    End Sub


    Private Sub txtExceptoHoraNum1_Enter(sender As Object, e As EventArgs) Handles txtExceptoHoraNum1.GotFocus
        txtExceptoHoraNum1.SelectionLength = 5
    End Sub

    Private Sub txtExceptoHoraNum2_Enter(sender As Object, e As EventArgs) Handles txtExceptoHoraNum2.GotFocus
        txtExceptoHoraNum2.SelectionLength = 5
    End Sub

    Private Sub txtExceptoHoraNum2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtExceptoHoraNum2.Validating
        txtExceptoHoraNum2.Text = CtoHSimple(txtHoraNum2.Text)
    End Sub

    Private Sub txtExceptoHoraNum1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtExceptoHoraNum1.Validating
        txtExceptoHoraNum1.Text = CtoHSimple(txtExceptoHoraNum1.Text)
    End Sub
End Class