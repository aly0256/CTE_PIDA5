Imports System.Data.OleDb



Public Class main

    Private nfi As New NotifyIcon
    Private mensaje As String = ""

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Me.BackgroundWorker1.WorkerSupportsCancellation = True

            archivo_name = ""

            DateTimePicker1.Value = Now

            For Each sucursal As strucSucursales In ListaSucursales()


                ComboBoxSucursales.Items.Add(sucursal.nombre)
                If sucursal.def = True Then
                    ComboBoxSucursales.SelectedItem = sucursal.nombre
                End If


            Next



        Catch ex As Exception
            MsgBox("Se presentó un error al intentar mostrar las sucursales. Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "ERROR")
        End Try

       

    End Sub

    Private Sub proceso_principal()
        Try

            'archivo_name = ""
            Dim file_name As String = transacciones_procesadas()

            If file_name <> "" Then

                'MsgBox("El archivo de Transacciones se ha generado correctamente", MsgBoxStyle.Information, "Informe")
                mensaje = "El archivo de Transacciones se ha generado correctamente"
            Else
                mensaje = "No se pudo generar el archivo de Transacciones"
                CancelarBackgroundWorker1()
                'MsgBox("No se pudo generar el archivo de Transacciones", MsgBoxStyle.Exclamation, "Aviso")
            End If


        Catch ex As Exception
            mensaje = "Se presentó un error al procesar la información. Si el problema persiste contacte al administrador"
            'MsgBox("Se presentó un error al procesar la información. Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "ERROR")
            CancelarBackgroundWorker1()
        End Try
    End Sub

    Private Sub CancelarBackgroundWorker1()

        If Me.BackgroundWorker1.IsBusy Then

            If Me.BackgroundWorker1.WorkerSupportsCancellation Then
                Me.BackgroundWorker1.CancelAsync()
            End If
        End If

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False

        fecha_reporte = DateTimePicker1.Value

        Label1.Text = ""
        ComboBoxSucursales.Enabled = False
        DateTimePicker1.Enabled = False
        ProgressBar1.Visible = False
        Button1.Text = " - "

        Dim sfd As New SaveFileDialog

        Try

            sfd.Title = "Guardar Reporte"
            sfd.CheckFileExists = False
            sfd.CheckPathExists = False
            sfd.FileName = "Transacciones aplicadas " & FechaSQL(fecha_reporte).Replace("-", "") & ".xlsx"
            sfd.DefaultExt = "xlsx"
            sfd.Filter = "Excel (*.xlsx)|*.xlsx"
            sfd.RestoreDirectory = True

            If sfd.ShowDialog = DialogResult.OK Then

                archivo_name = sfd.FileName
                Label1.Text = "Analizando..."
                ProgressBar1.Visible = True

                For Each sucursal As strucSucursales In ListaSucursales()
                    If sucursal.nombre.Trim = ComboBoxSucursales.Text.Trim Then

                        SQLConn = sucursal.conexion
                        sPassword = sucursal.clave
                        sUserAdmin = sucursal.usuario

                        Me.BackgroundWorker1.RunWorkerAsync()

                        Exit For
                    End If
                Next

            End If

           

        Catch ex As Exception
            MsgBox("Se presentó un error al procesar la información. Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "ERROR")
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            If Me.BackgroundWorker1.CancellationPending Then
                e.Cancel = True
            Else
                proceso_principal()

                If Me.BackgroundWorker1.CancellationPending Then
                    e.Cancel = True
                End If


            End If
        Catch ex As Exception
            MessageBox.Show("Se ha producido un error durante la ejecución. Si el problema persiste contacte al administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
       
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        If e.Cancelled Then
            MessageBox.Show(mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf e.Error IsNot Nothing Then
            MessageBox.Show("Se ha producido un error durante la ejecución: " & e.Error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("El archivo de Transacciones se ha generado correctamente", "INFORME", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Label1.Text = "Analizando " & e.ProgressPercentage & "%"
    End Sub
End Class