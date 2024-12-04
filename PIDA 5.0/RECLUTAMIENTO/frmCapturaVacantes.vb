Imports OfficeOpenXml
Imports System.IO

Public Class frmCapturaVacantes

#Region "Declaraciones"
    Dim dtLista As New DataTable        'Lista de datos para grid
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtDeptos As New DataTable        'Tabla de Departamentos
    Dim dtPlantas As New DataTable        'Tabla de Plantas
    Dim dtCias As New DataTable        'Tabla de Compañías
    Dim dtSupervisores As New DataTable        'Tabla de Plantas
    Dim dtCCostos As New DataTable         'Tabla de Centro de costos
    Dim dtPuestos As New DataTable         'Tabla de Puestos
    Dim dtLocal As New DataTable        'Tabla para otros Procesos
    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim banderaError As Boolean
#End Region

    '*** Funciones ***
    Private Sub MostrarInformacion()
        Dim i As Integer
        Try
            ' If Not dtRegistro.Rows.Count > 0 Or Not dgCalogVacantes.Rows.Count > 0 Then Exit Sub
            If dtRegistro.Rows.Count > 0 Then
                txtCodigo.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_vac")), "", dtRegistro.Rows(0).Item("cod_vac"))
                txtVacante.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("vacante")), "", dtRegistro.Rows(0).Item("vacante"))
                txtVacantes.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("vacantes")), 0, dtRegistro.Rows(0).Item("vacantes"))
                swActivo.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("Activo")), False, CBool(dtRegistro.Rows(0).Item("Activo").ToString))
                cmbFecha.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("vencimiento")), Nothing, Date.Parse(FechaSQL(dtRegistro.Rows(0).Item("vencimiento"))))

                cmbPlanta.SelectedValue = Split(dtRegistro.Rows(0).Item("planta").ToString, "-")(0)
                cmbDepto.SelectedValue = Split(dtRegistro.Rows(0).Item("depto").ToString, "-")(0)
                cmbSupervisor.SelectedValue = Split(dtRegistro.Rows(0).Item("supervisor").ToString, "-")(0)
                cmbCCostos.SelectedValue = Split(dtRegistro.Rows(0).Item("ccostos").ToString, "-")(0)
                cmbPuesto.SelectedValue = Split(dtRegistro.Rows(0).Item("puesto").ToString, "-")(0)
                txtNumRequisicion.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("NumRequisicion")), "", dtRegistro.Rows(0).Item("NumRequisicion"))
                Dim dtTemp = sqlExecute("select cod_posicion, status, num_posicion as posicion from reclutamiento.dbo.posiciones where cod_vacante = '" & txtCodigo.Text & "'")

                If Not DesdeGrid Then
                    i = dtLista.DefaultView.Find(txtCodigo.Text)
                    If i >= 0 Then
                        dgCalogVacantes.FirstDisplayedScrollingRowIndex = i
                        dgCalogVacantes.Rows(i).Selected = True
                    End If
                End If
                DesdeGrid = False
            Else
                txtCodigo.Text = ""
                txtVacante.Text = ""
                cmbPlanta.SelectedIndex = -1
                cmbDepto.SelectedIndex = -1
                cmbSupervisor.SelectedIndex = -1
                cmbCCostos.SelectedIndex = -1
                cmbPuesto.SelectedIndex = -1
                txtVacantes.Value = 0
                cmbFecha.Value = Nothing
                swActivo.Value = False
                txtNumRequisicion.Text = ""
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
        HabilitarBotones()
    End Sub


    Private Sub HabilitarBotones()
        Dim NoRec As Boolean
        NoRec = dgCalogVacantes.Rows.Count = 0

        btnPrimero.Enabled = Not (Agregar Or Editar Or NoRec)
        btnAnterior.Enabled = Not (Agregar Or Editar Or NoRec)
        btnSiguiente.Enabled = Not (Agregar Or Editar Or NoRec)
        btnUltimo.Enabled = Not (Agregar Or Editar Or NoRec)

        btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBuscar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBorrar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnCerrar.Enabled = Not (Agregar Or Editar)

        pnlCatalogo.Enabled = Agregar Or Editar
        btnEditar.Enabled = Not (Not (Editar Or Agregar) And NoRec)
        If Agregar Or Editar Then
            ' Si está activa la edición o nuevo registro
            btnNuevo.Image = PIDA.My.Resources.Ok16
            btnEditar.Image = PIDA.My.Resources.CancelX
            btnNuevo.Text = "Aceptar"
            btnEditar.Text = "Cancelar"
            tabcatalogo.SelectedTabIndex = 0
        Else
            btnNuevo.Image = PIDA.My.Resources.NewRecord
            btnEditar.Image = PIDA.My.Resources.Edit
            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"
        End If
        txtCodigo.Enabled = False

        If Agregar Then
            txtCodigo.Text = IIf(AsignarCodigo() = 0, "", AsignarCodigo())
            txtVacante.Text = ""
            cmbPlanta.SelectedIndex = -1
            cmbDepto.SelectedIndex = -1
            cmbSupervisor.SelectedIndex = -1
            cmbCCostos.SelectedIndex = -1
            cmbPuesto.SelectedIndex = -1
            txtVacantes.Value = 1
            cmbFecha.Value = Nothing
            swActivo.Value = False
            txtVacante.Focus()
            txtNumRequisicion.Text = ""
            Dim dtTemp = sqlExecute("select 1 as status, '' as cod_posicion, '' as posicion")
        ElseIf Editar Then
            txtVacante.Focus()
        ElseIf NoRec Then
            pnlCatalogo.Enabled = False
        End If
    End Sub

    Private Function AsignarCodigo()
        Dim codigo As Integer = 0
        Dim dtCodigo As New DataTable
        Try
            dtCodigo = sqlExecute("select top 1 cod_vac from vacantes order by Cod_Vac desc", "Reclutamiento")
            If dtCodigo.Columns.Count = 1 And dtCodigo.Columns.Contains("ERROR") Then
                codigo = 0
            ElseIf dtCodigo.Rows.Count > 0 Then
                codigo = (Int(dtCodigo.Rows(0).Item("cod_vac").ToString) + 1)
            ElseIf dtCodigo.Rows.Count = 0 Then
                codigo = 1
            End If
        Catch ex As Exception
            codigo = 0
        End Try
        Return codigo
    End Function

    Private Sub ValidarCaptura()
        Try
            If txtCodigo.Text.Trim = "" Or txtCodigo.Text.Trim = "0" Then
                banderaError = True
                MsgBox("No se pudo asiganar un código a la vacante", MsgBoxStyle.Exclamation, "Aviso")
                Exit Sub
            Else
                banderaError = False
            End If

            If txtVacante.Text.Trim = "" Then
                banderaError = True
                MsgBox("Debe ingresar la vacante. Favor de verificar", MsgBoxStyle.Exclamation, "Aviso")
                txtVacante.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbSupervisor.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Se requiere de un supervisor. Favor de verificar", MsgBoxStyle.Exclamation, "Aviso")
                cmbSupervisor.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbPlanta.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione una Planta. Favor de verificar", MsgBoxStyle.Exclamation, "Aviso")
                cmbPlanta.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbDepto.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione un Departamento. Favor de verificar", MsgBoxStyle.Exclamation, "Aviso")
                cmbDepto.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbCCostos.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione un Centro de Costos. Favor de verificar", MsgBoxStyle.Exclamation, "Aviso")
                cmbCCostos.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbPuesto.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione un Puesto. Favor de verificar", MsgBoxStyle.Exclamation, "Aviso")
                cmbPuesto.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If txtVacantes.Value = 0 Then
                banderaError = True
                MsgBox("Seleccione un valor mayor en [Num. Vacantes]. Favor de verificar", MsgBoxStyle.Exclamation, "Aviso")
                txtVacantes.Focus()
            Else
                banderaError = False
            End If

            If cmbFecha.Value = Nothing Then
                banderaError = True
                MsgBox("Seleccione una fecha de vencimiento. Favor de verificar", MsgBoxStyle.Exclamation, "Aviso")
                cmbFecha.Focus()
            Else
                If FechaSQL(cmbFecha.Value) < FechaSQL(Now) Then
                    banderaError = True
                    MsgBox("La fecha de vencimiento debe ser igual o mayor a la actual. Favor de verificar", MsgBoxStyle.Exclamation, "Aviso")
                    cmbFecha.Focus()
                    'If MessageBox.Show("La fecha de vencimiento seleccionada ya expiró, por lo que la vacante no será dada de alta.¿Desea continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    '    banderaError = False
                    'Else
                    '    banderaError = True
                    'End If
                    'swActivo.Value = False
                Else
                    banderaError = False
                End If
            End If

            If txtNumRequisicion.Text.Trim = "" Then
                banderaError = True
                MsgBox("Debe ingresar el Numero de Requisicion. Favor de verificar", MsgBoxStyle.Exclamation, "Aviso")
                txtNumRequisicion.Focus()
                Exit Sub
            Else
                banderaError = False
            End If
        Catch ex As Exception
            banderaError = True
        End Try
    End Sub

    Private Sub frmCatalogoVacantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            banderaError = False
            ActualizarActivoVacante()
            dtLista = sqlExecute("select top 1000 cod_vac as 'Codigo',planta as 'Planta',supervisor as 'Supervisor', depto as 'Depto',CCostos as 'CCostos', vacante as 'Vacante',Activo as 'Activa', Vencimiento ,'' as imagen from vacantes order by cod_vac desc", "Reclutamiento")
            dtLista.DefaultView.Sort = "Codigo"
            dgCalogVacantes.DataSource = dtLista
            dgCalogVacantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'dgCalogVacantes.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            'Obtener unicamente las plantas de Personal que tengan codigo de planta y nombre
            dtPlantas = sqlExecute("select distinct Ltrim(Rtrim(isnull(cod_planta,''))) as cod_planta, Ltrim(Rtrim(isnull(nombre,''))) as nombre from plantas where Ltrim(Rtrim(isnull(cod_planta,''))) <> '' and Ltrim(Rtrim(isnull(nombre,''))) <> '' order by cod_planta")
            cmbPlanta.DataSource = dtPlantas
            cmbPlanta.SelectedIndex = -1

            'Obtener los supervisores
            'dtSupervisores = sqlExecute("select distinct Ltrim(Rtrim(isnull(cod_super,''))) as cod_super, Ltrim(Rtrim(isnull(nombre,''))) as nombre from super where Ltrim(Rtrim(isnull(cod_super,''))) <> '' and Ltrim(Rtrim(isnull(nombre,''))) <> '' order by cod_super")
            'cmbSupervisor2.DataSource = dtSupervisores
            'cmbSupervisor2.SelectedIndex = -1

            'Mostrar todos los empleados
            dtSupervisores = sqlExecute("SELECT reloj, (rtrim(nombre) + ' ' + rtrim(apaterno)) as nombres from personalvw where cod_comp = 'WME'  and baja is null ORDER BY reloj")
            cmbSupervisor.DataSource = dtSupervisores
            cmbSupervisor.ValueMember = "reloj"
            cmbSupervisor.DisplayMembers = "reloj, nombres"

            'Obtener unicamente los departamentos de Personal que tengan codigo de departamento y nombre
            dtDeptos = sqlExecute("select distinct Ltrim(Rtrim(isnull(cod_depto,''))) as cod_depto, Ltrim(Rtrim(isnull(nombre,''))) as nombre from deptos where  Ltrim(Rtrim(isnull(cod_depto,''))) <> '' and Ltrim(Rtrim(isnull(nombre,''))) <> '' order by cod_depto")
            cmbDepto.DataSource = dtDeptos
            cmbDepto.SelectedIndex = -1

            dtCCostos = sqlExecute("select distinct Ltrim(Rtrim(isnull(centro_costos,''))) as centro_costos,Ltrim(Rtrim(isnull(nombre,''))) as nombre from c_costos where Ltrim(Rtrim(isnull(centro_costos,''))) <> '' and Ltrim(Rtrim(isnull(nombre,''))) <> '' order by centro_costos")
            cmbCCostos.DataSource = dtCCostos
            cmbCCostos.SelectedIndex = -1

            dtPuestos = sqlExecute("select distinct Ltrim(Rtrim(isnull(cod_puesto,''))) as cod_puesto,Ltrim(Rtrim(isnull(nombre,''))) as nombre from puestos where Ltrim(Rtrim(isnull(cod_puesto,''))) <> '' and Ltrim(Rtrim(isnull(nombre,''))) <> '' and activo = 1 and cod_comp = 'WME' order by cod_puesto")
            cmbPuesto.DataSource = dtPuestos
            cmbPuesto.SelectedIndex = -1

            dtRegistro = sqlExecute("select top 1 * from vacantes order by cod_vac ASC", "Reclutamiento")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim planta As String = ""
        Dim supervisor As String = ""
        Dim depto As String = ""
        Dim ccostos As String = ""
        Dim puesto As String = ""
        Dim mensaje As String = ""
        Dim puesto_cod As String = ""
        Dim Archivo As String
        Try
            If Agregar Then
                mensaje = "Agregar"
                ValidarCaptura()
                If banderaError Then
                    Exit Sub
                End If
                planta = cmbPlanta.Text.Trim.Replace(",", "-")
                supervisor = cmbSupervisor.Text.Trim.Replace(",", "-")
                depto = cmbDepto.Text.Trim.Replace(",", "-")
                ccostos = cmbCCostos.Text.Trim.Replace(",", "-")
                puesto = cmbPuesto.Text.Trim.Replace(",", "-")
                'dtLocal = sqlExecute("select cod_sf from personal.dbo.puestos where cod_puesto = '" & Split(cmbPuesto.Text.Trim, ",")(0) & "'")
                'If dtLocal.Rows.Count > 0 Then
                '    puesto_cod_sf = dtLocal.Rows(0).Item("cod_sf").ToString.Trim
                'End If
                puesto_cod = Split(cmbPuesto.Text.Trim, ",")(0)
                dtLocal = sqlExecute("select cod_vac from vacantes where cod_vac = '" & txtCodigo.Text.Trim & "' ", "Reclutamiento")
                If dtLocal.Rows.Count > 0 Then
                    MsgBox("Ya existe una vacante con el codigo [" & txtCodigo.Text.Trim & "]", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If
                dtLocal = sqlExecute("insert into vacantes values (" & txtCodigo.Text & ",'" & supervisor & "','" & planta & "','" & depto & "','" & txtVacante.Text & "'," & txtVacantes.Value & ",getdate(),'" & Usuario & "','" & FechaSQL(cmbFecha.Value) & "'," & IIf(swActivo.Value, 1, 0) & ",'" & ccostos & "','" & Split(cmbPlanta.Text.Trim, ",")(0) & "','" & puesto & "','" & puesto_cod & "','" & txtNumRequisicion.Text.Trim & "')", "Reclutamiento")
                If dtLocal.Columns.Count = 1 Then
                    MsgBox("Error al intentar dar de alta la vacante. Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                Else
                    MsgBox("Vacante dada de alta satisfactoriamente", MsgBoxStyle.Information, "Información")
                    Agregar = False
                End If
            ElseIf Editar Then
                ' Si Editar, entonces guardar cambios a registro
                mensaje = "Editar"
                ValidarCaptura()
                If banderaError Then
                    Exit Sub
                End If
                planta = cmbPlanta.Text.Trim.Replace(",", "-")
                supervisor = cmbSupervisor.Text.Trim.Replace(",", "-")
                depto = cmbDepto.Text.Trim.Replace(",", "-")
                ccostos = cmbCCostos.Text.Trim.Replace(",", "-")
                puesto = cmbPuesto.Text.Trim.Replace(",", "-")
                'dtLocal = sqlExecute("select cod_sf from personal.dbo.puestos where cod_puesto = '" & Split(cmbPuesto.Text.Trim, ",")(0) & "' and cod_comp = 'WME'")
                'If dtLocal.Rows.Count > 0 Then
                '    puesto_cod_sf = dtLocal.Rows(0).Item("cod_sf").ToString.Trim
                'End If
                puesto_cod = Split(cmbPuesto.Text.Trim, ",")(0)
                dtLocal = sqlExecute("UPDATE vacantes SET Supervisor='" & supervisor & "',Planta='" & planta & "',cod_planta='" & Split(cmbPlanta.Text.Trim, ",")(0) & "',Depto='" & depto & "', " & _
                                     "Vacante='" & txtVacante.Text & "',Vacantes = '" & txtVacantes.Value & "', Usuario ='" & Usuario & "', " & _
                                     "Vencimiento='" & FechaSQL(cmbFecha.Value) & "',Activo ='" & IIf(swActivo.Value, 1, 0) & "',CCostos = '" & ccostos & "',puesto = '" & puesto & "', cod_puesto = '" & puesto_cod & "', NumRequisicion = '" & txtNumRequisicion.Text & "' where Cod_Vac = '" & txtCodigo.Text & "' ", "Reclutamiento")
                If dtLocal.Columns.Count = 1 Then
                    MsgBox("Error al intentar actualizar la vacante. Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                Else
                    MsgBox("Vacante actualizada satisfactoriamente", MsgBoxStyle.Information, "Información")
                    Agregar = False
                End If
            Else
                Agregar = True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            banderaError = True
        End Try
        'If banderaError Then
        '    Exit Sub
        'End If
        Editar = False
        HabilitarBotones()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            HabilitarBotones()
            cmbSupervisor.Focus()
        Else
            Editar = False
        End If
        Agregar = False
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If MessageBox.Show("¿Está seguro de borrar la vacante " & RTrim(txtVacante.Text) & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            dtLocal = sqlExecute("DELETE FROM vacantes WHERE cod_vac = '" & RTrim(txtCodigo.Text) & "'", "Reclutamiento")

            If dtLocal.Columns.Count = 1 And dtLocal.Columns.Contains("ERROR") Then

                MsgBox("No se pudo eliminar la vacante " & txtVacante.Text.Trim, MsgBoxStyle.Exclamation, "Aviso")
            Else
                MsgBox("La vacante " & txtVacante.Text.Trim & " ha sido eliminada correctamente", MsgBoxStyle.Information, "Informe")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub dgCalogVacantes_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgCalogVacantes.RowEnter
        On Error Resume Next
        Dim cod As String
        DesdeGrid = True
        cod = dgCalogVacantes.Item("ColCodigo", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * from vacantes WHERE cod_vac = '" & cod & "'", "Reclutamiento")
        MostrarInformacion()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim BuscarVacantes As frmBuscarVacantes = New frmBuscarVacantes
            BuscarVacantes.ShowDialog()
            Dim Vacante As String
            Vacante = BuscarVacantes.CodVac.Trim
            If Vacante <> "CANCELAR" Then
                dtRegistro = sqlExecute("SELECT * from vacantes WHERE cod_vac = '" & Vacante & "'", "Reclutamiento")
                MostrarInformacion()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("vacantes", "cod_vac", dtRegistro, "Reclutamiento")
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("vacantes", "cod_vac", dtRegistro, "Reclutamiento")
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("vacantes", "cod_vac", RTrim(txtCodigo.Text), dtRegistro, "Reclutamiento")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("vacantes", "cod_vac", RTrim(txtCodigo.Text), dtRegistro, "Reclutamiento")
        MostrarInformacion()
    End Sub

    Private Sub cmbFecha_ValueChanged(sender As Object, e As EventArgs) Handles cmbFecha.ValueChanged
        'Try
        '    If Agregar Or Editar Then
        '        If FechaSQL(cmbFecha.Value) >= FechaSQL(Now) Then
        '            swActivo.Value = True
        '        Else
        '            swActivo.Value = False
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub dgCalogVacantes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgCalogVacantes.CellFormatting
        Try
            If Me.dgCalogVacantes.Columns(e.ColumnIndex).Name = "ColImagen" Then

                If CDbl(Me.dgCalogVacantes.Rows(e.RowIndex).Cells("ColActiva").Value) = True Then
                    e.Value = New Bitmap(My.Resources.Ok16)
                ElseIf CDbl(Me.dgCalogVacantes.Rows(e.RowIndex).Cells("ColActiva").Value) = False Then
                    e.Value = New Bitmap(My.Resources.CancelX)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

    End Sub

    Private Sub cmbDepto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDepto.SelectedValueChanged
        'If cmbDepto.SelectedValue <> Nothing Then
        '    dtCCostos = sqlExecute("select top 1 Ltrim(Rtrim(isnull(centro_costos,''))) as centro_costos,Ltrim(Rtrim(isnull(nombre,''))) as nombre from personal.dbo.c_costos where centro_costos = (select top 1 centro_costos from personal.dbo.deptos where cod_depto = '" & cmbDepto.SelectedValue.ToString & "')")
        '    If dtCCostos.Rows.Count > 0 Then
        '        cmbCCostos.SelectedValue = dtCCostos.Rows(0).Item("centro_costos").ToString()
        '    Else
        '        cmbCCostos.SelectedIndex = -1
        '    End If
        'End If
    End Sub

    Private Sub cmbSupervisor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbSupervisor.Validating
        Try
            If cmbSupervisor.SelectedValue <> "" Then
                dtTemporal = sqlExecute("SELECT (rtrim(nombre) + ' ' + rtrim(apaterno)) as nombres from personalvw WHERE reloj = '" & cmbSupervisor.SelectedValue & "' and baja is null")
                If dtTemporal.Rows.Count = 0 Then
                    'txtNombre.Text = "NO LOCALIZADO"
                Else
                    'txtNombre.Text = StrConv(dtTemporal.Rows(0).Item("nombres").ToString.Trim, VbStrConv.ProperCase)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbSupervisor_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbSupervisor.ButtonCustomClick
        Try
            'Reloj = "CANCEL"
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                'MostrarInformacion()
                cmbSupervisor.SelectedValue = Reloj
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbDepto_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbDepto.ButtonCustomClick
        Try
            Dim Cod As String
            Compania = "WME"
            Cod = Buscar("deptos", "cod_depto", "deptos", FiltrarCompania:=True, FiltrarInactivos:=True)
            If Cod <> "CANCELAR" Then
                cmbDepto.SelectedValue = Cod
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbPuesto_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbPuesto.ButtonCustomClick
        Try
            Dim Cod As String
            'Dim CodSF As String = ""
            Dim CodPuesto As String = ""
            Compania = "WME"
            Cod = Buscar("puestos", "cod_puesto", "puestos", FiltrarCompania:=True, FiltrarInactivos:=True)
            'Cod = Buscar("puestos", "cod_sf", "puestos", FiltrarCompania:=True, FiltrarInactivos:=True)
            If Cod <> "CANCELAR" Then
                dtLocal = sqlExecute("select cod_puesto from personal.dbo.puestos where cod_puesto = '" & Cod & "'")
                'dtLocal = sqlExecute("select cod_sf from personal.dbo.puestos where cod_sf = '" & Cod & "'")
                If dtLocal.Rows.Count > 0 Then
                    'CodSF = dtLocal.Rows(0).Item("cod_sf").ToString.Trim
                    CodPuesto = dtLocal.Rows(0).Item("cod_puesto").ToString.Trim
                End If
                'cmbPuesto.SelectedValue = CodSF
                cmbPuesto.SelectedValue = CodPuesto
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If InStr(1, "1234567890" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub cmbCCostos_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbCCostos.ButtonCustomClick
        Try
            Dim Cod As String
            Dim CentroCostos As String = ""
            Compania = "WME"
            Cod = Buscar("c_costos", "centro_costos", "centro de costos", FiltrarCompania:=True, FiltrarInactivos:=True)
            If Cod <> "CANCELAR" Then
                dtLocal = sqlExecute("select centro_costos from personal.dbo.c_costos where centro_costos = '" & Cod & "'")
                If dtLocal.Rows.Count > 0 Then
                    CentroCostos = dtLocal.Rows(0).Item("centro_costos").ToString.Trim
                End If
                cmbCCostos.SelectedValue = CentroCostos
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class