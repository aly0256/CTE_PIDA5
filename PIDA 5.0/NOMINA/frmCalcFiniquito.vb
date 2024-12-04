Public Class frmCalcFiniquito

#Region "Declaraciones"

    Dim dtRegistro As New DataTable
    Dim dtFiniquitos As New DataTable
    Dim dtLista As New DataTable
    Dim dtMulitSelSemana As New DataTable
    Dim dtMulitSelCompleto As New DataTable
    Dim dtMulitSelCatorcena As New DataTable
    Dim dtPeriodosAsentado As New DataTable
    Dim dtPeriodoActual As New DataTable

    Dim switchActivo As Boolean = False
    Dim CambioSel As Boolean = False
    Dim strSQLista As String = ""

    Public Folio As String = ""
    Public FolioSgv As String = ""
    Public Bandera As String = ""
    Public FolioCapturado As String = ""
    Public FolioSeleccionado As String = ""
    Public finCancelado As Boolean = False
    Private EscargaInicial As Boolean = True
    Private ClickFila As Boolean = False

    ' Public _cod_comp As String = ""

    'Dim swIntercambio As Boolean

    'Structure InfoEmpFiniquito

    '    Dim cod_comp As String
    '    Dim uma As String
    '    Dim rl As String
    '    Dim folio As String
    '    Dim nombre As String
    '    Dim alta As String
    '    Dim baja As String
    '    Dim alta_antig As String
    '    Dim salario_diario As Double
    '    Dim integrado As Double
    '    Dim cod_tipo As String
    '    Dim cod_clase As String
    '    Dim sindicalizado As Integer
    '    Dim cod_planta As String
    '    Dim planta As String
    '    Dim cod_depto As String
    '    Dim depto As String
    '    Dim cod_turno As String
    '    Dim turno As String
    '    Dim cod_super As String
    '    Dim cod_hora As String
    '    Dim hora As String
    '    Dim tipo_perido As String

    'End Structure


#End Region

    Private Sub MostrarInformacion(ByVal rl As String)

        Dim dRow As DataRow
        Dim EsBajaLocal As Boolean = False
        Try


            dtRegistro = sqlExecute("select * from personalvw where reloj = '" & rl & "' ")

            If Not dtRegistro.Rows.Count > 0 Then Exit Sub

            dRow = dtRegistro.Rows(0)

            txtReloj.Text = Trim(IIf(IsDBNull(dRow("reloj")), "", dRow("reloj")))
            txtNombre.Text = Trim(IIf(IsDBNull(dRow("nombres")), "", dRow("nombres")))
            txtHorario.Text = Trim(IIf(IsDBNull(dRow("cod_hora")), "", dRow("cod_hora"))) & _
            Trim(IIf(IsDBNull(dRow("nombre_horario")), "", " (" & dRow("nombre_horario").ToString.Trim & ") "))
            txtAlta.Text = IIf(IsDBNull(dRow("alta")), "------", dRow("alta"))
            txtBaja.Text = IIf(IsDBNull(dRow("baja")), "------", dRow("baja"))
            txtAntig.Text = IIf(IsDBNull(dRow("alta_vacacion")), txtAlta.Text, dRow("alta_vacacion"))
            txtTipoEmp.Text = Trim(IIf(IsDBNull(dRow("cod_tipo")), "", dRow("cod_tipo").ToString.Trim) & IIf(IsDBNull(dRow("nombre_tipoemp")), "", " (" & dRow("nombre_tipoemp").ToString.Trim & ")"))
            txtPuesto.Text = Trim(IIf(IsDBNull(dRow("nombre_puesto")), "", dRow("nombre_puesto").ToString.Trim))

            '*** Cambios en bajas ****
            Try
                EsBajaLocal = txtBaja.Text <> "------"
            Catch ex As Exception
                EsBajaLocal = False

            Finally
                lblEstado.Text = IIf(EsBajaLocal, "INACTIVO", "ACTIVO")
                lblEstado.BackColor = IIf(EsBajaLocal, Color.IndianRed, Color.LimeGreen)
                txtReloj.BackColor = lblEstado.BackColor
                lblEstado.Visible = True
            End Try
            '*************************

            'dtFiniquitos = sqlExecute("select [Status] as 'Status',ano,Periodo,Folio,alta,alta_antig,baja_finqto,Usuario,Captura,round(isnull(Neto,0),2) as Neto,Prima_Antig,Gratificacion,[20diasano],vales_despensa from nomina_calculo where reloj = '" & dRow("reloj") & "' ", "NOMINA")
            dtFiniquitos = sqlExecute("select [Status] as 'Status',ano,Periodo,Folio,alta,alta_antig,baja_fin,Usuario,Captura,isnull(Neto,0) as Neto,Prima_Antig,Gratificacion,isnull(dias_grati,0) as dias_grati,[20diasano],vales_despensa,isnull(asentado_deposito,0) as 'Ase_Dep',isnull(ano_asent_dep,'') as ano_asent_dep,isnull(per_asent_dep,'') as per_asent_dep,isnull(asentado_poliza,0) as 'Ase_Pol' from nomina_calculo where reloj = '" & dRow("reloj") & "' ", "NOMINA")
            dtFiniquitos.DefaultView.Sort = "folio"

            dgvFiniquitos.DataSource = dtFiniquitos

            If dgvFiniquitos.Rows.Count > 0 Then

                If Not FolioSgv.Trim = "" Then

                    Dim i As Integer = dtFiniquitos.DefaultView.Find(FolioSgv.Trim)

                    If i >= 0 Then

                        dgvFiniquitos.FirstDisplayedScrollingRowIndex = i
                        dgvFiniquitos.Rows(i).Selected = True
                        dgvFiniquitos.CurrentCell = dgvFiniquitos.Rows(i).Cells(0)

                    End If

                ElseIf Not FolioSeleccionado.Trim = "" And FolioSeleccionado.Trim <> "ERROR" Then

                    Dim i As Integer = dtFiniquitos.DefaultView.Find(FolioSeleccionado.Trim)
                    If i >= 0 Then
                        dgvFiniquitos.FirstDisplayedScrollingRowIndex = i
                        dgvFiniquitos.Rows(i).Selected = True
                        dgvFiniquitos.CurrentCell = dgvFiniquitos.Rows(i).Cells(0)
                    End If

                End If

                Dim dtCopia As New DataTable
                Dim drFolioCapturado As DataRow = Nothing
                Dim dtAgregar As New DataTable
                Dim FolEncontrado As Integer = -1

                Dim EsError As Boolean = False

                If FolioCapturado.Trim <> "" And FolioCapturado.Trim <> "ERROR" Then

                    Try : dtCopia = DirectCast(sdgFiniquitos.PrimaryGrid.DataSource, DataTable) : Catch : EsError = True : End Try

                    If Not EsError Then

                        dtAgregar = sqlExecute("select  0 as seleccionado, [Status] as estado,ano,Periodo,Folio,Reloj,Nombres, cod_tipo,tipo_periodo,isnull(ano_asent_dep,'') as ano_asent_dep,isnull(per_asent_dep,'') as per_asent_dep," & vbCr & _
                        " cod_puesto,alta,alta_antig,baja_fin,convert(decimal(38,2),isnull(Neto,0)) as Neto, Prima_Antig,Gratificacion,isnull(dias_grati,0) as dias_grati,[20diasano],vales_despensa," & vbCr & _
                        " isnull(asentado_deposito,0) as 'Deposito',isnull(asentado_poliza,0) as 'Poliza',Usuario,Captura,isnull(complemento,0) as complemento" & vbCr & _
                        " from nomina_calculo where folio = '" & FolioCapturado.Trim & "' and reloj = '" & txtReloj.Text.Trim & "'", "NOMINA")

                        Try : drFolioCapturado = dtAgregar.Select("folio = '" & FolioCapturado.Trim & "' and reloj = '" & txtReloj.Text.Trim & "'")(0) : Catch : drFolioCapturado = Nothing : End Try

                        If Not IsNothing(drFolioCapturado) Then

                            Try : FolEncontrado = IIf(dtCopia.Select("folio = '" & FolioCapturado.Trim & "' and reloj = '" & txtReloj.Text.Trim & "'").Count > 0, 1, 0) : Catch : EsError = True : End Try

                            If Not EsError Then

                                If FolEncontrado > 0 Then 'Si existe
                                    Dim drBuscar As DataRow = Nothing
                                    Dim drInsertar As DataRow = Nothing

                                    Try : drBuscar = dtCopia.Select("folio = '" & FolioCapturado.Trim & "' and reloj = '" & txtReloj.Text.Trim & "'")(0) : Catch : EsError = True : End Try

                                    If Not EsError Then
                                        For Each drColumna As DataColumn In dtCopia.Columns
                                            Try : drBuscar(drColumna.ColumnName) = drFolioCapturado(drColumna.ColumnName) : Catch ex As Exception : End Try
                                        Next
                                    End If

                                ElseIf FolEncontrado = 0 Then
                                    Try : dtCopia.ImportRow(drFolioCapturado) : Catch : EsError = True : End Try
                                    If Not EsError Then
                                        dtCopia.DefaultView.Sort = "Folio"
                                        sdgFiniquitos.Refresh()
                                    End If
                                End If

                            End If


                        End If

                    End If
                End If
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Error al intentar mostrar la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        FolioSgv = ""
        FolioCapturado = ""
        FolioSeleccionado = ""
    End Sub


    '== Modificado: Se agrego nuevo convenio                    11mar22             Ernesto
    Private Sub GenerarReporteFiniquito()
        Dim dtCartaFiniquito As New DataTable
        Dim dtConvenioFiniquito As New DataTable
        Dim dtFondoAhorro As New DataTable
        Dim dtConvenioFiniquitoAdicional As New DataTable

        Dim strSql1 As String = ""
        Dim strSql2 As String = ""
        Dim strSql3 As String = ""
        Dim strSql4 As String = ""
        Dim Ubicacion As String = ""
        Dim numArchivos As Integer = 0

        Try

            If Not Folio.Trim = "" Then

                Dim fbd As New FolderBrowserDialog
                fbd.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop
                If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Ubicacion = fbd.SelectedPath.Trim & "\"
                End If

                If Ubicacion.Trim = "" Then
                    Exit Sub
                End If

                'Acuse
                strSql1 = "select nomina_calculo.folio,ltrim(rtrim(nomina_calculo.Reloj)) as 'reloj', rtrim(personal.apaterno) as 'apaterno',rtrim(personal.amaterno) as 'amaterno',rtrim(personal.nombre) as 'nombre' ,ltrim(rtrim(nomina_calculo.Nombres)) as 'nomemp'," & vbCr & _
               "rtrim(ltrim(movimientos_calculo.Concepto)) as 'concepto',ltrim(rtrim(naturalezas.COD_NATURALEZA)) as 'naturaleza'," & vbCr & _
               "ltrim(rtrim(conceptos.NOMBRE)) as 'descripcion',conceptos.PRIORIDAD AS  'prioridad','' as 'recibido',isnull(movimientos_calculo.Monto,0) as 'importe',nomina_calculo.baja_fin as 'fin',convert(date,getdate()) as 'fecha_actual'," & vbCr & _
               "0 as 'TOTPER',0 as 'TOTDED', 0 as'NETO'" & vbCr & _
               "from nomina_calculo inner join movimientos_calculo " & vbCr & _
               "on nomina_calculo.reloj = movimientos_calculo.Reloj and nomina_calculo.folio = movimientos_calculo.Folio left join" & vbCr & _
               "conceptos on movimientos_calculo.Concepto = conceptos.CONCEPTO left join naturalezas on conceptos.COD_NATURALEZA = naturalezas.COD_NATURALEZA left join personal.dbo.personal" & vbCr & _
               "on nomina_calculo.reloj = personal.reloj" & vbCr & _
               "where nomina_calculo.reloj = '" & txtReloj.Text.Trim & "' and nomina_calculo.folio = '" & Folio.Trim & "'" & vbCr & _
               "order by folio, reloj"

                'Convenio
                strSql2 = "select folio,nomina_calculo.reloj,rtrim(personalvw.apaterno) as 'apaterno',rtrim(personalvw.amaterno) as 'amaterno',rtrim(personalvw.nombre) as 'nombre',rtrim(nomina_calculo.Nombres) as 'nomemp',nomina_calculo.alta,baja_fin as 'fin',convert(date,getdate()) as 'fecha_actual'," & vbCr & _
                "nomina_calculo.sactual,nomina_calculo.num_cheque,personalvw.nombre_puesto as 'puesto',personalvw.nombre_area as 'area',personalvw.nombre_horario as 'horario'" & vbCr & _
                "from nomina_calculo left join PERSONAL.dbo.personalvw on nomina_calculo.Reloj = personalvw.RELOJ" & vbCr & _
                "where folio = '" & Folio.Trim & "' and nomina_calculo.reloj = '" & txtReloj.Text.Trim & "'"

                ''Fondo de ahorro
                'strSql3 = "select nomina_calculo.folio,nomina_calculo.reloj,personalvw.APATERNO,personalvw.AMATERNO,personalvw.NOMBRE,nomina_calculo.baja_fin, convert(date,getdate()) as 'fecha_actual'" & vbCr & _
                '    "from nomina_calculo left join PERSONAL.dbo.personalvw on nomina_calculo.Reloj = personalvw.RELOJ" & vbCr & _
                '    "where nomina_calculo.folio = '" & Folio.Trim & "' and nomina_calculo.reloj = '" & txtReloj.Text.Trim & "'"

                '== Se agrego la alta para distinguir de los reingresos                 18oct2021               Ernesto
                strSql3 = "select nomina_calculo.folio,nomina_calculo.reloj,nomina_calculo.alta,personalvw.APATERNO,personalvw.AMATERNO,personalvw.NOMBRE,nomina_calculo.baja_fin, convert(date,getdate()) as 'fecha_actual'" & vbCr & _
                    "from nomina_calculo left join PERSONAL.dbo.personalvw on nomina_calculo.Reloj = personalvw.RELOJ" & vbCr & _
                    "where nomina_calculo.folio = '" & Folio.Trim & "' and nomina_calculo.reloj = '" & txtReloj.Text.Trim & "'"

                '== Convenio finiquito adicional                    10mar22             Ernesto
                strSql4 = "select nomina_calculo.folio,nomina_calculo.reloj,nomina_calculo.alta," & _
                                "personalvw.APATERNO,personalvw.AMATERNO,personalvw.NOMBRE,nomina_calculo.baja_fin," & _
                                "convert(date,getdate()) as 'fecha_actual',personalvw.IMSS,personalvw.CURP,personalvw.RFC,personalvw.FHA_NAC,nomina_calculo.sactual," & _
                                "personalvw.D_COMPLETA,personalvw.nombre_civil,personalvw.COD_HORA,nomina_calculo.num_cheque,personalvw.nombre_puesto as 'puesto',personalvw.nombre_area as 'area',personalvw.nombre_horario as 'horario' " & _
                                "from nomina_calculo left join PERSONAL.dbo.personalvw on nomina_calculo.Reloj = personalvw.RELOJ " & _
                                "where nomina_calculo.folio = '" & Folio.Trim & "' and nomina_calculo.reloj = '" & txtReloj.Text.Trim & "'"

                dtCartaFiniquito = sqlExecute(strSql1, "NOMINA")
                dtConvenioFiniquito = sqlExecute(strSql2, "NOMINA")
                dtFondoAhorro = sqlExecute(strSql3, "NOMINA")
                dtConvenioFiniquitoAdicional = sqlExecute(strSql4, "NOMINA")

                If dtCartaFiniquito.Columns.Contains("ERROR") Then
                    MessageBox.Show("Error al intentar generar la carta de finiquito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If dtConvenioFiniquito.Columns.Contains("ERROR") Then
                    MessageBox.Show("Error al intentar generar el convenio de finiquito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If dtFondoAhorro.Columns.Contains("ERROR") Then
                    MessageBox.Show("Error al intentar generar el formato de fondo de ahorro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If dtConvenioFiniquitoAdicional.Columns.Contains("ERROR") Then
                    MessageBox.Show("Error al intentar generar el formato de fondo de ahorro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If dtCartaFiniquito.Rows.Count > 0 Then
                    frmVistaPrevia.LlamarReporte("Acuse Finiquito", dtCartaFiniquito, "", {}, False, Ubicacion & "WOLLSDORF FINIQUITO " & "FOLIO " & Folio.Trim.PadLeft(7, "0") & " EMP " & txtReloj.Text.Trim & " " & txtNombre.Text.Trim & ".doc")
                    ' frmVistaPrevia.ShowDialog()
                    numArchivos = numArchivos + 1
                End If

                If dtConvenioFiniquito.Rows.Count > 0 Then
                    frmVistaPrevia.LlamarReporte("ConvenioFiniquito", dtConvenioFiniquito, "", {}, False, Ubicacion & "WOLLSDORF CONVENIO FINIQUITO " & "FOLIO " & Folio.Trim.PadLeft(7, "0") & " EMP " & txtReloj.Text.Trim & " " & txtNombre.Text.Trim & ".doc")
                    '  frmVistaPrevia.ShowDialog()
                    numArchivos = numArchivos + 1
                End If

                If dtFondoAhorro.Rows.Count > 0 Then
                    frmVistaPrevia.LlamarReporte("Liquidación FAH", dtFondoAhorro, "", {}, False, Ubicacion & "WOLLSDORF FONDO DE AHORRO " & "FOLIO " & Folio.Trim.PadLeft(7, "0") & " EMP " & txtReloj.Text.Trim & " " & txtNombre.Text.Trim & ".doc")
                    'frmVistaPrevia.ShowDialog()
                    numArchivos = numArchivos + 1
                End If

                If dtConvenioFiniquitoAdicional.Rows.Count > 0 Then
                    frmVistaPrevia.LlamarReporte("ConvenioFiniquito2", dtConvenioFiniquitoAdicional, "", {}, False,
                                                 Ubicacion & "WOLLSDORF CONVENIO " & "FOLIO " & Folio.Trim.PadLeft(7, "0") & " EMP " & txtReloj.Text.Trim & " " & txtNombre.Text.Trim & ".doc")
                    'frmVistaPrevia.ShowDialog()
                    numArchivos = numArchivos + 1
                End If
                MessageBox.Show("Archivos generados: " & numArchivos.ToString & ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No se ha seleccionado un folio válido. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show("No se ha seleccionado un folio válido. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    '== Funcion vieja  (comentada)          marzo22
    'Private Sub GenerarReporteFiniquito()
    '    Dim dtCartaFiniquito As New DataTable
    '    Dim dtConvenioFiniquito As New DataTable
    '    Dim dtFondoAhorro As New DataTable
    '    Dim strSql1 As String = ""
    '    Dim strSql2 As String = ""
    '    Dim strSql3 As String = ""
    '    Dim Ubicacion As String = ""
    '    Dim numArchivos As Integer = 0

    '    Try

    '        If Not Folio.Trim = "" Then



    '            Dim fbd As New FolderBrowserDialog
    '            fbd.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop
    '            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
    '                Ubicacion = fbd.SelectedPath.Trim & "\"
    '            End If

    '            If Ubicacion.Trim = "" Then
    '                Exit Sub
    '            End If

    '            'Acuse
    '            strSql1 = "select nomina_calculo.folio,ltrim(rtrim(nomina_calculo.Reloj)) as 'reloj', rtrim(personal.apaterno) as 'apaterno',rtrim(personal.amaterno) as 'amaterno',rtrim(personal.nombre) as 'nombre' ,ltrim(rtrim(nomina_calculo.Nombres)) as 'nomemp'," & vbCr & _
    '           "rtrim(ltrim(movimientos_calculo.Concepto)) as 'concepto',ltrim(rtrim(naturalezas.COD_NATURALEZA)) as 'naturaleza'," & vbCr & _
    '           "ltrim(rtrim(conceptos.NOMBRE)) as 'descripcion',conceptos.PRIORIDAD AS  'prioridad','' as 'recibido',isnull(movimientos_calculo.Monto,0) as 'importe',nomina_calculo.baja_fin as 'fin',convert(date,getdate()) as 'fecha_actual'," & vbCr & _
    '           "0 as 'TOTPER',0 as 'TOTDED', 0 as'NETO'" & vbCr & _
    '           "from nomina_calculo inner join movimientos_calculo " & vbCr & _
    '           "on nomina_calculo.reloj = movimientos_calculo.Reloj and nomina_calculo.folio = movimientos_calculo.Folio left join" & vbCr & _
    '           "conceptos on movimientos_calculo.Concepto = conceptos.CONCEPTO left join naturalezas on conceptos.COD_NATURALEZA = naturalezas.COD_NATURALEZA left join personal.dbo.personal" & vbCr & _
    '           "on nomina_calculo.reloj = personal.reloj" & vbCr & _
    '           "where nomina_calculo.reloj = '" & txtReloj.Text.Trim & "' and nomina_calculo.folio = '" & Folio.Trim & "'" & vbCr & _
    '           "order by folio, reloj"

    '            'Convenio
    '            strSql2 = "select folio,nomina_calculo.reloj,rtrim(personalvw.apaterno) as 'apaterno',rtrim(personalvw.amaterno) as 'amaterno',rtrim(personalvw.nombre) as 'nombre',rtrim(nomina_calculo.Nombres) as 'nomemp',nomina_calculo.alta,baja_fin as 'fin',convert(date,getdate()) as 'fecha_actual'," & vbCr & _
    '            "nomina_calculo.sactual,nomina_calculo.num_cheque,personalvw.nombre_puesto as 'puesto',personalvw.nombre_area as 'area',personalvw.nombre_horario as 'horario'" & vbCr & _
    '            "from nomina_calculo left join PERSONAL.dbo.personalvw on nomina_calculo.Reloj = personalvw.RELOJ" & vbCr & _
    '            "where folio = '" & Folio.Trim & "' and nomina_calculo.reloj = '" & txtReloj.Text.Trim & "'"

    '            ''Fondo de ahorro
    '            'strSql3 = "select nomina_calculo.folio,nomina_calculo.reloj,personalvw.APATERNO,personalvw.AMATERNO,personalvw.NOMBRE,nomina_calculo.baja_fin, convert(date,getdate()) as 'fecha_actual'" & vbCr & _
    '            '    "from nomina_calculo left join PERSONAL.dbo.personalvw on nomina_calculo.Reloj = personalvw.RELOJ" & vbCr & _
    '            '    "where nomina_calculo.folio = '" & Folio.Trim & "' and nomina_calculo.reloj = '" & txtReloj.Text.Trim & "'"

    '            '== Se agrego la alta para distinguir de los reingresos                 18oct2021               Ernesto
    '            strSql3 = "select nomina_calculo.folio,nomina_calculo.reloj,nomina_calculo.alta,personalvw.APATERNO,personalvw.AMATERNO,personalvw.NOMBRE,nomina_calculo.baja_fin, convert(date,getdate()) as 'fecha_actual'" & vbCr & _
    '                "from nomina_calculo left join PERSONAL.dbo.personalvw on nomina_calculo.Reloj = personalvw.RELOJ" & vbCr & _
    '                "where nomina_calculo.folio = '" & Folio.Trim & "' and nomina_calculo.reloj = '" & txtReloj.Text.Trim & "'"

    '            dtCartaFiniquito = sqlExecute(strSql1, "NOMINA")
    '            dtConvenioFiniquito = sqlExecute(strSql2, "NOMINA")
    '            dtFondoAhorro = sqlExecute(strSql3, "NOMINA")

    '            If dtCartaFiniquito.Columns.Contains("ERROR") Then
    '                MessageBox.Show("Error al intentar generar la carta de finiquito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub
    '            End If

    '            If dtConvenioFiniquito.Columns.Contains("ERROR") Then
    '                MessageBox.Show("Error al intentar generar el convenio de finiquito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub
    '            End If

    '            If dtFondoAhorro.Columns.Contains("ERROR") Then
    '                MessageBox.Show("Error al intentar generar el formato de fondo de ahorro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub
    '            End If

    '            If dtCartaFiniquito.Rows.Count > 0 Then
    '                frmVistaPrevia.LlamarReporte("Acuse Finiquito", dtCartaFiniquito, "", {}, False, Ubicacion & "WOLLSDORF FINIQUITO " & "FOLIO " & Folio.Trim.PadLeft(7, "0") & " EMP " & txtReloj.Text.Trim & " " & txtNombre.Text.Trim & ".PDF")
    '                ' frmVistaPrevia.ShowDialog()
    '                numArchivos = numArchivos + 1
    '            End If

    '            If dtConvenioFiniquito.Rows.Count > 0 Then
    '                frmVistaPrevia.LlamarReporte("ConvenioFiniquito", dtConvenioFiniquito, "", {}, False, Ubicacion & "WOLLSDORF CONVENIO FINIQUITO " & "FOLIO " & Folio.Trim.PadLeft(7, "0") & " EMP " & txtReloj.Text.Trim & " " & txtNombre.Text.Trim & ".PDF")
    '                '  frmVistaPrevia.ShowDialog()
    '                numArchivos = numArchivos + 1
    '            End If


    '            If dtFondoAhorro.Rows.Count > 0 Then
    '                frmVistaPrevia.LlamarReporte("Liquidación FAH", dtFondoAhorro, "", {}, False, Ubicacion & "WOLLSDORF FONDO DE AHORRO " & "FOLIO " & Folio.Trim.PadLeft(7, "0") & " EMP " & txtReloj.Text.Trim & " " & txtNombre.Text.Trim & ".PDF")
    '                'frmVistaPrevia.ShowDialog()
    '                numArchivos = numArchivos + 1
    '            End If

    '            MessageBox.Show("Archivos generados: " & numArchivos.ToString & ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        Else

    '            MessageBox.Show("No se ha seleccionado un folio válido. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '        End If



    '    Catch ex As Exception
    '        MessageBox.Show("No se ha seleccionado un folio válido. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    End Try
    '    'Dim dtDatos As New DataTable

    '    'Dim strSQL As String = ""

    '    'If Not Folio = "" Then

    '    '    strSQL = "exec ReporteFiniquito '" & Folio & "','" & txtReloj.Text.Trim & "'"

    '    '    dtDatos = sqlExecute(strSQL, "NOMINA")

    '    '    If dtDatos.Columns.Contains("ERROR") Then

    '    '        MessageBox.Show("Error al cargar el reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    '        Exit Sub
    '    '    End If


    '    '    If Not dtDatos.Rows.Count > 0 Then

    '    '        MessageBox.Show("Folio no encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    '        Exit Sub
    '    '    End If

    '    '    frmVistaPrevia.LlamarReporte("Finiquito", dtDatos)
    '    '    frmVistaPrevia.ShowDialog()

    '    '    If MessageBox.Show("¿Desea generar el archivo pdf del finiquito?", "Generar pdf finiquito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '    '        Dim sfd As New SaveFileDialog

    '    '        sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
    '    '        sfd.Filter = "PDF|*.PDF"
    '    '        sfd.Title = "Guardar en"
    '    '        sfd.OverwritePrompt = True
    '    '        sfd.RestoreDirectory = True
    '    '        sfd.FileName = "BRP QRO Finiquito " & txtReloj.Text.Trim & " " & txtNombre.Text.Trim & ".PDF"

    '    '        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
    '    '            frmVistaPrevia.LlamarReporte("Finiquito", dtDatos, , , False, sfd.FileName.ToString)
    '    '            MessageBox.Show("El finiquito ha sido guardado", "Finiquito guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    '        End If

    '    '    End If


    '    'Else
    '    '    MessageBox.Show("No se ha seleccionado un folio válido. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    'End If

    'End Sub

    Private Sub GenerarReporte()
        Dim dtDatos As New DataTable

        Dim strSQL As String = ""

        If Not Folio = "" Then

            strSQL = "declare @Folio char(10) = '" & Folio & "'" & _
               " select movimientos_calculo.*,LTRIM(RTRIM(conceptos.COD_NATURALEZA)) as naturaleza,LTRIM(RTRIM(conceptos.NOMBRE)) as nombre,round(dbo.TotalPercepciones(@Folio),2) as TOTPER ," & _
               " round(dbo.TotalDeducciones(@Folio),2) as TOTDED,round((dbo.TotalPercepciones(@Folio) - dbo.TotalDeducciones(@Folio)),2) as neto from movimientos_calculo  left join" & _
               " conceptos on movimientos_calculo.Concepto = conceptos.CONCEPTO" & _
               " where conceptos.COD_NATURALEZA in('P','D') and conceptos.POSITIVO in(0, 1) and SUMA_NETO = 1 and monto > 0  and movimientos_calculo .folio = @Folio " & _
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

    Private Sub MostrarFolio()

        Dim Respuesta As Windows.Forms.DialogResult

        Try

            If Folio.Trim = "" Then
                MessageBox.Show("Debe seleccionar un folio para editar finiquito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If dgvFiniquitos.SelectedRows.Count > 0 Then

                Respuesta = frmAjusteFiniquito.ShowDialog(Me)

                If Respuesta = Windows.Forms.DialogResult.Abort Then
                    MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                ElseIf Respuesta = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub HabilitarBotones()

        Try

            Dim NoReg As Boolean = dgvFiniquitos.Rows.Count > 0

            ' btnNext.Enabled = Not (Editar Or Agregar)
            ' btnFirst.Enabled = Not (Editar Or Agregar)
            ' btnLast.Enabled = Not (Editar Or Agregar)
            ' btnPrev.Enabled = Not (Editar Or Agregar)

            dgvFiniquitos.Enabled = Not switchActivo

            btnNuevo.Enabled = dtRegistro.Rows.Count > 0 And Not switchActivo And TabFiniquitos.SelectedTabIndex = 0
            btnEditar.Enabled = NoReg And Not switchActivo
            btnBorrar.Enabled = NoReg And Not switchActivo
            'btnCerrar.Enabled = (Editar Or Agregar)
            btnReporte.Enabled = NoReg And Not switchActivo
            btnBuscar.Enabled = Not switchActivo And TabFiniquitos.SelectedTabIndex = 0
            btnCancelarFiniquito.Enabled = NoReg And Not switchActivo And Not finCancelado
            cmbPeriodosAsentado.Enabled = NoReg And switchActivo
            swTipoperiodo.Enabled = NoReg And switchActivo
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Deposito()

        Dim frm As New frmTrabajando

        Dim dtDeposito As New DataTable

        Dim strSql As String = ""
        Dim cadena As String = ""
        Dim i As Integer = 0

        Try


            frm.Show()
            Application.DoEvents()

            If dtMulitSelCompleto.Rows.Count > 0 Then

                For Each drRow As DataRow In dtMulitSelCompleto.Select("", "folio")

                    Application.DoEvents()

                    'cadena = cadena & "'" & drRow("folio") & "'" & IIf(i = dtMulitSel.Rows.Count, "", ",")

                    strSql = "exec AsentarDeposito " & drRow("folio").ToString.Trim & ",'" & drRow("ano").ToString.Trim & "','" & drRow("periodo").ToString.Trim & "'"
                    dtDeposito = sqlExecute(strSql, "NOMINA")

                    If dtDeposito.Columns.Count > 0 Then

                        If dtDeposito.Columns.Contains("Mensaje") Then

                            Dim drRowMensaje As DataRow = dtDeposito.Rows(0)
                            MessageBox.Show(drRowMensaje("Mensaje").ToString.Trim, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        ElseIf dtDeposito.Columns.Contains("ErrDesc") Then

                            Dim drRowError As DataRow = dtDeposito.Rows(0)

                            ErrorLog(Usuario, drRowError("procedimiento"), drRowError("Forma"), drRowError("ErrNum"), drRowError("ErrDesc"), drRowError("Comentario"))

                            MessageBox.Show("Se presentó un problema al intentar cargar la información para depósito del empleado " & drRow("reloj"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        ElseIf dtDeposito.Columns.Contains("ERROR") Then
                            MessageBox.Show("Se presentó un problema al intentar cargar la información para depósito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    Else
                        'Actualizar MTRO_DED y SALDOS_CA
                        ActMtroDedSaldosAc(drRow("folio").ToString.Trim)
                        i = i + 1
                    End If
                Next

                MessageBox.Show("Se enviaron para depósito: " & i & " folios de " & dtMulitSelCompleto.Rows.Count & " seleccionado(s)", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                MessageBox.Show("No hay folios para enviar a depósito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


            End If

            ActivoTrabajando = False
            frm.Close()

        Catch ex As Exception

            ActivoTrabajando = False
            frm.Close()
            MessageBox.Show("Se presentó un error al intentar cargar los datos para depósito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    '***********************************************************Actualizar MTRO_DED y SALDOS_CA
    Private Sub ActMtroDedSaldosAc(fl As String)

        Dim dtEmpleadoAsentado As New DataTable
        Dim rl As String = ""
        Dim ano_mtro_ded As String = ""
        Dim per_mtro_ded As String = ""
        Dim numcred_mtro_ded As String = ""
        Dim ano_asent_dep As String = ""
        Dim per_asent_dep As String = ""

        Try

            dtEmpleadoAsentado = sqlExecute("select * from nomina_calculo where folio = '" & fl & "' and asentado_deposito = 1 and ltrim(rtrim(isnull(ano_asent_dep,''))) <> '' and ltrim(rtrim(isnull(per_asent_dep,''))) <> ''", "NOMINA")

            If (Not dtEmpleadoAsentado.Columns.Contains("Error") And dtEmpleadoAsentado.Rows.Count > 0) Then

                Dim drEmpleado As DataRow = dtEmpleadoAsentado.Rows(0)

                Try : rl = drEmpleado("reloj").ToString.Trim : Catch ex As Exception : rl = "" : End Try
                Try : ano_mtro_ded = drEmpleado("ano_mtro_ded").ToString.Trim : Catch ex As Exception : ano_mtro_ded = "" : End Try
                Try : per_mtro_ded = drEmpleado("per_mtro_ded").ToString.Trim : Catch ex As Exception : per_mtro_ded = "" : End Try

                Try : ano_asent_dep = drEmpleado("ano_asent_dep").ToString.Trim : Catch ex As Exception : ano_asent_dep = "" : End Try
                Try : per_asent_dep = drEmpleado("per_asent_dep").ToString.Trim : Catch ex As Exception : per_asent_dep = "" : End Try

                If (rl = "" Or ano_mtro_ded = "" Or per_mtro_ded = "" Or ano_asent_dep = "" Or per_asent_dep = "") Then Exit Sub

                Dim dtObtenerMovimientos As New DataTable

                'Dim strSQL As String = "select tb1.folio,tb1.Reloj,naturaleza,alias_mtro_ded,mtro_ded.NUMCREDITO,Monto"


                dtObtenerMovimientos = sqlExecute("select tb1.folio,tb1.Reloj,naturaleza,alias_mtro_ded,mtro_ded.NUMCREDITO,Monto" & vbCr & _
                                                  "from(" & vbCr & _
                                                  "select  ltrim(rtrim(conceptos.COD_NATURALEZA)) as naturaleza,movimientos_calculo.Folio,movimientos_calculo.Reloj, movimientos_calculo.Concepto,conceptos.alias_mtro_ded,movimientos_calculo.Monto" & vbCr & _
                                                  "from movimientos_calculo left join conceptos on movimientos_calculo.Concepto = conceptos.CONCEPTO" & vbCr & _
                                                  "where folio = '" & fl & "' and movimientos_calculo.reloj = '" & rl & "' and ltrim(rtrim(isnull(conceptos.alias_mtro_ded,''))) <> '')tb1 left join mtro_ded" & vbCr & _
                                                  "on tb1.alias_mtro_ded = mtro_ded.CONCEPTO and tb1.Reloj = mtro_ded.RELOJ" & vbCr & _
                                                  "where isnull(mtro_ded.STATUS,0) = 1 and isnull(mtro_ded.SALDO_ACT,0) > 0 and (mtro_ded.ANO+mtro_ded.PERIODO)<= '" & ano_mtro_ded & per_mtro_ded & "'", "NOMINA")

                For Each Row As DataRow In dtObtenerMovimientos.Rows

                    Dim naturaleza As String = Row("naturaleza").ToString.Trim.ToUpper
                    Dim concepto As String = Row("alias_mtro_ded").ToString.Trim.ToUpper
                    Dim coment As String = ""

                    Try : numcred_mtro_ded = Row("numcredito").ToString.Trim : Catch ex As Exception : numcred_mtro_ded = "" : End Try

                    If naturaleza = "P" Then
                        coment = "Saldo Entregado: " & Row("monto").ToString & " " & Now.Day.ToString.PadLeft(2, "0") & "/" & Now.Month.ToString.PadLeft(2, "0") & "/" & Now.Year.ToString.PadLeft(4, "0") & " Usuario: " & Usuario.Trim
                    ElseIf naturaleza = "D" Then
                        coment = "Saldo Liquidado: " & Row("monto").ToString & " " & Now.Day.ToString.PadLeft(2, "0") & "/" & Now.Month.ToString.PadLeft(2, "0") & "/" & Now.Year.ToString.PadLeft(4, "0") & " Usuario: " & Usuario.Trim
                    End If

                    If Not numcred_mtro_ded = "" Then
                        Dim QInsSaldos As String = "insert into saldos_ca (reloj,PERIODO,ANO,CONCEPTO,NUMCREDITO,ABONO_ALC,SALDO_ACT,COMENTARIO) " & _
                        "values ('" & rl & "','" & per_asent_dep & "','" & ano_asent_dep & "','" & concepto & "','" & numcred_mtro_ded & "'," & 0 & "," & 0 & ",'" & coment & "')"
                        sqlExecute(QInsSaldos, "NOMINA")

                        Dim QUpMtroDed As String = "update mtro_ded set SALDO_ACT=" & 0 & ",anoper_aplicado='" & ano_asent_dep & per_asent_dep & "',STATUS=" & 0 & ",ano='" & ano_asent_dep & "',PERIODO='" & per_asent_dep & "',ABONO_ACT = 0 where reloj='" & rl & "' and CONCEPTO='" & concepto & "' and NUMCREDITO='" & numcred_mtro_ded & "' and STATUS=1 and isnull(saldo_act,0)>0"
                        sqlExecute(QUpMtroDed, "NOMINA")
                    End If


                Next


            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub Poliza()

        'Dim frm As New frmTrabajando

        'Dim dtPoliza As New DataTable

        'Dim strSql As String = ""
        'Dim cadena As String = ""
        'Dim i As Integer = 0

        'Try

        '    frm.Show()
        '    Application.DoEvents()

        '    strSql = "delete from movimientos where periodo in ('80','81')" & vbCr & _
        '        " delete from nomina where periodo in('80','81')"

        '    dtPoliza = sqlExecute(strSql, "NOMINA")

        '    If Not dtPoliza.Columns.Contains("ERROR") Then

        '        If dtMulitSel.Rows.Count > 0 Then

        '            For Each drRow As DataRow In dtMulitSel.Select("", "folio")
        '                Application.DoEvents()

        '                strSql = "exec AsentarPoliza " & drRow("folio").ToString.Trim
        '                dtPoliza = sqlExecute(strSql, "NOMINA")

        '                If dtPoliza.Columns.Count > 0 Then

        '                    If dtPoliza.Columns.Contains("Mensaje") Then

        '                        Dim drRowMensaje As DataRow = dtPoliza.Rows(0)
        '                        MessageBox.Show(drRowMensaje("Mensaje").ToString.Trim, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        '                    ElseIf dtPoliza.Columns.Contains("ErrDesc") Then

        '                        Dim drRowError As DataRow = dtPoliza.Rows(0)

        '                        ErrorLog(Usuario, drRowError("procedimiento"), drRowError("Forma"), drRowError("ErrNum"), drRowError("ErrDesc"), drRowError("Comentario"))

        '                        MessageBox.Show("Se presentó un problema al intentar cargar la información para asentar la póliza del empleado " & drRow("reloj"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '                    ElseIf dtPoliza.Columns.Contains("ERROR") Then
        '                        MessageBox.Show("Se presentó un problema al intentar cargar la información para asentar la póliza del empleado " & drRow("reloj"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                    End If

        '                Else
        '                    i = i + 1
        '                End If

        '            Next
        '            'MessageBox.Show("Se enviaron para póliza: " & i & " folios de " & dtMulitSel.Rows.Count & " seleccionado(s)", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            MessageBox.Show("Se enviaron para póliza: " & i & " folios de " & dtMulitSelCompleto.Rows.Count & " seleccionado(s)", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Else

        '            MessageBox.Show("No hay folios para enviar a póliza", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        '            Exit Sub

        '        End If


        '    Else

        '        MessageBox.Show("Se presentó un problema al intentar iniciar la carga de datos para póliza", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        '    End If


        '    ActivoTrabajando = False
        '    frm.Close()


        'Catch ex As Exception
        '    ActivoTrabajando = False
        '    frm.Close()
        '    MessageBox.Show("Se presentó un error al intentar cargar los datos para póliza", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        'End Try

    End Sub

    Private Sub frmFiniquito_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            pnlControlAsentado.Enabled = True
            pnlControlAsentado.Visible = True
            lblEstado.Visible = False

            dgvFiniquitos.AutoGenerateColumns = False

            sdgFiniquitos.PrimaryGrid.AutoGenerateColumns = False

            dgvFiniquitos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            dtPeriodosAsentado = sqlExecute("select convert(char(100),'INDEFINIDO') as tipoperiodo,'' as 'Único','' as 'Año','' as 'Periodo','' as 'Inicio','' as 'Fin'", "TA")
            cmbPeriodosAsentado.DataSource = dtPeriodosAsentado

            strSQLista = "select  0 as seleccionado, [Status] as estado,ano,Periodo,Folio,Reloj,Nombres, cod_tipo,tipo_periodo," & vbCr & _
                " cod_puesto,alta,alta_antig,baja_fin,convert(decimal(38,2),isnull(Neto,0)) as Neto, Prima_Antig,Gratificacion,isnull(dias_grati,0) as dias_grati,[20diasano],vales_despensa," & vbCr & _
                " isnull(asentado_deposito,0) as 'Deposito',isnull(ano_asent_dep,'') as ano_asent_dep,isnull(per_asent_dep,'') as per_asent_dep,isnull(asentado_poliza,0) as 'Poliza',Usuario,Captura,isnull(complemento,0) as complemento" & vbCr & _
                " from nomina_calculo"

            dtLista = sqlExecute(strSQLista, "NOMINA")

            dtLista.DefaultView.Sort = "Folio"

            sdgFiniquitos.PrimaryGrid.DataSource = dtLista

            sdgFiniquitos.PrimaryGrid.EnableFiltering = True
            sdgFiniquitos.PrimaryGrid.UseAlternateRowStyle = True
            sdgFiniquitos.PrimaryGrid.EnableColumnFiltering = True
            'sdgFiniquitos.PrimaryGrid.ReadOnly = True

            sdgFiniquitos.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells

            dtMulitSelCompleto.Columns.Add("ano", GetType(System.String))
            dtMulitSelCompleto.Columns.Add("periodo", GetType(System.String))
            dtMulitSelCompleto.Columns.Add("folio", GetType(System.String))
            dtMulitSelCompleto.Columns.Add("reloj", GetType(System.String))
            dtMulitSelCompleto.Columns.Add("perfin", GetType(System.String))

            dtMulitSelSemana.Columns.Add("ano", GetType(System.String))
            dtMulitSelSemana.Columns.Add("periodo", GetType(System.String))
            dtMulitSelSemana.Columns.Add("folio", GetType(System.String))
            dtMulitSelSemana.Columns.Add("reloj", GetType(System.String))
            dtMulitSelSemana.Columns.Add("perfin", GetType(System.String))

            dtMulitSelSemana.PrimaryKey = New DataColumn() {dtMulitSelSemana.Columns("ano"), dtMulitSelSemana.Columns("perfin"), dtMulitSelSemana.Columns("reloj")}

            dtMulitSelCatorcena.Columns.Add("ano", GetType(System.String))
            dtMulitSelCatorcena.Columns.Add("periodo", GetType(System.String))
            dtMulitSelCatorcena.Columns.Add("folio", GetType(System.String))
            dtMulitSelCatorcena.Columns.Add("reloj", GetType(System.String))
            dtMulitSelCatorcena.Columns.Add("perfin", GetType(System.String))

            dtMulitSelCatorcena.PrimaryKey = New DataColumn() {dtMulitSelCatorcena.Columns("ano"), dtMulitSelCatorcena.Columns("perfin"), dtMulitSelCatorcena.Columns("reloj")}

            HabilitarBotones()
            EscargaInicial = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un error al cargar la ventana. Si el problema persiste contacte al administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim Respuesta As Windows.Forms.DialogResult

        Folio = ""
        Bandera = "NVO"
        finCancelado = False
        Try
            Respuesta = frmAjusteFiniquito.ShowDialog(Me)
            If Respuesta = Windows.Forms.DialogResult.Abort Then
                MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf Respuesta = Windows.Forms.DialogResult.Cancel Then

                ' Exit Sub
            End If

            MostrarInformacion(txtReloj.Text.Trim)
            HabilitarBotones()


        Catch ex As Exception

        End Try



    End Sub

    Private Sub frmCalcFiniquito_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Try
            frmBuscar.ShowDialog(Me)

            If Reloj <> "CANCEL" Then

                MostrarInformacion(Reloj)
                HabilitarBotones()

                If Not dgvFiniquitos.RowCount > 0 Then
                    btnNuevo.PerformClick()
                End If

            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub dgvFiniquitos_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFiniquitos.RowEnter
        On Error Resume Next

        If FolioSgv = "" Then
            Folio = dgvFiniquitos.Item("ColFolio", e.RowIndex).Value
        Else
            Folio = FolioSgv
        End If

        If dgvFiniquitos.Item("ColStatus", e.RowIndex).Value.ToString = "CANCELADO" Or dgvFiniquitos.Item("ColDeposito", e.RowIndex).Value Then
            btnCancelarFiniquito.Enabled = False
            btnEditar.Text = "Ver"
            finCancelado = True
        Else
            btnCancelarFiniquito.Enabled = True
            btnEditar.Text = "Editar"
            finCancelado = False
        End If

    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        Bandera = "EDIT"
        Dim Respuesta As Windows.Forms.DialogResult

        Try

            If Folio.Trim = "" Then
                MessageBox.Show("Debe seleccionar un folio para editar finiquito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If dgvFiniquitos.SelectedRows.Count > 0 Then

                Respuesta = frmAjusteFiniquito.ShowDialog(Me)

                If Respuesta = Windows.Forms.DialogResult.Abort Then
                    MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                ElseIf Respuesta = Windows.Forms.DialogResult.Cancel Then

                    ' Exit Sub
                End If

            End If

            MostrarInformacion(txtReloj.Text.Trim)
            HabilitarBotones()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvFiniquitos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFiniquitos.CellDoubleClick

        Dim Respuesta As Windows.Forms.DialogResult
        Try

            Folio = dgvFiniquitos.Item("ColFolio", e.RowIndex).Value
            Bandera = "EDIT"

            If Folio.Trim <> "" Then

                Respuesta = frmAjusteFiniquito.ShowDialog(Me)

                If Respuesta = Windows.Forms.DialogResult.Abort Then
                    MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                ElseIf Respuesta = Windows.Forms.DialogResult.Cancel Then
                    MostrarInformacion(txtReloj.Text.Trim)
                End If


            End If

        Catch ex As Exception

        End Try




    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        If Folio.Trim = "" Then
            MessageBox.Show("Debe seleccionar un folio para generar el reporte. Favor de verificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            'GenerarReporte()
            GenerarReporteFiniquito()
        End If

    End Sub


    Private Sub swPoliza_ValueObjectChanged(sender As Object, e As EventArgs) Handles swPoliza.ValueObjectChanged

        'Try

        '    sdgFiniquitos.PrimaryGrid.ClearSelectedRows()

        '    If swPoliza.Value Then

        '        sdgFiniquitos.PrimaryGrid.Columns("ColSel").HeaderText = "Póliza"
        '        sdgFiniquitos.PrimaryGrid.Columns("ColSel").Visible = True
        '        sdgFiniquitos.PrimaryGrid.Columns("ColSel").ReadOnly = False

        '        btnAceptar.Enabled = False
        '        btnLimpiar.Enabled = False

        '        swdeposito.Value = False

        '        dtLista = sqlExecute(strSQLista & " where (asentado_poliza is null or asentado_poliza = 0) and [Status] = 'CALCULADO'", "NOMINA")

        '        dtLista.DefaultView.Sort = "Folio"

        '        sdgFiniquitos.PrimaryGrid.DataSource = dtLista

        '        switchActivo = True

        '    Else
        '        dtMulitSel.Clear()


        '        If Not swdeposito.Value Then

        '            sdgFiniquitos.PrimaryGrid.Columns("ColSel").HeaderText = ""
        '            sdgFiniquitos.PrimaryGrid.Columns("ColSel").Visible = False
        '            sdgFiniquitos.PrimaryGrid.Columns("ColSel").ReadOnly = True

        '            sdgFiniquitos.PrimaryGrid.MultiSelect = False
        '            btnAceptar.Enabled = False
        '            btnLimpiar.Enabled = False

        '            dtLista = sqlExecute(strSQLista, "NOMINA")

        '            dtLista.DefaultView.Sort = "Folio"

        '            sdgFiniquitos.PrimaryGrid.DataSource = dtLista

        '            switchActivo = False
        '        End If

        '    End If

        'Catch ex As Exception
        '    switchActivo = True
        'End Try

        'HabilitarBotones()
    End Sub

    Private Sub sdgFiniquitos_RowClick(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs) Handles sdgFiniquitos.RowClick

        'Dim ano As String = ""
        'Dim periodo As String = ""
        'Dim folio1 As String = ""
        'Dim reloj As String = ""

        'Try

        '    FolioSgv = ""
        '    ClickFila = True

        '    If Not (swPoliza.Value Or swdeposito.Value) Then

        '        ano = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridRow.RowIndex, GridColAno.ColumnIndex).Value)
        '        periodo = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridRow.RowIndex, GridColPeriodo.ColumnIndex).Value)
        '        folio1 = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridRow.RowIndex, GridColFolio.ColumnIndex).Value)
        '        reloj = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridRow.RowIndex, GridColReloj.ColumnIndex).Value)

        '        Bandera = "EDIT"
        '        FolioSgv = folio1.Trim
        '        MostrarInformacion(reloj.Trim)
        '        HabilitarBotones()

        '    End If


        'Catch ex As Exception
        '    Bandera = ""
        '    MessageBox.Show("Error al seleccionar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        'If Not dtMulitSel.Rows.Count > 0 Then
        '    MessageBox.Show("Debe selecionar al menos un folio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If

        If Not dtMulitSelCompleto.Rows.Count > 0 Then
            MessageBox.Show("Debe selecionar al menos un folio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Not cmbPeriodosAsentado.SelectedIndex >= 0 Then
            MessageBox.Show("Debe selecionar el periodo que desea asentar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbPeriodosAsentado.Focus()
            Exit Sub
        End If

        If MessageBox.Show("¿Desea realizar algún cambio?", "Realizar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Exit Sub
        End If

        If swdeposito.Value Then
            Deposito()
        ElseIf swPoliza.Value Then
            '   Poliza()
        End If


    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        Dim copia As New DataTable

        Dim Fila As DataRow = Nothing


        Try

            'If Not dtMulitSel.Rows.Count > 0 Then
            '    Exit Sub
            'End If

            If dtMulitSelSemana.Rows.Count > 0 Then
                dtMulitSelSemana.Clear()
            End If

            If dtMulitSelCatorcena.Rows.Count > 0 Then
                dtMulitSelCatorcena.Clear()
            End If


            If Not dtMulitSelCompleto.Rows.Count > 0 Then
                Exit Sub
            End If

            If MessageBox.Show("Esta acción quitará de la lista los folios seleccionados. ¿Desea continuar? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

                ' dtMulitSel.Clear()

                btnAceptar.Enabled = False

                btnLimpiar.Enabled = False

                'copia = DirectCast(dtMulitSel, DataTable)

                copia = DirectCast(dtMulitSelCompleto, DataTable)

                For Each drRow As DataRow In dtLista.Select("seleccionado = 1")

                    drRow("seleccionado") = 0

                    If copia.Select("folio = '" & drRow("folio") & "'").Count > 0 Then

                        Fila = copia.Select("folio = '" & drRow("folio") & "'")(0)

                        copia.Rows.Remove(Fila)

                    End If


                Next

                ' Try : cmbPeriodosAsentado.SelectedIndex = -1 : Catch ex As Exception : End Try
                sdgFiniquitos.PrimaryGrid.ClearSelectedRows()

            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar quitar de la lista los folios seleccionados ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try


    End Sub

    Private Sub swdeposito_ValueObjectChanged(sender As Object, e As EventArgs) Handles swdeposito.ValueObjectChanged

        Try
            Dim selPerActual As String = ""
            sdgFiniquitos.PrimaryGrid.ClearSelectedRows()

            If swdeposito.Value Then

                sdgFiniquitos.PrimaryGrid.Columns("ColSel").HeaderText = "Depósito"
                sdgFiniquitos.PrimaryGrid.Columns("ColSel").Visible = True
                sdgFiniquitos.PrimaryGrid.Columns("ColSel").ReadOnly = False

                btnAceptar.Enabled = False
                btnLimpiar.Enabled = False

                swPoliza.Value = False


                'select  0 as seleccionado, [Status] as estado,ano,Periodo,Folio,Reloj,Nombres, cod_tipo,cod_puesto,alta,alta_antig,baja_finqto,Neto, Prima_Antig,Gratificacion,[20diasano],vales_despensa,isnull(asentado_deposito,0) as 'Deposito',isnull(asentado_poliza,0) as 'Poliza',Usuario,Captura
                'dtLista = sqlExecute(strSQLista & " where (asentado_deposito is null or asentado_deposito = 0) and [Status] = 'CALCULADO' and tipo_periodo = 'S'", "NOMINA")

                'dtLista.DefaultView.Sort = "Folio"

                ' sdgFiniquitos.PrimaryGrid.DataSource = dtLista



                'If swTipoperiodo.Value Then
                '    dtPeriodosAsentado = sqlExecute("select convert(char(100),'SEMANAL') as tipoperiodo,ano+periodo as 'Único',ano as 'Año',periodo as 'Periodo',CONVERT(varchar,FECHA_INI) as 'Inicio',CONVERT(varchar,FECHA_FIN) as 'Fin'" & _
                '                                    " from periodos where isnull(PERIODO_ESPECIAL,0) = 0" & _
                '                                    "order by ano desc, periodo desc", "TA")
                '    cmbPeriodosAsentado.DataSource = dtPeriodosAsentado

                '    dtPeriodoActual = sqlExecute("select  top 1 (ano+periodo) as 'Actual',ano as 'Año',periodo as 'Periodo',FECHA_INI as 'Inicio',FECHA_FIN as 'Fin' " & _
                '                   "from periodos where CONVERT(date,getdate()) between FECHA_INI and FECHA_FIN and isnull(PERIODO_ESPECIAL,0) = 0", "TA")

                'Else

                '    dtPeriodosAsentado = sqlExecute("select convert(char(100),'CATORCENAL') as tipoperiodo,ano+periodo as 'Único',ano as 'Año',periodo as 'Periodo',CONVERT(varchar,FECHA_INI) as 'Inicio',CONVERT(varchar,FECHA_FIN) as 'Fin'" & _
                '                                    " from periodos_catorcenal where isnull(PERIODO_ESPECIAL,0) = 0" & _
                '                                    "order by ano desc, periodo desc", "TA")
                '    cmbPeriodosAsentado.DataSource = dtPeriodosAsentado

                '    dtPeriodoActual = sqlExecute("select  top 1 (ano+periodo) as 'Actual',ano as 'Año',periodo as 'Periodo',FECHA_INI as 'Inicio',FECHA_FIN as 'Fin' " & _
                '              "from periodos_catorcenal where CONVERT(date,getdate()) between FECHA_INI and FECHA_FIN and isnull(PERIODO_ESPECIAL,0) = 0", "TA")

                'End If


                'Try : selPerActual = dtPeriodoActual.Rows(0).Item("Actual") : Catch ex As Exception : selPerActual = "" : End Try

                'cmbPeriodosAsentado.SelectedValue = selPerActual

                switchActivo = True

                swTipoperiodo.Value = True

            Else
                'dtMulitSel.Clear()
                dtMulitSelSemana.Clear()
                dtMulitSelCatorcena.Clear()
                dtMulitSelCompleto.Clear()
                sdgFiniquitos.PrimaryGrid.ClearSelectedRows()

                If Not swPoliza.Value Then

                    sdgFiniquitos.PrimaryGrid.Columns("ColSel").HeaderText = ""
                    sdgFiniquitos.PrimaryGrid.Columns("ColSel").Visible = False
                    sdgFiniquitos.PrimaryGrid.Columns("ColSel").ReadOnly = True

                    sdgFiniquitos.PrimaryGrid.MultiSelect = False
                    btnAceptar.Enabled = False
                    btnLimpiar.Enabled = False

                    dtLista = sqlExecute(strSQLista, "NOMINA")

                    dtLista.DefaultView.Sort = "Folio"

                    sdgFiniquitos.PrimaryGrid.DataSource = dtLista

                    swTipoperiodo.Value = False

                    cmbPeriodosAsentado.SelectedIndex = -1

                    switchActivo = False
                End If

            End If

        Catch ex As Exception
            switchActivo = True
        End Try

        HabilitarBotones()

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

        If MessageBox.Show("Esta acción eliminrá los datos de finiquito relacionados al folio seleccionado. ¿Desea continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then


            If sqlExecute("delete from movimientos_calculo where folio = '" & Folio & "'", "NOMINA").Columns.Contains("ERROR") Then
                Exit Sub
            End If

            If sqlExecute("delete from ajustes_tmp where folio = '" & Folio & "'", "NOMINA").Columns.Contains("ERROR") Then
                Exit Sub
            End If


            If sqlExecute("delete from nomina_calculo where folio = '" & Folio & "'", "NOMINA").Columns.Contains("ERROR") Then
                Exit Sub
            End If

            MessageBox.Show("El finiquito con folio '" & Folio & "' ha sido eliminado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MostrarInformacion(txtReloj.Text.Trim)
            HabilitarBotones()

        End If

    End Sub

    Private Sub sdgFiniquitos_CellClick(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs) Handles sdgFiniquitos.CellClick


        Dim ano As String = ""
        Dim periodo As String = ""
        Dim folio1 As String = ""
        Dim reloj As String = ""
        Dim tipoperiodo As String = ""
        Dim complemento As Boolean = False
        Dim row As DataRow = Nothing
        Dim drEncontrado As DataRow = Nothing
        Dim chk As Boolean = False

        Try



            If e.GridCell.GridColumn.Name.ToString = "ColSel" Then

                If cmbPeriodosAsentado.SelectedIndex >= 0 Then

                    If CambioSel Then
                        dtMulitSelCompleto.Clear()
                        chk = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColSel.ColumnIndex).Value)
                        'ano = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColAno.ColumnIndex).Value)
                        'periodo = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColPeriodo.ColumnIndex).Value)
                        ano = Trim(Split(cmbPeriodosAsentado.Text, ",")(1))
                        periodo = Trim(Split(cmbPeriodosAsentado.Text, ",")(2))
                        folio1 = sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColFolio.ColumnIndex).Value
                        reloj = sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColReloj.ColumnIndex).Value
                        complemento = sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColComple.ColumnIndex).Value
                        tipoperiodo = sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridTipoPeriodo.ColumnIndex).Value

                        If chk Then

                            If swTipoperiodo.Value Then

                                row = dtMulitSelSemana.NewRow

                                row("ano") = ano.Trim
                                row("periodo") = periodo.Trim
                                row("folio") = folio1.Trim
                                row("reloj") = reloj.Trim
                                row("perfin") = IIf(complemento, "81", "80")

                                drEncontrado = dtMulitSelSemana.Rows.Find({row("ano"), row("perfin"), row("reloj")})

                                If Not drEncontrado Is Nothing Then

                                    MessageBox.Show("Debe seleccionar solo un escenario para el empleado '" & reloj.Trim & "' ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                                    sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColSel.ColumnIndex).Value = False

                                Else

                                    dtMulitSelSemana.Rows.Add(row)

                                End If

                            Else

                                row = dtMulitSelCatorcena.NewRow

                                row("ano") = ano.Trim
                                row("periodo") = periodo.Trim
                                row("folio") = folio1.Trim
                                row("reloj") = reloj.Trim
                                row("perfin") = IIf(complemento, "81", "80")

                                drEncontrado = dtMulitSelCatorcena.Rows.Find({row("ano"), row("perfin"), row("reloj")})

                                If Not drEncontrado Is Nothing Then

                                    MessageBox.Show("Debe seleccionar solo un escenario para el empleado '" & reloj.Trim & "' ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                                    sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColSel.ColumnIndex).Value = False

                                Else

                                    dtMulitSelCatorcena.Rows.Add(row)

                                End If


                            End If

                            'If dtMulitSelSemana.Rows.Count > 0 Then
                            '    dtMulitSelCompleto.Merge(dtMulitSelSemana)
                            'End If

                            'If dtMulitSelCatorcena.Rows.Count > 0 Then
                            '    dtMulitSelCompleto.Merge(dtMulitSelCatorcena)
                            'End If

                        Else

                            Dim copia As New DataTable
                            Dim Completo As New DataTable

                            If swTipoperiodo.Value Then

                                copia = DirectCast(dtMulitSelSemana, DataTable)

                                If copia.Select("folio = '" & folio1.Trim & "'").Count > 0 Then

                                    Dim drRow() As DataRow = copia.Select("folio = '" & folio1.Trim & "'")

                                    dtMulitSelSemana.Rows.Remove(drRow(0))

                                End If

                                'Completo = DirectCast(dtMulitSelCompleto, DataTable)

                                'If Completo.Select("folio = '" & folio1.Trim & "'").Count > 0 Then

                                '    Dim drRow() As DataRow = Completo.Select("folio = '" & folio1.Trim & "'")

                                '    dtMulitSelCompleto.Rows.Remove(drRow(0))

                                'End If


                            Else

                                copia = DirectCast(dtMulitSelCatorcena, DataTable)

                                If copia.Select("folio = '" & folio1.Trim & "'").Count > 0 Then

                                    Dim drRow() As DataRow = copia.Select("folio = '" & folio1.Trim & "'")

                                    dtMulitSelCatorcena.Rows.Remove(drRow(0))

                                End If

                                'Completo = DirectCast(dtMulitSelCompleto, DataTable)

                                'If Completo.Select("folio = '" & folio1.Trim & "'").Count > 0 Then

                                '    Dim drRow() As DataRow = Completo.Select("folio = '" & folio1.Trim & "'")

                                '    dtMulitSelCompleto.Rows.Remove(drRow(0))

                                'End If


                            End If

                        End If

                    End If

                    If dtMulitSelSemana.Rows.Count > 0 Then
                        dtMulitSelCompleto.Merge(dtMulitSelSemana)
                    End If

                    If dtMulitSelCatorcena.Rows.Count > 0 Then
                        dtMulitSelCompleto.Merge(dtMulitSelCatorcena)
                    End If


                    If dtMulitSelCompleto.Rows.Count > 0 Then

                        btnAceptar.Enabled = True

                        btnLimpiar.Enabled = True

                    Else

                        btnAceptar.Enabled = False
                        btnLimpiar.Enabled = False

                    End If

                Else

                    MessageBox.Show("Debe seleccionr el periodo a asentar el finiquito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    sdgFiniquitos.PrimaryGrid.GetCell(e.GridCell.RowIndex, GridColSel.ColumnIndex).Value = False
                End If

            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar seleccionar o deseleccionar un folio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        CambioSel = False

    End Sub

    Private Sub sdgFiniquitos_CellValueChanged(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs) Handles sdgFiniquitos.CellValueChanged

        CambioSel = True

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelarFiniquito.Click
        Try
            Dim respuesta As DialogResult

            If dgvFiniquitos.Rows.Count > 0 Then

                If Folio.Trim = "" Then
                    MessageBox.Show("No se puede obtener el folio del finiquito para cancelar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                Dim dtFinAsentado As DataTable = sqlExecute("select * from nomina_calculo where folio = '" & Folio.Trim & "' and asentado_deposito = 1", "NOMINA")

                If (dtFinAsentado.Columns.Contains("ERROR") Or dtFinAsentado.Rows.Count > 0) Then
                    MessageBox.Show("No se pudo cancelar el finiquito con folio '" & Folio & "' por un error ó por que el mismo está asentado para pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If


                respuesta = MessageBox.Show("Esta acción cancelará el finiquito con folio '" & Folio & "'. ¿Desea continuar?", "Cancelación de finiquito", MessageBoxButtons.YesNo)

                If Not respuesta = Windows.Forms.DialogResult.Yes Then Exit Sub

                Dim dtCancelar As DataTable = sqlExecute("update nomina_calculo set [status] = 'CANCELADO' where folio = '" & Folio & "' and reloj = '" & txtReloj.Text.Trim & "'" & vbCr & _
                                                         "select @@ROWCOUNT as 'Actualizado'", "NOMINA")

                Dim cancelado As Integer = -1

                Try : cancelado = Convert.ToInt32(dtCancelar.Rows(0).Item("Actualizado").ToString) : Catch es As Exception : cancelado = -1 : End Try

                If Not cancelado > 0 Then
                    MessageBox.Show("No se pudo cancelar el finiquito con folio '" & Folio & "'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show("El finiquito con folio '" & Folio & "' ha sido cancelado", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    dgvFiniquitos.CurrentRow.Cells("ColStatus").Value = "CANCELADO"

                    Dim Actualizar As DataTable = DirectCast(sdgFiniquitos.PrimaryGrid.DataSource, DataTable)
                    Dim Row As DataRow = Nothing
                    Try : Row = Actualizar.Select("folio = '" & Folio & "' and reloj = '" & txtReloj.Text.Trim & "'")(0) : Catch ex As Exception : Row = Nothing : End Try
                    If Not IsNothing(Row) Then Row("estado") = "CANCELADO"

                    finCancelado = True
                    btnEditar.Text = "Ver"
                    btnCancelarFiniquito.Enabled = False

                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Error en cancelación de folio.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub sdgFiniquitos_SelectionChanged(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridEventArgs) Handles sdgFiniquitos.SelectionChanged

        Dim valor As String = ""
        Dim ano As String = ""
        Dim periodo As String = ""
        Dim folio1 As String = ""
        Dim reloj As String = ""
        Dim Esasentado As Boolean = False

        Try

            FolioSgv = ""

            If Not EscargaInicial And Not ClickFila Then

                If Not (swPoliza.Value Or swdeposito.Value) Then

                    ano = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridPanel.ActiveRow.RowIndex, GridColAno.ColumnIndex).Value)
                    periodo = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridPanel.ActiveRow.RowIndex, GridColPeriodo.ColumnIndex).Value)
                    folio1 = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridPanel.ActiveRow.RowIndex, GridColFolio.ColumnIndex).Value)
                    reloj = Trim(sdgFiniquitos.PrimaryGrid.GetCell(e.GridPanel.ActiveRow.RowIndex, GridColReloj.ColumnIndex).Value)
                    valor = sdgFiniquitos.PrimaryGrid.GetCell(e.GridPanel.ActiveRow.RowIndex, GridColStatus.ColumnIndex).Value
                    Esasentado = sdgFiniquitos.PrimaryGrid.GetCell(e.GridPanel.ActiveRow.RowIndex, GridColDeposito.ColumnIndex).Value

                    Bandera = "EDIT"
                    FolioSgv = folio1.Trim

                    If valor.Trim.ToUpper = "CANCELADO" Or Esasentado Then
                        finCancelado = True
                    Else
                        finCancelado = False
                    End If

                    MostrarInformacion(reloj.Trim)
                    HabilitarBotones()

                End If

            End If
        Catch ex As Exception
            Bandera = ""
            MessageBox.Show("Error al seleccionar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub sdgFiniquitos_RowActivated(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridRowActivatedEventArgs) Handles sdgFiniquitos.RowActivated

    End Sub

    Private Sub TabFiniquitos_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles TabFiniquitos.SelectedTabChanged

        Try

            If Not (swdeposito.Value Or swPoliza.Value) Then
                HabilitarBotones()

                sdgFiniquitos.PrimaryGrid.ClearAll()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub swTipoperiodo_ValueObjectChanged(sender As Object, e As EventArgs) Handles swTipoperiodo.ValueObjectChanged

        Try

            If swdeposito.Value Then

                If swTipoperiodo.Value Then
                    dtLista = sqlExecute(strSQLista & " where (asentado_deposito is null or asentado_deposito = 0) and [Status] = 'CALCULADO' and tipo_periodo = 'S'", "NOMINA")

                Else
                    dtLista = sqlExecute(strSQLista & " where (asentado_deposito is null or asentado_deposito = 0) and [Status] = 'CALCULADO' and tipo_periodo = 'C'", "NOMINA")
                End If
                dtLista.DefaultView.Sort = "Folio"
                sdgFiniquitos.PrimaryGrid.DataSource = dtLista

                CargarPeriodosAsentado()

            Else

                dtPeriodosAsentado = sqlExecute("select convert(char(100),'INDEFINIDO') as tipoperiodo,'' as 'Único','' as 'Año','' as 'Periodo','' as 'Inicio','' as 'Fin'", "TA")
                cmbPeriodosAsentado.DataSource = dtPeriodosAsentado

            End If

        Catch ex As Exception
            MessageBox.Show("Error al  cambiar periodo de asentado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Sub CargarPeriodosAsentado()

        Dim selPerActual As String = ""

        Try

            If swTipoperiodo.Value Then
                dtPeriodosAsentado = sqlExecute("select convert(char(100),'SEMANAL') as tipoperiodo,ano+periodo as 'Único',ano as 'Año',periodo as 'Periodo',CONVERT(varchar,FECHA_INI) as 'Inicio',CONVERT(varchar,FECHA_FIN) as 'Fin'" & _
                                                " from periodos where isnull(asentado,0) = 0 and  isnull(PERIODO_ESPECIAL,0) = 0" & _
                                                "order by ano desc, periodo asc", "TA")
                cmbPeriodosAsentado.DataSource = dtPeriodosAsentado

                dtPeriodoActual = sqlExecute("select  top 1 (ano+periodo) as 'Actual',ano as 'Año',periodo as 'Periodo',FECHA_INI as 'Inicio',FECHA_FIN as 'Fin' " & _
                               "from periodos where isnull(asentado,0) = 0 and  isnull(PERIODO_ESPECIAL,0) = 0 order by ano desc, periodo asc", "TA")

            Else

                dtPeriodosAsentado = sqlExecute("select convert(char(100),'CATORCENAL') as tipoperiodo,ano+periodo as 'Único',ano as 'Año',periodo as 'Periodo',CONVERT(varchar,FECHA_INI) as 'Inicio',CONVERT(varchar,FECHA_FIN) as 'Fin'" & _
                                                " from periodos_catorcenal where isnull(asentado,0) = 0 and  isnull(PERIODO_ESPECIAL,0) = 0" & _
                                                "order by ano desc, periodo asc", "TA")
                cmbPeriodosAsentado.DataSource = dtPeriodosAsentado

                dtPeriodoActual = sqlExecute("select  top 1 (ano+periodo) as 'Actual',ano as 'Año',periodo as 'Periodo',FECHA_INI as 'Inicio',FECHA_FIN as 'Fin' " & _
                          "from periodos_catorcenal where isnull(asentado,0) = 0 and  isnull(PERIODO_ESPECIAL,0) = 0 order by ano desc, periodo asc", "TA")

            End If


            Try : selPerActual = dtPeriodoActual.Rows(0).Item("Actual") : Catch ex As Exception : selPerActual = "" : End Try

            cmbPeriodosAsentado.SelectedValue = selPerActual

        Catch ex As Exception
            MessageBox.Show("Error al  cambiar periodo de asentado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPeriodosAsentado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPeriodosAsentado.SelectedValueChanged
        Dim copia As New DataTable

        Dim Fila As DataRow = Nothing

        Try

            'If Not dtMulitSel.Rows.Count > 0 Then
            '    Exit Sub
            'End If

            'If Not dtMulitSelCompleto.Rows.Count > 0 Then
            '    Exit Sub
            'End If

            If dtMulitSelSemana.Rows.Count > 0 Then
                dtMulitSelSemana.Clear()
            End If

            If dtMulitSelCatorcena.Rows.Count > 0 Then
                dtMulitSelCatorcena.Clear()
            End If

            If Not swdeposito.Value Then Exit Sub

            If Not dtMulitSelCompleto.Rows.Count > 0 Then
                Exit Sub
            End If


            ' dtMulitSel.Clear()

            btnAceptar.Enabled = False

            btnLimpiar.Enabled = False

            'copia = DirectCast(dtMulitSel, DataTable)

            copia = DirectCast(dtMulitSelCompleto, DataTable)

            For Each drRow As DataRow In dtLista.Select("seleccionado = 1")

                drRow("seleccionado") = 0

                If copia.Select("folio = '" & drRow("folio") & "'").Count > 0 Then

                    Fila = copia.Select("folio = '" & drRow("folio") & "'")(0)

                    copia.Rows.Remove(Fila)

                End If


            Next

            ' Try : cmbPeriodosAsentado.SelectedIndex = -1 : Catch ex As Exception : End Try
            sdgFiniquitos.PrimaryGrid.ClearSelectedRows()


        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar quitar de la lista los folios seleccionados ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class