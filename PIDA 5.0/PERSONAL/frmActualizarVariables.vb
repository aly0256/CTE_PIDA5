Public Class frmActualizarVariables
    Dim Archivo As String

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmActualizarVariables_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmActualizarVariables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblReloj.Text = ""
        Me.Height = 472
        Dim dtPeriodo As New DataTable
        Try
            dtPeriodo = sqlExecute("SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin,(CASE activo WHEN 1 THEN '   *' ELSE '' END) AS activo FROM periodos WHERE periodo_especial IS NULL OR periodo_especial = 0 ORDER BY ano DESC,periodo ASC", "TA")
            cmbPeriodos.DataSource = dtPeriodo
            cmbPeriodos.ValueMember = "fecha_fin"
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If MessageBox.Show("Los datos del archivo maestro serán modificados. ¿Está seguro de continuar?", "Carga de variables", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = vbYes Then
            CargaVariables(True)
        End If
    End Sub

    Private Sub CargaVariables(ByVal ActualizaDatos As Boolean)
        Dim TotalSueldos As Double = 0
        Dim TotalPromedios As Double = 0
        Dim TotalFactores As Double = 0
        Dim TotalIntegrados As Double
        Dim SActual As Double, ProVar As Double, Factor As Double, Integrado As Double
        'Dim Vacaciones As Double
        'Dim Cuenta As String
        Dim dtDiferenciaActualiza As New DataTable
        Dim dtDiferencias As New DataTable
        Dim dtDiferenciaCampos As New DataTable
        Dim LN As String
        Dim x As Integer
        Dim y As Integer
        Dim p As Double
        Dim d As Integer = 0
        Dim Cadena As String
        Dim dtUpdate As New DataTable
        Dim dtInfo As New DataTable
        Dim drDif As DataRow
        Dim drAct As DataRow
        Dim drDiferencias As DataRow
        Dim dtReloj As New DataTable
        Dim drReloj As DataRow

        Dim objReader As System.IO.StreamReader = Nothing
        dlgArchivo.FileName = "DATA.TXT"
        dlgArchivo.Multiselect = False
        dlgArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        Try
            Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()
            If lDialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                Archivo = dlgArchivo.FileName
            End If

            If System.IO.File.Exists(Archivo) = False Then
                MessageBox.Show("El archivo '" & Archivo & "' no existe. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            objReader = New System.IO.StreamReader(Archivo)

            x = 0
            y = objReader.BaseStream.Length
            cpActualizacion.Maximum = 100
            cpActualizacion.Visible = True
            btnActualizar.Enabled = False
            btnSimular.Enabled = False
            btnSalir.Enabled = False
            Application.DoEvents()

            dtReloj.Columns.Add("Reloj", GetType(System.String))

            dtDiferenciaCampos.Columns.Add("Reloj", GetType(System.String))
            dtDiferenciaCampos.Columns.Add("Nombre", GetType(System.String))
            dtDiferenciaCampos.Columns.Add("Campo", GetType(System.String))
            dtDiferenciaCampos.Columns.Add("Valor_PIDA", GetType(System.String))
            dtDiferenciaCampos.Columns.Add("Valor_Nómina", GetType(System.String))


            dtDiferencias.Columns.Add("Reloj", GetType(System.String))
            dtDiferencias.Columns.Add("AltaPIDA", GetType(System.String))
            dtDiferencias.Columns.Add("AltaCOMPUTO", GetType(System.String))
            dtDiferencias.Columns.Add("BajaPIDA", GetType(System.String))
            dtDiferencias.Columns.Add("BajaCOMPUTO", GetType(System.String))
            dtDiferencias.Columns.Add("NombresPIDA", GetType(System.String))
            dtDiferencias.Columns.Add("NombresCOMPUTO", GetType(System.String))
            dtDiferencias.Columns.Add("SActualPIDA", GetType(System.Double))
            dtDiferencias.Columns.Add("SActualCOMPUTO", GetType(System.Double))
            dtDiferencias.Columns.Add("ProVarPIDA", GetType(System.Double))
            dtDiferencias.Columns.Add("ProVarCOMPUTO", GetType(System.Double))
            dtDiferencias.Columns.Add("IntegradoPIDA", GetType(System.Double))
            dtDiferencias.Columns.Add("IntegradoCOMPUTO", GetType(System.Double))
            dtDiferencias.Columns.Add("FactIntPIDA", GetType(System.Double))
            dtDiferencias.Columns.Add("FactIntCOMPUTO", GetType(System.Double))
            dtDiferencias.Columns.Add("cod_deptoPIDA", GetType(System.String))
            dtDiferencias.Columns.Add("cod_deptoCOMPUTO", GetType(System.String))
            dtDiferencias.Columns.Add("cod_tipoPIDA", GetType(System.String))
            dtDiferencias.Columns.Add("cod_tipoCOMPUTO", GetType(System.String))
            dtDiferencias.Columns.Add("cod_clasePIDA", GetType(System.String))
            dtDiferencias.Columns.Add("cod_claseCOMPUTO", GetType(System.String))
            dtDiferencias.Columns.Add("cod_turnoPIDA", GetType(System.String))
            dtDiferencias.Columns.Add("cod_turnoCOMPUTO", GetType(System.String))
            dtDiferencias.Columns.Add("SexoPIDA", GetType(System.String))
            dtDiferencias.Columns.Add("SexoCOMPUTO", GetType(System.String))
            dtDiferencias.Columns.Add("IMSSPIDA", GetType(System.String))
            dtDiferencias.Columns.Add("IMSSCOMPUTO", GetType(System.String))
            dtDiferencias.Columns.Add("RFC_PIDA", GetType(System.String))
            dtDiferencias.Columns.Add("RFC_COMPUTO", GetType(System.String))
            dtDiferencias.Columns.Add("CURP_PIDA", GetType(System.String))
            dtDiferencias.Columns.Add("CURP_COMPUTO", GetType(System.String))

            dtDiferenciaActualiza = dtDiferencias

            Me.Height = 472

            'If ActualizaDatos Then
            '    '*** INICIALIZAR A 0 TODOS LOS VARIABLES ****
            '    sqlExecute("UPDATE personal SET pro_var = 0 WHERE pro_var<>0 AND baja IS NULL")
            'End If

            Do Until objReader.EndOfStream
                LN = objReader.ReadLine

                LN = LN.Trim

                If LN.Length < 70 Then
                    MessageBox.Show("El archivo no contiene la estructura requerida para la carga de variables. Favor de verificar." _
                                    , "Carga de variables", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Do
                End If
                If LN.Substring(0, 1) <> "*" Then

                    x = x + LN.Length
                    p = (x / y) * 100

                    cpActualizacion.Value = Math.Round(p, 2)
                    cpActualizacion.ProgressText = Math.Round(p, 2)

                    'Los archivos que se importan del 400, el reloj tienen siempre longitud de 5
                    Reloj = LN.Substring(0, 6).Trim.PadLeft(LongReloj, "0")
                    Factor = Val(LN.Substring(67, 6))
                    ProVar = Val(LN.Substring(86, 6).Trim.PadLeft(LongReloj, "0"))
                    lblReloj.Text = "Reloj " & Reloj
                    Dim nombres As String = LN.Substring(6, 49)
                    Dim cod_depto As String = LN.Substring(133, 6)
                    Dim cod_clase As String = LN.Substring(144, 1)
                    If cod_clase = "0" Then
                        cod_clase = "D"
                    ElseIf cod_clase = "1" Then
                        cod_clase = "I"
                    Else
                        cod_clase = "A"
                    End If
                    Dim cod_turno As String = LN.Substring(146, 1)
                    Dim sexo As String = LN.Substring(148, 1)
                    Dim imss As String = LN.Substring(150, 11)
                    Dim rfc As String = LN.Substring(162, 13)
                    Dim curp As String = LN.Substring(176, 18)
                    Dim alta As String = FechaSQL(Date.Parse(LN.Substring(195, 10)))
                    Dim baja As String
                    If LN.Length > 206 Then
                        baja = FechaSQL(Date.Parse(LN.Substring(206, 10)))
                    Else
                        baja = Nothing
                    End If
                    'dtInfo = sqlExecute("SELECT reloj,alta,baja,sactual,pro_var,factor_int,integrado,cuenta_banco,ISNULL(vacaciones_desde_variables,0) as actualiza," & _
                    '                    "ISNULL((SELECT TOP 1 saldo_dinero FROM saldos_vacaciones where reloj = personalvw.reloj ORDER BY fecha_fin DESC),0) " & _
                    '                    "as vacaciones " & _
                    '                    "from personalvw,parametros WHERE reloj = '" & Reloj & "'")

                    dtInfo = sqlExecute("SELECT reloj,nombres,alta,baja,sactual,pro_var,factor_int,integrado, COD_DEPTO, COD_CLASE, COD_TIPO, COD_TURNO, NOMBRE, APATERNO, AMATERNO, SEXO, IMSS+DIG_VER AS IMSS, RFC, CURP from personalvw WHERE reloj = '" & Reloj & "'")
                    If dtInfo.Rows.Count <> 0 Then
                        For Each row As DataRow In dtInfo.Rows
                            ConsultaBitacora(dtInfo, row, Date.Parse(cmbPeriodos.SelectedValue))
                        Next

                        If dtInfo.Columns.Count > 0 Then
                            If dtInfo.Columns(0).ColumnName = "ERROR" Then
                                Err.Raise(-1, Nothing, dtInfo.Rows(0).Item(0))
                            End If
                        End If

                        SActual = dtInfo.Rows.Item(0).Item("sactual")
                        Integrado = (SActual * Factor) + ProVar

                        If dtInfo.Rows.Count > 0 Then
                            TotalSueldos = TotalSueldos + SActual
                            TotalPromedios = TotalPromedios + ProVar
                            TotalFactores = TotalFactores + Factor
                            TotalIntegrados = TotalIntegrados + Integrado

                            If IsDBNull(dtInfo.Rows.Item(0).Item("baja")) And _
                                (dtInfo.Rows.Item(0).Item("sactual") <> SActual Or _
                                 dtInfo.Rows.Item(0).Item("factor_int") <> Factor Or _
                                 dtInfo.Rows.Item(0).Item("integrado") <> Integrado) Then
                                'Or _
                                'IIf(dtInfo.Rows.Item(0).Item("actualiza") = 1, Vacaciones, dtInfo.Rows.Item(0).Item("vacaciones")) <> Vacaciones Or _
                                'dtInfo.Rows.Item(0).Item("cuenta_banco") <> Cuenta) Then
                                'Insertar registro de diferencias
                                drDif = dtDiferencias.NewRow
                                drDiferencias = dtDiferenciaCampos.NewRow
                                drDif("reloj") = dtInfo.Rows.Item(0).Item("reloj")
                                drDif("AltaPIDA") = FechaSQL(dtInfo.Rows.Item(0).Item("alta"))
                                drDif("AltaCOMPUTO") = alta

                                If IsDBNull(dtInfo.Rows.Item(0).Item("baja")) Then
                                    drDif("BajaPIDA") = DBNull.Value
                                Else
                                    drDif("BajaPIDA") = FechaSQL(dtInfo.Rows.Item(0).Item("baja"))
                                End If
                                drDif("BajaCOMPUTO") = baja
                                drDif("NombresPIDA") = dtInfo.Rows.Item(0).Item("nombres")
                                drDif("NombresCOMPUTO") = nombres
                                drDif("SActualPIDA") = dtInfo.Rows.Item(0).Item("sactual")
                                drDif("SActualCOMPUTO") = SActual
                                drDif("ProVarPIDA") = dtInfo.Rows.Item(0).Item("pro_var")
                                drDif("ProVarCOMPUTO") = ProVar
                                drDif("IntegradoPIDA") = dtInfo.Rows.Item(0).Item("integrado")
                                drDif("IntegradoCOMPUTO") = Math.Round(Integrado, 2)
                                drDif("FactIntPIDA") = dtInfo.Rows.Item(0).Item("factor_int")
                                drDif("FactIntCOMPUTO") = Factor

                                drDif("cod_deptoPIDA") = RTrim(dtInfo.Rows.Item(0).Item("cod_depto"))
                                drDif("cod_deptoCOMPUTO") = cod_depto

                                drDif("cod_clasePIDA") = RTrim(dtInfo.Rows.Item(0).Item("cod_clase"))
                                drDif("cod_claseCOMPUTO") = cod_clase

                                drDif("cod_turnoPIDA") = dtInfo.Rows.Item(0).Item("cod_turno")
                                drDif("cod_turnoCOMPUTO") = cod_turno

                                drDif("SexoPIDA") = dtInfo.Rows.Item(0).Item("sexo")
                                drDif("SexoCOMPUTO") = sexo

                                drDif("IMSSPIDA") = dtInfo.Rows.Item(0).Item("imss")
                                drDif("IMSSCOMPUTO") = imss

                                drDif("RFC_PIDA") = dtInfo.Rows.Item(0).Item("rfc")
                                drDif("RFC_COMPUTO") = rfc

                                drDif("CURP_PIDA") = dtInfo.Rows.Item(0).Item("curp")
                                drDif("CURP_COMPUTO") = curp

                                'drDif("DiferenciaSActual") = dtInfo.Rows.Item(0).Item("sactual") - SActual
                                'drDif("DiferenciaIntegrado") = dtInfo.Rows.Item(0).Item("factor_int") - Factor
                                'drDif("DiferenciaFactInt") = dtInfo.Rows.Item(0).Item("integrado") - Integrado


                                If IIf(IsDBNull(drDif("AltaPIDA")), "", drDif("AltaPIDA")) <> IIf(IsDBNull(drDif("AltaCOMPUTO")), "", drDif("AltaCOMPUTO")) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "ALTA"
                                    drDiferencias("Valor_PIDA") = drDif("AltaPIDA")
                                    drDiferencias("Valor_Nómina") = drDif("AltaCOMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If

                                If IIf(IsDBNull(drDif("BajaPIDA")), "", drDif("BajaPIDA")) <> IIf(IsDBNull(drDif("BajaCOMPUTO")), "", drDif("BajaCOMPUTO")) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "BAJA"
                                    drDiferencias("Valor_PIDA") = drDif("BajaPIDA")
                                    drDiferencias("Valor_Nómina") = drDif("BajaCOMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If

                                If IIf(IsDBNull(drDif("NombresPIDA")), "", RTrim(drDif("NombresPIDA"))) <> IIf(IsDBNull(drDif("NombresCOMPUTO")), "", RTrim(drDif("NombresCOMPUTO"))) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "NOMBRE"
                                    drDiferencias("Valor_PIDA") = RTrim(drDif("NombresPIDA"))
                                    drDiferencias("Valor_Nómina") = RTrim(drDif("NombresCOMPUTO"))
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If

                                If IIf(IsDBNull(drDif("SActualPIDA")), 0.0, drDif("SActualPIDA")) <> IIf(IsDBNull(drDif("SActualCOMPUTO")), 0.0, drDif("SActualCOMPUTO")) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "SALARIO ACTUAL"
                                    drDiferencias("Valor_PIDA") = drDif("SActualPIDA")
                                    drDiferencias("Valor_Nómina") = drDif("SActualCOMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If

                                If IIf(IsDBNull(drDif("ProVarPIDA")), 0.0, drDif("ProVarPIDA")) <> IIf(IsDBNull(drDif("ProVarCOMPUTO")), 0.0, drDif("ProVarCOMPUTO")) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "PROMEDIO VARIABLE"
                                    drDiferencias("Valor_PIDA") = drDif("ProVarPIDA")
                                    drDiferencias("Valor_Nómina") = drDif("ProVarCOMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If
                                If IIf(IsDBNull(drDif("IntegradoPIDA")), 0.0, drDif("IntegradoPIDA")) <> IIf(IsDBNull(drDif("IntegradoCOMPUTO")), 0.0, drDif("IntegradoCOMPUTO")) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "INTEGRADO"
                                    drDiferencias("Valor_PIDA") = drDif("IntegradoPIDA")
                                    drDiferencias("Valor_Nómina") = drDif("IntegradoCOMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If
                                If IIf(IsDBNull(drDif("FactIntPIDA")), 0.0, drDif("FactIntPIDA")) <> IIf(IsDBNull(drDif("FactIntCOMPUTO")), 0.0, drDif("FactIntCOMPUTO")) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "FACTOR"
                                    drDiferencias("Valor_PIDA") = drDif("IntegradoPIDA")
                                    drDiferencias("Valor_Nómina") = drDif("IntegradoCOMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If
                                If IIf(IsDBNull(drDif("cod_deptoPIDA")), "", RTrim(drDif("cod_deptoPIDA"))) <> IIf(IsDBNull(drDif("cod_deptoCOMPUTO")), "", RTrim(drDif("cod_deptoCOMPUTO"))) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "DEPARTAMENTO"
                                    drDiferencias("Valor_PIDA") = drDif("cod_deptoPIDA")
                                    drDiferencias("Valor_Nómina") = drDif("cod_deptoCOMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If

                                If IIf(IsDBNull(drDif("cod_clasePIDA")), "", RTrim(drDif("cod_clasePIDA"))) <> IIf(IsDBNull(drDif("cod_claseCOMPUTO")), "", RTrim(drDif("cod_claseCOMPUTO"))) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "CLASE"
                                    drDiferencias("Valor_PIDA") = drDif("cod_clasePIDA")
                                    drDiferencias("Valor_Nómina") = drDif("cod_claseCOMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If


                                If IIf(IsDBNull(drDif("cod_turnoPIDA")), "", RTrim(drDif("cod_turnoPIDA"))) <> IIf(IsDBNull(drDif("cod_turnoCOMPUTO")), "", RTrim(drDif("cod_turnoCOMPUTO"))) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "TURNO"
                                    drDiferencias("Valor_PIDA") = drDif("cod_turnoPIDA")
                                    drDiferencias("Valor_Nómina") = drDif("cod_turnoCOMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If
                                If IIf(IsDBNull(drDif("SexoPIDA")), "", RTrim(drDif("SexoPIDA"))) <> IIf(IsDBNull(drDif("SexoCOMPUTO")), "", RTrim(drDif("SexoCOMPUTO"))) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "SEXO"
                                    drDiferencias("Valor_PIDA") = drDif("SexoPIDA")
                                    drDiferencias("Valor_Nómina") = drDif("SexoCOMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If
                                If IIf(IsDBNull(drDif("IMSSPIDA")), "", RTrim(drDif("IMSSPIDA"))) <> IIf(IsDBNull(drDif("IMSSCOMPUTO")), "", RTrim(drDif("IMSSCOMPUTO"))) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "IMSS"
                                    drDiferencias("Valor_PIDA") = drDif("IMSSPIDA")
                                    drDiferencias("Valor_Nómina") = drDif("IMSSCOMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If
                                If IIf(IsDBNull(drDif("RFC_PIDA")), "", RTrim(drDif("RFC_PIDA"))) <> IIf(IsDBNull(drDif("RFC_COMPUTO")), "", RTrim(drDif("RFC_COMPUTO"))) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "RFC"
                                    drDiferencias("Valor_PIDA") = drDif("RFC_PIDA")
                                    drDiferencias("Valor_Nómina") = drDif("RFC_COMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If
                                If IIf(IsDBNull(drDif("CURP_PIDA")), "", RTrim(drDif("CURP_PIDA"))) <> IIf(IsDBNull(drDif("CURP_COMPUTO")), "", RTrim(drDif("CURP_COMPUTO"))) Then
                                    drDiferencias = dtDiferenciaCampos.NewRow
                                    drDiferencias("Reloj") = drDif("reloj")
                                    drDiferencias("Nombre") = RTrim(dtInfo.Rows.Item(0).Item("nombres"))
                                    drDiferencias("Campo") = "CURP"
                                    drDiferencias("Valor_PIDA") = drDif("CURP_PIDA")
                                    drDiferencias("Valor_Nómina") = drDif("CURP_COMPUTO")
                                    dtDiferenciaCampos.Rows.Add(drDiferencias)
                                End If

                                'dtDiferenciaCampos.Rows.Add(drDiferencias)

                            End If
                            If ActualizaDatos Then
                                    If IsDBNull(dtInfo.Rows.Item(0).Item("baja")) And _
                                        (dtInfo.Rows.Item(0).Item("sactual") <> SActual Or _
                                         dtInfo.Rows.Item(0).Item("factor_int") <> Factor Or _
                                         dtInfo.Rows.Item(0).Item("integrado") <> Integrado) Then
                                        drAct = dtDiferenciaActualiza.NewRow
                                        drAct("reloj") = dtInfo.Rows.Item(0).Item("reloj")
                                        drAct("altaPIDA") = FechaSQL(dtInfo.Rows.Item(0).Item("alta"))
                                    If IsDBNull(dtInfo.Rows.Item(0).Item("baja")) Then
                                        drAct("BajaPIDA") = DBNull.Value
                                    Else
                                        drAct("BajaPIDA") = FechaSQL(dtInfo.Rows.Item(0).Item("baja"))
                                    End If
                                    'drAct("NombresPIDA") = ""
                                        drAct("SActualPIDA") = dtInfo.Rows.Item(0).Item("sactual")
                                        drAct("SActualCOMPUTO") = SActual
                                        drAct("ProVarPIDA") = dtInfo.Rows.Item(0).Item("pro_var")
                                        drAct("ProVarCOMPUTO") = ProVar
                                        drAct("IntegradoPIDA") = dtInfo.Rows.Item(0).Item("integrado")
                                        drAct("IntegradoCOMPUTO") = Math.Round(Integrado, 2)
                                        drAct("FactIntPIDA") = dtInfo.Rows.Item(0).Item("factor_int")
                                        drAct("FactIntCOMPUTO") = Factor
                                        dtDiferenciaActualiza.Rows.Add(drAct)
                                    End If

                                    dtTemporal = sqlExecute("UPDATE personal SET pro_var = " & ProVar & "," & _
                                                            "factor_int = " & Factor & "," & _
                                                            "integrado = " & Integrado & _
                                                            " WHERE reloj = '" & Reloj & "'")

                                    If dtTemporal.Columns.Count > 0 Then
                                        If dtTemporal.Columns(0).ColumnName = "ERROR" Then
                                            'Si existe la columna ERROR en la tabla resultante, provocar un error en este procedimiento para terminarlo
                                            Err.Raise(-1, Nothing, dtTemporal.Rows(0).Item(0))
                                        End If
                                    End If


                                    Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                                    Cadena = Cadena & Reloj & "','sactual'," & dtInfo.Rows.Item(0).Item("sactual") & "," & SActual & ",'" & Usuario & "',GETDATE(),'V')"
                                    sqlExecute(Cadena)

                                    Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                                    Cadena = Cadena & Reloj & "','pro_var'," & dtInfo.Rows.Item(0).Item("pro_var") & "," & ProVar & ",'" & Usuario & "',GETDATE(),'V')"
                                    sqlExecute(Cadena)

                                    Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                                    Cadena = Cadena & Reloj & "','factor_int'," & dtInfo.Rows.Item(0).Item("factor_int") & "," & Factor & ",'" & Usuario & "',GETDATE(),'V')"
                                    sqlExecute(Cadena)

                                    Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                                    Cadena = Cadena & Reloj & "','integrado'," & dtInfo.Rows.Item(0).Item("integrado") & "," & Integrado & ",'" & Usuario & "',GETDATE(),'V')"
                                    sqlExecute(Cadena)
                                End If

                            End If

                        Else
                            drReloj = dtReloj.NewRow '
                            drReloj("reloj") = Reloj
                            dtReloj.Rows.Add(drReloj)
                        End If

                    End If

                    Application.DoEvents()
            Loop

            lblReloj.Text = ""
            cpActualizacion.Visible = False
            Application.DoEvents()
            objReader.Close()

        Catch ex As Exception
            lblReloj.Text = ""
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "LibreriasVFP", ex.HResult, ex.Message)
            MessageBox.Show("Se detectaron errores durante la carga, por lo que el proceso no pudo ser completado." & vbCrLf & vbCrLf & "Err.-" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cpActualizacion.Visible = False
            'Dim relojes As String
            If dtReloj.Rows.Count > 0 Then
                Dim mystring = ""
                For Each dr As DataRow In dtReloj.Rows
                    mystring &= dr.Item(0).ToString & vbCrLf
                Next
                MessageBox.Show("No se localizaron los empleados con número de reloj: " & vbCrLf & mystring, "Empleados no localizados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If ActualizaDatos Then
                If dtDiferenciaActualiza.Rows.Count > 0 Then
                    dtFiltroPersonal = dtDiferenciaActualiza
                    frmVistaPrevia.LlamarReporte("Diferencias carga de variables", dtFiltroPersonal)
                    frmVistaPrevia.ShowDialog()
                End If
            Else
                If dtDiferenciaCampos.Rows.Count > 0 Then
                    dtFiltroPersonal = dtDiferenciaCampos
                    'frmVistaPrevia.LlamarReporte("Diferencias carga de variables", dtFiltroPersonal)
                    frmVistaPrevia.LlamarReporte("BRP_Diferencias en datos", dtFiltroPersonal)
                    frmVistaPrevia.ShowDialog()
                End If
            End If

            btnActualizar.Enabled = True
            btnSimular.Enabled = True
            btnSalir.Enabled = True
            d = 1
            Me.Height = 472
        End Try
    End Sub
    Private Sub btnSimular_Click(sender As Object, e As EventArgs) Handles btnSimular.Click
        If MessageBox.Show("Los datos del archivo maestro NO serán modificados.", "Simular carga de variables", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = vbOK Then
            CargaVariables(False)
        End If
    End Sub
    
End Class