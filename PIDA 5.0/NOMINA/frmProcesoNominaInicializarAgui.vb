Public Class frmProcesoNominaInicializarAgui

    '-- Modificaciones -- Ernesto -- 11 oct 2023
    Public Sub New(Optional options As Dictionary(Of String, Object) = Nothing)
        Call Me.InitializeComponent()
        Dim fha = DateSerial(Year(Date.Now), 12, 31)
        dtiFecha.Value = fha
    End Sub


    Public Function getOption(varName As String) As Object
        Select Case varName
            Case "aguinaldo_anual" : Return True
            Case "aguinaldo_fecha" : Return (FechaSQL(dtiFecha.Value))
        End Select
        Return False
    End Function

    Public Function getAllOptions() As Dictionary(Of String, Object)
        Return New Dictionary(Of String, Object) From {{"aguinaldo_anual", True},
                                                       {"aguinaldo_fecha", FechaSQL(dtiFecha.Value)}}
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