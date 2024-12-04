Public Class frmBuscarVacantes
    Public CodVac As String
    Dim dtBuscar As New DataTable
    Dim DesdeGrid As Boolean
    Dim idxBusca As Integer

    Private Sub MostrarInformacionBuscar(ByVal idx As Integer)

        On Error Resume Next

        Me.lblEstado.BackColor = System.Drawing.Color.DarkBlue
        Me.lblEstado.Text = ""

        If idx < 0 Then
            txtCodVacante.Text = ""
            txtVacante.Text = ""
            txtReloj.Text = ""
            txtSupervisor.Text = ""
            txtPlanta.Text = ""
            txtDepto.Text = ""
        Else
            txtCodVacante.Text = dtBuscar.Rows.Item(idx).Item("Cod_Vac").ToString.Trim
            txtVacante.Text = dtBuscar.Rows.Item(idx).Item("Vacante").ToString.Trim
            txtReloj.Text = Trim(Split(dtBuscar.Rows.Item(idx).Item("Supervisor").ToString.Trim, "-")(0))
            txtSupervisor.Text = Trim(Split(dtBuscar.Rows.Item(idx).Item("Supervisor").ToString.Trim, "-")(1))
            txtPlanta.Text = dtBuscar.Rows.Item(idx).Item("Planta").ToString.Trim
            txtDepto.Text = dtBuscar.Rows.Item(idx).Item("Depto").ToString.Trim

            If dtBuscar.Rows.Item(idx).Item("Activo").ToString.Trim Then
                Me.lblEstado.BackColor = System.Drawing.Color.LimeGreen
                Me.lblEstado.Text = "ACTIVO"
            Else
                Me.lblEstado.BackColor = System.Drawing.Color.IndianRed
                Me.lblEstado.Text = "INACTIVO"
            End If

            If dgDatos.Rows.Count > idxBusca And Not DesdeGrid Then
                dgDatos.FirstDisplayedScrollingRowIndex = idx
                dgDatos.Rows(idxBusca).Selected = True
            End If

        End If

    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Me.CodVac = IIf(txtCodVacante.Text.Trim = "", "CANCELAR", txtCodVacante.Text.Trim)
        Me.Close()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.CodVac = "CANCELAR"
        Me.Close()
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        DesdeGrid = False
        idxBusca = 0
        MostrarInformacionBuscar(idxBusca)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        DesdeGrid = False
        idxBusca = dtBuscar.Rows.Count - 1
        MostrarInformacionBuscar(idxBusca)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        DesdeGrid = False
        idxBusca = idxBusca - 1
        If idxBusca < 0 Then idxBusca = 0
        MostrarInformacionBuscar(idxBusca)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        DesdeGrid = False
        idxBusca = idxBusca + 1
        If idxBusca = dtBuscar.Rows.Count Then idxBusca = dtBuscar.Rows.Count - 1
        MostrarInformacionBuscar(idxBusca)
    End Sub

    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        Dim vl As String, strSQL As String
        Dim vlCod_vac As String = ""
        vl = txtBusca.Text.ToUpper.Replace("*", "%")
        If IsNumeric(vl) Then
            vlCod_vac = vl
        End If
        strSQL = "select top 1000 * from vacantes "
        strSQL = strSQL & "where cod_vac = '" & vlCod_vac & "' or Vacante like '%" & vl & "%' or Supervisor like '%" & vl & "%' or Planta like '%" & vl & "%' or Depto like '%" & vl & "%'"

        dtBuscar = sqlExecute(strSQL, "Reclutamiento")

        If dtBuscar.Rows.Count > 0 Then
            idxBusca = 0
            MostrarInformacionBuscar(idxBusca)
        Else
            MostrarInformacionBuscar(-1)
        End If
        dgDatos.DataSource = dtBuscar

    End Sub

    Private Sub frmBuscarVacantes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmBuscarVacantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        On Error Resume Next

        Me.lblEstado.BackColor = System.Drawing.Color.DarkBlue
        Me.lblEstado.Text = ""

        Dim strSQL As String
        Me.CodVac = "CANCELAR"

        dgDatos.AutoGenerateColumns = False

        strSQL = "select top 100 * from vacantes order by cod_vac desc"
        dtBuscar = sqlExecute(strSQL, "Reclutamiento")

        If dtBuscar.Rows.Count > 0 Then
            idxBusca = 0
            MostrarInformacionBuscar(idxBusca)
        Else
            MostrarInformacionBuscar(-1)
        End If
        dgDatos.DataSource = dtBuscar
        txtBusca.Focus()

    End Sub

    Private Sub dgDatos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDatos.CellContentDoubleClick
        btnAceptar.PerformClick()
    End Sub

    Private Sub dgDatos_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgDatos.RowEnter
        DesdeGrid = True
        idxBusca = e.RowIndex
        MostrarInformacionBuscar(idxBusca)
    End Sub

    Private Sub dgDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgDatos.DoubleClick
        btnAceptar.PerformClick()
    End Sub
End Class