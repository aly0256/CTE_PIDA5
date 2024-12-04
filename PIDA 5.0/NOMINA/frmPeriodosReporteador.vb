Imports System.IO

Public Class frmPeriodosReporteador

    Public siguiente As Integer = 0

    Dim dtPeriodos As New DataTable
    Dim dtTemp As New DataTable
    Dim dtTipoPoliza As New DataTable
    Dim dtTipo As New DataTable
    Dim dtCias As New DataTable
    Dim dtInfoPoliza As New DataTable
    Dim dtPoliza As New DataTable

    Private Sub frmForma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ndRoot As DevComponents.AdvTree.Node
        Dim ndChild As DevComponents.AdvTree.Node
        Dim dtAnos As New DataTable
        Dim ndSeleccionado As New DevComponents.AdvTree.Node

        Try
            '**** PERIODOS ****

            'Periodo activo
            'Marcar como activo el ultimo periodo semanal con informacion | ACASAS 20180122
            dtTemp = sqlExecute("SELECT MAX(ano+periodo) as AnoPeriodo FROM nomina WHERE periodo<='53' and tipo_periodo = 'S'", "NOMINA")
            If dtTemp.Rows.Count > 0 Then
                If IsDBNull(dtTemp.Rows(0).Item("anoperiodo")) Then
                    AnoSelec = ""
                    PeriodoSelec = ""
                Else
                    AnoSelec = dtTemp.Rows(0).Item("AnoPeriodo").ToString.Trim.Substring(0, 4)
                    PeriodoSelec = dtTemp.Rows(0).Item("AnoPeriodo").ToString.Trim.Substring(4, 2)
                End If

            Else
                AnoSelec = ""
                PeriodoSelec = ""
            End If

            'Años
            dtAnos = sqlExecute("SELECT DISTINCT ano FROM periodos ORDER BY ano DESC", "TA")

            'Limpiar el treeview, por si tiene información
            trPeriodos.Nodes.Clear()
            For Each dRow As DataRow In dtAnos.Rows
                'Crear nodo para el grupo
                ndRoot = New DevComponents.AdvTree.Node
                ndRoot.Name = dRow("ano")
                ndRoot.Text = dRow("ano")
                ndRoot.CheckBoxVisible = False
                'Si el periodo seleccionado es de este año, dejar abierto
                'ndRoot.Expanded = (dRow("ano") = AnoSelec)
                ndRoot.Expanded = False

                If dRow("ano") = AnoSelec Then
                    'ndRoot.CheckState = CheckState.Indeterminate
                End If
                'Obtener periodos del año a cargar


                Dim nodoSemanales = New DevComponents.AdvTree.Node
                nodoSemanales.Name = "Semanal"
                nodoSemanales.Text = "Semanal"
                nodoSemanales.CheckBoxVisible = False
                'Si el periodo seleccionado es de este año, dejar abierto
                'nodoSemanales.Expanded = (dRow("ano") = AnoSelec)
                nodoSemanales.Expanded = False

                dtPeriodos = sqlExecute("SELECT ano,periodo,mes,fecha_ini,fecha_fin,nombre FROM periodos WHERE ANO = '" & dRow("ano") & "'", "TA")

                For Each dPer As DataRow In dtPeriodos.Rows
                    'Celdas del nodo de año
                    ndChild = New DevComponents.AdvTree.Node
                    ndChild.CheckBoxVisible = True

                    'Si es el periodo activo, seleccionar por default
                    'y asignar este periodo para ser el nodo seleccionado
                    'If dPer("periodo") = PeriodoSelec And dRow("ano") = AnoSelec Then
                    '    'ndChild.Checked = True
                    '    'ndSeleccionado = ndChild
                    'End If

                    'Pasar los valores del periodo a cada celda
                    ndChild.Text = dPer("periodo")
                    ndChild.Cells.Add(New DevComponents.AdvTree.Cell(IIf(IsDBNull(dPer("periodo")), "", dPer("periodo"))))
                    ndChild.Cells.Add(New DevComponents.AdvTree.Cell(IIf(IsDBNull(dPer("fecha_ini")), "", dPer("fecha_ini"))))
                    ndChild.Cells.Add(New DevComponents.AdvTree.Cell(IIf(IsDBNull(dPer("fecha_fin")), "", dPer("fecha_fin"))))
                    ndChild.Cells.Add(New DevComponents.AdvTree.Cell(IIf(IsDBNull(dPer("mes")), "", dPer("mes"))))
                    ndChild.Cells.Add(New DevComponents.AdvTree.Cell(IIf(IsDBNull(dPer("nombre")), "", dPer("nombre"))))
                    ndChild.Cells.Add(New DevComponents.AdvTree.Cell(IIf(IsDBNull(dPer("ano")), "", dPer("ano"))))

                    'Agregar las celdas al nodo
                    nodoSemanales.Nodes.Add(ndChild)
                Next
                'Agregar el nodo al árbol


                Dim nodoQuincenales = New DevComponents.AdvTree.Node
                nodoQuincenales.Name = "Catorcenal"
                nodoQuincenales.Text = "Catorcenal"
                nodoQuincenales.CheckBoxVisible = False
                'Si el periodo seleccionado es de este año, dejar abierto
                'nodoQuincenales.Expanded = (dRow("ano") = AnoSelec)
                nodoQuincenales.Expanded = False

                dtPeriodos = sqlExecute("SELECT ano,periodo,mes,fecha_ini,fecha_fin,nombre FROM periodos_catorcenal WHERE ANO = '" & dRow("ano") & "'", "TA")

                For Each dPer As DataRow In dtPeriodos.Rows
                    'Celdas del nodo de año
                    ndChild = New DevComponents.AdvTree.Node
                    ndChild.CheckBoxVisible = True

                    ''Si es el periodo activo, seleccionar por default
                    ''y asignar este periodo para ser el nodo seleccionado
                    'If dPer("periodo") = PeriodoSelec And dRow("ano") = AnoSelec Then
                    '    ndChild.Checked = True
                    '    ndSeleccionado = ndChild
                    'End If

                    'Pasar los valores del periodo a cada celda
                    ndChild.Text = dPer("periodo")
                    ndChild.Cells.Add(New DevComponents.AdvTree.Cell(IIf(IsDBNull(dPer("periodo")), "", dPer("periodo"))))
                    ndChild.Cells.Add(New DevComponents.AdvTree.Cell(IIf(IsDBNull(dPer("fecha_ini")), "", dPer("fecha_ini"))))
                    ndChild.Cells.Add(New DevComponents.AdvTree.Cell(IIf(IsDBNull(dPer("fecha_fin")), "", dPer("fecha_fin"))))
                    ndChild.Cells.Add(New DevComponents.AdvTree.Cell(IIf(IsDBNull(dPer("mes")), "", dPer("mes"))))
                    ndChild.Cells.Add(New DevComponents.AdvTree.Cell(IIf(IsDBNull(dPer("nombre")), "", dPer("nombre"))))
                    ndChild.Cells.Add(New DevComponents.AdvTree.Cell(IIf(IsDBNull(dPer("ano")), "", dPer("ano"))))

                    'Agregar las celdas al nodo
                    nodoQuincenales.Nodes.Add(ndChild)
                Next
                'Agregar el nodo al árbol

                ndRoot.Nodes.Add(nodoSemanales)
                ndRoot.Nodes.Add(nodoQuincenales)
                trPeriodos.Nodes.Add(ndRoot)
            Next
            'Seleccionar el periodo activo dentro del árbol
            trPeriodos.SelectedNode = ndSeleccionado

            Dim SelecPer As String = ""
            For Each C In trPeriodos.CheckedNodes
                SelecPer = SelecPer & IIf(SelecPer.Length > 0, ", ", "") & C.Text & "-" & C.Cells(5).Text
            Next
            txtPeriodos.Text = SelecPer

            '**** Compañías ****
            dtCias = sqlExecute("SELECT cod_comp,nombre FROM cias ORDER BY cia_default DESC")
            dtCias.Rows.Add({"***", "Consolidado"})
            cmbCompania.DataSource = dtCias

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Try
            Dim x As Integer
            Dim Ano As String = ""
            Dim Per As String = ""
            Dim TP As String = "" ' AOS

            'Seleccionar los periodos marcados, para pasarlos a un arreglo de texto
            ReDim PeriodosReporteador(trPeriodos.CheckedNodes.Count - 1)
            x = 0
            For Each C In trPeriodos.CheckedNodes
                If Ano <> C.Cells(6).Text Then
                    Ano = Ano & IIf(Ano.Length > 0, ", ", "") & C.Cells(6).Text
                End If
                Per = Per & IIf(Per.Length = 0, "", ", ") & C.Text
                PeriodosReporteador(x) = C.Cells(6).Text & C.Text & C.Parent.Text.Substring(0, 1)
                x = x + 1
            Next
            If x = 0 Then
                MessageBox.Show("Debe seleccionar al menos un periodo pare el reportedor. Favor de verificar.", "Seleccionar periodo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                trPeriodos.Focus()
                Exit Sub
            End If

            '----- Validar para acumulado  AOS (2020-12-16)
            Dim totPer As Integer = PeriodosReporteador.Count

            If (totPer > 1) Then

                AcumularNom = True

                For Each I In PeriodosReporteador
                    Ano = I.Substring(0, 4)
                    Per = I.Substring(4, 2)
                    TP = I.Substring(6, 1)

                    If (Not aniosRepNom.Contains(Ano)) Then aniosRepNom = aniosRepNom & "'" & Ano.Trim & "',"
                    If (Not persRepNom.Contains(Per)) Then persRepNom = persRepNom & "'" & Per.Trim & "',"
                    If (Not TipoPersNom.Contains(TP)) Then TipoPersNom = TipoPersNom & "'" & TP.Trim & "',"

                Next

                aniosRepNom = aniosRepNom.TrimStart(",")
                aniosRepNom = aniosRepNom.TrimEnd(",")
                persRepNom = persRepNom.TrimStart(",")
                persRepNom = persRepNom.TrimEnd(",")
                TipoPersNom = TipoPersNom.TrimStart(",")
                TipoPersNom = TipoPersNom.TrimEnd(",")

                '---No se puede acumular mas de 1 año diferente o más de un tipo de periodo diferente
                If (aniosRepNom.Contains(",")) Then
                    MessageBox.Show("No debe de seleccionar más de un año para acumular", "Seleccionar periodo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    trPeriodos.Focus()
                    Exit Sub
                End If

            Else
                AcumularNom = False

            End If

            '-----Ends Valida acumulado

            CiaReporteador = cmbCompania.SelectedValue
            Me.Hide()

            Select Case siguiente
                Case 0
                    frmReporteadorNomina.MdiParent = frmMain
                    frmReporteadorNomina.WindowState = FormWindowState.Maximized
                    frmReporteadorNomina.Show()
                    frmReporteadorNomina.Focus()
                Case 1
                    Dim frm As New frmCondensadoNomina
                    frm.Show()
                    frm.Focus()
                Case Else
                    frmReporteadorNomina.MdiParent = frmMain
                    frmReporteadorNomina.WindowState = FormWindowState.Maximized
                    frmReporteadorNomina.Show()
                    frmReporteadorNomina.Focus()
            End Select


            Me.Close()
            Me.Dispose()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Me.DialogResult = Windows.Forms.DialogResult.Abort
            Me.Close()
            Me.Dispose()

        End Try
    End Sub


    Private Function DefineNombre(ByVal Ubicacion As String, ByVal Compania As String, ByVal AnoPeriodo() As String) As String
        Try
            Dim Per As String = ""
            Dim Ano As String = ""
            Dim AnoPer As String = ""
            Dim Mes As String = ""

            For Each p In AnoPeriodo
                AnoPer = AnoPer & IIf(AnoPer.Length > 0, ", ", "") & "'" & p & "'"
                Ano = Ano & IIf(Ano.Length > 0, ", ", "") & "'" & p.Substring(0, 4) & "'"
                Per = Per & IIf(Per.Length > 0, ", ", "") & "'" & p.Substring(4, 2) & "'"
            Next

            'De acuerdo a la asignación de la carpeta, sustituir periodo, mes, cía, etc.
            If Ubicacion.Contains("[P1]") Then
                '*SI ES UN SOLO PERIODO, PONER EL PERIODO, SI SON VARIOS, PONER EL MES DEL PRIMER PERIODO
                dtTemp = sqlExecute("SELECT DISTINCT mes FROM periodos WHERE ano+periodo IN (" & AnoPer & ")", "ta")
                If dtTemp.Rows.Count = 0 Then
                    Mes = "Sem" & AnoPeriodo(0).Substring(4, 2)
                Else
                    Mes = IIf(IsDBNull(dtTemp.Rows(0).Item("mes")), "[PP]", dtTemp.Rows(0).Item("mes")).ToString.Trim
                End If

                Ubicacion = Ubicacion.Replace("[P1]", Mes)
            End If

            'LISTAR EL/LOS PERIODOS SEPARADOS POR COMA
            Ubicacion = Ubicacion.Replace("[PP]", "SEM " & Per.Replace("'", ""))

            'TOMAR SOLO EL PRIMER AÑO DEL ARREGLO
            Ubicacion = Ubicacion.Replace("[AAAA]", AnoPeriodo(0).Substring(0, 4))

            'TOMAR SOLO EL PRIMER AÑO DEL ARREGLO
            Ubicacion = Ubicacion.Replace("[CIA]", Compania)

            Return Ubicacion
        Catch ex As Exception
            Return "ERROR"
        End Try
    End Function
    Private Function EstructuraPoliza() As Boolean
        Try
            'Agregar las columnas para cargar la información de la póliza
            dtInfoPoliza = New DataTable
            dtInfoPoliza.Columns.Add("tipo_pol", Type.GetType("System.String"))
            dtInfoPoliza.Columns.Add("reloj", Type.GetType("System.String"))
            dtInfoPoliza.Columns.Add("cod_clase", Type.GetType("System.String"))
            dtInfoPoliza.Columns.Add("prioridad", Type.GetType("System.Int16"))
            dtInfoPoliza.Columns.Add("orden", Type.GetType("System.String"))
            dtInfoPoliza.Columns.Add("periodo", Type.GetType("System.String"))
            dtInfoPoliza.Columns.Add("ano", Type.GetType("System.String"))
            dtInfoPoliza.Columns.Add("depto", Type.GetType("System.String"))
            dtInfoPoliza.Columns.Add("cuenta", Type.GetType("System.String"))
            dtInfoPoliza.Columns.Add("subcuenta", Type.GetType("System.String"))
            dtInfoPoliza.Columns.Add("nombre_cta", Type.GetType("System.String"))
            dtInfoPoliza.Columns.Add("concepto", Type.GetType("System.String"))
            dtInfoPoliza.Columns.Add("debe", Type.GetType("System.Double"))
            dtInfoPoliza.Columns.Add("haber", Type.GetType("System.Double"))
            dtInfoPoliza.Columns.Add("depto_orig", Type.GetType("System.String"))

            'Agregar las columnas para la póliza (resumen)
            dtPoliza = New DataTable
            dtPoliza.Columns.Add("depto", Type.GetType("System.String"))
            dtPoliza.Columns.Add("cuenta", Type.GetType("System.String"))
            dtPoliza.Columns.Add("subcuenta", Type.GetType("System.String"))
            dtPoliza.Columns.Add("nombre_cta", Type.GetType("System.String"))
            dtPoliza.Columns.Add("concepto", Type.GetType("System.String"))
            dtPoliza.Columns.Add("debe", Type.GetType("System.Double"))
            dtPoliza.Columns.Add("haber", Type.GetType("System.Double"))
            dtPoliza.PrimaryKey = New DataColumn() {dtPoliza.Columns("depto"), dtPoliza.Columns("cuenta"), dtPoliza.Columns("subcuenta"), dtPoliza.Columns("concepto")}

            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Private Function AgruparDatos() As Boolean
        Try
            Dim drPoliza As DataRow

            'Agrupar información de póliza
            For Each drInfo As DataRow In dtInfoPoliza.Select("debe <> 0 OR haber <> 0", "prioridad,orden,cuenta,subcuenta")
                'Buscar si ya existe depto, cuenta y subcuenta en drPoliza

                drPoliza = dtPoliza.Rows.Find({drInfo("depto"), drInfo("cuenta"), drInfo("subcuenta"), drInfo("concepto")})
                If IsNothing(drPoliza) Then
                    dtPoliza.Rows.Add({drInfo("depto"), drInfo("cuenta"), drInfo("subcuenta"), drInfo("nombre_cta"), drInfo("concepto"), drInfo("debe"), drInfo("haber")})
                Else
                    'Si existe, sumarizar
                    drPoliza("debe") = Math.Round(drPoliza("debe") + drInfo("debe"), 2)
                    drPoliza("haber") = Math.Round(drPoliza("haber") + drInfo("haber"), 2)
                End If
            Next

            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function
    Private Function SeparaPorcentajes() As Boolean
        Try
            Dim dtPorcentajes As New DataTable
            Dim dtInfoPolizaOrig As New DataTable

            Dim drPoliza As DataRow

            Dim _acumulado As Double = 0
            Dim _monto As Double = 0
            Dim _debe As Double = 0

            Dim _concepto As String = ""
            Dim _depto As String = ""
            Dim _porcentaje As Double

            'dtInfoPoliza.Columns.Add("tipo_pol", Type.GetType("System.String"))
            'dtInfoPoliza.Columns.Add("reloj", Type.GetType("System.String"))
            'dtInfoPoliza.Columns.Add("cod_clase", Type.GetType("System.String"))
            'dtInfoPoliza.Columns.Add("prioridad", Type.GetType("System.Int16"))
            'dtInfoPoliza.Columns.Add("orden", Type.GetType("System.String"))
            'dtInfoPoliza.Columns.Add("periodo", Type.GetType("System.String"))
            'dtInfoPoliza.Columns.Add("ano", Type.GetType("System.String"))
            'dtInfoPoliza.Columns.Add("depto", Type.GetType("System.String"))
            'dtInfoPoliza.Columns.Add("cuenta", Type.GetType("System.String"))
            'dtInfoPoliza.Columns.Add("subcuenta", Type.GetType("System.String"))
            'dtInfoPoliza.Columns.Add("nombre_cta", Type.GetType("System.String"))
            'dtInfoPoliza.Columns.Add("concepto", Type.GetType("System.String"))
            'dtInfoPoliza.Columns.Add("debe", Type.GetType("System.Double"))
            'dtInfoPoliza.Columns.Add("haber", Type.GetType("System.Double"))
            'dtInfoPoliza.Columns.Add("depto_orig", Type.GetType("System.String"))

            dtInfoPolizaOrig = dtInfoPoliza.Copy
            dtInfoPoliza.Rows.Clear()

            '*** El 21 de Enero 2009 Humberto pidio que el bono de asistencia, otras percepcions y bono de cumpleaños se separaran tambien
            '*** con los mismos porcentajes que los bonos de despensa (mando solo una tabla) IVO

            Dim _bono As Double = 0
            For Each drPoliza In dtInfoPolizaOrig.Rows
                If drPoliza("debe") > 0 And drPoliza("haber") = 0 Then
                    _concepto = drPoliza("concepto").ToString.Trim
                    If Array.IndexOf(New String() {"BONASI", "OTPGRA", "OTPNOG"}, _concepto) <> -1 Then
                        '*** ???? EN EL CODIGO, NO SE ESTA SACANDO PORCENTAJE DE ESTOS BONOS
                        dtInfoPoliza.ImportRow(drPoliza)
                        If _concepto = "BONASI" Then _bono = _bono + drPoliza("debe")
                    Else
                        dtPorcentajes = sqlExecute("SELECT * FROM porcentajes WHERE depto = '" & drPoliza("depto") & "'", "nomina")
                        If dtPorcentajes.Rows.Count = 0 Then
                            'Si no hubo porcentaje para el depto, copiar el registro tal cual
                            dtInfoPoliza.ImportRow(drPoliza)
                        Else
                            _acumulado = 0
                            _debe = drPoliza("debe")
                            For Each dRow As DataRow In dtPorcentajes.Rows
                                _depto = dRow("depto_nvo")
                                _porcentaje = dRow("porcentaje")
                                If _porcentaje <> 1 Then Stop

                                _monto = Math.Round(_debe * _porcentaje, 2)
                                _acumulado = _acumulado + _monto

                                'Si la diferencia es menor a $1, integrarla para que pueda cuadrar con el neto
                                If Math.Abs(_debe - _acumulado) < 1 Then
                                    _monto = _monto + (_debe - _acumulado)
                                End If

                                '***???? EN CODIGO ORIGINAL, AL ULTIMO REGISTRO LE SUMA LA DIFERENCIA... VER DEPTO. 4090

                                drPoliza("depto") = _depto
                                drPoliza("debe") = _monto

                                dtInfoPoliza.ImportRow(drPoliza)
                            Next
                        End If
                    End If
                Else
                    dtInfoPoliza.ImportRow(drPoliza)
                End If
            Next

            '***			El 15 de diciembre 2011 Humberto pidio que los bonos de asistenci y las otras percepciones se separen en porcentajes igual que los otros conceptos IVO
            '		case inlist(alltrim(poliza_mientras.concepto),"BONASI","OTPGRA","OTPNOG") 
            '		&& Estas percepciones se separan de acuerdo a la tabla porcentajes_despensa a partir de Enero 2009 IVO
            '                sele porcentajes_despensa
            '			store 0 to _cont, _acumulado
            '			store poliza_mientras.debe to _monto
            '			store poliza_mientras.debe to _debe

            '                sele poliza_orden
            '                append blank
            '				replace depto with poliza_mientras.depto_ant
            '				replace cuenta with poliza_mientras.cuenta
            '				replace subcuenta with poliza_mientras.subcuenta
            '				replace nombre_cta with poliza_mientras.nombre_cta
            '				replace concepto with poliza_mientras.concepto
            '				replace debe with _monto

            '		case depto_ant="XXX1" && Es el unico numero de reloj que nos pidio Humberto se manejara como constante IVO Dic 16 - 2008

            '			store 0 to _cont, _acumulado
            '			store poliza_mientras.debe to _monto
            '			store poliza_mientras.debe to _debe

            '                sele poliza_orden
            '                append blank
            '			replace depto with "3171"
            '			replace cuenta with poliza_mientras.cuenta
            '			replace subcuenta with poliza_mientras.subcuenta
            '			replace nombre_cta with poliza_mientras.nombre_cta
            '			replace concepto with poliza_mientras.concepto
            '			replace debe with _monto*.8
            '			store debe+_acumulado to _acumulado

            '                sele poliza_orden
            '                append blank
            '			replace depto with "4172"
            '			replace cuenta with poliza_mientras.cuenta
            '			replace subcuenta with poliza_mientras.subcuenta
            '			replace nombre_cta with poliza_mientras.nombre_cta
            '			replace concepto with poliza_mientras.concepto
            '			replace debe with _monto-_acumulado

            '                otherwise()
            '                sele porcentajes
            '			store 0 to _cont, _acumulado
            '			store poliza_mientras.debe to _monto
            '			store poliza_mientras.debe to _debe
            '			scan for alltrim(depto)=alltrim(poliza_mientras.depto_ant)
            '                sele poliza_orden
            '                append blank
            '				replace depto with porcentajes.depto_nvo
            '				replace cuenta with poliza_mientras.cuenta
            '				replace subcuenta with poliza_mientras.subcuenta
            '				replace nombre_cta with poliza_mientras.nombre_cta
            '				replace concepto with poliza_mientras.concepto
            '				replace debe with _monto*porcentajes.porcentaje
            '				store debe+_acumulado to _acumulado
            '                _cont = _cont + 1
            '                endscan()

            '                If _cont > 0.and._debe - _acumulado! = 0 Then
            '                    sele poliza_orden
            '				store _debe-_acumulado to _diferencia
            '				replace poliza_orden.debe with poliza_orden.debe+_diferencia
            '                End If

            '			if _cont=0	&& Para los que no se desglosan en porcentajes
            '                    sele poliza_orden
            '                    append blank
            '				replace depto with poliza_mientras.depto_ant
            '				replace cuenta with poliza_mientras.cuenta
            '				replace subcuenta with poliza_mientras.subcuenta
            '				replace nombre_cta with poliza_mientras.nombre_cta
            '				replace concepto with poliza_mientras.concepto
            '				replace debe with _monto
            '                End If
            '                endcase()
            '                endscan()


            '                sele poliza_mientras
            'scan for haber!=0	&& La parte del Haber no se divide
            '                sele poliza_orden
            '                append blank
            '	replace depto with poliza_mientras.depto_ant
            '	replace cuenta with poliza_mientras.cuenta
            '	replace subcuenta with poliza_mientras.subcuenta
            '	replace nombre_cta with poliza_mientras.nombre_cta
            '	replace concepto with poliza_mientras.concepto
            '	replace haber with poliza_mientras.haber
            '                endscan()



            'sele depto,cuenta,subcuenta,nombre_cta,concepto,sum(debe) as debe,sum(haber) as haber from;
            'poliza_orden group by depto,cuenta,subcuenta,concepto into cursor de_paso

            'sele * from de_paso into cursor poliza_orden 
            '                sele poliza_orden
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Private Function CrearArchivo(ByVal Archivo As String) As Boolean
        Try
            'dlgArchivo.FileName = "poliza_bpcs_" & TipoPoliza & ".TXT"
            'dlgArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            'dlgArchivo.OverwritePrompt = True
            'Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()

            'If lDialogResult = Windows.Forms.DialogResult.Cancel Then
            '    'Si seleccionan "CANCEL", salir del procedimiento
            '    Return False
            'Else
            '    Archivo = dlgArchivo.FileName
            'End If

            Dim wrArchivo As New StreamWriter(Archivo)
            For Each drPoliza As DataRow In dtPoliza.Rows
                'Compañía - México
                wrArchivo.Write("05")
                'Profit_center
                wrArchivo.Write(drPoliza("depto").ToString.Trim.PadRight(10))
                'account_number
                wrArchivo.Write((drPoliza("cuenta").ToString.Trim & drPoliza("subcuenta").ToString.Trim).PadRight(10, "0").PadRight(20))
                'date
                wrArchivo.Write(Today.Year & Today.Month & Today.Day)
                'amount
                wrArchivo.Write(Format(Math.Round((drPoliza("debe") - drPoliza("haber")), 2), "N2").Replace(",", "").PadLeft(16))
                'currency code
                wrArchivo.Write("PES")
                'description
                wrArchivo.Write(drPoliza("nombre_cta").ToString.Trim.PadRight(20))
                wrArchivo.WriteLine()
            Next
            wrArchivo.Close()
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function
    Private Function CrearExcelDetalle(ByVal Archivo As String) As Boolean
        Try

            Dim wrArchivo As New StreamWriter(Archivo)
            For Each drPoliza As DataRow In dtPoliza.Rows
                'Compañía - México
                wrArchivo.Write("05")
                'Profit_center
                wrArchivo.Write(drPoliza("depto").ToString.Trim.PadRight(10))
                'account_number
                wrArchivo.Write((drPoliza("cuenta").ToString.Trim & drPoliza("subcuenta").ToString.Trim).PadRight(10, "0").PadRight(20))
                'date
                wrArchivo.Write(Today.Year & Today.Month & Today.Day)
                'amount
                wrArchivo.Write(Format(Math.Round((drPoliza("debe") - drPoliza("haber")), 2), "N2").Replace(",", "").PadLeft(16))
                'currency code
                wrArchivo.Write("PES")
                'description
                wrArchivo.Write(drPoliza("nombre_cta").ToString.Trim.PadRight(20))
                wrArchivo.WriteLine()
            Next
            wrArchivo.Close()
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Private Function CrearExcelResumen(ByVal Archivo As String) As Boolean
        Try
            Dim wrArchivo As New StreamWriter(Archivo)
            For Each drPoliza As DataRow In dtPoliza.Rows
                'Compañía - México
                wrArchivo.Write("05")
                'Profit_center
                wrArchivo.Write(drPoliza("depto").ToString.Trim.PadRight(10))
                'account_number
                wrArchivo.Write((drPoliza("cuenta").ToString.Trim & drPoliza("subcuenta").ToString.Trim).PadRight(10, "0").PadRight(20))
                'date
                wrArchivo.Write(Today.Year & Today.Month & Today.Day)
                'amount
                wrArchivo.Write(Format(Math.Round((drPoliza("debe") - drPoliza("haber")), 2), "N2").Replace(",", "").PadLeft(16))
                'currency code
                wrArchivo.Write("PES")
                'description
                wrArchivo.Write(drPoliza("nombre_cta").ToString.Trim.PadRight(20))
                wrArchivo.WriteLine()
            Next
            wrArchivo.Close()
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Function Poliza(ByVal Compania As String, ByVal TipoPoliza As String, ByVal AnoPeriodo() As String, ByVal Provision As Boolean, ByVal Porcentaje As Boolean, ByVal BPC As Boolean) As Boolean
        Try
            Dim dtNom As New DataTable
            Dim dtMov As New DataTable
            Dim dtCta As New DataTable

            Dim dtPol As New DataTable
            Dim Condicion As String

            Dim drCta As DataRow = Nothing
            Dim Filtro As String = ""
            Dim _depto As String = ""
            Dim _depto_orig As String = ""
            Dim _concepto As String = ""
            Dim _prioridad As Integer
            Dim _cuenta As String = ""
            Dim _subcuenta As String = ""
            Dim _nombre As String = ""
            Dim _debe As Boolean
            Dim _haber As Boolean
            Dim _monto As Double
            Dim _orden As String = ""
            Dim _montoTmp As Double

            'Cada tipo de póliza seleccionada
            dtPol = sqlExecute("SELECT condicion FROM  tipo_polizas WHERE tipo_pol = '" & TipoPoliza & "'", "nomina")
            Condicion = dtPol.Rows(0).Item("condicion").ToString.Trim

            'Cada periodo seleccionado
            For Each arPer In AnoPeriodo
                'Datos de movimientos
                dtMov = sqlExecute("SELECT nomina.reloj,nomina.cod_depto,nomina.cod_tipo,nomina.cod_clase,nomina.cod_tipo_nomina, " & _
                                   "movimientos.concepto,movimientos.monto,movimientos.prioridad FROM " & _
                                   "nomina LEFT JOIN movimientos ON nomina.reloj = movimientos.reloj AND nomina.ano = movimientos.ano AND " & _
                                   "nomina.periodo = movimientos. periodo WHERE nomina.ano = '" & arPer.Substring(0, 4) & _
                                   "' AND nomina.periodo = '" & arPer.Substring(4, 2) & "' " & _
                                   "AND cod_comp = '" & Compania & "' " & _
                                   IIf(Condicion.Length > 0, " AND " & Condicion, "") & _
                                   IIf(Provision, " AND cod_tipo_nomina = 'P'", " AND cod_tipo_nomina <> 'P'"), "nomina")

                'Para cada movimiento de la tabla
                For Each dRow As DataRow In dtMov.Rows
                    If Not ActivoTrabajando Then
                        Return False
                    End If
                    frmTrabajando.lblAvance.Text = dRow("reloj")
                    Application.DoEvents()

                    _concepto = dRow("concepto").ToString.Trim
                    _monto = dRow("monto")
                    _depto_orig = dRow("cod_depto")

                    'Buscar la cuenta que cumpla con el concepto, y de ser necesario, tipo y/o clase
                    dtCta = sqlExecute("SELECT * FROM cuentas WHERE (provision = " & IIf(Provision, 1, " 0 OR provision IS NULL) AND ") & _
                                       " tipo_pol = '" & TipoPoliza & "' AND concepto = '" & dRow("concepto") & "'" & _
                                       " AND (cod_clase LIKE '%" & dRow("COD_CLASE").ToString.Trim & "%'  OR cod_clase = '' OR cod_clase IS NULL) " & _
                                       " AND (cod_tipo LIKE '%" & dRow("COD_TIPO").ToString.Trim & "%' OR cod_tipo = '' OR cod_tipo IS NULL)", "nomina")

                    'Si encontró cuenta que cumpla las condiciones
                    If dtCta.Rows.Count > 0 Then
                        drCta = dtCta.Rows(0)
                        _prioridad = drCta("prioridad")
                        _depto = DeterminaCuenta(drCta("depto"), drCta("depto"), _depto_orig, Porcentaje).Trim
                        _cuenta = DeterminaCuenta(drCta("cuenta"), drCta("depto"), _depto_orig, Porcentaje).Trim
                        _subcuenta = DeterminaCuenta(drCta("subcuenta"), drCta("depto"), _depto_orig, Porcentaje).Trim
                        _nombre = drCta("nombre_cta")
                        _debe = drCta("debe_haber") = "D"
                        _haber = drCta("debe_haber") = "H"

                        _orden = IIf(Val(_depto) > 0, _depto, "ZZZZZ")
                        '*** Para los Administrativos se separa por porcentajes, cuando el depto original acaba en 0 
                        '*** es la nueva regla el 20 de dic 2012 IVO				
                        If TipoPoliza = "%" And _depto_orig.Substring(_depto_orig.Trim.Length - 1, 1) = "0" And Array.IndexOf(New String() {"PERVAC", "PRIVAC", "PERAGI", "INDEMN", "PRIANT", "NOREST"}, _concepto) = -1 Then
                            _montoTmp = Math.Round(_monto * 0.25, 2)
                            If Array.IndexOf(New String() {"BONASI", "OTPGRA", "OTPNOG"}, _concepto) <> -1 Then
                                _depto = "3301"
                            ElseIf _depto.Substring(1, 3) <> "000" Then
                                _depto = "3" & _depto.Substring(1, 2) & "1"
                            End If

                            dtInfoPoliza.Rows.Add({TipoPoliza, dRow("reloj"), dRow("cod_clase"), dRow("prioridad"), _orden, arPer.Substring(4, 2), _
                                               arPer.Substring(0, 4), _depto, _cuenta, _subcuenta, _nombre, _concepto, IIf(_debe, _montoTmp, 0), _
                                               IIf(_haber, _montoTmp, 0), _depto_orig})

                            _montoTmp = _monto - _montoTmp
                            If Array.IndexOf(New String() {"BONASI", "OTPGRA", "OTPNOG"}, _concepto) <> -1 Then
                                _depto = "4302"
                            ElseIf _depto.Substring(1, 3) <> "000" Then
                                _depto = "4" & _depto.Substring(1, 2) & "2"
                            End If
                            dtInfoPoliza.Rows.Add({TipoPoliza, dRow("reloj"), dRow("cod_clase"), drCta("prioridad"), _orden, arPer.Substring(4, 2), _
                                               arPer.Substring(0, 4), _depto, _cuenta, _subcuenta, _nombre, _concepto, IIf(_debe, _montoTmp, 0), _
                                               IIf(_haber, _montoTmp, 0), _depto_orig})
                        Else
                            dtInfoPoliza.Rows.Add({TipoPoliza, dRow("reloj"), dRow("cod_clase"), drCta("prioridad"), _orden, arPer.Substring(4, 2), _
                                               arPer.Substring(0, 4), _depto, _cuenta, _subcuenta, _nombre, _concepto, IIf(_debe, _monto, 0), _
                                               IIf(_haber, _monto, 0), _depto_orig})
                        End If
                    End If
                Next dRow   'Movimientos
            Next arPer      'Arreglo de periodos seleccionados

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Function PolizaAhorroBMZ(ByVal Compania As String, ByVal TipoPoliza As String, ByVal AnoPeriodo() As String, ByVal Provision As Boolean, ByVal Porcentaje As Boolean, ByVal BPC As Boolean) As Boolean
        Try
            Dim dtNom As New DataTable
            Dim dtMov As New DataTable
            Dim dtCta As New DataTable

            Dim dtPol As New DataTable
            Dim Condicion As String

            Dim drCta As DataRow = Nothing
            Dim Filtro As String = ""
            Dim _depto As String = ""
            Dim _depto_orig As String = ""
            Dim _concepto As String = ""
            Dim _prioridad As Integer
            Dim _cuenta As String = ""
            Dim _subcuenta As String = ""
            Dim _nombre As String = ""
            Dim _debe As Boolean
            Dim _haber As Boolean
            Dim _monto As Double
            Dim _orden As String = ""
            Dim _total As Double = 0

            'Cada tipo de póliza seleccionada
            dtPol = sqlExecute("SELECT condicion FROM  tipo_polizas WHERE tipo_pol = '" & TipoPoliza & "'", "nomina")
            Condicion = dtPol.Rows(0).Item("condicion").ToString.Trim

            'Cada periodo seleccionado
            For Each arPer In AnoPeriodo
                'Datos de movimientos
                dtMov = sqlExecute("SELECT nomina.reloj,nomina.cod_depto,nomina.cod_tipo,nomina.cod_clase,nomina.cod_tipo_nomina, " & _
                                  "movimientos.concepto,movimientos.monto,movimientos.prioridad FROM " & _
                                  "nomina LEFT JOIN movimientos ON nomina.reloj = movimientos.reloj AND nomina.ano = movimientos.ano AND " & _
                                  "nomina.periodo = movimientos.periodo WHERE nomina.ano = '" & arPer.Substring(0, 4) & _
                                  "' AND nomina.periodo = '" & arPer.Substring(4, 2) & "' " & _
                                  "AND cod_comp = '" & Compania & "' " & _
                                  IIf(Condicion.Length > 0, " AND " & Condicion, "") & _
                                  " AND concepto IN ('APOFAH','ABOPMO','ABOINT') " & _
                                                  IIf(Provision, " AND cod_tipo_nomina = 'P'", " AND cod_tipo_nomina <> 'P'"), "nomina")

                'Para cada movimiento de la tabla
                For Each dRow As DataRow In dtMov.Rows
                    If Not ActivoTrabajando Then
                        Return False
                    End If
                    frmTrabajando.lblAvance.Text = dRow("reloj")
                    Application.DoEvents()

                    _concepto = dRow("concepto").ToString.Trim
                    _monto = dRow("monto")
                    _depto_orig = dRow("cod_depto")

                    'Buscar la cuenta que cumpla con el concepto, y de ser necesario, tipo y/o clase
                    dtCta = sqlExecute("SELECT * FROM cuentas WHERE (provision = " & IIf(Provision, 1, " 0 OR provision IS NULL) AND ") & _
                                       " tipo_pol = '" & TipoPoliza & "' AND concepto = '" & dRow("concepto") & "'" & _
                                       " AND (cod_clase LIKE '%" & dRow("COD_CLASE").ToString.Trim & "%'  OR cod_clase = '' OR cod_clase IS NULL) " & _
                                       " AND (cod_tipo LIKE '%" & dRow("COD_TIPO").ToString.Trim & "%' OR cod_tipo = '' OR cod_tipo IS NULL)", "nomina")

                    'Si encontró cuenta que cumpla las condiciones
                    If dtCta.Rows.Count > 0 Then
                        drCta = dtCta.Rows(0)
                        _prioridad = drCta("prioridad")
                        _depto = DeterminaCuenta(drCta("depto"), drCta("depto"), _depto_orig, Porcentaje).Trim
                        _cuenta = DeterminaCuenta(drCta("cuenta"), drCta("depto"), _depto_orig, Porcentaje).Trim
                        'If _cuenta = "8609" Then Stop
                        _subcuenta = DeterminaCuenta(drCta("subcuenta"), drCta("depto"), _depto_orig, Porcentaje).Trim
                        _nombre = drCta("nombre_cta")
                        _debe = drCta("debe_haber") = "D"
                        _haber = drCta("debe_haber") = "H"
                        _total = _total + _monto

                        _orden = IIf(Val(_depto) > 0, _depto, "ZZZZZ")

                        dtInfoPoliza.Rows.Add({TipoPoliza, dRow("reloj"), dRow("cod_clase"), drCta("prioridad"), _orden, arPer.Substring(4, 2), _
                                               arPer.Substring(0, 4), _depto, _cuenta, _subcuenta, _nombre, _concepto, IIf(_debe, _monto, 0), _
                                               IIf(_haber, _monto, 0), _depto_orig})
                    End If
                Next dRow   'Movimientos

                If Provision Then
                    _depto = "0000"
                    _cuenta = "0550"
                    _subcuenta = "003"
                Else
                    _depto = "0000"
                    _cuenta = "0031"
                    _subcuenta = "001"
                End If
                _nombre = "Total de póliza"
                _concepto = "APOFA"
                _depto_orig = ""

                dtInfoPoliza.Rows.Add({TipoPoliza, "", "", 950, "ZZZZ", arPer.Substring(4, 2), _
                                       arPer.Substring(0, 4), _depto, _cuenta, _subcuenta, _nombre, _concepto, 0, _
                                       _total, _depto_orig})
            Next arPer      'Arreglo de periodos seleccionados

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Function PolizaBonosBMZ(ByVal Compania As String, ByVal TipoPoliza As String, ByVal AnoPeriodo() As String, ByVal Provision As Boolean, ByVal Porcentaje As Boolean, ByVal BPC As Boolean) As Boolean
        Try
            Dim dtNom As New DataTable
            Dim dtMov As New DataTable
            Dim dtCta As New DataTable

            Dim dtPol As New DataTable
            Dim Condicion As String

            Dim drCta As DataRow = Nothing
            Dim Filtro As String = ""
            Dim _depto As String = ""
            Dim _depto_orig As String = ""
            Dim _concepto As String = ""
            Dim _prioridad As Integer
            Dim _cuenta As String = ""
            Dim _subcuenta As String = ""
            Dim _nombre As String = ""
            Dim _debe As Boolean
            Dim _haber As Boolean
            Dim _monto As Double
            Dim _orden As String = ""
            Dim _total As Double = 0

            'Cada tipo de póliza seleccionada
            dtPol = sqlExecute("SELECT condicion FROM  tipo_polizas WHERE tipo_pol = '" & TipoPoliza & "'", "nomina")
            Condicion = dtPol.Rows(0).Item("condicion").ToString.Trim

            'Cada periodo seleccionado
            For Each arPer In AnoPeriodo
                'Datos de movimientos
                dtMov = sqlExecute("SELECT nomina.reloj,nomina.cod_depto,nomina.cod_tipo,nomina.cod_clase,nomina.cod_tipo_nomina, " & _
                                   "movimientos.concepto,movimientos.monto,movimientos.prioridad FROM " & _
                                   "nomina LEFT JOIN movimientos ON nomina.reloj = movimientos.reloj AND nomina.ano = movimientos.ano AND " & _
                                   "nomina.periodo = movimientos.periodo WHERE nomina.ano = '" & arPer.Substring(0, 4) & _
                                   "' AND nomina.periodo = '" & arPer.Substring(4, 2) & "' " & _
                                   "AND cod_comp = '" & Compania & "' " & _
                                   IIf(Condicion.Length > 0, " AND " & Condicion, "") & _
                                   " AND concepto IN ('BONDES','BONASP') " & _
                                  IIf(Provision, " AND cod_tipo_nomina = 'P'", " AND cod_tipo_nomina <> 'P'"), "nomina")


                'Para cada movimiento de la tabla
                For Each dRow As DataRow In dtMov.Rows
                    If Not ActivoTrabajando Then
                        Return False
                    End If
                    frmTrabajando.lblAvance.Text = dRow("reloj")
                    Application.DoEvents()

                    _concepto = dRow("concepto").ToString.Trim
                    _monto = dRow("monto")
                    _depto_orig = dRow("cod_depto")

                    'Buscar la cuenta que cumpla con el concepto, y de ser necesario, tipo y/o clase
                    dtCta = sqlExecute("SELECT * FROM cuentas WHERE (provision = " & IIf(Provision, 1, " 0 OR provision IS NULL) AND ") & _
                                       " tipo_pol = '" & TipoPoliza & "' AND concepto = '" & dRow("concepto") & "'" & _
                                       " AND (cod_clase LIKE '%" & dRow("COD_CLASE").ToString.Trim & "%'  OR cod_clase = '' OR cod_clase IS NULL) " & _
                                       " AND (cod_tipo LIKE '%" & dRow("COD_TIPO").ToString.Trim & "%' OR cod_tipo = '' OR cod_tipo IS NULL)", "nomina")

                    'Si encontró cuenta que cumpla las condiciones
                    If dtCta.Rows.Count > 0 Then
                        drCta = dtCta.Rows(0)
                        _prioridad = drCta("prioridad")
                        _depto = DeterminaCuenta(drCta("depto"), drCta("depto"), _depto_orig, Porcentaje).Trim
                        _cuenta = DeterminaCuenta(drCta("cuenta"), drCta("depto"), _depto_orig, Porcentaje).Trim
                        'If _cuenta = "8609" Then Stop
                        _subcuenta = DeterminaCuenta(drCta("subcuenta"), drCta("depto"), _depto_orig, Porcentaje).Trim
                        _nombre = drCta("nombre_cta")
                        _debe = drCta("debe_haber") = "D"
                        _haber = drCta("debe_haber") = "H"
                        _total = _total + _monto

                        _orden = IIf(Val(_depto) > 0, _depto, "ZZZZZ")

                        dtInfoPoliza.Rows.Add({TipoPoliza, dRow("reloj"), dRow("cod_clase"), drCta("prioridad"), _orden, arPer.Substring(4, 2), _
                                               arPer.Substring(0, 4), _depto, _cuenta, _subcuenta, _nombre, _concepto, IIf(_debe, _monto, 0), _
                                               IIf(_haber, _monto, 0), _depto_orig})
                    End If
                Next dRow   'Movimientos


                '&& Cargo a la cuenta 430-5609-000-009 el 0.75% del importe total de bonos
                '&& el 26 de Junio 2008 Humberto Rivera pidio el cambio de la comision al 1.85% IVO
                '&& el 22 de Diciembre 2009 Humberto Rivera pidio el cambio de la comision al 1.75% IVO
                '&& el 15 de Diciembre 2011 Humberto Rivera pidio el cambio de la comision al 1.10% IVO

                Dim _ivaComision As Double
                Dim _iva As Double

                _ivaComision = _total * 0.11
                _iva = ((_total * 0.011) * 0.11)

                'Comisión
                dtInfoPoliza.Rows.Add({TipoPoliza, "", "", 930, "ZZZZZ", arPer.Substring(4, 2), _
                                       arPer.Substring(0, 4), "4302", "5609", "000-009", "Comisión 1.10%", "", _ivaComision, 0, "4302"})
                'IVA de comisión
                dtInfoPoliza.Rows.Add({TipoPoliza, "", "", 900, "ZZZZZ", arPer.Substring(4, 2), _
                                       arPer.Substring(0, 4), "0000", "0127", "000-000", "11% IVA de Comisión", "", _iva, 0, "0000"})
                'Total a bancos
                If Not Provision Then
                    dtInfoPoliza.Rows.Add({TipoPoliza, "", "", 950, "ZZZZZ", arPer.Substring(4, 2), _
                                           arPer.Substring(0, 4), "0000", "0031", "000-000", "Bancos", "", 0, _total + _iva + _ivaComision, "0000"})
                Else
                    dtInfoPoliza.Rows.Add({TipoPoliza, "", "", 950, "ZZZZZ", arPer.Substring(4, 2), _
                                           arPer.Substring(0, 4), "0000", "0550", "0003", "Bancos", "", 0, _total + _iva + _ivaComision, "0000"})
                End If

            Next arPer      'Arreglo de periodos seleccionados
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function DeterminaCuenta(ByVal Cta As String, ByVal DeptoCta As String, ByVal DeptoEmp As String, Optional ByVal Separacion As Boolean = False) As String
        Try
            Dim Cuenta As String = Cta
            Dim c As String

            If Cuenta.Contains("DEPA") Then
                'últimos 4 dígitos del depto. del empleado
                Cuenta = Cuenta.Replace("DEPA", DeptoEmp.Substring(1, 4))
            End If

            If Cuenta.Contains("DEPB") Then
                'If Not Separacion Then
                '    '*** El 15 de Diciembre 2011 Humberto pidio que para los conceptos BONASI,OTPGRA,OTPNOG solo en la nomina normal, no en la de porcentajes
                '    '*** el departamento para los que empiezan en 3 sea 3301
                '    '*** el departamento para los que empiezan en 4 sea 4302 IVO
                c = IIf(DeptoEmp.Substring(1, 1) = "3", "3301", IIf(DeptoEmp.Substring(1, 1) = "4", "4302", "ERROR"))
                Cuenta = Cuenta.Replace("DEPB", c)
                'Else
                'Cuenta = Cuenta.Replace("DEPB", DeptoEmp.Substring(1, 4))
                'End If
            End If

            If Cuenta.Contains("DEPC") Then
                c = DeptoEmp.Substring(1, 1) & "30" & DeptoEmp.Substring(4, 1)
                Cuenta = Cuenta.Replace("DEPC", c)
            End If

            Return Cuenta
        Catch ex As Exception
            Return "ERROR"
        End Try
    End Function

    Private Sub dgPolizas_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        Static A As Boolean = False
        If e.ColumnIndex = 0 Then
            For Each dRow As DataRow In dtTipoPoliza.Rows
                dRow("selec") = A
            Next
            A = Not A
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs)
        Dim dtNom As New DataTable
        Dim TotPer As Double = 0
        Dim TotDed As Double = 0
        Dim _ano As String = "2013"
        Dim _periodo As String = "38"
        Dim _monto As Double
        Dim cadena As String

        'Empleados en nómina, que no tengan NETO en movimientos
        dtNom = sqlExecute("SELECT reloj,cod_tipo_nomina FROM nomina WHERE nomina.ano = '" & _ano & "' AND nomina.periodo = '" & _periodo & "'" & _
                           "AND reloj NOT IN (SELECT reloj FROM movimientos WHERE concepto = 'NETO' AND ano = '" & _ano & "' " & _
                           "AND periodo = '" & _periodo & "' AND reloj = nomina.reloj)", "nomina")

        'Calcular netos, e insertarlos en movimientos

        For Each dRow In dtNom.Rows
            TotPer = TotalPercepciones(dRow("reloj"), _ano & _periodo)
            TotDed = TotalDeducciones(dRow("reloj"), _ano & _periodo)
            _monto = TotPer - TotDed
            cadena = "INSERT INTO movimientos (ano,periodo,tipo_nomina,reloj,concepto,monto) VALUES ('"
            cadena = cadena & _ano & "','" & _periodo & "', '" & dRow("cod_tipo_nomina") & "','" & dRow("reloj") & "','NETO'," & _monto & ")"
            sqlExecute(cadena, "nomina")
        Next dRow
    End Sub

    Private Sub trPeriodos_AfterCheck(sender As Object, e As DevComponents.AdvTree.AdvTreeCellEventArgs) Handles trPeriodos.AfterCheck
        Try
            'Marcar/desmarcar todos los nodos seleccionados
            For Each chld As DevComponents.AdvTree.Node In trPeriodos.SelectedNodes
                chld.Checked = e.Cell.Checked
            Next

            ActualizaLista()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ActualizaLista()
        Try
            'Actualizar textbox con lista de periodos           
            Dim SelecPer As String = ""

            For Each C In trPeriodos.CheckedNodes
                If C.Cells.Count >= 5 Then
                    SelecPer = SelecPer & IIf(SelecPer.Length > 0, ", ", "") & C.Text & "-" & C.Cells(6).Text
                End If
            Next
            txtPeriodos.Text = SelecPer
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            txtPeriodos.Text = ""
        End Try
    End Sub

    Private Sub trPeriodos_NodeClick(sender As Object, e As DevComponents.AdvTree.TreeNodeMouseEventArgs) Handles trPeriodos.NodeClick
        Try
            If e.Node.Level = 0 Then
                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False
                For Each Chld As DevComponents.AdvTree.Node In e.Node.Nodes
                    Chld.Checked = e.Node.Checked
                Next
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class