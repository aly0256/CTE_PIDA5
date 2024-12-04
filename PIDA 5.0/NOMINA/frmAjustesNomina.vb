Public Class frmAjustesNomina
    Dim Editar As Boolean = False
    Dim Agregar As Boolean = False


    ' Tablas
    Dim dtperiodos As New DataTable
    Dim dtInfoPersonal As New DataTable
    Dim dtconceptos As New DataTable
    Dim dtDeducciones As New DataTable
    Dim dtDed2 As New DataTable
    Dim dtSaldos As New DataTable

    Dim seleccionado As String
    Dim dtTemp As New DataTable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarInformacion()
        HabilitarBotones()
    End Sub
    Public Sub HabilitarBotones()
        btnNext.Enabled = Not (Editar Or Agregar)
        btnFirst.Enabled = Not (Editar Or Agregar)
        btnLast.Enabled = Not (Editar Or Agregar)
        btnPrev.Enabled = Not (Editar Or Agregar)
        btnBorrar.Enabled = Not (Editar Or Agregar)
        btnCerrar.Enabled = Not (Editar Or Agregar)
        'btnReporte.Enabled = Not (Editar Or Agregar)
        btnBuscar.Enabled = Not (Editar Or Agregar)
        dgMaestro.ReadOnly = Not (Editar Or Agregar)

    End Sub


    ''' <summary>
    ''' Proceso para regresar la información al fin del periodo, revisando la bitácora
    ''' </summary>
    Private Function ConsultaBitacora(ByRef dtPersonal As DataTable, Ano As String, Periodo As String) As Boolean
        Dim dtPeriodos As New DataTable
        Dim dtBitacora As New DataTable
        Dim FechaTopeIni As Date
        Dim FechaTopeFin As Date
        Dim FechaMto As Date

        Try
            dtPeriodos = sqlExecute("SELECT fecha_ini,fecha_fin,ano,periodo FROM periodos WHERE ano+periodo = '" & Ano & Periodo & "'", "TA")
            'Fechas topes para buscar en el mantenimiento, lo que se haya generado en los mantenimientos de ese rango
            'La fecha tope inicial es un día después del fin del periodo
            FechaTopeIni = DateAdd(DateInterval.Day, 1, dtPeriodos.Rows(0).Item("fecha_fin"))
            'Fecha tope final, es 3 días después del fin del periodo
            FechaTopeFin = DateAdd(DateInterval.Day, 3, dtPeriodos.Rows(0).Item("fecha_fin"))

            'Revisar en la bitácora cuando se hizo el último mantenimiento en el rango
            dtBitacora = sqlExecute("SELECT MAX(fecha_mantenimiento) AS fecha FROM bitacora_personal WHERE fecha_mantenimiento " & _
                                    "BETWEEN '" & FechaSQL(FechaTopeIni) & "' AND '" & FechaSQL(FechaTopeFin) & "'")
            If dtBitacora.Rows.Count = 0 Then
                FechaMto = Now.Date
            Else
                FechaMto = IIf(IsDBNull(dtBitacora.Rows(0).Item("fecha")), Now.Date, dtBitacora.Rows(0).Item("fecha"))
            End If

            'Realizar para cada registro de la tabla
            For Each dRow As DataRow In dtPersonal.Rows
                '... con cada columna
                For Each dCol As DataColumn In dtPersonal.Columns
                    '.... excepto con el reloj
                    If dCol.ColumnName.ToLower <> "reloj" Then
                        'buscar si hay movimientos efectuados entre el mantenimiento y la fecha actual, y regresa el más antiguo
                        dtBitacora = sqlExecute("SELECT TOP 1 ValorAnterior FROM bitacora_personal WHERE " & _
                                                "fecha BETWEEN '" & FechaHoraSQL(DateAdd(DateInterval.Second, 1, FechaMto)) & _
                                                "' AND '" & FechaHoraSQL(Now) & "'" & _
                                                " AND reloj = '" & dRow("reloj") & "' and campo = '" & dCol.ColumnName & _
                                                "' ORDER BY fecha")
                        If dtBitacora.Rows.Count > 0 Then
                            'Si hubo registro, pasar el valor anterior a la tabla, para regresar al punto del mantenimiento
                            dRow(dCol.ColumnName) = dtBitacora.Rows(0).Item("ValorAnterior")
                        End If
                    End If
                Next
            Next

            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            Return False
        End Try
    End Function

    Public Sub MostrarInformacion(Optional ByVal rl As String = "")
        Dim ArchivoFoto As String
        Dim dRow As DataRow
        Try
            If rl = "" Then
                dtInfoPersonal = ConsultaPersonalVW("SELECT TOP 1 reloj,nombres,cod_tipo,cod_depto,cod_super,cod_clase,cod_turno,cod_hora, " & _
                                            "nombre_depto,nombre_turno,nombre_horario,nombre_tipoemp,nombre_clase,nombre_super,alta,baja  " & _
                                            "FROM personalVW ORDER BY reloj")
            Else
                dtInfoPersonal = ConsultaPersonalVW("SELECT TOP 1 reloj,nombres,cod_tipo,cod_depto,cod_super,cod_clase,cod_turno,cod_hora, " & _
                            "nombre_depto,nombre_turno,nombre_horario,nombre_tipoemp,nombre_clase,nombre_super,alta,baja  " & _
                            "FROM personalVW WHERE reloj = '" & rl & "' ORDER BY reloj")
            End If

            rl = IIf(IsDBNull(dtInfoPersonal.Rows.Item(0).Item("reloj")), "", dtInfoPersonal.Rows.Item(0).Item("reloj"))
            dRow = dtInfoPersonal.Rows(0)

            'Mostrar información
            txtReloj.Text = IIf(IsDBNull(dRow("reloj")), "", dRow("reloj"))
            txtNombre.Text = IIf(IsDBNull(dRow("nombres")), "", dRow("nombres"))

            txtAlta.Text = IIf(IsDBNull(dRow("alta")), Nothing, dRow("alta"))
            EsBaja = Not IsDBNull(dRow("baja"))
            txtBaja.Text = IIf(EsBaja, dRow("baja"), Nothing)

            txtTipoEmp.Text = IIf(IsDBNull(dRow("cod_tipo")), "", dRow("cod_tipo").ToString.Trim) & IIf(IsDBNull(dRow("nombre_tipoemp")), "", " (" & dRow("nombre_tipoemp").ToString.Trim & ")")
            txtDepto.Text = IIf(IsDBNull(dRow("cod_depto")), "", dRow("cod_depto").ToString.Trim) & IIf(IsDBNull(dRow("nombre_depto")), "", " (" & dRow("nombre_depto").ToString.Trim & ")")
            'txtSupervisor.Text = IIf(IsDBNull(dRow("cod_super")), "", dRow("cod_super").ToString.Trim) & IIf(IsDBNull(dRow("nombre_super")), "", " (" & dRow("nombre_super").ToString.Trim & ")")
            txtClase.Text = IIf(IsDBNull(dRow("cod_clase")), "", dRow("cod_clase").ToString.Trim) & IIf(IsDBNull(dRow("nombre_clase")), "", " (" & dRow("nombre_clase").ToString.Trim & ")")
            txtTurno.Text = IIf(IsDBNull(dRow("cod_turno")), "", dRow("cod_turno").ToString.Trim) & IIf(IsDBNull(dRow("nombre_turno")), "", " (" & dRow("nombre_turno").ToString.Trim & ")")
            txtHorario.Text = IIf(IsDBNull(dRow("cod_hora")), "", dRow("cod_hora").ToString.Trim) & IIf(IsDBNull(dRow("nombre_horario")), "", " (" & dRow("nombre_horario").ToString.Trim & ")")


            dtDeducciones = sqlExecute("SELECT ajustes_nom.ID,ajustes_nom.concepto as cod_concepto,ISNULL(RTRIM(CONCEPTOS.NOMBRE),ajustes_nom.concepto) AS CONCEPTO," & _
                                       "RTRIM(NUMCREDITO) AS NUMCREDITO,PERIODO,ANO,PER_DED," & _
                                       "MONTO,RTRIM(COMENTARIO) AS COMENTARIO,TIPO_AJUSTE,FECHA_INCIDENCIA,NUMPERIODOS,SALDO_ACT FROM  " & _
                                       "ajustes_nom LEFT JOIN CONCEPTOS ON ajustes_nom.CONCEPTO = CONCEPTOS.CONCEPTO  " & _
                                       "WHERE reloj = '" & rl & "' ORDER BY ano DESC,periodo DESC,concepto,numcredito", "Nomina")
            dgMaestro.DataSource = dtDeducciones

            ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
            Try
                ArchivoFoto = PathFoto & rl & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    ArchivoFoto = PathFoto & "nofoto.png"
                End If

                'Dim ft As New Bitmap(ArchivoFoto)
                'picFoto.Width = picFoto.MinimumSize.Width
                'picFoto.Height = picFoto.MinimumSize.Height
                'picFoto.Left = 900
                'picFoto.Image = ft
                picFoto.ImageLocation = ArchivoFoto
            Catch
                picFoto.Image = picFoto.ErrorImage
            End Try

            '****************************************

            '*** Cambios en bajas ****
            txtBaja.Visible = EsBaja
            lblBaja.Visible = EsBaja
            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtReloj.BackColor = lblEstado.BackColor
            '*************************
            Exit Sub
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        dtTemp = ConsultaPersonalVW("SELECT TOP 1 reloj FROM personalVW ORDER BY reloj ASC ")
        If dtTemp.Rows.Count <> 0 Then
            MostrarInformacion(dtTemp.Rows(0).Item("reloj"))
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        dtTemp = ConsultaPersonalVW("SELECT TOP 1 reloj FROM personalVW  ORDER BY reloj DESC ")
        If dtTemp.Rows.Count <> 0 Then
            MostrarInformacion(dtTemp.Rows(0).Item("reloj"))
        End If
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        dtTemp = ConsultaPersonalVW("SELECT TOP 1 reloj FROM personalVW where reloj < '" & txtReloj.Text & "'  ORDER BY reloj DESC ")
        If dtTemp.Rows.Count = 0 Then
            btnFirst.PerformClick()
        Else
            MostrarInformacion(dtTemp.Rows(0).Item("reloj"))
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        dtTemp = ConsultaPersonalVW("SELECT TOP 1 reloj FROM personalVW where reloj > '" & txtReloj.Text & "'  ORDER BY reloj ASC ")
        If dtTemp.Rows.Count = 0 Then
            btnLast.PerformClick()
        Else
            MostrarInformacion(dtTemp.Rows(0).Item("reloj"))
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtTemp = dtInfoPersonal
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            dtInfoPersonal = dtTemp
        End Try
    End Sub

    Private Sub dgMaestro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMaestro.CellDoubleClick
        btnEditar.PerformClick()
    End Sub

    Private Sub dgMovimientos_Paint(sender As Object, e As PaintEventArgs) Handles dgMaestro.Paint
        'Dim y As Integer
        'Dim BColor As System.Drawing.Color
        'For y = 0 To dgMaestro.RowCount - 1

        '    If dgMaestro.Item("cod_naturaleza", y).Value.ToString.Trim = "P" Then
        '        BColor = Color.LightGreen
        '    ElseIf dgMaestro.Item("cod_naturaleza", y).Value.ToString.Trim = "D" Then
        '        BColor = Color.LightYellow
        '    Else
        '        BColor = Color.White
        '    End If

        '    dgMaestro.Item("concepto", y).Style.BackColor = BColor
        '    dgMaestro.Item("monto", y).Style.BackColor = BColor
        '    dgMaestro.Item("descripcion", y).Style.BackColor = BColor
        'Next
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim dtAjuste As New DataTable
        Try
            AjustesNomKey = dgMaestro.Item("cLID", dgMaestro.CurrentRow.Index).Value.ToString.Trim
            'BERE
            'dtAjuste = sqlExecute("SELECT IIF(envio_nom IS NULL,0,envio_nom) AS enviado FROM ajustes_nom WHERE CONCAT(ano,periodo,reloj,concepto,numcredito) = '" & AjustesNomKey & "'", "NOMINA")
            dtAjuste = sqlExecute("SELECT (CASE WHEN envio_nom IS NULL THEN 0 ELSE envio_nom END) AS enviado FROM ajustes_nom WHERE ID = '" & AjustesNomKey & "'", "NOMINA")
            If dtAjuste.Rows.Count = 0 Then
                Err.Raise(-1)
            Else
                If dtAjuste.Rows(0).Item("enviado") = 1 Then
                    If MessageBox.Show("El registro ya fue enviado para pago. ¿Está seguro de querer modificarlo?", "Editar ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            If frmEditarAjustes.ShowDialog(Me) = Windows.Forms.DialogResult.Abort Then
                Err.Raise(-1)
            End If
            MostrarInformacion(txtReloj.Text)
        Catch ex As Exception
            MessageBox.Show("El registro no puede ser modificado. Favor de verificar." & vbCrLf & ex.Message, "Editar ajuste", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim Respuesta As Windows.Forms.DialogResult

        'Insertar núm. de crédito para formar registro base
        AjustesNomKey = "NVO"
        Respuesta = frmEditarAjustes.ShowDialog(Me)
        If Respuesta = Windows.Forms.DialogResult.Abort Then
            MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf Respuesta = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        MostrarInformacion(txtReloj.Text)
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            Dim dtAjuste As New DataTable
            AjustesNomKey = dgMaestro.Item("cLID", dgMaestro.CurrentRow.Index).Value.ToString.Trim
            'BERE
            'dtAjuste = sqlExecute("SELECT IIF(envio_nom IS NULL,0,envio_nom) AS enviado FROM ajustes_nom WHERE CONCAT(ano,periodo,reloj,concepto,numcredito) = '" & AjustesNomKey & "'", "NOMINA")
            dtAjuste = sqlExecute("SELECT (CASE WHEN envio_nom IS NULL THEN 0 ELSE envio_nom END) AS enviado FROM ajustes_nom WHERE ID = '" & AjustesNomKey & "'", "NOMINA")
            If dtAjuste.Rows.Count = 0 Then
                Err.Raise(-1)
            Else
                If dtAjuste.Rows(0).Item("enviado") = 1 Then
                    If MessageBox.Show("El registro ya fue enviado para pago. ¿Está seguro de querer borrarlo?", "Borrar ajustes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    Else
                        sqlExecute("DELETE FROM ajustes_nom WHERE ID = '" & AjustesNomKey & "'", "NOMINA")
                    End If
                Else
                    If MessageBox.Show("¿Está seguro de querer borrar este ajuste?", "Borrar ajustes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        sqlExecute("DELETE FROM ajustes_nom WHERE ID = '" & AjustesNomKey & "'", "NOMINA")
                    End If
                End If
            End If

            MostrarInformacion(txtReloj.Text)
        Catch ex As Exception
            MessageBox.Show("El ajuste no pudo ser borrado. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
    End Sub

End Class