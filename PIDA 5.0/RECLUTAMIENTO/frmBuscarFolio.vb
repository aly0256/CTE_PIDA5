Public Class frmBuscarFolio
    Dim dtBuscar As New DataTable
    Dim idxBusca As Integer
    Dim DesdeGrid As Boolean
    Dim CamposBusca As String

    Dim BS As New BindingSource

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If txtFolio.Text <> "" Then
                Folio = txtFolio.Text
            End If
        Catch ex As Exception
            Folio = "CANCEL"
        Finally
            Me.Close()
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Folio = "CANCEL"
        Me.Close()
    End Sub


    Private Sub frmBuscarFolio_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmBuscarFolio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim Campos() As String
        Dim Extra As String = ""
        Dim dtParametros As New DataTable

        Try
            Folio = "CANCEL"
            dtBuscar = sqlExecute("SELECT c.*,v.NumRequisicion+' '+v.Vacante as reqvac FROM Candidatos c join vacantes v on c.cod_vac = v.cod_vac ORDER BY Folio", "RECLUTAMIENTO")
            BS.DataSource = dtBuscar
            navPersonal.BindingSource = BS
            dgTabla.DataSource = BS
            txtFolio.DataBindings.Add("Text", BS, "Folio")
            txtNombre.DataBindings.Add("Text", BS, "Nombre")
            txtAPaterno.DataBindings.Add("Text", BS, "Paterno")
            txtVacante.DataBindings.Add("Text", BS, "reqvac")
            txtAplicacion.DataBindings.Add("Text", BS, "FhaApli", True, DataSourceUpdateMode.Never, Nothing, "d")
            idxBusca = 0
            'MostrarInformacionBuscar()
        Catch ex As Exception
            If ex.HResult <> -2147024809 Then
                'Si el error no se debe a que ya se habían asignado los DataBindings de los textos
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                MessageBox.Show("Se detectó un error al iniciar pantalla de búsqueda. Si el problema persiste, contacte al administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            txtBusca.Text = ""
        End Try
    End Sub

    Private Sub txtBusca_GotFocus(sender As Object, e As EventArgs) Handles txtBusca.GotFocus
        txtBusca.SelectAll()
    End Sub


    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        Dim vl As String

        Try
            Dim dtSeleccion As New DataTable
            Dim vlAnt As String
            Dim vlDes As String
            Dim i As Integer
            dtSeleccion = dtBuscar.Clone
            vl = txtBusca.Text.Replace("*", "%")
            vl = vl.Replace("'", "")
            i = vl.IndexOf("%")

            If i >= 0 Then
                vlAnt = vl.Substring(0, i)
                vlDes = vl.Substring(i + 1)

                vl = "(folio LIKE '%" & vlAnt & "%' OR nombre LIKE '%" & vlAnt & "%' OR paterno LIKE '%" & vlAnt & "%') AND (" & _
                    "folio LIKE '%" & vlDes & "%' OR nombre LIKE '%" & vlDes & "%' OR paterno LIKE '%" & vlDes & "%')"
            Else
                vl = "folio LIKE '%" & vl & "%' OR nombre LIKE '%" & vl & "%' OR paterno LIKE '%" & vl & "%' "
            End If

            For Each dDato As DataRow In dtBuscar.Select(vl)
                dtSeleccion.ImportRow(dDato)
            Next

            BS.DataSource = dtSeleccion

        Catch ex As Exception
            'MCR 26/OCT/2015
            'Cambio para evitar que "truene" cuando el usuario presione secuencias incorrectas
            'p.ej. *,*,
            MessageBox.Show("Se detectó un error al buscar un solicitante que cumpla con la condición indicada. Favor de verificar." & vbCrLf & _
                             vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBusca.Text = ""
        End Try
    End Sub

    Private Sub dgTabla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellContentDoubleClick
        Folio = dgTabla.Item("colFolio", dgTabla.CurrentRow.Index).Value

        btnAceptar.PerformClick()
    End Sub

    Private Sub dgTabla_DoubleClick(sender As Object, e As EventArgs) Handles dgTabla.DoubleClick
        Folio = dgTabla.Item("colFolio", dgTabla.CurrentRow.Index).Value
        btnAceptar.PerformClick()
    End Sub

    Private Sub txtBusca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBusca.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnAceptar.PerformClick()
            e.Handled = True
        End If
    End Sub
End Class