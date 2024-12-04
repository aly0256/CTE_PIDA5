Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Data
Imports System.Xml
Imports System.Data.Common
Public Class frmCartasGenerales
    Dim dtPredefinidas As New DataTable
    Dim dtDestinatario As New DataTable
    Dim dtRemitente As New DataTable
    Dim dtMensaje As New DataTable
    Dim dtTemp As New DataTable

    Private Sub frmCartasContratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecha.Value = Today
        dtPredefinidas = sqlExecute("SELECT cod_carta,nombre FROM cartasPredefinidas")
        'dtPredefinidas.Rows.Add({"000", "Nuevo formato"})
        cmbPredefinidas.DataSource = dtPredefinidas
        cmbPredefinidas.SelectedValue = "001"

        dtDestinatario = sqlExecute("SELECT * FROM Destinatario")
        cmbDestinatario.DataSource = dtDestinatario
        cmbDestinatario.ValueMember = "cod_destinatario"
        dtRemitente = sqlExecute("SELECT * FROM Remitente")
        cmbRemitente.DataSource = dtRemitente
        cmbRemitente.ValueMember = "cod_remitente"
        dtMensaje = sqlExecute("SELECT * FROM mensaje_cartas")
        cmbMensaje.DataSource = dtMensaje
        cmbMensaje.ValueMember = "cod_mensaje"

        'frmVistaPrevia.vwrReportes.RefreshReport()
    End Sub

    Private Sub cmbPredefinidas_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPredefinidas.SelectedValueChanged
        Try
            If cmbPredefinidas.SelectedValue = "000" Then
                cmbDestinatario.SelectedIndex = 0
                cmbRemitente.SelectedIndex = 0
                cmbMensaje.SelectedIndex = 0
            Else
                dtTemp = sqlExecute("SELECT * FROM cartasPredefinidas WHERE cod_carta = '" & cmbPredefinidas.SelectedValue & "'")
                If dtTemp.Rows.Count > 0 Then
                    cmbDestinatario.SelectedValue = dtTemp.Rows(0).Item("cod_destinatario")
                    cmbRemitente.SelectedValue = dtTemp.Rows(0).Item("cod_remitente")
                    cmbMensaje.SelectedValue = dtTemp.Rows(0).Item("cod_mensaje")


                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub
    Private Sub cmbMensaje_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMensaje.SelectedValueChanged
        dtTemp = sqlExecute("SELECT detalle FROM mensaje_cartas WHERE cod_mensaje = '" & cmbMensaje.SelectedValue & "'")
        If dtTemp.Rows.Count > 0 Then
            txtMensaje.Text = dtTemp.Rows(0).Item(0)
        Else
            txtMensaje.Text = ""
        End If
    End Sub

    Private Sub btnGuardarCambios_Click(sender As Object, e As EventArgs) Handles btnGuardarCambios.Click
        Dim Nmb As String = ""
        Dim Cdg As String
        Dim NRem As String = cmbRemitente.SelectedValue
        Dim NDes As String = cmbDestinatario.SelectedValue
        Dim NMen As String = cmbMensaje.SelectedValue
        If cmbPredefinidas.SelectedValue = "000" Then
            Nmb = InputBox("Nombre del formato", "Guardar cambios")
            If Nmb.Length = 0 Then
                Exit Sub
            End If
            dtTemp = sqlExecute("SELECT MAX(cod_carta) FROM CartasPredefinidas")
            If dtTemp.Rows.Count = 0 Then
                Cdg = 0
            Else
                Cdg = (IIf(IsDBNull(dtTemp.Rows(0).Item(0)), 0, dtTemp.Rows(0).Item(0)) + 1).ToString.PadLeft(3, "0")
            End If
            dtTemp = sqlExecute("INSERT INTO CartasPredefinidas (cod_carta,nombre) VALUES('" & Cdg & "','" & Nmb & "')")
            dtPredefinidas.Rows.Add({Cdg, Nmb})
        Else
            Cdg = cmbPredefinidas.SelectedValue
        End If
        dtTemp = sqlExecute("UPDATE CartasPredefinidas SET cod_remitente = '" & NRem & "', cod_destinatario = '" & NDes & "', cod_mensaje = '" & NMen & "', fotografia = " & IIf(btnFotografia.Value = True, 1, 0) & " WHERE cod_carta = '" & Cdg & "'")
        cmbPredefinidas.SelectedValue = Cdg


    End Sub

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        'LlamarReporte(cmbMensaje.SelectedValue, cmbDestinatario.SelectedValue, cmbRemitente.SelectedValue, txtFecha.Value)
        'ConsultaPersonalVW("SELECT * FROM personalvw" & FiltroReporte & OrdenReporte, dtFiltroPersonal)
        LlamarReporte(cmbMensaje.SelectedValue, cmbDestinatario.SelectedValue, cmbRemitente.SelectedValue, txtFecha.Value)
        Me.Close()
        Me.Dispose()
    End Sub
    Public Sub LlamarReporte(cod_mensaje As String, cod_destinatario As String, cod_remitente As String, Fecha As Date)
        Try

            Dim dtCompa As New DataTable
            Dim dtDetalle As New DataTable
            Dim dtDatosCia As New DataTable

            Dim dtPersonalEspecial As New DataTable
            Dim IncluyePersonal As Boolean = False
            Dim Reporte As String = ""
            Dim FiltroCompania As String = ""
            Dim DatosDLL As New DataTable
            Dim dtInfo As New DataTable
            Dim dtResult As New DataTable
            Application.DoEvents()

            Reporte = DireccionReportes & "Cartas generales.rdl"

            'Asignar datos a dtCompa para asignarlo al frmVistaPrevia.vwrReportes, de acuerdo al valor de FiltroCompania
            If FiltroCompania = "" Then
                'Si no se incluye filtro, tomar el primero de la tabla
                dtCompa = sqlExecute("SELECT cod_comp,nombre,rfc,reg_pat,infonavit,logo,direccion,colonia,ciudad,estado,cod_postal,telefono1 FROM personal.dbo.cias WHERE cia_default = 1")
                FiltroCompania = dtCompa.Rows(0).Item("cod_comp")
            Else
                dtCompa = sqlExecute("SELECT COD_COMP,NOMBRE,RFC,REG_PAT,INFONAVIT,LOGO,direccion,colonia,ciudad,estado,cod_postal,telefono1 FROM personal.dbo.cias WHERE COD_COMP = " & FiltroCompania)
            End If

            dtDetalle = sqlExecute("SELECT SPACE(6) AS reloj, SPACE(50) AS foto, 0 AS incluye_foto,remitente.path_firma, mensaje_cartas.detalle as mensaje,destinatario.nombre AS destinatario,remitente.nombre AS remitente,puesto AS puesto_remitente,GETDATE() AS fecha,SPACE(50) AS fecha_letra FROM mensaje_cartas,destinatario,remitente WHERE cod_mensaje = '" & cmbMensaje.SelectedValue & "' AND cod_destinatario = '" & cmbDestinatario.SelectedValue & "' AND cod_remitente = '" & cmbRemitente.SelectedValue & "'")


            Dim Mensaje As String
            Dim Rl As String
            Dim Fld As String
            Dim Info As String
            Dim y As Integer
            Dim dtRow As DataRow

            Mensaje = dtDetalle.Rows(0).Item("mensaje")

            If Mensaje.Contains("[inicio_viaje]") Then
                frmFecha.ShowDialog(Me)
                If FechaInicial = Nothing Then
                    Exit Sub
                End If
            End If
            For x = 0 To dtFiltroPersonal.Rows.Count - 1
                dtDatosCia = sqlExecute("SELECT cias.nombre AS compania,rfc as rfc_cia,reg_pat,direccion AS direccion_comp,colonia AS colonia_comp, ciudad as ciudad_comp, estado as estado_comp, cod_postal AS cp_comp,rep_legal,puesto as rep_puesto FROM personal.dbo.cias WHERE cod_comp = '" & dtFiltroPersonal.Rows(x).Item("cod_comp") & "'")
                Rl = dtFiltroPersonal.Rows(x).Item("reloj")
                Info = Mensaje


                'horario descripción
                Try
                    Info = Info.Replace("[horario_descripcion]", sqlExecute("select descripcion_larga from horarios where cod_hora = '" & dtFiltroPersonal.Rows(x)("cod_hora") & "'").Rows(0)("descripcion_larga"))
                Catch ex As Exception
                    Info = Info.Replace("[horario_descripcion]", "[nombre_horario] (DESCRIPCION DEL HORARIO NO DISPONIBLE)")
                End Try

                For y = 0 To dtFiltroPersonal.Columns.Count - 1
                    Fld = dtFiltroPersonal.Columns(y).ColumnName.ToLower
                    'If Fld = "sactual" Then Stop

                    If dtFiltroPersonal.Columns(y).DataType.Name = "DateTime" Then
                        If IsDBNull(dtFiltroPersonal.Rows(x).Item(y)) Then
                            Info = Info.Replace("[" & Fld & "]", "---")
                        Else
                            Info = Info.Replace("[" & Fld & "]", FechaMediaLetra(dtFiltroPersonal.Rows(x).Item(y)))
                        End If
                    Else
                        Info = Info.Replace("[" & Fld & "]", dtFiltroPersonal.Rows(x).Item(y).ToString)
                    End If
                Next

                For y = 0 To dtDatosCia.Columns.Count - 1
                    Fld = dtDatosCia.Columns(y).ColumnName
                    If dtDatosCia.Columns(y).DataType.Name = "DateTime" Then
                        If IsDBNull(dtDatosCia.Rows(0).Item(y)) Then
                            Info = Info.Replace("[" & Fld & "]", "---")
                        Else
                            Info = Info.Replace("[" & Fld & "]", FechaCortaLetra(dtDatosCia.Rows(0).Item(y)))
                        End If
                    Else
                        Info = Info.Replace("[" & Fld & "]", dtDatosCia.Rows(0).Item(y).ToString)
                    End If
                Next

                'Nombre completo NOMBRE APATERNO AMATERNO
                Info = Info.Replace("[nombre_completo]", dtFiltroPersonal.Rows(x).Item("nombre") & " " & dtFiltroPersonal.Rows(x).Item("apaterno") & " " & dtFiltroPersonal.Rows(x).Item("amaterno"))

                'Definidos por sexo
                Info = Info.Replace("[al_ala]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "a la", "al"))
                Info = Info.Replace("[el_la]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "la", "el"))
                Info = Info.Replace("[sr(a)]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "señora (ita)", "señor"))

                'Sueldo en letra                
                If dtFiltroPersonal.Rows(x).Item("tipo_periodo").ToString.Trim = "Q" Then
                    Info = Info.Replace("[sactual_letra]", ConvNvo(dtFiltroPersonal.Rows(x).Item("sactual").ToString))
                    Info = Info.Replace("[salario_mensual]", String.Format("{0:C2}", Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual") * 30)))
                    Info = Info.Replace("[salario_mensual_letra]", ConvNvo(Math.Round(Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual")) * 30, 2)))
                Else
                    Info = Info.Replace("[sactual_letra]", ConvNvo(dtFiltroPersonal.Rows(x).Item("sactual").ToString))
                    Info = Info.Replace("[salario_mensual]", String.Format("{0:C2}", Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual") * 30.4)))
                    Info = Info.Replace("[salario_mensual_letra]", ConvNvo(Math.Round(Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual")) * 30.4, 2)))
                End If


                'Fechas de inicio y fin para viaje
                Info = Info.Replace("[inicio_viaje]", FechaMediaLetra(FechaInicial))
                Info = Info.Replace("[fin_viaje]", FechaMediaLetra(FechaFinal))


                Dim dtDiasVacaciones As DataTable = sqlExecute("select * from vacaciones where cod_tipo = '" & dtFiltroPersonal.Rows(x).Item("cod_tipo") & "' and cod_comp = '" & dtFiltroPersonal.Rows(x).Item("cod_comp") & "' and anos = '" & AntiguedadVac(dtFiltroPersonal.Rows(x).Item("alta"), Date.Now) & "'")
                If dtDiasVacaciones.Rows.Count Then
                    Info = Info.Replace("[dias_de_vacaciones]", dtDiasVacaciones.Rows(0)("dias").ToString)
                Else
                    Info = Info.Replace("[dias_de_vacaciones]", "N/A")
                End If



                'Formar el mensaje
                dtRow = dtDetalle.Rows(0)

                dtRow.Item("mensaje") = Info
                dtRow.Item("reloj") = Rl

                If btnFotografia.Value Then
                    'Si se incluye fotografía, tomar el path

                    dtRow.Item("foto") = sqlExecute("SELECT rtrim(PATH_FOTO) as 'path_foto' FROM cias WHERE cia_default = '1'", "KIOSCO").Rows(0).Item("PATH_FOTO").ToString.Trim & Rl.Trim.PadLeft(6, "0") & ".jpg"
                End If
                dtRow.Item("fecha") = txtFecha.Value
                dtRow.Item("fecha_letra") = FechaMediaLetra(txtFecha.Value)
                dtRow.Item("incluye_foto") = IIf(btnFotografia.Value, 1, 0)

                dtDetalle.Rows.Add({dtRow.Item("reloj"), dtRow.Item("foto"), dtRow.Item("incluye_foto"), dtRow.Item("path_firma"), dtRow.Item("mensaje"), dtRow.Item("destinatario"), dtRow.Item("remitente"), dtRow.Item("puesto_remitente"), dtRow.Item("fecha"), dtRow.Item("fecha_letra")})
            Next
            dtDetalle.Rows.RemoveAt(0)

            'Limpiar el ReportViewer, por si hubiera algún frmVistaPrevia.vwrReportes cargado
            frmVistaPrevia.vwrReportes.Clear()
            'Indicar que se ejecutarán frmVistaPrevia.vwrReportess de forma local (no desde servidor SSRS)
            frmVistaPrevia.vwrReportes.ProcessingMode = ProcessingMode.Local
            frmVistaPrevia.vwrReportes.LocalReport.ReportPath = Reporte
            frmVistaPrevia.vwrReportes.LocalReport.DataSources.Clear()
            frmVistaPrevia.vwrReportes.LocalReport.DataSources.Add(New ReportDataSource("Datos", dtDetalle))
            frmVistaPrevia.vwrReportes.LocalReport.DataSources.Add(New ReportDataSource("Compañía", dtCompa))

            frmVistaPrevia.vwrReportes.Dock = DockStyle.Fill
            frmVistaPrevia.vwrReportes.Visible = True


            ''Si no se ha asignado el parámetro COMP, asignarlo
            'If Not myAdapter.SelectCommand.Parameters.Contains("@COMP") Then
            '    myAdapter.SelectCommand.Parameters.Add("@COMP", SqlDbType.Char).Value = FiltroCompania
            'End If

            ''*************************************

            'Dim Parametros(0) As ReportParameter

            'Parametros(0) = New ReportParameter("COMP", FiltroCompania)

            'frmVistaPrevia.vwrReportes.LocalReport.EnableExternalImages = True
            'frmVistaPrevia.vwrReportes.LocalReport.GetParameters()
            'frmVistaPrevia.vwrReportes.LocalReport.SetParameters(Parametros)

            frmVistaPrevia.vwrReportes.LocalReport.EnableExternalImages = True
            frmVistaPrevia.vwrReportes.RefreshReport()
            frmVistaPrevia.ShowDialog()

        Catch ex As Exception
            Debug.Print(ex.Message & vbCrLf & ex.StackTrace)
        Finally
            Application.DoEvents()
        End Try

    End Sub

    Private Sub vwrReportes_DoubleClick(sender As Object, e As EventArgs)
        frmVistaPrevia.vwrReportes.Visible = False
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnVerDestinatario_Click(sender As Object, e As EventArgs) Handles btnVerDestinatario.Click
        Try
            Dim c As String = cmbDestinatario.SelectedValue
            frmDestinatario.ShowDialog(Me)
            dtDestinatario = sqlExecute("SELECT * FROM destinatario")
            cmbDestinatario.DataSource = dtDestinatario
            If Not c = Nothing Then cmbDestinatario.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Focus()
        End Try
    End Sub

    Private Sub btnVerRemitente_Click(sender As Object, e As EventArgs) Handles btnVerRemitente.Click
        Try
            Dim c As String = cmbRemitente.SelectedValue
            frmRemitentes.ShowDialog(Me)
            dtRemitente = sqlExecute("SELECT * FROM remitente")
            cmbRemitente.DataSource = dtRemitente
            If Not c = Nothing Then cmbRemitente.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Focus()
        End Try
    End Sub

    Private Sub btnMensaje_Click(sender As Object, e As EventArgs) Handles btnMensaje.Click
        Try
            Dim c As String = cmbMensaje.SelectedValue
            frmMensajeCartas.ShowDialog(Me)
            dtMensaje = sqlExecute("SELECT * FROM Mensaje_cartas")
            cmbMensaje.DataSource = dtMensaje
            If Not c = Nothing Then cmbMensaje.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Focus()
        End Try
    End Sub
End Class