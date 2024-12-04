Imports OfficeOpenXml
Imports System.IO

Public Class frmCargaOH

    Dim dtMovimientosAplicados As New DataTable

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try

            Dim nombre_archivo As String = "Carga masiva de personal"
            Dim sfd As New SaveFileDialog
            sfd.Filter = "Archivo de excel|*.xlsx"
            sfd.Title = "Generar layout para carga"
            sfd.FileName = nombre_archivo
            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                Dim hoja_personal As ExcelWorksheet = wb.Worksheets.Add("personal")
                Dim hoja_catalogos As ExcelWorksheet = wb.Worksheets.Add("catalogos")


                '***********************************************************************************

                hoja_personal.Cells(1, 1).Value = "reloj_alt"
                hoja_personal.Cells(1, 2).Value = "cod_depto"
                hoja_personal.Cells(1, 3).Value = "cod_tipo"
                hoja_personal.Cells(1, 4).Value = "cod_clase"
                hoja_personal.Cells(1, 5).Value = "cod_super"
                hoja_personal.Cells(1, 6).Value = "cod_hora"
                hoja_personal.Cells(1, 7).Value = "cod_puesto"
                hoja_personal.Cells(1, 8).Value = "tipo_periodo"
                hoja_personal.Cells(1, 9).Value = "sindicalizado"
                hoja_personal.Cells(1, 10).Value = "nombre"
                hoja_personal.Cells(1, 11).Value = "apaterno"
                hoja_personal.Cells(1, 12).Value = "amaterno"
                hoja_personal.Cells(1, 13).Value = "sexo"
                hoja_personal.Cells(1, 14).Value = "imss"
                hoja_personal.Cells(1, 15).Value = "rfc"
                hoja_personal.Cells(1, 16).Value = "curp"
                hoja_personal.Cells(1, 17).Value = "sactual"
                hoja_personal.Cells(1, 18).Value = "alta"
                hoja_personal.Cells(1, 19).Value = "baja"
                hoja_personal.Cells(1, 20).Value = "cod_civil"
                hoja_personal.Cells(1, 21).Value = "direccion"
                hoja_personal.Cells(1, 22).Value = "colonia_nombre"
                hoja_personal.Cells(1, 23).Value = "ciudad_nombre"


                hoja_personal.Cells(2, 1).Value = "Reloj alterno"
                hoja_personal.Cells(2, 2).Value = "Catálogo anexo"
                hoja_personal.Cells(2, 3).Value = "O = Operativo / A = Administrativo"
                hoja_personal.Cells(2, 4).Value = "D = Direct / I = Indirect / A = Salary / G = Manager"
                hoja_personal.Cells(2, 5).Value = "Catálogo anexo"
                hoja_personal.Cells(2, 6).Value = "Catálogo anexo"
                hoja_personal.Cells(2, 7).Value = "Catálogo anexo"
                hoja_personal.Cells(2, 8).Value = "S = Semanal / Q = Quincenal"
                hoja_personal.Cells(2, 9).Value = "1 = si / 0 = no"
                hoja_personal.Cells(2, 10).Value = "Nombre y segundo nombre"
                hoja_personal.Cells(2, 11).Value = "Apellido paterno"
                hoja_personal.Cells(2, 12).Value = "Apellido materno"
                hoja_personal.Cells(2, 13).Value = "F = Femenino / M = Masculino"
                hoja_personal.Cells(2, 14).Value = "Imss completo"
                hoja_personal.Cells(2, 15).Value = "RFC"
                hoja_personal.Cells(2, 16).Value = "CURP"
                hoja_personal.Cells(2, 17).Value = "Salario diario"
                hoja_personal.Cells(2, 18).Value = "Fecha de alta YYYY-MM-DD"
                hoja_personal.Cells(2, 19).Value = "Fecha de baja YYYY-MM-DD"
                hoja_personal.Cells(2, 20).Value = "Estado civil"
                hoja_personal.Cells(2, 21).Value = "Calle y numero"
                hoja_personal.Cells(2, 22).Value = "Colonia"
                hoja_personal.Cells(2, 23).Value = "Ciudad"


                '***********************************************************************************

                hoja_personal.Cells(1, 1).Style.Font.Bold = True ' = "reloj_alt"
                hoja_personal.Cells(1, 2).Style.Font.Bold = True ' = "cod_depto"
                hoja_personal.Cells(1, 3).Style.Font.Bold = True ' = "cod_tipo"
                hoja_personal.Cells(1, 4).Style.Font.Bold = True ' = "cod_clase"
                hoja_personal.Cells(1, 5).Style.Font.Bold = True ' = "cod_super"
                hoja_personal.Cells(1, 6).Style.Font.Bold = True ' = "cod_hora"
                hoja_personal.Cells(1, 7).Style.Font.Bold = True ' = "cod_puesto"
                hoja_personal.Cells(1, 8).Style.Font.Bold = True ' = "tipo_periodo"
                hoja_personal.Cells(1, 9).Style.Font.Bold = True ' = "sindicalizado"
                hoja_personal.Cells(1, 10).Style.Font.Bold = True ' = "nombre"
                hoja_personal.Cells(1, 11).Style.Font.Bold = True ' = "apaterno"
                hoja_personal.Cells(1, 12).Style.Font.Bold = True ' = "amaterno"
                hoja_personal.Cells(1, 13).Style.Font.Bold = True ' = "sexo"
                hoja_personal.Cells(1, 14).Style.Font.Bold = True ' = "imss"
                hoja_personal.Cells(1, 15).Style.Font.Bold = True ' = "rfc"
                hoja_personal.Cells(1, 16).Style.Font.Bold = True ' = "curp"
                hoja_personal.Cells(1, 17).Style.Font.Bold = True ' = "sactual"
                hoja_personal.Cells(1, 18).Style.Font.Bold = True ' = "alta"
                hoja_personal.Cells(1, 19).Style.Font.Bold = True ' = "baja"
                hoja_personal.Cells(1, 20).Style.Font.Bold = True ' = "cod_civil"
                hoja_personal.Cells(1, 21).Style.Font.Bold = True ' = "direccion"
                hoja_personal.Cells(1, 22).Style.Font.Bold = True ' = "colonia_nombre"
                hoja_personal.Cells(1, 23).Style.Font.Bold = True ' = "ciudad_nombre"


                hoja_personal.Cells(2, 1).Style.Font.Bold = True ' = "Reloj alterno"
                hoja_personal.Cells(2, 2).Style.Font.Bold = True ' = "Catálogo anexo"
                hoja_personal.Cells(2, 3).Style.Font.Bold = True ' = "O = Operativo / A = Administrativo"
                hoja_personal.Cells(2, 4).Style.Font.Bold = True ' = "D = Direct / I = Indirect / A = Salary / G = Manager"
                hoja_personal.Cells(2, 5).Style.Font.Bold = True ' = "Catálogo anexo"
                hoja_personal.Cells(2, 6).Style.Font.Bold = True ' = "Catálogo anexo"
                hoja_personal.Cells(2, 7).Style.Font.Bold = True ' = "Catálogo anexo"
                hoja_personal.Cells(2, 8).Style.Font.Bold = True ' = "S = Semanal / Q = Quincenal"
                hoja_personal.Cells(2, 9).Style.Font.Bold = True ' = "1 = si / 0 = no"
                hoja_personal.Cells(2, 10).Style.Font.Bold = True ' = "Nombre y segundo nombre"
                hoja_personal.Cells(2, 11).Style.Font.Bold = True ' = "Apellido paterno"
                hoja_personal.Cells(2, 12).Style.Font.Bold = True ' = "Apellido materno"
                hoja_personal.Cells(2, 13).Style.Font.Bold = True ' = "F = Femenino / M = Masculino"
                hoja_personal.Cells(2, 14).Style.Font.Bold = True ' = "Imss completo"
                hoja_personal.Cells(2, 15).Style.Font.Bold = True ' = "RFC"
                hoja_personal.Cells(2, 16).Style.Font.Bold = True ' = "CURP"
                hoja_personal.Cells(2, 17).Style.Font.Bold = True ' = "Salario diario"
                hoja_personal.Cells(2, 18).Style.Font.Bold = True ' = "Fecha de alta YYYY-MM-DD"
                hoja_personal.Cells(2, 19).Style.Font.Bold = True ' = "Fecha de baja YYYY-MM-DD"
                hoja_personal.Cells(2, 20).Style.Font.Bold = True ' = "Estado civil"
                hoja_personal.Cells(2, 21).Style.Font.Bold = True ' = "Calle y numero"
                hoja_personal.Cells(2, 22).Style.Font.Bold = True ' = "Colonia"
                hoja_personal.Cells(2, 23).Style.Font.Bold = True ' = "Ciudad"



                '*****************************************

                Dim dtDeptos As DataTable = sqlExecute("select distinct 'departamentos' as tipo, cod_depto as codigo, nombre_ingles as nombre, 0 as auxiliar from deptos where isnull(cod_depto, '') <> ''")
                Dim dtPuestos As DataTable = sqlExecute("select distinct 'puestos' as tipo, cod_puesto as codigo, nombre_ingles as nombre, 0 as auxiliar  from puestos where isnull(cod_puesto, '') <> ''")
                Dim dtSuper As DataTable = sqlExecute("select distinct 'supervisores' as tipo, cod_super as codigo, nombre as nombre, reloj as auxiliar from super where isnull(reloj, '') <> ''")
                Dim dtHorarios As DataTable = sqlExecute("select distinct 'horarios' as tipo, cod_hora as codigo, nombre as nombre, 0 as auxiliar from horarios  where isnull(cod_hora, '') <> ''")


                hoja_catalogos.Cells(1, 1).Value = "tipo"
                hoja_catalogos.Cells(1, 2).Value = "codigo"
                hoja_catalogos.Cells(1, 3).Value = "nombre"
                hoja_catalogos.Cells(1, 4).Value = "auxiliar"

                hoja_catalogos.Cells(1, 1).Style.Font.Bold = True
                hoja_catalogos.Cells(1, 2).Style.Font.Bold = True
                hoja_catalogos.Cells(1, 3).Style.Font.Bold = True
                hoja_catalogos.Cells(1, 4).Style.Font.Bold = True

                Dim x As Integer = 2

                For Each row As DataRow In dtDeptos.Rows
                    hoja_catalogos.Cells(x, 1).Value = row("tipo")
                    hoja_catalogos.Cells(x, 2).Value = row("codigo")
                    hoja_catalogos.Cells(x, 3).Value = row("nombre")
                    hoja_catalogos.Cells(x, 4).Value = row("auxiliar")

                    x += 1
                Next

                For Each row As DataRow In dtPuestos.Rows
                    hoja_catalogos.Cells(x, 1).Value = row("tipo")
                    hoja_catalogos.Cells(x, 2).Value = row("codigo")
                    hoja_catalogos.Cells(x, 3).Value = row("nombre")
                    hoja_catalogos.Cells(x, 4).Value = row("auxiliar")

                    x += 1
                Next

                For Each row As DataRow In dtSuper.Rows
                    hoja_catalogos.Cells(x, 1).Value = row("tipo")
                    hoja_catalogos.Cells(x, 2).Value = row("codigo")
                    hoja_catalogos.Cells(x, 3).Value = row("nombre")
                    hoja_catalogos.Cells(x, 4).Value = row("auxiliar")

                    x += 1
                Next

                For Each row As DataRow In dtHorarios.Rows
                    hoja_catalogos.Cells(x, 1).Value = row("tipo")
                    hoja_catalogos.Cells(x, 2).Value = row("codigo")
                    hoja_catalogos.Cells(x, 3).Value = row("nombre")
                    hoja_catalogos.Cells(x, 4).Value = row("auxiliar")

                    x += 1
                Next


                hoja_personal.Cells(hoja_personal.Dimension.Address).AutoFitColumns()
                hoja_catalogos.Cells(hoja_catalogos.Dimension.Address).AutoFitColumns()

                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))

            End If

            MessageBox.Show("Archivo generado correctamente en " & sfd.FileName, "Archivo generado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmCargaOH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dtCias As DataTable = sqlExecute("select cod_comp, (cod_comp + ' - ' + nombre) as nombre from cias where cod_comp <> '610'")
            cmbCias.DataSource = dtCias
            cmbCias.DisplayMember = "nombre"
            cmbCias.ValueMember = "cod_comp"


            Dim fecha_lunes As Date = Now.Date
            While fecha_lunes.DayOfWeek <> DayOfWeek.Monday
                fecha_lunes = fecha_lunes.AddDays(-1)
            End While

            dtpFechaEfectiva.Value = fecha_lunes

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSeleccionarArchivo_Click(sender As Object, e As EventArgs) Handles btnSeleccionarArchivo.Click
        Try
            Dim ofd As New OpenFileDialog
            ofd.Filter = "Excel File|*.xlsx"
            ofd.Title = "Seleccionar archivo excel"
            ofd.Multiselect = False

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtArchivoCarga.Text = ofd.FileName
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnIniciarCarga_Click(sender As Object, e As EventArgs) Handles btnIniciarCarga.Click
        Try
            If txtArchivoCarga.Text.Trim <> "" Then

                Dim dtPersonal As New DataTable
                dtPersonal.Columns.Add("reloj_alt", Type.GetType("System.String")) ' 1
                dtPersonal.Columns.Add("cod_depto", Type.GetType("System.String")) ' 2
                dtPersonal.Columns.Add("cod_tipo", Type.GetType("System.String")) ' 3
                dtPersonal.Columns.Add("cod_clase", Type.GetType("System.String")) ' 4
                dtPersonal.Columns.Add("cod_super", Type.GetType("System.String")) ' 5
                dtPersonal.Columns.Add("cod_hora", Type.GetType("System.String")) ' 6
                dtPersonal.Columns.Add("cod_puesto", Type.GetType("System.String")) ' 7
                dtPersonal.Columns.Add("tipo_periodo", Type.GetType("System.String")) ' 8
                dtPersonal.Columns.Add("sindicalizado", Type.GetType("System.String")) ' 9
                dtPersonal.Columns.Add("nombre", Type.GetType("System.String")) ' 10
                dtPersonal.Columns.Add("apaterno", Type.GetType("System.String")) ' 11
                dtPersonal.Columns.Add("amaterno", Type.GetType("System.String")) ' 12
                dtPersonal.Columns.Add("sexo", Type.GetType("System.String")) ' 13
                dtPersonal.Columns.Add("imss", Type.GetType("System.String")) ' 14
                dtPersonal.Columns.Add("rfc", Type.GetType("System.String")) ' 15
                dtPersonal.Columns.Add("curp", Type.GetType("System.String")) ' 16
                dtPersonal.Columns.Add("sactual", Type.GetType("System.String")) ' 17
                dtPersonal.Columns.Add("alta", Type.GetType("System.String")) ' 18
                dtPersonal.Columns.Add("baja", Type.GetType("System.String")) ' 19
                dtPersonal.Columns.Add("cod_civil", Type.GetType("System.String")) ' 20
                dtPersonal.Columns.Add("direccion", Type.GetType("System.String")) ' 21
                dtPersonal.Columns.Add("colonia_nombre", Type.GetType("System.String")) ' 22
                dtPersonal.Columns.Add("ciudad_nombre", Type.GetType("System.String")) ' 23


                dtPersonal.Columns.Add("tipo_movimiento", Type.GetType("System.String"))
                dtPersonal.Columns.Add("linea", Type.GetType("System.Int32"))
                dtPersonal.Columns.Add("valido", Type.GetType("System.Int32"))

                'AUXILIARES
                dtPersonal.Columns.Add("reloj", Type.GetType("System.String"))
                dtPersonal.Columns.Add("nombres", Type.GetType("System.String"))

                dtPersonal.Columns.Add("alta_fecha", Type.GetType("System.DateTime"))
                dtPersonal.Columns.Add("baja_fecha", Type.GetType("System.DateTime"))

                dtPersonal.Columns.Add("imss_a", Type.GetType("System.String"))
                dtPersonal.Columns.Add("imss_b", Type.GetType("System.String"))

                dtPersonal.Columns.Add("cod_colonia", Type.GetType("System.String"))
                dtPersonal.Columns.Add("cod_ciudad", Type.GetType("System.String"))


                Dim package As ExcelPackage = New ExcelPackage
                Try
                    package = New ExcelPackage(New FileInfo(txtArchivoCarga.Text))
                Catch ex As Exception
                    MessageBox.Show("El archivo no pudo ser leido. Asegúrese de no estarlo utilizando en este momento", "Hubo un problema al leer el archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try

                Dim hoja_personal As ExcelWorksheet = package.Workbook.Worksheets(1)


                '********** validacion archivo de campos principales
                Dim validado As Boolean = True
                Dim mensaje_error As String = ""

                Dim valid_1 As String = hoja_personal.Cells(1, 1).Value
                If valid_1 = "reloj_alt" Then
                    Dim valid_2 As String = hoja_personal.Cells(1, 23).Value
                    If valid_2 = "ciudad_nombre" Then
                        Dim valid_3 As String = hoja_personal.Cells(2, 1).Value
                        If valid_3 = "Reloj alterno" Then
                            ' OK
                        Else
                            mensaje_error = "La información debe comenzar en la fila 3"
                            validado = False
                        End If
                    Else
                        mensaje_error = "La columna 23 debe contener el nombre de la ciudad"
                        validado = False
                    End If
                Else
                    mensaje_error = "La columna 1 debe contener el reloj alterno"
                    validado = False
                End If

                If validado = False Then
                    MessageBox.Show("El archivo no tiene el formato correcto. " & mensaje_error, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                '********** termina validacion


                Dim frm As New frmTrabajando
                frm.Text = "Leyendo archivo"
                frm.Show()

                Dim x As Integer = 3
                Dim continuar As Boolean = True

                While continuar
                    Application.DoEvents()
                    Dim reloj_alterno As String = hoja_personal.Cells(x, 1).Value
                    If reloj_alterno <> "" Then
                        frm.lblAvance.Text = reloj_alterno

                        Dim drow As DataRow = dtPersonal.NewRow


                        drow("reloj_alt") = reloj_alterno ' 1
                        drow("cod_depto") = hoja_personal.Cells(x, 2).Value ' 2
                        drow("cod_tipo") = hoja_personal.Cells(x, 3).Value ' 3
                        drow("cod_clase") = hoja_personal.Cells(x, 4).Value ' 4
                        drow("cod_super") = hoja_personal.Cells(x, 5).Value ' 5
                        drow("cod_hora") = hoja_personal.Cells(x, 6).Value ' 6
                        drow("cod_puesto") = hoja_personal.Cells(x, 7).Value ' 7
                        drow("tipo_periodo") = hoja_personal.Cells(x, 8).Value ' 8
                        drow("sindicalizado") = hoja_personal.Cells(x, 9).Value ' 9
                        drow("nombre") = hoja_personal.Cells(x, 10).Value ' 10
                        drow("apaterno") = hoja_personal.Cells(x, 11).Value ' 11
                        drow("amaterno") = hoja_personal.Cells(x, 12).Value ' 12
                        drow("sexo") = hoja_personal.Cells(x, 13).Value ' 13
                        drow("imss") = hoja_personal.Cells(x, 14).Value ' 14
                        drow("rfc") = hoja_personal.Cells(x, 15).Value ' 15
                        drow("curp") = hoja_personal.Cells(x, 16).Value ' 16
                        drow("sactual") = hoja_personal.Cells(x, 17).Value ' 17
                        drow("alta") = hoja_personal.Cells(x, 18).Value ' 18
                        drow("baja") = hoja_personal.Cells(x, 19).Value ' 19
                        drow("cod_civil") = hoja_personal.Cells(x, 20).Value ' 20
                        drow("direccion") = hoja_personal.Cells(x, 21).Value ' 21
                        drow("colonia_nombre") = hoja_personal.Cells(x, 22).Value ' 22
                        drow("ciudad_nombre") = hoja_personal.Cells(x, 23).Value ' 23     
                        drow("linea") = x
                        drow("valido") = 0
                        drow("tipo_movimiento") = "X"

                        dtPersonal.Rows.Add(drow)

                    Else
                        continuar = False
                    End If
                    x += 1
                End While

                Dim altas As Integer = 0
                Dim bajas As Integer = 0
                Dim cambios As Integer = 0

                Dim altas_string As String = ""
                Dim bajas_string As String = ""

                For Each row As DataRow In dtPersonal.Rows
                    frm.lblAvance.Text = row("reloj_alt")
                    Application.DoEvents()

                    Dim dtExiste As DataTable = sqlExecute("select reloj, nombres from personalvw where reloj_alt = '" & row("reloj_alt") & "'")
                    If dtExiste.Rows.Count > 0 Then
                        row("nombres") = dtExiste.Rows(0)("nombres")
                        row("reloj") = dtExiste.Rows(0)("reloj")

                        Dim baja As String = IIf(IsDBNull(row("baja")), "", row("baja").ToString)
                        If baja.Trim <> "" Then
                            row("tipo_movimiento") = "B"
                            bajas += 1
                            bajas_string &= " - " & row("reloj_alt") & "," & row("nombres") & ", " & baja & vbCrLf
                        Else
                            row("tipo_movimiento") = "C"
                            cambios += 1
                        End If
                    Else
                        Dim nombres As String = ""
                        nombres &= RTrim(IIf(IsDBNull(row("apaterno")), "", row("apaterno"))) & ","
                        nombres &= RTrim(IIf(IsDBNull(row("amaterno")), "", row("amaterno"))) & ","
                        nombres &= RTrim(IIf(IsDBNull(row("nombre")), "", row("nombre")))
                        row("nombres") = nombres
                        row("tipo_movimiento") = "A"
                        altas += 1
                        altas_string &= " - " & row("reloj_alt") & ", " & row("nombres") & vbCrLf
                    End If


                Next

                ActivoTrabajando = False
                frm.Close()

                altas_string = ""
                bajas_string = ""

                Dim cod_comp As String = cmbCias.SelectedValue
                Dim dtDeptos As DataTable = sqlExecute("select distinct cod_depto from deptos where isnull(cod_depto, '') <> ''")
                Dim dtSuper As DataTable = sqlExecute("select distinct cod_super from super where isnull(cod_super, '') <> ''")
                Dim dtHorarios As DataTable = sqlExecute("select distinct cod_hora from horarios where isnull(cod_hora, '') <> ''")
                Dim dtPuestos As DataTable = sqlExecute("select distinct cod_puesto from puestos where isnull(cod_puesto, '') <> ''")


                If MessageBox.Show("¿Confirma que desea aplicar [" & (altas + bajas + cambios) & "] movimientos?" & _
                                   vbCrLf & altas & " Altas" & vbCrLf & altas_string & vbCrLf & _
                                   vbCrLf & bajas & " Bajas" & vbCrLf & bajas_string & vbCrLf & _
                                   vbCrLf & cambios & " Cambios / actualizaciones ", "Movimientos a aplicar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim valida_ok As Boolean = True
                    Dim valida_mensajes As String = ""


                    frm = New frmTrabajando
                    frm.Text = "Realizando validaciones"
                    frm.Show()

                    Dim linea As String = ""
                    For Each row As DataRow In dtPersonal.Select("", "linea")

                        Application.DoEvents()
                        frm.lblAvance.Text = row("reloj_alt")

                        Try
                            Dim tipo_movimiento As String = row("tipo_movimiento")


                            '******************* Validaciones

                            Dim cod_depto As String = RTrim(IIf(IsDBNull(row("cod_depto")), "", row("cod_depto"))).ToUpper
                            Dim cod_tipo As String = RTrim(IIf(IsDBNull(row("cod_tipo")), "", row("cod_tipo"))).ToUpper
                            Dim cod_clase As String = RTrim(IIf(IsDBNull(row("cod_clase")), "", row("cod_clase"))).ToUpper
                            Dim cod_puesto As String = RTrim(IIf(IsDBNull(row("cod_puesto")), "", row("cod_puesto"))).ToUpper
                            Dim cod_super As String = RTrim(IIf(IsDBNull(row("cod_super")), "", row("cod_super"))).ToUpper.PadLeft(3, "0")
                            Dim cod_hora As String = RTrim(IIf(IsDBNull(row("cod_hora")), "", row("cod_hora"))).ToUpper



                            Dim tipo_periodo As String = RTrim(IIf(IsDBNull(row("tipo_periodo")), "", row("tipo_periodo"))).ToUpper
                            Dim sindicalizado As Integer = RTrim(IIf(IsDBNull(row("sindicalizado")), "", row("sindicalizado"))).ToUpper
                            Dim sexo As String = RTrim(IIf(IsDBNull(row("sexo")), "", row("sexo"))).ToUpper

                            Dim cod_civil As String = RTrim(IIf(IsDBNull(row("cod_civil")), "", row("cod_civil"))).ToUpper & Space(1)
                            cod_civil = cod_civil.Substring(0, 1)

                            Dim nombre As String = RTrim(IIf(IsDBNull(row("nombre")), "", row("nombre"))).ToUpper
                            Dim apaterno As String = RTrim(IIf(IsDBNull(row("apaterno")), "", row("apaterno"))).ToUpper
                            Dim amaterno As String = RTrim(IIf(IsDBNull(row("amaterno")), "", row("amaterno"))).ToUpper

                            Dim imss_completo As String = RTrim(IIf(IsDBNull(row("imss")), "", row("imss"))).ToUpper
                            Dim rfc As String = RTrim(IIf(IsDBNull(row("rfc")), "", row("rfc"))).ToUpper
                            Dim curp As String = RTrim(IIf(IsDBNull(row("curp")), "", row("curp"))).ToUpper

                            Dim sactual As String = RTrim(IIf(IsDBNull(row("sactual")), "", row("sactual"))).ToUpper
                            Dim alta As String = RTrim(IIf(IsDBNull(row("alta")), "", row("alta"))).ToUpper
                            Dim baja As String = RTrim(IIf(IsDBNull(row("baja")), "", row("baja"))).ToUpper

                            Dim direccion As String = RTrim(IIf(IsDBNull(row("direccion")), "", row("direccion"))).ToUpper
                            Dim colonia_nombre As String = RTrim(IIf(IsDBNull(row("colonia_nombre")), "", row("colonia_nombre"))).ToUpper
                            Dim ciudad_nombre As String = RTrim(IIf(IsDBNull(row("ciudad_nombre")), "", row("ciudad_nombre"))).ToUpper


                            'VALIDA DEPARTAMENTO

                            If dtDeptos.Select("cod_depto = '" & cod_depto & "'").Any Then
                                row("cod_depto") = cod_depto
                            Else
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El departamento " & cod_depto & " del empleado " & row("reloj_alt") & " no es válido, favor de consultar el catálogo correspondiente." & vbCrLf
                                valida_ok = False
                            End If

                            'VALIDA TIPO y CLASE                        
                            If "A,O".Contains(cod_tipo) Then
                                row("cod_tipo") = cod_tipo
                            Else
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El tipo de empleado " & cod_tipo & " del empleado " & row("reloj_alt") & " no es válido." & vbCrLf
                                valida_ok = False
                            End If

                            If "A,G,D,I".Contains(cod_clase) Then
                                row("cod_clase") = cod_clase
                            Else
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "La clasificación " & cod_clase & " del empleado " & row("reloj_alt") & " no es válida." & vbCrLf
                                valida_ok = False
                            End If

                            'VALIDA PUESTO
                            If dtPuestos.Select("cod_puesto = '" & cod_puesto & "'").Any Then
                                row("cod_puesto") = cod_puesto
                            Else
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El puesto " & cod_puesto & " del empleado " & row("reloj_alt") & " no es válido, favor de consultar el catálogo correspondiente." & vbCrLf
                                valida_ok = False
                            End If


                            ' VALIDA SUPERVISOR                        
                            If dtSuper.Select("cod_super = '" & cod_super & "'").Any Then
                                row("cod_super") = cod_super
                            Else
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El supervisor " & cod_super & " del empleado " & row("reloj_alt") & " no es válido, favor de consultar el catálogo correspondiente." & vbCrLf
                                valida_ok = False
                            End If

                            ' VALIDA HORARIO                        
                            If dtHorarios.Select("cod_hora = '" & cod_hora & "'").Any Then
                                row("cod_hora") = cod_hora
                            Else
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El horario " & cod_hora & " del empleado " & row("reloj_alt") & " no es válido, favor de consultar el catálogo correspondiente." & vbCrLf
                                valida_ok = False
                            End If

                            'VALIDA tipo_periodo, sindicalizado, sexo y cod_civil

                            If "S,Q".Contains(tipo_periodo) Then
                                row("tipo_periodo") = tipo_periodo
                            Else
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El tipo de periodo " & tipo_periodo & " del empleado " & row("reloj_alt") & " no es válido." & vbCrLf
                                valida_ok = False
                            End If

                            If "1,0".Contains(sindicalizado) Then
                                row("sindicalizado") = sindicalizado
                            Else
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El valor sindicalizado " & sindicalizado & " del empleado " & row("reloj_alt") & " no es válido." & vbCrLf
                                valida_ok = False
                            End If

                            If "F,M".Contains(sexo) Then
                                row("sexo") = sexo
                            Else
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El sexo " & sexo & " del empleado " & row("reloj_alt") & " no es válido." & vbCrLf
                                valida_ok = False
                            End If

                            If "S,C,V,D,X,U".Contains(cod_civil) Then
                                row("cod_civil") = cod_civil
                            Else
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El estado civil " & cod_civil & " del empleado " & row("reloj_alt") & " no es válido." & vbCrLf
                                valida_ok = False
                            End If

                            'VALIDA NOMBRES
                            If nombre <> "" Then
                                row("nombre") = nombre
                            Else
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El nombre " & nombre & " del empleado " & row("reloj_alt") & " no es válido." & vbCrLf
                                valida_ok = False
                            End If

                            If apaterno <> "" Then
                                row("apaterno") = apaterno
                            Else
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El apellido paterno " & apaterno & " del empleado " & row("reloj_alt") & " no es válido." & vbCrLf
                                valida_ok = False
                            End If

                            row("amaterno") = amaterno

                            row("nombres") = apaterno & "," & amaterno & "," & nombre

                            'VALIDA IDS
                            If imss_completo.Trim.Length <> 11 Then
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El identificador IMSS " & imss_completo & " del empleado " & row("reloj_alt") & " no tiene la longitud esperada (11)." & vbCrLf
                                valida_ok = False
                            Else
                                Dim imss_a As String = imss_completo.Substring(0, 10)
                                Dim imss_b As String = imss_completo.Substring(10, 1)

                                row("imss_a") = imss_a
                                row("imss_b") = imss_b
                            End If

                            If rfc.Trim.Length <> 13 Then
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El identificador RFC " & rfc & " del empleado " & row("reloj_alt") & " no tiene la longitud esperada (13)." & vbCrLf
                                valida_ok = False
                            Else
                                row("rfc") = rfc
                            End If

                            If curp.Trim.Length <> 18 Then
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El identificador CURP " & rfc & " del empleado " & row("reloj_alt") & " no tiene la longitud esperada (18)." & vbCrLf
                                valida_ok = False
                            Else
                                row("curp") = curp
                            End If

                            'VALIDA SACTUAL
                            Try
                                Dim sactual_doble As Double = Double.Parse(sactual)
                            Catch ex As Exception
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "El salario " & sactual & " del empleado " & row("reloj_alt") & " no es válido." & vbCrLf
                                valida_ok = False
                            End Try

                            'VALIDA ALTA & BAJA
                            Try
                                Dim alta_fecha As Date = Date.Parse(alta)
                                row("alta_fecha") = alta_fecha
                            Catch ex As Exception
                                valida_mensajes &= "Fila [" & row("linea") & "]." & "La fecha de alta" & alta & " del empleado " & row("reloj_alt") & " no es válida." & vbCrLf
                                valida_ok = False
                            End Try

                            If tipo_movimiento = "B" Then
                                Try
                                    Dim baja_fecha As Date = Date.Parse(baja)
                                    row("baja_fecha") = baja_fecha
                                Catch ex As Exception
                                    valida_mensajes &= "Fila [" & row("linea") & "]." & "La fecha de baja" & baja & " del empleado " & row("reloj_alt") & " no es válida." & vbCrLf
                                    valida_ok = False
                                End Try
                            End If

                            row("direccion") = direccion

                            '************************************************

                            row("valido") = 1

                        Catch ex As Exception
                            valida_ok = False
                            valida_mensajes &= "Fila [" & row("linea") & "]." & "Error no identificado. " & ex.Message & vbCrLf
                        End Try

                    Next


                    ActivoTrabajando = False
                    frm.Close()

                    If Not valida_ok Then
                        Dim sfd As New SaveFileDialog
                        sfd.FileName = "Errores encontrados"
                        sfd.Filter = "Archivo de texto|*.txt"
                        sfd.Title = "Se encontraron errores en el archivo a cargar"
                        If sfd.ShowDialog() Then
                            Dim file As System.IO.StreamWriter
                            file = My.Computer.FileSystem.OpenTextFileWriter(sfd.FileName, False)
                            file.WriteLine(Now.ToString & vbCrLf & valida_mensajes)
                            file.Close()
                            MessageBox.Show("Archivo de errores generado en " & sfd.FileName, "Errores encontrados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    Else


                        frm = New frmTrabajando
                        frm.Text = "Aplicando"
                        frm.Show()

                        Dim movimientos_aplicados As Integer = 0


                        dtMovimientosAplicados = New DataTable
                        dtMovimientosAplicados.Columns.Add("id")
                        dtMovimientosAplicados.Columns.Add("tipo_movimiento")
                        dtMovimientosAplicados.Columns.Add("reloj")
                        dtMovimientosAplicados.Columns.Add("reloj_alt")
                        dtMovimientosAplicados.Columns.Add("nombre")
                        dtMovimientosAplicados.Columns.Add("campo")
                        dtMovimientosAplicados.Columns.Add("valor")


                        For Each row As DataRow In dtPersonal.Select("valido = 1")
                            Dim tipo_movimiento As String = row("tipo_movimiento")
                            Dim reloj_ As String = ""
                            Dim reloj_alt As String = row("reloj_alt").ToString.Trim
                            Dim _fecAlt As String = RTrim(IIf(IsDBNull(row("alta")), "", row("alta"))).ToUpper
                            Dim _FecBaj As String = RTrim(IIf(IsDBNull(row("baja")), "", row("baja"))).ToUpper
                            Dim bandCanc As Boolean = False
                            Dim tipo As Integer = 0

                            Try
                                Application.DoEvents()
                                frm.lblAvance.Text = row("reloj_alt")

                                'Validar fecha de alta original VS la que viene en el archivo para saber si es Canc de baja o Reingreso
                                bandCanc = False
                                Dim FAOrig As Date
                                Dim FBOrig As String = ""
                                Dim _fecBajaOrig As Date
                                Dim dtAlta As New DataTable
                                dtAlta = sqlExecute("SELECT alta,baja from personalvw where reloj_alt='" & reloj_alt & "'", "PERSONAL")
                                If dtAlta.Rows.Count > 0 Then
                                    FAOrig = Date.Parse(dtAlta.Rows(0).Item("alta").ToString.Trim)
                                    FBOrig = RTrim(IIf(IsDBNull(dtAlta.Rows(0).Item("baja")), "", dtAlta.Rows(0).Item("baja"))).ToUpper
                                End If

                                '---Saber si es Cancelacion de baja
                                If ((FAOrig = Date.Parse(row("alta_fecha"))) And _FecBaj = "" And FBOrig <> "") Then
                                    bandCanc = True
                                    tipo = 1
                                End If
                                '--Saber si es Reingreso
                                If ((FAOrig <> Date.Parse(row("alta_fecha"))) And _FecBaj = "" And FBOrig <> "") Then
                                    _fecBajaOrig = Date.Parse(FBOrig)
                                    bandCanc = True
                                    tipo = 2
                                End If

                                '--ENDS

                                If tipo_movimiento = "A" Then
                                    reloj_ = 800000
                                    Dim dtUltimo As DataTable = sqlExecute("select reloj from personal where cod_comp = '" & cmbCias.SelectedValue & "' order by reloj desc")
                                    If dtUltimo.Rows.Count > 0 Then
                                        reloj_ = Integer.Parse(dtUltimo.Rows(0)("reloj")) + 1
                                    End If

                                    sqlExecute("insert into personal (reloj, reloj_alt) values ('" & reloj_ & "', '" & row("reloj_alt") & "')")


                                    Dim drow As DataRow = dtMovimientosAplicados.NewRow
                                    drow("id") = movimientos_aplicados
                                    drow("tipo_movimiento") = tipo_movimiento
                                    drow("reloj") = reloj_
                                    drow("reloj_alt") = row("reloj_alt")
                                    drow("nombre") = row("nombres")
                                    drow("campo") = "alta"
                                    drow("valor") = FechaSQL(row("alta_fecha"))
                                    dtMovimientosAplicados.Rows.Add(drow)

                                ElseIf tipo_movimiento = "C" Or tipo_movimiento = "B" Then
                                    reloj_ = row("reloj")
                                End If

                                If bandCanc = True Then '-Si es cancelación de baja O Reingreso
                                    reloj_ = row("reloj").ToString.Trim
                                    reloj_alt = row("reloj_alt").ToString.Trim
                                    tipo_movimiento = "R"
                                    Dim fecEfec As Date = dtpFechaEfectiva.Value
                                    actCancBaja(reloj_, "alta", FechaSQL(row("alta_fecha")), row("alta_fecha"), tipo_movimiento, reloj_alt, tipo, fecEfec, FAOrig, _fecBajaOrig, movimientos_aplicados)
                                End If

                                If tipo_movimiento = "A" Or tipo_movimiento = "R" Then
                                    actualiza_valor_personal(reloj_, "alta", FechaSQL(row("alta_fecha")), row("alta_fecha"), tipo_movimiento)
                                    actualiza_valor_personal(reloj_, "baja", "null", row("alta_fecha"), tipo_movimiento)
                                End If

                                If tipo_movimiento = "A" Or tipo_movimiento = "C" Or tipo_movimiento = "R" Then

                                    Dim fecha_efectiva As Date = IIf(tipo_movimiento = "A" Or tipo_movimiento = "R", row("alta_fecha"), dtpFechaEfectiva.Value)

                                    actualiza_valor_personal(reloj_, "cod_comp", cmbCias.SelectedValue, fecha_efectiva, tipo_movimiento)

                                    'PARA QTO OH estos valores son fijos
                                    actualiza_valor_personal(reloj_, "cod_planta", "001", fecha_efectiva, tipo_movimiento)
                                    actualiza_valor_personal(reloj_, "cod_turno", "0", fecha_efectiva, tipo_movimiento)

                                    actualiza_valor_personal(reloj_, "cod_depto", row("cod_depto"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "cod_tipo", row("cod_tipo"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "cod_clase", row("cod_clase"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "cod_puesto", row("cod_puesto"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "cod_super", row("cod_super"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "cod_hora", row("cod_hora"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)

                                    actualiza_valor_personal(reloj_, "tipo_periodo", row("tipo_periodo"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "sindicalizado", row("sindicalizado"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "sexo", row("sexo"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "cod_civil", row("cod_civil"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)

                                    actualiza_valor_personal(reloj_, "nombre", row("nombre"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "apaterno", row("apaterno"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "amaterno", row("amaterno"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)

                                    actualiza_valor_personal(reloj_, "imss", row("imss_a"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "dig_ver", row("imss_b"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "rfc", row("rfc"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "curp", row("curp"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)


                                    actualiza_valor_personal(reloj_, "sactual", row("sactual"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "factor_int", 1.0, fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "pro_var", 0.0, fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)
                                    actualiza_valor_personal(reloj_, "integrado", row("sactual"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)

                                    actualiza_valor_personal(reloj_, "direccion", row("direccion"), fecha_efectiva, tipo_movimiento, reloj_alt, movimientos_aplicados)

                                    'Dim colonia_nombre As String = RTrim(IIf(IsDBNull(row("colonia_nombre")), "", row("colonia_nombre"))).ToUpper
                                    'Dim ciudad_nombre As String = RTrim(IIf(IsDBNull(row("ciudad_nombre")), "", row("ciudad_nombre"))).ToUpper
                                End If

                                If tipo_movimiento = "B" Then

                                    Dim drow As DataRow = dtMovimientosAplicados.NewRow
                                    drow("id") = movimientos_aplicados
                                    drow("tipo_movimiento") = tipo_movimiento
                                    drow("reloj") = reloj_
                                    drow("reloj_alt") = row("reloj_alt")
                                    drow("nombre") = row("nombres")
                                    drow("campo") = "baja"
                                    drow("valor") = FechaSQL(row("baja_fecha"))
                                    dtMovimientosAplicados.Rows.Add(drow)

                                    actualiza_valor_personal(reloj_, "baja", FechaSQL(row("baja_fecha")), row("baja_fecha"), tipo_movimiento)
                                End If
                                movimientos_aplicados += 1
                            Catch ex As Exception

                            End Try

                        Next

                        ActivoTrabajando = False
                        frm.Close()

                        MessageBox.Show(movimientos_aplicados & " movimientos aplicados", "Proceso concluido", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        Dim sfd As New SaveFileDialog
                        sfd.Filter = "Archivo de excel|*.xlsx"
                        sfd.Title = "Movimientos aplicados"
                        sfd.FileName = "Movimientos aplicados " & FechaSQL(Now.Date).Replace("-", "")
                        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                            If ExportaExcelOpenXML(dtMovimientosAplicados, sfd.FileName, "Movimientos aplicados " & cmbCias.SelectedValue & ", " & FechaSQL(Now.Date)) Then
                                MessageBox.Show("Archivo generado en " & sfd.FileName, "Movimientos aplicados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If

                    End If


                Else
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function ExportaExcelOpenXML(dtDatos As DataTable, file_name As String, titulo As String) As Boolean

        Dim frm As New frmTrabajando
        frm.Show()

        Try

            Dim archivo As ExcelPackage = New ExcelPackage()
            Dim wb As ExcelWorkbook = archivo.Workbook

            Dim hoja_personal As ExcelWorksheet = wb.Worksheets.Add("Sistema PIDA")

            Dim row As Integer = 3
            Dim col As Integer = 1

            For Each column As DataColumn In dtDatos.Columns
                Application.DoEvents()

                hoja_personal.Cells(row, col).Value = column.ColumnName
                hoja_personal.Cells(row, col).Style.Font.Bold = True
                col += 1
            Next
            row += 1

            For Each drow As DataRow In dtDatos.Rows
                col = 1
                For Each column As DataColumn In dtDatos.Columns
                    Application.DoEvents()
                    hoja_personal.Cells(row, col).Value = drow(column.ColumnName)
                    col += 1
                Next
                row += 1
            Next


            hoja_personal.Cells(hoja_personal.Dimension.Address).AutoFitColumns()

            hoja_personal.Cells(1, 1).Value = titulo
            hoja_personal.Cells(1, 1).Style.Font.Bold = True
            hoja_personal.Cells(1, 1).Style.Font.Size = 14


            archivo.SaveAs(New System.IO.FileInfo(file_name))

            ActivoTrabajando = False
            frm.Close()

            Return True

        Catch ex As Exception

            ActivoTrabajando = False
            frmTrabajando.Close()

            Return False
        End Try

    End Function



    Private Sub actualiza_valor_personal(reloj_ As String, campo_ As String, valor_ As String, fecha_ As Date, tipo_movimiento As String, Optional reloj_alt As String = "", Optional n_movimiento As Integer = -1)
        Try

            Dim valor_anterior As String = ""
            Dim aplicar As Boolean = True
            Dim nombres As String = ""

            If tipo_movimiento = "C" Then

                Dim dtPersonal As DataTable = sqlExecute("select " & campo_ & ", nombres from personalvw where reloj = '" & reloj_ & "'")
                If dtPersonal.Rows.Count > 0 Then
                    nombres = dtPersonal.Rows(0)("nombres")
                    valor_anterior = IIf(IsDBNull(dtPersonal.Rows(0)(campo_)), "", dtPersonal.Rows(0)(campo_))
                    If valor_.Trim.ToUpper = valor_anterior.Trim.ToUpper Then
                        aplicar = False
                    End If
                End If

            End If



            If aplicar Then

                Dim valor_aplica As String = ""

                If valor_.ToLower = "null" Then
                    valor_aplica = valor_
                Else
                    valor_aplica = "'" & valor_ & "'"
                End If

                sqlExecute("update personal set " & campo_ & " = " & valor_aplica & " where reloj = '" & reloj_ & "'")
                sqlExecute("insert into bitacora_personal (reloj, campo, valoranterior, valornuevo, fecha, fecha_mantenimiento, tipo_movimiento, usuario, mantenimiento) values " & _
                           "('" & reloj_ & "', '" & campo_ & "', '" & valor_anterior & "', '" & valor_ & "', '" & FechaSQL(fecha_) & "', getdate(), '" & tipo_movimiento & "', '" & Usuario & "', '1')")

                If tipo_movimiento = "C" And n_movimiento >= 0 Then
                    Dim drow As DataRow = dtMovimientosAplicados.NewRow
                    drow("id") = n_movimiento
                    drow("tipo_movimiento") = tipo_movimiento
                    drow("reloj") = reloj_
                    drow("reloj_alt") = reloj_alt
                    drow("nombre") = nombres
                    drow("campo") = campo_
                    drow("valor") = valor_
                    dtMovimientosAplicados.Rows.Add(drow)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub actCancBaja(reloj_ As String, campo_ As String, valor_ As String, fecha_ As Date, tipo_movimiento As String, reloj_alt As String, _mTipo As Integer, _FecEfec As Date, _FecAltaAnt As Date, _fecBajaAnt As Date, Optional n_movimiento As Integer = -1)
        Try
            Dim valor_anterior As String = ""
            Dim aplicar As Boolean = True
            Dim nombres As String = ""
            Dim FecAltAnt As Date
            Dim FecBajaAnt As Date
            Dim FecAltaNew As Date
            FecAltAnt = _FecAltaAnt
            FecBajaAnt = _fecBajaAnt
            FecAltaNew = Date.Parse(valor_)


            Dim dtPersonal As DataTable = sqlExecute("select " & campo_ & ", nombres from personalvw where reloj = '" & reloj_ & "'")
            If dtPersonal.Rows.Count > 0 Then
                nombres = dtPersonal.Rows(0)("nombres")
                valor_anterior = IIf(IsDBNull(dtPersonal.Rows(0)(campo_)), "", dtPersonal.Rows(0)(campo_))
            End If

            Select Case _mTipo
                Case 1 '-------Cancelar Bajas
                    If MessageBox.Show("¿Está seguro de cancelar la baja del empleado " & reloj_ & "?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        '--------Hacer todo el codigo
                        sqlExecute("update personal set baja=null,cod_mot_ba=null,COD_MOT_IM=null, cod_sub_ba=null,fh_baja_imss=null where reloj='" & reloj_ & "'")

                    End If
                Case 2 '--Actualizar Reingresos
                    sqlExecute("update personal set alta='" & FechaSQL(valor_) & "', baja=null,cod_mot_ba=null,COD_MOT_IM=null, cod_sub_ba=null,fh_baja_imss=null where reloj='" & reloj_ & "'", "PERSONAL")
                    sqlExecute("INSERT INTO reingresos (reloj,fecha,alta_ant,baja_ant,cod_mot_ba,cod_mot_im,alta) VALUES('" & reloj_ & "','" & FechaSQL(_FecEfec) & "','" & FechaSQL(FecAltAnt) & "','" & FechaSQL(FecBajaAnt) & "','','','" & FechaSQL(FecAltaNew) & "')", "PERSONAL")
            End Select

            Dim drow As DataRow = dtMovimientosAplicados.NewRow
            drow("id") = n_movimiento
            drow("tipo_movimiento") = tipo_movimiento
            drow("reloj") = reloj_
            drow("reloj_alt") = reloj_alt
            drow("nombre") = nombres
            drow("campo") = campo_
            drow("valor") = valor_
            dtMovimientosAplicados.Rows.Add(drow)


        Catch ex As Exception

        End Try

    End Sub

End Class