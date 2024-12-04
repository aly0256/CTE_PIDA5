Public Class frmTipoEmp
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtCias As New DataTable         'Tabla de compañías
    Dim dtSuper As New DataTable        'Tabla de supervisores

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region


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
            pnlRango.Enabled = Agregar Or Editar

            chkTodasLasCias.Visible = (Agregar Or Editar Or NoRec)
            'MCR 27/OCT/2015
            'Marcar por default "Todas las cias" cuando se agrega, pero no cuando se edita
            chkTodasLasCias.Checked = Agregar Or NoRec

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
            cmbCia.Enabled = Agregar

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
        Try
            Dim i As Integer
            Dim Automatico As Boolean

            txtCodigo.Text = dtRegistro.Rows(0).Item("cod_tipo")
            txtNombre.Text = dtRegistro.Rows(0).Item("nombre").ToString.Trim
            cmbCia.SelectedValue = dtRegistro.Rows(0).Item("cod_comp")
            btnCheca.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("checa_tarjeta")), False, dtRegistro.Rows(0).Item("checa_tarjeta"))
            btnConfidencial.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("confidencial")), False, dtRegistro.Rows(0).Item("confidencial"))

            'MCR 27/OCT/2015
            'Asignación de número de reloj por tipo de empleado
            Automatico = IsDBNull(dtRegistro.Rows(0).Item("minimo_rango")) Or IsDBNull(dtRegistro.Rows(0).Item("maximo_rango"))
            pnlRango.Visible = Not Automatico
            btnAsignacionAutomatica.Value = Not Automatico
            intRangoMinimo.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("minimo_rango")), -1, dtRegistro.Rows(0).Item("minimo_rango"))
            intRangoMaximo.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("maximo_rango")), -1, dtRegistro.Rows(0).Item("maximo_rango"))

            If Not DesdeGrid Then
                i = dtLista.DefaultView.Find(txtCodigo.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If
            DesdeGrid = False
            lblEstado.Text = "CONFIDENCIAL"
            lblEstado.Visible = btnConfidencial.Value = True
            HabilitarBotones()
            lblEstado.Enabled = True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCiasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmbCia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCia.SelectedIndexChanged
        Try
            dtSuper = sqlExecute("SELECT nombre FROM super WHERE cod_comp = '" & cmbCia.SelectedValue & "' ORDER BY nombre")
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            Dim Cod As String
            Cod = Buscar("tipo_emp", "cod_tipo", "tipo_emp", False)
            If Cod <> "CANCELAR" Then
                dtRegistro = sqlExecute("SELECT * from tipo_emp WHERE cod_tipo = '" & Cod & "' AND cod_comp = '" & Compania & "'")
                MostrarInformacion()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Try
            Primero("tipo_emp", "(cod_comp + cod_tipo)", dtRegistro)
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Try
            Anterior("tipo_emp", "(cod_comp + cod_tipo)", cmbCia.SelectedValue + txtCodigo.Text, dtRegistro)
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Try
            Siguiente("tipo_emp", "(cod_comp + cod_tipo)", cmbCia.SelectedValue + txtCodigo.Text, dtRegistro)
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Try
            Dim codigo As String, comp As String
            codigo = txtCodigo.Text
            comp = cmbCia.SelectedValue
            dtTemporal = sqlExecute("SELECT reloj from personalvw WHERE cod_tipo = '" & codigo & "' AND cod_comp = '" & comp & "'")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    sqlExecute("DELETE FROM tipo_emp WHERE cod_tipo = '" & codigo & "' AND cod_comp = '" & comp & "'")
                    btnSiguiente.PerformClick()
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        Try
            Dim cod As String, nom As String

            DesdeGrid = True

            cod = dgTabla.Item("Código", e.RowIndex).Value
            nom = dgTabla.Item("Compañía", e.RowIndex).Value
            dtRegistro = sqlExecute("SELECT * from tipo_emp WHERE cod_tipo = '" & cod & "' AND cod_comp = '" & nom & "'")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Try
            If Not Editar And Not Agregar Then
                Editar = True
                HabilitarBotones()
                txtNombre.Focus()
            Else
                Editar = False
            End If
            Agregar = False
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Try
            Ultimo("tipo_emp", "(cod_comp + cod_tipo)", dtRegistro)
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            Dim dtCias As DataTable
            If Agregar Then

                ' Si Agregar, revisar si existe cod_comp+cod_depto


                dtCias = sqlExecute("select * from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))

                For Each row As DataRow In dtCias.Rows
                    dtTemporal = sqlExecute("SELECT cod_tipo FROM tipo_emp where cod_comp = '" & row("cod_comp") & "' AND cod_tipo = '" & txtCodigo.Text & "'")
                    If dtTemporal.Rows.Count > 0 Then
                        MessageBox.Show("El registro no se puede agregar, ya existe el tipo '" & txtCodigo.Text & "' asignado a la compañía '" & row("cod_comp") & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtCodigo.Focus()
                        Exit Sub
                    End If
                Next

                For Each row As DataRow In dtCias.Rows
                    'MCR 27/OCT/2015
                    'Agregar rango mínimo y máximo a la tabla, para asignación automática de número de reloj
                    sqlExecute("INSERT INTO tipo_emp (cod_comp,cod_tipo,nombre,checa_tarjeta,confidencial,minimo_rango,maximo_rango) VALUES ('" & _
                               row("cod_comp") & "','" & _
                               txtCodigo.Text & "','" & _
                               txtNombre.Text & "'," & _
                               IIf(btnCheca.Value, 1, 0) & "," & _
                               IIf(btnConfidencial.Value, 1, 0) & "," & _
                               IIf(intRangoMinimo.Value = -1, vbNull, intRangoMinimo.Value) & "," & _
                               IIf(intRangoMaximo.Value = -1, vbNull, intRangoMaximo.Value) & ")")
                    Agregar = False
                Next


            ElseIf Editar Then
                ' Si Editar, entonces guardar cambios a registro

                dtCias = sqlExecute("select COD_COMP from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))

                For Each row As DataRow In dtCias.Rows
                    Dim dttabla As DataTable = sqlExecute("select *  from deptos where cod_comp = '" & row("cod_comp") & "' and cod_depto = '" & txtCodigo.Text & "'")
                    ' Si Editar, entonces guardar cambios a registro
                    'MCR 27/OCT/2015
                    'Agregar rango mínimo y máximo a la tabla, para asignación automática de número de reloj
                    sqlExecute("UPDATE tipo_emp SET nombre = '" & txtNombre.Text & _
                               "', checa_tarjeta = " & IIf(btnCheca.Value, 1, 0) & _
                               ", confidencial = " & IIf(btnConfidencial.Value, 1, 0) & _
                               ", minimo_rango = " & IIf(intRangoMinimo.Value = -1, "NULL", intRangoMinimo.Value) & _
                               ", maximo_rango = " & IIf(intRangoMaximo.Value = -1, "NULL", intRangoMaximo.Value) & _
                               " WHERE cod_tipo = '" & txtCodigo.Text & "' AND cod_comp = '" & row("cod_comp") & "'")
                Next
            Else
                Agregar = True
            End If
            Editar = False

            HabilitarBotones()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub frmTipoEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_comp as 'Compañía', cod_tipo as 'Código',Nombre FROM tipo_emp")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


            dtCias = sqlExecute("SELECT * FROM cias")
            cmbCia.DataSource = dtCias

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM tipo_emp ORDER BY cod_comp ASC, cod_tipo ASC")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Dim dtDatos As New DataTable
            dtDatos = sqlExecute("SELECT * FROM tipo_Emp WHERE cod_comp = '" & cmbCia.Text & "'")
            frmVistaPrevia.LlamarReporte("Tipo de empleados", dtDatos, cmbCia.Text)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAsignacionAutomatica_ValueChanged(sender As Object, e As EventArgs) Handles btnAsignacionAutomatica.ValueChanged
        Try
            pnlRango.Visible = btnAsignacionAutomatica.Value
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class