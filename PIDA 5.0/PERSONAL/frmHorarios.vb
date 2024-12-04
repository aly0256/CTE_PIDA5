Public Class frmHorarios
    Dim dtCias As New DataTable
    Dim dtTurnos As New DataTable
    Dim dtDias As New DataTable
    Dim dtDias2 As New DataTable
    Dim dtHorarios As New DataTable
    Dim dtTemp As New DataTable
    Dim dtLista As New DataTable

    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim DesdeGrid As Boolean
    Dim CodHora As String, CodComp As String

    Dim NumSemana As Integer = 1

    Private Sub frmHorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Agregar = False
        Editar = False

        dtLista = sqlExecute("SELECT cod_comp as 'Compañía',cod_hora as 'Código',Nombre FROM horarios")
        dtLista.DefaultView.Sort = "Código"

        dgTabla.DataSource = dtLista
        dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        dtCias = sqlExecute("SELECT cod_comp,nombre FROM cias")
        cmbCia.DataSource = dtCias

        DesdeGrid = False
        dtHorarios = sqlExecute("SELECT TOP 1 * FROM horarios ORDER BY cod_hora ASC")
        dtInicioMixto.Value = Now.Date

        sdgDias.PrimaryGrid.AllowRowInsert = True
        sdgDias.PrimaryGrid.AllowRowDelete = True

        sdgDias.PrimaryGrid.EnableFiltering = True
        sdgDias.PrimaryGrid.UseAlternateRowStyle = True
        sdgDias.PrimaryGrid.EnableColumnFiltering = True
        ' sdgDias.PrimaryGrid.Columns(0).FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        'sdgDias.PrimaryGrid.AddGroup(sdgDias.PrimaryGrid.Columns("SEMANA"))
        'sdgDias.PrimaryGrid.RemoveGroup(sdgDias.PrimaryGrid.Columns("SEMANA"))
        'copy + Paste
        'sdgDias.PrimaryGrid.CopySelectedCellsToClipboard()

        'Dim X As Object
        'X = Clipboard.GetText
        'Dim I() As String
        'I = X.ToString.Split(vbCrLf)

        'CodComp = "CTE"
        'dtTurnos = sqlExecute("SELECT cod_turno,nombre,RTRIM(CAST(horas as CHAR)) + ' hrs.' as horas FROM turnos WHERE cod_comp = '" & CodComp & "'")
        'cmbTurno.DataSource = dtTurnos

        MostrarInformacion()
        HabilitarBotones()

        'sdgDias.PrimaryGrid.Columns(0).FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards

    End Sub

    Private Sub MostrarInformacion()
        Dim i As Integer
        Dim Mixto As Boolean
        Try
            If dtHorarios.Rows.Count = 0 Then Exit Sub
            CodComp = dtHorarios.Rows.Item(0).Item("cod_comp")
            CodHora = dtHorarios.Rows.Item(0).Item("cod_hora")

            dtTurnos = sqlExecute("SELECT cod_turno,nombre,RTRIM(CAST(horas as CHAR)) + ' hrs.' as horas FROM turnos WHERE cod_comp = '" & CodComp & "'")
            cmbTurno.DataSource = dtTurnos

            GridHorarios(CodHora, CodComp)

            txtCodigo.Text = CodHora
            txtNombre.Text = dtHorarios.Rows.Item(0).Item("nombre").ToString.Trim
            txtDescripcion.Text = dtHorarios.Rows.Item(0).Item("descripcion_larga").ToString.Trim

            cmbCia.SelectedValue = CodComp
            cmbTurno.SelectedValue = dtHorarios.Rows.Item(0).Item("cod_turno")
            btnReferencia.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("referencia")), 0, dtHorarios.Rows.Item(0).Item("referencia"))
            btnSal_sig_di.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("Sal_sig_dia")), 0, dtHorarios.Rows.Item(0).Item("Sal_sig_dia"))
            btnPri_ent_ult_sal.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("Pri_ent_ult_sal")), 0, dtHorarios.Rows.Item(0).Item("Pri_ent_ult_sal"))
            btnCuenta_ex.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("Cuenta_ex")), 0, dtHorarios.Rows.Item(0).Item("Cuenta_ex"))
            btnCuenta_ex_antes.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("Cuenta_ex_antes")), 0, dtHorarios.Rows.Item(0).Item("Cuenta_ex_antes"))

            txtAviso_extra.Text = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("Aviso_extra")), "", dtHorarios.Rows.Item(0).Item("Aviso_extra"))
            btnCom_prop.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("Com_prop")), 0, dtHorarios.Rows.Item(0).Item("Com_prop"))
            txtComida.Text = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("Comida")), "", dtHorarios.Rows.Item(0).Item("Comida"))
            txtMinimo.Text = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("minimo_cafeteria")), "", dtHorarios.Rows.Item(0).Item("minimo_cafeteria"))

            Mixto = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("mixto")), False, dtHorarios.Rows.Item(0).Item("mixto"))
            'MCR 2017-10-05
            'Agregar fecha de inicio y secuencia en rol de horarios mixtos
            dtInicioMixto.ValueObject = dtHorarios.Rows.Item(0).Item("partir_mixto_fecha")
            txtSecuencia.Text = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("secuencia")), "", dtHorarios.Rows.Item(0).Item("secuencia"))
            '*****************

            btnMixto.Value = Mixto
            pnlFactor1.Visible = Mixto
            'tabSemana1.Text = IIf(Mixto, "Detalle semana 1", "Detalle")
            pnlMixto.Visible = btnMixto.Value

            cmbInicio.SelectedIndex = IIf(IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("inicio_mixto")), "1", dtHorarios.Rows.Item(0).Item("inicio_mixto")) = 1, 0, 1)
            cmbAPartir.SelectedIndex = IIf(IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("partir_mixto")), "P", dtHorarios.Rows.Item(0).Item("partir_mixto")) = "P", 0, 1)
            dblFactor1.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("factor_semana1")), 1, dtHorarios.Rows.Item(0).Item("factor_semana1"))

            If Not DesdeGrid Then
                i = dtLista.DefaultView.Find(txtCodigo.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If
            DesdeGrid = False
            'HabilitarBotones()
            ' sdgDias.PrimaryGrid.Columns(0).FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards


        Catch ex As Exception

            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("horarios", "(cod_hora + cod_comp)", CodHora & cmbCia.SelectedValue, dtHorarios)
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("horarios", "cod_hora", dtHorarios)
        MostrarInformacion()
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("horarios", "cod_hora", dtHorarios)
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("horarios", "(cod_hora + cod_comp)", CodHora & cmbCia.SelectedValue, dtHorarios)
        MostrarInformacion()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("horarios", "cod_hora", "Horarios", False)
        If Cod <> "CANCELAR" Then
            dtHorarios = sqlExecute("SELECT * from horarios WHERE cod_hora = '" & Cod & "' AND cod_comp = '" & Compania & "'")
            MostrarInformacion()
        End If

    End Sub

    Private Sub HabilitarBotones()
        Dim NoRec As Boolean
        NoRec = dgTabla.Rows.Count = 0
        btnPrimero.Enabled = Not (Agregar Or Editar Or NoRec)
        btnAnterior.Enabled = Not (Agregar Or Editar Or NoRec)
        btnSiguiente.Enabled = Not (Agregar Or Editar Or NoRec)
        btnUltimo.Enabled = Not (Agregar Or Editar Or NoRec)
        btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)

        btnBuscar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBorrar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnCerrar.Enabled = Not (Agregar Or Editar)
        'pnlDatos.Enabled = Agregar Or Editar

        btnEditar.Enabled = Not (Not (Editar Or Agregar) And NoRec)

        chkTodasLasCias.Visible = (Agregar Or Editar Or NoRec)

        If Agregar Or Editar Then
            ' Si está activa la edición o nuevo registro
            btnNuevo.Image = PIDA.My.Resources.Ok16
            btnEditar.Image = PIDA.My.Resources.CancelX
            btnNuevo.Text = "Aceptar"
            btnEditar.Text = "Cancelar"
            tabBuscar.SelectedTabIndex = 0
        Else

            btnNuevo.Image = PIDA.My.Resources.NewRecord
            btnEditar.Image = PIDA.My.Resources.Edit

            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"
        End If

        txtCodigo.Enabled = Agregar
        cmbCia.Enabled = Agregar
        txtNombre.ReadOnly = Not (Agregar Or Editar)
        txtDescripcion.ReadOnly = Not (Agregar Or Editar)
        btnMixto.IsReadOnly = Not (Agregar Or Editar)
        cmbTurno.Enabled = (Agregar Or Editar)
        btnReferencia.IsReadOnly = Not (Agregar Or Editar)
        btnAbierto.IsReadOnly = Not (Agregar Or Editar)
        btnSal_sig_di.IsReadOnly = Not (Agregar Or Editar)
        btnPri_ent_ult_sal.IsReadOnly = Not (Agregar Or Editar)
        btnCuenta_ex.IsReadOnly = Not (Agregar Or Editar)
        btnCuenta_ex_antes.IsReadOnly = Not (Agregar Or Editar)
        txtAviso_extra.ReadOnly = Not (Agregar Or Editar)
        txtComida.ReadOnly = Not (Agregar Or Editar)
        txtMinimo.ReadOnly = Not (Agregar Or Editar)
        btnCom_prop.IsReadOnly = Not (Agregar Or Editar)
        pnlFactor1.Enabled = (Agregar Or Editar)
        sdgDias.PrimaryGrid.ReadOnly = Not (Agregar Or Editar)
        cmbAPartir.Enabled = Agregar Or Editar
        cmbInicio.Enabled = Agregar Or Editar
        lblComentarioInsert.Visible = Agregar Or Editar

        If Agregar Then
            txtCodigo.Text = ""
            txtNombre.Text = ""
            txtDescripcion.Text = ""
            ' GridHorarios("", "")
            txtCodigo.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If
    End Sub

    Private Sub dgTabla_DoubleClick(sender As Object, e As EventArgs) Handles dgTabla.DoubleClick
        Try
            tabBuscar.SelectedTabIndex = 0
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try

    End Sub

    Private Sub dgTabla_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        Try
            Dim cod As String, nom As String

            DesdeGrid = True

            cod = dgTabla.Item("Código", e.RowIndex).Value
            nom = dgTabla.Item("Compañía", e.RowIndex).Value
            dtHorarios = sqlExecute("SELECT * from horarios WHERE cod_hora = '" & cod & "' AND cod_comp = '" & nom & "'")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtComida_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtComida.Validating
        txtComida.Text = CtoHSimple(txtComida.Text)
    End Sub

    Private Sub txtAviso_extra_Validated(sender As Object, e As EventArgs) Handles txtAviso_extra.Validated

    End Sub

    Private Sub txtAviso_extra_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAviso_extra.Validating
        txtAviso_extra.Text = CtoHSimple(txtAviso_extra.Text)
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim Cadena As String

        Dim Comp As String
        Dim Hora As String
        Try
            '***** NOTA MCR 2017-10-05
            ' FALTA DEFINIR FACTOR PROPORCIONAL PARA SEMANAS MIXTAS

            Hora = txtCodigo.Text
            Comp = cmbCia.SelectedValue

            If Agregar Then
                ' Si Agregar, revisar si existe cod_comp+cod_depto

                dtCias = sqlExecute("select * from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))

                For Each row As DataRow In dtCias.Rows
                    dtTemporal = sqlExecute("SELECT cod_hora FROM horarios where cod_comp = '" & row("cod_comp") & "' AND cod_hora = '" & txtCodigo.Text & "'")
                    If dtTemporal.Rows.Count > 0 Then
                        MessageBox.Show("El registro no se puede agregar, ya existe '" & txtCodigo.Text & "' asignado a la compañía '" & row("cod_comp") & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtCodigo.Focus()
                        Exit Sub
                    End If
                Next


                For Each row As DataRow In dtCias.Rows
                    Cadena = "INSERT INTO horarios (cod_comp,cod_hora,nombre,descripcion_larga,cod_turno,mixto,referencia,aviso_extra,cuenta_ex," & _
                        "cuenta_ex_antes,comida,com_prop,minimo_cafeteria,sal_sig_dia,abierto,pri_ent_ult_sal,inicio_mixto,partir_mixto,factor_semana1," & _
                        "factor_semana2,factor_semanal,partir_mixto_fecha,secuencia) VALUES ('"
                    Cadena = Cadena & row("cod_comp") & "','" & _
                        txtCodigo.Text & "','" & _
                        txtNombre.Text.Trim & "','" & _
                        txtDescripcion.Text.Trim & _
                        "','" & cmbTurno.SelectedValue & "'," & _
                        IIf(btnMixto.Value, 1, 0) & "," & _
                        IIf(btnReferencia.Value, 1, 0) & _
                        ",'" & txtAviso_extra.Text & "'," & _
                        IIf(btnCuenta_ex.Value, 1, 0) & "," & _
                        IIf(btnCuenta_ex_antes.Value, 1, 0) & ",'" & _
                        txtComida.Text & "'," & _
                        IIf(btnCom_prop.Value, 1, 0) & ",'" & _
                        txtMinimo.Text & "'," & _
                        IIf(btnSal_sig_di.Value, 1, 0) & "," & _
                        IIf(btnAbierto.Value, 1, 0) & "," & _
                        IIf(btnPri_ent_ult_sal.Value, 1, 0) & ",'" & _
                        cmbInicio.Text.Substring(7) & "','" & _
                        IIf(cmbAPartir.Text.Contains("alta"), "A", "P") & "'," & _
                        dblFactor1.Value & "," & _
                        0 & "," & _
                        dblFactor1.Value & ",'" & _
                        FechaSQL(dtInicioMixto.Value) & "','" & _
                        txtSecuencia.Text & "')"
                    sqlExecute(Cadena)

                    GuardarDias()
                Next

                dtHorarios = sqlExecute("SELECT * FROM horarios WHERE cod_comp = '" & Comp & "' AND cod_hora = '" & Hora & "'")
                MostrarInformacion()
                Agregar = False
            ElseIf Editar Then
                dtCias = sqlExecute("select * from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))

                For Each row As DataRow In dtCias.Rows
                    ' Si Editar, entonces guardar cambios a registro
                    Cadena = "UPDATE horarios SET nombre = '" & txtNombre.Text.Trim & _
                        "', descripcion_larga = '" & txtDescripcion.Text.Trim & _
                        "', cod_turno = '" & cmbTurno.SelectedValue & _
                        "', mixto = " & IIf(btnMixto.Value, 1, 0) & _
                        ", referencia = " & IIf(btnReferencia.Value, 1, 0) & _
                        ", aviso_extra = '" & txtAviso_extra.Text & _
                        "', cuenta_ex = " & IIf(btnCuenta_ex.Value, 1, 0) & _
                        ", cuenta_ex_antes = " & IIf(btnCuenta_ex_antes.Value, 1, 0) & _
                        ", comida = '" & txtComida.Text & "', com_prop = " & _
                        IIf(btnCom_prop.Value, 1, 0) & " ,minimo_cafeteria = '" & _
                        txtMinimo.Text & "', sal_sig_dia = " & _
                        IIf(btnSal_sig_di.Value, 1, 0) & _
                        ", abierto = " & IIf(btnAbierto.Value, 1, 0) & _
                        ",  pri_ent_ult_sal = " & IIf(btnPri_ent_ult_sal.Value, 1, 0) & _
                        ", inicio_mixto = '" & cmbInicio.Text.Substring(7) & "'" & _
                        ", partir_mixto = '" & IIf(cmbAPartir.Text.Contains("alta"), "A", "P") & "'" & _
                        ", factor_semana1 = " & dblFactor1.Value & _
                        ", factor_semana2 = " & 0 & _
                        ", factor_semanal = " & dblFactor1.Value & _
                        ", partir_mixto_fecha = '" & FechaSQL(dtInicioMixto.Value) & _
                        "',secuencia = '" & txtSecuencia.Text & _
                        "' WHERE cod_hora = '" & txtCodigo.Text & "' AND cod_comp = '" & row("cod_comp") & "'"

                    sqlExecute(Cadena)

                    GuardarDias()
                Next


                dtHorarios = sqlExecute("SELECT * FROM horarios WHERE cod_comp = '" & Comp & "' AND cod_hora = '" & Hora & "'")
                MostrarInformacion()
            Else
                Agregar = True
            End If
            Editar = False

            HabilitarBotones()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub GuardarDias()

        Dim Cadena As String
        Dim R As Integer
        Dim C As Integer
        Dim Comp As String
        Dim Hora As String

        Hora = txtCodigo.Text
        Comp = cmbCia.SelectedValue

        dtCias = sqlExecute("select * from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))

        For Each row As DataRow In dtCias.Rows
            sqlExecute("DELETE FROM dias WHERE cod_comp = '" & row("cod_comp") & "' AND cod_hora = '" & txtCodigo.Text & "'")

            sdgDias.PrimaryGrid.PurgeDeletedRows()

            For Each dR As DevComponents.DotNetBar.SuperGrid.GridRow In sdgDias.PrimaryGrid.Rows
                '                dR.Cells(0).Value
                'If Not R > 10 Then

                If Not IsDBNull(dR.Cells(1).Value) And _
                    Not dR.Cells(1).Value Is Nothing Then 'Si el día de entrada es nulo, se considera línea en blanco
                    Cadena = "INSERT INTO dias (cod_comp,cod_hora,semana,cod_dia,dia_ent,min_ant_ent,entra,min_des_ent,cod_dia_sal,dia_sal,min_ant_sal,sale,min_des_sal,descanso," & _
                        "hrs_dia,rango_hrs) VALUES ('"
                    Cadena = Cadena & row("cod_comp") & "','" & Hora
                    For C = 0 To sdgDias.PrimaryGrid.Columns.Count - 1
                        If C = 11 Then
                            If IsDBNull(dR.Cells(C).Value) Then
                                Cadena = Cadena & "',0"
                            Else
                                Cadena = Cadena & "'," & IIf(dR.Cells(C).Value, 1, 0)
                            End If

                        ElseIf C = 12 Then
                            Cadena = Cadena & ",'" & dR.Cells(C).Value
                        Else
                            Cadena = Cadena & "','" & dR.Cells(C).Value
                        End If
                    Next
                    Cadena = Cadena & "')"
                    sqlExecute(Cadena)
                End If
                'If R >= 7 Then Exit Sub
                'End If
            Next
        Next
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Editar = (Not Editar And Not Agregar)
        Agregar = False
        HabilitarBotones()
        MostrarInformacion()
        If Editar Then txtNombre.Focus()
    End Sub

    Private Sub GridHorarios(CodHora As String, CodComp As String)
        Try

            dtDias = sqlExecute("SELECT semana as 'SEMANA',cod_dia as '# DÍA DE ENTRADA', dia_ent as 'DÍA DE ENTRADA', min_ant_ent  AS 'MINUTOS ANTES DE LA ENTRADA'," & _
                                "entra AS 'ENTRADA',min_des_ent AS 'MINUTOS DESPUÉS DE LA ENTRADA',cod_dia_sal AS '# DÍA DE SALIDA'," & _
                                "dia_sal AS 'DÍA DE SALIDA',min_ant_sal AS 'MINUTOS ANTES DE LA SALIDA',sale AS 'SALIDA'," & _
                                "min_des_sal AS 'MINUTOS DESPUÉS DE LA SALIDA',descanso AS 'DESCANSO',hrs_dia AS 'HORAS POR DÍA'," & _
                                "rango_hrs AS 'HORAS DESPUÉS DE MEDIA NOCHE' FROM dias WHERE cod_hora = '" & CodHora & "' AND cod_comp = '" & CodComp & _
                                "' ORDER BY cod_dia,ENTRA")
            'dgHorariosSemana1.DataSource = dtDias
            'dgHorariosSemana1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            'dgHorariosSemana1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'dgHorariosSemana1.Columns(1).ReadOnly = True
            'dgHorariosSemana1.Columns(6).ReadOnly = True
            'dgHorariosSemana1.Columns(12).ToolTipText = "TIEMPO A CONSIDERAR DESPUÉS DE MEDIA NOCHE"

            sdgDias.PrimaryGrid.DataSource = dtDias
            sdgDias.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill
            sdgDias.PrimaryGrid.Columns(2).ReadOnly = True
            sdgDias.PrimaryGrid.Columns(7).ReadOnly = True
            sdgDias.PrimaryGrid.Columns(13).ToolTip = "TIEMPO A CONSIDERAR DESPUES DE MEDIA NOCHE"


        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim codigo As String, comp As String
        codigo = txtCodigo.Text
        comp = cmbCia.SelectedValue
        dtTemporal = sqlExecute("SELECT reloj from personalvw WHERE cod_hora = '" & codigo & "' AND cod_comp = '" & comp & "'")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM horarios WHERE cod_hora = '" & codigo & "' AND cod_comp = '" & comp & "'")
                sqlExecute("DELETE FROM dias WHERE cod_hora = '" & codigo & "' AND cod_comp = '" & comp & "'")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub dgHorarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtCompanias As New DataTable

        dtCompanias = sqlExecute("SELECT cod_comp FROM cias")
        frmVistaPrevia.LlamarReporte("Horarios", sqlExecute("SELECT " & _
                                                            "horarios.*, " & _
                                                            "dias.SEMANA, " & _
                                                            "dias.COD_DIA, " & _
                                                            "dias.DIA_ENT, " & _
                                                            "dias.MIN_ANT_ENT, " & _
                                                            "dias.ENTRA, " & _
                                                            "dias.MIN_DES_ENT, " & _
                                                            "dias.COD_DIA_SAL, " & _
                                                            "dias.DIA_SAL, " & _
                                                            "dias.MIN_ANT_SAL, " & _
                                                            "dias.SALE, " & _
                                                            "dias.MIN_DES_SAL, " & _
                                                            "dias.DESCANSO, " & _
                                                            "dias.HRS_DIA, " & _
                                                            "dias.RANGO_HRS " & _
                                                            "FROM personal.dbo.horarios  " & _
                                                            "INNER JOIN personal.dbo.dias ON horarios.COD_HORA =dias.COD_HORA AND horarios.COD_COMP = dias.COD_COMP"), cmbCia.SelectedValue)
        frmVistaPrevia.ShowDialog()

    End Sub

    Private Sub txtAviso_extra_TextChanged(sender As Object, e As EventArgs) Handles txtAviso_extra.TextChanged

    End Sub

    Private Sub txtMinimo_TextChanged(sender As Object, e As EventArgs) Handles txtMinimo.TextChanged

    End Sub

    Private Sub txtMinimo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMinimo.Validating
        txtMinimo.Text = CtoHSimple(txtMinimo.Text)
    End Sub

    Private Sub dgTabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellContentClick

    End Sub

    Private Sub dgTabla_RowDividerHeightChanged(sender As Object, e As DataGridViewRowEventArgs) Handles dgTabla.RowDividerHeightChanged

    End Sub

    Private Sub frmHorarios_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlControles.Left = (Me.Width - pnlControles.Width) / 2
    End Sub


    Private Sub btnMixto_ValueChanged(sender As Object, e As EventArgs) Handles btnMixto.ValueChanged
        If Editar Or Agregar Then
            pnlFactor1.Visible = btnMixto.Value
            pnlMixto.Visible = btnMixto.Value
            'tabSemana1.Text = IIf(btnMixto.Value, "Detalle semana 1", "Detalle")

        End If
    End Sub

    Private Sub btnGenerarRol_Click(sender As Object, e As EventArgs) Handles btnGenerarRol.Click
        'MCR 2017-09-29
        'Generar programación anual de roles para un horario
        Dim cod_hora As String
        Dim cod_comp As String
        Dim dtHorarios As New DataTable
        Dim mixto As Boolean
        Dim partir_mixto_fecha As Date
        Dim sec As String

        Dim drHorario As DataRow
        Try

            cod_hora = txtCodigo.Text.Trim
            cod_comp = cmbCia.SelectedValue.trim

            'Para programar solo el horario actual
            dtHorarios = sqlExecute("SELECT cod_comp,cod_hora,mixto,partir_mixto_fecha,secuencia FROM horarios WHERE cod_comp = '" & cod_comp & "' AND cod_hora = '" & cod_hora & "'")
            '*******************

            'Para programar todos los horarios
            'dtHorarios = sqlExecute("SELECT cod_hora,cod_comp,mixto,partir_mixto_fecha,secuencia FROM horarios")

            'Para programar solo los horarios del Excel BRP Querétaro
            'dtHorarios = sqlExecute("SELECT cod_hora,cod_comp,mixto,partir_mixto_fecha,secuencia FROM horarios WHERE " & _
            '                        "COD_HORA in('104','111','112','118','119','120','103','110','114','115','116','102','108','105','121','122','123','124','125','126','127','128','129','130','131','132','133','134','135','136','137','138','139','140','141','142','143','144','145','150','151','152','153','154','155','156','001','100')")
            If dtHorarios.Rows.Count = 0 Then
                MessageBox.Show("El horario " + cod_hora + " no fue localizado. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Err.Raise(0, Nothing, "Horario " + cod_hora + " no localizado.")
            End If

            For Each drHorario In dtHorarios.Rows
                cod_comp = drHorario("cod_comp")
                cod_hora = drHorario("cod_hora")

                mixto = IIf(IsDBNull(drHorario("mixto")), False, drHorario("mixto"))
                partir_mixto_fecha = IIf(IsDBNull(drHorario("partir_mixto_fecha")), Now.Date, drHorario("partir_mixto_fecha"))
                sec = IIf(IsDBNull(drHorario("secuencia")), "1", drHorario("secuencia")).ToString.Trim

                GenerarRolHorarios(cod_comp, cod_hora, sec, partir_mixto_fecha)
            Next

            MessageBox.Show("Rol de horarios completo", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub sdgDias_CellInfoLeave(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridCellInfoLeaveEventArgs)
        Try
            NumSemana = sdgDias.PrimaryGrid.GetCell(e.GridCell.RowIndex, 0).Value
            sdgDias.PrimaryGrid.Columns(0).DefaultNewRowCellValue = NumSemana
        Catch ex As Exception
            NumSemana = 1
        End Try
    End Sub

    Private Sub sdgDias_EndEdit(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridEditEventArgs)
        Dim R As Integer, C As Integer
        Dim n As Integer
        Dim Valor As String
        Try
            R = e.GridCell.RowIndex
            C = e.GridCell.ColumnIndex

            Valor = IIf(IsDBNull(sdgDias.PrimaryGrid.GetCell(R, C).Value), "", sdgDias.PrimaryGrid.GetCell(R, C).Value).ToString.Trim

            Select Case sdgDias.PrimaryGrid.Columns(C).Name
                Case "# DÍA DE ENTRADA", "# DÍA DE SALIDA"
                    'Día número - entrada o salida
                    n = IIf(IsDBNull(sdgDias.PrimaryGrid.GetCell(R, C).Value), 0, sdgDias.PrimaryGrid.GetCell(R, C).Value)
                    Select Case n
                        Case 1
                            sdgDias.PrimaryGrid.GetCell(R, C + 1).Value = "Lunes"
                        Case 2
                            sdgDias.PrimaryGrid.GetCell(R, C + 1).Value = "Martes"
                        Case 3
                            sdgDias.PrimaryGrid.GetCell(R, C + 1).Value = "Miércoles"
                        Case 4
                            sdgDias.PrimaryGrid.GetCell(R, C + 1).Value = "Jueves"
                        Case 5
                            sdgDias.PrimaryGrid.GetCell(R, C + 1).Value = "Viernes"
                        Case 6
                            sdgDias.PrimaryGrid.GetCell(R, C + 1).Value = "Sábado"
                        Case 7
                            sdgDias.PrimaryGrid.GetCell(R, C + 1).Value = "Domingo"
                        Case Else
                            sdgDias.PrimaryGrid.GetCell(R, C + 1).Value = "ERROR"
                    End Select

                Case "MINUTOS ANTES DE LA ENTRADA", "MINUTOS DESPUÉS DE LA ENTRADA", "MINUTOS ANTES DE LA SALIDA", "MINUTOS DESPUÉS DE LA SALIDA"
                    'Minutos antes/después de la entrada/salida
                    sdgDias.PrimaryGrid.GetCell(R, C).Value = CtoM(Valor)
                Case "ENTRADA", "SALIDA"
                    'Hora de entrada/Salida
                    If Not Valor.Contains("M") Then
                        sdgDias.PrimaryGrid.GetCell(R, C).Value = CtoH(Valor)
                    End If
                Case "HORAS POR DÍA", "HORAS DESPUÉS DE MEDIA NOCHE"
                    'Horas por día
                    sdgDias.PrimaryGrid.GetCell(R, C).Value = CtoHSimple(Valor)
            End Select

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub sdgDias_RowAdded(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridRowAddedEventArgs)

    End Sub

    Private Sub sdgDias_RowAdding(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridRowAddingEventArgs)
        'MCR 2017-10-05
        'Insertar nuevo registro 
        Try
            Dim R As Integer
            R = sdgDias.PrimaryGrid.ActiveCell.RowIndex
            For Each c As DevComponents.DotNetBar.SuperGrid.GridColumn In sdgDias.PrimaryGrid.Columns
                sdgDias.PrimaryGrid.Columns(c.ColumnIndex).DefaultNewRowCellValue = sdgDias.PrimaryGrid.GetCell(R, c.ColumnIndex).Value
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class
