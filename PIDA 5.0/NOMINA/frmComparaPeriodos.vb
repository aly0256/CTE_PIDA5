Public Class frmComparaPeriodos
    Dim dtCia1 As New DataTable
    Dim dtAno1 As New DataTable
    Dim dtPeriodo1 As New DataTable
    Dim dtClase1 As New DataTable
    Dim dtTipoNomina1 As New DataTable
    Dim dtPeriodi1 As New DataTable


    Dim dtCia2 As New DataTable
    Dim dtAno2 As New DataTable
    Dim dtPeriodo2 As New DataTable
    Dim dtClase2 As New DataTable
    Dim dtTipoNomina2 As New DataTable
    Dim dtPeriodi2 As New DataTable


    Dim dtComparativo As New DataTable


    Private Sub frmComparaPeriodos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtCia1 = sqlExecute("SELECT cod_comp,nombre FROM cias ORDER BY cia_default DESC,cod_comp", "personal")
        cmbCia1.DataSource = dtCia1
        dtCia2 = dtCia1.Copy
        cmbCia2.DataSource = dtCia2

        dtPeriodi1 = sqlExecute("Select tipo_periodo, nombre from tipo_periodo", "personal")
        cmbPeriodi1.DataSource = dtPeriodi1
        dtPeriodi2 = dtPeriodi1.Copy
        cmbPeriodi2.DataSource = dtPeriodi2

      

        dtAno1 = sqlExecute("SELECT DISTINCT ano FROM periodos ORDER BY ano DESC", "TA")
        cmbAno1.DataSource = dtAno1
        dtAno2 = dtAno1.Copy
        cmbAno2.DataSource = dtAno2

        dtTipoNomina1 = sqlExecute("SELECT cod_tipo_nomina,nombre FROM tipos_nomina", "nomina")
        cmbTipoNomina1.DataSource = dtTipoNomina1
        cmbTipoNomina1.SelectedValue = "N"

        dtTipoNomina2 = dtTipoNomina1.Copy
        cmbTipoNomina2.DataSource = dtTipoNomina2
        cmbTipoNomina2.SelectedValue = "N"
        dgComparativo.AutoGenerateColumns = False
        'dtPeriodo2 = dtPeriodo1.Copy

        'cmbPeriodo2.DataSource = dtPeriodo2
    End Sub

    Private Sub cmbAno1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAno1.SelectedValueChanged, cmbPeriodi1.SelectedValueChanged
        If cmbPeriodi1.SelectedValue = "S" Then
            dtPeriodo1 = sqlExecute("SELECT periodo,fecha_ini,fecha_fin FROM periodos WHERE ano = '" & cmbAno1.SelectedValue & "'  ORDER BY periodo ASC", "TA")
            cmbPeriodo1.DataSource = dtPeriodo1
        ElseIf cmbPeriodi1.SelectedValue = "Q" Then
            dtPeriodo1 = sqlExecute("SELECT periodo,fecha_ini,fecha_fin FROM periodos_quincenal WHERE ano = '" & cmbAno1.SelectedValue & "'  ORDER BY periodo ASC", "TA")
            cmbPeriodo1.DataSource = dtPeriodo1
        ElseIf cmbPeriodi1.SelectedValue = "M" Then
            dtPeriodo1 = sqlExecute("SELECT periodo,fecha_ini,fecha_fin FROM periodos_mensual WHERE ano = '" & cmbAno1.SelectedValue & "'  ORDER BY periodo ASC", "TA")
            cmbPeriodo1.DataSource = dtPeriodo1
        End If
    End Sub

    Private Sub cmbAno2_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAno2.SelectedValueChanged, cmbPeriodi2.SelectedValueChanged
        If cmbPeriodi2.SelectedValue = "S" Then
            dtPeriodo2 = sqlExecute("SELECT periodo,fecha_ini,fecha_fin FROM periodos WHERE ano = '" & cmbAno2.SelectedValue & "'  ORDER BY periodo ASC", "TA")
            cmbPeriodo2.DataSource = dtPeriodo2
        ElseIf cmbPeriodi2.SelectedValue = "Q" Then
            dtPeriodo2 = sqlExecute("SELECT periodo,fecha_ini,fecha_fin FROM periodos_quincenal WHERE ano = '" & cmbAno2.SelectedValue & "'  ORDER BY periodo ASC", "TA")
            cmbPeriodo2.DataSource = dtPeriodo2
        ElseIf cmbPeriodi2.SelectedValue = "M" Then
            dtPeriodo2 = sqlExecute("SELECT periodo,fecha_ini,fecha_fin FROM periodos_mensual WHERE ano = '" & cmbAno2.SelectedValue & "'  ORDER BY periodo ASC", "TA")
            cmbPeriodo2.DataSource = dtPeriodo2
        End If
    End Sub

    Private Sub cmbAno2_TextChanged(sender As Object, e As EventArgs) Handles cmbAno2.TextChanged

    End Sub

    Private Sub btnComparar_Click(sender As Object, e As EventArgs) Handles btnComparar.Click
        Dim Ano1 As String
        Dim Ano2 As String
        Dim Periodo1 As String
        Dim Periodo2 As String
        Dim Clase1 As String
        Dim Clase2 As String
        Dim Tipo1 As String
        Dim Tipo2 As String
        Dim Cia1 As String
        Dim Cia2 As String
        Dim Periodi1 As String
        Dim Periodi2 As String
       

        Try
            Me.Cursor = Cursors.WaitCursor
            Ano1 = cmbAno1.SelectedValue
            Ano2 = cmbAno2.SelectedValue
            Periodo1 = cmbPeriodo1.SelectedValue
            Periodo2 = cmbPeriodo2.SelectedValue
            Clase1 = IIf(cmbClase1.SelectedValue = "T", "", " AND cod_clase = '" & cmbClase1.SelectedValue & "' ")
            Clase2 = IIf(cmbClase2.SelectedValue = "T", "", " AND cod_clase = '" & cmbClase2.SelectedValue & "' ")
            Tipo1 = " AND cod_tipo_nomina = '" & cmbTipoNomina1.SelectedValue & "' "
            Tipo2 = " AND cod_tipo_nomina = '" & cmbTipoNomina2.SelectedValue & "' "

            Cia1 = " AND cod_comp = '" & cmbCia1.SelectedValue & "' "
            Cia2 = " AND cod_comp = '" & cmbCia2.SelectedValue & "' "

            Periodi1 = "AND nomina.tipo_periodo = '" & cmbPeriodi1.SelectedValue & "'"
            Periodi2 = "AND nomina.tipo_periodo = '" & cmbPeriodi2.SelectedValue & "'"


            'BERE
            'dtComparativo = sqlExecute("SELECT x.*,y.*,conceptos.nombre,naturalezas.nombre," & _
            '                           "IIF(conceptos.cod_naturaleza='P','A',IIF(conceptos.cod_naturaleza='D','B',conceptos.cod_naturaleza)) AS cod_naturaleza FROM " & _
            '                           "(SELECT nomina.ano AS ano,nomina.periodo AS periodo," & _
            '                           "movimientos.concepto, COUNT(movimientos.reloj) AS cuantos, SUM (movimientos.monto) AS monto,prioridad " & _
            '                           "FROM nomina LEFT JOIN movimientos ON nomina.reloj = movimientos.reloj AND nomina.ano = movimientos.ano " & _
            '                           "AND nomina.periodo = movimientos.periodo WHERE " & _
            '                           "nomina.ano = '" & Ano1 & "' AND nomina.periodo = '" & Periodo1 & "'" & Clase1 & Tipo1 & Cia1 & _
            '                           "GROUP BY nomina.ano,nomina.periodo,concepto,prioridad) AS x LEFT JOIN " & _
            '                           "(SELECT nomina.ano AS ano,nomina.periodo AS periodo," & _
            '                           "movimientos.concepto, COUNT(movimientos.reloj) AS cuantos, SUM (movimientos.monto) AS monto " & _
            '                           "FROM nomina LEFT JOIN movimientos ON nomina.reloj = movimientos.reloj AND nomina.ano = movimientos.ano " & _
            '                           "AND nomina.periodo = movimientos.periodo WHERE " & _
            '                           "nomina.ano = '" & Ano2 & "' AND nomina.periodo = '" & Periodo2 & "'" & Clase2 & Tipo2 & Cia2 & _
            '                           "GROUP BY nomina.ano,nomina.periodo,concepto) AS y " & _
            '                           "ON x.concepto = y.concepto  " & _
            '                           "LEFT JOIN conceptos ON x.concepto = conceptos.concepto " & _
            '                           "LEFT JOIN nomina.dbo.naturalezas ON conceptos.cod_naturaleza = naturalezas.COD_NATURALEZA " & _
            '                           "WHERE conceptos.comparativo_nominas = 1 " & _
            '                           "ORDER BY cod_naturaleza,conceptos.prioridad", "Nomina")

            dtComparativo = sqlExecute("SELECT x.*,y.*,conceptos.nombre,naturalezas.nombre," & _
                                       "(CASE WHEN conceptos.cod_naturaleza='P' THEN 'A'ELSE ((CASE WHEN conceptos.cod_naturaleza='D' THEN 'B' ELSE conceptos.cod_naturaleza END))END) AS cod_naturaleza FROM " & _
                                       "(SELECT nomina.ano AS ano,nomina.periodo AS periodo," & _
                                       "movimientos.concepto, COUNT(movimientos.reloj) AS cuantos, SUM (movimientos.monto) AS monto,prioridad " & _
                                       "FROM nomina LEFT JOIN movimientos ON nomina.reloj = movimientos.reloj AND nomina.ano = movimientos.ano " & _
                                       "AND nomina.tipo_periodo = movimientos.tipo_periodo AND nomina.periodo = movimientos.periodo WHERE " & _
                                       "nomina.ano = '" & Ano1 & "' AND nomina.periodo = '" & Periodo1 & "'" & Clase1 & Tipo1 & Cia1 & Periodi1 & _
                                       "GROUP BY nomina.ano,nomina.periodo,concepto,prioridad) AS x LEFT JOIN " & _
                                       "(SELECT nomina.ano AS ano,nomina.periodo AS periodo," & _
                                       "movimientos.concepto, COUNT(movimientos.reloj) AS cuantos, SUM (movimientos.monto) AS monto " & _
                                       "FROM nomina LEFT JOIN movimientos ON nomina.reloj = movimientos.reloj AND nomina.ano = movimientos.ano " & _
                                       "AND nomina.tipo_periodo = movimientos.tipo_periodo AND nomina.periodo = movimientos.periodo WHERE " & _
                                       "nomina.ano = '" & Ano2 & "' AND nomina.periodo = '" & Periodo2 & "'" & Clase2 & Tipo2 & Cia2 & Periodi2 & _
                                       "GROUP BY nomina.ano,nomina.periodo,concepto) AS y " & _
                                       "ON x.concepto = y.concepto  " & _
                                       "LEFT JOIN conceptos ON x.concepto = conceptos.concepto " & _
                                       "LEFT JOIN nomina.dbo.naturalezas ON conceptos.cod_naturaleza = naturalezas.COD_NATURALEZA " & _
                                       "WHERE conceptos.activo = 1 " & _
                                       "ORDER BY cod_naturaleza,conceptos.prioridad", "Nomina")

            'NOTA: Si el resultado del Query anterior no contiene información, revisar que haya conceptos que comparativo_nominas = 1 o activo = 1

            dtComparativo.Columns.Add("cia1", GetType(System.String))
            dtComparativo.Columns.Add("cia2", GetType(System.String))

            dtComparativo.Columns.Add("clase1", GetType(System.String))
            dtComparativo.Columns.Add("clase2", GetType(System.String))

            dtComparativo.Columns.Add("tipo1", GetType(System.String))
            dtComparativo.Columns.Add("tipo2", GetType(System.String))


            dtComparativo.Columns.Add("difPersonas", GetType(System.Double))
            dtComparativo.Columns.Add("porPersonas", GetType(System.Double))
            dtComparativo.Columns.Add("difMonto", GetType(System.Double))
            dtComparativo.Columns.Add("porMonto", GetType(System.Double))

            For Each dRow As DataRow In dtComparativo.Rows
                dRow("clase1") = cmbClase1.SelectedNode.Cells(1).Text.Trim
                dRow("clase2") = cmbClase2.SelectedNode.Cells(1).Text.Trim

                dRow("tipo1") = cmbTipoNomina1.SelectedNode.Cells(1).Text.Trim
                dRow("tipo2") = cmbTipoNomina2.SelectedNode.Cells(1).Text.Trim

                dRow("cia1") = cmbCia1.SelectedNode.Cells(1).Text.Trim
                dRow("cia2") = cmbCia2.SelectedNode.Cells(1).Text.Trim

                dRow("monto") = IIf(IsDBNull(dRow("monto")), 0, dRow("monto"))
                dRow("monto1") = IIf(IsDBNull(dRow("monto1")), 0, dRow("monto1"))
                dRow("cuantos") = IIf(IsDBNull(dRow("cuantos")), 0, dRow("cuantos"))
                dRow("cuantos1") = IIf(IsDBNull(dRow("cuantos1")), 0, dRow("cuantos1"))

                dRow("difPersonas") = dRow("cuantos1") - dRow("cuantos")
                dRow("difMonto") = dRow("monto1") - dRow("monto")
                dRow("porPersonas") = Math.Round(IIf(dRow("cuantos") > 0, (dRow("cuantos1") / dRow("cuantos")) - 1, 0), 4)
                dRow("porMonto") = Math.Round(IIf(dRow("monto") > 0, (dRow("monto1") / dRow("monto")) - 1, 0), 4)
            Next
            btnImprimir.Enabled = True

            dgComparativo.DataSource = dtComparativo

        Catch ex As Exception
            dtComparativo = New DataTable
            btnImprimir.Enabled = False
            MessageBox.Show("Se detectaron errores, por lo que no pudo llevarse a cabo el comparativo. Favor de verificar." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub dgComparativo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgComparativo.CellContentClick

    End Sub

    Private Sub dgComparativo_Paint(sender As Object, e As PaintEventArgs) Handles dgComparativo.Paint
        For x = 0 To dgComparativo.RowCount - 1
            dgComparativo.Item("colDiferenciaPersonas", x).Style.BackColor = IIf(Math.Abs(dgComparativo.Item("colPorPersonas", x).Value) > 0.2, Color.Yellow, SystemColors.Window)
            dgComparativo.Item("colDiferenciaMonto", x).Style.BackColor = IIf(Math.Abs(dgComparativo("colPorMonto", x).Value) > 0.2, Color.Yellow, SystemColors.Window)
            dgComparativo.Item("colPorPersonas", x).Style.BackColor = IIf(Math.Abs(dgComparativo.Item("colPorPersonas", x).Value) > 0.2, Color.Yellow, SystemColors.Window)
            dgComparativo.Item("colPorMonto", x).Style.BackColor = IIf(Math.Abs(dgComparativo.Item("colPorMonto", x).Value) > 0.2, Color.Yellow, SystemColors.Window)
        Next
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        frmVistaPrevia.LlamarReporte("Comparativo de periodos", dtComparativo)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub cmbCia1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCia1.SelectedValueChanged
        dtClase1 = sqlExecute("SELECT cod_clase,nombre FROM clase WHERE cod_comp = '" & cmbCia1.SelectedValue & "'")
        dtClase1.Rows.Add({"T", "Todos"})
        cmbClase1.DataSource = dtClase1
        cmbClase1.SelectedValue = "T"
    End Sub

    Private Sub cmbCia2_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCia2.SelectedValueChanged
        dtClase2 = sqlExecute("SELECT cod_clase,nombre FROM clase WHERE cod_comp = '" & cmbCia2.SelectedValue & "'")
        dtClase2.Rows.Add({"T", "Todos"})
        cmbClase2.DataSource = dtClase2
        cmbClase2.SelectedValue = "T"
    End Sub

    Private Sub cmbCia2_TextChanged(sender As Object, e As EventArgs) Handles cmbCia2.TextChanged

    End Sub

    
    
End Class
