Public Class frmPerfilesAdmKiosco
  
    Dim dtPerfiles As New DataTable
    Dim dtFormas As New DataTable
    Dim dtModulos As New DataTable
    Dim Nuevo As Boolean
    Dim Editar As Boolean
    Dim ProcesoCancelado As Boolean


    Private Sub ListarFORMAS()

        Try

            dtFormas = sqlExecute("Select modulo,forma,acceso,control from formas_disponibles order by modulo", "Kiosco")

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub RefrescaInformacion()
        Try

            If dtPerfiles.Rows.Count > 0 Then

                txtCodigo.Text = dtPerfiles.Rows.Item(0).Item("cod_perfil")
                txtNombre.Text = IIf(IsDBNull(dtPerfiles.Rows.Item(0).Item("nombre")), "NO IDENTIFICADO", dtPerfiles.Rows.Item(0).Item("nombre"))


            End If

            RevisarAccesosFORMAS(txtCodigo.Text)

        Catch ex As Exception
            MessageBox.Show("Se detectaron errores al tratar de cargar la información. " & _
                           "Si el problema persiste, contactar al administrador del sistema." & _
                           vbCrLf & vbCrLf & "Error: " & ex.Message, "PIDA - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub RevisarAccesosFORMAS(ActPerfil As String)
        Dim dtTemp As New DataTable
        Dim Acceso As Boolean
        Dim i As Integer
        Dim si As Integer
        Dim t As Integer = 0
        Dim Tg As String
        Try

            dtModulos = New DataTable

            If dtFormas.Rows.Count > 0 Then
                dtModulos = dtFormas.DefaultView.ToTable(True, "modulo")

            Else
                dtModulos.Columns.Add("modulo")
            End If

            For Each rp As DataRow In dtModulos.Rows
                'Poner como tag en cada RibbonPanel, a qué módulo pertenece
                Tg = IIf(IsDBNull(rp("modulo")), "", rp("modulo"))
                'Revisar cada control dentro del panel
                si = 0
                For Each c As DataRow In dtFormas.Select("modulo = '" & Tg & "'")
                    i = 0

                    dtTemp = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'F' AND control = '" & c("control") & "' AND cod_perfil = '" & ActPerfil & "'", "Kiosco")

                    Acceso = False
                    If dtTemp.Rows.Count > 0 Then
                        Acceso = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("acceso")), False, dtTemp.Rows.Item(0).Item("acceso") = 1)
                    End If

                    c("acceso") = Acceso
                    If Acceso Then si = si + 1
                Next
            Next

            dgFormas.PrimaryGrid.DataSource = dtFormas

            'cmbModulos.DataSource = dtModulos
            ' cmbModulos.SelectedValue = ""
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub HabilitarPerfiles()
        Dim NoRec As Boolean

        Try
            NoRec = dtPerfiles.Rows.Count = 0
            txtCodigo.Enabled = Nuevo
            txtNombre.Enabled = (Nuevo Or Editar)
            chkTodosFormas.Enabled = (Nuevo Or Editar)

            'dgFormas.PrimaryGrid.ReadOnly = Not (Nuevo Or Editar)
            dgFormas.PrimaryGrid.Columns(2).AllowEdit = (Nuevo Or Editar)

            btnPrimero.Enabled = Not (Nuevo Or Editar Or NoRec)
            btnAnterior.Enabled = Not (Nuevo Or Editar Or NoRec)
            btnSiguiente.Enabled = Not (Nuevo Or Editar Or NoRec)
            btnUltimo.Enabled = Not (Nuevo Or Editar Or NoRec)

            btnBuscar.Enabled = Not (Nuevo Or Editar Or NoRec)
            btnBorrar.Enabled = Not (Nuevo Or Editar Or NoRec)
            btnCerrar.Enabled = Not (Nuevo Or Editar Or NoRec)

            btnReporte.Enabled = Not (Nuevo Or Editar Or NoRec)
            btnEditar.Enabled = Not (Not (Editar Or Nuevo) And NoRec)

            If Nuevo Or Editar Then
                ' Si está activa la edición o nuevo registro
                btnNuevo.Image = PIDA.My.Resources.Ok16
                btnEditar.Image = PIDA.My.Resources.CancelX
                btnNuevo.Text = "Aceptar"
                btnEditar.Text = "Cancelar"
                If Nuevo Then tabBuscar.SelectedTabIndex = 0
            Else

                btnNuevo.Image = PIDA.My.Resources.NewRecord
                btnEditar.Image = PIDA.My.Resources.Edit

                btnNuevo.Text = "Nuevo"
                btnEditar.Text = "Editar"
            End If

            txtCodigo.Enabled = Nuevo

            If Nuevo Then
                txtCodigo.Text = ""
                txtNombre.Text = ""
                ListarFORMAS()
                txtCodigo.Focus()
            ElseIf Editar Then
                ' txtNombre.Focus()
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub EditarPermisos(actPerfil As String)

        Dim nmControl As String
        Dim Acceso As Boolean
        Dim tipo As String
        Dim modulo As String = ""
        Dim Nombre As String = ""

        Try

            For Each dReg As DataRow In dtFormas.Rows
                nmControl = dReg("control")
                Acceso = dReg("acceso")
                Nombre = dReg("forma")
                tipo = "F"
                AfectaDatos(Acceso, actPerfil, nmControl, Nombre, tipo)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub AfectaDatos(ByVal Acceso As Boolean, ByVal actPerfil As String, ByVal nmControl As String, ByVal Nombre As String, _
                          ByVal tipo As String, Optional modulo As String = "")


        Try

            If Acceso Then
                dtTemporal = sqlExecute("SELECT acceso FROM permisos WHERE cod_perfil = '" & actPerfil & "' AND control = '" & nmControl & _
                                        "'", "Kiosco")
                If dtTemporal.Rows.Count = 0 Then
                    'No se encuentra el registro
                    sqlExecute("INSERT INTO permisos (cod_perfil,control,tipo,acceso,modulo,nombre) VALUES ('" & _
                               actPerfil & "','" & _
                               nmControl & "','" & _
                               tipo & "',1,'" & _
                               modulo & "','" & Nombre & "')", "Kiosco")
                Else
                    sqlExecute("UPDATE permisos SET acceso=1 WHERE cod_perfil = '" & actPerfil & _
                               "' AND control = '" & nmControl & "'", "Kiosco")
                End If
            Else
                'Si no se tiene acceso, borrar el registro en permisos -en caso de que existiera -
                sqlExecute("DELETE FROM permisos WHERE cod_perfil = '" & actPerfil & "' AND control = '" & nmControl & "'", "Kiosco")
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub frmPerfilesAdmKiosco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtTemp As New DataTable

        Try

            gpAvance.Visible = True
            pbAvance.IsRunning = True

            dgFormas.PrimaryGrid.AutoGenerateColumns = False

            'Asignar el estilo de pantallas de acuerdo a las preferencias seleccionadas por el usuario
            'MCR 21/OCT/2015
            'Regresar el estilo, ya que se pierde cuando se accesa al ribbon de frmMain
            dtTemp = sqlExecute("SELECT estilo,color FROM appuser WHERE username = '" & Usuario & "'", "Seguridad")

            Dim scheme As DevComponents.DotNetBar.eStyle
            Dim sSel As String = dtTemp.Rows.Item(0).Item("estilo").ToString.Trim
            scheme = CType(System.Enum.Parse(GetType(DevComponents.DotNetBar.eStyle), sSel, False), DevComponents.DotNetBar.eStyle)
            mgrColorTint = Color.FromArgb(IIf(IsDBNull(dtTemp.Rows.Item(0).Item("color")), -1, dtTemp.Rows.Item(0).Item("color")))
            mgrStyle = scheme
            frmMain.stlEstiloVIsual.ManagerStyle = mgrStyle
            frmMain.stlEstiloVIsual.ManagerColorTint = mgrColorTint
            My.Application.DoEvents()

            lblAvance.Text = "CARGANDO PERFILES"
            Application.DoEvents()

            lblAvance.Text = "HABILITANDO PERFILES"
            Application.DoEvents()
            dtPerfiles = sqlExecute("select top 1 * from perfiles ORDER BY cod_perfil", "Kiosco")

            ProcesoCancelado = True
            If ProcesoCancelado Then
                EmpNav.Enabled = False
                tabFormas.Enabled = False
                bgwRefresca.RunWorkerAsync()
            Else
                gpAvance.Visible = False
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub bgwRefresca_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwRefresca.DoWork
        Try
            ProcesoCancelado = False

            bgwRefresca.ReportProgress(0, "FORMAS")
            ListarFORMAS()
            dgFormas.PrimaryGrid.DataSource = dtFormas
            tabFormas.Enabled = True

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub bgwRefresca_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwRefresca.ProgressChanged
        lblAvance.Text = "___ ACCESOS ___" & vbCrLf & CType(e.UserState, String)
    End Sub

    Private Sub bgwRefresca_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwRefresca.RunWorkerCompleted
        Try

            RefrescaInformacion()
            HabilitarPerfiles()

            gpAvance.Visible = False
            pbAvance.IsRunning = False
            EmpNav.Enabled = True
            ProcesoCancelado = True

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub frmPerfilesAdmKiosco_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try

            ProcesoCancelado = True
            pbAvance.IsRunning = False

            My.Application.DoEvents()
            Me.Dispose()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("perfiles", "cod_perfil", dtPerfiles, "Kiosco")
        RefrescaInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("perfiles", "cod_perfil", txtCodigo.Text, dtPerfiles, "Kiosco")
        RefrescaInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("perfiles", "cod_perfil", txtCodigo.Text, dtPerfiles, "Kiosco")
        RefrescaInformacion()
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("perfiles", "cod_perfil", dtPerfiles, "Kiosco")
        RefrescaInformacion()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim Cod As String
            Cod = Buscar("kiosco.dbo.perfiles", "cod_perfil", "PERFILES", False)
            If Cod <> "CANCELAR" Then
                dtPerfiles = sqlExecute("SELECT * FROM perfiles WHERE COD_PERFIL = '" & Cod & "' ", "Kiosco")
                RefrescaInformacion()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try

            If Nuevo Then
                ' Si Agregar, revisar si existe cod_comp+cod_linea
                dtTemporal = sqlExecute("SELECT cod_perfil FROM perfiles where cod_perfil = '" & txtCodigo.Text & "'", "Kiosco")

                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, debido a que ya existe el perfil '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                Else

                    sqlExecute("INSERT INTO perfiles (cod_perfil,nombre) VALUES ('" & _
                              txtCodigo.Text & "','" & _
                              txtNombre.Text & "')", "Kiosco")

                    Nuevo = False

                    EditarPermisos(txtCodigo.Text)
                End If

            ElseIf Editar Then
                ' Si Editar, entonces guardar cambios a registro

                sqlExecute("UPDATE perfiles SET nombre = '" & txtNombre.Text & _
                          " WHERE cod_perfil = '" & txtCodigo.Text & "'", "Kiosco")

                EditarPermisos(txtCodigo.Text)

                dtPerfiles = sqlExecute("SELECT * FROM perfiles WHERE cod_perfil = '" & txtCodigo.Text & "'", "Kiosco")
                RefrescaInformacion()

            Else
                Nuevo = True
            End If

            Editar = False

            HabilitarPerfiles()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Nuevo Then
            Editar = True
            Nuevo = False
            HabilitarPerfiles()
            txtNombre.Focus()
        Else
            Editar = False
            Nuevo = False
            HabilitarPerfiles()
            RefrescaInformacion()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            Dim codigo As String
            codigo = txtCodigo.Text
            dtTemporal = sqlExecute("SELECT cod_perfil FROM appuser WHERE cod_perfil = '" & codigo & "'", "Kiosco")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    sqlExecute("DELETE FROM perfiles WHERE cod_perfil = '" & codigo & "'", "Kiosco")
                    sqlExecute("DELETE FROM permisos WHERE cod_perfil = '" & codigo & "'", "Kiosco")
                    btnSiguiente.PerformClick()
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkTodosFormas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosFormas.CheckedChanged
        Try

            Dim x As Integer = 0
            If chkTodosFormas.Checked Then
                chkTodosFormas.Text = "Desmarcar todos"

            Else
                chkTodosFormas.Text = "Marcar todos"
            End If

            Dim Filtro As String = ""
            Dim F As String = ""

            If Not dgFormas.PrimaryGrid.Columns(0).FilterExpr Is Nothing Then
                F = dgFormas.PrimaryGrid.Columns(0).FilterExpr
                F = F.Replace("[Módulo]", "modulo")
                If Not F.Contains("modulo") Then
                    F = "modulo " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                F = F.Replace(Chr(34), "'")
                Filtro = F

            End If

            If Not dgFormas.PrimaryGrid.Columns(1).FilterExpr Is Nothing Then
                F = dgFormas.PrimaryGrid.Columns(1).FilterExpr
                F = F.Replace("[Forma]", "forma")
                If Not F.Contains("forma") Then
                    F = "forma " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                F = F.Replace(Chr(34), "'")
                Filtro = Filtro & IIf(Filtro.Length = 0, F, " AND " & F)
            End If

            If Not dgFormas.PrimaryGrid.Columns(2).FilterExpr Is Nothing Then

                F = dgFormas.PrimaryGrid.Columns(2).FilterExpr
                F = F.Replace("[Acceso]", "acceso")
                If Not F.Contains("acceso") Then
                    F = "acceso " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                Filtro = Filtro & IIf(Filtro.Length = 0, F, " AND " & F)

            End If

            For Each dForma As DataRow In dtFormas.Select(Filtro)
                dForma("acceso") = chkTodosFormas.Checked
            Next

            dgFormas.Refresh()


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtUsuarios As New DataTable
        Dim dRow As DataRow
        Dim dPerfil As DataRow

        Try

            dtUsuarios = sqlExecute("SELECT perfiles.cod_perfil,ISNULL(nivel_consulta,0)nivel_consulta,ISNULL(nivel_sueldos,0) AS nivel_sueldos," & _
                                "ISNULL(nivel_edicion,0) AS nivel_edicion " & _
                                "FROM Kiosco.dbo.perfiles WHERE cod_perfil = '" & txtCodigo.Text.Trim & "'", "Kiosco")


            dtUsuarios.Columns.Add("modulo")
            dtUsuarios.Columns.Add("tipo")
            dtUsuarios.Columns.Add("control")

            dRow = dtUsuarios.Rows(0)

            dPerfil = dRow


            For Each dControl As DataRow In dtFormas.Rows
                dPerfil("modulo") = dControl("modulo")
                dPerfil("tipo") = "Formas"
                dPerfil("control") = dControl("forma")

                If dControl("acceso") Then
                    dtUsuarios.ImportRow(dPerfil)
                End If
            Next


            frmVistaPrevia.LlamarReporte("PerfilesAdmKiosco", dtUsuarios, "")
            frmVistaPrevia.ShowDialog()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class