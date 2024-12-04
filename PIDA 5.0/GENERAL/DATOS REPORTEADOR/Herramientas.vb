Option Compare Text

Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Module Herramientas
    Public Sub EntregaUniformes(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            ' *****Agregar columnas del DataTable las cuales son los campos en el reporte, deben de tener el mismo nombre
            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("cod_comp")
            dtDatos.Columns.Add("cod_area")
            dtDatos.Columns.Add("descrip_area")
            dtDatos.Columns.Add("cod_puesto")
            dtDatos.Columns.Add("descrip_puesto")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("alta")
            dtDatos.Columns.Add("f_ult_entrega")
            dtDatos.Columns.Add("rango")
            dtDatos.Columns.Add("descrip_rango")
            dtDatos.Columns.Add("nombre_puesto")
            dtDatos.Columns.Add("f_Ini")
            dtDatos.Columns.Add("f_Fin")
            dtDatos.Columns.Add("talla_play")
            dtDatos.Columns.Add("talla_pant")
            dtDatos.Columns.Add("cod_cond")
            dtDatos.Columns.Add("articulo")
            dtDatos.Columns.Add("cantidad")
            dtDatos.Columns.Add("antig_meses")
            dtDatos.Columns.Add("sexo")
            dtDatos.Columns.Add("tipo_puesto")
            dtDatos.Columns.Add("reloj_alt")
            '*****Definir Variables 

            '****Definir rangos de fecha inicio y fin
            Dim _fini As Date = Now.Date
            Dim _ffin As Date = _fini.AddDays(7).Date

            Dim frm As New frmRangoFechas
            If frm.ShowDialog = DialogResult.OK Then
                _fini = FechaInicial
                _ffin = FechaFinal
            End If

            'Mostrar avance de resultados
            frmTrabajando.Show()
            Application.DoEvents()

            '********Definir DT que vamos a utilizar en el programa los cuales van  a contener la info para poder irla mostrando
            '---Jalar a todo el personal que este activo, el cual va  a ser nuestro universo para ir metiendo cada registro
            '   Dim dtPersvw As DataTable = sqlExecute("select * from personalvw where cod_comp IN('610','002') and baja is null")

            '---Obtener de la tabla de uniformes los registros
            Dim dtUnifEmplvw As DataTable = sqlExecute("SELECT * FROM UniformesEmpleadosVW", "HERRAMIENTAS")

            '---Obtener las condiciones de entrega de uniforme
            Dim dtCondEntrUnif As DataTable = sqlExecute("select * from cond_entrega_unif", "HERRAMIENTAS")


            '---Ir analizando cada uno de los registros de nuestro Universo para irlos ingresando al reporte e irles asignando sus valores correspondientes para clasificarlos
            '  For Each Row As DataRow In dtPersvw.Rows
            For Each Row As DataRow In dtInformacion.Rows

                frmTrabajando.lblAvance.Text = Row("reloj")
                Application.DoEvents()

                '---Ir asignando los valores al registro que estemos analizando en ese momento
                Dim drow As DataRow = dtDatos.NewRow
                drow("reloj") = Row("reloj")
                drow("cod_comp") = Row("cod_comp")
                drow("cod_area") = Row("cod_area")
                drow("descrip_area") = Row("nombre_area")
                drow("cod_puesto") = Row("cod_puesto")
                drow("descrip_puesto") = Row("nombre_puesto")
                drow("nombres") = Row("nombres")
                drow("alta") = FechaSQL(Row("alta"))
                drow("rango") = "" 'No cae en ningun rango
                'Para mandar las fechas inicio y fin al reporte
                drow("f_Ini") = FechaSQL(_fini)
                drow("f_Fin") = FechaSQL(_ffin)
                'New Items
                drow("cod_cond") = ""
                drow("articulo") = ""
                drow("cantidad") = ""
                drow("antig_meses") = ""
                drow("sexo") = Row("sexo")
                drow("tipo_puesto") = ""
                drow("reloj_alt") = IIf((drow("cod_comp") = "002"), Row("reloj_alt"), "")

                '--Conocer si el empleado cae en algun rango de antiguedad de los que mandó el cliente
                ' select * from cond_entrega_unif where antig_meses=3 and area_cond like'%04%' and puesto_cond like'%%'

                '--Recien ingresos de 0 a 31 días
                Dim difDias As Integer = DateDiff(DateInterval.Day, Row("alta"), _fini)
                If (difDias <= 31) Then
                    ' Buscar en el rango de antig de 1 Mes
                    Dim drow_1Mes As DataRow = Nothing
                    Try
                        drow_1Mes = dtCondEntrUnif.Select("antig_meses=1 and area_cond like'%" & drow("cod_area").ToString.Trim & "%' and puesto_cond like'%" & drow("cod_puesto").ToString.Trim & "%'")(0) ' Faltaria buscar x el puesto
                    Catch ex As Exception
                    End Try

                    If Not IsNothing(drow_1Mes) Then
                        drow("rango") = "A"  'Cae en el Rango de 3 Meses cumplidos
                        drow("descrip_rango") = "0 - 1 Mes"
                        drow("cod_cond") = drow_1Mes("COD_COND").ToString.Trim
                        drow("articulo") = drow_1Mes("ARTICULO").ToString.Trim
                        drow("cantidad") = drow_1Mes("CANTIDAD").ToString.Trim
                        drow("antig_meses") = drow_1Mes("ANTIG_MESES")
                        drow("tipo_puesto") = drow_1Mes("tipo_puesto").ToString.Trim
                    End If
                    GoTo Continuar
                End If

                '----3 Meses cumplidos

                Dim _fec3M As Date ' Rango 3 meses cumplidos
                _fec3M = DateAdd("m", 3, Row("alta"))
                If ((_fec3M >= _fini) And (_fec3M <= _ffin)) Then

                    Dim drow_3Mes As DataRow = Nothing
                    Try
                        drow_3Mes = dtCondEntrUnif.Select("antig_meses=3 and area_cond like'%" & drow("cod_area").ToString.Trim & "%' and puesto_cond like'%" & drow("cod_puesto").ToString.Trim & "%'")(0)
                    Catch ex As Exception
                    End Try
                    If Not IsNothing(drow_3Mes) Then
                        drow("rango") = "B"
                        drow("descrip_rango") = "3 Meses"
                        drow("cod_cond") = drow_3Mes("COD_COND").ToString.Trim
                        drow("articulo") = drow_3Mes("ARTICULO").ToString.Trim
                        drow("cantidad") = drow_3Mes("CANTIDAD").ToString.Trim
                        drow("antig_meses") = drow_3Mes("ANTIG_MESES")
                        drow("tipo_puesto") = drow_3Mes("tipo_puesto").ToString.Trim
                    End If
                    GoTo Continuar
                End If

                ' Rango 6 meses cumplidos
                Dim _fec6M As Date
                _fec6M = DateAdd("m", 6, Row("alta"))
                If ((_fec6M >= _fini) And (_fec6M <= _ffin)) Then

                    Dim drow_6Mes As DataRow = Nothing
                    Try
                        drow_6Mes = dtCondEntrUnif.Select("antig_meses=6 and area_cond like'%" & drow("cod_area").ToString.Trim & "%' and puesto_cond like'%" & drow("cod_puesto").ToString.Trim & "%'")(0)
                    Catch ex As Exception
                    End Try
                    If Not IsNothing(drow_6Mes) Then
                        drow("rango") = "C"  'Cae en el Rango de 3 Meses cumplidos
                        drow("descrip_rango") = "6 Meses"
                        drow("cod_cond") = drow_6Mes("COD_COND").ToString.Trim
                        drow("articulo") = drow_6Mes("ARTICULO").ToString.Trim
                        drow("cantidad") = drow_6Mes("CANTIDAD").ToString.Trim
                        drow("antig_meses") = drow_6Mes("ANTIG_MESES")
                        drow("tipo_puesto") = drow_6Mes("tipo_puesto").ToString.Trim
                    End If
                    GoTo Continuar
                End If

                ' Aniversario Cumplido
                Dim x As Integer = 0
                Dim _fecMasAniv As Date
                For x = 1 To 10
                    _fecMasAniv = DateAdd("m", (12 * x), Row("alta"))
                    If ((_fecMasAniv >= _fini) And (_fecMasAniv <= _ffin)) Then
                        Dim drow_Aniv As DataRow = Nothing
                        Try
                            drow_Aniv = dtCondEntrUnif.Select("antig_meses=12 and area_cond like'%" & drow("cod_area").ToString.Trim & "%' and puesto_cond like'%" & drow("cod_puesto").ToString.Trim & "%'")(0)
                        Catch ex As Exception
                        End Try
                        If Not IsNothing(drow_Aniv) Then
                            drow("rango") = "D" 'Cae en el Rango de 3 Meses cumplidos
                            drow("descrip_rango") = "Aniversario"
                            drow("cod_cond") = drow_Aniv("COD_COND").ToString.Trim
                            drow("articulo") = drow_Aniv("ARTICULO").ToString.Trim
                            drow("cantidad") = drow_Aniv("CANTIDAD").ToString.Trim
                            drow("antig_meses") = drow_Aniv("ANTIG_MESES")
                            drow("tipo_puesto") = drow_Aniv("tipo_puesto").ToString.Trim
                        End If
                        GoTo Continuar
                    End If
                Next

                ' ********Cumplido el aniversario (1 Año o mas)

Continuar:

                If drow("rango") <> "" Then ' Si tiene definido un rango procedemos a insertar el registro completo

                    '****Obtener Fecha Ultima entrega
                    Dim drow_fhaEntrUnif As DataRow = Nothing
                    Try
                        drow_fhaEntrUnif = dtUnifEmplvw.Select("reloj ='" & drow("reloj") & "'")(0)
                    Catch ex As Exception

                    End Try
                    If Not IsNothing(drow_fhaEntrUnif) Then
                        drow("f_ult_entrega") = FechaSQL(drow_fhaEntrUnif("fecha_ent")) 'Va a ser la fecha de entrega para ese empleado la que este en Uniformes

                    Else ' Si el empleado no esta registrado su fecha de uniforme dejarlo Nulo
                        drow("f_ult_entrega") = ""
                    End If

                    '****Obtener talla de la playera y pantalon
                    Dim drow_tallPlay As DataRow = Nothing
                    Dim drow_tallPant As DataRow = Nothing
                    Try
                        drow_tallPlay = dtUnifEmplvw.Select("reloj ='" & drow("reloj") & "' and cod_unif='PLAY001'")(0)
                        drow_tallPant = dtUnifEmplvw.Select("reloj ='" & drow("reloj") & "' and cod_unif='PANT001'")(0)
                    Catch ex As Exception
                    End Try


                    If Not IsNothing(drow_tallPlay) Then
                        drow("talla_play") = drow_tallPlay("talla")
                    Else
                        drow("talla_play") = ""
                    End If

                    If Not IsNothing(drow_tallPant) Then
                        drow("talla_pant") = drow_tallPant("talla")
                    Else
                        drow("talla_pant") = ""
                    End If
                    dtDatos.Rows.Add(drow) 'Agregar el registro completo
                End If

            Next
            '----Termina de analizar al registro y se va al otro si es que hay otro registro
            ActivoTrabajando = False ' Desactivamos el LOADING
            frmTrabajando.Close()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            ActivoTrabajando = False 'Desactivamos el LOADING en caso de que caiga en un TRY CATCH
            frmTrabajando.Close()

        End Try
    End Sub

    Public Sub EntregaUniformes_resumen(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            'Declaración de variables
            Dim _NumReloj As String = ""
            Dim _codArea As String = ""
            Dim _codPuesto As String = ""
            Dim _descripArea As String = ""
            Dim _tipoUnif As String = ""
            Dim tallaPlay As String = ""
            Dim tallaPant As String = ""
            Dim _color As String = ""
            Dim _cantidad As String = ""
            Dim _rangoAntig As String = ""
            Dim _tpoArtBT As String = ""
            Dim _cantBT As Integer = 0
            Dim _tpoArtML As String = ""
            Dim _cantML As Integer = 0
            Dim _tpoArtMC As String = ""
            Dim _cantMC As Integer = 0
            Dim _tpoArtP As String = ""
            Dim _cantP As Integer = 0
            Dim _tpoArtC As String = ""
            Dim _cantC As Integer = 0



            '****Definir rangos de fecha inicio y fin
            Dim _fini As Date = Now.Date
            Dim _ffin As Date = _fini.AddDays(7).Date

            Dim frm As New frmRangoFechas
            If frm.ShowDialog = DialogResult.OK Then
                _fini = FechaInicial
                _ffin = FechaFinal
            End If

            'Mostrar avance de resultados
            frmTrabajando.Show()
            Application.DoEvents()

            '---Jalar a todo el personal que este activo, el cual va  a ser nuestro universo para ir metiendo cada registro
            Dim dtPersvw As DataTable = sqlExecute("select reloj,COD_COMP,COD_PUESTO,cod_area,nombre_area,ALTA from personalvw where baja is null and cod_comp in('610','002')")

            '---Obtener de la tabla de uniformes los registros para obtener la talla
            Dim dtUnifEmplvw As DataTable = sqlExecute("select RELOJ,COD_UNIF,uniforme,TALLA from UniformesEmpleadosVW", "HERRAMIENTAS")

            '---Obtener las condiciones de entrega de uniforme
            Dim dtCondEntrUnif As DataTable = sqlExecute("select * from cond_entrega_unif", "HERRAMIENTAS")

            '--Eliminar todos los registros que haya en la tabla que llena el resumen para el reporte
            sqlExecute("delete from entrega_unif_resumen", "HERRAMIENTAS")

            'Ir analizando a cada uno de los empleados para obtener su info
            For Each Row As DataRow In dtPersvw.Rows
                frmTrabajando.lblAvance.Text = Row("reloj")
                Application.DoEvents()

                'Mandar las variables que podemos obtener
                _NumReloj = Row("RELOJ").ToString.Trim
                _codArea = Row("cod_area").ToString.Trim
                _codPuesto = Row("cod_puesto").ToString.Trim
                _descripArea = Row("nombre_area").ToString.Trim
                _rangoAntig = "" ' Inicializar rango para cada empleado

                'Saber si cae en algun rango de antiguedad para saber si metermos a este registro
                '--Recien ingresos de 0 a 31 días
                Dim difDias As Integer = Math.Abs(DateDiff(DateInterval.Day, Row("alta"), _fini))
                If (difDias <= 31) Then
                    ' Buscar en el rango de antig de 1 Mes

                    Dim drow_1Mes As DataRow = Nothing
                    Try
                        drow_1Mes = dtCondEntrUnif.Select("antig_meses=1 and area_cond like'%" & _codArea & "%' and puesto_cond like'%" & _codPuesto & "%'")(0) ' Faltaria buscar x el puesto
                    Catch ex As Exception
                    End Try

                    If Not IsNothing(drow_1Mes) Then
                        _rangoAntig = "A"  'Cae en el Rango de 1 mes cumplido
                        _color = drow_1Mes("ARTICULO").ToString.Trim
                        _cantidad = drow_1Mes("CANTIDAD").ToString.Trim

                    End If
                    GoTo Continuar
                End If

                ' Antig = 3 Meses
                Dim _fec3M As Date ' Rango 3 meses cumplidos
                _fec3M = DateAdd("m", 3, Row("alta"))
                If ((_fec3M >= _fini) And (_fec3M <= _ffin)) Then

                    Dim drow_3Mes As DataRow = Nothing
                    Try
                        drow_3Mes = dtCondEntrUnif.Select("antig_meses=3 and area_cond like'%" & _codArea & "%' and puesto_cond like'%" & _codPuesto & "%'")(0)
                    Catch ex As Exception
                    End Try
                    If Not IsNothing(drow_3Mes) Then
                        _rangoAntig = "B"
                        _color = drow_3Mes("ARTICULO").ToString.Trim
                        _cantidad = drow_3Mes("CANTIDAD").ToString.Trim
                    End If
                    GoTo Continuar
                End If

                ' Antig = 6 Meses
                Dim _fec6M As Date ' Rango 3 meses cumplidos
                _fec6M = DateAdd("m", 6, Row("alta"))
                If ((_fec6M >= _fini) And (_fec6M <= _ffin)) Then

                    Dim drow_6Mes As DataRow = Nothing
                    Try
                        drow_6Mes = dtCondEntrUnif.Select("antig_meses=6 and area_cond like'%" & _codArea & "%' and puesto_cond like'%" & _codPuesto & "%'")(0)
                    Catch ex As Exception
                    End Try
                    If Not IsNothing(drow_6Mes) Then
                        _rangoAntig = "C"
                        _color = drow_6Mes("ARTICULO").ToString.Trim
                        _cantidad = drow_6Mes("CANTIDAD").ToString.Trim
                    End If
                    GoTo Continuar
                End If

                ' Aniversario Cumplido
                Dim x As Integer = 0
                Dim _fecMasAniv As Date
                For x = 1 To 10
                    _fecMasAniv = DateAdd("m", (12 * x), Row("alta"))
                    If ((_fecMasAniv >= _fini) And (_fecMasAniv <= _ffin)) Then
                        Dim drow_Aniv As DataRow = Nothing
                        Try
                            drow_Aniv = dtCondEntrUnif.Select("antig_meses=12 and area_cond like'%" & _codArea & "%' and puesto_cond like'%" & _codPuesto & "%'")(0)
                        Catch ex As Exception
                        End Try
                        If Not IsNothing(drow_Aniv) Then
                            _rangoAntig = "D" 'Cae en el Rango de 3 Meses cumplidos
                            _color = drow_Aniv("ARTICULO").ToString.Trim
                            _cantidad = drow_Aniv("CANTIDAD").ToString.Trim
                        End If
                        GoTo Continuar
                    End If
                Next

Continuar:
                If (_rangoAntig <> "") Then ' Si cayó en un rango hacer todo lo demás para meterlo

                    'Validar si el empleado tiene talla registrada

                    '****Obtener talla de la playera y pantalon
                    Dim drow_tallPlay As DataRow = Nothing
                    Dim drow_tallPant As DataRow = Nothing

                    Try
                        drow_tallPlay = dtUnifEmplvw.Select("reloj ='" & Row("reloj") & "' and cod_unif='PLAY001'")(0)
                        drow_tallPant = dtUnifEmplvw.Select("reloj ='" & Row("reloj") & "' and cod_unif='PANT001'")(0)
                    Catch ex As Exception
                    End Try


                    If Not IsNothing(drow_tallPlay) Then
                        tallaPlay = drow_tallPlay("talla").ToString.Trim
                    Else
                        tallaPlay = ""
                    End If

                    If Not IsNothing(drow_tallPant) Then
                        tallaPant = drow_tallPant("talla").ToString.Trim
                    Else
                        tallaPant = ""
                    End If

                    Dim drow_Cond As DataRow = Nothing
                    Try
                        drow_Cond = dtCondEntrUnif.Select("ARTICULO='" & _color & "' and CANTIDAD ='" & _cantidad & "'")(0)
                    Catch ex As Exception
                    End Try


                    If Not IsNothing(drow_Cond) Then
                        '----------------BATA
                        If (drow_Cond("BT") > 0) Then
                            _tpoArtBT = "BATA-BT"
                            _cantBT = Convert.ToInt32(drow_Cond("BT"))
                            Dim tpo_actu As String = ""
                            tpo_actu = "BT"
                            Dim dtRes1 As New DataTable
                            dtRes1 = sqlExecute("SELECT * from entrega_unif_resumen where ARTICULO='" & _tpoArtBT.ToString.Trim & "' AND AREA='" & _codArea & "'", "HERRAMIENTAS")
                            If dtRes1.Rows.Count > 0 Then ' Si ya existe el registro solo hay que actualizarlo, sumarle
                                sqlExecute("update entrega_unif_resumen set BT =ISNULL(BT,0) + " & _cantBT & " where ARTICULO='" & _tpoArtBT.ToString.Trim & "' AND AREA='" & _codArea & "'", "HERRAMIENTAS")
                            Else 'Si no existe, hay que insertarlo
                                sqlExecute("INSERT INTO entrega_unif_resumen (ARTICULO,AREA,BT,NOMBRE_AREA) VALUES('" & _tpoArtBT.ToString.Trim & "','" & _codArea & "'," & _cantBT & ",'" & _descripArea & "')", "HERRAMIENTAS")
                            End If
                        End If


                        '----------------MANGA LARGA
                        If (drow_Cond("ML") > 0) Then
                            _tpoArtML = drow_Cond("ARTICULO").ToString.Trim & "-ML" ' Ejemplo: AZUL-ML
                            _cantML = Convert.ToInt32(drow_Cond("ML"))
                            Dim tpo_actu As String = ""
                            If (tallaPlay <> "") Then 'Si tiene playera registrada que lo actualice en el campo talla
                                tpo_actu = tallaPlay
                            Else
                                tpo_actu = "SD_PL" '--No tiene talla asignada, se va a S/Definir Playera
                            End If
                            Dim dtRes2 As New DataTable
                            dtRes2 = sqlExecute("SELECT * from entrega_unif_resumen where ARTICULO='" & _tpoArtML.ToString.Trim & "' AND AREA='" & _codArea & "'", "HERRAMIENTAS")
                            If dtRes2.Rows.Count > 0 Then ' Si ya existe el registro solo hay que actualizarlo, sumarle
                                sqlExecute("update entrega_unif_resumen set " & tpo_actu & "= ISNULL(" & tpo_actu & ",0) +" & _cantML & " where ARTICULO='" & _tpoArtML.ToString.Trim & "' AND AREA='" & _codArea & "'", "HERRAMIENTAS")
                            Else 'Si no existe, hay que insertarlo
                                sqlExecute("INSERT INTO entrega_unif_resumen (ARTICULO,AREA," & tpo_actu & ",NOMBRE_AREA) VALUES('" & _tpoArtML.ToString.Trim & "','" & _codArea & "'," & _cantML & ",'" & _descripArea & "')", "HERRAMIENTAS")
                            End If
                        End If


                        '-----------------MANGA CORTA
                        If (drow_Cond("MC") > 0) Then
                            _tpoArtMC = drow_Cond("ARTICULO").ToString.Trim & "-MC"
                            _cantMC = Convert.ToInt32(drow_Cond("MC"))
                            Dim tpo_actu As String = ""
                            If (tallaPlay <> "") Then 'Si tiene playera registrada que lo actualice en el campo talla
                                tpo_actu = tallaPlay
                            Else
                                tpo_actu = "SD_PL" '--No tiene talla asignada, se va a S/Definir Playera
                            End If
                            Dim dtRes3 As New DataTable
                            dtRes3 = sqlExecute("SELECT * from entrega_unif_resumen where ARTICULO='" & _tpoArtMC.ToString.Trim & "' AND AREA='" & _codArea & "'", "HERRAMIENTAS")
                            If dtRes3.Rows.Count > 0 Then ' Si ya existe el registro solo hay que actualizarlo, sumarle
                                sqlExecute("update entrega_unif_resumen set " & tpo_actu & "= ISNULL(" & tpo_actu & ",0) +" & _cantMC & " where ARTICULO='" & _tpoArtMC.ToString.Trim & "' AND AREA='" & _codArea & "'", "HERRAMIENTAS")
                            Else 'Si no existe, hay que insertarlo
                                sqlExecute("INSERT INTO entrega_unif_resumen (ARTICULO,AREA," & tpo_actu & ",NOMBRE_AREA) VALUES('" & _tpoArtMC.ToString.Trim & "','" & _codArea & "'," & _cantMC & ",'" & _descripArea & "')", "HERRAMIENTAS")
                            End If
                        End If


                        '-------------------PANTALON
                        If (drow_Cond("P") > 0) Then
                            ' _tpoArtP = drow_Cond("ARTICULO").ToString.Trim & "-P"
                            _tpoArtP = "PANTALON-PT"
                            _cantP = Convert.ToInt32(drow_Cond("P"))
                            Dim tpo_actu As String = ""
                            If (tallaPant <> "") Then 'Si tiene Pantalon registrada que lo actualice en el campo talla
                                tpo_actu = "_" & tallaPant  'Lo da x ejemplo: _26 ya que en la Tabla asi está el campo
                            Else
                                tpo_actu = "SD_PT" '--No tiene talla asignada, se va a S/Definir Pantalon
                            End If

                            Dim dtRes4 As New DataTable
                            dtRes4 = sqlExecute("SELECT * from entrega_unif_resumen where ARTICULO='" & _tpoArtP.ToString.Trim & "' AND AREA='" & _codArea & "'", "HERRAMIENTAS")
                            If dtRes4.Rows.Count > 0 Then ' Si ya existe el registro solo hay que actualizarlo, sumarle
                                sqlExecute("update entrega_unif_resumen set " & tpo_actu & "= ISNULL(" & tpo_actu & ",0) +" & _cantP & " where ARTICULO='" & _tpoArtP.ToString.Trim & "' AND AREA='" & _codArea & "'", "HERRAMIENTAS")
                            Else 'Si no existe, hay que insertarlo
                                sqlExecute("INSERT INTO entrega_unif_resumen (ARTICULO,AREA," & tpo_actu & ",NOMBRE_AREA) VALUES('" & _tpoArtP.ToString.Trim & "','" & _codArea & "'," & _cantP & ",'" & _descripArea & "')", "HERRAMIENTAS")
                            End If
                        End If

                        '---------------------CAMISOLA
                        If (drow_Cond("C") > 0) Then
                            ' _tpoArtC = drow_Cond("ARTICULO").ToString.Trim & "-C"
                            _tpoArtC = "CAMISOLA-C"
                            _cantC = Convert.ToInt32(drow_Cond("C"))
                            Dim tpo_actu As String = ""
                            'If (tallaPlay <> "") Then 'Si tiene Playera registrada que lo actualice en el campo talla
                            '    tpo_actu = "_" & tallaPlay  'Lo da x ejemplo:  ya que en la Tabla asi está el campo
                            'Else
                            '    tpo_actu = "SD"
                            'End If
                            tpo_actu = "C" ' --Va ser directo a la columna CAMISOLA, no maneja tallas, es CAMISOLA directamente
                            Dim dtRes5 As New DataTable
                            dtRes5 = sqlExecute("SELECT * from entrega_unif_resumen where ARTICULO='" & _tpoArtC.ToString.Trim & "' AND AREA='" & _codArea & "'", "HERRAMIENTAS")
                            If dtRes5.Rows.Count > 0 Then ' Si ya existe el registro solo hay que actualizarlo, sumarle
                                sqlExecute("update entrega_unif_resumen set " & tpo_actu & "= ISNULL(" & tpo_actu & ",0) +" & _cantC & " where ARTICULO='" & _tpoArtC.ToString.Trim & "' AND AREA='" & _codArea & "'", "HERRAMIENTAS")
                            Else 'Si no existe, hay que insertarlo
                                sqlExecute("INSERT INTO entrega_unif_resumen (ARTICULO,AREA," & tpo_actu & ",NOMBRE_AREA) VALUES('" & _tpoArtC.ToString.Trim & "','" & _codArea & "'," & _cantC & ",'" & _descripArea & "')", "HERRAMIENTAS")
                            End If
                        End If
                    End If

                End If
            Next 'Termina de analizar cada empleado para comenzar con el otro

            ActivoTrabajando = False ' Desactivamos el LOADING
            frmTrabajando.Close()

            'Ya una vez completada la  entrega_unif_resumen
            'Agregamos las columnas para la tabla final la cual va a mostrar todo
            dtDatos = New DataTable
            dtDatos.Columns.Add("ARTICULO")
            dtDatos.Columns.Add("area")
            dtDatos.Columns.Add("C")
            dtDatos.Columns.Add("CH")
            dtDatos.Columns.Add("XCH")
            dtDatos.Columns.Add("M")
            dtDatos.Columns.Add("G")
            dtDatos.Columns.Add("XG")
            dtDatos.Columns.Add("_22")
            dtDatos.Columns.Add("_24")
            dtDatos.Columns.Add("_25")
            dtDatos.Columns.Add("_26")
            dtDatos.Columns.Add("_27")
            dtDatos.Columns.Add("_28")
            dtDatos.Columns.Add("_29")
            dtDatos.Columns.Add("_30")
            dtDatos.Columns.Add("_31")
            dtDatos.Columns.Add("_32")
            dtDatos.Columns.Add("_33")
            dtDatos.Columns.Add("_34")
            dtDatos.Columns.Add("_36")
            dtDatos.Columns.Add("_38")
            dtDatos.Columns.Add("_40")
            dtDatos.Columns.Add("_42")
            dtDatos.Columns.Add("_44")
            dtDatos.Columns.Add("_46")
            dtDatos.Columns.Add("_48")
            dtDatos.Columns.Add("descrip_area")
            dtDatos.Columns.Add("SD_PL")
            dtDatos.Columns.Add("SD_PT")
            dtDatos.Columns.Add("BT")
            dtDatos.Columns.Add("f_Ini")
            dtDatos.Columns.Add("f_Fin")

            Dim dtResFinal As DataTable = sqlExecute("select * from entrega_unif_resumen", "HERRAMIENTAS")

            For Each Row As DataRow In dtResFinal.Rows
                Dim drow As DataRow = dtDatos.NewRow
                drow("ARTICULO") = Row("ARTICULO")
                drow("area") = Row("AREA")
                drow("C") = IIf(IsDBNull(Row("C")), 0, Row("C"))
                drow("CH") = IIf(IsDBNull(Row("CH")), 0, Row("CH"))
                drow("XCH") = IIf(IsDBNull(Row("XCH")), 0, Row("XCH"))
                drow("M") = IIf(IsDBNull(Row("M")), 0, Row("M"))
                drow("G") = IIf(IsDBNull(Row("G")), 0, Row("G"))
                drow("XG") = IIf(IsDBNull(Row("XG")), 0, Row("XG"))
                drow("_22") = IIf(IsDBNull(Row("_22")), 0, Row("_22"))
                drow("_24") = IIf(IsDBNull(Row("_24")), 0, Row("_24"))
                drow("_25") = IIf(IsDBNull(Row("_25")), 0, Row("_25"))
                drow("_26") = IIf(IsDBNull(Row("_26")), 0, Row("_26"))
                drow("_27") = IIf(IsDBNull(Row("_27")), 0, Row("_27"))
                drow("_28") = IIf(IsDBNull(Row("_28")), 0, Row("_28"))
                drow("_29") = IIf(IsDBNull(Row("_29")), 0, Row("_29"))
                drow("_30") = IIf(IsDBNull(Row("_30")), 0, Row("_30"))
                drow("_31") = IIf(IsDBNull(Row("_31")), 0, Row("_31"))
                drow("_32") = IIf(IsDBNull(Row("_32")), 0, Row("_32"))
                drow("_33") = IIf(IsDBNull(Row("_33")), 0, Row("_33"))
                drow("_34") = IIf(IsDBNull(Row("_34")), 0, Row("_34"))
                drow("_36") = IIf(IsDBNull(Row("_36")), 0, Row("_36"))
                drow("_38") = IIf(IsDBNull(Row("_38")), 0, Row("_38"))
                drow("_40") = IIf(IsDBNull(Row("_40")), 0, Row("_40"))
                drow("_42") = IIf(IsDBNull(Row("_42")), 0, Row("_42"))
                drow("_44") = IIf(IsDBNull(Row("_44")), 0, Row("_44"))
                drow("_46") = IIf(IsDBNull(Row("_46")), 0, Row("_46"))
                drow("_48") = IIf(IsDBNull(Row("_48")), 0, Row("_48"))
                drow("descrip_area") = Row("NOMBRE_AREA")
                drow("SD_PL") = IIf(IsDBNull(Row("SD_PL")), 0, Row("SD_PL"))
                drow("SD_PT") = IIf(IsDBNull(Row("SD_PT")), 0, Row("SD_PT"))
                drow("BT") = IIf(IsDBNull(Row("BT")), 0, Row("BT"))
                drow("f_Ini") = FechaSQL(_fini)
                drow("f_Fin") = FechaSQL(_ffin)

                dtDatos.Rows.Add(drow) 'Agregar el registro completo
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            ActivoTrabajando = False
            frmTrabajando.Close()
        End Try
    End Sub

    Public Sub EmplSinUnifAsig(ByRef dtDatos As DataTable, ByRef dtInformacion As DataTable)
        Try
            '----Declaracion de Variables
            Dim NumReloj As String = ""
            '-----Ends Declaracion de vars

            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_comp", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("fecha_alta", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("codigo_area", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_area", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("codigo_puesto", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("rfc", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_puesto", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("COD_TIPO", System.Type.GetType("System.String"))

            '--Personal que no tiene Uniforme Asignado:
            Dim dtEmplSinUnif As DataTable = sqlExecute("select ps.reloj,ps.cod_comp,ps.nombres,ps.ALTA,ps.BAJA,ps.cod_area,ps.nombre_area,ps.COD_PUESTO,ps.nombre_puesto,ps.RFC from PERSONAL.dbo.personalvw ps" & _
                                                        " WHERE NOT EXISTS (SELECT * from HERRAMIENTAS.dbo.UniformesEmpleadosVW unif where unif.RELOJ = ps.RELOJ and unif.talla is not null and unif.talla <>'')" & _
                                                        " and ps.BAJA is null and ps.COD_COMP in ('610','002') order by RELOJ ASC")

            Dim total As Integer
            total = dtEmplSinUnif.Rows.Count ' Var para sacar el total de registros

            frmTrabajando.Show()
            Application.DoEvents()

            ' For Each row As DataRow In dtInformacion.Rows
            For Each row As DataRow In dtInformacion.Select("COD_TIPO='O' AND BAJA IS NULL")
                frmTrabajando.lblAvance.Text = row("reloj")
                Application.DoEvents()

                Dim drow As DataRow = dtDatos.NewRow
                drow("reloj") = row("reloj").ToString.Trim
                NumReloj = drow("reloj")

                Dim drow_sinUnif As DataRow = Nothing
                Try
                    drow_sinUnif = dtEmplSinUnif.Select("reloj = '" & NumReloj & "'")(0) ' si existe ese reloj, es que no tiene uniforme asignado y hay que meterlo
                Catch ex As Exception

                End Try

                If Not IsNothing(drow_sinUnif) Then ' --Si existe ese registro es que no tiene Unif y hay que meterlo al DT
                    drow("cod_comp") = row("cod_comp")
                    drow("fecha_alta") = FechaSQL(row("alta"))
                    drow("codigo_area") = row("cod_area")
                    drow("nombres") = row("nombres")
                    drow("nombre_area") = row("nombre_area")
                    drow("codigo_puesto") = row("COD_PUESTO")
                    drow("rfc") = row("rfc")
                    drow("nombre_puesto") = row("nombre_puesto")
                    Select Case (row("COD_TIPO").ToString.Trim())
                        Case "A"
                            drow("COD_TIPO") = "Administrativo"
                        Case "O"
                            drow("COD_TIPO") = "Operativo"
                        Case Else
                            drow("COD_TIPO") = "No definido"
                    End Select
                    dtDatos.Rows.Add(drow)
                End If
            Next

            ActivoTrabajando = False ' Desactivamos el LOADING
            frmTrabajando.Close()

        Catch ex As Exception
            ActivoTrabajando = False ' Desactivamos el LOADING
            frmTrabajando.Close()
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

End Module

