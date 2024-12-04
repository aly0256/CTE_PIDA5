Imports System.IO

Public Class frmCapturaIdeas
    Dim dtRegistro As New DataTable
    Dim dtEstatus As New DataTable
    Dim dtLista As New DataTable
    Dim dtEstaciones As New DataTable
    Dim dtareas As New DataTable
    Dim DesdeGrid As Boolean
    Dim BuscaGrid As String

    Dim CodigoCompania As String
    Dim CodigoDepartamento As String
    Dim CodigoSuper As String
    Dim CodigoPuesto As String
    Dim CodigoArea As String
    Dim CodigoPlanta As String

    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim FiltroImagenes As String = "Todos los archivos de imagen|*.png;*.bmp;*.jpg;*.gif;*.pdf;|Archivos PNG (*.png)|*.png|Archivos Bitmap (*.bmp)|*.bmp|" & _
        "Archivos JPEG (*.jpg)|*.jpg|Archivos GIF (*.gif)|*.gif|Archivos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*" '---filtros modificados ; chuy




    Private Sub frmCapturaIdeas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmCapturaIdeas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtObjetivos As New DataTable
        Dim dtDesperdicios As New DataTable
        Try
            dtLista = sqlExecute("select Folio,ideas_empleado.nombre as 'Título',ideas_empleado.Reloj," & _
                                 "RTRIM(PERSONAL.nombre) + ' ' + RTRIM(personal.apaterno) AS 'Nombre empleado'," & _
                                 "RTRIM(estaciones_trabajo.nombre) AS 'Estación',Fecha from ideas_empleado " & _
                                 "LEFT JOIN estaciones_trabajo ON " & _
                                 "ideas_empleado.cod_estacion = estaciones_trabajo.cod_estacion " & _
                                 "LEFT JOIN PERSONAL.dbo.personal ON ideas_empleado.reloj = personal.reloj " & _
                                 "ORDER BY folio", "IDEAS")
            dtLista.DefaultView.Sort = "Folio"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgTabla.Columns(1).MinimumWidth = 100
            dgTabla.Columns(2).Width = 70
            dgTabla.Columns(3).Width = 200
            dgTabla.Columns(4).Width = 150
            dgTabla.Columns(5).Width = 75

            dtEstatus.Columns.Add("cod_estatus")
            dtEstatus.Columns.Add("nombre")

            dtEstatus.Rows.Add({"I", "IMPLEMENTADA"})
            'dtEstatus.Rows.Add({"C", "CANCELADA"})

            cmbEstatus.DataSource = dtEstatus

            dtObjetivos = sqlExecute("SELECT * FROM objetivos where activo = 'true' ORDER BY nombre", "IDEAS")
            tknObjetivos.DropDownHeight = 20
            For Each dRow As DataRow In dtObjetivos.Rows
                tknObjetivos.Tokens.Add(New DevComponents.DotNetBar.Controls.EditToken(dRow("cod_objetivo").ToString.Trim, dRow("nombre").ToString.Trim))
                tknObjetivos.DropDownHeight = tknObjetivos.DropDownHeight + 20
            Next

            dtDesperdicios = sqlExecute("SELECT * FROM desperdicios ORDER BY nombre", "IDEAS")
            For Each dRow As DataRow In dtDesperdicios.Rows
                tknDesperdicio.Tokens.Add(New DevComponents.DotNetBar.Controls.EditToken(dRow("cod_desperdicio").ToString.Trim, dRow("nombre").ToString.Trim))
            Next

            cmbTipoIdea.SelectedItem = itPreventiva

            dtEstaciones = sqlExecute("SELECT cod_estacion,rtrim(nombre) as nombre FROM estaciones_trabajo ORDER BY nombre", "IDEAS")
            cmbEstaciones.DataSource = dtEstaciones


            dtareas = sqlExecute("select cod_area, rtrim(nombre) as nombre from areas where cod_comp = '610' order by nombre asc", "PERSONAL")
            cmbAreas.DataSource = dtareas

            If Not Directory.Exists(PathFoto & "IDEAS\") Then
                MkDir(PathFoto & "IDEAS\")
            End If

            btnUltimo.PerformClick()


            Try
                Dim dtTemp As DataTable
                Dim capturar As Boolean
                dtTemp = sqlExecute("SELECT captura_ideas from perfiles where captura_ideas='1' and cod_perfil " & Perfil, "SEGURIDAD")
                capturar = False
                If dtTemp.Rows.Count > 0 Then
                    capturar = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("captura_ideas")), False, dtTemp.Rows.Item(0).Item("captura_ideas") = 1)
                End If
                btnNuevo.Visible = capturar
                btnEditar.Visible = capturar
                btnBorrar.Visible = capturar
            Catch ex As Exception

            End Try


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub tknObjetivos_Resize(sender As Object, e As EventArgs) Handles tknObjetivos.Resize
        Try
            tknDesperdicio.Top = tknObjetivos.Top + tknObjetivos.Height + 5
            lblDesperdicio.Top = tknDesperdicio.Top
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Function NuevaImagen(ByVal Archivo As String) As DevComponents.DotNetBar.ButtonItem
        Dim btnImagen As New DevComponents.DotNetBar.ButtonItem
        Dim btnMenu As New DevComponents.DotNetBar.ButtonItem
        'Dim pdf As String
        'pdf = ("\\pida-fs01\brp\fotos\IDEAS\PDFima.jpg")
        'Dim archivo2 As String
        '' Dim btnDoc As WebBrowser


        Try
            Dim i As Integer

            If File.Exists(Archivo) = False Then
                Return Nothing
            End If

            i = Archivo.LastIndexOf("\")
            If i < 0 Then
                Return Nothing
            End If



            If Archivo.Contains(".pdf") Then
                btnImagen.Image = My.Resources.PDFima
            Else
                btnImagen.Image = CType(Image.FromFile(Archivo, True), Bitmap)

                '    Archivo = pdf
            End If


            btnImagen.ImageFixedSize = New System.Drawing.Size(100, 100)
            btnImagen.Name = "btn" & itmFotografias.SubItems.Count
            btnImagen.OptionGroup = "chart"
            btnImagen.Tooltip = Archivo.Substring(i + 1)
            btnImagen.ImagePaddingHorizontal = 10
            btnImagen.ImagePaddingHorizontal = 10
            btnImagen.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            btnImagen.AutoCheckOnClick = True




            btnMenu = New DevComponents.DotNetBar.ButtonItem
            btnMenu.Text = "Copiar"
            btnMenu.Image = My.Resources.copy_16
            AddHandler btnMenu.Click, AddressOf CopyImage
            btnImagen.SubItems.Add(btnMenu)

            btnMenu = New DevComponents.DotNetBar.ButtonItem
            btnMenu.Text = "Borrar"
            btnMenu.Image = My.Resources.DeleteRec
            AddHandler btnMenu.Click, AddressOf Borrar
            btnImagen.SubItems.Add(btnMenu)

            btnMenu = New DevComponents.DotNetBar.ButtonItem
            btnMenu.Text = "Guardar como..."
            btnMenu.Image = My.Resources.Save_as16
            AddHandler btnMenu.Click, AddressOf GuardarComo
            btnImagen.SubItems.Add(btnMenu)


            btnMenu = New DevComponents.DotNetBar.ButtonItem
            btnMenu.Text = "Cerrar"
            btnMenu.BeginGroup = True
            btnImagen.SubItems.Add(btnMenu)

            AddHandler btnImagen.DoubleClick, AddressOf ZoomImagen
            AddHandler btnImagen.PopupOpen, AddressOf btnPopupOpen
            Return btnImagen
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub CopyImage(sender As Object, e As EventArgs)
        Clipboard.Clear()
        Clipboard.SetImage(sender.parent.Image)
    End Sub

    Private Sub GuardarComo(sender As Object, e As EventArgs)
        Dim Archivo As String
        Try
            Archivo = sender.parent.ToolTip

            sveDialog.FileName = Archivo
            sveDialog.Filter = FiltroImagenes
            If sveDialog.ShowDialog <> DialogResult.Cancel Then
                FileCopy(PathFoto & "IDEAS\" & Archivo, sveDialog.FileName)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAgregarImagen_Click(sender As Object, e As EventArgs) Handles btnAgregarImagen.Click
        Dim GuardaArchivo As String
        Dim NombreArchivo As String

        Dim dtLista As DataTable
        Dim i As Integer
        Dim btnImagen As New DevComponents.DotNetBar.ButtonItem
        Dim dtreloj As New DataTable
        '  txtReloj.Text = Reloj
        Reloj = txtReloj.Text

        If Reloj <> "" Then

            dtLista = sqlExecute("select Folio,ideas_empleado.nombre as 'Título',ideas_empleado.Reloj," & _
                                    "RTRIM(PERSONAL.nombre) + ' ' + RTRIM(personal.apaterno) AS 'Nombre empleado'," & _
                                    "RTRIM(estaciones_trabajo.nombre) AS 'Estación',Fecha from ideas_empleado " & _
                                    "LEFT JOIN estaciones_trabajo ON " & _
                                    "ideas_empleado.cod_estacion = estaciones_trabajo.cod_estacion " & _
                                    "LEFT JOIN PERSONAL.dbo.personal ON ideas_empleado.reloj = personal.reloj " & _
                                    "ORDER BY folio desc", "IDEAS")

            Try
                opnImagen.FileName = ""
                opnImagen.Filter = FiltroImagenes
                If opnImagen.ShowDialog <> DialogResult.Cancel Then
                    Dim Archivo As String
                    Archivo = opnImagen.FileName
                    i = Archivo.LastIndexOf("\")
                    If i < 0 Then
                        MessageBox.Show("El nombre de archivo es incorrecto. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    Dim f As New FileInfo(Archivo)
                    Dim Extension As String = f.Extension

                    Dim fecha As Date = Date.Now
                    Dim fecha_completa As String = fecha.Year & fecha.Month & fecha.Day & fecha.Hour & fecha.Minute & Reloj & Extension

                    ' NombreArchivo = Archivo.Substring(i + 1) modificacion chuy 
                    NombreArchivo = fecha_completa
                    GuardaArchivo = PathFoto & "IDEAS\" & NombreArchivo      'Nombre de archivo a guardar
                    Try
                        FileCopy(Archivo, GuardaArchivo)
                    Catch ex As Exception
                        MessageBox.Show("El archivo no puede ser insertado. Favor de verificar." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub

                    End Try


                    btnImagen = NuevaImagen(GuardaArchivo)
                    If btnImagen Is Nothing Then Exit Sub

                    itmFotografias.SubItems.Add(btnImagen)
                    pnlFotografias.Refresh()
                End If
            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            End Try

        Else

            MessageBox.Show("Para insertar imagen seleccione un empleado", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub AgregarImagenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        btnAgregarImagen.PerformClick()
    End Sub

    Private Sub Borrar(sender As Object, e As EventArgs)
        Dim selItem As New DevComponents.DotNetBar.ButtonItem
        Try
            If sender Is btnBorrarImagen Then

                For Each sit As DevComponents.DotNetBar.ButtonItem In itmFotografias.SubItems
                    If sit.Checked Then
                        selItem = sit
                        Exit For
                    End If
                Next
            Else
                selItem = sender.parent
            End If


            If selItem.Tooltip <> "" Then
                If MessageBox.Show("¿Está seguro de remover la imagen " & selItem.Tooltip & " de la idea " & txtFolio.Text & "?", "Remover imagen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    itmFotografias.SubItems.Remove(selItem)
                    pnlFotografias.Refresh()
                End If
            Else
                Stop
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim Imagenes As String = ""
        Dim Objetivos As String = ""
        Dim Desperdicios As String = ""
        Dim TextoBlanco As String = ""
        Dim Objeto As Object = Nothing
        Dim Estacion As Integer
        Dim EstacionSTR As String
        Dim i As Integer
        Dim dIdea As DataRow
        Dim Activo As Boolean
        Dim Alta As Date
        Dim Baja As Date
        Dim tipo_periodo As String
        Try

            dtTemporal = sqlExecute("SELECT cod_periodo from ta.dbo.periodos_vacacionales where getdate() between fecha_ini and dateadd(DAY,1,fecha_fin) and activo = 1", "TA")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("La captura de ideas se encuentra restringida por periodo de shutdown.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                txtReloj.Focus()
                Exit Sub
            End If

            If Agregar Then
                ' Si Agregar, revisar ...

                If txtFolio.Text.Trim.Length = 0 Then
                    TextoBlanco = "El número de folio"
                    Objeto = txtFolio
                ElseIf txtReloj.Text.Trim.Length = 0 Then
                    TextoBlanco = "El número de reloj del empleado"
                    Objeto = txtReloj
                    'ElseIf txtProblema.Text.Trim.Length = 0 Then
                    '    TextoBlanco = "El problema"
                    '    Objeto = txtProblema
                    'ElseIf txtIdea.Text.Trim.Length = 0 Then
                    '    TextoBlanco = "La idea"
                    '    Objeto = txtIdea
                    'ElseIf txtResultado.Text.Trim.Length = 0 Then
                    '    TextoBlanco = "El Resultado"
                    '    Objeto = txtResultado
                ElseIf txtTitulo.Text.Trim.Length = 0 Then
                    TextoBlanco = "El titulo de la idea"
                    Objeto = txtTitulo
                ElseIf tknObjetivos.SelectedTokens.Count = 0 Then
                    TextoBlanco = "El objetivo de la idea"
                    Objeto = tknObjetivos
                ElseIf cmbEstaciones.Text.Trim = "" Then
                    TextoBlanco = "La estación donde se implementa la idea"
                    Objeto = cmbEstaciones
                ElseIf cmbareas.Text.Trim = "" Then
                    TextoBlanco = "El área donde se implementa la idea"
                    Objeto = cmbareas
                    'ElseIf rtCalificacion.Rating < 1 Then
                    '    TextoBlanco = "La calificación"                    
                End If


                If TextoBlanco.Trim.Length > 0 Then
                    MessageBox.Show(TextoBlanco & " no puede quedar en blanco. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Objeto.focus()
                    Exit Sub
                End If

                dtTemporal = ConsultaPersonalVW("SELECT reloj,alta,baja, tipo_periodo FROM personal WHERE reloj = '" & txtReloj.Text.Trim & "'")
                If dtTemporal.Rows.Count = 0 Then
                    MessageBox.Show("El número de reloj " & txtReloj.Text.Trim & " no fue localizado, o el usuario no tiene acceso a su información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtReloj.Focus()
                    Exit Sub
                Else
                    Activo = True

                    If dtFecha.ValueObject Is Nothing Then
                        Activo = IsDBNull(dtTemporal.Rows(0).Item("baja"))
                    Else
                        Alta = dtTemporal.Rows(0).Item("alta")

                        If IsDBNull(dtTemporal.Rows(0).Item("baja")) Then
                            Baja = DateSerial(2099, 1, 1)
                        Else
                            Baja = dtTemporal.Rows(0).Item("baja")
                        End If

                        If Alta > dtFecha.Value Or Baja < dtFecha.Value Then
                            Activo = False
                        End If

                    End If

                    If Not Activo Then
                        MessageBox.Show("El empleado " & txtReloj.Text.Trim & " no está activo en la fecha indicada. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtReloj.Focus()
                        Exit Sub
                    End If

                    '     tipo_periodo = dtTemporal.Rows(0).Item("tipo_periodo")
                End If



                dtTemporal = sqlExecute("SELECT folio FROM ideas_empleado where folio = '" & txtFolio.Text & "'", "IDEAS")
                'dtTemporal = sqlExecute("SELECT MAX(folio)+1 as folio2 FROM ideas_empleado", "IDEAS")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe la idea con folio '" & txtFolio.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtFolio.Focus()
                    Exit Sub
                Else
                    Dim dtFolioNuevo = sqlExecute("SELECT MAX(Substring(folio,2,9))+1 as folio_nuevo FROM ideas_empleado", "IDEAS")
                    If dtFolioNuevo.Rows.Count > 0 Then
                        '                           "padaga= '" & ObtenerAnoPeriodo(Date.Now) & "'," & _
                        listarelojes = listarelojes & "," & txtReloj.Text
                        Dim lista As String() = listarelojes.Split(",")
                        For Each li As String In lista
                            If li.Length <= 1 Then
                                Continue For
                            Else
                                Dim temp As DataTable = sqlExecute("select * from personal where reloj = '" & li.Trim & "'")

                                tipo_periodo = IIf(IsDBNull(temp.Rows(0).Item("tipo_periodo")), "S", temp.Rows(0).Item("tipo_periodo"))
                                If tipo_periodo = "Q" Then
                                    sqlExecute("INSERT INTO ideas_empleado (folio, reloj,usuario,pagada, captura,USUARIO_WINDOWS,EQUIPO,colaboradores) VALUES ('" & dtFolioNuevo.Rows(0)("folio_nuevo").ToString.Trim.PadLeft(10, "0") & "','" & li.Trim & "', '" & Usuario & "', '" & obteneranoperiodocorte(Date.Now, tipo_periodo) & "','" & FechaHoraSQL(Now) & "','" + My.User.Name.ToString + "','" + My.Computer.Name.ToString + "','" & txtcola.Text & "')", "IDEAS")
                                Else
                                    sqlExecute("INSERT INTO ideas_empleado (folio, reloj,usuario,pagada, captura,USUARIO_WINDOWS,EQUIPO,colaboradores) VALUES ('" & dtFolioNuevo.Rows(0)("folio_nuevo").ToString.Trim.PadLeft(10, "0") & "','" & li.Trim & "', '" & Usuario & "', '" & ObtenerAnoPeriodo(Date.Now, tipo_periodo) & "','" & FechaHoraSQL(Now) & "','" + My.User.Name.ToString + "','" + My.Computer.Name.ToString + "','" & txtcola.Text & "')", "IDEAS")
                                End If
                            End If

                        Next
                        txtFolio.Text = dtFolioNuevo.Rows(0)("folio_nuevo").ToString.Trim.PadLeft(10, "0")
                    End If


                    Agregar = False
                End If
                Editar = True

            Else
                Agregar = True
            End If

            If Editar Then

                Imagenes = ""
                For Each sit As DevComponents.DotNetBar.ButtonItem In itmFotografias.SubItems
                    Imagenes = Imagenes & sit.Tooltip & ";"
                Next

                For Each tkn In tknObjetivos.SelectedTokens
                    Objetivos = Objetivos & IIf(Objetivos.Length > 0, ",", "") & tkn.Value
                Next

                For Each tkn In tknDesperdicio.SelectedTokens
                    Desperdicios = Desperdicios & IIf(Desperdicios.Length > 0, ",", "") & tkn.Value
                Next

                dtTemporal = sqlExecute("SELECT cod_estacion FROM estaciones_trabajo WHERE " & _
                                        "UPPER(nombre) = '" & cmbEstaciones.Text.Trim.ToUpper & "'", "IDEAS")
                If dtTemporal.Rows.Count = 0 Then
                    dtTemporal = sqlExecute("SELECT MAX(CAST(cod_estacion AS INTEGER)) FROM estaciones_trabajo", "IDEAS")
                    If dtTemporal.Rows.Count = 0 Then
                        Estacion = 0
                    Else
                        Estacion = CInt(IIf(IsDBNull(dtTemporal.Rows(0).Item(0)), 0, dtTemporal.Rows(0).Item(0)))
                    End If
                    Estacion += 1
                    EstacionSTR = Estacion.ToString.PadLeft(3, "0")
                    sqlExecute("INSERT INTO estaciones_trabajo (cod_estacion,nombre) VALUES ('" & _
                                EstacionSTR & "','" & _
                               cmbEstaciones.Text.Trim.ToUpper & "')", "IDEAS")

                    dtEstaciones.Rows.Add({EstacionSTR, cmbEstaciones.Text.Trim.ToUpper})
                    cmbEstaciones.SelectedValue = EstacionSTR
                End If

                ' Si Editar, entonces guardar cambios a registro
                Dim borrarcolaboradores As Boolean = False
                If listarelojes = "" Then
                    listarelojes = "," & txtReloj.Text
                    borrarcolaboradores = True
                End If
                Dim lista As String() = listarelojes.Split(",")
                For Each li As String In lista
                    If li.Length <= 1 Then
                        Continue For
                    Else
                        Dim dtinfoempleado As DataTable = sqlExecute("SELECT reloj,nombres,nombre_depto,cod_comp,cod_depto,cod_super,cod_puesto,cod_area,cod_planta,nombre_area,nombre_puesto,foto,alta,baja FROM personalVW WHERE reloj = '" & li.Trim & "'")
                        CodigoCompania = IIf(IsDBNull(dtinfoempleado.Rows(0).Item("cod_comp")), "", dtinfoempleado.Rows(0).Item("cod_comp").ToString.Trim)
                        CodigoDepartamento = IIf(IsDBNull(dtinfoempleado.Rows(0).Item("cod_depto")), "", dtinfoempleado.Rows(0).Item("cod_depto").ToString.Trim)
                        CodigoSuper = IIf(IsDBNull(dtinfoempleado.Rows(0).Item("cod_super")), "", dtinfoempleado.Rows(0).Item("cod_super").ToString.Trim)
                        CodigoPuesto = IIf(IsDBNull(dtinfoempleado.Rows(0).Item("cod_puesto")), "", dtinfoempleado.Rows(0).Item("cod_puesto").ToString.Trim)
                        CodigoArea = IIf(IsDBNull(dtinfoempleado.Rows(0).Item("cod_area")), "", dtinfoempleado.Rows(0).Item("cod_area").ToString.Trim)
                        If borrarcolaboradores Then
                            sqlExecute("UPDATE ideas_empleado SET " & _
                                  "fecha = '" & FechaSQL(dtFecha.Value) & "'," & _
                                  "nombre = '" & txtTitulo.Text.Trim.Replace("'", "''") & "'," & _
                                  "PROBLEMA = '" & txtProblema.Text.Trim.Replace("'", "''") & "'," & _
                                  "IDEA = '" & txtIdea.Text.Trim.Replace("'", "''") & "'," & _
                                  "RESULTADO = '" & txtResultado.Text.Trim.Replace("'", "''") & "'," & _
                                  "cod_estacion = '" & cmbEstaciones.SelectedValue & "'," & _
                                  "cod_area_a = '" & cmbareas.SelectedValue & "'," & _
                                  "cod_objetivo = '" & Objetivos & "'," & _
                                  "cod_desperdicio = '" & Desperdicios & "'," & _
                                  "estatus = '" & cmbEstatus.SelectedValue & "'," & _
                                  "calif = '" & IntegerInput1.Value & "'," & _
                                  "tipo = '" & IIf(cmbTipoIdea.Text = "PREVENTIVA", "P", "C") & "'," & _
                                  "implementacion = CASE 1 when " & IIf(cmbEstatus.SelectedValue = "I", 1, 2) & _
                                       " THEN GETDATE() ELSE implementacion END ," & _
                                  "aprobacion = CASE WHEN 1 = " & IIf(cmbEstatus.SelectedValue = "A", 1, _
                                                                      IIf(cmbEstatus.SelectedValue = "I", _
                                                                          "1 AND aprobacion IS NULL ", 2)) & _
                                               "THEN GETDATE() ELSE implementacion END ," & _
                                  "fotos = '" & Imagenes.Trim & "'," & _
                                  "calificacion = " & rtCalificacion.RatingValue & "" & _
                                  " WHERE folio = '" & txtFolio.Text.Trim & "'", "IDEAS")
                        Else
                            sqlExecute("UPDATE ideas_empleado SET " & _
                                  "fecha = '" & FechaSQL(dtFecha.Value) & "'," & _
                                  "nombre = '" & txtTitulo.Text.Trim.Replace("'", "''") & "'," & _
                                  "PROBLEMA = '" & txtProblema.Text.Trim.Replace("'", "''") & "'," & _
                                  "IDEA = '" & txtIdea.Text.Trim.Replace("'", "''") & "'," & _
                                  "RESULTADO = '" & txtResultado.Text.Trim.Replace("'", "''") & "'," & _
                                  "cod_estacion = '" & cmbEstaciones.SelectedValue & "'," & _
                                  "cod_area_a = '" & cmbareas.SelectedValue & "'," & _
                                  "cod_objetivo = '" & Objetivos & "'," & _
                                  "cod_desperdicio = '" & Desperdicios & "'," & _
                                  "estatus = '" & cmbEstatus.SelectedValue & "'," & _
                                  "calif = '" & IntegerInput1.Value & "'," & _
                                  "tipo = '" & IIf(cmbTipoIdea.Text = "PREVENTIVA", "P", "C") & "'," & _
                                  "implementacion = CASE 1 when " & IIf(cmbEstatus.SelectedValue = "I", 1, 2) & _
                                       " THEN GETDATE() ELSE implementacion END ," & _
                                  "aprobacion = CASE WHEN 1 = " & IIf(cmbEstatus.SelectedValue = "A", 1, _
                                                                      IIf(cmbEstatus.SelectedValue = "I", _
                                                                          "1 AND aprobacion IS NULL ", 2)) & _
                                               "THEN GETDATE() ELSE implementacion END ," & _
                                  "fotos = '" & Imagenes.Trim & "'," & _
                                  "calificacion = " & rtCalificacion.RatingValue & "," & _
                                   "cod_comp = '" & IIf(IsDBNull(CodigoCompania), "", CodigoCompania) & "'," & _
                                   "cod_depto = '" & IIf(IsDBNull(CodigoDepartamento), "", CodigoDepartamento) & "'," & _
                                   "cod_super = '" & IIf(IsDBNull(CodigoSuper), "", CodigoSuper) & "'," & _
                                   "cod_puesto = '" & IIf(IsDBNull(CodigoPuesto), "", CodigoPuesto) & "'," & _
                                   "cod_area = '" & IIf(IsDBNull(CodigoArea), "", CodigoArea.Trim) & "'," & _
                                   "cod_planta = '000'" & _
                                  " WHERE folio = '" & txtFolio.Text.Trim & "' and reloj = '" & li.Trim & "'", "IDEAS")
                        End If

                    End If
                Next
                Agregar = False

                i = dtLista.DefaultView.Find(txtFolio.Text.Trim)

                If i < 0 Then
                    dIdea = dtLista.NewRow
                    i = dtLista.Rows.Count - 1

                Else
                    dIdea = dtLista.Rows(i)
                End If

                dIdea("reloj") = txtReloj.Text
                dIdea("nombre empleado") = txtNombre.Text.Trim
                dIdea("título") = txtTitulo.Text.Trim
                dIdea("Estación") = cmbEstaciones.Text.Trim
                dIdea("Fecha") = dtFecha.Value

                dgTabla.FirstDisplayedScrollingRowIndex = i
                dgTabla.Rows(i).Selected = True
                listarelojes = ""
            End If
            Editar = False

            HabilitarBotones()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtReloj_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtReloj.ButtonCustomClick

    End Sub
    Sub InformacionEmpleado(ByVal Rl As String)
        Dim dtEmpleado As New DataTable
        Dim Alta As Date
        Dim Baja As Date
        Dim Activo As Boolean
        Try
            If txtReloj.Text <> Rl Then
                txtReloj.Text = Rl
            End If
            dtEmpleado = sqlExecute("SELECT reloj,nombres,nombre_depto,cod_comp,cod_depto,cod_super,cod_puesto,cod_area,cod_planta,nombre_area,nombre_puesto,foto,alta,baja FROM personalVW WHERE reloj = '" & Rl & "'")
            txtNombre.Text = ""
            txtDepartamento.Text = ""

            CodigoCompania = ""
            CodigoDepartamento = ""
            CodigoSuper = ""
            CodigoPuesto = ""
            CodigoArea = ""
            CodigoPlanta = ""
            txtPuesto.Text = ""
            txtArea.Text = ""
            picFoto.ImageLocation = ""

            If dtEmpleado.Rows.Count > 0 Then
                Activo = True

                If dtFecha.ValueObject Is Nothing Then
                    Activo = IsDBNull(dtEmpleado.Rows(0).Item("baja"))
                Else
                    Alta = dtEmpleado.Rows(0).Item("alta")

                    If IsDBNull(dtEmpleado.Rows(0).Item("baja")) Then
                        Baja = DateSerial(2099, 1, 1)
                    Else
                        Baja = dtEmpleado.Rows(0).Item("baja")
                    End If

                    If Alta > dtFecha.Value Or Baja < dtFecha.Value Then
                        Activo = False
                    End If
                End If

                lblEstado.Text = IIf(Not Activo, "INACTIVO", "ACTIVO")
                lblEstado.BackColor = IIf(Not Activo, Color.IndianRed, Color.LimeGreen)
                txtReloj.BackColor = lblEstado.BackColor


                txtNombre.Text = IIf(IsDBNull(dtEmpleado.Rows(0).Item("nombres")), "", dtEmpleado.Rows(0).Item("nombres").ToString.Trim)
                txtDepartamento.Text = IIf(IsDBNull(dtEmpleado.Rows(0).Item("nombre_depto")), "", dtEmpleado.Rows(0).Item("nombre_depto").ToString.Trim)

                CodigoCompania = IIf(IsDBNull(dtEmpleado.Rows(0).Item("cod_comp")), "", dtEmpleado.Rows(0).Item("cod_comp").ToString.Trim)
                CodigoDepartamento = IIf(IsDBNull(dtEmpleado.Rows(0).Item("cod_depto")), "", dtEmpleado.Rows(0).Item("cod_depto").ToString.Trim)
                CodigoSuper = IIf(IsDBNull(dtEmpleado.Rows(0).Item("cod_super")), "", dtEmpleado.Rows(0).Item("cod_super").ToString.Trim)
                CodigoPuesto = IIf(IsDBNull(dtEmpleado.Rows(0).Item("cod_puesto")), "", dtEmpleado.Rows(0).Item("cod_puesto").ToString.Trim)
                CodigoArea = IIf(IsDBNull(dtEmpleado.Rows(0).Item("cod_area")), "", dtEmpleado.Rows(0).Item("cod_area").ToString.Trim)
                CodigoPlanta = IIf(IsDBNull(dtEmpleado.Rows(0).Item("cod_planta")), "", dtEmpleado.Rows(0).Item("cod_planta").ToString.Trim)

                txtPuesto.Text = IIf(IsDBNull(dtEmpleado.Rows(0).Item("nombre_puesto")), "", dtEmpleado.Rows(0).Item("nombre_puesto").ToString.Trim)
                txtArea.Text = IIf(IsDBNull(dtEmpleado.Rows(0).Item("nombre_area")), "", dtEmpleado.Rows(0).Item("nombre_area").ToString.Trim)
                picFoto.ImageLocation = IIf(IsDBNull(dtEmpleado.Rows(0).Item("foto")), "", dtEmpleado.Rows(0).Item("foto").ToString.Trim)

                txtReloj.BackColor = SystemColors.Window
            ElseIf Rl.Length = 0 Then
                txtReloj.BackColor = SystemColors.Window
                picFoto.Image = picFoto.ErrorImage
            Else
                txtNombre.Text = "NO LOCALIZADO"
                txtReloj.BackColor = Color.Red
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtReloj_Validated(sender As Object, e As EventArgs) Handles txtReloj.Validated
        InformacionEmpleado(txtReloj.Text.Trim)
    End Sub

    Private Sub MostrarInformacion()
        Dim dIdea As DataRow
        Dim strFotos As String
        Dim Fotos() As String
        Dim Objetivos As String
        Dim Desperdicios As String
        Dim btnImagen As DevComponents.DotNetBar.ButtonItem
        Dim i As Integer

        Try
            If dtRegistro.Rows.Count > 0 Then
                dIdea = dtRegistro.Rows(0)
                txtFolio.Text = dIdea("folio").ToString.Trim
                dtFecha.ValueObject = dIdea("fecha")
                cmbEstatus.SelectedValue = IIf(IsDBNull(dIdea("estatus")), "", dIdea("estatus"))
                rtCalificacion.RatingValue = CInt(IIf(IsDBNull(dIdea("calificacion")), 0, dIdea("calificacion")))
                InformacionEmpleado(dIdea("reloj").ToString.Trim)
                txtTitulo.Text = IIf(IsDBNull(dIdea("nombre")), "", dIdea("nombre")).ToString.Trim
                txtProblema.Text = IIf(IsDBNull(dIdea("PROBLEMA")), "", dIdea("PROBLEMA")).ToString.Trim
                txtIdea.Text = IIf(IsDBNull(dIdea("IDEA")), "", dIdea("IDEA")).ToString.Trim
                txtResultado.Text = IIf(IsDBNull(dIdea("RESULTADO")), "", dIdea("RESULTADO")).ToString.Trim
                txtRedaccion.Text = IIf(IsDBNull(dIdea("descripcion")), "", dIdea("descripcion")).ToString.Trim
                IntegerInput1.Value = IIf(IsDBNull(dIdea("calif")), 0, dIdea("calif"))
                txtcola.Text = IIf(IsDBNull(dIdea("colaboradores")), 0, dIdea("colaboradores"))
                If IsDBNull(dIdea("tipo")) Then
                    cmbTipoIdea.SelectedValue = Nothing
                Else
                    cmbTipoIdea.SelectedValue = IIf(dIdea("tipo") = "P", "PREVENTIVA", "CORRECTIVA")

                End If
                cmbEstaciones.SelectedValue = IIf(IsDBNull(dIdea("cod_estacion")), "", dIdea("cod_estacion"))
                cmbAreas.SelectedValue = IIf(IsDBNull(dIdea("cod_area_a")), "", dIdea("cod_area_a"))

                tknObjetivos.ResetText()
                Objetivos = IIf(IsDBNull(dIdea("cod_objetivo")), "", dIdea("cod_objetivo")).ToString.Trim
                For Each tnk In tknObjetivos.Tokens
                    If Objetivos.Contains(tnk.Value) Then
                        tknObjetivos.SelectedTokens.Add(tnk)
                    End If
                Next

                tknDesperdicio.ResetText()
                Desperdicios = IIf(IsDBNull(dIdea("cod_desperdicio")), "", dIdea("cod_desperdicio")).ToString.Trim
                For Each tnk In tknDesperdicio.Tokens
                    If Desperdicios.Contains(tnk.Value) Then
                        tknDesperdicio.SelectedTokens.Add(tnk)
                    End If
                Next

                'tknObjetivos.SelectedTokens.Add()
                'tknDesperdicio.ResetText()
                dtFechaAprobacion.ValueObject = dIdea("aprobacion")
                dtFechaImplementacion.ValueObject = dIdea("implementacion")
                strFotos = IIf(IsDBNull(dIdea("fotos")), "", dIdea("fotos").ToString.Trim)
                Fotos = strFotos.Split(";")
                For x = 0 To itmFotografias.SubItems.Count - 1
                    itmFotografias.SubItems.RemoveAt(0)
                Next
                itmFotografias.SubItems.Clear()

                For Each foto In Fotos
                    If foto.Length > 0 Then
                        btnImagen = NuevaImagen(PathFoto & "IDEAS\" & foto)
                        If Not btnImagen Is Nothing Then

                            itmFotografias.SubItems.Add(btnImagen)
                        End If
                    End If
                Next
                'NOTA: El refresh debe ser desde el panel, si se hace desde el ItemContainer, 
                'y solo queda un elemento, no refresca y parece que queda un elemento
                pnlFotografias.Refresh()

                If IsDBNull(dIdea("envio_nomina")) Then
                    pnlPagada.Visible = False
                    lblPagada.Visible = False
                Else
                    pnlPagada.Visible = True
                    lblPagada.Visible = True

                    lblPeriodo.Text = dIdea("pagada").ToString.Substring(4, 2) & "/" & dIdea("pagada").ToString.Substring(0, 4)
                End If

                If Not DesdeGrid Then
                    i = dtLista.DefaultView.Find(txtFolio.Text.Trim)
                    If i >= 0 Then
                        dgTabla.FirstDisplayedScrollingRowIndex = i
                        dgTabla.Rows(i).Selected = True
                    End If
                End If
                DesdeGrid = False
            Else
                InfoEnBlanco()
            End If

            HabilitarBotones()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub InfoEnBlanco()
        Try
            lblEstado.Text = ""
            lblEstado.BackColor = lblEstado.Parent.BackColor
            txtcola.Text = "1"
            txtFolio.Text = ""
            dtFecha.Value = Now
            cmbEstatus.SelectedValue = "I"
            rtCalificacion.RatingValue = 0
            txtReloj.Text = ""
            txtNombre.Text = ""
            txtPuesto.Text = ""
            txtArea.Text = ""
            txtDepartamento.Text = ""
            CodigoCompania = ""
            CodigoDepartamento = ""
            CodigoSuper = ""
            CodigoPuesto = ""
            CodigoArea = ""
            CodigoPlanta = ""

            'cmbEstaciones.Text = ""
            picFoto.Image = picFoto.ErrorImage

            txtTitulo.Text = ""
            txtRedaccion.Text = ""
            txtProblema.Text = ""
            txtIdea.Text = ""
            txtResultado.Text = ""

            cmbTipoIdea.SelectedValue = Nothing
            tknObjetivos.ResetText()
            tknDesperdicio.ResetText()
            dtFechaAprobacion.Value = Now
            dtFechaImplementacion.Value = Now

            pnlPagada.Visible = False
            lblPagada.Visible = False


            For x = 0 To itmFotografias.SubItems.Count - 1
                itmFotografias.SubItems.RemoveAt(0)
            Next
            pnlFotografias.Refresh()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("ideas_empleado", "(folio)", dtRegistro, "ideas")
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("ideas_empleado", "(folio)", txtFolio.Text, dtRegistro, "ideas")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("ideas_empleado", "(folio)", txtFolio.Text, dtRegistro, "ideas")
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("ideas_empleado", "(folio)", dtRegistro, "ideas")
        MostrarInformacion()

    End Sub

    Private Sub HabilitarBotones()
        Dim NoRec As Boolean
        Try
            NoRec = dtRegistro.Rows.Count = 0
            ButtonX1.Enabled = Not (Editar Or NoRec)
            btnBuscarReloj.Enabled = Not (Editar Or NoRec)
            btnPrimero.Enabled = Not (Agregar Or Editar Or NoRec)
            btnAnterior.Enabled = Not (Agregar Or Editar Or NoRec)
            btnSiguiente.Enabled = Not (Agregar Or Editar Or NoRec)
            btnUltimo.Enabled = Not (Agregar Or Editar Or NoRec)

            btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)
            btnBuscar.Enabled = Not (Agregar Or Editar Or NoRec)
            btnBorrar.Enabled = Not (Agregar Or Editar Or NoRec)
            btnCerrar.Enabled = Not (Agregar Or Editar Or NoRec)
            pnlInfo.Enabled = Agregar Or Editar
            'rtCalificacion.Enabled = Agregar Or Editar
            IntegerInput1.Enabled = Agregar Or Editar
            Panel3.Enabled = Agregar Or Editar
            txtTitulo.Enabled = Agregar Or Editar
            txtRedaccion.Enabled = Agregar Or Editar
            txtProblema.Enabled = Agregar Or Editar
            txtIdea.Enabled = Agregar Or Editar
            txtResultado.Enabled = Agregar Or Editar
            pnlDetalle.Enabled = Agregar Or Editar
            pnlFechas.Enabled = Agregar Or Editar
            pnlPagada.Enabled = Agregar Or Editar
            pnlEncabezadoFoto.Enabled = Agregar Or Editar

            btnEditar.Enabled = Not (Not (Editar Or Agregar) And NoRec)

            'Dim dtTemp As DataTable
            'Dim capturar As Boolean
            'dtTemp = sqlExecute("SELECT * from perfiles where captura_ideas='1'", "SEGURIDAD")
            'capturar = False
            'If dtTemp.Rows.Count > 0 Then
            '    capturar = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("captura_ideas")), False, dtTemp.Rows.Item(0).Item("captura_ideas") = 1)
            'End If
            'btnNuevo.Visible = capturar

            If Agregar Or Editar Then
                ' Si está activa la edición o nuevo registro
                btnNuevo.Image = My.Resources.Ok16
                btnEditar.Image = My.Resources.CancelX
                btnNuevo.Text = "Aceptar"
                btnEditar.Text = "Cancelar"
                tabBuscar.SelectedTabIndex = 0

            Else

                btnNuevo.Image = My.Resources.NewRecord
                btnEditar.Image = My.Resources.Edit

                btnNuevo.Text = "Agregar"
                btnEditar.Text = "Editar"
            End If


            ' - txtFolio.Enabled = Agregar

            If Agregar Then
                InfoEnBlanco()
                'txtFolio.Focus()
                'Dim dtFolioNuevo = sqlExecute("SELECT MAX(folio)+1 as folio_nuevo FROM ideas_empleado", "IDEAS")
                'If dtFolioNuevo.Rows.Count > 0 Then
                '    txtFolio.Text = dtFolioNuevo.Rows(0)("folio_nuevo").ToString.Trim.PadLeft(10, "0")
                txtFolio.Text = "Captura"
                txtFolio.TextAlign = HorizontalAlignment.Center
                'End If

            ElseIf Editar Then
                dtFecha.Focus()
            End If

            lblEstado.Enabled = True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If Not Editar And Not Agregar Then
                dtRegistro = sqlExecute("SELECT * FROM ideas_empleado WHERE folio = '" & txtFolio.Text.Trim & "'", "IDEAS")
                Editar = True
                dtFecha.Focus()
            ElseIf Editar Then
                dtRegistro = sqlExecute("SELECT * FROM ideas_empleado WHERE folio = '" & txtFolio.Text.Trim & "'", "IDEAS")
                Editar = False
            Else
                Editar = False
            End If
            Agregar = False
            HabilitarBotones()
            MostrarInformacion()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            Dim i As Integer
            Dim dtValida As New DataTable
            dtValida = sqlExecute("SELECT envio_nomina FROM ideas_empleado WHERE folio = '" & txtFolio.Text & "'", "IDEAS")
            If dtValida.Rows.Count = 0 Then
                MessageBox.Show("La idea " & txtFolio.Text & " no fue localizada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If IIf(IsDBNull(dtValida.Rows(0).Item("envio_nomina")), "", dtValida.Rows(0).Item("envio_nomina")) = "" Then
                    If MessageBox.Show("¿Está seguro de borrar la idea con folio " & txtFolio.Text.Trim & "?", "Borrar idea", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                        sqlExecute("DELETE FROM ideas_empleado WHERE folio = '" & txtFolio.Text & "'", "IDEAS")

                        i = dtLista.DefaultView.Find(txtFolio.Text.Trim)

                        If i >= 0 Then
                            dtLista.Rows.RemoveAt(i)
                        End If
                        btnSiguiente.PerformClick()
                    End If
                Else
                    MessageBox.Show("La idea " & txtFolio.Text & " ya fue pagada, por lo que no se puede eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ZoomImagen(sender As Object, e As EventArgs) ',byval Archivo as string de chuy


        Try

            If sender.tooltip.ToString.Contains(".pdf") Then 'intento chuy

                Process.Start(PathFoto & "IDEAS\" & sender.tooltip.ToString)
            Else

                frmZoom.Text = "Idea " & txtFolio.Text
                frmZoom.picImagen.ImageLocation = PathFoto & "IDEAS\" & sender.tooltip

                If Application.OpenForms().OfType(Of frmZoom).Any Then
                    frmZoom.Show()
                Else
                    frmZoom.ShowDialog(Me)
                End If

            End If




        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim bi As frmBuscaIdeas = New frmBuscaIdeas()
            bi.ShowDialog()
            Dim Folio As String
            Folio = bi.Folio 'Buscar("ideas.dbo.ideas_empleado", "folio", "IDEAS", False)
            If Folio <> "CANCELAR" Then
                dtRegistro = sqlExecute("SELECT * FROM ideas_empleado WHERE folio = '" & Folio & "'", "IDEAS")
                MostrarInformacion()
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub frmCapturaIdeas_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlCentrado.Left = (Me.Width - pnlCentrado.Width) / 2


    End Sub

    Private Sub rtCalificacion_RatingChanged(sender As Object, e As EventArgs) Handles rtCalificacion.RatingChanged
        'Dim Calif As Integer
        'Calif = rtCalificacion.RatingValue
        'Select Case Calif
        '    Case 0
        '        lblCalificacion.Text = ""
        '        pnlCalificacion.BackColor = SystemColors.Window
        '    Case 1, 2
        '        lblCalificacion.Text = "ACEPTABLE"
        '        pnlCalificacion.BackColor = Color.Gainsboro
        '    Case 3, 4
        '        lblCalificacion.Text = "BUENA"
        '        pnlCalificacion.BackColor = Color.Turquoise
        '    Case 5
        '        lblCalificacion.Text = "EXCELENTE"
        '        pnlCalificacion.BackColor = Color.PaleGreen

        'End Select
    End Sub

    Private Sub txtReloj_TextChanged(sender As Object, e As EventArgs) Handles txtReloj.TextChanged

    End Sub

    Private Sub dgTabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellContentClick

    End Sub

    Private Sub dgTabla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgTabla.KeyPress
        Dim Cl As String
        Dim x As Integer
        Dim Valor As String
        Try
            BuscaGrid = BuscaGrid & e.KeyChar
            Cl = dgTabla.SortedColumn.Name
            dgTabla.ClearSelection()

            tmrBusca.Enabled = False

            For x = 0 To dgTabla.Rows.Count - 1
                Valor = dgTabla.Item(Cl, x).Value.ToString.ToUpper
                If Valor.Length >= BuscaGrid.Length Then
                    If Valor.Substring(0, BuscaGrid.Length) = BuscaGrid.ToUpper Then
                        dgTabla.Item(Cl, x).Selected = True
                        dgTabla.FirstDisplayedScrollingRowIndex = x
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
        tmrBusca.Enabled = True

    End Sub

    Private Sub dgTabla_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, nom As String

        DesdeGrid = True

        cod = dgTabla.Item("Folio", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * FROM ideas_empleado WHERE RTRIM(folio) = '" & cod & "'", "IDEAS")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrarImagen_Click(sender As Object, e As EventArgs) Handles btnBorrarImagen.Click
        Borrar(sender, e)
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnPopupOpen(sender As Object, e As DevComponents.DotNetBar.PopupOpenEventArgs)
        For Each it In sender.subitems
            If it.text = "Borrar" Then
                'Stop
                it.enabled = Agregar Or Editar
            End If
        Next
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtReporte As DataTable = sqlExecute("SELECT ideasVW.*,cias.nombre AS COMPANIA,deptos.nombre AS NOMBRE_DEPTO,SUPER.NOMBRE AS NOMBRE_SUPER," & _
                                       "AREAS.NOMBRE AS NOMBRE_AREA,puestos.nombre as 'nombre_puesto' FROM IDEASVW " & _
                                       "LEFT JOIN personal.dbo.cias ON ideasVW.cod_comp = cias.cod_comp " & _
                                       "LEFT JOIN personal.dbo.deptos ON ideasVW.cod_comp = deptos.cod_comp AND ideasVW.cod_depto = deptos.cod_depto " & _
                                       "LEFT JOIN personal.dbo.super ON ideasVW.cod_comp = super.cod_comp AND ideasVW.cod_super = super.cod_super " & _
                                       "LEFT JOIN personal.dbo.puestos ON ideasVW.cod_comp = puestos.cod_comp AND ideasVW.cod_puesto = puestos.cod_puesto " & _
                                       "LEFT JOIN personal.dbo.areas ON ideasVW.cod_comp = areas.cod_comp AND ideasVW.cod_area = areas.cod_area " & _
                                       "WHERE folio= '" & txtFolio.Text.Trim & "'", "IDEAS")
        frmVistaPrevia.LlamarReporte("Formato de Ideas", dtReporte)
        frmVistaPrevia.ShowDialog(Me)

    End Sub

    Private Sub tmrBusca_Tick(sender As Object, e As EventArgs) Handles tmrBusca.Tick
        BuscaGrid = ""
    End Sub

    Private Sub txtRedaccion_TextChanged(sender As Object, e As EventArgs) Handles txtRedaccion.TextChanged

    End Sub

    Private Sub colDetalle_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles colDetalle.SplitterMoved

    End Sub

    Private Sub cmbEstatus_PopupClose(sender As Object, e As EventArgs) Handles cmbEstatus.PopupClose
        If Editar And EnviadaAnom() And cmbEstatus.SelectedValue = "C" Then
            MessageBox.Show("Ya se envio a nómina y no puede ser cancelada", "Cambio inválido", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEstatus.SelectedValue = "I"
        End If
    End Sub
    Private Function EnviadaAnom() As Boolean
        Dim dtEnv As DataTable = sqlExecute("select  envio_nomina from ideas_empleado where folio ='" + txtFolio.Text + "' and envio_nomina is null ", "IDEAS")
        If dtEnv.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnBuscarReloj_Click(sender As Object, e As EventArgs) Handles btnBuscarReloj.Click
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                txtReloj.Text = Reloj
                InformacionEmpleado(Reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtIdea_Validated(sender As Object, e As EventArgs) Handles txtIdea.Validated
        ' txtTitulo.Text = txtIdea.Text.Substring(0, IIf(txtIdea.TextLength > 50, 50, txtIdea.TextLength))
    End Sub

    Private Sub IntegerInput1_ValueChanged(sender As Object, e As EventArgs) Handles IntegerInput1.ValueChanged


        Dim Calif As Integer
        Calif = IntegerInput1.Value
        'Calif = rtCalificacion.RatingValue

        Select Case Calif
            Case 0
                rtCalificacion.RatingValue = 0
                lblCalificacion.Text = ""
                pnlCalificacion.BackColor = SystemColors.Window
            Case 1, 2
                rtCalificacion.RatingValue = 1
                lblCalificacion.Text = "ACEPTABLE"
                pnlCalificacion.BackColor = Color.Gainsboro
            Case 3, 4
                rtCalificacion.RatingValue = 2
                lblCalificacion.Text = "ACEPTABLE"
                pnlCalificacion.BackColor = Color.Gainsboro
            Case 5, 6, 7
                rtCalificacion.RatingValue = 3
                lblCalificacion.Text = "BUENA"
                pnlCalificacion.BackColor = Color.Turquoise
            Case 8, 9
                rtCalificacion.RatingValue = 4
                lblCalificacion.Text = "BUENA"
                pnlCalificacion.BackColor = Color.Turquoise

            Case Is >= 10
                rtCalificacion.RatingValue = 5
                lblCalificacion.Text = "EXCELENTE"
                pnlCalificacion.BackColor = Color.PaleGreen
        End Select



        'Dim Calif As Integer
        'Calif = IntegerInput1.Value
        ''Calif = rtCalificacion.RatingValue


        'If My.Computer.Name.Contains("MXJU") Then
        '    Select Case Calif
        '        Case 0
        '            rtCalificacion.RatingValue = 0
        '            lblCalificacion.Text = ""
        '            pnlCalificacion.BackColor = SystemColors.Window
        '        Case 1, 2, 3, 4, 5
        '            rtCalificacion.RatingValue = 1
        '            lblCalificacion.Text = "ACEPTABLE"
        '            pnlCalificacion.BackColor = Color.Gainsboro
        '        Case 6, 7, 8, 9, 10
        '            rtCalificacion.RatingValue = 2
        '            lblCalificacion.Text = "ACEPTABLE"
        '            pnlCalificacion.BackColor = Color.Gainsboro
        '        Case 11, 12, 13
        '            rtCalificacion.RatingValue = 3
        '            lblCalificacion.Text = "BUENA"
        '            pnlCalificacion.BackColor = Color.Turquoise
        '        Case 14, 15, 16, 17
        '            rtCalificacion.RatingValue = 4
        '            lblCalificacion.Text = "BUENA"
        '            pnlCalificacion.BackColor = Color.Turquoise
        '        Case 18, 19, 20
        '            rtCalificacion.RatingValue = 5
        '            lblCalificacion.Text = "EXCELENTE"
        '            pnlCalificacion.BackColor = Color.PaleGreen

        '    End Select
        'ElseIf My.Computer.Name.Contains("MXJZ") Then
        '    Select Case Calif
        '        Case 0
        '            rtCalificacion.RatingValue = 0
        '            lblCalificacion.Text = ""
        '            pnlCalificacion.BackColor = SystemColors.Window
        '        Case 1, 2
        '            rtCalificacion.RatingValue = 1
        '            lblCalificacion.Text = "ACEPTABLE"
        '            pnlCalificacion.BackColor = Color.Gainsboro
        '        Case 3
        '            rtCalificacion.RatingValue = 2
        '            lblCalificacion.Text = "ACEPTABLE"
        '            pnlCalificacion.BackColor = Color.Gainsboro
        '        Case 4, 5
        '            rtCalificacion.RatingValue = 3
        '            lblCalificacion.Text = "BUENA"
        '            pnlCalificacion.BackColor = Color.Turquoise
        '        Case 6, 7
        '            rtCalificacion.RatingValue = 4
        '            lblCalificacion.Text = "BUENA"
        '            pnlCalificacion.BackColor = Color.Turquoise
        '        Case 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
        '            rtCalificacion.RatingValue = 5
        '            lblCalificacion.Text = "EXCELENTE"
        '            pnlCalificacion.BackColor = Color.PaleGreen

        '    End Select
        'Else
        '    Select Case Calif
        '        Case 0
        '            rtCalificacion.RatingValue = 0
        '            lblCalificacion.Text = ""
        '            pnlCalificacion.BackColor = SystemColors.Window
        '        Case 1, 2
        '            rtCalificacion.RatingValue = 1
        '            lblCalificacion.Text = "ACEPTABLE"
        '            pnlCalificacion.BackColor = Color.Gainsboro
        '        Case 3
        '            rtCalificacion.RatingValue = 2
        '            lblCalificacion.Text = "ACEPTABLE"
        '            pnlCalificacion.BackColor = Color.Gainsboro
        '        Case 4, 5
        '            rtCalificacion.RatingValue = 3
        '            lblCalificacion.Text = "BUENA"
        '            pnlCalificacion.BackColor = Color.Turquoise
        '        Case 6, 7
        '            rtCalificacion.RatingValue = 4
        '            lblCalificacion.Text = "BUENA"
        '            pnlCalificacion.BackColor = Color.Turquoise
        '        Case 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
        '            rtCalificacion.RatingValue = 5
        '            lblCalificacion.Text = "EXCELENTE"
        '            pnlCalificacion.BackColor = Color.PaleGreen

        '    End Select
        'End If








    End Sub


    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If txtReloj.Text = "" Then
            MessageBox.Show("El campo reloj debe estar lleno antes de agregar colaboradores", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            relojidea = txtReloj.Text
            frmColaboradores.ShowDialog()
            txtcola.Text = totalcolaboradores + 1.ToString
        End If
    End Sub
End Class
