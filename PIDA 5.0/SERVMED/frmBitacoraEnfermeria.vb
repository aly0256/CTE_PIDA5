Imports DevComponents.DotNetBar.Controls

Public Class frmBitacoraEnfermeria

    Dim estilo_a As New DataGridViewCellStyle
    Dim estilo_b As New DataGridViewCellStyle
    Dim estilo_c As New DataGridViewCellStyle

    Public refrescando As Boolean = False

    '------------------------------------------------------------

    Private dtBusquedaSintomas As New DataTable
    Private dtFallbackSintomas As New DataTable

    Private Sub llenar_busquedaSintomas()
        Try
            dtBusquedaSintomas.Columns.Add("cod_sin")
            dtBusquedaSintomas.Columns.Add("nombre")

            dtFallbackSintomas.Columns.Add("cod_sin")
            dtFallbackSintomas.Columns.Add("nombre")

            Dim dtSintomas As DataTable = sqlExecute("select * from arbol_sintomas where parent is null", "sermed")
            For Each row As DataRow In dtSintomas.Rows
                Dim codigo As String = RTrim(row("cod_sin"))
                Dim nombre As String = EliminaAcentos(RTrim(row("nombre")))

                llenar_busquedaSintomas(codigo, nombre)
            Next

            dgvBusquedaSintomas.DataSource = dtBusquedaSintomas

        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenar_busquedaSintomas(cod_sin As String, parents As String)
        Try
            Dim dtSintomas As DataTable = sqlExecute("select * from arbol_sintomas where parent = '" & cod_sin & "'", "sermed")
            For Each row As DataRow In dtSintomas.Rows
                Dim codigo As String = RTrim(row("cod_sin"))
                Dim nombre As String = parents & " - " & EliminaAcentos(RTrim(row("nombre")))

                dtBusquedaSintomas.Rows.Add({codigo, nombre})
                llenar_busquedaSintomas(codigo, nombre)
            Next
        Catch ex As Exception

        End Try
    End Sub

    '------------------------------------------------------------

    Private dtBusquedaTratamientos As New DataTable
    Private dtFallbackTratamientos As New DataTable

    Private Sub llenar_busquedaTratamientos()
        Try
            dtBusquedaTratamientos.Columns.Add("id_recurso")
            dtBusquedaTratamientos.Columns.Add("descripcion")
            dtBusquedaTratamientos.Columns.Add("servicio")
            dtBusquedaTratamientos.Columns.Add("posologia")
            dtBusquedaTratamientos.Columns.Add("recurso")
            dtBusquedaTratamientos.Columns.Add("tipo")
            dtBusquedaTratamientos.Columns.Add("dias")

            dtFallbackTratamientos = dtBusquedaTratamientos.Clone

            Dim dtSintomas As DataTable = sqlExecute("select * from tratamientos", "sermed")
            For Each row As DataRow In dtSintomas.Rows
                Dim codigo As String = RTrim(row("id_recurso"))
                Dim nombre As String = EliminaAcentos(RTrim(row("descripcion")))
                Dim servicio As String = EliminaAcentos(RTrim(row("servicio")))
                Dim posologia As String = EliminaAcentos(RTrim(row("posologia")))
                Dim recurso As String = EliminaAcentos(RTrim(row("recurso")))
                Dim tipo As String = EliminaAcentos(RTrim(row("clasificacion")))
                Dim dias As String = EliminaAcentos(RTrim(row("dias_tratamiento")))

                dtBusquedaTratamientos.Rows.Add({codigo, nombre, servicio, posologia, recurso, tipo, dias})

            Next

            dgvBusquedaTratamientos.DataSource = dtBusquedaTratamientos

        Catch ex As Exception

        End Try
    End Sub

    '------------------------------------------------------------

    Private Sub frmBitacoraEnfermeria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.KeyPreview = True
            VistaDetalle.Expanded = False

            dgvBitacora.AutoGenerateColumns = False

            estilo_a.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
            estilo_a.BackColor = Color.LimeGreen

            estilo_b.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
            estilo_b.BackColor = Color.IndianRed

            estilo_c.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)

            Dim column_area As DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn = dgvBitacora.Columns("ColumnArea")
            column_area.DataSource = sqlExecute("select cod_area, nombre from areas where cod_comp = '090'")
            column_area.ValueMember = "cod_area"
            column_area.DisplayMember = "nombre"

            Dim column_super As DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn = dgvBitacora.Columns("ColumnSuper")
            column_super.DataSource = sqlExecute("select cod_super, nombre from super where cod_comp = '090'")
            column_super.ValueMember = "cod_super"
            column_super.DisplayMember = "nombre"

            Dim column_maxben As DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn = dgvBitacora.Columns("ColumnMaxBen")
            column_maxben.DataSource = sqlExecute("select * from max_beneficio order by cod_maxben asc", "sermed")
            column_maxben.ValueMember = "cod_maxben"
            column_maxben.DisplayMember = "maxben"


            'VISTA DETALLE

            llenar_busquedaSintomas()
            llenar_busquedaTratamientos()

            ComboTree1.DataSource = sqlExecute("select * from max_beneficio order by cod_maxben asc", "sermed")
            ComboTree1.ValueMember = "cod_maxben"
            ComboTree1.DisplayMembers = "maxben"

            '---------------------------------------------
            dtpFecha.Value = Now.Date

        Catch ex As Exception

        End Try
    End Sub

    Dim h_ini_edit As String = ""
    Dim fecha_edit As String = ""
    Private Sub dgvBitacora_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvBitacora.CellBeginEdit
        Try
            Dim columna As String = dgvBitacora.Columns(e.ColumnIndex).Name
            Select Case columna
                Case "ColumnMaxBen"
                    dgvBitacora.Rows(e.RowIndex).Cells("ColumnMaxBen").Value = 1
                Case "ColumnHoraFin"
                    Dim valor As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnHoraFin").Value
                    If valor Is Nothing Then
                        valor = ""
                    End If
                    If valor.Trim = "" Then
                        Dim id_bitacora As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnID").Value.ToString
                        Dim hora As String = Now.Hour.ToString.PadLeft(2, "0") & ":" & Now.Minute.ToString.PadLeft(2, "0")
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnHoraFin").Value = hora
                        sqlExecute("update bitacora_enfermeria set hora_fin = '" & hora & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnHoraFin").Style = estilo_c
                        e.Cancel = True
                    End If
                Case "ColumnHora"
                    h_ini_edit = dgvBitacora.Rows(e.RowIndex).Cells("ColumnHora").Value
                Case "ColumnFecha"
                    fecha_edit = dgvBitacora.Rows(e.RowIndex).Cells("ColumnFecha").Value

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridViewX1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBitacora.CellEndEdit
        Try

            Dim id_bitacora As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnID").Value.ToString

            Dim columna As String = dgvBitacora.Columns(e.ColumnIndex).Name
            Select Case columna
                Case "ColumnReloj"
                    Dim reloj As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj").Value.ToString.PadLeft(6, "0")
                    Dim dtExiste As DataTable = sqlExecute("select reloj, nombres, cod_area, cod_super from personalvw where reloj = '" & reloj & "'")
                    If dtExiste.Rows.Count > 0 Then
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj").Value = reloj
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj").Style = estilo_a

                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnNombre").Value = dtExiste.Rows(0)("nombres")

                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnArea").Value = dtExiste.Rows(0)("cod_area")
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnArea").Style = estilo_c

                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnSuper").Value = dtExiste.Rows(0)("cod_super")
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnSuper").Style = estilo_c

                        sqlExecute("update bitacora_enfermeria set reloj = '" & reloj & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
                        sqlExecute("update bitacora_enfermeria set cod_area = '" & dtExiste.Rows(0)("cod_area") & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
                        sqlExecute("update bitacora_enfermeria set cod_super = '" & dtExiste.Rows(0)("cod_super") & "' where id_bitacora = '" & id_bitacora & "'", "sermed")

                    Else
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj").Value = reloj
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj").Style = estilo_b

                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnNombre").Value = "N/A"
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnArea").Value = ""
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnSuper").Value = ""

                    End If
                Case "ColumnComentarios"
                    Dim comentarios As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnComentarios").Value
                    comentarios = comentarios.Substring(0, IIf(comentarios.Trim.Length >= 500, 499, comentarios.Length)).Trim
                    sqlExecute("update bitacora_enfermeria set comentarios = '" & comentarios & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
                Case "ColumnTelefono"
                    Dim telefono As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnTelefono").Value
                    telefono = telefono.Substring(0, IIf(telefono.Trim.Length >= 30, 29, telefono.Length)).Trim
                    sqlExecute("update bitacora_enfermeria set telefono = '" & telefono & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
                Case "ColumnMaxBen"
                    Try
                        Dim maxben As Integer = dgvBitacora.Rows(e.RowIndex).Cells("ColumnMaxBen").Value
                        sqlExecute("update bitacora_enfermeria set maxben = '" & maxben & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
                    Catch ex As Exception

                    End Try
                Case "ColumnHora"
                    Try
                        Dim hora_ini As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnHora").Value
                        Dim h As Integer = hora_ini.Replace(":", ".").Split(".")(0)
                        If h >= 24 Or h < 0 Then
                            Err.Raise(-1)
                        End If
                        Dim m As Integer = 0
                        Try
                            m = hora_ini.Replace(":", ".").Split(".")(1)
                            If m > 59 Or h < 0 Then
                                Err.Raise(-1)
                            End If
                        Catch ex As Exception
                            If hora_ini.Replace(":", ".").Contains(".") Then
                                Err.Raise(-1)
                            End If
                        End Try

                        Dim h_ini As String = h.ToString.PadLeft(2, "0") & ":" & m.ToString.PadLeft(2, "0")

                        sqlExecute("update bitacora_enfermeria set hora = '" & h_ini & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnHora").Value = h_ini
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnHora").Style = estilo_c
                    Catch ex As Exception
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnHora").Value = h_ini_edit
                    End Try
                Case "ColumnHoraFin"
                    Try
                        Dim hora_fin As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnHoraFin").Value
                        Dim h As Integer = hora_fin.Replace(":", ".").Split(".")(0)
                        If h >= 24 Or h < 0 Then
                            Err.Raise(-1)
                        End If
                        Dim m As Integer = 0
                        Try
                            m = hora_fin.Replace(":", ".").Split(".")(1)
                            If m > 59 Or h < 0 Then
                                Err.Raise(-1)
                            End If
                        Catch ex As Exception
                            If hora_fin.Replace(":", ".").Contains(".") Then
                                Err.Raise(-1)
                            End If
                        End Try

                        Dim h_fin As String = h.ToString.PadLeft(2, "0") & ":" & m.ToString.PadLeft(2, "0")

                        sqlExecute("update bitacora_enfermeria set hora_fin = '" & h_fin & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnHoraFin").Value = h_fin
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnHoraFin").Style = estilo_c
                    Catch ex As Exception
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnHoraFin").Value = "**.**"
                        sqlExecute("update bitacora_enfermeria set hora_fin = null where id_bitacora = '" & id_bitacora & "'", "sermed")
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnHoraFin").Style = estilo_b
                    End Try
                Case "ColumnFecha"
                    Try
                        Dim f As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnFecha").Value
                        Dim d As Date = Date.Parse(fecha_edit).Date
                        Try
                            d = Date.Parse(f).Date
                        Catch ex As Exception
                            MessageBox.Show("La fecha capturada no es válida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Err.Raise(-1)
                        End Try

                        If MessageBox.Show("¿Confirma que desea cambiar la fecha del registro de " & Date.Parse(fecha_edit).ToShortDateString & " a " & Date.Parse(f).ToShortDateString & "?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                            sqlExecute("update bitacora_enfermeria set fecha = '" & FechaSQL(d) & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnFecha").Value = FechaSQL(d)
                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnFecha").Style = estilo_c
                            dtpFecha.Value = Date.Parse(f)
                            Exit Sub
                        Else
                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnFecha").Value = fecha_edit
                        End If

                    Catch ex As Exception
                        dgvBitacora.Rows(e.RowIndex).Cells("ColumnFecha").Value = fecha_edit
                    End Try
                Case Else

            End Select

            If VistaDetalle.Expanded = True Then
                MostrarInformacionDetalle(id_bitacora)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvBitacora_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvBitacora.RowsAdded

        Try
            Dim id As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnID").Value

            dgvBitacora.Rows(e.RowIndex).Cells("ColumnFecha").Style = estilo_c
            dgvBitacora.Rows(e.RowIndex).Cells("ColumnMaxBen").Style = estilo_c

            dgvBitacora.Rows(e.RowIndex).Cells("ColumnBuscar").Value = "Buscar"
            dgvBitacora.Rows(e.RowIndex).Cells("ColumnBuscar").Style = estilo_c

            If id Is Nothing Then
                Dim fecha As String = FechaSQL(dtpFecha.Value)
                Dim hora As String = Now.Hour.ToString.PadLeft(2, "0") & ":" & Now.Minute.ToString.PadLeft(2, "0")

                dgvBitacora.Rows(e.RowIndex).Cells("ColumnFecha").Value = fecha
                dgvBitacora.Rows(e.RowIndex).Cells("ColumnHora").Value = hora

                dgvBitacora.Rows(e.RowIndex).Cells("ColumnSintomas").Value = "Agregar síntomas"
                dgvBitacora.Rows(e.RowIndex).Cells("ColumnSintomas").Style = estilo_c

                dgvBitacora.Rows(e.RowIndex).Cells("ColumnTratamiento").Value = "Agregar tratamientos"
                dgvBitacora.Rows(e.RowIndex).Cells("ColumnTratamiento").Style = estilo_c

                sqlExecute("insert into bitacora_enfermeria (fecha, hora, usuario, registro, maxben) values ('" & fecha & "', '" & hora & "', '" & Usuario & "', getdate(), '0')", "sermed")
                Dim dtID As DataTable = sqlExecute("select * from bitacora_enfermeria where usuario = '" & Usuario & "' order by registro desc", "sermed")
                If dtID.Rows.Count > 0 Then
                    id = dtID.Rows(0)("id_bitacora")
                End If

                dgvBitacora.Rows(e.RowIndex).Cells("ColumnID").Value = id

                If VistaDetalle.Expanded = True Then
                    MostrarInformacionDetalle(id)
                End If

                dgvBitacora.CurrentCell = dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj")
                dgvBitacora.BeginEdit(False)

                Exit Sub
            End If

            If id IsNot Nothing Then
                Dim reloj As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj").Value

                Dim dtExiste As DataTable = sqlExecute("select reloj, nombres from personalvw where reloj = '" & reloj & "'")
                If dtExiste.Rows.Count > 0 Then
                    dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj").Style = estilo_a
                Else
                    dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj").Style = estilo_b
                End If

                dgvBitacora.Rows(e.RowIndex).Cells("ColumnArea").Style = estilo_c
                dgvBitacora.Rows(e.RowIndex).Cells("ColumnSuper").Style = estilo_c
                dgvBitacora.Rows(e.RowIndex).Cells("ColumnHoraFin").Style = estilo_c

                dgvBitacora.Rows(e.RowIndex).Cells("ColumnSintomas").Style = estilo_c
                dgvBitacora.Rows(e.RowIndex).Cells("ColumnTratamiento").Style = estilo_c
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            dgvBitacora.Rows.Add()
        Catch ex As Exception

        End Try
    End Sub

    Private last_key As Keys
    Private Sub frmTa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        last_key = e.KeyCode
        Try
            If e.KeyCode = Keys.F1 Then
                btnAgregar.PerformClick()
            ElseIf e.KeyCode = Keys.F2 Then
                VistaDetalle.Expanded = Not VistaDetalle.Expanded
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        Try
            refrescando = True
            MostrarInformacionFecha(dtpFecha.Value)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub MostrarInformacionFecha(fecha As Date)
        Dim dtBitacoraFecha As DataTable = sqlExecute("select * from bitacora_enfermeria where fecha = '" & FechaSQL(fecha) & "' order by fecha asc, hora asc", "sermed")
        dgvBitacora.Rows.Clear()
        For Each row As DataRow In dtBitacoraFecha.Rows
            Dim drow As New DataGridViewRow

            drow.CreateCells(dgvBitacora)

            drow.Cells(dgvBitacora.Columns("ColumnID").Index).Value = row("id_bitacora")
            drow.Cells(dgvBitacora.Columns("ColumnFecha").Index).Value = FechaSQL(row("fecha"))
            drow.Cells(dgvBitacora.Columns("ColumnHora").Index).Value = row("hora")

            drow.Cells(dgvBitacora.Columns("ColumnReloj").Index).Value = IIf(IsDBNull(row("reloj")), "", row("reloj"))

            Dim dtExiste As DataTable = sqlExecute("select reloj, nombres from personalvw where reloj = '" & IIf(IsDBNull(row("reloj")), "", row("reloj")) & "'")
            If dtExiste.Rows.Count > 0 Then
                drow.Cells(dgvBitacora.Columns("ColumnNombre").Index).Value = dtExiste.Rows(0)("nombres")
            End If

            drow.Cells(dgvBitacora.Columns("ColumnArea").Index).Value = IIf(IsDBNull(row("cod_area")), "", row("cod_area"))
            drow.Cells(dgvBitacora.Columns("ColumnSuper").Index).Value = IIf(IsDBNull(row("cod_super")), "", row("cod_super"))

            drow.Cells(dgvBitacora.Columns("ColumnComentarios").Index).Value = RTrim(IIf(IsDBNull(row("comentarios")), "", row("comentarios")))
            drow.Cells(dgvBitacora.Columns("ColumnTelefono").Index).Value = RTrim(IIf(IsDBNull(row("telefono")), "", row("telefono")))
            drow.Cells(dgvBitacora.Columns("ColumnMaxBen").Index).Value = RTrim(IIf(IsDBNull(row("maxben")), "", row("maxben")))
            drow.Cells(dgvBitacora.Columns("ColumnHoraFin").Index).Value = RTrim(IIf(IsDBNull(row("hora_fin")), "", row("hora_fin")))

            If IsDBNull(row("sintomas")) Then
                drow.Cells(dgvBitacora.Columns("ColumnSintomas").Index).Value = "Agregar síntomas"
            Else
                drow.Cells(dgvBitacora.Columns("ColumnSintomas").Index).Value = "Editar síntomas"
            End If

            If IsDBNull(row("tratamiento")) Then
                drow.Cells(dgvBitacora.Columns("ColumnTratamiento").Index).Value = "Agregar tratamientos"
            Else
                drow.Cells(dgvBitacora.Columns("ColumnTratamiento").Index).Value = "Editar tratamientos"
            End If


            dgvBitacora.Rows.Add(drow)

            Application.DoEvents()
        Next
    End Sub


    Private Sub dgvBitacora_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBitacora.CellContentClick
        Try
            If dgvBitacora.Columns(e.ColumnIndex).Name = "ColumnSintomas" Then
                Dim frm As New frmSeleccionarSintomas
                Dim id_bitacora As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnID").Value.ToString
                frm.id_bitacora = id_bitacora

                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim dtRegistro As DataTable = sqlExecute("select * from bitacora_enfermeria where id_bitacora = '" & id_bitacora & "' and sintomas is not null", "sermed")
                    If dtRegistro.Rows.Count > 0 Then
                        dgvBitacora.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Editar síntomas"
                    Else
                        dgvBitacora.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Agregar síntomas"
                    End If
                End If
            ElseIf dgvBitacora.Columns(e.ColumnIndex).Name = "ColumnTratamiento" Then

                Dim frm As New frmSeleccionarTratamientos
                Dim id_bitacora As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnID").Value.ToString
                frm.id_bitacora = id_bitacora

                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim dtRegistro As DataTable = sqlExecute("select * from bitacora_enfermeria where id_bitacora = '" & id_bitacora & "' and tratamiento is not null", "sermed")
                    If dtRegistro.Rows.Count > 0 Then
                        dgvBitacora.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Editar tratamientos"
                    Else
                        dgvBitacora.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Agregar tratamientos"
                    End If
                End If

            ElseIf dgvBitacora.Columns(e.ColumnIndex).Name = "ColumnBuscar" Then
                Try
                    frmBuscar.ShowDialog(Me)
                    If Reloj <> "CANCEL" Then
                        Dim id_bitacora As String = dgvBitacora.Rows(e.RowIndex).Cells("ColumnID").Value.ToString
                        Dim r As String = Reloj
                        Dim dtExiste As DataTable = sqlExecute("select reloj, nombres, cod_area, cod_super from personalvw where reloj = '" & r & "'")
                        If dtExiste.Rows.Count > 0 Then
                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj").Value = r
                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj").Style = estilo_a

                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnNombre").Value = dtExiste.Rows(0)("nombres")

                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnArea").Value = dtExiste.Rows(0)("cod_area")
                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnArea").Style = estilo_c

                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnSuper").Value = dtExiste.Rows(0)("cod_super")
                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnSuper").Style = estilo_c

                            sqlExecute("update bitacora_enfermeria set reloj = '" & r & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
                            sqlExecute("update bitacora_enfermeria set cod_area = '" & dtExiste.Rows(0)("cod_area") & "' where id_bitacora = '" & id_bitacora & "'", "sermed")
                            sqlExecute("update bitacora_enfermeria set cod_super = '" & dtExiste.Rows(0)("cod_super") & "' where id_bitacora = '" & id_bitacora & "'", "sermed")


                        Else
                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj").Value = r
                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnReloj").Style = estilo_b

                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnNombre").Value = "N/A"
                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnArea").Value = ""
                            dgvBitacora.Rows(e.RowIndex).Cells("ColumnSuper").Value = ""

                        End If
                    End If
                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub reporte(dtBitacora As DataTable)
        Dim dtDatos As New DataTable

        Try

            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")

            dtDatos.Columns.Add("cod_super")
            dtDatos.Columns.Add("nombre_super")
            dtDatos.Columns.Add("cod_area")
            dtDatos.Columns.Add("nombre_area")

            dtDatos.Columns.Add("fecha")
            dtDatos.Columns.Add("hora")
            dtDatos.Columns.Add("hora_fin")

            dtDatos.Columns.Add("comentarios")

            dtDatos.Columns.Add("telefono")

            dtDatos.Columns.Add("sintoma1")
            dtDatos.Columns.Add("sintoma2")
            dtDatos.Columns.Add("sintoma3")
            dtDatos.Columns.Add("sintoma4")
            dtDatos.Columns.Add("sintoma5")
            dtDatos.Columns.Add("sintoma6")
            dtDatos.Columns.Add("sintoma7")
            dtDatos.Columns.Add("sintoma8")
            dtDatos.Columns.Add("sintoma9")
            dtDatos.Columns.Add("sintoma10")

            dtDatos.Columns.Add("tratamiento1")
            dtDatos.Columns.Add("tratamiento2")
            dtDatos.Columns.Add("tratamiento3")
            dtDatos.Columns.Add("tratamiento4")
            dtDatos.Columns.Add("tratamiento5")
            dtDatos.Columns.Add("tratamiento6")
            dtDatos.Columns.Add("tratamiento7")
            dtDatos.Columns.Add("tratamiento8")
            dtDatos.Columns.Add("tratamiento9")
            dtDatos.Columns.Add("tratamiento10")

            dtDatos.Columns.Add("dias_tratamiento1")
            dtDatos.Columns.Add("dias_tratamiento2")
            dtDatos.Columns.Add("dias_tratamiento3")
            dtDatos.Columns.Add("dias_tratamiento4")
            dtDatos.Columns.Add("dias_tratamiento5")
            dtDatos.Columns.Add("dias_tratamiento6")
            dtDatos.Columns.Add("dias_tratamiento7")
            dtDatos.Columns.Add("dias_tratamiento8")
            dtDatos.Columns.Add("dias_tratamiento9")
            dtDatos.Columns.Add("dias_tratamiento10")

            dtDatos.Columns.Add("diarioconsultas")

            For Each row As DataRow In dtBitacora.Rows

                Dim drow As DataRow = dtDatos.NewRow

                drow("reloj") = row("reloj")
                drow("nombres") = row("nombres")
                drow("cod_super") = row("cod_super")
                drow("cod_area") = row("cod_area")

                drow("fecha") = FechaSQL(row("fecha"))
                drow("hora") = row("hora")
                drow("hora_fin") = row("hora_fin")

                drow("comentarios") = row("comentarios")
                drow("telefono") = row("telefono")




                Dim r As String = "del " & FechaSQL(FechaInicial) & " al " & FechaSQL(FechaFinal)
                drow("diarioconsultas") = r



              





                'desglosar sintomas
                Dim sintomas As String() = {""}
                If IsDBNull(row("sintomas")) Then
                    sintomas = {""}
                Else
                    sintomas = RTrim(row("sintomas")).Split(";")
                End If

                For i As Integer = 0 To sintomas.Length - 1
                    Dim sintoma As String = ""
                    Dim cod_sin As String = sintomas(i)

                    Dim parent As Boolean = True

                    While parent
                        Dim n As String = ""

                        Dim dtSintoma As DataTable = sqlExecute("select cod_sin, nombre, parent, case when parent is null then 0 else 1 end as p from arbol_sintomas where cod_sin = '" & cod_sin & "'", "sermed")
                        If dtSintoma.Rows.Count > 0 Then
                            n = dtSintoma.Rows(0)("nombre")
                            parent = dtSintoma.Rows(0)("p")
                            If parent Then
                                cod_sin = dtSintoma.Rows(0)("parent")
                            End If

                            sintoma = n.Trim & IIf(sintoma.Trim = "", "", " - ") & sintoma
                        Else
                            parent = False
                        End If

                    End While

                    drow("sintoma" & (i + 1)) = sintoma
                Next

                'desglosar tratamientos
                Dim tratamientos As String() = {""}
                If IsDBNull(row("tratamiento")) Then
                    tratamientos = {"-"}
                Else
                    tratamientos = RTrim(row("tratamiento")).Split(";")
                End If

                For i As Integer = 0 To tratamientos.Length - 1

                    Dim tratamiento As String = tratamientos(i)
                    If tratamiento <> "NULL" And tratamiento <> "" Then
                        Dim _t As String = tratamiento.Split("-")(0)
                        Dim _d As String = tratamiento.Split("-")(1)

                        Dim _n As String = ""
                        Dim _p As String = ""

                        Dim dtTratamiento As DataTable = sqlExecute("select * from tratamientos where id_recurso = '" & _t & "'", "sermed")
                        If dtTratamiento.Rows.Count > 0 Then
                            _n = RTrim(dtTratamiento.Rows(0)("descripcion"))
                            _p = RTrim(dtTratamiento.Rows(0)("posologia"))
                        End If

                        drow("tratamiento" & (i + 1)) = _n & ", " & _p
                        drow("dias_tratamiento" & (i + 1)) = _d
                    End If
                Next

                dtDatos.Rows.Add(drow)

            Next

            frmVistaPrevia.LlamarReporte("bitacora enfermeria", dtDatos)
            frmVistaPrevia.ShowDialog()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            frmRangoFechas.frmRangoFechas_fecha_ini = Now.AddDays(-31)
            frmRangoFechas.frmRangoFechas_fecha_fin = Now
            frmRangoFechas.ShowDialog()

            'Dim dtBitacora As DataTable = sqlExecute("select bitacora_enfermeria.*, personalvw.nombres from bitacora_enfermeria " & _
            '                                                     Space(1) & "left join personal.dbo.personalvw on personalvw.reloj = bitacora_enfermeria.reloj" & _
            '                                                     Space(1) & "where fecha = '" & FechaSQL(dtpFecha.Value) & "'", "sermed")

            Dim dtBitacora As DataTable = sqlExecute("select bitacora_enfermeria.*, personalvw.nombres from bitacora_enfermeria " & _
                                                    Space(1) & "left join personal.dbo.personalvw on personalvw.reloj = bitacora_enfermeria.reloj" & _
                                                    Space(1) & "where fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "'", "sermed")
            reporte(dtBitacora)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnReporteDetalle.Click
        Dim dtBitacora As DataTable = sqlExecute("select bitacora_enfermeria.*, personalvw.nombres from bitacora_enfermeria " & _
                                                             Space(1) & "left join personal.dbo.personalvw on personalvw.reloj = bitacora_enfermeria.reloj" & _
                                                             Space(1) & "where id_bitacora = '" & lblID.Text & "'", "sermed")
        reporte(dtBitacora)
    End Sub

    Private Sub ExpandablePanel1_ExpandedChanged(sender As Object, e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles VistaDetalle.ExpandedChanged
        Try

            If dgvBitacora.SelectedCells.Count >= 1 Or dgvBitacora.SelectedRows.Count >= 1 Then
                VistaDetalle.Expanded = VistaDetalle.Expanded
            Else
                VistaDetalle.Expanded = False
                Exit Sub
            End If

            ColumnSintomas.Visible = Not VistaDetalle.Expanded
            ColumnTratamiento.Visible = Not VistaDetalle.Expanded
            ColumnArea.Visible = Not VistaDetalle.Expanded
            'ColumnBuscar.Visible = Not VistaDetalle.Expanded
            ColumnSuper.Visible = Not VistaDetalle.Expanded
            ColumnTelefono.Visible = Not VistaDetalle.Expanded
            ColumnComentarios.Visible = Not VistaDetalle.Expanded
            ColumnMaxBen.Visible = Not VistaDetalle.Expanded
            'ColumnMisc.Visible = Not VistaDetalle.Expanded

            If VistaDetalle.Expanded = True Then
                dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                For Each row As DataGridViewRow In dgvBitacora.Rows
                    If row.Cells("ColumnID").Value = folio_seleccionado Then
                        row.Selected = True
                    End If
                Next
            Else
                dgvBitacora.SelectionMode = DataGridViewSelectionMode.CellSelect
                For Each row As DataGridViewRow In dgvBitacora.Rows
                    If row.Cells("ColumnID").Value = folio_seleccionado Then
                        row.Cells("ColumnNombre").Selected = True
                    End If
                Next
            End If


            If VistaDetalle.Expanded = True Then
                ColumnHoraFin.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Else
                ColumnHoraFin.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                ColumnHoraFin.Width = 150
            End If

            For Each column As DataGridViewColumn In dgvBitacora.Columns
                'column.ReadOnly = ExpandablePanel1.Expanded
            Next

        Catch ex As Exception

        End Try

    End Sub

    Dim sintomas_detalle As String = ""
    Dim tratamientos_detalle As String = ""
    Private Sub MostrarInformacionDetalle(folio As String)
        Try

            editar = False

            txtBuscarTratamientos.Text = ""
            txtBuscarSintomas.Text = ""

            Panel5.Enabled = editar

            btnAceptar.Visible = False
            btnEditar.Text = "Editar"
            btnEditar.Image = My.Resources.Edit

            Panel5.Visible = True
            btnReporteDetalle.Visible = True
            btnEditar.Visible = True

            Dim dtBitacora As DataTable = sqlExecute("select * from bitacora_enfermeria where id_bitacora = '" & folio & "'", "sermed")
            If dtBitacora.Rows.Count > 0 Then
                Dim drow As DataRow = dtBitacora.Rows(0)
                lblID.Text = folio

                If IsDBNull(drow("reloj")) Then
                    txtReloj.Text = "------"
                    txtNombre.Text = "No disponible"
                    txtArea.Text = "No disponible"
                    txtSupervisor.Text = "No disponible"
                    Err.Raise(-1)
                End If

                txtReloj.Text = drow("reloj")

                Dim dtNombre As DataTable = sqlExecute("select reloj, nombres from personalvw where reloj = '" & drow("reloj") & "'")
                If dtNombre.Rows.Count > 0 Then
                    txtNombre.Text = dtNombre.Rows(0)("nombres")
                End If

                Dim dtArea As DataTable = sqlExecute("select * from areas where cod_area = '" & drow("cod_area") & "'")
                If dtArea.Rows.Count > 0 Then
                    txtArea.Text = dtArea.Rows(0)("nombre")
                End If

                Dim dtSuper As DataTable = sqlExecute("select * from super where cod_super = '" & drow("cod_super") & "'")
                If dtSuper.Rows.Count > 0 Then
                    txtSupervisor.Text = dtSuper.Rows(0)("nombre")
                End If


                'SINTOMAS
                sintomas_detalle = ""

                If IsDBNull(drow("sintomas")) Then
                    sintomas_detalle = ""
                Else
                    sintomas_detalle = RTrim(drow("sintomas"))
                End If

                cargar_sintomas(sintomas_detalle)

                'Tratamientos
                tratamientos_detalle = ""

                If IsDBNull(drow("tratamiento")) Then
                    tratamientos_detalle = ""
                Else
                    tratamientos_detalle = RTrim(drow("tratamiento"))
                End If

                cargar_tratamientos(tratamientos_detalle)

                'Teléfono
                If IsDBNull(drow("telefono")) Then
                    txtTelefono.Text = ""
                Else
                    txtTelefono.Text = RTrim(drow("telefono"))
                End If

                'Comentarios
                If IsDBNull(drow("comentarios")) Then
                    rtbComentarios.Text = ""
                Else
                    rtbComentarios.Text = RTrim(drow("comentarios"))
                End If

                'maxben

                If IsDBNull(drow("maxben")) Then
                    ComboTree1.SelectedValue = 0
                Else
                    ComboTree1.SelectedValue = drow("maxben")
                End If

            End If

        Catch ex As Exception
            Panel5.Visible = False
            btnReporteDetalle.Visible = False
            btnEditar.Visible = False
        End Try
    End Sub

    '---------------------------------------------------

    Private Sub cargar_tratamientos(tratamientos As String)

        Try
            dgvTratamientos.AutoGenerateColumns = False
            dgvTratamientos.Visible = True

            btnAgregarTratamientos.Tooltip = IIf(dgvTratamientos.Visible, "Agregar", "Aceptar")
            btnAgregarTratamientos.Image = IIf(dgvTratamientos.Visible, My.Resources.Add, My.Resources.Ok16)

            Dim dtTablaTratamientos As New DataTable
            dtTablaTratamientos.Columns.Add("id_recurso")
            dtTablaTratamientos.Columns.Add("descripcion")
            dtTablaTratamientos.Columns.Add("posologia")
            dtTablaTratamientos.Columns.Add("dias_tratamiento")

            Dim t As String() = tratamientos.Split(";")            

            For Each tratamiento As String In t
                If tratamiento <> "" Then

                    Dim _t As String = tratamiento.Split("-")(0)
                    Dim _d As String = tratamiento.Split("-")(1)

                    Dim _n As String = ""
                    Dim _p As String = ""
                    Dim dtTratamiento As DataTable = sqlExecute("select * from tratamientos where id_recurso = '" & _t & "'", "sermed")
                    If dtTratamiento.Rows.Count > 0 Then
                        _n = dtTratamiento.Rows(0)("descripcion")
                        _p = dtTratamiento.Rows(0)("posologia")
                    End If

                    dtTablaTratamientos.Rows.Add({_t, _n, _p, _d})
                End If
            Next

            dgvTratamientos.DataSource = dtTablaTratamientos

            btnBorrarTratamientos.Visible = False

        Catch ex As Exception

        End Try

    End Sub

    '---------------------------------------------

    Private Sub cargar_sintomas(sintomas As String)

        dgvSintomas.AutoGenerateColumns = False
        dgvSintomas.Visible = True

       

        btnAgregarSintomas.Tooltip = IIf(dgvSintomas.Visible, "Agregar", "Aceptar")
        btnAgregarSintomas.Image = IIf(dgvSintomas.Visible, My.Resources.Add, My.Resources.Ok16)

        Dim dtTablaSintomas As New DataTable
        dtTablaSintomas.Columns.Add("cod_sin")
        dtTablaSintomas.Columns.Add("descripcion")

        Dim s As String() = sintomas.Split(";")
        Dim c As String = ""

        For Each sintoma As String In s
            If sintoma <> "" Then
                Dim s_ As String = sintoma
                c = ""
                Dim parent As Boolean = True

                While parent
                    Dim dtCodSin As DataTable = sqlExecute("select * from arbol_sintomas where cod_sin = '" & s_ & "'", "sermed")
                    If dtCodSin.Rows.Count > 0 Then
                        If sintoma = s_ Then
                            c = RTrim(dtCodSin.Rows(0)("nombre"))
                        Else
                            c = RTrim(dtCodSin.Rows(0)("nombre")) & " - " & c
                        End If

                        If IsDBNull(dtCodSin.Rows(0)("parent")) Then
                            parent = False
                        Else
                            s_ = RTrim(dtCodSin.Rows(0)("parent"))
                        End If
                    Else
                        parent = False
                    End If
                End While
                dtTablaSintomas.Rows.Add({sintoma, c})
            End If
        Next

        dgvSintomas.DataSource = dtTablaSintomas

        btnBorrarSintomas.Visible = False
    End Sub

    Dim folio_seleccionado As String = ""
    Private Sub dgvBitacora_SelectionChanged(sender As Object, e As EventArgs) Handles dgvBitacora.SelectionChanged
        Try
            If dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect Then

                Dim folio As String = dgvBitacora.SelectedRows(0).Cells("ColumnID").Value
                folio_seleccionado = folio
                MostrarInformacionDetalle(folio)
            ElseIf dgvBitacora.SelectionMode = DataGridViewSelectionMode.CellSelect Then

                Dim folio As String = dgvBitacora.Rows(dgvBitacora.SelectedCells(0).RowIndex).Cells("ColumnID").Value
                folio_seleccionado = folio
                MostrarInformacionDetalle(folio)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Dim editar As Boolean = False
    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            editar = Not editar
            Panel5.Enabled = editar

            If editar Then
                btnAceptar.Visible = True
                btnEditar.Text = "Cancelar"
                btnEditar.Image = My.Resources.Cancel16
            Else
                btnAceptar.Visible = False
                btnEditar.Text = "Editar"
                btnEditar.Image = My.Resources.Edit

                MostrarInformacionDetalle(lblID.Text)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim id As String = lblID.Text

            'Guardar comentarios
            If RTrim(rtbComentarios.Text) <> "" Then
                sqlExecute("update bitacora_enfermeria set comentarios = '" & RTrim(rtbComentarios.Text) & "' where id_bitacora = '" & id & "'", "sermed")
            Else
                sqlExecute("update bitacora_enfermeria set comentarios = null where id_bitacora = '" & id & "'", "sermed")
            End If

            'Guardar telefono
            If RTrim(txtTelefono.Text) <> "" Then
                sqlExecute("update bitacora_enfermeria set telefono = '" & RTrim(txtTelefono.Text) & "' where id_bitacora = '" & id & "'", "sermed")
            Else
                sqlExecute("update bitacora_enfermeria set telefono = null where id_bitacora = '" & id & "'", "sermed")
            End If

            'Guardar maxben
            If ComboTree1.SelectedValue > -1 Then
                sqlExecute("update bitacora_enfermeria set maxben = '" & ComboTree1.SelectedValue & "' where id_bitacora = '" & id & "'", "sermed")
            End If

            'Guardar sintomas
            sqlExecute("update bitacora_enfermeria set sintomas = '" & sintomas_detalle & "' where id_bitacora = '" & id & "'", "sermed")

            'Guardar tratamientos
            sqlExecute("update bitacora_enfermeria set tratamiento = '" & tratamientos_detalle & "' where id_bitacora = '" & id & "'", "sermed")

            editar = False
            Panel5.Enabled = editar
            btnAceptar.Visible = False
            btnEditar.Text = "Editar"
            btnEditar.Image = My.Resources.Edit

            MostrarInformacionDetalle(id)

        Catch ex As Exception
            editar = False
            Panel5.Enabled = editar
            btnAceptar.Visible = False
            btnEditar.Text = "Editar"
            btnEditar.Image = My.Resources.Edit
        End Try
    End Sub



    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrarSintomas.Click
        Try

            If dgvSintomas.SelectedRows.Count > 0 Then
                Dim s As String = ""
                For Each row As DataGridViewRow In dgvSintomas.Rows
                    If row.Index <> dgvSintomas.SelectedRows(0).Index Then
                        Dim sintoma As String = RTrim(row.Cells("ColumnCodSintoma").Value)
                        If s = "" Then
                            s = sintoma
                        Else
                            s = s & ";" & sintoma
                        End If
                    End If
                Next

                sintomas_detalle = s
                cargar_sintomas(sintomas_detalle)
            Else
                MessageBox.Show("Es necesario seleccionar primero un síntoma a borrar", "Sin síntoma seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX2_Click_1(sender As Object, e As EventArgs) Handles btnAgregarSintomas.Click

        Try
            If Not dgvSintomas.Visible And (dgvBusquedaSintomas.SelectedRows.Count > 0) Then
                Dim sintoma As String = dgvBusquedaSintomas.SelectedRows(0).Cells("ColumnCodSinBusqueda").Value
                If sintomas_detalle = "" Then
                    sintomas_detalle = sintoma
                Else
                    sintomas_detalle &= ";" & sintoma
                End If
                cargar_sintomas(sintomas_detalle)
            Else
                dgvSintomas.Visible = Not dgvSintomas.Visible
            End If

            txtBuscarSintomas.Text = ""

            If dgvSintomas.Visible Then
                LabelVistaSintomas.Text = "Síntomas"
            Else
                LabelVistaSintomas.Text = "Busqueda"
            End If

            btnAgregarSintomas.Tooltip = IIf(dgvSintomas.Visible, "Agregar", "Aceptar")
            btnAgregarSintomas.Image = IIf(dgvSintomas.Visible, My.Resources.Add, My.Resources.Ok16)
            btnBorrarSintomas.Visible = dgvSintomas.Visible

            If Not dgvSintomas.Visible Then
                txtBuscarSintomas.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarSintomas.TextChanged
        Try
            Dim query As String = ""
            Dim texto As String = RTrim(txtBuscarSintomas.Text)
            texto = EliminaAcentos(texto)
            texto = texto.Replace(" ", "*")

            For Each s As String In texto.Split("*")
                query &= "(nombre like '%" & RTrim(s) & "%') AND"
            Next
            query = query.Substring(0, query.Length - 3)


            dgvBusquedaSintomas.DataSource = dtBusquedaSintomas.Select(query).CopyToDataTable

        Catch ex As Exception
            dgvBusquedaSintomas.DataSource = dtFallbackSintomas
        End Try
    End Sub

    Private Sub dgvSintomas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSintomas.Click
        If dgvSintomas.SelectedRows.Count > 0 Then
            btnBorrarSintomas.Visible = True
        Else
            btnBorrarSintomas.Visible = False
        End If
    End Sub

    Private Sub dgvTratamientos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTratamientos.Click
        If dgvTratamientos.SelectedRows.Count > 0 Then
            btnBorrarTratamientos.Visible = True
        Else
            btnBorrarTratamientos.Visible = False
        End If
    End Sub

    Private Sub dgvSintomas_DoubleClick(sender As Object, e As EventArgs) Handles dgvBusquedaSintomas.DoubleClick
        If dgvBusquedaSintomas.SelectedRows.Count > 0 Then
            btnAgregarSintomas.PerformClick()
        End If
    End Sub

    Private Sub btnAgregarTratamientos_Click(sender As Object, e As EventArgs) Handles btnAgregarTratamientos.Click



        Try
            If Not dgvTratamientos.Visible And (dgvBusquedaTratamientos.SelectedRows.Count > 0) Then

                Dim tratamiento As String = dgvBusquedaTratamientos.SelectedRows(0).Cells("ColumnCodBusqueda").Value
                Dim diastra As String = "0"
                If txtDiasTratamiento.Visible = True Then
                    diastra = txtDiasTratamiento.Value.ToString
                End If

                If tratamientos_detalle = "" Then
                    tratamientos_detalle = tratamiento & "-" & diastra
                Else
                    tratamientos_detalle &= ";" & tratamiento & "-" & diastra
                End If
                cargar_tratamientos(tratamientos_detalle)
            Else
                dgvTratamientos.Visible = Not dgvTratamientos.Visible
            End If

            txtBuscarTratamientos.Text = ""

            If dgvTratamientos.Visible Then
                LabelVistaTratamientos.Text = "Tratamientos"
            Else
                LabelVistaTratamientos.Text = "Busqueda"
            End If

            btnAgregarTratamientos.Tooltip = IIf(dgvTratamientos.Visible, "Agregar", "Aceptar")
            btnAgregarTratamientos.Image = IIf(dgvTratamientos.Visible, My.Resources.Add, My.Resources.Ok16)
            btnBorrarTratamientos.Visible = dgvTratamientos.Visible

            If Not dgvTratamientos.Visible Then
                txtBuscarTratamientos.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBorrarTratamientos_Click(sender As Object, e As EventArgs) Handles btnBorrarTratamientos.Click
        Try

            If dgvTratamientos.SelectedRows.Count > 0 Then
                Dim t As String = ""
                For Each row As DataGridViewRow In dgvTratamientos.Rows
                    If row.Index <> dgvTratamientos.SelectedRows(0).Index Then
                        Dim tratamiento As String = RTrim(row.Cells("ColumnCodTratamiento").Value)
                        Dim diastra As String = "0"

                        Try
                            diastra = RTrim(row.Cells("ColumnDiasTratamientoT").Value)
                        Catch ex As Exception

                        End Try

                        If t = "" Then
                            t = tratamiento & "-" & diastra
                        Else
                            t = t & ";" & tratamiento & "-" & diastra
                        End If
                    End If
                Next

                tratamientos_detalle = t
                cargar_tratamientos(tratamientos_detalle)
            Else
                MessageBox.Show("Es necesario seleccionar primero un tratamiento a borrar", "Sin tratamiento seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBuscarTratamientos_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarTratamientos.TextChanged
        Try
            Dim query As String = ""
            Dim texto As String = RTrim(txtBuscarTratamientos.Text)
            texto = EliminaAcentos(texto)
            texto = texto.Replace(" ", "*")

            For Each s As String In texto.Split("*")
                query &= "(descripcion like '%" & RTrim(s) & "%') AND"
            Next
            query = query.Substring(0, query.Length - 3)


            dgvBusquedaTratamientos.DataSource = dtBusquedaTratamientos.Select(query).CopyToDataTable

        Catch ex As Exception
            dgvBusquedaTratamientos.DataSource = dtFallbackTratamientos
        End Try
    End Sub

   
    Private Sub dgvBusquedaTratamientos_Click(sender As Object, e As EventArgs) Handles dgvBusquedaTratamientos.SelectionChanged
        Try
            Dim drow As DataGridViewRow = dgvBusquedaTratamientos.SelectedRows(0)

            Dim recurso As String = RTrim(drow.Cells("ColumnRecurso").Value)
            txtRecurso.Text = recurso
            txtRecurso.Visible = recurso <> ""

            Dim servicio As String = RTrim(drow.Cells("ColumnServicioTratamiento").Value)
            txtServicio.Text = servicio
            txtServicio.Visible = servicio <> ""

            Dim posologia As String = RTrim(drow.Cells("ColumnPosologia").Value)
            txtPosologia.Text = posologia
            txtPosologia.Visible = posologia <> ""

            Dim tipo As String = RTrim(drow.Cells("ColumnTipoTratamiento").Value)
            txtTipo.Text = tipo
            txtTipo.Visible = tipo <> ""

            Dim dias As String = RTrim(drow.Cells("ColumnDiasTratamiento").Value)
            If dias = "NA" Or dias = "" Then
                txtDiasTratamiento.Visible = False
                LabelDiasTra.Visible = False
                txtDiasTratamiento.Value = 0
            Else
                txtDiasTratamiento.Visible = True
                LabelDiasTra.Visible = True
                txtDiasTratamiento.Value = Integer.Parse(dias)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvBusquedaTratamientos_DoubleClick(sender As Object, e As EventArgs) Handles dgvBusquedaTratamientos.DoubleClick
        If dgvBusquedaTratamientos.SelectedRows.Count > 0 Then
            btnAgregarTratamientos.PerformClick()
        End If
    End Sub
End Class