Imports System.IO
Imports OfficeOpenXml

Public Class frmPolizas
    Dim dtPeriodos As New DataTable
    Dim dtTemp As New DataTable
    Dim dtTipoPoliza As New DataTable
    Dim dtTipo As New DataTable
    Dim dtCias As New DataTable
    Dim dtInfoPoliza As New DataTable
    Dim dtPoliza As New DataTable

    '-- Para excel de cuentas poliza -- Ernesto -- 30 agosto 2023
    Dim ruta = ""

    Private Sub frmForma_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ndRoot As DevComponents.AdvTree.Node
        Dim ndChild As DevComponents.AdvTree.Node
        Dim dtAnos As New DataTable
        Dim ndSeleccionado As New DevComponents.AdvTree.Node

        Try
            '**** PERIODOS ****

            'Periodo activo
            'Marcar como activo el ultimo periodo semanal con informacion | ACASAS 20180122
            dtTemp = sqlExecute("SELECT MAX(ano+periodo) as AnoPeriodo FROM nomina WHERE tipo_periodo = 'S'", "NOMINA")
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

                    ''Si es el periodo activo, seleccionar por default
                    ''y asignar este periodo para ser el nodo seleccionado
                    'If dPer("periodo") = PeriodoSelec And dRow("ano") = AnoSelec Then
                    '    'ndChild.Checked = True
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
                    nodoSemanales.Nodes.Add(ndChild)
                Next
                'Agregar el nodo al árbol


                Dim nodoQuincenales = New DevComponents.AdvTree.Node
                nodoQuincenales.Name = "Quincenal"
                nodoQuincenales.Text = "Quincenal"
                nodoQuincenales.CheckBoxVisible = False
                'Si el periodo seleccionado es de este año, dejar abierto
                'nodoQuincenales.Expanded = (dRow("ano") = AnoSelec)
                nodoQuincenales.Expanded = False

                dtPeriodos = sqlExecute("SELECT ano,periodo,mes,fecha_ini,fecha_fin,nombre FROM periodos_quincenal WHERE ANO = '" & dRow("ano") & "'", "TA")

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
                SelecPer = SelecPer & IIf(SelecPer.Length > 0, ", ", "") & C.Text & "-" & C.Cells(6).Text & "-" & C.Parent.Text.Substring(0, 1)
            Next
            txtPeriodos.Text = SelecPer

            '**** TIPOS DE POLIZA ****
            dtTipoPoliza = sqlExecute("SELECT 1 as selec,tipo_pol,nombre,provision,porcentaje,nombre_archivo,ubicacion_archivo FROM tipo_polizas ORDER BY orden", "nomina")
            dgPolizas.DataSource = dtTipoPoliza

            '**** Compañías ****
            dtCias = sqlExecute("SELECT cod_comp,nombre FROM cias ORDER BY cia_default DESC")
            dtCias.Rows.Add({"***", "Consolidado"})
            cmbCompania.DataSource = dtCias

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Dim reloj_individual As String = ""
    Dim reloj_ind_int As Integer = 0

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Try
            reloj_individual = ""

            If trPeriodos.CheckedNodes.Count > 1 Then
                MessageBox.Show("Solo es posible generar la póliza para un periodo a la vez", "Periodos", MessageBoxButtons.OK, MessageBoxIcon.Information)

                For Each c As DevComponents.AdvTree.Node In trPeriodos.CheckedNodes
                    c.Checked = False
                Next

                Exit Sub
            End If

            Dim i As Integer = 0
            Dim limite As Integer = 1
            Dim dtEmpleados As New DataTable
            Dim strPeriodo = trPeriodos.CheckedNodes.Item(0).Text


            If sbGeneral.Value = False Then

                Dim _ano_ As String = trPeriodos.CheckedNodes.Item(0).Cells(6).Text
                Dim _periodo_ As String = trPeriodos.CheckedNodes.Item(0).Text
                Dim _tipo_periodo_ As String = trPeriodos.CheckedNodes.Item(0).Parent.Text.Substring(0, 1)

                dtEmpleados = sqlExecute("select reloj from nomina where ano = '" & _ano_ & "' and periodo = '" & _periodo_ & "' and tipo_periodo = '" & _tipo_periodo_ & "'", "nomina")
                limite = dtEmpleados.Rows.Count
            End If

            Dim Ubicacion As String = ""

            While i < limite

                If sbGeneral.Value = False Then
                    reloj_individual = dtEmpleados.Rows(i)("reloj")
                    reloj_ind_int = Integer.Parse(reloj_individual)
                End If


                Try
                    Dim x As Integer
                    Dim dtPolizaReporte As New DataTable
                    Dim dRows() As DataRow
                    Dim SelecPer() As String
                    Dim TipoPoliza As String = ""
                    Dim NombrePoliza As String = ""
                    Dim Exitoso As Boolean
                    Dim Porcentaje As Boolean
                    Dim Provision As Boolean
                    Dim Archivo As String = ""

                    Dim tm As DateTime = Now
                    Dim FIni As Date
                    Dim FFin As Date
                    Dim Ano As String = ""
                    Dim Per As String = ""
                    Dim UbicacionArchivos As String = ""


                    'Abrir forma para mostrar progress bar
                    gpParametros.Enabled = False
                    gpControles.Enabled = False
                    frmTrabajando.Text = "Generar pólizas"
                    frmTrabajando.Show(Me)
                    ActivoTrabajando = True
                    frmTrabajando.Avance.Value = 0
                    frmTrabajando.Avance.IsRunning = False
                    frmTrabajando.lblAvance.Text = "Analizando..."
                    frmTrabajando.Avance.IsRunning = True
                    Application.DoEvents()

                    'Cambiar el cursor a "Modo de espera", para avisar al usuario que está corriendo un proceso
                    Me.Cursor = Cursors.WaitCursor

                    'Seleccionar los periodos marcados, para pasarlos a un arreglo de texto
                    ReDim SelecPer(trPeriodos.CheckedNodes.Count - 1)
                    EncabezadoReporte = ""
                    x = 0

                    For Each C In trPeriodos.CheckedNodes
                        If FIni = New Date Then
                            FIni = C.Cells(2).Text
                        End If
                        If Ano <> C.Cells(6).Text Then
                            Ano = Ano & IIf(Ano.Length > 0, ", ", "") & C.Cells(6).Text
                        End If
                        Per = Per & IIf(Per.Length = 0, "", ", ") & C.Text

                        Dim _ano As String = C.Cells(6).Text
                        Dim _periodo As String = C.Text
                        Dim _tipo_periodo As String = C.Parent.Text.Substring(0, 1)


                        FFin = C.Cells(3).Text
                        SelecPer(x) = _ano & _periodo & _tipo_periodo
                        EncabezadoReporte = EncabezadoReporte & IIf(EncabezadoReporte.Length = 0, "", ", ") & _ano & "-" & _periodo & "-" & _tipo_periodo
                        x = x + 1

                    Next

                    EncabezadoReporte = IIf(EncabezadoReporte.Contains(","), "PERIODOS ", "PERIODO ") & EncabezadoReporte

                    'Seleccionar las pólizas marcadas, para pasarlas a un arreglo de texto
                    dRows = dtTipoPoliza.Select("selec = 1")
                    For x = 0 To dRows.GetUpperBound(0)
                        'Crear la estructura de la tabla

                        frmTrabajando.lblAvance.Text = dRows(x).Item("nombre").ToString.Trim
                        frmTrabajando.Text = dRows(x).Item("nombre").ToString.Trim
                        Application.DoEvents()

                        If EstructuraPoliza() Then
                            TipoPoliza = dRows(x).Item("tipo_pol")
                            NombrePoliza = dRows(x).Item("nombre")
                            Porcentaje = IIf(IsDBNull(dRows(x).Item("porcentaje")), 0, dRows(x).Item("porcentaje")) = 1
                            Provision = IIf(IsDBNull(dRows(x).Item("provision")), 0, dRows(x).Item("provision")) = 1
                            Archivo = IIf(IsDBNull(dRows(x).Item("nombre_archivo")), "POLIZA", dRows(x).Item("nombre_archivo")).ToString.Trim
                            Archivo = DefineNombre(Archivo, cmbCompania.SelectedValue, SelecPer)

                            If sbGeneral.Value = False Then
                                Archivo = "póliza finiquito " & (i + 1).ToString.PadLeft(2, "0") & "_"
                                Archivo = Archivo.ToUpper
                            End If


                            frmTrabajando.Text = "Generar pólizas"

                            If i = 0 Then

                                ActivoTrabajando = False
                                frmTrabajando.Close()

                                Dim fbd As New FolderBrowserDialog
                                fbd.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop
                                If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    Ubicacion = fbd.SelectedPath.Trim & "\"
                                    ruta = Ubicacion                '-- Ruta ubicacion para el excel exportado -- Ernesto -- 30 agosto 2023
                                End If

                                frmTrabajando.Show(Me)
                                ActivoTrabajando = True
                                frmTrabajando.Avance.Value = 0
                                frmTrabajando.Avance.IsRunning = False


                            End If

                            frmTrabajando.lblAvance.Text = "Analizando..."
                            frmTrabajando.Avance.IsRunning = True
                            Application.DoEvents()

                            UbicacionArchivos = IIf(Ubicacion <> UbicacionArchivos, UbicacionArchivos & vbCrLf, "") & Space(5) & Ubicacion

                            Exitoso = Poliza(cmbCompania.SelectedValue, TipoPoliza, SelecPer, Provision, Porcentaje, True)

                            'Si se pudo generar la póliza, continuar
                            If Exitoso Then
                                'Si está seleccionado que se separen porcentajes
                                If Porcentaje Then
                                    If Not SeparaPorcentajes() Then
                                        MessageBox.Show("No se pudieron separar los porcentajes de la póliza " & TipoPoliza & ".", "Error al separar porcentajes",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit For
                                    End If
                                End If

                                'Correr el proceso de agrupar datos, y si no hay error, continuar
                                If AgruparDatos() Then
                                    Application.DoEvents()

                                    If Exitoso Then
                                        If Not ActivoTrabajando Then
                                            Exit Sub
                                        End If

                                        frmTrabajando.lblAvance.Text = "Excel " & (i + 1) & " de " & limite
                                        Application.DoEvents()

                                        For Each row As DataRow In dtPoliza.Rows
                                            Dim debe As Double = row("debe")
                                            Dim haber As Double = row("haber")

                                            If debe < 0 Then
                                                row("debe") = 0
                                                row("haber") = haber + (debe * -1)
                                            ElseIf haber < 0 Then
                                                row("haber") = 0
                                                row("debe") = debe + (haber * -1)
                                            End If

                                            If debe > 0 And haber > 0 Then
                                                If debe >= haber Then
                                                    debe = debe - haber
                                                    row("debe") = debe
                                                    row("haber") = 0
                                                Else
                                                    haber = haber - debe
                                                    row("debe") = 0
                                                    row("haber") = haber
                                                End If
                                            End If
                                        Next

                                        '-- Excel de poliza
                                        crear_excel_resumen(dtPoliza, Ubicacion, SelecPer(0), Archivo)

                                        '-- Archivo txt
                                        Exitoso = CrearArchivo(Ubicacion & Archivo & "_" & SelecPer(0) & ".txt", strPeriodo, SelecPer(0).Substring(0, 4))
                                    End If

                                    If Not Exitoso Then
                                        MessageBox.Show("No se pudo crear al menos uno de los archivos de la póliza " & TipoPoliza & ".", "Error al crear archivos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit For
                                    End If
                                End If
                            Else
                                MessageBox.Show("Hubo problemas durante el proceso de preparación de datos para la póliza " & TipoPoliza & ", por lo que no puede generarse. Favor de reintentar." &
                                                vbCrLf & vbCrLf & "Si el problema persiste, contacte al administrador del sistema.", "Error en póliza", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("Hubo problemas durante la creación de la estructura para la póliza " & TipoPoliza & ", por lo que no puede generarse. Favor de reintentar." &
                                            vbCrLf & vbCrLf & "Si el problema persiste, contacte al administrador del sistema.", "Error en póliza", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Next

                    If Exitoso Then
                        If sbGeneral.Value = True Then
                            ActivoTrabajando = False
                            frmTrabajando.Close()
                            frmTrabajando.Dispose()

                            MessageBox.Show("Los archivos fueron exitosamente creados en: " & vbCrLf & UbicacionArchivos, _
                                            "Creación de pólizas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End If
                    Exitoso = True

                    My.Application.DoEvents()

                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                Finally
                    gpParametros.Enabled = True
                    gpControles.Enabled = True
                    Me.Cursor = Cursors.Default
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                End Try

                i += 1

            End While

            If sbGeneral.Value = False Then
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()

                MessageBox.Show("Los archivos fueron exitosamente creados en: " & vbCrLf & Ubicacion, _
                                "Creación de pólizas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Function ReverseRowsInDataTable(inputTable As DataTable) As DataTable

        Dim outputTable As DataTable = inputTable.Clone()

        For i As Integer = inputTable.Rows.Count - 1 To 0 Step -1
            outputTable.ImportRow(inputTable.Rows(i))
        Next

        Return outputTable
    End Function

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
            dtInfoPoliza.Columns.Add("detalle", Type.GetType("System.Double"))
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
            dtPoliza.Columns.Add("detalle", Type.GetType("System.Double"))
            dtPoliza.PrimaryKey = New DataColumn() {dtPoliza.Columns("depto"), dtPoliza.Columns("cuenta"), dtPoliza.Columns("subcuenta"), dtPoliza.Columns("nombre_cta")}

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
            For Each drInfo As DataRow In dtInfoPoliza.Select("debe <> 0 OR haber <> 0", "prioridad,orden,cuenta,subcuenta,nombre_cta")
                'Buscar si ya existe depto, cuenta y subcuenta en drPoliza

                drPoliza = dtPoliza.Rows.Find({drInfo("depto"), drInfo("cuenta"), drInfo("subcuenta"), drInfo("nombre_cta")})
                If IsNothing(drPoliza) Then
                    dtPoliza.Rows.Add({drInfo("depto"), drInfo("cuenta"), drInfo("subcuenta"), drInfo("nombre_cta"), drInfo("concepto"), drInfo("debe"), drInfo("haber"), drInfo("detalle")})
                Else
                    'Si existe, sumarizar
                    drPoliza("debe") = Math.Round(drPoliza("debe") + drInfo("debe"), 2)
                    drPoliza("haber") = Math.Round(drPoliza("haber") + drInfo("haber"), 2)

                    Try
                        Dim detalle As Double = 0
                        drPoliza("detalle") = Math.Round(IIf(IsDBNull(drPoliza("detalle")), 0, drPoliza("detalle")) + IIf(IsDBNull(drInfo("detalle")), 0, drInfo("detalle")), 2)
                    Catch ex As Exception

                    End Try

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
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Archivo txt de poliza
    ''' </summary>
    ''' <param name="Archivo"></param>
    ''' <param name="fecha_ini"></param>
    ''' <param name="fecha_fin"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CrearArchivo(ByVal Archivo As String, ByVal periodo As String, ByVal ano As String) As Boolean
        Try
            Dim wrArchivo As New StreamWriter(Archivo)
            Dim dtFhaPago = sqlExecute("select fecha_pago from ta.dbo.periodos where ano+periodo='" & ano & periodo & "'")
            Dim strFha = ""

            If dtFhaPago.Rows.Count > 0 Then
                strFha = FechaSQL(dtFhaPago.Rows(0)("fecha_pago")).Replace("-", "")
            Else
                strFha = FechaSQL(Now.Date).Replace("-", "")
            End If

            Dim per = periodo.PadLeft(2, "0")

            wrArchivo.Write("P" & Space(2))                                             ' Poliza(P)
            wrArchivo.Write(strFha & Space(4))                                          ' Fecha
            wrArchivo.Write("2" & Space(6))                                             ' TipoPol
            wrArchivo.Write("3839" & Space(1))                                          ' TipoPol
            wrArchivo.Write("1" & Space(1))                                             ' Folio
            wrArchivo.Write("0" & Space(10))                                            ' Clase
            wrArchivo.Write("NOMINA SEMANAL " & per & Space(84))                        ' Concepto
            wrArchivo.Write("11" & Space(1))                                           ' SistOrig
            'wrArchivo.Write("".PadRight(3, Space(1)))                                   ' SistOrig
            wrArchivo.Write("1" & Space(1))                                             ' Impresa
            wrArchivo.Write("0" & Space(1))                                             ' Ajuste
            'wrArchivo.Write("25695EBE-92F3-4AE9-84FC-183F640E8C26" & Space(1))          ' Guid
            wrArchivo.Write("".PadRight(37, Space(1)))                                  ' Guid
            wrArchivo.WriteLine()

            For Each drPoliza As DataRow In dtPoliza.Rows
                wrArchivo.Write("M1" & Space(1))                                                            ' Movimiento de poliza (M1)
                wrArchivo.Write(drPoliza("cuenta").ToString.Trim & Space(19))                               ' IdCuenta
                wrArchivo.Write("NOMINA SEMANAL " & per & Space(14))                                        ' Referencia

                Dim signo = If(Math.Abs(drPoliza("debe")) > Math.Abs(drPoliza("haber")), "0", "1")
                wrArchivo.Write(signo & Space(1))                                                             ' TipoMovto

                Dim importe = Math.Abs(Math.Abs(drPoliza("debe")) - Math.Abs(drPoliza("haber")))
                importe = importe.ToString.PadRight(21, Space(1))
                wrArchivo.Write(importe)                                                                    ' Importe

                wrArchivo.Write("0".ToString.PadRight(11, Space(11 - "0".ToString.Length)))                 ' IdDiario
                wrArchivo.Write("0.0".ToString.PadRight(21, Space(21 - "0".ToString.Length)))               ' ImporteME
                wrArchivo.Write("NOMINA SEMANAL " & per)                                                    ' Concepto

                Dim segmento = If(IsDBNull(drPoliza("subcuenta")), "", drPoliza("subcuenta"))
                wrArchivo.Write(segmento.ToString.PadLeft(88, Space(1)) & Space(1))                         ' IdSegNeg

                'wrArchivo.Write("25695EBE-92F3-4AE9-84FC-183F640E8C26" & Space(1))                          ' Guid
                wrArchivo.Write("".PadRight(37, Space(1)))                                                   ' Guid

                wrArchivo.Write(strFha & Space(1))                                                             ' FechaAplicacion
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
                wrArchivo.Write(Microsoft.VisualBasic.Strings.Format(Math.Round((drPoliza("debe") - drPoliza("haber")), 2), "N2").Replace(",", "").PadLeft(16))
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
                wrArchivo.Write(Microsoft.VisualBasic.Strings.Format(Math.Round((drPoliza("debe") - drPoliza("haber")), 2), "N2").Replace(",", "").PadLeft(16))
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
            Dim _porcentaje As Double

            'Cada tipo de póliza seleccionada
            dtPol = sqlExecute("SELECT condicion FROM  tipo_polizas WHERE tipo_pol = '" & TipoPoliza & "'", "nomina")
            Condicion = dtPol.Rows(0).Item("condicion").ToString.Trim

            'Cada periodo seleccionado
            For Each arPer In AnoPeriodo
                'Datos de movimientos

                '--- Se cambio NETO a NETOFI para los empleados finiquitos -- Ernesto -- 29 dic 2023
                If Not Provision Then
                    If sbGeneral.Value = True Then
                        dtMov = sqlExecute("SELECT nomina.reloj,nomina.cod_depto,nomina.cod_tipo,nomina.cod_clase,nomina.cod_tipo_nomina, " & _
                                       "(CASE WHEN movimientos.concepto='NETO' AND nomina.baja is not null THEN 'NETOFI' ELSE movimientos.concepto END) as concepto," &
                                       "movimientos.monto,movimientos.prioridad FROM " & _
                                       "nomina LEFT JOIN movimientos ON nomina.reloj = movimientos.reloj AND nomina.ano = movimientos.ano AND " & _
                                       "nomina.periodo = movimientos.periodo  and nomina.tipo_periodo = movimientos.tipo_periodo  WHERE nomina.ano = '" & arPer.Substring(0, 4) & _
                                       "' AND nomina.periodo = '" & arPer.Substring(4, 2) & "' and nomina.tipo_periodo = '" & arPer.Substring(6, 1) & "' " & _
                                       "AND nomina.cod_comp = '" & Compania & "' and not concepto is null " & _
                                       IIf(Condicion.Length > 0, " AND " & Condicion, "") & _
                                       IIf(Provision, " AND cod_tipo_nomina = 'P'", " AND cod_tipo_nomina <> 'P'"), "nomina")
                    Else
                        dtMov = sqlExecute("SELECT nomina.reloj,nomina.cod_depto,nomina.cod_tipo,nomina.cod_clase,nomina.cod_tipo_nomina, " & _
                                           "(CASE WHEN movimientos.concepto='NETO' AND nomina.baja is not null THEN 'NETOFI' ELSE movimientos.concepto END) as concepto," &
                                           "movimientos.monto,movimientos.prioridad FROM " & _
                                           "nomina LEFT JOIN movimientos ON nomina.reloj = movimientos.reloj AND nomina.ano = movimientos.ano AND " & _
                                           "nomina.periodo = movimientos.periodo and nomina.tipo_periodo = movimientos.tipo_periodo WHERE nomina.reloj = '" & reloj_individual & "' AND nomina.ano = '" & arPer.Substring(0, 4) & _
                                           "' AND nomina.periodo = '" & arPer.Substring(4, 2) & "' and nomina.tipo_periodo = '" & arPer.Substring(6, 1) & "' " & _
                                           "AND nomina.cod_comp = '" & Compania & "' and not concepto is null " & _
                                           IIf(Condicion.Length > 0, " AND " & Condicion, "") & _
                                           IIf(Provision, " AND cod_tipo_nomina = 'P'", " AND cod_tipo_nomina <> 'P'"), "nomina")
                    End If

                Else
                    dtMov = sqlExecute("SELECT nomina.reloj,nomina.cod_depto,nomina.cod_tipo,nomina.cod_clase,nomina.cod_tipo_nomina, " & _
                                       "movtos_provision.concepto,movtos_provision.monto FROM " & _
                                       "nomina LEFT JOIN movtos_provision ON nomina.reloj = movtos_provision.reloj AND nomina.ano = movtos_provision.ano AND " & _
                                       "nomina.periodo = movtos_provision.periodo  and nomina.tipo_periodo = movtos_provision.tipo_periodo  WHERE nomina.ano = '" & arPer.Substring(0, 4) & _
                                       "' AND nomina.periodo = '" & arPer.Substring(4, 2) & "' and nomina.tipo_periodo = '" & arPer.Substring(6, 1) & "' " & _
                                       "AND nomina.cod_comp = '" & Compania & "' and not concepto is null " & _
                                       IIf(Condicion.Length > 0, " AND " & Condicion, ""), "nomina")
                End If

                'Para cada movimiento de la tabla
                For Each dRow As DataRow In dtMov.Rows
                    If Not ActivoTrabajando Then
                        Return False
                    End If
                    frmTrabajando.lblAvance.Text = dRow("reloj")
                    Application.DoEvents()

                    _concepto = dRow("concepto").ToString.Trim
                    _depto_orig = IIf(IsDBNull(dRow("cod_depto")), "", dRow("cod_depto"))
                    _monto = IIf(IsDBNull(dRow("monto")), 0, dRow("monto"))

                    'Buscar la cuenta que cumpla con el concepto, y de ser necesario, tipo y/o clase
                    dtCta = sqlExecute("SELECT * FROM cuentas WHERE (provision = " & IIf(Provision, 1, " 0 OR provision IS NULL ") & ") AND " & _
                                       " tipo_pol = '" & TipoPoliza & "' AND concepto = '" & dRow("concepto") & "'" & _
                                       " AND (cod_clase LIKE '%" & dRow("COD_CLASE").ToString.Trim & "%'  OR cod_clase = '' OR cod_clase IS NULL) " & _
                                       " AND (cod_tipo LIKE '%" & dRow("COD_TIPO").ToString.Trim & "%' OR cod_tipo = '' OR cod_tipo IS NULL)" & _
                                       " AND cod_comp = '" & cmbCompania.SelectedValue & "'", "nomina")

                    'Si encontró cuenta que cumpla las condiciones
                    For Each drCta In dtCta.Rows
                        '_prioridad = If(IsDBNull(drCta("prioridad")), Nothing, drCta("prioridad"))
                        _depto = IIf(IsDBNull(drCta("depto")), "", drCta("depto"))
                        _depto = DeterminaCuenta(_depto, _depto, _depto_orig, Porcentaje).Trim
                        _cuenta = DeterminaCuenta(IIf(IsDBNull(drCta("cuenta")), "", drCta("cuenta")), _
                                                  IIf(IsDBNull(drCta("depto")), "", drCta("depto")), _
                                                  _depto_orig, _
                                                  Porcentaje).Trim
                        _subcuenta = DeterminaCuenta(IIf(IsDBNull(drCta("subcuenta")), "", drCta("subcuenta")), _
                                                     IIf(IsDBNull(drCta("depto")), "", drCta("depto")), _
                                                     _depto_orig, _
                                                     Porcentaje).Trim
                        _nombre = IIf(IsDBNull(drCta("nombre_cta")), "Cuenta sin nombre", drCta("nombre_cta")).ToString.Trim
                        _debe = drCta("debe_haber") = "D"
                        _haber = drCta("debe_haber") = "H"


                        _porcentaje = IIf(IsDBNull(drCta("porcentaje")), 1, drCta("porcentaje"))


                        _orden = IIf(Val(_depto) > 0, _depto, "ZZZZZ") & IIf(IsDBNull(drCta("prioridad")), "", drCta("prioridad")).ToString.Trim.PadLeft(6, "0")
                        '*** Para los Administrativos se separa por porcentajes, cuando el depto original acaba en 0 
                        '*** es la nueva regla el 20 de dic 2012 IVO				
                        If False Then

                        Else
                            Dim detalle As Double = 0
                            Dim factor_detalle As Double = 0
                            Dim dtDetalle As DataTable = sqlExecute("select movimientos.concepto, movimientos.monto, " & _
                                                                    "conceptos.horas, conceptos.factor_detalle from movimientos left join conceptos on conceptos.horas = movimientos.concepto " & _
                                                                    "where conceptos.concepto = '" & _concepto & "' and movimientos.reloj = '" & dRow("reloj") &
                                                                    "' and movimientos.ano = '" & arPer.Substring(0, 4) & "' and movimientos.periodo = '" & arPer.Substring(4, 2) &
                                                                    "' and movimientos.tipo_periodo = '" & arPer.Substring(6, 1) & "' and conceptos.horas is not null", "nomina")
                            If dtDetalle.Rows.Count > 0 Then
                                detalle = dtDetalle.Rows(0)("monto")
                                factor_detalle = dtDetalle.Rows(0)("factor_detalle")

                                'detalle = detalle * factor_detalle

                            End If

                            dtInfoPoliza.Rows.Add({TipoPoliza, dRow("reloj"), dRow("cod_clase"), drCta("prioridad"), _orden, arPer.Substring(4, 2), _
                                               arPer.Substring(0, 4), _depto, _cuenta, _subcuenta, _nombre, _concepto, IIf(_debe, Math.Round(_monto * _porcentaje, 2), 0), _
                                               IIf(_haber, Math.Round(_monto * _porcentaje, 2), 0), detalle, _depto_orig})
                        End If
                    Next drCta
                Next dRow   'Movimientos
            Next arPer      'Arreglo de periodos seleccionados



            '-- Guardar dtInfoPoliza en excel -- Ernesto -- 30 agosto 2023
            Try
                Dim dtInfo = ProcesoNomina.tableToExcelPackage(dtInfoPoliza, "ReportePolizaDetalle_" & AnoPeriodo(0).Substring(0, 4) & AnoPeriodo(0).Substring(4, 2) & "_" & AnoPeriodo(0).Substring(6, 1))
                ProcesoNomina.saveExcelFile("ReportePolizaDetalle_" & AnoPeriodo(0).Substring(0, 4) & AnoPeriodo(0).Substring(4, 2) & "_" & AnoPeriodo(0).Substring(6, 1), dtInfo, False, ruta)
            Catch ex As Exception : End Try

            '-- Guardar reporte de amarre de poliza -- Ernesto -- 9 sep 2023
            Try
                'ReporteAmarrePolizaNomina(dtInfoPoliza, ruta,
                '                          AnoPeriodo(0).Substring(0, 4),
                '                          AnoPeriodo(0).Substring(4, 2),
                '                          AnoPeriodo(0).Substring(6, 1))
            Catch ex As Exception : End Try

            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Private Function DeterminaCuenta(ByVal Cta As String, ByVal DeptoCta As String, ByVal DeptoEmp As String, Optional ByVal Separacion As Boolean = False) As String
        Try
            Dim Cuenta As String = Cta
            Dim c As String
            Dim dtDepto As New DataTable

            If Cuenta.Contains("DEPA") Then
                'últimos 4 dígitos del depto. del empleado
                Cuenta = Cuenta.Replace("DEPA", DeptoEmp.Substring(1, 4))
            End If

            If Cuenta.Contains("DEPTO") Then
                'Todo el departamento
                Cuenta = Cuenta.Replace("DEPTO", DeptoEmp.Trim)
            End If

            If Cuenta.Contains("DEPB") Then
                'If Not Separacion Then
                '    '*** El 15 de Diciembre 2011 Humberto pidio que para los conceptos BONASI,OTPGRA,OTPNOG solo en la nomina normal, no en la de porcentajes
                '    '*** el departamento para los que empiezan en 3 sea 3301
                '    '*** el departamento para los que empiezan en 4 sea 4302 IVO
                c = IIf(DeptoEmp.Substring(1, 1) = "3", "3301", IIf(DeptoEmp.Substring(1, 1) = "4", "4302", "ERROR"))
                Cuenta = Cuenta.Replace("DEPB", c)
            End If

            If Cuenta.Contains("DEPC") Then
                c = DeptoEmp.Substring(1, 1) & "30" & DeptoEmp.Substring(4, 1)
                Cuenta = Cuenta.Replace("DEPC", c)
            End If

            If Cuenta.Contains("CCOST") Then
                dtDepto = sqlExecute("SELECT centro_costos FROM deptos WHERE cod_depto = '" & DeptoEmp & "'")
                If dtDepto.Rows.Count = 0 Then
                    Cuenta = "ERROR"
                Else
                    Cuenta = dtDepto.Rows(0).Item("CENTRO_COSTOS").ToString.Trim
                End If
            End If

            Return Cuenta
        Catch ex As Exception
            Return "ERROR"
        End Try
    End Function

    Private Sub dgPolizas_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgPolizas.ColumnHeaderMouseClick
        Try
            Static A As Boolean = False
            If e.ColumnIndex = 0 Then
                For Each dRow As DataRow In dtTipoPoliza.Rows
                    dRow("selec") = A
                Next
                A = Not A
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub trPeriodos_AfterCheck(sender As Object, e As DevComponents.AdvTree.AdvTreeCellEventArgs) Handles trPeriodos.AfterCheck
        Try
            If trPeriodos.CheckedNodes.Count > 1 Then
                DevComponents.DotNetBar.ToastNotification.Close(gpParametros)
                DevComponents.DotNetBar.ToastNotification.ToastFont = New System.Drawing.Font("Microsoft Sans Serif", 10)
                DevComponents.DotNetBar.ToastNotification.ToastBackColor = System.Drawing.Color.Yellow
                DevComponents.DotNetBar.ToastNotification.ToastForeColor = System.Drawing.Color.Black

                DevComponents.DotNetBar.ToastNotification.Show(gpParametros, "Solo es posible generar la póliza para un periodo a la vez." _
                                                               , My.Resources.Categorias24, 5000, DevComponents.DotNetBar.eToastGlowColor.Blue, _
                                                               DevComponents.DotNetBar.eToastPosition.BottomCenter)
            Else
                DevComponents.DotNetBar.ToastNotification.Close(gpParametros)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub trPeriodos_Click(sender As Object, e As EventArgs) Handles trPeriodos.Click
        Try


            Dim SelecPer As String = ""
            For Each C In trPeriodos.CheckedNodes
                SelecPer = SelecPer & IIf(SelecPer.Length > 0, ", ", "") & C.Text & "-" & C.Cells(6).Text & "-" & C.Parent.Text.Substring(0, 1)
            Next
            txtPeriodos.Text = SelecPer
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    ' Función para convertir un número de columna a letra
    Private Function LetraColumna(noColumna As Integer) As String
        Dim letra As String = ""
        While noColumna > 0
            Dim modulo As Integer = (noColumna - 1) Mod 26
            letra = Chr(65 + modulo) & letra
            noColumna = (noColumna - modulo) \ 26
        End While
        Return letra
    End Function

    ''' <summary>
    ''' Excel de la poliza con cargos y abonos
    ''' </summary>
    ''' <param name="dtDatos"></param>
    ''' <param name="Ubicacion"></param>
    ''' <param name="AAAAPPT"></param>
    ''' <param name="nombre_archivo"></param>
    ''' <remarks></remarks>
    Private Sub crear_excel_resumen(ByRef dtDatos As DataTable, Ubicacion As String, AAAAPPT As String, nombre_archivo As String)
        Try
            Dim archivo As ExcelPackage = New ExcelPackage()
            Dim wb As ExcelWorkbook = archivo.Workbook
            Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("poliza")

            Dim total_cargo As Double = 0
            Dim total_horas As Double = 0
            Dim total_abono As Double = 0
            Dim total_total As Double = 0

            Dim _ano As String = AAAAPPT.Substring(0, 4)
            Dim _periodo As String = AAAAPPT.Substring(4, 2)
            Dim _tipo_periodo As String = AAAAPPT.Substring(6, 1)

            Dim i As Integer = 1
            Dim x As Integer = 9

            Dim f_ini_poliza As String = "DD MMM YYYY"
            Dim f_fin_poliza As String = "DD MMM YYYY"
            Dim f_pago_poliza As String = "DD MMM YYYY"

            Dim dtPeriodo As DataTable = sqlExecute("select * from periodos" & IIf(_tipo_periodo = "S", "", "_quincenal") &
                                                    " where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "TA")

            Dim dtTotales As DataTable = sqlExecute("select distinct cuenta,concepto,subcuenta,nombre_cta from nomina.dbo.cuentas " &
                                                    "where cod_clase='T' order by NOMBRE_CTA")

            If dtPeriodo.Rows.Count > 0 Then
                Try
                    f_ini_poliza = FechaCortaLetra(dtPeriodo.Rows(0)("fecha_ini"))
                    f_fin_poliza = FechaCortaLetra(dtPeriodo.Rows(0)("fecha_fin"))
                    f_pago_poliza = FechaCortaLetra(dtPeriodo.Rows(0)("fecha_pago"))
                Catch ex As Exception
                    f_ini_poliza = "DD MMM YYYY"
                    f_fin_poliza = "DD MMM YYYY"
                    f_pago_poliza = "DD MMM YYYY"
                End Try
            End If

            Dim business_area As DataTable = sqlExecute("select distinct cuenta, ba from cuentas", "nomina")
            business_area.PrimaryKey = New DataColumn() {business_area.Columns("cuenta")}

            hoja_excel.Cells(1, 2).Value = "CTE TRANSPORTE"
            hoja_excel.Cells(1, 2).Style.Font.Bold = True
            hoja_excel.Cells(1, 2).Style.Font.Size = 12
            hoja_excel.Cells(2, 2).Value = "NOMINA " & IIf(_tipo_periodo = "S", "SEMANA", "QUINCENA") & " " & _periodo
            hoja_excel.Cells(3, 2).Value = f_ini_poliza & " a " & f_fin_poliza
            hoja_excel.Cells(4, 2).Value = "FECHA PAGO"
            hoja_excel.Cells(4, 3).Value = f_pago_poliza
            hoja_excel.Cells(4, 3).Style.Font.Bold = True
            hoja_excel.Cells(4, 5).Value = "Folio documento"
            hoja_excel.Cells(4, 6).Value = "XXXXXXXXXX"
            hoja_excel.Cells(4, 6).Style.Font.Bold = True
            hoja_excel.Cells(6, 6).Value = FechaCortaLetra(Now)

            hoja_excel.Row(8).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            hoja_excel.Row(8).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
            hoja_excel.Row(8).Style.Font.Bold = True

            hoja_excel.Cells(8, 1).Value = "No."
            hoja_excel.Cells(8, 2).Value = "Refer."
            hoja_excel.Cells(8, 3).Value = "Cuenta"
            hoja_excel.Cells(8, 4).Value = "Nombre"
            hoja_excel.Cells(8, 5).Value = "Diario"
            hoja_excel.Cells(8, 6).Value = "Seg"
            hoja_excel.Cells(8, 7).Value = "Cargos"
            hoja_excel.Cells(8, 8).Value = "Abonos"

            Dim strFiltro = {"concepto='NETO'",
                             "debe>0 and haber=0 and concepto<>'NETO'",
                             "debe=0 and haber>0 and concepto<>'NETO'"}
            Dim strOrden = "subcuenta,cuenta asc"

            For Each filtro In strFiltro
                For Each row As DataRow In dtDatos.Select(filtro, strOrden)
                    hoja_excel.Cells(x, 1).Value = i
                    hoja_excel.Cells(x, 2).Value = ""
                    hoja_excel.Cells(x, 3).Value = row("cuenta")
                    hoja_excel.Cells(x, 4).Value = row("nombre_cta")
                    hoja_excel.Cells(x, 5).Value = ""
                    hoja_excel.Cells(x, 6).Value = row("subcuenta")
                    hoja_excel.Cells(x, 7).Value = IIf(row("debe") > 0, row("debe"), "")
                    hoja_excel.Cells(x, 7).Style.Numberformat.Format = "#,##0.00"
                    hoja_excel.Cells(x, 8).Value = IIf(row("haber") > 0, row("haber"), "")
                    hoja_excel.Cells(x, 8).Style.Numberformat.Format = "#,##0.00"

                    x += 1
                    i += 1
                Next
            Next

            '-- Totales
            strFiltro = {"concepto<>'SUMATODOS'", "concepto='SUMATODOS'"}
            Dim lstCuentas As New ArrayList
            Dim sumDebe = 0.0
            Dim sumHaber = 0.0

            For Each filtro In strFiltro
                For Each rowT As DataRow In dtTotales.Select(filtro, strOrden)

                    If Not lstCuentas.Contains(rowT("cuenta").ToString.Trim) Then lstCuentas.Add(rowT("cuenta").ToString.Trim) Else Continue For
                    Dim debe = 0.0, haber = 0.0
                    Dim total = 0.0

                    hoja_excel.Cells(x, 1).Value = i
                    hoja_excel.Cells(x, 2).Value = ""
                    hoja_excel.Cells(x, 3).Value = rowT("cuenta").ToString.Trim
                    hoja_excel.Cells(x, 4).Value = rowT("nombre_cta").ToString.Trim
                    hoja_excel.Cells(x, 5).Value = ""
                    hoja_excel.Cells(x, 6).Value = rowT("subcuenta")

                    If filtro.Contains("<>") Then
                        debe = dtDatos.Compute("sum(debe)", "nombre_cta='" & rowT("nombre_cta").ToString.Trim & "'")
                        haber = dtDatos.Compute("sum(haber)", "nombre_cta='" & rowT("nombre_cta").ToString.Trim & "'")

                        If debe > haber Then
                            debe = debe - haber
                            haber = 0
                        Else
                            haber = haber - debe
                            debe = 0
                        End If

                        sumDebe += debe
                        sumHaber += haber
                        hoja_excel.Cells(x, 7).Value = If(debe = 0, "", debe)
                        hoja_excel.Cells(x, 7).Style.Numberformat.Format = "#,##0.00"
                        hoja_excel.Cells(x, 8).Value = If(haber = 0, "", haber)
                        hoja_excel.Cells(x, 8).Style.Numberformat.Format = "#,##0.00"
                    Else
                        total = sumDebe - sumHaber
                        hoja_excel.Cells(x, 8).Value = total
                        hoja_excel.Cells(x, 8).Style.Numberformat.Format = "#,##0.00"
                    End If

                    Dim strConcepto = rowT("concepto").ToString.Trim
                    dtDatos.Rows.Add("", rowT("cuenta").ToString.Trim, rowT("subcuenta").ToString.Trim,
                                     rowT("nombre_cta").ToString.Trim, strConcepto, If(strConcepto = "SUMATODOS", 0, debe), If(strConcepto = "SUMATODOS", total, haber), 0)

                    x += 1 : i += 1
                Next
            Next

            hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

            Dim sfd As New SaveFileDialog
            sfd.InitialDirectory = Ubicacion
            sfd.FileName = "Póliza resumen " & reloj_individual & ".xlsx"

            If sbGeneral.Value = True Then
                If sfd.ShowDialog() = DialogResult.OK Then
                    archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
                End If
            Else
                archivo.SaveAs(New System.IO.FileInfo(Ubicacion & nombre_archivo & IIf(reloj_ind_int > 0, reloj_ind_int, "") & ".xlsx"))
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    'Private Sub crear_excel_resumen1(dtDatos As DataTable, Ubicacion As String, AAAAPPT As String, nombre_archivo As String)
    '    Try
    '        Dim archivo As ExcelPackage = New ExcelPackage()
    '        Dim wb As ExcelWorkbook = archivo.Workbook
    '        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("poliza")

    '        Dim total_cargo As Double = 0
    '        Dim total_horas As Double = 0
    '        Dim total_abono As Double = 0
    '        Dim total_total As Double = 0

    '        Dim x As Integer = 9
    '        Dim _ano As String = AAAAPPT.Substring(0, 4)
    '        Dim _periodo As String = AAAAPPT.Substring(4, 2)
    '        Dim _tipo_periodo As String = AAAAPPT.Substring(6, 1)

    '        Dim business_area As DataTable = sqlExecute("select distinct cuenta, ba from cuentas where cod_comp = '" & cmbCompania.SelectedValue & "'", "nomina")
    '        business_area.PrimaryKey = New DataColumn() {business_area.Columns("cuenta")}

    '        For Each row As DataRow In dtDatos.Rows

    '            hoja_excel.Cells(x, 1).Value = ""
    '            hoja_excel.Cells(x, 2).Value = row("cuenta")

    '            Dim cuenta As String = ""
    '            Dim ba As String = "NNN"
    '            Try
    '                cuenta = RTrim(row("cuenta"))
    '                ba = business_area.Rows.Find({cuenta})("ba")
    '            Catch ex As Exception

    '            End Try

    '            hoja_excel.Cells(x, 3).Value = IIf(row("debe") > 0, Decimal.Parse(row("debe")), 0) + IIf(row("haber") > 0, Decimal.Parse(row("haber")), 0)
    '            hoja_excel.Cells(x, 4).Value = ""
    '            hoja_excel.Cells(x, 5).Value = row("subcuenta")
    '            hoja_excel.Cells(x, 6).Value = ""
    '            hoja_excel.Cells(x, 7).Value = ""

    '            hoja_excel.Cells(x, 8).Value = IIf(row("haber") > 0, row("haber"), "")
    '            hoja_excel.Cells(x, 8).Style.Numberformat.Format = "#,##0.00"

    '            If row("haber") > 0 Then
    '                hoja_excel.Cells(x, 1).Value = "50"
    '                hoja_excel.Cells(x, 9).Value = ba
    '            Else
    '                hoja_excel.Cells(x, 1).Value = "40"
    '                hoja_excel.Cells(x, 9).Value = ba
    '            End If

    '            total_cargo += row("debe")
    '            total_abono += row("haber")
    '            total_total += (row("debe") + row("haber"))
    '            x += 1
    '        Next

    '        'hoja_excel.Cells(x, 5).Value = total_cargo
    '        'hoja_excel.Cells(x, 5).Style.Numberformat.Format = "#,##0.00"

    '        'hoja_excel.Cells(x, 6).Value = total_horas
    '        'hoja_excel.Cells(x, 6).Style.Numberformat.Format = "#,##0.00"

    '        'hoja_excel.Cells(x, 8).Value = total_abono
    '        'hoja_excel.Cells(x, 8).Style.Numberformat.Format = "#,##0.00"

    '        'hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

    '        '** ENCABEZADOS AL FINAL PARA NO MOVER CELDAS *************

    '        Dim f_ini_poliza As String = "DD MMM YYYY"
    '        Dim f_fin_poliza As String = "DD MMM YYYY"
    '        Dim f_pago_poliza As String = "DD MMM YYYY"

    '        Dim dtPeriodo As DataTable = sqlExecute("select * from periodos" & IIf(_tipo_periodo = "S", "", "_quincenal") & " where ano = '" & _ano & "' and periodo = '" & _periodo & "'", "TA")
    '        If dtPeriodo.Rows.Count > 0 Then
    '            Try
    '                f_ini_poliza = FechaCortaLetra(dtPeriodo.Rows(0)("fecha_ini"))
    '                f_fin_poliza = FechaCortaLetra(dtPeriodo.Rows(0)("fecha_fin"))
    '                f_pago_poliza = FechaCortaLetra(dtPeriodo.Rows(0)("fecha_pago"))
    '            Catch ex As Exception
    '                f_ini_poliza = "DD MMM YYYY"
    '                f_fin_poliza = "DD MMM YYYY"
    '                f_pago_poliza = "DD MMM YYYY"
    '            End Try
    '        End If

    '        Dim dtinfocomp As DataTable = sqlExecute("select * from cias where cod_comp = '" & cmbCompania.SelectedValue & "'")

    '        If dtinfocomp.Rows.Count > 0 Then
    '            hoja_excel.Cells(1, 2).Value = dtinfocomp.Rows(0).Item("nombre")
    '        Else
    '            hoja_excel.Cells(1, 2).Value = "BRP QUERETARO SA DE CV"

    '        End If
    '        hoja_excel.Cells(1, 2).Style.Font.Bold = True
    '        hoja_excel.Cells(1, 2).Style.Font.Size = 12

    '        hoja_excel.Cells(1, 8).Value = "Cod. Ref: FO HRP 4.1.4"

    '        hoja_excel.Cells(2, 2).Value = "NOMINA " & IIf(_tipo_periodo = "S", "SEMANA", "QUINCENA") & " " & _periodo
    '        hoja_excel.Cells(2, 8).Value = "Revisión: A"

    '        hoja_excel.Cells(3, 2).Value = f_ini_poliza & " a " & f_fin_poliza

    '        hoja_excel.Cells(4, 2).Value = "FECHA PAGO"
    '        hoja_excel.Cells(4, 3).Value = f_pago_poliza
    '        hoja_excel.Cells(4, 3).Style.Font.Bold = True

    '        hoja_excel.Cells(4, 5).Value = "Folio documento"
    '        hoja_excel.Cells(4, 6).Value = "XXXXXXXXXX"
    '        hoja_excel.Cells(4, 6).Style.Font.Bold = True

    '        hoja_excel.Cells(5, 2).Value = IIf(_tipo_periodo = "S", "OPERATIVA", "ADMINISTRATIVA")

    '        hoja_excel.Cells(6, 6).Value = FechaCortaLetra(Now)

    '        hoja_excel.Row(8).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
    '        hoja_excel.Row(8).Style.Fill.BackgroundColor.SetColor(Color.Gainsboro)
    '        hoja_excel.Row(8).Style.Font.Bold = True



    '        hoja_excel.Cells(8, 2).Value = "CUENTA"
    '        hoja_excel.Cells(8, 3).Value = "CONCEPTO + ABONO"
    '        hoja_excel.Cells(8, 4).Value = ""
    '        hoja_excel.Cells(8, 5).Value = "CC"
    '        hoja_excel.Cells(8, 6).Value = ""
    '        hoja_excel.Cells(8, 7).Value = ""
    '        hoja_excel.Cells(8, 8).Value = "CONCEPTO"
    '        'hoja_excel.Cells(8, 9).Value = "BA"

    '        hoja_excel.Cells.AutoFitColumns()



    '        'hoja_excel.Cells(8, 3).Value = "CC"
    '        'hoja_excel.Cells(8, 4).Value = "CONCEPTO"

    '        'hoja_excel.Cells(8, 6).Value = "HRS"
    '        'hoja_excel.Cells(8, 7).Value = ""
    '        'hoja_excel.Cells(8, 8).Value = "ABONO"
    '        'hoja_excel.Cells(8, 9).Value = "BA"

    '        '*******************************

    '        Dim sfd As New SaveFileDialog
    '        sfd.InitialDirectory = Ubicacion
    '        sfd.FileName = "Póliza 1 resumen " & reloj_individual & ".xlsx"

    '        If sbGeneral.Value = True Then
    '            If sfd.ShowDialog() = DialogResult.OK Then
    '                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
    '            End If
    '        Else
    '            archivo.SaveAs(New System.IO.FileInfo(Ubicacion & nombre_archivo & IIf(reloj_ind_int > 0, reloj_ind_int, "") & ".xlsx"))
    '        End If

    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
    '    End Try
    'End Sub

End Class