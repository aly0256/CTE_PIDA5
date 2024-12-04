Imports System.IO
Imports System.Data.OleDb

Public Class frmExcepcionesHorariosMasivos

    Dim sArchivo As String = ""


    Public tipo_ajuste As String

    Private Sub btnBuscaArchivo_Click(sender As Object, e As EventArgs) Handles btnBuscaArchivo.Click

        Dim ofd As New OpenFileDialog


        Try
            ofd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            ofd.Filter = "Excel(CSV)|*.CSV"
            ofd.Title = "Seleccione el Archivo a importar"
            ofd.Multiselect = False
            ofd.RestoreDirectory = True

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then

                sArchivo = ofd.FileName.ToString.Trim
                btnAceptar.Enabled = True
                cpActualizacion.Visible = False
                txtArchivo.Text = Path.GetFileName(sArchivo)

                dgvLog.Rows.Clear()
            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un problema al intentar abrir el archivo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmExcepcionesHorariosMasivos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmExcepcionesHorariosMasivos_Load(sender As Object, e As EventArgs) Handles Me.Load

        If tipo_ajuste = "t_completos" Then
            Me.Text = "Tiempos completos masivos"
            ReflectionLabel1.Text = "<b>Tiempos completos masivos</b>"
            lblFormato.Text = "Buscar en archivo (.csv) [RELOJ][FECHA]"
        Else
            Me.Text = "Excepciones de horario masivas"
            ReflectionLabel1.Text = "<b>Excepciones de horario masivas</b>"
            lblFormato.Text = "Buscar en archivo (.csv) [RELOJ][FECHA_EXCEPCION][CODIGO_EXCEPCION][COMENTARIO]"
        End If


        dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        cpActualizacion.Visible = False
        btnAceptar.Enabled = False
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If tipo_ajuste = "excepciones" Then

        ElseIf tipo_ajuste = "t_completos" Then

        End If

        Dim conn As OleDbConnection = Nothing
        Dim dtExcepcionesHorariosMasivos As New DataTable
        Dim dtCargarExcepciones As New DataTable
        Dim EsError As Boolean = True
        Dim strSql As String = ""
        Dim i As Integer = 0
        Dim fila As Integer = 1
        Dim nRegistrosCargados As Integer = 0

        Try

            Dim strConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Path.GetDirectoryName(sArchivo) & ";Extended Properties='text;HDR=Yes;FMT=Delimited;CharacterSet=65001;'"

            Try
                cpActualizacion.Text = ""
                cpActualizacion.Value = 0

                If dgvLog.Rows.Count > 0 Then
                    dgvLog.Rows.Clear()
                End If

                conn = New OleDbConnection(strConnString)

                conn.Open()

                Dim query = "SELECT * FROM [" + Path.GetFileName(sArchivo) + "]"

                Dim da As New OleDbDataAdapter(query, conn)

                da.Fill(dtExcepcionesHorariosMasivos)
                da.Dispose()

                EsError = False

            Catch ex As Exception
                EsError = True
                cpActualizacion.Text = "Error"
                btnAceptar.Enabled = False
                MessageBox.Show("Se presentó un error al intentar importar las excepciones de horarios masivos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

                conn.Close()
                conn.Dispose()
            End Try

            If Not EsError Then

                If Not dtExcepcionesHorariosMasivos.Columns.Contains("RELOJ") Then
                    MessageBox.Show("No se encontró el encabezado 'RELOJ'", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If tipo_ajuste = "excepciones" Then
                    If Not dtExcepcionesHorariosMasivos.Columns.Contains("FECHA_EXCEPCION") Then
                        MessageBox.Show("No se encontró el encabezado 'FECHA_EXCEPCION'", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    If Not dtExcepcionesHorariosMasivos.Columns.Contains("CODIGO_EXCEPCION") Then
                        MessageBox.Show("No se encontró el encabezado 'CODIGO_EXCEPCION'", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    If Not dtExcepcionesHorariosMasivos.Columns.Contains("COMENTARIO") Then
                        MessageBox.Show("No se encontró el encabezado 'COMENTARIO'", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If


                ElseIf tipo_ajuste = "t_completos" Then
                    If Not dtExcepcionesHorariosMasivos.Columns.Contains("FECHA") Then
                        MessageBox.Show("No se encontró el encabezado 'FECHA'", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

               


                cpActualizacion.Text = "Procesando..."
                cpActualizacion.Visible = True
                cpActualizacion.Maximum = dtExcepcionesHorariosMasivos.Rows.Count

                For Each dRow As DataRow In dtExcepcionesHorariosMasivos.Rows

                    fila = fila + 1

                    If tipo_ajuste = "excepciones" Then

                        'EXCEPCIONES DE HORARIO (PROCEDIMIENTO HECHO POR LUIS ANDRADE)

                        Dim reloj As String = Trim(IIf(IsDBNull(dRow("RELOJ")), "", dRow("RELOJ"))).PadLeft(6, "0")
                        ' Dim fecha_excepcion As String = FechaSQL(CDate(Trim(IIf(IsDBNull(dRow("FECHA_EXCEPCION")), "0001-01-01", dRow("FECHA_EXCEPCION"))).Replace("*", "")))
                        Dim fecha_excepcion As String = Trim(IIf(IsDBNull(dRow("FECHA_EXCEPCION")), "0001-01-01", dRow("FECHA_EXCEPCION"))).Replace("*", "")
                        Dim codigo_excepcion As String = Trim(IIf(IsDBNull(dRow("CODIGO_EXCEPCION")), "", dRow("CODIGO_EXCEPCION"))).Replace("*", "")
                        Dim comentarios As String = Trim(IIf(IsDBNull(dRow("COMENTARIO")), "", dRow("COMENTARIO")))

                        If Val(reloj) = 0 Then
                            dgvLog.Rows.Add({"RELOJ", "Campo vacío", fila})
                            Continue For
                        ElseIf Not reloj.Length = 6 Then
                            dgvLog.Rows.Add({"RELOJ", "Reloj no válido.", fila})
                            Continue For
                        End If

                        If Not IsDate(fecha_excepcion) Then
                            dgvLog.Rows.Add({"FECHA_EXCEPCION", "Formato de fecha incorrecto.", fila})
                            Continue For
                        ElseIf fecha_excepcion = "0001-01-01" Then
                            dgvLog.Rows.Add({"FECHA_EXCEPCION", "Campo de fecha vacío.", fila})
                            Continue For
                        End If

                        If codigo_excepcion.Trim = "" Then
                            dgvLog.Rows.Add({"CODIGO_EXCEPCION", "Campo vacío.", fila})
                            Continue For
                        ElseIf Not codigo_excepcion.Trim.Length = 3 Then
                            dgvLog.Rows.Add({"CODIGO_EXCEPCION", "Valor incorrecto.", fila})
                            Continue For
                        End If

                        codigo_excepcion = codigo_excepcion.PadLeft(3, "0")

                        If comentarios = "" Then
                            comentarios = "Carga Masiva " & Usuario
                        End If

                        strSql = "declare @reloj char(6) = '" & reloj & "'" & vbCr & _
                            "declare @fecha_excepcion varchar(10) = '" & FechaSQL(CDate(fecha_excepcion)) & "'" & vbCr & _
                            "declare @codigo_excepcion char(3) = '" & codigo_excepcion & "'" & vbCr & _
                            "declare @usuario varchar(max) = '" & Usuario & "'" & vbCr & _
                            "declare @comentarios varchar(max) = '" & comentarios & "'" & vbCr & _
                            "declare @existe_excepcion_dias as bit = 0" & vbCr & _
                            "" & vbCr & _
                            "set @existe_excepcion_dias = coalesce((select top 1 1 from personal inner join excepciones_dias " & vbCr & _
                            "on personal.cod_comp = excepciones_dias.cod_comp and excepciones_dias.cod_hora = @codigo_excepcion" & vbCr & _
                            "where reloj = @reloj),0) " & vbCr & _
                            "if  @existe_excepcion_dias = 1" & vbCr & _
                            "begin" & vbCr & _
                            "" & vbCr & _
                            "delete from excepciones_horarios where reloj = @reloj and fecha = @fecha_excepcion" & vbCr & _
                            "" & vbCr & _
                            "insert into excepciones_horarios" & vbCr & _
                            "select excepcion.* from (select COD_COMP,RELOJ, @codigo_excepcion as COD_HORA ,COD_HORA as COD_HORA_PERSONAL, @fecha_excepcion as FECHA, convert(date,GETDATE()) as FECHA_CAPTURA, " & vbCr & _
                            "NULL as FECHA_ANALISIS,convert(time(0),getdate()) as HORA_CAPTURA, @usuario as USUARIO, @comentarios as COMENTARIO, NULL as USUARIO_ANALISIS " & vbCr & _
                            "from personal ) excepcion inner join excepciones_dias on excepcion.COD_COMP = excepciones_dias.COD_COMP and excepcion.COD_HORA = excepciones_dias.COD_HORA" & vbCr & _
                            "where reloj = @reloj " & vbCr & _
                            "" & vbCr & _
                            "end" & vbCr & _
                            "" & vbCr & _
                            "select * from excepciones_horarios where reloj = @reloj and cod_hora = @codigo_excepcion and  fecha = @fecha_excepcion"


                        dtCargarExcepciones = sqlExecute(strSql)

                        If Not dtCargarExcepciones.Columns.Contains("ERROR") Then

                            If dtCargarExcepciones.Rows.Count > 0 Then
                                nRegistrosCargados = nRegistrosCargados + 1

                            Else
                                dgvLog.Rows.Add({"HORARIO", "No Insertado. No es válido para excepción.", fila})
                            End If

                            If FechaSQL(CDate(fecha_excepcion)) <= FechaSQL(Now) Then
                                analisis_independiente(reloj, FechaSQL(CDate(fecha_excepcion)))
                            End If

                        Else
                            dgvLog.Rows.Add({"NA", "Error al intentar cargar los datos.", 0})
                        End If

                    ElseIf tipo_ajuste = "t_completos" Then
                        'TIEMPOS COMPLETOS (PROCEDIMIENTO HECHO POR ABRAHAM CASAS)

                        Try
                            Dim _reloj_t_completo As String = RTrim(dRow("RELOJ")).PadLeft(6, "0")
                            Dim _fecha_t_completo As String = FechaSQL(dRow("FECHA"))

                            Dim dtTiempoCompleto As DataTable = sqlExecute("select * from ta.dbo.TiempoCompleto where reloj = '" & _reloj_t_completo & "' and fecha = '" & _fecha_t_completo & "'", "TA")
                            If dtTiempoCompleto.Rows.Count <= 0 Then

                                sqlExecute("insert into ta.dbo.TiempoCompleto (reloj, fecha, usuario, registro) values ('" & _reloj_t_completo & "', '" & _fecha_t_completo & "', '" & Usuario & "', getdate())")

                                analisis_independiente(_reloj_t_completo, _fecha_t_completo)

                            Else
                                dgvLog.Rows.Add({"NA", "Ya existe tiempo completo :" & _reloj_t_completo, i})
                            End If

                        Catch ex As Exception
                            dgvLog.Rows.Add({"NA", "Error en linea:" & i, i})
                        End Try

                    End If


                    i = i + 1
                    cpActualizacion.Value = i

                    Application.DoEvents()
                Next

                cpActualizacion.Text = "Finalizado..."

                MessageBox.Show("Se cargaron: " & nRegistrosCargados & " de " & dtExcepcionesHorariosMasivos.Rows.Count, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar importar las excepciones de horarios masivos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub
End Class