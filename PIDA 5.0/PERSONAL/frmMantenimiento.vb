Imports System.IO
Public Class frmMantenimiento

    Dim dtPeriodo As DataTable

    Private Sub frmMantenimiento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmMantenimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            dtPeriodo = sqlExecute("SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin,(CASE activo WHEN 1 THEN '   *' ELSE '' END) AS activo FROM periodos WHERE periodo_especial IS NULL OR periodo_especial = 0 ORDER BY ano DESC,periodo ASC", "TA")
            cmbPeriodos.DataSource = dtPeriodo

            dtTemporal = sqlExecute("SELECT TOP 1 ano + periodo as anoPeriodo FROM periodos WHERE activo = 1 ORDER BY ano DESC,periodo DESC", "TA")
            If dtTemporal.Rows.Count > 0 Then

                cmbPeriodos.SelectedValue = dtTemporal.Rows(0).Item("anoPeriodo")
            End If

            dtinicio.Value = DateSerial(Now.Year, Now.Month, 1)
            dtFin.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtinicio.Value))
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

        ''CargarAusentismos()

        'sqlExecute("delete  from ausentismo", "ta")
        'Dim dtperiodos As DataTable = sqlExecute("select * from periodos where periodo_especial = '0' order by ano asc, periodo asc", "ta")
        'For Each row_periodo As DataRow In dtperiodos.Rows
        '    Dim inicio As Date = row_periodo("fecha_ini")
        '    Dim fin As Date = row_periodo("fecha_fin")
        '    Dim dtAusentismo As DataTable = sqlExecute("select numero,fechainicial,fechafinal,tipo,isnull(folioincapacidad, '') as folioincapacidad from ausentismos where fechainicial between '" & FechaSQL(inicio) & "' and '" & FechaSQL(fin) & "'", "ta")
        '    For Each row_ausentismo As DataRow In dtAusentismo.Rows
        '        Dim reloj As String = Trim(row_ausentismo("numero"))
        '        Dim inicio_ausentismo As Date = row_ausentismo("fechainicial")
        '        Dim fin_ausentismo As Date = row_ausentismo("fechafinal")
        '        Dim tipo_aus As String = row_ausentismo("tipo")
        '        Dim referencia As String = row_ausentismo("folioincapacidad")

        '        Dim dias As Integer = fin_ausentismo.Subtract(inicio_ausentismo).TotalDays + 1
        '        For i As Integer = 0 To dias
        '            sqlExecute("insert into ausentismo(reloj, fecha, tipo_aus, referencia) values ('" & reloj & "', '" & FechaSQL(inicio_ausentismo.AddDays(i)) & "', '" & tipo_aus.Trim & "', " & IIf(referencia.Trim <> "", "'" & referencia & "'", "NULL") & ")", "ta")
        '        Next

        '    Next

        'Next

        'sqlExecute("update ta.dbo.ausentismo set ta.dbo.ausentismo.cod_comp = personal.dbo.personal.cod_comp from ta.dbo.ausentismo left join personal.dbo.personal on personal.dbo.personal.reloj = ta.dbo.ausentismo.reloj")

        Try
            'Solo tomar las compañías que tengan registros en campos_mantenimiento
            'Considerando que si no están, es porque no se genera mantenimiento
            cmbCia.DataSource = sqlExecute("SELECT DISTINCT campos_mantenimiento.COD_COMP,NOMBRE FROM campos_mantenimiento LEFT JOIN CIAS ON campos_mantenimiento.COD_COMP = CIAS.COD_COMP")
            cmbCia.ValueMember = "cod_comp"
            cmbCia.DisplayMembers = "cod_comp,nombre"
            cmbCia.Columns(0).Width.Absolute = 50
            cmbCia.Columns(0).Text = "Código"
            cmbCia.Columns(1).AutoSize()
            cmbCia.Columns(1).StretchToFill = True

            Dim dtCiaDefault As DataTable = sqlExecute("select top 1 * from cias where cia_default = '1'")
            If dtCiaDefault.Rows.Count Then
                cmbCia.SelectedValue = dtCiaDefault.Rows(0)("cod_comp")
            End If



            labelProgreso.Visible = False
            'BERE
            'dtPeriodos = sqlExecute("SELECT concat(ano,periodo) AS unico,ano as Año,periodo as Periodo,fecha_ini, fecha_fin FROM periodos ORDER BY ano DESC,periodo", "TA")
            'dtPeriodo = sqlExecute("SELECT (ano + periodo) AS unico,ano as Año,periodo as Periodo,fecha_ini, fecha_fin FROM periodos where activo = '1' ORDER BY ano DESC,periodo", "TA")

            'cmbPeriodo.DataSource = dtperiodos
            'cmbPeriodo.ValueMember = "unico"
            'cmbPeriodo.GroupingMembers = "Año"
            'cmbPeriodo.DisplayMembers = "Año, Periodo, fecha_ini, fecha_fin"
        Catch ex As Exception
            MessageBox.Show("La forma de mantenimiento tuvo errores al cargar. Si el problema persiste, contacte al administrador del sistema." & _
                            vbCrLf & vbCrLf & "Er.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private registros_bitacora As New ArrayList
    Public campos_mantenimiento As New ArrayList
    Public registros_mantenimiento As New ArrayList

    Public Structure campo_mantenimiento
        Public nombre_campo As String
        Public longitud As Integer
        Public query_personalvw As String
        Public altas As Boolean
        Public bajas As Boolean
    End Structure

    Private Structure registro_bitacora
        Public reloj As String
        Public campo As String
        Public valor As String
        Public tipo_movimiento As String
    End Structure

    Private Sub GenerarMantenimiento(sender As Object, e As EventArgs) Handles btnMantenimiento.Click
        'Dim unico As String = cmbPeriodo.SelectedValue
        Dim fecha_ini As Date
        Dim fecha_fin As Date
        Dim Archivo As String = ""
        Dim Cia As String
        Dim dtDatosReporte As New DataTable
        Dim dtReporte As New DataTable
        Dim dtCambios As New DataTable
        Dim reloj As String
        Dim TipoMov As String
        '----------------------------------------------------------
        Try

            If Not (btnAltas.Value Or btnBajas.Value Or btnCambios.Value Or btnModSal.Value) Then
                MessageBox.Show("Es necesario elegir al menos un tipo de movimiento a incluir en mantenimiento. Favor de verificar.", "Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub

            End If
            dtDatosReporte.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("cod_tipo_movimiento", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("tipo_movimiento", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("detalle1", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("encabezado1", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("detalle2", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("encabezado2", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("detalle3", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("encabezado3", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("detalle4", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("encabezado4", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("detalle5", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("encabezado5", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("detalle6", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("encabezado6", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("detalle7", Type.GetType("System.String"))
            dtDatosReporte.Columns.Add("encabezado7", Type.GetType("System.String"))

            '----------------------------------------------------------

            If optRango.Checked = True Then
                fecha_ini = dtinicio.Value
                fecha_fin = dtFin.Value
            Else
                fecha_ini = dtPeriodo.Select("unico = '" & cmbPeriodos.SelectedValue & "'")(0)("fecha_ini")
                fecha_fin = dtPeriodo.Select("unico = '" & cmbPeriodos.SelectedValue & "'")(0)("fecha_fin")
            End If

            dtReporte.Columns.Add("reloj", Type.GetType("System.String"))
            dtReporte.Columns.Add("nombres", Type.GetType("System.String"))
            dtReporte.Columns.Add("cod_tipo", Type.GetType("System.String"))
            dtReporte.Columns.Add("cod_clase", Type.GetType("System.String"))
            dtReporte.Columns.Add("alta", Type.GetType("System.String"))
            dtReporte.Columns.Add("cod_depto", Type.GetType("System.String"))
            dtReporte.Columns.Add("detalle_1", Type.GetType("System.String"))
            dtReporte.Columns.Add("detalle_2", Type.GetType("System.String"))
            dtReporte.Columns.Add("detalle_3", Type.GetType("System.String"))
            dtReporte.Columns.Add("detalle_4", Type.GetType("System.String"))


            btnCerrar.Visible = False
            btnMantenimiento.Visible = False
            pbAvance.Visible = True
            labelProgreso.Visible = True

            Cia = cmbCia.SelectedValue

            dlgArchivo.FileName = Cia & "MNT_" & cmbPeriodos.SelectedValue & cmbTipoEmp.SelectedValue & ".TXT"
            dlgArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            dlgArchivo.OverwritePrompt = True
            Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()

            If lDialogResult = Windows.Forms.DialogResult.Cancel Then
                'Si seleccionan "CANCEL", salir del procedimiento
                btnCerrar.Visible = True
                btnMantenimiento.Visible = True
                pbAvance.Visible = False
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                Archivo = dlgArchivo.FileName
            End If
            Me.Cursor = Cursors.WaitCursor

            CrearTabla(dtTemporal, cmbCia.SelectedValue)

            If btnAltas.Value = True Then

                Dim QAltas As String = "select reloj from personalvw where " & _
                 "alta between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & _
                 "' and cod_comp = '" & cmbCia.SelectedValue & _
                 "' and cod_tipo in ('" & IIf(cmbTipoEmp.SelectedValue = "T", "A', 'O", cmbTipoEmp.SelectedValue) & "','G')"

                Dim dtAltas As DataTable = sqlExecute(QAltas)
                If dtAltas.Rows.Count Then
                    Dim query_altas As String = "select "
                    For Each campo As campo_mantenimiento In campos_mantenimiento
                        If campo.altas Then
                            query_altas &= campo.query_personalvw & " as " & campo.nombre_campo & ","
                        Else
                            query_altas &= "'' as " & campo.nombre_campo & ","
                        End If
                    Next
                    query_altas &= "_ from personalvw where reloj in ("
                    For Each row As DataRow In dtAltas.Rows
                        query_altas &= "'" & row("reloj") & "',"
                    Next
                    query_altas &= "_) order by reloj asc"
                    query_altas = query_altas.Replace(",_", "")
                    query_altas = query_altas.Replace("TIPO_TRAN", "A")
                    Dim dtAltasMantenimiento As DataTable = sqlExecute(query_altas)
                    If dtAltasMantenimiento.Rows.Count Then
                        pbAvance.Value = 0
                        pbAvance.Maximum = dtAltasMantenimiento.Rows.Count
                        labelProgreso.Text = "Progreso: Analizando altas"
                        Application.DoEvents()

                        For Each row As DataRow In dtAltasMantenimiento.Rows
                            Dim reloj_mnt As String = row("reloj")
                            sqlExecute("insert into mnt_temp (reloj, tipo_movimiento) values ('" & reloj_mnt & "', 'A')")
                            For Each campo As campo_mantenimiento In campos_mantenimiento
                                Try
                                    Dim valor As String = IIf(IsDBNull(row(campo.nombre_campo)), "", row(campo.nombre_campo))
                                    sqlExecute("update mnt_temp set " & campo.nombre_campo.Trim & " = '" & valor.Trim & "' where reloj = '" & reloj_mnt & "'")
                                Catch ex As Exception
                                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
                                End Try
                            Next
                            pbAvance.Value += 1
                        Next
                    End If
                End If

                'reingresos
                'Dim dtReingreso As New DataTable
                Dim dtReingreso As DataTable = sqlExecute("select distinct(personal.reloj) from personal left join reingresos on personal.reloj = reingresos.reloj " & _
                                                          "where reingresos.alta between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & _
                                                          "' and  cod_comp = '" & cmbCia.SelectedValue & _
                                                          "' and cod_tipo in ('" & IIf(cmbTipoEmp.SelectedValue = "T", "A', 'O", cmbTipoEmp.SelectedValue) & "')")
                If dtReingreso.Rows.Count Then
                    pbAvance.Value = 0
                    pbAvance.Maximum = dtReingreso.Rows.Count
                    labelProgreso.Text = "Progreso: Analizando reingresos"
                    Application.DoEvents()

                    For Each row As DataRow In dtReingreso.Rows
                        sqlExecute("update mnt_temp set tipo_movimiento = 'R' where reloj = '" & row("reloj") & "' and tipo_movimiento in ('A')")
                        pbAvance.Value += 1
                    Next
                End If
            End If

            If btnBajas.Value Then
                'bajas
                'Dim dtBajas As DataTable = sqlExecute("select reloj from personalvw where " & _
                '                                      "baja between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & _
                '                                      "' and cod_comp = '" & cmbCia.SelectedValue & _
                '                                      "' and cod_tipo = '" & cmbTipoEmp.SelectedValue & "'")

                Dim dtBajas As DataTable = sqlExecute("select reloj from personalvw where " & _
                                                      "baja between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & _
                                                      "' and cod_comp = '" & cmbCia.SelectedValue & _
                                                      "' and cod_tipo in ('" & IIf(cmbTipoEmp.SelectedValue = "T", "A', 'O", cmbTipoEmp.SelectedValue) & "')" & _
                                                      " or RELOJ in ( " & _
                                                      " select distinct reloj from " & _
                                                      " bitacora_personal where tipo_movimiento = 'B' and " & _
                                                      " fecha < '" & FechaSQL(fecha_ini) & "' and reloj in (select reloj from personal " & _
                                                      " where COD_COMP = '" & cmbCia.SelectedValue & "' and COD_TIPO in ('" & IIf(cmbTipoEmp.SelectedValue = "T", "A', 'O", cmbTipoEmp.SelectedValue) & "'))" & _
                                                      " and fecha_mantenimiento between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "')")

                If dtBajas.Rows.Count Then
                    Dim query_bajas As String = "select "
                    For Each campo As campo_mantenimiento In campos_mantenimiento
                        If campo.bajas Then
                            query_bajas &= campo.query_personalvw & " as " & campo.nombre_campo & ","
                        Else
                            query_bajas &= "'' as " & campo.nombre_campo & ","
                        End If
                    Next
                    query_bajas &= "_ from personalvw where reloj in ("
                    For Each row As DataRow In dtBajas.Rows
                        query_bajas &= "'" & row("reloj") & "',"
                    Next
                    query_bajas &= "_) order by reloj asc"
                    query_bajas = query_bajas.Replace(",_", "")
                    query_bajas = query_bajas.Replace("TIPO_TRAN", "B")
                    Dim dtBajasMantenimiento As DataTable = sqlExecute(query_bajas)
                    If dtBajasMantenimiento.Rows.Count Then
                        pbAvance.Value = 0
                        pbAvance.Maximum = dtBajasMantenimiento.Rows.Count
                        labelProgreso.Text = "Progreso: Analizando bajas"
                        Application.DoEvents()

                        For Each row As DataRow In dtBajasMantenimiento.Rows
                            Dim reloj_mnt As String = row("reloj")
                            sqlExecute("insert into mnt_temp (reloj,tipo_movimiento) values ('" & reloj_mnt & "', 'B')")
                            For Each campo As campo_mantenimiento In campos_mantenimiento
                                Dim valor As String = row(campo.nombre_campo)
                                sqlExecute("update mnt_temp set " & campo.nombre_campo.Trim & " = '" & valor & "' where reloj = '" & reloj_mnt & "' and tipo_movimiento = 'B'")
                                pbAvance.Value += 1
                            Next
                        Next
                    End If
                End If
            End If

            If btnCambios.Value Or btnModSal.Value Then
                'cambios
                Dim TCambio As String
                TCambio = IIf(btnCambios.Value, "'C'", "")

                TCambio = TCambio & IIf(TCambio.Length > 0 And btnModSal.Value, ",", "") & IIf(btnModSal.Value, "'M'", "")
                'dtCambios = sqlExecute("select * from bitacora_personal where campo in " & _
                '                                        "(select campos_mantenimiento.nombre_campo from campos_mantenimiento where bitacora = '1') " & _
                '                                        "and convert(date, bitacora_personal.fecha) between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & _
                '                                        "' and tipo_movimiento in (" & TCambio & ") and valornuevo is not NULL and reloj in " & _
                '                                        "(select reloj from personalvw where cod_comp = '" & cmbCia.SelectedValue & _
                '                                        "' and cod_tipo = '" & cmbTipoEmp.SelectedValue & "') order by tipo_movimiento asc, reloj asc")

                sqlExecute("update bitacora_personal set bitacora_personal.valornuevo = PERSONAL.imss + PERSONAL.dig_ver from bitacora_personal left join personal on personal.RELOJ = bitacora_personal.reloj where bitacora_personal.campo = 'imss' and cast(bitacora_personal.fecha as DATE) between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "' and tipo_movimiento = 'C'")

                dtCambios = sqlExecute(
                   "select * from bitacora_personal where campo in " & _
                   "(select campos_mantenimiento.nombre_campo from campos_mantenimiento where bitacora = '1') " & _
                   "and " & _
                   "((" & _
                   "	convert(date, bitacora_personal.fecha_mantenimiento) between '" & FechaSQL(fecha_ini) & "' and GETDATE()" & _
                   "	and " & _
                   "	convert(date, bitacora_personal.fecha) <= '" & FechaSQL(fecha_fin) & "'" & _
                   "	)" & _
                   "or" & _
                   "	(" & _
                   "	convert(date, isnull(bitacora_personal.fecha_mantenimiento, convert(date,'" & FechaSQL(fecha_ini.AddDays(-1)) & "',126))) < '" & FechaSQL(fecha_ini) & "'" & _
                   "	and " & _
                   "	convert(date, bitacora_personal.fecha)  between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & "'" & _
                   "))" & _
                   "and tipo_movimiento in (" & TCambio & ") and valornuevo is not NULL and reloj in " & _
                   "(select reloj from personalvw where cod_comp = '" & cmbCia.SelectedValue & "' " & _
                   "and cod_tipo in ('" & IIf(cmbTipoEmp.SelectedValue = "T", "A', 'O", cmbTipoEmp.SelectedValue) & "')) order by tipo_movimiento asc, reloj asc"
               )

                If dtCambios.Rows.Count Then
                    pbAvance.Value = 0
                    pbAvance.Maximum = dtCambios.Rows.Count
                    labelProgreso.Text = "Progreso: Analizando cambios"
                    Application.DoEvents()

                    For Each row As DataRow In dtCambios.Select("", "fecha")
                        reloj = row("reloj")
                        If RTrim(row("campo")) = "clabe" Then
                            row("campo") = "cuenta_banco"
                            row("valornuevo") = "D" & RTrim(row("valornuevo"))

                        ElseIf RTrim(row("campo")) = "cuenta_banco" Then
                            row("valornuevo") = "B   000000" & RTrim(row("valornuevo")).PadLeft(10, "0")
                        ElseIf RTrim(row("campo")) = "cod_planta" Then
                            row("valornuevo") = Integer.Parse(row("valornuevo"))
                        End If

                        Dim dtExiste As DataTable = sqlExecute("select * from mnt_temp where reloj = '" & reloj & "'")
                        If dtExiste.Rows.Count <= 0 Then
                            sqlExecute("insert into mnt_temp (reloj, tipo_movimiento) values ('" & row("reloj") & "', '" & row("tipo_movimiento") & "')")
                            TipoMov = ""
                        Else
                            TipoMov = dtExiste.Rows(0).Item("tipo_movimiento")
                        End If

                        dtTemporal = sqlExecute(" SELECT data_type AS tipo, " & _
                                                       " character_maximum_length AS tamano, " & _
                                                       " numeric_precision AS tamano_numero," & _
                                                       " numeric_scale AS decimales " & _
                                                       " FROM information_schema.columns " & _
                                                       " WHERE table_name = 'personalvw' " & _
                                                       " AND column_name = '" & RTrim(row("campo")) & "'")
                        If dtTemporal.Rows.Count Then
                            Dim tipo As String = dtTemporal.Rows(0)("tipo")
                            Dim valor As String = row("valornuevo")
                            Select Case tipo
                                Case "char"
                                    valor = valor.ToUpper.Replace("-", "").Replace("Ñ", "#")
                                Case "date"
                                    valor = FechaSQL(Date.Parse(row("valornuevo"))).Replace("-", "")
                                Case "decimal"
                                    valor = String.Format("{0:N" & dtTemporal.Rows(0)("decimales") & "}", Double.Parse(valor))
                                    Select Case row("campo").ToString.Trim
                                        Case "sactual"
                                            valor = valor.PadLeft(8, " ")
                                        Case "factor_int"
                                            valor = valor.Replace("1.", "").PadLeft(6, " ")
                                    End Select
                            End Select

                            If row("tipo_movimiento") = "M" Then
                                sqlExecute("update mnt_temp set tipo_movimiento = 'M' where reloj = '" & row("reloj") & "' and (tipo_movimiento = 'C' or tipo_movimiento = 'M')")
                            End If

                            sqlExecute("update mnt_temp set " & row("campo") & " = '" & valor & "' where reloj = '" & row("reloj") & "' and (tipo_movimiento = 'C' or tipo_movimiento = 'M')")
                        End If

                        pbAvance.Value += 1
                    Next
                End If

                'reingresos
                'Dim dtReingreso As New DataTable
                Dim dtReingreso As DataTable = sqlExecute("select distinct(personal.reloj) from personal left join reingresos on personal.reloj = reingresos.reloj " & _
                                                          "where reingresos.alta between '" & FechaSQL(fecha_ini) & "' and '" & FechaSQL(fecha_fin) & _
                                                          "' and  cod_comp = '" & cmbCia.SelectedValue & _
                                                          "' and cod_tipo in ('" & IIf(cmbTipoEmp.SelectedValue = "T", "A', 'O", cmbTipoEmp.SelectedValue) & "')")
                If dtReingreso.Rows.Count Then
                    pbAvance.Value = 0
                    pbAvance.Maximum = dtReingreso.Rows.Count
                    labelProgreso.Text = "Progreso: Analizando reingresos"
                    Application.DoEvents()

                    For Each row As DataRow In dtReingreso.Rows
                        sqlExecute("update mnt_temp set tipo_movimiento = 'R' where reloj = '" & row("reloj") & "' and tipo_movimiento in ('C')")
                        pbAvance.Value += 1
                    Next
                End If

            End If

            'dejar en blanco los pagos en cero
            sqlExecute("update personal.dbo.mnt_temp set pago_inf = '       ' where pago_inf = '0      '")
            'Agregar el tipo de credito
            sqlExecute("update mnt set mnt.TIPO_CRE = per.TIPO_CRE " & _
                       "from personal.dbo.mnt_temp mnt inner join personal.dbo.personal per " & _
                       "on mnt.reloj = per.RELOJ and len(rtrim(mnt.pago_inf)) > 0 and mnt.tipo_cre is null")
            'tipo credito 3 lleva 4 decimales                   remover punto decimal agregar ceros
            sqlExecute("update personal.dbo.mnt_temp set pago_inf = replace(replace(str(pago_inf,8,4),'.',''),space(1),'0') where TIPO_CRE = '3'")
            'tipo credito 2 lleva 2 decimales
            sqlExecute("update personal.dbo.mnt_temp set pago_inf = replace(replace(str(pago_inf,8,2),'.',''),space(1),'0') where TIPO_CRE = '2'")
            'tipo credito 1 lleva 1 decimales
            sqlExecute("update personal.dbo.mnt_temp set pago_inf = replace(replace(str(pago_inf,8,1),'.',''),space(1),'0') where TIPO_CRE = '1'")

            Dim query_archivo As String = "select "
            For Each campo As campo_mantenimiento In campos_mantenimiento
                query_archivo &= "isnull(" & campo.nombre_campo & ", '') as " & campo.nombre_campo & ", "
            Next
            query_archivo &= "_ from mnt_temp"

            Dim dtArchivo As DataTable = sqlExecute(query_archivo.Replace(", _", ""))
            If dtArchivo.Rows.Count Then
                pbAvance.Value = 0
                pbAvance.Maximum = dtCambios.Rows.Count
                labelProgreso.Text = "Progreso: Generando archivo de mantenimiento"
                Application.DoEvents()
                Dim writer As New StreamWriter(Archivo)
                For Each row As DataRow In dtArchivo.Rows
                    Dim linea As String = ""
                    For Each campo As campo_mantenimiento In campos_mantenimiento
                        If campo.nombre_campo.Contains("dias") Then
                            linea &= RTrim(row(campo.nombre_campo)).PadLeft(campo.longitud, " ") & Space(1)
                        ElseIf campo.nombre_campo.Contains("sactual") Then
                            linea &= row(campo.nombre_campo).ToString.Replace(",", "").Trim.PadLeft(campo.longitud, " ") & Space(1)
                        ElseIf campo.nombre_campo.Contains("pago_inf") Then    'Se configuran 8 y se guardan 7 espacios
                            linea &= row(campo.nombre_campo).Trim.PadLeft(campo.longitud - 1, " ") & Space(1)
                        Else
                            linea &= row(campo.nombre_campo) & Space(1)
                        End If
                    Next
                    linea &= "_"
                    writer.WriteLine(linea.Replace(" _", ""))
                Next
                writer.Close()

                Try
                    Dim archivo_copia As String = DireccionReportes & "archivos_nomina\mantenimiento_" & Usuario.Trim
                    archivo_copia &= FechaHoraSQL(Now, True, False).Replace(":", "").Replace(Space(1), "").Replace("-", "") & ".txt"

                    File.Copy(Archivo, archivo_copia)
                Catch ex As Exception

                End Try

                MsgBox("Mantenimiento generado correctamente en " & Archivo, MsgBoxStyle.Information, "Mantenimiento exitoso")

            Else
                MsgBox("No hay registros que enviar al archivo mantenimiento en el rango: " & vbCrLf & FechaSQL(fecha_ini) & " - " & FechaSQL(fecha_fin), _
                       MsgBoxStyle.Information, "Mantenimiento en blanco")
            End If

            '--AOS - Contiene cod_hora y dias_aguiinaldo
            'Dim datos As String =
            '"SELECT " & _
            '"mnt_temp.reloj," & _
            '"personalvw.nombres, " & _
            '"mnt_temp.cod_depto," & _
            '"mnt_temp.cod_tipo," & _
            '"mnt_temp.imss," & _
            '"mnt_temp.cod_clase," & _
            '"mnt_temp.sactual," & _
            '"mnt_temp.cod_turno," & _
            '"case when len(rtrim(mnt_temp.alta)) > 0 then (substring(mnt_temp.alta, 1, 4) + '-' + substring(mnt_temp.alta, 5, 2) + '-' + substring(mnt_temp.alta, 7, 2)) else '' end as alta," & _
            '"mnt_temp.cod_super," & _
            '"mnt_temp.sexo," & _
            '"mnt_temp.rfc," & _
            '"case when len(rtrim(mnt_temp.fha_ult_mo)) > 0 then (substring(mnt_temp.fha_ult_mo, 1, 4) + '-' + substring(mnt_temp.fha_ult_mo, 5, 2) + '-' + substring(mnt_temp.fha_ult_mo, 7, 2)) else '' end as fha_ult_mo," & _
            '"mnt_temp.cod_hora," & _
            '"mnt_temp.cuenta_banco," & _
            '"mnt_temp.curp," & _
            '"'1.' + ltrim(mnt_temp.factor_int) as factor_int," & _
            '"case when len(rtrim(mnt_temp.baja)) > 0 then (substring(mnt_temp.baja, 1, 4) + '-' + substring(mnt_temp.baja, 5, 2) + '-' + substring(mnt_temp.baja, 7, 2)) else '' end as baja," & _
            '"mnt_temp.cod_mot_im," & _
            '"PersonalVW.motivo_baja_im as motivo_imss," & _
            '"PersonalVW.COD_MOT_BA," & _
            '"PersonalVW.motivo_baja as motivo_interno," & _
            '"mnt_temp.dias_vacaciones," & _
            '"mnt_temp.dias_aguinaldo," & _
            '"mnt_temp.tipo_movimiento," & _
            '"case tipo_movimiento when 'A' then '1' when 'R' then '1' when 'B' then '2' when 'C' then '3' when 'M' then '3' else '0' end as tipo," & _
            '"case tipo_movimiento when 'A' then 'ALTAS' when 'R' then 'REINGRESOS' when 'B' then 'BAJAS' when 'C' then 'CAMBIOS' when 'M' then 'MODIFICACIONES DE SUELDO' else 'INDEFINIDO' end as nombre_movimiento," & _
            '"'del " & FechaSQL(fecha_ini) & " al " & FechaSQL(fecha_fin) & "' as periodo " & _
            '"FROM mnt_temp " & _
            '"left join personalvw on personalvw.reloj = mnt_temp.reloj order by tipo_movimiento asc, reloj asc"

            '-- AOS - No trae cod_hora ni dias_aguinaldo
            Dim datos As String =
           "SELECT " & _
           "mnt_temp.reloj," & _
           "personalvw.nombres, " & _
           "mnt_temp.cod_depto," & _
           "mnt_temp.cod_tipo," & _
           "mnt_temp.imss," & _
           "mnt_temp.cod_clase," & _
           "mnt_temp.sactual," & _
           "mnt_temp.cod_turno," & _
           "case when len(rtrim(mnt_temp.alta)) > 0 then (substring(mnt_temp.alta, 1, 4) + '-' + substring(mnt_temp.alta, 5, 2) + '-' + substring(mnt_temp.alta, 7, 2)) else '' end as alta," & _
           "mnt_temp.cod_super," & _
           "mnt_temp.sexo," & _
           "mnt_temp.rfc," & _
           "case when len(rtrim(mnt_temp.fha_ult_mo)) > 0 then (substring(mnt_temp.fha_ult_mo, 1, 4) + '-' + substring(mnt_temp.fha_ult_mo, 5, 2) + '-' + substring(mnt_temp.fha_ult_mo, 7, 2)) else '' end as fha_ult_mo," & _
           "mnt_temp.cuenta_banco," & _
           "mnt_temp.curp," & _
           "'1.' + ltrim(mnt_temp.factor_int) as factor_int," & _
           "case when len(rtrim(mnt_temp.baja)) > 0 then (substring(mnt_temp.baja, 1, 4) + '-' + substring(mnt_temp.baja, 5, 2) + '-' + substring(mnt_temp.baja, 7, 2)) else '' end as baja," & _
           "mnt_temp.cod_mot_im," & _
           "PersonalVW.motivo_baja_im as motivo_imss," & _
           "PersonalVW.COD_MOT_BA," & _
           "PersonalVW.motivo_baja as motivo_interno," & _
           "mnt_temp.dias_vacaciones," & _
           "mnt_temp.tipo_movimiento," & _
           "case tipo_movimiento when 'A' then '1' when 'R' then '1' when 'B' then '2' when 'C' then '3' when 'M' then '3' else '0' end as tipo," & _
           "case tipo_movimiento when 'A' then 'ALTAS' when 'R' then 'REINGRESOS' when 'B' then 'BAJAS' when 'C' then 'CAMBIOS' when 'M' then 'MODIFICACIONES DE SUELDO' else 'INDEFINIDO' end as nombre_movimiento," & _
           "'del " & FechaSQL(fecha_ini) & " al " & FechaSQL(fecha_fin) & "' as periodo " & _
           "FROM mnt_temp " & _
           "left join personalvw on personalvw.reloj = mnt_temp.reloj order by tipo_movimiento asc, reloj asc"

            dtDatosReporte = sqlExecute(datos)
            frmVistaPrevia.LlamarReporte("Reporte mantenimiento", dtDatosReporte)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        Finally

            btnCerrar.Visible = True
            btnMantenimiento.Visible = True
            pbAvance.Visible = False
            labelProgreso.Visible = False

            Me.Cursor = Cursors.Arrow
        End Try


    End Sub


    Public Function CrearTabla(ByVal dtResulta As DataTable, cia As String) As Boolean
        Dim Cadena As String

        Try

            dtTemporal = sqlExecute("IF OBJECT_ID('dbo.mnt_temp', 'U') IS NOT NULL DROP TABLE dbo.mnt_temp")

            campos_mantenimiento.Clear()

            Dim dtCamposMantenimiento As DataTable = sqlExecute("select * from campos_mantenimiento where cod_comp = '" & cia & "' order by orden asc")
            If dtCamposMantenimiento.Rows.Count Then
                For Each row As DataRow In dtCamposMantenimiento.Rows
                    Dim campo As New campo_mantenimiento
                    With campo
                        .nombre_campo = row("nombre_campo")
                        .nombre_campo = .nombre_campo.Trim
                        .longitud = row("longitud")
                        .query_personalvw = row("query_personalvw")
                        .altas = row("altas")
                        .bajas = row("bajas")
                    End With
                    campos_mantenimiento.Add(campo)
                Next
            End If

            Cadena = "CREATE TABLE mnt_temp ("

            For Each campo As campo_mantenimiento In campos_mantenimiento
                Cadena = Cadena & campo.nombre_campo & " char(" & campo.longitud & ")" & IIf(campo.Equals(campos_mantenimiento(campos_mantenimiento.Count - 1)), ")", ",")
            Next

            sqlConexion.CommandText = Cadena
            sqlAdaptador.SelectCommand = sqlConexion
            sqlAdaptador.Fill(dtResulta)

            Return True

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            Return False
        End Try

    End Function



    Private Sub cmbCia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCia.SelectedValueChanged
        Dim dtBitacoraMnt As New DataTable
        Try
            If cmbCia.SelectedValue Is Nothing Then Exit Sub

            Dim dtTipos As DataTable = sqlExecute("SELECT cod_tipo,nombre FROM tipo_emp WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            Dim dr As DataRow = dtTipos.NewRow
            dr("cod_tipo") = "T"
            dr("nombre") = "Todos"
            dtTipos.Rows.Add(dr)

            cmbTipoEmp.DataSource = dtTipos
            cmbTipoEmp.ValueMember = "cod_tipo"
            cmbTipoEmp.DisplayMembers = "cod_tipo,nombre"

            cmbTipoEmp.SelectedValue = "T"

            cmbTipoEmp.Columns(0).Width.Absolute = 50
            cmbTipoEmp.Columns(0).Text = "Código"
            cmbTipoEmp.Columns(1).AutoSize()
            cmbTipoEmp.Columns(1).StretchToFill = True


            dtBitacoraMnt = sqlExecute("SELECT TOP 5 * FROM bitacora_mantenimiento WHERE exitoso = 1 AND cod_comp = '" & cmbCia.SelectedValue & _
                                                 "' ORDER BY fecha DESC")
            If dtBitacoraMnt.Rows.Count = 0 Then
                sqlExecute("INSERT INTO bitacora_mantenimiento (usuario,fecha,aumentos_antiguedad,exitoso,comentarios,cod_comp) " & _
                           "VALUES ('Inicio','2000-01-01 00:00',0,1,'Punto de inicio','" & cmbCia.SelectedValue & "')")
                dtBitacoraMnt = sqlExecute("SELECT TOP 5 * FROM bitacora_mantenimiento WHERE exitoso = 1 AND cod_comp = '" & cmbCia.SelectedValue & _
                                         "' ORDER BY fecha DESC")
            End If
            'cmbHistorico.DataSource = dtBitacoraMnt
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbCia_TextChanged(sender As Object, e As EventArgs) Handles cmbCia.TextChanged

    End Sub

    Private Sub optPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles optPeriodo.CheckedChanged
        Try
            cmbPeriodos.Enabled = optPeriodo.Checked
            dtinicio.Enabled = optRango.Checked
            dtFin.Enabled = optRango.Checked
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub optRango_CheckedChanged(sender As Object, e As EventArgs) Handles optRango.CheckedChanged
        Try
            cmbPeriodos.Enabled = optPeriodo.Checked
            dtinicio.Enabled = optRango.Checked
            dtFin.Enabled = optRango.Checked
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class
