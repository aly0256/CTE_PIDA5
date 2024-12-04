Public Class frmBuscaGeneral
    Dim dtBuscar As New DataTable
    Dim idxBusca As Integer
    Dim DesdeGrid As Boolean

    Private Sub MostrarInformacionBuscar(ByVal idx As Integer)
        'lblEstado.Text = dtBuscar.Rows.Count & " LOCALIZADOS"
        On Error Resume Next
        If idx < 0 Then
            txtCodigo.Text = ""
            txtNombre.Text = ""
            txtCia.Text = ""
        Else
            txtCodigo.Text = dtBuscar.Rows.Item(idx).Item("Codigo").ToString.Trim
            txtNombre.Text = dtBuscar.Rows.Item(idx).Item("nombre").ToString.Trim
            txtCia.Text = dtBuscar.Rows.Item(idx).Item("compañía").ToString.Trim
            txtCia.Visible = txtCia.Text <> "NA"
            lblCia.Visible = txtCia.Text <> "NA"

            If dgDatos.Rows.Count > idxBusca And Not DesdeGrid Then
                dgDatos.FirstDisplayedScrollingRowIndex = idx
                dgDatos.Rows(idxBusca).Selected = True
            End If
        End If
        'lblEstado.BackColor = IIf(idx < 0, Color.IndianRed, Color.LimeGreen)
    End Sub

    Private Sub txtBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusca.TextChanged
        Dim vl As String, strSQL As String
        vl = txtBusca.Text.ToUpper.Replace("*", "%")
        strSQL = Replace(CadenaBuscar, "strBuscar", vl)
        dtBuscar = sqlExecute(strSQL)

        If dtBuscar.Rows.Count > 0 Then
            idxBusca = 0
            MostrarInformacionBuscar(idxBusca)
        Else
            MostrarInformacionBuscar(-1)
        End If
        dgDatos.DataSource = dtBuscar
    End Sub

    Private Sub frmBuscaGeneral_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmBuscaGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vl As String, strSQL As String
        Codigo = "CANCELAR"
        vl = txtBusca.Text.ToUpper

        strSQL = Replace(CadenaBuscar, "strBuscar", vl)
        dtBuscar = sqlExecute(strSQL)

        If dtBuscar.Rows.Count > 0 Then
            idxBusca = 0
            MostrarInformacionBuscar(idxBusca)
        Else
            MostrarInformacionBuscar(-1)
        End If
        dgDatos.DataSource = dtBuscar
        dgDatos.Columns(0).Visible = ContieneCampoCia
        txtBusca.Focus()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Codigo = txtCodigo.Text
        Compania = txtCia.Text
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Codigo = "CANCELAR"
        Me.Close()
    End Sub

    Private Sub dgDatos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDatos.CellContentDoubleClick
        btnAceptar.PerformClick()
    End Sub

    Private Sub dgDatos_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.RowEnter
        DesdeGrid = True
        idxBusca = e.RowIndex
        MostrarInformacionBuscar(idxBusca)
    End Sub

    Private Sub btnPrev_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        DesdeGrid = False
        idxBusca = idxBusca - 1
        If idxBusca < 0 Then idxBusca = 0
        MostrarInformacionBuscar(idxBusca)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        DesdeGrid = False
        idxBusca = idxBusca + 1
        If idxBusca = dtBuscar.Rows.Count Then idxBusca = dtBuscar.Rows.Count - 1
        MostrarInformacionBuscar(idxBusca)
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        DesdeGrid = False
        idxBusca = dtBuscar.Rows.Count - 1
        MostrarInformacionBuscar(idxBusca)
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        DesdeGrid = False
        idxBusca = 0
        MostrarInformacionBuscar(idxBusca)
    End Sub

    Private Sub dgDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.CellContentClick

    End Sub

    Private Sub dgDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgDatos.DoubleClick
        btnAceptar.PerformClick()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class