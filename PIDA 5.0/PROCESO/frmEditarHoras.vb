Public Class frmEditarHoras

    Dim Reloj As String
    Dim anio As String
    Dim per As String
    Dim dtAjustes As New DataTable
    Dim dtConcHorasPro As New DataTable
    Dim drAjHrsPro As DataRow
    Dim concepto As String
    Dim descripcion As String
    Dim monto As Double
    Dim comentario As String
    Dim Nuevo As Boolean
    Dim valAnt As Double = 0.0

    Private Sub frmEditarHoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try
            Reloj = frmIndivTest.txtReloj.Text.Trim
            anio = frmIndivTest.lblAnioPer.Text.Trim.Substring(0, 4)
            per = frmIndivTest.lblAnioPer.Text.Trim.Substring(7, 2)

            '--Cargar conceptos
            dtConcHorasPro = sqlExecute("select * from conc_horas_pro", "NOMINA")
            If (Not dtConcHorasPro.Columns.Contains("Error") And dtConcHorasPro.Rows.Count > 0) Then
                cmbConcepto.DataSource = dtConcHorasPro
                cmbConcepto.ValueMember = "concepto"
            End If

            dtAjustes = sqlExecute("SELECT * from horas_pro where reloj='" & Reloj & "' and concepto='" & CalcIndivKey & "'", "NOMINA")

            If (dtAjustes.Columns.Contains("Error") Or dtAjustes.Rows.Count <= 0) Then
                '---Agregar nuevo concepto
                Nuevo = True
                cmbConcepto.Enabled = True
                cmbConcepto.SelectedIndex = 0

                Dim drowDescrip As DataRow = Nothing
                Try : drowDescrip = dtConcHorasPro.Select("concepto ='" & cmbConcepto.SelectedValue & "'")(0) : Catch ex As Exception : drowDescrip = Nothing : End Try
                If (Not IsNothing(drowDescrip)) Then txtDescripcion.Text = drowDescrip("descripcion").ToString.Trim

                txtMonto.Value = 0.0
                txtComentario.Text = ""
                cmbConcepto.Focus()

            Else
                '---Editar el existente
                Nuevo = False
                cmbConcepto.Enabled = False
                drAjHrsPro = dtAjustes.Rows(0)
                Try : concepto = drAjHrsPro("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                Try : descripcion = drAjHrsPro("descripcion").ToString.Trim : Catch ex As Exception : descripcion = "" : End Try
                Try : monto = Double.Parse(drAjHrsPro("monto")) : Catch ex As Exception : monto = 0.0 : End Try
                valAnt = monto
                Try : comentario = drAjHrsPro("comentario").ToString.Trim : Catch ex As Exception : comentario = "" : End Try

                cmbConcepto.SelectedValue = concepto
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

    Private Sub frmEditarHoras_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            If (txtMonto.Value <= 0) Then
                MessageBox.Show("El monto es inválido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMonto.Focus()
                Exit Sub
            End If


            If (cmbConcepto.Text = "") Then
                MessageBox.Show("El concepto es inválido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbConcepto.Focus()
                Exit Sub
            End If
            Dim cadena As String = ""
            Dim TipoMov As String = ""

            If (Nuevo) Then 'Nuevo registro
                '--Antes de insertarlo, validar que ese concepto no exista previamente ya para ese empleado
                Dim dtExistConcep As DataTable = sqlExecute("select * from horas_pro where reloj='" & Reloj & "' and concepto='" & cmbConcepto.SelectedValue & "'", "NOMINA")
                If (Not dtExistConcep.Columns.Contains("Error") And dtExistConcep.Rows.Count > 0) Then
                    MessageBox.Show("El concepto: '" & cmbConcepto.SelectedValue & "' no se puede agregar ya que existe capturado para este empleado, favor de modificar el existente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    Dim QI As String = "insert into horas_pro (ano,periodo,reloj,cod_hora,concepto,descripcion,monto,factor,usuario,fec_hora_registro,comentario) " & _
                        "VALUES ('" & anio & "','" & per & "','" & Reloj & "','1','" & cmbConcepto.SelectedValue & "','" & txtDescripcion.Text.Trim & "'," & txtMonto.Value & ",0.0000,'" & Usuario & "',Getdate(),'" & txtComentario.Text.Trim & "')"
                    sqlExecute(QI, "NOMINA")
                End If


            Else ' Editar  concepto existente
                If (valAnt <> txtMonto.Value) Then
                    '--Insertar en bitácora
                    TipoMov = "C"
                    cadena = "INSERT INTO bitacora_nomina (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,anoper) VALUES ('"
                    cadena = cadena & Reloj & "','" & concepto & "','" & valAnt & "','" & txtMonto.Value & "','" & Usuario & "',GETDATE(),'" & TipoMov & "','" & anio & per & "')"
                    sqlExecute(cadena, "NOMINA")

                End If
                sqlExecute("update horas_pro set monto=" & txtMonto.Value & ",comentario='" & txtComentario.Text & "' where reloj='" & Reloj & "' and concepto='" & concepto & "'", "NOMINA")

            End If


            Me.DialogResult = Windows.Forms.DialogResult.OK

        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        End Try
    End Sub

    Private Sub cmbConcepto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbConcepto.SelectedValueChanged
        '-- Actualizar descripcion
        Dim conc As String = cmbConcepto.SelectedValue

        Dim drowDescrip As DataRow = Nothing
        Try : drowDescrip = dtConcHorasPro.Select("concepto ='" & conc & "'")(0) : Catch ex As Exception : drowDescrip = Nothing : End Try
        If (Not IsNothing(drowDescrip)) Then txtDescripcion.Text = drowDescrip("descripcion").ToString.Trim
    End Sub
End Class