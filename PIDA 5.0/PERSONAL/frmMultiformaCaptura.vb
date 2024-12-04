Public Class frmMultiformaCaptura
    Dim dtDeptos As DataTable
    Dim dtAreas As DataTable
    Dim dtSuper As DataTable
    Dim dtPuestos As DataTable
    Dim dtTurnos As DataTable
    Dim dtHorarios As DataTable
    Dim dtDeptos2 As DataTable
    Dim dtAreas2 As DataTable
    Dim dtSuper2 As DataTable
    Dim dtPuestos2 As DataTable
    Dim dtTurnos2 As DataTable
    Dim dtHorarios2 As DataTable
    Dim Accion As String = ""
    Dim dtAusentismo As DataTable
    Dim dtMotivos As DataTable
    Dim dtMotivosImss As DataTable
    Dim dtEmpleado As DataTable
    Dim Movimiento As String = "BAJA"
    Dim Movimientos As String = ""
    Dim dtRegistros As DataTable
    Dim dtRegistro As DataTable
    Dim Agregar As Boolean = False
    Dim Editar As Boolean = False
    Dim compa As String
    Dim FiltroMultiforma As String
    Dim dtNivel As New DataTable
    Dim dtModSal As New DataTable
    Dim Nivel As String
    Dim CompaRatio As Double
    Dim dtTemp As New DataTable
    Public Sub New(ByVal action As String, Optional mov As String = "")
        InitializeComponent()
        Accion = action
        If mov <> "" Then
            Movimiento = mov
        End If

        If action.Equals("Editar") Then
            tabSalario.Visible = False
            pnlSalario.Visible = False
            ReflectionLabel1.Text = "<font color=""#1F497D""><b>EDITAR MOVIMIENTO</b></font>"
        Else
            ReflectionLabel1.Text = "<font color=""#1F497D""><b>AGREGAR MOVIMIENTO</b></font>"
        End If
    End Sub
    Private Sub frmNuevaModificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ArchivoFoto As String

        dtEmpleado = sqlExecute("select  * from personalvw where reloj ='" + Reloj + "'")
        Dim dRow = dtEmpleado.Rows(0)
        txtReloj.Text = IIf(IsDBNull(dRow("RELOJ")), "", dRow("RELOJ"))
        txtNombres.Text = IIf(IsDBNull(dRow("NOMBRES")), "", dRow("NOMBRES"))
        compa = IIf(IsDBNull(dRow("COD_COMP")), "", dRow("COD_COMP"))
        CargarCombos()
        lblArea.Text = IIf(IsDBNull(dRow("COD_AREA")), "", dRow("COD_AREA").ToString.Trim & IIf(IsDBNull(dRow.Item("NOMBRE_AREA")), "", ", " + dRow.Item("NOMBRE_AREA").ToString.Trim))
        lblArea.AccessibleDescription = IIf(IsDBNull(dRow("COD_AREA")), "", dRow("COD_AREA"))

        lblDepto.Text = IIf(IsDBNull(dRow("COD_DEPTO")), "", dRow("COD_DEPTO").ToString.Trim & IIf(IsDBNull(dRow.Item("NOMBRE_DEPTO")), "", ", " + dRow.Item("NOMBRE_DEPTO").ToString.Trim))
        lblDepto.AccessibleDescription = IIf(IsDBNull(dRow("COD_DEPTO")), "", dRow("COD_DEPTO"))

        lblPuesto.Text = IIf(IsDBNull(dRow("COD_PUESTO")), "", dRow("COD_PUESTO").ToString.Trim & IIf(IsDBNull(dRow.Item("NOMBRE_PUESTO")), "", ", " + dRow.Item("NOMBRE_PUESTO").ToString.Trim))
        lblPuesto.AccessibleDescription = IIf(IsDBNull(dRow("COD_PUESTO")), "", dRow("COD_PUESTO"))

        lblSuper.Text = IIf(IsDBNull(dRow("COD_SUPER")), "", dRow("COD_SUPER").ToString.Trim & IIf(IsDBNull(dRow.Item("NOMBRE_SUPER")), "", ", " + dRow.Item("NOMBRE_SUPER").ToString.Trim))
        lblSuper.AccessibleDescription = IIf(IsDBNull(dRow("COD_SUPER")), "", dRow("COD_SUPER"))

        lblTurno.Text = IIf(IsDBNull(dRow("COD_TURNO")), "", dRow("COD_TURNO").ToString.Trim & IIf(IsDBNull(dRow.Item("NOMBRE_TURNO")), "", ", " + dRow.Item("NOMBRE_TURNO").ToString.Trim))
        lblTurno.AccessibleDescription = IIf(IsDBNull(dRow("COD_TURNO")), "", dRow("COD_TURNO"))

        lblHorario.Text = IIf(IsDBNull(dRow("COD_HORA")), "", dRow("COD_HORA").ToString.Trim & IIf(IsDBNull(dRow.Item("NOMBRE_HORARIO")), "", ", " + dRow.Item("NOMBRE_HORARIO").ToString.Trim))
        lblHorario.AccessibleDescription = IIf(IsDBNull(dRow("COD_HORA")), "", dRow("COD_HORA"))
        cmbNivel.SelectedValue = IIf(IsDBNull(dRow("nivel")), "", dRow("nivel"))
        txtSueldoActual.Text = IIf(IsDBNull(dRow("sactual")), "", dRow("sactual"))
        txtProVar.Text = IIf(IsDBNull(dRow("pro_var")), "", dRow("pro_var"))
        txtFactorInt.Text = IIf(IsDBNull(dRow("factor_int")), "", dRow("factor_int"))
        CompaRatio = IIf(IsDBNull(dRow("compa_ratio")), "", dRow("compa_ratio"))
        Nivel = IIf(IsDBNull(dRow("nivel")), "", dRow("nivel"))
        'cmbAreaActual.SelectedValue = IIf(IsDBNull(dRow("COD_AREA")), "", dRow("COD_AREA"))
        'cmbPuestoActual.SelectedValue = IIf(IsDBNull(dRow("COD_PUESTO")), "", dRow("COD_PUESTO"))
        'cmbTurnoActual.SelectedValue = IIf(IsDBNull(dRow("COD_TURNO")), "", dRow("COD_TURNO"))
        'cmbHorarioActual.SelectedValue = IIf(IsDBNull(dRow("COD_HORA")), "", dRow("COD_HORA"))
        'cmbSupervisorActual.SelectedValue = IIf(IsDBNull(dRow("COD_SUPER")), "", dRow("COD_SUPER"))
        Try
            ArchivoFoto = PathFoto & Reloj & ".jpg"
            If Dir(ArchivoFoto) = "" Then
                ArchivoFoto = PathFoto & "nofoto.png"
            End If
            'Dim ft As New Bitmap(ArchivoFoto)
            picFoto.Width = picFoto.MinimumSize.Width
            picFoto.Height = picFoto.MinimumSize.Height
            picFoto.Left = 640
            'picFoto.Image = ft
            picFoto.ImageLocation = ArchivoFoto
        Catch
            picFoto.Image = picFoto.ErrorImage
        End Try
        txtBaja.Value = Date.Now
        txtFechaAus.Value = Date.Now
        txtFechaEfectivaPos.Value = Date.Now
        txtFechaEfectivaSal.Value = Date.Now
        txtFechaEfectivaTu.Value = Date.Now
        txtFechaEfectivaSal.Value = Date.Now.AddDays(10)

        gpSueldos.AccessibleDescription = ""
        pnlSalario.AccessibleDescription = ""
        ActualizarRegistro()
        HabilitarBotones()
        If Accion.Equals("Editar") Then
            If Movimiento.Equals("BAJA") Then
                pnlBaja.Focus()
            ElseIf Movimiento.Equals("AUSENTISMO") Then
                pnlAusencia.Focus()
            ElseIf Movimiento.Equals("TURNO") Then
                pnlTurno.Focus()
            ElseIf Movimiento.Equals("POSICION") Then
                pnlPosicion.Focus()
            ElseIf Movimiento.Equals("SALARIO") Then
                pnlSalario.Focus()
            End If
            btnEditar.PerformClick()
        Else
            tabBaja.Enabled = Not Movimientos.Contains("BAJA")
            tabAusencia.Enabled = Not Movimientos.Contains("AUSENTISMO")
            tabTurno.Enabled = Not Movimientos.Contains("TURNO")
            tabPosicion.Enabled = Not Movimientos.Contains("POSICION")
            tabSalario.Enabled = Not Movimientos.Contains("SALARIO")
        End If

    End Sub
    Private Sub CargarCombos()

        If FiltroXUsuario.Contains("COD_COMP") Or FiltroXUsuario.Contains("cod_comp") Then
            FiltroMultiforma = " where " & FiltroXUsuario
        Else
            FiltroMultiforma = " where cod_comp='" & compa & "'"
        End If
        dtDeptos = sqlExecute("select  * from deptos")
        dtAreas = sqlExecute("select  * from areas" & FiltroMultiforma)
        dtSuper = sqlExecute("select * from super" & FiltroMultiforma)
        dtPuestos = sqlExecute("select * from puestos" & FiltroMultiforma)
        dtTurnos = sqlExecute("select  * from turnos" & FiltroMultiforma)
        dtHorarios = sqlExecute("Select * from horarios" & FiltroMultiforma)
        dtDeptos2 = sqlExecute("select  * from deptos" & FiltroMultiforma)
        dtAreas2 = sqlExecute("select  * from areas" & FiltroMultiforma)
        dtSuper2 = sqlExecute("select * from super" & FiltroMultiforma)
        dtPuestos2 = sqlExecute("select * from puestos" & FiltroMultiforma)
        dtTurnos2 = sqlExecute("select  * from turnos" & FiltroMultiforma)
        dtHorarios2 = sqlExecute("Select * from horarios" & FiltroMultiforma)
        dtAusentismo = sqlExecute("select  * from tipo_ausentismo where tipo_naturaleza <> 'I'", "ta")
        dtMotivos = sqlExecute("select * from cod_mot_baj")
        dtMotivosImss = sqlExecute("select * from cod_mot_baj_imss")
        cmbAusentismo.DataSource = dtAusentismo
        cmbAusentismo.DisplayMembers = "tipo_aus,nombre"
        cmbAusentismo.ValueMember = "tipo_aus"
        cmbMotivo.DataSource = dtMotivos
        cmbMotivo.DisplayMembers = "cod_mot_ba,nombre"
        cmbMotivo.ValueMember = "cod_mot_ba"
        cmbMotivoImss.DataSource = dtMotivosImss
        cmbMotivoImss.DisplayMembers = "cod_mot,motivo"
        cmbMotivoImss.ValueMember = "cod_mot"
        'cmbAreaActual.DataSource = dtAreas
        'cmbAreaActual.DisplayMembers = "cod_area,nombre" 'cod_comp,
        'cmbAreaActual.ValueMember = "cod_area"
        cmbAreaNueva.DataSource = dtAreas2
        cmbAreaNueva.DisplayMembers = "cod_comp,cod_area,nombre" 'cod_comp,
        cmbAreaNueva.ValueMember = "cod_area"
        'cmbDepartamentoActual.DataSource = dtDeptos
        'cmbDepartamentoActual.DisplayMembers = "cod_depto,nombre"
        'cmbDepartamentoActual.ValueMember = "cod_depto"
        cmbDepartamentoNuevo.DataSource = dtDeptos2
        cmbDepartamentoNuevo.DisplayMembers = "cod_depto,nombre"
        cmbDepartamentoNuevo.ValueMember = "cod_depto"
        'cmbPuestoActual.DataSource = dtPuestos
        'cmbPuestoActual.DisplayMembers = "cod_puesto,nombre" 'cod_comp,
        'cmbPuestoActual.ValueMember = "cod_puesto"
        cmbPuestoNuevo.DataSource = dtPuestos2
        cmbPuestoNuevo.DisplayMembers = "cod_comp,cod_puesto,nombre" 'cod_comp,
        cmbPuestoNuevo.ValueMember = "cod_puesto"
        'cmbSupervisorActual.DataSource = dtSuper
        'cmbSupervisorActual.DisplayMembers = "cod_super,nombre" 'cod_comp,
        'cmbSupervisorActual.ValueMember = "cod_super"
        cmbSuperVisorNuevo.DataSource = dtSuper2
        cmbSuperVisorNuevo.DisplayMembers = "cod_comp,cod_super,nombre" 'cod_comp,
        cmbSuperVisorNuevo.ValueMember = "cod_super"
        'cmbTurnoActual.DataSource = dtTurnos
        'cmbTurnoActual.DisplayMembers = "cod_turno,nombre" 'cod_comp,
        'cmbTurnoActual.ValueMember = "cod_turno"
        cmbTurnoNuevo.DataSource = dtTurnos2
        cmbTurnoNuevo.DisplayMembers = "cod_comp,cod_turno,nombre" 'cod_comp,
        cmbTurnoNuevo.ValueMember = "cod_turno"
        'cmbHorarioActual.DataSource = dtHorarios
        'cmbHorarioActual.DisplayMembers = "cod_hora,nombre"
        'cmbHorarioActual.ValueMember = "cod_hora"
        cmbHorarioNuevo.DataSource = dtHorarios2
        cmbHorarioNuevo.DisplayMembers = "cod_hora,nombre"
        cmbHorarioNuevo.ValueMember = "cod_hora"
        'MODIFICACIONES DE SUELDO


        dtModSal = sqlExecute("SELECT * FROM tipo_mod_sal")
        cmbTipoModSal.DataSource = dtModSal
        cmbTipoModSal.DisplayMembers = "cod_tipo_mod,nombre"
        cmbTipoModSal.ValueMember = "cod_tipo_mod"

        'dtNivel = sqlExecute("SELECT * FROM niveles")
        'cmbNivel.DataSource = dtNivel

        dtNivel = sqlExecute("SELECT * FROM niveles WHERE cod_comp = '" & compa & "'")
        cmbNivel.DataSource = dtNivel
        cmbNivel.DisplayMembers = "nivel,sueldo"
        cmbNivel.ValueMember = "nivel"

    End Sub
    Private Sub ActualizarRegistro()
        If FiltroXUsuario.Contains("COD_COMP") Or FiltroXUsuario.Contains("cod_comp") Then
            FiltroMultiforma = " and " & FiltroXUsuario
        Else
            FiltroMultiforma = " and cod_comp='" & compa & "'"
        End If

        dtRegistros = sqlExecute("select distinct tipo_movimiento from formato_multiple where reloj = '" + Reloj + "' AND confirmado = '0'" + FiltroMultiforma)
        For Each row As DataRow In dtRegistros.Rows
            Movimientos = Movimientos + row.Item("tipo_movimiento").ToString + ","
        Next
        dtRegistros = sqlExecute("select * from formato_multiple where reloj = '" + Reloj + "' AND confirmado = '0'")
        MostrarInformacion()
    End Sub
    Private Sub MostrarInformacion()
        For Each row As DataRow In dtRegistros.Rows
            If row.Item("tipo_movimiento").ToString.Trim.Equals("BAJA") Then
                txtBaja.Value = row.Item("fecha_baja")
                cmbMotivo.SelectedValue = row.Item("cod_mot_ba")
                cmbMotivoImss.SelectedValue = row.Item("cod_mot")
                txtComentarioBaja.Text = row.Item("COMENTARIO")

            End If
            If row.Item("tipo_movimiento").ToString.Trim.Equals("AUSENTISMO") Then
                txtFechaAus.Value = row.Item("FECHA_INICIO")
                cmbAusentismo.SelectedValue = row.Item("TIPO_AUS")
                txtDias.Value = row.Item("CANTIDAD_DIAS")
                txtComentarioAus.Text = row.Item("COMENTARIO")

            End If
            If row.Item("tipo_movimiento").ToString.Trim.Equals("TURNO") Then
                txtFechaEfectivaTu.Value = row.Item("fecha_EFECTIVA")
                txtComentarioTurno.Text = row.Item("COMENTARIO")
                If row.Item("campo").ToString.Trim.Equals("COD_TURNO") Then
                    'cmbTurnoActual.SelectedValue = row.Item("VALOR_ACTUAL")
                    cmbTurnoNuevo.SelectedValue = row.Item("VALOR_NUEVO")
                ElseIf row.Item("campo").ToString.Trim.Equals("COD_HORA") Then
                    ' cmbHorarioActual.SelectedValue = row.Item("VALOR_ACTUAL")
                    cmbHorarioNuevo.SelectedValue = row.Item("VALOR_NUEVO")
                End If
            End If
            If row.Item("tipo_movimiento").ToString.Trim.Equals("POSICION") Then
                If row.Item("campo").ToString.Trim.Equals("COD_AREA") Then
                    chkArea.Checked = True
                    ' cmbAreaActual.SelectedValue = row.Item("VALOR_ACTUAL")
                    cmbAreaNueva.SelectedValue = row.Item("VALOR_NUEVO")
                ElseIf row.Item("campo").ToString.Trim.Equals("COD_DEPTO") Then
                    chkDepto.Checked = True
                    'cmbDepartamentoActual.SelectedValue = row.Item("VALOR_ACTUAL")
                    cmbDepartamentoNuevo.SelectedValue = row.Item("VALOR_NUEVO")
                ElseIf row.Item("campo").ToString.Trim.Equals("COD_PUESTO") Then
                    chkPuesto.Checked = True
                    'cmbPuestoActual.SelectedValue = row.Item("VALOR_ACTUAL")
                    cmbPuestoNuevo.SelectedValue = row.Item("VALOR_NUEVO")
                ElseIf row.Item("campo").ToString.Trim.Equals("COD_SUPER") Then
                    chkSuper.Checked = True
                    ' cmbSupervisorActual.SelectedValue = row.Item("VALOR_ACTUAL")
                    cmbSuperVisorNuevo.SelectedValue = row.Item("VALOR_NUEVO")
                End If
            
            End If
            If row.Item("tipo_movimiento").ToString.Trim.Equals("SALARIO") Then
                Dim dtEdicion As New DataTable
                Try
                    dtEdicion = sqlExecute("SELECT * FROM mod_sal WHERE ID ='" & row.Item("comentario").ToString.Trim & "'")
                    pnlSalario.AccessibleDescription = dtEdicion.Rows.Item(0).Item("ID")
                    gpSueldos.AccessibleDescription = dtEdicion.Rows.Item(0).Item("ID")
                    txtSueldoActual.Text = dtEdicion.Rows.Item(0).Item("cambio_de")
                    cmbTipoModSal.SelectedValue = dtEdicion.Rows.Item(0).Item("cod_tipo_mod")
                    cmbNivel.SelectedValue = dtEdicion.Rows.Item(0).Item("nivel")
                    txtCambioA.Text = dtEdicion.Rows.Item(0).Item("cambio_a")
                    txtFechaEfectivaPos.Value = dtEdicion.Rows.Item(0).Item("fecha")
                    txtProVar.Text = dtEdicion.Rows.Item(0).Item("provar")
                    txtFactorInt.Text = dtEdicion.Rows.Item(0).Item("fact_int")
                    txtIntegrado.Text = dtEdicion.Rows.Item(0).Item("integrado")
                    txtNotas.Text = dtEdicion.Rows.Item(0).Item("notas")
                Catch ex As Exception

                End Try
            End If
        Next
    End Sub

    Private Sub HabilitarBotones()
        If Movimientos.Contains(Movimiento) Then
            If Accion.Equals("Agregar") Then
                btnNuevo.Enabled = False
                btnEditar.Enabled = False
                'btnConfirmar.Visible = False
                ' btnBorrar.Visible = False

            Else
                btnNuevo.Enabled = False
                btnEditar.Enabled = True
                '       btnConfirmar.Visible = True
                'btnBorrar.Visible = True
            End If
        Else
            If Accion.Equals("Agregar") Then
                btnNuevo.Enabled = True
                btnEditar.Enabled = False
                '   btnConfirmar.Visible = False
                '  btnBorrar.Visible = False
            Else
                btnNuevo.Enabled = False
                btnEditar.Enabled = False
                '   btnConfirmar.Visible = False
                '  btnBorrar.Visible = False
            End If
        End If

    End Sub

    Private Sub tabBaja_Click(sender As Object, e As EventArgs) Handles tabBaja.Click
        Movimiento = "BAJA"
        HabilitarBotones()
    End Sub

    Private Sub tabAusencia_Click(sender As Object, e As EventArgs) Handles tabAusencia.Click
        Movimiento = "AUSENTISMO"
        HabilitarBotones()
    End Sub

    Private Sub tabTurno_Click(sender As Object, e As EventArgs) Handles tabTurno.Click
        Movimiento = "TURNO"
        HabilitarBotones()
    End Sub

    Private Sub tabPosicion_Click(sender As Object, e As EventArgs) Handles tabPosicion.Click
        Movimiento = "POSICION"
        HabilitarBotones()
    End Sub

    Private Sub tabSalario_Click(sender As Object, e As EventArgs) Handles tabSalario.Click
        Movimiento = "SALARIO"
        HabilitarBotones()
    End Sub
    Private Sub HabilitarPaneles()
        ' If Accion.Equals("Agregar") Then
        pnlBaja.Enabled = Movimiento.Equals("BAJA") And (Editar Or Agregar) 'And Movimientos.Contains("BAJA")
        pnlAusencia.Enabled = Movimiento.Equals("AUSENTISMO") And (Editar Or Agregar) 'And Movimientos.Contains("AUSENTISMO")
        pnlTurno.Enabled = Movimiento.Equals("TURNO") And (Editar Or Agregar) ' And Movimientos.Contains("TURNO")
        pnlPosicion.Enabled = Movimiento.Equals("POSICION") And (Editar Or Agregar) 'And Movimientos.Contains("POSICION")
        pnlSalario.Enabled = Movimiento.Equals("SALARIO") And (Editar Or Agregar) 'And Movimientos.Contains("SALARIO")
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dim dtinfo As DataTable = sqlExecute("select  * from formato_multiple where confirmado = '0' and reloj = '" + Reloj + "'")
        If dtinfo.Rows.Count > 0 Then
            dtinfo = sqlExecute("select reloj,'individual' as tipo_reporte from personalvw where reloj = '" + Reloj + "'")
            frmVistaPrevia.LlamarReporte("Formato Multiple", dtinfo)
            frmVistaPrevia.ShowDialog()
            sqlExecute("update formato_multiple set impreso='1' where impreso = '0' and reloj = '" + Reloj + "'")
        End If
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try


            Dim query As String = ""
            If Agregar Then
                If Movimiento.Equals("BAJA") Then
                    query = "insert into formato_multiple" & _
                            "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                            "HORA_CAPTURA,USUARIO,EQUIPO," & _
                            "COMENTARIO,FECHA_BAJA,COD_MOT_BA," & _
                            "COD_MOT,TIPO_MOVIMIENTO,CONFIRMADO,IMPRESO) " & _
                            "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                            "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                            "'" + txtComentarioBaja.Text + "','" + FechaSQL(txtBaja.Value) + "','" + cmbMotivo.SelectedValue.ToString + "'," & _
                            "'" + cmbMotivoImss.SelectedValue.ToString + "','BAJA','0','0')"
                    sqlExecute(query, "personal")
                ElseIf Movimiento.Equals("AUSENTISMO") Then
                    query = "insert into formato_multiple" & _
                            "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                            "HORA_CAPTURA,USUARIO,EQUIPO," & _
                            "COMENTARIO,TIPO_AUS,FECHA_INICIO," & _
                            "CANTIDAD_DIAS,TIPO_MOVIMIENTO,CONFIRMADO,IMPRESO) " & _
                            "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                            "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                            "'" + txtComentarioAus.Text + "','" + cmbAusentismo.SelectedValue.ToString + "','" + FechaSQL(txtFechaAus.Value) + "'," & _
                            "'" + txtDias.Value.ToString + "','AUSENTISMO','0','0')"
                    sqlExecute(query, "personal")
                ElseIf Movimiento.Equals("TURNO") Then
                    query = "insert into formato_multiple" & _
                            "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                            "HORA_CAPTURA,USUARIO,EQUIPO," & _
                            "COMENTARIO,CAMPO,VALOR_ACTUAL," & _
                            "VALOR_NUEVO,TIPO_MOVIMIENTO,FECHA_EFECTIVA,CONFIRMADO,IMPRESO) " & _
                            "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                            "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                            "'" + txtComentarioTurno.Text + "','COD_TURNO','" + lblTurno.AccessibleDescription + "'," & _
                            "'" + cmbTurnoNuevo.SelectedValue + "','TURNO','" + FechaSQL(txtFechaEfectivaTu.Value) + "','0','0')"
                    sqlExecute(query, "personal")
                    query = "insert into formato_multiple" & _
                           "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                           "HORA_CAPTURA,USUARIO,EQUIPO," & _
                           "COMENTARIO,CAMPO,VALOR_ACTUAL," & _
                           "VALOR_NUEVO,TIPO_MOVIMIENTO,FECHA_EFECTIVA,CONFIRMADO,IMPRESO) " & _
                           "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                           "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                           "'" + txtComentarioTurno.Text + "','COD_HORA','" + lblHorario.AccessibleDescription + "'," & _
                           "'" + cmbHorarioNuevo.SelectedValue + "','TURNO','" + FechaSQL(txtFechaEfectivaTu.Value) + "','0','0')"
                    sqlExecute(query, "personal")


                ElseIf Movimiento.Equals("POSICION") Then
                    If chkArea.Checked Then
                        query = "insert into formato_multiple" & _
                       "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                       "HORA_CAPTURA,USUARIO,EQUIPO," & _
                       "CAMPO,VALOR_ACTUAL,VALOR_NUEVO," & _
                       "FECHA_EFECTIVA,TIPO_MOVIMIENTO,CONFIRMADO,IMPRESO,COMENTARIO) " & _
                       "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                       "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                       "'COD_AREA','" + lblArea.AccessibleDescription + "','" + cmbAreaNueva.SelectedValue + "'," & _
                       "'" + FechaSQL(txtFechaEfectivaPos.Value) + "','POSICION','0','0','')"
                        sqlExecute(query, "personal")
                    End If
                    If chkDepto.Checked Then
                        query = "insert into formato_multiple" & _
                       "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                       "HORA_CAPTURA,USUARIO,EQUIPO," & _
                       "CAMPO,VALOR_ACTUAL,VALOR_NUEVO," & _
                       "FECHA_EFECTIVA,TIPO_MOVIMIENTO,CONFIRMADO,IMPRESO,COMENTARIO) " & _
                       "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                       "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                       "'COD_DEPTO','" + lblDepto.AccessibleDescription + "','" + cmbDepartamentoNuevo.SelectedValue + "'," & _
                       "'" + FechaSQL(txtFechaEfectivaPos.Value) + "','POSICION','0','0','')"
                        sqlExecute(query, "personal")
                    End If
                    If chkSuper.Checked Then
                        query = "insert into formato_multiple" & _
                       "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                       "HORA_CAPTURA,USUARIO,EQUIPO," & _
                       "CAMPO,VALOR_ACTUAL,VALOR_NUEVO," & _
                       "FECHA_EFECTIVA,TIPO_MOVIMIENTO,CONFIRMADO,IMPRESO,COMENTARIO) " & _
                       "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                       "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                       "'COD_SUPER','" + lblSuper.AccessibleDescription + "','" + cmbSuperVisorNuevo.SelectedValue + "'," & _
                       "'" + FechaSQL(txtFechaEfectivaPos.Value) + "','POSICION','0','0','')"
                        sqlExecute(query, "personal")
                    End If
                    If chkPuesto.Checked Then
                        query = "insert into formato_multiple" & _
                       "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                       "HORA_CAPTURA,USUARIO,EQUIPO," & _
                       "CAMPO,VALOR_ACTUAL,VALOR_NUEVO," & _
                       "FECHA_EFECTIVA,TIPO_MOVIMIENTO,CONFIRMADO,IMPRESO,COMENTARIO, PERIODO_PRUEBA) " & _
                       "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                       "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                       "'COD_PUESTO','" + lblPuesto.AccessibleDescription + "','" + cmbPuestoNuevo.SelectedValue + "'," & _
                       "'" + FechaSQL(txtFechaEfectivaPos.Value) + "','POSICION','0','0','', '" & IIf(btnPeriodoPrueba.Value = True, 1, 0) & "')"
                        sqlExecute(query, "personal")
                    End If
                ElseIf Movimiento.Equals("SALARIO") Then
                    GuardarCambioMOdSal()
                    query = "insert into formato_multiple" & _
                    "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                    "HORA_CAPTURA,USUARIO,EQUIPO," & _
                    "CAMPO,VALOR_ACTUAL,VALOR_NUEVO," & _
                    "FECHA_EFECTIVA,TIPO_MOVIMIENTO,CONFIRMADO,IMPRESO,COMENTARIO, PERIODO_PRUEBA) " & _
                    "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                    "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                    "'SACTUAL','" + txtSueldoActual.Text + "','" + txtCambioA.Text + "'," & _
                    "'" + FechaSQL(txtFechaEfectivaSal.Value) + "','SALARIO','0','0','" & pnlSalario.AccessibleDescription.Trim & "', '0')"
                    gpSueldos.AccessibleDescription = pnlSalario.AccessibleDescription
                    sqlExecute(query, "personal")
                End If

                Agregar = False
                ActualizarRegistro()
                HabilitarPaneles()
                botoneseditar()
                HabilitarBotones()
            ElseIf Editar Then
                If Movimiento.Equals("BAJA") Then
                    query = "UPDATE formato_multiple " & _
                            "SET COMENTARIO='" + txtComentarioBaja.Text + "',FECHA_BAJA='" + txtBaja.Value + "',COD_MOT_BA='" + cmbMotivo.SelectedValue.ToString + "',COD_MOT='" + cmbMotivoImss.SelectedValue.ToString + "' " & _
                            "where COD_COMP='" + compa + "' and RELOJ='" + Reloj + "' and TIPO_MOVIMIENTO='BAJA' AND CONFIRMADO='0'"
                    sqlExecute(query, "personal")
                ElseIf Movimiento.Equals("AUSENTISMO") Then
                    query = "UPDATE formato_multiple " & _
                            "set COMENTARIO='" + txtComentarioAus.Text + "',TIPO_AUS='" + cmbAusentismo.SelectedValue.ToString + "',FECHA_INICIO='" + FechaSQL(txtFechaAus.Value) + "'," & _
                            "CANTIDAD_DIAS='" + txtDias.Value.ToString + "' " & _
                            "where COD_COMP='" + compa + "' and RELOJ='" + Reloj + "' and TIPO_MOVIMIENTO='AUSENTISMO' AND CONFIRMADO='0'"
                    sqlExecute(query, "personal")
                ElseIf Movimiento.Equals("TURNO") Then
                    query = "UPDATE formato_multiple " & _
                            "set COMENTARIO='" + txtComentarioTurno.Text + "',VALOR_ACTUAL='" + lblTurno.AccessibleDescription + "'," & _
                            "VALOR_NUEVO='" + cmbTurnoNuevo.SelectedValue.ToString + "',FECHA_EFECTIVA='" + FechaSQL(txtFechaEfectivaTu.Value) + "' " & _
                            "where COD_COMP='" + compa + "' and RELOJ='" + Reloj + "' and TIPO_MOVIMIENTO='TURNO' AND CONFIRMADO='0' AND CAMPO='COD_TURNO'"
                    sqlExecute(query, "personal")
                    query = "UPDATE formato_multiple " & _
                            "set COMENTARIO='" + txtComentarioTurno.Text + "',VALOR_ACTUAL='" + lblHorario.AccessibleDescription + "'," & _
                            "VALOR_NUEVO='" + cmbHorarioNuevo.SelectedValue.ToString + "',FECHA_EFECTIVA='" + FechaSQL(txtFechaEfectivaTu.Value) + "' " & _
                            "where COD_COMP='" + compa + "' and RELOJ='" + Reloj + "' and TIPO_MOVIMIENTO='TURNO' AND CONFIRMADO='0' AND CAMPO='COD_HORA'"
                    sqlExecute(query, "personal")
                    ' ElseIf Movimiento.Equals("POSICION") Then
                    ' sqlExecute("delete formato_multiple where tipo_movimiento='POSICION' AND reloj = '" + Reloj + "' and confirmado ='0' and cod_comp='" + compa + "'")
                    '     If chkArea.Checked Then
                    '         query = "UPDATE formato_multiple " & _
                    '         "set VALOR_ACTUAL='" + cmbAreaActual.SelectedValue + "'," & _
                    '         "VALOR_NUEVO='" + cmbAreaNueva.SelectedValue + "',FECHA_EFECTIVA='" + FechaSQL(txtFechaEfectivaPos.Value) + "' " & _
                    '         "where COD_COMP='" + compa + "' and RELOJ='" + Reloj + "' and TIPO_MOVIMIENTO='POSICION' AND CONFIRMADO='0' AND CAMPO='COD_LINEA'"
                    '         sqlExecute(query, "personal")
                    '     End If
                    '     If chkDepto.Checked Then
                    '         query = "UPDATE formato_multiple " & _
                    '        "set VALOR_ACTUAL='" + cmbDepartamentoActual.SelectedValue + "'," & _
                    '         "VALOR_NUEVO='" + cmbDepartamentoNuevo.SelectedValue + "',FECHA_EFECTIVA='" + FechaSQL(txtFechaEfectivaPos.Value) + "' " & _
                    '         "where COD_COMP='" + compa + "' and RELOJ='" + Reloj + "' and TIPO_MOVIMIENTO='POSICION' AND CONFIRMADO='0' AND CAMPO='COD_DEPTO'"
                    '         sqlExecute(query, "personal")
                    '     End If
                    '     If chkSuper.Checked Then
                    '         query = "UPDATE formato_multiple " & _
                    '"set  VALOR_ACTUAL='" + cmbSupervisorActual.SelectedValue + "'," & _
                    ' "VALOR_NUEVO='" + cmbSuperVisorNuevo.SelectedValue.ToString + "',FECHA_EFECTIVA='" + FechaSQL(txtFechaEfectivaPos.Value) + "' " & _
                    ' "where COD_COMP='" + compa + "' and RELOJ='" + Reloj + "' and TIPO_MOVIMIENTO='POSICION' AND CONFIRMADO='0' AND CAMPO='COD_SUPER'"
                    '         sqlExecute(query, "personal")
                    '     End If
                    '     If chkPuesto.Checked Then
                    '         query = "UPDATE formato_multiple " & _
                    '         "VALOR_ACTUAL='" + cmbPuestoActual.SelectedValue + "'," & _
                    '         "VALOR_NUEVO='" + cmbPuestoNuevo.SelectedValue.ToString + "',FECHA_EFECTIVA='" + FechaSQL(txtFechaEfectivaPos.Value) + "' " & _
                    '             "where COD_COMP='" + compa + "' and RELOJ='" + Reloj + "' and TIPO_MOVIMIENTO='POSICION' AND CONFIRMADO='0' AND CAMPO='COD_PUESTO'"
                    '         sqlExecute(query, "personal")
                    '     End If
                ElseIf Movimiento.Equals("POSICION") Then
                    sqlExecute("delete formato_multiple where tipo_movimiento='POSICION' AND reloj = '" + Reloj + "' and confirmado ='0' and cod_comp='" + compa + "'")
                    If chkArea.Checked Then
                        query = "insert into formato_multiple" & _
                       "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                       "HORA_CAPTURA,USUARIO,EQUIPO," & _
                       "CAMPO,VALOR_ACTUAL,VALOR_NUEVO," & _
                       "FECHA_EFECTIVA,TIPO_MOVIMIENTO,CONFIRMADO,IMPRESO,COMENTARIO) " & _
                       "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                       "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                       "'COD_AREA','" + lblArea.AccessibleDescription + "','" + cmbAreaNueva.SelectedValue + "'," & _
                       "'" + FechaSQL(txtFechaEfectivaPos.Value) + "','POSICION','0','0','')"
                        sqlExecute(query, "personal")
                    End If
                    If chkDepto.Checked Then
                        query = "insert into formato_multiple" & _
                       "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                       "HORA_CAPTURA,USUARIO,EQUIPO," & _
                       "CAMPO,VALOR_ACTUAL,VALOR_NUEVO," & _
                       "FECHA_EFECTIVA,TIPO_MOVIMIENTO,CONFIRMADO,IMPRESO,COMENTARIO) " & _
                       "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                       "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                       "'COD_DEPTO','" + lblDepto.AccessibleDescription + "','" + cmbDepartamentoNuevo.SelectedValue + "'," & _
                       "'" + FechaSQL(txtFechaEfectivaPos.Value) + "','POSICION','0','0','')"
                        sqlExecute(query, "personal")
                    End If
                    If chkSuper.Checked Then
                        query = "insert into formato_multiple" & _
                       "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                       "HORA_CAPTURA,USUARIO,EQUIPO," & _
                       "CAMPO,VALOR_ACTUAL,VALOR_NUEVO," & _
                       "FECHA_EFECTIVA,TIPO_MOVIMIENTO,CONFIRMADO,IMPRESO,COMENTARIO) " & _
                       "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                       "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                       "'COD_SUPER','" + lblSuper.AccessibleDescription + "','" + cmbSuperVisorNuevo.SelectedValue + "'," & _
                       "'" + FechaSQL(txtFechaEfectivaPos.Value) + "','POSICION','0','0','')"
                        sqlExecute(query, "personal")
                    End If
                    If chkPuesto.Checked Then
                        query = "insert into formato_multiple" & _
                       "(COD_COMP,RELOJ,FECHA_CAPTURA," & _
                       "HORA_CAPTURA,USUARIO,EQUIPO," & _
                       "CAMPO,VALOR_ACTUAL,VALOR_NUEVO," & _
                       "FECHA_EFECTIVA,TIPO_MOVIMIENTO,CONFIRMADO,IMPRESO,COMENTARIO) " & _
                       "VALUES('" + compa + "','" + Reloj + "','" + FechaSQL(Date.Now) + "'," & _
                       "'" + FechaHoraSQL(Date.Now) + "','" + Usuario + "','" + My.Computer.Name + "'," & _
                       "'COD_PUESTO','" + lblPuesto.AccessibleDescription + "','" + cmbPuestoNuevo.SelectedValue + "'," & _
                       "'" + FechaSQL(txtFechaEfectivaPos.Value) + "','POSICION','0','0','')"
                        sqlExecute(query, "personal")
                    End If
                ElseIf Movimiento.Equals("SALARIO") Then
                    GuardarCambioMOdSal()
                    query = "UPDATE formato_multiple " & _
                            "SET COMENTARIO='" + pnlSalario.AccessibleDescription + "',FECHA_EFECTIVA='" + txtFechaEfectivaSal.Value + "',VALOR_ACTUAL='" + txtSueldoActual.Text + "',VALOR_NUEVO='" + txtCambioA.Text + "' " & _
                            "where COMENTARIO='" + gpSueldos.AccessibleDescription + "' and tipo_movimiento='SALARIO'"
                    gpSueldos.AccessibleDescription = pnlSalario.AccessibleDescription
                    sqlExecute(query, "personal")
                End If
                Editar = False
                ActualizarRegistro()
                HabilitarPaneles()
                botoneseditar()
                HabilitarBotones()
            Else

                Agregar = True
                HabilitarPaneles()
                botoneseditar()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try


    End Sub
    Private Sub GuardarCambioMOdSal()
        Dim cadena As String
        Dim CambioValido As Boolean = True
        Dim Notas As String
        Dim Integrado As String
        Dim ID As String = pnlSalario.AccessibleDescription
        dtTemporal = sqlExecute("UPDATE configuracion SET cod_tipo_mod = '" & cmbTipoModSal.SelectedValue & "', fecha_mod = '" & FechaSQL(txtFechaEfectivaSal.Value) & "' WHERE usuario = '" & Usuario & "'", "Seguridad")
        dtTemp = sqlExecute("DELETE FROM mod_sal WHERE id = '" & ID & "'")
        Notas = txtNotas.Text
        Notas = Notas.Replace("'", "''")
        Notas = Notas.Replace(Chr(34), "''")
        Integrado = txtIntegrado.Text.Replace("$", "")
        Integrado = Integrado.Replace(",", "")
       
        '***********************Calcular compa_ratio nuevo y ant **********
        Dim SActual As Double = Double.Parse(txtCambioA.Text)
        Dim compa_ratio_ant As Double = CompaRatio
        Dim compa_ratio_nvo As Double
        Dim NivelAnt As String = Nivel
        Dim NivelNuevo As String = cmbNivel.SelectedValue
        Dim MidPoint As Double = 0
        Dim dtCompaRatio As New DataTable
        dtCompaRatio = sqlExecute("select * from niveles where cod_comp = '" & compa & "' and nivel = '" & NivelNuevo & "'")
        For Each row As DataRow In dtCompaRatio.Rows
            MidPoint = IIf(IsDBNull(row.Item("MED")), 0, row.Item("MED"))
            If MidPoint <> 0 Then
                compa_ratio_nvo = ((SActual * 30.4) / MidPoint) * 100
            Else
                compa_ratio_nvo = 0
            End If
        Next

        cadena = "INSERT INTO mod_sal (cod_comp,reloj,cod_tipo_mod,cambio_de,cambio_a,provar,fact_int,fecha,notas,nivel,integrado,hoy,compa_ratio_ant,compa_ratio_nvo) VALUES ('"
        cadena = cadena & compa & "','" & txtReloj.Text & "','" & cmbTipoModSal.SelectedValue & "'," & txtSueldoActual.Text & "," & txtCambioA.Text & ","
        cadena = cadena & txtProVar.Text & "," & txtFactorInt.Text & ",'" & FechaSQL(txtFechaEfectivaSal.Value) & "','" & txtNotas.Text & "','" & cmbNivel.SelectedValue & "',"
        cadena = cadena & Integrado & ", GETDATE(),'" + Format(compa_ratio_ant, "f") + "','" + Format(compa_ratio_nvo, "f") + "')"
        dtTemp = sqlExecute(cadena)
        dtTemp = sqlExecute("SELECT MAX(ID) AS ID FROM mod_sal")
        If dtTemp.Rows.Count <= 0 Then
            ID = 0
        Else
            ID = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("ID")), 0, dtTemp.Rows.Item(0).Item("ID"))
        End If
        pnlSalario.AccessibleDescription = ID

    End Sub
    Private Sub txtCambioA_TextChanged(sender As Object, e As EventArgs) Handles txtCambioA.TextChanged
        Try
            Dim Integrado As Double = (txtCambioA.Text * txtFactorInt.Text) + txtProVar.Text
            txtIntegrado.Text = FormatCurrency(Integrado)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbNivel_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNivel.SelectedValueChanged
        Dim sdo As Double
        dtTemp = sqlExecute("SELECT sueldo FROM niveles WHERE cod_comp = '" & compa & "' AND nivel = '" & cmbNivel.SelectedValue & "'")
        If dtTemp.Rows.Count > 0 Then
            sdo = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("sueldo")), 0, dtTemp.Rows.Item(0).Item("sueldo"))

            If sdo <> 0 Then
                txtCambioA.Text = sdo
            End If
            txtCambioA.Enabled = (sdo = 0)
        End If
    End Sub

    Private Sub cmbNivel_Validated(sender As Object, e As EventArgs) Handles cmbNivel.Validated
        Dim sdo As Double
        dtTemp = sqlExecute("SELECT sueldo FROM niveles WHERE cod_comp = '" & compa & "' AND nivel = '" & cmbNivel.SelectedValue & "'")
        If dtTemp.Rows.Count > 0 Then
            sdo = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("sueldo")), 0, dtTemp.Rows.Item(0).Item("sueldo"))

            If sdo <> 0 Then
                txtCambioA.Text = sdo
            End If
            txtCambioA.Enabled = (sdo = 0)

        End If

    End Sub
    'Private Sub botoneseditar()
    '    If Editar Or Agregar Then
    '        btnNuevo.Image = PIDA.My.Resources.Ok16
    '        btnEditar.Image = PIDA.My.Resources.CancelX
    '        btnNuevo.Text = "Aceptar"
    '        btnEditar.Text = "Cancelar"
    '        btnCerrar.Enabled = False
    '        btnConfirmar.Enabled = False
    '        btnNuevo.Enabled = True
    '        btnEditar.Enabled = True
    '        btnConfirmar.Enabled = False
    '        btnBorrar.Enabled = False
    '        tabAusencia.Enabled = tabAusencia.AccessibleDescription.Equals(Movimiento)
    '        tabBaja.Enabled = tabBaja.AccessibleDescription.Equals(Movimiento)
    '        tabPosicion.Enabled = tabPosicion.AccessibleDescription.Equals(Movimiento)
    '        tabSalario.Enabled = tabSalario.AccessibleDescription.Equals(Movimiento)
    '        tabTurno.Enabled = tabTurno.AccessibleDescription.Equals(Movimiento)
    '    Else
    '        btnNuevo.Image = PIDA.My.Resources.NewRecord
    '        btnEditar.Image = PIDA.My.Resources.Edit
    '        btnNuevo.Text = "Agregar"
    '        btnEditar.Text = "Editar"
    '        btnCerrar.Enabled = True
    '        btnBorrar.Enabled = True
    '        btnConfirmar.Enabled = True
    '        tabAusencia.Enabled = True

    '        tabBaja.Enabled = True
    '        tabTurno.Enabled = True
    '        tabPosicion.Enabled = True
    '        tabSalario.Enabled = True
    '    End If
    'End Sub


    Private Sub botoneseditar()
        If Editar Or Agregar Then
            btnNuevo.Image = PIDA.My.Resources.Ok16
            btnEditar.Image = PIDA.My.Resources.CancelX
            btnNuevo.Text = "Aceptar"
            btnEditar.Text = "Cancelar"
            btnCerrar.Enabled = False
            '     btnConfirmar.Visible = False
            btnNuevo.Enabled = True
            btnEditar.Enabled = True
            ' btnConfirmar.Visible = False
            '   btnBorrar.Visible = False
            tabAusencia.Enabled = tabAusencia.AccessibleDescription.Equals(Movimiento)
            tabBaja.Enabled = tabBaja.AccessibleDescription.Equals(Movimiento)
            tabPosicion.Enabled = tabPosicion.AccessibleDescription.Equals(Movimiento)
            tabSalario.Enabled = tabSalario.AccessibleDescription.Equals(Movimiento)
            tabTurno.Enabled = tabTurno.AccessibleDescription.Equals(Movimiento)
        Else
            btnNuevo.Image = PIDA.My.Resources.NewRecord
            btnEditar.Image = PIDA.My.Resources.Edit
            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"
            btnCerrar.Enabled = True
            '   btnBorrar.Visible = True
            '  btnConfirmar.Visible = True
            tabAusencia.Enabled = True
            tabBaja.Enabled = True
            tabTurno.Enabled = True
            tabPosicion.Enabled = True
            tabSalario.Enabled = True
        End If
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Editar Or Agregar Then
            Editar = False
            Agregar = False
            ActualizarRegistro()
            HabilitarPaneles()
            botoneseditar()
            HabilitarBotones()
        Else
            Editar = True
            HabilitarPaneles()
            botoneseditar()
        End If


    End Sub

    Private Sub chkArea_CheckedChanged(sender As Object, e As EventArgs) Handles chkArea.CheckedChanged, chkDepto.CheckedChanged, chkPuesto.CheckedChanged, chkSuper.CheckedChanged
        cmbAreaNueva.Enabled = chkArea.Checked

        cmbDepartamentoNuevo.Enabled = chkDepto.Checked
        cmbPuestoNuevo.Enabled = chkPuesto.Checked
        cmbSuperVisorNuevo.Enabled = chkSuper.Checked
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("¿Estás seguro que deseas eliminar este movimiento  de '" + Movimiento + "'?", "Borrar movimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sqlExecute("delete formato_multiple where cod_comp ='" + compa + "' and reloj = '" + Reloj + "' and confirmado ='0' and tipo_movimiento = '" + Movimiento + "'")
        End If

    End Sub

    Private Sub cmbMotivo_PopupClose(sender As Object, e As EventArgs) Handles cmbMotivo.PopupClose
        Dim temp As DataTable = sqlExecute("select cod_mot_im from cod_mot_baj where cod_mot_ba ='" + cmbMotivo.SelectedValue + "'")
        If temp.Rows.Count > 0 Then
            cmbMotivoImss.SelectedValue = temp.Rows(0).Item("cod_mot_im")
        End If
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("¿Estás seguro que deseas aplicar este movimiento  de '" + Movimiento + "'?", "Aplicar movimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sqlExecute("update formato_multiple set confirmado ='1' where cod_comp ='" + compa + "' and reloj = '" + Reloj + "' and confirmado ='0' and tipo_movimiento = '" + Movimiento + "'")
        End If
        ActualizarRegistro()
        HabilitarBotones()
    End Sub

    Private Sub cmbTurnoNuevo_PopupClose(sender As Object, e As EventArgs) Handles cmbTurnoNuevo.LostFocus
        If FiltroXUsuario.Contains("COD_COMP") Or FiltroXUsuario.Contains("cod_comp") Then
            FiltroMultiforma = " and " & FiltroXUsuario
        Else
            FiltroMultiforma = " and cod_comp='" & compa & "'"
        End If
        dtHorarios2 = sqlExecute("select  *  from horarios where cod_turno='" + cmbTurnoNuevo.SelectedValue.ToString + "'" & FiltroMultiforma)
        cmbHorarioNuevo.DataSource = dtHorarios2
    End Sub
    Private Sub txtCambioA_Validated(sender As Object, e As EventArgs) Handles txtCambioA.Validated
        If Double.Parse(txtCambioA.Text) <= Double.Parse(txtSueldoActual.Text) Then
            MessageBox.Show("El salario nuevo no puedes ser igual o menos al salario actual, porfavor verificalo", "Cambio incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCambioA.Text = Double.Parse(txtSueldoActual.Text) + 1
            txtCambioA.SelectAll()
            txtCambioA.Focus()
        End If
    End Sub
End Class