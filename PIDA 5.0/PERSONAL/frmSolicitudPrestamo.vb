Public Class frmSolicitudPrestamo
    Dim Agregar As Boolean
    Dim dtInfoPersonal As New DataTable
    Dim dtTemp As New DataTable
    Dim dtCias As New DataTable
    Dim dtSolicitudes As New DataTable
    Dim TotalSemanas As Integer
    Dim InicioAhorroStr As String


    Private Sub frmSolicitudPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PeriodoActual As String
        Dim FinAhorroStr As String
        Dim InicioPrestamosStr As String
        Dim Permitir As Boolean
        Dim Valido As Boolean = True

        '***IGR*pidieron que el periodo que tuviera la solicitud fuera el periodo que se esta viviendo y no el de nomina
        PeriodoActual = ObtenerAnoPeriodo(Now.Date)
        If PeriodoActual.Length < 6 Then
            txtPeriodo.Text = PeriodoActual
        Else
            txtPeriodo.Text = PeriodoActual.Substring(0, 4) & "-" & PeriodoActual.Substring(4, 2)
        End If

        'Buscar el máximo periodo cargado en nómina
        dtTemp = sqlExecute("SELECT MAX(ano+periodo) as ultimo FROM nomina WHERE periodo<'55'", "nomina")
        If dtTemp.Rows.Count = 0 Then
            MessageBox.Show("No se localizaron registros en nómina, y no es posible capturar préstamos sin esta información." & vbCrLf & _
                            "Contactar con el departamento de nóminas.", "No hay registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Valido = False
        Else
            If DiferenciaPeriodos(dtTemp.Rows(0).Item("ultimo"), PeriodoActual) > 1 Then
                MessageBox.Show("No se localizaron registros en nómina de las última semana, y no es posible capturar préstamos sin esta información." & vbCrLf & _
                                "Contactar con el departamento de nóminas.", "No hay registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Valido = False
            End If
        End If

        'Obtener información de la compañía
        dtCias = sqlExecute("SELECT SEMANA_INICIO_PRESTAMOS,PERMITIR_PRESTAMOS,SEMANA_FIN_FONDO_AHORRO,SEMANA_INICIO_FONDO_AHORRO FROM parametros")

        '** cada año se cambia el primer factor de la siguiente formula, debe ser la primer semana
        '** en que se van a CAPTURAR prestamos EJ. Año 2011 Viviendo Semana 4 
        InicioPrestamosStr = IIf(IsDBNull(dtCias.Rows(0).Item("semana_inicio_prestamos")), "      ", dtCias.Rows(0).Item("semana_inicio_prestamos"))
        InicioAhorroStr = IIf(IsDBNull(dtCias.Rows(0).Item("SEMANA_INICIO_FONDO_AHORRO")), "      ", dtCias.Rows(0).Item("SEMANA_INICIO_FONDO_AHORRO"))
        FinAhorroStr = IIf(IsDBNull(dtCias.Rows(0).Item("SEMANA_FIN_FONDO_AHORRO")), "      ", dtCias.Rows(0).Item("SEMANA_FIN_FONDO_AHORRO"))
        Permitir = IIf(IsDBNull(dtCias.Rows(0).Item("PERMITIR_PRESTAMOS")), 0, dtCias.Rows(0).Item("PERMITIR_PRESTAMOS")) = 1

        If Not Permitir Then
            'Cuando se genera archivo de préstamos, se bloquea la captura
            'Al cargar información de nómina, se vuelve a permitir capturar préstamos
            'Desde compañías, pueden activar/desactivar conforme se requiera
            MessageBox.Show("Por el momento, no se permite capturar préstamos. Si considera que es un error, consulte al departamento de nóminas.", _
                            "No permitir préstamos", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Valido = False
        Else
            If InicioPrestamosStr > PeriodoActual Then
                MessageBox.Show("El periodo de préstamos aún no inicia. Si considera que es un error, consulte al departamento de nóminas.", _
                                "No permitir préstamos", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Valido = False
            ElseIf PeriodoActual > FinAhorroStr Then
                MessageBox.Show("El periodo de préstamos ya concluyó. Si considera que es un error, consulte al departamento de nóminas.", _
                                "No permitir préstamos", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Valido = False
            End If
        End If

        cmbMotivo.Items.Add("Problemas personales")
        cmbMotivo.Items.Add("Enfermedad")
        cmbMotivo.SelectedIndex = 0

        'Determinar cuántas semanas faltan para que termine el fondo de ahorro, y es el máximo de semanas para el préstamo
        TotalSemanas = DiferenciaPeriodos(FinAhorroStr, PeriodoActual)
        txtSemanas.MaxValue = TotalSemanas

        btnAceptar.Visible = Valido
        pnlPrestamo.Enabled = Valido
        pnlPrestamo.Visible = Valido

        'dtSolicitudes = sqlExecute("SELECT reloj,periodo,ano,fecha,cantidad_sol,cantidad_pag,porciento,descuento_sem,semanas_pag," & _
        '                           "RTRIM(motivo_pmo) AS motivo_pmo,aprobada," & _
        '                           "IIF(aprobada=0,'0 - Pendiente',IIF(aprobada=1,'1 - Aprobada','2 - Rechazada')) AS estado " & _
        '                           "FROM sol_prestamos WHERE ano+periodo >= '" & InicioAhorroStr & "' ORDER BY aprobada", "nomina")

        ' BERE

        dtSolicitudes = sqlExecute("SELECT reloj,periodo,ano,fecha,cantidad_sol,cantidad_pag,porciento,descuento_sem,semanas_pag," & _
                                   "RTRIM(motivo_pmo) AS motivo_pmo,aprobada," & _
                                   "(CASE aprobada when 0 then '0 - Pendiente' else (case aprobada when 1 then '1 - Aprobada' else '2 - Rechazada' end ) end) AS estado " & _
                                   "FROM sol_prestamos WHERE ano+periodo >= '" & InicioAhorroStr & "' ORDER BY aprobada", "nomina")

        dgTabla.DataSource = dtSolicitudes
        lblMensaje.Visible = False
        lblMensaje.Height = pnlPrestamo.Height
        lblMensaje.Dock = DockStyle.Bottom

        MostrarInformacion()
        HabilitarBotones()
    End Sub

    Public Sub MostrarInformacion(Optional ByVal rl As String = "")
        Dim ArchivoFoto As String
        Dim dRow As DataRow
        Dim Valido As Boolean = True
        Try
            If rl = "" Then
                dtInfoPersonal = sqlExecute("SELECT TOP 1 reloj,nombres,cod_tipo,cod_depto,cod_super,cod_clase,cod_turno,cod_hora, " & _
                                            "nombre_depto,nombre_turno,nombre_horario,nombre_puesto,nombre_tipoemp,nombre_clase,nombre_super,alta,baja  " & _
                                            "FROM personalVW WHERE baja IS NULL ORDER BY reloj")
            Else
                dtInfoPersonal = sqlExecute("SELECT TOP 1 reloj,nombres,cod_tipo,cod_depto,cod_super,cod_clase,cod_turno,cod_hora, " & _
                            "nombre_depto,nombre_turno,nombre_horario,nombre_puesto,nombre_tipoemp,nombre_clase,nombre_super,alta,baja  " & _
                            "FROM personalVW WHERE reloj = '" & rl & "' AND baja IS NULL ORDER BY reloj")
            End If
            If dtInfoPersonal.Rows.Count = 0 Then
                MessageBox.Show("El empleado no se localizó, está dado de baja, o el usuario no tiene acceso a su información.", "Error", _
                                MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If

            rl = IIf(IsDBNull(dtInfoPersonal.Rows.Item(0).Item("reloj")), "", dtInfoPersonal.Rows.Item(0).Item("reloj"))
            dRow = dtInfoPersonal.Rows(0)

            lblmensaje.Visible = False
            'Mostrar información
            txtReloj.Text = IIf(IsDBNull(dRow("reloj")), "", dRow("reloj"))
            txtNombre.Text = IIf(IsDBNull(dRow("nombres")), "", dRow("nombres"))
            txtDepto.Text = IIf(IsDBNull(dRow("nombre_depto")), "", dRow("nombre_depto"))
            txtPuesto.Text = IIf(IsDBNull(dRow("nombre_puesto")), "", dRow("nombre_puesto"))

            txtAlta.Text = IIf(IsDBNull(dRow("alta")), Nothing, dRow("alta"))
            EsBaja = Not IsDBNull(dRow("baja"))
            txtBaja.Text = IIf(EsBaja, dRow("baja"), Nothing)

            ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
            Try
                ArchivoFoto = PathFoto & rl & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    ArchivoFoto = PathFoto & "nofoto.png"
                End If
                picFoto.ImageLocation = ArchivoFoto
            Catch
                picFoto.Image = picFoto.ErrorImage
            End Try

            '****************************************

            '*** Cambios en bajas ****
            txtBaja.Visible = EsBaja
            lblBaja.Visible = EsBaja
            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtReloj.BackColor = lblEstado.BackColor
            '*************************


            Dim SaldoAhorro As Double
            Dim NPrestamos As Integer

            'Revisar su saldo de fondo de ahorro
            dtTemp = sqlExecute("SELECT SUM(monto) as monto FROM movimientos WHERE ano ='" & txtPeriodo.Text.Substring(0, 4) & "' AND reloj = '" & rl & _
                                "' AND concepto = 'NPREST'", "NOMINA")
            If dtTemp.Rows.Count = 0 Then
                NPrestamos = 0
            Else
                NPrestamos = IIf(IsDBNull(dtTemp.Rows(0).Item("monto")), 0, dtTemp.Rows(0).Item("monto"))
            End If

            If NPrestamos > 0 Then
                'Solo puede pedir un préstamo por año
                lblMensaje.Text = "Al empleado ya se le ha autorizado un préstamo en el año." & vbCrLf & "No puede solicitar otro."
                lblmensaje.Visible = True
                Valido = False
            Else
                'Si no hay préstamo registrado en movimientos, buscar en solicitudes
                'Revisar si tiene solicitud en proceso, o algún otro impedimento
                'Si aprobada = 2, indica que fue rechazada, y puede aplicar nuevamente
                dtTemp = sqlExecute("SELECT aprobada FROM sol_prestamos WHERE reloj = '" & rl & "' AND ano = '" & txtPeriodo.Text.Substring(0, 4) & "' AND aprobada<>2 ", "nomina")
                If dtTemp.Rows.Count > 0 Then
                    lblMensaje.Text = "El empleado ya tiene un préstamo registrado." & vbCrLf & "No puede solicitar otro."
                    lblmensaje.Visible = True
                    Valido = False
                End If
            End If

            If Valido Then
                'Revisar su saldo de fondo de ahorro
                'Sumando el saldo del empleado + saldo de la compañia
                dtTemp = sqlExecute("SELECT (SELECT MAX(monto) as monto FROM movimientos WHERE ano ='" & txtPeriodo.Text.Substring(0, 4) & "' AND reloj = '" & rl & _
                                    "' AND concepto IN ('SAFAHE','SAFAHC')) + (SELECT MAX(monto) as monto FROM movimientos WHERE ano ='" & txtPeriodo.Text.Substring(0, 4) & _
                                    "' AND reloj = '" & rl & _
                                    "' AND concepto IN ('SAFAHE','SAFAHC')) AS monto", "NOMINA")
                If dtTemp.Rows.Count = 0 Then
                    SaldoAhorro = 0
                Else
                    SaldoAhorro = IIf(IsDBNull(dtTemp.Rows(0).Item("monto")), 0, dtTemp.Rows(0).Item("monto"))
                End If

                'Restar retiros del fondo de ahorro
                dtTemp = sqlExecute("SELECT TOP 1 monto FROM movimientos WHERE ano ='" & txtPeriodo.Text.Substring(0, 4) & "' AND reloj = '" & rl & _
                                    "' AND concepto = 'RETFAH' ORDER BY periodo DESC", "NOMINA")
                If dtTemp.Rows.Count > 0 Then
                    SaldoAhorro = SaldoAhorro - IIf(IsDBNull(dtTemp.Rows(0).Item("monto")), 0, dtTemp.Rows(0).Item("monto"))
                End If
                txtCantidadSolicitada.MaxValue = SaldoAhorro
                txtCantidadSolicitada.Value = SaldoAhorro
            End If

            txtSemanas.Value = totalsemanas

            pnlPrestamo.Visible = Valido
            btnAceptar.Visible = Valido And pnlPrestamo.Enabled

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Public Sub HabilitarBotones()
        btnNext.Enabled = Not Agregar
        btnFirst.Enabled = Not Agregar
        btnLast.Enabled = Not Agregar
        btnPrev.Enabled = Not Agregar
        btnCerrar.Enabled = Not Agregar
        btnReporte.Enabled = Not Agregar
        btnBuscar.Enabled = Not Agregar
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        dtTemp = sqlExecute("SELECT TOP 1 reloj FROM personalVW WHERE baja IS NULL ORDER BY reloj ASC ")
        If dtTemp.Rows.Count <> 0 Then
            MostrarInformacion(dtTemp.Rows(0).Item("reloj"))
        End If
    End Sub


    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        dtTemp = sqlExecute("SELECT TOP 1 reloj FROM personalVW where reloj < '" & txtReloj.Text & "' AND baja IS NULL  ORDER BY reloj DESC ")
        If dtTemp.Rows.Count = 0 Then
            btnFirst.PerformClick()
        Else
            MostrarInformacion(dtTemp.Rows(0).Item("reloj"))
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        dtTemp = sqlExecute("SELECT TOP 1 reloj FROM personalVW where reloj > '" & txtReloj.Text & "' AND baja IS NULL ORDER BY reloj ASC ")
        If dtTemp.Rows.Count = 0 Then
            btnLast.PerformClick()
        Else
            MostrarInformacion(dtTemp.Rows(0).Item("reloj"))
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        dtTemp = sqlExecute("SELECT TOP 1 reloj FROM personalVW  WHERE baja IS NULL ORDER BY reloj DESC ")
        If dtTemp.Rows.Count <> 0 Then
            MostrarInformacion(dtTemp.Rows(0).Item("reloj"))
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtTemp = dtInfoPersonal
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
            dtInfoPersonal = dtTemp
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtInfo As New DataTable
        dtInfo = sqlExecute("SELECT sol_prestamos.reloj,nombres,cod_turno,nombre_depto,fecha," & _
                            "cantidad_sol,cantidad_pag,ROUND(cantidad_sol*(porciento/100),2) as intereses,porciento/100 as porciento," & _
                            "descuento_sem,semanas_pag,RTRIM(motivo_pmo) AS motivo_pmo " & _
                            "FROM nomina.dbo.sol_prestamos,personal.dbo.personalvw " & _
                            "WHERE personalVW.reloj='" & txtReloj.Text & "' AND  sol_prestamos.reloj = '" & txtReloj.Text & "'" & _
                            "AND ano = '" & txtPeriodo.Text.Substring(0, 4) & "' AND aprobada = 0")
        frmVistaPrevia.LlamarReporte("Solicitud de préstamo", dtInfo)
        frmVistaPrevia.ShowDialog()

    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtSemanas_ValueChanged(sender As Object, e As EventArgs) Handles txtSemanas.ValueChanged
        CalculaPagos()
    End Sub

    Private Sub CalculaPagos()
        Try
            '****  MODIFICACION DEL 10 AL 12% FIJO SOLICITADO POR MARY SALAZAR EL 27 DE ENERO 05 IVO
            '****  MODIFICACION DEL INTERES DEPENDIENDO DE LA CANTIDAD DE SEMANAS SOLICITADA
            '****  POR MARY SALAZAR EL 25 DE ENERO 07 IVO
            Select Case txtSemanas.Value
                Case Is <= 9
                    txtIntereses.Value = 3
                Case Is <= 19
                    txtIntereses.Value = 6
                Case Else
                    txtIntereses.Value = 12
            End Select
            txtCantidadPagar.Value = RoundUp(Val(txtCantidadSolicitada.Value) * (1 + (txtIntereses.Value / 100)), 2)
            txtDescuento.Text = FormatCurrency(RoundUp(txtCantidadPagar.Value / txtSemanas.Value, 2), 2)
        Catch ex As Exception
            txtCantidadPagar.Value = 0
            txtDescuento.Text = 0
        End Try
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim AnoPer As String
        Try
            AnoPer = txtPeriodo.Text.Replace("-", "").PadLeft(6)
            If MessageBox.Show("¿Está seguro de generar una solicitud de préstamo?", "Guardar solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                '*** IMPRIMIR SOLICITUD DE PRESTAMO ****

                sqlExecute("INSERT INTO sol_prestamos (reloj,periodo,ano,fecha,cantidad_sol,cantidad_pag,porciento,descuento_sem," & _
                           "semanas_pag,motivo_pmo,usuario,aprobada) VALUES (" & _
                          "'" & txtReloj.Text & "'," & "'" & AnoPer.Substring(4, 2) & "','" & AnoPer.Substring(0, 4) & "'," & _
                          "'" & FechaSQL(Now.Date) & "'," & txtCantidadSolicitada.Value & "," & txtCantidadPagar.Value & "," & _
                          txtIntereses.Value & "," & RoundUp(txtCantidadPagar.Value / txtSemanas.Value, 2) & "," & _
                          txtSemanas.Value & ",'" & cmbMotivo.Text.Trim & "','" & Usuario & "',0)", "nomina")

                'dtSolicitudes.Rows.Add({txtReloj.Text, AnoPer.Substring(4, 2), AnoPer.Substring(0, 4), FechaSQL(Now.Date), txtCantidadSolicitada.Value, _
                '                        txtCantidadPagar.Value, txtIntereses.Value, RoundUp(txtCantidadPagar.Value / txtSemanas.Value, 2), _
                '                        txtSemanas.Value, cmbMotivo.Text.Trim, vbNull, "0 - Pendiente"})
                'BERE

                'dgTabla.DataSource = sqlExecute("SELECT reloj,periodo,ano,fecha,cantidad_sol,cantidad_pag,porciento,descuento_sem,semanas_pag," & _
                '                   "RTRIM(motivo_pmo) AS motivo_pmo,aprobada," & _
                '                   "IIF(aprobada=0,'0 - Pendiente',IIF(aprobada=1,'1 - Aprobada','2 - Rechazada')) AS estado " & _
                '                   "FROM sol_prestamos WHERE ano+periodo >= '" & InicioAhorroStr & "' ORDER BY aprobada", "nomina")

                dgTabla.DataSource = sqlExecute("SELECT reloj,periodo,ano,fecha,cantidad_sol,cantidad_pag,porciento,descuento_sem,semanas_pag," & _
                                   "RTRIM(motivo_pmo) AS motivo_pmo,aprobada," & _
                                    "(CASE aprobada when 0 then '0 - Pendiente' else (case aprobada when 1 then '1 - Aprobada' else '2 - Rechazada' end ) end) AS estado " & _
                                   "FROM sol_prestamos WHERE ano+periodo >= '" & InicioAhorroStr & "' ORDER BY aprobada", "nomina")


                pnlPrestamo.Visible = False
                btnReporte.PerformClick()
                MostrarInformacion(txtReloj.Text)

                'dtSolicitudes = sqlExecute("SELECT reloj,periodo,ano,fecha,cantidad_sol,cantidad_pag,porciento,descuento_sem,semanas_pag," & _
                '           "RTRIM(motivo_pmo) AS motivo_pmo,aprobada," & _
                '           "IIF(aprobada=0,'0 - Pendiente',IIF(aprobada=1,'1 - Aprobada','2 - Rechazada')) AS estado " & _
                '           "FROM sol_prestamos WHERE ano = '" & Year(Now.Date) & "' ORDER BY aprobada", "nomina")
                'dgTabla.DataSource = dtSolicitudes

            End If
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtCantidadSolicitada_ValueChanged(sender As Object, e As EventArgs) Handles txtCantidadSolicitada.ValueChanged
        CalculaPagos()
    End Sub

    Private Sub dgTabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellContentClick

    End Sub

    Private Sub dgTabla_Paint(sender As Object, e As PaintEventArgs) Handles dgTabla.Paint
        Dim BColor As System.Drawing.Color
        Dim f As Font = dgTabla.DefaultCellStyle.Font
        Try

            For y = 0 To dgTabla.RowCount - 1

                If dgTabla.Item("ColAprobada", y).Value.ToString.Trim = "0" Then
                    BColor = Color.White
                    dgTabla.Rows(y).DefaultCellStyle.Font = New Font(f, FontStyle.Regular)

                ElseIf dgTabla.Item("ColAprobada", y).Value.ToString.Trim = "1" Then
                    BColor = Color.LightGreen
                    dgTabla.Rows(y).DefaultCellStyle.Font = New Font(f, FontStyle.Italic)
                Else
                    BColor = Color.LightGray
                    dgTabla.Rows(y).DefaultCellStyle.Font = New Font(f, FontStyle.Strikeout)
                End If
                dgTabla.Rows(y).DefaultCellStyle.BackColor = BColor
                'dgTabla.Item("concepto", y).Style.BackColor = BColor
                'dgTabla.Item("monto", y).Style.BackColor = BColor
                'dgTabla.Item("descripcion", y).Style.BackColor = BColor
            Next

        Catch ex As Exception
            dgTabla.DefaultCellStyle.Font = New Font(f, FontStyle.Regular)
            dgTabla.DefaultCellStyle.BackColor = Color.White
        End Try
    End Sub
End Class