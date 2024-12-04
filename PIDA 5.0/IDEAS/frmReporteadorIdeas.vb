
Imports Microsoft.Reporting.WinForms
Imports System.Xml
Public Class frmReporteadorIdeas
    Dim dtReportes As New DataTable
    Dim Acumulado As String
    Dim NombreReporte As String = ""
    Dim BuscaReporte As String = ""

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

        Return FL
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

    Private Sub frmReporteadorTA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtPersonalFaltante As New DataTable
        Try
            lblFechas.Text = FechaCortaLetra(RangoFInicial) & " A " & FechaCortaLetra(RangoFFinal)
            If RangoFFinal < Today Then
                txtActivos.MaxDate = RangoFFinal
                txtBajas.MaxDate = RangoFFinal
                txtActivos.Value = RangoFFinal
                txtBajas.Value = RangoFFinal
            Else
                txtActivos.Value = Today
                txtBajas.Value = Today

            End If

            bgw.WorkerReportsProgress = True
            gpAvance.Visible = True
            pbAvance.IsRunning = True
            lblAvance.Text = "Cargando información"
            My.Application.DoEvents()
            bgw.RunWorkerAsync()
            chkActivos.Checked = True
            FiltroActivos()
        Catch ex As Exception
            Stop
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
                FiltroActivos()
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

            If chkRecientes.Checked Then
                Cadena = "SELECT RTRIM(reportes.NOMBRE) AS NOMBRE,reportes.TIPO," & _
                    "(100*VECES_ACCESO)/((SELECT MAX(veces_acceso) FROM reportes)+1) AS 'Frecuencia'," & _
                    "reportes_recientes.FECHA,FILTRAR,username FROM REPORTES RIGHT JOIN reportes_recientes ON " & _
                    "reportes.nombre = reportes_recientes.nombre WHERE reportes_recientes.usuario = '" & _
                    Usuario & "' AND reportes.NOMBRE IN " & _
                    "(SELECT CONTROL FROM SEGURIDAD.dbo.PERMISOS WHERE " & IIf(FiltrarTipo, " reportes.tipo='" & cmbTipoReportes.SelectedValue & "' AND ", "") & _
                    " cod_perfil " & Perfil & " AND permisos.modulo = 'IDE'  and permisos.acceso = 1)" & _
                   IIf(BuscaReporte.Length = 0, "", " AND dbo.EliminaAcentos(reportes.nombre) LIKE '%" & BuscaReporte & "%' ") & _
                    "ORDER BY reportes_recientes.fecha DESC,nombre"
            Else
                Cadena = "SELECT RTRIM(reportes.NOMBRE) AS NOMBRE,reportes.TIPO," & _
                    "(100*VECES_ACCESO)/((SELECT MAX(veces_acceso) FROM reportes)+1) AS Frecuencia,reportes.FECHA,FILTRAR,username " & _
                    "FROM REPORTES WHERE reportes.NOMBRE IN " & _
                    "(SELECT CONTROL FROM SEGURIDAD.dbo.PERMISOS WHERE " & IIf(FiltrarTipo, " reportes.tipo='" & cmbTipoReportes.SelectedValue & "' AND ", "") & _
                    IIf(FiltrarTipo, " reportes.tipo='" & cmbTipoReportes.SelectedValue & "' AND ", " NOT reportes.tipo IN ('S','T') AND ") & _
                    " cod_perfil " & Perfil & " AND permisos.modulo = 'IDE'   and permisos.acceso = 1)" & _
                    IIf(BuscaReporte.Length = 0, "", " AND dbo.EliminaAcentos(reportes.nombre) LIKE '%" & BuscaReporte & "%' ") & _
                    " ORDER BY reportes.nombre"
            End If
            dtReportes = New DataTable
            dtReportes = sqlExecute(Cadena, "IDEAS")
            dgReportes.DataSource = dtReportes
            'dgReportes.Columns("username").Visible = False
            'dgReportes.Sort(dgReportes.Columns.Item(D), O)
            If dgReportes.Rows.Count > 0 Then
                'dgReportes.Rows.Item(1).Visible = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
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
            frmFiltroIdeas.ShowDialog()
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

        My.Application.DoEvents()
        'bgwReporte.RunWorkerAsync()

        bgwReporte_DoWork()
        bgwReporte_RunWorkerCompleted()
    End Sub

    Private Function FiltrosTAAcumulados() As String
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

        Return FL
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

            dtTemporal = sqlExecute("UPDATE reportes SET veces_acceso = veces_acceso + 1, fecha = GETDATE()   WHERE nombre = '" & NombreReporte.Trim & "'", "IDEAS")

            dtTemporal = sqlExecute("SELECT COUNT(nombre) AS cuantos FROM reportes_recientes WHERE usuario = '" & Usuario & "'", "IDEAS")
            If dtTemporal.Rows.Item(0).Item("cuantos") = 10 Then
                dtTemporal = sqlExecute("DELETE FROM reportes_recientes WHERE fecha = (SELECT MIN(fecha) FROM reportes_recientes WHERE usuario = '" & Usuario & "') AND usuario = '" & Usuario & "'", "IDEAS")
            End If

            dtTemporal = sqlExecute("SELECT nombre FROM reportes_recientes WHERE usuario = '" & Usuario & "' AND nombre = '" & NombreReporte.Trim & "'", "IDEAS")
            If dtTemporal.Rows.Count > 0 Then
                dtTemporal = sqlExecute("UPDATE reportes_recientes SET fecha = GETDATE() WHERE usuario = '" & Usuario & "' AND nombre = '" & NombreReporte.Trim & "'", "IDEAS")
            Else
                dtTemporal = sqlExecute("INSERT INTO reportes_recientes (usuario,fecha,nombre) VALUES ('" & Usuario & "',GETDATE(), '" & NombreReporte & "')", "IDEAS")
            End If

            FiltroReporte = FiltrosAcumulados()
            OrdenReporte = OrdenAcumulado()

            Dim dtResultadoIDEASFiltro As New DataSet
            dtResultadoIDEASFiltro.Merge(dtResultadoIDEAS.Select(FiltroReporte))

            If dtResultadoIDEASFiltro.Tables.Count = 0 Then
                dtFiltroTA = New DataTable
            Else
                dtFiltroTA = dtResultadoIDEASFiltro.Tables(0)
                dtResultadoIDEASFiltro.Tables(0).TableName = "IDEAS"
                dtFiltroTA.DefaultView.Sort = OrdenReporte
            End If

            If Tipo = "U" Then
                dtDisponibles = sqlExecute("SELECT UPPER(cod_campo) AS campo,upper(left(nombre,1)) + lower(substring(nombre,2,75)) AS nombre,tipo FROM campos ORDER BY nombre", "IDEAS")
                ReporteadorFuente = "TAA"
                dtReporte = sqlExecute("SELECT * FROM reportes WHERE nombre = '" & NombreReporte.Trim & "'", "IDEAS")
                If dtReporte.Rows.Count < 1 Then Exit Sub
                frmVistaPrevia.ReporteDinamico(dtReporte.Rows(0), dtFiltroTA, NombreReporte)
            Else
                frmVistaPrevia.LlamarReporte(NombreReporte, dtFiltroTA)
                frmVistaPrevia.Show(Me)
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
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
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
        frmOrdenIdeas.ShowDialog()

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
            dtDisponibles = sqlExecute("SELECT UPPER(cod_campo) AS campo,upper(left(nombre,1)) + lower(substring(nombre,2,75)) AS nombre,tipo FROM campos ORDER BY nombre", "IDEAS")
            ReporteadorFuente = "IDEAS"
            frmCrearReporteDinamico.ShowDialog()

            'Revisar si se seleccionó CANCELAR
            If dtReporteDinamico.Columns.Count = 0 Then Exit Sub
            If dtReporteDinamico.Rows.Count = 0 Then
                MessageBox.Show("Hubo un error durante la creación del reporte, y este no pudo guardarse. Si el problema persiste, contacte con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            drInfoReporte = dtReporteDinamico.Rows(0)
            dtReportes.ImportRow(drInfoReporte)
            dtReportes.AcceptChanges()

            Titulo = drInfoReporte("nombre")

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

            dtCampos = sqlExecute("select upper(cod_campo) as campo,nombre,tipo FROM campos", "IDEAS")
            dtCampos.PrimaryKey = New DataColumn() {dtCampos.Columns("campo")}


            Campos = Split(IIf(IsDBNull(drInfoReporte("campos")), "", drInfoReporte("campos")), ",")
            Grupo1 = IIf(IsDBNull(drInfoReporte("grupo1")), "", drInfoReporte("grupo1").ToString.Trim)
            Grupo2 = IIf(IsDBNull(drInfoReporte("grupo2")), "", drInfoReporte("grupo2").ToString.Trim)
            Grupo3 = IIf(IsDBNull(drInfoReporte("grupo3")), "", drInfoReporte("grupo3").ToString.Trim)
            MostrarDetalle = IIf(IsDBNull(drInfoReporte("mostrar_detalle")), 0, drInfoReporte("mostrar_detalle"))
            MostrarResumen = IIf(IsDBNull(drInfoReporte("mostrar_resumen")), 0, drInfoReporte("mostrar_resumen"))


            Dim dtResultadoIDEASFiltro As New DataSet
            dtResultadoIDEASFiltro.Merge(dtResultadoIDEAS.Select(FiltroReporte))

            If dtResultadoIDEASFiltro.Tables.Count = 0 Then
                dtFiltroTA = New DataTable
            Else
                dtFiltroTA = dtResultadoIDEASFiltro.Tables(0)
                dtResultadoIDEASFiltro.Tables(0).TableName = "IDEAS"
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
            ' frmVistaPrevia.Show(Me)
            If MostrarReporte Then
                frmVistaPrevia.Show(Me)
            Else
                MessageBox.Show("El reporte no pudo ser generado", "Error al generar el reporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MostrarReporte = True
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
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
                dtTemporal = sqlExecute("DELETE FROM reportes WHERE nombre = '" & NombreReporte.Trim & "'", "IDEAS")
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

            Tipo = dgReportes.Item("tipo", r).Value

            sqlExecute("UPDATE reportes SET veces_acceso = veces_acceso + 1, fecha = GETDATE()   WHERE nombre = '" & NombreReporte.Trim & "'", "IDEAS")

            dtTemporal = sqlExecute("SELECT COUNT(nombre) AS cuantos FROM reportes_recientes WHERE usuario = '" & Usuario & "'", "IDEAS")
            If dtTemporal.Rows.Item(0).Item("cuantos") = 10 Then
                sqlExecute("DELETE FROM reportes_recientes WHERE fecha = (SELECT MIN(fecha) FROM reportes_recientes WHERE usuario = '" & _
                           Usuario & "') AND usuario = '" & Usuario & "'", "IDEAS")
            End If

            dtTemporal = sqlExecute("SELECT nombre FROM reportes_recientes WHERE usuario = '" & Usuario & "' AND nombre = '" & _
                                    NombreReporte.Trim & "'", "IDEAS")
            If dtTemporal.Rows.Count > 0 Then
                sqlExecute("UPDATE reportes_recientes SET fecha = GETDATE() WHERE usuario = '" & Usuario & "' AND nombre = '" & _
                           NombreReporte.Trim & "'", "IDEAS")
            Else
                sqlExecute("INSERT INTO reportes_recientes (usuario,fecha,nombre) VALUES ('" & Usuario & "',GETDATE(),'" & NombreReporte.Trim & "')", _
                           "IDEAS")
            End If

            Dim dtResultadoIDEAStemp As DataTable = dtResultadoIDEAS.Copy
            If NombreReporte.ToString.Trim.Equals("Formato en blanco para impresión") Then
                GenerarFormatoEnBlanco("Formato en blanco para impresión")
                Exit Sub

            End If
            If NombreReporte.ToString.Trim.Equals("Participación de mi departamento") Then
                If FiltroXUsuario.ToUpper.Contains("COD_DEPTO") Or FiltroXUsuario.ToUpper.Contains("COD_SUPER") Then
                    dtResultadoIDEAS = ObtenerPersonalIdeas(FiltroXUsuario)
                Else
                    MessageBox.Show("No puedes generar este reporte debido a que el filtro de tu usuario es incorrecto, Contacta al encargado del programa de IDEAS.", "Formato de Filtro incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                dtFiltroPersonal = dtResultadoIDEAS.Clone
                For Each dR As DataRow In dtResultadoIDEAS.Rows
                    dtFiltroPersonal.ImportRow(dR)
                Next
            Else
                dtFiltroPersonal = dtResultadoIDEAS.Clone
                For Each dR As DataRow In dtResultadoIDEAS.Select(FiltroReporte, OrdenReporte)
                    dtFiltroPersonal.ImportRow(dR)
                Next
            End If

            dtResultadoIDEAS = dtResultadoIDEAStemp.Copy


            Dim I As Integer
            If FiltroReporte.Contains("COD_COMP") Then
                'I = FiltroReporte.IndexOf("COD_COMP")
                'CiaReporteador = FiltroReporte.Substring(I + 14, 3)
                CiaReporteador = ""
            Else
                CiaReporteador = ""
            End If
            If Tipo = "U" Then
                dtDisponibles = sqlExecute("SELECT UPPER(cod_campo) AS campo,personal.dbo.IniciaMayuscula(nombre) AS nombre,tipo " & _
                                           "FROM campos ORDER BY nombre", "IDEAS")
                ReporteadorFuente = "TAA"
                dtReporte = sqlExecute("SELECT * FROM reportes WHERE nombre = '" & NombreReporte & "'", "IDEAS")
                If dtReporte.Rows.Count < 1 Then Exit Sub
                frmVistaPrevia.ReporteDinamico(dtReporte.Rows(0), dtFiltroPersonal, NombreReporte)
            Else
                frmVistaPrevia.LlamarReporte(NombreReporte.Trim, dtFiltroPersonal, CiaReporteador.Replace("''", ""))
                'bgwReporte.ReportProgress(100)
                ' frmVistaPrevia.Show(Me)
                If MostrarReporte Then
                    frmVistaPrevia.Show(Me)
                Else
                    MessageBox.Show(MensajeError, "Error al generar el reporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MensajeError = ""
                    MostrarReporte = True
                End If
            End If

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
        Application.DoEvents()
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
        Try
            BuscaReporte = EliminaAcentos(txtBusca.Text.Trim)
            CargarReportes()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub bgw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        Dim dtPersonalFaltante As New DataTable
        Try
            dtResultadoIDEAS = ObtenerPersonalIdeas()
            For Each dEmp As DataRow In dtPersonalFaltante.Rows
                dtResultadoIDEAS.ImportRow(dEmp)
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub bgw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        pbAvance.IsRunning = False
        gpAvance.Visible = False

        chkRecientes.Text = "Ver últimos 10 reportes utilizados por el usuario " & Usuario.ToUpper
        chkRecientes.Checked = False
        'txtActivos.Value = RangoFFinal
        'txtBajas.Value = RangoFFinal

        Acumulado = FiltrosAcumulados()

        cmbTipoReportes.DataSource = sqlExecute("SELECT * FROM tipo_reportes ORDER BY tipo", "IDEAS")
        cmbTipoReportes.SelectedValue = "X"
    End Sub
    Private Sub FiltroActivos()
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

    Private Sub chkActivos_Validated(sender As Object, e As EventArgs) Handles chkActivos.Validated
        FiltroActivos()
    End Sub

    Private Sub bgwReporte_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwReporte.DoWork

    End Sub
    Private Function ObtenerPersonalIdeas(Optional FiltroUsuarioIdeas As String = "") As DataTable
        Dim dtTemp1 As DataTable = New DataTable
        Dim dtTemp2 As DataTable = New DataTable
        FiltroUsuarioIdeas = FiltroUsuarioIdeas.ToUpper.Replace("[COD_DEPTO]", "[COD_DEPTO_ACTUAL]")
        FiltroUsuarioIdeas = FiltroUsuarioIdeas.ToUpper.Replace("[COD_SUPER]", "[COD_SUPER_ACTUAL]")
        Dim query As String = "" & _
     " select * from " & _
       " (SELECT " & _
       " ideasvw.folio, " & _
       " ideasvw.reloj, " & _
       " ideasvw.nombres, " & _
       " ideasvw.alta, " & _
       " ideasvw.baja, " & _
       " personalvw.cod_mot_ba, " & _
       " ideasvw.fecha, " & _
              " ideasvw.CAPTURA, " & _
       " ideasvw.cod_estacion, " & _
       " ideasvw.cod_objetivo, " & _
       " ideasvw.cod_desperdicio, " & _
       " ideasvw.tipo, " & _
       " ideasvw.descripcion, " & _
       " ideasvw.estatus, " & _
       " ideasvw.pagada, " & _
       " ideasvw.USUARIO, " & _
" ideasvw.usuario_windows , " & _
" ideasvw.equipo, " & _
" ideasvw.PROBLEMA, " & _
" ideasvw.IDEA, " & _
" ideasvw.RESULTADO, " & _
       " ideasvw.aprobacion, " & _
       " ideasvw.implementacion, " & _
       " ideasvw.calificacion, " & _
       " case when ideasvw.COD_OBJETIVO = '004' then cast(130 as decimal(5,2)) / cast(colaboradores as decimal(5,2)) else cast(65 as decimal(4,2)) / cast(colaboradores as decimal(4,2)) end AS cantidad, " & _
       " ideasvw.titulo, " & _
       " ideasvw.envio_nomina, " & _
       " ideasvw.nombre_estacion, " & _
       " ideasvw.mes_implementacion, " & _
       " ideasvw.nombre_objetivos, " & _
       " ideasvw.nombre_desperdicios , " & _
       " ideasvw.pagada AS periodo, " & _
      "  ideasvw.COD_COMP_ACTUAL, " & _
      " ideasvw.NOMBRE_COMP_ACTUAL, " & _
      " ideasvw.cod_comp, " & _
      " ideasvw.compania, " & _
      " ideasvw.COD_DEPTO_ACTUAL, " & _
      " ideasvw.NOMBRE_DEPTO_ACTUAL, " & _
      " ideasvw.cod_area_a, " & _
      " ideasvw.calif, " & _
      " ideasvw.cod_DEPTO, " & _
      " ideasvw.NOMBRE_DEPTO, " & _
      " ideasvw.COD_SUPER_ACTUAL, " & _
      " ideasvw.NOMBRE_SUPER_ACTUAL, " & _
      " ideasvw.cod_SUPER, " & _
      " ideasvw.NOMBRE_SUPER, " & _
      " ideasvw.COD_PUESTO_ACTUAL, " & _
      " ideasvw.NOMBRE_PUESTO_ACTUAL, " & _
      " ideasvw.cod_PUESTO, " & _
      " ideasvw.NOMBRE_PUESTO, " & _
      " ideasvw.COD_AREA_ACTUAL, " & _
      " ideasvw.NOMBRE_AREA_ACTUAL, " & _
      " ideasvw.cod_AREA, " & _
      " ideasvw.NOMBRE_AREA, " & _
      " ideasvw.COD_PLANTA_ACTUAL, " & _
      " ideasvw.COD_TURNO_ACTUAL, " & _
      " ideasvw.NOMBRE_PLANTA_ACTUAL, " & _
      " ideasvw.cod_PLANTA, " & _
      " ideasvw.NOMBRE_PLANTA,ideasvw.CENTRO_COSTOS, " & _
      "personalvw.cod_clase " & _
      " from ideas.dbo.ideasvw " & _
      " left join personal.dbo.personalvw on  personalvw.reloj = ideasvw.reloj " & _
      "WHERE personalvw.reloj NOT IN ('004343', '004078', '020141', '020418', '020245', '003144', '003145'," & _
            "'003149', '003159', '003171', '003189', '003190', '003192', '003209'," & _
            "'003212', '003211', '003184', '001901', '004343', '020245', '003229'," & _
            "'003230', '003231', '003232', '001004', '001007', '001008', '001009'," & _
            "'003149', '003192', '003212', '003214', '003215', '003216', '003217'," & _
            "'003219', '003220', '003221', '003222', '003223', '003224', '003225'," & _
            "'003226', '003228', '003184', '003211', '003227', '001901', '003210','004343', '020182','020255','020453')" & _
      ") as ideas" & _
      " where (fecha between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "') and  (baja between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' or baja is null) and ( cod_mot_ba <>'06' or cod_mot_ba is null) " + IIf(FiltroUsuarioIdeas.Equals(""), "", " AND ALTA <= '" + FechaSQL(RangoFFinal) + "' AND (BAJA IS NULL OR BAJA > '" + FechaSQL(RangoFFinal) + "') and " + FiltroUsuarioIdeas)
        '" where (fecha between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "') and  (baja between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' or baja is null) and ( cod_mot_ba <>'06' or cod_mot_ba is null) " + IIf(FiltroUsuarioIdeas.Equals(""), "", " AND ALTA <= '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "') and " + FiltroUsuarioIdeas)
        '(baja between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' or baja is null) and ( cod_mot_ba <>'06' or cod_mot_ba is null) " + IIf(FiltroUsuarioIdeas.Equals(""), "", " AND ALTA <= '" + FechaSQL(RangoFFinal) + "' AND (BAJA IS NULL OR BAJA > '" + FechaSQL(RangoFFinal) + "') and " + FiltroUsuarioIdeas)
        Dim query2 As String = "" & _
" select * from " & _
" (SELECT " & _
" ideasvw.folio, " & _
" personalvw.reloj, " & _
" personalvw.nombres, " & _
" personalvw.alta, " & _
" personalvw.baja, " & _
" personalvw.cod_mot_ba, " & _
" ideasvw.fecha, " & _
" ideasvw.CAPTURA, " & _
" ideasvw.cod_estacion, " & _
" ideasvw.cod_objetivo, " & _
" ideasvw.cod_desperdicio, " & _
" ideasvw.tipo, " & _
" ideasvw.descripcion, " & _
" ideasvw.estatus, " & _
" ideasvw.pagada, " & _
" ideasvw.aprobacion, " & _
" ideasvw.implementacion, " & _
" ideasvw.calificacion, " & _
" case when ideasvw.COD_OBJETIVO = '004' then cast(130 as decimal(5,2)) / cast(colaboradores as decimal(5,2)) else cast(65 as decimal(4,2)) / cast(colaboradores as decimal(4,2)) end AS cantidad, " & _
" ideasvw.titulo, " & _
" ideasvw.envio_nomina, " & _
" ideasvw.nombre_estacion, " & _
" ideasvw.mes_implementacion, " & _
" ideasvw.nombre_objetivos, " & _
" ideasvw.nombre_desperdicios , " & _
" ideasvw.pagada AS periodo, " & _
" ideasvw.USUARIO, " & _
" ideasvw.usuario_windows , " & _
" ideasvw.equipo, " & _
" ideasvw.PROBLEMA, " & _
" ideasvw.IDEA, " & _
" ideasvw.RESULTADO, " & _
"  personalvw.cod_comp as COD_COMP_ACTUAL, " & _
" personalvw.compania as NOMBRE_COMP_ACTUAL, " & _
" personalvw.cod_comp, " & _
" personalvw.compania, " & _
" personalvw.cod_DEPTO as COD_DEPTO_ACTUAL, " & _
" personalvw.NOMBRE_DEPTO as NOMBRE_DEPTO_ACTUAL, " & _
" personalvw.cod_DEPTO, " & _
" personalvw.NOMBRE_DEPTO, " & _
" personalvw.cod_SUPER as COD_SUPER_ACTUAL, " & _
" personalvw.NOMBRE_SUPER as NOMBRE_SUPER_ACTUAL, " & _
" personalvw.cod_SUPER, " & _
" personalvw.NOMBRE_SUPER, " & _
" personalvw.cod_PUESTO as COD_PUESTO_ACTUAL, " & _
" personalvw.NOMBRE_PUESTO as NOMBRE_PUESTO_ACTUAL, " & _
" personalvw.cod_PUESTO, " & _
" personalvw.NOMBRE_PUESTO, " & _
" personalvw.cod_AREA as COD_AREA_ACTUAL, " & _
" personalvw.NOMBRE_AREA as NOMBRE_AREA_ACTUAL, " & _
" personalvw.cod_AREA, " & _
" personalvw.NOMBRE_AREA, " & _
" personalvw.cod_PLANTA as COD_PLANTA_ACTUAL, " & _
" personalvw.NOMBRE_PLANTA as NOMBRE_PLANTA_ACTUAL, " & _
" personalvw.cod_PLANTA, " & _
 " ideasvw.COD_TURNO_ACTUAL, " & _
" personalvw.NOMBRE_PLANTA,personalvw.CENTRO_COSTOS, " & _
" personalvw.cod_clase " & _
" from personal.dbo.personalvw " & _
" left join ideas.dbo.ideasvw on  personalvw.reloj = ideasvw.FOLIO " & _
      "WHERE personalvw.reloj NOT IN ('004343', '004078', '020141', '020418', '020245', '003144', '003145'," & _
            "'003149', '003159', '003171', '003189', '003190', '003192', '003209'," & _
            "'003212', '003211', '003184', '001901', '004343', '020245', '003229'," & _
            "'003230', '003231', '003232', '001004', '001007', '001008', '001009'," & _
            "'003149', '003192', '003212', '003214', '003215', '003216', '003217'," & _
            "'003219', '003220', '003221', '003222', '003223', '003224', '003225'," & _
            "'003226', '003228', '003184', '003211', '003227', '001901', '003210','004343', '020182','020255','020453')" & _
      ") as ideas" & _
" where  (baja between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' or baja is null) and ( cod_mot_ba <>'06' or cod_mot_ba is null) " + IIf(FiltroUsuarioIdeas.Equals(""), "", " AND ALTA <= '" + FechaSQL(RangoFFinal) + "' AND (BAJA IS NULL OR BAJA > '" + FechaSQL(RangoFFinal) + "') and " + FiltroUsuarioIdeas)


        dtTemp1 = sqlExecute(query, "IDEAS")
        dtTemp2 = sqlExecute(query2, "IDEAS")
        dtTemp1.Merge(dtTemp2)
        Return dtTemp1
    End Function
    Private Sub GenerarFormatoEnBlanco(n As String)
        Dim SF As New SaveFileDialog
        SF.FileName = n
        SF.Filter = "Excel file (*.xlsx)|*.xlsx"
        SF.FilterIndex = 1
        Dim resultado As Integer = SF.ShowDialog()
        If resultado = DialogResult.OK Then
            Dim Source As String = DireccionReportes + n + ".xlsx"
            Dim Destination As String = SF.FileName
            System.IO.File.Copy(Source, Destination, True)
        End If
    End Sub
End Class