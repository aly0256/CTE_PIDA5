
Option Compare Binary
Imports System.Deployment
Public Class loginemp

    Dim Sucursales() As strucSucursales
    Dim dtUsuarios As New DataTable

    Private Sub loginemp_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.CapsLock Then
            statusMay.Visible = My.Computer.Keyboard.CapsLock
        ElseIf e.KeyCode = Keys.NumLock Then
            statusNum.Visible = My.Computer.Keyboard.NumLock
        End If
    End Sub

    Private Sub loginemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Srvr As String = ""
        Dim Usr As String = ""
        Dim Ln As String = ""
        Try
            Try
                Dim FILE_NAME As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\SERV.PIDA"

                If Dir(FILE_NAME) <> "" Then
                    Dim objReader As New System.IO.StreamReader(FILE_NAME)

                    Try
                        Ln = objReader.ReadLine
                        Usr = Ln.Substring(0, Ln.IndexOf("|"))
                        Srvr = Ln.Substring(Ln.IndexOf("|") + 1)
                    Catch ex As Exception
                        Usr = ""
                        Srvr = ""
                    Finally
                        objReader.Close()
                    End Try
                Else
                    Usr = ""
                    Srvr = ""
                End If

                If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
                    'Si está corriendo desde el archivo ClickOnce, obtener versión de publish
                    ApVer = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
                Else
                    ApVer = My.Application.Info.Version.ToString.Trim
                End If
                Me.Text = "Acceso de usuarios - PIDA " & ApVer
                statusMay.Visible = My.Computer.Keyboard.CapsLock
                statusNum.Visible = My.Computer.Keyboard.NumLock
            Catch ex As Exception

            End Try


            Sucursales = ListaSucursales()
            Try
                For x As Integer = 0 To UBound(Sucursales)
                    cmbSucursal.Items.Add(Sucursales(x).nombre)
                Next
            Catch ex As Exception

            End Try


            Try
                txtUsuario.Text = Usr
                cmbSucursal.Text = Srvr
                If Usr.Length = 0 Then
                    txtUsuario.Focus()
                    txtUsuario.Select()
                Else
                    txtClave.Focus()
                    txtClave.Select()
                End If
            Catch ex As Exception

            End Try


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim ErrorLogin As Boolean
        Dim dtEstilo As New DataTable
        Dim dtCias As New DataTable
        Dim dtSuplente As New DataTable
        Dim dtParametros As New DataTable
        Dim suc As String
        Try
            suc = cmbSucursal.Text

            For Each Sucursal In Sucursales
                If suc = Sucursal.nombre Then
                    SQLConn = Sucursal.conexion
                    sPassword = Sucursal.clave
                    sUserAdmin = Sucursal.usuario
                    Exit For
                End If
            Next

            ErrorLogin = False
            dtParametros = sqlExecute("SELECT * FROM parametros")

            dtCias = sqlExecute("SELECT cod_comp FROM cias WHERE cia_default = 1")
            If dtCias.Rows.Count = 0 Then
                MessageBox.Show("No se ha asignado compañía default en este servidor. Favor de verificar para poder continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            dtUsuarios = sqlExecute("SELECT * FROM appuser WHERE username = '" & txtUsuario.Text & "'", "Seguridad")
            If dtUsuarios.Rows.Count > 0 Then
                'Revisar si la clave de usuario = encriptar la clave dada
                If dtUsuarios.Rows.Item(0).Item("userpass").ToString.Trim = getMD5Hash(txtClave.Text) Then
                    ErrorLogin = False
                Else
                    ErrorLogin = True
                End If

                If ErrorLogin Then
                    MessageBox.Show("El usuario y/o contraseña son incorrectos, favor de verificar.", "Error en acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Usuario = txtUsuario.Text
                    FiltroXUsuario = IIf(IsDBNull(dtUsuarios.Rows.Item(0).Item("filtro")), "", dtUsuarios.Rows.Item(0).Item("filtro").ToString.Trim)
                    Perfil = "'" & IIf(IsDBNull(dtUsuarios.Rows.Item(0).Item("cod_perfil")), "", dtUsuarios.Rows.Item(0).Item("cod_perfil")).ToString.Trim & "'"

                    'REVISAR SI EL USUARIO ES SUPLENTE DE ALGUIEN MAS, Y AUMENTAR SUS PRIVILEGIOS DE SER NECESARIO
                    dtSuplente = sqlExecute("SELECT cod_perfil,ISNULL(filtro,'') AS filtro FROM appuser " & _
                                            "WHERE NOT(cod_perfil IS NULL or cod_perfil = '' or cod_perfil = " & Perfil & ") AND (" & _
                                            "(activo_suplente1 = 1 AND suplente1 = '" & Usuario & "') OR " & _
                                            "(activo_suplente2 = 1 AND suplente2 = '" & Usuario & "') OR " & _
                                            "(activo_suplente3 = 1 AND suplente3 = '" & Usuario & "')) AND " & _
                                            "((suplente_definido = 0 OR suplente_definido IS NULL) OR " & _
                                            "(suplente_definido = 1 AND GETDATE() BETWEEN SUPLENTE_FECHA_INICIO AND SUPLENTE_FECHA_FIN))", "Seguridad")

                    For Each dR As DataRow In dtSuplente.Rows
                        Perfil = Perfil & ",'" & dR("cod_perfil").ToString.Trim & "'"
                        'Si el filtroXUsuario viene en blanco (el usuario principal no tiene filtros), 
                        'ignorar los filtros que tiene como suplente
                        FiltroXUsuario = FiltroXUsuario & _
                            IIf(dR("filtro") = "", _
                                "", _
                                IIf(FiltroXUsuario.Length = 0, _
                                    "", " OR (" & dR("filtro").ToString.Trim & ")"))
                    Next
                    Perfil = " IN(" & Perfil & ")"
                    If FiltroXUsuario.Length > 0 Then
                        FiltroXUsuario = "(" & FiltroXUsuario & ")"
                    End If
                    '********************************************


                    ModuloInicial = IIf(IsDBNull(dtUsuarios.Rows.Item(0).Item("modulo")), "", dtUsuarios.Rows.Item(0).Item("modulo")).ToString.Trim
                    dtTemporal = sqlExecute("SELECT MAX(nivel_sueldos) as nivel_sueldos,MAX(nivel_consulta) AS nivel_consulta," & _
                                            "MAX(nivel_edicion) AS nivel_edicion FROM perfiles WHERE cod_perfil " & Perfil.Trim, "Seguridad")
                    If dtTemporal.Rows.Count > 0 Then
                        NivelSueldos = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("nivel_sueldos")), 0, dtTemporal.Rows.Item(0).Item("nivel_sueldos"))
                        NivelConsulta = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("nivel_consulta")), 0, dtTemporal.Rows.Item(0).Item("nivel_consulta"))
                        NivelEdicion = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("nivel_edicion")), 0, dtTemporal.Rows.Item(0).Item("nivel_edicion"))
                    Else
                        NivelConsulta = 0
                        NivelSueldos = 0
                        NivelEdicion = 0
                    End If

                    ReDim Filtros(2, 10)
                    NFiltros = 0
                    ReDim Orden(2, 10)
                    NOrden = 1
                    Orden(1, 0) = "RELOJ"
                    Orden(2, 0) = "ASC"

                    resCancelar = False
                    '**** CLAVE DE ACCESO CON CADUCIDAD. HABILITAR SI LOS DIAS DE CADUCIDAD SON > 0 ****
                    If IIf(IsDBNull(dtParametros.Rows(0).Item("dias_expira_clave")), 0, dtParametros.Rows(0).Item("dias_expira_clave")) > 0 Then
                        If dtUsuarios.Rows.Item(0).Item("fecha_expira") <= Today Then
                            resCancelar = True
                            If MessageBox.Show("La clave de acceso ha expirado. Para continuar con el programa, deberá introducir una nueva clave.", "Clave de acceso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                                frmCambiarClave.ShowDialog()
                            End If
                        End If
                    End If
                    '****************************************************************
                    If resCancelar Then
                        Me.Close()
                        End
                    Else
                        Dim Srvr As String = cmbSucursal.Text
                        Dim Usr As String = txtUsuario.Text
                        Try
                            Dim FILE_NAME As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\SERV.PIDA"
                            Dim objReader As New System.IO.StreamWriter(FILE_NAME)
                            objReader.WriteLine(Usr.Trim & "|" & Srvr.Trim)
                            objReader.Close()
                        Catch ex As Exception
                            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                        End Try

                        DireccionReportes = IIf(IsDBNull(dtParametros.Rows(0).Item("path_reportes")), "", dtParametros.Rows(0).Item("path_reportes")).ToString.Trim
                        If DireccionReportes.Length > 0 Then
                            DireccionReportes = DireccionReportes & IIf(DireccionReportes.Substring(DireccionReportes.Trim.Length - 1) = "\", "", "\")
                        End If
                        If DireccionReportes.Length = 0 Then
                            MessageBox.Show("No se ha indicado la ubicación de los reportes, por lo que éstos no se ejecutarán correctamente.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                        PathFoto = IIf(IsDBNull(dtParametros.Rows(0).Item("path_foto")), "", dtParametros.Rows(0).Item("path_foto")).ToString.Trim
                        If PathFoto.Length > 0 Then
                            PathFoto = PathFoto & IIf(PathFoto.Substring(PathFoto.Trim.Length - 1) = "\", "", "\")
                        End If
                        If PathFoto.Length = 0 Then
                            MessageBox.Show("No se ha indicado la ubicación de las fotografías, por lo que éstas no se mostrarán correctamente.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf Dir(PathFoto & "*.jpg").Length = 0 Then
                            MessageBox.Show("No se localizaron fotografías en la ubicación indicada, por lo que éstas no se mostrarán correctamente.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                        PathFirma = IIf(IsDBNull(dtParametros.Rows(0).Item("path_firma_capacitacion")), "", dtParametros.Rows(0).Item("path_firma_capacitacion")).ToString.Trim
                        If PathFirma.Length > 0 Then
                            PathFirma = PathFirma & IIf(PathFirma.Substring(PathFirma.Trim.Length - 1) = "\", "", "\")
                        End If
                        If PathFirma.Length = 0 Then
                            MessageBox.Show("No se ha indicado la ubicación de las firmas para  capacitación, por lo que éstas no se mostrarán correctamente.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf Dir(PathFirma & "*.jpg").Length = 0 Then
                            MessageBox.Show("No se localizaron firmas en la ubicación indicada, por lo que éstas no se mostrarán correctamente.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                        'MCR 9/NOV/2015
                        'Tomar dato desde inicio
                        IniciaLunes = IIf(IsDBNull(dtParametros.Rows.Item(0)("inicia_sem")), 2, dtParametros.Rows.Item(0)("inicia_sem")) = 2

                        'Asignar el estilo de pantallas de acuerdo a las preferencias seleccionadas por el usuario
                        dtEstilo = sqlExecute("SELECT estilo,color FROM appuser WHERE username = '" & Usuario & "'", "Seguridad")

                        Try
                            sqlExecute("insert into registro_accesos (usuario, fecha_hora, equipo, version) values ('" & Usuario & "', getdate(), '" & My.Computer.Name & "', '" & ApVer & "')", "seguridad")
                        Catch ex As Exception

                        End Try

                        Dim scheme As DevComponents.DotNetBar.eStyle
                        Dim sSel As String = dtEstilo.Rows.Item(0).Item("estilo").ToString.Trim
                        scheme = CType(System.Enum.Parse(GetType(DevComponents.DotNetBar.eStyle), sSel, False), DevComponents.DotNetBar.eStyle)
                        mgrColorTint = Color.FromArgb(IIf(IsDBNull(dtEstilo.Rows.Item(0).Item("color")), -1, dtEstilo.Rows.Item(0).Item("color")))
                        mgrStyle = scheme
                        frmMain.Show()
                        Me.Close()
                        frmMain.Focus()
                        Me.Dispose()
                    End If
                End If
            Else
                MessageBox.Show("El usuario y/o contraseña son incorrectos, favor de verificar.", "Error en acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

            MessageBox.Show("No puede ser iniciado el sistema. Por favor, contacte al administrador del mismo." & vbCrLf & vbCrLf & _
                            "Err.- " & " " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        End
    End Sub

    Private Sub txtUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged
        btnOk.Enabled = (txtUsuario.Text <> "")
    End Sub

    Private Sub txtUsuario_GotFocus(sender As Object, e As EventArgs) Handles txtUsuario.GotFocus
        txtUsuario.SelectAll()
    End Sub
End Class