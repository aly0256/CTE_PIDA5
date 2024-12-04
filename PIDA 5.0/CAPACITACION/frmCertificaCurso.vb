Public Class frmCertificaCurso

    Public nombre_empleado As String = ""
    Public cod_puesto As String = ""
    Public fecha_alta As Date = Nothing
    Private estatus As Integer = 0
    Private existe As Boolean = False

    Private Sub frmCertificaCurso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    '==Corroborar si esta certificado       julio2021       Ernesto
    Private Sub ValidarCertificacion(clock As String, nom As String, alta As String)
        Try
            '==Puesto de empleado
            Dim dtValida As DataTable
            Dim puesto As String = "select RELOJ,rtrim(COD_PUESTO) as cod_puesto,nombre_puesto,baja from personal.dbo.personalvw where RELOJ='" & clock & "'"
            dtValida = sqlExecute(puesto)

            If Not dtValida.Rows(0)("baja") Is DBNull.Value Then
                Label9.BackColor = Color.DarkGray
                Label9.Text = "DADO DE BAJA"
                pnlDatosCertificacion.BackColor = Color.Silver
                btnCertificar.Enabled = False
            Else
                Try : puesto = dtValida.Rows(0)("cod_puesto").ToString : Catch ex As Exception : puesto = "" : End Try

                '==Si esta certificado
                Dim valida As String = "select * from capacitacion.dbo.certi where reloj='" & clock & "' and nombres='" & nom & "' and alta='" & alta & "' and cod_puesto='" & puesto & "' and aprobado='1'"
                dtValida = sqlExecute(valida)

                If dtValida.Rows.Count > 0 Then
                    Label9.BackColor = Color.DarkGreen
                    Label9.Text = "ESTATUS: CERTIFICADO"
                    pnlDatosCertificacion.BackColor = Color.Green
                    estatus = 1
                Else
                    valida = "select reloj,alta,DATEDIFF(MONTH,ALTA,GETDATE()) as dif_meses from personal.dbo.personal where reloj='" & clock & "'"
                    dtValida = sqlExecute(valida)

                    If dtValida.Rows(0)("dif_meses") >= 3 Then
                        Label9.BackColor = Color.DarkRed
                        Label9.Text = "ESTATUS: VENCIDO"
                        pnlDatosCertificacion.BackColor = Color.IndianRed
                        estatus = 0
                    Else
                        Label9.BackColor = Color.Goldenrod
                        Label9.Text = "ESTATUS: EN TIEMPO"
                        pnlDatosCertificacion.BackColor = Color.Gold
                        estatus = 0
                    End If
                End If
            End If
            BotonCertificacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub MostrarInfo()
        Try
            ValidarCertificacion(txtReloj.Text.ToString.Trim, nombre_empleado, FechaSQL(fecha_alta))
            Dim query As String = "select RELOJ,NOMBRES,COD_PUESTO,ALTA,INICIO from CAPACITACION.DBO.certi where aprobado='1'"
            Dim dtCertificados As DataTable = sqlExecute(query)
            lblCerti.Text = "--"
            If dtCertificados.Rows.Count > 0 Then
                For Each x As DataRow In dtCertificados.Select("reloj='" & txtReloj.Text.ToString.Trim & "'")
                    lblCerti.Text = FechaSQL(x.Item("inicio"))
                Next
            End If
            dgCursosEmp.DataSource = dtCertificados
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCertificar_Click(sender As Object, e As EventArgs) Handles btnCertificar.Click
        Try
            Dim query As String = "" : Dim dtValidar As DataTable : Dim f_inicio As String = ""

            '==Si no esta certificado
            If estatus < 1 Then
                If MessageBox.Show("Desea certificar al empleado: " & nombre_empleado & ", con número de reloj: " & txtReloj.Text & "?",
                         "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                    '==Revisa si ya existe en la bd de certificaciones
                    query = "select * from capacitacion.dbo.certi where reloj='" & txtReloj.Text.ToString.Trim & "' and cod_puesto='" & cod_puesto & "' and aprobado='0'"
                    dtValidar = sqlExecute(query)

                    If dtValidar.Rows.Count > 0 Then
                        existe = True
                        f_inicio = FechaSQL(dtValidar.Rows(0)("inicio"))
                    Else
                        existe = False
                    End If

                    If existe Then
                        query = "update capacitacion.dbo.certi set aprobado='1' where reloj='" & txtReloj.Text.ToString.Trim & "' and cod_puesto='" & cod_puesto & "' and inicio='" & f_inicio & "'"
                        sqlExecute(query)
                    Else
                        query = "insert into CAPACITACION.dbo.certi (RELOJ,NOMBRES,COD_PUESTO,ALTA,APROBADO,COD_CURSO,INICIO) " & _
                                                  "values ('" & txtReloj.Text & "'," & _
                                                  "'" & nombre_empleado & "'," & _
                                                  "'" & cod_puesto & "'," & _
                                                  "'" & FechaSQL(fecha_alta) & "'," & _
                                                  "" & "'1','1',getdate())"
                        sqlExecute(query, "CAPACITACION")
                        existe = False
                    End If

                    MostrarInfo()
                    dgCursosEmp.Refresh()

                Else
                    Exit Sub
                End If
            Else        '==Quitar certificacion
                If MessageBox.Show("Desea eliminar la certificación al empleado: " & nombre_empleado & ", con número de reloj: " & txtReloj.Text & "?",
                         "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then

                    query = "update CAPACITACION.dbo.certi set APROBADO='0' where  RELOJ='" & txtReloj.Text.ToString.Trim & "' " & _
                        "and NOMBRES='" & nombre_empleado & "' and COD_PUESTO='" & cod_puesto & "' and INICIO='" & lblCerti.Text & "'"

                    sqlExecute(query)
                    MostrarInfo()
                    dgCursosEmp.Refresh()
                Else
                    Exit Sub
                End If
            End If
         
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante la certificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub BotonCertificacion()
        If estatus = 1 Then
            btnCertificar.Text = "Quitar certificación"
        Else
            btnCertificar.Text = "Certificar"
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs)

    End Sub
End Class