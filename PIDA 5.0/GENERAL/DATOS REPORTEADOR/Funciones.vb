Module Funciones
    Public Function PreparaDatos(ByVal Reporte As String, ByRef dtInformacion As DataTable, Optional NombreDataSet As String = "", Optional ParametrosAdicionales As String() = Nothing, Optional cod_comp As String = "", Optional payment_date As String = Nothing) As DataTable

        'Reporte = Nombre del reporte que se está emitiendo
        'dtInformacion = La tabla de personal ya filtrada, como referencia de los números de reloj
        'NombreDataSet = en caso de que el reporte requiera varios DataSet, se puede determinar con cual se debe trabajar

        'dtDatos es el Datatable donde devuelve el Query resultante, después de trabajarlo en la subrutina

        Dim dtDatos As New DataTable
        Dim tipo As Integer
        Dim x As System.StringComparison = StringComparison.InvariantCultureIgnoreCase
        tipo = 0
        'Buscar qué proceso se debe correr, de acuerdo al reporte que se está emitiendo.
        Try

            '**** RECURSOS HUMANOS ****
            If Reporte = "CARTA DESLINDE GAFETE UNICO BAJA OPERADORES" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "FORMATO CARTA BANAMEX" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "Carta de designación de beneficiarios" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CARTA VISA" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CONSTANCIA LABORAL ACTIVO" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CONSTANCIA LABORAL BAJA" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CONSTANCIA LABORAL ACTIVO" Then
                dtDatos = dtInformacion
            End If

            If Reporte = "3 RESPONSIVA DE PENSION ALIMENTICIA" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CTEF-103 Rev. A Carta de confidencialidad." Then
                dtDatos = dtInformacion
            End If
            If Reporte = "4 RESPONSIVA DE CREDITO INFONAVIT" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "Carta Oferta" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CARTA PARA GUARDERÍA" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CARTA DE ENTRENAMIENTO CRUCE" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CARTA COMPROMISO DE PAGO" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "RENUNCIA CTE" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CTEF-095 Rev. A Recibo de cobro de finiquito" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CTEF-094 Rev. A Requisitos para contratacion de personal administrativo" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CTEF-093 Rev. A ENTREVISTA DE SALIDA" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CTEF-049 Rev. C Check list para baja de trabajadores formato" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CTEF-024 Rev. B Examen practico de manejo" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CTEF-004 Rev. H Requisitos para contratacion de personal operativo" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CTEF003 Requisicion del personal EDITABLE" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CARTA PARA CBP" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CARTA PARA CBP ADMINISTRATIVOS" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "5 AVISO DE PRIVACIDAD" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "6 REGLAMENTO CTE DE USO Y ACCESO A LOS RECURSOS INFORMATICOS" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "7 CTEF-RH-12 ACTUALIZACION DE DATOS PERSONALES Y DE EMERGENCIA-2" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "BIENVENIDA" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "REGISTRO DE ASISTENCIA A REUNIONES" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "8 ACTUALIZACION DE DATOS PERSONALES Y DE EMERGENCIA" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CTEF030 Referencias y Entrevista de Trabajo" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "CTEF-076 Rev. A Encuesta socioeconomica" Then
                dtDatos = dtInformacion
                dtDatos.Columns.Add("FOTO_EMPLEADO")
                For Each row In dtDatos.Rows
                    row("FOTO_EMPLEADO") = PathFoto + Trim(row("RELOJ").ToString) + ".jpg"
                Next
            End If
            If Reporte = "SOLICITUD DE EMPLEO CTE" Then
                dtDatos = dtInformacion
                dtDatos.Columns.Add("FOTO_EMPLEADO")
                For Each row In dtDatos.Rows
                    row("FOTO_EMPLEADO") = PathFoto + Trim(row("RELOJ").ToString) + ".jpg"
                Next
            End If
            If Reporte = "CTEF-070 Rev. A VALE POR EQUIPO" Then
                dtDatos = dtInformacion
            End If
            If Reporte = "Reporte numérico" Then
                dtDatos = dtInformacion
            ElseIf Reporte = "Detalle infonavit" Then  '-- AOS: 10/06/2021
                DetInfonavit(dtDatos, dtInformacion)
            ElseIf Reporte = "Gafete WME" Then  '-- MCR
                GafetesQR(dtDatos, dtInformacion)
            ElseIf Reporte = "BRP Formato rol_promociones" Then
                CambioRoles(dtDatos, dtInformacion)
            ElseIf Reporte = "HC Turnover" Then
                ReporteTurnover(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de horarios detalle" Then
                HorariosDetalle()
            ElseIf Reporte = "Cumpleaños" Then
                Cumpleaños(dtDatos, dtInformacion)
            ElseIf Reporte = "Checadas cafeteria" Then ' AO 2023-05-24
                ChecadasCafeteria(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte Saldo Vacaciones (PRUEBA PIDA)" Then
                vacaciones_prueba(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte Saldo de Vacaciones (PRUEBA)" Then
                vacaciones_prueba(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de recomendaciones nómina Semanal" Then
                ReporteRecomendacionNomina(dtDatos, dtInformacion, "S")
            ElseIf Reporte = "Reporte de recomendaciones nómina Quincenal" Then
                ReporteRecomendacionNomina(dtDatos, dtInformacion, "Q")
            ElseIf Reporte = "Reporte de recomendaciones" Then
                Recomendaciones(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de recomendaciones Métricos" Then
                Recomendaciones(dtDatos, dtInformacion)
            ElseIf Reporte = "Constancia Baja" Then
                ConstanciaBaja(dtDatos, dtInformacion)
            ElseIf Reporte = "Bitacora de cambios" Then
                BitacoraCambios(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte Transacciones" Then
                main.ShowDialog()
                main.Dispose()
            ElseIf Reporte = "Porcentaje totales departamento" Then
                PorcentajeTotalesDepartamento(dtDatos, dtInformacion)
            ElseIf Reporte = "Bonus Salaried with promotion" Or Reporte = "Bonus Salaried" Then
                BonusSalWProm(dtDatos, dtInformacion)
                '--------
            ElseIf Reporte = "Reporte de rutas entrada y salida" Then '-----------Adrian Ortega: Nuevo solicitado para mandar tanto totales de Entrada /Salida en uno solo
                ReporteDeRutasEnt_Sal(dtDatos, dtInformacion)

            ElseIf Reporte = "Reporte de rutas detalle" Or Reporte = "Reporte de rutas" Then '---ENTRADA: Detalle y Totales
                tipo = 1
                ReporteDeRutas(dtDatos, dtInformacion, tipo) ' Para entradas

            ElseIf Reporte = "Reporte de rutas detalle salida" Or Reporte = "Reporte de rutas salida" Then '---SALIDA: Detalle y Totales
                tipo = 2
                ReporteDeRutas(dtDatos, dtInformacion, tipo) ' Para salidas

            ElseIf Reporte = "Empleados sin ruta asignada" Then '--Empleados sin ruta asignada
                EmpleadosSinRuta(dtDatos, dtInformacion)
            ElseIf Reporte = "Bonus Hourly Plantees" Or Reporte = "ES Plant Memo" Then
                BonusHourlyPlan(dtDatos, dtInformacion)
            ElseIf Reporte = "BRP asignaciones SF" Then
                AsignacionSF(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte mantenimiento" Then
                dtDatos = dtInformacion
            ElseIf Reporte = "Movimiento más reciente" Then
                UltimoMovimiento(dtDatos, dtInformacion)
            ElseIf Reporte = "Matriz cursos YIELD" Then
                MatrizCursosYIELD(dtDatos, dtInformacion)
            ElseIf Reporte = "Personal con hijos" Then
                PersonalConHijos(dtDatos, dtInformacion)
            ElseIf Reporte = "Detalle Personal con hijos" Then
                DetallePersonalConHijos(dtDatos, dtInformacion)


            ElseIf Reporte = "Proyeccion de vacaciones" Then '--------------------------Adrian Ortega ---------------------------------------------------------
                ProyeccionVacas(dtDatos, dtInformacion)


            ElseIf Reporte = "Datos para servicio médico" Then '-------Adrian Ortega
                DatosSerMed(dtDatos, dtInformacion)

            ElseIf Reporte = "Reporte de estadística de kiosco" Then '-------Adrian Ortega
                EstadisticaKiosco(dtDatos, dtInformacion)

            ElseIf Reporte = "Reporte de respuestas de encuestas de kiosco" Then '-------Adrian Ortega
                Select Case NombreDataSet
                    Case "Personal_COD" '--Detalle
                        RespEncuestasKiosco(dtDatos, dtInformacion)
                    Case "Resumen_COD" '--Totales resumen
                        RespEncTot(dtDatos, dtInformacion)
                End Select

            ElseIf Reporte = "Reporte para Budget" Then '-------Adrian Ortega
                ReporteBudget(dtDatos, dtInformacion)

            ElseIf Reporte = "Constancia Laboral banco" Or Reporte = "Constancia Laboral" Or Reporte = "Renuncia Wollsdorf" Or Reporte = "Convenio terminacion de contrato" Then ' Adrian Ortega
                Dim SRep = Reporte
                LlenarWORDWME(dtDatos, dtInformacion, SRep)

            ElseIf Reporte = "Convenio reduccion de salario 300620" Or Reporte = "Carta Guaderia" Or Reporte = "Clausula de Beneficiarios Wollsdorf" Then  '----ANTONIO
                Dim SRep = Reporte
                LlenarWORDWME(dtDatos, dtInformacion, SRep)

            ElseIf Reporte = "Reporte de Cuentas y Clabes Bancarias" Then '-------Antonio
                ReporteCuentasYClabes(dtDatos, dtInformacion) '---------------------Antonio

            ElseIf Reporte = "Reporte Empleados Baja" Then '-----------------------Antonio
                ReporteEmpleadosBaja(dtDatos, dtInformacion) '---------------------Antonio

            ElseIf Reporte = "Constancia de antiguedad y vacaciones" Then  '---------------Ernesto  22/dic/2020
                Dim SRep = Reporte
                LlenarWORDWME(dtDatos, dtInformacion, SRep)

            ElseIf Reporte = "Formato de liberacion finiquito" Then  '---------------AOS  22/Jun/2021
                Dim SRep = Reporte
                LlenarWORDWME(dtDatos, dtInformacion, SRep)

            ElseIf Reporte = "Beneficiarios" Then   '------------Ernesto    23/dic/2020
                Beneficiarios(dtDatos, dtInformacion)

            ElseIf Reporte = "Permiso de ausencia" Then  '-- Adrian Ortega
                ExcelPermisoAusencia(dtDatos, dtInformacion)

            ElseIf Reporte = "Carta Patronal" Then  '---------------Ernesto 10junio2021
                Dim SRep = Reporte
                LlenarWORDWME(dtDatos, dtInformacion, SRep)

            ElseIf Reporte = "Reporte disciplinario general rh" Then  '-- Ernesto Garcia       29marzo22
                ReporteAccionDisciplinaria(dtDatos)

            ElseIf Reporte = "Reporte quejas general rh" Then         '-- Ernesto Garcia       22febrero23
                ReporteQuejasGeneral(dtDatos)

                '== Reporte de excel para bajas solicitado por Elizabeth WME        --      Ernesto     --      16marzo2023
            ElseIf Reporte = "Reporte Empleados Baja Excel" Then
                ReporteExcelBajasMotivos()

            ElseIf Reporte = "Solicitud de vacacaciones desde kiosco" Then '-------Adrian Ortega
                RepSolVacsDesdeKiosco(dtDatos, dtInformacion)

                '//*******************************************HERRAMIENTAS ************************************************************************
            ElseIf Reporte = "Reporte de entrega de uniformes por antiguedad" Then  '--------------AOS
                EntregaUniformes(dtDatos, dtInformacion)

            ElseIf Reporte = "Reporte de entrega uniformes por antig_resumen" Then  '--------------AOS
                EntregaUniformes_resumen(dtDatos, dtInformacion)

            ElseIf Reporte = "Empleados sin uniforme asignado" Then  '--------------AOS
                EmplSinUnifAsig(dtDatos, dtInformacion)
                '//************************************************************** Discos para el IMSS ************************** Inicio
            ElseIf Reporte = "IDSE Altas" Then ' AOS 12/19/2019
                AltasIMSS(dtDatos, dtInformacion)
            ElseIf Reporte = "IDSE Bajas" Then ' AOS 12/19/2019
                BajasIMSS(dtDatos, dtInformacion)
            ElseIf Reporte = "IDSE Modificaciones de sueldo" Then ' AOS 12/19/2019
                ModificacionesIMSS(dtDatos, dtInformacion)

            ElseIf Reporte = "Disco de modificaciones al IMSS por nuevo UMA(Topados)" Then ' AOS 2021-02-03
                ModificacionesIMSS_Topados(dtDatos, dtInformacion)

            ElseIf Reporte = "Variables IMSS" Then ' AOS 12/12/2020
                ModificacionesIMSS_Variables(dtDatos, dtInformacion, FecAplVar)

            ElseIf Reporte.Contains("Disco de modificaciones de sueldo por aniversario al IMSS") Then
                ModificacionesPorAntiguedad(dtDatos, dtInformacion)
                '//************************************************************** Discos para el SUA ************************** Inicio
            ElseIf Reporte = "Disco de modificaciones al SUA" Then
                ModificacionesSUA(dtDatos, dtInformacion)
            ElseIf Reporte = "Disco de Bajas al SUA" Then
                BajasSUA(dtDatos, dtInformacion)
            ElseIf Reporte = "Disco de Altas al SUA" Then
                AltasSUA(dtDatos, dtInformacion)
            ElseIf Reporte.Contains("Disco de Ausentismo al SUA") Then
                ModificacionesAusenSUA(dtDatos, dtInformacion)
            ElseIf Reporte.Contains("Disco de Incapacidad al SUA") Then
                ModificacionesIncapSUA(dtDatos, dtInformacion)
            ElseIf Reporte.Contains("Disco de Reingresos al SUA") Then
                ReingresoSUA(dtDatos, dtInformacion)
            ElseIf Reporte.Contains("Disco SUA Global (Reingresos,Bajas,Modificaciones,Incapacidades,Ausentismos)") Then
                SUAGlobal(dtDatos, dtInformacion)
            ElseIf Reporte = "Disco de infonavit al SUA" Then '-----------Adrian Ortega 2023-01-20
                SUAInfonavit(dtDatos, dtInformacion)
                '//************************************************************** Discos para el SUA ************************** Fin
            ElseIf Reporte = "Reporte HC por centro de costos" Then
                BRPHC(dtDatos, dtInformacion)
            ElseIf Reporte = "Formato movimientos seguros Monterrey" Then
                segurosmonterrey(dtDatos, dtInformacion)
            ElseIf Reporte = "Empleados por departamento contando sexo" Then
                EmpleadosDeptoSexo(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte AMAC" Then
                ReporteAMAC(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de bajas (nómina)" Then
                ReporteBajasNomina(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de rotación por puesto" Then
                RotacionXPuesto(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de rotación por tipo de empleado" Then
                RotacionXTipo(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de saldos de vacaciones" Then
                SaldosVacaciones(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de última modificación de sueldo" Then
                UltimaModificacion(dtDatos, dtInformacion)
            ElseIf Reporte = "Resumen de bajas" Then
                ResumenBajas(dtDatos, dtInformacion)
            ElseIf Reporte = "PIM_Employee record" Then
                Employeerecord(dtDatos, dtInformacion)
            ElseIf Reporte = "Modificaciones de salario por antiguedad" Then
                ModificacionesPorAntiguedadBRP(dtDatos, dtInformacion)
            ElseIf Reporte = "Beneficiarios" Then
                Beneficiarios(dtDatos, dtInformacion)
            ElseIf Reporte = "Gafete Centro Familiar" Then
                CentroFamiliar(dtDatos, dtInformacion)
            ElseIf Reporte = "Programación de vacaciones por cierre" Then
                ProgramacionVacaciones(dtInformacion)
            ElseIf Reporte = "Programación de vacaciones CC" Then
                ProgramacionVacacionesCC(dtInformacion)
            ElseIf Reporte = "Bajas GMM" Then
                BajasGMM(dtInformacion)
            ElseIf Reporte = "Carta ex-empleado" Then '**********************************JOSE**********************************
                ExEmpleado(dtDatos, dtInformacion)
            ElseIf Reporte = "Afiliación BNC" Then '******************************JOSE*******************************
                AfiliacionBNC(dtDatos, dtInformacion)
            ElseIf Reporte = "Etiquetas por empleado" Then '******************************JOSE*******************************
                Etiquetas_empleado(dtDatos, dtInformacion)
            ElseIf Reporte = "BRP_Diferencias fechas alta" Then '******************************JOSE*******************************
                DifFechasAltas(dtDatos, dtInformacion)
                'ElseIf Reporte = "Cumpleañeros (para pizarrón)" Then
                '    CumplePizarron(dtDatos, dtInformacion)
            ElseIf Reporte = "checklist accidente de trabajo" Then  '---------------------------------------chuy-----------------------------------'
                AccidenteDeTrabajo(dtDatos, dtInformacion)
            ElseIf Reporte = "Dias para PTU" Then    '----------------------------------------chuy--------------------------' 
                DiasParaPTU(dtDatos, dtInformacion)
            ElseIf Reporte = "Axa Seguro de vida" Then
                IncluyeBeneficiarios(dtDatos, dtInformacion, "SEGVI")
            ElseIf Reporte = "Listado de bajas" Then
                Listadobajas(dtDatos, dtInformacion)
            ElseIf Reporte = "Listado de altas" Then
                Listadoaltas(dtDatos, dtInformacion)
            ElseIf Reporte = "BRP_Listado cambios salario" Then
                Listadocambiossalario(dtDatos, dtInformacion)
            ElseIf Reporte.Contains("FOR03042") Then
                IncluyeBeneficiarios(dtDatos, dtInformacion, "FONDO")
            ElseIf Reporte.Contains("Disco de modificaciones de sueldo por aniversario al IMSS") Then
                ModificacionesPorAntiguedad(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de personal contrato" Then
                PersonalTiposContratoPG(dtDatos, dtInformacion) '**************************CARLOS*********************************************************
            ElseIf Reporte = "BRP_Reporte de antiguedad promedio" Then
                ReporteAntiguedadPromedio(dtDatos, dtInformacion) '**************************CARLOS*********************************************************
                'ElseIf Reporte = "Formato Multiple Altas" Then
                '    FormatoMultiple(dtDatos, dtInformacion) '**************************CARLOS*********************************************************
            ElseIf Reporte = "Formato Multiple" Then
                FormatoMultiple(dtDatos, dtInformacion) '**************************CARLOS*********************************************************
            ElseIf Reporte = "Compa ratio" Then
                CompaRatio(dtDatos, dtInformacion) '**************************CARLOS*********************************************************
            ElseIf Reporte = "Headcount activos" Then
                HeadcountActivos(dtDatos, dtInformacion) '**************************CARLOS*********************************************************
            ElseIf Reporte = "Ausentismo y Rotacion" Then
                AusentismoYRotacion(dtDatos, dtInformacion) '**************************CARLOS*********************************************************
                'ElseIf Reporte = "BRP_Reporte diario" Or Reporte = "BRP_Reporte diario Juarez 1" Or Reporte = "BRP_Reporte diario Juarez 2" Then
                '    BRP_ReporteDiario(dtDatos, dtInformacion, NombreDataSet) '**************************CARLOS*********************************************************

            ElseIf Reporte = "Reporte diario" Then
                NuevoReporteDiario(dtDatos, dtInformacion) '**************************ABRAHAM

            ElseIf Reporte = "BRP_Listado de cambios por antiguedad" Then
                Cambiosporantiguedad(dtDatos, dtInformacion)
                'ElseIf Reporte = "Reporte para budget" Then
                '    ReporteBudgetSoloBRPQTO()
            ElseIf Reporte = "Tarjetas de despensa" Then
                TarjetasDespensa(dtDatos, dtInformacion)
            ElseIf Reporte = "Rep. Ing. Muñoz" Then
                ReporteIngMunoz(dtDatos, dtInformacion)
            ElseIf Reporte = "BRP_Aniversarios 5 10 15 20 etc" Then
                ReportedeAntiguedades(dtDatos, dtInformacion)
            ElseIf Reporte = "Selección aleatoria de empleados" Then
                Antidoping(dtDatos, dtInformacion)
            ElseIf Reporte = "BRP_Inicio periodo de pruebas" Then
                PeriodoPruebas(dtDatos, dtInformacion)
            ElseIf Reporte = "BRP_Vencimiento de contrato" Then
                ContratosVencidos(dtDatos, dtInformacion)
            ElseIf Reporte = "Contratos" Then


            ElseIf Reporte = "Reporte de Compensaciones" Then
                RptCompen(dtDatos, dtInformacion)
            ElseIf Reporte = "Saldos de vacaciones QRO" Then
                ReporteVacacionesQRO(dtDatos, dtInformacion) '**************************CARLOS*********************************************************
            ElseIf Reporte = "Kardex Anual" Then
                KardexAnualGlobal(dtDatos, dtInformacion) '********************************* Enrique Meza ***************************************************

            ElseIf Reporte = "Registro de personal activo" Then ' AOS 2024-05-10
                RegistroPersAct(dtDatos, dtInformacion)

            ElseIf Reporte = "Empleados con modificacion de salario en un rango de fechas" Then ' AO 2024-06-18
                ModSalRangoFec(dtDatos, dtInformacion)

            ElseIf Reporte = "Detalle de saldo de vacaciones" Then ' AO 2024-06-21
                DetSalVacas(dtDatos, dtInformacion)

                '***************************************************************************************************************************************************************************
                '***************************************************************************TA**********************************************************************************************
                '***************************************************************************************************************************************************************************
                '***************************************************************************************************************************************************************************

            ElseIf Reporte = "Resumen de cafetería" Then ' AOS: 02/06/2021
                ResumenCafeteria(dtDatos, dtInformacion)

            ElseIf Reporte = "Checadas por día" Then
                ChecadasXDia(dtDatos, dtInformacion)

            ElseIf Reporte = "OH - Avance autorización" Then
                OH_AvanceAutoriazion(dtDatos, dtInformacion)
            ElseIf Reporte = "Avance autorización" Then ' 18/oct/2024
                AvanceAutoriazion(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de checadas" Then
                ReporteChecadas(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte Historial Horas en Bruto" Then
                HistorialHorasBruto(dtDatos, dtInformacion)
            ElseIf Reporte = "Tiempo extra (Doble y Triple)" Then
                TiempoExtraDobleyTriple(dtDatos, dtInformacion)
                'Revisión de horas antes de envío de información TOTALES
            ElseIf Reporte = "Reporte Faltas Injustificadas 30 y 90 días" Then
                ausentismo_semanal3090()
            ElseIf Reporte = "Revisión de horas antes de envío de información TOTALES" Then
                InfoRetPSG(dtDatos, dtInformacion)
            ElseIf Reporte = "Tiempo extra acumulado" Then
                TiempoextraAcumulado(dtDatos, dtInformacion)
            ElseIf Reporte = "KardexAnual" Then
                KardexAnual(dtDatos, dtInformacion, ParametrosAdicionales)
            ElseIf Reporte = "Ajustes por fecha" Then
                ReporteAjustesClerkFecha(dtDatos, dtInformacion)
            ElseIf Reporte = "Kardex empleado" Then
                KardexEmpleado(dtDatos, dtInformacion)
            ElseIf Reporte = "Follow up by week" Then
                FollowUpByWeek(dtDatos, dtInformacion)
            ElseIf Reporte = "Graficas ausentismo" Then
                GraficasAusentismo(dtDatos, dtInformacion)
            ElseIf Reporte = "Ausentismo por área" Then
                AusentismoPorArea(dtDatos, dtInformacion)
            ElseIf Reporte = "Horas trabajadas por centro de costos" _
                      Or Reporte = "Horas trabajadas por departamento" _
                      Or Reporte = "Horas trabajadas por CC empleados estimados" _
                      Or Reporte = "Horas trabajadas por centro de costos y turno" _
                      Or Reporte = "Horas trabajadas por departamento y turno" Then
                HorasTrabajadas(dtDatos, dtInformacion)
            ElseIf Reporte = "Prenómina semanal administrativa" Then
                PrenominaAdmva(dtDatos, dtInformacion)
            ElseIf Reporte = "Lista de asistencia" Or Reporte = "Detalle de asistencia" Then
                ListaAsistencia(dtDatos, dtInformacion)
                'ElseIf Reporte = "Lista de asistencia semanal" Then
                '    AsistenciaSemanal(dtDatos, dtInformacion, NombreDataSet)
            ElseIf Reporte = "Ausentismo" Or Reporte.Contains("Resumen de ausentismo") Then
                AusentismoPorGrupo(dtDatos, dtInformacion)
            ElseIf Reporte = "Listado y exportación de incapacidades" Then
                ExportaIncapacidades(dtDatos, dtInformacion)
            ElseIf Reporte = "Listado y exportación de ausentismo" Then
                ExportaAusentismo(dtDatos, dtInformacion)
            ElseIf Reporte = "Asistencia perfecta" Then
                AsistenciaPerfectaReporte(dtDatos, dtInformacion)
            ElseIf Reporte = "Asistencia perfecta con secundaria" Then
                AsistenciaPerfectaSecundaria(dtDatos, dtInformacion, NombreDataSet)
            ElseIf Reporte = "Asistencia perfecta mensual" Then
                'MCR 9/NOV/2015
                'Asistencia perfecta BRP
                AsistenciaPerfectaMensual(dtDatos, dtInformacion)

            ElseIf Reporte.Contains("Reporte Cafetería") Then
                ReporteCafeteriaQTO(dtDatos, dtInformacion)

            ElseIf Reporte = "Excel ausentismo rango horizontal" Then
                ExcelAusentismoTA(dtDatos, dtInformacion) '****** ' -------------CHUY------------
            ElseIf Reporte = "Excel Registro de Asistencia" Then
                ExcelAsistenciaTA(dtDatos, dtInformacion, "Excel Registro de Asistencia") '----------------ANTONIO-----------

            ElseIf Reporte = "Detalle Horas trabajadas reales (catorcenales)" Then   '-- Ernesto feb/21
                ExcelAsistenciaTA(dtDatos, dtInformacion, "Detalle Horas trabajadas reales (catorcenales)") '----------------Ernesto-----------  feb/21

                '== Funcion de reporte para 'Reporte de faltas por clasificacion'       Abril 2021      Ernesto
            ElseIf Reporte = "Reporte de faltas por clasificacion" Then
                ExcelFaltasInjustificadasMotivos(dtDatos, dtInformacion)

                '== Funcion de reporte para 'Listado captura de excepciones de horario'       Mayo 2021      Ernesto
            ElseIf Reporte = "Listado captura de excepciones de horario" Then
                ReporteExcepcionesHorario(dtDatos, dtInformacion)

                '== Funcion de reporte para 'Formato de solicitud de tiempo extra'       27oct 2021      Ernesto
            ElseIf Reporte = "Formato de solicitud de tiempo extra" Then
                ExcelFormatoHorasExtras(dtDatos, dtInformacion)

            ElseIf Reporte = "Tiempo extra" Or Reporte = "Detalle de tiempo extra" Or Reporte = "Tiempo extra (horas) acumulado" Then
                TiempoExtra(dtDatos, dtInformacion)
            ElseIf Reporte = "Tiempo extra con costo diario" _
                Or Reporte = "Tiempo extra con costo" _
                Or Reporte = "Tiempo extra con costo diario por prensa" _
                Or Reporte = "Tiempo extra con costo por prensa" Then
                TiempoExtraCostoDiario(dtDatos, dtInformacion)
            ElseIf Reporte = "Provisión horas normales y extras" Then
                ProvisionNormalesExtras(dtDatos, dtInformacion)
            ElseIf Reporte = "Exportación ausentismo SUA" Then
                ExportacionAusentismo(dtDatos, dtInformacion)

                'ElseIf Reporte = "Reporte de Incapacidades" Then ' Anterior
                '    ReporteIncapacidades(dtDatos, dtInformacion)

            ElseIf Reporte = "Reporte de incapacidades" Then
                RepIncap(dtDatos, dtInformacion) ' 2024-06-22

            ElseIf Reporte = "Incapacidades" Then
                RrtIncapa(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de ausentismo" Then
                Reporteausentismo(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de asistencia perfecta" Then
                Reporteasistenciaperfecta(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de retardos y salida anticipada" Then
                RetardosAnticipada(dtDatos, dtInformacion, NombreDataSet)
            ElseIf Reporte = "Personal sin horas para pago" Then
                PersonalSinHoras(dtDatos)
            ElseIf Reporte = "Bitácora relojes checadores" Then
                Bitacorarelojes(dtDatos)
            ElseIf Reporte = "Reconocimiento de falta" Then
                FaltasInjustificadas(dtDatos, dtInformacion) '************************************************CARLOS********************************
            ElseIf Reporte = "Reporte de faltas injustificadas" Then
                ConteoFaltasInjustificadas(dtDatos, dtInformacion) '******************************************CARLOS********************************
            ElseIf Reporte = "Reporte de asistencia" Then
                ReporteAsistencia(dtDatos, dtInformacion) '***************************************************CARLOS********************************
            ElseIf Reporte = "Saldos de vacaciones" Then
                SaldosDíasVacaciones(dtDatos, dtInformacion) '************************************************CARLOS********************************
            ElseIf Reporte = "Reporte de ausentismo devuelto" Then
                ReporteAusentismoDevuelto(dtDatos, dtInformacion, NombreDataSet) '****************************CARLOS********************************
            ElseIf Reporte = "Ausentismo aplicado y devuelto" Then
                ReporteAusentismoDevuelto(dtDatos, dtInformacion, NombreDataSet) '****************************CARLOS********************************
            ElseIf Reporte = "Ausentismo aplicado" Then
                ReporteAusentismoAplicado(dtDatos, dtInformacion) '*******************************************ENRIQUE MEZA**************************
            ElseIf Reporte = "Revisión incidencias clerk PRUEBAS" Then
                RevisionIncidenciasClerk(dtDatos, dtInformacion)

            ElseIf Reporte = "Asistencia por dia" Then ' ---AO 2024-04-26
                AsistenciaXDia(dtDatos, dtInformacion)

            ElseIf Reporte = "Asistencia semanal" Then ' ---AO 2024-05-02
                AsistenciaSemanal(dtDatos, dtInformacion)

            ElseIf Reporte = "Metrico 60 horas" Then ' ---AO 2024-05-08
                Metrico60Horas(dtDatos, dtInformacion)

            ElseIf Reporte = "Ausentismo diario" Then ' ---AO 2024-11-15
                AusentismoDiario(dtDatos, dtInformacion)

                '**** TIME ALLOCATION
            ElseIf Reporte = "Auditoria de horas" Then
                AuditoriaHoras(dtDatos, dtInformacion)
            ElseIf Reporte = "Diferencias en distribucion de horas por departamento" Or Reporte = "Diferencias en distribucion de horas por supervisor" Then
                DiferenciasTAlloc(dtDatos, dtInformacion)
            ElseIf Reporte = "Distribución de horas y ausentismo" Then
                DistribucionHorasAusentismo(dtDatos, dtInformacion)
            ElseIf Reporte = "Residencias profesionales" Then
                Residencias(dtDatos, dtInformacion) '********************************JOSE*******************
            ElseIf Reporte = "Excel Ausentismo Semanal" Then '****************************JOSE***********
                ExcelAusentismo(dtDatos, dtInformacion)
            ElseIf Reporte = "Excel Ausentismo Semanal A" Then '****************************JOSE***********
                ExcelAusentismo(dtDatos, dtInformacion)
            ElseIf Reporte = "Prenómina semanal" Then
                PrenominaSemanal(dtDatos, dtInformacion)
            ElseIf Reporte = "Excel detalle de vacaciones programadas" Then '****************************AO***********
                ExcelVacsProg(dtDatos, dtInformacion)
            ElseIf Reporte = "Excel registro de asistencia vertical" Then '****************************AO***********
                ExcelAsistVertical(dtDatos, dtInformacion)

                '==========================================================================================================================================================================================
                '==========================================================================================================================================================================================
                '===============================================================================NOMINA=====================================================================================================
                '==========================================================================================================================================================================================
                '==========================================================================================================================================================================================

                '== Percepciones totales anual por empleado             Ernesto         20oct2021

            ElseIf Reporte = "Reporte de tiempo extra y bonos administrativos" Then
                ReporteTiempoExtraBonosAdmin(dtDatos, dtInformacion)

            ElseIf Reporte = "Reporte de movimientos mensual" Then
                ReportePerTotEmpMensualQro(dtDatos, dtInformacion)

            ElseIf Reporte = "Reporte totales por concepto" Then
                ReporteTotalesConcepto(dtDatos, dtInformacion)

            ElseIf Reporte = "Reporte Percepciones Empleado" Then
                ReportePerTotEmpAnual(dtDatos, dtInformacion)

            ElseIf Reporte = "No Timbrados" Then  'Antonio
                NoTimbrados(dtDatos, dtInformacion)  'Antonio

            ElseIf Reporte = "Solicitud de Retiro" Then 'Antonio
                Dim SRep = Reporte
                LlenarWORDWME(dtDatos, dtInformacion, SRep) 'Antonio

            ElseIf Reporte = "Relacion De Recibos Nomina" Then  '--Adrian Ortega
                RelacionDeRecibosNomina(dtDatos, dtInformacion)  '--Adrian ortega

            ElseIf Reporte = "Acuse Finiquito" Then
                AcuseFiniquito(dtDatos, dtInformacion)

            ElseIf Reporte = "ConvenioFiniquito" Then
                ConvenioFiniquito(dtDatos, dtInformacion)

                '== Convenio finiquito adicional        10mar22     Ernesto
            ElseIf Reporte = "ConvenioFiniquito2" Then
                ConvenioFiniquitoAdicional(dtDatos, dtInformacion)


            ElseIf Reporte = "Liquidación FAH" Then
                LiquidacionFAH(dtDatos, dtInformacion)

            ElseIf Reporte = "Diferencia en conceptos" Then

                DifConcCalcNom(dtDatos, dtInformacion)



            ElseIf Reporte = "Reporte de ISN" Then
                ReporteISN(dtDatos, dtInformacion)
            ElseIf Reporte = "Ajustes a nómina exportados Detalle" Then
                AjustesNominaDetalle(dtDatos, dtInformacion)
            ElseIf Reporte = "Finiquito" Then
                ReporteFiniquito(dtDatos, dtInformacion)
            ElseIf Reporte = "Ajustes a nómina exportados" Then
                If TipoPeriodo = "Q" Then ResumenTotComedores(dtDatos, dtInformacion) ' AOS 14/05/2019
            ElseIf Reporte = "Reporte de póliza" Then
                ReportePoliza(dtDatos, dtInformacion)
                'ElseIf Reporte = "Listado de nómina" Then
                '    ListadoNomina(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de nómina" Then
                ReporteNomina(dtDatos, dtInformacion)
            ElseIf Reporte = "Horas por centro de costos" Or Reporte = "Horas por centro de costos Detalle" Then
                HorasCC(dtDatos, dtInformacion)
            ElseIf Reporte = "Horas por centro de costos - Póliza" Then ' AOS --> 02/10/2019
                HorasCC_Poliza(dtDatos, dtInformacion)
            ElseIf Reporte = "Horas por centro de costos Detalle incidencias" Then ' AOS 28/10/2019
                HorasCC_Detalle_Incidencias(dtDatos, dtInformacion)
            ElseIf Reporte = "Horas por centro de costos TA" Then
                HorasCCTA(dtDatos, dtInformacion)
            ElseIf Reporte = "Cifra de Control" Then
                'CaratulaGeneral(dtDatos, dtInformacion)
                CifraControl(dtDatos, dtInformacion)
            ElseIf Reporte = "Listado De Raya" Then
                ListadoRaya(dtDatos, dtInformacion)
            ElseIf Reporte = "Listado Raya" Then
                ListadoRaya(dtDatos, dtInformacion)
            ElseIf Reporte = "Desglose nómina excel" Then
                DesgloseExcel(dtDatos, dtInformacion)
                '------------------------------------------------------Edgar------------------------------------------------------
            ElseIf Reporte = "Checada Salary" Then
                ChecadaSalary(dtDatos, dtInformacion)

            ElseIf Reporte = "Listado cambios salario" Then
                Listadocambiossalario(dtDatos, dtInformacion)

            ElseIf Reporte = "Caja de ahorro" Then

                Cajadeahorro(dtDatos, dtInformacion) ', ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2))

            ElseIf Reporte = "Compensacion Tunel" Then

                CompensacionTunel(dtDatos, dtInformacion) ', ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2))

            ElseIf Reporte = "Cuota Sindical" Then

                CuotaSindical(dtDatos, dtInformacion) ', ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2))

            ElseIf Reporte = "Prestamo Caja Ahorro" Then

                PrestamoCajaAhorro(dtDatos, dtInformacion) ', ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2))


            ElseIf Reporte = "Aportaciones Fondo de Ahorro" Then

                AportacionesFondodeAhorro(dtDatos, dtInformacion)

            ElseIf Reporte = "Reporte de nómina a excel (español)" Then
                NominaExcel(dtDatos, dtInformacion, False)

            ElseIf Reporte = "Reporte de nómina a excel (por CC)" Then
                NominaExcelCC(dtDatos, dtInformacion, False)
            ElseIf Reporte = "Acumulado por Conceptos" Then
                AcumuladoConceptos(dtDatos, dtInformacion)

                '-------------------------------------------------------------------------------------
                ' ********** PAGOS ELECTRONICOS **********
            ElseIf Reporte = "Reporte de póliza" Then
                'If ParametrosAdicionales IsNot Nothing Then
                '    ReportePoliza(dtDatos, dtInformacion, ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2), ParametrosAdicionales(3))
                'Else
                ReportePoliza(dtDatos, dtInformacion)
                'End If
            ElseIf Reporte = "Pagos electrónicos" Then
                If ParametrosAdicionales IsNot Nothing Then
                    PagosElectronicos(dtDatos, dtInformacion, ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2), ParametrosAdicionales(3), cod_comp:=cod_comp)
                Else
                    dtDatos = dtInformacion.Clone
                End If
            ElseIf Reporte = "Pagos electrónicos Pensiones" Then
                If ParametrosAdicionales IsNot Nothing Then
                    PagosElectronicosPEN(dtDatos, dtInformacion, ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2), ParametrosAdicionales(3))
                Else
                    dtDatos = dtInformacion.Clone
                End If
            ElseIf Reporte = "Flujo de efectivo" Then
                If ParametrosAdicionales IsNot Nothing Then
                    FlujoEfectivo(dtDatos, dtInformacion, ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2), ParametrosAdicionales(3))
                Else
                    dtDatos = dtInformacion.Clone
                End If
            ElseIf Reporte = "Bonos de despensa" Then
                If ParametrosAdicionales IsNot Nothing Then
                    BonosDespensa(dtDatos, dtInformacion, ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2))
                Else
                    dtDatos = dtInformacion.Clone
                End If
            ElseIf Reporte = "Ordenes de pago Referenciadas" Then
                If ParametrosAdicionales IsNot Nothing Then
                    OrdenesPagosConvenio(dtDatos, dtInformacion, ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2), ParametrosAdicionales(3))
                Else
                    dtDatos = dtInformacion.Clone
                End If
            ElseIf Reporte = "Dispersión convenio" Then
                If ParametrosAdicionales IsNot Nothing Then
                    DispersionConvenio(dtDatos, dtInformacion, ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2), ParametrosAdicionales(3))
                Else
                    dtDatos = dtInformacion.Clone
                End If
            ElseIf Reporte = "Pagos por convenio" Then
                If ParametrosAdicionales IsNot Nothing Then
                    PagosConvenio(dtDatos, dtInformacion, ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2), ParametrosAdicionales(3))
                Else
                    dtDatos = dtInformacion.Clone
                End If
            ElseIf Reporte = "Movimientos fondo ahorro" Then
                If ParametrosAdicionales IsNot Nothing Then
                    MovimientosFAH(dtDatos, dtInformacion, ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2), ParametrosAdicionales(3))
                Else
                    MovimientosFAH(dtDatos, dtInformacion)
                    'dtDatos = dtInformacion.Clone
                End If
                '****************************************************
            ElseIf Reporte = "Movimientos fondo ahorro Vector" Then
                If ParametrosAdicionales IsNot Nothing Then
                    MovimientosFAHVector(dtDatos, dtInformacion, ParametrosAdicionales(0), ParametrosAdicionales(1), ParametrosAdicionales(2), ParametrosAdicionales(3))
                Else

                    dtDatos = dtInformacion.Clone
                End If
                '****************************************************
            ElseIf Reporte = "Relación de saldos de vacaciones" Then
                RelacionVacaciones(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de nómina excel" Then
                NominaExcel(dtDatos, dtInformacion, False)
            ElseIf Reporte = "Relación de personal numérica" Then
                RelacionPersonalNum(dtDatos, dtInformacion)
            ElseIf Reporte = "Relación de personal alfabética" Then
                RelacionPersonalNum(dtDatos, dtInformacion)
            ElseIf Reporte = "Relación semanal de descuentos de infonavit" Then
                DescuentosInfonavit(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de fondo de ahorro" Then
                FondoAhorro(dtDatos, dtInformacion)
            ElseIf Reporte = "Préstamos de fondo de ahorro" Then
                PrestamosFondoAhorro(dtDatos, dtInformacion)
            ElseIf Reporte = "Carga días de vacaciones" Then   '****nuevo
                CargaVacaciones(dtDatos, dtInformacion)
            ElseIf Reporte = "Relación de saldos de descuento" Then

                If ParametrosAdicionales IsNot Nothing Then
                    SaldosDescuentos(dtDatos, dtInformacion, ParametrosAdicionales(0))
                Else
                    SaldosDescuentos(dtDatos, dtInformacion)
                End If

                '********* CAPACITACION ***********************************************
            ElseIf Reporte = "Licencia para montacargas" Then
                LicenciaMontacargas(dtDatos, dtInformacion)
            ElseIf Reporte = "Licencia para PalletJack" Then
                LicenciaPalletJack(dtDatos, dtInformacion)
            ElseIf Reporte = "Gafete de certificación" Then
                GafeteCertificacion(dtDatos, dtInformacion)
            ElseIf Reporte = "Registro de entrenamiento" Then
                RegistroEntrenamiento(dtDatos, dtInformacion) '**********************************CARLOS**************************
            ElseIf Reporte = "FORMATO DC4" Then
                FormatoDC4(dtDatos, dtInformacion) '**********************************CARLOS**************************
            ElseIf Reporte = "Reporte de cursos tomados" Then
                ReporteCursosTomados(dtDatos, dtInformacion) '**********************************CARLOS**************************
            ElseIf Reporte = "BRP_Constancia de habilidades DC3" Then
                BRPFormatoDC3(dtDatos, dtInformacion) '**********************************CARLOS**************************
            ElseIf Reporte = "Formato DC3" Then
                FormatoDC3(dtDatos, dtInformacion) '**********************************CARLOS**************************
            ElseIf Reporte = "Formato DC3 2017" Then
                FormatoDC3(dtDatos, dtInformacion) '**********************************CARLOS**************************
            ElseIf Reporte = "Matriz de cursos" Then
                MatrizCursos(dtDatos, dtInformacion) '**********************************CARLOS**************************
            ElseIf Reporte = "Relación de cursos impartidos" Then '--chuy--
                ReporteCursosImpartidos(dtDatos, dtInformacion)
            ElseIf Reporte = "Solicitud de Capacitación" Then
                SolicitudCapacitacion(dtDatos) '-------Sergio Núñez 22/Sep/22

            ElseIf Reporte = "Matriz Capacitación" Then
                MatrizCapacitacion(dtDatos, dtInformacion) '**********************************Adrian Ortega**************************

            ElseIf Reporte = "Matriz Capacitacion Empleado" Then
                MatrizCapacitacionPorEmpleado(dtDatos, dtInformacion) '-------------Antonio

            ElseIf Reporte = "Matriz Hue Test" Then
                MatrizHueTest(dtDatos, dtInformacion) ' ************************AO

            ElseIf Reporte = "Matriz de habilidades" Then
                MatrizHabilidades(dtDatos, dtInformacion) '*AOS

            ElseIf Reporte = "Gafete de certificacion" Then
                GafeteDeCertificacion(dtDatos, dtInformacion) '*AOS

                '==Ernesto      julio2021
            ElseIf Reporte = "Reporte de empleados certificados" Then
                EmpleadosCertificados(dtDatos, dtInformacion)

                '== Reporte para empleados por curso            4oct2021        Ernesto
            ElseIf Reporte = "Matriz Capacitacion Cursos" Then
                MatrizCapacitacionPorCurso(dtDatos, dtInformacion)

                '* IDEAS *
            ElseIf Reporte = "Ideas pagadas" Then
                IdeasPagadas(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de sugerencias por objetivo" Then
                SugerenciasObjetivos(dtDatos, dtInformacion)
            ElseIf Reporte = "Participación en el programa de ideas" Then
                ParticipacionIdeas(dtDatos, dtInformacion)
            ElseIf Reporte = "Formato de ideas capturadas" Then
                FormatoIdeas(dtDatos, dtInformacion)
            ElseIf Reporte = "Participación en el programa de ideas por departamento con bajas" Then  '**********************************CARLOS************************** 'Participación de mi Departamento
                'ParticipacionIdeasCBajas(dtDatos, dtInformacion) ' CARLOS IDEAS 22 septiembre
                ParticipacionIndividualIdeasCBajas(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de participación por planta" Then
                ParticipacionIdeasCBajas(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de participación por departamento" Then
                ParticipacionDepartamento(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de participación por supervisor" Then '****************************************CARLOS**************************
                ParticipacionDepartamento(dtDatos, dtInformacion)
            ElseIf Reporte = "Participación de mi departamento" Then
                ParticipacionIndividualIdeas(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de participación individual en el programa ideas" Then
                ParticipacionIndividualIdeas(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte de participación por departamento Totales" Then
                ParticipacionIndividualIdeas(dtDatos, dtInformacion)
            ElseIf Reporte = "Formato en blanco para impresión" Then
                FormatoIdeasVacio(dtDatos, dtInformacion)
            ElseIf Reporte = "Detalle de cumplimiento" Then
                DetalleCumplimiento(dtDatos, dtInformacion)
            ElseIf Reporte = "Reporte Resultado de IDOO" Then
                ParticipacionIDOO(dtDatos, dtInformacion)
                '* SERVICIOS MEDICOS*
            ElseIf Reporte = "Reporte familiares mayores de 16 años" Then
                Familiares16(dtDatos, dtInformacion)
            ElseIf Reporte = "Relacion de Consultas" Then
                RelacionConsultas(dtDatos, dtInformacion)
            ElseIf Reporte = "Expediente Personal" Then
                Expediente(dtDatos, dtInformacion)
            End If

            Return dtDatos

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "PreparaDatos", ex.HResult, ex.Message)
            Return Nothing
        End Try
    End Function
End Module
