Public Class frmEditarMotBaj

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim motivo As String = ""
        Dim dtMotivo As DataTable = sqlExecute("select * from cod_sub_baj where cod_sub_ba = '" & cmbsub.SelectedValue & "'")
        If dtMotivo.Rows.Count > 0 Then
            motivo = dtMotivo.Rows(0)("cod_mot_ba")
        Else
            Throw New Exception("no existe el submotivo " & cmbsub.SelectedValue & "o no tiene relacion con un motivo interno")
        End If

        '***************************************************

        Dim motivo_imss As String = ""
        Dim dtMotivoImss As DataTable = sqlExecute("select * from cod_mot_baj where cod_mot_ba = '" & motivo & "'")
        If dtMotivoImss.Rows.Count > 0 Then
            motivo_imss = dtMotivoImss.Rows(0)("cod_mot_im")
        Else
            Throw New Exception("no existe el motivo " & motivo & " o no tiene relacion con un motivo del IMSS")
        End If



        sqlExecute("update personal set  cod_mot_ba = '" & motivo & "', cod_sub_ba = '" & cmbsub.SelectedValue & "', cod_mot_im = '" & motivo_imss & "' where reloj = '" & reloj_mot_baj & "'")

        'Transferencias desde la baja hacia un empleado existente
        Try
            Dim dtAplica As DataTable = sqlExecute("select reloj, (imss + dig_ver) as imss, cod_comp, alta, baja from personal where reloj = '" & reloj_mot_baj & "' and cod_sub_ba = '006' and baja is not null and cod_comp in ('002')", "personal")
            If dtAplica.Rows.Count > 0 Then

                Dim imss_transferencia As String = dtAplica.Rows(0)("imss")
                Dim cod_comp_transferencia As String = dtAplica.Rows(0)("cod_comp")

                Dim alta_transferencia As Date = dtAplica.Rows(0)("alta")
                Dim baja_transferencia As Date = dtAplica.Rows(0)("baja")

                Dim dtNuevo As DataTable = sqlExecute("select reloj, nombres, alta from personalvw where cod_comp = '610' and imss + dig_ver  = '" & imss_transferencia & "'", "personal")
                If dtNuevo.Rows.Count > 0 Then
                    Dim reloj_nuevo As String = dtNuevo.Rows(0)("reloj")
                    Dim nombres_nuevo As String = dtNuevo.Rows(0)("nombres")
                    Dim alta_nuevo As Date = dtNuevo.Rows(0)("alta")

                    Dim dtexiste As DataTable = sqlExecute("select * from transferencias where reloj_anterior = '" & reloj_mot_baj & "' and reloj_nuevo = '" & reloj_nuevo & "'", "personal")
                    If dtexiste.Rows.Count <= 0 Then

                        If MessageBox.Show("¿Desea marcar como transferencia el empleado " & reloj_mot_baj & " al empleado " & reloj_nuevo & ", " & nombres_nuevo & "", "Transferencia a BRP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            sqlExecute("insert into transferencias (reloj_anterior, cod_comp_anterior, imss, alta_anterior, baja_anterior, reloj_nuevo, cod_comp_nuevo, alta) values (" & _
                                       "'" & Reloj & "', '" & cod_comp_transferencia & "', '" & imss_transferencia & "', '" & FechaSQL(alta_transferencia) & "', '" & FechaSQL(baja_transferencia) & "', '" & reloj_nuevo & "', '610', '" & FechaSQL(alta_nuevo) & "')", "personal")
                        End If


                    End If
                End If


            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
        MessageBox.Show("Se ha actualizado el motivo de baja en la información de personal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmEditarMotBaj_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbsub.DataSource = sqlExecute("select * from cod_sub_baj")
    End Sub
End Class