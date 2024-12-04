Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Text
Imports System.Threading

Public Class frmMaestroDeducciones '-- Ernesto -- enero 2023
    Dim editar As Boolean = False
    Dim agregar As Boolean = False
    Dim dP As New DataTable
    Dim dtInfoPer As New DataTable
    Dim dC As New DataTable
    Dim dtDeducciones As New DataTable
    Dim dtConceptosSaldosCa As New DataTable
    Dim dtSaldos As New DataTable
    Dim dtSaldosCa As New DataTable
    Dim S As String
    Dim dtConsultaPer As New DataTable
    Dim tab = ""

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'llenarClaves()
        dtSaldosCa = sqlExecute("SELECT ano,periodo,concepto,saldo_act+abono_alc AS saldo_ant,abono_alc AS abono,saldo_act AS saldo," &
                                "intereses_alc AS intereses,comentario FROM saldos_ca WHERE reloj = 'x'", "nomina")
        mostrarInformacion()
        habilitarBotones()
    End Sub

    Private Sub llenarClaves()
        Try
            Dim dtMtro = sqlExecute("select * from nomina.dbo.mtro_ded where credito is null")
            For Each x In dtMtro.Rows
                Thread.Sleep(10)
                Dim cred = Date.Now.TimeOfDay.ToString.Replace(".", "").Replace(":", "")
                sqlExecute("update nomina.dbo.mtro_ded set credito='" & cred & "' where id=" & x("id"))
                sqlExecute("insert into nomina.dbo.saldos_ca values ('" &
                           x("reloj").ToString.Trim & "','" &
                           x("ini_per").ToString.Trim & "','" &
                           x("ini_ano").ToString.Trim & "','" &
                           x("concepto").ToString.Trim & "','" &
                           cred & "',0,'" & x("ini_saldo") & "','Saldo inicial " & x("ini_saldo").ToString & " Usuario: pida" & "',null)")
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    '==== NAVEGACION DE LA INTERFAZ ENTRE RELOJES
    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        dtConsultaPer = ConsultaPersonalVW("SELECT TOP 1 reloj FROM personalVW ORDER BY reloj ASC ")

        If dtConsultaPer.Rows.Count <> 0 Then
            mostrarInformacion(dtConsultaPer.Rows(0).Item("reloj"))
            btnAgregar.Enabled = IIf(EsBaja, False, True)
            btnCancelar.Enabled = IIf(EsBaja, False, True)
        End If
    End Sub

    Private Sub btnFinal_Click(sender As Object, e As EventArgs) Handles btnFinal.Click
        dtConsultaPer = ConsultaPersonalVW("SELECT TOP 1 reloj FROM personalVW  ORDER BY reloj DESC ")

        If dtConsultaPer.Rows.Count <> 0 Then
            mostrarInformacion(dtConsultaPer.Rows(0).Item("reloj"))
            btnAgregar.Enabled = IIf(EsBaja, False, True)
            btnCancelar.Enabled = IIf(EsBaja, False, True)
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        dtConsultaPer = ConsultaPersonalVW("SELECT TOP 1 reloj FROM personalVW where reloj < '" & txtReloj.Text & "'  ORDER BY reloj DESC ")

        If dtConsultaPer.Rows.Count = 0 Then
            btnPrimero.PerformClick()
        Else
            mostrarInformacion(dtConsultaPer.Rows(0).Item("reloj"))
            btnAgregar.Enabled = IIf(EsBaja, False, True)
            btnCancelar.Enabled = IIf(EsBaja, False, True)
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        dtConsultaPer = ConsultaPersonalVW("SELECT TOP 1 reloj FROM personalVW where reloj > '" & txtReloj.Text & "'  ORDER BY reloj ASC ")

        If dtConsultaPer.Rows.Count = 0 Then
            btnFinal.PerformClick()
        Else
            mostrarInformacion(dtConsultaPer.Rows(0).Item("reloj"))
            btnAgregar.Enabled = IIf(EsBaja, False, True)
            btnCancelar.Enabled = IIf(EsBaja, False, True)
        End If

    End Sub
    '====

    ''' <summary>
    ''' Busqueda por empleado
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtConsultaPer = dtInfoPer
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then mostrarInformacion(Reloj)
            btnAgregar.Enabled = IIf(EsBaja, False, True)
            btnCancelar.Enabled = IIf(EsBaja, False, True)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtInfoPer = dtConsultaPer
        End Try
    End Sub

    ''' <summary>
    ''' Si se adentra el curso dentro de una celda en el datagrid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvMaestro_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMaestro.CellEnter
        Dim colActiva
        Try
            colActiva = dgvMaestro.Item("ColActivo", e.RowIndex).Value
        Catch ex As Exception
            colActiva = False
        End Try
        btnCancelar.Enabled = colActiva
    End Sub

    ''' <summary>
    ''' De los saldo ca, muestra la info del concepto seleccionado
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbConceptoCuenta_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbConceptoCuenta.SelectedValueChanged
        Try
            Dim dtConceptos = sqlExecute("select rtrim(concepto) as concepto from nomina.dbo.mtro_ded")
            Dim strCredito = ""
            Dim strConcepto = ""
            Dim strCon = cmbConceptoCuenta.SelectedValue.ToString.Trim.Substring(0, 6)

            If dtConceptos.Select("concepto='" & strCon & "'").Count > 0 Then
                strConcepto = dtConceptos.Select("concepto='" & strCon & "'").First.Item("concepto").ToString.Trim
                strCredito = cmbConceptoCuenta.SelectedValue.ToString.Trim.Replace(strCon, "")
            Else
                Exit Sub
            End If


            Dim t, dtSaldoIni, dtSaldoActual, dtAbonos, strActivo, strCancelado
            imgEdoConcepto.Image = Nothing
            lblEdoConcepto.Text = ""
            lblSaldoInicial.Text = FormatCurrency(0)
            lblAbonos.Text = FormatCurrency(0)
            lblSaldoAct.Text = FormatCurrency(0)

            If Not cmbConceptoCuenta.DataSource Is Nothing Then
                strActivo = dtDeducciones.Select("credito='" & strCredito & "'").First.Item("activo")
                strCancelado = dtDeducciones.Select("credito='" & strCredito & "'").First.Item("comentario")

                If strActivo Then
                    lblEdoConcepto.Text = "Activo"
                    imgEdoConcepto.Image = My.Resources.acept_
                ElseIf Not strActivo And strCancelado.Contains("cancelación") Then
                    lblEdoConcepto.Text = "Cancelado"
                    imgEdoConcepto.Image = My.Resources.cancel_
                Else
                    lblEdoConcepto.Text = "Liquidado"
                    imgEdoConcepto.Image = My.Resources.medal_
                End If
            End If

            t = sqlExecute("SELECT " & _
                           "(SELECT TOP 1 saldo_act from saldos_ca WHERE reloj = '" & txtReloj.Text & "' AND concepto='" & strConcepto & "' and numcredito= '" & strCredito & "' " & _
                           "ORDER BY ano DESC,periodo ASC) AS saldo_inicial, " & _
                           "(SELECT TOP 1 saldo_act FROM saldos_ca WHERE reloj = '" & txtReloj.Text & "' AND concepto='" & strConcepto & "' and numcredito= '" & strCredito & "' " & _
                           "ORDER BY ano DESC,periodo DESC) AS saldo_final, " & _
                           "SUM(abono_alc) AS abonos " & _
                           "FROM saldos_ca WHERE reloj = '" & txtReloj.Text & "' AND concepto='" & strConcepto & "' and numcredito= '" & strCredito & "'", "NOMINA")

            dtSaldoIni = sqlExecute("SELECT TOP 1 saldo_act+ABONO_ALC AS saldo_inicial,cast(ano as int) as ano,cast(periodo as int) AS periodo FROM saldos_ca WHERE reloj = '" &
                                    txtReloj.Text & "' AND concepto='" & strConcepto & "' and numcredito= '" & strCredito & "' ORDER BY ano ASC,periodo ASC", "NOMINA")
            dtSaldoActual = sqlExecute("SELECT TOP 1 saldo_act AS saldo_final,cast(ano as int) as ano,cast(periodo as int) AS periodo FROM saldos_ca WHERE reloj = '" &
                                       txtReloj.Text & "' AND concepto='" & strConcepto & "' and numcredito= '" & strCredito & "' ORDER BY ano DESC,periodo DESC", "NOMINA")
            dtAbonos = sqlExecute("SELECT SUM(abono_alc) AS abonos FROM saldos_ca WHERE reloj = '" & txtReloj.Text & "' AND concepto='" & strConcepto &
                                  "' and numcredito= '" & strCredito & "'", "NOMINA")

            If t.Rows.Count > 0 Then
                lblSaldoInicial.Text = FormatCurrency(IIf(IsDBNull(dtSaldoIni.Rows(0).Item("saldo_inicial")), 0, dtSaldoIni.Rows(0).Item("saldo_inicial")))
                lblSaldoAct.Text = FormatCurrency(IIf(IsDBNull(dtSaldoActual.Rows(0).Item("saldo_final")), 0, dtSaldoActual.Rows(0).Item("saldo_final")))
                lblAbonos.Text = FormatCurrency(IIf(IsDBNull(dtAbonos.Rows(0).Item("abonos")), 0, dtAbonos.Rows(0).Item("abonos")))
            End If

            dtSaldos = sqlExecute("SELECT ano,periodo,concepto,saldo_act+abono_alc AS saldo_ant,abono_alc AS abono,saldo_act AS saldo," & _
                                  "intereses_alc AS intereses,comentario FROM saldos_ca " & _
                                  "WHERE reloj = '" & txtReloj.Text & "' AND concepto='" & strConcepto & "' and numcredito= '" & strCredito & "'" &
                                  "ORDER BY ano,periodo", "nomina")

            dgvSaldoCuenta.DataSource = dtSaldos
            If dtSaldos.Rows.Count > 0 Then dgvSaldoCuenta.Rows(0).DefaultCellStyle.BackColor = System.Drawing.SystemColors.MenuHighlight

        Catch ex As Exception
            imgEdoConcepto.Image = Nothing
            lblEdoConcepto.Text = ""
            dgvSaldoCuenta.DataSource = dtSaldosCa
        End Try
    End Sub

    ''' <summary>
    ''' Agregar nuevo concepto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim drRespuesta As Windows.Forms.DialogResult
        MtroDedConcepto = "NVO"
        drRespuesta = frmEditarDeducciones.ShowDialog(Me)

        If drRespuesta = Windows.Forms.DialogResult.Abort Then
            MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf drRespuesta = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        mostrarInformacion(txtReloj.Text)
    End Sub

    ''' <summary>
    ''' Cancela concepto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim dblSaldoAct As Double
        Dim strConcepto, strReloj

        Try
            dblSaldoAct = IIf(IsDBNull(dgvMaestro.Item("ColSaldoActual", dgvMaestro.CurrentRow.Index).Value), 0, dgvMaestro.Item("ColSaldoActual", dgvMaestro.CurrentRow.Index).Value.ToString.Trim)
            strConcepto = IIf(IsDBNull(dgvMaestro.Item("colConcepto", dgvMaestro.CurrentRow.Index).Value), "", dgvMaestro.Item("colConcepto", dgvMaestro.CurrentRow.Index).Value.ToString.Trim)
            strReloj = txtReloj.Text
            MtroDedSaldo = dblSaldoAct
            MtroDedConcepto = dgvMaestro.Item("colID", dgvMaestro.CurrentRow.Index).Value.ToString.Trim

            If frmCancelarDeducciones.ShowDialog() = Windows.Forms.DialogResult.Abort Then
                MessageBox.Show("El crédito/préstamo no pudo ser cancelado. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            mostrarInformacion(txtReloj.Text)

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Abre forma para la carga de la cedula de fonacot por creditos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnFonacot_Click(sender As Object, e As EventArgs) Handles btnFonacot.Click
        Try
            frmCredFonacotMtroDed.ShowDialog()
            mostrarInformacion(txtReloj.Text)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la carga del archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRepEmp_Click(sender As Object, e As EventArgs) Handles btnRepEmp.Click
        Try
            If tab = "EdoCuenta" Then
                Dim numCred = cmbConceptoCuenta.Text.Substring((cmbConceptoCuenta.Text.ToString.Trim.Length - 6), 6)
                Dim dtRepDedTot
                Dim c = cmbConceptoCuenta.Text.Substring(0, 10).Trim
                dtRepDedTot = sqlExecute("SELECT saldos_ca.RELOJ,saldos_ca.ANO,saldos_ca.PERIODO,saldos_ca.NUMCREDITO,ABONO_ALC,saldos_ca.SALDO_ACT,saldos_ca.COMENTARIO," &
                                         "mtro_ded.comentario AS DETALLE,INTERESES_ALC, NOMBRES,COD_DEPTO,COD_SUPER,COD_CLASE,COD_TURNO,COD_HORA,COD_PUESTO,COD_TIPO," &
                                         "personalvw.ALTA,personalvw.BAJA,CONCEPTOS.NOMBRE AS CONCEPTO,(SELECT TOP 1 saldo_act from saldos_ca WHERE reloj = '" & txtReloj.Text &
                                         "' AND concepto = mtro_ded.concepto AND (mtro_ded.ini_ano+mtro_ded.ini_per) = saldos_ca.NUMCREDITO ORDER BY ano DESC,periodo ASC) AS SALDO_INICIAL," &
                                         "(SELECT TOP 1 saldo_act from saldos_ca WHERE reloj = '" & txtReloj.Text & "' AND concepto = mtro_ded.concepto AND (mtro_ded.ini_ano+mtro_ded.ini_per) = saldos_ca.NUMCREDITO " &
                                         "ORDER BY ano DESC,periodo DESC) AS SALDO_FINAL FROM nomina.dbo.saldos_ca LEFT JOIN personal.dbo.personalvw ON saldos_ca.reloj= personalvw.reloj " &
                                         "LEFT JOIN nomina.dbo.conceptos ON saldos_ca.concepto = conceptos.concepto LEFT JOIN mtro_ded ON saldos_ca.reloj = mtro_ded.reloj AND " &
                                         "(mtro_ded.ini_ano+mtro_ded.ini_per) = saldos_ca.NUMCREDITO WHERE saldos_ca.reloj = '" & txtReloj.Text & "' AND saldos_ca.concepto = '" & c & _
                                         "' AND mtro_ded.concepto = '" & c & "' AND saldos_ca.NUMCREDITO='" & numCred & "' ORDER BY concepto,numcredito,ano,periodo", "nomina")
                frmVistaPrevia.LlamarReporte("Estado de cuenta maestro de deducciones", dtRepDedTot) : frmVistaPrevia.ShowDialog()
            End If

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Botones para el reporte de resumen de conceptos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegAct_Click(sender As Object, e As EventArgs) Handles btnRegAct.Click
        Try
            Dim dtDed = sqlExecute("select distinct m.reloj,p.nombres,m.concepto,c.nombre,m.ini_ano,m.ini_per,m.ini_saldo as saldo_inicial,m.abono,m.sald_act as saldo_actual, " &
                                   "m.periodos as abonos,m.tipo_perio as tipo_periodo,p.COD_TIPO,p.COD_DEPTO,p.COD_CLASE,p.ALTA,(rtrim(p.COD_PUESTO)+'-'+rtrim(p.nombre_puesto)) as nombre_puesto " &
                                   "from nomina.dbo.mtro_ded m left join nomina.dbo.conceptos c on c.CONCEPTO=m.concepto left join personal.dbo.personalvw p on m.reloj=p.RELOJ where m.activo=1 and " &
                                   "p.baja is null order by m.concepto asc")
            frmVistaPrevia.LlamarReporte("Reporte mtro ded activos", dtDed)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Se habilitan o deshabilitan los botones de interfaz
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub habilitarBotones()
        btnSiguiente.Enabled = Not (editar Or agregar)
        btnPrimero.Enabled = Not (editar Or agregar)
        btnFinal.Enabled = Not (editar Or agregar)
        btnAnterior.Enabled = Not (editar Or agregar)
        btnCancelar.Enabled = Not (editar Or agregar)
        btnCerrar.Enabled = Not (editar Or agregar)
        'btnReportes.Enabled = Not (editar Or agregar)
        btnBuscar.Enabled = Not (editar Or agregar)
        dgvMaestro.ReadOnly = Not (editar Or agregar)
        If editar Or agregar Then btnAgregar.Image = My.Resources.Ok16 : btnAgregar.Text = "Aceptar" Else btnAgregar.Image = My.Resources.NewRecord : btnAgregar.Text = "Agregar"
        btnAgregar.Enabled = IIf(EsBaja, False, True)
        btnCancelar.Enabled = IIf(EsBaja, False, True)
    End Sub

    ''' <summary>
    ''' Refresca la info de la interfaz
    ''' </summary>
    ''' <param name="strReloj"></param>
    ''' <remarks></remarks>
    Public Sub mostrarInformacion(Optional ByVal strReloj As String = "")
        Dim strRutaFoto, filaPer
        Try
            If strReloj = "" Then
                dtInfoPer = ConsultaPersonalVW("SELECT TOP 1 reloj,nombres,cod_tipo,cod_depto,cod_super,cod_clase,cod_turno,cod_hora,nombre_depto,nombre_turno,nombre_horario,nombre_tipoemp," &
                                               "nombre_clase,nombre_super,alta,baja FROM personalVW ORDER BY reloj")
            Else
                dtInfoPer = ConsultaPersonalVW("SELECT TOP 1 reloj,nombres,cod_tipo,cod_depto,cod_super,cod_clase,cod_turno,cod_hora,nombre_depto,nombre_turno,nombre_horario,nombre_tipoemp," &
                                               "nombre_clase,nombre_super,alta,baja FROM personalVW WHERE reloj = '" & strReloj & "' ORDER BY reloj")
            End If

            strReloj = IIf(IsDBNull(dtInfoPer.Rows.Item(0).Item("reloj")), "", dtInfoPer.Rows.Item(0).Item("reloj"))
            filaPer = dtInfoPer.Rows(0)
            txtReloj.Text = IIf(IsDBNull(filaPer("reloj")), "", filaPer("reloj"))
            txtNombres.Text = IIf(IsDBNull(filaPer("nombres")), "", filaPer("nombres"))
            txtAlta.Text = IIf(IsDBNull(filaPer("alta")), Nothing, filaPer("alta"))
            EsBaja = Not IsDBNull(filaPer("baja"))
            txtBaja.Text = IIf(EsBaja, filaPer("baja"), Nothing)
            txtTipoEmp.Text = IIf(IsDBNull(filaPer("cod_tipo")), "", filaPer("cod_tipo").ToString.Trim) & IIf(IsDBNull(filaPer("nombre_tipoemp")), "", " (" & filaPer("nombre_tipoemp").ToString.Trim & ")")
            txtDepto.Text = IIf(IsDBNull(filaPer("cod_depto")), "", filaPer("cod_depto").ToString.Trim) & IIf(IsDBNull(filaPer("nombre_depto")), "", " (" & filaPer("nombre_depto").ToString.Trim & ")")
            txtClase.Text = IIf(IsDBNull(filaPer("cod_clase")), "", filaPer("cod_clase").ToString.Trim) & IIf(IsDBNull(filaPer("nombre_clase")), "", " (" & filaPer("nombre_clase").ToString.Trim & ")")
            txtTurno.Text = IIf(IsDBNull(filaPer("cod_turno")), "", filaPer("cod_turno").ToString.Trim) & IIf(IsDBNull(filaPer("nombre_turno")), "", " (" & filaPer("nombre_turno").ToString.Trim & ")")
            txtCodHora.Text = IIf(IsDBNull(filaPer("cod_hora")), "", filaPer("cod_hora").ToString.Trim) & IIf(IsDBNull(filaPer("nombre_horario")), "", " (" & filaPer("nombre_horario").ToString.Trim & ")")

            Try
                strRutaFoto = PathFoto & strReloj & ".jpg"
                If Dir(strRutaFoto) = "" Then strRutaFoto = PathFoto & "nofoto.png"
                picFoto.ImageLocation = strRutaFoto
            Catch
                picFoto.Image = picFoto.ErrorImage
            End Try

            txtBaja.Visible = EsBaja
            lblFechaBaja.Visible = EsBaja
            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtReloj.BackColor = lblEstado.BackColor

            dtDeducciones = sqlExecute("select id,rtrim(m.concepto) as concepto,c.nombre,m.ini_per,m.ini_ano,ini_saldo,m.periodos,m.abono,m.sald_act,m.activo,comentario,rtrim(credito) as credito " & _
                                       "from nomina.dbo.mtro_ded m left join nomina.dbo.conceptos c on m.concepto=c.concepto " & _
                                       " where m.reloj='" & strReloj & "' order by m.activo desc")
            dgvMaestro.DataSource = dtDeducciones

            dtConceptosSaldosCa = sqlExecute("select distinct conceptos.concepto, rtrim(conceptos.nombre) as nombre,rtrim(numcredito) as numcredito," &
                                             "(rtrim(conceptos.concepto)+''+rtrim(numcredito)) as conceptonum from nomina.dbo.saldos_ca left join nomina.dbo.conceptos on saldos_ca.concepto=conceptos.concepto  " & _
                                             "where reloj = '" & strReloj & "'")
            cmbConceptoCuenta.DataSource = dtConceptosSaldosCa

            btnEditar.Enabled = dtDeducciones.Rows.Count > 0

            'mdg.DataSource = dD : dDD = sqlExecute("select distinct conceptos.concepto, rtrim(conceptos.nombre) as nombre,(ini_ano+ini_per) as numcredito from " & _
            '                               "nomina.dbo.mtro_ded left join nomina.dbo.conceptos on mtro_ded.concepto=conceptos.concepto  " & _
            '                               "where reloj = '" & rl & "'") : ccntp.DataSource = dDD : Exit Sub
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Tab para visualizar los conceptos de mtro ded
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tabEdoCta_Click(sender As Object, e As EventArgs) Handles tabEdoCta.Click, tabEdoCuenta.Click
        tab = "EdoCuenta"
    End Sub

    ''' <summary>
    ''' Tab para visualizar los saldos ca
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tabMtro_Click(sender As Object, e As EventArgs) Handles tabMtro.Click, tabMaestro.Click
        tab = "MtroDed"
    End Sub

    ''' <summary>
    ''' Edicion de conceptos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        MtroDedConcepto = dgvMaestro.Item("colID", dgvMaestro.CurrentRow.Index).Value.ToString.Trim
        frmEditarDeducciones.ShowDialog(Me)
        mostrarInformacion(txtReloj.Text)
    End Sub

End Class