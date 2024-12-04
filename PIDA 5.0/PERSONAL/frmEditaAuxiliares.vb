Public Class frmEditaAuxiliares
    Public reloj_ As String = ""

    Dim cmbCiaSelectedValue As String = ""

    Private Sub frmEditaAuxiliares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Me.reloj_ <> "" Then

                lblReloj.Text = reloj_

                Dim dtDatos As DataTable = sqlExecute("select nombres, cod_comp from personalvw where reloj = '" & reloj_ & "'")
                If dtDatos.Rows.Count > 0 Then
                    lblNombre.Text = RTrim(dtDatos.Rows(0)("nombres"))
                    cmbCiaSelectedValue = dtDatos.Rows(0)("cod_comp")
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                End If

                CrearDTCambiosAuxiliares()
                RefrescaAuxiliares(reloj_)
                dgAuxiliares.ClearSelection()
            Else
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End If
        Catch ex As Exception

        End Try
    End Sub

    Dim dtAuxiliares As DataTable

    Dim AgregarAux As Boolean     'Nueva auxiliares?
    Dim EditarAux As Boolean    'Editar auxiliares?
    Dim AuxSelec As Integer      'Auxiliar seleccionado

    Dim dtCambiosAuxiliares As New DataTable
    Dim IDAuxiliares As String
    Dim AuxAnt As String

    Dim dtTemp As DataTable

    Dim editar As Boolean = True
    Dim nuevo As Boolean = False

    Dim dtValidos As New DataTable



    Private Sub RefrescaAuxiliares(ByVal rl As String)
        Dim colAux As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn
        Dim dtAuxSel As New DataTable
        Try
            rl = rl.Trim
            dtAuxSel = sqlExecute("SELECT campo FROM auxiliares LEFT JOIN personal ON auxiliares.cod_comp = personal.cod_comp WHERE reloj = '" & rl & _
                                  "' AND mostrar_personal = 1 AND campo NOT IN " & _
                                  "(select campo FROM detalle_auxiliares WHERE campo =auxiliares.campo AND reloj = '" & rl & "') ")

            For Each AuxSel As DataRow In dtAuxSel.Rows
                Dim idFld As Integer = 1000
                Dim dtSiguiente As DataTable = sqlExecute("select top 1 idFld from detalle_auxiliares where idFld is not null order by idFld desc")
                If dtSiguiente.Rows.Count Then
                    idFld = Integer.Parse(dtSiguiente.Rows(0)("idfld")) + 1
                End If

                If AuxSel("campo").ToString.Trim <> "RECOMEN" Then
                    sqlExecute("INSERT INTO detalle_auxiliares (idFld,cod_comp, reloj,campo) VALUES ('" & idFld & "','" & cmbCiaSelectedValue & "', '" & rl & "','" & AuxSel("campo") & "')")
                End If
            Next

            dtAuxiliares = New DataTable
            dtAuxiliares = sqlExecute("SELECT detalle_auxiliares.idFld,RTRIM(auxiliares.CAMPO) AS CAMPO,RTRIM(detalle_auxiliares.contenido) as 'CONTENIDO' FROM detalle_auxiliares FULL OUTER JOIN auxiliares ON auxiliares.campo=detalle_auxiliares.campo WHERE reloj = '" & rl & "' ORDER BY auxiliares.campo")
            AgregarAux = False
            EditarAux = True
            dgAuxiliares.DataSource = dtAuxiliares
            dgAuxiliares.Columns("idFld").Visible = False
            'dgAuxiliares.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ''dtAuxiliares.Columns("detalle").ReadOnly = True

            dgAuxiliares.Columns.Remove("CAMPO")
            dgAuxiliares.Columns.Remove("CONTENIDO")

            'Agregar datos a columna combo de tipo de respuestas
            'Esta configuración no se puede agregar en modo de edición, solo en código
            colAux.DataSource = sqlExecute("SELECT UPPER(RTRIM(CAMPO)) AS CAMPO,upper(RTRIM(NOMBRE)) as NOMBRE FROM Auxiliares ORDER BY campo")
            colAux.ValueMember = "CAMPO"
            colAux.DisplayMember = "NOMBRE"
            colAux.DataPropertyName = "CAMPO"
            colAux.Name = "CAMPO"
            colAux.Width = 350
            colAux.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            'colRespuesta.AutoCompleteSource = AutoCompleteSource.ListItems
            colAux.DropDownStyle = ComboBoxStyle.DropDownList
            colAux.HeaderText = "CAMPO"
            dgAuxiliares.Columns.Insert(1, colAux)
            '***********************************************************************

            Dim dgvCombo As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn
            With dgvCombo
                '.Width = 150
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend

                dtValidos = sqlExecute("SELECT idFLD, campo, campo_valido FROM Auxiliares_VALIDOS")
                .Items.Clear()
                For Each DR As DataRow In dtValidos.Rows
                    .Items.Add(DR("CAMPO_VALIDO"))
                Next

                'dtValidos.Select("campo = 'TALLA_PANT'")

                '.DataSource = dtValidos
                '.DisplayMember = "campo,campo_valido"
                .ValueMember = "campo_valido"
                .DataPropertyName = "CONTENIDO"
                .HeaderText = "CONTENIDO"
                .Name = "CONTENIDO"
            End With
            dgAuxiliares.Columns.Add(dgvCombo)
            dgAuxiliares.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgAuxiliares_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgAuxiliares.CellBeginEdit
        Try
            If IsDBNull(dgAuxiliares.Item("idFLD", e.RowIndex).Value) Then
                IDAuxiliares = ""
            Else
                IDAuxiliares = dgAuxiliares.Item("idFLD", e.RowIndex).Value
            End If
            AuxAnt = IIf(IsDBNull(dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value), "", dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub dgAuxiliares_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliares.CellEndEdit
        Dim NewVal As String
        Dim ID As String
        Dim dR As DataRow
        Static NvoID As Integer = 999000
        Try
            NvoID = NvoID + 1

            ID = IIf(IsDBNull(dgAuxiliares.Item("idfld", e.RowIndex).Value), NvoID, dgAuxiliares.Item("idfld", e.RowIndex).Value)

            NewVal = IIf(IsDBNull(dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value), "", dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value)

            If AuxAnt <> NewVal Then
                dR = dtCambiosAuxiliares.Rows.Find(ID)
                If IsNothing(dR) Then
                    dtCambiosAuxiliares.Rows.Add(ID, IIf(ID > 999000, "A", "C"), dgAuxiliares.Item("CAMPO", e.RowIndex).Value, dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value)
                    dgAuxiliares.Item("idfld", e.RowIndex).Value = ID
                Else

                    dR.Item("CAMPO") = dgAuxiliares.Item("CAMPO", e.RowIndex).Value
                    dR.Item("CONTENIDO") = dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value
                End If

                AgregarAux = False
            End If

            If dgAuxiliares.Item("CAMPO", e.RowIndex).Value = "RECOMEN" Then
                dgAuxiliares.Item("CONTENIDO", e.RowIndex).ReadOnly = True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgAuxiliares_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliares.CellEnter
        Try
            Dim Campo As String = dgAuxiliares.Item(1, e.RowIndex).Value.ToString.Trim
            Dim AuxValidos As Boolean = False
            Dim tmpCampo As String = ""

            If Editar Or Nuevo Then
                If e.ColumnIndex = 2 Then

                    If Campo.ToUpper = "RUTA_SEC" Then

                        tmpCampo = "'" & Campo & "' as campo"
                        Campo = "RUTA"

                    Else
                        tmpCampo = "campo"
                    End If

                    'Buscar los valores válidos para el auxiliar seleccionado
                    'dtValidos = sqlExecute("SELECT idFLD, campo, campo_valido FROM Auxiliares_VALIDOS WHERE campo = '" & Campo & "' AND cod_comp = '" & cmbCiaSelectedValue & "'")
                    'dtValidos = sqlExecute("SELECT idFLD, campo, campo_valido FROM Auxiliares_VALIDOS WHERE campo = '" & Campo & "'")

                    dtValidos = sqlExecute("SELECT idFLD, " & tmpCampo & ", campo_valido FROM Auxiliares_VALIDOS WHERE campo = '" & Campo & "'")

                    'Si regresó registros, indica que hay auxiliares válidos
                    AuxValidos = dtValidos.Rows.Count > 0

                    'Crear una variable tipo combo, para pasar los datos de los auxiliares válidos
                    Dim dgvCombo As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn
                    dgvCombo = dgAuxiliares.Columns("CONTENIDO")
                    dgvCombo.Items.Clear()
                    For Each DR As DataRow In dtValidos.Rows
                        dgvCombo.Items.Add(DR("CAMPO_VALIDO"))
                    Next

                    'Si hay , buscar si el valor actual es válido
                    If AuxValidos Then
                        'dtTemp = sqlExecute("SELECT idFLD FROM Auxiliares_VALIDOS WHERE campo_valido = '" & dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value & "' AND  campo = '" & Campo & "' AND cod_comp = '" & cmbCiaSelectedValue & "'")
                        dtTemp = sqlExecute("SELECT idFLD FROM Auxiliares_VALIDOS WHERE campo_valido = '" & dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value & "' AND  campo = '" & Campo & "'")

                        'Si el valor actual no es un dato válido para este auxiliar, poner en blanco
                        If dtTemp.Rows.Count = 0 Then
                            'Poner el blanco el contenido, 
                            dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value = ""
                        End If
                    End If
                    'dgAuxiliares.Item("CONTENIDO", e.RowIndex) = dgvCombo.Items(0)

                    'If IsDBNull(dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value) Then
                    'End If
                    dgAuxiliares.Refresh()
                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub



    Private Sub dgAuxiliares_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgAuxiliares.CellValidating
        Dim Campo As String = ""
        'Dim x As Integer
        Try
            Dim Valido As Boolean
            If Editar Or Nuevo Then
                If e.ColumnIndex = 2 Then
                    Dim C As String
                    C = e.FormattedValue
                    Valido = True

                    Campo = dgAuxiliares.Item("CAMPO", e.RowIndex).Value.ToString.Trim.ToUpper

                    If Campo = "RUTA_SEC" Then
                        Campo = "RUTA"
                    End If

                    'dtTemp = sqlExecute("SELECT campo_valido FROM Auxiliares_validos WHERE campo = '" & dgAuxiliares.Item("CAMPO", e.RowIndex).Value.ToString.Trim.ToUpper & "'")
                    dtTemp = sqlExecute("SELECT campo_valido FROM Auxiliares_validos WHERE campo = '" & Campo & "'")
                    If dtTemp.Rows.Count = 0 Then
                        Valido = True
                    Else
                        'dtTemp = sqlExecute("SELECT campo_valido FROM Auxiliares_validos WHERE campo = '" & dgAuxiliares.Item("CAMPO", e.RowIndex).Value.ToString.Trim.ToUpper & _
                        '                    "' AND campo_valido = '" & C.ToUpper & "'")

                        dtTemp = sqlExecute("SELECT campo_valido FROM Auxiliares_validos WHERE campo = '" & Campo & _
                                            "' AND campo_valido = '" & C.ToUpper & "'")

                        dgAuxiliares.CurrentCell.Value = C.ToUpper
                        Valido = dtTemp.Rows.Count > 0
                    End If

                    If Not Valido Then
                        MessageBox.Show("El tipo de auxiliar no es válido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        'dgAuxiliares.CancelEdit()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            e.Cancel = True
        End Try
    End Sub



    Private Sub dgAuxiliares_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgAuxiliares.UserAddedRow
        AgregarAux = True
    End Sub

    Private Sub dgAuxiliares_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgAuxiliares.UserDeletingRow
        Dim Indice As String
        Dim dR As DataRow
        Try
            Indice = """" & dgAuxiliares.Item("CAMPO", e.Row.Index).Value & """"
            If MessageBox.Show("¿Está seguro de borrar el registro " & Indice & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                dR = dtCambiosAuxiliares.Rows.Find(Indice)
                If IsNothing(dR) Then
                    dtCambiosAuxiliares.Rows.Add(dgAuxiliares.Item("idFld", e.Row.Index).Value, "B")
                Else
                    dR.Item("MOVIMIENTO") = "B"
                End If
            Else
                e.Cancel = True
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            e.Cancel = True
        End Try

    End Sub

    Private Function ActualizarCambiosAuxiliares() As Boolean
        Dim I As Integer
        Dim D As Integer = 0
        Dim R As String
        Dim M As String
        Dim U As String
        Dim C As String
        Dim T As String
        Dim N As String
        Try
            R = reloj_

            For I = 0 To dtCambiosAuxiliares.Rows.Count - 1
                M = dtCambiosAuxiliares.Rows(I).Item("movimiento")
                U = dtCambiosAuxiliares.Rows(I).Item("unico")
                C = IIf(IsDBNull(dtCambiosAuxiliares.Rows(I).Item("CAMPO")), "", dtCambiosAuxiliares.Rows(I).Item("CAMPO"))
                If C.Length > 0 Then
                    D = C.IndexOf(" - ")
                    If D > 0 Then C = C.Substring(0, D)
                ElseIf M <> "B" Then
                    MessageBox.Show("El campo auxiliar no puede quedar en blanco, favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
                dtTemp = sqlExecute("SELECT cod_comp from personalvw WHERE reloj = '" & R & "'")
                N = dtTemp.Rows.Item(0).Item(0)

                T = IIf(IsDBNull(dtCambiosAuxiliares.Rows(I).Item("contenido")), "", dtCambiosAuxiliares.Rows(I).Item("contenido"))



                Select Case M
                    Case "A"
                        Dim idFld As Integer = 1000
                        Dim dtSiguiente As DataTable = sqlExecute("select top 1 idFld from detalle_auxiliares where idFld is not null order by idFld desc")
                        If dtSiguiente.Rows.Count Then
                            idFld = Integer.Parse(dtSiguiente.Rows(0)("idfld")) + 1
                        End If
                        If C.Trim = "RECOMEN" Then
                            Dim dttemp As DataTable = sqlExecute("select * from personal where reloj = '" & T.Trim.PadLeft(6, "0") & "'")
                            If dttemp.Rows.Count > 0 Then
                                Dim dttemp2 As DataTable = sqlExecute("select * from detalle_auxiliares where campo = 'RECOMEN' and  reloj = '" & R & "'")
                                If dttemp2.Rows.Count > 0 Then
                                    MessageBox.Show("Este empleado ya fue recomendado anteriormente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Else
                                    'sqlExecute("INSERT INTO detalle_auxiliares (idfld, cod_comp,reloj,campo,contenido, detalles, usuario) VALUES ('" & idFld & "', '" & N & "','" & R & "','" & C.Trim & "','" & T.Trim.PadLeft(6, "0") & "', '1', '" & Usuario & "')")
                                    'Jose R Hdez 31-oct-19 se agrego la fecha
                                    sqlExecute("INSERT INTO detalle_auxiliares (idfld, cod_comp,reloj,campo,contenido, detalles, usuario, fecha) VALUES ('" & idFld & "', '" & N & "','" & R & "','" & C.Trim & "','" & T.Trim.PadLeft(6, "0") & "', '1', '" & Usuario & "', getdate())")
                                End If

                            Else
                                MessageBox.Show("El valor de auxiliar no es valido, favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                            btnBorrarRecomen.Visible = False
                        Else
                            sqlExecute("INSERT INTO detalle_auxiliares (idfld, cod_comp,reloj,campo,contenido) VALUES ('" & idFld & "', '" & N & "','" & R & "','" & C.Trim & "','" & T.Trim & "')")
                        End If


                    Case "B"
                        sqlExecute("DELETE FROM detalle_auxiliares WHERE idFld = '" & U & "'")
                    Case "C"
                        If C.Trim = "RECOMEN" Then
                            Dim dttemp2 As DataTable = sqlExecute("select * from detalle_auxiliares where campo = 'RECOMEN' and  reloj = '" & R & "'")
                            If dttemp2.Rows.Count > 0 Then
                                MessageBox.Show("Este empleado ya fue recomendado anteriormente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Else
                                'sqlExecute("UPDATE detalle_auxiliares SET campo = '" & C & "', contenido = '" & T & "', usuario = '" & Usuario & "' WHERE idFld = '" & U & "'")
                                'Jose R Hdez 31-oct-19 se agrego la fecha
                                sqlExecute("UPDATE detalle_auxiliares SET campo = '" & C & "', contenido = '" & T & "', usuario = '" & Usuario & "', fecha = getdate() WHERE idFld = '" & U & "'")
                            End If
                            btnBorrarRecomen.Visible = False
                        Else
                            sqlExecute("UPDATE detalle_auxiliares SET campo = '" & C & "', contenido = '" & T & "' WHERE idFld = '" & U & "'")
                        End If

                End Select
            Next
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Private Function CrearDTCambiosAuxiliares() As Boolean
        Try
            Dim Columnas(3) As DataColumn

            dtCambiosAuxiliares = New DataTable("CambiosAuxiliares")
            Columnas(0) = New DataColumn("UNICO")
            Columnas(0).DataType = System.Type.GetType("System.String")
            Columnas(1) = New DataColumn("MOVIMIENTO")
            Columnas(1).DataType = System.Type.GetType("System.String")
            Columnas(2) = New DataColumn("Campo")
            Columnas(2).DataType = System.Type.GetType("System.String")
            Columnas(3) = New DataColumn("Contenido")
            Columnas(3).DataType = System.Type.GetType("System.String")

            For x = 0 To UBound(Columnas)
                dtCambiosAuxiliares.Columns.Add(Columnas(x))
            Next
            dtCambiosAuxiliares.PrimaryKey = New DataColumn() {dtCambiosAuxiliares.Columns("UNICO")}
            'dgCambiosAuxiliares.DataSource = dtCambiosAuxiliares
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        ActualizarCambiosAuxiliares()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub dgAuxiliares_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliares.CellDoubleClick
        If Editar Then

            Dim bonorecom As String = ""
            Dim colum As Integer
            If IsDBNull(dgAuxiliares.Item("CAMPO", e.RowIndex).Value) Then
                bonorecom = ""
                colum = 0
            Else
                bonorecom = dgAuxiliares.Item("CAMPO", e.RowIndex).Value
                colum = e.ColumnIndex

            End If
            If bonorecom = "RECOMEN" And colum = 2 Then
                ' dtTemp = dtPersonal
                Try
                    frmBuscar.ShowDialog(Me)
                    If Reloj <> "CANCEL" Then
                        dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value = Reloj
                        recomendado = Reloj
                        Reloj = reloj_

                    End If

                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                    ' dtPersonal = dtTemp
                End Try
            End If

            Dim NewVal As String
            Dim ID As String
            Dim dR As DataRow
            Static NvoID As Integer = 999000
            Try
                NvoID = NvoID + 1

                ID = IIf(IsDBNull(dgAuxiliares.Item("idfld", e.RowIndex).Value), NvoID, dgAuxiliares.Item("idfld", e.RowIndex).Value)

                NewVal = IIf(IsDBNull(dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value), "", dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value)

                If AuxAnt <> NewVal Then
                    dR = dtCambiosAuxiliares.Rows.Find(ID)
                    If IsNothing(dR) Then
                        dtCambiosAuxiliares.Rows.Add(ID, IIf(ID > 999000, "A", "C"), dgAuxiliares.Item("CAMPO", e.RowIndex).Value, dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value)
                        dgAuxiliares.Item("idfld", e.RowIndex).Value = ID
                    Else

                        dR.Item("CAMPO") = dgAuxiliares.Item("CAMPO", e.RowIndex).Value
                        dR.Item("CONTENIDO") = dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value
                    End If

                    AgregarAux = False
                End If



            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            End Try

        End If
        If Not IsDBNull(dgAuxiliares.Item("CAMPO", e.RowIndex).Value) Then
            If dgAuxiliares.Item("CAMPO", e.RowIndex).Value = "RECOMEN" Then
                dgAuxiliares.Item("CONTENIDO", e.RowIndex).ReadOnly = True
                If Editar Then
                    btnBorrarRecomen.Visible = True
                    btnBorrarRecomen.Enabled = True
                End If
            Else
                If Editar Then
                    btnBorrarRecomen.Visible = False
                    btnBorrarRecomen.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub dgAuxiliares_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliares.CellClick
        If Not IsDBNull(dgAuxiliares.Item("CAMPO", e.RowIndex).Value) Then
            If dgAuxiliares.Item("CAMPO", e.RowIndex).Value = "RECOMEN" Then
                dgAuxiliares.Item("CONTENIDO", e.RowIndex).ReadOnly = True
                If Editar Then
                    btnBorrarRecomen.Visible = True
                    btnBorrarRecomen.Enabled = True
                    recomendado = IIf(IsDBNull(dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value), "", dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value)
                End If
            Else
                If Editar Then
                    btnBorrarRecomen.Visible = False
                    btnBorrarRecomen.Enabled = False
                    recomendado = ""
                End If
            End If
        End If
    End Sub
    Dim recomendado As String = ""
    Private Sub btnBorrarRecomen_Click(sender As Object, e As EventArgs) Handles btnBorrarRecomen.Click

        If recomendado <> "" Then
            If sqlExecute("select * from detalle_auxiliares where reloj = '" & reloj_ & "' and campo = 'RECOMEN' and contenido = '" & recomendado & "'").Rows.Count > 0 Then
                If MessageBox.Show("¿Está seguro de borrar el auxiliar seleccionado?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    sqlExecute("delete from detalle_auxiliares where reloj = '" & reloj_ & "' and campo='RECOMEN' and contenido = '" & recomendado & "'")
                    btnAceptar.PerformClick()
                End If
            Else
                MessageBox.Show("El registro no se a guardado, se cancelara la edicion.", "Borrar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnCancelar.PerformClick()
            End If

        End If

        btnBorrarRecomen.Visible = False
        dgAuxiliares.ClearSelection()
    End Sub
End Class