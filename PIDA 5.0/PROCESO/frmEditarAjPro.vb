Public Class frmEditarAjPro

    Dim Reloj As String
    Dim anio As String
    Dim per As String
    Dim dtConcAjustes As New DataTable
    Dim dtAjustesPro As New DataTable
    Dim drAjPro As DataRow
    Dim concepto As String
    Dim descripcion As String
    Dim monto As Double
    Dim saldo As Double
    Dim comentario As String
    Dim Nuevo As Boolean
    Dim valAnt As Double = 0.0

    Private Sub frmEditarAjPro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Reloj = frmIndivTest.txtReloj.Text.Trim
            anio = frmIndivTest.lblAnioPer.Text.Trim.Substring(0, 4)
            per = frmIndivTest.lblAnioPer.Text.Trim.Substring(7, 2)

            '--Cargar conceptos
            dtConcAjustes = sqlExecute("select * from conc_ajustes_pro", "NOMINA")
            If (Not dtConcAjustes.Columns.Contains("Error") And dtConcAjustes.Rows.Count > 0) Then
                cmbConcep.DataSource = dtConcAjustes
                cmbConcep.ValueMember = "concepto"
            End If

            dtAjustesPro = sqlExecute("SELECT * from ajustes_pro where reloj='" & Reloj & "' and concepto='" & CalcIndivKey & "'", "NOMINA")

            If (dtAjustesPro.Columns.Contains("Error") Or dtAjustesPro.Rows.Count <= 0) Then
                '---Agregar nuevo concepto
                Nuevo = True
                cmbConcep.Enabled = True
                cmbConcep.SelectedIndex = 0

                Dim drowDescrip As DataRow = Nothing
                Try : drowDescrip = dtConcAjustes.Select("concepto ='" & cmbConcep.SelectedValue & "'")(0) : Catch ex As Exception : drowDescrip = Nothing : End Try
                If (Not IsNothing(drowDescrip)) Then txtDescripcion.Text = drowDescrip("descrip").ToString.Trim

                txtMonto.Value = 0.0
                txtComentario.Text = ""
                cmbConcep.Focus()

            Else
                '---Editar el existente
                Nuevo = False
                cmbConcep.Enabled = False
                drAjPro = dtAjustesPro.Rows(0)
                Try : concepto = drAjPro("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                Try : descripcion = drAjPro("descrip").ToString.Trim : Catch ex As Exception : descripcion = "" : End Try
                Try : monto = Double.Parse(drAjPro("monto")) : Catch ex As Exception : monto = 0.0 : End Try
                valAnt = monto
                Try : saldo = Double.Parse(drAjPro("saldo")) : Catch ex As Exception : saldo = 0.0 : End Try
                Try : comentario = drAjPro("comentario").ToString.Trim : Catch ex As Exception : comentario = "" : End Try

                cmbConcep.SelectedValue = concepto
                txtDescripcion.Text = descripcion
                txtMonto.Value = monto
                txtComentario.Text = comentario
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmEditarAjPro_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub



    Private Sub cmbConcep_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbConcep.SelectedValueChanged
        '-- Actualizar descripcion
        Dim conc As String = cmbConcep.SelectedValue

        Dim drowDescrip As DataRow = Nothing
        Try : drowDescrip = dtConcAjustes.Select("concepto ='" & conc & "'")(0) : Catch ex As Exception : drowDescrip = Nothing : End Try
        If (Not IsNothing(drowDescrip)) Then txtDescripcion.Text = drowDescrip("descripcion").ToString.Trim
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try
            If (txtMonto.Value <= 0) Then
                MessageBox.Show("El monto es inválido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMonto.Focus()
                Exit Sub
            End If


            If (cmbConcep.Text = "") Then
                MessageBox.Show("El concepto es inválido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbConcep.Focus()
                Exit Sub
            End If

            Dim cadena As String = ""
            Dim TipoMov As String = ""

            If (Nuevo) Then ' Nuevo registro
                Dim dtExiste As DataTable = sqlExecute("select * from ajustes_pro where reloj='" & Reloj & "' and concepto='" & cmbConcep.SelectedValue & "'", "Nomina")
                If (Not dtExiste.Columns.Contains("Error") And dtExiste.Rows.Count > 0) Then
                    MessageBox.Show("El concepto: '" & cmbConcep.SelectedValue & "' no se puede agregar ya que existe capturado para este empleado, favor de modificar el existente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else

                    Dim per_ded As String = ""
                    Dim saldo As Double = 0.0
                    Dim dtPerDed As DataTable = sqlExecute("select COD_NATURALEZA from conceptos where CONCEPTO='" & cmbConcep.SelectedValue & "'", "NOMINA")    '--Encontrar si es P o D
                    If (Not dtPerDed.Columns.Contains("Error") And dtPerDed.Rows.Count > 0) Then Try : per_ded = dtPerDed.Rows(0).Item("COD_NATURALEZA").ToString.Trim : Catch ex As Exception : per_ded = "" : End Try

                    Dim QI As String = "insert into ajustes_pro (ano,periodo,reloj,per_ded,concepto,descrip,monto,origen,saldo,comentario) " & _
                        "VALUES ('" & anio & "','" & per & "','" & Reloj & "','" & per_ded & "','" & cmbConcep.SelectedValue & "','" & txtDescripcion.Text.Trim & "'," & txtMonto.Value & ",'" & Usuario & "'," & saldo & ",'" & txtComentario.Text.Trim & "')"
                    sqlExecute(QI, "NOMINA")
                End If

            Else '-- Editar registro

                If (valAnt <> txtMonto.Value) Then
                    '--Insertar en bitácora
                    TipoMov = "C"
                    cadena = "INSERT INTO bitacora_nomina (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,anoper) VALUES ('"
                    cadena = cadena & Reloj & "','" & concepto & "','" & valAnt & "','" & txtMonto.Value & "','" & Usuario & "',GETDATE(),'" & TipoMov & "','" & anio & per & "')"
                    sqlExecute(cadena, "NOMINA")

                End If

                Dim QUp As String = "update ajustes_pro set monto=" & txtMonto.Value & ",origen='" & Usuario & "',comentario='" & txtComentario.Text & "' where reloj='" & Reloj & "' and concepto='" & concepto & "'"
                sqlExecute(QUp, "NOMINA")
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        End Try
    End Sub
End Class