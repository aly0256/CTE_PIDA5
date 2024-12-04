Public Class frmBuscaIdeas
    Dim dtBuscar As New DataTable
    Dim idxBusca As Integer
    Dim DesdeGrid As Boolean
    Public Folio As String
    Private Sub MostrarInformacionBuscar(ByVal idx As Integer)
        'lblEstado.Text = dtBuscar.Rows.Count & " LOCALIZADOS"
        On Error Resume Next
        If idx < 0 Then
            txtFolio.Text = ""
            txtNombre.Text = ""
            txtIdea.Text = ""
            txtReloj.Text = ""
        Else
            txtFolio.Text = dtBuscar.Rows.Item(idx).Item("Folio").ToString.Trim
            txtNombre.Text = dtBuscar.Rows.Item(idx).Item("nombre_empleado").ToString.Trim
            txtIdea.Text = dtBuscar.Rows.Item(idx).Item("nombre").ToString.Trim
            txtReloj.Text = dtBuscar.Rows.Item(idx).Item("Reloj").ToString.Trim

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
        strSQL = "select  TOP 1000 ideas_empleado.folio,rtrim(ideas_empleado.nombre) as nombre,ideas_empleado.reloj,personalvw.nombres as nombre_empleado from ideas_empleado left join personal.dbo.personalvw on ideas_empleado.reloj=personalvw.reloj "
        strSQL = strSQL + "where ideas_empleado.folio like '%" & vl & "%' or ideas_empleado.nombre like '%" & vl & "%' or ideas_empleado.reloj  like '%" & vl & "%' or personalvw.nombres like '%" & vl & "%'"
        ' strSQL = Replace(CadenaBuscar, "strBuscar", vl)
        dtBuscar = sqlExecute(strSQL, "IDEAS")

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
        strSQL = "select top 100 ideas_empleado.folio,ideas_empleado.nombre,ideas_empleado.reloj,personalvw.nombres as nombre_empleado from ideas_empleado left join personal.dbo.personalvw on ideas_empleado.reloj=personalvw.reloj order by ideas_empleado.fecha desc"
        'strSQL = Replace(CadenaBuscar, "strBuscar", vl)
        dtBuscar = sqlExecute(strSQL, "IDEAS")
        If dtBuscar.Rows.Count > 0 Then
            idxBusca = 0
            MostrarInformacionBuscar(idxBusca)
        Else
            MostrarInformacionBuscar(-1)
        End If
        dgDatos.DataSource = dtBuscar
        txtBusca.Focus()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Folio = IIf(txtFolio.Text = "", "CANCELAR", txtFolio.Text)

        'Compania = txtCia.Text
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Folio = "CANCELAR"
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