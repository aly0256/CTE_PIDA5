Public Class frmSMedico

#Region "Declaraciones"
    Dim dtVacantes As New DataTable        'Tabla de Vacantes
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtRegistroMedico As New DataTable     'Mantiene el registro medico actual
    Dim dtTemp As New DataTable        'Tabla de uso general
    Dim dtEdoCivil As New DataTable     'Tabla de estados civiles
    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim banderaError As Boolean
#End Region

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("Candidatos", "Folio", dtRegistro, "Reclutamiento")
        MostrarInformacion()
    End Sub

    Private Sub MostrarInformacion()
        Try
            ' If Not dtRegistro.Rows.Count > 0 Or Not dgCalogVacantes.Rows.Count > 0 Then Exit Sub
            If dtRegistro.Rows.Count > 0 Then
                txtFolio.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Folio")), "", dtRegistro.Rows(0).Item("Folio"))
                cmbFechaAplica.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("Captura")), Nothing, Date.Parse(FechaSQL(dtRegistro.Rows(0).Item("Captura"))))
                cmbVacante.SelectedValue = dtRegistro.Rows(0).Item("cod_vac").ToString
                Txtnombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre")), "", dtRegistro.Rows(0).Item("nombre").ToString.Trim)
                Txtnombre.Text &= IIf(IsDBNull(dtRegistro.Rows(0).Item("SegundoNombre")), "", " " & dtRegistro.Rows(0).Item("SegundoNombre").ToString.Trim)
                Txtpaterno.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Paterno")), "", dtRegistro.Rows(0).Item("Paterno").ToString.Trim)
                Txtmaterno.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Materno")), "", dtRegistro.Rows(0).Item("Materno").ToString.Trim)
                If IsDBNull(dtRegistro.Rows(0).Item("genero")) Then
                    swGenero.SetValue(True, DevComponents.DotNetBar.eEventSource.Code)
                Else
                    If dtRegistro.Rows(0).Item("genero").ToString = "M" Then
                        swGenero.SetValue(True, DevComponents.DotNetBar.eEventSource.Code)
                    Else
                        swGenero.SetValue(False, DevComponents.DotNetBar.eEventSource.Code)
                    End If
                End If
                txtNoHijos.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Numero_Hijos")), "", dtRegistro.Rows(0).Item("Numero_Hijos").ToString.Trim)
                txtEdoCivil.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_civil")), "", dtRegistro.Rows(0).Item("cod_civil").ToString.Trim)
                dtEdoCivil = sqlExecute("select top 1 * from civil where cod_civil = '" & IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_civil")), "''", dtRegistro.Rows(0).Item("cod_civil").ToString.Trim) & "'", "Personal")
                If dtEdoCivil.Rows.Count > 0 Then
                    txtEdoCivil.Text = IIf(IsDBNull(dtEdoCivil.Rows(0).Item("Nombre")), "", dtEdoCivil.Rows(0).Item("Nombre").ToString.Trim)
                Else
                    txtEdoCivil.Text = ""
                End If
                dtRegistroMedico = sqlExecute("select top 1 * from Revisiones_Medicas where Folio = '" & txtFolio.Text.Trim & "'", "Reclutamiento")
                If dtRegistroMedico.Rows.Count > 0 Then
                    If IsDBNull(dtRegistroMedico.Rows(0).Item("aptitud")) Then
                        chkApto.Checked = True
                    Else
                        Select Case dtRegistroMedico.Rows(0).Item("aptitud").ToString
                            Case 1
                                chkApto.Checked = True
                            Case 2
                                chkNoApto.Checked = True
                            Case 3
                                chkAptoPendiente.Checked = True
                            Case 4
                                chkNoAptoSinLentes.Checked = True
                            Case 5
                                chkNoAptoCFC.Checked = True
                            Case Else
                                chkApto.Checked = True
                        End Select
                    End If
                    If IsDBNull(dtRegistro.Rows(0).Item("AprobadoMedico")) Then
                        'swAprobado.SetValue(True, DevComponents.DotNetBar.eEventSource.Code)
                        swAprobado.CheckState = CheckState.Indeterminate
                        swAprobado.Text = "Pendiente"
                    Else
                        If dtRegistro.Rows(0).Item("AprobadoMedico").ToString = "1" Then
                            'swAprobado.SetValue(True, DevComponents.DotNetBar.eEventSource.Code)
                            swAprobado.CheckState = CheckState.Checked
                            swAprobado.Text = "Aprobado"
                        Else
                            'swAprobado.SetValue(False, DevComponents.DotNetBar.eEventSource.Code)
                            swAprobado.CheckState = CheckState.Unchecked
                            swAprobado.Text = "Rechazado"
                        End If
                    End If
                    txtComentarios.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("ComentariosMedico")), "", dtRegistro.Rows(0).Item("ComentariosMedico").ToString.Trim)
                    clkCronometro.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("DuracionMedico")), "00:00:00", dtRegistro.Rows(0).Item("DuracionMedico").ToString)
                    clkCronometro.Update()
                Else
                    swGenero.SetValue(True, DevComponents.DotNetBar.eEventSource.Code)
                    chkApto.Checked = True
                    'swAprobado.SetValue(False, DevComponents.DotNetBar.eEventSource.Code)
                    swAprobado.CheckState = CheckState.Unchecked
                    swAprobado.Text = "Rechazado"
                    txtComentarios.Text = ""
                End If
            Else
                txtFolio.Text = ""
                cmbVacante.SelectedIndex = -1
                cmbFechaAplica.Value = Nothing
                Txtnombre.Text = ""
                Txtpaterno.Text = ""
                Txtmaterno.Text = ""
                swGenero.SetValue(True, DevComponents.DotNetBar.eEventSource.Code)
                txtComentarios.Text = ""
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar Información, Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "Error")
        End Try
        HabilitarBotones()
    End Sub

    Private Sub frmSMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            banderaError = False
            dtVacantes = sqlExecute("select Cod_Vac as 'CODIGO',Vacante as 'VACANTE' from vacantes order by Vacante", "Reclutamiento")
            cmbVacante.DataSource = dtVacantes
            cmbVacante.ValueMember = "CODIGO"
            cmbVacante.DisplayMembers = "VACANTE"
            cmbVacante.SelectedIndex = -1
            'dtLista = sqlExecute("select top 1000 cod_vac as 'Codigo',planta as 'Planta',Rtrim(ltrim(requisitor)) as 'Requisitor', depto as 'Depto',turno as 'Turno', vacante as 'Vacante',Activo as 'Activa', Vencimiento ,'' as imagen from vacantes order by cod_vac desc", "Reclutamiento")
            'dtLista.DefaultView.Sort = "Codigo"
            dtRegistro = sqlExecute("select top 1 * from Candidatos order by Folio ASC", "Reclutamiento")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub HabilitarBotones()

        Dim NoRec As Boolean
        dtRegistroMedico = sqlExecute("select top 1 * from Revisiones_Medicas where Folio = '" & txtFolio.Text.Trim & "'", "Reclutamiento")
        NoRec = dtRegistroMedico.Rows.Count = 0

        btnPrimero.Enabled = Not (Agregar Or Editar)
        btnAnterior.Enabled = Not (Agregar Or Editar)
        btnSiguiente.Enabled = Not (Agregar Or Editar)
        btnUltimo.Enabled = Not (Agregar Or Editar)
        btnReporte.Enabled = Not (Agregar Or Editar)
        btnBuscar.Enabled = Not (Agregar Or Editar)
        btnBorrar.Enabled = Not (Agregar Or Editar)
        btnCerrar.Enabled = Not (Agregar Or Editar)

        btnNuevo.Enabled = NoRec
        pnlGeneral.Enabled = Agregar Or Editar
        pnlAptitud.Enabled = Agregar Or Editar
        pnlAprobado.Enabled = Agregar Or Editar

        If Agregar Or Editar Then
            ' Si está activa la edición o nuevo registro
            btnNuevo.Image = PIDA.My.Resources.Ok16
            btnEditar.Image = PIDA.My.Resources.CancelX
            btnNuevo.Text = "Aceptar"
            btnEditar.Text = "Cancelar"
            btnNuevo.Enabled = True
            btnEditar.Enabled = True
            txtComentarios.Enabled = True
        Else

            btnNuevo.Image = PIDA.My.Resources.NewRecord
            btnEditar.Image = PIDA.My.Resources.Edit

            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"
            btnEditar.Enabled = Not NoRec
            btnNuevo.Enabled = NoRec
            txtComentarios.Enabled = False
        End If

        txtFolio.Enabled = False
        Txtnombre.Enabled = False
        cmbVacante.Enabled = False
        cmbFechaAplica.Enabled = False
        Txtpaterno.Enabled = False
        Txtmaterno.Enabled = False
        swGenero.Enabled = False
        txtEdoCivil.Enabled = False
        txtNoHijos.Enabled = False
    End Sub


    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("Candidatos", "Folio", RTrim(txtFolio.Text), dtRegistro, "Reclutamiento")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("Candidatos", "Folio", RTrim(txtFolio.Text), dtRegistro, "Reclutamiento")
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("Candidatos", "Folio", dtRegistro, "Reclutamiento")
        MostrarInformacion()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtTemp = dtRegistro
        Try
            frmBuscarFolio.ShowDialog(Me)
            If Folio <> "CANCEL" Then
                dtRegistro = sqlExecute("SELECT top 1 * FROM Candidatos WHERE folio ='" & Folio & "'", "RECLUTAMIENTO")
                If dtRegistro.Rows.Count > 0 Then
                    MostrarInformacion()
                Else
                    MessageBox.Show("El solicitante con folio " & Folio & " no fue localizado.", "Solicitante no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtRegistro = dtTemp
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim strQry As String = ""
        Dim mensaje As String = ""
        Dim intApto As Integer = 0
        Try
            Select Case True
                Case chkApto.Checked
                    intApto = 1
                Case chkNoApto.Checked
                    intApto = 2
                Case chkAptoPendiente.Checked
                    intApto = 3
                Case chkNoAptoSinLentes.Checked
                    intApto = 4
                Case chkNoAptoCFC.Checked
                    intApto = 5
                Case Else
                    intApto = 0
            End Select
            If Agregar Then
                mensaje = "Agregar"
                'ValidarCaptura()
                If MessageBox.Show("¿Realmente desea guardar los datos?", "Guardar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                Else
                    Exit Sub
                End If
                If banderaError Then
                    Exit Sub
                End If
                dtRegistroMedico = sqlExecute("select folio from revisiones_medicas where folio = '" & txtFolio.Text.Trim & "' ", "Reclutamiento")
                If dtRegistroMedico.Rows.Count > 0 Then
                    MsgBox("Ya existe una revision para el folio [" & txtFolio.Text.Trim & "]", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If
                strQry = "insert into revisiones_medicas (Folio,aptitud,Captura,Usuario) " & _
                         "values ('" & txtFolio.Text.Trim & "','" & intApto & "', getdate(),'" & Usuario & "')"
                dtRegistroMedico = sqlExecute(strQry, "Reclutamiento")

                If dtRegistroMedico.Columns.Count = 1 Then
                    MsgBox("Error al intentar dar de alta la evaluación médica. Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                Else
                    strQry = "Update Candidatos set AprobadoMedico = '" & IIf(swAprobado.CheckValue, "1", "0") & "', ComentariosMedico = '" & txtComentarios.Text.Trim & "', DuracionMedico = '" & clkCronometro.Value.TimeOfDay.ToString & "' where Folio = '" & txtFolio.Text.Trim & "' "
                    dtTemp = sqlExecute(strQry, "Reclutamiento")
                    MsgBox("Evaluación médica dada de alta satisfactoriamente. " & Environment.NewLine & Environment.NewLine & "Favor de verificar la aprobacion del candidato.", MsgBoxStyle.Information, "Información")
                    Agregar = False
                    Timer1.Stop()
                End If

            ElseIf Editar Then
                ' Si Editar, entonces guardar cambios a registro
                mensaje = "Editar"
                'ValidarCaptura()
                If MessageBox.Show("¿Realmente desea guardar los datos?", "Guardar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                Else
                    Exit Sub
                End If
                If banderaError Then
                    Exit Sub
                End If
                strQry = "UPDATE revisiones_medicas SET aptitud =" & intApto & ", Captura = getdate(),Usuario = '" & Usuario & "' where Folio = '" & txtFolio.Text.Trim & "' "
                dtRegistroMedico = sqlExecute(strQry, "Reclutamiento")
                If dtRegistroMedico.Columns.Count = 1 Then
                    MsgBox("Error al intentar actualizar la evaluación médica. Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                Else
                    strQry = "Update Candidatos set AprobadoMedico = '" & IIf(swAprobado.CheckValue, "1", "0") & "', ComentariosMedico = '" & txtComentarios.Text.Trim & "' where Folio = '" & txtFolio.Text.Trim & "' "
                    dtTemp = sqlExecute(strQry, "Reclutamiento")
                    MsgBox("Evaluación médica actualizada satisfactoriamente. " & Environment.NewLine & Environment.NewLine & "Favor de verificar la aprobacion del candidato.", MsgBoxStyle.Information, "Información")
                    Editar = False
                End If
            Else
                Agregar = True
                clkCronometro.Value = "00:00:00"
                Timer1.Start()
            End If
        Catch ex As Exception
            MsgBox("Error al " & mensaje & " registro. Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "Error")
            banderaError = True
        End Try
        'If banderaError Then
        '    Exit Sub
        'End If
        Editar = False
        HabilitarBotones()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If Not Editar And Not Agregar Then
                Editar = True
                HabilitarBotones()
                txtFolio.Focus()
            Else
                Editar = False
            End If
            Agregar = False
            dtRegistro = sqlExecute("SELECT top 1 * FROM Candidatos WHERE folio ='" & txtFolio.Text.Trim & "'", "RECLUTAMIENTO")
            If dtRegistro.Rows.Count > 0 Then
                MostrarInformacion()
            Else
                MessageBox.Show("El solicitante con folio " & Folio & " no fue localizado.", "Solicitante no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            HabilitarBotones()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

    End Sub

    Public Overloads Sub Show(ByVal Folio As String)
        MyBase.Show()
        dtRegistro = sqlExecute("SELECT top 1 * FROM Candidatos WHERE folio ='" & Folio & "'", "RECLUTAMIENTO")
        If dtRegistro.Rows.Count > 0 Then
            MostrarInformacion()
        Else
            MessageBox.Show("El solicitante con folio " & Folio & " no fue localizado.", "Solicitante no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        clkCronometro.Value = clkCronometro.Value.AddSeconds(1)
        clkCronometro.Update()
    End Sub

    Private Sub swAprobado2_CheckedChanged(sender As Object, e As EventArgs) Handles swAprobado.CheckedChanged
        Try
            If swAprobado.CheckValue = "1" Then swAprobado.Text = "Rechazado"
            If swAprobado.CheckValue = "0" Then swAprobado.Text = "Aprobado"
            If swAprobado.CheckValue = "NULL" Then swAprobado.Text = "Rechazado"
        Catch
        End Try
    End Sub
End Class