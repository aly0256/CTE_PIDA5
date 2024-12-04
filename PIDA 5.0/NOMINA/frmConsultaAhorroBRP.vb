Public Class frmConsultaAhorroBRP
    Public TOTAL As Double
    Public CantidadPrestamo As Double
    Public TipoPago As String
    Public PlazoSemanas As Integer
    Public periodo As Integer
    Public AbonoSem As Double
    Public Interes As Double
    Dim dtPersonal As New DataTable
    Dim RelojPIDA As String = ""
    Dim Depto As String = ""
    Dim tipo_periodo As String = ""
    Public periodo_retiro As Integer

    Private Sub CargarInformación(Optional Reloj As String = "010004")
        RelojPIDA = Reloj.Substring(1)
        Dim PORPEN As Double
        Dim PORPENF As Double = 0
        Dim dtTemp As DataTable
        Dim ano As Integer = Date.Now.Year
        Dim Fecha_ini As String
        Dim Fecha_fin As String
        Dim SAFAHE As String
        Dim SAFAHC As String
        Dim SALPRF As String
        Dim SAFAPE As String
        Dim SUBTOTAL As Double
        Dim SUBTOTAL_SIN_PENSION As Double
        Dim TOTAL_SIN_PENSION As Double
        'dtTemp = sqlExecute("select porcentaje, fijo  from pensiones where reloj = '" & Empleado.getRelojPIDA & "'")
        'If dtTemp.Rows.Count > 0 Then
        '    PORPEN = Double.Parse(dtTemp.Rows(0).Item("porcentaje").ToString.Trim)

        '    If PORPEN = 0 Then
        '        PORPENF = Double.Parse(dtTemp.Rows(0).Item("fijo").ToString.Trim)
        '    End If
        'Else
        '    PORPEN = 0
        'End If
        dtTemp = sqlExecute("select * from periodos where FECHA_INI <= GETDATE() and FECHA_FIN >= GETDATE() and PERIODO_ESPECIAL = '0'", "kiosco")
        If dtTemp.Rows.Count > 0 Then
            periodo_retiro = Integer.Parse(dtTemp.Rows(0).Item("periodo"))
        Else
            dtTemp = sqlExecute("SELECT TOP 1 COD_TIPO_NOMINA,PERIODO FROM NOMINA WHERE COD_TIPO_NOMINA = 'N' AND ANO = '" & ano & "' AND tipo_periodo = '" & TipoPeriodo & "' AND PERIODO < 54 ORDER BY PERIODO DESC", "KIOSCO")
            If dtTemp.Rows.Count > 0 Then
                periodo_retiro = Integer.Parse(dtTemp.Rows(0).Item("periodo"))
            End If
        End If

        dtTemp = sqlExecute("SELECT TOP 1 COD_TIPO_NOMINA,PERIODO FROM nomina WHERE ANO+periodo = (select top 1 ano+periodo from timbrado where ano = '" & ano & "' and tipo_periodo = '" & TipoPeriodo & "' and periodo < 54 order by periodo desc) ORDER BY PERIODO DESC", "KIOSCO")
        If dtTemp.Rows.Count > 0 Then
            periodo = Integer.Parse(dtTemp.Rows(0).Item("periodo"))
        Else
            ano = ano - 1
            dtTemp = sqlExecute("SELECT TOP 1 COD_TIPO_NOMINA,PERIODO FROM nomina WHERE ANO+periodo = (select top 1 ano+periodo from timbrado where ano = '" & ano & "' and tipo_periodo = '" & TipoPeriodo & "' and periodo < 54 order by periodo desc) ORDER BY PERIODO DESC", "KIOSCO")
            If dtTemp.Rows.Count > 0 Then
                periodo = Integer.Parse(dtTemp.Rows(0).Item("periodo"))
            End If
        End If

        dtTemp = sqlExecute("SELECT FECHA_INI FROM PERIODOS WHERE PERIODO = '" & periodo.ToString.PadLeft(2, "0") & "' AND ANO = '" & ano & "'", "KIOSCO")
        If dtTemp.Rows.Count > 0 Then
            Fecha_ini = FechaLetra(dtTemp.Rows(0).Item("FECHA_INI"))
        Else
            Fecha_ini = "--/--/--"
        End If
        dtTemp = sqlExecute("SELECT FECHA_FIN FROM PERIODOS WHERE PERIODO = '" & periodo.ToString.PadLeft(2, "0") & "' AND ANO = '" & ano & "'", "KIOSCO")
        If dtTemp.Rows.Count > 0 Then
            Fecha_fin = FechaLetra(dtTemp.Rows(0).Item("FECHA_FIN"))
        Else
            Fecha_fin = "--/--/--"
        End If
        'tileFecha.TitleText = " "
        'tileFecha.Text = " La Información está actualizada hasta el periodo " + periodo.ToString + vbCrLf + " correspondiente a la semana del " & Fecha_ini & " al " & Fecha_fin
        'tileFecha.Text = " Saldo al día de hoy."

        dtTemp = sqlExecute("SELECT MONTO FROM MOVIMIENTOS WHERE RELOJ = '" & RelojPIDA & "' and tipo_periodo = '" & TipoPeriodo & "' AND TIPO_NOMINA = 'N' AND PERIODO = '" & periodo.ToString.PadLeft(2, "0") & "' AND ANO = '" & ano & "' AND CONCEPTO = 'SAFAHE'", "KIOSCO")
        If dtTemp.Rows.Count > 0 Then
            SAFAHE = dtTemp.Rows(0).Item("MONTO").ToString
        Else
            SAFAHE = "00.00"
            'btnRetiro.Enabled = False
        End If
        dtTemp = sqlExecute("SELECT MONTO FROM MOVIMIENTOS WHERE RELOJ = '" & RelojPIDA & "' and tipo_periodo = '" & TipoPeriodo & "' AND TIPO_NOMINA = 'N' AND PERIODO = '" & periodo.ToString.PadLeft(2, "0") & "' AND ANO = '" & ano & "' AND CONCEPTO = 'SAFAHC'", "KIOSCo")
        If dtTemp.Rows.Count > 0 Then
            SAFAHC = dtTemp.Rows(0).Item("MONTO").ToString
        Else
            SAFAHC = "00.00"
        End If
        dtTemp = sqlExecute("SELECT MONTO FROM MOVIMIENTOS WHERE RELOJ = '" & RelojPIDA & "' and tipo_periodo = '" & TipoPeriodo & "' AND TIPO_NOMINA = 'N' AND PERIODO = '" & periodo.ToString.PadLeft(2, "0") & "' AND ANO = '" & ano & "' AND CONCEPTO = 'SALPRF'", "KIOSCO")
        If dtTemp.Rows.Count > 0 Then
            SALPRF = dtTemp.Rows(0).Item("MONTO").ToString
        Else
            SALPRF = "00.00"
        End If
        If Not SALPRF.Equals("00.00") Then
            btnPrestamo.Enabled = False
        Else
            btnPrestamo.Enabled = True
        End If
        If SAFAHC.Equals("00.00") Then
            btnPrestamo.Enabled = False
        Else
            btnPrestamo.Enabled = True
        End If
        dtTemp = sqlExecute("SELECT MONTO FROM MOVIMIENTOS WHERE RELOJ = '" & RelojPIDA & "' and tipo_periodo = '" & TipoPeriodo & "' AND TIPO_NOMINA = 'N' AND PERIODO = '" & periodo.ToString.PadLeft(2, "0") & "' AND ANO = '" & ano & "' AND CONCEPTO = 'SAFAPE'", "KIOSCO")
        If dtTemp.Rows.Count > 0 Then
            SAFAPE = dtTemp.Rows(0).Item("MONTO").ToString
        Else
            SAFAPE = "00.00"
        End If
        Try

            SUBTOTAL = Double.Parse(SAFAHE) - SAFAPE + Double.Parse(SAFAHC)

        Catch ex As Exception

        End Try
        'SUBTOTAL = Double.Parse(SAFAHC) * (1 - (PORPEN / 100)) + Double.Parse(SAFAHC)
        SUBTOTAL_SIN_PENSION = Double.Parse(SAFAHE) + Double.Parse(SAFAHC)
        TOTAL_SIN_PENSION = SUBTOTAL_SIN_PENSION - Double.Parse(SALPRF)
        TOTAL = SUBTOTAL - Double.Parse(SALPRF)
        txtResumen.Text = "Ahorro empleado:          " & Format(Double.Parse(SAFAHE), "c") _
            & vbCrLf & " +      " & vbCrLf & _
            "Ahorro empresa:            " & Format(Double.Parse(SAFAHC), "c") _
             & vbCrLf & " -      " & vbCrLf & _
            "Saldo Retiro:             " & Format(Double.Parse(SALPRF), "c") _
            & vbCrLf & " = " & vbCrLf & _
            "Subtotal:           " & Format(TOTAL_SIN_PENSION, "c") _
            & vbCrLf & " -      " & vbCrLf & _
            "Pensión alimenticia:          " & Format(Double.Parse(SAFAPE), "c") _
            & vbCrLf & " =      " & vbCrLf & _
            "Monto máximo a retirar:          " & Format(TOTAL, "c") _
            & vbCrLf & vbCrLf & "Puedes Solicitar hasta:        " _
            & IIf(SALPRF.Equals("00.00"), Format(TOTAL, "c"), "N/A")
        'ActivityLog(IPKiosko, "CONSULTA DE AHORRO", Empleado.getReloj, ano.ToString + periodo.ToString.PadLeft(2, "0"))
    End Sub


    Private Sub frmConsultaAhorroBRP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarInformacion()

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.Close()
    End Sub

    Private Sub btnPrestamo_Click(sender As Object, e As EventArgs) Handles btnPrestamo.Click


        Dim dtTemp As DataTable = sqlExecute("SELECT * FROM prestamos WHERE  (RELOJ ='" & RelojPIDA & "' AND ano >= '" & Date.Now.Year.ToString & "')", "KIOSCO") '(RELOJ ='" & Empleado.getRelojPIDA & "' AND CONFIRMADO = '0') or 
        If dtTemp.Rows.Count > 0 Then
          
            MessageBox.Show("No se puede realizar la solicitud para este empleado, porque ya tiene una pendiente.", "Solicitud realizada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' btnPrestamo.Enabled = False
            'ElseIf sqlExecute("select * from prestamos where reloj ='" & Empleado.getRelojPIDA & "' and ano+periodo >  (select top 1 ANO+PERIODO as seleccionado  from periodos where FECHA_INI < GETDATE() and OBSERVACIONES like 'Ahorro%' order by fecha_ini desc)", "KIOSCO").Rows.Count > 0 Then
            '    btnPrestamo.TitleText = "Exceso de solicitudes"
            '    Dim m As frmMessageBox = New frmMessageBox("No puedes solicitar: No puedes solicitar más de un retiro por ciclo. Favor de comunicarse a la ext. 4747", 1, False)
            ' btnRetiro.Enabled = False
            'ElseIf sqlExecute("SELECT * FROM retiros WHERE  (RELOJ ='" & Empleado.getRelojPIDA & "' AND CONFIRMADO = '0') or (RELOJ ='" & Empleado.getRelojPIDA & "' AND fecha_sol > '" & FechaSQL(Date.Now.AddDays(-15)) & "')", "KIOSCO").Rows.Count > 0 Then
            '    btnPrestamo.TitleText = "Ya tienes una solicitud"
            '    Dim m As frmMessageBox = New frmMessageBox("No puedes solicitar: ya tienes una solicitud de retiro pendiente. Favor de comunicarse a la ext. 4747", 1, False)
            ' btnRetiro.Enabled = False
        Else
            RelojClabe = RelojPIDA
            If frmClabe.ShowDialog() = DialogResult.Cancel Then

            Else

                If frmInfoPrestamo.ShowDialog() = DialogResult.Cancel Then

                Else
                    Dim id As TimeSpan
                    id = Date.Now.TimeOfDay
                    'Dim M As frmMessageBox = New frmMessageBox("Pasa al final del turno  a Recursos Humanos  a firmar tu solicitud ", 1, True)
                    If MessageBox.Show("¿Estas seguro que deseas hacer una solicitud de retiro para este empleado?", "Retirar de fondo de ahorro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then


                        sqlExecute("INSERT INTO prestamos(ID,RELOJ,NOMBRE,FECHA_SOL,FECHA_REV,CANTIDAD,CONFIRMADO,TIPO_PAGO,PLAZO_SEMANAS,DEPTO,ABONO,INTERES,EXPORTADO, ano, periodo, clabe, fecha_export) " & _
                                                  "VALUES('" & id.ToString & "','" & RelojPIDA & "','" & txtApaterno.Text.Trim & " " & txtAmaterno.Text.Trim & " / " & txtNombre.Text.Trim & "','" & FechaSQL(Date.Now) & "','" & FechaSQL(Date.Now) & "'," & _
                                                  "'" & Format(CantidadPrestamo, "f") & "','1','al final','0','0'," & _
                                                  "'0','0','0','" & Date.Now.Year & "', '" & periodo_retiro & "', '" & CLABE_fah & "',null)", "KIOSCO")
                        MessageBox.Show("Solicitud aplicada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else

                        sqlExecute("DELETE FROM prestamos WHERE ID = '" & id.ToString & "' and reloj = '" & RelojPIDA & "'", "KIOSCO")
                        Me.Close()
                    End If

                End If
            End If
        End If

    End Sub
    Private Sub btnRetiro_Click(sender As Object, e As EventArgs)
        'Dim dtTemp As DataTable = sqlExecute("SELECT * FROM retiros WHERE  (RELOJ ='" & RelojPIDA & "' AND CONFIRMADO = '0') or (RELOJ ='" & RelojPIDA & "' AND fecha_sol > '" & FechaSQL(Date.Now.AddDays(-15)) & "')", "KIOSCO")
        'If dtTemp.Rows.Count > 0 Then
        '    MessageBox.Show("No se puede realizar la solicitud para este empleado, porque ya tiene una pendiente.", "Solicitud realizada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'ElseIf sqlExecute("SELECT * FROM prestamos WHERE  (RELOJ ='" & RelojPIDA & "' AND CONFIRMADO = '0') or (RELOJ ='" & txtReloj.Text.Trim & "' AND fecha_sol > '" & FechaSQL(Date.Now.AddDays(-15)) & "')", "KIOSCO").Rows.Count > 0 Then
        '    MessageBox.Show("No se puede realizar la solicitud para este empleado, porque ya tiene una pendiente.", "Solicitud realizada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    If MessageBox.Show("¿Estas seguro que deseas retirar a este empleado del fondo de ahorro?", "Retirar de fondo de ahorro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
        '        Dim id As TimeSpan
        '        id = Date.Now.TimeOfDay
        '        sqlExecute("INSERT INTO retiros(ID,RELOJ,NOMBRE,FECHA_SOL,DEPTO,CONFIRMADO,EXPORTADO)VALUES('" & id.ToString & "','" & RelojPIDA & "','" & txtNombre.Text.Trim & " " & txtApaterno.Text.Trim & " " & txtAmaterno.Text.Trim & "','" & FechaSQL(Date.Now) & "','" & Depto & "','1','0')", "KIOSCO")
        '        Me.Close()
        '    End If
        'End If
    End Sub
    Private Sub txtReloj_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtReloj.ButtonCustomClick
        Dim dtTemp As New DataTable
        dtTemp = dtPersonal
        Try
            frmBuscar.ShowDialog()
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj)
            End If
        Catch ex As Exception
            ' ErrorLog(Usuario.getUSERNAME, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
            dtPersonal = dtTemp
        End Try
    End Sub
    Public Sub MostrarInformacion(Optional rl As String = "")

        Dim ArchivoFoto As String

        Dim SI As Integer = 0
        Try

            If rl <> "" Then
                dtPersonal = sqlExecute("SELECT top 1 * FROM Vpersonal WHERE RELOJ = '" & rl & "'", "KIOSCO")
            Else
                dtPersonal = sqlExecute("SELECT  TOP 1 * FROM Vpersonal ORDER BY RELOJ ", "KIOSCO")
                rl = IIf(IsDBNull(dtPersonal.Rows.Item(0).Item("RELOJ")), "", dtPersonal.Rows.Item(0).Item("RELOJ"))
            End If

            With dtPersonal.Rows.Item(0)
                txtReloj.Text = IIf(IsDBNull(.Item("RELOJ")), "", .Item("RELOJ"))
                txtNombre.Text = IIf(IsDBNull(.Item("NOMBRE")), "", .Item("NOMBRE"))
                txtApaterno.Text = IIf(IsDBNull(.Item("APATERNO")), "", .Item("APATERNO"))
                txtAmaterno.Text = IIf(IsDBNull(.Item("AMATERNO")), "", .Item("AMATERNO"))
                Depto = IIf(IsDBNull(.Item("COD_DEPTO")), "", .Item("COD_DEPTO"))
                TipoPeriodo = IIf(IsDBNull(.Item("tipo_periodo")), "", .Item("tipo_periodo"))
            End With
            Try
                Dim dtTemp As DataTable = sqlExecute("SELECT TOP 1 path_foto FROM cias WHERE cia_default=1", "KIOSCO")
                PathFoto = dtTemp.Rows.Item(0).Item("path_foto")
                PathFoto = PathFoto.Trim
                If PathFoto.Substring(PathFoto.Length - 1, 1) <> "\" Then
                    PathFoto = PathFoto & "\"
                End If
                ArchivoFoto = PathFoto & txtReloj.Text.Trim.PadLeft(6, "0") & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    ArchivoFoto = PathFoto & "nofoto.png"
                End If
                'Dim ft As New Bitmap(ArchivoFoto)
                picFoto.Width = picFoto.MinimumSize.Width
                picFoto.Height = picFoto.MinimumSize.Height
                picFoto.Left = 572
                'picFoto.Image = ft
                picFoto.ImageLocation = ArchivoFoto
            Catch
                picFoto.Image = picFoto.ErrorImage
            End Try

            CargarInformación(txtReloj.Text)
        Catch ex As Exception

        End Try
    End Sub

End Class