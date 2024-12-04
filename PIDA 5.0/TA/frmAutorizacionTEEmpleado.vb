Public Class frmAutorizacionTEEmpleado
    Dim AnoTE As String
    Dim PeriodoTE As String
    Dim DiasAut As Integer
    Dim dtEmp As New DataTable


    Public Sub InicioNuevo(ByVal AnoPeriodo As String)
        AnoTE = AnoPeriodo.Substring(0, 4)
        PeriodoTE = AnoPeriodo.Substring(4, 2)
        txtReloj.Focus()
    End Sub

    Public Sub MostrarInformacion(ByVal ID As String, Optional ByVal Nuevo As Boolean = False)
        Dim Reloj As String
        Dim Ano As String
        Dim Periodo As String
        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim Activo As Boolean
        Dim dtDeptos As New DataTable
        Dim dtPeriodos As New DataTable


        Try
            txtReloj.Enabled = Nuevo
            If ID.Length = LongReloj Then
                Reloj = ID
            ElseIf ID.Length = LongReloj + 6 Then
                Reloj = ID.Substring(0, LongReloj).ToString.Trim
                AnoTE = ID.Substring(LongReloj, 4).ToString.Trim
                PeriodoTE = ID.Substring(LongReloj + 4, 2).ToString.Trim
            Else
                Exit Sub
            End If

            Ano = AnoTE
            Periodo = PeriodoTE

            lblPeriodo.Text = "PERIODO " & Ano & " - " & Periodo

            dtPeriodos = sqlExecute("SELECT fecha_ini,fecha_fin FROM periodos WHERE ano = '" & AnoTE & "' AND periodo = '" & PeriodoTE & "'", "TA")
            FechaIni = dtPeriodos.Rows(0).Item("fecha_ini")
            FechaFin = dtPeriodos.Rows(0).Item("fecha_fin")

            dtEmp = ConsultaPersonalVW("SELECT nombres,nombre_depto,nombre_super,nombre_puesto,nombre_turno,nombre_tipoEmp,alta,baja,cod_comp " & _
                                       "FROM personalVW WHERE reloj = '" & Reloj & "'", False)
            txtReloj.Text = Reloj
            txtNombre.Text = IIf(IsDBNull(dtEmp.Rows(0).Item("nombres")), "", dtEmp.Rows(0).Item("nombres"))
            txtDepartamento.Text = IIf(IsDBNull(dtEmp.Rows(0).Item("nombre_depto")), "", dtEmp.Rows(0).Item("nombre_depto"))
            txtSupervisor.Text = IIf(IsDBNull(dtEmp.Rows(0).Item("nombre_super")), "", dtEmp.Rows(0).Item("nombre_super"))
            txtPuesto.Text = IIf(IsDBNull(dtEmp.Rows(0).Item("nombre_puesto")), "", dtEmp.Rows(0).Item("nombre_puesto"))
            txtTurno.Text = IIf(IsDBNull(dtEmp.Rows(0).Item("nombre_turno")), "", dtEmp.Rows(0).Item("nombre_turno"))
            txtTipo.Text = IIf(IsDBNull(dtEmp.Rows(0).Item("nombre_tipoEmp")), "", dtEmp.Rows(0).Item("nombre_tipoEmp"))
            txtAlta.Text = IIf(IsDBNull(dtEmp.Rows(0).Item("alta")), "", FechaCortaLetra(dtEmp.Rows(0).Item("alta")))
            If IsDBNull(dtEmp.Rows(0).Item("baja")) Then
                txtBaja.Text = ""
                Activo = dtEmp.Rows(0).Item("alta") < FechaFin
            Else
                txtBaja.Text = FechaCortaLetra(dtEmp.Rows(0).Item("baja"))
                Activo = dtEmp.Rows(0).Item("baja") > FechaFin
            End If
            txtComp.Text = IIf(IsDBNull(dtEmp.Rows(0).Item("cod_comp")), "", dtEmp.Rows(0).Item("cod_comp"))

            dtDeptos = sqlExecute("SELECT cod_depto,nombre FROM deptos WHERE cod_comp = '" & txtComp.Text.Trim.Trim & "'")
            cmbDepto1.DataSource = dtDeptos.Copy
            cmbDepto2.DataSource = dtDeptos.Copy
            cmbDepto3.DataSource = dtDeptos.Copy
            cmbDepto4.DataSource = dtDeptos.Copy
            cmbDepto5.DataSource = dtDeptos.Copy
            cmbDepto6.DataSource = dtDeptos.Copy
            cmbDepto7.DataSource = dtDeptos.Copy

            LlenarDia(pnlDia1, DateAdd(DateInterval.Day, 0, FechaIni), Reloj)
            LlenarDia(pnlDia2, DateAdd(DateInterval.Day, 1, FechaIni), Reloj)
            LlenarDia(pnlDia3, DateAdd(DateInterval.Day, 2, FechaIni), Reloj)
            LlenarDia(pnlDia4, DateAdd(DateInterval.Day, 3, FechaIni), Reloj)
            LlenarDia(pnlDia5, DateAdd(DateInterval.Day, 4, FechaIni), Reloj)
            LlenarDia(pnlDia6, DateAdd(DateInterval.Day, 5, FechaIni), Reloj)
            LlenarDia(pnlDia7, DateAdd(DateInterval.Day, 6, FechaIni), Reloj)


            lblEstado.Text = IIf(Not Activo, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(Not Activo, Color.IndianRed, Color.LimeGreen)
            txtReloj.BackColor = lblEstado.BackColor
            lblBaja.Visible = Not Activo
            txtBaja.Visible = Not Activo

            SumaHorasReales()
            gpDetalle.Visible = True

            If pnlDia1.Enabled Then
                txtAutorizadas1.Focus()
            ElseIf pnlDia2.Enabled Then
                txtAutorizadas2.Focus()
            ElseIf pnlDia3.Enabled Then
                txtAutorizadas3.Focus()
            ElseIf pnlDia4.Enabled Then
                txtAutorizadas4.Focus()
            ElseIf pnlDia5.Enabled Then
                txtAutorizadas5.Focus()
            ElseIf pnlDia6.Enabled Then
                txtAutorizadas6.Focus()
            ElseIf pnlDia7.Enabled Then
                txtAutorizadas7.Focus()
            End If
        Catch ex As Exception
            Stop
        End Try
    End Sub

    Private Sub LlenarDia(ByVal PanelCtrl As System.Windows.Forms.Panel, ByVal Fecha As Date, ByVal R As String)
        Dim Num As String
        Dim Activo As Boolean
        Dim dtAsist As New DataTable
        Dim dtAutorizadas As New DataTable
        Dim Nombre As String
        Dim i As Integer

        Dim Aus As String = ""
        Dim ExR As String = ""
        Dim ExA As String = ""
        Dim HoraEnt As String = ""
        Dim HoraSal As String = ""
        Dim DeptoTran As String = ""
        Dim Motivo As String = ""
        Dim Entra As String = ""

        Try
            Num = PanelCtrl.Name.Substring(PanelCtrl.Name.Trim.Length - 1).Trim
            dtAutorizadas = sqlExecute("SELECT entrada,salida,extras_autorizadas,RTRIM(comentario) as comentario,depto_transferencia " & _
                                       "FROM extras_autorizadas WHERE reloj = '" & R & "' AND fecha ='" & FechaSQL(Fecha) & "'", "TA")

            If dtAutorizadas.Rows.Count > 0 Then
                HoraEnt = IIf(IsDBNull(dtAutorizadas.Rows(0).Item("entrada")), "", dtAutorizadas.Rows(0).Item("entrada")).ToString.Trim
                HoraSal = IIf(IsDBNull(dtAutorizadas.Rows(0).Item("salida")), "", dtAutorizadas.Rows(0).Item("salida")).ToString.Trim
                ExA = IIf(IsDBNull(dtAutorizadas.Rows(0).Item("extras_autorizadas")), "", dtAutorizadas.Rows(0).Item("extras_autorizadas"))
                Motivo = IIf(IsDBNull(dtAutorizadas.Rows(0).Item("comentario")), "", dtAutorizadas.Rows(0).Item("comentario")).ToString.Trim
                DeptoTran = IIf(IsDBNull(dtAutorizadas.Rows(0).Item("depto_transferencia")), "", dtAutorizadas.Rows(0).Item("depto_transferencia"))
            End If

            dtAsist = sqlExecute("SELECT horas_extras,extras_autorizadas,cod_depto,tipo_ausentismo.nombre as ausentismo " & _
                          ", salio FROM asist LEFT JOIN tipo_ausentismo ON asist.tipo_aus = tipo_ausentismo.tipo_aus " & _
                           "WHERE reloj = '" & R & "' AND fha_ent_hor ='" & FechaSQL(Fecha) & "'", "TA")

            If dtAsist.Rows.Count > 0 Then
                ExR = IIf(IsDBNull(dtAsist.Rows(0).Item("horas_extras")), "00:00", dtAsist.Rows(0).Item("horas_extras"))
                If ExA = "" Then
                    ExA = IIf(IsDBNull(dtAsist.Rows(0).Item("extras_autorizadas")), "00:00", dtAsist.Rows(0).Item("extras_autorizadas"))
                End If

                HoraEnt = IIf(HoraEnt = "", dtAsist.Rows(0).Item("salio"), HoraEnt).ToString.Trim
                If HoraEnt <> "" And dtAsist.Rows(0).Item("salio").ToString.Trim <> "" Then
                    HoraSal = IIf(HoraSal = "", DateAdd(DateInterval.Hour, HtoD(ExA), dtAsist.Rows(0).Item("salio")), HoraSal)
                Else
                    HoraSal = ""
                End If
                DeptoTran = IIf(DeptoTran = "", IIf(IsDBNull(dtAsist.Rows(0).Item("cod_depto")), "", dtAsist.Rows(0).Item("cod_depto")), DeptoTran)
                Aus = IIf(IsDBNull(dtAsist.Rows(0).Item("ausentismo")), "", dtAsist.Rows(0).Item("ausentismo"))
            End If

            If IsDBNull(dtEmp.Rows(0).Item("baja")) Then
                Activo = dtEmp.Rows(0).Item("alta") <= Fecha
            Else
                Activo = dtEmp.Rows(0).Item("baja") >= Fecha
            End If

            'Poner en el tag el horario
            dtTemporal = sqlExecute("select entra,sale,descanso from dias LEFT JOIN personal ON dias.cod_comp = personal.cod_comp " & _
                                    "AND dias.cod_hora = personal.cod_hora where reloj = '" & R & "' and cod_dia = '" & Num & "'")
            If dtTemporal.Rows.Count > 0 Then
                If dtTemporal.Rows(0).Item("descanso") = 1 Then
                    'Si es día de descanso, el tiempo extra inicia en la hora de entrada (por default)
                    Entra = dtTemporal.Rows(0).Item("entra")
                Else
                    'Si no es día de descanso, el tiempo extra inicia a la salida (por default)
                    Entra = dtTemporal.Rows(0).Item("sale")
                End If
            Else
                Entra = HoraEnt
            End If

            If HoraEnt = "" Then
                HoraEnt = Entra
            End If

            For Each cont As Control In PanelCtrl.Controls
                Nombre = cont.Name.Trim
                Select Case Nombre
                    Case "lblDia" & Num
                        cont.Text = DiaSem(Fecha)
                    Case "lblFecha" & Num
                        cont.Text = FechaCortaLetra(Fecha)
                        cont.Tag = Fecha
                    Case "lblAusentismo" & Num
                        cont.Text = Aus
                    Case "lblExtraReales" & Num
                        cont.Text = IIf(ExR = "", "00:00", ExR)
                    Case "txtAutorizadas" & Num
                        cont.Text = IIf(ExA = "", "00:00", ExA)
                    Case "txtHoraEntrada" & Num
                        cont.Text = HoraEnt
                        cont.Tag = Entra
                    Case "txtHoraSalida" & Num
                        cont.Text = HoraSal
                        cont.Tag = Entra
                    Case "cmbDepto" & Num
                        cont.Text = DeptoTran
                    Case "txtMotivo" & Num
                        cont.Text = Motivo
                    Case "lblActivo" & Num
                        cont.Visible = Not Activo
                End Select
            Next

            i = 0
            If Fecha < Now.Date Then
                Do Until Fecha = Now.Date
                    If Not DiaDescanso(Fecha, R) Then
                        i += 1
                    End If
                    If i > DiasAut Then Exit Do
                    Fecha = DateAdd(DateInterval.Day, 1, Fecha)
                Loop
            ElseIf Fecha > Now.Date Then
                Do Until Fecha = Now.Date
                    If Not DiaDescanso(Fecha) Then
                        i += 1
                    End If
                    If i > DiasAut Then Exit Do
                    Fecha = DateAdd(DateInterval.Day, -1, Fecha)
                Loop
            End If

            PanelCtrl.Enabled = (i <= DiasAut) And Activo
        Catch ex As Exception
            Stop
        End Try
    End Sub

    Private Sub GuardaCambios(ByVal PanelCtrl As System.Windows.Forms.Panel)
        Dim Nombre As String
        Dim Num As String
        Dim F As String = ""
        Dim ExA As String = "00:00"
        Dim ExR As String = "00:00"
        Dim Entrada As DateTime
        Dim Salida As DateTime
        Dim Depto As String = ""
        Dim Motivo As String = ""
        Dim R As String
        Dim Editar As Boolean = False

        Dim dtAut As New DataTable
        Dim dtEmpleado As New DataTable
        Try
            Num = PanelCtrl.Name.Substring(PanelCtrl.Name.Trim.Length - 1).Trim
            R = txtReloj.Text.Trim
            For Each cont As Control In PanelCtrl.Controls
                Nombre = cont.Name.Trim
                Select Case Nombre
                    Case "lblFecha" & Num
                        F = FechaSQL(cont.Tag)
                    Case "lblExtraReales" & Num
                        ExR = cont.Text
                    Case "txtAutorizadas" & Num
                        ExA = cont.Text
                    Case "txtHoraEntrada" & Num
                        Entrada = IIf(cont.Text = "", New DateTime, cont.Text)
                    Case "txtHoraSalida" & Num
                        Salida = IIf(cont.Text = "", New DateTime, cont.Text)
                    Case "cmbDepto" & Num
                        Dim cmb As DevComponents.DotNetBar.Controls.ComboTree = cont
                        Depto = cmb.SelectedValue
                    Case "txtMotivo" & Num
                        Motivo = cont.Text
                End Select
            Next
            dtAut = sqlExecute("SELECT entrada,salida,extras_reales,extras_autorizadas,comentario,depto_transferencia " & _
                               "FROM extras_autorizadas WHERE reloj = '" & R & "' AND fecha ='" & F & "'", "TA")
            If dtAut.Rows.Count = 0 Then
                sqlExecute("INSERT INTO extras_autorizadas (reloj,fecha) VALUES ('" & R & "','" & F & "')", "ta")
                dtAut = sqlExecute("SELECT entrada,salida,extras_reales,extras_autorizadas,comentario,depto_transferencia " & _
                               "FROM extras_autorizadas WHERE reloj = '" & R & "' AND fecha ='" & F & "'", "TA")
            End If

            If Entrada <> IIf(IsDBNull(dtAut.Rows(0).Item("entrada")), Nothing, dtAut.Rows(0).Item("entrada")) Then
                sqlExecute("UPDATE extras_autorizadas SET entrada = '" & Entrada.ToShortTimeString & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                Editar = True
            End If

            If Salida <> IIf(IsDBNull(dtAut.Rows(0).Item("salida")), Nothing, dtAut.Rows(0).Item("salida")) Then
                sqlExecute("UPDATE extras_autorizadas SET salida = '" & Salida.ToShortTimeString & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                Editar = True
            End If

            If ExR <> IIf(IsDBNull(dtAut.Rows(0).Item("extras_reales")), "00:00", dtAut.Rows(0).Item("extras_reales")) Then
                sqlExecute("UPDATE extras_autorizadas SET extras_reales = '" & ExR & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                Editar = True
            End If

            If ExA <> IIf(IsDBNull(dtAut.Rows(0).Item("extras_autorizadas")), "00:00", dtAut.Rows(0).Item("extras_autorizadas")) Then
                sqlExecute("UPDATE extras_autorizadas SET extras_autorizadas = '" & ExA & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                Editar = True
            End If

            If Motivo <> IIf(IsDBNull(dtAut.Rows(0).Item("comentario")), "", dtAut.Rows(0).Item("comentario")).ToString.Trim Then
                sqlExecute("UPDATE extras_autorizadas SET comentario = '" & Motivo & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                Editar = True
            End If

            If Depto <> IIf(IsDBNull(dtAut.Rows(0).Item("depto_transferencia")), "", dtAut.Rows(0).Item("depto_transferencia")) Then
                sqlExecute("UPDATE extras_autorizadas SET depto_transferencia = '" & Depto & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                Editar = True
            End If

            If Editar Then
                dtEmpleado = sqlExecute("SELECT cod_super,cod_depto FROM PERSONAL WHERE RELOJ = '" & R & "'")
                sqlExecute("UPDATE extras_autorizadas SET cod_super = '" & dtEmpleado.Rows(0).Item("COD_SUPER") & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                sqlExecute("UPDATE extras_autorizadas SET cod_depto = '" & dtEmpleado.Rows(0).Item("COD_DEPTO") & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                sqlExecute("UPDATE extras_autorizadas SET periodo = '" & PeriodoTE & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                sqlExecute("UPDATE extras_autorizadas SET ano = '" & AnoTE & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                sqlExecute("UPDATE extras_autorizadas SET usuario_s = '" & Usuario & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                sqlExecute("UPDATE extras_autorizadas SET fecha_s = '" & FechaSQL(Now.Date) & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                sqlExecute("UPDATE extras_autorizadas SET envio_s = 0,aplicado = 0,analizado = 0  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtReloj_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtReloj.Validating
        Dim dtEmp As New DataTable
        If txtReloj.Text = "" Then Exit Sub
        txtReloj.Text = txtReloj.Text.Trim.PadLeft(LongReloj, "0")

        dtEmp = ConsultaPersonalVW("select reloj FROM personalVW WHERE reloj = '" & txtReloj.Text & "'")
        If dtEmp.Rows.Count = 0 Then
            gpDetalle.Visible = False
            MessageBox.Show("El número de reloj " & txtReloj.Text & " no fue localizado, o el usuario no tiene acceso a su consulta. Favor de verificar", _
                            "Número inexistente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        Else
            MostrarInformacion(txtReloj.Text, True)
        End If
    End Sub

    Private Sub frmAutorizacionTEEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtTemporal = sqlExecute("SELECT dias_autorizacionTE FROM perfiles WHERE cod_perfil " & Perfil, "seguridad")
        DiasAut = IIf(IsDBNull(dtTemporal.Rows(0).Item("dias_autorizacionTE")), 1, dtTemporal.Rows(0).Item("dias_autorizacionTE"))
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtHoraEntrada1_Leave(sender As Object, e As EventArgs) Handles txtHoraEntrada1.Leave
        txtHoraSalida1.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas1.Text.Trim), txtHoraEntrada1.Value)
    End Sub
    Private Sub txtHoraEntrada2_Leave(sender As Object, e As EventArgs) Handles txtHoraEntrada2.Leave
        txtHoraSalida2.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas2.Text.Trim), txtHoraEntrada2.Value)
    End Sub
    Private Sub txtHoraEntrada3_Leave(sender As Object, e As EventArgs) Handles txtHoraEntrada3.Leave
        txtHoraSalida3.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas3.Text.Trim), txtHoraEntrada3.Value)
    End Sub
    Private Sub txtHoraEntrada4_Leave(sender As Object, e As EventArgs) Handles txtHoraEntrada4.Leave
        txtHoraSalida4.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas4.Text.Trim), txtHoraEntrada4.Value)
    End Sub
    Private Sub txtHoraEntrada5_Leave(sender As Object, e As EventArgs) Handles txtHoraEntrada5.Leave
        txtHoraSalida5.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas5.Text.Trim), txtHoraEntrada5.Value)
    End Sub
    Private Sub txtHoraEntrada6_Leave(sender As Object, e As EventArgs) Handles txtHoraEntrada6.Leave
        txtHoraSalida6.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas6.Text.Trim), txtHoraEntrada6.Value)
    End Sub
    Private Sub txtHoraEntrada7_Leave(sender As Object, e As EventArgs) Handles txtHoraEntrada7.Leave
        txtHoraSalida7.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas7.Text.Trim), txtHoraEntrada7.Value)
    End Sub
    Private Sub txtAutorizadas1_GotFocus(sender As Object, e As EventArgs) Handles txtAutorizadas1.GotFocus
        txtAutorizadas1.SelectionLength = txtAutorizadas1.TextLength
    End Sub
    Private Sub txtAutorizadas2_GotFocus(sender As Object, e As EventArgs) Handles txtAutorizadas2.GotFocus
        txtAutorizadas2.SelectionLength = txtAutorizadas2.TextLength
    End Sub
    Private Sub txtAutorizadas3_GotFocus(sender As Object, e As EventArgs) Handles txtAutorizadas3.GotFocus
        txtAutorizadas3.SelectionLength = txtAutorizadas3.TextLength
    End Sub
    Private Sub txtAutorizadas4_GotFocus(sender As Object, e As EventArgs) Handles txtAutorizadas4.GotFocus
        txtAutorizadas4.SelectionLength = txtAutorizadas4.TextLength
    End Sub
    Private Sub txtAutorizadas5_GotFocus(sender As Object, e As EventArgs) Handles txtAutorizadas5.GotFocus
        txtAutorizadas5.SelectionLength = txtAutorizadas5.TextLength
    End Sub
    Private Sub txtAutorizadas6_GotFocus(sender As Object, e As EventArgs) Handles txtAutorizadas6.GotFocus
        txtAutorizadas6.SelectionLength = txtAutorizadas6.TextLength
    End Sub
    Private Sub txtAutorizadas7_GotFocus(sender As Object, e As EventArgs) Handles txtAutorizadas7.GotFocus
        txtAutorizadas7.SelectionLength = txtAutorizadas7.TextLength
    End Sub

    Private Sub txtAutorizadas1_Validated(sender As Object, e As EventArgs) Handles txtAutorizadas1.Validated
        txtAutorizadas1.Text = CtoHSimple(txtAutorizadas1.Text.Trim)
        If txtHoraEntrada1.Text = "" Then
            txtHoraEntrada1.Value = txtHoraEntrada1.Tag
        End If
        txtHoraSalida1.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas1.Text.Trim), txtHoraEntrada1.Value)
    End Sub
    Private Sub txtAutorizadas2_Validated(sender As Object, e As EventArgs) Handles txtAutorizadas2.Validated
        txtAutorizadas2.Text = CtoHSimple(txtAutorizadas2.Text.Trim)
        If txtHoraEntrada2.Text = "" Then
            txtHoraEntrada2.Value = txtHoraEntrada2.Tag
        End If
        txtHoraSalida2.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas2.Text.Trim), txtHoraEntrada2.Value)

    End Sub
    Private Sub txtAutorizadas3_Validated(sender As Object, e As EventArgs) Handles txtAutorizadas3.Validated
        txtAutorizadas3.Text = CtoHSimple(txtAutorizadas3.Text.Trim)
        If txtHoraEntrada3.Text = "" Then
            txtHoraEntrada3.Value = txtHoraEntrada3.Tag
        End If
        txtHoraSalida3.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas3.Text.Trim), txtHoraEntrada3.Value)

    End Sub
    Private Sub txtAutorizadas4_Validated(sender As Object, e As EventArgs) Handles txtAutorizadas4.Validated
        txtAutorizadas4.Text = CtoHSimple(txtAutorizadas4.Text.Trim)
        If txtHoraEntrada4.Text = "" Then
            txtHoraEntrada4.Value = txtHoraEntrada4.Tag
        End If
        txtHoraSalida4.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas4.Text.Trim), txtHoraEntrada4.Value)

    End Sub
    Private Sub txtAutorizadas5_Validated(sender As Object, e As EventArgs) Handles txtAutorizadas5.Validated
        txtAutorizadas5.Text = CtoHSimple(txtAutorizadas5.Text.Trim)
        If txtHoraEntrada5.Text = "" Then
            txtHoraEntrada5.Value = txtHoraEntrada5.Tag
        End If
        txtHoraSalida5.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas5.Text.Trim), txtHoraEntrada5.Value)

    End Sub
    Private Sub txtAutorizadas6_Validated(sender As Object, e As EventArgs) Handles txtAutorizadas6.Validated
        txtAutorizadas6.Text = CtoHSimple(txtAutorizadas6.Text.Trim)
        If txtHoraEntrada6.Text = "" Then
            txtHoraEntrada6.Value = txtHoraEntrada6.Tag
        End If
        txtHoraSalida6.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas6.Text.Trim), txtHoraEntrada6.Value)

    End Sub
    Private Sub txtAutorizadas7_Validated(sender As Object, e As EventArgs) Handles txtAutorizadas7.Validated
        txtAutorizadas7.Text = CtoHSimple(txtAutorizadas7.Text.Trim)
        If txtHoraEntrada7.Text = "" Then
            txtHoraEntrada7.Value = txtHoraEntrada7.Tag
        End If
        txtHoraSalida7.Value = DateAdd(DateInterval.Hour, HtoD(txtAutorizadas7.Text.Trim), txtHoraEntrada7.Value)

    End Sub

    Private Sub txtHoraSalida1_Leave(sender As Object, e As EventArgs) Handles txtHoraSalida1.Leave
        Dim Hrs As String
        Hrs = Math.Round(DateDiff(DateInterval.Minute, txtHoraEntrada1.Value, txtHoraSalida1.Value) / 60, 2)
        txtAutorizadas1.Text = DtoH(Hrs)
    End Sub
    Private Sub txtHoraSalida2_Leave(sender As Object, e As EventArgs) Handles txtHoraSalida2.Leave
        Dim Hrs As String
        Hrs = Math.Round(DateDiff(DateInterval.Minute, txtHoraEntrada2.Value, txtHoraSalida2.Value) / 60, 2)
        txtAutorizadas2.Text = DtoH(Hrs)
    End Sub
    Private Sub txtHoraSalida3_Leave(sender As Object, e As EventArgs) Handles txtHoraSalida3.Leave
        Dim Hrs As String
        Hrs = Math.Round(DateDiff(DateInterval.Minute, txtHoraEntrada3.Value, txtHoraSalida3.Value) / 60, 2)
        txtAutorizadas3.Text = DtoH(Hrs)
    End Sub
    Private Sub txtHoraSalida4_Leave(sender As Object, e As EventArgs) Handles txtHoraSalida4.Leave
        Dim Hrs As String
        Hrs = Math.Round(DateDiff(DateInterval.Minute, txtHoraEntrada4.Value, txtHoraSalida4.Value) / 60, 2)
        txtAutorizadas4.Text = DtoH(Hrs)
    End Sub
    Private Sub txtHoraSalida5_Leave(sender As Object, e As EventArgs) Handles txtHoraSalida5.Leave
        Dim Hrs As String
        Hrs = Math.Round(DateDiff(DateInterval.Minute, txtHoraEntrada5.Value, txtHoraSalida5.Value) / 60, 2)
        txtAutorizadas5.Text = DtoH(Hrs)
    End Sub
    Private Sub txtHoraSalida6_Leave(sender As Object, e As EventArgs) Handles txtHoraSalida6.Leave
        Dim Hrs As String
        Hrs = Math.Round(DateDiff(DateInterval.Minute, txtHoraEntrada6.Value, txtHoraSalida6.Value) / 60, 2)
        txtAutorizadas6.Text = DtoH(Hrs)
    End Sub
    Private Sub txtHoraSalida7_Leave(sender As Object, e As EventArgs) Handles txtHoraSalida7.Leave
        Dim Hrs As String
        Hrs = Math.Round(DateDiff(DateInterval.Minute, txtHoraEntrada7.Value, txtHoraSalida7.Value) / 60, 2)
        txtAutorizadas7.Text = DtoH(Hrs)
    End Sub

    Private Sub SumaHorasReales()
        Dim i As Double
        i = HtoD(lblExtraReales1.Text)
        i = i + HtoD(lblExtraReales2.Text)
        i = i + HtoD(lblExtraReales3.Text)
        i = i + HtoD(lblExtraReales4.Text)
        i = i + HtoD(lblExtraReales5.Text)
        i = i + HtoD(lblExtraReales6.Text)
        i = i + HtoD(lblExtraReales7.Text)

        lblTotalReales.Text = DtoH(i)
    End Sub

    Private Sub SumaHorasAutorizadas()
        Dim i As Double
        i = HtoD(txtAutorizadas1.Text)
        i = i + HtoD(txtAutorizadas2.Text)
        i = i + HtoD(txtAutorizadas3.Text)
        i = i + HtoD(txtAutorizadas4.Text)
        i = i + HtoD(txtAutorizadas5.Text)
        i = i + HtoD(txtAutorizadas6.Text)
        i = i + HtoD(txtAutorizadas7.Text)

        lblTotalAutorizadas.Text = DtoH(i)
    End Sub
    Private Sub txtAutorizadas1_TextChanged(sender As Object, e As EventArgs) Handles txtAutorizadas1.TextChanged
        SumaHorasAutorizadas()
    End Sub

    Private Sub txtAutorizadas2_TextChanged(sender As Object, e As EventArgs) Handles txtAutorizadas2.TextChanged
        SumaHorasAutorizadas()
    End Sub
    Private Sub txtAutorizadas3_TextChanged(sender As Object, e As EventArgs) Handles txtAutorizadas3.TextChanged
        SumaHorasAutorizadas()
    End Sub
    Private Sub txtAutorizadas4_TextChanged(sender As Object, e As EventArgs) Handles txtAutorizadas4.TextChanged
        SumaHorasAutorizadas()
    End Sub
    Private Sub txtAutorizadas5_TextChanged(sender As Object, e As EventArgs) Handles txtAutorizadas5.TextChanged
        SumaHorasAutorizadas()
    End Sub
    Private Sub txtAutorizadas6_TextChanged(sender As Object, e As EventArgs) Handles txtAutorizadas6.TextChanged
        SumaHorasAutorizadas()
    End Sub
    Private Sub txtAutorizadas7_TextChanged(sender As Object, e As EventArgs) Handles txtAutorizadas7.TextChanged
        SumaHorasAutorizadas()
    End Sub


    Private Sub txtReloj_TextChanged(sender As Object, e As EventArgs) Handles txtReloj.TextChanged
        If txtReloj.Text = "" Then Exit Sub

        dtEmp = ConsultaPersonalVW("select reloj FROM personalVW WHERE reloj = '" & txtReloj.Text.Trim.PadLeft(LongReloj, "0") & "'")
        If dtEmp.Rows.Count > 0 Then
            txtReloj.Text = txtReloj.Text.Trim.PadLeft(LongReloj, "0")
            MostrarInformacion(txtReloj.Text, True)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Reloj = txtReloj.Text
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj, True)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If pnlDia1.Enabled Then GuardaCambios(pnlDia1)
        If pnlDia2.Enabled Then GuardaCambios(pnlDia2)
        If pnlDia3.Enabled Then GuardaCambios(pnlDia3)
        If pnlDia4.Enabled Then GuardaCambios(pnlDia4)
        If pnlDia5.Enabled Then GuardaCambios(pnlDia5)
        If pnlDia6.Enabled Then GuardaCambios(pnlDia6)
        If pnlDia7.Enabled Then GuardaCambios(pnlDia7)
        Me.Close()
        Me.Dispose()
    End Sub

   
End Class