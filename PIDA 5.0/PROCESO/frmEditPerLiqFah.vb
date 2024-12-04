Public Class frmEditPerLiqFah

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

    Private Sub frmEditPerLiqFah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '----Add concepto nuevo
            Nuevo = True
            txtAnioInic.Text = ""
            txtPerInic.Text = ""
            txtAnioFin.Text = ""
            txtPerFin.Text = ""
            txtAnioAplica.Text = ""
            txtComentario.Text = ""
            txtAnioInic.Focus()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim Msj As String = ValCamposVacios(txtAnioInic.Text, "Año inicial", txtPerInic.Text, "Periodo Inicial", txtAnioFin.Text, "Año final", txtPerFin.Text, "Periodo fin", txtAnioAplica.Text, "Año aplicar")

            If (Msj.Trim = "") Then

            Else
                MessageBox.Show("Favor de capturar: " & vbCrLf & Msj, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If (Nuevo) Then ' Nuevo registro
                '--Validar si ya existe dicho registro
                Dim QExist As String = "select * from config_per_liqfah where anio_liq='" & txtAnioAplica.Text.Trim & "'"
                Dim dtExistPer As DataTable = sqlExecute(QExist, "NOMINA")
                If (Not dtExistPer.Columns.Contains("Error") And dtExistPer.Rows.Count > 0) Then
                    MessageBox.Show("El registro que intenta registrar ya está dado de alta para el año dado:'" & txtAnioAplica.Text.Trim & "'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtAnioAplica.Focus()
                Else
                    '-- Hacer el insert
                    Dim QInsert As String = "insert into config_per_liqfah (anio_ini,per_ini,anio_fin,per_fin,anio_liq,activo,coment) values" & _
                        "('" & txtAnioInic.Text & "','" & txtPerInic.Text.PadLeft(2, "0") & "','" & txtAnioFin.Text & "','" & txtPerFin.Text.PadLeft(2, "0") & "','" & txtAnioAplica.Text & "',0,'" & txtComentario.Text & "')"
                    sqlExecute(QInsert, "NOMINA")
                End If
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        End Try

    End Sub


End Class