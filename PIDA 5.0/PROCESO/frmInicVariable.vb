Public Class frmInicVariable
    Dim dtPeriodos As New DataTable
    Dim dt_periodos As New DataTable
    Dim perActivo As String = ""

    Private Sub frmInicVariable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtAno As New DataTable
        Dim anio_actual As String = ""
        Try
            anio_actual = Now.Year.ToString.Trim
            dtAno = sqlExecute("select distinct ano from periodos_variables as ano ", "TA")

            cmbAno.DataSource = dtAno
            cmbAno.SelectedValue = anio_actual


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbAno_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cmbAno.SelectionChanged
        Try

            dtPeriodos = sqlExecute("SELECT TOP 1 bimestre FROM periodos_variables WHERE ano = '" & cmbAno.SelectedValue & "' and isnull(asentado,0)=0 order by bimestre asc", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                perActivo = dtPeriodos.Rows(0).Item("bimestre")
            End If

            dtPeriodos = sqlExecute("SELECT bimestre FROM periodos_variables WHERE ano = '" & cmbAno.SelectedValue & "' ORDER BY bimestre", "TA")
            cmbPerVar.DataSource = dtPeriodos
            If perActivo.Length > 0 Then
                cmbPerVar.SelectedValue = perActivo
                '   cmbPeriodoVar.Text = perActivo.Trim
            Else
                cmbPerVar.SelectedIndex = 0
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnIniciProcVar_Click(sender As Object, e As EventArgs) Handles btnIniciProcVar.Click
        cmbAno.Enabled = False
        cmbPerVar.Enabled = False
        btnIniciProcVar.Enabled = False


        Try

            Dim _ano As String = cmbAno.SelectedValue
            Dim _bimestre As String = cmbPerVar.SelectedValue

            Dim QP As String = "select * from periodos_variables where ano = '" & _ano & "' and bimestre = '" & _bimestre & "' and isnull(asentado,0)=0"
            Dim dt_bimestre As DataTable = sqlExecute(QP, "TA")

            If (dt_bimestre.Columns.Contains("Error") Or dt_bimestre.Rows.Count <= 0) Then
                MessageBox.Show("El bimestre no puede ser inicializado ya que se encuentra calculado y asentado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbAno.Enabled = True
                cmbPerVar.Enabled = True
                btnIniciProcVar.Enabled = True
                Exit Sub
            End If

            If dt_bimestre.Rows.Count > 0 Then
                'limpiar tablas

                labelEstatus.Text = "Limpiando proceso anterior [1/3]"
                sqlExecute("truncate table variables_nom_pro", "NOMINA")
                Application.DoEvents()

                labelEstatus.Text = "Limpiando proceso anterior [2/3]"
                sqlExecute("truncate table variables_mov_pro", "NOMINA")
                Application.DoEvents()

                labelEstatus.Text = "Limpiando proceso anterior [3/3]"
                sqlExecute("truncate table variable_status_proc", "NOMINA")
                Application.DoEvents()

                ' ObtenerDatosDesdePersonal(_ano, _periodo, _fecha_ini, _fecha_fin) ' Actualizar nomina_pro desde PERSONALVW y desde INFONAVIT
                GetDataFromPersForCalcVar(_ano, _bimestre)

                MessageBox.Show("Proceso inicializado correctamente", "Proceso inicializado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                labelEstatus.Text = ""

                '---Actualizar status_proceso indicando que ya está listo el paso 2 que es Inicializar Nómina
                Dim dtStProc As DataTable = sqlExecute("select distinct ano,bimestre from variables_nom_pro order by bimestre asc", "NOMINA")
                If (Not dtStProc.Columns.Contains("Error") And dtStProc.Rows.Count > 0) Then
                    Dim _anioSt As String = "", _bimSt As String = ""
                    Try : _anioSt = dtStProc.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : _anioSt = "" : End Try
                    Try : _bimSt = dtStProc.Rows(0).Item("bimestre").ToString.Trim : Catch ex As Exception : _bimSt = "" : End Try
                    sqlExecute("insert into variable_status_proc (ano,bimestre,avance,usuario,datetime) values ('" & _anioSt & "','" & _bimSt & "','2','" & Usuario & "',Getdate())", "NOMINA")
                End If

            Else
                MessageBox.Show("El bimestre seleccionado no existe o no está correctamente configurado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al inicializar, último paso: " & labelEstatus.Text, "Error al inicializar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            labelEstatus.Text = ""
        End Try

        cmbAno.Enabled = True
        cmbPerVar.Enabled = True
        btnIniciProcVar.Enabled = True


    End Sub

    Private Sub GetDataFromPersForCalcVar(_ano As String, _bimestre As String)
        Try
            Dim QP As String = "select * from personalvw where isnull(SACTUAL,0)<>0 and isnull(baja,'')='' and isnull(reloj,'')<>'' order by reloj asc" ' Aplica a todos lo activos automaticamente
            Dim dtActivos As DataTable = sqlExecute(QP, "PERSONAL")
            Dim bim_act As String = ""

            Dim empleados_a_importar As Integer = dtActivos.Rows.Count
            Dim contador_empleados As Integer = 1
            bim_act = _ano.Trim & _bimestre.Trim & "A"

            For Each row_activos As DataRow In dtActivos.Rows
                Dim _reloj As String = row_activos("reloj").ToString.Trim
                Dim _tipo_periodo As String = "", esbaja As Boolean = False


                Try : _tipo_periodo = row_activos("tipo_periodo").ToString.Trim : Catch ex As Exception : _tipo_periodo = "" : End Try

                labelEstatus.Text = "Importando personal [" & _reloj & "][" & contador_empleados & " de " & empleados_a_importar & "]"

                '--Hacer el primer insert
                sqlExecute("insert into variables_nom_pro (ano, bimestre, reloj) values ('" & _ano & "', '" & _bimestre & "', '" & _reloj & "')", "nomina")

                '----Hacer el update de todos los campos
                sqlExecute("update variables_nom_pro set tipo_periodo = '" & _tipo_periodo & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and bimestre = '" & _bimestre & "'", "nomina")
                sqlExecute("update variables_nom_pro set cod_comp = '" & IIf(IsDBNull(row_activos("cod_comp")), "", row_activos("cod_comp")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and bimestre = '" & _bimestre & "'", "nomina")
                sqlExecute("update variables_nom_pro set cod_tipo = '" & IIf(IsDBNull(row_activos("cod_tipo")), "", row_activos("cod_tipo")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and bimestre = '" & _bimestre & "'", "nomina")
                sqlExecute("update variables_nom_pro set cod_depto = '" & IIf(IsDBNull(row_activos("cod_depto")), "", row_activos("cod_depto")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and bimestre = '" & _bimestre & "'", "nomina")
                sqlExecute("update variables_nom_pro set cod_puesto = '" & IIf(IsDBNull(row_activos("cod_puesto")), "", row_activos("cod_puesto")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and bimestre = '" & _bimestre & "'", "nomina")
                sqlExecute("update variables_nom_pro set alta = '" & FechaSQL(row_activos("alta")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and bimestre = '" & _bimestre & "'", "nomina")

                If Not IsDBNull(row_activos("baja")) Then
                    EsBaja = True
                    sqlExecute("update variables_nom_pro set baja = '" & FechaSQL(row_activos("baja")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and bimestre = '" & _bimestre & "'", "nomina")
                End If
                sqlExecute("update variables_nom_pro set sactual = '" & IIf(IsDBNull(row_activos("sactual")), "0", row_activos("sactual")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and bimestre = '" & _bimestre & "'", "nomina")
                sqlExecute("update variables_nom_pro set factor_int = '" & IIf(IsDBNull(row_activos("FACTOR_INT")), "0", row_activos("FACTOR_INT")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and bimestre = '" & _bimestre & "'", "nomina")
                sqlExecute("update variables_nom_pro set pro_var = '" & IIf(IsDBNull(row_activos("pro_var")), "0", row_activos("pro_var")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and bimestre = '" & _bimestre & "'", "nomina")
                sqlExecute("update variables_nom_pro set integrado = '" & IIf(IsDBNull(row_activos("integrado")), "0", row_activos("integrado")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and bimestre = '" & _bimestre & "'", "nomina")
                sqlExecute("update variables_nom_pro set nombres = '" & IIf(IsDBNull(row_activos("nombres")), "0", row_activos("nombres")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and bimestre = '" & _bimestre & "'", "nomina")

                Application.DoEvents()
                contador_empleados += 1
            Next


        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al obtener datos de los empleados", "Error al inicializar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

End Class