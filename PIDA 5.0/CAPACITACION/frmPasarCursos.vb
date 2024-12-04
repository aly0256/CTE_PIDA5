Public Class frmPasarCursos


    Public _strRelojEmp As String = ""
    Public _strNombreEmp As String = ""
    Public _strPuestoEmp As String = ""
    Public _strEstatusEmp As String = ""
    Public _strRutaFoto As String = ""
    Dim _dtPersonal As New DataTable
    Dim _dicControles As New Dictionary(Of String, String)
    Dim _noFilas As Integer = 0

#Region "Funciones"

    ''' <summary>
    ''' Información de la interfaz.
    ''' </summary>
    ''' <param name="strReloj">Reloj de empleado</param>
    ''' <remarks></remarks>
    Private Sub CargaInformacion(strReloj As String)
        Try
            '-- Información personal [se almacena en un diccionario]
            For Each dicValor As KeyValuePair(Of String, String) In ControlesInfo(strReloj)
                For Each c As Object In pnlContenido.Controls
                    Dim nomCtrl As String = c.Name
                    ExplorarCtrl(c, dicValor)
                Next
            Next
            '-- Totales de registros
            Try : lblCursosTot1.Text = dgvCursos1.RowCount.ToString & " cursos en total" : Catch ex As Exception : End Try
            Try : lblCursosTot2.Text = dgvCursos2.RowCount.ToString & " cursos en total" : Catch ex As Exception : End Try
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Explora dentro de los controles y asigna sus valores correspondientes.
    ''' </summary>
    ''' <param name="Ctrl">Nombre del control a explorar</param>
    ''' <param name="diccionario">Diccionario con valores definidos</param>
    ''' <remarks></remarks>
    Private Sub ExplorarCtrl(ByRef Ctrl As Object, diccionario As KeyValuePair(Of String, String))
        '-- Se hace un loop dentro del panel y se asignan valores a los controles [puede ser un panel o groupbox]
        For Each elem As Object In Ctrl.Controls
            Dim nomCtrl As String = elem.Name
            If TypeOf elem Is Panel Or TypeOf elem Is GroupBox Then ExplorarCtrl(elem, diccionario)
            If nomCtrl.Contains(diccionario.Key) And Not (nomCtrl.Contains("dgvCursos") Or nomCtrl.Contains("lblCursosTot")) Then elem.Text = diccionario.Value
            If nomCtrl.Contains("lblEstatus") And nomCtrl.Contains(diccionario.Key) Then elem.BackColor = IIf(diccionario.Value = "Estatus: Inactivo", Color.Red, IIf(diccionario.Value = "Estatus: Activo", Color.ForestGreen, Color.SlateGray))
            If TypeOf elem Is DevComponents.DotNetBar.Controls.DataGridViewX And nomCtrl.Contains(diccionario.Key) Then elem.DataSource = sqlExecute(diccionario.Value)
            If TypeOf elem Is PictureBox And nomCtrl.Contains(diccionario.Key) Then Try : elem.ImageLocation = diccionario.Value : Catch ex As Exception : elem.Image = elem.ErrorImage : End Try
        Next
    End Sub

    ''' <summary>
    ''' Carga valores definidos desde la invocación de la forma en la ventana de consulta de cursos.
    ''' </summary>
    ''' <param name="strReloj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ControlesInfo(strReloj As String) As Dictionary(Of String, String)
        Dim numCtrl As String
        Dim rljBusqueda As Boolean
        Dim dicCtrl As New Dictionary(Of String, String)
        Dim qryCursos As String = "select  ce.cod_curso,c.nombre from CAPACITACION.dbo.cursos_empleado ce " & _
                                                        "inner join CAPACITACION.dbo.cursos c on ce.cod_curso=c.cod_curso where ce.reloj='" & strReloj & "' " & _
                                                        "union select pe.cod_curso,c.nombre from CAPACITACION.dbo.planeacion_empleados pe " & _
                                                        "inner join CAPACITACION.dbo.cursos c on pe.cod_curso=c.cod_curso where pe.reloj='" & strReloj & "'"
        Select Case strReloj
            Case _strRelojEmp
                numCtrl = "1"
            Case Else
                numCtrl = "2"
                rljBusqueda = True
                _dtPersonal = sqlExecute("select top 1 reloj,(rtrim(nombre)+' '+rtrim(apaterno)+' '+rtrim(amaterno)) as nombres,rtrim(nombre_puesto) as nombre_puesto, " & _
                                                               "case when baja is null then 'Activo' else 'Inactivo' end as 'estatus',foto,alta " & _
                                                               "from personal.dbo.personalvw where reloj='" & strReloj & "'")
        End Select

        dicCtrl.Add("txtReloj" & numCtrl, strReloj)
        dicCtrl.Add("lblNombres" & numCtrl, IIf(rljBusqueda, _dtPersonal.Select("reloj='" & strReloj & "'").First.Item("nombres"), _strNombreEmp))
        dicCtrl.Add("lblPuesto" & numCtrl, IIf(rljBusqueda, _dtPersonal.Select("reloj='" & strReloj & "'").First.Item("nombre_puesto"), _strPuestoEmp))
        dicCtrl.Add("lblEstatus" & numCtrl, "Estatus: " & IIf(rljBusqueda, _dtPersonal.Select("reloj='" & strReloj & "'").First.Item("estatus"), _strEstatusEmp))
        dicCtrl.Add("dgvCursos" & numCtrl, qryCursos)
        dicCtrl.Add("picFoto" & numCtrl, IIf(rljBusqueda, _dtPersonal.Select("reloj='" & strReloj & "'").First.Item("foto"), _strRutaFoto))
       Return dicCtrl
    End Function
#End Region

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmTraspasarCursos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _dtPersonal = sqlExecute("select top 1 reloj,(rtrim(nombre)+' '+rtrim(apaterno)+' '+rtrim(amaterno)) as nombres,rtrim(nombre_puesto) as nombre_puesto, " & _
                                               "case when baja is null then 'ACTIVO' else 'INACTIVO' end as 'estatus',foto " & _
                                               "from personal.dbo.personalvw where reloj='" & _strRelojEmp & "'")
            CargaInformacion(_strRelojEmp)
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Búsqueda del empleado al que se asignarán los cursos.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBusqueda_Click(sender As Object, e As EventArgs) Handles btnBusqueda.Click
        frmBuscar.ShowDialog(Me)
        If Reloj <> "CANCEL" And Reloj.Trim <> _strRelojEmp Then
            txtReloj2.Text = Reloj
            CargaInformacion(Reloj.Trim)
            btnTraspasa.Enabled = Not dgvCursos1.RowCount = 0
        End If
    End Sub

    ''' <summary>
    ''' Botón que transfiere los cursos tomados de un empleado a otro como planeados.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTraspasa_Click(sender As Object, e As EventArgs) Handles btnTraspasa.Click
        Try
            Dim strQuery = "insert into capacitacion.dbo.planeacion_empleados (reloj,cod_curso,ano,mes,obligatorio,usuario,fecha_captura,fecha_maxima) " & _
                                        "values ('" & txtReloj2.Text & "','[c]','" & Date.Now.Year.ToString & "','" & IIf(Date.Now.Month < 10, "0" & Date.Now.Month.ToString, Date.Now.Month.ToString) & "','1','" & Usuario & "','" & FechaSQL(_dtPersonal.Rows(0)("alta")) & "',NULL)"
            Dim strCadena = "" : Dim cont = 0 : Dim nvosCursos As New List(Of String)

            '-- Determinar los cursos distintos [La fecha de inicio será la fecha de alta del empleado a transferir y la fecha máxima queda pendiente]
            For Each i As DataGridViewRow In dgvCursos1.Rows
                Dim noExiste = TryCast(dgvCursos2.DataSource, DataTable).Select("cod_curso='" & i.Cells("cod_curso").Value.ToString.Trim & "'").Count = 0
                strCadena &= IIf(noExiste, strQuery.Replace("[c]", i.Cells("cod_curso").Value.ToString.Trim), "") & ";"
                If noExiste Then nvosCursos.Add(i.Cells("cod_curso").Value.ToString.Trim)
                cont += 1
            Next
            '-- Insercion en BD pleaneados empleados
            If Not strCadena.Contains("insert") Then
                MessageBox.Show("Los cursos del empleado " & txtReloj1.Text & " ya existen en el historial del reloj " & txtReloj2.Text & ".", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnTraspasa.Enabled = False
            Else
                If MessageBox.Show("Se agregarán " & cont.ToString & " nuevos cursos al empleado " & txtReloj2.Text & ". ¿Desea continuar?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    sqlExecute(strCadena.Substring(0, strCadena.Length - 1))

                    '-- Insertar los cursos planeados en la tabla planeacion cursos
                    strCadena = ""
                    Dim dtPlanCursos = sqlExecute("select * from capacitacion.dbo.planeacion_cursos where ano='" & Date.Now.Year & "' and mes='" & IIf(Date.Now.Month < 10, "0" & Date.Now.Month.ToString, Date.Now.Month.ToString) & "'")
                    For Each nvos In nvosCursos
                        If dtPlanCursos.Select("cod_curso='" & nvos & "'").Count = 0 Then
                            strCadena &= "insert into capacitacion.dbo.planeacion_cursos (cod_curso,ano,mes,condicion) values " & _
                                                  "('" & nvos & "','" & Date.Now.Year.ToString & "','" & IIf(Date.Now.Month < 10, "0" & Date.Now.Month.ToString, Date.Now.Month.ToString) & "','(RELOJ IN (''" & txtReloj2.Text & "''))');"
                        Else
                            Dim strCondicionOriginalDb = dtPlanCursos.Select("cod_curso='" & nvos & "'").First.Item("condicion").ToString.Trim
                            If Not strCondicionOriginalDb.Contains(txtReloj2.Text) Then
                                strCadena &= "update capacitacion.dbo.planeacion_cursos set condicion='" & strCondicionOriginalDb.Substring(0, strCondicionOriginalDb.Length - 1).Replace("'", "''") & " AND RELOJ IN (''" & txtReloj2.Text & "''))' " & _
                                      "where cod_curso='" & nvos & "' and ano='" & Date.Now.Year.ToString & "' and mes='" & IIf(Date.Now.Month < 10, "0" & Date.Now.Month.ToString, Date.Now.Month.ToString) & "';"
                            End If
                        End If
                    Next
                    sqlExecute(strCadena.Substring(0, strCadena.Length - 1))

                    MessageBox.Show("Se han agregado " & cont.ToString & " nuevos cursos planeados al empleado " & txtReloj2.Text & " con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargaInformacion(txtReloj2.Text)
                    btnTraspasa.Enabled = False
                End If
            End If
       
        Catch ex As Exception : End Try
    End Sub
End Class