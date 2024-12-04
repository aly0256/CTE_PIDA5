Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Module LibreriasNomina

    '------------Almacenar en movimientos_pro al calcular la nómina
    Public Function puente(ByVal _anio As String, ByVal _periodo As String, ByVal _reloj As String, ByVal _monto As Double, ByVal _tipo_nom As String, ByVal _tipo_per As String, ByVal _concepto As String, ByVal _dtConceptos As DataTable) As Integer
        Try
            '--Validar si el concepto esa activo
            Dim ACTIVO As Integer = 0
            Dim SUMA_NETO As Integer = 0
            Dim COD_NATURALEZA As String = ""
            Dim PRIORIDAD As Integer = 0
            Dim IMPORTAR As Integer = 0
            Dim concepto_saldo As String = ""
            Dim saldo_tmp As Double = 0.0

            Dim drowConcepto As DataRow = Nothing
            Try : drowConcepto = _dtConceptos.Select("concepto='" & _concepto & "'")(0) : Catch ex As Exception : drowConcepto = Nothing : End Try

            If (IsNothing(drowConcepto)) Then ' Si no lo encontró, agregar dicho concepto y mandar alerta
                Dim QInsertConc As String = "Insert into conceptos (cod_tipo_nomina,cod_naturaleza,concepto,nombre,prioridad,activo) VALUES " & _
                    "('" & _tipo_nom & "','I','" & _concepto & "','Concepto nuevo','999',1)"
                sqlExecute(QInsertConc, "NOMINA")
                MessageBox.Show("Se ha dado de alta el concepto:" & _concepto.Trim & ", favor de actualizar campos en la tabla CONCEPTOS", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If (Not IsNothing(drowConcepto)) Then ' Si lo encontró
                Try : ACTIVO = drowConcepto("ACTIVO") : Catch ex As Exception : ACTIVO = 0 : End Try
                Try : SUMA_NETO = drowConcepto("SUMA_NETO") : Catch ex As Exception : SUMA_NETO = 0 : End Try
                Try : COD_NATURALEZA = drowConcepto("COD_NATURALEZA").ToString.Trim : Catch ex As Exception : COD_NATURALEZA = "" : End Try
                Try : PRIORIDAD = drowConcepto("PRIORIDAD") : Catch ex As Exception : PRIORIDAD = 0 : End Try
                Try : IMPORTAR = drowConcepto("IMPORTAR") : Catch ex As Exception : IMPORTAR = 0 : End Try
                Try : concepto_saldo = drowConcepto("concepto_saldo").ToString.Trim : Catch ex As Exception : concepto_saldo = "" : End Try
            End If

            _monto = Math.Round(_monto, 2)

            If ACTIVO = 0 Then _monto = 0.0

            '---Ir acumulando el neto para cada concepto, solo si suma al neto
            If SUMA_NETO = 1 Then
                Select Case COD_NATURALEZA
                    Case "P"
                        acum_neto = acum_neto + _monto
                        acum_percep = acum_percep + _monto
                    Case "D"
                        acum_deduc = acum_deduc + _monto
                        If ((acum_neto >= _monto) And (acum_neto > 0)) Then
                            acum_neto = acum_neto - _monto
                            GoTo Salir
                        End If

                        If ((acum_neto < _monto) And (acum_neto > 0)) Then
                            _monto = acum_neto
                            acum_neto = acum_neto - _monto
                            GoTo Salir
                        End If

                        If ((acum_neto < _monto) And (acum_neto <= 0)) Then
                            _monto = 0.0
                            acum_neto = 0.0
                            GoTo Salir
                        End If
salir:
                End Select
            End If

            '---Incluir saldos
            If (concepto_saldo <> "") Then
                '-- Buscar en ajustesPro si viene un valor
                Dim dtBuscaSaldo As DataTable = sqlExecute("select * from ajustes_pro where reloj='" & _reloj & "' and concepto='" & _concepto & "'", "NOMINA")
                If (Not dtBuscaSaldo.Columns.Contains("Error") And dtBuscaSaldo.Rows.Count > 0) Then
                    Try : saldo_tmp = Double.Parse(dtBuscaSaldo.Rows(0).Item("saldo")) - _monto : Catch ex As Exception : saldo_tmp = 0.0 : End Try
                End If
            End If


            '--Agregarlo en movimientos_pro
            If ((_monto <> 0 Or _concepto = "NETO" Or _concepto = "TOTPER" Or _concepto = "TOTDED") And ACTIVO = 1) Then
                If existsMovsPro(_anio, _periodo, _reloj, _concepto) = 0 Then  ' Si no existe, agregarlo  PEND: Faltaria buscarlo por tipo de nom ??
                    If (InsertMovsPro(_anio, _periodo, _reloj, _tipo_nom, _tipo_per, _concepto, _monto, PRIORIDAD, IMPORTAR) = 0) Then
                        MessageBox.Show("No se agregó  en movimientos_pro el empleado con número:" & _reloj & ", concepto:" & _concepto & ", monto:" & _monto & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Else ' Si ya existe dicho movimiento, solo actualizarlo
                    If (UpdateMovsPro(_anio, _periodo, _reloj, _tipo_nom, _tipo_per, _concepto, _monto, PRIORIDAD, IMPORTAR) = 0) Then
                        MessageBox.Show("No se pudo actualizar  en movimientos_pro el empleado con número:" & _reloj & ", concepto:" & _concepto & ", monto:" & _monto & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If
            End If

            '--Incluir ese saldo
            If (saldo_tmp <> 0) Then
                If existsMovsPro(_anio, _periodo, _reloj, concepto_saldo) = 0 Then ' Si no existe dicho mov, agregarlo
                    If (InsertMovsPro(_anio, _periodo, _reloj, _tipo_nom, _tipo_per, concepto_saldo, saldo_tmp, PRIORIDAD, IMPORTAR) = 0) Then
                        MessageBox.Show("No se agregó  en movimientos_pro el empleado con número:" & _reloj & ", concepto:" & concepto_saldo & ", monto:" & saldo_tmp & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else ' Si ya existe dicho movimiento, solo actualizarlo
                    If (UpdateMovsPro(_anio, _periodo, _reloj, _tipo_nom, _tipo_per, concepto_saldo, saldo_tmp, PRIORIDAD, IMPORTAR) = 0) Then
                        MessageBox.Show("No se pudo actualizar  en movimientos_pro el empleado con número:" & _reloj & ", concepto:" & concepto_saldo & ", monto:" & saldo_tmp & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    '------------Almacenar en movimientos_calculo al calcular el finiquito
    Public Function puente_finiquito(ByVal _anio As String, ByVal _periodo As String, ByVal _reloj As String, ByVal _folio As String, ByVal _monto As Double, ByVal _tipo_nom As String, ByVal _tipo_per As String, ByVal _concepto As String, ByVal _dtConceptos As DataTable) As Integer
        Try
            '--Validar si el concepto esa activo
            Dim ACTIVO As Integer = 0
            Dim SUMA_NETO As Integer = 0
            Dim COD_NATURALEZA As String = ""
            Dim PRIORIDAD As Integer = 0
            Dim IMPORTAR As Integer = 0
            Dim concepto_saldo As String = ""
            Dim saldo_tmp As Double = 0.0

            Dim drowConcepto As DataRow = Nothing
            Try : drowConcepto = _dtConceptos.Select("concepto='" & _concepto & "'")(0) : Catch ex As Exception : drowConcepto = Nothing : End Try

            If (IsNothing(drowConcepto)) Then ' Si no lo encontró, agregar dicho concepto y mandar alerta
                Dim QInsertConc As String = "Insert into conceptos (cod_tipo_nomina,cod_naturaleza,concepto,nombre,prioridad,activo) VALUES " & _
                    "('" & _tipo_nom & "','I','" & _concepto & "','Concepto nuevo','999',1)"
                sqlExecute(QInsertConc, "NOMINA")
                MessageBox.Show("Se ha dado de alta el concepto:" & _concepto.Trim & ", favor de actualizar campos en la tabla CONCEPTOS", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If (Not IsNothing(drowConcepto)) Then ' Si lo encontró
                Try : ACTIVO = drowConcepto("ACTIVO") : Catch ex As Exception : ACTIVO = 0 : End Try
                Try : SUMA_NETO = drowConcepto("SUMA_NETO") : Catch ex As Exception : SUMA_NETO = 0 : End Try
                Try : COD_NATURALEZA = drowConcepto("COD_NATURALEZA").ToString.Trim : Catch ex As Exception : COD_NATURALEZA = "" : End Try
                Try : PRIORIDAD = drowConcepto("PRIORIDAD") : Catch ex As Exception : PRIORIDAD = 0 : End Try
                Try : IMPORTAR = drowConcepto("IMPORTAR") : Catch ex As Exception : IMPORTAR = 0 : End Try
                Try : concepto_saldo = drowConcepto("concepto_saldo").ToString.Trim : Catch ex As Exception : concepto_saldo = "" : End Try
            End If

            _monto = Math.Round(_monto, 2)

            If ACTIVO = 0 Then _monto = 0.0

            '---Ir acumulando el neto para cada concepto, solo si suma al neto
            If SUMA_NETO = 1 Then
                Select Case COD_NATURALEZA
                    Case "P"
                        acum_neto = acum_neto + _monto
                        acum_percep = acum_percep + _monto
                    Case "D"
                        acum_deduc = acum_deduc + _monto
                        If ((acum_neto >= _monto) And (acum_neto > 0)) Then
                            acum_neto = acum_neto - _monto
                            GoTo Salir
                        End If

                        If ((acum_neto < _monto) And (acum_neto > 0)) Then
                            _monto = acum_neto
                            acum_neto = acum_neto - _monto
                            GoTo Salir
                        End If

                        If ((acum_neto < _monto) And (acum_neto <= 0)) Then
                            _monto = 0.0
                            acum_neto = 0.0
                            GoTo Salir
                        End If
salir:
                End Select
            End If

            '---Incluir saldos
            'If (concepto_saldo <> "") Then
            '    '-- Buscar en ajustesPro si viene un valor
            '    Dim dtBuscaSaldo As DataTable = sqlExecute("select * from ajustes_pro where reloj='" & _reloj & "' and concepto='" & _concepto & "'", "NOMINA")
            '    If (Not dtBuscaSaldo.Columns.Contains("Error") And dtBuscaSaldo.Rows.Count > 0) Then
            '        Try : saldo_tmp = Double.Parse(dtBuscaSaldo.Rows(0).Item("saldo")) - _monto : Catch ex As Exception : saldo_tmp = 0.0 : End Try
            '    End If
            'End If


            '--Agregarlo en movimientos_calculo
            If ((_monto <> 0 Or _concepto = "NETO" Or _concepto = "TOTPER" Or _concepto = "TOTDED") And ACTIVO = 1) Then
                If existsMovsCalc(_anio, _periodo, _reloj, _folio, _concepto) = 0 Then  ' Si no existe, agregarlo  PEND: Faltaria buscarlo por tipo de nom ??
                    If (InsertMovsCalc(_anio, _periodo, _reloj, _folio, _tipo_nom, _tipo_per, _concepto, _monto, PRIORIDAD, IMPORTAR) = 0) Then
                        MessageBox.Show("No se agregó  en movimientos_calculo el empleado con número:" & _reloj & ", concepto:" & _concepto & ", monto:" & _monto & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Else ' Si ya existe dicho movimiento, solo actualizarlo
                    If (UpdateMovsCalc(_anio, _periodo, _reloj, _folio, _tipo_nom, _tipo_per, _concepto, _monto, PRIORIDAD, IMPORTAR) = 0) Then
                        MessageBox.Show("No se pudo actualizar  en movimientos_calculo el empleado con número:" & _reloj & ", concepto:" & _concepto & ", monto:" & _monto & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If
            End If

            '--Incluir ese saldo
            'If (saldo_tmp <> 0) Then
            '    If existsMovsCalc(_anio, _periodo, _reloj, concepto_saldo) = 0 Then ' Si no existe dicho mov, agregarlo
            '        If (InsertMovsCalc(_anio, _periodo, _reloj, _tipo_nom, _tipo_per, concepto_saldo, saldo_tmp, PRIORIDAD, IMPORTAR) = 0) Then
            '            MessageBox.Show("No se agregó  en movimientos_pro el empleado con número:" & _reloj & ", concepto:" & concepto_saldo & ", monto:" & saldo_tmp & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        End If
            '    Else ' Si ya existe dicho movimiento, solo actualizarlo
            '        If (UpdateMovsCalc(_anio, _periodo, _reloj, _tipo_nom, _tipo_per, concepto_saldo, saldo_tmp, PRIORIDAD, IMPORTAR) = 0) Then
            '            MessageBox.Show("No se pudo actualizar  en movimientos_pro el empleado con número:" & _reloj & ", concepto:" & concepto_saldo & ", monto:" & saldo_tmp & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        End If
            '    End If
            'End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function existsMovsCalc(ByRef an As String, per As String, rj As String, fol As String, conc As String) As Integer ' PEND: Faltaria buscarlo por tipo de nom ??
        Dim existe As Integer = 1
        Try
            Dim anioPer As String = an & per
            Dim qBusca As String = "select * from movimientos_calculo where ano+periodo='" & anioPer & "' and reloj='" & rj & "' and folio = '" & fol & "' and concepto='" & conc & "'"
            Dim dtBuscaMovsPro As DataTable = sqlExecute(qBusca, "NOMINA")

            If (Not dtBuscaMovsPro.Columns.Contains("Error") And dtBuscaMovsPro.Rows.Count = 0) Then existe = 0

            Return existe

        Catch ex As Exception
            Return existe
        End Try
    End Function

    Public Function InsertMovsCalc(ByRef an As String, per As String, rj As String, fol As String, tnom As String, tPer As String, conc As String, mto As Double, prio As Integer, imp As Integer) As Integer
        Dim insertado As Integer = 0
        Dim RowsInsert As Integer = 0
        Try
            'Dim qInsert As String = "insert into movimientos_pro (ano,periodo,reloj,tipo_nomina,tipo_periodo,concepto,monto,prioridad,importar) " & _
            '    "values ('" & an & "','" & per & "','" & rj & "','" & tnom & "','" & tPer & "','" & conc & "'," & mto & "," & prio & "," & imp & ")"

            Dim qInsert As String = "insert into movimientos_calculo (ano,periodo,folio,reloj,tipo_nomina,concepto,monto,prioridad) " & _
            "values ('" & an & "','" & per & "','" & fol & "','" & rj & "','" & tnom & "','" & conc & "'," & mto & "," & prio & ")"

            Dim dtRowsCount As DataTable = sqlExecute(qInsert & " select @@ROWCOUNT as 'RowsInsert'", "NOMINA")
            Try : RowsInsert = Convert.ToInt32(dtRowsCount.Rows(0).Item("RowsInsert").ToString.Trim) : Catch ex As Exception : RowsInsert = 0 : End Try
            If (RowsInsert > 0) Then insertado = 1
            Return insertado
        Catch ex As Exception
            Return insertado
        End Try
    End Function
    Public Function UpdateMovsCalc(ByRef an As String, per As String, rj As String, fol As String, tnom As String, tPer As String, conc As String, mto As Double, prio As Integer, imp As Integer) As Integer
        Dim Actualizado As Integer = 0
        Dim RowsUpdate As Integer = 0
        Try
            'Dim qUpdate As String = "update movimientos_calculo set monto=" & mto & ",prioridad=" & prio & ",importar=" & prio & _
            '                        " where reloj='" & rj & "' and folio = '" & fol & "' and concepto='" & conc & "'"

            Dim qUpdate As String = "update movimientos_calculo set monto=" & mto & ",prioridad=" & prio & _
                                 " where reloj='" & rj & "' and folio = '" & fol & "' and concepto='" & conc & "'"

            Dim dtRowsCount As DataTable = sqlExecute(qUpdate & " select @@ROWCOUNT as 'RowsUpdate'", "NOMINA")
            Try : RowsUpdate = Convert.ToInt32(dtRowsCount.Rows(0).Item("RowsUpdate").ToString.Trim) : Catch ex As Exception : RowsUpdate = 0 : End Try
            If (RowsUpdate > 0) Then Actualizado = 1
            Return Actualizado
        Catch ex As Exception
            Return Actualizado
        End Try
    End Function

    Public Function CalcISRSEP(ByVal _sueldo_mensual As Double, ByVal _tabla As String, ByVal _tipo_per As String) As Double

        Dim lim_inf As Double = 0.0
        Dim cta_fija As Double = 0.0
        Dim porcentaje As Double = 0.0
        Dim exedente As Double = 0.0
        Dim imp_marginal As Double = 0.0
        Dim isr_mensual As Double = 0.0
        Dim Res As Double = 0.0


        Try
            Dim Qbusca As String = "select top 1 * from tablas_isr where lim_inf <= " & _sueldo_mensual & " and periodo='" & _tipo_per & "' and tabla='" & _tabla & "' order by lim_inf desc"
            Dim dtBuscaIsr As DataTable = sqlExecute(Qbusca, "NOMINA")
            If (Not dtBuscaIsr.Columns.Contains("Error") And dtBuscaIsr.Rows.Count > 0) Then
                Try : lim_inf = Double.Parse(dtBuscaIsr.Rows(0).Item("lim_inf")) : Catch ex As Exception : lim_inf = 0.0 : End Try
                Try : cta_fija = Double.Parse(dtBuscaIsr.Rows(0).Item("cta_fija")) : Catch ex As Exception : cta_fija = 0.0 : End Try
                Try : porcentaje = Double.Parse(dtBuscaIsr.Rows(0).Item("porcentaje")) : Catch ex As Exception : porcentaje = 0.0 : End Try
                '  Try : subempleo = Double.Parse(dtBuscaIsr.Rows(0).Item("subempleo")) : Catch ex As Exception : subempleo = 0.0 : End Try
            End If

            exedente = _sueldo_mensual - lim_inf
            imp_marginal = exedente * porcentaje
            isr_mensual = imp_marginal + cta_fija

            Res = isr_mensual / _sueldo_mensual

            Return Res

        Catch ex As Exception
            Return Res
        End Try

    End Function

    Public Function existsMovsPro(ByRef an As String, per As String, rj As String, conc As String) As Integer ' PEND: Faltaria buscarlo por tipo de nom ??
        Dim existe As Integer = 1
        Try
            Dim anioPer As String = an & per
            Dim qBusca As String = "select * from movimientos_pro where ano+periodo='" & anioPer & "' and reloj='" & rj & "' and concepto='" & conc & "'"
            Dim dtBuscaMovsPro As DataTable = sqlExecute(qBusca, "NOMINA")

            If (Not dtBuscaMovsPro.Columns.Contains("Error") And dtBuscaMovsPro.Rows.Count = 0) Then existe = 0

            Return existe

        Catch ex As Exception
            Return existe
        End Try
    End Function

    Public Function InsertMovsPro(ByRef an As String, per As String, rj As String, tnom As String, tPer As String, conc As String, mto As Double, prio As Integer, imp As Integer) As Integer
        Dim insertado As Integer = 0
        Dim RowsInsert As Integer = 0
        Try
            Dim qInsert As String = "insert into movimientos_pro (ano,periodo,reloj,tipo_nomina,tipo_periodo,concepto,monto,prioridad,importar) " & _
                "values ('" & an & "','" & per & "','" & rj & "','" & tnom & "','" & tPer & "','" & conc & "'," & mto & "," & prio & "," & imp & ")"

            Dim dtRowsCount As DataTable = sqlExecute(qInsert & " select @@ROWCOUNT as 'RowsInsert'", "NOMINA")
            Try : RowsInsert = Convert.ToInt32(dtRowsCount.Rows(0).Item("RowsInsert").ToString.Trim) : Catch ex As Exception : RowsInsert = 0 : End Try
            If (RowsInsert > 0) Then insertado = 1
            Return insertado
        Catch ex As Exception
            Return insertado
        End Try
    End Function

    Public Function UpdateMovsPro(ByRef an As String, per As String, rj As String, tnom As String, tPer As String, conc As String, mto As Double, prio As Integer, imp As Integer) As Integer
        Dim Actualizado As Integer = 0
        Dim RowsUpdate As Integer = 0
        Try
            Dim qUpdate As String = "update movimientos_pro set monto=" & mto & ",prioridad=" & prio & ",importar=" & prio & _
                                    " where reloj='" & rj & "' and concepto='" & conc & "'"


            Dim dtRowsCount As DataTable = sqlExecute(qUpdate & " select @@ROWCOUNT as 'RowsUpdate'", "NOMINA")
            Try : RowsUpdate = Convert.ToInt32(dtRowsCount.Rows(0).Item("RowsUpdate").ToString.Trim) : Catch ex As Exception : RowsUpdate = 0 : End Try
            If (RowsUpdate > 0) Then Actualizado = 1
            Return Actualizado
        Catch ex As Exception
            Return Actualizado
        End Try
    End Function

    '----Funcion para aplicar subsidio una vez al mes
    Public Function CalcISR(ByRef _rj As String, _pergra As Double, tipo_per As String, _tabla As String, _dias_pagados As Double, _dtAjustesPro As DataTable, _aplica_ajsupe As Integer, _acum_per_gravada As Double) As Double ' Función para calcular el ISR y el Subsidio
        Dim Res As Double = 0.0
        If (_dias_pagados = 0 Or _pergra = 0) Then Return Res
        ' NORMAL y FINIQUITO
        Try
            Dim lim_inf As Double = 0.0
            Dim cta_fija As Double = 0.0
            Dim porcentaje As Double = 0.0
            Dim GravDiario As Double = _pergra / _dias_pagados
            Dim GravMens As Double = GravDiario * 30.4
            Dim exedente As Double = 0.0
            Dim imp_marginal As Double = 0.0
            Dim isr_mensual As Double = 0.0
            Dim subsidio_mensual As Double = 0.0


            Dim Qbusca As String = "select top 1 * from tablas_isr where lim_inf <= " & GravMens & " and periodo='" & tipo_per & "' and tabla='" & _tabla & "' order by lim_inf desc"
            Dim dtBuscaIsr As DataTable = sqlExecute(Qbusca, "NOMINA")
            If (Not dtBuscaIsr.Columns.Contains("Error") And dtBuscaIsr.Rows.Count > 0) Then
                Try : lim_inf = Double.Parse(dtBuscaIsr.Rows(0).Item("lim_inf")) : Catch ex As Exception : lim_inf = 0.0 : End Try
                Try : cta_fija = Double.Parse(dtBuscaIsr.Rows(0).Item("cta_fija")) : Catch ex As Exception : cta_fija = 0.0 : End Try
                Try : porcentaje = Double.Parse(dtBuscaIsr.Rows(0).Item("porcentaje")) : Catch ex As Exception : porcentaje = 0.0 : End Try
                '  Try : subempleo = Double.Parse(dtBuscaIsr.Rows(0).Item("subempleo")) : Catch ex As Exception : subempleo = 0.0 : End Try
            End If

            exedente = GravMens - lim_inf
            imp_marginal = exedente * porcentaje
            isr_mensual = imp_marginal + cta_fija

            '  subsidio_mensual = CalcSubempleo(GravMens, "M", "Sub") &&_ Originalmente asi es cada semana, pero en este caso se aplicará aj sub cada mes
            If _aplica_ajsupe = 1 Then subsidio_mensual = CalcSubempleo(_acum_per_gravada, "M", "Sub")

            isrCausado = (isr_mensual / 30.4) * _dias_pagados    ' ISPT Causado
            '   subempleoCausado = (subsidio_mensual / 30.4) * _dias_pagados ' Subsidio causado &&_ Se deshabilita debido a que se se aplicará solo una vez al mes

            If _aplica_ajsupe = 1 Then subempleoCausado = subsidio_mensual


            '--Buscar en ajustes_pro si hay valor para el isrCausado y el SubempleoCausado para sumarselo
            Dim drowIsrCaus As DataRow = Nothing
            Try : drowIsrCaus = _dtAjustesPro.Select("reloj='" & _rj & "' and concepto='ISPT'")(0) : Catch ex As Exception : drowIsrCaus = Nothing : End Try
            If (Not IsNothing(drowIsrCaus)) Then isrCausado += Double.Parse(drowIsrCaus("monto"))

            Dim drowSubCaus As DataRow = Nothing
            Try : drowSubCaus = _dtAjustesPro.Select("reloj='" & _rj & "' and concepto='SUBCAU'")(0) : Catch ex As Exception : drowSubCaus = Nothing : End Try
            If (Not IsNothing(drowSubCaus)) Then subempleoCausado += Double.Parse(drowSubCaus("monto"))

            If (isrCausado > subempleoCausado) Then isrRetenido = isrCausado - subempleoCausado
            If (isrCausado < subempleoCausado) Then subempleoPagado = subempleoCausado - isrCausado


            If (_aplica_ajsupe = 0) Then  ' Cuando no es aj al sub al mes, el isrRet = IsrCausado
                isrRetenido = isrCausado
            End If

            Res = isrRetenido

            Return Res
        Catch ex As Exception
            Return Res

        End Try
    End Function

    '---Funcion que aplica el subsidio cada semana
    'Public Function CalcISR(ByRef _rj As String, _pergra As Double, tipo_per As String, _tabla As String, _dias_pagados As Double, _dtAjustesPro As DataTable, _aplica_ajsupe As Integer, _acum_per_gravada As Double) As Double ' Función para calcular el ISR y el Subsidio
    '    Dim Res As Double = 0.0
    '    If (_dias_pagados = 0 Or _pergra = 0) Then Return Res

    '    Try
    '        Dim lim_inf As Double = 0.0
    '        Dim cta_fija As Double = 0.0
    '        Dim porcentaje As Double = 0.0
    '        Dim GravDiario As Double = _pergra / _dias_pagados
    '        Dim GravMens As Double = GravDiario * 30.4
    '        Dim exedente As Double = 0.0
    '        Dim imp_marginal As Double = 0.0
    '        Dim isr_mensual As Double = 0.0
    '        Dim subsidio_mensual As Double = 0.0


    '        Dim Qbusca As String = "select top 1 * from tablas_isr where lim_inf <= " & GravMens & " and periodo='" & tipo_per & "' and tabla='" & _tabla & "' order by lim_inf desc"
    '        Dim dtBuscaIsr As DataTable = sqlExecute(Qbusca, "NOMINA")
    '        If (Not dtBuscaIsr.Columns.Contains("Error") And dtBuscaIsr.Rows.Count > 0) Then
    '            Try : lim_inf = Double.Parse(dtBuscaIsr.Rows(0).Item("lim_inf")) : Catch ex As Exception : lim_inf = 0.0 : End Try
    '            Try : cta_fija = Double.Parse(dtBuscaIsr.Rows(0).Item("cta_fija")) : Catch ex As Exception : cta_fija = 0.0 : End Try
    '            Try : porcentaje = Double.Parse(dtBuscaIsr.Rows(0).Item("porcentaje")) : Catch ex As Exception : porcentaje = 0.0 : End Try
    '            '  Try : subempleo = Double.Parse(dtBuscaIsr.Rows(0).Item("subempleo")) : Catch ex As Exception : subempleo = 0.0 : End Try
    '        End If

    '        exedente = GravMens - lim_inf
    '        imp_marginal = exedente * porcentaje
    '        isr_mensual = imp_marginal + cta_fija

    '        subsidio_mensual = CalcSubempleo(GravMens, "M", "Sub")


    '        isrCausado = (isr_mensual / 30.4) * _dias_pagados    ' ISPT Causado
    '        subempleoCausado = (subsidio_mensual / 30.4) * _dias_pagados ' Subsidio causado &&_ Se deshabilita debido a que se se aplicará solo una vez al mes

    '        '--Buscar en ajustes_pro si hay valor para el isrCausado y el SubempleoCausado para sumarselo
    '        'Dim drowIsrCaus As DataRow = Nothing
    '        'Try : drowIsrCaus = _dtAjustesPro.Select("reloj='" & _rj & "' and concepto='ISPT'")(0) : Catch ex As Exception : drowIsrCaus = Nothing : End Try
    '        'If (Not IsNothing(drowIsrCaus)) Then isrCausado += Double.Parse(drowIsrCaus("monto"))

    '        'Dim drowSubCaus As DataRow = Nothing
    '        'Try : drowSubCaus = _dtAjustesPro.Select("reloj='" & _rj & "' and concepto='SUBCAU'")(0) : Catch ex As Exception : drowSubCaus = Nothing : End Try
    '        'If (Not IsNothing(drowSubCaus)) Then subempleoCausado += Double.Parse(drowSubCaus("monto"))

    '        If (isrCausado > subempleoCausado) Then isrRetenido = isrCausado - subempleoCausado
    '        If (isrCausado < subempleoCausado) Then subempleoPagado = subempleoCausado - isrCausado




    '        Res = isrRetenido

    '        Return Res
    '    Catch ex As Exception
    '        Return Res

    '    End Try
    'End Function

    Public Function CalcSubempleo(ByRef _gravado As Double, _tipo_per As String, _tabla As String) As Double
        Dim Res As Double = 0.0
        Try
            Dim qBusca As String = "select top 1 * from tablas_isr where lim_inf <= " & _gravado & " and periodo='" & _tipo_per & "' and tabla='" & _tabla & "' order by lim_inf desc"
            Dim dtBuscaSub As DataTable = sqlExecute(qBusca, "NOMINA")
            Dim _sub_empleo As Double = 0.0

            If (Not dtBuscaSub.Columns.Contains("Error") And dtBuscaSub.Rows.Count > 0) Then
                Try : _sub_empleo = Double.Parse(dtBuscaSub.Rows(0).Item("subempleo")) : Catch ex As Exception : _sub_empleo = 0.0 : End Try
            End If
            Res = _sub_empleo
            Return Res
        Catch ex As Exception
            Return Res
        End Try
    End Function

    Public Function Antiguedad_Empleado(Falta As Date, fFin As Date) As Integer
        Dim Res As Integer = 0
        Try
            Dim TotDias As Integer = 0
            Dim anios As Integer = 0
            TotDias = DateDiff(DateInterval.Day, Falta, fFin)
            anios = CInt(TotDias / 365)
            Res = anios
            Return Res
        Catch ex As Exception
            Return Res
        End Try
    End Function

    Public Function CalcImss(ByRef _anio As String, _periodo As String, _rj As String, _tipo_nom As String, _tipoPer As String, _topeIntegrado As Double, _diasPag As Double, _UMA As Double, _prima_riesgo As Double) As Double
        Dim Res As Double = 0.0
        If (_diasPag = 0) Then Return Res
        Try
            Dim IMSS As Double = 0.0
            Dim CtaFija As Double = 0.0
            Dim Base3Umas As Double = 0.0
            Dim Exe3UmasPat As Double = 0.0
            Dim Exe3UmasTrab As Double = 0.0
            Dim PrestaDinPat As Double = 0.0
            Dim PrestaDinTrab As Double = 0.0
            Dim GtosMedPensPat As Double = 0.0
            Dim GtosMedPensTrab As Double = 0.0
            Dim InvVidaPat As Double = 0.0
            Dim InvVidaTrab As Double = 0.0
            Dim GuardPat As Double = 0.0
            Dim RetiroPat As Double = 0.0
            Dim CesVejezPat As Double = 0.0
            Dim CesVejezTrab As Double = 0.0
            Dim RiesgoPat As Double = 0.0
            Dim InfoPat As Double = 0.0
            Dim TOTPAT As Double = 0.0
            Dim TOTASE As Double = 0.0

            '--Redondear los dias pagados al prox enterior, si es que cuenta con alguna fraccion, aunque sea ya con 5.1
            Dim _diasPagInt As Integer = CInt(_diasPag)
            If (_diasPagInt < _diasPag) Then _diasPag = _diasPagInt + 1 Else _diasPag = _diasPagInt



            '--Cuota Fija 
            CtaFija = _UMA * _diasPag * (20.4 / 100) ' Patrón
            If (CtaFija <> 0) Then puente_imss(_anio, _periodo, _rj, CtaFija, _tipo_nom, _tipoPer, "CUOFIJ")

            '--Exedente a 3 UMA'S
            If (_topeIntegrado > (3 * _UMA)) Then ' Solo entra si su integrado es mayor al valor de 3Umas
                Base3Umas = (_topeIntegrado - (3 * _UMA)) * _diasPag
                Exe3UmasPat = Base3Umas * (1.1 / 100)  ' Patrón
                Exe3UmasTrab = Base3Umas * (0.4 / 100) '- Trabajador
            End If

            '-insertar en movimientos_imss_pro
            If (Exe3UmasPat <> 0) Then puente_imss(_anio, _periodo, _rj, Exe3UmasPat, _tipo_nom, _tipoPer, "EXE3MP")
            If (Exe3UmasTrab <> 0) Then puente_imss(_anio, _periodo, _rj, Exe3UmasTrab, _tipo_nom, _tipoPer, "EXE3MA")

            '--Prestaciones en Dinero
            PrestaDinPat = _topeIntegrado * _diasPag * (0.7 / 100)
            PrestaDinTrab = _topeIntegrado * _diasPag * (0.25 / 100)
            If (PrestaDinPat <> 0) Then puente_imss(_anio, _periodo, _rj, PrestaDinPat, _tipo_nom, _tipoPer, "PREDIP")
            If (PrestaDinTrab <> 0) Then puente_imss(_anio, _periodo, _rj, PrestaDinTrab, _tipo_nom, _tipoPer, "PREDIA")

            '--Gastos médicos a pensionados
            GtosMedPensPat = _topeIntegrado * _diasPag * (1.05 / 100)
            GtosMedPensTrab = _topeIntegrado * _diasPag * (0.375 / 100)

            If (GtosMedPensPat <> 0) Then puente_imss(_anio, _periodo, _rj, GtosMedPensPat, _tipo_nom, _tipoPer, "GASMEP")
            If (GtosMedPensTrab <> 0) Then puente_imss(_anio, _periodo, _rj, GtosMedPensTrab, _tipo_nom, _tipoPer, "GASMEA")

            '--Invalidez y vida
            InvVidaPat = _topeIntegrado * _diasPag * (1.75 / 100)
            InvVidaTrab = _topeIntegrado * _diasPag * (0.625 / 100)

            If (InvVidaPat <> 0) Then puente_imss(_anio, _periodo, _rj, InvVidaPat, _tipo_nom, _tipoPer, "INVIDP")
            If (InvVidaTrab <> 0) Then puente_imss(_anio, _periodo, _rj, InvVidaTrab, _tipo_nom, _tipoPer, "INVIDA")

            '--Guardería
            GuardPat = _topeIntegrado * _diasPag * (1.0 / 100)
            If (GuardPat <> 0) Then puente_imss(_anio, _periodo, _rj, GuardPat, _tipo_nom, _tipoPer, "GUARDE")


            '--RETIRO
            RetiroPat = _topeIntegrado * _diasPag * (2.0 / 100)
            If (RetiroPat <> 0) Then puente_imss(_anio, _periodo, _rj, RetiroPat, _tipo_nom, _tipoPer, "RETIRO")

            '--Cesantía y Vejez
            CesVejezPat = _topeIntegrado * _diasPag * (3.15 / 100)
            CesVejezTrab = _topeIntegrado * _diasPag * (1.125 / 100)

            If (CesVejezPat <> 0) Then puente_imss(_anio, _periodo, _rj, CesVejezPat, _tipo_nom, _tipoPer, "CESVEP")
            If (CesVejezTrab <> 0) Then puente_imss(_anio, _periodo, _rj, CesVejezTrab, _tipo_nom, _tipoPer, "CESVEA")

            '--Riesgo
            RiesgoPat = _topeIntegrado * _diasPag * (_prima_riesgo / 100)
            If (RiesgoPat <> 0) Then puente_imss(_anio, _periodo, _rj, RiesgoPat, _tipo_nom, _tipoPer, "RIESGO")

            '--Infonavit
            InfoPat = _topeIntegrado * _diasPag * (5 / 100)
            If (InfoPat <> 0) Then puente_imss(_anio, _periodo, _rj, InfoPat, _tipo_nom, _tipoPer, "INFONP")

            '--TOTALES: 
            TOTPAT = CtaFija + Exe3UmasPat + PrestaDinPat + GtosMedPensPat + InvVidaPat + GuardPat + RetiroPat + CesVejezPat + RiesgoPat + InfoPat ' Total Patrón
            TOTASE = Exe3UmasTrab + PrestaDinTrab + GtosMedPensTrab + InvVidaTrab + CesVejezTrab ' Total asegurado

            If (TOTPAT <> 0) Then puente_imss(_anio, _periodo, _rj, TOTPAT, _tipo_nom, _tipoPer, "TOTPAT")
            If (TOTASE <> 0) Then puente_imss(_anio, _periodo, _rj, TOTASE, _tipo_nom, _tipoPer, "TOTASE")

            IMSS = TOTASE  ' El descuento real del trabajador

            Res = IMSS

            Return Res

        Catch ex As Exception
            Return Res
        End Try
    End Function

    Public Function puente_imss(ByRef anio As String, periodo As String, reloj As String, monto As Double, tipoNom As String, tipoPer As String, concepto As String) As Integer
        Try
            If (anio <> "" And periodo <> "" And reloj <> "" And concepto <> "") Then

                If existsMovsIMSSPro(anio, periodo, reloj, concepto) = 0 Then ' Si no existe, agregarlo
                    If (InsertMovsIMSSPro(anio, periodo, reloj, tipoNom, tipoPer, concepto, monto) = 0) Then
                        MessageBox.Show("No se agregó  en movimientos_imss_pro el empleado con número:" & reloj & ", concepto:" & concepto & ", monto:" & monto & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Else ' Si existe, actualizarlo

                    If (UpdateMovsIMSSPro(anio, periodo, reloj, tipoNom, tipoPer, concepto, monto) = 0) Then
                        MessageBox.Show("No se pudo actualizar  en movimientos_pro el empleado con número:" & reloj & ", concepto:" & concepto & ", monto:" & monto & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If


            End If
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Public Function existsMovsIMSSPro(ByRef an As String, per As String, rj As String, conc As String) As Integer
        Dim existe As Integer = 1
        Try
            Dim anioPer As String = an & per
            Dim qBusca As String = "select * from movimientos_imss_pro where ano+periodo='" & anioPer & "' and reloj='" & rj & "' and concepto='" & conc & "'"
            Dim dtBuscaMovsPro As DataTable = sqlExecute(qBusca, "NOMINA")

            If (Not dtBuscaMovsPro.Columns.Contains("Error") And dtBuscaMovsPro.Rows.Count = 0) Then existe = 0

            Return existe

        Catch ex As Exception
            Return existe
        End Try
    End Function

    Public Function InsertMovsIMSSPro(ByRef an As String, per As String, rj As String, tnom As String, tPer As String, conc As String, mto As Double) As Integer
        Dim insertado As Integer = 0
        Dim RowsInsert As Integer = 0
        Try
            Dim qInsert As String = "insert into movimientos_imss_pro (ano,periodo,reloj,tipo_nomina,tipo_periodo,concepto,monto) " & _
                "values ('" & an & "','" & per & "','" & rj & "','" & tnom & "','" & tPer & "','" & conc & "'," & mto & ")"

            Dim dtRowsCount As DataTable = sqlExecute(qInsert & " select @@ROWCOUNT as 'RowsInsert'", "NOMINA")
            Try : RowsInsert = Convert.ToInt32(dtRowsCount.Rows(0).Item("RowsInsert").ToString.Trim) : Catch ex As Exception : RowsInsert = 0 : End Try
            If (RowsInsert > 0) Then insertado = 1
            Return insertado
        Catch ex As Exception
            Return insertado
        End Try
    End Function

    Public Function UpdateMovsIMSSPro(ByRef an As String, per As String, rj As String, tnom As String, tPer As String, conc As String, mto As Double) As Integer
        Dim Actualizado As Integer = 0
        Dim RowsUpdate As Integer = 0
        Try
            Dim qUpdate As String = "update movimientos_imss_pro set monto=" & mto & _
                                    " where reloj='" & rj & "' and concepto='" & conc & "'"


            Dim dtRowsCount As DataTable = sqlExecute(qUpdate & " select @@ROWCOUNT as 'RowsUpdate'", "NOMINA")
            Try : RowsUpdate = Convert.ToInt32(dtRowsCount.Rows(0).Item("RowsUpdate").ToString.Trim) : Catch ex As Exception : RowsUpdate = 0 : End Try
            If (RowsUpdate > 0) Then Actualizado = 1
            Return Actualizado
        Catch ex As Exception
            Return Actualizado
        End Try
    End Function

    Public Function CalcInfonavit(ByRef reloj As String, tipo_cred As String, factorDesc As Double, tipoNom As String, tipoPer As String, uma As Double, diasPag As Double, umi As Double, integr As Double) As Double
        Dim Res As Double = 0.0
        If (diasPag = 0) Then Return Res
        Try
            Dim basePorc As Double = 0.0
            Dim topePorc As Double = 0.0
            Dim numSemDesc As Double = 0.0
            Dim DescMensVsm As Double = 0.0
            Dim DescInfon As Double = 0.0

            '  If (tipoPer = "S") Then numSemDesc = 4  
            If totSemDescInfo = 0 Then totSemDescInfo = 4
            If (tipoPer = "S") Then numSemDesc = totSemDescInfo
            If (tipoPer = "C") Then numSemDesc = 2

            If (tipo_cred = 1) Then ' Porcentaje
                basePorc = integr * diasPag
                topePorc = 25 * uma * diasPag
                If (basePorc >= topePorc) Then basePorc = topePorc ' Topamos esa base 
                DescInfon = basePorc * (factorDesc / 100)
                Res = DescInfon
                Return Res
            End If

            If (tipo_cred = 2) Then ' Cuota Fija
                '    DescInfon = factorDesc / numSemDesc
                DescInfon = (factorDesc / 30.4) * diasPag
                Res = DescInfon
                Return Res
            End If

            If (tipo_cred = 3) Then ' VSM
                DescMensVsm = factorDesc * umi
                '     DescInfon = DescMensVsm / numSemDesc
                DescInfon = (DescMensVsm / 30.4) * diasPag
                Res = DescInfon
                Return Res
            End If


            Return Res
        Catch ex As Exception
            Return Res
        End Try
    End Function

    '--Obtener y actualizar en el mtro de deduc lo referente al saldo del fondo de ahorro (SAFAHE y SAFAHC)
    Public Function GetSaldosFah(ByVal _anio As String, ByVal _periodo As String, ByVal _reloj As String, abono As Double) As Integer
        Dim dtExistSaldo As New DataTable
        Try

            '-------AO 2023-12-14: Casos cuando son Reingresos, eliminar todo de mtro_ded y saldos_ca, siempre y cuando sea su primer nomina
            Dim Q As String = "", dtReing As New DataTable, alta_empl As String = "", dtPrimerPer As New DataTable, ANOPER As String = "", dtDatosPrimerNom As New DataTable

            Q = "select top 1 * from reingresos where reloj='" & _reloj & "' order by fecha desc "
            dtReing = sqlExecute(Q, "PERSONAL")
            If dtReing.Rows.Count > 0 Then
                Try : alta_empl = FechaSQL(dtReing.Rows(0).Item("alta").ToString.Trim) : Catch ex As Exception : alta_empl = "" : End Try

                Q = "select top 1  ano+PERIODO as 'ANOPER' from TA.dbo.periodos where fini_nom>='" & alta_empl & "' and ISNULL(periodo_especial,0)=0 order by fini_nom asc"
                dtPrimerPer = sqlExecute(Q, "TA")
                If Not dtPrimerPer.Columns.Contains("Error") And dtPrimerPer.Rows.Count > 0 Then Try : ANOPER = dtPrimerPer.Rows(0).Item("ANOPER").ToString.Trim : Catch ex As Exception : ANOPER = "" : End Try

                Q = "select * from NOMINA.dbo.nomina where reloj='" & _reloj & "' and ANO+PERIODO='" & ANOPER & "'"
                dtDatosPrimerNom = sqlExecute(Q, "NOMINA")
                If dtDatosPrimerNom.Rows.Count <= 0 Then ' Si es su primer nómina la que se está procesando, SI ELIMINAR lo de mtro_ded y saldos_ca
                    sqlExecute("delete from mtro_ded where reloj='" & _reloj & "' and CONCEPTO in('SAFAHC','SAFAHE')", "NOMINA")
                    sqlExecute("delete from saldos_ca where reloj='" & _reloj & "' and CONCEPTO in('SAFAHC','SAFAHE')", "NOMINA")
                End If

            End If

            '-------END Casos cuando son reingresos

            '----Validar saldo
            Dim QrExist As String = "select * from mtro_ded where reloj='" & _reloj & "' and CONCEPTO in('SAFAHC','SAFAHE') and STATUS=1"
            dtExistSaldo = sqlExecute(QrExist, "NOMINA")
            If (Not dtExistSaldo.Columns.Contains("Error") And dtExistSaldo.Rows.Count > 0) Then
                '---Existe
                Try : saldo_tot_fahc = dtExistSaldo.Rows(0).Item("SALDO_ACT").ToString.Trim : Catch ex As Exception : saldo_tot_fahc = 0.0 : End Try
                saldo_tot_fahe = saldo_tot_fahc  ' Es lo mismo el de la empresa que el de la compania

                sqlExecute("update mtro_ded set NUMCREDITO='" & _anio.Trim & _periodo.Trim & "',ano='" & _anio & "',PERIODO='" & _periodo & "',ABONO_ACT=" & abono & " where reloj='" & _reloj & "' and CONCEPTO='SAFAHC' ", "NOMINA")
                sqlExecute("update mtro_ded set NUMCREDITO='" & _anio.Trim & _periodo.Trim & "',ano='" & _anio & "',PERIODO='" & _periodo & "',ABONO_ACT=" & abono & " where reloj='" & _reloj & "' and CONCEPTO='SAFAHE' ", "NOMINA")

            End If
            If (dtExistSaldo.Rows.Count = 0 And Not dtExistSaldo.Columns.Contains("Error") And abono > 0) Then
                ' -- No existe, agregarlo
                Dim Q1 As String = "INSERT INTO mtro_ded (reloj,CONCEPTO,NUMCREDITO,PERIODO,ano,STATUS,SALDO_ACT,ABONO_ACT) " & _
                    "VALUES ('" & _reloj & "','SAFAHC','" & _anio.Trim & _periodo.Trim & "','" & _periodo & "','" & _anio & "',1,0," & abono & ")"

                Dim Q2 As String = "INSERT INTO mtro_ded (reloj,CONCEPTO,NUMCREDITO,PERIODO,ano,STATUS,SALDO_ACT,ABONO_ACT) " & _
                   "VALUES ('" & _reloj & "','SAFAHE','" & _anio.Trim & _periodo.Trim & "','" & _periodo & "','" & _anio & "',1,0," & abono & ")"

                '---AOS: 05/04/2021 - Dejar en 0 el abono_alc para el  periodo 00
                Dim abono_alc As Double = 0.0
                Dim Q3 As String = "insert into saldos_ca (reloj,ano,PERIODO,CONCEPTO,NUMCREDITO,ABONO_ALC,SALDO_ACT,COMENTARIO) " & _
                    "VALUES ('" & _reloj & "','" & _anio & "','00','SAFAHC','" & _anio & "00" & "'," & abono_alc & ",0,'Saldo inicial " & Date.Today & " Usuario: " & Usuario & "')"

                Dim Q4 As String = "insert into saldos_ca (reloj,ano,PERIODO,CONCEPTO,NUMCREDITO,ABONO_ALC,SALDO_ACT,COMENTARIO) " & _
         "VALUES ('" & _reloj & "','" & _anio & "','00','SAFAHE','" & _anio & "00" & "'," & abono_alc & ",0,'Saldo inicial " & Date.Today & " Usuario: " & Usuario & "')"

                sqlExecute(Q1, "NOMINA")
                sqlExecute(Q2, "NOMINA")
                sqlExecute(Q3, "NOMINA")
                sqlExecute(Q4, "NOMINA")

                saldo_tot_fahc = 0.0
                saldo_tot_fahe = 0.0


            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    '---Consulta la bitácora para saber que valor tuvo en el periodo antes de la nómina actual
    Public Function ConsultaBitacoraNomina(ByVal dtTabla As DataTable, ByRef dRow As DataRow, ByVal FechaInicio As Date, ByVal FechaFin As Date) As Boolean
        Dim dtPeriodos As New DataTable
        Dim dtBitacora As New DataTable
        Dim Campo As String

        Dim dtTemp As New DataTable

        Try
            'buscar si hay movimientos efectuados después del fin del periodo
            'si hay, tomar el valorAnterior del primero, que indica cómo estaba antes del cambio
            Dim QB As String = "SELECT CAMPO,VALORANTERIOR FROM bitacora_personal WHERE reloj = '" & dRow("reloj") & _
                                    "' AND FECHA = " & _
                                    "(SELECT MIN(FECHA) AS FECHA FROM dbo.bitacora_personal AS BITACORA WHERE " & _
                                    "CAST(fecha AS DATE) between '" & FechaSQL(FechaInicio) & "' and '" & FechaSQL(FechaFin) & "' AND campo = bitacora_personal.campo and reloj= bitacora_personal.reloj) " & _
                                    " AND tipo_movimiento = 'C' and isnull(ValorAnterior,'')<>''  ORDER BY fecha desc"
            dtBitacora = sqlExecute(QB)


            For Each dCol As DataRow In dtBitacora.Rows
                Campo = dCol("campo").ToString.ToLower.Trim
                If dtTabla.Columns.IndexOf(Campo) >= 0 Then
                    If dRow(Campo).ToString <> dCol("ValorAnterior").ToString Then

                        'Select Case dtTabla.Columns(Campo).DataType
                        '    Case GetType(System.String)
                        '        dRow(Campo) = dCol("ValorAnterior").ToString.Trim
                        '    Case GetType(System.Boolean)
                        '        dRow(Campo) = CInt(dCol("ValorAnterior"))
                        '    Case Else
                        '        dRow(Campo) = dCol("ValorAnterior")
                        'End Select

                        Select Case Campo
                            Case "cod_tipo" '--  AOS - 26/03/2021 - A solicitud de Brenda, se pide que el tipo de empleado y el tipo de periodo sea de lo que está en Personal actual
                                'If dtTabla.Columns.IndexOf("cod_tipo") >= 0 Then
                                '    dRow("cod_tipo") = dCol("ValorAnterior").ToString.Trim
                                'End If

                                'If dtTabla.Columns.IndexOf("nombre_tipoEmp") >= 0 Then
                                '    dtTemp = sqlExecute("SELECT nombre FROM tipo_emp WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_tipo = '" & dRow(Campo) & "'")
                                '    If dtTemp.Rows.Count > 0 Then
                                '        dRow("nombre_tipoEmp") = dtTemp.Rows(0).Item("nombre")
                                '    Else
                                '        dRow("nombre_tipoEmp") = ""
                                '    End If
                                'End If

                            Case "cod_clase"
                                If dtTabla.Columns.IndexOf("cod_clase") >= 0 Then
                                    dRow("cod_clase") = dCol("ValorAnterior").ToString.Trim
                                End If

                                'If dtTabla.Columns.IndexOf("nombre_clase") >= 0 Then
                                '    dtTemp = sqlExecute("SELECT nombre FROM clase WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_clase = '" & dRow(Campo) & "'")
                                '    If dtTemp.Rows.Count > 0 Then
                                '        dRow("nombre_clase") = dtTemp.Rows(0).Item("nombre")
                                '    Else
                                '        dRow("nombre_clase") = ""
                                '    End If
                                'End If
                            Case "cod_comp"
                                If dtTabla.Columns.IndexOf("cod_comp") >= 0 Then
                                    dRow("cod_comp") = dCol("ValorAnterior").ToString.Trim
                                End If

                                'If dtTabla.Columns.IndexOf("compania") >= 0 Then
                                '    dtTemp = sqlExecute("SELECT nombre FROM cias WHERE cod_comp = '" & dRow("cod_comp") & "'")
                                '    If dtTemp.Rows.Count > 0 Then
                                '        dRow("compania") = dtTemp.Rows(0).Item("nombre")
                                '    Else
                                '        dRow("compania") = ""
                                '    End If
                                'End If
                            Case "cod_area"
                                If dtTabla.Columns.IndexOf("cod_area") >= 0 Then
                                    dRow("cod_area") = dCol("ValorAnterior").ToString.Trim
                                End If

                                'If dtTabla.Columns.IndexOf("nombre_area") >= 0 Then
                                '    dtTemp = sqlExecute("SELECT nombre FROM areas WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_area = '" & dRow(Campo) & "'")
                                '    If dtTemp.Rows.Count > 0 Then
                                '        dRow("nombre_area") = dtTemp.Rows(0).Item("nombre")
                                '    Else
                                '        dRow("nombre_area") = ""
                                '    End If
                                'End If
                            Case "cod_depto"
                                If dtTabla.Columns.IndexOf("cod_depto") >= 0 Then
                                    dRow("cod_depto") = dCol("ValorAnterior").ToString.Trim
                                End If
                            Case "tipo_periodo" '--  AOS - 26/03/2021 - A solicitud de Brenda, se pide que el tipo de empleado y el tipo de periodo sea de lo que está en Personal actual
                                'If dtTabla.Columns.IndexOf("tipo_periodo") >= 0 Then
                                '    dRow("tipo_periodo") = dCol("ValorAnterior").ToString.Trim
                                'End If
                            Case "CENTRO_COSTOS"
                                If dtTabla.Columns.IndexOf("CENTRO_COSTOS") >= 0 Then
                                    dRow("CENTRO_COSTOS") = dCol("ValorAnterior").ToString.Trim
                                End If

                            Case "cod_super"
                                If dtTabla.Columns.IndexOf("cod_super") >= 0 Then
                                    dRow("cod_super") = dCol("ValorAnterior").ToString.Trim
                                End If

                            Case "cod_planta"
                                If dtTabla.Columns.IndexOf("cod_planta") >= 0 Then
                                    dRow("cod_planta") = dCol("ValorAnterior").ToString.Trim
                                End If

                            Case "cod_turno"
                                If dtTabla.Columns.IndexOf("cod_turno") >= 0 Then
                                    dRow("cod_turno") = dCol("ValorAnterior").ToString.Trim
                                End If

                                'Case "cod_puesto"
                                '    If dtTabla.Columns.IndexOf("cod_puesto") >= 0 Then
                                '        dRow("cod_puesto") = dCol("ValorAnterior").ToString.Trim
                                '    End If

                            Case "cod_hora"
                                If dtTabla.Columns.IndexOf("cod_hora") >= 0 Then
                                    dRow("cod_hora") = dCol("ValorAnterior").ToString.Trim
                                End If

                                'Case "sactual"
                                '    If dtTabla.Columns.IndexOf("sactual") >= 0 Then
                                '        dRow("sactual") = dRow(Campo)
                                '    End If
                        End Select
                    End If
                End If
            Next

            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Public Sub InicializaProcNomEspecial(ByVal _anio As String, _per As String, _tipoNomEsp As String, _numMes As String)
        Try
            '-- Limpia tablas
            sqlExecute("truncate table primer_calc_esp", "NOMINA")
            sqlExecute("truncate table status_proceso_esp", "NOMINA")
            sqlExecute("truncate table nomina_pro_esp", "NOMINA")
            sqlExecute("truncate table movimientos_pro_esp", "NOMINA")
            sqlExecute("truncate table movimientos_imss_pro_esp", "NOMINA")
            sqlExecute("truncate table horas_pro_esp", "NOMINA")
            sqlExecute("truncate table ajustes_pro_esp", "NOMINA")

            If (_tipoNomEsp = "ptu") Then
                CalcDiaPagPTU(_anio, _per, _tipoNomEsp, _numMes)    ' Calcular los días para cada empleado (DIASPA)
                CalcPTUDIA(_anio, _per, _tipoNomEsp, _numMes)  ' Calcular el mento en días de PTU (PTUDIA)
                CalcPTUSUE(_anio, _per, _tipoNomEsp, _numMes) ' Calcular el monto en sueldos (PTUSUE)
            End If

            GetDataFromPersonal(_anio, _per, _tipoNomEsp, _numMes)

        Catch ex As Exception

        End Try
    End Sub

    '== Funcion para saber si empleado fue reingreso y usar info para PTU               Ernesto -- Fecha: 25abril2022
    Public Function ReingresoEmpPTU() As DataTable
        Try
            Dim fecIniAnioPasado = CStr(Year(Date.Now) - 1) & "-01-01"
            Dim fecFinAnioPasado = CStr(Year(Date.Now) - 1) & "-12-31"
            Dim Qry = "SELECT r.reloj,r.alta_ant,r.baja_ant,r.alta as alta_actual," & _
                                "(CASE WHEN YEAR(r.baja_ant)=YEAR(GETDATE())-1 THEN DATEDIFF(dd, CASE WHEN YEAR(r.alta_ant)=YEAR(GETDATE())-1 THEN alta_ant ELSE '" & fecIniAnioPasado & "' END, r.baja_ant)+1 " & _
                                "ELSE 0 END)+DATEDIFF(dd,r.alta,'" & fecFinAnioPasado & "')+1 AS dias_totales " & _
                                "FROM PERSONAL.dbo.reingresos r LEFT JOIN PERSONAL.dbo.personal p " & _
                                "ON r.reloj=p.reloj WHERE YEAR(r.alta)=YEAR(GETDATE())-1 and p.baja is null"
            Dim dtReingAnioPas = sqlExecute(Qry)

            Return dtReingAnioPas
        Catch ex As Exception
        End Try
    End Function


    'Public Sub CalcDiaPagPTU(ByVal _ano As String, _periodo As String, _tipoNomEsp As String, _numMes As String)
    '    Try
    '        Dim anio_Ant As Integer = Convert.ToInt32(_ano) - 1 ' NOTA: El empleado 00001 no entra al reparto de utilidades
    '        Dim dtPersonal As DataTable = sqlExecute("select reloj,alta,baja from personalvw where reloj<>'00001' and ((select DATEDIFF(dd, alta, '" & anio_Ant & "-12-31')+1)>=" & dias_ptu & ") and cod_puesto not in ('00094')", "PERSONAL")

    '        Dim dtAusentismos As New DataTable
    '        Dim AusAplicar As String = "'FI','SUS'" '---- Para ptu a pagar en el 2023 referenciando el 2022, comenta Brenda que solo aplicaria: ('FI','SUS')
    '        Dim QAus As String = "select * from ausentismo where TIPO_AUS in (" & AusAplicar & ") and fecha between '" & anio_Ant & "-01-01' and '" & anio_Ant & "-12-31'"
    '        dtAusentismos = sqlExecute(QAus, "TA")


    '        '== 13mayo2022. Brenda solicito que se tomaran en cuenta los sig. empleados al calculo y se metieran de manera manual: '00025','00030','00050','00109','00319','00326','00341','00379'
    '        Dim rljMnl = "'00025','00030','00050','00109','00319','00326','00341','00379'"


    '        '== Ernesto: Fecha 25abr2022
    '        '== Se agregan los reingresos del año pasado actualmente activos
    '        Dim dtReingresosAnioAnt As DataTable = ReingresoEmpPTU()
    '        Dim reingCont As Integer = 0
    '        Dim reingresosStr = ""

    '        If Not dtReingresosAnioAnt Is Nothing Or dtReingresosAnioAnt.Rows.Count > 0 Then
    '            Dim diasPaReing As Double = 0.0
    '            Dim relojReing As String = ""

    '            For Each x As DataRow In dtReingresosAnioAnt.Rows
    '                relojReing = Trim(x.Item("reloj"))
    '                diasPaReing = x.Item("dias_totales")

    '                If (diasPaReing >= dias_ptu) Then
    '                    If (diasPaReing >= 365) Then diasPaReing = 365
    '                    Dim Q As String = "insert into ajustes_pro_esp values('" & _ano & "','" & _periodo & "','" & relojReing & "',null,'DIASPA','DIAS PAG'," & diasPaReing & ",NULL,'" & Usuario & "',NULL,'Dias pagados PTU')"
    '                    sqlExecute(Q, "NOMINA")
    '                    reingCont += 1
    '                    reingresosStr &= relojReing & ","
    '                End If

    '            Next
    '        End If
    '        '== Fin reingresos

    '        If (Not dtPersonal.Columns.Contains("Error") And dtPersonal.Rows.Count > 0) Then

    '            '-- Se incluyen los reingresos      25abr2022   Ernesto
    '            Dim empleados_a_importar As Integer = dtPersonal.Rows.Count + reingCont
    '            Dim contador_empleados As Integer = 1 + reingCont

    '            For Each dr As DataRow In dtPersonal.Rows
    '                '   For Each dr As DataRow In dtPersonal.Select("reloj='00191'")
    '                Dim rj As String = "", alta As String = "", baja As String = "", diaspa As Double = 0.0
    '                Dim _primeroEnero As New Date(Now.Year - 1, 1, 1) ' 1Ero de Enero del anio anterior
    '                Dim _diaUltAnioAnt As New Date(Now.Year - 1, 12, 31) ' 31 de Dic del anio anterior
    '                Try : rj = dr("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
    '                Try : alta = FechaSQL(dr("alta").ToString.Trim) : Catch ex As Exception : alta = "" : End Try
    '                Try : baja = FechaSQL(dr("baja").ToString.Trim) : Catch ex As Exception : baja = "" : End Try

    '                frmCalcPTU.lblEstatus.Text = "Calculando días PTU [" & rj & "][" & contador_empleados & " de " & empleados_a_importar & "]"

    '                If (alta <> "" And baja = "") Then
    '                    ' Calcular los dias que le tocan, sacando la diferencia entre el alta y el 31/12 del anio anterior
    '                    diaspa = Antiguedad_Dias(Date.Parse(alta), _diaUltAnioAnt)
    '                End If

    '                If (alta <> "" And baja <> "") Then
    '                    Dim BajaMin As Date
    '                    BajaMin = DateAdd("d", dias_ptu, _primeroEnero) ' Se le agregan los días para PTU al primero de enero del año anterior para obtener la fecha de baja mínima para considerar

    '                    '== If original comentado: 13mayo2022, Ernesto
    '                    'If (Date.Parse(baja) >= BajaMin) Then

    '                    '== If con relojes manuales: 13mayo2022, Ernesto
    '                    If (Date.Parse(baja) >= BajaMin Or rljMnl.Contains(rj)) Then

    '                        If (Date.Parse(baja).Year = Convert.ToInt32(_ano)) Then  '--Si la baja es en el año actual sacar la dif entre el alta y el 31/12 del anio anteior
    '                            diaspa = Antiguedad_Dias(Date.Parse(alta), _diaUltAnioAnt)

    '                        Else   '--Si la baja es en el año anterior

    '                            If (Date.Parse(alta).Year = Convert.ToInt32(_ano) - 1) Then ' Si la alta es del año anterior
    '                                diaspa = Antiguedad_Dias(Date.Parse(alta), Date.Parse(baja)) ' Sacar dif entre el alta y la baja
    '                            Else 'Si el alta es de años atras, sacar la dif entre el 1er de enero del anio anterior y la fecha de baja
    '                                diaspa = Antiguedad_Dias(_primeroEnero, Date.Parse(baja))
    '                            End If

    '                        End If
    '                    End If
    '                End If

    '                '---Descuenta dias de ptu
    '                '  QUERY::   select count(0) as faltas from TA.dbo.ausentismo where reloj='00197' and TIPO_AUS in ('FI') and fecha between '2020-01-01' and '2020-12-31'
    '                Dim AusADesc As Integer = 0
    '                AusADesc = dtAusentismos.Select("reloj='" & rj & "'").Count

    '                ' If (diaspa >= dias_ptu Or rljMnl.Contains(rj)) Then   '== If con relojes manuales agregados: 13mayo2022, Ernesto
    '                If (diaspa >= dias_ptu) Then ' IF Original

    '                    If (diaspa >= 365) Then diaspa = 365

    '                    diaspa = diaspa - AusADesc ' Descuenta los ausentismos
    '                    If (diaspa <= 0) Then diaspa = 0

    '                    '== Que no sea reingreso                25abr2022
    '                    If Not reingresosStr.Contains(rj) Then
    '                        Dim Q As String = "insert into ajustes_pro_esp values('" & _ano & "','" & _periodo & "','" & rj & "',null,'DIASPA','DIAS PAG'," & diaspa & ",NULL,'" & Usuario & "',NULL,'Dias pagados PTU')"
    '                        sqlExecute(Q, "NOMINA")
    '                    End If

    '                End If

    '                Application.DoEvents()
    '                contador_empleados += 1
    '            Next
    '        End If

    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Cálculo dias para PTU", Err.Number, ex.Message)
    '    End Try
    'End Sub


    Public Sub CalcDiaPagPTU(ByVal _ano As String, _periodo As String, _tipoNomEsp As String, _numMes As String)
        Try

            Dim anio_Ant As Integer = Convert.ToInt32(_ano) - 1 ' NOTA: El empleado 00001 no entra al reparto de utilidades
            ' Dim QP As String = "select reloj,alta,baja from personalvw where reloj<>'00001' and ((select DATEDIFF(dd, alta, '" & anio_Ant & "-12-31')+1)>=" & dias_ptu & ") and cod_puesto not in ('00094')"
            Dim QP As String = "select reloj,alta,baja from personalvw where reloj<>'00001' and cod_puesto not in ('00094')"
            Dim dtPersonal As DataTable = sqlExecute(QP, "PERSONAL")

            Dim dtAusentismos As New DataTable
            Dim AusAplicar As String = "'FI','SUS'" '---- Para ptu a pagar en el 2023 referenciando el 2022, comenta Brenda que solo aplicaria: ('FI','SUS')
            Dim QAus As String = "select * from ausentismo where TIPO_AUS in (" & AusAplicar & ") and fecha between '" & anio_Ant & "-01-01' and '" & anio_Ant & "-12-31'"
            dtAusentismos = sqlExecute(QAus, "TA")


            '== 13mayo2022. Brenda solicito que se tomaran en cuenta los sig. empleados al calculo y se metieran de manera manual: '00025','00030','00050','00109','00319','00326','00341','00379'
            Dim rljMnl = "'00025','00030','00050','00109','00319','00326','00341','00379'"


            '== Ernesto: Fecha 25abr2022
            '== Se agregan los reingresos del año pasado actualmente activos

            'Dim dtReingresosAnioAnt As DataTable = ReingresoEmpPTU()
            'Dim reingCont As Integer = 0
            'Dim reingresosStr = ""

            'If Not dtReingresosAnioAnt Is Nothing Or dtReingresosAnioAnt.Rows.Count > 0 Then
            '    Dim diasPaReing As Double = 0.0
            '    Dim relojReing As String = ""

            '    For Each x As DataRow In dtReingresosAnioAnt.Rows
            '        relojReing = Trim(x.Item("reloj"))
            '        diasPaReing = x.Item("dias_totales")

            '        If (diasPaReing >= dias_ptu) Then
            '            If (diasPaReing >= 365) Then diasPaReing = 365
            '            Dim Q As String = "insert into ajustes_pro_esp values('" & _ano & "','" & _periodo & "','" & relojReing & "',null,'DIASPA','DIAS PAG'," & diasPaReing & ",NULL,'" & Usuario & "',NULL,'Dias pagados PTU')"
            '            sqlExecute(Q, "NOMINA")
            '            reingCont += 1
            '            reingresosStr &= relojReing & ","
            '        End If

            '    Next
            'End If

            '== Fin reingresos

            Dim reingCont As Integer = 0
            Dim EmplNoTomarEnCuenta As String = "'00809','00821'" ' Empleados que comenta Brenda no deben de entrar al calc de PTU ya que son reingresos pero con diferente numero, se deben de añadir a la tabla de reingresos:  insert into PERSONAL.dbo.reingresos values ('00907','2022-06-06','2022-01-10','2022-03-11','01','01','2022-06-06',NULL)
            If (Not dtPersonal.Columns.Contains("Error") And dtPersonal.Rows.Count > 0) Then

                '-- Se incluyen los reingresos      25abr2022   Ernesto
                Dim empleados_a_importar As Integer = dtPersonal.Rows.Count
                Dim contador_empleados As Integer = 1

                For Each dr As DataRow In dtPersonal.Rows
                    'For Each dr As DataRow In dtPersonal.Select("reloj='00026'") ' Para probar a ciertos empleados


                    Dim rj As String = "", alta As String = "", baja As String = "", diaspa As Double = 0.0
                    Dim _primeroEnero As New Date(Now.Year - 1, 1, 1) ' 1Ero de Enero del anio anterior
                    Dim _diaUltAnioAnt As New Date(Now.Year - 1, 12, 31) ' 31 de Dic del anio anterior
                    Try : rj = dr("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                    Try : alta = FechaSQL(dr("alta").ToString.Trim) : Catch ex As Exception : alta = "" : End Try
                    Try : baja = FechaSQL(dr("baja").ToString.Trim) : Catch ex As Exception : baja = "" : End Try
                    Dim esReingreso As Boolean = False, AusADesc As Integer = 0

                    If EmplNoTomarEnCuenta.Contains(rj) Then GoTo NextRecord

                    frmCalcPTU.lblEstatus.Text = "Calculando días PTU [" & rj & "][" & contador_empleados & " de " & empleados_a_importar & "]"

                    '***********************************************************************************************************************************************************************************************************
                    '*********************************************************************PRCESO PARA  REINGRESOS **************************************************************************************************************************************
                    '***********************************************************************************************************************************************************************************************************

                    Dim QReing As String = "select * from reingresos where reloj='" & rj & "' and (year(fecha)='" & anio_Ant & "' or year(alta_ant)='" & anio_Ant & "' or year(baja_ant)='" & anio_Ant & "' or year(alta)='" & anio_Ant & "') order by fecha asc"
                    Dim dtReingresos As New DataTable, segundoRec As Integer = 0, sumaDiasReing As Double = 0.0
                    dtReingresos = sqlExecute(QReing, "PERSONAL")

                    If Not dtReingresos.Columns.Contains("Error") And dtReingresos.Rows.Count > 0 Then
                        esReingreso = True

                        If dtReingresos.Rows.Count = 1 Then ' Solo tiene 1 reingreso y una 2da alta

                            Dim alta_ant As String = "", baja_ant As String = "", alta_reing As String = "", anio_alta_ant As Integer = 0, anio_baja_ant As Integer = 0, anio_alta As Integer = 0

                            Try : alta_ant = FechaSQL(dtReingresos.Rows(0).Item("alta_ant").ToString.Trim) : Catch ex As Exception : alta_ant = "" : End Try
                            Try : baja_ant = FechaSQL(dtReingresos.Rows(0).Item("baja_ant").ToString.Trim) : Catch ex As Exception : baja_ant = "" : End Try
                            Try : alta_reing = FechaSQL(dtReingresos.Rows(0).Item("alta").ToString.Trim) : Catch ex As Exception : alta_reing = "" : End Try
                            Try : anio_alta_ant = Date.Parse(alta_ant).Year : Catch ex As Exception : anio_alta_ant = anio_Ant : End Try
                            Try : anio_baja_ant = Date.Parse(baja_ant).Year : Catch ex As Exception : anio_baja_ant = anio_Ant : End Try
                            Try : anio_alta = Date.Parse(alta_reing).Year : Catch ex As Exception : anio_alta = anio_Ant : End Try

                            If (anio_alta_ant < anio_Ant) Then ' Si la alta anterior es menor al anio anterior, hacerlo al 1ero denero
                                If (anio_baja_ant = anio_Ant) Then ' si la baja es del mimo anio anterior
                                    sumaDiasReing = Antiguedad_Dias(Date.Parse(_primeroEnero), Date.Parse(baja_ant))
                                End If

                                If (anio_alta = anio_Ant) Then

                                    If (baja <> "") Then ' si tiene baja actual
                                        If (Date.Parse(baja).Year = anio_Ant) Then ' si ultima baja es del anio anterior
                                            sumaDiasReing = sumaDiasReing + Antiguedad_Dias(Date.Parse(alta_reing), Date.Parse(baja))
                                        End If

                                        If (Date.Parse(baja).Year > anio_Ant) Then ' si ultima baja es del año actual
                                            sumaDiasReing = sumaDiasReing + Antiguedad_Dias(Date.Parse(alta_reing), _diaUltAnioAnt)
                                        End If

                                    Else
                                        sumaDiasReing = sumaDiasReing + Antiguedad_Dias(Date.Parse(alta_reing), _diaUltAnioAnt) ' Solo es la ultima de su ultima alta al ultimo del mes
                                    End If

                                End If

                            End If

                            If (anio_alta_ant = anio_Ant) And sumaDiasReing = 0 Then ' si la alta anterior es la misma que del año anterior
                                If (anio_baja_ant = anio_Ant) Then ' si la baja es dentro del mismo anio
                                    sumaDiasReing = Antiguedad_Dias(Date.Parse(alta_ant), Date.Parse(baja_ant))
                                End If

                                If (baja <> "") Then ' si tiene baja actual
                                    If (Date.Parse(baja).Year = anio_Ant) Then ' si ultima baja es del anio anterior
                                        sumaDiasReing = sumaDiasReing + Antiguedad_Dias(Date.Parse(alta_reing), Date.Parse(baja))
                                    End If

                                    If (Date.Parse(baja).Year > anio_Ant) Then ' si ultima baja es del año actual
                                        sumaDiasReing = sumaDiasReing + Antiguedad_Dias(Date.Parse(alta_reing), _diaUltAnioAnt)
                                    End If
                                Else
                                    sumaDiasReing = sumaDiasReing + Antiguedad_Dias(Date.Parse(alta_reing), _diaUltAnioAnt) ' Solo es la suma de su ultima alta al ultimo del mes
                                End If
                            End If

                            If (anio_baja_ant < anio_Ant) And anio_alta = anio_Ant And sumaDiasReing = 0 Then ' Si la baja anterior es de un año menor al año anterior, pero la ultima alta es del año anterior
                                If (baja <> "") Then ' si tiene baja actual
                                    If (Date.Parse(baja).Year = anio_Ant) Then ' si ultima baja es del anio anterior
                                        sumaDiasReing = Antiguedad_Dias(Date.Parse(alta_reing), Date.Parse(baja))
                                    End If

                                    If (Date.Parse(baja).Year > anio_Ant) Then ' si ultima baja es del año actual
                                        sumaDiasReing = Antiguedad_Dias(Date.Parse(alta_reing), _diaUltAnioAnt)
                                    End If
                                Else
                                    sumaDiasReing = sumaDiasReing + Antiguedad_Dias(Date.Parse(alta_reing), _diaUltAnioAnt) ' Solo es la suma de su ultima alta al ultimo del mes
                                End If
                            End If


                        End If

                        ' Dos reingresos
                        If dtReingresos.Rows.Count = 2 Then ' Tiene 2 reingresos y una 3era alta

                            For Each drR2 As DataRow In dtReingresos.Rows
                                Dim alta_ant As String = "", baja_ant As String = "", alta_reing As String = "", anio_alta_ant As Integer = 0, anio_baja_ant As Integer = 0, anio_alta As Integer = 0
                                segundoRec += 1

                                Try : alta_ant = FechaSQL(drR2("alta_ant").ToString.Trim) : Catch ex As Exception : alta_ant = "" : End Try
                                Try : baja_ant = FechaSQL(drR2("baja_ant").ToString.Trim) : Catch ex As Exception : baja_ant = "" : End Try
                                Try : alta_reing = FechaSQL(drR2("alta").ToString.Trim) : Catch ex As Exception : alta_reing = "" : End Try
                                Try : anio_alta_ant = Date.Parse(alta_ant).Year : Catch ex As Exception : anio_alta_ant = anio_Ant : End Try
                                Try : anio_baja_ant = Date.Parse(baja_ant).Year : Catch ex As Exception : anio_baja_ant = anio_Ant : End Try
                                Try : anio_alta = Date.Parse(alta_reing).Year : Catch ex As Exception : anio_alta = anio_Ant : End Try

                                If (segundoRec = 1) Then
                                    If (anio_alta_ant < anio_Ant) And anio_baja_ant = anio_Ant Then ' Si la alta anterior es menor al anio actual, y su primer baja es de este año se convierte al primero de enero
                                        sumaDiasReing = Antiguedad_Dias(_primeroEnero, Date.Parse(baja_ant))
                                    ElseIf (anio_alta_ant = anio_Ant) And anio_baja_ant = anio_Ant Then ' Si el alta anterior y baja anterior caen dentro del mismo anio
                                        sumaDiasReing = Antiguedad_Dias(alta_ant, Date.Parse(baja_ant))
                                    End If
                                End If

                                If (segundoRec = 2) Then ' Buscar la ultima baja en personal

                                    If (anio_alta_ant = anio_Ant) And (anio_baja_ant = anio_Ant) Then ' Si la alta anterior y la baja anterior caen dentro del mismo año
                                        sumaDiasReing = sumaDiasReing + Antiguedad_Dias(Date.Parse(alta_ant), Date.Parse(baja_ant))
                                    End If

                                    If (baja <> "") Then ' Si tiene baja
                                        If (Date.Parse(baja).Year > anio_Ant) Then ' Si la baja es mayor al año anterior, contabilizarlo de su ultima alta al 31/12 de ese anio
                                            sumaDiasReing = sumaDiasReing + Antiguedad_Dias(Date.Parse(alta_reing), Date.Parse(_diaUltAnioAnt))
                                        End If
                                        If (Date.Parse(baja).Year = anio_Ant) Then ' si la ultima baja cae dentro del mismo año, contabilizar desde su ultima alta a esa fecha del baja del anio anterio
                                            sumaDiasReing = sumaDiasReing + Antiguedad_Dias(Date.Parse(alta_reing), Date.Parse(baja))
                                        End If
                                    Else ' si no tiene baja, sumar hasta el 31/12 de ese anio
                                        sumaDiasReing = sumaDiasReing + Antiguedad_Dias(Date.Parse(alta_reing), Date.Parse(_diaUltAnioAnt))
                                    End If

                                End If

                            Next
                        End If

                        ' Descontar aus
                        If (sumaDiasReing >= 365) Then sumaDiasReing = 365
                        AusADesc = dtAusentismos.Select("reloj='" & rj & "'").Count
                        diaspa = sumaDiasReing - AusADesc

                        If (diaspa >= dias_ptu) Then
                            If (diaspa >= 365) Then diaspa = 365
                            If (diaspa <= 0) Then diaspa = 0

                            Dim Q As String = "insert into ajustes_pro_esp values('" & _ano & "','" & _periodo & "','" & rj & "',null,'DIASPA','DIAS PAG'," & diaspa & ",NULL,'" & Usuario & "',NULL,'Dias pagados PTU')"
                            sqlExecute(Q, "NOMINA")

                        End If

                    End If



                    '***********************************************************************************************************************************************************************************************************
                    '*********************************************************************PRCESO PARA NO REINGRESOS (Empleados normales)**************************************************************************************************************************************
                    '***********************************************************************************************************************************************************************************************************
                    If Not esReingreso Then

                        If (alta <> "" And baja = "") Then
                            ' Calcular los dias que le tocan, sacando la diferencia entre el alta y el 31/12 del anio anterior
                            diaspa = Antiguedad_Dias(Date.Parse(alta), _diaUltAnioAnt)
                        End If

                        If (alta <> "" And baja <> "") Then
                            Dim BajaMin As Date
                            BajaMin = DateAdd("d", dias_ptu, _primeroEnero) ' Se le agregan los días para PTU al primero de enero del año anterior para obtener la fecha de baja mínima para considerar

                            '== If original comentado: 13mayo2022, Ernesto
                            'If (Date.Parse(baja) >= BajaMin) Then

                            '== If con relojes manuales: 13mayo2022, Ernesto
                            If (Date.Parse(baja) >= BajaMin Or rljMnl.Contains(rj)) Then

                                If (Date.Parse(baja).Year = Convert.ToInt32(_ano)) Then  '--Si la baja es en el año actual sacar la dif entre el alta y el 31/12 del anio anteior
                                    diaspa = Antiguedad_Dias(Date.Parse(alta), _diaUltAnioAnt)

                                Else   '--Si la baja es en el año anterior

                                    If (Date.Parse(alta).Year = Convert.ToInt32(_ano) - 1) Then ' Si la alta es del año anterior
                                        diaspa = Antiguedad_Dias(Date.Parse(alta), Date.Parse(baja)) ' Sacar dif entre el alta y la baja
                                    Else 'Si el alta es de años atras, sacar la dif entre el 1er de enero del anio anterior y la fecha de baja
                                        diaspa = Antiguedad_Dias(_primeroEnero, Date.Parse(baja))
                                    End If

                                End If
                            End If
                        End If

                        '---Descuenta dias de ptu
                        '  QUERY::   select count(0) as faltas from TA.dbo.ausentismo where reloj='00197' and TIPO_AUS in ('FI') and fecha between '2020-01-01' and '2020-12-31'
                        If (diaspa >= 365) Then diaspa = 365
                        AusADesc = dtAusentismos.Select("reloj='" & rj & "'").Count
                        diaspa = diaspa - AusADesc ' Descuenta los ausentismos

                        ' If (diaspa >= dias_ptu Or rljMnl.Contains(rj)) Then   '== If con relojes manuales agregados: 13mayo2022, Ernesto
                        If (diaspa >= dias_ptu) Then ' IF Original

                            If (diaspa >= 365) Then diaspa = 365

                            If (diaspa <= 0) Then diaspa = 0

                            Dim Q As String = "insert into ajustes_pro_esp values('" & _ano & "','" & _periodo & "','" & rj & "',null,'DIASPA','DIAS PAG'," & diaspa & ",NULL,'" & Usuario & "',NULL,'Dias pagados PTU')"
                            sqlExecute(Q, "NOMINA")

                        End If

                    End If

                    Application.DoEvents()
                    contador_empleados += 1

NextRecord:
                Next

            End If
            '***********************************************************************************************************************************************************************************************************
            '*********************************************************************ENDS PROCESO EVALUA A CADA EMPLEADO***************************************************************************************************
            '***********************************************************************************************************************************************************************************************************

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Cálculo dias para PTU", Err.Number, ex.Message)
        End Try


        '  End Try
    End Sub

    Public Sub CalcPTUDIA(ByVal _ano As String, _periodo As String, _tipoNomEsp As String, _numMes As String)
        Try
            Dim MontoDias As Double = cant_repartir / 2
            '--- Obtener la suma total de dias  
            Dim SumaDias As Double = 0.0
            Dim dtSumaDias As DataTable = sqlExecute("select ISNULL(SUM(convert(float,monto)),0) AS 'SumaDias' from ajustes_pro_esp where concepto='DIASPA'", "NOMINA")
            If (Not dtSumaDias.Columns.Contains("Error") And dtSumaDias.Rows.Count > 0) Then
                Try : SumaDias = Double.Parse(dtSumaDias.Rows(0).Item("SumaDias")) : Catch ex As Exception : SumaDias = 0.0 : End Try
            End If

            Dim dtPersonal As DataTable = sqlExecute("select reloj,monto from ajustes_pro_esp where concepto='DIASPA'", "NOMINA")

            If (Not dtPersonal.Columns.Contains("Error") And dtPersonal.Rows.Count > 0) Then

                Dim empleados_a_importar As Integer = dtPersonal.Rows.Count
                Dim contador_empleados As Integer = 1

                For Each dr As DataRow In dtPersonal.Rows
                    Dim rj As String = "", diasPag As Double = 0.0, PTUDIA As Double = 0.0
                    Try : rj = dr("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                    Try : diasPag = Double.Parse(dr("monto")) : Catch ex As Exception : diasPag = 0.0 : End Try

                    frmCalcPTU.lblEstatus.Text = "Calculando cantidad en Días [" & rj & "][" & contador_empleados & " de " & empleados_a_importar & "]"

                    PTUDIA = Math.Round((diasPag / SumaDias) * MontoDias, 2)

                    Dim Q As String = "insert into ajustes_pro_esp values('" & _ano & "','" & _periodo & "','" & rj & "',null,'PTUDIA','PTU DIAS'," & PTUDIA & ",NULL,'" & Usuario & "',NULL,'PTU Días')"
                    sqlExecute(Q, "NOMINA")

                    Application.DoEvents()
                    contador_empleados += 1
                Next
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Cálculo dias para PTU", Err.Number, ex.Message)
        End Try
    End Sub

    Public Sub CalcPTUSUE(ByVal _ano As String, _periodo As String, _tipoNomEsp As String, _numMes As String)
        Try
            Dim MontoSueldo As Double = cant_repartir / 2
            Dim LimSdMax As Double = sd_max + (sd_max * 0.2)
            Dim anio_ant As String = Integer.Parse(Convert.ToInt32(_ano) - 1)

            Dim dtPersonal As DataTable = sqlExecute("select reloj from ajustes_pro_esp where concepto='DIASPA'", "NOMINA")
            If (Not dtPersonal.Columns.Contains("Error") And dtPersonal.Rows.Count > 0) Then

                Dim empleados_a_importar As Integer = dtPersonal.Rows.Count
                Dim contador_empleados As Integer = 1

                For Each dr As DataRow In dtPersonal.Rows
                    Dim rj As String = "", QAcum As String = "", acum As Double = 0.0, sueldo As Double = 0.0
                    Dim dtAcum As DataTable
                    Try : rj = dr("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try

                    frmCalcPTU.lblEstatus.Text = "Calculando sueldos [" & rj & "][" & contador_empleados & " de " & empleados_a_importar & "]"

                    '---Obtener el acumulado de su sueldo del año inmediato anterior **NOTA: Comentó Brenda que para el acumalado solo era su PERNOR, su RETROA y sus PERVAC
                    '--- AO 2023-05-16: Casos que son REINGRESOS que entran con diferente reloj 
                    Dim emplReing As String = "'00907','00908'"
                    If emplReing.Contains(rj) Then
                        Select Case rj
                            Case "00907"
                                QAcum = "select ISNULL(SUM(convert(float,monto)),0) AS 'acum' from movimientos where reloj in('00821','00907') and  ANO='" & anio_ant & "' and concepto in('PERNOR','RETROA','PERVAC')  "
                            Case "00908"
                                QAcum = "select ISNULL(SUM(convert(float,monto)),0) AS 'acum' from movimientos where reloj in('00809','00908') and  ANO='" & anio_ant & "' and concepto in('PERNOR','RETROA','PERVAC')  "
                        End Select
                    Else
                        QAcum = "select ISNULL(SUM(convert(float,monto)),0) AS 'acum' from movimientos where reloj='" & rj & "' and  ANO='" & anio_ant & "' and concepto in('PERNOR','RETROA','PERVAC')  "
                    End If

                    dtAcum = sqlExecute(QAcum, "NOMINA")
                    If (dtAcum.Rows.Count > 0) Then
                        Try : acum = Double.Parse(dtAcum.Rows(0).Item("acum")) : Catch ex As Exception : acum = 0.0 : End Try
                    End If
                    If (acum >= LimSdMax) Then sueldo = LimSdMax Else sueldo = acum

                    '---Registrar ese sueldo en la tabla
                    Dim Q1 As String = "insert into ajustes_pro_esp values('" & _ano & "','" & _periodo & "','" & rj & "',null,'ACUMSD','Acum Sue'," & sueldo & ",NULL,'" & Usuario & "',NULL,'Acum Sueldo')"
                    sqlExecute(Q1, "NOMINA")

                    Application.DoEvents()
                    contador_empleados += 1
                Next
            End If

            '****************************** Parte 2 para finalizar el cálculo
            '----Obtener la suma de los sueldos
            Dim SumaSueldos As Double = 0.0
            Dim dtSumaSueldos As DataTable = sqlExecute("select ISNULL(SUM(convert(float,monto)),0) AS 'SumaSueldos' from ajustes_pro_esp where concepto='ACUMSD'", "NOMINA")
            If (Not dtSumaSueldos.Columns.Contains("Error") And dtSumaSueldos.Rows.Count > 0) Then
                Try : SumaSueldos = Double.Parse(dtSumaSueldos.Rows(0).Item("SumaSueldos")) : Catch ex As Exception : SumaSueldos = 0.0 : End Try
            End If

            Dim dtPersonal2 As DataTable = sqlExecute("select reloj,monto from ajustes_pro_esp where concepto='ACUMSD'", "NOMINA")

            If (Not dtPersonal2.Columns.Contains("Error") And dtPersonal2.Rows.Count > 0) Then

                Dim empleados_a_importar As Integer = dtPersonal2.Rows.Count
                Dim contador_empleados As Integer = 1

                For Each dr As DataRow In dtPersonal2.Rows
                    Dim rj As String = "", sueldo As Double = 0.0, PTUSUE As Double = 0.0
                    Try : rj = dr("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                    Try : sueldo = Double.Parse(dr("monto")) : Catch ex As Exception : sueldo = 0.0 : End Try

                    frmCalcPTU.lblEstatus.Text = "Calculando monto en sueldos [" & rj & "][" & contador_empleados & " de " & empleados_a_importar & "]"

                    PTUSUE = Math.Round((sueldo / SumaSueldos) * MontoSueldo, 2)

                    Dim Q2 As String = "insert into ajustes_pro_esp values('" & _ano & "','" & _periodo & "','" & rj & "',null,'PTUSUE','PTU SUELDO'," & PTUSUE & ",NULL,'" & Usuario & "',NULL,'PTU SUELDO')"
                    sqlExecute(Q2, "NOMINA")

                    Application.DoEvents()
                    contador_empleados += 1
                Next

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Cálculo Sueldos para PTU", Err.Number, ex.Message)
        End Try
    End Sub

    Public Sub GetDataFromPersonal(ByVal _ano As String, _periodo As String, _tipoNomEsp As String, _numMes As String)
        Try
            '---Datos de infonavit
            Dim dtInfonavit As New DataTable
            dtInfonavit = sqlExecute("select * from infonavit where activo = 1", "PERSONAL")

            Dim QP As String = "", periodo_act As String = ""

            If _tipoNomEsp = "agui" Then
                QP = "select * from personalvw where isnull(SACTUAL,0)<>0 and isnull(alta,'')<>'' and isnull(baja,'')='' order by reloj asc" ' Aplica a todos los activos automaticamente
            End If

            If (_tipoNomEsp = "liq_fah") Then
                QP = "select * from personalvw where isnull(baja,'')='' and reloj in (select reloj from NOMINA.dbo.saldos_liq_fah where concepto in('SAFAHC') and ano='" & _ano & "')"
            End If

            '---PTU NOTA: En esta ocasión como lo vamos a cargar manual, lo vamos a tomar de lo que ya cargamos en ajustes_pro_esp
            If (_tipoNomEsp = "ptu") Then
                QP = "select * from personalvw where reloj in (select reloj from NOMINA.dbo.ajustes_pro_esp where concepto in('PTUDIA') and ano='" & _ano & "' and periodo='" & _periodo & "')"
            End If

            Dim dtEmplAImportar As DataTable = sqlExecute(QP, "PERSONAL")

            Dim empleados_a_importar As Integer = dtEmplAImportar.Rows.Count
            Dim contador_empleados As Integer = 1
            periodo_act = _ano.Trim & _periodo.Trim & "A"

            For Each rowEmp As DataRow In dtEmplAImportar.Rows
                '  ConsultaBitacoraNomina(dtEmplAImportar, rowEmp, FiniPerAnt, FFinPerAnt) ' Consulta bitacora para conocer el valor del periodo anterior que es el que se va pagar en nomina (NOTA: No todos los campos aplican)
                Dim _reloj As String = rowEmp("reloj").ToString.Trim
                Dim esbaja As Boolean = False
                Dim _tipo_periodo As String = ""
                Try : _tipo_periodo = rowEmp("tipo_periodo").ToString.Trim : Catch ex As Exception : _tipo_periodo = "" : End Try

                If _tipoNomEsp = "agui" Then
                    frmCalcAgui.lblEstatus.Text = "Importando personal [" & _reloj & "][" & contador_empleados & " de " & empleados_a_importar & "]"
                End If

                If _tipoNomEsp = "liq_fah" Then
                    frmCalcLiqFah.lblEstatus.Text = "Importando personal [" & _reloj & "][" & contador_empleados & " de " & empleados_a_importar & "]"
                End If

                If _tipoNomEsp = "ptu" Then
                    frmCalcPTU.lblEstatus.Text = "Importando personal [" & _reloj & "][" & contador_empleados & " de " & empleados_a_importar & "]"
                End If

                sqlExecute("insert into nomina_pro_esp (ano, periodo, reloj) values ('" & _ano & "', '" & _periodo & "', '" & _reloj & "')", "nomina")

                sqlExecute("update nomina_pro_esp set procesar = 1 where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set periodo_act='" & periodo_act & "',mes='" & _numMes & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                sqlExecute("update nomina_pro_esp set cod_comp = '" & IIf(IsDBNull(rowEmp("cod_comp")), "", rowEmp("cod_comp")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set cod_planta = '" & IIf(IsDBNull(rowEmp("cod_planta")), "", rowEmp("cod_planta")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set cod_depto = '" & IIf(IsDBNull(rowEmp("cod_depto")), "", rowEmp("cod_depto")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set cod_area = '" & IIf(IsDBNull(rowEmp("cod_area")), "", rowEmp("cod_area")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set cod_super = '" & IIf(IsDBNull(rowEmp("cod_super")), "", rowEmp("cod_super")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                sqlExecute("update nomina_pro_esp set tipo_periodo = '" & IIf(IsDBNull(rowEmp("tipo_periodo")), "", rowEmp("tipo_periodo")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set cod_tipo = '" & IIf(IsDBNull(rowEmp("cod_tipo")), "", rowEmp("cod_tipo")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set cod_clase = '" & IIf(IsDBNull(rowEmp("cod_clase")), "", rowEmp("cod_clase")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                sqlExecute("update nomina_pro_esp set cod_turno = '" & IIf(IsDBNull(rowEmp("cod_turno")), "", rowEmp("cod_turno")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set cod_hora = '" & IIf(IsDBNull(rowEmp("cod_hora")), "", rowEmp("cod_hora")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set cod_puesto = '" & IIf(IsDBNull(rowEmp("cod_puesto")), "", rowEmp("cod_puesto")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set cod_costos = '" & IIf(IsDBNull(rowEmp("CENTRO_COSTOS")), "", rowEmp("CENTRO_COSTOS")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                sqlExecute("update nomina_pro_esp set nombres = '" & IIf(IsDBNull(rowEmp("nombres")), "", rowEmp("nombres")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set IMSS_PRO = '" & IIf(IsDBNull(rowEmp("IMSS")), "", rowEmp("IMSS")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set DIG_VER = '" & IIf(IsDBNull(rowEmp("DIG_VER")), "", rowEmp("DIG_VER")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set RFC = '" & IIf(IsDBNull(rowEmp("RFC")), "", rowEmp("RFC")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set CURP = '" & IIf(IsDBNull(rowEmp("CURP")), "", rowEmp("CURP")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                sqlExecute("update nomina_pro_esp set sactual = '" & IIf(IsDBNull(rowEmp("sactual")), "0", rowEmp("sactual")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set integrado = '" & IIf(IsDBNull(rowEmp("integrado")), "0", rowEmp("integrado")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set alta = '" & FechaSQL(rowEmp("alta")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                If Not IsDBNull(rowEmp("baja")) Then
                    esbaja = True
                    sqlExecute("update nomina_pro_esp set baja = '" & FechaSQL(rowEmp("baja")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                End If


                '--COD_TIPO_NOMINA : F -- Finiquitos ; N -- Nomina
                Dim cod_tipo_nomina As String = ""
                If Not IsDBNull(rowEmp("baja")) Then cod_tipo_nomina = "F" Else cod_tipo_nomina = "N"
                sqlExecute("update nomina_pro_esp set cod_tipo_nomina = '" & cod_tipo_nomina & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                '---Obtener los dias de prima vac y el porc  por aniversario en caso de que el empleado esté cumpliendo años de anviersario
                '--NOTA: PARA LA NOMINA DE AGUINALDO NO APLICA
                'GetDataVac(_reloj.ToString.Trim, rowEmp("cod_comp").ToString.Trim, rowEmp("cod_tipo").ToString.Trim, FechaSQL(rowEmp("alta")), rowEmp("tipo_periodo").ToString.Trim, _fecha_ini, _fecha_fin, FIniCat, FFinCat)
                'sqlExecute("update nomina_pro_esp set privac_dias = '" & privac_dias & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                'sqlExecute("update nomina_pro_esp set privac_porc = '" & privac_porc & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina") ' NOTA: Se inserta como viene, si es 25 asi se llena
                '---Ends PrimaVac y Porc PrimaVac

                '***************-Tarjetas y vales 
                Dim CUENTA_BANCO As String = "", CLABE As String = ""
                Try : CUENTA_BANCO = rowEmp("CUENTA_BANCO").ToString.Trim : Catch ex As Exception : CUENTA_BANCO = "" : End Try
                Try : CLABE = rowEmp("CLABE").ToString.Trim : Catch ex As Exception : CLABE = "" : End Try

                sqlExecute("update nomina_pro_esp set BANCO = '" & IIf(IsDBNull(rowEmp("BANCO")), "", rowEmp("BANCO")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set CUENTA_BANCO = '" & CUENTA_BANCO & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set TARJETA_BANCO = '" & IIf(IsDBNull(rowEmp("TARJETA_BANCO")), "", rowEmp("TARJETA_BANCO")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set CLABE = '" & CLABE & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set CUENTA_BONOS = '" & IIf(IsDBNull(rowEmp("CUENTA_BONOS")), "", rowEmp("CUENTA_BONOS")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
                sqlExecute("update nomina_pro_esp set TARJETA_BONOS = '" & IIf(IsDBNull(rowEmp("TARJETA_BONOS")), "", rowEmp("TARJETA_BONOS")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                '--cod_pago D - Depósito ; E - Efectivo
                Dim cod_pago As String = ""
                If (CUENTA_BANCO = "" And CLABE = "") Then cod_pago = "E" Else cod_pago = "D"
                sqlExecute("update nomina_pro_esp set cod_pago = '" & cod_pago & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

                'INFONAVIT
                Dim drInf As DataRow = Nothing
                Try : drInf = dtInfonavit.Select("reloj ='" & _reloj & "'")(0) : Catch ex As Exception : drInf = Nothing : End Try
                If (Not IsNothing(drInf)) Then
                    sqlExecute("update nomina_pro_esp set infonavit_credito = '" & drInf("infonavit") & "' where reloj = '" & _reloj & "'", "nomina")
                    sqlExecute("update nomina_pro_esp set tipo_credito = '" & drInf("tipo_cred") & "' where reloj = '" & _reloj & "'", "nomina")
                    sqlExecute("update nomina_pro_esp set cuota_credito = '" & drInf("cuota_cred") & "' where reloj = '" & _reloj & "'", "nomina")
                    sqlExecute("update nomina_pro_esp set inicio_credito = '" & drInf("inicio_cre") & "' where reloj = '" & _reloj & "'", "nomina")
                    sqlExecute("update nomina_pro_esp set cobro_segviv= '" & drInf("cobro_segv") & "' where reloj = '" & _reloj & "'", "nomina")

                End If

                '--MAESTRO DE DEDUCCIONES
                '-- NOTA: No aplica para NOMINA DE AGUINALDO
                'For Each drMtDed As DataRow In dtMtroDed.Select("reloj='" & _reloj & "'")
                '    Dim concepto As String = "", saldo_act As Double = 0.0, abono_act As Double = 0.0, descrip As String = ""

                '    Try : concepto = drMtDed("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                '    Try : descrip = drMtDed("descrip").ToString.Trim : Catch ex As Exception : descrip = "" : End Try
                '    Try : saldo_act = drMtDed("saldo_act") : Catch ex As Exception : saldo_act = 0.0 : End Try
                '    Try : abono_act = drMtDed("abono_act") : Catch ex As Exception : abono_act = 0.0 : End Try


                '    If (esbaja) Then ' Si es una baja (Finiquito), traerse todo el saldo que debe para que lo descuente
                '        abono_act = saldo_act
                '    End If


                '    If (saldo_act <= abono_act) Then abono_act = saldo_act

                '    sqlExecute("insert into ajustes_pro (ano, periodo, reloj,per_ded, concepto,descrip, monto,origen) values ('" & _ano & "', '" & _periodo & "', '" & _reloj & "','D', '" & concepto & "','" & descrip & "', '" & abono_act & "','" & Usuario & "')", "nomina")

                'Next

                Application.DoEvents()
                contador_empleados += 1
            Next


            '----Agrupar un solo concepto para aquellos conceptos que se repitan del maestro de deducciones y dejar la suma total del monto por cada concepto
            Try
                Dim QBuscaRep As String = "SELECT ano,periodo,reloj,concepto,descrip,count(*) as totRepetidos from ajustes_pro_esp group by ano,periodo,reloj,concepto,descrip having count(*)>1"
                Dim dtBuscaRep As DataTable = sqlExecute(QBuscaRep, "NOMINA")
                If (Not dtBuscaRep.Columns.Contains("Error") And dtBuscaRep.Rows.Count > 0) Then
                    For Each row As DataRow In dtBuscaRep.Rows
                        Dim anio As String = "", per As String = "", rj As String = "", _concepto As String = "", _descrip As String = "", _monto As Double = 0.0

                        Try : anio = row("ano").ToString.Trim : Catch ex As Exception : anio = "" : End Try
                        Try : per = row("periodo").ToString.Trim : Catch ex As Exception : per = "" : End Try
                        Try : rj = row("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                        Try : _concepto = row("concepto").ToString.Trim : Catch ex As Exception : _concepto = "" : End Try
                        Try : _descrip = row("descrip").ToString.Trim : Catch ex As Exception : _descrip = "" : End Try

                        Dim QMonto As String = "select sum(monto) AS monto,ano,periodo,reloj,concepto from ajustes_pro_esp where ano='" & anio & "' and periodo='" & per & "' and reloj='" & rj & "' and concepto='" & _concepto & "' GROUP BY ano,periodo,reloj,concepto "
                        Dim dtMonto As DataTable = sqlExecute(QMonto, "NOMINA")
                        If (dtMonto.Rows.Count > 0) Then
                            Try : _monto = Double.Parse(dtMonto.Rows(0).Item("monto")) : Catch ex As Exception : _monto = 0.0 : End Try
                        End If

                        sqlExecute("delete from ajustes_pro_esp where ano='" & anio & "' and periodo='" & per & "' and reloj='" & rj & "' and concepto='" & _concepto & "'", "NOMINA")

                        sqlExecute("insert into ajustes_pro_esp (ano, periodo, reloj,per_ded, concepto,descrip, monto,origen) values ('" & anio & "', '" & per & "', '" & rj & "','D', '" & _concepto & "','" & _descrip & "', '" & _monto & "','" & Usuario & "')", "nomina")
                    Next
                End If
            Catch ex As Exception

            End Try
            '----ENDS de agrupar

        Catch ex As Exception

        End Try
    End Sub

    Public Function InsertMovsPro_esp(ByRef an As String, per As String, rj As String, tnom As String, tPer As String, conc As String, mto As Double, prio As Integer, imp As Integer) As Integer
        Dim insertado As Integer = 0
        Dim RowsInsert As Integer = 0
        Try
            Dim qInsert As String = "insert into movimientos_pro_esp (ano,periodo,reloj,tipo_nomina,tipo_periodo,concepto,monto,prioridad,importar) " & _
                "values ('" & an & "','" & per & "','" & rj & "','" & tnom & "','" & tPer & "','" & conc & "'," & mto & "," & prio & "," & imp & ")"

            Dim dtRowsCount As DataTable = sqlExecute(qInsert & " select @@ROWCOUNT as 'RowsInsert'", "NOMINA")
            Try : RowsInsert = Convert.ToInt32(dtRowsCount.Rows(0).Item("RowsInsert").ToString.Trim) : Catch ex As Exception : RowsInsert = 0 : End Try
            If (RowsInsert > 0) Then insertado = 1
            Return insertado
        Catch ex As Exception
            Return insertado
        End Try
    End Function

    

    Public Function puente_esp(ByVal _anio As String, ByVal _periodo As String, ByVal _reloj As String, ByVal _monto As Double, ByVal _tipo_nom As String, ByVal _tipo_per As String, ByVal _concepto As String, ByVal _dtConceptos As DataTable) As Integer
        Try
            '--Validar si el concepto esa activo
            Dim ACTIVO As Integer = 0
            Dim SUMA_NETO As Integer = 0
            Dim COD_NATURALEZA As String = ""
            Dim PRIORIDAD As Integer = 0
            Dim IMPORTAR As Integer = 0
            Dim concepto_saldo As String = ""
            Dim saldo_tmp As Double = 0.0

            Dim drowConcepto As DataRow = Nothing
            Try : drowConcepto = _dtConceptos.Select("concepto='" & _concepto & "'")(0) : Catch ex As Exception : drowConcepto = Nothing : End Try

            If (IsNothing(drowConcepto)) Then ' Si no lo encontró, agregar dicho concepto y mandar alerta
                Dim QInsertConc As String = "Insert into conceptos (cod_tipo_nomina,cod_naturaleza,concepto,nombre,prioridad,activo) VALUES " & _
                    "('" & _tipo_nom & "','I','" & _concepto & "','Concepto nuevo','999',1)"
                sqlExecute(QInsertConc, "NOMINA")
                MessageBox.Show("Se ha dado de alta el concepto:" & _concepto.Trim & ", favor de actualizar campos en la tabla CONCEPTOS", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If (Not IsNothing(drowConcepto)) Then ' Si lo encontró
                Try : ACTIVO = drowConcepto("ACTIVO") : Catch ex As Exception : ACTIVO = 0 : End Try
                Try : SUMA_NETO = drowConcepto("SUMA_NETO") : Catch ex As Exception : SUMA_NETO = 0 : End Try
                Try : COD_NATURALEZA = drowConcepto("COD_NATURALEZA").ToString.Trim : Catch ex As Exception : COD_NATURALEZA = "" : End Try
                Try : PRIORIDAD = drowConcepto("PRIORIDAD") : Catch ex As Exception : PRIORIDAD = 0 : End Try
                Try : IMPORTAR = drowConcepto("IMPORTAR") : Catch ex As Exception : IMPORTAR = 0 : End Try
                Try : concepto_saldo = drowConcepto("concepto_saldo").ToString.Trim : Catch ex As Exception : concepto_saldo = "" : End Try
            End If

            _monto = Math.Round(_monto, 2)

            If ACTIVO = 0 Then _monto = 0.0

            '---Ir acumulando el neto para cada concepto, solo si suma al neto
            If SUMA_NETO = 1 Then
                Select Case COD_NATURALEZA
                    Case "P"
                        acum_neto = acum_neto + _monto
                        acum_percep = acum_percep + _monto
                    Case "D"
                        acum_deduc = acum_deduc + _monto
                        If ((acum_neto >= _monto) And (acum_neto > 0)) Then
                            acum_neto = acum_neto - _monto
                            GoTo Salir
                        End If

                        If ((acum_neto < _monto) And (acum_neto > 0)) Then
                            _monto = acum_neto
                            acum_neto = acum_neto - _monto
                            GoTo Salir
                        End If

                        If ((acum_neto < _monto) And (acum_neto <= 0)) Then
                            _monto = 0.0
                            acum_neto = 0.0
                            GoTo Salir
                        End If
salir:
                End Select
            End If

            '---Incluir saldos
            If (concepto_saldo <> "") Then
                '-- Buscar en ajustesPro si viene un valor
                Dim dtBuscaSaldo As DataTable = sqlExecute("select * from ajustes_pro_esp where reloj='" & _reloj & "' and concepto='" & _concepto & "'", "NOMINA")
                If (Not dtBuscaSaldo.Columns.Contains("Error") And dtBuscaSaldo.Rows.Count > 0) Then
                    Try : saldo_tmp = Double.Parse(dtBuscaSaldo.Rows(0).Item("saldo")) - _monto : Catch ex As Exception : saldo_tmp = 0.0 : End Try
                End If
            End If


            '--Agregarlo en movimientos_pro
            If ((_monto <> 0 Or _concepto = "NETO" Or _concepto = "TOTPER" Or _concepto = "TOTDED") And ACTIVO = 1) Then
                If existsMovsPro_esp(_anio, _periodo, _reloj, _concepto) = 0 Then  ' Si no existe, agregarlo  PEND: Faltaria buscarlo por tipo de nom ??
                    If (InsertMovsPro_esp(_anio, _periodo, _reloj, _tipo_nom, _tipo_per, _concepto, _monto, PRIORIDAD, IMPORTAR) = 0) Then
                        MessageBox.Show("No se agregó  en movimientos_pro_esp el empleado con número:" & _reloj & ", concepto:" & _concepto & ", monto:" & _monto & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Else ' Si ya existe dicho movimiento, solo actualizarlo
                    If (UpdateMovsPro_esp(_anio, _periodo, _reloj, _tipo_nom, _tipo_per, _concepto, _monto, PRIORIDAD, IMPORTAR) = 0) Then
                        MessageBox.Show("No se pudo actualizar  en movimientos_pro_esp el empleado con número:" & _reloj & ", concepto:" & _concepto & ", monto:" & _monto & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If
            End If

            '--Incluir ese saldo
            If (saldo_tmp <> 0) Then
                If existsMovsPro_esp(_anio, _periodo, _reloj, concepto_saldo) = 0 Then ' Si no existe dicho mov, agregarlo
                    If (InsertMovsPro_esp(_anio, _periodo, _reloj, _tipo_nom, _tipo_per, concepto_saldo, saldo_tmp, PRIORIDAD, IMPORTAR) = 0) Then
                        MessageBox.Show("No se agregó  en movimientos_pro_esp el empleado con número:" & _reloj & ", concepto:" & concepto_saldo & ", monto:" & saldo_tmp & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else ' Si ya existe dicho movimiento, solo actualizarlo
                    If (UpdateMovsPro_esp(_anio, _periodo, _reloj, _tipo_nom, _tipo_per, concepto_saldo, saldo_tmp, PRIORIDAD, IMPORTAR) = 0) Then
                        MessageBox.Show("No se pudo actualizar  en movimientos_pro_esp el empleado con número:" & _reloj & ", concepto:" & concepto_saldo & ", monto:" & saldo_tmp & ", favor de revisar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function UpdateMovsPro_esp(ByRef an As String, per As String, rj As String, tnom As String, tPer As String, conc As String, mto As Double, prio As Integer, imp As Integer) As Integer
        Dim Actualizado As Integer = 0
        Dim RowsUpdate As Integer = 0
        Try
            Dim qUpdate As String = "update movimientos_pro_esp set monto=" & mto & ",prioridad=" & prio & ",importar=" & prio & _
                                    " where reloj='" & rj & "' and concepto='" & conc & "'"


            Dim dtRowsCount As DataTable = sqlExecute(qUpdate & " select @@ROWCOUNT as 'RowsUpdate'", "NOMINA")
            Try : RowsUpdate = Convert.ToInt32(dtRowsCount.Rows(0).Item("RowsUpdate").ToString.Trim) : Catch ex As Exception : RowsUpdate = 0 : End Try
            If (RowsUpdate > 0) Then Actualizado = 1
            Return Actualizado
        Catch ex As Exception
            Return Actualizado
        End Try
    End Function

    Public Function existsMovsPro_esp(ByRef an As String, per As String, rj As String, conc As String) As Integer ' PEND: Faltaria buscarlo por tipo de nom ??
        Dim existe As Integer = 1
        Try
            Dim anioPer As String = an & per
            Dim qBusca As String = "select * from movimientos_pro_esp where ano+periodo='" & anioPer & "' and reloj='" & rj & "' and concepto='" & conc & "'"
            Dim dtBuscaMovsPro As DataTable = sqlExecute(qBusca, "NOMINA")

            If (Not dtBuscaMovsPro.Columns.Contains("Error") And dtBuscaMovsPro.Rows.Count = 0) Then existe = 0

            Return existe

        Catch ex As Exception
            Return existe
        End Try
    End Function

    Public Function CalcISR142(ByRef _rj As String, _pergra As Double, tipo_per As String, _tabla As String, _dias_pagados As Double, _dtAjustesPro As DataTable, _aplica_ajsupe As Integer, _acum_per_gravada As Double, _sactual As Double, _tipoNomProc As String) As Double ' Función para calcular nominas especiales por ART 142
        Dim Res As Double = 0.0
        If (_dias_pagados = 0 Or _pergra = 0) Then Return Res
        Dim diasAnio As Double = 365.0
        Dim smensual As Double = _sactual * 30.4
        Try
            Dim lim_inf As Double = 0.0
            Dim cta_fija As Double = 0.0
            Dim porcentaje As Double = 0.0
            Dim GravDiario As Double = 0.0
            Dim GravMens As Double = 0.0
            Dim impABusc1 = 0.0
            Dim exedente As Double = 0.0
            Dim imp_marginal As Double = 0.0
            Dim isrCau1 As Double = 0.0
            Dim isrCau2 As Double = 0.0
            Dim subCau1 As Double = 0.0
            Dim subCau2 As Double = 0.0
            Dim subsidio_mensual As Double = 0.0
            Dim DifIsr As Double = 0.0
            Dim FacIsr As Double = 0.0

            Dim QBuscaIsr1 As String = ""
            Dim dtBuscaIsr1 As New DataTable

            Dim QBuscaIsr2 As String = ""
            Dim dtBuscaIsr2 As New DataTable


            If (_tipoNomProc = "agui" Or _tipoNomProc = "ptu") Then

                '---*******CALCULAR ISRCAU 1
                GravDiario = _pergra / diasAnio ' para aguinaldo
                GravMens = GravDiario * 30.4 ' Para el aguinaldo
                impABusc1 = smensual + GravMens ' Para el aguinaldo

                QBuscaIsr1 = "select top 1 * from tablas_isr where lim_inf <= " & impABusc1 & " and periodo='" & tipo_per & "' and tabla='" & _tabla & "' order by lim_inf desc"
                dtBuscaIsr1 = sqlExecute(QBuscaIsr1, "NOMINA")
                If (Not dtBuscaIsr1.Columns.Contains("Error") And dtBuscaIsr1.Rows.Count > 0) Then
                    Try : lim_inf = Double.Parse(dtBuscaIsr1.Rows(0).Item("lim_inf")) : Catch ex As Exception : lim_inf = 0.0 : End Try
                    Try : cta_fija = Double.Parse(dtBuscaIsr1.Rows(0).Item("cta_fija")) : Catch ex As Exception : cta_fija = 0.0 : End Try
                    Try : porcentaje = Double.Parse(dtBuscaIsr1.Rows(0).Item("porcentaje")) : Catch ex As Exception : porcentaje = 0.0 : End Try
                End If

                exedente = impABusc1 - lim_inf
                imp_marginal = exedente * porcentaje
                isrCau1 = imp_marginal + cta_fija

                '--Obt Sub Cau 1
                If (_tipoNomProc = "agui") Then
                    subCau1 = CalcSubempleo(impABusc1, "M", "Sub")
                    isrCau1 = isrCau1 - subCau1
                End If


                '---*******CALCULAR ISRCAU 2
                QBuscaIsr2 = "select top 1 * from tablas_isr where lim_inf <= " & smensual & " and periodo='" & tipo_per & "' and tabla='" & _tabla & "' order by lim_inf desc"
                dtBuscaIsr2 = sqlExecute(QBuscaIsr2, "NOMINA")
                If (Not dtBuscaIsr2.Columns.Contains("Error") And dtBuscaIsr1.Rows.Count > 0) Then
                    Try : lim_inf = Double.Parse(dtBuscaIsr2.Rows(0).Item("lim_inf")) : Catch ex As Exception : lim_inf = 0.0 : End Try
                    Try : cta_fija = Double.Parse(dtBuscaIsr2.Rows(0).Item("cta_fija")) : Catch ex As Exception : cta_fija = 0.0 : End Try
                    Try : porcentaje = Double.Parse(dtBuscaIsr2.Rows(0).Item("porcentaje")) : Catch ex As Exception : porcentaje = 0.0 : End Try
                End If

                exedente = smensual - lim_inf
                imp_marginal = exedente * porcentaje
                isrCau2 = imp_marginal + cta_fija

                '--Obt SubCau2
                If (_tipoNomProc = "agui") Then
                    subCau2 = CalcSubempleo(smensual, "M", "Sub")
                    isrCau2 = isrCau2 - subCau2
                End If


                DifIsr = isrCau1 - isrCau2

                If (DifIsr <= 0) Then ' Si la diferencia entre los 2 ISR's da cero o menor de cero, no habrá isr a retener
                    isrRetenido = 0.0
                    isrCausado = 0.0
                    subempleoCausado = 0.0
                    subempleoPagado = 0.0
                    GoTo Saltar1
                End If

                FacIsr = DifIsr / GravMens
                isrRetenido = FacIsr * _pergra  '--- Este es el ISR  A Retener finalmwente
                isrCausado = isrRetenido
                subempleoCausado = subCau1 + subCau2
                subempleoPagado = 0.0 ' Para Agui y ptu no aplica subsidio pagado con este metodo 142
            End If

saltar1:
            Res = isrRetenido

            Return Res
        Catch ex As Exception
            Return Res

        End Try
    End Function

    Public Sub AcumulaPeriodos(ByVal anio As String, periodos As String)
        Try
            '---Mostrar Progress
            Dim i As Integer = -1
            frmTrabajando.Text = "Acumulando nóminas"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Acumulando nóminas"
            ActivoTrabajando = True
            frmTrabajando.Show()
            Application.DoEvents()


            sqlExecute("TRUNCATE TABLE acumula_mov", "NOMINA")
            Dim QDistRj As String = "select distinct reloj from movimientos where ano=" & anio & " and PERIODO in (" & periodos & ") order by reloj asc"

            Dim dtDistRj As DataTable = sqlExecute(QDistRj, "NOMINA")
            If (Not dtDistRj.Columns.Contains("Error") And dtDistRj.Rows.Count > 0) Then

                '--Mostrar progress
                frmTrabajando.Avance.IsRunning = False
                frmTrabajando.lblAvance.Text = "Procesando datos"
                Application.DoEvents()
                frmTrabajando.Avance.Maximum = dtDistRj.Rows.Count

                For Each rwRj As DataRow In dtDistRj.Rows
                    Dim dtDistConcep As New DataTable
                    Dim reloj As String = ""

                    Try : reloj = rwRj("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try

                    dtDistConcep = sqlExecute("select distinct concepto from movimientos where ano=" & anio & " and PERIODO in (" & periodos & ") and reloj='" & reloj & "'", "NOMINA")

                    '----Mostrar Progress - avance
                    i += 1
                    frmTrabajando.Avance.Value = i
                    frmTrabajando.lblAvance.Text = reloj
                    Application.DoEvents()
                    '----Ends Avance


                    If (Not dtDistConcep.Columns.Contains("Error") And dtDistConcep.Rows.Count > 0) Then
                        For Each rwConc As DataRow In dtDistConcep.Rows
                            Dim dtMonto As New DataTable
                            Dim concepto As String = "", monto As Double = 0.0, query As String = ""

                            Try : concepto = rwConc("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                            query = "select ISNULL(SUM(convert(float,monto)),0) AS 'monto' from movimientos where  ANO=" & anio & " and concepto='" & concepto & "'  and periodo in (" & periodos & ") and reloj='" & reloj & "'"
                            dtMonto = sqlExecute(query, "NOMINA")

                            If (Not dtMonto.Columns.Contains("Error") And dtMonto.Rows.Count > 0) Then
                                Try : monto = Double.Parse(dtMonto.Rows(0).Item("monto")) : Catch ex As Exception : monto = 0.0 : End Try
                            End If

                            If (monto <> 0 And concepto.Trim <> "") Then
                                sqlExecute("insert into acumula_mov values (" & anio & ",'','N','" & reloj & "','" & concepto & "'," & monto & ",1,1,NULL,'','')", "NOMINA")
                            End If

                        Next
                    End If
                Next

                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()

            End If

        Catch ex As Exception

            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()


            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    '---- Función para calcular el ISR ANUAL
    Public Function CalcISRAnual(ByRef _rj As String, _pergra As Double, tipo_per As String, _tabla As String, _isrRet As Double, _subCau As Double, _codComp As String, _ano As String, _aplica As Integer) As Double
        Dim Res As Double = 0.0


        Try
            Dim lim_inf As Double = 0.0
            Dim exedente As Double = 0.0
            Dim porcentaje As Double = 0.0
            Dim imp_marginal As Double = 0.0
            Dim cta_fija As Double = 0.0
            Dim isr As Double = 0.0
            Dim isr_causado As Double = 0.0
            Dim difIsr As Double = 0.0
            Dim aFavor As Integer = 0



            Dim Qbusca As String = "select top 1 * from tablas_isr where lim_inf <= " & _pergra & " and periodo='" & tipo_per & "' and tabla='" & _tabla & "' order by lim_inf desc"
            Dim dtBuscaIsr As DataTable = sqlExecute(Qbusca, "NOMINA")
            If (Not dtBuscaIsr.Columns.Contains("Error") And dtBuscaIsr.Rows.Count > 0) Then
                Try : lim_inf = Double.Parse(dtBuscaIsr.Rows(0).Item("lim_inf")) : Catch ex As Exception : lim_inf = 0.0 : End Try
                Try : cta_fija = Double.Parse(dtBuscaIsr.Rows(0).Item("cta_fija")) : Catch ex As Exception : cta_fija = 0.0 : End Try
                Try : porcentaje = Double.Parse(dtBuscaIsr.Rows(0).Item("porcentaje")) : Catch ex As Exception : porcentaje = 0.0 : End Try
            End If

            exedente = _pergra - lim_inf
            imp_marginal = exedente * porcentaje
            isr = imp_marginal + cta_fija

            '--Restarle el subsidio causado del año
            If (isr > _subCau) Then
                isrCausado = isr - _subCau
            Else
                isrCausado = 0.0
            End If

            '---AOS: 22/09/2021 Comenta el INg Acosta, que si no aplica ya sea por que es baja, o tiene menos de 365 días del año, o tiene ingresos superiores a 400,000, el isr Ret es igual al isr causado para efectos de presentación
            If (_aplica = 0) Then
                _isrRet = isrCausado
                difIsr = 0.0
                sqlExecute("update isranual_nom_pro set isrret=" & _isrRet & " where cod_comp='" & _codComp & "' and ano='" & _ano & "' and reloj='" & _rj & "'", "NOMINA")
                aFavor = 0
                GoTo UpdateTable
            End If

            '--Obtener la dif de Isr entre la causado y el retenido en el anio
            difIsr = isrCausado - _isrRet

            '--Si el isr causado es menor al retenido, es a favor, y de lo contrario, es en contra
            If (difIsr < 0) Then
                difIsr = difIsr * -1
                aFavor = 1
            Else
                aFavor = 0
            End If


UpdateTable:
            sqlExecute("update isranual_nom_pro set difisr=" & difIsr & " where cod_comp='" & _codComp & "' and ano='" & _ano & "' and reloj='" & _rj & "'", "NOMINA")
            sqlExecute("update isranual_nom_pro set afavor=" & aFavor & " where cod_comp='" & _codComp & "' and ano='" & _ano & "' and reloj='" & _rj & "'", "NOMINA")

            Res = isrCausado

            Return Res
        Catch ex As Exception
            Return Res

        End Try
    End Function

End Module
