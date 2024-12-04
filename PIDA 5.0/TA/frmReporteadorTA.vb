
Imports Microsoft.Reporting.WinForms
Imports System.Xml
Public Class frmReporteadorTA
    Dim dtReportes As New DataTable
    Dim Acumulado As String
    Dim NombreReporte As String = ""
    Dim BuscaReporte As String = ""
    Dim UltimaActualizacion As Date
    Dim dtTemp As New DataTable
    Dim LocalRangoFInicial As Date
    Dim LocalRangoFFinal As Date

    Public Function FiltrosAcumulados() As String
        Dim FL As String = ""
        Dim i As Integer

        Try
            lstFiltros.Items.Clear()
            For i = 0 To NFiltros - 1
                FL = FL & IIf(i > 0, " AND (", "(") & Filtros(2, i) & ")"
                lstFiltros.Items.Add(Filtros(2, i))
            Next
            'If FL.Length > 0 Then
            '    FL = " WHERE " & FL
            'End If
        Catch ex As Exception
            FL = "ERROR"
        End Try

        Return FL & IIf(FL.Trim = "", FiltroXUsuario, " AND " & FiltroXUsuario)
    End Function

    Private Function OrdenAcumulado() As String

        Dim FL As String = ""
        Dim i As Integer
        Try
            For i = 0 To lstOrden.Items.Count - 1
                FL = FL & IIf(i > 0, ",", "") & lstOrden.Items(i)
            Next
            FL = FL.Replace("(", "")
            FL = FL.Replace(")", "")
            If FL = "" Then
                FL = "RELOJ ASC"
            End If

            'FL = " ORDER BY " & FL
        Catch ex As Exception
            FL = "ERROR"
        End Try

        Return FL

    End Function


    Private Sub frmReporteadorTA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        NFiltros = 0
        Me.Dispose()
    End Sub

    '== Funcion para eliminar registros de hrs_brt de registros que no corresponden a la compania de la instancia       24marzo22       Ernesto
    Private Sub DepurarTablas()
        Try
            'sqlExecuteInstancias("DELETE from TA.dbo.hrs_brt where reloj not in (select reloj from PERSONAL.dbo.personal where cod_comp='WME')", "", 1)
            'sqlExecuteInstancias("DELETE from TA.dbo.hrs_brt where reloj not in (select reloj from PERSONAL.dbo.personal where cod_comp='WSM')", "", 2)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmReporteadorTA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtPersonalFaltante As New DataTable
        Try
            'MCR 4/NOV/2015
            'Tomar fecha/hora de última actualización de datos
            UltimaActualizacion = Now
            'Guardar valores de rango de fechas para usar en bitácora
            'Ya que son variables globales que se utilizan en otras formas
            LocalRangoFInicial = RangoFInicial
            LocalRangoFFinal = RangoFFinal
            '***************************************************
            'AOS: 2021-06-02: Guardar valores de rango de fechas para usar en hrs_brt_cafeteria
            'Ya que son variables globales que se utilizan en otras formas
            CafFechaIni = RangoFInicial
            CafFechaFin = RangoFFinal

            lblFechas.Text = FechaCortaLetra(RangoFInicial) & " A " & FechaCortaLetra(RangoFFinal)

            Dim _campos_tavw As String = "*"
            Dim dtquery As datatable = sqlexecute("select * from kiosco.dbo.variables where variable = 'QUERY_TA'")
            If dtquery.rows.count > 0 Then
                _campos_tavw = dtquery.rows(0)("valor")
            End If

            '== Depuración de tablas            24marzo2022     Ernesto
            Try : DepurarTablas() : Catch ex As Exception : End Try

            dtResultadoTA = sqlExecute("SELECT " & _campos_tavw & " FROM TAVW WHERE FHA_ENT_HOR between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & _
                                       "'", "ta")

            '== SE ALMACENA LA INFORMACION DE LA SEGUNDA EMPRESA EN CASO DE QUE SE VAYA A UTILIZAR EN ALGUN REPORTE  (SOLO WOLLSDORF)                12ene2022               Ernesto
            'Try
            '    dtInfoPlanta2 = sqlExecute("SELECT " & _campos_tavw & " FROM TAVW WHERE FHA_ENT_HOR between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & _
            '               "'", "ta", 1)
            'Catch ex As Exception
            '    MessageBox.Show("Error al cargar informacion de la instancia WSM", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End Try
            '==

            dtPersonalFaltante = sqlExecute("SELECT RELOJ,COD_COMP,ALTA,AMATERNO,APATERNO,NOMBRE,NOMBRES,AVISO_ACC,BAJA,BANCO," & _
                                            "CHECA_TARJETA,COD_CD,COD_CIVIL,COD_CLASE AS 'COD_CLASE_PERSONAL',COD_COL,COD_COMP AS 'COD_COMP_PERSONAL'," & _
                                            "COD_DEPTO AS 'COD_DEPTO_PERSONAL',COD_EDO,COD_HORA,COD_LINEA,COD_MOT_BA,COD_MOT_IM,COD_PLANTA," & _
                                            "COD_PUESTO AS 'COD_PUESTO_PERSONAL',COD_SUPER AS 'COD_SUPER_PERSONAL',COD_TIPO AS 'COD_TIPO_PERSONAL'," & _
                                            "COD_TURNO AS 'COD_TURNO_PERSONAL',COMENTARIO AS 'COMENTARIO_PERSONAL',CREDITO_IN,CUENTA_BANCO,CURP," & _
                                            "DIAS_AGUINALDO,DIAS_VACACIONES,DIG_VER,DIG_VER_IN,DIRECCION,FACTOR_INT,FAH_PARTIC,FAH_PORCEN,FECHA_CRE," & _
                                            "FHA_NAC,FHA_ULT_EV,FHA_ULT_MO,GAFETE AS 'GAFETE_PERSONAL',IMSS,INFONAVIT,INTEGRADO,LOCKER," & _
                                            "LUGARN,NIVEL,NOMBRE,NOMBRE_DEPTO AS 'NOMBRE_DEPTO_PERSONAL',NOMBRE_HORARIO AS 'NOMBRE_HORARIO_PERSONAL'," & _
                                            "NOMBRE_PUESTO AS 'NOMBRE_PUESTO_PERSONAL',NOMBRE_SUPER AS 'NOMBRE_SUPER_PERSONAL',NOMBRE_PLANTA," & _
                                            "NOMBRE_LINEA,PAGO_INF,PAGO_SEGVI,PRO_VAR,RECONTRATA,RFC,SACTUAL,SAL_ANT,SEXO,TELEFONO,TIPO_CRE," & _
                                            "TIPO_PAGO,HORAS AS HORAS_TURNO,UMF,EDAD,ESCOLARIDAD,ANTIGUEDAD,FOTO,NOMBRE_COLONIA,NOMBRE_TIPOEMP," & _
                                            "NOMBRE_TURNO,NOMBRE_CLASE,LUGAR_NAC,MOTIVO_BAJA,MOTIVO_BAJA_IM " & _
                                            "FROM PERSONALVW WHERE RELOJ not in " & _
                                            "(SELECT RELOJ FROM ta.dbo.TAVW WHERE FHA_ENT_HOR between '" & FechaSQL(RangoFInicial) & "' and '" & _
                                            FechaSQL(RangoFFinal) & "') AND (BAJA IS NULL OR baja>' " & FechaSQL(RangoFInicial) & "')" & _
                                            " AND alta <= '" & FechaSQL(RangoFFinal) & "'")

            For Each dEmp As DataRow In dtPersonalFaltante.Rows
                dtResultadoTA.ImportRow(dEmp)
            Next

            chkRecientes.Text = "Ver últimos 10 reportes utilizados por el usuario " & Usuario.ToUpper
            chkRecientes.Checked = False
            txtActivos.Value = RangoFFinal
            txtBajas.Value = RangoFFinal

            Acumulado = FiltrosAcumulados()

            'MCR 5/NOV/2015
            'No considerar los tipos de reporte de Time Allocation (S = TAlloc creados por usuario, T = Generales de TAlloc)
            cmbTipoReportes.DataSource = sqlExecute("SELECT * FROM tipo_reportes WHERE tipo NOT IN ('S','T') ORDER BY tipo", "TA")
            cmbTipoReportes.SelectedValue = "X"

            '==Filtro de perfiles       29julio2021 Ernesto
            revisarPerfiles(Perfil, Me, False, "CIA")

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub



    Private Sub chkBajas_CheckedChanged(sender As Object, e As EventArgs) Handles chkBajas.CheckedChanged
        Try
            Dim I As Integer = -1
            If chkBajas.Checked Then
                chkActivos.Checked = False
                chkTodos.Checked = False
                txtBajas.Focus()

            Else
                'Actualiza lista de filtros
                Dim x As Integer

                For x = 0 To NFiltros - 1
                    If Filtros(1, x) = "BAJAS" Then
                        I = x
                        Exit For
                    End If
                Next

                If I < 0 Then Exit Sub
                lstFiltros.Items.RemoveAt(I)

                For x = I To NFiltros - 1
                    Filtros(1, x) = Filtros(1, x + 1)
                    Filtros(2, x) = Filtros(2, x + 1)
                Next
                NFiltros = NFiltros - 1
                ReDim Preserve Filtros(2, x)
            End If
            chkTodos.Checked = Not (chkActivos.Checked Or chkBajas.Checked Or chkOtrosFiltros.Checked)
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkActivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivos.CheckedChanged
        Try
            'Dim Filtro As String
            Dim I As Integer = -1
            If chkActivos.Checked Then
                chkBajas.Checked = False
                chkTodos.Checked = False
                txtActivos.Focus()
            Else
                'Actualiza lista de filtros
                Dim x As Integer

                For x = 0 To NFiltros - 1
                    If Filtros(1, x) = "ACTIVOS" Then
                        I = x
                        Exit For
                    End If
                Next

                If I < 0 Then Exit Sub
                lstFiltros.Items.RemoveAt(I)

                For x = I To NFiltros - 1
                    Filtros(1, x) = Filtros(1, x + 1)
                    Filtros(2, x) = Filtros(2, x + 1)
                Next
                NFiltros = NFiltros - 1
                ReDim Preserve Filtros(2, x)
            End If
            chkTodos.Checked = Not (chkActivos.Checked Or chkBajas.Checked Or chkOtrosFiltros.Checked)
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtBajas_Click(sender As Object, e As EventArgs) Handles txtBajas.Click

    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        Try
            If chkTodos.Checked Then
                chkActivos.Checked = False
                chkBajas.Checked = False
                chkOtrosFiltros.Checked = False
                lstFiltros.Items.Clear()
                NFiltros = 0
            End If

            If Not (chkActivos.Checked Or chkBajas.Checked Or chkOtrosFiltros.Checked) Then
                chkTodos.Checked = True
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkRecientes_CheckedChanged(sender As Object, e As EventArgs) Handles chkRecientes.CheckedChanged
        CargarReportes()

    End Sub

    Private Sub dgReportes_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub CargarReportes()
        Dim FiltrarTipo As Boolean
        Dim Cadena As String
        Dim D As Integer
        Dim O As Windows.Forms.SortOrder
        Try
            FiltrarTipo = cmbTipoReportes.SelectedValue <> "X"
            dtReportes = New DataTable
            If dgReportes.SortedColumn Is Nothing Then
                D = 0
                O = SortOrder.Ascending
            Else
                D = dgReportes.SortedColumn.Index
                O = dgReportes.SortOrder
            End If

            'MCR 3/NOV/2015
            'Eliminar TAA como identificador para Time & Attendance; utilizar solamente TA
            If chkRecientes.Checked Then
                Cadena = "SELECT RTRIM(reportes.NOMBRE) AS NOMBRE,reportes.TIPO," & _
                    "(100*VECES_ACCESO)/((SELECT MAX(veces_acceso) FROM reportes)+1) AS 'Frecuencia'," & _
                    "reportes_recientes.FECHA,FILTRAR,username FROM REPORTES RIGHT JOIN reportes_recientes ON " & _
                    "reportes.nombre = reportes_recientes.nombre WHERE reportes_recientes.usuario = '" & _
                    Usuario & "' AND reportes.NOMBRE IN " & _
                    "(SELECT CONTROL FROM SEGURIDAD.dbo.PERMISOS WHERE " & IIf(FiltrarTipo, " reportes.tipo='" & cmbTipoReportes.SelectedValue & "' AND ", "") & _
                    " cod_perfil " & Perfil & " AND permisos.modulo = 'TA'  and permisos.acceso = 1)" & _
                   IIf(BuscaReporte.Length = 0, "", " AND dbo.EliminaAcentos(reportes.nombre) LIKE '%" & BuscaReporte & "%' ") & _
                    "ORDER BY reportes_recientes.fecha DESC,nombre"
            Else
                Cadena = "SELECT RTRIM(reportes.NOMBRE) AS NOMBRE,reportes.TIPO," & _
                    "(100*VECES_ACCESO)/((SELECT MAX(veces_acceso) FROM reportes)+1) AS Frecuencia,reportes.FECHA,FILTRAR,username " & _
                    "FROM REPORTES WHERE reportes.INDIVIDUAL is null and reportes.NOMBRE IN " & _
                    "(SELECT CONTROL FROM SEGURIDAD.dbo.PERMISOS WHERE " & IIf(FiltrarTipo, " reportes.tipo='" & cmbTipoReportes.SelectedValue & "' AND ", "") & _
                    IIf(FiltrarTipo, " reportes.tipo='" & cmbTipoReportes.SelectedValue & "' AND ", " NOT reportes.tipo IN ('S','T') AND ") & _
                    " cod_perfil " & Perfil & " AND permisos.modulo = 'TA' and permisos.acceso = 1)" & _
                    IIf(BuscaReporte.Length = 0, "", " AND dbo.EliminaAcentos(reportes.nombre) LIKE '%" & BuscaReporte & "%' ") & _
                    " ORDER BY reportes.nombre"
            End If
            dtReportes = New DataTable
            dtReportes = sqlExecute(Cadena, "ta")
            dgReportes.DataSource = dtReportes
            'dgReportes.Columns("username").Visible = False
            'dgReportes.Sort(dgReportes.Columns.Item(D), O)
            If dgReportes.Rows.Count > 0 Then
                'dgReportes.Rows.Item(1).Visible = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub



    Private Sub chkReloj_CheckedChanged(sender As Object, e As EventArgs) Handles chkReloj.CheckedChanged
        Try
            Dim I As Integer = -1
            Dim TipoOrden As String = IIf(sbReloj.Value, "ASC", "DESC")
            Dim x As Integer = 0

            If chkReloj.Checked Then
                'Actualiza lista de Orden
                If NOrden < 0 Then NOrden = 0
                For x = 0 To NOrden - 1
                    If Orden(1, x) = "RELOJ" Then
                        I = x
                        Exit For
                    End If
                Next

                If I = -1 Then
                    I = NOrden
                    NOrden = NOrden + 1

                    If UBound(Orden, 2) < NOrden Then
                        ReDim Preserve Orden(2, NOrden)
                    End If
                End If

                Orden(1, I) = "RELOJ"
                Orden(2, I) = TipoOrden

                lstOrden.Items.Clear()
                For x = 0 To NOrden - 1
                    lstOrden.Items.Add(Orden(1, x) & " (" & Orden(2, x) & ")")
                Next
                chkNombre.Checked = False
                sbReloj.Focus()
            Else
                'Actualiza lista de orden


                For x = 0 To NOrden - 1
                    If Orden(1, x) = "RELOJ" Then
                        I = x
                        Exit For
                    End If
                Next

                If I < 0 Then Exit Sub
                lstOrden.Items.RemoveAt(I)

                For x = I To NOrden - 1
                    Orden(1, x) = Orden(1, x + 1)
                    Orden(2, x) = Orden(2, x + 1)
                Next
                NOrden = NOrden - 1
                ReDim Preserve Orden(2, x)
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkNombre_CheckedChanged(sender As Object, e As EventArgs) Handles chkNombre.CheckedChanged
        Try
            Dim I As Integer = -1
            Dim TipoOrden As String = IIf(sbNombre.Value, "ASC", "DESC")
            Dim x As Integer = 0

            If chkNombre.Checked Then
                'Actualiza lista de Orden
                If NOrden < 0 Then NOrden = 0
                For x = 0 To NOrden - 1
                    If Orden(1, x) = "NOMBRES" Then
                        I = x
                        Exit For
                    End If
                Next

                If I = -1 Then
                    I = NOrden
                    NOrden = NOrden + 1

                    If UBound(Orden, 2) < NOrden Then
                        ReDim Preserve Orden(2, NOrden)
                    End If
                End If

                Orden(1, I) = "NOMBRES"
                Orden(2, I) = TipoOrden

                lstOrden.Items.Clear()
                For x = 0 To NOrden - 1
                    lstOrden.Items.Add(Orden(1, x) & " (" & Orden(2, x) & ")")
                Next

                chkReloj.Checked = False
                sbReloj.Focus()
            Else
                'Actualiza lista de orden


                For x = 0 To NOrden - 1
                    If Orden(1, x) = "NOMBRES" Then
                        I = x
                        Exit For
                    End If
                Next

                If I < 0 Then Exit Sub
                lstOrden.Items.RemoveAt(I)

                For x = I To NOrden - 1
                    Orden(1, x) = Orden(1, x + 1)
                    Orden(2, x) = Orden(2, x + 1)
                Next
                NOrden = NOrden - 1
                ReDim Preserve Orden(2, x)
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkReportesUsuario_CheckedChanged(sender As Object, e As EventArgs)
        CargarReportes()
    End Sub

    Private Sub chkOtrosFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtrosFiltros.CheckedChanged
        chkTodos.Checked = Not (chkActivos.Checked Or chkBajas.Checked Or chkOtrosFiltros.Checked)
    End Sub

    Private Sub btnSeleccionarFiltros_Click(sender As Object, e As EventArgs) Handles btnSeleccionarFiltros.Click
        Try
            Dim Filtro As String
            frmFiltroTA.ShowDialog()
            Acumulado = FiltrosAcumulados()

            chkOtrosFiltros.Checked = NFiltros > 0

            Filtro = ""
            lstFiltros.Items.Clear()
            For x = 0 To NFiltros - 1
                lstFiltros.Items.Add(Filtros(2, x))
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtActivos_Click(sender As Object, e As EventArgs) Handles txtActivos.Click

    End Sub

    Private Sub txtActivos_Validated(sender As Object, e As EventArgs) Handles txtActivos.Validated
        Try
            Dim Filtro As String
            Dim I As Integer = -1
            If chkActivos.Checked Then
                'chkBajas.Checked = False
                'txtActivos.Focus()
                Filtro = " ALTA <= '" & FechaSQL(txtActivos.Value) & "' AND (BAJA IS NULL OR BAJA > '" & FechaSQL(txtActivos.Value) & "')"


                'Actualiza lista de filtros

                For x = 0 To NFiltros - 1
                    If Filtros(1, x) = "ACTIVOS" Then
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

                Filtros(1, I) = "ACTIVOS"
                Filtros(2, I) = Filtro

                Filtro = ""
                lstFiltros.Items.Clear()
                For x = 0 To NFiltros - 1
                    lstFiltros.Items.Add(Filtros(2, x))
                    'Filtro = Filtro & IIf(Filtro.Length = 0, "", " AND ") & Filtros(2, x)
                Next
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
     
        gpAvance.Visible = True
        pbAvance.IsRunning = True
        gpReportes.Enabled = False
        gpFiltros.Enabled = False
        gpOrden.Enabled = False
        gpControles.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        'bgwReporte.WorkerReportsProgress = True

        EncabezadoReporte = lblFechas.Text.Trim
        FiltroReporte = FiltrosTAAcumulados()
        OrdenReporte = OrdenAcumulado()

        'MCR 4/NOV/2015
        'Revisar bitácora por cambios desde última actualización de datos
        ConsultaBitacora(dtResultadoTA, UltimaActualizacion)

        '==Revisa bitacora para la segunda empresa          12ene22           Ernesto
        Try : ConsultaBitacora(dtInfoPlanta2, UltimaActualizacion, 1) : Catch ex As Exception : End Try

        My.Application.DoEvents()
        'bgwReporte.RunWorkerAsync()

        bgwReporte_DoWork()
        bgwReporte_RunWorkerCompleted()

        If (NombreReporte = "Tiempo Extra (Doble y Triple)") Then
            acciones(NombreReporte.Trim())
        End If

    End Sub

    Private Function FiltrosTAAcumulados() As String
        Dim FL As String = ""
        Dim i As Integer
        Try
            lstFiltros.Items.Clear()
            For i = i To NFiltros - 1
                FL = FL & IIf(i > 0, " AND (", "(") & Filtros(2, i) & ")"
                lstFiltros.Items.Add(Filtros(2, i))
            Next
            'If FL.Length > 0 Then
            '    FL = " WHERE " & FL
            'End If
        Catch ex As Exception
            FL = "ERROR"
        End Try

        Return FL & IIf(FL.Trim = "", FiltroXUsuario, IIf(FiltroXUsuario.Trim <> "", " AND " & FiltroXUsuario, ""))
    End Function

    Private Sub Mientras()
        Dim dtReporte As New DataTable
        Dim r As Integer
        Dim i As Integer
        Dim Tipo As String
        Try
            r = dgReportes.CurrentCell.RowIndex
            If r < 0 Then Exit Sub
            NombreReporte = dgReportes.Item("nombre", r).Value
            Tipo = dgReportes.Item("tipo", r).Value

            dtTemporal = sqlExecute("UPDATE reportes SET veces_acceso = veces_acceso + 1, fecha = GETDATE()   WHERE nombre = '" & NombreReporte.Trim & "'", "TA")

            dtTemporal = sqlExecute("SELECT COUNT(nombre) AS cuantos FROM reportes_recientes WHERE usuario = '" & Usuario & "'", "TA")
            If dtTemporal.Rows.Item(0).Item("cuantos") = 10 Then
                dtTemporal = sqlExecute("DELETE FROM reportes_recientes WHERE fecha = (SELECT MIN(fecha) FROM reportes_recientes WHERE usuario = '" & Usuario & "') AND usuario = '" & Usuario & "'", "TA")
            End If

            dtTemporal = sqlExecute("SELECT nombre FROM reportes_recientes WHERE usuario = '" & Usuario & "' AND nombre = '" & NombreReporte.Trim & "'", "TA")
            If dtTemporal.Rows.Count > 0 Then
                dtTemporal = sqlExecute("UPDATE reportes_recientes SET fecha = GETDATE() WHERE usuario = '" & Usuario & "' AND nombre = '" & NombreReporte.Trim & "'", "TA")
            Else
                dtTemporal = sqlExecute("INSERT INTO reportes_recientes (usuario,fecha,nombre) VALUES ('" & Usuario & "',GETDATE(), '" & NombreReporte & "')", "TA")
            End If

            FiltroReporte = FiltrosAcumulados()
            OrdenReporte = OrdenAcumulado()

            Dim dtResultadoTAFiltro As New DataSet
            dtResultadoTAFiltro.Merge(dtResultadoTA.Select(FiltroReporte))

            If dtResultadoTAFiltro.Tables.Count = 0 Then
                dtFiltroTA = New DataTable
            Else
                dtFiltroTA = dtResultadoTAFiltro.Tables(0)
                dtResultadoTAFiltro.Tables(0).TableName = "TA"
                dtFiltroTA.DefaultView.Sort = OrdenReporte
            End If


            


            If Tipo = "U" Then
                dtDisponibles = sqlExecute("SELECT UPPER(cod_campo) AS campo,upper(left(nombre,1)) + lower(substring(nombre,2,75)) AS nombre,tipo FROM campos ORDER BY nombre", "TA")
                'MCR 3/NOV/2015
                'Estandarizar y dejar de utilizar TAA, solamente TA como identificador de Time&Attendance
                ReporteadorFuente = "TA"
                dtReporte = sqlExecute("SELECT * FROM reportes WHERE nombre = '" & NombreReporte.Trim & "'", "TA")
                If dtReporte.Rows.Count < 1 Then Exit Sub
                frmVistaPrevia.ReporteDinamico(dtReporte.Rows(0), dtFiltroTA, NombreReporte)
            Else

                frmVistaPrevia.LlamarReporte(NombreReporte, dtFiltroTA)
                frmVistaPrevia.ShowDialog()
            End If

            CargarReportes()
            For i = 0 To dgReportes.Rows.Count - 1
                If dgReportes.Item("nombre", i).Value = NombreReporte Then
                    r = i
                    Exit For
                End If
            Next
            dgReportes.CurrentCell = dgReportes.Item(1, r)


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub



    Private Sub sbReloj_Validated(sender As Object, e As EventArgs)

    End Sub
    Private Sub sbReloj_ValueChanged(sender As Object, e As EventArgs) Handles sbReloj.ValueChanged
        Try
            Dim TipoOrden As String
            Dim I As Integer = -1
            TipoOrden = IIf(sbReloj.Value, "ASC", "DESC")
            'Hacerlo falso, luego verdadero, para activar el "CheckedChanged"
            If chkReloj.Checked Then
                chkReloj.Checked = False
                chkReloj.Checked = True
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub sbNombre_ValueChanged(sender As Object, e As EventArgs) Handles sbNombre.ValueChanged
        Try
            Dim TipoOrden As String
            Dim I As Integer = -1
            TipoOrden = IIf(sbNombre.Value, "ASC", "DESC")
            'Hacerlo falso, luego verdadero, para activar el "CheckedChanged"
            If chkNombre.Checked Then
                chkNombre.Checked = False
                chkNombre.Checked = True
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnOrden_Click(sender As Object, e As EventArgs) Handles btnOrden.Click
        On Error GoTo ErrS
        Dim r As Boolean, n As Boolean
        Dim i As Integer
        ' Dim TipoOrden As String
        frmOrden.ShowDialog()


        i = NOrden
        lstOrden.Items.Clear()
        For x = 0 To NOrden - 1
            lstOrden.Items.Add(Orden(1, x) & " (" & Orden(2, x) & ")")
            If Orden(1, x) = "RELOJ" Then
                r = True
                sbReloj.Value = Orden(2, x) = "ASC"
                chkReloj.Checked = True
                i = i - 1
            ElseIf Orden(1, x) = "NOMBRES" Then
                n = True
                sbReloj.Value = Orden(2, x) = "ASC"
                chkNombre.Checked = True
                i = i - 1
            End If
        Next
        chkReloj.Checked = r
        chkNombre.Checked = n
        chkOtroOrden.Checked = i > 0
        Exit Sub
ErrS:
        MessageBox.Show(Err.Description)
    End Sub

    Private Sub btnSubir_Click(sender As Object, e As EventArgs) Handles btnSubir.Click
        SubirElemento(lstOrden)
    End Sub

    Private Sub btnBajar_Click(sender As Object, e As EventArgs) Handles btnBajar.Click
        BajarElemento(lstOrden)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub lstOrden_KeyUp(sender As Object, e As KeyEventArgs) Handles lstOrden.KeyUp
        Try
            Dim i As Integer
            Dim x As Integer
            If e.KeyValue = Keys.Delete Then
                i = lstOrden.SelectedIndex
                If lstOrden.SelectedItem.ToString.Substring(0, 5) = "RELOJ" Then
                    chkReloj.Checked = False
                ElseIf lstOrden.SelectedItem.ToString.Substring(0, 7) = "NOMBRES" Then
                    chkNombre.Checked = False
                End If

                If i < 0 Then Exit Sub
                If i = 0 Then
                    lstOrden.Items.Clear()
                Else
                    lstOrden.Items.RemoveAt(i)
                End If


                For x = i To NOrden - 1
                    Orden(1, x) = Orden(1, x + 1)
                    Orden(2, x) = Orden(2, x + 1)
                Next
                NOrden = NOrden - 1
                ReDim Preserve Orden(2, x)

                lstOrden.Items.Clear()
                For x = 0 To NOrden - 1
                    lstOrden.Items.Add(Orden(1, x) & "(" & Orden(2, x) & ")")
                Next
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub lstOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrden.SelectedIndexChanged

    End Sub

    Private Sub txtBajas_Validated(sender As Object, e As EventArgs) Handles txtBajas.Validated
        Try
            Dim Filtro As String
            Dim I As Integer = -1
            If chkBajas.Checked Then
                'chkBajas.Checked = False
                'txtActivos.Focus()
                Filtro = " BAJA <= '" & FechaSQL(txtActivos.Value) & "' AND NOT BAJA IS NULL"


                'Actualiza lista de filtros

                For x = 0 To NFiltros - 1
                    If Filtros(1, x) = "BAJAS" Then
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

                Filtros(1, I) = "BAJAS"
                Filtros(2, I) = Filtro

                Filtro = ""
                lstFiltros.Items.Clear()
                For x = 0 To NFiltros - 1
                    lstFiltros.Items.Add(Filtros(2, x))
                    'Filtro = Filtro & IIf(Filtro.Length = 0, "", " AND ") & Filtros(2, x)
                Next
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub gpReportes_Click(sender As Object, e As EventArgs) Handles gpReportes.Click

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            Dim Reporte As String = DireccionReportes & "Reporte dinámico.rdl"
            Dim c As String
            Dim i As Integer = 0
            Dim f As Integer = 0
            Dim Campos() As String
            Dim Grupo1 As String
            Dim Grupo2 As String
            Dim Grupo3 As String
            Dim MostrarDetalle As Byte
            Dim MostrarResumen As Byte
            Dim Titulo As String

            Dim dtCampos As New DataTable
            Dim dtCompa As New DataTable
            Dim dtDatos As New DataTable
            Dim drInfoReporte As DataRow

            'Inicializar campos disponibles
            dtDisponibles = New DataTable
            dtDisponibles = sqlExecute("SELECT UPPER(cod_campo) AS campo,upper(left(nombre,1)) + lower(substring(nombre,2,75)) AS nombre,tipo FROM campos ORDER BY nombre", "TA")
            'MCR 3/NOV/2015
            'Estandarizar y dejar de utilizar TAA, solamente TA como identificador de Time&Attendance
            ReporteadorFuente = "TA"
            frmCrearReporteDinamico.ShowDialog()

            'Revisar si se seleccionó CANCELAR
            If dtReporteDinamico.Columns.Count = 0 Then Exit Sub

            drInfoReporte = dtReporteDinamico.Rows(0)
            dtReportes.ImportRow(drInfoReporte)
            dtReportes.AcceptChanges()

            Titulo = drInfoReporte("nombre").ToString.Trim

            FiltroReporte = FiltrosAcumulados()
            OrdenReporte = OrdenAcumulado()

            If FiltroReporte.ToUpper.Contains("COD_COMP") Then
                'Si no se incluye filtro, tomar el primero de la tabla
                i = FiltroReporte.ToUpper.IndexOf("COD_COMP")
                f = FiltroReporte.ToUpper.IndexOf(")", i)

                c = FiltroReporte.ToUpper.Substring(i, f - i + 1)

                dtCompa = sqlExecute("SELECT COD_COMP, RTRIM(NOMBRE) AS NOMBRE, RFC, REG_PAT, INFONAVIT, LOGO, GUIA, DIRECCION, COLONIA, CIUDAD, ESTADO, COD_POSTAL, TELEFONO1, REP_LEGAL ,PUESTO FROM personal.dbo.cias WHERE " & c)

            Else
                dtCompa = sqlExecute("SELECT TOP 1 COD_COMP,RTRIM(NOMBRE) AS NOMBRE,RFC,REG_PAT,INFONAVIT,LOGO,GUIA FROM personal.dbo.cias WHERE cia_default = 1")
            End If

            dtCampos = sqlExecute("select upper(cod_campo) as campo,nombre,tipo FROM campos", "TA")
            dtCampos.PrimaryKey = New DataColumn() {dtCampos.Columns("campo")}


            Campos = Split(IIf(IsDBNull(drInfoReporte("campos")), "", drInfoReporte("campos")), ",")
            Grupo1 = IIf(IsDBNull(drInfoReporte("grupo1")), "", drInfoReporte("grupo1").ToString.Trim)
            Grupo2 = IIf(IsDBNull(drInfoReporte("grupo2")), "", drInfoReporte("grupo2").ToString.Trim)
            Grupo3 = IIf(IsDBNull(drInfoReporte("grupo3")), "", drInfoReporte("grupo3").ToString.Trim)
            MostrarDetalle = IIf(IsDBNull(drInfoReporte("mostrar_detalle")), 0, drInfoReporte("mostrar_detalle"))
            MostrarResumen = IIf(IsDBNull(drInfoReporte("mostrar_resumen")), 0, drInfoReporte("mostrar_resumen"))


            Dim dtResultadoTAFiltro As New DataSet
            dtResultadoTAFiltro.Merge(dtResultadoTA.Select(FiltroReporte))

            If dtResultadoTAFiltro.Tables.Count = 0 Then
                dtFiltroTA = New DataTable
            Else
                dtFiltroTA = dtResultadoTAFiltro.Tables(0)
                dtResultadoTAFiltro.Tables(0).TableName = "TA"
                dtFiltroTA.DefaultView.Sort = OrdenReporte
            End If

            Dim x As Integer
            Dim Columnas(5) As DataColumn

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reloj", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("campo", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("valor", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("grupo1", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("grupo2", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("grupo3", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            Dim G1 As String = ""
            Dim G2 As String = ""
            Dim G3 As String = ""
            Dim Valor As String = ""
            Dim dr As DataRow

            For Each dRow As DataRow In dtFiltroTA.Rows
                If Grupo1 = "<Ninguno>" Then
                    G1 = ""
                Else
                    dr = dtCampos.Rows.Find(Grupo1)
                    If IsNothing(dr) Then
                        G1 = Grupo1 & " " & dRow(Grupo1)
                    Else
                        G1 = dr.Item("nombre").ToString.Trim & " " & dRow(Grupo1)
                    End If
                End If
                If Grupo2 = "<Ninguno>" Then
                    G2 = ""
                Else
                    dr = dtCampos.Rows.Find(Grupo2)
                    If IsNothing(dr) Then
                        G2 = Grupo2 & " " & dRow(Grupo2)
                    Else
                        G2 = dr.Item("nombre").ToString.Trim & " " & dRow(Grupo2)
                    End If
                End If
                If Grupo3 = "<Ninguno>" Then
                    G3 = ""
                Else
                    dr = dtCampos.Rows.Find(Grupo3)
                    If IsNothing(dr) Then
                        G3 = Grupo3 & " " & dRow(Grupo3)
                    Else
                        G3 = dr.Item("nombre").ToString.Trim & " " & dRow(Grupo3)
                    End If
                End If
                For x = 0 To UBound(Campos)
                    dr = dtCampos.Rows.Find(Campos(x))
                    If Not IsNothing(dr) Then
                        If dr("tipo").ToString.Trim = "num" Then
                            Try
                                Valor = String.Format("{0:0.00}", dRow(Campos(x)))
                            Catch ex As Exception
                                Valor = String.Format("{0:0.00}", 0)
                            End Try
                        Else
                            Valor = IIf(IsDBNull(dRow(Campos(x))), "", dRow(Campos(x)))
                        End If
                    Else
                        Valor = IIf(IsDBNull(dRow(Campos(x))), "", dRow(Campos(x)))
                    End If
                   
                    dtDatos.Rows.Add({dRow("reloj"), dr("nombre").ToString.Trim, Valor, G1, G2, G3})
                Next
            Next

            'Limpiar el ReportViewer, por si hubiera algún reporte cargado
            frmVistaPrevia.vwrReportes.Clear()
            'Indicar que se ejecutarán reportes de forma local (no desde servidor SSRS)
            frmVistaPrevia.vwrReportes.ProcessingMode = ProcessingMode.Local
            frmVistaPrevia.vwrReportes.LocalReport.ReportPath = Reporte
            frmVistaPrevia.vwrReportes.LocalReport.DataSources.Clear()

            frmVistaPrevia.vwrReportes.LocalReport.DataSources.Add(New ReportDataSource("Datos", dtDatos))
            frmVistaPrevia.vwrReportes.LocalReport.DataSources.Add(New ReportDataSource("Compañía", dtCompa))

            Dim Parametros(0) As ReportParameter

            Parametros(0) = New ReportParameter("TITULO", Titulo)

            frmVistaPrevia.vwrReportes.LocalReport.EnableExternalImages = True
            frmVistaPrevia.vwrReportes.LocalReport.SetParameters(Parametros)
            frmVistaPrevia.vwrReportes.RefreshReport()
            frmVistaPrevia.Show(Me)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try

    End Sub

    Private Sub dgReportes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReportes.CellClick
        Try
            Dim r As Integer
            r = e.RowIndex
            If r < 0 Then Exit Sub
            gpFiltros.Enabled = IIf(IsDBNull(dgReportes.Item("FILTRAR", r).Value), Enabled, dgReportes.Item("FILTRAR", r).Value)
            pnlRango.Visible = IIf(IsDBNull(dgReportes.Item("FILTRAR", r).Value), Enabled, dgReportes.Item("FILTRAR", r).Value)
        Catch ex As Exception
            gpFiltros.Enabled = True
            pnlRango.Visible = True
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgReportes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReportes.CellDoubleClick
        btnGenerar.PerformClick()
    End Sub


    Private Sub dgReportes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgReportes.CellEnter
        Try
            Dim i As Integer
            Dim t As String
            Dim u As String
            i = dgReportes.CurrentRow.Index
            t = dgReportes.Item("tipo", i).Value
            u = IIf(IsDBNull(dgReportes.Item("username", i).Value), "", dgReportes.Item("username", i).Value)

            'Permitir borrar solo los reportes creados por el usuario actual
            btnBorrar.Visible = (t.Trim = "U" And u.Trim = Usuario)
        Catch ex As Exception
            btnBorrar.Visible = False

                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            NombreReporte = dgReportes.Item("nombre", dgReportes.CurrentCell.RowIndex).Value.ToString.Trim
            If MessageBox.Show("¿Está seguro de eliminar el reporte " & NombreReporte & "?", "Borrar reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                dtTemporal = sqlExecute("DELETE FROM reportes WHERE nombre = '" & NombreReporte.Trim & "'", "TA")
                dgReportes.Rows.RemoveAt(dgReportes.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgReportes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReportes.CellContentClick

    End Sub

    Private Sub cmbTipoReportes_TextChanged(sender As Object, e As EventArgs) Handles cmbTipoReportes.TextChanged
        CargarReportes()
    End Sub

    'Private Sub bgwReporte_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwReporte.DoWork
    Private Sub bgwReporte_DoWork()
        Dim dtReporte As New DataTable
        Dim r As Integer
        'Dim i As Integer
        Dim Tipo As String
        Try
            r = dgReportes.CurrentCell.RowIndex
            If r < 0 Then Exit Sub
            NombreReporte = dgReportes.Item("nombre", r).Value.ToString.Trim
            'bgwReporte.ReportProgress(0, NombreReporte)

            '== Aquí se almacena el nombre del reporte en la variable global            6oct2021            Ernesto
            _varNomReport = NombreReporte

            Tipo = dgReportes.Item("tipo", r).Value

            sqlExecute("UPDATE reportes SET veces_acceso = veces_acceso + 1, fecha = GETDATE()   WHERE nombre = '" & NombreReporte.Trim & "'", "ta")

            dtTemporal = sqlExecute("SELECT COUNT(nombre) AS cuantos FROM reportes_recientes WHERE usuario = '" & Usuario & "'", "ta")
            If dtTemporal.Rows.Item(0).Item("cuantos") = 10 Then
                sqlExecute("DELETE FROM reportes_recientes WHERE fecha = (SELECT MIN(fecha) FROM reportes_recientes WHERE usuario = '" & _
                           Usuario & "') AND usuario = '" & Usuario & "'", "ta")
            End If

            dtTemporal = sqlExecute("SELECT nombre FROM reportes_recientes WHERE usuario = '" & Usuario & "' AND nombre = '" & _
                                    NombreReporte.Trim & "'", "ta")

            '== Esta sección se modificó para que se almacene el estatus inicial (cuando inicia el proceso de generación de reporte)                6oct2021            Ernesto

            If dtTemporal.Rows.Count > 0 Then
                'sqlExecute("UPDATE reportes_recientes SET fecha = GETDATE() WHERE usuario = '" & Usuario & "' AND nombre = '" & _
                '           NombreReporte.Trim & "'", "ta")
                sqlExecute("UPDATE TA.dbo.reportes_recientes SET fecha = GETDATE(),estatus_inicio='" & Date.Now & "' WHERE usuario = '" & Usuario & "' AND nombre = '" & _
           NombreReporte.Trim & "'")
            Else
                'sqlExecute("INSERT INTO reportes_recientes (usuario,fecha,nombre) VALUES ('" & Usuario & "',GETDATE(),'" & NombreReporte.Trim & "')", _
                '           "ta")
                sqlExecute("INSERT INTO TA.dbo.reportes_recientes (usuario,fecha,nombre,estatus_inicio) VALUES ('" & Usuario & "',GETDATE(),'" & NombreReporte.Trim &
                           "','" & Date.Now & "')")
            End If

            '== Hasta aquí   6oct2021            Ernesto

            dtFiltroPersonal = dtResultadoTA.Clone
            For Each dR As DataRow In dtResultadoTA.Select(FiltroReporte, OrdenReporte)
                dtFiltroPersonal.ImportRow(dR)
            Next

            '== Ordenar info en datatable de la segunda emp             12ene22           Ernesto
            Dim dtTemp As DataTable = dtInfoPlanta2.Clone
            Try
                For Each x As DataRow In dtInfoPlanta2.Select(FiltroReporte, OrdenReporte)
                    dtTemp.ImportRow(x)
                Next
                dtInfoPlanta2 = dtTemp.Copy
            Catch ex As Exception
                dtInfoPlanta2 = dtTemp.Copy
            End Try
            '==


            Dim compania_filtro As String = ""
            Try
                Dim i_ As Integer
                Dim f As Integer

                If FiltroReporte.ToUpper.Contains("COD_COMP") Then
                    'Si no se incluye filtro, tomar el primero de la tabla
                    i_ = FiltroReporte.ToUpper.IndexOf("COD_COMP")
                    f = FiltroReporte.ToUpper.IndexOf(")", i_)

                    compania_filtro = FiltroReporte.ToUpper.Substring(i_, f - i_ + 1)

                    Dim dtCompa As DataTable = sqlExecute("SELECT COD_COMP, NOMBRE, RFC, REG_PAT, INFONAVIT, LOGO, GUIA, DIRECCION, COLONIA, CIUDAD, ESTADO, COD_POSTAL, TELEFONO1, REP_LEGAL ,PUESTO FROM personal.dbo.cias WHERE " & compania_filtro)
                    If dtCompa.Rows.Count > 0 Then
                        compania_filtro = dtCompa.Rows(0)("cod_comp")
                    Else
                        compania_filtro = ""
                    End If

                ElseIf FiltroReporte.ToUpper.Contains("COMPANIA") Then
                    'Si no se incluye filtro, tomar el primero de la tabla
                    i_ = FiltroReporte.ToUpper.IndexOf("COMPANIA")
                    f = FiltroReporte.ToUpper.IndexOf(")", i_)

                    compania_filtro = FiltroReporte.ToUpper.Substring(i_, f - i_ + 1)
                    compania_filtro = compania_filtro.Replace("COMPANIA", "NOMBRE")

                    Dim dtCompa As DataTable = sqlExecute("SELECT COD_COMP, NOMBRE, RFC, REG_PAT, INFONAVIT, LOGO, GUIA, DIRECCION, COLONIA, CIUDAD, ESTADO, COD_POSTAL, TELEFONO1, REP_LEGAL ,PUESTO FROM personal.dbo.cias WHERE " & compania_filtro)
                    If dtCompa.Rows.Count > 0 Then
                        compania_filtro = dtCompa.Rows(0)("cod_comp")
                    Else
                        compania_filtro = ""
                    End If
                End If
            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            End Try

            If Tipo = "U" Then
                dtDisponibles = sqlExecute("SELECT UPPER(cod_campo) AS campo,personal.dbo.IniciaMayuscula(nombre) AS nombre,tipo " & _
                                           "FROM campos ORDER BY nombre", "TA")
                'MCR 3/NOV/2015
                'Estandarizar y dejar de utilizar TAA, solamente TA como identificador de Time&Attendance
                ReporteadorFuente = "TA"
                dtReporte = sqlExecute("SELECT * FROM reportes WHERE nombre = '" & NombreReporte & "'", "ta")
                If dtReporte.Rows.Count < 1 Then Exit Sub
                frmVistaPrevia.ReporteDinamico(dtReporte.Rows(0), dtFiltroPersonal, NombreReporte)
            ElseIf Tipo = "X" Then
                PreparaDatos(NombreReporte, dtFiltroPersonal)
            Else
                '---Llamar reportes especiales
                If NombreReporte.Trim = "Revisión de horas OH totales por centro de costo" Then
                    If AnoSelec <> "" And PeriodoSelec <> "" And FechaSQL(FechaInicial) <> "" And FechaSQL(FechaFinal) <> "" Then
                        frmVistaPrevia.LlamarReporte(NombreReporte.Trim, TotResXCC(AnoSelec, PeriodoSelec, FechaSQL(FechaInicial), FechaSQL(FechaFinal), dtFiltroPersonal))
                        frmVistaPrevia.Show(Me)
                    Else
                        MessageBox.Show("Debe de seleccionar la opción del periodo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    'ElseIf NombreReporte.Trim = "Graficas Ausentismo" Then   'Jose R Hdez 2019-Abr-30
                    '    genera_graficas_ausentismo(dtFiltroPersonal)
                    '    MessageBox.Show("Reporte de graficas de ausentismo generado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else '---Llamar a todos los demas reportes
                    frmVistaPrevia.LlamarReporte(NombreReporte.Trim, dtFiltroPersonal, compania_filtro)
                    frmVistaPrevia.Show(Me)
                End If
            End If

            '== Reestablecer variables globales         25nov2021
            selecPlantaRep = 0

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub bgwReporte_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwReporte.ProgressChanged
        lblAvance.Text = "... PREPARANDO ..." & vbCrLf & CType(e.UserState, String)
        If e.ProgressPercentage = 100 Then
            gpAvance.Visible = False
            pbAvance.IsRunning = False
        End If
    End Sub

    'Private Sub bgwReporte_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwReporte.RunWorkerCompleted
    Private Sub bgwReporte_RunWorkerCompleted()
        Try
            Dim r As Integer = 0

            CargarReportes()
            For I = 0 To dgReportes.Rows.Count - 1
                If dgReportes.Item("nombre", I).Value = NombreReporte Then
                    r = I
                    Exit For
                End If
            Next
            dgReportes.CurrentCell = dgReportes.Item(1, r)

        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            pbAvance.IsRunning = False
            gpAvance.Visible = False

            gpControles.Enabled = True
            gpReportes.Enabled = True
            gpFiltros.Enabled = True
            gpOrden.Enabled = True
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub frmReporteadorTA_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        gpAvance.Left = (Me.Width - gpAvance.Size.Width) / 2
        pnlCentrarControles.Left = (Me.Width - pnlCentrarControles.Size.Width) / 2
    End Sub

    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        BuscaReporte = EliminaAcentos(txtBusca.Text.Trim)
        CargarReportes()
    End Sub

    ''' <summary>
    ''' Proceso para actualizar datos antes de ejecutar reporte MCR (4/NOV/2015). Modificado 25nov2021  Ernesto
    ''' </summary>
    Private Function ConsultaBitacora(ByVal dtTabla As DataTable, ByVal FechaTope As Date, Optional empresa As Integer = 0) As Boolean
        Dim dtBitacora As New DataTable
        Dim dtAsist As New DataTable
        Dim dRow As DataRow
        Dim dSeleccionados() As DataRow

        Try
            'Buscar en asist, los números de reloj que se hayan analizado a partir de la última actualización, 
            'y que pertenezcan al rango de fechas del reporteador
            dtAsist = sqlExecute("SELECT DISTINCT reloj FROM asist WHERE " & _
                                 "fha_ent_hor BETWEEN '" & FechaSQL(LocalRangoFInicial) & "' AND '" & FechaSQL(LocalRangoFFinal) & _
                                 "' AND RTRIM(RTRIM(CONVERT(char,fecha,121)) +' ' + hora) >= '" & FechaHoraSQL(UltimaActualizacion, True, False) & "'", _
                                 "ta")
            For Each dRow In dtAsist.Rows
                'Buscar los registros ya integrados al datatable, que estén entre los modificados
                dSeleccionados = dtTabla.Select("reloj = '" & dRow("reloj").ToString.Trim & "'")
                For Each dSel As DataRow In dSeleccionados
                    'Borrar los registros del empleado que se haya modificado
                    'Considerando que algunos registros se agregan, otros se eliminan cuando se analiza en TA
                    dtTabla.Rows.Remove(dSel)
                Next

                'Tomar nuevamente todos los datos del empleado, en el rango de fechas
                dtBitacora = sqlExecute("SELECT * FROM TAVW WHERE " & _
                                        "RELOJ= '" & dRow("RELOJ") & "' AND " & _
                                        "fha_ent_hor between '" & FechaSQL(LocalRangoFInicial) & "' AND '" & FechaSQL(LocalRangoFFinal) & "'", "TA")

                For Each dRec As DataRow In dtBitacora.Rows
                    'Importar cada registro en el rango
                    dtTabla.ImportRow(dRec)
                Next
            Next

            'Tomar fecha/hora de última actualización de datos
            UltimaActualizacion = Now

            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    ' ''' <summary>
    ' ''' Proceso para actualizar datos antes de ejecutar reporte MCR (4/NOV/2015)
    ' ''' </summary>
    'Private Function ConsultaBitacora(ByVal dtTabla As DataTable, ByVal FechaTope As Date) As Boolean
    '    Dim dtBitacora As New DataTable
    '    Dim dtAsist As New DataTable
    '    Dim dRow As DataRow
    '    Dim dSeleccionados() As DataRow

    '    Try
    '        'Buscar en asist, los números de reloj que se hayan analizado a partir de la última actualización, 
    '        'y que pertenezcan al rango de fechas del reporteador
    '        dtAsist = sqlExecute("SELECT DISTINCT reloj FROM asist WHERE " & _
    '                             "fha_ent_hor BETWEEN '" & FechaSQL(LocalRangoFInicial) & "' AND '" & FechaSQL(LocalRangoFFinal) & _
    '                             "' AND RTRIM(RTRIM(CONVERT(char,fecha,121)) +' ' + hora) >= '" & FechaHoraSQL(UltimaActualizacion, True, False) & "'", _
    '                             "ta")
    '        For Each dRow In dtAsist.Rows
    '            'Buscar los registros ya integrados al datatable, que estén entre los modificados
    '            dSeleccionados = dtTabla.Select("reloj = '" & dRow("reloj").ToString.Trim & "'")
    '            For Each dSel As DataRow In dSeleccionados
    '                'Borrar los registros del empleado que se haya modificado
    '                'Considerando que algunos registros se agregan, otros se eliminan cuando se analiza en TA
    '                dtTabla.Rows.Remove(dSel)
    '            Next

    '            'Tomar nuevamente todos los datos del empleado, en el rango de fechas
    '            dtBitacora = sqlExecute("SELECT * FROM TAVW WHERE " & _
    '                                    "RELOJ= '" & dRow("RELOJ") & "' AND " & _
    '                                    "fha_ent_hor between '" & FechaSQL(LocalRangoFInicial) & "' AND '" & FechaSQL(LocalRangoFFinal) & "'", "TA")

    '            For Each dRec As DataRow In dtBitacora.Rows
    '                'Importar cada registro en el rango
    '                dtTabla.ImportRow(dRec)
    '            Next
    '        Next

    '        'Tomar fecha/hora de última actualización de datos
    '        UltimaActualizacion = Now

    '        Return True
    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
    '        Return False
    '    End Try
    'End Function

    '-----------------------------------------FUNCIONES ESPECIALES PARA CIERTOS REPORTES
    Private Function TotResXCC(ByVal ano As String, ByVal per As String, ByVal f_ini As String, ByVal f_fin As String, ByVal dtInfoSemana As DataTable) As DataTable
        Try
            '--Mandar rango de fechas
            '  Dim Fec_Inic As Date = Now.Date
            ' Dim Fec_Fin As Date = Fec_Inic.AddDays(7).Date

            Dim frm As New frmRangoFechas
            If frm.ShowDialog = DialogResult.OK Then
                f_ini = FechaInicial
                f_fin = FechaFinal
            End If
            ano = ""
            per = ""
            '   Dim strPer As String = ""

            '------Obtener Año y periodo(s) que aplican para ese rango de fechas mandando
            Dim dtPeriodos As DataTable = sqlExecute("select * from periodos where (FECHA_INI<='" & FechaSQL(f_fin) & "' AND FECHA_FIN>='" & FechaSQL(f_ini) & "') AND PERIODO_ESPECIAL=0 ORDER BY PERIODO ASC", "TA")
            If (Not dtPeriodos.Columns.Contains("ERROR") And dtPeriodos.Rows.Count > 0) Then
                ano = IIf(IsDBNull(dtPeriodos.Rows(0).Item("ANO")), "", dtPeriodos.Rows(0).Item("ANO")) ' El año va a ser el 1ero que encuentre
                For Each dRPer As DataRow In dtPeriodos.Rows
                    '--Asignar los periodos que aplican
                    per = per & "'" & dRPer("PERIODO").ToString.Trim & "',"
                Next
            End If
            per = per.TrimStart(",") 'Elimina todas las "," al inicio 
            per = per.TrimEnd(",") 'Elimina todas las "," al final 
            '--Al final per va a ser = '01','02','03'  Etc

            Dim dtFinal As New DataTable
            dtFinal.Columns.Add("ANO")
            dtFinal.Columns.Add("PERIODO")
            dtFinal.Columns.Add("CENTRO_COSTOS")
            dtFinal.Columns.Add("HRS_DOBLES", GetType(System.Double))
            dtFinal.Columns.Add("HRS_TRIPLES", GetType(System.Double))
            dtFinal.Columns.Add("HRS_NOPAG", GetType(System.Double))
            dtFinal.Columns.Add("HRS_RETARDO", GetType(System.Double))
            dtFinal.Columns.Add("HRS_FEL", GetType(System.Double))
            dtFinal.Columns.Add("DIADOM", GetType(System.Double))
            dtFinal.Columns.Add("DIASAB", GetType(System.Double))
            dtFinal.Columns.Add("DIASAB_UNI", GetType(System.Double))
            dtFinal.Columns.Add("PGO", GetType(System.Double))
            dtFinal.Columns.Add("FI", GetType(System.Double))
            dtFinal.Columns.Add("JUS", GetType(System.Double))
            dtFinal.Columns.Add("PSG", GetType(System.Double))
            dtFinal.Columns.Add("SUS", GetType(System.Double))
            dtFinal.Columns.Add("SHU", GetType(System.Double))
            dtFinal.Columns.Add("PAR", GetType(System.Double))
            dtFinal.Columns.Add("SAL", GetType(System.Double))
            dtFinal.Columns.Add("INA", GetType(System.Double))
            dtFinal.Columns.Add("EG", GetType(System.Double))
            dtFinal.Columns.Add("MAT", GetType(System.Double))
            dtFinal.Columns.Add("RT", GetType(System.Double))
            dtFinal.Columns.Add("DIACON", GetType(System.Double))
            dtFinal.Columns.Add("DIASIN", GetType(System.Double))
            dtFinal.Columns.Add("DIADES", GetType(System.Double))
            dtFinal.Columns.Add("fec_ini")
            dtFinal.Columns.Add("fec_fin")


            Dim dtCCostos As New DataTable
            dtCCostos = sqlExecute("SELECT DISTINCT psw.CENTRO_COSTOS AS CENTRO_COSTOS from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw " & _
                                   "on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and ns.ANO='" & ano & "' and ns.PERIODO in(" & per & ") " & _
                                   "and psw.alta  <= '" & FechaSQL(f_fin) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini) & "')   and isnull(psw.cod_super, '') <> ''")

            If dtCCostos.Rows.Count > 0 Then
                For Each row As DataRow In dtCCostos.Rows '--Para cada Centro de costo que hay en ese periodo
                    Dim drow As DataRow = dtFinal.NewRow
                    Dim cCosto As String = IIf(IsDBNull(row("CENTRO_COSTOS")), "", row("CENTRO_COSTOS").ToString.Trim)
                    drow("CENTRO_COSTOS") = cCosto

                    '--Horas Dobles
                    Dim dtHrsDbls As DataTable = sqlExecute("SELECT ISNULL((SUM (ns.hrs_dobles)),0) AS HORAS_DOBLES from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and " & _
                                                            "ns.ANO='" & ano & "' and ns.PERIODO in(" & per & ") and psw.alta  <= '" & FechaSQL(f_fin) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini) & "')   and isnull(psw.cod_super, '') <> '' " & _
                                                            "and psw.CENTRO_COSTOS='" & cCosto & "'")
                    drow("HRS_DOBLES") = IIf((dtHrsDbls.Rows.Count > 0), Double.Parse(dtHrsDbls.Rows(0).Item("HORAS_DOBLES").ToString.Trim()), 0)
                    drow("HRS_DOBLES") = Math.Round(drow("HRS_DOBLES"), 2)

                    '----Horas Triples
                    Dim dtHrsTrip As DataTable = sqlExecute("SELECT ISNULL((SUM (ns.hrs_triples)),0) AS HORAS_TRIPLES from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and " & _
                                                         "ns.ANO='" & ano & "' and ns.PERIODO in(" & per & ") and psw.alta  <= '" & FechaSQL(f_fin) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini) & "')   and isnull(psw.cod_super, '') <> '' " & _
                                                         "and psw.CENTRO_COSTOS='" & cCosto & "'")
                    drow("HRS_TRIPLES") = IIf((dtHrsTrip.Rows.Count > 0), Double.Parse(dtHrsTrip.Rows(0).Item("HORAS_TRIPLES").ToString.Trim()), 0)
                    drow("HRS_TRIPLES") = Math.Round(drow("HRS_TRIPLES"), 2)

                    '---Salida Anticipada
                    Dim dtHrsNoPag As DataTable = sqlExecute("SELECT SUM (ns.hrs_nopag) AS HRS_NOPAG from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and " & _
                                                         "ns.ANO='" & ano & "' and ns.PERIODO in(" & per & ") and psw.alta  <= '" & FechaSQL(f_fin) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini) & "')   and isnull(psw.cod_super, '') <> '' " & _
                                                         "and psw.CENTRO_COSTOS='" & cCosto & "'")
                    drow("HRS_NOPAG") = IIf((dtHrsNoPag.Rows.Count > 0), Double.Parse(dtHrsNoPag.Rows(0).Item("HRS_NOPAG").ToString.Trim()), 0)
                    drow("HRS_NOPAG") = Math.Round(drow("HRS_NOPAG"), 2)


                    '----Horas Retardo
                    Dim dtHrsRet As DataTable = sqlExecute("SELECT ISNULL((SUM (ns.hrs_retardo)),0) AS HRS_RETARDO from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and " & _
                                                       "ns.ANO='" & ano & "' and ns.PERIODO in(" & per & ") and psw.alta  <= '" & FechaSQL(f_fin) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini) & "')   and isnull(psw.cod_super, '') <> '' " & _
                                                       "and psw.CENTRO_COSTOS='" & cCosto & "'")
                    drow("HRS_RETARDO") = IIf((dtHrsRet.Rows.Count > 0), Double.Parse(dtHrsRet.Rows(0).Item("HRS_RETARDO").ToString.Trim()), 0)
                    drow("HRS_RETARDO") = Math.Round(drow("HRS_RETARDO"), 2)

                    '-------Horas Festivas
                    Dim dtHrsFest As DataTable = sqlExecute("SELECT ISNULL((SUM (ns.hrs_fel)),0) AS HRS_FEL from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and " & _
                                                      "ns.ANO='" & ano & "' and ns.PERIODO in(" & per & ") and psw.alta  <= '" & FechaSQL(f_fin) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini) & "')   and isnull(psw.cod_super, '') <> '' " & _
                                                      "and psw.CENTRO_COSTOS='" & cCosto & "'")
                    drow("HRS_FEL") = IIf((dtHrsFest.Rows.Count > 0), Double.Parse(dtHrsFest.Rows(0).Item("HRS_FEL").ToString.Trim()), 0)
                    drow("HRS_FEL") = Math.Round(drow("HRS_FEL"), 2)

                    '--------Prima Dominical, Totales
                    Dim dtPrimDom As DataTable = sqlExecute("SELECT COUNT(ns.RELOJ) AS DIADOM from nomsem ns left join asist a on ns.RELOJ=a.RELOJ left join PERSONAL.dbo.personalvw psw ON ns.RELOJ=psw.RELOJ and ns.ANO=a.ANO and ns.PERIODO=a.PERIODO " & _
                                                            "WHERE ns.PRIMA_DOM=1 and ns.ANO ='" & ano & "' and ns.PERIODO in(" & per & ") and datepart(dw,a.FHA_ENT_HOR)=1 and a.COD_COMP='002' and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("DIADOM") = IIf((dtPrimDom.Rows.Count > 0), Double.Parse(dtPrimDom.Rows(0).Item("DIADOM").ToString.Trim()), 0)


                    '--------Prima Sabatina ( $ PAGO)
                    Dim dtPrimSabDin As DataTable = sqlExecute("select ISNULL((SUM(psw.SACTUAL * 0.25) ),0) AS DIASAB from nomsem ns left join asist a on ns.RELOJ=a.RELOJ left join PERSONAL.dbo.personalvw psw on ns.RELOJ=psw.RELOJ and ns.ANO=a.ANO and ns.PERIODO=a.PERIODO " & _
                                                               "WHERE ns.PRIMA_SAB=1 and ns.ANO ='" & ano & "' and ns.PERIODO in(" & per & ") and datepart(dw,a.FHA_ENT_HOR)=7 and a.COD_COMP='002' and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("DIASAB") = IIf((dtPrimSabDin.Rows.Count > 0), Double.Parse(dtPrimSabDin.Rows(0).Item("DIASAB").ToString.Trim()), 0)
                    drow("DIASAB") = Math.Round(drow("DIASAB"), 2)

                    '-------Prima Sabatina (Totales Unidades)
                    Dim dtPriSabU As DataTable = sqlExecute("SELECT COUNT(ns.RELOJ) AS DIASAB_UNI from nomsem ns left join asist a on ns.RELOJ=a.RELOJ left join PERSONAL.dbo.personalvw psw ON ns.RELOJ=psw.RELOJ and ns.ANO=a.ANO and ns.PERIODO=a.PERIODO " & _
                                                           "WHERE ns.PRIMA_SAB=1 and ns.ANO ='" & ano & "' and ns.PERIODO in(" & per & ") and datepart(dw,a.FHA_ENT_HOR)=7 and a.COD_COMP='002' and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("DIASAB_UNI") = IIf((dtPriSabU.Rows.Count > 0), Double.Parse(dtPriSabU.Rows(0).Item("DIASAB_UNI").ToString.Trim()), 0)


                    '--------PGO
                    Dim dtTotPGO As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS PGO FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo in(" & per & ") AND asi.tipo_aus in ('PGO') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("PGO") = IIf((dtTotPGO.Rows.Count > 0), Double.Parse(dtTotPGO.Rows(0).Item("PGO").ToString.Trim()), 0)


                    '------FI
                    Dim dtTotFI As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS FI FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo in(" & per & ") AND asi.tipo_aus in ('FI') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("FI") = IIf((dtTotFI.Rows.Count > 0), Double.Parse(dtTotFI.Rows(0).Item("FI").ToString.Trim()), 0)

                    '------JUS
                    Dim dtTotJUS As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS JUS FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo in(" & per & ") AND asi.tipo_aus in ('JUS') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("JUS") = IIf((dtTotJUS.Rows.Count > 0), Double.Parse(dtTotJUS.Rows(0).Item("JUS").ToString.Trim()), 0)

                    '------PSG
                    Dim dtTotPSG As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS PSG FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo in(" & per & ") AND asi.tipo_aus in ('PSG') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("PSG") = IIf((dtTotPSG.Rows.Count > 0), Double.Parse(dtTotPSG.Rows(0).Item("PSG").ToString.Trim()), 0)

                    '-------SUS
                    Dim dtTotSUS As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS SUS FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo in(" & per & ") AND asi.tipo_aus in ('SUS') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("SUS") = IIf((dtTotSUS.Rows.Count > 0), Double.Parse(dtTotSUS.Rows(0).Item("SUS").ToString.Trim()), 0)

                    '-------SHU
                    Dim dtTotSHU As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS SHU FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo in(" & per & ") AND asi.tipo_aus in ('SHU') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("SHU") = IIf((dtTotSHU.Rows.Count > 0), Double.Parse(dtTotSHU.Rows(0).Item("SHU").ToString.Trim()), 0)

                    '-------PAR
                    Dim dtTotPAR As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS PAR FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo in(" & per & ") AND asi.tipo_aus in ('PAR') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("PAR") = IIf((dtTotPAR.Rows.Count > 0), Double.Parse(dtTotPAR.Rows(0).Item("PAR").ToString.Trim()), 0)

                    '-------SAL
                    Dim dtTotSAL As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS SAL FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo in(" & per & ") AND asi.tipo_aus in ('SAL') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("SAL") = IIf((dtTotSAL.Rows.Count > 0), Double.Parse(dtTotSAL.Rows(0).Item("SAL").ToString.Trim()), 0)

                    '-------INA
                    '  Dim dtTotINA As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS INA FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo in(" & per & ") AND asi.tipo_aus in ('INA') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    Dim dtTotINA As DataTable = sqlExecute("SELECT COUNT(aus.RELOJ) AS INA FROM ausentismo aus LEFT JOIN PERSONAL.dbo.personalvw psw on aus.RELOJ=psw.RELOJ where aus.COD_COMP='002' and aus.fecha between '" & FechaSQL(f_ini) & "' and '" & FechaSQL(f_fin) & "' and aus.periodo in(" & per & ") AND aus.tipo_aus in ('INA') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("INA") = IIf((dtTotINA.Rows.Count > 0), Double.Parse(dtTotINA.Rows(0).Item("INA").ToString.Trim()), 0)

                    '-------EG
                    '  Dim dtTotEG As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS EG FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo in(" & per & ") AND asi.tipo_aus in ('EG') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    Dim dtTotEG As DataTable = sqlExecute("SELECT COUNT(aus.RELOJ) AS EG FROM ausentismo aus LEFT JOIN PERSONAL.dbo.personalvw psw on aus.RELOJ=psw.RELOJ where aus.COD_COMP='002' and aus.fecha between '" & FechaSQL(f_ini) & "' and '" & FechaSQL(f_fin) & "' and aus.periodo in(" & per & ") AND aus.tipo_aus in ('EG') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("EG") = IIf((dtTotEG.Rows.Count > 0), Double.Parse(dtTotEG.Rows(0).Item("EG").ToString.Trim()), 0)

                    '-------MAT
                    ' Dim dtTotMAT As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS MAT FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo in(" & per & ") AND asi.tipo_aus in ('MAT') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    Dim dtTotMAT As DataTable = sqlExecute("SELECT COUNT(aus.RELOJ) AS MAT FROM ausentismo aus LEFT JOIN PERSONAL.dbo.personalvw psw on aus.RELOJ=psw.RELOJ where aus.COD_COMP='002' and aus.fecha between '" & FechaSQL(f_ini) & "' and '" & FechaSQL(f_fin) & "' and aus.periodo in(" & per & ") AND aus.tipo_aus in ('MAT') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("MAT") = IIf((dtTotMAT.Rows.Count > 0), Double.Parse(dtTotMAT.Rows(0).Item("MAT").ToString.Trim()), 0)

                    '-------RT
                    Dim dtTotRT As DataTable = sqlExecute("SELECT COUNT(aus.RELOJ) AS RT FROM ausentismo aus LEFT JOIN PERSONAL.dbo.personalvw psw on aus.RELOJ=psw.RELOJ where aus.COD_COMP='002' and aus.fecha between '" & FechaSQL(f_ini) & "' and '" & FechaSQL(f_fin) & "' and aus.periodo in(" & per & ") AND aus.tipo_aus in ('RT') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("RT") = IIf((dtTotRT.Rows.Count > 0), Double.Parse(dtTotRT.Rows(0).Item("RT").ToString.Trim()), 0)

                    '-------DIACON
                    Dim dtTotConSub As DataTable = sqlExecute("select count(hrc.reloj) as DIACON from hrs_brt_cafeteria hrc left join PERSONAL.dbo.personalvw psw on hrc.reloj=psw.RELOJ " & _
                                                              "where hrc.cod_comp='002' and hrc.FECHA>='" & FechaSQL(f_ini) & "' AND hrc.fecha<='" & FechaSQL(f_fin) & "' AND hrc.subsidio='C' and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("DIACON") = IIf((dtTotConSub.Rows.Count > 0), Double.Parse(dtTotConSub.Rows(0).Item("DIACON").ToString.Trim()), 0)

                    '-------DIASIN
                    Dim dtTotSinSub As DataTable = sqlExecute("select count(hrc.reloj) as DIASIN from hrs_brt_cafeteria hrc left join PERSONAL.dbo.personalvw psw on hrc.reloj=psw.RELOJ " & _
                                                  "where hrc.cod_comp='002' and hrc.FECHA>='" & FechaSQL(f_ini) & "' AND hrc.fecha<='" & FechaSQL(f_fin) & "' AND hrc.subsidio='S' and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("DIASIN") = IIf((dtTotSinSub.Rows.Count > 0), Double.Parse(dtTotSinSub.Rows(0).Item("DIASIN").ToString.Trim()), 0)

                    '-------DIADES
                    Dim dtTotDes As DataTable = sqlExecute("select count(hrc.reloj) as DIADES from hrs_brt_cafeteria hrc left join PERSONAL.dbo.personalvw psw on hrc.reloj=psw.RELOJ " & _
                                              "where hrc.cod_comp='002' and hrc.FECHA>='" & FechaSQL(f_ini) & "' AND hrc.fecha<='" & FechaSQL(f_fin) & "' AND hrc.subsidio='Z' and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
                    drow("DIADES") = IIf((dtTotDes.Rows.Count > 0), Double.Parse(dtTotDes.Rows(0).Item("DIADES").ToString.Trim()), 0)

                    '--Para Año, Periodo y fechas
                    drow("ANO") = ano
                    drow("PERIODO") = per
                    drow("fec_ini") = FechaSQL(f_ini)
                    drow("fec_fin") = FechaSQL(f_fin)
                    dtFinal.Rows.Add(drow)
                Next
            End If
            Return dtFinal

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Function

End Class