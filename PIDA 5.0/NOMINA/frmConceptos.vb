Public Class frmConceptos
#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtNaturaleza As New DataTable         'Tabla de compañías
 
    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region


    Private Sub frmconceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dtConcepto As New DataTable
            dtLista = sqlExecute("SELECT concepto as 'Código',nombre as 'Descripción',cod_naturaleza as 'Naturaleza',Prioridad FROM conceptos", "nomina")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtNaturaleza = sqlExecute("SELECT * FROM naturalezas", "nomina")
            cmbNaturaleza.DataSource = dtNaturaleza

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM conceptos ORDER BY prioridad,concepto", "nomina")

            cmbTipos.Items.Add("NUMÉRICO")
            cmbTipos.Items.Add("FECHA")
            cmbTipos.Items.Add("PORCENTAJE")
            cmbTipos.Items.Add("CARACTER")

            dtConcepto = sqlExecute("SELECT concepto,nombre FROM conceptos WHERE activo = 1 ORDER BY concepto", "nomina")
            Dim dR As DataRow = dtConcepto.NewRow
            dR("concepto") = ""
            dR("nombre") = "NO APLICA"
            dtConcepto.Rows.InsertAt(dR, 0)
            cmbExento.DataSource = dtConcepto

            MostrarInformacion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub HabilitarBotones()
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
            btnNuevo.Image = My.Resources.Ok16
            btnEditar.Image = My.Resources.CancelX
            btnNuevo.Text = "Aceptar"
            btnEditar.Text = "Cancelar"
            tabBuscar.SelectedTabIndex = 0
        Else

            btnNuevo.Image = My.Resources.NewRecord
            btnEditar.Image = My.Resources.Edit

            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"
        End If

        txtCodigo.Enabled = Agregar
        IntPrioridad.Enabled = Agregar Or Editar
        btnAfecta.Enabled = Agregar Or Editar
        btnPositivo.Enabled = Agregar Or Editar
        'btnCalculoactivo.Enabled = Agregar Or Editar
        btnComparativo.Enabled = Agregar Or Editar

        If Agregar Then
            txtCodigo.Text = ""
            txtNombre.Text = ""
            txtNombreIngles.Text = ""
            IntPrioridad.Value = 900
            btnAfecta.Value = False
            btnPositivo.Value = True
            'btnCalculoactivo.Value = True
            btnComparativo.Value = True
            btnMaestro.Value = False
            txtClaveMisc.Text = ""
            txtMonto.Value = 0

            cmbTipos.Text = "NUMÉRICO"
            txtCodigoSat.Text = ""
            cmbExento.SelectedValue = ""
            txtEquivalenteSat.Text = ""

            txtCodigo.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If
    End Sub
    Private Sub MostrarInformacion()
        Dim i As Integer

        Try
            txtCodigo.Text = dtRegistro.Rows(0).Item("concepto")
            txtNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre").ToString.Trim), "", dtRegistro.Rows(0).Item("nombre").ToString.Trim)
            txtNombreIngles.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre_ingles").ToString.Trim), "", dtRegistro.Rows(0).Item("nombre_ingles").ToString.Trim)
            cmbNaturaleza.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_naturaleza")), "", dtRegistro.Rows(0).Item("cod_naturaleza"))
            IntPrioridad.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("prioridad")), 0, dtRegistro.Rows(0).Item("prioridad"))
            btnAfecta.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("suma_neto")), 0, dtRegistro.Rows(0).Item("suma_neto")) = 1
            btnPositivo.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("positivo")), 0, dtRegistro.Rows(0).Item("positivo")) = 1
            'btnCalculoactivo.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("activo")), 0, dtRegistro.Rows(0).Item("activo")) = 1
            btnComparativo.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("comparativo_nominas")), 0, dtRegistro.Rows(0).Item("comparativo_nominas")) = 1
            txtMonto.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("misce_monto")), 0, dtRegistro.Rows(0).Item("misce_monto"))
            txtClaveMisc.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("misce_clave")), "", dtRegistro.Rows(0).Item("misce_clave"))
            btnComparativo.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("aplica_mtro_ded")), 0, dtRegistro.Rows(0).Item("aplica_mtro_ded")) = 1
            cmbTipos.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("tipo_dato")), "NUMÉRICO", dtRegistro.Rows(0).Item("tipo_dato"))
            txtCodigoSat.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_sat")), "", dtRegistro.Rows(0).Item("cod_sat"))
            cmbExento.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("exento")), "", dtRegistro.Rows(0).Item("exento"))
            txtEquivalenteSat.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("concepto_sat")), dtRegistro.Rows(0).Item("concepto"), dtRegistro.Rows(0).Item("concepto_sat"))

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
        Cod = Buscar("nomina.dbo.conceptos", "concepto", "CONCEPTOS", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from conceptos WHERE concepto = '" & Cod & "'", "nomina")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("conceptos", "concepto", dtRegistro, "nomina")
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("conceptos", "concepto", txtCodigo.Text, dtRegistro, "nomina")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("conceptos", "concepto", txtCodigo.Text, dtRegistro, "nomina")
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String, comp As String
        codigo = txtCodigo.Text
        comp = cmbNaturaleza.SelectedValue
        dtTemporal = sqlExecute("SELECT concepto FROM movimientos WHERE concepto = '" & codigo & "'", "nomina")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM conceptos WHERE concepto = '" & codigo & "'", "nomina")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub dgTabla_RowDividerHeightChanged(sender As Object, e As DataGridViewRowEventArgs) Handles dgTabla.RowDividerHeightChanged

    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, nom As String

        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value.ToString.Trim
        nom = dgTabla.Item("descripcion", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * from conceptos WHERE concepto = '" & cod & "'", "nomina")
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
        Ultimo("conceptos", "concepto", dtRegistro, "nomina")
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Agregar Then
            ' Si Agregar, revisar si existe cod_naturaleza+concepto
            dtTemporal = sqlExecute("SELECT concepto FROM conceptos where concepto = '" & txtCodigo.Text & "'", "nomina")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe el concepto '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                Exit Sub
            End If
            sqlExecute("INSERT INTO conceptos (concepto) VALUES ('" & txtCodigo.Text & "')", "nomina")
        End If

        If Agregar Or Editar Then
            sqlExecute("UPDATE conceptos SET nombre = '" & txtNombre.Text & "', " & _
                "nombre_ingles = " & IIf(txtNombreIngles.Text.Trim.Length = 0, "NULL", "'" & txtNombreIngles.Text & "'") & ", " & _
                "cod_naturaleza = '" & cmbNaturaleza.SelectedValue & "', " & _
                "prioridad = " & IntPrioridad.Value & ", " & _
                "suma_neto = " & IIf(btnAfecta.Value, 1, 0) & ", " & _
                "positivo = " & IIf(btnPositivo.Value, 1, 0) & ", " & _
                "comparativo_nominas = " & IIf(btnComparativo.Value, 1, 0) & ", " & _
                "misce_monto = " & txtMonto.Value & ", " & _
                "misce_clave = '" & txtClaveMisc.Text & "', " & _
                "aplica_mtro_ded = " & IIf(btnMaestro.Value, 1, 0) & ", " & _
                "cod_sat = '" & txtCodigoSat.Text & "', " & _
                "tipo_dato = '" & cmbTipos.Text & "', " & _
                "exento = '" & cmbExento.SelectedValue & "', " & _
                "concepto_sat = '" & txtEquivalenteSat.Text & "', activo = 1 " & _
                " WHERE concepto = '" & txtCodigo.Text & "'", "nomina")

            '"activo = " & IIf(btnCalculoactivo.Value, 1, 0) & 

            Agregar = False
        Else
            Agregar = True
            txtCodigo.Text = ""
        End If
        Editar = False
        HabilitarBotones()
    End Sub

    Private Sub dgTabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellContentClick

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmVistaPrevia.LlamarReporte("Conceptos", Nothing)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub txtEquivalenteSat_GotFocus(sender As Object, e As EventArgs) Handles txtEquivalenteSat.GotFocus
        If (Editar Or Agregar) And txtEquivalenteSat.Text = "" Then
            txtEquivalenteSat.Text = txtCodigo.Text
        End If
    End Sub

    Private Sub txtEquivalenteSat_TextChanged(sender As Object, e As EventArgs) Handles txtEquivalenteSat.TextChanged

    End Sub
End Class