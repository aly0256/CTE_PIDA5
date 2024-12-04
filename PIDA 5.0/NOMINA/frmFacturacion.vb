Imports Excel = Microsoft.Office.Interop.Excel


Public Class frmFacturacion
    Dim Encabezado As String
    Dim NombreCia As String

    Dim Archivo As String
    Dim dtPeriodos As New DataTable
    Dim dtUbicacion As New DataTable
    Dim dtCias As New DataTable
    Dim dtDatosPrenomina As New DataTable
    Dim dtDatosProvision As New DataTable
    Dim dtDatosCostoExtra As New DataTable
    Dim dtDatosCostoFinal As New DataTable


    Private Sub frmFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtTemp As New DataTable

        Try
            dtCias = sqlExecute("SELECT cod_comp,nombre FROM cias ORDER BY cia_default DESC,cod_comp")
            cmbCia.DataSource = dtCias
            cmbCia.SelectedIndex = 0

            dtPeriodos = sqlExecute("SELECT ano+periodo as 'seleccionado',ano,periodo,fecha_ini,fecha_fin FROM periodos ORDER BY ano DESC,periodo ASC", "TA")
            cmbPeriodos.DataSource = dtPeriodos
            'cmbPeriodos.Columns("ColSeleccionado").Visible = False

            dtTemp = sqlExecute("SELECT TOP 1 ano+periodo AS seleccionado FROM nomina WHERE periodo<='53' ORDER BY ano DESC, periodo DESC", "NOMINA")
            If dtTemp.Rows.Count > 0 Then
                cmbPeriodos.SelectedValue = dtTemp.Rows(0).Item("seleccionado")
            End If

        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim Respuesta As Exception
        Dim NombreArchivo As String
        Dim ExcelAPP As New Excel.Application
        Dim wBook As Excel.Workbook

        Try
            sqlExecute("UPDATE base_facturacion SET excel_base = '" & txtBase.Text & "', excel_factura = '" & txtFactura.Text & "'", "nomina")

            Respuesta = ProvisionSUA(cmbCia.SelectedValue, cmbPeriodos.SelectedValue.ToString.Trim.Substring(0, 4), cmbPeriodos.SelectedValue.ToString.Trim.Substring(4, 2))
            If Not Respuesta Is Nothing Then
                Err.Raise(Respuesta.HResult, Respuesta)
            End If

            'Respuesta = PrenominaHoras(cmbCia.SelectedValue, cmbPeriodos.SelectedValue.ToString.Trim.Substring(0, 4), cmbPeriodos.SelectedValue.ToString.Trim.Substring(4, 2))
            'If Not Respuesta Is Nothing Then
            '    Err.Raise(Respuesta.HResult, Respuesta)
            'End If

            Respuesta = CalculoCostoHoraExtra(cmbCia.SelectedValue, cmbPeriodos.SelectedValue.ToString.Trim.Substring(0, 4), cmbPeriodos.SelectedValue.ToString.Trim.Substring(4, 2))
            If Not Respuesta Is Nothing Then
                Err.Raise(Respuesta.HResult, Respuesta)
            End If

            Respuesta = CalculoHorasFinal(cmbCia.SelectedValue, cmbPeriodos.SelectedValue.ToString.Trim.Substring(0, 4), cmbPeriodos.SelectedValue.ToString.Trim.Substring(4, 2))
            If Not Respuesta Is Nothing Then
                Err.Raise(Respuesta.HResult, Respuesta)
            End If

            NombreArchivo = txtFactura.Text.Trim

            dtTemporal = sqlExecute("SELECT fecha_ini,fecha_fin FROM periodos WHERE ano = '" & cmbPeriodos.SelectedValue.ToString.Substring(0, 4) & _
                                    "' AND  periodo = '" & cmbPeriodos.SelectedValue.ToString.Substring(4, 2) & "'", "ta")
            Encabezado = "Semana " & cmbPeriodos.SelectedValue.ToString.Substring(4, 2) & " - " & cmbPeriodos.SelectedValue.ToString.Substring(0, 4)
            Encabezado = Encabezado & " (del " & FechaLetra(dtTemporal.Rows(0).Item("fecha_ini")) & " al " & FechaLetra(dtTemporal.Rows(0).Item("fecha_fin")) & ")"

            dtTemporal = sqlExecute("SELECT nombre FROM cias WHERE cod_comp = '" & cmbCia.SelectedValue.ToString.Trim & "'")
            NombreCia = dtTemporal.Rows(0).Item("nombre").ToString.Trim.ToUpper

            wBook = ExcelAPP.Workbooks.Open(txtBase.Text.Trim)
            ExportaCostoHora(wBook)
            ExportaImpuestosPatronales(wBook)
            ExportaFactura(wBook)

            If System.IO.File.Exists(NombreArchivo) Then
                System.IO.File.Delete(NombreArchivo)
            End If

            wBook.SaveAs(NombreArchivo)
            'ExcelAPP.Workbooks.Open(NombreArchivo)
            ExcelAPP.Visible = True

            MessageBox.Show("El archivo de facturación fue exitosamente creado.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            ExcelAPP.Quit()
            ExcelAPP = Nothing
            MessageBox.Show("Se detectaron errores durante el proceso de facturación.", vbCrLf & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ExportaCostoHora(ByRef wBook As Excel.Workbook)
        Try
            Dim wSheet As Excel.Worksheet
            wSheet = wBook.Sheets("Costo_por_hora")

            Dim lngCount As Integer
            Dim RegistrosStr(dtDatosProvision.Rows.Count - 1, 3) As String
            Dim RegistrosDbl(dtDatosProvision.Rows.Count - 1, 16) As Double

            lngCount = 0
            For Each dReg As DataRow In dtDatosProvision.Rows
                RegistrosStr(lngCount, 0) = IIf(IsDBNull(dReg("cod_comp")), "", dReg("cod_comp"))
                RegistrosStr(lngCount, 1) = IIf(IsDBNull(dReg("cod_planta")), "", dReg("cod_planta"))
                RegistrosStr(lngCount, 2) = IIf(IsDBNull(dReg("reloj")), "", dReg("reloj"))
                RegistrosStr(lngCount, 3) = IIf(IsDBNull(dReg("nombres")), "", dReg("nombres"))
                RegistrosDbl(lngCount, 0) = IIf(IsDBNull(dReg("diario")), 0, dReg("diario"))
                RegistrosDbl(lngCount, 1) = IIf(IsDBNull(dReg("integrado")), 0, dReg("integrado"))
                RegistrosDbl(lngCount, 2) = IIf(IsDBNull(dReg("mensual")), 0, dReg("mensual"))
                RegistrosDbl(lngCount, 3) = IIf(IsDBNull(dReg("vacpag")), 0, dReg("vacpag"))
                RegistrosDbl(lngCount, 4) = IIf(IsDBNull(dReg("pripag")), 0, dReg("pripag"))
                RegistrosDbl(lngCount, 5) = IIf(IsDBNull(dReg("agupag")), 0, dReg("agupag"))
                RegistrosDbl(lngCount, 6) = IIf(IsDBNull(dReg("IMSSPAT")), 0, dReg("IMSSPAT"))
                RegistrosDbl(lngCount, 7) = IIf(IsDBNull(dReg("CESVEJP")), 0, dReg("CESVEJP"))
                RegistrosDbl(lngCount, 8) = IIf(IsDBNull(dReg("sar")), 0, dReg("sar"))
                RegistrosDbl(lngCount, 9) = IIf(IsDBNull(dReg("infona")), 0, dReg("infona"))
                RegistrosDbl(lngCount, 10) = IIf(IsDBNull(dReg("impest")), 0, dReg("impest"))
                RegistrosDbl(lngCount, 11) = IIf(IsDBNull(dReg("total_imp")), 0, dReg("total_imp"))
                RegistrosDbl(lngCount, 12) = IIf(IsDBNull(dReg("total_sueldo_impuesto")), 0, dReg("total_sueldo_impuesto"))
                RegistrosDbl(lngCount, 13) = IIf(IsDBNull(dReg("markup")), 0, dReg("markup"))
                RegistrosDbl(lngCount, 14) = IIf(IsDBNull(dReg("total_servicio")), 0, dReg("total_servicio"))
                RegistrosDbl(lngCount, 15) = IIf(IsDBNull(dReg("costo_por_hora_con_impuesto")), 0, dReg("costo_por_hora_con_impuesto"))
                RegistrosDbl(lngCount, 16) = IIf(IsDBNull(dReg("costo_por_hora_sin_impuesto")), 0, dReg("costo_por_hora_sin_impuesto"))

                lngCount = lngCount + 1
            Next
            wSheet.Cells(1, 1) = NombreCia
            wSheet.Cells(3, 1) = Encabezado
            wSheet.Range("A6", "D" & RegistrosDbl.GetUpperBound(0) + 6).Value = RegistrosStr
            wSheet.Range("E6", "U" & RegistrosDbl.GetUpperBound(0) + 6).Value = RegistrosDbl


        Catch ex As Exception
            MessageBox.Show("Se detectaron errores al exportar información de costo por hora. Si el problema persiste, contacte al administrador del sistema." & _
                            vbCrLf & vbCrLf & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportaImpuestosPatronales(ByRef wBook As Excel.Workbook)
        Try
            Dim wSheet As Excel.Worksheet
            wSheet = wBook.Sheets("Impuestos_patronales")

            Dim lngCount As Integer

            Dim RegistrosStr(dtDatosProvision.Rows.Count - 1, 6) As String
            Dim RegistrosDbl(dtDatosProvision.Rows.Count - 1, 38) As Double
            lngCount = 0

            For Each dReg As DataRow In dtDatosProvision.Rows
                RegistrosStr(lngCount, 0) = IIf(IsDBNull(dReg("cod_comp")), "", dReg("cod_comp"))
                RegistrosStr(lngCount, 1) = IIf(IsDBNull(dReg("cod_planta")), "", dReg("cod_planta"))
                RegistrosStr(lngCount, 2) = IIf(IsDBNull(dReg("reloj")), "", dReg("reloj"))
                RegistrosStr(lngCount, 3) = IIf(IsDBNull(dReg("nombres")), "", dReg("nombres"))
                RegistrosStr(lngCount, 4) = IIf(IsDBNull(dReg("numimss")), "", dReg("numimss"))
                RegistrosStr(lngCount, 5) = IIf(IsDBNull(dReg("alta")), "", dReg("alta"))
                RegistrosStr(lngCount, 6) = IIf(IsDBNull(dReg("baja")), "", dReg("baja"))

                RegistrosDbl(lngCount, 0) = IIf(IsDBNull(dReg("diario")), 0, dReg("diario"))
                RegistrosDbl(lngCount, 1) = IIf(IsDBNull(dReg("integrado")), 0, dReg("integrado"))
                RegistrosDbl(lngCount, 2) = IIf(IsDBNull(dReg("mes1")), 0, dReg("mes1"))
                RegistrosDbl(lngCount, 3) = IIf(IsDBNull(dReg("mes2")), 0, dReg("mes2"))
                RegistrosDbl(lngCount, 4) = IIf(IsDBNull(dReg("inc1")), 0, dReg("inc1"))
                RegistrosDbl(lngCount, 5) = IIf(IsDBNull(dReg("aus1")), 0, dReg("aus1"))
                RegistrosDbl(lngCount, 6) = IIf(IsDBNull(dReg("CUOFIJ")), 0, dReg("CUOFIJ"))
                RegistrosDbl(lngCount, 7) = IIf(IsDBNull(dReg("CUOADIP")), 0, dReg("CUOADIP"))
                RegistrosDbl(lngCount, 8) = IIf(IsDBNull(dReg("CUOADIO")), 0, dReg("CUOADIO"))
                RegistrosDbl(lngCount, 9) = IIf(IsDBNull(dReg("CUOADI")), 0, dReg("CUOADI"))
                RegistrosDbl(lngCount, 10) = IIf(IsDBNull(dReg("PRESDINP")), 0, dReg("PRESDINP"))
                RegistrosDbl(lngCount, 11) = IIf(IsDBNull(dReg("PRESDINO")), 0, dReg("PRESDINO"))
                RegistrosDbl(lngCount, 12) = IIf(IsDBNull(dReg("PRESDIN")), 0, dReg("PRESDIN"))
                RegistrosDbl(lngCount, 13) = IIf(IsDBNull(dReg("IGASMEDP")), 0, dReg("IGASMEDP"))
                RegistrosDbl(lngCount, 14) = IIf(IsDBNull(dReg("IGASMEDO")), 0, dReg("IGASMEDO"))
                RegistrosDbl(lngCount, 15) = IIf(IsDBNull(dReg("IGASMED")), 0, dReg("IGASMED"))
                RegistrosDbl(lngCount, 16) = IIf(IsDBNull(dReg("RIESGOTR")), 0, dReg("RIESGOTR"))
                RegistrosDbl(lngCount, 17) = IIf(IsDBNull(dReg("INVIDAP")), 0, dReg("INVIDAP"))
                RegistrosDbl(lngCount, 18) = IIf(IsDBNull(dReg("INVIDAO")), 0, dReg("INVIDAO"))
                RegistrosDbl(lngCount, 19) = IIf(IsDBNull(dReg("INVIDA")), 0, dReg("INVIDA"))
                RegistrosDbl(lngCount, 20) = IIf(IsDBNull(dReg("GUAPRE")), 0, dReg("GUAPRE"))
                RegistrosDbl(lngCount, 21) = IIf(IsDBNull(dReg("IMSSPAT")), 0, dReg("IMSSPAT"))
                RegistrosDbl(lngCount, 22) = IIf(IsDBNull(dReg("IMSSOBR")), 0, dReg("IMSSOBR"))
                RegistrosDbl(lngCount, 23) = IIf(IsDBNull(dReg("TOTIMSS")), 0, dReg("TOTIMSS"))
                RegistrosDbl(lngCount, 24) = IIf(IsDBNull(dReg("SAR")), 0, dReg("SAR"))
                RegistrosDbl(lngCount, 25) = IIf(IsDBNull(dReg("CESVEJP")), 0, dReg("CESVEJP"))
                RegistrosDbl(lngCount, 26) = IIf(IsDBNull(dReg("CESVEJO")), 0, dReg("CESVEJO"))
                RegistrosDbl(lngCount, 27) = IIf(IsDBNull(dReg("CESVEJ")), 0, dReg("CESVEJ"))
                RegistrosDbl(lngCount, 28) = IIf(IsDBNull(dReg("subtotal_rcv_patron")), 0, dReg("subtotal_rcv_patron"))
                RegistrosDbl(lngCount, 29) = IIf(IsDBNull(dReg("subtotal_rcv_obrero")), 0, dReg("subtotal_rcv_obrero"))
                RegistrosDbl(lngCount, 30) = IIf(IsDBNull(dReg("total_rcv")), 0, dReg("total_rcv"))
                RegistrosDbl(lngCount, 31) = IIf(IsDBNull(dReg("INFONA")), 0, dReg("INFONA"))
                RegistrosDbl(lngCount, 32) = IIf(IsDBNull(dReg("aport_vol")), 0, dReg("aport_vol"))
                RegistrosDbl(lngCount, 33) = IIf(IsDBNull(dReg("amort_credito_obrero")), 0, dReg("amort_credito_obrero"))
                RegistrosDbl(lngCount, 34) = IIf(IsDBNull(dReg("total_infonavit_patron")), 0, dReg("total_infonavit_patron"))
                RegistrosDbl(lngCount, 35) = IIf(IsDBNull(dReg("IMPEST")), 0, dReg("IMPEST"))
                RegistrosDbl(lngCount, 36) = IIf(IsDBNull(dReg("gran_total")), 0, dReg("gran_total"))
                RegistrosDbl(lngCount, 37) = IIf(IsDBNull(dReg("total_obrero")), 0, dReg("total_obrero"))
                RegistrosDbl(lngCount, 38) = IIf(IsDBNull(dReg("total_patron")), 0, dReg("total_patron"))

                lngCount = lngCount + 1
            Next
            wSheet.Cells(1, 1) = NombreCia
            wSheet.Cells(3, 1) = Encabezado
            wSheet.Range("A11", "G" & RegistrosDbl.GetUpperBound(0) + 11).Value = RegistrosStr
            wSheet.Range("H11", "AT" & RegistrosDbl.GetUpperBound(0) + 11).Value = RegistrosDbl

        Catch ex As Exception
            MessageBox.Show("Se detectaron errores al exportar información de impuestos patronales. Si el problema persiste, contacte al administrador del sistema." & _
                            vbCrLf & vbCrLf & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ExportaFactura(ByRef wBook As Excel.Workbook)
        Try
            Dim wSheet As Excel.Worksheet
            wSheet = wBook.Sheets("Factura")

            Dim lngCount As Integer
            Dim Total As Double = 0
            Dim RenglonInicial As Integer = 7

            Dim RegistrosStr(dtDatosCostoFinal.Rows.Count - 1, 4) As String
            Dim RegistrosDbl(dtDatosCostoFinal.Rows.Count - 1, 15) As Double
            lngCount = 0

            For Each dReg As DataRow In dtDatosCostoFinal.Rows
                RegistrosStr(lngCount, 0) = IIf(IsDBNull(dReg("consecutivo")), 0, dReg("consecutivo"))
                RegistrosStr(lngCount, 1) = IIf(IsDBNull(dReg("reloj")), "", dReg("reloj"))
                RegistrosStr(lngCount, 2) = IIf(IsDBNull(dReg("nombres")), "", dReg("nombres"))
                RegistrosStr(lngCount, 3) = IIf(IsDBNull(dReg("puesto")), "", dReg("puesto"))
                RegistrosStr(lngCount, 4) = IIf(IsDBNull(dReg("turno")), "", dReg("turno"))

                RegistrosDbl(lngCount, 0) = IIf(IsDBNull(dReg("sueldo_diario")), 0, dReg("sueldo_diario"))
                'RegistrosDbl(lngCount, 1) = IIf(IsDBNull(dReg("costo_horas_normales")), 0, dReg("costo_horas_normales"))
                RegistrosDbl(lngCount, 1) = IIf(IsDBNull(dReg("horas_normales")), 0, dReg("horas_normales"))
                RegistrosDbl(lngCount, 2) = IIf(IsDBNull(dReg("subtotal_normales")), 0, dReg("subtotal_normales"))
                RegistrosDbl(lngCount, 3) = IIf(IsDBNull(dReg("horas_dobles")), 0, dReg("horas_dobles"))
                RegistrosDbl(lngCount, 4) = IIf(IsDBNull(dReg("costo_hora_doble")), 0, dReg("costo_hora_doble"))
                RegistrosDbl(lngCount, 5) = IIf(IsDBNull(dReg("subtotal_dobles")), 0, dReg("subtotal_dobles"))
                RegistrosDbl(lngCount, 6) = IIf(IsDBNull(dReg("horas_extras_integrables")), 0, dReg("horas_extras_integrables"))
                RegistrosDbl(lngCount, 7) = IIf(IsDBNull(dReg("costo_hora_extra_integrable")), 0, dReg("costo_hora_extra_integrable"))
                RegistrosDbl(lngCount, 8) = IIf(IsDBNull(dReg("subtotal_extra_integrable")), 0, dReg("subtotal_extra_integrable"))
                RegistrosDbl(lngCount, 9) = IIf(IsDBNull(dReg("horas_triples")), 0, dReg("horas_triples"))
                RegistrosDbl(lngCount, 10) = IIf(IsDBNull(dReg("costo_hora_triple")), 0, dReg("costo_hora_triple"))
                RegistrosDbl(lngCount, 11) = IIf(IsDBNull(dReg("subtotal_triples")), 0, dReg("subtotal_triples"))
                RegistrosDbl(lngCount, 12) = IIf(IsDBNull(dReg("subtotal_tiempo_extra")), 0, dReg("subtotal_tiempo_extra"))
                RegistrosDbl(lngCount, 13) = IIf(IsDBNull(dReg("markup")), 0, dReg("markup"))
                RegistrosDbl(lngCount, 14) = IIf(IsDBNull(dReg("total")), 0, dReg("total"))
                Total += IIf(IsDBNull(dReg("total")), 0, dReg("total"))
                lngCount = lngCount + 1
            Next
            wSheet.Cells(1, 1) = NombreCia
            wSheet.Cells(2, 1) = "FACTURACIÓN"
            wSheet.Cells(3, 1) = Encabezado
            wSheet.Range("A" & RenglonInicial, "E" & RegistrosDbl.GetUpperBound(0) + RenglonInicial).Value = RegistrosStr
            wSheet.Range("F" & RenglonInicial, "T" & RegistrosDbl.GetUpperBound(0) + RenglonInicial).Value = RegistrosDbl

            wSheet.Cells(RegistrosDbl.GetUpperBound(0) + RenglonInicial + 2, 3) = "Subtotal"
            wSheet.Cells(RegistrosDbl.GetUpperBound(0) + RenglonInicial + 2, 20) = Total

            wSheet.Cells(RegistrosDbl.GetUpperBound(0) + RenglonInicial + 3, 3) = "IVA"
            wSheet.Cells(RegistrosDbl.GetUpperBound(0) + RenglonInicial + 3, 20) = Total * 0.16

            wSheet.Cells(RegistrosDbl.GetUpperBound(0) + RenglonInicial + 4, 3) = "TOTAL"
            wSheet.Cells(RegistrosDbl.GetUpperBound(0) + RenglonInicial + 4, 20) = Total * 1.16

        Catch ex As Exception
            MessageBox.Show("Se detectaron errores al exportar información de impuestos patronales. Si el problema persiste, contacte al administrador del sistema." & _
                            vbCrLf & vbCrLf & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ProvisionSUA(ByVal Cia As String, ByVal Ano As String, ByVal Periodo As String) As Exception
        Dim dtProvision As New DataTable
        Dim horas As Double
        Dim Markup As Double
        Try
            dtTemporal = sqlExecute("SELECT porcentaje_markup FROM cias WHERE cod_comp = '" & Cia & "'")
            Markup = IIf(IsDBNull(dtTemporal.Rows(0).Item(0)), 5, dtTemporal.Rows(0).Item(0))
            Markup = Markup / 100

            dtDatosProvision = New DataTable
            dtDatosProvision = sqlExecute("SELECT cod_comp,cod_planta,cod_turno,reloj,nombres,numimss,alta,baja,sactual AS diario,sactual *30.4 AS mensual,nombre_puesto FROM nominaVW WHERE " & _
                       "cod_comp = '" & Cia & "' AND ano = '" & Ano & "' AND periodo = '" & Periodo & "'", "nomina")

            dtDatosProvision.Columns.Add("mes1", GetType(Double))
            dtDatosProvision.Columns.Add("mes2", GetType(Double))
            dtDatosProvision.Columns.Add("inc1", GetType(Double))
            dtDatosProvision.Columns.Add("aus1", GetType(Double))
            dtDatosProvision.Columns.Add("SALBASE", GetType(Double))
            dtDatosProvision.Columns.Add("INTEGRADO", GetType(Double))
            dtDatosProvision.Columns.Add("DIASCOT", GetType(Double))
            dtDatosProvision.Columns.Add("CUOFIJ", GetType(Double))     'Cuota_fija_patron
            dtDatosProvision.Columns.Add("CUOADIP", GetType(Double))    '_cuota_adicional_patron = excedente_3smdf_patron
            dtDatosProvision.Columns.Add("CUOADIO", GetType(Double))    '_cuota_adicional_obrero = excedente_3smdf_obrero
            dtDatosProvision.Columns.Add("CUOADI", GetType(Double))     '_cuota_adicional = subtotal_excedente_3smdf
            dtDatosProvision.Columns.Add("PRESDINP", GetType(Double))   '_prestaciones_dinero_patron = prestaciones_dinero_patron
            dtDatosProvision.Columns.Add("PRESDINO", GetType(Double))   '_prestaciones_dinero_obrero = prestaciones_dinero_obrero
            dtDatosProvision.Columns.Add("PRESDIN", GetType(Double))    '_pres_din = subtotal_prestaciones_dinero
            dtDatosProvision.Columns.Add("IGASMEDP", GetType(Double))   '_gmp_patron = gmp_patron	
            dtDatosProvision.Columns.Add("IGASMEDO", GetType(Double))   '_gmp_obrero = gmp_obrero
            dtDatosProvision.Columns.Add("IGASMED", GetType(Double))    '_gmp = gmp
            dtDatosProvision.Columns.Add("RIESGOTR", GetType(Double))   '_riesgo_trabajo = riesgo_trabajo
            dtDatosProvision.Columns.Add("INVIDA", GetType(Double))     '_inval_vida = subtotal_inval_vida
            dtDatosProvision.Columns.Add("INVIDAP", GetType(Double))    '_inval_vida_patron = inval_vida_patron
            dtDatosProvision.Columns.Add("INVIDAO", GetType(Double))    '_inval_vida_obrero = inval_vida_obrero
            dtDatosProvision.Columns.Add("GUAPRE", GetType(Double))     '_guard_pres_soc = guard_pres_soc
            dtDatosProvision.Columns.Add("IMSSPAT", GetType(Double))    '_imss_patron = total_imss_patron
            dtDatosProvision.Columns.Add("IMSSOBR", GetType(Double))    '_imss_obrero = total_imss_obrero 
            dtDatosProvision.Columns.Add("TOTIMSS", GetType(Double))    '_tot_cal_imss = total_imss	
            dtDatosProvision.Columns.Add("SAR", GetType(Double))        '_sar = retiro
            dtDatosProvision.Columns.Add("CESVEJP", GetType(Double))    '_c_v_patronal = c_v_patron
            dtDatosProvision.Columns.Add("CESVEJO", GetType(Double))    '_c_v_obrera = c_v_obrero
            dtDatosProvision.Columns.Add("CESVEJ", GetType(Double))     '_c_v =  subtotal_c_v 	
            dtDatosProvision.Columns.Add("subtotal_rcv_patron", GetType(Double))    ' subtotal_rcv_patron
            dtDatosProvision.Columns.Add("subtotal_rcv_obrero", GetType(Double))    ' subtotal_rcv_obrero
            dtDatosProvision.Columns.Add("total_rcv", GetType(Double))              'total_rcv
            dtDatosProvision.Columns.Add("INFONA", GetType(Double))     '_infonavit
            dtDatosProvision.Columns.Add("aport_vol", GetType(Double))
            dtDatosProvision.Columns.Add("amort_credito_obrero", GetType(Double))
            dtDatosProvision.Columns.Add("total_infonavit_patron", GetType(Double))
            dtDatosProvision.Columns.Add("impuesto_nominas_patron", GetType(Double))
            dtDatosProvision.Columns.Add("gran_total", GetType(Double))     'gran_total
            dtDatosProvision.Columns.Add("total_obrero", GetType(Double))   'total_patron
            dtDatosProvision.Columns.Add("total_patron", GetType(Double))   'total_obrero
            dtDatosProvision.Columns.Add("IMPEST", GetType(Double))     'impuesto_nominas_patron
            dtDatosProvision.Columns.Add("AGUPAG", GetType(Double))
            dtDatosProvision.Columns.Add("PRIPAG", GetType(Double))
            dtDatosProvision.Columns.Add("VACPAG", GetType(Double))
            dtDatosProvision.Columns.Add("total_imp", GetType(Double))
            dtDatosProvision.Columns.Add("total_sueldo_impuesto", GetType(Double))
            dtDatosProvision.Columns.Add("markup", GetType(Double))
            dtDatosProvision.Columns.Add("total_servicio", GetType(Double))
            dtDatosProvision.Columns.Add("costo_por_hora_con_impuesto", GetType(Double))
            dtDatosProvision.Columns.Add("costo_por_hora_sin_impuesto", GetType(Double))

            dtDatosProvision.PrimaryKey = New DataColumn() {dtDatosProvision.Columns("reloj")}

            For Each dRegistro As DataRow In dtDatosProvision.Rows
                dRegistro("mes1") = 30.4
                dRegistro("mes2") = 30.4
                dRegistro("inc1") = 0
                dRegistro("aus1") = 0

                dtProvision = sqlExecute("SELECT * FROM movtos_provision WHERE ano = '" & Ano & "' AND periodo = '" & Periodo & "' AND reloj = '" & dRegistro("reloj") & "'", "nomina")
                For Each dMov As DataRow In dtProvision.Rows
                    If dtDatosProvision.Columns.Contains(dMov("concepto").ToString.Trim) Then
                        dRegistro(dMov("concepto").ToString.Trim) = dMov("monto")
                    End If
                Next
                dRegistro("subtotal_rcv_patron") = IIf(IsDBNull(dRegistro("sar")), 0, dRegistro("sar")) + IIf(IsDBNull(dRegistro("cesvejp")), 0, dRegistro("cesvejp"))
                dRegistro("subtotal_rcv_obrero") = IIf(IsDBNull(dRegistro("cesvejo")), 0, dRegistro("cesvejo"))
                dRegistro("total_rcv") = IIf(IsDBNull(dRegistro("sar")), 0, dRegistro("sar")) + IIf(IsDBNull(dRegistro("cesvej")), 0, dRegistro("cesvej"))
                dRegistro("total_patron") = IIf(IsDBNull(dRegistro("IMSSPAT")), 0, dRegistro("IMSSPAT")) + _
                    IIf(IsDBNull(dRegistro("subtotal_rcv_patron")), 0, dRegistro("subtotal_rcv_patron")) + _
                    IIf(IsDBNull(dRegistro("infona")), 0, dRegistro("infona")) + _
                    IIf(IsDBNull(dRegistro("impest")), 0, dRegistro("impest"))
                dRegistro("total_obrero") = IIf(IsDBNull(dRegistro("IMSSOBR")), 0, dRegistro("IMSSOBR")) + IIf(IsDBNull(dRegistro("subtotal_rcv_obrero")), 0, dRegistro("subtotal_rcv_obrero"))
                dRegistro("gran_total") = IIf(IsDBNull(dRegistro("total_patron")), 0, dRegistro("total_patron")) + IIf(IsDBNull(dRegistro("total_obrero")), 0, dRegistro("total_obrero"))

                dRegistro("total_imp") = IIf(IsDBNull(dRegistro("vacpag")), 0, dRegistro("vacpag")) + _
                    IIf(IsDBNull(dRegistro("pripag")), 0, dRegistro("pripag")) + _
                    IIf(IsDBNull(dRegistro("agupag")), 0, dRegistro("agupag")) + _
                    IIf(IsDBNull(dRegistro("total_patron")), 0, dRegistro("total_patron"))
                dRegistro("total_sueldo_impuesto") = IIf(IsDBNull(dRegistro("mensual")), 0, dRegistro("mensual")) + _
                    IIf(IsDBNull(dRegistro("total_imp")), 0, dRegistro("total_imp"))
                dRegistro("markup") = Math.Round(IIf(IsDBNull(dRegistro("total_sueldo_impuesto")), 0, dRegistro("total_sueldo_impuesto")) * Markup, 2)
                dRegistro("total_servicio") = dRegistro("total_sueldo_impuesto")

                dtTemporal = sqlExecute("SELECT horas FROM turnos WHERE cod_turno = '" & dRegistro("cod_turno") & "'")
                If dtTemporal.Rows.Count = 0 Then
                    horas = 45
                Else
                    horas = IIf(IsDBNull(dtTemporal.Rows(0).Item("horas")), 45, dtTemporal.Rows(0).Item("horas"))
                End If

                dRegistro("costo_por_hora_con_impuesto") = IIf(IsDBNull(dRegistro("total_servicio")), 0, dRegistro("total_servicio")) / 30.4 * 7 / horas
                dRegistro("costo_por_hora_sin_impuesto") = IIf(IsDBNull(dRegistro("mensual")), 0, dRegistro("mensual")) * (1 + Markup) / 30.4 * 7 / horas
            Next
            Return Nothing
        Catch ex As Exception
            Return ex
        End Try

    End Function

    Private Function PrenominaHoras(ByVal Cia As String, ByVal Ano As String, ByVal Periodo As String) As Exception
        Dim dtAsist As New DataTable
        Dim dtTurno As New DataTable
        Try
            dtDatosPrenomina = New DataTable
            dtDatosPrenomina = sqlExecute("SELECT reloj,nombres,cod_clase,cod_turno,cod_depto,horas_normales,horas_festivas,horas_dobles,horas_triples,horas_dobles+horas_triples AS horas_extras FROM nominaVW " & _
                                 "WHERE cod_comp = '" & Cia & "' AND ano = '" & Ano & "' AND periodo = '" & Periodo & "'", "nomina")
            dtDatosPrenomina.Columns.Add("semana")
            dtDatosPrenomina.Columns.Add("horas_factura")
            dtDatosPrenomina.Columns.Add("centro_costos")
            dtDatosPrenomina.Columns.Add("observaciones")
            dtDatosPrenomina.Columns.Add("lunes_nor", GetType(Double))
            dtDatosPrenomina.Columns.Add("martes_nor", GetType(Double))
            dtDatosPrenomina.Columns.Add("miercoles_nor", GetType(Double))
            dtDatosPrenomina.Columns.Add("jueves_nor", GetType(Double))
            dtDatosPrenomina.Columns.Add("viernes_nor", GetType(Double))
            dtDatosPrenomina.Columns.Add("sabado_nor", GetType(Double))
            dtDatosPrenomina.Columns.Add("domingo_nor", GetType(Double))
            dtDatosPrenomina.Columns.Add("lunes_ext", GetType(Double))
            dtDatosPrenomina.Columns.Add("martes_ext", GetType(Double))
            dtDatosPrenomina.Columns.Add("miercoles_ext", GetType(Double))
            dtDatosPrenomina.Columns.Add("jueves_ext", GetType(Double))
            dtDatosPrenomina.Columns.Add("viernes_ext", GetType(Double))
            dtDatosPrenomina.Columns.Add("sabado_ext", GetType(Double))
            dtDatosPrenomina.Columns.Add("domingo_ext", GetType(Double))
            dtDatosPrenomina.Columns.Add("lunes_aus", GetType(String))
            dtDatosPrenomina.Columns.Add("martes_aus", GetType(String))
            dtDatosPrenomina.Columns.Add("miercoles_aus", GetType(String))
            dtDatosPrenomina.Columns.Add("jueves_aus", GetType(String))
            dtDatosPrenomina.Columns.Add("viernes_aus", GetType(String))
            dtDatosPrenomina.Columns.Add("sabado_aus", GetType(String))
            dtDatosPrenomina.Columns.Add("domingo_aus", GetType(String))
            dtDatosPrenomina.Columns.Add("prima_dom", GetType(Double))
            dtDatosPrenomina.Columns.Add("extra_doble", GetType(Double))
            dtDatosPrenomina.Columns.Add("extra_triple", GetType(Double))
            dtDatosPrenomina.Columns.Add("total_extras", GetType(Double))
            dtDatosPrenomina.Columns.Add("ubicacion")
            dtDatosPrenomina.PrimaryKey = New DataColumn() {dtDatosPrenomina.Columns("reloj")}

            Dim _normales As Double
            Dim _extras As Double

            For Each Dato As DataRow In dtDatosPrenomina.Rows
                Dato("semana") = "Normal"
                Dato("centro_costos") = Dato("cod_depto")
                Dato("martes_nor") = 0
                Dato("lunes_nor") = 0
                Dato("miercoles_nor") = 0
                Dato("jueves_nor") = 0
                Dato("viernes_nor") = 0
                Dato("sabado_nor") = 0
                Dato("domingo_nor") = 0
                Dato("lunes_ext") = 0
                Dato("martes_ext") = 0
                Dato("miercoles_ext") = 0
                Dato("jueves_ext") = 0
                Dato("viernes_ext") = 0
                Dato("sabado_ext") = 0
                Dato("domingo_ext") = 0
                Dato("prima_dom") = 0
                Dato("extra_doble") = 0
                Dato("extra_triple") = 0
                Dato("total_extras") = 0

                dtAsist = sqlExecute("SELECT dia_entro,horas_normales,extras_autorizadas,ISNULL(ausentismo,0) as ausentismo,tipo_aus FROM asist WHERE ano = '" & Ano & "' AND periodo = '" & Periodo & "' AND reloj = '" & Dato("reloj") & "'", "TA")
                'Analizando horas diarias RELOJ & dato("reloj")
                For Each dDia As DataRow In dtAsist.Rows
                    _normales = HtoS(dDia("horas_normales")) / 3600
                    _extras = HtoS(dDia("extras_autorizadas")) / 3600
                    If dDia("ausentismo") = 0 Then
                        Select Case dDia("dia_entro").ToString.Substring(0, 2).ToUpper
                            Case "LU"
                                Dato("lunes_nor") += _normales
                                Dato("lunes_ext") += _extras
                            Case "MA"
                                Dato("martes_nor") += _normales
                                Dato("martes_ext") += _extras
                            Case "MI"
                                Dato("miercoles_nor") += _normales
                                Dato("miercoles_ext") += _extras
                            Case "JU"
                                Dato("jueves_nor") += _normales
                                Dato("jueves_ext") += _extras
                            Case "VI"
                                Dato("viernes_nor") += _normales
                                Dato("viernes_ext") += _extras
                            Case "SA"
                                Dato("sabado_nor") += _normales
                                Dato("sabado_ext") += _extras
                            Case "DO"
                                Dato("domingo_nor") += _normales
                                Dato("domingo_ext") += _extras
                        End Select
                    Else
                        Select Case dDia("dia_entro").ToString.Substring(0, 2).ToUpper
                            Case "LU"
                                Dato("lunes_aus") = dDia("tipo_aus")
                                Dato("lunes_ext") += _extras
                            Case "MA"
                                Dato("martes_aus") = dDia("tipo_aus")
                                Dato("martes_ext") += _extras
                            Case "MI"
                                Dato("miercoles_aus") = dDia("tipo_aus")
                                Dato("miercoles_ext") += _extras
                            Case "JU"
                                Dato("jueves_aus") = dDia("tipo_aus")
                                Dato("jueves_ext") += _extras
                            Case "VI"
                                Dato("viernes_aus") = dDia("tipo_aus")
                                Dato("viernes_ext") += _extras
                            Case "SA"
                                Dato("sabado_aus") = dDia("tipo_aus")
                                Dato("sabado_ext") += _extras
                            Case "DO"
                                Dato("domingo_aus") = dDia("tipo_aus")
                                Dato("domingo_ext") += _extras
                        End Select
                    End If
                Next
                Dato("prima_dom") = IIf(Dato("domingo_nor") + Dato("domingo_ext") > 0, IIf(Dato("cod_clase") = "D", 0.55, 0.78), 0)
                Dato("horas_normales") = Dato("horas_normales") + Dato("horas_festivas")
                dtTurno = sqlExecute("SELECT horas FROM turnos WHERE cod_turno = '" & Dato("cod_turno") & "'")
                If dtTurno.Rows.Count = 0 Then
                    Dato("horas_factura") = Dato("horas_normales")
                Else
                    Dato("horas_factura") = Dato("horas_normales") * 45 / IIf(IsDBNull(dtTurno.Rows(0).Item("horas")), 45, dtTurno.Rows(0).Item("horas"))
                End If
            Next
            Return Nothing
        Catch ex As Exception
            Return ex
        End Try

    End Function

    Private Function CalculoCostoHoraExtra(ByVal Cia As String, ByVal Ano As String, ByVal Periodo As String) As Exception
        Dim dtPuesto As New DataTable
        Try
            'NO SE INCLUYE EL MARKUP EN EL COSTO DE LAS HORAS EXTRAS
            dtDatosCostoExtra = sqlExecute("SELECT reloj,nombres,cod_turno,sactual AS sueldo_diario FROM nominaVW " & _
                                           "WHERE cod_comp = '" & Cia & "' AND ano = '" & Ano & "' AND periodo = '" & Periodo & "'", "nomina")
            dtDatosCostoExtra.Columns.Add("factor_por_turno", GetType(Double))
            dtDatosCostoExtra.Columns.Add("impuesto_doble", GetType(Double))
            dtDatosCostoExtra.Columns.Add("impuesto_triple", GetType(Double))
            dtDatosCostoExtra.Columns.Add("subtotal_doble", GetType(Double))
            dtDatosCostoExtra.Columns.Add("subtotal_triple", GetType(Double))
            dtDatosCostoExtra.Columns.Add("markup_doble", GetType(Double))
            dtDatosCostoExtra.Columns.Add("markup_triple", GetType(Double))
            dtDatosCostoExtra.Columns.Add("total_doble", GetType(Double))
            dtDatosCostoExtra.Columns.Add("total_triple", GetType(Double))
            dtDatosCostoExtra.Columns.Add("total_extra_integrable", GetType(Double))
            dtDatosCostoExtra.Columns.Add("costo_hora_doble", GetType(Double))
            dtDatosCostoExtra.Columns.Add("costo_hora_triple", GetType(Double))
            dtDatosCostoExtra.Columns.Add("costo_hora_extra_integrable", GetType(Double))
            dtDatosCostoExtra.PrimaryKey = New DataColumn() {dtDatosCostoExtra.Columns("reloj")}

            For Each Dato As DataRow In dtDatosCostoExtra.Rows
                Select Case Dato("cod_turno").ToString.Trim
                    Case "1"
                        Dato("factor_por_turno") = 7.5
                    Case "2"
                        Dato("factor_por_turno") = 7.0
                    Case "3"
                        Dato("factor_por_turno") = 5.5
                    Case Else
                        Dato("factor_por_turno") = 7.5
                End Select
                Dato("impuesto_doble") = Dato("sueldo_diario") * 0.02
                Dato("impuesto_triple") = Dato("sueldo_diario") * 0.203484
                Dato("subtotal_doble") = Dato("sueldo_diario") + Dato("impuesto_doble")
                Dato("subtotal_triple") = Dato("sueldo_diario") + Dato("impuesto_triple")
                Dato("total_doble") = Dato("subtotal_doble")
                Dato("total_triple") = Dato("subtotal_triple")
                Dato("total_extra_integrable") = Dato("sueldo_diario") + Dato("impuesto_triple")
                Dato("costo_hora_doble") = Dato("total_doble") / Dato("factor_por_turno") * 2
                Dato("costo_hora_triple") = Dato("total_triple") / Dato("factor_por_turno") * 3
                Dato("costo_hora_extra_integrable") = Dato("total_extra_integrable") / Dato("factor_por_turno") * 2
            Next
            Return Nothing
        Catch ex As Exception
            Return ex
        End Try
    End Function

    Private Sub btnBase_Click(sender As Object, e As EventArgs) Handles btnBase.Click
        Try
            Dim Sep As Integer
            'Buscar la última diagonal, para tomar nombre de archivo
            Sep = txtBase.Text.LastIndexOf("\")
            If Sep > 0 Then
                'Si se encontró diagonal, tomar los caracteres antes, para el nombre de la carpeta
                dlgArchivo.InitialDirectory = txtBase.Text.Substring(0, Sep)
                'tomar los caracteres después, para el nombre del archivo
                dlgArchivo.FileName = txtBase.Text.Substring(Sep + 1).Trim
            Else
                dlgArchivo.FileName = ""
            End If
            'No permitir seleccionar varios archivos
            dlgArchivo.Multiselect = False
            'Filtrar solo archivos de texto
            dlgArchivo.Filter = "Archivos Excel|*.xlsx;*.xls|Todos los archivos (*.*)|*.*"

            'Mostrar pantalla de "Open", y el resultado asignarlo a la variable
            Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()

            'Si se seleccionó Aceptar, tomar nombre de archivo y mostrarlo en textbox
            If lDialogResult = Windows.Forms.DialogResult.OK Then
                txtBase.Text = dlgArchivo.FileName
                txtBase.Focus()
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnFactura_Click(sender As Object, e As EventArgs) Handles btnFactura.Click
        Try
            Dim Sep As Integer
            'Buscar la última diagonal, para tomar nombre de archivo
            Sep = txtBase.Text.LastIndexOf("\")
            If Sep > 0 Then
                'Si se encontró diagonal, tomar los caracteres antes, para el nombre de la carpeta
                dlgGuardar.InitialDirectory = txtBase.Text.Substring(0, Sep)
                'tomar los caracteres después, para el nombre del archivo
                dlgGuardar.FileName = txtBase.Text.Substring(Sep + 1).Trim
            Else
                dlgGuardar.FileName = ""
            End If
            'Filtrar solo archivos de texto
            dlgGuardar.Filter = "Archivos Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*"

            'Mostrar pantalla de "Open", y el resultado asignarlo a la variable
            Dim lDialogResult As DialogResult = dlgGuardar.ShowDialog()

            'Si se seleccionó Aceptar, tomar nombre de archivo y mostrarlo en textbox
            If lDialogResult = Windows.Forms.DialogResult.OK Then
                txtFactura.Text = dlgGuardar.FileName
                txtFactura.Focus()
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbCia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCia.SelectedValueChanged
        Try
            dtUbicacion = sqlExecute("SELECT TOP 1 * FROM base_facturacion WHERE cod_comp = '" & cmbCia.SelectedValue & "'", "nomina")
            If dtUbicacion.Rows.Count = 0 Then
                sqlExecute("INSERT INTO base_facturacion (cod_comp) VALUES ('" & cmbCia.SelectedValue & "')", "nomina")
            End If
            txtBase.Text = IIf(IsDBNull(dtUbicacion.Rows(0).Item("excel_base")), "", dtUbicacion.Rows(0).Item("excel_base").ToString.Trim)
            txtFactura.Text = IIf(IsDBNull(dtUbicacion.Rows(0).Item("excel_factura")), "", dtUbicacion.Rows(0).Item("excel_factura").ToString.Trim)
        Catch ex As Exception
            txtBase.Text = ""
            txtFactura.Text = ""
        End Try
    End Sub
    Private Function CalculoHorasFinal(ByVal Cia As String, ByVal Ano As String, ByVal Periodo As String) As Exception
        Dim Markup As Double
        Dim Contador As Integer
        Dim dHoras As DataRow
        Try
            dtTemporal = sqlExecute("SELECT porcentaje_markup FROM cias WHERE cod_comp = '" & Cia & "'")
            Markup = IIf(IsDBNull(dtTemporal.Rows(0).Item(0)), 5, dtTemporal.Rows(0).Item(0))
            Markup = Markup / 100

            dtDatosCostoFinal = New DataTable
            dtDatosCostoFinal = sqlExecute("SELECT reloj,nombres,nombre_puesto as puesto,cod_turno as turno,sactual as sueldo_diario," & _
                                           "horas_normales,horas_festivas,horas_dobles,horas_triples " & _
                                           "FROM nominaVW WHERE " & _
                                           "cod_comp = '" & Cia & "' AND ano = '" & Ano & "' AND periodo = '" & Periodo & "'", "nomina")

            dtDatosCostoFinal.Columns.Add("consecutivo", GetType(Integer))
            dtDatosCostoFinal.Columns.Add("costo_horas_normales", GetType(Double))
            dtDatosCostoFinal.Columns.Add("subtotal_normales", GetType(Double))
            dtDatosCostoFinal.Columns.Add("costo_hora_doble", GetType(Double))
            dtDatosCostoFinal.Columns.Add("subtotal_dobles", GetType(Double))
            dtDatosCostoFinal.Columns.Add("horas_extras_integrables", GetType(Double))
            dtDatosCostoFinal.Columns.Add("costo_hora_extra_integrable", GetType(Double))
            dtDatosCostoFinal.Columns.Add("subtotal_extra_integrable", GetType(Double))
            dtDatosCostoFinal.Columns.Add("costo_hora_triple", GetType(Double))
            dtDatosCostoFinal.Columns.Add("subtotal_triples", GetType(Double))
            dtDatosCostoFinal.Columns.Add("subtotal_tiempo_extra", GetType(Double))
            dtDatosCostoFinal.Columns.Add("horas_domingo", GetType(Double))
            dtDatosCostoFinal.Columns.Add("subtotal_domingo", GetType(Double))
            dtDatosCostoFinal.Columns.Add("markup", GetType(Double))
            dtDatosCostoFinal.Columns.Add("total", GetType(Double))

            Contador = 1
            Dim DobleInt As Double
            Dim ExtrasNoInt As Double

            For Each dReg As DataRow In dtDatosCostoFinal.Rows
                dtTemporal = sqlExecute("SELECT monto FROM movimientos WHERE ano = '" & Ano & "' AND periodo = '" & Periodo & "' AND " & _
                                        "reloj = '" & dReg("reloj") & "' AND concepto = 'HRSDIN'", "nomina")
                If dtTemporal.Rows.Count = 0 Then
                    DobleInt = 0
                Else
                    DobleInt = dtTemporal.Rows(0).Item("monto")
                End If
                ExtrasNoInt = dReg("horas_dobles") - DobleInt

                dReg("consecutivo") = Contador

                dHoras = dtDatosCostoExtra.Rows.Find("reloj = '" & dReg("reloj"))
                If Not dHoras Is Nothing Then
                    dReg("costo_horas_normales") = IIf(IsDBNull(dHoras("costo_por_hora_con_impuesto")), 0, dHoras("costo_por_hora_con_impuesto"))
                    dReg("subtotal_normales") = IIf(IsDBNull(dHoras("costo_por_hora_con_impuesto")), 0, dHoras("costo_por_hora_con_impuesto")) * _
                        IIf(IsDBNull(dReg("horas_normales")), 0, dReg("horas_normales"))

                    dReg("horas_dobles") = ExtrasNoInt
                    dReg("costo_hora_doble") = IIf(IsDBNull(dHoras("costo_hora_doble")), 0, dHoras("costo_hora_doble"))
                    dReg("subtotal_dobles") = dReg("costo_hora_doble") * dReg("horas_dobles")

                    dReg("horas_extras_integrables") = DobleInt
                    dReg("costo_hora_extra_integrable") = IIf(IsDBNull(dHoras("costo_hora_extra_integrable")), 0, dHoras("costo_hora_extra_integrable"))
                    dReg("subtotal_extra_integrable") = dReg("costo_hora_extra_integrable") * dReg("horas_extras_integrables")

                    dReg("costo_hora_triple") = IIf(IsDBNull(dHoras("costo_hora_triple")), 0, dHoras("costo_hora_triple"))
                    dReg("subtotal_extra_integrable") = dReg("costo_hora_triple") * dReg("horas_triples")

                    dReg("subtotal_tiempo_extra") = dReg("subtotal_dobles") + dReg("subtotal_extra_integrable") + dReg("subtotal_triples")
                    dReg("markup") = (dReg("subtotal_normales") + dReg("subtotal_tiempo_extra")) * Markup
                    dReg("total") = dReg("subtotal_normales") + dReg("subtotal_tiempo_extra") + dReg("markup")
                End If

                Contador += 1
            Next

            Return Nothing
        Catch ex As Exception
            Return ex
        End Try

    End Function
End Class