Public Class frmMedidaAccionDisciplinaria
    Dim dtRegistros As New DataTable
    Dim dtLista As DataTable
    Dim dtTemp As DataTable
    Dim FiltroDisciplinaria As String = ""
    Dim dtPersonal As New DataTable

    Private Sub frmMedidaAccionDisciplinaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(My.Computer.Screen.Bounds.Width, 600)
        If FiltroXUsuario.Length > 4 Then
            FiltroDisciplinaria = " where" & FiltroXUsuario
        Else
            FiltroDisciplinaria = ""
        End If
        dtRegistros = sqlExecute("select top 1 * from personalVW" & FiltroDisciplinaria)
        MostrarInformacion()


    End Sub
    Private Sub MostrarInformacion(Optional ByVal rl As String = "")
        Dim ArchivoFoto As String


        Try
            'Mostrar la informacion en los txtbox
            If rl <> "" Then
                If FiltroXUsuario.Length > 4 Then
                    FiltroDisciplinaria = " and" & FiltroXUsuario
                Else
                    FiltroDisciplinaria = ""
                End If
                dtRegistros = sqlExecute("select top 1 * from personalVW where reloj= '" & rl & "'" & FiltroDisciplinaria & " order by reloj asc")

            End If
            Dim drow = dtRegistros.Rows(0)
            txtReloj.Text = IIf(IsDBNull(drow("RELOJ")), "", drow("RELOJ"))
            txtNombre.Text = IIf(IsDBNull(drow("NOMBRES")), "", drow("NOMBRES"))
            txtAlta.Text = IIf(IsDBNull(drow("ALTA")), "", drow("ALTA"))
            EsBaja = Not IsDBNull(drow("BAJA"))
            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtBaja.Text = IIf(EsBaja, drow("BAJA"), Nothing)
            txtDepartamento.Text = IIf(IsDBNull(drow("COD_DEPTO")), "", drow("COD_DEPTO").ToString.Trim) & IIf(IsDBNull(drow("nombre_depto")), "", ", " & drow("nombre_depto").ToString.Trim)
            txtSupervisor.Text = IIf(IsDBNull(drow("COD_SUPER")), "", drow("COD_SUPER").ToString.Trim) & IIf(IsDBNull(drow("nombre_super")), "", ", " & drow("nombre_super").ToString.Trim)
            txtTurno.Text = IIf(IsDBNull(drow("COD_TURNO")), "", drow("COD_PLANTA").ToString.Trim) & IIf(IsDBNull(drow("nombre_turno")), "", ", " & drow("nombre_turno").ToString.Trim)
            Reloj = txtReloj.Text


            dtLista = sqlExecute("select accion_disciplinaria.FOLIO, accion_disciplinaria.FECHA_CAPTURA, accion_disciplinaria.fecha as fecha_incidencia, tipo_disciplinaria.TIPO_ACCION_DISCIPLINARIA,  " & _
                                 "cod_motivo_disciplinario.cod_motivo, cod_motivo_disciplinario.NOMBRE as MOTIVO, cod_cat_disciplinaria.nombre, " & _
                                 "accion_disciplinaria.coment_super, accion_disciplinaria.coment_empleado " & _
                                 "from accion_disciplinaria LEFT JOIN cod_motivo_disciplinario on accion_disciplinaria.COD_MOTIVO = cod_motivo_disciplinario.COD_MOTIVO " & _
                                 "LEFT JOIN tipo_disciplinaria on accion_disciplinaria.COD_TIPO_ACCION = tipo_disciplinaria.COD_TIPO_ACCION " & _
                                 "LEFT JOIN cod_cat_disciplinaria on accion_disciplinaria.categoria = cod_cat_disciplinaria.cod_categoria WHERE RELOJ = '" & txtReloj.Text & "'")
            dgTabla.DataSource = dtLista

            dgAusentismo.DataSource = sqlExecute("select reloj, fecha, periodo from ausentismo where tipo_aus = 'SUS' and reloj = '" & txtReloj.Text & "' order by fecha desc", "TA")





            'Proceso para cargar fotografia
            Try
                ArchivoFoto = PathFoto & txtReloj.Text.Trim & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    picFoto.Image = My.Resources.NoFoto
                Else
                    picFoto.ImageLocation = ArchivoFoto
                End If

            Catch
                picFoto.Image = picFoto.ErrorImage
                picFoto.SizeMode = PictureBoxSizeMode.Zoom
            End Try

            If lblEstado.Text = "ACTIVO" Then
                txtBaja.Visible = False
                lblBaja.Visible = False
            Else
                txtBaja.Visible = True
                lblBaja.Visible = True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
   
    '-- Modificado abril 8

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Dim reloj As String
        Try
            reloj = txtReloj.Text
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw WHERE reloj >'" & reloj & "' ORDER BY reloj ASC")
            If dtPersonal.Rows.Count < 1 Then
                btnUltimo.PerformClick()
            Else
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
                MostrarInformacion(reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub
    '-- Modificado abril 8

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Dim reloj As String
        Try
            reloj = txtReloj.Text
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw ORDER BY reloj DESC")
            If dtPersonal.Rows.Count > 0 Then
                'EmpIdx = dtPersonal.Rows.Count - 1
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
                MostrarInformacion(reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub
    '-- Modificado abril 8

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Dim reloj As String
        Try
            reloj = txtReloj.Text
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw WHERE reloj <'" & reloj & "' ORDER BY reloj DESC")
            If dtPersonal.Rows.Count < 1 Then
                btnPrimero.PerformClick()
            Else
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")

                MostrarInformacion(reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    '-- Modificado abril 8

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Dim reloj As String
        Try
            reloj = txtReloj.Text
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw ORDER BY reloj ASC")
            If dtPersonal.Rows.Count > 0 Then
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
                MostrarInformacion(reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If lblEstado.Text = "ACTIVO" Then
            editarDisciplinaria = False
            frmCapturaAccionDisciplinaria.ShowDialog()
            MostrarInformacion()
        Else
            MessageBox.Show("No es posible asignar una acción disciplinaria a personal inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim dteditar As New DataTable
        Try

            folioDisciplinaria = dgTabla.Item("cl_folio", dgTabla.CurrentRow.Index).Value.ToString.Trim
            editarDisciplinaria = True
            frmCapturaAccionDisciplinaria.ShowDialog()
            MostrarInformacion()

        Catch ex As Exception
            MessageBox.Show("El registro no puede ser modificado. Favor de verificar.", "Editar ajuste", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

        If dgTabla.RowCount > 0 Then
            folioDisciplinaria = dgTabla.Item("cl_folio", dgTabla.CurrentRow.Index).Value.ToString.Trim
            If MessageBox.Show("¿Está seguro de querer borrar la accion disciplinaria registrada al empleado '" & txtReloj.Text & "'", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                sqlExecute("DELETE from accion_disciplinaria where folio='" & folioDisciplinaria & "'")


                '=====2024-07-10: Si tiene una suspension capturada en lo que va a eliminar, preguntar si desea borrarla
                Dim fecha_incidencia As String = "", categoria As String = ""

                Try : fecha_incidencia = FechaSQL(dgTabla.Item("Column8", dgTabla.CurrentRow.Index).Value) : Catch ex As Exception : fecha_incidencia = "" : End Try
                Try : categoria = dgTabla.Item("Column9", dgTabla.CurrentRow.Index).Value.ToString.Trim : Catch ex As Exception : categoria = "" : End Try

                If categoria = "Suspensión" Then ' Si el registro es una suspensión
                    Dim dtExisteSuspension As DataTable = sqlExecute("select * from ta.dbo.ausentismo where reloj='" & txtReloj.Text.Trim & "' and TIPO_AUS='SUS' and fecha='" & fecha_incidencia & "'", "TA")
                    If Not dtExisteSuspension.Columns.Contains("Error") And dtExisteSuspension.Rows.Count > 0 Then
                        If MessageBox.Show("¿Al eliminar este registro, existe una suspensión capturada en Kardex para el día '" & fecha_incidencia & "', desea eliminarla también?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            sqlExecute("delete from ta.dbo.ausentismo where reloj='" & txtReloj.Text.Trim & "' and fecha='" & fecha_incidencia & "' and TIPO_AUS='SUS'", "TA")
                        End If
                    End If


                End If

                MostrarInformacion()
            End If
        Else
            MessageBox.Show("No hay registros para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtTemp = dtPersonal
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                If FiltroXUsuario.Length > 4 Then
                    FiltroDisciplinaria = " and" & FiltroXUsuario
                Else
                    FiltroDisciplinaria = ""
                End If               
                dtRegistros = sqlExecute("select * from personalVW where reloj = '"&Reloj &"'" & FiltroDisciplinaria)

                MostrarInformacion()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtPersonal = dtTemp
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

        Try
            If dgTabla.RowCount > 0 Then
                folioDisciplinaria = dgTabla.Item("cl_folio", dgTabla.CurrentRow.Index).Value.ToString.Trim
                frmReportesDisciplinarios.ShowDialog()
                If DisciplinarioIndividual = True Then
                    frmVistaPrevia.LlamarReporte("Reporte disciplinario individual", sqlExecute("select accion_disciplinaria.categoria, accion_disciplinaria.folio, accion_disciplinaria.reloj, personalVW.nombres, " & _
                                                                                                "plantas.NOMBRE as planta, deptos.NOMBRE as depto, super.NOMBRE as supervisor, " & _
                                                                                                "turnos.NOMBRE as turno, cod_motivo_disciplinario.NOMBRE as motivo, tipo_disciplinaria.TIPO_ACCION_DISCIPLINARIA, " & _
                                                                                                " accion_disciplinaria.FECHA, accion_disciplinaria.fecha_captura, " & _
                                                                                                "accion_disciplinaria.COMENT_SUPER, accion_disciplinaria.COMENT_EMPLEADO, accion_disciplinaria.cod_tipo_accion " & _
                                                                                                "from accion_disciplinaria " & _
                                                                                                "LEFT JOIN personalVW on accion_disciplinaria.reloj = personalVW.reloj " & _
                                                                                                "LEFT JOIN plantas on  accion_disciplinaria.COD_PLANTA = plantas.COD_PLANTA and accion_disciplinaria.COD_COMP = plantas.COD_COMP " & _
                                                                                                "LEFT JOIN deptos on accion_disciplinaria.COD_DEPTO = deptos.COD_DEPTO and accion_disciplinaria.COD_COMP = deptos.COD_COMP " & _
                                                                                                "LEFT JOIN super on accion_disciplinaria.COD_SUPER = super.COD_SUPER and accion_disciplinaria.COD_COMP = super.COD_COMP " & _
                                                                                                "LEFT JOIN turnos on accion_disciplinaria.COD_TURNO = turnos.COD_TURNO and accion_disciplinaria.COD_COMP = turnos.COD_COMP " & _
                                                                                                "LEFT JOIN cod_motivo_disciplinario on accion_disciplinaria.COD_MOTIVO = cod_motivo_disciplinario.COD_MOTIVO " & _
                                                                                                "LEFT JOIN tipo_disciplinaria on accion_disciplinaria.COD_TIPO_ACCION = tipo_disciplinaria.COD_TIPO_ACCION " & _
                                                                                                "LEFT JOIN cod_cat_disciplinaria on accion_disciplinaria.categoria = cod_cat_disciplinaria.cod_categoria " & _
                                                                                                "where folio ='" & folioDisciplinaria & "'"))
                    frmVistaPrevia.ShowDialog()
                    DisciplinarioIndividual = False
                End If

                If DisciplinarioGeneral = True Then
                    frmVistaPrevia.LlamarReporte("Reporte disciplinario general", sqlExecute("select cod_cat_disciplinaria.nombre as categoria, accion_disciplinaria.folio, accion_disciplinaria.reloj, personalVW.nombres, accion_disciplinaria.cod_motivo, " & _
                                                                                                "plantas.NOMBRE as planta, deptos.NOMBRE as depto, super.NOMBRE as supervisor, " & _
                                                                                                "turnos.NOMBRE as turno, cod_motivo_disciplinario.NOMBRE as motivo, tipo_disciplinaria.TIPO_ACCION_DISCIPLINARIA, " & _
                                                                                                "accion_disciplinaria.FECHA, " & _
                                                                                                "accion_disciplinaria.COMENT_SUPER, accion_disciplinaria.COMENT_EMPLEADO " & _
                                                                                                "from accion_disciplinaria " & _
                                                                                                "LEFT JOIN personalVW on accion_disciplinaria.reloj = personalVW.reloj " & _
                                                                                                "LEFT JOIN plantas on  accion_disciplinaria.COD_PLANTA = plantas.COD_PLANTA and accion_disciplinaria.COD_COMP = plantas.COD_COMP " & _
                                                                                                "LEFT JOIN deptos on accion_disciplinaria.COD_DEPTO = deptos.COD_DEPTO and accion_disciplinaria.COD_COMP = deptos.COD_COMP " & _
                                                                                                "LEFT JOIN super on accion_disciplinaria.COD_SUPER = super.COD_SUPER and accion_disciplinaria.COD_COMP = super.COD_COMP " & _
                                                                                                "LEFT JOIN turnos on accion_disciplinaria.COD_TURNO = turnos.COD_TURNO and accion_disciplinaria.COD_COMP = turnos.COD_COMP " & _
                                                                                                "LEFT JOIN cod_motivo_disciplinario on accion_disciplinaria.COD_MOTIVO = cod_motivo_disciplinario.COD_MOTIVO " & _
                                                                                                "LEFT JOIN tipo_disciplinaria on accion_disciplinaria.COD_TIPO_ACCION = tipo_disciplinaria.COD_TIPO_ACCION " & _
                                                                                                "LEFT JOIN cod_cat_disciplinaria on accion_disciplinaria.categoria = cod_cat_disciplinaria.cod_categoria " & _
                                                                                                "where accion_disciplinaria.reloj = '" & txtReloj.Text & "'"))
                    frmVistaPrevia.ShowDialog()
                    DisciplinarioGeneral = False
                End If


                If DisciplinarioPDF = True Then
                    Dim dttemp As DataTable = sqlExecute("select * from accion_disciplinaria where folio = '" & folioDisciplinaria & "'")


                    If dttemp.Rows.Count > 0 Then
                        Dim savepath As String = IIf(IsDBNull(dttemp.Rows(0).Item("path_pdf")), "", dttemp.Rows(0).Item("path_pdf"))
                        If System.IO.File.Exists(savepath) Then
                            Dim File As New SaveFileDialog
                            Dim ruta_origen As String = ""
                            Dim ruta_destino As String = ""

                            File.Title = "Abrir..."
                            File.Filter = "PDF Files(*.pdf)|*.pdf|All Files(*.*)|*.*"
                            Dim rs As DialogResult = File.ShowDialog()

                            If rs = Windows.Forms.DialogResult.OK Then
                                ruta_origen = savepath
                                ruta_destino = File.FileName
                                My.Computer.FileSystem.CopyFile(ruta_origen, ruta_destino, True)
                            End If
                        Else
                            MessageBox.Show("Esta registro de accion disciplinaria no cuenta con un archivo PDF.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else

                    End If
                    DisciplinarioPDF = False
                End If

            Else
                MessageBox.Show("No hay informacion para generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class