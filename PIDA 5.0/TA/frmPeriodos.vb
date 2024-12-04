Public Class frmPeriodos
    Dim dtPeriodos As New DataTable
    Dim dtLista As New DataTable
    Dim Editar As Boolean = False
    Dim Agregar As Boolean = False
    Dim PeriodoActivo As String = ""
    Dim dtAnos As New DataTable
    Dim dtMeses As New DataTable
    Dim dtNuevos As New DataTable
    Dim CambiarActivo As Boolean = False
    Dim DesdeGrid As Boolean = False

    Dim A As String = ""
    Dim BS As New BindingSource

    Private Sub frmPeriodos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'No salir si no hay periodo seleccionado, o hay más de 3
        dtTemporal = sqlExecute("SELECT periodo FROM periodos WHERE activo = 1", "TA")
        If dtTemporal.Rows.Count > 3 Then
            MessageBox.Show("Solo puede haber hasta 3 periodos activos. Necesita desactivar al menos uno para que pueda seleccionar otro.", "Periodo activo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If

        If dtTemporal.Rows.Count = 0 Then
            dtTemporal = sqlExecute("SELECT TOP 1 periodo FROM periodos", "TA")
            If dtTemporal.Rows.Count <> 0 Then
                MessageBox.Show("No hay periodos activos. Debe seleccionar al menos un periodo.", "Error. Sin periodo activo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If

        If Not e.Cancel Then Me.Dispose()
    End Sub


    Private Sub frmPeriodosTA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Exceptuar los periodos especiales de nómina
        Dim dtActivo As New DataTable
        Dim dtTemp As New DataTable
        Try

            dtAnos = sqlExecute("SELECT DISTINCT ano FROM periodos ORDER BY ano desc", "TA")
            cmbAno.DataSource = dtAnos

            dtMeses = sqlExecute("SELECT num_mes,mes_may FROM meses ORDER BY num_mes")
            Dim dNuevo As DataRow = dtMeses.NewRow
            'dNuevo("num_mes") = DBNull
            dNuevo("mes_may") = "INDEFINIDO"
            dtMeses.Rows.InsertAt(dNuevo, 0)
            cmbMes.DataSource = dtMeses

            dtLista = sqlExecute("SELECT *,ano+periodo as 'UNICO' FROM periodos ORDER BY ano DESC,periodo ASC", "TA")
            'sqlExecute("SELECT ano,periodo,cast(fecha_ini as char) as 'fecha_ini',cast(fecha_fin as char) as'fecha_fin',ano+periodo as 'unico' FROM periodos WHERE periodo_especial IS NULL OR periodo_especial = 0 ORDER BY ano DESC,periodo ASC", dtPeriodosActivos, "TA")
            'Buscar periodos activos
            
            dtLista.DefaultView.Sort = "unico"
            dgTabla.AutoGenerateColumns = False
                'dgTabla.DataSource = dtLista

            txtNuevoAno.Text = Now.Year + 1
            gpNuevo.Left = lbl1.Left - 10
            gpNuevo.Width = pnlDatos.Width - (gpNuevo.Left * 2)

            BS.DataSource = dtLista
            dgTabla.DataSource = BS

            dtActivo = sqlExecute("SELECT ano,periodo,fecha_ini,fecha_fin,activo FROM periodos WHERE (periodo_especial IS NULL OR periodo_especial = 0) " & _
                                  "AND activo=1 ORDER BY ano DESC,periodo DESC", "TA")
            lstActivo.Items.Clear()

            If dtActivo.Rows.Count = 0 Then
                MessageBox.Show("No hay periodos activos. Debe seleccionar al menos un periodo.", "Error. Sin periodo activo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                PeriodoActivo = ObtenerAnoPeriodo(DateAdd(DateInterval.Day, -7, Now.Date))
                If PeriodoActivo.Length = 6 Then
                    dtPeriodos = sqlExecute("SELECT * FROM periodos WHERE ano = '" & PeriodoActivo.Substring(0, 4) & _
                                          "' AND periodo = '" & PeriodoActivo.Substring(4, 2) & "'", "TA")
                End If

            Else
                PeriodoActivo = dtActivo.Rows(0).Item("ano") & " " & dtActivo.Rows(0).Item("periodo")
                For Each dPer As DataRow In dtActivo.Rows
                    lstActivo.Items.Add(dPer("ano") & " " & dPer("periodo"))
                Next
                ' PeriodoActivo = dtActivo.Rows.Item(dtActivo.Rows.Count - 1).Item("ano") & " " & dtActivo.Rows.Item(dtActivo.Rows.Count - 1).Item("periodo")
                If dtActivo.Rows.Count > 3 Then
                    MessageBox.Show("Hay " & dtActivo.Rows.Count & " periodos activos. Hasta 3 periodos pueden estar activo a la vez.", "Error. Varios periodos activos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                dtPeriodos = sqlExecute("select * from periodos where ano+periodo in (select max(ano+periodo) from periodos where activo = 1)", "TA")
                'End If
            End If

            MostrarInformacion()
            HabilitarControles()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub
    Private Sub MostrarInformacion()
        Try
            Dim i As Integer
            Dim mes As Integer
            If dtPeriodos.Rows.Count = 0 then Exit Sub 
            Dim drPeriodo As DataRow = dtPeriodos.Rows(0)
            cmbAno.SelectedValue = drPeriodo("ano")
            txtPeriodo.Text = drPeriodo("periodo")
            txtFechaIni.Value = drPeriodo("fecha_ini")
            txtFechaFin.Value = drPeriodo("fecha_fin")
            txtDescripcion.Text = IIf(IsDBNull(drPeriodo("nombre")), "", drPeriodo("nombre"))
            txtObservaciones.Text = IIf(IsDBNull(drPeriodo("observaciones")), "", drPeriodo("observaciones"))
            txtFechaPago.Value = IIf(IsDBNull(drPeriodo("fecha_pago")), DateAdd(DateInterval.Day, 4, drPeriodo("fecha_fin")), drPeriodo("fecha_pago"))
            If IsDBNull(drPeriodo("num_mes")) Then
                If DatePart(DateInterval.Month, drPeriodo("fecha_ini")) = DatePart(DateInterval.Month, drPeriodo("fecha_fin")) Then
                    mes = DatePart(DateInterval.Month, drPeriodo("fecha_ini"))
                Else
                    mes = IIf(DateSerial(Ano, DatePart(DateInterval.Month, drPeriodo("fecha_fin")), 1).DayOfWeek <= 3, DatePart(DateInterval.Month, drPeriodo("fecha_fin")), DatePart(DateInterval.Month, drPeriodo("fecha_ini")))
                End If
            Else
                mes = IIf(drPeriodo("num_mes").ToString.Trim.Length = 0, 0, drPeriodo("num_mes"))
            End If
            cmbMes.SelectedValue = IIf(mes = 0, 0, mes.ToString.Trim.PadLeft(2, "0"))
            btnActivo.Value = IIf(IsDBNull(drPeriodo("activo")), 0, drPeriodo("activo")) = 1
            btnEspecial.Value = IIf(IsDBNull(drPeriodo("periodo_especial")), 0, drPeriodo("periodo_especial")) = 1
            If Not DesdeGrid Then
                i = BS.Find("unico", drPeriodo("ano") & drPeriodo("periodo"))
                If i >= 0 Then
                    BS.Position = i
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    'dgTabla.CurrentCell = dgTabla.Rows(i).Cells(0)
                End If

                'i = dtLista.DefaultView.Find(cmbAno.SelectedValue & txtPeriodo.Text)
                'If i >= 0 Then
                '    dgTabla.FirstDisplayedScrollingRowIndex = i
                '    dgTabla.CurrentCell = dgTabla.Rows(i).Cells("año")
                'End If
            End If
            DesdeGrid = False

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub HabilitarControles()
        If Editar Or Agregar Then
            ' Si está activa la edición o nuevo registro
            btnNuevo.Image = PIDA.My.Resources.Ok16
            btnNuevo.Text = "Aceptar"
            btnEditar.Image = PIDA.My.Resources.CancelX
            btnEditar.Text = "Cancelar"
        Else

            btnNuevo.Image = PIDA.My.Resources.NewRecord
            btnNuevo.Text = "Agregar"
            btnEditar.Image = PIDA.My.Resources.Edit
            btnEditar.Text = "Editar"
        End If

        btnPrimero.Enabled = Not (Agregar Or Editar)
        btnAnterior.Enabled = Not (Agregar Or Editar)
        btnSiguiente.Enabled = Not (Agregar Or Editar)
        btnUltimo.Enabled = Not (Agregar Or Editar)

        btnReporte.Enabled = Not (Agregar Or Editar)
        btnBuscar.Enabled = Not (Agregar Or Editar)
        btnBorrar.Enabled = Not (Agregar Or Editar)
        btnCerrar.Enabled = Not (Agregar Or Editar)
        'dgTabla.Columns("colActivo").ReadOnly = Not (Agregar Or Editar)

        txtDescripcion.Enabled = Agregar Or Editar
        txtObservaciones.Enabled = Agregar Or Editar
        txtFechaPago.Enabled = (Agregar Or Editar)
        cmbMes.Enabled = Agregar Or Editar
        btnActivo.IsReadOnly = Not (Agregar Or Editar)
        btnEspecial.IsReadOnly = Not (Agregar Or Editar)

        gpNuevo.Visible = Agregar

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        'BERE
        'Cod = Buscar("ta.dbo.periodos", "CONCAT(ano,periodo)", "PERIODOS", False)
        Cod = Buscar("ta.dbo.periodos", "(ano + periodo)", "PERIODOS", False)
        If Cod <> "CANCELAR" Then
            'BERE
            'dtPeriodos = sqlExecute("SELECT * from periodos WHERE CONCAT(ano,periodo) = '" & Cod & "'", "TA")
            dtPeriodos = sqlExecute("SELECT * from periodos WHERE (ano + periodo) = '" & Cod & "'", "TA")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Editar = Not (Editar Or Agregar)
        Agregar = False
        CambiarActivo = False
        HabilitarControles()
        MostrarInformacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        'Me.Dispose()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        'BERE
        'Siguiente("periodos", "CONCAT(ano,periodo)", cmbAno.SelectedValue & txtPeriodo.Text, dtPeriodos, "TA")
        Siguiente("periodos", "(ano + periodo)", cmbAno.SelectedValue & txtPeriodo.Text, dtPeriodos, "TA")
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        'BERE
        'Ultimo("periodos", "CONCAT(ano,periodo)", dtPeriodos, "TA")
        Ultimo("periodos", "(ano + periodo)", dtPeriodos, "TA")
        MostrarInformacion()
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        'BERE
        'Primero("periodos", "CONCAT(ano,periodo)", dtPeriodos, "TA")
        Primero("periodos", "(ano + periodo)", dtPeriodos, "TA")
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        'BERE
        'Anterior("periodos", "CONCAT(ano,periodo)", cmbAno.SelectedValue & txtPeriodo.Text, dtPeriodos, "TA")
        Anterior("periodos", "(ano + periodo)", cmbAno.SelectedValue & txtPeriodo.Text, dtPeriodos, "TA")
        MostrarInformacion()
    End Sub

    Private Sub dgTabla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellDoubleClick
        Try
            Dim EstaActivo As Boolean
            Dim AnoPeriodo As String
            Dim dtActivo As New DataTable
            If dgTabla.Columns(e.ColumnIndex).Name = "colActivo" And Not Editar Then
                EstaActivo = btnActivo.Value
                AnoPeriodo = BS.Item(e.RowIndex)("ano") & BS.Item(e.RowIndex)("periodo")
                If MessageBox.Show("¿Está seguro de " & IIf(EstaActivo, "desactivar", "activar") & " el periodo " & AnoPeriodo & "?", "Activar/desactivar periodo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    sqlExecute("UPDATE periodos SET activo = " & IIf(EstaActivo, 0, 1) & " WHERE ano = '" & AnoPeriodo.Substring(0, 4) & _
                               "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'", "TA")
                    btnActivo.Value = Not EstaActivo
                    BS.Item(e.RowIndex)("activo") = Not EstaActivo

                    dtActivo = sqlExecute("SELECT ano,periodo,fecha_ini,fecha_fin,activo FROM periodos WHERE (periodo_especial IS NULL OR periodo_especial = 0) " & _
                                 "AND activo=1 ORDER BY ano DESC,periodo DESC", "TA")

                    lstActivo.Items.Clear()
                    For Each dPer As DataRow In dtActivo.Rows
                        lstActivo.Items.Add(dPer("ano") & " " & dPer("periodo"))
                    Next
                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgTabla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellEnter

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim FechaInicial As Date
        Dim FechaFinal As Date
        Dim Fecha As Date
        Dim Periodo As Integer
        Dim Ano As String
        Dim Mes As Integer
        Dim x As Integer
        Try
            Ano = txtNuevoAno.Text
            FechaInicial = txtFechaInicial.Value
            Fecha = FechaInicial
            FechaFinal = txtFechaFinal.Value
            'BERE
            'dtNuevos = sqlExecute("SELECT * FROM periodos WHERE (fecha_ini BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "') OR CONCAT(ano,periodo)='" & Ano & Periodo.ToString.PadLeft(2, "0") & "'", "TA")
            dtNuevos = sqlExecute("SELECT * FROM periodos WHERE (fecha_ini BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "') OR (ano + periodo)='" & Ano & Periodo.ToString.PadLeft(2, "0") & "'", "TA")
            If dtNuevos.Rows.Count > 0 Then
                If MessageBox.Show("El periodo inicial ya existe, o hay periodos registrados en ese periodo de tiempo. ¿Desea sobreescribirlos?", "Nuevos periodos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                    'BERE
                    'dtTemporal = sqlExecute("DELETE FROM periodos WHERE (fecha_ini BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "') OR CONCAT(ano,periodo)='" & Ano & Periodo.ToString.PadLeft(2, "0") & "'", "TA")
                    dtTemporal = sqlExecute("DELETE FROM periodos WHERE (fecha_ini BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "') OR (ano + periodo)='" & Ano & Periodo.ToString.PadLeft(2, "0") & "'", "TA")
                Else
                    txtNuevoAno.Focus()
                    Exit Sub
                End If
            End If

            'Esta tabla debe regresar en blanco, pues si había registros ya se borraron, sin embargo nos da la estructura para llenar
            dtNuevos = sqlExecute("SELECT ano AS AÑO,PERIODO,fecha_ini AS 'FECHA INICIAL',fecha_fin AS 'FECHA FINAL',num_mes AS 'MES','' as 'MES LETRA',periodo_especial AS 'PERIODO ESPECIAL' FROM periodos WHERE fecha_ini BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "'", "TA")
            If dtNuevos.Rows.Count > 0 Then
                MessageBox.Show("Existen periodos dentro de este rango de fechas. Deben ser eliminados antes de continuar la creación de los nuevos periodos", "Crear periodos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Periodo = Int(txtPeriodoInicial.Text)
            Do Until Fecha > txtFechaFinal.Value Or Periodo > 53
                FechaInicial = Fecha
                FechaFinal = DateAdd(DateInterval.Day, 6, Fecha)
                'Si la fecha inicial y la final están en diferente mes, definir cuál tiene más días
                If FechaInicial.Month = FechaFinal.Month Then
                    Mes = FechaInicial.Month
                Else
                    Mes = IIf(DateSerial(Ano, FechaFinal.Month, 1).DayOfWeek <= 3, FechaFinal.Month, FechaInicial.Month)
                End If
                'Agregar el registro
                dtNuevos.Rows.Add({Ano, Periodo.ToString.PadLeft(2, "0"), FechaInicial, FechaFinal, Mes.ToString.Trim.PadLeft(2, "0"), MesLetra(Mes)})

                'Incrementar la fecha y el periodo
                Fecha = DateAdd(DateInterval.Day, 1, FechaFinal)
                Periodo = Periodo + 1
            Loop

            'Si se seleccionó crear periodos especiales, crearlos del 70 en delante
            If btnCrearEspeciales.Value Then
                For x = 70 To 99
                    dtNuevos.Rows.Add({Ano, x.ToString, DateSerial(Ano, 1, 1), DateSerial(Ano, 12, 31), "", "", 1})
                Next
            End If

            dgNuevosPeriodos.DataSource = dtNuevos
            dgNuevosPeriodos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgNuevosPeriodos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgNuevosPeriodos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtNuevoAno_ValueChanged(sender As Object, e As EventArgs) Handles txtNuevoAno.ValueChanged
        Dim Fecha As Date
        Dim IniciaLunes As Boolean
        Try

            dtTemporal = sqlExecute("SELECT inicia_sem FROM parametros")
            If dtTemporal.Rows.Count = 0 Then
                IniciaLunes = True
            Else
                IniciaLunes = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item(0)), 2, dtTemporal.Rows.Item(0).Item(0)) = 2
            End If
            Fecha = DateSerial(txtNuevoAno.Value, 1, 1)

            If Fecha.DayOfWeek > 3 Then
                'Si la fecha es posterior a miércoles, tomar siguiente lunes
                txtFechaInicial.Value = DateAdd(DateInterval.Day, 7 - Fecha.DayOfWeek, Fecha)

            Else
                'Si la fecha es menor o igual a miércoles, tomar lunes anterior
                txtFechaInicial.Value = DateAdd(DateInterval.Day, -Fecha.DayOfWeek + 1, Fecha)
            End If
            'Agregar las 52 semanas, para fecha final
            txtFechaFinal.Value = DateAdd(DateInterval.Day, (7 * 52) - 1, txtFechaInicial.Value)

            'Si está configurado a no iniciar en lunes, restar un día para que inicie en domingo
            If Not IniciaLunes Then
                txtFechaInicial.Value = DateAdd(DateInterval.Day, -1, txtFechaInicial.Value)
                txtFechaFinal.Value = DateAdd(DateInterval.Day, -1, txtFechaFinal.Value)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        lblDiaFinal.Text = DiaSem(txtFechaFinal.Value)
    End Sub

    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        lblDiaInicial.Text = DiaSem(txtFechaInicial.Value)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            Dim dtActivo As New DataTable

            If Agregar Then
                For Each dRow As DataRow In dtNuevos.Rows
                    sqlExecute("INSERT INTO periodos (ano,periodo,fecha_ini,fecha_fin,num_mes,mes,periodo_especial) VALUES ('" & _
                               dRow("año") & "','" & dRow("periodo") & "','" & FechaSQL(dRow("fecha inicial")) & "','" & FechaSQL(dRow("fecha final")) & "','" & _
                               dRow("mes") & "','" & MesLetra(Val(dRow("mes"))) & "'," & IIf(IsDBNull(dRow("periodo especial")), 0, dRow("periodo especial")) & ")", "TA")
                Next
                dtAnos = sqlExecute("SELECT DISTINCT ano FROM periodos ORDER BY ano desc", "TA")
                cmbAno.DataSource = dtAnos

                dtLista = sqlExecute("SELECT *,ano+periodo as 'UNICO' FROM periodos ORDER BY ano DESC,periodo ASC", "TA")
                BS.DataSource = dtLista
                dgTabla.DataSource = BS
                Agregar = False
            ElseIf Editar Then
                'BERE
                'sqlExecute("UPDATE periodos SET nombre = '" & txtDescripcion.Text & "' WHERE CONCAT(ano,periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                'sqlExecute("UPDATE periodos SET observaciones = '" & txtObservaciones.Text & "' WHERE CONCAT(ano,periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                'sqlExecute("UPDATE periodos SET fecha_pago = '" & FechaSQL(txtFechaPago.Value) & "' WHERE CONCAT(ano,periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                'sqlExecute("UPDATE periodos SET num_mes = '" & cmbMes.SelectedValue & "' WHERE CONCAT(ano,periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                'sqlExecute("UPDATE periodos SET mes = '" & MesLetra(cmbMes.SelectedValue) & "' WHERE CONCAT(ano,periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                'sqlExecute("UPDATE periodos SET periodo_especial = " & IIf(btnEspecial.Value, 1, 0) & " WHERE CONCAT(ano,periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                'sqlExecute("UPDATE periodos SET activo = " & IIf(btnActivo.Value, 1, 0) & " WHERE CONCAT(ano,periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")

                sqlExecute("UPDATE periodos SET nombre = '" & txtDescripcion.Text & "' WHERE (ano + periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                sqlExecute("UPDATE periodos SET observaciones = '" & txtObservaciones.Text & "' WHERE (ano + periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                sqlExecute("UPDATE periodos SET fecha_pago = '" & FechaSQL(txtFechaPago.Value) & "' WHERE (ano + periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                sqlExecute("UPDATE periodos SET num_mes = '" & cmbMes.SelectedValue & "' WHERE (ano + periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                sqlExecute("UPDATE periodos SET mes = '" & MesLetra(cmbMes.SelectedValue) & "' WHERE (ano + periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                sqlExecute("UPDATE periodos SET periodo_especial = " & IIf(btnEspecial.Value, 1, 0) & " WHERE (ano + periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                sqlExecute("UPDATE periodos SET activo = " & IIf(btnActivo.Value, 1, 0) & " WHERE (ano + periodo)='" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
                BS(BS.Position)("activo") = IIf(btnActivo.Value, 1, 0)
                BS(BS.Position)("mes") = MesLetra(cmbMes.SelectedValue)

                dtActivo = sqlExecute("SELECT ano,periodo,fecha_ini,fecha_fin,activo FROM periodos WHERE (periodo_especial IS NULL OR periodo_especial = 0) " & _
                      "AND activo=1 ORDER BY ano DESC,periodo DESC", "TA")
                lstActivo.Items.Clear()

                If dtActivo.Rows.Count > 0 Then
                    PeriodoActivo = dtActivo.Rows(0).Item("ano") & " " & dtActivo.Rows(0).Item("periodo")
                    For Each dPer As DataRow In dtActivo.Rows
                        lstActivo.Items.Add(dPer("ano") & " " & dPer("periodo"))
                    Next
                End If
            Else
                Agregar = True
            End If
            dtLista = sqlExecute("SELECT ano,ANO as AÑO,PERIODO,FECHA_INI,FECHA_FIN,ACTIVO,ano+periodo as 'UNICO' FROM periodos WHERE periodo_especial IS NULL OR periodo_especial = 0 ORDER BY ano DESC,periodo ASC", "TA")
            'BERE
            'dtPeriodos = sqlExecute("SELECT * FROM periodos WHERE CONCAT(ano,periodo) = '" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")
            dtPeriodos = sqlExecute("SELECT * FROM periodos WHERE (ano + periodo) = '" & cmbAno.SelectedValue & txtPeriodo.Text & "'", "TA")

            Editar = False
            MostrarInformacion()
            HabilitarControles()

        Catch ex As Exception
            MessageBox.Show("Los cambios no pudieron ser guardados. Favor de verificar." & vbCrLf & "Error " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnActivo_Click(sender As Object, e As EventArgs) Handles btnActivo.Click
        ''Si está en modo de edición
        'If Editar Then
        '    'El botón de click se activa antes de cambiar el valor, por eso se evalúa en falso
        '    If btnActivo.Value = False Then

        '        dtTemporal = sqlExecute("SELECT periodo FROM periodos WHERE activo = 1", "TA")
        '        If dtTemporal.Rows.Count > 3 Then
        '            MessageBox.Show("Solo puede haber hasta 3 periodos activos. " & vbCrLf & "Necesita desactivar al menos uno para que pueda seleccionar otro.", "Periodo activo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            btnActivo.Value = False
        '            Exit Sub
        '        End If

        '        'Si se está seleccionando activo
        '        If MessageBox.Show("¿Está seguro de definir este periodo como activo?", "Periodo activo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
        '            btnActivo.Value = False
        '        End If
        '    Else
        '        dtTemporal = sqlExecute("SELECT periodo FROM periodos WHERE activo = 1", "TA")
        '        If dtTemporal.Rows.Count = 0 Then
        '            MessageBox.Show("Debe haber al menos un periodo activo seleccionado." & vbCrLf & " Por favor, seleccione el periodo que quedará activo.", "Periodo activo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub btnActivo_ValueChanged(sender As Object, e As EventArgs) Handles btnActivo.ValueChanged

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtPeriodos As New DataTable
        'BERE
        'dtPeriodos = sqlExecute("SELECT ano,periodo,fecha_ini,fecha_fin,fecha_pago, " & _
        '"REPLACE(STR(IIF(num_mes IS NULL OR num_mes = '','99',num_mes), 2), SPACE(1), '0')as num_mes," & _
        '"mes,nombre,observaciones,activo,periodo_especial FROM ta.dbo.periodos " & _
        '"WHERE ano = " & cmbAno.SelectedValue & " ORDER BY num_mes,periodo", "TA")

        dtPeriodos = sqlExecute("SELECT ano,periodo,fecha_ini,fecha_fin,fecha_pago, " & _
                                "REPLACE(STR((CASE WHEN num_mes is NULL OR num_mes='' THEN '99' ELSE num_mes END), 2), SPACE(1), '0')as num_mes," & _
                                "mes,nombre,observaciones,activo,periodo_especial FROM ta.dbo.periodos " & _
                                "WHERE ano = " & cmbAno.SelectedValue & " ORDER BY num_mes,periodo", "TA")
        frmVistaPrevia.LlamarReporte("Periodos", dtPeriodos)
        frmVistaPrevia.ShowDialog()

    End Sub


    Private Sub dgTabla_Click(sender As Object, e As EventArgs) Handles dgTabla.Click
        On Error Resume Next

        Dim cod As String, nom As String
        DesdeGrid = True
        cod = BS.Item(BS.Position)("ano")
        nom = BS.Item(BS.Position)("periodo")
        dtPeriodos = sqlExecute("SELECT * from periodos WHERE ano = '" & cod & "' AND periodo = '" & nom & "'", "TA")
        MostrarInformacion()
    End Sub

    Private Sub dgTabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellContentClick

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

    End Sub
End Class