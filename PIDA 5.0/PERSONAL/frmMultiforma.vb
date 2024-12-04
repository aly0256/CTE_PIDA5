Public Class frmMultiforma
    Dim dtRegistro As New DataTable
    Dim dtMovs As DataTable
    Dim dtTemp As DataTable
    Dim FiltroMultiforma As String = ""
    Private Sub frmModificacionPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If FiltroXUsuario.Length > 4 Then
            FiltroMultiforma = " where " & FiltroXUsuario
        Else
            FiltroMultiforma = ""
        End If
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM personalVW" & FiltroMultiforma)
        MostrarInformacion()
    End Sub
    Private Sub MostrarInformacion(Optional ByVal rl As String = "")
        Dim ArchivoFoto As String
        Try
            'Mostrar información
            If rl <> "" Then
                If FiltroXUsuario.Length > 4 Then
                    FiltroMultiforma = " and " & FiltroXUsuario
                Else
                    FiltroMultiforma = ""
                End If
                dtRegistro = sqlExecute("SELECT TOP 1 * FROM personalVW WHERE RELOJ = '" & rl & "'" & FiltroMultiforma)
            End If
            Dim dRow = dtRegistro.Rows(0)
            txtReloj.Text = IIf(IsDBNull(dRow("RELOJ")), "", dRow("RELOJ"))
            txtNombre.Text = IIf(IsDBNull(dRow("NOMBRES")), "", dRow("NOMBRES"))
            txtAlta.Text = IIf(IsDBNull(dRow("ALTA")), Nothing, dRow("ALTA"))
            EsBaja = Not IsDBNull(dRow("BAJA"))
            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtBaja.Text = IIf(EsBaja, dRow("BAJA"), Nothing)
            txtTipoEmp.Text = IIf(IsDBNull(dRow("COD_TIPO")), "", dRow("COD_TIPO").ToString.Trim) & IIf(IsDBNull(dRow("nombre_tipoemp")), "", " (" & dRow("nombre_tipoemp").ToString.Trim & ")")
            txtArea.Text = IIf(IsDBNull(dRow("COD_AREA")), "", dRow("COD_AREA").ToString.Trim) & IIf(IsDBNull(dRow("nombre_area")), "", " (" & dRow("nombre_area").ToString.Trim & ")")
            txtDepto.Text = IIf(IsDBNull(dRow("COD_DEPTO")), "", dRow("COD_DEPTO").ToString.Trim) & IIf(IsDBNull(dRow("nombre_depto")), "", " (" & dRow("nombre_depto").ToString.Trim & ")")
            txtSupervisor.Text = IIf(IsDBNull(dRow("COD_SUPER")), "", dRow("COD_SUPER").ToString.Trim) & IIf(IsDBNull(dRow("nombre_super")), "", " (" & dRow("nombre_super").ToString.Trim & ")")
            txtClase.Text = IIf(IsDBNull(dRow("COD_CLASE")), "", dRow("COD_CLASE").ToString.Trim) & IIf(IsDBNull(dRow("nombre_clase")), "", " (" & dRow("nombre_clase").ToString.Trim & ")")
            txtTurno.Text = IIf(IsDBNull(dRow("COD_TURNO")), "", dRow("COD_TURNO").ToString.Trim) & IIf(IsDBNull(dRow("nombre_Turno")), "", " (" & dRow("nombre_Turno").ToString.Trim & ")")
            txtHorario.Text = IIf(IsDBNull(dRow("COD_HORA")), "", dRow("COD_HORA").ToString.Trim) & IIf(IsDBNull(dRow("nombre_Horario")), "", " (" & dRow("nombre_Horario").ToString.Trim & ")")
            txtPuesto.Text = IIf(IsDBNull(dRow("COD_PUESTO")), "", dRow("COD_PUESTO").ToString.Trim) & IIf(IsDBNull(dRow("nombre_Puesto")), "", " (" & dRow("nombre_Puesto").ToString.Trim & ")")
            Compania = IIf(IsDBNull(dRow("COD_COMP")), "", dRow("COD_COMP").ToString.Trim)
            lblBaja.Visible = EsBaja
            txtBaja.Visible = EsBaja
            Reloj = txtReloj.Text
            dtMovs = sqlExecute("SELECT RELOJ," & _
                               "FECHA_CAPTURA,HORA_CAPTURA,USUARIO,TIPO_MOVIMIENTO," & _
                               "COMENTARIO,CONFIRMADO,IMPRESO," & _
                               "CASE TIPO_MOVIMIENTO " & _
                               "WHEN 'BAJA' THEN ('Motivo de baja: '+ cast(COD_MOT_BA as VARCHAR) + ' Fecha baja: '+ cast (FECHA_BAJA as VARCHAR))  " & _
                               "WHEN 'AUSENTISMO' THEN ('Tipo de ausentismo: '+ cast(TIPO_AUS as VARCHAR) + ' Fecha de inicio: '+ cast (FECHA_INICIO as VARCHAR)+ ' Duracion: '+ cast (CANTIDAD_DIAS as VARCHAR) + ' días') " & _
                               "WHEN 'POSICION' THEN ('Campo: '+ cast(CAMPO as VARCHAR) + ' Actual: '+ cast (VALOR_ACTUAL as VARCHAR)+ ' Nuevo: '+ cast (VALOR_NUEVO as VARCHAR) + ' Fecha efectiva: '+ cast (FECHA_EFECTIVA as VARCHAR)) " & _
                               "WHEN 'TURNO' THEN ('Campo: '+ cast(CAMPO as VARCHAR) + ' Actual: '+ cast (VALOR_ACTUAL as VARCHAR)+ ' Nuevo: '+ cast (VALOR_NUEVO as VARCHAR) + ' Fecha efectiva: '+ cast (FECHA_EFECTIVA as VARCHAR)) " & _
                               "WHEN 'SALARIO' THEN ('Campo: '+ cast(CAMPO as VARCHAR) + ' Actual: '+ cast (VALOR_ACTUAL as VARCHAR)+ ' Nuevo: '+ cast (VALOR_NUEVO as VARCHAR) + ' Fecha efectiva: '+ cast (FECHA_EFECTIVA as VARCHAR)) " & _
                               "END AS DETALLE " & _
                               "FROM formato_multiple where reloj = '" + Reloj + "' and tipo_movimiento <> 'SALARIO' order by fecha_captura desc")

            dgTabla.DataSource = dtMovs
            ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
            Try
                ArchivoFoto = PathFoto & Reloj & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    ArchivoFoto = PathFoto & "nofoto.png"
                End If
                'Dim ft As New Bitmap(ArchivoFoto)
                picFoto.Width = picFoto.MinimumSize.Width
                picFoto.Height = picFoto.MinimumSize.Height
                picFoto.Left = 900
                'picFoto.Image = ft
                picFoto.ImageLocation = ArchivoFoto
            Catch
                picFoto.Image = picFoto.ErrorImage
            End Try
        Catch ex As Exception
            ErrorLog(USUARIO, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'Primero("personalVW", "RELOJ", dtRegistro)
        'MostrarInformacion()

        ' Para que respete el filtro por usuario
        dtRegistro = ConsultaPersonalVW("SELECT TOP 1 * from personalvw ORDER BY reloj ASC")
        MostrarInformacion()
    End Sub
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Anterior("personalVW", "RELOJ", txtReloj.Text, dtRegistro)
        'MostrarInformacion()

        ' Para que respete el filtro por usuario
        dtRegistro = ConsultaPersonalVW("SELECT TOP 1 * from personalvw WHERE reloj <'" & Reloj & "' ORDER BY reloj DESC")
        MostrarInformacion()
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Siguiente("personalVW", "RELOJ", txtReloj.Text, dtRegistro)
        'MostrarInformacion()

        ' Para que respete el filtro por usuario
        dtRegistro = ConsultaPersonalVW("SELECT TOP 1 * from personalvw WHERE reloj >'" & Reloj & "' ORDER BY reloj ASC")
        MostrarInformacion()
          
    End Sub
    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        '    Ultimo("personalVW", "RELOJ", dtRegistro)
        '    MostrarInformacion()

        ' Para que respete el filtro por usuario
        dtRegistro = ConsultaPersonalVW("SELECT TOP 1 * from personalvw ORDER BY reloj DESC")
        MostrarInformacion()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        dtTemp = dtRegistro
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj)
            Else
                MostrarInformacion(txtReloj.Text)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtRegistro = dtTemp
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If dtMovs.Rows.Count > 0 Then
            Dim _movimiento As String = dgTabla.SelectedCells.Item(4).Value.ToString().Trim
            Dim Nuevo As New frmMultiformaCaptura("Editar", _movimiento)
            Nuevo.ShowDialog()
        End If
        MostrarInformacion()

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If dtMovs.Rows.Count > 0 Then

            Dim _compa As String = Compania
            Dim _reloj As String = dgTabla.SelectedCells.Item(0).Value.ToString().Trim
            Dim _fecha As String = FechaSQL(dgTabla.SelectedCells.Item(1).Value)
            ' Dim _hora As String = FechaHoraSQL(dgTabla.SelectedCells.Item(3).Value)
            Dim _usuario As String = dgTabla.SelectedCells.Item(3).Value.ToString().Trim
            Dim _movimiento As String = dgTabla.SelectedCells.Item(4).Value.ToString().Trim
            Dim _comentario As String = dgTabla.SelectedCells.Item(5).Value.ToString().Trim
            Dim _detalle As String = dgTabla.SelectedCells.Item(8).Value.ToString().Trim
            Dim _confirmado As String = dgTabla.SelectedCells.Item(6).Value.ToString().Trim
            Dim _impreso As String = dgTabla.SelectedCells.Item(7).Value.ToString().Trim

            Dim _campo As String = "None"

            If MessageBox.Show("Estás seguro que deseas borrar este registro? (reloj:" + _reloj + ",Mov:" + _movimiento + ")", "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                If _confirmado.Equals("0") Then
                    If _movimiento.Equals("BAJA") Then
                        sqlExecute("delete formato_multiple where cod_comp ='" + _compa + "' and reloj ='" + _reloj + "' and usuario='" + _usuario + "' and comentario ='" + _comentario + "' and tipo_movimiento ='" + _movimiento + "' and confirmado ='0'")
                    ElseIf _movimiento.Equals("AUSENTISMO") Then
                        sqlExecute("delete formato_multiple where cod_comp ='" + _compa + "' and reloj ='" + _reloj + "' and usuario='" + _usuario + "' and comentario ='" + _comentario + "' and tipo_movimiento ='" + _movimiento + "' and confirmado ='0'")
                    ElseIf _movimiento.Equals("POSICION") Or _movimiento.Equals("TURNO") Then
                        If _detalle.Contains("COD_DEPTO") Then
                            _campo = "COD_DEPTO"
                        ElseIf _detalle.Contains("COD_HORA") Then
                            _campo = "COD_HORA"
                        ElseIf _detalle.Contains("COD_TURNO") Then
                            _campo = "COD_TURNO"
                        ElseIf _detalle.Contains("COD_SUPER") Then
                            _campo = "COD_SUPER"
                        ElseIf _detalle.Contains("COD_LINEA") Then
                            _campo = "COD_LINEA"
                        ElseIf _detalle.Contains("COD_PUESTO") Then
                            _campo = "COD_PUESTO"
                        End If
                        sqlExecute("delete formato_multiple where cod_comp ='" + _compa + "' and reloj ='" + _reloj + "' and usuario='" + _usuario + "' and comentario ='" + _comentario + "' and tipo_movimiento ='" + _movimiento + "' and campo ='" + _campo + "' and confirmado ='0'")
                    End If
                Else

                End If

            End If

        End If

        MostrarInformacion()
        'If dtMovs.Rows.Count > 0 Then
        '    If MessageBox.Show("¿Estás seguro que deseas este registro de  empleado " + Reloj + "?", "Eliminar registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '        sqlExecute("delete formato_multiple where reloj = '" + Reloj + "' and confirmado = '0'")
        '       
        '    End If
        'End If

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtinfo As DataTable = sqlExecute("select  * from formato_multiple where confirmado = '0' and reloj = '" + Reloj + "'")
        If dtinfo.Rows.Count > 0 Then
            dtinfo = sqlExecute("select reloj,'individual' as tipo_reporte from personalvw where reloj = '" + Reloj + "'")
            frmVistaPrevia.LlamarReporte("Formato Multiple", dtinfo)
            frmVistaPrevia.ShowDialog()
            sqlExecute("update formato_multiple set impreso='1' where impreso = '0' and reloj = '" + Reloj + "'")
        Else
            MessageBox.Show("El empleado " + Reloj + " no contiene información para crear el reporte", "No hay información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        MostrarInformacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        Dim Nuevo As New frmMultiformaCaptura("Agregar")
        Nuevo.ShowDialog()
        MostrarInformacion()

    End Sub

    Private Sub metodos()
        'Confirmar todos
        If MessageBox.Show("¿Estás seguro que deseas aplicar todos los movimientos para el empleado " + Reloj + "?", "Aplicar todo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sqlExecute("update formato_multiple set  confirmado = '1' where confirmado = '0' and reloj = '" + Reloj + "' ")
            MostrarInformacion()
        End If
        '
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        frmMultiformaAplicacion.ShowDialog()
    End Sub

 
End Class