Imports System.Web.Mail
Public Class frmCondicionesReporteTextra

    Public dtDatosReportes As DataTable
    Public fini As Date
    Public ffin As Date

    Private Sub btnAutorizarGlobal_Click(sender As Object, e As EventArgs) Handles btnAutorizarGlobal.Click
        Try
            Dim super_envio As String = ""
            Dim correo_super As String = ""
            Dim cod_super As String = ""
            If txtHoraDesde.Text.Trim = "" Or txtHoraHasta.Text.Trim = "" Then
                MessageBox.Show("Por favor capture la hora de inicio y fin", "Captura de horas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                For Each row As DataRow In dtDatosReportes.Rows



                    If Trim(txtComentarios.Text) <> "" Then
                        row("comentario") = txtComentarios.Text
                    Else
                        row("comentario") = ""
                    End If
                    row("desde") = txtHoraDesde.Text
                    row("hasta") = txtHoraHasta.Text
                    super_envio = row("super")
                    cod_super = row("cod_super")
                Next

                'Dim nombre_archivo As String = "C:\INDEX\Formato autorización " & Replace(dtiFechaAutorizacion.Text, "/", "-") & ".pdf"
                If dtDatosReportes.Select("fecha = '" & FechaSQL(dtiFechaAutorizacion.Value) & "'").Any Then
                    Dim nombre_archivo As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) & "\Formato autorización " & Replace(dtiFechaAutorizacion.Text, "/", "-") & ".pdf"
                    frmVistaPrevia.LlamarReporte("Tiempo extra autorizado", dtDatosReportes.Select("fecha = '" & FechaSQL(dtiFechaAutorizacion.Value) & "'").CopyToDataTable, "", {}, False, nombre_archivo)
                    frmVistaPrevia.ShowDialog()


                    'Dim result As DialogResult = frmAutorizacionEnviar.ShowDialog()
                    Dim dtcorreosuper As DataTable = sqlExecute("select * from super where cod_super = '" & cod_super & "'")
                    If dtcorreosuper.Rows.Count > 0 Then
                        correo_super = dtcorreosuper.Rows(0).Item("correo")
                        EnviarCorreoSMTP("Formato autorización " & Trim(super_envio) & " " & FechaSQL(dtiFechaAutorizacion.Value).ToString, "", correo_super, "", nombre_archivo)
                    End If
                    'If result = Windows.Forms.DialogResult.OK Then


                    For Each row_reporte As DataRow In dtDatosReportes.Select("fecha = '" & FechaSQL(dtiFechaAutorizacion.Value) & "'")
                        'ABRAHAM CASAS BITACORA TIEMPO EXTRA 20180925
                        Dim dtMasReciente As DataTable = sqlExecute("select * from bitacora_te where reloj = '" & row_reporte("reloj") & "' and fecha = '" & FechaSQL(row_reporte("fecha")) & "' order by fecha_hora desc", "ta")
                        If dtMasReciente.Rows.Count > 0 Then
                            Dim _orden As Integer = dtMasReciente.Rows(0)("orden")
                            'sqlExecute("update bitacora_te set enviado = getdate() where reloj = '" & row_reporte("reloj") & "' and fecha = '" & FechaSQL(row_reporte("fecha")) & "' and orden = '" & _orden & "'", "TA")
                            sqlExecute("update bitacora_te set enviado = getdate(), hora_desde = '" & txtHoraDesde.Text & "', hora_hasta = '" & txtHoraHasta.Text & "', comentarios = '" & txtComentarios.Text & "' where reloj = '" & row_reporte("reloj") & "' and fecha = '" & FechaSQL(row_reporte("fecha")) & "' and orden = '" & _orden & "'", "TA")
                        End If
                    Next

                    'End If
                    'My.Computer.FileSystem.DeleteFile(nombre_archivo)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MessageBox.Show("La fecha seleccionada no contiene tiempo extra para autorizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            End If

        Catch ex As Exception
            ErrorLog("TareaReportes", System.Reflection.MethodBase.GetCurrentMethod.Name(), "Envio correo SMTP", Err.Number, ex.Message)
        End Try


    End Sub
    Public Function EnviarCorreoSMTP(Asunto As String, Mensaje As String, Destinatario As String, CC As String, Archivo As String, Optional Archivo2 As String = "") As Boolean
        Try
            Dim r As New System.Web.Mail.MailMessage
            r.Body = Mensaje
            r.BodyEncoding = System.Text.Encoding.UTF8
            r.BodyFormat = Web.Mail.MailFormat.Html
            r.Subject = Asunto
            r.From = "mxju_pida@brp.local"
            'r.From = "sistema.pida@gmail.com"
            If Archivo.Trim <> "" Then
                r.Attachments.Add(New System.Web.Mail.MailAttachment(Archivo))
            End If

            If Not Archivo2.Equals("") Then
                r.Attachments.Add(New System.Web.Mail.MailAttachment(Archivo2))
            End If

            r.Fields("http://schemas.microsoft.com/cdo/configuration/smtsperver") = "smtp-mxqt.brp.local"
            r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = "25"
            r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
            r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
            r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "svc_mxju_smtp_pida@brp.local"
            r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "PW4P!d@$"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtsperver") = "smtp.gmail.com"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 465
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpusessl") = True
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "sistema.pida@gmail.com"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "Resultados1"
            r.To() = Destinatario
            If CC.Trim <> "" Then
                r.Cc = CC
            End If

            System.Web.Mail.SmtpMail.SmtpServer = "smtp-mxqt.brp.local"
            'System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com"
            'System.Web.Mail.SmtpMail.SmtpServer = "smtp.pida.com.mx"
            'MessageBox.Show(Asunto + vbCrLf + Destino + vbCrLf + Archivo + vbCrLf + Archivo2 + vbCrLf + Mensaje)
            System.Web.Mail.SmtpMail.Send(r)
            Return True
        Catch ex As Exception
            ErrorLog("TareaReportes", System.Reflection.MethodBase.GetCurrentMethod.Name(), "Envio correo SMTP", Err.Number, ex.Message)
            Return False
        End Try
    End Function
    Private Sub frmCondicionesReporteTextra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtiFechaAutorizacion.MonthCalendar.TodayButton.Text = "Hoy"
        dtiFechaAutorizacion.MonthCalendar.DayNames = {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"}
        dtiFechaAutorizacion.MonthCalendar.YearSelectionEnabled = False

        dtiFechaAutorizacion.MinDate = fini
        dtiFechaAutorizacion.MaxDate = ffin
        dtiFechaAutorizacion.Value = fini

        txtComentarios.Focus()

    End Sub

    Private Sub txtHoraDesde_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtHoraDesde.Validating
        Try
            txtHoraDesde.Text = MerMilitar(CtoH(txtHoraDesde.Text))
        Catch ex As Exception
            txtHoraDesde.Text = "**:**"
        End Try
    End Sub

    Private Sub txtHoraHasta_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtHoraHasta.Validating
        Try
            txtHoraHasta.Text = MerMilitar(CtoH(txtHoraHasta.Text))
        Catch ex As Exception
            txtHoraHasta.Text = "**:**"
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class