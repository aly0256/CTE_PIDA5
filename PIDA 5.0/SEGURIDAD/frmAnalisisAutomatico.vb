Public Class frmAnalisisAutomatico

    Private Sub frmAnalisisAutomatico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.TopMost = True

        frmLogin.txtUsuario.Text = "AnalisisTA"
        frmLogin.txtClave.Text = "adip*014"
        ListBox1.Items.Clear()

        Timer1.Start()

    End Sub

    Dim iniciar As Integer = 5
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If iniciar > 0 Then
                iniciar -= 1

                ListBox1.Items.Clear()
                agregar_elemento("Iniciando " & iniciar)
                Application.DoEvents()
            Else
                ANALISIS_AUTOMATICO = True
                Timer1.Stop()
                frmLogin.btnOk.PerformClick()

                agregar_elemento("ANALISIS_AUTOMATICO = 1")

                frmMain.analisis_auto(Now)

            End If
        Catch ex As Exception
            Me.Close()
        End Try
    End Sub

    Public Sub agregar_elemento(elemento As String)
        ListBox1.Items.Add(elemento)
        Application.DoEvents()
        ListBox1.TopIndex = ListBox1.Items.Count - 1
    End Sub

    Private Sub frmAnalisisAutomatico_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ANALISIS_AUTOMATICO = False
        agregar_elemento("Cancelado: " & FechaHoraSQL(Now))


        Try
            ActivoTrabajando = False
            frmTrabajando.Close()
        Catch ex As Exception

        End Try
    End Sub

End Class