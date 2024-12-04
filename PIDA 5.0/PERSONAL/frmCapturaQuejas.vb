''' <summary>
''' Módulo de captura de quejas a empleados [basado en el módulo de captura de medidas disciplinaria]
''' Ernesto  13feb2023
''' </summary>
''' <remarks></remarks>
Public Class frmCapturaQuejas

    Dim folio As Integer
    Dim dtInfoEditar As DataTable = Nothing
    Dim dtInfo As DataTable = Nothing
    Dim editarInfo = False

    Public Sub New(blEdit As Boolean, intFolio As Integer)
        InitializeComponent()
        editarInfo = blEdit
        folio = intFolio
    End Sub

    Private Sub frmCapturaAccionDisciplinaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(300, 50)

        '== Valor de nuevo folio o folio inicial
        If folio = 0 Then
            Dim dtfolio As DataTable = sqlExecute("SELECT TOP 1 FOLIO FROM PERSONAL.dbo.presentacion_quejas ORDER BY FOLIO DESC")
            If dtfolio.Rows.Count > 0 Then
                folio = dtfolio.Rows(0)("folio") + 1
            Else
                folio = 1000000000
            End If
        End If

        '== Si se trata de una edición de datos
        If editarInfo = True Then
            dtInfoEditar = sqlExecute("SELECT P.FOLIO,RTRIM(P.COD_MOTIVO) AS COD_MOTIVO,C.NOMBRE AS MOTIVO,P.RELOJ AS ACUSANTE,P.NOMBRES,P.PUESTO,P.DEPARTAMENTO," &
                                          "P.FECHA,P.COMENT_SUPER,P.COMENT_EMPLEADO,P.PATH_PDF FROM PERSONAL.dbo.presentacion_quejas P " &
                                          "LEFT JOIN PERSONAL.dbo.cod_queja C ON P.COD_MOTIVO=C.COD_MOTIVO " &
                                          "WHERE P.FOLIO='" & folio & "'")
        End If

        '== Muestra la información en los controles
        MostrarInformacion(editarInfo, dtInfoEditar)

    End Sub

    ''' <summary>
    ''' Valores iniciales de controles al cargar pantalla
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MostrarInformacion(Optional editar As Boolean = False, Optional dtInfoEditar As DataTable = Nothing)
        Try
            '== Valores iniciales de controles
            txtReloj.Text = Reloj
            dtimeFecha.Value = Today
            txtComentEmpleado.Text = ""
            txtComentSupervisor.Text = ""
            txtPDF.Text = ""

            '== Nombres del empleado acusado
            Dim dtReloj As DataTable = sqlExecute("SELECT NOMBRES FROM PERSONAL.dbo.personalvw WHERE reloj='" & txtReloj.Text & "'")
            txtNombre.Text = IIf(IsDBNull(dtReloj.Rows(0)("NOMBRES")), "", RTrim(dtReloj.Rows(0)("NOMBRES")))

            '== Motivos disponibles de quejas
            cmbMotivo.DataSource = sqlExecute("SELECT RTRIM(COD_MOTIVO) AS COD_MOTIVO,RTRIM(NOMBRE) AS NOMBRE FROM PERSONAL.dbo.cod_queja")

            '== Deshabilitar boton de búsqueda de reloj, si es edición
            btnBuscar.Enabled = Not editar

            '== Si se edita info. cargar datos de acusante
            If editar Then
                cmbMotivo.SelectedValue = IIf(IsDBNull(dtInfoEditar.Rows(0).Item("COD_MOTIVO")), "", dtInfoEditar.Rows(0).Item("COD_MOTIVO"))
                txtPDF.Text = IIf(IsDBNull(dtInfoEditar.Rows(0).Item("PATH_PDF")), "", dtInfoEditar.Rows(0).Item("PATH_PDF"))
                dtimeFecha.Text = IIf(IsDBNull(dtInfoEditar.Rows(0).Item("FECHA")), "", dtInfoEditar.Rows(0).Item("FECHA"))
                txtComentEmpleado.Text = IIf(IsDBNull(dtInfoEditar.Rows(0).Item("COMENT_EMPLEADO")), "", dtInfoEditar.Rows(0).Item("COMENT_EMPLEADO"))
                txtComentSupervisor.Text = IIf(IsDBNull(dtInfoEditar.Rows(0).Item("COMENT_SUPER")), "", dtInfoEditar.Rows(0).Item("COMENT_SUPER"))
                txtNoReloj.Text = IIf(IsDBNull(dtInfoEditar.Rows(0).Item("ACUSANTE")), "", dtInfoEditar.Rows(0).Item("ACUSANTE"))
                txtNombres.Text = IIf(IsDBNull(dtInfoEditar.Rows(0).Item("NOMBRES")), "", dtInfoEditar.Rows(0).Item("NOMBRES"))
                txtPuesto.Text = IIf(IsDBNull(dtInfoEditar.Rows(0).Item("PUESTO")), "", dtInfoEditar.Rows(0).Item("PUESTO"))
                txtDepartamento.Text = IIf(IsDBNull(dtInfoEditar.Rows(0).Item("DEPARTAMENTO")), "", dtInfoEditar.Rows(0).Item("DEPARTAMENTO"))
                txtPDF.Text = IIf(IsDBNull(dtInfoEditar.Rows(0).Item("PATH_PDF")), "", dtInfoEditar.Rows(0).Item("PATH_PDF"))
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Validación al momento de agregar o editar info.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function validacionesControles(Optional campos As Boolean = False) As Boolean
        '== Contenido de controles
        Dim ctrls As Boolean = (Not dtimeFecha.ValueObject = Nothing And
                                txtPDF.Text.ToString.Trim <> "" And
                                (cmbMotivo.SelectedValue <> "" Or Not cmbMotivo.SelectedValue = Nothing) And
                                txtNoReloj.Text.ToString.Trim <> "")

        If editarInfo AndAlso (ctrls And campos) Then Return True
        If Not editarInfo AndAlso ctrls Then Return True

FechaErronea:
        Return False
    End Function

    ''' <summary>
    ''' Agrega o edita la información
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim campos = "", strqry = ""

            If editarInfo Then
                strQry = "UPDATE PERSONAL.dbo.presentacion_quejas SET {0} WHERE FOLIO='" & folio & "'"

                '== Nueva información
                Dim infoNva As New Dictionary(Of String, Object)
                infoNva.Add("COD_MOTIVO", cmbMotivo.SelectedValue)
                infoNva.Add("FECHA", FechaSQL(dtimeFecha.Value))
                infoNva.Add("COMENT_SUPER", txtComentSupervisor.Text.ToString.Trim)
                infoNva.Add("COMENT_EMPLEADO", txtComentEmpleado.Text.ToString.Trim)
                infoNva.Add("PATH_PDF", txtPDF.Text.ToString.Trim)

                campos = String.Join(",", (From i In infoNva Where i.Value <> dtInfoEditar.Rows(0)(i.Key) Select i.Key & "='" & i.Value & "'"))
            End If

            If validacionesControles((campos <> "")) Then

                If Not editarInfo Then
                    strqry = "INSERT INTO PERSONAL.dbo.presentacion_quejas VALUES (" &
                       "'" & folio.ToString & "'," &
                       "'" & txtNoReloj.Text.ToString.Trim & "'," &
                       "'" & dtInfo.Rows(0)("COD_PLANTA") & "'," &
                       "'" & txtNombres.Text & "'," &
                       "'" & txtPuesto.Text & "'," &
                       "'" & txtDepartamento.Text & "'," &
                       "'" & cmbMotivo.SelectedValue & "'," &
                       "'" & FechaSQL(dtimeFecha.Value) & "'," &
                       "'" & FechaSQL(Date.Now) & "'," &
                       "'" & txtReloj.Text.ToString.Trim & "'," &
                       "'" & Usuario & "'," &
                       "'" & Environment.MachineName & "'," &
                       "'" & Environment.UserName & "'," &
                       "'" & Now.ToString("HH:mm:ss") & "'," &
                       "'" & txtComentSupervisor.Text & "'," &
                       "'" & txtComentEmpleado.Text & "'," &
                       "'" & dtInfo.Rows(0)("COD_COMP") & "'," &
                       "'" & txtPDF.Text & "')"
                End If

                sqlExecute(String.Format(strqry, campos))

                '== Si es nuevo registro, validar que se agregó
                If Not editarInfo AndAlso sqlExecute("SELECT * FROM PERSONAL.dbo.presentacion_quejas WHERE FOLIO='" & folio & "'").Rows.Count = 0 Then
                    MessageBox.Show("Ha ocurrido un error durante el registro. Por favor, vuelva intentarlo. Si el problema persiste, contacte al administrador del sistema.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                '== Confirmación de registro agregado/editado
                MessageBox.Show("Se ha " & IIf(editarInfo, "editado", "agregado") & " el registro con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Por favor, complete toda la información requerida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtimeFecha_MonthCalendar_DateChanged(sender As Object, e As EventArgs) Handles dtimeFecha.MonthCalendar.DateChanged
        If dtimeFecha.Text > Today Then
            MessageBox.Show("No es posible seleccionar fechas posteriores al dia de hoy", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtimeFecha.Text = Today
        End If
    End Sub

    Private Sub btnSubirPDF_Click(sender As Object, e As EventArgs) Handles btnSubirPDF.Click
        Try
            Dim File As New OpenFileDialog
            Dim ruta_origen As String = ""
            Dim ruta_destino As String = ""

            ruta_destino = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"

            File.Title = "Abrir..."
            File.Multiselect = False
            File.Filter = "PDF Files(*.pdf)|*.pdf|All Files(*.*)|*.*"
            Dim rs As DialogResult = File.ShowDialog()

            If rs = Windows.Forms.DialogResult.OK Then
                ruta_origen = File.FileName
                Dim newNameFile As String = ruta_origen.Trim.Split("\").Last()
                newNameFile = newNameFile.Replace(".pdf", "")
                newNameFile = newNameFile.Trim & "_" + folio.ToString.Trim & "_" & txtReloj.Text.ToString.Trim & ".pdf"

                Dim ruta_sin_file As String = ruta_origen.Replace(ruta_origen.Trim.Split("\").Last(), "")
                ruta_destino = ruta_sin_file & newNameFile

                My.Computer.FileSystem.CopyFile(ruta_origen, ruta_destino, True)
                txtPDF.Text = ruta_destino
            End If

            '---- Guardar Ruta para tomarla de ahi
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnVerPDF_Click(sender As Object, e As EventArgs) Handles btnVerPDF.Click
        '---Tomar ruta de la BD para mandarlo a RutaPDF
        Dim pdfVer As New frmVisualizaPDF
        Dim RutaPDF As String = txtPDF.Text.Trim
        '----Validar si el archivo existe
        If System.IO.File.Exists(RutaPDF) = False Then
            MessageBox.Show("El archivo '" & RutaPDF & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            BotonVisualizaPDF(RutaPDF, pdfVer)
        End If
    End Sub

    Public Function BotonVisualizaPDF(rutaPDF As String, ByVal forma As frmVisualizaPDF) As Boolean
        Try
            '== Mostrar la forma con el PDF
            forma.AxAcroPDF1.src = rutaPDF
            forma.Show()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Info. para controles del empleado que se buscó
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                dtInfo = sqlExecute("SELECT RELOJ,RTRIM(NOMBRES) AS NOMBRES," &
                                        "(RTRIM(COD_PUESTO) + ', ' + RTRIM(nombre_puesto)) AS PUESTO," &
                                        "(RTRIM(COD_DEPTO) + ', ' + RTRIM(nombre_depto)) AS DEPARTAMENTO, " &
                                        "COD_PLANTA,COD_COMP " &
                                        "FROM PERSONAL.dbo.personalvw WHERE reloj='" & Reloj.ToString.Trim & "'")

                txtNoReloj.Text = Reloj.ToString.Trim

                If dtInfo.Rows.Count > 0 Then
                    txtNombres.Text = dtInfo.Rows(0)("NOMBRES")
                    txtPuesto.Text = dtInfo.Rows(0)("PUESTO")
                    txtDepartamento.Text = dtInfo.Rows(0)("DEPARTAMENTO")
                Else
                    txtNombres.Text = "" : txtPuesto.Text = "" : txtDepartamento.Text = ""
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class