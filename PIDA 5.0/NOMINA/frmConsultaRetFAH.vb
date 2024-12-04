Imports OfficeOpenXml
Imports System.Globalization

Public Class frmConsultaRetFAH
    Dim dtTemp As New DataTable
    Dim dtPersonal As New DataTable
    Dim dtArbolPersAct As New DataTable
    ' Dim dtArbolAllPers As New DataTable
    Dim dtArbolCanc As New DataTable


    Dim grupo As String
    Dim identificador As String

    Private Sub frmConsultaRetFAH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim QuerySoloPersAct As String = "" & _
            "SELECT p.id , p.RELOJ,p.NOMBRE, p.CONFIRMADO,cast(p.cantidad as decimal(10,2))as cantidad, p.exportado,cast(p.FECHA_SOL as nvarchar) as 'Fecha de Solicitud','RETIRO FONDO DE AHORRO' AS 'Grupo1',p.ano as 'Grupo2', p.periodo as 'Grupo3' " & _
            "from prestamos p LEFT OUTER JOIN PERSONAL.dbo.personalvw psw ON '0'+p.RELOJ = psw.RELOJ " & _
            "WHERE p.FECHA_SOL>=DATEADD(YY,-1,GETDATE()) AND   isnull(psw.baja,'')='' AND ISNULL(psw.inactivo,0)=0 " & _
            "order by p.ano asc, CAST(p.periodo as int) asc"
        dtArbolPersAct = sqlExecute(QuerySoloPersAct, "KIOSCO")

        '  Dim query As String = "" & _
        '"SELECT id , RELOJ,NOMBRE, CONFIRMADO,cast(cantidad as decimal(10,2))as cantidad, exportado,cast(FECHA_SOL as nvarchar) as 'Fecha de Solicitud','RETIRO FONDO DE AHORRO' AS 'Grupo1',ano as 'Grupo2', periodo as 'Grupo3' from prestamos order by ano asc, CAST(periodo as int) asc"
        '  dtArbolAllPers = sqlExecute(query, "Kiosco")

        Dim query2 As String = "" & _
    "SELECT id , RELOJ,NOMBRE, CONFIRMADO,usuario_can, exportado,cast(FECHA_CAN as nvarchar) as 'Fecha de cancelación','RETIROS FONDO DE AHORRO' AS 'Grupo1',ano as 'Grupo2', periodo as 'Grupo3' from prestamos_cancelados order by ano asc, CAST(periodo as int) asc"
        dtArbolCanc = sqlExecute(query2, "KIOSCO")
        RefrescarArbol()
    End Sub

    Private Sub RefrescarArbol()
        ' -- Actualizar Información de Retiros de Fondo de ahorro, solo personal activo y de un año para delante

        For Each drow As DataRow In dtArbolPersAct.Select("Grupo1 = 'RETIRO FONDO DE AHORRO'")

            Dim dttemp As New DataTable
            dttemp = sqlExecute("select *  from pensiones where reloj = '" & drow("reloj") & "'", "KIOSCO")
            If dttemp.Rows.Count > 0 Then
                drow("NOMBRE") = drow("NOMBRE") & " (CON PENSION)"
            End If
        Next

        '--Activar Form de cargar información
        frmTrabajando.Show(Me)
        frmTrabajando.Avance.Value = 0
        frmTrabajando.Avance.IsRunning = False
        frmTrabajando.lblAvance.Text = "Cargando información..."
        Application.DoEvents()
        frmTrabajando.Avance.IsRunning = True


        advSolicitudes.DataSource = dtArbolPersAct
        advSolicitudes.GroupingMembers = "Grupo1,Grupo2,Grupo3"
        For Each n As DevComponents.AdvTree.Node In advSolicitudes.Nodes

            If n.Text = "RETIRO FONDO DE AHORRO" Then
                For Each k As DevComponents.AdvTree.Node In n.Nodes               
                    For Each l As DevComponents.AdvTree.Node In k.Nodes
                        frmTrabajando.lblAvance.Text = "Periodo " & l.ToString.Trim
                        Application.DoEvents()
                        For Each m As DevComponents.AdvTree.Node In l.Nodes
                            m.CheckBoxVisible = True
                            If m.Cells(5).Text = "1" Then
                                m.Checked = True
                            End If
                        Next
                    Next
                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()
                Next
            End If
        Next
        'ACTUALIZAR ARBOL DE CANCELACIONESS

        advCancelaciones.DataSource = dtArbolCanc
        advCancelaciones.GroupingMembers = "Grupo1,Grupo2,Grupo3"
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarBusq_Click(sender As Object, e As EventArgs) Handles btnLimpiarBusq.Click
        RefrescarArbol()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        '--- Abrir Form y buscar a empleado   

        dtTemp = dtPersonal

        Try
            frmBuscar.ShowDialog(Me)
            If Reloj2.ToString.Trim <> "CANCEL" Then
                RefreshTreeXRj(Reloj2.ToString.Trim)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtPersonal = dtTemp
        End Try
    End Sub

    Private Sub RefreshTreeXRj(ByVal rj As String)
        Try
            If (rj.Trim <> "") Then
                If (rj.Trim.Length = 6) Then rj = rj.Substring(1, 5)
                'ACTUALIZAR ARBOL DE SOLICITUDES
                Dim query As String = "" & _
                    "SELECT id , RELOJ,NOMBRE, CONFIRMADO,cast(cantidad as decimal(10,2))as cantidad, exportado,cast(FECHA_SOL as nvarchar) as 'Fecha de Solicitud','RETIRO FONDO DE AHORRO' AS 'Grupo1',ano as 'Grupo2', periodo as 'Grupo3' from prestamos where reloj='" & rj.Trim & "' order by ano asc, CAST(periodo as int) asc"
                Dim dtArbol As DataTable = sqlExecute(query, "KIOSCO")

                For Each drow As DataRow In dtArbol.Select("Grupo1 = 'RETIRO FONDO DE AHORRO'")

                    Dim dttemp As New DataTable
                    dttemp = sqlExecute("select *  from pensiones where reloj = '" & drow("reloj") & "'", "KIOSCO")
                    If dttemp.Rows.Count > 0 Then
                        drow("NOMBRE") = drow("NOMBRE") & " (CON PENSION)"
                    End If
                Next

                advSolicitudes.DataSource = dtArbol
                advSolicitudes.GroupingMembers = "Grupo1,Grupo2,Grupo3"
                For Each n As DevComponents.AdvTree.Node In advSolicitudes.Nodes
                    If n.Text = "RETIRO FONDO DE AHORRO" Then
                        For Each k As DevComponents.AdvTree.Node In n.Nodes
                            For Each l As DevComponents.AdvTree.Node In k.Nodes
                                For Each m As DevComponents.AdvTree.Node In l.Nodes
                                    m.CheckBoxVisible = True
                                    If m.Cells(5).Text = "1" Then
                                        m.Checked = True
                                    End If
                                Next
                            Next
                        Next
                    End If
                Next
                'ACTUALIZAR ARBOL DE CANCELACIONESS
                query = "" & _
                    "SELECT id , RELOJ,NOMBRE, CONFIRMADO,usuario_can, exportado,cast(FECHA_CAN as nvarchar) as 'Fecha de cancelación','RETIROS FONDO DE AHORRO' AS 'Grupo1',ano as 'Grupo2', periodo as 'Grupo3' from prestamos_cancelados where reloj='" & rj.Trim & "' order by ano asc, CAST(periodo as int) asc"
                dtArbol = sqlExecute(query, "KIOSCO")
                advCancelaciones.DataSource = dtArbol
                advCancelaciones.GroupingMembers = "Grupo1,Grupo2,Grupo3"

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class