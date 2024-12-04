Public Class frmRecertificaCurso

    Public nombre_empleado As String = ""
    Public cod_puesto As String = ""
    Public fecha_alta As Date = Nothing
    Private estatus As Integer = 0
    Private existe As Boolean = False

    Private Sub frmRecertificaCurso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            lblNombre.Text = nombre_empleado
            lblAlta.Text = FechaSQL(fecha_alta)
            MostrarInfo()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub MostrarInfo()
        Try
            ValidarRecertificacion(txtReloj.Text.ToString.Trim, nombre_empleado, FechaSQL(fecha_alta))
            Dim query As String = "select RELOJ,NOMBRES,COD_PUESTO,ALTA,INICIO_RECERTI as 'INICIO' from CAPACITACION.DBO.certi where aprobado='1' and recerti=1"
            Dim dtCertificados As DataTable = sqlExecute(query)
            lblCerti.Text = "--"
            If dtCertificados.Rows.Count > 0 Then
                For Each x As DataRow In dtCertificados.Select("reloj='" & txtReloj.Text.ToString.Trim & "'")
                    Dim fecha_recerti As String = ""
                    fecha_recerti = FechaSQL(x.Item("INICIO"))
                    If fecha_recerti <> "" Then
                        lblCerti.Text = fecha_recerti
                        GoTo final
                    End If
                Next
            End If
final:
            dgCursosEmp.DataSource = dtCertificados
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub ValidarRecertificacion(clock As String, nom As String, alta As String)

        Dim recerti As Integer = 0, fecha_certificacion As Date, diaHoy As Date = Date.Now()
        Try
            '==Puesto de empleado
            Dim dtValida As DataTable
            Dim puesto As String = "select RELOJ,rtrim(COD_PUESTO) as cod_puesto,nombre_puesto,baja from personal.dbo.personalvw where RELOJ='" & clock & "'"
            dtValida = sqlExecute(puesto)

            If Not dtValida.Rows(0)("baja") Is DBNull.Value Then
                Label9.BackColor = Color.DarkGray
                Label9.Text = "DADO DE BAJA"
                pnlDatosCertificacion.BackColor = Color.Silver
                btnReCertificar.Enabled = False
            Else
                Try : puesto = dtValida.Rows(0)("cod_puesto").ToString : Catch ex As Exception : puesto = "" : End Try

                cod_puesto = puesto

                '==Si esta rE-certificado
                Dim valida As String = "select * from capacitacion.dbo.certi where reloj='" & clock & "' and nombres='" & nom & "' and alta='" & alta & "' and cod_puesto='" & puesto & "' and aprobado='1'"
                dtValida = sqlExecute(valida)

                If dtValida.Rows.Count > 0 Then
                    'lblRecertif.Visible = True
                    'pnlRecertifica.Visible = True
                    'btnRecertif.Visible = True

                    Try : recerti = (dtValida.Rows(0).Item("recerti")) : Catch ex As Exception : recerti = 0 : End Try
                    Try : fecha_certificacion = Date.Parse(FechaSQL((dtValida.Rows(0).Item("inicio")))) : Catch ex As Exception : fecha_certificacion = Nothing : End Try

                    If (recerti = 1) Then '1-- Validar si ya está recertificado (recerti=1)
                        Label9.BackColor = Color.DarkGreen
                        Label9.Text = "RE-CERTIFICADO"
                        pnlDatosCertificacion.BackColor = Color.Green
                        estatus = 1
                    Else
                        '2-- Si no esta recertif, en base a su fecha de certif (inicio), validar que tenga <=12 para estar a tiempo (amarillo)
                        Dim difDias As Integer = DateDiff(DateInterval.Day, fecha_certificacion, diaHoy) + 1
                        If difDias <= 365 Then
                            Label9.BackColor = Color.Goldenrod
                            Label9.Text = "EN TIEMPO"
                            pnlDatosCertificacion.BackColor = Color.Gold
                            estatus = 0
                        Else '3-- Si es > 12 meses, mostrar que ya esta VENCIDO (color Rojo)
                            Label9.BackColor = Color.DarkRed
                            Label9.Text = "VENCIDO"
                            pnlDatosCertificacion.BackColor = Color.IndianRed
                            estatus = 0
                        End If

                    End If

                Else
                    estatus = 0
                    '4-- Si  dtValida.Rows.Count <=0, no mostrar el boton de recertif ya que debe de estar primero certificado
                    'lblRecertif.Visible = False
                    'pnlRecertifica.Visible = False
                    'btnRecertif.Visible = False
                End If
            End If
            BotonReCertificacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub BotonReCertificacion()
        If estatus = 1 Then
            btnReCertificar.Text = "Quitar Re-certificación"
        Else
            btnReCertificar.Text = "Re-Certificar"
        End If
    End Sub


    Private Sub btnReCertificar_Click(sender As Object, e As EventArgs) Handles btnReCertificar.Click
        Dim query As String = "" : Dim dtValidar As DataTable : Dim f_inicio As String = ""
        Try
            If estatus <= 0 Then ' == No está Recertificado
                If MessageBox.Show("Desea re-certificar al empleado: " & nombre_empleado & ", con número de reloj: " & txtReloj.Text & "?",
                       "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                    '== Revisar si ya está recertificado
                    query = "select * from capacitacion.dbo.certi where reloj='" & txtReloj.Text.ToString.Trim & "' and cod_puesto='" & cod_puesto & "' and isnull(recerti,0)=0"
                    dtValidar = sqlExecute(query)
                    If Not dtValidar.Columns.Contains("Error") And dtValidar.Rows.Count > 0 Then
                        existe = True
                        Try : f_inicio = FechaSQL(dtValidar.Rows(0)("inicio")) : Catch Ex As Exception : f_inicio = "" : End Try

                    Else
                        existe = False
                    End If

                    If existe Then ' Hacer el update de que esta Recertificado
                        query = "update capacitacion.dbo.certi set recerti=1,inicio_recerti=getdate() where reloj='" & txtReloj.Text.Trim & "' and cod_puesto='" & cod_puesto & "' and inicio='" & f_inicio & "'"
                        sqlExecute(query)
                    End If
                    MostrarInfo()
                    dgCursosEmp.Refresh()
                Else
                    Exit Sub
                End If

            Else ' == Ya está Recertificado, Quitar Recertificación

                If MessageBox.Show("Desea eliminar la re-certificación al empleado: " & nombre_empleado & ", con número de reloj: " & txtReloj.Text & "?",
                        "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
                    query = "update CAPACITACION.dbo.certi set recerti=0,INICIO_RECERTI=null where reloj='" & txtReloj.Text.Trim & "' and cod_puesto='" & cod_puesto & "' and inicio_recerti='" & lblCerti.Text & "'"

                    sqlExecute(query)
                    MostrarInfo()
                    dgCursosEmp.Refresh()
                Else
                    Exit Sub
                End If


            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la Re-certificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class