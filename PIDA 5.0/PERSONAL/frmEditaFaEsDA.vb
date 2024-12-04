Public Class frmEditaFaEsDA

    Private Sub frmEditaFaEsDA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            '---- Obtener valores de las columnas

            Dim c_familia As String = frmMaestro.dgFamiliares.Item("CÓD.FAMILIA", frmMaestro.dgFamiliares.CurrentRow.Index).Value.ToString.Trim

            '-- Si no hay nada de info seleccionada que no cargue el form
            If c_familia = "" Then Me.DialogResult = Windows.Forms.DialogResult.Cancel

            cmbTipoPago.DropDownStyle = ComboBoxStyle.DropDown

            Dim idfld As String = frmMaestro.dgFamiliares.Item("idfld", frmMaestro.dgFamiliares.CurrentRow.Index).Value.ToString.Trim
            Dim col_nombreFam As String = frmMaestro.dgFamiliares.Item("NOMBRE (EJEM. AP PATERNO/AP MATERNO/NOMBRES)", frmMaestro.dgFamiliares.CurrentRow.Index).Value.ToString.Trim
            Dim encabezado_fecha As String = "FECHA NACIMIENTO (EJEM. " & New Date(Now.Year, 12, 31).ToShortDateString & ")"
            Dim col_fecha As String = frmMaestro.dgFamiliares.Item(encabezado_fecha, frmMaestro.dgFamiliares.CurrentRow.Index).Value.ToString.Trim

            Label4.Text = "Fecha de nacimiento (Ejem. " & New Date(Now.Year, 12, 31).ToShortDateString & ")"

            '---Agregar al comboBox los valores
            cmbTipoPago.Items.Clear()
            Dim dtInfoFamilia As DataTable = sqlExecute("select cod_familia + ' - ' + nombre as 'cod_familia' from familia", "PERSONAL")
            If Not dtInfoFamilia.Columns.Contains("Error") And dtInfoFamilia.Rows.Count > 0 Then
                For Each dr As DataRow In dtInfoFamilia.Rows
                    Dim cod_familia As String = ""
                    cod_familia = dr("cod_familia").ToString.Trim
                    cmbTipoPago.Items.Add(cod_familia)
                Next
            End If
            cmbTipoPago.Text = c_familia '---Poner valor en comboBox que trae ya : NOTA: El comboBox en su propiedad DropDownStyle debe de ser tipo dropDown
            cmbTipoPago.DropDownStyle = ComboBoxStyle.DropDownList

            txtNombreFamiliar.Text = col_nombreFam

            If col_fecha <> "" Then col_fecha = col_fecha.Substring(0, 10)

            txtFecha.Text = col_fecha

            txtIdfld.Text = idfld.ToString.Trim

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnElimina_Click(sender As Object, e As EventArgs) Handles btnElimina.Click
        '---Elimina registro
        Try
            If MessageBox.Show("¿Está seguro de elimnar el registro seleccionado?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                Dim idFld As String = "", QE As String = ""
                idFld = txtIdfld.Text.Trim

                QE = "delete from familiares where idFld=" & idFld
                sqlExecute(QE, "PERSONAL")

                MessageBox.Show("Registro eliminado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        '----Editar registro  dgFamiliares_CellValidating() para validar fecha

        Try
            Dim Q As String = ""
            Dim cod_familia As String = "", nombre = "", idFld As String = "", fecha As Date

            idFld = txtIdfld.Text.Trim
            cod_familia = cmbTipoPago.Text.Split("-")(0).Trim
            nombre = txtNombreFamiliar.Text.Trim

            If nombre = "" Then
                MessageBox.Show("El nombre no debe de quedar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If txtFecha.Text.Trim <> "" Then

                Try
                    fecha = Date.Parse(txtFecha.Text.Trim)
                Catch ex As Exception
                    MessageBox.Show("La fecha no es válida. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try

            Else
                MessageBox.Show("La fecha no debe de ir vacía", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Q = "UPDATE familiares set COD_FAMILIA='" & cod_familia & "',NOMBRE='" & nombre & "',FECHA_NAC='" & FechaSQL(fecha) & "' where  idFld=" & idFld
            sqlExecute(Q, "PERSONAL")
            MessageBox.Show("Se editó correctamente el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub
End Class