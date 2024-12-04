Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json.Linq.JObject
Imports System.Net
Imports System.Security.Cryptography
Imports System.Threading

Public Class frmInfoAPI

    Dim dicInfo As New Dictionary(Of String, String)
    Dim resultados As Dictionary(Of String, Object) = Nothing
    Dim dicReg As New Dictionary(Of String, Object)

    Dim dtInfo As DataTable
    Dim strInicio As String
    Dim strFin As String
    Dim dtAanio As DataTable
    Dim dtPer As DataTable
    Dim log As New List(Of String)
    Dim det As New List(Of String)
    Dim op As String = ""
    Dim strComprueba As New ArrayList

    Private Sub frmInfoAPI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtPer = sqlExecute("select ano,periodo,CONVERT(varchar,fecha_ini,23) as fecha_ini,CONVERT(varchar,fecha_fin,23) as fecha_fin " &
                               "from ta.dbo.periodos where ISNULL(periodo_especial,0)=0")
            dtAanio = sqlExecute("select distinct ano from ta.dbo.periodos order by ano desc")
            cmbAno.DataSource = dtAanio
            ParametrosAPI()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al inicializar la forma.", "Error carga forma.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "APIBonos_iniciaForma", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub BloqueoControles(disponible As Boolean)
        Try
            cmbAno.Enabled = disponible
            cmbPeriodo.Enabled = disponible
            intRango.Enabled = disponible
            btnExporta.Enabled = disponible
            btnConexion.Enabled = disponible
            btnNomina.Enabled = disponible
        Catch ex As Exception
        End Try
    End Sub

    Private Sub hiloTrabajo_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles hiloTrabajo.DoWork
        Select Case op
            Case "Conexion"
                Conexion()
            Case "Exportar_nomina"
                ExportarNomina()
        End Select
    End Sub

    Private Sub hiloTrabajo_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles hiloTrabajo.RunWorkerCompleted
        BloqueoControles(True)

        If op = "Exportar_nomina" Then
            lstDet.Items.Add("")
        End If

        hiloTrabajo.CancelAsync()
    End Sub

    Private Sub hiloTrabajo_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles hiloTrabajo.ProgressChanged
        Try
            CircularProgress4.Value = e.ProgressPercentage
            Select Case op
                Case "Conexion"
                    lstLog.Items.Clear()
                    If log.Count > 0 Then
                        For Each lg In log : lstLog.Items.Add(lg) : Next
                    End If
                Case "Exportar_nomina"
                    lstDet.Items.Clear()
                    If det.Count > 0 Then
                        For Each er In det : lstDet.Items.Add(er) : Next
                    End If
            End Select
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "APIBonos_progresoHilo", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Para acceder a la api se requieren 4 parametros que se encuentran encriptados por seguridad
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ParametrosAPI()
        Try
            Dim dtCias = sqlExecute("select top 1 COD_COMP,NOMBRE,rfc,curp,CIA_DEFAULT from personal.dbo.cias where CIA_DEFAULT=1")
            Dim dtParam = sqlExecute("select * from nomina.dbo.validaciones_procnomina where tipo='Variable_api'")
            Dim faltaInfo = False

            If dtCias.Rows.Count > 0 And dtParam.Rows.Count > 0 Then
                Dim rfc = If(IsDBNull(dtCias.Rows(0)("rfc")), "", dtCias.Rows(0)("rfc").ToString.Trim)
                Dim curp = If(IsDBNull(dtCias.Rows(0)("curp")), "", dtCias.Rows(0)("curp").ToString.Trim)
                Dim llave = (rfc & curp).ToString.PadRight(32, "#")

                If llave.Length > 0 Then
                    For Each p In dtParam.Rows
                        Dim strVar = p("variable").ToString.Trim
                        Dim strVal = If(IsDBNull(p("valor")), "", p("valor").ToString.Trim)
                        If strVal.Length = 0 Then faltaInfo = True : Exit For
                        dicInfo.Add(strVar, AES_Desencriptar(strVal, llave))
                    Next
                End If
            Else
                faltaInfo = True
            End If

            If faltaInfo Then
                MessageBox.Show("Falta información de parametros para la conexión de la api. Por favor, contacte al admin. del sistema",
                                "Información faltante", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al inicializar los parametros del API.", "Error parametros API.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "APIBonos_cargaParametros", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Método POST API
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="RestURL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Async Function llamadaServicioPOST(data As Dictionary(Of String, String), RestURL As String) As Task(Of Dictionary(Of String, Object))
        Try

            Dim cliente = New HttpClient()
            Dim peticion = New HttpRequestMessage(HttpMethod.Post, RestURL)
            peticion.Content = New FormUrlEncodedContent(data)

            Dim respuesta = cliente.SendAsync(peticion).GetAwaiter().GetResult

            If Not respuesta.StatusCode = Net.HttpStatusCode.OK Then : Throw New Exception() : End If
            Dim x = Await respuesta.Content.ReadAsStringAsync()
            Return JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(x)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Inicializa conexión a API
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Iniciar(ByVal fecha As Date)
        Try
            resultados = llamadaServicioPOST(ValoresConexion(fecha), "https://gmtransport.co/GMTERPV8_PROCESOSESPECIALES_WEB/ES/API.awp").Result
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Valores de parametros
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ValoresConexion(ByVal fecha As Date) As Dictionary(Of String, String)
        Try
            Dim strFecha = FechaSQL(fecha).ToString.Replace("-", "")
            Dim dic As New Dictionary(Of String, String)
            For Each kvp As KeyValuePair(Of String, String) In dicInfo : dic.Add(kvp.Key, kvp.Value) : Next
            Dim str = dic.Item("Parametros").ToString.Replace("{0}", strFecha)
            dic.Item("Parametros") = str
            Return dic
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al asignar valores de parametros.", "Error asignar valores parametros.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "APIBonos_valoresParametros", ex.HResult, ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Conexion con el API
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Conexion()
        Try
            Dim aviso = "Realizando conexión a API"
            Dim dtJsonInfo As New DataTable
            Dim col = {"IdOperador", "NombreOperador", "TipoViaje", "IdViaje", "Viaje", "Origen", "Destino", "ImporteLiquidar", "Salida", "Llegada"}
            For Each c In col : dtJsonInfo.Columns.Add(c, GetType(Object)) : Next

            '-- Establecer fechas de inicio y fin
            Dim fhaIni = "", fhaFin = "", ini As Date = Nothing, fin As Date = Nothing
            fhaIni = dtPer.Select("ano='" & cmbAno.SelectedValue & "' and periodo='" & cmbPeriodo.SelectedValue & "'").First.Item("fecha_ini")
            fhaFin = dtPer.Select("ano='" & cmbAno.SelectedValue & "' and periodo='" & cmbPeriodo.SelectedValue & "'").First.Item("fecha_fin")
            ini = Convert.ToDateTime(fhaIni)
            fin = Convert.ToDateTime(fhaFin)

            '-- Validaciones
            If (fhaIni = "" Or fhaFin = "") Then
                MessageBox.Show("Error en la selección de las fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim rangoAnterior = intRango.Value * -1
                Dim fechaIni = Convert.ToDateTime(fhaIni).AddDays(rangoAnterior) : strInicio = FechaSQL(fechaIni)
                Dim fechaFin = Convert.ToDateTime(fhaFin) : strFin = FechaSQL(fechaFin)
                Dim diff = DateDiff(DateInterval.Day, fechaIni, fechaFin)
                Dim counter = 0

                For i = 0 To diff

                    Iniciar(fechaIni.AddDays(i))

                    Dim cont = 0
                    Dim newRow As DataRow
                    Dim r = Nothing

                    Try : r = resultados("Result").ToString
                    Catch ex As Exception : GoTo Err
                    End Try

                    Dim JsonInfo As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(r)

                    For Each info In JsonInfo("Viajes")
                        Dim JsonDic = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(info.ToString)
                        newRow = dtJsonInfo.NewRow

                        For Each row In JsonDic
                            If col.Contains(row.Key) Then
                                newRow(row.Key) = row.Value
                            End If
                        Next

                        dtJsonInfo.Rows.Add(newRow)
                        cont += 1
                    Next

                    '-- Aplicar filtros de registros duplicados
                    Dim lstFiltro As New ArrayList
                    Dim dtClon = dtJsonInfo.Clone
                    Dim strFiltro = ""

                    For Each cRow In dtJsonInfo.Select("", "IdOperador asc")
                        strFiltro = cRow("IdOperador").ToString.Trim & "_" & cRow("IdViaje").ToString.Trim &
                                    "_" & cRow("Origen").ToString.Trim & "_" & cRow("Destino").ToString.Trim

                        If Not lstFiltro.Contains(strFiltro) Then lstFiltro.Add(strFiltro) Else Continue For
                        dtClon.ImportRow(cRow)
                    Next

                    dtJsonInfo = dtClon.Copy

Err:
                    If Not Me.hiloTrabajo Is Nothing Then : Me.hiloTrabajo.ReportProgress(100 * counter / diff + 1) : End If
                    counter += 1

                    log.Add(FechaSQL(fechaIni.AddDays(i)) & " - " & cont & " " & "registros")
                Next

                '-- Filtrar las columnas de "salida" y "llegada" de la info. obtenida de acuerdo a las fechas del periodo
                Dim dtFiltro = dtJsonInfo.Clone
                dtJsonInfo.DefaultView.Sort = "salida asc"
                dtJsonInfo = dtJsonInfo.DefaultView.ToTable

                For Each p In dtJsonInfo.Rows
                    Dim strSalida = p("salida").ToString
                    Dim strLlegada = p("llegada").ToString

                    If strSalida = "0000-00-00T00:00:00.000" Or strLlegada = "0000-00-00T00:00:00.000" Then
                        Continue For
                    End If

                    'Dim salida As Date = FechaSQL(Convert.ToDateTime(p("salida")))
                    Dim llegada As Date = FechaSQL(Convert.ToDateTime(p("llegada")))

                    If (llegada >= ini And llegada <= fin) Then
                        Dim nr As DataRow = dtFiltro.NewRow
                        nr = p
                        dtFiltro.ImportRow(nr)
                    End If
                Next

                dgv1.PrimaryGrid.DataSource = dtFiltro
                dtInfo = dtFiltro.Copy
            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error en la conexión al API.", "Error conexión.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "APIBonos_conexionAPI", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Limpiar controles
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Limpiar()
        Try
            resultados = Nothing
            dtInfo = Nothing
            strInicio = Nothing
            strFin = Nothing

            log.Clear()
            det.Clear()
            strComprueba.Clear()

            dgv1.PrimaryGrid.DataSource = Nothing
            dgv1.PrimaryGrid.Columns.Clear()
            lstLog.Items.Clear()
            lstDet.Items.Clear()
            CircularProgress4.Value = 0
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "APIBonos_limpiaControles", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnConexion_Click(sender As Object, e As EventArgs) Handles btnConexion.Click
        Limpiar()
        BloqueoControles(False)
        op = "Conexion"
        hiloTrabajo.RunWorkerAsync()
    End Sub

    Private Sub btnExporta_Click(sender As Object, e As EventArgs) Handles btnExporta.Click
        Try
            Dim info = ProcesoNomina.tableToExcelPackage(dtInfo, "Registros_de_" & strInicio & "_a_" & strFin)
            ProcesoNomina.saveExcelFile("Registros_de_" & strInicio & "_a_" & strFin, info)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error en la generación del excel.", "Error excel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "APIBonos_excel", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Selecciona el año del periodo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbAno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAno.SelectedIndexChanged
        Try
            Dim dt = dtPer.Select("ano='" & cmbAno.SelectedNode.ToString.Trim & "'").CopyToDataTable
            Dim dtFiltro = New DataView(dt, "", "periodo asc", DataViewRowState.CurrentRows).ToTable(False, "periodo", "fecha_ini", "fecha_fin")
            cmbPeriodo.DataSource = dtFiltro
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Se exporta el resultado a los ajustes de nómina
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnNomina_Click(sender As Object, e As EventArgs) Handles btnNomina.Click
        Try
            op = "Exportar_nomina"
            BloqueoControles(False)
            hiloTrabajo.RunWorkerAsync()
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' 'Evento DrawItem del ListBox2 para pintar los items
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub lstDet_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lstDet.DrawItem
        Try
            e.DrawBackground()
            Dim brush As Brush = Brushes.White
            Dim str = lstDet.Items(e.Index).ToString()

            If (lstDet.Items(e.Index).ToString().Contains("*")) Then
                brush = Brushes.OrangeRed
            ElseIf (lstDet.Items(e.Index).ToString().Contains("[")) Then
                brush = Brushes.Yellow
            Else
                brush = Brushes.LightGreen
            End If

            e.DrawFocusRectangle()
            e.Graphics.DrawString(str, e.Font, brush, e.Bounds, StringFormat.GenericDefault)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "APIBonos_cargaLog", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Exportación de registros a ajustesnom
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ExportarNomina()
        Try
            Dim nombreOperador = (From i In dtInfo.Rows Select i("nombreoperador").ToString.Trim).ToList().Distinct
            Dim dtPer = sqlExecute("select reloj,(rtrim(apaterno) + ' ' +rtrim(amaterno) + ' ' + rtrim(nombre)) as nombre_completo from personal.dbo.personal")
            Dim sqlInsert = "insert into nomina.dbo.ajustes_nom (reloj,ano,periodo,monto,concepto,numcredito,tipo_periodo) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');"
            Dim strQuery As New ArrayList
            Dim dtExiste As DataTable
            Dim counter = 0

            det.Clear()
            strComprueba.Clear()

            For Each nom In nombreOperador

                Thread.Sleep(50)
                dicReg.Clear()

                Dim strReloj = ""
                Dim sumMonto = 0.0
                Dim noCredito = Now.ToString("yyyyMMddhhmmssfff")

                For Each sum In dtInfo.Select("NombreOperador='" & nom & "'")
                    sumMonto += CDec(sum("ImporteLiquidar"))
                Next

                counter += 1
                If Not Me.hiloTrabajo Is Nothing Then : Me.hiloTrabajo.ReportProgress(100 * counter / nombreOperador.Count) : End If

                If sumMonto = 0 Then Continue For

                If dtPer.Select("nombre_completo='" & nom & "'").Count > 0 Then
                    strReloj = dtPer.Select("nombre_completo='" & nom & "'").First.Item("reloj").ToString.Trim
                Else
                    If Not det.Contains(nom) Then
                        det.Add("* " & nom & " - No existe nombre en personal.")
                    End If
                    Continue For
                End If

                dicReg.Add("reloj", strReloj) : dicReg.Add("ano", cmbAno.SelectedValue.ToString.Trim)
                dicReg.Add("periodo", cmbPeriodo.SelectedValue.ToString.Trim) : dicReg.Add("monto", sumMonto)
                dicReg.Add("concepto", "BONPRO") : dicReg.Add("tipo_periodo", "S")
                QuerysExistencia("nomina", "ajustes_nom", dicReg)

                strQuery.Add(String.Format(sqlInsert,
                                           strReloj,
                                           cmbAno.SelectedValue.ToString.Trim,
                                           cmbPeriodo.SelectedValue.ToString.Trim,
                                           sumMonto,
                                           "BONPRO",
                                           noCredito,
                                           "S"))
            Next

            '-- Comprueba si ya existen
            For Each existe In strComprueba
                dtExiste = sqlExecute(existe)
                If dtExiste.Rows.Count > 0 Then
                    det.Add("- Empleado " & dtExiste.Rows(0)("reloj").ToString.Trim & " ya tiene un registro en miscelaneos. Año [" & dtExiste.Rows(0)("ano") &
                            "] Periodo [" & dtExiste.Rows(0)("periodo") &
                            "] Monto [" & dtExiste.Rows(0)("monto") & "]")

                    For Each s In strQuery
                        If s.ToString.Contains(dtExiste.Rows(0)("reloj").ToString.Trim) Then
                            strQuery.Remove(s)
                            Exit For
                        End If
                    Next
                End If
            Next

            '-- Insercion de movimientos para ajustes de nómina
            GuardaMovimientosTablaSQL(strQuery)

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error en la exportación de bonos a miscelaneos.", "Error exportación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "APIBonos_exportacion", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Función para comprobar si se agregaron los registros o si existen en ajustes nom
    ''' </summary>
    ''' <param name="baseDatos"></param>
    ''' <param name="tabla"></param>
    ''' <param name="dicInfo"></param>
    ''' <remarks></remarks>
    Private Sub QuerysExistencia(baseDatos As String, tabla As String, dicInfo As Dictionary(Of String, Object))
        Try
            Dim strSQL = "select top 1 * from {0}.dbo.{1} where {2}"
            Dim strCols = ""

            If dicInfo.Count > 0 Then
                For Each kvp As KeyValuePair(Of String, Object) In dicInfo
                    strCols &= kvp.Key & "=" & If(kvp.Value.ToString = "NULL", kvp.Value.ToString, "'" & kvp.Value.ToString & "'") & " and "
                Next
                Dim strVerifica = String.Format(strSQL, baseDatos, tabla, strCols.Substring(0, strCols.Length - 5))
                strComprueba.Add(strVerifica)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "APIBonos_comprobarExistencia", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Guarda los bloques de registros en sqlite -- Ernesto -- 18 dic 2023
    ''' </summary>
    ''' <param name="strQuerys">Querys que se ejecutarán</param>
    ''' <remarks></remarks>
    Private Sub GuardaMovimientosTablaSQL(strQuerys As ArrayList)
        Try
            '-- Variables
            Dim lim = 500                                       'Cantidad de querys de un bloque
            Dim cont = 0                                        'Contador querys 
            Dim numBloq = 0                                     'Num. de bloque con querys
            Dim strQry As New System.Text.StringBuilder         'Almacena cadena de querys

            If lim > strQuerys.Count Then
                If strQuerys.Count = 1 Then
                    lim = strQuerys.Count
                Else
                    lim = (strQuerys.Count / 2)
                End If
            End If

            If Not hiloTrabajo Is Nothing Then : hiloTrabajo.ReportProgress(0) : End If

            For Each i In strQuerys
                strQry.Append(i)

                If cont = lim Then
                    numBloq += 1
                    sqlExecute("BEGIN TRANSACTION; " & strQry.ToString & "COMMIT;") : cont = 0 : strQry.Clear()
                    If Not hiloTrabajo Is Nothing Then : hiloTrabajo.ReportProgress(100 * numBloq / (strQuerys.Count / lim)) : End If
                End If

                cont += 1
            Next

            If cont > 0 And strQry.ToString.Length > 0 Then sqlExecute("BEGIN TRANSACTION; " & strQry.ToString & "COMMIT;")
            det.Add("- Se agregaron " & strQuerys.Count & " registros a miscelaneos.")
            If Not hiloTrabajo Is Nothing Then : hiloTrabajo.ReportProgress(100) : End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "APIBonos_guardarMovimientos", ex.HResult, ex.Message)
        End Try
    End Sub
End Class