Imports System.Data.SqlClient

Public Class frmAutorizacionTiempoExtra

    Dim dtAutorizadas As New DataTable
    Dim DiasAut As Integer
    Dim Nuevo As Boolean
    Dim CargaInformacion As Boolean

    Private Sub frmAutorizacionTiempoExtra_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyValue = Keys.F5 Then
            MostrarInformacion()
        End If
    End Sub


    Private Sub frmAutorizacionTiempoExtra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtPeriodos As New DataTable
        CargaInformacion = True
        dtTemporal = sqlExecute("SELECT dias_autorizacionTE FROM perfiles WHERE cod_perfil " & Perfil, "seguridad")
        DiasAut = IIf(IsDBNull(dtTemporal.Rows(0).Item("dias_autorizacionTE")), 1, dtTemporal.Rows(0).Item("dias_autorizacionTE"))
        dtPeriodos = sqlExecute("SELECT ano+periodo AS unico,ano,periodo FROM periodos WHERE activo = 1 ORDER BY ano DESC,periodo desc", "TA")
        cmbPeriodo.DataSource = dtPeriodos
        cmbPeriodo.SelectedValue = ObtenerAnoPeriodo(Now)
        If cmbPeriodo.SelectedValue Is Nothing Then
            cmbPeriodo.SelectedIndex = 0
        End If
        'Dim InfoST As New DevComponents.DotNetBar.SuperTooltipInfo
        'InfoST.BodyText = vbCrLf & "Para autorizar todo el tiempo extra trabajado," & vbCrLf & "indicar ""*"" o ""TODO"""
        'InfoST.BodyImage = My.Resources.Info64
        ''SuperTooltip1.SetSuperTooltip(dgAutorizacion.Columns("EXTRAS_AUTORIZADAS"), InfoST)
        'SuperTooltip1.SetSuperTooltip(btnMostrarInformacion, InfoST)

        My.Application.DoEvents()
    End Sub

    Private Sub EmpNav_Enter(sender As Object, e As EventArgs) Handles EmpNav.Enter

    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim x As Integer
        Try
            x = 0
            frmAutorizacionTEEmpleado.InicioNuevo(cmbPeriodo.SelectedValue)
            frmAutorizacionTEEmpleado.ShowDialog()
            MostrarInformacion()
            'frmModSalEdicion.ShowDialog()
            'MostrarInformacion()

            'x = dgAutorizacion.Rows.Count - 1
            'If x >= 0 Then
            '    dgAutorizacion.CurrentCell.Selected = False
            '    dgAutorizacion.Rows(x).Selected = True
            '    dgAutorizacion.FirstDisplayedScrollingRowIndex = x
            'End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub MostrarInformacion()
        Try
            If cmbFecha.SelectedValue Is Nothing Then Exit Sub
            CargaInformacion = True
            dtAutorizadas = New DataTable
            Dim strquery As String =
                "SELECT " & _
                "extras_autorizadas.reloj, " & _
                "PERSONALvw.cod_tipo, " & _
                "personalvw.cod_depto, " & _
                "personalvw.cod_turno, " & _
                "fecha, " & _
                "extras_reales, " & _
                "extras_autorizadas, " & _
                "periodo, " & _
                "ano, " & _
                "entrada, " & _
                "salida," & _
                "RTRIM(extras_autorizadas.comentario) AS comentario," & _
                "usuario_s, " & _
                "fecha_s, " & _
                "aplicado, " & _
                "analizado, " & _
                "autori_a1, " & _
                "personalvw.nombres " & _
                "FROM extras_autorizadas LEFT JOIN personal.dbo.personalvw " & _
                "ON extras_autorizadas.reloj= personalvw.reloj WHERE fecha = '" & FechaSQL(cmbFecha.SelectedValue) & _
                "' order by personalvw.cod_tipo asc" ' AND usuario_s ='" & Usuario & "'"
            dtAutorizadas = sqlExecute(strquery, "ta")

            labelTotalVista.Text = "TOTAL: " & dtAutorizadas.Rows.Count & " EMPLEADOS"

            dgAutorizacion.AutoGenerateColumns = False
            dgAutorizacion.DataSource = dtAutorizadas

            dgAutorizacion.Columns("colReloj").ReadOnly = True
            dgAutorizacion.Columns("colNombre").ReadOnly = True
            dgAutorizacion.Columns("colFecha").ReadOnly = True

            dgAutorizacion.Columns("colTipo").ReadOnly = True
            dgAutorizacion.Columns("colDepto").ReadOnly = True
            dgAutorizacion.Columns("colTurno").ReadOnly = True


            dgAutorizacion.Columns("colEntrada").ReadOnly = True
            dgAutorizacion.Columns("colSalida").ReadOnly = True
            dgAutorizacion.Columns("colExtrasReales").ReadOnly = True

            dgAutorizacion.Columns("colAut").ReadOnly = False
            dgAutorizacion.Columns("colAutorizadas").ReadOnly = False
            dgAutorizacion.Columns("colComentario").ReadOnly = False


            dgAutorizacion.Columns("colReloj").DefaultCellStyle.BackColor = SystemColors.InactiveCaption
            dgAutorizacion.Columns("colNombre").DefaultCellStyle.BackColor = SystemColors.InactiveCaption
            dgAutorizacion.Columns("colFecha").DefaultCellStyle.BackColor = SystemColors.InactiveCaption

            dgAutorizacion.Columns("colTipo").DefaultCellStyle.BackColor = SystemColors.InactiveCaption
            dgAutorizacion.Columns("colDepto").DefaultCellStyle.BackColor = SystemColors.InactiveCaption
            dgAutorizacion.Columns("colTurno").DefaultCellStyle.BackColor = SystemColors.InactiveCaption


            dgAutorizacion.Columns("colEntrada").DefaultCellStyle.BackColor = SystemColors.InactiveCaption
            dgAutorizacion.Columns("colSalida").DefaultCellStyle.BackColor = SystemColors.InactiveCaption
            dgAutorizacion.Columns("colExtrasReales").DefaultCellStyle.BackColor = SystemColors.InactiveCaption


            CargaInformacion = False
        Catch ex As SqlClient.SqlException

            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgAutorizacion_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) 'Handles dgAutorizacion.CellContentDoubleClick
        btnEditar.PerformClick()
    End Sub

    

    Private Sub dgAutorizacion_RowLeave(sender As Object, e As DataGridViewCellEventArgs) 'Handles dgAutorizacion.RowLeave, dgAutorizacion.CellEndEdit
        Try
            Dim dReg As DataRow
            Dim dtEmpleado As New DataTable
            Dim Editar As Boolean = False
            Dim R As String
            Dim F As String
            Dim OldVal As String
            Dim NewVal As String
            Try
                If CargaInformacion Then Exit Sub
                R = dgAutorizacion.Item("reloj", e.RowIndex).Value.ToString.Trim
                If R = "" Then Exit Sub
                F = FechaSQL(cmbFecha.SelectedValue)
                'F = FechaSQL(DateTimeInput1.Value)
                If Nuevo Then
                    dtTemporal = sqlExecute("SELECT * FROM extras_autorizadas WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                    If dtTemporal.Rows.Count > 0 Then
                        MessageBox.Show("El empleado " & R & " ya tiene tiempo extra autorizado para el día " & FechaCortaLetra(F) & ".", "Tiempo extra ya autorizado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgAutorizacion.CancelEdit()
                        Nuevo = False
                        dgAutorizacion.Item("reloj", e.RowIndex).Value = ""
                        Exit Sub
                    End If
                    sqlExecute("INSERT INTO extras_autorizadas (reloj,fecha) VALUES ('" & R & "','" & F & "')", "ta")
                    Nuevo = False
                End If

                If Not Nuevo Then
                    dtTemporal = sqlExecute("SELECT * FROM extras_autorizadas WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                    If dtTemporal.Rows.Count > 0 Then
                        dReg = dtTemporal.Rows(0)
                        For Each c In dgAutorizacion.Columns
                            Dim col As String = c.datapropertyname
                            Try
                                If col <> "" Then
                                    If TypeOf dgAutorizacion.Item(c.name, e.RowIndex).value Is String Then
                                        NewVal = dgAutorizacion.Item(c.name, e.RowIndex).value.ToString.Trim
                                        OldVal = IIf(IsDBNull(dReg(c.datapropertyname)), "", dReg(c.datapropertyname)).ToString.Trim

                                    ElseIf TypeOf dgAutorizacion.Item(c.name, e.RowIndex).value Is Date Then
                                        NewVal = FechaSQL(dgAutorizacion.Item(c.name, e.RowIndex).value)
                                        OldVal = FechaSQL(IIf(IsDBNull(dReg(c.datapropertyname)), "", dReg(c.datapropertyname)))
                                    ElseIf IsDBNull(dgAutorizacion.Item(c.name, e.RowIndex).value) Then
                                        NewVal = ""
                                        OldVal = IIf(IsDBNull(dReg(c.datapropertyname)), "", dReg(c.datapropertyname)).ToString.Trim
                                    Else
                                        NewVal = ""
                                        OldVal = ""
                                        'Stop
                                    End If

                                    If OldVal <> NewVal Then
                                        Editar = True


                                        sqlExecute("UPDATE extras_autorizadas SET " & col & " = '" & NewVal & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")

                                        If col = "extras_autorizadas" Then
                                            sqlExecute("UPDATE asist SET extras_autorizadas = '" & NewVal & "'  WHERE reloj = '" & R & "' AND fecha_entro = '" & F & "'", "TA")

                                            Dim dtEmp As DataTable = sqlExecute("select * from personal where reloj = '" & R & "'")
                                            If dtEmp.Rows.Count > 0 Then
                                                ' frmTA.Evaluador(dtEmp.Rows(0), Date.Parse(F), cmbPeriodo.SelectedValue.ToString.Substring(4, 2), cmbPeriodo.SelectedValue.ToString.Substring(0, 4))
                                                LlenaNomSem(dtEmp.Rows(0), cmbPeriodo.SelectedValue.ToString.Substring(4, 2), New DataTable)
                                            End If
                                        End If




                                    End If
                                End If
                            Catch ex As Exception
                                Debug.Print(c.name)
                            End Try
                        Next
                        If Editar Then
                            dtEmpleado = sqlExecute("SELECT cod_super,cod_depto FROM PERSONAL WHERE RELOJ = '" & R & "'")
                            sqlExecute("UPDATE extras_autorizadas SET cod_super = '" & dtEmpleado.Rows(0).Item("COD_SUPER") & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET cod_depto = '" & dtEmpleado.Rows(0).Item("COD_DEPTO") & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET periodo = '" & cmbPeriodo.SelectedValue.ToString.Substring(4, 2) & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET ano = '" & cmbPeriodo.SelectedValue.ToString.Substring(0, 4) & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET usuario_s = '" & Usuario & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET fecha_s = '" & FechaSQL(Now.Date) & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET envio_s = 0,aplicado = 0,analizado = 0  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            'De momento, no se requiere autorización de gerente. Aprobar todo si el supervisor lo captura
                            sqlExecute("UPDATE extras_autorizadas SET usuario_a1 = '" & Usuario & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET fecha_a1 = '" & FechaSQL(Now.Date) & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET autori_a1 = 1  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET envio_a1 = 0,aplicado = 0,analizado = 0  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            'De momento, no se requiere autorización de director. Aprobar todo si el supervisor lo captura 
                            sqlExecute("UPDATE extras_autorizadas SET usuario_a2 = '" & Usuario & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET fecha_a2 = '" & FechaSQL(Now.Date) & "'  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET autori_a2 = 1  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                            sqlExecute("UPDATE extras_autorizadas SET envio_a2 = 0,aplicado = 0,analizado = 0  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                        End If
                    End If
                End If
            Catch ex As SqlClient.SqlException

                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        Dim i As Integer
        Dim ID As String

        Try
            CargaInformacion = True
            pnlEditar.Visible = True
            prgEditar.IsRunning = True
            My.Application.DoEvents()
            i = dgAutorizacion.CurrentCell.RowIndex
            ID = IIf(IsDBNull(dgAutorizacion.Item("reloj", i).Value), "", dgAutorizacion.Item("reloj", i).Value) & cmbPeriodo.SelectedValue
            frmAutorizacionTEEmpleado.MostrarInformacion(ID)
            pnlEditar.Visible = False
            frmAutorizacionTEEmpleado.ShowDialog()
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnMostrarInformacion_Click(sender As Object, e As EventArgs) Handles btnMostrarInformacion.Click
        MostrarInformacion()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        TiempoExFecha = cmbFecha.SelectedValue
        TiempoExFechaEntro = cmbFecha.SelectedValue
        frmOpcionesHrsExtras.ShowDialog()
    End Sub

    Private Sub cmbPeriodo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPeriodo.SelectedValueChanged
        Dim dtPeriodos As New DataTable
        Dim dtFechas As New DataTable
        Dim FIni As Date
        Dim FFin As Date
        Try
            If cmbPeriodo.SelectedValue Is Nothing Then Exit Sub

            dtPeriodos = sqlExecute("SELECT fecha_ini,fecha_fin FROM periodos WHERE ano = '" & cmbPeriodo.SelectedValue.ToString.Substring(0, 4) & _
                                    "' AND periodo = '" & cmbPeriodo.SelectedValue.ToString.Substring(4, 2) & "'", "TA")
            FIni = dtPeriodos.Rows(0).Item("fecha_ini")
            FFin = dtPeriodos.Rows(0).Item("fecha_fin")
            dtFechas.Columns.Add("FECHA", GetType(System.DateTime))
            Do Until FIni > FFin
                dtFechas.Rows.Add({FIni})
                FIni = DateAdd(DateInterval.Day, 1, FIni)
            Loop
            cmbFecha.DataSource = dtFechas

            CargaInformacion = False
            cmbFecha.SelectedValue = Now.Date
            If cmbFecha.SelectedValue Is Nothing Then
                cmbFecha.SelectedIndex = 0
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbFecha_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFecha.SelectedValueChanged
        Dim Fecha As Date
        Dim i As Integer
        Try
            If cmbFecha.SelectedValue Is Nothing Then Exit Sub
            Fecha = cmbFecha.SelectedValue
            i = 0
            If Fecha < Now.Date Then
                Do Until Fecha = Now.Date
                    If Not DiaDescanso(Fecha) Then
                        i += 1
                    End If
                    Fecha = DateAdd(DateInterval.Day, 1, Fecha)
                Loop
            ElseIf Fecha > Now.Date Then
                Do Until Fecha = Now.Date
                    If Not DiaDescanso(Fecha) Then
                        i += 1
                    End If
                    Fecha = DateAdd(DateInterval.Day, -1, Fecha)
                Loop
            End If

            dgAutorizacion.ReadOnly = Not (i <= DiasAut)
            dgAutorizacion.AllowUserToDeleteRows = Not dgAutorizacion.ReadOnly
            If dgAutorizacion.ReadOnly Then
                dgAutorizacion.DefaultCellStyle.BackColor = SystemColors.InactiveCaption
            Else
                dgAutorizacion.DefaultCellStyle.BackColor = SystemColors.Window
            End If

            If Not CargaInformacion Then
                MostrarInformacion()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub frmAutorizacionTiempoExtra_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlCentrado.Left = (Me.Width - pnlCentrado.Width) / 2
        pnlEditar.Left = (Me.Width - pnlEditar.Width) / 2
        pnlEditar.Top = (dgAutorizacion.Height - pnlEditar.Height) / 2
    End Sub

    Private Sub dgAutorizacion_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgAutorizacion.CellMouseEnter
        Try
            If e.ColumnIndex < 0 Then Exit Sub

            If dgAutorizacion.Columns(e.ColumnIndex).Name = "colAutorizadas" And Not dgAutorizacion.Columns(e.ColumnIndex).ReadOnly Then
                DevComponents.DotNetBar.ToastNotification.ToastFont = New Font("Microsoft Sans Serif", 10)
                DevComponents.DotNetBar.ToastNotification.ToastBackColor = Color.LightGreen
                DevComponents.DotNetBar.ToastNotification.ToastForeColor = Color.Black

                DevComponents.DotNetBar.ToastNotification.Show(pnlEncabezado, "Para autorizar todo el tiempo extra trabajado," & vbCrLf & "indicar ""*"" o ""TODO""" _
                                                               , My.Resources.Information48, 10000, DevComponents.DotNetBar.eToastGlowColor.Green, _
                                                               DevComponents.DotNetBar.eToastPosition.BottomCenter)
            Else
                DevComponents.DotNetBar.ToastNotification.Close(pnlEncabezado)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    'Private Sub dgAutorizacion_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
    '    Dim rl As String
    '    Dim Activo As Boolean
    '    Try
    '        If dgAutorizacion.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then Exit Sub
    '        rl = IIf(IsDBNull(dgAutorizacion.Item(e.ColumnIndex, e.RowIndex).Value), "", dgAutorizacion.Item(e.ColumnIndex, e.RowIndex).Value)
    '        If rl = "" Then
    '            Nuevo = False
    '            Exit Sub
    '        End If

    '        If e.ColumnIndex = dgAutorizacion.Columns("RELOJ").Index Then

    '            '*** MCR *** UTILIZAR WERE EN LUGAR DE WHERE EN CUALQUIER FILTRO QUE NO APLIQUE A PERSONALVW, 
    '            'PARA QUE EL PROCEDIMIENTO CONSULTAPERSONALVW NO LO SUSTITUYA POR LOS FILTROS 
    '            dtTemporal = ConsultaPersonalVW("SELECT PERSONALVW.RELOJ,PERSONALVW.NOMBRES,PERSONALVW.ALTA,PERSONALVW.BAJA,ISNULL(infoAsist.COD_DEPTO,PERSONALVW.COD_DEPTO) AS COD_DEPTO,FECHA_ENTRO,HORAS_EXTRAS,ENTRO," & _
    '                                            "SALIO,tipo_ausentismo.nombre AS ausentismo FROM PERSONALVW " & _
    '                                            "LEFT JOIN (SELECT reloj,cod_depto,fecha_entro,horas_extras,entro,salio,tipo_aus FROM TA.dbo.asist " & _
    '                                            "WERE reloj = '" & rl & "' AND FHA_ENT_HOR = '" & FechaSQL(cmbFecha.SelectedValue) & "') AS infoAsist " & _
    '                                            "ON PERSONALVW.RELOJ = infoAsist.RELOJ " & _
    '                                            "LEFT JOIN ta.dbo.tipo_ausentismo ON infoAsist.tipo_aus = tipo_ausentismo.tipo_aus " & _
    '                                            "WHERE PersonalVW.RELOJ = '" & rl.Trim & "'", False)



    '            If dtTemporal.Rows.Count > 0 Then
    '                If IsDBNull(dtTemporal.Rows(0).Item("baja")) Then
    '                    Activo = dtTemporal.Rows(0).Item("alta") < cmbFecha.SelectedValue
    '                Else
    '                    Activo = dtTemporal.Rows(0).Item("baja") > cmbFecha.SelectedValue
    '                End If

    '                If Not Activo Then
    '                    MessageBox.Show("El empleado " & rl & " no se encuentra activo en la fecha seleccionada. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Nuevo = False
    '                    dgAutorizacion.CancelEdit()
    '                    Exit Sub
    '                End If

    '                dgAutorizacion.Item("nombre", e.RowIndex).Value = IIf(IsDBNull(dtTemporal.Rows(0).Item("nombres")), "NO LOCALIZADO", dtTemporal.Rows(0).Item("nombres"))
    '                dgAutorizacion.Item("colDepto", e.RowIndex).Value = IIf(IsDBNull(dtTemporal.Rows(0).Item("cod_depto")), "NOLOC", dtTemporal.Rows(0).Item("cod_depto"))
    '                dgAutorizacion.Item("colDeptoOriginal", e.RowIndex).Value = IIf(IsDBNull(dtTemporal.Rows(0).Item("cod_depto")), "NOLOC", dtTemporal.Rows(0).Item("cod_depto"))
    '                dgAutorizacion.Item("colFecha", e.RowIndex).Value = cmbFecha.SelectedValue
    '                dgAutorizacion.Item("colEntrada", e.RowIndex).Value = IIf(IsDBNull(dtTemporal.Rows(0).Item("entro")), "", dtTemporal.Rows(0).Item("entro"))
    '                dgAutorizacion.Item("colSalida", e.RowIndex).Value = IIf(IsDBNull(dtTemporal.Rows(0).Item("salio")), "", dtTemporal.Rows(0).Item("salio"))
    '                dgAutorizacion.Item("colExtrasReales", e.RowIndex).Value = IIf(IsDBNull(dtTemporal.Rows(0).Item("HORAS_EXTRAS")), "00:00", dtTemporal.Rows(0).Item("HORAS_EXTRAS"))
    '                dgAutorizacion.Item("colAusentismo", e.RowIndex).Value = IIf(IsDBNull(dtTemporal.Rows(0).Item("ausentismo")), "", dtTemporal.Rows(0).Item("ausentismo"))
    '                dgAutorizacion.Item("colDepto", e.RowIndex).Style.BackColor = IIf(dgAutorizacion.Item("colDepto", e.RowIndex).Value = "NOLOC", Color.Red, Color.White)
    '                'dgAutorizacion.Item("colAutorizadas", e.RowIndex).Value = txtDefault.Text
    '            Else
    '                MessageBox.Show("El empleado " & rl & " no está registrado, o el usuario no tiene acceso a su consulta.", "No localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Nuevo = False
    '                dgAutorizacion.CancelEdit()
    '            End If
    '        ElseIf e.ColumnIndex = dgAutorizacion.Columns("colAutorizadas").Index Then
    '            dgAutorizacion.Item("colAutorizadas", e.RowIndex).Value = CtoHSimple(dgAutorizacion.Item("colAutorizadas", e.RowIndex).Value)
    '        ElseIf e.ColumnIndex = dgAutorizacion.Columns("colDepto").Index Then
    '            dtTemporal = sqlExecute("SELECT cod_depto FROM personal WHERE cod_depto = '" & dgAutorizacion.Item("colDepto", e.RowIndex).Value.ToString.Trim & "'")
    '            If dtTemporal.Rows.Count = 0 Then
    '                dgAutorizacion.Item("colDepto", e.RowIndex).Value = "NOLOC"
    '            End If
    '            dgAutorizacion.Item("colDepto", e.RowIndex).Style.BackColor = IIf(dgAutorizacion.Item("colDepto", e.RowIndex).Value = "NOLOC", Color.Red, Color.White)
    '        End If
    '    Catch ex As Exception
    '        Stop
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
    '    End Try
    'End Sub

    Private Sub dgAutorizacion_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgAutorizacion.UserAddedRow
        Try
            Nuevo = Not CargaInformacion
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnGlobal_Click(sender As Object, e As EventArgs) Handles btnGlobal.Click
        Dim dtGlobal As New DataTable
        Dim R As String
        Dim F As String = FechaSQL(cmbFecha.SelectedValue)
        Try
            '*** MCR *** UTILIZAR WERE EN LUGAR DE WHERE EN CUALQUIER FILTRO QUE NO APLIQUE A PERSONALVW, 
            'PARA QUE EL PROCEDIMIENTO CONSULTAPERSONALVW NO LO SUSTITUYA POR LOS FILTROS 
            dtGlobal = ConsultaPersonalVW("SELECT PERSONALVW.RELOJ,PERSONALVW.NOMBRES,PERSONALVW.ALTA,PERSONALVW.BAJA,PERSONALVW.COD_SUPER," & _
                                          "ISNULL(infoAsist.COD_DEPTO,PERSONALVW.COD_DEPTO) AS COD_DEPTO,FECHA_ENTRO,HORAS_EXTRAS,ENTRO," & _
                                          "SALIO,tipo_ausentismo.nombre AS ausentismo FROM PERSONALVW " & _
                                          "LEFT JOIN (SELECT reloj,cod_depto,fecha_entro,horas_extras,entro,salio,tipo_aus FROM TA.dbo.asist " & _
                                          "WERE FHA_ENT_HOR = '" & F & "') AS infoAsist " & _
                                          "ON PERSONALVW.RELOJ = infoAsist.RELOJ " & _
                                          "LEFT JOIN ta.dbo.tipo_ausentismo ON infoAsist.tipo_aus = tipo_ausentismo.tipo_aus " & _
                                          "WHERE (PERSONALVW.BAJA IS NULL OR PERSONALVW.BAJA > '" & F & "') AND personalvw.alta<='" & F & "'", False)
            pnlEditar.Visible = True
            prgEditar.Value = 0
            prgEditar.Maximum = dtGlobal.Rows.Count
            prgEditar.ProgressTextVisible = True
            EmpNav.Enabled = False
            dgAutorizacion.Enabled = False

            For Each dEmp As DataRow In dtGlobal.Rows
                R = dEmp("reloj").ToString.Trim
                lblAvance.Text = R
                prgEditar.Value += 1
                prgEditar.ProgressText = Math.Round((prgEditar.Value / prgEditar.Maximum) * 100, 0) & "%"
                My.Application.DoEvents()

                dtTemporal = sqlExecute("SELECT reloj FROM extras_autorizadas WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                If dtTemporal.Rows.Count = 0 Then
                    sqlExecute("INSERT INTO extras_autorizadas (reloj,fecha) VALUES ('" & R & "','" & F & "')", "ta")

                    sqlExecute("UPDATE extras_autorizadas SET entrada = '" & IIf(IsDBNull(dEmp("entro")), "", dEmp("entro")) & "', " & _
                               "extras_reales = '" & IIf(IsDBNull(dEmp("horas_extras")), "", dEmp("horas_extras")) & "', " & _
                               " cod_super = '" & dEmp("COD_SUPER") & "', " & _
                               "cod_depto = '" & dEmp("COD_DEPTO") & "', " & _
                               " periodo = '" & cmbPeriodo.SelectedValue.ToString.Substring(4, 2) & "', " & _
                               "ano = '" & cmbPeriodo.SelectedValue.ToString.Substring(0, 4) & "', " & _
                               "usuario_s = '" & Usuario & "', " & _
                               "fecha_s = '" & FechaSQL(Now.Date) & "', " & _
                               "envio_s = 1, " & _
                               "usuario_a1 = '" & Usuario & "', " & _
                               "fecha_a1 = '" & FechaSQL(Now.Date) & "', " & _
                               "autori_a1 = 1, " & _
                               "envio_a1 = 1, " & _
                               "usuario_a2 = '" & Usuario & "', " & _
                               "fecha_a2 = '" & FechaSQL(Now.Date) & "', " & _
                               "autori_a2 = 1, " & _
                               "envio_a2 = 1,aplicado = 0,analizado = 0  WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")


                End If
            Next
            MostrarInformacion()
        Catch ex As Exception
            Stop
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            pnlEditar.Visible = False
            lblAvance.Text = "Cargando información"
            prgEditar.ProgressTextVisible = False
            EmpNav.Enabled = True
            dgAutorizacion.Enabled = True
        End Try
    End Sub

    'Private Sub txtDefault_GotFocus(sender As Object, e As EventArgs)
    '    txtDefault.SelectionLength = txtDefault.TextLength
    'End Sub

    'Private Sub txtDefault_Validated(sender As Object, e As EventArgs)
    '    txtDefault.Text = CtoHSimple(txtDefault.Text)
    'End Sub

    Private Sub dgAutorizacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAutorizacion.CellContentClick

    End Sub

    Private Sub dgAutorizacion_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgAutorizacion.UserDeletingRow
        Dim R As String
        Dim F As String
        Dim Autorizado As Boolean = False
        Dim Aplicado As Boolean = False
        Dim Borrar As Boolean = True
        Try

            R = dgAutorizacion.Item("reloj", e.Row.Index).Value.ToString.Trim
            F = FechaSQL(dgAutorizacion.Item("colFecha", e.Row.Index).Value.ToString.Trim)
            dtTemporal = sqlExecute("SELECT aplicado, analizado,usuario_a1 FROM extras_autorizadas WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
            If dtTemporal.Rows.Count > 0 Then
                Autorizado = IIf(IsDBNull(dtTemporal.Rows(0).Item("usuario_a1")), "", dtTemporal.Rows(0).Item("usuario_a1")) <> ""
                Aplicado = IIf(IsDBNull(dtTemporal.Rows(0).Item("aplicado")), False, dtTemporal.Rows(0).Item("aplicado"))
            End If

            If Autorizado Then
                Borrar = MessageBox.Show("¿El tiempo extra al empleado " & R & " para el día " & F & " ya fue autorizado por " & dtTemporal.Rows(0).Item("usuario_a1").ToString.Trim & _
                                         ", está seguro de eliminarlo?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes
            ElseIf Aplicado Then
                Borrar = MessageBox.Show("¿El tiempo extra al empleado " & R & " para el día " & F & " ya fue aplicado a sus registros de asistencia, " & _
                                         "está seguro de eliminarlo?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes

            Else
                Borrar = MessageBox.Show("¿Está seguro de eliminar la autorización " & vbCrLf & " de tiempo extra  al empleado " & dgAutorizacion.Item("reloj", e.Row.Index).Value _
                                          & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes
            End If

            If Borrar Then
                sqlExecute("DELETE FROM extras_autorizadas WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                'MostrarInformacion()
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            Stop
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbFecha_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFecha.SelectedIndexChanged

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim R As String
        Dim F As String
        Dim Autorizado As Boolean = False
        Dim Aplicado As Boolean = False
        Dim Borrar As Boolean = True
        Dim I As Integer
        Try
            I = dgAutorizacion.CurrentCell.RowIndex
            R = dgAutorizacion.Item("reloj", I).Value.ToString.Trim
            F = FechaSQL(dgAutorizacion.Item("colFecha", I).Value.ToString.Trim)
            dtTemporal = sqlExecute("SELECT aplicado, analizado,usuario_a1 FROM extras_autorizadas WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
            If dtTemporal.Rows.Count > 0 Then
                Autorizado = IIf(IsDBNull(dtTemporal.Rows(0).Item("usuario_a1")), "", dtTemporal.Rows(0).Item("usuario_a1")) <> ""
                Aplicado = IIf(IsDBNull(dtTemporal.Rows(0).Item("aplicado")), False, dtTemporal.Rows(0).Item("aplicado"))

            End If

            If Autorizado Then
                Borrar = MessageBox.Show("¿El tiempo extra al empleado " & R & " para el día " & F & " ya fue autorizado por " & dtTemporal.Rows(0).Item("usuario_a1").ToString.Trim & _
                                         ", está seguro de eliminarlo?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes
            ElseIf Aplicado Then
                Borrar = MessageBox.Show("¿El tiempo extra al empleado " & R & " para el día " & F & " ya fue aplicado a sus registros de asistencia, " & _
                                         "está seguro de eliminarlo?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes

            Else
                Borrar = MessageBox.Show("¿Está seguro de eliminar la autorización " & vbCrLf & " de tiempo extra  al empleado " & dgAutorizacion.Item("reloj", I).Value _
                                          & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes
            End If

            If Borrar Then
                sqlExecute("DELETE FROM extras_autorizadas WHERE reloj = '" & R & "' AND fecha = '" & F & "'", "TA")
                dgAutorizacion.Rows.RemoveAt(I)
                'MostrarInformacion()
            Else
            End If
        Catch ex As Exception
            Stop
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgAutorizacion_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgAutorizacion.CellEndEdit
        Try
            If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Exit Sub
            Dim Col As String = dgAutorizacion.Columns(e.ColumnIndex).DataPropertyName
            Dim Reloj As String = dgAutorizacion.Rows(e.RowIndex).Cells("colReloj").Value
            Dim Fecha As Date = Date.Parse(dgAutorizacion.Rows(e.RowIndex).Cells("colFecha").Value)

            Dim Valor As String = dgAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim

            If Col = "extras_autorizadas" Then
                If Valor = "*" Or Valor.ToUpper = "TODO" Then
                    Valor = "TODO"
                Else
                    Valor = CtoHSimple(Valor).Replace("**:**", "00:00")
                End If

                dgAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Valor
            End If

            sqlExecute("update extras_autorizadas set " & Col & " = '" & Valor & "' where reloj = '" & Reloj & "' and fecha = '" & FechaSQL(Fecha) & "'", "ta")

            If Col = "extras_autorizadas" Then
                If Valor = "TODO" Then
                    sqlExecute("update asist set extras_autorizadas = horas_extras where reloj = '" & Reloj & "' and fecha_entro = '" & FechaSQL(Fecha) & "'", "ta")
                Else
                    sqlExecute("update asist set extras_autorizadas = '" & Valor & "' where reloj = '" & Reloj & "' and fecha_entro = '" & FechaSQL(Fecha) & "'", "ta")
                End If
            End If

            Dim dtEmp As DataTable = sqlExecute("select * from personalvw where reloj = '" & Reloj & "'")
            If dtEmp.Rows.Count > 0 Then
                LlenaNomSem(dtEmp.Rows(0), cmbPeriodo.SelectedValue.ToString, New DataTable)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Function NtoH(v As String) As String
        Try
            Dim valor As Double = Double.Parse("0" & v)
            Dim valorh As Integer = Math.Floor(valor)
            Dim valorm As Integer = (valor - Math.Floor(valor)) * 100
            Dim h As String = IIf(valorh <= 23 And valorh >= 0, valorh.ToString.PadLeft(2, "0"), "00")
            Dim m As String = IIf(valorm <= 59 And valorm >= 0, valorm.ToString.PadLeft(2, "0"), "00")
            Return h & ":" & m
        Catch ex As Exception
            Return "00:00"
        End Try
    End Function

    Private Sub dgAutorizacion_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgAutorizacion.CellMouseLeave
        DevComponents.DotNetBar.ToastNotification.Close(pnlEncabezado)
    End Sub
End Class