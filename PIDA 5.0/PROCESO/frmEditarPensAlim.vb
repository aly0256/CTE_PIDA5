Public Class frmEditarPensAlim
    Dim Reloj As String
    Dim anio As String
    Dim per As String
    Dim dtAjustes As New DataTable
    Dim dtPensiones As New DataTable
    Dim drAjPens As DataRow
    Dim apaterno As String
    Dim amaterno As String
    Dim nombre As String
    Dim porc As Double
    Dim cf As Double
    Dim inter As Integer
    Dim no_cuenta As String
    Dim pension As Integer
    Dim Nuevo As Boolean
    Dim valAnt As Double = 0.0


    Private Sub frmEditarPensAlim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Reloj = frmIndivTest.txtReloj.Text.Trim
            anio = frmIndivTest.lblAnioPer.Text.Trim.Substring(0, 4)
            per = frmIndivTest.lblAnioPer.Text.Trim.Substring(7, 2)

            '-- Cargar pensiones
            dtAjustes = sqlExecute("select * from ctas_pens_alim where id=" & CalcIndivKey & " and reloj='" & Reloj & "' ORDER by pension asc", "PERSONAL")

            If (dtAjustes.Columns.Contains("Error") Or dtAjustes.Rows.Count <= 0 Or frmIndivTest.AddNewPensAlim) Then
                '------Agregar nueva pensión
                Nuevo = True

                txtAPatPensAlim.Text = ""
                txtApMatPensAlim.Text = ""
                txtNombresPensAlim.Text = ""
                txtPorc.Value = 0.0
                chkInter.Checked = False
                lblCta_Clabe_pensAlim.Text = "Cuenta"
                txtNoCuenta.Text = ""
                chkPAPorc.Checked = True
                txtAPatPensAlim.Focus()

            Else
                '------Editar pensión seleccionada
                Nuevo = False
                drAjPens = dtAjustes.Rows(0)
                Try : apaterno = drAjPens("apaterno").ToString.Trim : Catch ex As Exception : apaterno = "" : End Try
                Try : amaterno = drAjPens("amaterno").ToString.Trim : Catch ex As Exception : amaterno = "" : End Try
                Try : nombre = drAjPens("nombre").ToString.Trim : Catch ex As Exception : nombre = "" : End Try
                Try : no_cuenta = drAjPens("no_cuenta").ToString.Trim : Catch ex As Exception : no_cuenta = "" : End Try
                Try : pension = Integer.Parse(drAjPens("pension")) : Catch ex As Exception : pension = 0 : End Try
                Try : inter = Integer.Parse(drAjPens("inter")) : Catch ex As Exception : inter = 0 : End Try
                Try : porc = Double.Parse(drAjPens("porc")) : Catch ex As Exception : porc = 0.0 : End Try
                Try : cf = Double.Parse(drAjPens("cf")) : Catch ex As Exception : cf = 0.0 : End Try

                If (porc > 0) Then
                    chkPAPorc.Checked = True
                    chkPACFija.Checked = False
                    valAnt = porc
                    txtPorc.Value = porc
                End If

                If (cf > 0) Then
                    chkPAPorc.Checked = False
                    chkPACFija.Checked = True
                    valAnt = cf
                    txtPorc.Value = cf
                End If

                '  valAnt = porc

                txtAPatPensAlim.Text = apaterno
                txtApMatPensAlim.Text = amaterno
                txtNombresPensAlim.Text = nombre
                '   txtPorc.Value = porc

                If (inter = 1) Then
                    chkInter.Checked = True
                    lblCta_Clabe_pensAlim.Text = "Clabe:"
                Else
                    chkInter.Checked = False
                    lblCta_Clabe_pensAlim.Text = "Cuenta:"
                End If
                txtNoCuenta.Text = no_cuenta

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmEditarPensAlim_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If (txtNoCuenta.Text = "") Then
                MessageBox.Show("El número de cuenta está vacío. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNoCuenta.Focus()
                Exit Sub
            End If

            If (txtPorc.Value <= 0) Then
                MessageBox.Show("El valor de descuento es inválido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPorc.Focus()
                Exit Sub
            End If

            Dim cadena As String = ""
            Dim TipoMov As String = ""

            If (Nuevo) Then
                '---Agregar nueva pensión
                '---1 - Validar que lo que se esté agregando no exista
                Dim dtExistCuenta As DataTable = sqlExecute("select * from ctas_pens_alim where reloj='" & Reloj & "' and no_cuenta='" & txtNoCuenta.Text.Trim & "'", "PERSONAL")
                If (Not dtExistCuenta.Columns.Contains("Error") And dtExistCuenta.Rows.Count > 0) Then
                    MessageBox.Show("La cuenta: '" & txtNoCuenta.Text.Trim & "' no se puede agregar ya que existe capturada para este empleado, favor de modificar el registro con la cuenta existente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    '--Encontrar que No. Pension sería
                    Dim dtNoPens As DataTable = sqlExecute("select top 1 pension from ctas_pens_alim where reloj='" & Reloj & "' order by pension desc", "PERSONAL")
                    If (Not dtNoPens.Columns.Contains("Error") And dtNoPens.Rows.Count > 0) Then
                        Try : pension = Integer.Parse(dtNoPens.Rows(0).Item("pension")) : Catch ex As Exception : pension = 0 : End Try
                        pension += 1
                    Else
                        pension = 1
                    End If

                    If (chkInter.Checked = True) Then inter = 1 Else inter = 0

                    Dim QI As String = ""

                    If (chkPAPorc.Checked) Then '--Porcentaje
                        QI = "insert into ctas_pens_alim values ('" & Reloj & "','" & txtAPatPensAlim.Text.Trim & "','" & txtApMatPensAlim.Text.Trim & "','" & txtNombresPensAlim.Text.Trim & "','" & txtNoCuenta.Text.Trim & "'," & pension & "," & inter & "," & txtPorc.Value & ",0)"
                    End If

                    If (chkPACFija.Checked) Then '---Cuota Fija
                        QI = "insert into ctas_pens_alim values ('" & Reloj & "','" & txtAPatPensAlim.Text.Trim & "','" & txtApMatPensAlim.Text.Trim & "','" & txtNombresPensAlim.Text.Trim & "','" & txtNoCuenta.Text.Trim & "'," & pension & "," & inter & ",0," & txtPorc.Value & ")"
                    End If

                    sqlExecute(QI, "PERSONAL")

                End If
            Else
                '---Editar registro

                If (valAnt <> txtPorc.Value) Then
                    Dim campo As String = "porcentaje_pension"
                    '--Insertar en bitácora
                    TipoMov = "C"
                    cadena = "INSERT INTO bitacora_nomina (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,anoper) VALUES ('"
                    cadena = cadena & Reloj & "','" & campo & "','" & valAnt & "','" & txtPorc.Value & "','" & Usuario & "',GETDATE(),'" & TipoMov & "','" & anio & per & "')"
                    sqlExecute(cadena, "NOMINA")

                End If
                If (chkInter.Checked = True) Then inter = 1 Else inter = 0
                Dim QUpPensAlim As String = ""
                If (chkPAPorc.Checked) Then '--Porcentaje
                    QUpPensAlim = "update ctas_pens_alim set apaterno='" & txtAPatPensAlim.Text.Trim & "', amaterno='" & txtApMatPensAlim.Text.Trim & "', nombre='" & txtNombresPensAlim.Text.Trim & "',no_cuenta='" & txtNoCuenta.Text.Trim & "',inter=" & inter & ",porc=" & txtPorc.Value & ",cf=0 where id=" & CalcIndivKey & " and reloj='" & Reloj & "'"
                End If
                If (chkPACFija.Checked) Then '---Cuota Fija
                    QUpPensAlim = "update ctas_pens_alim set apaterno='" & txtAPatPensAlim.Text.Trim & "', amaterno='" & txtApMatPensAlim.Text.Trim & "', nombre='" & txtNombresPensAlim.Text.Trim & "',no_cuenta='" & txtNoCuenta.Text.Trim & "',inter=" & inter & ",porc=0 ,cf=" & txtPorc.Value & " where id=" & CalcIndivKey & " and reloj='" & Reloj & "'"
                End If

                sqlExecute(QUpPensAlim, "PERSONAL")

            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        End Try
    End Sub

    Private Sub chkInter_CheckedChanged(sender As Object, e As EventArgs) Handles chkInter.CheckedChanged
        If (chkInter.Checked = True) Then
            lblCta_Clabe_pensAlim.Text = "Clabe:"
            txtNoCuenta.MaxLength = 18
        Else
            lblCta_Clabe_pensAlim.Text = "Cuenta:"
            txtNoCuenta.MaxLength = 11
        End If
    End Sub

    Private Sub chkPAPorc_CheckStateChanged(sender As Object, e As EventArgs) Handles chkPAPorc.CheckStateChanged
        If (chkPAPorc.Checked) Then
            chkPACFija.Checked = False
            Label3.Text = "Porcentaje"
            Label4.Visible = True
        End If

        If (chkPAPorc.Checked = False) Then
            chkPACFija.Checked = True
        End If
    End Sub

    Private Sub chkPACFija_CheckStateChanged(sender As Object, e As EventArgs) Handles chkPACFija.CheckStateChanged
        If (chkPACFija.Checked) Then
            chkPAPorc.Checked = False
            Label3.Text = "C.Fija"
            Label4.Visible = False
        End If

        If (chkPACFija.Checked = False) Then
            chkPAPorc.Checked = True
        End If
    End Sub
End Class