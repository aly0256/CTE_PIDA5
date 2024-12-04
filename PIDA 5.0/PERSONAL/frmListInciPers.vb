Public Class frmListInciPers

    Dim Query As String = ""

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged

    End Sub

    Private Sub frmListInciPers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblAplic.Visible = False
        ReflectionLabel1.Visible = True
        MostrarInformacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 'Método que cargará los registros de vacaciones programadas al dataGridView para mostrar la información
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub MostrarInformacion()
        Try
            Dim dtListaNoVac As New DataTable, dtListaVac As New DataTable, dtListaCompleta As New DataTable, dtFiltroUser As New DataTable, _flt_user As String = "", _condRest As String = ""

            Dim dtListaNoVacTodas As New DataTable, dtListaVacTodas As New DataTable, dtListaCompletaTodas As New DataTable

            '===Acceso a solo ver a empleados de acuerdo al perfil
            Query = "select USERNAME,COD_PERFIL,reloj,FILTRO from SEGURIDAD.dbo.appuser where USERNAME='" & Usuario & "'"
            dtFiltroUser = sqlExecute(Query, "SEGURIDAD")
            If Not dtFiltroUser.Columns.Contains("Error") And dtFiltroUser.Rows.Count > 0 Then Try : _flt_user = dtFiltroUser.Rows(0).Item("FILTRO").ToString.Trim : Catch ex As Exception : _flt_user = "" : End Try

            If _flt_user <> "" Then _condRest = " and reloj in(select reloj from personal.dbo.personal where " & _flt_user & ") " Else _condRest = ""


            '========================Llenar info de solo las incidencias NO  aplicadas
            Query = "select usuario,reloj,nombre,depto,CAST(isnull(tipo_movimiento,0) AS VARCHAR) as 'tipo_movimiento',dias,f_ini,f_fin,motivo from solicitud_incidencias_personal where isnull(tipo_movimiento,0)<>0 and isnull(aplicado,0)=0" & _condRest
            dtListaNoVac = sqlExecute(Query, "PERSONAL")

            Query = "select usuario,reloj,nombre,depto,CAST(isnull(tipo_movimiento,0) AS VARCHAR) as 'tipo_movimiento',dias_vac as 'dias',f_ini_vac as 'f_ini',f_fin_vac as 'f_fin',motivo from solicitud_incidencias_personal where isnull(tipo_movimiento,0)=0 and isnull(aplicado,0)=0" & _condRest
            dtListaVac = sqlExecute(Query, "PERSONAL")

            If Not dtListaCompleta.Columns.Contains("usuario") Then dtListaCompleta.Columns.Add("usuario", Type.GetType("System.String"))
            If Not dtListaCompleta.Columns.Contains("reloj") Then dtListaCompleta.Columns.Add("reloj", Type.GetType("System.String"))
            If Not dtListaCompleta.Columns.Contains("nombre") Then dtListaCompleta.Columns.Add("nombre", Type.GetType("System.String"))
            If Not dtListaCompleta.Columns.Contains("depto") Then dtListaCompleta.Columns.Add("depto", Type.GetType("System.String"))
            If Not dtListaCompleta.Columns.Contains("tipo_movimiento") Then dtListaCompleta.Columns.Add("tipo_movimiento", Type.GetType("System.String"))
            If Not dtListaCompleta.Columns.Contains("dias") Then dtListaCompleta.Columns.Add("dias", Type.GetType("System.String"))
            If Not dtListaCompleta.Columns.Contains("f_ini") Then dtListaCompleta.Columns.Add("f_ini", Type.GetType("System.String"))
            If Not dtListaCompleta.Columns.Contains("f_fin") Then dtListaCompleta.Columns.Add("f_fin", Type.GetType("System.String"))
            If Not dtListaCompleta.Columns.Contains("motivo") Then dtListaCompleta.Columns.Add("motivo", Type.GetType("System.String"))



            If Not dtListaNoVac.Columns.Contains("Error") And dtListaNoVac.Rows.Count > 0 Then
                '=== Agregar lo que traiga dtlistaVac a dtLista


                For Each dr As DataRow In dtListaNoVac.Rows
                    Dim tipo_movimiento As String = "", f_ini As String = "", f_fin As String = ""
                    Try : tipo_movimiento = dr("tipo_movimiento").ToString.Trim : Catch ex As Exception : tipo_movimiento = "" : End Try
                    Try : f_ini = FechaSQL(dr("f_ini").ToString.Trim) : Catch ex As Exception : f_ini = "" : End Try
                    Try : f_fin = FechaSQL(dr("f_fin").ToString.Trim) : Catch ex As Exception : f_fin = "" : End Try

                    If tipo_movimiento = "0" Then
                        tipo_movimiento = "Vacación"
                    ElseIf tipo_movimiento = "1" Then
                        tipo_movimiento = "Permiso con goce de sueldo"
                    ElseIf tipo_movimiento = "2" Then
                        tipo_movimiento = "Permiso Sin goce de sueldo"
                    ElseIf tipo_movimiento = "3" Then
                        tipo_movimiento = "Tolerancia"
                    ElseIf tipo_movimiento = "4" Then
                        tipo_movimiento = "Falta injustificada"
                    ElseIf tipo_movimiento = "5" Then
                        tipo_movimiento = "Falta justificada"
                    Else
                        tipo_movimiento = "No encontrada"
                    End If

                    dtListaCompleta.Rows.Add(dr("usuario"), dr("reloj"), dr("nombre"), dr("depto"), tipo_movimiento, dr("dias"), f_ini, f_fin, dr("motivo"))
                Next
            End If

            If Not dtListaVac.Columns.Contains("Error") And dtListaVac.Rows.Count > 0 Then
                '=== Agregar lo que traiga dtListaVac a dtLista

                For Each dr As DataRow In dtListaVac.Rows
                    Dim tipo_movimiento As String = "Vacación", f_ini As String = "", f_fin As String = ""

                    Try : f_ini = FechaSQL(dr("f_ini").ToString.Trim) : Catch ex As Exception : f_ini = "" : End Try
                    Try : f_fin = FechaSQL(dr("f_fin").ToString.Trim) : Catch ex As Exception : f_fin = "" : End Try
                    dtListaCompleta.Rows.Add(dr("usuario"), dr("reloj"), dr("nombre"), dr("depto"), tipo_movimiento, dr("dias"), f_ini, f_fin, dr("motivo"))
                Next
            End If

            If Not dtListaCompleta.Columns.Contains("Error") And dtListaCompleta.Rows.Count > 0 Then
                dgvPendInci.DataSource = dtListaCompleta
            Else
                dgvPendInci.DataSource = dtListaCompleta
                MessageBox.Show("No se encontraron empleados con incidencias pendientes capturadas a mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


            '================Llenar datagridview con solo las incidencias YA aplicadas
            Query = "select usuario,reloj,nombre,depto,CAST(isnull(tipo_movimiento,0) AS VARCHAR) as 'tipo_movimiento',dias,f_ini,f_fin,motivo from solicitud_incidencias_personal where isnull(tipo_movimiento,0)<>0 and isnull(aplicado,0)=1" & _condRest
            dtListaNoVacTodas = sqlExecute(Query, "PERSONAL")

            Query = "select usuario,reloj,nombre,depto,CAST(isnull(tipo_movimiento,0) AS VARCHAR) as 'tipo_movimiento',dias_vac as 'dias',f_ini_vac as 'f_ini',f_fin_vac as 'f_fin',motivo from solicitud_incidencias_personal where isnull(tipo_movimiento,0)=0 and isnull(aplicado,0)=1" & _condRest
            dtListaVacTodas = sqlExecute(Query, "PERSONAL")

            dtListaCompletaTodas = dtListaCompleta.Clone

            If Not dtListaNoVacTodas.Columns.Contains("Error") And dtListaNoVacTodas.Rows.Count > 0 Then


                For Each dr As DataRow In dtListaNoVacTodas.Rows
                    Dim tipo_movimiento As String = "", f_ini As String = "", f_fin As String = ""
                    Try : tipo_movimiento = dr("tipo_movimiento").ToString.Trim : Catch ex As Exception : tipo_movimiento = "" : End Try
                    Try : f_ini = FechaSQL(dr("f_ini").ToString.Trim) : Catch ex As Exception : f_ini = "" : End Try
                    Try : f_fin = FechaSQL(dr("f_fin").ToString.Trim) : Catch ex As Exception : f_fin = "" : End Try

                    If tipo_movimiento = "0" Then
                        tipo_movimiento = "Vacación"
                    ElseIf tipo_movimiento = "1" Then
                        tipo_movimiento = "Permiso con goce de sueldo"
                    ElseIf tipo_movimiento = "2" Then
                        tipo_movimiento = "Permiso Sin goce de sueldo"
                    ElseIf tipo_movimiento = "3" Then
                        tipo_movimiento = "Tolerancia"
                    ElseIf tipo_movimiento = "4" Then
                        tipo_movimiento = "Falta injustificada"
                    ElseIf tipo_movimiento = "5" Then
                        tipo_movimiento = "Falta justificada"
                    Else
                        tipo_movimiento = "No encontrada"
                    End If

                    dtListaCompletaTodas.Rows.Add(dr("usuario"), dr("reloj"), dr("nombre"), dr("depto"), tipo_movimiento, dr("dias"), f_ini, f_fin, dr("motivo"))
                Next
            End If

            If Not dtListaVacTodas.Columns.Contains("Error") And dtListaVacTodas.Rows.Count > 0 Then
                '=== Agregar lo que traiga dtListaVac a dtLista

                For Each dr As DataRow In dtListaVacTodas.Rows
                    Dim tipo_movimiento As String = "Vacación", f_ini As String = "", f_fin As String = ""

                    Try : f_ini = FechaSQL(dr("f_ini").ToString.Trim) : Catch ex As Exception : f_ini = "" : End Try
                    Try : f_fin = FechaSQL(dr("f_fin").ToString.Trim) : Catch ex As Exception : f_fin = "" : End Try
                    dtListaCompletaTodas.Rows.Add(dr("usuario"), dr("reloj"), dr("nombre"), dr("depto"), tipo_movimiento, dr("dias"), f_ini, f_fin, dr("motivo"))
                Next
            End If

            If Not dtListaCompletaTodas.Columns.Contains("Error") And dtListaCompletaTodas.Rows.Count > 0 Then
                dgvIncTodas.DataSource = dtListaCompletaTodas
            Else
                dgvIncTodas.DataSource = dtListaCompletaTodas
                '  MessageBox.Show("No se encontraron empleados con incidencias capturados a mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgvPendInci_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPendInci.CellDoubleClick
        'Editar registro

        Dim Respuesta As Windows.Forms.DialogResult
        Respuesta = frmEditaSolInciPer.ShowDialog(Me)

        MostrarInformacion() ' Actualiza dgv

        If Respuesta = Windows.Forms.DialogResult.Abort Then
            MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf Respuesta = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

    End Sub

    Private Sub dgvIncTodas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIncTodas.CellDoubleClick
        '=====Imprimir formato de acuerdo a lo seleccionado

        '=====Preguntar si se desea mandar a imprimir formato, y actualizar impreso= 1
        If MessageBox.Show("¿Desea generar el formato de esta incidencia?", "P.I.D.A", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            '====Obtener valores
            Dim fecha_inicio As String = "", rj As String = "", tipo_mov As Integer = -1, cod_comp As String = "CTE", movimiento As String = ""

            Try : rj = Me.dgvIncTodas.Item("col_reloj_t", Me.dgvIncTodas.CurrentRow.Index).Value.ToString.Trim : Catch ex As Exception : rj = "" : End Try
            Try : movimiento = Me.dgvIncTodas.Item("col_tipo_mov_t", Me.dgvIncTodas.CurrentRow.Index).Value.ToString.Trim : Catch ex As Exception : movimiento = "" : End Try
            Try : fecha_inicio = FechaSQL(Me.dgvIncTodas.Item("col_fini_t", Me.dgvIncTodas.CurrentRow.Index).Value.ToString.Trim) : Catch ex As Exception : fecha_inicio = "" : End Try


            If movimiento.ToString.ToUpper.Trim.Contains("VACACI") Then
                tipo_mov = 0
            ElseIf movimiento.ToString.ToUpper.Trim.Contains("CON GOCE") Then
                tipo_mov = 1
            ElseIf movimiento.ToString.ToUpper.Trim.Contains("SIN GOCE") Then
                tipo_mov = 2
            ElseIf movimiento.ToString.ToUpper.Trim.Contains("TOLERAN") Then
                tipo_mov = 3
            ElseIf movimiento.ToString.ToUpper.Trim.Contains("FALTA INJUSTIFICADA") Then
                tipo_mov = 4
            ElseIf movimiento.ToString.ToUpper.Trim.Contains("FALTA JUSTIFICADA") Then
                tipo_mov = 5
            End If

            If rj = "00007" Then cod_comp = "CT2"

            '====Generar reporte
            Dim fecha_ini As Date = Date.Parse(fecha_inicio), _dtInfoReporte As New DataTable
            frmEditaSolInciPer.GenDataRepInciPers(rj, tipo_mov, fecha_ini, cod_comp, _dtInfoReporte)
            frmVistaPrevia.LlamarReporte("Reporte para incidencias del personal", _dtInfoReporte)
            frmVistaPrevia.ShowDialog()

            ' Query = "update solicitud_incidencias_personal set impreso=1 where reloj='" & Reloj & "' and tipo_movimiento=" & tipo_mov & rest_query
            'sqlExecute(Query, "PERSONAL")


            'Me.Close() 
            Exit Sub

        Else
            ' Me.Close()
            Exit Sub
        End If

    End Sub

    Private Sub tabTodasInci_Click(sender As Object, e As EventArgs) Handles tabTodasInci.Click
        ReflectionLabel1.Visible = False
        lblAplic.Visible = True

    End Sub

    Private Sub tabInciPend_Click(sender As Object, e As EventArgs) Handles tabInciPend.Click
        lblAplic.Visible = False
        ReflectionLabel1.Visible = True
    End Sub
End Class