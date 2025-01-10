Imports System.Deployment.Application 'Libreria para buscar la ultima actualizacion de todo el sistema 

Public Class frmMain
    Dim dtTemp As New DataTable

    Private Enum ShowWindowCommand As Integer
        Hide = 0
        Show = 5

    End Enum

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sqlExecute("UPDATE appuser SET modulo = '" & rbGeneral.SelectedRibbonTabItem.Name & "' WHERE username = '" & Usuario & "'", "SEGURIDAD")
        Me.Dispose()
        End
    End Sub


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            stlEstiloVIsual.ManagerColorTint = mgrColorTint
            stlEstiloVIsual.ManagerStyle = mgrStyle
            '***** Obtener lista de formas *****
            PermitirAccesosXperfil()


            '***********************************
            Me.BackgroundImage = My.Resources.logo_pida_nvo_plain
            Me.Text = Me.Text & " " & ApVer
            ' Neccessary for Automatic Tab-Strip Mdi support
            tabStrip1.MdiForm = Me

            'Si hay un módulo inicial seleccionado, buscarlo 
            If ModuloInicial.Length > 0 Then
                For Each it In rbGeneral.Items
                    If it.name = ModuloInicial Then
                        rbGeneral.SelectedRibbonTabItem = it
                        Exit For
                    End If
                Next
            End If

            HabDeshabTabsMainGral() '---Tabs habilitados por cierto criterio

            '== 28ene2022
            '== Mostrar el botón para validar registros de info. de los XMLs timbrados
            If Usuario.Trim = "pida" Or Usuario.Trim = "PIDA" Then
                btnValidaTimbrado.Enabled = True
                btnValidaTimbrado.Visible = True
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try

        'If Usuario.Trim.ToUpper <> "PIDA" Then
        '    btnCalcFiniquito.Enabled = False
        '    btnCalcFiniquito.Visible = False
        'End If

    End Sub

    '== MODIFICADO          3MAR22          Ernesto
    Public Sub HabDeshabTabsMainGral()
        '===No visibles para nadie a menos que se indique
        rbRHReclutamiento.Visible = False ' Reclutamiento
        RibbonTabItem4.Visible = False ' Ideas
        RibbonTabItem1.Visible = False ' Servicios Medicos
        Herramientas.Visible = False ' Herramientas
        Cafeteria.Visible = False ' Cafetería
        procesonomina.Visible = False ' Proceso de nómina

        '== Habilitar pestañas para ciertos perfiles nada mas
        Kiosco.Visible = IIf(Perfil.Contains("ADMINISTRADOR"), True, False)


    End Sub

    Public Sub analisis_auto(analisis_f As Date)
        If ANALISIS_AUTOMATICO Then
            Try

                frmAnalisisAutomatico.ListBox1.Items.Add("iniciando frmTA")
                Dim frm As New frmTA
                frm.MdiParent = Me
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
                frm.Focus()
                frm.chkGlobal.Checked = True

                frmAnalisisAutomatico.agregar_elemento("fecha: " & FechaSQL(analisis_f))

                Dim dtAnoPeriodo As DataTable = sqlExecute("select ano+periodo as anoper from periodos where '" & analisis_f & "' between fecha_ini and fecha_fin and isnull(periodo_especial, 0) = 0", "TA")
                If dtAnoPeriodo.Rows.Count > 0 Then
                    Dim ano_per As String = dtAnoPeriodo.Rows(0)("anoper")
                    frmAnalisisAutomatico.agregar_elemento("periodo: " & ano_per)

                    frm.cmbPeriodos.SelectedValue = ano_per

                    Dim dia_sem As Integer = analisis_f.DayOfWeek
                    Select Case dia_sem
                        Case DayOfWeek.Monday
                            frm.chkLun.Checked = True
                            frmAnalisisAutomatico.agregar_elemento("dia: lunes")
                        Case DayOfWeek.Tuesday
                            frm.chkMar.Checked = True
                            frmAnalisisAutomatico.agregar_elemento("dia: martes")
                        Case DayOfWeek.Wednesday
                            frm.chkMie.Checked = True
                            frmAnalisisAutomatico.agregar_elemento("dia: miercoles")
                        Case DayOfWeek.Thursday
                            frm.chkJue.Checked = True
                            frmAnalisisAutomatico.agregar_elemento("dia: jueves")
                        Case DayOfWeek.Friday
                            frm.chkVie.Checked = True
                            frmAnalisisAutomatico.agregar_elemento("dia: viernes")
                        Case DayOfWeek.Saturday
                            frm.chkSab.Checked = True
                            frmAnalisisAutomatico.agregar_elemento("dia: sabado")
                        Case DayOfWeek.Sunday
                            frm.chkDom.Checked = True
                            frmAnalisisAutomatico.agregar_elemento("dia: domingo")
                    End Select


                    frm.btnAnalisis.RaiseClick()


                End If

            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub RefrescaVacaciones()

        Dim dtActivos As DataTable = sqlExecute("select * from personal where baja is null")
        For Each row As DataRow In dtActivos.Rows
            Dim rl As String = row("reloj")
            Dim _diasVac As Integer = 0
            Dim _Prima As Integer = 0
            Dim _alta As Date = row("alta")
            Dim Antiguedad As Integer = DateDiff(DateInterval.Year, _alta, Now)

            Dim _f_aniversario As New Date(Year(Now), _alta.Month, _alta.Day)
            Dim _f_anterior As New Date(Year(Now) - 1, _alta.Month, _alta.Day)
            Dim _dinero As Double = 0
            Dim _tiempo As Double = 0
            Dim _dDias As Double = 0


            Try
                '***** PARA ACTUALIZAR SALDOS CUANDO CUMPLEN ANIVERSARIO
                If Antiguedad >= 1 And Not EsBaja And Now >= _f_aniversario Then
                    _diasVac = 0
                    _Prima = 0
                    dtTemp = sqlExecute("SELECT reloj FROM saldos_vacaciones WHERE reloj = '" & rl & "' AND ano = '" & Year(_f_aniversario) & "' AND aniversario = 1")

                    '*** Si ya pasó su aniversario, y no se le han actualizado los saldos, crear registro de aniversario
                    If dtTemp.Rows.Count = 0 Then
                        '*** Tomar los saldos anteriores
                        dtTemp = sqlExecute("SELECT TOP 1 saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & rl & "' ORDER BY fecha_captura DESC,fecha_fin DESC")
                        If dtTemp.Rows.Count > 0 Then
                            _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero")
                            _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo")
                        End If

                        dtTemp = sqlExecute("SELECT dias, por_prima FROM vacaciones WHERE cod_comp = '" & row("cod_comp") & "' AND cod_tipo = '" & row("cod_tipo") & "' AND anos = " & Antiguedad)

                        If dtTemp.Rows.Count > 0 Then
                            _diasVac = dtTemp.Rows.Item(0).Item("dias")
                            _Prima = dtTemp.Rows.Item(0).Item("por_prima")

                            sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,dias,prima,saldo_dinero,saldo_tiempo,comentario,aniversario," & _
                                       "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                                       rl & "','" & _
                                       Year(_f_aniversario) & "'," & _
                                       _diasVac & "," & _
                                       _Prima & "," & _
                                       (_dinero + _diasVac) & "," & _
                                       (_tiempo + _diasVac) & _
                                       ",'ANIVERSARIO " & Year(_f_aniversario) & "',1,'" & _
                                       FechaSQL(_f_anterior) & "','" & _
                                       FechaSQL(_f_aniversario) & "',GETDATE())")
                        End If

                    End If
                End If

            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            End Try

        Next


    End Sub

    Private Sub btnMaestro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaestro.Click
        On Error Resume Next
        frmMaestro.MdiParent = Me
        frmMaestro.WindowState = FormWindowState.Maximized
        frmMaestro.Show()
        frmMaestro.Focus()
    End Sub

    Private Sub btnAuxiliares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAuxiliares.Click
        frmAuxiliares.MdiParent = Me
        frmAuxiliares.WindowState = FormWindowState.Maximized
        frmAuxiliares.Show()
        frmAuxiliares.Focus()
    End Sub

    Private Sub btnFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFamilia.Click
        frmFamilia.MdiParent = Me
        frmFamilia.WindowState = FormWindowState.Maximized
        frmFamilia.Show()
        frmFamilia.Focus()
    End Sub

    Private Sub btnModificacionesSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuModificacionesSueldo.Click
        frmTipoMovSal.MdiParent = Me
        frmTipoMovSal.WindowState = FormWindowState.Maximized
        frmTipoMovSal.Show()
        frmTipoMovSal.Focus()
    End Sub

    Private Sub btnEscuelas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEscuelas.Click
        frmEscuelas.MdiParent = Me
        frmEscuelas.WindowState = FormWindowState.Maximized
        frmEscuelas.Show()
        frmEscuelas.Focus()
    End Sub

    Private Sub btnCiudades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCiudades.Click
        frmCiudades.MdiParent = Me
        frmCiudades.WindowState = FormWindowState.Maximized
        frmCiudades.Show()
        frmCiudades.Focus()
    End Sub

    Private Sub btnClasificacion_Click(sender As System.Object, e As System.EventArgs) Handles mnuClasificacion.Click
        frmClase.MdiParent = Me
        frmClase.WindowState = FormWindowState.Maximized
        frmClase.Show()
        frmClase.Focus()
    End Sub

    Private Sub btnColonias_Click(sender As System.Object, e As System.EventArgs) Handles mnuColonias.Click
        frmColonias.MdiParent = Me
        frmColonias.WindowState = FormWindowState.Maximized
        frmColonias.Show()
        frmColonias.Focus()
    End Sub

    Private Sub btnEstadoCivil_Click(sender As System.Object, e As System.EventArgs) Handles mnuEstadoCivil.Click
        frmCivil.MdiParent = Me
        frmCivil.WindowState = FormWindowState.Maximized
        frmCivil.Show()
        frmCivil.Focus()
    End Sub

    Private Sub mnuEstados_Click(sender As System.Object, e As System.EventArgs) Handles mnuEstados.Click
        frmEstados.MdiParent = Me
        frmEstados.WindowState = FormWindowState.Maximized
        frmEstados.Show()
        frmEstados.Focus()
    End Sub

    Private Sub mnuFactoresIntegracion_Click(sender As System.Object, e As System.EventArgs) Handles mnuFactoresIntegracion.Click
        frmFactInt.MdiParent = Me
        frmFactInt.WindowState = FormWindowState.Maximized
        frmFactInt.Show()
        frmFactInt.Focus()
    End Sub

    Private Sub mnuHorarios_Click(sender As System.Object, e As System.EventArgs) Handles mnuHorarios.Click
        frmHorarios.MdiParent = Me
        frmHorarios.WindowState = FormWindowState.Maximized
        frmHorarios.Show()
        frmHorarios.Focus()
    End Sub

    Private Sub mnuLineas_Click(sender As System.Object, e As System.EventArgs)
        frmLineas.MdiParent = Me
        frmLineas.WindowState = FormWindowState.Maximized
        frmLineas.Show()
        frmLineas.Focus()
    End Sub

    Private Sub mnuNiveles_Click(sender As System.Object, e As System.EventArgs) Handles mnuNiveles.Click
        frmNivel.MdiParent = Me
        frmNivel.WindowState = FormWindowState.Maximized
        frmNivel.Show()
        frmNivel.Focus()
    End Sub

    Private Sub mnuSupervisores_Click(sender As System.Object, e As System.EventArgs) Handles mnuSupervisores.Click
        frmSuper.MdiParent = Me
        frmSuper.WindowState = FormWindowState.Maximized
        frmSuper.Show()
        frmSuper.Focus()
    End Sub

    Private Sub mnuTiposEmpleado_Click(sender As System.Object, e As System.EventArgs) Handles mnuTiposEmpleado.Click
        frmTipoEmp.MdiParent = Me
        frmTipoEmp.WindowState = FormWindowState.Maximized
        frmTipoEmp.Show()
        frmTipoEmp.Focus()
    End Sub

    Private Sub mnuTurnos_Click(sender As System.Object, e As System.EventArgs) Handles mnuTurnos.Click
        frmTurnos.MdiParent = Me
        frmTurnos.WindowState = FormWindowState.Maximized
        frmTurnos.Show()
        frmTurnos.Focus()
    End Sub

    Private Sub mnuVacaciones_Click(sender As System.Object, e As System.EventArgs) Handles mnuVacaciones.Click
        frmVacaciones.MdiParent = Me
        frmVacaciones.WindowState = FormWindowState.Maximized
        frmVacaciones.Show()
        frmVacaciones.Focus()
    End Sub

    Private Sub mnuAguinaldo_Click(sender As System.Object, e As System.EventArgs) Handles mnuAguinaldo.Click
        frmAguinaldo.MdiParent = Me
        frmAguinaldo.WindowState = FormWindowState.Maximized
        frmAguinaldo.Show()
        frmAguinaldo.Focus()
    End Sub

    Private Sub mnuFormaPago_Click(sender As Object, e As EventArgs) Handles mnuFormaPago.Click
        frmFormaPago.MdiParent = Me
        frmFormaPago.WindowState = FormWindowState.Maximized
        frmFormaPago.Show()
        frmFormaPago.Focus()
    End Sub

    Private Sub btnMtoNomina_Click(sender As Object, e As EventArgs) Handles btnMtoNomina.Click
        'frmMantenimiento.MdiParent = Me
        On Error Resume Next
        Dim frm As New frmMantenimiento
        frm.ShowDialog(Me)
        ' frmMantenimiento.Focus()
    End Sub

    Private Sub btnVariables_Click(sender As Object, e As EventArgs) Handles btnVariables.Click
        frmActualizarVariables.ShowDialog(Me)
        frmActualizarVariables.Focus()
    End Sub

    Private Sub btnModSalTemp_Click(sender As Object, e As EventArgs) Handles btnModSalTemp.Click
        frmModSalTemp.MdiParent = Me
        frmModSalTemp.WindowState = FormWindowState.Maximized
        frmModSalTemp.Show()
        frmModSalTemp.Focus()
    End Sub

    Private Sub mnuPlantas_Click(sender As Object, e As EventArgs) Handles mnuPlantas.Click
        frmPlantas.MdiParent = Me
        frmPlantas.WindowState = FormWindowState.Maximized
        frmPlantas.Show()
        frmPlantas.Focus()
    End Sub

    Private Sub mnuMotivosBaja_Click(sender As Object, e As EventArgs) Handles mnuMotivosBaja.Click
        frmMotivosBajaInternos.MdiParent = Me
        frmMotivosBajaInternos.WindowState = FormWindowState.Maximized
        frmMotivosBajaInternos.Show()
        frmMotivosBajaInternos.Focus()
    End Sub

    Private Sub mnuMotivosBajaIMSS_Click(sender As Object, e As EventArgs) Handles mnuMotivosBajaIMSS.Click
        frmMotivosBajaIMSS.MdiParent = Me
        frmMotivosBajaIMSS.WindowState = FormWindowState.Maximized
        frmMotivosBajaIMSS.Show()
        frmMotivosBajaIMSS.Focus()
    End Sub

    Private Sub btnCambiarClave_Click(sender As Object, e As EventArgs) Handles btnCambiarClave.Click
        frmCambiarClave.ShowDialog(Me)
    End Sub

    Private Sub btnReportes_Click(sender As Object, e As EventArgs) Handles btnRHReportes.Click
        frmReporteador.MdiParent = Me
        frmReporteador.WindowState = FormWindowState.Maximized
        frmReporteador.Show()
        frmReporteador.Focus()
    End Sub


    'Private Sub btnCambiosMasivos_Click(sender As Object, e As EventArgs) Handles btnCambiosMasivos.Click
    '    frmCambiosMasivos.ShowDialog()
    '    frmCambiosMasivos.Focus()
    'End Sub

    Private Sub btnNaturalezaAusentismo_Click(sender As Object, e As EventArgs) Handles btnNaturalezaAusentismo.Click
        frmNaturalezaAusentismo.MdiParent = Me
        frmNaturalezaAusentismo.WindowState = FormWindowState.Maximized
        frmNaturalezaAusentismo.Show()
        frmNaturalezaAusentismo.Focus()
    End Sub

    Private Sub btnTipoAusentismo_Click(sender As Object, e As EventArgs) Handles btnTipoAusentismo.Click
        frmTipoAusentismo.MdiParent = Me
        frmTipoAusentismo.WindowState = FormWindowState.Maximized
        frmTipoAusentismo.Show()
        frmTipoAusentismo.Focus()
    End Sub

    Private Sub btnFestivos_Click(sender As Object, e As EventArgs) Handles btnFestivos.Click
        frmFestivos.MdiParent = Me
        frmFestivos.WindowState = FormWindowState.Maximized
        frmFestivos.Show()
        frmFestivos.Focus()
    End Sub

    Private Sub btnRegistroTA_Click(sender As Object, e As EventArgs) Handles btnRegistroTA.Click
        frmTA.MdiParent = Me
        frmTA.WindowState = FormWindowState.Maximized
        frmTA.Show()
        frmTA.Focus()
    End Sub

    Private Sub btnReporteadorTA_Click(sender As Object, e As EventArgs) Handles btnReporteadorTA.Click
        If frmFiltroReporteador.ShowDialog() = Windows.Forms.DialogResult.OK Then
            frmReporteadorTA.MdiParent = Me
            frmReporteadorTA.WindowState = FormWindowState.Maximized
            frmReporteadorTA.Show()
            frmReporteadorTA.Focus()
        End If
    End Sub

    Private Sub btnKardexAnual_Click(sender As Object, e As EventArgs) Handles btnKardexAnual.Click
        frmKardexAn.MdiParent = Me
        frmKardexAn.WindowState = FormWindowState.Maximized
        frmKardexAn.Show()
        frmKardexAn.Focus()
    End Sub

    Private Sub btnEstilo_Click(sender As Object, e As EventArgs) Handles btnEstilo.Click
        frmEstilo.ShowDialog()
        frmEstilo.Focus()
    End Sub

    Private Sub mnuBanco_Click(sender As Object, e As EventArgs) Handles mnuBanco.Click
        frmBanco.MdiParent = Me
        frmBanco.WindowState = FormWindowState.Maximized
        frmBanco.Show()
        frmBanco.Focus()
    End Sub
    Private Sub rbGeneral_Click(sender As Object, e As EventArgs) Handles rbGeneral.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuRemitentes_Click(sender As Object, e As EventArgs) Handles mnuRemitentes.Click
        frmRemitentes.MdiParent = Me
        frmRemitentes.WindowState = FormWindowState.Maximized
        frmRemitentes.Show()
        frmRemitentes.Focus()
    End Sub

    Private Sub mnuMensajesCartas_Click(sender As Object, e As EventArgs) Handles mnuMensajesCartas.Click
        frmMensajeCartas.MdiParent = Me
        frmMensajeCartas.WindowState = FormWindowState.Maximized
        frmMensajeCartas.Show()
        frmMensajeCartas.Focus()
    End Sub

    Private Sub mnuDestinatarios_Click(sender As Object, e As EventArgs) Handles mnuDestinatarios.Click
        frmDestinatario.MdiParent = Me
        frmDestinatario.WindowState = FormWindowState.Maximized
        frmDestinatario.Show()
        frmDestinatario.Focus()
    End Sub

    Private Sub mnuContratos_Click(sender As Object, e As EventArgs) Handles mnuContratos.Click
        frmRedaccionContrato.MdiParent = Me
        frmRedaccionContrato.WindowState = FormWindowState.Maximized
        frmRedaccionContrato.Show()
        frmRedaccionContrato.Focus()
    End Sub

    Private Sub btnPeriodos_Click(sender As Object, e As EventArgs) Handles btnPeriodos.Click
        frmPeriodos.MdiParent = Me
        frmPeriodos.WindowState = FormWindowState.Maximized
        frmPeriodos.Show()
        frmPeriodos.Focus()
    End Sub



    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        frmProcesarHoras.MdiParent = Me
        frmProcesarHoras.WindowState = FormWindowState.Maximized
        frmProcesarHoras.Show()
        frmProcesarHoras.Focus()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Hola")
    End Sub
    Private Sub mnuDeptos_Click(sender As Object, e As EventArgs) Handles mnuDeptos.Click
        frmDeptos.MdiParent = Me
        frmDeptos.WindowState = FormWindowState.Maximized
        frmDeptos.Show()
        frmDeptos.Focus()
    End Sub


    Private Sub ButtonItem8_Click(sender As Object, e As EventArgs) Handles ButtonItem8.Click
        frmImportaciondatos.Show()
        frmImportaciondatos.Focus()
    End Sub

    Private Sub mnuNaturalezaNomina_Click(sender As Object, e As EventArgs) Handles mnuNaturalezaNomina.Click
        frmNaturalezas.MdiParent = Me
        frmNaturalezas.WindowState = FormWindowState.Maximized
        frmNaturalezas.Show()
        frmNaturalezas.Focus()
    End Sub

    Private Sub mnuPoliza_Click(sender As Object, e As EventArgs) Handles mnuPoliza.Click
        frmPolizas.MdiParent = Me
        frmPolizas.WindowState = FormWindowState.Maximized
        frmPolizas.Show()
        frmPolizas.Focus()
    End Sub

    Private Sub btnMaestroDeducciones_Click(sender As Object, e As EventArgs)
        frmMaestroDeducciones.MdiParent = Me
        frmMaestroDeducciones.WindowState = FormWindowState.Maximized
        frmMaestroDeducciones.Show()
        frmMaestroDeducciones.Focus()
    End Sub

    Private Sub btnAjustes_Click(sender As Object, e As EventArgs) Handles btnAjustes.Click

    End Sub

    Private Sub btnAjustesGrupales_Click(sender As Object, e As EventArgs)
        frmAjustesMasivos.ShowDialog()
        frmAjustesMasivos.Focus()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs)
        frmExportar.ShowDialog()
        frmExportar.Focus()
    End Sub

    Private Sub btnReporteador_Click(sender As Object, e As EventArgs)
        frmReporteadorNomina.MdiParent = Me
        frmReporteadorNomina.WindowState = FormWindowState.Maximized
        frmReporteadorNomina.Show()
        frmReporteadorNomina.Focus()
    End Sub

    Private Sub btnAjustesNomina_Click(sender As Object, e As EventArgs) Handles btnAjustesNomina.Click
        frmAjustesNomina.MdiParent = Me
        frmAjustesNomina.WindowState = FormWindowState.Maximized
        frmAjustesNomina.Show()
        frmAjustesNomina.Focus()
    End Sub

    Private Sub bntExportarAjustes_Click(sender As Object, e As EventArgs) Handles bntExportarAjustes.Click
        frmExportar.ShowDialog()
        frmExportar.Focus()
    End Sub

    Private Sub btnAjustesMasivos_Click(sender As Object, e As EventArgs) Handles btnAjustesMasivos.Click
        frmAjustesMasivos.ShowDialog()
        frmAjustesMasivos.Focus()
    End Sub

    Private Sub btnPrestamos_Click(sender As Object, e As EventArgs) Handles btnPrestamos.Click
        'frmRevisionPrestamos.MdiParent = Me
        'frmRevisionPrestamos.WindowState = FormWindowState.Maximized
        'frmRevisionPrestamos.Show()
        'frmRevisionPrestamos.Focus()

        frmMaestroDeducciones.MdiParent = Me
        frmMaestroDeducciones.WindowState = FormWindowState.Maximized
        frmMaestroDeducciones.Show()
        frmMaestroDeducciones.Focus()
    End Sub

    Private Sub btnSolicitudPrestamo_Click(sender As Object, e As EventArgs) Handles btnSolicitudPrestamo.Click
        frmSolicitudPrestamo.Show(Me)
        frmSolicitudPrestamo.Focus()
    End Sub

    Private Sub btnReporteadorNomina_Click(sender As Object, e As EventArgs) Handles btnReporteadorNomina.Click
        frmNewPeriodosReporteador.Show()
        frmNewPeriodosReporteador.Focus()
    End Sub

    Private Sub btnRecibos_Click(sender As Object, e As EventArgs) Handles btnRecibos.Click
        'frmRecibos.Show(Me)
        'frmRecibos.Focus()

        'MOSTRAR VENTANA PARA SELECCIONAR EMPLEADOS (UNO O TODOS)   20/NOV/20   
        frmCantidadEmpleadosRecibos.Show()
        frmCantidadEmpleadosRecibos.Focus()

    End Sub

    Private Sub btnConsultaMaestro_Click(sender As Object, e As EventArgs) Handles btnConsultaMaestro.Click
        On Error Resume Next
        frmConsultaMaestro.MdiParent = Me
        frmConsultaMaestro.WindowState = FormWindowState.Maximized
        frmConsultaMaestro.Show()
        frmConsultaMaestro.Focus()
    End Sub

    Private Sub mnuPuestos_Click(sender As Object, e As EventArgs) Handles mnuPuestos.Click
        frmPuestos.MdiParent = Me
        frmPuestos.WindowState = FormWindowState.Maximized
        frmPuestos.Show()
        frmPuestos.Focus()
    End Sub

    Private Sub btnPerfiles_Click(sender As Object, e As EventArgs) Handles btnPerfiles.Click
        frmPerfiles.MdiParent = Me
        frmPerfiles.WindowState = FormWindowState.Maximized
        frmPerfiles.Show()
        frmPerfiles.Focus()
    End Sub

    Private Sub btnOpciones_Click(sender As Object, e As EventArgs) Handles btnParametros.Click
        frmParametros.MdiParent = Me
        frmParametros.WindowState = FormWindowState.Maximized
        frmParametros.Show()
        frmParametros.Focus()
    End Sub

    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        frmUsuarios.MdiParent = Me
        frmUsuarios.WindowState = FormWindowState.Maximized
        frmUsuarios.Show()
        frmUsuarios.Focus()
    End Sub

    Private Sub rpPersonal_Click(sender As Object, e As EventArgs) Handles rpPersonal.Click

    End Sub

    Private Sub btnNomina_Click(sender As Object, e As EventArgs) Handles btnNomina.Click
        frmNomina.MdiParent = Me
        frmNomina.WindowState = FormWindowState.Maximized
        frmNomina.Show()
        frmNomina.Focus()
    End Sub

    Private Sub btnImportacion_Click(sender As Object, e As EventArgs)
        frmImportaciondatos.ShowDialog()
        frmImportaciondatos.Focus()
    End Sub

    Private Sub mnuConceptosNomina_Click(sender As Object, e As EventArgs) Handles mnuConceptosNomina.Click
        frmConceptos.MdiParent = Me
        frmConceptos.WindowState = FormWindowState.Maximized
        frmConceptos.Show()
        frmConceptos.Focus()
    End Sub


    Private Sub btnCursos_Click(sender As Object, e As EventArgs) Handles btnCursos.Click
        frmCursos.MdiParent = Me
        frmCursos.WindowState = FormWindowState.Maximized
        frmCursos.Show()
        frmCursos.Focus()
    End Sub

    Private Sub btnInstitutos_Click(sender As Object, e As EventArgs) Handles btnInstitutos.Click
        frmInstitutos.MdiParent = Me
        frmInstitutos.WindowState = FormWindowState.Maximized
        frmInstitutos.Show()
        frmInstitutos.Focus()
    End Sub

    Private Sub btnInstructores_Click(sender As Object, e As EventArgs) Handles btnInstructores.Click
        frmInstructores.MdiParent = Me
        frmInstructores.WindowState = FormWindowState.Maximized
        frmInstructores.Show()
        frmInstructores.Focus()
    End Sub

    Private Sub btnCursosEmpleado_Click(sender As Object, e As EventArgs) Handles btnCursosEmpleado.Click
        frmConsulta.MdiParent = Me
        frmConsulta.WindowState = FormWindowState.Maximized
        frmConsulta.Show()
        frmConsulta.Focus()
    End Sub

    Private Sub btnObjetivos_Click(sender As Object, e As EventArgs) Handles btnObjetivos.Click
        frmObjetivos.MdiParent = Me
        frmObjetivos.WindowState = FormWindowState.Maximized
        frmObjetivos.Show()
        frmObjetivos.Focus()
    End Sub

    Private Sub btnArea_Click(sender As Object, e As EventArgs) Handles btnArea.Click
        frmAreasTematicas.MdiParent = Me
        frmAreasTematicas.WindowState = FormWindowState.Maximized
        frmAreasTematicas.Show()
        frmAreasTematicas.Focus()
    End Sub

    Private Sub btnClasificaciones_Click(sender As Object, e As EventArgs) Handles btnClasificaciones.Click
        frmClasificacionCursos.MdiParent = Me
        frmClasificacionCursos.WindowState = FormWindowState.Maximized
        frmClasificacionCursos.Show()
        frmClasificacionCursos.Focus()
    End Sub

    Private Sub btnModalidades_Click(sender As Object, e As EventArgs) Handles btnModalidades.Click
        frmModalidades.MdiParent = Me
        frmModalidades.WindowState = FormWindowState.Maximized
        frmModalidades.Show()
        frmModalidades.Focus()
    End Sub

    Private Sub btnCargaGrupal_Click(sender As Object, e As EventArgs) Handles btnCargaGrupal.Click
        frmCapturaCursosTemp.MdiParent = Me
        frmCapturaCursosTemp.WindowState = FormWindowState.Maximized
        frmCapturaCursosTemp.Show()
        frmCapturaCursosTemp.Focus()
    End Sub

    Private Sub btnPlaneacion_Click(sender As Object, e As EventArgs) Handles btnPlaneacion.Click
        frmPlaneacion.MdiParent = Me
        frmPlaneacion.WindowState = FormWindowState.Maximized
        frmPlaneacion.Show()
        frmPlaneacion.Focus()
    End Sub

    Private Sub btnReporteadorCapacitacion_Click(sender As Object, e As EventArgs) Handles btnReporteadorCapacitacion.Click
        frmReporteadorCapacitacion.MdiParent = Me
        frmReporteadorCapacitacion.WindowState = FormWindowState.Maximized
        frmReporteadorCapacitacion.Show()
        frmReporteadorCapacitacion.Focus()
    End Sub

    Private Sub btnClasificacionHerramientas_Click(sender As Object, e As EventArgs) Handles btnClasificacionHerramientas.Click
        frmClasificacionesHerramientas.MdiParent = Me
        frmClasificacionesHerramientas.WindowState = FormWindowState.Maximized
        frmClasificacionesHerramientas.Show()
        frmClasificacionesHerramientas.Focus()
    End Sub

    Private Sub btnHerramientas_Click(sender As Object, e As EventArgs) Handles btnHerramientas.Click
        frmHerramientas.MdiParent = Me
        frmHerramientas.WindowState = FormWindowState.Maximized
        frmHerramientas.Show()
        frmHerramientas.Focus()
    End Sub

    Private Sub btnUniformes_Click(sender As Object, e As EventArgs) Handles btnUniformes.Click
        frmUniformes.MdiParent = Me
        frmUniformes.WindowState = FormWindowState.Maximized
        frmUniformes.Show()
        frmUniformes.Focus()
    End Sub

    Private Sub btnReporteadorHerramientas_Click(sender As Object, e As EventArgs) Handles btnReporteadorHerramientas.Click
        frmReporteadorHerramientas.MdiParent = Me
        frmReporteadorHerramientas.WindowState = FormWindowState.Maximized
        frmReporteadorHerramientas.Show()
        frmReporteadorHerramientas.Focus()
    End Sub

    Private Sub btnPrestamoHerramientas_Click(sender As Object, e As EventArgs) Handles btnPrestamoHerramientas.Click
        frmPrestamoGlobalH.MdiParent = Me
        frmPrestamoGlobalH.WindowState = FormWindowState.Maximized
        frmPrestamoGlobalH.Show()
        frmPrestamoGlobalH.Focus()
    End Sub

    Private Sub btnPrestamoUniformes_Click(sender As Object, e As EventArgs) Handles btnPrestamoUniformes.Click
        frmPrestamoGlobalU.MdiParent = Me
        frmPrestamoGlobalU.WindowState = FormWindowState.Maximized
        frmPrestamoGlobalU.Show()
        frmPrestamoGlobalU.Focus()
    End Sub

    Private Sub btnHerramientasEmpleado_Click(sender As Object, e As EventArgs) Handles btnHerramientasEmpleado.Click
        frmHerramientasPersonal.MdiParent = Me
        frmHerramientasPersonal.WindowState = FormWindowState.Maximized
        frmHerramientasPersonal.Show()
        frmHerramientasPersonal.Focus()
    End Sub

    Private Sub btnUniformesEmpleado_Click(sender As Object, e As EventArgs) Handles btnUniformesEmpleado.Click
        frmUniformesPersonal.MdiParent = Me
        frmUniformesPersonal.WindowState = FormWindowState.Maximized
        frmUniformesPersonal.Show()
        frmUniformesPersonal.Focus()
    End Sub

    Private Sub mnuCuestionarios_Click(sender As Object, e As EventArgs) Handles mnuCuestionarios.Click
        frmCuestionarios.MdiParent = Me
        frmCuestionarios.WindowState = FormWindowState.Maximized
        frmCuestionarios.Show()
        frmCuestionarios.Focus()
    End Sub

    Private Sub mnuEvaluaciones_Click(sender As Object, e As EventArgs) Handles mnuEvaluaciones.Click
        frmEvaluaciones.MdiParent = Me
        frmEvaluaciones.WindowState = FormWindowState.Maximized
        frmEvaluaciones.Show()
        frmEvaluaciones.Focus()
    End Sub

    Private Sub mnuRespuestas_Click(sender As Object, e As EventArgs) Handles mnuRespuestas.Click
        frmRespuestas.MdiParent = Me
        frmRespuestas.WindowState = FormWindowState.Maximized
        frmRespuestas.Show()
        frmRespuestas.Focus()
    End Sub

    Private Sub btnHabilidades_Click(sender As Object, e As EventArgs) Handles btnHabilidades.Click
        frmEvaluacionEmpleados.MdiParent = Me
        frmEvaluacionEmpleados.WindowState = FormWindowState.Maximized
        frmEvaluacionEmpleados.Show()
        frmEvaluacionEmpleados.Focus()
    End Sub

    Private Sub btnRHCatalogo_Click(sender As Object, e As EventArgs) Handles btnRHCatalogo.Click

    End Sub

    Private Sub btnImportarHoras_Click(sender As Object, e As EventArgs)
        Try
            Dim dtPath As New DataTable
            Dim Archivo As String

            'Inhabilitar la forma para que no pueda seleccionar otro proceso mientras se completa la importación
            Me.Enabled = False
            dtPath = sqlExecute("SELECT path_hrs FROM parametros")
            If dtPath.Rows.Count = 0 Then
                Archivo = ""
            Else
                Archivo = IIf(IsDBNull(dtPath.Rows(0).Item(0)), "", dtPath.Rows(0).Item(0).ToString.Trim)
            End If

            frmImportacion.ImportaAnoPer = ObtenerAnoPeriodo(DateAdd(DateInterval.Day, -7, Now))
            frmImportacion.ImportaArchivo = Archivo
            frmImportacion.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Se detectaron errores durante la importación." & vbCrLf & "Error.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    Private Sub btnRecibosCFDI_Click(sender As Object, e As EventArgs) Handles btnRecibosCFDI.Click
        frmRecibosCFDI.ShowDialog()
    End Sub

    Private Sub btnFacturacion_Click(sender As Object, e As EventArgs)
        frmFacturacion.ShowDialog()
    End Sub

    Private Sub mnuCias_Click(sender As Object, e As EventArgs) Handles mnuCias.Click
        frmCias.MdiParent = Me
        frmCias.WindowState = FormWindowState.Maximized
        frmCias.Show()
        frmCias.Focus()
    End Sub

    Private Sub btnSuplentes_Click(sender As Object, e As EventArgs) Handles btnSuplentes.Click
        frmSuplentes.MdiParent = Me
        frmSuplentes.WindowState = FormWindowState.Maximized
        frmSuplentes.Show()
        frmSuplentes.Focus()
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        frmPrestacionesConBeneficiarios.MdiParent = Me
        frmPrestacionesConBeneficiarios.WindowState = FormWindowState.Maximized
        frmPrestacionesConBeneficiarios.Show()
        frmPrestacionesConBeneficiarios.Focus()
    End Sub


    Private Sub btnAutorizacionTESupervisor_Click(sender As Object, e As EventArgs)
        frmAutorizacionTiempoExtra.MdiParent = Me
        frmAutorizacionTiempoExtra.WindowState = FormWindowState.Maximized
        frmAutorizacionTiempoExtra.Show()
        frmAutorizacionTiempoExtra.Focus()
    End Sub

    Private Sub btnCargaMasivaAuxiliares_Click(sender As Object, e As EventArgs)
        Try
            Dim frm As New frmCargaMasivaAuxiliares
            frm.ShowDialog()
            frm.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCapturaMultiforma_Click(sender As Object, e As EventArgs)
        frmMultiforma.MdiParent = Me
        frmMultiforma.WindowState = FormWindowState.Maximized
        frmMultiforma.Show()
        frmMultiforma.Focus()
    End Sub

    Private Sub btnAplicacionMultiforma_Click(sender As Object, e As EventArgs)
        frmMultiformaAplicacion.MdiParent = Me
        frmMultiformaAplicacion.WindowState = FormWindowState.Maximized
        frmMultiformaAplicacion.Show()
        frmMultiformaAplicacion.Focus()
    End Sub

    Private Sub btnAreas_Click(sender As Object, e As EventArgs) Handles btnAreas.Click
        frmAreas.MdiParent = Me
        frmAreas.WindowState = FormWindowState.Maximized
        frmAreas.Show()
        frmAreas.Focus()
    End Sub

    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click
        frmCentroCostos.MdiParent = Me
        frmCentroCostos.WindowState = FormWindowState.Maximized
        frmCentroCostos.Show()
        frmCentroCostos.Focus()
    End Sub

    Private Sub btnTAlloc_Click(sender As Object, e As EventArgs) Handles btnTAlloc.Click
        frmTimeAllocation.MdiParent = Me
        frmTimeAllocation.WindowState = FormWindowState.Maximized
        frmTimeAllocation.Show()
        frmTimeAllocation.Focus()
    End Sub

    Private Sub btnReporteadorTAlloc_Click(sender As Object, e As EventArgs) Handles btnReporteadorTAlloc.Click
        If frmFiltroReporteador.ShowDialog() = Windows.Forms.DialogResult.OK Then
            frmReporteadorTAlloc.MdiParent = Me
            frmReporteadorTAlloc.WindowState = FormWindowState.Maximized
            frmReporteadorTAlloc.Show()
            frmReporteadorTAlloc.Focus()
        End If
    End Sub

    Private Sub btnConsultaTAlloc_Click(sender As Object, e As EventArgs) Handles btnConsultaTAlloc.Click
        frmTimeAllocationConsulta.MdiParent = Me
        frmTimeAllocationConsulta.WindowState = FormWindowState.Maximized
        frmTimeAllocationConsulta.Show()
        frmTimeAllocationConsulta.Focus()
    End Sub
    Private Sub btnSubMot_Click(sender As Object, e As EventArgs) Handles btnSubMot.Click
        frmSubmotivosBaja.MdiParent = Me
        frmSubmotivosBaja.WindowState = FormWindowState.Maximized
        frmSubmotivosBaja.Show()
        frmSubmotivosBaja.Focus()
    End Sub

    Private Sub btnGuardarSAPAlloc_Click(sender As Object, e As EventArgs) Handles btnGuardarSAPAlloc.Click
        GeneraArchivoSAP(Me)
    End Sub

    Private Sub btnCargarSAPJobs_Click(sender As Object, e As EventArgs) Handles btnCargarSAPJobs.Click
        Try
            Dim NumOrden As String
            Dim NomOrden As String
            Dim strFileName As String = ""
            Dim Linea As String
            Dim Inicio As Boolean = False
            Dim Insertadas As Integer = 0
            Dim Actualizadas As Integer = 0

            Dim dtInfoTAlloc As New DataTable
            Dim ArchivoJOBS As System.IO.StreamReader
            Dim AbreArchivo As Boolean

            Dim PreguntaArchivo As New Windows.Forms.OpenFileDialog

            PreguntaArchivo.Filter = "Text file|*.txt"
            PreguntaArchivo.FileName = ""
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            End If

            Try
                ArchivoJOBS = System.IO.File.OpenText(strFileName)
                AbreArchivo = True
            Catch ex As Exception
                ArchivoJOBS = Nothing
                AbreArchivo = False
            End Try

            Do Until ArchivoJOBS.EndOfStream
                Linea = ArchivoJOBS.ReadLine

                If Inicio Then
                    If Linea.Length > 125 Then
                        NumOrden = Linea.Substring(0, 9)
                        NomOrden = Linea.Substring(125)

                        dtInfoTAlloc = sqlExecute("SELECT cod_orden FROM ordenes_trabajo WHERE cod_orden = '" & NumOrden.Trim & "'", "TA")
                        If dtInfoTAlloc.Rows.Count > 0 Then
                            sqlExecute("UPDATE ordenes_trabajo SET nombre = '" & NomOrden.Trim & "', closing_date = NULL " & _
                                       "WHERE cod_orden = '" & NumOrden.Trim & "'", "TA")
                            Actualizadas += 1
                        Else
                            sqlExecute("INSERT INTO ordenes_trabajo (cod_orden,nombre,opening_date) VALUES ('" & _
                                       NumOrden.Trim & "','" & NomOrden.Trim & "',GETDATE())", "TA")
                            Insertadas += 1
                        End If
                    End If

                    '1-9 = Numero de orden
                    '10-14 = Puntos (ignorar)
                    '15-31 = Descripción Corta (ignorar)
                    '32-53 = Ceros  (ignorar)
                    '54-67 = Espacios  (ignorar)
                    '68-76 = Ceros  (ignorar)
                    '77-77 = Espacios  (ignorar)
                    '78-92 = Nombre Gerente  (ignorar)
                    '93-97 = Ceros  (ignorar)
                    '98-119 = Espacios  (ignorar)
                    '120-125 = Ceros  (ignorar)
                    '126-170= Descripción Larga 
                End If

                If Not Inicio And Linea.Length >= 6 Then
                    If Linea.Substring(0, 6) = "FORMAT" Then
                        Inicio = True
                    End If
                End If
            Loop
            ArchivoJOBS.Close()

            MessageBox.Show("Se insertaron " & Insertadas & " y se actualizaron " & Actualizadas & " órdenes satisfactoriamente.", "Actualizar órdenes", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub RibbonBar1_ItemClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub rpSeguridad_Click(sender As Object, e As EventArgs) Handles rpSeguridad.Click

    End Sub

    Private Sub btnErrorLog_Click(sender As Object, e As EventArgs)
        Try
            frmErrorLog.MdiParent = Me
            frmErrorLog.WindowState = FormWindowState.Maximized
            frmErrorLog.Show()
            frmErrorLog.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles btnCapturaIdeas.Click
        Try
            frmCapturaIdeas.MdiParent = Me
            frmCapturaIdeas.WindowState = FormWindowState.Maximized
            frmCapturaIdeas.Show()
            frmCapturaIdeas.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles btnReporteadorIdeas.Click
        Try
            If frmFiltroReporteadorIDEAS.ShowDialog() = Windows.Forms.DialogResult.OK Then
                frmReporteadorIdeas.MdiParent = Me
                frmReporteadorIdeas.WindowState = FormWindowState.Maximized
                frmReporteadorIdeas.Show()
                frmReporteadorIdeas.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem12_Click(sender As Object, e As EventArgs) Handles btnDesperdiciosIdeas.Click
        Try
            frmDesperdicios.MdiParent = Me
            frmDesperdicios.WindowState = FormWindowState.Maximized
            frmDesperdicios.Show()
            frmDesperdicios.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem13_Click(sender As Object, e As EventArgs) Handles btnEstacionesTrabajo.Click
        Try
            frmEstacionesTrabajo.MdiParent = Me
            frmEstacionesTrabajo.WindowState = FormWindowState.Maximized
            frmEstacionesTrabajo.Show()
            frmEstacionesTrabajo.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem14_Click(sender As Object, e As EventArgs) Handles btnObjetivosIdeas.Click
        Try
            frmObjetivosIdea.MdiParent = Me
            frmObjetivosIdea.WindowState = FormWindowState.Maximized
            frmObjetivosIdea.Show()
            frmObjetivosIdea.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSoloConsulta_Click(sender As Object, e As EventArgs)
        Try
            frmConsultaPersonal.MdiParent = Me
            frmConsultaPersonal.WindowState = FormWindowState.Maximized
            frmConsultaPersonal.Show()
            frmConsultaPersonal.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPagoIdeas_Click(sender As Object, e As EventArgs) Handles btnPagoIdeas.Click
        Try
            frmIdeasAPago.MdiParent = Me
            frmIdeasAPago.WindowState = FormWindowState.Maximized
            frmIdeasAPago.Show()
            frmIdeasAPago.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Herramientas_Click(sender As Object, e As EventArgs) Handles Herramientas.Click

    End Sub

    Private Sub btnExpediente_Click(sender As Object, e As EventArgs) Handles btnExpediente.Click
        Try
            frmExpedientePersonal.MdiParent = Me
            frmExpedientePersonal.WindowState = FormWindowState.Maximized
            frmExpedientePersonal.Show()
            frmExpedientePersonal.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnConsultas_Click(sender As Object, e As EventArgs) Handles btnConsultas.Click
        Try
            frmConsultas.MdiParent = Me
            frmConsultas.WindowState = FormWindowState.Maximized
            frmConsultas.Show()
            frmConsultas.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem2_Click_1(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        Try
            If frmFiltroReporteador.ShowDialog = Windows.Forms.DialogResult.OK Then
                frmReporteadorSermed.MdiParent = Me
                frmReporteadorSermed.WindowState = FormWindowState.Maximized
                frmReporteadorSermed.Show()
                frmReporteadorSermed.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOrdenesTrabajo_Click(sender As Object, e As EventArgs) Handles btnOrdenesTrabajo.Click
        frmOrdenesTrabajo.MdiParent = Me
        frmOrdenesTrabajo.WindowState = FormWindowState.Maximized
        frmOrdenesTrabajo.Show()
        frmOrdenesTrabajo.Focus()
    End Sub

    Private Sub btnSintomas_Click(sender As Object, e As EventArgs) Handles btnSintomas.Click
        frmSintomas.MdiParent = Me
        frmSintomas.WindowState = FormWindowState.Maximized
        frmSintomas.Show()
        frmSintomas.Focus()
    End Sub

    Private Sub btnGrupos_Click(sender As Object, e As EventArgs) Handles btnGrupos.Click
        frmGrupos.MdiParent = Me
        frmGrupos.WindowState = FormWindowState.Maximized
        frmGrupos.Show()
        frmGrupos.Focus()
    End Sub

    Private Sub btnGafete_Click(sender As Object, e As EventArgs) Handles btnGafete.Click
        frmGafetes.MdiParent = Me
        frmGafetes.WindowState = FormWindowState.Maximized
        frmGafetes.Show()
        frmGafetes.Focus()
    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs)
        Dim frm As New frmHorasMasivas
        frm.ShowDialog()
    End Sub

    Private Sub ButtonItemAjustesTA_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnExternos_Click(sender As Object, e As EventArgs) Handles btnExternos.Click
        frmCatExternos.MdiParent = Me
        frmCatExternos.WindowState = FormWindowState.Maximized
        frmCatExternos.Show()
        frmCatExternos.Focus()
    End Sub

    Private Sub ButtonItem7_Click(sender As Object, e As EventArgs) Handles ButtonItem7.Click
        frmBitacoraEnfermeria.MdiParent = Me
        frmBitacoraEnfermeria.WindowState = FormWindowState.Maximized
        frmBitacoraEnfermeria.Show()
        frmBitacoraEnfermeria.Focus()
    End Sub

    Private Sub ButtonItem9_Click(sender As Object, e As EventArgs) Handles ButtonItem9.Click
        frmCatArbolSintomas.MdiParent = Me
        frmCatArbolSintomas.WindowState = FormWindowState.Maximized
        frmCatArbolSintomas.Show()
        frmCatArbolSintomas.Focus()
    End Sub

    Private Sub ButtonItem10_Click(sender As Object, e As EventArgs)
        Dim frm As New frmCargaExcelVacaciones
        frm.ShowDialog()
    End Sub

    Private Sub btnAccionDisciplinaria_Click(sender As Object, e As EventArgs) Handles btnAccionDisciplinaria.Click
        frmMedidaAccionDisciplinaria.MdiParent = Me
        frmMedidaAccionDisciplinaria.WindowState = FormWindowState.Maximized
        frmMedidaAccionDisciplinaria.Show()
        frmMedidaAccionDisciplinaria.Focus()

    End Sub

    Private Sub mnuTipoDisciplinaria_Click(sender As Object, e As EventArgs) Handles mnuTipoDisciplinaria.Click
        frmTipoDisciplinario.MdiParent = Me
        frmTipoDisciplinario.WindowState = FormWindowState.Maximized
        frmTipoDisciplinario.Show()
        frmTipoDisciplinario.Focus()
    End Sub

    Private Sub mnuMotivoAccionDisciplinaria_Click(sender As Object, e As EventArgs) Handles mnuMotivoAccionDisciplinaria.Click
        frmMotivoAccionDisciplinaria.MdiParent = Me
        frmMotivoAccionDisciplinaria.WindowState = FormWindowState.Maximized
        frmMotivoAccionDisciplinaria.Show()
        frmMotivoAccionDisciplinaria.Focus()
    End Sub

    Private Sub btnLockers_Click(sender As Object, e As EventArgs) Handles btnLockers.Click
        frmLockers.MdiParent = Me
        frmLockers.WindowState = FormWindowState.Maximized
        frmLockers.Show()
        frmLockers.Focus()
    End Sub

    Private Sub btnCambiosMasivos_Click(sender As Object, e As EventArgs)
        Dim frm As New frmCargaExcelVacaciones
        frm.ShowDialog()
    End Sub

    Private Sub mnuRepresentantes_Click(sender As Object, e As EventArgs) Handles mnuRepresentantes.Click
        frmRepresentantes.MdiParent = Me
        frmRepresentantes.WindowState = FormWindowState.Maximized
        frmRepresentantes.Show()
        frmRepresentantes.Focus()



    End Sub

    Private Sub ButtonItem10_Click_1(sender As Object, e As EventArgs) Handles ButtonItem10.Click
        Dim frm As New frmPeriodosReporteador
        frm.siguiente = 1
        frm.Show()
        frm.Focus()
    End Sub
    Private Sub btnHorariosCafeteria_Click(sender As Object, e As EventArgs) Handles btnHorariosCafeteria.Click
        frmHorariosCafeteria.MdiParent = Me
        frmHorariosCafeteria.WindowState = FormWindowState.Maximized
        frmHorariosCafeteria.Show()
        frmHorariosCafeteria.Focus()
    End Sub

    Private Sub btnPlatillosCafeteria_Click(sender As Object, e As EventArgs) Handles btnParametrosCafeteria.Click
        frmParametrosCafe.MdiParent = Me
        frmParametrosCafe.WindowState = FormWindowState.Maximized
        frmParametrosCafe.Show()
        frmParametrosCafe.Focus()
    End Sub

    Private Sub btnMenusCafeteria_Click(sender As Object, e As EventArgs) Handles btnMenusCafeteria.Click
        frmMenuCafeteria.MdiParent = Me
        frmMenuCafeteria.WindowState = FormWindowState.Maximized
        frmMenuCafeteria.Show()
        frmMenuCafeteria.Focus()
    End Sub

    Private Sub btnSincronizacionCafeteria_Click(sender As Object, e As EventArgs) Handles btnProgramacionCafeteria.Click
        frmProgramacionMenu.MdiParent = Me
        frmProgramacionMenu.WindowState = FormWindowState.Maximized
        frmProgramacionMenu.Show()
        frmProgramacionMenu.Focus()
    End Sub

    Private Sub bntDispositivosCafeteria_Click(sender As Object, e As EventArgs) Handles bntDispositivosCafeteria.Click
        frmDispositivosCafeteria.MdiParent = Me
        frmDispositivosCafeteria.WindowState = FormWindowState.Maximized
        frmDispositivosCafeteria.Show()
        frmDispositivosCafeteria.Focus()
    End Sub

    Private Sub btnResumenCafeteria_Click(sender As Object, e As EventArgs) Handles btnResumenCafeteria.Click
        frmResumenCafeteria.MdiParent = Me
        frmResumenCafeteria.WindowState = FormWindowState.Maximized
        frmResumenCafeteria.Show()
        frmResumenCafeteria.Focus()
    End Sub

    Private Sub btnReporteadorCafeteria_Click(sender As Object, e As EventArgs) Handles btnReporteadorCafeteria.Click
        Try
            If frmFiltroReporteadorCafeteria.ShowDialog() = Windows.Forms.DialogResult.OK Then
                frmReporteadorCafeteria.MdiParent = Me
                frmReporteadorCafeteria.WindowState = FormWindowState.Maximized
                frmReporteadorCafeteria.Show()
                frmReporteadorCafeteria.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem13_Click_1(sender As Object, e As EventArgs) Handles ButtonItem13.Click
        'frmProgramacionVacaciones.MdiParent = Me
        'frmProgramacionVacaciones.WindowState = FormWindowState.Maximized
        'frmProgramacionVacaciones.Show()
        'frmProgramacionVacaciones.Focus()

        'frmAutorizacionTiempoExtraPeriodoAdmin.MdiParent = Me
        'frmAutorizacionTiempoExtraPeriodoAdmin.WindowState = FormWindowState.Maximized
        'frmAutorizacionTiempoExtraPeriodoAdmin.Show()
        'frmAutorizacionTiempoExtraPeriodoAdmin.Focus()
        frmAutorizacionTiempoExtraPeriodo_Salary.MdiParent = Me
        frmAutorizacionTiempoExtraPeriodo_Salary.WindowState = FormWindowState.Maximized
        frmAutorizacionTiempoExtraPeriodo_Salary.Show()
        frmAutorizacionTiempoExtraPeriodo_Salary.Focus()


    End Sub

    Private Sub ButtonItem14_Click_1(sender As Object, e As EventArgs)
        Dim frm As New frmCargaExcelVacaciones
        frm.ShowDialog()
    End Sub

    '== Comentado                               3mar22          Ernesto
    'Private Sub ButtonItem15_Click(sender As Object, e As EventArgs) Handles ButtonItem15.Click
    '    frmOtrasSolicitudes.MdiParent = Me
    '    frmOtrasSolicitudes.WindowState = FormWindowState.Maximized
    '    frmOtrasSolicitudes.Show()
    '    frmOtrasSolicitudes.Focus()
    'End Sub

    Private Sub ButtonItem16_Click(sender As Object, e As EventArgs) Handles ButtonItem16.Click
        frmAutorizacionTiempoExtraPeriodo.MdiParent = Me
        frmAutorizacionTiempoExtraPeriodo.WindowState = FormWindowState.Maximized
        frmAutorizacionTiempoExtraPeriodo.Show()
        frmAutorizacionTiempoExtraPeriodo.Focus()
    End Sub

    Private Sub ButtonItem17_Click(sender As Object, e As EventArgs) Handles ButtonItem17.Click
        'frmExcepcionHorarios.MdiParent = Me
        'frmExcepcionHorarios.WindowState = FormWindowState.Maximized
        'frmExcepcionHorarios.Show()
        'frmExcepcionHorarios.Focus()
    End Sub

    Private Sub ButtonItem20_Click_1(sender As Object, e As EventArgs)
        frmAusentismoGlobal.Show()
        frmAusentismoGlobal.Focus()
    End Sub



    Private Sub ButtonItem18_Click(sender As Object, e As EventArgs) Handles ButtonItem18.Click
        frmComparaPeriodos.MdiParent = Me
        frmComparaPeriodos.WindowState = FormWindowState.Maximized
        frmComparaPeriodos.Show()
        frmComparaPeriodos.Focus()
    End Sub

    Private Sub btnAusentismoMasivo_Click(sender As Object, e As EventArgs) Handles btnAusentismoMasivo.Click
        frmAusentismoGlobal.Show()
        frmAusentismoGlobal.Focus()
    End Sub

    Private Sub btnRetardoTrans_Click(sender As Object, e As EventArgs) Handles btnRetardoTrans.Click
        frmRetardoTransporte.Show()
        frmRetardoTransporte.Focus()
    End Sub
    Private Sub Compensaciones_Click(sender As Object, e As EventArgs) Handles Compensaciones.Click
        frmCompensaciones.MdiParent = Me
        frmCompensaciones.WindowState = FormWindowState.Maximized
        frmCompensaciones.Show()
        frmCompensaciones.Focus()
    End Sub

    'Private Sub ButtonItem14_Click_2(sender As Object, e As EventArgs) Handles ButtonItem14.Click
    '    Try
    '        If frmFiltroReporteador.ShowDialog() = Windows.Forms.DialogResult.OK Then

    '            frmTrabajando.Show()
    '            Application.DoEvents()

    '            Dim _campos_tavw As String = "*"
    '            Dim dtquery As DataTable = sqlExecute("select * from kiosco.dbo.variables where variable = 'QUERY_TA'")
    '            If dtquery.Rows.Count > 0 Then
    '                _campos_tavw = dtquery.Rows(0)("valor")
    '            End If
    '            Dim dtIncidencias As DataTable = sqlExecute("SELECT " & _campos_tavw & " FROM TAVW WHERE FHA_ENT_HOR between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' " & IIf(FiltroXUsuario.Trim = "", "", " AND " & FiltroXUsuario), "ta")


    '            ActivoTrabajando = False
    '            frmTrabajando.Close()

    '            frmVistaPrevia.LlamarReporte("Revisión incidencias clerk", dtIncidencias)
    '            frmVistaPrevia.ShowDialog()

    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Se presentó un problema al generar el reporte de incidencias", "Reporte de incidencias", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
    '        ActivoTrabajando = False
    '        frmTrabajando.Close()
    '    End Try
    'End Sub

    Private Sub ButtonItem14_Click_2(sender As Object, e As EventArgs) Handles ButtonItem14.Click
        Try
            If frmFiltroReporteador.ShowDialog() = Windows.Forms.DialogResult.OK Then

                frmTrabajando.Show()
                Application.DoEvents()

                Dim _campos_tavw As String = "*"
                Dim dtquery As DataTable = sqlExecute("select * from kiosco.dbo.variables where variable = 'QUERY_TA'")
                If dtquery.Rows.Count > 0 Then
                    _campos_tavw = dtquery.Rows(0)("valor")
                End If
                Dim dtIncidencias As DataTable = sqlExecute("SELECT " & _campos_tavw & " FROM TAVW WHERE FHA_ENT_HOR between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' " & IIf(FiltroXUsuario.Trim = "", "", " AND " & FiltroXUsuario), "ta")


                dtIncidencias.Columns.Add("incluir_en_reporte", Type.GetType("System.Int32"))

                For Each row As DataRow In dtIncidencias.Rows

                    frmTrabajando.lblAvance.Text = row("reloj")
                    Application.DoEvents()

                    row("incluir_en_reporte") = 0

                    Dim comentario As String = IIf(IsDBNull(row("comentario")), "", row("comentario")).ToString.ToUpper.Trim
                    Dim tipo_aus As String = IIf(IsDBNull(row("tipo_aus")), "", row("tipo_aus")).ToString.ToUpper.Trim

                    Dim entro As String = IIf(IsDBNull(row("entro")), "", row("entro")).ToString.ToUpper.Trim
                    Dim salio As String = IIf(IsDBNull(row("salio")), "", row("salio")).ToString.ToUpper.Trim

                    'Falta entrada y falta salida
                    If comentario.Contains("FALTA") Then
                        row("incluir_en_reporte") = 1
                    End If

                    'Retardos y salidas anticiapdas
                    If comentario.Contains("RETARDO") Or comentario.Contains("SALIDA ANTICIPADA") Then
                        row("incluir_en_reporte") = 1
                    End If

                    'Retardos y salidas anticiapdas
                    If comentario.Contains("EXCEPCIONES") Then
                        row("incluir_en_reporte") = 1
                    End If

                    ' Faltas injustificadas
                    If (tipo_aus = "FI") Then
                        row("incluir_en_reporte") = 1
                    End If

                    ' Incapacidades generales
                    If (tipo_aus = "ING") Then
                        row("incluir_en_reporte") = 1
                    End If
                    'Conveio 50%
                    'If (tipo_aus = "C50") Then
                    '    row("incluir_en_reporte") = 1
                    'End If

                    'Todos los ausentismo con asistencia
                    If (tipo_aus <> "" And (entro <> "" Or salio <> "")) Then
                        row("incluir_en_reporte") = 1

                        row("comentario") = "* " & comentario
                    End If


                Next

                ActivoTrabajando = False
                frmTrabajando.Close()

                'frmVistaPrevia.LlamarReporte("Revisión incidencias clerk", dtIncidencias.Select("incluir_en_reporte = 1").CopyToDataTable)
                frmVistaPrevia.LlamarReporte("Revisión incidencias", dtIncidencias.Select("incluir_en_reporte = 1").CopyToDataTable)
                frmVistaPrevia.ShowDialog()

            End If
        Catch ex As Exception
            MessageBox.Show("Se presentó un problema al generar el reporte de incidencias", "Reporte de incidencias", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            ActivoTrabajando = False
            frmTrabajando.Close()
        End Try
    End Sub

    Private Sub btnExportarPR_Click(sender As Object, e As EventArgs) Handles btnExportarPR.Click
        frmAprobacionRetirosPrestamos.MdiParent = Me

        frmAprobacionRetirosPrestamos.WindowState = FormWindowState.Maximized
        frmAprobacionRetirosPrestamos.Show()
        frmAprobacionRetirosPrestamos.Focus()
    End Sub

    Private Sub ButtonItem19_Click(sender As Object, e As EventArgs) Handles ButtonItem19.Click
        frmFiniquitos.MdiParent = Me
        frmFiniquitos.WindowState = FormWindowState.Maximized
        frmFiniquitos.Show()
        frmFiniquitos.Focus()
    End Sub

    Private Sub btnReporteadorAUS_Click(sender As Object, e As EventArgs) Handles btnReporteadorAUS.Click
        If frmFiltroReporteador.ShowDialog() = Windows.Forms.DialogResult.OK Then
            frmReporteadorAUS.MdiParent = Me
            frmReporteadorAUS.WindowState = FormWindowState.Maximized
            frmReporteadorAUS.Show()
            frmReporteadorAUS.Focus()
        End If
    End Sub

    Private Sub ButtonItem22_Click(sender As Object, e As EventArgs) Handles ButtonItem22.Click
        frmProgramacionVacaciones.MdiParent = Me
        frmProgramacionVacaciones.WindowState = FormWindowState.Maximized
        frmProgramacionVacaciones.Show()
        frmProgramacionVacaciones.Focus()
    End Sub

    Private Sub ButtonItem23_Click(sender As Object, e As EventArgs) Handles ButtonItem23.Click
        Dim frm As New frmCargaExcelVacaciones
        frm.ShowDialog()
    End Sub

    Private Sub btn_Proc_Hrs_OH_Click(sender As Object, e As EventArgs) Handles btn_Proc_Hrs_OH.Click
        frmProcesarHoras_OH.MdiParent = Me
        frmProcesarHoras_OH.WindowState = FormWindowState.Maximized
        frmProcesarHoras_OH.Show()
        frmProcesarHoras_OH.Focus()
    End Sub


    Private Sub ButtonItem20_Click(sender As Object, e As EventArgs) Handles ButtonItem20.Click
        Try
            Dim frm As New frmCargaOH
            frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRepUnif_Click(sender As Object, e As EventArgs) Handles btnRepUnif.Click
        frmReporteadorUniformes.MdiParent = Me
        frmReporteadorUniformes.WindowState = FormWindowState.Maximized
        frmReporteadorUniformes.Show()
        frmReporteadorUniformes.Focus()
    End Sub

    Private Sub Tipo_curso_Click(sender As Object, e As EventArgs) Handles Tipo_curso.Click
        Try
            frmTipo_curso.MdiParent = Me
            frmTipo_curso.WindowState = FormWindowState.Maximized
            frmTipo_curso.Show()
            frmTipo_curso.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Clase_curso_Click(sender As Object, e As EventArgs) Handles Clase_curso.Click
        Try
            frmClase_curso.MdiParent = Me
            frmClase_curso.WindowState = FormWindowState.Maximized
            frmClase_curso.Show()
            frmClase_curso.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem21_Click(sender As Object, e As EventArgs) Handles ButtonItem21.Click
        frmCapturaSubAusentismo.MdiParent = Me
        frmCapturaSubAusentismo.WindowState = FormWindowState.Maximized
        frmCapturaSubAusentismo.Show()
        frmCapturaSubAusentismo.Focus()
    End Sub

    'Private Sub btnCalcFiniquito_Click(sender As Object, e As EventArgs)
    '    On Error Resume Next
    '    frmCalcFiniquito.MdiParent = Me
    '    frmCalcFiniquito.WindowState = FormWindowState.Maximized
    '    frmCalcFiniquito.Show()
    '    frmCalcFiniquito.Focus()
    'End Sub

    Private Sub mnuClerks_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        frmClerks.MdiParent = Me
        frmClerks.WindowState = FormWindowState.Maximized
        frmClerks.Show()
        frmClerks.Focus()
    End Sub

    Private Sub btnConsultaRetFAH_Click(sender As Object, e As EventArgs) Handles btnConsultaRetFAH.Click
        frmConsultaRetFAH.MdiParent = Me
        frmConsultaRetFAH.WindowState = FormWindowState.Maximized
        frmConsultaRetFAH.Show()
        frmConsultaRetFAH.Focus()
    End Sub

    Private Sub btnKardexAnualAccD_Click(sender As Object, e As EventArgs) Handles btnKardexAnualAccD.Click
        frmKardexAcd.MdiParent = Me
        frmKardexAcd.WindowState = FormWindowState.Maximized
        frmKardexAcd.Show()
        frmKardexAcd.Focus()
    End Sub

    Private Sub ButtonItem36_Click(sender As Object, e As EventArgs) Handles btnVacantesReclutamiento.Click
        frmCapturaVacantes.MdiParent = Me
        frmCapturaVacantes.WindowState = FormWindowState.Maximized
        frmCapturaVacantes.Show()
        frmCapturaVacantes.Focus()
    End Sub

    Private Sub ButtonItem27_Click(sender As Object, e As EventArgs) Handles btnEntrevistaMedico.Click
        frmSMedico.MdiParent = Me
        frmSMedico.WindowState = FormWindowState.Maximized
        frmSMedico.Show()
        frmSMedico.Focus()
    End Sub

    Private Sub ButtonItem26_Click(sender As Object, e As EventArgs) Handles btnRegistroCandidatos.Click
        frmCapturaCandidatos.MdiParent = Me
        frmCapturaCandidatos.WindowState = FormWindowState.Maximized
        frmCapturaCandidatos.Show()
        frmCapturaCandidatos.Focus()
    End Sub

    Private Sub ButtonItem29_Click(sender As Object, e As EventArgs) Handles btnAltaRH.Click
        frmrevision.MdiParent = Me
        frmrevision.WindowState = FormWindowState.Maximized
        frmrevision.Show()
        frmrevision.Focus()
    End Sub

    Private Sub ButtonItem28_Click(sender As Object, e As EventArgs) Handles btnEntrevistaSupervisor.Click
        frmEvaluacionSolicitantes.MdiParent = Me
        frmEvaluacionSolicitantes.WindowState = FormWindowState.Maximized
        frmEvaluacionSolicitantes.Show()
        frmEvaluacionSolicitantes.Focus()
    End Sub

    Private Sub ButtonItem24_Click(sender As Object, e As EventArgs) Handles btnEvaluacionesReclutamiento.Click
        frmEvaluacionesRec.MdiParent = Me
        frmEvaluacionesRec.WindowState = FormWindowState.Maximized
        frmEvaluacionesRec.Show()
        frmEvaluacionesRec.Focus()
    End Sub

    Private Sub ButtonItem30_Click(sender As Object, e As EventArgs) Handles btnCuestionariosReclutamiento.Click
        frmCuestionariosRec.MdiParent = Me
        frmCuestionariosRec.WindowState = FormWindowState.Maximized
        frmCuestionariosRec.Show()
        frmCuestionariosRec.Focus()
    End Sub

    Private Sub ButtonItem31_Click(sender As Object, e As EventArgs) Handles btnRespuestasReclutamiento.Click
        frmRespuestasRec.MdiParent = Me
        frmRespuestasRec.WindowState = FormWindowState.Maximized
        frmRespuestasRec.Show()
        frmRespuestasRec.Focus()
    End Sub

    Private Sub ButtonItem37_Click(sender As Object, e As EventArgs) Handles btnAdminSolicitudes.Click
        frmAdminSolicitudes.MdiParent = Me
        frmAdminSolicitudes.WindowState = FormWindowState.Maximized
        frmAdminSolicitudes.Show()
        frmAdminSolicitudes.Focus()
    End Sub

    Private Sub btnCatalogoReclutamiento_Click(sender As Object, e As EventArgs) Handles btnCatalogoReclutamiento.Click

    End Sub

    Private Sub btUsuariosAdmKiosco_Click(sender As Object, e As EventArgs) Handles btUsuariosAdmKiosco.Click
        On Error Resume Next
        frmUsuariosAdmKiosco.MdiParent = Me
        frmUsuariosAdmKiosco.WindowState = FormWindowState.Maximized
        frmUsuariosAdmKiosco.Show()
        frmUsuariosAdmKiosco.Focus()
    End Sub

    Private Sub btnPerfilesAdmKiosco_Click(sender As Object, e As EventArgs) Handles btnPerfilesAdmKiosco.Click
        On Error Resume Next
        frmPerfilesAdmKiosco.MdiParent = Me
        frmPerfilesAdmKiosco.WindowState = FormWindowState.Maximized
        frmPerfilesAdmKiosco.Show()
        frmPerfilesAdmKiosco.Focus()
    End Sub

    Private Sub btnEntrevistaRH_Click(sender As Object, e As EventArgs) Handles btnEntrevistaRH.Click
        frmEntrevistaRH.MdiParent = Me
        frmEntrevistaRH.WindowState = FormWindowState.Maximized
        frmEntrevistaRH.Show()
        frmEntrevistaRH.Focus()
    End Sub

    Private Sub ButtonItem24_Click_1(sender As Object, e As EventArgs) Handles ButtonItem24.Click
        frmChecadas.ShowDialog()
        frmChecadas.Focus()
    End Sub

    Private Sub ButtonItem25_Click(sender As Object, e As EventArgs) Handles ButtonItem25.Click
        frmChecador.ShowDialog()
        frmChecador.Focus()
    End Sub

    Private Sub btnMasivoGafetes_Click(sender As Object, e As EventArgs) Handles btnMasivoGafetes.Click
        On Error Resume Next
        frmMasivoGafetes.ShowDialog()
    End Sub

    Private Sub mnuInicNom_Click(sender As Object, e As EventArgs) Handles mnuInicNom.Click
        ' --- Inicializar nómina
        frmInicNom.ShowDialog()
        frmInicNom.Focus()
    End Sub

    Private Sub mnuCalcGenNom_Click(sender As Object, e As EventArgs) Handles mnuCalcGenNom.Click
        frmCalcNom.ShowDialog()
        frmCalcNom.Focus()
    End Sub

    Private Sub mnuConsulIndiv_Click(sender As Object, e As EventArgs) Handles mnuConsulIndiv.Click

        On Error Resume Next
        frmIndivTest.MdiParent = Me
        frmIndivTest.WindowState = FormWindowState.Maximized
        frmIndivTest.Show()
        frmIndivTest.Focus()

    End Sub

    Private Sub mnuAsentNom_Click(sender As Object, e As EventArgs) Handles mnuAsentNom.Click
        frmAsentarNom.ShowDialog()
        frmAsentarNom.Focus()
    End Sub

    Private Sub mnuTimbrado_Click(sender As Object, e As EventArgs) Handles mnuTimbrado.Click
        'frmRecibosCFDI2017.ShowDialog()
        'frmRecibosCFDI2017.Focus()
    End Sub

    Private Sub ButtonItem26_Click_1(sender As Object, e As EventArgs) Handles ButtonItem26.Click

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        '---Generar reportes semanal y catorcenal del periodo actual

        Try
            If MessageBox.Show("¿Desea generar el reporte de detalle de la nómina?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then


                Dim QPer As String = "select distinct ano,periodo,tipo_periodo from nomina_pro order by tipo_periodo desc" ' Para que coloque siempre la Sem en 1er lugar
                Dim dtValidaPer As DataTable = sqlExecute(QPer, "NOMINA")
                Dim anio1 As String = "", per1 As String = "", tipo_per1 As String = "", anio2 As String = "", per2 As String = "", tipo_per2 As String = ""
                Dim TotPerProc As Integer = 0

                If (Not dtValidaPer.Columns.Contains("Error") And dtValidaPer.Rows.Count > 0) Then
                    If (dtValidaPer.Rows.Count = 1) Then ' Es solo un periodo mandado
                        Try : anio1 = dtValidaPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio1 = "" : End Try
                        Try : per1 = dtValidaPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per1 = "" : End Try
                        Try : tipo_per1 = dtValidaPer.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per1 = "" : End Try
                        TotPerProc = 1
                    End If

                    If (dtValidaPer.Rows.Count = 2) Then ' Son los dos periodos que se mandan
                        Try : anio1 = dtValidaPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio1 = "" : End Try
                        Try : per1 = dtValidaPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per1 = "" : End Try
                        Try : tipo_per1 = dtValidaPer.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per1 = "" : End Try

                        Try : anio2 = dtValidaPer.Rows(1).Item("ano").ToString.Trim : Catch ex As Exception : anio2 = "" : End Try
                        Try : per2 = dtValidaPer.Rows(1).Item("periodo").ToString.Trim : Catch ex As Exception : per2 = "" : End Try
                        Try : tipo_per2 = dtValidaPer.Rows(1).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per2 = "" : End Try

                        TotPerProc = 2
                    End If
                End If

                If (TotPerProc = 1) Then
                    frmCalcNom.GenRepNominaDetalle(anio1, per1, "5", tipo_per1)
                    Me.Close()
                End If

                If (TotPerProc = 2) Then
                    frmCalcNom.GenRepNominaDetalle(anio1, per1, "5", tipo_per1)
                    frmCalcNom.GenRepNominaDetalle(anio2, per2, "5", tipo_per2)
                    Me.Close()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCargaCafe_Click(sender As Object, e As EventArgs) Handles btnCargaCafe.Click
        frmCargaCafeteria.ShowDialog()
        frmCargaCafeteria.Focus()
    End Sub

    Private Sub mnuCargaXml_Click(sender As Object, e As EventArgs) Handles mnuCargaXml.Click
        frmCargaXML.Show()
        frmCargaXML.Focus()
    End Sub

    Private Sub btnCalculaAgui_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCalcularAguinaldo_Click(sender As Object, e As EventArgs) Handles btnCalcularAguinaldo.Click
        frmCalcAgui.Show()
        frmCalcAgui.Focus()
    End Sub

    Private Sub btnConsInidivNomEsp_Click(sender As Object, e As EventArgs) Handles btnConsInidivNomEsp.Click
        On Error Resume Next
        nombreNomEspecial = "agui"
        frmIndivNomEsp.MdiParent = Me
        frmIndivNomEsp.WindowState = FormWindowState.Maximized
        frmIndivNomEsp.Show()
        frmIndivNomEsp.Focus()
    End Sub

    Private Sub btnGenRepAgui_Click(sender As Object, e As EventArgs) Handles btnGenRepAgui.Click
        Try
            If MessageBox.Show("¿Desea generar el reporte de detalle de la nómina?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then


                Dim QPer As String = "select distinct ano,periodo,tipo_periodo from nomina_pro_esp order by tipo_periodo desc" ' Para que coloque siempre la Sem en 1er lugar
                Dim dtValidaPer As DataTable = sqlExecute(QPer, "NOMINA")
                Dim anio1 As String = "", per1 As String = "", tipo_per1 As String = "", anio2 As String = "", per2 As String = "", tipo_per2 As String = ""
                Dim TotPerProc As Integer = 0

                If (Not dtValidaPer.Columns.Contains("Error") And dtValidaPer.Rows.Count > 0) Then
                    If (dtValidaPer.Rows.Count = 1) Then ' Es solo un periodo mandado
                        Try : anio1 = dtValidaPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio1 = "" : End Try
                        Try : per1 = dtValidaPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per1 = "" : End Try
                        Try : tipo_per1 = dtValidaPer.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per1 = "" : End Try
                        TotPerProc = 1
                    End If

                    If (dtValidaPer.Rows.Count = 2) Then ' Son los dos periodos que se mandan
                        Try : anio1 = dtValidaPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio1 = "" : End Try
                        Try : per1 = dtValidaPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per1 = "" : End Try
                        Try : tipo_per1 = dtValidaPer.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per1 = "" : End Try

                        Try : anio2 = dtValidaPer.Rows(1).Item("ano").ToString.Trim : Catch ex As Exception : anio2 = "" : End Try
                        Try : per2 = dtValidaPer.Rows(1).Item("periodo").ToString.Trim : Catch ex As Exception : per2 = "" : End Try
                        Try : tipo_per2 = dtValidaPer.Rows(1).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per2 = "" : End Try

                        TotPerProc = 2
                    End If
                End If

                If (TotPerProc = 1) Then
                    frmCalcAgui.GenRepNominaDetalle_esp(anio1, per1, "5", tipo_per1, "Agui")
                    Me.Close()
                End If

                If (TotPerProc = 2) Then
                    frmCalcAgui.GenRepNominaDetalle_esp(anio1, per1, "5", tipo_per1, "Agui")
                    frmCalcAgui.GenRepNominaDetalle_esp(anio2, per2, "5", tipo_per2, "Agui")
                    Me.Close()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAsentNomAgui_Click(sender As Object, e As EventArgs) Handles btnAsentNomAgui.Click
        nombreNomEspecial = "agui"
        frmAsentarNom_esp.ShowDialog()
        frmAsentarNom_esp.Focus()
    End Sub

    Private Sub mnuConfigPerFah_Click(sender As Object, e As EventArgs) Handles mnuConfigPerFah.Click
        '---Configurar periodos de pago de Fondo de ahorro
        frmConfigPerLiqFah.Show()
        frmConfigPerLiqFah.Focus()
    End Sub

    Private Sub mnuCalcLiqFah_Click(sender As Object, e As EventArgs) Handles mnuCalcLiqFah.Click
        frmCalcLiqFah.Show()
        frmCalcLiqFah.Focus()
    End Sub

    Private Sub mnuConsIndivLiqFah_Click(sender As Object, e As EventArgs) Handles mnuConsIndivLiqFah.Click
        On Error Resume Next
        nombreNomEspecial = "liq_fah"
        frmIndivNomEsp.MdiParent = Me
        frmIndivNomEsp.WindowState = FormWindowState.Maximized
        frmIndivNomEsp.Show()
        frmIndivNomEsp.Focus()
    End Sub

    Private Sub mnuRepLiqFah_Click(sender As Object, e As EventArgs) Handles mnuRepLiqFah.Click
        Try
            If MessageBox.Show("¿Desea generar el reporte de detalle de la nómina?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then


                Dim QPer As String = "select distinct ano,periodo,tipo_periodo from nomina_pro_esp order by tipo_periodo desc" ' Para que coloque siempre la Sem en 1er lugar
                Dim dtValidaPer As DataTable = sqlExecute(QPer, "NOMINA")
                Dim anio1 As String = "", per1 As String = "", tipo_per1 As String = "", anio2 As String = "", per2 As String = "", tipo_per2 As String = ""
                Dim TotPerProc As Integer = 0

                If (Not dtValidaPer.Columns.Contains("Error") And dtValidaPer.Rows.Count > 0) Then
                    If (dtValidaPer.Rows.Count = 1) Then ' Es solo un periodo mandado
                        Try : anio1 = dtValidaPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio1 = "" : End Try
                        Try : per1 = dtValidaPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per1 = "" : End Try
                        Try : tipo_per1 = dtValidaPer.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per1 = "" : End Try
                        TotPerProc = 1
                    End If

                    If (dtValidaPer.Rows.Count = 2) Then ' Son los dos periodos que se mandan
                        Try : anio1 = dtValidaPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio1 = "" : End Try
                        Try : per1 = dtValidaPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per1 = "" : End Try
                        Try : tipo_per1 = dtValidaPer.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per1 = "" : End Try

                        Try : anio2 = dtValidaPer.Rows(1).Item("ano").ToString.Trim : Catch ex As Exception : anio2 = "" : End Try
                        Try : per2 = dtValidaPer.Rows(1).Item("periodo").ToString.Trim : Catch ex As Exception : per2 = "" : End Try
                        Try : tipo_per2 = dtValidaPer.Rows(1).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per2 = "" : End Try

                        TotPerProc = 2
                    End If
                End If

                If (TotPerProc = 1) Then

                    frmCalcAgui.GenRepNominaDetalle_esp(anio1, per1, "5", tipo_per1, "LiqFah")
                    Me.Close()
                End If

                If (TotPerProc = 2) Then
                    frmCalcAgui.GenRepNominaDetalle_esp(anio1, per1, "5", tipo_per1, "LiqFah")
                    frmCalcAgui.GenRepNominaDetalle_esp(anio2, per2, "5", tipo_per2, "LiqFah")
                    Me.Close()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnuAsentNomLiqFah_Click(sender As Object, e As EventArgs) Handles mnuAsentNomLiqFah.Click
        nombreNomEspecial = "liq_fah"
        frmAsentarNom_esp.ShowDialog()
        frmAsentarNom_esp.Focus()
    End Sub

    Private Sub btnTimbNomEsp_Click(sender As Object, e As EventArgs)
        'frmRecibosCFDI2017.ShowDialog()
        'frmRecibosCFDI2017.Focus()
    End Sub

    Private Sub btnCargaXmlNomEsp_Click(sender As Object, e As EventArgs) Handles btnCargaXmlNomEsp.Click
        frmCargaXML.Show()
        frmCargaXML.Focus()
    End Sub

    Private Sub mnuCargaXmlHist_Click(sender As Object, e As EventArgs) Handles mnuCargaXmlHist.Click
        'frmCargaHist.Show()
        'frmCargaHist.Focus()
    End Sub

    Private Sub btnGenSolFonAho_Click(sender As Object, e As EventArgs) Handles btnGenSolFonAho.Click
        Dim dtData As New DataTable
        Dim dtSacaAnioPeriodo As New DataTable
        Dim dtValidaMovimientos As New DataTable
        dtSacaAnioPeriodo = sqlExecute("select ANO+PERIODO AS 'AP' from TA.DBO.periodos where ano='" + CStr(Date.Now.Year) + "' and PERIODO_ESPECIAL=1 and (OBSERVACIONES like '%liq%' and OBSERVACIONES like '%fond%'  and OBSERVACIONES like '%ahorr%')")
        If dtSacaAnioPeriodo.Rows.Count > 0 Then
            Dim AnioPeriodo As String = dtSacaAnioPeriodo.Rows(0)("AP")
            dtValidaMovimientos = sqlExecute("SELECT * FROM NOMINA.DBO.movimientos WHERE ANO+PERIODO = '" + CStr(AnioPeriodo) + "'")
            If dtValidaMovimientos.Rows.Count > 0 Then
                dtData = sqlExecute("SELECT *, (SELECT CLABE FROM PERSONAL.dbo.personal WHERE RELOJ = nomina.RELOJ) AS 'CLABE',(SELECT MONTO FROM Movimientos WHERE ANO + PERIODO = '" + AnioPeriodo + "' AND RELOJ = NOMINA.RELOJ AND CONCEPTO = 'neto') as 'MONTO' FROM NOMINA WHERE ANO + PERIODO = '" + AnioPeriodo + "'", "NOMINA")
                PreparaDatos("Solicitud de Retiro", dtData)
            Else
                MessageBox.Show("No se puede mostrar la informacion ya que no se cuenta con el periodo asentado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se puede generar la carta ya que no se cuenta con la suficiente informacion de Año y Periodo ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mnuInicVar_Click(sender As Object, e As EventArgs) Handles mnuInicVar.Click
        frmInicVariable.ShowDialog()
        frmInicVariable.Focus()
    End Sub

    Private Sub mnuCalcVar_Click(sender As Object, e As EventArgs) Handles mnuCalcVar.Click
        frmCalcVariable.ShowDialog()
        frmCalcVariable.Focus()
    End Sub

    Private Sub btnRepVarImss_Click(sender As Object, e As EventArgs) Handles btnRepVarImss.Click
        Dim anio As String = "", periodo As String = ""
        Try
            If MessageBox.Show("¿Desea generar el reporte con el detalle de las variables IMSS?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Dim dtAnioBimVar As DataTable = sqlExecute("SELECT distinct ano,bimestre from variables_nom_pro", "NOMINA")
                If (Not dtAnioBimVar.Columns.Contains("Error") And dtAnioBimVar.Rows.Count > 0) Then
                    Try : anio = dtAnioBimVar.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio = "" : End Try
                    Try : periodo = dtAnioBimVar.Rows(0).Item("bimestre").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
                End If
                frmCalcVariable.GenRepVar_PRO(anio, periodo)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAplicaVar_Click(sender As Object, e As EventArgs) Handles btnAplicaVar.Click
        '--- Aplicar variables
        frmAplicaVar.ShowDialog()
        frmAplicaVar.Focus()
    End Sub

    Private Sub btnGenArchIDSE_Click(sender As Object, e As EventArgs) Handles btnGenArchIDSE.Click
        Dim dtDatos As New DataTable
        Dim dtInfo As New DataTable
        Dim dtStatusProc As New DataTable
        Dim anio As String = ""
        Dim bim As String = ""
        Dim avance As String = ""
        Dim dtPeriodos As New DataTable
        FecAplVar = ""

        dtStatusProc = sqlExecute("select * from variable_status_proc", "NOMINA")

        If (Not dtStatusProc.Columns.Contains("Error") And dtStatusProc.Rows.Count > 0) Then
            Try : avance = dtStatusProc.Rows(0).Item("avance") : Catch ex As Exception : avance = "" : End Try
            Try : anio = dtStatusProc.Rows(0).Item("ano") : Catch ex As Exception : anio = "" : End Try
            Try : bim = dtStatusProc.Rows(0).Item("bimestre") : Catch ex As Exception : bim = "" : End Try
        End If

        If avance <> "4" Then
            MessageBox.Show("El bimestre actual aun no se encuentra calculado y aplicado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If

        dtPeriodos = sqlExecute("select * from periodos_variables where ano+bimestre='" & anio & bim & "'", "TA")

        If (Not dtPeriodos.Columns.Contains("Error") And dtPeriodos.Rows.Count > 0) Then
            Try : FecAplVar = FechaSQL(dtPeriodos.Rows(0).Item("fec_aplica")) : Catch ex As Exception : FecAplVar = "" : End Try
        End If

        Try
            If MessageBox.Show("¿Desea generar el archivo de notificación al IMSS del bimestre actual cerrado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Dim Q As String = "select p.* from PERSONAL.dbo.personalvw p left outer join NOMINA.dbo.variables_nom_pro n " & _
                                  "on p.RELOJ=n.reloj where isnull(n.aplica,0)=1 and n.ano+n.bimestre='" & anio & bim & "'"
                dtInfo = sqlExecute(Q, "NOMINA")

                frmVistaPrevia.LlamarReporte("Variables IMSS", dtInfo, Compania)
                frmVistaPrevia.ShowDialog()

            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub btnPantallaRelojes_Click(sender As Object, e As EventArgs) Handles btnPantallaRelojes.Click
        frmImportarChecadas.ShowDialog()
    End Sub

    Private Sub btnHorarioMasivo_Click(sender As Object, e As EventArgs) Handles btnHorarioMasivo.Click
        '---Agregado 4/feb/21   Ernesto
        frmHorarioMasivo.Show()
        frmHorarioMasivo.Focus()
    End Sub

    Private Sub btnCalcPTU_Click(sender As Object, e As EventArgs) Handles btnCalcPTU.Click
        frmCalcPTU.Show()
        frmCalcPTU.Focus()
    End Sub

    Private Sub btnConsIndivPtu_Click(sender As Object, e As EventArgs) Handles btnConsIndivPtu.Click
        On Error Resume Next
        nombreNomEspecial = "ptu"
        frmIndivNomEsp.MdiParent = Me
        frmIndivNomEsp.WindowState = FormWindowState.Maximized
        frmIndivNomEsp.Show()
        frmIndivNomEsp.Focus()
    End Sub

    Private Sub btnRepPTU_Click(sender As Object, e As EventArgs) Handles btnRepPTU.Click
        Try
            If MessageBox.Show("¿Desea generar el reporte de detalle de la nómina?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then


                Dim QPer As String = "select distinct ano,periodo,tipo_periodo from nomina_pro_esp order by tipo_periodo desc" ' Para que coloque siempre la Sem en 1er lugar
                Dim dtValidaPer As DataTable = sqlExecute(QPer, "NOMINA")
                Dim anio1 As String = "", per1 As String = "", tipo_per1 As String = "", anio2 As String = "", per2 As String = "", tipo_per2 As String = ""
                Dim TotPerProc As Integer = 0

                If (Not dtValidaPer.Columns.Contains("Error") And dtValidaPer.Rows.Count > 0) Then
                    If (dtValidaPer.Rows.Count = 1) Then ' Es solo un periodo mandado
                        Try : anio1 = dtValidaPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio1 = "" : End Try
                        Try : per1 = dtValidaPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per1 = "" : End Try
                        Try : tipo_per1 = dtValidaPer.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per1 = "" : End Try
                        TotPerProc = 1
                    End If

                    If (dtValidaPer.Rows.Count = 2) Then ' Son los dos periodos que se mandan
                        Try : anio1 = dtValidaPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio1 = "" : End Try
                        Try : per1 = dtValidaPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per1 = "" : End Try
                        Try : tipo_per1 = dtValidaPer.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per1 = "" : End Try

                        Try : anio2 = dtValidaPer.Rows(1).Item("ano").ToString.Trim : Catch ex As Exception : anio2 = "" : End Try
                        Try : per2 = dtValidaPer.Rows(1).Item("periodo").ToString.Trim : Catch ex As Exception : per2 = "" : End Try
                        Try : tipo_per2 = dtValidaPer.Rows(1).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per2 = "" : End Try

                        TotPerProc = 2
                    End If
                End If

                If (TotPerProc = 1) Then
                    frmCalcAgui.GenRepNominaDetalle_esp(anio1, per1, "5", tipo_per1, "ptu")
                    Me.Close()
                End If

                If (TotPerProc = 2) Then
                    frmCalcAgui.GenRepNominaDetalle_esp(anio1, per1, "5", tipo_per1, "ptu")
                    frmCalcAgui.GenRepNominaDetalle_esp(anio2, per2, "5", tipo_per2, "ptu")
                    Me.Close()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAsentPTU_Click(sender As Object, e As EventArgs) Handles btnAsentPTU.Click
        nombreNomEspecial = "ptu"
        frmAsentarNom_esp.ShowDialog()
        frmAsentarNom_esp.Focus()
    End Sub

    Private Sub btnPtuParametros_Click(sender As Object, e As EventArgs) Handles btnPtuParametros.Click
        frmPtuParam.Show()
        frmPtuParam.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim info As UpdateCheckInfo = Nothing
        If (ApplicationDeployment.IsNetworkDeployed) Then
            Try
                Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment
                info = AD.CheckForDetailedUpdate()
            Catch
                Return
            End Try
            If (info.UpdateAvailable) Then
                Timer1.Enabled = False
                MessageBox.Show("Hay una actualizacion disponible con el numero de version: " & info.MinimumRequiredVersion.ToString() & _
                    ". Favor de cerrar y volver a abrir la aplicacion para actualizarla.", _
                    "Hay una actualizacion disponible", MessageBoxButtons.OK, _
                    MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnCargaMasivaExcep_Click(sender As Object, e As EventArgs) Handles btnCargaMasivaExcep.Click
        frmCargaExcepMasivo.Show()
        frmCargaExcepMasivo.Focus()
    End Sub

    Private Sub btnConsultaExcep_Click(sender As Object, e As EventArgs) Handles btnConsultaExcep.Click
        frmExcepcionHorarios.MdiParent = Me
        frmExcepcionHorarios.WindowState = FormWindowState.Maximized
        frmExcepcionHorarios.Show()
        frmExcepcionHorarios.Focus()
    End Sub

    '==Catalogo de orden de las categorias      2-sep-2021
    Private Sub btnOrdenCategorias_Click(sender As Object, e As EventArgs) Handles btnOrdenCategorias.Click
        Try
            frmOrdenNivelCategorias.MdiParent = Me
            frmOrdenNivelCategorias.WindowState = FormWindowState.Maximized
            frmOrdenNivelCategorias.Show()
            frmOrdenNivelCategorias.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnuInicCalcIsrAnual_Click(sender As Object, e As EventArgs) Handles mnuInicCalcIsrAnual.Click
        frmInicCalcIsrAnual.ShowDialog()
        frmInicCalcIsrAnual.Focus()
    End Sub

    Private Sub btnCalcIsrAnu_Click(sender As Object, e As EventArgs) Handles btnCalcIsrAnu.Click
        frmCalcIsrAnual.ShowDialog()
        frmCalcIsrAnual.Focus()
    End Sub

    Private Sub btnRepCalcISRAnu_Click(sender As Object, e As EventArgs) Handles btnRepCalcISRAnu.Click
        Try
            If MessageBox.Show("¿Desea generar el reporte de detalle del ISR Anual actual calculado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                Dim dtDetalleIsrAnual As DataTable = sqlExecute("select * from isranual_nom_pro", "NOMINA")
                If (Not dtDetalleIsrAnual.Columns.Contains("Error") And dtDetalleIsrAnual.Rows.Count > 0) Then
                    frmVistaPrevia.LlamarReporte("Detalle isr anual", dtDetalleIsrAnual)
                    frmVistaPrevia.ShowDialog()
                Else
                    MessageBox.Show("No existe información para generarse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Error al generar reporte de ISR anual", Err.Number, ex.Message)
        End Try
    End Sub

    Private Sub btnAplicaIsrAnual_Click(sender As Object, e As EventArgs) Handles btnAplicaIsrAnual.Click
        frmAplicaIsrAnual.ShowDialog()
        frmAplicaIsrAnual.Focus()
    End Sub

    '==Agregado 5oct2021   Ernesto
    Private Sub btnEmpleadosCursos_Click(sender As Object, e As EventArgs) Handles btnEmpleadosCursos.Click
        Try
            frmEmpleadosCurso.MdiParent = Me
            frmEmpleadosCurso.WindowState = FormWindowState.Maximized
            frmEmpleadosCurso.Show()
            frmEmpleadosCurso.Focus()
        Catch ex As Exception

        End Try
    End Sub

    '== Agregado 21oct2021          Ernesto
    Private Sub btnRepPerEmpl_Click(sender As Object, e As EventArgs) Handles btnRepPerEmpl.Click
        Try
            If MessageBox.Show("¿Desea generar el reporte de percepciones anual de todos empleado?", "Aviso", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Dim dtDatoEmp As New DataTable
                Dim Qry As String = "SELECT * from NOMINA.dbo.isranual_nom_pro"
                dtDatoEmp = sqlExecute(Qry)

                If dtDatoEmp.Rows.Count > 0 Then
                    frmVistaPrevia.LlamarReporte("Reporte Percepciones Empleado", dtDatoEmp)
                    frmVistaPrevia.ShowDialog()
                Else
                    MessageBox.Show("No existe información para generarse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Error al generar reporte de percepciones de empleados", Err.Number, ex.Message)
        End Try
    End Sub

    '== Dic2021     Ernesto
    Private Sub mnuLideres_Click(sender As Object, e As EventArgs) Handles mnuLideres.Click
        frmLider.MdiParent = Me
        frmLider.WindowState = FormWindowState.Maximized
        frmLider.Show()
        frmLider.Focus()
    End Sub

    Private Sub btnValidaTimbrado_Click(sender As Object, e As EventArgs) Handles btnValidaTimbrado.Click
        frmValidaTimbradoTabla.ShowDialog()
        frmValidaTimbradoTabla.Focus()
    End Sub

    '== 17ene2022       Ernesto
    Private Sub btnSolicitudesVacaciones_Click(sender As Object, e As EventArgs) Handles btnSolicitudesVacaciones.Click
        frmSolVacKiosco.MdiParent = Me
        frmSolVacKiosco.WindowState = FormWindowState.Maximized
        frmSolVacKiosco.Show()
        frmSolVacKiosco.Focus()
    End Sub

    Private Sub btnItemDesNom_Click(sender As Object, e As EventArgs) Handles btnItemDesNom.Click
        frmDesAsentarUltNom.Show()
        frmDesAsentarUltNom.Focus()
    End Sub

    Private Sub btnCargaXmls_Click(sender As Object, e As EventArgs) Handles btnCargaXmls.Click
        frmCargaXmls.Show()
        frmCargaXmls.Focus()
    End Sub

    ''' <summary>
    ''' Botón para abrir módulo de 'Presentación de quejas'
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPresentacionQueja_Click(sender As Object, e As EventArgs) Handles btnPresentacionQueja.Click
        frmPresentacionQuejas.MdiParent = Me
        frmPresentacionQuejas.WindowState = FormWindowState.Maximized
        frmPresentacionQuejas.Show()
        frmPresentacionQuejas.Focus()
    End Sub

    '== Boton de acceso al proceso de nomina Qro -- Ernesto -- 7 mayo 2024
    Private Sub btnProcesoNomina_Click(sender As Object, e As EventArgs) Handles btnProcesoNomina.Click
        frmProcesoNomina.MdiParent = Me
        frmProcesoNomina.WindowState = FormWindowState.Maximized
        frmProcesoNomina.Show()
        frmProcesoNomina.Focus()
    End Sub

    '== Botón para acceder a la info de la api del cliente -- Ernesto -- 6 marzo 2024
    Private Sub btnApiInfo_Click(sender As Object, e As EventArgs) Handles btnApiInfo.Click
        frmInfoAPI.Show()
        frmInfoAPI.Focus()
    End Sub

    Private Sub btnProgVacs_Click(sender As Object, e As EventArgs) Handles btnProgVacs.Click
        frmProgVacs.MdiParent = Me
        frmProgVacs.WindowState = FormWindowState.Maximized
        frmProgVacs.Show()
        frmProgVacs.Focus()
    End Sub

    Private Sub mnuPensionesAlim_Click(sender As Object, e As EventArgs) Handles mnuPensionesAlim.Click
        frmPensionesAlimenticias.MdiParent = Me
        frmPensionesAlimenticias.WindowState = FormWindowState.Maximized
        frmPensionesAlimenticias.Show()
        frmPensionesAlimenticias.Focus()
    End Sub

    Private Sub btnTimbrado_Click(sender As Object, e As EventArgs) Handles btnTimbrado.Click
        frmTimbrado.MdiParent = Me
        frmTimbrado.WindowState = FormWindowState.Maximized
        frmTimbrado.Show()
        btnTimbrado.Focus()
    End Sub

    Private Sub btnPromediosVariable_Click(sender As Object, e As EventArgs) Handles btnPromediosVariable.Click
        frmPromediosVariables.MdiParent = Me
        frmPromediosVariables.WindowState = FormWindowState.Maximized
        frmPromediosVariables.Show()
        frmPromediosVariables.Focus()
    End Sub

    Private Sub mnCapIncPers_Click(sender As Object, e As EventArgs) Handles mnCapIncPers.Click
        frmCapDatosIncPers.Show()
    End Sub

    Private Sub mnuListaIncidencias_Click(sender As Object, e As EventArgs) Handles mnuListaIncidencias.Click
        '====Incidencias capturadas del personal

        frmListInciPers.MdiParent = Me
        frmListInciPers.WindowState = FormWindowState.Maximized
        frmListInciPers.Show()
        frmListInciPers.Focus()
    End Sub

    'Private Sub btnmnuFiniquito_Click(sender As Object, e As EventArgs) Handles btnmnuFiniquito.Click

    'End Sub

    Private Sub btnmnuCapturados_Click(sender As Object, e As EventArgs) Handles btnmnuCapturados.Click
        On Error Resume Next
        frmDemoFiniquitosCapturados.MdiParent = Me
        frmDemoFiniquitosCapturados.WindowState = FormWindowState.Maximized
        frmDemoFiniquitosCapturados.Show()
        frmDemoFiniquitosCapturados.Focus()
    End Sub

    Private Sub btnCalcFiniquito_Click(sender As Object, e As EventArgs) Handles btnmnuFiniquito.Click
        On Error Resume Next
        frmCalcFiniquito.MdiParent = Me
        frmCalcFiniquito.WindowState = FormWindowState.Maximized
        frmCalcFiniquito.Show()
        frmCalcFiniquito.Focus()
    End Sub

    Private Sub frmMain_ResizeBegin(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin
        PermitirAccesosXperfil()
    End Sub

    Private Sub frmMain_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        PermitirAccesosXperfil()
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PermitirAccesosXperfil()
    End Sub

    Private Sub btnRepDocCursos_Click(sender As Object, e As EventArgs) Handles btnRepDocCursos.Click
        Try
            frmRepositorioCursos.MdiParent = Me
            frmRepositorioCursos.WindowState = FormWindowState.Maximized
            frmRepositorioCursos.Show()
            frmRepositorioCursos.Focus()
        Catch ex As Exception

        End Try
    End Sub
End Class