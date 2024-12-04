
Public Class frmImportarChecadas
    Private Conecxion = False
    Private NumeroEquipo As Integer

    Public c As New zkemkeeper.CZKEM
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click




        If txtIP.Text.Trim() = "" Or txtPort.Text.Trim() = "" Then
            MsgBox("Llena los campos IP y Port antes de continuar", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        Dim idwErrorCode As Integer
        Cursor = Cursors.WaitCursor


        If ButtonX1.Text = "Desconectar" Then
            c.Disconnect()
            Conecxion = False
            ButtonX1.Text = "Conectar"
            lblState.Text = "Estado: Desconectado"
            Cursor = Cursors.Default
            Exit Sub
        End If

        Conecxion = c.Connect_Net(txtIP.Text.Trim, txtPort.Text.Trim)

        If Conecxion = True Then
            ButtonX1.Text = "Desconectar"
            'btnConnect.Refresh()
            lblState.Text = "Estado: Conectado"
            NumeroEquipo = 1 'Siempre es 1 en conection TCP/IP
            c.RegEvent(NumeroEquipo, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
        Else
            c.GetLastError(idwErrorCode)
            MsgBox("No fue posible la conexion,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click

        If Conecxion = False Then
            MsgBox("Realizar la conexion primero", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Dim dtdatos As New DataTable
        dtdatos.Columns.Add("ID")
        dtdatos.Columns.Add("Ano")
        dtdatos.Columns.Add("Mes")
        dtdatos.Columns.Add("Dia")
        dtdatos.Columns.Add("Hora")



        Dim idwTMachineNumber As Integer
        Dim idwEnrollNumber As Integer
        Dim idwEMachineNumber As Integer
        Dim idwVerifyMode As Integer
        Dim idwInOutMode As Integer
        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer

        Dim idwErrorCode As Integer
        Dim iGLCount = 0
        Dim lvItem As New ListViewItem("Items", 0)

        Cursor = Cursors.WaitCursor
        TextBoxX1.Text = ""

        c.EnableDevice(NumeroEquipo, False) 'Deshabilitar el equipo

        If c.ReadGeneralLogData(NumeroEquipo) Then 'Leer toda la informacion en memoria
            While c.GetGeneralLogData(NumeroEquipo, idwTMachineNumber, idwEnrollNumber, idwEMachineNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute)
                iGLCount += 1


                TextBoxX1.Text = TextBoxX1.Text & vbNewLine & idwEnrollNumber.ToString() & "  " & idwYear.ToString() & "-" & idwMonth.ToString() & "-" & idwDay.ToString() & "   " & idwHour.ToString() & ":" & idwMinute.ToString()
                'lvItem = lvLista1.Items.Add(iGLCount.ToString())
                'lvItem.SubItems.Add(idwEnrollNumber.ToString())
                'lvItem.SubItems.Add(idwVerifyMode.ToString())
                'lvItem.SubItems.Add(idwInOutMode.ToString())
                'lvItem.SubItems.Add(idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString())

                dtdatos.Rows.Add({idwEnrollNumber.ToString(),
                                  idwYear.ToString(),
                                  idwMonth.ToString(),
                                  idwDay.ToString(),
                                  idwHour.ToString() & ":" & idwMinute.ToString()
                                 })



                Application.DoEvents()


            End While

            DataGridViewX1.DataSource = dtdatos

        Else
            Cursor = Cursors.Default
            c.GetLastError(idwErrorCode)
            If idwErrorCode <> 0 Then
                MsgBox("Error al leer los registros,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
            Else
                MsgBox("No hay datos que leer", MsgBoxStyle.Exclamation, "Error")
            End If
        End If
        c.EnableDevice(NumeroEquipo, True) 'Habilitar equipo
        Cursor = Cursors.Default

    End Sub

    'Mismo proceso que el anterior, pero los registros se leen como cadenas de texto
    Private Sub ButtonX3_Click(sender As Object, e As EventArgs)
        'If Conecxion = False Then
        '    MsgBox("Realizar la conexion primero", MsgBoxStyle.Exclamation, "Error")
        '    Exit Sub
        'End If
        'Dim idwErrorCode As Integer

        'Dim idwEnrollNumber As Integer
        'Dim idwVerifyMode As Integer
        'Dim idwInOutMode As Integer
        'Dim sTime = ""

        'Dim lvItem As New ListViewItem("Items", 0)
        'Dim iGLCount = 0

        'Cursor = Cursors.WaitCursor
        'TextBoxX2.Text = ""
        'c.EnableDevice(NumeroEquipo, False)
        'If c.ReadGeneralLogData(NumeroEquipo) Then

        '    While c.GetGeneralLogDataStr(NumeroEquipo, idwEnrollNumber, idwVerifyMode, idwInOutMode, sTime)
        '        iGLCount += 1
        '        TextBoxX2.Text = TextBoxX2.Text & vbNewLine & idwEnrollNumber.ToString() & "-" & sTime
        '        'lvItem.SubItems.Add(idwEnrollNumber.ToString())
        '        'lvItem.SubItems.Add(idwVerifyMode.ToString())
        '        'lvItem.SubItems.Add(idwInOutMode.ToString())
        '        'lvItem.SubItems.Add(sTime)
        '        Application.DoEvents()
        '    End While
        'Else
        '    Cursor = Cursors.Default
        '    c.GetLastError(idwErrorCode)
        '    If idwErrorCode <> 0 Then
        '        MsgBox("Error al leer los registros,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        '    Else
        '        MsgBox("No hay datos que leer", MsgBoxStyle.Exclamation, "Error")
        '    End If
        'End If

        'c.EnableDevice(NumeroEquipo, True)
        'Cursor = Cursors.Default
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        If Conecxion = False Then
            MsgBox("Realizar la conexion primero", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        Dim idwErrorCode As Integer
        Dim iValue = 0

        c.EnableDevice(NumeroEquipo, False)
        If c.GetDeviceStatus(NumeroEquipo, 6, iValue) = True Then
            MsgBox("Numero de registros de asistecia " + iValue.ToString(), MsgBoxStyle.Information, "Success")
        Else
            c.GetLastError(idwErrorCode)
            MsgBox("Ocurrio un error,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If

    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        'If Conecxion = False Then
        '    MsgBox("Realizar la conexion primero", MsgBoxStyle.Exclamation, "Error")
        '    Exit Sub
        'End If
        'Dim idwErrorCode As Integer
        'If MessageBox.Show("Se borraran todos los registros del equipo, desa continuar?", "PIDA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        '    Exit Sub
        'End If
        ''lvLogs.Items.Clear()
        'c.EnableDevice(NumeroEquipo, False) 'disable the device
        'If c.ClearGLog(NumeroEquipo) = True Then
        '    c.RefreshData(NumeroEquipo) 'the data in the device should be refreshed
        '    MsgBox("Todos los registros del equipo han sido eliminados", MsgBoxStyle.Information, "Success")
        'Else
        '    c.GetLastError(idwErrorCode)
        '    MsgBox("Ocurrio un problema al eliminar los registros,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        'End If

        'c.EnableDevice(NumeroEquipo, True) 'enable the device
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs)
        'If Conecxion = False Then
        '    MsgBox("Realizar la conexion primero", MsgBoxStyle.Exclamation, "Error")
        '    Exit Sub
        'End If
        'Dim idwErrorCode As Integer

        'Dim idwEnrollNumber As Integer
        'Dim idwVerifyMode As Integer
        'Dim idwInOutMode As Integer
        'Dim idwYear As Integer
        'Dim idwMonth As Integer
        'Dim idwDay As Integer
        'Dim idwHour As Integer
        'Dim idwMinute As Integer
        'Dim idwSecond As Integer
        'Dim idwWorkCode As Integer
        'Dim idwReserved As Integer

        'Dim lvItem As New ListViewItem("Items", 0)
        'Dim iGLCount = 0

        'Cursor = Cursors.WaitCursor
        'TextBoxX2.Text = ""
        'c.EnableDevice(NumeroEquipo, False)
        'If c.ReadGeneralLogData(NumeroEquipo) Then
        '    'get the records from memory
        '    While c.GetGeneralExtLogData(NumeroEquipo, idwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkCode, idwReserved)
        '        iGLCount += 1
        '        TextBoxX2.Text = TextBoxX2.Text & vbNewLine & idwWorkCode.ToString() & "   " & idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString()
        '        'lvItem = lvLogs.Items.Add(iGLCount.ToString())
        '        'lvItem.SubItems.Add(idwEnrollNumber.ToString())
        '        'lvItem.SubItems.Add(idwVerifyMode.ToString())
        '        'lvItem.SubItems.Add(idwInOutMode.ToString())
        '        'lvItem.SubItems.Add(idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString())
        '        'lvItem.SubItems.Add(idwWorkCode.ToString())
        '        'lvItem.SubItems.Add(idwReserved.ToString())
        '        Application.DoEvents()
        '    End While
        'Else
        '    Cursor = Cursors.Default
        '    c.GetLastError(idwErrorCode)
        '    If idwErrorCode <> 0 Then
        '        MsgBox("Reading data from terminal failed,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        '    Else
        '        MsgBox("No data from terminal returns!", MsgBoxStyle.Exclamation, "Error")
        '    End If
        'End If

        'c.EnableDevice(NumeroEquipo, True) 'enable the device
        'Cursor = Cursors.Default
    End Sub

    Private Sub frmImportarChecadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonX3_Click_1(sender As Object, e As EventArgs) Handles ButtonX3.Click
        If Conecxion = False Then
            MsgBox("Realizar la conexion primero", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Dim dtdatos As New DataTable
        dtdatos.Columns.Add("ID")
        dtdatos.Columns.Add("Ano")
        dtdatos.Columns.Add("Mes")
        dtdatos.Columns.Add("Dia")
        dtdatos.Columns.Add("Hora")



        Dim idwTMachineNumber As Integer
        Dim idwEnrollNumber As Integer
        Dim idwEMachineNumber As Integer
        Dim idwVerifyMode As Integer
        Dim idwInOutMode As Integer
        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer
        Dim idSecond As Integer
        Dim idWorkcode As Integer

        Dim idwErrorCode As Integer
        Dim iGLCount = 0
        Dim lvItem As New ListViewItem("Items", 0)

        Cursor = Cursors.WaitCursor
        TextBoxX1.Text = ""

        c.EnableDevice(NumeroEquipo, False) 'Deshabilitar el equipo

        If c.ReadGeneralLogData(NumeroEquipo) Then 'Leer toda la informacion en memoria
            While c.SSR_GetGeneralLogData(NumeroEquipo, idwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idSecond, idWorkcode)
                iGLCount += 1


                TextBoxX1.Text = TextBoxX1.Text & vbNewLine & idwEnrollNumber.ToString() & "  " & idwYear.ToString() & "-" & idwMonth.ToString() & "-" & idwDay.ToString() & "   " & idwHour.ToString() & ":" & idwMinute.ToString()
                'lvItem = lvLista1.Items.Add(iGLCount.ToString())
                'lvItem.SubItems.Add(idwEnrollNumber.ToString())
                'lvItem.SubItems.Add(idwVerifyMode.ToString())
                'lvItem.SubItems.Add(idwInOutMode.ToString())
                'lvItem.SubItems.Add(idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString())

                dtdatos.Rows.Add({idwEnrollNumber.ToString(),
                                  idwYear.ToString(),
                                  idwMonth.ToString(),
                                  idwDay.ToString(),
                                  idwHour.ToString() & ":" & idwMinute.ToString()
                                 })



                Application.DoEvents()


            End While

            DataGridViewX1.DataSource = dtdatos

        Else
            Cursor = Cursors.Default
            c.GetLastError(idwErrorCode)
            If idwErrorCode <> 0 Then
                MsgBox("Error al leer los registros,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
            Else
                MsgBox("No hay datos que leer", MsgBoxStyle.Exclamation, "Error")
            End If
        End If
        c.EnableDevice(NumeroEquipo, True) 'Habilitar equipo
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonX6_Click_1(sender As Object, e As EventArgs) Handles ButtonX6.Click
        If Conecxion = False Then
            MsgBox("Realizar la conexion primero", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Dim dtdatos As New DataTable
        dtdatos.Columns.Add("ID")
        dtdatos.Columns.Add("Ano")
        dtdatos.Columns.Add("Mes")
        dtdatos.Columns.Add("Dia")
        dtdatos.Columns.Add("Hora")



        Dim idwTMachineNumber As Integer
        Dim idwEnrollNumber As Integer
        Dim idwEMachineNumber As Integer
        Dim idwVerifyMode As Integer
        Dim idwInOutMode As Integer
        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer
        Dim idSecond As Integer
        Dim idWorkcode As Integer

        Dim idwErrorCode As Integer
        Dim iGLCount = 0
        Dim lvItem As New ListViewItem("Items", 0)

        Cursor = Cursors.WaitCursor
        TextBoxX1.Text = ""

        c.EnableDevice(NumeroEquipo, False) 'Deshabilitar el equipo

        If c.ReadGeneralLogData(NumeroEquipo) Then 'Leer toda la informacion en memoria
            While c.GetAllGLogData(NumeroEquipo, idwTMachineNumber, idwEnrollNumber, idwEMachineNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute)
                iGLCount += 1


                TextBoxX1.Text = TextBoxX1.Text & vbNewLine & idwEnrollNumber.ToString() & "  " & idwYear.ToString() & "-" & idwMonth.ToString() & "-" & idwDay.ToString() & "   " & idwHour.ToString() & ":" & idwMinute.ToString()
                'lvItem = lvLista1.Items.Add(iGLCount.ToString())
                'lvItem.SubItems.Add(idwEnrollNumber.ToString())
                'lvItem.SubItems.Add(idwVerifyMode.ToString())
                'lvItem.SubItems.Add(idwInOutMode.ToString())
                'lvItem.SubItems.Add(idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString())

                dtdatos.Rows.Add({idwEnrollNumber.ToString(),
                                  idwYear.ToString(),
                                  idwMonth.ToString(),
                                  idwDay.ToString(),
                                  idwHour.ToString() & ":" & idwMinute.ToString()
                                 })



                Application.DoEvents()


            End While

            DataGridViewX1.DataSource = dtdatos

        Else
            Cursor = Cursors.Default
            c.GetLastError(idwErrorCode)
            If idwErrorCode <> 0 Then
                MsgBox("Error al leer los registros,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
            Else
                MsgBox("No hay datos que leer", MsgBoxStyle.Exclamation, "Error")
            End If
        End If
        c.EnableDevice(NumeroEquipo, True) 'Habilitar equipo
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonX7_Click(sender As Object, e As EventArgs) Handles ButtonX7.Click
        If Conecxion = False Then
            MsgBox("Realizar la conexion primero", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Dim dtdatos As New DataTable
        dtdatos.Columns.Add("ID")
        dtdatos.Columns.Add("Ano")
        dtdatos.Columns.Add("Mes")
        dtdatos.Columns.Add("Dia")
        dtdatos.Columns.Add("Hora")



        Dim idwTMachineNumber As Integer
        Dim idwEnrollNumber As Integer
        Dim idwEMachineNumber As Integer
        Dim idwVerifyMode As Integer
        Dim idwInOutMode As Integer
        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer
        Dim idSecond As Integer
        Dim idWorkcode As Integer
        Dim idreserved As Integer
        Dim idwErrorCode As Integer
        Dim iGLCount = 0
        Dim lvItem As New ListViewItem("Items", 0)

        Cursor = Cursors.WaitCursor
        TextBoxX1.Text = ""

        c.EnableDevice(NumeroEquipo, False) 'Deshabilitar el equipo

        If c.ReadGeneralLogData(NumeroEquipo) Then 'Leer toda la informacion en memoria
            While c.GetGeneralExtLogData(NumeroEquipo, idwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idSecond, idWorkcode, idReserved)
                iGLCount += 1


                TextBoxX1.Text = TextBoxX1.Text & vbNewLine & idwEnrollNumber.ToString() & "  " & idwYear.ToString() & "-" & idwMonth.ToString() & "-" & idwDay.ToString() & "   " & idwHour.ToString() & ":" & idwMinute.ToString()
                'lvItem = lvLista1.Items.Add(iGLCount.ToString())
                'lvItem.SubItems.Add(idwEnrollNumber.ToString())
                'lvItem.SubItems.Add(idwVerifyMode.ToString())
                'lvItem.SubItems.Add(idwInOutMode.ToString())
                'lvItem.SubItems.Add(idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString())

                dtdatos.Rows.Add({idwEnrollNumber.ToString(),
                                  idwYear.ToString(),
                                  idwMonth.ToString(),
                                  idwDay.ToString(),
                                  idwHour.ToString() & ":" & idwMinute.ToString()
                                 })



                Application.DoEvents()


            End While

            DataGridViewX1.DataSource = dtdatos

        Else
            Cursor = Cursors.Default
            c.GetLastError(idwErrorCode)
            If idwErrorCode <> 0 Then
                MsgBox("Error al leer los registros,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
            Else
                MsgBox("No hay datos que leer", MsgBoxStyle.Exclamation, "Error")
            End If
        End If
        c.EnableDevice(NumeroEquipo, True) 'Habilitar equipo
        Cursor = Cursors.Default
    End Sub
End Class