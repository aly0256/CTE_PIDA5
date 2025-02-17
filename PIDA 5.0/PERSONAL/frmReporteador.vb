Imports Microsoft.Reporting.WinForms
Imports System.Xml
Public Class frmReporteador
    Dim BuscaReporte As String = ""
    Dim dtReportes As New DataTable
    Dim Acumulado As String
    Dim NombreReporte As String = ""
    Dim dtTemp As New DataTable
    Dim UltimaActualizacion As DateTime

    Public Function FiltrosAcumulados() As String
        Dim FL As String = ""
        Dim i As Integer
        Try
            lstFiltros.Items.Clear()

            If NFiltros <= 0 And Filtros.Length > 0 And Not chkTodos.Checked Then NFiltros = 1 '==AO: Arregla detalle de cargar bajas en la primera vez que se accesa al server


            For i = 0 To NFiltros - 1
                FL = FL & IIf(i > 0, " AND (", "(") & Filtros(2, i) & ")"
                lstFiltros.Items.Add(Filtros(2, i))
            Next
            'If FL.Length > 0 Then
            '    FL = " WHERE " & FL
            'End If
        Catch ex As Exception
            NFiltros = 0 '==AO: Arregla detalle de cargar bajas en la primera vez que se accesa al server
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

    Private Sub frmReporteador_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        NFiltros = 0
        Me.Dispose()
    End Sub

    Private Sub frmReporteador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmbTipoReportes.DataSource = sqlExecute("SELECT * FROM tipo_reportes ORDER BY tipo", "personal")
            cmbTipoReportes.SelectedValue = ""

            'Utilizar el OVER para que el máximo no sea por grupo, sino en general
            chkRecientes.Text = "Ver últimos 10 reportes utilizados por el usuario " & Usuario.ToUpper
            chkRecientes.Checked = False
            txtActivos.Value = Today
            txtBajas.Value = Today

            Acumulado = FiltrosAcumulados()

            pbAvance.IsRunning = True
            gpAvance.Visible = True

            gpControles.Enabled = False
            gpReportes.Enabled = False
            gpFiltros.Enabled = False
            gpOrden.Enabled = False

            Me.Cursor = Cursors.WaitCursor
            CiaReporteador = ""

            bgw.WorkerReportsProgress = True
            bgw.RunWorkerAsync()

            chkActivos.Checked = True
            FiltroActivos()

            '==filtro para controles        julio2021       ernesto
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
                FiltroBajas()
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

            '-- 2024-03-21
            If cmbTipoReportes.SelectedValue Is Nothing Then cmbTipoReportes.SelectedValue = "G"

            If chkRecientes.Checked Then
                Cadena = "SELECT RTRIM(reportes.NOMBRE) AS NOMBRE,reportes.TIPO," & _
                    "(100*VECES_ACCESO)/((SELECT MAX(veces_acceso) FROM reportes)+1) AS 'Frecuencia'," & _
                    "reportes_recientes.FECHA,FILTRAR,username FROM REPORTES RIGHT JOIN reportes_recientes ON " & _
                    "reportes.nombre = reportes_recientes.nombre WHERE reportes_recientes.usuario = '" & _
                    Usuario & "' AND reportes.NOMBRE IN " & _
                    "(SELECT CONTROL FROM SEGURIDAD.dbo.PERMISOS WHERE " & IIf(FiltrarTipo, " reportes.tipo='" & cmbTipoReportes.SelectedValue & "' AND ", "") & _
                    " cod_perfil " & Perfil & " AND permisos.modulo = 'PER'  and permisos.acceso = 1)" & _
                   IIf(BuscaReporte.Length = 0, "", " AND dbo.EliminaAcentos(reportes.nombre) LIKE '%" & BuscaReporte & "%' ") & _
                    "ORDER BY reportes_recientes.fecha DESC,nombre"
            Else
                Cadena = "SELECT RTRIM(reportes.NOMBRE) AS NOMBRE,reportes.TIPO," & _
                    "(100*VECES_ACCESO)/((SELECT MAX(veces_acceso) FROM reportes)+1) AS Frecuencia,reportes.FECHA,FILTRAR,username " & _
                    "FROM REPORTES WHERE reportes.NOMBRE IN " & _
                    "(SELECT CONTROL FROM SEGURIDAD.dbo.PERMISOS WHERE " & IIf(FiltrarTipo, " reportes.tipo='" & cmbTipoReportes.SelectedValue & "' AND ", "") & _
                    " cod_perfil " & Perfil & " AND permisos.modulo = 'PER'  and permisos.acceso = 1)" & _
                    IIf(BuscaReporte.Length = 0, "", " AND dbo.EliminaAcentos(reportes.nombre) LIKE '%" & BuscaReporte & "%' ") & _
                    " ORDER BY reportes.nombre"
            End If
            dtReportes = New DataTable
            dtReportes = sqlExecute(Cadena)
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
            Dim x As Integer
            frmFiltro.ShowDialog(Me)
            Acumulado = FiltrosAcumulados()

            chkOtrosFiltros.Checked = NFiltros > 0

            Filtro = ""
            lstFiltros.Items.Clear()
            For x = 0 To NFiltros - 1
                lstFiltros.Items.Add(Filtros(2, x))
            Next
            If x = 0 Then
                chkTodos.Checked = True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtActivos_Click(sender As Object, e As EventArgs) Handles txtActivos.Click

    End Sub

    Private Sub txtActivos_Validated(sender As Object, e As EventArgs) Handles txtActivos.Validated
        FiltroActivos()
    End Sub
    Private Sub FiltroBajas()
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
    Private Sub FiltroActivos()
        Try
            Dim Filtro As String
            Dim I As Integer = -1
            If chkActivos.Checked Then
                'chkBajas.Checked = False
                'txtActivos.Focus()
                Filtro = " ALTA <= '" & FechaSQL(txtActivos.Value) & "' AND (BAJA IS NULL OR BAJA >= '" & FechaSQL(txtActivos.Value) & "')"


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
        Dim dtReporte As New DataTable
        Dim r As Integer
        Dim i As Integer
        Dim Nombre As String
        Dim Tipo As String
        Try
            r = dgReportes.CurrentCell.RowIndex
            If r < 0 Then Exit Sub
            Nombre = dgReportes.Item("nombre", r).Value
            Tipo = dgReportes.Item("tipo", r).Value

            sqlExecute("UPDATE reportes SET veces_acceso = veces_acceso + 1, fecha = GETDATE()   WHERE nombre = '" & Nombre.Trim & "'")

            dtTemporal = sqlExecute("SELECT COUNT(nombre) AS cuantos FROM reportes_recientes WHERE usuario = '" & Usuario & "'")
            If dtTemporal.Rows.Item(0).Item("cuantos") = 10 Then
                sqlExecute("DELETE FROM reportes_recientes WHERE fecha = (SELECT MIN(fecha) FROM reportes_recientes WHERE usuario = '" & Usuario & "') AND usuario = '" & Usuario & "'")
            End If

            dtTemporal = sqlExecute("SELECT * FROM reportes_recientes WHERE usuario = '" & Usuario & "' AND nombre = '" & Nombre.Trim & "'")
            If dtTemporal.Rows.Count > 0 Then
                sqlExecute("UPDATE reportes_recientes SET fecha = GETDATE() WHERE usuario = '" & Usuario & "' AND nombre = '" & Nombre.Trim & "'")
            Else
                sqlExecute("INSERT INTO reportes_recientes (usuario,fecha,nombre) VALUES ('" & Usuario & "',GETDATE(),'" & Nombre.Trim & "')")
            End If

            EncabezadoReporte = ""
            FiltroReporte = FiltrosAcumulados()
            OrdenReporte = OrdenAcumulado()

            'MCR 28/OCT/2015
            'Revisar bitácora por cambios desde última actualización de datos
            ConsultaBitacora(dtResultado, UltimaActualizacion)

            '*********-----****--AO: 2024-05-30 Casos de auxiliares cuando los campos se llaman 001, 002, etc, para que no marque error al filktrar
            If dtResultado.Columns.Contains("001") Then dtResultado.Columns("001").ColumnName = "D01"
            If dtResultado.Columns.Contains("002") Then dtResultado.Columns("002").ColumnName = "D02"
            If dtResultado.Columns.Contains("003") Then dtResultado.Columns("003").ColumnName = "D03"
            If dtResultado.Columns.Contains("004") Then dtResultado.Columns("004").ColumnName = "D04"

            Dim _var As String = ""
            Try : _var = FiltroReporte.Substring(1, 3).ToString.Trim : Catch ex As Exception : _var = "" : End Try

            If _var = "001" Then FiltroReporte = FiltroReporte.Replace("001", "D01")
            If _var = "002" Then FiltroReporte = FiltroReporte.Replace("002", "D02")
            If _var = "003" Then FiltroReporte = FiltroReporte.Replace("003", "D03")
            If _var = "004" Then FiltroReporte = FiltroReporte.Replace("004", "D04")

            '***********--*********END Datos de auxiliares

            Dim dtResultadoFiltro As New DataSet
            dtResultadoFiltro.Merge(dtResultado.Select(FiltroReporte))

            If dtResultadoFiltro.Tables.Count = 0 Then
                dtFiltroPersonal = New DataTable
            Else
                dtFiltroPersonal = dtResultadoFiltro.Tables(0)
                'Dependiendo del reporte va a tomar la tabla
                Select Case Nombre
                    Case "Reporte de rutas detalle", "Reporte de rutas", "Reporte de rutas detalle salida", "Reporte de rutas salida", "Datos para servicio médico"
                        dtResultadoFiltro.Tables(0).TableName = "personalvw"
                    Case Else
                        dtResultadoFiltro.Tables(0).TableName = "Personal"
                End Select

                dtFiltroPersonal.DefaultView.Sort = OrdenReporte
            End If


            Dim compania As String = ""
            Try
                Dim i_ As Integer
                Dim f As Integer

                If FiltroReporte.ToUpper.Contains("COD_COMP") Then
                    'Si no se incluye filtro, tomar el primero de la tabla
                    i_ = FiltroReporte.ToUpper.IndexOf("COD_COMP")
                    f = FiltroReporte.ToUpper.IndexOf(")", i_)

                    compania = FiltroReporte.ToUpper.Substring(i_, f - i_ + 1)

                    Dim dtCompa As DataTable = sqlExecute("SELECT COD_COMP, NOMBRE, RFC, REG_PAT, INFONAVIT, LOGO, GUIA, DIRECCION, COLONIA, CIUDAD, ESTADO, COD_POSTAL, TELEFONO1, REP_LEGAL ,PUESTO FROM personal.dbo.cias WHERE " & compania)
                    If dtCompa.Rows.Count > 0 Then
                        compania = dtCompa.Rows(0)("cod_comp")
                    Else
                        compania = ""
                    End If

                ElseIf FiltroReporte.ToUpper.Contains("COMPANIA") Then
                    'Si no se incluye filtro, tomar el primero de la tabla
                    i_ = FiltroReporte.ToUpper.IndexOf("COMPANIA")
                    f = FiltroReporte.ToUpper.IndexOf(")", i_)

                    compania = FiltroReporte.ToUpper.Substring(i_, f - i_ + 1)
                    compania = compania.Replace("COMPANIA", "NOMBRE")

                    Dim dtCompa As DataTable = sqlExecute("SELECT COD_COMP, NOMBRE, RFC, REG_PAT, INFONAVIT, LOGO, GUIA, DIRECCION, COLONIA, CIUDAD, ESTADO, COD_POSTAL, TELEFONO1, REP_LEGAL ,PUESTO FROM personal.dbo.cias WHERE " & compania)
                    If dtCompa.Rows.Count > 0 Then
                        compania = dtCompa.Rows(0)("cod_comp")
                    Else
                        compania = ""
                    End If
                End If
            Catch ex As Exception

            End Try

            If Tipo = "U" Then
                dtDisponibles = sqlExecute("(SELECT UPPER(cod_campo) AS campo,personal.dbo.IniciaMayuscula(nombre) AS nombre,tipo FROM campos " & _
                                           "UNION SELECT UPPER(campo),personal.dbo.IniciaMayuscula(nombre) AS nombre,'aux' as tipo FROM auxiliares) " & _
                                           "ORDER BY nombre")
                ReporteadorFuente = "PERSONAL"
                dtReporte = sqlExecute("SELECT * FROM reportes WHERE nombre = '" & Nombre & "'")
                If dtReporte.Rows.Count < 1 Then Exit Sub
                frmVistaPrevia.ReporteDinamico(dtReporte.Rows(0), dtFiltroPersonal, Nombre)
            ElseIf Nombre = "Resultados Encuesta Cafetería" Then
                ResultadosEncuestaCafeteriaExcel()
            ElseIf Nombre.ToUpper = "CARTAS GENERALES" Then
                frmCartasGenerales.ShowDialog()
            ElseIf Nombre.ToUpper = "ETIQUETAS" Then
                FormaOrigen = Me.Name
                '  frmElegirEtiquetas.ShowDialog() ' AOS - Originalmente para eleguir el tipo de etiquetas, pero se hará directo
                frmElegirEtiquetas.MandarEtiquetas()
            ElseIf Nombre.ToUpper = "CONTRATOS" Then
                Dim ContratosNew As frmContratos = New frmContratos("Reporteador")
                ContratosNew.ShowDialog()
            ElseIf Nombre.ToUpper = "REPORTE SUPERVISORES SF" Then
                Dim dtsupersf As DataTable = sqlExecute("SELECT super.*, SF_Hirings.sf_id FROM super LEFT JOIN SF_Hirings on super.reloj = SF_Hirings.reloj")
                frmVistaPrevia.LlamarReporte(Nombre, dtsupersf)
                frmVistaPrevia.ShowDialog()
            ElseIf Nombre.ToUpper = "PERSONAL CON HIJOS" Then
                frmNumeroHijos.ShowDialog()
                If CapturaEdad = True Then
                    frmVistaPrevia.LlamarReporte(Nombre, dtFiltroPersonal, compania)
                    frmVistaPrevia.ShowDialog()
                    CapturaEdad = False
                End If
            ElseIf Nombre = "Resultados encuestas" Then
                Dim frmReEn As New frmResultadosEncuesta
                frmReEn.ShowDialog()
            ElseIf Nombre = "Reporte Empleados Baja" Then '--------------Antonio
                Dim dtBajas As New DataTable
                '== Agregados motivos de baja 12abr2022     Ernesto
                dtBajas = sqlExecute("select reloj,reloj_alt as 'id_sap',FORMAT(alta, 'dd-MMM-yyyy') AS 'alta', FORMAT(baja, 'dd-MMM-yyyy') AS 'baja',motivo_baja,nombres,nombre_puesto,nombre_depto,CENTRO_COSTOS,COD_SUPER,nombre_super," & _
                                                     "COD_MOT_BA,motivo_baja,cod_sub_ba,SUBMOTIVO_BAJA from personalvw where isnull(baja,'')<>'' order by reloj asc", "PERSONAL")
                frmVistaPrevia.LlamarReporte(Nombre, dtBajas, compania)
                frmVistaPrevia.ShowDialog()
            ElseIf Tipo = "Z" Then
                Dim frm As New frmCondensados
                frm.condensado = Nombre.Trim
                frm.dtInfo = dtFiltroPersonal
                frm.ShowDialog()
            ElseIf Tipo = "X" Then
                PreparaDatos(Nombre, dtFiltroPersonal)
            ElseIf Nombre = "Disco de infonavit al SUA" Then '--------------AOS
                PreparaDatos(Nombre, dtFiltroPersonal)
            ElseIf Tipo = "D" Then
                TipoReporteEstadistico = Trim(Nombre)
                frmEstadisticaDisiciplinaria.ShowDialog()
            ElseIf Tipo = "G" Then
                frmVistaPrevia.LlamarReporte(Nombre, dtFiltroPersonal, compania)
                frmVistaPrevia.ShowDialog()
                'MsgBox("Finalizó la operación", MsgBoxStyle.OkOnly & vbInformation, "Reporteador")
            End If

            acciones(Nombre.Trim)

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
        FiltroBajas()
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

            'Inicializar datos de campos antes de iniciar
            dtDisponibles = New DataTable
            dtDisponibles = sqlExecute("(SELECT UPPER(cod_campo) AS campo,personal.dbo.IniciaMayuscula(nombre) AS nombre " & _
                                       "FROM campos UNION " & _
                                       "SELECT UPPER(campo),personal.dbo.IniciaMayuscula(nombre) AS nombre FROM auxiliares) " & _
                                       "ORDER BY nombre")
            ReporteadorFuente = "PERSONAL"
            frmCrearReporteDinamico.ShowDialog()

            frmCrearReporteDinamico.reporte_edicion = ""

            'Revisar si se seleccionó CANCELAR
            If dtReporteDinamico.Columns.Count = 0 Then Exit Sub

            drInfoReporte = dtReporteDinamico.Rows(0)
            dtReportes.ImportRow(drInfoReporte)
            dtReportes.AcceptChanges()

            Titulo = drInfoReporte("nombre").ToString.Trim.ToUpper

            FiltroReporte = FiltrosAcumulados()
            OrdenReporte = OrdenAcumulado()

            If FiltroReporte.ToUpper.Contains("COD_COMP") Then
                'Si no se incluye filtro, tomar el primero de la tabla
                i = FiltroReporte.ToUpper.IndexOf("COD_COMP")
                f = FiltroReporte.ToUpper.IndexOf(")", i)

                c = FiltroReporte.ToUpper.Substring(i, f - i + 1)

                dtCompa = sqlExecute("SELECT COD_COMP, NOMBRE, RFC, REG_PAT, INFONAVIT, LOGO, GUIA, DIRECCION, COLONIA, CIUDAD, ESTADO, COD_POSTAL, TELEFONO1, REP_LEGAL ,PUESTO FROM personal.dbo.cias WHERE " & c)

            ElseIf FiltroReporte.ToUpper.Contains("COMPANIA") Then
                'Si no se incluye filtro, tomar el primero de la tabla
                i = FiltroReporte.ToUpper.IndexOf("COMPANIA")
                f = FiltroReporte.ToUpper.IndexOf(")", i)

                c = FiltroReporte.ToUpper.Substring(i, f - i + 1)
                c = c.Replace("COMPANIA", "NOMBRE")

                dtCompa = sqlExecute("SELECT COD_COMP, NOMBRE, RFC, REG_PAT, INFONAVIT, LOGO, GUIA, DIRECCION, COLONIA, CIUDAD, ESTADO, COD_POSTAL, TELEFONO1, REP_LEGAL ,PUESTO FROM personal.dbo.cias WHERE " & c)

            Else
                dtCompa = sqlExecute("SELECT TOP 1 COD_COMP,NOMBRE,RFC,REG_PAT,INFONAVIT,LOGO,GUIA FROM personal.dbo.cias WHERE cia_default = 1")
            End If

            dtCampos = sqlExecute("select upper(cod_campo) as campo,nombre,tipo FROM campos UNION select upper(campo),nombre,'char' as tipo from auxiliares")
            dtCampos.PrimaryKey = New DataColumn() {dtCampos.Columns("campo")}


            Campos = Split(IIf(IsDBNull(drInfoReporte("campos")), "", drInfoReporte("campos")), ",")
            Grupo1 = IIf(IsDBNull(drInfoReporte("grupo1")), "", drInfoReporte("grupo1").ToString.Trim)
            Grupo2 = IIf(IsDBNull(drInfoReporte("grupo2")), "", drInfoReporte("grupo2").ToString.Trim)
            Grupo3 = IIf(IsDBNull(drInfoReporte("grupo3")), "", drInfoReporte("grupo3").ToString.Trim)
            MostrarDetalle = IIf(IsDBNull(drInfoReporte("mostrar_detalle")), 0, drInfoReporte("mostrar_detalle"))
            MostrarResumen = IIf(IsDBNull(drInfoReporte("mostrar_resumen")), 0, drInfoReporte("mostrar_resumen"))

            'MCR 5/nov/2015
            'Revisar bitácora por cambios desde última actualización de datos
            ConsultaBitacora(dtResultado, UltimaActualizacion)

            Dim dtResultadoFiltro As New DataSet
            dtResultadoFiltro.Merge(dtResultado.Select(FiltroReporte))

            If dtResultadoFiltro.Tables.Count = 0 Then
                dtFiltroPersonal = New DataTable
            Else
                dtFiltroPersonal = dtResultadoFiltro.Tables(0)
                dtResultadoFiltro.Tables(0).TableName = "Personal"
                dtFiltroPersonal.DefaultView.Sort = OrdenReporte
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

            For Each dRow As DataRow In dtFiltroPersonal.Rows
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
                    dtDatos.Rows.Add({dRow("reloj"), Campos(x), Valor, G1, G2, G3})
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
            frmVistaPrevia.ShowDialog()

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
        Catch ex As Exception
            gpFiltros.Enabled = True
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
            btnBorrar.Visible = (t.Trim = "U" And (u.Trim = Usuario Or Perfil.ToUpper.Contains("ADMIN")))

            Dim Nombre As String = dgReportes.Item("nombre", dgReportes.CurrentCell.RowIndex).Value.ToString.Trim
            If Not Nombre.Contains("*") Then
                btnEditar.Visible = (t.Trim = "U" And (u.Trim = Usuario Or Perfil.ToUpper.Contains("ADMIN")))
            End If

        Catch ex As Exception
            btnBorrar.Visible = False
            btnEditar.Visible = False

            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            Dim Nombre As String
            Nombre = dgReportes.Item("nombre", dgReportes.CurrentCell.RowIndex).Value.ToString.Trim
            If MessageBox.Show("¿Está seguro de eliminar el reporte " & Nombre & "?", "Borrar reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                sqlExecute("DELETE FROM reportes WHERE nombre = '" & Nombre.Trim & "'")
                dgReportes.Rows.RemoveAt(dgReportes.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbTipoReportes_TextChanged(sender As Object, e As EventArgs) Handles cmbTipoReportes.TextChanged
        CargarReportes()
    End Sub

    Private Sub bgwReporte_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwReporte.DoWork
        Dim dtReporte As New DataTable
        Dim r As Integer
        'Dim i As Integer
        Dim Nombre As String
        Dim Reporte As String
        Dim Tipo As String
        Try
            r = dgReportes.CurrentCell.RowIndex
            If r < 0 Then Exit Sub
            Nombre = dgReportes.Item("nombre", r).Value
            Reporte = Nombre.Trim
            bgwReporte.ReportProgress(0, Nombre)

            Tipo = dgReportes.Item("tipo", r).Value

            sqlExecute("UPDATE reportes SET veces_acceso = veces_acceso + 1, fecha = GETDATE()   WHERE nombre = '" & Nombre.Trim & "'", "ta")

            dtTemporal = sqlExecute("SELECT COUNT(nombre) AS cuantos FROM reportes_recientes WHERE usuario = '" & Usuario & "'", "ta")
            If dtTemporal.Rows.Item(0).Item("cuantos") = 10 Then
                sqlExecute("DELETE FROM reportes_recientes WHERE fecha = (SELECT MIN(fecha) FROM reportes_recientes WHERE usuario = '" & Usuario & "') AND usuario = '" & Usuario & "'", "ta")
            End If

            dtTemporal = sqlExecute("SELECT nombre FROM reportes_recientes WHERE usuario = '" & Usuario & "' AND nombre = '" & Nombre.Trim & "'", "ta")
            If dtTemporal.Rows.Count > 0 Then
                sqlExecute("UPDATE reportes_recientes SET fecha = GETDATE() WHERE usuario = '" & Usuario & "' AND nombre = '" & Nombre.Trim & "'", "ta")
            Else
                sqlExecute("INSERT INTO reportes_recientes (usuario,fecha,nombre) VALUES ('" & Usuario & "',GETDATE(),'" & Nombre.Trim & "')", "ta")
            End If

            dtFiltroPersonal = dtResultado.Clone
            For Each dR As DataRow In dtResultado.Select(FiltroReporte, OrdenReporte)
                dtFiltroPersonal.ImportRow(dR)
            Next

            Dim I As Integer
            If FiltroReporte.Contains("COD_COMP") Then
                I = FiltroReporte.IndexOf("COD_COMP")
                CiaReporteador = FiltroReporte.Substring(I + 14, 3)
            Else
                CiaReporteador = ""
            End If
            If Tipo = "U" Then
                dtDisponibles = sqlExecute("(SELECT UPPER(cod_campo) AS campo,personal.dbo.IniciaMayuscula(nombre) AS nombre FROM campos UNION SELECT UPPER(campo),personal.dbo.IniciaMayuscula(nombre) AS nombre FROM auxiliares) ORDER BY nombre")
                ReporteadorFuente = "TAA"
                dtReporte = sqlExecute("SELECT * FROM reportes WHERE nombre = '" & Nombre & "'", "ta")
                If dtReporte.Rows.Count < 1 Then Exit Sub
                frmVistaPrevia.ReporteDinamico(dtReporte.Rows(0), dtFiltroPersonal, Nombre)
            Else
                frmVistaPrevia.LlamarReporte(Reporte, dtFiltroPersonal, CiaReporteador.Replace("''", ""))
                bgwReporte.ReportProgress(100)
                frmVistaPrevia.ShowDialog()
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub bgw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        'Dim drow As DataRow
        Try
            Dim ArchivoFoto As String = ""
            Dim dtTemp As New DataTable
            Dim dtDatosPersonal As New DataTable

            'MCR 28/OCT/2015
            'Tomar fecha/hora de última actualización de datos
            UltimaActualizacion = Now

            bgw.ReportProgress(0, "PREPARANDO" & vbCrLf & "DATOS")
            Application.DoEvents()
            dtDatosPersonal = sqlExecute("EXEC MaestroPersonal @Nivel = '" & NivelConsulta & "', @Reloj = ''")
            dtResultado = dtDatosPersonal.Clone
            dtResultado.PrimaryKey = New DataColumn() {dtResultado.Columns("reloj")}
            'frmTrabajando.Avance.IsRunning = True

            If dtDatosPersonal.Rows.Count = 0 Then
                Exit Sub
            End If

            Dim i As Integer = 0
            For Each dRow As DataRow In dtDatosPersonal.Select(FiltroXUsuario)
                bgw.ReportProgress(i, "Reloj " & dRow.Item("reloj"))
                Application.DoEvents()

                If dRow("nivel_seguridad") > NivelSueldos Then

                    dRow.Item("sactual") = 0
                    dRow.Item("integrado") = 0
                    dRow.Item("pro_var") = 0
                    dRow.Item("factor_int") = 0
                    dRow.Item("sal_ant") = 0
                End If
                dtResultado.ImportRow(dRow)
                i = i + 1
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub bgw_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgw.ProgressChanged
        Try
            If e.ProgressPercentage <> 0 Then
                pbAvance.IsRunning = False
                pbAvance.Value = e.ProgressPercentage
            End If
            lblAvance.Text = CType(e.UserState, String)
            lblAvance.Refresh()
        Catch ex As Exception
            lblAvance.Text = "ERROR"
        End Try
    End Sub

    Private Sub bgw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        pbAvance.IsRunning = False
        gpAvance.Visible = False

        gpControles.Enabled = True
        gpReportes.Enabled = True
        gpFiltros.Enabled = True
        gpOrden.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        BuscaReporte = EliminaAcentos(txtBusca.Text.Trim)
        CargarReportes()
    End Sub

    Private Sub dgReportes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReportes.CellContentClick

    End Sub

    Private Sub frmReporteador_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        gpAvance.Left = (Me.Width - gpAvance.Size.Width) / 2
        pnlCentrarControles.Left = (Me.Width - pnlCentrarControles.Size.Width) / 2
    End Sub
    Private Function ConsultaBitacora(ByVal dtTabla As DataTable, ByVal FechaTope As Date) As Boolean
        Dim dtPeriodos As New DataTable
        Dim dtBitacora As New DataTable
        Dim dRow As DataRow
        Dim Campo As String
        Dim T1 As String = ""
        Dim T2 As String = ""
        Dim i As Integer = 0
        Try
            dtBitacora = sqlExecute("SELECT RELOJ,CAMPO,VALORNUEVO FROM bitacora_personal WHERE cast(fecha as date) <= cast(getdate() as date) and fecha_mantenimiento >= '" & FechaHoraSQL(UltimaActualizacion, False, False) & "'")
            For Each dCol In dtBitacora.Rows
                Campo = dCol("campo").ToString.ToLower.Trim
                If dtTabla.Columns.Contains(dCol("campo").ToString.Trim) Then

                    dRow = dtTabla.Rows.Find(dCol("reloj"))
                    If Not dRow Is Nothing Then
                        'If dRow(Campo) <> dCol("VALORNUEVO") Then
						If IIf(IsDBNull(dRow(Campo)), "", dRow(Campo)) <> dCol("VALORNUEVO") Then
                            Select Case dtTabla.Columns(Campo).DataType
                                Case GetType(System.String)
                                    If Campo = "IMSS" Then
                                        'Si el campo es IMSS, separar dígito verificador
                                        '(bitácora los tiene juntos)
                                        i = dCol("VALORNUEVO").ToString.IndexOf("-")
                                        If i > 0 Then
                                            T1 = dCol("VALORNUEVO").ToString.Substring(0, i)
                                            T2 = dCol("VALORNUEVO").ToString.Substring(i + 1)
                                        Else
                                            i = dCol("VALORNUEVO").ToString.Trim.Length
                                            If i = 11 Then
                                                T1 = dCol("VALORNUEVO").ToString.Substring(0, 10)
                                                T2 = dCol("VALORNUEVO").ToString.Substring(10, 1)
                                            Else
                                                T1 = dCol("VALORNUEVO").ToString.Trim
                                                T2 = ""
                                            End If
                                        End If
                                        dRow("IMSS") = T1
                                        dRow("DIG_VER") = T2
                                    Else
                                        dRow(Campo) = dCol("VALORNUEVO").ToString.Trim
                                    End If
                                Case GetType(System.Boolean)
                                    dRow(Campo) = CInt(dCol("VALORNUEVO"))
                                Case Else
                                    dRow(Campo) = dCol("VALORNUEVO")
                            End Select

                            Select Case Campo
                                Case "cod_tipo"
                                    If dtTabla.Columns.IndexOf("nombre_tipoEmp") >= 0 Then
                                        dtTemp = sqlExecute("SELECT nombre FROM tipo_emp WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_tipo = '" & dRow(Campo) & "'")
                                        If dtTemp.Rows.Count > 0 Then
                                            dRow("nombre_tipoEmp") = dtTemp.Rows(0).Item("nombre")
                                        Else
                                            dRow("nombre_tipoEmp") = ""
                                        End If
                                    End If
                                Case "cod_clase"
                                    If dtTabla.Columns.IndexOf("nombre_clase") >= 0 Then
                                        dtTemp = sqlExecute("SELECT nombre FROM clase WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_clase = '" & dRow(Campo) & "'")
                                        If dtTemp.Rows.Count > 0 Then
                                            dRow("nombre_clase") = dtTemp.Rows(0).Item("nombre")
                                        Else
                                            dRow("nombre_clase") = ""
                                        End If
                                    End If
                                Case "cod_comp"
                                    If dtTabla.Columns.IndexOf("compania") >= 0 Then
                                        dtTemp = sqlExecute("SELECT nombre FROM cias WHERE cod_comp = '" & dRow("cod_comp") & "'")
                                        If dtTemp.Rows.Count > 0 Then
                                            dRow("compania") = dtTemp.Rows(0).Item("nombre")
                                        Else
                                            dRow("compania") = ""
                                        End If
                                    End If
                                Case "cod_area"
                                    If dtTabla.Columns.IndexOf("nombre_area") >= 0 Then
                                        dtTemp = sqlExecute("SELECT nombre FROM areas WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_area = '" & dRow(Campo) & "'")
                                        If dtTemp.Rows.Count > 0 Then
                                            dRow("nombre_area") = dtTemp.Rows(0).Item("nombre")
                                        Else
                                            dRow("nombre_area") = ""
                                        End If
                                    End If
                                Case "cod_depto"
                                    If dtTabla.Columns.IndexOf("nombre_depto") >= 0 Then
                                        dtTemp = sqlExecute("SELECT nombre FROM deptos WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_depto = '" & dRow(Campo) & "'")
                                        If dtTemp.Rows.Count > 0 Then
                                            dRow("nombre_depto") = dtTemp.Rows(0).Item("nombre")
                                        Else
                                            dRow("nombre_depto") = ""
                                        End If
                                    End If
                                Case "cod_super"
                                    If dtTabla.Columns.IndexOf("nombre_super") >= 0 Then
                                        dtTemp = sqlExecute("SELECT nombre FROM super WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_super = '" & dRow(Campo) & "'")
                                        If dtTemp.Rows.Count > 0 Then
                                            dRow("nombre_super") = dtTemp.Rows(0).Item("nombre")
                                        Else
                                            dRow("nombre_super") = ""
                                        End If
                                    End If
                                Case "cod_planta"
                                    If dtTabla.Columns.IndexOf("nombre_planta") >= 0 Then
                                        dtTemp = sqlExecute("SELECT nombre FROM plantas WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_planta = '" & dRow(Campo) & "'")
                                        If dtTemp.Rows.Count > 0 Then
                                            dRow("nombre_planta") = dtTemp.Rows(0).Item("nombre")
                                        Else
                                            dRow("nombre_planta") = ""
                                        End If
                                    End If
                                Case "cod_turno"
                                    If dtTabla.Columns.IndexOf("nombre_turno") >= 0 Then
                                        dtTemp = sqlExecute("SELECT nombre FROM turnos WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_turno = '" & dRow(Campo) & "'")
                                        If dtTemp.Rows.Count > 0 Then
                                            dRow("nombre_turno") = dtTemp.Rows(0).Item("nombre")
                                        Else
                                            dRow("nombre_turno") = ""
                                        End If
                                    End If
                                Case "cod_puesto"
                                    If dtTabla.Columns.IndexOf("nombre_puesto") >= 0 Then
                                        dtTemp = sqlExecute("SELECT nombre FROM puestos WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_puesto = '" & dRow(Campo) & "'")
                                        If dtTemp.Rows.Count > 0 Then
                                            dRow("nombre_puesto") = dtTemp.Rows(0).Item("nombre")
                                        Else
                                            dRow("nombre_puesto") = ""
                                        End If
                                    End If
                                Case "cod_hora"
                                    If dtTabla.Columns.IndexOf("nombre_horario") >= 0 Then
                                        dtTemp = sqlExecute("SELECT nombre FROM horarios WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_hora = '" & dRow(Campo) & "'")
                                        If dtTemp.Rows.Count > 0 Then
                                            dRow("nombre_horario") = dtTemp.Rows(0).Item("nombre")
                                        Else
                                            dRow("nombre_horario") = ""
                                        End If
                                    End If
                            End Select
                        End If
                    End If
                End If
            Next

            'MCR 28/OCT/2015
            'Tomar fecha/hora de última actualización de datos
            UltimaActualizacion = Now


            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            Dim Nombre As String
            Nombre = dgReportes.Item("nombre", dgReportes.CurrentCell.RowIndex).Value.ToString.Trim
            frmCrearReporteDinamico.reporte_edicion = Nombre
            btnNuevo.PerformClick()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub lstFiltros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFiltros.SelectedIndexChanged

    End Sub

    Private Sub gpFiltros_Click(sender As Object, e As EventArgs) Handles gpFiltros.Click

    End Sub
End Class