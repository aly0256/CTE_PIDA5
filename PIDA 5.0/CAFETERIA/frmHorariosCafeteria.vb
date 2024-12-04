Public Class frmHorariosCafeteria
    '   Dim dtCias As New DataTable
    Dim dtTurnos As New DataTable
    Dim dtDias As New DataTable
    Dim dtHorarios As New DataTable
    Dim dtTemp As New DataTable
    Dim dtLista As New DataTable

    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim DesdeGrid As Boolean
    Dim CodHora As String ', CodComp As String

    Private Sub frmHorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Agregar = False
        Editar = False

        dtLista = sqlExecute("SELECT cod_horario as 'Código',Nombre FROM horarios", "cafeteria") 'cod_comp as 'Compañía',
        dtLista.DefaultView.Sort = "Código"

        dgTabla.DataSource = dtLista
        dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        cmbServicio.Items.Add("DESAYUNO")
        cmbServicio.Items.Add("COMIDA")
        cmbServicio.Items.Add("CENA")

        dtTurnos = sqlExecute("select cod_turno,nombre from turnos where cod_comp ='090'")
        cmbTurno.DataSource = dtTurnos
        Dim r As DataRow = dtTurnos.NewRow
        r.Item("COD_TURNO") = "0"
        r.Item("NOMBRE") = "TIEMPO EXTRA"
        dtTurnos.Rows.Add(r)
        'dtCias = sqlExecute("SELECT cod_comp,nombre FROM cias")
        ' cmbCia.DataSource = dtCias

        DesdeGrid = False
        dtHorarios = sqlExecute("SELECT TOP 1 * FROM horarios ORDER BY cod_horario ASC", "cafeteria")
        If dtHorarios.Rows.Count > 0 Then MostrarInformacion()
        HabilitarBotones()
    End Sub

    Sub MostrarInformacion()
        Dim i As Integer
        Try
            ' CodComp = dtHorarios.Rows.Item(0).Item("cod_comp")
            CodHora = dtHorarios.Rows.Item(0).Item("cod_horario")

            txtCodigo.Text = CodHora
            txtNombre.Text = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("nombre")), "", dtHorarios.Rows.Item(0).Item("nombre")).ToString.Trim
            '  cmbCia.SelectedValue = CodComp

            txtHoraInicio.Value = Now.Date.Add(TimeSpan.Parse(IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("hora_inicio")), "00:00:00", dtHorarios.Rows.Item(0).Item("hora_inicio")).ToString))
            txtHoraFin.Value = Now.Date.Add(TimeSpan.Parse(IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("hora_fin")), "00:00:00", dtHorarios.Rows.Item(0).Item("hora_fin")).ToString))
            cmbTurno.SelectedValue = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("turno")), "", dtHorarios.Rows.Item(0).Item("turno"))
            'txtCosto.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("COSTO")), 0, dtHorarios.Rows.Item(0).Item("COSTO"))

            cmbServicio.Text = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("servicio")), "", dtHorarios.Rows.Item(0).Item("servicio")).ToString.Trim
            cmbPlanta.Text = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("PLANTA")), "", dtHorarios.Rows.Item(0).Item("PLANTA")).ToString.Trim
            swLunes.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("lunes")), False, dtHorarios.Rows.Item(0).Item("lunes"))
            swMartes.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("martes")), False, dtHorarios.Rows.Item(0).Item("martes"))
            swMiercoles.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("miercoles")), False, dtHorarios.Rows.Item(0).Item("miercoles"))
            swJueves.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("jueves")), False, dtHorarios.Rows.Item(0).Item("jueves"))
            swViernes.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("viernes")), False, dtHorarios.Rows.Item(0).Item("viernes"))
            swSabado.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("sabado")), False, dtHorarios.Rows.Item(0).Item("sabado"))
            swDomingo.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("domingo")), False, dtHorarios.Rows.Item(0).Item("domingo"))

            ' txtCosto.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("costo")), 0, dtHorarios.Rows.Item(0).Item("hrs_sale"))
            ' txtCostoFin.Value = IIf(IsDBNull(dtHorarios.Rows.Item(0).Item("costo_fin")), 0, dtHorarios.Rows.Item(0).Item("costo_fin"))

            If Not DesdeGrid Then
                i = dtLista.DefaultView.Find(txtCodigo.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If
            DesdeGrid = False
            'HabilitarBotones()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("horarios", "cod_horario", CodHora, dtHorarios, "cafeteria")
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("horarios", "cod_horario", dtHorarios, "cafeteria")
        MostrarInformacion()
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("horarios", "cod_horario", dtHorarios, "cafeteria")
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("horarios", "cod_horario", CodHora, dtHorarios, "cafeteria")
        MostrarInformacion()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("cafeteria.dbo.horarios", "cod_horario", "HORARIOS", False)
        If Cod <> "CANCELAR" Then
            dtHorarios = sqlExecute("SELECT * from horarios WHERE cod_horario = '" & Cod & "'", "cafeteria")
            MostrarInformacion()
        End If

    End Sub

    Private Sub HabilitarBotones()
        Dim NoRec As Boolean
        NoRec = dgTabla.Rows.Count = 0
        btnPrimero.Enabled = Not (Agregar Or Editar Or NoRec)
        btnAnterior.Enabled = Not (Agregar Or Editar Or NoRec)
        btnSiguiente.Enabled = Not (Agregar Or Editar Or NoRec)
        btnUltimo.Enabled = Not (Agregar Or Editar Or NoRec)
        btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)

        btnBuscar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBorrar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnCerrar.Enabled = Not (Agregar Or Editar Or NoRec)
        pnlDatos.Enabled = Agregar Or Editar

        btnEditar.Enabled = Not (Not (Editar Or Agregar) And NoRec)


        If Agregar Or Editar Then
            ' Si está activa la edición o nuevo registro
            btnNuevo.Image = PIDA.My.Resources.Ok16
            btnEditar.Image = PIDA.My.Resources.CancelX
            btnNuevo.Text = "Aceptar"
            btnEditar.Text = "Cancelar"
            tabBuscar.SelectedTabIndex = 0
        Else

            btnNuevo.Image = PIDA.My.Resources.NewRecord
            btnEditar.Image = PIDA.My.Resources.Edit

            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"
        End If

        txtCodigo.Enabled = Agregar
        ' cmbCia.Enabled = Agregar

        If Agregar Then
            txtCodigo.Text = ""
            txtNombre.Text = ""
            'txtCosto.Value = 0
            txtCodigo.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If
        RevisaExcepciones(Me, "", True)
    End Sub

    Private Sub dgTabla_DoubleClick(sender As Object, e As EventArgs)
        Try
            tabBuscar.SelectedTabIndex = 0
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub dgTabla_RowEnter(sender As Object, e As DataGridViewCellEventArgs)
        Try
            Dim cod As String ', nom As String

            DesdeGrid = True

            cod = dgTabla.Item("Código", e.RowIndex).Value
            'nom = dgTabla.Item("Compañía", e.RowIndex).Value
            dtHorarios = sqlExecute("SELECT * from horarios WHERE cod_horario = '" & cod & "'", "cafeteria")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        '   Dim Comp As String
        Dim Hora As String
        Dim Cadena As String = ""
        Try

            Hora = txtCodigo.Text
            '  Comp = cmbCia.SelectedValue

            If Agregar Then
                ' Si Agregar, revisar si existe cod_comp+cod_depto
                dtTemporal = sqlExecute("SELECT cod_horario FROM horarios where cod_horario = '" & txtCodigo.Text & "'", "cafeteria")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                Else

                    Cadena = "INSERT INTO horarios (COD_HORARIO,NOMBRE,SERVICIO,HORA_INICIO,HORA_FIN,TURNO,LUNES,MARTES,MIERCOLES,JUEVES,VIERNES,SABADO,DOMINGO,PLANTA) VALUES ("
                    Cadena = Cadena & "'" & txtCodigo.Text & "','" & txtNombre.Text & "','" & cmbServicio.Text & "','" & txtHoraInicio.Text & "','" & txtHoraFin.Text & "','" & cmbTurno.SelectedValue & "',"
                    Cadena = Cadena & "'" & IIf(swLunes.Value, "1", "0") & "','" & IIf(swMartes.Value, "1", "0") & "','" & IIf(swMiercoles.Value, "1", "0") & "','" & IIf(swJueves.Value, "1", "0") & "','" & IIf(swViernes.Value, "1", "0") & "','" & IIf(swSabado.Value, "1", "0") & "','" & IIf(swDomingo.Value, "1", "0") & "','" + cmbPlanta.Text + "')"

                    sqlExecute(Cadena, "cafeteria")

                    dtHorarios = sqlExecute("SELECT * FROM horarios WHERE cod_horario = '" & Hora & "'", "cafeteria")
                    MostrarInformacion()
                    Agregar = False
                End If

            ElseIf Editar Then
                ' Si Editar, entonces guardar cambios a registro
                Cadena = "UPDATE horarios set NOMBRE='" & txtNombre.Text & "',SERVICIO='" & cmbServicio.Text & "',HORA_INICIO='" & txtHoraInicio.Text & "',HORA_FIN='" & txtHoraFin.Text & "',TURNO='" & cmbTurno.SelectedValue & "',PLANTA='" + cmbPlanta.Text + "',"
                Cadena = Cadena & "LUNES='" & IIf(swLunes.Value, "1", "0") & "',MARTES='" & IIf(swMartes.Value, "1", "0") & "',MIERCOLES='" & IIf(swMiercoles.Value, "1", "0") & "',JUEVES='" & IIf(swJueves.Value, "1", "0") & "',VIERNES='" & IIf(swViernes.Value, "1", "0") & "',SABADO='" & IIf(swSabado.Value, "1", "0") & "',DOMINGO='" & IIf(swDomingo.Value, "1", "0") & "' "
                Cadena = Cadena & "WHERE cod_horario = '" & txtCodigo.Text & "'"
                sqlExecute(Cadena, "cafeteria")

                dtHorarios = sqlExecute("SELECT * FROM horarios WHERE cod_horario = '" & Hora & "'", "cafeteria")
                MostrarInformacion()
            Else
                Agregar = True
            End If
            Editar = False

            HabilitarBotones()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            HabilitarBotones()
            txtNombre.Focus()
        Else
            Agregar = False
            Editar = False
            HabilitarBotones()

        End If

        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim codigo As String, comp As String
        codigo = txtCodigo.Text
        'comp = cmbCia.SelectedValue
        dtTemporal = sqlExecute("SELECT horario_asiste from marcajes WHERE cod_horario = '" & codigo & "' ", "CAFETERIA")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse ningún que haya sido ultilizado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM horarios WHERE cod_horario = '" & codigo & "'", "CAFETERIA")
                'sqlExecute("DELETE FROM dias WHERE cod_horario = '" & codigo & "' AND cod_comp = '" & comp & "'")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtHrs As New DataTable

        dtHrs = sqlExecute("SELECT * FROM horarios", "CAFETERIA")
        frmVistaPrevia.LlamarReporte("horarios", dtHorarios) ', cmbCia.SelectedValue)
        frmVistaPrevia.ShowDialog()

    End Sub

    Private Sub frmHorarios_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlControles.Left = (Me.Width - pnlControles.Width) / 2
    End Sub
End Class