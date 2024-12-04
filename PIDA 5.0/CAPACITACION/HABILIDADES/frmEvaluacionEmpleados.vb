Imports System.IO

Public Class frmEvaluacionEmpleados
    Dim dtPersonal As New DataTable
    Dim dtTemp As New DataTable
    Dim Editar As Boolean
    Dim sdAgregarEvaluacion As DevComponents.AdvTree.Node
    Dim Certifica As Boolean
    Dim Cargando As Boolean

    Dim FontBold = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
    Dim FontBold12 = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)

    Dim FontRegular = New Font("Microsoft Sans Serif", 9)
    Dim MaxWidth As Integer = 0

    Dim dtRangos As New DataTable

    Dim Campos As String
    Public HuboCambios As Boolean


    Private Sub frmEvaluacionEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim P As Boolean = True
        Try
            Certifica = True
            Campos = "cod_comp,reloj,RTRIM(nombre)+' '+RTRIM(apaterno)+' '+RTRIM(amaterno) AS nombre,alta,baja,reingreso," & _
                "cod_tipo,nombre_tipoemp,cod_depto,nombre_depto,cod_super,nombre_super,cod_clase,nombre_clase,cod_turno,nombre_turno," & _
                "cod_hora,nombre_horario,cod_linea,cod_puesto,nombre_puesto"

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

            MostrarInformacion("")

            '--- AO 2023-06-07: Revisar perfiles para mostrar botones o no
            Dim _visible As Boolean = True
            _visible = revisarPerfiles(Perfil, Me, _visible, "WME", txtReloj.Text.ToString.Trim)
            btnGuardar.Visible = _visible
            btnCertificar.Visible = _visible

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Public Sub MostrarInformacion(ByVal rl As String)
        Dim ArchivoFoto As String
        Dim Comp As String

        Try
            If rl = "" Then
                dtPersonal = ConsultaPersonalVW("SELECT TOP 1 " & Campos & " FROM personalVW ORDER BY reloj", False)
                rl = IIf(IsDBNull(dtPersonal.Rows.Item(0).Item("reloj")), "", dtPersonal.Rows.Item(0).Item("reloj"))
            End If

            With dtPersonal.Rows.Item(0)
                Comp = IIf(IsDBNull(.Item("cod_comp")), "", .Item("cod_comp"))

                txtReloj.Text = IIf(IsDBNull(.Item("reloj")), "", .Item("reloj"))
                txtNombre.Text = IIf(IsDBNull(.Item("nombre")), "", .Item("nombre"))

                txtAlta.Value = IIf(IsDBNull(.Item("alta")), Nothing, .Item("alta"))
                EsBaja = Not IsDBNull(.Item("baja"))
                txtBaja.Value = IIf(EsBaja, .Item("baja"), Nothing)

                Reingreso = (IIf(IsDBNull(.Item("reingreso")), 0, .Item("reingreso")) = 1)
                lblReingreso.Visible = Reingreso

                txtTipoEmp.Text = IIf(IsDBNull(.Item("cod_tipo")), "", .Item("cod_tipo").ToString.Trim) & IIf(IsDBNull(.Item("nombre_tipoemp")), "", " (" & .Item("nombre_tipoemp").ToString.Trim & ")")
                txtDepto.Text = IIf(IsDBNull(.Item("cod_depto")), "", .Item("cod_depto").ToString.Trim) & IIf(IsDBNull(.Item("nombre_depto")), "", " (" & .Item("nombre_depto").ToString.Trim & ")")
                txtSupervisor.Text = IIf(IsDBNull(.Item("cod_super")), "", .Item("cod_super").ToString.Trim) & IIf(IsDBNull(.Item("nombre_super")), "", " (" & .Item("nombre_super").ToString.Trim & ")")
                txtClase.Text = IIf(IsDBNull(.Item("cod_clase")), "", .Item("cod_clase").ToString.Trim) & IIf(IsDBNull(.Item("nombre_clase")), "", " (" & .Item("nombre_clase").ToString.Trim & ")")
                txtTurno.Text = IIf(IsDBNull(.Item("cod_turno")), "", .Item("cod_turno").ToString.Trim) & IIf(IsDBNull(.Item("nombre_turno")), "", " (" & .Item("nombre_turno").ToString.Trim & ")")
                txtHorario.Text = IIf(IsDBNull(.Item("cod_hora")), "", .Item("cod_hora").ToString.Trim) & IIf(IsDBNull(.Item("nombre_horario")), "", " (" & .Item("nombre_horario").ToString.Trim & ")")
                txtLinea.Text = IIf(IsDBNull(.Item("cod_linea")), "", .Item("cod_linea").ToString.Trim) & IIf(IsDBNull(.Item("nombre_linea")), "", " (" & .Item("nombre_linea").ToString.Trim & ")")
                txtPuesto.Text = IIf(IsDBNull(.Item("cod_puesto")), "", .Item("cod_puesto").ToString.Trim) & IIf(IsDBNull(.Item("nombre_puesto")), "", " (" & .Item("nombre_puesto").ToString.Trim & ")")
            End With

            '' *** PROCESO PARA CARGAR FOTOGRAFIA ***
            Try
                ArchivoFoto = PathFoto & rl & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    ArchivoFoto = PathFoto & "nofoto. png"
                End If

                'Dim ft As New Bitmap(ArchivoFoto)
                picFoto.Width = picFoto.MinimumSize.Width
                picFoto.Height = picFoto.MinimumSize.Height
                picFoto.Left = 1094
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

            lblReingreso.Visible = Not EsBaja And Reingreso
            '*************************

            CrearEvaluaciones()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
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
            pnlDatosCertificacion.Visible = False
            pnlGuardar.Visible = False
            dtEvaluaciones = sqlExecute("SELECT DISTINCT evaluaciones_empleados.cod_evaluacion,nombre,cuestionarios " & _
                                        "FROM evaluaciones_empleados LEFT JOIN evaluaciones " & _
                                        "ON evaluaciones_empleados.cod_evaluacion = evaluaciones.cod_evaluacion " & _
                                        "WHERE reloj = '" & txtReloj.Text & "' ORDER BY evaluaciones_empleados.cod_evaluacion", "CAPACITACION")

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
            Dim dtRecertifica As New DataTable

            Dim Cuestionarios As String

            Dim sdNodoCuest As DevComponents.AdvTree.Node
            Dim sdNodoRecert As DevComponents.AdvTree.Node

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
                                         "WHERE cod_cuestionario IN (" & Cuestionarios & ")", "CAPACITACION")
            For Each dCuest As DataRow In dtCuestionarios.Rows
                sdNodoCuest = New DevComponents.AdvTree.Node
                sdNodoCuest.Text = dCuest("nombre").ToString.Trim
                sdNodoCuest.Name = "cuest" & dCuest("cod_cuestionario")
                sdNodoCuest.FullRowBackground = True
                sdNodo.Nodes.Add(sdNodoCuest)
                dtRecertifica = sqlExecute("SELECT fecha,num_certificacion FROM evaluaciones_empleados WHERE reloj = '" & txtReloj.Text & "'" & _
                                           " AND cod_cuestionario = '" & dCuest("cod_cuestionario") & "' AND num_certificacion>0 ORDER BY num_certificacion", "CAPACITACION")

                For Each dCertifica As DataRow In dtRecertifica.Rows
                    sdNodoRecert = New DevComponents.AdvTree.Node
                    sdNodoRecert.Text = "Recertificación " & FechaCortaLetra(dCertifica("fecha"))
                    sdNodoRecert.Name = "recert" & dCuest("cod_cuestionario") & "#" & dCertifica("num_certificacion")
                    sdNodoRecert.FullRowBackground = True
                    sdNodoCuest.Nodes.Add(sdNodoRecert)
                Next
            Next
            Return sdNodo

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            Return New DevComponents.AdvTree.Node
        End Try
    End Function

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Try
            Dim reloj As String
            reloj = txtReloj.Text
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 " & Campos & " FROM personalVW ORDER BY reloj ASC", False)

            reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
            MostrarInformacion(reloj)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Try
            Dim reloj As String
            reloj = txtReloj.Text
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 " & Campos & " FROM personalVW WHERE reloj <'" & reloj & "' ORDER BY reloj DESC", False)

            If dtPersonal.Rows.Count < 1 Then
                btnFirst.PerformClick()
            Else
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")

                MostrarInformacion(reloj)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            Dim reloj As String
            reloj = txtReloj.Text
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 " & Campos & " FROM personalVW WHERE reloj >'" & reloj & "' ORDER BY reloj ASC", False)
            If dtPersonal.Rows.Count < 1 Then
                btnLast.PerformClick()
            Else
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
                MostrarInformacion(reloj)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Try

            Dim reloj As String
            reloj = txtReloj.Text
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 " & Campos & " FROM personalVW ORDER BY reloj DESC", False)

            reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
            MostrarInformacion(reloj)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtTemp = dtPersonal
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                dtPersonal = ConsultaPersonalVW("SELECT " & campos & " FROM personalVW WHERE reloj ='" & Reloj & "'", False)
                If dtPersonal.Rows.Count > 0 Then
                    MostrarInformacion(Reloj)
                Else
                    MessageBox.Show("El empleado " & Reloj & " no fue localizado, o tiene un nivel al que su usuario no tiene acceso.", "Empleado no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            dtPersonal = dtTemp
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs)
        Try
            If Not Editar Then
                Editar = True
                txtNombre.Focus()

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
            Dim Recertificacion As Integer

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
                Recertificacion = CodCuestionario.Substring(i + 1)
                CodCuestionario = CodCuestionario.Substring(0, i)
            Else
                Recertificacion = 0
            End If

            Cargando = True
            dtPreguntas = sqlExecute("SELECT preguntas.*,seleccion_multiple,opciones,estilo FROM preguntas LEFT JOIN tipos_respuestas " & _
                                     "ON preguntas.cod_respuesta = tipos_respuestas.cod_respuesta WHERE cod_cuestionario = '" & CodCuestionario & _
                                     "' ORDER BY ubicacion", "CAPACITACION")

            'Limpiar el panel de controles anteriores
            pnlCuestionario.Visible = False
            My.Application.DoEvents()
            pnlCuestionario.Controls.Clear()

            pnlCuestionario.Tag = CodEvaluacion.Trim & "#" & CodCuestionario.Trim & "#" & Recertificacion
            i = 0
            'Inicializar el ancho máximo de acuerdo al panel
            MaxWidth = pnlCuestionario.Width

            For Each dPreg As DataRow In dtPreguntas.Rows
                dtResEmp = sqlExecute("SELECT respuesta FROM respuestas_empleados WHERE reloj = '" & txtReloj.Text & _
                                      "' AND cod_pregunta = '" & dPreg("cod_pregunta") & _
                                      "' AND cod_evaluacion = '" & CodEvaluacion.Replace("cuest", "") & _
                                      "' AND cod_cuestionario = '" & CodCuestionario.Replace("cuest", "") & _
                                      "' AND num_certificacion = " & Recertificacion, "CAPACITACION")
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
                                If Resp.Length > v + 2 Then
                                    Op = Resp.Substring(0, v).Trim
                                    Val = Resp.Substring(v + 2)

                                    chkLogico = New DevComponents.DotNetBar.Controls.CheckBoxX
                                    chkLogico.Parent = pnlPregunta
                                    chkLogico.Left = 600 + j
                                    chkLogico.Top = 5
                                    chkLogico.BackColor = SystemColors.Window
                                    chkLogico.Text = Op.Trim
                                    chkLogico.Tag = Val
                                    chkLogico.Width = 50
                                    chkLogico.Height = 20
                                    chkLogico.Visible = True
                                    chkLogico.TextColor = SystemColors.WindowText
                                    chkLogico.AutoSize = True
                                    AddHandler chkLogico.CheckedChanged, AddressOf BanderaCambios


                                    If dPreg("seleccion_multiple") Then
                                        chkLogico.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox
                                    Else
                                        chkLogico.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
                                    End If

                                    If MaxWidth < chkLogico.Width + chkLogico.Left Then
                                        MaxWidth = chkLogico.Width + chkLogico.Left
                                    End If
                                    j += (chkLogico.Width + 5)

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
            RefrescaPanelCertificacion(CodEvaluacion, CodCuestionario)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Public Sub GuardarRespuestas(ByVal Codigo As String)
        Try
            Dim Respuesta As String
            Dim Recertificacion As Integer
            Dim i As Integer
            Dim j As Integer
            Dim CodEvaluacion As String
            Dim CodCuestionario As String

            i = Codigo.IndexOf("#")
            If i >= 0 Then

                CodEvaluacion = Codigo.Substring(0, i).Trim
                j = Codigo.IndexOf("#", i + 1)
                If j >= 0 Then
                    CodCuestionario = Codigo.Substring(i + 1, j - i - 1)
                    Recertificacion = Codigo.Substring(j + 1)
                Else
                    CodCuestionario = ""
                    Recertificacion = 0
                End If
            Else
                Recertificacion = 0
                CodCuestionario = ""
                CodEvaluacion = Codigo
            End If

            Dim dtRespuesta As New DataTable

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
                    dtRespuesta = sqlExecute("SELECT respuesta FROM respuestas_empleados WHERE reloj = '" & txtReloj.Text & _
                             "' AND cod_evaluacion = '" & CodEvaluacion & _
                             "' AND cod_pregunta = '" & pnlPregunta.name.replace("preg", "") & _
                             "' AND cod_cuestionario = '" & CodCuestionario & _
                             "' AND num_certificacion = " & Recertificacion _
                             , "CAPACITACION")
                    If dtRespuesta.Rows.Count > 0 Then
                        sqlExecute("UPDATE respuestas_empleados SET respuesta = '" & Respuesta & "'  WHERE reloj = '" & txtReloj.Text & _
                             "' AND cod_evaluacion = '" & CodEvaluacion & _
                             "' AND cod_pregunta = '" & pnlPregunta.name.replace("preg", "") & _
                             "' AND cod_cuestionario = '" & CodCuestionario & _
                             "' AND num_certificacion = " & Recertificacion _
                             , "CAPACITACION")
                    Else
                        sqlExecute("INSERT INTO respuestas_empleados (reloj,cod_evaluacion,cod_pregunta,cod_cuestionario,respuesta,num_certificacion) VALUES ('" & _
                                   txtReloj.Text & "','" & CodEvaluacion & "','" & pnlPregunta.name.replace("preg", "") & "','" & _
                                   CodCuestionario & "','" & Respuesta & "'," & Recertificacion & ")", "CAPACITACION")
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
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
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
            Certifica = False
        Finally
            btnCertificar.Enabled = Certifica
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
            HuboCambios = True
        End Try
    End Sub

    Private Sub pnlCuestionario_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs)

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
            strRespuesta = txtReloj.Text
            If frmAgregarEvaluacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim sdNodo As devcomponents.advtree.node
                CodEval = strRespuesta

                dtEvaluacion = sqlExecute("SELECT cod_evaluacion,nombre,cuestionarios FROM evaluaciones WHERE cod_evaluacion = '" & _
                                          CodEval & "'", "CAPACITACION")
                C = IIf(IsDBNull(dtEvaluacion.Rows(0).Item("cuestionarios")), "", dtEvaluacion.Rows(0).Item("cuestionarios"))
                ArCuestionarios = C.Trim.Split(",")
                For Each C In ArCuestionarios
                    C = C.Replace("'", "")

                    sqlExecute("INSERT INTO evaluaciones_empleados (reloj,cod_evaluacion,cod_cuestionario)" & _
                               "VALUES ('" & txtReloj.Text & "','" & _
                               CodEval & "','" & _
                               C & "')", "CAPACITACION")
                Next
                sdNodo = CrearNodo(dtEvaluacion.Rows(0))
                treEvaluaciones.Nodes.Insert(treEvaluaciones.Nodes.Count - 1, sdNodo)
                treevaluaciones.Refresh()
                Return sdNodo
            Else
                Return Nothing
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub BorrarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem1.Click
        Dim dtEvalEmp As New DataTable
        Dim Evaluacion As New devcomponents.advtree.node
        Dim Recertificacion As Integer
        Dim i As Integer
        Dim j As Integer
        Dim CodEvaluacion As String
        Dim CodCuestionario As String
        Dim Codigo As String
        Dim Borra As Boolean = True
        Try

            Evaluacion = treEvaluaciones.SelectedNode
            If Evaluacion Is Nothing Then Exit Sub

            Codigo = pnlCuestionario.Tag

            i = Codigo.IndexOf("#")
            If i >= 0 Then

                CodEvaluacion = Codigo.Substring(0, i).Trim
                j = Codigo.IndexOf("#", i + 1)
                If j >= 0 Then
                    CodCuestionario = Codigo.Substring(i + 1, j - i - 1)
                    Recertificacion = Codigo.Substring(j + 1)
                Else
                    CodCuestionario = ""
                    Recertificacion = 0
                End If
            Else
                Recertificacion = 0
                CodCuestionario = ""
                CodEvaluacion = Codigo
            End If


            dtEvalEmp = sqlExecute("SELECT SUM(certificado) FROM evaluaciones_empleados WHERE reloj = '" & txtReloj.Text & _
                                   "' AND cod_evaluacion = '" & CodEvaluacion & "'", "CAPACITACION")
            If dtEvalEmp.Rows.Count > 0 Then
                If IIf(IsDBNull(dtEvalEmp.Rows(0).Item(0)), 0, dtEvalEmp.Rows(0).Item(0)) > 0 Then
                    MessageBox.Show("No se puede borrar una evaluación que ya fue certificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Borra = False
                End If
            End If

            If Borra Then
                If MessageBox.Show("¿Está seguro de querer borrar la evaluación " & Evaluacion.Text & _
                                   " del empleado con número de reloj " & txtReloj.Text & "?", "Borrar evaluación", _
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    sqlExecute("DELETE FROM evaluaciones_empleados WHERE reloj = '" & txtReloj.Text & _
                               "' AND cod_evaluacion = '" & CodEvaluacion & "'", "CAPACITACION")
                    Evaluacion.Parent.Nodes.Remove(Evaluacion)
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
                'Recertificación
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
            GuardarRespuestas(pnlCuestionario.Tag)
        Catch ex As Exception
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
            Try
                Certifica = True
                For Each pnl In pnlCuestionario.Controls
                    If pnl.controls.count > 1 Then
                        'Si solo tiene un control, es solo título, y no cuenta para promedio
                        p += 1
                    End If
                    'Certificación es el panel con la información de usuario, fecha, etc.
                    If pnl.tag Is Nothing Then
                        CalMin = 0
                    Else
                        CalMin = pnl.tag
                    End If
                    For Each ctl In pnl.controls
                        If TypeOf ctl Is DevComponents.DotNetBar.Controls.CheckBoxX Then
                            If ctl.checkboxstyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton Then
                                If ctl.checked Then
                                    Certifica = Certifica And (ctl.tag <> 0)
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
                                Certifica = Certifica And (CalMin <= ttl)

                            End If
                        ElseIf TypeOf ctl Is DevComponents.Editors.IntegerInput Then
                            Certifica = Certifica And (CalMin <= ctl.value)
                            Calificacion += ctl.value
                        ElseIf TypeOf ctl Is DevComponents.DotNetBar.ProgressSteps Then
                            ttl = 0
                            For Each stpNivel In ctl.items
                                If stpNivel.value = 100 Then
                                    ttl += 1
                                End If
                            Next
                            Calificacion += ttl
                            Certifica = Certifica And (CInt(CalMin) <= ttl)
                        End If
                    Next
                    'Suma += Calificacion
                Next
                txtPromedio.Text = Math.Round(Calificacion / p, 2)
            Catch ex As Exception
                Certifica = False
            Finally
                btnCertificar.Enabled = Certifica
            End Try
        End If

    End Sub

    Private Sub RefrescaPanelCertificacion(ByVal CodEvaluacion As String, ByVal CodCuestionario As String)
        Dim dtCuestionario As New DataTable
        Dim dtEvaluacion As New DataTable
        Dim dtRecertifica As New DataTable
        Dim Recertifica As Boolean
        Dim BorraRecert As Boolean
        Dim Certificado As Boolean
        Dim ProxCertifica As Integer
        Dim Promediar As Boolean
        Dim NumCertificacion As Integer
        Dim i As Integer
        Try
            'Buscar el número de certificación seleccionado
            i = pnlCuestionario.Tag.ToString.LastIndexOf("#")
            If i > 0 Then
                NumCertificacion = pnlCuestionario.Tag.ToString.Substring(i + 1)
            Else
                NumCertificacion = 0
            End If

            dtCuestionario = sqlExecute("SELECT * FROM cuestionarios WHERE cod_cuestionario = '" & CodCuestionario & "'", "CAPACITACION")
            dtEvaluacion = sqlExecute("SELECT * FROM evaluaciones_empleados WHERE reloj = '" & txtReloj.Text & "'" & _
                                      " AND cod_evaluacion = '" & CodEvaluacion & "' AND cod_cuestionario = '" & CodCuestionario & "'" & _
                                      " AND num_certificacion = " & NumCertificacion, _
                                      "CAPACITACION")

            If dtCuestionario.Rows.Count = 0 Then
                Recertifica = False
                ProxCertifica = 0
                Promediar = True
            Else
                Recertifica = IIf(IsDBNull(dtCuestionario.Rows(0).Item("recertificacion")), 0, dtCuestionario.Rows(0).Item("recertificacion"))
                ProxCertifica = IIf(IsDBNull(dtCuestionario.Rows(0).Item("tiempo_recertificacion")), 0, dtCuestionario.Rows(0).Item("tiempo_recertificacion"))
                Promediar = IIf(IsDBNull(dtCuestionario.Rows(0).Item("promediar")), 0, dtCuestionario.Rows(0).Item("promediar"))

                If Recertifica Then
                    'Revisar si la última recertificación ya fue completada
                    'para permitir o no agregar una nueva
                    dtRecertifica = sqlExecute("SELECT certificado FROM evaluaciones_empleados WHERE reloj = '" & txtReloj.Text & "'" & _
                                      " AND cod_evaluacion = '" & CodEvaluacion & "' AND cod_cuestionario = '" & CodCuestionario & "'" & _
                                      " AND num_certificacion = " & _
                                      "(SELECT max(num_certificacion) FROM evaluaciones_empleados WHERE reloj = '" & txtReloj.Text & "'" & _
                                      " AND cod_cuestionario = '" & CodCuestionario & "' AND cod_evaluacion = '" & CodEvaluacion & "')", "CAPACITACION")
                    If dtRecertifica.Rows.Count = 0 Then
                        Recertifica = False
                    Else
                        Recertifica = IIf(IsDBNull(dtRecertifica.Rows(0).Item(0)), 0, dtRecertifica.Rows(0).Item(0))
                    End If
                    BorraRecert = True
                Else
                    BorraRecert = False
                End If
            End If
            'Habilitar/inhabilitar opción de agregar recertifiación
            AgregarRecertificaciónToolStripMenuItem.Enabled = Recertifica
            BorrarRecertificaciónToolStripMenuItem.Enabled = BorraRecert

            If dtEvaluacion.Rows.Count > 0 Then
                Certificado = IIf(IsDBNull(dtEvaluacion.Rows(0).Item("certificado")), 0, dtEvaluacion.Rows(0).Item("certificado")) = 1

                If Certificado Then
                    txtUsuario.Text = IIf(IsDBNull(dtEvaluacion.Rows(0).Item("usuario")), "", dtEvaluacion.Rows(0).Item("usuario"))
                    txtFecha.Value = IIf(IsDBNull(dtEvaluacion.Rows(0).Item("fecha")), Today.Date, dtEvaluacion.Rows(0).Item("fecha"))
                    txtProxEval.Value = IIf(IsDBNull(dtEvaluacion.Rows(0).Item("proxima_evaluacion")), DateAdd(DateInterval.Day, ProxCertifica, txtFecha.Value), dtEvaluacion.Rows(0).Item("proxima_evaluacion"))
                    txtPromedio.Text = IIf(IsDBNull(dtEvaluacion.Rows(0).Item("promedio")), 0, dtEvaluacion.Rows(0).Item("promedio"))
                End If
            Else
                Certificado = False
            End If
            'Mostrar el panel con datos de la certificación, si ya completó
            pnlDatosCertificacion.Visible = Certificado
            'Mostrar panel para guardar cambios y certificar, si aún no completa
            pnlGuardar.Visible = Not Certificado

            'Si ya está certificado, no permitir modificar respuestas
            For Each pnl In pnlCuestionario.Controls
                If TypeOf pnl Is Panel Then
                    For Each ctl In pnl.controls
                        If Not TypeOf ctl Is Label Then
                            ctl.enabled = Not Certificado
                        End If
                    Next
                End If
            Next


        Catch ex As Exception
            pnlCuestionario.Enabled = False
            txtUsuario.Text = "ERROR"
        End Try
    End Sub

    Private Sub pnlCuestionario_Resize(sender As Object, e As EventArgs) Handles pnlCuestionario.Resize
        Try
            For Each pnl As Panel In pnlCuestionario.Controls
                pnl.Width = IIf(pnlCuestionario.Width < MaxWidth, MaxWidth, pnlCuestionario.Width) - 5
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCertificar_Click(sender As Object, e As EventArgs) Handles btnCertificar.Click
        Dim dtCuestionario As New DataTable

        Dim Recertificacion As Integer
        Dim ProxCertifica As Integer
        Dim Promediar As Boolean
        Dim i As Integer
        Dim j As Integer
        Dim CodEvaluacion As String
        Dim CodCuestionario As String
        Dim Codigo As String
        Try
            Codigo = pnlCuestionario.Tag
            i = Codigo.IndexOf("#")
            If i >= 0 Then

                CodEvaluacion = Codigo.Substring(0, i).Trim
                j = Codigo.IndexOf("#", i + 1)
                If j >= 0 Then
                    CodCuestionario = Codigo.Substring(i + 1, j - i - 1)
                    Recertificacion = Codigo.Substring(j + 1)
                Else
                    CodCuestionario = ""
                    Recertificacion = 0
                End If
            Else
                Recertificacion = 0
                CodCuestionario = ""
                CodEvaluacion = Codigo
            End If

            If MessageBox.Show("¿Está seguro de certificar al empleado " & txtReloj.Text & "?", "Certificar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                GuardarRespuestas(pnlCuestionario.Tag)
                RevisaRespuestas()

                dtCuestionario = sqlExecute("SELECT tiempo_recertificacion,promediar FROM cuestionarios WHERE cod_cuestionario = '" & CodCuestionario & "'", "CAPACITACION")

                If dtCuestionario.Rows.Count = 0 Then
                    ProxCertifica = 0
                Else
                    ProxCertifica = IIf(IsDBNull(dtCuestionario.Rows(0).Item("tiempo_recertificacion")), 0, dtCuestionario.Rows(0).Item("tiempo_recertificacion"))
                    Promediar = IIf(IsDBNull(dtCuestionario.Rows(0).Item("promediar")), 0, dtCuestionario.Rows(0).Item("promediar"))
                End If

                sqlExecute("UPDATE evaluaciones_empleados SET " & _
                           "certificado = 1," & _
                           "usuario  ='" & Usuario & _
                           "',promedio = " & IIf(Promediar, txtPromedio.Text, "NULL") & _
                           ",fecha = '" & FechaSQL(Today) & _
                           "',proxima_evaluacion = '" & FechaSQL(DateAdd(DateInterval.Day, ProxCertifica, Today)) & _
                           "' WHERE reloj= '" & txtReloj.Text & "' AND cod_evaluacion = '" & CodEvaluacion & _
                           "' AND cod_cuestionario = '" & CodCuestionario & "' AND num_certificacion = " & Recertificacion, "CAPACITACION")
                RefrescaPanelCertificacion(CodEvaluacion, CodCuestionario)

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub txtProxEval_Click(sender As Object, e As EventArgs) Handles txtProxEval.Click

    End Sub

    Private Sub txtProxEval_ValueChanged(sender As Object, e As EventArgs) Handles txtProxEval.ValueChanged
        Dim dtCuestionario As New DataTable

        Dim Recertificacion As Integer
        Dim i As Integer
        Dim j As Integer
        Dim CodEvaluacion As String
        Dim CodCuestionario As String
        Dim Codigo As String

        If Cargando Then Exit Sub

        Codigo = pnlCuestionario.Tag
        i = Codigo.IndexOf("#")
        If i >= 0 Then

            CodEvaluacion = Codigo.Substring(0, i).Trim
            j = Codigo.IndexOf("#", i + 1)
            If j >= 0 Then
                CodCuestionario = Codigo.Substring(i + 1, j - i - 1)
                Recertificacion = Codigo.Substring(j + 1)
            Else
                CodCuestionario = ""
                Recertificacion = 0
            End If
        Else
            Recertificacion = 0
            CodCuestionario = ""
            CodEvaluacion = Codigo
        End If

        sqlExecute("UPDATE evaluaciones_empleados SET proxima_evaluacion = '" & txtProxEval.Value & _
                       "' WHERE reloj= '" & txtReloj.Text & "' AND cod_evaluacion = '" & CodEvaluacion & _
                       "' AND cod_cuestionario = '" & CodCuestionario & "' AND num_certificacion = " & Recertificacion, "CAPACITACION")

    End Sub

    Private Sub AgregarRecertificaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarRecertificaciónToolStripMenuItem.Click
        Dim dtCuestionario As New DataTable

        Dim Recertificacion As Integer
        Dim i As Integer
        Dim j As Integer
        Dim CodCuestionario As String
        Dim CodEvaluacion As String
        Dim Codigo As String
        Try
            'El tag del panel de cuestionario incluye codEval#codCuest#recertificacion
            Codigo = pnlCuestionario.Tag
            CodCuestionario = ""
            CodEvaluacion = Codigo

            i = Codigo.IndexOf("#")
            If i >= 0 Then
                CodEvaluacion = Codigo.Substring(0, i).Trim
                j = Codigo.IndexOf("#", i + 1)
                If j >= 0 Then
                    CodCuestionario = Codigo.Substring(i + 1, j - i - 1)
                End If
            End If

            'Buscar la última certificación dada
            dtCuestionario = sqlExecute("SELECT max(num_certificacion) FROM evaluaciones_empleados WHERE certificado = 1 AND reloj = '" & txtReloj.Text & "'" & _
                               " AND cod_cuestionario = '" & CodCuestionario & "'" & " AND cod_evaluacion = '" & CodEvaluacion & "'", "CAPACITACION")

            If dtCuestionario.Rows.Count = 0 Then
                Recertificacion = 0
            Else
                'Agregar 1, para crear la siguiente
                Recertificacion = IIf(IsDBNull(dtCuestionario.Rows(0).Item(0)), 0, dtCuestionario.Rows(0).Item(0)) + 1
            End If

            Dim sdNodoRecert As New DevComponents.AdvTree.Node
            sdNodoRecert.Text = "Recertificación " & FechaCortaLetra(Today)
            sdNodoRecert.Name = "recert" & CodCuestionario & "#" & Recertificacion
            sdNodoRecert.FullRowBackground = True

            'Tomar el nodo seleccionado, y en base a su posición, ubicar dónde corresponde la recertificación
            Dim sdParentNode As New DevComponents.AdvTree.Node
            sdParentNode = treEvaluaciones.SelectedNode
            If sdParentNode.Name.Contains("recert") Then
                sdParentNode = treEvaluaciones.SelectedNode.Parent
            ElseIf sdParentNode.Name.Contains("eval") Then
                sdParentNode = treEvaluaciones.SelectedNode.Nodes(0)
            End If

            sdParentNode.Nodes.Add(sdNodoRecert)

            'Insertar en la tabla
            sqlExecute("INSERT INTO evaluaciones_empleados (reloj,cod_evaluacion,cod_cuestionario,fecha,num_certificacion)" & _
                               "VALUES ('" & txtReloj.Text & "','" & _
                               CodEvaluacion & "','" & _
                               CodCuestionario & "','" & _
                               FechaSQL(Today) & "'," & _
                               Recertificacion & ")", "CAPACITACION")
            sdNodoRecert.SetSelectedCell(sdNodoRecert.Cells(0), DevComponents.AdvTree.eTreeAction.Code)
            sdNodoRecert.RaiseClick()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub pnlCuestionario_MouseEnter(sender As Object, e As EventArgs) Handles pnlCuestionario.MouseEnter
        pnlCuestionario.Select()
    End Sub

    Private Sub BorrarRecertificaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarRecertificaciónToolStripMenuItem.Click
        Dim dtEvalEmp As New DataTable
        Dim Evaluacion As New DevComponents.AdvTree.Node
        Dim Recertificacion As Integer
        Dim i As Integer
        Dim j As Integer
        Dim CodEvaluacion As String
        Dim CodCuestionario As String
        Dim Codigo As String
        Dim Borra As Boolean = True
        Try
            Evaluacion = treEvaluaciones.SelectedNode
            If Evaluacion Is Nothing Then Exit Sub
            If Not Evaluacion.Name.Contains("recert") Then
                MessageBox.Show(Evaluacion.Text & " no es una recertificación, por lo que no puede ser eliminada. Favor de verificar.", "Borrar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Codigo = pnlCuestionario.Tag

            i = Codigo.IndexOf("#")
            If i >= 0 Then

                CodEvaluacion = Codigo.Substring(0, i).Trim
                j = Codigo.IndexOf("#", i + 1)
                If j >= 0 Then
                    CodCuestionario = Codigo.Substring(i + 1, j - i - 1)
                    Recertificacion = Codigo.Substring(j + 1)
                Else
                    CodCuestionario = ""
                    Recertificacion = 0
                End If
            Else
                Recertificacion = 0
                CodCuestionario = ""
                CodEvaluacion = Codigo
            End If


            dtEvalEmp = sqlExecute("SELECT certificado FROM evaluaciones_empleados WHERE reloj = '" & txtReloj.Text & _
                                   "' AND cod_evaluacion = '" & CodEvaluacion & "' AND cod_cuestionario = '" & CodCuestionario & "'" & _
                                   "AND num_certificacion= " & Recertificacion, "CAPACITACION")
            If dtEvalEmp.Rows.Count > 0 Then
                If IIf(IsDBNull(dtEvalEmp.Rows(0).Item(0)), 0, dtEvalEmp.Rows(0).Item(0)) > 0 Then
                    MessageBox.Show("No se puede borrar una recertificación aprobada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Borra = False
                End If
            End If

            If Borra Then
                If MessageBox.Show("¿Está seguro de querer borrar la recertificación " & Evaluacion.Name.Replace("eval", "") & _
                                   " del empleado con número de reloj " & txtReloj.Text & "?", "Borrar recertificación", _
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    sqlExecute("DELETE FROM evaluaciones_empleados WHERE reloj = '" & txtReloj.Text & _
                                   "' AND cod_evaluacion = '" & CodEvaluacion & "' AND cod_cuestionario = '" & CodCuestionario & "'" & _
                                   "AND num_certificacion= " & Recertificacion, "CAPACITACION")

                    sqlExecute("DELETE FROM respuestas_empleados WHERE reloj = '" & txtReloj.Text & _
                               "' AND cod_evaluacion = '" & CodEvaluacion & "' AND cod_cuestionario = '" & CodCuestionario & "'" & _
                               "AND num_certificacion = " & Recertificacion, "CAPACITACION")

                    Evaluacion.Parent.Nodes.Remove(Evaluacion)
                    treEvaluaciones.Refresh()
                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

    End Sub
End Class