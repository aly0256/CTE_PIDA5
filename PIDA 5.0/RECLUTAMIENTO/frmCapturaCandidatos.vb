Imports System.Runtime.CompilerServices

Public Class frmCapturaCandidatos

#Region "Declaraciones"
    Dim dtLocal As New DataTable        'Lista de datos para grid
    Dim dtTitulo As New DataTable       'Tabla de Titulos
    Dim dtVacantes As New DataTable     'Mantiene el registro actual
    Dim dtGenero As New DataTable       'Tabla de Generos
    Dim dtCivil As New DataTable        'Tabla de Estados Civiles
    Dim dtCiudad As New DataTable       'Tabla de Ciudades
    Dim dtPaises As New DataTable       'Tabla de Paises
    Dim dtEstados As New DataTable      'Tabla de Estados
    Dim dtEstados2 As New DataTable     'Tabla de Estados
    Dim dtMunicipios As New DataTable   'Tabla de Municipios
    Dim dtColonia As New DataTable
    Dim dtCP As New DataTable
    Dim dtGrado As New DataTable
    Dim dtIdiomas As New DataTable
    Dim dtIdiomas2 As New DataTable
    Dim dtIdiomas3 As New DataTable
    Dim dtTelCia As New DataTable       'Para sacar el telefono de la compania
    Dim dtAuxiliares As New DataTable       'Para sacar varios datos de auxiliares
    Dim dtTurno As New DataTable
    Dim TabActual As Integer
    Dim Agregar As Boolean
    Dim Cancelar As Boolean
    Dim banderaError As Boolean

#End Region



    Private Sub HabilitarBotones()
        Try
            btnPrimero.PerformClick()

            btnPrimero.Enabled = Agregar And Not Cancelar
            btnAnterior.Enabled = Agregar And Not Cancelar
            btnSiguiente.Enabled = Agregar And Not Cancelar
            btnUltimo.Enabled = Agregar And Not Cancelar

            'gpVacante.Enabled = Agregar And Not Cancelar
            TabRegistro.Enabled = Agregar And Not Cancelar
            cmbVacante.Enabled = Agregar And Not Cancelar
            cmbFechaAplica.Enabled = Agregar And Not Cancelar

            If Agregar Then
                ' Si está activa nuevo registro
                btnNuevo.Image = PIDA.My.Resources.Ok16
                btnNuevo.Text = "Aceptar"
                btnCerrar.Text = "Cancelar"
            Else
                btnNuevo.Image = PIDA.My.Resources.NewRecord
                btnNuevo.Text = "Agregar"
                btnCerrar.Text = "Salir"
            End If
            txtFolio.ReadOnly = True
            If Agregar Or Cancelar Then
                'txtFolio.Text = IIf(Agregar, AsignarFolio(), "")
                txtFolio.Text = ""
                cmbTitulo.SelectedIndex = -1
                cmbVacante.SelectedIndex = -1
                cmbFechaAplica.Value = IIf(Agregar, Now, Nothing)
                cmbPaisNac.SelectedValue = "MEX"
                txtNombre.Text = ""
                txtSegundoNombre.Text = ""
                txtPaterno.Text = ""
                txtMaterno.Text = ""
                txtIMSS.Text = ""
                txtIMSSdv.Text = ""
                txtRFC.Text = ""
                txtCurp.Text = ""
                cmbFechaNac.Value = Nothing
                swGenero.Value = False
                cmbCivil.SelectedIndex = -1
                cmbTallaPantalon.SelectedIndex = -1
                txtNacionalidad.Text = ""
                intNumeroHijos.Value = 0
                txtDireccion.Text = ""
                txtDepartamento.Text = ""
                cmbCiudad.SelectedValue = "00305"
                cmbEstado.SelectedValue = "QT"
                cmbColonia.SelectedIndex = 0
                'cmbColonia.SelectedValue = "0000"
                'cmbColonia.Text = ""
                'cmbColonia2.SelectedIndex = -1
                'cmbColonia2.SelectedValue = "0000"
                'cmbColonia2.Text = ""
                cmbTallaPlayera.SelectedIndex = -1
                cmbTallaZapato.SelectedIndex = -1
                'cmbMunicipio.SelectedValue = "1831"
                txtCP.Text = ""
                txtTelefono1.Text = ""
                txtTelefono2.Text = ""
                dtTelCia = sqlExecute("select telefono1 from personal.dbo.plantas where cod_planta = '001' and cod_comp = 'WME'")
                If dtTelCia.Rows.Count > 0 Then
                    txtTelefono3.Text = dtTelCia.Rows(0).Item("telefono1").ToString.Trim
                Else
                    txtTelefono3.Text = ""
                End If
                txtTelefono4.Text = ""
                txtTelefono5.Text = ""
                txtLugarNacimiento.Text = ""
                cmbEstadoNac.SelectedIndex = -1
                cmbGrado.SelectedIndex = -1
                txtOtroGrado.Text = ""

                txtNomEmp1.Text = ""
                txtPuesto1.Text = ""
                txtSueldo1.Text = ""
                txtIngreso1.Text = ""
                txtBaja1.Text = ""
                txtActividades1.Text = ""

                txtNomEmp2.Text = ""
                txtPuesto2.Text = ""
                txtSueldo2.Text = ""
                txtIngreso2.Text = ""
                txtBaja2.Text = ""
                txtActividades2.Text = ""

                txtNomEmp3.Text = ""
                txtPuesto3.Text = ""
                txtSueldo3.Text = ""
                txtIngreso3.Text = ""
                txtBaja3.Text = ""
                txtActividades3.Text = ""

                'txtComentarios.Text = ""
                Cbpoliticas.Checked = False
                'cmbAgencia.Text = ""
                cmbAgencia.SelectedIndex = -1
                'cmbMedio.Text = ""
                cmbMedio.SelectedIndex = -1
                txtRecomendadoPor.Text = ""
                'cmbTurno.Text = ""
                cmbTurno.SelectedIndex = -1
                txtEmailBusiness.Text = ""
                txtEmailPersonal.Text = ""
                txtEmailOtro.Text = ""
                cbDeclaracionDeVerdad.Checked = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Function AsignarFolio()
        Dim strFolio As String = ""
        Dim dtFolio As New DataTable
        Try
            dtFolio = sqlExecute("select top 1 (cast(folio as int) + 1) as 'folio'  from Candidatos order by folio desc", "Reclutamiento")
            If dtFolio.Rows.Count > 0 Then
                strFolio = dtFolio.Rows(0).Item("folio").ToString
                strFolio = IIf(strFolio.Length > 5, strFolio.PadLeft(strFolio.Length + 1, "0"), strFolio.PadLeft(5, "0"))
            ElseIf dtFolio.Columns.Count = 1 And dtFolio.Columns.Contains("ERROR") Then
                strFolio = "00000"
                MsgBox("Se produjo un error al intentar asignar el folio", MsgBoxStyle.Exclamation, "Aviso")
            Else
                strFolio = "00001"
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            strFolio = "00000"
            MsgBox("No se pudo asignar el folio", MsgBoxStyle.Critical, "Error")
        End Try
        Return strFolio
    End Function

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

            ''Validar IMSS
            'If txtIMSSdv.Text.Trim <> DigitoVerificador(txtIMSS.Text.Trim) Then
            '    banderaError = True
            '    MessageBox.Show("El numero de IMSS no es válido. Favor de verificar.", "IMSS inválido", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    txtIMSS.Focus()
            '    Exit Sub
            'Else
            '    banderaError = False
            'End If

            ''Validar RFC
            'If Not ValidaRFC(txtRFC.Text.Trim) Then
            '    banderaError = True
            '    MessageBox.Show("El RFC no es válido. Favor de verificar.", "RFC inválido", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    txtRFC.Focus()
            '    Exit Sub
            'Else
            '    banderaError = False
            'End If

            ''Validar CURP
            'If Not ValidaCURP(txtCurp.Text.Trim) Then
            '    banderaError = True
            '    MessageBox.Show("La CURP no es válida. Favor de verificar.", "CURP inválida", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    txtCurp.Focus()
            '    Exit Sub
            'Else
            '    banderaError = False
            'End If

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

            'If txtEmailPersonal.Text.Trim = "" Then
            '    banderaError = True
            '    MsgBox("Ingrese el correo personal del candidato", MsgBoxStyle.Exclamation, "AVISO")
            '    txtEmailPersonal.Focus()
            '    Exit Sub
            'Else
            '    banderaError = False
            'End If
            If cmbAgencia.SelectedIndex = -1 Then
                banderaError = True
                MsgBox("Seleccione una agencia", MsgBoxStyle.Exclamation, "AVISO")
                cmbAgencia.Focus()
                Exit Sub
            Else
                banderaError = False
            End If

            If Not cbDeclaracionDeVerdad.Checked Then
                banderaError = True
                MsgBox("Haga click para aceptar que la información es verdad", MsgBoxStyle.Exclamation, "AVISO")
                cbDeclaracionDeVerdad.Focus()
                Exit Sub
            Else
                banderaError = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    'Public Function DigitoVerificador(IMSS As String) As String
    '    Dim Cadena As String = ""
    '    Dim Bandera As Boolean = True
    '    Dim Num As Integer = 0
    '    Dim Suma As Integer = 0
    '    Dim Car As String
    '    Dim Dv As String
    '    Try
    '        If IMSS.Length < 10 Then
    '            Return "*"
    '        End If

    '        For x = 0 To 9
    '            If Bandera Then
    '                Num = Val(IMSS.Substring(x, 1)) * 1
    '            Else
    '                Num = Val(IMSS.Substring(x, 1)) * 2
    '            End If
    '            Cadena = Cadena + Num.ToString.PadLeft(2, "0")
    '            Bandera = Not Bandera
    '        Next x
    '        For x = 0 To Len(Cadena) - 1
    '            Suma = Suma + Val(Cadena.Substring(x, 1))
    '        Next x
    '        Car = Suma.ToString.Substring(0, 1)
    '        Dv = ((Val(Car) + 1) * 10) - Suma
    '        If Dv = 10 Then
    '            Dv = 0
    '        End If

    '        Return Dv
    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
    '        Return "*"
    '    End Try
    'End Function


    Private Sub frmCapturaCandidatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtVacantes = sqlExecute("select Cod_Vac as 'CODIGO',Vacante as 'VACANTE' from vacantes where Activo = 1 order by Vacante", "Reclutamiento")
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
            cmbPaisNac.SelectedValue = "MEX"

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

            'dtMunicipios = sqlExecute("select Rtrim(Ltrim(COD_MUN)) as 'CODIGO', Rtrim(Ltrim(NOMBRE)) as 'NOMBRE'  from municipios order by NOMBRE", "reclutamiento")
            'cmbMunicipio.DataSource = dtMunicipios
            'cmbMunicipio.ValueMember = "CODIGO"
            'cmbMunicipio.DisplayMembers = "NOMBRE"
            'cmbMunicipio.SelectedIndex = -1

            swGenero.Value = False

            dtCivil = sqlExecute("select Rtrim(Ltrim(COD_CIVIL)) as 'CODIGO', Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from civil")
            cmbCivil.DataSource = dtCivil
            cmbCivil.ValueMember = "CODIGO"
            cmbCivil.DisplayMembers = "NOMBRE"
            cmbCivil.SelectedIndex = -1

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

            dtAuxiliares = sqlExecute("select idFld as 'CODIGO', CAMPO_VALIDO as 'NOMBRE' from personal.dbo.auxiliares_validos where campo = 'AGENCIA'")
            cmbAgencia.DataSource = dtAuxiliares
            cmbAgencia.ValueMember = "CODIGO"
            cmbAgencia.DisplayMember = "NOMBRE"
            cmbAgencia.SelectedIndex = -1

            dtAuxiliares = sqlExecute("select idFld as 'CODIGO', CAMPO_VALIDO as 'NOMBRE' from personal.dbo.auxiliares_validos where campo = 'FUENTE_R'")
            cmbMedio.DataSource = dtAuxiliares
            cmbMedio.ValueMember = "CODIGO"
            cmbMedio.DisplayMember = "NOMBRE"
            cmbMedio.SelectedIndex = -1

            dtCiudad = sqlExecute("select Rtrim(Ltrim(COD_CD)) as 'CODIGO', Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from ciudad order by nombre")
            cmbCiudad.DataSource = dtCiudad
            cmbCiudad.ValueMember = "CODIGO"
            cmbCiudad.DisplayMembers = "NOMBRE"
            cmbCiudad.SelectedValue = "00305"

            'dtColonia = sqlExecute("select Rtrim(Ltrim(cod_col)) as 'CODIGO',Rtrim(Ltrim(nombre)) as 'NOMBRE' from colonias where Rtrim(Ltrim(ISNULL(COD_COL,''))) <> '' and Rtrim(Ltrim(ISNULL(nombre,''))) <> '' order by nombre")
            'cmbColonia2.DataSource = dtColonia
            'cmbColonia2.ValueMember = "CODIGO"
            'cmbColonia2.DisplayMember = "NOMBRE"
            'cmbColonia2.SelectedIndex = -1

            dtColonia = sqlExecute("select * from colonias")
            cmbColonia.DataSource = dtColonia

            dtGrado = sqlExecute("select Rtrim(Ltrim(COD_ESCUELA)) as 'CODIGO',Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from escuelas order by COD_ESCUELA")
            cmbGrado.DataSource = dtGrado
            cmbGrado.ValueMember = "CODIGO"
            cmbGrado.DisplayMembers = "NOMBRE"
            cmbGrado.SelectedIndex = -1

            'dtTurno = sqlExecute("select Rtrim(Ltrim(COD_TURNO)) as 'CODIGO', Rtrim(Ltrim(NOMBRE)) as 'NOMBRE' from personal.dbo.turnos where cod_comp = 'WME' order by nombre")
            dtTurno = sqlExecute("select '1' as 'CODIGO', 'Turno 1' as 'NOMBRE' union select '2' as 'CODIGO', 'Turno 2' as 'NOMBRE' union select '3' as 'CODIGO', 'Turno 3' as 'NOMBRE'")
            cmbTurno.DataSource = dtTurno
            cmbTurno.ValueMember = "CODIGO"
            cmbTurno.DisplayMember = "NOMBRE"

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
        HabilitarBotones()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            If Agregar Then
                Dim strSQL As String = ""
                txtFolio.Text = AsignarFolio()
                ValidaControles()
                If banderaError Then
                    Exit Sub
                End If
                If MessageBox.Show("¿Desea realizar algún cambio antes de registrar al candidato?", "Registro Candidato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Exit Sub
                End If
                strSQL = "INSERT INTO Candidatos (Cod_Vac,Folio,salutation,FhaApli,Nombre,SegundoNombre,Paterno,Materno,Genero,Nacionalidad,FhaNac,Cod_civil,Numero_Hijos,TallaZapato,TallaPantalon,TallaPlayera,imss,DIG_VER,RFC,CURP,Direccion,Departamento,"
                strSQL = strSQL & "Ciudad,cod_col,Colonia,CP,Cod_Est,Municipio,Telefono1,Telefono2,Telefono3,Telefono4,Telefono5,EmailPersonal,EmailBusiness,EmailOtro,Cod_Pais_Nac,lugar_nac,Cod_Est_Nac,EdoNac,UltimoGrado,OtroGrado,"
                strSQL = strSQL & "NomEmpUltTrab,AnoIngresoUltTrab,AnoBajaUltimoTrab,PuestoUltTrab,SueldoMenUltTrab,ActUltTrab,NomEmpPenTrab,AnoIngresoPenTrab,AnoBajaPenTrab,PuestoPenTrab,"
                strSQL = strSQL & "SueldoMenPenTrab,ActPenTrab,NomEmpAntTrab,AnoIngresoAntTrab,AnoBajaAntTrab,PuestoAntTrab,SueldoMenAntTrab,ActAntTrab,agencia,Medio,AceptaPoliPriva,RecomendadoPor,TurnoPreferencia,Captura,Usuario,DuracionCaptura,pertenecioASindicato,DeclaracionDeVerdad) "
                strSQL = strSQL & "VALUES ('" & cmbVacante.SelectedValue & "','" & txtFolio.Text.Trim & "','" & cmbTitulo.SelectedValue & "','" & FechaSQL(cmbFechaAplica.Value) & "',"
                strSQL = strSQL & "'" & txtNombre.Text.ToLower.ToTitleCase.Trim & "','" & txtSegundoNombre.Text.ToLower.ToTitleCase.Trim & "','" & txtPaterno.Text.ToLower.ToTitleCase.Trim & "','" & txtMaterno.Text.ToLower.ToTitleCase.Trim & "','" & IIf(swGenero.Value, "M", "F") & "','" & txtNacionalidad.Text.Trim & "','" & FechaSQL(cmbFechaNac.Value) & "',"
                strSQL = strSQL & "'" & cmbCivil.SelectedValue & "','" & intNumeroHijos.Text & "','" & cmbTallaZapato.Text & "','" & cmbTallaPantalon.Text & "','" & cmbTallaPlayera.Text & "','" & txtIMSS.Text.Trim & "','" & txtIMSSdv.Text.Trim & "','" & txtRFC.Text.Trim & "','" & txtCurp.Text.Trim & "','" & txtDireccion.Text.Trim & "',"
                'strSQL = strSQL & "'" & txtDepartamento.Text.Trim & "','" & cmbCiudad.SelectedValue & "','" & IIf(IsNothing(cmbColonia.SelectedValue), "", cmbColonia.SelectedValue) & "','" & cmbColonia.Text.ToString.Trim & "','" & txtCP.Text.Trim & "','" & cmbEstado.SelectedValue & "','" & cmbMunicipio.SelectedValue & "','" & txtTelefono1.Text.Trim & "',"
                strSQL = strSQL & "'" & txtDepartamento.Text.Trim & "','" & cmbCiudad.SelectedValue & "','" & IIf(IsNothing(cmbColonia.SelectedValue), "", cmbColonia.SelectedValue) & "','" & cmbColonia.Text.Split(",")(1).Trim & "','" & txtCP.Text.Trim & "','" & cmbEstado.SelectedValue & "','','" & txtTelefono1.Text.Trim & "',"
                strSQL = strSQL & "'" & txtTelefono2.Text.Trim & "','" & txtTelefono3.Text.Trim & "','" & txtTelefono4.Text.Trim & "','" & txtTelefono5.Text.Trim & "',"
                strSQL = strSQL & "'" & txtEmailPersonal.Text.Trim & "','" & txtEmailBusiness.Text.Trim & "','" & txtEmailOtro.Text.Trim & "',"
                strSQL = strSQL & "'" & cmbPaisNac.SelectedValue & "','" & txtLugarNacimiento.Text.Trim & "','" & cmbEstadoNac.SelectedValue & "','" & cmbEstadoNac.Text.ToString.Trim & "','" & cmbGrado.SelectedValue & "','" & txtOtroGrado.Text.Trim & "','" & txtNomEmp1.Text.Trim & "',"
                strSQL = strSQL & "'" & txtIngreso1.Text.Trim & "','" & txtBaja1.Text.Trim & "',"
                strSQL = strSQL & "'" & txtPuesto1.Text.Trim & "','" & txtSueldo1.Text.Trim & "','" & txtActividades1.Text.Trim & "','" & txtNomEmp2.Text.Trim & "','" & txtIngreso2.Text.Trim & "','" & txtBaja2.Text.Trim & "','" & txtPuesto2.Text.Trim & "','" & txtSueldo2.Text.Trim & "',"
                strSQL = strSQL & "'" & txtActividades2.Text.Trim & "','" & txtNomEmp3.Text.Trim & "','" & txtIngreso3.Text.Trim & "','" & txtBaja3.Text.Trim & "','" & txtPuesto3.Text.Trim & "','" & txtSueldo3.Text.Trim & "','" & txtActividades3.Text.Trim & "',"
                strSQL = strSQL & "'" & cmbAgencia.Text & "','" & cmbMedio.Text & "','" & Cbpoliticas.Checked & "','" & txtRecomendadoPor.Text.Trim & "','" & cmbTurno.Text.Trim & "',GETDATE(),'" & Usuario & "','" & clkCronometro.Value.TimeOfDay.ToString & "','" & cbSindicato.Checked & "','" & cbDeclaracionDeVerdad.Checked & "')"
                dtLocal = sqlExecute(strSQL, "Reclutamiento")
                If dtLocal.Columns.Count = 1 Then
                    MsgBox("Se presentó un error al intentar agregar el registro", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                Else
                    MsgBox("El candidato con folio [" & txtFolio.Text.Trim & "] ha sido registrado", MsgBoxStyle.Information, "Informe")

                End If

                For Each row As DataGridViewRow In dgDependientes.Rows
                    If Not row.IsNewRow Then
                        If row.Cells("primerNombre").Value.ToString.Trim.Length > 0 And row.Cells("apellidoPaterno").Value.ToString.Trim.Length > 0 And row.Cells("parentezco").Value.ToString.Trim.Length > 0 And row.Cells("fechaNacimiento").Value.ToString.Trim.Length > 0 Then
                            strSQL = "INSERT into Dependientes (Folio, Nombre, SegundoNombre, Paterno, Materno, Parentezco, FhaNacimiento) "
                            strSQL = strSQL & "VALUES ('" & txtFolio.Text.Trim & "','" & row.Cells("primerNombre").Value.ToString.Trim & "', "
                            If IsNothing(row.Cells("segundoNombre").Value) Then
                                strSQL = strSQL & "'', "
                            Else
                                strSQL = strSQL & "'" & row.Cells("segundoNombre").Value.ToString.Trim & "', "
                            End If
                            strSQL = strSQL & "'" & row.Cells("apellidoPaterno").Value.ToString.Trim & "', "
                            If IsNothing(row.Cells("apellidoMaterno").Value) Then
                                strSQL = strSQL & "'', "
                            Else
                                strSQL = strSQL & "'" & row.Cells("apellidoMaterno").Value.ToString.Trim & "', "
                            End If
                            strSQL = strSQL & "'" & row.Cells("parentezco").Value.ToString.Trim & "','" & FechaSQL(row.Cells("fechaNacimiento").Value.ToString.Trim) & "')"
                            dtLocal = sqlExecute(strSQL, "Reclutamiento")
                        Else
                            MsgBox("Error al guardar la informacion del dependiente", MsgBoxStyle.Critical, "Error")
                        End If
                    End If
                Next

                Agregar = False
                Cancelar = True
                dgDependientes.Rows.Clear()
                Timer1.Stop()
            Else
                'If cmbVacante.SelectedIndex = -1 Then
                '    MsgBox("Debe seleccionar una Vacante", MsgBoxStyle.Exclamation, "Aviso")
                '    cmbVacante.Focus()
                'End If

                'Agregar = IIf(cmbVacante.SelectedIndex = -1, False, True)
                Agregar = True
                Cancelar = False
                clkCronometro.Value = "00:00:00"
                Timer1.Start()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
        HabilitarBotones()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Timer1.Stop()
        Cancelar = True
        Agregar = False
        If btnCerrar.Text.ToUpper = "SALIR" Then
            Me.Close()
        End If
        HabilitarBotones()
    End Sub

    Private Sub frmCapturaCandidatos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        TabActual = 0
        TabRegistro.SelectedTabIndex = TabActual
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        TabActual = TabRegistro.Tabs.Count - 1
        TabRegistro.SelectedTabIndex = TabActual
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        TabActual -= 1
        If TabActual < 0 Then
            TabActual = 0
        End If
        TabRegistro.SelectedTabIndex = TabActual
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        TabActual += 1
        If TabActual > (TabRegistro.Tabs.Count - 1) Then
            TabActual = (TabRegistro.Tabs.Count - 1)
        End If
        TabRegistro.SelectedTabIndex = TabActual
    End Sub

    Private Sub TabRegistro_TabStripMouseClick(sender As Object, e As MouseEventArgs) Handles TabRegistro.TabStripMouseClick
        TabActual = TabRegistro.SelectedTabIndex
    End Sub

    Private Sub cmbCiudad_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbCiudad.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("ciudad", "cod_cd", "ciudad", False)
        If Cod <> "CANCELAR" Then
            cmbCiudad.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbEstado_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbEstado.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("reclutamiento.dbo.estados", "cod_edo", "estado", False)
        If Cod <> "CANCELAR" Then
            cmbEstado.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbEstadoNac_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbEstadoNac.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("reclutamiento.dbo.estados", "cod_edo", "estado", False)
        If Cod <> "CANCELAR" Then
            cmbEstadoNac.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbPaisNac_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbPaisNac.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("reclutamiento.dbo.CountryISO", "code", "pais", False)
        If Cod <> "CANCELAR" Then
            cmbPaisNac.SelectedValue = Cod
        End If
    End Sub



    Private Sub cmbMunicipio_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbMunicipio.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("reclutamiento.dbo.municipios", "cod_mun", "municipio", False)
        If Cod <> "CANCELAR" Then
            cmbMunicipio.SelectedValue = Cod
        End If
    End Sub

    'Private Sub txtCurp_TextChanged(sender As Object, e As EventArgs) Handles txtCurp.TextChanged
    'If txtCurp.Text.Substring(10, 1).Equals("M") Then
    '    swGenero.Value = False
    'Else
    '    swGenero.Value = True
    'End If
    'End Sub

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
End Class