Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style

Public Class frmRevisionPrestamos

    Dim Agregar As Boolean
    Dim dtInfoPersonal As New DataTable
    Dim dtTemp As New DataTable
    Dim dtCias As New DataTable
    Dim dtSolicitudes As New DataTable
    Dim dtSol As New DataTable
    Dim TotalSemanas As Integer
    Dim Cargando As Boolean = True
    Dim PeriodoActual As String = ""
    Dim SolicitudReloj As String
    Dim SolicitudFecha As String
    Dim SolicitudEstado As Integer
    Dim InicioPrestamosStr As String

    Private _MyFont As New Font(SystemFonts.StatusFont, FontStyle.Bold)
    Private _BackColor As Background() = {New Background(Color.MistyRose), _
    New Background(Color.FromArgb(&HE5, &HFF, &HDD)), New Background(Color.AliceBlue)}


#Region "Combos"

    ''' <summary>
    ''' Clase para crear combo con motivos de préstamo
    ''' </summary>
    Public Class ComboBoxMotivo
        Inherits GridComboBoxExEditControl
        Public Sub New()
            Dim dtMotivo As New DataTable
            dtMotivo = sqlExecute("SELECT DISTINCT RTRIM(motivo_pmo) as campo FROM sol_prestamos", "nomina")
            For Each name As DataRow In dtMotivo.Rows
                If name IsNot Nothing Then
                    Items.Add(name("campo"))
                End If
            Next name
        End Sub
    End Class

    ''' <summary>
    ''' Clase para crear combo con números de reloj
    ''' </summary>
    Public Class ComboBoxReloj
        Inherits GridComboBoxExEditControl
        Public Sub New()
            Dim dtMotivo As New DataTable
            dtMotivo = sqlExecute("SELECT DISTINCT RTRIM(reloj) as campo FROM sol_prestamos", "nomina")
            For Each name As DataRow In dtMotivo.Rows
                If name IsNot Nothing Then
                    Items.Add(name("campo"))
                End If
            Next name
        End Sub
    End Class

    ''' <summary>
    ''' Clase para crear combo con usuarios que capturan...
    ''' </summary>
    Public Class ComboBoxCapturado
        Inherits GridComboBoxExEditControl
        Public Sub New()
            Dim dtMotivo As New DataTable
            dtMotivo = sqlExecute("SELECT DISTINCT RTRIM(usuario) as campo FROM sol_prestamos", "nomina")
            For Each name As DataRow In dtMotivo.Rows
                If name IsNot Nothing Then
                    Items.Add(name("campo"))
                End If
            Next name
        End Sub
    End Class

    ''' <summary>
    ''' Clase para crear combo con usuarios que revisan...
    ''' </summary>
    Public Class ComboBoxRevisado
        Inherits GridComboBoxExEditControl
        Public Sub New()
            Dim dtMotivo As New DataTable
            dtMotivo = sqlExecute("SELECT DISTINCT RTRIM(usuario_revision) as campo FROM sol_prestamos", "nomina")
            For Each name As DataRow In dtMotivo.Rows
                If name IsNot Nothing Then
                    Items.Add(name("campo"))
                End If
            Next name
        End Sub
    End Class

#End Region

    Private Sub frmRevisionPrestamos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim R As String
        Dim F As Date
        Dim A As Integer
        Dim B As Integer
        Dim M As String
        Try
            For Each dRow As DataRow In dtSolicitudes.Rows
                R = dRow("reloj")
                F = dRow("fecha")
                A = IIf(IsDBNull(dRow("aprobada")), 0, 1)
                If A = 1 Then
                    'Si A = 1, simplemente no es nulo, entonces revisar el valor en la tabla dtSolicitudes
                    A = IIf(dRow("aprobada") = 0, 2, 1)
                End If
                M = IIf(IsDBNull(dRow("motivo_rechazo")), "", dRow("motivo_rechazo"))

                dtTemp = sqlExecute("SELECT MIN(aprobada) as aprobada FROM sol_prestamos WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(F) & "'", "nomina")
                If dtTemp.Rows.Count = 0 Then
                    MessageBox.Show("No se encontró el registro " & R & " " & F & " en la tabla de préstamos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    B = IIf(IsDBNull(dtTemp.Rows(0).Item("aprobada")), 0, dtTemp.Rows(0).Item("aprobada"))
                End If

                If B <> A Then
                    'Si hubo algún cambio en el estado de la solicitud
                    sqlExecute("UPDATE sol_prestamos SET aprobada = " & A & ", motivo_rechazo = '" & M & _
                               "', usuario_revision = '" & Usuario & "', fecha_revision = '" & FechaHoraSQL(Now) & _
                               "' WHERE reloj = '" & R & "' AND fecha = '" & FechaSQL(F) & "'", "nomina")
                End If
            Next

        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Stop
        End Try
    End Sub

    Private Sub frmRevisionPrestamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim InicioAhorroStr As String
        Dim FinAhorroStr As String
        Dim Permitir As Boolean
        Dim Valido As Boolean = True


        btnExportar.Left = btnLimpiar.Left + 20
        btnLimpiar.Left = btnBuscar.Left - 20
        tabPrestamos.SelectedTabIndex = 0

        'Buscar el máximo periodo cargado en nómina
        dtTemp = sqlExecute("SELECT TOP 1 ano+periodo as ultimo FROM nomina WHERE periodo<'55' ORDER BY ano DESC,periodo DESC", "nomina")
        If dtTemp.Rows.Count = 0 Then
            MessageBox.Show("No se localizaron registros en nómina, y no es posible capturar préstamos sin esta información. Contactar con el departamento de nóminas.", "No hay registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Valido = False
        Else
            PeriodoActual = IIf(IsDBNull(dtTemp.Rows(0).Item("ultimo")), "", dtTemp.Rows(0).Item("ultimo"))

            dtTemp = sqlExecute("SELECT DISTINCT ano,periodo FROM sol_prestamos WHERE (exportada = 0 OR exportada IS NULL) ", "Nomina")
            If dtTemp.Rows.Count > 1 Then
                MessageBox.Show("Se localizaron registros de diferentes periodos aún pendientes de exportar. " & _
                                "Favor de contactar al administrador del sistema.", "Varios periodos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Valido = False
            End If
        End If
        tabTabla.Text = "CONSULTA" & vbCrLf & Year(Now).ToString.Trim

        'Obtener información de la compañía
        dtCias = sqlExecute("SELECT SEMANA_INICIO_PRESTAMOS,PERMITIR_PRESTAMOS,SEMANA_FIN_FONDO_AHORRO,SEMANA_INICIO_FONDO_AHORRO " & _
                            "FROM parametros")

        '** cada año se cambia el primer factor de la siguiente formula, debe ser la primer semana
        '** en que se van a CAPTURAR prestamos EJ. Año 2011 Viviendo Semana 4 
        InicioPrestamosStr = IIf(IsDBNull(dtCias.Rows(0).Item("semana_inicio_prestamos")), "      ", dtCias.Rows(0).Item("semana_inicio_prestamos"))
        InicioAhorroStr = IIf(IsDBNull(dtCias.Rows(0).Item("SEMANA_INICIO_FONDO_AHORRO")), "      ", dtCias.Rows(0).Item("SEMANA_INICIO_FONDO_AHORRO"))
        FinAhorroStr = IIf(IsDBNull(dtCias.Rows(0).Item("SEMANA_FIN_FONDO_AHORRO")), "      ", dtCias.Rows(0).Item("SEMANA_FIN_FONDO_AHORRO"))
        Permitir = IIf(IsDBNull(dtCias.Rows(0).Item("PERMITIR_PRESTAMOS")), 0, dtCias.Rows(0).Item("PERMITIR_PRESTAMOS")) = 1

        If Not Permitir Then
            'Cuando se genera archivo de préstamos, se bloquea la captura
            'Al cargar información de nómina, se vuelve a permitir capturar préstamos
            'Desde compañías, pueden activar/desactivar conforme se requiera
            MessageBox.Show("Por el momento, no se permite capturar préstamos. Si considera que es un error, consulte al departamento de nóminas.", "No permitir préstamos", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Valido = False
        End If

        dgAprobacion.Enabled = Valido
        btnTodos.IsReadOnly = Not Valido

        ActualizaDatos()

    End Sub

    Private Sub ActualizaDatos()
        'En la tabla y en el checkbox, la columna APROBADA es diferente, porque en la tabla es parte del índice, y no puede ser NULL
        'en el checkbox, en cambio, debe ser NULL para que pueda ser indeterminado, por tanto
        'TABLA  CHECKBOX    ESTADO
        '2      0           rechazado
        '1      1           aprobado
        '0      NULL        pendiente
        dtSolicitudes = sqlExecute("SELECT reloj,fecha,cantidad_sol,cantidad_pag,descuento_sem,semanas_pag," & _
                                   "RTRIM(motivo_pmo) AS motivo_pmo,(CASE aprobada WHEN 0 THEN NULL WHEN 1 THEN 1 ELSE 0 END) AS aprobada,'' AS motivo_rechazo " & _
                                   "FROM sol_prestamos WHERE ano + periodo >= '" & InicioPrestamosStr & _
                                   "' AND (exportada = 0 OR exportada IS NULL) ORDER BY aprobada,fecha,reloj ", "nomina")

        dgAprobacion.DataSource = dtSolicitudes
        AddRows()
        dgAprobacion.Refresh()
    End Sub

    Private Sub AddRows()
        Try
            dtSol = sqlExecute("SELECT RTRIM(reloj) AS reloj,periodo,ano,fecha,cantidad_sol,cantidad_pag,porciento,descuento_sem,semanas_pag," & _
                                  "RTRIM(motivo_pmo) AS motivo_pmo,aprobada,motivo_rechazo,usuario,usuario_revision,fecha_revision," & _
                                  "(CASE aprobada WHEN 0 THEN 'PENDIENTE' WHEN 2 THEN 'RECHAZADO' ELSE 'APROBADO' END) as estado " & _
                                  "FROM sol_prestamos WHERE ano = '" & Year(Now.Date) & "' ORDER BY ano DESC,periodo DESC,aprobada,reloj", "nomina")

            Dim panel As GridPanel = dgSuperPrestamos.PrimaryGrid

            dgSuperPrestamos.BeginUpdate()
            dgSuperPrestamos.PrimaryGrid.Rows.Clear()

            For Each dRow As DataRow In dtSol.rows
                Dim Info() As Object = {dRow("ano"), dRow("periodo"), dRow("reloj"), dRow("fecha"), dRow("cantidad_sol"), _
                                       dRow("cantidad_pag"), dRow("porciento"), dRow("semanas_pag"), dRow("descuento_sem"), dRow("estado"), dRow("motivo_pmo").ToString.Trim, _
                                       dRow("usuario"), dRow("usuario_revision"), dRow("fecha_revision"), dRow("motivo_rechazo").ToString.Trim}
                panel.Rows.Add(New GridRow(Info))
            Next

            panel.Columns("Motivo").EditorType = GetType(ComboBoxMotivo)
            panel.Columns("Reloj").EditorType = GetType(ComboBoxReloj)
            panel.Columns("Capturado por").EditorType = GetType(ComboBoxCapturado)
            panel.Columns("Revisado por").EditorType = GetType(ComboBoxRevisado)
            panel.Columns("estado").EditorType = GetType(GridImageCombo)
            panel.Columns("estado").EditorParams = New Object() {imgEstados, imgEstados.Images(0).Height}

            dgSuperPrestamos.EndUpdate()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtTemp = dtInfoPersonal
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                For Each dR As System.Windows.Forms.DataGridViewRow In dgAprobacion.Rows
                    If dR.Cells(0).Value.ToString.Trim = Reloj Then
                        dR.Selected = True
                    End If
                    Debug.Print(1)
                Next
                ' MostrarInformacion(Reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            dtInfoPersonal = dtTemp
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Dim dtInfo As New DataTable

            If tabPrestamos.SelectedTabIndex = 1 Then
                Dim Par As OrdenFiltro
                Dim dtResultadoFiltro As New DataSet
                dtSol = sqlExecute("SELECT RTRIM(reloj) AS reloj,periodo,ano,fecha,cantidad_sol,cantidad_pag,porciento,descuento_sem,semanas_pag," & _
                                "RTRIM(motivo_pmo) AS motivo_pmo,aprobada,motivo_rechazo,usuario,usuario_revision,fecha_revision," & _
                                "(CASE aprobada WHEN 0 THEN 'PENDIENTE' WHEN 2 THEN 'RECHAZADO' ELSE 'APROBADO' END) as estado " & _
                                "FROM sol_prestamos WHERE ano = '" & Year(Now.Date) & "' ORDER BY ano DESC,periodo DESC,aprobada,reloj", "nomina")

                Par = CadenaFiltro(dtSol, dgSuperPrestamos)
                dtResultadoFiltro.Merge(dtSol.Select(Par.Filtro, Par.Orden))

                If dtResultadoFiltro.Tables.Count = 0 Then
                    dtInfo = New DataTable
                Else
                    dtInfo = dtResultadoFiltro.Tables(0)
                    dtResultadoFiltro.Tables(0).TableName = "Filtro"
                End If
                EncabezadoReporte = "CONSULTA GENERAL"
            Else
                EncabezadoReporte = "PENDIENTES DE PROCESAR"
                dtInfo = dtSolicitudes.Copy
                dtInfo.Columns.Add("periodo")
                dtInfo.Columns.Add("ano")
            End If


            Dim A As Integer

           
            dtInfo.Columns.Add("nombres")
            dtInfo.Columns.Add("cod_depto")
            dtInfo.Columns.Add("cod_turno")
            dtInfo.Columns.Add("intereses", GetType(System.Double))
            dtInfo.Columns.Add("abono_pmo", GetType(System.Double))
            dtInfo.Columns.Add("abono_int", GetType(System.Double))
            For Each dR As DataRow In dtInfo.Rows
                dtTemp = sqlExecute("SELECT nombres,cod_depto,cod_turno from personalvw WHERE reloj = '" & dR("reloj") & "'")
                If dtTemp.Rows.Count > 0 Then
                    dR("nombres") = dtTemp.Rows(0).Item("nombres")
                    dR("cod_depto") = dtTemp.Rows(0).Item("cod_depto")
                    dR("cod_turno") = dtTemp.Rows(0).Item("cod_turno")
                End If
                'If dR("reloj") = "12105" Then Stop

                A = IIf(IsDBNull(dR("aprobada")), 0, 1)
                If A = 1 Then
                    'Si A = 1, simplemente no es nulo, entonces revisar el valor en la tabla dtSolicitudes
                    'A = IIf(dR("aprobada") = 0, 2, 1)
                    A = dR("aprobada")
                End If
                dR("aprobada") = A
                dR("ano") = PeriodoActual.Substring(0, 4)
                dR("periodo") = PeriodoActual.Substring(4, 2)
                dR("intereses") = RoundUp(dR("cantidad_pag") - dR("cantidad_sol"), 2)
                dR("abono_pmo") = RoundUp(IIf(dR("semanas_pag") = 0, 0, dR("cantidad_sol") / dR("semanas_pag")), 2)
                dR("abono_int") = RoundUp(IIf(dR("semanas_pag") = 0, 0, dR("cantidad_pag") / dR("semanas_pag")), 2)
            Next
            frmVistaPrevia.LlamarReporte("Préstamos a exportar", dtInfo)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            MessageBox.Show("Hubo un error durante la generación del reporte." & _
                               vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub dgAprobacion_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgAprobacion.CellMouseUp
        Dim Motivo As String
        Try
            'Si no está en la columna de aprobación, salir
            If dgAprobacion.CurrentCell.OwningColumn.Name <> "ColRevAprobada" Then Exit Sub
            'Solo continuar si se selecciona rechazar
            If IIf(IsDBNull(dgAprobacion.CurrentCell.Value), 1, dgAprobacion.CurrentCell.Value) > 0 Then Exit Sub

            'Si se rechaza, preguntar el motivo
            Motivo = InputBox("Motivo por el cual se rechaza el préstamo:", "Rechazado", _
                              IIf(IsDBNull(dgAprobacion.Item("ColRechazo", e.RowIndex).Value), "", dgAprobacion.Item("ColRechazo", e.RowIndex).Value))
            If Motivo.Length > 0 Then
                dgAprobacion.Item("ColRechazo", e.RowIndex).Value = Motivo
            Else
                'Si se cancela capturar el motivo, volver a estado de indeterminado
                dgAprobacion.CurrentCell.Value = DBNull.Value
            End If
        Catch ex As Exception
            dgAprobacion.CurrentCell.Value = DBNull.Value
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgAprobacion_Paint(sender As Object, e As PaintEventArgs) Handles dgAprobacion.Paint
        Dim BColor As System.Drawing.Color
        Dim f As Font = dgAprobacion.DefaultCellStyle.Font
        Try
            For y = 0 To dgAprobacion.RowCount - 1
                If dgAprobacion.Item("ColRevAprobada", y).Value.ToString.Trim = "" Then
                    dgAprobacion.Rows(y).DefaultCellStyle.Font = New Font(f, FontStyle.Regular)
                ElseIf dgAprobacion.Item("ColRevAprobada", y).Value.ToString.Trim = "1" Then
                    dgAprobacion.Rows(y).DefaultCellStyle.Font = New Font(f, FontStyle.Italic)
                ElseIf dgAprobacion.Item("ColRevAprobada", y).Value.ToString.Trim = "0" Then
                    dgAprobacion.Rows(y).DefaultCellStyle.Font = New Font(f, FontStyle.Strikeout)
                End If
                dgAprobacion.Rows(y).DefaultCellStyle.BackColor = BColor
            Next

        Catch ex As Exception
            dgAprobacion.DefaultCellStyle.Font = New Font(f, FontStyle.Regular)
            dgAprobacion.DefaultCellStyle.BackColor = Color.White
        End Try
    End Sub


#Region "GridImageCombo"

    Public Class GridImageCombo
        Inherits GridComboBoxExEditControl
        Private _ImageList As ImageList

        Public Sub New(ByVal imageList As ImageList, ByVal itemHeight As Integer)
            _ImageList = imageList

            DisableInternalDrawing = True
            DropDownStyle = ComboBoxStyle.DropDownList
            itemHeight = itemHeight

            For i As Integer = 0 To imageList.Images.Count - 1
                Items.Add(imageList.Images.Keys(i))
            Next i

            AddHandler DrawItem, AddressOf GridImageComboDrawItem
        End Sub

#Region "CellRender"

        Public Overrides Sub CellRender(ByVal g As Graphics)
            Dim r As Rectangle = EditorCell.Bounds
            r.X += 4
            r.Width -= 4

            RenderItem(g, r, Text)
        End Sub

#End Region

#Region "GridImageComboDrawItem"

        Private Sub GridImageComboDrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs)
            If e.Index >= 0 Then
                e.DrawBackground()

                RenderItem(e.Graphics, e.Bounds, _ImageList.Images.Keys(e.Index))
            End If
        End Sub

#End Region

#Region "RenderItem"

        Private Sub RenderItem(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal key As String)
            Dim image As Image = _ImageList.Images(key)

            If image IsNot Nothing Then
                Dim r As Rectangle = bounds
                r.Size = image.Size
                r.X += 2
                r.Y += (bounds.Height - r.Height) \ 2

                g.DrawImageUnscaled(image, r)

                r = bounds
                r.X += image.Width + 2
                r.Width -= image.Width + 2

                Using sf As New StringFormat()
                    sf.LineAlignment = StringAlignment.Center

                    g.DrawString(key, Font, Brushes.Black, r, sf)
                End Using
            End If
        End Sub

#End Region
    End Class

#End Region

    Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
        Dim Motivo As String = ""
        Try
            If Not btnTodos.Value Then
                Motivo = InputBox("Motivo por el cual se rechazan todos los préstamos:", "Rechazado")
                If Motivo = "" Then
                    For x = 0 To dgAprobacion.Rows.Count - 1
                        dgAprobacion.Item("ColRevAprobada", x).Value = DBNull.Value
                        dgAprobacion.Item("ColRechazo", x).Value = ""
                    Next
                    Exit Sub
                End If
            End If
            For x = 0 To dgAprobacion.Rows.Count - 1
                dgAprobacion.Item("ColRevAprobada", x).Value = IIf(btnTodos.Value, 1, 0)
                dgAprobacion.Item("ColRechazo", x).Value = Motivo
            Next
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Dim panel As GridPanel = dgSuperPrestamos.PrimaryGrid

        dgSuperPrestamos.PrimaryGrid.FilterExpr = Nothing
        For Each column As GridColumn In panel.Columns
            column.FilterExpr = Nothing
        Next column
    End Sub

    Private Sub tabPrestamos_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles tabPrestamos.SelectedTabChanged
        btnExportar.Visible = tabPrestamos.SelectedTabIndex = 0
        btnBuscar.Visible = tabPrestamos.SelectedTabIndex = 0
        btnLimpiar.Visible = tabPrestamos.SelectedTabIndex = 1
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim strFileName As String = ""
        Dim oWrite As System.IO.StreamWriter
        Dim GuardaArchivo As Boolean
        Dim Nulos As Integer = 0
        Try
            For Each dr As DataRow In dtSolicitudes.Rows
                If IsDBNull(dr("aprobada")) Then
                    Nulos += 1
                End If
            Next

            If Nulos > 0 Then
                MessageBox.Show("Aún quedan solicitudes pendientes de aprobar. Favor de aceptar/rechazar estas solicitudes antes de continuar.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If MessageBox.Show("¿Está seguro de exportar las solicitudes de préstamo para el proceso de la nómina?" & vbCrLf & vbCrLf & "Una vez exportadas, no podrá hacer cambios.", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

            PreguntaArchivo.Filter = "Text file|*.txt"
            PreguntaArchivo.FileName = "Prestamos" & PeriodoActual
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            End If
            Try
                oWrite = File.CreateText(strFileName)
                GuardaArchivo = True
            Catch ex As Exception
                oWrite = Nothing
                GuardaArchivo = False
            End Try

            If Not GuardaArchivo Then Exit Sub

            Dim Prestamo As Double
            Dim Intereses As Double
            Dim AbonoPmo As Double
            Dim AbonoInt As Double

            For Each dRow As DataRow In dtSolicitudes.Rows
                If IIf(IsDBNull(dRow("aprobada")), 0, dRow("aprobada")) = 1 Then
                    Prestamo = dRow("cantidad_sol")
                    Intereses = dRow("cantidad_pag") - Prestamo
                    AbonoPmo = RoundUp(Prestamo / dRow("semanas_pag"), 2)
                    AbonoInt = RoundUp(Intereses / dRow("semanas_pag"), 2)

                    oWrite.WriteLine(Space(4) & _
                                     dRow("reloj").ToString.Trim.PadRight(6) & _
                                     Space(1) & _
                                     (Prestamo * 100).ToString.Trim.PadLeft(8) & _
                                     Space(10) & _
                                     (Intereses * 100).ToString.Trim.PadLeft(8) & _
                                     Space(10) & _
                                     (AbonoPmo * 100).ToString.Trim.PadLeft(8) & _
                                     Space(1) & _
                                     (AbonoInt * 100).ToString.Trim.PadLeft(8))



                    'reloj, 5
                    '    000000 00000000          00000000          00000000 00000000
                    '

                End If

                sqlExecute("UPDATE sol_prestamos SET exportada = 1,aprobada = " & dRow("aprobada") & ", fecha_exportacion = '" & FechaHoraSQL(Now) & _
                               "',usuario_exportacion = '" & Usuario & "' WHERE reloj = '" & dRow("reloj") & _
                               "' AND fecha = '" & FechaSQL(dRow("fecha")) & "'", "nomina")
            Next

            If GuardaArchivo Then
                oWrite.Close()
            End If

            ActualizaDatos()
            MessageBox.Show("El archivo " & strFileName & " fue guardado exitosamente.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Hubo un error durante el proceso de exportación, por lo que el archivo no fue generado exitosamente." & _
                             vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub dgSuperPrestamos_CellClick(sender As Object, e As GridCellClickEventArgs) Handles dgSuperPrestamos.CellClick
        Dim R As String = e.GridCell.GridRow(2).Value
        Dim F As String = e.GridCell.GridRow(3).Value
        Dim A As String = e.GridCell.GridRow(9).Value

        SolicitudReloj = R.ToString.Trim
        SolicitudFecha = F
        SolicitudEstado = IIf(A = "APROBADO", 1, IIf(A = "RECHAZADO", 2, 0))


    End Sub

    Private Sub ReimprimirSolicitudToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReimprimirSolicitudToolStripMenuItem.Click
        Dim dtInfo As New DataTable

        dtInfo = sqlExecute("SELECT sol_prestamos.reloj,nombres,cod_turno,nombre_depto,fecha," & _
                                "cantidad_sol,cantidad_pag,ROUND(cantidad_sol*(porciento/100),2) as intereses,porciento/100 as porciento," & _
                                "descuento_sem,semanas_pag,RTRIM(motivo_pmo) AS motivo_pmo " & _
                                "FROM nomina.dbo.sol_prestamos,personal.dbo.personalvw " & _
                                "WHERE personalVW.reloj='" & SolicitudReloj & "' AND  sol_prestamos.reloj = '" & SolicitudReloj & "'" & _
                                "AND fecha = '" & FechaSQL(SolicitudFecha) & "' AND aprobada = " & SolicitudEstado)
        frmVistaPrevia.LlamarReporte("Solicitud de préstamo", dtInfo)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub btnMostrarInformacion_Click(sender As Object, e As EventArgs) Handles btnMostrarInformacion.Click
        ActualizaDatos()
    End Sub



    Private Sub btnTodos_ValueChanged(sender As Object, e As EventArgs) Handles btnTodos.ValueChanged

    End Sub

    Private Sub frmRevisionPrestamos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlCentrar.Left = (Me.Width - pnlCentrar.Width) / 2
    End Sub
End Class