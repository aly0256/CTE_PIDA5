Imports System.IO

Public Class frmEvaluacionSolicitantes
    Dim dtPersonal As New DataTable
    Dim dtTemp As New DataTable
    Dim Editar As Boolean
    Dim sdAgregarEvaluacion As DevComponents.AdvTree.Node
    Dim Cargando As Boolean

    Dim FontBold = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
    Dim FontBold12 = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)

    Dim FontRegular = New Font("Microsoft Sans Serif", 9)
    Dim MaxWidth As Integer = 0

    Dim dtRangos As New DataTable
    Dim dtReloj As New DataTable

    Dim Campos As String
    Public HuboCambios As Boolean
    Dim dtVacantes As New DataTable     'Mantiene el registro actual


    Private Sub frmEvaluacionSolicitantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim P As Boolean = True
        Try
            txtVacante.Text = ""
            Campos = "Folio, rtrim(nombre)+' '+rtrim(SegundoNombre)+' '+rtrim(Paterno)+' '+rtrim(Materno) As nombres,cod_vac,FhaApli,ComentariosSupervisor,AprobadoSupervisor,DuracionSupervisor"

            'Configuración para panel de agregar evaluación
            sdAgregarEvaluacion = New DevComponents.AdvTree.Node
            sdAgregarEvaluacion.Text = "  AGREGAR EVALUACIÓN"
            sdAgregarEvaluacion.Name = "evaluacion"
            sdAgregarEvaluacion.Image = My.Resources.AddList32
            sdAgregarEvaluacion.FullRowBackground = True
            sdAgregarEvaluacion.Style = New DevComponents.DotNetBar.ElementStyle
            sdAgregarEvaluacion.Style.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
            sdAgregarEvaluacion.FullRowBackground = True

            'Estructura para tipio de respuesta RANGO
            dtRangos.Columns.Add("cod_pregunta")
            dtRangos.Columns.Add("identificador")
            dtRangos.Columns.Add("minimo")
            dtRangos.Columns.Add("maximo")

            dtReloj = sqlExecute("SELECT reloj, (rtrim(nombre) + ' ' + rtrim(apaterno)) as nombres from personalvw ORDER BY reloj")
            cmbReloj.DataSource = dtReloj
            cmbReloj.ValueMember = "reloj"
            cmbReloj.DisplayMembers = "reloj, nombres"

            MostrarInformacion("")
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub MostrarInformacion(ByVal folio As String)
        Try
            If folio = "" Then
                dtPersonal = sqlExecute("SELECT TOP 1 " & Campos & " FROM Candidatos ORDER BY Folio", "RECLUTAMIENTO")
                If dtPersonal.Rows.Count > 0 Then
                    folio = IIf(IsDBNull(dtPersonal.Rows.Item(0).Item("folio")), "", dtPersonal.Rows.Item(0).Item("folio"))
                End If
            End If
            If dtPersonal.Rows.Count > 0 Then
                With dtPersonal.Rows.Item(0)
                    txtFolio.Text = IIf(IsDBNull(.Item("Folio")), "", .Item("Folio"))
                    dtVacantes = sqlExecute("select Cod_Vac as 'CODIGO',Vacante as 'VACANTE' from vacantes where cod_vac = " & IIf(IsDBNull(.Item("cod_vac")), 0, .Item("cod_vac")) & " order by Vacante", "Reclutamiento")
                    If dtVacantes.Rows.Count > 0 Then
                        txtVacante.Text = dtVacantes.Rows(0).Item("Vacante")
                    End If
                    txtFechaAplica.Text = IIf(IsDBNull(.Item("FhaApli")), "", FechaSQL(.Item("FhaApli")))
                    txtNombre.Text = IIf(IsDBNull(.Item("nombres")), "", .Item("nombres"))
                    If IsDBNull(.Item("AprobadoSupervisor")) Then
                        swAprobado.CheckState = CheckState.Indeterminate
                        swAprobado.Text = "Pendiente"
                    ElseIf .Item("AprobadoSupervisor") = 1 Then
                        'swAprobado.Value = True
                        swAprobado.CheckState = CheckState.Checked
                        swAprobado.Text = "Aprobado"
                    Else
                        'swAprobado.Value = False
                        swAprobado.CheckState = CheckState.Unchecked
                        swAprobado.Text = "Rechazado"
                    End If
                    txtComentariosSupervisor.Text = IIf(IsDBNull(.Item("ComentariosSupervisor")), "", .Item("ComentariosSupervisor"))
                    clkCronometro.Value = IIf(IsDBNull(.Item("DuracionSupervisor")), "00:00:00", .Item("DuracionSupervisor").ToString)
                    clkCronometro.Update()
                End With
            End If
            dtTemp = sqlExecute("select entrevistador from RECLUTAMIENTO.dbo.evaluaciones_solicitantes where folio = '" & txtFolio.Text & "'")
            If dtTemp.Rows.Count > 0 Then
                cmbReloj.SelectedValue = IIf(IsDBNull(dtTemp.Rows(0).Item("entrevistador")), "", dtTemp.Rows(0).Item("entrevistador"))
            End If
            CrearEvaluaciones()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Proceso para crear nodos de las evaluaciones del empleado
    ''' </summary>
    Private Sub CrearEvaluaciones()
        Try
            Dim sdNodo As DevComponents.AdvTree.Node
            Cargando = True
            treEvaluaciones.Nodes.Clear()
            pnlCuestionario.Controls.Clear()
            pnlCuestionario.Refresh()

            Dim dtEvaluaciones As New DataTable
            Dim dtCuestionarios As New DataTable
            Dim dtPreguntas As New DataTable
            dtEvaluaciones = sqlExecute("SELECT DISTINCT evaluaciones_solicitantes.cod_evaluacion,nombre,cuestionarios,entrevistador " & _
                                        "FROM evaluaciones_solicitantes LEFT JOIN evaluaciones " & _
                                        "ON evaluaciones_solicitantes.cod_evaluacion = evaluaciones.cod_evaluacion and evaluaciones.filtro = 'Entrevista Supervisor' " & _
                                        "WHERE folio = '" & txtFolio.Text & "' ORDER BY evaluaciones_solicitantes.cod_evaluacion", "RECLUTAMIENTO")

            For Each dEval As DataRow In dtEvaluaciones.Rows
                sdNodo = CrearNodo(dEval)
                treEvaluaciones.Nodes.Add(sdNodo)
            Next

            'Agregar siempre el control para nuevas evaluaciones
            treEvaluaciones.Nodes.Add(sdAgregarEvaluacion)

            'Al terminar, refrescar el control para mostrar cambios
            treEvaluaciones.Refresh()
            treEvaluaciones.Nodes(0).Expand()
            If treEvaluaciones.Nodes(0).Nodes.Count >= 1 Then
                treEvaluaciones.Nodes(0).Nodes(0).Expand()
                CargarPreguntas(treEvaluaciones.Nodes(0).Name.Replace("eval", ""), treEvaluaciones.Nodes(0).Nodes(0).Name.Replace("cuest", ""))
            Else
                txtPromedio.Text = "0"
                HuboCambios = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Proceso para crear los nodos de los cuestionarios para la evaluación indicada
    ''' </summary>
    Private Function CrearNodo(dEval As DataRow) As DevComponents.AdvTree.Node
        Try
            Dim dtCuestionarios As New DataTable
            Dim Cuestionarios As String
            Dim sdNodoCuest As DevComponents.AdvTree.Node
            Dim sdNodo As New DevComponents.AdvTree.Node
            'sdNodo.Text = "  " & dEval("cod_evaluacion") & vbCrLf & "  " & dEval("nombre").ToString.Trim
            sdNodo.Text = dEval("nombre").ToString.Trim
            sdNodo.Name = "eval" & dEval("cod_evaluacion")
            sdNodo.Style = New DevComponents.DotNetBar.ElementStyle
            sdNodo.Style.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
            sdNodo.FullRowBackground = True
            Cuestionarios = IIf(IsDBNull(dEval("cuestionarios")), "", dEval("cuestionarios").ToString.Trim)
            Cuestionarios = Cuestionarios.Replace(",", "','")
            Cuestionarios = "'" & Cuestionarios & "'"
            dtCuestionarios = sqlExecute("SELECT cod_cuestionario,nombre FROM cuestionarios " & _
                                         "WHERE cod_cuestionario IN (" & Cuestionarios & ")", "RECLUTAMIENTO")
            For Each dCuest As DataRow In dtCuestionarios.Rows
                sdNodoCuest = New DevComponents.AdvTree.Node
                sdNodoCuest.Text = dCuest("nombre").ToString.Trim
                sdNodoCuest.Name = "cuest" & dCuest("cod_cuestionario")
                sdNodoCuest.FullRowBackground = True
                sdNodo.Nodes.Add(sdNodoCuest)
            Next
            Return sdNodo
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            Return New DevComponents.AdvTree.Node
        End Try
    End Function

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Dim msg As System.Windows.Forms.DialogResult = Windows.Forms.DialogResult.Yes
        Try
            If HuboCambios Then
                msg = MessageBox.Show("¿Desea guardar los cambios antes de continuar?", "¿Guardar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msg = Windows.Forms.DialogResult.Yes Then
                    btnGuardar.PerformClick()
                End If
            End If
            Dim folio As String
            folio = txtFolio.Text
            dtPersonal = sqlExecute("SELECT TOP 1 " & Campos & " FROM Candidatos ORDER BY folio ASC", "RECLUTAMIENTO")
            If dtPersonal.Rows.Count > 0 Then
                folio = dtPersonal.Rows.Item(0).Item("FOLIO")
                MostrarInformacion(folio)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Dim msg As System.Windows.Forms.DialogResult = Windows.Forms.DialogResult.Yes
        Try
            If HuboCambios Then
                msg = MessageBox.Show("¿Desea guardar los cambios antes de continuar?", "¿Guardar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msg = Windows.Forms.DialogResult.Yes Then
                    btnGuardar.PerformClick()
                End If
            End If
            Dim folio As String
            folio = txtFolio.Text
            dtPersonal = sqlExecute("SELECT TOP 1 " & Campos & " FROM Candidatos WHERE folio <'" & folio & "' ORDER BY folio DESC", "RECLUTAMIENTO")
            If dtPersonal.Rows.Count < 1 Then
                btnFirst.PerformClick()
            Else
                folio = dtPersonal.Rows.Item(0).Item("FOLIO")

                MostrarInformacion(folio)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim msg As System.Windows.Forms.DialogResult = Windows.Forms.DialogResult.Yes
        Try
            If HuboCambios Then
                msg = MessageBox.Show("¿Desea guardar los cambios antes de continuar?", "¿Guardar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msg = Windows.Forms.DialogResult.Yes Then
                    btnGuardar.PerformClick()
                End If
            End If
            Dim folio As String
            folio = txtFolio.Text
            dtPersonal = sqlExecute("SELECT TOP 1 " & Campos & " FROM Candidatos WHERE folio >'" & folio & "' ORDER BY folio ASC", "RECLUTAMIENTO")
            If dtPersonal.Rows.Count < 1 Then
                btnLast.PerformClick()
            Else
                folio = dtPersonal.Rows.Item(0).Item("FOLIO")
                MostrarInformacion(folio)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Dim msg As System.Windows.Forms.DialogResult = Windows.Forms.DialogResult.Yes
        Try
            If HuboCambios Then
                msg = MessageBox.Show("¿Desea guardar los cambios antes de continuar?", "¿Guardar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msg = Windows.Forms.DialogResult.Yes Then
                    btnGuardar.PerformClick()
                End If
            End If
            Dim folio As String
            folio = txtFolio.Text
            dtPersonal = sqlExecute("SELECT TOP 1 " & Campos & " FROM Candidatos ORDER BY folio DESC", "RECLUTAMIENTO")
            If dtPersonal.Rows.Count > 0 Then
                folio = dtPersonal.Rows.Item(0).Item("FOLIO")
                MostrarInformacion(folio)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtTemp = dtPersonal
        Dim msg As System.Windows.Forms.DialogResult = Windows.Forms.DialogResult.Yes
        Try
            If HuboCambios Then
                msg = MessageBox.Show("¿Desea guardar los cambios antes de continuar?", "¿Guardar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msg = Windows.Forms.DialogResult.Yes Then
                    btnGuardar.PerformClick()
                End If
            End If
            frmBuscarFolio.ShowDialog(Me)
            If Folio <> "CANCEL" Then
                dtPersonal = sqlExecute("SELECT " & Campos & " FROM Candidatos WHERE folio ='" & Folio & "'", "RECLUTAMIENTO")
                If dtPersonal.Rows.Count > 0 Then
                    MostrarInformacion(Folio)
                Else
                    MessageBox.Show("El solicitante con folio " & Folio & " no fue localizado.", "Solicitante no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtPersonal = dtTemp
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dim msg As System.Windows.Forms.DialogResult = Windows.Forms.DialogResult.Yes
        If HuboCambios Then
            msg = MessageBox.Show("¿Desea guardar los cambios antes de continuar?", "¿Guardar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msg = Windows.Forms.DialogResult.Yes Then
                btnGuardar.PerformClick()
            End If
        End If
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs)
        Try
            If Not Editar Then
                Editar = True
                txtFolio.Focus()

            Else
                Editar = False

                'ActualizaInformacionTA()
            End If
            HabilitarBotones()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HabilitarBotones()
        Try
            'Dim SI As Integer
            btnFirst.Enabled = Not Editar
            btnPrev.Enabled = Not Editar
            btnNext.Enabled = Not Editar
            btnLast.Enabled = Not Editar

            btnBuscar.Enabled = Not Editar
            btnCerrar.Enabled = Not Editar

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Public Sub NuevaEvaluacion()
        Try
            Dim NewEval As New DevComponents.AdvTree.Node
            NewEval = AgregaEvaluacion()
            If Not NewEval Is Nothing Then
                treEvaluaciones.CollapseAll()
                NewEval.Expand()
                If NewEval.Nodes.Count > 0 Then
                    NewEval.Nodes(0).Expand()
                    CargarPreguntas(NewEval.Name.Replace("eval", ""), NewEval.Nodes(0).Name.Replace("cuest", ""))
                End If
            End If
            treEvaluaciones.Refresh()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub
    Public Sub CargarPreguntas(ByVal CodEvaluacion As String, ByVal CodCuestionario As String)
        Try
            Dim i As Integer
            Dim j As Integer
            Dim v As Integer
            Dim r As Integer
            Dim arRespuestas() As String
            Dim RespuestaEmpleado As String
            Dim CalifMinima As String
            Dim Titulo As Boolean
            Dim dtPreguntas As New DataTable
            Dim dtRespuestas As New DataTable
            Dim dtResEmp As New DataTable
            'Controles generales a todas las preguntas
            Dim lblPregunta As Windows.Forms.Label
            Dim pnlPregunta As Windows.Forms.Panel

            If CodCuestionario.Contains("#") Then
                i = CodCuestionario.IndexOf("#")
                CodCuestionario = CodCuestionario.Substring(0, i)
            End If
            Cargando = True
            dtPreguntas = sqlExecute("SELECT preguntas.*,seleccion_multiple,opciones,estilo FROM preguntas LEFT JOIN respuestas " & _
                                     "ON preguntas.cod_respuesta = respuestas.cod_respuesta WHERE cod_cuestionario = '" & CodCuestionario & _
                                     "' ORDER BY ubicacion", "RECLUTAMIENTO")
            'Limpiar el panel de controles anteriores
            pnlCuestionario.Visible = False
            My.Application.DoEvents()
            pnlCuestionario.Controls.Clear()
            pnlCuestionario.Tag = CodEvaluacion.Trim & "#" & CodCuestionario.Trim
            i = 0
            'Inicializar el ancho máximo de acuerdo al panel
            MaxWidth = pnlCuestionario.Width
            For Each dPreg As DataRow In dtPreguntas.Rows
                dtResEmp = sqlExecute("SELECT respuesta FROM respuestas_solicitantes WHERE folio = '" & txtFolio.Text & _
                                      "' AND cod_pregunta = '" & dPreg("cod_pregunta") & _
                                      "' AND cod_evaluacion = '" & CodEvaluacion.Replace("cuest", "") & _
                                      "' AND cod_cuestionario = '" & CodCuestionario.Replace("cuest", "") & "'", "RECLUTAMIENTO")
                If dtResEmp.Rows.Count > 0 Then
                    RespuestaEmpleado = IIf(IsDBNull(dtResEmp.Rows(0).Item("respuesta")), Nothing, dtResEmp.Rows(0).Item("respuesta"))
                Else
                    RespuestaEmpleado = Nothing
                End If
                Titulo = IIf(IsDBNull(dPreg("titulo")), 0, dPreg("titulo"))
                'Arreglo de las respuestas
                arRespuestas = dPreg("opciones").ToString.Trim.Split(vbCrLf)
                'Crear un panel por cada pregunta, para contener sus respuestas
                'El tag del panel es el número de pregunta, para identificación
                pnlPregunta = New Panel
                pnlPregunta.Parent = pnlCuestionario
                pnlPregunta.Size = New Size(IIf(pnlCuestionario.Width < 1000, 1000, pnlCuestionario.Width - 5), 30)
                pnlPregunta.Location = New Point(0, i)
                pnlPregunta.BackColor = IIf(Titulo, SystemColors.ActiveCaption, SystemColors.Window)
                pnlPregunta.BorderStyle = BorderStyle.None
                pnlPregunta.Name = "preg" & dPreg("cod_pregunta")
                pnlPregunta.Tag = IIf(IsDBNull(dPreg("calificacion_minima")), 0, dPreg("calificacion_minima"))
                CalifMinima = pnlPregunta.Tag
                'Manejo del mouse para uso del wheel
                AddHandler pnlPregunta.MouseEnter, AddressOf pnlCuestionario_MouseEnter
                'Etiqueta con la pregunta
                'Ubicación, negritas y color de fondo cambian si es título
                'El tag de la pregunta es la calificación mínima, para revisión
                lblPregunta = New Windows.Forms.Label
                lblPregunta.BackColor = IIf(Titulo, SystemColors.ActiveCaption, SystemColors.Window)
                lblPregunta.Text = dPreg("pregunta").ToString.Trim
                lblPregunta.Left = IIf(Titulo, 10, 30)
                lblPregunta.Top = 5
                lblPregunta.Font = IIf(Titulo, FontBold, FontRegular)
                lblPregunta.AutoSize = False
                lblPregunta.Width = IIf(Titulo, pnlCuestionario.Width - 20, 500)
                lblPregunta.Tag = IIf(IsDBNull(dPreg("calificacion_minima")), 0, dPreg("calificacion_minima"))
                lblPregunta.Parent = pnlPregunta
                If Not Titulo Then
                    Select Case dPreg("estilo").ToString.Trim
                        Case "LOGICO"
                            Dim chkLogico As DevComponents.DotNetBar.Controls.CheckBoxX

                            j = 0
                            r = 1
                            For Each Resp In arRespuestas
                                chkLogico = New DevComponents.DotNetBar.Controls.CheckBoxX
                                chkLogico.Parent = pnlPregunta
                                chkLogico.Left = 600 + j
                                chkLogico.Top = 5
                                chkLogico.BackColor = SystemColors.Window
                                chkLogico.Text = Resp.Trim
                                chkLogico.Width = 50
                                chkLogico.Height = 20
                                chkLogico.Visible = True
                                chkLogico.TextColor = SystemColors.WindowText
                                chkLogico.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
                                chkLogico.Tag = r
                                AddHandler chkLogico.CheckedChanged, AddressOf BanderaCambios
                                If MaxWidth < chkLogico.Width + chkLogico.Left Then
                                    MaxWidth = chkLogico.Width + chkLogico.Left
                                End If
                                j += 75
                                'Contestar con respuesta de empleado
                                If Not IsNothing(RespuestaEmpleado) Then
                                    chkLogico.Checked = (Resp.Trim = RespuestaEmpleado.Trim)
                                End If
                                r -= 1
                            Next
                        Case "NUMERICO"
                            Dim txtNumerico As New DevComponents.Editors.IntegerInput
                            txtNumerico.Parent = pnlPregunta
                            txtNumerico.ShowUpDown = True
                            txtNumerico.Left = 600
                            txtNumerico.Top = 5
                            txtNumerico.Width = 60
                            txtNumerico.Height = 25
                            txtNumerico.MinValue = arRespuestas(0)
                            txtNumerico.MaxValue = arRespuestas(1)
                            txtNumerico.Increment = Int(txtNumerico.MaxValue / 10)
                            txtNumerico.Value = lblPregunta.Tag
                            AddHandler txtNumerico.ValueChanged, AddressOf BanderaCambios
                            If MaxWidth < txtNumerico.Width + txtNumerico.Left Then
                                MaxWidth = txtNumerico.Width + txtNumerico.Left
                            End If
                            'Contestar con respuesta de empleado
                            If Not IsNothing(RespuestaEmpleado) Then
                                txtNumerico.Value = CInt(RespuestaEmpleado)
                            End If
                        Case "NIVEL"
                            Dim stpClasificacion As New DevComponents.DotNetBar.ProgressSteps
                            'Este control solicita licencia (en ocasiones)
                            'stpClasificacion.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
                            Dim stpNivel As New DevComponents.DotNetBar.StepItem
                            Dim Op As String
                            Dim Val As Integer
                            Dim ID As Integer = 0
                            Dim n As Integer
                            'Este control requiere mayor altura
                            'el contador i hay que incrementarlo, para que el siguiente panel se ajuste
                            pnlPregunta.Height = 40
                            i += 10
                            stpClasificacion.Parent = pnlPregunta
                            stpClasificacion.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
                            stpClasificacion.BackgroundStyle.Class = "ProgressSteps"
                            stpClasificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
                            stpClasificacion.ContainerControlProcessDialogKey = True
                            stpClasificacion.Location = New System.Drawing.Point(600, 2)
                            stpClasificacion.Name = "stpClasificacion"
                            stpClasificacion.Size = New System.Drawing.Size(551, 35)
                            stpClasificacion.TabIndex = 1
                            AddHandler stpClasificacion.ItemClick, AddressOf Nivel_Click
                            n = 0
                            For Each Opcion In arRespuestas
                                n += 1
                                stpNivel = New DevComponents.DotNetBar.StepItem
                                v = Opcion.ToUpper.IndexOf("&V")
                                If v < 0 Then
                                    Op = Opcion.Trim
                                    Val = 0
                                Else
                                    Op = Opcion.Substring(0, v).Trim
                                    Val = Opcion.Substring(v + 2)
                                End If
                                stpNivel.Text = Op
                                stpNivel.Padding.All = 10
                                stpNivel.TextColor = SystemColors.ControlText
                                stpClasificacion.Items.Add(stpNivel)
                                'Contestar con respuesta de empleado
                                If Not IsNothing(RespuestaEmpleado) Then
                                    If stpNivel.Text = RespuestaEmpleado.Trim Then
                                        Nivel_Click(stpNivel, Nothing)
                                    End If
                                Else
                                    If n <= CalifMinima Then
                                        Nivel_Click(stpNivel, Nothing)
                                    End If
                                End If
                            Next
                            stpClasificacion.Refresh()
                            If MaxWidth < stpClasificacion.Width + stpClasificacion.Left Then
                                MaxWidth = stpClasificacion.Width + stpClasificacion.Left
                            End If
                        Case "RANGO"
                            Dim txtRango As New DevComponents.Editors.IntegerInput
                            Dim lblRango As New Windows.Forms.Label

                            txtRango.Parent = pnlPregunta
                            txtRango.ShowUpDown = True
                            txtRango.Left = 600
                            txtRango.Top = 5
                            txtRango.Width = 60
                            txtRango.Height = 25
                            lblRango.Parent = pnlPregunta
                            lblRango.Left = txtRango.Left + txtRango.Width + 1
                            lblRango.Top = 5
                            lblRango.Width = 50
                            lblRango.Height = 25
                            lblRango.AutoSize = True
                            lblRango.Text = ""
                            lblRango.BackColor = SystemColors.Highlight
                            lblRango.ForeColor = SystemColors.HighlightText
                            lblRango.Font = FontBold12

                            Dim Op As String
                            Dim Val As String
                            Dim ValMin As Integer
                            Dim ValMax As Integer
                            Dim Minimo As Integer = 0
                            Dim Maximo As Integer = 0

                            For Each Opcion In arRespuestas
                                If Opcion.Length > 5 Then
                                    v = Opcion.ToUpper.IndexOf("&V")
                                    If v < 0 Then
                                        Op = Opcion.Trim
                                        Val = 0
                                    Else
                                        Op = Opcion.Substring(0, v).Trim
                                        Val = Opcion.Substring(v + 2)

                                        v = Val.IndexOf("-")
                                        If v < 0 Or v = Val.Length - 1 Then
                                            ValMin = 0
                                            ValMax = 0
                                        Else
                                            ValMin = Val.Substring(0, v)
                                            ValMax = Val.Substring(v + 1)
                                        End If
                                    End If
                                    If Minimo > ValMin Then Minimo = ValMin
                                    If Maximo < ValMax Then Maximo = ValMax
                                    dtRangos.Rows.Add({dPreg("cod_pregunta"), Op, ValMin, ValMax})
                                End If
                            Next
                            txtRango.MinValue = Minimo
                            txtRango.MaxValue = Maximo
                            txtRango.Increment = Int(Maximo / 10)
                            txtRango.Value = lblPregunta.Tag
                            AddHandler txtRango.ValueChanged, AddressOf CambioRango
                            If MaxWidth < lblRango.Width + lblRango.Left Then
                                MaxWidth = lblRango.Width + lblRango.Left
                            End If
                            'Contestar con respuesta de empleado
                            If Not IsNothing(RespuestaEmpleado) Then
                                txtRango.Value = CInt(RespuestaEmpleado)
                                'CambioRango(txtRango, Nothing)
                            End If
                        Case "OPCION MULTIPLE"
                            Dim chkLogico As DevComponents.DotNetBar.Controls.CheckBoxX
                            Dim Op As String
                            Dim Val As Integer
                            Dim Respuestas() As String

                            j = 0
                            For Each Resp In arRespuestas
                                v = Resp.ToUpper.IndexOf("&V")
                                If Resp.Length >= v + 2 Then
                                    Op = Resp.Substring(0, v).Trim
                                    If Resp.Substring(v + 2) = "" Then
                                        Val = 0
                                    Else
                                        Val = Resp.Substring(v + 2)
                                    End If
                                    chkLogico = New DevComponents.DotNetBar.Controls.CheckBoxX
                                    chkLogico.Parent = pnlPregunta
                                    chkLogico.Left = 600
                                    chkLogico.Top = 5 + j
                                    chkLogico.BackColor = SystemColors.Window
                                    chkLogico.Text = Op.Trim
                                    chkLogico.Tag = Val
                                    chkLogico.Width = 50
                                    chkLogico.Height = 20
                                    chkLogico.Visible = True
                                    chkLogico.TextColor = SystemColors.WindowText
                                    chkLogico.AutoSize = True
                                    'chkLogico.Anchor = AnchorStyles.Left
                                    AddHandler chkLogico.CheckedChanged, AddressOf BanderaCambios
                                    If dPreg("seleccion_multiple") Then
                                        chkLogico.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox
                                    Else
                                        chkLogico.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
                                    End If
                                    If MaxWidth < chkLogico.Width + chkLogico.Left Then
                                        MaxWidth = chkLogico.Width + chkLogico.Left
                                    End If
                                    j += (chkLogico.Height + 5)
                                    i += 20
                                    pnlPregunta.Height += 20
                                    'Contestar con respuesta de empleado
                                    If Not IsNothing(RespuestaEmpleado) Then
                                        Respuestas = RespuestaEmpleado.Trim.Split(vbCrLf)
                                        For Each Rpt In Respuestas
                                            If chkLogico.Text = Rpt.Trim Then
                                                chkLogico.Checked = True
                                                Exit For
                                            End If
                                        Next
                                    End If
                                End If

                            Next
                    End Select
                End If
                i += 30
            Next
            For Each pnl As Panel In pnlCuestionario.Controls
                pnl.Width = IIf(pnlCuestionario.Width < MaxWidth, MaxWidth, pnlCuestionario.Width) - 5
            Next
            HuboCambios = False
            Cargando = False
            RevisaRespuestas()
            pnlCuestionario.Refresh()
            pnlCuestionario.Visible = True
            My.Application.DoEvents()
        Catch ex As Exception
            HuboCambios = False
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub GuardarRespuestas(ByVal Codigo As String)
        Try
            Dim Respuesta As String
            Dim CodEvaluacion As String
            Dim CodCuestionario As String
            Dim dtRespuesta As New DataTable

            CodEvaluacion = Codigo.Split("#")(0)
            CodCuestionario = Codigo.Split("#")(1)
            For Each pnlPregunta In pnlCuestionario.Controls
                Respuesta = ""
                For Each ctlPreg In pnlPregunta.Controls
                    If TypeOf ctlPreg Is DevComponents.DotNetBar.Controls.CheckBoxX Then
                        If ctlPreg.checked Then
                            Respuesta = Respuesta & IIf(Respuesta.Trim.Length > 0, vbCrLf, "") & ctlPreg.text
                        End If
                    ElseIf TypeOf ctlPreg Is DevComponents.Editors.IntegerInput Then
                        Respuesta = ctlPreg.value
                    ElseIf TypeOf ctlPreg Is DevComponents.DotNetBar.ProgressSteps Then
                        For Each stp As DevComponents.DotNetBar.StepItem In ctlPreg.items
                            If stp.Value = 100 Then
                                Respuesta = stp.Text
                            End If
                        Next
                    End If
                Next
                If Respuesta.Length > 0 Then
                    dtRespuesta = sqlExecute("SELECT respuesta FROM respuestas_solicitantes WHERE folio = '" & txtFolio.Text & _
                             "' AND cod_evaluacion = '" & CodEvaluacion & _
                             "' AND cod_pregunta = '" & pnlPregunta.name.replace("preg", "") & _
                             "' AND cod_cuestionario = '" & CodCuestionario & _
                             "'", "RECLUTAMIENTO")
                    If dtRespuesta.Rows.Count > 0 Then
                        sqlExecute("UPDATE respuestas_solicitantes SET respuesta = '" & Respuesta & "'  WHERE folio = '" & txtFolio.Text & _
                             "' AND cod_evaluacion = '" & CodEvaluacion & _
                             "' AND cod_pregunta = '" & pnlPregunta.name.replace("preg", "") & _
                             "' AND cod_cuestionario = '" & CodCuestionario & _
                             "'", "RECLUTAMIENTO")
                    Else
                        sqlExecute("INSERT INTO respuestas_solicitantes (folio,cod_evaluacion,cod_pregunta,cod_cuestionario,respuesta) VALUES ('" & _
                                   txtFolio.Text & "','" & CodEvaluacion & "','" & pnlPregunta.name.replace("preg", "") & "','" & _
                                   CodCuestionario & "','" & Respuesta & "')", "RECLUTAMIENTO")
                    End If
                End If
                'lnSeparador = New DevComponents.DotNetBar.Controls.Line
                'lnSeparador.Parent = pnlPregunta
                'lnSeparador.Height = 1
                'lnSeparador.Dock = DockStyle.Bottom
                'lnSeparador.ForeColor = SystemColors.ControlDark
                'lnSeparador.DashStyle = Drawing2D.DashStyle.Dot
                'i += 30
            Next
            HuboCambios = False
        Catch ex As Exception
            HuboCambios = False
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub Nivel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim stpNivel As New DevComponents.DotNetBar.StepItem
        Try
            For Each stpNivel In sender.ContainerControl.items
                If stpNivel.Id <= sender.id Then
                    stpNivel.Value = 100
                Else
                    stpNivel.Value = 0
                End If
            Next

            If Not Cargando Then RevisaRespuestas()
            HuboCambios = True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub CambioRango(sender As Object, e As EventArgs)
        Dim Preg As String
        Dim dRow() As DataRow
        Try
            Preg = sender.parent.name.ToString.Replace("preg", "")

            dRow = dtRangos.Select("cod_pregunta = '" & Preg & "' AND minimo<= " & sender.value & " AND maximo >= " & sender.value)
            For Each lbl As Control In sender.parent.controls
                If TypeOf lbl Is Windows.Forms.Label Then
                    If lbl.BackColor <> SystemColors.Window Then
                        lbl.Text = " " & dRow(0).Item("identificador") & " "
                    End If
                End If
            Next
            HuboCambios = True
            RevisaRespuestas()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            HuboCambios = True
        End Try
    End Sub

    Private Sub AgregarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem1.Click
        NuevaEvaluacion()
    End Sub

    Private Function AgregaEvaluacion() As DevComponents.AdvTree.Node
        Dim CodEval As String
        Dim ArCuestionarios() As String
        Dim C As String
        Dim dtEvaluacion As New DataTable
        Try
            strRespuesta = txtFolio.Text
            If frmAgregarEvaluacionReclutamiento.ShowDialog("Entrevista Supervisor") = Windows.Forms.DialogResult.OK Then
                Dim sdNodo As DevComponents.AdvTree.Node
                CodEval = strRespuesta

                dtEvaluacion = sqlExecute("SELECT cod_evaluacion,nombre,cuestionarios FROM evaluaciones WHERE cod_evaluacion = '" & _
                                          CodEval & "'", "RECLUTAMIENTO")
                If dtEvaluacion.Rows.Count > 0 Then
                    C = IIf(IsDBNull(dtEvaluacion.Rows(0).Item("cuestionarios")), "", dtEvaluacion.Rows(0).Item("cuestionarios"))
                    ArCuestionarios = C.Trim.Split(",")
                    For Each C In ArCuestionarios
                        C = C.Replace("'", "")

                        sqlExecute("INSERT INTO evaluaciones_solicitantes (folio,cod_evaluacion,cod_cuestionario,entrevistador)" & _
                                   "VALUES ('" & txtFolio.Text & "','" & CodEval & "','" & C & "','" & Split(cmbReloj.Text, ",")(0) & "')", "RECLUTAMIENTO")
                    Next
                    sdNodo = CrearNodo(dtEvaluacion.Rows(0))
                    treEvaluaciones.Nodes.Insert(treEvaluaciones.Nodes.Count - 1, sdNodo)
                    treEvaluaciones.Refresh()
                    btnFirst.Enabled = False
                    btnPrev.Enabled = False
                    btnNext.Enabled = False
                    btnLast.Enabled = False
                    btnBuscar.Enabled = False
                    clkCronometro.Value = "00:00:00"
                    Timer1.Start()
                    Return sdNodo
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub BorrarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem1.Click
        Dim dtEvalEmp As New DataTable
        Dim Evaluacion As New devcomponents.advtree.node
        Dim CodEvaluacion As String
        Dim CodCuestionario As String
        Dim Codigo As String
        Dim Borra As Boolean = True
        Try
            Evaluacion = treEvaluaciones.SelectedNode
            If Evaluacion Is Nothing Then Exit Sub
            Codigo = pnlCuestionario.Tag
            If Codigo.Contains("#") Then
                CodEvaluacion = Codigo.Split("#")(0)
                CodCuestionario = Codigo.Split("#")(1)
            Else
                CodCuestionario = ""
                CodEvaluacion = Codigo
            End If
            If Borra Then
                If MessageBox.Show("¿Está seguro de querer borrar la evaluación " & Evaluacion.Text & _
                                   " del empleado con número de folio " & txtFolio.Text & "?", "Borrar evaluación", _
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    sqlExecute("DELETE FROM evaluaciones_solicitantes WHERE folio = '" & txtFolio.Text & _
                               "' AND cod_evaluacion = '" & CodEvaluacion & "'", "RECLUTAMIENTO")
                    Evaluacion.Parent.Nodes.Remove(Evaluacion)
                    'treEvaluaciones.Nodes.Remove(Evaluacion)
                    treEvaluaciones.Refresh()
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try

    End Sub

    Private Sub treEvaluaciones_MouseEnter(sender As Object, e As EventArgs) Handles treEvaluaciones.MouseEnter
        treEvaluaciones.Select()
    End Sub

    Private Sub treEvaluaciones_NodeClick(sender As Object, e As DevComponents.AdvTree.TreeNodeMouseEventArgs) Handles treEvaluaciones.NodeClick
        Dim SelNode As New DevComponents.AdvTree.Node
        Static AntNode As New DevComponents.AdvTree.Node
        Dim GuardarCambios As Windows.Forms.DialogResult
        Try
            'Nodo seleccionado
            SelNode = treEvaluaciones.SelectedNode
            'Si no hay nodo seleccionado, salir del procedimiento
            If SelNode Is Nothing Then Exit Sub

            'Si se activó la bandera de que HuboCambios...
            If HuboCambios Then
                GuardarCambios = MessageBox.Show("¿Desea guardar los cambios antes de continuar? " & vbCrLf & "Si elige <NO>, se perderán.", "Cambiar pregunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                If GuardarCambios = Windows.Forms.DialogResult.Yes Then
                    'Al seleccionar "YES", llamar el clic del botón para guardar
                    btnGuardar.PerformClick()
                ElseIf GuardarCambios = Windows.Forms.DialogResult.Cancel Then
                    'Si seleccionan "CANCEL", seleccionar el nodo anterior antes de salir
                    'El anterior es antes de que se presionara clic, el cuestionario en que estaban trabajando
                    SelNode = AntNode
                    treEvaluaciones.SelectedNode = SelNode
                    Exit Sub
                End If

                'Si seleccionan no, ignorar cambios y continuar
            End If

            If SelNode.Name = "evaluacion" Then
                'Si el nodo es el de "AGREGAR EVALUACION"
                'solicitar nueva evaluación
                NuevaEvaluacion()
            ElseIf SelNode.Name.Contains("eval") Then
                'Si se seleccionó una evaluación, colapsar todas las demás (para identificar la seleccionada)
                treEvaluaciones.CollapseAll()

                'Expander el nodo seleccionado y su primer cuestionario
                SelNode.Expand()
                SelNode.Nodes(0).SetSelectedCell(SelNode.Nodes(0).Cells(0), DevComponents.AdvTree.eTreeAction.Code)
                'Cargar las preguntas del primer cuestionario
                CargarPreguntas(SelNode.Name.Replace("eval", ""), SelNode.Nodes(0).Name.Replace("cuest", ""))
            ElseIf SelNode.Name.Contains("cuest") Then
                'Cargar las preguntas del cuestionario seleccionado
                CargarPreguntas(SelNode.Parent.Name.Replace("eval", ""), SelNode.Name.Replace("cuest", ""))
            ElseIf SelNode.Name.Contains("recert") Then
                CargarPreguntas(SelNode.Parent.Parent.Name.Replace("eval", ""), SelNode.Name.Replace("recert", ""))
            Else
                'Ante cualquier otra circunstancia, simplemente quitar todos los controles del panel de preguntas
                pnlCuestionario.Controls.Clear()
            End If
            'Igualar el nodo anterior como el seleccionado
            AntNode = SelNode
            pnlCuestionario.Refresh()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub treEvaluaciones_Click(sender As Object, e As EventArgs) Handles treEvaluaciones.Click

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim SelNode As New DevComponents.AdvTree.Node
        Try
            If MessageBox.Show("¿Está seguro de guardar los cambios? ", "¿Guardar cambios?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                'GuardarRespuestas(pnlCuestionario.Tag)
                If evaluar() Then
                    Timer1.Stop()
                    sqlExecute("Update reclutamiento.dbo.Candidatos set DuracionSupervisor = '" & clkCronometro.Value.TimeOfDay.ToString & "' where folio = '" & txtFolio.Text.Trim & "'", "RECLUTAMIENTO")
                    btnFirst.Enabled = True
                    btnPrev.Enabled = True
                    btnNext.Enabled = True
                    btnLast.Enabled = True
                    btnBuscar.Enabled = True
                    MsgBox("La informacion del solicitante fue actualizada satisfactoriamente. " & Environment.NewLine & Environment.NewLine & "Favor de verificar la aprobacion del candidato.", MsgBoxStyle.Information, "Información")
                Else
                    MsgBox("Faltaron preguntas por responder. ", MsgBoxStyle.Exclamation, "Entrevista del supervisor.")
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub BanderaCambios(sender As Object, e As EventArgs)
        HuboCambios = True
        RevisaRespuestas()
    End Sub

    Private Sub RevisaRespuestas()
        Dim CalMin As String
        Dim ttl As Integer = 0
        Dim Suma As Integer = 0
        Dim p As Integer = 0
        Dim i As Integer = 0
        Dim Calificacion As Integer
        If Not Cargando Then
            txtPromedio.Text = "0"
            Try
                For Each pnl In pnlCuestionario.Controls
                    If pnl.controls.count > 1 Then
                        'Si solo tiene un control, es solo título, y no cuenta para promedio
                        p += 1
                    End If
                    If pnl.tag Is Nothing Then
                        CalMin = 0
                    Else
                        CalMin = pnl.tag
                    End If
                    For Each ctl In pnl.controls
                        If TypeOf ctl Is DevComponents.DotNetBar.Controls.CheckBoxX Then
                            If ctl.checkboxstyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton Then
                                If ctl.checked Then
                                    If ctl.tag = -1 Then
                                        'Si el tag es -1, quiere decir que no aplica
                                        'por tanto, disminuir en 1 el número de preguntas para no afectar promedio
                                        p -= 1
                                    Else
                                        Calificacion += ctl.tag
                                    End If
                                End If
                            Else
                                For Each opt In ctl.parent.controls
                                    If TypeOf opt Is DevComponents.DotNetBar.Controls.CheckBoxX Then
                                        If opt.Checked Then
                                            ttl = ttl + CInt(opt.Tag)
                                        End If
                                    End If
                                Next
                                Calificacion += ttl

                            End If
                        ElseIf TypeOf ctl Is DevComponents.Editors.IntegerInput Then
                            Calificacion += ctl.value
                        ElseIf TypeOf ctl Is DevComponents.DotNetBar.ProgressSteps Then
                            ttl = 0
                            For Each stpNivel In ctl.items
                                If stpNivel.value = 100 Then
                                    ttl += 1
                                End If
                            Next
                            Calificacion += ttl
                        End If
                    Next
                    'Suma += Calificacion
                Next
                txtPromedio.Text = Math.Round(Calificacion / p, 2)
            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            End Try
        End If

    End Sub

    Private Sub pnlCuestionario_Resize(sender As Object, e As EventArgs) Handles pnlCuestionario.Resize
        Try
            For Each pnl As Panel In pnlCuestionario.Controls
                pnl.Width = IIf(pnlCuestionario.Width < MaxWidth, MaxWidth, pnlCuestionario.Width) - 5
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Function evaluar() As Boolean
        Dim dtCuestionario As New DataTable
        Dim Promediar As Boolean
        Dim CodEvaluacion As String
        Dim CodCuestionario As String
        Dim Codigo As String
        Dim strQry As String
        Dim respuestas As Integer = 0
        Dim preguntas As Integer = 0
        Try
            Codigo = pnlCuestionario.Tag
            If Codigo.Contains("#") Then
                CodEvaluacion = Codigo.Split("#")(0)
                CodCuestionario = Codigo.Split("#")(1)
            Else
                CodCuestionario = ""
                CodEvaluacion = Codigo
            End If
            GuardarRespuestas(pnlCuestionario.Tag)
            RevisaRespuestas()
            dtCuestionario = sqlExecute("SELECT promediar FROM cuestionarios WHERE cod_cuestionario = '" & CodCuestionario & "'", "RECLUTAMIENTO")
            If dtCuestionario.Rows.Count = 0 Then
            Else
                Promediar = IIf(IsDBNull(dtCuestionario.Rows(0).Item("promediar")), 0, dtCuestionario.Rows(0).Item("promediar"))
            End If
            sqlExecute("UPDATE evaluaciones_solicitantes SET " & _
                        "usuario  ='" & Usuario & _
                        "',promedio = " & IIf(Promediar, txtPromedio.Text, "NULL") & _
                        ",fecha = '" & FechaSQL(Today) & _
                        "',entrevistador = '" & Split(cmbReloj.Text, ",")(0) & "' " & _
                        "WHERE folio = '" & txtFolio.Text & "' AND cod_evaluacion = '" & CodEvaluacion & _
                        "' AND cod_cuestionario = '" & CodCuestionario & "'", "RECLUTAMIENTO")
            Dim dtRespuestas = sqlExecute("SELECT count(*) respuestas FROM respuestas_solicitantes WHERE folio = '" & txtFolio.Text & "' and cod_evaluacion ='" & CodEvaluacion & "' ", "RECLUTAMIENTO")
            If dtRespuestas.Rows.Count = 0 Then
            Else
                respuestas = dtRespuestas.Rows(0).Item("respuestas")
            End If
            Dim dtpreguntas = sqlExecute("SELECT count(*) preguntas FROM preguntas WHERE cod_cuestionario = '" & CodCuestionario & "'  and titulo = 0", "RECLUTAMIENTO")
            If dtpreguntas.Rows.Count = 0 Then
            Else
                preguntas = dtpreguntas.Rows(0).Item("preguntas")
            End If
            If preguntas > respuestas Then
                Return False
            Else
                strQry = "Update Candidatos set AprobadoSupervisor = '" & IIf(swAprobado.CheckValue, "1", "0") & "', ComentariosSupervisor = '" & txtComentariosSupervisor.Text.Trim & "' where Folio = '" & txtFolio.Text.Trim & "' "
                dtTemp = sqlExecute(strQry, "Reclutamiento")
                Return True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Private Sub pnlCuestionario_MouseEnter(sender As Object, e As EventArgs) Handles pnlCuestionario.MouseEnter
        pnlCuestionario.Select()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

    End Sub

    Private Sub GuardarCambiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarCambiosToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Public Overloads Sub Show(ByVal Folio As String)
        MyBase.Show()
        dtPersonal = sqlExecute("SELECT " & Campos & " FROM Candidatos WHERE folio ='" & Folio & "'", "RECLUTAMIENTO")
        If dtPersonal.Rows.Count > 0 Then
            MostrarInformacion(Folio)
        Else
            MessageBox.Show("El solicitante con folio " & Folio & " no fue localizado.", "Solicitante no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub cmbReloj_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbReloj.ButtonCustomClick
        Try
            'Reloj = "CANCEL"
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                'MostrarInformacion()
                cmbReloj.SelectedValue = Reloj
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbReloj_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbReloj.Validating
        Try
            If cmbReloj.SelectedValue <> "" Then
                dtTemporal = sqlExecute("SELECT (rtrim(nombre) + ' ' + rtrim(apaterno)) as nombres from personalvw WHERE reloj = '" & cmbReloj.SelectedValue & "'")
                If dtTemporal.Rows.Count = 0 Then
                    txtNombre.Text = "NO LOCALIZADO"
                Else
                    txtNombre.Text = StrConv(dtTemporal.Rows(0).Item("nombres").ToString.Trim, VbStrConv.ProperCase)
                End If
            End If
        Catch ex As Exception

        End Try
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