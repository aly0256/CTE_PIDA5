Imports System.IO
Imports DevComponents.AdvTree

Public Class frmRepositorioCursos

    Dim dtRegistro As New DataTable

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    '===EventoLoad
    Private Sub frmRepositorioCursos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtRegistro = sqlExecute("SELECT TOP 1 * FROM Cursos ORDER BY cod_curso ASC", "Capacitacion")
        MostrarInformacion(dtRegistro)

    End Sub

    Private Sub MostrarInformacion(ByVal _dt_registro As DataTable)
        Dim _cod_curso As String = "", nombre_curso As String = ""
        If Not _dt_registro.Columns.Contains("Error") And _dt_registro.Rows.Count > 0 Then
            Try : _cod_curso = _dt_registro.Rows(0).Item("cod_curso").ToString.Trim : Catch ex As Exception : _cod_curso = "" : End Try
            Try : nombre_curso = _dt_registro.Rows(0).Item("nombre").ToString.Trim : Catch ex As Exception : nombre_curso = "" : End Try

        End If
        txtCodigo.Text = _cod_curso
        txtNombre.Text = nombre_curso
        CargarDocumentos(_cod_curso)
    End Sub
    '=======================================STARTS DOCUMENTOS
#Region "Documentos"
    'MCR 20210305
    'Procedimientos necesarios para cargar/mostrar documentos del expediente, guardados en una tabla
    Public DocsNodoActivo As DevComponents.AdvTree.Node

    '====Evento de Cargar los documentos de solo el empleado en consulta
    Private Sub CargarDocumentos(ByVal id_curso As String)
        Dim Cadena As String, dtDocumentos As New DataTable
        Dim sdNodoDoc As DevComponents.AdvTree.Node
        Dim sdNodoInfo As DevComponents.AdvTree.Node
        Try
            'LIMPIAR CARPETA ANTES DE CARGAR

            If webPreview.IsDisposed = False Then
                ' Solo accede al WebBrowser si no ha sido dispuesto
                webPreview.Navigate("about:blank")
            Else
                ' Si el control ya ha sido dispuesto, crea un nuevo WebBrowser
                webPreview = New System.Windows.Forms.WebBrowser()
                Controls.Add(webPreview)
                webPreview.Navigate("about:blank")
            End If

            'Dim DirTemp As String = DireccionReportes & My.Computer.Name & "\"
            Dim DirTemp As String = DireccionDocsCapacCursos


            Try
                'Borrar todos los documentos que se encuentren en la carpeta temporal dentro del directorio de reportes
                If Dir(DirTemp & "docs*.*") > "" Then
                    ' FileSystem.Kill(DirTemp & "docs*.*")
                End If
            Catch ex As Exception

            End Try


            treeDocs.Nodes.Clear()

            '===Cod temporal por mi para cargar solo el de 1 empleado, solo necesito:   cod_documento,extension,nombre,  nom_archivo y fecha
            Dim extension As String = "", cod_documento As String = "", archivo As Integer = 1, nombre As String = "", nom_archivo As String = "", fecha As String = "", fecha_date As Date = Now
            Cadena = "select * from archivos  where id='" & id_curso & "' order by consec asc"
            dtDocumentos = sqlExecute(Cadena, "CAPACITACION")

            If Not dtDocumentos.Columns.Contains("Error") And dtDocumentos.Rows.Count > 0 Then
                For Each doc In dtDocumentos.Rows
                    Try : extension = doc("tipo_arch").ToString.Trim : Catch ex As Exception : extension = "" : End Try
                    Try : cod_documento = doc("consec").ToString.Trim : Catch ex As Exception : cod_documento = "" : End Try
                    Try : nombre = doc("desc_arch").ToString.Trim : Catch ex As Exception : nombre = "" : End Try
                    Try : fecha = FechaSQL(doc("fecha_hora").ToString.Trim) : Catch ex As Exception : fecha = "" : End Try
                    fecha_date = Date.Parse(fecha)

                    '===Validar si existe el archivo
                    If nombre <> "" Then archivo = 1 Else archivo = 0


                    sdNodoDoc = New DevComponents.AdvTree.Node
                    sdNodoDoc.Text = nombre
                    sdNodoDoc.Name = "doc" & cod_documento
                    sdNodoDoc.FullRowBackground = True
                    sdNodoDoc.NodesIndent = 20
                    treeDocs.Nodes.Add(sdNodoDoc)

                    If archivo = 1 Then
                        sdNodoDoc.Image = imgDocs.Images(extension)
                        If sdNodoDoc.Image Is Nothing Then
                            'Si no hay un ícono para ese tipo de archivo, poner el ícono indefinido
                            sdNodoDoc.Image = imgDocs.Images("UND")
                        End If

                        'Descripción
                        sdNodoInfo = New DevComponents.AdvTree.Node
                        sdNodoInfo.Text = "Detalle: " & nombre
                        sdNodoInfo.Name = "des" & cod_documento
                        sdNodoInfo.Selectable = False
                        sdNodoDoc.Nodes.Add(sdNodoInfo)

                        sdNodoInfo = New DevComponents.AdvTree.Node
                        sdNodoInfo.Text = "Fecha: " & FechaCortaLetra(fecha_date).ToUpper
                        sdNodoInfo.Name = "fec" & fecha
                        sdNodoInfo.Selectable = False
                        sdNodoDoc.Nodes.Add(sdNodoInfo)
                    Else
                        'Al no tener ícono, requiere espacio al inicio, para mantenerse en la misma línea
                        sdNodoDoc.Text = "       " & sdNodoDoc.Text
                        sdNodoDoc.Enabled = False
                    End If
                Next
            End If

        Catch ex As Exception
            treeDocs.Nodes.Clear()

            sdNodoDoc = New DevComponents.AdvTree.Node
            sdNodoDoc.Text = "ERROR: La información de documentos no pudo ser cargada."
            treeDocs.Nodes.Add(sdNodoDoc)

            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub

    '===Evento de al momento de dar click sobre un documento:
    Private Sub treeDocs_NodeClick(sender As Object, e As DevComponents.AdvTree.TreeNodeMouseEventArgs) Handles treeDocs.NodeClick
        Try
            Dim dtDocumento As New DataTable, query As String = ""
            Dim doc As String
            'Dim DirTemp As String = DireccionReportes & My.Computer.Name & "\"
            Dim DirTemp As String = DireccionDocsCapacCursos
            Dim Reloj As String = ""

            'Guardar el nodo activo, para utilizarlo en el menú
            DocsNodoActivo = e.Node
            doc = e.Node.Name ' ==Es el documento que está seleccionado en el momento

            GuardarArchivoToolStripMenuItem.Enabled = False
            ImprimirArchivoToolStripMenuItem.Enabled = False


            '===Si realmente se selecciona un documento
            If doc.Substring(0, 3) = "doc" Then

                Dim consec As String = "", nombre_arch As String = "", extension As String = "", fecha As String = ""
                consec = doc.Substring(3).ToString.Trim

                query = "select * from archivos  where id='" & txtCodigo.Text.Trim & "' and consec='" & consec & "'"
                dtDocumento = sqlExecute(query, "CAPACITACION")
                If Not dtDocumento.Columns.Contains("Error") And dtDocumento.Rows.Count > 0 Then
                    Try : nombre_arch = dtDocumento.Rows(0).Item("nombre_arch").ToString.Trim : Catch ex As Exception : nombre_arch = "" : End Try
                    Try : extension = dtDocumento.Rows(0).Item("tipo_arch").ToString.Trim : Catch ex As Exception : nombre_arch = "" : End Try
                    Try : fecha = FechaSQL(dtDocumento.Rows(0).Item("fecha_hora")) : Catch ex As Exception : fecha = "" : End Try
                Else
                    webPreview.Navigate("about:blank")
                    Exit Sub
                End If

                '===Validar que el archivo exista en la ruta donde se guardarán los documentos (NOTA: Despues cambiarla para que sea fija que es donde ahí se guardaran todos los documentos)
                If File.Exists(DirTemp & nombre_arch) Then
                    DirTemp = DirTemp & nombre_arch
                    webPreview.Navigate(DirTemp)

                    'Las opciones de guardar e imprimir solo están disponibles cuando hay archivo
                    GuardarArchivoToolStripMenuItem.Enabled = True
                    ImprimirArchivoToolStripMenuItem.Enabled = True

                Else
                    MessageBox.Show("El archivo no se encontró en : " & DirTemp & nombre_arch)
                    webPreview.Navigate("about:blank")
                    Exit Sub
                End If
            End If
            My.Application.DoEvents()

        Catch ex As Exception
            webPreview.Navigate("about:blank")
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub

    Private Sub AgregarDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarDocumentoToolStripMenuItem.Click

        '====Nuevo proceso
        Try
            Dim DirTemp2 As String = DireccionDocsCapacCursos
            Dim DirTemp As String
            Dim id_curso As String = txtCodigo.Text.Trim
            Dim NombreArchivo As String
            Dim f As FileInfo
            Dim ext_archivo As String
            Dim FiltroArchivos As String = "Todos los archivos (PDF,Imagen, Word, Excel, ZIP)|*.pdf;*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.xlsx;*.docx;*.pptx;*.zip;|Archivos PDF (*.pdf)|*.pdf|Archivos PNG (*.png)|*.png|Archivos Bitmap (*.bmp)|*.bmp|" & _
                "Archivos JPEG (*.jpg)|*.jpg|Archivos GIF (*.gif)|*.gif|Archivos Word|*.docx;*.docm;*.dotx;*.rtf;*.doc;*.dot|Archivos Excel|*.xls;*.xls5;*.xlsx|Todos los archivos (*.*)|*.*"

            '===NEW
            opnArchivo.FileName = ""
            opnArchivo.Filter = FiltroArchivos
            If opnArchivo.ShowDialog <> DialogResult.Cancel Then 'NEW

                NombreArchivo = opnArchivo.FileName 'NEW
                f = New FileInfo(NombreArchivo)
                If f.Extension = "" Then
                    ext_archivo = ".pdf"
                    NombreArchivo = NombreArchivo & ext_archivo
                Else
                    ext_archivo = f.Extension
                End If


                Dim _nombre_arch_guardar As String = "", consec As String = "", _nombreArchivo_Fuente As String = "", extension_archivo As String = "", query As String = ""

                _nombreArchivo_Fuente = NombreArchivo.Trim.Split("\").Last()
                _nombreArchivo_Fuente = _nombreArchivo_Fuente.Split(".")(0).ToUpper '==Dar sin el nombre de la extension
                extension_archivo = NombreArchivo.Split(".")(1).ToUpper '==Solo da la extensión del archivo

                '===Obtener el cod_doc consecutivo para guardarlo
                Dim dtConsec As DataTable = sqlExecute("SELECT  TOP 1 ISNULL(MAX(consec),0) AS consec  FROM archivos", "CAPACITACION")
                If (Not dtConsec.Columns.Contains("ERROR") And dtConsec.Rows.Count > 0) Then
                    Dim UltRStr As String = IIf(IsDBNull(dtConsec.Rows(0).Item("consec")), "", dtConsec.Rows(0).Item("consec"))
                    If (UltRStr.Trim = "0") Then UltRStr = "00000" ' Ponemos la cantidad de dig que deseamos manejar para todos los empleados, puede variar para cada empresa
                    Dim NCSig As Integer = IIf(UltRStr.Trim = "", 0, Convert.ToInt32(UltRStr)) + 1
                    Dim CerosAdd As String = AddZeros(Len(UltRStr.Trim), Len(NCSig.ToString.Trim))
                    consec = CerosAdd & NCSig.ToString.Trim
                End If

                _nombre_arch_guardar = _nombreArchivo_Fuente & "_" & Reloj & "." & extension_archivo
                DirTemp = DirTemp2 & _nombre_arch_guardar
                If Not System.IO.File.Exists(DirTemp) Then
                    File.Copy(NombreArchivo, DirTemp)
                    MessageBox.Show("El archivo " & vbCrLf & NombreArchivo & " fue guardado exitosamente. ", "Pida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("El archivo '" & _nombre_arch_guardar & "' ya existe en la ruta de archivos guardados, favor de seleccionar otro o renombrarlo con otro nombre", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                

                '===Actualizar tabla de archivos
                query = "insert into archivos values ('" & id_curso & "','" & consec & "','" & _nombre_arch_guardar & "','" & _nombre_arch_guardar & "','" & extension_archivo & "',getdate(),'" & DirTemp & "')"
                sqlExecute(query, "CAPACITACION")

                '===Volver a llamar a la funcion de recargar los documentos
                CargarDocumentos(id_curso)

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("El archivo no pudo ser guardado. " & vbCrLf & ex.Message, "Pida", MessageBoxButtons.OK, MessageBoxIcon.Error)
            webPreview.Navigate("about:blank")
        End Try
    End Sub

    '===Evento para eliminar un documento
    Private Sub EliminarDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarDocumentoToolStripMenuItem.Click
        Dim D As String, nombre_archivo As String = "", query As String = "", dtDocumento As New DataTable
        Dim cod_curso As String = txtCodigo.Text.Trim
        Dim DirTemp = DireccionDocsCapacCursos

        webPreview.Navigate("about:blank") ' Cerrar navegador ante todo para que no se quede el doc abierto
        ' webPreview.Dispose()

        Try
            If Not DocsNodoActivo Is Nothing Then
                If DocsNodoActivo.Nodes.Count > 0 Then
                    If MessageBox.Show("¿Está seguro de eliminar el archivo cargado como " & DocsNodoActivo.Text & _
                                       "? Una vez borrado, no puede ser recuperado.", "Pida", _
                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then
                        Exit Sub
                    End If

                    DocsNodoActivo.Enabled = False
                    DocsNodoActivo.Nodes.Clear()
                    DocsNodoActivo.Image = Nothing
                    DocsNodoActivo.Text = "       " & DocsNodoActivo.Text
                    D = DocsNodoActivo.Name.Replace("doc", "")

                    query = "select * from archivos  where id='" & cod_curso & "' and consec='" & D & "'"
                    dtDocumento = sqlExecute(query, "CAPACITACION")

                    If Not dtDocumento.Columns.Contains("Error") And dtDocumento.Rows.Count > 0 Then
                        nombre_archivo = dtDocumento.Rows(0).Item("nombre_arch").ToString.Trim
                    End If


                    '===Eliminarlo del directorio temporal y de la base de datos
                    If File.Exists(DirTemp & nombre_archivo) Then

                        FileSystem.Kill(DirTemp & nombre_archivo)
                        sqlExecute("DELETE FROM archivos WHERE id = '" & cod_curso & "' AND consec = '" & D & "'", "CAPACITACION")
                        MessageBox.Show("El elemento seleccionado fué eliminado de forma exitosa", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        sqlExecute("DELETE FROM archivos WHERE id = '" & cod_curso & "' AND consec = '" & D & "'", "CAPACITACION")
                        MessageBox.Show("El elemento seleccionado fué eliminado de forma exitosa", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    '===Actualizar documentos
                    CargarDocumentos(cod_curso)


                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub

    '===Evento para agregar y guardar documentos con su extension y todo
    Private Sub GuardarArchivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarArchivoToolStripMenuItem.Click

    End Sub

    '===Evento para imprimir el archivo
    Private Sub ImprimirArchivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirArchivoToolStripMenuItem.Click
        Try
            webPreview.ShowPrintPreviewDialog()
            webPreview.Print()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub


    '===Evento al hacer click derecho sobre el archivo seleccionado, lo seleccione y se pueda eliminar
    Private Sub mnuDocs_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuDocs.Opening
        ' MessageBox.Show("CLICK DERECHO")

        '===Es para seleccionar/simular que se selecciona el elemento con click derecho
        '==Ya que por default el menuContextStrip se habilita siempre con click derecho
        If treeDocs.SelectedNode IsNot Nothing Then
            ' Creamos un objeto TreeNodeMouseClickEventArgs
            Dim args As New TreeNodeMouseEventArgs(treeDocs.SelectedNode, MouseButtons.Left, 1, 1, 1, 1)

            ' Llamamos al método que maneja el evento NodeClick pasando los parámetros correspondientes
            treeDocs_NodeClick(treeDocs, args)
        End If

        If Not DocsNodoActivo Is Nothing Then
            DocToolStripMenuItem.Text = DocsNodoActivo.Text.Trim
        End If

    End Sub
#End Region

    '=======================================ENDS DOCUMENTOS


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    '===Siguiente
    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("Cursos", "cod_curso", txtCodigo.Text, dtRegistro, "Capacitacion")
        MostrarInformacion(dtRegistro)
    End Sub
    '===Anterior
    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("Cursos", "cod_curso", txtCodigo.Text, dtRegistro, "Capacitacion")
        MostrarInformacion(dtRegistro)
    End Sub
    '===Ultimo
    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("Cursos", "cod_curso", dtRegistro, "Capacitacion")
        MostrarInformacion(dtRegistro)
    End Sub
    '===Primero
    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("Cursos", "cod_curso", dtRegistro, "Capacitacion")
        MostrarInformacion(dtRegistro)
    End Sub

    '====Buscar un curso
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("capacitacion.dbo.Cursos", "cod_curso", "Cursos", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from Cursos WHERE cod_curso = '" & Cod & "' ", "Capacitacion")
            MostrarInformacion(dtRegistro)
        End If
    End Sub
End Class