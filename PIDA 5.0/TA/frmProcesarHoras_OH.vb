Imports System.IO

Public Class frmProcesarHoras_OH

    Private Sub frmProcesarHoras_OH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Dim dtCia As New DataTable
        Dim dtAno As New DataTable
        Dim dtAnoActual As New DataTable
        Dim anioActual As String = ""

        Dim _dtAnioActualPc As New DataTable
        Dim anio_Compu As String = ""

        Try

            _dtAnioActualPc = sqlExecute("Select year(getdate()) AS Anio_actual")
            anio_Compu = _dtAnioActualPc.Rows(0).Item("Anio_actual")

            dtAno = sqlExecute("select distinct ano from (SELECT ano from periodos union all select ano from periodos_quincenal union all select ano from periodos_mensual) as ano ", "TA")
            dtAnoActual = sqlExecute("SELECT TOP 1 ano FROM (SELECT ano from periodos union all select ano from periodos_quincenal union all select ano from periodos_mensual) as ano ORDER BY ano DESC", "TA")
            anioActual = dtAnoActual.Rows(0).Item("ano")
            cmbAno.DataSource = dtAno
            '---Comparar años para mostrar el anio actual
            If (anioActual > anio_Compu) Then
                cmbAno.SelectedValue = anio_Compu
            Else
                cmbAno.SelectedValue = anioActual
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Dim dtPeriodos As New DataTable
    Dim perActivo As String = ""
    Private Sub cmbAno_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cmbAno.SelectionChanged


        Try
            '   dtPeriodos = sqlExecute("SELECT TOP 1 periodo, fecha_ini, fecha_fin FROM " & tipo_periodo & " WHERE ano = '" & cmbAno.SelectedValue & "' AND activo = 1 ORDER BY periodo DESC", "TA")
            'En este caso siempre el periodo será semanal para los empleados tipo OutHelping
            dtPeriodos = sqlExecute("SELECT TOP 1 periodo, fecha_ini, fecha_fin FROM periodos WHERE ano = '" & cmbAno.SelectedValue & "' AND activo = 1 ORDER BY periodo DESC", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                perActivo = dtPeriodos.Rows(0).Item("periodo")
            End If

            ' dtPeriodos = sqlExecute("SELECT periodo,fecha_ini,fecha_fin FROM " & tipo_periodo & " WHERE ano = '" & cmbAno.SelectedValue & "' ORDER BY periodo", "TA")
            dtPeriodos = sqlExecute("SELECT periodo,fecha_ini,fecha_fin FROM periodos WHERE ano = '" & cmbAno.SelectedValue & "' ORDER BY periodo", "TA")
            cmbPeriodo.DataSource = dtPeriodos
            If perActivo.Length > 0 Then
                cmbPeriodo.SelectedValue = perActivo
            Else
                cmbPeriodo.SelectedIndex = 0
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub
    Dim tipo_periodo As String = "periodos"

    Private Sub cmbAno_TextChanged(sender As Object, e As EventArgs) Handles cmbAno.TextChanged

    End Sub


    Private Sub exportacion_quincenal(ByRef dtDatos As DataTable, oWrite As System.IO.StreamWriter)

        Dim dtPeriodoQuincenal As DataTable = sqlExecute("select * from periodos_quincenal where ano+periodo = '" & cmbAno.SelectedValue & cmbPeriodo.SelectedValue & "'", "TA")
        Dim f_ini_q As Date = dtPeriodoQuincenal.Rows(0)("fecha_ini")
        Dim f_fin_q As Date = dtPeriodoQuincenal.Rows(0)("fecha_fin")

        Try
            'Tomar los datos de nomsem, filtrando solo operativos, del periodo, año y compañía seleccionadas

            oWrite.WriteLine("Reloj, Concepto, Valor, Fecha, Factor")
            Dim dtPersonalQuincenal As DataTable = sqlExecute("select * from personal where alta < '" & FechaSQL(f_fin_q) & "' and (baja is null or baja >= '" & FechaSQL(f_ini_q) & "') and tipo_periodo = 'Q'")
            For Each row_personalQuicenal As DataRow In dtPersonalQuincenal.Rows

                Dim hrs_nor As Double = 0
                Dim hrs_extras As Double = 0
                Dim hrs_nopag As Double = 0
                Dim hrs_tarde As Double = 0

                Dim hrs_dobles As Double = 0
                Dim hrs_triples As Double = 0

                Dim primas_dom As Integer = 0
                Dim primas_sab As Integer = 0

                Dim diastr As Integer = 0

                Dim fecha As Date = f_ini_q.AddDays(-1)

                Application.DoEvents()

                '-----Validar Cambio de sueldo con incapacidad
                Dim dtmodsue As New DataTable
                dtmodsue = sqlExecute("select * from personal where reloj = '" & row_personalQuicenal("reloj") & "'")
                If dtmodsue.Rows.Count > 0 Then
                    Dim fha_ult_mod As String = IIf(IsDBNull(dtmodsue.Rows(0).Item("FHA_ULT_MO")), "", dtmodsue.Rows(0).Item("FHA_ULT_MO").ToString)
                    If fha_ult_mod <> "" Then
                        Dim dttemp As DataTable = sqlExecute("select " & _
                                                    "ausentismo.reloj, ausentismo.tipo_aus, ausentismo.fecha, tipo_ausentismo.TIPO_NATURALEZA, " & _
                                                    "periodos_quincenal.ano, periodos_quincenal.periodo from ausentismo left join periodos_quincenal on ausentismo.fecha between " & _
                                                    "fecha_ini and fecha_fin left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus " & _
                                                    "where TIPO_NATURALEZA = 'I' and isnull(PERIODO_ESPECIAL, 0) = 0 and '" & FechaSQL(fha_ult_mod) & "' between fecha_ini and fecha_fin and reloj = '" & row_personalQuicenal("reloj") & "'", "TA")
                        If dttemp.Rows.Count > 0 Then
                            MessageBox.Show("El empleado " & row_personalQuicenal("reloj") & " cuenta con incapacidad en la quincena que se aplicó cambio de sueldo. Favor de verificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                    Dim fha_baja As String = IIf(IsDBNull(dtmodsue.Rows(0).Item("baja")), "", dtmodsue.Rows(0).Item("baja").ToString)
                    If fha_baja <> "" Then
                        Dim dttemp As DataTable = sqlExecute("select " & _
                                                "ausentismo.reloj, ausentismo.tipo_aus, ausentismo.fecha, tipo_ausentismo.TIPO_NATURALEZA, " & _
                                                "periodos.ano, periodos.periodo from ausentismo left join periodos on ausentismo.fecha between " & _
                                                "fecha_ini and fecha_fin left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus left join PERSONAL.dbo.personal on ausentismo.RELOJ = personal.reloj  " & _
                                                "where TIPO_NATURALEZA = 'I' and isnull(PERIODO_ESPECIAL, 0) = 0 and '" & FechaSQL(fha_baja) & "' between fecha_ini and fecha_fin and ausentismo.reloj = '" & row_personalQuicenal("reloj") & "' and periodos.ano+periodos.periodo = '" & cmbAno.SelectedValue & cmbPeriodo.SelectedValue & "' and baja is not null", "TA")
                        If dttemp.Rows.Count > 0 Then
                            MessageBox.Show("El empleado " & row_personalQuicenal("reloj") & " se encuentra dado de baja y cuenta con una incapacidad en la semana. Favor de verificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If




                Dim dtAsistQuincenal As DataTable = sqlExecute("select * from asist where reloj = '" & row_personalQuicenal("reloj") & "' and fha_ent_hor between '" & FechaSQL(f_ini_q) & "' and '" & FechaSQL(f_fin_q) & "'", "ta")
                For Each drAsist In dtAsistQuincenal.Rows

                    Dim EsDomingo As Boolean = False
                    Dim EsSabado As Boolean = False

                    If Date.Parse(drAsist("fha_ent_hor")).Date <> fecha.Date Then
                        diastr += 1
                    End If

                    fecha = drAsist("fha_ent_hor")

                    'Definir si esta fecha corresponde a un día festivo, domingo o descanso                
                    EsDomingo = DiaSem(fecha).ToLower = "domingo"
                    EsSabado = DiaSem(fecha).ToLower = "sábado"
                    'EsDescanso = DiaDescanso(Fecha, R)
                    'EsFestivo = Festivo(Fecha, R)

                    'Sumar horas

                    hrs_nor = hrs_nor + HtoD(drAsist("horas_normales"))
                    hrs_tarde = hrs_tarde + HtoD(drAsist("horas_tarde"))


                    If HtoD(drAsist("horas_anticipadas")) < 0 Then
                        hrs_nopag += HtoD(drAsist("horas_anticipadas")) * -1
                    End If

                    If HtoD(drAsist("horas_tarde")) > 0 Then
                        hrs_nopag += HtoD(drAsist("horas_tarde"))
                    End If

                    hrs_extras = hrs_extras + HtoD(drAsist("extras_autorizadas"))

                    'Contabilizar horas extras



                    'Si es domingo
                    Try
                        If EsDomingo Then

                            Dim hrs_prim_dom As Double = drAsist("extras_autorizadas") + drAsist("horas_normales")

                            If hrs_prim_dom > 0 Then
                                primas_dom += 1
                            Else
                                Dim dtComentario As DataTable = sqlExecute("select * from asist where reloj = '" & row_personalQuicenal("reloj") & "' and fha_ent_hor = '" & FechaSQL(drAsist("fha_ent_hor")) & "'", "TA")
                                For Each r_comentario As DataRow In dtComentario.Rows
                                    Dim comentario As String = r_comentario("comentario")
                                    If comentario.ToUpper.Contains("FALTA") Then
                                        If (comentario.ToUpper.Contains("SALIDA") Or comentario.ToUpper.Contains("ENTRADA")) Then
                                            primas_dom += 1
                                        End If
                                    End If
                                Next

                            End If
                        End If


                    Catch ex As Exception

                    End Try


                    Try
                        If EsSabado Then

                            Dim hrs_prim_sab As Double = drAsist("extras_autorizadas") + drAsist("horas_normales")

                            If hrs_prim_sab > 0 Then
                                primas_sab += 1
                            Else
                                Dim dtComentario As DataTable = sqlExecute("select * from asist where reloj = '" & row_personalQuicenal("reloj") & "' and fha_ent_hor = '" & FechaSQL(drAsist("fha_ent_hor")) & "'", "TA")
                                For Each r_comentario As DataRow In dtComentario.Rows
                                    Dim comentario As String = r_comentario("comentario")
                                    If comentario.ToUpper.Contains("FALTA") Then
                                        If (comentario.ToUpper.Contains("SALIDA") Or comentario.ToUpper.Contains("ENTRADA")) Then
                                            primas_sab += 1

                                        End If
                                    End If
                                Next

                            End If
                        End If


                    Catch ex As Exception

                    End Try


                Next

                If hrs_extras >= 9 Then
                    hrs_dobles = 9
                    hrs_triples = hrs_extras - 9
                Else
                    hrs_dobles = hrs_extras
                    hrs_triples = 0
                End If

                Dim dDato As DataRow = dtDatos.NewRow
                dDato("reloj") = row_personalQuicenal("reloj")
                dDato("cod_tipo") = ""
                dDato("cod_depto") = ""
                dDato("nombre_depto") = ""
                dDato("cod_super") = ""
                dDato("super") = ""
                dDato("HRSNOR") = hrs_nor
                dDato("HRSFES") = 0
                dDato("HORDOB") = hrs_dobles
                dDato("HORTRI") = hrs_triples
                dDato("HORDOM") = 0
                dDato("DIVACA") = 0 '
                dDato("DIAGUI") = 0 ' IIf(IsDBNull(dRow("dias_aguinaldo")), 0, dRow("dias_aguinaldo"))
                dDato("BONO01") = 0
                dDato("BONO02") = 0
                dDato("BONO03") = 0
                dDato("BONO04") = 0
                dDato("BONO05") = 0
                dDato("bono06") = 0
                dDato("bono07") = 0
                dDato("bono08") = 0
                dDato("bono09") = 0
                dDato("bono10") = 0

                dDato("PRIMA_DOM") = primas_dom
                dDato("PRIMA_SAB") = primas_sab

                dDato("HORDIN") = 0
                dDato("HORTIN") = 0
                dDato("DIASTR") = diastr

                dDato("DIASCM") = 0

                dDato("HRS_NOPAG") = hrs_nopag
                dDato("HRS_RETARDO") = hrs_tarde

                dtDatos.Rows.Add(dDato)


                If dDato("HRSNOR") > 0 Then
                    'oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSNOR," & String.Format("{0:0.00}", dDato("HRSNOR")))
                End If
                If dDato("HORDOB") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSEX2," & String.Format("{0:0.00}", dDato("HORDOB")))
                End If
                If dDato("HORTRI") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSEX3," & String.Format("{0:0.00}", dDato("HORTRI")))
                End If
                If dDato("HRS_RETARDO") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSRET," & String.Format("{0:0.00}", dDato("HRS_RETARDO")))
                End If
                If dDato("HRS_NOPAG") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSPSG," & String.Format("{0:0.00}", dDato("HRS_NOPAG")))
                End If

                If dDato("PRIMA_DOM") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIADOM," & String.Format("{0:0.00}", dDato("PRIMA_DOM")))
                End If

                If dDato("PRIMA_SAB") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIASAB," & String.Format("{0:0.00}", dDato("PRIMA_SAB")))
                End If

                If dDato("DIASTR") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIASTR," & String.Format("{0:0.00}", dDato("DIASTR")))
                End If

                Dim q_ausentismo As String = "select ausentismo.reloj, ausentismo.fecha, ausentismo.tipo_aus, tipo_ausentismo.NOMBRE, percepcion, cancelacion, deduccion, devolucion " & _
                    "from ausentismo left join periodos_quincenal on ausentismo.fecha between periodos_quincenal.fecha_ini and periodos_quincenal.fecha_fin " & _
                    "left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus " & _
                    "where periodos_quincenal.ano = '" & cmbAno.SelectedValue & "' and periodos_quincenal.periodo = '" & cmbPeriodo.SelectedValue & "' and reloj = '" & dDato("reloj").ToString.Trim.PadLeft(6) & "'"

                Dim dtAus As DataTable = sqlExecute(q_ausentismo, "TA")




                If dtAus.Rows.Count > 0 Then
                    For Each row As DataRow In dtAus.Select("tipo_aus in ('FI', 'C50')")
                        Dim percepcion_aus As Boolean = Not IsDBNull(row("percepcion"))
                        Dim deduccion_aus As Boolean = Not IsDBNull(row("deduccion"))
                        If percepcion_aus Then
                            oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & "," & row("percepcion") & "," & 1 & "," & FechaSQL(row("fecha")))
                            dDato(row("percepcion")) = 1
                        ElseIf deduccion_aus Then
                            oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & "," & row("deduccion") & "," & 1 & "," & FechaSQL(row("fecha")))
                            dDato(row("deduccion")) = 1
                        Else
                            oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",ERROR," & 1 & "," & FechaSQL(row("fecha")))
                        End If

                    Next
                End If

                Dim dtComedor As DataTable = sqlExecute("select reloj, sum(case when subsidio = 'C' then 1 else 0 end) as CON_SUBSIDIO, " & _
                "sum(case when subsidio = 'S' then 1 else 0 end) as SIN_SUBSIDIO from hrs_brt_cafeteria " & _
                "left join periodos_quincenal on hrs_brt_cafeteria.fecha between periodos_quincenal.fecha_ini and periodos_quincenal.FECHA_FIN " & _
                "where periodos_quincenal.ano + periodos_quincenal.periodo = '" & cmbAno.SelectedValue & cmbPeriodo.SelectedValue & "' and hrs_brt_cafeteria.reloj = '" & dDato("reloj").ToString.Trim.PadLeft(6) & "'" & _
                "group by  reloj", "TA")
                If dtComedor.Rows.Count > 0 Then
                    If dtComedor.Rows(0)("CON_SUBSIDIO") > 0 Then
                        oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIACON," & dtComedor.Rows(0)("CON_SUBSIDIO"))
                        dDato("DIACON") = dtComedor.Rows(0)("CON_SUBSIDIO")
                    End If
                    If dtComedor.Rows(0)("SIN_SUBSIDIO") > 0 Then
                        oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIASIN," & dtComedor.Rows(0)("SIN_SUBSIDIO"))
                        dDato("DIASIN") = dtComedor.Rows(0)("SIN_SUBSIDIO")
                    End If
                End If


            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnTransferencia_Click(sender As Object, e As EventArgs) Handles btnTransferencia.Click
        Dim dtDatos As New DataTable
        Dim dtInfoEmplSem As New DataTable 'DataTable que carga info de todos los empleados para esa semana de NOMSEM

        Dim dRow As DataRow
        Dim Ano As String
        Dim Per As String
        Dim strFileName As String = ""
        Dim oWrite As System.IO.StreamWriter
        Dim GuardaArchivo As Boolean = True
        Dim hrFormateada As String = ""
        Dim _FormatTime As String = "" 'Segun el valor del formato del campo ya sea horas o minutos
        Dim NumEmplOH As String = "" ' -Num de reloj OH
        Dim NumEmplPida As String = ""
        Dim FullName As String = ""
        Dim _x As Integer = 0
        Dim suma As Boolean = False
        Dim sumAus As Boolean = False
        Dim TotPSab As Boolean = False
        Dim sactual As Double = 0 ' - Sueldo actual
        Dim nombre_clase As String = "" ' Sabes si es D, I,G o A


        Try
            Me.Cursor = Cursors.WaitCursor
            Ano = cmbAno.SelectedValue
            Per = cmbPeriodo.SelectedValue

            Dim c As Integer = 0
            Dim dDato As DataRow

            'Inicializar archivo CSV y ubicacion de guardado
            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog
            PreguntaArchivo.Filter = "Archivo CSV|*.csv"
            PreguntaArchivo.FileName = "002_hrs_OH " & Ano & "-" & Per & ".csv"
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            Else
                Exit Sub
            End If
            Try
                oWrite = File.CreateText(strFileName)
                GuardaArchivo = True
            Catch ex As Exception
                oWrite = Nothing
                GuardaArchivo = False
                MessageBox.Show("El archivo no pudo ser creado." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ' Preparar cuadro de vance
            frmTrabajando.Show(Me)
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            frmTrabajando.lblAvance.Text = "Preparando datos..."
            Application.DoEvents()

            'Agregar al DT principal todas las columnas que vamos a ir validando, los nombres deben de ser igual a los de las tablas que vamos a sacar esa info para no confundirse
            dtDatos.Columns.Add("grupo") ' Para mandar grupos totales en reporte
            dtDatos.Columns.Add("reloj") ' Numero de reloj anterior con el que vamos a comparar
            dtDatos.Columns.Add("reloj_alt")
            dtDatos.Columns.Add("nombres", GetType(System.String))
            dtDatos.Columns.Add("CENTRO_COSTOS")
            dtDatos.Columns.Add("ANO")
            dtDatos.Columns.Add("PERIODO")
            dtDatos.Columns.Add("HRS_DOBLES", GetType(System.Double))
            dtDatos.Columns.Add("HRS_TRIPLES", GetType(System.Double))
            dtDatos.Columns.Add("HRS_NOPAG", GetType(System.Double))
            dtDatos.Columns.Add("HRS_RETARDO", GetType(System.Double))
            dtDatos.Columns.Add("HRS_FEL", GetType(System.Double))
            dtDatos.Columns.Add("DIADOM", GetType(System.Double))
            dtDatos.Columns.Add("DIASAB", GetType(System.Double))
            dtDatos.Columns.Add("DIASAB_UNI", GetType(System.Double))
            dtDatos.Columns.Add("C50", GetType(System.Double))
            dtDatos.Columns.Add("PGO", GetType(System.Double))
            dtDatos.Columns.Add("FI", GetType(System.Double))
            dtDatos.Columns.Add("JUS", GetType(System.Double))
            dtDatos.Columns.Add("PSG", GetType(System.Double))
            dtDatos.Columns.Add("SUS", GetType(System.Double))
            dtDatos.Columns.Add("SHU", GetType(System.Double))
            dtDatos.Columns.Add("PAR", GetType(System.Double))
            dtDatos.Columns.Add("SAL", GetType(System.Double))
            dtDatos.Columns.Add("VAC", GetType(System.Double))
            dtDatos.Columns.Add("INA", GetType(System.Double))
            dtDatos.Columns.Add("EG", GetType(System.Double))
            dtDatos.Columns.Add("MAT", GetType(System.Double))
            dtDatos.Columns.Add("RT", GetType(System.Double))
            dtDatos.Columns.Add("DIASIN", GetType(System.Double))
            dtDatos.Columns.Add("DIACON", GetType(System.Double))
            dtDatos.Columns.Add("DIADES", GetType(System.Double))
            dtDatos.Columns.Add("sactual", GetType(System.Double))




            '*Obtener filtro del periodo que estamos analizando para obtener fec ini y fec fin
            Dim dtPeriodoSemanal As DataTable = sqlExecute("select * from periodos where ano+periodo = '" & cmbAno.SelectedValue & cmbPeriodo.SelectedValue & "'", "TA")
            Dim f_ini_s As Date = dtPeriodoSemanal.Rows(0)("fecha_ini") 'Obtener el primer lunes del periodo mandado
            Dim f_fin_s As Date = dtPeriodoSemanal.Rows(0)("fecha_fin")

            'Obtener filtro de todos los empleados de ese año y periodo de NOMSEM (Que es donde se guarda toda la info para procesar la nomina) solo para empleados outHelping (cod_comp='002')
            'Se toma NOMSEM porque guarda un registro por empleado, no como asist que guarda el mismo registro por varios dias por cada checada
            Dim QInfoEmpl As String = "SELECT ns.*,psw.cod_comp,psw.nombres,psw.reloj_alt,psw.sactual,psw.CENTRO_COSTOS,psw.nombre_clase  " & _
                                       "from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw " & _
                                     "on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and ns.ANO=" & Ano & " and ns.PERIODO=" & Per & _
                                     " and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''"

            dtInfoEmplSem = sqlExecute(QInfoEmpl)

            If dtInfoEmplSem.Rows.Count = 0 Then
                MessageBox.Show("No se localizaron registros correspondientes a los parámetros indicados. Favor de verificar.", "Procesar horas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            frmTrabajando.Avance.Maximum = dtInfoEmplSem.Rows.Count ' Total de registros para ir avanzando

            ' Definir columnas del Excel
            oWrite.WriteLine("Reloj, Nombre, Cve_Mov, Concepto_Mov, Importe_Mov, Horas_TE, Tipo_TE, Dias_Aus, Horas-Min_Aus, Cve_Aus, Descrip_Aus, Fecha_Aplica, Fecha_Real, Clase")

            'Recorrer cada registro encontrado en dtInfoEmplSem para ir agregándolo al archivo
            For Each dRow In dtInfoEmplSem.Rows
                If Not ActivoTrabajando Then   'Bandera para indicar si está abierta la pantalla de frmTrabajando, es decir si no esta abierta, cerrar archivo y salirse de este Método
                    oWrite.Close()
                    Exit Sub
                End If

                'Ir mostrando el avance en el # Reloj para cada registro
                frmTrabajando.lblAvance.Text = dRow("reloj")
                frmTrabajando.Avance.Value += 1
                Application.DoEvents()

                'Los nombres de los campos deben de ser iguales a los que arrojó el query, en este caso de la tabla NOMSEM y PERSONALVW
                dDato = dtDatos.NewRow
                Dim cantDig As Integer = 0
                NumEmplOH = dRow("reloj_alt").ToString.Trim
                cantDig = Len(NumEmplOH)
                NumEmplOH = NumEmplOH.Substring(0, cantDig - 1) 'Tomamos el nuevo num de empleado sin el último digito que es un 1 que es el que se va a mandar
                NumEmplPida = dRow("RELOJ").ToString.Trim ' Num Empleado PIDA
                nombre_clase = IIf(IsDBNull(dRow("nombre_clase")), "", dRow("nombre_clase"))
                '-Obtener sueldo actual
                sactual = IIf(IsDBNull(dRow("sactual")), 0, dRow("sactual"))
                dDato("reloj") = NumEmplOH ' --> 30/10/2018 - Solicitan que el nuevo # Reloj sea el ID de OH
                dDato("nombres") = dRow("nombres")
                dDato("CENTRO_COSTOS") = IIf(IsDBNull(dRow("CENTRO_COSTOS")), "", dRow("CENTRO_COSTOS"))
                dDato("hrs_dobles") = IIf(IsDBNull(dRow("hrs_dobles")), 0, dRow("hrs_dobles"))
                dDato("hrs_triples") = IIf(IsDBNull(dRow("hrs_triples")), 0, dRow("hrs_triples"))
                dDato("hrs_nopag") = IIf(IsDBNull(dRow("hrs_nopag")), 0, dRow("hrs_nopag"))
                dDato("hrs_retardo") = IIf(IsDBNull(dRow("hrs_retardo")), 0, dRow("hrs_retardo"))
                dDato("hrs_fel") = IIf(IsDBNull(dRow("hrs_fel")), 0, dRow("hrs_fel"))

                dtDatos.Rows.Add(dDato)
                FullName = dDato("nombres").ToString
                FullName = FullName.Replace(",", " ") ' Nombre completo sin "," las quitamos para que no nos meta el nombre en otra columna diferente, ya que con la ',' se separa cada campo porque va delimitado

                'Aqui es donde va escribiendo cada renglón con el valor en cada columna en el oWrite.WriteLine , separar con coma "," cada elemento

                '*******************************MOVIMIENTOS 
                'DIADOM - Dias trabajados en Domingo
                Dim dtDomAsist As New DataTable 'Obtener todos los empleados que laboraron en fecha de domingo
                Dim _FecRealDom As Date 'Fecha real que aplica la tomamos de ASIST
                Dim x As Integer ' para contabilizar cada domingo y dar el numero de dias que laboró
                'dtDomAsist = sqlExecute(" SELECT * FROM asist WHERE ano=" & Ano & " AND periodo=" & Per & " and cod_comp='002' and (horas_normales<>'00:00' OR  extras_autorizadas<>'00:00')" & _
                '                        " and datepart(dw,FHA_ENT_HOR)=1", "TA")
                dtDomAsist = sqlExecute("select ns.RELOJ,ns.ANO,ns.PERIODO,ns.PRIMA_DOM,a.COD_COMP,a.ANO,a.PERIODO,a.FHA_ENT_HOR,a.DIA_ENTRO,a.FHA_SAL_HOR,a.DIA_SALIO,a.TIPO_AUS " & _
                                        "from nomsem ns left join asist a on ns.RELOJ=a.RELOJ and ns.ANO=a.ANO and ns.PERIODO=a.PERIODO " & _
                                        "WHERE ns.PRIMA_DOM=1 and ns.ANO =" & Ano & " and ns.PERIODO=" & Per & " and datepart(dw,a.FHA_ENT_HOR)=1 and a.COD_COMP='002'", "TA")
                If (dtDomAsist.Rows.Count > 0) Then
                    x = 0
                    For Each row As DataRow In dtDomAsist.Select("reloj='" & NumEmplPida & "' ")
                        _FecRealDom = dtDomAsist.Rows(x).Item("FHA_ENT_HOR")
                        x += 1
                        oWrite.WriteLine(NumEmplOH & "," & FullName & ",132,PRIMA DOMINICAL," & x & ", , , , , , ," & FechaSQL_2(f_ini_s) & "," & FechaSQL_2(_FecRealDom) & "," & nombre_clase.Trim) 'Insertar registro en Excel                      
                    Next
                    dDato("DIADOM") = x
                End If

                'DIASAB - Dias trabajados en sabado

                Dim dtSabAsist As New DataTable
                Dim _FecRealSab As Date 'Fecha real que aplica la tomamos de ASIST
                Dim PrimSab As Double = 0 '- Va a ser igual al 25 % de su sueldo
                dtSabAsist = sqlExecute("select ns.RELOJ,ns.ANO,ns.PERIODO,ns.PRIMA_SAB,a.COD_COMP,a.ANO,a.PERIODO,a.FHA_ENT_HOR,a.DIA_ENTRO,a.FHA_SAL_HOR,a.DIA_SALIO,a.TIPO_AUS " & _
                                        "from nomsem ns left join asist a on ns.RELOJ=a.RELOJ and ns.ANO=a.ANO and ns.PERIODO=a.PERIODO " & _
                                        "WHERE ns.PRIMA_SAB=1 and ns.ANO =" & Ano & " and ns.PERIODO=" & Per & " and datepart(dw,a.FHA_ENT_HOR)=7 and a.COD_COMP='002'", "TA")
                If (dtSabAsist.Rows.Count > 0) Then
                    x = 0
                    For Each row As DataRow In dtSabAsist.Select("reloj='" & NumEmplPida & "' ")
                        _FecRealSab = dtSabAsist.Rows(x).Item("FHA_ENT_HOR")
                        PrimSab = sactual * 0.25
                        x += 1
                        oWrite.WriteLine(NumEmplOH & "," & FullName & ",168,PRIMA SABATINA," & PrimSab & ", , , , , , ," & FechaSQL_2(f_ini_s) & "," & FechaSQL_2(_FecRealSab) & "," & nombre_clase.Trim) 'Insertar registro en Excel
                    Next
                    dDato("DIASAB") = PrimSab ' En $
                    '--Mandar totales de Unidades de Prima Sabatina
                    If (TotPSab = False) Then
                        dDato("DIASAB_UNI") = Double.Parse(dtSabAsist.Rows.Count)
                        TotPSab = True
                    End If


                End If

                'CONVENIO AL 50% C50
                Dim _FecRealC50 As Date 'Fecha real que aplica la tomamos de ASIST
                Dim QC50 As String = "select * from asist where COD_COMP='002' AND RELOJ='" & NumEmplPida & "' and ANO=" & Ano & " and PERIODO=" & Per & "  AND TIPO_AUS='C50'"
                Dim dtC50 As DataTable = sqlExecute(QC50, "TA")
                Dim MontoC50 As Double = 0 '- Va a ser igual al 50 % de su sueldo Diario

                If (Not dtC50.Columns.Contains("Error") And dtC50.Rows.Count > 0) Then
                    x = 0
                    For Each row As DataRow In dtC50.Select("reloj='" & NumEmplPida & "' ")
                        _FecRealC50 = dtC50.Rows(x).Item("FHA_ENT_HOR")
                        MontoC50 = sactual * 0.5
                        x += 1
                        oWrite.WriteLine(NumEmplOH & "," & FullName & ",641,CONVENIO 50%," & MontoC50 & ", , , , , , ," & FechaSQL_2(f_ini_s) & "," & FechaSQL_2(_FecRealC50) & "," & nombre_clase.Trim) 'Insertar registro en Excel
                    Next
                    dDato("C50") = MontoC50 * x  '-- Multiplicado por el total de días que tuvo C50
                End If


                'HRSFEL - Horas festivas trabajadas
                If (dDato("hrs_fel") > 0) Then
                    Dim dtFecRealHFel As DataTable
                    Dim _fecRealHFel As Date ' La fecha real la tomamos de ASIST donde el comentario = Festivo Trab  y extras_autorizadas sean las mismas horas mandadas
                    Dim TotHrs_Fel As Double = Math.Round(dDato("hrs_fel"), 2)
                    dtFecRealHFel = sqlExecute("select * from asist where COD_COMP='002' AND RELOJ='" & NumEmplPida & "' and ANO=" & Ano & " and PERIODO=" & Per & " and EXTRAS_AUTORIZADAS>'00:00'" & _
                                               " AND TIPO_AUS='FES'  AND COMENTARIO like '%FEST%'", "TA")
                    If (dtFecRealHFel.Rows.Count > 0) Then
                        _fecRealHFel = dtFecRealHFel(0).Item("FHA_ENT_HOR")
                    End If
                    oWrite.WriteLine(NumEmplOH & "," & FullName & ",164,FESTIVO TRABAJADO HORA," & TotHrs_Fel & ", , , , , , ," & FechaSQL_2(f_ini_s) & "," & FechaSQL_2(_fecRealHFel) & "," & nombre_clase.Trim) 'Insertar registro en Excel
                End If

                '---CAFETERIA: DIASIN (S), DIACON(C), DIADES(Z)
                Dim dtInfoHrsCafe As New DataTable 'Datatable que va a contener toda la info de cafetería de hrs_brt_cafeteria
                dtInfoHrsCafe = sqlExecute("select * from hrs_brt_cafeteria where cod_comp='002' and RELOJ='" & NumEmplPida & "' and FECHA>='" & FechaSQL(f_ini_s) & "' AND fecha<='" & FechaSQL(f_fin_s) & "'", "TA")
                If (dtInfoHrsCafe.Rows.Count > 0) Then ' Si arroja informacion el 1er query
                    _x = 0
                    Dim dtTipoDesc As New DataTable
                    'Es para solo seleccionar los distindos codigos que trae en la columna "subsidio"  y en base a esos, evaluar uno por uno al primer DT
                    dtTipoDesc = sqlExecute("Select distinct subsidio from hrs_brt_cafeteria where cod_comp='002' and RELOJ='" & NumEmplPida & "' and FECHA>='" & FechaSQL(f_ini_s) & "' AND fecha<='" & FechaSQL(f_fin_s) & "' and subsidio in ('S','C','Z')", "TA")
                    For Each row As DataRow In dtTipoDesc.Rows 'Para cada row que arrojo solo los valores disntios, aqui por ejemplo serian 3 resultados o menos, evaluar lo que sigue
                        Dim _tipoDesc As String = dtTipoDesc.Rows(_x).Item("subsidio").ToString.Trim() ' Por ejemplo seria "C"
                        Dim _cantDiasDesc As Integer
                        Dim clave_concep As String = ""
                        Dim nombre_concep As String = ""
                        Dim _FechaRealApp As Date = dtInfoHrsCafe.Rows(_x).Item("fecha").ToString.Trim()

                        Select Case _tipoDesc ' En base a lo que este evaluando en ese momento, segun sea el caso mandar en variabes lo siguiente para poder imprimirlo en el archivito de excel tipo CSV
                            Case "C"
                                _cantDiasDesc = dtInfoHrsCafe.Select("subsidio ='C'").Count ' Da el conteo que hay para ese empleado cuando la columna "subsidio" sea = "C" x ejemplo
                                clave_concep = "1500"
                                nombre_concep = "Comedor con subsidio"

                            Case "S"
                                _cantDiasDesc = dtInfoHrsCafe.Select("subsidio ='S'").Count
                                '  clave_concep = "DIASIN"
                                '-30/10/2018- Comenta Yael Anaya que tambien los comedores sin Sub van con la 1500
                                clave_concep = "639" '-14/11/2018 Comenta Gerardo Clemente que la clave es 639
                                nombre_concep = "Comedor sin subsidio"

                            Case "Z"
                                _cantDiasDesc = dtInfoHrsCafe.Select("subsidio ='Z'").Count
                                clave_concep = "640" '20/11/2018 Comenta Gerardo Clemente que la cve es 640
                                nombre_concep = "Desayuno"

                        End Select
                        oWrite.WriteLine(NumEmplOH & "," & FullName & "," & clave_concep & "," & nombre_concep & "," & _cantDiasDesc & ", , , , , , ," & FechaSQL_2(f_ini_s) & "," & FechaSQL_2(_FechaRealApp) & "," & nombre_clase.Trim) 'Insertar registro en Excel
                        _x = _x + 1
                    Next

                End If
                '----------Obtener totales de cafeteria
                If (suma = False) Then
                    Dim dtTotalesDiaCon As New DataTable
                    Dim dtTotDiaSin As New DataTable
                    Dim dtTotDiaDes As New DataTable
                    dtTotalesDiaCon = sqlExecute("select count(H.reloj) as totalConSub from hrs_brt_cafeteria H left join PERSONAL.dbo.personalvw psw on H.RELOJ = psw.RELOJ where H.cod_comp='002' and H.FECHA>='" & FechaSQL(f_ini_s) & "' AND H.fecha<='" & FechaSQL(f_fin_s) & "' AND H.subsidio='C' and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "') and isnull(psw.cod_super, '') <> ''", "TA")
                    dtTotDiaSin = sqlExecute("select count(H.reloj) as totalSinSub from hrs_brt_cafeteria H left join PERSONAL.dbo.personalvw psw on H.RELOJ = psw.RELOJ where H.cod_comp='002' and H.FECHA>='" & FechaSQL(f_ini_s) & "' AND H.fecha<='" & FechaSQL(f_fin_s) & "' AND H.subsidio='S' and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "') and isnull(psw.cod_super, '') <> ''", "TA")
                    dtTotDiaDes = sqlExecute("select count(H.reloj) as totalDes from hrs_brt_cafeteria H left join PERSONAL.dbo.personalvw psw on H.RELOJ = psw.RELOJ where H.cod_comp='002' and H.FECHA>='" & FechaSQL(f_ini_s) & "' AND H.fecha<='" & FechaSQL(f_fin_s) & "' AND H.subsidio='Z' and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "') and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("DIACON") = IIf((dtTotalesDiaCon.Rows.Count > 0), Double.Parse(dtTotalesDiaCon.Rows(0).Item("totalConSub").ToString.Trim()), 0)
                    dDato("DIASIN") = IIf((dtTotDiaSin.Rows.Count > 0), Double.Parse(dtTotDiaSin.Rows(0).Item("totalSinSub").ToString.Trim()), 0)
                    dDato("DIADES") = IIf((dtTotDiaDes.Rows.Count > 0), Double.Parse(dtTotDiaDes.Rows(0).Item("totalDes").ToString.Trim()), 0)
                    suma = True
                End If


                '*******************************END_MOVIMIENTOS

                ' ******************************Tiempo Extra , ir agregando cada registro que tenga tiempo extra
                If (dDato("hrs_dobles") + dDato("hrs_triples")) > 0 Then
                    Dim dtFecReal As New DataTable
                    Dim _FecReal As Date 'Fecha real que aplica la tomamos de ASIST
                    Dim TotTE As Double = 0
                    TotTE = Math.Round((dDato("hrs_dobles") + dDato("hrs_triples")), 2) ' Redondear a 2 el TExtra
                    dtFecReal = sqlExecute("select * from asist where COD_COMP='002' AND RELOJ='" & NumEmplPida & "' and ANO=" & Ano & " and PERIODO=" & Per & " and HORAS_EXTRAS>'00:00'", "TA")
                    If (dtFecReal.Rows.Count > 0) Then
                        _FecReal = dtFecReal.Rows(0).Item("FHA_ENT_HOR")
                    End If
                    'Agregar en orden cada valor para cada columna, las cuales son:
                    ' Reloj, Nombre, Cve_Mov, Concepto_Mov, Importe_Mov, Horas_TE, Tipo_TE, Dias_Aus, Horas-Min_Aus, Cve_Aus, Descrip_Aus, Fecha_Aplica, Fecha_Real
                    '  oWrite.WriteLine(NumEmplOH & "," & FullName & ", , , ," & String.Format("{0:0.00}", TotTE) & ",1, , , , ," & FechaSQL_2(f_ini_s) & "," & FechaSQL_2(_FecReal))
                    oWrite.WriteLine(NumEmplOH & "," & FullName & ", , , ," & String.Format("{0:0.00}", TotTE) & ",1, , , , ," & FechaSQL_2(f_ini_s) & "," & FechaSQL_2(f_fin_s) & "," & nombre_clase.Trim) '22/11/2018 --> La fcha fin desean que sea la fecha fin del periodo

                End If
                '********************************Termina Tiempo Extra

                '********************************AUSENTISMOS
                '----RETARDOS
                If dDato("hrs_retardo") > 0 Then ' La fecha Real la dejo igual que la que fecha que aplica, el 1er lunes ya que no el retard es la suma de todos los tiempos de ASIST, la cual coloca el total en NOMSEM en HRS_RETARDO
                    _FormatTime = "HOR" ' El campo viene en Horas
                    hrFormateada = ConvertHHMM(dDato("hrs_retardo"), _FormatTime).ToString  'CONVERTIR horas a HH:MM, ejemplo de 5.8 a 05:48 
                    ' hrFormateada = String.Format("{0:0.00}", hrFormateada)
                    oWrite.WriteLine(NumEmplOH & "," & FullName & ", , , " & ", , , ,'" & hrFormateada & ",16,FALTA POR HORAS," & FechaSQL_2(f_ini_s) & "," & FechaSQL_2(f_ini_s) & "," & nombre_clase.Trim)
                End If
                '----Permiso sin goce de horas (salida anticipada)
                If dDato("hrs_nopag") Then
                    _FormatTime = "HOR" ' El campo viene en Horas
                    hrFormateada = ConvertHHMM(dDato("hrs_nopag"), _FormatTime).ToString  'CONVERTIR horas a HH:MM, ejemplo de 5.8 a 05:48 
                    '  hrFormateada = String.Format("{0:0.00}", hrFormateada)
                    oWrite.WriteLine(NumEmplOH & "," & FullName & ", , , " & ", , , ,'" & hrFormateada & ",23,PERMISO SIN GOCE HORAS," & FechaSQL_2(f_ini_s) & "," & FechaSQL_2(f_ini_s) & "," & nombre_clase.Trim)
                End If

                '-----Para todas los demas tipos de ausentismos que los tome de la tabla ASIST
                Dim dtAusen As New DataTable
                ' dtAusen = sqlExecute("select * from asist where COD_COMP='002' and ANO=" & Ano & " and periodo=" & Per & " and TIPO_AUS<>'' and RELOJ='" & NumEmplPida & "' AND tipo_aus in ('PGO','FI','JUS','INA','EG','MAT','RT','SAL','PSG','SHU','PAR','SUS')", "TA")
                dtAusen = sqlExecute("select * from asist where COD_COMP='002' and ANO=" & Ano & " and periodo=" & Per & " and TIPO_AUS<>'' and RELOJ='" & NumEmplPida & "' AND tipo_aus in ('PGO','FI','JUS','SAL','PSG','SHU','PAR','SUS','VAC')", "TA")
                If dtAusen.Rows.Count > 0 Then
                    _x = 0 ' Para posicionarmos en el Row que este en ese momento analizando, ya que un empleado puede tener mas de 1, lo dejamos en 0 para cada registro nuevo se inicialice en su primer posición
                    'Vamos a recorrer cada registro en ASIST para cada empleado, un empleado puede tener varios registros en esa semana, entonces cada registro lo va a meter 1 x 1
                    For Each row As DataRow In dtAusen.Rows ' Solo estos tipos de Incidencia van a aplicar
                        Dim TipoAus As String = dtAusen.Rows(_x).Item("tipo_aus").ToString.Trim()
                        Dim CveAus As String = ""
                        Dim DescAus As String = ""
                        Dim _fecReal As Date
                        Dim tipo As Integer = 0 'Para saber si devolver la clave de aus o la descripcion
                        ' Convertir el tipo de ausentismo segun tabla mandada x cliente, ejemplo, si es FI, sería un 1 
                        tipo = 1
                        CveAus = ConvertAus(dtAusen.Rows(_x).Item("tipo_aus").ToString.Trim(), tipo)
                        tipo = 2
                        DescAus = ConvertAus(dtAusen.Rows(_x).Item("tipo_aus").ToString.Trim(), tipo)
                        _fecReal = dtAusen.Rows(_x).Item("FHA_ENT_HOR") ' Fecha Real que aplica esa incidencia

                        ' oWrite.WriteLine(NumEmplOH & "," & FullName & ", , , " & ", , ,1, ," & CveAus & "," & DescAus & "," & FechaSQL_2(f_ini_s) & "," & FechaSQL_2(_fecReal)) 'Insertar registro en Excel
                        oWrite.WriteLine(NumEmplOH & "," & FullName & ", , , " & ", , ,1, ," & CveAus & "," & DescAus & "," & FechaSQL_2(_fecReal) & "," & FechaSQL_2(_fecReal) & "," & nombre_clase.Trim) '22/Nov/2018 solicitan que en ausentismos sea siempre la fecha Real
                        _x = _x + 1
                    Next
                End If

                '-----Para todas las Incapacidades que las tome de la tabla AUSENTISMO
                Dim dtIncap As New DataTable
                Dim QI As String = "select * from ausentismo where COD_COMP='002' and fecha between '" & FechaSQL(f_ini_s) & "' and '" & FechaSQL(f_fin_s) & "' and PERIODO='" & Per & "' and TIPO_AUS<>'' and RELOJ='" & NumEmplPida & "' AND tipo_aus in ('INA','EG','MAT','RT')"
                dtIncap = sqlExecute(QI, "TA")
                If (Not dtIncap.Columns.Contains("Error") And dtIncap.Rows.Count > 0) Then
                    _x = 0
                    For Each row As DataRow In dtIncap.Rows
                        Dim TipoAus As String = dtIncap.Rows(_x).Item("tipo_aus").ToString.Trim()
                        Dim CveAus As String = ""
                        Dim DescAus As String = ""
                        Dim _fecReal As Date
                        Dim tipo As Integer = 0

                        tipo = 1
                        CveAus = ConvertAus(dtIncap.Rows(_x).Item("tipo_aus").ToString.Trim(), tipo)
                        tipo = 2
                        DescAus = ConvertAus(dtIncap.Rows(_x).Item("tipo_aus").ToString.Trim(), tipo)
                        _fecReal = dtIncap.Rows(_x).Item("FECHA") ' Fecha Real que aplica esa incidencia

                        oWrite.WriteLine(NumEmplOH & "," & FullName & ", , , " & ", , ,1, ," & CveAus & "," & DescAus & "," & FechaSQL_2(_fecReal) & "," & FechaSQL_2(_fecReal) & "," & nombre_clase.Trim) '22/Nov/2018 solicitan que en incapacidades sea siempre la fecha Real
                        _x = _x + 1
                    Next
                End If

                '--Mandar totales de AUSENTISMOS e INCAPACIDADES
                If (sumAus = False) Then
                    '----PGO
                    Dim dtTotPGO As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS PGO FROM asist asi left join PERSONAL.dbo.personalvw psw on asi.RELOJ = psw.RELOJ where asi.COD_COMP='002' and asi.ANO=" & Ano & " and asi.periodo=" & Per & " AND asi.tipo_aus in ('PGO') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("PGO") = IIf((dtTotPGO.Rows.Count > 0), Double.Parse(dtTotPGO.Rows(0).Item("PGO").ToString.Trim()), 0)

                    '---FI
                    Dim dtTotFI As New DataTable
                    dtTotFI = sqlExecute("SELECT COUNT(asi.RELOJ) AS TOT_FI FROM asist asi left join PERSONAL.dbo.personalvw psw on asi.RELOJ = psw.RELOJ where asi.COD_COMP='002' and asi.ANO=" & Ano & " and asi.periodo=" & Per & " AND asi.tipo_aus in ('FI') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("FI") = IIf((dtTotFI.Rows.Count > 0), Double.Parse(dtTotFI.Rows(0).Item("TOT_FI").ToString.Trim()), 0)
                    '----JUS
                    Dim dtTotJUS As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS JUS FROM asist asi left join PERSONAL.dbo.personalvw psw on asi.RELOJ = psw.RELOJ where asi.COD_COMP='002' and asi.ANO=" & Ano & " and asi.periodo=" & Per & " AND asi.tipo_aus in ('JUS') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("JUS") = IIf((dtTotJUS.Rows.Count > 0), Double.Parse(dtTotJUS.Rows(0).Item("JUS").ToString.Trim()), 0)
                    '----PSG
                    Dim dtTotPSG As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS PSG FROM asist asi left join PERSONAL.dbo.personalvw psw on asi.RELOJ = psw.RELOJ where asi.COD_COMP='002' and asi.ANO=" & Ano & " and asi.periodo=" & Per & " AND asi.tipo_aus in ('PSG') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("PSG") = IIf((dtTotPSG.Rows.Count > 0), Double.Parse(dtTotPSG.Rows(0).Item("PSG").ToString.Trim()), 0)
                    '----SUS
                    Dim dtTotSUS As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS SUS FROM asist asi left join PERSONAL.dbo.personalvw psw on asi.RELOJ = psw.RELOJ where asi.COD_COMP='002' and asi.ANO=" & Ano & " and asi.periodo=" & Per & " AND asi.tipo_aus in ('SUS') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("SUS") = IIf((dtTotSUS.Rows.Count > 0), Double.Parse(dtTotSUS.Rows(0).Item("SUS").ToString.Trim()), 0)
                    '-----SHU
                    Dim dtTotSHU As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS SHU FROM asist asi left join PERSONAL.dbo.personalvw psw on asi.RELOJ = psw.RELOJ where asi.COD_COMP='002' and asi.ANO=" & Ano & " and asi.periodo=" & Per & " AND asi.tipo_aus in ('SHU') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("SHU") = IIf((dtTotSHU.Rows.Count > 0), Double.Parse(dtTotSHU.Rows(0).Item("SHU").ToString.Trim()), 0)
                    '-----PAR
                    Dim dtTotPAR As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS PAR FROM asist asi left join PERSONAL.dbo.personalvw psw on asi.RELOJ = psw.RELOJ where asi.COD_COMP='002' and asi.ANO=" & Ano & " and asi.periodo=" & Per & " AND asi.tipo_aus in ('PAR') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("PAR") = IIf((dtTotPAR.Rows.Count > 0), Double.Parse(dtTotPAR.Rows(0).Item("PAR").ToString.Trim()), 0)
                    '-----SAL
                    Dim dtTotSAL As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS SAL FROM asist asi left join PERSONAL.dbo.personalvw psw on asi.RELOJ = psw.RELOJ where asi.COD_COMP='002' and asi.ANO=" & Ano & " and asi.periodo=" & Per & " AND asi.tipo_aus in ('SAL') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("SAL") = IIf((dtTotSAL.Rows.Count > 0), Double.Parse(dtTotSAL.Rows(0).Item("SAL").ToString.Trim()), 0)

                    '----VAC
                    Dim dtTotVac As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS TOT_VAC FROM asist asi left join PERSONAL.dbo.personalvw psw on asi.RELOJ = psw.RELOJ where asi.COD_COMP='002' and asi.ANO=" & Ano & " and asi.periodo=" & Per & " AND asi.tipo_aus in ('VAC') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("VAC") = IIf((dtTotVac.Rows.Count > 0), Double.Parse(dtTotVac.Rows(0).Item("TOT_VAC").ToString.Trim()), 0)

                    '------INA
                    Dim dtTotINA As DataTable = sqlExecute("SELECT COUNT(aus.RELOJ) AS INA FROM ausentismo aus left join PERSONAL.dbo.personalvw psw on aus.RELOJ = psw.RELOJ where aus.COD_COMP='002' and aus.FECHA between '" & FechaSQL(f_ini_s) & "' and '" & FechaSQL(f_fin_s) & "' and aus.periodo=" & Per & " AND aus.tipo_aus in ('INA') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("INA") = IIf((dtTotINA.Rows.Count > 0), Double.Parse(dtTotINA.Rows(0).Item("INA").ToString.Trim()), 0)

                    '----EG
                    Dim dtTotEG As DataTable = sqlExecute("SELECT COUNT(aus.RELOJ) AS TOT_EG FROM ausentismo aus left join PERSONAL.dbo.personalvw psw on aus.RELOJ = psw.RELOJ where aus.COD_COMP='002' and aus.FECHA between '" & FechaSQL(f_ini_s) & "' and '" & FechaSQL(f_fin_s) & "' and aus.periodo=" & Per & " AND aus.tipo_aus in ('EG') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("EG") = IIf((dtTotEG.Rows.Count > 0), Double.Parse(dtTotEG.Rows(0).Item("TOT_EG").ToString.Trim()), 0)
                    '----MAT
                    Dim dtTotMAT As DataTable = sqlExecute("SELECT COUNT(aus.RELOJ) AS MAT FROM ausentismo aus left join PERSONAL.dbo.personalvw psw on aus.RELOJ = psw.RELOJ where aus.COD_COMP='002' and aus.FECHA between '" & FechaSQL(f_ini_s) & "' and '" & FechaSQL(f_fin_s) & "' and aus.periodo=" & Per & " AND aus.tipo_aus in ('MAT') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("MAT") = IIf((dtTotMAT.Rows.Count > 0), Double.Parse(dtTotMAT.Rows(0).Item("MAT").ToString.Trim()), 0)
                    '-----RT
                    Dim dtTotRT As DataTable = sqlExecute("SELECT COUNT(aus.RELOJ) AS RT FROM ausentismo aus left join PERSONAL.dbo.personalvw psw on aus.RELOJ = psw.RELOJ where aus.COD_COMP='002' and aus.FECHA between '" & FechaSQL(f_ini_s) & "' and '" & FechaSQL(f_fin_s) & "' and aus.periodo=" & Per & " AND aus.tipo_aus in ('RT') and psw.alta  <= '" & FechaSQL(f_fin_s) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini_s) & "')   and isnull(psw.cod_super, '') <> ''", "TA")
                    dDato("RT") = IIf((dtTotRT.Rows.Count > 0), Double.Parse(dtTotRT.Rows(0).Item("RT").ToString.Trim()), 0)

                    sumAus = True
                End If



                '*******************************END_ AUSENTIMOS
            Next



            '***************************************
            oWrite.Close() ' Cerrar archivo
            frmTrabajando.Hide() ' Cerrar cuadro de vance

            Try
                Dim archivo_copia As String = DireccionReportes & "archivos_nomina\horas_" & Usuario.Trim
                archivo_copia &= FechaHoraSQL(Now, True, False).Replace(":", "").Replace(Space(1), "").Replace("-", "") & ".txt"
                File.Copy(strFileName, archivo_copia)
            Catch ex As Exception

            End Try

            ' --------Mandar Reporte resumen
            dtFiltroTA = dtDatos.Copy
            Dim dTt As DataRow ' - Mandar solo Totales
            dTt = dtFiltroTA.NewRow
            dTt("grupo") = "0"
            dTt("reloj") = 0
            dTt("ANO") = cmbAno.SelectedValue.ToString.Trim
            dTt("PERIODO") = cmbPeriodo.SelectedValue.ToString.Trim

            For Each dIt As DataRow In dtFiltroTA.Rows ' Para cada Renglón del DT que contiene toda la info
                dTt("reloj") = Val(dTt("reloj")) + 1

                For Each dCol As DataColumn In dtFiltroTA.Columns 'Para cada columna del DT que contiene toda la info
                    If dCol.DataType Is GetType(System.Double) Or dCol.DataType Is GetType(System.Int32) Then 'Solo si el dato es de tipo Double o INT
                        dTt(dCol.ColumnName) = IIf(IsDBNull(dTt(dCol.ColumnName)), 0, dTt(dCol.ColumnName)) + IIf(IsDBNull(dIt(dCol.ColumnName)), 0, dIt(dCol.ColumnName))
                    End If
                Next

            Next

            '   dTt("reloj") = "Total " & dTt("reloj")
            dTt("reloj") = "Total "
            dtFiltroTA.Rows.Add(dTt)

            Dim dtTotales As New DataTable
            dtTotales = dtFiltroTA.Clone
            dtTotales.ImportRow(dTt)

            '--------Mandar los dos reportes uno tras otro
            frmVistaPrevia.LlamarReporte("Revisión de horas OH TOTALES", dtTotales)
            frmVistaPrevia.Show(Me)

            'frmVistaPrevia.LlamarReporte("Revisión de horas OH TOTALES_CC", TotResXCC(cmbAno.SelectedValue.ToString.Trim, cmbPeriodo.SelectedValue.ToString.Trim, FechaSQL(f_ini_s), FechaSQL(f_fin_s), dtDatos))
            'frmVistaPrevia.Show(Me)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            Application.DoEvents()
        End Try

    End Sub

    'Private Function TotResXCC(ByVal ano As String, ByVal per As String, ByVal f_ini As Date, ByVal f_fin As Date, ByVal dtInfoSemana As DataTable) As DataTable
    '    Try
    '        '--Definir Columnas del DT FINAL
    '        Dim dtFinal As New DataTable
    '        dtFinal.Columns.Add("ANO")
    '        dtFinal.Columns.Add("PERIODO")
    '        dtFinal.Columns.Add("CENTRO_COSTOS")
    '        dtFinal.Columns.Add("HRS_DOBLES", GetType(System.Double))
    '        dtFinal.Columns.Add("HRS_TRIPLES", GetType(System.Double))
    '        dtFinal.Columns.Add("HRS_NOPAG", GetType(System.Double))
    '        dtFinal.Columns.Add("HRS_RETARDO", GetType(System.Double))
    '        dtFinal.Columns.Add("HRS_FEL", GetType(System.Double))
    '        dtFinal.Columns.Add("DIADOM", GetType(System.Double))
    '        dtFinal.Columns.Add("DIASAB", GetType(System.Double))
    '        dtFinal.Columns.Add("DIASAB_UNI", GetType(System.Double))
    '        dtFinal.Columns.Add("PGO", GetType(System.Double))
    '        dtFinal.Columns.Add("FI", GetType(System.Double))
    '        dtFinal.Columns.Add("JUS", GetType(System.Double))
    '        dtFinal.Columns.Add("PSG", GetType(System.Double))
    '        dtFinal.Columns.Add("SUS", GetType(System.Double))
    '        dtFinal.Columns.Add("SHU", GetType(System.Double))
    '        dtFinal.Columns.Add("PAR", GetType(System.Double))
    '        dtFinal.Columns.Add("SAL", GetType(System.Double))
    '        dtFinal.Columns.Add("INA", GetType(System.Double))
    '        dtFinal.Columns.Add("EG", GetType(System.Double))
    '        dtFinal.Columns.Add("MAT", GetType(System.Double))
    '        dtFinal.Columns.Add("RT", GetType(System.Double))
    '        dtFinal.Columns.Add("DIACON", GetType(System.Double))
    '        dtFinal.Columns.Add("DIASIN", GetType(System.Double))
    '        dtFinal.Columns.Add("DIADES", GetType(System.Double))


    '        Dim dtCCostos As New DataTable
    '        dtCCostos = sqlExecute("SELECT DISTINCT psw.CENTRO_COSTOS AS CENTRO_COSTOS from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw " & _
    '                               "on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and ns.ANO='" & ano & "' and ns.PERIODO='" & per & "' " & _
    '                               "and psw.alta  <= '" & FechaSQL(f_fin) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini) & "')   and isnull(psw.cod_super, '') <> ''")

    '        If dtCCostos.Rows.Count > 0 Then
    '            For Each row As DataRow In dtCCostos.Rows '--Para cada Centro de costo que hay en ese periodo
    '                Dim drow As DataRow = dtFinal.NewRow
    '                Dim cCosto As String = IIf(IsDBNull(row("CENTRO_COSTOS")), "", row("CENTRO_COSTOS").ToString.Trim)
    '                drow("CENTRO_COSTOS") = cCosto

    '                '--Horas Dobles
    '                Dim dtHrsDbls As DataTable = sqlExecute("SELECT ISNULL((SUM (ns.hrs_dobles)),0) AS HORAS_DOBLES from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and " & _
    '                                                        "ns.ANO='" & ano & "' and ns.PERIODO='" & per & "' and psw.alta  <= '" & FechaSQL(f_fin) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini) & "')   and isnull(psw.cod_super, '') <> '' " & _
    '                                                        "and psw.CENTRO_COSTOS='" & cCosto & "'")
    '                drow("HRS_DOBLES") = IIf((dtHrsDbls.Rows.Count > 0), Double.Parse(dtHrsDbls.Rows(0).Item("HORAS_DOBLES").ToString.Trim()), 0)

    '                '----Horas Triples
    '                Dim dtHrsTrip As DataTable = sqlExecute("SELECT ISNULL((SUM (ns.hrs_triples)),0) AS HORAS_TRIPLES from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and " & _
    '                                                     "ns.ANO='" & ano & "' and ns.PERIODO='" & per & "' and psw.alta  <= '" & FechaSQL(f_fin) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini) & "')   and isnull(psw.cod_super, '') <> '' " & _
    '                                                     "and psw.CENTRO_COSTOS='" & cCosto & "'")
    '                drow("HRS_TRIPLES") = IIf((dtHrsTrip.Rows.Count > 0), Double.Parse(dtHrsTrip.Rows(0).Item("HORAS_TRIPLES").ToString.Trim()), 0)

    '                '---Salida Anticipada
    '                Dim dtHrsNoPag As DataTable = sqlExecute("SELECT SUM (ns.hrs_nopag) AS HRS_NOPAG from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and " & _
    '                                                     "ns.ANO='" & ano & "' and ns.PERIODO='" & per & "' and psw.alta  <= '" & FechaSQL(f_fin) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini) & "')   and isnull(psw.cod_super, '') <> '' " & _
    '                                                     "and psw.CENTRO_COSTOS='" & cCosto & "'")
    '                drow("HRS_NOPAG") = IIf((dtHrsNoPag.Rows.Count > 0), Double.Parse(dtHrsNoPag.Rows(0).Item("HRS_NOPAG").ToString.Trim()), 0)

    '                '----Horas Retardo
    '                Dim dtHrsRet As DataTable = sqlExecute("SELECT ISNULL((SUM (ns.hrs_retardo)),0) AS HRS_RETARDO from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and " & _
    '                                                   "ns.ANO='" & ano & "' and ns.PERIODO='" & per & "' and psw.alta  <= '" & FechaSQL(f_fin) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini) & "')   and isnull(psw.cod_super, '') <> '' " & _
    '                                                   "and psw.CENTRO_COSTOS='" & cCosto & "'")
    '                drow("HRS_RETARDO") = IIf((dtHrsRet.Rows.Count > 0), Double.Parse(dtHrsRet.Rows(0).Item("HRS_RETARDO").ToString.Trim()), 0)

    '                '-------Horas Festivas
    '                Dim dtHrsFest As DataTable = sqlExecute("SELECT ISNULL((SUM (ns.hrs_fel)),0) AS HRS_FEL from TA.dbo.nomsem ns left join PERSONAL.dbo.personalvw psw on ns.RELOJ = psw.RELOJ where psw.COD_COMP='002' and " & _
    '                                                  "ns.ANO='" & ano & "' and ns.PERIODO='" & per & "' and psw.alta  <= '" & FechaSQL(f_fin) & "' and (psw.baja is null or psw.baja >= '" & FechaSQL(f_ini) & "')   and isnull(psw.cod_super, '') <> '' " & _
    '                                                  "and psw.CENTRO_COSTOS='" & cCosto & "'")
    '                drow("HRS_FEL") = IIf((dtHrsFest.Rows.Count > 0), Double.Parse(dtHrsFest.Rows(0).Item("HRS_FEL").ToString.Trim()), 0)

    '                '--------Prima Dominical, Totales
    '                Dim dtPrimDom As DataTable = sqlExecute("SELECT COUNT(ns.RELOJ) AS DIADOM from nomsem ns left join asist a on ns.RELOJ=a.RELOJ left join PERSONAL.dbo.personalvw psw ON ns.RELOJ=psw.RELOJ and ns.ANO=a.ANO and ns.PERIODO=a.PERIODO " & _
    '                                                        "WHERE ns.PRIMA_DOM=1 and ns.ANO ='" & ano & "' and ns.PERIODO='" & per & "' and datepart(dw,a.FHA_ENT_HOR)=1 and a.COD_COMP='002' and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("DIADOM") = IIf((dtPrimDom.Rows.Count > 0), Double.Parse(dtPrimDom.Rows(0).Item("DIADOM").ToString.Trim()), 0)

    '                '--------Prima Sabatina ( $ PAGO)
    '                Dim dtPrimSabDin As DataTable = sqlExecute("select ISNULL((SUM(psw.SACTUAL * 0.25) ),0) AS DIASAB from nomsem ns left join asist a on ns.RELOJ=a.RELOJ left join PERSONAL.dbo.personalvw psw on ns.RELOJ=psw.RELOJ and ns.ANO=a.ANO and ns.PERIODO=a.PERIODO " & _
    '                                                           "WHERE ns.PRIMA_SAB=1 and ns.ANO ='" & ano & "' and ns.PERIODO='" & per & "' and datepart(dw,a.FHA_ENT_HOR)=7 and a.COD_COMP='002' and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("DIASAB") = IIf((dtPrimSabDin.Rows.Count > 0), Double.Parse(dtPrimSabDin.Rows(0).Item("DIASAB").ToString.Trim()), 0)

    '                '-------Prima Sabatina (Totales Unidades)
    '                Dim dtPriSabU As DataTable = sqlExecute("SELECT COUNT(ns.RELOJ) AS DIASAB_UNI from nomsem ns left join asist a on ns.RELOJ=a.RELOJ left join PERSONAL.dbo.personalvw psw ON ns.RELOJ=psw.RELOJ and ns.ANO=a.ANO and ns.PERIODO=a.PERIODO " & _
    '                                                       "WHERE ns.PRIMA_SAB=1 and ns.ANO ='" & ano & "' and ns.PERIODO='" & per & "' and datepart(dw,a.FHA_ENT_HOR)=7 and a.COD_COMP='002' and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("DIASAB_UNI") = IIf((dtPriSabU.Rows.Count > 0), Double.Parse(dtPriSabU.Rows(0).Item("DIASAB_UNI").ToString.Trim()), 0)

    '                '--------PGO
    '                Dim dtTotPGO As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS PGO FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo='" & per & "' AND asi.tipo_aus in ('PGO') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("PGO") = IIf((dtTotPGO.Rows.Count > 0), Double.Parse(dtTotPGO.Rows(0).Item("PGO").ToString.Trim()), 0)

    '                '------FI
    '                Dim dtTotFI As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS FI FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo='" & per & "' AND asi.tipo_aus in ('FI') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("FI") = IIf((dtTotFI.Rows.Count > 0), Double.Parse(dtTotFI.Rows(0).Item("FI").ToString.Trim()), 0)

    '                '------JUS
    '                Dim dtTotJUS As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS JUS FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo='" & per & "' AND asi.tipo_aus in ('JUS') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("JUS") = IIf((dtTotJUS.Rows.Count > 0), Double.Parse(dtTotJUS.Rows(0).Item("JUS").ToString.Trim()), 0)

    '                '------PSG
    '                Dim dtTotPSG As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS PSG FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo='" & per & "' AND asi.tipo_aus in ('PSG') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("PSG") = IIf((dtTotPSG.Rows.Count > 0), Double.Parse(dtTotPSG.Rows(0).Item("PSG").ToString.Trim()), 0)

    '                '-------SUS
    '                Dim dtTotSUS As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS SUS FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo='" & per & "' AND asi.tipo_aus in ('SUS') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("SUS") = IIf((dtTotSUS.Rows.Count > 0), Double.Parse(dtTotSUS.Rows(0).Item("SUS").ToString.Trim()), 0)

    '                '-------SHU
    '                Dim dtTotSHU As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS SHU FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo='" & per & "' AND asi.tipo_aus in ('SHU') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("SHU") = IIf((dtTotSHU.Rows.Count > 0), Double.Parse(dtTotSHU.Rows(0).Item("SHU").ToString.Trim()), 0)

    '                '-------PAR
    '                Dim dtTotPAR As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS PAR FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo='" & per & "' AND asi.tipo_aus in ('PAR') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("PAR") = IIf((dtTotPAR.Rows.Count > 0), Double.Parse(dtTotPAR.Rows(0).Item("PAR").ToString.Trim()), 0)

    '                '-------SAL
    '                Dim dtTotSAL As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS SAL FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo='" & per & "' AND asi.tipo_aus in ('SAL') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("SAL") = IIf((dtTotSAL.Rows.Count > 0), Double.Parse(dtTotSAL.Rows(0).Item("SAL").ToString.Trim()), 0)

    '                '-------INA
    '                Dim dtTotINA As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS INA FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo='" & per & "' AND asi.tipo_aus in ('INA') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("INA") = IIf((dtTotINA.Rows.Count > 0), Double.Parse(dtTotINA.Rows(0).Item("INA").ToString.Trim()), 0)

    '                '-------EG
    '                Dim dtTotEG As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS EG FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo='" & per & "' AND asi.tipo_aus in ('EG') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("EG") = IIf((dtTotEG.Rows.Count > 0), Double.Parse(dtTotEG.Rows(0).Item("EG").ToString.Trim()), 0)

    '                '-------MAT
    '                Dim dtTotMAT As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS MAT FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo='" & per & "' AND asi.tipo_aus in ('MAT') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("MAT") = IIf((dtTotMAT.Rows.Count > 0), Double.Parse(dtTotMAT.Rows(0).Item("MAT").ToString.Trim()), 0)

    '                '-------RT
    '                Dim dtTotRT As DataTable = sqlExecute("SELECT COUNT(asi.RELOJ) AS RT FROM asist asi LEFT JOIN PERSONAL.dbo.personalvw psw on asi.RELOJ=psw.RELOJ where asi.COD_COMP='002' and asi.ANO='" & ano & "' and asi.periodo='" & per & "' AND asi.tipo_aus in ('RT') and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("RT") = IIf((dtTotRT.Rows.Count > 0), Double.Parse(dtTotRT.Rows(0).Item("RT").ToString.Trim()), 0)

    '                '-------DIACON
    '                Dim dtTotConSub As DataTable = sqlExecute("select count(hrc.reloj) as DIACON from hrs_brt_cafeteria hrc left join PERSONAL.dbo.personalvw psw on hrc.reloj=psw.RELOJ " & _
    '                                                          "where hrc.cod_comp='002' and hrc.FECHA>='" & FechaSQL(f_ini) & "' AND hrc.fecha<='" & FechaSQL(f_fin) & "' AND hrc.subsidio='C' and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("DIACON") = IIf((dtTotConSub.Rows.Count > 0), Double.Parse(dtTotConSub.Rows(0).Item("DIACON").ToString.Trim()), 0)

    '                '-------DIASIN
    '                Dim dtTotSinSub As DataTable = sqlExecute("select count(hrc.reloj) as DIASIN from hrs_brt_cafeteria hrc left join PERSONAL.dbo.personalvw psw on hrc.reloj=psw.RELOJ " & _
    '                                              "where hrc.cod_comp='002' and hrc.FECHA>='" & FechaSQL(f_ini) & "' AND hrc.fecha<='" & FechaSQL(f_fin) & "' AND hrc.subsidio='S' and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("DIASIN") = IIf((dtTotSinSub.Rows.Count > 0), Double.Parse(dtTotSinSub.Rows(0).Item("DIASIN").ToString.Trim()), 0)

    '                '-------DIADES
    '                Dim dtTotDes As DataTable = sqlExecute("select count(hrc.reloj) as DIADES from hrs_brt_cafeteria hrc left join PERSONAL.dbo.personalvw psw on hrc.reloj=psw.RELOJ " & _
    '                                          "where hrc.cod_comp='002' and hrc.FECHA>='" & FechaSQL(f_ini) & "' AND hrc.fecha<='" & FechaSQL(f_fin) & "' AND hrc.subsidio='Z' and psw.CENTRO_COSTOS='" & cCosto & "'", "TA")
    '                drow("DIADES") = IIf((dtTotDes.Rows.Count > 0), Double.Parse(dtTotDes.Rows(0).Item("DIADES").ToString.Trim()), 0)

    '                '--Para Año y Periodo
    '                drow("ANO") = ano
    '                drow("PERIODO") = per
    '                dtFinal.Rows.Add(drow)
    '            Next
    '        End If
    '        Return dtFinal

    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
    '    End Try
    'End Function

    Private Function FechaSQL_2(ByVal Fecha As Date) As String
        Try
            Return "'" & Fecha.Year.ToString.PadLeft(4, "0") & Fecha.Month.ToString.PadLeft(2, "0") & Fecha.Day.ToString.PadLeft(2, "0")
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function ConvertHHMM(hrsDbl As Double, _FormatoCampo As String) As String
        Try
            Dim hrs As String = ""
            Dim hrFormat As String = ""
            Dim cantDig As Integer
            Dim Min As Double = 0
            Dim MinStr As String = ""
            If _FormatoCampo = "MIN" Then  'Si el campo viene en minutos, hay que cambiarlo a horas y luego redondear a 2 decimales
                hrsDbl = Math.Round((hrsDbl / 60), 2)
            End If
            hrs = hrsDbl.ToString
            cantDig = Len(hrs)
            Select Case cantDig
                Case 1 ' de 5 a 05:00
                    hrFormat = "0" & hrs.Substring(0, 1) & ":00"
                Case 3 ' de 0.5 a 00:30  Aqui hay que agregarle un 0 a la derecha a los min
                    MinStr = hrs.Substring(2, 1) & "0"
                    Min = Math.Round((Double.Parse(MinStr) * 60) / 100) '- Convertir a Minutos de 60

                    If (Len(Min.ToString) = 1) Then ' Si el valor de Min da de un solo digito agregarle un cero a la izquierda
                        hrFormat = "0" & hrs.Substring(0, 1) & ":0" & (Min.ToString)
                    Else
                        hrFormat = "0" & hrs.Substring(0, 1) & ":" & (Min.ToString)
                    End If

                Case 4 ' De [5.80 a 05:48] ó [56.2 a 56:12]
                    If hrs.Substring(1, 1) = "." Then ' Si es 5.80 ejem
                        Min = Math.Round((Double.Parse(hrs.Substring(2, 2)) * 60) / 100) ' - Convertir a Minutos de 60
                        If (Len(Min.ToString) = 1) Then ' Si el valor de Min da de un solo digito agregarle un cero a la izquierda
                            hrFormat = "0" & hrs.Substring(0, 1) & ":0" & (Min.ToString)
                        Else
                            hrFormat = "0" & hrs.Substring(0, 1) & ":" & (Min.ToString)
                        End If
                    ElseIf (hrs.Substring(2, 1) = ".") Then ' Si es x ejemplo 56.2
                        MinStr = hrs.Substring(3, 1) & "0" 'Agregar un 0 a los minutos, ejemplo si es 2 -> 20
                        Min = Math.Round((Double.Parse(MinStr) * 60) / 100) ' - Convertir a Minutos de 60
                        If (Len(Min.ToString) = 1) Then ' Si el valor de Min da de un solo digito agregarle un cero a la izquierda
                            hrFormat = "0" & hrs.Substring(0, 1) & ":0" & (Min.ToString)
                        Else
                            hrFormat = "0" & hrs.Substring(0, 1) & ":" & (Min.ToString)
                        End If
                    End If

                Case 5 ' De 72.47 a 72:28
                    Min = Math.Round((Double.Parse(hrs.Substring(3, 2)) * 60) / 100) ' - Convertir a Minutos de 60
                    If (Len(Min.ToString) = 1) Then ' Si el valor de Min da de un solo digito agregarle un cero a la izquierda
                        hrFormat = hrs.Substring(0, 2) & ":0" & Min.ToString
                    Else
                        hrFormat = hrs.Substring(0, 2) & ":" & Min.ToString
                    End If

                Case Else
                    hrFormat = " "
            End Select
            Return hrFormat
        Catch ex As Exception

        End Try
    End Function

    Private Function ConvertAus(tipAus As String, _tipo As Integer) As String ' Devolver la cve de aus y desc de acuerdo a tabla mandada por cliente
        Dim _CveAus As String = ""
        Dim _DescAus As String = ""
        Select Case tipAus
            Case "PGO"
                _CveAus = "8"
                _DescAus = "PERMISO CON GOCE"
            Case "FI"
                _CveAus = "15"
                _DescAus = "FALTA D"
            Case "JUS"
                _CveAus = "17"
                _DescAus = "FALTA JUSTIFICADA"
            Case "PAR"
                _CveAus = "19"
                _DescAus = "PERMISO POR MATERNIDAD"
            Case "SAL"
                _CveAus = "20"
                _DescAus = "PERMISO CON GOCE DE SUELDO D"
            Case "SUS"
                _CveAus = "21"
                _DescAus = "SUSPENSION D"
            Case "PSG"
                _CveAus = "22"
                _DescAus = "PERMISO SIN GOCE DE SUELDO D"
            Case "SHU"
                _CveAus = "24"
                _DescAus = "PARO TECNICO D"
            Case "EG"
                _CveAus = "25"
                _DescAus = "INC ENFERMEDAD GENERAL"
            Case "MAT"
                _CveAus = "26"
                _DescAus = "INC MATERNIDAD"
            Case "RT"
                _CveAus = "27"
                _DescAus = "INC RIESGO DE TRABAJO"
            Case "INA"
                _CveAus = "28"
                _DescAus = "INC EN TRAYECTO D"
            Case "VAC"
                _CveAus = "VAC"
                _DescAus = "VACACIONES"
            Case Else
                _CveAus = " "
                _DescAus = " "
        End Select

        If _tipo = 1 Then
            Return _CveAus
        End If

        If _tipo = 2 Then
            Return _DescAus
        End If
    End Function


    Private Sub CorrecionesANT()
        Dim dtDatos As New DataTable
        Dim dtInfoNomsem As New DataTable
        Dim dtInfoNomsemREF As New DataTable
        Dim dRow As DataRow
        Dim dRowREF As DataRow
        Dim Ano As String
        Dim Per As String
        Dim Cia As String

        Dim Inserta As Boolean = False

        Dim Normales As String = ""
        Dim Festivo As String = ""
        Dim Dobles As String = ""
        Dim Triples As String = ""
        Dim Vac As String = ""
        Dim Punt As String = ""
        Dim Asist As String = ""
        Dim Dom As String = ""
        Dim Perfecta As String = ""

        Dim strFileName As String = ""
        Dim oWrite As System.IO.StreamWriter
        Dim GuardaArchivo As Boolean = True

        Try
            Me.Cursor = Cursors.WaitCursor
            Ano = cmbAno.SelectedValue
            Per = cmbPeriodo.SelectedValue


            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("COD_COMP")
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("COD_SUPER")
            dtDatos.Columns.Add("SUPER")
            dtDatos.Columns.Add("COD_TIPO")
            dtDatos.Columns.Add("PERIODO")

            dtDatos.Columns.Add("NORMALES", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("DOBLES", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("TRIPLES", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("VAC", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("FESTIVO", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("PUNT", System.Type.GetType("System.Int16"))
            dtDatos.Columns.Add("ASIST", System.Type.GetType("System.Int16"))
            dtDatos.Columns.Add("DOM", System.Type.GetType("System.Double"))

            dtDatos.Columns.Add("PERFECTA")
            dtDatos.Columns.Add("COMENTARIO")
            Dim c As Integer = 0
            'Tomar los datos de nomsem, filtrando solo operativos, del periodo, año y compañía seleccionadas
            dtInfoNomsem = sqlExecute("SELECT nomsem.*,nombres,personalvw.cod_comp,cod_tipo,cod_depto,cod_super,nombre_super,cod_tipo FROM ta.dbo.nomsem LEFT JOIN personal.dbo.personalvw ON nomsem.reloj = personalvw.reloj WHERE cod_tipo = 'O'  AND personalvw.cod_comp = '" & Cia & "' AND nomsem.periodo = '" & Per & "' AND ano = '" & Ano & "'", "TA")
            For Each dRow In dtInfoNomsem.Rows
                Inserta = False
                c = c + 1
                'Buscar si existe el registro en nomsem_ref_horas
                dtInfoNomsemREF = sqlExecute("SELECT * FROM nomsem_ref_horas WHERE reloj = '" & dRow("reloj") & "' AND periodo = '" & Per & "' AND ano = '" & Ano & "'", "TA")
                'Si no lo localiza, insertar completo
                If dtInfoNomsemREF.Rows.Count = 0 Then
                    Inserta = True
                    Perfecta = dRow("asistencia_perfecta")

                    Normales = FormatNumber(dRow("hrs_normales"), 2)
                    Festivo = FormatNumber(dRow("hrs_festivo"), 2)
                    Dobles = FormatNumber(dRow("hrs_dobles"), 2)
                    Triples = FormatNumber(dRow("hrs_triples"), 2)
                    Dom = FormatNumber(dRow("hrs_prim_dom"), 2).ToString
                    Punt = dRow("bono_puntualidad")
                    Asist = dRow("bono_asistencia")
                    Vac = 0
                Else
                    'Si lo localiza, comparar si hay diferencias
                    dRowREF = dtInfoNomsemREF.Rows(0)
                    If (dRow("hrs_normales") <> dRowREF("hrs_normales") Or dRow("hrs_dobles") <> dRowREF("hrs_dobles") Or dRow("hrs_triples") <> dRowREF("hrs_triples") Or dRow("hrs_festivo") <> dRowREF("hrs_festivo") Or dRow("hrs_prim_dom") <> dRowREF("hrs_prim_dom") Or dRow("asistencia_perfecta") <> dRowREF("asistencia")) Then
                        Inserta = True

                        If dRow("asistencia_perfecta") = 0 And dRowREF("asistencia") = 1 Then
                            Perfecta = 2
                        Else
                            Perfecta = dRowREF("asistencia_perfecta")
                        End If

                        Normales = FormatNumber(dRowREF("hrs_normales"), 2)
                        Festivo = FormatNumber(dRowREF("hrs_festivo"), 2)
                        Dobles = FormatNumber(dRowREF("hrs_dobles"), 2)
                        Triples = FormatNumber(dRowREF("hrs_triples"), 2)
                        Dom = FormatNumber(dRowREF("hrs_prim_dom"), 2).ToString
                        Punt = IIf(IsDBNull(dRowREF("bono_puntualidad")), 0, dRowREF("bono_puntualidad"))
                        Asist = IIf(IsDBNull(dRowREF("bono_asistencia")), 0, dRowREF("bono_asistencia"))
                        Vac = 0
                    End If
                End If

                If Inserta Then
                    dtDatos.Rows.Add({dRow("reloj"), dRow("cod_comp"), dRow("cod_depto"), dRow("cod_super"), dRow("nombre_super"), dRow("cod_tipo"), Per, Normales, Dobles, Triples, Vac, Festivo, Punt, Asist, Dom, Perfecta, "CORRECCIONES"})
                End If
            Next

            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

            PreguntaArchivo.Filter = "Text file|*.txt"
            PreguntaArchivo.FileName = Cia & "CorPC.txt"
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            End If
            Try
                oWrite = File.CreateText(strFileName)
                GuardaArchivo = True
            Catch ex As Exception
                oWrite = Nothing
                GuardaArchivo = False
            End Try

            If GuardaArchivo Then
                For Each dRow In dtDatos.Rows
                    oWrite.WriteLine(dRow("reloj").ToString.Trim.PadLeft(10) & " " & _
                                     FormatNumber(dRow("normales"), 2).ToString.Trim.PadLeft(9) & _
                                     FormatNumber(dRow("festivo"), 2).ToString.Trim.PadLeft(12) & _
                                     FormatNumber(dRow("dobles") + dRow("triples"), 2).ToString.Trim.PadLeft(7) & _
                                     FormatNumber(dRow("dom"), 2).ToString.Trim.PadLeft(10) & _
                                     dRow("perfecta").ToString.Trim.PadLeft(1))
                Next
            End If
            oWrite.Close()
            dtFiltroTA = dtDatos.Copy
            frmVistaPrevia.LlamarReporte("Revisión de horas antes de envío de información", dtFiltroTA)
            frmVistaPrevia.Show(Me)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs)
        Dim dtDatos As New DataTable
        Dim dtInfoNomsem As New DataTable
        Dim rsDatos As New ADODB.Recordset

        Dim dRow As DataRow
        Dim Ano As String
        Dim Per As String
        Dim Cia As String

        Dim Normales As String = ""
        Dim Festivo As String = ""
        Dim Dobles As String = ""
        Dim Triples As String = ""
        Dim Extras As String = ""
        Dim Vac As String = ""
        Dim Punt As String = ""
        Dim Asist As String = ""
        Dim Dom As String = ""
        Dim Perfecta As String = ""
        Dim FondoUnido As String = ""

        Dim TotalNormales As Double = 0
        Dim TotalFestivo As Double = 0
        Dim TotalDobles As Double = 0
        Dim TotalTriples As Double = 0
        Dim TotalExtras As Double = 0
        Dim TotalVac As Double = 0
        Dim TotalPunt As Double = 0
        Dim TotalAsist As Double = 0
        Dim TotalDom As Double = 0
        Dim TotalFondoUnido As Double = 0

        Dim strFileName As String = ""
        Dim GuardaArchivo As Boolean = True

        Try
            Me.Cursor = Cursors.WaitCursor
            Ano = cmbAno.SelectedValue
            Per = cmbPeriodo.SelectedValue


            dtDatos.Columns.Add("NORMALES", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("FESTIVO", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("DOBLES", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("TRIPLES", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("EXTRAS", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("DOM", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("PERFECTA")
            dtDatos.Columns.Add("FONDO_UNIDO", System.Type.GetType("System.Double"))

            rsDatos.Fields.Append("RELOJ", ADODB.DataTypeEnum.adChar, 10)
            rsDatos.Fields.Append("COD_TURNO", ADODB.DataTypeEnum.adChar, 10)
            rsDatos.Fields.Append("NOMBRE", ADODB.DataTypeEnum.adChar, 50)
            rsDatos.Fields.Append("NORMALES", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("FESTIVO", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("DOBLES", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("TRIPLES", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("EXTRAS", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("DOM", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("FONDO_UNIDO", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("PERFECTA", ADODB.DataTypeEnum.adBoolean)

            rsDatos.Open()
            Dim c As Integer = 0
            'Tomar los datos de nomsem, filtrando solo operativos, del periodo, año y compañía seleccionadas
            dtInfoNomsem = sqlExecute("SELECT nomsem.*,nombres,personalvw.cod_comp,cod_tipo,cod_depto,cod_super,nombre_super,cod_tipo,cod_turno FROM ta.dbo.nomsem LEFT JOIN personal.dbo.personalvw ON nomsem.reloj = personalvw.reloj WHERE cod_tipo = 'O' AND personalvw.cod_comp = '" & Cia & "' AND nomsem.periodo = '" & Per & "' AND ano = '" & Ano & "'", "TA")
            For Each dRow In dtInfoNomsem.Rows
                c = c + 1

                Normales = FormatNumber(dRow("hrs_normales"), 2)
                Festivo = FormatNumber(dRow("hrs_festivo"), 2)
                Dobles = FormatNumber(dRow("hrs_dobles"), 2)
                Triples = FormatNumber(dRow("hrs_triples"), 2)
                Extras = FormatNumber(dRow("hrs_triples") + dRow("hrs_dobles"), 2)
                Dom = FormatNumber(dRow("hrs_prim_dom"), 2).ToString
                Perfecta = dRow("asistencia_perfecta")
                Punt = dRow("bono_puntualidad")
                Asist = dRow("bono_asistencia")
                Vac = 0

                '**** OJO Para el 6o. turno trabajara solo 24 pero el equivalente sera a 40 horas
                '**** por eso se multiplica por el factor 1.6667 (40/24)	IVO 12 Ago 06
                If dRow("cod_turno") = "6" Then
                    Normales = FormatNumber(Val(Normales) * (40 / 24), 2)
                    Festivo = FormatNumber(Val(Festivo) * (40 / 24), 2)
                    Dom = FormatNumber(Val(Dom) * (40 / 24), 2)
                End If

                'Buscar Fondo Unido
                dtTemporal = sqlExecute("SELECT contenido FROM detalle_auxiliares WHERE reloj = '" & dRow("reloj") & "' AND campo = 'FONDOUNIDO'")
                If dtTemporal.Rows.Count > 0 Then
                    FondoUnido = Val(dtTemporal.Rows(0).Item("contenido"))
                Else
                    FondoUnido = 0
                End If

                TotalNormales += dRow("hrs_normales")
                TotalFestivo += dRow("hrs_festivo")
                TotalDobles += dRow("hrs_dobles")
                TotalTriples += dRow("hrs_triples")
                TotalExtras += dRow("hrs_triples") + dRow("hrs_dobles")
                TotalDom += dRow("hrs_prim_dom")
                TotalFondoUnido += FondoUnido


                'Insertar en rsDatos para exportar a excel
                rsDatos.AddNew()
                rsDatos.Fields("reloj").Value = dRow("reloj")
                rsDatos.Fields("cod_turno").Value = dRow("cod_turno")
                rsDatos.Fields("nombre").Value = dRow("nombres")
                rsDatos.Fields("Normales").Value = Normales
                rsDatos.Fields("Festivo").Value = Festivo
                rsDatos.Fields("Dobles").Value = Dobles
                rsDatos.Fields("Triples").Value = Triples
                rsDatos.Fields("Extras").Value = Extras
                rsDatos.Fields("Dom").Value = Dom
                rsDatos.Fields("Perfecta").Value = Perfecta
                rsDatos.Fields("Fondo_Unido").Value = FondoUnido
                rsDatos.Update()

            Next

            'Insertar en dtDatos para reporte
            dtDatos.Rows.Add({TotalNormales, TotalFestivo, TotalDobles, TotalTriples, TotalExtras, TotalDom, TotalFondoUnido})

            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog
            PreguntaArchivo.Filter = "Excel|*.xls"
            PreguntaArchivo.FileName = Cia & "hrspc AGENCIA.xls"
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            End If

            If strFileName.Length <> 0 Then
                ExportaExcel(rsDatos, strFileName)
            End If

            frmVistaPrevia.LlamarReporte("Resumen de horas a exportar", dtDatos)
            frmVistaPrevia.Show(Me)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            rsDatos.Close()
        End Try
    End Sub

End Class
