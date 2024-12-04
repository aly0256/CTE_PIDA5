Imports DevComponents.DotNetBar.Keyboard
Imports DevComponents.DotNetBar.Metro
Public Class frmInfoPrestamo
    Dim dtPeriodoAhorro As DataTable
    Dim SemanasAlfinal As Integer
    Dim Semanas As Integer
    Dim SemanasS As Integer = 8
    Dim SemanasI As Integer = 1
    Dim PeriodoActual As Integer
    Dim Cantidad As Double
    Dim CantidadString As String = "0"
    Dim CantidadS As Double = 10000
    Dim CantidadI As Double = 50
    Dim TipoPago As String
    Dim Alfinal As Boolean
    Dim Abono As Double = 0
    'Dim interes As Double
    Private Sub frmInputForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'setFullScreen()
        kbTeclado.Keyboard = CreateNumericKeyboard()
        Cantidad = ConsultaAhorro.TOTAL 'select ISNULL(cast(observaciones as INTEGER),0) as semanas from periodos where GETDATE()>= fecha_ini   and GETDATE()  <=   FECHA_FIN and periodo <54
        'Dim dtSemanasPrestamos As DataTable = sqlExecute("select ISNULL(cast(observaciones as INTEGER),1) as semanas from periodos where GETDATE()>= fecha_ini   and GETDATE()  <=   FECHA_FIN and periodo <54")
        'If dtSemanasPrestamos.Rows.Count > 0 Then
        '    SemanasS = IIf(IsDBNull(dtSemanasPrestamos.Rows(0).Item("semanas")), 1, dtSemanasPrestamos.Rows(0).Item("semanas"))
        'Else
        '    btnAlfinal.PerformClick()
        SemanasS = 1
        'End If

        'Dim dtTemp As DataTable
        'dtTemp = sqlExecute("SELECT * FROM PERIODOS WHERE FECHA_INI <= '" & FechaSQL(Date.Now) & "' AND FECHA_FIN >='" & FechaSQL(Date.Now) & "' AND PERIODO_ESPECIAL <>'1'")
        'If dtTemp.Rows.Count > 0 Then
        '    PeriodoActual = Integer.Parse(dtTemp.Rows(0).Item("PERIODO"))
        'End If
        'dtTemp = sqlExecute("SELECT * FROM PERIODOS WHERE FECHA_INI <= '" & FechaSQL(Date.Now) & "'")
        'dtPeriodoAhorro = sqlExecute("SELECT FECHA_INI FROM periodos WHERE OBSERVACIONES like 'Ahorro%' and fecha_ini > getdate()", "NOMINA")

        'If dtPeriodoAhorro.Rows.Count > 0 Then
        '    dtPeriodoAhorro = sqlExecute("SELECT FECHA_INI FROM periodos WHERE FECHA_INI <='" & FechaSQL(dtPeriodoAhorro.Rows(0).Item("FECHA_INI")) & "'", "NOMINA")
        '    SemanasS = dtPeriodoAhorro.Rows.Count - dtTemp.Rows.Count - 1
        'Else
        '    btnAlfinal.PerformClick()
        '    SemanasS = 1
        'End If


        CantidadS = Cantidad
        Semanas = SemanasS
        SemanasAlfinal = Semanas
        lblSemanas.Text = Semanas.ToString
        lblCantidad.Text = Format(CantidadS, "C")
        btnAlfinal.PerformClick()
        MostrarInformacion()
    End Sub
    Private Sub setFullScreen()
        Me.Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Me.SetVisibleCore(False)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.SetVisibleCore(True)
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

        If tecla = "{BACKSPACE}" Then
            CantidadString = "0"
        Else
            CantidadString = CantidadString + tecla
        End If
        Cantidad = Double.Parse(CantidadString)
        If Cantidad <= CantidadS Then
            lblCantidad.Text = Format(Cantidad, "c")
        Else
            lblCantidad.Text = Format(CantidadS, "c")
            MessageBox.Show("La cantidad máxima que puedes solicitar es : " & lblCantidad.Text, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cantidad = CantidadS
            CantidadString = ""
        End If
        MostrarInformacion()
    End Sub
    Private Sub MostrarInformacion()
        'lblTotalPrestamo.Text = ""
        'lblTotalInteres.Text = ""
        'lblAbonoSemanalI.Text = ""
        'lblAbonoSemanalP.Text = ""
        'lblDescuentoSemanal.Text = ""
        ' interes = (Cantidad * 0.1) * ((Semanas) / 52)
        If Not btnSemanal.Enabled Then
            'interes = (Cantidad * 0.1) * ((Semanas) / 52)
            TipoPago = "Semanal"
            'lblAbonoSemanalI.Text = Format(interes / Semanas, "C")
            'lblAbonoSemanalP.Text = Format(Cantidad / Semanas, "C")
            Abono = (Cantidad) / Semanas
            lblDescuentoSemanal.Text = Format(Abono, "c")
            PaginaDos.Visible = True
        Else
            'interes = (Cantidad * 0.1) * ((SemanasAlfinal) / 52)
            TipoPago = "Alfinal"
            lblAbonoSemanalI.Text = "N/A"
            lblAbonoSemanalP.Text = "N/A"
            lblDescuentoSemanal.Text = "N/A"
            Abono = 0
            PaginaDos.Visible = False
        End If

        lblTotalPrestamo.Text = Format(Cantidad, "C")
        ' lblTotalInteres.Text = Format(interes, "C")

    End Sub

    Private Sub MetroTileItem3_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


    Private Sub btnAlfinal_Click(sender As Object, e As EventArgs) Handles btnAlfinal.Click, btnSemanal.Click
        If btnAlfinal.Enabled Then
            btnAlfinal.Enabled = False
            btnAlfinal.BackColor = Color.White
            btnSemanal.BackColor = Color.Gold
            btnSemanal.Enabled = True
        Else
            btnAlfinal.BackColor = Color.Gold
            btnSemanal.BackColor = Color.White
            btnAlfinal.Enabled = True
            btnSemanal.Enabled = False
        End If
        MostrarInformacion()
    End Sub

    Private Sub btnMas_Click(sender As Object, e As EventArgs) Handles btnMas.Click
        If Semanas < SemanasS Then
            Semanas = Double.Parse(lblSemanas.Text) + 1
            lblSemanas.Text = Semanas.ToString
        End If
        MostrarInformacion()
    End Sub

    Private Sub btnMenos_Click(sender As Object, e As EventArgs) Handles btnMenos.Click
        If Semanas > SemanasI Then
            Semanas = Double.Parse(lblSemanas.Text) - 1
            lblSemanas.Text = Semanas.ToString
        End If
        MostrarInformacion()
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        ConsultaAhorro.PlazoSemanas = IIf(btnSemanal.Enabled, 0, Semanas)
        ConsultaAhorro.TipoPago = TipoPago
        ConsultaAhorro.CantidadPrestamo = Cantidad
        ConsultaAhorro.AbonoSem = Abono
        ConsultaAhorro.Interes = 0
        Me.Close()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub lblSemanas_Click(sender As Object, e As EventArgs) Handles lblSemanas.Click

    End Sub
End Class