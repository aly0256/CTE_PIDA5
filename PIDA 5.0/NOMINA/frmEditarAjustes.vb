Public Class frmEditarAjustes
    Dim dtConceptos As New DataTable
    Dim dtPeriodos As New DataTable
    Dim dtAjustes As New DataTable
    Dim dtTemp As New DataTable
    Dim dtNaturalezas As New DataTable
    Dim drAjustesNom As DataRow
    Dim Nuevo As Boolean
    Dim tipo_periodo As String = "S"

    Private Sub frmEditarAjustes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub


    Private Sub frmEditarAjustes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PeriodoActivo As String = ""
        Dim dtTipoAjuste As New DataTable
        Dim dtEmpleado As New DataTable
        Dim Reloj As String
        'MCR 20180424
        Dim Comentario As String

        Dim tabla_periodos As String = "periodos"
        Dim TipoAjuste As String = "R"
        Try

            'MCR 2017-10-10
            'Obtener el tipo de periodos, de acuerdo a su información de personal
            Reloj = frmAjustesNomina.txtReloj.Text
            dtTemp = sqlExecute("SELECT tipo_periodo , " & _
                                "RTRIM(ISNULL(dbo.personal.APATERNO, ''))  + ',' + RTRIM(ISNULL(dbo.personal.AMATERNO, '')) + ',' + RTRIM(ISNULL(dbo.personal.NOMBRE, '')) " & _
                                " as nombres FROM personal WHERE reloj = '" & Reloj & "'")
            If dtTemp.Rows.Count = 0 Then
                MessageBox.Show("El empleado " & Reloj & " no fue localizado. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Err.Raise(-1, "Empleado " & Reloj & " no localizado.")
            Else
                tipo_periodo = IIf(IsDBNull(dtTemp.Rows(0)("tipo_periodo")), "S", dtTemp.Rows(0)("tipo_periodo"))
                txtReloj.Text = Reloj
                txtNombre.Text = IIf(IsDBNull(dtTemp.Rows(0)("nombres")), "", dtTemp.Rows(0)("nombres"))
            End If

            Select Case tipo_periodo
                Case "S"
                    tabla_periodos = "periodos"
                    lblPeriodo.Text = "En la semana"
                    lblPeriodo.Tag = "la semana"
                Case "Q"
                    tabla_periodos = "periodos_quincenal"
                    lblPeriodo.Text = "En la quincena"
                    lblPeriodo.Tag = "la quincena"
                Case "M"
                    tabla_periodos = "periodos_mensual"
                    lblPeriodo.Text = "En el mes"
                    lblPeriodo.Tag = "el mes"
            End Select

            'MCR 2017-10-16
            'Concepto depende del tipo de ajuste. Mostrar solo los disponibles para el ajuste seleccionado
            'dtConceptos = sqlExecute("SELECT concepto,RTRIM(conceptos.nombre) AS nombre,convert(char(75), naturalezas.nombre) as naturaleza FROM conceptos LEFT JOIN naturalezas ON " & _
            '                         "conceptos.cod_naturaleza = naturalezas.cod_naturaleza WHERE NOT misce_clave IS NULL", "nomina")
            'cmbConcepto.DataSource = dtConceptos
            'cmbDeduccion.SelectedValue = MtroDedConcepto

            dtTemp = sqlExecute("SELECT top 1 ano+periodo as 'unico' FROM " & tabla_periodos & " WHERE activo = 1 ORDER BY ano DESC,periodo DESC", "TA")
            If dtTemp.Rows.Count > 0 Then
                PeriodoActivo = dtTemp.Rows(0).Item(0)
            End If
            dtPeriodos = sqlExecute("SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin FROM " & tabla_periodos & " ORDER BY ano DESC,periodo ASC", "TA")
            cmbPeriodo.DataSource = dtPeriodos

            'MCR
            '2017-10-16
            'Seleccionar el periodo actual
            'cmbPeriodo.SelectedValue = PeriodoActivo

            'MCR 2017-10-11
            'Agregar el tipo de ajuste a capturar
            dtTipoAjuste.Columns.Add("TIPO")
            dtTipoAjuste.Columns.Add("DESCRIPCION")

            dtTipoAjuste.Rows.Add({"R", "Regular"})
            'dtTipoAjuste.Rows.Add({"D", "Devolución"})
            'dtTipoAjuste.Rows.Add({"M", "Maestro deducciones"})
            cmbTipoConcepto.ValueMember = "tipo"

            cmbTipoConcepto.DataSource = dtTipoAjuste
            '**************

            'MCR 20180424 Se movió del final del procedimiento, ya que en edición, pierde el concepto seleccionado
            cmbTipoConcepto.RefreshItems()
            '*******************************

            'BERE
            'dtAjustes = sqlExecute("SELECT * FROM ajustes_nom WHERE CONCAT(ano,periodo,reloj,concepto,numcredito) = '" & AjustesNomKey & "'", "nomina")
            'MCR 2017-10-11
            'dtAjustes = sqlExecute("SELECT * FROM ajustes_nom WHERE (ano + periodo + reloj + concepto + comentario) = '" & AjustesNomKey & "'", "nomina")
            dtAjustes = sqlExecute("SELECT * FROM ajustes_nom WHERE ID = '" & AjustesNomKey & "'", "nomina")
            If dtAjustes.Rows.Count = 0 Then
                'Si no se localiza el núm. de crédito, es que se va a agregar
                dtAjustes.Rows.Add("")
                drAjustesNom = dtAjustes.Rows(0)
                Nuevo = True
                cmbPeriodo.SelectedValue = ObtenerAnoPeriodo(Now.Date, tipo_periodo)
                cmbConcepto.SelectedIndex = 0
                txtCredito.Text = ""
                'El monto no se modifica, para tomar el default por el tipo de deducción
                'txtMonto.Value = 0
                txtComentario.Text = ""

            Else
                Nuevo = False
                drAjustesNom = dtAjustes.Rows(0)
                TipoAjuste = IIf(IsDBNull(drAjustesNom("tipo_ajuste")), "R", drAjustesNom("tipo_ajuste"))
                cmbTipoConcepto.SelectedValue = TipoAjuste

                cmbPeriodo.SelectedValue = drAjustesNom("ano").ToString.Trim & drAjustesNom("periodo").ToString.Trim
                cmbConcepto.SelectedValue = drAjustesNom("concepto").ToString.Trim
                txtCredito.Text = drAjustesNom("numcredito").ToString.Trim
                txtMonto.Value = IIf(IsDBNull(drAjustesNom("monto")), 0, drAjustesNom("monto"))
                txtSaldoInicial.Value = IIf(IsDBNull(drAjustesNom("saldo_act")), 0, drAjustesNom("saldo_act"))
                txtFechaIncidencia.Value = IIf(IsDBNull(drAjustesNom("fecha_incidencia")), Now, drAjustesNom("fecha_incidencia"))

                'MCR 20180424****
                Comentario = IIf(IsDBNull(drAjustesNom("comentario")), "", drAjustesNom("comentario")).ToString
                If Comentario.StartsWith("Hrs. dobles:") Then
                    Comentario = Comentario.Substring(Comentario.IndexOf(".     ") + 3)
                End If
                txtComentario.Text = Comentario.Trim
                '********20180424
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim Concepto As String
            Dim NumCredito As String
            Dim Naturaleza As String
            Dim dtAjuste As New DataTable
            Dim TipoAjuste As String
            Dim dtaus As DataTable
            Dim dtdev As DataTable
            Dim aplicar_dev As Boolean = False
            Dim tipoaus As String = ""
            Dim dtpersona As New DataTable
            Dim AnoPer As String = ""



            'Dim res, ress As Date

            'If pnlFechaIncidencia.Visible = True Then
            '    dtpersona = sqlExecute("select * from personal where reloj = " & txtReloj.Text & "", "personal")
            '    res = dtpersona.Rows(0).Item("Alta")
            '    ress = FechaSQL(txtFechaIncidencia.Value)
            '    If ress < res Then
            '        MessageBox.Show("Fecha fuera de rango. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        Exit Sub
            '    End If
            'End If

            If txtMonto.Value = 0 Then
                MessageBox.Show("El monto es inválido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMonto.Focus()
                Exit Sub
            End If

            TipoAjuste = cmbTipoConcepto.SelectedValue.ToString.Trim
            Concepto = cmbConcepto.SelectedValue.ToString.Trim
            NumCredito = txtCredito.Text.Trim

            '****Validar si el empleado tiene un ausentismo capturado en la fecha de incidencia
            If TipoAjuste = "D" Then
                dtdev = sqlExecute("select * from tipo_ausentismo where cancelacion = '" & Concepto & "' or devolucion = '" & Concepto & "'", "TA")
                tipoaus = dtdev.Rows(0).Item("tipo_aus")
                dtaus = sqlExecute("select * from ausentismo where reloj = '" & txtReloj.Text & "' and fecha = '" & FechaSQL(txtFechaIncidencia.Value) & "' and tipo_aus = '" & tipoaus & "'", "TA")

                If Not dtaus.Rows.Count > 0 Then
                    MessageBox.Show("No hay ausentismo registrado en la fecha indicada para aplicar la devolución.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                Else
                    aplicar_dev = True
                End If
            End If



            If NumCredito = "" Then
                NumCredito = Year(Now) & Month(Now).ToString.Trim.PadLeft(2, "0") & Now.Day.ToString.Trim.PadLeft(2, "0") & _
                    Hour(Now).ToString.Trim.PadLeft(2, "0") & Minute(Now).ToString.Trim.PadLeft(2, "0") & Second(Now).ToString.Trim.PadLeft(2, "0")
            End If
            drAjustesNom("concepto") = Concepto
            drAjustesNom("monto") = txtMonto.Value
            drAjustesNom("numcredito") = NumCredito
            drAjustesNom("ano") = cmbPeriodo.SelectedValue.ToString.Substring(0, 4)
            drAjustesNom("periodo") = cmbPeriodo.SelectedValue.ToString.Substring(4, 2)
            AnoPer = drAjustesNom("ano") & drAjustesNom("periodo")
            drAjustesNom("tipo_ajuste") = cmbTipoConcepto.SelectedValue.ToString
            drAjustesNom("fecha_incidencia") = txtFechaIncidencia.Value
            drAjustesNom("numperiodos") = txtPeriodos.Value
            drAjustesNom("saldo_act") = txtSaldoInicial.Value

            'Guardar cambios
            If Nuevo Then
                'BERE
                'dtAjuste = sqlExecute("SELECT concepto AS enviado FROM ajustes_nom WHERE CONCAT(ano,periodo,reloj,concepto,numcredito) = '" & _
                '                      cmbPeriodo.SelectedValue.ToString.Substring(0, 4) & cmbPeriodo.SelectedValue.ToString.Substring(4, 2) & _
                '                       txtReloj.Text & Concepto & NumCredito & "'", "NOMINA")
                dtAjuste = sqlExecute("SELECT concepto AS enviado FROM ajustes_nom WHERE (ano + periodo + reloj + concepto + numcredito) = '" & _
                                      cmbPeriodo.SelectedValue.ToString.Substring(0, 4) & cmbPeriodo.SelectedValue.ToString.Substring(4, 2) & _
                                       txtReloj.Text & Concepto & NumCredito & "'", "NOMINA")
                If dtAjuste.Rows.Count > 0 Then
                    MessageBox.Show("No puede haber más de un movimiento del mismo concepto y número de credito durante un periodo. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    cmbConcepto.Focus()

                    Exit Sub
                End If


                If (Not ExistRecCred(txtReloj.Text, cmbPeriodo.SelectedValue.ToString.Substring(0, 4), cmbPeriodo.SelectedValue.ToString.Substring(4, 2), Concepto, NumCredito)) Then
                    sqlExecute("INSERT INTO ajustes_nom (reloj,ano,periodo,concepto,numcredito,tipo_ajuste) " & _
                           "VALUES ('" & txtReloj.Text & "','" & cmbPeriodo.SelectedValue.ToString.Substring(0, 4) & "','" & _
                           cmbPeriodo.SelectedValue.ToString.Substring(4, 2) & "','" & Concepto & "','" & _
                           NumCredito & "','" & cmbTipoConcepto.SelectedValue.ToString & "')", "nomina")
                Else
                    '--Existe registro
                    MessageBox.Show("No puede haber más de un movimiento del mismo concepto y número de credito durante un periodo. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                AjustesNomKey = sqlExecute("select top(1) ID from ajustes_nom order by ID desc", "NOMINA").Rows(0).Item("ID")

            End If

            'MCR 2018-04-19
            'Proceso para separar horas extras en dobles/triples para periodos anteriores, y quincenales
            If Concepto = "HRSEXA" Or Concepto = "HRSEXT" Then
                HrsExtrasMiscelaneos(AjustesNomKey, Concepto, tipo_periodo, FechaSQL(txtFechaIncidencia.Value), txtReloj.Text, txtMonto.Value, AnoPer)
                anComentario = anComentario & ".     " & vbCrLf & txtComentario.Text.Trim
            Else
                anComentario = txtComentario.Text.Trim
            End If

            '************MCR 20180419

            dtAjuste = sqlExecute("SELECT cod_naturaleza FROM conceptos WHERE concepto= '" & Concepto & "'", "nomina")
            If dtAjuste.Rows.Count = 0 Then
                Naturaleza = "I"
            Else
                Naturaleza = IIf(IsDBNull(dtAjuste.Rows(0).Item(0)), "I", dtAjuste.Rows(0).Item(0))
            End If
            'BERE
            'sqlExecute("UPDATE ajustes_nom SET ano = '" & cmbPeriodo.SelectedValue.ToString.Substring(0, 4) & "', periodo = '" & _
            '           cmbPeriodo.SelectedValue.ToString.Substring(4, 2) & "',per_ded = '" & Naturaleza.Trim & _
            '           "', clave = (SELECT misce_clave FROM conceptos WHERE concepto like '%" & Concepto & "%'),monto = " & txtMonto.Value & _
            '           ",comentario = '" & txtComentario.Text.Trim & "',concepto = '" & Concepto & "', usuario = '" & Usuario & _
            '           "',fecha = '" & FechaSQL(Now) & "',cap_nomina = 1 WHERE CONCAT(ano,periodo,reloj,rtrim(concepto),numcredito) = '" & _
            '           AjustesNomKey & "'", "nomina")
            sqlExecute("UPDATE ajustes_nom SET " & _
                       "ano = '" & cmbPeriodo.SelectedValue.ToString.Substring(0, 4) & _
                       "', periodo = '" & cmbPeriodo.SelectedValue.ToString.Substring(4, 2) & _
                       "',per_ded = '" & Naturaleza.Trim & _
                       "', clave = (SELECT misce_clave FROM conceptos WHERE concepto like '%" & Concepto & "%'), " & _
                       "monto = " & txtMonto.Value & _
                       ",comentario = '" & anComentario & _
                       "',concepto = '" & Concepto & _
                       "', usuario = '" & Usuario & _
                       "',fecha = '" & FechaSQL(Now) & _
                       "',cap_nomina = 1  " & _
                       ", numcredito = '" & NumCredito & "' " & _
                       ", tipo_periodo = '" & tipo_periodo & "'" & _
                       ", tipo_ajuste = '" & cmbTipoConcepto.SelectedValue.ToString.Trim & "' " & _
                       ", fecha_incidencia = " & IIf(txtFechaIncidencia.Visible, "'" & FechaSQL(txtFechaIncidencia.Value) & "' ", "NULL ") & _
                       ", numperiodos = " & IIf(TipoAjuste = "M", txtPeriodos.Value & " ", "NULL ") & _
                       ", saldo_act = " & IIf(TipoAjuste = "M", txtSaldoInicial.Value & " ", "NULL ") & _
                       ", hrs_dobles = " & IIf(Math.Round(anDobles, 2) > 0, Math.Round(anDobles, 2) & " ", "NULL ") & _
                       ", hrs_triples = " & IIf(Math.Round(anTriples, 2) > 0, Math.Round(anTriples, 2) & " ", "NULL ") & _
                       ", semana_pago = " & IIf((anPerS + anSem).ToString.Length > 0, "'" & anPerS & IIf(anSem.Length > 0, "_" & anSem & "' ", "'"), "NULL ") & _
                       "WHERE ID = '" & _
                       AjustesNomKey & "'", "nomina")


            '2019-04-17 RETROACTIVO ES_RETRO ABRAHAM CASAS
            Try
                Dim es_retro As Boolean = False

                If Concepto.Trim.ToLower = "retro" Then
                    es_retro = True
                Else

                    If txtFechaIncidencia.Visible = True Then

                        Dim dtAplicaRetro As DataTable = sqlExecute("" & _
                        "select ajustes_nom.reloj, ajustes_nom.concepto, ajustes_nom.FECHA_INCIDENCIA, ajustes_nom.ano, ajustes_nom.periodo, ajustes_nom.es_retro from" & Space(1) & _
                        "ajustes_nom left join ta.dbo.periodos on ajustes_nom.ano = periodos.ano and ajustes_nom.PERIODO = periodos.periodo where" & Space(1) & _
                        "ajustes_nom.TIPO_PERIODO = 'S' and " & Space(1) & _
                        "ajustes_nom.concepto in (select concepto from conceptos where MISCE_FECHA = '1') and" & Space(1) & _
                        "(ajustes_nom.FECHA_INCIDENCIA < periodos.FECHA_INI or ajustes_nom.FECHA_INCIDENCIA is null)" & Space(1) & _
                        "and ajustes_nom.ano >= '2019'" & Space(1) & _
                        "and ajustes_nom.reloj = '" & txtReloj.Text & "' and ajustes_nom.concepto = '" & Concepto & "' and ajustes_nom.FECHA_INCIDENCIA = '" & FechaSQL(txtFechaIncidencia.Value) & "'", "nomina")

                        If dtAplicaRetro.Rows.Count > 0 Then
                            es_retro = True
                        End If

                    End If

                End If

                If es_retro = True Then
                    sqlExecute("update ajustes_nom set es_retro = '1' WHERE ID = '" & AjustesNomKey & "'", "nomina")
                End If
            Catch ex As Exception

            End Try


            If aplicar_dev Then
                sqlExecute("update ausentismo set tipo_aus = 'D" & tipoaus & "' where reloj = '" & txtReloj.Text & "' and fecha = '" & FechaSQL(txtFechaIncidencia.Value) & "' and tipo_aus = '" & tipoaus & "'", "TA")
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        End Try
    End Sub

    Private Function ExistRecCred(ByVal R As String, ByVal A As String, ByVal P As String, ByVal C As String, ByVal NC As String) As Boolean
        '-
        Try
            Dim dtRec As DataTable = sqlExecute("SELECT * from ajustes_nom where RELOJ='" & R & "' AND ANO='" & A & "' AND PERIODO='" & P & "' AND CONCEPTO='" & C & "' AND NUMCREDITO='" & NC & "'", "NOMINA")
            If (Not dtRec.Columns.Contains("ERROR") And dtRec.Rows.Count > 0) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub cmbConcepto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbConcepto.SelectedValueChanged
        Try
            If cmbConcepto.SelectedValue Is Nothing Then Exit Sub
            dtTemp = sqlExecute("SELECT cod_naturaleza,misce_monto FROM conceptos WHERE concepto = '" & cmbConcepto.SelectedValue.ToString.Trim & "'", "nomina")
            If dtTemp.Rows.Count > 0 Then
                txtMonto.Value = IIf(IsDBNull(dtTemp.Rows(0).Item("misce_monto")), 0, dtTemp.Rows(0).Item("misce_monto"))
            End If

            dtTemp = sqlExecute("select * from conceptos where misce_fecha = '1' and concepto = '" & cmbConcepto.SelectedValue & "'", "nomina")
            pnlFechaIncidencia.Visible = dtTemp.Rows.Count
            If dtTemp.Rows.Count Then
                If cmbTipoConcepto.SelectedValue = "D" Then
                    pnlMonto.Visible = False
                    txtMonto.Value = 1
                Else
                    pnlMonto.Visible = True
                    txtMonto.Value = 1
                End If
                ' devolucion = True

            Else
                ' devolucion = False
                pnlMonto.Visible = True
                txtMonto.Value = 1
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbTipoConcepto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoConcepto.SelectedValueChanged
        Dim Tipo As String
        Try
            If cmbTipoConcepto.SelectedValue Is Nothing Then
                Exit Sub
            End If
            Tipo = cmbTipoConcepto.SelectedValue.ToString.Trim

            If Tipo = "R" Then
                pnlNumPeriodos.Visible = False
                'pnlFechaIncidencia.Visible = False
                pnlSaldo.Visible = False
                pnlCreditoFolio.Visible = True
                'pnlMonto.Visible = True
                lblPeriodo.Text = "En " & lblPeriodo.Tag

                dtConceptos = sqlExecute("SELECT concepto,RTRIM(conceptos.nombre) AS nombre,convert(char(75), naturalezas.nombre) as naturaleza FROM conceptos " & _
                          "LEFT JOIN naturalezas ON conceptos.cod_naturaleza = naturalezas.cod_naturaleza " & _
                          "WHERE NOT (misce_clave IS NULL OR MISCE_CLAVE = 0) and not concepto  in " & _
                          "(select distinct ISNULL(cancelacion,devolucion) AS concepto FROM ta.dbo.tipo_ausentismo " & _
                          "WHERE NOT (cancelacion IS NULL and devolucion IS NULL)) AND (aplica_mtro_ded IS NULL OR APLICA_MTRO_DED = 0) ", "nomina")
            ElseIf Tipo = "D" Then
                pnlNumPeriodos.Visible = False
                pnlCreditoFolio.Visible = False
                pnlSaldo.Visible = False
                'pnlFechaIncidencia.Visible = True
                'pnlMonto.Visible = False
                'txtMonto.Value = 1
                lblPeriodo.Text = "En " & lblPeriodo.Tag

                dtConceptos = sqlExecute("SELECT concepto,RTRIM(conceptos.nombre) AS nombre,convert(char(75), naturalezas.nombre) as naturaleza FROM conceptos " & _
                                         "LEFT JOIN naturalezas ON conceptos.cod_naturaleza = naturalezas.cod_naturaleza " & _
                                         "WHERE NOT (misce_clave IS NULL OR MISCE_CLAVE = 0) and concepto  in " & _
                                         "(select distinct ISNULL(cancelacion,devolucion) AS concepto FROM ta.dbo.tipo_ausentismo " & _
                                         "WHERE NOT (cancelacion IS NULL and devolucion IS NULL)) AND (aplica_mtro_ded IS NULL OR APLICA_MTRO_DED = 0) ", "nomina")
            ElseIf Tipo = "M" Then
                pnlNumPeriodos.Visible = True
                'pnlFechaIncidencia.Visible = False
                pnlSaldo.Visible = True
                pnlCreditoFolio.Visible = True
                'pnlMonto.Visible = True
                lblPeriodo.Text = "Desde " & lblPeriodo.Tag

                dtConceptos = sqlExecute("SELECT concepto,RTRIM(conceptos.nombre) AS nombre,convert(char(75), naturalezas.nombre) as naturaleza FROM conceptos " & _
                                         "LEFT JOIN naturalezas ON conceptos.cod_naturaleza = naturalezas.cod_naturaleza " & _
                                         "WHERE NOT (misce_clave IS NULL OR MISCE_CLAVE = 0) and not concepto  in " & _
                                         "(select distinct ISNULL(cancelacion,devolucion) AS concepto FROM ta.dbo.tipo_ausentismo " & _
                                         "WHERE NOT (cancelacion IS NULL and devolucion IS NULL)) AND (aplica_mtro_ded =1) ", "Nomina")
            End If


            cmbConcepto.DataSource = dtConceptos

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtSaldoInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtSaldoInicial.ValueChanged
        If txtMonto.Value > 0 Then
            txtPeriodos.Value = txtSaldoInicial.Value / txtMonto.Value
        End If
    End Sub

    Private Sub txtMonto_ValueChanged(sender As Object, e As EventArgs) Handles txtMonto.ValueChanged
        If txtMonto.Value > 0 Then
            txtPeriodos.Value = txtSaldoInicial.Value / txtMonto.Value
        End If
    End Sub

End Class