Public Class frmrevision

#Region "Declaraciones"
    Dim dtLocal As New DataTable        'Lista de datos para grid
    Dim dtTitulo As New DataTable       'Tabla de Titulos
    Dim dtVacantes As New DataTable     'Mantiene el registro actual
    'Dim dtMedios As New DataTable        'Tabla de Medios
    Dim dtGenero As New DataTable        'Tabla de Generos
    Dim dtCivil As New DataTable         'Tabla de Estados Civiles
    Dim dtCiudad As New DataTable        'Tabla de Ciudades
    Dim dtPaises As New DataTable        'Tabla de Paises
    Dim dtEstados As New DataTable       'Tabla de Estados
    Dim dtEstados2 As New DataTable      'Tabla de Estados
    Dim dtColonia As New DataTable
    Dim dtCP As New DataTable
    Dim dtGrado As New DataTable
    Dim dtTipoEmpleado As New DataTable      'Tabla de tipos de empleado
    Dim dtClaseEmpleado As New DataTable      'Tabla de clases de empleado
    Dim dtPayScaleGroup As New DataTable      'Tabla de Pay Scale Group
    Dim dtHorario As New DataTable      'Tabla de Horarios
    Dim dtPosicion As New DataTable      'Tabla de Posiciones
    Dim dtAuxiliares As New DataTable       'Para sacar varios datos de auxiliares
    Dim dtMunicipios As New DataTable   'Tabla de Municipios
    Dim TabActual As Integer
    Dim dtTurnos As New DataTable   'Tabla de Turnos
    Dim dtNiveles As New DataTable   'Tabla de Niveles
    Dim Editar As Boolean = False
    Dim Cancelar As Boolean = False
    Dim banderaError As Boolean
    Dim dtRegistro As New DataTable     'Mantiene el registro actual
    Dim dtTemp As New DataTable        'Tabla de uso general
    Dim esReingreso As Boolean = False

#End Region

    Private Sub frmrevision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            banderaError = False

            dtVacantes = sqlExecute("select Cod_Vac as 'CODIGO',Vacante as 'VACANTE' from vacantes order by Vacante", "Reclutamiento")
            cmbVacante.DataSource = dtVacantes
            cmbVacante.ValueMember = "CODIGO"
            cmbVacante.DisplayMembers = "VACANTE"
            cmbVacante.SelectedIndex = -1

            dtTitulo = sqlExecute("select Rtrim(Ltrim(codigo)) as 'CODIGO', Rtrim(Ltrim(nombre)) as 'NOMBRE'  from Salutation order by nombre", "Reclutamiento")
            cmbTitulo.DataSource = dtTitulo
            cmbTitulo.ValueMember = "CODIGO"
            cmbTitulo.DisplayMembers = "NOMBRE"
            cmbTitulo.SelectedIndex = -1

            dtPaises = sqlExecute("select Rtrim(Ltrim(CODE)) as 'CODIGO', Rtrim(Ltrim(Nombre)) as 'NOMBRE'  from CountryISO order by Nombre", "Reclutamiento")
            cmbPaisNac.DataSource = dtPaises
            cmbPaisNac.ValueMember = "CODIGO"
            cmbPaisNac.DisplayMembers = "NOMBRE"
            cmbPaisNac.SelectedIndex = -1

            dtEstados = sqlExecute("select Rtrim(Ltrim(COD_EDO)) as 'CODIGO', Rtrim(Ltrim(NOMBRE)) as 'NOMBRE'  from estados order by NOMBRE", "Reclutamiento")
            cmbEstadoNac.DataSource = dtEstados
            cmbEstadoNac.ValueMember = "CODIGO"
            cmbEstadoNac.DisplayMembers = "NOMBRE"
            cmbEstadoNac.SelectedIndex = -1

            dtEstados2 = sqlExecute("select Rtrim(Ltrim(COD_EDO)) as 'CODIGO', Rtrim(Ltrim(NOMBRE)) as 'NOMBRE'  from estados order by NOMBRE", "Reclutamiento")
            cmbEstado.DataSource = dtEstados2
            cmbEstado.ValueMember = "CODIGO"
            cmbEstado.DisplayMembers = "NOMBRE"
            cmbEstado.SelectedIndex = -1

            dtMunicipios = sqlExecute("select Rtrim(Ltrim(COD_MUN)) as 'CODIGO', Rtrim(Ltrim(NOMBRE)) as 'NOMBRE'  from municipios order by NOMBRE", "reclutamiento")
            cmbMunicipio.DataSource = dtMunicipios
            cmbMunicipio.ValueMember = "CODIGO"
            cmbMunicipio.DisplayMembers = "NOMBRE"
            cmbMunicipio.SelectedIndex = -1

            swGenero.Value = False

            dtCivil = sqlExecute("select Rtrim(Ltrim(COD_CIVIL)) as 'CODIGO', Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from civil")
            cmbCivil.DataSource = dtCivil
            cmbCivil.ValueMember = "CODIGO"
            cmbCivil.DisplayMembers = "NOMBRE"
            cmbCivil.SelectedIndex = -1

            dtCiudad = sqlExecute("select Rtrim(Ltrim(COD_CD)) as 'CODIGO', Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from ciudad order by nombre")
            cmbCiudad.DataSource = dtCiudad
            cmbCiudad.ValueMember = "CODIGO"
            cmbCiudad.DisplayMembers = "NOMBRE"
            cmbCiudad.SelectedIndex = -1

            'dtColonia = sqlExecute("select Rtrim(Ltrim(cod_col)) as 'CODIGO',Rtrim(Ltrim(nombre)) as 'NOMBRE' from colonias where Rtrim(Ltrim(ISNULL(COD_COL,''))) <> '' and Rtrim(Ltrim(ISNULL(nombre,''))) <> '' order by nombre")
            'cmbColonia2.DataSource = dtColonia
            'cmbColonia2.ValueMember = "CODIGO"
            'cmbColonia2.DisplayMember = "NOMBRE"
            'cmbColonia2.SelectedIndex = -1

            dtColonia = sqlExecute("select * from colonias")
            cmbColonia.DataSource = dtColonia

            dtAuxiliares = sqlExecute("select idFld as 'CODIGO', CAMPO_VALIDO as 'NOMBRE' from personal.dbo.auxiliares_validos where campo = 'T_PANTALON'")
            cmbTallaPantalon.DataSource = dtAuxiliares
            cmbTallaPantalon.ValueMember = "CODIGO"
            cmbTallaPantalon.DisplayMember = "NOMBRE"
            cmbTallaPantalon.SelectedIndex = -1

            dtAuxiliares = sqlExecute("select idFld as 'CODIGO', CAMPO_VALIDO as 'NOMBRE' from personal.dbo.auxiliares_validos where campo = 'T_PLAYERA'")
            cmbTallaPlayera.DataSource = dtAuxiliares
            cmbTallaPlayera.ValueMember = "CODIGO"
            cmbTallaPlayera.DisplayMember = "NOMBRE"
            cmbTallaPlayera.SelectedIndex = -1

            dtAuxiliares = sqlExecute("select idFld as 'CODIGO', CAMPO_VALIDO as 'NOMBRE' from personal.dbo.auxiliares_validos where campo = 'T_ZAPATO'")
            cmbTallaZapato.DataSource = dtAuxiliares
            cmbTallaZapato.ValueMember = "CODIGO"
            cmbTallaZapato.DisplayMember = "NOMBRE"
            cmbTallaZapato.SelectedIndex = -1

            dtGrado = sqlExecute("select Rtrim(Ltrim(COD_ESCUELA)) as 'CODIGO',Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from escuelas order by COD_ESCUELA")
            cmbGrado.DataSource = dtGrado
            cmbGrado.ValueMember = "CODIGO"
            cmbGrado.DisplayMembers = "NOMBRE"
            cmbGrado.SelectedIndex = -1

            'dtTipoEmpleado = sqlExecute("select Rtrim(Ltrim(cod_tipo_empleado)) as 'CODIGO',Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from tipo_empleado order by cod_tipo_empleado", "Reclutamiento")
            'cmbTipoEmpleado.DataSource = dtTipoEmpleado
            'cmbTipoEmpleado.ValueMember = "CODIGO"
            'cmbTipoEmpleado.DisplayMembers = "NOMBRE"
            'cmbTipoEmpleado.SelectedIndex = -1

            dtTipoEmpleado = sqlExecute("select top 1 Rtrim(Ltrim(cod_tipo_empleado)) as 'CODIGO',Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from tipo_empleado order by cod_tipo_empleado", "Reclutamiento")
            If dtTipoEmpleado.Rows.Count > 0 Then
                txtTipoEmpleado.Text = dtTipoEmpleado.Rows(0).Item("CODIGO") & "-" & dtTipoEmpleado.Rows(0).Item("nombre")
            End If

            dtClaseEmpleado = sqlExecute("select Rtrim(Ltrim(cod_clase_empleado)) as 'CODIGO',Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from clase_empleado order by cod_clase_empleado", "Reclutamiento")
            cmbClaseEmpleado.DataSource = dtClaseEmpleado
            cmbClaseEmpleado.ValueMember = "CODIGO"
            cmbClaseEmpleado.DisplayMembers = "NOMBRE"
            cmbClaseEmpleado.SelectedIndex = -1

            'dtPayScaleGroup = sqlExecute("select Rtrim(Ltrim(cod_pay_scale_group)) as 'CODIGO',Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from pay_scale_group order by cod_pay_scale_group", "Reclutamiento")
            'cmbPayScaleGroup.DataSource = dtPayScaleGroup
            'cmbPayScaleGroup.ValueMember = "CODIGO"
            'cmbPayScaleGroup.DisplayMembers = "NOMBRE"
            'cmbPayScaleGroup.SelectedIndex = -1

            dtHorario = sqlExecute("select Rtrim(Ltrim(cod_hora)) as 'CODIGO',Rtrim(Ltrim(cod_hora))+'   '+Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from horarios where cod_comp = 'WME' order by cod_hora")
            cmbHorario.DataSource = dtHorario
            cmbHorario.ValueMember = "CODIGO"
            cmbHorario.DisplayMember = "NOMBRE"
            cmbHorario.SelectedIndex = -1

            dtPosicion = sqlExecute("select Rtrim(Ltrim(cod_posicion)) as 'CODIGO',Rtrim(Ltrim(num_posicion)) as 'NOMBRE' from posiciones where status = 1 order by num_posicion", "Reclutamiento")
            cmbPosicion.DataSource = dtPosicion
            cmbPosicion.ValueMember = "CODIGO"
            cmbPosicion.DisplayMember = "NOMBRE"
            cmbPosicion.SelectedIndex = -1

            dtAuxiliares = sqlExecute("select idFld as 'CODIGO', CAMPO_VALIDO as 'NOMBRE' from personal.dbo.auxiliares_validos where campo = 'FUENTE_R'")
            cmbMedio.DataSource = dtAuxiliares
            cmbMedio.ValueMember = "CODIGO"
            cmbMedio.DisplayMember = "NOMBRE"
            cmbMedio.SelectedIndex = -1

            dtAuxiliares = sqlExecute("select idFld as 'CODIGO', CAMPO_VALIDO as 'NOMBRE' from personal.dbo.auxiliares_validos where campo = 'AGENCIA'")
            cmbAgencia.DataSource = dtAuxiliares
            cmbAgencia.ValueMember = "CODIGO"
            cmbAgencia.DisplayMember = "NOMBRE"
            cmbAgencia.SelectedIndex = -1

            dtAuxiliares = sqlExecute("select idFld as 'CODIGO', CAMPO_VALIDO as 'NOMBRE' from personal.dbo.auxiliares_validos where campo = 'RUTA'")
            cmbRuta.DataSource = dtAuxiliares
            cmbRuta.ValueMember = "CODIGO"
            cmbRuta.DisplayMember = "NOMBRE"
            cmbRuta.SelectedIndex = -1

            dtTurnos = sqlExecute("select Rtrim(Ltrim(COD_TURNO)) as 'CODIGO', Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from personal.dbo.turnos where cod_comp = 'WME' order by nombre")
            cmbTurnoFinal.DataSource = dtTurnos
            cmbTurnoFinal.ValueMember = "CODIGO"
            cmbTurnoFinal.DisplayMember = "NOMBRE"

            dtNiveles = sqlExecute("select Rtrim(Ltrim(NIVEL)) as 'CODIGO', Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from personal.dbo.niveles where cod_comp = 'WME'  and len(rtrim(nombre)) > 0 and cod_tipo = 'O' order by nombre")
            cmbNivel.DataSource = dtNiveles
            cmbNivel.ValueMember = "CODIGO"
            cmbNivel.DisplayMember = "NOMBRE"

            dtRegistro = sqlExecute("select top 1 * from Candidatos order by Folio ASC", "Reclutamiento")

        Catch ex As Exception

        End Try

        HabilitarBotones()
        MostrarInformacion()
    End Sub

    Private Sub HabilitarBotones()

        Try
            'btnPrimero.PerformClick()

            btnPrimero.Enabled = Not Editar Or Cancelar
            btnAnterior.Enabled = Not Editar Or Cancelar
            btnSiguiente.Enabled = Not Editar Or Cancelar
            btnUltimo.Enabled = Not Editar Or Cancelar
            btnBuscar.Enabled = Not Editar Or Cancelar
            btnReporte.Enabled = Not Editar Or Cancelar

            'gpVacante.Enabled = Editar And Not Cancelar
            'TabRegistro.Enabled = Editar And Not Cancelar
            Panel3.Enabled = Editar And Not Cancelar
            PnlCaptura.Enabled = Editar And Not Cancelar
            SuperTabControlPanel2.Enabled = Editar And Not Cancelar
            SuperTabControlPanel3.Enabled = Editar And Not Cancelar
            SuperTabControlPanel4.Enabled = Editar And Not Cancelar
            'TapComAprob.Enabled = Editar And Not Cancelar
            cmbVacante.Enabled = Editar And Not Cancelar
            cmbFechaAplica.Enabled = Editar And Not Cancelar

            If Editar Then
                ' Si está activa nuevo registro
                btnNuevo.Image = PIDA.My.Resources.Ok16
                btnNuevo.Text = "Aceptar"
                btnCerrar.Text = "Cancelar"
            Else
                btnNuevo.Image = PIDA.My.Resources.Edit
                btnNuevo.Text = "Editar"
                btnCerrar.Text = "Salir"
            End If
            txtFolio.ReadOnly = True
            txtComentariosEntrevistaRH.ReadOnly = True
            swAprobadoEntrevistaRH.Enabled = False
            txtComentariosMedico.ReadOnly = True
            swAprobadoMed.Enabled = False
            txtComentariosSupervisor.ReadOnly = True
            swAprobadoSup.Enabled = False

            'If Editar Or Cancelar Then
            If Cancelar Then
                MostrarInformacion()
                'btnPrimero.PerformClick()
                Cancelar = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("Candidatos", "Folio", dtRegistro, "Reclutamiento")
        HabilitarBotones()
        MostrarInformacion()
    End Sub

    Private Sub MostrarInformacion()
        Try
            ' If Not dtRegistro.Rows.Count > 0 Or Not dgCalogVacantes.Rows.Count > 0 Then Exit Sub
            If dtRegistro.Rows.Count > 0 Then
                txtFolio.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Folio")), "", dtRegistro.Rows(0).Item("Folio"))
                cmbVacante.SelectedValue = dtRegistro.Rows(0).Item("cod_vac").ToString
                cmbFechaAplica.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("Captura")), Nothing, Date.Parse(FechaSQL(dtRegistro.Rows(0).Item("Captura"))))
                cmbTitulo.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("salutation")), "MR", dtRegistro.Rows(0).Item("salutation").ToString.ToUpper.Replace(".", ""))
                txtNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nombre")), "", dtRegistro.Rows(0).Item("nombre").ToString.Trim)
                txtSegundoNombre.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("SegundoNombre")), "", dtRegistro.Rows(0).Item("SegundoNombre").ToString.Trim)
                txtPaterno.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Paterno")), "", dtRegistro.Rows(0).Item("Paterno").ToString.Trim)
                txtMaterno.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Materno")), "", dtRegistro.Rows(0).Item("Materno").ToString.Trim)
                txtIMSS.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("IMSS")), "", dtRegistro.Rows(0).Item("IMSS").ToString.Trim)
                txtIMSSdv.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("DIG_VER")), "", dtRegistro.Rows(0).Item("DIG_VER").ToString.Trim)
                txtRFC.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("RFC")), "", dtRegistro.Rows(0).Item("RFC").ToString.Trim)
                Try
                    txtCurp.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("CURP")), "", dtRegistro.Rows(0).Item("CURP").ToString.Trim)
                Catch
                End Try
                If IsDBNull(dtRegistro.Rows(0).Item("Genero")) Then
                    swGenero.SetValue(True, DevComponents.DotNetBar.eEventSource.Code)
                Else
                    If dtRegistro.Rows(0).Item("Genero").ToString = "M" Then
                        swGenero.SetValue(True, DevComponents.DotNetBar.eEventSource.Code)
                    Else
                        swGenero.SetValue(False, DevComponents.DotNetBar.eEventSource.Code)
                    End If
                End If
                txtNacionalidad.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("nacionalidad")), "", dtRegistro.Rows(0).Item("nacionalidad"))
                cmbCivil.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("Cod_civil")), "", dtRegistro.Rows(0).Item("Cod_civil"))
                intNumeroHijos.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Numero_Hijos")), "0", dtRegistro.Rows(0).Item("Numero_Hijos").ToString.Trim)
                txtDireccion.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Direccion")), "", dtRegistro.Rows(0).Item("Direccion"))
                txtDepartamento.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Departamento")), "", dtRegistro.Rows(0).Item("Departamento"))
                cmbCiudad.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("Ciudad")), "00305", dtRegistro.Rows(0).Item("Ciudad"))
                cmbColonia.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_col")), "", dtRegistro.Rows(0).Item("cod_col"))
                If IsNothing(cmbColonia.SelectedValue) Then
                    cmbColonia.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("colonia")), "", dtRegistro.Rows(0).Item("colonia"))
                End If
                cmbMunicipio.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("Municipio")), "", dtRegistro.Rows(0).Item("Municipio"))
                cmbTallaPantalon.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("TallaPantalon")), "", dtRegistro.Rows(0).Item("TallaPantalon"))
                cmbTallaPlayera.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("TallaPlayera")), "", dtRegistro.Rows(0).Item("TallaPlayera"))
                cmbTallaZapato.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("TallaZapato")), "", dtRegistro.Rows(0).Item("TallaZapato"))
                txtCP.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("CP")), "", dtRegistro.Rows(0).Item("CP"))
                cmbEstado.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("Cod_Est")), "QT", dtRegistro.Rows(0).Item("Cod_Est"))
                txtTelefono1.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Telefono1")), "", dtRegistro.Rows(0).Item("Telefono1"))
                txtTelefono2.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Telefono2")), "", dtRegistro.Rows(0).Item("Telefono2"))
                txtTelefono3.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Telefono3")), "", dtRegistro.Rows(0).Item("Telefono3"))
                txtTelefono4.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Telefono4")), "", dtRegistro.Rows(0).Item("Telefono4"))
                txtTelefono5.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Telefono5")), "", dtRegistro.Rows(0).Item("Telefono5"))
                txtLugarNacimiento.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("lugar_nac")), "", dtRegistro.Rows(0).Item("lugar_nac"))
                If IsDBNull(dtRegistro.Rows(0).Item("FhaNac")) Then
                    cmbFechaNac.Value = Nothing
                Else
                    cmbFechaNac.Value = Date.Parse(FechaSQL(dtRegistro.Rows(0).Item("FhaNac")))
                End If

                cmbPaisNac.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("Cod_Pais_Nac")), "", dtRegistro.Rows(0).Item("Cod_Pais_Nac"))
                cmbEstadoNac.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("Cod_Est_Nac")), "", dtRegistro.Rows(0).Item("Cod_Est_Nac"))
                cmbGrado.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("UltimoGrado")), "", dtRegistro.Rows(0).Item("UltimoGrado"))
                txtOtroGrado.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("OtroGrado")), "", dtRegistro.Rows(0).Item("OtroGrado"))

                txtNomEmp1.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("NomEmpUltTrab")), "", dtRegistro.Rows(0).Item("NomEmpUltTrab"))
                txtPuesto1.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("PuestoUltTrab")), "", dtRegistro.Rows(0).Item("PuestoUltTrab"))
                txtSueldo1.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("SueldoMenUltTrab")), "", dtRegistro.Rows(0).Item("SueldoMenUltTrab"))
                txtIngreso1.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("AnoIngresoUltTrab")), "", dtRegistro.Rows(0).Item("AnoIngresoUltTrab").trim)
                txtBaja1.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("AnoBajaUltimoTrab")), "", dtRegistro.Rows(0).Item("AnoBajaUltimoTrab").trim)
                txtActividades1.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("ActUltTrab")), "", dtRegistro.Rows(0).Item("ActUltTrab"))

                txtNomEmp2.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("NomEmpPenTrab")), "", dtRegistro.Rows(0).Item("NomEmpPenTrab"))
                txtPuesto2.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("PuestoPenTrab")), "", dtRegistro.Rows(0).Item("PuestoPenTrab"))
                txtSueldo2.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("SueldoMenPenTrab")), "", dtRegistro.Rows(0).Item("SueldoMenPenTrab"))
                txtIngreso2.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("AnoIngresoPenTrab")), "", dtRegistro.Rows(0).Item("AnoIngresoPenTrab").trim)
                txtBaja2.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("AnoBajaPenTrab")), "", dtRegistro.Rows(0).Item("AnoBajaPenTrab").trim)
                txtActividades2.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("ActPenTrab")), "", dtRegistro.Rows(0).Item("ActPenTrab"))

                txtNomEmp3.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("NomEmpAntTrab")), "", dtRegistro.Rows(0).Item("NomEmpAntTrab"))
                txtPuesto3.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("PuestoAntTrab")), "", dtRegistro.Rows(0).Item("PuestoAntTrab"))
                txtSueldo3.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("SueldoMenAntTrab")), "", dtRegistro.Rows(0).Item("SueldoMenAntTrab"))
                txtIngreso3.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("AnoIngresoAntTrab")), "", dtRegistro.Rows(0).Item("AnoIngresoAntTrab").trim)
                txtBaja3.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("AnoBajaAntTrab")), "", dtRegistro.Rows(0).Item("AnoBajaAntTrab").trim)
                txtActividades3.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("ActAntTrab")), "", dtRegistro.Rows(0).Item("ActAntTrab"))

                If IsDBNull(dtRegistro.Rows(0).Item("pertenecioASindicato")) Then
                    cbSindicato.Checked = False
                Else
                    If dtRegistro.Rows(0).Item("pertenecioASindicato") = "1" Then
                        cbSindicato.Checked = True
                    Else
                        cbSindicato.Checked = False
                    End If
                End If

                'txtComentariosCandidato.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Comentarios")), "", dtRegistro.Rows(0).Item("Comentarios"))
                If IsDBNull(dtRegistro.Rows(0).Item("AceptaPoliPriva")) Then
                    Cbpoliticas.Checked = False
                Else
                    If dtRegistro.Rows(0).Item("AceptaPoliPriva") = "1" Then
                        Cbpoliticas.Checked = True
                    Else
                        Cbpoliticas.Checked = False
                    End If
                End If
                cmbMedio.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Medio")), "", dtRegistro.Rows(0).Item("Medio"))
                cmbAgencia.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Agencia")), "", dtRegistro.Rows(0).Item("Agencia"))
                cmbRuta.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Ruta")), "", dtRegistro.Rows(0).Item("Ruta"))
                txtRecomendadoPor.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("RecomendadoPor")), "", dtRegistro.Rows(0).Item("RecomendadoPor"))
                'cmbTipoEmpleado.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("TipoEmpleado")), "", dtRegistro.Rows(0).Item("TipoEmpleado"))
                txtTipoEmpleado.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("TipoEmpleado")), "001", dtRegistro.Rows(0).Item("TipoEmpleado"))
                Dim dtTipoEmpleado As DataTable = sqlExecute("select nombre from reclutamiento.dbo.tipo_empleado where cod_tipo_empleado = '" & txtTipoEmpleado.Text & "' and len(rtrim(nombre)) > 0")
                If dtTipoEmpleado.Rows.Count > 0 Then
                    txtTipoEmpleado.Text = txtTipoEmpleado.Text & "-" & dtTipoEmpleado.Rows(0).Item("nombre").ToString.Trim
                End If
                cmbClaseEmpleado.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("ClaseEmpleado")), "", dtRegistro.Rows(0).Item("ClaseEmpleado"))
                txtHorasSemanales.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("HorasSemanales")), "", dtRegistro.Rows(0).Item("HorasSemanales"))
                txtDiasSemana.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("DiasSemana")), "", dtRegistro.Rows(0).Item("DiasSemana"))

                cmbHorario.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("Horario")), "", dtRegistro.Rows(0).Item("Horario"))
                Dim dtPosiciones As DataTable = sqlExecute("select cod_posicion,num_posicion from posiciones where status = 1 and cod_vacante = '" & dtRegistro.Rows(0).Item("cod_vac") & "' or cod_posicion = '" & dtRegistro.Rows(0).Item("Position") & "'", "Reclutamiento")
                If dtPosiciones.Rows.Count > 0 Then
                    cmbPosicion.DataSource = dtPosiciones
                    cmbPosicion.ValueMember = "cod_posicion"
                    cmbPosicion.DisplayMember = "num_posicion"
                    If IsDBNull(dtRegistro.Rows(0).Item("Position")) Then
                        cmbPosicion.SelectedIndex = -1
                    Else
                        If dtRegistro.Rows(0).Item("Position").ToString.Length = 0 Then
                            cmbPosicion.SelectedIndex = -1
                        Else
                            cmbPosicion.SelectedValue = dtRegistro.Rows(0).Item("Position")
                        End If
                    End If
                Else
                    cmbPosicion.DataSource = dtPosiciones
                    cmbPosicion.ValueMember = "cod_posicion"
                    cmbPosicion.DisplayMember = "num_posicion"
                    cmbPosicion.SelectedIndex = -1
                End If
                cmbEmloyeeTypeFortia.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("EmployeeTypeFortia")), "", dtRegistro.Rows(0).Item("EmployeeTypeFortia"))
                If IsDBNull(dtRegistro.Rows(0).Item("FechaAlta")) Then
                    cmbFechaAlta.Value = Nothing
                Else
                    cmbFechaAlta.Value = Date.Parse(FechaSQL(dtRegistro.Rows(0).Item("FechaAlta")))
                End If
                If IsDBNull(dtRegistro.Rows(0).Item("FechaVacaciones")) Then
                    cmbFechaVac.Value = Nothing
                Else
                    cmbFechaVac.Value = Date.Parse(FechaSQL(dtRegistro.Rows(0).Item("FechaVacaciones")))
                End If
                If IsDBNull(dtRegistro.Rows(0).Item("FechaAntiguedad")) Then
                    cmbFechaAnt.Value = Nothing
                Else
                    cmbFechaAnt.Value = Date.Parse(FechaSQL(dtRegistro.Rows(0).Item("FechaAntiguedad")))
                End If
                txtSueldoDiario.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("SueldoDiario")), "", dtRegistro.Rows(0).Item("SueldoDiario"))
                txtComentariosEntrevistaRH.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("ComentariosEntrevistaRH")), "", dtRegistro.Rows(0).Item("ComentariosEntrevistaRH"))
                If IsDBNull(dtRegistro.Rows(0).Item("AprobadoEntrevistaRH")) Then
                    swAprobadoEntrevistaRH.CheckState = CheckState.Indeterminate
                    swAprobadoEntrevistaRH.Text = "Pendiente"
                Else
                    If dtRegistro.Rows(0).Item("AprobadoEntrevistaRH").ToString = "1" Then
                        swAprobadoEntrevistaRH.CheckState = CheckState.Checked
                        swAprobadoEntrevistaRH.Text = "Aprobado"
                    Else
                        swAprobadoEntrevistaRH.CheckState = CheckState.Unchecked
                        swAprobadoEntrevistaRH.Text = "Rechazado"
                    End If
                End If
                txtComentariosMedico.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("ComentariosMedico")), "", dtRegistro.Rows(0).Item("ComentariosMedico"))
                If IsDBNull(dtRegistro.Rows(0).Item("AprobadoMedico")) Then
                    swAprobadoMed.CheckState = CheckState.Indeterminate
                    swAprobadoMed.Text = "Pendiente"
                Else
                    If dtRegistro.Rows(0).Item("AprobadoMedico").ToString = "1" Then
                        swAprobadoMed.CheckState = CheckState.Checked
                        swAprobadoMed.Text = "Aprobado"
                    Else
                        swAprobadoMed.CheckState = CheckState.Unchecked
                        swAprobadoMed.Text = "Rechazado"
                    End If
                End If
                txtComentariosSupervisor.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("ComentariosSupervisor")), "", dtRegistro.Rows(0).Item("ComentariosSupervisor"))
                If IsDBNull(dtRegistro.Rows(0).Item("AprobadoSupervisor")) Then
                    swAprobadoSup.CheckState = CheckState.Indeterminate
                    swAprobadoSup.Text = "Pendiente"
                Else
                    If dtRegistro.Rows(0).Item("AprobadoSupervisor").ToString = "1" Then
                        swAprobadoSup.CheckState = CheckState.Checked
                        swAprobadoSup.Text = "Aprobado"
                    Else
                        swAprobadoSup.CheckState = CheckState.Unchecked
                        swAprobadoSup.Text = "Rechazado"
                    End If
                End If
                txtComentariosRH.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("ComentariosRH")), "", dtRegistro.Rows(0).Item("ComentariosRH"))
                If IsDBNull(dtRegistro.Rows(0).Item("AprobadoRH")) Then
                    swAprobadoRH.CheckState = CheckState.Indeterminate
                    swAprobadoRH.Text = "Pendiente"
                Else
                    If dtRegistro.Rows(0).Item("AprobadoRH").ToString = "1" Then
                        swAprobadoRH.CheckState = CheckState.Checked
                        swAprobadoRH.Text = "Aprobado"
                    Else
                        swAprobadoRH.CheckState = CheckState.Unchecked
                        swAprobadoRH.Text = "Rechazado"
                    End If
                End If
                txtTurnoDeseado.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("TurnoPreferencia")), "", dtRegistro.Rows(0).Item("TurnoPreferencia"))
                cmbTurnoFinal.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("Turno")), "", dtRegistro.Rows(0).Item("Turno"))

                dtTemp = sqlExecute("select Parentezco as parentezco, Nombre as primerNombre, SegundoNombre as segundoNombre, Paterno as apellidoPaterno, Materno as apellidoMaterno, FhaNacimiento as fechaNacimiento from reclutamiento.dbo.Dependientes where Folio = '" & dtRegistro.Rows(0).Item("Folio").ToString.Trim & "'")
                dgDependientes.DataSource = dtTemp
                If IsDBNull(dtRegistro.Rows(0).Item("Nivel")) Then
                    cmbNivel.SelectedIndex = 0
                ElseIf dtRegistro.Rows(0).Item("Nivel").ToString.Trim.Length = 0 Then
                    cmbNivel.SelectedIndex = 0
                Else
                    If cmbNivel.Items.Count > 0 Then
                        cmbNivel.SelectedValue = Trim(dtRegistro.Rows(0).Item("Nivel"))
                    End If
                End If
                txtEmailPersonal.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("EmailPersonal")), "", dtRegistro.Rows(0).Item("EmailPersonal"))
                txtEmailBusiness.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("EmailBusiness")), "", dtRegistro.Rows(0).Item("EmailBusiness"))
                txtEmailOtro.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("EmailOtro")), "", dtRegistro.Rows(0).Item("EmailOtro"))
                lblRelojPIDA.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("RelojPida")), "", dtRegistro.Rows(0).Item("RelojPida"))
                lblRelojSF.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("RelojSF")), "", dtRegistro.Rows(0).Item("RelojSF"))
                'lblIMSS.Text = ""
                If IsDBNull(dtRegistro.Rows(0).Item("Layout")) Then
                    lblExportado.Visible = False
                    lblExpReloj.Visible = False
                    lblExpReloj.Text = ""
                Else
                    If dtRegistro.Rows(0).Item("Layout").ToString.Trim.Length > 0 Then
                        lblExportado.Visible = False
                        lblExpReloj.Visible = False
                        lblExpReloj.Text = ""
                        If dtRegistro.Rows(0).Item("Layout").ToString.Trim = "1" Then
                            lblExpReloj.Text = IIf(IsDBNull(dtRegistro.Rows(0).Item("RelojSF")), "", dtRegistro.Rows(0).Item("RelojSF"))
                            lblExportado.Visible = True
                            lblExpReloj.Visible = True
                        End If
                        If dtRegistro.Rows(0).Item("Layout").ToString.Trim = "0" Then
                            lblExportado.Visible = False
                            lblExpReloj.Visible = False
                            lblExpReloj.Text = ""
                        End If
                    Else
                        lblExportado.Visible = False
                        lblExpReloj.Visible = False
                        lblExpReloj.Text = ""
                    End If
                End If
                esReingreso = IIf(IsDBNull(dtRegistro.Rows(0).Item("Reingreso")), False, dtRegistro.Rows(0).Item("Reingreso"))
                If esReingreso Then
                    Dim dtReingreso As DataTable = sqlExecute("select reloj, nombre, apaterno, amaterno, imss, dig_ver, rfc, curp from personal.dbo.personal where cod_comp = 'WME' and imss = '" & txtIMSS.Text & "' and dig_ver = '" & txtIMSSdv.Text & "'")
                    If dtReingreso.Rows.Count > 0 Then
                        lblIMSS.Visible = True
                        'lblIMSS.Text = "REINGRESO  IMSS: " & dtReingreso.Rows(0).Item("imss").ToString.Trim & dtReingreso.Rows(0).Item("dig_ver").ToString.Trim & _
                        '"    Nombre:  " & dtReingreso.Rows(0).Item("nombre").ToString.Trim & " " & dtReingreso.Rows(0).Item("apaterno").ToString.Trim & " " & dtReingreso.Rows(0).Item("amaterno").ToString.Trim & _
                        '"    Reloj:  " & dtReingreso.Rows(0).Item("reloj").ToString.Trim
                    End If
                Else
                    lblIMSS.Visible = False
                    'lblIMSS.Text = ""
                End If
                Dim dtNiveles As DataTable = sqlExecute("select PayScaleGroup from personal.dbo.niveles where cod_comp = '090' and nivel = '" & dtRegistro.Rows(0).Item("Nivel") & "' and len(rtrim(nombre)) > 0")
                If dtNiveles.Rows.Count > 0 Then
                    txtPayScaleGroup.Text = dtNiveles.Rows(0).Item("PayScaleGroup").ToString.Trim
                End If
                'deshabilitar comentarios medicos para determinados perfiles
                Dim dtPerfil = sqlExecute("SELECT cod_perfil FROM appuser WHERE username = '" & Usuario & "'", "seguridad")
                If dtPerfil.Rows.Count > 0 Then
                    Select Case dtPerfil.Rows(0).Item("cod_perfil").ToString.Trim
                        Case "RHTHRLYR"
                            txtComentariosMedico.Visible = False
                            Label24.Visible = False
                    End Select
                End If
                clkCronometro.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("DuracionRH")), "00:00:00", dtRegistro.Rows(0).Item("DuracionRH").ToString)
                clkCronometro.Update()
            Else
                txtFolio.Text = ""
                cmbVacante.SelectedIndex = -1
                cmbFechaAplica.Value = Nothing
                txtNombre.Text = ""
                txtPaterno.Text = ""
                txtMaterno.Text = ""
                swGenero.SetValue(True, DevComponents.DotNetBar.eEventSource.Code)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

        'HabilitarBotones()

    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("Candidatos", "Folio", RTrim(txtFolio.Text), dtRegistro, "Reclutamiento")
        HabilitarBotones()
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("Candidatos", "Folio", RTrim(txtFolio.Text), dtRegistro, "Reclutamiento")
        HabilitarBotones()
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("Candidatos", "Folio", dtRegistro, "Reclutamiento")
        HabilitarBotones()
        MostrarInformacion()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dtTemp = dtRegistro
        Try
            frmBuscarFolio.ShowDialog(Me)
            If Folio <> "CANCEL" Then
                dtRegistro = sqlExecute("SELECT top 1 * FROM Candidatos WHERE folio ='" & Folio & "'", "RECLUTAMIENTO")
                If dtRegistro.Rows.Count > 0 Then
                    HabilitarBotones()
                    MostrarInformacion()
                Else
                    MessageBox.Show("El solicitante con folio " & Folio & " no fue localizado.", "Solicitante no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtRegistro = dtTemp
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim strQry As String = ""
        Dim mensaje As String = ""
        Dim intApto As Integer = 0
        Dim horario As String = ""
        Try
            If Editar Then
                If lblExpReloj.Text.Length > 0 And lblExpReloj.Text <> lblRelojSF.Text Then
                    Dim result As Integer = MessageBox.Show("Esta seguro de cambiar el numero de reloj?", "El reloj es diferente", MessageBoxButtons.OKCancel)
                    If result = DialogResult.Cancel Then
                        Exit Sub
                    ElseIf result = DialogResult.OK Then

                    End If
                End If
                If swAprobadoRH.CheckValue = "NULL" Or swAprobadoRH.CheckValue = "0" Then
                    banderaError = False
                Else
                    ValidaControles()
                End If
                Cancelar = False
                ' Si Editar, entonces guardar cambios a registro
                mensaje = "Editar"
                'ValidarCaptura()
                If banderaError Then
                    Exit Sub
                End If
                strQry = "select cod_hora from personal.dbo.horarios where cod_hora = '" & cmbHorario.SelectedValue & "' and cod_comp = 'WME'"
                dtTemp = sqlExecute(strQry, "Personal")
                If dtTemp.Rows.Count > 0 Then
                    horario = dtTemp.Rows(0).Item("cod_hora").ToString.Trim
                End If
                Timer1.Stop()
                strQry = "UPDATE Candidatos SET Cod_Vac='" & cmbVacante.SelectedValue & "', RelojPida='" & IIf(lblRelojPIDA.Text.Trim.Length = 0, "", lblRelojPIDA.Text.Trim) & "', RelojSF='" & IIf(lblRelojSF.Text.Trim.Length = 0, "", lblRelojSF.Text.Trim) & "'," & _
                          "salutation='" & cmbTitulo.Text.Trim & "',FhaApli='" & FechaSQL(cmbFechaAplica.Value) & "',Medio = '" & cmbMedio.Text.Trim & "', " & _
                          "Nombre ='" & txtNombre.Text.ToLower.ToTitleCase.Trim & "',SegundoNombre='" & txtSegundoNombre.Text.ToLower.ToTitleCase.Trim & "',Paterno ='" & txtPaterno.Text.ToLower.ToTitleCase.Trim & "',Materno ='" & txtMaterno.Text.ToLower.ToTitleCase.Trim & "', " & _
                          "Genero ='" & IIf(swGenero.Value, "M", "F") & "', Nacionalidad = '" & txtNacionalidad.Text.Trim & "', FhaNac='" & FechaSQL(cmbFechaNac.Value) & "',Cod_civil ='" & cmbCivil.SelectedValue & "',Numero_Hijos ='" & intNumeroHijos.Text & "', " & _
                          "TallaZapato = '" & cmbTallaZapato.Text.Trim & "',TallaPantalon = '" & cmbTallaPantalon.Text.Trim & "',TallaPlayera = '" & cmbTallaPlayera.Text.Trim & "', imss = '" & txtIMSS.Text.Trim & "',DIG_VER='" & txtIMSSdv.Text.Trim & "',RFC ='" & txtRFC.Text.Trim & "',CURP ='" & txtCurp.Text.Trim & "', " & _
                          "Direccion ='" & txtDireccion.Text.Trim & "',Departamento='" & txtDepartamento.Text.Trim & "',Ciudad ='" & cmbCiudad.SelectedValue & "',cod_col ='" & IIf(IsNothing(cmbColonia.SelectedValue), "", cmbColonia.SelectedValue) & "',Colonia ='" & cmbColonia.Text.Split(",")(1).Trim & "', Municipio ='" & cmbMunicipio.SelectedValue & "',  " & _
                          "CP ='" & txtCP.Text.Trim & "',Telefono1='" & txtTelefono1.Text.Trim & "',Telefono2='" & txtTelefono2.Text.Trim & "',Telefono3='" & txtTelefono3.Text.Trim & "',Telefono4='" & txtTelefono4.Text.Trim & "',Telefono5='" & txtTelefono5.Text.Trim & "',Cod_Est='" & cmbEstado.SelectedValue & "',Cod_Pais_Nac ='" & cmbPaisNac.SelectedValue & "',lugar_nac ='" & txtLugarNacimiento.Text.Trim & "', " & _
                          "EmailPersonal = '" & txtEmailPersonal.Text.Trim & "',EmailBusiness = '" & txtEmailBusiness.Text.Trim & "',EmailOtro = '" & txtEmailOtro.Text.Trim & "'," & _
                          "Cod_Est_Nac ='" & cmbEstadoNac.SelectedValue & "',EdoNac ='" & cmbEstadoNac.Text.ToString.Trim & "',UltimoGrado='" & cmbGrado.SelectedValue & "',OtroGrado='" & txtOtroGrado.Text.Trim & "',NomEmpUltTrab ='" & txtNomEmp1.Text.Trim & "', " & _
                          "AnoIngresoUltTrab ='" & txtIngreso1.Text.Trim & "',AnoBajaUltimoTrab='" & txtBaja1.Text.Trim & "',PuestoUltTrab ='" & txtPuesto1.Text.Trim & "',SueldoMenUltTrab ='" & txtSueldo1.Text.Trim & "', " & _
                          "ActUltTrab ='" & txtActividades1.Text.Trim & "',NomEmpPenTrab='" & txtNomEmp2.Text.Trim & "',AnoIngresoPenTrab ='" & txtIngreso2.Text.Trim & "',AnoBajaPenTrab ='" & txtBaja2.Text.Trim & "', " & _
                          "PuestoPenTrab ='" & txtPuesto2.Text.Trim & "',SueldoMenPenTrab='" & txtSueldo2.Text.Trim & "',ActPenTrab ='" & txtActividades2.Text.Trim & "',NomEmpAntTrab ='" & txtNomEmp3.Text.Trim & "', " & _
                          "AnoIngresoAntTrab='" & txtIngreso3.Text.Trim & "',AnoBajaAntTrab ='" & txtBaja3.Text.Trim & "',PuestoAntTrab ='" & txtPuesto3.Text.Trim & "', " & _
                          "SueldoMenAntTrab ='" & txtSueldo3.Text.Trim & "',ActAntTrab='" & txtActividades3.Text.Trim & "', " & _
                          "pertenecioASindicato='" & cbSindicato.Checked & "',AceptaPoliPriva='" & Cbpoliticas.Checked & "', AprobadoRH = " & IIf(swAprobadoRH.CheckValue = "NULL", "NULL", IIf(swAprobadoRH.CheckValue = "1", "'1'", "'0'")) & ", " & _
                          "Agencia ='" & cmbAgencia.Text.Trim & "', Ruta ='" & cmbRuta.Text.Trim & "',RecomendadoPor='" & txtRecomendadoPor.Text.Trim & "',TipoEmpleado='" & txtTipoEmpleado.Text.Substring(0, 3) & "',ClaseEmpleado='" & IIf(IsNothing(cmbClaseEmpleado.SelectedValue), "", cmbClaseEmpleado.SelectedValue) & "', ClaseEmpleadoNombre='" & cmbClaseEmpleado.Text.ToString.Trim & "', " & _
                          "HorasSemanales = " & IIf(txtHorasSemanales.Text.Trim.Length = 0, "0", txtHorasSemanales.Text.Trim) & ", DiasSemana = " & IIf(txtDiasSemana.Text.Trim.Length = 0, "0", txtDiasSemana.Text.Trim) & ",PayScaleGroup='" & txtPayScaleGroup.Text.Trim & "',Horario='" & IIf(IsNothing(cmbHorario.SelectedValue), "", cmbHorario.SelectedValue) & "',Horario_cod='" & IIf(IsNothing(horario), "", horario) & "', " & _
                          "Position='" & IIf(IsNothing(cmbPosicion.SelectedValue), "", cmbPosicion.SelectedValue) & "',EmployeeTypeFortia='" & cmbEmloyeeTypeFortia.Text & "',FechaAlta='" & FechaSQL(cmbFechaAlta.Value) & "',FechaVacaciones='" & FechaSQL(cmbFechaVac.Value) & "', FechaAntiguedad='" & FechaSQL(cmbFechaAnt.Value) & "',SueldoDiario ='" & txtSueldoDiario.Text.Trim & "', " & _
                          "ComentariosRH = '" & txtComentariosRH.Text.Trim & "', Turno ='" & cmbTurnoFinal.Text.Trim & "', Nivel = '" & cmbNivel.SelectedValue & "', Reingreso = '" & IIf(esReingreso, "1", "0") & "', " & _
                          "Captura = getdate(),Usuario = '" & Usuario & "', DuracionRH = '" & clkCronometro.Value.TimeOfDay.ToString & "' where Folio = '" & txtFolio.Text.Trim & "' "
                dtTemp = sqlExecute(strQry, "Reclutamiento")
                If dtTemp.Columns.Count = 1 Then
                    MsgBox("Error al intentar actualizar el registro. Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                Else
                    MsgBox("La información del solicitante fue actualizada satisfactoriamente. " & Environment.NewLine & Environment.NewLine & "Favor de verificar la aprobacion del candidato.", MsgBoxStyle.Information, "Información")
                    Editar = False
                End If
                strQry = "delete from Dependientes where Folio = '" & txtFolio.Text.Trim & "'"
                dtLocal = sqlExecute(strQry, "Reclutamiento")
                For Each row As DataGridViewRow In dgDependientes.Rows
                    If Not row.IsNewRow Then
                        If row.Cells("primerNombre").Value.ToString.Trim.Length > 0 And row.Cells("apellidoPaterno").Value.ToString.Trim.Length > 0 And row.Cells("parentezco").Value.ToString.Trim.Length > 0 And row.Cells("fechaNacimiento").Value.ToString.Trim.Length > 0 Then
                            strQry = "INSERT into Dependientes (Folio, Nombre, SegundoNombre, Paterno, Materno, Parentezco, FhaNacimiento) "
                            strQry = strQry & "VALUES ('" & txtFolio.Text.Trim & "','" & row.Cells("primerNombre").Value.ToString.Trim & "','" & row.Cells("segundoNombre").Value.ToString.Trim & "', "
                            strQry = strQry & "'" & row.Cells("apellidoPaterno").Value.ToString.Trim & "','" & row.Cells("apellidoMaterno").Value.ToString.Trim & "', "
                            strQry = strQry & "'" & row.Cells("parentezco").Value.ToString.Trim & "','" & FechaSQL(row.Cells("fechaNacimiento").Value.ToString.Trim) & "')"
                            dtLocal = sqlExecute(strQry, "Reclutamiento")
                        Else
                            MsgBox("Error al guardar la información del dependiente", MsgBoxStyle.Critical, "Error")
                        End If
                    End If
                Next
                strQry = "update posiciones set status = 1 " & _
                         "   where cod_posicion in ( " & _
                         "   select cod_posicion " & _
                         "   from posiciones " & _
                         "   where cod_posicion not in (select case when isnumeric(Position)=1 then convert(int,Position) else 0 end from Candidatos where Cod_Vac = '" & cmbVacante.SelectedValue & "') " & _
                         "         and cod_vacante = '" & cmbVacante.SelectedValue & "'" & _
                         ")"
                dtLocal = sqlExecute(strQry, "Reclutamiento")
                If Not cmbPosicion.SelectedValue Is Nothing Then
                    strQry = "update posiciones set status = 0 where cod_posicion = " & cmbPosicion.SelectedValue
                    dtLocal = sqlExecute(strQry, "Reclutamiento")
                End If
                dtRegistro = sqlExecute("SELECT top 1 * FROM Candidatos WHERE folio ='" & txtFolio.Text.Trim & "'", "RECLUTAMIENTO")
            Else
                Editar = True
                clkCronometro.Value = "00:00:00"
                Timer1.Start()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MsgBox("Error al " & mensaje & " registro. Si el problema persiste contacte al administrador", MsgBoxStyle.Critical, "Error")
            banderaError = True
        End Try
        'If banderaError Then
        '    Exit Sub
        'End If
        'Editar = False
        HabilitarBotones()

        MostrarInformacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Cancelar = True
        Editar = False
        If btnCerrar.Text.ToUpper = "SALIR" Then
            Me.Close()
        End If
        If btnCerrar.Text.ToUpper = "CANCELAR" Then
            'clkCronometro.Value = "00:00:00"
            Timer1.Stop()
        End If
        HabilitarBotones()
    End Sub

    Private Sub txtSueldo1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSueldo1.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtSueldo2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSueldo2.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtSueldo3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSueldo3.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtIngreso1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIngreso1.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtBaja1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBaja1.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtIngreso2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIngreso2.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtBaja2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBaja2.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtIngreso3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIngreso3.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtBaja3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBaja3.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbFechaAlta_TextChanged(sender As Object, e As EventArgs) Handles cmbFechaAlta.TextChanged
        cmbFechaAnt.Value = cmbFechaAlta.Value
    End Sub

    Private Sub cmbFechaAnt_TextChanged(sender As Object, e As EventArgs) Handles cmbFechaAnt.TextChanged
        cmbFechaVac.Value = cmbFechaAnt.Value
    End Sub

    Private Sub dgDependientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDependientes.CellClick
        'if click is on new row or header row
        If e.RowIndex = dgDependientes.NewRowIndex Or e.RowIndex < 0 Then
            Exit Sub
        End If

        'Check if click is on specific column 
        If e.ColumnIndex = dgDependientes.Columns("deleteColumn").Index Then
            dgDependientes.Rows.Remove(dgDependientes.CurrentRow)
        End If
    End Sub

    Private Sub txtCurp_TextChanged(sender As Object, e As EventArgs) Handles txtCurp.TextChanged
        If txtCurp.Text.Trim.Length > 0 Then
            If txtCurp.Text.Trim.Length > 10 Then
                If txtCurp.Text.Substring(10, 1).Equals("M") Then
                    swGenero.Value = False
                Else
                    swGenero.Value = True
                End If
            End If
        End If
    End Sub

    Public Overloads Sub Show(ByVal Folio As String)
        MyBase.Show()
        dtRegistro = sqlExecute("SELECT top 1 * FROM Candidatos WHERE folio ='" & Folio & "'", "RECLUTAMIENTO")
        If dtRegistro.Rows.Count > 0 Then
            MostrarInformacion()
        Else
            MessageBox.Show("El solicitante con folio " & Folio & " no fue localizado.", "Solicitante no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub cmbFechaAnt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbFechaAnt.Validating
        If DateTime.Compare(cmbFechaAnt.Value, cmbFechaAlta.Value) = 1 Then
            cmbFechaAnt.Value = cmbFechaAlta.Value
            MessageBox.Show("La fecha de antiguedad no puede ser mayor que la fecha de alta.", "Fecha no valida", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub ValidaControles()
        Try
            If txtFolio.Text.Trim = "" Or txtFolio.Text.Trim = "00000" Then
                banderaError = True
                MsgBox("El folio no es válido", MsgBoxStyle.Exclamation, "AVISO")
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbVacante.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione una vacante", MsgBoxStyle.Exclamation, "AVISO")
                cmbVacante.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbFechaAplica.Value = Nothing Then
                banderaError = True
                MsgBox("Seleccione una fecha de aplicación", MsgBoxStyle.Exclamation, "AVISO")
                cmbFechaAplica.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            'If cmbTitulo.SelectedIndex = -1 Then
            '    banderaError = True
            '    MsgBox("Seleccione el titulo del candidato", MsgBoxStyle.Exclamation, "AVISO")
            '    cmbTitulo.Focus()
            '    Exit Sub
            'Else
            '    banderaError = False
            'End If

            If txtNombre.Text.Trim = "" Then
                banderaError = True
                MsgBox("Escriba el nombre del candidato", MsgBoxStyle.Exclamation, "AVISO")
                txtNombre.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If txtPaterno.Text.Trim = "" And txtMaterno.Text.Trim = "" Then
                banderaError = True
                MsgBox("Escriba un apellido del candidato", MsgBoxStyle.Exclamation, "AVISO")
                txtPaterno.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            'Validar IMSS
            If txtIMSSdv.Text.Trim <> DigitoVerificador(txtIMSS.Text.Trim) Then
                banderaError = True
                MessageBox.Show("El número de IMSS no es válido. Favor de verificar que sean 11 dígitos y/o último dígito sea correcto.", "IMSS inválido", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtIMSS.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            ''Validar si el IMSS no se ha usado antes
            'dtTemp = sqlExecute("SELECT reloj from personalvw WHERE (imss + dig_ver) = '" & txtIMSS.Text & txtIMSSdv.Text & "'")
            'If dtTemp.Rows.Count > 0 And txtIMSS.Text & txtIMSSdv.Text > "" Then
            '    banderaError = True
            '    MessageBox.Show("El número de IMSS " & txtIMSS.Text & txtIMSSdv.Text & " ya se encuentra asignado al número de reloj " & dtTemp.Rows(0).Item("reloj"), "IMSS duplicado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    txtIMSS.Focus()
            '    Exit Sub
            'Else
            '    banderaError = False
            'End If

            'Validar RFC
            If Not ValidaRFC(txtRFC.Text.Trim) Then
                banderaError = True
                MessageBox.Show("El RFC no es válido. Favor de verificar.", "RFC inválido", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtRFC.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            ''Validar si el RFC no se ha usado antes
            'dtTemp = sqlExecute("SELECT reloj from personalvw WHERE RFC = '" & txtRFC.Text.Trim & "'")
            'If dtTemp.Rows.Count > 0 Then
            '    banderaError = True
            '    MessageBox.Show("El RFC " & txtRFC.Text.Trim & " ya se encuentra asignado al número de reloj " & dtTemp.Rows(0).Item("reloj"), "RFC duplicado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    txtRFC.Focus()
            '    Exit Sub
            'Else
            '    banderaError = False
            'End If

            'Validar CURP
            If Not ValidaCURP(txtCurp.Text.Trim) Then
                banderaError = True
                MessageBox.Show("La CURP no es válida. Favor de verificar.", "CURP inválida", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtCurp.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If txtNacionalidad.Text.Trim = "" Then
                banderaError = True
                MsgBox("Escriba la nacionalidad del candidato", MsgBoxStyle.Exclamation, "AVISO")
                txtNacionalidad.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbCivil.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione el estado civil del candidato", MsgBoxStyle.Exclamation, "AVISO")
                cmbCivil.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If txtDireccion.Text.Trim = "" Then
                banderaError = True
                MsgBox("Ingrese la dirección del candidato", MsgBoxStyle.Exclamation, "AVISO")
                txtDireccion.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbCiudad.SelectedValue = "" Then
                banderaError = True
                MsgBox("Ingrese la ciudad del candidato", MsgBoxStyle.Exclamation, "AVISO")
                cmbCiudad.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            'If cmbColonia2.Text.Trim = "" Then
            '    banderaError = True
            '    MsgBox("Ingrese la colonia del candidato", MsgBoxStyle.Exclamation, "AVISO")
            '    cmbColonia2.Focus()
            '    Exit Sub
            'Else
            '    banderaError = False
            'End If

            If txtCP.Text.Trim = "" Then
                banderaError = True
                MsgBox("Ingrese el Codigo Postal del candidato", MsgBoxStyle.Exclamation, "AVISO")
                txtCP.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbEstado.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione un estado", MsgBoxStyle.Exclamation, "AVISO")
                cmbEstado.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            'If cmbMunicipio.SelectedIndex = -1 Then
            '    banderaError = True
            '    MsgBox("Seleccione un municipio", MsgBoxStyle.Exclamation, "AVISO")
            '    cmbMunicipio.Focus()
            '    Exit Sub
            'Else
            '    banderaError = False
            'End If

            For Each row As DataGridViewRow In dgDependientes.Rows
                If Not row.IsNewRow Then
                    If IsNothing(row.Cells("primerNombre").Value) Then
                        banderaError = True
                        MsgBox("Ingrese el primer nombre del dependiente", MsgBoxStyle.Exclamation, "AVISO")
                        Exit Sub
                    Else
                        If row.Cells("primerNombre").Value.ToString.Trim.Length = 0 Then
                            banderaError = True
                            MsgBox("Ingrese el primer nombre del dependiente", MsgBoxStyle.Exclamation, "AVISO")
                        Else
                            banderaError = False
                        End If
                    End If
                    If IsNothing(row.Cells("apellidoPaterno").Value) Then
                        banderaError = True
                        MsgBox("Ingrese el apellido paterno del dependiente", MsgBoxStyle.Exclamation, "AVISO")
                        Exit Sub
                    Else
                        If row.Cells("apellidoPaterno").Value.ToString.Trim.Length = 0 Then
                            banderaError = True
                            MsgBox("Ingrese el apellido paterno del dependiente", MsgBoxStyle.Exclamation, "AVISO")
                        Else
                            banderaError = False
                        End If
                    End If
                    If IsNothing(row.Cells("parentezco").Value) Then
                        banderaError = True
                        MsgBox("Ingrese el parentezco del dependiente", MsgBoxStyle.Exclamation, "AVISO")
                        Exit Sub
                    Else
                        If row.Cells("parentezco").Value.ToString.Trim.Length = 0 Then
                            banderaError = True
                            MsgBox("Ingrese el parentezco del dependiente", MsgBoxStyle.Exclamation, "AVISO")
                        Else
                            banderaError = False
                        End If
                    End If
                    If IsNothing(row.Cells("fechaNacimiento").Value) Then
                        banderaError = True
                        MsgBox("Seleccione la fecha de nacimiento del dependiente", MsgBoxStyle.Exclamation, "AVISO")
                        Exit Sub
                    Else
                        If row.Cells("fechaNacimiento").Value.ToString.Trim.Length = 0 Then
                            banderaError = True
                            MsgBox("Seleccione la fecha de nacimiento del dependiente", MsgBoxStyle.Exclamation, "AVISO")
                        Else
                            banderaError = False
                        End If
                    End If
                End If
            Next

            If txtLugarNacimiento.Text.Trim = "" Then
                banderaError = True
                MsgBox("Ingrese el lugar de nacimiento del candidato", MsgBoxStyle.Exclamation, "AVISO")
                txtLugarNacimiento.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            'If txtEmailPersonal.Text.Trim.Length <= 0 Then
            '    banderaError = True
            '    MsgBox("Ingrese un correo personal", MsgBoxStyle.Exclamation, "AVISO")
            '    txtEmailPersonal.Focus()
            '    Exit Sub
            'Else
            '    banderaError = False
            'End If

            If cmbFechaNac.Value = Nothing Then
                banderaError = True
                MsgBox("Ingrese la fecha de nacimiento del candidato", MsgBoxStyle.Exclamation, "AVISO")
                cmbFechaNac.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbPaisNac.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione un pais de nacimiento", MsgBoxStyle.Exclamation, "AVISO")
                cmbPaisNac.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbEstadoNac.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione un estado de nacimiento", MsgBoxStyle.Exclamation, "AVISO")
                cmbEstadoNac.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbGrado.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione un grado de estudios", MsgBoxStyle.Exclamation, "AVISO")
                cmbGrado.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If Not Cbpoliticas.Checked Then
                banderaError = True
                MsgBox("Haga click para aceptar las politicas de privacidad", MsgBoxStyle.Exclamation, "AVISO")
                Cbpoliticas.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            'If cmbTipoEmpleado.SelectedIndex = -1 Then
            '    banderaError = True
            '    MsgBox("Seleccione un Tipo de Empleado", MsgBoxStyle.Exclamation, "AVISO")
            '    cmbTipoEmpleado.Focus()
            '    Exit Sub
            'Else
            '    banderaError = False
            'End If

            If txtTipoEmpleado.Text.Length <= 0 Then
                banderaError = True
                MsgBox("Escriba un Tipo de Empleado", MsgBoxStyle.Exclamation, "AVISO")
                txtTipoEmpleado.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbClaseEmpleado.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione una Clase de Empleado", MsgBoxStyle.Exclamation, "AVISO")
                cmbClaseEmpleado.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If txtHorasSemanales.Text.Trim.Length <= 0 Then
                banderaError = True
                'MsgBox("Ingrese el numero de horas semanales", MsgBoxStyle.Exclamation, "AVISO")
                MsgBox("Seleccione horario válido", MsgBoxStyle.Exclamation, "AVISO")
                txtHorasSemanales.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If txtPayScaleGroup.Text.Trim.Length <= 0 Then
                banderaError = True
                MsgBox("Escriba un Pay Scale Group", MsgBoxStyle.Exclamation, "AVISO")
                txtPayScaleGroup.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbHorario.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione un Horario", MsgBoxStyle.Exclamation, "AVISO")
                cmbHorario.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbPosicion.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione un valor para Position", MsgBoxStyle.Exclamation, "AVISO")
                cmbPosicion.Focus()
                Exit Sub
            Else
                If Not IsNumeric(cmbPosicion.Text.Trim) Or cmbPosicion.Text.Trim.Length > 8 Then
                    banderaError = True
                    MsgBox("Position debe ser numerica y no mayor de 8 digitos", MsgBoxStyle.Exclamation, "AVISO")
                    cmbPosicion.Focus()
                    Exit Sub
                Else
                    banderaError = False
                End If
            End If

            If cmbEmloyeeTypeFortia.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione un Employee Type (Fortia)", MsgBoxStyle.Exclamation, "AVISO")
                cmbEmloyeeTypeFortia.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If cmbFechaAlta.Value = Nothing Then
                banderaError = True
                MsgBox("Ingrese la fecha de Alta", MsgBoxStyle.Exclamation, "AVISO")
                cmbFechaAlta.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            Try
                If txtSueldoDiario.Text.Trim <= 0 Then
                    banderaError = True
                    MsgBox("Ingrese el Sueldo Diario", MsgBoxStyle.Exclamation, "AVISO")
                    txtSueldoDiario.Focus()
                    Exit Sub
                Else
                    banderaError = False
                End If
            Catch
                banderaError = True
                MsgBox("Ingrese el Sueldo Diario", MsgBoxStyle.Exclamation, "AVISO")
                txtSueldoDiario.Focus()
                Exit Sub
            End Try

            If cmbTurnoFinal.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione un Turno", MsgBoxStyle.Exclamation, "AVISO")
                cmbTurnoFinal.Focus()
                Exit Sub
            Else
                banderaError = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbMunicipio_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbMunicipio.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("reclutamiento.dbo.municipios", "cod_mun", "municipio", False)
        If Cod <> "CANCELAR" Then
            cmbMunicipio.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbNivel_TextChanged(sender As Object, e As EventArgs) Handles cmbNivel.TextChanged
        Dim strNivelSelValue = ""
        strNivelSelValue = cmbNivel.SelectedValue.ToString
        If strNivelSelValue = "System.Data.DataRowView" Then
            strNivelSelValue = cmbNivel.SelectedValue.row(0).ToString
        End If
        Dim dtNiveles As DataTable = sqlExecute("select * from personal.dbo.niveles where cod_comp = 'WME' and nivel = '" & strNivelSelValue & "' and len(rtrim(nombre)) > 0")
        If dtNiveles.Rows.Count > 0 Then
            txtPayScaleGroup.Text = dtNiveles.Rows(0).Item("PayScaleGroup").ToString.Trim
            If Not IsDBNull(dtNiveles.Rows(0).Item("sueldo")) Then
                If dtNiveles.Rows(0).Item("sueldo") = "0" Then
                    txtSueldoDiario.Text = ""
                    txtSueldoDiario.ReadOnly = False
                Else
                    txtSueldoDiario.Text = dtNiveles.Rows(0).Item("sueldo").ToString.Trim
                    txtSueldoDiario.ReadOnly = True
                End If
            Else
                txtSueldoDiario.Text = ""
                txtSueldoDiario.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub txtSueldoDiario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSueldoDiario.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtHorasSemanales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHorasSemanales.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtIMSSdv_Leave(sender As Object, e As EventArgs) Handles txtIMSSdv.Leave
        Dim dtReingreso As DataTable = sqlExecute("select reloj, nombre, apaterno, amaterno, imss, dig_ver, rfc, curp from personal.dbo.personal where cod_comp = 'WME' and imss = '" & txtIMSS.Text & "' and dig_ver = '" & txtIMSSdv.Text & "'")
        If dtReingreso.Rows.Count > 0 Then
            lblIMSS.Visible = True
            'lblIMSS.Text = "REINGRESO  IMSS: " & dtReingreso.Rows(0).Item("imss").ToString.Trim & dtReingreso.Rows(0).Item("dig_ver").ToString.Trim & _
            '            "    Nombre:  " & dtReingreso.Rows(0).Item("nombre").ToString.Trim & " " & dtReingreso.Rows(0).Item("apaterno").ToString.Trim & " " & dtReingreso.Rows(0).Item("amaterno").ToString.Trim & _
            '            "    Reloj:  " & dtReingreso.Rows(0).Item("reloj").ToString.Trim
            txtRFC.Text = dtReingreso.Rows(0).Item("rfc").ToString.Trim
            txtRFC.ForeColor = Color.Blue
            txtCurp.Text = dtReingreso.Rows(0).Item("curp").ToString.Trim
            txtCurp.ForeColor = Color.Blue
            lblRelojPIDA.Text = dtReingreso.Rows(0).Item("reloj").ToString.Trim
            Dim dtSuccessFactors As DataTable = sqlExecute("select top 1 sf_id from personal.dbo.SF_HIRINGS where reloj = '" & dtReingreso.Rows(0).Item("reloj").ToString.Trim & "'")
            If dtSuccessFactors.Rows.Count > 0 Then
                lblRelojSF.Text = dtSuccessFactors.Rows(0).Item("sf_id").ToString.Trim
            Else
                lblRelojSF.Text = ""
            End If
            txtNombre.Text = Split(dtReingreso.Rows(0).Item("nombre").ToString.Trim, " ")(0)
            txtSegundoNombre.Text = dtReingreso.Rows(0).Item("nombre").ToString.Trim.Replace(txtNombre.Text, "")
            txtPaterno.Text = dtReingreso.Rows(0).Item("apaterno").ToString.Trim
            txtMaterno.Text = dtReingreso.Rows(0).Item("amaterno").ToString.Trim
            esReingreso = True
        Else
            'lblIMSS.Text = ""
            lblIMSS.Visible = False
            'txtRFC.Text = ""
            txtRFC.ForeColor = Color.Black
            'txtCurp.Text = ""
            txtCurp.ForeColor = Color.Black
            'lblRelojPIDA.Text = ""
            'lblRelojSF.Text = ""
            esReingreso = False
        End If
    End Sub

    Private Sub cmbHorario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHorario.SelectedIndexChanged
        Try
            Dim dtHorasDias As DataTable = sqlExecute("select avg_hrs, avg_days from personal.dbo.horarios where cod_hora = '" & cmbHorario.SelectedValue.ToString & "'")
            If dtHorasDias.Rows.Count > 0 Then
                txtHorasSemanales.Text = dtHorasDias.Rows(0).Item("avg_hrs").ToString.Trim
                txtDiasSemana.Text = dtHorasDias.Rows(0).Item("avg_days").ToString.Trim
            End If
        Catch
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        clkCronometro.Value = clkCronometro.Value.AddSeconds(1)
        clkCronometro.Update()
    End Sub

    Private Sub txtTelefono1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono1.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = " " Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtTelefono2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono2.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = " " Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtTelefono3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono3.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = " " Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtTelefono4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono4.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = " " Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtTelefono5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono5.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = " " Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbColonia_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbColonia.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("colonias", "cod_col", "colonias", False)
        If Cod <> "CANCELAR" Then
            'Dim dtCol As DataTable = sqlExecute("SELECT * from colonias WHERE cod_col = '" & Cod & "'")            
            cmbColonia.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbColonia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColonia.SelectedIndexChanged
        Dim cl As String
        Try
            cl = cmbColonia.SelectedValue
            Dim dtcp As DataTable = sqlExecute("select * from colonias where cod_col = '" & cl & "'")
            If dtcp.Rows.Count > 0 Then
                txtCP.Text = dtcp.Rows(0)("cp")
            Else
                txtCP.Text = "N/A"
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtCP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCP.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnVerColonias_Click(sender As Object, e As EventArgs) Handles btnVerColonias.Click
        Try
            Dim c As String = cmbColonia.SelectedValue
            frmColonias.ShowDialog(Me)
            dtColonia = sqlExecute("SELECT cod_col,nombre FROM colonias")
            cmbColonia.DataSource = dtColonia
            If Not c = Nothing Then cmbColonia.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmColonias.Focus()
        End Try
    End Sub

    Private Sub cmbCiudad_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbCiudad.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("ciudad", "cod_cd", "ciudad", False)
        If Cod <> "CANCELAR" Then
            cmbCiudad.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbEstadoNac_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbEstadoNac.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("reclutamiento.dbo.estados", "cod_edo", "estado", False)
        If Cod <> "CANCELAR" Then
            cmbEstado.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbEstado_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbEstado.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("reclutamiento.dbo.estados", "cod_edo", "estado", False)
        If Cod <> "CANCELAR" Then
            cmbEstado.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbPaisNac_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbPaisNac.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("reclutamiento.dbo.CountryISO", "code", "pais", False)
        If Cod <> "CANCELAR" Then
            cmbPaisNac.SelectedValue = Cod
        End If
    End Sub

    Private Sub swAprobadoRH2_CheckedChanged(sender As Object, e As EventArgs) Handles swAprobadoRH.CheckedChanged
        Try
            If swAprobadoRH.CheckValue = "1" Then swAprobadoRH.Text = "Rechazado"
            If swAprobadoRH.CheckValue = "0" Then swAprobadoRH.Text = "Aprobado"
            If swAprobadoRH.CheckValue = "NULL" Then swAprobadoRH.Text = "Rechazado"
        Catch
        End Try
    End Sub
End Class