Public Class frmResumenCafeteria

    'Dim SucursalTemp As strucSucursales
    'Dim SucursalActual As strucSucursales
    Dim Planta As String
    Dim PlantaTemp As String
    Dim AjusteTemp As Double
    Dim AjusteFinal As Double
    Dim ToolTipAjuste As New DevComponents.DotNetBar.SuperTooltip()

    Private Sub frmResumenCafeteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'For Each Sucursal In ListaSucursales()
        '    If SQLConn = Sucursal.conexion Then
        '        SucursalTemp.nombre = Sucursal.nombre
        '        SucursalTemp.conexion = Sucursal.conexion
        '        SucursalTemp.clave = Sucursal.clave
        '        SucursalTemp.usuario = Sucursal.usuario
        '        Exit For
        '    End If
        'Next
        If My.Application.IsNetworkDeployed Then
            If My.Application.Deployment.UpdateLocation.Host.ToUpper.Contains("MXJUVAS04") Then
                Planta = "JUAREZ 1"
                PlantaTemp = "JUAREZ 1"
                swPlanta.Value = True
            Else
                Planta = "JUAREZ 2"
                PlantaTemp = "JUAREZ 2"
                swPlanta.Value = False
            End If
        Else
            Planta = "PIDA"
        End If



        Dim dtPeriodos As DataTable = sqlExecute("select ano+periodo as 'Seleccionado', ano as 'Año',periodo as 'Semana',cast(fecha_ini as nvarchar) as 'Fecha inicio',cast(fecha_fin as nvarchar) as 'Fecha fin' from periodos where periodo < 54 order by ano+periodo desc ", "ta")
        cmbPeriodos.GroupingMembers = "Año"
        cmbPeriodos.DisplayMembers = "Seleccionado,Año,Semana,Fecha inicio,Fecha fin"
        cmbPeriodos.ValueMember = "Seleccionado"
        cmbPeriodos.DataSource = dtPeriodos
        cmbPeriodos.SelectedValue = ObtenerAnoPeriodo(Date.Now)
        AddHandler cmbPeriodos.PopupClose, AddressOf CambioPeriodo

        ActualizarYardaLiberty()
        LlenarValores()
        LlenarValoresComida()
        LlenarTotales()
        AgregarHandler()
        RevisaExcepciones(Me, "")
    End Sub
    'Private Sub CambiarSucursal()
    '    If Not SucursalTemp.nombre.Contains("PIDA") And Not SucursalTemp.nombre.Contains("PRUEBAS") Then
    '        swPlanta.Enabled = True
    '        Dim s As String = IIf(swPlanta.Value, "JUAREZ 1", "JUAREZ 2")
    '        For Each Sucursal In ListaSucursales()
    '            If Sucursal.nombre = s Then
    '                  SQLConn = Sucursal.conexion
    '                sPassword = Sucursal.clave
    '                sUserAdmin = Sucursal.usuario
    '                Exit For
    '            End If
    '        Next
    '    Else
    '        swPlanta.Enabled = False
    '    End If
    'End Sub
    'Private Sub ReestablecerSucursal()
    '    For Each Sucursal In ListaSucursales()
    '        If Sucursal.nombre = SucursalTemp.nombre Then
    '            SQLConn = Sucursal.conexion
    '            sPassword = Sucursal.clave
    '            sUserAdmin = Sucursal.usuario
    '            Exit For
    '        End If
    '    Next
    'End Sub

    Dim sumext As Boolean
    Private Sub LlenarTotales()

        subDesayuno.Value = 0
        For Each subTotales As Windows.Forms.Control In pnlDesayuno.Controls

            If subTotales.Name.Contains("Tot") Then
                Dim cSubTotales As DevComponents.Editors.DoubleInput = TryCast(subTotales, DevComponents.Editors.DoubleInput)
                cSubTotales.Value = 0
                For Each Dato As Windows.Forms.Control In pnlDesayuno.Controls
                    If Dato.Name.Contains("num") Then
                        Dim cDato As DevComponents.Editors.DoubleInput = TryCast(Dato, DevComponents.Editors.DoubleInput)
                        If ObtenerDia(cDato.Name) = ObtenerDia(cSubTotales.Name) And ObtenerIteracion(cDato.Name) = ObtenerIteracion(cSubTotales.Name) Then
                            cSubTotales.Value = cSubTotales.Value + cDato.Value
                            'ElseIf ObtenerServicio(cDato.Name) = ObtenerServicio(cTotales.Name) And ObtenerTipo(cDato.Name) = ObtenerTipo(cTotales.Name) Then
                            '    cTotales.Value = cTotales.Value + cDato.Value
                        Else
                            '   total.Value = total.Value + 0
                        End If
                        ' vGranTotal = vGranTotal + value.Value

                    End If
                Next
                subDesayuno.Value = subDesayuno.Value + cSubTotales.Value
                'If ObtenerDia(value.Name) = ObtenerDia(subTotVal.Name) And ObtenerIteracion(value.Name) = ObtenerIteracion(subTotVal.Name) Then
                '    subTotVal.Value = subTotVal.Value + value.Value
                'End If
            End If
        Next
        subComida.Value = 0
        For Each subTotales As Windows.Forms.Control In pnlComida.Controls
            If subTotales.Name.Contains("Tot") Then
                Dim cSubTotales As DevComponents.Editors.DoubleInput = TryCast(subTotales, DevComponents.Editors.DoubleInput)
                cSubTotales.Value = 0
                For Each Dato As Windows.Forms.Control In pnlComida.Controls
                    If Dato.Name.Contains("num") Then
                        Dim cDato As DevComponents.Editors.DoubleInput = TryCast(Dato, DevComponents.Editors.DoubleInput)
                        If ObtenerDia(cDato.Name) = ObtenerDia(cSubTotales.Name) And ObtenerIteracion(cDato.Name) = ObtenerIteracion(cSubTotales.Name) Then
                            cSubTotales.Value = cSubTotales.Value + cDato.Value
                            'ElseIf ObtenerServicio(cDato.Name) = ObtenerServicio(cTotales.Name) And ObtenerTipo(cDato.Name) = ObtenerTipo(cTotales.Name) Then
                            '    cTotales.Value = cTotales.Value + cDato.Value
                        Else
                            '   total.Value = total.Value + 0
                        End If
                        ' vGranTotal = vGranTotal + value.Value

                    End If
                Next
                subComida.Value = subComida.Value + cSubTotales.Value
                'If ObtenerDia(value.Name) = ObtenerDia(subTotVal.Name) And ObtenerIteracion(value.Name) = ObtenerIteracion(subTotVal.Name) Then
                '    subTotVal.Value = subTotVal.Value + value.Value
                'End If
            End If
        Next
        subCena.Value = 0

        For Each subTotales As Windows.Forms.Control In pnlCena.Controls
            If subTotales.Name.Contains("Tot") Then
                Dim cSubTotales As DevComponents.Editors.DoubleInput = TryCast(subTotales, DevComponents.Editors.DoubleInput)
                cSubTotales.Value = 0
                For Each Dato As Windows.Forms.Control In pnlCena.Controls
                    If Dato.Name.Contains("num") Then
                        Dim cDato As DevComponents.Editors.DoubleInput = TryCast(Dato, DevComponents.Editors.DoubleInput)
                        If ObtenerDia(cDato.Name) = ObtenerDia(cSubTotales.Name) And ObtenerIteracion(cDato.Name) = ObtenerIteracion(cSubTotales.Name) Then
                            cSubTotales.Value = cSubTotales.Value + cDato.Value
                            'ElseIf ObtenerServicio(cDato.Name) = ObtenerServicio(cTotales.Name) And ObtenerTipo(cDato.Name) = ObtenerTipo(cTotales.Name) Then
                            '    cTotales.Value = cTotales.Value + cDato.Value
                        Else
                            '   total.Value = total.Value + 0
                        End If
                        ' vGranTotal = vGranTotal + value.Value

                    End If
                Next
                subCena.Value = subCena.Value + cSubTotales.Value
                'If ObtenerDia(value.Name) = ObtenerDia(subTotVal.Name) And ObtenerIteracion(value.Name) = ObtenerIteracion(subTotVal.Name) Then
                '    subTotVal.Value = subTotVal.Value + value.Value
                'End If
            End If
        Next

        Dim vGranTotal As Double = 0
        For Each Totales As Windows.Forms.Control In gpTotales.Controls
            If Totales.Name.Contains("Tot") Then
                Dim cTotales As DevComponents.Editors.DoubleInput = TryCast(Totales, DevComponents.Editors.DoubleInput)
                cTotales.Value = 0






                'VALORES DEL SERVICIO**************************************************************************************************


                For Each Dato As Windows.Forms.Control In pnlDesayuno.Controls
                    If Dato.Name.Contains("num") Then
                        Dim cDato As DevComponents.Editors.DoubleInput = TryCast(Dato, DevComponents.Editors.DoubleInput)
                        If ObtenerDia(cDato.Name) = ObtenerDia(cTotales.Name) And ObtenerIteracion(cDato.Name) = ObtenerIteracion(cTotales.Name) Then
                            cTotales.Value = cTotales.Value + cDato.Value
                        ElseIf ObtenerServicio(cDato.Name) = ObtenerServicio(cTotales.Name) And (ObtenerTipo(cDato.Name) = ObtenerTipo(cTotales.Name) Or ObtenerTipo(cDato.Name) = ObtenerTipo(cTotales.Name) & "R") Then
                            cTotales.Value = cTotales.Value + cDato.Value
                        Else
                            '   total.Value = total.Value + 0
                        End If
                        ' vGranTotal = vGranTotal + value.Value

                    End If
                Next
                '*********************************************************************************************************
                For Each Dato As Windows.Forms.Control In pnlComida.Controls
                    If Dato.Name.Contains("num") Then
                        Dim cDato As DevComponents.Editors.DoubleInput = TryCast(Dato, DevComponents.Editors.DoubleInput)
                        sumext = True
                        If ObtenerDia(cDato.Name) = ObtenerDia(cTotales.Name) And ObtenerIteracion(cDato.Name) = ObtenerIteracion(cTotales.Name) Then
                            cTotales.Value = cTotales.Value + cDato.Value
                        ElseIf ObtenerServicio(cDato.Name) = ObtenerServicio(cTotales.Name) And (ObtenerTipo(cDato.Name) = ObtenerTipo(cTotales.Name) Or ObtenerTipo(cDato.Name) = ObtenerTipo(cTotales.Name) & "R") And ObtenerTurno(cDato.Name) = ObtenerTurno(cTotales.Name) Then
                            cTotales.Value = cTotales.Value + cDato.Value
                        Else
                            '   total.Value = total.Value + 0
                        End If
                        ' vGranTotal = vGranTotal + value.Value
                        'For Each subTotal As Windows.Forms.Control In pnlDesayuno.Controls
                        '    If subTotal.Name.Contains("Tot") Then
                        '        Dim subTotVal As DevComponents.Editors.DoubleInput = TryCast(subTotal, DevComponents.Editors.DoubleInput)
                        '        If ObtenerDia(value.Name) = ObtenerDia(subTotVal.Name) And ObtenerIteracion(value.Name) = ObtenerIteracion(subTotVal.Name) Then
                        '            subTotVal.Value = subTotVal.Value + value.Value
                        '        End If
                        '    End If
                        'Next
                    End If
                Next
                sumext = False
                '*********************************************************************************************************
                For Each Dato As Windows.Forms.Control In pnlCena.Controls
                    If Dato.Name.Contains("num") Then
                        Dim cDato As DevComponents.Editors.DoubleInput = TryCast(Dato, DevComponents.Editors.DoubleInput)
                        If ObtenerDia(cDato.Name) = ObtenerDia(cTotales.Name) And ObtenerIteracion(cDato.Name) = ObtenerIteracion(cTotales.Name) Then
                            cTotales.Value = cTotales.Value + cDato.Value
                        ElseIf ObtenerServicio(cDato.Name) = ObtenerServicio(cTotales.Name) And (ObtenerTipo(cDato.Name) = ObtenerTipo(cTotales.Name) Or ObtenerTipo(cDato.Name) = ObtenerTipo(cTotales.Name) & "R") Then
                            cTotales.Value = cTotales.Value + cDato.Value
                        Else
                            '   total.Value = total.Value + 0
                        End If
                        ' vGranTotal = vGranTotal + value.Value
                        'For Each subTotal As Windows.Forms.Control In pnlDesayuno.Controls
                        '    If subTotal.Name.Contains("Tot") Then
                        '        Dim subTotVal As DevComponents.Editors.DoubleInput = TryCast(subTotal, DevComponents.Editors.DoubleInput)
                        '        If ObtenerDia(value.Name) = ObtenerDia(subTotVal.Name) And ObtenerIteracion(value.Name) = ObtenerIteracion(subTotVal.Name) Then
                        '            subTotVal.Value = subTotVal.Value + value.Value
                        '        End If
                        '    End If
                        'Next
                    End If
                Next

                '*********************************************************************************************************
                'TOTALES DEL SERVICIO
                'For Each valor As Windows.Forms.Control In pnlDesayuno.Controls
                '    If valor.Name.Contains("Tot") Then
                '        Dim value As DevComponents.Editors.DoubleInput = TryCast(valor, DevComponents.Editors.DoubleInput)
                '        If ObtenerDia(value.Name) = ObtenerDia(total.Name) And ObtenerIteracion(value.Name) = ObtenerIteracion(total.Name) Then
                '            total.Value = total.Value + value.Value
                '        ElseIf ObtenerServicio(value.Name) = ObtenerServicio(total.Name) And ObtenerTipo(value.Name) = ObtenerTipo(total.Name) Then
                '            total.Value = total.Value + value.Value
                '        Else
                '            '   total.Value = total.Value + 0
                '        End If
                '        ' vGranTotal = vGranTotal + value.Value
                '    End If
                'Next



                'For Each valor As Windows.Forms.Control In pnlComida.Controls
                '    If valor.Name.Contains("num") Then
                '        Dim value As DevComponents.Editors.DoubleInput = TryCast(valor, DevComponents.Editors.DoubleInput)
                '        ' Dim total As DevComponents.Editors.DoubleInput = TryCast(sTotal, DevComponents.Editors.DoubleInput)
                '        If ObtenerDia(value.Name) = ObtenerDia(total.Name) And ObtenerIteracion(value.Name) = ObtenerIteracion(total.Name) Then
                '            total.Value = total.Value + value.Value
                '        ElseIf ObtenerServicio(value.Name) = ObtenerServicio(total.Name) And ObtenerTipo(value.Name) = ObtenerTipo(total.Name) Then
                '            total.Value = total.Value + value.Value
                '        Else
                '            'total.Value = total.Value + 0
                '        End If
                '        '   vGranTotal = vGranTotal + value.Value
                '    End If
                'Next
                'For Each valor As Windows.Forms.Control In pnlCena.Controls
                '    If valor.Name.Contains("num") Then
                '        Dim value As DevComponents.Editors.DoubleInput = TryCast(valor, DevComponents.Editors.DoubleInput)
                '        '  Dim total As DevComponents.Editors.DoubleInput = TryCast(sTotal, DevComponents.Editors.DoubleInput)

                '        If ObtenerDia(value.Name) = ObtenerDia(total.Name) And ObtenerIteracion(value.Name) = ObtenerIteracion(total.Name) Then
                '            total.Value = total.Value + value.Value
                '        ElseIf ObtenerServicio(value.Name) = ObtenerServicio(total.Name) And ObtenerTipo(value.Name) = ObtenerTipo(total.Name) Then
                '            total.Value = total.Value + value.Value
                '        Else
                '            '  total.Value = total.Value + 0
                '        End If
                '        ' vGranTotal = vGranTotal + value.Value
                '    End If
                'Next
                If Not ObtenerDia(cTotales.Name).Equals("") Then
                    vGranTotal = vGranTotal + cTotales.Value
                End If
            End If
        Next
        GrandTotal.Value = vGranTotal
    End Sub
    Private Sub LlenarValores()
        Dim dtTemp As New DataTable
        Dim dtServiciosEditables As DataTable
        Dim dtServiciosNoEditables As DataTable
        If swServicioCosto.Value Then
            dtServiciosEditables = sqlExecute("select sum(COSTO) as total,servicio,0 as repeticion,0 as extra,dia,tipo from ajustes where servicio <> 'COMIDA' and ano+periodo = '" + cmbPeriodos.SelectedValue + "' and PLANTA ='" + PlantaTemp + "' group by servicio,dia,tipo ", "cafeteria")
            dtServiciosNoEditables = sqlExecute("select SUM(COSTO) as total,servicio,repeticion,extra,dia from marcajesvw where servicio <> 'COMIDA' and ano+periodo = '" + cmbPeriodos.SelectedValue + "' and PLANTA ='" + PlantaTemp + "' group by servicio,repeticion,extra,dia", "CAFETERIA")
        Else
            dtServiciosEditables = sqlExecute("select sum(Ajuste) as total,servicio,0 as repeticion,0 as extra,dia,tipo from ajustes where servicio <> 'COMIDA' and ano+periodo = '" + cmbPeriodos.SelectedValue + "' and PLANTA ='" + PlantaTemp + "' group by servicio,dia,tipo ", "cafeteria")
            dtServiciosNoEditables = sqlExecute("select count(*) as total,servicio,repeticion,extra,dia from marcajesvw where servicio <> 'COMIDA' and ano+periodo = '" + cmbPeriodos.SelectedValue + "' and PLANTA ='" + PlantaTemp + "' group by servicio,repeticion,extra,dia", "CAFETERIA")

        End If
        For Each Panel As Windows.Forms.Control In gpTotales.Controls
            If Panel.Name.Contains("pnl") Then
                For Each valor As Windows.Forms.Control In Panel.Controls
                    If valor.Name.Contains("num") Then
                        Dim number As DevComponents.Editors.DoubleInput = TryCast(valor, DevComponents.Editors.DoubleInput)

                        If ObtenerTipo(number.Name) = "Normal" Or ObtenerTipo(number.Name) = "Extra" Then
                            Try
                                dtTemp = dtServiciosNoEditables.Select("[EXTRA]= '" + IIf(ObtenerTipo(number.Name) = "Normal", 0, 1).ToString + "'").CopyToDataTable
                            Catch ex As Exception
                                dtTemp = dtServiciosNoEditables.Clone()
                            End Try

                            If dtTemp.Rows.Count > 0 Then
                                Try
                                    dtTemp = dtTemp.Select("[DIA]= '" + ObtenerDia(number.Name) + "'").CopyToDataTable
                                Catch ex As Exception
                                    dtTemp = dtServiciosNoEditables.Clone()
                                End Try

                                If dtTemp.Rows.Count > 0 Then
                                    Try
                                        dtTemp = dtTemp.Select("[REPETICION]= '" + ObtenerIteracion(number.Name) + "'").CopyToDataTable
                                    Catch ex As Exception
                                        dtTemp = dtServiciosNoEditables.Clone()
                                    End Try

                                    If dtTemp.Rows.Count > 0 Then
                                        Try
                                            dtTemp = dtTemp.Select("[servicio]= '" + ObtenerServicio(number.Name) + "'").CopyToDataTable
                                        Catch ex As Exception
                                            dtTemp = dtServiciosNoEditables.Clone()
                                        End Try
                                        If dtTemp.Rows.Count > 0 Then
                                            number.Value = dtTemp.Rows(0).Item("TOTAL")
                                        Else
                                            number.Value = 0
                                        End If
                                    Else
                                        number.Value = 0
                                    End If

                                Else
                                    number.Value = 0
                                End If

                            Else
                                number.Value = 0
                            End If
                        Else
                            If ObtenerTipo(number.Name).Equals("Ajuste") And Not swServicioCosto.Value Then
                                number.IsInputReadOnly = False
                            Else
                                If ObtenerTipo(number.Name).Equals("AjusteR") And Not swServicioCosto.Value Then
                                    number.IsInputReadOnly = False
                                Else
                                    number.IsInputReadOnly = True
                                End If
                            End If
                            Try
                                dtTemp = dtServiciosEditables.Select("[DIA]= '" + ObtenerDia(number.Name) + "'").CopyToDataTable
                            Catch ex As Exception
                                dtTemp = dtServiciosEditables.Clone()
                            End Try
                            If dtTemp.Rows.Count > 0 Then
                                Try
                                    dtTemp = dtTemp.Select("[TIPO]= '" + ObtenerTipo(number.Name) + "'").CopyToDataTable
                                Catch ex As Exception
                                    dtTemp = dtServiciosEditables.Clone()
                                End Try
                                If dtTemp.Rows.Count > 0 Then
                                    Try
                                        dtTemp = dtTemp.Select("[SERVICIO]= '" + ObtenerServicio(number.Name) + "'").CopyToDataTable
                                    Catch ex As Exception
                                        dtTemp = dtServiciosEditables.Clone()
                                    End Try
                                    If dtTemp.Rows.Count > 0 Then
                                        If ObtenerIteracion(number.Name).Equals("0") Or ObtenerTipo(number.Name).Equals("AjusteR") Then
                                            number.Value = dtTemp.Rows(0).Item("TOTAL")
                                        Else
                                            number.Value = 0
                                        End If
                                    Else
                                        number.Value = 0
                                    End If
                                Else
                                    number.Value = 0
                                End If
                            Else
                                number.Value = 0
                            End If
                        End If

                    End If
                Next
            End If
        Next
    End Sub
    Private Sub LlenarValoresComida()
        Dim dtTemp As New DataTable
        Dim dtServiciosEditables As DataTable
        Dim dtServiciosNoEditables As DataTable
        If swServicioCosto.Value Then
            dtServiciosEditables = sqlExecute("select sum(COSTO) as total,servicio,0 as repeticion,0 as extra,dia,tipo, 0 as turno_asiste from ajustes where servicio = 'COMIDA' and ano+periodo = '" + cmbPeriodos.SelectedValue + "' and PLANTA ='" + PlantaTemp + "' group by servicio,dia,tipo ", "cafeteria")
            dtServiciosNoEditables = sqlExecute("select SUM(COSTO) as total,servicio,repeticion,extra,dia, turno_asiste from marcajesvw where servicio = 'COMIDA' and ano+periodo = '" + cmbPeriodos.SelectedValue + "' and PLANTA ='" + PlantaTemp + "' group by servicio,repeticion,extra,dia, turno_asiste", "CAFETERIA")
        Else
            dtServiciosEditables = sqlExecute("select sum(Ajuste) as total,servicio,0 as repeticion,0 as extra,dia,tipo, 0 as turno_asiste from ajustes where servicio = 'COMIDA' and ano+periodo = '" + cmbPeriodos.SelectedValue + "' and PLANTA ='" + PlantaTemp + "' group by servicio,dia,tipo ", "cafeteria")
            dtServiciosNoEditables = sqlExecute("select count(*) as total,servicio,repeticion,extra,dia, turno_asiste from marcajesvw where servicio = 'COMIDA' and ano+periodo = '" + cmbPeriodos.SelectedValue + "' and PLANTA ='" + PlantaTemp + "' group by servicio,repeticion,extra,dia, turno_asiste", "CAFETERIA")

        End If
        For Each Panel As Windows.Forms.Control In gpTotales.Controls
            If Panel.Name.Contains("pnl") Then
                For Each valor As Windows.Forms.Control In Panel.Controls
                    If valor.Name.Contains("num") Then
                        Dim number As DevComponents.Editors.DoubleInput = TryCast(valor, DevComponents.Editors.DoubleInput)

                        If ObtenerTipo(number.Name) = "Normal" Or ObtenerTipo(number.Name) = "Extra" Then
                            If ObtenerServicio(number.Name) = "COMIDA" Then

                                Try
                                    dtTemp = dtServiciosNoEditables.Select("[EXTRA]= '" + IIf(ObtenerTipo(number.Name) = "Normal", 0, 1).ToString + "'").CopyToDataTable
                                Catch ex As Exception
                                    dtTemp = dtServiciosNoEditables.Clone()
                                End Try

                                If dtTemp.Rows.Count > 0 Then
                                    Try
                                        dtTemp = dtTemp.Select("[DIA]= '" + ObtenerDia(number.Name) + "'").CopyToDataTable
                                    Catch ex As Exception
                                        dtTemp = dtServiciosNoEditables.Clone()
                                    End Try

                                    If dtTemp.Rows.Count > 0 Then
                                        Try
                                            dtTemp = dtTemp.Select("[REPETICION]= '" + ObtenerIteracion(number.Name) + "'").CopyToDataTable
                                        Catch ex As Exception
                                            dtTemp = dtServiciosNoEditables.Clone()
                                        End Try
                                        If dtTemp.Rows.Count > 0 Then

                                            If ObtenerServicio(number.Name) = "COMIDA" Then
                                                Try
                                                    dtTemp = dtTemp.Select("[TURNO_ASISTE]= '" + ObtenerTurno(number.Name) + "'").CopyToDataTable
                                                Catch ex As Exception
                                                    dtTemp = dtServiciosNoEditables.Clone()
                                                End Try
                                            End If
                                            If dtTemp.Rows.Count > 0 Then
                                                Try
                                                    dtTemp = dtTemp.Select("[servicio]= '" + ObtenerServicio(number.Name) + "'").CopyToDataTable
                                                Catch ex As Exception
                                                    dtTemp = dtServiciosNoEditables.Clone()
                                                End Try
                                                If dtTemp.Rows.Count > 0 Then
                                                    number.Value = dtTemp.Rows(0).Item("TOTAL")
                                                Else
                                                    number.Value = 0
                                                End If
                                            Else
                                                number.Value = 0
                                            End If
                                        Else
                                            number.Value = 0
                                        End If
                                    Else
                                        number.Value = 0
                                    End If

                                Else
                                    number.Value = 0
                                End If
                            End If
                        Else
                            If ObtenerServicio(number.Name) = "COMIDA" Then

                                If ObtenerTipo(number.Name).Equals("Ajuste") And Not swServicioCosto.Value Then
                                    number.IsInputReadOnly = False
                                Else
                                    If ObtenerTipo(number.Name).Equals("AjusteR") And Not swServicioCosto.Value Then
                                        number.IsInputReadOnly = False
                                    Else
                                        number.IsInputReadOnly = True
                                    End If
                                End If
                                Try
                                    dtTemp = dtServiciosEditables.Select("[DIA]= '" + ObtenerDia(number.Name) + "'").CopyToDataTable
                                Catch ex As Exception
                                    dtTemp = dtServiciosEditables.Clone()
                                End Try
                                If dtTemp.Rows.Count > 0 Then
                                    Try
                                        dtTemp = dtTemp.Select("[TIPO]= '" + ObtenerTipo(number.Name) + "'").CopyToDataTable
                                    Catch ex As Exception
                                        dtTemp = dtServiciosEditables.Clone()
                                    End Try
                                    If dtTemp.Rows.Count > 0 Then
                                        Try
                                            dtTemp = dtTemp.Select("[SERVICIO]= '" + ObtenerServicio(number.Name) + "'").CopyToDataTable
                                        Catch ex As Exception
                                            dtTemp = dtServiciosEditables.Clone()
                                        End Try
                                        If dtTemp.Rows.Count > 0 Then
                                            If ObtenerIteracion(number.Name).Equals("0") Or ObtenerTipo(number.Name).Equals("AjusteR") Then
                                                number.Value = dtTemp.Rows(0).Item("TOTAL")
                                            Else
                                                number.Value = 0
                                            End If
                                        Else
                                            number.Value = 0
                                        End If
                                    Else
                                        number.Value = 0
                                    End If
                                Else
                                    number.Value = 0
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub CambioPeriodo(sender As Object, e As EventArgs)
        ActualizarYardaLiberty()
        LlenarValores()
        LlenarValoresComida()
        LlenarTotales()
    End Sub

    Private Function ObtenerTurno(NombreControl As String) As String
        Dim r As String = ""
        If NombreControl.Contains("do") Then
            r = "2"
        ElseIf NombreControl.Contains("ro") Then
            r = "1"
        ElseIf NombreControl.Contains("ce") Then
            If sumext = True Then
                r = "1"
            Else
                r = "0"
            End If
            sumext = False
        End If
        Return r
    End Function
    Private Function ObtenerDia(NombreControl As String) As String
        Dim r As String = ""
        If NombreControl.Contains("Lun") Then
            r = "Lunes"
        ElseIf NombreControl.Contains("Mar") Then
            r = "Martes"
        ElseIf NombreControl.Contains("Mie") Then
            r = "Miércoles"
        ElseIf NombreControl.Contains("Jue") Then
            r = "Jueves"
        ElseIf NombreControl.Contains("Vie") Then
            r = "Viernes"
        ElseIf NombreControl.Contains("Sab") Then
            r = "Sábado"
        ElseIf NombreControl.Contains("Dom") Then
            r = "Domingo"
        End If
        Return r
    End Function
    Private Function ObtenerServicio(NombreControl As String) As String
        Dim r As String = ""
        If NombreControl.Contains("Des") Then
            r = "DESAYUNO"
        ElseIf NombreControl.Contains("Com") Then
            r = "COMIDA"
        ElseIf NombreControl.Contains("Cen") Then
            r = "CENA"
        End If

        Return r
    End Function
    Private Function ObtenerIteracion(NombreControl As String) As String
        Dim r As String = ""
        If NombreControl.Contains("1") Then
            r = "0"
        Else
            r = "1"
        End If
        Return r
    End Function
    Private Function ObtenerTipo(NombreControl As String) As String
        Dim r As String = ""
        'r = NombreControl.Substring(10)
        If NombreControl.Contains("Normal") Then
            r = "Normal"
        ElseIf NombreControl.Contains("Extra") Then
            r = "Extra"
        Else
            r = NombreControl.Substring(10)
        End If
        Return r
    End Function



    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        'Dim dtServiciosEditables As DataTable
        'Dim dtServiciosNoEditables As DataTable
        'If swServicioCosto.Value Then
        '    dtServiciosEditables = sqlExecute("select sum(COSTO) as total,servicio,0 as repeticion,0 as extra,dia,tipo from ajustes where ano+periodo = '" + cmbPeriodos.SelectedValue + "' group by servicio,dia,tipo ", "cafeteria")
        '    dtServiciosNoEditables = sqlExecute("select SUM(COSTO) as total,servicio,repeticion,extra,dia from marcajesvw where ano+periodo = '" + cmbPeriodos.SelectedValue + "' group by servicio,repeticion,extra,dia", "CAFETERIA")
        'Else
        '    dtServiciosEditables = sqlExecute("select sum(Ajuste) as total,servicio,0 as repeticion,0 as extra,dia,tipo from ajustes where ano+periodo = '" + cmbPeriodos.SelectedValue + "' group by servicio,dia,tipo ", "cafeteria")
        '    dtServiciosNoEditables = sqlExecute("select count(*) as total,servicio,repeticion,extra,dia from marcajesvw where ano+periodo = '" + cmbPeriodos.SelectedValue + "' group by servicio,repeticion,extra,dia", "CAFETERIA")
        'End If

        Try
            Dim query As String = ""
            Dim dtReporte As DataTable
            If swServicioCosto.Value Then
                query = query + "select sum(COSTO) as total,servicio,0 as repeticion,0 as extra,dia,ano,periodo,tipo from ajustes where ano+periodo = '" + cmbPeriodos.SelectedValue + "' and PLANTA ='" + PlantaTemp + "'  group by servicio,dia,ano,periodo ,tipo UNION ALL "
                query = query + "select SUM(COSTO) as total,servicio,repeticion,extra,dia,ano,periodo,CASE WHEN EXTRA=1 THEN 'Extra' ELSE 'Normal'END AS TIPO from marcajesvw where ano+periodo = '" + cmbPeriodos.SelectedValue + "' and PLANTA ='" + PlantaTemp + "'  group by servicio,repeticion,extra,dia,ano,periodo "
            Else
                query = query + "select sum(AJUSTE) as total,servicio,0 as turno_asiste, 0 as repeticion,0 as extra,dia,ano,periodo,tipo from ajustes where ano+periodo = '" + cmbPeriodos.SelectedValue + "' and PLANTA ='" + PlantaTemp + "' group by servicio, dia,ano,periodo,tipo  UNION ALL "
                query = query + "select count(*) as total,servicio,turno_asiste, repeticion,extra,dia,ano,periodo,CASE WHEN EXTRA=1 THEN 'Extra' ELSE 'Normal'END AS TIPO from marcajesvw where ano+periodo = '" + cmbPeriodos.SelectedValue + "' and PLANTA ='" + PlantaTemp + "' group by servicio,turno_asiste, repeticion,extra,dia,ano,periodo "
            End If

            Dim dtfechas As DataTable = sqlExecute("select * from periodos where ano+periodo = '" & cmbPeriodos.SelectedValue & "'", "TA")
            Dim fechai As Date = dtfechas.Rows(0).Item("FECHA_INI")
            Dim fechaf As Date = dtfechas.Rows(0).Item("FECHA_FIN")
            Dim fechas_periodo As String = fechai.ToShortDateString & " a " & fechaf.ToShortDateString
            dtReporte = sqlExecute(query, "cafeteria")

            Dim fechas As New Data.DataColumn("fechas_periodo", GetType(System.String))
            Dim planta As New Data.DataColumn("planta", GetType(System.String))
            fechas.DefaultValue = fechas_periodo
            planta.DefaultValue = PlantaTemp
            dtReporte.Columns.Add(fechas)
            dtReporte.Columns.Add(planta)

            For Each row As DataRow In dtReporte.Rows
                If row("turno_asiste") = "0" Then
                    row("turno_asiste") = "1"
                End If
            Next



            frmVistaPrevia.LlamarReporte("Reporte semanal de cafeteria", dtReporte)
            frmVistaPrevia.ShowDialog()

        Catch ex As Exception

        End Try

    End Sub




    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub swServicioCosto_ValueChanged(sender As Object, e As EventArgs) Handles swServicioCosto.ValueChanged
        LlenarValores()
        LlenarValoresComida()
        LlenarTotales()
    End Sub

    Private Sub AgregarHandler()
        For Each c As Windows.Forms.Control In pnlDesayuno.Controls
            If c.Name.Contains("Ajuste") Then
                AddHandler c.Click, AddressOf numComLun1Ajuste_Click
                If Not c.Name.Contains("AjusteR") Then
                    AddHandler c.Validated, AddressOf numComLun1Ajuste_Validated
                Else
                    AddHandler c.Validated, AddressOf numDesLun2Ajuste_Validated
                End If
            End If

            If c.Name.Contains("Normal") Or c.Name.Contains("Extra") Then
                c.ContextMenuStrip = mnuVer
                AddHandler c.MouseDown, AddressOf numDesLun1Normal_MouseDown
            End If
        Next
        For Each c As Windows.Forms.Control In pnlComida.Controls
            If c.Name.Contains("Ajuste") Then
                AddHandler c.Click, AddressOf numComLun1Ajuste_Click
                If Not c.Name.Contains("AjusteR") Then
                    AddHandler c.Validated, AddressOf numComLun1Ajuste_Validated
                Else
                    AddHandler c.Validated, AddressOf numDesLun2Ajuste_Validated
                End If
            End If

            If c.Name.Contains("Normal") Or c.Name.Contains("Extra") Then
                c.ContextMenuStrip = mnuVer
                AddHandler c.MouseDown, AddressOf numDesLun1Normal_MouseDown
            End If
        Next
        For Each c As Windows.Forms.Control In pnlCena.Controls
            If c.Name.Contains("Ajuste") Then
                AddHandler c.Click, AddressOf numComLun1Ajuste_Click
                If Not c.Name.Contains("AjusteR") Then
                    AddHandler c.Validated, AddressOf numComLun1Ajuste_Validated
                Else
                    AddHandler c.Validated, AddressOf numDesLun2Ajuste_Validated
                End If
            End If

            If c.Name.Contains("Normal") Or c.Name.Contains("Extra") Then
                c.ContextMenuStrip = mnuVer
                AddHandler c.MouseDown, AddressOf numDesLun1Normal_MouseDown
            End If
        Next
    End Sub


    Private Sub numComLun1Ajuste_Validated(sender As Object, e As EventArgs)
        Dim c As DevComponents.Editors.DoubleInput = TryCast(sender, DevComponents.Editors.DoubleInput)
        AjusteFinal = c.Value - AjusteTemp
        Dim y As String = cmbPeriodos.SelectedValue.ToString.Substring(0, 4)
        Dim p As String = cmbPeriodos.SelectedValue.ToString.Substring(4, 2)
        Dim dtInformacionCostos As DataTable = sqlExecute("select * from servicios where servicio = '" + ObtenerServicio(c.Name) + "'", "CAFETERIA")
        If dtInformacionCostos.Rows.Count > 0 Then
            Dim costo As Double = IIf(IsDBNull(dtInformacionCostos.Rows(0).Item("COSTO_PRIMERA_NORMAL")), 0, dtInformacionCostos.Rows(0).Item("COSTO_PRIMERA_NORMAL"))
            Dim query As String = "insert into ajustes(ANO,PERIODO,DIA,SERVICIO,AJUSTE,TIPO,COSTO,PLANTA)"
            query = query + "VALUES('" + y + "','" + p + "','" + ObtenerDia(c.Name) + "','" + ObtenerServicio(c.Name) + "','" + AjusteFinal.ToString + "','Ajuste','" + (AjusteFinal * costo).ToString + "','" + PlantaTemp + "')"
            sqlExecute(query, "CAFETERIA")
        End If

        LlenarValores()
        LlenarValoresComida()
        LlenarTotales()
    End Sub

    Private Sub numComLun1Ajuste_Click(sender As Object, e As EventArgs)
        Dim c As DevComponents.Editors.DoubleInput = TryCast(sender, DevComponents.Editors.DoubleInput)
        AjusteTemp = c.Value
    End Sub

    'Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
    '    Me.Close()

    'End Sub


    Private Sub swPlanta_ValueChanged(sender As Object, e As EventArgs) Handles swPlanta.ValueChanged
        If swPlanta.Value Then
            PlantaTemp = "JUAREZ 1"
        Else
            PlantaTemp = "JUAREZ 2"
        End If
        LlenarValores()
        LlenarValoresComida()
        LlenarTotales()
    End Sub



#Region "bk"
    'Dim year As String
    'Dim period As String
    'Dim DesayunoLunes As Integer = 0
    'Dim DesayunoMartes As Integer = 0
    'Dim Desayunomiercoles As Integer = 0
    'Dim DesayunoJueves As Integer = 0
    'Dim DesayunoViernes As Integer = 0
    'Dim DesayunoSabado As Integer = 0
    'Dim DesayunoDomingo As Integer = 0
    'Dim DesayunoTotal As Integer = 0

    'Dim ComidaLunes As Integer = 0
    'Dim ComidaMartes As Integer = 0
    'Dim Comidamiercoles As Integer = 0
    'Dim ComidaJueves As Integer = 0
    'Dim ComidaViernes As Integer = 0
    'Dim ComidaSabado As Integer = 0
    'Dim ComidaDomingo As Integer = 0
    'Dim ComidaTotal As Integer = 0

    'Dim CenaLunes As Integer = 0
    'Dim CenaMartes As Integer = 0
    'Dim Cenamiercoles As Integer = 0
    'Dim CenaJueves As Integer = 0
    'Dim CenaViernes As Integer = 0
    'Dim CenaSabado As Integer = 0
    'Dim CenaDomingo As Integer = 0
    'Dim CenaTotal As Integer = 0

    'Dim TotalLunes As Integer = 0
    'Dim TotalMartes As Integer = 0
    'Dim Totalmiercoles As Integer = 0
    'Dim TotalJueves As Integer = 0
    'Dim TotalViernes As Integer = 0
    'Dim TotalSabado As Integer = 0
    'Dim TotalDomingo As Integer = 0

    'Dim TotalFinal As Integer = 0

    'Dim DesayunoLunesAjuste As Integer = 0
    'Dim DesayunoMartesAjuste As Integer = 0
    'Dim DesayunomiercolesAjuste As Integer = 0
    'Dim DesayunoJuevesAjuste As Integer = 0
    'Dim DesayunoViernesAjuste As Integer = 0
    'Dim DesayunoSabadoAjuste As Integer = 0
    'Dim DesayunoDomingoAjuste As Integer = 0

    'Dim ComidaLunesAjuste As Integer = 0
    'Dim ComidaMartesAjuste As Integer = 0
    'Dim ComidamiercolesAjuste As Integer = 0
    'Dim ComidaJuevesAjuste As Integer = 0
    'Dim ComidaViernesAjuste As Integer = 0
    'Dim ComidaSabadoAjuste As Integer = 0
    'Dim ComidaDomingoAjuste As Integer = 0


    'Dim CenaLunesAjuste As Integer = 0
    'Dim CenaMartesAjuste As Integer = 0
    'Dim CenamiercolesAjuste As Integer = 0
    'Dim CenaJuevesAjuste As Integer = 0
    'Dim CenaViernesAjuste As Integer = 0
    'Dim CenaSabadoAjuste As Integer = 0
    'Dim CenaDomingoAjuste As Integer = 0
    'Private Sub Blanquear()
    '    DesayunoLunes = 0
    '    DesayunoMartes = 0
    '    Desayunomiercoles = 0
    '    DesayunoJueves = 0
    '    DesayunoViernes = 0
    '    DesayunoSabado = 0
    '    DesayunoDomingo = 0
    '    DesayunoTotal = 0

    '    ComidaLunes = 0
    '    ComidaMartes = 0
    '    Comidamiercoles = 0
    '    ComidaJueves = 0
    '    ComidaViernes = 0
    '    ComidaSabado = 0
    '    ComidaDomingo = 0
    '    ComidaTotal = 0

    '    CenaLunes = 0
    '    CenaMartes = 0
    '    Cenamiercoles = 0
    '    CenaJueves = 0
    '    CenaViernes = 0
    '    CenaSabado = 0
    '    CenaDomingo = 0
    '    CenaTotal = 0

    '    TotalLunes = 0
    '    TotalMartes = 0
    '    Totalmiercoles = 0
    '    TotalJueves = 0
    '    TotalViernes = 0
    '    TotalSabado = 0
    '    TotalDomingo = 0

    '    TotalFinal = 0

    '    DesayunoLunesAjuste = 0
    '    DesayunoMartesAjuste = 0
    '    DesayunomiercolesAjuste = 0
    '    DesayunoJuevesAjuste = 0
    '    DesayunoViernesAjuste = 0
    '    DesayunoSabadoAjuste = 0
    '    DesayunoDomingoAjuste = 0

    '    ComidaLunesAjuste = 0
    '    ComidaMartesAjuste = 0
    '    ComidamiercolesAjuste = 0
    '    ComidaJuevesAjuste = 0
    '    ComidaViernesAjuste = 0
    '    ComidaSabadoAjuste = 0
    '    ComidaDomingoAjuste = 0


    '    CenaLunesAjuste = 0
    '    CenaMartesAjuste = 0
    '    CenamiercolesAjuste = 0
    '    CenaJuevesAjuste = 0
    '    CenaViernesAjuste = 0
    '    CenaSabadoAjuste = 0
    '    CenaDomingoAjuste = 0
    'End Sub
    'Private Sub MostrarInformacion()
    '    Blanquear()
    '    Try
    '        year = cmbPeriodos.SelectedValue.ToString.Substring(0, 4)
    '        period = cmbPeriodos.SelectedValue.ToString.Substring(4, 2)
    '        Debug.Print("")
    '    Catch ex As Exception
    '        year = ""
    '        period = ""
    '        Debug.Print("error al asignar periodo")
    '        Exit Sub
    '    End Try
    '    Dim dtTotales As DataTable = sqlExecute("select count(reloj) as total,dia,servicio from marcajesvw where ano+periodo = '" + cmbPeriodos.SelectedValue + "' group by dia,servicio", "cafeteria")

    '    For Each r As DataRow In dtTotales.Rows
    '        Dim d As String = r.Item("dia")
    '        Dim s As String = r.Item("servicio")
    '        Dim c As Integer = r.Item("total")
    '        Select Case d
    '            Case "Lunes"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunoLunes = c

    '                    Case "COMIDA"

    '                        ComidaLunes = c

    '                    Case "CENA"

    '                        CenaLunes = c

    '                End Select
    '            Case "Martes"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunoMartes = c

    '                    Case "COMIDA"
    '                        ComidaMartes = c

    '                    Case "CENA"
    '                        CenaMartes = c

    '                End Select
    '            Case "Miércoles"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        Desayunomiercoles = c

    '                    Case "COMIDA"
    '                        Comidamiercoles = c

    '                    Case "CENA"
    '                        Cenamiercoles = c

    '                End Select
    '            Case "Jueves"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunoJueves = c

    '                    Case "COMIDA"
    '                        ComidaJueves = c

    '                    Case "CENA"
    '                        CenaJueves = c

    '                End Select
    '            Case "Viernes"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunoViernes = c

    '                    Case "COMIDA"
    '                        ComidaViernes = c

    '                    Case "CENA"
    '                        CenaViernes = c
    '                End Select
    '            Case "Sábado"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunoSabado = c

    '                    Case "COMIDA"
    '                        ComidaSabado = c

    '                    Case "CENA"
    '                        CenaSabado = c
    '                End Select
    '            Case "Domingo"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunoDomingo = c
    '                    Case "COMIDA"
    '                        ComidaDomingo = c
    '                    Case "CENA"
    '                        CenaDomingo = c
    '                End Select

    '        End Select
    '    Next
    '    Dim dtAjustes As DataTable = sqlExecute("SELECT SUM(ajuste) as Total,ano,periodo,dia,servicio FROM ajustes where ano+periodo = '" + cmbPeriodos.SelectedValue + "' group by ano,periodo,dia,servicio", "cafeteria")
    '    For Each r As DataRow In dtAjustes.Rows
    '        Dim d As String = r.Item("dia")
    '        Dim s As String = r.Item("servicio")
    '        Dim c As Integer = r.Item("total")
    '        Select Case d
    '            Case "Lunes"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunoLunesAjuste = c

    '                    Case "COMIDA"

    '                        ComidaLunesAjuste = c

    '                    Case "CENA"

    '                        CenaLunesAjuste = c

    '                End Select
    '            Case "Martes"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunoMartesAjuste = c

    '                    Case "COMIDA"
    '                        ComidaMartesAjuste = c

    '                    Case "CENA"
    '                        CenaMartesAjuste = c

    '                End Select
    '            Case "Miércoles"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunomiercolesAjuste = c

    '                    Case "COMIDA"
    '                        ComidamiercolesAjuste = c

    '                    Case "CENA"
    '                        CenamiercolesAjuste = c

    '                End Select
    '            Case "Jueves"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunoJuevesAjuste = c

    '                    Case "COMIDA"
    '                        ComidaJuevesAjuste = c

    '                    Case "CENA"
    '                        CenaJuevesAjuste = c

    '                End Select
    '            Case "Viernes"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunoViernesAjuste = c

    '                    Case "COMIDA"
    '                        ComidaViernesAjuste = c

    '                    Case "CENA"
    '                        CenaViernesAjuste = c
    '                End Select
    '            Case "Sábado"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunoSabadoAjuste = c

    '                    Case "COMIDA"
    '                        ComidaSabadoAjuste = c

    '                    Case "CENA"
    '                        CenaSabadoAjuste = c
    '                End Select
    '            Case "Domingo"
    '                Select Case s
    '                    Case "DESAYUNO"
    '                        DesayunoDomingoAjuste = c
    '                    Case "COMIDA"
    '                        ComidaDomingoAjuste = c
    '                    Case "CENA"
    '                        CenaDomingoAjuste = c
    '                End Select

    '        End Select
    '    Next

    '    numDesayunoLunes.Value = DesayunoLunes + DesayunoLunesAjuste
    '    numDesayunoLunes.ForeColor = IIf(DesayunoLunesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numDesayunoLunes, IIf(DesayunoLunesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(DesayunoLunesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))

    '    numDesayunoMartes.Value = DesayunoMartes + DesayunoMartesAjuste
    '    numDesayunoMartes.ForeColor = IIf(DesayunoMartesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numDesayunoMartes, IIf(DesayunoMartesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(DesayunoMartesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '   
    '    numDesayunoMiercoles.Value = Desayunomiercoles + DesayunomiercolesAjuste
    '    numDesayunoMiercoles.ForeColor = IIf(DesayunomiercolesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numDesayunoMiercoles, IIf(DesayunomiercolesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(DesayunomiercolesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numDesayunoJueves.Value = DesayunoJueves + DesayunoJuevesAjuste
    '    numDesayunoJueves.ForeColor = IIf(DesayunoJuevesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numDesayunoJueves, IIf(DesayunoJuevesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(DesayunoJuevesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numDesayunoViernes.Value = DesayunoViernes + DesayunoViernesAjuste
    '    numDesayunoViernes.ForeColor = IIf(DesayunoViernesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numDesayunoViernes, IIf(DesayunoViernesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(DesayunoViernesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numDesayunoSabado.Value = DesayunoSabado + DesayunoSabadoAjuste
    '    numDesayunoSabado.ForeColor = IIf(DesayunoSabadoAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numDesayunoSabado, IIf(DesayunoSabadoAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(DesayunoSabadoAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numDesayunoDomingo.Value = DesayunoDomingo + DesayunoDomingoAjuste
    '    numDesayunoDomingo.ForeColor = IIf(DesayunoDomingoAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numDesayunoDomingo, IIf(DesayunoDomingoAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(DesayunoDomingoAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numComidaLunes.Value = ComidaLunes + ComidaLunesAjuste
    '    numComidaLunes.ForeColor = IIf(ComidaLunesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numComidaLunes, IIf(ComidaLunesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(ComidaLunesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))

    '    numComidaMartes.Value = ComidaMartes + ComidaMartesAjuste
    '    numComidaMartes.ForeColor = IIf(ComidaMartesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numComidaMartes, IIf(ComidaMartesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(ComidaMartesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '   
    '    numComidaMiercoles.Value = Comidamiercoles + ComidamiercolesAjuste
    '    numComidaMiercoles.ForeColor = IIf(ComidamiercolesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numComidaMiercoles, IIf(ComidamiercolesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(ComidamiercolesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numComidaJueves.Value = ComidaJueves + ComidaJuevesAjuste
    '    numComidaJueves.ForeColor = IIf(ComidaJuevesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numComidaJueves, IIf(ComidaJuevesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(ComidaJuevesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numComidaViernes.Value = ComidaViernes + ComidaViernesAjuste
    '    numComidaViernes.ForeColor = IIf(ComidaViernesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numComidaViernes, IIf(ComidaViernesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(ComidaViernesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numComidaSabado.Value = ComidaSabado + ComidaSabadoAjuste
    '    numComidaSabado.ForeColor = IIf(ComidaSabadoAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numComidaSabado, IIf(ComidaSabadoAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(ComidaSabadoAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numComidaDomingo.Value = ComidaDomingo + ComidaDomingoAjuste
    '    numComidaDomingo.ForeColor = IIf(ComidaDomingoAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numComidaDomingo, IIf(ComidaDomingoAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(ComidaDomingoAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numCenaLunes.Value = CenaLunes + CenaLunesAjuste
    '    numCenaLunes.ForeColor = IIf(CenaLunesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numCenaLunes, IIf(CenaLunesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(CenaLunesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))

    '    numCenaMartes.Value = CenaMartes + CenaMartesAjuste
    '    numCenaMartes.ForeColor = IIf(CenaMartesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numCenaMartes, IIf(CenaMartesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(CenaMartesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '   
    '    numCenaMiercoles.Value = Cenamiercoles + CenamiercolesAjuste
    '    numCenaMiercoles.ForeColor = IIf(CenamiercolesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numCenaMiercoles, IIf(CenamiercolesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(CenamiercolesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numCenaJueves.Value = CenaJueves + CenaJuevesAjuste
    '    numCenaJueves.ForeColor = IIf(CenaJuevesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numCenaJueves, IIf(CenaJuevesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(CenaJuevesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numCenaViernes.Value = CenaViernes + CenaViernesAjuste
    '    numCenaViernes.ForeColor = IIf(CenaViernesAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numCenaViernes, IIf(CenaViernesAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(CenaViernesAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numCenaSabado.Value = CenaSabado + CenaSabadoAjuste
    '    numCenaSabado.ForeColor = IIf(CenaSabadoAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numCenaSabado, IIf(CenaSabadoAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(CenaSabadoAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '
    '    numCenaDomingo.Value = CenaDomingo + CenaDomingoAjuste
    '    numCenaDomingo.ForeColor = IIf(CenaDomingoAjuste <> 0, Color.IndianRed, Color.Black)
    '    ToolTipAjuste.SetSuperTooltip(numCenaDomingo, IIf(CenaDomingoAjuste <> 0, New DevComponents.DotNetBar.SuperTooltipInfo(CenaDomingoAjuste.ToString, "", "Cantidad Total Ajustada", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Red), Nothing))
    '    '

    '    numTotalLunes.Value = numDesayunoLunes.Value + numComidaLunes.Value + numCenaLunes.Value
    '    numTotalMartes.Value = numDesayunoMartes.Value + numComidaMartes.Value + numCenaMartes.Value
    '    numTotalMiercoles.Value = numDesayunoMiercoles.Value + numComidaMiercoles.Value + numCenaMiercoles.Value
    '    numTotalJueves.Value = numDesayunoJueves.Value + numComidaJueves.Value + numCenaJueves.Value
    '    numTotalViernes.Value = numDesayunoViernes.Value + numComidaViernes.Value + numCenaViernes.Value
    '    numTotalSabado.Value = numDesayunoSabado.Value + numComidaSabado.Value + numCenaSabado.Value
    '    numTotalDomingo.Value = numDesayunoDomingo.Value + numComidaDomingo.Value + numCenaDomingo.Value

    '    numDesayunoTotal.Value = numDesayunoLunes.Value + numDesayunoMartes.Value + numDesayunoMiercoles.Value + numDesayunoJueves.Value + numDesayunoViernes.Value + numDesayunoSabado.Value + numDesayunoDomingo.Value
    '    numComidaTotal.Value = numComidaLunes.Value + numComidaMartes.Value + numComidaMiercoles.Value + numComidaJueves.Value + numComidaViernes.Value + numComidaSabado.Value + numComidaDomingo.Value
    '    numCenaTotal.Value = numCenaLunes.Value + numCenaMartes.Value + numCenaMiercoles.Value + numCenaJueves.Value + numCenaViernes.Value + numCenaSabado.Value + numCenaDomingo.Value

    '    numTotalFinal.Value = numDesayunoTotal.Value + numComidaTotal.Value + numCenaTotal.Value

    'End Sub

    'Private Sub cmbPeriodos_PopupClose(sender As Object, e As EventArgs) Handles cmbPeriodos.PopupClose
    '    MostrarInformacion()
    'End Sub



    ''Private Sub numDesayunoLunes_ValueChanged(sender As Object, e As EventArgs) Handles numDesayunoLunes.ValueChanged
    ''    MessageBox.Show(numDesayunoLunes.Value.ToString)
    ''End Sub

    'Private Sub numDesayunoLunes_Click(sender As Object, e As EventArgs) Handles numDesayunoLunes.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numDesayunoLunes.Value - (DesayunoLunes + DesayunoLunesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Desayuno del dia Lunes? de " + (DesayunoLunes + DesayunoLunesAjuste).ToString + " a " + numDesayunoLunes.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Lunes','DESAYUNO','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numDesayunoMartes_Click(sender As Object, e As EventArgs) Handles numDesayunoMartes.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numDesayunoMartes.Value - (DesayunoMartes + DesayunoMartesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Desayuno del dia Martes? de " + (DesayunoMartes + DesayunoMartesAjuste).ToString + " a " + numDesayunoMartes.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Martes','DESAYUNO','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numDesayunoMiercoles_Click(sender As Object, e As EventArgs) Handles numDesayunoMiercoles.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numDesayunoMiercoles.Value - (Desayunomiercoles + DesayunomiercolesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Desayuno del dia Miercoles? de " + (DesayunoMiercoles + DesayunoMiercolesAjuste).ToString + " a " + numDesayunoMiercoles.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Miércoles','DESAYUNO','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numDesayunoJueves_Click(sender As Object, e As EventArgs) Handles numDesayunoJueves.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numDesayunoJueves.Value - (DesayunoJueves + DesayunoJuevesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Desayuno del dia Jueves? de " + (DesayunoJueves + DesayunoJuevesAjuste).ToString + " a " + numDesayunoJueves.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Jueves','DESAYUNO','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numDesayunoViernes_Click(sender As Object, e As EventArgs) Handles numDesayunoViernes.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numDesayunoViernes.Value - (DesayunoViernes + DesayunoViernesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Desayuno del dia Viernes? de " + (DesayunoViernes + DesayunoViernesAjuste).ToString + " a " + numDesayunoViernes.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Viernes','DESAYUNO','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numDesayunoSabado_Click(sender As Object, e As EventArgs) Handles numDesayunoSabado.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numDesayunoSabado.Value - (DesayunoSabado + DesayunoSabadoAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Desayuno del dia Sabado? de " + (DesayunoSabado + DesayunoSabadoAjuste).ToString + " a " + numDesayunoSabado.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Sábado','DESAYUNO','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numDesayunoDomingo_Click(sender As Object, e As EventArgs) Handles numDesayunoDomingo.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numDesayunoDomingo.Value - (DesayunoDomingo + DesayunoDomingoAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Desayuno del dia Domingo? de " + (DesayunoDomingo + DesayunoDomingoAjuste).ToString + " a " + numDesayunoDomingo.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Domingo','DESAYUNO','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub



    'Private Sub numComidaLunes_Click(sender As Object, e As EventArgs) Handles numComidaLunes.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numComidaLunes.Value - (ComidaLunes + ComidaLunesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Comida del dia Lunes? de " + (ComidaLunes + ComidaLunesAjuste).ToString + " a " + numComidaLunes.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Lunes','COMIDA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numComidaMartes_Click(sender As Object, e As EventArgs) Handles numComidaMartes.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numComidaMartes.Value - (ComidaMartes + ComidaMartesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Comida del dia Martes? de " + (ComidaMartes + ComidaMartesAjuste).ToString + " a " + numComidaMartes.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Martes','COMIDA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numComidaMiercoles_Click(sender As Object, e As EventArgs) Handles numComidaMiercoles.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numComidaMiercoles.Value - (Comidamiercoles + ComidamiercolesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Comida del dia Miercoles? de " + (ComidaMiercoles + ComidaMiercolesAjuste).ToString + " a " + numComidaMiercoles.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Miércoles','COMIDA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numComidaJueves_Click(sender As Object, e As EventArgs) Handles numComidaJueves.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numComidaJueves.Value - (ComidaJueves + ComidaJuevesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Comida del dia Jueves? de " + (ComidaJueves + ComidaJuevesAjuste).ToString + " a " + numComidaJueves.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Jueves','COMIDA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numComidaViernes_Click(sender As Object, e As EventArgs) Handles numComidaViernes.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numComidaViernes.Value - (ComidaViernes + ComidaViernesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Comida del dia Viernes? de " + (ComidaViernes + ComidaViernesAjuste).ToString + " a " + numComidaViernes.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Viernes','COMIDA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numComidaSabado_Click(sender As Object, e As EventArgs) Handles numComidaSabado.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numComidaSabado.Value - (ComidaSabado + ComidaSabadoAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Comida del dia Sabado? de " + (ComidaSabado + ComidaSabadoAjuste).ToString + " a " + numComidaSabado.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Sábado','COMIDA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numComidaDomingo_Click(sender As Object, e As EventArgs) Handles numComidaDomingo.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numComidaDomingo.Value - (ComidaDomingo + ComidaDomingoAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Comida del dia Domingo? de " + (ComidaDomingo + ComidaDomingoAjuste).ToString + " a " + numComidaDomingo.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Domingo','COMIDA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub


    'Private Sub numCenaLunes_Click(sender As Object, e As EventArgs) Handles numCenaLunes.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numCenaLunes.Value - (CenaLunes + CenaLunesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Cena del dia Lunes? de " + (CenaLunes + CenaLunesAjuste).ToString + " a " + numCenaLunes.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Lunes','CENA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numCenaMartes_Click(sender As Object, e As EventArgs) Handles numCenaMartes.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numCenaMartes.Value - (CenaMartes + CenaMartesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Cena del dia Martes? de " + (CenaMartes + CenaMartesAjuste).ToString + " a " + numCenaMartes.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Martes','CENA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numCenaMiercoles_Click(sender As Object, e As EventArgs) Handles numCenaMiercoles.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numCenaMiercoles.Value - (Cenamiercoles + CenamiercolesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Cena del dia Miercoles? de " + (CenaMiercoles + CenaMiercolesAjuste).ToString + " a " + numCenaMiercoles.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Miércoles','CENA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numCenaJueves_Click(sender As Object, e As EventArgs) Handles numCenaJueves.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numCenaJueves.Value - (CenaJueves + CenaJuevesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Cena del dia Jueves? de " + (CenaJueves + CenaJuevesAjuste).ToString + " a " + numCenaJueves.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Jueves','CENA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numCenaViernes_Click(sender As Object, e As EventArgs) Handles numCenaViernes.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numCenaViernes.Value - (CenaViernes + CenaViernesAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Cena del dia Viernes? de " + (CenaViernes + CenaViernesAjuste).ToString + " a " + numCenaViernes.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Viernes','CENA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numCenaSabado_Click(sender As Object, e As EventArgs) Handles numCenaSabado.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numCenaSabado.Value - (CenaSabado + CenaSabadoAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Cena del dia Sabado? de " + (CenaSabado + CenaSabadoAjuste).ToString + " a " + numCenaSabado.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Sábado','CENA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub
    'Private Sub numCenaDomingo_Click(sender As Object, e As EventArgs) Handles numCenaDomingo.Validated
    '    If year <> "" And period <> "" Then
    '        Dim diferencia As Integer = numCenaDomingo.Value - (CenaDomingo + CenaDomingoAjuste)
    '        If diferencia <> 0 Then
    '            If MessageBox.Show("¿Deseas guardar el ajuste al Cena del dia Domingo? de " + (CenaDomingo + CenaDomingoAjuste).ToString + " a " + numCenaDomingo.Value.ToString, "Ajustar Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                sqlExecute("insert into ajustes(ano,periodo,dia,servicio,ajuste) values('" + year + "','" + period + "','Domingo','CENA','" & diferencia.ToString & "')", "cafeteria")
    '            End If
    '        End If
    '    End If
    '    MostrarInformacion()
    'End Sub

    'Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click


    '    Me.Close()
    'End Sub

    'Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
    '    Dim query As String = "" & _
    '        "SELECT  SUM(TOTAL) AS total,dia,servicio,ano,periodo from " & _
    '        "(select count(reloj) as total,dia,servicio,ano,periodo " & _
    '        "from marcajesvw group by dia,servicio,ano,periodo " & _
    '        "UNION ALL " & _
    '        "select  sum(ajuste) as total,dia,servicio,ano,periodo " & _
    '        "from ajustes GROUP BY dia,servicio,ano,periodo)a " & _
    '        "where a.ano+a.periodo='" + cmbPeriodos.SelectedValue.ToString + "' " & _
    '        "group by a.dia,a.servicio,a.ano,a.periodo"
    '    Dim dtTotal As DataTable = sqlExecute(query, "cafeteria")
    '    frmVistaPrevia.LlamarReporte("Reporte de total de servicios con ajuste", dtTotal)
    '    frmVistaPrevia.ShowDialog()
    'End Sub


#End Region
#Region "Codigobk"
    Private Sub ActualizarYardaLiberty()
        Dim dias As New ArrayList
        dias.Add("Lunes")
        dias.Add("Martes")
        dias.Add("Miércoles")
        dias.Add("Jueves")
        dias.Add("Sábado")
        dias.Add("Domingo")
        dias.Add("Viernes")
        Dim seleccionado As String
        Dim Ano As String
        Dim Periodo As String
        Dim Yarda As Integer
        Dim Liberty As Integer
        Dim dtAjustesDefault As DataTable
        Dim dtServicios As DataTable = sqlExecute("select * from servicios", "CAFETERIA")
        Dim dtPeriodoDefault As DataTable = sqlExecute("SELECT ano+periodo as seleccionado,* FROM PARAMETROS", "CAFETERIA")
        If dtPeriodoDefault.Rows.Count > 0 Then
            If cmbPeriodos.SelectedValue <> Nothing Then
                seleccionado = cmbPeriodos.SelectedValue.ToString.Substring(0, 4) & cmbPeriodos.SelectedValue.ToString.Substring(4, 2)
                Ano = cmbPeriodos.SelectedValue.ToString.Substring(0, 4)
                Periodo = cmbPeriodos.SelectedValue.ToString.Substring(4, 2)
            Else
                seleccionado = ObtenerAnoPeriodo(Date.Now)
                Ano = Date.Now.Year
                Periodo = ObtenerAnoPeriodo(Date.Now).Substring(4, 2)
            End If
            Yarda = dtPeriodoDefault.Rows(0).Item("DEFAULT_YARDA")
            Liberty = dtPeriodoDefault.Rows(0).Item("DEFAULT_LIBERTY")
            For Each s As String In dias
                For Each r As DataRow In dtServicios.Rows

                    dtAjustesDefault = sqlExecute("SELECT * FROM AJUSTES WHERE ano+periodo = '" + seleccionado + "' and tipo = 'Liberty' AND SERVICIO= '" + r.Item("SERVICIO").ToString.Trim + "' AND DIA='" + s + "' AND PLANTA='" + PlantaTemp + "'", "CAFETERIA")
                    If Not dtAjustesDefault.Rows.Count > 0 Then
                        sqlExecute("INSERT INTO AJUSTES(ANO,PERIODO,DIA,SERVICIO,AJUSTE,TIPO,COSTO,PLANTA) values('" + Ano + "','" + Periodo + "','" + s + "','" + r.Item("SERVICIO").ToString.Trim + "','" + Liberty.ToString + "','Liberty','" + (Liberty * r.Item("COSTO_PRIMERA_NORMAL")).ToString + "','" + PlantaTemp + "')", "CAFETERIA")
                    End If
                    dtAjustesDefault = sqlExecute("SELECT * FROM AJUSTES WHERE ano+periodo = '" + seleccionado + "' and tipo = 'Yarda' AND SERVICIO= '" + r.Item("SERVICIO").ToString.Trim + "' AND DIA='" + s + "' AND PLANTA ='" + PlantaTemp + "'", "CAFETERIA")
                    If Not dtAjustesDefault.Rows.Count > 0 Then
                        sqlExecute("INSERT INTO AJUSTES(ANO,PERIODO,DIA,SERVICIO,AJUSTE,TIPO,COSTO,PLANTA) values('" + Ano + "','" + Periodo + "','" + s + "','" + r.Item("SERVICIO").ToString.Trim + "','" + Yarda.ToString + "','Yarda','" + (Yarda * r.Item("COSTO_PRIMERA_NORMAL")).ToString + "','" + PlantaTemp + "')", "CAFETERIA")
                    End If


                    '********************AGREGAR AJUSTES EN 0 PARA QUE SALGAN TODOS LOS VALORES EN LOS REPORTES *******************************
                    dtAjustesDefault = sqlExecute("SELECT * FROM AJUSTES WHERE ano+periodo = '" + seleccionado + "' and tipo = 'Normal' AND SERVICIO= '" + r.Item("SERVICIO").ToString.Trim + "' AND DIA='" + s + "' AND PLANTA= '" + PlantaTemp + "'", "CAFETERIA")
                    If Not dtAjustesDefault.Rows.Count > 0 Then
                        sqlExecute("INSERT INTO AJUSTES(ANO,PERIODO,DIA,SERVICIO,AJUSTE,TIPO,COSTO,PLANTA) values('" + Ano + "','" + Periodo + "','" + s + "','" + r.Item("SERVICIO").ToString.Trim + "','0','Normal','0','" + PlantaTemp + "')", "CAFETERIA")
                    End If
                    dtAjustesDefault = sqlExecute("SELECT * FROM AJUSTES WHERE ano+periodo = '" + seleccionado + "' and tipo = 'Extra' AND SERVICIO= '" + r.Item("SERVICIO").ToString.Trim + "' AND DIA='" + s + "' AND PLANTA= '" + PlantaTemp + "'", "CAFETERIA")
                    If Not dtAjustesDefault.Rows.Count > 0 Then
                        sqlExecute("INSERT INTO AJUSTES(ANO,PERIODO,DIA,SERVICIO,AJUSTE,TIPO,COSTO,PLANTA) values('" + Ano + "','" + Periodo + "','" + s + "','" + r.Item("SERVICIO").ToString.Trim + "','0','Extra','0','" + PlantaTemp + "')", "CAFETERIA")
                    End If
                    dtAjustesDefault = sqlExecute("SELECT * FROM AJUSTES WHERE ano+periodo = '" + seleccionado + "' and tipo = 'Ajuste' AND SERVICIO= '" + r.Item("SERVICIO").ToString.Trim + "' AND DIA='" + s + "' AND PLANTA='" + PlantaTemp + "'", "CAFETERIA")
                    If Not dtAjustesDefault.Rows.Count > 0 Then
                        sqlExecute("INSERT INTO AJUSTES(ANO,PERIODO,DIA,SERVICIO,AJUSTE,TIPO,COSTO,PLANTA) values('" + Ano + "','" + Periodo + "','" + s + "','" + r.Item("SERVICIO").ToString.Trim + "','0','Ajuste','0','" + PlantaTemp + "')", "CAFETERIA")
                    End If
                Next
            Next
        End If


    End Sub
    Private Sub ActualizarCostes()
        Dim query As String = ""
        query = query + "UPDATE MARCAJES SET MARCAJES.COSTO = case when MARCAJESVW.REPETICION = 1 AND marcajesVW.EXTRA = 1 THEN servicios.COSTO_REPETICION_EXTRA ELSE "
        query = query + "CASE WHEN MARCAJESVW.REPETICION = 1 AND marcajesVW.EXTRA = 0 THEN servicios.COSTO_REPETICION_NORMAL ELSE "
        query = query + "CASE WHEN marcajesVW.REPETICION = 0 AND marcajesVW.EXTRA = 1 THEN servicios.COSTO_PRIMERA_EXTRA ELSE "
        query = query + "servicios.COSTO_PRIMERA_NORMAL END END END "
        query = query + "FROM MARCAJESVW "
        query = query + "LEFT JOIN SERVICIOS ON SERVICIOS.SERVICIO = marcajesVW.SERVICIO "
        query = query + "LEFT JOIN MARCAJES ON MARCAJES._ID = marcajesVW._ID "
        query = query + "WHERE MARCAJES.COSTO = 0 "
        sqlExecute(query, "CAFETERIA")

    End Sub
    'Dim QueryResumenSemanal As String = "" & _
    '"SELECT " & _
    '"marcajesVW.SERVICIO," & _
    '"marcajesVW.ANO," & _
    '"marcajesVW.PERIODO," & _
    '"(CASE WHEN marcajesVW.COD_TURNO = '' THEN 'NORMAL' ELSE (CASE WHEN marcajesVW.TURNO_ASISTE = marcajesVW.COD_TURNO THEN 'NORMAL' ELSE 'EXTRA'END) END) AS TIEMPO," & _
    '"SUM(CASE WHEN marcajesVW.dia='Lunes' and REPETICION='0' THEN 1 ELSE 0 END) AS 'LUNES PRIMERA'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Lunes' and REPETICION='1' THEN 1 ELSE 0 END) AS 'LUNES REPETICION'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Martes' and REPETICION='0' THEN 1 ELSE 0 END) AS 'MARTES PRIMERA'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Martes' and REPETICION='1' THEN 1 ELSE 0 END) AS 'MARTES REPETICION'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Miércoles' and REPETICION='0' THEN 1 ELSE 0 END) AS 'MIERCOLES PRIMERA'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Miércoles' and REPETICION='1' THEN 1 ELSE 0 END) AS 'MIERCOLES REPETICION'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Jueves' and REPETICION='0' THEN 1 ELSE 0 END) AS 'JUEVES PRIMERA'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Jueves' and REPETICION='1' THEN 1 ELSE 0 END) AS 'JUEVES REPETICION'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Viernes' and REPETICION='0' THEN 1 ELSE 0 END) AS 'VIERNES PRIMERA'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Viernes' and REPETICION='1' THEN 1 ELSE 0 END) AS 'VIERNES REPETICION'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Sábado' and REPETICION='0' THEN 1 ELSE 0 END) AS 'SABADO PRIMERA'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Sábado' and REPETICION='1' THEN 1 ELSE 0 END) AS 'SABADO REPETICION'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Domingo' and REPETICION='0' THEN 1 ELSE 0 END) AS 'DOMINGO PRIMERA'," & _
    '"SUM(CASE WHEN marcajesVW.dia='Domingo' and REPETICION='1' THEN 1 ELSE 0 END) AS 'DOMINGO REPETICION' " & _
    '"FROM marcajesVW " & _
    '"GROUP BY " & _
    '"marcajesVW.SERVICIO, " & _
    '"marcajesVW.ANO, " & _
    '"marcajesVW.PERIODO, " & _
    '"(CASE WHEN marcajesVW.COD_TURNO = '' THEN 'NORMAL' ELSE (CASE WHEN marcajesVW.TURNO_ASISTE = marcajesVW.COD_TURNO THEN 'NORMAL' ELSE 'EXTRA'END) END) "

    'Dim dtResumenSemanal As DataTable = sqlExecute(QueryResumenSemanal, "CAFETERIA")

    ''  dgResumenSemanal.PrimaryGrid.DataSource = dtResumenSemanal
    ''dgResumenSemanal.PrimaryGrid.GroupByRow


    'Dim dtPeriodos As DataTable = sqlExecute("select ano+periodo as 'Seleccionado', ano as 'Año',periodo as 'Semana',cast(fecha_ini as nvarchar) as 'Fecha inicio',cast(fecha_fin as nvarchar) as 'Fecha fin' from periodos where periodo <54 order by ano+periodo desc ", "ta")
    '    cmbPeriodos.GroupingMembers = "Año"
    '    cmbPeriodos.DisplayMembers = "Seleccionado,Año,Semana,Fecha inicio,Fecha fin"
    '    cmbPeriodos.ValueMember = "Seleccionado"
    '    cmbPeriodos.DataSource = dtPeriodos
    '' MostrarInformacion()
#End Region

    Private Sub LabelX42_Click(sender As Object, e As EventArgs) Handles LabelX42.Click

    End Sub

    Private Sub numComJue1Liberty_ValueChanged(sender As Object, e As EventArgs) Handles numComJue1Liberty.ValueChanged

    End Sub

    Private Sub gpTotales_MouseDown(sender As Object, e As MouseEventArgs) Handles gpTotales.MouseDown

    End Sub

    Dim serv As String
    Dim dia As String
    Dim rep As String
    Dim norext As String
    Dim turno As String
    Private Sub numDesLun1Normal_MouseDown(sender As Object, e As MouseEventArgs) Handles numDesLun1Normalro.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            mnuVerD.Visible = True

            Dim btn As DevComponents.Editors.DoubleInput = TryCast(sender, DevComponents.Editors.DoubleInput)

            serv = ObtenerServicio(btn.Name)
            dia = ObtenerDia(btn.Name)
            rep = ObtenerIteracion(btn.Name)
            norext = ObtenerTipo(btn.Name)
            If serv = "COMIDA" Then
                turno = " and turno_asiste = '" & ObtenerTurno(btn.Name) & "'"
            Else
                turno = ""
            End If


        End If


    End Sub

    Private Sub mnuVerD_Click(sender As Object, e As EventArgs) Handles mnuVerD.Click

        Dim dtinforep As DataTable = sqlExecute("select folio, repeticion, reloj, nombres, fechahora, extra, dia, servicio, periodo from marcajesvw where ano+periodo = '" & cmbPeriodos.SelectedValue & "' and servicio = '" & serv & "' and dia = '" & dia & "' and repeticion = '" & rep & "' and extra = '" & IIf(norext = "Normal", 0, 1).ToString & "' and planta = '" & PlantaTemp & "'" & turno & "", "CAFETERIA")

        Dim planta As New Data.DataColumn("planta", GetType(System.String))

        planta.DefaultValue = PlantaTemp
        dtinforep.Columns.Add(planta)


        frmVistaPrevia.LlamarReporte("Reporte de servicios detalle extra", dtinforep)
        frmVistaPrevia.ShowDialog()



    End Sub
    Private Sub numDesLun2Ajuste_Validated(sender As Object, e As EventArgs)
        Dim c As DevComponents.Editors.DoubleInput = TryCast(sender, DevComponents.Editors.DoubleInput)
        AjusteFinal = c.Value - AjusteTemp
        Dim y As String = cmbPeriodos.SelectedValue.ToString.Substring(0, 4)
        Dim p As String = cmbPeriodos.SelectedValue.ToString.Substring(4, 2)
        Dim dtInformacionCostos As DataTable = sqlExecute("select * from servicios where servicio = '" + ObtenerServicio(c.Name) + "'", "CAFETERIA")
        If dtInformacionCostos.Rows.Count > 0 Then
            Dim costo As Double = IIf(IsDBNull(dtInformacionCostos.Rows(0).Item("COSTO_REPETICION_NORMAL")), 0, dtInformacionCostos.Rows(0).Item("COSTO_REPETICION_NORMAL"))
            Dim query As String = "insert into ajustes(ANO,PERIODO,DIA,SERVICIO,AJUSTE,TIPO,COSTO,PLANTA)"
            query = query + "VALUES('" + y + "','" + p + "','" + ObtenerDia(c.Name) + "','" + ObtenerServicio(c.Name) + "','" + AjusteFinal.ToString + "','AjusteR','" + (AjusteFinal * costo).ToString + "','" + PlantaTemp + "')"
            sqlExecute(query, "CAFETERIA")
        End If

        LlenarValores()
        LlenarValoresComida()
        LlenarTotales()
    End Sub
End Class