Public Class frmProcesoNominaCalcularOpciones

    '-- Modificaciones -- Ernesto -- 11 oct 2023
    Public Sub New(Optional options As Dictionary(Of String, Object) = Nothing, Optional strMes As String = "")
        Call Me.InitializeComponent()
        Label1.Text = String.Format("SUA pagado del mes anterior [{0}]", strMes)
        Me.sbtnCalcAgui.Value = IIf(Not options Is Nothing And options.ContainsKey("periodo_aguinaldo"), options("periodo_aguinaldo"), False)
        Me.sbtnSuaPaid.Value = IIf(Not options Is Nothing And options.ContainsKey("sua_pagado_mes_anterior"), options("sua_pagado_mes_anterior"), False)
        Me.sbtnAjusteSub.Value = IIf(Not options Is Nothing And options.ContainsKey("incluir_ajuste_subsidio"), options("incluir_ajuste_subsidio"), False)
    End Sub


    Public Function getOption(varName As String) As Boolean
        Select Case varName
            Case "periodo_aguinaldo" : Return Me.sbtnCalcAgui.Value
            Case "sua_pagado_mes_anterior" : Return Me.sbtnSuaPaid.Value
            Case "incluir_ajuste_subsidio" : Return Me.sbtnAjusteSub.Value
        End Select
        Return False
    End Function

    Public Function getAllOptions() As Dictionary(Of String, Boolean)
        Return New Dictionary(Of String, Boolean) From {{"periodo_aguinaldo", Me.sbtnCalcAgui.Value},
                                                        {"sua_pagado_mes_anterior", Me.sbtnSuaPaid.Value},
                                                        {"incluir_ajuste_subsidio", Me.sbtnAjusteSub.Value}}
    End Function

    Private Sub btnAcept_Click(sender As Object, e As EventArgs) Handles btnAcept.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class