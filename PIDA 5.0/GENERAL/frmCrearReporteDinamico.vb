Imports System.Drawing.Drawing2D
Imports System
Imports System.Drawing.Text
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Math

Public Class frmCrearReporteDinamico
    Dim drop_index As Integer

    Private dtSeleccionados As New DataTable
    Dim dtSel As New DataTable

    Public reporte_edicion As String = ""

    Dim edicion_grupo1 As String = ""
    Dim edicion_grupo2 As String = ""
    Dim edicion_grupo3 As String = ""

    Dim edicion_campos() As String

    Dim edicion_mostrar_detalle As Boolean
    Dim edicion_mostrar_resumen As Boolean

    Private m_DragSource As ListBox = Nothing

    Private Sub frmCrearReporteDinamico_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            dtReporteDinamico = New DataTable
            dtDisponibles.Columns.Add("seleccionado", GetType(System.Boolean))
            dtDisponibles.Columns.Add("orden", GetType(System.Int16))

            dtDisponibles.PrimaryKey = New DataColumn() {dtDisponibles.Columns("campo")}

            dtSeleccionados = dtDisponibles.Copy
            lblFuente.Text = ReporteadorFuente.ToUpper

            If reporte_edicion <> "" Then

                Dim dtCamposActuales As DataTable = sqlExecute("select * from reportes where nombre = '" & reporte_edicion & "' and tipo = 'u' and campos is not null", ReporteadorFuente)
                If dtCamposActuales.Rows.Count > 0 Then

                    txtReporte.Text = reporte_edicion
                    txtReporte.Enabled = False

                    chkGuardar.Checked = True
                    chkGuardar.Enabled = False

                    edicion_grupo1 = dtCamposActuales.Rows(0)("grupo1")
                    edicion_grupo2 = dtCamposActuales.Rows(0)("grupo2")
                    edicion_grupo3 = dtCamposActuales.Rows(0)("grupo3")

                    edicion_mostrar_detalle = dtCamposActuales.Rows(0)("mostrar_detalle")
                    edicion_mostrar_resumen = dtCamposActuales.Rows(0)("mostrar_resumen")

                    edicion_campos = RTrim(dtCamposActuales.Rows(0)("campos")).Split(",")
                    Dim primero As String = ""
                    For Each s As String In edicion_campos
                        If primero = "" Then
                            primero = s
                        End If

                        For Each row As DataRow In dtSeleccionados.Rows
                            If RTrim(row("campo")) = RTrim(s) Then
                                row("seleccionado") = True
                            End If
                        Next
                    Next

                    wizAsistente.NavigateNext()

                    lstDisponibles.DataSource = dtSeleccionados
                    lstDisponibles.DisplayMember = "nombre"
                    lstDisponibles.ValueMember = "campo"
                    lstDisponibles.SelectedValue = primero

                    lstSeleccionados.AllowDrop = True

                    chkSeleccionados.Checked = True
                End If
            Else
                lstDisponibles.DataSource = dtSeleccionados
                lstDisponibles.DisplayMember = "nombre"
                lstDisponibles.ValueMember = "campo"                

                lstSeleccionados.AllowDrop = True
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Hubo un error al cargar la información. Si el problema persiste, contacte al administrador " & _
                            "del sistema." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Wizard1_CancelButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles wizAsistente.CancelButtonClick
        Me.Close()

    End Sub

    Private Sub wizCampos_Enter(sender As Object, e As EventArgs) Handles wizCampos.Enter
        txtBusca.Focus()
    End Sub
    Private Sub wizCampos_NextButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles wizCampos.NextButtonClick
        Try
            If dtSeleccionados.Select("seleccionado").Count = 0 Then
                MessageBox.Show("Para crear un reporte, debe elegir al menos un campo.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            Else
                lstSeleccionados.Items.Clear()

                If reporte_edicion <> "" Then
                    Dim orden As Integer = 1

                    For Each row As DataRow In dtSeleccionados.Rows
                        row("orden") = 99
                    Next

                    For Each s As String In edicion_campos
                        For Each row As DataRow In dtSeleccionados.Rows
                            If RTrim(row("campo")) = RTrim(s) Then
                                row("orden") = orden
                                orden += 1                            
                            End If
                        Next
                    Next
                End If
                

                For Each dSel As DataRow In dtSeleccionados.Select("seleccionado", "orden")
                    lstSeleccionados.Items.Add(dSel("nombre"))
                Next

                CargarGrupos(cmbGrupo1)
                CargarGrupos(cmbGrupo2)
                CargarGrupos(cmbGrupo3)

                If reporte_edicion <> "" Then
                    Try : cmbGrupo1.SelectedValue = edicion_grupo1 : Catch : cmbGrupo1.SelectedValue = "<Ninguno>" : End Try
                    Try : cmbGrupo2.SelectedValue = edicion_grupo2 : Catch : cmbGrupo2.SelectedValue = "<Ninguno>" : End Try
                    Try : cmbGrupo3.SelectedValue = edicion_grupo3 : Catch : cmbGrupo3.SelectedValue = "<Ninguno>" : End Try

                    Try : chkTotales.Checked = edicion_mostrar_resumen : Catch : chkTotales.Checked = False : End Try
                    Try : chkDetalle.Checked = edicion_mostrar_detalle : Catch : chkDetalle.Checked = False : End Try
                End If

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Hubo un error al cargar la información. Si el problema persiste, contacte al administrador " & _
                            "del sistema." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargarGrupos(Combo As ComboBox)
        Try
            Dim dN As DataRow
            Dim dtCombo As New DataTable
            dtCombo = dtSeleccionados.Clone

            dN = dtCombo.NewRow
            dN("nombre") = "<Ninguno>"
            dN("campo") = "<Ninguno>"
            dtCombo.Rows.Add(dN)
            For Each i As DataRow In dtSeleccionados.Select("seleccionado")
                dtCombo.ImportRow(i)

                'Combo.Items.Add(i("nombre").ToString.Trim)
            Next
            Combo.DataSource = dtCombo
            Combo.DisplayMember = "nombre"
            Combo.ValueMember = "campo"
            Combo.SelectedIndex = 0
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Hubo un error al cargar la información. Si el problema persiste, contacte al administrador " & _
                            "del sistema." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbGrupo1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupo1.SelectedIndexChanged
        Try

            cmbGrupo2.Enabled = cmbGrupo1.SelectedValue.Trim <> "<Ninguno>"

        Catch ex As Exception
            cmbGrupo2.Enabled = False
        End Try
    End Sub

    Private Sub cmbGrupo2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupo2.SelectedIndexChanged
        Try
            cmbGrupo3.Enabled = cmbGrupo2.SelectedValue.Trim <> "<Ninguno>"

        Catch ex As Exception
            cmbGrupo3.Enabled = False
        End Try
    End Sub

    Private Sub txtReporte_TextChanged(sender As Object, e As EventArgs) Handles txtReporte.TextChanged

    End Sub

    Private Sub txtReporte_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtReporte.Validating
        Try
            If txtReporte.Text.Trim.Length > 0 And chkGuardar.Checked Then
                dtTemporal = sqlExecute("SELECT nombre FROM reportes WHERE nombre = '" & txtReporte.Text.Trim & "'")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("Ya existe un reporte con este nombre, por favor, asigne un nombre diferente.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Hubo un error al cargar la información. Si el problema persiste, contacte al administrador " & _
                            "del sistema." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub wizAsistente_FinishButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles wizAsistente.FinishButtonClick
        Dim Campos As String = ""
        Dim dtDatos As New DataTable
        Dim dtPerfil As New DataTable
        Dim dIt As DataRow
        Dim Tipo As String

        Try
            If txtReporte.Text.Trim.Length = 0 Then
                MessageBox.Show("Es necesario asignar un nombre al reporte.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            For Each dIt In dtSeleccionados.Select("seleccionado")
                dIt("orden") = -1
            Next

            For x = 0 To lstSeleccionados.Items.Count - 1
                For Each dIt In dtSeleccionados.Select("seleccionado AND (orden IS NULL OR orden = -1)")
                    If dIt("nombre").ToString.Trim = lstSeleccionados.Items(x).ToString.Trim Then
                        dIt("orden") = x
                        Exit For
                    End If
                Next

            Next

            Campos = ""
            For Each it As DataRow In dtSeleccionados.Select("seleccionado", "orden")
                Campos = Campos & IIf(Campos.Length > 0, ",", "") & it.Item("campo").ToString.Trim
            Next

            'MCR 3/NOV/2015
            'Utilizar TimeAllocation como TA dentro de los permisos
            'Pero no ajustarlo aún, para poder 
            Tipo = IIf(ReporteadorFuente = "TIME ALLOCATION", "S", "U")
            ReporteadorFuente = IIf(ReporteadorFuente = "TIME ALLOCATION", "TA", ReporteadorFuente)
            ReporteadorFuente = ReporteadorFuente.Replace("&", "")

            If chkGuardar.Checked Then
                dtPerfil = sqlExecute("SELECT cod_perfil FROM appuser WHERE username = '" & Usuario & "'", "seguridad")

                If reporte_edicion = "" Then
                    sqlExecute("INSERT INTO Reportes (nombre,tipo,campos,grupo1,grupo2,grupo3,mostrar_detalle,mostrar_resumen,username) VALUES('" & _
                           txtReporte.Text.Trim & _
                           "','" & Tipo & "','" & _
                           Campos & "','" & _
                           cmbGrupo1.SelectedValue & "','" & _
                           cmbGrupo2.SelectedValue & "','" & _
                           cmbGrupo3.SelectedValue & "'," & _
                           IIf(chkDetalle.Checked, 1, 0) & "," & _
                           IIf(chkTotales.Checked, 1, 0) & ",'" & _
                           Usuario & "')", ReporteadorFuente)
                Else
                    sqlExecute("update reportes set campos = '" & Campos & "' where nombre = '" & txtReporte.Text.Trim & "'", ReporteadorFuente)

                    sqlExecute("update reportes set grupo1 = '" & cmbGrupo1.SelectedValue & "' where nombre = '" & txtReporte.Text.Trim & "'", ReporteadorFuente)
                    sqlExecute("update reportes set grupo2 = '" & cmbGrupo2.SelectedValue & "' where nombre = '" & txtReporte.Text.Trim & "'", ReporteadorFuente)
                    sqlExecute("update reportes set grupo3 = '" & cmbGrupo3.SelectedValue & "' where nombre = '" & txtReporte.Text.Trim & "'", ReporteadorFuente)

                    sqlExecute("update reportes set mostrar_detalle = '" & IIf(chkDetalle.Checked, 1, 0) & "' where nombre = '" & txtReporte.Text.Trim & "'", ReporteadorFuente)
                    sqlExecute("update reportes set mostrar_resumen = '" & IIf(chkTotales.Checked, 1, 0) & "' where nombre = '" & txtReporte.Text.Trim & "'", ReporteadorFuente)
                End If
                

                sqlExecute("INSERT INTO permisos (cod_perfil,control,tipo,acceso,modulo) VALUES ('" & _
                           dtPerfil.Rows(0).Item("cod_perfil").ToString.Trim & _
                           "','" & txtReporte.Text.Trim & "','R',1,'" & _
                           ReporteadorFuente.Substring(0, IIf(ReporteadorFuente.Length >= 3, 3, ReporteadorFuente.Length)) & "')", "Seguridad")
                dtDatos = sqlExecute("SELECT * FROM reportes WHERE nombre = '" & _
                                     txtReporte.Text.Trim & "'", ReporteadorFuente)

            Else
                Dim x As Integer
                Dim Columnas(8) As DataColumn

                'Crear estructura de datos
                dtDatos = New DataTable("Datos")
                Columnas(0) = New DataColumn("nombre", System.Type.GetType("System.String"))
                Columnas(1) = New DataColumn("tipo", System.Type.GetType("System.String"))
                Columnas(2) = New DataColumn("campos", System.Type.GetType("System.String"))
                Columnas(3) = New DataColumn("grupo1", System.Type.GetType("System.String"))
                Columnas(4) = New DataColumn("grupo2", System.Type.GetType("System.String"))
                Columnas(5) = New DataColumn("grupo3", System.Type.GetType("System.String"))
                Columnas(6) = New DataColumn("mostrar_detalle", System.Type.GetType("System.String"))
                Columnas(7) = New DataColumn("mostrar_resumen", System.Type.GetType("System.String"))
                Columnas(8) = New DataColumn("usuario", System.Type.GetType("System.String"))

                For x = 0 To UBound(Columnas)
                    dtDatos.Columns.Add(Columnas(x))
                Next
                dtDatos.Rows.Add({"*" & txtReporte.Text.Trim, _
                                  Tipo, _
                                  Campos, _
                                  cmbGrupo1.SelectedValue, _
                                  cmbGrupo2.SelectedValue, _
                                  cmbGrupo3.SelectedValue, _
                                  IIf(chkDetalle.Checked, 1, 0), _
                                  IIf(chkTotales.Checked, 1, 0), _
                                  Usuario})
            End If

            dtReporteDinamico = dtDatos
            Me.Close()
            Me.Dispose()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Hubo un error al cargar la información. Si el problema persiste, contacte al administrador " & _
                            "del sistema." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub wizTerminar_AfterPageDisplayed(sender As Object, e As DevComponents.DotNetBar.WizardPageChangeEventArgs) Handles wizTerminar.AfterPageDisplayed
        txtReporte.Focus()
    End Sub


    Private Sub wizCampos_Click(sender As Object, e As EventArgs) Handles wizCampos.Click

    End Sub

    Private Sub CambiarSeleccion(sender As Object, e As EventArgs) Handles chkSeleccionados.CheckedChanged
        Dim dIt As DataRow
        Dim x As Integer
        Dim dtSel As New DataTable
        Try

            If chkSeleccionados.Checked Then
                dtSel = dtSeleccionados.Clone
                For Each dR As DataRow In dtSeleccionados.Select("seleccionado", "nombre")
                    dtSel.ImportRow(dR)
                Next
                lstDisponibles.DataSource = dtSel
            Else
                lstDisponibles.DataSource = dtSeleccionados
            End If

            lstDisponibles.DisplayMember = "nombre"
            lstDisponibles.ValueMember = "campo"

            x = 0
            For x = 0 To lstDisponibles.Items.Count - 1
                dIt = dtSeleccionados.Rows.Find(lstDisponibles.Items(x)(0).ToString.Trim)
                If Not dIt Is Nothing Then
                    lstDisponibles.SetItemChecked(x, IIf(IsDBNull(dIt("seleccionado")), 0, dIt("seleccionado")))
                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Hubo un error al cargar la información. Si el problema persiste, contacte al administrador " & _
                            "del sistema." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MarcarTodos(sender As Object, e As EventArgs) Handles chkMarcar.CheckedChanged
        Try
            Dim x As Integer
            Dim dIt As DataRow

            x = 0
            For x = 0 To lstDisponibles.Items.Count - 1
                lstDisponibles.SetItemChecked(x, chkMarcar.Checked)
                dIt = dtSeleccionados.Rows.Find(lstDisponibles.Items(x)(0).ToString.Trim)
                If Not dIt Is Nothing Then
                    dIt("seleccionado") = chkMarcar.Checked
                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Hubo un error al cargar la información. Si el problema persiste, contacte al administrador " & _
                            "del sistema." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lstDisponibles_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lstDisponibles.ItemCheck
        Try
            Dim dIt As DataRow

            dIt = dtSeleccionados.Rows.Find(lstDisponibles.SelectedValue)
            If Not dIt Is Nothing Then
                dIt("seleccionado") = e.NewValue
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Hubo un error al cargar la información. Si el problema persiste, contacte al administrador " & _
                            "del sistema." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub lstSeleccionados_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstSeleccionados.DragDrop
        Try
            If lstSeleccionados.SelectedIndex >= 0 Then
                Dim i As Integer
                i = lstSeleccionados.IndexFromPoint(lstSeleccionados.PointToClient(New Point(e.X, e.Y)))
                If i >= 0 Then
                    lstSeleccionados.Items.Insert(lstSeleccionados.IndexFromPoint(lstSeleccionados.PointToClient(New Point(e.X, e.Y))), e.Data.GetData(DataFormats.Text))
                    lstSeleccionados.Items.RemoveAt(lstSeleccionados.SelectedIndex)
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub lstSeleccionados_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstSeleccionados.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub lstSeleccionados_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSeleccionados.MouseDown
        lstSeleccionados.DoDragDrop(lstSeleccionados.Text, DragDropEffects.All)
    End Sub

    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        Try
            Dim i As Integer
            i = lstDisponibles.FindString(txtBusca.Text.Trim)
            If i >= 0 Then
                lstDisponibles.TopIndex = i
                lstDisponibles.SetSelected(i, True)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub lstDisponibles_KeyDown(sender As Object, e As KeyEventArgs) Handles lstDisponibles.KeyDown
        Try
            txtBusca.Text = Chr(e.KeyValue)
            txtBusca.SelectionStart = 1
            txtBusca.Focus()
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub lstDisponibles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDisponibles.SelectedIndexChanged

    End Sub

    Private Sub wizGrupos_Click(sender As Object, e As EventArgs) Handles wizGrupos.Click

    End Sub
End Class
