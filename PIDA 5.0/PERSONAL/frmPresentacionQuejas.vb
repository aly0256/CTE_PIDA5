''' <summary>
''' Módulo de presentación de quejas a empleados [basado en el módulo de acción disciplinaria]
''' Ernesto  13feb2023
''' </summary>
''' <remarks></remarks>
Public Class frmPresentacionQuejas
    Dim dtInfoEmpleado As New DataTable
    Dim dtLista As DataTable
    Dim dtTemp As DataTable
    Dim dtPersonal As New DataTable
    Dim strQry = ""
    Dim strFolio = ""

    Private Sub frmMedidaAccionDisciplinaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(My.Computer.Screen.Bounds.Width, 600)

        '== Información del empleado y registros de quejas
        strQry = "SELECT RTRIM(P.RELOJ) AS RELOJ,RTRIM(P.NOMBRES) AS NOMBRES,P.ALTA,P.BAJA," &
                  "(CASE WHEN ISNULL(P.BAJA,'')='' THEN 'ACTIVO' ELSE 'INACTIVO' END) AS ESTADO," &
                  "(RTRIM(P.COD_DEPTO) + ', ' + RTRIM(P.nombre_depto)) AS DEPARTAMENTO," &
                  "(RTRIM(P.COD_SUPER) + ', ' + RTRIM(P.nombre_super)) AS SUPERVISOR," &
                  "(RTRIM(P.COD_TURNO) + ', ' + RTRIM(P.nombre_turno)) AS TURNO," &
                  "Q.RELOJ AS ACUSANTE,Q.FOLIO,Q.FECHA_CAPTURA,Q.COD_MOTIVO,C.NOMBRE AS MOTIVO,Q.FECHA as FECHA_INCIDENCIA,Q.COMENT_SUPER,Q.COMENT_EMPLEADO, " &
                  "(SELECT COUNT(ACUSADO) FROM PERSONAL.dbo.presentacion_quejas WHERE ACUSADO=Q.ACUSADO GROUP BY ACUSADO) AS NUM_QUEJAS " &
                  "FROM PERSONAL.dbo.personalvw P " &
                  "LEFT JOIN PERSONAL.dbo.presentacion_quejas Q ON P.RELOJ=Q.ACUSADO " &
                  "LEFT JOIN PERSONAL.dbo.cod_queja C ON Q.COD_MOTIVO=C.COD_MOTIVO " &
                  "WHERE P.RELOJ='{0}'"

        MostrarInformacion(sqlExecute("SELECT TOP 1 RTRIM(RELOJ) AS RELOJ FROM PERSONAL.dbo.personal ORDER BY RELOJ ASC").Rows(0)("reloj"))
    End Sub

    ''' <summary>
    ''' Muestra la información principal de la interfaz
    ''' </summary>
    ''' <param name="rl"></param>
    ''' <remarks></remarks>
    Private Sub MostrarInformacion(Optional ByVal rl As String = "")
        Dim ArchivoFoto As String

        Try
            '== Mostrar la informacion en los txtbox
            If rl <> "" Then
                dtInfoEmpleado = sqlExecute(String.Format(strQry, rl))
            Else
                Exit Sub
            End If

            '== Info. empleado consultado
            Dim drow = dtInfoEmpleado.Rows(0)
            txtReloj.Text = IIf(IsDBNull(drow("RELOJ")), "", drow("RELOJ"))
            txtNombre.Text = IIf(IsDBNull(drow("NOMBRES")), "", drow("NOMBRES"))
            txtAlta.Text = IIf(IsDBNull(drow("ALTA")), "", drow("ALTA"))
            EsBaja = Not IsDBNull(drow("BAJA"))
            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtBaja.Text = IIf(EsBaja, drow("BAJA"), Nothing)
            txtDepartamento.Text = IIf(IsDBNull(drow("DEPARTAMENTO")), "", drow("DEPARTAMENTO"))
            txtSupervisor.Text = IIf(IsDBNull(drow("SUPERVISOR")), "", drow("SUPERVISOR"))
            txtTurno.Text = IIf(IsDBNull(drow("TURNO")), "", drow("TURNO"))
            Reloj = txtReloj.Text

            '== Registros de quejas
            If IsDBNull(dtInfoEmpleado.Rows(0)("NUM_QUEJAS")) Then dtInfoEmpleado.Rows.Clear()
            dgTabla.DataSource = New DataView(dtInfoEmpleado).ToTable(False, "ACUSANTE", "FOLIO", "FECHA_CAPTURA", "COD_MOTIVO", "MOTIVO", "FECHA_INCIDENCIA", "COMENT_SUPER", "COMENT_EMPLEADO")

            '== Proceso para cargar fotografia
            Try
                ArchivoFoto = PathFoto & txtReloj.Text.Trim & ".jpg"
                'If Dir(ArchivoFoto) = "" Then
                '    picFoto.Image = My.Resources.NoFoto
                'Else
                '    picFoto.ImageLocation = ArchivoFoto
                'End If

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
            Dim captura As New frmCapturaQuejas(False, 0)
            captura.ShowDialog()
            MostrarInformacion(txtReloj.Text.ToString.ToString)
        Else
            MessageBox.Show("No es posible asignar una queja a personal inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim dteditar As New DataTable
        Try
            strFolio = dgTabla.Item("cl_folio", dgTabla.CurrentRow.Index).Value.ToString.Trim
            Dim captura As New frmCapturaQuejas(True, CInt(strFolio))
            captura.ShowDialog()
            MostrarInformacion(Reloj)
        Catch ex As Exception
            MessageBox.Show("No hay registros para editar.", "Editar ajuste", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If dgTabla.RowCount > 0 Then
            Dim strAcusante = ""
            Dim strMotivo = ""

            strFolio = dgTabla.Item("cl_folio", dgTabla.CurrentRow.Index).Value.ToString.Trim
            strAcusante = dgTabla.Item("col_acusante", dgTabla.CurrentRow.Index).Value.ToString.Trim
            strMotivo = dgTabla.Item("col_motivo", dgTabla.CurrentRow.Index).Value.ToString.Trim

            If MessageBox.Show("¿Está seguro de querer eliminar la queja registrada al empleado '" & txtReloj.Text & "' con la siguiente información? " & vbNewLine & vbNewLine &
                               "Acusante: " & strAcusante & vbNewLine & "Motivo: " & strMotivo, "Borrar",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                sqlExecute("DELETE from PERSONAL.dbo.presentacion_quejas where folio='" & strFolio & "'")

                If sqlExecute("SELECT reloj FROM PERSONAL.dbo.presentacion_quejas WHERE FOLIO='" & strFolio & "'").Rows.Count = 0 Then
                    MessageBox.Show("Registro eliminado con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Ocurrió un error durante la eliminación, por favor, inténtelo nuevamente. Si el problema persiste, contacte al administrador del sistema.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                MostrarInformacion(Reloj)
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
                MostrarInformacion(Reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtPersonal = dtTemp
        End Try
    End Sub

    'Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

    '    Try
    '        If dgTabla.RowCount > 0 Then
    '            folioDisciplinaria = dgTabla.Item("cl_folio", dgTabla.CurrentRow.Index).Value.ToString.Trim
    '            frmReportesDisciplinarios.ShowDialog()
    '            If DisciplinarioIndividual = True Then
    '                frmVistaPrevia.LlamarReporte("Reporte disciplinario individual", sqlExecute("select accion_disciplinaria.categoria, accion_disciplinaria.folio, accion_disciplinaria.reloj, personalVW.nombres, " & _
    '                                                                                            "plantas.NOMBRE as planta, deptos.NOMBRE as depto, super.NOMBRE as supervisor, " & _
    '                                                                                            "turnos.NOMBRE as turno, cod_motivo_disciplinario.NOMBRE as motivo, tipo_disciplinaria.TIPO_ACCION_DISCIPLINARIA, " & _
    '                                                                                            " accion_disciplinaria.FECHA, accion_disciplinaria.fecha_captura, " & _
    '                                                                                            "accion_disciplinaria.COMENT_SUPER, accion_disciplinaria.COMENT_EMPLEADO, accion_disciplinaria.cod_tipo_accion " & _
    '                                                                                            "from accion_disciplinaria " & _
    '                                                                                            "LEFT JOIN personalVW on accion_disciplinaria.reloj = personalVW.reloj " & _
    '                                                                                            "LEFT JOIN plantas on  accion_disciplinaria.COD_PLANTA = plantas.COD_PLANTA and accion_disciplinaria.COD_COMP = plantas.COD_COMP " & _
    '                                                                                            "LEFT JOIN deptos on accion_disciplinaria.COD_DEPTO = deptos.COD_DEPTO and accion_disciplinaria.COD_COMP = deptos.COD_COMP " & _
    '                                                                                            "LEFT JOIN super on accion_disciplinaria.COD_SUPER = super.COD_SUPER and accion_disciplinaria.COD_COMP = super.COD_COMP " & _
    '                                                                                            "LEFT JOIN turnos on accion_disciplinaria.COD_TURNO = turnos.COD_TURNO and accion_disciplinaria.COD_COMP = turnos.COD_COMP " & _
    '                                                                                            "LEFT JOIN cod_motivo_disciplinario on accion_disciplinaria.COD_MOTIVO = cod_motivo_disciplinario.COD_MOTIVO " & _
    '                                                                                            "LEFT JOIN tipo_disciplinaria on accion_disciplinaria.COD_TIPO_ACCION = tipo_disciplinaria.COD_TIPO_ACCION " & _
    '                                                                                            "LEFT JOIN cod_cat_disciplinaria on accion_disciplinaria.categoria = cod_cat_disciplinaria.cod_categoria " & _
    '                                                                                            "where folio ='" & folioDisciplinaria & "'"))
    '                frmVistaPrevia.ShowDialog()
    '                DisciplinarioIndividual = False
    '            End If

    '            If DisciplinarioGeneral = True Then
    '                frmVistaPrevia.LlamarReporte("Reporte disciplinario general", sqlExecute("select cod_cat_disciplinaria.nombre as categoria, accion_disciplinaria.folio, accion_disciplinaria.reloj, personalVW.nombres, accion_disciplinaria.cod_motivo, " & _
    '                                                                                            "plantas.NOMBRE as planta, deptos.NOMBRE as depto, super.NOMBRE as supervisor, " & _
    '                                                                                            "turnos.NOMBRE as turno, cod_motivo_disciplinario.NOMBRE as motivo, tipo_disciplinaria.TIPO_ACCION_DISCIPLINARIA, " & _
    '                                                                                            "accion_disciplinaria.FECHA, " & _
    '                                                                                            "accion_disciplinaria.COMENT_SUPER, accion_disciplinaria.COMENT_EMPLEADO " & _
    '                                                                                            "from accion_disciplinaria " & _
    '                                                                                            "LEFT JOIN personalVW on accion_disciplinaria.reloj = personalVW.reloj " & _
    '                                                                                            "LEFT JOIN plantas on  accion_disciplinaria.COD_PLANTA = plantas.COD_PLANTA and accion_disciplinaria.COD_COMP = plantas.COD_COMP " & _
    '                                                                                            "LEFT JOIN deptos on accion_disciplinaria.COD_DEPTO = deptos.COD_DEPTO and accion_disciplinaria.COD_COMP = deptos.COD_COMP " & _
    '                                                                                            "LEFT JOIN super on accion_disciplinaria.COD_SUPER = super.COD_SUPER and accion_disciplinaria.COD_COMP = super.COD_COMP " & _
    '                                                                                            "LEFT JOIN turnos on accion_disciplinaria.COD_TURNO = turnos.COD_TURNO and accion_disciplinaria.COD_COMP = turnos.COD_COMP " & _
    '                                                                                            "LEFT JOIN cod_motivo_disciplinario on accion_disciplinaria.COD_MOTIVO = cod_motivo_disciplinario.COD_MOTIVO " & _
    '                                                                                            "LEFT JOIN tipo_disciplinaria on accion_disciplinaria.COD_TIPO_ACCION = tipo_disciplinaria.COD_TIPO_ACCION " & _
    '                                                                                            "LEFT JOIN cod_cat_disciplinaria on accion_disciplinaria.categoria = cod_cat_disciplinaria.cod_categoria " & _
    '                                                                                            "where accion_disciplinaria.reloj = '" & txtReloj.Text & "'"))
    '                frmVistaPrevia.ShowDialog()
    '                DisciplinarioGeneral = False
    '            End If


    '            If DisciplinarioPDF = True Then
    '                Dim dttemp As DataTable = sqlExecute("select * from accion_disciplinaria where folio = '" & folioDisciplinaria & "'")


    '                If dttemp.Rows.Count > 0 Then
    '                    Dim savepath As String = IIf(IsDBNull(dttemp.Rows(0).Item("path_pdf")), "", dttemp.Rows(0).Item("path_pdf"))
    '                    If System.IO.File.Exists(savepath) Then
    '                        Dim File As New SaveFileDialog
    '                        Dim ruta_origen As String = ""
    '                        Dim ruta_destino As String = ""

    '                        File.Title = "Abrir..."
    '                        File.Filter = "PDF Files(*.pdf)|*.pdf|All Files(*.*)|*.*"
    '                        Dim rs As DialogResult = File.ShowDialog()

    '                        If rs = Windows.Forms.DialogResult.OK Then
    '                            ruta_origen = savepath
    '                            ruta_destino = File.FileName
    '                            My.Computer.FileSystem.CopyFile(ruta_origen, ruta_destino, True)
    '                        End If
    '                    Else
    '                        MessageBox.Show("Esta registro de accion disciplinaria no cuenta con un archivo PDF.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    End If
    '                Else

    '                End If
    '                DisciplinarioPDF = False
    '            End If

    '        Else
    '            MessageBox.Show("No hay informacion para generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If

    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
    '    End Try
    'End Sub
End Class