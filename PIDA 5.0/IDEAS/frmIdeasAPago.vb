Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style

Public Class frmIdeasAPago
    Dim Monto As Double
    Dim Clave As String

    Dim Agregar As Boolean
    Dim dtInfoPersonal As New DataTable
    Dim dtTemp As New DataTable
    Dim dtCias As New DataTable
    Dim dtSolicitudes As New DataTable
    Dim dtSol As New DataTable
    Dim TotalSemanas As Integer
    Dim Cargando As Boolean = True
    Dim AnoPeriodoActual As String = ""
    Dim SolicitudReloj As String
    Dim SolicitudFecha As String
    Dim SolicitudEstado As Integer
    Dim InicioPrestamosStr As String

    Private _MyFont As New Font(SystemFonts.StatusFont, FontStyle.Bold)
    Private _BackColor As Background() = {New Background(Color.MistyRose), _
    New Background(Color.FromArgb(&HE5, &HFF, &HDD)), New Background(Color.AliceBlue)}

    Private Sub frmRevisionPrestamos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmRevisionPrestamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Valido As Boolean = True

        'btnProcesar.Left = btnLimpiar.Left
        btnLimpiar.Left = btnBuscar.Left
        tabPrestamos.SelectedTabIndex = 0
        dgAprobacion.AutoGenerateColumns = False
        btnTodos.Value = True
        cmbPeriodos.DataSource = sqlExecute("SELECT ano+periodo AS unico,ano,periodo,fecha_ini,fecha_fin FROM periodos ORDER BY unico", "TA")
        cmbCompa.DataSource = sqlExecute("select cod_comp, nombre from cias order by cod_comp desc")
        'cmbPeriodos.DataSource = sqlExecute("SELECT ano+periodo AS unico,ano,periodo,fecha_ini,fecha_fin FROM periodos WHERE ano+periodo >= (SELECT MIN(ano+periodo) FROM periodos WHERE activo = 1) ORDER BY unico", "TA")
        cmbPeriodos.SelectedValue = ObtenerAnoPeriodo(Now.Date)
        cmbCompa.SelectedValue = "610"
        AnoPeriodoActual = cmbPeriodos.SelectedValue
        ActualizaDatos()

    End Sub
    Dim FechaIni As Date
    Dim FechaFin As Date
    Private Sub ActualizaDatos()
        Dim dtConsulta As New DataTable

        Try


            If cmbCompa.SelectedValue = "002" Then
                dgAprobacion.Columns("Reloj_alt").Visible = True
            Else
                dgAprobacion.Columns("Reloj_alt").Visible = False
            End If


            'El rango para las ideas es de febrero de un año a enero del siguiente
            FechaIni = DateSerial(Year(Now), 2, 1)
            FechaFin = DateSerial(Year(Now) + 1, 1, 30)

            If FechaIni > Now Then
                'Si la fecha inicial es posterior al día de hoy, está en enero, aún es del periodo anterior
                FechaIni = DateSerial(Year(Now) - 1, 2, 1)
                FechaFin = DateSerial(Year(Now), 1, 30)
            End If


            'Buscar el máximo periodo cargado en nómina
            tabTabla.Text = "CONSULTA" & vbCrLf & Year(FechaIni) & "-" & Year(FechaFin)

            tabAprobaciones.Text = "CONSULTA " & vbCrLf & "PERIODO " + AnoPeriodoActual.Substring(4, 2) & vbCrLf & "ANO " + AnoPeriodoActual.Substring(0, 4)
            dtTemp = sqlExecute("SELECT misce_clave,misce_monto FROM conceptos WHERE concepto = 'IDEAS'", "NOMINA")
            If dtTemp.Rows.Count = 0 Then
                MessageBox.Show("No se localizó concepto de IDEAS en nómina. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf IsDBNull(dtTemp.Rows(0).Item("misce_clave")) Or IsDBNull(dtTemp.Rows(0).Item("misce_monto")) Then
                MessageBox.Show("Falta la clave y/o el monto a pagar por el concepto de IDEAS en nómina. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                Clave = dtTemp.Rows(0).Item("misce_clave")
                Monto = dtTemp.Rows(0).Item("misce_monto")
            End If
            'c'
            'dtSolicitudes = sqlExecute("SELECT personalvw.compania,personalvw.reloj_alt,ideasvw.reloj,personalvw.nombres,ideasvw.fecha,ideasvw.titulo,folio,calificacion, cast(65 as decimal(4,2)) / cast(colaboradores as decimal(4,2)) AS cantidad, personalvw.nombre_area," & _
            '                           " personalvw.cod_depto, ideasvw.nombre_estacion, personalvw.cod_super, personalvw.estatus, implementacion, pagada FROM ideasvw LEFT JOIN personal.dbo.personalVW ON ideasvw.reloj = personalvw.reloj " & _
            '                           "WHERE pagada  = '" + AnoPeriodoActual + "'  AND ideasvw.ESTATUS='I'  AND tipo_periodo = '" & IIf(btnTodos.Value, "S", "Q") & "' and personalvw.cod_comp = '" & cmbCompa.SelectedValue & "' ORDER BY fecha,reloj ", "IDEAS")
            'Jose R Hdez 2019 Abr 11
            dtSolicitudes = sqlExecute("SELECT personalvw.compania,personalvw.reloj_alt,ideasvw.reloj,personalvw.nombres,ideasvw.fecha,ideasvw.titulo,folio,calificacion, case when ideasvw.COD_OBJETIVO like '%004%' then cast(130 as decimal(5,2)) / cast(colaboradores as decimal(5,2)) else cast(65 as decimal(4,2)) / cast(colaboradores as decimal(4,2)) end AS cantidad, personalvw.nombre_area," & _
                                       " personalvw.cod_depto, ideasvw.nombre_estacion, personalvw.cod_super, personalvw.estatus, implementacion, pagada FROM ideasvw LEFT JOIN personal.dbo.personalVW ON ideasvw.reloj = personalvw.reloj " & _
                                       "WHERE pagada  = '" + AnoPeriodoActual + "'  AND ideasvw.ESTATUS='I'  AND tipo_periodo = '" & IIf(btnTodos.Value, "S", "Q") & "' and personalvw.cod_comp = '" & cmbCompa.SelectedValue & "' ORDER BY fecha,reloj ", "IDEAS")

            dtSolicitudes.Columns.Add("enviar", GetType(System.Boolean))
            For Each dSol As DataRow In dtSolicitudes.Rows
                dSol("enviar") = False
            Next

            dtConsulta = sqlExecute("SELECT compania,reloj,SUBSTRING(pagada,1,4) as ano,SUBSTRING(pagada,5,2) AS periodo,cast(65 as decimal(4,2)) / cast(colaboradores as decimal(4,2)) as monto,folio,titulo,calificacion,envio_nomina,fecha AS fecha_captura_idea, " & _
" case WHEN envio_nomina IS NULL then 'NO' else 'SI' end AS pagada,pagada as anoperiodo FROM ideasvw " & _
" WHERE fecha BETWEEN '" & Date.Now.Year.ToString & "-02-01' AND '" & (Date.Now.Year + 1).ToString & "-01-30' ORDER BY ano DESC,periodo DESC", "IDEAS")
                    dgConsulta.PrimaryGrid.DataSource = dtConsulta

                    dgAprobacion.DataSource = dtSolicitudes
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub AddRows()
        Try
            'dtSol = sqlExecute("SELECT RTRIM(reloj) AS reloj,periodo,ano,fecha,cantidad_sol,cantidad_pag,porciento,descuento_sem,semanas_pag," & _
            '                      "RTRIM(motivo_pmo) AS motivo_pmo,aprobada,motivo_rechazo,usuario,usuario_revision,fecha_revision," & _
            '                      "(CASE aprobada WHEN 0 THEN 'PENDIENTE' WHEN 2 THEN 'RECHAZADO' ELSE 'APROBADO' END) as estado " & _
            '                      "FROM sol_prestamos WHERE ano = '" & Year(Now.Date) & "' ORDER BY ano DESC,periodo DESC,aprobada,reloj", "nomina")

            'Dim panel As GridPanel = dgSuperPrestamos.PrimaryGrid

            'dgSuperPrestamos.BeginUpdate()
            'dgSuperPrestamos.PrimaryGrid.Rows.Clear()

            'For Each dRow As DataRow In dtSol.Rows
            '    Dim Info() As Object = {dRow("ano"), dRow("periodo"), dRow("reloj"), dRow("fecha"), dRow("cantidad_sol"), _
            '                           dRow("cantidad_pag"), dRow("porciento"), dRow("semanas_pag"), dRow("descuento_sem"), dRow("estado"), dRow("motivo_pmo").ToString.Trim, _
            '                           dRow("usuario"), dRow("usuario_revision"), dRow("fecha_revision"), dRow("motivo_rechazo").ToString.Trim}
            '    panel.Rows.Add(New GridRow(Info))
            'Next

            'dgSuperPrestamos.EndUpdate()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
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
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtInfoPersonal = dtTemp
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            'If Consulta = False Then
            '    dtTemp = sqlExecute("SELECT reloj,folio,nombres,cod_depto,cod_puesto,nombre_estacion,cod_super,estatus,implementacion " & _
            '                               "FROM ideasVW WHERE folio in (SELECT folio FROM ideas_empleado WHERE envio_nomina IS NULL AND ESTATUS='I')", "IDEAS")

            '    EncabezadoReporte = "PENDIENTES DE ENVIAR A PAGO"
            'Else
            '    Dim filtro As String = "('"
            '    For Each r As GridRow In dgConsulta.PrimaryGrid.Rows
            '        If r.Visible = True Then
            '            filtro &= r.Cells(1).Value & "','_"
            '        End If
            '    Next
            '    filtro &= "_"
            '    filtro = filtro.Replace(",'__", ")")
            '    filtro = filtro.Replace("_", "")

            '    dtTemp = sqlExecute("SELECT reloj,folio,nombres,cod_depto,cod_puesto,nombre_estacion,cod_super,estatus,implementacion,SUBSTRING(pagada,1,4)+'-'+SUBSTRING(pagada,5,2) AS periodo " & _
            '                               "FROM ideasVW WHERE folio in " & filtro & " ", "IDEAS")
            '    'dtTemp = sqlExecute("SELECT reloj,folio,nombres,cod_depto,cod_puesto,nombre_estacion,cod_super,estatus FROM ideasvw WHERE folio in(SELECT folio FROM nomina.dbo.ajustes_nom LEFT JOIN IDEAS.dbo.ideas_empleado ON ajustes_nom.reloj = ideas_empleado.reloj " & _
            '    '                  "AND ajustes_nom.numcredito = ideas_empleado.folio WHERE concepto = 'IDEAS' AND " & _
            '    '                 "ideas_empleado.fecha BETWEEN '" & FechaSQL(FechaIni) & "' AND '" & FechaSQL(FechaFin) & "')", "IDEAS")
            '    EncabezadoReporte = "CONSULTA " & Year(FechaIni) & " " & Year(FechaFin)
            'End If
            'If Consulta = False Then
            '    dtTemp = sqlExecute("SELECT compania,reloj,folio,nombres,cod_depto,cod_puesto,nombre_estacion,cod_super,estatus,implementacion,SUBSTRING(pagada,1,4)+'-'+SUBSTRING(pagada,5,2) AS periodo, " & _
            '                                   "  cast(65 as decimal(4,2)) / cast(colaboradores as decimal(4,2)) as monto2 FROM ideasVW WHERE pagada  = '" + AnoPeriodoActual + "' ", "IDEAS")
            '    EncabezadoReporte = "IDEAS PAGADAS EN EL PERIODO " + AnoPeriodoActual.Substring(4, 2) + " DEL ANO " + AnoPeriodoActual.Substring(0, 4)
            'Else
            '    Dim filtro As String = "('"
            '    For Each r As GridRow In dgConsulta.PrimaryGrid.Rows
            '        If r.Visible = True Then
            '            filtro &= r.Cells(1).Value & "','_"
            '        End If
            '    Next
            '    filtro &= "_"
            '    filtro = filtro.Replace(",'__", ")")
            '    filtro = filtro.Replace("_", "")

            '    dtTemp = sqlExecute("SELECT compania,reloj,folio,nombres,cod_depto,cod_puesto,nombre_estacion,cod_super,estatus,implementacion,SUBSTRING(pagada,1,4)+'-'+SUBSTRING(pagada,5,2) AS periodo, " & _
            '                               "  cast(65 as decimal(4,2)) / cast(colaboradores as decimal(4,2)) as monto2 FROM ideasVW WHERE folio in " & filtro & " ", "IDEAS")
            '    'dtTemp = sqlExecute("SELECT reloj,folio,nombres,cod_depto,cod_puesto,nombre_estacion,cod_super,estatus FROM ideasvw WHERE folio in(SELECT folio FROM nomina.dbo.ajustes_nom LEFT JOIN IDEAS.dbo.ideas_empleado ON ajustes_nom.reloj = ideas_empleado.reloj " & _
            '    '                  "AND ajustes_nom.numcredito = ideas_empleado.folio WHERE concepto = 'IDEAS' AND " & _
            '    '                 "ideas_empleado.fecha BETWEEN '" & FechaSQL(FechaIni) & "' AND '" & FechaSQL(FechaFin) & "')", "IDEAS")
            '    EncabezadoReporte = "CONSULTA " & Year(FechaIni) & " " & Year(FechaFin)
            'End If


            frmVistaPrevia.LlamarReporte("Reporte de sugerencias", dtSolicitudes)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Hubo un error durante la generación del reporte." & _
                               vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
        Dim Motivo As String = ""
        Try
            For x = 0 To dgAprobacion.Rows.Count - 1
                dgAprobacion.Item("colEnviarNomina", x).Value = IIf(btnTodos.Value, 1, 0)
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Dim panel As GridPanel = dgConsulta.PrimaryGrid

        dgConsulta.PrimaryGrid.FilterExpr = Nothing
        For Each column As GridColumn In panel.Columns
            column.FilterExpr = Nothing
        Next column
    End Sub

    Dim Consulta As Boolean = False
    Private Sub tabPrestamos_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles tabPrestamos.SelectedTabChanged
        ' btnProcesar.Visible = tabPrestamos.SelectedTabIndex = 0
        btnBuscar.Visible = tabPrestamos.SelectedTabIndex = 0
        btnLimpiar.Visible = tabPrestamos.SelectedTabIndex = 1
        Try
            If tabPrestamos.SelectedTab.Equals(tabTabla) Then
                Consulta = True
            Else
                Consulta = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs)
        Dim strFileName As String = ""
        Dim Aprobado As Integer = 0
        Dim AnoPeriodo As String
        Dim Errores As String = ""

        Try
            If cmbPeriodos.SelectedValue Is Nothing Then
                MessageBox.Show("Es necesario elegir el periodo en que se procesará el pago. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            For Each dRow As DataRow In dtSolicitudes.Rows
                If IIf(IsDBNull(dRow("enviar")), False, dRow("enviar")) Then
                    Aprobado += 1
                End If
            Next

            If Aprobado = 0 Then
                MessageBox.Show("No hay ideas aprobadas para ser enviadas a pago. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If MessageBox.Show("¿Está seguro de procesar el pago de ideas para el proceso de la nómina?" & vbCrLf & vbCrLf & "Una vez aprobadas, no podrá hacer cambios.", "Aprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If


            AnoPeriodo = cmbPeriodos.SelectedValue
            Aprobado = 0
            For Each dRow As DataRow In dtSolicitudes.Rows
                If IIf(IsDBNull(dRow("enviar")), False, dRow("enviar")) Then
                    dtTemp = sqlExecute("SELECT envio_nom FROM ajustes_nom WHERE RELOJ = '" & dRow("RELOJ").ToString.Trim & _
                                        "' AND CONCEPTO = 'IDEAS' AND NUMCREDITO = '" & dRow("FOLIO").ToString.Trim & "'", "NOMINA")
                    If dtTemp.Rows.Count > 0 Then
                        If IIf(IsDBNull(dtTemp.Rows(0).Item("envio_nom")), 0, dtTemp.Rows(0).Item("envio_nom")) <> 0 Then
                            Errores += vbCrLf & "La idea # " & dRow("folio") & ", propuesta por el empleado " & dRow("reloj") & " fue enviada a nómina el día " & dtTemp.Rows(0).Item("envio_nom")
                        Else
                            sqlExecute("UPDATE ajustes_nom SET clave = '" & Clave & "', monto = " & Monto & ", fecha = getdate()", "NOMINA")
                            sqlExecute("UPDATE ideas_empleado SET envio_nomina = GETDATE(),PAGADA='" & AnoPeriodo & "' WHERE folio = '" & dRow("folio") & "'", "IDEAS")
                            Aprobado += 1
                        End If
                    Else
                        Aprobado += 1
                        sqlExecute("INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,numcredito,concepto,usuario,fecha)" & "VALUES (" & _
                                   "'" & dRow("reloj") & "'," & _
                                   "'" & AnoPeriodo.Substring(0, 4) & "'," & _
                                   "'" & AnoPeriodo.Substring(4, 2) & "'," & _
                                   "'P'," & _
                                   "'" & Clave & "'," & _
                                   "" & Monto & "," & _
                                   "'Pago de idea #" & dRow("folio") & "'," & _
                                   "'" & dRow("folio") & "'," & _
                                   "'IDEAS'," & _
                                   "'" & Usuario & "'," & _
                                   "GETDATE()" & _
                                   ")", "nomina")

                        sqlExecute("UPDATE ideas_empleado SET envio_nomina = GETDATE(),PAGADA='" & AnoPeriodo & "' WHERE folio = '" & dRow("folio") & "'", "IDEAS")
                    End If

                End If
            Next

            ActualizaDatos()

            dtTemp = sqlExecute("SELECT reloj,folio,nombres,cod_depto,cod_puesto,nombre_estacion,cod_super,estatus,implementacion,SUBSTRING(pagada,1,4)+'-'+SUBSTRING(pagada,5,2) AS periodo  " & _
                     "FROM ideasVW WHERE envio_nomina = '" & FechaSQL(Now.Date) & "' ORDER BY folio,reloj ", "IDEAS")
            EncabezadoReporte = "ENVIADAS A PAGO EL " & FechaMediaLetra(Now.Date).ToUpper
            frmVistaPrevia.LlamarReporte("Reporte de sugerencias", dtTemp)
            frmVistaPrevia.ShowDialog()

            MessageBox.Show("Se " & IIf(Aprobado = 1, "aprobó una idea", "aprobaron " & Aprobado & " ideas") & " para pago en el periodo " & AnoPeriodo & ".", "Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Hubo un error durante el proceso de aprobación, por lo que los datos no fueron completamente enviados a nómina." & _
                             vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ReimprimirSolicitudToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim dtInfo As New DataTable

        dtInfo = sqlExecute("SELECT sol_prestamos.reloj,nombres,cod_turno,nombre_depto,fecha," & _
                                "cantidad_sol,cantidad_pag,ROUND(cantidad_sol*(porciento/100),2) as intereses,porciento/100 as porciento," & _
                                "descuento_sem,semanas_pag,RTRIM(motivo_pmo) AS motivo_pmo " & _
                                "FROM nomina.dbo.sol_prestamos,personal.dbo.personalvw " & _
                                "WHERE personalVW.reloj='" & SolicitudReloj & "' AND  sol_prestamos.reloj = '" & SolicitudReloj & "'" & _
                                "AND fecha = '" & FechaSQL(SolicitudFecha) & "' AND aprobada = " & SolicitudEstado)
        'frmVistaPrevia.LlamarReporte("Solicitud de préstamo", dtInfo)
        'frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub btnMostrarInformacion_Click(sender As Object, e As EventArgs) Handles btnMostrarInformacion.Click
        ActualizaDatos()
    End Sub



    Private Sub btnTodos_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmRevisionPrestamos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlCentrar.Left = (Me.Width - pnlCentrar.Width) / 2
    End Sub

    Private Sub dgAprobacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAprobacion.CellContentClick

    End Sub

    Private Sub cmbPeriodos_PopupClose(sender As Object, e As EventArgs)
        AnoPeriodoActual = cmbPeriodos.SelectedValue
        ActualizaDatos()
    End Sub

    Private Sub btnTodos_ValueChanged_1(sender As Object, e As EventArgs) Handles btnTodos.ValueChanged

        If btnTodos.Value Then
            cmbPeriodos.DataSource = sqlExecute("SELECT ano+periodo AS unico,ano,periodo,fecha_ini,fecha_fin FROM periodos ORDER BY unico", "TA")
            cmbPeriodos.SelectedValue = ObtenerAnoPeriodo(Now.Date)
            AnoPeriodoActual = cmbPeriodos.SelectedValue
            ActualizaDatos()

        Else
            cmbPeriodos.DataSource = sqlExecute("SELECT ano+periodo AS unico,ano,periodo,fecha_ini,fecha_fin FROM periodos_quincenal ORDER BY unico", "TA")
            cmbPeriodos.SelectedValue = ObtenerAnoPeriodo(Now.Date, "Q")
            AnoPeriodoActual = cmbPeriodos.SelectedValue
            ActualizaDatos()
        End If


    End Sub

    Private Sub cmbCompa_ValueMemberChanged(sender As Object, e As EventArgs)
        ActualizaDatos()
    End Sub

    Private Sub cmbPeriodos_PopupClose_1(sender As Object, e As EventArgs) Handles cmbPeriodos.PopupClose
        AnoPeriodoActual = cmbPeriodos.SelectedValue
        ActualizaDatos()
    End Sub

    Private Sub cmbCompa_PopupClose(sender As Object, e As EventArgs) Handles cmbCompa.PopupClose
        ActualizaDatos()
    End Sub
End Class