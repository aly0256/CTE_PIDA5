Imports Microsoft.Office.Interop

Public Class frmRedaccionContrato
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtCias As New DataTable
    Dim dtCampos As New DataTable

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean


#End Region


    Private Sub frmRedaccionContrato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim btn As DevComponents.DotNetBar.ButtonItem

            dtLista = sqlExecute("SELECT cod_comp AS 'Compañía', tipo_cont as 'Código',RTRIM(Nombre) AS 'Nombre' FROM contrato")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtCias = sqlExecute("SELECT cod_comp,nombre FROM cias")
            cmbCia.DataSource = dtCias
            cmbCia.ValueMember = "cod_comp"

            dtCampos = sqlExecute("SELECT cod_campo,nombre FROM campos ORDER BY nombre")
            dtCampos.Rows.Add("nombre_completo", "NOMBRE APATERNO AMATERNO")
            dtCampos.Rows.Add("al_ala", "AL - A LA")
            dtCampos.Rows.Add("el_la", "EL - LA")
            dtCampos.Rows.Add("sr(a)", "SR(A)")
            dtCampos.Rows.Add("sactual_letra", "Sueldo diario (letra)")
            dtCampos.Rows.Add("hora_entrada", "Hora de entrada")
            dtCampos.Rows.Add("hora_salida", "Hora de salida")
            dtCampos.Rows.Add("entrada_h1", "Entrada horario 1")
            dtCampos.Rows.Add("salida_h1", "Salida horario 1")
            dtCampos.Rows.Add("entrada_h2", "Entrada horario 2")
            dtCampos.Rows.Add("salida_h2", "Salida horario 2")
            dtCampos.Rows.Add("fecha_hoy", "Fecha de hoy (letra)")
            dtCampos.Rows.Add("fecha_firma", "Fecha de firma (letra)")
            dtCampos.Rows.Add("alta_letra", "Fecha de alta (letra)")
            For Each dCampo As DataRow In dtCampos.Rows
                btn = New DevComponents.DotNetBar.ButtonItem
                btn.Text = dCampo("nombre")
                btn.Tag = dCampo("cod_campo")
                AddHandler btn.Click, AddressOf InsertaCampo
                btnCampos.SubItems.Add(btn)
            Next
            btnCampos.SubItems(1).BeginGroup = True

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM contrato ORDER BY tipo_cont ASC ")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub HabilitarBotones()
        Try
            Dim NoRec As Boolean
            NoRec = dgTabla.Rows.Count = 0
            btnPrimero.Enabled = Not (Agregar Or Editar Or NoRec)
            btnAnterior.Enabled = Not (Agregar Or Editar Or NoRec)
            btnSiguiente.Enabled = Not (Agregar Or Editar Or NoRec)
            btnUltimo.Enabled = Not (Agregar Or Editar Or NoRec)

            btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)
            btnBuscar.Enabled = Not (Agregar Or Editar Or NoRec)
            btnBorrar.Enabled = Not (Agregar Or Editar Or NoRec)
            btnCerrar.Enabled = Not (Agregar Or Editar Or NoRec)
            pnlDatos.Enabled = Agregar Or Editar

            btnEditar.Enabled = Not (Not (Editar Or Agregar) And NoRec)


            If Agregar Or Editar Then
                ' Si está activa la edición o nuevo registro
                btnNuevo.Image = PIDA.My.Resources.Ok16
                btnEditar.Image = PIDA.My.Resources.CancelX
                btnNuevo.Text = "Aceptar"
                btnEditar.Text = "Cancelar"
                tabBuscar.SelectedTabIndex = 0
            Else

                btnNuevo.Image = PIDA.My.Resources.NewRecord
                btnEditar.Image = PIDA.My.Resources.Edit

                btnNuevo.Text = "Agregar"
                btnEditar.Text = "Editar"
            End If

            txtCodigo.Enabled = Agregar

            If Agregar Then
                txtCodigo.Text = ""
                txtNombre.Text = ""
                txtCodigo.Focus()
            ElseIf Editar Then
                txtNombre.Focus()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub MostrarInformacion()
        Dim i As Integer
        Try

            txtCodigo.Text = dtRegistro.Rows(0).Item("tipo_cont").ToString.Trim
            txtNombre.Text = dtRegistro.Rows(0).Item("nombre").ToString.Trim.ToString.Trim
            cmbCia.SelectedValue = dtRegistro.Rows(0).Item("cod_comp").ToString.Trim
            txtRevision.Text = dtRegistro.Rows(0).Item("revision").ToString.Trim
            txtVigencia.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("vigencia")), 0, dtRegistro.Rows(0).Item("vigencia"))
            txtRedaccion.Text = dtRegistro.Rows(0).Item("contrato").ToString.Trim
            webPrevia.DocumentText = "<body style= " & Chr(34) & "font-family:Calibri" & Chr(34) & ";>" & txtRedaccion.Text.Replace(vbCrLf, "<br>")
            If Not DesdeGrid Then
                i = dtLista.DefaultView.Find(txtCodigo.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If
            DesdeGrid = False
            HabilitarBotones()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCiasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("contrato", "(cod_comp + tipo_cont)", "estado contrato", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM contrato WHERE (cod_comp + tipo_cont) = '" & Cod & "' ")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("contrato", "(cod_comp + tipo_cont)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("contrato", "(cod_comp + tipo_cont)", cmbCia.SelectedValue & txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("contrato", "(cod_comp + tipo_cont)", cmbCia.SelectedValue & txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Codigo = txtCodigo.Text

        If MessageBox.Show("¿Está seguro de borrar el registro " & Codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            sqlExecute("DELETE FROM contrato WHERE tipo_cont = '" & Codigo & "'")
            btnSiguiente.PerformClick()
        End If
    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, nom As String, comp As String

        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value
        nom = dgTabla.Item("Nombre", e.RowIndex).Value
        comp = dgTabla.Item("Compañía", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * FROM contrato WHERE tipo_cont = '" & cod & "' AND nombre = '" & nom & "' AND cod_comp = '" & comp & "'")
        MostrarInformacion()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click

        If Not Editar And Not Agregar Then
            Editar = True
            HabilitarBotones()
            txtNombre.Focus()
        Else
            Editar = False
        End If
        Agregar = False
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Ultimo("contrato", "(cod_comp + tipo_cont)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            Dim mensaje As String
            mensaje = txtRedaccion.Text.Trim

            mensaje = mensaje.Replace(Chr(34), """")
            mensaje = mensaje.Replace(Chr(39), "''")

            Dim CambioEfectuado As Boolean
            CambioEfectuado = True
            If Agregar Then
                ' Si Agregar, revisar si existe tipo_cont
                dtTemporal = sqlExecute("SELECT tipo_cont FROM contrato where tipo_cont = '" & txtCodigo.Text & "'")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe el registro '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                Else
                    sqlExecute("INSERT INTO contrato (tipo_cont,nombre,cod_comp,revision,vigencia,contrato) VALUES ('" & txtCodigo.Text & "','" & txtNombre.Text & "','" & cmbCia.SelectedValue & "','" & txtRevision.Text & "'," & IIf(txtVigencia.Value = 0, "NULL", txtVigencia.Value) & ",'" & mensaje & "')")
                    Agregar = False
                End If
                ExportarContratoWord(mensaje, cmbCia.SelectedValue.ToString.Trim & txtCodigo.Text.Trim)
            ElseIf Editar Then
                ' Si Editar, entonces guardar cambios a registro
                sqlExecute("UPDATE contrato SET " & _
                           "nombre = '" & txtNombre.Text & _
                           "',revision = '" & txtRevision.Text & _
                           "',cod_comp = '" & cmbCia.SelectedValue & _
                           "', vigencia = " & IIf(txtVigencia.Value = 0, "NULL", txtVigencia.Value) & _
                           ",contrato='" & mensaje & "' WHERE tipo_cont = '" & txtCodigo.Text & "' AND cod_comp = '" & dtRegistro.Rows(0).Item("cod_comp") & "'")
                ExportarContratoWord(mensaje, cmbCia.SelectedValue.ToString.Trim & txtCodigo.Text.Trim)
            Else
                Agregar = True
            End If
            Editar = False

            HabilitarBotones()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("Estadocontrato", Nothing)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub frmRedaccionContrato_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlCentrarControles.Left = (Me.Width - pnlCentrarControles.Size.Width) / 2
    End Sub
    Private Sub InsertaCampo(sender As Object, e As EventArgs)
        Try
            txtRedaccion.SelectedText = "[" & sender.tag.ToString.ToLower.Trim & "]"
            btnPrevia.PerformClick()
        Catch ex As Exception
            MessageBox.Show("No se pudo insertar el campo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExpandablePanel1_Click(sender As Object, e As EventArgs)
        webPrevia.DocumentText = txtRedaccion.Text
    End Sub

    Private Sub expPrevia_ExpandedChanged(sender As Object, e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles expPrevia.ExpandedChanged
        expEspacio.Visible = expPrevia.Expanded
    End Sub

    Private Sub btnBold_Click(sender As Object, e As EventArgs) Handles btnBold.Click
        txtRedaccion.SelectedText = "<b>" & txtRedaccion.SelectedText & "</b>"
        btnPrevia.PerformClick()
    End Sub

    Private Sub btnPrevia_Click(sender As Object, e As EventArgs) Handles btnPrevia.Click
        webPrevia.DocumentText = "<body style= " & Chr(34) & "font-family:Calibri" & Chr(34) & ";>" & txtRedaccion.Text.Replace(vbCrLf, "<br>")
    End Sub

    Private Sub btnItalic_Click(sender As Object, e As EventArgs) Handles btnItalic.Click
        txtRedaccion.SelectedText = "<i>" & txtRedaccion.SelectedText & "</i>"
        btnPrevia.PerformClick()
    End Sub

    Private Sub btnUnderline_Click(sender As Object, e As EventArgs) Handles btnUnderline.Click
        txtRedaccion.SelectedText = "<u>" & txtRedaccion.SelectedText & "</u>"
        btnPrevia.PerformClick()
    End Sub

    Private Sub txtRedaccion_MouseUp(sender As Object, e As MouseEventArgs) Handles txtRedaccion.MouseUp
        btnBold.Enabled = txtRedaccion.SelectionLength > 0
        btnItalic.Enabled = txtRedaccion.SelectionLength > 0
        btnUnderline.Enabled = txtRedaccion.SelectionLength > 0
        btnLeft.Enabled = txtRedaccion.SelectionLength > 0
        btnCenter.Enabled = txtRedaccion.SelectionLength > 0
        btnRight.Enabled = txtRedaccion.SelectionLength > 0
        btnSuperscript.Enabled = txtRedaccion.SelectionLength > 0
        btnSubscript.Enabled = txtRedaccion.SelectionLength > 0
    End Sub


    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        txtRedaccion.SelectedText = "<p align= " & Chr(34) & "left" & Chr(34) & ">" & txtRedaccion.SelectedText & "</p>"
        btnPrevia.PerformClick()
    End Sub

    Private Sub btnCenter_Click(sender As Object, e As EventArgs) Handles btnCenter.Click
        txtRedaccion.SelectedText = "<p align= " & Chr(34) & "center" & Chr(34) & ">" & txtRedaccion.SelectedText & "</p>"
        btnPrevia.PerformClick()
    End Sub

    Private Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        txtRedaccion.SelectedText = "<p align= " & Chr(34) & "right" & Chr(34) & ">" & txtRedaccion.SelectedText & "</p>"
        btnPrevia.PerformClick()
    End Sub

    Private Sub btnSubscript_Click(sender As Object, e As EventArgs) Handles btnSubscript.Click
        txtRedaccion.SelectedText = "<sub>" & txtRedaccion.SelectedText & "</sub>"
        btnPrevia.PerformClick()
    End Sub

    Private Sub btnSuperscript_Click(sender As Object, e As EventArgs) Handles btnSuperscript.Click
        txtRedaccion.SelectedText = "<sup>" & txtRedaccion.SelectedText & "</sup>"
        btnPrevia.PerformClick()
    End Sub

    Private Sub txtBusca_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBusca.KeyUp
        For Each itm As Object In btnCampos.SubItems
            If TypeOf itm Is DevComponents.DotNetBar.ButtonItem Then
                itm.Visible = itm.Text.ToString.ToUpper.Contains(txtBusca.Text.ToUpper)
            End If
        Next
    End Sub

    Private Sub txtBusca_GotFocus(sender As Object, e As EventArgs) Handles txtBusca.GotFocus
        txtBusca.SelectionStart = 0
        txtBusca.SelectionLength = txtBusca.Text.Length
    End Sub

    Private Sub btnCampos_Click(sender As Object, e As EventArgs) Handles btnCampos.Click

    End Sub

    Private Sub btnCampos_ExpandChange(sender As Object, e As EventArgs) Handles btnCampos.ExpandChange
        If btnCampos.Expanded Then
            txtBusca.Focus()
        End If
    End Sub

    Private Sub pnlVistaContrato_Resize(sender As Object, e As EventArgs) Handles pnlVistaContrato.Resize
        If expPrevia.Expanded Then
            expPrevia.Width = pnlVistaContrato.Width / 2
        End If
    End Sub

    Private Sub frmRedaccionContrato_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        expPrevia.Expanded = False
    End Sub

    Private Sub ExportarContratoWord(ByVal Redaccion As String, ByVal RefContrato As String)
        'Exportar contrato a plantilla (template) de MSWord
        ' Aplicación de Word
        Dim word_app As Word.Application = New Word.Application
        ' Crear documento Word
        Dim word_doc As Word.Document = word_app.Documents.Add()
        Dim oTable As Word.Table

        'word_app.Visible = True
        Dim x As Integer
        Dim cod As String = ""

        Dim i As Integer
        Dim par() As String
        Dim Negritas As Boolean = False
        Dim Italica As Boolean = False
        Dim Subrayado As Boolean = False
        Dim Subindice As Boolean = False
        Dim Superindice As Boolean = False
        Dim Alineacion As Word.WdParagraphAlignment = Word.WdParagraphAlignment.wdAlignParagraphJustify

        Dim Parrafo As Word.Paragraph = word_doc.Paragraphs.Add()
        Try
            'Redaccion = Clipboard.GetText
            word_app.Selection.Font.Size = 10
            'Generar arreglo con el texto del contrato, delimitado por códigos de formato
            par = Redaccion.Split("<")

            x = 0
            i = 0

            For Each iTxt As String In par
                If iTxt <> "" Then
                    i = iTxt.IndexOf(">")
                    If i < 0 Then i = 0
                    cod = iTxt.Substring(0, i)

                    Select Case cod
                        Case "p"
                            'Si el código indica inicio de párrafo, ignorar
                            iTxt.Replace("p>", "")
                        Case "b"
                            Negritas = True
                        Case "/b"
                            Negritas = False
                        Case "i"
                            Italica = True
                        Case "/i"
                            Italica = False
                        Case "u"
                            Subrayado = True
                        Case "/u"
                            Subrayado = False
                        Case Else
                            If cod.Length >= 5 Then
                                If cod.Substring(2, 5) = "align" Then
                                    If cod.Contains("left") Then
                                        Alineacion = Word.WdParagraphAlignment.wdAlignParagraphLeft
                                    ElseIf cod.Contains("right") Then
                                        Alineacion = Word.WdParagraphAlignment.wdAlignParagraphRight
                                    ElseIf cod.Contains("center") Then
                                        Alineacion = Word.WdParagraphAlignment.wdAlignParagraphCenter
                                    Else
                                        Alineacion = Word.WdParagraphAlignment.wdAlignParagraphJustify
                                    End If
                                Else
                                    'Si es cualquier otro código no considerado, detener en "debug" para analizar si debe incluirse
                                    Debug.Print(cod)
                                    Stop
                                End If
                            ElseIf cod = "/p" Then
                                'Si es fin de párrafo, cambiar la alineación al default (justificado)
                                Alineacion = Word.WdParagraphAlignment.wdAlignParagraphJustify

                            ElseIf cod <> "" And cod <> "/p" Then
                                'Si es cualquier otro código no considerado, detener en "debug" para analizar si debe incluirse
                                Debug.Print(cod)
                                Stop
                            End If
                    End Select

                    'Quitar el código y el delimitador al final de la línea, para dejar solo redaccion
                    iTxt = iTxt.Replace(cod & ">", "")
                    'Eliminar los dobles espacios entre párrafos
                    iTxt = iTxt.Replace(Chr(13) & Chr(10) & Chr(13) & Chr(10), Chr(13) & Chr(10))

                    'Si no es un fin de párrafo, cambiar formato
                    If cod <> "/p" Then
                        'Debug.Print(IIf(Negritas, "N", " ") & " " & IIf(Italica, "I", " ") & " " & IIf(Subrayado, "S", " ") & " " & Alineacion.ToString.PadRight(15) & " " & iTxt)

                        word_app.Selection.ParagraphFormat.Alignment = Alineacion
                        word_app.Selection.Font.Bold = Negritas
                        word_app.Selection.Font.Italic = Italica
                        word_app.Selection.Font.Underline = Subrayado
                    End If
                    'Insertar el redaccion ya con el formato
                    word_app.Selection.TypeText(iTxt)
                End If
            Next
            Application.DoEvents()

            'Insertar espacios después del redaccion
            word_doc.Range.Font.Size = 10
            word_doc.Range.InsertAfter(vbCrLf)

            'Formatear y llenar tabla para firmas con 4 renglones, 5 columnas al final del documento
            oTable = word_doc.Tables.Add(word_doc.Bookmarks.Item("\endofdoc").Range, 4, 5)
            oTable.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oTable.Range.Font.Size = 10

            oTable.Columns.Item(1).Width = word_app.InchesToPoints(0.5)
            oTable.Columns.Item(2).Width = word_app.InchesToPoints(2.5)
            oTable.Columns.Item(3).Width = word_app.InchesToPoints(0.5)
            oTable.Columns.Item(4).Width = word_app.InchesToPoints(2.5)
            oTable.Columns.Item(5).Width = word_app.InchesToPoints(0.5)
            'Hacer más alto el renglón para la firma
            oTable.Rows.Item(2).Height = word_app.InchesToPoints(0.5)
            oTable.Rows.Item(3).Height = word_app.InchesToPoints(0.1)

            oTable.Cell(1, 2).Range.Text = "EL PATRÓN"
            oTable.Cell(2, 2).Borders(3).Visible = True

            oTable.Cell(1, 4).Range.Text = "EL (LA) TRABAJADOR (A)"
            oTable.Cell(2, 4).Borders(3).Visible = True

            'oTable.Cell(3, 2).Range.Text = "REPRESENTANTE LEGAL"
            'oTable.Cell(3, 4).Range.Text = " [nombre_completo]"
            'oTable.Cell(4, 2).Range.Text = "[representante]"

            oTable.Cell(3, 2).Range.Text = "[representante]"
            oTable.Cell(3, 4).Range.Text = " [nombre_completo]"
            oTable.Cell(4, 2).Range.Text = "REPRESENTANTE LEGAL"


            oTable.Rows.Item(1).Range.Font.Bold = True
            oTable.Rows.Item(3).Range.Font.Bold = True

            Dim filename As Object = DireccionReportes & "Contrato " & RefContrato & ".docx"

            If IO.File.Exists(filename) Then
                IO.File.Delete(filename)
            End If

            word_doc.SaveAs(FileName:=filename)

            ' Close.
            Dim save_changes As Object = False
            word_doc.Close(save_changes)
            word_app.Quit(save_changes)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class