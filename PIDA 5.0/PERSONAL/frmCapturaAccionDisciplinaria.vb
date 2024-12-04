Public Class frmCapturaAccionDisciplinaria
    Dim numDias_suspension As Integer
    Dim contador_dias As Integer

    Dim contador_borrar_fechas As Integer = 2
    Private Sub frmCapturaAccionDisciplinaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(300, 50)
        dtimeFecha.Value = Today

      
        txtComentEmpleado.Text = ""
        txtComentSupervisor.Text = ""

        txtReloj.Text = Reloj
        contador_dias = 1
        folio = 1000000000
        Dim dtfolio As DataTable = sqlExecute("select top 1 folio from accion_disciplinaria order by folio desc")
        If dtfolio.Rows.Count > 0 Then
            folio = dtfolio.Rows(0)("folio") + 1
        End If


        If editarDisciplinaria = True Then
            Dim dteditar As DataTable = sqlExecute("select * from accion_disciplinaria where folio= '" & folioDisciplinaria & "'")
            MostrarInformacion()
            'Cargar informacion para editar****
            Dim dtTipoaccionDisciplinaria As DataTable = sqlExecute("select tipo_disciplinaria.tipo_accion_disciplinaria, " & _
                                                                    "tipo_disciplinaria.COD_TIPO_ACCION from accion_disciplinaria LEFT JOIN tipo_disciplinaria " & _
                                                                    "on accion_disciplinaria.COD_TIPO_ACCION = tipo_disciplinaria.COD_TIPO_ACCION WHERE folio='" & folioDisciplinaria & "'")
            Dim dtMotivoDisciplinario As DataTable = sqlExecute("select cod_motivo_disciplinario.COD_MOTIVO, cod_motivo_disciplinario.NOMBRE from " & _
                                                                "accion_disciplinaria LEFT JOIN cod_motivo_disciplinario on " & _
                                                                "accion_disciplinaria.COD_MOTIVO = cod_motivo_disciplinario.COD_MOTIVO where folio='" & folioDisciplinaria & "'")
            Dim dtComentarios As DataTable = sqlExecute("select categoria, fecha, coment_super, coment_empleado, path_pdf from accion_disciplinaria where folio='" & folioDisciplinaria & "'")

            cmbTipo.SelectedValue = IIf(IsDBNull(dtTipoaccionDisciplinaria.Rows(0).Item("cod_tipo_accion")), "", dtTipoaccionDisciplinaria.Rows(0).Item("cod_tipo_accion"))
            cmbMotivo.SelectedValue = IIf(IsDBNull(dtMotivoDisciplinario.Rows(0).Item("cod_motivo")), "", dtMotivoDisciplinario.Rows(0).Item("cod_motivo"))
            cmbCategoria.SelectedValue = IIf(IsDBNull(dtComentarios.Rows(0).Item("categoria")), "", dtComentarios.Rows(0).Item("categoria"))



      

        
            txtPDF.Text = IIf(IsDBNull(dtComentarios.Rows(0).Item("path_pdf")), "", dtComentarios.Rows(0).Item("path_pdf"))
            dtimeFecha.Text = IIf(IsDBNull(dtComentarios.Rows(0).Item("fecha")), "", dtComentarios.Rows(0).Item("fecha"))
            txtComentEmpleado.Text = IIf(IsDBNull(dtComentarios.Rows(0).Item("coment_empleado")), "", dtComentarios.Rows(0).Item("coment_empleado"))
            txtComentSupervisor.Text = IIf(IsDBNull(dtComentarios.Rows(0).Item("coment_super")), "", dtComentarios.Rows(0).Item("coment_super"))
            '**********

        Else

            MostrarInformacion()

        End If


    End Sub

    Private Sub MostrarInformacion()
        Try
            Dim dtReloj As DataTable = sqlExecute("select nombres from personalvw where reloj='" & txtReloj.Text & "'")
            txtNombre.Text = IIf(IsDBNull(dtReloj.Rows(0)("nombres")), "", RTrim(dtReloj.Rows(0)("nombres")))
            cmbTipo.DataSource = sqlExecute("select TIPO_ACCION_DISCIPLINARIA as TIPO, COD_TIPO_ACCION from " & _
                                            "tipo_disciplinaria order by cod_tipo_accion asc")
            '  cmbMotivo.DataSource = sqlExecute("select COD_MOTIVO as Código, NOMBRE as Nombre from cod_motivo_disciplinario")
            cmbMotivo.DataSource = sqlExecute("select COD_MOTIVO as Código, NOMBRE as Nombre,TEMA as Tema from cod_motivo_disciplinario")
            cmbCategoria.DataSource = sqlExecute("select cod_categoria, nombre from cod_cat_disciplinaria")
            txtPDF.Text = ""
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub cmbTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedValueChanged
        '***Obtener el numero de dias para asignar las fechas de suspension***


    End Sub
    Private Sub btnAgregarFecha_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub cmbMotivo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMotivo.SelectedValueChanged
        If cmbMotivo.Text.Length > 0 Then
            Dim dtMotivo_suspension As DataTable = sqlExecute("select nombre from cod_motivo_disciplinario where cod_motivo='" & cmbMotivo.SelectedValue & "'")
            If dtMotivo_suspension.Rows.Count > 0 Then
                txtMotivo.Text = IIf(IsDBNull(dtMotivo_suspension.Rows(0)("nombre")), "", RTrim(dtMotivo_suspension.Rows(0)("nombre")))
            End If
        End If
    End Sub

    Private Sub btnRemover_Click(sender As Object, e As EventArgs)
    

    End Sub

    Dim folio As Integer
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim fecha_captura As Date = Now
        Dim hora_captura As String = Now.ToString("HH:mm:ss")
        Dim fechas_suspension As String = ""
        Dim fechas_faltas As String = ""
        Dim dtTemp As DataTable = sqlExecute("select * from personal where reloj='" & txtReloj.Text & "'")
        Dim cod_planta As String = IIf(IsDBNull(dtTemp.Rows(0)("cod_planta")), "", RTrim(dtTemp.Rows(0)("cod_planta")))
        Dim cod_depto As String = IIf(IsDBNull(dtTemp.Rows(0)("cod_depto")), "", RTrim(dtTemp.Rows(0)("cod_depto")))
        Dim cod_super As String = IIf(IsDBNull(dtTemp.Rows(0)("cod_super")), "", RTrim(dtTemp.Rows(0)("cod_super")))
        Dim cod_turno As String = IIf(IsDBNull(dtTemp.Rows(0)("cod_turno")), "", RTrim(dtTemp.Rows(0)("cod_turno")))
        Dim cod_comp As String = IIf(IsDBNull(dtTemp.Rows(0)("cod_comp")), "", RTrim(dtTemp.Rows(0)("cod_comp")))


        '====== Se desactiva validación ya que no es necesaria.
        'If cmbTipo.SelectedValue = "001" Then
        '    Dim total As Integer = 0
        '    Dim dtcount As DataTable = sqlExecute("SELECT reloj FROM accion_disciplinaria where cod_tipo_accion = '001' and  reloj = '" & txtReloj.Text & "'")

        '    If dtcount.Rows.Count > 0 Then
        '        total = dtcount.Rows.Count

        '        If total >= 1 Then
        '            MessageBox.Show("El empleado ya cuenta con " & total.ToString & " carta(s) compromiso, favor de validar si aplica notificación de no incremento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        End If
        '    End If

        'End If


        If editarDisciplinaria = True Then
            sqlExecute("DELETE FROM accion_disciplinaria where folio= '" & folioDisciplinaria & "'")
        End If

        sqlExecute("insert into accion_disciplinaria (FOLIO, RELOJ, COD_PLANTA, COD_DEPTO, COD_SUPER, COD_TURNO, COD_MOTIVO, COD_TIPO_ACCION, FECHA, " & _
                    "FECHA_CAPTURA, USUARIO, EQUIPO, USUARIO_WINDOWS, HORA_CAPTURA, COMENT_SUPER, COMENT_EMPLEADO, COD_COMP, CATEGORIA, PATH_PDF) values ('" & folio & "', '" & Reloj & "', " & _
                     "'" & cod_planta & "', '" & cod_depto & "', '" & cod_super & "', '" & cod_turno & "', '" & cmbMotivo.SelectedValue & "', " & _
                     "'" & cmbTipo.SelectedValue & "', '" & FechaSQL(dtimeFecha.Value) & "', '" & FechaSQL(fecha_captura) & "', " & _
                     "'" & Usuario & "', '" & Environment.MachineName & "', '" & Environment.UserName & "', '" & hora_captura & "', '" & txtComentSupervisor.Text & "', '" & txtComentEmpleado.Text & "', '" & cod_comp & "', '" & cmbCategoria.SelectedValue & "', '" & txtPDF.Text & "')")

        '=====2024-07-10: Si es categoría tipo suspensión, que se registre en kardex
        If cmbCategoria.SelectedValue = "003" Then
            Dim Query As String = ""
            '====Validar si existe ya una suspension ese dia
            Dim dtExisteSus As DataTable = sqlExecute("select * from ta.dbo.ausentismo where reloj='" & Reloj & "' and TIPO_AUS='SUS' and fecha='" & FechaSQL(dtimeFecha.Value) & "'", "TA")
            If Not dtExisteSus.Columns.Contains("Error") And dtExisteSus.Rows.Count > 0 Then

                If MessageBox.Show("¿Ya existe una suspensión capturada para el día '" & FechaSQL(dtimeFecha.Value) & "', desea eliminarla y que se registre nuevamente a partir de esta acción disciplinaria?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    '--------Eliminar
                    sqlExecute("delete from ta.dbo.ausentismo where reloj='" & Reloj & "' and fecha='" & FechaSQL(dtimeFecha.Value) & "' and TIPO_AUS='SUS'", "TA")

                    '-------Volver a insertar
                    Query = "insert into ta.dbo.ausentismo (COD_COMP,reloj,FECHA,TIPO_AUS,PERIODO,SUBCLASI,USUARIO,FECHA_HORA) values " & _
                        "('" & cod_comp & "','" & Reloj & "','" & FechaSQL(dtimeFecha.Value) & "','SUS',(select periodo from ta.dbo.periodos where FECHA_INI<='" & FechaSQL(dtimeFecha.Value) & "' and FECHA_FIN>='" & FechaSQL(dtimeFecha.Value) & "'),'Suspension','" & Usuario & "',getdate())"
                    sqlExecute(Query, "TA")

                End If

            Else ' Solo se inserta

                Query = "insert into ta.dbo.ausentismo (COD_COMP,reloj,FECHA,TIPO_AUS,PERIODO,SUBCLASI,USUARIO,FECHA_HORA) values " & _
    "('" & cod_comp & "','" & Reloj & "','" & FechaSQL(dtimeFecha.Value) & "','SUS',(select periodo from ta.dbo.periodos where FECHA_INI<='" & FechaSQL(dtimeFecha.Value) & "' and FECHA_FIN>='" & FechaSQL(dtimeFecha.Value) & "'),'Suspension','" & Usuario & "',getdate())"
                sqlExecute(Query, "TA")

            End If

        End If

        Me.Close()
        

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

    End Sub

    Private Sub cmbFechaSuspension_MonthCalendar_DateChanged(sender As Object, e As EventArgs)
        

    End Sub

    Private Sub dtimeFecha_MonthCalendar_DateChanged(sender As Object, e As EventArgs) Handles dtimeFecha.MonthCalendar.DateChanged
        If dtimeFecha.Text > Today Then
            MessageBox.Show("No es posible seleccionar fechas posteriores al dia de hoy", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtimeFecha.Text = Today
        End If
    End Sub

    Private Sub btnAgregarFecha2_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub btnRemover2_Click(sender As Object, e As EventArgs)
     
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
End Class