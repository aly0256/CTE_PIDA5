﻿Public Class frmOrdenIdeas
    Dim dtCampos As New DataTable
    Dim Acumulado As String


    Private Sub frmOrden_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Acumulado = OrdenAcumulado()

        dtCampos = sqlExecute("SELECT nombre AS 'NOMBRE',UPPER(cod_campo) as 'COD_CAMPO' FROM campos ORDER BY nombre", "IDEAS")
        cbCampos.DataSource = dtCampos

        cbCampos.SelectedIndex = -1
        cbCampos.Focus()
    End Sub

    Public Function OrdenAcumulado()
        Dim x As Integer
        Dim a As String = ""
        lstOrden.Items.Clear()

        For x = 0 To NOrden - 1
            a = Orden(1, x) & " (" & Orden(2, x) & ")"
            lstOrden.Items.Add(a)
        Next
        Return a
    End Function

    Private Sub ReflectionLabel1_Click(sender As Object, e As EventArgs) Handles ReflectionLabel1.Click

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim Campo As String
        Dim Modo As String = IIf(sbOrden.Value, "ASC", "DESC")
        Dim I As Integer = -1

        If Not cbCampos.SelectedValue = Nothing Then
            Campo = cbCampos.SelectedValue.ToString.Trim
        Else
            Exit Sub
        End If

        For x = 0 To NOrden - 1
            If Orden(1, x) = Campo Then
                I = x
                Exit For
            End If
        Next

        If I = -1 Then
            I = NOrden
            NOrden = NOrden + 1

            If UBound(Orden, 2) < NOrden Then
                ReDim Preserve Orden(2, NOrden)
            End If
        End If


        Orden(1, I) = Campo
        Orden(2, I) = Modo

        OrdenAcumulado()

    End Sub

    '    Private Sub btnSubir_Click(sender As Object, e As EventArgs) Handles btnSubir.Click
    '        On Error GoTo ErrS
    '        ' SubirElemento(lstOrden)
    '        Exit Sub
    'ErrS:
    '        MessageBox.Show(Err.Description)
    '    End Sub




    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnSubir_Click(sender As Object, e As EventArgs) Handles btnSubir.Click
        On Error GoTo ErrS
        SubirElemento(lstOrden)
        Exit Sub
ErrS:
        MessageBox.Show(Err.Description)
    End Sub

    Private Sub btnBajar_Click(sender As Object, e As EventArgs) Handles btnBajar.Click
        BajarElemento(lstOrden)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        lstOrden.Items.Clear()
        NOrden = 1

        Orden(1, 0) = "RELOJ"
        Orden(2, 0) = "ASC"

        lstOrden.Items.Clear()
        lstOrden.Items.Add(Orden(1, 0) & " (" & Orden(2, 0) & ")")
    End Sub

    Private Sub lstOrden_KeyUp(sender As Object, e As KeyEventArgs) Handles lstOrden.KeyUp
        Dim i As Integer
        Dim x As Integer
        If e.KeyValue = Keys.Delete Then
            i = lstOrden.SelectedIndex

            If i < 0 Then Exit Sub
            lstOrden.Items.RemoveAt(i)

            For x = i To NOrden - 1
                Orden(1, x) = Orden(1, x + 1)
                Orden(2, x) = Orden(2, x + 1)
            Next
            NOrden = NOrden - 1
            ReDim Preserve Orden(2, x)

            lstOrden.Items.Clear()
            For x = 0 To NOrden - 1
                lstOrden.Items.Add(Orden(1, x) & "(" & Orden(2, x) & ")")
            Next
        End If
    End Sub

    Private Sub lstOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrden.SelectedIndexChanged

    End Sub
End Class