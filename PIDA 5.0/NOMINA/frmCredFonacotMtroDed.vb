Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Reflection
Imports System.Threading


Public Class frmCredFonacotMtroDed '-- Ernesto -- agosto 2024

    Dim dtDataExcel As DataTable
    Dim dtPersonal As DataTable
    Dim nomTabla = ""
    Dim contInvalidos = 0
    Dim rfcNoEncontrado As New List(Of String)
    Dim rutaTxt = ""
    Dim comentario As New ArrayList
    Dim bajas As New ArrayList
    Dim rutaBajas = ""
    Dim numActivos = 0
    Dim montoActivos = 0.0
    Dim montoInactivos = 0.0
    Dim filtro = ""
    Dim dicExcel As New Dictionary(Of String, DataTable)
    Dim errBool = False
    Dim Bitmap As Bitmap
    Dim dicRutas As New Dictionary(Of String, String)
    Dim actualiza = False
    Dim strComent = ""
    Dim iniAno = ""
    Dim noMes = ""

    ''' <summary>
    ''' Función para reestablecer variables globales de manera default
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetVariables()
        Try
            dtDataExcel = New DataTable
            dtPersonal = New DataTable
            nomTabla = ""
            contInvalidos = 0
            rfcNoEncontrado.Clear()
            rutaTxt = ""
            comentario.Clear()
            bajas.Clear()
            rutaBajas = ""
            numActivos = 0
            montoActivos = 0.0
            montoInactivos = 0.0
            filtro = ""
            dicExcel.Clear()
            errBool = False
            Bitmap = Nothing
            dicRutas.Clear()
            actualiza = False
            strComent = ""
            iniAno = ""
            noMes = ""
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Se abre un dialogo para seleccionar los archivos csv y cargar su info. a un datagrid y un diccionario para manipular la data
    ''' </summary>
    ''' <param name="strCtrlNom"></param>
    ''' <remarks></remarks>
    Private Sub DialogoCarga(actualiza As Boolean)
        Try
            errBool = False
            lblIngresados.Text = "Reg. ingresados:"
            lblIngMonto.Text = "Monto:"

            '-- Recorrer cada archivo seleccionado
            If Not actualiza Then
                ofdRuta.Filter = "Archivos csv|*.csv"
                ofdRuta.Multiselect = True
                ofdRuta.Title = ""

                Dim lDialogResult As DialogResult = ofdRuta.ShowDialog()
                If lDialogResult = Windows.Forms.DialogResult.Cancel Then Exit Sub
                For Each filePath In ofdRuta.FileNames : AlmacenaInfo(filePath) : Next
            End If

            actualiza = False

        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Se guarda la info. de las rutas y los registros de los csv
    ''' </summary>
    ''' <param name="ruta"></param>
    ''' <remarks></remarks>
    Private Sub AlmacenaInfo(ruta As String)
        Try
            '-- Para que no se repitan llaves
            Thread.Sleep(50)

            Dim strArchivo = ruta.Split("\")(ruta.Split("\").Length - 1)
            Dim strId = Date.Now.TimeOfDay.ToString
            Dim dtCsv As New DataTable

            If System.IO.File.Exists(ruta) = False Then
                MessageBox.Show("El archivo '" & strArchivo & "' no existe. Favor de verificar.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            '-- Corroborar que el archivo no se agregue 2 veces
            If dicRutas.ContainsValue(ruta) Then
                MessageBox.Show(ruta & vbNewLine & vbNewLine & "Archivo ya se agregó previamente.", "Archivo existente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            dtCsv = LeerCsv(ruta, "btn1")

            If dtCsv.Rows.Count > 0 Then
                dicExcel.Add(strId, dtCsv)
                dicRutas.Add(strId, ruta)
                dgvArchivos.Rows.Add(strId, strArchivo, Bitmap)
                Application.DoEvents()
            End If

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Validaciones especiales para el nombre del empleado de la cédula, Ej. Dobles espacios o nombres con punto
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ValidarCadenaNombre(strNombre As String) As String
        Try
            Dim strComp = "", conPunto = False
            For Each s In strNombre.Split(" ")
                If {"MA.", "MA"}.Contains(s) Then conPunto = True
                If s <> "" Then strComp &= IIf({"MA.", "MA"}.Contains(s), "MA#", s) & " "
            Next
            If conPunto Then strComp = strComp.Replace("#", ".").Trim & "','" & strComp.Replace("#", "").Trim
            Return strComp.Trim
        Catch ex As Exception : End Try
    End Function

    ''' <summary>
    ''' Función para determinar el último periodo de acuerdo a un plazo dado
    ''' </summary>
    ''' <param name="tipoPeriodo">Semanal o quincenal</param>
    ''' <param name="periodoInicial">Periodo de inicio</param>
    ''' <param name="plazo">No. de periodos a considerar</param>
    ''' <param name="año">Año del periodo</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UltimoPeriodo(tipoPeriodo As String, periodoInicial As Integer, plazo As Integer, año As Integer) As String
        Try
            Dim periodoPlazo = periodoInicial + plazo - 1
            Dim periodoFueraRango = IIf(tipoPeriodo = "S", (52 - (periodoInicial + plazo - 1)) * -1, (24 - (periodoInicial + plazo - 1)) * -1).ToString
            Dim dentroPeriodo As Boolean = IIf(periodoPlazo <= IIf(tipoPeriodo = "S", 52, 24), True, False)
            If Not dentroPeriodo Then Return UltimoPeriodo(tipoPeriodo, 1, periodoFueraRango, año + 1)
            Dim ultimoPer = año & IIf(periodoPlazo.ToString.Length = 1, "0" & periodoPlazo.ToString, periodoPlazo.ToString)
            Return ultimoPer
        Catch ex As Exception : End Try
    End Function

    ''' <summary>
    ''' Función que se encarga de regresar un datatable de un archivo csv
    ''' </summary>
    ''' <param name="path">Ruta del csv</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function LeerCsv(path As String, Optional strCtrl As String = "") As DataTable
        Try
            Dim colValidas() = {"No_FONACOT", "RFC", "NOMBRE", "No_CREDITO", "RETENCION_MENSUAL", "CLAVE_EMPLEADO", "PLAZO", "CUOTAS_PAGADAS", "RETENCION_REAL"}
            Dim dtValores = ProcesoNomina.creaDt("No_FONACOT,RFC,NOMBRE,No_CREDITO,RETENCION_MENSUAL,CLAVE_EMPLEADO,PLAZO,CUOTAS_PAGADAS,RETENCION_REAL",
                                                 "String,String,String,String,Double,String,Double,Double,Double")

            dtValores.PrimaryKey = New DataColumn() {dtValores.Columns("No_FONACOT"), dtValores.Columns("RFC"),
                                                     dtValores.Columns("NOMBRE"), dtValores.Columns("No_CREDITO"),
                                                     dtValores.Columns("RETENCION_MENSUAL"), dtValores.Columns("CLAVE_EMPLEADO"),
                                                     dtValores.Columns("PLAZO"), dtValores.Columns("CUOTAS_PAGADAS"),
                                                     dtValores.Columns("RETENCION_REAL")}

            Dim lineaTxt As String = ""
            Dim strValores() As String
            Dim exiteVal As Boolean
            Dim cont As Integer = 0

            If System.IO.File.Exists(path) = True Then
                Using objReader As New System.IO.StreamReader(path, Encoding.Default)
                    Do While objReader.Peek() <> -1
                        lineaTxt = objReader.ReadLine()
                        strValores = Split(lineaTxt, ",")

                        '-- Validar columnas de excel
                        If cont = 0 Then
                            For Each validas As String In strValores
                                If cont > 8 Then Exit For
                                If colValidas.Contains(validas.Replace("""", "")) And cont <= 8 Then exiteVal = True Else exiteVal = False
                                If Not exiteVal Then MessageBox.Show("La información analizada del archivo no es válida.", "Error",
                                                     MessageBoxButtons.OK, MessageBoxIcon.Error) : errBool = True : GoTo ErrorArchivo
                                cont += 1
                            Next
                            cont = 0
                        Else
                            '-- Llenar valores de excel a datatable
                            Dim nrow = dtValores.NewRow
                            For i = 0 To 8 : nrow.Item(colValidas(i)) = strValores(i).Replace("""", "") : Next
                            dtValores.Rows.Add(nrow)
                        End If
                        Application.DoEvents()
                        cont += 1
                    Loop
                End Using
            Else
                MessageBox.Show("El archivo no existe en la ruta indicada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

ErrorArchivo:
            Return dtValores

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la lectura del archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ''' <summary>
    ''' Información de los datagridviews.
    ''' </summary>
    ''' <param name="dtInfo">Datatable con la información principal</param>
    ''' <remarks></remarks>
    Private Sub CargaDatagrids(dtInfo As DataTable)
        Try
            dgvSemanal.DataSource = dtInfo
            CargaInfoControles(If(dtInfo.Rows.Count > 0, 1, 0), "S")
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Cargar los controles de acuerdo a un estado inicial o no.
    ''' </summary>
    ''' <param name="estadoInicial">Estado al cargar o editar información</param>
    ''' <param name="tipoPer">Tipo de periodo (semanal o quincenal)</param>
    ''' <remarks></remarks>
    Private Sub CargaInfoControles(estadoInicial As Integer, tipoPer As String)
        Try
            Select Case estadoInicial
                Case 0
                    lblNoReg.Text = "No. registros: 0"
                    intAnioIni.Enabled = False
                    intAnioIni.ValueObject = ""
                    intPerIni.Enabled = False
                    intPerIni.ValueObject = "1"
                    intNumAbonos.Enabled = False
                    intNumAbonos.ValueObject = "1"
                    txtUltAnio.Text = ""
                    txtUltPer.Text = ""

                    btnAplica.Enabled = False
                Case Else
                    intPerIni.Enabled = True
                    intPerIni.MaxValue = IIf(tipoPer = "S", 52, 24)
                    intPerIni.Value = 0
                    intAnioIni.Enabled = True
                    intAnioIni.Value = Date.Now.Year
                    intNumAbonos.Enabled = True
                    intNumAbonos.Value = 0
            End Select
        Catch ex As Exception
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

            For Each i In strQuerys
                strQry.Append(i)

                If cont = lim Then
                    numBloq += 1
                    sqlExecute("BEGIN TRANSACTION; " & strQry.ToString & "COMMIT;") : cont = 0 : strQry.Clear()
                End If

                cont += 1
            Next

            If cont > 0 And strQry.ToString.Length > 0 Then sqlExecute("BEGIN TRANSACTION; " & strQry.ToString & "COMMIT;")

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "FONACOTCedula_cargaMasiva", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Se valida si los registros que se ingresarán ya existen en la BD.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GuardarRegistros()
        Try
            Dim dtMtroDedCreditos = sqlExecute("select * from nomina.dbo.mtro_ded where concepto='FNAALC' and substring(credito,1,7)='" & iniAno & "-" & noMes & "'")
            Dim creditosBD = (From i In dtMtroDedCreditos.Rows Select i("credito").ToString.Trim).ToList
            Dim creditosCedula = (From i In dtDataExcel.Rows Select (i("ini_ano").ToString.Trim & "-" & noMes & "-" & i("no_credito").ToString.PadLeft(5, "0"))).ToList

            Dim lstNoAgregar As New ArrayList
            Dim lstIdBD As New ArrayList
            Dim reemplazar As Boolean = False
            Dim lstQryAgrega As New ArrayList
            Dim lstQryNoAgrega As New ArrayList
            Dim montosAgregados = 0.0
            Dim montosNoAgregados = 0.0

            '-- Agrega a un arreglo si existen los registros en BD
            If dtMtroDedCreditos.Rows.Count > 0 Then
                For Each cred In creditosCedula
                    If creditosBD.Contains(cred) Then
                        lstNoAgregar.Add(cred)
                        Dim strId = dtMtroDedCreditos.Select("credito='" & cred & "'").First.Item("id")
                        lstIdBD.Add(strId)
                    End If
                Next
            End If

            '-- Prepara los querys
            For Each x In dtDataExcel.Rows
                Dim strLlave = x("ini_ano").ToString.Trim & "-" & noMes & "-" & x("no_credito").ToString.PadLeft(5, "0")

                If Not lstNoAgregar.Contains(strLlave) Then
                    lstQryAgrega.Add(x("query").ToString.Replace("[mes]", CInt(MesNumero(cmbMeses.SelectedItem.ToString))))
                    montosAgregados += x("ini_saldo")
                Else
                    lstQryNoAgrega.Add(x("query").ToString.Replace("[mes]", CInt(MesNumero(cmbMeses.SelectedItem.ToString))))
                    montosNoAgregados += x("ini_saldo")
                End If
            Next

            '-- Reemplazar registros existentes si lo desea el usuario
            If lstQryNoAgrega.Count > 0 Then
                If MessageBox.Show("Existen registros con el mismo número de crédito en maestro de deducciones, " &
                                   "¿Desea reemplazar los existentes en maestro de deducciones con los nuevos de esta cédula?",
                                   "Reemplazar", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then

                    '-- Eliminar existentes en mtro ded
                    Dim strCond = String.Join(",", (From i In lstIdBD Select i))
                    sqlExecute("delete from nomina.dbo.mtro_ded where id in (" & strCond & ")")
                    reemplazar = True
                Else
                    montosNoAgregados = 0.0
                End If
            End If

            '-- Meter los registros a BD
            frmTrabajando.Show(Me)
            frmTrabajando.lblAvance.Font = New Font("", 8)
            ActivoTrabajando = True
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Guardando registros"
            Application.DoEvents()

            Dim reemplaza = reemplazar AndAlso lstQryNoAgrega.Count > 0
            Dim agrega = lstQryAgrega.Count > 0
            If reemplaza Then GuardaMovimientosTablaSQL(lstQryNoAgrega)
            If agrega Then GuardaMovimientosTablaSQL(lstQryAgrega)

            '-- Animación de trabajo
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()

            Dim totalRegistros = If(reemplazar, lstQryNoAgrega.Count + lstQryAgrega.Count, lstQryAgrega.Count)
            Dim decMonto = Math.Round(montosAgregados + montosNoAgregados, 2)
            Dim montosRegistros = "$" & (decMonto).ToString("#,##0.00")

            lblIngresados.Text = String.Format("Reg. ingresados: {0}", totalRegistros)
            lblIngMonto.Text = String.Format("Monto: {0}", montosRegistros)

            '-- Guardar txt con detalles
            rfcNoEncontrado.Sort()

            If rfcNoEncontrado.Count > 0 Then
                Dim strRFCs = ""
                For Each rfcNo As String In rfcNoEncontrado : lstErr.Items.Add(rfcNo.ToString.Replace("-", " - ")) : Next
                btnExportar.Enabled = True
            End If

            btnCargaCedula.Enabled = False

            If (reemplaza Or agrega) Then
                MessageBox.Show("Registros guardados.", "Registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No se guardaron cambios.", "Registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Función para validar la info. en el datatable principal (Que contiene toda la info.), evaluando si hay celdas vacias o valores idénticos al momento de aplicar cambios.
    ''' </summary>
    ''' <param name="dtInfo">Datatable a trabajar (con filtro para semanal o quincenal)</param>
    ''' <param name="strOp">Si se va editar o validar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function validaDt(dtInfo As DataTable, strOp As String) As Boolean
        Try
            Select Case strOp
                Case "Edicion"
                    For Each row As DataRow In dtInfo.Rows
                        Dim celdasVacias = row.Item("ini_per").ToString.Trim = "" Or row.Item("periodos").ToString.Trim = 0 Or
                            row.Item("ultimo_per").ToString.Trim = "" Or row.Item("ultimo_ano").ToString.Trim = ""
                        Dim valorSimilar = row.Item("ini_per") = CStr(IIf(intPerIni.ValueObject < 10, "0" & intPerIni.ValueObject, intPerIni.ValueObject)) And row.Item("ini_ano") = CStr(intAnioIni.ValueObject) And row.Item("periodos") = CStr(intNumAbonos.ValueObject) And
                                                          row.Item("ultimo_per") = txtUltPer.Text And row.Item("ultimo_ano") = txtUltAnio.Text
                        Dim editarCelda = IIf(celdasVacias = False And valorSimilar = False, True, False)
                        If celdasVacias Then Return False
                        If valorSimilar Then Return True
                        If editarCelda Then Return False
                    Next
                Case "Validacion"
                    contInvalidos = 0
                    For Each row As DataRow In dtInfo.Rows
                        If row.Item("ini_per").ToString = "" Or row.Item("ini_ano") = "" Or row.Item("periodos") = 0 Or
                            row.Item("ultimo_per").ToString = "" Or row.Item("ultimo_ano").ToString = "" Or row.Item("query").ToString = "" Or row.Item("abono") = 0 Then
                            contInvalidos += 1
                        End If
                    Next
                    Return IIf(contInvalidos = 0, True, False)
            End Select
        Catch ex As Exception
            Return True
        End Try
    End Function

    ''' <summary>
    ''' Carga la información correspondiente a cada datagridview.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NoRegistros()
        lblNoReg.Text = "No. registros: " & dgvSemanal.RowCount
    End Sub

    ''' <summary>
    ''' Carga la información inicial de la forma
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Inicializa()
        Try
            Me.Controls.Clear()
            InitializeComponent()

            '-- Tablas de consulta
            dtDataExcel = ProcesoNomina.creaDt("origen,reloj,no_credito,abono,ini_saldo,ini_per,ini_ano,periodos,sald_act,ultimo_per,ultimo_ano,query",
                                                "String,String,String,Double,Double,String,String,Integer,Double,String,String,String")

            dtPersonal = sqlExecute("select reloj,(rtrim(apaterno)+' '+rtrim(amaterno)+' '+rtrim(nombre)) as nombres,rfc,alta,baja,cod_tipo from " &
                                     "personal.dbo.personalvw")

            Bitmap = New Bitmap(PIDA.My.Resources.Resources.remove_, 15, 15)
        Catch ex As Exception

        End Try
    End Sub

#Region "Eventos"

    ''' <summary>
    ''' Función para cargar la información del excel a un datatable 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargarArchivo(sender As Object, e As EventArgs) Handles btnCargaArchivo.Click
        Try
            '-- Se cargan los archivos de credito
            DialogoCarga(actualiza)

            Dim archivoBajas As String = ""

            dtDataExcel.Clear()
            rfcNoEncontrado.Clear()
            lstErr.Items.Clear()

            '-- Animación carga
            frmTrabajando.Show(Me)
            frmTrabajando.lblAvance.Font = New Font("", 8)
            ActivoTrabajando = True
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Analizando archivo(s)"

            Dim dtExcel As New DataTable

            For Each x As KeyValuePair(Of String, DataTable) In dicExcel
                If Not x.Value Is Nothing AndAlso x.Value.Rows.Count > 0 Then
                    dtExcel = x.Value.Clone
                    dtExcel.Columns.Add("ORIGEN", GetType(System.String))
                    Exit For
                End If
            Next

            If Not dtExcel Is Nothing Then
                For Each x As KeyValuePair(Of String, DataTable) In dicExcel
                    If Not x.Value Is Nothing AndAlso x.Value.Rows.Count > 0 Then
                        For Each i In x.Value.Rows
                            Dim row = dtExcel.Rows.Find({i("No_FONACOT"), i("RFC"), i("NOMBRE"), i("No_CREDITO"), i("RETENCION_MENSUAL"),
                                                         i("CLAVE_EMPLEADO"), i("PLAZO"), i("CUOTAS_PAGADAS"), i("RETENCION_REAL")})                                                                             '-- Agregado
                            If IsNothing(row) Then
                                Dim newR = dtExcel.NewRow
                                newR("No_FONACOT") = i("No_FONACOT")
                                newR("RFC") = i("RFC")
                                newR("NOMBRE") = i("NOMBRE")
                                newR("No_CREDITO") = i("No_CREDITO")
                                newR("RETENCION_MENSUAL") = i("RETENCION_MENSUAL")
                                newR("CLAVE_EMPLEADO") = i("CLAVE_EMPLEADO")
                                newR("PLAZO") = i("PLAZO")
                                newR("CUOTAS_PAGADAS") = i("CUOTAS_PAGADAS")
                                newR("RETENCION_REAL") = i("RETENCION_REAL")
                                newR("ORIGEN") = dicRutas.Item(x.Key).Split("\")(dicRutas.Item(x.Key).Split("\").Length - 1)
                                dtExcel.Rows.Add(newR)
                            End If
                        Next
                    End If
                Next
            Else
                MessageBox.Show("No información para cargar") : Exit Sub
            End If

            '-- Si no hay info. salir
            If dtExcel.Rows.Count = 0 Then GoTo SinInfoExcel
            Dim dtRfc = New DataView(dtExcel, "", "rfc", DataViewRowState.CurrentRows).ToTable("", False, "rfc", "nombre", "no_credito", "origen")
            Dim strQry = ""
            Dim registroCorrecto = False
            Dim noValid = {DBNull.Value, Nothing}
            Dim existeRfcCred As New ArrayList

            For Each rowrfc As DataRow In dtRfc.Rows

                Dim rfc = rowrfc.Item("rfc").ToString.Trim
                Dim nombre = rowrfc.Item("nombre").ToString.Trim
                Dim no_credito = rowrfc.Item("no_credito").ToString.Trim
                Dim origen = rowrfc.Item("origen").ToString.Trim
                Dim llave = rfc & no_credito
                Dim nombreCorregido = ""

                '-- Si ya existe rfc-no_credito
                If existeRfcCred.Count > 0 Then
                    If existeRfcCred.Contains(llave) Then Continue For
                End If

                '-- Se agrega rfc-no_credito que ya existe para no volver agregarlo
                existeRfcCred.Add(llave)

                '-- Dobles espacios o nombres con punto
                nombreCorregido = ValidarCadenaNombre(nombre)

                '-- Valida RFC y nombres
                Dim info = dtPersonal.Select("rfc='" & rfc & "' and baja is null", "reloj asc") '-- RFC y activo
                If Not info.Count > 0 Then info = dtPersonal.Select("rfc='" & rfc & "' and baja is not null", "reloj asc") '-- RFC e inactivo
                If Not info.Count > 0 Then info = dtPersonal.Select("nombres in ('" & nombreCorregido & "') and baja is null", "reloj asc") '-- Nombres y activo
                If Not info.Count > 0 Then info = dtPersonal.Select("nombres in ('" & nombreCorregido & "') and baja is not null", "reloj asc") '-- Nombres e inactivo
                If Not info.Count > 0 Then rfcNoEncontrado.Add(rfc & "-" & nombreCorregido) : Continue For

                Dim reloj = info.First().Item("reloj").ToString.Trim
                Dim codTipo = info.First().Item("cod_tipo").ToString.Trim
                Dim ret_mensual = Math.Round(dtExcel.Compute("sum(retencion_real)", "no_credito='" & no_credito & "' and rfc='" & rfc & "'"), 2)
                Dim anio = Date.Now.Year
                Dim noPeriodos = 0
                Dim abono = 0
                Dim peractual = ""
                Dim tipoPer = "S"

                '-- Tabla de información donde se definirán los periodos inicial y los plazos
                dtDataExcel.Rows.Add(origen, reloj, no_credito, abono, ret_mensual, peractual, anio, noPeriodos, ret_mensual, "", "", "")
                Application.DoEvents()
            Next

SinInfoExcel:
            CargaDatagrids(dtDataExcel)
            NoRegistros()
            btnAplica.Enabled = dtExcel.Rows.Count > 0
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            actualiza = False

        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Carga la cedula a maestro de deducciones
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCargaCedula_Click(sender As Object, e As EventArgs) Handles btnCargaCedula.Click
        GuardarRegistros()
    End Sub

    ''' <summary>
    ''' Cerrar la forma
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Se carga el archivo de fonacot (formato csv) para su vista previa y edición.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCargar_Click(sender As Object, e As EventArgs)
        Try : CargarArchivo(sender, e) : Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Se aplican las ediciones de periodos, abonos y año a los registros (semanales y quincenales).
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAplica_Click(sender As Object, e As EventArgs) Handles btnAplica.Click
        Try
            Dim strQry = "" : Dim pruebas = ""
            iniAno = intAnioIni.Value.ToString
            noMes = CInt(MesNumero(cmbMeses.SelectedItem.ToString)).ToString.PadLeft(2, "0")

            '-- Validar controles
            If (intPerIni.ValueObject Is Nothing Or intAnioIni.ValueObject Is Nothing Or intNumAbonos.ValueObject Is Nothing) Or
                (intPerIni.ValueObject = 0 Or intNumAbonos.ValueObject = 0) Or (cmbMeses.SelectedItem Is Nothing) Then
                MessageBox.Show("Por favor, llene los campos con los datos correctos (mes aplicación o datos para créditos).",
                                "Información incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            '-- Si no hay cambios o el año es inválido
            Dim validoDgv = validaDt(dtDataExcel, "Edicion")
            Dim anioValido = (intAnioIni.ValueObject >= Date.Now.Year)
            Dim strPeriodoInicial = IIf(intPerIni.Value < 10, "0" & intPerIni.ValueObject, intPerIni.ValueObject)

            If Not validoDgv And anioValido Then
                If MessageBox.Show("¿Desea aplicar los siguientes cambios a los registros?" & vbNewLine & vbNewLine & _
                                    "Periodo inicial: " & intPerIni.ValueObject & vbNewLine & _
                                    "Año inicial: " & intAnioIni.ValueObject & vbNewLine & _
                                    "Número de abonos: " & intNumAbonos.ValueObject & vbNewLine & _
                                    "Último periodo: " & txtUltPer.Text & vbNewLine & _
                                    "Último año: " & txtUltAnio.Text,
                                    "Confirmación datos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                    For Each row As DataRow In dtDataExcel.Rows

                        Dim strCreditoConcepto = "FNAALC"
                        Dim strLlave = intAnioIni.Value & "-" & noMes & "-" & row("no_credito").ToString.PadLeft(5, "0")
                        Dim strReloj = row.Item("reloj").ToString.Trim
                        Dim dblSaldo = row.Item("ini_saldo") / intNumAbonos.ValueObject
                        Dim saldoCondicion = If(row.Item("ini_saldo") = (Math.Round(dblSaldo, 2) * intNumAbonos.ValueObject),
                                                dblSaldo,
                                                If(row.Item("ini_saldo") > (Math.Round(dblSaldo, 2) * intNumAbonos.ValueObject), Math.Round(dblSaldo, 2) + 0.01, Math.Round(dblSaldo, 2)))

                        Dim dblSaldoRedondeado = saldoCondicion
                        Dim strAnioPer = intAnioIni.ValueObject.ToString & IIf(intPerIni.ValueObject < 10, "0" & intPerIni.ValueObject, intPerIni.ValueObject)
                        strComent = "Carga cédula fonacot sem " & intPerIni.ValueObject.ToString.PadLeft(2, "0") & "-" & intAnioIni.ValueObject

                        For i As Integer = 0 To 1
                            If i = 0 Then
                                strQry = "insert into nomina.dbo.mtro_ded (reloj,concepto,abono,ini_saldo,ini_per,ini_ano,periodos,sald_act,activo,fijo,comentario,tipo_perio,alta,baja,mes_aplica,credito) values ('" & _
                                         strReloj & "'," & _
                                         "'" & strCreditoConcepto & "','" & _
                                         dblSaldoRedondeado & "','" & _
                                         row.Item("ini_saldo") & "','" & _
                                         strPeriodoInicial & "','" & _
                                         intAnioIni.ValueObject & "','" & _
                                         intNumAbonos.ValueObject & "','" & _
                                         row.Item("ini_saldo") & "'," & _
                                         "1," & _
                                         "0," & _
                                         "'" & strComent & "','" & _
                                         "S" & "'," & _
                                         "null," & _
                                         "null," & _
                                         "[mes],'" & strLlave & "');"
                            Else
                                '-- No exite tabla saldos_ca por el momento
                                strQry &= "insert into nomina.dbo.saldos_ca (reloj,periodo,ano,concepto,numcredito,abono_alc,saldo_act,comentario) values ('" & _
                                           strReloj & "'," & _
                                           "'00','" & _
                                           intAnioIni.ValueObject & _
                                           "','" & strCreditoConcepto & "','" & _
                                           strAnioPer & _
                                           "','0','" & _
                                           row.Item("ini_saldo") & _
                                           "','Inicio de crédito Sem " & intPerIni.ValueObject.ToString.PadLeft(2, "0") & "-" & intAnioIni.ValueObject & "');"
                            End If
                        Next

                        pruebas &= strQry

                        '-- Actualiza el dt
                        row.Item("abono") = dblSaldoRedondeado
                        row.Item("ini_per") = strPeriodoInicial
                        row.Item("ini_ano") = intAnioIni.ValueObject
                        row.Item("periodos") = intNumAbonos.ValueObject
                        row.Item("ultimo_per") = txtUltPer.Text
                        row.Item("ultimo_ano") = txtUltAnio.Text
                        row.Item("query") = strQry
                    Next

                    CargaDatagrids(dtDataExcel)

                    '-- Si los criterios son correctos para ambas categorias de registros entonces se habilita el botón de aceptar para actualizar tablas
                    If validaDt(dtDataExcel, "Validacion") Then btnCargaCedula.Enabled = True Else btnCargaCedula.Enabled = False
                End If
            Else
                If Not anioValido Then MessageBox.Show("Seleccione un año correcto.", "Año inválido", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If validoDgv Then MessageBox.Show("Datos idénticos a los originales.", "Valores idénticos", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Se exporta txt con información de la excepciones de la carga de la cedula
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            Dim sfd As New SaveFileDialog
            Dim filtro As String = "Arhivo texto (txt)|*.txt"
            sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop

            sfd.FileName = "CedulaExcepciones_" & CStr(Date.Now.ToShortDateString.Replace("/", "_")) & "_" &
                                                  CStr(Date.Now.ToShortTimeString.Replace(":", "_"))
            sfd.Filter = filtro

            If sfd.ShowDialog() = DialogResult.OK Then
                If System.IO.File.Exists(sfd.FileName) Then System.IO.File.Delete(sfd.FileName)
                Dim docTxt = New StreamWriter(sfd.FileName, True)
                Dim strLinea = "RFC o nombres no encontrados en personal" & vbNewLine & "RFC | Nombre completo" & vbNewLine
                For Each s In rfcNoEncontrado : strLinea &= s & vbNewLine : Next
                docTxt.WriteLine(strLinea) : docTxt.Close()

                If System.IO.File.Exists(sfd.FileName) Then
                    MessageBox.Show("Archivo de texto generado exitosamente.", "Archivo texto detalles", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    System.Diagnostics.Process.Start(sfd.FileName)
                Else
                    MessageBox.Show("Archivo de texto no se generó de manera exitosa.", "Archivo texto fallido", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Cuando se cierra la forma
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmCredFonacotMtroDed_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ResetVariables()
    End Sub

    ''' <summary>
    ''' Cuando se carga la forma
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmCredFonacotMtroDed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializa()
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Función para validar los controles de input (periodo, año y abonos).
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub InputsValidados(sender As Object, e As EventArgs) Handles intPerIni.ValueChanged, intNumAbonos.ValueChanged, intAnioIni.ValueChanged
        Try
            txtUltAnio.Text = UltimoPeriodo("S", intPerIni.ValueObject, intNumAbonos.ValueObject, intAnioIni.ValueObject).Substring(0, 4)
            txtUltPer.Text = UltimoPeriodo("S", intPerIni.ValueObject, intNumAbonos.ValueObject, intAnioIni.ValueObject).Substring(4, 2)
        Catch ex As Exception
            txtUltAnio.Text = ""
            txtUltPer.Text = ""
        End Try
    End Sub

    ''' <summary>
    ''' Eliminar registros del grid de archivos por parte del usuario
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvArchivos_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvArchivos.CellMouseUp
        Try
            If e.ColumnIndex = 2 Then
                Dim id = dgvArchivos.Rows(e.RowIndex).Cells("id").Value
                actualiza = True
                dicExcel.Remove(id)
                dicRutas.Remove(id)
                dgvArchivos.Rows.RemoveAt(e.RowIndex)
                btnCargaArchivo.PerformClick()
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

End Class