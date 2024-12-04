Public Class frmPensionesAlimenticias '-- Ernesto -- junio 2023
#Region "Declaraciones"
    Dim dtLista As New DataTable                            'Lista de datos para grid
    Dim dtRegistro As New DataTable                         'Mantiene el registro actual
    Dim dtVaciosPer As New DataTable                           'Para limpiar controles [Pensiones alimenticias personal]
    Dim dtVaciosNom As New DataTable                           'Columnas [Pensiones alimenticias nomina]

    Dim dicInfo As New Dictionary(Of String, Object)        'Diccionario para comparar info al momento de actualizar [Pensiones alimenticias personal]
    Dim dicInfo2 As New Dictionary(Of String, Object)        'Diccionario para comparar info al momento de actualizar [Pensiones alimenticias nomina]

    Dim dtPensionNom As New DataTable                       'Info de pensiones de nomina
    Dim dtInfoPer As New DataTable                          'Info de periodos
    Dim dtComp As New DataTable                             'Compania
    Dim strID As String = ""                                'ID del registro
    Dim strLlavePer As String = ""                          'Llaves que conectan las pensiones
    Dim strLlaveNom As String = ""

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean

    Dim dtPensionesAlim As New DataTable
#End Region


    Private Sub frmPensionesAlimenticias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '-- Tipos de pensiones [12 tipos según el cálculo del proceso]
            dtPensionesAlim = sqlExecute("select * from personal.dbo.tipo_pensiones")
            If dtPensionesAlim.Rows.Count > 0 Then
                For Each i In dtPensionesAlim.Rows
                    Dim cmbItem As New DevComponents.Editors.ComboItem
                    cmbItem.Text = i("tipo_pension").ToString.Trim
                    cmbItem.TextAlignment = System.Drawing.StringAlignment.Center
                    cmbItem.TextLineAlignment = System.Drawing.StringAlignment.Center
                    tipo_pen.Items.Add(cmbItem)
                Next
            Else
                For i = 1 To 14
                    Dim cmbItem As New DevComponents.Editors.ComboItem
                    cmbItem.Text = i
                    cmbItem.TextAlignment = System.Drawing.StringAlignment.Center
                    cmbItem.TextLineAlignment = System.Drawing.StringAlignment.Center
                    tipo_pen.Items.Add(cmbItem)
                Next
            End If

            RefrescaDatatable()
            MostrarInformacion()

            '-- Carga diccionario [Pensiones alimenticias personal]
            If dicInfo.Count = 0 Then
                For Each c As DataColumn In dtVaciosPer.Columns
                    dicInfo.Add(c.ColumnName.ToLower, Nothing)
                Next
            End If

            '-- Carga diccionario [Pensiones alimenticias nomina]
            If dicInfo2.Count = 0 Then
                For Each c As DataColumn In dtVaciosNom.Columns
                    dicInfo2.Add(c.ColumnName.ToLower, Nothing)
                Next
            End If

            '-- Compañia
            dtComp = sqlExecute("select reloj,cod_comp,(case when cod_tipo='A' then 'Q' else 'S' end) as tipo_periodo," &
                                "RTRIM(nombre) as nombre,RTRIM(apaterno) as apaterno,RTRIM(amaterno) as amaterno from personal.dbo.personal")

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub RefrescaDatatable()
        Try
            '-- Lista de pensiones para dgv
            dtLista = sqlExecute("select * from personal.dbo.pensiones_alimenticias")
            dtLista.DefaultView.Sort = "reloj"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            '-- Primer registro de pensiones alimenticias
            dtRegistro = sqlExecute("select top 1 * from personal.dbo.pensiones_alimenticias")
            dtVaciosPer = dtRegistro.Clone
            If dtVaciosPer.Rows.Count = 0 Then dtVaciosPer.Rows.Add()

            '-- Pensiones de nomina
            dtPensionNom = sqlExecute("select * from nomina.dbo.pensiones_alimenticias")
            dtVaciosNom = dtPensionNom.Clone
            If dtVaciosNom.Rows.Count = 0 Then dtVaciosNom.Rows.Add()

            '-- Info de periodos
            dtInfoPer = sqlExecute("select ano,periodo from ta.dbo.periodos where ano=YEAR(getdate()) and periodo_especial=0 and GETDATE() between FECHA_INI and FECHA_FIN")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub HabilitarBotones()

        Dim NoRec As Boolean
        NoRec = dgTabla.Rows.Count = 0
        btnPrimero.Enabled = Not (Agregar Or Editar Or NoRec)
        btnAnterior.Enabled = Not (Agregar Or Editar Or NoRec)
        btnSiguiente.Enabled = Not (Agregar Or Editar Or NoRec)
        btnUltimo.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBuscar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBorrar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnCerrar.Enabled = Not (Agregar Or Editar Or NoRec)
        pnlDatos.Enabled = Agregar Or Editar
        gpNomina.Enabled = Agregar Or Editar
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

        reloj.Enabled = Agregar

        If Agregar Then
            ControlesInfo(dtVaciosPer, False)
        ElseIf Editar Then
            ControlesInfo(dtRegistro)
        End If
    End Sub

    Private Sub ControlesInfo(ByRef dtInfo As DataTable, Optional cargarInfo As Boolean = True)
        Try
            '-- Pensiones alimenticias personal
            Dim cont = 0
            strID = dtInfo.Rows(0).Item("ID").ToString.Trim
            strLlavePer = If(Agregar, Date.Now.TimeOfDay.ToString, dtInfo.Rows(0).Item("llave").ToString.Trim)

            txtID.Text = strID
            reloj.Text = dtInfo.Rows(0).Item("reloj").ToString.Trim
            pensionado.Text = If(IsDBNull(dtInfo.Rows(0).Item("pensionado")), "", dtInfo.Rows(0).Item("pensionado"))
            porcentaje.Value = If(IsDBNull(dtInfo.Rows(0).Item("porcentaje")), 0.0, dtInfo.Rows(0).Item("porcentaje"))

            For Each elem In tipo_pen.Items
                If elem.ToString = dtInfo.Rows(0).Item("tipo_pen").ToString.Trim Then tipo_pen.SelectedIndex = cont : Exit For
                cont += 1
            Next

            base_pen.Value = If(IsDBNull(dtInfo.Rows(0).Item("base_pen")), 0.0, dtInfo.Rows(0).Item("base_pen"))
            fijo.Value = If(IsDBNull(dtInfo.Rows(0).Item("fijo")), False, dtInfo.Rows(0).Item("fijo"))
            cuenta.Text = If(IsDBNull(dtInfo.Rows(0).Item("cuenta")), "", dtInfo.Rows(0).Item("cuenta"))
            activo.Value = If(IsDBNull(dtInfo.Rows(0).Item("activo")), False, dtInfo.Rows(0).Item("activo"))
            apaterno.Text = If(IsDBNull(dtInfo.Rows(0).Item("apaterno")), "", dtInfo.Rows(0).Item("apaterno"))
            amaterno.Text = If(IsDBNull(dtInfo.Rows(0).Item("amaterno")), "", dtInfo.Rows(0).Item("amaterno"))
            nombre.Text = If(IsDBNull(dtInfo.Rows(0).Item("nombre")), "", dtInfo.Rows(0).Item("nombre"))
            cuaderno.Text = If(IsDBNull(dtInfo.Rows(0).Item("cuaderno")), "", dtInfo.Rows(0).Item("cuaderno"))
            num_pensio.Value = If(IsDBNull(dtInfo.Rows(0).Item("num_pensio")), 1, CInt(dtInfo.Rows(0).Item("num_pensio")))
            cuenta_val.Text = If(IsDBNull(dtInfo.Rows(0).Item("cuenta_val")), "", dtInfo.Rows(0).Item("cuenta_val"))
            comentario.Text = If(IsDBNull(dtInfo.Rows(0).Item("comentario")), "", dtInfo.Rows(0).Item("comentario"))
            inicio.Value = If(IsDBNull(dtInfo.Rows(0).Item("inicio")), Nothing, dtInfo.Rows(0).Item("inicio"))
            suspension.Value = If(IsDBNull(dtInfo.Rows(0).Item("suspension")), Nothing, dtInfo.Rows(0).Item("suspension"))
            mercantil.Value = If(IsDBNull(dtInfo.Rows(0).Item("mercantil")), False, dtInfo.Rows(0).Item("mercantil"))
            tarjeta_val.Text = If(IsDBNull(dtInfo.Rows(0).Item("tarjeta_val")), "", dtInfo.Rows(0).Item("tarjeta_val"))
            interbancario.Value = If(IsDBNull(dtInfo.Rows(0).Item("interbancario")), False, dtInfo.Rows(0).Item("interbancario"))

            llave.Text = strLlavePer

            '-- Pensiones alimenticias nomina
            Dim dtInfoNom = dtPensionNom.Select("llave='" & strLlavePer & "'")

            If dtInfoNom.Count > 0 Then
                ano.Text = dtInfoNom.First.Item("ano").ToString.Trim
                periodo.Text = dtInfoNom.First.Item("periodo").ToString.Trim
                cuenta0.Text = If(IsDBNull(dtInfoNom.First.Item("cuenta")), "", dtInfoNom.First.Item("cuenta").ToString.Trim)
                nombre0.Text = If(IsDBNull(dtInfoNom.First.Item("nombre")), "", dtInfoNom.First.Item("nombre").ToString.Trim)
                monto.Value = If(IsDBNull(dtInfoNom.First.Item("monto")), Nothing, dtInfoNom.First.Item("monto").ToString.Trim)
                pension.Value = dtInfoNom.First.Item("pension")
                inter.Value = If(dtInfoNom.First.Item("inter") = 1, True, False)
                no_pago.Value = If(dtInfoNom.First.Item("no_pago") = 1, True, False)
                cod_comp.Text = If(IsDBNull(dtInfoNom.First.Item("cod_comp")), "", dtInfoNom.First.Item("cod_comp").ToString.Trim)
                tipo_periodo.Text = If(IsDBNull(dtInfoNom.First.Item("tipo_periodo")), "", dtInfoNom.First.Item("tipo_periodo").ToString.Trim)
                llave0.Text = If(IsDBNull(dtInfoNom.First.Item("llave")), "", dtInfoNom.First.Item("llave").ToString.Trim)
                strLlaveNom = If(IsDBNull(dtInfoNom.First.Item("llave")), "", dtInfoNom.First.Item("llave").ToString.Trim)
            Else
                ano.Text = ""
                periodo.Text = ""
                cuenta0.Text = ""
                nombre0.Text = ""
                monto.Value = 0.0
                pension.Value = 0
                inter.Value = False
                no_pago.Value = False
                cod_comp.Text = ""
                tipo_periodo.Text = ""
                llave0.Text = strLlavePer
                strLlaveNom = strLlavePer
            End If

            If cargarInfo Then
                dicInfo("reloj") = reloj.Text.Trim
                dicInfo("pensionado") = pensionado.Text
                dicInfo("porcentaje") = porcentaje.Value
                dicInfo("tipo_pen") = tipo_pen.SelectedItem
                dicInfo("base_pen") = base_pen.Value
                dicInfo("fijo") = fijo.Value
                dicInfo("cuenta") = cuenta.Text
                dicInfo("activo") = activo.Value
                dicInfo("apaterno") = apaterno.Text
                dicInfo("amaterno") = amaterno.Text
                dicInfo("nombre") = nombre.Text
                dicInfo("cuaderno") = cuaderno.Text
                dicInfo("num_pensio") = num_pensio.Value
                dicInfo("cuenta_val") = cuenta_val.Text
                dicInfo("comentario") = comentario.Text
                dicInfo("interbancario") = interbancario.Value
                dicInfo("inicio") = If(IsNothing(inicio.ValueObject), Nothing, inicio.ValueObject)
                dicInfo("suspension") = If(IsNothing(suspension.ValueObject), Nothing, suspension.ValueObject)
                dicInfo("mercantil") = mercantil.Value
                dicInfo("tarjeta_val") = tarjeta_val.Text

                dicInfo2("cuenta") = cuenta0.Text
                dicInfo2("nombre") = nombre0.Text
                dicInfo2("monto") = monto.Value
                dicInfo2("pension") = pension.Value
                dicInfo2("inter") = inter.Value
                dicInfo2("no_pago") = no_pago.Value
            End If

            If Agregar Then
                ano.Text = dtInfoPer.Rows(0)("ano").ToString.Trim
                periodo.Text = dtInfoPer.Rows(0)("periodo").ToString.Trim
            End If


        Catch ex As Exception : End Try
    End Sub

    Private Sub MostrarInformacion()
        Dim i As Integer

        ControlesInfo(dtRegistro)

        If Not DesdeGrid Then
            i = dtLista.DefaultView.Find(strID)
            If i >= 0 Then
                dgTabla.FirstDisplayedScrollingRowIndex = i
                dgTabla.Rows(i).Selected = True
            End If
        End If

        DesdeGrid = False
        HabilitarBotones()
    End Sub

    ''' <summary>
    ''' Recorrer panel de controles para obtener su información
    ''' </summary>
    ''' <param name="strNomControl"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ctrlInterfaz(strNomControl As String, Optional op As Integer = 0) As Object
        Try
            Dim pnls = {pnlDatos, gpNomina}
            For Each ctrl In pnls(op).Controls
                If ctrl.name.ToString.Replace("0", "") = strNomControl Then
                    If ctrl.GetType() Is GetType(DevComponents.DotNetBar.Controls.TextBoxX) Then Return ctrl.Text
                    If ctrl.GetType() Is GetType(DevComponents.Editors.DoubleInput) Then Return ctrl.Value
                    If ctrl.GetType() Is GetType(DevComponents.Editors.IntegerInput) Then Return ctrl.Value
                    If ctrl.GetType() Is GetType(DevComponents.Editors.DateTimeAdv.DateTimeInput) Then Return ctrl.ValueObject
                    If ctrl.GetType() Is GetType(DevComponents.DotNetBar.Controls.ComboBoxEx) Then Return ctrl.SelectedItem
                    If ctrl.GetType() Is GetType(DevComponents.DotNetBar.Controls.SwitchButton) Then Return ctrl.Value
                End If
            Next
            Return Nothing
        Catch ex As Exception : End Try
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("pensiones_alimenticias", "reloj", "pensiones_alimenticias", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT TOP 1 * from personal.dbo.pensiones_alimenticias WHERE reloj = '" & Cod & "' AND ID<>" & strID & " ORDER BY ID ASC")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("pensiones_alimenticias", "ID", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("pensiones_alimenticias", "ID", strID, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("pensiones_alimenticias", "ID", strID, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Ultimo("pensiones_alimenticias", "ID", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim strReloj = reloj.Text
        Dim strPensionado = pensionado.Text.Trim
        Dim strNum = num_pensio.Value

        dtTemporal = sqlExecute("SELECT reloj,pensionado from personal.dbo.pensiones_alimenticias WHERE ID = '" & strID & "'")

        If dtTemporal.Rows.Count = 0 Then
            MessageBox.Show("No existe el registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & strReloj & " - " & strPensionado & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM personal.dbo.pensiones_alimenticias WHERE llave = '" & strLlavePer & "'")
                sqlExecute("DELETE FROM nomina.dbo.pensiones_alimenticias WHERE llave = '" & strLlavePer & "'")
                RefrescaDatatable()
                MostrarInformacion()
            End If
        End If
    End Sub

    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        Try
            DesdeGrid = True
            Dim reloj As String = dgTabla.Rows(e.RowIndex).Cells("reloj").Value
            Dim pensionado As String = If(IsDBNull(dgTabla.Rows(e.RowIndex).Cells("pensionado").Value), "is NULL", "='" & dgTabla.Rows(e.RowIndex).Cells("pensionado").Value & "'")
            strID = dgTabla.Rows(e.RowIndex).Cells("ID").Value
            dtRegistro = sqlExecute("SELECT * from personal.dbo.pensiones_alimenticias WHERE ID=" & strID)
            MostrarInformacion()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            HabilitarBotones()
        Else
            Editar = False
        End If

        Agregar = False
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        If Agregar Then
            '-- Verificar que no exista el el mismo pensionado
            dtTemporal = sqlExecute("SELECT * from personal.dbo.pensiones_alimenticias WHERE reloj = '" & reloj.Text.Trim & "' AND pensionado = '" & pensionado.Text.Trim & "'")

            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El registro no se puede agregar, ya existe el pensionado '" & pensionado.Text.Trim & " para el reloj " & reloj.Text.Trim & ".", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj.Focus()
                Exit Sub
            Else
                If reloj.Text.Trim <> "" Then
                    If sqlExecute("select reloj from personal.dbo.personal where reloj='" & reloj.Text.Trim & "'").Rows.Count = 0 Then
                        MessageBox.Show("El reloj ingresado no existe en personal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        '-- La cuenta no debe ir null tanto para la tabla de pensiones alimenticias de nomina como de personal -- Ernesto -- 28 julio 2023
                        sqlExecute("insert into personal.dbo.pensiones_alimenticias values ('" & reloj.Text.Trim & "'," &
                                                                                               If(pensionado.Text.Trim = "", "NULL", "'" & pensionado.Text.Trim & "'") & ",'" &
                                                                                               porcentaje.Value & "','" &
                                                                                               tipo_pen.SelectedItem.ToString & "','" &
                                                                                               base_pen.Value & "'," &
                                                                                               If(fijo.Value, 1, 0) & "," &
                                                                                               If(cuenta.Text.Trim = "", "''", "'" & cuenta.Text.Trim & "'") & "," &
                                                                                               If(activo.Value, 1, 0) & "," &
                                                                                               If(apaterno.Text.Trim = "", "NULL", "'" & apaterno.Text.Trim & "'") & "," &
                                                                                               If(amaterno.Text.Trim = "", "NULL", "'" & amaterno.Text.Trim & "'") & "," &
                                                                                               If(nombre.Text.Trim = "", "NULL", "'" & nombre.Text.Trim & "'") & "," &
                                                                                               If(cuaderno.Text.Trim = "", "NULL", "'" & cuaderno.Text.Trim & "'") & ",'" &
                                                                                               num_pensio.Value & "'," &
                                                                                               If(cuenta_val.Text.Trim = "", "NULL", "'" & cuenta_val.Text.Trim & "'") & "," &
                                                                                               If(comentario.Text.Trim = "", "NULL", "'" & comentario.Text.Trim & "'") & "," &
                                                                                               If(IsNothing(inicio.ValueObject), "NULL", "'" & inicio.ValueObject & "'") & "," &
                                                                                               If(IsNothing(suspension.ValueObject), "NULL", "'" & suspension.ValueObject & "'") & "," &
                                                                                               If(mercantil.Value, 1, 0) & "," &
                                                                                               If(tarjeta_val.Text.Trim = "", "NULL", "'" & tarjeta_val.Text.Trim & "'") & "," &
                                                                                               If(interbancario.Value, 1, 0) & "," &
                                                                                               If(llave.Text = "", "NULL", "'" & llave.Text.Trim & "'") & ")")

                        sqlExecute("insert into nomina.dbo.pensiones_alimenticias values ('" & ano.Text & "','" &
                                                                                               periodo.Text & "','" &
                                                                                               reloj.Text & "'," &
                                                                                               monto.Value & ",'" &
                                                                                               cuenta0.Text & "','" &
                                                                                               nombre0.Text & "'," &
                                                                                               pension.Value & ",'" &
                                                                                               cod_comp.Text & "'," &
                                                                                               If(inter.Value, 1, 0) & ",'" &
                                                                                               tipo_periodo.Text & "',NULL," &
                                                                                               If(no_pago.Value, 1, 0) & ",'" & llave.Text & "')")
                        Agregar = False
                    End If
                Else
                    MessageBox.Show("Campo vacio. Por favor, ingrese un reloj.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

        ElseIf Editar Then
            Dim strActualiza = {"update personal.dbo.pensiones_alimenticias set ", "update nomina.dbo.pensiones_alimenticias set "}
            Dim cont = 0
            Dim dt = {dtVaciosPer, dtVaciosNom}
            Dim dic = {dicInfo, dicInfo2}

            For Each d In dt
                Dim strCampos = ""

                For Each c As DataColumn In d.Columns
                    Dim columna = c.ColumnName.ToLower.Replace("0", "")

                    If dic(cont).Keys.Contains(columna) Then
                        If columna = "tipo_pen" Then
                            If dic(cont)(columna).ToString <> ctrlInterfaz(columna, cont).ToString Then
                                strCampos &= columna & "=" & "'" & ctrlInterfaz(columna, cont).ToString & "',"
                            End If
                        Else
                            If dic(cont)(columna) <> ctrlInterfaz(columna, cont) Then
                                If {Nothing, ""}.Contains(ctrlInterfaz(columna, cont)) Then
                                    strCampos &= columna & "=NULL,"
                                ElseIf VarType(ctrlInterfaz(columna, cont)) = vbBoolean Then
                                    strCampos &= columna & "=" & If(ctrlInterfaz(columna, cont), 1, 0) & ","
                                ElseIf VarType(ctrlInterfaz(columna, cont)) = vbDate Then
                                    strCampos &= columna & "=" & "'" & FechaSQL(ctrlInterfaz(columna, cont)) & "',"
                                Else
                                    strCampos &= columna & "=" & "'" & ctrlInterfaz(columna, cont) & "',"
                                End If
                            End If
                        End If
                    End If
                Next

                If strCampos.Length > 0 Then
                    If cont = 0 Then
                        strActualiza(0) &= strCampos.Substring(0, strCampos.Length - 1) & " where id=" & strID
                        sqlExecute(strActualiza(0))
                    Else
                        strActualiza(1) &= strCampos.Substring(0, strCampos.Length - 1) & " where reloj='" & dic(0)("reloj") & "' and pension " &
                            If({Nothing, ""}.Contains(dic(1)("pension")), "is NULL", "='" & dic(1)("pension") & "'")
                        sqlExecute(strActualiza(1))
                    End If
                End If

                cont += 1
            Next
        Else
            Agregar = True
        End If

        Editar = False
        RefrescaDatatable()
        HabilitarBotones()
        MostrarInformacion()
    End Sub

    '-- Se llena la compañia de manera automática de acuerdo se vaya llenando el reloj
    Private Sub reloj_TextChanged(sender As Object, e As EventArgs) Handles reloj.TextChanged
        Try
            cod_comp.Text = dtComp.Select("reloj='" & reloj.Text.ToString.Trim & "'").First.Item("cod_comp").ToString.Trim
            tipo_periodo.Text = dtComp.Select("reloj='" & reloj.Text.ToString.Trim & "'").First.Item("tipo_periodo").ToString.Trim
            nombre.Text = dtComp.Select("reloj='" & reloj.Text.ToString.Trim & "'").First.Item("nombre").ToString
            amaterno.Text = dtComp.Select("reloj='" & reloj.Text.ToString.Trim & "'").First.Item("amaterno").ToString
            apaterno.Text = dtComp.Select("reloj='" & reloj.Text.ToString.Trim & "'").First.Item("apaterno").ToString
        Catch ex As Exception : cod_comp.Text = "" : tipo_periodo.Text = "" : End Try
    End Sub

    '-- La cuenta de la tabla de pensiones de nomina sera la misma que la de personal
    Private Sub nCuenta_TextChanged(sender As Object, e As EventArgs) Handles cuenta0.TextChanged
        Try : cuenta.Text = cuenta0.Text.ToString.Trim : Catch ex As Exception : End Try
    End Sub

    '-- Número de pensión cambian para ambas tablas personal y nómina
    Private Sub NumeroPension(sender As Object, e As EventArgs) Handles num_pensio.ValueChanged, pension.ValueChanged
        Try
            If Agregar Or Editar Then
                If sender.name = "num_pensio" Then
                    pension.Value = sender.Value
                Else
                    num_pensio.Value = sender.Value
                End If
            End If
        Catch ex As Exception : End Try
    End Sub


    Private Sub tipo_pen_SelectedValueChanged(sender As Object, e As EventArgs) Handles tipo_pen.SelectedValueChanged
        Try
            Dim dtDet = dtPensionesAlim.Select("tipo_pension='" & tipo_pen.SelectedItem.ToString & "'")
            If dtDet.Count > 0 Then
                lblCalc.Text = dtDet.First.Item("detalle")
            End If

        Catch ex As Exception : End Try
    End Sub
End Class