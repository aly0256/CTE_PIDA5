Imports Microsoft.Reporting.WinForms
Imports Microsoft.Office.Interop

Public Class frmContratos
    Dim dtContratos As New DataTable
    Dim Origen As String
    Dim Cia As String
    Dim Contrato As String
    Dim Fecha As Date
    Public Sub New(rise As String)

        ' This call is required by the designer.
        InitializeComponent()
        Origen = rise
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmContratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtContratos = sqlExecute("SELECT cod_comp AS CIA,tipo_cont AS TIPO,nombre AS NOMBRE,contrato FROM contrato ORDER BY cod_comp,tipo_cont")
            cmbContratos.DataSource = dtContratos
            cmbContratos.ValueMember = "tipo"
            cmbContratos.Columns(3).Visible = False
            cmbContratos.Columns(0).Width.Absolute = 30
            cmbContratos.Columns(1).Width.Absolute = 30
            cmbContratos.Columns(2).StretchToFill = True

            cmbContratos.SelectedIndex = 0


            'txtFecha.Value = Date.Parse(dtFiltroPersonal.Rows(0).Item("alta"))
            txtFechaVencimiento.Enabled = False
            cmbinicio.Enabled = False
            '' descomentar esta linea 
            txtFechaVencimiento.Value = Date.Parse(dtFiltroPersonal.Rows(0).Item("alta")).AddDays(29)
            txtInicioHoy.Value = Now
            If (rbVigencia.Checked) Then
                cmbTipo.Text = "90" ' AOS - Se deja por default los 90 días
            End If
            txtFechaVencimiento.Value = Now.AddDays(90) ' AOS - Se deja por default los 90 días
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub GeneraContrato()
        Dim dtDatosCia As New DataTable
        Dim dtDetalle As New DataTable
        Dim dtTemp As New DataTable
        Dim dtListaReporteador As New DataTable
        dtListaReporteador.Columns.Add("reloj")
        Dim dtInsert As New DataTable
        dtInsert.Columns.Add("reloj")
        dtInsert.Columns.Add("fecha")
        dtInsert.Columns.Add("tipo_contrato")
        dtInsert.Columns.Add("fecha_vencimiento")
        dtInsert.Columns.Add("usuario")
        dtInsert.Columns.Add("vigencia")
        dtInsert.Columns.Add("fecha_genera")
        Dim Reporte As String
        Try
            If Contrato = "001" Then
                Reporte = DireccionReportes & "CONTRATO ADMINISTRATIVO.rdl"
            End If

            If Contrato = "002" Then
                Reporte = DireccionReportes & "CONTRATO CRUCE.rdl"
            End If

            If Contrato = "003" Then
                Reporte = DireccionReportes & "CONTRATO FORANEO.rdl"
            End If

            If Contrato = "004" Then
                Reporte = DireccionReportes & "CONTRATO LOCAL.rdl"
            End If

            If Contrato = "005" Then
                Reporte = DireccionReportes & "CONTRATO TEMPORAL.rdl"
            End If

            If Contrato = "006" Then
                Reporte = DireccionReportes & "CONTRATO MECANICO.rdl"
            End If

            If Contrato = "007" Then
                Reporte = DireccionReportes & "CONTRATO POR TIEMPO DETERMINADO-MATERNIDAD.rdl"
            End If
            'Reporte = DireccionReportes & "CONTRATO.rdl"
            Dim Mensaje As String
            Dim Mensaje1 As String
            Dim Revision As String
            Dim Vigencia As Integer = 0
            Dim Rl As String
            Dim Repre As String
            Dim path_firma_rep As String
            Dim puesto_rep As String
            Dim Fld As String
            Dim Info As String
            Dim Info1 As String
            Dim y As Integer
            Dim x As Integer
            Dim Fin_contrato As Date
            Dim dias As Integer
            Dim fecha1 As Date
            Dim fecha2 As Date

            dtDetalle.Columns.Add("CONTRATO")
            dtDetalle.Columns.Add("CONTRATO1")
            dtDetalle.Columns.Add("reloj")
            dtDetalle.Columns.Add("repre")
            dtDetalle.Columns.Add("path_firma_rep")
            dtDetalle.Columns.Add("puesto_rep")
            dtDetalle.Columns.Add("mensaje")
            dtDetalle.Columns.Add("revision")
            dtDetalle.Columns.Add("nombre")
            dtDetalle.Columns.Add("cia_nombre")
            dtDetalle.Columns.Add("representante")

            dtTemp = sqlExecute("SELECT contrato,contrato1,revision,vigencia FROM contrato WHERE tipo_cont = '" & Contrato & "' AND cod_comp = '" & Cia & "'")


            If lblAlta.Checked Then
                fecha1 = dtFiltroPersonal.Rows(x).Item("alta")
            ElseIf lblEspecifica.Checked Then
                fecha1 = txtInicioHoy.Value
            ElseIf chkApartir.Checked Then
                fecha1 = Date.Parse(dtFiltroPersonal.Rows(x).Item("alta")).AddDays(cmbinicio.SelectedValue)
            End If

            Mensaje = dtTemp.Rows(0).Item("contrato")
            Mensaje1 = dtTemp.Rows(0).Item("contrato1")
            Revision = dtTemp.Rows(0).Item("revision").ToString.Trim
            Vigencia = IIf(IsDBNull(dtTemp.Rows(0).Item("vigencia")), 0, dtTemp.Rows(0).Item("vigencia"))
            Fin_contrato = Date.Parse(fecha1).AddDays(cmbTipo.SelectedValue).AddDays(-1)


            ' fecha1 = IIf(lblAlta.Checked, dtFiltroPersonal.Rows(x).Item("alta"), txtInicioHoy.Value)
            fecha2 = txtFechaVencimiento.Value
            dias = (fecha2 - fecha1).TotalDays

            For x = 0 To dtFiltroPersonal.Rows.Count - 1
                dtDatosCia = sqlExecute("SELECT cias.nombre AS compania,rfc as rfc_cia,reg_pat,direccion AS direccion_comp,colonia AS colonia_comp,cod_postal AS cp_comp,rep_legal,puesto as rep_puesto FROM cias WHERE cod_comp = '" & dtFiltroPersonal.Rows(x).Item("cod_comp") & "'")
                Rl = dtFiltroPersonal.Rows(x).Item("reloj")
                Repre = IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("nombre_rep")), "", dtFiltroPersonal.Rows(x).Item("nombre_rep"))
                path_firma_rep = IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("path_firma_rep")), "", dtFiltroPersonal.Rows(x).Item("path_firma_rep"))
                puesto_rep = IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("puesto_rep")), "", dtFiltroPersonal.Rows(x).Item("puesto_rep"))
                Info = Mensaje
                Info1 = Mensaje1
                'horario descripción (abraham)
                Try
                    Info = Info.Replace("[horario_descripcion]", sqlExecute("select descripcion_larga from horarios where cod_hora = '" & dtFiltroPersonal.Rows(x)("cod_hora") & "'").Rows(0)("descripcion_larga"))
                    Info1 = Info1.Replace("[horario_descripcion]", sqlExecute("select descripcion_larga from horarios where cod_hora = '" & dtFiltroPersonal.Rows(x)("cod_hora") & "'").Rows(0)("descripcion_larga"))
                Catch ex As Exception
                    Info = Info.Replace("[horario_descripcion]", "[nombre_horario] (DESCRIPCION DEL HORARIO NO DISPONIBLE)")
                    Info1 = Info1.Replace("[horario_descripcion]", "[nombre_horario] (DESCRIPCION DEL HORARIO NO DISPONIBLE)")
                End Try

                Try
                    Info = Info.Replace("[sexo_letra]", sqlExecute("select * from sexo where sexo = '" & dtFiltroPersonal.Rows(x)("sexo") & "'").Rows(0)("nombre"))
                    Info1 = Info1.Replace("[sexo_letra]", sqlExecute("select * from sexo where sexo = '" & dtFiltroPersonal.Rows(x)("sexo") & "'").Rows(0)("nombre"))

                Catch ex As Exception
                    Info = Info.Replace("[sexo_letra]", "N/A")
                    Info1 = Info1.Replace("[sexo_letra]", "N/A")
                End Try
                Try
                    Info = Info.Replace("[repre]", Repre)
                    Info1 = Info1.Replace("[repre]", Repre)
                Catch ex As Exception
                    Info = Info.Replace("[repre]", "N/A")
                    Info1 = Info1.Replace("[repre]", "N/A")
                End Try

                For y = 0 To dtFiltroPersonal.Columns.Count - 1
                    Fld = dtFiltroPersonal.Columns(y).ColumnName.ToLower

                    If dtFiltroPersonal.Columns(y).DataType.Name = "DateTime" Then
                        If IsDBNull(dtFiltroPersonal.Rows(x).Item(y)) Then
                            Info = Info.Replace("[" & Fld & "]", "---")
                            Info1 = Info1.Replace("[" & Fld & "]", "---")
                        Else
                            Info = Info.Replace("[" & Fld & "]", FechaMediaLetra(dtFiltroPersonal.Rows(x).Item(y)))
                            Info1 = Info1.Replace("[" & Fld & "]", FechaMediaLetra(dtFiltroPersonal.Rows(x).Item(y)))
                        End If
                    Else
                        Info = Info.Replace("[" & Fld & "]", IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item(y)), "---", dtFiltroPersonal.Rows(x).Item(y).ToString.ToUpper))
                        Info1 = Info1.Replace("[" & Fld & "]", IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item(y)), "---", dtFiltroPersonal.Rows(x).Item(y).ToString.ToUpper))
                    End If
                Next

                For y = 0 To dtDatosCia.Columns.Count - 1
                    Fld = dtDatosCia.Columns(y).ColumnName
                    If dtDatosCia.Columns(y).DataType.Name = "DateTime" Then
                        If IsDBNull(dtDatosCia.Rows(0).Item(y)) Then
                            Info = Info.Replace("[" & Fld & "]", "---")
                            Info1 = Info1.Replace("[" & Fld & "]", "---")
                        Else
                            Info = Info.Replace("[" & Fld & "]", FechaMediaLetra(dtDatosCia.Rows(0).Item(y)))
                            Info1 = Info1.Replace("[" & Fld & "]", FechaMediaLetra(dtDatosCia.Rows(0).Item(y)))
                        End If
                    Else
                        Info = Info.Replace("[" & Fld & "]", dtDatosCia.Rows(0).Item(y).ToString.ToUpper)
                        Info1 = Info1.Replace("[" & Fld & "]", dtDatosCia.Rows(0).Item(y).ToString.ToUpper)
                    End If
                Next

                'Nombre completo NOMBRE APATERNO AMATERNO
                Try
                    Info = Info.Replace("[nombre_completo]", IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("nombre")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("nombre"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("apaterno")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("apaterno"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("amaterno")), " ", dtFiltroPersonal.Rows(x).Item("amaterno")))
                    Info1 = Info1.Replace("[nombre_completo]", IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("nombre")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("nombre"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("apaterno")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("apaterno"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("amaterno")), " ", dtFiltroPersonal.Rows(x).Item("amaterno")))
                Catch ex As Exception

                End Try

                Try
                    Info = Info.Replace("[FECHA_INI]", txtInicioHoy.Value.ToString("yyyy/MM/dd"))
                    Info1 = Info1.Replace("[FECHA_INI]", txtInicioHoy.Value.ToString("yyyy/MM/dd"))
                Catch ex As Exception

                End Try

                Try
                    Info = Info.Replace("[FECHA_FINAL]", txtInicioHoy.Value.AddDays(120).ToString("yyyy/MM/dd"))
                    Info1 = Info1.Replace("[FECHA_FINAL]", txtInicioHoy.Value.AddDays(120).ToString("yyyy/MM/dd"))
                    Info = Info.Replace("[fecha_fin]", txtInicioHoy.Value.AddDays(120).ToString("yyyy/MM/dd"))
                    Info1 = Info1.Replace("[fecha_fin]", txtInicioHoy.Value.AddDays(120).ToString("yyyy/MM/dd"))
                Catch ex As Exception

                End Try

                'edad en anios (abraham)
                Try
                    Info = Info.Replace("[edad_en_anos]", dtFiltroPersonal.Rows(x).Item("edad").ToString)
                    Info1 = Info1.Replace("[edad_en_anos]", dtFiltroPersonal.Rows(x).Item("edad").ToString)
                Catch ex As Exception
                    Info = Info.Replace("[edad_en_anos]", "N/A")
                    Info1 = Info1.Replace("[edad_en_anos]", "N/A")
                End Try

                'Sexo (completo)
                Info = Info.Replace("[sexo_comp]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "femenino", "masculino"))
                Info1 = Info1.Replace("[sexo_comp]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "femenino", "masculino"))

                '-- Estado Civil (AOS)
                Info = Info.Replace("[name_civil]", dtFiltroPersonal.Rows(x).Item("nombre_civil").ToString)
                Info1 = Info1.Replace("[name_civil]", dtFiltroPersonal.Rows(x).Item("nombre_civil").ToString)
                '-- AOS - Fecha de nacimiento
                Try
                    Info = Info.Replace("[fecha_naci]", FechaMediaLetra(dtFiltroPersonal.Rows(x).Item("fha_nac")))
                    Info1 = Info1.Replace("[fecha_naci]", FechaMediaLetra(dtFiltroPersonal.Rows(x).Item("fha_nac")))
                Catch ex As Exception
                    Info = Info.Replace("[fecha_naci]", "N/A")
                    Info1 = Info1.Replace("[fecha_naci]", "N/A")
                End Try

                '--- AOS:: CURP
                Try : Info = Info.Replace("[curp]", dtFiltroPersonal.Rows(x).Item("curp")) : Catch ex As Exception : Info = "N/A" : End Try
                Try : Info1 = Info1.Replace("[curp]", dtFiltroPersonal.Rows(x).Item("curp")) : Catch ex As Exception : Info1 = "N/A" : End Try

                '--- AOS:: RFC
                Try : Info = Info.Replace("[rfc]", dtFiltroPersonal.Rows(x).Item("rfc")) : Catch ex As Exception : Info = "N/A" : End Try
                Try : Info1 = Info1.Replace("[rfc]", dtFiltroPersonal.Rows(x).Item("rfc")) : Catch ex As Exception : Info1 = "N/A" : End Try

                '--- AOS :: Nombre del puesto
                Try : Info = Info.Replace("[PUESTO]", dtFiltroPersonal.Rows(x).Item("nombre_puesto")) : Catch ex As Exception : Info = "PUESTO NO DISPONIBLE" : End Try
                Try : Info = Info.Replace("[puesto]", dtFiltroPersonal.Rows(x).Item("nombre_puesto")) : Catch ex As Exception : Info = "PUESTO NO DISPONIBLE" : End Try
                Try : Info1 = Info1.Replace("[PUESTO]", dtFiltroPersonal.Rows(x).Item("nombre_puesto")) : Catch ex As Exception : Info = "PUESTO NO DISPONIBLE" : End Try
                Try : Info1 = Info1.Replace("[puesto]", dtFiltroPersonal.Rows(x).Item("nombre_puesto")) : Catch ex As Exception : Info = "PUESTO NO DISPONIBLE" : End Try
                'Vigencia en dias

                'Info = Info.Replace("[vigencia_dias]", dias)
                Info = Info.Replace("[vigencia_dias]", IIf(rbVigencia.Checked, cmbTipo.SelectedValue, dias))
                Info1 = Info1.Replace("[vigencia_dias]", IIf(rbVigencia.Checked, cmbTipo.SelectedValue, dias))
                '---AOS :: Nombre en letra de los dias de duracion de contrato
                If (rbVigencia.Checked) Then
                    dias = cmbTipo.SelectedValue
                End If

                Dim DiasLetra As String = ""
                Dim dtDiasLetra As DataTable = sqlExecute("select denomina from denomina where clave=" & dias, "KIOSCO")
                If (Not dtDiasLetra.Columns.Contains("Error") And dtDiasLetra.Rows.Count > 0) Then
                    Try : DiasLetra = dtDiasLetra.Rows(0).Item("denomina").ToString.Trim : Catch ex As Exception : DiasLetra = "" : End Try
                End If
                Try : Info = Info.Replace("[dduraletra]", DiasLetra) : Catch ex As Exception : Info = "N/A" : End Try
                Try : Info1 = Info1.Replace("[dduraletra]", DiasLetra) : Catch ex As Exception : Info1 = "N/A" : End Try

                'vigencia contrato (abraham)
                Try
                    Info = Info.Replace("[vigencia_contrato]", Vigencia)
                    Info1 = Info1.Replace("[vigencia_contrato]", Vigencia)
                Catch ex As Exception
                    Info = Info.Replace("[vigencia_contrato]", "N/A")
                    Info1 = Info1.Replace("[vigencia_contrato]", "N/A")
                End Try

                'fin del contrato (abraham)
                Try
                    Info = Info.Replace("[fecha_fin_contrato_letra]", IIf(rbVigencia.Checked, FechaMediaLetra(Fin_contrato), FechaMediaLetra(txtFechaVencimiento.Value)))
                    Info1 = Info1.Replace("[fecha_fin_contrato_letra]", IIf(rbVigencia.Checked, FechaMediaLetra(Fin_contrato), FechaMediaLetra(txtFechaVencimiento.Value)))
                Catch ex As Exception
                    Info = Info.Replace("[fecha_fin_contrato_letra]", "N/A")
                    Info1 = Info1.Replace("[fecha_fin_contrato_letra]", "N/A")
                End Try

                ' - AOS :: Fecha de inicio de relacion laboral en version Date (Corta) (Puede ser fecha de alta o fecha especificia) 
                Try : Info = Info.Replace("[fecha_ini_lab_vcorta]", FechaSQL(fecha1)) : Catch ex As Exception : Info = "N/A" : End Try
                Try : Info1 = Info1.Replace("[fecha_ini_lab_vcorta]", FechaSQL(fecha1)) : Catch ex As Exception : Info1 = "N/A" : End Try
                'AOS :: fecha de Inicio de Relacion laboral en versión larga (Puede ser fecha de alta o fecha especificia) 
                Try

                    Info = Info.Replace("[fecha_ini_lab_vlarga]", FechaMediaLetra(fecha1))
                    Info1 = Info1.Replace("[fecha_ini_lab_vlarga]", FechaMediaLetra(fecha1))
                Catch ex As Exception
                    Info = Info.Replace("[fecha_ini_lab_vlarga]", "N/A")
                    Info1 = Info1.Replace("[fecha_ini_lab_vlarga]", "N/A")
                End Try
                'Fecha en que se imprime el contrato(carlos)
                Try
                    Info = Info.Replace("[fecha_actual]", FechaMediaLetra(Date.Now))
                    Info1 = Info1.Replace("[fecha_actual]", FechaMediaLetra(Date.Now))
                Catch ex As Exception
                    Info = Info.Replace("[fecha_actual]", "N/A")
                    Info1 = Info1.Replace("[fecha_actual]", "N/A")
                End Try

                Dim DirecEmpl As String = ""

                'direccion completa con Colonia (abraham)
                Try
                    Info = Info.Replace("[direccion_completa]", RTrim(dtFiltroPersonal.Rows(x).Item("direccion")) & ", " & RTrim(sqlExecute("select top 1 * from colonias where cod_col = '" & dtFiltroPersonal.Rows(x).Item("cod_col") & "'").Rows(0)("nombre")))
                    Info1 = Info1.Replace("[direccion_completa]", RTrim(dtFiltroPersonal.Rows(x).Item("direccion")) & ", " & RTrim(sqlExecute("select top 1 * from colonias where cod_col = '" & dtFiltroPersonal.Rows(x).Item("cod_col") & "'").Rows(0)("nombre")))
                Catch ex As Exception
                    Info = Info.Replace("[direccion_completa]", "(DIRECCION NO DISPONIBLE)")
                    Info1 = Info1.Replace("[direccion_completa]", "(DIRECCION NO DISPONIBLE)")
                End Try

                Try
                    Info = Info.Replace("[CP]", RTrim(dtFiltroPersonal.Rows(x).Item("cp_sat")) & ", " & RTrim(sqlExecute("select top 1 * from colonias where cod_col = '" & dtFiltroPersonal.Rows(x).Item("cod_col") & "'").Rows(0)("nombre")))
                    Info1 = Info1.Replace("[CP]", RTrim(dtFiltroPersonal.Rows(x).Item("cp_sat")) & ", " & RTrim(sqlExecute("select top 1 * from colonias where cod_col = '" & dtFiltroPersonal.Rows(x).Item("cod_col") & "'").Rows(0)("nombre")))
                    Info = Info.Replace("[cp]", RTrim(dtFiltroPersonal.Rows(x).Item("cp_sat")) & ", " & RTrim(sqlExecute("select top 1 * from colonias where cod_col = '" & dtFiltroPersonal.Rows(x).Item("cod_col") & "'").Rows(0)("nombre")))
                    Info1 = Info1.Replace("[cp]", RTrim(dtFiltroPersonal.Rows(x).Item("cp_sat")) & ", " & RTrim(sqlExecute("select top 1 * from colonias where cod_col = '" & dtFiltroPersonal.Rows(x).Item("cod_col") & "'").Rows(0)("nombre")))
                Catch ex As Exception
                    Info = Info.Replace("[CP]", "(CODIGO POSTAL NO DISPONIBLE)")
                    Info1 = Info1.Replace("[CP]", "(CODIGO POSTAL NO DISPONIBLE)")
                    Info = Info.Replace("[cp]", "(CODIGO POSTAL NO DISPONIBLE)")
                    Info1 = Info1.Replace("[cp]", "(CODIGO POSTAL NO DISPONIBLE)")
                End Try



                '--- AOS:: Direccion (La colonia ya la incluye en el campo "direccion")
                Try : DirecEmpl = dtFiltroPersonal.Rows(x).Item("direccion") : Catch ex As Exception : DirecEmpl = "" : End Try
                If DirecEmpl.Trim = "" Then DirecEmpl = "DIRECCION NO DISPONIBLE"
                Try : Info = Info.Replace("[direc_empl]", DirecEmpl) : Catch ex As Exception : Info = "DIRECCION NO DISPONIBLE" : End Try
                Try : Info1 = Info1.Replace("[direc_empl]", DirecEmpl) : Catch ex As Exception : Info1 = "DIRECCION NO DISPONIBLE" : End Try
                'Definidos por sexo
                Info = Info.Replace("[al_ala]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "a la", "al"))
                Info1 = Info1.Replace("[al_ala]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "a la", "al"))
                Info = Info.Replace("[el_la]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "la", "el"))
                Info1 = Info1.Replace("[el_la]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "la", "el"))
                Info = Info.Replace("[sr(a)]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "señora (ita)", "señor"))
                Info1 = Info1.Replace("[sr(a)]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "señora (ita)", "señor"))
                'Sueldo en letra
                Info = Info.Replace("[sactual_letra]", ConvNvo(dtFiltroPersonal.Rows(x).Item("sactual").ToString))
                Info1 = Info1.Replace("[sactual_letra]", ConvNvo(dtFiltroPersonal.Rows(x).Item("sactual").ToString))

                Try : Info = Info.Replace("[sactual]", dtFiltroPersonal.Rows(x).Item("sactual")) : Catch ex As Exception : Info = "N/A" : End Try
                Try : Info1 = Info1.Replace("[sactual]", dtFiltroPersonal.Rows(x).Item("sactual")) : Catch ex As Exception : Info1 = "N/A" : End Try
                'salario mensual (abraham)

                Try
                    If dtFiltroPersonal.Rows(x).Item("cod_tipo").ToString.Trim.ToUpper = "A" Then
                        Info = Info.Replace("[salario_mensual]", String.Format("{0:C2}", Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual") * 30)))
                        Info1 = Info1.Replace("[salario_mensual]", String.Format("{0:C2}", Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual") * 30)))
                        Info = Info.Replace("[salario_mensual_letra]", ConvNvo(Math.Round(Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual")) * 30, 2)))
                        Info1 = Info1.Replace("[salario_mensual_letra]", ConvNvo(Math.Round(Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual")) * 30, 2)))
                    Else
                        Info = Info.Replace("[salario_mensual]", String.Format("{0:C2}", Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual") * 30.4)))
                        Info1 = Info1.Replace("[salario_mensual]", String.Format("{0:C2}", Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual") * 30.4)))
                        Info = Info.Replace("[salario_mensual_letra]", ConvNvo(Math.Round(Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual")) * 30.4, 2)))
                        Info1 = Info1.Replace("[salario_mensual_letra]", ConvNvo(Math.Round(Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual")) * 30.4, 2)))
                    End If
                Catch ex As Exception
                    Info = Info.Replace("[salario_mensual]", String.Format("{0:C2}", Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual") * 30.4)))
                    Info1 = Info1.Replace("[salario_mensual]", String.Format("{0:C2}", Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual") * 30.4)))
                    Info = Info.Replace("[salario_mensual_letra]", ConvNvo(Math.Round(Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual")) * 30.4, 2)))
                    Info1 = Info1.Replace("[salario_mensual_letra]", ConvNvo(Math.Round(Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual")) * 30.4, 2)))
                End Try


                'Horarios
                dtTemp = sqlExecute("SELECT entra,sale FROM dias WHERE cod_hora = '" & dtFiltroPersonal.Rows(x).Item("cod_hora") & "' AND cod_comp = '" & dtFiltroPersonal.Rows(x).Item("cod_comp") & "' AND descanso = 0")
                If dtTemp.Rows.Count = 0 Then
                    Info = Info.Replace("[hora_entrada]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Info1 = Info1.Replace("[hora_entrada]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Info = Info.Replace("[hora_salida]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Info1 = Info1.Replace("[hora_salida]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                Else
                    Info = Info.Replace("[hora_entrada]", dtTemp.Rows(0).Item("entra"))
                    Info1 = Info1.Replace("[hora_entrada]", dtTemp.Rows(0).Item("entra"))
                    Info = Info.Replace("[hora_salida]", dtTemp.Rows(0).Item("sale"))
                    Info1 = Info1.Replace("[hora_salida]", dtTemp.Rows(0).Item("sale"))
                End If

                'Jornada diurna
                dtTemp = sqlExecute("SELECT entra,sale FROM dias WHERE cod_hora = '1' AND cod_comp = '" & dtFiltroPersonal.Rows(x).Item("cod_comp") & "' AND descanso = 0")
                If dtTemp.Rows.Count = 0 Then
                    Info = Info.Replace("[entrada_h1]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Info1 = Info1.Replace("[entrada_h1]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Info = Info.Replace("[salida_h1]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Info1 = Info1.Replace("[salida_h1]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                Else
                    Info = Info.Replace("[entrada_h1]", dtTemp.Rows(0).Item("entra"))
                    Info1 = Info1.Replace("[entrada_h1]", dtTemp.Rows(0).Item("entra"))
                    Info = Info.Replace("[salida_h1]", dtTemp.Rows(0).Item("sale"))
                    Info1 = Info1.Replace("[salida_h1]", dtTemp.Rows(0).Item("sale"))
                End If

                'Jornada mixta
                dtTemp = sqlExecute("SELECT entra,sale FROM dias WHERE cod_hora = '2' AND cod_comp = '" & dtFiltroPersonal.Rows(x).Item("cod_comp") & "' AND descanso = 0")
                If dtTemp.Rows.Count = 0 Then
                    Info = Info.Replace("[entrada_h2]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Info1 = Info1.Replace("[entrada_h2]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Info = Info.Replace("[salida_h2]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Info1 = Info1.Replace("[salida_h2]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                Else
                    Info = Info.Replace("[entrada_h2]", dtTemp.Rows(0).Item("entra"))
                    Info1 = Info1.Replace("[entrada_h2]", dtTemp.Rows(0).Item("entra"))
                    Info = Info.Replace("[salida_h2]", dtTemp.Rows(0).Item("sale"))
                    Info1 = Info1.Replace("[salida_h2]", dtTemp.Rows(0).Item("sale"))
                End If

                Info = Info.Replace("[fecha_hoy]", FechaMediaLetra(Now))
                Info1 = Info1.Replace("[fecha_hoy]", FechaMediaLetra(Now))
                Info = Info.Replace("[fecha_firma]", FechaMediaLetra(fecha1))
                Info1 = Info1.Replace("[fecha_firma]", FechaMediaLetra(fecha1))
                Info = Info.Replace("[alta_letra]", FechaMediaLetra(dtFiltroPersonal.Rows(x).Item("alta")))
                Info1 = Info1.Replace("[alta_letra]", FechaMediaLetra(dtFiltroPersonal.Rows(x).Item("alta")))
                Info = Info.Replace("[fecha_renovacion]", FechaMediaLetra(Date.Parse(dtFiltroPersonal.Rows(x).Item("alta")).AddDays(30)))
                Info1 = Info1.Replace("[fecha_renovacion]", FechaMediaLetra(Date.Parse(dtFiltroPersonal.Rows(x).Item("alta")).AddDays(30)))

                Dim dtExiste As DataTable = sqlExecute("select * from contratos_generados where reloj='" & dtFiltroPersonal.Rows(x).Item("reloj") & "' and fecha='" & FechaSQL(fecha1) & "' and tipo_contrato='" & Contrato & "'")
                'If dtExiste.Rows.Count = 0 Then
                '    dtInsert.Rows.Add({dtFiltroPersonal.Rows(x).Item("reloj"), FechaSQL(fecha1), Contrato, IIf(Vigencia = 0, "NULL", IIf(rbVigencia.Checked, FechaSQL(Fin_contrato), FechaSQL(txtFechaVencimiento.Value))), Usuario, IIf(rbVigencia.Checked, cmbTipo.Text, ""), FechaSQL(Now)})

                '    dtDetalle.Rows.Add({Rl, Repre, path_firma_rep, puesto_rep, Info, Revision, IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("nombre")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("nombre"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("apaterno")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("apaterno"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("amaterno")), " ", dtFiltroPersonal.Rows(x).Item("amaterno")), IIf(IsDBNull(dtDatosCia.Rows(0)("compania")), " ", dtDatosCia.Rows(0)("compania")), IIf(IsDBNull(dtDatosCia.Rows(0)("rep_legal")), " ", dtDatosCia.Rows(0)("rep_legal"))})
                'Else
                sqlExecute("DELETE FROM contratos_generados where reloj='" & dtFiltroPersonal.Rows(x).Item("reloj") & "' AND fecha='" & FechaSQL(fecha1) & "' AND tipo_contrato='" & Contrato & "'")
                dtInsert.Rows.Add({dtFiltroPersonal.Rows(x).Item("reloj"), FechaSQL(fecha1), Contrato, IIf(Vigencia = 0, "NULL", IIf(rbVigencia.Checked, FechaSQL(Fin_contrato), FechaSQL(txtFechaVencimiento.Value))), Usuario, IIf(rbVigencia.Checked, cmbTipo.Text, ""), FechaSQL(Now)})

                dtDetalle.Rows.Add({Info, Info1, path_firma_rep, puesto_rep, Info, Revision,
                                    IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("nombre")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("nombre"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("apaterno")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("apaterno"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("amaterno")), " ", dtFiltroPersonal.Rows(x).Item("amaterno")),
                                    IIf(IsDBNull(dtDatosCia.Rows(0)("compania")), " ", dtDatosCia.Rows(0)("compania"))})

                'dtDetalle.Rows.Add({Info1, Repre, path_firma_rep, puesto_rep, Info1, Revision,
                '                    IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("nombre")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("nombre"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("apaterno")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("apaterno"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("amaterno")), " ", dtFiltroPersonal.Rows(x).Item("amaterno")),
                '                    IIf(IsDBNull(dtDatosCia.Rows(0)("compania")), " ", dtDatosCia.Rows(0)("compania"))})
                'End If

            Next
            Dim cadena As String
            If dtInsert.Rows.Count >= 10 Then
                If MessageBox.Show("Se generarán " & dtInsert.Rows.Count & " contratos." & vbCrLf & "¿Es correcto?", "Contratos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    For Each dr As DataRow In dtInsert.Rows

                        cadena = "INSERT INTO contratos_generados (reloj,fecha,tipo_contrato,fecha_vencimiento,usuario,vigencia,fecha_genera) VALUES (" & _
                                "@reloj,@fecha,@tipo_contrato,@fha_vencimiento,@usuario,@vigencia,@fcha_genera)"
                        cadena = cadena.Replace("@reloj", "'" & dr("reloj") & "'")
                        cadena = cadena.Replace("@fecha", "'" & FechaSQL(dr("fecha")) & "'")
                        cadena = cadena.Replace("@tipo_contrato", "'" & dr("tipo_contrato") & "'")
                        cadena = cadena.Replace("@fha_vencimiento", "'" & FechaSQL(dr("fecha_vencimiento")) & "'")
                        cadena = cadena.Replace("@usuario", "'" & dr("usuario") & "'")
                        cadena = cadena.Replace("@vigencia", "'" & dr("vigencia") & "'")
                        cadena = cadena.Replace("@fcha_genera", "'" & dr("fecha_genera") & "'")
                        sqlExecute(cadena)
                    Next
                End If
            ElseIf dtInsert.Rows.Count > 0 Then
                For Each dr As DataRow In dtInsert.Rows

                    cadena = "INSERT INTO contratos_generados (reloj,fecha,tipo_contrato,fecha_vencimiento,usuario,vigencia,fecha_genera) VALUES (" & _
                            "@reloj,@fecha,@tipo_contrato,@fha_vencimiento,@usuario,@vigencia,@fcha_genera)"
                    cadena = cadena.Replace("@reloj", "'" & dr("reloj") & "'")
                    cadena = cadena.Replace("@fecha", "'" & FechaSQL(dr("fecha")) & "'")
                    cadena = cadena.Replace("@tipo_contrato", "'" & dr("tipo_contrato") & "'")
                    If dr("tipo_contrato") = "001" Then
                        cadena = cadena.Replace("@fha_vencimiento", "null")
                    End If
                    If dr("tipo_contrato") = "002" Then
                        cadena = cadena.Replace("@fha_vencimiento", "null")
                    End If

                    If dr("tipo_contrato") = "003" Then
                        cadena = cadena.Replace("@fha_vencimiento", "null")
                    End If

                    If dr("tipo_contrato") = "004" Then
                        cadena = cadena.Replace("@fha_vencimiento", "null")
                    End If

                    If dr("tipo_contrato") = "005" Then
                        cadena = cadena.Replace("@fha_vencimiento", "null")
                    End If

                    If dr("tipo_contrato") = "006" Then
                        cadena = cadena.Replace("@fha_vencimiento", "null")
                    End If

                    If dr("tipo_contrato") = "007" Then
                        cadena = cadena.Replace("@fha_vencimiento", "null")
                    End If

                    If dr("tipo_contrato") = "008" Then
                        cadena = cadena.Replace("@fha_vencimiento", "null")
                    End If

                    'cadena = cadena.Replace("@fha_vencimiento", "'" & FechaSQL(dr("fecha_vencimiento")) & "'")


                    cadena = cadena.Replace("@usuario", "'" & dr("usuario") & "'")

                    If dr("tipo_contrato") = "001" Then
                        cadena = cadena.Replace("@vigencia", "null")
                    End If
                    If dr("tipo_contrato") = "002" Then
                        cadena = cadena.Replace("@vigencia", "null")
                        'cadena = cadena.Replace("@vigencia", "'" & dr("vigencia") & "'")
                    End If

                    If dr("tipo_contrato") = "003" Then
                        cadena = cadena.Replace("@vigencia", "null")
                    End If

                    If dr("tipo_contrato") = "004" Then
                        cadena = cadena.Replace("@vigencia", "null")
                    End If

                    If dr("tipo_contrato") = "005" Then
                        cadena = cadena.Replace("@vigencia", "null")
                    End If

                    If dr("tipo_contrato") = "006" Then
                        cadena = cadena.Replace("@vigencia", "null")
                    End If

                    If dr("tipo_contrato") = "007" Then
                        cadena = cadena.Replace("@vigencia", "null")
                    End If

                    If dr("tipo_contrato") = "008" Then
                        cadena = cadena.Replace("@vigencia", "null")
                    End If

                    cadena = cadena.Replace("@fcha_genera", "'" & dr("fecha_genera") & "'")
                    sqlExecute(cadena)
                Next

            End If

            'If dtListaReporteador.Rows.Count > 0 Then
            '    Dim mystring = ""
            '    For Each dr As DataRow In dtListaReporteador.Rows
            '        mystring &= dr.Item(0).ToString & vbCrLf
            '    Next

            '    MessageBox.Show("Este tipo de contrato ya se ha generado en la misma fecha para los siguientes empleados. Favor de verificar." & vbCrLf & "" & mystring & "", "Contratos duplicados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
            If dtInsert.Rows.Count <> 0 Then
                'Limpiar el ReportViewer, por si hubiera algún frmVistaPrevia.vwrReportes cargado
                frmVistaPrevia.vwrReportes.Clear()
                'Indicar que se ejecutarán frmVistaPrevia.vwrReportess de forma local (no desde servidor SSRS)
                frmVistaPrevia.vwrReportes.ProcessingMode = ProcessingMode.Local
                frmVistaPrevia.vwrReportes.LocalReport.ReportPath = Reporte
                frmVistaPrevia.vwrReportes.LocalReport.DataSources.Clear()
                frmVistaPrevia.vwrReportes.LocalReport.DataSources.Add(New ReportDataSource("Datos", dtDetalle))

                frmVistaPrevia.vwrReportes.Dock = DockStyle.Fill
                frmVistaPrevia.vwrReportes.Visible = True

                frmVistaPrevia.vwrReportes.LocalReport.EnableExternalImages = True
                frmVistaPrevia.vwrReportes.RefreshReport()
                frmVistaPrevia.ShowDialog()
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Application.DoEvents()
        End Try

    End Sub

    Private Sub GeneraContratoWord()
        'Contrato exportado directamente a Word, a través de un archivo  
        'plantilla al editar/agregar el contrato en el catálogo

        Dim dtDatosCia As New DataTable
        Dim dtDetalle As New DataTable
        Dim dtTemp As New DataTable
        Dim dtListaReporteador As New DataTable
        Dim dtFields As New DataTable

        Dim SourceFN As String
        Dim Destination As String = ""

        dtListaReporteador.Columns.Add("reloj")
        Dim dtInsert As New DataTable
        dtInsert.Columns.Add("reloj")
        dtInsert.Columns.Add("fecha")
        dtInsert.Columns.Add("tipo_contrato")
        dtInsert.Columns.Add("fecha_vencimiento")
        dtInsert.Columns.Add("usuario")
        dtInsert.Columns.Add("vigencia")
        dtInsert.Columns.Add("fecha_genera")

        dtFields.Columns.Add("referencia")
        dtFields.Columns.Add("valor")
        Try
            Dim Reporte As String = DireccionReportes & "Contrato.rdl"
            Dim Mensaje As String
            Dim Revision As String
            Dim Vigencia As Integer = 0
            Dim Rl As String
            Dim Repre As String
            Dim path_firma_rep As String
            Dim puesto_rep As String
            Dim Fld As String
            Dim Info As String
            Dim y As Integer
            Dim x As Integer
            Dim Fin_contrato As Date
            Dim dias As Integer
            Dim fecha1 As Date
            Dim fecha2 As Date

            dtDetalle.Columns.Add("reloj")
            dtDetalle.Columns.Add("repre")
            dtDetalle.Columns.Add("path_firma_rep")
            dtDetalle.Columns.Add("puesto_rep")
            dtDetalle.Columns.Add("mensaje")
            dtDetalle.Columns.Add("revision")
            dtDetalle.Columns.Add("nombre")
            dtDetalle.Columns.Add("cia_nombre")
            dtDetalle.Columns.Add("representante")

            If dtFiltroPersonal.Rows.Count > 10 Then
                If MessageBox.Show("Se generarán " & dtFiltroPersonal.Rows.Count & " contratos." & vbCrLf & "¿Es correcto?", "Contratos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If

            dtTemp = sqlExecute("SELECT contrato,revision,vigencia FROM contrato WHERE tipo_cont = '" & Contrato & "' AND cod_comp = '" & Cia & "'")


            If lblAlta.Checked Then
                fecha1 = dtFiltroPersonal.Rows(x).Item("alta")
            ElseIf lblEspecifica.Checked Then
                fecha1 = txtInicioHoy.Value
            ElseIf chkApartir.Checked Then
                fecha1 = Date.Parse(dtFiltroPersonal.Rows(x).Item("alta")).AddDays(cmbinicio.SelectedValue)
            End If

            Mensaje = dtTemp.Rows(0).Item("contrato")
            Revision = dtTemp.Rows(0).Item("revision").ToString.Trim
            Vigencia = IIf(IsDBNull(dtTemp.Rows(0).Item("vigencia")), 0, dtTemp.Rows(0).Item("vigencia"))
            Fin_contrato = Date.Parse(fecha1).AddDays(cmbTipo.SelectedValue).AddDays(-1)


            ' fecha1 = IIf(lblAlta.Checked, dtFiltroPersonal.Rows(x).Item("alta"), txtInicioHoy.Value)
            fecha2 = txtFechaVencimiento.Value
            dias = (fecha2 - fecha1).TotalDays

            Dim SF As New SaveFileDialog
            'Dim Reporte As String = SRep

            SF.FileName = "Contrato " & Cia & Contrato & ".docx"
            SourceFN = DireccionReportes & "Contrato " & Cia & Contrato & ".docx"

            If Not System.IO.File.Exists(SourceFN) Then
                MessageBox.Show("Este contrato no está preparado para ser enviado directamente a Word, requiere el archivo base " & "Contrato " & Cia & Contrato & ".docx" & _
                                vbCrLf & vbCrLf & "El contrato aún puede ser enviado a Word, generando el reporte y después elegir <Exportar>.", "Contratos", _
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            SF.Filter = "Word file (*.docx)|*.docx"
            SF.FilterIndex = 1

            Dim FD As New FolderBrowserDialog
            FD.RootFolder = Environment.SpecialFolder.MyComputer
            Dim resultado As Integer = SF.ShowDialog()
            ' Dim resultado As Integer = FD.ShowDialog() 'CAMBIO A SAVE FILE DIALOG
            If resultado = DialogResult.OK Then
                Dim wapp As New Word.Application
                Dim wdoc As Word.Document = Nothing
                Dim save_changes As Object = True

                ' wapp = New Word.Application
                'wapp.Visible = True

                For x = 0 To dtFiltroPersonal.Rows.Count - 1
                    Application.DoEvents()
                    dtFields.Clear()

                    dtDatosCia = sqlExecute("SELECT cias.nombre AS compania,rfc as rfc_cia,reg_pat,direccion AS direccion_comp,colonia AS colonia_comp,cod_postal AS cp_comp,rep_legal,puesto as rep_puesto FROM cias WHERE cod_comp = '" & dtFiltroPersonal.Rows(x).Item("cod_comp") & "'")
                    Rl = dtFiltroPersonal.Rows(x).Item("reloj")
                    Repre = IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("nombre_rep")), "", dtFiltroPersonal.Rows(x).Item("nombre_rep"))
                    path_firma_rep = IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("path_firma_rep")), "", dtFiltroPersonal.Rows(x).Item("path_firma_rep"))
                    puesto_rep = IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("puesto_rep")), "", dtFiltroPersonal.Rows(x).Item("puesto_rep"))
                    Info = Mensaje

                    'horario descripción (abraham)
                    Try
                        CamposReferencia(dtFields, "[horario_descripcion]", sqlExecute("select descripcion_larga from horarios where cod_hora = '" & dtFiltroPersonal.Rows(x)("cod_hora") & "'").Rows(0)("descripcion_larga"))
                    Catch ex As Exception
                        CamposReferencia(dtFields, "[horario_descripcion]", "[nombre_horario] (DESCRIPCION DEL HORARIO NO DISPONIBLE)")
                    End Try
                    Try
                        CamposReferencia(dtFields, "[FECHA_INI]", txtInicioHoy.Value.ToString("yyyy/MM/dd"))
                    Catch ex As Exception
                        CamposReferencia(dtFields, "[FECHA_INI]", "FECHA DE INICIO NO DISPONIBLE")
                    End Try
                    Try
                        CamposReferencia(dtFields, "[FECHA_FIN]", txtInicioHoy.Value.AddDays(120).ToString("yyyy/MM/dd"))
                    Catch ex As Exception
                        CamposReferencia(dtFields, "[FECHA_FIN]", "FECHA FINAL NO DISPONIBLE")
                    End Try
            Try
                CamposReferencia(dtFields, "[sexo_letra]", sqlExecute("select * from sexo where sexo = '" & dtFiltroPersonal.Rows(x)("sexo") & "'").Rows(0)("nombre"))
            Catch ex As Exception
                CamposReferencia(dtFields, "[sexo_letra]", "N/A")
            End Try
            Try
                CamposReferencia(dtFields, "[repre]", Repre)
            Catch ex As Exception
                CamposReferencia(dtFields, "[repre]", "N/A")
            End Try

            For y = 0 To dtFiltroPersonal.Columns.Count - 1
                Fld = dtFiltroPersonal.Columns(y).ColumnName.ToLower

                If dtFiltroPersonal.Columns(y).DataType.Name = "DateTime" Then
                    If IsDBNull(dtFiltroPersonal.Rows(x).Item(y)) Then
                        CamposReferencia(dtFields, "[" & Fld & "]", "---")
                    Else
                        CamposReferencia(dtFields, "[" & Fld & "]", FechaMediaLetra(dtFiltroPersonal.Rows(x).Item(y)))
                    End If
                Else
                    CamposReferencia(dtFields, "[" & Fld & "]", IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item(y)), "---", dtFiltroPersonal.Rows(x).Item(y).ToString.ToUpper))
                End If
            Next

            For y = 0 To dtDatosCia.Columns.Count - 1
                Fld = dtDatosCia.Columns(y).ColumnName
                If dtDatosCia.Columns(y).DataType.Name = "DateTime" Then
                    If IsDBNull(dtDatosCia.Rows(0).Item(y)) Then
                        CamposReferencia(dtFields, "[" & Fld & "]", "---")
                    Else
                        CamposReferencia(dtFields, "[" & Fld & "]", FechaMediaLetra(dtDatosCia.Rows(0).Item(y)))
                    End If
                Else
                    CamposReferencia(dtFields, "[" & Fld & "]", dtDatosCia.Rows(0).Item(y).ToString.ToUpper)
                End If
            Next

            'Nombre completo NOMBRE APATERNO AMATERNO
            Try
                CamposReferencia(dtFields, "[nombre_completo]", IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("nombre")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("nombre"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("apaterno")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("apaterno"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("amaterno")), " ", dtFiltroPersonal.Rows(x).Item("amaterno")))
            Catch ex As Exception

            End Try


            'edad en anios (abraham)
            Try
                CamposReferencia(dtFields, "[edad_en_anos]", dtFiltroPersonal.Rows(x).Item("edad").ToString)
            Catch ex As Exception
                CamposReferencia(dtFields, "[edad_en_anos]", "N/A")
            End Try

            'Sexo (completo)
            CamposReferencia(dtFields, "[sexo_comp]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "Femenino", "Masculino"))

            '-- Estado Civil (AOS)
            CamposReferencia(dtFields, "[name_civil]", dtFiltroPersonal.Rows(x).Item("nombre_civil").ToString)

            '-- AOS - Fecha de nacimiento
            Try
                CamposReferencia(dtFields, "[fecha_naci]", FechaMediaLetra(dtFiltroPersonal.Rows(x).Item("fha_nac")))
            Catch ex As Exception
                CamposReferencia(dtFields, "[fecha_naci]", "N/A")
            End Try

            '--- AOS:: CURP
            Try : CamposReferencia(dtFields, "[curp]", dtFiltroPersonal.Rows(x).Item("curp")) : Catch ex As Exception : Info = "N/A" : End Try


            Try : CamposReferencia(dtFields, "[CP]", dtFiltroPersonal.Rows(x).Item("cp_sat")) : Catch ex As Exception : Info = "N/A" : End Try


            '--- AOS:: RFC
            Try : CamposReferencia(dtFields, "[rfc]", dtFiltroPersonal.Rows(x).Item("rfc")) : Catch ex As Exception : Info = "N/A" : End Try

            '--- AOS :: Nombre del puesto
            Try : CamposReferencia(dtFields, "[nombre_puesto_empl]", dtFiltroPersonal.Rows(x).Item("nombre_puesto")) : Catch ex As Exception : Info = "PUESTO NO DISPONIBLE" : End Try

            'Vigencia en dias

            'ReplaceAllInWord(wapp,"[vigencia_dias]", dias)
            CamposReferencia(dtFields, "[vigencia_dias]", IIf(rbVigencia.Checked, cmbTipo.SelectedValue, dias))

            '---AOS :: Nombre en letra de los dias de duracion de contrato
            If (rbVigencia.Checked) Then
                dias = cmbTipo.SelectedValue
            End If

            Dim DiasLetra As String = ""
            Dim dtDiasLetra As DataTable = sqlExecute("select denomina from denomina where clave=" & dias, "KIOSCO")
            If (Not dtDiasLetra.Columns.Contains("Error") And dtDiasLetra.Rows.Count > 0) Then
                Try : DiasLetra = dtDiasLetra.Rows(0).Item("denomina").ToString.Trim : Catch ex As Exception : DiasLetra = "" : End Try
            End If
            Try : CamposReferencia(dtFields, "[dduraletra]", DiasLetra) : Catch ex As Exception : Info = "N/A" : End Try

            'vigencia contrato (abraham)
            Try
                CamposReferencia(dtFields, "[vigencia_contrato]", Vigencia)
            Catch ex As Exception
                CamposReferencia(dtFields, "[vigencia_contrato]", "N/A")
            End Try

            'fin del contrato (abraham)
            Try
                CamposReferencia(dtFields, "[fecha_fin_contrato_letra]", IIf(rbVigencia.Checked, FechaMediaLetra(Fin_contrato), FechaMediaLetra(txtFechaVencimiento.Value)))
            Catch ex As Exception
                CamposReferencia(dtFields, "[fecha_fin_contrato_letra]", "N/A")
            End Try

            ' - AOS :: Fecha de inicio de relacion laboral en version Date (Corta) (Puede ser fecha de alta o fecha especificia) 
            Try : CamposReferencia(dtFields, "[fecha_ini_lab_vcorta]", FechaSQL(fecha1)) : Catch ex As Exception : Info = "N/A" : End Try

            'AOS :: fecha de Inicio de Relacion laboral en versión larga (Puede ser fecha de alta o fecha especificia) 
            Try

                CamposReferencia(dtFields, "[fecha_ini_lab_vlarga]", FechaMediaLetra(fecha1))
            Catch ex As Exception
                CamposReferencia(dtFields, "[fecha_ini_lab_vlarga]", "N/A")
            End Try
            'Fecha en que se imprime el contrato(carlos)
            Try
                CamposReferencia(dtFields, "[fecha_actual]", FechaMediaLetra(Date.Now))
            Catch ex As Exception
                CamposReferencia(dtFields, "[fecha_actual]", "N/A")
            End Try

            Dim DirecEmpl As String = ""

            'direccion completa con Colonia (abraham)
            Try
                CamposReferencia(dtFields, "[direccion_completa]", RTrim(dtFiltroPersonal.Rows(x).Item("direccion")) & ", " & RTrim(sqlExecute("select top 1 * from colonias where cod_col = '" & dtFiltroPersonal.Rows(x).Item("cod_col") & "'").Rows(0)("nombre")))
            Catch ex As Exception
                CamposReferencia(dtFields, "[direccion_completa]", "(DIRECCION NO DISPONIBLE)")
            End Try


            '--- AOS:: Direccion (La colonia ya la incluye en el campo "direccion")
            Try : DirecEmpl = dtFiltroPersonal.Rows(x).Item("direccion") : Catch ex As Exception : DirecEmpl = "" : End Try
            If DirecEmpl.Trim = "" Then DirecEmpl = "DIRECCION NO DISPONIBLE"
            Try : CamposReferencia(dtFields, "[direc_empl]", DirecEmpl) : Catch ex As Exception : Info = "DIRECCION NO DISPONIBLE" : End Try

            'Definidos por sexo
            CamposReferencia(dtFields, "[al_ala]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "A LA", "AL"))
            CamposReferencia(dtFields, "[el_la]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "LA", "EL"))
            CamposReferencia(dtFields, "[sr(a)]", IIf(dtFiltroPersonal.Rows(x).Item("sexo").ToString = "F", "SEÑORA (ITA)", "SEÑOR"))

            'Sueldo en letra
            CamposReferencia(dtFields, "[sactual_letra]", ConvNvo(dtFiltroPersonal.Rows(x).Item("sactual").ToString))
            'salario mensual (abraham)

            Try
                If dtFiltroPersonal.Rows(x).Item("cod_tipo").ToString.Trim.ToUpper = "A" Then
                    CamposReferencia(dtFields, "[salario_mensual]", String.Format("{0:C2}", Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual") * 30)))
                    CamposReferencia(dtFields, "[salario_mensual_letra]", ConvNvo(Math.Round(Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual")) * 30, 2)))
                Else
                    CamposReferencia(dtFields, "[salario_mensual]", String.Format("{0:C2}", Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual") * 30.4)))
                    CamposReferencia(dtFields, "[salario_mensual_letra]", ConvNvo(Math.Round(Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual")) * 30.4, 2)))
                End If
            Catch ex As Exception
                CamposReferencia(dtFields, "[salario_mensual]", String.Format("{0:C2}", Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual") * 30.4)))
                CamposReferencia(dtFields, "[salario_mensual_letra]", ConvNvo(Math.Round(Double.Parse(dtFiltroPersonal.Rows(x).Item("sactual")) * 30.4, 2)))
            End Try


            'Horarios
            dtTemp = sqlExecute("SELECT entra,sale FROM dias WHERE cod_hora = '" & dtFiltroPersonal.Rows(x).Item("cod_hora") & "' AND cod_comp = '" & dtFiltroPersonal.Rows(x).Item("cod_comp") & "' AND descanso = 0")
            If dtTemp.Rows.Count = 0 Then
                CamposReferencia(dtFields, "[hora_entrada]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                CamposReferencia(dtFields, "[hora_salida]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            Else
                CamposReferencia(dtFields, "[hora_entrada]", dtTemp.Rows(0).Item("entra"))
                CamposReferencia(dtFields, "[hora_salida]", dtTemp.Rows(0).Item("sale"))
            End If

            'Jornada diurna
            dtTemp = sqlExecute("SELECT entra,sale FROM dias WHERE cod_hora = '1' AND cod_comp = '" & dtFiltroPersonal.Rows(x).Item("cod_comp") & "' AND descanso = 0")
            If dtTemp.Rows.Count = 0 Then
                CamposReferencia(dtFields, "[entrada_h1]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                CamposReferencia(dtFields, "[salida_h1]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            Else
                CamposReferencia(dtFields, "[entrada_h1]", dtTemp.Rows(0).Item("entra"))
                CamposReferencia(dtFields, "[salida_h1]", dtTemp.Rows(0).Item("sale"))
            End If

            'Jornada mixta
            dtTemp = sqlExecute("SELECT entra,sale FROM dias WHERE cod_hora = '2' AND cod_comp = '" & dtFiltroPersonal.Rows(x).Item("cod_comp") & "' AND descanso = 0")
            If dtTemp.Rows.Count = 0 Then
                CamposReferencia(dtFields, "[entrada_h2]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                CamposReferencia(dtFields, "[salida_h2]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            Else
                CamposReferencia(dtFields, "[entrada_h2]", dtTemp.Rows(0).Item("entra"))
                CamposReferencia(dtFields, "[salida_h2]", dtTemp.Rows(0).Item("sale"))
            End If

            CamposReferencia(dtFields, "[fecha_hoy]", FechaMediaLetra(Now))
            CamposReferencia(dtFields, "[fecha_firma]", FechaMediaLetra(fecha1))
            CamposReferencia(dtFields, "[alta_letra]", FechaMediaLetra(dtFiltroPersonal.Rows(x).Item("alta")))
            CamposReferencia(dtFields, "[fecha_renovacion]", FechaMediaLetra(Date.Parse(dtFiltroPersonal.Rows(x).Item("alta")).AddDays(30)))


            Dim dtExiste As DataTable = sqlExecute("select * from contratos_generados where reloj='" & dtFiltroPersonal.Rows(x).Item("reloj") & "' and fecha='" & FechaSQL(fecha1) & "' and tipo_contrato='" & Contrato & "'")
            If dtExiste.Rows.Count = 0 Then
                dtInsert.Rows.Add({dtFiltroPersonal.Rows(x).Item("reloj"), FechaSQL(fecha1), Contrato, IIf(Vigencia = 0, "NULL", IIf(rbVigencia.Checked, FechaSQL(Fin_contrato), FechaSQL(txtFechaVencimiento.Value))), Usuario, IIf(rbVigencia.Checked, cmbTipo.Text, ""), FechaSQL(Now)})

                dtDetalle.Rows.Add({Rl, Repre, path_firma_rep, puesto_rep, Info, Revision, IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("nombre")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("nombre"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("apaterno")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("apaterno"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("amaterno")), " ", dtFiltroPersonal.Rows(x).Item("amaterno")), IIf(IsDBNull(dtDatosCia.Rows(0)("compania")), " ", dtDatosCia.Rows(0)("compania")), IIf(IsDBNull(dtDatosCia.Rows(0)("rep_legal")), " ", dtDatosCia.Rows(0)("rep_legal"))})
            Else
                sqlExecute("DELETE FROM contratos_generados where reloj='" & dtFiltroPersonal.Rows(x).Item("reloj") & "' AND fecha='" & FechaSQL(fecha1) & "' AND tipo_contrato='" & Contrato & "'")
                dtInsert.Rows.Add({dtFiltroPersonal.Rows(x).Item("reloj"), FechaSQL(fecha1), Contrato, IIf(Vigencia = 0, "NULL", IIf(rbVigencia.Checked, FechaSQL(Fin_contrato), FechaSQL(txtFechaVencimiento.Value))), Usuario, IIf(rbVigencia.Checked, cmbTipo.Text, ""), FechaSQL(Now)})

                dtDetalle.Rows.Add({Rl, Repre, path_firma_rep, puesto_rep, Info, Revision, IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("nombre")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("nombre"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("apaterno")), " ", RTrim(dtFiltroPersonal.Rows(x).Item("apaterno"))) & " " & IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("amaterno")), " ", dtFiltroPersonal.Rows(x).Item("amaterno")), IIf(IsDBNull(dtDatosCia.Rows(0)("compania")), " ", dtDatosCia.Rows(0)("compania")), IIf(IsDBNull(dtDatosCia.Rows(0)("rep_legal")), " ", dtDatosCia.Rows(0)("rep_legal"))})
            End If

            CamposReferencia(dtFields, "[representante]", Repre)


            'Nombre del archivo Word, considerando contrato por compañía
            Destination = SF.FileName.Replace(".docx", "-" & Rl & ".docx")
            'System.IO.File.Copy(SourceFN, Destination, True)

            '                    wdoc = wapp.Documents.Open(Destination)
            wdoc = wapp.Documents.Open(SourceFN)
            Dim tx As String = wdoc.Range.Text
            Dim c As String = ""
            Dim i As Integer
            Dim j As Integer
            Dim Valor As String
            Dim dRes() As DataRow

            i = tx.IndexOf("[")
            Do Until i < 0
                Application.DoEvents()

                j = tx.IndexOf("]", i)
                If j >= 0 Then
                    c = tx.Substring(i, j - i + 1)
                    dRes = dtFields.Select("referencia = '" & c & "'")
                    If dRes.Length > 0 Then
                        Valor = dRes(0)("valor").ToString()
                        ReplaceAllInWord(wapp, c, Valor)
                    End If

                End If
                i = tx.IndexOf("[", j)
            Loop

            wdoc.SaveAs(Destination)
            wdoc.Close()
            'wapp.Documents.Close(Word.WdSaveOptions.wdSaveChanges)
            ' Close.

            'wdoc.Close(save_changes)
            'wdoc.Quit(save_changes)
                Next
            wapp.Quit(save_changes)
            releaseObject(wdoc)
            releaseObject(wapp)

            Application.DoEvents()
            Dim cadena As String
            'If dtInsert.Rows.Count >= 10 Then
            '    If MessageBox.Show("Se generarán " & dtInsert.Rows.Count & " contratos." & vbCrLf & "¿Es correcto?", "Contratos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        For Each dr As DataRow In dtInsert.Rows

            '            cadena = "INSERT INTO contratos_generados (reloj,fecha,tipo_contrato,fecha_vencimiento,usuario,vigencia,fecha_genera) VALUES (" & _
            '                    "@reloj,@fecha,@tipo_contrato,@fha_vencimiento,@usuario,@vigencia,@fcha_genera)"
            '            cadena = cadena.Replace("@reloj", "'" & dr("reloj") & "'")
            '            cadena = cadena.Replace("@fecha", "'" & FechaSQL(dr("fecha")) & "'")
            '            cadena = cadena.Replace("@tipo_contrato", "'" & dr("tipo_contrato") & "'")
            '            cadena = cadena.Replace("@fha_vencimiento", "'" & FechaSQL(dr("fecha_vencimiento")) & "'")
            '            cadena = cadena.Replace("@usuario", "'" & dr("usuario") & "'")
            '            cadena = cadena.Replace("@vigencia", "'" & dr("vigencia") & "'")
            '            cadena = cadena.Replace("@fcha_genera", "'" & dr("fecha_genera") & "'")
            '            sqlExecute(cadena)
            '        Next
            '    End If
            'Else
            If dtInsert.Rows.Count > 0 Then
                For Each dr As DataRow In dtInsert.Rows

                    cadena = "INSERT INTO contratos_generados (reloj,fecha,tipo_contrato,fecha_vencimiento,usuario,vigencia,fecha_genera) VALUES (" & _
                            "@reloj,@fecha,@tipo_contrato,@fha_vencimiento,@usuario,@vigencia,@fcha_genera)"
                    cadena = cadena.Replace("@reloj", "'" & dr("reloj") & "'")
                    cadena = cadena.Replace("@fecha", "'" & FechaSQL(dr("fecha")) & "'")
                    cadena = cadena.Replace("@tipo_contrato", "'" & dr("tipo_contrato") & "'")
                    If dr("tipo_contrato") = "004" Then
                        cadena = cadena.Replace("@fha_vencimiento", "null")
                    Else
                        '== ERROR CON FECHA CUANDO NO HAY F DE VENCIMIENTO              10nov2021
                        Dim f_ven As String = ""
                        Try : f_ven = FechaSQL(dr("fecha_vencimiento")) : Catch ex As Exception : f_ven = "" : End Try
                        cadena = cadena.Replace("@fha_vencimiento", "'" & f_ven & "'")
                        '==
                    End If

                    cadena = cadena.Replace("@usuario", "'" & dr("usuario") & "'")

                    If dr("tipo_contrato") = "004" Then
                        cadena = cadena.Replace("@vigencia", "null")
                    Else
                        cadena = cadena.Replace("@vigencia", "'" & dr("vigencia") & "'")
                    End If

                    cadena = cadena.Replace("@fcha_genera", "'" & dr("fecha_genera") & "'")
                    sqlExecute(cadena)
                Next

            End If
            'Detener la barra de progreso antes de mostrar el mensaje
            pbAvance.IsRunning = False
            pnlAvance.Visible = False

            If dtInsert.Rows.Count = 1 Then
                MsgBox("Archivo generado exitosamente: " & vbCrLf & Destination, MsgBoxStyle.Information, "Pida")
            ElseIf dtInsert.Rows.Count > 0 Then
                MsgBox(dtInsert.Rows.Count & " archivos fueron generados exitosamente:" & SF.FileName.Replace(".docx", "*"), MsgBoxStyle.Information, "Pida")
            End If

            End If
        Catch ex As Exception
            Debug.Print(ex.Message & vbCrLf & ex.StackTrace)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MsgBox("Hubo un error, y los archivos no pudieron ser procesados correctamente. Si el problema persiste, contacte al administrador del sistema." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Pida")
        Finally
            Application.DoEvents()
        End Try

    End Sub
    Private Sub CamposReferencia(ByRef dtInfo As DataTable, referencia As String, valor As String)
        Try
            dtInfo.Rows.Add({referencia, valor})

        Catch ex As Exception
            Debug.Print(ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Public Sub GeneraContrato(dtEmpleado As DataTable)

        Dim dtDatosCia As New DataTable
        Dim dtDetalle As New DataTable
        Dim dtTemp As New DataTable
        Dim dtDobles As DataTable
        Try
            Dim Reporte As String = DireccionReportes & "Contrato.rdl"
            Dim Mensaje As String
            Dim Revision As String
            Dim Vigencia As Integer = 0
            Dim Rl As String
            Dim Repre As String
            Dim path_firma_rep As String
            Dim puesto_rep As String
            Dim Fld As String
            Dim Info As String
            Dim y As Integer
            Dim x As Integer
            Dim Fin_contrato As Date
            Dim fecha1 As Date
            Dim fecha2 As Date
            Dim dias As Integer
            dtDetalle.Columns.Add("reloj")
            dtDetalle.Columns.Add("repre")
            dtDetalle.Columns.Add("path_firma_rep")
            dtDetalle.Columns.Add("puesto_rep")
            dtDetalle.Columns.Add("CONTRATO")
            dtDetalle.Columns.Add("revision")
            dtDetalle.Columns.Add("nombre")
            dtDetalle.Columns.Add("cia_nombre")
            dtDetalle.Columns.Add("representante")


            dtTemp = sqlExecute("SELECT contrato,revision,vigencia FROM contrato WHERE tipo_cont = '" & Contrato & "' AND cod_comp = '" & Cia & "'")

            Mensaje = dtTemp.Rows(0).Item("contrato")
            Revision = dtTemp.Rows(0).Item("revision").ToString.Trim
            Vigencia = IIf(IsDBNull(dtTemp.Rows(0).Item("vigencia")), 0, dtTemp.Rows(0).Item("vigencia"))
            Fin_contrato = Date.Parse(IIf(lblAlta.Checked, dtEmpleado.Rows(x)("alta"), txtInicioHoy.Value)).AddDays(cmbTipo.SelectedValue).AddDays(-1)

            fecha1 = IIf(lblAlta.Checked, dtEmpleado.Rows(x).Item("alta"), txtInicioHoy.Value)
            fecha2 = txtFechaVencimiento.Value
            dias = (fecha2 - fecha1).TotalDays

            For x = 0 To dtEmpleado.Rows.Count - 1
                dtDatosCia = sqlExecute("SELECT cias.nombre AS compania,rfc as rfc_cia,reg_pat,direccion AS direccion_comp,colonia AS colonia_comp,cod_postal AS cp_comp,rep_legal,puesto as rep_puesto FROM cias WHERE cod_comp = '" & dtEmpleado.Rows(x).Item("cod_comp") & "'")
                Rl = dtEmpleado.Rows(x).Item("reloj")
                Repre = IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("nombre_rep")), "", dtFiltroPersonal.Rows(x).Item("nombre_rep"))
                path_firma_rep = IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("path_firma_rep")), "", dtFiltroPersonal.Rows(x).Item("path_firma_rep"))
                puesto_rep = IIf(IsDBNull(dtFiltroPersonal.Rows(x).Item("puesto_rep")), "", dtFiltroPersonal.Rows(x).Item("puesto_rep"))
                Info = Mensaje

                'horario descripción (abraham)
                Try
                    Info = Info.Replace("[horario_descripcion]", sqlExecute("select descripcion_larga from horarios where cod_hora = '" & dtEmpleado.Rows(x)("cod_hora") & "'").Rows(0)("descripcion_larga"))
                Catch ex As Exception
                    Info = Info.Replace("[horario_descripcion]", "[nombre_horario] (DESCRIPCION DEL HORARIO NO DISPONIBLE)")
                End Try

                Try
                    Info = Info.Replace("[sexo_letra]", sqlExecute("select * from sexo where sexo = '" & dtEmpleado.Rows(x)("sexo") & "'").Rows(0)("nombre"))
                Catch ex As Exception
                    Info = Info.Replace("[sexo_letra]", "N/A")
                End Try

                Try
                    Info = Info.Replace("[repre]", Repre)
                Catch ex As Exception
                    Info = Info.Replace("[repre]", "N/A")
                End Try

                For y = 0 To dtEmpleado.Columns.Count - 1
                    Fld = dtEmpleado.Columns(y).ColumnName.ToLower

                    If dtEmpleado.Columns(y).DataType.Name = "DateTime" Then
                        If IsDBNull(dtEmpleado.Rows(x).Item(y)) Then
                            Info = Info.Replace("[" & Fld & "]", "---")
                        Else
                            Info = Info.Replace("[" & Fld & "]", FechaMediaLetra(dtEmpleado.Rows(x).Item(y)))
                        End If
                    Else
                        Info = Info.Replace("[" & Fld & "]", IIf(IsDBNull(dtEmpleado.Rows(x).Item(y)), "---", dtEmpleado.Rows(x).Item(y).ToString.ToUpper))
                    End If
                Next

                For y = 0 To dtDatosCia.Columns.Count - 1
                    Fld = dtDatosCia.Columns(y).ColumnName
                    If dtDatosCia.Columns(y).DataType.Name = "DateTime" Then
                        If IsDBNull(dtDatosCia.Rows(0).Item(y)) Then
                            Info = Info.Replace("[" & Fld & "]", "---")
                        Else
                            Info = Info.Replace("[" & Fld & "]", FechaMediaLetra(dtDatosCia.Rows(0).Item(y)))
                        End If
                    Else
                        Info = Info.Replace("[" & Fld & "]", dtDatosCia.Rows(0).Item(y).ToString.ToUpper)
                    End If
                Next

                'Nombre completo NOMBRE APATERNO AMATERNO
                Info = Info.Replace("[nombre_completo]", RTrim(dtEmpleado.Rows(x).Item("nombre")) & " " & RTrim(dtEmpleado.Rows(x).Item("apaterno")) & " " & RTrim(IIf(IsDBNull(dtEmpleado.Rows(x).Item("amaterno")), "", dtEmpleado.Rows(x).Item("amaterno"))))

                'edad en anios (abraham)
                Try
                    Info = Info.Replace("[edad_en_anos]", Antiguedad(dtEmpleado.Rows(x).Item("fha_nac"), dtEmpleado.Rows(x).Item("alta")))
                Catch ex As Exception
                    Info = Info.Replace("[edad_en_anos]", "N/A")
                End Try

                'Vigencia en dias

                'Info = Info.Replace("[vigencia_dias]", dias)
                Info = Info.Replace("[vigencia_dias]", IIf(rbVigencia.Checked, cmbTipo.SelectedValue, dias))

                'vigencia contrato (abraham)
                Try
                    Info = Info.Replace("[vigencia_contrato]", dtTemp.Rows(0)("vigencia"))
                Catch ex As Exception
                    Info = Info.Replace("[vigencia_contrato]", "N/A")
                End Try
                'fin del contrato (abraham)
                Try
                    Info = Info.Replace("[fecha_fin_contrato_letra]", IIf(rbVigencia.Checked, FechaMediaLetra(Fin_contrato), FechaMediaLetra(txtFechaVencimiento.Value)))
                Catch ex As Exception
                    Info = Info.Replace("[fecha_fin_contrato_letra]", "N/A")
                End Try
                'fecha de Alta (larga) (edgar)
                Try
                    Info = Info.Replace("[alta_fecha_larga]", IIf(lblAlta.Checked, FechaMediaLetra(dtFiltroPersonal.Rows(x).Item("alta")), FechaMediaLetra(txtInicioHoy.Value)))
                Catch ex As Exception
                    Info = Info.Replace("[alta_fecha_larga]", "N/A")
                End Try

                'Fecha en que se imprime el contrato(carlos)
                Try
                    Info = Info.Replace("[fecha_actual]", FechaMediaLetra(Date.Now))
                Catch ex As Exception
                    Info = Info.Replace("[fecha_actual]", "N/A")
                End Try
                'direccion completa (abraham)
                Try
                    Info = Info.Replace("[direccion_completa]", RTrim(dtEmpleado.Rows(x).Item("direccion")) & ", " & RTrim(sqlExecute("select top 1 * from colonias where cod_col = '" & dtEmpleado.Rows(x).Item("cod_col") & "'").Rows(0)("nombre")))
                Catch ex As Exception
                    Info = Info.Replace("[direccion_completa]", "(DIRECCION NO DISPONIBLE)")
                End Try

                'Sexo (completo)
                Info = Info.Replace("[sexo_comp]", IIf(dtEmpleado.Rows(x).Item("sexo").ToString = "F", "femenino", "masculino"))

                'Definidos por sexo
                Info = Info.Replace("[al_ala]", IIf(dtEmpleado.Rows(x).Item("sexo").ToString = "F", "a la", "al"))
                Info = Info.Replace("[el_la]", IIf(dtEmpleado.Rows(x).Item("sexo").ToString = "F", "la", "el"))
                Info = Info.Replace("[sr(a)]", IIf(dtEmpleado.Rows(x).Item("sexo").ToString = "F", "señora (ita)", "señor"))

                'Sueldo en letra
                Info = Info.Replace("[sactual_letra]", ConvNvo(dtEmpleado.Rows(x).Item("sactual").ToString))
                'salario mensual (abraham)
                Info = Info.Replace("[salario_mensual]", String.Format("{0:C2}", Double.Parse(dtEmpleado.Rows(x).Item("sactual") * 30)))
                Info = Info.Replace("[salario_mensual_letra]", ConvNvo(Math.Round(Double.Parse(dtEmpleado.Rows(x).Item("sactual")) * 30, 2)))

                'Horarios
                dtTemp = sqlExecute("SELECT entra,sale FROM dias WHERE cod_hora = '" & dtEmpleado.Rows(x).Item("cod_hora") & "' AND cod_comp = '" & dtEmpleado.Rows(x).Item("cod_comp") & "' AND descanso = 0")
                If dtTemp.Rows.Count = 0 Then
                    Info = Info.Replace("[hora_entrada]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Info = Info.Replace("[hora_salida]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                Else
                    Info = Info.Replace("[hora_entrada]", dtTemp.Rows(0).Item("entra"))
                    Info = Info.Replace("[hora_salida]", dtTemp.Rows(0).Item("sale"))
                End If

                'Jornada diurna
                dtTemp = sqlExecute("SELECT entra,sale FROM dias WHERE cod_hora = '1' AND cod_comp = '" & dtEmpleado.Rows(x).Item("cod_comp") & "' AND descanso = 0")
                If dtTemp.Rows.Count = 0 Then
                    Info = Info.Replace("[entrada_h1]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Info = Info.Replace("[salida_h1]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                Else
                    Info = Info.Replace("[entrada_h1]", dtTemp.Rows(0).Item("entra"))
                    Info = Info.Replace("[salida_h1]", dtTemp.Rows(0).Item("sale"))
                End If

                'Jornada mixta
                dtTemp = sqlExecute("SELECT entra,sale FROM dias WHERE cod_hora = '2' AND cod_comp = '" & dtEmpleado.Rows(x).Item("cod_comp") & "' AND descanso = 0")
                If dtTemp.Rows.Count = 0 Then
                    Info = Info.Replace("[entrada_h2]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                    Info = Info.Replace("[salida_h2]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                Else
                    Info = Info.Replace("[entrada_h2]", dtTemp.Rows(0).Item("entra"))
                    Info = Info.Replace("[salida_h2]", dtTemp.Rows(0).Item("sale"))
                End If

                Info = Info.Replace("[fecha_hoy]", FechaMediaLetra(Now))
                Info = Info.Replace("[fecha_firma]", FechaMediaLetra(IIf(lblAlta.Checked, dtEmpleado.Rows(x).Item("alta"), txtInicioHoy.Value)))
                Info = Info.Replace("[alta_letra]", FechaMediaLetra(dtEmpleado.Rows(x).Item("alta")))
                Info = Info.Replace("[fecha_renovacion]", FechaMediaLetra(Date.Parse(dtEmpleado.Rows(x).Item("alta")).AddDays(30)))
                dtDobles = sqlExecute("select * from contratos_generados where reloj='" & dtEmpleado.Rows(x).Item("reloj") & "' and fecha='" & FechaSQL(IIf(lblAlta.Checked, dtEmpleado.Rows(x).Item("alta"), txtInicioHoy.Value)) & "' and tipo_contrato='" & Contrato & "'")
                If dtDobles.Rows.Count <> 0 Then
                    sqlExecute("delete from contratos_generados where reloj='" & dtEmpleado.Rows(x).Item("reloj") & "' and fecha='" & FechaSQL(IIf(lblAlta.Checked, dtEmpleado.Rows(x).Item("alta"), txtInicioHoy.Value)) & "' and tipo_contrato='" & Contrato & "'")
                End If
                sqlExecute("INSERT INTO contratos_generados (reloj,fecha,tipo_contrato,fecha_vencimiento,usuario,vigencia,fecha_genera) VALUES ('" & _
                                               dtEmpleado.Rows(x).Item("reloj") & "','" & FechaSQL(IIf(lblAlta.Checked, dtEmpleado.Rows(x).Item("alta"), txtInicioHoy.Value)) & "','" & Contrato & "'," & _
                                               IIf(Vigencia = 0, "NULL", "'" & IIf(rbVigencia.Checked, FechaMediaLetra(Fin_contrato), FechaMediaLetra(txtFechaVencimiento.Value)) & "'") & ",'" & Usuario & "'," & IIf(rbVigencia.Checked, "'" & cmbTipo.SelectedValue & "'", "NULL") & ",'" & FechaSQL(Now) & "')")

                'Formar el mensaje
                dtDetalle.Rows.Add({Rl, Repre, path_firma_rep, puesto_rep, Info, Revision, RTrim(dtEmpleado.Rows(x).Item("nombre")) & " " & RTrim(dtEmpleado.Rows(x).Item("apaterno")) & " " & IIf(IsDBNull(dtEmpleado.Rows(x).Item("amaterno")), "", dtEmpleado.Rows(x).Item("amaterno")), dtDatosCia.Rows(0)("compania"), dtDatosCia.Rows(0)("rep_legal")})
            Next

            'Limpiar el ReportViewer, por si hubiera algún frmVistaPrevia.vwrReportes cargado
            frmVistaPrevia.vwrReportes.Clear()
            'Indicar que se ejecutarán frmVistaPrevia.vwrReportess de forma local (no desde servidor SSRS)
            frmVistaPrevia.vwrReportes.ProcessingMode = ProcessingMode.Local
            frmVistaPrevia.vwrReportes.LocalReport.ReportPath = Reporte
            frmVistaPrevia.vwrReportes.LocalReport.DataSources.Clear()
            frmVistaPrevia.vwrReportes.LocalReport.DataSources.Add(New ReportDataSource("Datos", dtDetalle))

            frmVistaPrevia.vwrReportes.Dock = DockStyle.Fill
            frmVistaPrevia.vwrReportes.Visible = True

            frmVistaPrevia.vwrReportes.LocalReport.EnableExternalImages = True
            frmVistaPrevia.vwrReportes.RefreshReport()
            'frmVistaPrevia.ShowDialog()
            frmVistaPrevia.GenerarReporteTMP()
        Catch ex As Exception
            Debug.Print(ex.Message & vbCrLf & ex.StackTrace)
        Finally
            Application.DoEvents()
        End Try

    End Sub
    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        Try
            Cia = cmbContratos.SelectedNode.Cells(0).Text
            Contrato = cmbContratos.SelectedNode.Cells(1).Text
            pnlAvance.Visible = True
            pbAvance.IsRunning = True
            'Fecha = IIf(lblAlta.Checked, dtEmpleado.Rows(x).Item("nombre"), txtInicioHoy.Value)
            Fecha = Now
            Me.Cursor = Cursors.WaitCursor
            If Origen.Equals("Reporteador") Then
                If chkWord.Checked Then
                    GeneraContratoWord()
                Else
                    GeneraContrato()
                End If
            Else
                Me.Cursor = Cursors.Default
                pbAvance.IsRunning = False
                Me.Close()
            End If
            Me.Cursor = Cursors.Default
            pbAvance.IsRunning = False

            Me.Close()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub cmbContratos_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cmbContratos.SelectionChanged
        Try
            Dim Cnt As String = cmbContratos.SelectedValue
            dtTemporal = sqlExecute("SELECT vigencia,tipo_cont FROM contrato WHERE tipo_cont = '" & Cnt & "'")
            Dim vigencia As Integer = IIf(IsDBNull(dtTemporal.Rows(0).Item("vigencia")), 0, dtTemporal.Rows(0).Item("vigencia"))
            Dim contrato As String = IIf(IsDBNull(dtTemporal.Rows(0).Item("tipo_cont")), 0, RTrim(dtTemporal.Rows(0).Item("tipo_cont")).ToString)

            If vigencia > 0 Then
                'txtFechaVencimiento.Value = DateAdd(DateInterval.Day, dtTemporal.Rows(0).Item("vigencia"), txtFecha.Value)
                txtFechaVencimiento.Visible = True
                'txtFechaVencimiento.Value = IIf(lblAlta.Checked, txtFecha.Value.AddDays(vigencia), txtInicioHoy.Value.AddDays(vigencia))
                txtFechaVencimiento.Value = Now
                txtFechaVencimiento.Enabled = True
                'lblVencimiento.Visible = True
                PanelVencimiento.Visible = True
            Else
                'txtFechaVencimiento.Visible = False
                txtFechaVencimiento.Enabled = False
                'lblVencimiento.Visible = False
                PanelVencimiento.Visible = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub cmbContratos_TextChanged(sender As Object, e As EventArgs) Handles cmbContratos.TextChanged

    End Sub

    Private Sub txtFecha_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtFecha_Validated(sender As Object, e As EventArgs)
        Try
            Dim Cnt As String = cmbContratos.SelectedValue.ToString
            dtTemporal = sqlExecute("SELECT vigencia FROM contrato WHERE tipo_cont = '" & Cnt & "'")
            If Not IsDBNull(dtTemporal.Rows(0).Item("vigencia")) Then
                'txtFechaVencimiento.Value = DateAdd(DateInterval.Day, dtTemporal.Rows(0).Item("vigencia"), IIf(lblAlta.Checked, txtFecha.Value, txtInicioHoy.Value))
                txtFechaVencimiento.Enabled = True
            Else
                txtFechaVencimiento.Enabled = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ReflectionLabel1_Click(sender As Object, e As EventArgs) Handles ReflectionLabel1.Click

    End Sub

    Private Sub rbFechaVenc_CheckedChanged(sender As Object, e As EventArgs) Handles rbFechaVenc.CheckedChanged
        txtFechaVencimiento.Enabled = rbFechaVenc.Checked
        'txtFechaVencimiento.Enabled = rbVigencia.Checked
    End Sub

    Private Sub rbVigencia_CheckedChanged(sender As Object, e As EventArgs) Handles rbVigencia.CheckedChanged
        Try
            'cmbTipo.Enabled = rbFechaVenc.Checked
            cmbTipo.Enabled = rbVigencia.Checked
            cmbTipo.DisplayMember = "Dias"
            cmbTipo.ValueMember = "Dias"
            Dim tb As New DataTable
            tb.Columns.Add("Dias", GetType(Integer))
            tb.Rows.Add(30)
            tb.Rows.Add(60)
            tb.Rows.Add(90)
            cmbTipo.DataSource = tb
            cmbTipo.Text = "90"
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub lblAlta_CheckedChanged(sender As Object, e As EventArgs) Handles lblAlta.CheckedChanged
        'txtFecha.Enabled = lblAlta.Checked
    End Sub

    Private Sub lblEspecifica_CheckedChanged(sender As Object, e As EventArgs) Handles lblEspecifica.CheckedChanged
        txtInicioHoy.Enabled = lblEspecifica.Checked
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub chkApartir_CheckedChanged(sender As Object, e As EventArgs) Handles chkApartir.CheckedChanged
        Try
            cmbinicio.Enabled = chkApartir.Checked
            cmbinicio.DisplayMember = "Dias"
            cmbinicio.ValueMember = "Dias"
            Dim tb As New DataTable
            tb.Columns.Add("Dias", GetType(Integer))
            tb.Rows.Add(30)
            tb.Rows.Add(60)
            tb.Rows.Add(90)
            cmbinicio.DataSource = tb
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ReplaceAllInWord(wapp As Word.Application, Original As String, Nuevo As String)
        Try
            Dim wdoc As Word.Document = wapp.ActiveDocument
            Dim x As Boolean
            x = wdoc.Content.Find.Execute(FindText:=Original, ReplaceWith:=Nuevo.Trim, Replace:=Word.WdReplace.wdReplaceAll)
        Catch ex As Exception
            Debug.Print(ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged

    End Sub

    Private Sub txtInicioHoy_Click(sender As Object, e As EventArgs) Handles txtInicioHoy.Click

    End Sub
End Class
