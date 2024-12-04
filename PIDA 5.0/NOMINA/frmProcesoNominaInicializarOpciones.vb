Public Class frmProcesoNominaInicializarOpciones

    Public Sub New(Optional options As Dictionary(Of String, Object) = Nothing)
        Call Me.InitializeComponent()
        Me.sbtnPSG.Value = IIf(Not options Is Nothing And options.ContainsKey("validar_psg_5hrs"), options("validar_psg_5hrs"), False)
        Me.sbtnSindi.Value = IIf(Not options Is Nothing And options.ContainsKey("descuento_sindical"), options("descuento_sindical"), False)
        Me.sbtnDespensaF.Value = IIf(Not options Is Nothing And options.ContainsKey("aplica_vales_despensa_finiquitos"), options("aplica_vales_despensa_finiquitos"), False)
        Me.sbtnAgui.Value = IIf(Not options Is Nothing And options.ContainsKey("incluir_aguinaldo_proporcional"), options("incluir_aguinaldo_proporcional"), False)
        Me.txtDescDefuncion.Text = IIf(Not options Is Nothing And options.ContainsKey("empleados_descuento_defuncion"), options("empleados_descuento_defuncion"), "")
    End Sub


    Public Function getOption(varName As String) As Object
        Select Case varName
            Case "validar_psg_5hrs" : Return Me.sbtnPSG.Value
            Case "descuento_sindical" : Return Me.sbtnSindi.Value
            Case "aplica_vales_despensa_finiquitos" : Return Me.sbtnDespensaF.Value
            Case "incluir_aguinaldo_proporcional" : Return Me.sbtnAgui.Value
            Case "incluir_bondes" : Return False
            Case "empleados_descuento_defuncion" : Return Me.txtDescDefuncion.Text
        End Select
        Return False
    End Function

    Public Function getAllOptions() As Dictionary(Of String, Object)
        Return New Dictionary(Of String, Object) From {{"validar_psg_5hrs", Me.sbtnPSG.Value},
                                                       {"descuento_sindical", Me.sbtnSindi.Value},
                                                       {"aplica_vales_despensa_finiquitos", Me.sbtnDespensaF.Value},
                                                       {"incluir_aguinaldo_proporcional", Me.sbtnAgui.Value},
                                                       {"empleados_descuento_defuncion", txtDescDefuncion.Text},
                                                       {"incluir_bondes", False}}
    End Function

    Private Sub CaracteresPermitidos(sender As Object, e As KeyPressEventArgs) Handles txtDescDefuncion.KeyPress
        Try
            If Not Char.IsNumber(e.KeyChar) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) And Not (e.KeyChar = ",") Then e.KeyChar = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAcept_Click(sender As Object, e As EventArgs) Handles btnAcept.Click

        '-- Validación para asignar relojes para descuento de defunción -- Ernesto
        If Not ValidarRelojesDefuncion() Then
            MessageBox.Show("En 'descuento de defunción', favor de asignar y/o verificar los relojes con formato correcto en el campo de texto 'Asignar empleado(s)'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            txtDescDefuncion.Text = "'" & txtDescDefuncion.Text.ToString.Replace(",", "','") & "'"
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' Se valida el campo de empleado(s) asignado(s) al monto de defunción -- Ernesto
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValidarRelojesDefuncion() As Boolean
        If sbtnSindi.Value Then
            If txtDescDefuncion.Text = "" Then Return False

            Dim strRelojes = txtDescDefuncion.Text.Split(",")
            For Each r In strRelojes
                If r.Length <> 6 Then Return False
            Next
        End If
        Return True
    End Function

    ''' <summary>
    ''' Si se habilita descuento de defunción, habilitar textbox para ingresar empleados asignados. -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub sbtnSindi_ValueChanged(sender As Object, e As EventArgs) Handles sbtnSindi.ValueChanged
        txtDescDefuncion.Enabled = sbtnSindi.Value
        Label6.Enabled = sbtnSindi.Value
        Label7.Enabled = sbtnSindi.Value
        txtDescDefuncion.Focus()
        txtDescDefuncion.Text = ""
    End Sub
End Class