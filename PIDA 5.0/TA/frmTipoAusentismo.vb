Public Class frmTipoAusentismo
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtNaturaleza As New DataTable         'Tabla de compañías

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region

    Private Sub HabilitarBotones()
        Dim NoRec As Boolean
        Try
            NoRec = dgTabla.Rows.Count = 0
            btnPrimero.Enabled = Not (Agregar Or Editar Or NoRec)
            btnAnterior.Enabled = Not (Agregar Or Editar Or NoRec)
            btnSiguiente.Enabled = Not (Agregar Or Editar Or NoRec)
            btnUltimo.Enabled = Not (Agregar Or Editar Or NoRec)

            btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)
            btnBuscar.Enabled = Not (Agregar Or Editar Or NoRec)
            btnBorrar.Enabled = Not (Agregar Or Editar Or NoRec)
            btnCerrar.Enabled = Not (Agregar Or Editar)


            txtCodigo.ReadOnly = Not (Agregar Or Editar)
            cmbNaturaleza.Enabled = Agregar Or Editar
            txtNombre.Enabled = Agregar Or Editar
            cpLetra.Enabled = Agregar Or Editar
            cpFondo.Enabled = Agregar Or Editar

            intGoce.Enabled = Agregar Or Editar
            tbGoce.Enabled = Agregar Or Editar
            txtSample.ReadOnly = Not (Agregar Or Editar)

            btnEditar.Enabled = Not (Not (Editar Or Agregar) And NoRec)

            btnSUA.IsReadOnly = Not (Agregar Or Editar)

            'MCR 11/NOV/2015
            'Afecta bonos básicos
            btnAsistencia.IsReadOnly = Not (Agregar Or Editar)
            btnPuntualidad.IsReadOnly = Not (Agregar Or Editar)
            btnAsistenciaPerfecta.IsReadOnly = Not (Agregar Or Editar)

            For Each ctl In gpAfecta.Controls
                If TypeOf ctl Is DevComponents.DotNetBar.Controls.SwitchButton Then
                    ctl.isreadonly = Not (Agregar Or Editar)
                End If
            Next

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
            cmbNaturaleza.Enabled = Agregar Or Editar

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
            If dtRegistro.Rows.Count = 0 Then
                Exit Sub
            End If
            txtCodigo.Text = dtRegistro.Rows(0).Item("tipo_aus").ToString.Trim
            txtNombre.Text = dtRegistro.Rows(0).Item("nombre").tostring.trim
            cmbNaturaleza.SelectedValue = dtRegistro.Rows(0).Item("tipo_naturaleza").ToString.Trim
            tbGoce.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("porcentaje")), 0, dtRegistro.Rows(0).Item("porcentaje"))
            intGoce.Text = tbGoce.Value

            Try
                cpLetra.SelectedColor = Color.FromArgb(IIf(IsDBNull(dtRegistro.Rows(0).Item("color_letra")), Color.Black.ToArgb, dtRegistro.Rows(0).Item("color_letra")))
                cpFondo.SelectedColor = Color.FromArgb(IIf(IsDBNull(dtRegistro.Rows(0).Item("color_back")), Color.White.ToArgb, dtRegistro.Rows(0).Item("color_back")))
            Catch ex As Exception
                cpLetra.SelectedColor = Color.Black
                cpFondo.SelectedColor = Color.White
            End Try
            btnSUA.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("afecta_SUA")), 0, dtRegistro.Rows(0).Item("afecta_SUA"))
            btnHrsConv.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("acumula_horas_convenio")), 0, dtRegistro.Rows(0).Item("acumula_horas_convenio"))
            'MCR 11/NOV/2015
            'Bonos básicos desde tipo_ausentismo, no relacion_bonos
            btnAsistencia.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("afecta_bono_asistencia")), 0, dtRegistro.Rows(0).Item("afecta_bono_asistencia"))
            btnPuntualidad.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("afecta_bono_puntualidad")), 0, dtRegistro.Rows(0).Item("afecta_bono_puntualidad"))
            btnAsistenciaPerfecta.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("afecta_asistencia_perfecta")), 0, dtRegistro.Rows(0).Item("afecta_asistencia_perfecta"))

            '***** Bonos *****
            Dim NM As String
            Dim dtBonos As New DataTable

            For Each ctl As Object In gpAfecta.Controls
                If TypeOf ctl Is DevComponents.DotNetBar.Controls.SwitchButton Then
                    NM = ctl.tag.ToString.Trim
                    dtBonos = sqlExecute("SELECT nombre FROM relacion_bonos WHERE cod_bono = '" & NM & "'", "ta")
                    If dtBonos.Rows.Count > 0 Then
                        ctl.visible = Not IsDBNull(dtBonos.Rows(0).Item("nombre"))
                        If ctl.visible Then
                            ctl.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("afecta_" & NM)), 0, dtRegistro.Rows(0).Item("afecta_" & NM))
                        Else
                            ctl.value = 0
                        End If
                    Else
                        ctl.visible = False
                    End If
                End If
            Next
            '*****************

            If Not DesdeGrid Then
                i = dtLista.DefaultView.Find(txtCodigo.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If
            DesdeGrid = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            HabilitarBotones()
        End Try
    End Sub

    Private Sub btnnaturaleza_ausCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("ta.dbo.tipo_ausentismo", "tipo_aus", "Tipo de ausentismo", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from tipo_ausentismo WHERE tipo_aus = '" & Cod & "'", "TA")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("tipo_ausentismo", "tipo_aus", dtRegistro, "TA")
        MostrarInformacion()
    End Sub

    Private Sub btnnaturaleza_ausPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("tipo_ausentismo", "tipo_aus", txtCodigo.Text, dtRegistro, "TA")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("tipo_ausentismo", "tipo_aus", txtCodigo.Text, dtRegistro, "TA")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String, comp As String
        codigo = txtCodigo.Text
        comp = cmbnaturaleza.text
        dtTemporal = sqlExecute("SELECT reloj FROM ausentismo WHERE tipo_aus = '" & codigo & "'", "TA")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un ausentismo que ya se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM tipo_ausentismo WHERE tipo_aus = '" & codigo & "'", "TA")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, nom As String

        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value
        nom = dgTabla.Item("Nombre", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * from tipo_ausentismo WHERE tipo_aus = '" & cod & "' AND nombre = '" & nom & "'", "TA")
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
        Ultimo("tipo_ausentismo", "tipo_aus", dtRegistro, "TA")
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe tipo_naturaleza+tipo_aus
            dtTemporal = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo where tipo_aus = '" & txtCodigo.Text & "'", "TA")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe el ausentismo '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            Else
                dtTemporal = sqlExecute("INSERT INTO tipo_ausentismo (tipo_aus) VALUES ('" & txtCodigo.Text & "')", "TA")
                Agregar = False
                Editar = True
            End If
        End If

        If Editar Then
            ' Si Editar, entonces guardar cambios a registro
            sqlExecute("UPDATE tipo_ausentismo SET nombre = '" & txtNombre.Text & "', tipo_naturaleza = '" & _
                       cmbNaturaleza.SelectedValue & "', porcentaje = " & tbGoce.Value & ",color_letra = " & _
                       cpLetra.SelectedColor.ToArgb & ",color_back = " & cpFondo.SelectedColor.ToArgb & _
                       ", afecta_SUA = " & IIf(btnSUA.Value, 1, 0) & _
                       ", afecta_bono_asistencia = " & IIf(btnAsistencia.Value, 1, 0) & _
                       ", afecta_bono_puntualidad = " & IIf(btnPuntualidad.Value, 1, 0) & _
                       ", afecta_asistencia_perfecta = " & IIf(btnAsistenciaPerfecta.Value, 1, 0) & _
                       ", acumula_horas_convenio = " & IIf(btnHrsConv.Value, 1, 0) & _
                       " WHERE tipo_aus = '" & txtCodigo.Text & "'", "TA")


            '***** Bonos *****
            Dim NM As String
            For Each ctl As Object In gpAfecta.Controls
                If TypeOf ctl Is DevComponents.DotNetBar.Controls.SwitchButton And ctl.visible Then
                    NM = ctl.tag.ToString.Trim
                    sqlExecute("UPDATE tipo_ausentismo SET " & NM & " = " & IIf(ctl.Value, 1, 0) & " WHERE tipo_aus = '" & txtCodigo.Text & "'", "TA")
                End If
            Next
            '*****************
        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()
    End Sub

    Private Sub frmtipo_ausentismos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nm As String
        Dim dtBonos As New DataTable
        Try
            dtLista = sqlExecute("SELECT tipo_naturaleza as 'Naturaleza',tipo_aus as 'Código',Nombre FROM tipo_ausentismo", "TA")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtNaturaleza = sqlExecute("SELECT * FROM naturaleza_aus", "TA")
            cmbNaturaleza.DataSource = dtNaturaleza

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM tipo_ausentismo ORDER BY tipo_naturaleza ASC, tipo_aus ASC", "TA")

            '***** Bonos *****
            For Each ctl As Object In gpAfecta.Controls
                If TypeOf ctl Is Label Then
                    nm = ctl.tag
                    dtBonos = sqlExecute("SELECT nombre FROM relacion_bonos WHERE cod_bono = '" & nm & "'", "ta")
                    If dtBonos.Rows.Count > 0 Then
                        If IsDBNull(dtBonos.Rows(0).Item("nombre")) Then
                            ctl.visible = False
                        Else
                            ctl.visible = True
                            ctl.text = dtBonos.Rows(0).Item("nombre").ToString.Trim
                        End If
                    Else
                        ctl.visible = False
                    End If
                End If
            Next
            '*****************

            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cpLetra_SelectedColorChanged(sender As Object, e As EventArgs) Handles cpLetra.SelectedColorChanged
        txtSample.ForeColor = cpLetra.SelectedColor
    End Sub

    Function PadLeft(strChar As String, TotalWidth As Integer, PaddingChar As String) As String
        Dim c As String = ""
        Dim x As Integer

        For x = strChar.Trim.Length To TotalWidth
            c = c & PaddingChar
        Next
        c = c & strChar
        Return c
    End Function

    Private Sub cpFondo_SelectedColorChanged(sender As Object, e As EventArgs) Handles cpFondo.SelectedColorChanged
        txtSample.BackColor = cpFondo.SelectedColor
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        txtSample.Text = txtCodigo.Text
    End Sub

    Private Sub tbGoce_Scroll(sender As Object, e As EventArgs) Handles tbGoce.Scroll
        intGoce.Value = tbGoce.Value
    End Sub

    Private Sub intGoce_GotFocus(sender As Object, e As EventArgs) Handles intGoce.GotFocus

    End Sub

    Private Sub intGoce_ValueChanged(sender As Object, e As EventArgs) Handles intGoce.ValueChanged
        tbGoce.Value = intGoce.Value
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtReporte As New DataTable
        dtReporte = sqlExecute("SELECT tipo_ausentismo.TIPO_AUS,tipo_ausentismo.NOMBRE," & _
                               "tipo_ausentismo.GOCE_SDO,tipo_ausentismo.COLOR_LETRA," & _
                               "tipo_ausentismo.COLOR_BACK, CASE WHEN tipo_ausentismo.PORCENTAJE IS NULL THEN 0 ELSE PORCENTAJE END AS PORCENTAJE," & _
                               "naturaleza_aus.NOMBRE AS NATURALEZA,AFECTA_BONO_ASISTENCIA, AFECTA_BONO_PUNTUALIDAD," & _
                               "AFECTA_SUA, AFECTA_ASISTENCIA_PERFECTA FROM TA.dbo.tipo_ausentismo" & _
                               " INNER JOIN ta.dbo.naturaleza_aus ON tipo_ausentismo.TIPO_NATURALEZA = naturaleza_aus.TIPO_NATURALEZA", "TA")
        frmVistaPrevia.LlamarReporte("TipoAusentismo", dtReporte)
        frmVistaPrevia.ShowDialog()
    End Sub
End Class