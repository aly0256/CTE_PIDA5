Public Class frmElegirPlatillos
    Dim PathPlatillos As String = ""
    Dim dtPlatillos As DataTable
    Public CodigoPlatilloSeleccionado As String
    Private Sub frmElegirPlatillos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtPathP As DataTable = sqlExecute("select top 1 path_platillos from parametros ", "cafeteria")
        If dtPathP.Rows.Count > 0 Then
            PathPlatillos = dtPathP.Rows(0).Item("path_platillos")
        Else
            PathPlatillos = ""
        End If
        ActualizarListado()
    End Sub
    Private Sub Click_PLatillo(sender As Object, e As EventArgs)
        Dim c As uscPlatillo = TryCast(sender.parent, uscPlatillo)
        ' MessageBox.Show(c.CodigoPlatillo.ToString)
        CodigoPlatilloSeleccionado = c.CodigoPlatillo.ToString
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ActualizarListado(txtBuscar.Text)
    End Sub
    Private Sub ActualizarListado(Optional filtro As String = "")
        For Each c As uscPlatillo In flwPeriodosDisponibles.Controls
            RemoveHandler c.btnAgregarQuitar.Click, AddressOf Click_PLatillo
        Next
        flwPeriodosDisponibles.Controls.Clear()
        If filtro = "" Then
            dtPlatillos = sqlExecute("select * from platillos order by cod_platillo asc ", "cafeteria")
        Else
            dtPlatillos = sqlExecute("select * from platillos where nombre like '%" + filtro + "%' order by cod_platillo asc ", "cafeteria")
        End If
        For Each r As DataRow In dtPlatillos.Rows
            flwPeriodosDisponibles.Controls.Add(New uscPlatillo(r.Item("cod_platillo"), PathPlatillos + r.Item("cod_platillo") + ".jpg", r.Item("Nombre").ToString))
        Next
        For Each c As uscPlatillo In flwPeriodosDisponibles.Controls
            AddHandler c.btnAgregarQuitar.Click, AddressOf Click_PLatillo
        Next
    End Sub
End Class