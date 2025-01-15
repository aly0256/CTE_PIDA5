Public Class frmAjusteFiniquito

    Dim dtRegistro As New DataTable
    Dim dtPeriodos As New DataTable
    Dim dtConceptos As New DataTable
    Dim dtConcGrid As New DataTable
    Dim dtCompania As New DataTable
    Dim dtNominaBaseProcesada As New DataTable

    Dim TipoEmp As String = ""
    Dim PeriodoAct As String = ""
    Dim strPeriodo As String = ""
    Dim Clave As String = ""
    Dim FhaBaja As Boolean
    Dim FhaAlta As Boolean
    Dim FhaAntig As Boolean
    Dim EsCaptura As Boolean
    Dim BandPer As Boolean
    Dim EsCambioValor As Boolean
    Dim EsCargaIni As Boolean
    Dim Escomplemento As Boolean
    Dim EsAltaMayorAPeriodo As Boolean
    Dim folioAnt As String = ""

    '*** Nuevas Variables
    Dim sUltimaNominaProcesada As String = ""
    Dim sNominaEnProceso As String = ""
    Dim sNominaAProcesar As String = ""
    Dim sFechaFiniquito As String = ""
    Dim sFechaAltaEmpleado As String = ""

    Private Function NominaBase() As DataTable

        Dim frm As New frmTrabajando

        Dim dtNominaBase As New DataTable
        Dim dtDatos As New DataTable

        Dim strSQL As String = ""

        Try

            dtNominaBase.Columns.Add("unico", GetType(System.String))
            dtNominaBase.Columns.Add("año", GetType(System.String))
            dtNominaBase.Columns.Add("periodo", GetType(System.String))
            dtNominaBase.Columns.Add("fecha_ini", GetType(System.String))
            dtNominaBase.Columns.Add("fecha_fin", GetType(System.String))

            EsAltaMayorAPeriodo = False

            strSQL = "declare @Reloj varchar(max) = '" & txtReloj.Text.Trim & "';" & vbCr &
                            "declare @Alta char(10) = '" & sFechaAltaEmpleado & "';" & vbCr

            Select Case TipoEmp.Trim.ToUpper

                Case Is = "O"

                    strSQL &= "with S0 as (" & vbCr &
                        "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin, 'N' as 'Alta_Mayor' " & vbCr &
                        "from periodos " & vbCr &
                        "WHERE  (ano+periodo) in (select distinct (ano+periodo) as 'periodo' from nomina.dbo.nomina where reloj = @Reloj) and  (periodo_especial IS NULL OR periodo_especial = 0)" & vbCr &
                        "ORDER BY ano DESC,periodo DESC" & vbCr &
                        "),S1 as (" & vbCr &
                        "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin,'S' as 'Alta_Mayor' " & vbCr &
                        "from periodos " & vbCr &
                        "where (DATEADD(DAY,-7,@Alta) between fecha_ini and fecha_fin) and (periodo_especial is null or periodo_especial = 0)" & vbCr &
                        "order by ano desc, periodo desc" & vbCr &
                        "),S3 as (" & vbCr &
                        "select * from S0 union select * from S1" & vbCr &
                        ") select top 1 unico,año,periodo,fecha_ini,fecha_fin,Alta_Mayor from S3 order by unico desc"

                Case Is = "A"

                    strSQL &= "with S0 as (" & vbCr &
                        "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin, 'N' as 'Alta_Mayor' " & vbCr &
                        "from periodos " & vbCr &
                        "WHERE  (ano+periodo) in (select distinct (ano+periodo) as 'periodo' from nomina.dbo.nomina where reloj = @Reloj) and  (periodo_especial IS NULL OR periodo_especial = 0)" & vbCr &
                        "ORDER BY ano DESC,periodo DESC" & vbCr &
                        "),S1 as (" & vbCr &
                        "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin,'S' as 'Alta_Mayor' " & vbCr &
                        "from periodos " & vbCr &
                        "where (DATEADD(DAY,-7,@Alta) between fecha_ini and fecha_fin) and (periodo_especial is null or periodo_especial = 0)" & vbCr &
                        "order by ano desc, periodo desc" & vbCr &
                        "),S3 as (" & vbCr &
                        "select * from S0 union select * from S1" & vbCr &
                        ") select top 1 unico,año,periodo,fecha_ini,fecha_fin,Alta_Mayor from S3 order by unico desc"


                Case Else

                    strSQL = ""

            End Select

            If Not strSQL.Trim = "" Then

                If Clave.Trim = "EDIT" Then
                    frm.Show()
                    frm.lblAvance.Text = "Última nómina..."
                    Application.DoEvents()

                End If

                dtDatos = sqlExecute(strSQL, "TA")

                If dtDatos.Rows.Count > 0 Then

                    Dim Row_Datos As DataRow = dtDatos.Rows(0)
                    Dim Row_NominaBase As DataRow = dtNominaBase.NewRow

                    If Row_Datos("Alta_Mayor").ToString.Trim.ToUpper = "S" Then
                        EsAltaMayorAPeriodo = True
                    Else
                        EsAltaMayorAPeriodo = False
                    End If

                    Row_NominaBase("unico") = Row_Datos("unico")
                    Row_NominaBase("año") = Row_Datos("año")
                    Row_NominaBase("periodo") = Row_Datos("periodo")
                    Row_NominaBase("fecha_ini") = FechaSQL(CDate(Row_Datos("fecha_ini").ToString))
                    Row_NominaBase("fecha_fin") = FechaSQL(CDate(Row_Datos("fecha_fin").ToString))

                    dtNominaBase.Rows.Add(Row_NominaBase)

                End If

            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar consultar la última nómina procesada del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ActivoTrabajando = False
        frm.Close()

        Return dtNominaBase

    End Function

    Private Sub AsignarFolio()

        Dim folio As String = ""
        Dim dtFolio As DataTable = New DataTable
        Dim LongLimite As Integer = 10

        Try

            dtFolio = sqlExecute("select top 1 (convert(int, folio) + 1) as 'folio' from nomina_calculo order by folio desc", "NOMINA")

            If Not dtFolio.Columns.Contains("ERROR") Then

                If dtFolio.Rows.Count > 0 Then

                    folio = dtFolio.Rows(0).Item("folio").ToString


                    folio = folio.PadLeft(LongLimite, "0")

                Else
                    folio = "1"
                    folio = folio.PadLeft(LongLimite, "0")
                End If

            Else
                folio = ""
                folio = folio.PadLeft(LongLimite, "0")
                MessageBox.Show("No se pudo asignar un folio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        Catch ex As Exception
            folio = ""
            folio = folio.PadLeft(LongLimite, "0")
            MessageBox.Show("Error al intentar asignar un folio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        txtFolio.Text = folio.Trim

    End Sub


    Private Sub MostrarInformacion()

        Dim dtPeriodoAct As New DataTable
        Dim drRegistro As DataRow = Nothing

        Dim strSql1 As String = ""
        Dim tiposueldo As String = ""
        Dim _aplica_ajuste As Integer = 0
        Dim _tipo_ajuste As String = ""
        Dim _cantidad As Double = 0
        Dim CampAntigPer As String = ""
        Dim _TipoPeriodo As String = ""

        Try
            If dtRegistro.Rows.Count > 0 And (Clave = "EDIT" Or Clave = "NVO") Then

                drRegistro = dtRegistro.Rows(0)

                Escomplemento = False

                txtReloj.Text = dtRegistro.Rows(0).Item("reloj")
                txtNombre.Text = dtRegistro.Rows(0).Item("nombres")

                AltaEmp.ValueObject = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("alta")), Nothing, dtRegistro.Rows(0).Item("alta")))

                sFechaAltaEmpleado = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("alta")), "", dtRegistro.Rows(0).Item("alta")))

                If Clave = "NVO" Then
                    CampAntigPer = "alta_vacacion"
                Else
                    CampAntigPer = "alta_antig"
                End If

                AntigEmp.ValueObject = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item(CampAntigPer)), AltaEmp.ValueObject, dtRegistro.Rows(0).Item(CampAntigPer)))

                TipoEmp = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_tipo")), "", dtRegistro.Rows(0).Item("cod_tipo")))

                _TipoPeriodo = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("tipo_periodo")), "", dtRegistro.Rows(0).Item("tipo_periodo")))

                strSql1 = ""

                If Clave = "NVO" Then

                    dtNominaBaseProcesada = NominaBase()

                    lblTipoNomProcesada.Text = "Periodo última nómina semanal procesada"

                    dtPeriodos = dtNominaBaseProcesada

                    If dtPeriodos.Columns.Contains("ERROR") Then

                        MessageBox.Show("Se presentó un error al intentar cargar la última nómina procesada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        cmbPeriodos.SelectedIndex = -1

                    ElseIf Not dtPeriodos.Rows.Count > 0 Then


                        MessageBox.Show("No se localizó la última nómina procesada del empleado '" & txtNombre.Text.Trim & "'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


                    Else

                        cmbPeriodos.DataSource = dtPeriodos
                        cmbPeriodos.ValueMember = "unico"
                        cmbPeriodos.DisplayMembers = "unico,año,periodo,fecha_ini,fecha_fin"

                    End If

                    Try
                        cmbPeriodos.SelectedIndex = IIf(dtPeriodos.Rows.Count > 0, 0, -1)
                    Catch ex As Exception
                        sUltimaNominaProcesada = ""
                    End Try

                ElseIf Clave = "EDIT" Then

                    If TipoEmp.ToUpper.Equals("O") Or TipoEmp.ToUpper.Equals("A") Then

                        strSql1 = "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin" &
                            " from periodos" &
                            " where (ano+periodo) = '" & drRegistro("ano") & drRegistro("periodo") & "'"

                        lblTipoNomProcesada.Text = "Periodo última nómina semanal procesada"

                        'ElseIf TipoEmp.ToUpper.Equals("A") Then

                        '    strSql1 = "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin" & _
                        '        " from periodos_quincenal" & _
                        '        " where (ano+periodo) = '" & drRegistro("ano") & drRegistro("periodo") & "'"

                        '    lblTipoNomProcesada.Text = "Periodo última nómina quincenal procesada"

                    End If

                    dtPeriodos = sqlExecute(strSql1, "TA")

                    If dtPeriodos.Columns.Contains("ERROR") Then

                        MessageBox.Show("Se presentó un error al intentar cargar la última nómina procesada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        cmbPeriodos.SelectedIndex = -1

                    ElseIf Not dtPeriodos.Rows.Count > 0 Then

                        MessageBox.Show("No se localizó la última nómina procesada del empleado '" & txtNombre.Text.Trim & "'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        cmbPeriodos.SelectedIndex = -1

                    Else

                        cmbPeriodos.DataSource = dtPeriodos
                        cmbPeriodos.ValueMember = "unico"
                        cmbPeriodos.DisplayMembers = "unico,año,periodo,fecha_ini,fecha_fin"

                        cmbPeriodos.SelectedIndex = 0
                    End If

                Else

                    dtPeriodos.Clear()

                End If


                dtConceptos = sqlExecute("select ltrim(rtrim(conceptos.concepto)) as concepto,upper(ltrim(rtrim(conceptos.nombre))) as nombre," & vbCr &
                                     "convert(char(100), ltrim(rtrim( naturalezas.nombre))) as naturaleza " & vbCr &
                                     "from conceptos left join naturalezas on conceptos.COD_NATURALEZA = naturalezas.COD_NATURALEZA" & vbCr &
                                     "where activo = 1 and finiquito = 1 and rtrim(ltrim(isnull(naturalezas.nombre,''))) <> ''", "NOMINA")

                cmbConceptos.DataSource = dtConceptos
                cmbConceptos.ValueMember = "CONCEPTO"
                cmbConceptos.DisplayMembers = "CONCEPTO,NOMBRE"
                cmbConceptos.SelectedIndex = -1


                dtCompania = sqlExecute("select cias.*,personalvw.reloj,personalvw.nombres,personalvw.sactual,personalvw.integrado,personalvw.cod_hora from personalvw left join cias on personalvw.cod_comp = cias.cod_comp where reloj = '" & txtReloj.Text.Trim & "'")

                If Clave = "NVO" Then
                    swdespensa.Value = True
                    swantiguedad.Value = True
                    Exit Sub
                End If



                txtFolio.Text = dtRegistro.Rows(0).Item("folio")

                BajaFiniquito.ValueObject = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("baja_fin")), Nothing, dtRegistro.Rows(0).Item("baja_fin")))

                strPeriodo = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("ano")), "", dtRegistro.Rows(0).Item("ano")))
                strPeriodo &= Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("periodo")), "", dtRegistro.Rows(0).Item("periodo")))

                cmbPeriodos.SelectedValue = strPeriodo

                swdespensa.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("vales_despensa")), 0, dtRegistro.Rows(0).Item("vales_despensa"))

                swantiguedad.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("prima_antig")), 0, dtRegistro.Rows(0).Item("prima_antig"))

                tiposueldo = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("tipo_sdo_antig")), "", dtRegistro.Rows(0).Item("tipo_sdo_antig")))

                If tiposueldo = "" Or tiposueldo = "Diario" Then
                    cmbsueldoprima.SelectedIndex = 0
                ElseIf tiposueldo = "Integrado" Then
                    cmbsueldoprima.SelectedIndex = 1
                Else
                    cmbsueldoprima.SelectedIndex = 0
                End If

                swgratificacion.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("gratificacion")), 0, dtRegistro.Rows(0).Item("gratificacion"))

                tiposueldo = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("tipo_sdo_grati")), "", dtRegistro.Rows(0).Item("tipo_sdo_grati")))

                If tiposueldo = "" Or tiposueldo = "Diario" Then
                    cmbsueldograf.SelectedIndex = 0
                ElseIf tiposueldo = "Integrado" Then
                    cmbsueldograf.SelectedIndex = 1
                Else
                    cmbsueldograf.SelectedIndex = 0
                End If

                txtNumGratificacion.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("dias_grati")), 0, dtRegistro.Rows(0).Item("dias_grati"))

                swdiasano.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("20diasano")), 0, dtRegistro.Rows(0).Item("20diasano"))
                tiposueldo = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("tipo_sdo_rest")), "", dtRegistro.Rows(0).Item("tipo_sdo_rest")))

                If tiposueldo = "" Or tiposueldo = "Integrado" Then
                    cmbsueldodias.SelectedIndex = 1
                ElseIf tiposueldo = "Diario" Then
                    cmbsueldodias.SelectedIndex = 0
                Else
                    cmbsueldodias.SelectedIndex = 1
                End If

                _aplica_ajuste = IIf(IsDBNull(dtRegistro.Rows(0).Item("aplica_ajuste")), 0, dtRegistro.Rows(0).Item("aplica_ajuste"))
                _tipo_ajuste = IIf(IsDBNull(dtRegistro.Rows(0).Item("tipo_ajuste")), "", dtRegistro.Rows(0).Item("tipo_ajuste"))
                _cantidad = IIf(IsDBNull(dtRegistro.Rows(0).Item("cantidad")), 0, dtRegistro.Rows(0).Item("cantidad"))

                If _tipo_ajuste.Trim.ToUpper = "N" Then

                    swnetofijo.Value = _aplica_ajuste
                    txtNetoFijo.Text = FormatNumber(_cantidad, 2)

                ElseIf _tipo_ajuste.Trim.ToUpper = "P" Then

                    swpercefija.Value = _aplica_ajuste
                    txtPerFija.Text = FormatNumber(_cantidad, 2)

                End If

                Escomplemento = IIf(IsDBNull(dtRegistro.Rows(0).Item("complemento")), 0, dtRegistro.Rows(0).Item("complemento"))


                dtConcGrid = sqlExecute("select ltrim(rtrim(concepto)) as concepto,ltrim(rtrim(descripcion)) as descripcion,monto,factor from ajustes_tmp where folio = '" & dtRegistro.Rows(0).Item("folio") & "' and reloj = '" & dtRegistro.Rows(0).Item("reloj") & "' and (ano+periodo) = '" & strPeriodo & "'", "NOMINA")

                dtConcGrid.DefaultView.Sort = "concepto"

                dgvConceptos.DataSource = dtConcGrid


            Else

            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar mostrar parte de la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub InfoBlanco()
        Try
            pnlEmp.Enabled = False
            Panel2.Enabled = False
            btnCalcular.Enabled = False
            btnCancelar.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PeriodoActual(cod_tipo As String)

        Dim strSQL As String = ""
        Try

            dtPeriodos.Clear()

            If Not cod_tipo = "" Then

                Select Case cod_tipo.ToUpper

                    Case "O"

                        strSQL = "select top 1 (ano+periodo) as 'unico',ano,periodo,fecha_ini,fecha_fin" & vbCr &
                           " from ta.dbo.periodos" & vbCr &
                           " where (fecha_fin < convert(date, getdate())) and  (periodo_especial is null or periodo_especial = 0)" & vbCr &
                           " order by ano desc, periodo desc"

                        dtPeriodos = sqlExecute(strSQL, "TA")

                    Case "A"
                        strSQL = "select top 1 (ano+periodo) as 'unico',ano,periodo,fecha_ini,fecha_fin" & vbCr &
                           " from ta.dbo.periodos" & vbCr &
                           " where (fecha_fin < convert(date, getdate())) and  (periodo_especial is null or periodo_especial = 0)" & vbCr &
                           " order by ano desc, periodo desc"

                        dtPeriodos = sqlExecute(strSQL, "TA")
                End Select

                If dtPeriodos.Rows.Count > 0 And Not dtPeriodos.Columns.Contains("ERROR") Then
                    cmbPeriodos.DataSource = dtPeriodos

                    cmbPeriodos.ValueMember = "unico"
                    cmbPeriodos.DisplayMembers = "unico,ano,periodo,fecha_ini,fecha_fin"

                    cmbPeriodos.SelectedIndex = 0
                Else

                    MessageBox.Show("No se localizó el periodo actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If


            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Complemento()
        Try
            Dim strsql As String = ""

            strsql = "exec Complemento " & txtFolio.Text.Trim & ",'" & txtReloj.Text.Trim & "'"

            If sqlExecute(strsql, "NOMINA").Columns.Contains("ERROR") Then
                MessageBox.Show("Error al intentar crear el complemento del folio '" & folioAnt & "' .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar crear el complemento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        swComplemento.Enabled = False

    End Sub

    Private Sub InsertarNominaFiniquitos(ByVal Folio As String, ByVal rl As String)

        Dim strSql As String = "insert into nomina_finiquito(folio,pagina,cod_tipo_nomina,cod_pago,periodo,ano,reloj,nombres,mes,horas_normales," &
            " horas_dobles,horas_triples,horas_festivas,horas_descanso,horas_domingo,horas_compensa,dias_vac,dias_agui," &
            " sactual,integrado,cod_depto,cod_turno,cod_puesto,cod_super,cod_hora,cod_tipo,cod_clase,alta,baja,deposito,periodo_act," &
            " cuenta,cod_planta,cod_comp,info_vsm,info_porc,info_cred,fah_porc,banco,info_cuota,cla_ban,tipo_periodo)" &
            " select convert(int,folio) as folio, 0 as pagina, 'F' as cod_tipo_nomina, '' as cod_pago, (case when isnull(comp_folio,'') = '' then '80' else '81' end) as periodo, ano," &
            " nomina_calculo.reloj,nomina_calculo.nombres,'' as mes ,0 as horas_normales, 0 as horas_dobles ,0 as horas_triples, 0 as horas_festivas, 0 as horas_descanso, 0 as horas_domingo," &
            " 0 as horas_compensa, 0 as dias_vac, 0 as dias_agui, nomina_calculo.sactual,nomina_calculo.integrado,isnull(nomina_calculo.cod_depto,'') as cod_depto,isnull(nomina_calculo.cod_turno,'') as cod_turno," &
            " isnull(nomina_calculo.cod_puesto,'') as cod_puesto,isnull(nomina_calculo.cod_super,'') as cod_super,isnull(nomina_calculo.cod_hora,'') as cod_hora,isnull(nomina_calculo.cod_tipo,'') as cod_tipo," &
            " nomina_calculo.cod_clase,nomina_calculo.alta,baja_fin as baja, 0 as deposito, '" & PeriodoAct.Trim & "' as periodo_act, " &
            " 0 as cuenta,nomina_calculo. cod_planta, nomina_calculo.cod_comp, 0 as info_vsm, 0 as info_porc," &
            " isnull(infonavit_credito,'') as info_cred, fah_porc, '' as banco, isnull(cuota_credito,0) as info_cuota, '' as cla_ban, isnull(tipo_periodo,'') as tipo_periodo" &
            " from nomina_calculo" &
            " where folio = '" & txtFolio.Text.Trim & "' and reloj = '" & txtReloj.Text.Trim & "'"

        If sqlExecute(strSql, "NOMINA").Columns.Contains("ERROR") Then
            MessageBox.Show("No se pudo cargar los datos en nomina finiquitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub

    'Para poliza
    Private Sub InsertarNomina(ByVal Folio As String, ByVal rl As String)

        If Not sqlExecute("delete from nomina where periodo in ('80','81')", "NOMINA").Columns.Contains("ERROR") Then

            Dim strSql As String = "insert into nomina(folio,pagina,cod_tipo_nomina,cod_pago,periodo,ano,reloj,nombres,mes,horas_normales," &
            " horas_dobles,horas_triples,horas_festivas,horas_descanso,horas_domingo,horas_compensa,dias_vac,dias_agui," &
            " sactual,integrado,cod_depto,cod_turno,cod_puesto,cod_super,cod_hora,cod_tipo,cod_clase,alta,baja,deposito,periodo_act," &
            " cuenta,cod_planta,cod_comp,info_vsm,info_porc,info_cred,fah_porc,banco,info_cuota,cla_ban,tipo_periodo)" &
            " select convert(int,folio) as folio, 0 as pagina, 'F' as cod_tipo_nomina, '' as cod_pago, (case when isnull(comp_folio,'') = '' then '80' else '81' end) as periodo, ano," &
            " nomina_calculo.reloj,nomina_calculo.nombres,'' as mes ,0 as horas_normales, 0 as horas_dobles ,0 as horas_triples, 0 as horas_festivas, 0 as horas_descanso, 0 as horas_domingo," &
            " 0 as horas_compensa, 0 as dias_vac, 0 as dias_agui, nomina_calculo.sactual,nomina_calculo.integrado,isnull(nomina_calculo.cod_depto,'') as cod_depto,isnull(nomina_calculo.cod_turno,'') as cod_turno," &
            " isnull(nomina_calculo.cod_puesto,'') as cod_puesto,isnull(nomina_calculo.cod_super,'') as cod_super,isnull(nomina_calculo.cod_hora,'') as cod_hora,isnull(nomina_calculo.cod_tipo,'') as cod_tipo," &
            " nomina_calculo.cod_clase,nomina_calculo.alta,baja_fin as baja, 0 as deposito, '" & PeriodoAct.Trim & "' as periodo_act, " &
            " 0 as cuenta,nomina_calculo. cod_planta, nomina_calculo.cod_comp, 0 as info_vsm, 0 as info_porc," &
            " isnull(infonavit_credito,'') as info_cred, fah_porc, '' as banco, isnull(cuota_credito,0) as info_cuota, '' as cla_ban, isnull(tipo_periodo,'') as tipo_periodo" &
            " from nomina_calculo" &
            " where folio = '" & txtFolio.Text.Trim & "' and reloj = '" & txtReloj.Text.Trim & "'"

            If sqlExecute(strSql, "NOMINA").Columns.Contains("ERROR") Then
                MessageBox.Show("No se pudo cargar los datos en nomina.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else
            MessageBox.Show("No se pudo cargar los datos en nomina.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub

    Private Sub InsertarMovimientosFiniquitos(Row As DataRow)
        Dim strSql As String = ""

        Try

            strSql = "insert into movimientos_finiquito(ano,periodo,tipo_nomina,reloj,concepto,monto,prioridad,tipo_periodo)" &
           " select movtmp.ano, ( case when isnull(nomtmp.comp_folio,'') = '' then '80' else '81' end ) as Periodo,'F' as tipo_nomina," &
           " nomtmp.Reloj,movtmp.Concepto,movtmp.Monto,movtmp.Prioridad,isnull(nomtmp.tipo_periodo,'') as tipo_periodo" &
           " from movimientos_calculo movtmp left join nomina_calculo nomtmp on movtmp.Folio = nomtmp.folio" &
           " where movtmp.folio = '" & Row("folio") & "'"

            If sqlExecute(strSql, "NOMINA").Columns.Contains("ERROR") Then
                MessageBox.Show("No se pudo cargar los datos en movimientos finiquitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            strSql = "declare @ano char(4)" &
                " declare @periodo char(2)" &
                " declare @tipo_periodo char(1)" &
                " set @ano = '" & Trim(Row("ano")) & "'" &
                " set @periodo = '" & Trim(IIf(IsDBNull(Row("comp_folio")), "80", "81")) & "'" &
                " set @tipo_periodo = '" & Trim(IIf(IsDBNull(Row("tipo_periodo")), "S", Row("tipo_periodo"))) & "'" &
                " delete from nomina_finiquito where ANO+PERIODO+tipo_periodo = @ano+@PERIODO+@tipo_periodo" &
                " " &
                " insert into nomina_finiquito" &
                " select '' as FOLIO,'' as PAGINA,'F' as COD_TIPO_nomina_finiquito,case when len(rtrim(isnull(clabe, '')))>len(rtrim(isnull(CUENTA_BANCO, ''))) then 'D' else case when len(rtrim(isnull(CUENTA_BANCO, '')))=0 then 'E' else'B' end end as COD_PAGO,@periodo as  PERIODO, @ano as ANO,RELOJ,NOMBRES,'' as MES, 0 as HORAS_NORMALES, 0 as HORAS_DOBLES," &
                " 0 as HORAS_TRIPLES, 0 as HORAS_FESTIVAS, 0 as HORAS_DESCANSO," &
                " 0 as HORAS_DOMINGO, 0 as HORAS_COMPENSA," &
                " 0 as DIAS_VAC, 0 as DIAS_AGUI, SACTUAL, INTEGRADO, COD_DEPTO, COD_TURNO, COD_PUESTO, COD_SUPER," &
                " COD_HORA, COD_TIPO, COD_CLASE, ALTA, BAJA,1 as DEPOSITO,'' as PERIODO_ACT,case when len(rtrim(isnull(clabe, '')))>len(rtrim(isnull(cuenta_banco, ''))) then clabe else CUENTA_BANCO end,COD_PLANTA,COD_COMP," &
                " null as FOLIO_CFDI, null as FECHA_CFDI,null as CERTIFICADO_CFDI,null as UBICACION_ARCHIVO_CFDI,null as REFERENCIA_DAP," &
                " 0 as info_vsm,0 as info_porc,'' as info_cred,0 as fah_porc," &
                " '01' as banco, '' as info_cuota, '' as cla_ban, 0 as impresa, '' as comentario,'' as firma, @tipo_periodo as tipo_periodo,0 as confirma,null as fecha_exportacion, null as usuario_exportacion" &
                " from personal.dbo.personalvw where reloj in (" &
                " select reloj from movimientos_finiquito where ano+periodo+tipo_periodo = @ano+@PERIODO+@tipo_periodo)" &
                " update nomina_finiquito set banco = null where ANO+PERIODO+tipo_periodo = @ano+@PERIODO+@tipo_periodo and cod_pago = 'D'" &
                " update nomina_finiquito set cuenta = '' where cod_pago = 'E' and ANO+PERIODO+tipo_periodo = @ano+@PERIODO+@tipo_periodo"

            If sqlExecute(strSql, "NOMINA").Columns.Contains("ERROR") Then
                MessageBox.Show("No se pudo cargar los datos en nomina finiquito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show("No se pudo cargar los datos en nomina_finiquito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        ' sqlExecute(strSql, "NOMINA")

    End Sub

    'Para poliza
    Private Sub InsertarMovimientos(ByVal Folio As String)

        If Not sqlExecute("delete from movimientos where periodo in('80','81') ", "NOMINA").Columns.Contains("ERROR") Then

            Dim strSql As String = "insert into movimientos(ano,periodo,tipo_nomina,reloj,concepto,monto,prioridad,tipo_periodo)" &
            " select movtmp.ano, ( case when isnull(nomtmp.comp_folio,'') = '' then '80' else '81' end ) as Periodo,'F' as tipo_nomina," &
            " nomtmp.Reloj,movtmp.Concepto,movtmp.Monto,movtmp.Prioridad,isnull(nomtmp.tipo_periodo,'') as tipo_periodo" &
            " from movimientos_calculo movtmp left join nomina_calculo nomtmp on movtmp.Folio = nomtmp.folio" &
            " where movtmp.folio = '" & txtFolio.Text.Trim & "'"

            If sqlExecute(strSql, "NOMINA").Columns.Contains("ERROR") Then
                MessageBox.Show("No se pudo cargar los datos en movimientos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else
            MessageBox.Show("No se pudo cargar los datos en movimientos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub

    '*** Calculo actual 2019-09-04 ***
    Private Sub DiasNormales1(Optional ByVal Filtro As String = "")

        Dim dtDiasNormales As New DataTable
        Dim dtDiasHabiles As New DataTable
        Dim dtPeriodoFiniquito As New DataTable

        Dim drDiasHabiles As DataRow = Nothing

        Dim strSql As String = ""
        Dim sPeriodoFiniquito As String = ""

        Dim iDias As Integer = 0
        Dim iDiaSemana As Integer = 0


        Try

            dtDiasNormales = sqlExecute("select top 1 * from conceptos where concepto = 'DIANOR'", "NOMINA")

            If Not (dtDiasNormales.Rows.Count > 0 Or dtRegistro.Rows.Count > 0) Then Exit Sub

            If sUltimaNominaProcesada.Trim = "" Then

                MessageBox.Show("No se pudo determinar los dias normales a pagar al empleado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub

            End If


            'Los dias se calculan apartir de su ultima nomina hasta la fecha del finiquito
            Dim dateFechaini As Date = IIf(EsAltaMayorAPeriodo, CDate(sFechaAltaEmpleado), CDate(Trim(Split(cmbPeriodos.Text, ",")(4))).AddDays(1))
            Dim dateFechaFin As Date = CDate(sFechaFiniquito)

            Application.DoEvents()
            If Trim(TipoEmp.Trim.ToUpper) = "O" Or Trim(TipoEmp.Trim.ToUpper) = "A" Then



                If dateFechaini <= dateFechaFin Then

                    iDias = DateDiff(DateInterval.DayOfYear, dateFechaini, dateFechaFin) + 1

                    Select Case iDias

                        Case Is > 7

                            Dim Residuo As Integer = ((iDias - 1) Mod 7) + 1
                            Dim Sumar As Integer = 7 - Residuo

                            iDias = IIf(dateFechaFin.DayOfWeek >= DayOfWeek.Friday, iDias + Sumar, iDias)

                        Case 1 To 7

                            If dateFechaFin.DayOfWeek >= DayOfWeek.Friday Then

                                iDias = iDias + 2

                            End If

                        Case Else

                            iDias = 0

                    End Select

                Else


                    If dateFechaFin.DayOfWeek >= DayOfWeek.Friday Then
                        iDias = 0
                    Else
                        iDias = DateDiff(DateInterval.DayOfYear, dateFechaini, dateFechaFin) + 1
                    End If



                End If
            Else
                MessageBox.Show("No se localizó el tipo de empleado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            'Carga en el dtConcGrid del cual esta enlazado el dgvConceptos
            If iDias <> 0 Then

                Dim drFila As DataRow = dtConcGrid.NewRow

                drFila("concepto") = dtDiasNormales.Rows(0).Item("concepto").ToString.Trim
                drFila("descripcion") = Trim(IIf(IsDBNull(dtDiasNormales.Rows(0).Item("nombre")), "", dtDiasNormales.Rows(0).Item("nombre")))
                drFila("monto") = iDias

                dtConcGrid.Rows.Add(drFila)

            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar calcular los dias normales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "DiasNormales", ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    '*** Calculo actual 2019-09-04 ***
    Private Sub HorasExtras1(Optional ByVal Filtro As String = "")

        Dim dtHrsExtra As DataTable = New DataTable
        Dim dtConExtra As New DataTable
        Dim dtAsist As New DataTable
        Dim _HrsExtra As String = ""
        Dim strSQL As String = ""
        Dim horas As Double = 0
        Dim minutos As Double = 0
        Dim ExtraTotal As Double = 0
        Dim hrs_dobles As Double = 0
        Dim hrs_triples As Double = 0
        Dim hrs_extra As Double = 0
        Dim Extradiarias As Double = 0
        Dim Fecha As String = ""
        Dim hrs_fel As Double = 0

        Try

            If Filtro.Trim = "" Then
                dtConExtra = sqlExecute("select * from conceptos where concepto in ('HRSEX2','HRSEX3','HRSFEL')", "NOMINA")
            Else
                dtConExtra = sqlExecute("select top 1 * from conceptos where concepto = '" & Filtro.Trim & "' ", "NOMINA")
            End If

            If Not (dtRegistro.Rows.Count > 0 And dtConExtra.Rows.Count > 0 And TipoEmp.Trim.ToUpper = "O") Then Exit Sub


            Dim dateFechaIni As String = FechaSQL(CDate(Split(cmbPeriodos.Text.Trim, ",")(4)).AddDays(1))
            Dim dateFechaFin As String = FechaSQL(BajaFiniquito.Value)

            If Not dateFechaIni < dateFechaFin Then Exit Sub

            strSQL = "declare @fechaIni char(10)" & vbCr &
                "declare @fechaFin char(10) " & vbCr &
                "declare @reloj char(6)" & vbCr &
                "set @fechaIni = '" & dateFechaIni & "'" & vbCr &
                "set @fechaFin = '" & dateFechaFin & "'" & vbCr &
                "set @reloj = '" & txtReloj.Text.Trim & "'" & vbCr &
                "select horas_extras,fha_ent_hor " & vbCr &
                "from asist" & vbCr &
                "where reloj = @reloj and fha_ent_hor between @fechaIni and @fechaFin and (horas_extras <> '00:00' and horas_extras is not null)  order by periodo asc, fha_ent_hor asc"


            dtAsist = sqlExecute(strSQL, "TA")

            For Each drAsist In dtAsist.Rows

                _HrsExtra = Trim(IIf(IsDBNull(drAsist("horas_extras")), "00:00", drAsist("horas_extras")))
                horas = Math.Truncate(HtoD(_HrsExtra))
                minutos = HtoD(_HrsExtra) - horas

                Fecha = FechaSQL(IIf(IsDBNull(drAsist("fha_ent_hor")), "0001-01-01", drAsist("fha_ent_hor")))

                If minutos >= 0 And minutos < 0.5 Then

                    Extradiarias = horas
                Else
                    Extradiarias = (horas + 0.5)
                End If

                Dim dtFestivoGeneral As DataTable = sqlExecute("select * from ausentismo where reloj = '" & txtReloj.Text.Trim & "' and fecha = '" & FechaSQL(Fecha) & "' and tipo_aus = 'FES'", "TA")

                If dtFestivoGeneral.Rows.Count > 0 Then

                    If Extradiarias > 0 Then

                        Dim cod_dia As Integer = DiaSemInt(Fecha)
                        'Dim dtPeriodoUnico As DataTable = sqlExecute("select top 1 (ano+periodo) as periodo from " & IIf(TipoEmp.Trim.ToUpper = "A", "periodos_quincenal", "periodos") & " where  '" & FechaSQL(BajaFiniquito.ValueObject) & "' >= FECHA_INI and '" & FechaSQL(BajaFiniquito.ValueObject) & "' <= FECHA_FIN and (periodo_especial is null or periodo_especial = 0)", "TA")
                        Dim dtPeriodoUnico As DataTable = sqlExecute("select top 1 (ano+periodo) as periodo from " & IIf(TipoEmp.Trim.ToUpper = "A", "periodos", "periodos") & " where  '" & FechaSQL(BajaFiniquito.ValueObject) & "' >= FECHA_INI and '" & FechaSQL(BajaFiniquito.ValueObject) & "' <= FECHA_FIN and (periodo_especial is null or periodo_especial = 0)", "TA")
                        Dim se As DetalleSemana = SemanaHorarioMixto(Trim(dtPeriodoUnico.Rows(0).Item("periodo")), txtReloj.Text.Trim)

                        Dim strSql2 As String = "select  horarios.cod_hora,rol_horarios.ano,rol_horarios.periodo,rol_horarios.SEMANA, max(ta.dbo.htod(hrs_dia) ) as hrs_dia" &
                            " from horarios " &
                            " left join rol_horarios on rol_horarios.cod_hora = horarios.cod_hora" &
                            " left join dias on dias.cod_hora = horarios.cod_hora and dias.semana = rol_horarios.semana" &
                            " where  (rol_horarios.ano+rol_horarios.periodo) = '" & dtPeriodoUnico.Rows(0).Item("periodo") & "' and horarios.cod_comp = '" & dtRegistro.Rows(0).Item("cod_comp") & "' and horarios.cod_hora = '" & se.cod_hora & "' and rol_horarios.SEMANA = '" & se.NumSemana & "' and dias.cod_dia = '" & cod_dia & "'" &
                            " group by horarios.cod_hora,rol_horarios.ano, rol_horarios.periodo,rol_horarios.SEMANA"


                        Dim dtDiasHorario As DataTable = sqlExecute(strSql2)

                        Dim hrs_dia As Double = 0
                        If dtDiasHorario.Rows.Count > 0 Then
                            Try
                                hrs_dia = dtDiasHorario.Rows(0)("hrs_dia")
                            Catch ex As Exception

                            End Try
                        End If
                        hrs_fel += IIf(Extradiarias > hrs_dia, hrs_dia, Extradiarias)
                        Extradiarias = IIf(Extradiarias > hrs_dia, Extradiarias - hrs_dia, 0)
                    End If


                End If

                hrs_extra += Extradiarias

            Next

            If hrs_extra > 9 Then
                hrs_dobles = 9
                hrs_triples = hrs_extra - 9
            Else
                hrs_dobles = hrs_extra
            End If

            If (hrs_extra = 0 Or hrs_fel = 0) And Not Filtro.Trim = "" Then

                Dim drFila As DataRow = dtConcGrid.NewRow

                Select Case dtConExtra.Rows(0).Item("concepto").ToString.Trim


                    Case "HRSEX2"

                        drFila("concepto") = dtConExtra.Rows(0).Item("concepto").ToString.Trim
                        drFila("descripcion") = Trim(IIf(IsDBNull(dtConExtra.Rows(0).Item("nombre")), "", dtConExtra.Rows(0).Item("nombre")))
                        drFila("monto") = 0

                    Case "HRSEX3"

                        drFila("concepto") = dtConExtra.Rows(0).Item("concepto").ToString.Trim
                        drFila("descripcion") = Trim(IIf(IsDBNull(dtConExtra.Rows(0).Item("nombre")), "", dtConExtra.Rows(0).Item("nombre")))
                        drFila("monto") = 0

                    Case "HRSFEL"

                        drFila("concepto") = dtConExtra.Rows(0).Item("concepto").ToString.Trim
                        drFila("descripcion") = Trim(IIf(IsDBNull(dtConExtra.Rows(0).Item("nombre")), "", dtConExtra.Rows(0).Item("nombre")))
                        drFila("monto") = 0

                End Select

                dtConcGrid.Rows.Add(drFila)

            ElseIf hrs_extra <> 0 Or hrs_fel <> 0 Then

                For Each drRow As DataRow In dtConExtra.Rows

                    If drRow("concepto").ToString.Trim = "HRSEX2" And hrs_dobles <> 0 Then

                        Dim drFila As DataRow = dtConcGrid.NewRow

                        drFila("concepto") = drRow("concepto").ToString.Trim
                        drFila("descripcion") = Trim(IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")))
                        drFila("monto") = hrs_dobles

                        dtConcGrid.Rows.Add(drFila)

                    ElseIf drRow("concepto").ToString.Trim = "HRSEX3" And hrs_triples <> 0 Then

                        Dim drFila As DataRow = dtConcGrid.NewRow

                        drFila("concepto") = drRow("concepto").ToString.Trim
                        drFila("descripcion") = Trim(IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")))
                        drFila("monto") = hrs_triples

                        dtConcGrid.Rows.Add(drFila)

                    ElseIf drRow("concepto").ToString.Trim = "HRSFEL" And hrs_fel <> 0 Then

                        Dim drFila As DataRow = dtConcGrid.NewRow

                        drFila("concepto") = drRow("concepto").ToString.Trim
                        drFila("descripcion") = Trim(IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")))
                        drFila("monto") = hrs_fel

                        dtConcGrid.Rows.Add(drFila)

                    End If


                Next

            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar cargar las horas extras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


    'DIAPRI
    Private Sub Prima_Vacacional1(Optional ByVal Filtro As String = "")

        Dim dtPrimaVac As New DataTable
        Dim dtDIAPRI As New DataTable

        Dim valor As Double = 0
        Dim aniversario_antig As Date = Nothing
        Dim aniversario As Date = Nothing
        Dim alta_antig As Date = Nothing
        Dim alta As Date = Nothing
        Dim Anios As Integer = 0
        Dim _cod_comp As String = ""
        Dim _tipo_emp As String = ""
        Dim dias As Double = 0
        Dim por_prima As Double = 0

        Try

            dtDIAPRI = sqlExecute("select top 1 * from conceptos where concepto = 'DIAPRI'", "NOMINA")

            If Not (dtRegistro.Rows.Count > 0 Or dtDIAPRI.Rows.Count > 0) Then Exit Sub


            alta = AltaEmp.ValueObject
            alta_antig = AntigEmp.ValueObject
            _cod_comp = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_comp")), "", dtRegistro.Rows(0).Item("cod_comp"))
            _tipo_emp = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_tipo")), "", dtRegistro.Rows(0).Item("cod_tipo"))

            If alta_antig = Nothing Then

                alta_antig = alta

            End If

            If Month(alta_antig) = 2 And alta_antig.Day = 29 Then
                alta_antig = alta_antig.AddDays(-1)
            End If

            If Month(alta) = 2 And alta.Day = 29 Then
                alta = alta.AddDays(-1)
            End If

            aniversario_antig = DateSerial(Year(BajaFiniquito.Value), alta_antig.Month, alta_antig.Day)
            aniversario = DateSerial(Year(BajaFiniquito.Value), alta.Month, alta.Day)

            If FechaSQL(aniversario_antig) > FechaSQL(BajaFiniquito.Value) Then
                aniversario_antig = aniversario_antig.AddMonths(-12)
            End If

            If FechaSQL(aniversario) > FechaSQL(BajaFiniquito.Value) Then
                aniversario = aniversario.AddMonths(-12)
            End If

            Anios = aniversario_antig.Year - alta_antig.Year + 1


            dtPrimaVac = sqlExecute("select top 1 * from vac_especiales where reloj = '" & txtReloj.Text.Trim & "' and cod_tipo = '" & _tipo_emp & "' and anos = '" & Anios & "'")

            If dtPrimaVac.Rows.Count > 0 Then

                dias = IIf(IsDBNull(dtPrimaVac.Rows(0).Item("dias")), 0.0, dtPrimaVac.Rows(0).Item("dias"))
                por_prima = IIf(IsDBNull(dtPrimaVac.Rows(0).Item("por_prima")), 0.0, dtPrimaVac.Rows(0).Item("por_prima"))

                If ((DateDiff(DateInterval.DayOfYear, alta_antig, BajaFiniquito.Value) + 1) / 365.25) <= 1 Then

                    valor = (dias / 365.25) * ((DateDiff(DateInterval.DayOfYear, alta, BajaFiniquito.Value)) + 1)

                    valor = valor * por_prima / 100

                Else
                    valor = (dias / 365.25) * ((DateDiff(DateInterval.DayOfYear, aniversario_antig, BajaFiniquito.Value)) + 1)

                    valor = valor * por_prima / 100
                End If


            Else

                dtPrimaVac = New DataTable
                dtPrimaVac = sqlExecute("select * from vacaciones where cod_comp = '" & _cod_comp & "' and  cod_tipo = '" & _tipo_emp & "' and anos = '" & Anios & "'")

                If dtPrimaVac.Rows.Count > 0 Then

                    dias = IIf(IsDBNull(dtPrimaVac.Rows(0).Item("dias")), 0.0, dtPrimaVac.Rows(0).Item("dias"))
                    por_prima = IIf(IsDBNull(dtPrimaVac.Rows(0).Item("por_prima")), 0.0, dtPrimaVac.Rows(0).Item("por_prima"))

                    If ((DateDiff(DateInterval.DayOfYear, alta_antig, BajaFiniquito.Value) + 1) / 365.25) <= 1 Then

                        valor = (dias / 365.25) * ((DateDiff(DateInterval.DayOfYear, alta, BajaFiniquito.Value)) + 1)

                        valor = valor * por_prima / 100

                    Else
                        valor = (dias / 365.25) * ((DateDiff(DateInterval.DayOfYear, aniversario_antig, BajaFiniquito.Value)) + 1)

                        valor = valor * por_prima / 100
                    End If
                End If

            End If

            If valor = 0 And Not Filtro.Trim = "" Then


                Dim drFila As DataRow = dtConcGrid.NewRow

                drFila("concepto") = dtDIAPRI.Rows(0).Item("concepto").ToString.Trim
                drFila("descripcion") = Trim(IIf(IsDBNull(dtDIAPRI.Rows(0).Item("nombre")), "", dtDIAPRI.Rows(0).Item("nombre")))
                drFila("monto") = 0

                dtConcGrid.Rows.Add(drFila)


            ElseIf valor <> 0 Then


                Dim drFila As DataRow = dtConcGrid.NewRow

                drFila("concepto") = dtDIAPRI.Rows(0).Item("concepto").ToString.Trim
                drFila("descripcion") = Trim(IIf(IsDBNull(dtDIAPRI.Rows(0).Item("nombre")), "", dtDIAPRI.Rows(0).Item("nombre")))
                drFila("monto") = Math.Round(valor, 2)

                dtConcGrid.Rows.Add(drFila)

            End If


        Catch ex As Exception
            MessageBox.Show("Error al intentar obtener la prima vacacional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    'DIASAG
    Private Sub Proporcion_Aguinaldo1(Optional ByVal Filtro As String = "")
        Dim dtAguinaldo As DataTable = New DataTable
        Dim dtDIASAG As New DataTable

        Dim primero As Date = Nothing
        Dim ultimo As Date = Nothing
        Dim alta As Date = Nothing
        Dim alta_ant As Date = Nothing

        Dim dias_anuales As Double = 0
        Dim anios As Double = 0
        Dim ant_completa As Double = 0
        Dim dias As Double = 0
        Dim corresponden As Double = 0

        Dim _cod_comp As String = ""
        Dim _tipo_emp As String = ""

        Try

            dtDIASAG = sqlExecute("select top 1 * from conceptos where concepto = 'DIASAG'", "NOMINA")

            If Not (dtRegistro.Rows.Count > 0 Or dtDIASAG.Rows.Count > 0) Then Exit Sub

            primero = DateSerial(Year(Now), 1, 1)
            dias_anuales = DateDiff(DateInterval.DayOfYear, DateSerial(Year(Now), 1, 1), DateSerial(Year(Now), 12, 31)) + 1


            alta = AltaEmp.ValueObject
            alta_ant = AntigEmp.ValueObject

            If FechaSQL(alta_ant) = "0001-01-01" Then
                alta_ant = alta
            End If

            ultimo = BajaFiniquito.Value

            If FechaSQL(alta) > FechaSQL(primero) Then

                primero = alta

            End If

            anios = IIf(Antiguedad(alta_ant, ultimo) < 1, 1, Antiguedad(alta_ant, ultimo))
            ant_completa = Antiguedad_Dias(primero, ultimo) + 1


            _cod_comp = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_comp")), "X", dtRegistro.Rows(0).Item("cod_comp"))
            _tipo_emp = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_tipo")), "X", dtRegistro.Rows(0).Item("cod_tipo"))

            dtAguinaldo = sqlExecute("select * from agui where cod_comp = '" & _cod_comp & "' and cod_tipo = '" & _tipo_emp & "' and anos = '" & anios & "'")

            If dtAguinaldo.Rows.Count > 0 Then
                dias = IIf(IsDBNull(dtAguinaldo.Rows(0).Item("DIAS")), 0, dtAguinaldo.Rows(0).Item("DIAS")) + IIf(IsDBNull(dtAguinaldo.Rows(0).Item("DIAS_AD")), 0, dtAguinaldo.Rows(0).Item("DIAS_AD"))

            Else
                dias = 15
            End If

            corresponden = (dias * ant_completa) / dias_anuales

            If corresponden = 0 And Not Filtro.Trim = "" Then

                Dim drFila As DataRow = dtConcGrid.NewRow

                drFila("concepto") = dtDIASAG.Rows(0).Item("concepto").ToString.Trim
                drFila("descripcion") = Trim(IIf(IsDBNull(dtDIASAG.Rows(0).Item("nombre")), "", dtDIASAG.Rows(0).Item("nombre")))
                drFila("monto") = 0

                dtConcGrid.Rows.Add(drFila)

            ElseIf corresponden <> 0 Then

                Dim drFila As DataRow = dtConcGrid.NewRow

                drFila("concepto") = dtDIASAG.Rows(0).Item("concepto").ToString.Trim
                drFila("descripcion") = Trim(IIf(IsDBNull(dtDIASAG.Rows(0).Item("nombre")), "", dtDIASAG.Rows(0).Item("nombre")))
                drFila("monto") = Math.Round(corresponden, 2)

                dtConcGrid.Rows.Add(drFila)

            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar obtener el aguinaldo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    'DIASVA
    Private Sub Vacaciones1(Optional ByVal Filtro As String = "")

        Dim valor As Double = 0
        Dim dtDIASVA As New DataTable
        Dim fechaproy As Date

        Try

            dtDIASVA = sqlExecute("select top 1 * from conceptos where concepto = 'DIASVA'", "NOMINA")

            If Not (dtRegistro.Rows.Count > 0 Or dtDIASVA.Rows.Count > 0) Then Exit Sub

            fechaproy = BajaFiniquito.Value

            Dim query = "" &
           "WITH L0 AS ( " &
           "   select " &
           "      va.reloj, " &
           "      va.nombres, " &
           "      va.cod_tipo, " &
           "      va.alta, " &
           "      alta_antiguedad, " &
           "      sueldo, " &
           "      saldo_final as saldo_inicial, " &
           "      DATEADD(dd,1,periodo_fin) as periodo_inicio, " &
           "      CAST('" & FechaSQL(fechaproy) & "' AS date) as periodo_fin, " &
           "      periodo_antiguedad + 1 as periodo_antiguedad, " &
           "      case when exists (select top 1 dias from vac_especiales where vac_especiales.reloj = va.reloj and anos = periodo_antiguedad + 1) then (select top 1 dias from vac_especiales where vac_especiales.reloj = va.reloj and anos = periodo_antiguedad + 1) " &
           "            else (select top 1 dias from vacaciones where cod_tipo = va.COD_TIPO and anos = va.periodo_antiguedad + 1) end as periodo_corresponden, " &
           "      datediff(dd,DATEADD(dd,1,periodo_fin),'" & FechaSQL(fechaproy) & "') + 1 as periodo_dias, " &
           "      ROW_NUMBER() OVER(PARTITION BY va.reloj ORDER BY periodo_inicio DESC) AS RowNum " &
           "   from vac_aniversarios va " &
           "        join personal p " &
           "        on va.reloj = p.reloj " &
           "        where va.reloj = '" & txtReloj.Text & "'" &
           "), " &
           "L1 AS ( " &
           "    select *, " &
           "          cast((CAST(periodo_corresponden AS DECIMAL(5,2)) /365) * periodo_dias AS DECIMAL(5,2)) as periodo_proporcion, " &
           "          coalesce((select count(a.reloj) " &
           "		            from ta.dbo.ausentismo a " &
           "		            where a.fecha between L0.periodo_inicio and L0.periodo_fin and a.tipo_aus='VAC' and a.reloj = L0.reloj " &
           "		            group by a.reloj),0) as dias_tomados " &
           "    from L0 where RowNum = 1 " &
           ") " &
           "select reloj,nombres,cod_tipo,alta,alta_antiguedad,sueldo,saldo_inicial,periodo_inicio,periodo_fin,periodo_antiguedad,periodo_dias,periodo_corresponden,periodo_proporcion,dias_tomados, " &
           "   saldo_inicial + periodo_proporcion - dias_tomados as saldo_final " &
           "from L1"

            Dim dtTemp As DataTable = sqlExecute(query)

            Dim query2 As String = "" &
                "with L0 as ( " &
                "select reloj, " &
                "    rtrim(apaterno) + ', ' + rtrim(amaterno) + ', ' + rtrim(nombre) as nombres, " &
                "    cod_tipo, " &
                "    alta, " &
                "    coalesce((CASE WHEN month(alta_vacacion) = 2 and day(alta_vacacion) = 29 then DATEADD(day,-1,alta_vacacion) else  alta_vacacion end),alta) AS ALTA_ANTIGUEDAD, " &
                "    sactual as SUELDO, " &
                "    coalesce((select DIAS from vac_inicial where reloj = personal.reloj),0) as saldo_inicial, " &
                "    alta as periodo_inicio, " &
                "    CAST('" & FechaSQL(fechaproy) & "' AS date) as periodo_fin " &
                "from personal " &
                "where reloj = '" & txtReloj.Text & "' and datediff(dd,alta,'" & FechaSQL(fechaproy) & "')<365 and not exists(select reloj from vac_aniversarios where reloj = '" & txtReloj.Text & "') " &
                "), " &
                "L1 as ( " &
                "select *, " &
                "    case when (year(periodo_fin) - year(alta_antiguedad)) < 1 then 1 else year(periodo_fin) - year(alta_antiguedad) end as periodo_antiguedad  " &
                "from L0 " &
                "), " &
                "L2 as ( " &
                "    select *, " &
                "    datediff(dd,periodo_inicio,periodo_fin) + 1 as PERIODO_DIAS, " &
                "    case when exists (select top 1 dias from vac_especiales where vac_especiales.reloj = L1.reloj and anos = periodo_antiguedad ) then (select top 1 dias from vac_especiales where vac_especiales.reloj = L1.reloj and anos = periodo_antiguedad) " &
                "         else (select top 1 dias from vacaciones where cod_tipo = L1.COD_TIPO and anos = periodo_antiguedad) end as periodo_corresponden " &
                "from L1 " &
                "), " &
                "L3 as ( " &
                "select *, " &
                "    cast((CAST(periodo_corresponden AS DECIMAL(5,2)) /365) * periodo_dias AS DECIMAL(5,2)) as periodo_proporcion, " &
                "    coalesce((select count(a.reloj) " &
                "		            from ta.dbo.ausentismo a " &
                "		            where a.fecha between periodo_inicio and periodo_fin and a.tipo_aus='VAC' and a.reloj = L2.reloj " &
                "		            group by a.reloj),0) as dias_tomados " &
                "from L2 " &
                ") " &
                "select *, " &
                "    SALDO_INICIAL + PERIODO_PROPORCION  - DIAS_TOMADOS as SALDO_FINAL " &
                "from L3 "

            Dim dtTemp2 As DataTable = sqlExecute(query2)

            dtTemp.Merge(dtTemp2, False, MissingSchemaAction.Ignore)

            dtTemp.DefaultView.Sort = "reloj ASC"
            dtTemp = dtTemp.DefaultView.ToTable

            If dtTemp.Rows.Count > 0 Then

                valor = dtTemp.Rows(0).Item("SALDO_FINAL")

            End If

            If valor = 0 And Not Filtro.Trim = "" Then

                Dim drFila As DataRow = dtConcGrid.NewRow

                drFila("concepto") = dtDIASVA.Rows(0).Item("concepto").ToString.Trim
                drFila("descripcion") = Trim(IIf(IsDBNull(dtDIASVA.Rows(0).Item("nombre")), "", dtDIASVA.Rows(0).Item("nombre")))
                drFila("monto") = 0

                dtConcGrid.Rows.Add(drFila)

            ElseIf valor <> 0 Then

                Dim drFila As DataRow = dtConcGrid.NewRow

                drFila("concepto") = dtDIASVA.Rows(0).Item("concepto").ToString.Trim
                drFila("descripcion") = Trim(IIf(IsDBNull(dtDIASVA.Rows(0).Item("nombre")), "", dtDIASVA.Rows(0).Item("nombre")))
                drFila("monto") = valor

                dtConcGrid.Rows.Add(drFila)


            End If



        Catch ex As Exception
            MessageBox.Show("Error al intentar obtener los dias de vacaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    '*** Calculo actual 2019-09-04 ***
    Private Sub Comedor(Optional ByVal Filtro As String = "")

        Dim dtComedor As New DataTable
        Dim strSQL As String = ""
        Dim fechaIni As Date = Nothing
        Dim fechafin As Date = Nothing

        Try

            If Not dtRegistro.Rows.Count > 0 Then Exit Sub




            'If TipoEmp.Trim.ToUpper = "O" Then
            fechaIni = CDate(Split(cmbPeriodos.Text, ",")(4)).AddDays(1)
            fechafin = CDate(sFechaFiniquito)
            'Else

            '    fechaIni = CDate(Split(cmbPeriodos.Text, ",")(3))
            '    fechafin = CDate(sFechaFiniquito)

            'End If

            If Not fechaIni <= fechafin Then Exit Sub


            strSQL = "declare @fecha_ini char(10) " & vbCr &
             "declare @fecha_fin char(10)" & vbCr &
             "declare @reloj char(6)" & vbCr &
             "set @fecha_ini = '" & FechaSQL(fechaIni) & "'" & vbCr &
             "set @fecha_fin = '" & FechaSQL(fechafin) & "'" & vbCr &
             "set @reloj = '" & txtReloj.Text.Trim & "' " & vbCr &
             "select TotalComedor.concepto,ltrim(rtrim(conceptos.nombre)) as Descripcion,Total as Monto" & vbCr &
             "from( " & vbCr &
             "select  (case subsidio " & vbCr &
         "when 'C' then 'DIACON' " & vbCr &
         "when 'S' then 'DIASIN'" & vbCr &
         "when 'Z'then  'DIADES' end) as concepto,count(subsidio) as 'Total' from (select *" & vbCr &
         "from hrs_brt_cafeteria left join horarios_cafeteria on hrs_brt_cafeteria.horario = horarios_cafeteria.cod_hora_cafe" & vbCr &
         "where reloj = @reloj and fecha between @fecha_ini and @fecha_fin and subsidio in('C','Z','S')" & vbCr &
         "and upper(rtrim(ltrim(isnull(horarios_cafeteria.genera_costo,'')))) <> 'X') cafeteria" & vbCr &
         "group by subsidio) TotalComedor left join nomina.dbo.conceptos on TotalComedor.concepto = conceptos.concepto"


            If Not Filtro.Trim = "" Then
                strSQL &= " where TotalComedor.concepto = '" & Filtro & "'"
            End If

            Application.DoEvents()
            dtComedor = sqlExecute(strSQL, "TA")

            If dtComedor.Rows.Count > 0 And Not dtComedor.Columns.Contains("ERROR") Then

                For Each drRow As DataRow In dtComedor.Rows
                    Application.DoEvents()
                    Dim drFila As DataRow = dtConcGrid.NewRow()

                    drFila("concepto") = drRow("concepto").ToString.Trim
                    drFila("descripcion") = Trim(IIf(IsDBNull(drRow("descripcion")), "", drRow("descripcion")))
                    drFila("monto") = drRow("monto")

                    dtConcGrid.Rows.Add(drFila)

                Next

            ElseIf Not Filtro.Trim = "" Then
                Application.DoEvents()
                dtComedor = sqlExecute("select top 1 * from conceptos where concepto = '" & Filtro.Trim & "'", "NOMINA")


                If dtComedor.Rows.Count > 0 And Not dtComedor.Columns.Contains("ERROR") Then

                    Dim drFila As DataRow = dtConcGrid.NewRow()

                    drFila("concepto") = dtComedor.Rows(0).Item("concepto").ToString.Trim
                    drFila("descripcion") = Trim(IIf(IsDBNull(dtComedor.Rows(0).Item("nombre")), "", dtComedor.Rows(0).Item("nombre")))
                    drFila("monto") = 0

                    dtConcGrid.Rows.Add(drFila)
                End If



            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar cargar el monto del comedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    '*** Calculo actual 2019-09-04 ***
    Private Sub Movimientos(Optional ByVal Filtro As String = "")

        Dim dtMovimientos As New DataTable
        Dim strSQL As String = ""
        Dim AgregarLiqFondo As Double = 0

        Try

            If Not dtRegistro.Rows.Count > 0 Then Exit Sub


            strSQL = "declare @periodo char(6)" & vbCr &
             "declare @reloj char(6)" & vbCr &
             "set @periodo = '" & Trim(cmbPeriodos.SelectedValue) & "'" & vbCr &
             "set @reloj = '" & txtReloj.Text.Trim & "';" & vbCr &
             "" & vbCr &
             "with S0 as (" & vbCr &
             "   select c.CONCEPTO,c.NOMBRE,cf.alias as movimiento, cf.detalle" & vbCr &
             "   from conceptos c inner join conceptos_finiquito cf on c.CONCEPTO = cf.concepto" & vbCr &
             "   where cf.aplica_mov = 1 and cf.activo = 1" & vbCr &
             "), S1 as (" & vbCr &
             "   select S0.CONCEPTO,S0.NOMBRE, isnull(movimientos.MONTO,0) as monto from S0 inner join movimientos on S0.movimiento = movimientos.CONCEPTO " & vbCr &
             "   where (ano+periodo) = @periodo and reloj = @reloj and (isnull(monto,0) <> 0) and ltrim(rtrim(isnull(movimiento,''))) <> ''" & vbCr &
             "), S2 as (" & vbCr &
             "   select S0.CONCEPTO,S0.NOMBRE, isnull(movimientos.MONTO,0) as Descuento from S0 inner join movimientos on S0.detalle = movimientos.CONCEPTO " & vbCr &
             "   where (ano+periodo) = @periodo and reloj = @reloj and (isnull(monto,0) <> 0) and ltrim(rtrim(isnull(movimiento,''))) <> ''" & vbCr &
             ") select S1.*,isnuLl(S2.Descuento,0) as Descuento, case when (S1.monto - isnull(S2.Descuento,0)) < 0 then 0 else (S1.monto - isnull(S2.Descuento,0)) end as Total " & vbCr &
             "   from S1 left join S2 on S1.CONCEPTO = S2.CONCEPTO"

            Application.DoEvents()
            dtMovimientos = sqlExecute(strSQL, "NOMINA")

            If dtMovimientos.Rows.Count > 0 And Not dtMovimientos.Columns.Contains("ERROR") Then

                For Each drRow As DataRow In dtMovimientos.Rows

                    Application.DoEvents()
                    Dim drFila As DataRow = dtConcGrid.NewRow

                    drFila("concepto") = drRow("concepto").ToString.Trim
                    drFila("descripcion") = Trim(IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")))
                    drFila("monto") = Math.Round(IIf(IsDBNull(drRow("total")), 0, drRow("total")), 2)

                    dtConcGrid.Rows.Add(drFila)

                Next


            ElseIf Not (dtMovimientos.Columns.Contains("ERROR") And Filtro.Trim = "") Then

                Dim dtAgregar As DataTable = sqlExecute("select top 1 * from conceptos where concepto = '" & Filtro.Trim & "'", "NOMINA")

                If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then

                    Application.DoEvents()
                    Dim drFila As DataRow = dtConcGrid.NewRow

                    drFila("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                    drFila("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                    drFila("monto") = 0

                    dtConcGrid.Rows.Add(drFila)

                End If


            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar cargar el monto de los movimientos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Asistencia(Optional ByVal Filtro As String = "")

        Dim dtAusentismo As New DataTable
        'Dim dtTipoAusentismo As New DataTable
        Dim dtFactor As New DataTable
        Dim dtUnicos As New DataTable
        Dim _diasemana As Integer = 0

        Dim _Factor As Double = 0
        Dim _FechaFiniquito As Date = Nothing
        Dim _fecha_ini As Date = Nothing
        Dim _fecha_fin As Date = Nothing
        Dim strSQL As String = ""
        Dim tabla As String = ""
        'Dim tipo_ausentismo As String = ""

        Try


            'If TipoEmp.ToUpper.Trim = "O" Then
            tabla = "ta.dbo.periodos"
            'ElseIf TipoEmp.ToUpper.Trim = "A" Then
            '    tabla = "ta.dbo.periodos_quincenal"
            'Else
            '    Exit Sub
            'End If

            'If TipoEmp.Trim.ToUpper = "O" Then
            _fecha_ini = CDate(Split(cmbPeriodos.Text, ",")(4)).AddDays(1)
            _fecha_fin = CDate(sFechaFiniquito)
            'Else
            '    _fecha_ini = CDate(Split(cmbPeriodos.Text, ",")(3))
            '    _fecha_fin = CDate(sFechaFiniquito)

            'End If


            If _fecha_ini > _fecha_fin Then
                MessageBox.Show("Se presentó un error al intentar establecer el rango de fechas para obtener los ausentismos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If Not _fecha_ini = _fecha_fin Then
                _fecha_fin = _fecha_fin.AddDays(-1)
            Else
                Exit Sub
            End If


            strSQL = "declare @reloj char(6) = '" & txtReloj.Text.Trim & "'" & vbCr &
                    "declare @fecha_ini char(10) = '" & FechaSQL(_fecha_ini) & "'" & vbCr &
                    "declare @fecha_fin char(10) = '" & FechaSQL(_fecha_fin) & "';" & vbCr &
                    "with S0 as (" & vbCr &
                    "   select rtrim(ltrim(tipo_aus)) as tipo_aus,nombre,tipo_naturaleza,goce_sdo,percepcion as concepto" & vbCr &
                    "from tipo_ausentismo where percepcion is not null" & vbCr &
                    "union" & vbCr &
                    "select rtrim(ltrim(tipo_aus)) as tipo_aus,nombre,tipo_naturaleza,goce_sdo,deduccion as concepto " & vbCr &
                    "from tipo_ausentismo where deduccion is not null" & vbCr &
                    "),S1 as (" & vbCr &
                    "select reloj,tipo_aus,fecha " & vbCr &
                    "from ausentismo" & vbCr &
                    "where (reloj = @reloj)  and (fecha between @fecha_ini and @fecha_fin) " & vbCr &
                    "),S2 as (" & vbCr &
                    "select S1.*,S0.concepto from S1 inner join S0 on S1.tipo_aus = S0.tipo_aus" & vbCr &
                    "where S0.tipo_naturaleza not in('D','V') and S0.tipo_aus not in ('COR','CNV','16','INA','DES','INV','FSF','FES')" & vbCr &
                    ")select S2.*,rtrim(ltrim(conceptos.nombre)) as nombre from S2 inner join NOMINA.dbo.conceptos on S2.concepto = conceptos.CONCEPTO order by tipo_aus, fecha desc"

            dtAusentismo = sqlExecute(strSQL, "TA")
            Dim fecha_actual As String = FechaSQL(Now.AddDays(-1))


            If dtAusentismo.Rows.Count > 0 Then

                Application.DoEvents()

                dtUnicos = dtAusentismo.DefaultView.ToTable(True, "concepto", "nombre")

                For Each drConcepto As DataRow In dtUnicos.Select(IIf(TipoEmp.ToUpper.Trim = "A", "concepto not in('DIAFIN')", ""))


                    Dim _concepto_ As String = Trim(IIf(IsDBNull(drConcepto("concepto")), "", drConcepto("concepto")))
                    Dim _unidades_ As Integer = 0
                    Dim _descripcion_ As String = Trim(IIf(IsDBNull(drConcepto("nombre")), "", drConcepto("nombre")))
                    Dim _fecha_tope As String = ""
                    Dim fecha_maxima As String = ""

                    If _concepto_ = "DIAFIN" Or _concepto_ = "DIAFJU" Then

                        Select Case fecha_actual

                            Case Is > FechaSQL(_fecha_fin)

                                _fecha_tope = FechaSQL(_fecha_fin)
                                _unidades_ = dtAusentismo.Select("concepto = '" & _concepto_ & "' and (fecha >='" & FechaSQL(_fecha_ini) & "' and fecha <='" & _fecha_tope & "') ").Count

                            Case Is < FechaSQL(_fecha_fin)

                                _fecha_tope = fecha_actual
                                _unidades_ = dtAusentismo.Select("concepto = '" & _concepto_ & "' and (fecha >='" & FechaSQL(_fecha_ini) & "' and fecha <='" & _fecha_tope & "') ").Count

                            Case Else

                                _fecha_tope = FechaSQL(_fecha_fin)
                                _unidades_ = dtAusentismo.Select("concepto = '" & _concepto_ & "' and (fecha >='" & FechaSQL(_fecha_ini) & "' and fecha <='" & _fecha_tope & "') ").Count

                        End Select

                        If _unidades_ > 0 Then

                            fecha_maxima = FechaSQL(CDate(dtAusentismo.Compute("max(fecha)", "concepto = '" & _concepto_ & "' and (fecha >='" & FechaSQL(_fecha_ini) & "' and fecha <='" & _fecha_tope & "')")))

                        Else

                            Continue For

                        End If

                    Else

                        _unidades_ = dtAusentismo.Select("concepto = '" & _concepto_ & "'").Count

                        If _unidades_ > 0 Then

                            fecha_maxima = FechaSQL(CDate(dtAusentismo.Compute("max(fecha)", "concepto = '" & _concepto_ & "'")))

                        Else

                            Continue For

                        End If

                    End If

                    If TipoEmp.ToUpper.Trim = "A" Then

                        _Factor = 1

                    Else

                        dtFactor = sqlExecute("declare @f_Ausentismo char(10) = '" & fecha_maxima & "'" & vbCr &
                                    "select top 1 factor " & vbCr &
                                    "from rol_horarios " & vbCr &
                                    "where cod_comp = '" & dtCompania.Rows(0).Item("cod_comp") & "' and cod_hora = '" & dtCompania.Rows(0).Item("cod_hora") & "' " & vbCr &
                                    "and (ano+periodo) = (select top 1 (ano+periodo) as periodo from " & tabla & " where (@f_Ausentismo between FECHA_INI and FECHA_FIN) and (PERIODO_ESPECIAL is null or PERIODO_ESPECIAL = 0) order by ano desc, PERIODO desc)")

                        If dtFactor.Columns.Contains("ERROR") Or Not dtFactor.Rows.Count > 0 Then

                            _Factor = 0

                        Else

                            _Factor = IIf(IsDBNull(dtFactor.Rows(0).Item("factor")), 0, dtFactor.Rows(0).Item("factor"))

                        End If

                    End If

                    Dim drFila As DataRow = dtConcGrid.NewRow

                    drFila("concepto") = _concepto_
                    drFila("descripcion") = _descripcion_
                    drFila("monto") = _unidades_
                    drFila("factor") = _Factor
                    dtConcGrid.Rows.Add(drFila)

                Next

            End If


        Catch ex As Exception

            MessageBox.Show("Se presentó un error al intentar cargar la información de ausentismo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Sub DiasPrimaSabDom()

        Dim dtAsistencia As New DataTable
        Dim dtDiasPrimas As New DataTable
        Dim strSQL As String = ""

        Dim _fecha_ini As Date = Nothing
        Dim _fecha_fin As Date = Nothing

        Dim DiasSabado As Integer = 0
        Dim DiasDomingo As Integer = 0

        Try

            dtDiasPrimas = sqlExecute("select * from conceptos where concepto IN('DIASAB','DIADOM')", "NOMINA")

            If Not dtDiasPrimas.Rows.Count > 0 Then Exit Sub

            'If TipoEmp.Trim.ToUpper = "O" Then
            _fecha_ini = CDate(Split(cmbPeriodos.Text, ",")(4)).AddDays(1)
            _fecha_fin = CDate(sFechaFiniquito)
            'Else
            '    _fecha_ini = CDate(Split(cmbPeriodos.Text, ",")(3))
            '    _fecha_fin = CDate(sFechaFiniquito)

            'End If

            If _fecha_ini > _fecha_fin Then
                Exit Sub
            End If


            Select Case TipoEmp.Trim.ToUpper

                Case Is = "O"

                    strSQL = "WITH RangoPeriodo(anoperiodoini,anoperiodofin)" & vbCr &
                        "AS" & vbCr &
                        "(" & vbCr &
                        "select min(ano+periodo),max(ano+periodo)" & vbCr &
                        "from periodos" & vbCr &
                        "where (('" & FechaSQL(_fecha_ini) & "' BETWEEN fecha_ini and fecha_fin ) or ('" & FechaSQL(_fecha_fin) & "' BETWEEN fecha_ini and fecha_fin))" & vbCr &
                        "and (periodo_especial is null or periodo_especial = 0)" & vbCr &
                        ")" & vbCr &
                        "select sum(isnull(PRIMA_SAB,0)) as Sabado,sum(isnull(PRIMA_DOM,0)) as Domingo " & vbCr &
                        "from nomsem" & vbCr &
                        "where (ano+periodo) in( " & vbCr &
                        "select (periodos.ano+periodos.periodo) as PeriodoPrima from RangoPeriodo,periodos " & vbCr &
                        "where (periodos.ano+periodos.periodo)  BETWEEN RangoPeriodo.anoperiodoini and RangoPeriodo.anoperiodofin and " & vbCr &
                        "(periodo_especial is null or periodo_especial = 0)" & vbCr &
                        ") and reloj = '" & txtReloj.Text.Trim & "' and (isnull(PRIMA_SAB,0) = 1 or isnull(PRIMA_DOM,0) = 1)"

                Case Is = "A"

                    strSQL = "WITH RangoPeriodo(anoperiodoini,anoperiodofin)" & vbCr &
                        "AS" & vbCr &
                        "(" & vbCr &
                        "select min(ano+periodo),max(ano+periodo)" & vbCr &
                        "from periodos" & vbCr &
                        "where (('" & FechaSQL(_fecha_ini) & "' BETWEEN fecha_ini and fecha_fin ) or ('" & FechaSQL(_fecha_fin) & "' BETWEEN fecha_ini and fecha_fin))" & vbCr &
                        "and (periodo_especial is null or periodo_especial = 0)" & vbCr &
                        ")" & vbCr &
                        "select sum(isnull(PRIMA_SAB,0)) as Sabado,sum(isnull(PRIMA_DOM,0)) as Domingo " & vbCr &
                        "from nomsem" & vbCr &
                        "where (ano+periodo) in( " & vbCr &
                        "select (periodos.ano+periodos.periodo) as PeriodoPrima from RangoPeriodo,periodos " & vbCr &
                        "where (periodos.ano+periodos.periodo)  BETWEEN RangoPeriodo.anoperiodoini and RangoPeriodo.anoperiodofin and " & vbCr &
                        "(periodo_especial is null or periodo_especial = 0)" & vbCr &
                        ") and reloj = '" & txtReloj.Text.Trim & "' and (isnull(PRIMA_SAB,0) = 1 or isnull(PRIMA_DOM,0) = 1)"

                Case Else

                    strSQL = ""

            End Select


            dtAsistencia = sqlExecute(strSQL, "TA")

            If dtAsistencia.Rows.Count > 0 Then

                Dim dr As DataRow = dtAsistencia.Rows(0)

                DiasSabado = IIf(IsDBNull(dr("Sabado")), 0, dr("Sabado"))
                DiasDomingo = IIf(IsDBNull(dr("Domingo")), 0, dr("Domingo"))

                For Each drRow As DataRow In dtDiasPrimas.Rows

                    Dim _concepto As String = drRow("concepto").ToString.Trim

                    Dim drFila As DataRow = dtConcGrid.NewRow

                    If _concepto = "DIASAB" And Not DiasSabado = 0 Then

                        drFila("concepto") = _concepto
                        drFila("descripcion") = Trim(IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")))
                        drFila("monto") = DiasSabado
                        drFila("factor") = 0

                        dtConcGrid.Rows.Add(drFila)

                    ElseIf _concepto = "DIADOM" And Not DiasDomingo = 0 Then

                        drFila("concepto") = _concepto
                        drFila("descripcion") = Trim(IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")))
                        drFila("monto") = DiasDomingo
                        drFila("factor") = 0

                        dtConcGrid.Rows.Add(drFila)

                    End If


                Next

            End If



        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar cargar la información de dias para prima sabatina y/o dominical.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "DiasPrimaSabDom", ex.HResult, ex.Message)
        End Try

    End Sub

    'Horas Acumuladas de salidas anticipadas entre la ultmina nomina y la fecha de finiquito
    Private Sub PermisoSinGoceSueldoHrs()

        Dim dtHrs As New DataTable
        Dim dtConceptoUnidad As New DataTable
        Dim dtFactor As New DataTable

        Dim fecha_ini As String = ""
        Dim fecha_fin As String = ""

        Dim hrs_sal_anti As Double = 0
        Dim hr_sal_anti As Double = 0

        Dim _factor As Single = 0


        Dim tabla As String = ""


        Try

            If TipoEmp.Trim.ToUpper = "O" Or TipoEmp.Trim.ToUpper = "A" Then

                fecha_ini = FechaSQL(CDate(Trim(Split(cmbPeriodos.Text, ",")(4))).AddDays(1))
                fecha_fin = FechaSQL(BajaFiniquito.Value.AddDays(-1))
                tabla = "ta.dbo.periodos"

                'ElseIf TipoEmp.Trim.ToUpper = "A" Then

                '    fecha_ini = FechaSQL(CDate(Trim(Split(cmbPeriodos.Text, ",")(3))))
                '    fecha_fin = FechaSQL(BajaFiniquito.Value.AddDays(-1))
                '    tabla = "ta.dbo.periodos_quincenal"
            Else
                MessageBox.Show("No se pudo determinar el tipo de empleado.", "Tipo Empleado Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim fecha_actual As String = FechaSQL(Now.AddDays(-1))

            If fecha_actual < fecha_fin Then
                fecha_fin = fecha_actual
            End If

            If fecha_ini > fecha_fin Then
                MessageBox.Show("Rango de fechas errónea. '" & fecha_ini & "' al '" & fecha_fin & "'", "Rango de fechas Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            dtHrs = sqlExecute("declare @reloj char(6)" & vbCr &
                                            " declare @fecha_ini char(10)" & vbCr &
                                            " declare @fecha_fin char(10)" & vbCr &
                                            " set @reloj = '" & txtReloj.Text.Trim & "'" & vbCr &
                                            " set @fecha_ini = '" & fecha_ini & "'" & vbCr &
                                            " set @fecha_fin = '" & fecha_fin & "' " & vbCr &
                                            " select * " & vbCr &
                                            " from asist" & vbCr &
                                            " where reloj= @reloj and (FECHA_ENTRO between @fecha_ini and @fecha_fin) and (comentario like '%salida anticipada%')", "TA")


            For Each row As DataRow In dtHrs.Rows

                hr_sal_anti = HtoD(Trim(IIf(IsDBNull(row("dif_sal")), "00:00", row("dif_sal"))))

                hrs_sal_anti = hrs_sal_anti + IIf(hr_sal_anti <= 0, hr_sal_anti * -1, 0)

            Next

            If hrs_sal_anti > 0 Then

                If TipoEmp.Trim.ToUpper = "A" Then
                    _factor = 1

                Else

                    Dim fecha_maxima As String = FechaSQL(CDate(dtHrs.Compute("max(FECHA_ENTRO)", "")))

                    dtFactor = sqlExecute("declare @f_retardo char(10) = '" & fecha_maxima & "'" & vbCr &
                                "select top 1 factor " & vbCr &
                                "from rol_horarios " & vbCr &
                                "where cod_comp = '" & dtCompania.Rows(0).Item("cod_comp") & "' and cod_hora = '" & dtCompania.Rows(0).Item("cod_hora") & "' " & vbCr &
                                "and (ano+periodo) = (select top 1 (ano+periodo) as periodo from " & tabla & " where (@f_retardo between FECHA_INI and FECHA_FIN) and (PERIODO_ESPECIAL is null or PERIODO_ESPECIAL = 0) order by ano desc, PERIODO desc)")

                    If dtFactor.Rows.Count > 0 Then

                        _factor = IIf(IsDBNull(dtFactor.Rows(0).Item("factor")), 0, dtFactor.Rows(0).Item("factor"))

                    Else

                        _factor = 0

                    End If


                End If

                dtConceptoUnidad = sqlExecute("select top 1 * from conceptos where concepto = 'HRSPSG'", "NOMINA")

                If Not dtConceptoUnidad.Rows.Count > 0 Then
                    MessageBox.Show("No se encontro el concepto 'HRSRET'.", "Concepto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Dim drFila As DataRow = dtConcGrid.NewRow

                drFila("concepto") = dtConceptoUnidad.Rows(0).Item("concepto").ToString.Trim
                drFila("descripcion") = Trim(IIf(IsDBNull(dtConceptoUnidad.Rows(0).Item("nombre")), "", dtConceptoUnidad.Rows(0).Item("nombre")))
                drFila("monto") = hrs_sal_anti
                drFila("factor") = _factor

                dtConcGrid.Rows.Add(drFila)

            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un problema al intentar cargar los datos de 'Permiso sin goce de sueldo'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    'Horas Acumuladas de retardos entre la ultmina nomina y la fecha de finiquito
    Private Sub RetardosHrs()

        Dim dtHrs As New DataTable
        Dim dtFactor As New DataTable
        Dim dtConceptoUnidad As New DataTable

        Dim fecha_ini As String = ""
        Dim fecha_fin As String = ""

        Dim hrs_retardo As Double = 0
        Dim hr_retardo As Double = 0
        Dim _factor As Single = 0


        Dim tabla As String = ""

        Try

            If TipoEmp.Trim.ToUpper = "O" Or TipoEmp.Trim.ToUpper = "A" Then

                fecha_ini = FechaSQL(CDate(Trim(Split(cmbPeriodos.Text, ",")(4))).AddDays(1))
                fecha_fin = FechaSQL(BajaFiniquito.Value.AddDays(-1))
                tabla = "ta.dbo.periodos"

                'ElseIf TipoEmp.Trim.ToUpper = "A" Then

                '    fecha_ini = FechaSQL(CDate(Trim(Split(cmbPeriodos.Text, ",")(3))))
                '    fecha_fin = FechaSQL(BajaFiniquito.Value.AddDays(-1))
                '    tabla = "ta.dbo.periodos_quincenal"
            Else
                MessageBox.Show("No se pudo determinar el tipo de empleado.", "Tipo Empleado Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            Dim fecha_actual As String = FechaSQL(Now.AddDays(-1))

            If fecha_actual < fecha_fin Then
                fecha_fin = fecha_actual
            End If

            If fecha_ini > fecha_fin Then
                MessageBox.Show("Rango de fechas errónea. '" & fecha_ini & "' al '" & fecha_fin & "'", "Rango de fechas Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            dtHrs = sqlExecute("declare @reloj char(6)" & vbCr &
                                               " declare @fecha_ini char(10)" & vbCr &
                                               " declare @fecha_fin char(10)" & vbCr &
                                               " set @reloj = '" & txtReloj.Text.Trim & "'" & vbCr &
                                               " set @fecha_ini = '" & fecha_ini & "'" & vbCr &
                                               " set @fecha_fin = '" & fecha_fin & "' " & vbCr &
                                               " select * " & vbCr &
                                               " from asist" & vbCr &
                                               " where reloj= @reloj and (FECHA_ENTRO between @fecha_ini and @fecha_fin) and (comentario like '%retardo%')", "TA")


            For Each row As DataRow In dtHrs.Rows

                hr_retardo = HtoD(Trim(IIf(IsDBNull(row("dif_ent")), "00:00", row("dif_ent"))))

                hrs_retardo = hrs_retardo + IIf(hr_retardo <= 0, hr_retardo * -1, 0)

            Next


            If hrs_retardo > 0 Then

                If TipoEmp.Trim.ToUpper = "A" Then
                    _factor = 1

                Else

                    Dim fecha_maxima As String = FechaSQL(CDate(dtHrs.Compute("max(FECHA_ENTRO)", "")))

                    dtFactor = sqlExecute("declare @f_retardo char(10) = '" & fecha_maxima & "'" & vbCr &
                                "select top 1 factor " & vbCr &
                                "from rol_horarios " & vbCr &
                                "where cod_comp = '" & dtCompania.Rows(0).Item("cod_comp") & "' and cod_hora = '" & dtCompania.Rows(0).Item("cod_hora") & "' " & vbCr &
                                "and (ano+periodo) = (select top 1 (ano+periodo) as periodo from " & tabla & " where (@f_retardo between FECHA_INI and FECHA_FIN) and (PERIODO_ESPECIAL is null or PERIODO_ESPECIAL = 0) order by ano desc, PERIODO desc)")

                    If dtFactor.Rows.Count > 0 Then

                        _factor = IIf(IsDBNull(dtFactor.Rows(0).Item("factor")), 0, dtFactor.Rows(0).Item("factor"))

                    Else

                        _factor = 0

                    End If


                End If



                dtConceptoUnidad = sqlExecute("select top 1 * from conceptos where concepto = 'HRSRET'", "NOMINA")

                If Not dtConceptoUnidad.Rows.Count > 0 Then
                    MessageBox.Show("No se encontro el concepto 'HRSRET'.", "Concepto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Dim drFila As DataRow = dtConcGrid.NewRow

                drFila("concepto") = dtConceptoUnidad.Rows(0).Item("concepto").ToString.Trim
                drFila("descripcion") = Trim(IIf(IsDBNull(dtConceptoUnidad.Rows(0).Item("nombre")), "", dtConceptoUnidad.Rows(0).Item("nombre")))
                drFila("monto") = hrs_retardo
                drFila("factor") = _factor

                dtConcGrid.Rows.Add(drFila)

            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un problema al intentar cargar los datos de 'Retardo'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub



    Private Sub Aplicar_descuento(ByVal tipo_empleado As String, ByVal dtMovimientos As DataTable)

        Dim UlNomPagar As New DataTable
        Dim NomPagar As String = ""


        Try

            If tipo_empleado.Trim = "O" Or tipo_empleado.Trim = "A" Then
                UlNomPagar = sqlExecute("select top 1 (ano+periodo) as periodo,FECHA_INI,FECHA_FIN from periodos where FECHA_FIN < '" & FechaSQL(BajaFiniquito.Value) & "' and (PERIODO_ESPECIAL is null or  PERIODO_ESPECIAL = 0) order by ano desc, periodo desc", "TA")
                'ElseIf tipo_empleado.Trim = "A" Then
                '    UlNomPagar = sqlExecute(" select top 1 (ano+periodo) as periodo,FECHA_INI,FECHA_FIN from periodos_quincenal where ('" & FechaSQL(BajaFiniquito.Value) & "' >= fecha_ini and '" & FechaSQL(BajaFiniquito.Value) & "' <= fecha_fin) and (PERIODO_ESPECIAL is null or  PERIODO_ESPECIAL = 0) order by ano desc, periodo desc", "TA")
            End If

            If UlNomPagar.Rows.Count > 0 And Not UlNomPagar.Columns.Contains("ERROR") Then

                NomPagar = UlNomPagar.Rows(0).Item("periodo").ToString.Trim

                If Not NomPagar <= Trim(cmbPeriodos.SelectedValue) Then

                    For Each drRow As DataRow In dtMovimientos.Select("concepto not in ('LIFAHC','LIFAHE')")

                        Application.DoEvents()

                        Dim total As Double = Math.Round(IIf(IsDBNull(drRow("total")), 0, drRow("total")), 2)

                        If total > 0 Then

                            Dim drFila As DataRow = dtConcGrid.NewRow

                            drFila("concepto") = drRow("concepto").ToString.Trim
                            drFila("descripcion") = Trim(IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")))
                            drFila("monto") = Math.Round(drRow("total"), 2)

                            dtConcGrid.Rows.Add(drFila)

                        End If

                    Next

                Else

                    For Each drRow As DataRow In dtMovimientos.Select("concepto not in ('LIFAHC','LIFAHE')")

                        Application.DoEvents()

                        Dim monto As Double = Math.Round(IIf(IsDBNull(drRow("monto")), 0, drRow("monto")), 2)

                        If monto > 0 Then

                            Dim drFila As DataRow = dtConcGrid.NewRow

                            drFila("concepto") = drRow("concepto").ToString.Trim
                            drFila("descripcion") = Trim(IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")))
                            drFila("monto") = Math.Round(drRow("monto"), 2)

                            dtConcGrid.Rows.Add(drFila)

                        End If

                    Next


                End If


            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar cargar los datos de movimientos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Proyeccion_Fondo_Ahorro(ByVal tipo_empleado As String, ByVal dtMovimientos As DataTable)

        Dim valor As Double = 0

        Dim UlNomPagar As New DataTable
        Dim dtFactor As New DataTable
        Dim dtAusentismo As New DataTable
        Dim NomPagar As String = ""
        Dim fecha_ini As String = ""
        Dim fecha_fin As String = ""
        Dim factor As Double = 0
        Dim total As Double = 0
        Dim retardo As Double = 0
        Dim hrs_retardo As Double = 0
        Dim hr_retardo As Double = 0
        Dim salida_anticipada As Double = 0
        Dim hrs_sal_anti As Double = 0
        Dim hr_sal_anti As Double = 0
        Dim acum_base As Double = 0

        Dim SalarioDiario As Double = 0
        Dim uma As Double = 0
        Dim Calc_Salario As Double = 0
        Dim Calc_Uma As Double = 0


        Try


            If tipo_empleado.Trim = "O" Or tipo_empleado.Trim = "A" Then
                UlNomPagar = sqlExecute("select top 1 (ano+periodo) as periodo,FECHA_INI,FECHA_FIN from periodos where FECHA_FIN < '" & FechaSQL(BajaFiniquito.Value) & "' and (PERIODO_ESPECIAL is null or  PERIODO_ESPECIAL = 0) order by ano desc, periodo desc", "TA")
                'ElseIf tipo_empleado.Trim = "A" Then
                '    UlNomPagar = sqlExecute(" select top 1 (ano+periodo) as periodo,FECHA_INI,FECHA_FIN from periodos_quincenal where ('" & FechaSQL(BajaFiniquito.Value) & "' >= fecha_ini and '" & FechaSQL(BajaFiniquito.Value) & "' <= fecha_fin) and (PERIODO_ESPECIAL is null or  PERIODO_ESPECIAL = 0) order by ano desc, periodo desc", "TA")
            End If

            If UlNomPagar.Rows.Count > 0 And Not UlNomPagar.Columns.Contains("ERROR") Then

                NomPagar = UlNomPagar.Rows(0).Item("periodo")

                If Not NomPagar <= Trim(cmbPeriodos.SelectedValue) Then

                    If dtMovimientos.Select("concepto in ('LIFAHC','LIFAHE')").Count > 0 Then

                        fecha_ini = UlNomPagar.Rows(0).Item("fecha_ini")

                        fecha_fin = UlNomPagar.Rows(0).Item("fecha_fin")

                        dtFactor = sqlExecute("select factor from personal.dbo.rol_horarios where cod_comp = '" & dtCompania.Rows(0).Item("cod_comp") & "' and COD_HORA = '" & dtCompania.Rows(0).Item("cod_hora") & "' and (ano+periodo) = '" & NomPagar & "'")

                        factor = CDbl(IIf(IsDBNull(dtFactor.Rows(0).Item("factor")), 0, dtFactor.Rows(0).Item("factor")))

                        SalarioDiario = IIf(IsDBNull(dtCompania.Rows(0).Item("sactual")), 0, dtCompania.Rows(0).Item("sactual"))

                        uma = IIf(IsDBNull(dtCompania.Rows(0).Item("uma")), 0, dtCompania.Rows(0).Item("uma"))


                        dtAusentismo = sqlExecute("declare @reloj char(6)" & vbCr &
                                                 " declare @fecha_ini char(10)" & vbCr &
                                                 " declare @fecha_fin char(10)" & vbCr &
                                                 " set @reloj = '" & txtReloj.Text.Trim & "'" & vbCr &
                                                 " set @fecha_ini = '" & fecha_ini & "'" & vbCr &
                                                 " set @fecha_fin = '" & fecha_fin & "' " & vbCr &
                                                 " select TIPO_AUS,count(TIPO_AUS) as total " & vbCr &
                                                 " from asist" & vbCr &
                                                 " where reloj= @reloj and FECHA_ENTRO between @fecha_ini and @fecha_fin and TIPO_AUS in ('FI','JUS','MAT','EG','RT','PSG','SUS') group by TIPO_AUS", "TA")


                        For Each row As DataRow In dtAusentismo.Select("TIPO_AUS in ('FI','JUS','PSG','SUS')")

                            total = total + (row("total") * factor * SalarioDiario)

                        Next


                        For Each row As DataRow In dtAusentismo.Select("TIPO_AUS in ('MAT','EG','RT')")

                            total = total + (row("total") * SalarioDiario)

                        Next


                        dtAusentismo = sqlExecute("declare @reloj char(6)" & vbCr &
                                                 " declare @fecha_ini char(10)" & vbCr &
                                                 " declare @fecha_fin char(10)" & vbCr &
                                                 " set @reloj = '" & txtReloj.Text.Trim & "'" & vbCr &
                                                 " set @fecha_ini = '" & fecha_ini & "'" & vbCr &
                                                 " set @fecha_fin = '" & fecha_fin & "' " & vbCr &
                                                 " select * " & vbCr &
                                                 " from asist" & vbCr &
                                                 " where reloj= @reloj and (FECHA_ENTRO between @fecha_ini and @fecha_fin) and (comentario like '%retardo%' or comentario like '%salida anticipada%')", "TA")

                        For Each row As DataRow In dtAusentismo.Select("comentario like '%retardo%'")


                            hr_retardo = (HtoD(Trim(IIf(IsDBNull(row("dif_ent")), "00:00", row("dif_ent")))))

                            hrs_retardo = hrs_retardo + IIf(hr_retardo <= 0, hr_retardo * -1, 0)

                        Next

                        For Each row As DataRow In dtAusentismo.Select("comentario like '%salida anticipada%'")

                            hr_sal_anti = hrs_sal_anti + HtoD(Trim(IIf(IsDBNull(row("dif_sal")), "00:00", row("dif_sal"))))

                            hrs_sal_anti = hrs_sal_anti + IIf(hr_sal_anti <= 0, hr_sal_anti * -1, 0)

                        Next

                        retardo = (SalarioDiario / 8) * hrs_retardo * factor

                        salida_anticipada = (SalarioDiario / 8) * hrs_sal_anti * factor

                        total = total + retardo + salida_anticipada

                        acum_base = (7 * SalarioDiario) - total

                        If Not Math.Round(acum_base, 2) = 0 Then

                            Calc_Salario = (acum_base * 9.4) / 100.0

                            Calc_Uma = uma * 7 * 10 * 0.13

                            valor = Math.Round(IIf(Calc_Salario > Calc_Uma, Calc_Uma, Calc_Salario), 2)

                        Else
                            valor = 0
                        End If

                        For Each drRow As DataRow In dtMovimientos.Select("concepto in ('LIFAHC','LIFAHE')")

                            Application.DoEvents()
                            Dim drFila As DataRow = dtConcGrid.NewRow

                            drFila("concepto") = drRow("concepto").ToString.Trim
                            drFila("descripcion") = Trim(IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")))

                            drFila("monto") = Math.Round(drRow("monto") + valor, 2)

                            dtConcGrid.Rows.Add(drFila)

                        Next

                    End If

                Else

                    If dtMovimientos.Select("concepto in ('LIFAHC','LIFAHE')").Count > 0 Then

                        For Each drRow As DataRow In dtMovimientos.Select("concepto in ('LIFAHC','LIFAHE')")

                            Application.DoEvents()
                            Dim drFila As DataRow = dtConcGrid.NewRow

                            drFila("concepto") = drRow("concepto").ToString.Trim
                            drFila("descripcion") = Trim(IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")))

                            drFila("monto") = Math.Round(drRow("monto"), 2)

                            dtConcGrid.Rows.Add(drFila)

                        Next

                    End If

                End If


            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar cargar los datos de fondo de ahorro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


    Private Sub EliminarConceptoAjustes(ByVal unico As String)
        sqlExecute("delete from ajustes_tmp where (ano+periodo+folio+rtrim(ltrim(concepto))) = '" & unico & "'", "NOMINA")
    End Sub

    Private Function InsertarConceptoAjustes(ano As String, periodo As String, folio As String, rl As String, concepto As String, descripcion As String, monto As Double, clave As String) As Boolean
        Dim proceso As Boolean = False
        If sqlExecute("insert into ajustes_tmp(ano,periodo,folio,reloj,concepto,descripcion,monto,factor) values ('" & ano & "','" & periodo & "','" & folio & "','" & rl & "','" & concepto & "','" & descripcion & "'," & monto & ",'" & clave & "')", "NOMINA").Columns.Contains("ERROR") Then
            proceso = False
        Else
            proceso = True
        End If

        Return proceso
    End Function

    Private Sub AjusteNetoTest(ByVal NetoFijo As Double)

        Dim dtISPT As New DataTable
        Dim dtImpuesto As New DataTable
        Dim dtSubempleo As New DataTable
        Dim dtTotales As New DataTable

        Dim Row As DataRow = Nothing

        Dim percepciones As Decimal = 0
        Dim deducciones As Decimal = 0
        Dim neto As Decimal = 0
        Dim gravable As Decimal = 0
        Dim ispt As Decimal = 0
        Dim isptre As Decimal = 0

        Dim unidades As Decimal = 0
        Dim gratificacion As Decimal = 0

        Dim limite_inferior As Decimal = 0
        Dim Excedente_Limite_Inferior As Decimal = 0
        Dim Tasa_isr As Decimal = 0
        Dim ISR_Excedente_Limite_Inferior As Decimal = 0
        Dim Couta_Fija As Decimal = 0
        Dim ISR_Cargo As Decimal = 0
        Dim Subsidio_Empleado As Decimal = 0
        Dim nuevo_isr As Decimal = 0

        Dim continuar As Boolean = True

        Dim strSQL As String = ""

        Dim AjusteDec As Decimal = 0

        Try

            AjusteDec = CDec(NetoFijo)

            dtISPT = sqlExecute("select * from ispt_tmp where periodo = '" & IIf(TipoEmp.Trim.ToUpper = "A", "Semanal", "Semanal") & "' order by tabla,lim_inf", "NOMINA")

            strSQL = "declare @Folio int = '" & txtFolio.Text.Trim & "'" & vbCr &
                "declare @Reloj varchar(max) = '" & txtReloj.Text.Trim & "'" & vbCr &
                "select coalesce((select monto from movimientos_calculo where folio = @Folio and reloj = @Reloj and Concepto = 'TOTPER'),0) as Per," & vbCr &
                "coalesce((select monto from movimientos_calculo where folio = @Folio and reloj = @Reloj and Concepto = 'TOTDED'),0) as Ded," & vbCr &
                "coalesce((select monto from movimientos_calculo where folio = @Folio and reloj = @Reloj and Concepto = 'GRATIF'),0) as GRATIF," & vbCr &
                "coalesce((select monto from movimientos_calculo where folio = @Folio and reloj = @Reloj and Concepto = 'NETO'),0) as Neto," & vbCr &
                "coalesce((select monto from movimientos_calculo where folio = @Folio and reloj = @Reloj and Concepto = 'PERGRA'),0) as Gravable," & vbCr &
                "coalesce((select monto from movimientos_calculo where folio = @Folio and reloj = @Reloj and Concepto = 'ISPT'),0) as ISPT," & vbCr &
                "coalesce((select monto from movimientos_calculo where folio = @Folio and reloj = @Reloj and Concepto = 'ISPTRE'),0) as ISPTRE"

            dtTotales = sqlExecute(strSQL, "NOMINA")


            If Not (dtISPT.Rows.Count > 0 And dtTotales.Rows.Count > 0) Then
                MessageBox.Show("No se localizó la información necesaria para realizar el ajuste al neto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Row = dtTotales.Rows(0)

            percepciones = CDec(Math.Round(Row.Item("Per"), 2))
            deducciones = CDec(Math.Round(Row.Item("Ded"), 2))
            gratificacion = CDec(Math.Round(Row.Item("GRATIF"), 2))
            neto = CDec(Math.Round(Row.Item("neto"), 2))
            gravable = CDec(IIf(Math.Round(Row.Item("Gravable"), 2) < 0.01, 0.01, Math.Round(Row.Item("Gravable"), 2)))
            ispt = CDec(Math.Round(Row.Item("ISPT"), 2))
            isptre = CDec(Math.Round(Row.Item("ISPTRE"), 2))

            If neto <= 0 Then
                MessageBox.Show("El neto actual es menor o igual a cero, por lo que no se llevará a cabo el " &
                                "cálculo del neto fijo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            If AjusteDec <= 0 Then
                MessageBox.Show("El neto fijo debe ser mayor a cero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            ElseIf AjusteDec < neto Then
                MessageBox.Show("El neto fijo no se realizará ya que la cantidad ingresada es menor que el neto actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub

            ElseIf AjusteDec = neto Then

                MessageBox.Show("El neto fijo no se realizará ya que la cantidad ingresada es igual al neto actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub

            End If

            unidades = 10 ^ (CStr(Fix(percepciones)).Length - 1)

            percepciones = percepciones - gratificacion

            deducciones = Math.Round(deducciones - isptre, 2)

            gravable = gravable + unidades
            gratificacion = gratificacion + unidades

            If Not continuar Then

                MessageBox.Show("El cálculo para el neto fijo no se pudo realizar dado que el gravable " &
                                "no es mayor a cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            dtImpuesto = dtISPT.Select("tabla = 'Impuesto'", "lim_inf desc").CopyToDataTable

            dtSubempleo = dtISPT.Select("tabla = 'SubEmpleo'", "lim_inf desc").CopyToDataTable

            Row = dtImpuesto.Select("lim_inf <= " & gravable, "lim_inf desc")(0)

            limite_inferior = Row.Item("lim_inf")
            Excedente_Limite_Inferior = gravable - limite_inferior
            Tasa_isr = Row.Item("porcentaje")
            ISR_Excedente_Limite_Inferior = Excedente_Limite_Inferior * Tasa_isr
            Couta_Fija = Row.Item("cta_fija")
            ISR_Cargo = Math.Round((ISR_Excedente_Limite_Inferior + Couta_Fija), 2)

            Row = dtSubempleo.Select("lim_inf <= " & gravable, "lim_inf desc")(0)

            nuevo_isr = Math.Round(IIf(ISR_Cargo > Subsidio_Empleado, ISR_Cargo - Subsidio_Empleado, 0), 2)

            neto = Math.Round((percepciones + gratificacion) - (deducciones + nuevo_isr), 2)

            Do While neto <> AjusteDec

                Application.DoEvents()

                Select Case neto

                    Case Is > AjusteDec

                        gravable = IncrementarValor(gravable, 2, -1, unidades)
                        gratificacion = IncrementarValor(gratificacion, 2, -1, unidades)

                        unidades = unidades / CDec(10)


                    Case Is < AjusteDec

                        gravable = IncrementarValor(gravable, 2, 1, unidades)
                        gratificacion = IncrementarValor(gratificacion, 2, 1, unidades)

                End Select

                If Not gravable > 0 Then
                    continuar = False
                    Exit Do
                End If

                Row = dtImpuesto.Select("lim_inf <= " & gravable, "lim_inf desc")(0)

                limite_inferior = Row.Item("lim_inf")
                Excedente_Limite_Inferior = gravable - limite_inferior
                Tasa_isr = Row.Item("porcentaje")
                ISR_Excedente_Limite_Inferior = Excedente_Limite_Inferior * Tasa_isr
                Couta_Fija = Row.Item("cta_fija")
                ISR_Cargo = Math.Round((ISR_Excedente_Limite_Inferior + Couta_Fija), 2)

                Row = dtSubempleo.Select("lim_inf <= " & gravable, "lim_inf desc")(0)

                Subsidio_Empleado = Row.Item("subempleo")

                nuevo_isr = Math.Round(IIf(ISR_Cargo > Subsidio_Empleado, ISR_Cargo - Subsidio_Empleado, 0), 2)

                neto = Math.Round((percepciones + gratificacion) - (deducciones + nuevo_isr), 2)

                If neto <= 0 Then
                    continuar = False
                    Exit Do
                End If

            Loop

            If Not continuar Then

                MessageBox.Show("El cálculo para el neto fijo no se pudo realizar dado que el neto fijo " &
                                "no se pudo calcular correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Application.DoEvents()

            strSQL = "declare @Folio int" & vbCr &
                "declare @Reloj varchar(max) ='" & txtReloj.Text.Trim & "'" & vbCr &
                " set @Folio = '" & txtFolio.Text.Trim & "'" & vbCr &
                " delete from movimientos_calculo where folio = @Folio and reloj = @Reloj" & vbCr &
                " if exists(select top 1 * from ajustes_tmp where folio = @Folio and reloj = @Reloj and concepto = 'GRATIF')" & vbCr &
                " begin" & vbCr &
                " update ajustes_tmp set monto = " & gratificacion & " where folio = @Folio and reloj = @Reloj and concepto = 'GRATIF'" & vbCr &
                " exec CalculoCTE @Folio,@Reloj" & vbCr &
                " end" & vbCr &
                " else" & vbCr &
                " begin" & vbCr &
                " insert into ajustes_tmp(ano,periodo,folio,reloj,concepto,monto)" & vbCr &
                " select top 1 ano,periodo,folio,reloj,'GRATIF' as concepto, " & gratificacion & " as monto from ajustes_tmp where folio = @Folio and reloj = @Reloj" & vbCr &
                " exec CalculoCTE @Folio,@Reloj" & vbCr &
                " delete from ajustes_tmp where folio = @Folio and reloj = @Reloj and concepto = 'GRATIF'" & vbCr &
                " end"

            If sqlExecute(strSQL, "NOMINA").Columns.Contains("ERROR") Then
                MessageBox.Show("Se presentó un error al intentar realizar el ajuste al neto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar realizar el ajuste al neto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


    Private Function IncrementarValor(ByVal Numero As Double, ByVal Decimales As Integer, ByVal restar As Integer, ByVal tmpUnidades As Decimal) As Decimal

        Dim v_return As Decimal = 0
        Dim NumDec As Decimal = 0
        Dim NumRedondear As Integer = 0
        Dim factor2 As Integer = 0
        Dim incrementar As Decimal = 0

        Try

            NumDec = CDec(Numero)

            factor2 = 10 ^ (Decimales)

            NumRedondear = Fix((NumDec * factor2))

            If restar = -1 Then

                NumRedondear = NumRedondear - (tmpUnidades * factor2)

                incrementar = tmpUnidades / CDec(10)

            Else

                incrementar = tmpUnidades

            End If

            NumRedondear = NumRedondear + (incrementar * factor2)

            v_return = CDec(NumRedondear) / CDec(factor2)

        Catch ex As Exception
            v_return = 0
        End Try



        Return v_return


    End Function


    Private Sub GenerarReporteFiniquito()
        Dim dtDatos As New DataTable

        Dim strSQL As String = ""

        If Not txtFolio.Text.Trim = "" Then

            strSQL = "exec ReporteFiniquito '" & txtFolio.Text.Trim & "','" & txtReloj.Text.Trim & "'"

            dtDatos = sqlExecute(strSQL, "NOMINA")

            If dtDatos.Columns.Contains("ERROR") Then

                MessageBox.Show("Error al cargar el reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            If Not dtDatos.Rows.Count > 0 Then

                MessageBox.Show("Folio no encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            frmVistaPrevia.LlamarReporte("Finiquito", dtDatos)
            frmVistaPrevia.ShowDialog()

            If MessageBox.Show("¿Desea generar el archivo pdf del finiquito?", "Generar pdf finiquito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim sfd As New SaveFileDialog

                sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                sfd.Filter = "PDF|*.PDF"
                sfd.Title = "Guardar en"
                sfd.OverwritePrompt = True
                sfd.RestoreDirectory = True
                sfd.FileName = "CTE Finiquito " & txtReloj.Text.Trim & " " & txtNombre.Text.Trim & ".PDF"

                If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    frmVistaPrevia.LlamarReporte("Finiquito", dtDatos, , , False, sfd.FileName.ToString)
                    MessageBox.Show("El finiquito ha sido guardado", "Finiquito guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If


        Else
            MessageBox.Show("No se ha seleccionado un folio válido. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub GenerarReporte()
        Dim dtDatos As New DataTable

        Dim strSQL As String = ""

        If Not txtFolio.Text.Trim = "" Then

            strSQL = "declare @Folio char(10) = '" & txtFolio.Text.Trim & "'" &
               " select movimientos_calculo.*,LTRIM(RTRIM(conceptos.COD_NATURALEZA)) as naturaleza,LTRIM(RTRIM(conceptos.NOMBRE)) as nombre,round(dbo.TotalPercepciones(@Folio),2) as TOTPER ," &
               " round(dbo.TotalDeducciones(@Folio),2) as TOTDED,round((dbo.TotalPercepciones(@Folio) - dbo.TotalDeducciones(@Folio)),2) as neto from movimientos_calculo  left join" &
               " conceptos on movimientos_calculo.Concepto = conceptos.CONCEPTO" &
               " where conceptos.COD_NATURALEZA in('P','D') and conceptos.POSITIVO in(0, 1) and SUMA_NETO = 1 and monto > 0  and movimientos_calculo .folio = @Folio " &
               " order by COD_NATURALEZA desc, movimientos_calculo.prioridad"

            dtDatos = sqlExecute(strSQL, "NOMINA")

            If dtDatos.Columns.Contains("ERROR") Then

                MessageBox.Show("Error al cargar el reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            If Not dtDatos.Rows.Count > 0 Then

                MessageBox.Show("Folio no encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            frmVistaPrevia.LlamarReporte("Finiquito", dtDatos)
            frmVistaPrevia.ShowDialog()
        Else
            MessageBox.Show("No se ha seleccionado un folio válido. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Function SumaLiqFonAhorro() As Double

        Dim dtUltNomPagar As New DataTable

        Dim valor As Double = 0

        Dim strSQL As String = ""

        Dim Row As DataRow = Nothing

        Dim PeriodoPagar As String = ""

        Dim _uma As Double = 0

        Try


            strSQL = "select top 1 *  from periodos " &
                " where ano = '" & Trim(Split(cmbPeriodos.Text, ",")(1)) & "' and  FECHA_FIN < convert(date,getdate()) and (PERIODO_ESPECIAL is null or  PERIODO_ESPECIAL = 0)" &
                " order by ano desc, periodo desc"

            dtUltNomPagar = sqlExecute(strSQL, "TA")

            If Not dtUltNomPagar.Columns.Contains("ERROR") And dtUltNomPagar.Rows.Count > 0 Then

                Row = dtUltNomPagar.Rows(0)

                PeriodoPagar = Trim(Row("ano")) & Trim(Row("periodo"))

                If Not PeriodoPagar = Trim(cmbPeriodos.SelectedValue) Then



                End If


            End If


        Catch ex As Exception

        End Try

        Return valor

    End Function


    Private Sub frmAjusteFiniquito_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            EsCargaIni = True
            Clave = frmCalcFiniquito.Bandera

            Dim sueldo1() As String = {"Diario", "Integrado"}
            Dim sueldo2() As String = {"Diario", "Integrado"}
            Dim sueldo3() As String = {"Diario", "Integrado"}

            lblTipoNomProcesada.Text = "Periodo última nómina procesada"

            dgvConceptos.AutoGenerateColumns = False

            cmbsueldoprima.DataSource = sueldo1
            cmbsueldoprima.Columns(0).Text = "Sueldo"
            cmbsueldoprima.SelectedIndex = 0

            cmbsueldograf.DataSource = sueldo2
            cmbsueldograf.Columns(0).Text = "Sueldo"
            cmbsueldograf.SelectedIndex = 0

            cmbsueldodias.DataSource = sueldo3
            cmbsueldodias.Columns(0).Text = "Sueldo"
            cmbsueldodias.SelectedIndex = 1

            txtNumGratificacion.ValueObject = 0

            dtConcGrid = sqlExecute("select Concepto,Descripcion, Monto,Factor from ajustes_tmp where 0 = 1", "NOMINA")
            dtConcGrid.DefaultView.Sort = "Concepto"
            dgvConceptos.DataSource = dtConcGrid

            If Clave = "NVO" Then

                AsignarFolio()

                dtRegistro = sqlExecute("select * from personalvw where reloj = '" & frmCalcFiniquito.txtReloj.Text.Trim & "'")


            ElseIf Clave = "EDIT" Then

                dtRegistro = sqlExecute("select * from nomina_calculo where folio = '" & frmCalcFiniquito.Folio.Trim & "' and reloj = '" & frmCalcFiniquito.txtReloj.Text.Trim & "'", "NOMINA")

            End If

            MostrarInformacion()

            HabilitarFiniquito()

            EsCargaIni = False

        Catch ex As Exception
            EsCargaIni = False
            MessageBox.Show("Se presentó un error al cargar la ventana. Si el problema persiste contacte al administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub frmAjusteFiniquito_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub swnetofijo_ValueChanged(sender As Object, e As EventArgs) Handles swnetofijo.ValueChanged
        Try

            If swnetofijo.Value Then
                txtNetoFijo.Enabled = True
                swpercefija.Value = False
                swpercefija.Enabled = False

                swgratificacion.Value = False
                swgratificacion.Enabled = False
                txtNumGratificacion.Value = 0
                cmbsueldograf.SelectedIndex = 0
            Else
                txtNetoFijo.Enabled = False
                txtNetoFijo.Text = FormatNumber("0", 2)
                swpercefija.Enabled = True

                swgratificacion.Value = False
                swgratificacion.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub swpercefija_ValueChanged(sender As Object, e As EventArgs) Handles swpercefija.ValueChanged
        Try

            If swpercefija.Value Then
                txtPerFija.Enabled = True
                swnetofijo.Value = False
                swnetofijo.Enabled = False

                swgratificacion.Value = False
                swgratificacion.Enabled = False
                txtNumGratificacion.Value = 0
                cmbsueldograf.SelectedIndex = 0
            Else
                txtPerFija.Enabled = False
                txtPerFija.Text = FormatNumber("0", 2)
                swnetofijo.Enabled = True


                swgratificacion.Value = False
                swgratificacion.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub swantiguedad_ValueChanged(sender As Object, e As EventArgs) Handles swantiguedad.ValueChanged
        If swantiguedad.Value Then
            cmbsueldoprima.Enabled = True
        Else
            cmbsueldoprima.Enabled = False
            cmbsueldoprima.SelectedIndex = 0
        End If
    End Sub

    Private Sub swgratificacion_ValueChanged(sender As Object, e As EventArgs) Handles swgratificacion.ValueChanged
        If swgratificacion.Value Then
            cmbsueldograf.Enabled = True
            txtNumGratificacion.Enabled = True
        Else
            cmbsueldograf.Enabled = False
            txtNumGratificacion.Value = 0
            cmbsueldograf.SelectedIndex = 0
            txtNumGratificacion.Enabled = False

        End If
    End Sub

    Private Sub swdiasano_ValueChanged(sender As Object, e As EventArgs) Handles swdiasano.ValueChanged
        If swdiasano.Value Then
            cmbsueldodias.Enabled = True
        Else
            cmbsueldodias.SelectedIndex = 1
            cmbsueldodias.Enabled = False
        End If
    End Sub

    Private Sub txtNetoFijo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNetoFijo.Validating
        Try

            If txtNetoFijo.Text.Trim = "" Then
                txtNetoFijo.Text = "0.00"
            Else
                txtNetoFijo.Text = FormatNumber(txtNetoFijo.Text, 2)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPerFija_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPerFija.Validating
        Try

            If txtPerFija.Text.Trim = "" Then
                txtPerFija.Text = "0.00"
            Else
                txtPerFija.Text = FormatNumber(txtPerFija.Text, 2)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BajaFiniquito_ValueChanged(sender As Object, e As EventArgs) Handles BajaFiniquito.ValueChanged

        If Not EsCargaIni Then

            EsCambioValor = True

        Else

            EsCambioValor = False
        End If

        sFechaFiniquito = FechaSQL(BajaFiniquito.Value)

        HabilitarFiniquito()


    End Sub

    Private Sub cmbPeriodos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPeriodos.SelectedValueChanged

        If Not EsCargaIni Then

            EsCambioValor = True

        Else

            EsCambioValor = False
        End If

        Try
            sUltimaNominaProcesada = Split(cmbPeriodos.Text, ",")(0)
        Catch ex As Exception
            sUltimaNominaProcesada = ""
        End Try


        HabilitarFiniquito()

    End Sub

    Private Sub HabilitarFiniquito()


        swComplemento.Enabled = Not Clave = "NVO" And Not Escomplemento

        btnCargaDef.Enabled = Not Clave = "NVO" Or EsCambioValor

        Panel4.Enabled = Not Clave = "NVO"

        Panel6.Enabled = Not Clave = "NVO"


        btnCalcular.Enabled = Not Clave = "NVO" And Not EsCambioValor


        btnCancelar.Enabled = Not Clave = "NVO"

    End Sub

    Private Sub btnCargaDef_Click(sender As Object, e As EventArgs) Handles btnCargaDef.Click
        Dim frm As New frmTrabajando
        Dim valor As Double = 0

        Try


            If cmbPeriodos.SelectedIndex < 0 Then
                MessageBox.Show("El periodo no ha sido cargado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPeriodos.Focus()
                Exit Sub
            ElseIf cmbPeriodos.SelectedIndex >= 0 And Clave.Trim = "EDIT" Then

                Try

                    dtPeriodos = NominaBase()

                    If dtPeriodos.Rows.Count > 0 Then

                        cmbPeriodos.DataSource = dtPeriodos
                        cmbPeriodos.ValueMember = "unico"
                        cmbPeriodos.DisplayMembers = "unico,año,periodo,fecha_ini,fecha_fin"

                        cmbPeriodos.SelectedIndex = 0
                    Else
                        sUltimaNominaProcesada = ""
                        cmbPeriodos.SelectedIndex = -1
                        Exit Sub
                    End If



                Catch ex As Exception
                    MessageBox.Show("Se presentó un error al intentar cargar el periodo de última nómina procesada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    sUltimaNominaProcesada = ""
                    cmbPeriodos.SelectedIndex = -1
                    cmbPeriodos.Focus()
                    Exit Sub
                End Try

            End If

            If cmbPeriodos.SelectedIndex < 0 Then
                MessageBox.Show("El periodo no ha sido cargado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPeriodos.Focus()
                Exit Sub
            End If

            If AltaEmp.ValueObject Is Nothing Then
                MessageBox.Show("Fecha de alta en blanco. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AltaEmp.Focus()
                Exit Sub
            End If


            If AntigEmp.ValueObject Is Nothing Then
                MessageBox.Show("Fecha de alta antiguedad en blanco. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AntigEmp.Focus()
                Exit Sub
            End If

            frm.Show()
            Application.DoEvents()

            If Not BajaFiniquito.ValueObject = Nothing Then

                If dtConcGrid.Rows.Count > 0 Then dtConcGrid.Clear()

                Application.DoEvents()
                DiasNormales1()

                Application.DoEvents()
                HorasExtras1()

                Application.DoEvents()
                lclCalculoDefaultConcepto(txtReloj.Text, BajaFiniquito.Value)

                'Application.DoEvents()
                'Prima_Vacacional1()

                'Application.DoEvents()
                'Proporcion_Aguinaldo1()

                'Application.DoEvents()
                'Vacaciones1()

                Application.DoEvents()
                Comedor()

                Application.DoEvents()
                Movimientos()

                Application.DoEvents()
                Asistencia()

                'Application.DoEvents()
                'DiasPrimaSabDom()

                'Application.DoEvents()
                'PermisoSinGoceSueldoHrs()

                'Application.DoEvents()
                'RetardosHrs()

                dtConcGrid.DefaultView.Sort = "concepto"

                Panel4.Enabled = True
                Panel6.Enabled = True
                btnCalcular.Enabled = True
            Else

                ActivoTrabajando = False
                frm.Close()
                MessageBox.Show("La fecha de finiquito no puede quedar en blanco. Favor de verificar", "Fecha de baja en blanco", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                BajaFiniquito.Focus()
                Panel4.Enabled = False
                Panel6.Enabled = False
                btnCalcular.Enabled = False
                Exit Sub


            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar cargar los conceptos principales", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Panel4.Enabled = False
            Panel6.Enabled = False
            btnCalcular.Enabled = False
        End Try

        dgvConceptos.ClearSelection()
        ActivoTrabajando = False
        frm.Close()

    End Sub

    Private Sub btnAgregaConcepto_Click(sender As Object, e As EventArgs) Handles btnAgregaConcepto.Click
        Dim frm As New frmTrabajando
        Dim strConcepto As String = ""
        Dim strDescripcion As String = ""
        Dim Bconcepto As Integer = 0
        Dim dtFactor As New DataTable
        Dim _factor As Double = 0
        Dim valor As Double = 0
        Dim tabla As String = ""

        Try

            If AltaEmp.ValueObject Is Nothing Then
                MessageBox.Show("Fecha de alta en blanco. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AltaEmp.Focus()
                Exit Sub
            End If


            If AntigEmp.ValueObject Is Nothing Then
                MessageBox.Show("Fecha de alta antiguedad en blanco. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AntigEmp.Focus()
                Exit Sub
            End If


            If BajaFiniquito.ValueObject = Nothing Then

                MessageBox.Show("La fecha de baja no pude estar vacía. Favor de verificar", "Fecha baja en blanco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            If cmbPeriodos.SelectedIndex < 0 Then
                MessageBox.Show("Debe seleccionar un periodo. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPeriodos.Focus()
                Exit Sub
            End If

            If cmbConceptos.SelectedIndex > -1 Then

                frm.Show()
                Application.DoEvents()

                strConcepto = Trim(Split(cmbConceptos.Text, ",")(0))
                strDescripcion = Trim(Split(cmbConceptos.Text, ",")(1))


                If strConcepto.Trim.StartsWith("DIA") Then

                    If TipoEmp.ToUpper.Trim = "O" Then
                        tabla = "ta.dbo.periodos"
                        'ElseIf TipoEmp.ToUpper.Trim = "A" Then
                        '    tabla = "ta.dbo.periodos_quincenal"
                    Else
                        tabla = "ta.dbo.periodos"
                    End If

                    dtFactor = sqlExecute(" declare @fechafiniquito char(10)" & vbCr &
                                      " set @fechafiniquito = '" & FechaSQL(BajaFiniquito.Value) & "'" & vbCr &
                                      "select factor " & vbCr &
                                      "from rol_horarios " & vbCr &
                                      "where cod_comp = '" & dtCompania.Rows(0).Item("cod_comp") & "' and cod_hora = '" & dtCompania.Rows(0).Item("cod_hora") & "' " & vbCr &
                                      "and (ano+periodo) = (select top 1 (ano+periodo) as periodo from " & tabla & " where (@fechafiniquito between FECHA_INI and FECHA_FIN) and (PERIODO_ESPECIAL is null or PERIODO_ESPECIAL = 0) order by ano desc, PERIODO desc)")

                    If dtFactor.Rows.Count > 0 Then
                        _factor = IIf(IsDBNull(dtFactor.Rows(0).Item("factor")), 0, dtFactor.Rows(0).Item("factor"))
                    Else
                        _factor = 0
                    End If

                Else
                    _factor = 0
                End If


                If dtConcGrid.Rows.Count > 0 Then

                    Bconcepto = dtConcGrid.AsEnumerable().Where(Function(conce) conce.Field(Of String)("concepto") = strConcepto).Count

                    If Bconcepto = 0 Then

                        Application.DoEvents()

                        Dim dtAgregar As DataTable = sqlExecute("select top 1 * from conceptos where concepto = '" & strConcepto.Trim & "'", "NOMINA")

                        If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then

                            Application.DoEvents()
                            Dim drFila As DataRow = dtConcGrid.NewRow

                            drFila("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                            drFila("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                            drFila("monto") = 0
                            drFila("factor") = _factor

                            dtConcGrid.Rows.Add(drFila)
                        Else

                            ActivoTrabajando = False
                            frm.Close()
                            MessageBox.Show("El concepto [" & strConcepto & "] no se pudo agragar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        End If

                        'Agrega_Concepto(strConcepto)
                        cmbConceptos.SelectedIndex = -1
                        dtConcGrid.DefaultView.Sort = "concepto"

                    ElseIf Bconcepto > 0 Then
                        ActivoTrabajando = False
                        frm.Close()
                        MessageBox.Show("El concepto [" & strConcepto & "] ya ha sido agregado para el cálculo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                Else

                    Application.DoEvents()

                    Dim dtAgregar As DataTable = sqlExecute("select top 1 * from conceptos where concepto = '" & strConcepto.Trim & "'", "NOMINA")

                    If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then

                        Application.DoEvents()
                        Dim drFila As DataRow = dtConcGrid.NewRow

                        drFila("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                        drFila("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                        drFila("monto") = 0
                        drFila("factor") = _factor

                        dtConcGrid.Rows.Add(drFila)

                    Else

                        ActivoTrabajando = False
                        frm.Close()
                        MessageBox.Show("El concepto [" & strConcepto & "] no se pudo agragar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    End If

                    ' Agrega_Concepto(strConcepto)
                    cmbConceptos.SelectedIndex = -1
                    dtConcGrid.DefaultView.Sort = "concepto"
                End If

                ActivoTrabajando = False
                frm.Close()

                Dim i As Integer = dtConcGrid.DefaultView.Find(strConcepto)

                dgvConceptos.ClearSelection()
                If i >= 0 Then
                    dgvConceptos.FirstDisplayedScrollingRowIndex = i
                    dgvConceptos.Rows(i).Selected = True
                End If

            Else

                MessageBox.Show("Debe seleccionar un concepto. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un error. Si el problema persiste contacte al administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

            ActivoTrabajando = False
            frm.Close()
        End Try
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles EliminaConce.Click

        Dim strunico As String = ""
        Dim strperfol As String = ""
        Dim strconcepto As String = ""
        Dim Eliminar As New ArrayList
        Dim cadena As String = ""
        Dim i As Integer = 0
        Dim dtExiste As New DataTable

        Try

            'strperfol = Trim(cmbPeriodos.SelectedValue) & Trim(IIf(txtFolio.Text = "", "0", txtFolio.Text))

            strperfol = Trim(cmbPeriodos.SelectedValue)

            If dgvConceptos.Rows.Count > 0 Then

                Dim NumConSel As Integer = dgvConceptos.SelectedRows.Count

                If NumConSel > 0 Then

                    Dim respuesta As DialogResult = MessageBox.Show("Los conceptos seleccionados serán eliminados para el cálculo. ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                    If respuesta = Windows.Forms.DialogResult.Yes Then

                        cadena = "in("

                        For Each dgvRow As DataGridViewRow In dgvConceptos.SelectedRows

                            strconcepto = Trim(dgvRow.Cells(0).Value)
                            strunico = strperfol & strconcepto

                            cadena = cadena & "'" & strconcepto & "'" & IIf(i = (NumConSel - 1), "", ",")
                            i = i + 1

                        Next

                        cadena &= ")"

                        'If Not sqlExecute("delete from ajustes_tmp where (ano+periodo) = '" & strperfol & "' and folio = '" & txtFolio.Text.Trim & "' and ltrim(rtrim(concepto)) " & cadena, "NOMINA").Columns.Contains("ERROR") Then

                        Try

                            Dim Copia As DataTable = DirectCast(dgvConceptos.DataSource, DataTable)

                            Dim drRows() As DataRow = Copia.Select("concepto " & cadena)

                            For Each Row As DataRow In drRows

                                Copia.Rows.Remove(Row)

                            Next

                        Catch ex As Exception
                            MessageBox.Show("Error al intentar eliminar los conceptos seleccionados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try

                        'Else

                        '    MessageBox.Show("Error al intentar eliminar los conceptos seleccionados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        'End If


                    End If

                Else
                    MessageBox.Show("No se ha seleccionado algún concepto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If



            Else
                MessageBox.Show("No hay conceptos para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar eliminar concepto(s)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    '--- TEST 2023-12-19
    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click

        Dim frm As New frmTrabajando
        Dim dtExiste As New DataTable
        Dim dtInfonavit As New DataTable
        Dim infonavit As String = ""
        Dim tipo_credito As String = ""
        Dim cuota_credito As Double = 0
        Dim strsql As String = ""
        Dim _aplica_ajuste As Integer = 0
        Dim _tipo_ajuste As String = ""
        Dim _cantidad As Double = 0
        Dim valor As Double = 0
        Dim continuar As Boolean = False

        Try

            If Val(txtFolio.Text.Trim) = 0 Then
                MessageBox.Show("Folio no asignado. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If AltaEmp.ValueObject Is Nothing Then
                MessageBox.Show("Fecha de alta en blanco. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AltaEmp.Focus()
                Exit Sub
            End If


            If AntigEmp.ValueObject Is Nothing Then
                MessageBox.Show("Fecha de alta antiguedad en blanco. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AntigEmp.Focus()
                Exit Sub
            End If


            If BajaFiniquito.ValueObject Is Nothing Then
                MessageBox.Show("Fecha de finiquito en blanco. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                BajaFiniquito.Focus()
                Exit Sub
            End If

            If cmbPeriodos.SelectedIndex < 0 Then
                MessageBox.Show("Debe seleccionar un periodo. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPeriodos.Focus()
                Exit Sub
            End If

            If Not dgvConceptos.Rows.Count > 0 Then

                MessageBox.Show("Para el cálculo debe existir al menos un concepto. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub

            End If

            If swnetofijo.Value Or swpercefija.Value Then
                _aplica_ajuste = 1

                If swnetofijo.Value Then

                    _tipo_ajuste = "N"

                    valor = IIf(txtNetoFijo.Text.Trim = "", 0, txtNetoFijo.Text.Trim)

                    If valor <= 0 Then
                        MessageBox.Show("Debe ingresar un valor mayor de cero para NETO FIJO.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txtNetoFijo.Focus()
                        Exit Sub
                    Else
                        _cantidad = txtNetoFijo.Text
                        _cantidad = Math.Round(_cantidad, 2)
                    End If

                ElseIf swpercefija.Value Then

                    _tipo_ajuste = "P"

                    valor = IIf(txtPerFija.Text.Trim = "", 0, txtPerFija.Text.Trim)

                    If valor <= 0 Then
                        MessageBox.Show("Debe ingresar un valor mayor de cero para PERCEPCIÓN FIJA.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txtPerFija.Focus()
                        Exit Sub
                    Else
                        _cantidad = txtPerFija.Text
                        _cantidad = Math.Round(_cantidad, 2)
                    End If

                End If
            Else

                _aplica_ajuste = 0
                _tipo_ajuste = ""
                _cantidad = 0

            End If


            dtExiste = sqlExecute("select top 1 * from nomina_calculo where folio = '" & txtFolio.Text.Trim & "' and reloj = '" & txtReloj.Text.Trim & "' ", "NOMINA")

            If Not dtExiste.Columns.Contains("ERROR") Then


                If Not dtExiste.Rows.Count > 0 Then

                    Dim dtFactor As New DataTable
                    Dim _factor As Double = 0

                    dtFactor = sqlExecute("select factor from rol_horarios where cod_comp = '" & dtCompania.Rows(0).Item("cod_comp") & "' and cod_hora = '" & dtCompania.Rows(0).Item("cod_hora") & "' and (ano+periodo) = '" & Trim(cmbPeriodos.SelectedValue) & "'")

                    If dtFactor.Rows.Count > 0 Then

                        _factor = IIf(IsDBNull(dtFactor.Rows(0).Item("factor")), 1, dtFactor.Rows(0).Item("factor"))

                    Else

                        _factor = 0

                    End If

                    dtInfonavit = sqlExecute("select top 1 reloj,infonavit,tipo_cre,pago_inf from personal where reloj = '" & txtReloj.Text.Trim & "' and credito_in = 1")

                    If dtInfonavit.Rows.Count > 0 Then

                        infonavit = Trim(IIf(IsDBNull(dtInfonavit.Rows(0).Item("infonavit")), "", dtInfonavit.Rows(0).Item("infonavit")))
                        tipo_credito = Trim(IIf(IsDBNull(dtInfonavit.Rows(0).Item("tipo_cre")), "", dtInfonavit.Rows(0).Item("tipo_cre")))
                        cuota_credito = IIf(IsDBNull(dtInfonavit.Rows(0).Item("pago_inf")), 0, dtInfonavit.Rows(0).Item("pago_inf"))
                    Else

                        infonavit = ""
                        tipo_credito = ""
                        cuota_credito = 0

                    End If

                    strsql = "SET IDENTITY_INSERT [nomina_calculo] ON;"
                    strsql &= " insert into nomina_calculo ([status],folio,periodo,ano,cod_comp,reloj,nombres,sactual,integrado,alta,baja_fin,alta_antig,cod_puesto,puesto,cod_tipo,"
                    strsql &= "prima_antig,tipo_sdo_antig,gratificacion,tipo_sdo_grati,dias_grati,[20diasano],tipo_sdo_rest,vales_despensa,sindicalizado,infonavit_credito,cuota_credito,tipo_credito,captura,usuario,aplica_ajuste,tipo_ajuste,cantidad,cod_depto,cod_turno,cod_super,cod_hora,cod_clase,cod_planta,tipo_periodo,complemento,comp_folio,factor_dias)"
                    strsql &= " select 'EN PROCESO' as [status],'" & txtFolio.Text.Trim & "' as folio, '" & Trim(Split(cmbPeriodos.Text, ",")(2)) & "' as periodo, '" & Trim(Split(cmbPeriodos.Text, ",")(1)) & "' as ano, cod_comp,reloj,nombres,sactual,integrado,"
                    strsql &= " '" & FechaSQL(AltaEmp.ValueObject) & "' as alta, '" & FechaSQL(BajaFiniquito.Value) & "' as baja_fin,'" & IIf(AntigEmp.ValueObject = Nothing, FechaSQL(AltaEmp.ValueObject), FechaSQL(AntigEmp.ValueObject)) & "' as alta_antig,"
                    strsql &= "cod_puesto, rtrim(isnull(nombre_puesto,'')) as puesto ,cod_tipo, " & IIf(swantiguedad.Value, 1, 0) & " as prima_antig, '" & cmbsueldoprima.Text.Trim & "' as tipo_sdo_antig, " & IIf(swgratificacion.Value, 1, 0) & " as gratificacion,'" & cmbsueldograf.Text.Trim & "' as tipo_sdo_grati, " & txtNumGratificacion.Value & " as dias_grati,"
                    strsql &= "" & IIf(swdiasano.Value, 1, 0) & " as [20diasano], '" & cmbsueldodias.Text.Trim & "' as tipo_sdo_rest, " & IIf(swdespensa.Value, 1, 0) & " as vales_despensa,sindicalizado, '" & infonavit & "' as infonavit_credito, " & cuota_credito & " as cuota_credito, '" & tipo_credito & "' as tipo_credito,getdate(),'" & Usuario & "' as usuario, " & _aplica_ajuste & " as aplica_ajuste,'" & _tipo_ajuste & "' as tipo_ajuste, " & _cantidad & " as cantidad,"
                    strsql &= " isnull(cod_depto,'') as cod_depto,isnull(cod_turno,'') as cod_turno,isnull(cod_super,'') as cod_super,isnull(cod_hora,'') as cod_hora,isnull(cod_clase,'') as cod_clase, isnull(cod_planta,'') as cod_planta,isnull(tipo_periodo,'') as tipo_periodo, " & IIf(swComplemento.Value, 1, 0) & " as complemento,'" & folioAnt.Trim & "' as comp_folio," & _factor & " as factor_dias"
                    strsql &= " from personal.dbo.personalvw where reloj = '" & txtReloj.Text.Trim & "'"
                    strsql &= " SET IDENTITY_INSERT [nomina_calculo] OFF;"


                    If sqlExecute(strsql, "NOMINA").Columns.Contains("ERROR") Then

                        MessageBox.Show("No se pudo realizar la alta de finiquito del empleado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Else

                    strsql = "update nomina_calculo set [status] = 'EN PROCESO',neto = 0,sactual = " & dtCompania.Rows(0).Item("sactual") & ",integrado = " & dtCompania.Rows(0).Item("integrado") & ",ano ='" & Trim(Split(cmbPeriodos.Text, ",")(1)) & "',periodo = '" & Trim(Split(cmbPeriodos.Text, ",")(2)) & "',baja_fin = '" & FechaSQL(BajaFiniquito.Value) & "',prima_antig = " & IIf(swantiguedad.Value, 1, 0) & ",tipo_sdo_antig = '" & cmbsueldoprima.Text.Trim & "',"
                    strsql &= "gratificacion = " & IIf(swgratificacion.Value, 1, 0) & ",dias_grati = " & txtNumGratificacion.Value & ",tipo_sdo_grati = '" & cmbsueldograf.Text.Trim & "',[20diasano] = " & IIf(swdiasano.Value, 1, 0) & ",tipo_sdo_rest = '" & cmbsueldodias.Text.Trim & "',vales_despensa = " & IIf(swdespensa.Value, 1, 0) & ","
                    strsql &= "aplica_ajuste = " & _aplica_ajuste & ",tipo_ajuste = '" & _tipo_ajuste & "',cantidad = " & _cantidad & ",fhacalculo = getdate(),usrcalculo = '" & Usuario & "', alta = '" & FechaSQL(AltaEmp.ValueObject) & "', alta_antig = '" & FechaSQL(AntigEmp.ValueObject) & "' where folio = '" & txtFolio.Text.Trim & "' and reloj ='" & txtReloj.Text.Trim & "'"

                    If sqlExecute(strsql, "NOMINA").Columns.Contains("ERROR") Then
                        MessageBox.Show("No se pudo actualizar los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    If sqlExecute("delete from movimientos_calculo where folio = '" & txtFolio.Text.Trim & "' and reloj = '" & txtReloj.Text.Trim & "' ", "NOMINA").Columns.Contains("ERROR") Then
                        MessageBox.Show("Se presentó un error al recalcular el finiquito especial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    If sqlExecute("delete from ajustes_tmp where folio = '" & txtFolio.Text.Trim & "' and reloj = '" & txtReloj.Text.Trim & "' ", "NOMINA").Columns.Contains("ERROR") Then
                        MessageBox.Show("Se presentó un error al recalcular el finiquito especial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                End If

            Else
                MessageBox.Show("No se pudo realizar la captura de finiquito del empleado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            frm.Show()
            Application.DoEvents()

            For Each dgvRow As DataGridViewRow In dgvConceptos.Rows

                Application.DoEvents()


                If Not dgvRow.Cells("ColMonto").Value = 0 Then
                    If Not InsertarConceptoAjustes(Trim(Split(cmbPeriodos.Text, ",")(1)), Trim(Split(cmbPeriodos.Text, ",")(2)), txtFolio.Text.Trim, txtReloj.Text.Trim, dgvRow.Cells("ColConcepto").Value, dgvRow.Cells("ColDescripcion").Value, dgvRow.Cells("ColMonto").Value, IIf(IsDBNull(dgvRow.Cells("ColFactor").Value), 0, dgvRow.Cells("ColFactor").Value)) Then
                        MessageBox.Show("No se pudo realizar la captura completa de conceptos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        continuar = False
                        Exit For
                    Else
                        continuar = True
                    End If

                End If

            Next

            If continuar Then

                Application.DoEvents()

                If sqlExecute("exec calculoCTE '" & txtFolio.Text.Trim & "','" & txtReloj.Text.Trim & "'", "NOMINA").Columns.Contains("ERROR") Then
                    MessageBox.Show("No se pudo realizar el calculo del finiquito", "Error calculo finiquito", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ActivoTrabajando = False
                    frm.Close()
                    Exit Sub
                End If

                Application.DoEvents()

                '*** Verificar si el ajuste es al NETO, de ser asi se realiza
                '*** el procedimiento de ajuste ya que no es diercto como el ajuste a la percepcion
                '*** la cual está incluida dentro del store procedure calculo

                If _tipo_ajuste.Trim.ToUpper = "N" Then AjusteNetoTest(_cantidad)

                Application.DoEvents()
                If (swComplemento.Value And Not folioAnt.Trim = "") Or Escomplemento Then Complemento()

                Application.DoEvents()

                sqlExecute("declare @_folio int = '" & txtFolio.Text.Trim & "'" & vbCr &
                          "declare @_reloj varchar(max) = '" & txtReloj.Text.Trim & "'" & vbCr &
                          "declare @_monto decimal(12,2) = convert(decimal(12,2),coalesce((select top 1 monto from movimientos_calculo where concepto = 'NETO' and folio = @_folio and reloj = @_reloj),0))" & vbCr &
                          "update nomina_calculo set  [status] = 'CALCULADO' , neto = @_monto  where folio = @_folio and reloj = @_reloj", "NOMINA")

                ActivoTrabajando = False
                frm.Close()

                'With sqlExecute("select * from nomina_calculo where folio = '" & txtFolio.Text.Trim & "' and reloj = '" & txtReloj.Text.Trim & "' and neto <> 0 and [status] <> 'EN PROCESO'", "NOMINA")
                With sqlExecute("select * from nomina_calculo where folio = '" & txtFolio.Text.Trim & "' and reloj = '" & txtReloj.Text.Trim & "' and [status] <> 'EN PROCESO'", "NOMINA")
                    If .Columns.Contains("ERROR") Then
                        MessageBox.Show("Se presentó un problema al intentar mostrar el reporte de finiquito especial", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ElseIf Not .Rows.Count > 0 Then
                        MessageBox.Show("No se generará el reporte de finiquito especial ya que se detectó que está 'EN PROCESO'.", "Finiquito no calculado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Else
                        GenerarReporteFiniquito()
                    End If

                End With

            Else

                ActivoTrabajando = False
                frm.Close()

            End If

        Catch ex As Exception
            ActivoTrabajando = False
            frm.Close()
            MessageBox.Show("Se presentó un error al intentar realizar el calculo de finiquito", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgvConceptos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvConceptos.DataError
        Try
            dgvConceptos.Rows(e.RowIndex).ErrorText = "El monto debe ser numérico. Favor de verificar."
            MessageBox.Show("El monto debe ser numérico. Favor de verificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvConceptos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConceptos.CellEndEdit

        Try
            Dim row As DataGridViewRow = dgvConceptos.CurrentRow

            Dim value As Object = row.Cells("ColMonto").Value

            If Convert.ToString(value) = String.Empty Then
                row.Cells("ColMonto").Value = 0
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Dim respuesta As DialogResult

        respuesta = MessageBox.Show("Esta acción cancelará el finiquito. ¿Desea continuar?", "Cancelación de finiquito", MessageBoxButtons.YesNo)

        If Not respuesta = Windows.Forms.DialogResult.Yes Then Exit Sub

        If Val(txtFolio.Text.Trim) = 0 Then
            MessageBox.Show("El Folio no pude estar en blanco", "Folio no asigando", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If sqlExecute("update nomina_calculo set [status] = 'CANCELADO' where folio = '" & txtFolio.Text.Trim & "' and reloj = '" & txtReloj.Text.Trim & "' ", "NOMINA").Columns.Contains("ERROR") Then

            MessageBox.Show("No se pudo cancelar el finiquito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MessageBox.Show("El finiquito ha sido cancelado", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub swComplemento_ValueObjectChanged(sender As Object, e As EventArgs) Handles swComplemento.ValueObjectChanged

        Dim dtExiste As New DataTable

        Try

            If swComplemento.Value Then

                If Not MessageBox.Show("Se creará un nuevo folio con las condiciones del cálculo anterior. ¿Desea continuar?", "Complemento del folio '" & txtFolio.Text.Trim & "'", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    folioAnt = ""
                    swComplemento.Value = False
                    Exit Sub
                End If

                dtExiste = sqlExecute("select top 1 * from nomina_calculo where folio = '" & txtFolio.Text.Trim & "' and reloj = '" & txtReloj.Text.Trim & "'", "NOMINA")

                If Not dtExiste.Rows.Count > 0 Then
                    MessageBox.Show("El folio '" & txtFolio.Text.Trim & "' no existe en finiquitos, por lo cual no se generará el complemento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    folioAnt = ""
                    swComplemento.Value = False
                    Exit Sub
                Else
                    folioAnt = txtFolio.Text.Trim
                    AsignarFolio()
                    '   Complemento()
                End If

            Else

                If Not folioAnt.Trim = "" Then
                    txtFolio.Text = folioAnt.Trim
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al tratar de crear un folio al complemento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            folioAnt = ""
            InfoBlanco()

        End Try


    End Sub

    Private Sub txtNetoFijo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNetoFijo.KeyPress
        Dim numero As Double = 0
        Dim valor As String = ""

        Try

            If e.KeyChar = Convert.ToChar(Keys.Back) Then
                Exit Sub
            ElseIf e.KeyChar = Convert.ToChar(Keys.Space) Then
                e.KeyChar = ""
                Exit Sub
            End If

            valor = txtNetoFijo.Text & e.KeyChar

            If Not Double.TryParse(valor, numero) Then
                e.KeyChar = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPerFija_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPerFija.KeyPress
        Dim numero As Double = 0
        Dim valor As String = ""

        Try

            If e.KeyChar = Convert.ToChar(Keys.Back) Then
                Exit Sub
            ElseIf e.KeyChar = Convert.ToChar(Keys.Space) Then
                e.KeyChar = ""
                Exit Sub
            End If

            valor = txtPerFija.Text & e.KeyChar

            If Not Double.TryParse(valor, numero) Then
                e.KeyChar = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AltaEmp_ValueObjectChanged(sender As Object, e As EventArgs) Handles AltaEmp.ValueObjectChanged

        If Not EsCargaIni Then

            EsCambioValor = True

        Else

            EsCambioValor = False

        End If

        HabilitarFiniquito()

    End Sub

    Private Sub AntigEmp_ValueObjectChanged(sender As Object, e As EventArgs) Handles AntigEmp.ValueObjectChanged

        If Not EsCargaIni Then

            EsCambioValor = True

        Else

            EsCambioValor = False
        End If


        HabilitarFiniquito()
    End Sub

    Private Sub lclCalculoDefaultConcepto(ByVal Rj As String, ByVal FBaja As Date)
        Try

            Dim valor As String = FechaSQL(FBaja)
            Dim ExistsDIASVA As Integer = 0
            Dim ExistsDIASPV As Integer = 0
            Dim ExistsDIASAG As Integer = 0

            If (Rj <> "" And valor <> "") Then

                Dim dtEmp As New DataTable
                dtEmp = sqlExecute("SELECT '" & FechaSQL(AltaEmp.Value) & "' as alta,baja,cod_comp,ISNULL(cod_tipo,'') AS cod_tipo,ISNULL(tipo_periodo,'') AS tipo_periodo FROM personal WHERE reloj = '" & Rj & "'")

                '*****************Días de vacaciones
                Dim saldo_dinero As Double = 0.0
                Dim saldo_devengado As Double = 0.0
                Dim DiasVac As Double = 0.0
                Dim QSaldoDin As String = "SELECT TOP 1 saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE comentario not in('BAJA') AND reloj = '" & Rj.Trim &
                          "' ORDER BY fecha_captura DESC,fecha_fin DESC"
                Dim dtSaldoDin As DataTable = sqlExecute(QSaldoDin, "PERSONAL")

                If ((dtSaldoDin.Columns.Contains("Error")) Or (Not dtSaldoDin.Columns.Contains("Error") And dtSaldoDin.Rows.Count = 0)) Then
                    saldo_dinero = 0.0
                    GoTo CalcSaldoDev
                End If
                saldo_dinero = IIf(IsDBNull(dtSaldoDin.Rows(0).Item("saldo_dinero")), 0.0, dtSaldoDin.Rows(0).Item("saldo_dinero"))
CalcSaldoDev:
                '   saldo_devengado = VacacionesDevengadas(Rj.Trim, FBaja)
                saldo_devengado = CalculoDAgDVacDPrVac(dtEmp.Rows(0).Item("alta"), FBaja, dtEmp.Rows(0).Item("cod_tipo"), dtEmp.Rows(0).Item("cod_comp"), 1)
                DiasVac = Math.Round(saldo_dinero + saldo_devengado, 2)

                '******************Dias de prima vacacional
                Dim dias_prima_vac As Double = 0.0
                dias_prima_vac = CalculoDAgDVacDPrVac(dtEmp.Rows(0).Item("alta"), FBaja, dtEmp.Rows(0).Item("cod_tipo"), dtEmp.Rows(0).Item("cod_comp"), 2)

                '--La sig func es para los casos cuando se paga el finiquito y de acuerdo a la FBaja, la Fecha de aniv cae en ese rango, es decir, aun no se le paga, y la funcion hace que se le pague lo que le corresponde por aniv, mas
                '--la parte proporcional de prima que le toca despues de su aniv, por lo que a horita con la func de arriba, solo se  le paga esta parte propr de prima pero no toma en cuenta si se le pagó ya por aniv
                '  dias_prima_vac = CalcPrimaVacacional(Rj.Trim, dtEmp.Rows(0).Item("alta"), FBaja, dtEmp.Rows(0).Item("cod_tipo"), dtEmp.Rows(0).Item("cod_comp"), dtEmp.Rows(0).Item("tipo_periodo")) '2021-10-13 Nueva Funcion Luis Andrade para vacaciones de aniv ya pagadas


                '-----Días de Aguinaldo
                Dim dias_Aguinaldo As Double = 0.0
                dias_Aguinaldo = CalculoDAgDVacDPrVac(dtEmp.Rows(0).Item("alta"), FBaja, dtEmp.Rows(0).Item("cod_tipo"), dtEmp.Rows(0).Item("cod_comp"), 3)

                '--- Obtener periodo y empleados de nomina de aguinaldo pagada
                Dim QPerAgui As String = "select * from periodos where ano='" & Year(FBaja) & "' and observaciones like '%aguinaldo%' and PERIODO_ESPECIAL=1"
                Dim QNomAguiPag As String = ""
                Dim per_agui_pag As String = ""
                Dim dtPerAguiPag As DataTable = sqlExecute(QPerAgui, "TA")
                Dim dtEmplAguiPag As New DataTable

                If (Not dtPerAguiPag.Columns.Contains("Error") And dtPerAguiPag.Rows.Count > 0) Then
                    Try : per_agui_pag = dtPerAguiPag.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per_agui_pag = "" : End Try

                    QNomAguiPag = "select * from movimientos where ano+periodo='" & Year(FBaja) & per_agui_pag & "' and concepto='PERAGI' and monto<>0 "
                    dtEmplAguiPag = sqlExecute(QNomAguiPag, "NOMINA")
                End If

                Dim aguiPag As Integer = 0

                If dtEmplAguiPag.Rows.Count > 0 Then
                    If (dtEmplAguiPag.Select("reloj='" & Rj.Trim & "'").Count > 0) Then aguiPag = 1
                End If

                If (aguiPag = 1) Then dias_Aguinaldo = 0

                '---------------------------------------

                Dim dtCopia As New DataTable

                Try
                    dtCopia = DirectCast(dgvConceptos.DataSource, DataTable)
                    Dim dtAgregar As New DataTable

                    If dtCopia.Rows.Count > 0 Then

                        ExistsDIASVA = dtCopia.AsEnumerable().Where(Function(conce) conce.Field(Of String)("concepto") = "DIASVA").Count()
                        ExistsDIASPV = dtCopia.AsEnumerable().Where(Function(conce) conce.Field(Of String)("concepto") = "DIASPV").Count()
                        ExistsDIASAG = dtCopia.AsEnumerable().Where(Function(conce) conce.Field(Of String)("concepto") = "DIASAG").Count()

                    End If

                    If DiasVac <> 0 Then

                        If Not ExistsDIASVA > 0 Then

                            dtAgregar = sqlExecute("select top 1 * from conceptos where concepto = 'DIASVA'", "NOMINA")
                            If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then

                                Dim drAgregar As DataRow = dtCopia.NewRow
                                drAgregar("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                                drAgregar("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                                drAgregar("monto") = DiasVac
                                drAgregar("factor") = 0

                                dtCopia.Rows.Add(drAgregar)

                            End If

                        Else

                            Dim drConcepto As DataRow = dtCopia.Select("concepto = 'DIASVA'")(0)
                            drConcepto("monto") = DiasVac
                        End If

                    End If

                    If DiasVac <> 0 Then

                        If Not ExistsDIASPV > 0 Then

                            dtAgregar = sqlExecute("select top 1 * from conceptos where concepto = 'DIASPV'", "NOMINA")
                            If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then

                                Dim drAgregar As DataRow = dtCopia.NewRow
                                drAgregar("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                                drAgregar("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                                drAgregar("monto") = DiasVac
                                drAgregar("factor") = 0

                                dtCopia.Rows.Add(drAgregar)

                            End If

                        Else

                            Dim drConcepto As DataRow = dtCopia.Select("concepto = 'DIASPV'")(0)
                            drConcepto("monto") = DiasVac
                        End If

                    End If

                    If dias_Aguinaldo <> 0 Then

                        If Not ExistsDIASAG > 0 Then
                            dtAgregar = sqlExecute("select top 1 * from conceptos where concepto = 'DIASAG'", "NOMINA")
                            If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then

                                Dim drAgregar As DataRow = dtCopia.NewRow
                                drAgregar("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                                drAgregar("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                                drAgregar("monto") = dias_Aguinaldo
                                drAgregar("factor") = 0

                                dtCopia.Rows.Add(drAgregar)

                            End If
                        Else
                            Dim drConcepto As DataRow = dtCopia.Select("concepto = 'DIASAG'")(0)
                            drConcepto("monto") = dias_Aguinaldo
                        End If

                    ElseIf aguiPag = 1 Then

                        Dim drConcepto As DataRow = Nothing
                        Try : drConcepto = dtCopia.Select("concepto = 'DIASAG'")(0) : Catch ex As Exception : drConcepto = Nothing : End Try

                        If Not drConcepto Is Nothing Then
                            dtCopia.Rows.Remove(drConcepto)
                        End If

                    End If


                    dgvConceptos.Refresh()

                Catch ex As Exception

                End Try

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class