
Imports Microsoft.Reporting.WinForms
Imports System.Xml
Public Class frmReporteadorUniformes
    Dim dtReportes As New DataTable
    Dim Acumulado As String
    Public AmbitoUniformes As String
    Dim NombreReporte As String = ""
    Dim BuscaReporte As String = ""
    Private Function FiltrosAcumulados() As String
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
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
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
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
        Return FL
    End Function
    Private Sub frmReporteadorUniformes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmbTipoReportes.DataSource = sqlExecute("SELECT tipo,nombre FROM tipo_reportes where tipo='N' ", "HERRAMIENTAS")
            cmbTipoReportes.SelectedValue = "N"
            chkRecientes.Text = "Ver últimos 10 reportes utilizados por el usuario " & Usuario.ToUpper
            chkRecientes.Checked = False
            txtActivos.Value = Today
            txtBajas.Value = Today
            Acumulado = FiltrosAcumulados()
            'Dim drow As DataRow
            Dim ArchivoFoto As String = ""
            Dim dtTemp As New DataTable
            '   Ambito = IIf(cmbTipoReportes.SelectedValue.Equals("N") Or cmbTipoReportes.SelectedValue.Equals("F") Or cmbTipoReportes.SelectedValue.Equals("X"), "UniformesEmpleadosVW", "ArticulosEmpleadosVW")
            '   Ambito2 = IIf(cmbTipoReportes.SelectedValue.Equals("N") Or cmbTipoReportes.SelectedValue.Equals("F") Or cmbTipoReportes.SelectedValue.Equals("X"), "UNIFORME", "ARTICULO")

            AmbitoUniformes = "UniformesEmpleadosVW"

            frmTrabajando.Show(Me)
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Text = "Preparando datos..."
            Application.DoEvents()
            '  dtResultado = sqlExecute("SELECT " & IIf(Ambito.Equals("UniformesEmpleadosVW"), "COD_UNIF", "COD_ART") & " as 'Código'," & Ambito2 & "  AS 'Producto'," & Ambito & ".* FROM " & Ambito & "", "HERRAMIENTAS")
            dtResultado = sqlExecute("SELECT COD_UNIF as Código, UNIFORME as 'Producto', UniformesEmpleadosVW.* FROM UniformesEmpleadosVW", "HERRAMIENTAS")

            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            chkActivos.Checked = True
            FiltroActivos()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)

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
                    "reportes.nombre = reportes_recientes.nombre LEFT JOIN SEGURIDAD.dbo.permisos ON " & _
                    "reportes.nombre = permisos.control WHERE reportes_recientes.usuario = '" & _
                    Usuario & "' AND " & IIf(FiltrarTipo, " reportes.tipo='" & cmbTipoReportes.SelectedValue & "' AND ", "") & _
                    " cod_perfil " & Perfil & " AND permisos.modulo = 'HER'  and permisos.acceso = 1 " & _
                    IIf(BuscaReporte.Length = 0, "", " AND reportes.nombre LIKE '%" & BuscaReporte & "%' ") & _
                    "ORDER BY reportes_recientes.fecha DESC,nombre"
            Else
                Cadena = "SELECT RTRIM(reportes.NOMBRE) AS NOMBRE,reportes.TIPO," & _
                    "(100*VECES_ACCESO)/((SELECT MAX(veces_acceso) FROM reportes)+1) AS 'Frecuencia',reportes.FECHA,FILTRAR,username " & _
                    "FROM REPORTES  LEFT JOIN SEGURIDAD.dbo.permisos ON reportes.nombre = permisos.control WHERE " & _
                    IIf(FiltrarTipo, " reportes.tipo='" & cmbTipoReportes.SelectedValue & "' AND ", "") & " cod_perfil " & Perfil & _
                    IIf(BuscaReporte.Length = 0, "", " AND reportes.nombre LIKE '%" & BuscaReporte & "%' ") & _
                    " AND permisos.modulo = 'HER' and permisos.acceso = 1 ORDER BY reportes.nombre"
            End If
            dtReportes = New DataTable
            dtReportes = sqlExecute(Cadena, "HERRAMIENTAS")
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
            Dim x As Integer
            '   frmFiltroH.ShowDialog(Me)
            frmFiltroUniformes.ShowDialog(Me)
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

    Private Sub txtActivos_Validated(sender As Object, e As EventArgs) Handles txtActivos.Validated
        FiltroActivos()
    End Sub
    Private Sub FiltroActivos()
        Try
            Dim Filtro As String
            Dim I As Integer = -1
            If chkActivos.Checked Then
                'chkBajas.Checked = False
                'txtActivos.Focus()
                Filtro = " ALTA <= '" & FechaSQL(txtActivos.Value) & "' AND (BAJA IS NULL OR BAJA > '" & FechaSQL(txtActivos.Value) & "')"
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

            AmbitoUniformes = "UniformesEmpleadosVW"


            '  dtResultado = sqlExecute("SELECT " & IIf(Ambito.Equals("UniformesEmpleadosVW"), "COD_UNIF", "COD_ART") & " as 'Código'," & Ambito2 & "  AS 'Producto'," & Ambito & ".* FROM " & Ambito & "", "HERRAMIENTAS")
            dtResultado = sqlExecute("SELECT COD_UNIF as Código, UNIFORME as 'Producto', UniformesEmpleadosVW.* FROM UniformesEmpleadosVW", "HERRAMIENTAS")

            ' ----Para tomar el filtro de otra tabla
            If ((Nombre = "Empleados sin uniforme asignado") Or (Nombre = "Reporte de entrega de uniformes por antiguedad")) Then
                '  Ambito = "personalvw"
                AmbitoUniformes = "personalvw"
                dtResultado = sqlExecute("select * from PERSONAL.dbo.personalvw ")
            End If


            sqlExecute("UPDATE reportes SET veces_acceso = veces_acceso + 1, fecha = GETDATE()   WHERE nombre = '" & Nombre.Trim & "'", "HERRAMIENTAS")
            dtTemporal = sqlExecute("SELECT COUNT(nombre) AS cuantos FROM reportes_recientes WHERE usuario = '" & Usuario & "'", "HERRAMIENTAS")
            If dtTemporal.Rows.Item(0).Item("cuantos") = 10 Then
                sqlExecute("DELETE FROM reportes_recientes WHERE fecha = (SELECT MIN(fecha) FROM reportes_recientes WHERE usuario = '" & Usuario & "') AND usuario = '" & Usuario & "'", "HERRAMIENTAS")
            End If
            dtTemporal = sqlExecute("SELECT * FROM reportes_recientes WHERE usuario = '" & Usuario & "' AND nombre = '" & Nombre.Trim & "'", "HERRAMIENTAS")
            If dtTemporal.Rows.Count > 0 Then
                sqlExecute("UPDATE reportes_recientes SET fecha = GETDATE() WHERE usuario = '" & Usuario & "' AND nombre = '" & Nombre.Trim & "'", "HERRAMIENTAS")
            Else
                sqlExecute("INSERT INTO reportes_recientes (usuario,fecha,nombre) VALUES ('" & Usuario & "',GETDATE(),'" & Nombre.Trim & "')", "HERRAMIENTAS")
            End If
            FiltroReporte = FiltrosAcumulados()
            OrdenReporte = OrdenAcumulado()

            EncabezadoReporte = DeterminaEncabezado(FiltroReporte, "FECHA_ENT")
            EncabezadoReporte = EncabezadoReporte & IIf(EncabezadoReporte.Length = 0, "", vbCrLf) & DeterminaEncabezado(FiltroReporte, "FECHA_SAL")
            EncabezadoReporte = EncabezadoReporte & IIf(EncabezadoReporte.Length = 0, "", vbCrLf) & DeterminaEncabezado(FiltroReporte, "FECHA_DEV")

            Dim dtResultadoFiltro As New DataSet
            dtResultadoFiltro.Merge(dtResultado.Select(FiltroReporte))
            If dtResultadoFiltro.Tables.Count = 0 Then
                dtFiltroPersonal = New DataTable
            Else
                dtFiltroPersonal = dtResultadoFiltro.Tables(0)
                Select Case Nombre
                    Case "Reporte de entrega de uniformes por antiguedad", "Reporte de entrega uniformes por antig_resumen", "Empleados sin uniforme asignado"
                        dtResultadoFiltro.Tables(0).TableName = "personalvw"
                    Case Else
                        dtResultadoFiltro.Tables(0).TableName = "Herramientas"
                End Select
                dtFiltroPersonal.DefaultView.Sort = OrdenReporte
            End If
            frmVistaPrevia.LlamarReporte(Nombre, dtFiltroPersonal)
            frmVistaPrevia.ShowDialog()
            'If Tipo = "F" Then
            '    dtDisponibles = sqlExecute("SELECT UPPER(COD_CAMPO) AS campo,personal.dbo.IniciaMayuscula(NOMBRE) AS nombre,TIPO FROM campos " & _
            '                               "WHERE TABLA IS NULL OR TABLA = '" & Ambito & "'", "HERRAMIENTAS")
            '    ReporteadorFuente = "HERRAMIENTAS"
            '    dtReporte = sqlExecute("SELECT * FROM reportes WHERE NOMBRE = '" & Nombre & "'", "HERRAMIENTAS")
            '    If dtReporte.Rows.Count < 1 Then Exit Sub
            '    frmVistaPrevia.ReporteDinamico(dtReporte.Rows(0), dtFiltroPersonal, Nombre)
            'ElseIf Tipo = "R" Then
            '    dtDisponibles = sqlExecute("SELECT UPPER(COD_CAMPO) AS campo,personal.dbo.IniciaMayuscula(NOMBRE) AS nombre,TIPO FROM campos " & _
            '                               "WHERE TABLA IS NULL OR TABLA = '" & Ambito & "'", "HERRAMIENTAS")
            '    ReporteadorFuente = "HERRAMIENTAS"
            '    dtReporte = sqlExecute("SELECT * FROM reportes WHERE NOMBRE = '" & Nombre & "'", "HERRAMIENTAS")
            '    If dtReporte.Rows.Count < 1 Then Exit Sub
            '    frmVistaPrevia.ReporteDinamico(dtReporte.Rows(0), dtFiltroPersonal, Nombre)
            'Else
            '    frmVistaPrevia.LlamarReporte(Nombre, dtFiltroPersonal)
            '    frmVistaPrevia.ShowDialog()
            'End If
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

    Private Function DeterminaEncabezado(ByVal FiltroReporte As String, ByVal CampoFecha As String) As String
        Dim a As Integer
        Dim b As Integer
        Dim c As String = ""
        Dim fi As String
        Dim ff As String
        Dim Descripcion As String

        Try
            Select Case CampoFecha
                Case "FECHA_ENT"
                    Descripcion = "FECHA DE REEMPLAZO"
                Case "FECHA_DEV"
                    Descripcion = "FECHA DE DEVOLUCIÓN"
                Case "FECHA_SAL"
                    Descripcion = "FECHA DE PRÉSTAMO"
                Case Else
                    Descripcion = CampoFecha
            End Select

            If FiltroReporte.Contains(CampoFecha) Then
                a = FiltroReporte.IndexOf(CampoFecha)
                b = FiltroReporte.IndexOf(")", a)
                If a > 5 Then
                    c = FiltroReporte.Substring(a - 5, 5)
                Else
                    c = ""
                End If
                If c.Contains("NOT") Then
                    c = FiltroReporte.Substring(a, b - a)
                    If c.Contains("NULL") Then
                        c = Descripcion & " NO EN BLANCO"
                    Else
                        c = FiltroReporte.Substring(a, b - a)
                        a = c.IndexOf("'")
                        b = c.IndexOf("'", a + 1)
                        fi = FechaCortaLetra(c.Substring(a + 1, b - a - 1))

                        a = c.IndexOf("'", b + 1)
                        b = c.IndexOf("'", a + 1)
                        ff = FechaCortaLetra(c.Substring(a + 1, b - a - 1))
                        c = Descripcion & " NO ENTRE " & fi & " Y " & ff

                    End If

                Else
                    c = FiltroReporte.Substring(a, b - a)
                    If c.Contains("NULL") Then
                        c = Descripcion & " EN BLANCO"
                    Else
                        a = c.IndexOf("'")
                        b = c.IndexOf("'", a + 1)
                        fi = FechaCortaLetra(c.Substring(a + 1, b - a - 1))

                        a = c.IndexOf("'", b + 1)
                        b = c.IndexOf("'", a + 1)
                        ff = FechaCortaLetra(c.Substring(a + 1, b - a - 1))

                        c = Descripcion & " " & fi & " AL " & ff
                    End If
                End If
            End If
            Return c

        Catch ex As Exception
            Return ""
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Function

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
        Dim r As Boolean, n As Boolean
        Dim i As Integer
        ' Dim TipoOrden As String
        Try
            frmOrdenH.ShowDialog()
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
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
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

            'Inicializar datos de campos antes de iniciar
            dtDisponibles = New DataTable
            dtDisponibles = sqlExecute("SELECT UPPER(COD_CAMPO) AS 'campo',personal.dbo.IniciaMayuscula(NOMBRE) AS 'nombre' FROM campos WHERE TABLA IS NULL  OR TABLA = '" & AmbitoUniformes & "' ORDER BY nombre", "HERRAMIENTAS")
            ReporteadorFuente = "HERRAMIENTAS"
            ' ABRAHAM COMENTO ESTO PORQUE MARCABA ERROR
            Stop
            'frmCrearReporteDinamico.ShowDialog()

            'Revisar si se seleccionó CANCELAR
            If dtReporteDinamico.Columns.Count = 0 Then Exit Sub
            drInfoReporte = dtReporteDinamico.Rows(0)
            dtReportes.ImportRow(drInfoReporte)
            dtReportes.AcceptChanges()
            Titulo = drInfoReporte("nombre")
            FiltroReporte = FiltrosAcumulados()
            OrdenReporte = OrdenAcumulado()

            sqlExecute("UPDATE reportes SET TIPO='" & IIf(cmbTipoReportes.SelectedValue.Equals("N") Or cmbTipoReportes.SelectedValue.Equals("F"), "F", "R") & _
                  "' WHERE TIPO ='U' AND nombre = '" & Titulo & "'", "HERRAMIENTAS")

            If FiltroReporte.ToUpper.Contains("COD_COMP") Then
                'Si no se incluye filtro, tomar el primero de la tabla
                i = FiltroReporte.ToUpper.IndexOf("COD_COMP")
                f = FiltroReporte.ToUpper.IndexOf(")", i)

                c = FiltroReporte.ToUpper.Substring(i, f - i + 1)

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
            If t.Trim = "R" And u.Trim = Usuario Then
                btnBorrar.Visible = True
            ElseIf t.Trim = "U" And u.Trim = Usuario Then
                btnBorrar.Visible = True
            ElseIf t.Trim = "F" And u.Trim = Usuario Then
                btnBorrar.Visible = True
            Else
                btnBorrar.Visible = False
            End If
        Catch ex As Exception
            btnBorrar.Visible = False
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            NombreReporte = dgReportes.Item("nombre", dgReportes.CurrentCell.RowIndex).Value.ToString.Trim
            If MessageBox.Show("¿Está seguro de eliminar el reporte " & NombreReporte & "?", "Borrar reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                sqlExecute("DELETE FROM reportes WHERE nombre = '" & NombreReporte.Trim & "'", "HERRAMIENTAS")
                dgReportes.Rows.RemoveAt(dgReportes.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub cmbTipoReportes_TextChanged(sender As Object, e As EventArgs) Handles cmbTipoReportes.TextChanged
        AmbitoUniformes = "UniformesEmpleadosVW"
        chkTodos.Checked = True
        dtResultado = sqlExecute("SELECT " & IIf(AmbitoUniformes.Equals("UniformesEmpleadosVW"), "COD_UNIF", "COD_ART") & " as 'Código', Uniforme  AS 'Producto'," & AmbitoUniformes & ".* FROM " & AmbitoUniformes & "", "HERRAMIENTAS")
        CargarReportes()
    End Sub


    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        BuscaReporte = EliminaAcentos(txtBusca.Text.Trim)
        CargarReportes()
    End Sub

    Private Sub frmReporteadorUniformes_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlCentrarControles.Left = (Me.Width - pnlCentrarControles.Size.Width) / 2
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class