Public Class frmIndivTest

    '---Tablas
    Dim dtTemp As New DataTable
    ' Dim dtPersonal As New DataTable
    Dim dtInformacionGeneral As DataTable

    '--Variables para el maestro de Nomina
    Dim anio As String = ""
    Dim periodo As String = ""
    Dim fIniPerSem As String = ""
    Dim fFinPerSem As String = ""
    Dim _reloj_consulta As String = ""
    Dim Editar As Boolean
    Dim asentado As String = ""
    Public AddNewPensAlim As Boolean = False

    Private Sub frmIndivTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '---Obtener anio y periodo procesado
        Dim dtAnioPer As DataTable = sqlExecute("select * from status_proceso", "NOMINA")
        If (Not dtAnioPer.Columns.Contains("Error") And dtAnioPer.Rows.Count > 0) Then
            Try : anio = dtAnioPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio = "" : End Try
            Try : periodo = dtAnioPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
        End If
        Dim anioPer As String = anio & periodo
        Dim dtFechasPer As DataTable = sqlExecute("SELECT * from periodos where ano+PERIODO='" & anioPer & "'", "TA")
        If (Not dtFechasPer.Columns.Contains("Error") And dtFechasPer.Rows.Count > 0) Then
            Try : fIniPerSem = FechaSQL(dtFechasPer.Rows(0).Item("FECHA_INI").ToString.Trim) : Catch ex As Exception : fIniPerSem = "" : End Try
            Try : fFinPerSem = FechaSQL(dtFechasPer.Rows(0).Item("FECHA_FIN").ToString.Trim) : Catch ex As Exception : fFinPerSem = "" : End Try
            Try : asentado = dtFechasPer.Rows(0).Item("asentado").ToString.Trim : Catch ex As Exception : asentado = "" : End Try
        End If

        If (asentado = "1") Then
            MessageBox.Show("El periodo ya encuentra asentado/cerrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If

        lblAnioPer.Text = anio & " - " & periodo & " - Del " & fIniPerSem & " al " & fFinPerSem
        '2020 - 35

        Dim dtPrimero As DataTable = sqlExecute("select reloj from nomina_pro order by reloj asc", "nomina")
        If dtPrimero.Rows.Count > 0 Then

            CargarCatalogos()

            btnFirst.PerformClick()

        Else
            MessageBox.Show("No hay un proceso activo en este momento", "Proceso no inicializado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Dispose()
        End If
    End Sub



    Private Sub MostrarInformacion(ByVal _reloj_consulta As String)

        Try

            Dim QInfoGral As String = "select " & _
            "reloj, " & _
            "isnull(nombres, 'N/A') as nombres, " & _
            "isnull(cod_comp, 'N/A') as cod_comp, " & _
            "isnull(cod_planta, 'N/A') as cod_planta, " & _
            "isnull(cod_depto, 'N/A') as cod_depto, " & _
            "isnull(cod_area, 'N/A') as cod_area, " & _
            "isnull(tipo_periodo, 'N/A') as tipo_periodo, " & _
            "isnull(cod_tipo, 'N/A') as cod_tipo, " & _
            "isnull(cod_clase, 'N/A') as cod_clase, " & _
            "isnull(cod_turno, 'N/A') as cod_turno, " & _
            "isnull(cod_hora, 'N/A') as cod_hora, " & _
            "isnull(cod_puesto, 'N/A') as cod_puesto, " & _
            "isnull(imss_pro, 'N/A') as IMSS, " & _
            "isnull(DIG_VER, 'N/A') as DIG_VER, " & _
            "isnull(RFC, 'N/A') as RFC, " & _
            "isnull(CURP, 'N/A') as CURP, " & _
            "isnull(sactual, '0') as sactual, " & _
            "isnull(integrado, '0') as integrado, " & _
            "alta, baja  " & _
            " from nomina_pro where reloj = '" & _reloj_consulta & "'"

            dtInformacionGeneral = sqlExecute(QInfoGral, "NOMINA")

            If dtInformacionGeneral.Rows.Count > 0 Then

                txtReloj.Text = _reloj_consulta

                '***********************DATOS GENERALES
                Try : lblNombres.Text = dtInformacionGeneral.Rows(0)("nombres") : Catch ex As Exception : lblNombres.Text = "" : End Try
                Try : cmbCias.SelectedValue = dtInformacionGeneral.Rows(0)("cod_comp") : Catch ex As Exception : cmbCias.SelectedValue = "" : End Try
                Try : cmbPlanta.SelectedValue = dtInformacionGeneral.Rows(0)("cod_planta") : Catch ex As Exception : cmbPlanta.SelectedValue = "" : End Try
                Try : cmbArea.SelectedValue = dtInformacionGeneral.Rows(0)("cod_area") : Catch ex As Exception : cmbArea.SelectedValue = "" : End Try
                Try : cmbDepto.SelectedValue = dtInformacionGeneral.Rows(0)("cod_depto") : Catch ex As Exception : cmbDepto.SelectedValue = "" : End Try
                Try : cmbTipoPeriodo.SelectedValue = dtInformacionGeneral.Rows(0)("tipo_periodo") : Catch ex As Exception : cmbTipoPeriodo.SelectedValue = "" : End Try
                Try : cmbTipo.SelectedValue = dtInformacionGeneral.Rows(0)("cod_tipo") : Catch ex As Exception : cmbTipo.SelectedValue = "" : End Try
                Try : cmbClase.SelectedValue = dtInformacionGeneral.Rows(0)("cod_clase") : Catch ex As Exception : cmbClase.SelectedValue = "" : End Try
                Try : cmbTurno.SelectedValue = dtInformacionGeneral.Rows(0)("cod_turno") : Catch ex As Exception : cmbTurno.SelectedValue = "" : End Try
                Try : cmbHora.SelectedValue = dtInformacionGeneral.Rows(0)("cod_hora") : Catch ex As Exception : cmbHora.SelectedValue = "" : End Try
                Try : cmbPuesto.SelectedValue = dtInformacionGeneral.Rows(0)("cod_puesto") : Catch ex As Exception : cmbPuesto.SelectedValue = "" : End Try
                Try : txtIMSS.Text = dtInformacionGeneral.Rows(0)("IMSS") & "-" & dtInformacionGeneral.Rows(0)("DIG_VER") : Catch ex As Exception : txtIMSS.Text = "" : End Try
                Try : txtRFC.Text = dtInformacionGeneral.Rows(0)("RFC") : Catch ex As Exception : txtRFC.Text = "" : End Try
                Try : txtCURP.Text = dtInformacionGeneral.Rows(0)("CURP") : Catch ex As Exception : txtCURP.Text = "" : End Try
                Try : txtSactual.Text = Double.Parse(dtInformacionGeneral.Rows(0)("sactual")).ToString("0.00") : Catch ex As Exception : txtSactual.Text = "" : End Try
                Try : txtIntegrado.Text = Double.Parse(dtInformacionGeneral.Rows(0)("integrado")).ToString("0.00") : Catch ex As Exception : txtIntegrado.Text = "" : End Try


                ' lblNombres.Text = dtInformacionGeneral.Rows(0)("nombres")
                ' cmbCias.SelectedValue = dtInformacionGeneral.Rows(0)("cod_comp")
                ' cmbPlanta.SelectedValue = dtInformacionGeneral.Rows(0)("cod_planta")
                '  cmbArea.SelectedValue = dtInformacionGeneral.Rows(0)("cod_area")
                '  cmbDepto.SelectedValue = dtInformacionGeneral.Rows(0)("cod_depto")
                '  cmbTipoPeriodo.SelectedValue = dtInformacionGeneral.Rows(0)("tipo_periodo")
                '  cmbTipo.SelectedValue = dtInformacionGeneral.Rows(0)("cod_tipo")
                '  cmbClase.SelectedValue = dtInformacionGeneral.Rows(0)("cod_clase")
                '  cmbTurno.SelectedValue = dtInformacionGeneral.Rows(0)("cod_turno")
                'cmbHora.SelectedValue = dtInformacionGeneral.Rows(0)("cod_hora")
                'cmbPuesto.SelectedValue = dtInformacionGeneral.Rows(0)("cod_puesto")
                '  txtIMSS.Text = dtInformacionGeneral.Rows(0)("IMSS") & "-" & dtInformacionGeneral.Rows(0)("DIG_VER")
                '  txtRFC.Text = dtInformacionGeneral.Rows(0)("RFC")
                '  txtCURP.Text = dtInformacionGeneral.Rows(0)("CURP")
                '  txtSactual.Text = Double.Parse(dtInformacionGeneral.Rows(0)("sactual")).ToString("0.00")
                '   txtIntegrado.Text = Double.Parse(dtInformacionGeneral.Rows(0)("integrado")).ToString("0.00")


                Try : txtAlta.Value = dtInformacionGeneral.Rows(0)("alta") : Catch ex As Exception : txtAlta.Value = Nothing : End Try
                '   dtpAlta.Value = dtInformacionGeneral.Rows(0)("alta")

                If IsDBNull(dtInformacionGeneral.Rows(0)("baja")) Then
                    lblBaja.Visible = False
                    txtBaja.Visible = False
                    txtBaja.Value = txtBaja.MinDate

                    txtReloj.BackColor = Color.LimeGreen
                    txtSAP.BackColor = Color.LimeGreen

                Else
                    lblBaja.Visible = True
                    txtBaja.Visible = True
                    Try : txtBaja.Value = dtInformacionGeneral.Rows(0)("BAJA") : Catch ex As Exception : txtBaja.Value = Nothing : End Try
                    '    dtpBaja.Value = dtInformacionGeneral.Rows(0)("BAJA")

                    txtReloj.BackColor = Color.IndianRed
                    txtSAP.BackColor = Color.IndianRed
                End If

                '*********************INFONAVIT

                Dim dtInfonavit As DataTable = sqlExecute("select infonavit_credito, tipo_credito, cuota_credito, inicio_credito from nomina_pro where reloj = '" & _reloj_consulta & "'", "nomina")
                If dtInfonavit.Rows.Count > 0 Then
                    txtNumeroCredito.Text = IIf(IsDBNull(dtInfonavit.Rows(0)("infonavit_credito")), "SIN CREDITO ACTIVO", dtInfonavit.Rows(0)("infonavit_credito"))
                    If txtNumeroCredito.Text = "SIN CREDITO ACTIVO" Then
                        '  panelInfonavit.Visible = False
                        cmbTipoInfonavit.SelectedValue = 0
                        txtFactorDeDescuentoInfonavit.Text = 0
                        dtpFechaInicioCreditoInfonavit.Value = dtpFechaInicioCreditoInfonavit.MinDate

                        btnAgregarSuspenderCreditoInfonavit.Text = "Agregar crédito"

                        '--No mostrar controles
                        Label3.Visible = False
                        Label17.Visible = False
                        Label16.Visible = False
                        cmbTipoInfonavit.Visible = False
                        txtFactorDeDescuentoInfonavit.Visible = False
                        dtpFechaInicioCreditoInfonavit.Visible = False

                    Else
                        '  panelInfonavit.Visible = True
                        Try : cmbTipoInfonavit.SelectedValue = dtInfonavit.Rows(0)("tipo_credito") : Catch ex As Exception : cmbTipoInfonavit.SelectedValue = "0" : End Try
                        Try : txtFactorDeDescuentoInfonavit.Text = Double.Parse(dtInfonavit.Rows(0)("cuota_credito")).ToString("0.0000") : Catch ex As Exception : txtFactorDeDescuentoInfonavit.Text = "" : End Try
                        Try : dtpFechaInicioCreditoInfonavit.Value = dtInfonavit.Rows(0)("inicio_credito") : Catch ex As Exception : dtpFechaInicioCreditoInfonavit.Value = dtpFechaInicioCreditoInfonavit.MinDate : End Try


                        btnAgregarSuspenderCreditoInfonavit.Text = "Suspender crédito"

                        '--Mostrar demás controles
                        Label3.Visible = True
                        Label17.Visible = True
                        Label16.Visible = True
                        cmbTipoInfonavit.Visible = True
                        txtFactorDeDescuentoInfonavit.Visible = True
                        dtpFechaInicioCreditoInfonavit.Visible = True

                    End If

                End If

                Dim dtInfo As DataTable = sqlExecute("select infonavit,tipo_cred,cuota_cred,inicio_cre,suspension,comentario,activo from infonavit where reloj='" & _reloj_consulta & "'", "PERSONAL")
                dgvInfonavit.DataSource = dtInfo
                '***********************TARJETAS

                txtCuentaBanco.Text = ""
                txtTarjetaBanco.Text = ""
                txtClabe.Text = ""

                txtCuentaBonos.Text = ""
                txtTarjetaBonos.Text = ""

                Dim dtTarjetas As DataTable = sqlExecute("select isnull(banco, '') as banco, isnull(cuenta_banco, '') as cuenta_banco, isnull(tarjeta_banco, '') as tarjeta_banco, isnull(clabe, '') as clabe, isnull(cuenta_bonos, '') as cuenta_bonos, isnull(tarjeta_bonos, '') as tarjeta_bonos from personal where reloj = '" & _reloj_consulta & "'")
                If dtTarjetas.Rows.Count > 0 Then
                    Try : cmbBanco.SelectedValue = dtTarjetas.Rows(0)("banco") : Catch ex As Exception : cmbBanco.SelectedValue = "" : End Try
                    Try : txtCuentaBanco.Text = dtTarjetas.Rows(0)("cuenta_banco").ToString.Trim : Catch ex As Exception : txtCuentaBanco.Text = "" : End Try
                    Try : txtTarjetaBanco.Text = dtTarjetas.Rows(0)("tarjeta_banco").ToString.Trim : Catch ex As Exception : txtTarjetaBanco.Text = "" : End Try
                    Try : txtClabe.Text = dtTarjetas.Rows(0)("clabe").ToString.Trim : Catch ex As Exception : txtClabe.Text = "" : End Try
                    Try : txtCuentaBonos.Text = dtTarjetas.Rows(0)("cuenta_bonos").ToString.Trim : Catch ex As Exception : txtCuentaBonos.Text = "" : End Try
                    Try : txtTarjetaBonos.Text = dtTarjetas.Rows(0)("tarjeta_bonos").ToString.Trim : Catch ex As Exception : txtTarjetaBonos.Text = "" : End Try




                    '  cmbBanco.SelectedValue = dtTarjetas.Rows(0)("banco")
                    ' txtCuentaBanco.Text = dtTarjetas.Rows(0)("cuenta_banco").ToString.Trim
                    'txtTarjetaBanco.Text = dtTarjetas.Rows(0)("tarjeta_banco").ToString.Trim
                    ' txtClabe.Text = dtTarjetas.Rows(0)("clabe").ToString.Trim

                    '  txtCuentaBonos.Text = dtTarjetas.Rows(0)("cuenta_bonos").ToString.Trim
                    '  txtTarjetaBonos.Text = dtTarjetas.Rows(0)("tarjeta_bonos").ToString.Trim

                End If

                '*********************-- Pensiones Alimenticias
                Dim dtPensAlim As DataTable = sqlExecute("select id,nombre,no_cuenta,pension,inter,porc,cf from ctas_pens_alim where reloj='" & _reloj_consulta & "' order by pension asc", "PERSONAL")
                dgvPensAlim.DataSource = dtPensAlim

                '**********************-- Maestro de deducciones
                Dim QMtroDed As String = "SELECT CONCEPTOS.CONCEPTO,RTRIM(CONCEPTOS.NOMBRE) AS NOMBRE,NUMCREDITO,ANO,PERIODO,SALDO_ORIG,SALDO_ACT,ABONO_ORIG,ABONO_ACT,SEMANAS_DESC,SEM_RESTAN,STATUS as 'ACTIVO' FROM  MTRO_DED LEFT JOIN CONCEPTOS ON mtro_ded.CONCEPTO = CONCEPTOS.CONCEPTO  WHERE reloj = '" & _reloj_consulta & "' ORDER BY status DESC"
                Dim dtMaestroDeDeducciones As DataTable = sqlExecute(QMtroDed, "NOMINA")
                dgMaestro.DataSource = dtMaestroDeDeducciones

                '**********************HORAS
                Dim dtHoras As DataTable = sqlExecute("select concepto,descripcion,monto,comentario from horas_pro where reloj='" & _reloj_consulta & "'", "NOMINA")
                dgHoras.DataSource = dtHoras

                '**********************MISCELANEOS
                Dim dtAjustes As DataTable = sqlExecute("select concepto,descrip as 'descripcion',monto,clave,saldo,comentario from ajustes_pro where reloj='" & _reloj_consulta & "'", "NOMINA")
                dgvMiscelaneos.DataSource = dtAjustes

                '**********************CALCULO DETALLE (Movimientos)
                Dim dtMovsPro As DataTable = sqlExecute("select m.concepto,UPPER(c.nombre) as 'descripcion',m.monto from movimientos_pro m left outer join conceptos c on m.concepto=c.concepto  where m.reloj='" & _reloj_consulta & "' and c.COD_NATURALEZA in('P','D','T') order by c.grupo asc", "NOMINA")
                dgMovimientos.DataSource = dtMovsPro

            Else
                MessageBox.Show("El empleado no está agregado en la nómina", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                MostrarInformacion(txtReloj.Text.Trim)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnAgregarSuspenderCreditoInfonavit_Click(sender As Object, e As EventArgs) Handles btnAgregarSuspenderCreditoInfonavit.Click
        Try
            Dim rj As String = ""
            If btnAgregarSuspenderCreditoInfonavit.Text.Contains("Agregar") Then
                Dim frm As New frmAgregarCreditoInfonavit

                rj = txtReloj.Text.Trim
                frm._reloj_agregar_infonavit = rj
                frm._nombres_agregar_infonavit = lblNombres.Text
                frm._fecha_alta = txtAlta.Value

                frm.ShowDialog()
            ElseIf btnAgregarSuspenderCreditoInfonavit.Text.Contains("Suspender") Then
                Dim frm As New frmSuspenderCreditoInfonavit
                rj = txtReloj.Text.Trim
                frm._reloj_suspender_infonavit = rj
                frm._nombres_suspender_infonavit = lblNombres.Text
                frm._fecha_alta = txtAlta.Value
                frm._numero_credito_suspender = txtNumeroCredito.Text

                frm.ShowDialog()
            End If
            rj = txtReloj.Text.Trim
            sqlExecute("update nomina_pro set infonavit_credito = null, tipo_credito = null, cuota_credito = null, inicio_credito = null, cobro_segviv = 0 where reloj = '" & rj & "'", "nomina")

            Dim dtInfonavit As DataTable = sqlExecute("select * from infonavit where activo = 1 and reloj = '" & rj & "' order by inicio_cre asc")
            For Each row_infonavit As DataRow In dtInfonavit.Rows

                sqlExecute("update nomina_pro set infonavit_credito = '" & row_infonavit("infonavit") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")
                sqlExecute("update nomina_pro set tipo_credito = '" & row_infonavit("tipo_cred") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")
                sqlExecute("update nomina_pro set cuota_credito = '" & row_infonavit("cuota_cred") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")
                sqlExecute("update nomina_pro set inicio_credito = '" & row_infonavit("inicio_cre") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")
                sqlExecute("update nomina_pro set cobro_segviv= '" & row_infonavit("cobro_segv") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")

            Next

            MostrarInformacion(rj)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnModificarFactor_Click(sender As Object, e As EventArgs)
        Try

            Dim frm As New froModificarFactorCreditoInfonavit
            Dim rj As String = txtReloj.Text.Trim
            frm._reloj_agregar_infonavit = rj
            frm._nombres_agregar_infonavit = lblNombres.Text
            frm._fecha_alta = txtAlta.Value

            frm._credito_modificar = txtNumeroCredito.Text
            frm._tipo_credito_modificar = cmbTipoInfonavit.SelectedValue
            frm._factor_credito_modificar = txtFactorDeDescuentoInfonavit.Text

            frm.ShowDialog()


            sqlExecute("update nomina_pro set infonavit_credito = null, tipo_credito = null, cuota_credito = null, inicio_credito = null, cobro_segviv = 0 where reloj = '" & rj & "'", "nomina")

            Dim dtInfonavit As DataTable = sqlExecute("select * from infonavit where activo = 1 and reloj = '" & rj & "' order by inicio_cre asc")
            For Each row_infonavit As DataRow In dtInfonavit.Rows

                sqlExecute("update nomina_pro set infonavit_credito = '" & row_infonavit("infonavit") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")
                sqlExecute("update nomina_pro set tipo_credito = '" & row_infonavit("tipo_cred") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")
                sqlExecute("update nomina_pro set cuota_credito = '" & row_infonavit("cuota_cred") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")
                sqlExecute("update nomina_pro set inicio_credito = '" & row_infonavit("inicio_cre") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")
                sqlExecute("update nomina_pro set cobro_segviv= '" & row_infonavit("cobro_segv") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")

            Next

            MostrarInformacion(rj)
        Catch ex As Exception

        End Try
    End Sub

    ' functiones auxiliares

    Private Sub CargarCatalogos()
        Try
            Dim dtCias As DataTable = sqlExecute("select cod_comp, nombre from cias")
            cmbCias.DataSource = dtCias
            cmbCias.ValueMember = "cod_comp"

            Dim dtPlantas As DataTable = sqlExecute("select cod_planta, nombre from plantas")
            cmbPlanta.DataSource = dtPlantas
            cmbPlanta.ValueMember = "cod_planta"

            Dim dtDeptos As DataTable = sqlExecute("select cod_depto, nombre from deptos")
            cmbDepto.DataSource = dtDeptos
            cmbDepto.ValueMember = "cod_depto"

            Dim dtAreas As DataTable = sqlExecute("select cod_area, nombre from areas")
            cmbArea.DataSource = dtAreas
            cmbArea.ValueMember = "cod_area"

            Dim dtTipoPeriodo As DataTable = sqlExecute("select tipo_periodo, nombre from tipo_periodo")
            cmbTipoPeriodo.DataSource = dtTipoPeriodo
            cmbTipoPeriodo.ValueMember = "tipo_periodo"

            Dim dtTipoEmpleado As DataTable = sqlExecute("select cod_tipo, nombre from tipo_emp")
            cmbTipo.DataSource = dtTipoEmpleado
            cmbTipo.ValueMember = "cod_tipo"

            Dim dtTipoClase As DataTable = sqlExecute("select cod_clase, nombre from clase")
            cmbClase.DataSource = dtTipoClase
            cmbClase.ValueMember = "cod_clase"

            Dim dtTurno As DataTable = sqlExecute("select cod_turno, nombre from turnos")
            cmbTurno.DataSource = dtTurno
            cmbTurno.ValueMember = "cod_turno"

            Dim dtHorario As DataTable = sqlExecute("select cod_hora, nombre from horarios")
            cmbHora.DataSource = dtHorario
            cmbHora.ValueMember = "cod_hora"

            Dim dtPuesto As DataTable = sqlExecute("select cod_puesto, nombre from puestos")
            cmbPuesto.DataSource = dtPuesto
            cmbPuesto.ValueMember = "cod_puesto"


            Dim dtTipoInfonavit As New DataTable
            dtTipoInfonavit.Columns.Add("tipo")
            dtTipoInfonavit.Columns.Add("nombre")

            dtTipoInfonavit.Rows.Add({"1", "Porcentaje"})
            dtTipoInfonavit.Rows.Add({"2", "Cuota fija"})
            dtTipoInfonavit.Rows.Add({"3", "VSM"})

            cmbTipoInfonavit.DataSource = dtTipoInfonavit
            cmbTipoInfonavit.ValueMember = "tipo"

            '--- Bancos
            Dim dtBancos As DataTable = sqlExecute("select * from bancos")
            cmbBanco.DataSource = dtBancos
            cmbBanco.ValueMember = "banco"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Try
            Dim dtFirst As DataTable = sqlExecute("select top 1 * from nomina_pro order by reloj asc", "nomina")
            _reloj_consulta = dtFirst.Rows(0)("reloj")

            btnFirst.Enabled = False
            btnPrev.Enabled = False
            btnNext.Enabled = True
            btnLast.Enabled = True

            MostrarInformacion(_reloj_consulta)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Try
            Dim dtLast As DataTable = sqlExecute("select top 1 * from nomina_pro order by reloj desc", "nomina")
            _reloj_consulta = dtLast.Rows(0)("reloj")

            btnFirst.Enabled = True
            btnPrev.Enabled = True
            btnNext.Enabled = False
            btnLast.Enabled = False

            MostrarInformacion(_reloj_consulta)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Try
            Dim dtPrev As DataTable = sqlExecute("select reloj from nomina_pro where reloj < '" & _reloj_consulta & "'  order by reloj desc", "nomina")
            If dtPrev.Rows.Count > 0 Then
                _reloj_consulta = dtPrev.Rows(0)("reloj")

                If dtPrev.Rows.Count > 1 Then
                    btnFirst.Enabled = True
                    btnPrev.Enabled = True
                Else
                    btnFirst.Enabled = False
                    btnPrev.Enabled = False
                End If



                btnNext.Enabled = True
                btnLast.Enabled = True

                MostrarInformacion(_reloj_consulta)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            Dim dtNext As DataTable = sqlExecute("select reloj from nomina_pro where reloj > '" & _reloj_consulta & "'  order by reloj asc", "nomina")
            If dtNext.Rows.Count > 0 Then
                _reloj_consulta = dtNext.Rows(0)("reloj")

                btnFirst.Enabled = True
                btnPrev.Enabled = True

                If dtNext.Rows.Count > 1 Then
                    btnNext.Enabled = True
                    btnLast.Enabled = True
                Else
                    btnNext.Enabled = False
                    btnLast.Enabled = False
                End If


                MostrarInformacion(_reloj_consulta)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtTemp = dtInformacionGeneral
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtInformacionGeneral = dtTemp
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        '----NOTA: Solo se va a editar, no agregar
        Try
            If (btnEditar.Text = "Cancelar") Then
                Editar = False
                HabilitarMtroNomina()
                Exit Sub
            End If

            Editar = True
            HabilitarMtroNomina()
            cmbPlanta.Focus()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub HabilitarMtroNomina()    '---Habilita los controles para su edición
        Try
            '--Botón para editar
            If (Editar) Then
                ' btnNuevo.Image = My.Resources.Ok16
                btnEditar.Image = My.Resources.Cancel16

                '   btnNuevo.Text = "Aceptar"
                btnEditar.Text = "Cancelar"
                btnAceptar.Visible = True
            Else
                btnEditar.Image = My.Resources.Edit
                btnEditar.Text = "Editar"
                btnAceptar.Visible = False
            End If



            '--Datos Generales
            cmbPlanta.Enabled = Editar
            cmbDepto.Enabled = Editar
            cmbArea.Enabled = Editar
            cmbTipo.Enabled = Editar
            cmbClase.Enabled = Editar
            cmbTurno.Enabled = Editar
            cmbHora.Enabled = Editar
            cmbPuesto.Enabled = Editar
            txtIMSS.Enabled = Editar
            txtRFC.Enabled = Editar
            txtCURP.Enabled = Editar
            txtSactual.Enabled = Editar

            '---Datos de Infonavit
            ' txtNumeroCredito.Enabled = Editar
            txtFactorDeDescuentoInfonavit.Enabled = Editar
            cmbTipoInfonavit.Enabled = Editar
            dtpFechaInicioCreditoInfonavit.Enabled = Editar

            cmbBanco.Enabled = Editar
            txtCuentaBanco.Enabled = Editar
            txtTarjetaBanco.Enabled = Editar
            txtClabe.Enabled = Editar
            txtCuentaBonos.Enabled = Editar
            txtTarjetaBonos.Enabled = Editar

            '----Para mostrar los btones de edición para cada uno de los tabs que lo requiera
            Dim tab As String = SuperTabControl1.SelectedTab.Name
            If (tab = "tabInfo") Then
                lblNotaEditar.Text = "NOTA: Los cambios efectuados en esta pantalla solo afectaran exclusivamente al cálculo de nómina"
                lblNotaEditar.Visible = Editar
            End If
            If (tab = "tabHoras" Or tab = "tabPensAlim" Or tab = "tabMtroDed" Or tab = "tabMisc") Then
                pnlBotMisc.Enabled = Editar
                pnlBotMisc.Visible = Editar
            End If

            If (tab = "tabCalculo") Then
                '  btnRecalcular.Visible = Editar
                btnRecalcular.Visible = True
            End If



            '-DataGridViews
            dgMaestro.Enabled = Editar
            dgHoras.Enabled = Editar
            dgvMiscelaneos.Enabled = Editar

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click ' Guardar cambios
        AceptarCambios()
    End Sub
    Private Sub AceptarCambios() '***---- Actualiza campos en nomina_pro y en las tablas origen que son las principales
        Dim Rj As String = "", cod_planta As String = "", cod_depto As String = "", cod_area As String = "", cod_tipo As String = "", cod_clase As String = "", cod_turno As String = "", cod_hora As String = "", cod_puesto As String = ""
        Dim banco As String = "", cuenta_banco As String = "", tarjeta_banco As String = "", clabe As String = "", cuenta_bonos As String = "", tarjeta_bonos As String = ""
        Dim infonavit As String = "", tipo_cred As String = "", cuota_cred As String = "", inicio_cre As String = ""
        Try
            Rj = txtReloj.Text.Trim

            '---Información General
            cod_planta = cmbPlanta.SelectedValue
            cod_depto = cmbDepto.SelectedValue
            cod_area = cmbArea.SelectedValue
            cod_tipo = cmbTipo.SelectedValue
            cod_clase = cmbClase.SelectedValue
            cod_turno = cmbTurno.SelectedValue
            cod_hora = cmbHora.SelectedValue
            cod_puesto = cmbPuesto.SelectedValue

            EditaEmpleado(Rj, "cod_planta", cod_planta)
            EditaEmpleado(Rj, "cod_depto", cod_depto)
            EditaEmpleado(Rj, "cod_area", cod_area)
            EditaEmpleado(Rj, "cod_tipo", cod_tipo)
            EditaEmpleado(Rj, "cod_clase", cod_clase)
            EditaEmpleado(Rj, "cod_turno", cod_turno)
            EditaEmpleado(Rj, "cod_hora", cod_hora)
            EditaEmpleado(Rj, "cod_puesto", cod_puesto)

            '----INFONAVIT
            infonavit = txtNumeroCredito.Text.Trim
            tipo_cred = cmbTipoInfonavit.SelectedValue
            cuota_cred = txtFactorDeDescuentoInfonavit.Text
            inicio_cre = FechaSQL(dtpFechaInicioCreditoInfonavit.Value)

            EditaInfonavit(Rj, infonavit, "tipo_cred", tipo_cred)
            EditaInfonavit(Rj, infonavit, "cuota_cred", cuota_cred)
            EditaInfonavit(Rj, infonavit, "inicio_cre", inicio_cre)

            '---Tarjetas
            banco = cmbBanco.SelectedValue
            cuenta_banco = txtCuentaBanco.Text.Trim
            tarjeta_banco = txtTarjetaBanco.Text.Trim
            clabe = txtClabe.Text.Trim
            cuenta_bonos = txtCuentaBonos.Text.Trim
            tarjeta_bonos = txtTarjetaBonos.Text.Trim


            EditaEmpleado(Rj, "banco", banco)
            EditaEmpleado(Rj, "cuenta_banco", cuenta_banco)
            EditaEmpleado(Rj, "tarjeta_banco", tarjeta_banco)
            EditaEmpleado(Rj, "clabe", clabe)
            EditaEmpleado(Rj, "cuenta_bonos", cuenta_bonos)
            EditaEmpleado(Rj, "tarjeta_bonos", tarjeta_bonos)
            If (cuenta_banco.Trim <> "" Or clabe.Trim <> "") Then EditaEmpleado(Rj, "cod_pago", "D")




            '----Pensiones alimenticias

            '----Maestro de deducciones

            '----Horas

            Editar = False
            HabilitarMtroNomina()
            MostrarInformacion(Rj)


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub EditaEmpleado(ByVal Reloj As String, ByVal Campo As String, ByVal Valor As Object)
        Try
            Dim cadena As String = ""
            Dim TipoMovimiento As String = "C"
            Dim anioPer As String = anio & periodo
            Dim actualiza_Personal As Boolean = True

            '----Campos que no aplican actualizar en la tabla personal
            If (Campo = "cod_planta" Or Campo = "cod_depto" Or Campo = "cod_area" Or Campo = "cod_tipo" Or Campo = "cod_clase" Or Campo = "cod_turno" Or Campo = "cod_hora" Or Campo = "cod_puesto") Then
                actualiza_Personal = False
            End If



            If TypeOf Valor Is Double Or TypeOf Valor Is Integer Then ' Si es tipo double o Integer
            ElseIf TypeOf Valor Is Boolean Then ' Si es bOOLEANO
            ElseIf TypeOf Valor Is Date Then ' Si es tipo fecha

            Else ' Cualquier otro, va  ser tpo String
                Dim ValAnt As String = "" ' Guarda el val anterior para meterlo a bitácora
                dtTemp = sqlExecute("SELECT " & Campo & " from nomina_pro WHERE reloj = '" & Reloj & "'", "NOMINA")
                Try : ValAnt = dtTemp.Rows.Item(0).Item(0) : Catch ex As Exception : ValAnt = "" : End Try
                If (Valor Is Nothing Or Valor = "") Then Valor = ""

                If (ValAnt.Trim <> Valor.ToString.Trim) Then
                    '---Guardar en bitácora el cambio
                    cadena = "INSERT INTO bitacora_nomina (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,anoper) VALUES ('"
                    cadena = cadena & Reloj & "','" & Campo & "','" & ValAnt & "','" & Valor & "','" & Usuario & "',GETDATE(),'" & TipoMovimiento & "','" & anioPer & "')"
                    sqlExecute(cadena, "NOMINA")

                    If Valor = "NULL" Then
                        sqlExecute("UPDATE nomina_pro SET " & Campo & " = NULL WHERE reloj = '" & Reloj & "'", "NOMINA")
                    Else
                        sqlExecute("UPDATE nomina_pro SET " & Campo & " = '" & Valor & "' WHERE reloj = '" & Reloj & "'", "NOMINA")

                        If (actualiza_Personal) Then ' También actualizamos la tabla principal que es PERSONAL pero solo para los campos que apliquen
                            sqlExecute("UPDATE personal SET " & Campo & " = '" & Valor & "' WHERE reloj = '" & Reloj & "'", "PERSONAL")
                        End If

                    End If

                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub EditaInfonavit(ByVal _rj As String, _infonavit As String, ByVal Campo As String, ByVal Valor As Object)
        Try
            Dim cadena As String = ""
            Dim TipoMovimiento As String = "C"
            Dim anioPer As String = anio & periodo
            Dim campo_nomPro As String = ""

            Select Case Campo
                Case "tipo_cred"
                    campo_nomPro = "tipo_credito"
                Case "cuota_cred"
                    campo_nomPro = "cuota_credito"
                Case "inicio_cre"
                    campo_nomPro = "inicio_credito"
            End Select

            Dim _nombres_agregar_infonavit As String = "", alta As String = ""
            Dim dtPersonalNomb As DataTable = sqlExecute("select reloj,nombres,alta from personalvw where reloj='" & _rj & "'", "PERSONAL")
            If (Not dtPersonalNomb.Columns.Contains("Error") And dtPersonalNomb.Rows.Count > 0) Then
                Try : _nombres_agregar_infonavit = dtPersonalNomb.Rows(0).Item("nombres").ToString.Trim : Catch ex As Exception : _nombres_agregar_infonavit = "" : End Try
                Try : alta = FechaSQL(dtPersonalNomb.Rows(0).Item("alta")) : Catch ex As Exception : alta = "" : End Try
            End If


            If TypeOf Valor Is Double Or TypeOf Valor Is Integer Then ' Si es tipo double o Integer
            ElseIf TypeOf Valor Is Boolean Then ' Si es bOOLEANO
            ElseIf TypeOf Valor Is Date Then ' Si es tipo fecha

            Else ' Cualquier otro, va  ser tpo String
                Dim ValAnt As String = "" ' Guarda el val anterior para meterlo a bitácora
                dtTemp = sqlExecute("SELECT " & campo_nomPro & " from nomina_pro WHERE reloj = '" & _rj & "'", "NOMINA")
                Try : ValAnt = dtTemp.Rows.Item(0).Item(0) : Catch ex As Exception : ValAnt = "" : End Try
                If (Valor Is Nothing Or Valor = "") Then Valor = ""

                If (ValAnt.Trim <> Valor.ToString.Trim) Then
                    '---Guardar en bitácora el cambio
                    cadena = "INSERT INTO bitacora_nomina (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,anoper) VALUES ('"
                    cadena = cadena & _rj & "','" & Campo & "','" & ValAnt & "','" & Valor & "','" & Usuario & "',GETDATE(),'" & TipoMovimiento & "','" & anioPer & "')"
                    sqlExecute(cadena, "NOMINA")

                    If Valor = "NULL" Then
                        sqlExecute("UPDATE nomina_pro SET " & campo_nomPro & " = NULL WHERE reloj = '" & _rj & "' and infonavit_credito='" & _infonavit & "'", "NOMINA")
                    Else
                        '---Validar si existe
                        Dim dtExistInfo As DataTable = sqlExecute("select * from infonavit where reloj='" & _rj & "' and infonavit='" & _infonavit & "' and tipo_cred='" & cmbTipoInfonavit.SelectedValue & "' and cuota_cred=" & txtFactorDeDescuentoInfonavit.Text & " and inicio_cre='" & FechaSQL(dtpFechaInicioCreditoInfonavit.Value) & "'", "PERSONAL")
                        If (Not dtExistInfo.Columns.Contains("Error") And dtExistInfo.Rows.Count > 0) Then
                            '  GoTo SaltaInsertInfo
                            '---AOS : 2022-02-22 Eliminar dicho registros para que vuelva a ser reinsertado
                            sqlExecute("delete from infonavit where reloj='" & _rj & "' and infonavit='" & _infonavit & "' and tipo_cred='" & cmbTipoInfonavit.SelectedValue & "' and cuota_cred=" & txtFactorDeDescuentoInfonavit.Text & " and inicio_cre='" & FechaSQL(dtpFechaInicioCreditoInfonavit.Value) & "'", "PERSONAL")
                        End If

                        '---AOS 2022-02-22 - Eliminar todos los registros con valor a cero
                        sqlExecute("delete from infonavit where reloj='" & _rj & "' and isnull(cuota_cred,0.00)=0.00", "PERSONAL")

                        sqlExecute("UPDATE nomina_pro SET " & campo_nomPro & " = '" & Valor & "' WHERE reloj = '" & _rj & "' and infonavit_credito='" & _infonavit & "'", "NOMINA")
                        '   sqlExecute("UPDATE infonavit SET " & Campo & " = '" & Valor & "' WHERE reloj = '" & _rj & "' and infonavit='" & _infonavit & "'", "PERSONAL") ' También actualizamos la tabla principal que es PERSONAL
                        '----AOS: 10/06/2021 : Agregamos el nuevo registro con el dato cambiado
                        sqlExecute("update infonavit set activo=0 where reloj='" & _rj & "'", "PERSONAL") ' Actualizamos todos los infonavit como no activos, para dejar el que se va agregar como activo
                        '---- Proceso para insertar el nuevo registro con el cambio:
                        sqlExecute("insert into infonavit (reloj, infonavit, activo, cobro_segv,usuario,fechahora) values ('" & _rj & "', '" & _infonavit & "', 1, 1,'" & Usuario & "',getdate())", "PERSONAL")
                        sqlExecute("update infonavit set nombres = '" & _nombres_agregar_infonavit & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")
                        sqlExecute("update infonavit set alta = '" & alta & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")

                        sqlExecute("update infonavit set tipo_cred = '" & cmbTipoInfonavit.SelectedValue & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")
                        sqlExecute("update infonavit set cuota_cred = '" & txtFactorDeDescuentoInfonavit.Text & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")
                        sqlExecute("update infonavit set inicio_cre = '" & FechaSQL(dtpFechaInicioCreditoInfonavit.Value) & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")

                        '--- Actualizar en PERSONAL  ::   update personal set INFONAVIT='',DIG_VER_IN='',FECHA_CRE='',TIPO_CRE='',PAGO_INF=0.0,PAGO_SEGVI=1,CREDITO_IN=1 where reloj='00002'
                        Dim DIG_VER_IN As String = "", PAGO_SEGVI As Integer = 0, CREDITO_IN As Integer = 0
                        PAGO_SEGVI = 1
                        CREDITO_IN = 1
                        Try : DIG_VER_IN = _infonavit.Substring(10, 1).ToString.Trim : Catch ex As Exception : DIG_VER_IN = "" : End Try
                        Dim QUp As String = "update personal set INFONAVIT='" & _infonavit & "',DIG_VER_IN='" & DIG_VER_IN & "',FECHA_CRE='" & FechaSQL(dtpFechaInicioCreditoInfonavit.Value) & "',TIPO_CRE='" & cmbTipoInfonavit.SelectedValue & "',PAGO_INF=" & Double.Parse(txtFactorDeDescuentoInfonavit.Text) & ",PAGO_SEGVI=" & PAGO_SEGVI & ",CREDITO_IN=" & CREDITO_IN & " where reloj='" & _rj & "'"
                        sqlExecute(QUp, "PERSONAL")

                        'SaltaInsertInfo: ' aos 2022-02-22 se comenta esta linea
                    End If

                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub pnlCentrarControles_Paint(sender As Object, e As PaintEventArgs) Handles pnlCentrarControles.Paint

    End Sub

    Private Sub tabHoras_Click(sender As Object, e As EventArgs) Handles tabHoras.Click
        btnRecalcular.Visible = False
        lblNotaEditar.Visible = False
        btnEditar.Visible = True
        If (Editar) Then
            pnlBotMisc.Enabled = True
            pnlBotMisc.Visible = True

        Else
            pnlBotMisc.Enabled = False
            pnlBotMisc.Visible = False
        End If
    End Sub
    Private Sub tabPensAlim_Click(sender As Object, e As EventArgs) Handles tabPensAlim.Click
        btnRecalcular.Visible = False
        lblNotaEditar.Visible = False
        btnEditar.Visible = True
        If (Editar) Then
            pnlBotMisc.Enabled = True
            pnlBotMisc.Visible = True
        Else
            pnlBotMisc.Enabled = False
            pnlBotMisc.Visible = False
        End If
    End Sub
    Private Sub tabMtroDed_Click(sender As Object, e As EventArgs) Handles tabMtroDed.Click
        btnRecalcular.Visible = False
        lblNotaEditar.Visible = False
        btnEditar.Visible = True
        If (Editar) Then
            pnlBotMisc.Enabled = True
            pnlBotMisc.Visible = True
        Else
            pnlBotMisc.Enabled = False
            pnlBotMisc.Visible = False
        End If
    End Sub

    Private Sub tabMisc_Click(sender As Object, e As EventArgs) Handles tabMisc.Click
        btnRecalcular.Visible = False
        lblNotaEditar.Visible = False
        btnEditar.Visible = True
        If (Editar) Then
            pnlBotMisc.Enabled = True
            pnlBotMisc.Visible = True
        Else
            pnlBotMisc.Enabled = False
            pnlBotMisc.Visible = False
        End If
    End Sub


    Private Sub tabInfo_Click(sender As Object, e As EventArgs) Handles tabInfo.Click
        pnlBotMisc.Enabled = False
        pnlBotMisc.Visible = False
        btnRecalcular.Visible = False
        btnEditar.Visible = True
        If (Editar) Then
            lblNotaEditar.Text = "NOTA: Los cambios efectuados en esta pantalla solo afectaran exclusivamente al cálculo de nómina"
            lblNotaEditar.Visible = Editar
        End If
    End Sub

    Private Sub tabInfonavit_Click(sender As Object, e As EventArgs) Handles tabInfonavit.Click
        pnlBotMisc.Enabled = False
        pnlBotMisc.Visible = False
        btnRecalcular.Visible = False
        lblNotaEditar.Visible = False
        btnEditar.Visible = True
    End Sub

    Private Sub tabTarjetas_Click(sender As Object, e As EventArgs) Handles tabTarjetas.Click
        pnlBotMisc.Enabled = False
        pnlBotMisc.Visible = False
        btnRecalcular.Visible = False
        lblNotaEditar.Visible = False
        btnEditar.Visible = True
    End Sub

    Private Sub tabCalculo_Click(sender As Object, e As EventArgs) Handles tabCalculo.Click
        pnlBotMisc.Enabled = False
        pnlBotMisc.Visible = False
        lblNotaEditar.Visible = False
        btnEditar.Visible = False
        '  If (Editar) Then btnRecalcular.Visible = True
        btnRecalcular.Visible = True
    End Sub

    Private Sub btnAgregarMisc_Click(sender As Object, e As EventArgs) Handles btnAgregarMisc.Click
        Dim tab As String = SuperTabControl1.SelectedTab.Name

        Dim Respuesta As Windows.Forms.DialogResult
        CalcIndivKey = "NVO"
        Select Case tab
            Case "tabPensAlim"
                AddNewPensAlim = True
                Respuesta = frmEditarPensAlim.ShowDialog(Me)
            Case "tabHoras"
                Respuesta = frmEditarHoras.ShowDialog(Me)
            Case "tabMisc"
                Respuesta = frmEditarAjPro.ShowDialog(Me)
        End Select


        If Respuesta = Windows.Forms.DialogResult.Abort Then
            MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf Respuesta = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        MostrarInformacion(txtReloj.Text)
    End Sub

    Private Sub btnEditMisc_Click(sender As Object, e As EventArgs) Handles btnEditMisc.Click
        Dim dtAjuste As New DataTable
        Dim tab As String = SuperTabControl1.SelectedTab.Name
        Try
            If (tab = "tabPensAlim") Then
                AddNewPensAlim = False
                CalcIndivKey = dgvPensAlim.Item("clId", dgvPensAlim.CurrentRow.Index).Value.ToString.Trim
                dtAjuste = sqlExecute("select * from ctas_pens_alim where id=" & CalcIndivKey & " and reloj='" & txtReloj.Text.Trim & "' ORDER by pension asc", "PERSONAL")

                If (dtAjuste.Columns.Contains("Error") Or dtAjuste.Rows.Count <= 0) Then
                    Err.Raise(-1)
                    Exit Sub
                End If

                If frmEditarPensAlim.ShowDialog(Me) = Windows.Forms.DialogResult.Abort Then
                    Err.Raise(-1)
                End If
            End If

            If (tab = "tabHoras") Then
                CalcIndivKey = dgHoras.Item("cLConcep", dgHoras.CurrentRow.Index).Value.ToString.Trim
                dtAjuste = sqlExecute("SELECT * from horas_pro where reloj='" & txtReloj.Text.Trim & "' and concepto='" & CalcIndivKey & "'", "NOMINA")

                If (dtAjuste.Columns.Contains("Error") Or dtAjuste.Rows.Count <= 0) Then
                    Err.Raise(-1)
                    Exit Sub
                End If

                If frmEditarHoras.ShowDialog(Me) = Windows.Forms.DialogResult.Abort Then
                    Err.Raise(-1)
                End If
            End If

            If (tab = "tabMisc") Then
                CalcIndivKey = dgvMiscelaneos.Item("cLConcepAj", dgvMiscelaneos.CurrentRow.Index).Value.ToString.Trim
                dtAjuste = sqlExecute("SELECT * from ajustes_pro where reloj='" & txtReloj.Text.Trim & "' and concepto='" & CalcIndivKey & "'", "NOMINA")

                If (dtAjuste.Columns.Contains("Error") Or dtAjuste.Rows.Count <= 0) Then
                    Err.Raise(-1)
                    Exit Sub
                End If

                If frmEditarAjPro.ShowDialog(Me) = Windows.Forms.DialogResult.Abort Then
                    Err.Raise(-1)
                End If

            End If


            MostrarInformacion(txtReloj.Text)
        Catch ex As Exception
            MessageBox.Show("El registro no puede ser modificado. Favor de verificar." & vbCrLf & ex.Message, "Editar ajuste", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBorrarMisc_Click(sender As Object, e As EventArgs) Handles btnBorrarMisc.Click
        Dim dtBorra As New DataTable
        Dim tab As String = SuperTabControl1.SelectedTab.Name
        Try
            If (tab = "tabPensAlim") Then
                CalcIndivKey = dgvPensAlim.Item("clId", dgvPensAlim.CurrentRow.Index).Value.ToString.Trim
                If MessageBox.Show("¿Está seguro de eliminar la pensión alimentica seleccionada?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    sqlExecute("delete from ctas_pens_alim where id='" & CalcIndivKey & "' and reloj='" & txtReloj.Text.Trim & "'", "PERSONAL")
                End If
            End If

            If (tab = "tabHoras") Then
                CalcIndivKey = dgHoras.Item("cLConcep", dgHoras.CurrentRow.Index).Value.ToString.Trim
                If MessageBox.Show("¿Está seguro de borrar el concepto " & CalcIndivKey & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    sqlExecute("delete from horas_pro where reloj='" & txtReloj.Text & "' and concepto='" & CalcIndivKey & "'", "NOMINA")
                End If
            End If

            If (tab = "tabMisc") Then
                CalcIndivKey = dgvMiscelaneos.Item("cLConcepAj", dgvMiscelaneos.CurrentRow.Index).Value.ToString.Trim
                If MessageBox.Show("¿Está seguro de borrar el concepto " & CalcIndivKey & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    sqlExecute("delete from ajustes_pro where reloj='" & txtReloj.Text & "' and concepto='" & CalcIndivKey & "'", "NOMINA")
                End If
            End If

            MostrarInformacion(txtReloj.Text)
        Catch ex As Exception
            MessageBox.Show("El registro no puede ser eliminado. Favor de verificar." & vbCrLf & ex.Message, "Eliminar ajuste", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pnlInferior_Paint(sender As Object, e As PaintEventArgs) Handles pnlInferior.Paint

    End Sub

    Private Sub btnRecalcular_Click(sender As Object, e As EventArgs) Handles btnRecalcular.Click
        '--- Recalcular solo al empleado
        Dim Rj As String = ""
        Rj = txtReloj.Text.Trim

        Try
            frmCalcNom.CalculoNomina(anio, periodo, "I", "procesar=1", Rj)

            sqlExecute("update nomina_pro set recalc_nom=1 where reloj='" & Rj & "'", "NOMINA")  '-**-Indicar que el movimiento fue recalculado

            MostrarInformacion(Rj)
        Catch ex As Exception
            MessageBox.Show("El empleado no puede ser Recalculado. Favor de verificar." & vbCrLf & ex.Message, "Recalcular empleado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvPensAlim_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPensAlim.CellContentDoubleClick

    End Sub

    Private Sub dgHoras_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgHoras.CellDoubleClick
        If (Editar) Then btnEditMisc.PerformClick()
    End Sub

    Private Sub dgvPensAlim_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPensAlim.CellDoubleClick
        If (Editar) Then btnEditMisc.PerformClick()
    End Sub

    Private Sub dgMaestro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMaestro.CellDoubleClick
        If (Editar) Then btnEditMisc.PerformClick()
    End Sub

    Private Sub dgvMiscelaneos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMiscelaneos.CellDoubleClick
        If (Editar) Then btnEditMisc.PerformClick()
    End Sub

    Private Sub txtCuentaBanco_TextChanged(sender As Object, e As EventArgs) Handles txtCuentaBanco.TextChanged
        ' txtCuentaBanco.Text = txtCuentaBanco.Text
    End Sub

    Private Sub lblNotaEditar_Click(sender As Object, e As EventArgs) Handles lblNotaEditar.Click

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

    End Sub
End Class