Imports OfficeOpenXml
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Runtime.InteropServices


'== Forma que carga todas las solicitudes de vacaciones de Kiosco                   18ene2021               Ernesto
Public Class frmSolVacKiosco

    Dim hayInfo As Boolean
    Dim dtSolVacaciones As DataTable = Nothing
    Dim filaSeleccionada As Integer = 0
    Dim errorReporte As Boolean
    Dim archivoCorreo As String = ""
    Dim validaInfo As New ArrayList
    Dim perfil As String = ""


    '== Se cargan las solicitudes de vacaciones provenientes del kiosco
    Private Sub frmSolVacKiosco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '== Información y correo(s) de destinatario(s) para Kiosco
        Try : CargarInformacion() : Catch ex As Exception : End Try
    End Sub

    '== Estado de los controles de la forma
    Private Sub EstadoControles(existeInfo As Boolean)
        Try
            btnEliminar.Visible = (perfil <> "SUPERV")

            txtFechaIni.Text = IIf(Not existeInfo, "", txtFechaIni.Text)
            txtFechaFin.Text = IIf(Not existeInfo, "", txtFechaFin.Text)
            txtFechaRegreso.Text = IIf(Not existeInfo, "", txtFechaRegreso.Text)
            txtDiasTotales.Text = IIf(Not existeInfo, "", txtDiasTotales.Text)

            lblNomEmp.Text = IIf(Not existeInfo, "---", lblNomEmp.Text)
            txtNoSolAnio.Text = IIf(Not existeInfo, "---", txtNoSolAnio.Text)
            txtUltSol.Text = IIf(Not existeInfo, "---", txtUltSol.Text)

            validaInfo.Clear()
            archivoCorreo = ""
            errorReporte = False
            filaSeleccionada = 0

            lblEdoSolicitud.BackColor = Color.SlateGray
            lblEdoSolicitud.Image = My.Resources.Resources.l_disponible
            lblEdoSolicitud.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top

        Catch ex As Exception : End Try
    End Sub

    '== Cargar información en pantalla
    Private Sub CargarInformacion(Optional relojBusqueda As String = "")
        Try
            Dim _Qry As String = "" : Dim _dtTemp As New DataTable
            Dim _regPend As Integer = 0 : Dim _regConf As Integer = 0
            Dim _ciclo As Boolean = True

            While (_ciclo)

                '== Mostrar todos los registos del solicitudes de la tabla 'Solicitudes_Vacaciones'
                _Qry = "SELECT RTRIM(S.RELOJ) AS RELOJ_SUPER, SV.* FROM KIOSCO.dbo.Solicitudes_Vacaciones SV LEFT JOIN PERSONAL.dbo.personal P ON " & _
                                 "P.RELOJ=SV.RELOJ LEFT JOIN PERSONAL.dbo.super S ON P.COD_SUPER=S.COD_SUPER"

                _dtTemp = sqlExecute(_Qry)
                _dtTemp = FiltroDt(_dtTemp, "reloj_super", perfil)

                '== Calcular el no. de pendientes y aprobados
                If _dtTemp.Rows.Count > 0 Then
                    For Each reg As DataRow In _dtTemp.Rows
                        Select Case reg.Item("aprobado").ToString.Trim
                            Case ""
                                _regPend += 1
                            Case "1"
                                _regConf += 1
                        End Select
                    Next
                End If

                '== Labels de información de los aprobados y pendientes
                lblConfirmados.Text = IIf(_regConf = 0 And _regPend = 0, "---", _regConf)
                lblPendientes.Text = IIf(_regConf = 0 And _regPend = 0, "---", _regPend)

                If Not chkMostrarPen.Checked Then
                    _Qry = "SELECT RTRIM(S.RELOJ) AS RELOJ_SUPER, SV.* FROM KIOSCO.dbo.Solicitudes_Vacaciones SV LEFT JOIN PERSONAL.dbo.personal P ON " & _
                            "P.RELOJ=SV.RELOJ LEFT JOIN PERSONAL.dbo.super S ON P.COD_SUPER=S.COD_SUPER " & IIf(perfil = "SUPERV", "WHERE ISNULL(SV.APROBADO,-1)<>0", "")
                Else
                    _Qry = "SELECT RTRIM(S.RELOJ) AS RELOJ_SUPER, SV.* FROM KIOSCO.dbo.Solicitudes_Vacaciones SV LEFT JOIN PERSONAL.dbo.personal P ON " & _
                            "P.RELOJ=SV.RELOJ LEFT JOIN PERSONAL.dbo.super S ON P.COD_SUPER=S.COD_SUPER WHERE ISNULL(SV.APROBADO,-1)=1"
                End If

                dtSolVacaciones = sqlExecute(_Qry)
                _dtTemp = FiltroDt(dtSolVacaciones, "reloj_super", perfil)

                '== Si las solicitudes exceden un plazo de 7 dias desde que se pidio, se cancelan automáticamente
                CancelaSolicitudesVencidas(_dtTemp, _ciclo)
            End While


            If _dtTemp.Rows.Count > 0 Then hayInfo = True Else hayInfo = False
            dgSolicitudes.DataSource = _dtTemp

            '== Se selecciona la fila 1 por default
            EstadoControles(hayInfo)
            InfoSeleccionada(0)

        Catch ex As Exception : End Try
    End Sub

    '== Mostrar información en el resto de los controles si se selecciona una fila
    Private Sub dgSolicitudes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSolicitudes.CellClick
        Try
            filaSeleccionada = e.RowIndex
            InfoSeleccionada(filaSeleccionada)
        Catch ex As Exception
        End Try
    End Sub

    '== Función para filtrar información de datatables de acuerdo a usuario u otro parámetro                            2mayo2022           Ernesto
    Private Function FiltroDt(dtInfo As DataTable, campoFiltro As String, Optional ByRef perfil As String = "") As DataTable
        Try

            '== Determina el tipo de perfil
            Dim tipoPerfil As String = "" : Dim dtRes As New DataTable : Dim filtro As String = "" : Dim relojUsuario As String = ""
            Dim QryGral As String = "SELECT * FROM SEGURIDAD.dbo.appuser WHERE USERNAME='" & Usuario & "'"
            Dim dtUsuario As DataTable = sqlExecute(QryGral)

            If dtUsuario.Rows.Count > 0 Then tipoPerfil = dtUsuario.Rows(0)("cod_perfil").ToString.Trim : relojUsuario = dtUsuario.Rows(0)("reloj").ToString.Trim : perfil = tipoPerfil

            '== Filtro
            Select Case tipoPerfil
                Case "SUPERV"
                    dtRes = dtInfo.Clone : Filtro = campoFiltro & " in ('" & dtUsuario.Rows(0)("reloj").ToString.Trim & "')"
                    For Each x As DataRow In dtInfo.Select(filtro) : dtRes.ImportRow(x) : Next
                Case Else
                    dtRes = dtInfo.Copy
            End Select

            Return dtRes

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Cancelación de vacaciones de acuerdo a ciertos criterios como que hayan pasado 7 dias o la fecha de inicio haya pasado
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CancelaSolicitudesVencidas(dtInfo As DataTable, ByRef ciclo As Boolean)

        ciclo = False

        For Each row In dtInfo.Select("aprobado is null")
            '== Si se cumple un plazo de 7 dias
            If Convert.ToDateTime(FechaSQL(Date.Now)) > Convert.ToDateTime(FechaSQL(row("fecha_solicitud"))).AddDays(7) Then
                sqlExecute("update kiosco.dbo.solicitudes_vacaciones set aprobado=0,motivo_rechazo='Cancelado automáticamente por vencimiento de solicitud: Fecha cancelacion: " & FechaSQL(Date.Now) & "' where id='" & row("id") & "'")
                ciclo = True
            End If

            '== Si la fecha de inicio de la solicitud de vacaciones pasó
            If Convert.ToDateTime(FechaSQL(row("fecha_inicio"))) < Convert.ToDateTime(FechaSQL(Date.Now)) Then
                sqlExecute("update kiosco.dbo.solicitudes_vacaciones set aprobado=0,motivo_rechazo='Cancelado automáticamente por fecha de inicio de solicitud anterior: Fecha cancelacion: " & FechaSQL(Date.Now) & "' where id='" & row("id") & "'")
                ciclo = True
            End If
        Next
    End Sub

    '== Cargar información a controles si se da click a DGV
    Private Sub InfoSeleccionada(filSel As Integer)
        Try
            Dim _aprobado As Integer = -2

            If (hayInfo) Then
                txtFechaIni.Text = FechaCortaLetra(dgSolicitudes.Rows(filSel).Cells("fecha_inicio").Value)
                txtFechaFin.Text = FechaCortaLetra(dgSolicitudes.Rows(filSel).Cells("fecha_fin").Value)
                txtFechaRegreso.Text = FechaCortaLetra(dgSolicitudes.Rows(filSel).Cells("fecha_regreso").Value)
                txtDiasTotales.Text = dgSolicitudes.Rows(filSel).Cells("dias_solicitados").Value
                _aprobado = If(IsDBNull(dgSolicitudes.Rows(filSel).Cells("aprobado").Value), -1, dgSolicitudes.Rows(filSel).Cells("aprobado").Value)
                lblNomEmp.Text = dgSolicitudes.Rows(filSel).Cells("nombre").Value
                txtDetalles.Text = If(IsDBNull(dgSolicitudes.Rows(filSel).Cells("motivo_rechazo").Value), "", dgSolicitudes.Rows(filSel).Cells("motivo_rechazo").Value)

                Dim cont As Integer = 0 : Dim r As String = dgSolicitudes.Rows(filSel).Cells("reloj").Value
                Dim fSol As Date = Nothing : Dim añoActual As Integer = Year(Date.Now)

                For Each info As DataRow In dtSolVacaciones.Select("reloj='" & r & "'", "fecha_solicitud")
                    fSol = info.Item("fecha_solicitud")
                    If Year(fSol) = añoActual Then
                        cont += 1
                    End If
                Next

                txtNoSolAnio.Text = cont.ToString
                txtUltSol.Text = IIf(cont = 0, "---", FechaCortaLetra(fSol))
            End If

            '== Deshabilitar el boton de confirmar si ya esta aprobado
            btnEliminar.Enabled = ({"WME_AD", "RH", "ADMINISTRADOR"}.Contains(perfil) And _aprobado = 0 And hayInfo)
            btnConfirmar.Enabled = ({"SUPERV", "ADMINISTRADOR", "WME_AD", "RH"}.Contains(perfil) And _aprobado < 0 And hayInfo)
            btnCancela.Enabled = ({"SUPERV", "ADMINISTRADOR", "WME_AD", "RH"}.Contains(perfil) And _aprobado < 0 And hayInfo)

            lblEdoSolicitud.BackColor = IIf(_aprobado < 0, Color.SlateGray, IIf(_aprobado = 0, Color.Red, Color.Green))
            lblEdoSolicitud.Image = IIf(_aprobado < 0, My.Resources.Resources.l_disponible, IIf(_aprobado = 0, My.Resources.Resources.l_cancelado, My.Resources.Resources.l_ocupado))
            lblEdoSolicitud.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top

            lblDetalle.Text = IIf(_aprobado < 0, "Detalle de solicitud [Pendiente]", IIf(_aprobado = 0, "Detalle de solicitud [Cancelada]", "Detalle de solicitud [Aprobada]"))
            '  btnReporte.Enabled = ({"SUPERV", "ADMINISTRADOR", "WME_AD", "RH"}.Contains(perfil) And _aprobado = 1 And hayInfo)
            btnReporte.Enabled = ({"SUPERV", "ADMINISTRADOR", "WME_AD", "RH"}.Contains(perfil) And hayInfo) ' AO 2023-07-26: Solicita Miriam V. que se pueda imprimir este aprobado o no
        Catch ex As Exception
        End Try
    End Sub

    '== Función para actualizar o borrar solicitud
    Private Sub ModificarRegistro(filaTabla As Integer, op As String)
        Try
            '== Información del registro
            Dim arr(2) As String : Dim QryModificacion As String = "" : Dim QryConsulta As String = "" : Dim QryComprueba As String = "" : Dim QryHistorial As String = ""
            Dim idRegistro As String = dgSolicitudes.Rows(filaSeleccionada).Cells("ID").Value.ToString.Trim
            Dim relojRegistro As String = dgSolicitudes.Rows(filaSeleccionada).Cells("reloj").Value.ToString.Trim
            Dim fechaSolRegistro As String = FechaCortaLetra(dgSolicitudes.Rows(filaSeleccionada).Cells("fecha_sol").Value)
            Dim nombreRegistro As String = dgSolicitudes.Rows(filaSeleccionada).Cells("nombre").Value.ToString.Trim
            Dim fechaIniRegistro As String = FechaSQL(dgSolicitudes.Rows(filaSeleccionada).Cells("fecha_inicio").Value)
            Dim fechaFinRegistro As String = FechaSQL(dgSolicitudes.Rows(filaSeleccionada).Cells("fecha_fin").Value)
            Dim diasRegistro As Integer = dgSolicitudes.Rows(filaSeleccionada).Cells("dias_solicitados").Value
            Dim anioRegistro As String = (dgSolicitudes.Rows(filaSeleccionada).Cells("fecha_inicio").Value).year
            Dim compRegistro As String = dgSolicitudes.Rows(filaSeleccionada).Cells("cod_comp").Value
            Dim detalleRegistro As String = dgSolicitudes.Rows(filaSeleccionada).Cells("detalles").Value
            Dim regresoRegistro As String = FechaSQL(dgSolicitudes.Rows(filaSeleccionada).Cells("fecha_regreso").Value)
            Dim aprobadoRegistro As String = If(IsDBNull(dgSolicitudes.Rows(filaSeleccionada).Cells("aprobado").Value), -1, dgSolicitudes.Rows(filaSeleccionada).Cells("aprobado").Value)

            Dim relojSuper As String = "" : For Each x As DataRow In dtSolVacaciones.Select("id='" & idRegistro & "'") : relojSuper = x.Item("reloj_super").ToString : Next


            '== Msj personalizado para c/ situación
            Select Case op
                Case "Actualiza"
                    QryModificacion = "UPDATE KIOSCO.dbo.Solicitudes_Vacaciones SET aprobado='1' WHERE ID='" & idRegistro & "'"
                    QryConsulta = "SELECT TOP 1 ID, APROBADO FROM KIOSCO.dbo.Solicitudes_Vacaciones WHERE ID='" & idRegistro & "' AND aprobado is null"
                    QryComprueba = "SELECT TOP 1 * FROM KIOSCO.dbo.Solicitudes_Vacaciones WHERE ID='" & idRegistro & "' and aprobado=1"
                Case "Cancela"
                    QryModificacion = "UPDATE KIOSCO.dbo.Solicitudes_Vacaciones SET aprobado='0',motivo_rechazo='{0}' WHERE ID='" & idRegistro & "'"
                    QryConsulta = "SELECT TOP 1 ID FROM KIOSCO.dbo.Solicitudes_Vacaciones WHERE ID='" & idRegistro & "' AND aprobado is null"
                    QryComprueba = "SELECT TOP 1 ID FROM KIOSCO.dbo.Solicitudes_Vacaciones WHERE ID='" & idRegistro & "' and aprobado='0' and motivo_rechazo='{0}'"
                Case "Elimina"
                    QryModificacion = "DELETE FROM KIOSCO.dbo.Solicitudes_Vacaciones WHERE ID='" & idRegistro & "' and aprobado='0'"
                    QryConsulta = "SELECT TOP 1 ID FROM KIOSCO.dbo.Solicitudes_Vacaciones WHERE ID='" & idRegistro & "' and aprobado='0'"
                    QryHistorial = "INSERT INTO KIOSCO.dbo.Solicitudes_VacHist VALUES ('" & idRegistro & "','" & compRegistro & "','" & relojRegistro & "','" & nombreRegistro & _
                                   "','" & FechaSQL(dgSolicitudes.Rows(filaSeleccionada).Cells("fecha_sol").Value) & "','" & diasRegistro & "','" & FechaSQL(fechaIniRegistro) & "','" & FechaSQL(fechaFinRegistro) & _
                                   "','" & FechaSQL(regresoRegistro) & "','" & relojSuper & "','" & Usuario & "',getdate()," & aprobadoRegistro & ")"
            End Select

            arr(0) = "¿Desea [msj1] la siguiente solicitud de vacaciones?" & vbNewLine & vbNewLine & "Reloj: " & relojRegistro & "" & vbNewLine & "Fecha de solicitud: " & fechaSolRegistro & vbNewLine & " Fecha inicio vacación: " & fechaIniRegistro & vbNewLine & "Cantidad días: " & diasRegistro
            arr(1) = "La solicitud se [msj2] de manera correcta."
            arr(2) = "Ocurrió un error durante la [msj3] de la solicitud. Contacte al administrador del sistema."

            arr(0) = Replace(arr(0), "[msj1]", IIf(op = "Actualiza", "aprobar", IIf(op = "Cancela", "cancelar", "eliminar")))
            arr(1) = Replace(arr(1), "[msj2]", IIf(op = "Actualiza", "aprobó", IIf(op = "Cancela", "canceló", "eliminó")))
            arr(2) = Replace(arr(2), "[msj3]", IIf(op = "Actualiza", "aprobación", IIf(op = "Cancela", "cancelación", "eliminación")))

            '== Comprobar si el registro que se modificará existe
            Dim dtResultado As DataTable = sqlExecute(QryConsulta)

            If dtResultado.Rows.Count > 0 Then
                If MessageBox.Show(arr(0), "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                    '== En esta parte se actualiza el saldo de vacaciones si se autoriza la solicitud, validar registro y envio de correo.
                    If op = "Actualiza" Then
                        If ValidacionesSolicitud(True) Then
                            sqlExecute(QryModificacion)

                            If sqlExecute(QryComprueba).Rows.Count > 0 Then
                                MessageBox.Show(arr(1), "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show(arr(2), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "frmSolVacKiosco", "000", "Registro no actualizado", "Error al actualizar registro")
                            End If
                        Else
                            'MessageBox.Show(arr(2), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            'ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "frmSolVacKiosco", "000", "Registro no actualizado", "Error al actualizar registro")
                        End If

                        '== Aquí se cancela la solicitud del empleado por el supervisor [se incluye motivo de la misma]
                    ElseIf op = "Cancela" Then

                        Dim res As New frmSolVacKioscoMotivo
                        If res.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            sqlExecute(String.Format(QryModificacion, res.strMotivo))

                            '---- AO 2023-06-14: Mandar correo que se rechazó
                            GeneraReporte(True, Nothing)
                            EnviaSolicitud(nombreRegistro, relojRegistro, idRegistro, False)

                            If sqlExecute(String.Format(QryComprueba, res.strMotivo)).Rows.Count > 0 Then
                                MessageBox.Show(arr(1), "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show(arr(2), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "frmSolVacKiosco", "000", "Registro no cancelado", "Error en la cancelacion del registro")
                            End If
                        End If

                        '== Esta sección esta reservada para RH. Elimina las solicitudes no aprobadas y las mete en el historial de solicitudes
                    ElseIf op = "Elimina" Then
                        sqlExecute(QryModificacion)

                        If sqlExecute(QryConsulta).Rows.Count = 0 Then
                            MessageBox.Show(arr(1), "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            sqlExecute(QryHistorial)
                        Else
                            MessageBox.Show(arr(2), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "frmSolVacKiosco", "000", "Registro no eliminado", "Error en la eliminación del registro")
                        End If

                    End If
                End If
            End If

            CargarInformacion()

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante proceso. Inténtelo nuevamente. Si el problema persiste, contacte al administrador del sistema.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "frmSolVacKiosco", Err.Number, ex.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    '== Para mostrar solo pendientes o aprobados también      
    Private Sub chkMostrarPen_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarPen.CheckedChanged
        Try : CargarInformacion() : Catch ex As Exception : End Try
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try : ModificarRegistro(filaSeleccionada, "Actualiza") : Catch ex As Exception : End Try
    End Sub

    Private Sub btnCancela_Click(sender As Object, e As EventArgs) Handles btnCancela.Click
        Try : ModificarRegistro(filaSeleccionada, "Cancela") : Catch ex As Exception : End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try : ModificarRegistro(filaSeleccionada, "Elimina") : Catch ex As Exception : End Try
    End Sub

    '== Solicitud de vacaciones generada en excel
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        GeneraReporte(False)
    End Sub

    '== Función genera reporte
    Private Sub GeneraReporte(enviarCorreo As Boolean, Optional msjRev As ArrayList = Nothing)
        Try
            If Not (hayInfo) Then
                MessageBox.Show("No hay información disponible para generar el reporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                errorReporte = False
                ExcelPermisoAusencia(dtSolVacaciones, enviarCorreo, msjRev)

                If Not errorReporte And Not enviarCorreo Then
                    MessageBox.Show("Se ha generado el reporte con éxito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    '== Checar si el día de regreso es de descanso o festivo
    Private Function DiasAusentismos(inicio As Date, fin As Date, reloj As String) As ArrayList
        Try
            '== NOTA. Para la solicitud de vacaciones, los únicos días que se podrán saltear serán los días de descanso y los festivos, el resto (festivos o ausentismos) 
            '== se respetarán dentro del periodo solicitado. Se validarán al momento de que el supervisor apruebe la solicitud.
            Dim diaTemp As Date = inicio
            Dim diaResultante As Date = Nothing
            Dim diaValido As Boolean
            Dim ciclo As Boolean = False
            Dim diasValidos As New ArrayList

            '== A diferencia de kiosco, se evaluará estrictamente el rango de fechas de la solicitud original
            While (diaTemp >= inicio And diaTemp <= fin)
                For i As Integer = 0 To 3
                    '== Incapacidades
                    If i = 0 And TipoAusentismo(diaTemp, reloj, i) Then
                        diaValido = False
                        diaTemp = diaTemp.AddDays(1)
                        Continue While
                        '== Festivos y descansos
                    ElseIf i > 0 And i < 3 And TipoAusentismo(diaTemp, reloj, i) Then
                        diaValido = False
                        diaTemp = diaTemp.AddDays(1)
                        Continue While
                        '== Ausentismos generales
                    ElseIf i = 3 And TipoAusentismo(diaTemp, reloj, i) Then
                        diaValido = True
                    Else
                        '== Días libres
                        diaValido = True
                    End If
                Next

                '== Guardar los días válidos
                If diaValido Then diasValidos.Add(FechaSQL(diaTemp))
                diaTemp = diaTemp.AddDays(1)
            End While

            Return diasValidos

            ''====================== Es sección se comenta por si alguna vez se requiere generar las solicitudes desde esta forma
            ''== Validar cada día 
            'While Not (ciclo)
            '    For i As Integer = 0 To 3
            '        '== Incapacidades
            '        If i = 0 And TipoAusentismo(diaTemp, reloj, i) Then
            '            diaValido = False
            '            diaTemp = diaTemp.AddDays(1)
            '            Continue While
            '            '== Festivos y descansos
            '        ElseIf i > 0 And i < 3 And TipoAusentismo(diaTemp, reloj, i) Then
            '            diaValido = False
            '            diaTemp = diaTemp.AddDays(1)
            '            Continue While
            '            '== Ausentismos generales
            '        ElseIf i = 3 And TipoAusentismo(diaTemp, reloj, i) Then
            '            diaValido = True
            '        Else
            '            '== Días libres
            '            diaValido = True
            '        End If
            '    Next

            '    '== Guardar los días válidos
            '    If diaValido Then diasValidos.Add(FechaSQL(diaTemp)) : listaTemp.Add(FechaSQL(diaTemp))
            '    diaTemp = diaTemp.AddDays(1)

            '    If listaTemp.Count = numDias + 1 Then
            '        ciclo = True
            '    Else
            '        ciclo = False
            '    End If
            'End While

            'diaResultante = listaTemp.Item(numDias - 1)
            'Return diaResultante
            ''====================== Fin comenta

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '== Ausentismos de una fecha
    Private Function TipoAusentismo(fecha As Date, reloj As String, op As Integer) As Boolean
        Try
            Dim QryGeneral As String = ""
            Dim dtTabla As New DataTable
            Dim dtTemp As New DataTable
            Dim filtro As String = ""

            Select Case op
                Case 0
                    '== Incapacidades que se respetan: 'ING','IXM','IRT','IXT','FES'
                    QryGeneral = "SELECT * FROM TA.DBO.ausentismo WHERE RELOJ='" & reloj & "' AND FECHA>='" & FechaSQL(fecha) & "' AND TIPO_AUS IN ('ING','IXM','IRT','IXT','VAC')"
                    dtTabla = sqlExecute(QryGeneral)
                    filtro = "[fecha]='" & FechaSQL(fecha) & "'"
                Case 1
                    '== Días festivos
                    QryGeneral = "SELECT * FROM TA.dbo.FESTIVOS WHERE FESTIVO >= '" & FechaSQL(fecha) & "'"
                    dtTabla = sqlExecute(QryGeneral)
                    QryGeneral = "SELECT * FROM PERSONAL.dbo.personalvw where reloj='" & reloj & "'"
                    dtTemp = sqlExecute(QryGeneral)
                    filtro = "[festivo]='" & FechaSQL(fecha) & "'"
                Case 2
                    '== Días de descanso
                    QryGeneral = "SELECT pw.RELOJ,d.DIA_ENT,(CASE WHEN COD_DIA='7' THEN '0' ELSE COD_DIA END) AS NUM_DIA FROM PERSONAL.dbo.personalvw pw " & _
                                                   "LEFT JOIN PERSONAL.dbo.dias d ON pw.COD_HORA=d.COD_HORA " & _
                                                   "WHERE pw.reloj = '" & reloj & "' and d.DESCANSO=1"
                    dtTabla = sqlExecute(QryGeneral)
                    filtro = "[num_dia]='" & fecha.DayOfWeek & "'"
                Case 3
                    '== Incapacidades que se sobreescriben
                    QryGeneral = "SELECT * FROM TA.DBO.ausentismo WHERE RELOJ='" & reloj & "' AND FECHA>='" & FechaSQL(fecha) & "' AND TIPO_AUS NOT IN ('ING','IXM','IRT','IXT','FES','VAC')"
                    dtTabla = sqlExecute(QryGeneral)
                    filtro = "[fecha]='" & FechaSQL(fecha) & "'"
            End Select

            For Each rowAus As DataRow In dtTabla.Select(filtro)
                If op = 1 Then
                    For Each rowPer As DataRow In dtTemp.Select(rowAus.Item("filtro").ToString.Trim)
                        Return True
                    Next
                    Return False
                End If
                Return True
            Next

            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function

    '== Función para validar la solicitud de vacaciones (en caso de empalme, generar nuevo rango de fecha y actualizar datos de la sol.)
    Private Function ValidacionesSolicitud(sobreescribeAusentismo As Boolean) As Boolean
        Try
            Dim idRegistro As String = dgSolicitudes.Rows(filaSeleccionada).Cells("ID").Value.ToString.Trim
            Dim relojRegistro As String = dgSolicitudes.Rows(filaSeleccionada).Cells("reloj").Value.ToString.Trim
            Dim fechaSolRegistro As String = FechaCortaLetra(dgSolicitudes.Rows(filaSeleccionada).Cells("fecha_sol").Value)
            Dim nombreRegistro As String = dgSolicitudes.Rows(filaSeleccionada).Cells("nombre").Value.ToString.Trim
            Dim fechaIniRegistro As String = FechaSQL(dgSolicitudes.Rows(filaSeleccionada).Cells("fecha_inicio").Value)
            Dim fechaFinRegistro As String = FechaSQL(dgSolicitudes.Rows(filaSeleccionada).Cells("fecha_fin").Value)
            Dim fechaRegresoRegistro As String = FechaSQL(dgSolicitudes.Rows(filaSeleccionada).Cells("fecha_regreso").Value)
            Dim diasRegistro As Integer = dgSolicitudes.Rows(filaSeleccionada).Cells("dias_solicitados").Value
            Dim anioRegistro As String = (dgSolicitudes.Rows(filaSeleccionada).Cells("fecha_inicio").Value).year
            Dim compRegistro As String = dgSolicitudes.Rows(filaSeleccionada).Cells("cod_comp").Value
            Dim detalleRegistro As String = dgSolicitudes.Rows(filaSeleccionada).Cells("detalles").Value

            '== Si la fecha de inicio de la solicitud es anterior al día actual, manda msj de error
            If Convert.ToDateTime(FechaSQL(Date.Now)) > Convert.ToDateTime(FechaSQL(fechaIniRegistro)) Then
                MessageBox.Show("La solicitud [" & idRegistro & "] que intenta aprobar ya se ha vencido [" & FechaMediaLetra(fechaIniRegistro) & "]. Se recomienda sugerirle al " & _
                                                  "empleado generar una nueva.", "Solicitud vencida",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else
                '== Si el número de días de la solicitud original cambio con esta revisión, se le manda un aviso al usuario para avisar si desea continuar con modificaciones
                '== o sugerirle que informe al empleado para que genere una nueva solicitud.
                Dim diasVacList As ArrayList = DiasAusentismos(fechaIniRegistro, fechaFinRegistro, relojRegistro)
                Dim noDiasRevision As Integer = diasVacList.Count
                Dim msjRevision As New ArrayList

                If noDiasRevision = diasRegistro Then
                    CalcularVacaciones(relojRegistro, compRegistro, noDiasRevision, fechaIniRegistro, idRegistro)

                    If ValidaRegVac(validaInfo) Then
                        GeneraReporte(True, Nothing)
                        EnviaSolicitud(nombreRegistro, relojRegistro, idRegistro, True)
                        Return True
                    Else
                        Return False
                    End If
                Else

                    MessageBox.Show("No se puede continuar con el proceso. Se detectó que no hay días disponibles para el rango de fechas de la solicitud. Puede recomendarse " & _
                                          "al empleado generar una nueva solicitud desde kiosco o acudir a RH." & vbNewLine & vbNewLine & _
                                          "Sol. original: [" & diasRegistro.ToString & " días]" & vbNewLine & _
                                          "Sol. revisada: [" & noDiasRevision.ToString & " días]", "Días insuficientes",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                    'End If
                End If
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    '== Función para enviar correo de aprobación
    Private Sub EnviaSolicitud(nomEmp As String, relojEmp As String, id As String, _aprobado As Boolean)
        Try
            Dim msj As String = "" : Dim destinatario As String = "" : Dim asunto As String = ""
            Dim QryVar As String = "" : Dim dtVar As DataTable : Dim relojSuper As String = "" : Dim nomSuper As String = "" : Dim correoSuper As String = "" : Dim correoDestinarios As String = ""
            Dim correoEmpleado As String = ""

            QryVar = "SELECT variable,valor from KIOSCO.dbo.variables WHERE variable='Correos_SolVac'"
            dtVar = sqlExecute(QryVar)

            '== Información del supervisor
            For Each drow As DataRow In dtSolVacaciones.Select("id ='" & id & "'")
                Dim detallesVar() As String = Split(drow.Item("detalles").ToString.Trim, ",")
                For Each c As String In detallesVar
                    If c.Contains("reloj_super") Then
                        Dim rSuper() As String = Split(c, "=")
                        relojSuper = rSuper(1)

                        '== Nombre de supervisor
                        Dim dtTemp As DataTable
                        QryVar = "SELECT NOMBRES,email_empresa FROM PERSONAL.dbo.personalvw WHERE reloj='" & relojSuper & "'"
                        dtTemp = sqlExecute(QryVar)
                        If dtTemp.Rows.Count > 0 Then
                            nomSuper = dtTemp.Rows(0)("nombres").ToString.Trim
                            correoSuper = If(IsDBNull(dtTemp.Rows(0)("email_empresa").ToString.Trim), "", dtTemp.Rows(0)("email_empresa").ToString.Trim)
                        End If
                        GoTo seguir
                    End If
                Next
            Next


seguir:

            '== Correos de destinatarios [RH]
            For Each dest In dtVar.Rows
                correoDestinarios = If(IsDBNull(dest("valor")), "", "'" & dest("valor").ToString.Replace(",", "','") & "'")
                Dim correoEmpresarial = sqlExecute("select reloj,email_empresa from personal.dbo.personal where reloj in (" & correoDestinarios & ")")
                If correoEmpresarial.Rows.Count > 0 Then
                    correoDestinarios = String.Join(";", From i In correoEmpresarial Select i("email_empresa").ToString.Trim)
                End If
            Next

            If dtVar.Rows.Count > 0 Then
                If correoDestinarios <> ";" Then

                    'AO 2023-06-14: Eliminar comas en los nombres
                    nomEmp = nomEmp.Replace(",", " ")
                    nomSuper = nomSuper.Replace(",", " ")

                    '**********************************************************************************************************************************************************************************************************
                    '**************************************************************************APROBADO VACS*******************************************************************************************************************
                    '**********************************************************************************************************************************************************************************************************
                    If _aprobado Then

                        asunto = "Wollsdorf México - Aprobación de solicitud de vacaciones " & relojEmp

                        '---- Anterior
                        'msj = "A quien corresponda:" & vbNewLine & vbNewLine
                        'msj &= "Se le(s) informa a través de este medio que la solicitud de vacaciones del empleado " & nomEmp.ToUpper & " con número de "
                        'msj &= "reloj " & relojEmp.Trim & " ha sido aprobada por su supervisor " & nomSuper & " con número de reloj " & relojSuper & "." & vbNewLine & vbNewLine
                        'msj &= "Se anexa el documento PDF de la solicitud para su respectiva revisión." & vbNewLine & vbNewLine & vbNewLine & vbNewLine
                        'msj &= "Este correo fue enviado de manera automática desde la interfaz PIDA. Si usted no es el destinatario intencional, usted no debe leer, abrir, copiar, usar o diseminar esta información. " & vbNewLine
                        'msj &= "Si ha recibido esto por error, por favor, notifique al remitente original y borre este correo electrónico de su bandeja de entrada."

                        '---- 2023-06-14:  Nuevo que solicita Miriam, el mensaje de aprobación

                        Dim z As String = "ha sido aprobada. " & Format("Blab", Font.Bold) ' Otra forma de indicar el formato

                        ' Nota: lleva sintaxis de codigo HTML
                        msj = "A quien corresponda:" & vbNewLine & vbNewLine
                        msj &= "Se le informa a través de este medio que la solicitud de vacaciones del empleado " & nomEmp.ToUpper & " con número de "
                        msj &= "reloj " & relojEmp.Trim & "  <b><u>ha sido aprobada.</u></b>" & vbNewLine
                        msj &= "<u>Le pedimos entregar el formato correspondiente a la brevedad para evitar descuentos en la nómina.</u>" & vbNewLine & vbNewLine
                        msj &= "Se anexa el documento PDF de la solicitud para su respectiva revisión." & vbNewLine & vbNewLine
                        msj &= "Este correo fue enviado de manera automática desde la interfaz PIDA. Si usted no es el destinatario intencional, usted no debe leer, abrir, copiar, usar o diseminar esta información. " & vbNewLine
                        msj &= "Si ha recibido esto por error, por favor, notifique al remitente original y borre este correo electrónico de su bandeja de entrada."

                    End If
                    '**********************************************************************************************************************************************************************************************************
                    '**************************************************************************NO APROBADO VACS*******************************************************************************************************************
                    '**********************************************************************************************************************************************************************************************************
                    If Not _aprobado Then

                        asunto = "Wollsdorf México - No Aprobación de solicitud de vacaciones " & relojEmp

                        ' Nota: lleva sintaxis de codigo HTML
                        msj = "A quien corresponda:" & vbNewLine & vbNewLine
                        msj &= "Se le(s) informa a través de este medio que la solicitud de vacaciones del empleado " & nomEmp.ToUpper & " con número de "
                        msj &= "reloj " & relojEmp.Trim & "  <b><u>no ha sido aprobada.</u></b> por lo que le pedimos tomarlo en consideración y en caso de cualquier duda acercase con el coordinador del área" & vbNewLine & vbNewLine
                        msj &= "Se anexa el documento PDF de la solicitud para su respectiva revisión." & vbNewLine & vbNewLine
                        msj &= "Este correo fue enviado de manera automática desde la interfaz PIDA. Si usted no es el destinatario intencional, usted no debe leer, abrir, copiar, usar o diseminar esta información. " & vbNewLine
                        msj &= "Si ha recibido esto por error, por favor, notifique al remitente original y borre este correo electrónico de su bandeja de entrada."
                    End If

                    '**********************************************************************************************************************************************************************************************************
                    '**************************************************************************ENDS NO APROBADO*******************************************************************************************************************
                    '**********************************************************************************************************************************************************************************************************


                    '---Agregar el correo del empleado
                    Dim dtCorreoEmpl As DataTable = sqlExecute("select reloj,email,email_empresa from personal where reloj='" & relojEmp.ToString.Trim & "'", "PERSONAL")
                    If Not dtCorreoEmpl.Columns.Contains("Error") And dtCorreoEmpl.Rows.Count > 0 Then
                        Try : correoEmpleado = dtCorreoEmpl.Rows(0).Item("email").ToString.Trim : Catch ex As Exception : correoEmpleado = "" : End Try                    
                    End If
                    '---Ends add el correo del empleado

                    destinatario = correoDestinarios & If(correoSuper = "", "", ";" & correoSuper) & If(correoEmpleado = "", "", ";" & correoEmpleado) ' Contiene todos los correos a los que estaría llegando

                    Try
                        Dim QI As String = ""
                        If EnviarCorreo(msj, asunto, destinatario, archivoCorreo.Replace(".xlsx", ".pdf")) Then
                            QI = "Insert into envio_recibos_det values ('2060','99','destin','S','VacsKiosco',getdate(),1)"
                            sqlExecute(QI, "NOMINA") ' SI enviado
                        Else
                            QI = "Insert into envio_recibos_det values ('2060','99','destin','S','VacsKiosco',getdate(),0)"
                            sqlExecute(QI, "NOMINA") ' NO enviado
                        End If
                    Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "EnviarCorreoPIDA", Err.Number, ex.Message)
                    End Try



                    '== Eliminar los archivos temporales [excel y pdf]
                    Try
                        System.IO.File.Delete(archivoCorreo)
                        System.IO.File.Delete(archivoCorreo.Replace(".xlsx", ".pdf"))
                    Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "EnviarCorreoPIDA", Err.Number, ex.Message)
                    End Try

                Else
                    MessageBox.Show("No se encuentran definidos los destinarios para el envio de correo. Por favor, comuniquese con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Envia_Correo_Sol_Vacs_Kiosco", Err.Number, ex.Message)
        End Try
    End Sub

#Region "Funciones aplicar vacaciones"
    '== Meter registro de vacaciones
    Private Sub CalcularVacaciones(_r As String, _comp As String, _diasSol As Double, _fechaIni As Date, _idSol As String)

        Dim rl As String = _r.ToString.Trim
        Dim _diasDinero As Double = _diasSol
        Dim _diasTiempo As Double = _diasSol
        Dim _codComp As String = _comp

        Dim _fecha As Date
        Dim _fecha_fin As Date
        Dim _fecha_ini As Date
        Dim _dinero As Double = 0
        Dim _tiempo As Double = 0
        Dim _ano As String = ""
        Dim _prima As Double = 0

        Dim _diasDineroConvertidos As Double = _diasDinero
        Dim _diasTiempoConvertidos As Double = _diasTiempo

        Dim ClaveVA As String
        Dim x As Integer
        Dim AusVac As String = ""
        Dim InsertaVac As Boolean = True
        Dim Respuesta As DialogResult
        Dim _aus_natural As String = ""
        Dim _devengadas As Double = VacacionesDevengadas(rl, Now.Date)
        Dim _semana_captura As Boolean = False
        Dim _tipoPeriodo As String = ""

        '== Obtener tipo periodo del empleado
        Dim dtPeriodoEmp As DataTable = sqlExecute("SELECT tipo_periodo FROM PERSONAL.dbo.personal WHERE reloj='" & rl & "'")
        If dtPeriodoEmp.Rows.Count > 0 Then _tipoPeriodo = dtPeriodoEmp.Rows(0)("tipo_periodo").ToString.Trim

        '== Obtener dias, tiempo, prima, etc
        Dim dtTemp As DataTable

        dtTemp = sqlExecute("SELECT TOP 1 ano,prima,saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & rl & _
         "' ORDER BY fecha_captura DESC,fecha_fin DESC")

        If dtTemp.Rows.Count > 0 Then
            _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero")
            _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo")
            _ano = dtTemp.Rows.Item(0).Item("ano")
            _prima = dtTemp.Rows.Item(0).Item("prima")
        End If

        Try

            _fecha_ini = _fechaIni

            '***** PROCESO PARA APLICAR VACACIONES EN AUSENTISMO *******
            dtTemp = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE tipo_naturaleza = 'V'", "TA")
            If dtTemp.Rows.Count = 0 Then
                AusVac = "VAC"
            Else
                AusVac = dtTemp.Rows(0).Item("tipo_aus")
            End If

            'Revisar ausentismo default y tipo de pago para vacaciones
            dtTemp = sqlExecute("SELECT ausentismo,pago_vacaciones_semana_captura FROM parametros")
            If dtTemp.Rows.Count = 0 Then
                _aus_natural = "AUS"
            Else
                _aus_natural = IIf(IsDBNull(dtTemp.Rows(0).Item("ausentismo")), "AUS", dtTemp.Rows(0).Item("ausentismo")).ToString.Trim
                _semana_captura = IIf(IsDBNull(dtTemp.Rows(0).Item("pago_vacaciones_semana_captura")), False, dtTemp.Rows(0).Item("pago_vacaciones_semana_captura"))
            End If

            _fecha = _fecha_ini

            Dim dtperiodo_ajustesnom As New DataTable
            dtperiodo_ajustesnom.Columns.Add("ano")
            dtperiodo_ajustesnom.Columns.Add("periodo")
            dtperiodo_ajustesnom.Columns.Add("dias")
            dtperiodo_ajustesnom.PrimaryKey = New DataColumn() {dtperiodo_ajustesnom.Columns("ano"), dtperiodo_ajustesnom.Columns("periodo")}

            x = 1
            Do Until x > _diasTiempo
                If Not (Festivo(_fecha, rl) Or DiaDescanso(_fecha, rl)) Then
                    dtTemp = sqlExecute("SELECT TIPO_NATURALEZA,ausentismo.TIPO_AUS,NOMBRE FROM AUSENTISMO LEFT JOIN TIPO_AUSENTISMO ON " & _
                                                        "ausentismo.TIPO_AUS = tipo_ausentismo.TIPO_AUS WHERE RELOJ = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")

                    If dtTemp.Rows.Count > 0 Then
                        If dtTemp.Rows(0).Item("tipo_aus") = _aus_natural Then
                            sqlExecute("DELETE FROM ausentismo  WHERE RELOJ = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                            InsertaVac = True
                        Else

                            '============== En esta parte se evaluara que ausentismos se pueden sobreescribir y cuales no [ING,IXM,IRT,IXT,FES]
                            Dim dtIncapSolVac As DataTable = sqlExecute("SELECT * FROM KIOSCO.DBO.variables WHERE variable='Incapacidades_SolVac'")
                            Dim varIncapSolVac As String = dtTemp.Rows(0)("tipo_aus").ToString.Trim
                            Dim sobreEscribe As Boolean = True

                            If dtIncapSolVac.Rows.Count > 0 Then
                                Dim varTiposAus() = Split(dtIncapSolVac.Rows(0)("valor").ToString.Trim, ",")
                                For i As Integer = 0 To varTiposAus.Count - 1
                                    If varTiposAus(i) = varIncapSolVac Then
                                        sobreEscribe = False
                                        GoTo respuestaMsj
                                    End If
                                Next
                            End If

respuestaMsj:
                            Respuesta = IIf(sobreEscribe, Windows.Forms.DialogResult.Yes, Windows.Forms.DialogResult.No)
                            '============== Fin validación

                            'Respuesta = MessageBox.Show("Existe ausentismo registrado para el día " & FechaMediaLetra(_fecha) & " (" & dtTemp.Rows(0).Item("nombre") & "). ¿Desea sobrescribirlo?",
                            '                            "Ausentismo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)

                            If Respuesta = Windows.Forms.DialogResult.Yes Then
                                sqlExecute("DELETE FROM ausentismo  WHERE RELOJ = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                                InsertaVac = True
                            ElseIf Respuesta = Windows.Forms.DialogResult.No Then
                                InsertaVac = False
                            Else
                                Exit Sub
                            End If

                        End If
                    End If

                    '== Se agrego el id de la solicitud
                    '--AO 2023-12: Se agregó usuario y fecha de captura para tener mayor detalle
                    If InsertaVac Then
                        sqlExecute("INSERT INTO ausentismo (COD_COMP,RELOJ,FECHA,TIPO_AUS,PERIODO,sf_key,USUARIO,FECHA_HORA) VALUES ('" & _
                                   _codComp & "','" & _
                                   rl & "','" & _
                                   FechaSQL(_fecha) & "','" & _
                                   AusVac & "','" & _
                                   ObtenerPeriodo(_fecha) & "','" & _
                                   _idSol & "','" & Usuario & "',getdate())", "TA")

                        _fecha_fin = _fecha
                        x = x + 1

                        Dim ano_pago As String = _fecha.Year
                        Dim periodo_pago As String = _fecha.Month.ToString.PadLeft(2, "0")

                        Dim dtFechaCorte As DataTable = sqlExecute("select * from periodos where ano = '" & ano_pago & "' and periodo = '" & periodo_pago & "' and fecha_fin <= '" & FechaSQL(Now.Date) & "' and isnull(periodo_especial, 0) = 0", "ta")
                        If dtFechaCorte.Rows.Count <= 0 Then
                            Dim dtSiguiente As DataTable = sqlExecute("select * from periodos where fecha_fin > '" & FechaSQL(Now.Date) & "' and isnull(periodo_especial, 0) = 0 order by ano, periodo", "ta")
                            If dtSiguiente.Rows.Count > 0 Then
                                ano_pago = dtSiguiente.Rows(0)("ano")
                                periodo_pago = dtSiguiente.Rows(0)("periodo")
                            Else
                                MessageBox.Show("Es necesario dar de alta los periodos de pago faltantes, si recibe este mensaje por favor contacte a PIDA", "Faltan periodos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If

                        Dim drPeriodoPago As DataRow = dtperiodo_ajustesnom.Rows.Find({ano_pago, periodo_pago})
                        If drPeriodoPago Is Nothing Then
                            drPeriodoPago = dtperiodo_ajustesnom.NewRow
                            drPeriodoPago("ano") = ano_pago
                            drPeriodoPago("periodo") = periodo_pago
                            drPeriodoPago("dias") = 0
                            dtperiodo_ajustesnom.Rows.Add(drPeriodoPago)
                        End If

                        Dim dias_ As Integer = drPeriodoPago("dias")
                        drPeriodoPago("dias") = dias_ + 1

                    End If

                End If
                _fecha = _fecha.AddDays(1)
                InsertaVac = True
            Loop

            '**** VACACIONES PARA SALDOS Y PAGOS *****
            dtTemp = sqlExecute("SELECT TOP 1 ano,prima,saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & rl & _
             "' ORDER BY fecha_captura DESC,fecha_fin DESC")
            If dtTemp.Rows.Count > 0 Then
                _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero")
                _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo")
                _ano = dtTemp.Rows.Item(0).Item("ano")
                _prima = dtTemp.Rows.Item(0).Item("prima")
            End If

            dtTemp = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = 'DIASVA'", "Nomina")
            If dtTemp.Rows.Count > 0 Then
                ClaveVA = dtTemp.Rows.Item(0).Item("misce_clave")
            Else
                ClaveVA = ""
            End If

            _dinero = _dinero - _diasDineroConvertidos
            _tiempo = _tiempo - _diasTiempoConvertidos

            sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                       "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                       rl & "','" & _
                       _fecha.Year & "'," & _
                       _prima & "," & _
                       _dinero & "," & _
                       _tiempo & "," & _
                       _diasDineroConvertidos & "," & _
                       _diasTiempoConvertidos & _
                       ",'VACACIONES','" & _
                       FechaSQL(_fecha_ini) & "','" & _
                       FechaSQL(_fecha_fin) & "','" & _
                       FechaHoraSQL(Now) & "')")

            '---AO 2023-12: Registrar en bitacora_vacaciones para tener mayor detalle:
            Dim Q As String = ""
            Q = "insert into bitacora_vacaciones (RELOJ,FECHA_INI,FECHA_FIN,COMENTARIO,USUARIO,FECHA_CAPTURA) VALUES" & _
                "('" & rl & "','" & FechaSQL(_fecha_ini) & "','" & FechaSQL(_fecha_fin) & "','AGREGADO DESDE SOL_VAC_KIOSCO','" & Usuario & "',GETDATE())"
            sqlExecute(Q, "PERSONAL")

            '**** PROCESO PARA APLICAR VACACIONES EN MISCELANEOS DE NOMINA ******* 
            '--- AOS: Proceso nuevo que evalua dia a dia e inserta de acuerdo a las fechas ini y fin en ajustes_nom (Miscelaneos), ya que puede abarcar uno o mas periodos
            '--- NOTA: Para los 14nales igual lo registra en periodo semanal en ajustes_nom
            Dim diasPag As Double = 0.0
            Try : diasPag = _diasDinero : Catch ex As Exception : diasPag = 0.0 : End Try

            '==Periodo del empleado     junio2021       Ernesto
            ProcInsDiasVaAjNom(rl, diasPag, _fecha_ini, _fecha_fin, _tipoPeriodo)
            RefrescaVacaciones(rl)

            '== Información para validar los registros
            validaInfo.Add(_idSol & "," & FechaSQL(_fecha_ini) & "," & FechaSQL(_fecha_fin) & "," & _diasDineroConvertidos & "," & rl)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    '== Actualizar los saldos en caso de aniversario
    Private Sub RefrescaVacaciones(ByVal rl As String)
        Dim _diasVac As Integer = 0
        Dim _Prima As Integer = 0
        Dim _dinero As Double = 0
        Dim _tiempo As Double = 0
        Dim _dDias As Double

        Dim dtTemp As New DataTable
        Dim dtAlta As DataTable = sqlExecute("SELECT ALTA,cod_tipo FROM PERSONAL.dbo.personal WHERE reloj='" & rl & "'")
        Dim _alta As Date = dtAlta.Rows(0)("alta")

        Dim Antiguedad As Integer = DateDiff(DateInterval.Year, _alta, Now)
        Dim _f_aniversario As New Date(Year(Now), _alta.Month, _alta.Day)
        Dim _f_anterior As New Date(Year(Now) - 1, _alta.Month, _alta.Day)

        Try
            '***** PARA ACTUALIZAR SALDOS CUANDO CUMPLEN ANIVERSARIO
            If Antiguedad >= 1 And Not EsBaja And Now >= _f_aniversario Then
                _diasVac = 0
                _Prima = 0
                dtTemp = sqlExecute("SELECT reloj FROM saldos_vacaciones WHERE reloj = '" & rl & "' AND ano = '" & Year(_f_aniversario) & "' AND aniversario = 1")

                '*** Si ya pasó su aniversario, y no se le han actualizado los saldos, crear registro de aniversario
                If dtTemp.Rows.Count = 0 Then
                    '*** Tomar los saldos anteriores
                    dtTemp = sqlExecute("SELECT TOP 1 saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & rl & "' ORDER BY fecha_captura DESC,fecha_fin DESC")
                    If dtTemp.Rows.Count > 0 Then
                        _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero")
                        _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo")
                    End If

                    dtTemp = sqlExecute("SELECT dias, por_prima FROM vacaciones WHERE cod_comp = '" & Compania & "' AND cod_tipo = '" & dtAlta.Rows(0)("cod_tipo").ToString.Trim & _
                                        "' AND anos = " & Antiguedad)

                    If dtTemp.Rows.Count > 0 Then
                        _diasVac = dtTemp.Rows.Item(0).Item("dias")
                        _Prima = dtTemp.Rows.Item(0).Item("por_prima")

                        '--AOS: 03/04/2020 -  A solicitud del cliente,  cada vez que se cumpla aniversario, se reinicia el saldo y se deja solamente lo ganado, pero que pasa si trae saldo negativo, si debe de restarlo
                        If (_dinero >= 0) Then
                            _dinero = 0
                            _tiempo = 0
                        End If

                        sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,dias,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario,aniversario," & _
                                   "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                                   rl & "','" & _
                                   Year(_f_aniversario) & "'," & _
                                   _diasVac & "," & _
                                   _Prima & "," & _
                                   (_dinero + _diasVac) & "," & _
                                   (_tiempo + _diasVac) & _
                                   ",0,0,'ANIVERSARIO " & Year(_f_aniversario) & "',1,'" & _
                                   FechaSQL(_f_anterior) & "','" & _
                                   FechaSQL(_f_aniversario) & "','" & _
                                   FechaHoraSQL(Now) & "')")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    '== Validar que vacaciones se hayan registrado de manera correcta
    Private Function ValidaRegVac(informacion As ArrayList) As Boolean
        Try
            Dim qryGral As String = "" : Dim dtResultados As DataTable : Dim infoVal(2) As Boolean : Dim res As Boolean
            Dim info() As String = Split(informacion.Item(0), ",")
            Dim id As String = info(0)
            Dim ini As String = info(1)
            Dim fin As String = info(2)
            Dim num As String = info(3)
            Dim rl As String = info(4)

            '== Para la tabla ausentismos
            qryGral = "SELECT * FROM TA.DBO.ausentismo WHERE sf_key='" & id & "' and reloj='" & rl & "'"
            dtResultados = sqlExecute(qryGral)
            If dtResultados.Rows.Count = CInt(num) Then infoVal(0) = True Else infoVal(0) = False

            '== Para la tabla saldo vacaciones
            qryGral = "SELECT * FROM PERSONAL.dbo.saldos_vacaciones WHERE reloj='" & rl & "' and fecha_ini='" & ini & "' and fecha_fin='" & fin & "' and dinero='" & num & "'"
            dtResultados = sqlExecute(qryGral)
            If dtResultados.Rows.Count > 0 Then infoVal(1) = True Else infoVal(1) = False

            '== Para la tabla ajustes nom (PENDIENTE DE CORREGIR EL PROCESO PRINCIPAL)
            Dim rango As String = ini & " al " & fin
            qryGral = "SELECT * FROM nomina.dbo.ajustes_nom WHERE reloj='" & rl & "' and concepto='DIASVA' and numcredito='" & rango & "'"
            dtResultados = sqlExecute(qryGral)
            If dtResultados.Rows.Count > 0 Then infoVal(2) = True Else infoVal(2) = False

            res = infoVal(0) And infoVal(1) And infoVal(2)

            Return res

        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Funciones excel reporte"
    '== Plantilla para el excel 
    Public Sub ExcelPermisoAusencia(ByVal dtInformacion As DataTable, Optional envioCorreo As Boolean = False, Optional msjRev As ArrayList = Nothing)
        Try
            Dim relojSel As String = dgSolicitudes.Rows(filaSeleccionada).Cells("reloj").Value
            Dim id As String = dgSolicitudes.Rows(filaSeleccionada).Cells("id").Value
            Dim PathPlantilla As String = "" : Dim PathGuardar As String = ""
            Dim dtTemp As DataTable = dtInformacion.Clone
            Dim fbd As New SaveFileDialog

            Dim nombreArchivo As String = "PermisoVacKiosco_" & relojSel.Trim & "_" & id.Substring(id.Length - 7, 6)

            For Each drow As DataRow In dtInformacion.Select("reloj='" & relojSel.Trim & "' and id='" & id & "'")
                dtTemp.ImportRow(drow)
            Next

            dtTemp.Columns.Add("nombre_puesto")
            dtTemp.Columns.Add("nombre_depto")
            dtTemp.Rows(0)("nombre_puesto") = ""
            dtTemp.Rows(0)("nombre_depto") = ""

            Dim dtInfo As DataTable = sqlExecute("SELECT TOP 1 reloj,nombre_puesto,nombre_depto FROM PERSONAL.dbo.personalvw WHERE RELOJ='" & relojSel.Trim & "'")

            If dtInfo.Rows.Count > 0 Then
                Try : dtTemp.Rows(0)("nombre_puesto") = dtInfo.Rows(0)("nombre_puesto").ToString.Trim : Catch ex As Exception : End Try
                Try : dtTemp.Rows(0)("nombre_depto") = dtInfo.Rows(0)("nombre_depto").ToString.Trim : Catch ex As Exception : End Try
            End If

            '== Path de la plantilla de excel
            Dim dtPathPlantilla As DataTable = sqlExecute("select path_reportes from parametros", "PERSONAL")

            If (Not dtPathPlantilla.Columns.Contains("Error") And dtPathPlantilla.Rows.Count > 0) Then
                PathPlantilla = IIf(IsDBNull(dtPathPlantilla.Rows(0).Item("path_reportes")), "", dtPathPlantilla.Rows(0).Item("path_reportes").ToString.Trim)
                '== Si se aprueba la solicitud, entonces se envia por correo
                If Not envioCorreo Then
                    fbd.DefaultExt = ".xlsx"
                    fbd.FileName = nombreArchivo
                    fbd.OverwritePrompt = True
                    If fbd.ShowDialog() = DialogResult.OK Then
                        PathGuardar = fbd.FileName
                    Else
                        errorReporte = True
                    End If
                Else
                    PathGuardar = PathPlantilla & nombreArchivo & ".xlsx"
                    archivoCorreo = PathGuardar
                End If

                PathPlantilla = PathPlantilla.Trim & "Permiso de ausencia vacaciones.xlsx"
                Dim archivo As ExcelPackage = New ExcelPackage(New FileInfo(PathPlantilla))
                Dim wb As ExcelWorkbook = archivo.Workbook
                LlenarPlantillaExcel("Sol_Vacaciones_Kiosco", "", dtTemp, PathGuardar, PathPlantilla, msjRev)

                '== Eliminar los archivos temporales [excel]
                Try : System.IO.File.Delete(PathGuardar) : Catch ex As Exception : End Try
            Else
                errorReporte = True
            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante proceso del reporte. Inténtelo nuevamente. Si el problema persiste, por favor, contacte al administrador del sistema.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reporte Sol. Vac. Pida admin kiosco", ex.HResult, ex.Message)
            errorReporte = True
        End Try
    End Sub

    '== MODIFICADO          23nov2021           Ernesto
    Public Sub LlenarPlantillaExcel(nombre_hoja As String, filtro As String, ByRef dtInfo As DataTable, ByRef _PathSave As String, ByRef _PathPlantilla As String,
                                                          Optional msjRev As ArrayList = Nothing) ' Cod que toma librerias para no abrir el office o tenga que estar instalado
        Try

            For Each row As DataRow In dtInfo.Rows
                Dim archivo As ExcelPackage = New ExcelPackage(New FileInfo(_PathPlantilla))
                Dim wb As ExcelWorkbook = archivo.Workbook
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Item(1)
                Dim reloj As String = IIf(IsDBNull(row("RELOJ")), "", row("RELOJ"))
                'Dim _FileName As String = _PathSave & "PermisoVacacionesKiosco_" & reloj.Trim & ".xlsx"

                Dim _FileName As String = _PathSave
                Dim FechaSol As String = FechaCortaLetra(dgSolicitudes.Rows(filaSeleccionada).Cells("fecha_sol").Value)
                Dim Nombres As String = dgSolicitudes.Rows(filaSeleccionada).Cells("nombre").Value
                Dim nombre_puesto As String = IIf(IsDBNull(row("nombre_puesto")), "", row("nombre_puesto"))
                Dim nombre_depto As String = IIf(IsDBNull(row("nombre_depto")), "", row("nombre_depto"))

                '--- Como las columnas son fijas en la plantilla, no es necesario ir de una en una, se dejan fijas Renglones y columnas
                hoja_excel.Cells(13, 4).Value = FechaSol
                hoja_excel.Cells(15, 4).Value = reloj.Trim
                hoja_excel.Cells(15, 12).Value = Nombres.Trim
                hoja_excel.Cells(17, 2).Value = nombre_puesto.Trim
                hoja_excel.Cells(17, 13).Value = nombre_depto.Trim

                '== Datos de la solicitud de vacaciones
                Dim _noDias As String = txtDiasTotales.Text
                Dim _inicioFecha As String = txtFechaIni.Text
                Dim _finFecha As String = txtFechaFin.Text
                Dim _regFecha As String = txtFechaRegreso.Text

                hoja_excel.Cells(21, 4).Value = "X" : hoja_excel.Cells(21, 4).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                hoja_excel.Cells(21, 6).Value = _noDias : hoja_excel.Cells(21, 6).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                hoja_excel.Cells(21, 8).Value = _inicioFecha : hoja_excel.Cells(21, 8).Style.Font.Size = 14
                hoja_excel.Cells(21, 4).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                hoja_excel.Cells(21, 10).Value = _finFecha : hoja_excel.Cells(21, 10).Style.Font.Size = 14
                hoja_excel.Cells(21, 10).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                hoja_excel.Cells(21, 12).Value = _regFecha : hoja_excel.Cells(21, 12).Style.Font.Size = 14
                hoja_excel.Cells(21, 12).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center

                '== Mensaje de revisión (en caso de que hayan salido menos días de los previstos)
                If Not msjRev Is Nothing Then
                    hoja_excel.Cells(21, 6).Value = msjRev.Item(1) : hoja_excel.Cells(21, 6).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    hoja_excel.Cells(47, 1).Value = msjRev.Item(0) : hoja_excel.Cells(47, 1).Style.Font.Size = 14
                End If

                '== Incluir información como el nombre del empleado, supervisor y el gerente de recursos humanos
                Dim dtTemp As DataTable = sqlExecute("select (rtrim(pv.NOMBRE)+' '+rtrim(pv.APATERNO)+' '+rtrim(pv.AMATERNO)) as gerente_rh,s.NOMBRE as supervisor_emp," & _
                                                            "(rtrim(p.NOMBRE)+' '+rtrim(p.APATERNO)+' '+rtrim(p.AMATERNO)) as empleado_nom from PERSONAL.dbo.personalvw pv,PERSONAL.dbo.personal p " & _
                                                            "left join PERSONAL.dbo.super s on p.COD_SUPER=s.COD_SUPER " & _
                                                            "where p.RELOJ='" & reloj.Trim & "' and pv.nombre_puesto='GERENTE DE RECURSOS HUMANOS'")
                Dim super As String = "--"
                Dim gerente_rh As String = "--"
                Dim nombre_emp As String = "--"

                If dtTemp.Rows.Count > 0 Then
                    super = dtTemp.Rows(0)("supervisor_emp").ToString.Trim.ToUpper
                    gerente_rh = dtTemp.Rows(0)("gerente_rh").ToString.Trim.ToUpper
                    nombre_emp = dtTemp.Rows(0)("empleado_nom").ToString.Trim.ToUpper
                End If

                hoja_excel.Cells(57, 2).Value = nombre_emp
                hoja_excel.Cells(57, 8).Value = super
                hoja_excel.Cells(57, 13).Value = gerente_rh

                archivo.SaveAs(New FileInfo(_FileName))
                archivo.Dispose()

                ConvertirExcelPDF(_FileName)
            Next

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante proceso del reporte. Inténtelo nuevamente. Si el problema persiste, por favor, contacte al administrador del sistema.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reporte Sol. Vac. Pida admin kiosco", ex.HResult, ex.Message)
            errorReporte = True
        End Try
    End Sub
#End Region

End Class