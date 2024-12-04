Public Class frmEditaEscolaridad

    Dim cod_escuela_ant As String = ""

    ''' <summary>
    ''' 'Método que para cargar formulario
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub frmEditaEscolaridad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim col_nivelesc As String = "", col_descripcion As String = "", col_anos As String = "", col_finalizo As String = ""

            col_nivelesc = frmMaestro.dgEscolaridad.Item("NIVEL ESC.", frmMaestro.dgEscolaridad.CurrentRow.Index).Value.ToString.Trim

            '-- Si no hay nada de info seleccionada que no cargue el form
            If col_nivelesc = "" Then Me.DialogResult = Windows.Forms.DialogResult.Cancel

            col_descripcion = frmMaestro.dgEscolaridad.Item("NOMBRE/DESCRIPCIÓN", frmMaestro.dgEscolaridad.CurrentRow.Index).Value.ToString.Trim
            col_anos = frmMaestro.dgEscolaridad.Item("AÑOS", frmMaestro.dgEscolaridad.CurrentRow.Index).Value.ToString.Trim
            col_finalizo = frmMaestro.dgEscolaridad.Item("FINALIZÓ", frmMaestro.dgEscolaridad.CurrentRow.Index).Value.ToString.Trim

            '---Agregar al comboBox los valores
            cmbEscolaridad.DropDownStyle = ComboBoxStyle.DropDown 'Para que pueda escribir sobre el
            cmbEscolaridad.Items.Clear()
            Dim dtInfoEscolaridad As DataTable = sqlExecute("select cod_escuela + ' - ' + nombre as 'cod_escuela' from escuelas", "PERSONAL")
            If Not dtInfoEscolaridad.Columns.Contains("Error") And dtInfoEscolaridad.Rows.Count > 0 Then
                For Each dr As DataRow In dtInfoEscolaridad.Rows
                    Dim cod_escuela As String = ""
                    cod_escuela = dr("cod_escuela").ToString.Trim
                    cmbEscolaridad.Items.Add(cod_escuela)
                Next
            End If
            cmbEscolaridad.Text = col_nivelesc '---Poner valor en comboBox que trae ya : NOTA: El comboBox en su propiedad DropDownStyle debe de ser tipo dropDown
            cmbEscolaridad.DropDownStyle = ComboBoxStyle.DropDownList ' Para que ya no pueda editarse el comboBox

            txtNombreEscolaridad.Text = col_descripcion
            txtAnos.Text = col_anos
            If col_finalizo = 1 Then sbFinalizo.Value = True Else sbFinalizo.Value = False

            cod_escuela_ant = col_nivelesc.Split("-")(0).Trim ' Para obtener el codigo de escuela con el que estaba original para poder hacer el UPDATE

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    ''' <summary>
    ''' 'Método que guarda/actualiza el registro seleccionado
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim Q As String = "", cod_escuela As String = "", anos As String = "", finalizo As String = "", descripcion As String = ""


            cod_escuela = cmbEscolaridad.Text.Split("-")(0).Trim
            descripcion = txtNombreEscolaridad.Text.Trim
            anos = txtAnos.Text.Trim
            If sbFinalizo.Value = True Then finalizo = "1" Else finalizo = "0"

            If descripcion = "" Then
                MessageBox.Show("La descripción de la escuela no debe de quedar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If anos = "" Then
                MessageBox.Show("Los años no debe de ir vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                ' Validar que sea numérico del 1 al 10
                If Not EsValNum(anos) Then
                    MessageBox.Show("El valor de años debe de ser tipo numérico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If

            Q = "update escolaridad set COD_ESCUELA='" & cod_escuela & "',ANOS=" & anos & ",FINALIZO=" & finalizo & " where reloj='" & Reloj2 & "' and COD_ESCUELA='" & cod_escuela_ant & "'"
            sqlExecute(Q, "PERSONAL")
            MessageBox.Show("Se editó correctamente el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 'Método para eliminar un registro
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnElimina_Click(sender As Object, e As EventArgs) Handles btnElimina.Click
        Try
            If MessageBox.Show("¿Está seguro de elimnar el registro seleccionado?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Dim Q As String = ""

                Q = "delete from escolaridad where reloj='" & Reloj2 & "' and COD_ESCUELA='" & cod_escuela_ant & "'"
                sqlExecute(Q, "PERSONAL")

                MessageBox.Show("Registro eliminado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 'Función para validar si es número
    ''' </summary>
    ''' <remarks></remarks>
    Private Function EsValNum(ByVal _numero As String) As Boolean
        Dim esNum As Boolean = False
        Try
            If (_numero.Trim <> "") Then
                Dim Num As Double = Double.Parse(_numero.Trim)
                If ((Num >= 0.0) Or (Num < 0.0)) Then
                    esNum = True
                Else
                    esNum = False
                End If
            Else
                esNum = False
                Return esNum
            End If
            Return esNum
        Catch ex As Exception
            Return esNum
        End Try
    End Function
End Class