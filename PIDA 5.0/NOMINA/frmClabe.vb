Imports System.ComponentModel
Imports System.Text
Imports DevComponents.DotNetBar.Keyboard
Imports DevComponents.DotNetBar.Metro
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Deployment.Application
Imports System.IO
Public Class frmClabe
    Dim iterador As Integer
    Dim iteradortemp As Integer
    Dim value As Integer = CInt(Int((3 * Rnd()) + 1))
    Dim Clave1 As Boolean
    Dim ClaveFecha As String
    Dim OrdenClaveFecha(2) As String
    Private Sub frmClabe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetVisibleCore(False)
        Me.SetVisibleCore(True)
        kbTeclado.Keyboard = CreateNumericKeyboard()
        txtCLABE.Text = ""
        txtConfirma.Text = ""
    End Sub
    Private Function CreateNumericKeyboard() As Keyboard
        Dim keyboard As New Keyboard()
        Dim klNumLockOn As New LinearKeyboardLayout()
        klNumLockOn.AddKey("7")
        klNumLockOn.AddKey("8")
        klNumLockOn.AddKey("9")
        klNumLockOn.AddLine()
        klNumLockOn.AddKey("4")
        klNumLockOn.AddKey("5")
        klNumLockOn.AddKey("6")
        klNumLockOn.AddLine()
        klNumLockOn.AddKey("1")
        klNumLockOn.AddKey("2")
        klNumLockOn.AddKey("3")
        klNumLockOn.AddLine()
        klNumLockOn.AddKey("0", width:=21)
        klNumLockOn.AddKey("Back", "{BACKSPACE}", style:=KeyStyle.Dark)
        Dim klNumLockOff As New LinearKeyboardLayout()
        keyboard.Layouts.Add(klNumLockOn)
        keyboard.Layouts.Add(klNumLockOff)
        Return keyboard
    End Function
    Private Sub kbTeclado_KeySent(sender As Object, e As KeyboardKeyEventArgs) Handles kbTeclado.KeySent
        IntroducirTecla(e.Key)
    End Sub
    Private Sub IntroducirTecla(ByVal tecla As String)
        btnAceptar.Focus()
        If tecla = "{BACKSPACE}" Then
            If txtConfirma.Text.Length = 0 Then
                txtCLABE.Focus()
                txtCLABE.PasswordChar = Nothing
                ApuntarClabe.Visible = True
                ApuntaCOnfirma.Visible = False
                ' txtCLABE.Text = txtCLABE.Text & tecla
            Else
                txtConfirma.Focus()
                ApuntarClabe.Visible = False
                ApuntaCOnfirma.Visible = True
            End If
        Else
            If txtCLABE.Text.Length < 18 Then
                txtCLABE.Focus()
                ApuntarClabe.Visible = True
                ApuntaCOnfirma.Visible = False
                ' txtCLABE.Text = txtCLABE.Text & tecla
            Else
                txtConfirma.Focus()
                txtCLABE.PasswordChar = "•"
                ApuntarClabe.Visible = False
                ApuntaCOnfirma.Visible = True
            End If
        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If txtCLABE.Text = txtConfirma.Text Then
            Dim dtclabe As DataTable = sqlExecute("select * from personal.dbo.personalvw where reloj = '" & RelojClabe.PadLeft(6, "0") & "'")

            If dtclabe.Rows.Count > 0 Then

                If dtclabe.Rows(0).Item("tipo_pago") = "D" Then
                    Dim clabe = Trim(txtCLABE.Text)
                    If clabe = Trim(dtclabe.Rows(0).Item("CLABE")) Then
                        CLABE_fah = txtConfirma.Text
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    Else
                        MessageBox.Show("Tu CLABE es incorrecta, vuelve a intentarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCLABE.Text = ""
                        txtConfirma.Text = ""
                        txtCLABE.Focus()
                    End If
                ElseIf dtclabe.Rows(0).Item("tipo_pago") = "B" Then
                    Dim clabe = txtCLABE.Text.Substring(6, 11)
                    If clabe = Trim(dtclabe.Rows(0).Item("CUENTA_BANCO")).ToString.PadLeft(11, "0") Then
                        CLABE_fah = txtConfirma.Text
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    Else
                        MessageBox.Show("Tu CLABE es incorrecta, vuelve a intentarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCLABE.Text = ""
                        txtConfirma.Text = ""
                        txtCLABE.Focus()
                    End If
                Else
                    Dim clabe = txtCLABE.Text.Substring(6, 11)
                    If clabe = Trim(dtclabe.Rows(0).Item("CUENTA_BANCO")).ToString.PadLeft(11, "0") Then
                        CLABE_fah = txtConfirma.Text
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    Else
                        MessageBox.Show("Tu CLABE es incorrecta, vuelve a intentarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCLABE.Text = ""
                        txtConfirma.Text = ""
                        txtCLABE.Focus()
                    End If
                End If




            Else
                MessageBox.Show("No es posible validar tu numero de CLABE. Favor de comunicarse a la ext. 4747", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            MessageBox.Show("Las CLABES no coinciden, revisa tu información", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click
        txtCLABE.Text = ""
        txtConfirma.Text = ""
        txtCLABE.Focus()
    End Sub

End Class