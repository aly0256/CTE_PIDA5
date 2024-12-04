Public Class frmInicCalcIsrAnual

    Private Sub frmInicCalcIsrAnual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtAno As New DataTable
        Dim anio_actual As String = ""
        Try
            anio_actual = Now.Year.ToString.Trim
            dtAno = sqlExecute("select distinct ano from periodos as ano ", "TA")

            cmbAno.DataSource = dtAno
            cmbAno.SelectedValue = anio_actual

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnIniciProcVar_Click(sender As Object, e As EventArgs) Handles btnInicCalcIsrAn.Click
        cmbAno.Enabled = False
        btnInicCalcIsrAn.Enabled = False

        Try
            '---Validar si  el año a calcular ya se calculó (asentado)
            Dim _ano As String = cmbAno.SelectedValue
            Dim dtAno As DataTable = sqlExecute("select * from isranual_nom where ano='" & _ano & "'", "NOMINA")

            If (Not dtAno.Columns.Contains("Error") And dtAno.Rows.Count > 0) Then
                MessageBox.Show("El ejercicio del año seleccionado ya está cálculado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbAno.Enabled = True
                btnInicCalcIsrAn.Enabled = True
                Exit Sub
            Else
                'limpiar tablas
                labelEstatus.Text = "Limpiando proceso anterior [1/2]"
                sqlExecute("truncate table isranual_nom_pro", "NOMINA")
                Application.DoEvents()

                labelEstatus.Text = "Limpiando proceso anterior [2/2]"
                sqlExecute("truncate table isranual_status_proc", "NOMINA")
                Application.DoEvents()

                '---Obtener empleados que van a entrar al proceso
                GetDataFromPersCalcIsrAnual(_ano)

                MessageBox.Show("Proceso inicializado correctamente", "Proceso inicializado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                labelEstatus.Text = ""

                '---Actualizar status_proceso indicando que ya está listo el paso 2 que es Inicializar Nómina
                Dim dtStProc As DataTable = sqlExecute("select distinct ano from isranual_nom_pro order by ano asc", "NOMINA")
                If (Not dtStProc.Columns.Contains("Error") And dtStProc.Rows.Count > 0) Then
                    Dim _anioSt As String = ""
                    Try : _anioSt = dtStProc.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : _anioSt = "" : End Try
                    sqlExecute("insert into isranual_status_proc (ano,avance,usuario,datetime) values ('" & _anioSt & "','2','" & Usuario & "',Getdate())", "NOMINA")
                End If

            End If

            cmbAno.Enabled = True
            btnInicCalcIsrAn.Enabled = True

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al inicializar, último paso: " & labelEstatus.Text, "Error al inicializar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            labelEstatus.Text = ""
            cmbAno.Enabled = True
            btnInicCalcIsrAn.Enabled = True
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Error al inic. cálculo isr anual", Err.Number, ex.Message)
        End Try
    End Sub

    Private Sub GetDataFromPersCalcIsrAnual(_ano As String)
        Try
            '   Dim QP As String = "select * from personalvw where isnull(SACTUAL,0)<>0 and isnull(baja,'')='' and isnull(reloj,'')<>'' order by reloj asc" ' Aplica a todos lo activos automaticamente
            Dim FechaPrimEne As New Date(Now.Year, 1, 1)
            Dim QP As String = "select  * from  personalvw where (baja>='" & FechaSQL(FechaPrimEne) & "' or isnull(baja,'')='') and reloj in(select distinct reloj from nomina.dbo.nomina n where ano='" & cmbAno.SelectedValue & "') order by reloj asc" ' Aplica para todos los empleados que tuvieron algun ingreso en el año a calcular
            Dim dtEmpleados As DataTable = sqlExecute(QP, "PERSONAL")

            Dim empleados_a_importar As Integer = dtEmpleados.Rows.Count
            Dim contador_empleados As Integer = 1

            For Each row_activos As DataRow In dtEmpleados.Rows
                Dim _reloj As String = row_activos("reloj").ToString.Trim

                Dim cod_comp As String = "", tipo_periodo As String = "", cod_tipo As String = "", cod_depto As String = "", cod_puesto As String = "", nombres As String = "", alta As String = "", baja As String = ""

                Try : cod_comp = row_activos("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try
                Try : tipo_periodo = row_activos("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_periodo = "" : End Try
                Try : cod_tipo = row_activos("cod_tipo").ToString.Trim : Catch ex As Exception : cod_tipo = "" : End Try
                Try : cod_depto = row_activos("cod_depto").ToString.Trim : Catch ex As Exception : cod_depto = "" : End Try
                Try : cod_puesto = row_activos("cod_puesto").ToString.Trim : Catch ex As Exception : cod_puesto = "" : End Try
                Try : nombres = row_activos("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
                Try : alta = FechaSQL(row_activos("alta")) : Catch ex As Exception : alta = "" : End Try
                Try : baja = FechaSQL(row_activos("baja")) : Catch ex As Exception : baja = "" : End Try

                labelEstatus.Text = "Importando personal [" & _reloj & "][" & contador_empleados & " de " & empleados_a_importar & "]"

                '--Hacer el primer insert
                sqlExecute("insert into isranual_nom_pro (ano,reloj) values ('" & _ano & "','" & _reloj & "')", "NOMINA")

                '---Hacer el update de todos los campos
                sqlExecute("update isranual_nom_pro set cod_comp='" & cod_comp & "' where reloj='" & _reloj & "' and ano='" & _ano & "'", "NOMINA")
                sqlExecute("update isranual_nom_pro set tipo_periodo='" & tipo_periodo & "' where reloj='" & _reloj & "' and ano='" & _ano & "'", "NOMINA")
                sqlExecute("update isranual_nom_pro set cod_tipo='" & cod_tipo & "' where reloj='" & _reloj & "' and ano='" & _ano & "'", "NOMINA")
                sqlExecute("update isranual_nom_pro set cod_depto='" & cod_depto & "' where reloj='" & _reloj & "' and ano='" & _ano & "'", "NOMINA")
                sqlExecute("update isranual_nom_pro set cod_puesto='" & cod_puesto & "' where reloj='" & _reloj & "' and ano='" & _ano & "'", "NOMINA")
                sqlExecute("update isranual_nom_pro set nombres='" & nombres & "' where reloj='" & _reloj & "' and ano='" & _ano & "'", "NOMINA")
                If (alta <> "") Then sqlExecute("update isranual_nom_pro set alta='" & alta & "' where reloj='" & _reloj & "' and ano='" & _ano & "'", "NOMINA")
                If (baja <> "") Then sqlExecute("update isranual_nom_pro set baja='" & baja & "' where reloj='" & _reloj & "' and ano='" & _ano & "'", "NOMINA")

                Application.DoEvents()
                contador_empleados += 1
            Next

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al obtener datos de los empleados", "Error al inicializar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Error al obtener datos del personal", Err.Number, ex.Message)
        End Try
    End Sub
End Class