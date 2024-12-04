Public Class uscDispositivoCafeteria
    Dim CodigoDispositivo As String
    Dim Descripcion As String
    Dim UltimaSincronizacion As DateTime
    Dim Version As String



    Dim connectedInt As Integer
    Dim rebootInt As Integer
    Dim refreshInt As Integer
    Dim SyncInt As Integer

    Dim Conectado As Boolean
    Dim Actualizar As Boolean
    Dim Reiniciar As Boolean
    Dim Sincronizar As Boolean

    Dim Bloqueado As Boolean
    Public Sub New(Codigo As String)
        InitializeComponent()
        CodigoDispositivo = Codigo
    End Sub
    Private Sub MostrarInformacion()

        Try
            If System.IO.File.Exists(PathFoto & "cafeteria\" & CodigoDispositivo & ".jpg") Then
                btnScreenshot.Enabled = True
            Else
                btnScreenshot.Enabled = False
            End If
        Catch ex As Exception

        End Try
        

        Dim dtDispositivo As DataTable = sqlExecute("select * from dispositivos where cod_dispositivo = '" + CodigoDispositivo + "'", "cafeteria")
        If dtDispositivo.Rows.Count > 0 Then
            Descripcion = IIf(IsDBNull(dtDispositivo.Rows(0).Item("descripcion")), "", dtDispositivo.Rows(0).Item("descripcion")).ToString.Trim
            Version = IIf(IsDBNull(dtDispositivo.Rows(0).Item("version")), "", dtDispositivo.Rows(0).Item("version")).ToString.Trim
            UltimaSincronizacion = IIf(IsDBNull(dtDispositivo.Rows(0).Item("ultima_sincronizacion")), Nothing, dtDispositivo.Rows(0).Item("ultima_sincronizacion"))
            connectedInt = IIf(IsDBNull(dtDispositivo.Rows(0).Item("conectado")), 0, dtDispositivo.Rows(0).Item("conectado"))
            rebootInt = IIf(IsDBNull(dtDispositivo.Rows(0).Item("reiniciar")), 0, dtDispositivo.Rows(0).Item("reiniciar"))
            refreshInt = IIf(IsDBNull(dtDispositivo.Rows(0).Item("actualizar")), 0, dtDispositivo.Rows(0).Item("actualizar"))
            SyncInt = IIf(IsDBNull(dtDispositivo.Rows(0).Item("sincronizar")), 0, dtDispositivo.Rows(0).Item("sincronizar"))
        Else
            CodigoDispositivo = ""
            Descripcion = ""
            Conectado = False
            Reiniciar = False
            Actualizar = False
            Sincronizar = False
            connectedInt = 0
            Version = "0.0.0.0"
            UltimaSincronizacion = Nothing
        End If
        Me.lblDispositivo.Text = "<b><font size=""+8"">" + CodigoDispositivo + "</font></b>"
        lblDescripcion.Text = Descripcion
        lblVersion.Text = Version
        Conectado = IIf(connectedInt = 0, False, True)
        Reiniciar = IIf(rebootInt = 0, False, True)
        Actualizar = IIf(refreshInt = 0, False, True)
        Sincronizar = IIf(SyncInt = 0, False, True)

        btnActualizar.Enabled = Not Actualizar
        btnReiniciar.Enabled = Not Reiniciar
        btnSincronizar.Enabled = Not Sincronizar
        pnlEstatus.BackColor = IIf(Conectado, Color.LimeGreen, Color.IndianRed)



    End Sub
    Private Sub uscDispositivoCafeteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrDispositivo.Start()
    End Sub

    Private Sub tmrDispositivo_Tick(sender As Object, e As EventArgs) Handles tmrDispositivo.Tick
        MostrarInformacion()
    End Sub

    Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
        sqlExecute("update dispositivos set sincronizar = '1' where cod_dispositivo= '" + CodigoDispositivo + "'", "cafeteria")
    End Sub

    Private Sub btnReiniciar_Click(sender As Object, e As EventArgs) Handles btnReiniciar.Click
        sqlExecute("update dispositivos set reiniciar = '1' where cod_dispositivo= '" + CodigoDispositivo + "'", "cafeteria")
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        sqlExecute("update dispositivos set sincronizar = '1' where cod_dispositivo= '" + CodigoDispositivo + "'", "cafeteria")
        sqlExecute("update dispositivos set sincronizar_personal = '1' where cod_dispositivo= '" + CodigoDispositivo + "'", "cafeteria")
        sqlExecute("update dispositivos set borrar_personal = '1' where cod_dispositivo= '" + CodigoDispositivo + "'", "cafeteria")
        sqlExecute("update dispositivos set reiniciar = '1' where cod_dispositivo= '" + CodigoDispositivo + "'", "cafeteria")
    End Sub

    Private Sub btnBloquear_Click(sender As Object, e As EventArgs) Handles btnBloquear.Click
        If btnBloquear.Text = "Bloquear" Then
            btnBloquear.Text = "Desbloquear"
            sqlExecute("update dispositivos set bloqueado = '1' where cod_dispositivo= '" + CodigoDispositivo + "'", "cafeteria")
        Else
            btnBloquear.Text = "Bloquear"
            sqlExecute("update dispositivos set bloqueado = '0' where cod_dispositivo= '" + CodigoDispositivo + "'", "cafeteria")
        End If

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnScreenshot.Click
        Try
            frmFoto.picFoto.Load(PathFoto & "cafeteria\" & CodigoDispositivo & ".jpg")
            frmFoto.Size = New Size(640, 360)
            frmFoto.Text = CodigoDispositivo
            frmFoto.ShowDialog(Me)
        Catch ex As Exception

        End Try
    End Sub
End Class
